Imports System.Data.SqlClient
Imports System.Data
Imports entidadNegocios
Public Class Vtas_vend_ciudAd
    Public Function listar_vtas_lin_ciud(ByVal sql As String) As DataTable
        Dim conn As New SqlConnection
        Dim objConexion As New Conexion
        conn = objConexion.abrirConexion
        Dim dt As New DataTable
        Dim DA As New SqlDataAdapter(sql, conn)
        DA.Fill(dt)
        conn.Close()
        Return dt
    End Function
    Public Function listar_cbo(ByVal cadena As String) As DataTable

        Dim objConexion As New Conexion
        Dim conn As New SqlConnection
        conn = objConexion.abrirConexion
        Dim dt As New DataTable
        Dim DA As New SqlDataAdapter(cadena, conn)
        DA.Fill(dt)
        conn.Close()
        Return dt
    End Function
    Public Function listar_id_cor() As String(,)
        Dim conn As New SqlConnection
        Dim i As Integer = 0
        Dim reader As SqlDataReader
        Dim comando As New SqlCommand
        Dim objConexion As New Conexion
        Dim mat(40, 2) As String
        comando.CommandType = CommandType.Text
        conn = objConexion.abrirConexion
        comando.Connection = conn
        comando.CommandText = "select Id_cor,Descripcion   from JJV_Grupos_seguimiento ORDER BY id_cor"
        reader = comando.ExecuteReader
        While (reader.Read)
            mat(i, 0) = reader("id_cor")
            mat(i, 1) = reader("Descripcion")
            i += 1
        End While
        mat(i, 0) = -1
        mat(i, 1) = "TODOS"
        conn.Close()
        Return mat
    End Function
    Public Function listar_dptos() As String(,)
        Dim conn As New SqlConnection
        Dim i As Integer = 0
        Dim reader As SqlDataReader
        Dim comando As New SqlCommand
        Dim objConexion As New Conexion
        Dim mat(60, 2) As String
        comando.CommandType = CommandType.Text
        conn = objConexion.abrirConexion
        comando.Connection = conn
        comando.CommandText = "SELECT  departamento ,descripcion " & _
                                 "FROM y_departamentos " & _
                                    "ORDER BY descripcion"
        reader = comando.ExecuteReader
        While (reader.Read)
            mat(i, 0) = reader("departamento")
            mat(i, 1) = reader("descripcion")
            i += 1
        End While
        mat(i, 0) = -1
        mat(i, 1) = "TODOS"
        conn.Close()
        Return mat
    End Function

    Public Function listar_ciudad(ByVal dpto As Integer) As String(,)
        Dim conn As New SqlConnection
        Dim sql_cont As String = ""
        Dim sql As String = ""
        Dim i As Integer = 0
        Dim reader As SqlDataReader
        Dim comando As New SqlCommand
        Dim objConexion As New Conexion
        If (dpto = "todos") Then
            sql_cont = "SELECT  COUNT(ciudad) FROM y_ciudades"
            sql = "SELECT  ciudad  ,descripcion " & _
                                "FROM(y_ciudades) " & _
                                     "order by descripcion "
        Else
            sql_cont = "SELECT  COUNT(ciudad) FROM y_ciudades WHERE departamento = " & dpto & ""
            sql = "SELECT  ciudad  ,descripcion " & _
                                "FROM(y_ciudades) " & _
                                      "WHERE descripcion = " & dpto & " " & _
                                         "order by descripcion "
        End If
        Dim cant As Double = tamano(sql_cont)
        Dim mat(cant, 2) As String

        comando.CommandType = CommandType.Text
        conn = objConexion.abrirConexion
        comando.Connection = conn
        comando.CommandText = "SELECT  ciudad  ,descripcion " & _
                                "FROM(y_ciudades) " & _
                                     "order by descripcion "
        reader = comando.ExecuteReader
        While (reader.Read)
            mat(i, 0) = reader("ciudad")
            mat(i, 1) = reader("descripcion")
            i += 1
        End While
        mat(i, 0) = -1
        mat(i, 1) = "TODOS"
        conn.Close()
        Return mat
    End Function
    Public Function tamano(ByVal sql As String) As Double
        Dim conn As New SqlConnection
        Dim reader As SqlDataReader
        Dim comando As New SqlCommand
        Dim objConexion As New Conexion
        Dim cont As Double = 0
        comando.CommandType = CommandType.Text
        conn = objConexion.abrirConexion
        comando.Connection = conn
        comando.CommandText = sql
        reader = comando.ExecuteReader
        If (reader.Read) Then
            cont = reader(0)
        End If

        Return cont
    End Function
End Class
