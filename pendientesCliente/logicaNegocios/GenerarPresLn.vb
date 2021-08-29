Imports accesoDatos
Imports entidadNegocios
Public Class GenerarPresLn
    '****************************************************************************************************************
    'Se crean las instancias de las clases necesarias****************************************************************
    '****************************************************************************************************************
    Private objGenPresAd As GenerarPresAd

    Public Sub New()
        objGenPresAd = New GenerarPresAd
    End Sub

    Public Function listarGenerarPres(ByVal nit As Double, ByVal criterio As String) As List(Of GenerarPresEn)
        Return objGenPresAd.listarGenpres(nit, criterio)
    End Function
    Public Function cargarVendedores() As DataTable
        Return objGenPresAd.cargarVendedores()
    End Function
    Public Sub insertarPres(ByVal fechaPres As String, ByVal nit As Double, ByVal id_cor As Double, ByVal ppto_kilos As Double, ByVal vr_tot As Double, ByVal vr_kilo As Double, ByVal cto_kilo As Double, ByVal porc_util As Double, ByVal dias_habil As Double, ByVal cto_tot As Double)
        objGenPresAd.insertarPres(fechaPres, nit, id_cor, ppto_kilos, vr_tot, vr_kilo, cto_kilo, porc_util, dias_habil, cto_tot)
    End Sub
    Public Function consulPttoTodos(ByVal fecha As String) As Object
        Return objGenPresAd.consulPttoTodos(fecha)
    End Function
    Public Function consultarPres(ByVal fecha As String, ByVal vendedor As Integer) As Object
        Return objGenPresAd.consultarPres(fecha, vendedor)
    End Function
    Public Function consultStock() As Double()
        Return objGenPresAd.consultStock()
    End Function
    Public Function existePres(ByVal fecha As String, ByVal vendedor As Integer) As Boolean
        Return objGenPresAd.existePres(fecha, vendedor)
    End Function
    Public Sub eliminarPres(ByVal fecha As String, ByVal vendedor As Integer)
        objGenPresAd.eliminarPres(fecha, vendedor)
    End Sub
    Public Function consultDiasHabil(ByVal año As Integer, ByVal mes As Integer) As Integer
        Return objGenPresAd.consultDiasHabil(año, mes)
    End Function
    Public Function nombreVendedor(ByVal vendedor As Integer) As String
        Return objGenPresAd.nombreVendedor(vendedor)
    End Function
    Public Function listarGenerarPresTodos(ByVal min As Double, ByVal max As Double, ByVal criterio As String) As List(Of GenerarPresEn)
        Return objGenPresAd.listarGenpresTodos(min, max, criterio)
    End Function
    Public Function promPresTodos(ByVal vendMin As Integer, ByVal vendMax As Integer, ByVal criterio As String, ByVal cantidadMeses As Double) As Double()
        Return objGenPresAd.promPresTodos(vendMin, vendMax, criterio, cantidadMeses)
    End Function

    Public Sub GenerarPresupuestoTodos(ByVal vendMin As Integer, ByVal vendMax As Integer, ByVal fecha As String, ByVal cantidadMeses As Double)
        objGenPresAd.GenerarPresupuestoTodos(vendMin, vendMax, fecha, cantidadMeses)

    End Sub
    Public Function valTotTodosIdCor(ByVal cantidadMeses As Double) As Double()
        Return objGenPresAd.valTotTodosIdCor(cantidadMeses)
    End Function
    Public Function consultarPptoKilos(ByVal vendedor As Integer) As Double()
        Return objGenPresAd.consultarPptoKilos(vendedor)
    End Function
    Public Function consultarVtaMesId_cor(ByVal vendedor As Integer) As Double()
        Return objGenPresAd.consultarVtaMesId_cor(vendedor)
    End Function
    Public Function ejmGraftica() As DataTable
        Return objGenPresAd.ejmGraftica()
    End Function
    Public Function existeTazabilidad() As Boolean
        Return objGenPresAd.existeTazabilidad()
    End Function
    Public Sub trazTodos()
        objGenPresAd.trazTodos()
        'objGenPresAd.listarGenTazCu(1001)
    End Sub
    Public Sub cerrarPres(ByVal fecha As String)
        objGenPresAd.cerrarPres(fecha)
    End Sub
    Public Function consultarCerrado(ByVal fec As String) As Boolean
        Return objGenPresAd.consultarCerrado(fec)
    End Function
    Public Function listarPresGeneral(ByVal fec As String) As List(Of GenerarPresEn)
        Return objGenPresAd.listarPresGeneral(fec)
    End Function
End Class