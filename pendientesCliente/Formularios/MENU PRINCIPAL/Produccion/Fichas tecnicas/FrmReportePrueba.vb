Imports Microsoft.Reporting.WinForms
Imports entidadNegocios


Public Class FrmReportePrueba
    '
    'Cree dos listas una para el Encabezado y otra para el detalle
    '
    Public listOdenProdLn As New List(Of OrdenProdEn)()

    '
    'Cree las propiedades publicas Titulo y Empresa
    '
    Dim Titulo As String = "prueba de titulo"
    Dim numero As String = "123"


    Private Sub FrmReportePrueba_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim parameters As ReportParameter() = New ReportParameter(1) {}
        parameters(0) = New ReportParameter("parPrueba", Titulo)
        parameters(1) = New ReportParameter("parNumero", numero)

        'Limpiemos el DataSource del informe
        rpt2.LocalReport.DataSources.Clear()
        '
        'Establezcamos los parametros que enviaremos al reporte
        'recuerde que son dos para el titulo del reporte y para el nombre de la empresa

        '
        'Establezcamos la lista como Datasource del informe
        '
        rpt2.LocalReport.DataSources.Add(New ReportDataSource("objOrdenProdEn", listOdenProdLn))

        '
        'Enviemos la lista de parametros
        rpt2.LocalReport.SetParameters(parameters)
        '
        'Hagamos un refresh al reportViewer
        '
        rpt2.RefreshReport()
    End Sub
End Class
