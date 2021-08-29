Imports accesoDatos
Public Class TocLn
    Private obj_tocAd As New TocAd
    Public Function ExecuteSqlTransaction(ByVal mat(,) As Object, ByVal filas As Integer) As Boolean
        Return obj_tocAd.ExecuteSqlTransaction(mat, filas)
    End Function
    Public Function toc_detallado() As DataTable
        Return obj_tocAd.toc_detallado()
    End Function
End Class
