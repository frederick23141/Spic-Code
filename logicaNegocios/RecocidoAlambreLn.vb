Imports accesoDatos

Public Class RecocidoAlambreLn

#Region "Atributos"
    Private objOpDb As New OperacionesDb
    Private obj_op_simplesAd As New Op_simplesAd
#End Region

#Region "Metodos Publicos"
    Public Function sqlInsertPpal(ByVal CodOrden As String, ByVal FechaI As String, ByVal Codigos As String, ByVal KG As Integer, ByVal Base As String, ByVal Sostenimiento As String, ByVal Temperatura As String, ByVal HoraInicio As String, ByVal HoraFinal As String, ByVal PCarga As String, ByVal POpera As String, ByVal PDescarga As String, ByVal Traccion As String, ByVal TiempoDes As String)
        Return "INSERT INTO b_Orden_Recocido VALUES('" & CodOrden & "','" & FechaI & "','" & Codigos & "','" & KG & "','" & Base & "','" & Sostenimiento & "', '" & Temperatura & "', '" & Traccion & "', '" & HoraInicio & "','" & HoraFinal & "','" & TiempoDes & "','" & PCarga & "','" & POpera & "', '" & PDescarga & "')"
    End Function

    Public Function guardarTodo(ByVal listSql As List(Of Object)) As Boolean
        Return objOpDb.ExecuteSqlTransactionProduccion(listSql)
    End Function

    Public Function validarNumero(ByVal numero As String) As Boolean
        If (numero <> "") Then
            If (Not IsNumeric(numero)) Then
                Return False
            End If
        End If
        Return True
    End Function
#End Region

End Class
