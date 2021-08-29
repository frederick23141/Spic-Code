Imports entidadNegocios
Imports logicaNegocios
Public Class FrmRegUsuario
    Private objUsuarioEn As New UsuarioEn
    Private objLoginLn As New LoginLn
    Private objOpSimplesLn As New Op_simpesLn
    Private Sub FrmRegUsuario_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim sql As String
        Dim dt As New DataTable
        Dim dr As DataRow
        cboTipo.DataSource = objOpSimplesLn.listar_datatable("SELECT descripcion FROM j_spic_permiso", "CORSAN")
        cboTipo.DisplayMember = "descripcion"
        cboTipo.ValueMember = "descripcion"
        cboTipo.Text = "Seleccione"


        Sql = "SELECT id,descripcion FROM C_cargos_corsan ORDER BY descripcion"
        dt = objOpSimplesLn.listar_datatable(Sql, "PRODUCCION")
        dr = dt.NewRow
        dr("id") = 0
        dr("descripcion") = "Seleccione"
        dt.Rows.Add(dr)
        cboCargo.DataSource = dt
        cboCargo.ValueMember = "id"
        cboCargo.DisplayMember = "descripcion"
        cboCargo.Text = "Seleccione"
        nuevo()

    End Sub
    Private Sub ckDesen_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckDesen.CheckedChanged
        If ckDesen.Checked = True Then
            txtContUsu.PasswordChar = ""
            txtRepConCorreo.PasswordChar = ""
            txtRepConUsu.PasswordChar = ""
            TxtConCorreo.PasswordChar = ""
        Else
            txtContUsu.PasswordChar = "*"
            txtRepConCorreo.PasswordChar = "*"
            txtRepConUsu.PasswordChar = "*"
            TxtConCorreo.PasswordChar = "*"
        End If
    End Sub
    Private Sub txtVend_TextChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtVend.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub
    Private Sub txtNit_TextChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNit.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub
    Private Function validar_Mail(ByVal sMail As String) As Boolean
        Dim emailRegex As New System.Text.RegularExpressions.Regex("^(?<user>[^@]+)@(?<host>.+)$")
        Dim emailMatch As System.Text.RegularExpressions.Match =
           emailRegex.Match(sMail)
        Return emailMatch.Success
    End Function
    Public Function validarCamposVacios() As Boolean
        If (txtUsuario.Text = "" Or TxtConCorreo.Text = "" Or txtContUsu.Text = "" Or txtRepConCorreo.Text = "" Or txtRepConUsu.Text = "" Or txtVend.Text = "" Or cboTipo.Text = "" Or cbo_bodega.Text = "" Or txt_nombres.Text = "" Or txtNit.Text = "" Or cboCargo.Text = "Seleccione") Then
            Return False
        Else
            Return True
        End If
    End Function
    Public Function validarContraseñas(ByVal cont1 As String, ByVal cont2 As String) As Boolean
        If (cont1 = cont2) Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Sub registrar()
        Dim autor As String = ""
        If (cboTipo.Text <> "Seleccione") Then
            If (validarCamposVacios()) Then
                If (validarContraseñas(txtRepConUsu.Text, txtContUsu.Text)) Then
                    If (validarContraseñas(txtRepConCorreo.Text, TxtConCorreo.Text)) Then
                        If Not (objLoginLn.existeUsuario(txtUsuario.Text)) Then
                            objUsuarioEn = New UsuarioEn
                            objUsuarioEn.nombre = txtUsuario.Text
                            objUsuarioEn.Vendedor = txtVend.Text
                            objUsuarioEn.EmailClave = TxtConCorreo.Text
                            objUsuarioEn.clave = txtContUsu.Text
                            objUsuarioEn.Email = txtCorreo.Text
                            objUsuarioEn.bodega = cbo_bodega.Text
                            objUsuarioEn.nombresCompleto = txt_nombres.Text
                            objUsuarioEn.permiso = cboTipo.Text
                            objUsuarioEn.cargo = cboCargo.SelectedValue
                            objUsuarioEn.nit = txtNit.Text
                            If (objLoginLn.insertarUsuario(objUsuarioEn) = 1) Then
                                MessageBox.Show("El usuario se ingreso en forma correcta!", "Exito!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                Me.Close()
                            End If
                        Else
                            MessageBox.Show("El usuario ya existe!", "Verifique!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If


                    Else
                        MessageBox.Show("Contraseñas de correo no coinsiden!", "Verifique!!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                Else
                    MessageBox.Show("Contraseñas de usuario no coinsiden!", "Verifique!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Else
                MessageBox.Show("Diligenciar todos los campos!", "Verifique!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Else
            MessageBox.Show("Escojer tipo de permiso!", "Verifique!", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Public Sub nuevo()
        txtRepConUsu.Enabled = True
        txtRepConCorreo.Enabled = True
        txtContUsu.Enabled = True
        TxtConCorreo.Enabled = True
        txtUsuario.Enabled = True
        txtUsuario.Text = ""
        txtVend.Text = ""
        TxtConCorreo.Text = ""
        txtContUsu.Text = ""
        txtCorreo.Text = ""
        txt_nombres.Text = ""
        cbo_bodega.Text = ""
        cboTipo.Text = ""
        txtRepConCorreo.Text = ""
        txtRepConUsu.Text = ""
        txtNit.Text = ""
    End Sub
    Private Sub eliminar()
        Dim resp As String = ""
        resp = InputBox("Ingrese usuario a eliminar:", "Eliminar")
        If (resp <> "") Then
            If (objLoginLn.eliminarUsuario(resp)) >= 1 Then
                MessageBox.Show("El usuario se elimino en forma correcta!", "Exito!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub
    Private Sub modificar()
        If (txt_nombres.Text = "") Then
            Frm_consultar.Show()
            MessageBox.Show("Seleccione un usuario a modificar!", "Seleccione!", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            If (validarContraseñas(Trim(TxtConCorreo.Text), Trim(txtRepConCorreo.Text))) Then
                If (validarContraseñas(Trim(txtContUsu.Text), Trim(txtRepConUsu.Text))) Then
                    objUsuarioEn.nombre = txtUsuario.Text
                    objUsuarioEn.Vendedor = txtVend.Text
                    objUsuarioEn.EmailClave = TxtConCorreo.Text
                    objUsuarioEn.clave = txtContUsu.Text
                    objUsuarioEn.Email = txtCorreo.Text
                    objUsuarioEn.bodega = cbo_bodega.Text
                    objUsuarioEn.nombresCompleto = txt_nombres.Text
                    objUsuarioEn.permiso = cboTipo.Text
                    objUsuarioEn.clave = txtContUsu.Text
                    objUsuarioEn.EmailClave = TxtConCorreo.Text
                    objUsuarioEn.cargo = cboCargo.SelectedValue
                    objUsuarioEn.nit = txtNit.Text
                    If (objLoginLn.mod_usuario(objUsuarioEn) >= 1) Then
                        MessageBox.Show("El usuario se modifico en forma correcta!", "Exito!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        nuevo()
                    End If
                Else
                    MessageBox.Show("Contraseñas de usuario no coinsiden!", "Verifique!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Else
                MessageBox.Show("Contraseñas de correo no coinsiden!", "Verifique!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub btn_consultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_consultar.Click
        Frm_consultar.Show()
    End Sub
    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        registrar()
    End Sub
    Private Sub btn_mod_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_mod.Click
        modificar()
    End Sub

    Private Sub btn_eliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_eliminar.Click
        eliminar()
    End Sub
    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        nuevo()
    End Sub
    Public Sub val_campo_blanco(ByVal txt As TextBox)
        If (txt.Text = "") Then
            txt.BackColor = Color.Red
        Else
            txt.BackColor = Color.White
        End If
    End Sub


 
End Class