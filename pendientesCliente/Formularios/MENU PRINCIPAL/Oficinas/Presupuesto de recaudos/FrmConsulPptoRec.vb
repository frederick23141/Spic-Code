Public Class FrmConsulPptoRec
   
    Private Sub FrmConsulPptoRec_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim año As Double = Now.Year
        For i = 0 To 2
            cboAño.Items.Add(año - 1)
            año += 1
        Next
        cboMes.SelectedIndex = Now.Month - 1
        cboAño.SelectedIndex = 1
        Me.CenterToScreen()
    End Sub
    Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
        FrmPpto_recaudo.Show()
        FrmPpto_recaudo.consultarPpto(cboAño.Text, cboMes.SelectedIndex + 1)
        Me.Close()
    End Sub
End Class