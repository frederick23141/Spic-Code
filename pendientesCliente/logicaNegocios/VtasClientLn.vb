Imports entidadNegocios
Imports accesoDatos
Public Class VtasClientLn
    '****************************************************************************************************************
    'Se crean las instancias de las clases necesarias****************************************************************
    '****************************************************************************************************************
    Private objClienteAd As VtasClientAd

    Public Sub New()
        objClienteAd = New VtasClientAd


    End Sub
    '****************************************************************************************************************
    'Se hace el enlace de el formulario con los objetos de acceso a datos aca se llaman los diferentes prodecimientos
    'se le mandan los parametos y se retorna el resultadp a los diferentes formularios*******************************
    '****************************************************************************************************************

    'Funciones que invocan a la clase  ClienteAd
    Public Function listarClienProd(ByVal min As Double, ByVal max As Double, ByVal mesIni As Double, ByVal añoIni As Double, ByVal mesFin As Double, ByVal añoFin As Double, ByVal codigoMin As String, ByVal codigoMax As String) As List(Of VtasClientEn)
        Return objClienteAd.listarClienProd(min, max, mesIni, añoIni, mesFin, añoFin, codigoMin, codigoMax)
    End Function




End Class


