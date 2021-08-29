Imports accesoDatos
Imports entidadNegocios
Public Class EstClienVendLn

    Private objEstaClienVendAd As EstClienVendAd
    Private objEstaClienVeAd As EstClienVendAd

    Public Sub New()
        objEstaClienVendAd = New EstClienVendAd
    End Sub

    Public Function listarEstClient(ByVal vendedores As String) As List(Of EstClienVendEn)
        Return objEstaClienVendAd.listarEstClient(vendedores)
    End Function
    Public Function listarClientesCategoria(ByVal cadena As String) As DataTable
        Return objEstaClienVendAd.listarClientesCategoria(cadena)
    End Function
    Public Function listarMovTotales(ByVal cadena As String) As DataTable
        Return objEstaClienVendAd.listarMovTotales(cadena)
    End Function
    Public Function listarAtendFecFin(ByVal vendedor As Integer) As DataTable
        Return objEstaClienVendAd.listarAtendFecFin(vendedor)
    End Function
    Public Function listarAtendFecIni(ByVal vendedor As Integer) As DataTable
        Return objEstaClienVendAd.listarAtenFecIni(vendedor)
    End Function
    Public Function listarNuevosFecini(ByVal vendedor As Integer) As DataTable
        Return objEstaClienVendAd.listarNuevosFecIni(vendedor)
    End Function
    Public Function listarNuevosFecFin(ByVal vendedor As Integer) As DataTable
        Return objEstaClienVendAd.listarNuevosFecFin(vendedor)
    End Function
    Public Function listar_traz(ByVal nit As Double, ByVal criterio As String, ByVal fec_ini As Date, ByVal fec_fin As Date) As DataTable
        Return objEstaClienVendAd.listar_traz(nit, criterio, fec_ini, fec_fin)
    End Function
 
End Class
