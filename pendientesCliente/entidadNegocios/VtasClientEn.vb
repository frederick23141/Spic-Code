Public Class VtasClientEn

    Private sCiudad As String
    Private sNit As Double
    Private sNombres As String
    Private sCodigo As String
    Private sDescipcion As String
    Private sCant As Double
    Private sKilos As Double
    Private sValtot As Double
    Private sVrUni As Double
    Private sVrKilo As Double
    Public Property Ciudad()
        Get
            Return sCiudad
        End Get
        Set(ByVal value)
            If (IsDBNull(value)) Then
            Else
                Me.sCiudad = value
            End If

        End Set
    End Property
    Public Property Nit()
        Get
            Return sNit
        End Get
        Set(ByVal value)
            Me.sNit = value
        End Set
    End Property
    Public Property Nombres()
        Get
            Return sNombres
        End Get
        Set(ByVal value)
            If (IsDBNull(value)) Then
            Else
                Me.sNombres = value
            End If

        End Set
    End Property
    Public Property Codigo()
        Get
            Return sCodigo
        End Get
        Set(ByVal value)
            Me.sCodigo = value
        End Set
    End Property
    Public Property Descripcion()
        Get
            Return sDescipcion
        End Get
        Set(ByVal value)
            Me.sDescipcion = value
        End Set
    End Property
    Public Property Cantidad()
        Get
            Return sCant
        End Get
        Set(ByVal value)
            Me.sCant = value
        End Set
    End Property
    Public Property Kilos()
        Get
            Return sKilos
        End Get
        Set(ByVal value)
            If IsDBNull(value) Then
            Else
                Me.sKilos = value
            End If
        End Set
    End Property
    Public Property Vr_Tot()
        Get
            Return sValtot
        End Get
        Set(ByVal value)
            Me.sValtot = value
        End Set
    End Property
    Public Property Vr_unit()
        Get
            Return sVrUni
        End Get
        Set(ByVal value)
            Me.sVrUni = value
        End Set
    End Property

    Public Property Vr_Kilo()
        Get
            Return sVrKilo
        End Get
        Set(ByVal value)
            Me.sVrKilo = value
        End Set
    End Property

End Class

