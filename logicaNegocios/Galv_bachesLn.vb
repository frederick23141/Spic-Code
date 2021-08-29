Imports accesoDatos
Public Class Galv_bachesLn
    Dim ObjX As New OperacionesDb
    Public Function CrearId() As Int64
        Dim id As String = ObjX.consultValor("SELECT MAX(id) FROM [Seguimiento tornillos]", "PRODUCCION")
        If (id = "") Then
            Return 1
        Else
            Return (Convert.ToInt64(id) + 1)
        End If
    End Function
    Public Function guardarTodo(ByVal listSql As List(Of Object)) As Boolean
        Return ObjX.ExecuteSqlTransactionProduccion(listSql)
    End Function

    Public Function Ejecutar(ByVal sql As String, ByVal db As String)
        Return ObjX.ejecutar(sql, db)
    End Function
End Class
