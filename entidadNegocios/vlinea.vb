Public Class vlinea
    ''autor:david alejandro hincapie
    ''entidad creada para implementar el update necesario para el formulario Frm_clasificacionb que se encarga de cambiar la linea de produccion
    'del producto selecionado
    Dim codigo As String
    Dim linea As String
    Public Property gcodigo
        Get
            Return codigo
        End Get
        Set(ByVal value)
            codigo = value
        End Set
    End Property

    Public Property glinea
        Get
            Return linea
        End Get
        Set(ByVal value)
            linea = value
        End Set
    End Property

    Public Sub New()

    End Sub

    Public Sub New(ByVal codigo As String, ByVal linea As String)
        gcodigo = codigo
        glinea = linea
    End Sub
End Class
