Imports accesoDatos

Public Class Vtas_clien_idCorLn

    Private obj_Vtas_clien_idCorAd As New Vtas_clien_idCorAd
    Public Function listar_consulta(ByVal nit As Double, ByVal ano_ini As Integer, ByVal ano_Fin As Integer, ByVal vendedores As String, ByVal vend_hoy As Boolean) As DataTable
        Return obj_Vtas_clien_idCorAd.listar_consulta(nit, ano_ini, ano_Fin, vendedores, vend_hoy)
    End Function
    Public Function listar_detalle(ByVal ano As Integer, ByVal nit As Double, ByVal id_cor As Integer) As DataTable
        Return obj_Vtas_clien_idCorAd.listar_detalle(ano, nit, id_cor)
    End Function
    Public Function cargar_table(ByVal sql As String) As DataTable
        Return obj_Vtas_clien_idCorAd.cargar_table(sql)
    End Function

End Class
