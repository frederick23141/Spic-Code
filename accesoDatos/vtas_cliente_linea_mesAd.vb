Imports System.Data.SqlClient
Imports System.Data
Imports entidadNegocios
Public Class vtas_cliente_linea_mesAd
    Public Function list_analisos_vrKilo_meses(ByVal mes_ini As Integer, ByVal ano_ini As Integer, ByVal mes_fin As Integer, ByVal ano_fin As Integer, ByVal nit As Double, ByVal whereVendedor As String) As DataTable
        Dim conn As New SqlConnection
        Dim reader As SqlDataReader
        Dim comando As New SqlCommand
        Dim objConexion As New Conexion
        Dim dt As New DataTable
        Dim nombMes As String = ""
        Dim primero As Boolean = True
        If (mes_fin = 12) Then
            mes_fin = 1
            ano_fin = ano_fin + 1
        Else
            mes_fin = mes_fin + 1
        End If
        Dim fecIni As String = ano_ini & "-" & mes_ini & "-01"
        Dim fecFin As String = ano_fin & "-" & mes_fin & "-01"
        Dim sql As String = ""
        Dim nom_col As String = ""
        Dim mes_ant As Integer = 0
        Dim ano_ant As Integer = 0
        dt = llenarDtLineasProduccion(fecIni, fecFin, nit)

        comando.CommandType = CommandType.Text
        conn = objConexion.abrirConexion
        comando.Connection = conn
        sql = "SELECT SUM (KILOS) As kilos,SUM (Vr_total )As vr_total,SUM (Cto_total ) As cto_tot,YEAR (fec) as ano ,MONTH (fec) As mes ,Id_cor,desc_id_cor " & _
                        "FROM Jjv_V_vtas_vend_cliente_ref " & _
                                "WHERE fec>='" & fecIni & "' and fec <'" & fecFin & "' AND nit = " & nit & " " & whereVendedor & " " & _
                                    "GROUP BY MONTH (fec),YEAR (fec) ,Id_cor,desc_id_cor " & _
                                        "ORDER BY YEAR (fec)Asc ,MONTH (fec)Asc"
        comando.CommandText = sql
        reader = comando.ExecuteReader
        While (reader.Read)
            nombMes = MonthName(reader("mes"), True).ToUpper & "-" & reader("ano")
            If (primero) Then
                mes_ant = reader("mes")
                ano_ant = reader("ano")
                dt.Columns.Add(nombMes & "-kilos", GetType(Double))
                dt.Columns.Add(nombMes & "-vr_total", GetType(Double))
                dt.Columns.Add(nombMes & "-cto_tot", GetType(Double))
                dt.Columns.Add(nombMes & "-p_util", GetType(Double))
                primero = False
            End If
            If (mes_ant <> reader("mes") Or ano_ant <> reader("ano")) Then
                dt.Columns.Add(nombMes & "-kilos", GetType(Double))
                dt.Columns.Add(nombMes & "-vr_total", GetType(Double))
                dt.Columns.Add(nombMes & "-cto_tot", GetType(Double))
                dt.Columns.Add(nombMes & "-p_util", GetType(Double))
            End If
            For i = 0 To dt.Rows.Count - 1
                If (dt.Rows(i).Item("id_cor") = reader("id_cor")) Then
                    dt.Rows(i).Item(nombMes & "-vr_total") = reader("vr_total")
                    dt.Rows(i).Item(nombMes & "-cto_tot") = reader("cto_tot")
                    dt.Rows(i).Item(nombMes & "-p_util") = (dt.Rows(i).Item(nombMes & "-vr_total") - reader("cto_tot")) / (dt.Rows(i).Item(nombMes & "-vr_total")) * 100
                    dt.Rows(i).Item(nombMes & "-kilos") = reader("kilos")
                    i = dt.Rows.Count - 1
                End If
            Next
            mes_ant = reader("mes")
            ano_ant = reader("ano")
        End While
        conn.Close()
        reader.Close()
        Return dt
    End Function
    Private Function llenarDtLineasProduccion(ByVal fecIni As String, ByVal fecFin As String, ByVal nit As Double)
        Dim conn As New SqlConnection
        Dim reader As SqlDataReader
        Dim comando As New SqlCommand
        Dim objConexion As New Conexion
        Dim dt As New DataTable
        dt.Columns.Add("Linea")
        dt.Columns.Add("id_cor")
        Dim sql As String = "SELECT id_cor,desc_id_cor " & _
                        "FROM Jjv_V_vtas_vend_cliente_ref " & _
                                "WHERE fec>='" & fecIni & "' and fec <'" & fecFin & "' AND nit = " & nit & " " & _
                                    "GROUP BY id_cor,desc_id_cor " & _
                                        "ORDER BY id_cor"
        comando.CommandType = CommandType.Text
        conn = objConexion.abrirConexion
        comando.Connection = conn
        comando.CommandText = sql
        reader = comando.ExecuteReader
        While (reader.Read)
            dt.Rows.Add()
            dt.Rows(dt.Rows.Count - 1).Item("Linea") = reader("desc_id_cor")
            dt.Rows(dt.Rows.Count - 1).Item("id_cor") = reader("id_cor")
        End While
        conn.Close()
        reader.Close()
        Return dt
    End Function
End Class
