Imports logicaNegocios
Imports System.Windows.Forms.DataVisualization.Charting
Public Class FrmGraficoVrKilo


    ''cargamos la matriz con las columnas identificadas
    Public Sub main(ByVal mat(,) As Object, ByVal nombCol As String)
        graficar(mat, nombCol)
    End Sub

    '' graficamos con las funciones de vb.net empleadas del chart1
    Private Sub graficar(ByVal mat(,) As Object, ByVal nombCol As String)
        Chart1.Visible = True
        Chart1.Titles.Clear()
        Chart1.Series.Clear()
        Chart1.ChartAreas.Clear()
        Chart1.ChartAreas.Add(0)
        Chart1.Series.Add(nombCol)
        For i = 0 To (mat.Length / 2) - 1
            If Not (mat(i, 1) Is Nothing) Then
                Chart1.Series(nombCol).Points.AddXY(mat(i, 1), Convert.ToDouble(mat(i, 0)).ToString("N1"))
            End If
        Next
        Chart1.Series(nombCol).ChartType = DataVisualization.Charting.SeriesChartType.Line
        Chart1.ChartAreas(0).AxisX.Title = "Meses"
        Chart1.ChartAreas(0).AxisY.Title = nombCol
        Chart1.Refresh()
    End Sub
   
End Class