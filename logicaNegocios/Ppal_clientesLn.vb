Imports accesoDatos
Public Class Ppal_clientesLn
    Private obj_ppal_clienteAd As New Ppal_clientAd
    Public Function listar_datatable(ByVal cadena As String) As DataTable
        Return obj_ppal_clienteAd.listar_datatable(cadena)
    End Function
End Class



