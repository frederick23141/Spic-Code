Imports System.Data.SqlClient
Imports System.Data
Imports entidadNegocios
Imports System.Data.SqlServerCe
Public Class QuejaRecAd
    Public Function listar_datatable(ByVal cadena As String) As DataTable
        Dim conn As New SqlConnection
        Dim objConexion As New Conexion
        conn = objConexion.abrirConexion
        Dim dt As New DataTable
        Dim DA As New SqlDataAdapter(cadena, conn)
        DA.Fill(dt)
        conn.Close()
        Return dt
    End Function
    Public Function ejecutar(ByVal Sql As String) As Integer
        Dim resp As Integer = 0
        Dim conn As New SqlConnection
        Try
            Dim objConexion As New Conexion
            Dim comando1 As New System.Data.SqlClient.SqlCommand
            conn = objConexion.abrirConexion
            comando1.CommandType = System.Data.CommandType.Text
            comando1.Connection = conn
            comando1.CommandText = Sql
            resp = (comando1.ExecuteNonQuery())
        Catch ex As Exception
            MsgBox(ex.Message.ToString & "error ejecutar QuejaRecAd")
        Finally

        End Try
        conn.Close()
        Return resp
    End Function
    Public Function listar_vector(ByVal sql As String, ByVal numCol As Integer) As Object(,)
        Dim listaCodigo As New List(Of Object)
        Dim tam As Integer = consulTam(sql)
        If (tam >= 1) Then
            tam -= 1
        End If
        Dim codigos As String = ""
        Dim mat(tam, numCol) As Object
        Dim comando As New System.Data.SqlClient.SqlCommand
        Dim conn As New SqlConnection
        Dim objConexion As New Conexion
        comando = New SqlCommand
        Dim i As Integer = 0
        Dim reader As SqlDataReader
        comando.CommandType = CommandType.Text
        conn = objConexion.abrirConexion
        comando.Connection = conn
        comando.CommandText = (sql)
        reader = comando.ExecuteReader
        While (reader.Read)
            If Not IsDBNull(reader(0)) Then
                mat(i, 0) = reader(0)
                mat(i, 1) = reader(1)
                mat(i, 2) = reader(2)
                mat(i, 3) = reader(3)
                mat(i, 4) = reader(4)
                mat(i, 5) = reader(5)
                mat(i, 6) = reader(6)
                mat(i, 7) = reader(7)
                mat(i, 8) = reader(8)
                mat(i, 9) = reader(9)
                mat(i, 10) = reader(10)
                mat(i, 11) = reader(11)
                mat(i, 12) = reader(12)
                mat(i, 13) = reader(13)
                mat(i, 14) = reader(14)
                mat(i, 15) = reader(15)
                mat(i, 16) = reader(16)
                mat(i, 17) = reader(17)
                mat(i, 18) = reader(18)
                listaCodigo = listarCodigo(reader(0))
                For j = 0 To listaCodigo.Count - 1
                    codigos += listaCodigo(j) & "-"
                    If (j <> listaCodigo.Count - 1) Then
                        codigos += vbCrLf
                    End If
                Next
                mat(i, 19) = codigos
                mat(i, 20) = reader(19)
                mat(i, 21) = reader(20)
                mat(i, 22) = reader(21)
                codigos = ""
                i += 1
            End If
        End While
        conn.Close()
        Return mat
    End Function
    Public Function listarCodigo(ByVal idQueja As Integer) As List(Of Object)
        Dim listaCodigo As New List(Of Object)
        Dim sql As String = "SELECT codigo FROM J_quejas_rec_det WHERE idQuejaRec = " & idQueja
        Dim comando As New System.Data.SqlClient.SqlCommand
        Dim conn As New SqlConnection
        Dim objConexion As New Conexion
        comando = New SqlCommand
        Dim i As Integer = 0
        Dim reader As SqlDataReader
        comando.CommandType = CommandType.Text
        conn = objConexion.abrirConexion
        comando.Connection = conn
        comando.CommandText = (sql)
        reader = comando.ExecuteReader
        While (reader.Read)
            If Not IsDBNull(reader(0)) Then
                listaCodigo.Add(reader(0))
                i += 1
            End If
        End While
        conn.Close()
        Return listaCodigo
    End Function
    Public Function listar_vector_maestros(ByVal sql As String, ByVal numCol As Integer) As Object(,)
        Dim tam As Integer = consulTam(sql)
        tam = consulTam(sql)
        If (tam >= 1) Then
            tam -= 1
        End If
        Dim mat(tam, numCol) As Object
        Dim comando As New System.Data.SqlClient.SqlCommand
        Dim conn As New SqlConnection
        Dim objConexion As New Conexion
        comando = New SqlCommand
        Dim i As Integer = 0
        Dim reader As SqlDataReader
        comando.CommandType = CommandType.Text
        conn = objConexion.abrirConexion
        comando.Connection = conn
        comando.CommandText = (sql)
        reader = comando.ExecuteReader
        While (reader.Read)
            If Not IsDBNull(reader(0)) Then
                mat(i, 0) = reader(0)
                mat(i, 1) = reader(1)
                If (numCol = 3) Then
                    mat(i, 2) = reader(2)
                End If

                i += 1
            End If
        End While
        conn.Close()
        Return mat
    End Function
    Private Function consulTam(ByVal sql As String) As Integer
        Dim tam As Integer = 0
        Dim comando As New System.Data.SqlClient.SqlCommand
        Dim conn As New SqlConnection
        Dim objConexion As New Conexion
        comando = New SqlCommand
        Dim i As Integer = 0
        Dim reader As SqlDataReader
        comando.CommandType = CommandType.Text
        conn = objConexion.abrirConexion
        comando.Connection = conn
        comando.CommandText = (sql)
        reader = comando.ExecuteReader
        While (reader.Read)
            If Not IsDBNull(reader(0)) Then
                tam += 1
            End If
        End While
        conn.Close()
        Return tam
    End Function
    Public Function existeReg(ByVal sql As String) As Boolean
        Dim comando As New System.Data.SqlClient.SqlCommand
        Dim conn As New SqlConnection
        Dim resp As Boolean = False
        Dim objConexion As New Conexion
        comando = New SqlCommand
        Dim i As Integer = 0
        Dim reader As SqlDataReader
        comando.CommandType = CommandType.Text
        conn = objConexion.abrirConexion
        comando.Connection = conn
        comando.CommandText = (sql)
        reader = comando.ExecuteReader
        If (reader.Read) Then
            If Not IsDBNull(reader(0)) Then
                resp = True
            End If
        End If
        conn.Close()
        Return resp
    End Function
    Public Function genConsect(ByVal sql As String) As Double
        Dim comando As New System.Data.SqlClient.SqlCommand
        Dim conn As New SqlConnection
        Dim resp As Double = 0
        Dim objConexion As New Conexion
        comando = New SqlCommand
        Dim i As Integer = 0
        Dim reader As SqlDataReader
        comando.CommandType = CommandType.Text
        conn = objConexion.abrirConexion
        comando.Connection = conn
        comando.CommandText = (sql)
        reader = comando.ExecuteReader
        If (reader.Read) Then
            If Not IsDBNull(reader(0)) Then
                resp = reader(0) + 1
            End If
        End If
        conn.Close()
        Return resp
    End Function
    Public Function consultValor(ByVal sql As String) As String
        Dim resp As String = ""
        Dim comando As New System.Data.SqlClient.SqlCommand
        Dim conn As New SqlConnection
        Dim objConexion As New Conexion
        comando = New SqlCommand
        Dim i As Integer = 0
        Dim reader As SqlDataReader
        comando.CommandType = CommandType.Text
        conn = objConexion.abrirConexion
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

    Public Function mat_quejas(ByVal sql As String) As Object(,)
        Dim tamano As Integer = consulTam(sql) / 2
        Dim mat(tamano, 1) As Object
        Dim conn As New SqlConnection
        Dim objConexion As New Conexion
        Dim comando As New SqlCommand
        Dim resp As Double = 0
        Dim reader As SqlDataReader
        conn = objConexion.abrirConexion_prod
        comando.Connection = conn
        comando.CommandType = CommandType.Text
        comando.CommandText = (sql)
        reader = comando.ExecuteReader
        Dim i As Integer
        If reader.Read Then
            If IsDBNull(reader(0)) Then
                mat(i, 0) = reader(0)
                mat(i, 1) = reader(1)
                i += 1
            End If
        End If
        conn.Close()
        Return mat
    End Function
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
                Sql = (listSql(i))
                comando.CommandText = Sql
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

End Class
