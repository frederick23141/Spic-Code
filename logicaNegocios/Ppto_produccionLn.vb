Imports accesoDatos
Public Class Ppto_produccionLn
    Private objAnalisisAd As AnalisisAd2
    Dim obj_op_simplesLn As New Op_simpesLn
    Public Sub add_inv_area(ByRef dt As DataTable, ByVal centro As Integer, ByVal where_codigo As String, ByVal mes As Integer, ByVal ano As Integer)
        Dim sql As String = ""
        Dim dt_datos As New DataTable
        Dim group As String = ""
        If centro <> 6200 And centro <> 2800 Then 'temple
            sql = "SELECT SUM(kilos)As kilos    " &
                        "FROM J_transacciones_kilos   " &
                               "WHERE  ano =" & ano & " AND mes =" & mes & " " & where_codigo
            dt_datos = obj_op_simplesLn.listar_datatable(sql, "CORSAN")
        ElseIf (centro = 6200) Then
            sql = "SELECT SUM( [Seguimiento tornillos].Cantidad ) AS kilos  " &
            "FROM [Seguimiento tornillos] " &
                "WHERE  [Seguimiento tornillos].Maquina = '213' and YEAR( Fecha) =  " & ano & " and MONTH( Fecha) = " & mes & " "
            dt_datos = obj_op_simplesLn.listar_datatable(sql, "PRODUCCION")
        ElseIf (centro = 2800) Then
            sql = "SELECT SUM( [Seguimiento tornillos].Cantidad ) AS kilos  " &
            "FROM [Seguimiento tornillos] " &
                "WHERE  [Seguimiento tornillos].Maquina = '180' and YEAR( Fecha) =  " & ano & " and MONTH( Fecha) = " & mes & " "
            dt_datos = obj_op_simplesLn.listar_datatable(sql, "PRODUCCION")
        End If

        For i = 0 To dt.Rows.Count - 1
            If dt.Rows(i).Item("centro") = centro Then
                For k = 0 To dt_datos.Rows.Count - 1
                    If IsNumeric(dt_datos.Rows(k).Item("kilos")) Then
                        dt.Rows(i).Item("llevamos") = dt_datos.Rows(k).Item("kilos")
                    End If
                Next
            End If
        Next
    End Sub
    Public Sub add_Cantidad_Inv(ByRef dt As DataTable, ByVal centro As Integer, ByVal where_codigo As String, ByVal mes As Integer, ByVal ano As Integer)
        Dim sql As String = ""
        Dim dt_datos As New DataTable
        Dim group As String = ""
        If centro <> 6200 And centro <> 2800 Then 'temple
            sql = "SELECT SUM(cantidad)As cantidad    " &
                        "FROM J_transacciones_kilos   " &
                               "WHERE  ano =" & ano & " AND mes =" & mes & " " & where_codigo
            dt_datos = obj_op_simplesLn.listar_datatable(sql, "CORSAN")
        ElseIf (centro = 6200) Then
            sql = "SELECT SUM( [Seguimiento tornillos].Cantidad ) AS Cantidad  " &
            "FROM [Seguimiento tornillos] " &
                "WHERE  [Seguimiento tornillos].Maquina = '213' and YEAR( Fecha) =  " & ano & " and MONTH( Fecha) = " & mes & " "
            dt_datos = obj_op_simplesLn.listar_datatable(sql, "PRODUCCION")
        ElseIf (centro = 2800) Then
            sql = "SELECT SUM( [Seguimiento tornillos].Cantidad ) AS Cantidad  " &
            "FROM [Seguimiento tornillos] " &
                "WHERE  [Seguimiento tornillos].Maquina = '180' and YEAR( Fecha) =  " & ano & " and MONTH( Fecha) = " & mes & " "
            dt_datos = obj_op_simplesLn.listar_datatable(sql, "PRODUCCION")
        End If

        For i = 0 To dt.Rows.Count - 1
            If dt.Rows(i).Item("centro") = centro Then
                For k = 0 To dt_datos.Rows.Count - 1
                    If IsNumeric(dt_datos.Rows(k).Item("cantidad")) Then
                        dt.Rows(i).Item("llevamos_cant") = dt_datos.Rows(k).Item("cantidad")
                    End If
                Next
            End If
        Next
    End Sub
    Public Function cargar_seguimiento_gral_area(ByVal dias_habiles_otros As Double, ByVal dias_adic_otros As Double, ByVal dias_trabajados_otros As Double, ByVal mes As Integer, ByVal ano As Integer) As DataTable
        Dim dias_habiles As Double = 0
        Dim dias_adic As Double = 0
        Dim cant_festivos As Integer = 0
        Dim dias_trbajados As Double = 0
        Dim dt As New DataTable
        Dim sql As String = "SELECT c.centro,c.descripcion,p.kilos As ppto_kilos,p.cantidad as ppto_cantidad,dias_habiles,dias_adicionales " &
                                            "FROM J_ppto_prod_area p , CORSAN.dbo.centros  c " &
                                                "WHERE p.centro = c.centro AND mes =" & mes & " AND ano = " & ano & " " &
                                                   "ORDER BY p.centro "

        dt = obj_op_simplesLn.listar_datatable(sql, "PRODUCCION")
        dt.Columns.Add("dias_trab", GetType(Double))
        dt.Columns.Add("ppto_por_dia", GetType(Double))
        dt.Columns.Add("llevamos", GetType(Double))
        dt.Columns.Add("llevamos_cant", GetType(Double))
        dt.Columns.Add("prom_dia", GetType(Double))
        dt.Columns.Add("deb_llevar", GetType(Double))
        dt.Columns.Add("cump_hoy", GetType(Double))
        dt.Columns.Add("pxn_a_recup", GetType(Double))
        dt.Columns.Add("cump", GetType(Double))
        If (dt.Rows.Count > 0) Then
            If Not IsDBNull(dt.Rows(0).Item("dias_habiles")) Then
                dias_habiles = dt.Rows(0).Item("dias_habiles")
            End If
            If Not IsDBNull(dt.Rows(0).Item("dias_adicionales")) Then
                dias_adic = dt.Rows(0).Item("dias_adicionales")
            End If
        End If
        dias_habiles += dias_adic
        If (mes <> Now.Month) Then
            dias_trbajados = dias_habiles
        Else
            dias_trbajados = obj_op_simplesLn.calcDiasHabilesProduccion(ano & "-" & mes & "-01", ano & "-" & mes & "-" & Now.Day)
            dias_trbajados -= obj_op_simplesLn.cant_festivos2(Now.Day, mes, ano)
            dias_trbajados -= dias_vacas(mes, ano)
            dias_trbajados += dias_adic
        End If
        If dias_trbajados > 1 And mes = Now.Month Then
            dias_trbajados -= 1
        End If

        Dim where_sql_inv As String = ""
        For i = 0 To dt.Rows.Count - 1
            Select Case dt.Rows(i).Item("centro")
                Case 2100 'trefilacion
                    where_sql_inv = " AND (codigo like '33X%' or codigo like '22X%' or codigo like '33B%' or codigo like '22B%') AND tipo IN ('EPPT','EPPP') "
                Case 2200 ' recocido
                    where_sql_inv = " AND (codigo like '22R%' or codigo like '33R%') AND tipo IN ('EPPT','EPPP') "
                Case 2300 ' puntilleria
                    where_sql_inv = " AND (codigo like '2CC%' or codigo like '2CA%' or codigo like '2CK%' or codigo like '2CM%') AND descripcion NOT like '%electrosoldado%' AND tipo IN ('EPPP') "
                Case 2400 'emp puntilleria
                    where_sql_inv = " AND (codigo like '3CC%' or codigo like '3CA%' or codigo like '3CK%' or codigo like '3CM%' or codigo like '3PT%') AND modelo in (01,02) AND descripcion NOT like '%electrosoldado%' AND tipo IN ('EDEP') "
                Case 2500 ' tornilleria
                    where_sql_inv = " AND (codigo like '3WW%' or codigo like '2T%') AND tipo IN ('ETV3','EAI2') AND descripcion NOT LIKE '%DRYWALL%' AND codigo not like '%GS' "
                Case 2600 'emp tornilleria
                    where_sql_inv = " AND tipo IN ('ETV3') "
                Case 2800 ' galv

                Case 5200 ' galv alambre
                    where_sql_inv = " AND (codigo like '33G%' or codigo like '22G%') AND tipo IN ('EPPT','EPPP') AND codigo not like '33G130125%' "
                Case 5300 ' Grapas
                    where_sql_inv = " AND codigo like '2GR%' AND tipo IN ('EPPP')  "
                Case 5400 ' empaque Grapas
                    where_sql_inv = " AND codigo like '3GR%' AND tipo IN ('EDEP')  "
                Case 6200 ' temple
                    where_sql_inv = ""
                Case 6400 ' puas 
                    where_sql_inv = " AND (codigo like '33P%') AND tipo IN ('EPPT','EPPP')"
            End Select
            add_inv_area(dt, dt.Rows(i).Item("centro"), where_sql_inv, mes, ano)
            add_Cantidad_Inv(dt, dt.Rows(i).Item("centro"), where_sql_inv, mes, ano)
        Next
        calcular_cumplimiento_area(dt, dias_habiles, dias_trbajados, dias_habiles_otros, dias_adic_otros, dias_trabajados_otros)
        Return dt
    End Function
    Private Sub add_extra(ByRef dt As DataTable, ByVal mes As Integer, ByVal ano As Integer)
        dt.Columns.Add("t_extra", GetType(Double))
        dt.Columns.Add("ppto_t_extra", GetType(Double))
        Dim sql_extra As String = "SELECT y.centro,SUM(y.horas)As horas,AVG(p.presupuesto)As presupuesto " &
                        " FROM y_liquidacion y , y_conceptos_nom c ,PRGPRODUCCION.dbo.J_ppto_prod_extra p " &
                            "WHERE p.mes = y.mes AND p.ano = y.ano AND y.centro = p.centro AND (y.mes) = " & mes & " And (y.ano)  = " & ano & " AND  y.concepto = c.concepto AND y.concepto IN ('13', '14', '15', '16')  " & _
                                "GROUP BY y.centro " & _
                                    "ORDER BY y.centro "
        Dim dt_extra As DataTable = obj_op_simplesLn.listar_datatable(sql_extra, "CORSAN")
        For i = 0 To dt.Rows.Count - 1
            If IsNumeric(dt.Rows(i).Item("centro")) Then
                For k = 0 To dt_extra.Rows.Count - 1
                    If dt.Rows(i).Item("centro") = dt_extra.Rows(k).Item("centro") Then
                        dt.Rows(i).Item("t_extra") = dt_extra.Rows(k).Item("horas")
                        dt.Rows(i).Item("ppto_t_extra") = dt_extra.Rows(k).Item("presupuesto")
                        k = dt_extra.Rows.Count - 1
                    End If
                Next
            End If
        Next
    End Sub
    Private Sub add_ausentismo(ByRef dt As DataTable, ByVal mes As Integer, ByVal ano As Integer)
        dt.Columns.Add("ausentismo", GetType(Double))
        dt.Columns.Add("ppto_ausentismo", GetType(Double))
        Dim sql_ausentismo As String = "SELECT y.centro,SUM(y.horas)As horas,AVG(p.presupuesto)As presupuesto " &
                            " FROM y_liquidacion y , y_conceptos_nom c , PRGPRODUCCION.dbo.J_ppto_prod_ausentismo p  " &
                                "WHERE p.mes = y.mes AND p.ano = y.ano AND y.centro = p.centro AND (y.mes) = " & mes & " And (y.ano)  = " & ano & " AND  y.concepto = c.concepto AND y.concepto IN ('5', '6', '7', '8', '9','25', '34', '35', '36', '37', '68', '77', '510', '511', '512', '513', '516')  " & _
                                    "GROUP BY y.centro " & _
                                        "ORDER BY y.centro "
        Dim dt_ausentismo As DataTable = obj_op_simplesLn.listar_datatable(sql_ausentismo, "CORSAN")
        For i = 0 To dt.Rows.Count - 1
            If IsNumeric(dt.Rows(i).Item("centro")) Then
                For k = 0 To dt_ausentismo.Rows.Count - 1
                    If dt.Rows(i).Item("centro") = dt_ausentismo.Rows(k).Item("centro") Then
                        dt.Rows(i).Item("ausentismo") = dt_ausentismo.Rows(k).Item("horas")
                        dt.Rows(i).Item("ppto_ausentismo") = dt_ausentismo.Rows(k).Item("presupuesto")
                        k = dt_ausentismo.Rows.Count - 1
                    End If
                Next
            End If
        Next
    End Sub
    Private Sub add_desperdicios(ByRef dt As DataTable, ByVal mes As Integer, ByVal ano As Integer)
        dt.Columns.Add("inherente", GetType(Double))
        dt.Columns.Add("ppto_inherente", GetType(Double))
        dt.Columns.Add("%_desp_inherente", GetType(Double))
        dt.Columns.Add("meta_inherente", GetType(Double))
        dt.Columns.Add("cumplimiento_inherente", GetType(Double))

        dt.Columns.Add("interna", GetType(Double))
        dt.Columns.Add("ppto_interna", GetType(Double))
        dt.Columns.Add("%_desp_interna", GetType(Double))
        dt.Columns.Add("meta_interna", GetType(Double))
        dt.Columns.Add("cumplimiento_interna", GetType(Double))

        dt.Columns.Add("suma_desperdicio", GetType(Double))
        dt.Columns.Add("suma_ppto_desperdicio", GetType(Double))
        Dim sql_desperdicios As String = "SELECT centro,desc_centro,causal,SUM(kilos)As desperdicio,AVG(presupuesto) As ppto " & _
                                            "FROM J_v_desperdicios " & _
                                              "WHERE anulado Is NULL And Year(fecha) = " & ano & " And Month(fecha) =  " & mes & _
                                                    " GROUP BY centro,desc_centro , causal  " & _
                                                        " ORDER  by centro "
        Dim dt_desperdicios As DataTable = obj_op_simplesLn.listar_datatable(sql_desperdicios, "PRODUCCION")
        For i = 0 To dt.Rows.Count - 1
            If IsNumeric(dt.Rows(i).Item("centro")) Then
                For k = 0 To dt_desperdicios.Rows.Count - 1
                    If dt.Rows(i).Item("centro") = dt_desperdicios.Rows(k).Item("centro") Then
                        If dt_desperdicios.Rows(k).Item("causal") = "inherente" Then
                            dt.Rows(i).Item("inherente") = dt_desperdicios.Rows(k).Item("desperdicio")
                            dt.Rows(i).Item("ppto_inherente") = dt_desperdicios.Rows(k).Item("ppto")
                        Else
                            dt.Rows(i).Item("interna") = dt_desperdicios.Rows(k).Item("desperdicio")
                            dt.Rows(i).Item("ppto_interna") = dt_desperdicios.Rows(k).Item("ppto")
                        End If
                        If IsNumeric(dt.Rows(i).Item("suma_desperdicio")) Then
                            dt.Rows(i).Item("suma_desperdicio") += dt_desperdicios.Rows(k).Item("desperdicio")
                        Else
                            dt.Rows(i).Item("suma_desperdicio") = dt_desperdicios.Rows(k).Item("desperdicio")
                        End If
                        If IsNumeric(dt.Rows(i).Item("suma_ppto_desperdicio")) Then
                            dt.Rows(i).Item("suma_ppto_desperdicio") += dt_desperdicios.Rows(k).Item("ppto")
                        Else
                            dt.Rows(i).Item("suma_ppto_desperdicio") = dt_desperdicios.Rows(k).Item("ppto")
                        End If

                        Dim sql As String = ""
                        Dim pres As Double = 0
                        Dim where_sql_inv As String = ""

                        Select Case dt.Rows(i).Item("centro")
                            Case 2100 'trefilacion
                                where_sql_inv = " AND (codigo like '33X%' or codigo like '22X%' or codigo like '33B%' or codigo like '22B%') AND tipo IN ('EPPT','EPPP') "
                            Case 2200 ' recocido
                                where_sql_inv = " AND (codigo like '22R%' or codigo like '33R%') AND tipo IN ('EPPT','EPPP') "
                            Case 2300 ' puntilleria
                                where_sql_inv = " AND (codigo like '3CC%' or codigo like '3CA%' or codigo like '3CK%' or codigo like '3CM%') AND descripcion NOT like '%electro%' AND tipo IN ('EPPP') "
                            Case 2400 'emp puntilleria
                                where_sql_inv = " AND (codigo like '3CC%' or codigo like '3CA%' or codigo like '3CK%' or codigo like '3CM%') AND descripcion NOT like '%electro%' AND tipo IN ('EDEP') "
                            Case 2500 ' tornilleria
                                where_sql_inv = " AND (codigo like '3WW%' or codigo like '2T%') AND tipo IN ('ETV3','EAI2') AND descripcion NOT LIKE '%DRYWALL%' AND codigo not like '%GS' "
                            Case 2600 'emp tornilleria
                                where_sql_inv = " AND tipo IN ('ETV3') "
                            Case 2800 ' galv
                            Case 5200 ' galv alambre
                                where_sql_inv = " AND (codigo like '33G%' or codigo like '22G%') AND tipo IN ('EPPT','EPPP') AND codigo not like '33G130125%' "
                            Case 5300 ' Grapas
                                where_sql_inv = " AND codigo Like '2GR%' AND tipo IN ('EPPP')"
                            Case 5400 ' Empaque Grapas
                                where_sql_inv = " AND  codigo like '3GR%'AND tipo IN ('EDEP')"
                            Case 6200 ' temple
                                where_sql_inv = ""
                            Case 6400 ' puas 
                                where_sql_inv = " And (codigo Like '33P%') AND tipo IN ('EPPT') "
                        End Select


                        If dt.Rows(i).Item("centro") <> 6200 And dt.Rows(i).Item("centro") <> 2800 Then 'temple
                            Dim val As String
                            sql = "SELECT SUM(kilos)As kilos    " & _
                                        "FROM J_transacciones_kilos   " & _
                                               "WHERE  ano =" & ano & " AND mes =" & mes & " " & where_sql_inv
                            val = obj_op_simplesLn.consultValorTodo(sql, "CORSAN")
                            If val = "" Then
                                val = "0"
                            End If
                            pres = CDbl(val)
                        ElseIf (dt.Rows(i).Item("centro") = 6200) Then
                            Dim val As String
                            sql = "SELECT SUM(Cantidad ) AS kilos  " & _
                            "FROM PRGPRODUCCION.dbo.[Seguimiento tornillos]  " & _
                                "WHERE Maquina = '213' and YEAR( Fecha) =  " & ano & " and MONTH( Fecha) = " & mes & " "
                            val = obj_op_simplesLn.consultValorTodo(sql, "CORSAN")
                            If val = "" Then
                                val = "0"
                            End If
                            pres = CDbl(val)
                        ElseIf (dt.Rows(i).Item("centro") = 2800) Then
                            Dim val As String
                            sql = "SELECT SUM( Cantidad ) AS kilos  " & _
                            "FROM PRGPRODUCCION.dbo.[Seguimiento tornillos]  " & _
                                "WHERE Maquina = '180' and YEAR( Fecha) =  " & ano & " and MONTH( Fecha) = " & mes & " "
                            val = obj_op_simplesLn.consultValorTodo(sql, "CORSAN")
                            If val = "" Then
                                val = "0"
                            End If
                            pres = CDbl(val)
                        End If





                    If IsNumeric(dt.Rows(i).Item("inherente")) Then
                        dt.Rows(i).Item("%_desp_inherente") = dt.Rows(i).Item("inherente") / pres
                    End If
                    If IsNumeric(dt.Rows(i).Item("interna")) Then
                        dt.Rows(i).Item("%_desp_interna") = dt.Rows(i).Item("interna") / pres
                    End If

                    'INFORMACION TEMPORAL
                    If dt.Rows(i).Item("centro") = 2100 Then
                        dt.Rows(i).Item("meta_inherente") = 0.8
                        dt.Rows(i).Item("meta_interna") = 0.3
                    ElseIf dt.Rows(i).Item("centro") = 2300 Then
                        dt.Rows(i).Item("meta_inherente") = 1.6
                        dt.Rows(i).Item("meta_interna") = 0.7
                    ElseIf dt.Rows(i).Item("centro") = 2500 Then
                        dt.Rows(i).Item("meta_inherente") = 0.5
                        dt.Rows(i).Item("meta_interna") = 0.2
                    ElseIf dt.Rows(i).Item("centro") = 5200 Then
                        dt.Rows(i).Item("meta_inherente") = 1.6
                        dt.Rows(i).Item("meta_interna") = 1
                    ElseIf dt.Rows(i).Item("centro") = 6400 Then
                        dt.Rows(i).Item("meta_inherente") = 0.04
                        dt.Rows(i).Item("meta_interna") = 0.4
                    End If


                    If IsNumeric(dt.Rows(i).Item("%_desp_interna")) And IsNumeric(dt.Rows(i).Item("meta_interna")) Then
                        dt.Rows(i).Item("cumplimiento_interna") = (dt.Rows(i).Item("%_desp_interna") / dt.Rows(i).Item("meta_interna")) * 100
                    End If
                    If IsNumeric(dt.Rows(i).Item("%_desp_inherente")) And IsNumeric(dt.Rows(i).Item("meta_inherente")) Then
                        dt.Rows(i).Item("cumplimiento_inherente") = (dt.Rows(i).Item("%_desp_inherente") / dt.Rows(i).Item("meta_inherente")) * 100
                    End If



                    End If
                Next
            End If
        Next
    End Sub
    Public Function gestionar_otros_pptos(ByVal mes As Integer, ByVal ano As Integer) As DataTable
        Dim dt As New DataTable
        Dim sql As String = "SELECT centro,descripcion FROM centros WHERE centro IN (1100,1200,2100,2200,2300,2400,2500,2600,2800,5200,5300,5400,6200,6400)"
        dt = obj_op_simplesLn.listar_datatable(sql, "CORSAN")
        add_eficiencias(dt, mes, ano)
        add_eficiencias_meta(dt, mes, ano)
        dt.Columns.Add("porc_efic", GetType(Double))
        add_gastos(dt, mes, ano)
        dt.Columns.Add("porc_gastos", GetType(Double))
        add_desperdicios(dt, mes, ano)
        dt.Columns.Add("porc_desperdicios", GetType(Double))
        add_ausentismo(dt, mes, ano)
        dt.Columns.Add("porc_ausentismo", GetType(Double))
        add_extra(dt, mes, ano)
        dt.Columns.Add("porc_extra", GetType(Double))
        totalizar_dt(dt)
        calcular_cump_otros(dt)
        Return dt
    End Function
    Private Sub calcular_cump_otros(ByRef dt As DataTable)
        For j = 0 To dt.Columns.Count - 1
            Select Case dt.Columns(j).ColumnName
                Case "eficiencia"
                    op_cumplimiento(dt, j, "meta_eficienia", "porc_efic")
                Case "gastos"
                    op_cumplimiento(dt, j, "ppto_gastos", "porc_gastos")
                Case "desperdicio"
                    op_cumplimiento(dt, j, "ppto_desperdicio", "porc_desperdicios")
                Case "ausentismo"
                    op_cumplimiento(dt, j, "ppto_ausentismo", "porc_ausentismo")
                Case "t_extra"
                    op_cumplimiento(dt, j, "ppto_t_extra", "porc_extra")
            End Select
        Next
    End Sub
    Private Sub op_cumplimiento(ByRef dt As DataTable, ByVal col1 As Integer, ByVal col2 As String, ByVal col_destino As String)
        For i = 0 To dt.Rows.Count - 1
            If IsNumeric(dt.Rows(i).Item(col1)) And IsNumeric(dt.Rows(i).Item(col2)) Then
                dt.Rows(i).Item(col_destino) = (dt.Rows(i).Item(col1) / dt.Rows(i).Item(col2)) * 100
            End If
        Next
    End Sub
    Private Sub calcular_cumplimiento_area(ByRef dt As DataTable, ByVal dias_habiles As Double, ByVal dias_trabajados As Double, ByVal dias_habiles_otros As Double, ByVal dias_adic_otros As Double, ByVal dias_trabajados_otros As Double)
        Dim sum_ppto As Double = 0
        Dim sum_ppto_dia As Double = 0
        Dim sum_kilos As Double = 0
        Dim sum_deb_llevar As Double = 0
        Dim ppto_por_dia As Double = 0
        Dim ppto As Double = 0
        Dim dias_habiles_finales As Double = 0
        For i = 0 To dt.Rows.Count - 1
            If IsNumeric(dt.Rows(i).Item("llevamos")) Then
                If Not IsDBNull(dt.Rows(i).Item("ppto_kilos")) Then
                    If Not IsDBNull(dt.Rows(i).Item("centro")) Then
                        ppto = dt.Rows(i).Item("ppto_kilos")
                        If dt.Rows(i).Item("centro") = 5200 Then
                            dias_habiles_finales = dias_habiles_otros + dias_adic_otros
                            ppto_por_dia = ppto / dias_habiles_finales
                            dt.Rows(i).Item("dias_habiles") = dias_habiles_otros
                            dt.Rows(i).Item("dias_adicionales") = dias_adic_otros
                            dt.Rows(i).Item("dias_trab") = dias_trabajados_otros
                            dt.Rows(i).Item("deb_llevar") = ppto_por_dia * dias_trabajados_otros
                        Else
                            dias_habiles_finales = dias_habiles
                            ppto_por_dia = ppto / dias_habiles_finales
                            dt.Rows(i).Item("dias_trab") = dias_trabajados
                            dt.Rows(i).Item("deb_llevar") = ppto_por_dia * dias_trabajados
                        End If
                        sum_deb_llevar += dt.Rows(i).Item("deb_llevar")
                        dt.Rows(i).Item("ppto_por_dia") = ppto_por_dia
                    End If
                End If
                If (dt.Rows(i).Item("ppto_kilos") = 0 Or dt.Rows(i).Item("llevamos") = 0) Then
                    dt.Rows(i).Item("cump") = 0
                Else
                    dt.Rows(i).Item("cump") = (dt.Rows(i).Item("llevamos") / dt.Rows(i).Item("ppto_kilos")) * 100
                    sum_ppto += dt.Rows(i).Item("ppto_kilos")
                    sum_kilos += dt.Rows(i).Item("llevamos")
                End If
                If (dt.Rows(i).Item("deb_llevar") = 0 Or dt.Rows(i).Item("llevamos") = 0) Then
                    dt.Rows(i).Item("cump") = 0
                Else
                    dt.Rows(i).Item("cump_hoy") = (dt.Rows(i).Item("llevamos") / dt.Rows(i).Item("deb_llevar")) * 100
                    sum_ppto_dia += dt.Rows(i).Item("deb_llevar")
                End If
                dt.Rows(i).Item("prom_dia") = dt.Rows(i).Item("llevamos") / dias_trabajados
                dt.Rows(i).Item("pxn_a_recup") = dt.Rows(i).Item("deb_llevar") - dt.Rows(i).Item("llevamos")
            End If
        Next
    End Sub
    Private Sub add_eficiencias(ByRef dt As DataTable, ByVal mes As Integer, ByVal ano As Integer)
        dt.Columns.Add("eficiencia", GetType(Double))
        Dim sql As String = ""
        Dim centro As Integer
        Dim dt_efic As New DataTable
        For i = 0 To dt.Rows.Count - 1
            If IsNumeric(dt.Rows(i).Item("centro")) Then
                centro = dt.Rows(i).Item("centro")
                Select Case centro
                    Case 2100
                        sql = "SELECT YEAR(fecha)As ano,MONTH(fecha)As mes,((SUM (prod.reproceso) + SUM (prod.alambron)) / SUM(prod.kilos_esp)) * 100 AS efic " & _
                                    "FROM j_v_tref_completo prod  " & _
                                        "WHERE YEAR(fecha)= " & ano & " AND MONTH(fecha)= " & mes & " " & _
                                            "GROUP BY YEAR(fecha),MONTH(fecha)"
                    Case 6400
                        sql = "	SELECT YEAR(fecha)As ano,MONTH(fecha)As mes,(SELECT CASE WHEN SUM (prod.kilos_esp)= 0 THEN 0 ELSE(((SUM (prod.kilos_prod ))/SUM (prod.kilos_esp))*100)END)As efic  " & _
                                    "FROM J_prod_puas prod  " & _
                                        "WHERE YEAR(fecha)= " & ano & " AND MONTH(fecha)= " & mes & " " & _
                                            "GROUP BY YEAR(fecha),MONTH(fecha)"
                    Case 2300
                        sql = "	SELECT YEAR(fecha)As ano,MONTH(fecha)As mes,(((SUM (kilos_prod ))/SUM (kil_esperado))*100)As efic  " & _
                                    "FROM J_prod_puntilleria prod " & _
                                                  "WHERE YEAR(fecha)= " & ano & " AND MONTH(fecha)= " & mes & " " & _
                                            "GROUP BY YEAR(fecha),MONTH(fecha)"
                    Case 2400
                        sql = "	SELECT mes, ano ,(SELECT CASE WHEN SUM(esperado) =0 THEN 0 ELSE (SUM(cartones)/SUM(esperado))*100 END) As efic  " & _
                                  "FROM J_v_empaque_puntilleria v " & _
                                        "WHERE anulado Is null And mes = " & mes & "  And ano = " & ano & "  " & _
                                          "GROUP BY mes, ano "
                End Select
                If sql <> "" Then
                    dt_efic = New DataTable
                    dt_efic = obj_op_simplesLn.listar_datatable(sql, "PRODUCCION")
                    For k = 0 To dt_efic.Rows.Count - 1
                        dt.Rows(i).Item("eficiencia") = dt_efic.Rows(k).Item("efic")
                    Next
                    sql = ""
                End If
            End If
        Next
    End Sub
    Private Sub add_eficiencias_meta(ByRef dt As DataTable, ByVal mes As Integer, ByVal ano As Integer)
        Dim sql As String = ""
        Dim centro As Integer
        Dim dt_efic As New DataTable
        dt.Columns.Add("meta_eficienia", GetType(Double))
        For i = 0 To dt.Rows.Count - 1
            If IsNumeric(dt.Rows(i).Item("centro")) Then
                centro = dt.Rows(i).Item("centro")
                sql = "SELECT centro,presupuesto FROM J_ppto_prod_efic_meta WHERE mes =" & mes & " AND ano =" & ano & ""
                dt_efic = New DataTable
                dt_efic = obj_op_simplesLn.listar_datatable(sql, "PRODUCCION")
                For k = 0 To dt_efic.Rows.Count - 1
                    If IsNumeric(dt.Rows(i).Item("centro")) Then
                        If dt.Rows(i).Item("centro") = dt_efic.Rows(k).Item("centro") Then
                            dt.Rows(i).Item("meta_eficienia") = dt_efic.Rows(k).Item("presupuesto")
                        End If
                    End If
                Next
                sql = ""
            End If
        Next
    End Sub
    Public Function cargar_dias_habiles_otros(ByVal mes As Integer, ByVal ano As Integer) As DataTable
        Dim dias_habiles As Double = 0
        Dim sql As String = "SELECT dias_habiles,dias_adic FROM J_ppto_prod_dias_hab_otros WHERE mes =" & mes & " AND ano = " & ano
        Dim dt As DataTable = obj_op_simplesLn.listar_datatable(sql, "PRODUCCION")
        Return dt
    End Function
    Public Function cargar_dias_habiles(ByVal mes As Integer, ByVal ano As Integer) As DataTable
        Dim dias_habiles As Double = 0
        Dim sql As String = "SELECT dias_habiles,dias_adicionales FROM J_ppto_produccion WHERE mes =" & mes & " AND ano = " & ano
        Dim dt As DataTable = obj_op_simplesLn.listar_datatable(sql, "PRODUCCION")
        Return dt
    End Function
    Public Function cargar_dias_habiles_general(ByVal mes As Integer, ByVal ano As Integer) As DataTable
        Dim sql_fechas_descanso_otros As String = "SELECT fecha FROM J_ppto_prod_fec_descanso_otros WHERE mes =" & mes & " AND ano = " & ano
        Dim dt_fechas_descanso_otros As DataTable = obj_op_simplesLn.listar_datatable(sql_fechas_descanso_otros, "PRODUCCION")
        Dim dias_habiles As Double = 0
        Dim dias_habiles_otros As Double = 0
        Dim dias_adic_otros As Double = 0
        Dim dt_habiles_otros As DataTable = cargar_dias_habiles_otros(mes, ano)
        Dim dias_trabajados_otros As Double = Now.Day
        Dim dias_adic As Double = 0
        Dim cant_festivos As Integer = 0
        Dim dias_trabajados As Double = 0
        Dim dt_dias_habiles As DataTable = cargar_dias_habiles(mes, ano)
        Dim dt_dias_habiles_general As New DataTable
        For i = 0 To dt_habiles_otros.Rows.Count - 1
            dias_habiles_otros = dt_habiles_otros.Rows(i).Item("dias_habiles")
            dias_adic_otros = dt_habiles_otros.Rows(i).Item("dias_adic")
        Next
        dias_trabajados_otros += dias_adic_otros
        If (dt_dias_habiles.Rows.Count > 0) Then
            If Not IsDBNull(dt_dias_habiles.Rows(0).Item("dias_habiles")) Then
                dias_habiles = dt_dias_habiles.Rows(0).Item("dias_habiles")
            End If
            If Not IsDBNull(dt_dias_habiles.Rows(0).Item("dias_adicionales")) Then
                dias_adic = dt_dias_habiles.Rows(0).Item("dias_adicionales")
            End If
        End If
        dias_habiles += dias_adic
        If (mes <> Now.Month) Then
            dias_trabajados = dias_habiles
        Else
            dias_trabajados = obj_op_simplesLn.calcDiasHabilesProduccion(ano & "-" & mes & "-01", ano & "-" & mes & "-" & Now.Day)
            dias_trabajados -= obj_op_simplesLn.cant_festivos2(Now.Day, mes, ano)
            dias_trabajados -= dias_vacas(mes, ano)
            dias_trabajados += dias_adic
        End If
        If dias_trabajados > 1 And mes = Now.Month Then
            dias_trabajados -= 1
            dias_trabajados_otros -= 1
        End If
        If dt_fechas_descanso_otros.Rows.Count > 0 Then
            For i = 0 To dt_fechas_descanso_otros.Rows.Count - 1
                If Convert.ToDateTime(dt_fechas_descanso_otros.Rows(i).Item("fecha")) < Now.Date Then
                    dias_trabajados_otros -= 1
                End If
            Next
        End If
        If Now.Month <> mes Then
            dias_trabajados_otros = dias_habiles_otros
        End If
        dt_dias_habiles_general.Columns.Add("dias_habiles", GetType(Double))
        dt_dias_habiles_general.Columns.Add("dias_habiles_otros", GetType(Double))
        dt_dias_habiles_general.Columns.Add("dias_adic_otros", GetType(Double))
        dt_dias_habiles_general.Columns.Add("dias_trabajados_otros", GetType(Double))
        dt_dias_habiles_general.Columns.Add("cant_festivos", GetType(Double))
        dt_dias_habiles_general.Columns.Add("dias_adic", GetType(Double))
        dt_dias_habiles_general.Columns.Add("dias_trabajados", GetType(Double))
        dt_dias_habiles_general.Rows.Add()
        dt_dias_habiles_general.Rows(0).Item("dias_habiles") = dias_habiles
        dt_dias_habiles_general.Rows(0).Item("dias_habiles_otros") = dias_habiles_otros
        dt_dias_habiles_general.Rows(0).Item("dias_adic_otros") = dias_adic_otros
        dt_dias_habiles_general.Rows(0).Item("dias_trabajados_otros") = dias_trabajados_otros
        dt_dias_habiles_general.Rows(0).Item("cant_festivos") = cant_festivos
        dt_dias_habiles_general.Rows(0).Item("dias_adic") = dias_adic
        dt_dias_habiles_general.Rows(0).Item("dias_trabajados") = dias_trabajados
        Return dt_dias_habiles_general
    End Function
    Private obj_Ing_prodLn As New Ing_prodLn
    Private Function dias_vacas(ByVal mes As Integer, ByVal ano As Integer)
        Dim dias As Integer = 0
        Dim sql As String = "select count(fecha) from J_ppto_prod_vac_planta where mes = " & mes & " and ano = " & ano
        dias = obj_Ing_prodLn.consultar_valor(sql, "PRODUCCION")
        Return dias
    End Function
    Private Sub add_gastos(ByRef dt As DataTable, ByVal mes As Integer, ByVal ano As Integer)
        dt.Columns.Add("gastos", GetType(Double))
        dt.Columns.Add("ppto_gastos", GetType(Double))
        Dim sql As String = "SELECT m.centro,SUM (m.valor)As valor " & _
                                "FROM movimiento m , J_ppto_gastos_cuentas p " & _
                                  "WHERE p.cuenta = m.cuenta AND m.centro <> 0 AND Year(m.fec) = " & ano & " And Month(m.fec) =  " & mes & " " & _
                                    "GROUP BY m.centro "

        Dim sql_ppto As String = "SELECT p.centro,SUM (p.ppto)As ppto  " & _
                                     "FROM J_ppto_gastos p  " & _
                                        "WHERE ano = " & ano & " And mes = " & mes & " AND centro <> 0 " & _
                                               "GROUP BY p.centro  "
        Dim dt_ppto As DataTable = obj_op_simplesLn.listar_datatable(sql_ppto, "CORSAN")
        Dim dt_gastos As DataTable = obj_op_simplesLn.listar_datatable(sql, "CORSAN")
        For i = 0 To dt.Rows.Count - 1
            For k = 0 To dt_ppto.Rows.Count - 1
                If IsNumeric(dt.Rows(i).Item("centro")) Then
                    If dt_ppto.Rows(k).Item("centro") = dt.Rows(i).Item("centro") Then
                        If IsNumeric(dt.Rows(i).Item("ppto_gastos")) Then
                            dt.Rows(i).Item("ppto_gastos") += dt_ppto.Rows(k).Item("ppto")
                        Else
                            dt.Rows(i).Item("ppto_gastos") = dt_ppto.Rows(k).Item("ppto")
                        End If
                    End If
                End If
            Next
        Next
        For i = 0 To dt.Rows.Count - 1
            For k = 0 To dt_gastos.Rows.Count - 1
                If IsNumeric(dt.Rows(i).Item("centro")) Then
                    If dt_gastos.Rows(k).Item("centro").ToString(0) = dt.Rows(i).Item("centro").ToString(0) And dt_gastos.Rows(k).Item("centro").ToString(1) = dt.Rows(i).Item("centro").ToString(1) Then
                        If IsNumeric(dt.Rows(i).Item("gastos")) Then
                            dt.Rows(i).Item("gastos") += dt_gastos.Rows(k).Item("valor")
                        Else
                            dt.Rows(i).Item("gastos") = dt_gastos.Rows(k).Item("valor")
                        End If
                    End If
                End If
            Next
        Next
    End Sub
    Private Sub totalizar_dt(ByRef dt As DataTable)
        Dim sum As Double = 0
        dt.Rows.Add()
        For j = 0 To dt.Columns.Count - 1
            If dt.Columns(j).ColumnName = "ppto_ausentismo" Or dt.Columns(j).ColumnName = "ppto_t_extra" Or dt.Columns(j).ColumnName = "desperdicio" Or dt.Columns(j).ColumnName = "ausentismo" Or dt.Columns(j).ColumnName = "t_extra" Or dt.Columns(j).ColumnName = "gastos" Or dt.Columns(j).ColumnName = "eficiencia" Or dt.Columns(j).ColumnName = "meta_eficienia" Or dt.Columns(j).ColumnName = "ppto_gastos" Or dt.Columns(j).ColumnName = "ppto_desperdicio" Or dt.Columns(j).ColumnName = "interna" Or dt.Columns(j).ColumnName = "inherente" Then
                For i = 0 To dt.Rows.Count - 2
                    If Not IsDBNull(dt.Rows(i).Item(j)) Then
                        sum += dt.Rows(i).Item(j)
                    End If
                Next
                dt.Rows(dt.Rows.Count - 1).Item(j) = sum
                sum = 0
            End If
        Next
    End Sub
End Class
