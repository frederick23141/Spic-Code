
Public Class AcumVentEn
    Private vendedorV As Double
    Private ciudadV As String
    Private nitV As Double
    Private nombresV As String
    Private alBrillV As Double
    Private alRecoV As Double
    Private alEspV As Double
    Private varillasV As Double
    Private alPuasV As Double
    Private alGalvV As Double
    Private alPolloV As Double
    Private cc350_700V As Double
    Private cc400_800V As Double
    Private cc500_1000V As Double
    Private clGranelV As Double
    Private clVaretaV As Double
    Private clZincV As Double
    Private helYAnulaV As Double
    Private helecV As Double
    Private clAceroV As Double '
    Private grapasV As Double
    Private clHerrarV As Double
    Private trEstufaV As Double
    Private trMadV As Double
    Private trLaminaV As Double
    Private trAGloV As Double
    Private trChazoV As Double
    Private remacheV As Double
    Private carriajeV As Double
    Private trDrywallV As Double
    Private arandelaV As Double
    Private clas_corV As Double

    Public Property Vendedor()
        Get
            Return vendedorV
        End Get
        Set(ByVal value)
            Me.vendedorV = value
        End Set
    End Property
    Public Property ciudad()
        Get
            Return ciudadV
        End Get
        Set(ByVal value)
            If IsDBNull(value) Then
            Else
                Me.ciudadV = value
            End If
        End Set
    End Property
    Public Property nit()
        Get
            Return nitV
        End Get
        Set(ByVal value)
            Me.nitV = value
        End Set
    End Property
    Public Property Nombres()
        Get
            Return nombresV
        End Get
        Set(ByVal value)
            If IsDBNull(value) Then
            Else
                Me.nombresV = value
            End If

        End Set
    End Property
    Public Property alBrill()
        Get
            Return alBrillV
        End Get
        Set(ByVal value)
            Me.alBrillV = CInt(value)
        End Set
    End Property
    Public Property alReco()
        Get
            Return alRecoV
        End Get
        Set(ByVal value)
            Me.alRecoV = CInt(value)
        End Set
    End Property
    Public Property alEspe()
        Get
            Return alEspV
        End Get
        Set(ByVal value)
            Me.alEspV = CInt(value)
        End Set
    End Property
    Public Property varillas()
        Get
            Return varillasV
        End Get
        Set(ByVal value)
            Me.varillasV = CInt(value)
        End Set
    End Property
    Public Property alPuas()
        Get
            Return alPuasV
        End Get
        Set(ByVal value)
            Me.alPuasV = CInt(value)
        End Set
    End Property
    Public Property alGalv()
        Get
            Return alGalvV
        End Get
        Set(ByVal value)
            Me.alGalvV = CInt(value)
        End Set
    End Property
    Public Property mallPollo()
        Get
            Return alPolloV
        End Get
        Set(ByVal value)
            Me.alPolloV = CInt(value)
        End Set
    End Property
    Public Property cc350_700()
        Get
            Return cc350_700V
        End Get
        Set(ByVal value)
            Me.cc350_700V = CInt(value)
        End Set
    End Property
    Public Property cc400_800()
        Get
            Return cc400_800V
        End Get
        Set(ByVal value)
            Me.cc400_800V = CInt(value)
        End Set
    End Property
    Public Property cc500_1000()
        Get
            Return cc500_1000V
        End Get
        Set(ByVal value)
            Me.cc500_1000V = CInt(value)
        End Set
    End Property
    Public Property clGranel()
        Get
            Return clGranelV
        End Get
        Set(ByVal value)
            Me.clGranelV = CInt(value)
        End Set
    End Property
    Public Property clZinc()
        Get
            Return clZincV
        End Get
        Set(ByVal value)
            Me.clZincV = CInt(value)
        End Set
    End Property
    Public Property clVareta()
        Get
            Return clVaretaV
        End Get
        Set(ByVal value)
            Me.clVaretaV = CInt(value)
        End Set
    End Property
    Public Property helicoYanula()
        Get
            Return helYAnulaV
        End Get
        Set(ByVal value)
            Me.helYAnulaV = CInt(value)
        End Set
    End Property
    Public Property helectro()
        Get
            Return helecV
        End Get
        Set(ByVal value)
            Me.helecV = CInt(value)
        End Set
    End Property
    Public Property clAcero()
        Get
            Return clAceroV
        End Get
        Set(ByVal value)
            Me.clAceroV = CInt(value)
        End Set
    End Property
    Public Property grapas()
        Get
            Return grapasV
        End Get
        Set(ByVal value)
            Me.grapasV = CInt(value)
        End Set
    End Property
    Public Property clHerrar()
        Get
            Return clHerrarV
        End Get
        Set(ByVal value)
            Me.clHerrarV = CInt(value)
        End Set
    End Property
    Public Property trEstufa()
        Get
            Return trEstufaV
        End Get
        Set(ByVal value)
            Me.trEstufaV = CInt(value)
        End Set
    End Property
    Public Property trLamina()
        Get
            Return trLaminaV
        End Get
        Set(ByVal value)
            Me.trLaminaV = CInt(value)
        End Set
    End Property
    Public Property trMadera()
        Get
            Return trMadV
        End Get
        Set(ByVal value)
            Me.trMadV = CInt(value)
        End Set
    End Property
    Public Property trAglom()
        Get
            Return trAGloV
        End Get
        Set(ByVal value)
            Me.trAGloV = CInt(value)
        End Set
    End Property
    Public Property trChazo()
        Get
            Return trChazoV
        End Get
        Set(ByVal value)
            Me.trChazoV = CInt(value)
        End Set
    End Property
    Public Property remaches()
        Get
            Return remacheV
        End Get
        Set(ByVal value)
            Me.remacheV = CInt(value)
        End Set
    End Property
    Public Property carriaje()
        Get
            Return carriajeV
        End Get
        Set(ByVal value)
            Me.carriajeV = CInt(value)
        End Set
    End Property
    Public Property trDrywall()
        Get
            Return trDrywallV
        End Get
        Set(ByVal value)
            Me.trDrywallV = CInt(value)
        End Set
    End Property

    Public Property arandela()
        Get
            Return arandelaV
        End Get
        Set(ByVal value)
            Me.arandelaV = CInt(value)
        End Set
    End Property

    Public Property clas_cor()
        Get
            Return clas_corV
        End Get
        Set(ByVal value)
            Me.clas_corV = CInt(value)
        End Set
    End Property

End Class
