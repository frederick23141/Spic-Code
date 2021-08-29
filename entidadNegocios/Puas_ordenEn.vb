Public Class Puas_ordenEn
    'autor david hincapié
    'Atributos utilizados por el modulo de puas
    Dim nro, cant_prog, cant_trab As Integer
    Dim nit As Double
    Dim maquina, mat_p, mat_p2, pruducto, nombre_oper, productoDes, mat_pDes, mat_p2Des As String

    Public Property pnro
        Get
            Return nro
        End Get
        Set(ByVal value)
            nro = value
        End Set
    End Property

    Public Property pcant_prog
        Get
            Return cant_prog
        End Get
        Set(ByVal value)
            cant_prog = value
        End Set
    End Property

    Public Property pcant_trab
        Get
            Return cant_trab
        End Get
        Set(ByVal value)
            cant_trab = value
        End Set
    End Property
    Public Property pnit
        Get
            Return nit
        End Get
        Set(ByVal value)
            nit = value
        End Set
    End Property

    Public Property pmaquina
        Get
            Return maquina
        End Get
        Set(ByVal value)
            maquina = value
        End Set
    End Property
   
    Public Property pmat_p
        Get
            Return mat_p
        End Get
        Set(ByVal value)
            mat_p = value
        End Set
    End Property
    Public Property pmat_p2
        Get
            Return mat_p2
        End Get
        Set(ByVal value)
            mat_p2 = value
        End Set
    End Property
    Public Property ppruducto
        Get
            Return pruducto
        End Get
        Set(ByVal value)
            pruducto = value
        End Set
    End Property
    Public Property pproductoDes
        Get
            Return productoDes
        End Get
        Set(ByVal value)
            productoDes = value
        End Set
    End Property
    Public Property pmat_p2Des
        Get
            Return mat_p2Des
        End Get
        Set(ByVal value)
            mat_p2Des = value
        End Set
    End Property
    Public Property pmat_pDes
        Get
            Return mat_pDes
        End Get
        Set(ByVal value)
            mat_pDes = value
        End Set
    End Property
    Public Property pnoper
        Get
            Return nombre_oper
        End Get
        Set(ByVal value)
            nombre_oper = value
        End Set
    End Property

    Public Sub New()
    End Sub
    Public Sub New(ByVal r_nro As Integer, ByVal r_cant_p As Integer, ByVal r_cant_t As Integer, ByVal r_nit As Double, ByVal r_maquina As String, ByVal r_mat_p As String, ByVal r_mat_p2 As String, ByVal r_producto As String, ByVal r_noper As String, ByVal productoDes As String, ByVal mp1Des As String, ByVal mp2Des As String)
        pnro = r_nro
        pcant_prog = r_cant_p
        pcant_trab = r_cant_t
        pnit = r_nit
        pmaquina = r_maquina
        pmat_p2 = r_mat_p2
        pmat_p = r_mat_p
        ppruducto = r_producto
        pnoper = r_noper
        pproductoDes = productoDes
        pmat_pDes = mp1Des
        pmat_p2Des = mp2Des
    End Sub
End Class
