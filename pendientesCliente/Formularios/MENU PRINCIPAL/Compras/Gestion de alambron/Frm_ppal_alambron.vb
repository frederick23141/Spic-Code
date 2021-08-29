Imports logicaNegocios
Imports entidadNegocios
Public Class Frm_ppal_alambron
    Dim nit_usuario As String
    Private objOpSimplesLn As New Op_simpesLn
    Dim cargaComp As Boolean = False
    Private Sub Frm_ppal_alambron_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Location.X.Equals(10)
        Me.Location.Y.Equals(10)
        habilitarCampos(False)
        cargaComp = True
    End Sub

    Private Sub habilitarCampos(ByVal estado As Boolean)
        TreeView1.Enabled = estado
    End Sub
    Private Sub txtCedula_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCedula.TextChanged
        If (cargaComp) Then
            If (Trim(txtCedula.Text).Length > 4) Then
                Dim nombre As String = objOpSimplesLn.consultarVal("SELECT nombres FROM V_nom_personal_Activo_con_maquila WHERE nit = '" & txtCedula.Text & "'")
                If (nombre <> "") Then
                    nit_usuario = txtCedula.Text
                    imgCed.Image = Spic.My.Resources.ok3
                    Me.Text = nombre
                    habilitarCampos(True)
                Else
                    imgCed.Image = Spic.My.Resources._1371750041_14125
                    Me.Text = "Digite su cédula"
                    habilitarCampos(False)
                End If
            Else
                imgCed.Image = Spic.My.Resources._1371750041_14125
                Me.Text = "Digite su cédula"
                habilitarCampos(False)
            End If

        End If
    End Sub
    Private Sub soloNumero(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If (Char.IsDigit(e.KeyChar) Or e.KeyChar = ".") Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtCedula_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCedula.KeyPress
        soloNumero(e)
    End Sub
    Private Sub txtCedula_Enter(ByVal sender As Object, ByVal e As EventArgs) Handles txtCedula.Enter
        txtCedula.BackColor = Color.Lime
    End Sub
    Private Sub txtCedula_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles txtCedula.Leave
        txtCedula.BackColor = Color.White
    End Sub
    Private Sub TreeView1_AfterSelect_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView1.AfterSelect
        Dim listColumnas As New List(Of String)
        Dim nodeName As String = TreeView1.SelectedNode.Name
        Select Case (nodeName)
            Case "nod_descarga_alambron"
                Dim frm As New Frm_lector_cod_alambron
                frm.Show()
                frm.Main(nit_usuario)
                Me.WindowState = 1
                frm.Activate()
            Case "nod_traslado_1_2"
                Dim frm As New Frm_transaciones_alambron
                frm.Show()
                frm.Main(nit_usuario, 1, 2, "08")
                Me.WindowState = 1
                frm.Activate()
            Case "nod_trasalado_2_1"
                Dim frm As New Frm_transaciones_alambron
                frm.Show()
                frm.Main(nit_usuario, 2, 1, "12")
                Me.WindowState = 1
                frm.Activate()
            Case "nod_traslado_2_11"
                Dim frm As New Frm_transaciones_materia_prima_G
                frm.Show()
                frm.Main(nit_usuario, 2, 11, "21")
                Me.WindowState = 1
                frm.Activate()
            Case "nod_traslado_11_2"
                Dim frm As New Frm_transaciones_materia_prima_G_devolver
                frm.Show()
                frm.Main(nit_usuario, 11, 2, "24")
                Me.WindowState = 1
                frm.Activate()
            Case "nod_registro_prod"
                Dim frm As New Frm_transaciones_terminado
                frm.Show()
                frm.Main(nit_usuario, "ETV3")
                Me.WindowState = 1
                frm.Activate()
            Case "nod_planilla"
                Dim frm As New Frm_planilla_separe
                frm.Show()
                frm.Main(nit_usuario)
                Me.WindowState = 1
                frm.Activate()
            Case "nod_noconforme"
                Dim frm As New frm_no_conforme_gest
                frm.MAIN(nit_usuario)
                frm.Show()
                Me.WindowState = 1
                frm.Activate()
            Case "nod_inventarios"
                Dim frm As New Galvanizado()
                frm.Show()
                frm.Main(nit_usuario)
                Me.WindowState = 1
                frm.Activate()
            Case "nod_mat_prima_punt"
                Dim frm As New Frm_transacion_mp_puntilleria
                frm.Show()
                frm.Main(nit_usuario, 2, 12, "22")
                Me.WindowState = 1
                frm.Activate()
            Case "nod_dev_punti"
                Dim frm As New frm_dev_mp_puntilleria
                frm.Show()
                frm.Main(nit_usuario, 12, 2, "14")
                frm.Activate()
                Me.WindowState = 1
            Case "nod_mat_prima_recocido"
                Dim frm As New Frm_transacion_mp_recocido
                frm.Show()
                frm.Main(nit_usuario, 2, 13, "23")
                frm.Activate()
                Me.WindowState = 1
            Case "nodo_dev_rec"
                Dim frm As New Frm_transacion_mp_recocido
                frm.Show()
                frm.Main(nit_usuario, 13, 2, "28")
                Me.WindowState = 1
                frm.Activate()
            Case "nod_mat_prima_puas"
                Dim frm As New Frm_transacion_mp_puas
                frm.Show()
                frm.Main(nit_usuario, 2, 2, "01")
                frm.Activate()
                Me.WindowState = 1
            Case "nodo_devolver_p"
                Dim frm As New Frm_transacion_mp_puas
                frm.Show()
                frm.Main(nit_usuario, 2, 2, "01")
                frm.Activate()
                Me.WindowState = 1
            Case "nod_scal_tref"
                Dim frm As New Frm_transacion_mp_tscal
                frm.Show()
                frm.Main(nit_usuario, 2, 2, "01")
                frm.Activate()
                Me.WindowState = 1
            Case "nod_scae_tref"
                Dim frm As New Frm_transacion_mp_tscae
                frm.Show()
                frm.Main(nit_usuario, 2, 2, "01")
                frm.Activate()
                Me.WindowState = 1
            Case "nod_sar_tref"
                Dim frm As New Frm_transacion_mp_tsar
                frm.Show()
                frm.Main(nit_usuario, 2, 2, "01")
                frm.Activate()
                Me.WindowState = 1
            Case "nod_savr_tref"
                Dim frm As New Frm_transacion_mp_tsav
                frm.Show()
                frm.Main(nit_usuario, 2, 2, "01")
                frm.Activate()
                Me.WindowState = 1
            Case "nod_inv_bod"
                Dim frm As New frm_control_inv()
                frm.Show()
                frm.main(nit_usuario)
                frm.Activate()
                Me.WindowState = 1
        End Select
        TreeView1.SelectedNode = TreeView1.Nodes("raiz_gestion_alambron")
    End Sub
End Class