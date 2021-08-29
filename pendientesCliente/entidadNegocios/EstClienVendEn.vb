Public Class EstClienVendEn
    Private Svendedor As Integer
    Private Snombres As String
    Private StotClient As Double
    Private StotAct As Double
    Private StotInac As Double
    Private StotBloq As Double
    Private SnoUsar As Double
    Private SmovTotales As Double
    Private SmovActivo As Double
    Private SmovInactivo As Double
    Private SmovBloqueado As Double
    Private SmovNoUsar As Double
    Private SatendFecIni As Double
    Private SatendFecFin As Double
    Private SnEfectFecIni As Double
    Private SnEfectFecFin As Double

    Public Property Vendedor()
        Get
            Return Svendedor
        End Get
        Set(ByVal value)
            Me.Svendedor = value
        End Set
    End Property
    Public Property Nombres()
        Get
            Return Snombres
        End Get
        Set(ByVal value)
            Me.Snombres = value
        End Set
    End Property
    Public Property Tot_cliente()
        Get
            Return StotClient
        End Get
        Set(ByVal value)
            Me.StotClient = value
        End Set
    End Property
    Public Property Tot_act()
        Get
            Return StotAct
        End Get
        Set(ByVal value)
            Me.StotAct = value
        End Set
    End Property
    Public Property Tot_Inactivo()
        Get
            Return StotInac
        End Get
        Set(ByVal value)
            Me.StotInac = value
        End Set
    End Property
    Public Property Tot_Bloq()
        Get
            Return StotBloq
        End Get
        Set(ByVal value)
            Me.StotBloq = value
        End Set
    End Property
    Public Property Tot_no_usar()
        Get
            Return SnoUsar
        End Get
        Set(ByVal value)
            Me.SnoUsar = value
        End Set
    End Property
    Public Property Mov_totales()
        Get
            Return SmovTotales
        End Get
        Set(ByVal value)
            Me.SmovTotales = value
        End Set
    End Property
    Public Property Mov_act()
        Get
            Return SmovActivo
        End Get
        Set(ByVal value)
            Me.SmovActivo = value
        End Set
    End Property
    Public Property Mov_inactivo()
        Get
            Return SmovInactivo
        End Get
        Set(ByVal value)
            Me.SmovInactivo = value
        End Set
    End Property
    Public Property Mov_bloq()
        Get
            Return SmovBloqueado
        End Get
        Set(ByVal value)
            Me.SmovBloqueado = value
        End Set
    End Property
    Public Property Mov_no_usar()
        Get
            Return SmovNoUsar
        End Get
        Set(ByVal value)
            Me.SmovNoUsar = value
        End Set
    End Property
    Public Property AtendFecIni()
        Get
            Return SatendFecIni
        End Get
        Set(ByVal value)
            Me.SatendFecIni = value
        End Set
    End Property
    Public Property AtendFecFin()
        Get
            Return SatendFecFin
        End Get
        Set(ByVal value)
            Me.SatendFecFin = value
        End Set
    End Property
    Public Property NefectFecIni()
        Get
            Return SnEfectFecIni
        End Get
        Set(ByVal value)
            Me.SnEfectFecIni = value
        End Set
    End Property
    Public Property NefectFecFin()
        Get
            Return SnEfectFecFin
        End Get
        Set(ByVal value)
            Me.SnEfectFecFin = value
        End Set
    End Property
End Class
