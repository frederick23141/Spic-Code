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
    Dim objOpSimplesLn As New Op_simpesLn
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

    Public Function getVendedor(ByVal nit As Double) As Int32
        Return objClienteAd.getVendedor(nit)
    End Function
    'Funciones que invocan a la clase  ClienteAd
    Public Function listarBusqueda(ByVal cadena As String, ByVal vendedores As String) As DataTable
        Return objClienteAd.listarBusqueda(cadena, vendedores)
    End Function
    Public Function existeUsuario(ByVal nit As Double) As Boolean
        Return objClienteAd.existeCliente(nit)
    End Function
    Public Function existeUsuarioTERCEROS(ByVal nit As Double, ByVal vendedores As String) As Boolean
        Return objClienteAd.existeUsuarioTERCEROS(nit, vendedores)
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
        Return (objClienteAd.mayVenta(nit, objOpSimplesLn.cambiarFormatoFecha(Now.AddYears(-1))))
    End Function
    Public Function fechMayVenta(ByVal nit As Double, ByVal valor As Double) As String
        Return (objClienteAd.fechMayVenta(nit, valor))
    End Function

    'Funciones que invocan a la clase pendientesAd
    Public Function listarPendientes(ByVal nit As Double) As DataTable
        Return objpendientesAd.listarPendiente(nit)
    End Function
    Public Function sumPenValTot(ByVal nit As Double) As Double
        Dim iva As Double = objOpSimplesLn.getIvaPorc()
        Return objpendientesAd.sumValTot(nit, iva)
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
    Public Function listar_cheq_dev(ByVal nit As Double, ByVal fec As String) As DataTable
        Return objCarteraAd.listar_cheq_dev(nit, fec)
    End Function
    Public Function sumar_cheq_dev(ByVal nit As Double) As Double
        Return objCarteraAd.sumar_cheq_dev(nit)
    End Function

    'Funciones que invocan a la clase  FacturaMesActualAd
    Public Function listar_may_vta(ByVal nit As Double) As DataTable
        Return objFacturaMesActualAd.listar_may_vta(nit)
    End Function
    Public Function listarFactura(ByVal nit As Double, ByVal mesIni As String, ByVal añoIni As String, ByVal mesFin As Integer, ByVal anoFin As Integer, ByVal codigo As String) As DataTable
        Return objFacturaMesActualAd.listarFactura(nit, mesIni, añoIni, mesFin, anoFin, codigo)
    End Function
   
    Public Function sumValorTotal(ByVal nit As Double, ByVal mesIni As String, ByVal añoIni As String, ByVal mesFin As Integer, ByVal anoFin As Integer) As Double
        Return objFacturaMesActualAd.sumarValorTotal(nit, mesIni, añoIni, mesFin, anoFin)
    End Function
    Public Function sumTotKilos(ByVal nit As Double, ByVal mesIni As String, ByVal añoIni As String, ByVal mesFin As Integer, ByVal anoFin As Integer) As Decimal
        Return objFacturaMesActualAd.sumarValorKilos(nit, mesIni, añoIni, mesFin, anoFin)
    End Function
    
    'Funciones que invocan a la clase  DespachoAd

    Public Function listarDespacho(ByVal nit As Double, ByVal fecha As Date)
        Return objDespachoAd.listarDespacho(nit, fecha)
    End Function
    Public Function nombres(ByVal nit As Double) As String
        Return objClienteAd.nombres(nit)
    End Function

End Class

