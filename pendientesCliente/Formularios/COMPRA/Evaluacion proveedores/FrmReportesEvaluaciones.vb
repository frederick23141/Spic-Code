Imports Microsoft.Reporting.WinForms
Imports entidadNegocios
Public Class FrmReportesEvaluaciones
    Public listCriteriosEvaluacionEn As New List(Of CriteriosEvaluacionEn)
    Public listClas_provEn As New List(Of Clas_provEn)
    Public objEncEvaluacion As New EncEvaluacionEn
    Public Sub Main(ByVal titulo As String, ByVal listCriteriosEvaluacionEn As List(Of CriteriosEvaluacionEn), ByVal listClas_provEn As List(Of Clas_provEn), ByVal objEncEvaluacion As EncEvaluacionEn)
        Me.Text = titulo
        Me.listClas_provEn = listClas_provEn
        Me.listCriteriosEvaluacionEn = listCriteriosEvaluacionEn
        Me.objEncEvaluacion = objEncEvaluacion
    End Sub

    Private Sub FrmReportesFichas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim listObjEncEvaluacion As New List(Of EncEvaluacionEn)
        listObjEncEvaluacion.add(objEncEvaluacion)
        rpt.LocalReport.DataSources.Clear()
        rpt.LocalReport.DataSources.Add(New ReportDataSource("DTceriteriosEvaluacion", listCriteriosEvaluacionEn))
        rpt.LocalReport.DataSources.Add(New ReportDataSource("DTclasProv", listClas_provEn))
        rpt.LocalReport.DataSources.Add(New ReportDataSource("DTEncEv", listObjEncEvaluacion))
        Me.rpt.RefreshReport()
    End Sub

    Private Sub rpt_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rpt.Load

    End Sub
End Class