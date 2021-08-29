Imports System.Data.SqlClient
Imports System.Data
Imports System.Data.SqlServerCe
Imports entidadNegocios
Public Class OperacionesDb
    Public Function ExecuteSqlTransaction(ByVal listSql As List(Of Object)) As Boolean
        Dim conn As New SqlConnection
        Dim resp As Boolean = False
        Dim objConexion As New Conexion
        Dim comando As New SqlCommand
        Dim sql As String = ""
        conn = objConexion.abrirConexion
        Dim transaction As SqlTransaction
        transaction = conn.BeginTransaction("Insertar")
        comando.Connection = conn
        comando.Transaction = transaction
        Try

            For i As Integer = 0 To listSql.Count - 1 Step 1
                sql = (listSql(i))
                comando.CommandText = sql
                comando.ExecuteNonQuery()
            Next
            ' Attempt to commit the transaction.
            transaction.Commit()
            resp = True
        Catch ex As Exception
            Console.WriteLine("Commit Exception Type: {0}", ex.GetType())
            MsgBox("  Message: {0}" & ex.Message)

            Try
                transaction.Rollback()

            Catch ex2 As Exception
                Console.WriteLine("Rollback Exception Type: {0}", ex2.GetType())
                Console.WriteLine("  Message: {0}", ex2.Message)
            End Try
        End Try
        conn.Close()
        Return resp
    End Function
    Public Function ExecuteSqlTransactionTodo(ByVal listSql As List(Of Object), ByVal db As String) As Boolean
        Dim conn As New SqlConnection
        Dim resp As Boolean = False
        Dim objConexion As New Conexion
        Dim comando As New SqlCommand
        Dim sql As String = ""
        If (db = "CORSAN") Then
            conn = objConexion.abrirConexion
        ElseIf (db = "PRODUCCION") Then
            conn = objConexion.abrirConexion_prod
        ElseIf (db = "CONTROL") Then
            conn = objConexion.abrirConexionControl
        End If
        Dim transaction As SqlTransaction
        transaction = conn.BeginTransaction("Insertar")
        comando.Connection = conn
        comando.Transaction = transaction
        Try

            For i As Integer = 0 To listSql.Count - 1 Step 1
                sql = (listSql(i))
                comando.CommandText = sql
                comando.ExecuteNonQuery()
            Next
            ' Attempt to commit the transaction.
            transaction.Commit()
            resp = True
        Catch ex As Exception
            Console.WriteLine("Commit Exception Type: {0}", ex.GetType())
            MsgBox("  Message: {0}" & ex.Message)

            Try
                transaction.Rollback()

            Catch ex2 As Exception
                Console.WriteLine("Rollback Exception Type: {0}", ex2.GetType())
                Console.WriteLine("  Message: {0}", ex2.Message)
            End Try
        End Try
        conn.Close()
        Return resp
    End Function
    Public Function consultValor(ByVal sql As String, ByVal db As String) As String
        Dim resp As String = ""
        Dim comando As New System.Data.SqlClient.SqlCommand
        Dim conn As New SqlConnection
        Dim objConexion As New Conexion
        comando = New SqlCommand
        Dim i As Integer = 0
        Dim reader As SqlDataReader
        comando.CommandType = CommandType.Text
        If (db = "CORSAN") Then
            conn = objConexion.abrirConexion
        ElseIf (db = "PRODUCCION") Then
            conn = objConexion.abrirConexion_prod
        End If
        comando.Connection = conn
        comando.CommandText = (sql)
        reader = comando.ExecuteReader
        While (reader.Read)
            If Not IsDBNull(reader(0)) Then
                resp = reader(0)
            End If
        End While
        conn.Close()
        Return resp
    End Function
    Public Function ExecuteSqlTransactionProduccion(ByVal listSql As List(Of Object)) As Boolean
        Dim conn As New SqlConnection
        Dim resp As Boolean = False
        Dim objConexion As New Conexion
        Dim comando As New SqlCommand
        Dim sql As String = ""
        conn = objConexion.abrirConexion_prod
        Dim transaction As SqlTransaction
        transaction = conn.BeginTransaction("Insertar")
        comando.Connection = conn
        comando.Transaction = transaction
        Try

            For i As Integer = 0 To listSql.Count - 1 Step 1
                sql = (listSql(i))
                comando.CommandText = sql
                comando.ExecuteNonQuery()
            Next
            ' Attempt to commit the transaction.
            transaction.Commit()
            resp = True
        Catch ex As Exception
            Console.WriteLine("Commit Exception Type: {0}", ex.GetType())
            MsgBox("  Message: {0}" & ex.Message)

            Try
                transaction.Rollback()

            Catch ex2 As Exception
                Console.WriteLine("Rollback Exception Type: {0}", ex2.GetType())
                Console.WriteLine("  Message: {0}", ex2.Message)
            End Try
        End Try
        conn.Close()
        Return resp
    End Function
    Public Function ejecutar(ByVal Sql As String, ByVal db As String) As Integer
        Dim conn As New SqlConnection
        Dim resp As Integer = 0
        Try
            Dim objConexion As New Conexion
            Dim comando1 As New System.Data.SqlClient.SqlCommand
            If (db = "CORSAN") Then
                conn = objConexion.abrirConexion
            ElseIf (db = "PRODUCCION") Then
                conn = objConexion.abrirConexion_prod
            End If
            comando1.CommandType = System.Data.CommandType.Text
            comando1.Connection = conn
            comando1.CommandText = Sql
            resp = (comando1.ExecuteNonQuery())
        Catch ex As Exception
            MsgBox(ex.Message.ToString & "error")
        Finally

        End Try
        conn.Close()
        Return resp
    End Function
    Public Function return_objReferenciaEn(ByVal codigo As String) As ReferenciaEn
        Dim objReferenciaEn As New ReferenciaEn
        Dim sql As String = "SELECT  codigo,descripcion,valor_unitario,costo_unitario " & _
                                    "FROM referencias " & _
                                "WHERE codigo = '" & codigo & "'"
        Dim objConexion As New Conexion
        Dim reader As SqlDataReader
        Dim comando As New SqlCommand
        Dim conn As New SqlConnection
        comando.CommandType = CommandType.Text
        conn = objConexion.abrirConexion
        comando.Connection = conn
        comando.CommandText = (sql)
        reader = comando.ExecuteReader
        If (reader.Read) Then
            objReferenciaEn.codigo = reader("codigo")
            objReferenciaEn.descripcion = reader("descripcion")
            objReferenciaEn.valor_unitario = reader("valor_unitario")
            objReferenciaEn.costo_unitario = reader("costo_unitario")
        End If
        conn.Close()
        Return objReferenciaEn
    End Function
End Class
