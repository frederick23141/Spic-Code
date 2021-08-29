Imports entidadNegocios
Imports accesoDatos
Public Class SegVendLn
    Private objSegVendAd As SegVendAd

    Public Sub New()
        objSegVendAd = New SegVendAd
    End Sub

    Public Function listarNuev(ByVal mes As Integer, ByVal año As Integer, ByVal criterio As String) As List(Of SegVendEn)
        Return objSegVendAd.listarNuev(mes, año, criterio)
    End Function
    Public Function DetalleVentasVend(ByVal mes As Integer, ByVal año As Integer, ByVal min As Integer, ByVal max As Integer) As DataTable
        Return objSegVendAd.DetalleVentasVend(mes, año, min, max)
    End Function
    Public Function DetaPptoVtas(ByVal mes As Integer, ByVal año As Integer, ByVal min As Integer, ByVal max As Integer) As DataTable
        Return objSegVendAd.DetaPptoVtas(mes, año, min, max)
    End Function
    Public Function DetalleRec(ByVal mes As Integer, ByVal año As Integer, ByVal min As Integer, ByVal max As Integer) As DataTable
        Return objSegVendAd.DetalleRec(mes, año, min, max)
    End Function
    Public Function DetallePptoRec(ByVal mes As Integer, ByVal año As Integer, ByVal min As Integer, ByVal max As Integer) As DataTable
        Return objSegVendAd.DetallePptoRec(mes, año, min, max)
    End Function
    Public Function DetallePend(ByVal mes As Integer, ByVal año As Integer, ByVal min As Integer, ByVal max As Integer) As DataTable
        Return objSegVendAd.DetallePend(mes, año, min, max)
    End Function
    Public Function DetalleDev(ByVal mes As Integer, ByVal año As Integer, ByVal min As Integer, ByVal max As Integer) As DataTable
        Return objSegVendAd.DetalleDev(mes, año, min, max)
    End Function
    Public Function listarIndividual(ByVal mes As Integer, ByVal año As Integer, ByVal vendedor As Integer, ByVal criterio As String) As List(Of SegVendEn)
        Return objSegVendAd.listarIndividual(mes, año, vendedor, criterio)
    End Function
    Public Function tot_vtas(ByVal mes As Integer, ByVal año As Integer, ByVal min As Integer, ByVal max As Integer) As Double
        Return objSegVendAd.tot_vtas(mes, año, min, max)
    End Function
    Public Function total_ptes(ByVal min As Integer, ByVal max As Integer) As Double
        Return objSegVendAd.total_ptes(min, max)
    End Function
End Class
