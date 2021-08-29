Public Class FacturaEn
    Private _sw As String
    Private _Bodega As String
    Private _Numero As String
    Public Property sw() As Integer
        Get
            Return _sw
        End Get
        Set(ByVal value As Integer)
            _sw = value
        End Set
    End Property
    Public Property bodega() As Integer
        Get
            Return _Bodega
        End Get
        Set(ByVal value As Integer)
            _Bodega = value
        End Set
    End Property
    Public Property numero() As Double
        Get
            Return _Numero
        End Get
        Set(ByVal value As Double)
            _Numero = value
        End Set
    End Property
    Private _Nit As Double
    Public Property nit() As Double
        Get
            Return _Nit
        End Get
        Set(ByVal value As Double)
            _Nit = value
        End Set
    End Property
    Private _Vendedor As Integer
    Public Property vendedor() As Integer
        Get
            Return _Vendedor
        End Get
        Set(ByVal value As Integer)
            _Vendedor = value
        End Set
    End Property
    Private _Fecha As String
    Public Property fecha() As String
        Get
            Return _Fecha
        End Get
        Set(ByVal value As String)
            _Fecha = value
        End Set
    End Property
    Private _Condicion As String
    Public Property condicion() As Integer
        Get
            Return _Condicion
        End Get
        Set(ByVal value As Integer)
            _Condicion = value
        End Set
    End Property
    Private _diasVal As String
    Public Property diasVal() As Integer
        Get
            Return _diasVal
        End Get
        Set(ByVal value As Integer)
            _diasVal = value
        End Set
    End Property
    Private _descuento_pie As Decimal
    Public Property descuento_pie() As Decimal
        Get
            Return _descuento_pie
        End Get
        Set(ByVal value As Decimal)
            _descuento_pie = value
        End Set
    End Property
    Private _Val_tot As Double
    Public Property Val_tot() As Double
        Get
            Return _Val_tot
        End Get
        Set(ByVal value As Double)
            _Val_tot = value
        End Set
    End Property
    Private _FechaHora As String
    Public Property Fecha_Hora() As String
        Get
            Return _FechaHora
        End Get
        Set(ByVal value As String)
            _FechaHora = value
        End Set
    End Property
    Private _anulado As String
    Public Property anulado() As Integer
        Get
            Return _anulado
        End Get
        Set(ByVal value As Integer)
            _anulado = value
        End Set
    End Property
    Private _notas As String
    Public Property notas() As String
        Get
            Return _notas
        End Get
        Set(ByVal value As String)
            _notas = value
        End Set
    End Property
    Private _usuario As String
    Public Property usuario() As String
        Get
            Return _usuario
        End Get
        Set(ByVal value As String)
            _usuario = value
        End Set
    End Property
    Private _pc As String
    Public Property pc() As String
        Get
            Return _pc
        End Get
        Set(ByVal value As String)
            _pc = value
        End Set
    End Property
    Private _duracion As String
    Public Property duracion() As Integer
        Get
            Return _duracion
        End Get
        Set(ByVal value As Integer)
            _duracion = value
        End Set
    End Property
    Private _concepto As String
    Public Property concepto() As String
        Get
            Return _concepto
        End Get
        Set(ByVal value As String)
            _concepto = value
        End Set
    End Property
    Private _moneda As Integer
    Public Property moneda() As Integer
        Get
            Return _moneda
        End Get
        Set(ByVal value As Integer)
            _moneda = value
        End Set
    End Property
    Private _despacho As String
    Public Property despacho() As String
        Get
            Return _despacho
        End Get
        Set(ByVal value As String)
            _despacho = value
        End Set
    End Property
    Private _fecha_Entrega As String
    Public Property fecha_Entrega() As String
        Get
            Return _fecha_Entrega
        End Get
        Set(ByVal value As String)
            _fecha_Entrega = value
        End Set
    End Property
    Private _nit_Destino As Integer
    Public Property nit_Destino() As Integer
        Get
            Return _nit_Destino
        End Get
        Set(ByVal value As Integer)
            _nit_Destino = value
        End Set
    End Property
    Private _cod_direc As String
    Public Property cod_direc() As String
        Get
            Return _cod_direc
        End Get
        Set(ByVal value As String)
            _cod_direc = value
        End Set
    End Property

















End Class
