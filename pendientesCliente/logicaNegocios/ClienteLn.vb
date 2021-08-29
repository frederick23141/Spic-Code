Imports entidadNegocios
Imports accesoDatos
Public Class ClienteLn
    '****************************************************************************************************************
    'Se crean las instancias de las clases necesarias****************************************************************
    '****************************************************************************************************************
    Private objClienteAd As ClienteAd
    Private objpendientesAd As pendientesAd
    Private objFacturaMesActualAd As facturaMesActualAd
    Private objCarteraAd As carteraAd
    Private objDespachoAd As DespachoAd
    Public Sub New()
        objClienteAd = New ClienteAd
        objpendientesAd = New pendientesAd
        objFacturaMesActualAd = New facturaMesActualAd
        objCarteraAd = New carteraAd
        objDespachoAd = New DespachoAd

    End Sub
    '****************************************************************************************************************
    'Se hace el enlace de el formulario con los objetos de acceso a datos aca se llaman los diferentes prodecimientos
    'se le mandan los parametos y se retorna el resultadp a los diferentes formularios*******************************
    '****************************************************************************************************************

    'Funciones que invocan a la clase  ClienteAd
    Public Function listarBusqueda(ByVal cadena As String) As DataTable
        Return objClienteAd.listarBusqueda(cadena)
    End Function
    Public Function existeUsuario(ByVal nit As Double) As Boolean
        Return objClienteAd.existeCliente(nit)
    End Function
    Public Function existeUsuarioTERCEROS(ByVal nit As Double) As Boolean
        Return objClienteAd.existeClienteTerceros(nit)
    End Function
    Public Function listarDatosCliente(ByVal nit As Double) As DataTable
        Return objClienteAd.listarCliente(nit)
    End Function
    Public Function listarDatosClienteTERCEROS(ByVal nit As Double) As DataTable
        Return objClienteAd.listarClienteTERCEROS(nit)
    End Function

    Public Function cupoDisponible(ByVal nit As Double, ByVal penSumValTot As Double, ByVal saldo As Double)
        Return objClienteAd.cupoDisponible(nit, penSumValTot, saldo)
    End Function
    Public Function mayVenta(ByVal nit As Double) As Double
        Return (objClienteAd.mayVenta(nit))
    End Function
    Public Function fechMayVenta(ByVal nit As Double, ByVal valor As Double) As String
        Return (objClienteAd.fechMayVenta(nit, valor))
    End Function
    Public Function mostrarSaldoCliente(ByVal nit As Double) As String
        Return objClienteAd.mostrarSaldoCliente(nit)
    End Function

    'Funciones que invocan a la clase pendientesAd
    Public Function listarPendientes(ByVal nit As Double) As DataTable
        Return objpendientesAd.listarPendiente(nit)
    End Function
    Public Function sumPenValTot(ByVal nit As Double) As Double
        Return objpendientesAd.sumValTot(nit)
    End Function
    Public Function sumPenKilos(ByVal nit As Double) As Double
        Return objpendientesAd.sumKilos(nit)
    End Function

    'Funciones que invocan a la clase CarteraAd
    Public Function listarCartera(ByVal nit As Double) As DataTable
        Return objCarteraAd.listarCartera(nit)
    End Function
    Public Function sumValorTotalCartera(ByVal nit As Double) As Double
        Return objCarteraAd.sumarValorTot(nit)
    End Function
    Public Function sumValAplicado(ByVal nit As Double) As Double
        Return objCarteraAd.sumarValorAplicado(nit)
    End Function
    Public Function sumSaldo(ByVal nit As Double) As Double
        Return objCarteraAd.sumarSaldo(nit)
    End Function
    Public Function sumSinVencer(ByVal nit As Double) As Double
        Return objCarteraAd.sumarSinVencer(nit)
    End Function
    Public Function sum1a30(ByVal nit As Double) As Double
        Return objCarteraAd.sumar1a30(nit)
    End Function
    Public Function sum31a60(ByVal nit As Double) As Double
        Return objCarteraAd.sumar31a60(nit)
    End Function
    Public Function sum61a91(ByVal nit As Double) As Double
        Return objCarteraAd.sumar61a91(nit)
    End Function
    Public Function sum91a120(ByVal nit As Double) As Double
        Return objCarteraAd.sumar91a120(nit)
    End Function
    Public Function sumMas120(ByVal nit As Double) As Double
        Return objCarteraAd.sumarMas120(nit)
    End Function

    'Funciones que invocan a la clase  FacturaMesActualAd

    Public Function listarFactura(ByVal nit As Double, ByVal mes As String, ByVal año As String) As DataTable
        Return objFacturaMesActualAd.listarFactura(nit, mes, año)
    End Function
   
    Public Function sumValorTotal(ByVal nit As Double, ByVal mes As String, ByVal año As String) As Double
        Return objFacturaMesActualAd.sumarValorTotal(nit, mes, año)
    End Function
    Public Function sumTotKilos(ByVal nit As Double, ByVal mes As String, ByVal año As String) As Decimal
        Return objFacturaMesActualAd.sumarValorKilos(nit, mes, año)
    End Function
    
    'Funciones que invocan a la clase  DespachoAd

    Public Function listarDespacho(ByVal nit As Double, ByVal fecha As Date)
        Return objDespachoAd.listarDespacho(nit, fecha)
    End Function
    Public Function nombres(ByVal nit As Double) As String
        Return objClienteAd.nombres(nit)
    End Function

End Class

