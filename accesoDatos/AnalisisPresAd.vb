Imports System.Data.SqlClient
Imports System.Data
Imports entidadNegocios

Public Class AnalisisPresAd
    Private conn As New SqlConnection
    Private conn2 As New SqlConnection
    Private comando As New SqlCommand
    Dim objConexion As New Conexion
    Dim objAnalisisPresEn As New AnalisisPresEn

   
    
    Public Function cargarVendedores() As String()
        Dim reader As SqlDataReader
        Dim vecVend(99) As String
        Dim k As Double = 0
        comando.CommandType = CommandType.Text
        conn = objConexion.abrirConexion
        comando.Connection = conn
        comando.CommandText = ("select vendedor FROM v_vendedores WHERE     (vendedor >= 1001) AND (vendedor <= 1099) AND (bloqueo = 0) ORDER BY vendedor")
        reader = comando.ExecuteReader
        While (reader.Read)
            If IsDBNull(reader(0)) Then
            Else
                vecVend(k) = reader(0)
                k = k + 1
            End If
        End While
        vecVend(k) = ("Nacionales")
        vecVend(k + 1) = ("Todos")
        conn.Close()
        Return vecVend
    End Function
    Public Function cargarConsultaVtasMes(ByVal vendedorMin As Integer, ByVal vendedorMax As Integer, ByVal mes As Integer, ByVal año As Integer, ByVal id_cor As Integer) As DataTable
        conn = objConexion.abrirConexion
        Dim DA As New SqlDataAdapter("select CIUDAD,NIT, NOMBRES,Codigo,DESCRIPCION,CANTIDAD as CANT,KILOS,VR_TOTAL,VALOR_UNITARIO as VR_UNIT,COSTO_UNITARIO as COST_UNIT,((SELECT CASE WHEN KILOS  = 0 THEN null ELSE (VALOR_UNITARIO)*100/(Vr_total /KILOS  ) END))as VR_KILO from Jjv_V_vtas_vend_cliente_ref   where MONTH (fec)=" & mes & " and YEAR (fec)=" & año & "  and vendedor >= " & vendedorMin & "  and vendedor <= " & vendedorMax & " and Id_cor = " & id_cor & " order by nit", conn)
        Dim dt As New DataTable
        DA.Fill(dt)
        conn.Close()
        Return dt
    End Function
End Class
