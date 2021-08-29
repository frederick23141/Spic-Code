Imports System.Data.SqlClient
Imports System.Data
Imports entidadNegocios
Public Class pendientesAd
    '****************************************************************************************************************
    'Se crean los parametros para la conexion ***********************************************************************
    '****************************************************************************************************************
    Private conn As New SqlConnection
    Private comando As New SqlCommand
    Dim objConexion As New Conexion
    '****************************************************************************************************************
    'Se listan los resultados de el Nit de el cliente para sus Pendientes********************************************
    '****************************************************************************************************************
    Public Function listarPendiente(ByVal nit As Double) As DataTable
        conn = objConexion.abrirConexion
        Dim dt As New DataTable
        Dim sql As String = "SELECT distinct codigo,fecha, numero,  descripcion, valor_unitario, Cant_pedida, cantidad_despachada, Pendiente,  KilosPendiente, Valor_total, notas, autoriz_texto, autorizacion, usuario FROM V_pendientes_por_vendedor where nit=" & nit
        Dim DA As New SqlDataAdapter(sql, conn)
        DA.Fill(dt)
        conn.Close()
        Return dt
    End Function
    '****************************************************************************************************************
    'Funcion encargada se sumar los valores totales******************************************************************
    '****************************************************************************************************************
    Public Function sumValTot(ByVal nit As Double, ByVal iva As Double) As Double
        Dim suma As Double = 0
        Dim reader As SqlDataReader
        conn = objConexion.abrirConexion
        comando.Connection = conn
        comando.CommandType = CommandType.Text
        comando.CommandText = ("SELECT  distinct  codigo,Valor_total FROM V_pendientes_por_vendedor where nit=" & nit)
        reader = comando.ExecuteReader
        While reader.Read
            If IsDBNull(reader(1)) Then
            Else
                suma += reader(1)
            End If
        End While
        conn.Close()
        Return suma * (iva + 1)
    End Function
    '****************************************************************************************************************
    'Funcion encargada se sumar los valores de el campo kilos********************************************************
    '****************************************************************************************************************
    Public Function sumKilos(ByVal nit As Double) As Double
        Dim suma As Double
        Dim reader As SqlDataReader
        conn = objConexion.abrirConexion
        comando.Connection = conn
        comando.CommandType = CommandType.Text
        comando.CommandText = ("SELECT  distinct  codigo,KilosPendiente FROM V_pendientes_por_vendedor where nit=" & nit)
        reader = comando.ExecuteReader
        While reader.Read
            If IsDBNull(reader(1)) Then
            Else
                suma += reader(1)
            End If
        End While
        conn.Close()
        Return suma
    End Function

End Class
