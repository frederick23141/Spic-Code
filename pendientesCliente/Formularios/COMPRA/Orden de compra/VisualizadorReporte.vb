Public Class VisualizadorReporte
    Dim num As Integer
    Dim num2 As Integer
    Private Sub VisualizadorReporte_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'PRGPRODUCCIONDataSet.d_filtrar_reporte_solicitud' Puede moverla o quitarla según sea necesario.
        Me.d_filtrar_reporte_solicitudTableAdapter.Fill(Me.PRGPRODUCCIONDataSet.d_filtrar_reporte_solicitud, num, num2)
        Me.ReportViewer1.RefreshReport()
    End Sub

    'Estos dos metodos reciben el numero de la solicitud y el numero de servicios solicitados
    Public Sub guardar_numero(ByVal numero As Integer, ByVal num_d As Integer)
        num = numero
        num2 = num_d
    End Sub
End Class