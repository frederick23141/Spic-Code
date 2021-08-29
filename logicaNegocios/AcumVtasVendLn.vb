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
    Public Function listar_consulta(ByVal min As Double, ByVal max As Double, ByVal mesIni As Double, ByVal añoIni As Double, ByVal mesFin As Double, ByVal añoFin As Double, ByVal criterio As String, ByVal vendedores As String, ByVal vend_hoy As Boolean) As DataTable
        Return objAcumVtasVendAd.listar_consulta(min, max, mesIni, añoIni, mesFin, añoFin, criterio, vendedores, vend_hoy)
    End Function
    Public Function listar_detalle(ByVal sql As String) As DataTable
        Return objAcumVtasVendAd.listar_detalle(sql)
    End Function
   
End Class
