Imports entidadNegocios
Imports accesoDatos
Public Class Dtalle_seg_ppto_Ln
    Private obj_Dtalle_seg_ppto_Ad As New Dtalle_seg_ppto_ad
    Public Function listarBusqueda(ByVal min As Integer, ByVal max As Integer, ByVal fec_ini As String, ByVal fec_max As String, ByVal criterio As String, ByVal vendedores As String, ByVal grupo As Boolean, ByVal linea As Boolean) As DataTable
        Return obj_Dtalle_seg_ppto_Ad.listarBusqueda(min, max, fec_ini, fec_max, criterio, vendedores, grupo, linea)
    End Function
    Public Function listar_vendedores(ByVal vendedores As String) As List(Of Integer)
        Return obj_Dtalle_seg_ppto_Ad.listar_vendedores(vendedores)
    End Function
End Class
