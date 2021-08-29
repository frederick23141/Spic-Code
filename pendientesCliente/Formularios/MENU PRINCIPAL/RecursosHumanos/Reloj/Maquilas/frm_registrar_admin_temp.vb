Imports entidadNegocios
Imports logicaNegocios
Public Class frm_registrar_admin_temp
    Private objUsuarioEn As New UsuarioEn
    Private objLoginLn As New LoginLn
    Private objOpSimplesLn As New Op_simpesLn
    Private Sub btn_registrar_Click(sender As Object, e As EventArgs) Handles btn_registrar.Click
        If validar() Then
            insertar_temporal()
        End If
    End Sub
    Private Function validar()
        Dim resp As Boolean = False
        If txt_nomb.Text <> "" Then
            If txt_nit.Text <> "" And IsNumeric(txt_nit.Text) Then
                resp = True
            Else
                MessageBox.Show("LLenar el campo de nit o ingresar valor numerico", "LLenar campo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            MessageBox.Show("LLenar el campo de nombres y apellidos", "LLenar campo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Return resp
    End Function
    Private Sub insertar_temporal()
        Dim nomb As String = txt_nomb.Text
        Dim nit As String = txt_nit.Text
        Dim codigo_barras As String = "1234"
        Dim sql As String
        sql = "INSERT INTO J_personal_maquila (nombres,nit,cod_barras) values('" & nomb & "'," & nit & ",'" & codigo_barras & "')"
        objOpSimplesLn.ejecutar(sql, "CONTROL")
        MessageBox.Show("El temporal fue insertado correctamente", "LLenar campo", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
    End Sub
End Class