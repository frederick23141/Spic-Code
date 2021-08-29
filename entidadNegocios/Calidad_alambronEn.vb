Public Class Calidad_alambronEn
    Private _calidad As Integer
    Private _carbono As String
    Private _magneso As String
    Private _fosforo_max As String
    Private _azufre_max As String

    Public Property calidad() As Integer
        Get
            Return _calidad
        End Get
        Set(ByVal value As Integer)
            _calidad = value
        End Set
    End Property
    Public Property carbono() As String
        Get
            Return _carbono
        End Get
        Set(ByVal value As String)
            _carbono = value
        End Set
    End Property
    Public Property magneso() As String
        Get
            Return _magneso
        End Get
        Set(ByVal value As String)
            _magneso = value
        End Set
    End Property
    Public Property fosforo_max() As String
        Get
            Return _fosforo_max
        End Get
        Set(ByVal value As String)
            _fosforo_max = value
        End Set
    End Property
    Public Property azufre_max() As String
        Get
            Return _azufre_max
        End Get
        Set(ByVal value As String)
            _azufre_max = value
        End Set
    End Property
End Class
