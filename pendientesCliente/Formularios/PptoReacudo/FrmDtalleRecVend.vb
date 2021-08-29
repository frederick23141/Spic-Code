Public Class FrmDtalleRecVend

    Private Sub FrmDtalleVend_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CenterToScreen()
    End Sub
    Private Sub dtgDtalleVend_CellFormatting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dtgDtalleVend.CellFormatting
        Dim var As Integer = 0

        If (dtgDtalleVend.RowCount Mod 2 = 1) Then
            var = 1
        End If
        If e.RowIndex Mod 2 = var Then
            e.CellStyle.BackColor = Color.Gainsboro
        End If
    End Sub

  
End Class