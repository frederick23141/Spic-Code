Public Class Ppto_recaudoEn
    Dim iVendedor As Integer
    Dim sNombres As String
    Dim sFechaPpto As String
    Dim dPptoRecCalc As Double
    Dim dPptoCliContado As Double
    Dim dTotPpto As Double
    Dim dPromclienCont As Double
    Dim sFecMod As String

    Public Property Vendedor()
        Get
            Return Me.iVendedor
        End Get
        Set(ByVal value)
            iVendedor = value
        End Set
    End Property
    Public Property Nombres()
        Get
            Return Me.sNombres
        End Get
        Set(ByVal value)
            sNombres = value
        End Set
    End Property
    Public Property FechaPpto()
        Get
            Return Me.sFechaPpto
        End Get
        Set(ByVal value)
            sFechaPpto = value
        End Set
    End Property
    Public Property Ppto_calculado()
        Get
            Return Me.DpptoRecCalc
        End Get
        Set(ByVal value)
            DpptoRecCalc = value
        End Set
    End Property
    Public Property Ppto_client_contado()
        Get
            Return Me.DpptoCliContado
        End Get
        Set(ByVal value)
            DpptoCliContado = value
        End Set
    End Property
    Public Property Total()
        Get
            Return Me.DtotPpto
        End Get
        Set(ByVal value)
            DtotPpto = value
        End Set
    End Property
    Public Property TotClienCont()
        Get
            Return Me.dPromclienCont
        End Get
        Set(ByVal value)
            dPromclienCont = value
        End Set
    End Property
    Public Property FecMod()
        Get
            Return Me.sFecMod
        End Get
        Set(ByVal value)
            sFecMod = value
        End Set
    End Property

End Class
