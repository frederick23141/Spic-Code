Imports Microsoft.Reporting.WinForms
Imports entidadNegocios
Public Class FrmReporteProc
    Public listProcEnc As New List(Of Procedimiento_encEn)
    Public listProcDet As New List(Of Procedimiento_detEn)

    '' se listan los procesos de auditoria
    Public Sub Main(ByVal titulo As String, ByVal listProcEnc As List(Of Procedimiento_encEn), ByVal listProcDet As List(Of Procedimiento_detEn))
        Me.Text = titulo
        Me.listProcEnc = listProcEnc
        Me.listProcDet = listProcDet
    End Sub

    '' cargar los reportes 
    Private Sub FrmReportesFichas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim listObjEncEvaluacion As New List(Of EncEvaluacionEn)
        rpt.LocalReport.DataSources.Clear()
        rpt.LocalReport.DataSources.Add(New ReportDataSource("dtsProcedimientoEnc", listProcEnc))
        rpt.LocalReport.DataSources.Add(New ReportDataSource("dtsProcedimientoDet", listProcDet))
        Me.rpt.RefreshReport()
    End Sub

End Class