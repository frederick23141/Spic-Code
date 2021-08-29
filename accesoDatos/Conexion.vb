Imports System.Data.SqlClient
Imports System.Data
Public Class Conexion
    Public Property CommandTimeout As Integer
    Public Function abrirConexion() As SqlConnection
        'Dim sConexion As String = "Data Source=S11;Initial Catalog=JJVDMSCORSANPUAS;Integrated Security=True; LANGUAGE=English"
        Dim sConexion As String = "Data Source=S11;Initial Catalog=CORSAN;Integrated Security=True; LANGUAGE=English"
        ' Dim sConexion As String = "Data Source=SST;Initial Catalog=jjvdmscontabili;Integrated Security=True;"
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
    Public Function abrirConexion_prod() As SqlConnection
        'Dim sConexion As String = "Data Source=S11;Initial Catalog=JJVPRGPRODUCCION;Integrated Security=True"
        Dim sConexion As String = "Data Source=S11;Initial Catalog=PRGPRODUCCION;Integrated Security=True"
        Dim conConexion As New SqlConnection()
        Try
            conConexion = New SqlConnection(sConexion)
            conConexion.Open()
            If conConexion.State = ConnectionState.Open Then
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return conConexion
    End Function
    Public Function abrirConexionControl() As SqlConnection
        'Dim sConexion As String = "Data Source=S11;Initial Catalog=JJVCONTROL;Integrated Security=True"
        Dim sConexion As String = "Data Source=S11;Initial Catalog=CONTROL;Integrated Security=True"
        Dim conConexion As New SqlConnection()
        conConexion = New SqlConnection(sConexion)
        conConexion.Open()
        If conConexion.State = ConnectionState.Open Then
            'MsgBox("Conexion exitosa")
        End If
        Return conConexion
    End Function
    Public Function verificarConexion() As Boolean
        Try
            'Dim sConexion As String = "Data Source=S11;Initial Catalog=JJVCONTROL;Integrated Security=True"
            Dim sConexion As String = "Data Source=S11;Initial Catalog=CONTROL;Integrated Security=True"

            Dim conConexion As New SqlConnection()
            conConexion = New SqlConnection(sConexion)
            conConexion.Open()
            conConexion.Close()
            Return True
        Catch
            Return False
        End Try
    End Function
End Class

