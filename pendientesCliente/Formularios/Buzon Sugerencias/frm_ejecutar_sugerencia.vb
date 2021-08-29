Imports entidadNegocios
Imports logicaNegocios

Public Class frm_ejecutar_sugerencia

    Dim id_sug As Integer = 0
    Dim usuario As UsuarioEn
    Dim doc As Integer = 0

    Private objOpSimplesLn As New Op_simpesLn
    Private obj_correoLn As New EnvCorreoLN
    Private obj_Ing_prodLn As New Ing_prodLn

    Public Sub main(ByVal consecutivo As Integer, ByVal us As UsuarioEn, ByVal doc As Integer)
        Me.Text = "Ejecutar Sugerencia #" & consecutivo
        id_sug = consecutivo
        usuario = us
        Me.doc = doc
    End Sub

    ''metodo que se encarga de controlar la ejecucion de la sugerencia
    Private Sub frm_ejecutar_sugerencia_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim sql As String = ""
        Dim dt As New DataTable

        'CBO De Clientes
        sql = "SELECT id_area,area FROM JB_buzon_sugerencias_area ORDER BY area"
        dt = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        dt.Rows.Add()
        dt.Rows(dt.Rows.Count - 1).Item("id_area") = 0
        dt.Rows(dt.Rows.Count - 1).Item("area") = "Seleccione Area"
        cbo_area.DataSource = dt
        cbo_area.ValueMember = "id_area"
        cbo_area.DisplayMember = "area"
        cbo_area.SelectedValue = 0
    End Sub

    ''metodo que se encarga de actualizar la transacion si se ejecuta o se denega
    Private Sub btn_ejec_Click(sender As Object, e As EventArgs) Handles btn_ejec.Click
        Dim listSql As New List(Of Object)
        If cbo_area.SelectedValue <> 0 Then
            Dim sql As String = "UPDATE JB_buzon_sugerencias SET estado = 4, fec_ejec = GETDATE(), area = " & cbo_area.SelectedValue & " WHERE id_sugerencia = " & id_sug
            listSql.Add(sql)

            sql = "SELECT puntos FROM JB_buzon_sugerencias_puntos WHERE doc = " & doc
            Dim puntos As Integer = obj_Ing_prodLn.consultar_valor(sql, "CORSAN") + 5

            sql = "INSERT INTO JB_buzon_historial_puntos (doc,fec,cant,razon) VALUES (" & _
                        doc & ",getdate(),5,'SUGERENCIA EN EJECUCION')"
            listSql.Add(sql)

            sql = "UPDATE JB_buzon_sugerencias_puntos SET puntos =" & puntos & " WHERE doc =" & doc
            listSql.Add(sql)
            If obj_Ing_prodLn.ExecuteSqlTransaction(listSql, "CORSAN") Then
                MessageBox.Show("La sugerencia #" & id_sug & " se coloco en Ejecucion.", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information)
                enviar_correo(cbo_area.SelectedValue)
                enviar_correo_eje(doc)
                Me.Close()
            End If
        Else
            MessageBox.Show("Debe digitar un motivo para poder denegar la Sugerencia.", "Digitar Motivo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub


    ''metodo que envia correo con los datos de la sugerencia en ejecucion para su revision en el spic
    Private Sub enviar_correo(ByVal areas As Integer)
        Dim sql As String = "SELECT mail,Mail_login  FROM Jjv_usuarios WHERE usuario = 'ADMIN'"
        Dim dt_admin As DataTable = objOpSimplesLn.listar_datatable(sql, "CORSAN")

        sql = "SELECT correo FROM JB_buzon_sugerencias_area WHERE id_area =" & areas
        Dim mail As String = objOpSimplesLn.consultValorTodo(sql, "CORSAN")

        Dim asunto As String = "Sugerencia para Ejecucion."
        Dim cuerpo As String = "DEBE EJECUTAR UNA SUGERENCIA" & vbCrLf & _
                                "" & vbCrLf & _
                                "Consecutivo: " & id_sug & vbCrLf & _
                                "Fecha: " & Now & vbCrLf & _
                                "USUARIO QUE TRANSFIERE: " & usuario.nombresCompleto & vbCrLf & _
                                "POR FAVOR REVISAR EL SPIC." & vbCrLf & _
                                "(Recuerde que sera evaluado dependiendo de las sugerencias que revise)"

        Dim mailEnvia As String = dt_admin.Rows(0).Item("mail")
        Dim mailEnviaPass As String = dt_admin.Rows(0).Item("Mail_login")
        obj_correoLn.EnviarCorreo(mail.Trim, cuerpo, asunto, "", mailEnvia, mailEnviaPass, False)
    End Sub

    ''metodo que se encarga de enviar el correo con los datos de la sugerencia en ejecucion
    Private Sub enviar_correo_eje(ByVal nit As Integer)
        Dim sql As String = "SELECT mail,Mail_login  FROM Jjv_usuarios WHERE usuario = 'ADMIN'"
        Dim dt_admin As DataTable = objOpSimplesLn.listar_datatable(sql, "CORSAN")

        sql = "SELECT mail FROM v_nom_personal WHERE nit =" & nit
        Dim mail As String = objOpSimplesLn.consultValorTodo(sql, "CORSAN")

        Dim asunto As String = "Sugerencia en Ejecucion"
        Dim cuerpo As String = "SUGERENCIA EN EJECUCION" & vbCrLf & _
                                "" & vbCrLf & _
                                "Consecutivo:  " & id_sug & vbCrLf & _
                                "Fecha:  " & Now & vbCrLf
        Dim mailEnvia As String = dt_admin.Rows(0).Item("mail")
        Dim mailEnviaPass As String = dt_admin.Rows(0).Item("Mail_login")
        obj_correoLn.EnviarCorreo(mail.Trim, cuerpo, asunto, "", mailEnvia, mailEnviaPass, False)
    End Sub
End Class