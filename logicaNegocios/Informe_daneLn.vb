Imports accesoDatos
Public Class Informe_daneLn
    Private objInforme_daneAd As New Informe_daneAd
    Public Function listarBusqueda(ByVal ano As Integer, ByVal tipo As String) As DataView
        Return objInforme_daneAd.listarBusqueda(ano, tipo)
    End Function
    Public Function vec_varianza(ByVal ano As Integer, ByVal tipo As String, ByVal mes As Integer) As Double()
        Return objInforme_daneAd.vec_varianza(ano, tipo, mes)
    End Function
    Public Function listar_variacion(ByVal ano As Integer, ByVal tipo As String, ByVal mes As Integer) As DataView
        Return objInforme_daneAd.listar_variacion(ano, tipo, mes)
    End Function
   
End Class
