Public Class UsuarioEn

    Private strEmail As String
    Private strTipoPermiso As String
    Private strEmailClave As String
    Private strNombre As String
    Private _QuienAut As String
    Private _Vendedor As String
    Private _clave As String
    Private _bodega As Integer
    Private _nombresCompleto As String
    Public Property clave() As String
        Get
            Return _clave
        End Get
        Set(ByVal value As String)
            _clave = value
        End Set
    End Property
    Public Property nombresCompleto() As String
        Get
            Return _nombresCompleto
        End Get
        Set(ByVal value As String)
            _nombresCompleto = value
        End Set
    End Property

    Public Property Vendedor() As String
        Get
            Return _Vendedor
        End Get
        Set(ByVal value As String)
            _Vendedor = value
        End Set
    End Property
    Public Property QuienAut() As String
        Get
            Return _QuienAut
        End Get
        Set(ByVal value As String)
            _QuienAut = value
        End Set
    End Property

    Public Property permiso() As String
        Get
            Return strTipoPermiso
        End Get
        Set(ByVal value As String)
            strTipoPermiso = value
        End Set
    End Property
    Public Property Email() As String
        Get
            Return strEmail
        End Get
        Set(ByVal value As String)
            strEmail = value
        End Set
    End Property
    Public Property EmailClave() As String
        Get
            Return strEmailClave
        End Get
        Set(ByVal value As String)
            strEmailClave = value
        End Set
    End Property
    Public Property nombre() As String
        Get
            Return strNombre
        End Get
        Set(ByVal value As String)
            strNombre = value
        End Set
    End Property
    Public Property bodega() As Integer
        Get
            Return _bodega
        End Get
        Set(ByVal value As Integer)
            _bodega = value
        End Set
    End Property

End Class
