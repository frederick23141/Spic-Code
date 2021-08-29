Imports entidadNegocios
Imports accesoDatos
Public Class AnVrKiloLn
    Private objAnKilosAd As New AnVrkiloAd
    Public Function listarPresGeneral(ByVal mes As Integer, ByVal añoIni As Integer, ByVal añoFin As Integer) As List(Of AnVrKiloEn)
        Return objAnKilosAd.listarPresGeneral(mes, añoIni, añoFin)
    End Function
End Class
