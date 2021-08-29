Public Class OrdenProdEn
    Private _cod_orden As String
    Private _cod_det As String
    Private _fecha As String
    Private _maquina As String
    Private _origen As String
    Private _calidad As String
    Private _diam_alambron As String
    Private _velocidad As String
    Private _cod_materia_prim As String
    Private _diam_prod_final As String
    Private _cod_prod_final As String
    Private _prod_final_desc As String

    Public Property fecha()
        Get
            Return _fecha
        End Get
        Set(ByVal value)
            Me._fecha = value
        End Set
    End Property
    Public Property maquina()
        Get
            Return _maquina
        End Get
        Set(ByVal value)
            Me._maquina = value
        End Set
    End Property
    Public Property origen()
        Get
            Return _origen
        End Get
        Set(ByVal value)
            Me._origen = value
        End Set
    End Property
    Public Property calidad()
        Get
            Return _calidad
        End Get
        Set(ByVal value)
            Me._calidad = value
        End Set
    End Property
    Public Property diam_alambron()
        Get
            Return _diam_alambron
        End Get
        Set(ByVal value)
            Me._diam_alambron = value
        End Set
    End Property
    Public Property velocidad()
        Get
            Return _velocidad
        End Get
        Set(ByVal value)
            Me._velocidad = value
        End Set
    End Property
    Public Property cod_materia_prim()
        Get
            Return _cod_materia_prim
        End Get
        Set(ByVal value)
            Me._cod_materia_prim = value
        End Set
    End Property
    Public Property diam_prod_final()
        Get
            Return _diam_prod_final
        End Get
        Set(ByVal value)
            Me._diam_prod_final = value
        End Set
    End Property
    Public Property cod_prod_final()
        Get
            Return _cod_prod_final
        End Get
        Set(ByVal value)
            Me._cod_prod_final = value
        End Set
    End Property
    Public Property cod_orden()
        Get
            Return _cod_orden
        End Get
        Set(ByVal value)
            Me._cod_orden = value
        End Set
    End Property
    Public Property cod_det()
        Get
            Return _cod_det
        End Get
        Set(ByVal value)
            Me._cod_det = value
        End Set
    End Property
    Public Property prod_final_desc()
        Get
            Return _prod_final_desc
        End Get
        Set(ByVal value)
            Me._prod_final_desc = value
        End Set
    End Property


End Class
