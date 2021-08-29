Imports entidadNegocios
Imports accesoDatos
Public Class AnVrKiloLn
    Private objAnKilosAd As New AnVrkiloAd
    Public Function listarPresGeneral(ByVal mes As Integer, ByVal añoIni As Integer, ByVal añoFin As Integer) As List(Of AnVrKiloEn)
        Return objAnKilosAd.listarPresGeneral(mes, añoIni, añoFin)
    End Function
    Public Function detalle_analisis_vrkilo(ByVal mes_ini As Integer, ByVal ano_ini As Integer, ByVal mes_fin As Integer, ByVal ano_fin As Integer) As DataTable
        Return objAnKilosAd.detalle_analisis_vrkilo(mes_ini, ano_ini, mes_fin, ano_fin)
    End Function
    Public Function list_analisos_vrKilo_meses(ByVal mes_ini As Integer, ByVal ano_ini As Integer, ByVal mes_fin As Integer, ByVal ano_fin As Integer) As DataTable
        Return objAnKilosAd.list_analisos_vrKilo_meses(mes_ini, ano_ini, mes_fin, ano_fin)
    End Function
End Class
