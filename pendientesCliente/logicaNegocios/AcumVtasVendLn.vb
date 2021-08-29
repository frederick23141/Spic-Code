Imports entidadNegocios
Imports accesoDatos
Public Class AcumVtasVendLn
    Private objAcumVtasVendAd As acumVtasVendAd
    Public Sub New()
        objAcumVtasVendAd = New acumVtasVendAd
    End Sub
    Public Function listarAcumVtasVend(ByVal min As Double, ByVal max As Double, ByVal mesIni As Double, ByVal añoIni As Double, ByVal mesFin As Double, ByVal añoFin As Double, ByVal criterio As String) As List(Of AcumVtasVendEn)
        Return objAcumVtasVendAd.listarAcumVtasVend(min, max, mesIni, añoIni, mesFin, añoFin, criterio)
    End Function
   
End Class
