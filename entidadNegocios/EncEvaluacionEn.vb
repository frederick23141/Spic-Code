Public Class EncEvaluacionEn
    Private _numero As String
    Private _fecha As String
    Private _nit As String
    Private _nombre As String
    Private _contacto As String
    Private _punt_obtenido As String
    Private _punt_ant As String
    Private _observaciones As String
    Public Property observaciones()
        Get
            Return _observaciones
        End Get
        Set(ByVal value)
            Me._observaciones = value
        End Set
    End Property
    Public Property punt_ant()
        Get
            Return _punt_ant
        End Get
        Set(ByVal value)
            Me._punt_ant = value
        End Set
    End Property
    Public Property punt_obtenido()
        Get
            Return _punt_obtenido
        End Get
        Set(ByVal value)
            Me._punt_obtenido = value
        End Set
    End Property
    Public Property contacto()
        Get
            Return _contacto
        End Get
        Set(ByVal value)
            Me._contacto = value
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
    Public Property nit()
        Get
            Return _nit
        End Get
        Set(ByVal value)
            Me._nit = value
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
    Public Property numero()
        Get
            Return _numero
        End Get
        Set(ByVal value)
            Me._numero = value
        End Set
    End Property
End Class
