Imports System.Data.SqlClient
Imports System.Data
Imports entidadNegocios
Public Class VotacionesAd
    Public Function formatearVotaciones() As Boolean
        Dim conn As New SqlConnection
        Dim reader As SqlDataReader
        Dim comando As New SqlCommand
        Dim resp As Boolean = True
        Dim objConexion As New Conexion
        Dim sql As String = "select nit,nombres,centro,estado   from Jjv_personal_vot"
        Dim sqlInsert As String = ""
        Dim sqlDelete As String = "DELETE FROM J_votaciones"
        ExecuteSqlTransaction(sqlDelete)
        comando.CommandType = CommandType.Text
        conn = objConexion.abrirConexion
        comando.Connection = conn
        comando.CommandText = sql
        reader = comando.ExecuteReader
        While (reader.Read And resp)
            sqlInsert = "INSERT INTO J_votaciones (id_tercero,puntos,votante) VALUES(" & reader("nit") & ",0,0)"
            If resp Then
                resp = ExecuteSqlTransaction(sqlInsert)
            End If
        End While
        conn.Close()
        reader.Close()
        Return resp
    End Function
    Public Function ExecuteSqlTransaction(ByVal sql As String) As Boolean
        Dim conn As New SqlConnection
        Dim resp As Boolean = False
        Dim objConexion As New Conexion
        Dim comando As New SqlCommand
        conn = objConexion.abrirConexion_prod
        Dim transaction As SqlTransaction
        transaction = conn.BeginTransaction("Insertar")
        comando.Connection = conn
        comando.Transaction = transaction
        Try
            comando.CommandText = sql
            comando.ExecuteNonQuery()
            transaction.Commit()
            resp = True
        Catch ex As Exception
            Console.WriteLine("Commit Exception Type: {0}", ex.GetType())
            Console.WriteLine("  Message: {0}", ex.Message)

            Try
                transaction.Rollback()

            Catch ex2 As Exception
                Console.WriteLine("Rollback Exception Type: {0}", ex2.GetType())
                Console.WriteLine("  Message: {0}", ex2.Message)
            End Try
        End Try
        Return resp
    End Function
    Public Function listar_datatable(ByVal cadena As String) As DataTable
        Dim objConexion As New Conexion
        Dim conn As New SqlConnection
        conn = objConexion.abrirConexion
        Dim dt As New DataTable
        Dim DA As New SqlDataAdapter(cadena, conn)
        DA.Fill(dt)
        conn.Close()
        Return dt
    End Function
    Public Function cargarInfoBasica(ByVal nit As Double) As Object
        Dim objConexion As New Conexion
        Dim reader As SqlDataReader
        Dim vec_usu(1) As Object
        Dim comando As New SqlCommand
        comando.CommandType = CommandType.Text
        Dim conn As New SqlConnection
        conn = objConexion.abrirConexion
        comando.Connection = conn
        Dim sql As String = "select nombres,grupo_vot   from terceros WHERE nit = " & nit & ""
        comando.CommandText = (sql)
        reader = comando.ExecuteReader
        While (reader.Read)
            If IsDBNull(reader(0)) Then
            Else
                vec_usu(0) = reader("nombres")
                vec_usu(1) = reader("grupo_vot")
            End If
        End While
        conn.Close()
        Return vec_usu
    End Function
    Public Function sumarPuntos(ByVal puntos As Integer, ByVal nit As Double) As Integer
        Dim conn As New SqlConnection
        Dim comando As New SqlCommand
        Dim objConexion As New Conexion
        Dim resp As Integer = 0
        conn = objConexion.abrirConexion
        Dim comando1 As New System.Data.SqlClient.SqlCommand
        comando1.CommandType = System.Data.CommandType.Text
        comando1.Connection = conn
        Dim stringSql As String = "UPDATE J_votaciones " & _
                                     "SET puntos = (select puntos from J_votaciones where id_tercero  = " & nit & ")+" & puntos & "	" & _
                                            "WHERE id_tercero = " & nit & ""
        comando1.CommandText = stringSql
        resp = comando1.ExecuteNonQuery()
        conn.Close()
        Return resp
    End Function
    Public Function verificarVotante(ByVal nit As Double) As Integer
        Dim objConexion As New Conexion
        Dim resp As Boolean = True
        Dim reader As SqlDataReader
        Dim comando As New SqlCommand
        comando.CommandType = CommandType.Text
        Dim conn As New SqlConnection
        conn = objConexion.abrirConexion
        comando.Connection = conn
        Dim sql As String = "SELECT * FROM J_votaciones WHERE id_tercero = " & nit & " AND votante =1"
        comando.CommandText = (sql)
        reader = comando.ExecuteReader
        If (reader.Read) Then
            resp = False
        End If
        conn.Close()
        Return resp
    End Function
    Public Function marcarVotante(ByVal nit As Double) As Integer
        Dim conn As New SqlConnection
        Dim comando As New SqlCommand
        Dim objConexion As New Conexion
        Dim resp As Integer = 0
        conn = objConexion.abrirConexion
        Dim comando1 As New System.Data.SqlClient.SqlCommand
        comando1.CommandType = System.Data.CommandType.Text
        comando1.Connection = conn
        Dim stringSql As String = "UPDATE J_votaciones " & _
                                     "SET votante = 1	" & _
                                            "WHERE id_tercero = " & nit & ""
        comando1.CommandText = stringSql
        resp = comando1.ExecuteNonQuery()
        conn.Close()
        Return resp
    End Function
    Public Function ejecutar(ByVal sql As String) As Integer
        Dim conn As New SqlConnection
        Dim comando As New SqlCommand
        Dim objConexion As New Conexion
        Dim resp As Integer = 0
        conn = objConexion.abrirConexion
        Dim comando1 As New System.Data.SqlClient.SqlCommand
        comando1.CommandType = System.Data.CommandType.Text
        comando1.Connection = conn
        comando1.CommandText = sql
        resp = comando1.ExecuteNonQuery()
        conn.Close()
        Return resp
    End Function

End Class
