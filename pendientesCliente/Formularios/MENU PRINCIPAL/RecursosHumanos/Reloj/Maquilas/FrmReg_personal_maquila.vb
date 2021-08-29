Imports entidadNegocios
Imports logicaNegocios
Public Class FrmReg_personal_maquila
    Private objUsuarioEn As New UsuarioEn
    Private objLoginLn As New LoginLn
    Private objOpSimplesLn As New Op_simpesLn
    Dim nit_reci As String
    Private Sub FrmRegUsuario_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        nuevo()
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
    Public Sub obtener_nit(ByVal nit As String)
        nit_reci = nit
    End Sub
    Public Function validarCamposVacios() As Boolean
        If (txt_nombres.Text = "" Or txtNit.Text = "" Or txt_cod_lector.Text = "") Then
            Return False
        Else
            Return True
        End If
    End Function
    Public Sub registrar()
        Dim autor As String = ""
        If (validarCamposVacios()) Then
            If Not (existeUsuario(txtNit.Text)) Then
                Dim nit As Double = txtNit.Text
                Dim nombres As String = txt_nombres.Text
                Dim codigo As String = txt_cod_lector.Text.Trim
                Dim sql As String = "INSERT INTO J_personal_maquila (nit,nombres,cod_barras,estado) VALUES (" & nit & ",'" & nombres & "','" & codigo & "','A') "
                If (objOpSimplesLn.ejecutar(sql, "CONTROL") > 0) Then
                    MessageBox.Show("El usuario se ingreso en forma correcta!", "Exito!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Close()
                End If
            Else
                MessageBox.Show("El usuario ya existe!", "Verifique!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            MessageBox.Show("Diligenciar todos los campos!", "Verifique!", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
    Private Function existeUsuario(ByVal nit As Double) As Boolean
        Dim sql As String = "SELECT nit FROM J_personal_maquila WHERe nit = " & nit & " and desactivar is null"
        Dim resp As String = objOpSimplesLn.consultValorTodo(sql, "CONTROL").Length
        If resp <> "0" Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Sub nuevo()
        txt_cod_lector.Text = ""
        txt_nombres.Text = ""
        txtNit.Text = ""
    End Sub
    Private Sub eliminar()
        Dim resp As String = ""
        Dim fecha_retiro As String
        Dim sql As String
        resp = InputBox("Ingrese nit a eliminar:", "Eliminar")
        If (resp <> "") Then
            pn_fec_ret.Visible = True
            fecha_retiro = dtp_fec_ret.Value.ToString("yyyy/MM/dd")
            sql = "update J_personal_maquila set fecha_final='" & fecha_retiro & "',estado='R' where nit=" & resp & ""
            If objOpSimplesLn.ejecutar(sql, "CONTROL") Then
                If (eliminarUsuario(resp)) Then
                    MessageBox.Show("El usuario se elimino en forma correcta!", "Exito!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    pn_fec_ret.Visible = False
                End If
            Else
                MessageBox.Show("Error al eliminar!", "Exito!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        End If
    End Sub
    Private Function eliminarUsuario(ByVal nit As Double) As Boolean
        Dim sql As String = "UPDATE J_personal_maquila set desactivar=1,estado='R' where nit = " & nit
        If (objOpSimplesLn.ejecutar(sql, "CONTROL") > 1) Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub btn_consultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_consultar.Click
        Frm_consultar_usu_mauquilas.Show()
    End Sub
    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        registrar()
    End Sub
    Private Sub btn_eliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_eliminar.Click
        pn_fec_ret.Visible = True
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
    Private Sub txt_cod_lector_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_cod_lector.KeyPress
        If (e.KeyChar = Microsoft.VisualBasic.ChrW(13)) Then
            registrar()
        End If
    End Sub
    Private Sub btn_button_Click(sender As Object, e As EventArgs) Handles btn_button.Click
        Dim frm As New Frm_consultar_Empleado_Temporales
        frm.main(Me)
        frm.ShowDialog()
        txtNit.Text = nit_reci
    End Sub
    Private Sub btn_delete_Click(sender As Object, e As EventArgs) Handles btn_delete.Click
        eliminar()
    End Sub
    Private Sub tsb_temporal_Click(sender As Object, e As EventArgs) Handles tsb_temporal.Click
        Dim frm As New frm_registrar_admin_temp
        frm.Show()
    End Sub
End Class