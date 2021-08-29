Public Class frmPrincipal_autocierre
    Dim tiempo As Integer = 0
    Public Sub main()
        tiempo = 20
        Label2.Text = 20
        Timer1.Enabled = True
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        tiempo = tiempo - 1
        Label2.Text = tiempo
        If tiempo = 0 Then
            FrmPrincipal.fin()
        End If
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        FrmPrincipal.reiniciar_timer(120)
        Timer1.Enabled = False
        Me.Close()
    End Sub
End Class