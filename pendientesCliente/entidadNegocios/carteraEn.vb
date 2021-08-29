Imports Excel = Microsoft.Office.Interop.Excel

Public Class carteraEn
    Private tipo As String
    Private numero As Integer
    Private vencimiento As String
    Private valorTotal As Decimal
    Private valorAplicado As Decimal
    Private saldo As Decimal
    Private diasVencido As Integer
    Private sinVencer As Decimal
    Private unMes As Decimal
    Private dosMeses As Decimal
    Private tresMeses As Decimal
    Private cuatroMeses As Decimal
    Private mas4Meses As Decimal

    Public Property tipoCartera()
        Get
            Return tipo
        End Get
        Set(ByVal value)
            Me.tipo = value
        End Set
    End Property
    Public Property numeroCartera()
        Get
            Return numero
        End Get
        Set(ByVal value)
            Me.numero = value
        End Set
    End Property
    Public Property vencimientoCartera()
        Get
            Return vencimiento
        End Get
        Set(ByVal value)
            Me.vencimiento = value
        End Set
    End Property
    Public Property valorTotalC()
        Get
            Return valorTotal
        End Get
        Set(ByVal value)
            Me.valorTotal = CInt(value)
        End Set
    End Property
    Public Property valorAplicadoC()
        Get
            Return valorAplicado
        End Get
        Set(ByVal value)
            Me.valorAplicado = CInt(value)
        End Set
    End Property
    Public Property saldoC()
        Get
            Return saldo
        End Get
        Set(ByVal value)
            Me.saldo = CInt(value)
        End Set
    End Property
    Public Property diasVencidoC()
        Get
            Return diasVencido
        End Get
        Set(ByVal value)
            Me.diasVencido = value
        End Set
    End Property
    Public Property sinVencerC()
        Get
            Return sinVencer
        End Get
        Set(ByVal value)
            Me.sinVencer = value
        End Set
    End Property
    Public Property unMesC()
        Get
            Return unMes
        End Get
        Set(ByVal value)
            Me.unMes = CInt(value)
        End Set
    End Property
    Public Property dosMesesC()
        Get
            Return dosMeses
        End Get
        Set(ByVal value)
            Me.dosMeses = CInt(value)
        End Set
    End Property
    Public Property tresMesesC()
        Get
            Return tresMeses
        End Get
        Set(ByVal value)
            Me.tresMeses = CInt(value)
        End Set
    End Property
    Public Property cuatroMesesC()
        Get
            Return cuatroMeses
        End Get
        Set(ByVal value)
            Me.cuatroMeses = CInt(value)
        End Set
    End Property
    Public Property mas4MesesC()
        Get
            Return mas4Meses
        End Get
        Set(ByVal value)
            Me.mas4Meses = CInt(value)
        End Set
    End Property





End Class
