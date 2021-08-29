Imports System.Windows.Forms.DataVisualization.Charting
Public Class FrmElimPresRec

    Private Sub FrmElimPresRec_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim año As Double = Now.Year
        For i = 0 To 2
            cboAño.Items.Add(año - 1)
            año += 1
        Next
        cboMes.SelectedIndex = Now.Month - 1
        cboAño.SelectedIndex = 1
        Me.CenterToScreen()
    End Sub


    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        Dim año As Integer = cboAño.Text
        Dim mes As Integer = cboMes.SelectedIndex + 1
        If (MessageBox.Show("Seguro de eliminar el presupuesto para " & año & "-" & mes & " ?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) = 6 Then
            FrmPpto_recaudo.eliminarPpto(año, mes)
            Me.Close()
        End If
    End Sub

End Class