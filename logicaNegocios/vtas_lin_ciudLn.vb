Imports accesoDatos
Public Class vtas_lin_ciudLn
    Private obj_vtas_lin_ciudAd As New vtas_lin_ciudadAd
    Public Function listar_cbo(ByVal cadena As String) As DataTable
        Return obj_vtas_lin_ciudAd.listar_cbo(cadena)
    End Function
    Public Function listar_vtas_lin_ciud(ByVal sql As String) As DataTable
        Return obj_vtas_lin_ciudAd.listar_vtas_lin_ciud(sql)
    End Function
    Public Function listar_id_cor() As String(,)
        Return obj_vtas_lin_ciudAd.listar_id_cor()
    End Function
    Public Function listar_dptos() As String(,)
        Return obj_vtas_lin_ciudAd.listar_dptos
    End Function
    Public Function listar_ciudad(ByVal dpto As String) As String(,)
        Return obj_vtas_lin_ciudAd.listar_ciudad(dpto)
    End Function
End Class
