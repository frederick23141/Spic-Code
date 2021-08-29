Public Class FacturaDetEn
    Private _codigo As String
    Private _descripcion As String
    Private _valor_unitario As Double
    Private _valor_total As Double
    Private _cantidad As Double
    Private _unidad As String

    Public Property unidad() As String
        Get
            Return _unidad
        End Get
        Set(ByVal value As String)
            _unidad = value
        End Set
    End Property
    Public Property cantidad() As Double
        Get
            Return _cantidad
        End Get
        Set(ByVal value As Double)
            _cantidad = value
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
    Public Property valor_unitario() As Double
        Get
            Return _valor_unitario
        End Get
        Set(ByVal value As Double)
            _valor_unitario = value
        End Set
    End Property
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
End Class
