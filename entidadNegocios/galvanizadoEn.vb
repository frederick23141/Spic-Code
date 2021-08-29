Public Class galvanizadoEn
    'autor david hincapié
    'Atributos utilizados por la ventana galvanizado
    Dim codigo_rollo, descripcion As String
    Dim id_operador, peso, defecto, capa As String
    Dim bobina As Integer
    Public Property gcodigo_rollo
        Get
            Return codigo_rollo
        End Get
        Set(ByVal value)
            codigo_rollo = value
        End Set
    End Property

    Public Property gdescripcion
        Get
            Return descripcion
        End Get
        Set(ByVal value)
            descripcion = value
        End Set
    End Property

    Public Property gidoperador
        Get
            Return id_operador
        End Get
        Set(ByVal value)
            id_operador = value
        End Set
    End Property



    Public Property gpeso
        Get
            Return peso
        End Get
        Set(ByVal value)
            peso = value
        End Set
    End Property

    Public Property gdefecto
        Get
            Return defecto
        End Get
        Set(ByVal value)
            defecto = value
        End Set
    End Property
    Public Property gcapa
        Get
            Return capa
        End Get
        Set(ByVal value)
            capa = value
        End Set
    End Property
    Public Property gbobina
        Get
            Return bobina
        End Get
        Set(ByVal value)
            bobina = value
        End Set
    End Property

    Public Sub New()

    End Sub

    Public Sub New(ByVal rcodigo_rollo As String, ByVal r_descripcion As String, ByVal r_idoperador As Integer, ByVal rpeso As String, ByVal rdefecto As String, ByVal rcapa As String, ByVal rbobina As Integer)
        gcodigo_rollo = rcodigo_rollo
        gdescripcion = r_descripcion
        gidoperador = r_idoperador
        gpeso = rpeso
        gdefecto = rdefecto
        gcapa = rcapa
        gbobina = rbobina
    End Sub
End Class
