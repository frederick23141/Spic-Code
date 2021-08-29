Imports entidadNegocios
Imports accesoDatos
Public Class AnalisisLn
    '****************************************************************************************************************
    'Se crean las instancias de las clases necesarias****************************************************************
    '****************************************************************************************************************
    Private objAnalisis2Ad As AnalisisAd2
    Public Sub New()
        objAnalisis2Ad = New AnalisisAd2
    End Sub

    '**********************************
    Public Sub llamarPrincipal(ByVal min As Double, ByVal max As Double)
        objAnalisis2Ad.LLenarTodo(min, max)
    End Sub
    Public Function listaBloq() As List(Of AnalisisEn)
        Return objAnalisis2Ad.retornarBloq
    End Function
    Public Function listaVenc() As List(Of AnalisisEn)
        Return objAnalisis2Ad.retornarVenc
    End Function
    Public Function listaBuenos() As List(Of AnalisisEn)
        Return objAnalisis2Ad.retornarBueno
    End Function
    Public Function listaCupo() As List(Of AnalisisEn)
        Return objAnalisis2Ad.retornarCupo
    End Function
    Public Function listaCupoYdocVenc() As List(Of AnalisisEn)
        Return objAnalisis2Ad.retornarCupoYdocVenc
    End Function
    Public Sub autorizarPed(ByVal notas As String, ByVal numero As Integer)
        objAnalisis2Ad.autorizarPed(notas, numero)
    End Sub
    Public Function listar_No_Reflej() As DataTable
        Return objAnalisis2Ad.listar_No_Reflej()
    End Function
    Public Function anular_no_reflej(ByVal numero As Integer) As Integer
        Return objAnalisis2Ad.anular_no_reflej(numero)
    End Function

    '**********************Pruebas
    'Public Function listarBloqIdiv(ByVal min As Integer, ByVal max As Integer) As List(Of AnalisisEn)
    '    Return objAnalisis2Ad.listarBloq(min, max)
    'End Function
    'Public Function listarBuenosIndiv(ByVal min As Integer, ByVal max As Integer, ByVal criterio As String) As List(Of AnalisisEn)
    '    Return objAnalisis2Ad.listarBuenos(min, max)
    'End Function
    'Public Function listarDocVendIndiv(ByVal min As Integer, ByVal max As Integer) As List(Of AnalisisEn)
    '    Return objAnalisis2Ad.listarDocVenc(min, max)
    'End Function
    'Public Function listarCupoIndiv(ByVal min As Integer, ByVal max As Integer, ByVal criterio As String) As List(Of AnalisisEn)
    '    Return objAnalisis2Ad.listarBuenos(min, max, criterio)
    'End Function
   



End Class
