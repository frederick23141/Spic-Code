Imports logicaNegocios
Imports entidadNegocios
Public Class Frm_bobinas_paradas
    Dim objIngresoProdLn As New Ing_prodLn
    Private Sub Frm_bobinas_paradasvb_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_consultas()
    End Sub
    Public Sub cargar_consultas()
        Dim dt As New DataTable
        Dim sql As String = ""
        sql = " SELECT Fecha,Motor,Eact FROM Jjv_plc_estados"
        dt = objIngresoProdLn.listar_datatable(sql, "CORSAN")
        Dgvbobina.DataSource = dt

        For Each row In Dgvbobina.Rows
            row.DefaultCellStyle.BackColor = Color.Red
        Next
    End Sub
End Class