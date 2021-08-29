Imports entidadNegocios
Imports accesoDatos
Public Class AnalisisLn
    '****************************************************************************************************************
    'Se crean las instancias de las clases necesarias****************************************************************
    '****************************************************************************************************************
    Private objAnalisisAd As AnalisisAd2
    Dim objOpSimplesLn As New Op_simpesLn
    Private objpendientesAd As New pendientesAd
    Public Sub New()
        objAnalisisAd = New AnalisisAd2
    End Sub

    '**********************************
    Public Sub llamarPrincipal(ByVal min As Double, ByVal max As Double, ByVal vendedores As String)
        Dim iva As Double = objOpSimplesLn.getIvaPorc()
        objAnalisisAd.LLenarTodo(min, max, vendedores, iva)
    End Sub
    Public Function listaBloq() As List(Of AnalisisEn)
        Return objAnalisisAd.retornarBloq
    End Function
    Public Function listarDocVenc(ByVal min As Integer, ByVal max As Integer) As DataTable
        Return objAnalisisAd.listarDocVenc(min, max)
    End Function
    Public Function listaBuenos() As List(Of AnalisisEn)
        Return objAnalisisAd.retornarBueno
    End Function
    Public Function listaCupo() As List(Of AnalisisEn)
        Return objAnalisisAd.retornarCupo
    End Function
    Public Function listaCupoYdocVenc() As List(Of AnalisisEn)
        Return objAnalisisAd.retornarCupoYdocVenc
    End Function
    Public Sub autorizarPed(ByVal notas As String, ByVal numero As Integer)
        objAnalisisAd.autorizarPed(notas, numero)
    End Sub
    Public Function listar_No_Reflej(ByVal tipo As String) As DataTable
        Return objAnalisisAd.listar_No_Reflej(tipo)
    End Function
    Public Function anular_no_reflej(ByVal numero As Integer) As Integer
        Return objAnalisisAd.anular_no_reflej(numero)
    End Function
    Public Function consultarStock(ByVal codigo As String) As String
        Return objAnalisisAd.consultarStock(codigo)
    End Function
    Public Function consultarCantPend(ByVal codigo As String) As Double
        Return objAnalisisAd.consultarCantPend(codigo)
    End Function
    Public Function sum_no_reflej(ByVal vend_min As Integer, ByVal vend_max As Integer, ByVal iva As Double) As Double
        Return objAnalisisAd.sum_no_reflej(vend_min, vend_max, iva)
    End Function
    Public Function retornarCupo() As List(Of AnalisisEn)
        Return objAnalisisAd.retornarCupo()
    End Function
    Public Function listarBuenos(ByVal min As Integer, ByVal max As Integer) As List(Of AnalisisEn)()
        Dim iva As Double = objOpSimplesLn.getIvaPorc()
        Return objAnalisisAd.listarBuenos(min, max, iva)
    End Function
    Public Function listarBloq(ByVal min As Integer, ByVal max As Integer) As List(Of AnalisisEn)
        Return objAnalisisAd.listarBloq(min, max)
    End Function
    'Public Function listarDocVenc(ByVal min As Integer, ByVal max As Integer) As List(Of AnalisisEn)
    '    Return objAnalisisAd.listarDocVenc(min, max)
    'End Function
    Public Function ejecutar(ByVal sql As String) As Integer
        Return objAnalisisAd.ejecutar(Sql)
    End Function
    Public Function vr_total_pend(ByVal nit As Double, ByVal iva As Double) As Double
        Return objpendientesAd.sumValTot(nit, iva)
    End Function




End Class
