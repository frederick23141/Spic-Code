Imports Microsoft.Reporting.WinForms
Imports entidadNegocios
Public Class FrmReportesFichas
    Public listDetRollos As New List(Of DetalleRollosEn)
    Public listDetRollos2 As New List(Of DetalleRollosEn)
    Public listFichaAlamb As New List(Of FichaAlambEn)
    Public listCalidadAlambron As New List(Of Calidad_alambronEn)
    Public Sub Main(ByVal titulo As String, ByVal objFichaAlambEn As FichaAlambEn, ByVal listDetRollos As List(Of DetalleRollosEn), ByVal listDetRollos2 As List(Of DetalleRollosEn), ByVal obj_calidad_alambron As Calidad_alambronEn)
        Me.Text = titulo
        Me.listFichaAlamb.Add(objFichaAlambEn)
        Me.listDetRollos = listDetRollos
        Me.listDetRollos2 = listDetRollos2
        Me.listCalidadAlambron.Add(obj_calidad_alambron)
    End Sub

    Private Sub FrmReportesFichas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        rpt.LocalReport.DataSources.Clear()
        rpt.LocalReport.DataSources.Add(New ReportDataSource("EncFichaAlamb", listFichaAlamb))
        rpt.LocalReport.DataSources.Add(New ReportDataSource("DetRollos", listDetRollos))
        rpt.LocalReport.DataSources.Add(New ReportDataSource("DetRollos2", listDetRollos2))
        rpt.LocalReport.DataSources.Add(New ReportDataSource("Calidad_alambron", listCalidadAlambron))
        Me.rpt.RefreshReport()
    End Sub

End Class