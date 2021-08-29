Imports accesoDatos
Public Class vtas_cliente_linea_mesLn
    Private obj_vtas_cliente_linea_mesAd As New vtas_cliente_linea_mesAd


    Public Function list_analisos_vrKilo_meses(ByVal mes_ini As Integer, ByVal ano_ini As Integer, ByVal mes_fin As Integer, ByVal ano_fin As Integer, ByVal nit As Double, ByVal whereVendedor As String) As DataTable
        Return obj_vtas_cliente_linea_mesAd.list_analisos_vrKilo_meses(mes_ini, ano_ini, mes_fin, ano_fin, nit, whereVendedor)
    End Function
End Class
