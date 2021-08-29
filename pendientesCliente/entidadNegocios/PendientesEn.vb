Public Class pendientesEn
    Private id As Integer
    Private codigo As String
    Private descripcion As String
    Private valorUn As Integer


    Public Property idPrendiente()
        Get
            Return Me.id
        End Get
        Set(ByVal value)
            id = value
        End Set
    End Property

    Public Property codigoPendiente()
        Get
            Return Me.codigo
        End Get
        Set(ByVal value)
            codigo = value
        End Set
    End Property

    Public Property descripcionPendiente()
        Get
            Return Me.descripcion
        End Get
        Set(ByVal value)
            descripcion = value
        End Set
    End Property

    Public Property valorUnitarioPrendiente()
        Get
            Return Me.valorUn
        End Get
        Set(ByVal value)
            valorUn = CInt(value)
        End Set
    End Property
    

End Class
