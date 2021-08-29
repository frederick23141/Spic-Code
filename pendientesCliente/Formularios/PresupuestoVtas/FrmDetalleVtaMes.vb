Public Class FrmDetalleVtaMes

    Private Sub FrmDetalleVtaMes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Size = Screen.PrimaryScreen.WorkingArea.Size
        centrarEnPantalla()
    End Sub
    Private Sub centrarEnPantalla()
        Me.Left = (Screen.PrimaryScreen.WorkingArea.Width - Me.Width) / 2
        Me.Top = (Screen.PrimaryScreen.WorkingArea.Height - Me.Height) / 2
    End Sub
    Private Sub dtgResultVtas_CellFormatting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dtgResultVtas.CellFormatting
        Dim var As Integer = 0

        If (dtgResultVtas.RowCount Mod 2 = 1) Then
            var = 1
        End If
        If e.RowIndex Mod 2 = var Then
            e.CellStyle.BackColor = Color.Gainsboro
        End If
    End Sub
    Public Sub cargarGrid(ByVal dt As DataTable)
        dtgResultVtas.DataSource = dt
    End Sub

End Class