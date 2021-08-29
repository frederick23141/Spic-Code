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
    Public Function listarFactura(ByVal nit As Double, ByVal mesIni As String, ByVal añoIni As String, ByVal mesFin As Integer, ByVal anoFin As Integer, ByVal codigo As String) As DataTable
        Dim ultimo As Date
        ultimo = DateSerial(anoFin, mesFin + 1, 0)
        conn = objConexion.abrirConexion
        Dim dt As New DataTable
        Dim sql As String = "SELECT  numero, fec, codigo, descripcion, valor_unitario, cantidad, Kilos, Vr_total,pedido, notas FROM Jjv_V_vtas_vend_cliente_ref   where nit=" & nit & "and fec >= '" & mesIni & "/01/" & añoIni & "' and fec <= '" & mesFin & "/" & ultimo.Day & "/" & anoFin & "' AND codigo like '" & codigo & "%' ORDER BY fec DESC"
        Dim DA As New SqlDataAdapter(sql, conn)
        DA.Fill(dt)
        conn.Close()
        Return dt

    End Function
    Public Function listar_may_vta(ByVal nit As Double) As DataTable
        conn = objConexion.abrirConexion
        Dim sql As String
        Dim dt As New DataTable
        sql = "SELECT  pedido, tipo, numero, fec, codigo, descripcion, cantidad, Kilos, valor_unitario, Vr_total, notas " & _
                        "FROM Jjv_V_vtas_vend_cliente_ref " & _
                                "WHERE nit=" & nit & " and fec = (select max(fec) FROM Jjv_V_vtas_vend_cliente_ref where nit = " & nit & ")"
        Dim DA As New SqlDataAdapter(sql, conn)
        DA.Fill(dt)
        conn.Close()
        Return dt

    End Function
    '****************************************************************************************************************
    'Funcion encargada se sumar los valores totales******************************************************************
    '****************************************************************************************************************
    Public Function sumarValorTotal(ByVal nit As Double, ByVal mesIni As String, ByVal añoIni As String, ByVal mesFin As Integer, ByVal anoFin As Integer) As Double
        Dim suma As Decimal
        Dim ultimo As Date = DateSerial(anoFin, mesFin + 1, 0)
        Dim reader As SqlDataReader
        conn = objConexion.abrirConexion
        comando.Connection = conn
        comando.CommandType = CommandType.Text
        Dim sql As String = " SELECT ROUND(SUM (Vr_total),0) FROM Jjv_V_vtas_vend_cliente_ref where nit=" & nit & "and fec >= '" & mesIni & "/01/" & añoIni & "' and fec < '" & mesFin & "/" & ultimo.Day & "/" & anoFin & "'"
        comando.CommandText = Sql
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
    Public Function sumarValorKilos(ByVal nit As Double, ByVal mesIni As String, ByVal añoIni As String, ByVal mesFin As Integer, ByVal anoFin As Integer) As Decimal
        Dim suma As Decimal
        Dim reader As SqlDataReader
        Dim ultimo As Date = DateSerial(anoFin, mesFin + 1, 0)
        conn = objConexion.abrirConexion
        comando.Connection = conn
        comando.CommandType = CommandType.Text
        Dim sql As String = " SELECT ROUND(SUM (Kilos ),1) FROM Jjv_V_vtas_vend_cliente_ref where nit=" & nit & "and fec >= '" & mesIni & "/01/" & añoIni & "' and fec < '" & mesFin & "/" & ultimo.Day & "/" & anoFin & "'"
        comando.CommandText = sql
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
