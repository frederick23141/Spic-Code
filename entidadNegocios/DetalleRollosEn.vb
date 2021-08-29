Public Class DetalleRollosEn
    Private _numRollo As String
    Private _peso As String
    Private _colada As String
    Private _traccion As String

    Public Property numRollo() As Integer
        Get
            Return _numRollo
        End Get
        Set(ByVal value As Integer)
            _numRollo = value
        End Set
    End Property
    Public Property peso() As String
        Get
            Return _peso
        End Get
        Set(ByVal value As String)
            _peso = value
        End Set
    End Property
    Public Property colada() As String
        Get
            Return _colada
        End Get
        Set(ByVal value As String)
            _colada = value
        End Set
    End Property
    Public Property traccion() As String
        Get
            Return _traccion
        End Get
        Set(ByVal value As String)
            _traccion = value
        End Set
    End Property
End Class
