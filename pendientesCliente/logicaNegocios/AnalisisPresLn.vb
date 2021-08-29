Imports entidadNegocios
Imports accesoDatos

Public Class AnalisisPresLn
    '****************************************************************************************************************
    'Se crean las instancias de las clases necesarias****************************************************************
    '****************************************************************************************************************
    Private objAnalisisPResAd As AnalisisPresAd

    Public Sub New()
        objAnalisisPResAd = New AnalisisPresAd
    End Sub

    Public Function listarAnalisisPres(ByVal min As Double, ByVal max As Double, ByVal criterio As String) As List(Of AnalisisPresEn)
        Return objAnalisisPResAd.listarAnalisisPres2(min, max, criterio)
    End Function
    Public Function cargarVendedores() As String()
        Return objAnalisisPResAd.cargarVendedores()
    End Function
    Public Function cargarConsultaVtasMes(ByVal vendedorMin As Integer, ByVal vendedorMax As Integer, ByVal mes As Integer, ByVal año As Integer, ByVal id_cor As Integer) As DataTable
        Return objAnalisisPResAd.cargarConsultaVtasMes(vendedorMin, vendedorMax, mes, año, id_cor)
    End Function
End Class
