Imports entidadNegocios
Imports accesoDatos
Public Class Gestion_ped_Ln
    Private obj_Gestion_ped_Ad As New Gestion_ped_Ad
    Public Function listar_ped() As DataTable
        Return obj_Gestion_ped_Ad.listar_ped()
    End Function
    Public Function anular_ped(ByVal numero As Integer) As Integer
        Return obj_Gestion_ped_Ad.anular_ped(numero)
    End Function
End Class
