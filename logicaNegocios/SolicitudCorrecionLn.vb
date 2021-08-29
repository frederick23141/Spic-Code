Imports accesoDatos
Public Class SolicitudCorrecionLn
    Dim ObjX As New OperacionesDb
    Public Function Consultar(ByVal sql As String) As Integer
        Return ObjX.consultValor(sql, "PRODUCCION")
    End Function

    Public Function CrearId() As Int64
        Dim id As String = ObjX.consultValor("SELECT MAX(id_Solicitud) FROM b_Solicitud_Correcion", "PRODUCCION")
        If (id = "") Then
            Return 1
        Else
            Return (Convert.ToInt64(id) + 1)
        End If
    End Function
    Public Function guardarTodo(ByVal listSql As List(Of Object)) As Boolean
        Return ObjX.ExecuteSqlTransactionProduccion(listSql)
    End Function
End Class
