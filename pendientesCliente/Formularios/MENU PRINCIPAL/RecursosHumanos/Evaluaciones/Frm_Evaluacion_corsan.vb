Imports logicaNegocios
Imports entidadNegocios
Public Class Frm_Evaluacion_corsan
    Private obj_Ing_prodLn As New Ing_prodLn
    Private objOpsimpesLn As New Op_simpesLn
    Private obj_correoLn As New EnvCorreoLN
    Private usuario As String
    Private objUsuario As UsuarioEn
    Private Sub Frm_Evaluacion_corsan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargar_cbo()
        cbo_tipo_Evaluacion.Select()
    End Sub
    Public Sub Main(ByVal objUsuario As UsuarioEn)
        Me.objUsuario = objUsuario
        Me.usuario = objUsuario.usuario
        If Not IsNothing(objUsuario.nit) Then
            cbo_evaluador.SelectedValue = objUsuario.nit
        End If
    End Sub
    Private Sub txt_continuar_Click(sender As Object, e As EventArgs) Handles txt_continuar.Click
        If valida_tipo_evalua() Then
            If cbo_tipo_Evaluacion.Text = "Evaluación x Jefe" Then
                If validar_evaluado() Then
                    If validar_evaluador() Then
                        If validar_existencia("J") Then
                            Dim frm As New Frm_evaluacione_desempeno
                            frm.Show()
                            frm.Main(objUsuario, "J", cbo_empleados.SelectedValue, cbo_evaluador.SelectedValue)
                            frm.TabPage3.Parent = Nothing
                            frm.Activate()
                            Me.Close()
                        Else
                            MessageBox.Show("La persona ya fue evaluada por su jefe", "Evaluada por jefe", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    End If
                End If
            ElseIf cbo_tipo_Evaluacion.Text = "Evaluacion x Compañero" Then
                If validar_evaluado() Then
                    If validar_evaluador() Then
                        If validar_existencia("C") Then
                            Dim frm As New Frm_evaluacione_desempeno
                            frm.Show()
                            frm.Main(objUsuario, "C", cbo_empleados.SelectedValue, cbo_evaluador.SelectedValue)
                            frm.Activate()
                            Me.Close()
                        Else
                            MessageBox.Show("La persona ya fue evaluada por un compañero", "Evaluada por compañero", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    End If
                End If
            Else
                If validar_evaluado() Then
                    If validar_existencia("A") Then
                        If validar_contrasena() Then
                            Dim sql As String = "select contraseña  from D_autoEva_pass where nit=" & cbo_empleados.SelectedValue & ""
                            Dim val_contra = obj_Ing_prodLn.consultar_valor(sql, "CONTROL")
                            Dim contrasena = txt_contraseña.Text
                            If contrasena = val_contra Then
                                Dim frm As New Frm_evaluacione_desempeno
                                frm.Show()
                                frm.Main(objUsuario, "A", cbo_empleados.SelectedValue, cbo_empleados.SelectedValue)
                                frm.Activate()
                                Me.Close()
                            Else
                                MessageBox.Show("La contraseña no es la correcta", "Contraseña no es correcta", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            End If
                        End If
                    Else
                        MessageBox.Show("La persona ya hizo la autoevaluación", "Ya hizo la autoevaluación", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End If
                End If
        End If
    End Sub
    Private Function validar_evaluado()
        Dim resp As Boolean = False
        If cbo_empleados.SelectedValue <> 0 Then
            resp = True
        Else
            MessageBox.Show("Seleccione alguien a evaluar", "Empleado no seleccionado", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Return resp
    End Function
    Private Function validar_evaluador()
        Dim resp As Boolean = False
        If cbo_evaluador.SelectedValue <> 0 Then
            resp = True
        Else
            MessageBox.Show("Seleccione Evaluador", "Empleado no seleccionado", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Return resp
    End Function
    Private Function valida_tipo_evalua()
        Dim resp As Boolean = False
        If cbo_tipo_Evaluacion.Text <> "" Then
            resp = True
        Else
            MessageBox.Show("Seleccione tipo de evaluación", "Tipo de evaluación no seleccionado", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Return resp
    End Function
    Private Function validar_contrasena()
        Dim resp As Boolean = False
        If txt_contraseña.Text <> "" Then
            If IsNumeric(txt_contraseña.Text) Then
                resp = True
            Else
                MessageBox.Show("La contraseña debe ser numerica", "Contraseña no es numerica", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            MessageBox.Show("Ingrese la contraseña", "No ha ingresado la contraseña", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Return resp
    End Function
    Private Function validar_existencia(ByVal tipo As String)
        Dim resp = False
        Dim sql As String
        Dim valor As String
        If tipo = "A" Then
            sql = "Select id from J_eval_enc where year(fecha)=" & Now.Year & " and tipo='A' and nit=" & cbo_empleados.SelectedValue & ""
        ElseIf tipo = "J" Then
            sql = "Select id from J_eval_enc where year(fecha)=" & Now.Year & " and tipo='J' and nit=" & cbo_empleados.SelectedValue & ""
        Else
            sql = "Select id from J_eval_enc where year(fecha)=" & Now.Year & " and tipo='C' and nit=" & cbo_empleados.SelectedValue & ""
        End If
        valor = objOpsimpesLn.consultValorTodo(sql, "CORSAN")
        If valor = "" Then
            resp = True
        End If
        Return resp
    End Function
    Private Sub cargar_cbo()
        Dim dt As New DataTable
        Dim row As DataRow
        Dim Sql As String
        Sql = "SELECT nit,nombres FROM V_nom_personal_Activo_con_maquila_general order by nombres"
        dt = obj_Ing_prodLn.listar_datatable(Sql, "CORSAN")
        row = dt.NewRow
        row("nit") = 0
        row("nombres") = "Seleccione"
        dt.Rows.Add(row)
        cbo_empleados.DataSource = dt
        cbo_empleados.ValueMember = "nit"
        cbo_empleados.DisplayMember = "nombres"
        cbo_empleados.SelectedValue = 0
        Sql = "SELECT nit,nombres FROM V_nom_personal_Activo_con_maquila_general order by nombres"
        dt = obj_Ing_prodLn.listar_datatable(Sql, "CORSAN")
        row = dt.NewRow
        row("nit") = 0
        row("nombres") = "Seleccione"
        dt.Rows.Add(row)
        cbo_evaluador.DataSource = dt
        cbo_evaluador.ValueMember = "nit"
        cbo_evaluador.DisplayMember = "nombres"
        cbo_evaluador.SelectedValue = 0
    End Sub

    Private Sub cbo_tipo_Evaluacion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbo_tipo_Evaluacion.SelectedIndexChanged
        If cbo_tipo_Evaluacion.Text = "Autoevaluacion" Then
            cbo_evaluador.Enabled = False
            gb_contraseña.Visible = True
            btn_contraseña.Visible = True
        ElseIf cbo_tipo_Evaluacion.Text = "Evaluación x Jefe" Then
            cbo_evaluador.SelectedValue = objUsuario.nit
            cbo_evaluador.Enabled = False
            txt_contraseña.Text = ""
            cbo_evaluador.Enabled = False
            gb_contraseña.Visible = False
            btn_contraseña.Visible = False
        Else
            txt_contraseña.Text = ""
            cbo_evaluador.Enabled = True
            gb_contraseña.Visible = False
            btn_contraseña.Visible = False
        End If
    End Sub
    Private Sub enviarCorreoClave(ByVal clave As Integer)
        Dim sql_admin As String = "SELECT mail,Mail_login  FROM Jjv_usuarios WHERE usuario = 'ADMIN' "
        Dim dt_admin As DataTable = objOpsimpesLn.listar_datatable(sql_admin, "CORSAN")
        Dim mail As String = "faysury.rios@corsan.com.co"
        Dim asunto As String = "Contraseña para autoevaluacíon de: " & cbo_empleados.Text & ""
        Dim cuerpo As String = "La contraseña es: " & clave & vbCrLf & _
                               "Fecha: " & Now
        Dim mailEnvia As String = dt_admin.Rows(0).Item("mail")
        Dim mailEnviaPass As String = dt_admin.Rows(0).Item("Mail_login")
        obj_correoLn.EnviarCorreo(mail, cuerpo, asunto, "", mailEnvia, mailEnviaPass, False)
        mail = "david.hincapie@corsan.com.co"
        obj_correoLn.EnviarCorreo(mail, cuerpo, asunto, "", mailEnvia, mailEnviaPass, False)
    End Sub
    Private Sub btn_contraseña_Click(sender As Object, e As EventArgs) Handles btn_contraseña.Click
        If validar_evaluado() Then
            Dim num_aleatorio As New Random()
            Dim clave As Integer = num_aleatorio.Next(1, 10000)
            Dim sql As String = "select nit from D_autoEva_pass where nit=" & cbo_empleados.SelectedValue & ""
            Dim valor As String = obj_Ing_prodLn.consultar_valor(sql, "CONTROL")
            If valor = "0" Then
                sql = "INSERT INTO D_autoEva_pass (nit,contraseña) values(" & cbo_empleados.SelectedValue & "," & clave & ")"
                objOpsimpesLn.ejecutar(sql, "CONTROL")
            Else
                sql = "UPDATE D_autoEva_pass SET contraseña=" & clave & " where nit=" & cbo_empleados.SelectedValue & ""
                objOpsimpesLn.ejecutar(sql, "CONTROL")
            End If
            enviarCorreoClave(clave)
            MessageBox.Show("Contraseña generada", "Contraseña", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
End Class