Public Class AnalisisEn
    Private fecha As String
    Private codigo As String
    Private descripcion As String
    Private pendiente As Double
    Private kilosPend As Double
    Private valorTot As Double
    Private notas As String
    Private vendedor As String
    Private ciudad As String
    Private nit As Double
    Private nombres As String
    Private promDias As Double
    Private bloqueo As Double
    Private credito As Double
    Private numeroA As Double
    Private sautorizacion As String
    
    Public Property nitA()
        Get
            Return nit
        End Get
        Set(ByVal value)
            Me.nit = value
        End Set
    End Property
    Public Property Numero()
        Get
            Return numeroA
        End Get
        Set(ByVal value)
            Me.numeroA = value
        End Set
    End Property
    Public Property aut()
        Get
            Return sautorizacion
        End Get
        Set(ByVal value)
            If (IsDBNull(value)) Then
            Else
                Me.sautorizacion = value
            End If

        End Set
    End Property
    Public Property fechaA()
        Get
            Return fecha
        End Get
        Set(ByVal value)
            Me.fecha = value
        End Set
    End Property
    Public Property codigoA()
        Get
            Return codigo
        End Get
        Set(ByVal value)
            Me.codigo = value
        End Set
    End Property
    Public Property descripcionA()
        Get
            Return descripcion
        End Get
        Set(ByVal value)
            Me.descripcion = value
        End Set
    End Property

    Public Property pendienteA()
        Get
            Return pendiente
        End Get
        Set(ByVal value)
            Me.pendiente = value
        End Set
    End Property
    Public Property kilosA()
        Get
            Return kilosPend
        End Get
        Set(ByVal value)
            Me.kilosPend = CInt(value)
        End Set
    End Property
    Public Property valTotA()
        Get
            Return valorTot
        End Get
        Set(ByVal value)
            Me.valorTot = CInt(value)
        End Set
    End Property
    Public Property vendedorA()
        Get
            Return vendedor
        End Get
        Set(ByVal value)
            Me.vendedor = value
        End Set
    End Property
    Public Property ciudadaA()
        Get
            Return ciudad
        End Get
        Set(ByVal value)
            Me.ciudad = value
        End Set
    End Property
    Public Property nombresA()
        Get
            Return nombres
        End Get
        Set(ByVal value)
            Me.nombres = value
        End Set
    End Property

    Public Property promDiasA()
        Get
            Return promDias
        End Get
        Set(ByVal value)
            Me.promDias = value
        End Set
    End Property
    Public Property bloqueoA()
        Get
            Return bloqueo
        End Get
        Set(ByVal value)
            Me.bloqueo = value
        End Set
    End Property
    Public Property creditoA()
        Get
            Return credito
        End Get
        Set(ByVal value)
            Me.credito = CInt(value)
        End Set
    End Property
    Public Property notasA()
        Get
            Return notas
        End Get
        Set(ByVal value)
            If (IsDBNull(value)) Then
            Else
                Me.notas = value
            End If

        End Set
    End Property

End Class
