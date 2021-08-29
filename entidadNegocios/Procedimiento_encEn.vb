Public Class Procedimiento_encEn
    Private _nombre As String
    Private _objetivo As String
    Private _codigo As String
    Private _version As String
    Private _elabora As String
    Private _revisa As String
    Private _aprueba As String
    Private _fecha As String
    Private _fecha_modificacion As String
    Private _numero As String
    Public Property numero()
        Get
            Return _numero
        End Get
        Set(ByVal value)
            Me._numero = value
        End Set
    End Property
    Public Property fecha_modificacion()
        Get
            Return _fecha_modificacion
        End Get
        Set(ByVal value)
            If Not IsDBNull(value) Then
                Me._fecha_modificacion = value
            Else
                Me._fecha_modificacion = ""
            End If

        End Set
    End Property
    Public Property fecha()
        Get
            Return _fecha
        End Get
        Set(ByVal value)
            Me._fecha = value
        End Set
    End Property
    Public Property aprueba()
        Get
            Return _aprueba
        End Get
        Set(ByVal value)
            Me._aprueba = value
        End Set
    End Property
    Public Property revisa()
        Get
            Return _revisa
        End Get
        Set(ByVal value)
            If Not IsDBNull(value) Then
                Me._revisa = value
            Else
                Me._revisa = 0
            End If
        End Set
    End Property
    Public Property elabora()
        Get
            Return _elabora
        End Get
        Set(ByVal value)
            Me._elabora = value
        End Set
    End Property
    Public Property version()
        Get
            Return _version
        End Get
        Set(ByVal value)
            Me._version = value
        End Set
    End Property
    Public Property codigo()
        Get
            Return _codigo
        End Get
        Set(ByVal value)
            Me._codigo = value
        End Set
    End Property
    Public Property objetivo()
        Get
            Return _objetivo
        End Get
        Set(ByVal value)
            Me._objetivo = value
        End Set
    End Property
    Public Property nombre()
        Get
            Return _nombre
        End Get
        Set(ByVal value)
            Me._nombre = value
        End Set
    End Property
End Class
