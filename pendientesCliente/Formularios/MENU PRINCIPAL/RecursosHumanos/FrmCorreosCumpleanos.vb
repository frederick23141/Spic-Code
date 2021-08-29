Imports logicaNegocios
Public Class FrmCorreosCumpleanos
    Private objOpSimplesLn As New Op_simpesLn
    Private objEnvCorreoLN As New EnvCorreoLN
    Dim nomb_modulo As String = "FrmCorreosCumpleanos"
    Private Sub FrmCorreosCumpleanos_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Hide()
        Dim dt As DataTable = destinatarios()
        Dim dt_vencimiento_contratos As New DataTable
        Dim mensaje As String = ""
        For i = 0 To dt.Rows.Count - 1
            If Not IsDBNull(dt.Rows(i).Item("mail")) Then
                If (dt.Rows(i).Item("mail") <> "") Then
                    enviarCorreo(dt.Rows(i).Item("nombres"), dt.Rows(i).Item("mail"))
                    mensaje &= dt.Rows(i).Item("nombres") & vbCrLf
                End If
            End If
        Next
        mensaje &= personal_contrato_venc_10_dias()
        MessageBox.Show("Correos de cumpleaños enviados a:" & vbCrLf & vbCrLf & mensaje, "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information)
        If validar_fecha_desempeño() Then
            correos_Evaluacion_desempeño()
        End If
        Me.Close()
    End Sub
    Private Sub correos_Evaluacion_desempeño()
        Me.Hide()
        Dim dt As DataTable = destinatarios_coord()
        Dim dt_vencimiento_contratos As New DataTable
        Dim mensaje As String = ""
        For i = 0 To dt.Rows.Count - 1
            If Not IsDBNull(dt.Rows(i).Item("mail")) Then
                If (dt.Rows(i).Item("mail") <> "") Then
                    enviar_desempeño(dt.Rows(i).Item("nombres"), dt.Rows(i).Item("mail"))
                    mensaje &= dt.Rows(i).Item("nombres") & vbCrLf
                End If
            End If
        Next
        MessageBox.Show("Se ha enviado el recordatorio de la evaluación de desempeño a estos usuarios: " & vbNewLine & mensaje, "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
    End Sub
    Private Function validar_fecha_desempeño()
        Dim resp As Boolean = False
        Dim fecha_act As String = Date.Now.ToString("dd/MM/yyyy")
        Dim fecha As String = "27/09/" & Year(Now)
        Dim fecha_sup As String = "20/11/" & Year(Now)
        Dim fechai As Date = CDate(fecha)
        Dim fechas As Date = CDate(fecha_sup)

        If CDate(fecha_act) >= CDate(fecha) And CDate(fecha_act) <= CDate(fecha_sup) Then
            resp = True
        End If
        Return resp
    End Function
    Private Function personal_contrato_venc_10_dias() As String
        Dim resp As String = "Contratos a vencer en los proximos 10 días: " & vbCrLf
        Dim sql As String = "SELECT nit,nombres,fecha_final,DATEDIFF (DAY ,GETDATE (),fecha_final )As dias_faltantes " & _
                                        "FROM V_nom_personal_Activo_con_maquila " & _
                                            "WHERE fecha_final is not null AND DATEDIFF (DAY ,GETDATE (),fecha_final ) <=10"
        Dim dt As New DataTable
        dt = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        For i = 0 To dt.Rows.Count - 1
            resp &= "Cc:" & dt.Rows(i).Item("nit") & "-" & dt.Rows(i).Item("nombres") & "-fec_venc:" & objOpSimplesLn.cambiarFormatoFecha(dt.Rows(i).Item("fecha_final"))
        Next
        Return resp
    End Function
    Private Sub enviarCorreo(ByVal nombres As String, ByVal destino As String)
        Dim texto As String = modificarPlantilla(nombres)
        Dim titulo As String = "¡FELICIDADES EN TU CUMPLEAÑOS " & nombres & "!"
        Dim direccion As String = Environment.CurrentDirectory & "\tarjetacumple.jpg"
        Dim email As String = objOpSimplesLn.consultarVal("SELECT Mail from jjv_usuarios WHERE usuario like '%admin%'")
        Dim contra As String = objOpSimplesLn.consultarVal("SELECT Mail_login from jjv_usuarios WHERE usuario like '%admin%'")
        If Not (objEnvCorreoLN.EnviarCorreo(destino, texto, titulo, direccion, email, contra, True)) Then
            Using New Centered_MessageBox(Me)
                MessageBox.Show("Error al enviar el correo,comuniquese con el administrador del sistema!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
            End Using
        End If
    End Sub
    Private Sub enviar_desempeño(ByVal nombres As String, ByVal destino As String)
        Dim texto As String = "Durante el mes de octubre se deberan realizar las evaluaciones de desempeño," & _
                               "Hay plazo hasta el 20 de Noviembre."
        Dim titulo As String = "¡Se acerca la evaluación de desempeño! " & nombres & "!"
        Dim email As String = objOpSimplesLn.consultarVal("SELECT Mail from jjv_usuarios WHERE usuario like '%nomina%'")
        Dim contra As String = objOpSimplesLn.consultarVal("SELECT Mail_login from jjv_usuarios WHERE usuario like '%nomina%'")
        If Not (objEnvCorreoLN.EnviarCorreo(destino, texto, titulo, "", email, contra, False)) Then
            Using New Centered_MessageBox(Me)
                MessageBox.Show("Error al enviar el correo,comuniquese con el administrador del sistema!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
            End Using
        End If
    End Sub
    Private Function destinatarios() As DataTable
        Dim fec_min As Date = Now.Date
        Dim fec_max As Date = Now.Date
        If (Weekday(fec_min, vbMonday) = 6 Or Weekday(fec_min, vbMonday) = 7) Then
            fec_max = Now.AddDays(2)
        End If
        Dim sql As String = "SELECT nombres,mail FROM V_nom_personal_Activo_con_maquila WHERE MONTH(fecha_nacimiento ) >= " & fec_min.Month & " AND DAY (fecha_nacimiento ) >= " & fec_min.Day & " AND MONTH(fecha_nacimiento ) <= " & fec_max.Month & " AND DAY (fecha_nacimiento ) <= " & fec_max.Day & ""
        Return objOpSimplesLn.listar_datatable(sql, "CORSAN")
    End Function
    Private Function destinatarios_coord() As DataTable
        Dim sql As String = "SELECT nombres,mail FROM V_nom_personal_Activo_con_maquila WHERE nit in (9760043,43733334,43970009,71273681,98550501,21491229,98542805)"
        Return objOpSimplesLn.listar_datatable(sql, "CORSAN")
    End Function
    Private Function modificarPlantilla(ByVal nombres As String) As String
        Dim fic As String = Environment.CurrentDirectory & "\cumple.html"
        Dim texto As String = ""
        Dim sr As New System.IO.StreamReader(fic)
        texto = sr.ReadToEnd()
        texto = Replace(texto, "@nombres", nombres)
        texto = Replace(texto, "@ano", Now.Year)
        sr.Close()
        Return texto
    End Function
End Class