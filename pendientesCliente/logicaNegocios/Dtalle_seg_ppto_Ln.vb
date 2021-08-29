Imports entidadNegocios
Imports accesoDatos
Public Class Dtalle_seg_ppto_Ln
    Private obj_Dtalle_seg_ppto_Ad As New Dtalle_seg_ppto_ad
    Public Function listarBusqueda(ByVal min As Integer, ByVal max As Integer, ByVal fec_ini As String, ByVal fec_max As String, ByVal criterio As String) As DataTable
        Return obj_Dtalle_seg_ppto_Ad.listarBusqueda(min, max, fec_ini, fec_max, criterio)
    End Function
    Public Function listar_vendedores() As List(Of Integer)
        Return obj_Dtalle_seg_ppto_Ad.listar_vendedores()
    End Function
End Class
