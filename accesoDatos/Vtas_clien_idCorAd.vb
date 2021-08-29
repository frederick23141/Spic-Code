Imports System.Data.SqlClient
Imports System.Data
Imports entidadNegocios
Public Class Vtas_clien_idCorAd
    Public Function listar_consulta(ByVal nit As Double, ByVal ano_ini As Integer, ByVal ano_Fin As Integer, ByVal vendedores As String, ByVal vend_hoy As Boolean) As DataTable
        Dim conn As New SqlConnection
        Dim reader As SqlDataReader
        Dim comando As New SqlCommand
        Dim objConexion As New Conexion
        Dim dt As New DataTable
        Dim dr As DataRow
        Dim sql As String = ""
        Dim ano As Integer = 0
        Dim sw As Boolean = False
        Dim id_cor_ant As Integer = 0
        Dim criterioVendedor As String = ""
        Dim vendedor As String = ""
        If (vendedores <> "") Then
            If (vend_hoy) Then
                criterioVendedor = " AND vend_hoy in (" & vendedores & ")"
            Else
                criterioVendedor = " AND vendedor in (" & vendedores & ")"
            End If

        Else
            If (vend_hoy) Then
                vendedor = consultValor("Select vendedor FROM terceros WHERE nit = " & nit & " ")
                criterioVendedor = "  AND vendedor = " & vendedor & " "
            End If
        End If
        dt = construir_table(nit, ano_ini, ano_Fin, dt)
        comando.CommandType = CommandType.Text
        conn = objConexion.abrirConexion
        comando.Connection = conn
        sql = "SELECT  vend_hoy,vendedor ,YEAR (fec)AS Ano ,seg_idcor.Id_cor ,seg_idcor.Descripcion ,vtas.nit,SUM (vtas.KILOS )as kilos, SUM (vtas.Vr_total   )as Valor_tot ,(SELECT CASE WHEN SUM (vtas.Vr_total) =0 THEN 0 ELSE ((SUM (vtas.Vr_total  )- SUM (vtas.Cto_total )) /SUM (vtas.Vr_total)*100 )END)AS Porc_util " & _
                "FROM Jjv_V_vtas_vend_cliente_ref vtas INNER JOIN referencias ref ON vtas.codigo = ref.codigo, JJV_Grupos_seguimiento seg_idcor  " & _
                    "WHERE(Year(fec) >= " & ano_ini & " And Year(fec) <= " & ano_Fin & " And seg_idcor.Id_cor = ref.Id_cor And vtas.nit = " & nit & " " & criterioVendedor & ") " & _
                          "GROUP  BY YEAR (fec) ,seg_idcor.Id_cor ,seg_idcor.Descripcion ,vtas.nit,vend_hoy,vendedor  " & _
                                "ORDER by seg_idcor.Id_cor "
        comando.CommandText = sql
        reader = comando.ExecuteReader
        dr = dt.NewRow
        While (reader.Read)
            ano = reader("Ano")
            If (sw = False) Then
                dr = dt.NewRow
                id_cor_ant = reader("Id_cor")
                sw = True
            End If
            If Not (id_cor_ant = reader("Id_cor")) Then
                dt.Rows.Add(dr)
                dr = dt.NewRow
                id_cor_ant = reader("Id_cor")
            End If
            dr("Linea_producción") = reader("Descripcion")
            dr("Kg-" & ano) = reader("kilos")
            dr("Vr_total-" & ano) = reader("Valor_tot")
            dr("%-" & ano) = reader("Porc_util")
            dr("id_cor") = reader("Id_cor")
            dr("nit") = reader("nit")

        End While
        dt.Rows.Add(dr)
        conn.Close()
        reader.Close()
        Return dt
    End Function
    Public Function consultValor(ByVal sql As String) As String
        Dim resp As String = ""
        Dim comando As New System.Data.SqlClient.SqlCommand
        Dim conn As New SqlConnection
        Dim objConexion As New Conexion
        comando = New SqlCommand
        Dim i As Integer = 0
        Dim reader As SqlDataReader
        comando.CommandType = CommandType.Text
        conn = objConexion.abrirConexion
        comando.Connection = conn
        comando.CommandText = (sql)
        reader = comando.ExecuteReader
        While (reader.Read)
            If Not IsDBNull(reader(0)) Then
                resp = reader(0)
            End If
        End While
        conn.Close()
        Return resp
    End Function
    Public Function construir_table(ByVal nit As Double, ByVal ano_ini As Integer, ByVal ano_Fin As Integer, ByVal dt As DataTable) As DataTable
        dt.Columns.Add("Linea_producción")
        dt.Columns.Add("nit")
        dt.Columns.Add("id_cor")
        For i = ano_ini To ano_Fin
            dt.Columns.Add("Kg-" & ano_ini, GetType(Int64))
            dt.Columns.Add("Vr_total-" & ano_ini, GetType(Int64))
            dt.Columns.Add("%-" & ano_ini, GetType(Int64))
            ano_ini += 1
        Next
        Return dt
    End Function
    Public Function listar_detalle(ByVal ano As Integer, ByVal nit As Double, ByVal id_cor As Integer) As DataTable
        Dim conn As New SqlConnection
        Dim objConexion As New Conexion
        conn = objConexion.abrirConexion
        Dim sql As String = "SELECT  vtas.codigo ,vtas.Descripcion ,SUM (vtas.KILOS )as kilos, SUM (vtas.Vr_total   )as Valor_tot ,(SELECT CASE WHEN SUM (vtas.Vr_total) =0 THEN 0 ELSE ((SUM (vtas.Vr_total  )- SUM (vtas.Cto_total )) /SUM (vtas.Vr_total)*100 )END)AS Porc_util  " & _
                                 "FROM Jjv_V_vtas_vend_cliente_ref vtas INNER JOIN referencias ref ON vtas.codigo = ref.codigo, JJV_Grupos_seguimiento seg_idcor " & _
                                  "WHERE(Year(fec) = " & ano & "  And seg_idcor.Id_cor = ref.Id_cor And vtas.nit = " & nit & ") AND seg_idcor.Id_cor  = " & id_cor & " " & _
                                     "GROUP  by vtas.codigo ,vtas .Descripcion "
        Dim dt As New DataTable
        Dim DA As New SqlDataAdapter(sql, conn)
        DA.Fill(dt)
        conn.Close()
        Return dt
    End Function
    Public Function cargar_table(ByVal sql As String) As DataTable
        Dim conn As New SqlConnection
        Dim objConexion As New Conexion
        conn = objConexion.abrirConexion
        Dim dt As New DataTable
        Dim DA As New SqlDataAdapter(sql, conn)
        DA.Fill(dt)
        conn.Close()
        Return dt
    End Function

End Class
