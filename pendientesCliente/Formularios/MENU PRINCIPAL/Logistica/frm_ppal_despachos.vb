Imports logicaNegocios
Imports entidadNegocios
Public Class frm_ppal_despachos
    Dim nit_usuario As String
    Private objOpSimplesLn As New Op_simpesLn
    Dim cargaComp As Boolean = False
    Private Sub frm_ppal_despachos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Location.X.Equals(10)
        Me.Location.Y.Equals(10)
        habilitarCampos(False)
        cargaComp = True
    End Sub
    Private Sub tw_despachos_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles tw_despachos.AfterSelect
        Dim listColumnas As New List(Of String)
        Dim nodeName As String = tw_despachos.SelectedNode.Name
        Select Case (nodeName)
            Case "nod_traslado_2_3"
                Dim frm As New frm_Trb_2_3_desp
                frm.Main(nit_usuario, 2, 3, "11")
                frm.Show()
                Me.WindowState = 1
                frm.Activate()
            Case "nod_traslado_2_3_P"
                Dim frm As New frm_traslado_puas_2_3
                frm.Main(nit_usuario, 2, 3, "11")
                frm.Show()
                Me.WindowState = 1
                frm.Activate()
        End Select
    End Sub
    Private Sub txtCedula_TextChanged(sender As Object, e As EventArgs) Handles txtCedula.TextChanged
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
    Private Sub habilitarCampos(ByVal estado As Boolean)
        tw_despachos.Enabled = estado
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

End Class