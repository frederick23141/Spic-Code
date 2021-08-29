Imports logicaNegocios
Imports entidadNegocios
Public Class Frm_Mantenimiento_Planta
    Private objOpSimplesLn As New Op_simpesLn
    Private objOpsimpesLn As New Op_simpesLn
    Private obj_correoLn As New EnvCorreoLN
    Private Sub Frm_Mantenimiento_Planta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargar_cbo()
    End Sub
    Private Sub cargar_cbo()
        Dim sql As String
        Dim dt As New DataTable

        sql = "select t.id,t.nombres from terceros t join y_personal_contratos c on t.nit=c.nit  where t.nit in (select nit from control.dbo.D_empleados_sin_salida) and c.estado='A'  and (c.centro_planta = 2100 or c.centro_planta = 2200 or c.centro_planta is null)"
        'Cargar datos de los Hornos

        dt = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        dt.Rows.Add()
        dt.Rows(dt.Rows.Count - 1).Item("id") = 0
        dt.Rows(dt.Rows.Count - 1).Item("nombres") = "Seleccione"
        cbo_operario_sol.DataSource = dt
        cbo_operario_sol.ValueMember = "id"
        cbo_operario_sol.DisplayMember = "nombres"
        cbo_operario_sol.SelectedValue = 0

        sql = "select id,descripcion from mto_equipos "
        dt = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        dt.Rows.Add()
        dt.Rows(dt.Rows.Count - 1).Item("id") = 0
        dt.Rows(dt.Rows.Count - 1).Item("descripcion") = "Seleccione"
        cbo_maquina_afec.DataSource = dt
        cbo_maquina_afec.ValueMember = "id"
        cbo_maquina_afec.DisplayMember = "descripcion"
        cbo_maquina_afec.SelectedValue = 0

    End Sub

    Private Sub Btn_realizar_Click(sender As Object, e As EventArgs) Handles btn_realizar.Click
        Dim sql As String
        sql = "select (max(numero)+1) as numero from mto_solicitudes "
        Dim numero As Integer = objOpSimplesLn.consultValorTodo(sql, "CORSAN")
        Dim id_equipo As Integer = cbo_maquina_afec.SelectedValue
        Dim solicitante As Integer = cbo_operario_sol.SelectedValue
        Dim descripcion As String = txt_solicitado.Text
        If validar_entrada() Then
            sql = "INSERT INTO  mto_solicitudes (TIPO,NUMERO,origen,id_equipo,id_prioridad,id_solicitante,fecha_creacion,descripcion,estado,usuario_crea,fecha_requerida)" &
              " VALUES ('COR'," & numero & ",'S'," & id_equipo & ",3," & solicitante & ",getdate(),'" & descripcion & "','A','SPIC',getdate())"
            objOpSimplesLn.ejecutar(sql, "CORSAN")
            enviarCorreoMan(numero)
            MessageBox.Show("La solicitud fue registrada,pronto sera atendida.El numero es:" & numero & "", "Mantenimiento", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        Else
            MessageBox.Show("Alguno de los campos no esta bien diligenciado", "Ingresarlo correctamente", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
    Private Function validar_entrada()
        Dim resp As Boolean = False
        If cbo_maquina_afec.Text <> "Seleccione" Then
            If cbo_maquina_afec.Text <> "Seleccione" Then
                If txt_solicitado.Text <> "" Then
                    resp = True
                End If
            End If
        End If
        Return resp
    End Function
    Private Sub enviarCorreoMan(ByVal numero As Double)
        Dim sql_admin As String = "SELECT mail,Mail_login  FROM Jjv_usuarios WHERE usuario = 'ADMIN' "
        Dim dt_admin As DataTable = objOpsimpesLn.listar_datatable(sql_admin, "CORSAN")
        Dim mail As String = "mantenimiento@corsan.com.co"
        Dim asunto As String = "Se ingreso solicitud de mantenimiento por parte de " & cbo_solicitante.Text & ""
        Dim cuerpo As String = "Número de la solicitud : " & numero & "" & vbCrLf &
                                "Maquina : " & cbo_maquina_afec.Text & " " & vbCrLf &
                                "Fecha: " & Now
        Dim mailEnvia As String = dt_admin.Rows(0).Item("mail")
        Dim mailEnviaPass As String = dt_admin.Rows(0).Item("Mail_login")
        obj_correoLn.EnviarCorreo(mail, cuerpo, asunto, "", mailEnvia, mailEnviaPass, False)
    End Sub
End Class
