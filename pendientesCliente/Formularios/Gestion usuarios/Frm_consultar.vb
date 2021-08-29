Imports System.Configuration
Imports logicaNegocios
Imports entidadNegocios
Imports System.IO
Imports Microsoft.Office.Interop
Public Class Frm_consultar
    Private strSql As String
    Private objLoginLn As New LoginLn
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        usuarios()
    End Sub

    Public Sub usuarios()

        If txtNunVend.Text <> "" And txtNombres.Text <> "" Then

            strSql = "SELECT U.usuario,U.Login,U.nit, U.Nombres, U.Autorizacion,U.Mail,U.Mail_login,U.Bodega,U.Vendedor,C.descripcion as cargo,C.id as id_cargo " & _
                         "FROM Jjv_usuarios U ,PRGPRODUCCION.dbo.C_cargos_corsan C " & _
                     "WHERE C.id = U.cargo AND Vendedor LIKE '" & txtNunVend.Text & "%' AND " & _
                     "      nombres LIKE '%" & txtNombres.Text & "%' " & _
                     "ORDER BY nombres"

        ElseIf txtNunVend.Text = "" And txtNombres.Text = "" Then
            strSql = "SELECT U.usuario,U.Login,U.nit, U.Nombres, U.Autorizacion,U.Mail,U.Mail_login,U.Bodega,U.Vendedor,C.descripcion as cargo,C.id as id_cargo " & _
                                     "FROM Jjv_usuarios U ,PRGPRODUCCION.dbo.C_cargos_corsan C " & _
                                                  "WHERE C.id = U.cargo " & _
                            "ORDER BY nombres"


        ElseIf txtNunVend.Text = "" And txtNombres.Text <> "" Then

            strSql = "SELECT U.usuario,U.Login,U.nit, U.Nombres, U.Autorizacion,U.Mail,U.Mail_login,U.Bodega,U.Vendedor,C.descripcion as cargo,C.id as id_cargo " & _
                           "FROM Jjv_usuarios U ,PRGPRODUCCION.dbo.C_cargos_corsan C " & _
                       "WHERE C.id = U.cargo AND nombres LIKE '%" & txtNombres.Text & "%'  " & _
                       "ORDER BY nombres"

        ElseIf txtNunVend.Text <> "" And txtNombres.Text = "" Then
            strSql = "SELECT U.usuario,U.Login,U.nit, U.Nombres, U.Autorizacion,U.Mail,U.Mail_login,U.Bodega,U.Vendedor,C.descripcion as cargo,C.id as id_cargo " & _
                                "FROM Jjv_usuarios U ,PRGPRODUCCION.dbo.C_cargos_corsan C " & _
                            "WHERE C.id = U.cargo AND Vendedor LIKE '" & txtNunVend.Text & "%'  " & _
                            "ORDER BY nombres"
        End If

        dtg_clientes.DataSource = objLoginLn.listar_clientes(strSql)
    End Sub

    Private Sub txtNit_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNunVend.TextChanged
        txtNombres.Text = ""
        usuarios()
    End Sub

    Private Sub txtNombres_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNombres.TextChanged
        txtNunVend.Text = ""
        usuarios()
    End Sub

    Private Sub dtg_clientes_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtg_clientes.CellDoubleClick
        FrmRegUsuario.Show()
        FrmRegUsuario.txtUsuario.Text = dtg_clientes.Item("usuario", e.RowIndex).Value
        FrmRegUsuario.txtCorreo.Text = dtg_clientes.Item("Mail", e.RowIndex).Value
        FrmRegUsuario.cboTipo.Text = dtg_clientes.Item("Autorizacion", e.RowIndex).Value
        FrmRegUsuario.cbo_bodega.Text = dtg_clientes.Item("Bodega", e.RowIndex).Value
        FrmRegUsuario.txt_nombres.Text = dtg_clientes.Item("Nombres", e.RowIndex).Value
        FrmRegUsuario.txtVend.Text = dtg_clientes.Item("Vendedor", e.RowIndex).Value
        FrmRegUsuario.txtContUsu.Text = dtg_clientes.Item("Login", e.RowIndex).Value
        FrmRegUsuario.txtRepConUsu.Text = dtg_clientes.Item("Login", e.RowIndex).Value
        FrmRegUsuario.TxtConCorreo.Text = dtg_clientes.Item("Mail_login", e.RowIndex).Value
        FrmRegUsuario.txtRepConCorreo.Text = dtg_clientes.Item("Mail_login", e.RowIndex).Value
        FrmRegUsuario.cboCargo.SelectedValue = dtg_clientes.Item("id_cargo", e.RowIndex).Value
        If Not IsDBNull(dtg_clientes.Item("nit", e.RowIndex).Value) Then
            FrmRegUsuario.txtNit.Text = dtg_clientes.Item("nit", e.RowIndex).Value
        End If
        'FrmRegUsuario.txtRepConUsu.Enabled = False
        'FrmRegUsuario.txtRepConCorreo.Enabled = False
        'FrmRegUsuario.txtContUsu.Enabled = False
        'FrmRegUsuario.TxtConCorreo.Enabled = False
        'FrmRegUsuario.txtUsuario.Enabled = False
        Me.Close()
    End Sub
End Class
