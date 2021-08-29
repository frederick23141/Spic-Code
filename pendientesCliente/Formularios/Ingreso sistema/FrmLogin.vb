Imports System.Configuration
Imports entidadNegocios
Imports logicaNegocios
Public Class FrmLogin
    Private objLoginLn As New LoginLn
    Private objUsuarioEn As UsuarioEn
    Private obj_Ing_prodLn As New Ing_prodLn
    Dim frm As New Frm_alerta_bd
    Dim val_timer As String
    Private Sub Login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtUsuario.Focus()
    End Sub
    Private Sub BtnIngresar_Click_1(sender As Object, e As EventArgs) Handles btnIngresar.Click
        Dim tipo As String = ""
        'If (SystemInformation.ComputerName = "BAJOGRANDE2" And txtUsuario.Text = "" And txtContra.Text = "") Then
        '    txtUsuario.Text = "admin"
        '    txtContra.Text = "sistemas"
        'End If
        If (SystemInformation.ComputerName = "CONTABILIDAD-A" And txtUsuario.Text = "" And txtContra.Text = "") Then
            txtUsuario.Text = "admin"
            txtContra.Text = "sistemas"
        End If
        objUsuarioEn = objLoginLn.tipoUsuario(txtUsuario.Text, txtContra.Text)
        tipo = objUsuarioEn.permiso


        If (objUsuarioEn.usuario = "GALVANIZADO") Then
            FrmOrdenProdGalv.Show()
            FrmOrdenProdGalv.main(objUsuarioEn)
            FrmOrdenProdGalv.Activate()
            Me.Close()
        ElseIf (objUsuarioEn.usuario = "GALVANIZADO1") Then
            FrmOrdenProdGalv.Show()
            FrmOrdenProdGalv.main(objUsuarioEn)
            FrmOrdenProdGalv.Activate()
            Me.Close()
        ElseIf (objUsuarioEn.usuario = "operarios") Then
            FrmOrdenProdTef.Show()
            FrmOrdenProdTef.Activate()
            FrmOrdenProdTef.main("operario", "", objUsuarioEn.nit)
        ElseIf (objUsuarioEn.usuario = "puntilleria") Then
            Frm_orden_prod_punt.Show()
            Frm_orden_prod_punt.Activate()
            Frm_orden_prod_punt.main(objUsuarioEn)
            Me.Close()
        ElseIf (objUsuarioEn.usuario = "recocido") Then
            frm_ordne_prdo_rec2.Show()
            frm_ordne_prdo_rec2.Activate()
            frm_ordne_prdo_rec2.main(objUsuarioEn)
            Me.Close()
        ElseIf (objUsuarioEn.usuario = "puas") Then
            frm_control_orden_puas.Show()
            frm_control_orden_puas.Activate()
            Me.Close()
        Else
            If (tipo <> "") Then
                If tipo = "SALUD_OCUPACIONAL" Then
                    FrmPrincipal.Show()
                    FrmPrincipal.Activate()
                    FrmPrincipal.Main(tipo, objUsuarioEn, False)
                    Me.Close()
                Else
                    FrmPrincipal.Show()
                    FrmPrincipal.Activate()
                    FrmPrincipal.Main(tipo, objUsuarioEn, True)
                    Me.Close()
                End If
            Else
                txtContra.Text = ""
                MessageBox.Show("Usuario ò contraseña incorrectos!", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub
    Private Sub txtContra_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtContra.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            btnIngresar.PerformClick()
        End If
    End Sub
    Private Sub txtUsuario_Enter(ByVal sender As Object, ByVal e As EventArgs) Handles txtUsuario.Enter
        txtUsuario.BackColor = Color.FromArgb(251, 173, 33)
    End Sub
    Private Sub txtUsuario_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles txtUsuario.Leave
        txtUsuario.BackColor = Color.White
    End Sub
    Private Sub txtContra_Enter(ByVal sender As Object, ByVal e As EventArgs) Handles txtContra.Enter
        txtContra.BackColor = Color.FromArgb(251, 173, 33)
    End Sub
    Private Sub txtContra_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles txtContra.Leave
        txtContra.BackColor = Color.White
    End Sub
    Private Sub btnIngresar_Enter(ByVal sender As Object, ByVal e As EventArgs)
        btnIngresar.BackColor = Color.Lime
    End Sub
    Private Sub btnIngresar_Leave(ByVal sender As Object, ByVal e As EventArgs)
        btnIngresar.BackColor = Color.White
    End Sub
    Private Sub txtUsuario_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txtUsuario.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            txtContra.Focus()
        End If
    End Sub
    Private Sub Cerrar_forzado_Tick(sender As Object, e As EventArgs) Handles Cerrar_forzado.Tick
        Dim sql As String
        sql = "select * from J_spic_cerrar_aplicacion"
        If obj_Ing_prodLn.consultar_valor(sql, "CORSAN") <> "0" Then
            Application.ExitThread()
        End If
    End Sub
    Private Sub timer_ping_bd_Tick(sender As Object, e As EventArgs) Handles timer_ping_bd.Tick
        If My.Computer.Network.IsAvailable() Then
            If val_timer = "1" Then
                Cerrar_forzado.Enabled = True
                val_timer = ""
                frm.Close()
            End If
            If My.Computer.Network.Ping("10.10.10.246", 5000) Then
                If val_timer = "1" Then
                    Cerrar_forzado.Enabled = True
                    val_timer = ""
                    frm.Close()
                End If
            Else
                If val_timer <> "1" Then
                    If validar_formu() Then
                        val_timer = "1"
                        Cerrar_forzado.Enabled = False
                        frm.ShowDialog()
                    End If
                End If
            End If
        Else
            If val_timer <> "1" Then
                If validar_formu() Then
                    val_timer = "1"
                    Cerrar_forzado.Enabled = False
                    frm.ShowDialog()
                End If
            End If
        End If
    End Sub
    Private Function validar_formu()
        Dim resp As Boolean = True
        For Each f As Form In Application.OpenForms
            If f.Name = frm.Name Then
                resp = False
            End If
        Next
        Return resp
    End Function


End Class