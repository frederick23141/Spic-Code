Public Class Procedimiento_detEn
    Private _responsable As String
    Private _descripcion As String
    Private _id_subproc As String
    Private _id As String
    Public Property id()
        Get
            Return _id
        End Get
        Set(ByVal value)
            Me._id = value
        End Set
    End Property
    Public Property id_subproc()
        Get
            Return _id_subproc
        End Get
        Set(ByVal value)
            Me._id_subproc = value
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
    Public Property responsable()
        Get
            Return _responsable
        End Get
        Set(ByVal value)
            Me._responsable = value
        End Set
    End Property
End Class
