Imports logicaNegocios
Imports entidadNegocios
Imports accesoDatos
Public Class Frm_seg_ppto_produccion
    Private obj_op_simplesLn As New Op_simpesLn
    Private obj_Ing_prodLn As New Ing_prodLn
    Private objOperacionesForm As New OperacionesFormularios
    Dim carga_comp As Boolean = False
    Dim usuario As New UsuarioEn
    Dim sum_kilos_ppto_total As Double = 0
    Dim sum_kilos_ppto_hoy As Double = 0
    Dim sum_kilos_ppto_productos As Double = 0
    Dim mes As Integer = 0
    Dim ano As Integer = 0
    Dim ver_costos As Boolean = True
    Dim obj_ppto_produccionLn As New Ppto_produccionLn
    Public Sub MAIN(ByVal usuario As UsuarioEn)
        Me.usuario = usuario
        If usuario.permiso <> "ADMIN" And usuario.permiso <> "DIR_PRODUCCION" Then
            ver_costos = False
        Else
            ver_costos = True
        End If
        consultar()
    End Sub
    Private Sub Frm_seg_ppto_produccion_load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim año = Now.Year
        While (año >= Now.Year - 5)
            cbo_ano.Items.Add(año)
            año -= 1
        End While
        cbo_ano.Text = Now.Year
        cbo_mes.SelectedIndex = Now.Month - 1
        mes = cbo_mes.SelectedIndex + 1
        ano = cbo_ano.Text
        tab_ppal.SelectedTab = tab_ppto_area
        tab_ppal.SelectedTab = tab_pendientes
        tab_ppal.SelectedTab = tab_b2
        tab_ppal.SelectedTab = tab_b3
        labelcontar()
        carga_comp = True
    End Sub
    'trae el total de registros de una consulta
    Public Sub labelcontar()
        Dim i As Integer
        Dim a As New ClasificacionAd
        i = a.contarregistros
        LinkLabel1.Text = "Productos sin clasificar:" & i
        If i = 0 Then
            LinkLabel1.LinkColor = Color.Green
        Else
            LinkLabel1.LinkColor = Color.Red
        End If
    End Sub


    Private Sub consultar()
        img_procesar.Visible = True
        Application.DoEvents()
        dtg_presupuesto.Columns.Clear()
        sum_kilos_ppto_total = 0
        sum_kilos_ppto_hoy = 0
        sum_kilos_ppto_productos = 0
        Dim dt As New DataTable
        Dim dias_habiles_otros As Double = 0
        Dim dias_adic_otros As Double = 0
        Dim dias_trbajados As Double = 0
        Dim dias_habiles As Double = 0
        Dim dias_trabajados_otros As Double = 0
        Dim dias_adic As Double = 0
        Dim dt_dias_habiles_general As DataTable = obj_ppto_produccionLn.cargar_dias_habiles_general(mes, ano)
        For i = 0 To dt_dias_habiles_general.Rows.Count - 1
            dias_habiles_otros = dt_dias_habiles_general.Rows(i).Item("dias_habiles_otros")
            dias_adic_otros = dt_dias_habiles_general.Rows(i).Item("dias_adic_otros")
            dias_trbajados = dt_dias_habiles_general.Rows(i).Item("dias_trabajados")
            dias_habiles = dt_dias_habiles_general.Rows(i).Item("dias_habiles")
            dias_trabajados_otros = dt_dias_habiles_general.Rows(i).Item("dias_trabajados_otros")
            dias_adic = dt_dias_habiles_general.Rows(i).Item("dias_adic")
        Next
        dt = armar_dt(dias_habiles_otros, dias_adic_otros, dias_habiles, dias_adic)
        addInventarios(dt, False)
        dt.Columns.Add("porc_cump", GetType(Double))
        dt.Rows.Add()
        calcular_ppto_a_hoy(dt, dias_trbajados, dias_habiles, dias_habiles_otros, dias_trabajados_otros)
        calcular_cumplimiento(dt)
        totalizarDt(dt)
        totalizar_tipo_producto(dt)
        eliminar_sin_ppto(dt)
        dtg_presupuesto.DataSource = dt
        formatoDtg()
        dtg_presupuesto.Columns("id_Cor").Visible = False
        dtg_presupuesto.Columns("porc_cump").HeaderText = "%mes"
        dtg_presupuesto.Columns("porc_hoy").HeaderText = "%hoy"
        dtg_presupuesto.Columns("linea_de_produccion").HeaderText = "Linea de producción"
        consumo_alambron(mes, ano, dias_trbajados, dias_habiles)
        inventarios_b2()
        bodega_2_nc()
        '  cargar_ppto_area(dias_habiles_otros, dias_adic_otros, dias_trabajados_otros)
        If Not ver_costos Then
            For j = 0 To dtg_presupuesto.ColumnCount - 1
                If dtg_presupuesto.Columns(j).Name = "cos_ent" Then
                    dtg_presupuesto.Columns(j).Visible = False
                End If
            Next
            For j = 0 To dtg_inv_b2.ColumnCount - 1
                If dtg_inv_b2.Columns(j).Name = "cos_ent" Or dtg_inv_b2.Columns(j).Name = "cos_ini" Or dtg_inv_b2.Columns(j).Name = "costo_stock" Or dtg_inv_b2.Columns(j).Name = "cos_sal" Then
                    dtg_inv_b2.Columns(j).Visible = False
                End If
            Next
        End If
        seg_ppto_dia(dias_trbajados, dias_habiles)
        seg_ppto_dia_area()
        cargar_ppto_area(dias_habiles_otros, dias_adic_otros, dias_trabajados_otros, mes, ano)

        seg_ppto_detalle(dias_trbajados, dias_habiles, dias_trabajados_otros)
        cargar_pendientes()

        cargar_pendientes_Ventas_2()
        mostrarVariables()
        cargar_ppto_otros()
        img_procesar.Visible = False
    End Sub
    Private Sub cargar_ppto_otros()
        Dim dt As DataTable = obj_ppto_produccionLn.gestionar_otros_pptos(mes, ano)
        dtg_otros_presupuestos.DataSource = dt
        dtg_otros_presupuestos.Columns("eficiencia").DefaultCellStyle.Format = "N2"
        dtg_otros_presupuestos.Columns("meta_eficienia").DefaultCellStyle.Format = "N2"
        dtg_otros_presupuestos.Columns("porc_efic").DefaultCellStyle.Format = "N2"
        dtg_otros_presupuestos.Columns("porc_gastos").DefaultCellStyle.Format = "N2"
        dtg_otros_presupuestos.Columns("porc_desperdicios").DefaultCellStyle.Format = "N2"
        dtg_otros_presupuestos.Columns("porc_ausentismo").DefaultCellStyle.Format = "N2"
        dtg_otros_presupuestos.Columns("porc_extra").DefaultCellStyle.Format = "N2"

        dtg_otros_presupuestos.Columns("%_desp_inherente").DefaultCellStyle.Format = "N6"
        dtg_otros_presupuestos.Columns("%_desp_interna").DefaultCellStyle.Format = "N6"
        dtg_otros_presupuestos.Columns("meta_inherente").DefaultCellStyle.Format = "N4"
        dtg_otros_presupuestos.Columns("cumplimiento_inherente").DefaultCellStyle.Format = "N4"
        dtg_otros_presupuestos.Columns("cumplimiento_interna").DefaultCellStyle.Format = "N4"
        dtg_otros_presupuestos.Columns("meta_interna").DefaultCellStyle.Format = "N4"

        dtg_otros_presupuestos.Columns("porc_efic").HeaderText = "%"
        dtg_otros_presupuestos.Columns("porc_gastos").HeaderText = "%"
        dtg_otros_presupuestos.Columns("porc_desperdicios").HeaderText = "%"
        dtg_otros_presupuestos.Columns("porc_ausentismo").HeaderText = "%"
        dtg_otros_presupuestos.Columns("porc_extra").HeaderText = "%"
        formatoDtg_otros()
    End Sub
    Private Sub cargar_ppto_area(ByVal dias_habiles_otros As Double, ByVal dias_adic_otros As Double, ByVal dias_trabajados_otros As Double, ByVal mes As Integer, ByVal ano As Integer)
        Dim dt As DataTable = obj_ppto_produccionLn.cargar_seguimiento_gral_area(dias_habiles_otros, dias_adic_otros, dias_trabajados_otros, mes, ano)
        dtg_ppto_area.DataSource = dt
        totalizar_dt_dias(dt)
        formatoDtgArea()
    End Sub
    Private Sub seg_ppto_dia(ByVal dias_trabajados As Double, ByVal dias_habiles As Double)
        dtg_seg_ppto_dia.Columns.Clear()
        dtg_seg_ppto_dia.DataSource = Nothing
        Dim dt As DataTable = armar_dt_dia()
        addDias(dt)
        addInventarios(dt, True)
        totalizarDt_dia(dt)
        totalizar_tipo_producto_dia(dt)
        calcular_ppto_dia(dt, dias_trabajados, dias_habiles)
        dtg_seg_ppto_dia.DataSource = dt
        formatoDia()
        pintar_dtg_dia()
    End Sub
    Private Sub seg_ppto_dia_area()
        dtg_seg_dia_area.Columns.Clear()
        dtg_seg_dia_area.DataSource = Nothing
        Dim dt As DataTable = armar_dt_dia_area()
        addDias(dt)
        cargar_ppto_area_dia(dt)
        '  totalizarDt_dia(dt)
        formatoDia_area()
        pintar_dtg_dia_area()
    End Sub
    Private Sub seg_ppto_detalle(ByVal dias_trabajados As Double, ByVal dias_habiles As Double, ByVal dias_trabajados_otros As Double)
        dtg_ppto_detalle.Columns.Clear()
        dtg_ppto_detalle.DataSource = Nothing
        Dim dias_habiles_otros As Double = 0
        Dim dias_adic_otros As Double = 0
        Dim dt_habiles_otros As DataTable = obj_ppto_produccionLn.cargar_dias_habiles_otros(mes, ano)
        For i = 0 To dt_habiles_otros.Rows.Count - 1
            dias_habiles_otros = dt_habiles_otros.Rows(i).Item("dias_habiles")
            dias_adic_otros = dt_habiles_otros.Rows(i).Item("dias_adic")
        Next
        Dim dt As DataTable = armar_dt_detalle()
        addInventarios_detalle(dt)
        dt.Columns.Add("porc_cump", GetType(Double))
        dt.Rows.Add()
        calcular_ppto_a_hoy(dt, dias_trabajados, dias_habiles, dias_habiles_otros, dias_trabajados_otros)
        calcular_cumplimiento(dt)
        totalizarDt(dt)
        totalizar_tipo_producto(dt)
        eliminar_sin_ppto(dt)
        dtg_ppto_detalle.DataSource = dt
        formatoDtg_detalle()
        dtg_ppto_detalle.Columns("id_Cor").Visible = False
        dtg_ppto_detalle.Columns("porc_cump").HeaderText = "%mes"
        dtg_ppto_detalle.Columns("porc_hoy").HeaderText = "%hoy"
        dtg_ppto_detalle.Columns("linea_de_produccion").HeaderText = "Linea de producción"
    End Sub
    Private Sub calcular_ppto_dia(ByRef dt As DataTable, ByVal dias_trabajados As Double, ByVal dias_habiles As Double)
        Dim ppto As Double = 0
        Dim ppto_por_dia As Double = 0
        For i = 0 To dt.Rows.Count - 2
            If Not IsDBNull(dt.Rows(i).Item("ppto_kilos")) Then
                ppto = dt.Rows(i).Item("ppto_kilos")
                ppto_por_dia = ppto / dias_habiles
                dt.Rows(i).Item("ppto_por_dia") = ppto_por_dia
            End If
        Next
    End Sub
    Private Sub totalizar_tipo_producto_dia(ByRef dt As DataTable)
        Dim sum As Double = 0
        Dim a As String = ""
        For j = 0 To dt.Columns.Count - 1
            a = dt.Columns(j).ColumnName
            If dt.Columns(j).ColumnName <> "tipo" And dt.Columns(j).ColumnName <> "id_cor" And dt.Columns(j).ColumnName <> "linea_de_produccion" Then
                For i = 0 To dt.Rows.Count - 2
                    If IsNumeric(dt.Rows(i).Item(j)) Then
                        sum += dt.Rows(i).Item(j)
                    End If
                    If IsDBNull(dt.Rows(i).Item("tipo")) Then
                        If i <> dt.Columns.Count - 1 Then
                            If (dt.Columns(j).ColumnName = "porc_cump") Then
                                If IsNumeric(dt.Rows(i).Item("ent_kilos")) And IsNumeric(dt.Rows(i).Item("ppto_kilos")) Then
                                    dt.Rows(i).Item(j) = (dt.Rows(i).Item("ent_kilos") / dt.Rows(i).Item("ppto_kilos")) * 100
                                End If
                            ElseIf dt.Columns(j).ColumnName = "porc_hoy" Then
                                If IsNumeric(dt.Rows(i).Item("ent_kilos")) And IsNumeric(dt.Rows(i).Item("ppto_a_hoy")) Then
                                    dt.Rows(i).Item(j) = (dt.Rows(i).Item("ent_kilos") / dt.Rows(i).Item("ppto_a_hoy")) * 100
                                End If
                            Else
                                dt.Rows(i).Item(j) = sum
                                sum = 0
                            End If
                        End If
                    End If
                Next
                sum = 0
            End If
        Next
    End Sub
    Private Sub totalizar_tipo_producto(ByRef dt As DataTable)
        Dim sum As Double = 0
        For j = 0 To dt.Columns.Count - 1
            If (dt.Columns(j).ColumnName = "ppto_en_kilos" Or dt.Columns(j).ColumnName = "cant_ppto" Or dt.Columns(j).ColumnName = "entradas" Or dt.Columns(j).ColumnName = "ppto_a_hoy" _
                Or dt.Columns(j).ColumnName = "kilos_ini" Or dt.Columns(j).ColumnName = "stock" Or dt.Columns(j).ColumnName = "kilos_ent" Or dt.Columns(j).ColumnName = "ent_kilos" Or dt.Columns(j).ColumnName = "ent_cant" _
                Or dt.Columns(j).ColumnName = "cos_ent" Or dt.Columns(j).ColumnName = "cos_ini" Or dt.Columns(j).ColumnName = "cos_sal" _
                    Or dt.Columns(j).ColumnName = "porc_cump" Or dt.Columns(j).ColumnName = "porc_hoy" Or dt.Columns(j).ColumnName = "stockB2") Then
                For i = 0 To dt.Rows.Count - 2
                    If Not IsDBNull(dt.Rows(i).Item(j)) Then
                        sum += dt.Rows(i).Item(j)
                    End If
                    If IsDBNull(dt.Rows(i).Item("tipo")) Then
                        If IsDBNull(dt.Rows(i).Item("tipo")) Then
                            If i <> dt.Columns.Count - 1 Then
                                If (dt.Columns(j).ColumnName = "porc_cump") Then
                                    If IsNumeric(dt.Rows(i).Item("ent_kilos")) And IsNumeric(dt.Rows(i).Item("ppto_en_kilos")) Then
                                        dt.Rows(i).Item(j) = (dt.Rows(i).Item("ent_kilos") / dt.Rows(i).Item("ppto_en_kilos")) * 100
                                    End If
                                ElseIf dt.Columns(j).ColumnName = "porc_hoy" Then
                                    If IsNumeric(dt.Rows(i).Item("ent_kilos")) And IsNumeric(dt.Rows(i).Item("ppto_a_hoy")) Then
                                        dt.Rows(i).Item(j) = (dt.Rows(i).Item("ent_kilos") / dt.Rows(i).Item("ppto_a_hoy")) * 100
                                    End If
                                Else
                                    dt.Rows(i).Item(j) = sum
                                    sum = 0
                                End If
                            End If
                        End If
                    End If
                Next
                sum = 0
            End If
        Next
    End Sub
    Private Sub addInventarios(ByRef dt As DataTable, ByVal dia As Boolean)
        For i = 0 To dt.Rows.Count - 1
            If Not IsDBNull(dt.Rows(i).Item("id_cor")) Then
                'algunos alambres
                If (dt.Rows(i).Item("id_cor") = 2 Or dt.Rows(i).Item("id_cor") = 4 Or
                     dt.Rows(i).Item("id_cor") = 91) Then
                    If dia Then
                        add_transaccion_dia(dt, i, "EPPT")
                    Else
                        add_transaccion(dt, i, "EPPT")
                    End If
                    'Alambre brillante,galvanizado,puas     
                ElseIf (dt.Rows(i).Item("id_cor") = 1 Or dt.Rows(i).Item("id_cor") = 5 Or dt.Rows(i).Item("id_cor") = 6 Or dt.Rows(i).Item("id_cor") = 3) Then
                    If dia Then
                        add_transaccion_dia(dt, i, "EPPT")
                    Else
                        add_transaccion(dt, i, "EPPP")
                    End If
                    ' clavos
                ElseIf (dt.Rows(i).Item("id_cor") = 8 Or dt.Rows(i).Item("id_cor") = 9 Or dt.Rows(i).Item("id_cor") = 10 Or dt.Rows(i).Item("id_cor") = 11 Or
                    dt.Rows(i).Item("id_cor") = 12 Or dt.Rows(i).Item("id_cor") = 13 Or dt.Rows(i).Item("id_cor") = 14 Or dt.Rows(i).Item("id_cor") = 16 Or dt.Rows(i).Item("id_cor") = 17 Or dt.Rows(i).Item("id_cor") = 27) Then
                    If dia Then
                        add_transaccion_dia(dt, i, "EDEP")
                    Else
                        add_transaccion(dt, i, "EDEP")
                    End If
                    'tornillos
                ElseIf (dt.Rows(i).Item("id_cor") = 19 Or dt.Rows(i).Item("id_cor") = 20 Or dt.Rows(i).Item("id_cor") = 21 Or dt.Rows(i).Item("id_cor") = 22 Or dt.Rows(i).Item("id_cor") = 23 _
                        Or dt.Rows(i).Item("id_cor") = 24) Then
                    If dia Then
                        add_transaccion_dia(dt, i, "ETV3")
                        'add_transaccion_dia(dt, i, "EDEP")
                    Else
                        add_transaccion(dt, i, "ETV3")
                        'add_transaccion(dt, i, "EDEP")
                    End If
                End If
            End If
        Next

    End Sub
    Private Sub addInventarios_detalle(ByRef dt As DataTable)
        For i = 0 To dt.Rows.Count - 1
            If Not IsDBNull(dt.Rows(i).Item("id_cor")) Then
                'alambres
                If (dt.Rows(i).Item("id_cor") = 1 Or dt.Rows(i).Item("id_cor") = 2 Or dt.Rows(i).Item("id_cor") = 3 Or dt.Rows(i).Item("id_cor") = 4 Or
                    dt.Rows(i).Item("id_cor") = 5 Or dt.Rows(i).Item("id_cor") = 6 Or dt.Rows(i).Item("id_cor") = 91) Then

                    add_transaccion_detalle(dt, i, "tipo IN('EPPT','EPPP')")

                    ' clavos
                ElseIf (dt.Rows(i).Item("id_cor") = 8 Or dt.Rows(i).Item("id_cor") = 9 Or dt.Rows(i).Item("id_cor") = 10 Or dt.Rows(i).Item("id_cor") = 11 Or
                    dt.Rows(i).Item("id_cor") = 12 Or dt.Rows(i).Item("id_cor") = 13 Or dt.Rows(i).Item("id_cor") = 14 Or dt.Rows(i).Item("id_cor") = 16 Or dt.Rows(i).Item("id_cor") = 17) Then

                    add_transaccion_detalle(dt, i, " tipo ='EDEP'")

                    'tornillos
                ElseIf (dt.Rows(i).Item("id_cor") = 19 Or dt.Rows(i).Item("id_cor") = 20 Or dt.Rows(i).Item("id_cor") = 21 Or dt.Rows(i).Item("id_cor") = 23 _
                        Or dt.Rows(i).Item("id_cor") = 24) Then
                    add_transaccion_detalle(dt, i, " tipo ='ETV3'")
                End If
            End If
        Next

    End Sub
    Private Sub add_transaccion(ByRef dt As DataTable, ByVal fila As Integer, ByVal transaccion As String)
        Dim id_cor As Integer = dt.Rows(fila).Item("id_cor")
        Dim where_codigo As String = ""
        If (id_cor) = 6 Then
            'where_codigo = "AND codigo NOT IN ('33G130125') "
        End If
        Dim Sql As String
        If transaccion = "EPPT" Then
            Sql = "SELECT id_cor,SUM(kilos)As ent_kilos,SUM(cantidad) As cant, SUM(cos_ent) As cos_ent " &
                 "FROM J_transacciones_kilos t  " &
               "WHERE codigo like '3%' AND id_cor = " & id_cor & "  AND ano =" & ano & " AND mes =" & mes & " AND (tipo='" & transaccion & "' or ((tipo ='TRB1') and modelo=11)) " & where_codigo &
                   "GROUP BY id_cor "

        ElseIf transaccion = "EDEP" Then
            Sql = "SELECT id_cor,SUM(kilos)As ent_kilos,SUM(cantidad) As cant, SUM(cos_ent) As cos_ent " &
               "FROM J_transacciones_kilos t  " &
             "WHERE codigo like '3%' AND id_cor = " & id_cor & "  AND ano =" & ano & " AND mes =" & mes & " AND (tipo='" & transaccion & "'  and modelo not in(02) ) " & where_codigo &
                 "GROUP BY id_cor "
        ElseIf transaccion = "EPPP" Then
            Sql = "SELECT id_cor,SUM(kilos)As ent_kilos,SUM(cantidad) As cant, SUM(cos_ent) As cos_ent " &
                "FROM J_transacciones_kilos t  " &
              "WHERE codigo like '3%' AND id_cor = " & id_cor & "  AND ano =" & ano & " AND mes =" & mes & " AND (tipo='" & transaccion & "' or tipo='EPPT') " & where_codigo &
                  "GROUP BY id_cor "
        Else
            Sql = "SELECT id_cor,tipo,SUM(kilos)As ent_kilos,SUM(cantidad) As cant, SUM(cos_ent) As cos_ent " &
             "FROM J_transacciones_kilos t  " &
              "WHERE codigo like '3%' AND id_cor = " & id_cor & " AND tipo = '" & transaccion & "' AND ano =" & ano & " AND mes =" & mes & " " & where_codigo &
                     "GROUP BY tipo,id_cor "
        End If
        Dim dt_consulta As DataTable = obj_op_simplesLn.listar_datatable(Sql, "CORSAN")
        For i = 0 To dt_consulta.Rows.Count - 1
            dt.Rows(fila).Item("ent_kilos") = dt_consulta.Rows(i).Item("ent_kilos")
            dt.Rows(fila).Item("ent_cant") = dt_consulta.Rows(i).Item("cant")
            dt.Rows(fila).Item("cos_ent") = dt_consulta.Rows(i).Item("cos_ent")
            addStock(dt, dt_consulta.Rows(i).Item("id_cor"), fila, 3, where_codigo)
            addStock(dt, dt_consulta.Rows(i).Item("id_cor"), fila, 2, where_codigo)
        Next
    End Sub
    Private Sub add_transaccion_detalle(ByRef dt As DataTable, ByVal fila As Integer, ByVal whereTransaccion As String)
        dt.Rows(fila).Item("ent_kilos") = 0
        dt.Rows(fila).Item("cant") = 0
        dt.Rows(fila).Item("cos_ent") = 0
        Dim id_cor As Integer = dt.Rows(fila).Item("id_cor")
        Dim id_item As String = dt.Rows(fila).Item("id_item")
        Dim sql_consulta_where As String = "SELECT script FROM J_ppto_porduccion_item WHERE id_item =" & id_item
        Dim where_id_item As String = obj_op_simplesLn.consultValorTodo(sql_consulta_where, "PRODUCCION")
        Dim where_codigo As String = ""
        Dim where_id_cor As String = " id_cor =" & id_cor & " AND "
        If (id_cor) = 6 Then
            'where_codigo = "AND codigo NOT IN ('33G130125') "
        End If
        where_codigo &= " " & where_id_item
        If (dt.Rows(fila).Item("id_cor") = 8 Or dt.Rows(fila).Item("id_cor") = 9 Or dt.Rows(fila).Item("id_cor") = 10 Or dt.Rows(fila).Item("id_cor") = 11 Or
                    dt.Rows(fila).Item("id_cor") = 12 Or dt.Rows(fila).Item("id_cor") = 13 Or dt.Rows(fila).Item("id_cor") = 14 Or dt.Rows(fila).Item("id_cor") = 16 Or dt.Rows(fila).Item("id_cor") = 17) Then
            where_id_cor = ""
        End If
        Dim sql As String
        If whereTransaccion = "tipo IN('EPPT','EPPP')" Then
            sql = "SELECT id_cor,SUM(kilos)As ent_kilos,SUM(cantidad) As cant, SUM(cos_ent) As cos_ent " &
               "FROM J_transacciones_kilos t  " &
                      "WHERE " & where_id_cor & "  ano =" & ano & " AND mes =" & mes & " and (" & whereTransaccion & " or ((tipo ='TRB1') and modelo=11))  " & where_codigo & " " &
                        "GROUP BY id_cor"
        Else
            sql = "SELECT id_cor,SUM(kilos)As ent_kilos,SUM(cantidad) As cant, SUM(cos_ent) As cos_ent " &
               "FROM J_transacciones_kilos t  " &
                      "WHERE " & where_id_cor & " " & whereTransaccion & " AND ano =" & ano & " AND mes =" & mes & " " & where_codigo & " " &
                        "GROUP BY id_cor"
        End If
        Dim dt_consulta As DataTable = obj_op_simplesLn.listar_datatable(Sql, "CORSAN")
        For i = 0 To dt_consulta.Rows.Count - 1
            dt.Rows(fila).Item("ent_kilos") += dt_consulta.Rows(i).Item("ent_kilos")
            dt.Rows(fila).Item("cant") += dt_consulta.Rows(i).Item("cant")
            dt.Rows(fila).Item("cos_ent") += dt_consulta.Rows(i).Item("cos_ent")
            addStock(dt, dt_consulta.Rows(i).Item("id_cor"), fila, 3, where_codigo)
        Next

    End Sub
    Private Sub add_transaccion_dia(ByRef dt As DataTable, ByVal fila As Integer, ByVal transaccion As String)
        Dim id_cor As Integer = dt.Rows(fila).Item("id_cor")
        Dim where_codigo As String = ""
        If (id_cor) = 6 Then
            'where_codigo = "AND codigo NOT IN ('33G130125') "
        End If
        Dim sql As String = ""
        Dim dt_consulta As New DataTable
        Dim fecha As Date
        If transaccion = "EPPT" Then
            sql = "SELECT fecha,id_cor,SUM(kilos)As ent_kilos,SUM(cantidad) As cant, SUM(cos_ent) As cos_ent " &
                    "FROM J_transacciones_kilos t  " &
                              "WHERE id_cor = " & id_cor & "  AND ano =" & ano & " AND mes =" & mes & " AND (tipo = '" & transaccion & "' or ((tipo ='TRB1') and modelo=11)) " & where_codigo &
                                    "GROUP BY fecha,id_cor "
        ElseIf transaccion = "EDEP" Then
            sql = "SELECT fecha,id_cor,SUM(kilos)As ent_kilos,SUM(cantidad) As cant, SUM(cos_ent) As cos_ent " &
               "FROM J_transacciones_kilos t  " &
                         "WHERE id_cor = " & id_cor & "  AND ano =" & ano & " AND mes =" & mes & " AND (tipo = '" & transaccion & "' and modelo not in (02)) " & where_codigo &
                               "GROUP BY fecha,id_cor "
        Else
            sql = "SELECT fecha,id_cor,tipo,SUM(kilos)As ent_kilos,SUM(cantidad) As cant, SUM(cos_ent) As cos_ent " &
                    "FROM J_transacciones_kilos t  " &
                              "WHERE id_cor = " & id_cor & " AND tipo = '" & transaccion & "' AND ano =" & ano & " AND mes =" & mes & " " & where_codigo &
                                    "GROUP BY fecha,tipo,id_cor "
        End If
        dt_consulta = obj_op_simplesLn.listar_datatable(sql, "CORSAN")
        For i = 0 To dt_consulta.Rows.Count - 1
            For j = 0 To dt.Columns.Count - 1
                If IsDate(dt.Columns(j).ColumnName) Then
                    fecha = dt.Columns(j).ColumnName
                    If dt_consulta.Rows(i).Item("fecha") = fecha Then
                        dt.Rows(fila).Item(j) = dt_consulta.Rows(i).Item("ent_kilos")
                        j = dt.Columns.Count - 1
                    End If
                End If
            Next
        Next
    End Sub

    Private Sub addStock(ByRef dt As DataTable, ByVal id_cor As String, ByVal fila As Integer, ByVal bodega As Integer, ByVal where_codigo As String)
        Dim sql As String
        If bodega = 2 Then
            sql = "SELECT SUM(stock) AS stockB2 FROM dbo.v_referencias_sto_hoy " &
                                            " WHERE id_cor = " & id_cor & "  AND bodega = " & bodega & " and codigo like '3%' "
        Else
            sql = "SELECT SUM(stock) AS stock FROM dbo.v_referencias_sto_hoy " &
                                            " WHERE id_cor = " & id_cor & "  AND bodega = " & bodega & " " & where_codigo
        End If
        Dim val As String = obj_op_simplesLn.consultarVal(sql)
        If val = "" Then
            val = 0
        End If
        If bodega = 2 Then
            dt.Rows(fila).Item("stockB2") = 0
            If IsNumeric(dt.Rows(fila).Item("id_cor")) Then
                dt.Rows(fila).Item("stockB2") += val
            End If
        Else
            dt.Rows(fila).Item("stock") = 0
            If IsNumeric(dt.Rows(fila).Item("id_cor")) Then
                dt.Rows(fila).Item("stock") += val
            End If
        End If
    End Sub
    Private Function armar_dt(ByVal dias_habiles_otros As Double, ByVal dias_adic_otros As Double, ByVal dias_habiles As Double, ByVal dias_adic As Double) As DataTable
        Dim sql As String = "SELECT g.id_cor,g.descripcion As linea_de_produccion , g.tipo,t.descripcion As desc_tipo , SUM(p.kilos) As ppto_en_kilos , (AVG(p.kilos)/ AVG(g.conversion) ) As ppto_en_cant   " &
                                "FROM JJV_Grupos_seguimiento g ,PRGPRODUCCION.dbo.J_ppto_produccion p , Jjv_grupos_seguimiento_clasificacion t " &
                                    "WHERE t.id = g.tipo AND g.id_cor = p.id_cor AND p.ano = " & ano & " AND p.mes = " & mes & " AND g.id_cor NOT IN (26,31) " &
                                    "GROUP BY g.id_cor,g.descripcion ,g.orden, g.tipo,t.descripcion " &
                                       "ORDER BY g.orden"
        Dim dt As DataTable = obj_op_simplesLn.listar_datatable(sql, "CORSAN")
        dt.Columns.Add("dias_habiles", GetType(Double))
        dt.Columns.Add("dias_adicionales", GetType(Double))
        Dim dt_final As New DataTable
        Dim tipo_Ant As Integer = 0
        Dim desc_tipo_ant As String = ""
        For j = 0 To dt.Columns.Count - 1
            If dt.Columns(j).ColumnName = "linea_de_produccion" Or dt.Columns(j).ColumnName = "desc_tipo" Then
                dt_final.Columns.Add(dt.Columns(j).ColumnName)
            Else
                dt_final.Columns.Add(dt.Columns(j).ColumnName, GetType(Double))
            End If
        Next
        For i = 0 To dt.Rows.Count - 1
            If Not IsDBNull(dt.Rows(i).Item("tipo")) Then
                If dt.Rows(i).Item("id_cor") = 6 Then
                    dt.Rows(i).Item("dias_habiles") = dias_habiles_otros + dias_adic_otros
                    dt.Rows(i).Item("dias_adicionales") = dias_adic_otros
                Else
                    dt.Rows(i).Item("dias_habiles") = dias_habiles
                    dt.Rows(i).Item("dias_adicionales") = dias_adic
                End If
                If tipo_Ant <> (dt.Rows(i).Item("tipo")) Then
                    If tipo_Ant <> 0 Then
                        dt_final.Rows.Add()
                        dt_final.Rows(dt_final.Rows.Count - 1).Item("linea_de_produccion") = "TOTAL " & desc_tipo_ant
                    End If
                    tipo_Ant = (dt.Rows(i).Item("tipo"))
                    desc_tipo_ant = dt.Rows(i).Item("desc_tipo")
                End If
                dt_final.Rows.Add()
                For j = 0 To dt.Columns.Count - 1
                    dt_final.Rows(dt_final.Rows.Count - 1).Item(dt.Columns(j).ColumnName) = dt.Rows(i).Item(j)
                Next
            End If
        Next
        dt_final.Columns.Add("ent_cant", GetType(Double))
        dt_final.Columns.Add("ent_kilos", GetType(Double))
        dt_final.Columns.Add("stock", GetType(Double))
        dt_final.Columns.Add("stockB2", GetType(Double))
        dt_final.Columns.Add("cos_ent", GetType(Double))
        Return dt_final
    End Function
    Private Function armar_dt_detalle() As DataTable
        Dim sql As String = "SELECT i.id_item ,i.id_cor,i.descripcion As linea_de_produccion,d.kilos As ppto_en_kilos,g.tipo ,g.Descripcion_tipo As desc_tipo " &
                                       "FROM J_ppto_porduccion_item i , J_ppto_produccion_detalle d ,CORSAN.dbo.JJV_Grupos_seguimiento g  " &
                                           "WHERE i.id_item = d.id_ppto_prod_item AND g.Id_cor = i.id_cor AND mes =" & cbo_mes.SelectedIndex + 1 & " AND ano = " & cbo_ano.Text & " " &
                                               "ORDER BY i.orden"
        Dim dt As DataTable = obj_op_simplesLn.listar_datatable(sql, "PRODUCCION")
        Dim dt_final As New DataTable
        Dim tipo_Ant As Integer = 0
        Dim desc_tipo_ant As String = ""
        For j = 0 To dt.Columns.Count - 1
            If dt.Columns(j).ColumnName = "linea_de_produccion" Or dt.Columns(j).ColumnName = "desc_tipo" Then
                dt_final.Columns.Add(dt.Columns(j).ColumnName)
            Else
                dt_final.Columns.Add(dt.Columns(j).ColumnName, GetType(Double))
            End If
        Next
        For i = 0 To dt.Rows.Count - 1
            If Not IsDBNull(dt.Rows(i).Item("tipo")) Then
                If tipo_Ant <> (dt.Rows(i).Item("tipo")) Then
                    If tipo_Ant <> 0 Then
                        dt_final.Rows.Add()
                        dt_final.Rows(dt_final.Rows.Count - 1).Item("linea_de_produccion") = "TOTAL " & desc_tipo_ant
                    End If
                    tipo_Ant = (dt.Rows(i).Item("tipo"))
                    desc_tipo_ant = dt.Rows(i).Item("desc_tipo")
                End If
                dt_final.Rows.Add()
                For j = 0 To dt.Columns.Count - 1
                    dt_final.Rows(dt_final.Rows.Count - 1).Item(dt.Columns(j).ColumnName) = dt.Rows(i).Item(j)
                Next
            End If
        Next
        dt_final.Columns.Add("cant", GetType(Double))
        dt_final.Columns.Add("ent_kilos", GetType(Double))
        dt_final.Columns.Add("stock", GetType(Double))
        dt_final.Columns.Add("cos_ent", GetType(Double))

        Return dt_final
    End Function
    Private Function armar_dt_dia() As DataTable
        Dim sql As String = "SELECT g.id_cor,g.descripcion As linea_de_produccion , g.tipo,t.descripcion As desc_tipo , SUM(p.kilos) As ppto_kilos , (AVG(p.kilos)/ AVG(g.conversion) ) As cant_ppto, p.dias_habiles, p.dias_adicionales   " &
                                "FROM JJV_Grupos_seguimiento g ,PRGPRODUCCION.dbo.J_ppto_produccion p , Jjv_grupos_seguimiento_clasificacion t " &
                                    "WHERE t.id = g.tipo AND g.id_cor = p.id_cor AND p.ano = " & ano & " AND p.mes = " & mes & " AND g.id_cor NOT IN (7, 18,15,22,25,26,29,31) " &
                                    "GROUP BY g.id_cor,g.descripcion , p.dias_habiles, p.dias_adicionales,g.orden, g.tipo,t.descripcion " &
                                       "ORDER BY g.orden"
        Dim dt As DataTable = obj_op_simplesLn.listar_datatable(sql, "CORSAN")
        Dim dt_final As New DataTable
        Dim tipo_Ant As Integer = 0
        Dim desc_tipo_ant As String = ""
        For j = 0 To dt.Columns.Count - 1
            If dt.Columns(j).ColumnName = "linea_de_produccion" Or dt.Columns(j).ColumnName = "desc_tipo" Then
                dt_final.Columns.Add(dt.Columns(j).ColumnName)
            Else
                dt_final.Columns.Add(dt.Columns(j).ColumnName, GetType(Double))
            End If
        Next
        dt_final.Columns.Add("ppto_por_dia", GetType(Double))
        For i = 0 To dt.Rows.Count - 1
            If Not IsDBNull(dt.Rows(i).Item("tipo")) Then
                If tipo_Ant <> (dt.Rows(i).Item("tipo")) Then
                    If tipo_Ant <> 0 Then
                        dt_final.Rows.Add()
                        dt_final.Rows(dt_final.Rows.Count - 1).Item("linea_de_produccion") = "TOTAL " & desc_tipo_ant
                    End If
                    tipo_Ant = (dt.Rows(i).Item("tipo"))
                    desc_tipo_ant = dt.Rows(i).Item("desc_tipo")
                End If
                dt_final.Rows.Add()
                For j = 0 To dt.Columns.Count - 1
                    dt_final.Rows(dt_final.Rows.Count - 1).Item(dt.Columns(j).ColumnName) = dt.Rows(i).Item(j)
                Next
            End If
        Next
        dt_final.Rows.Add()
        Return dt_final
    End Function
    Private Function armar_dt_dia_area() As DataTable
        Dim sql As String = "SELECT c.centro,c.descripcion,p.kilos/(dias_habiles + dias_adicionales )As ppto_dia " &
                                    "FROM J_ppto_prod_area p , CORSAN.dbo.centros c " &
                                       "WHERE p.centro = c.centro And mes = " & mes & " And ano =  " & ano & " " &
                                            "ORDER BY p.centro"
        Dim dt As DataTable = obj_op_simplesLn.listar_datatable(sql, "PRODUCCION")
        Return dt
    End Function
    Private Sub addDias(ByRef dt As DataTable)
        Dim nom_dia As String = ""
        Dim fec_ini As String = ano & "-" & mes & "-01"
        Dim fec_fin As Date = obj_op_simplesLn.cambiarFormatoFecha(DateSerial(ano, mes + 1, Now.Day))
        Dim sql As String = "SELECT fecha,sabado,domingo,festivo FROM y_calendario WHERE fecha>= '" & obj_op_simplesLn.cambiarFormatoFecha(fec_ini) & "' AND fecha <= '" & obj_op_simplesLn.cambiarFormatoFecha(fec_fin) & "' order by fecha"
        Dim dt_dias As DataTable = obj_op_simplesLn.listar_datatable(sql, "CORSAN")
        Dim fec As Date
        For i = 0 To dt_dias.Rows.Count - 1
            fec = dt_dias.Rows(i).Item("fecha")
            nom_dia = fec.Day & "-" & MonthName(fec.Month)
            dt.Columns.Add(dt_dias.Rows(i).Item("fecha"), GetType(Double))
            ' dt.Rows(dt.Rows.Count - 2).Item(nom_dia) = dt_dias.Rows(i).Item("fecha")
        Next
    End Sub
    Private Sub consumo_alambron(ByVal mes As Integer, ByVal ano As Integer, ByVal dias_trabajados As Double, ByVal dias_habiles As Double)
        Dim dt As New DataTable
        Dim ppto_por_dia As Double = 0
        Dim valor As String = ""
        Dim sum_brillantes_especiales As Double = 0
        Dim sum_smpp As Double = 0
        Dim sql_ppto_consumo_alambron As String = "SELECT SUM(kilos) FROM J_ppto_prod_consumo_alambron WHERE mes = " & mes & " AND ano = " & ano
        Dim ppto_consumo_alambron As String = obj_op_simplesLn.consultValorTodo(sql_ppto_consumo_alambron, "PRODUCCION")
        If ppto_consumo_alambron = "" Then
            ppto_consumo_alambron = 0
        End If
        Dim sql_ppto_reproceso As String = "SELECT SUM(kilos) FROM J_ppto_prod_reproceso WHERE mes = " & mes & " AND ano = " & ano
        Dim ppto_reproceso As String = obj_op_simplesLn.consultValorTodo(sql_ppto_reproceso, "PRODUCCION")
        If ppto_reproceso = "" Then
            ppto_reproceso = 0
        End If
        Dim sql_consumo As String = "SELECT SUM(lin.cantidad)As cantidad " &
               "FROM documentos_lin lin , documentos doc " &
                      "		WHERE doc.numero = lin.numero  AND YEAR(lin.fec)= " & ano & " AND MONTH(lin.fec )= " & mes & " AND lin.codigo like '11%' AND lin.bodega = 2 AND doc.tipo IN ('SMPP') AND lin.tipo = doc.tipo AND doc.bodega = lin.bodega  "
        valor = obj_op_simplesLn.consultarVal(sql_consumo)
        If valor <> "" Then
            sum_smpp = valor
        Else
            sum_smpp = 0
        End If
        valor = 0
        Dim sql_brillantes_especiales As String = "SELECT SUM(lin.cantidad)As cantidad " &
              "FROM documentos_lin lin , documentos doc " &
                     "WHERE doc.numero = lin.numero AND lin.tipo = doc.tipo AND doc.bodega = lin.bodega AND lin.tipo IN ('EPPP','EPPT') AND (lin.codigo like '22b%' or lin.codigo like '33b%' or lin.codigo like '22x%' or lin.codigo like '33x%' )  AND YEAR(lin.fec)= " & ano & " AND MONTH(lin.fec )= " & mes
        valor = obj_op_simplesLn.consultarVal(sql_brillantes_especiales)
        If valor <> "" Then
            sum_brillantes_especiales = valor
        Else
            sum_brillantes_especiales = 0
        End If

        dt.Columns.Add("descripcion")
        dt.Columns.Add("Presupuesto", GetType(Double))
        dt.Columns.Add("produccion", GetType(Double))
        dt.Columns.Add("ppto_a_hoy", GetType(Double))
        dt.Columns.Add("porc_cump", GetType(Double))
        dt.Columns.Add("porc_hoy", GetType(Double))

        dt.Rows.Add()
        dt.Rows(dt.Rows.Count - 1).Item("descripcion") = "CONSUMO DE ALAMBRON"
        dt.Rows(dt.Rows.Count - 1).Item("Presupuesto") = ppto_consumo_alambron
        dt.Rows(dt.Rows.Count - 1).Item("produccion") = sum_smpp
        ppto_por_dia = ppto_consumo_alambron / dias_habiles
        dt.Rows(dt.Rows.Count - 1).Item("ppto_a_hoy") = ppto_por_dia * dias_trabajados

        dt.Rows.Add()
        dt.Rows(dt.Rows.Count - 1).Item("descripcion") = "PXN CON REPROCESO"
        dt.Rows(dt.Rows.Count - 1).Item("Presupuesto") = ppto_reproceso
        dt.Rows(dt.Rows.Count - 1).Item("produccion") = sum_brillantes_especiales
        ppto_por_dia = ppto_reproceso / dias_habiles
        dt.Rows(dt.Rows.Count - 1).Item("ppto_a_hoy") = ppto_por_dia * dias_trabajados

        calcular_cump_consumo(dt)
        dtg_consumo_alambron.DataSource = dt
        formatoDtg_consumo()
    End Sub
    Private Sub calcular_ppto_a_hoy(ByRef dt As DataTable, ByVal dias_trabajados As Double, ByVal dias_habiles As Double, ByVal dias_habiles_otros As Double, ByVal dias_trabajados_otros As Double)
        dt.Columns.Add("ppto_a_hoy", GetType(Double))
        dt.Columns.Add("ppto_por_dia", GetType(Double))
        dt.Columns.Add("porc_hoy", GetType(Double))
        dt.Columns.Add("dias_trab", GetType(Double))
        Dim ppto As Double = 0
        Dim ppto_por_dia As Double = 0
        Dim es_otra_area As Boolean = False
        For i = 0 To dt.Rows.Count - 2
            If Not IsDBNull(dt.Rows(i).Item("ppto_en_kilos")) Then
                ppto = dt.Rows(i).Item("ppto_en_kilos")
                If IsNumeric(dt.Rows(i).Item("id_Cor")) Then
                    If dt.Rows(i).Item("id_Cor") = 6 Then
                        es_otra_area = True
                    End If
                End If
                If es_otra_area Then
                    ppto_por_dia = ppto / dias_habiles_otros
                    dt.Rows(i).Item("ppto_a_hoy") = ppto_por_dia * dias_trabajados_otros
                    dt.Rows(i).Item("dias_trab") = dias_trabajados_otros
                Else
                    ppto_por_dia = ppto / dias_habiles
                    dt.Rows(i).Item("ppto_a_hoy") = ppto_por_dia * dias_trabajados
                    dt.Rows(i).Item("dias_trab") = dias_trabajados
                End If
                dt.Rows(i).Item("ppto_por_dia") = ppto_por_dia
            End If
            es_otra_area = False
        Next
    End Sub
    Private Sub eliminar_sin_ppto(ByRef dt As DataTable)
        For i = 0 To dt.Rows.Count - 1
            If i < dt.Rows.Count Then
                If Not IsDBNull(dt.Rows(i).Item("id_cor")) Then
                    If IsDBNull(dt.Rows(i).Item("ppto_en_kilos")) Then
                        dt.Rows(i).Delete()
                    ElseIf (dt.Rows(i).Item("ppto_en_kilos") = 0) Then
                        dt.Rows(i).Delete()
                    End If
                End If
            End If
        Next
    End Sub
    Private Sub calcular_cumplimiento(ByRef dt As DataTable)
        Dim sum_ppto As Double = 0
        Dim sum_ppto_dia As Double = 0
        Dim sum_entradas As Double = 0
        If dt.Rows.Count > 0 Then
            For i = 0 To dt.Rows.Count - 2
                If IsNumeric(dt.Rows(i).Item("ent_kilos")) Then
                    If (dt.Rows(i).Item("ppto_en_kilos") = 0 Or dt.Rows(i).Item("ent_kilos") = 0) Then
                        dt.Rows(i).Item("porc_cump") = 0
                    Else
                        dt.Rows(i).Item("porc_cump") = (dt.Rows(i).Item("ent_kilos") / dt.Rows(i).Item("ppto_en_kilos")) * 100
                        sum_entradas += dt.Rows(i).Item("ent_kilos")
                    End If
                    If (dt.Rows(i).Item("ppto_a_hoy") = 0 Or dt.Rows(i).Item("ent_kilos") = 0) Then
                        dt.Rows(i).Item("porc_cump") = 0
                    Else
                        dt.Rows(i).Item("porc_hoy") = (dt.Rows(i).Item("ent_kilos") / dt.Rows(i).Item("ppto_a_hoy")) * 100
                    End If
                End If
                If IsNumeric(dt.Rows(i).Item("ppto_a_hoy")) Then
                    sum_ppto_dia += dt.Rows(i).Item("ppto_a_hoy")
                End If
                If IsNumeric(dt.Rows(i).Item("ppto_en_kilos")) Then
                    sum_ppto += dt.Rows(i).Item("ppto_en_kilos")
                End If
            Next
            dt.Rows(dt.Rows.Count - 1).Item("porc_cump") = (sum_entradas / sum_ppto) * 100
            dt.Rows(dt.Rows.Count - 1).Item("porc_hoy") = (sum_entradas / sum_ppto_dia) * 100
        End If
    End Sub
    Private Sub calcular_cump_consumo(ByRef dt As DataTable)
        Dim sum_ppto As Double = 0
        Dim sum_ppto_dia As Double = 0
        Dim sum_entradas As Double = 0
        For i = 0 To dt.Rows.Count - 1
            If (dt.Rows(i).Item("Presupuesto") = 0 Or dt.Rows(i).Item("produccion") = 0) Then
                dt.Rows(i).Item("porc_cump") = 0
            Else
                dt.Rows(i).Item("porc_cump") = (dt.Rows(i).Item("produccion") / dt.Rows(i).Item("Presupuesto")) * 100
                sum_ppto += dt.Rows(i).Item("Presupuesto")
                sum_entradas += dt.Rows(i).Item("produccion")
            End If
            If (dt.Rows(i).Item("ppto_a_hoy") = 0 Or dt.Rows(i).Item("produccion") = 0) Then
                dt.Rows(i).Item("porc_cump") = 0
            Else
                dt.Rows(i).Item("porc_hoy") = (dt.Rows(i).Item("produccion") / dt.Rows(i).Item("ppto_a_hoy")) * 100
                sum_ppto_dia += dt.Rows(i).Item("ppto_a_hoy")
            End If
        Next
    End Sub
    Private Sub btn_actualizar_Click(sender As Object, e As EventArgs) Handles btn_actualizar.Click
        carga_comp = False
        consultar()
        carga_comp = True
    End Sub
    Private Sub inventarios_b2()
        Dim view As New DataView
        Dim BindingSource1 As New BindingSource
        Dim sum As Double = 0
        'Dim sql As String = "SELECT g.orden,g.id_cor,g.Descripcion as linea_produccion, s.bodega,SUM(s.can_ini)As can_ini,SUM(s.can_ent)As can_ent,SUM(s.can_sal)As can_sal,((SUM(s.can_ini)+SUM(s.can_ent)) -SUM(s.can_sal))As stock , SUM(s.cos_ini)As cos_ini,SUM(cos_ent)As cos_ent,SUM(cos_sal)As cos_sal,((SUM(s.cos_ini)+SUM(s.cos_ent)) -SUM(s.cos_sal))As costo_stock " & _
        '                        "FROM referencias_sto s , referencias r ,JJV_Grupos_seguimiento g " & _
        '                             "WHERE r.codigo = s.codigo AND mes = " & mes & " AND ano = " & ano & "   AND g.Id_cor = r.Id_cor  AND bodega = 2 " & _
        '                                "GROUP BY g.id_cor,s.bodega ,g.Descripcion,g.orden   " & _
        '                                    "ORDER BY g.orden "
        Dim sql As String = "SELECT orden,id_cor,linea_produccion, SUM(kilos_ini)As kilos_ini,SUM(kilos_ent)As kilos_ent,SUM(kilos_sal)As kilos_sal,SUM(kilos_stock) As  kilos_stock , SUM(cos_ini)As cos_ini,SUM(cos_ent)As cos_ent,SUM(cos_sal)As cos_sal,SUM(costo_stock)As costo_stock " &
                             "FROM J_v_ref_sto_kilos " &
                                "WHERE  codigo like'2%' AND mes = " & mes & " AND ano =" & ano & " AND id_cor NOT IN (30,7) and Bodega not in(4)" &
                                 "GROUP BY id_cor,linea_produccion,orden   " &
                                     "ORDER BY orden "
        Dim dt As DataTable = obj_op_simplesLn.listar_datatable(sql, "CORSAN")
        add_inv_b2(dt, " AND codigo like '22R%' AND codigo NOT IN ('22R100142','33R100142P')", 2)
        dt.Rows.Add()
        dt.Rows(dt.Rows.Count - 1).Item("id_cor") = 91
        dt.Rows(dt.Rows.Count - 1).Item("linea_produccion") = "ALAMBRE RECOCIDO DE CONSTRUCCION"
        dt.Rows(dt.Rows.Count - 1).Item("orden") = 3
        add_inv_b2(dt, " AND codigo like '22R%' AND codigo IN ('22R100142')", 91)
        dt.Rows.Add()
        dt.Rows(dt.Rows.Count - 1).Item("orden") = 200
        For j = 0 To dt.Columns.Count - 1
            If (dt.Columns(j).ColumnName = "kilos_ini" Or dt.Columns(j).ColumnName = "kilos_ent" Or dt.Columns(j).ColumnName = "kilos_sal" Or dt.Columns(j).ColumnName = "kilos_stock" Or dt.Columns(j).ColumnName = "cos_ent" Or dt.Columns(j).ColumnName = "cos_ent" Or dt.Columns(j).ColumnName = "cos_sal" Or dt.Columns(j).ColumnName = "costo_stock" Or dt.Columns(j).ColumnName = "cos_ini") Then
                For i = 0 To dt.Rows.Count - 2
                    If Not IsDBNull(dt.Rows(i).Item(j)) Then
                        sum += dt.Rows(i).Item(j)
                    End If
                Next
                dt.Rows(dt.Rows.Count - 1).Item(j) = sum
                sum = 0
            ElseIf (dt.Columns(j).ColumnName = "linea_produccion") Then
                dt.Rows(dt.Rows.Count - 1).Item(j) = "TOTAL"
            End If
        Next
        BindingSource1.DataSource = dt
        view = New DataView(dt)
        view.Sort = "orden"
        dtg_inv_b2.DataSource = view
        For i = 0 To dtg_inv_b2.Rows.Count - 2
            If dtg_inv_b2.Item("id_cor", i).Value <> 91 Then
                If Convert.ToInt32(dtg_inv_b2.Item("kilos_ini", i).Value) = 0 And Convert.ToInt32(dtg_inv_b2.Item("kilos_ent", i).Value) = 0 And Convert.ToInt32(dtg_inv_b2.Item("kilos_sal", i).Value) = 0 Then
                    dtg_inv_b2.Rows(i).Visible = False
                End If
            End If
        Next
        dtg_inv_b2.Columns("id_cor").Visible = False
        dtg_inv_b2.Columns("orden").Visible = False
        dtg_inv_b2.Columns("kilos_stock").DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        dtg_inv_b2.Rows(dtg_inv_b2.Rows.Count - 1).DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
    End Sub
    Private Sub bodega_2_nc()
        Dim sql = "select g.orden,g.id_cor,g.Descripcion as linea_produccion,sum(d.cantidad) as tot_nc from  documentos_lin d  inner join referencias r on d.codigo=r.codigo  inner join JJV_Grupos_seguimiento g on r.Id_cor=g.Id_cor inner join documentos l on d.numero=l.numero and d.tipo=l.tipo" &
            " where d.tipo='EIPP' and l.modelo in (2,3) and year(d.fec) = " & cbo_ano.Text & " and month(d.fec) = " & cbo_mes.SelectedIndex + 1 & " AND g.id_cor NOT IN (30,7) GROUP BY g.id_cor,g.Descripcion,g.orden order by orden"
        Dim dt_datos As DataTable = obj_op_simplesLn.listar_datatable(sql, "CORSAN")
        dtg_nc.DataSource = dt_datos
    End Sub
    Private Sub add_inv_b2(ByRef dt As DataTable, ByVal where_codigo As String, ByVal id_cor As Integer)
        Dim sql As String = "SELECT orden,id_cor,linea_produccion, SUM(kilos_ini)As kilos_ini,SUM(kilos_ent)As kilos_ent,SUM(kilos_sal)As kilos_sal,SUM(kilos_stock) As  kilos_stock , SUM(cos_ini)As cos_ini,SUM(cos_ent)As cos_ent,SUM(cos_sal)As cos_sal,SUM(costo_stock) as costo_stock " &
                           "FROM J_v_ref_sto_kilos " &
                              "WHERE  codigo like'2%' AND mes = " & mes & " AND ano =" & ano & " " & where_codigo & " and bodega not in (4)" &
                                  "GROUP BY id_cor,linea_produccion,orden   " &
                                   "ORDER BY orden "
        Dim dt_datos As DataTable = obj_op_simplesLn.listar_datatable(sql, "CORSAN")
        For i = 0 To dt.Rows.Count - 1
            If dt.Rows(i).Item("id_cor") = id_cor Then
                For j = 0 To dt_datos.Columns.Count - 1
                    For k = 0 To dt_datos.Rows.Count - 1
                        If (dt_datos.Columns(j).ColumnName) <> "linea_produccion" And (dt_datos.Columns(j).ColumnName) <> "orden)" Then
                            dt.Rows(i).Item(dt_datos.Columns(j).ColumnName) = dt_datos.Rows(k).Item(j)
                        End If
                    Next
                Next
            End If
        Next
    End Sub
    Private Sub formatoDia()
        Dim nom_col As String = ""
        Dim tamano_letra As Single = 7.5!
        If dtg_seg_ppto_dia.Rows.Count > 0 Then
            dtg_seg_ppto_dia.Item("linea_de_produccion", dtg_seg_ppto_dia.Rows.Count - 1).Value = "TOTAL"
            For j = 0 To dtg_seg_ppto_dia.Columns.Count - 1
                nom_col = dtg_seg_ppto_dia.Columns(j).Name
                If (nom_col = "tipo" Or nom_col = "desc_tipo" Or nom_col = "id_cor" Or nom_col = "ppto_kilos" Or nom_col = "cant_ppto" Or nom_col = "dias_habiles" Or nom_col = "dias_adicionales") Then
                    dtg_seg_ppto_dia.Columns(j).Visible = False
                ElseIf (nom_col = "linea_de_produccion") Then
                    dtg_seg_ppto_dia.Columns(j).Frozen = True
                End If
            Next
            For i = 0 To dtg_seg_ppto_dia.Rows.Count - 1
                If IsDBNull(dtg_seg_ppto_dia.Item("id_cor", i).Value) Then
                    dtg_seg_ppto_dia.Rows(i).DefaultCellStyle = objOperacionesForm.formatoNegrita(tamano_letra)
                End If
            Next
        End If
    End Sub
    Private Sub formatoDia_area()
        Dim nom_col As String = ""
        Dim tamano_letra As Single = 7.5!
        dtg_seg_dia_area.Columns("ppto_dia").DefaultCellStyle = objOperacionesForm.formatoNegrita(tamano_letra)
        dtg_seg_dia_area.Rows(dtg_seg_dia_area.Rows.Count - 1).DefaultCellStyle = objOperacionesForm.formatoNegrita(tamano_letra)
        For j = 0 To dtg_seg_dia_area.Columns.Count - 1
            nom_col = dtg_seg_dia_area.Columns(j).Name
            If (nom_col = "centro" Or nom_col = "descripcion" Or nom_col = "ppto_dia") Then
                dtg_seg_dia_area.Columns(j).Frozen = True
            End If
        Next
    End Sub
    Private Sub formatoDtg()
        Dim nom_col As String = ""
        Dim tamano_letra As Single = 7.5!
        If dtg_presupuesto.Rows.Count > 0 Then
            dtg_presupuesto.Item("linea_de_produccion", dtg_presupuesto.Rows.Count - 1).Value = "TOTAL"
            dtg_presupuesto.Columns("porc_cump").DefaultCellStyle = objOperacionesForm.formatoNegrita(tamano_letra)
            dtg_presupuesto.Columns("porc_cump").DefaultCellStyle.Format = "N2"
            dtg_presupuesto.Columns("porc_hoy").DefaultCellStyle = objOperacionesForm.formatoNegrita(tamano_letra)
            dtg_presupuesto.Columns("ent_kilos").DefaultCellStyle = objOperacionesForm.formatoNegrita(tamano_letra)
            dtg_presupuesto.Columns("porc_hoy").DefaultCellStyle.Format = "N2"
            dtg_presupuesto.Columns("dias_adicionales").DefaultCellStyle.Format = "N1"
            dtg_presupuesto.Columns("dias_trab").DefaultCellStyle.Format = "N1"
            dtg_presupuesto.Columns("dias_habiles").DefaultCellStyle.Format = "N1"
            For j = 0 To dtg_presupuesto.Columns.Count - 1
                nom_col = dtg_presupuesto.Columns(j).Name
                If (nom_col = "porc_hoy" Or nom_col = "porc_cump") Then
                    For i = 0 To dtg_presupuesto.Rows.Count - 1
                        If Not IsDBNull(dtg_presupuesto.Item(j, i).Value) Then
                            If (dtg_presupuesto.Item(j, i).Value > 100) Then
                                dtg_presupuesto.Item(j, i).Style.BackColor = Color.GreenYellow
                            ElseIf dtg_presupuesto.Item(j, i).Value >= 90 And dtg_presupuesto.Item(j, i).Value <= 99 Then
                                dtg_presupuesto.Item(j, i).Style.BackColor = Color.Yellow
                            Else
                                dtg_presupuesto.Item(j, i).Style.BackColor = Color.Red
                            End If
                        Else
                            dtg_presupuesto.Item(j, i).Style.BackColor = Color.Red
                        End If
                    Next
                ElseIf (nom_col = "tipo" Or nom_col = "desc_tipo") Then
                    dtg_presupuesto.Columns(nom_col).Visible = False
                End If
            Next
            For i = 0 To dtg_presupuesto.Rows.Count - 1
                If IsDBNull(dtg_presupuesto.Item("id_cor", i).Value) Then
                    dtg_presupuesto.Rows(i).DefaultCellStyle = objOperacionesForm.formatoNegrita(tamano_letra)
                End If
            Next
        End If
    End Sub
    Private Sub formatoDtg_detalle()
        Dim nom_col As String = ""
        Dim tamano_letra As Single = 7.5!
        If dtg_ppto_detalle.Rows.Count > 0 Then
            dtg_ppto_detalle.Item("linea_de_produccion", dtg_ppto_detalle.Rows.Count - 1).Value = "TOTAL"
            dtg_ppto_detalle.Columns("porc_cump").DefaultCellStyle = objOperacionesForm.formatoNegrita(tamano_letra)
            dtg_ppto_detalle.Columns("porc_cump").DefaultCellStyle.Format = "N2"
            dtg_ppto_detalle.Columns("porc_hoy").DefaultCellStyle = objOperacionesForm.formatoNegrita(tamano_letra)
            dtg_ppto_detalle.Columns("ent_kilos").DefaultCellStyle = objOperacionesForm.formatoNegrita(tamano_letra)
            dtg_ppto_detalle.Columns("porc_hoy").DefaultCellStyle.Format = "N2"
            For j = 0 To dtg_ppto_detalle.Columns.Count - 1
                nom_col = dtg_ppto_detalle.Columns(j).Name
                If (nom_col = "porc_hoy" Or nom_col = "porc_cump") Then
                    For i = 0 To dtg_ppto_detalle.Rows.Count - 1
                        If Not IsDBNull(dtg_ppto_detalle.Item(j, i).Value) Then
                            If (dtg_ppto_detalle.Item(j, i).Value > 100) Then
                                dtg_ppto_detalle.Item(j, i).Style.BackColor = Color.GreenYellow
                            ElseIf dtg_ppto_detalle.Item(j, i).Value >= 90 And dtg_ppto_detalle.Item(j, i).Value <= 99 Then
                                dtg_ppto_detalle.Item(j, i).Style.BackColor = Color.Yellow
                            Else
                                dtg_ppto_detalle.Item(j, i).Style.BackColor = Color.Red
                            End If
                        Else
                            dtg_ppto_detalle.Item(j, i).Style.BackColor = Color.Red
                        End If
                    Next
                ElseIf (nom_col = "tipo" Or nom_col = "desc_tipo") Then
                    dtg_ppto_detalle.Columns(nom_col).Visible = False
                End If
            Next
            For i = 0 To dtg_ppto_detalle.Rows.Count - 1
                If IsDBNull(dtg_ppto_detalle.Item("id_cor", i).Value) Then
                    dtg_ppto_detalle.Rows(i).DefaultCellStyle = objOperacionesForm.formatoNegrita(tamano_letra)
                End If
            Next
        End If
    End Sub
    Private Sub formatoDtg_consumo()
        Dim tamano_letra As Single = 7.5!
        Dim nom_col As String = ""
        dtg_consumo_alambron.Columns("descripcion").DefaultCellStyle = objOperacionesForm.formatoNegrita(tamano_letra)
        dtg_consumo_alambron.Columns("porc_cump").DefaultCellStyle = objOperacionesForm.formatoNegrita(tamano_letra)
        dtg_consumo_alambron.Columns("descripcion").HeaderText = "Descripción"
        dtg_consumo_alambron.Columns("produccion").HeaderText = "Producción"
        dtg_consumo_alambron.Columns("Presupuesto").DefaultCellStyle.Format = "N0"
        dtg_consumo_alambron.Columns("ppto_a_hoy").DefaultCellStyle.Format = "N0"
        dtg_consumo_alambron.Columns("produccion").DefaultCellStyle.Format = "N0"
        dtg_consumo_alambron.Columns("porc_cump").DefaultCellStyle.Format = "N2"
        dtg_consumo_alambron.Columns("porc_hoy").DefaultCellStyle.Format = "N2"
        For j = 0 To dtg_consumo_alambron.Columns.Count - 1
            nom_col = dtg_consumo_alambron.Columns(j).Name
            If (nom_col = "porc_hoy" Or nom_col = "porc_cump") Then
                For i = 0 To dtg_consumo_alambron.Rows.Count - 1
                    If Not IsDBNull(dtg_consumo_alambron.Item(j, i).Value) Then
                        If (dtg_consumo_alambron.Item(j, i).Value > 100) Then
                            dtg_consumo_alambron.Item(j, i).Style.BackColor = Color.GreenYellow
                        ElseIf dtg_consumo_alambron.Item(j, i).Value >= 90 And dtg_consumo_alambron.Item(j, i).Value <= 99 Then
                            dtg_consumo_alambron.Item(j, i).Style.BackColor = Color.Yellow
                        Else
                            dtg_consumo_alambron.Item(j, i).Style.BackColor = Color.Red
                        End If
                    Else
                        dtg_consumo_alambron.Item(j, i).Style.BackColor = Color.Red
                    End If
                Next
            End If

        Next
    End Sub
    Private Sub totalizarDt(ByRef dt As DataTable)
        Dim sum As Double = 0
        Dim dias_t As Double = 0
        Dim dias_ab As Double = 0
        Dim ppt_kils As Double = 0
        If dt.Columns.Count > 0 Then
            For j = 0 To dt.Columns.Count - 1
                If (dt.Columns(j).ColumnName = "ppto_en_kilos" Or dt.Columns(j).ColumnName = "ppto_en_cant" Or dt.Columns(j).ColumnName = "entradas" Or dt.Columns(j).ColumnName = "ppto_a_hoy" _
                    Or dt.Columns(j).ColumnName = "kilos_ini" Or dt.Columns(j).ColumnName = "stock" Or dt.Columns(j).ColumnName = "kilos_ent" Or dt.Columns(j).ColumnName = "ent_kilos" Or dt.Columns(j).ColumnName = "ent_cant" _
                    Or dt.Columns(j).ColumnName = "cos_ent" Or dt.Columns(j).ColumnName = "cos_ini" Or dt.Columns(j).ColumnName = "cos_sal" Or dt.Columns(j).ColumnName = "stockB2") Then
                    For i = 0 To dt.Rows.Count - 2
                        If Not IsDBNull(dt.Rows(i).Item(j)) Then
                            If (dt.Columns(j).ColumnName = "ppto_en_kilos") Then
                                If (dt.Rows(i).Item("id_cor") = 3 Or dt.Rows(i).Item("id_cor") = 16) Then
                                    sum_kilos_ppto_productos += dt.Rows(i).Item(j)
                                End If
                            End If
                            sum += dt.Rows(i).Item(j)
                        End If
                    Next
                    If (dt.Columns(j).ColumnName = "ppto_en_kilos") Then
                        sum_kilos_ppto_total = sum
                    ElseIf (dt.Columns(j).ColumnName = "inv_final" Or dt.Columns(j).ColumnName = "inv_inicial" Or dt.Columns(j).ColumnName = "ppto_a_hoy") Then
                        sum_kilos_ppto_hoy = sum
                    End If

                    dt.Rows(dt.Rows.Count - 1).Item(j) = sum
                    sum = 0

                    'If (dt.Columns(j).ColumnName = "ppto_kilos") Then
                    '    ppt_kils = sum_kilos_ppto_total
                    'End If

                End If

                'For i = 0 To dt.Rows.Count - 2
                '    If Not IsDBNull(dt.Rows(i).Item(j)) Then
                '        If (dt.Columns(j).ColumnName = "dias_trab") Then
                '            If dt.Rows(i).Item(j) <> 0 Then
                '                dias_t = dt.Rows(i).Item(j)
                '            End If
                '        End If
                '    End If
                'Next
                'For i = 0 To dt.Rows.Count - 2
                '    If Not IsDBNull(dt.Rows(i).Item(j)) Then
                '        If (dt.Columns(j).ColumnName = "dias_habiles") Then
                '            If dt.Rows(i).Item(j) <> 0 Then
                '                dias_ab = dt.Rows(i).Item(j)
                '            End If
                '        End If
                '    End If
                'Next

                'If (dt.Columns(j).ColumnName = "dias_trab") And dias_t <> 0 Then
                '    dt.Rows(dt.Rows.Count - 1).Item(j) = dias_t
                'End If
                'If (dt.Columns(j).ColumnName = "dias_habiles") And dias_ab <> 0 Then
                '    dt.Rows(dt.Rows.Count - 1).Item(j) = dias_ab
                'End If
            Next

            'If (dt.Columns(13).ColumnName = "ppto_a_hoy") And ppt_kils <> 0 And dias_ab <> 0 And dias_t <> 0 Then
            '    Dim dato As Double = (ppt_kils / dias_ab) * dias_t
            '    dt.Rows(dt.Rows.Count - 1).Item(13) = dato
            'End If
        End If
    End Sub
    Private Sub totalizarDt_dia(ByRef dt As DataTable)
        Dim sum As Double = 0
        For j = 0 To dt.Columns.Count - 1
            For i = 0 To dt.Rows.Count - 2
                If IsNumeric(dt.Rows(i).Item(j)) Then
                    sum += dt.Rows(i).Item(j)
                End If
            Next
            If sum <> 0 Then
                dt.Rows(dt.Rows.Count - 1).Item(j) = sum
                sum = 0
            End If
        Next
    End Sub
    Private Sub pintar_dtg_dia()
        Dim ppto_dia As Double = 0
        For i = 0 To dtg_seg_ppto_dia.RowCount - 2
            If IsNumeric(dtg_seg_ppto_dia.Item("ppto_por_dia", i).Value) Then
                ppto_dia = dtg_seg_ppto_dia.Item("ppto_por_dia", i).Value
            Else
                ppto_dia = 0
            End If
            For j = 0 To dtg_seg_ppto_dia.Columns.Count - 1
                If IsDate(dtg_seg_ppto_dia.Columns(j).Name) Then
                    If IsNumeric(dtg_seg_ppto_dia.Item(j, i).Value) Then
                        If dtg_seg_ppto_dia.Item(j, i).Value < ppto_dia Then
                            dtg_seg_ppto_dia.Item(j, i).Style.BackColor = Color.Red
                        End If
                    End If
                End If
            Next
        Next
    End Sub
    Private Sub pintar_dtg_dia_area()
        Dim ppto_dia As Double = 0
        For i = 0 To dtg_seg_dia_area.RowCount - 2
            If IsNumeric(dtg_seg_dia_area.Item("ppto_dia", i).Value) Then
                ppto_dia = dtg_seg_dia_area.Item("ppto_dia", i).Value
            Else
                ppto_dia = 0
            End If
            For j = 0 To dtg_seg_dia_area.Columns.Count - 1
                If IsDate(dtg_seg_dia_area.Columns(j).Name) Then
                    If IsNumeric(dtg_seg_dia_area.Item(j, i).Value) Then
                        If dtg_seg_dia_area.Item(j, i).Value < ppto_dia Then
                            dtg_seg_dia_area.Item(j, i).Style.BackColor = Color.Red
                        End If
                    End If
                End If
            Next
        Next
    End Sub
    Private Sub mostrarVariables()
        Dim mostrar As Boolean = False
        If (chkMostrarVariables.Checked) Then
            mostrar = True
        End If
        For i = 0 To dtg_presupuesto.Columns.Count - 1
            If (dtg_presupuesto.Columns(i).Name = "dias_trab" Or dtg_presupuesto.Columns(i).Name = "dias_adicionales" Or dtg_presupuesto.Columns(i).Name = "ppto_por_dia" Or dtg_presupuesto.Columns(i).Name = "dias_habiles") Then
                dtg_presupuesto.Columns(i).Visible = mostrar
            End If
        Next
        For i = 0 To dtg_ppto_area.Columns.Count - 1
            If (dtg_ppto_area.Columns(i).Name = "dias_trab" Or dtg_ppto_area.Columns(i).Name = "dias_adicionales" Or dtg_ppto_area.Columns(i).Name = "ppto_por_dia" Or dtg_ppto_area.Columns(i).Name = "dias_habiles") Then
                dtg_ppto_area.Columns(i).Visible = mostrar
            End If
        Next
    End Sub

    Private Sub chkMostrarVariables_CheckedChanged(sender As Object, e As EventArgs) Handles chkMostrarVariables.CheckedChanged
        mostrarVariables()
    End Sub


    Private Sub cbo_mes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbo_mes.SelectedIndexChanged
        If carga_comp Then
            mes = cbo_mes.SelectedIndex + 1
        End If
    End Sub

    Private Sub cbo_ano_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbo_ano.SelectedIndexChanged
        If carga_comp Then
            ano = cbo_ano.Text
        End If
    End Sub
    Private Sub cargar_pendientes()
        Dim sum As Double = 0
        Dim sql As String = "SELECT p.id_Cor,p.linea_produccion,p.codigo,p.descripcion,p.bodega,avg(r.stock) + ISNULL((select stock from v_referencias_sto_hoy where  bodega=2 and codigo=p.codigo and ano=year(getdate()) and mes=month(getdate())),0) As stock,((avg(r.stock) + ISNULL((select stock from v_referencias_sto_hoy where  bodega=2 and codigo=p.codigo and ano=year(getdate()) and mes=month(getdate())),0))-SUM(p.Pendiente))As pend_prod, ((avg(r.stock) + ISNULL((select stock from v_referencias_sto_hoy where  bodega=2 and codigo=p.codigo and ano=year(getdate()) and mes=month(getdate())),0))-SUM(p.Pendiente))As val_pend_prod, (avg(r.stock)) As pend_log,(avg(r.stock)) As val_pend_log,ISNULL((select stock from v_referencias_sto_hoy where  bodega=2 and codigo=p.codigo and ano=year(getdate()) and mes=month(getdate())),0) as pend_log_b2,ISNULL((select stock from v_referencias_sto_hoy where  bodega=2 and codigo=p.codigo and ano=year(getdate()) and mes=month(getdate())),0) as val_pend_log_b2,SUM(p.Pendiente) As Pendiente,((SUM(p.valor_total))/SUM(p.Pendiente)) As valor_unitario,SUM( p.valor_total) As valor_total " &
                    "FROM J_v_pendientes_por_vendedor_id_cor p ,v_referencias_sto_hoy r " &
                        "WHERE p.bodega = r.bodega AND p.codigo = r.codigo " &
                            "GROUP BY p.id_Cor,p.linea_produccion,p.codigo, p.descripcion,p.bodega " &
                             " ORDER BY p.id_Cor,p.linea_produccion,p.bodega"
        Dim dt As New DataTable
        dt = obj_Ing_prodLn.listar_datatable(sql, "CORSAN")
        calcular_prod_log(dt)
        dt = consolidarLineaProduccion(dt)

        dt.Rows.Add()
        For j = 0 To dt.Columns.Count - 1
            If (dt.Columns(j).ColumnName = "pend_prod" Or dt.Columns(j).ColumnName = "pend_log" Or dt.Columns(j).ColumnName = "val_pend_prod" Or dt.Columns(j).ColumnName = "val_pend_log" Or dt.Columns(j).ColumnName = "Cant_pedida" Or dt.Columns(j).ColumnName = "cantidad_despachada" Or dt.Columns(j).ColumnName = "Pendiente" Or dt.Columns(j).ColumnName = "KilosPendiente" Or dt.Columns(j).ColumnName = "Costo_total" Or dt.Columns(j).ColumnName = "valor_unitario" Or dt.Columns(j).ColumnName = "valor_total" Or dt.Columns(j).ColumnName = "pend_log_b2" Or dt.Columns(j).ColumnName = "val_pend_log_b2" Or dt.Columns(j).ColumnName = "pend_prod" Or dt.Columns(j).ColumnName = "val_pend_prod") Then
                For i = 0 To dt.Rows.Count - 2
                    sum += dt.Rows(i).Item(j)
                Next
                dt.Rows(dt.Rows.Count - 1).Item(j) = sum
                sum = 0
            ElseIf (dt.Columns(j).ColumnName = "linea_produccion") Then
                dt.Rows(dt.Rows.Count - 1).Item(j) = "TOTAL"
            End If
        Next
        dtg_pendientes.DataSource = Nothing
        dtg_pendientes.DataSource = dt
        dtg_pendientes.Rows(dtg_pendientes.Rows.Count - 1).DefaultCellStyle.BackColor = Color.Red
        dtg_pendientes.Rows(dtg_pendientes.Rows.Count - 1).DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        For i = 0 To dtg_pendientes.Columns.Count - 1
            If (dtg_pendientes.Columns(i).Name = "pend_prod" Or dtg_pendientes.Columns(i).Name = "val_pend_prod") Then
                dtg_pendientes.Columns(i).DefaultCellStyle.BackColor = Color.Yellow
                dtg_pendientes.Columns(i).HeaderCell.Style.BackColor = Color.Yellow
                dtg_pendientes.Columns(i).HeaderCell.Style.ForeColor = Color.Black
                If dtg_pendientes.Columns(i).Name = "pend_prod" Then
                    dtg_pendientes.Columns(i).DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
                End If
            ElseIf (dtg_pendientes.Columns(i).Name = "pend_log" Or dtg_pendientes.Columns(i).Name = "val_pend_log") Then
                dtg_pendientes.Columns(i).DefaultCellStyle.BackColor = Color.Lime
                dtg_pendientes.Columns(i).HeaderCell.Style.BackColor = Color.Lime
                dtg_pendientes.Columns(i).HeaderCell.Style.ForeColor = Color.Black
                If dtg_pendientes.Columns(i).Name = "pend_log" Then
                    dtg_pendientes.Columns(i).DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
                End If
            ElseIf (dtg_pendientes.Columns(i).Name = "pend_log_b2" Or dtg_pendientes.Columns(i).Name = "val_pend_log_b2") Then
                dtg_pendientes.Columns(i).DefaultCellStyle.BackColor = Color.Aquamarine
                dtg_pendientes.Columns(i).HeaderCell.Style.BackColor = Color.Aquamarine
                dtg_pendientes.Columns(i).HeaderCell.Style.ForeColor = Color.Black
                If dtg_pendientes.Columns(i).Name = "pend_log_b2" Then
                    dtg_pendientes.Columns(i).DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
                End If
            ElseIf (dtg_pendientes.Columns(i).Name = "id_Cor") Then
                dtg_pendientes.Columns(i).Visible = False
            End If
        Next
    End Sub
    'Pendientes de ventas para el concepto 1 
    'Private Sub cargar_pendientes_Ventas()
    '    Dim sum As Double = 0
    '    Dim sql As String = "SELECT p.id_Cor,p.linea_produccion,p.codigo,p.descripcion,p.bodega,AVG(r.stock)As stock,(AVG(r.stock)-SUM(p.Pendiente))As pend_prod, (AVG(r.stock)-SUM(p.Pendiente))As val_pend_prod, (AVG(r.stock))As pend_log,(AVG(r.stock))As val_pend_log,SUM(p.Pendiente)As Pendiente,(SUM(p.valor_total)/SUM(p.Pendiente)) As valor_unitario,SUM( p.valor_total) As valor_total " & _
    '                "FROM J_v_pendientes_por_vendedor_id_cor p ,v_referencias_sto_hoy r " & _
    '                    "WHERE p.bodega = r.bodega AND p.codigo = r.codigo and p.concepto in (1) and year(p.fecha)=year(GETDATE()) and month(p.fecha)=month(GETDATE())" & _
    '                        "GROUP BY p.id_Cor,p.linea_produccion,p.codigo, p.descripcion,p.bodega " & _
    '                         " ORDER BY p.id_Cor,p.linea_produccion,p.bodega"
    '    Dim dt As New DataTable
    '    dt = obj_Ing_prodLn.listar_datatable(sql, "CORSAN")
    '    calcular_prod_log(dt)
    '    dt = consolidarLineaProduccion(dt)

    '    dt.Rows.Add()
    '    For j = 0 To dt.Columns.Count - 1
    '        If (dt.Columns(j).ColumnName = "pend_prod" Or dt.Columns(j).ColumnName = "pend_log" Or dt.Columns(j).ColumnName = "val_pend_prod" Or dt.Columns(j).ColumnName = "val_pend_log" Or dt.Columns(j).ColumnName = "Cant_pedida" Or dt.Columns(j).ColumnName = "cantidad_despachada" Or dt.Columns(j).ColumnName = "Pendiente" Or dt.Columns(j).ColumnName = "KilosPendiente" Or dt.Columns(j).ColumnName = "Costo_total" Or dt.Columns(j).ColumnName = "valor_unitario" Or dt.Columns(j).ColumnName = "valor_total") Then
    '            For i = 0 To dt.Rows.Count - 2
    '                sum += dt.Rows(i).Item(j)
    '            Next
    '            dt.Rows(dt.Rows.Count - 1).Item(j) = sum
    '            sum = 0
    '        ElseIf (dt.Columns(j).ColumnName = "linea_produccion") Then
    '            dt.Rows(dt.Rows.Count - 1).Item(j) = "TOTAL"
    '        End If
    '    Next
    '    dtg_pedidos_ventas.DataSource = Nothing
    '    dtg_pedidos_ventas.DataSource = dt
    '    dtg_pedidos_ventas.Rows(dtg_pedidos_ventas.Rows.Count - 1).DefaultCellStyle.BackColor = Color.Red
    '    dtg_pedidos_ventas.Rows(dtg_pedidos_ventas.Rows.Count - 1).DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
    '    For i = 0 To dtg_pedidos_ventas.Columns.Count - 1
    '        If (dtg_pedidos_ventas.Columns(i).Name = "pend_prod" Or dtg_pedidos_ventas.Columns(i).Name = "val_pend_prod") Then
    '            dtg_pedidos_ventas.Columns(i).DefaultCellStyle.BackColor = Color.Yellow
    '            dtg_pedidos_ventas.Columns(i).HeaderCell.Style.BackColor = Color.Yellow
    '            dtg_pedidos_ventas.Columns(i).HeaderCell.Style.ForeColor = Color.Black
    '            If dtg_pedidos_ventas.Columns(i).Name = "pend_prod" Then
    '                dtg_pedidos_ventas.Columns(i).DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
    '            End If
    '        ElseIf (dtg_pedidos_ventas.Columns(i).Name = "pend_log" Or dtg_pedidos_ventas.Columns(i).Name = "val_pend_log") Then
    '            dtg_pedidos_ventas.Columns(i).DefaultCellStyle.BackColor = Color.Lime
    '            dtg_pedidos_ventas.Columns(i).HeaderCell.Style.BackColor = Color.Lime
    '            dtg_pedidos_ventas.Columns(i).HeaderCell.Style.ForeColor = Color.Black
    '            If dtg_pedidos_ventas.Columns(i).Name = "pend_log" Then
    '                dtg_pedidos_ventas.Columns(i).DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
    '            End If
    '        ElseIf (dtg_pedidos_ventas.Columns(i).Name = "id_Cor") Then
    '            dtg_pedidos_ventas.Columns(i).Visible = False
    '        End If
    '    Next
    'End Sub
    'Pendiente de ventas para el concepto 2
    Private Sub cargar_pendientes_Ventas_2()
        Dim sum As Double = 0
        Dim sql As String = "SELECT p.id_Cor,p.linea_produccion,p.codigo,p.descripcion,p.bodega,AVG(r.stock)As stock,(AVG(r.stock)-SUM(p.Pendiente))As pend_prod, (AVG(r.stock)-SUM(p.Pendiente))As val_pend_prod, (AVG(r.stock))As pend_log,(AVG(r.stock))As val_pend_log,SUM(p.Pendiente)As Pendiente,(SUM(p.valor_total)/SUM(p.Pendiente)) As valor_unitario,SUM( p.valor_total) As valor_total " &
                    "FROM J_v_pendientes_por_vendedor_id_cor p ,v_referencias_sto_hoy r " &
                        "WHERE p.bodega = r.bodega AND p.codigo = r.codigo and p.nota1 <>''" &
                            "GROUP BY p.id_Cor,p.linea_produccion,p.codigo, p.descripcion,p.bodega " &
                             " ORDER BY p.id_Cor,p.linea_produccion,p.bodega"
        Dim dt As New DataTable
        dt = obj_Ing_prodLn.listar_datatable(sql, "CORSAN")
        calcular_prod_log(dt)
        dt = consolidarLineaProduccion(dt)

        dt.Rows.Add()
        For j = 0 To dt.Columns.Count - 1
            If (dt.Columns(j).ColumnName = "pend_prod" Or dt.Columns(j).ColumnName = "pend_log" Or dt.Columns(j).ColumnName = "val_pend_prod" Or dt.Columns(j).ColumnName = "val_pend_log" Or dt.Columns(j).ColumnName = "Cant_pedida" Or dt.Columns(j).ColumnName = "cantidad_despachada" Or dt.Columns(j).ColumnName = "Pendiente" Or dt.Columns(j).ColumnName = "KilosPendiente" Or dt.Columns(j).ColumnName = "Costo_total" Or dt.Columns(j).ColumnName = "valor_unitario" Or dt.Columns(j).ColumnName = "valor_total") Then
                For i = 0 To dt.Rows.Count - 2
                    sum += dt.Rows(i).Item(j)
                Next
                dt.Rows(dt.Rows.Count - 1).Item(j) = sum
                sum = 0
            ElseIf (dt.Columns(j).ColumnName = "linea_produccion") Then
                dt.Rows(dt.Rows.Count - 1).Item(j) = "TOTAL"
            End If
        Next
        dtg_pedidos_ventas2.DataSource = Nothing
        dtg_pedidos_ventas2.DataSource = dt
        dtg_pedidos_ventas2.Rows(dtg_pedidos_ventas2.Rows.Count - 1).DefaultCellStyle.BackColor = Color.Red
        dtg_pedidos_ventas2.Rows(dtg_pedidos_ventas2.Rows.Count - 1).DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        For i = 0 To dtg_pedidos_ventas2.Columns.Count - 1
            If (dtg_pedidos_ventas2.Columns(i).Name = "pend_prod" Or dtg_pedidos_ventas2.Columns(i).Name = "val_pend_prod") Then
                dtg_pedidos_ventas2.Columns(i).DefaultCellStyle.BackColor = Color.Yellow
                dtg_pedidos_ventas2.Columns(i).HeaderCell.Style.BackColor = Color.Yellow
                dtg_pedidos_ventas2.Columns(i).HeaderCell.Style.ForeColor = Color.Black
                If dtg_pedidos_ventas2.Columns(i).Name = "pend_prod" Then
                    dtg_pedidos_ventas2.Columns(i).DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
                End If
            ElseIf (dtg_pedidos_ventas2.Columns(i).Name = "pend_log" Or dtg_pedidos_ventas2.Columns(i).Name = "val_pend_log") Then
                dtg_pedidos_ventas2.Columns(i).DefaultCellStyle.BackColor = Color.Lime
                dtg_pedidos_ventas2.Columns(i).HeaderCell.Style.BackColor = Color.Lime
                dtg_pedidos_ventas2.Columns(i).HeaderCell.Style.ForeColor = Color.Black
                If dtg_pedidos_ventas2.Columns(i).Name = "pend_log" Then
                    dtg_pedidos_ventas2.Columns(i).DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
                End If
            ElseIf (dtg_pedidos_ventas2.Columns(i).Name = "id_Cor") Then
                dtg_pedidos_ventas2.Columns(i).Visible = False
            End If
        Next
    End Sub
    Private Sub calcular_prod_log(ByRef dt As DataTable)
        Dim sum_prod_bod7 As Double = 0
        Dim sum_log_bod7 As Double = 0
        Dim sum_val_prod_bod7 As Double = 0
        Dim sum_val_log_bod7 As Double = 0
        Dim sum_prod_bod3 As Double = 0
        Dim sum_log_bod3 As Double = 0
        Dim sum_val_prod_bod3 As Double = 0
        Dim sum_val_log_bod3 As Double = 0
        Dim sum_stock_bod3 As Double = 0
        Dim sum_stock_bod7 As Double = 0

        For j = 0 To dt.Columns.Count - 1
            If (dt.Columns(j).ColumnName = "pend_prod") Then
                For i = 0 To dt.Rows.Count - 1
                    If (dt.Rows(i).Item("pend_prod") >= 0) Then
                        dt.Rows(i).Item("pend_prod") = 0
                    Else
                        dt.Rows(i).Item("pend_prod") *= -1
                    End If
                    dt.Rows(i).Item("val_pend_prod") = (dt.Rows(i).Item("pend_prod") * dt.Rows(i).Item("valor_unitario"))
                Next
            ElseIf (dt.Columns(j).ColumnName = "pend_log") Then
                For i = 0 To dt.Rows.Count - 1
                    If (dt.Rows(i).Item("pend_log") > dt.Rows(i).Item("Pendiente")) Then
                        dt.Rows(i).Item("pend_log") = dt.Rows(i).Item("Pendiente")
                    End If
                    dt.Rows(i).Item("val_pend_log") = (dt.Rows(i).Item("pend_log") * dt.Rows(i).Item("valor_unitario"))
                Next
            ElseIf (dt.Columns(j).ColumnName = "pend_log_b2") Then
                For i = 0 To dt.Rows.Count - 1
                    If (dt.Rows(i).Item("pend_log_b2") > dt.Rows(i).Item("Pendiente")) Then
                        dt.Rows(i).Item("pend_log_b2") = dt.Rows(i).Item("Pendiente")
                    End If
                    dt.Rows(i).Item("val_pend_log_b2") = dt.Rows(i).Item("pend_log_b2") * dt.Rows(i).Item("valor_unitario")

                Next
                j = dt.Columns.Count - 1
            End If
        Next
    End Sub
    Private Function consolidarLineaProduccion(ByVal dt As DataTable) As DataTable
        Dim dt_consolidado As New DataTable
        Dim id_cor_ant As Integer = 0
        Dim bod_ant As Integer = 0
        Dim addFila As Boolean = False
        Dim nomCol As String = ""
        Dim valor As Double = 0
        dt_consolidado.Columns.Add("id_Cor", GetType(Double))
        dt_consolidado.Columns.Add("linea_produccion")
        dt_consolidado.Columns.Add("bodega", GetType(Double))
        dt_consolidado.Columns.Add("stock", GetType(Double))
        dt_consolidado.Columns.Add("pend_prod", GetType(Double))
        dt_consolidado.Columns.Add("val_pend_prod", GetType(Double))
        dt_consolidado.Columns.Add("pend_log", GetType(Double))
        dt_consolidado.Columns.Add("val_pend_log", GetType(Double))
        dt_consolidado.Columns.Add("pend_log_b2", GetType(Double))
        dt_consolidado.Columns.Add("val_pend_log_b2", GetType(Double))
        dt_consolidado.Columns.Add("Pendiente", GetType(Double))
        dt_consolidado.Columns.Add("valor_unitario", GetType(Double))
        For k = dt.Columns.IndexOf("valor_unitario") + 1 To dt.Columns.Count - 1
            If (dt.Columns(k).ColumnName <> "notas" And dt.Columns(k).ColumnName <> "notas5" And dt.Columns(k).ColumnName <> "notas_aut" And dt.Columns(k).ColumnName <> "autoriz_texto") Then
                dt_consolidado.Columns.Add(dt.Columns(k).ColumnName, GetType(Double))
            End If
        Next
        For i = 0 To dt.Rows.Count - 1
            If (id_cor_ant <> dt.Rows(i).Item("id_Cor") Or bod_ant <> dt.Rows(i).Item("bodega") Or i = 0) Then
                addFila = True
            End If
            If (addFila) Then
                dt_consolidado.Rows.Add()
                dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("id_Cor") = dt.Rows(i).Item("id_Cor")
                dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("linea_produccion") = dt.Rows(i).Item("linea_produccion")
                dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("bodega") = dt.Rows(i).Item("bodega")
                For j = 0 To dt_consolidado.Columns.Count - 1
                    If (dt_consolidado.Columns(j).ColumnName <> "id_Cor" And dt_consolidado.Columns(j).ColumnName <> "bodega" And dt_consolidado.Columns(j).ColumnName <> "linea_produccion") Then
                        dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item(j) = 0
                    End If
                Next
            End If
            For k = dt.Columns.IndexOf("stock") To dt.Columns.Count - 1
                nomCol = dt.Columns(k).ColumnName
                valor = dt.Rows(i).Item(nomCol)
                dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item(dt_consolidado.Columns.IndexOf(nomCol)) += dt.Rows(i).Item(nomCol)
            Next
            id_cor_ant = dt.Rows(i).Item("id_Cor")
            bod_ant = dt.Rows(i).Item("bodega")
            addFila = False
            If (i = dt.Rows.Count - 1) Then

            End If
        Next
        Return dt_consolidado
    End Function
    Private Sub cargar_ppto_area_dia(ByRef dt As DataTable)
        Dim where_sql_inv As String = ""
        Dim tamano_letra As Single = 9.0!
        For i = 0 To dt.Rows.Count - 1
            Select Case dt.Rows(i).Item("centro")
                Case 2100 'trefilacion
                    where_sql_inv = " AND (codigo like '33X%' or codigo like '22X%' or codigo like '33B%' or codigo like '22B%') AND tipo IN ('EPPT','EPPP') "
                Case 2200 ' recocido
                    where_sql_inv = " AND (codigo like '22R%' or codigo like '33R%') AND tipo IN ('EPPT','EPPP') "
                Case 2300 ' puntilleria
                    where_sql_inv = " AND (codigo like '2CC%'  or codigo like '2CA%' or codigo like '2CK%' or codigo like '2CM%') AND descripcion NOT like '%electrosoldado%' AND tipo IN ('EPPP') "
                Case 2400 'emp puntilleria
                    where_sql_inv = " AND (codigo like '3CC%'  or codigo like '3CA%' or codigo like '3CK%' or codigo like '3CM%') AND descripcion NOT like '%electrosoldado%' AND tipo IN ('EDEP') "
                Case 2500 ' tornilleria
                    where_sql_inv = " AND (codigo like '3WW%' or codigo like '2T%') AND tipo IN ('ETV3','EAI2') AND descripcion NOT LIKE '%DRYWALL%' AND codigo not like '%GS' "
                Case 2600 'emp tornilleria
                    where_sql_inv = " AND tipo IN ('ETV3') "
                Case 2800 ' galv

                Case 5200 ' galv alambre
                    where_sql_inv = " AND (codigo like '33G%' or codigo like '22G%') AND tipo IN ('EPPT','EPPP') " ' AND codigo not like '33G130125%' "
                Case 5300 'GRAPA'
                    where_sql_inv = " AND codigo like '2GR%'  AND tipo IN ('EPPP')"
                Case 5400 'Empaque GRAPA'
                    where_sql_inv = " AND  codigo like '3GR%' AND tipo IN ('EDEP')"
                Case 6200 ' temple
                    where_sql_inv = ""
                Case 6400 ' puas 
                    where_sql_inv = " AND (codigo like '33P%') AND tipo IN ('EPPT','EPPP') "
            End Select
            add_inv_area_dia(dt, dt.Rows(i).Item("centro"), where_sql_inv)
        Next
        totalizar_dt_dias(dt)
        dtg_seg_dia_area.DataSource = dt
        dtg_seg_dia_area.Rows(dtg_seg_dia_area.Rows.Count - 1).DefaultCellStyle = objOperacionesForm.formatoNegrita(tamano_letra)
    End Sub
    Private Sub add_inv_area_dia(ByRef dt As DataTable, ByVal centro As Integer, ByVal where_codigo As String)
        Dim sql As String = ""
        Dim dt_datos As New DataTable
        Dim group As String = ""
        If centro <> 6200 And centro <> 2800 Then 'temple
            sql = "SELECT SUM(kilos)As kilos,CAST(Fecha AS date )As fecha " &
                        "FROM J_transacciones_kilos   " &
                               "WHERE  ano =" & ano & " AND mes =" & mes & " " & where_codigo &
                               " GROUP BY CAST(Fecha AS date )"
            dt_datos = obj_op_simplesLn.listar_datatable(sql, "CORSAN")
        ElseIf (centro = 6200) Then
            sql = "SELECT SUM( [Seguimiento tornillos].Cantidad ) AS kilos  , CAST(Fecha AS date ) As fecha  " &
            "FROM [Seguimiento tornillos] " &
                "WHERE  [Seguimiento tornillos].Maquina = '213' and YEAR( Fecha) =  " & ano & " and MONTH( Fecha) = " & mes & " " &
                               " GROUP BY CAST(Fecha AS date )"
            dt_datos = obj_op_simplesLn.listar_datatable(sql, "PRODUCCION")
        ElseIf (centro = 2800) Then
            sql = "SELECT SUM( [Seguimiento tornillos].Cantidad ) AS kilos, CAST(Fecha AS date ) As fecha " &
            "FROM [Seguimiento tornillos] " &
                "WHERE  [Seguimiento tornillos].Maquina = '180' and YEAR( Fecha) =  " & ano & " and MONTH( Fecha) = " & mes & " " &
                               " GROUP BY CAST(Fecha AS date )"
            dt_datos = obj_op_simplesLn.listar_datatable(sql, "PRODUCCION")
            'ElseIf (centro = 2300) Then
            '    sql = " SELECT SUM( kilos_prod ) AS kilos  , CAST(Fecha AS date ) As fecha  " & _
            '    "FROM J_prod_puntilleria " & _
            '        "WHERE  YEAR( Fecha) =  " & ano & " and MONTH( Fecha) = " & mes & " " &
            '                       " GROUP BY CAST(Fecha AS date ) "
            '    dt_datos = obj_op_simplesLn.listar_datatable(sql, "PRODUCCION")
        End If
        Dim fecha As Date
        For i = 0 To dt.Rows.Count - 1
            If dt.Rows(i).Item("centro") = centro Then
                For k = 0 To dt_datos.Rows.Count - 1
                    For j = 0 To dt.Columns.Count - 1
                        If IsDate(dt.Columns(j).ColumnName) Then
                            fecha = dt.Columns(j).ColumnName
                            If dt_datos.Rows(k).Item("fecha") = fecha Then
                                dt.Rows(i).Item(j) = dt_datos.Rows(k).Item("kilos")
                                j = dt.Columns.Count - 1
                            End If
                        End If
                    Next
                Next
            End If
        Next

    End Sub

    Private Sub formatoDtgArea()
        Dim nom_col As String = ""
        Dim tamano_letra As Single = 9.0!
        dtg_ppto_area.Rows(dtg_ppto_area.Rows.Count - 1).DefaultCellStyle = objOperacionesForm.formatoNegrita(tamano_letra)
        If dtg_ppto_area.Rows.Count > 0 Then
            dtg_ppto_area.Columns("cump").DefaultCellStyle = objOperacionesForm.formatoNegrita(tamano_letra)
            dtg_ppto_area.Columns("cump").DefaultCellStyle.Format = "N2"
            dtg_ppto_area.Columns("cump_hoy").DefaultCellStyle = objOperacionesForm.formatoNegrita(tamano_letra)
            dtg_ppto_area.Columns("cump_hoy").DefaultCellStyle.Format = "N2"
            dtg_ppto_area.Columns("dias_adicionales").DefaultCellStyle.Format = "N1"
            dtg_ppto_area.Columns("dias_trab").DefaultCellStyle.Format = "N1"
            dtg_ppto_area.Columns("dias_habiles").DefaultCellStyle.Format = "N1"
            For j = 0 To dtg_ppto_area.Columns.Count - 1
                nom_col = dtg_ppto_area.Columns(j).Name
                If (nom_col = "cump_hoy" Or nom_col = "cump") Then
                    For i = 0 To dtg_ppto_area.Rows.Count - 1
                        If Not IsDBNull(dtg_ppto_area.Item(j, i).Value) Then
                            If (dtg_ppto_area.Item(j, i).Value > 100) Then
                                dtg_ppto_area.Item(j, i).Style.BackColor = Color.GreenYellow
                            ElseIf dtg_ppto_area.Item(j, i).Value >= 90 And dtg_ppto_area.Item(j, i).Value < 100 Then
                                dtg_ppto_area.Item(j, i).Style.BackColor = Color.Yellow
                            Else
                                dtg_ppto_area.Item(j, i).Style.BackColor = Color.Red
                            End If
                        Else
                            dtg_ppto_area.Item(j, i).Style.BackColor = Color.Red
                        End If
                    Next
                End If
            Next
        End If
    End Sub
    Private Sub formatoDtg_otros()
        Dim nom_col As String = ""
        Dim tamano_letra As Single = 9.0!
        dtg_otros_presupuestos.Rows(dtg_otros_presupuestos.Rows.Count - 1).DefaultCellStyle = objOperacionesForm.formatoNegrita(tamano_letra)
        dtg_otros_presupuestos.Columns("centro").Frozen = True
        dtg_otros_presupuestos.Columns("descripcion").Frozen = True
        If dtg_otros_presupuestos.Rows.Count > 0 Then
            For j = 0 To dtg_otros_presupuestos.Columns.Count - 1
                nom_col = dtg_otros_presupuestos.Columns(j).Name
                If (nom_col = "porc_efic") Then
                    For i = 0 To dtg_otros_presupuestos.Rows.Count - 1
                        If Not IsDBNull(dtg_otros_presupuestos.Item(j, i).Value) Then
                            If (dtg_otros_presupuestos.Item(j, i).Value > 100) Then
                                dtg_otros_presupuestos.Item(j, i).Style.BackColor = Color.GreenYellow
                            ElseIf dtg_otros_presupuestos.Item(j, i).Value >= 90 And dtg_otros_presupuestos.Item(j, i).Value < 100 Then
                                dtg_otros_presupuestos.Item(j, i).Style.BackColor = Color.Yellow
                            Else
                                dtg_otros_presupuestos.Item(j, i).Style.BackColor = Color.Red
                            End If
                        Else
                            dtg_otros_presupuestos.Item(j, i).Style.BackColor = Color.Red
                        End If
                    Next
                ElseIf nom_col = "porc_gastos" Or nom_col = "porc_desperdicios" Or nom_col = "porc_ausentismo" Or nom_col = "porc_extra" Then
                    For i = 0 To dtg_otros_presupuestos.Rows.Count - 1
                        If Not IsDBNull(dtg_otros_presupuestos.Item(j, i).Value) Then
                            If (dtg_otros_presupuestos.Item(j, i).Value > 100) Then
                                dtg_otros_presupuestos.Item(j, i).Style.BackColor = Color.Red
                            ElseIf dtg_otros_presupuestos.Item(j, i).Value >= 90 And dtg_otros_presupuestos.Item(j, i).Value < 100 Then
                                dtg_otros_presupuestos.Item(j, i).Style.BackColor = Color.Yellow
                            Else
                                dtg_otros_presupuestos.Item(j, i).Style.BackColor = Color.GreenYellow
                            End If
                        Else
                            dtg_otros_presupuestos.Item(j, i).Style.BackColor = Color.Red
                        End If
                    Next
                End If
            Next
        End If
    End Sub
    Private Sub SeguimientoDePresupeustoGeneralToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SeguimientoDePresupeustoGeneralToolStripMenuItem.Click
        objOperacionesForm.ExportarDatosExcel(dtg_presupuesto, SeguimientoDePresupeustoGeneralToolStripMenuItem.Text)
    End Sub

    Private Sub InventariosBodega2ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InventariosBodega2ToolStripMenuItem.Click
        objOperacionesForm.ExportarDatosExcel(dtg_inv_b2, InventariosBodega2ToolStripMenuItem.Text)
    End Sub

    Private Sub PendientesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PendientesToolStripMenuItem.Click
        objOperacionesForm.ExportarDatosExcel(dtg_pendientes, PendientesToolStripMenuItem.Text)
    End Sub

    Private Sub SeguimientoDePresupuestoPorAreaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SeguimientoDePresupuestoPorAreaToolStripMenuItem.Click
        objOperacionesForm.ExportarDatosExcel(dtg_ppto_area, SeguimientoDePresupuestoPorAreaToolStripMenuItem.Text)
    End Sub

    Private Sub toolConsumoAlambron_Click(sender As Object, e As EventArgs) Handles toolConsumoAlambron.Click
        objOperacionesForm.ExportarDatosExcel(dtg_consumo_alambron, toolConsumoAlambron.Text)
    End Sub

    Private Sub SeguimientoDePresupuestoDíaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SeguimientoDePresupuestoDíaToolStripMenuItem.Click
        objOperacionesForm.ExportarDatosExcel(dtg_seg_ppto_dia, "Seguimiento por día")
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Frm_clasificacion.ShowDialog()
    End Sub

    Private Sub totalizar_dt_dias(ByRef dt As DataTable)
        Dim sum As Double = 0
        dt.Rows.Add()
        For j = 0 To dt.Columns.Count - 1
            If (dt.Columns(j).ColumnName <> "descripcion" And dt.Columns(j).ColumnName <> "centro") Then
                If (dt.Columns(j).ColumnName = "cump_hoy") Then
                    For i = 0 To dt.Rows.Count - 1
                        If dt.Rows(i).Item("llevamos") IsNot DBNull.Value And Not dt.Rows(i).Item("deb_llevar") IsNot DBNull.Value Then
                            If IsNumeric(dt.Rows(i).Item("llevamos") And IsNumeric(dt.Rows(i).Item("deb_llevar"))) Then
                                dt.Rows(i).Item("cump_hoy") = (dt.Rows(i).Item("llevamos") / dt.Rows(i).Item("deb_llevar")) * 100
                            End If
                        End If
                    Next
                ElseIf dt.Columns(j).ColumnName = "cump" Then
                    For i = 0 To dt.Rows.Count - 1
                        If dt.Rows(i).Item("llevamos") IsNot DBNull.Value And Not dt.Rows(i).Item("ppto_kilos") IsNot DBNull.Value Then
                            If IsNumeric(dt.Rows(i).Item("llevamos") And IsNumeric(dt.Rows(i).Item("ppto_kilos"))) Then
                                dt.Rows(i).Item("cump") = (dt.Rows(i).Item("llevamos") / dt.Rows(i).Item("ppto_kilos")) * 100
                            End If
                        End If
                    Next
                Else
                    For i = 0 To dt.Rows.Count - 2
                        If Not IsDBNull(dt.Rows(i).Item(j)) Then
                            sum += dt.Rows(i).Item(j)
                        End If
                    Next
                    dt.Rows(dt.Rows.Count - 1).Item(j) = sum
                    sum = 0
                End If
            End If
        Next
    End Sub

    Private Sub SeguimientoDiarioPorAreaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SeguimientoDiarioPorAreaToolStripMenuItem.Click
        objOperacionesForm.ExportarDatosExcel(dtg_seg_dia_area, "Seguimiento dirario por area")
    End Sub

    Private Sub itemGrafic_Click(sender As Object, e As EventArgs) Handles itemGrafic.Click
        Dim fila As Integer = dtg_seg_dia_area.Rows(dtg_seg_dia_area.CurrentCell.RowIndex).Index
        If fila >= 0 Then
            graficar(fila)
        End If

    End Sub
    Public Sub graficar(ByVal fila As Integer)
        Chart1.Visible = True
        Chart1.Titles.Clear()
        Chart1.Series.Clear()
        Chart1.ChartAreas.Clear()
        Chart1.ChartAreas.Add(0)
        Chart1.Series.Add("Produccion")
        Chart1.Series.Add("Presupuesto")
        Dim ppto As Double = dtg_seg_dia_area.Item("ppto_dia", fila).Value
        Dim valor As Integer = 0
        Dim cant As Integer = 0
        Dim num_dia_semana As Integer = 0
        For j = 0 To dtg_seg_dia_area.Columns.Count - 1
            If IsDate(dtg_seg_dia_area.Columns(j).Name) Then
                If IsNumeric(dtg_seg_dia_area.Item(j, fila).Value) Then
                    If (dtg_seg_dia_area.Item(j, fila).Value) > 0 Then
                        valor = dtg_seg_dia_area.Item(j, fila).Value
                        Chart1.Series("Produccion").Points.AddXY(dtg_seg_dia_area.Columns(j).Name, valor)
                        Chart1.Series("Presupuesto").Points.AddXY(dtg_seg_dia_area.Columns(j).Name, ppto)
                        num_dia_semana = Weekday(dtg_seg_dia_area.Columns(j).Name)
                        Chart1.Series("Presupuesto").Points(cant).ToolTip = WeekdayName(num_dia_semana) & "," & dtg_seg_dia_area.Columns(j).Name
                        Chart1.Series("Produccion").Points(cant).ToolTip = WeekdayName(num_dia_semana) & "," & dtg_seg_dia_area.Columns(j).Name
                        Chart1.Series("Produccion").Points(cant).LabelFormat = "N0"
                        cant += 1
                    End If
                End If
            End If
        Next
        Chart1.Series("Produccion").ChartType = DataVisualization.Charting.SeriesChartType.Line
        Chart1.Series("Presupuesto").ChartType = DataVisualization.Charting.SeriesChartType.Line

        Chart1.Series("Produccion").IsValueShownAsLabel = True
        Chart1.ChartAreas(0).AxisX.Title = "Días"
        Chart1.ChartAreas(0).AxisY.Title = dtg_seg_dia_area.Item("descripcion", fila).Value
        Chart1.Refresh()
    End Sub
    Private Sub dtg_seg_dia_area_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dtg_seg_dia_area.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            With (Me.dtg_seg_dia_area)
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                End If
            End With
        End If
    End Sub

    Private Sub btn_cerrar_grafico_Click(sender As Object, e As EventArgs) Handles btn_cerrar_grafico.Click
        Chart1.Visible = False
    End Sub
End Class