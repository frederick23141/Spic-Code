Imports Microsoft.Reporting.WinForms
Imports entidadNegocios

Public Class Frm_rpt_fact

    Public listDet As New List(Of FacturaDetEn)
    Public listEnc As New List(Of FacturaEncEn)
    Public Sub Main(ByVal titulo As String, ByVal objFacturaEncEn As FacturaEncEn, ByVal listDet As List(Of FacturaDetEn))
        Me.Text = titulo
        Me.listDet = listDet
        Me.listEnc.Add(objFacturaEncEn)
    End Sub

    Private Sub Frm_rpt_fact_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        rpt.LocalReport.DataSources.Clear()
        rpt.LocalReport.DataSources.Add(New ReportDataSource("dts_ts_detalle", listDet))
        rpt.LocalReport.DataSources.Add(New ReportDataSource("dts_fact_enc", listEnc))
        Me.rpt.RefreshReport()
    End Sub
End Class