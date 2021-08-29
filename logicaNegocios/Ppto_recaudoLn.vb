Imports entidadNegocios
Imports accesoDatos
Public Class Ppto_recaudoLn
    Private objPpto_recaudoAd As Ppto_recaudoAd

    Public Sub New()
        objPpto_recaudoAd = New Ppto_recaudoAd
    End Sub
    Public Function listarPptoRec(ByVal fechaRec As String) As List(Of Ppto_recaudoEn)
        Return objPpto_recaudoAd.listarPptoRec(fechaRec)
    End Function
    Public Function listaDtalleVend(ByVal vendedor As Integer) As DataTable
        Return objPpto_recaudoAd.listaDtalleVend(vendedor)
    End Function
    Public Function listarDtallePpto() As List(Of DtallePptoRecEn)
        Return objPpto_recaudoAd.listarDtallePpto()
    End Function
    Public Sub insertarPres(ByVal fechaPres As Date, ByVal vendedor As Double, ByVal nombre As String, ByVal ppto_rec As Double, ByVal ppto_clien_cont As Double, ByVal pptoTot As Double, ByVal totClienCont As Integer)
        objPpto_recaudoAd.insertarPres(fechaPres, vendedor, nombre, ppto_rec, ppto_clien_cont, pptoTot, totClienCont)
    End Sub
    Public Function listarConsulta(ByVal año As Integer, ByVal mes As Integer) As List(Of Ppto_recaudoEn)
        Return objPpto_recaudoAd.listarConsulta(año, mes)
    End Function
    Public Sub eliminarPres(ByVal año As Integer, ByVal mes As Integer)
        objPpto_recaudoAd.eliminarPres(año, mes)
    End Sub
    Public Function existePresRec(ByVal año As Integer, ByVal mes As Integer) As Boolean
        Return objPpto_recaudoAd.existePresRec(año, mes)
    End Function
End Class