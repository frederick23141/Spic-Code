Public Class FacturaEncEn
    Private _nit As String
    Private _nombres As String
    Private _direccion As String
    Private _ciudad As String
    Private _telefono As String
    Private _numero As Integer
    Private _sub_total As Double
    Private _iva As Double
    Private _valor_total As Double
    Private _fecha As Date
    Private _fecha_venc As Date
    Private _condicion As Integer
    Private _vendedor As String
    Private _notas As String
    Private _pedido As Integer


    Public Property pedido() As Integer
        Get
            Return _pedido
        End Get
        Set(ByVal value As Integer)
            _pedido = value
        End Set
    End Property
    Public Property notas() As String
        Get
            Return _notas
        End Get
        Set(ByVal value As String)
            _notas = value
        End Set
    End Property
    
    Public Property vendedor() As String
        Get
            Return _vendedor
        End Get
        Set(ByVal value As String)
            _vendedor = value
        End Set
    End Property
    Public Property condicion() As Integer
        Get
            Return _condicion
        End Get
        Set(ByVal value As Integer)
            _condicion = value
        End Set
    End Property
    Public Property fecha_venc() As Date
        Get
            Return _fecha_venc
        End Get
        Set(ByVal value As Date)
            _fecha_venc = value
        End Set
    End Property
    Public Property fecha() As Date
        Get
            Return _fecha
        End Get
        Set(ByVal value As Date)
            _fecha = value
        End Set
    End Property
    Public Property valor_total() As Double
        Get
            Return _valor_total
        End Get
        Set(ByVal value As Double)
            _valor_total = value
        End Set
    End Property
    Public Property iva() As Double
        Get
            Return _iva
        End Get
        Set(ByVal value As Double)
            _iva = value
        End Set
    End Property
    Public Property sub_total() As Double
        Get
            Return _sub_total
        End Get
        Set(ByVal value As Double)
            _sub_total = value
        End Set
    End Property
    Public Property numero() As Integer
        Get
            Return _numero
        End Get
        Set(ByVal value As Integer)
            _numero = value
        End Set
    End Property
    Public Property telefono() As String
        Get
            Return _telefono
        End Get
        Set(ByVal value As String)
            _telefono = value
        End Set
    End Property
    Public Property ciudad() As String
        Get
            Return _ciudad
        End Get
        Set(ByVal value As String)
            _ciudad = value
        End Set
    End Property
    Public Property direccion() As String
        Get
            Return _direccion
        End Get
        Set(ByVal value As String)
            _direccion = value
        End Set
    End Property
    Public Property nombres() As String
        Get
            Return _nombres
        End Get
        Set(ByVal value As String)
            _nombres = value
        End Set
    End Property
    Public Property nit() As String
        Get
            Return _nit
        End Get
        Set(ByVal value As String)
            _nit = value
        End Set
    End Property
End Class
