Imports System.Data.SqlClient
Imports System.Data
Imports entidadNegocios
'****************************************************************************************************************
'Se crean los parametros para la conexion ***********************************************************************
'****************************************************************************************************************
Public Class facturaMesActualAd
    Private conn As New SqlConnection
    Private comando As New SqlCommand
    Dim objConexion As New Conexion
    Public Sub New()
        Dim objConexion As New Conexion
    End Sub
    '****************************************************************************************************************
    'Se listan los resultados de el Nit de el cliente para sus facturas**********************************************
    '****************************************************************************************************************
    Public Function listarFactura(ByVal nit As Double, ByVal mes As String, ByVal año As String) As DataTable
        conn = objConexion.abrirConexion
        Dim dt As New DataTable
        Dim DA As New SqlDataAdapter("SELECT     pedido, tipo, numero, fec, codigo, descripcion, cantidad, Kilos, valor_unitario, Vr_total, notas FROM Jjv_V_vtas_vend_cliente_ref   where nit=" & nit & "and fec >= '" & mes & "/01/" & año & "'  ORDER BY fec DESC", conn)
        DA.Fill(dt)
        conn.Close()
        Return dt

    End Function
    '****************************************************************************************************************
    'Funcion encargada se sumar los valores totales******************************************************************
    '****************************************************************************************************************
    Public Function sumarValorTotal(ByVal nit As Double, ByVal mes As String, ByVal año As String) As Double
        Dim suma As Decimal
        Dim reader As SqlDataReader
        conn = objConexion.abrirConexion
        comando.Connection = conn
        comando.CommandType = CommandType.Text
        comando.CommandText = " SELECT ROUND(SUM (Vr_total),0) FROM Jjv_V_vtas_vend_cliente_ref where nit=" & nit & "and fec >= '" & mes & "/01/" & año & "'"
        reader = comando.ExecuteReader
        While reader.Read
            If IsDBNull(reader(0)) Then
            Else
                suma = reader(0)
            End If

        End While
        conn.Close()
        Return suma

    End Function
    '****************************************************************************************************************
    'Funcion encargada se sumar los valores de el campo kilos********************************************************
    '****************************************************************************************************************
    Public Function sumarValorKilos(ByVal nit As Double, ByVal mes As String, ByVal año As String) As Decimal
        Dim suma As Decimal
        Dim reader As SqlDataReader
        conn = objConexion.abrirConexion
        comando.Connection = conn
        comando.CommandType = CommandType.Text
        comando.CommandText = " SELECT ROUND(SUM (Kilos ),1) FROM Jjv_V_vtas_vend_cliente_ref where nit=" & nit & "and fec >= '" & mes & "/01/" & año & "'"
        reader = comando.ExecuteReader
        While reader.Read
            If IsDBNull(reader(0)) Then
            Else
                suma = reader(0)
            End If
        End While
        conn.Close()
        Return suma

    End Function

End Class
