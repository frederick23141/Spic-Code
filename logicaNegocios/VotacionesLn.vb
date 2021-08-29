Imports accesoDatos
Public Class VotacionesLn
    Private objVotacionesAd As New VotacionesAd

    Public Function formatearVotaciones() As Boolean
        Return objVotacionesAd.formatearVotaciones()
    End Function

    Public Function listar_datatable(ByVal cadena As String) As DataTable
        Return objVotacionesAd.listar_datatable(cadena)
    End Function
    Public Function cargarInfoBasica(ByVal nit As Double) As Object
        Return objVotacionesAd.cargarInfoBasica(nit)
    End Function
    Public Function sumarPuntos(ByVal puntos As Integer, ByVal nit As Double) As Integer
        Return objVotacionesAd.sumarPuntos(puntos, nit)
    End Function
    Public Function verificarVotante(ByVal nit As Double) As Integer
        Return objVotacionesAd.verificarVotante(nit)
    End Function
    Public Function marcarVotante(ByVal nit As Double) As Integer
        Return objVotacionesAd.marcarVotante(nit)
    End Function
    Public Function ejecutar(ByVal sql As String) As Integer
        Return objVotacionesAd.ejecutar(sql)
    End Function

End Class
