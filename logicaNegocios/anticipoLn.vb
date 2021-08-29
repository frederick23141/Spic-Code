Imports accesoDatos
Imports entidadNegocios
Public Class anticipoLn
    Private obj_anticipoAd As New anticipoAd
    Public Function listar_anticipo(ByVal fecIni As String, ByVal fecFin As String, ByVal vendmin As Integer, ByVal vendMax As Integer, ByVal condicion As String) As DataTable
        Return obj_anticipoAd.listar_anticipo(fecIni, fecFin, vendmin, vendMax, condicion)
    End Function
    Public Function listar_anticipo_nomb(ByVal vendmin As Integer, ByVal vendMax As Integer, ByVal nombre As String, ByVal condicion As String) As DataTable
        Return obj_anticipoAd.listar_anticipo_nomb(vendmin, vendMax, nombre, condicion)
    End Function
    Public Function listar_anticipo_nit(ByVal vendmin As Integer, ByVal vendMax As Integer, ByVal nit As Double, ByVal condicion As String) As DataTable
        Return obj_anticipoAd.listar_anticipo_nit(vendmin, vendMax, nit, condicion)
    End Function
    Public Function consolidar_anticipo(ByVal fecIni As String, ByVal fecFin As String, ByVal vendmin As Integer, ByVal vendMax As Integer, ByVal condicion As String) As DataTable
        Return (obj_anticipoAd.consolidar_anticipo(fecIni, fecFin, vendmin, vendMax, condicion))
    End Function
End Class
