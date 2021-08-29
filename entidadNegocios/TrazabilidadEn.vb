Public Class TrazabilidadEn
    Private _fecha As String
    Private _kilos As String
    Private _pesos As String
    Private _cto_tot As String
    Private _vendedor As String
    Private _id_cor As String
    Public Property id_cor() As String
        Get
            Return _id_cor
        End Get
        Set(ByVal value As String)
            _id_cor = value
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

    Public Property cto_tot() As String
        Get
            Return _cto_tot
        End Get
        Set(ByVal value As String)
            _cto_tot = value
        End Set
    End Property

    Public Property pesos() As String
        Get
            Return _pesos
        End Get
        Set(ByVal value As String)
            _pesos = value
        End Set
    End Property

    Public Property fecha() As String
        Get
            Return _fecha
        End Get
        Set(ByVal value As String)
            _fecha = value
        End Set
    End Property
    Public Property kilos() As String
        Get
            Return _kilos
        End Get
        Set(ByVal value As String)
            _kilos = value
        End Set
    End Property

End Class
