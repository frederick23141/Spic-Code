Public Class ReferenciaEn
    Private _codigo As String
    Private _descripcion As String
    Private _valor_unitario As Double
    Private _costo_unitario As Double
    Public Property codigo() As String
        Get
            Return _codigo
        End Get
        Set(ByVal value As String)
            _codigo = value
        End Set
    End Property
    Public Property descripcion() As String
        Get
            Return _descripcion
        End Get
        Set(ByVal value As String)
            _descripcion = value
        End Set
    End Property
    Public Property valor_unitario() As Double
        Get
            Return _valor_unitario
        End Get
        Set(ByVal value As Double)
            _valor_unitario = value
        End Set
    End Property
    Public Property costo_unitario() As Double
        Get
            Return _costo_unitario
        End Get
        Set(ByVal value As Double)
            _costo_unitario = value
        End Set
    End Property


End Class
