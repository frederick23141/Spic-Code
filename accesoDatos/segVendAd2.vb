Imports System.Data.SqlClient
Imports System.Data
Public Class segVendAd2
    Private Function listarSeg(ByVal vend As Integer, ByVal mes As Integer, ByVal ano As Integer, ByVal inter As Boolean) As DataTable
        Dim conn As New SqlConnection
        Dim comando As New SqlCommand
        Dim objConexion As New Conexion
        Dim dt As New DataTable
        Dim sql As String = ""
        Dim listaVend As New List(Of Object)
        If (vend <> 1020) Then
        Else
            listaVend.Add(vend)
        End If
        Return dt
    End Function
    Private Function vendedores(ByVal inter As Boolean) As Integer()
        Dim reader As SqlDataReader
        Dim objConexion As New Conexion
        Dim conn As New SqlConnection
        Dim comando As New SqlCommand
        Dim vecVend(99) As Integer
        Dim k As Double = 0
        Dim sSql As String = ""
        comando.CommandType = CommandType.Text
        conn = objConexion.abrirConexion
        comando.Connection = conn
        If (inter) Then
            sSql = "select  vendedor " & _
                    " from v_vendedores " & _
                           "where (vendedor >= 1001) AND (vendedor <= 1099) AND (bloqueo = 0) ORDER BY vendedor"
        Else
            sSql = "select  vendedor " & _
                    " from v_vendedores " & _
                           "where (vendedor >= 1001) AND (vendedor <= 1060) AND (bloqueo = 0) ORDER BY vendedor"
        End If
        comando.CommandText = (sSql)
        reader = comando.ExecuteReader
        While (reader.Read)
            If IsDBNull(reader(0)) Then
            Else
                vecVend(k) = reader(0)
                k = k + 1
            End If
        End While
        conn.Close()
        Return vecVend
    End Function
End Class
