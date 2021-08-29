Public Class CriteriosEvaluacionEn
    Private _factor As String
    Private _criterio As String
    Private _puntaje_maximo As String
    Private _puntaje As String

    Public Property puntaje()
        Get
            Return _puntaje
        End Get
        Set(ByVal value)
            Me._puntaje = value
        End Set
    End Property
    Public Property puntaje_maximo()
        Get
            Return _puntaje_maximo
        End Get
        Set(ByVal value)
            Me._puntaje_maximo = value
        End Set
    End Property
    Public Property criterio()
        Get
            Return _criterio
        End Get
        Set(ByVal value)
            Me._criterio = value
        End Set
    End Property
    Public Property factor()
        Get
            Return _factor
        End Get
        Set(ByVal value)
            Me._factor = value
        End Set
    End Property
End Class
