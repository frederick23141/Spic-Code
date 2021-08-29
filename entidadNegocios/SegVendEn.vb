Public Class SegVendEn
    Private sVend As String
    Private dVtas As Double
    Private dPresVent As Double
    Private dRec As Double
    Private dPresRec As Double
    Private dPend As Double
    Private _No_reflej As Double
    Private dDev As Double
    Private dPorcCumpVtas As Double
    Private dPorcCumpRec As Double
    Private dPorcDev As Double
    Private _porc_util As Double

    Public Property Vendedor()
        Get
            Return sVend
        End Get
        Set(ByVal value)
            Me.sVend = value
        End Set
    End Property
    Public Property Ventas()
        Get
            Return dVtas
        End Get
        Set(ByVal value)
            Me.dVtas = value
        End Set
    End Property
    Public Property Pres_Ventas()
        Get
            Return dPresVent
        End Get
        Set(ByVal value)
            Me.dPresVent = value
        End Set
    End Property
    Public Property Pend()
        Get
            Return dPend
        End Get
        Set(ByVal value)
            Me.dPend = value
        End Set
    End Property
    Public Property No_reflej()
        Get
            Return _No_reflej
        End Get
        Set(ByVal value)
            Me._No_reflej = value
        End Set
    End Property
    Public Property Rec()
        Get
            Return dRec
        End Get
        Set(ByVal value)
            Me.dRec = value
        End Set
    End Property
    Public Property Pres_rec()
        Get
            Return dPresRec
        End Get
        Set(ByVal value)
            Me.dPresRec = value
        End Set
    End Property
    Public Property Dev()
        Get
            Return dDev
        End Get
        Set(ByVal value)
            Me.dDev = value
        End Set
    End Property
    Public Property porCumVtas()
        Get
            Return dPorcCumpVtas
        End Get
        Set(ByVal value)
            Me.dPorcCumpVtas = value
        End Set
    End Property
    Public Property porCumRec()
        Get
            Return dPorcCumpRec
        End Get
        Set(ByVal value)
            Me.dPorcCumpRec = value
        End Set
    End Property
    Public Property porDev()
        Get
            Return dPorcDev
        End Get
        Set(ByVal value)
            Me.dPorcDev = value
        End Set
    End Property
    Public Property Por_util()
        Get
            Return _porc_util
        End Get
        Set(ByVal value)
            Me._porc_util = value
        End Set
    End Property



End Class
