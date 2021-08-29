Imports System.Data.SqlClient
Imports System.Data
Imports entidadNegocios
Public Class VtasClientAd
    Private conn As New SqlConnection
    Private conn2 As New SqlConnection
    Private comando As New SqlCommand
    Dim objConexion As New Conexion
    Private objVtasClienProdEn As VtasClientEn

    Public Function listarClienProd(ByVal min As Double, ByVal max As Double, ByVal mesIni As Double, ByVal añoIni As Double, ByVal mesFin As Double, ByVal añoFin As Double, ByVal codigoMin As String, ByVal codigoMax As String, ByVal vendedores As String) As DataTable
        Dim dia_fin As Integer = DateSerial(añoFin, mesFin + 1, 0).Day
        Dim fec_ini As String = añoIni & "/" & mesIni & "/01"
        Dim fec_max As String = añoFin & "/" & mesFin & "/" & dia_fin
        conn = objConexion.abrirConexion
        Dim dt As New DataTable
        Dim criterioVendedor As String = ""
        If (vendedores <> "") Then
            criterioVendedor = " AND vendedor in (" & vendedores & ")"
        Else
            criterioVendedor = " AND vendedor >= 1001 AND vendedor <= 1099"
        End If
        Dim sql As String = "SELECT ciudad,nit,nombres,codigo,descripcion,SUM (cantidad)As Cantidad,SUM(Kilos)As Kilos,SUM(Vr_total )As Vr_total,SUM(Cto_total  )As Cto_total " & _
                                "FROM Jjv_V_vtas_vend_cliente_ref " & _
                                    "WHERE fec>='" & fec_ini & "'and fec<='" & fec_max & "' AND   codigo  between '" & codigoMin & "%' and '" & codigoMax & "%' " & criterioVendedor & "" & _
                                        "GROUP BY ciudad,nit,nombres,codigo,descripcion " & _
                                                "ORDER BY codigo"
        Dim DA As New SqlDataAdapter(sql, conn)
        DA.Fill(dt)
        Return dt
    End Function


End Class
