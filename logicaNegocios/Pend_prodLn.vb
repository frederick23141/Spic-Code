Imports accesoDatos
Public Class Pend_prodLn
    Private objPend_prodAd As New Pend_prodAd
    Public Function listar_id_cor() As String(,)
        Return objPend_prodAd.listar_id_cor
    End Function
    Public Function listar_tipo_idCor() As String()
        Return objPend_prodAd.listar_tipo_idCor()
    End Function
    Public Function listar_pend_prod(ByVal idcor_min, ByVal idcor_max) As DataTable
        Return objPend_prodAd.listar_pend_prod(idcor_min, idcor_max)
    End Function
    Public Function listarBusqueda(ByVal idcor_min As Integer, ByVal idcor_max As Integer, ByVal tipo As String) As DataView
        Return objPend_prodAd.listarBusqueda(idcor_min, idcor_max, tipo)
    End Function
    Public Function listarConsolidado(ByVal idcor_min As Integer, ByVal idcor_max As Integer, ByVal tipo As String) As DataTable
        Return objPend_prodAd.listarConsolidado(idcor_min, idcor_max, tipo)
    End Function
    Public Function Detalle_consol_pend_idCor() As DataTable
        Return objPend_prodAd.Detalle_consol_pend_idCor
    End Function
End Class
