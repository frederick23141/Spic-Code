Imports logicaNegocios
Public Class Frm_prog_prod
    Private Sub Frm_prog_prod_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim año = Now.Year
        While (2000 <= año)
            cbo_ano.Items.Add(año)
            año -= 1
        End While
    End Sub
End Class