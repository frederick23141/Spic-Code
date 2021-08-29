Imports System.Data.SqlClient
Imports System.Data
Public Class Conexion
    'Se establece la conexión con la base de datos
    Public Function abrirConexion() As SqlConnection
        Dim sConexion As String = "Data Source=SST;Initial Catalog=CORSAN;Integrated Security=True"
        Dim conConexion As New SqlConnection()
        Try
            conConexion = New SqlConnection(sConexion)
            conConexion.Open()
            If conConexion.State = ConnectionState.Open Then
                'MsgBox("Conexion exitosa")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return conConexion
    End Function
    Public Function abrirConexion2() As SqlConnection
        Dim sConexion As String = "Data Source=SST;Initial Catalog=CORSAN;Integrated Security=True"
        Dim conConexion As New SqlConnection()
        conConexion = New SqlConnection(sConexion)
        conConexion.Open()
        If conConexion.State = ConnectionState.Open Then
            'MsgBox("Conexion exitosa")
        End If
        Return conConexion
    End Function
    Public Function abrirConexion3() As SqlConnection
        Dim sConexion As String = "Data Source=SST;Initial Catalog=CORSAN;Integrated Security=True"
        Dim conConexion As New SqlConnection()
        conConexion = New SqlConnection(sConexion)
        conConexion.Open()
        If conConexion.State = ConnectionState.Open Then
            'MsgBox("Conexion exitosa")
        End If
        Return conConexion
    End Function
End Class
