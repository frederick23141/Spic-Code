Public Class entradausuarioEn
    'autor: david hincape
    Dim consecutivo As Integer
    Dim nit As Double
    Dim fecha_entrada As Date
    Dim fecha_salida As Date
    Dim notas, permiso As String

    Public Property gconsecutivo
        Get
            Return consecutivo
        End Get
        Set(ByVal value)
            consecutivo = value
        End Set
    End Property

    Public Property gnit
        Get
            Return nit
        End Get
        Set(ByVal value)
            nit = value
        End Set
    End Property

    Public Property gfecha_entrada
        Get
            Return fecha_entrada
        End Get
        Set(ByVal value)
            fecha_entrada = value
        End Set
    End Property

    Public Property gfecha_salida
        Get
            Return fecha_salida
        End Get
        Set(ByVal value)
            fecha_salida = value
        End Set
    End Property
    Public Property gnotas
        Get
            Return notas
        End Get
        Set(ByVal value)
            notas = value
        End Set
    End Property

    Public Property gpermiso
        Get
            Return permiso
        End Get
        Set(ByVal value)
            permiso = value
        End Set
    End Property

    Public Sub New()

    End Sub

    Public Sub New(ByVal consecutivo As Integer, ByVal nit As Double, ByVal fecha_entrada As Date, ByVal fecha_salida As Date, ByVal notas As String, ByVal permiso As String)
        gconsecutivo = consecutivo
        gnit = nit
        gfecha_entrada = fecha_entrada
        gfecha_salida = fecha_salida
        gnotas = notas
        gpermiso = permiso
    End Sub
End Class
