Public Class ClienteEn
    Private vendedor As String
    Private nit As Double
    Private ciudad As String
    Private nombres As String
    Private fechaCreacion As String
    Private condicion As String
    Private bloqueo As String
    Private contacto1 As String
    Private cupo As Integer
    Private chequeDevuelto As String
    Private saldoVen As Integer
    Private saldoSin As Integer
    Private saldoTot As Integer
    Private cupoMas30 As Integer
    Private tel1 As Integer
    Private notasTer As String
    Private promDiasPag As Decimal
    Private unMes As Decimal
    Private dosMeses As Decimal
    Private tresMeses As Decimal
    Private cuatroMeses As Decimal
    Private mas4Meses As Decimal
    Private autorizaTexto As String
    Private autorizacion As String
    Private direccion As String
    Private cupoAnt As String
    Private fechaMod As String
    Private celular As String
    Private mail As String

    ''SELECT     vendedor, ciudad, nit, nombres,  fecha_creacion, condicion,  bloqueo, contacto_1,  cupo_credito, Cheques_Dev, Saldo_ven, Saldo_sin, Saldo_Tot, Cupomas30, 
    '                  telefono_1, Notas_ter, Promed_Dias_pago, de_1_a_30, de_31_a_60, de_61_a_90, de_91_a_120, mas_de_120, autoriz_texto, autorizacion, direccion, cupo_ant, 
    '                  fecha_modificacion, celular, mail

    Public Property vendedorC()
        Get
            Return vendedor
        End Get
        Set(ByVal value)
            Me.vendedor = value
        End Set
    End Property
    Public Property ciudadC()
        Get
            Return ciudad
        End Get
        Set(ByVal value)
            Me.ciudad = value
        End Set
    End Property
    Public Property nitCliente()
        Get
            Return nit
        End Get
        Set(ByVal value)
            Me.nit = value
        End Set
    End Property
    Public Property nombresC()
        Get
            Return nombres
        End Get
        Set(ByVal value)
            Me.nombres = value
        End Set
    End Property
    Public Property fechaCreacionC()
        Get
            Return fechaCreacion
        End Get
        Set(ByVal value)
            Me.fechaCreacion = value
        End Set
    End Property
    Public Property condicionC()
        Get
            Return condicion
        End Get
        Set(ByVal value)
            Me.condicion = value
        End Set
    End Property
    Public Property bloqueoC()
        Get
            Return bloqueo
        End Get
        Set(ByVal value)
            Me.bloqueo = value
        End Set
    End Property
    Public Property contacto1C()
        Get
            Return contacto1
        End Get
        Set(ByVal value)
            If IsDBNull(value) Then
            Else
                Me.contacto1 = value
            End If
        End Set
    End Property
    Public Property cupoC()
        Get
            Return cupo
        End Get
        Set(ByVal value)
            Me.cupo = CInt(value)
        End Set
    End Property
    Public Property chequeDevueltoC()
        Get
            Return chequeDevuelto
        End Get
        Set(ByVal value)
            Me.chequeDevuelto = value
        End Set
    End Property
    Public Property saldoVenC()
        Get
            Return saldoVen
        End Get
        Set(ByVal value)
            Me.saldoVen = CInt(value)
        End Set
    End Property
    Public Property saldoSinC()
        Get
            Return saldoSin
        End Get
        Set(ByVal value)
            Me.saldoSin = CInt(value)
        End Set
    End Property
    Public Property saldoTotC()
        Get
            Return saldoTot
        End Get
        Set(ByVal value)
            Me.saldoTot = CInt(value)
        End Set
    End Property
    Public Property cupoMas30C()
        Get
            Return cupoMas30
        End Get
        Set(ByVal value)
            Me.cupoMas30 = CInt(value)
        End Set
    End Property
    Public Property tel1C()
        Get
            Return tel1
        End Get
        Set(ByVal value)
            Me.tel1 = value
        End Set
    End Property
    Public Property notasTerC()
        Get
            Return notasTer
        End Get
        Set(ByVal value)
            Me.notasTer = value
        End Set
    End Property
    Public Property promDiasPagC()
        Get
            Return promDiasPag
        End Get
        Set(ByVal value)
            Me.promDiasPag = CInt(value)
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
    Public Property autorizaTextoC()
        Get
            Return autorizaTexto
        End Get
        Set(ByVal value)
            If IsDBNull(value) Then
            Else
                Me.autorizaTexto = value
            End If
        End Set
    End Property
    Public Property autorizacionC()
        Get
            Return autorizacion
        End Get
        Set(ByVal value)
            Me.autorizacion = value
        End Set
    End Property
    Public Property direccionC()
        Get
            Return direccion
        End Get
        Set(ByVal value)
            Me.direccion = value
        End Set
    End Property
    Public Property cupoAntC()
        Get
            Return cupoAnt
        End Get
        Set(ByVal value)
            Me.cupoAnt = value
        End Set
    End Property
    Public Property fechaModC()
        Get
            Return fechaMod
        End Get
        Set(ByVal value)
            Me.fechaMod = value
        End Set
    End Property
    Public Property celularC()
        Get
            Return celular
        End Get
        Set(ByVal value)
            If IsDBNull(value) Then
            Else
                Me.celular = value
            End If
        End Set
    End Property
    Public Property mailC()
        Get
            Return mail
        End Get
        Set(ByVal value)
            Me.mail = value
        End Set
    End Property


End Class
