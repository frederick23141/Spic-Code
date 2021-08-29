Public Class EstClienDatosEn
    Private Svendedor As Integer
    Private Snit As Integer
    Private Snombres As String
    Private Sciudad As String
    Private Scondicion As Integer
    Private Sbloqueo As Integer
    Private Scupo As Double
    Private SclasCor As Double
    Private SpromKilos As Double
    Private SpromVrTot As Double
    Private SpromPago As Double
    Public Property Vendedor()
        Get
            Return Svendedor
        End Get
        Set(ByVal value)
            Me.Svendedor = value
        End Set
    End Property
    Public Property Nit()
        Get
            Return Snit
        End Get
        Set(ByVal value)
            Me.Snit = value
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
    Public Property Ciudad()
        Get
            Return Sciudad
        End Get
        Set(ByVal value)
            If IsDBNull(value) Then
            Else
                Me.Sciudad = value
            End If

        End Set
    End Property
    Public Property Condicion()
        Get
            Return Scondicion
        End Get
        Set(ByVal value)
            Me.Scondicion = value
        End Set
    End Property
    Public Property Bloqueo()
        Get
            Return Sbloqueo
        End Get
        Set(ByVal value)
            Me.Sbloqueo = value
        End Set
    End Property
    Public Property Cupo()
        Get
            Return Scupo
        End Get
        Set(ByVal value)
            Me.Scupo = value
        End Set
    End Property
    Public Property Clas_cor()
        Get
            Return SclasCor
        End Get
        Set(ByVal value)
            If IsDBNull(value) Then
            Else
                Me.SclasCor = value
            End If

        End Set
    End Property
    Public Property PromKilos()
        Get
            Return SpromKilos
        End Get
        Set(ByVal value)
            If IsDBNull(value) Then
            Else
                Me.SpromKilos = value
            End If

        End Set
    End Property
    Public Property PromVrTot()
        Get
            Return SpromVrTot
        End Get
        Set(ByVal value)
            If IsDBNull(value) Then
            Else
                Me.SpromVrTot = value
            End If

        End Set
    End Property
    Public Property PromPago()
        Get
            Return SpromPago
        End Get
        Set(ByVal value)
            If IsDBNull(value) Then
            Else
                Me.SpromPago = value
            End If

        End Set
    End Property


End Class
