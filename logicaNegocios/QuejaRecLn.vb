Imports accesoDatos
Public Class QuejaRecLn
    Private objQuejaRecAd As New QuejaRecAd
    Public Function ejecutar(ByVal Sql As String) As Integer
        Return objQuejaRecAd.ejecutar(Sql)
    End Function
    Public Function listar_datatable(ByVal cadena As String) As DataTable
        Return objQuejaRecAd.listar_datatable(cadena)
    End Function
    Public Function listar_vector(ByVal sql As String, ByVal numCol As Integer) As Object(,)
        Return objQuejaRecAd.listar_vector(sql, numCol)
    End Function
    Public Function existeReg(ByVal sql As String) As Boolean
        Return objQuejaRecAd.existeReg(sql)
    End Function
    Public Function genConsect(ByVal sql As String) As Double
        Return objQuejaRecAd.genConsect(sql)
    End Function
    Public Function consultValor(ByVal sql As String) As String
        Return objQuejaRecAd.consultValor(sql)
    End Function
    Public Function listar_vector_maestros(ByVal sql As String, ByVal numCol As Integer) As Object(,)
        Return objQuejaRecAd.listar_vector_maestros(sql, numCol)
    End Function
    Public Function mat_quejas(ByVal sql As String) As Object(,)
        Return objQuejaRecAd.mat_quejas(sql)
    End Function
    Public Function ExecuteSqlTransaction(ByVal listSql As List(Of Object)) As Boolean
        Return objQuejaRecAd.ExecuteSqlTransaction(listSql)
    End Function
    Public Function listarCodigo(ByVal idQueja As Integer) As List(Of Object)
        Return objQuejaRecAd.listarCodigo(idQueja)
    End Function

End Class
