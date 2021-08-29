Public Class FactuMesActualEN
    Dim fecha As Date
    Dim tipo As String
    Dim codigo As String
    Dim descripcion As String
    Dim cantidad As Integer


    Dim pedido As String
    Dim numero As Integer
    Dim kilos As Decimal
    Dim valorUnitario As Decimal
    Dim notas As String
    Dim valorTotal As Integer


    Public Property fechaFactura()
        Get
            Return fecha
        End Get
        Set(ByVal value)
            Me.fecha = value
        End Set
    End Property
    Public Property pedidoF()
        Get
            Return pedido
        End Get
        Set(ByVal value)
            Me.pedido = value
        End Set
    End Property

    Public Property tipoFactura()
        Get
            Return tipo
        End Get
        Set(ByVal value)
            Me.tipo = value
        End Set
    End Property
    Public Property numeroF()
        Get
            Return numero
        End Get
        Set(ByVal value)
            Me.numero = value
        End Set
    End Property

    Public Property codigoFactura()
        Get
            Return codigo
        End Get
        Set(ByVal value)
            Me.codigo = value
        End Set
    End Property

    Public Property descripcionFactura()
        Get
            Return descripcion
        End Get
        Set(ByVal value)
            Me.descripcion = value
        End Set
    End Property

    Public Property cantidadFactura()
        Get
            Return cantidad
        End Get
        Set(ByVal value)
            Me.cantidad = value
        End Set
    End Property
    Public Property kilosF()
        Get
            Return kilos
        End Get
        Set(ByVal value)
            Me.kilos = CInt(value)
        End Set
    End Property


    Public Property valorUnitarioF()
        Get
            Return valorUnitario
        End Get
        Set(ByVal value)
            Me.valorUnitario = CInt(value)
        End Set
    End Property
    Public Property valorTotalFactura()
        Get
            Return valorTotal
        End Get
        Set(ByVal value)
            Me.valorTotal = CInt(value)
        End Set
    End Property

   
    
    Public Property notasF()
        Get
            Return notas
        End Get
        Set(ByVal value)
            If IsDBNull(value) Then
                ' MsgBox("el valor es null")
            Else
                Me.notas = value
            End If

        End Set
    End Property
  

    'SELECT     pedido, tipo, numero, fec, codigo, descripcion, cantidad, Kilos, valor_unitario, Vr_total, notas

End Class
