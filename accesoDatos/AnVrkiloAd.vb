Imports System.Data.SqlClient
Imports System.Data
Imports entidadNegocios
Public Class AnVrkiloAd

    '****************************************************************************************************************
    'Se crean los parametros para la conexion ***********************************************************************
    '****************************************************************************************************************
    Private conn As New SqlConnection
    Private comando As New SqlCommand


    Dim objConexion As New Conexion
    Dim objAnalisisEn As AnalisisEn

    ''Lista todos los eneros del rango años, ejem enero 2012 -2011-2010..
    Public Function listarPresGeneral(ByVal mes As Integer, ByVal añoIni As Integer, ByVal añoFin As Integer) As List(Of AnVrKiloEn)
        Dim objAnVrKiloEn As New AnVrKiloEn
        Dim objAnVrKiloEn2 As New AnVrKiloEn
        Dim objAnVrKiloEn3 As New AnVrKiloEn
        Dim objAnVrKiloEn4 As New AnVrKiloEn
        Dim objAnVrKiloEn5 As New AnVrKiloEn
        Dim objAnVrKiloEn6 As New AnVrKiloEn
        Dim listaAnVrKilo As New List(Of AnVrKiloEn)
        Dim reader As SqlDataReader
        Dim sql As String = ""
        Dim i As Integer = 1
        Try
            conn = objConexion.abrirConexion
            comando.CommandType = CommandType.Text
            comando.Connection = conn
            sql = "select SUM (KILOS),SUM (Vr_total ),SUM (Cto_total ) from Jjv_V_vtas_vend_cliente_ref where MONTH (fec) = " & mes & " and YEAR (fec) >= " & añoIni & " and YEAR (fec) <= " & añoFin & " group by MONTH (fec),YEAR (fec)"
            comando.CommandText = sql
            reader = comando.ExecuteReader
            objAnVrKiloEn = New AnVrKiloEn
            objAnVrKiloEn.Descripcion = "Kilos"

            objAnVrKiloEn2 = New AnVrKiloEn
            objAnVrKiloEn2.Descripcion = "Valor Total"

            objAnVrKiloEn3 = New AnVrKiloEn
            objAnVrKiloEn3.Descripcion = "Costo Total"

            objAnVrKiloEn4 = New AnVrKiloEn
            objAnVrKiloEn4.Descripcion = "Valor Kilo"

            objAnVrKiloEn5 = New AnVrKiloEn
            objAnVrKiloEn5.Descripcion = "Costo Kilo"

            objAnVrKiloEn6 = New AnVrKiloEn
            objAnVrKiloEn6.Descripcion = "Porc Utilidad"

            While (reader.Read)
                If IsDBNull(reader(0)) Then
                Else

                    Select Case i
                        Case 1
                            objAnVrKiloEn.mes1 = reader(0)
                            objAnVrKiloEn2.mes1 = reader(1)
                            objAnVrKiloEn3.mes1 = reader(2)
                        Case 2
                            objAnVrKiloEn.mes2 = reader(0)
                            objAnVrKiloEn2.mes2 = reader(1)
                            objAnVrKiloEn3.mes2 = reader(2)
                        Case 3
                            objAnVrKiloEn.mes3 = reader(0)
                            objAnVrKiloEn2.mes3 = reader(1)
                            objAnVrKiloEn3.mes3 = reader(2)
                        Case 4
                            objAnVrKiloEn.mes4 = reader(0)
                            objAnVrKiloEn2.mes4 = reader(1)
                            objAnVrKiloEn3.mes4 = reader(2)
                        Case 5
                            objAnVrKiloEn.mes5 = reader(0)
                            objAnVrKiloEn2.mes5 = reader(1)
                            objAnVrKiloEn3.mes5 = reader(2)
                        Case 6
                            objAnVrKiloEn.mes6 = reader(0)
                            objAnVrKiloEn2.mes6 = reader(1)
                            objAnVrKiloEn3.mes6 = reader(2)
                        Case 7
                            objAnVrKiloEn.mes7 = reader(0)
                            objAnVrKiloEn2.mes7 = reader(1)
                            objAnVrKiloEn3.mes7 = reader(2)
                        Case 8
                            objAnVrKiloEn.mes8 = reader(0)
                            objAnVrKiloEn2.mes8 = reader(1)
                            objAnVrKiloEn3.mes8 = reader(2)
                        Case 9
                            objAnVrKiloEn.mes9 = reader(0)
                            objAnVrKiloEn2.mes9 = reader(1)
                            objAnVrKiloEn3.mes9 = reader(2)
                        Case 10
                            objAnVrKiloEn.mes10 = reader(0)
                            objAnVrKiloEn2.mes10 = reader(1)
                            objAnVrKiloEn3.mes10 = reader(2)
                        Case 11
                            objAnVrKiloEn.mes11 = reader(0)
                            objAnVrKiloEn2.mes11 = reader(1)
                            objAnVrKiloEn3.mes11 = reader(2)
                        Case 12
                            objAnVrKiloEn.mes12 = reader(0)
                            objAnVrKiloEn2.mes12 = reader(1)
                            objAnVrKiloEn3.mes12 = reader(2)
                        Case 13
                            objAnVrKiloEn.mes13 = reader(0)
                            objAnVrKiloEn2.mes13 = reader(1)
                            objAnVrKiloEn3.mes13 = reader(2)
                        Case 14
                            objAnVrKiloEn.mes14 = reader(0)
                            objAnVrKiloEn2.mes14 = reader(1)
                            objAnVrKiloEn3.mes14 = reader(2)
                        Case 15
                            objAnVrKiloEn.mes15 = reader(0)
                            objAnVrKiloEn2.mes15 = reader(1)
                            objAnVrKiloEn3.mes15 = reader(2)

                    End Select

                End If
                i += 1

            End While
            listaAnVrKilo.Add(objAnVrKiloEn)
            listaAnVrKilo.Add(objAnVrKiloEn2)
            listaAnVrKilo.Add(objAnVrKiloEn3)
            listaAnVrKilo.Add(objAnVrKiloEn4)
            listaAnVrKilo.Add(objAnVrKiloEn5)
            listaAnVrKilo.Add(objAnVrKiloEn6)

        Catch ex As ApplicationException
            MsgBox(ex.Message)
        End Try
        conn.Close()
        Return listaAnVrKilo
    End Function

    'Public Function detalle_analisis_vrkilo(ByVal mes_ini As Integer, ByVal ano_ini As Integer, ByVal mes_fin As Integer, ByVal ano_fin As Integer) As DataTable
    '    conn = objConexion.abrirConexion
    '    Dim dt As New DataTable
    '    Dim fecIni As String = ano_ini & "-" & mes_ini & "-01"
    '    Dim fecFin As String = ano_fin & "-" & mes_fin & "-01"
    '    Dim sql As String = "SELECT Year(pend.fec) As ano,Month(pend.fec) As mes,seg_idcor.Id_cor,seg_idcor.Descripcion ,SUM (pend.KILOS)AS Kilos,SUM (pend.Vr_total )AS Vr_tot,SUM (pend.Cto_total )AS Cto_tot ,(SUM (pend.Vr_total )/SUM (pend.KILOS))AS Vr_kilo,(SUM (pend.Cto_total )/SUM (pend.KILOS))AS Cto_kilo,((SUM (pend.Vr_total )/SUM (pend.KILOS))-(SUM (pend.Cto_total )/SUM (pend.KILOS)))/(SUM (pend.Vr_total )/SUM (pend.KILOS))*100 As Porc_util " & _
    '                                "FROM Jjv_V_vtas_vend_cliente_ref pend,JJV_Grupos_seguimiento seg_idcor " & _
    '                                    "WHERE pend.Id_cor Is Not null And pend.Id_cor = seg_idcor.Id_cor AND  fec>='" & fecIni & "' and fec <'" & fecFin & "' " & _
    '                                            "GROUP BY seg_idcor.Descripcion,Month(pend.fec),Year(pend.fec),seg_idcor.Id_cor " & _
    '                                                 "ORDER by  Year(pend.fec),Month(pend.fec),seg_idcor.Id_cor   "
    '    Dim DA As New SqlDataAdapter(sql, conn)
    '    DA.Fill(dt)
    '    conn.Close()
    '    Return dt
    'End Function

    Public Function detalle_analisis_vrkilo(ByVal mes_ini As Integer, ByVal ano_ini As Integer, ByVal mes_fin As Integer, ByVal ano_fin As Integer) As DataTable
        Dim mesAnt As String = ""
        Dim listIdCor As New List(Of Object)
        If (mes_fin = 12) Then
            mes_fin = 1
            ano_fin += 1
        Else
            mes_fin += 1
        End If
        listIdCor = lista("SELECT descripcion FROM JJV_Grupos_seguimiento ORDER BY id_cor")
        Dim fecIni As String = ano_ini & "-" & mes_ini & "-01"
        Dim fecFin As String = ano_fin & "-" & mes_fin & "-01"
        Dim conn As New SqlConnection
        Dim reader As SqlDataReader
        Dim comando As New SqlCommand
        Dim objConexion As New Conexion
        Dim dt As New DataTable
        Dim dr As DataRow
        Dim drAux As DataRow
        Dim nombMes As String = ""
        Dim sql As String = ""
        Dim contIdCor As Integer = 1
        Dim tam As Integer = listIdCor.Count - 1
        dt.Columns.Add("mes")
        dt.Columns.Add("Id_cor")
        dt.Columns.Add("Descripcion")
        dt.Columns.Add("Kilos", GetType(Double))
        dt.Columns.Add("Vr_tot", GetType(Double))
        dt.Columns.Add("Cto_tot", GetType(Double))
        dt.Columns.Add("Cto_kilo", GetType(Double))
        dt.Columns.Add("Porc_util", GetType(Double))
        comando.CommandType = CommandType.Text
        conn = objConexion.abrirConexion
        comando.Connection = conn
        sql = "SELECT Year(pend.fec) As ano,Month(pend.fec) As mes,pend.Id_cor, seg.Descripcion  ,SUM (pend.KILOS)AS Kilos,SUM (pend.Vr_total )AS Vr_tot,SUM (pend.Cto_total )AS Cto_tot ,(SELECT CASE WHEN SUM(pend.Vr_total) =0 THEN 0 ELSE (SUM (pend.Vr_total )/SUM (pend.KILOS)) END)AS Vr_kilo,(SELECT CASE WHEN SUM(pend.Vr_total) =0 THEN 0 ELSE (SUM (pend.Cto_total )/SUM (pend.KILOS)) END)AS Cto_kilo,(SELECT CASE WHEN SUM(pend.Vr_total) =0 THEN 0 ELSE (((SUM (pend.Vr_total )/SUM (pend.KILOS))-(SUM (pend.Cto_total )/SUM (pend.KILOS)))/(SUM (pend.Vr_total )/SUM (pend.KILOS))*100) END)  As Porc_util  " &
                 "FROM Jjv_V_vtas_vend_cliente_ref pend ,JJV_Grupos_seguimiento seg  " &
                  "WHERE pend.Id_cor Is Not null AND seg.Id_cor = pend.Id_cor  AND fec>='" & fecIni & "' and fec <'" & fecFin & "' GROUP BY Month(pend.fec),Year(pend.fec),pend.Id_cor , seg.Descripcion " &
                 "ORDER by  Year(pend.fec),Month(pend.fec),pend.Id_cor   "
        comando.CommandText = sql
        reader = comando.ExecuteReader
        While (reader.Read)
            nombMes = MonthName(reader("mes"), True).ToUpper & " - " & reader("ano")
            dr = dt.NewRow
            dr("mes") = nombMes
            dr("Id_cor") = reader("Id_cor")
            dr("Descripcion") = reader("Descripcion")
            dr("Kilos") = reader("Kilos")
            dr("Vr_tot") = reader("Vr_tot")
            dr("Cto_tot") = reader("Cto_tot")
            dr("Cto_kilo") = reader("Cto_kilo")
            dr("Porc_util") = reader("Porc_util")
            If (reader("Id_cor") <> contIdCor) Then
                drAux = dt.NewRow
                drAux("mes") = nombMes
                drAux("Id_cor") = contIdCor
                ' drAux("Descripcion") = listIdCor(contIdCor - 1)
                dt.Rows.Add(drAux)
                contIdCor = reader("Id_cor")
            End If
            If (reader("Id_cor") = tam + 1) Then
                contIdCor = 1
            Else
                contIdCor += 1
            End If
            dt.Rows.Add(dr)

        End While
        dr = dt.NewRow
        dt.Rows.Add(dr)
        conn.Close()
        reader.Close()
        Return dt
    End Function


    Public Function list_analisos_vrKilo_meses(ByVal mes_ini As Integer, ByVal ano_ini As Integer, ByVal mes_fin As Integer, ByVal ano_fin As Integer) As DataTable
        Dim conn As New SqlConnection
        Dim reader As SqlDataReader
        Dim comando As New SqlCommand
        Dim objConexion As New Conexion
        Dim dt As New DataTable
        Dim dr As DataRow
        Dim nombMes As String = ""
        If (mes_fin = 12) Then
            mes_fin = 1
            ano_fin = ano_fin + 1
        Else
            mes_fin = mes_fin + 1
        End If
        Dim fecIni As String = ano_ini & "-" & mes_ini & "-01"
        Dim fecFin As String = ano_fin & "-" & mes_fin & "-01"
        Dim stock As Double = 0
        Dim sql As String = ""
        Dim cont As Integer = 0
        Dim nom_col As String = ""
        dt.Columns.Add("Descripciòn") '
        dr = dt.NewRow
        dr("Descripciòn") = "Kilos"
        dt.Rows.Add(dr)

        Dim dr1 As DataRow = dt.NewRow
        dr1("Descripciòn") = "Valor_total"
        dt.Rows.Add(dr1)

        Dim dr2 As DataRow = dt.NewRow
        dr2("Descripciòn") = "Costo_total"
        dt.Rows.Add(dr2)

        Dim dr3 As DataRow = dt.NewRow
        dr3("Descripciòn") = "Valor_kilo"
        dt.Rows.Add(dr3)

        Dim dr4 As DataRow = dt.NewRow
        dr4("Descripciòn") = "Costo_kilo"
        dt.Rows.Add(dr4)

        Dim dr5 As DataRow = dt.NewRow
        dr5("Descripciòn") = "Porc_util"
        dt.Rows.Add(dr5)

        comando.CommandType = CommandType.Text
        conn = objConexion.abrirConexion
        comando.Connection = conn
        sql = "select SUM (KILOS) As kilos,SUM (Vr_total )As vr_total,SUM (Cto_total ) As cto_tot,YEAR (fec) as ano ,MONTH (fec) As mes " & _
                        "from Jjv_V_vtas_vend_cliente_ref " & _
                                "where fec>='" & fecIni & "' and fec <'" & fecFin & "' " & _
                                    "group by MONTH (fec),YEAR (fec) " & _
                                        "order by YEAR (fec)desc ,MONTH (fec)desc"
        comando.CommandText = sql
        reader = comando.ExecuteReader
        While (reader.Read)
            nombMes = MonthName(reader("mes"), True).ToUpper & " - " & reader("ano")
            dt.Columns.Add(nombMes, GetType(Double))
            dr(nombMes) = reader("kilos")
            dr1(nombMes) = reader("vr_total")
            dr2(nombMes) = reader("cto_tot")
            'dt.Rows.Add(dr)
        End While
        conn.Close()
        reader.Close()
        Return dt
    End Function
    Public Function lista(ByVal sql As String) As List(Of Object)
        Dim objConexion As New Conexion
        Dim reader As SqlDataReader
        Dim lista_valores As New List(Of Object)
        Dim comando As New SqlCommand
        Dim conn As New SqlConnection

        comando.CommandType = CommandType.Text
        conn = objConexion.abrirConexion
        comando.Connection = conn
        comando.CommandText = (sql)
        reader = comando.ExecuteReader
        While (reader.Read)
            If IsDBNull(reader(0)) Then
            Else
                lista_valores.Add(reader(0))
            End If
        End While
        conn.Close()
        Return lista_valores
    End Function

End Class

