Imports logicaNegocios
Public Class FrmPrioridadEmp
    Private objOpSimplesLn As New Op_simpesLn
    Private Sub btnAct_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAct.Click
        actConsulta()
    End Sub
    Private Sub actConsulta()
        Dim sql As String = "SELECT t.codigo,t.descripcion,t.inv_inic,t.Entrada,t.Salida,t.stock,t.pendiente,t.prioridad " & _
                                  "FROM jjv_ptes_tambores1 t " & _
                                        "WHERE(pendiente Is Not null) " & _
                                   "ORDER BY t.prioridad DESC "
        dtg_consulta.DataSource = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        txt_ult_act.Text = "ÚLTIMA ACTUALIZACIÓN: " & Now
        For i = 0 To dtg_consulta.Columns.Count - 1
            dtg_consulta.Columns(i).SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Next
    End Sub

    Private Sub timAct_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timAct.Tick
        actConsulta()
    End Sub

    Private Sub FrmPrioridadEmp_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        actConsulta()
    End Sub
End Class