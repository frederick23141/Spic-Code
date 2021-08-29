Public Class Clas_provEn
    Private _puntaje As String
    Private _descripcion As String
    Private _calificacion As String
    Private _calificacion_real As String
    Public Property calificacion_real()
        Get
            Return _calificacion_real
        End Get
        Set(ByVal value)
            Me._calificacion_real = value
        End Set
    End Property
    Public Property calificacion()
        Get
            Return _calificacion
        End Get
        Set(ByVal value)
            Me._calificacion = value
        End Set
    End Property
    Public Property descripcion()
        Get
            Return _descripcion
        End Get
        Set(ByVal value)
            Me._descripcion = value
        End Set
    End Property
    Public Property puntaje()
        Get
            Return _puntaje
        End Get
        Set(ByVal value)
            Me._puntaje = value
        End Set
    End Property
End Class
