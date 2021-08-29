Imports logicaNegocios
Imports entidadNegocios
Public Class Frm_super_modulo_consult_pendientes
    Private objUsuarioLn As New UsuarioLn
    Private objOperacionesForm As New OperacionesFormularios
    Private objOpSimplesLn As New Op_simpesLn
    Dim carga_comp As Boolean = False
    Private objUsuarioEn As New UsuarioEn
    Dim select_col_stock As Boolean = False
    Private permiso As String = ""
    Private columnaArbol As String
    Dim dt_idref As New DataTable
    Private consol_linea_prod As Boolean = False
    Private dt_columnas_permiso As New DataTable
    Dim resumen_pend_prod_log As Boolean = False
    'permisos
    Private obj_correoLn As New EnvCorreoLN
    Dim calidad As Boolean = False
    Dim permiso_clientes As Boolean = False
    Dim permiso_ciudad As Boolean = False
    Dim permiso_vendedor As Boolean = False
    Dim permiso_valores As Boolean = False
    'vendedores
    Dim vendedores As String
    Dim where_global As String
    Dim group_global As String
    Public Sub Main(ByVal objUsuarioEn As UsuarioEn)
        Me.objUsuarioEn = objUsuarioEn
        permiso = objUsuarioEn.permiso.Trim
        If (permiso = "ADMIN") Then
            Dim sql As String = "SELECT descripcion  FROM J_spic_permiso "
            cargarLista(listaTipoUsu, sql)
            cargar_columnas_permisos()
        Else
            btnConfigPermisos.Visible = False
        End If
        ' vendedores = objUsuarioLn.coordinadorVend(objUsuarioEn.usuario)
        vendedores = ""
        cargar_campos()
    End Sub

    Private Sub Frm_super_modulo_consult_pendientes_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        carga_comp = True
        cargar_ciudades()
    End Sub
    Private Sub cargarLista(ByVal lista As ListBox, ByVal sql As String)
        lista.Items.Clear()
        Dim list As New List(Of Object)
        list = objOpSimplesLn.lista(sql)
        For i = 0 To list.Count - 1
            lista.Items.Add(list(i))
        Next
    End Sub
    Private Sub listPermisosUsuario_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles listaTipoUsu.SelectedIndexChanged
        permiso = listaTipoUsu.SelectedItem
        Dim sql As String = "SELECT columna FROM J_spic_per_columna_pendientes   WHERE permiso = '" & permiso & "' ORDER BY orden "
        cargarLista(listPermisosUsuario, sql)
    End Sub
    Private Sub btnAddColumna_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddColumna.Click
        addColumna()
    End Sub
    Private Sub addColumna()
        If (permiso <> "") Then
            Dim sql As String = "INSERT INTO J_spic_per_columna_pendientes (columna,permiso) VALUES ('" & columnaArbol & "','" & permiso & "')"
            If (objOpSimplesLn.consultarVal("SELECT columna FROM J_spic_per_columna_pendientes WHERE columna = '" & columnaArbol & "' AND permiso = '" & permiso & "'") <> "") Then
                MessageBox.Show("LA columna ya fue asignado para este permiso")
            ElseIf (objOpSimplesLn.ejecutar(sql, "CORSAN")) Then
                listPermisosUsuario.Items.Add(columnaArbol)
            Else
                MsgBox("Error al otorgar el permiso")
            End If
        Else
            MessageBox.Show("Seleccione tipo de permiso para asignar funcionalidad", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
    Private Sub cargar_columnas_permisos()
        listColumnas.Items.Add("fecha")
        listColumnas.Items.Add("numero")
        listColumnas.Items.Add("nit")
        listColumnas.Items.Add("nombres")
        listColumnas.Items.Add("vendedor")
        listColumnas.Items.Add("ciudad")
        listColumnas.Items.Add("dias_vencido")
        listColumnas.Items.Add("direccion")
        listColumnas.Items.Add("telefono_1")
        listColumnas.Items.Add("condicion")
        listColumnas.Items.Add("linea_produccion")
        listColumnas.Items.Add("pend_prod")
        listColumnas.Items.Add("pend_log")
        listColumnas.Items.Add("codigo")
        listColumnas.Items.Add("Pendiente")
        listColumnas.Items.Add("valor_unitario")
        listColumnas.Items.Add("Cant_pedida")
        listColumnas.Items.Add("cantidad_despachada")
        listColumnas.Items.Add("KilosPendiente")
        listColumnas.Items.Add("Costo_total")
        listColumnas.Items.Add("valor_total")
        listColumnas.Items.Add("autoriz_texto")
        listColumnas.Items.Add("nota_prod")
        listColumnas.Items.Add("notas")
        listColumnas.Items.Add("notas5")
        listColumnas.Items.Add("notas_aut")
        listColumnas.Items.Add("producido")
        listColumnas.Items.Add("calidad")
        listColumnas.Items.Add("adicional")
        listColumnas.Items.Add("concepto_4")
    End Sub
    Private Sub cargar_campos()
        Dim row As DataRow
        Dim dt_linea As New DataTable
        Dim dt_bodega As New DataTable
        Dim dt_departamento As New DataTable
        Dim sql_bodega As String = "SELECT CAST(bodega AS varchar(25))As bodega FROM V_pendientes_por_vendedor GROUP BY bodega "
        Dim sql_linea As String = "SELECT CAST(Id_cor AS varchar(25))As Id_cor, Descripcion FROM JJV_Grupos_seguimiento"
        dt_linea = objOpSimplesLn.listar_datatable(sql_linea, "CORSAN")

        For i = 0 To dt_linea.Rows.Count - 1
            If (i = 0) Then
                chkLinea.Items.Add("TODOS")
            End If
            chkLinea.Items.Add(dt_linea.Rows(i).Item("Descripcion"))
        Next

        dt_bodega = objOpSimplesLn.listar_datatable(sql_bodega, "CORSAN")
        row = dt_bodega.NewRow
        row("bodega") = "TODO"
        row("bodega") = "TODO"
        dt_bodega.Rows.Add(row)
        cbo_bodega.DataSource = dt_bodega
        cbo_bodega.ValueMember = "bodega"
        cbo_bodega.DisplayMember = "bodega"
        cbo_bodega.SelectedValue = "TODO"


        Dim whereVend As String = ""
        If (vendedores <> "") Then
            whereVend = "vendedor in(" & vendedores & ")"
        Else
            whereVend = "vendedor >= 1001 and vendedor <= 1099"
        End If
        Dim sql_columnas As String = "SELECT columna " & _
                                        "FROM J_spic_per_columna_pendientes " & _
                                            "WHERE permiso = '" & permiso & "' " & _
                                            "ORDER BY orden  "
        Dim sql_vendedores As String = "SELECT vendedor " & _
                                        "FROM V_pendientes_por_vendedor  " & _
                                        "WHERE " & whereVend & " " & _
                                             "GROUP BY vendedor " & _
                                                    "ORDER BY vendedor"

        Dim dt_vendedores As New DataTable
        dt_columnas_permiso = objOpSimplesLn.listar_datatable(sql_columnas, "CORSAN")
        dt_vendedores = objOpSimplesLn.listar_datatable(sql_vendedores, "CORSAN")
        For i = 0 To dt_columnas_permiso.Rows.Count - 1
            If Not (dt_columnas_permiso.Rows(i).Item("columna") = "pend_prod" Or dt_columnas_permiso.Rows(i).Item("columna") = "pend_log" Or dt_columnas_permiso.Rows(i).Item("columna") = "producido" Or dt_columnas_permiso.Rows(i).Item("columna") = "calidad" Or dt_columnas_permiso.Rows(i).Item("columna") = "adicional") Then
                chk_col_consol.Items.Add(dt_columnas_permiso.Rows(i).Item("columna"))
            End If
        Next
        Dim a As String = ""
        For i = 0 To chk_col_consol.Items.Count - 1
            a = chk_col_consol.Items.Item(i).ToString
            If (chk_col_consol.Items.Item(i).ToString = "codigo" Or chk_col_consol.Items.Item(i).ToString = "valor_total") Then
                chk_col_consol.SetItemChecked(i, True)
                If (chk_col_consol.Items.Item(i).ToString = "valor_total") Then
                    permiso_valores = True
                End If
            ElseIf (chk_col_consol.Items.Item(i).ToString = "nit" Or chk_col_consol.Items.Item(i).ToString = "nombres") Then
                permiso_clientes = True
            ElseIf (chk_col_consol.Items.Item(i).ToString = "ciudad") Then
                permiso_ciudad = True
            ElseIf (chk_col_consol.Items.Item(i).ToString = "vendedor") Then
                permiso_vendedor = True
            ElseIf (chk_col_consol.Items.Item(i).ToString = "valor_total" Or chk_col_consol.Items.Item(i).ToString = "valor_unitario") Then
                permiso_valores = True
            End If
        Next
        For i = 0 To dt_vendedores.Rows.Count - 1
            If (i = 0) Then
                ChkListvendedores.Items.Add("TODOS")
            End If
            ChkListvendedores.Items.Add(dt_vendedores.Rows(i).Item("vendedor"))
        Next
        If Not (permiso_clientes) Then
            txt_nombres.Enabled = False
        End If
        If Not (permiso_ciudad) Then
            chk_ciudades.Enabled = False
        End If
        If Not (permiso_vendedor) Then
            ChkListvendedores.Enabled = False
        End If
     
    End Sub
    Private Sub validarConsulta()
        For i = 0 To chk_col_consol.CheckedItems.Count - 1
            If (chk_col_consol.CheckedItems(i) = "dias_vencido") Then
                chk_col_consol.SetItemChecked(chk_col_consol.Items.IndexOf("nit"), True)
            End If
        Next
    End Sub
    Private Sub btn_actualizar_Click(sender As System.Object, e As System.EventArgs) Handles btn_actualizar.Click
        If (chk_col_consol.CheckedItems.Count > 0) Then
            validarConsulta()
            txtSumProblemas.Text = ""
            txtSumProbLog.Text = ""
            txtSumProbProd.Text = ""
            txtProbBloqueo.Text = ""
            txtProbDocVenc.Text = ""
            txtProCupo.Text = ""
            txtTotStock.Text = ""
            txtStockB3.Text = ""
            txtStockB7.Text = ""
            If (chkMarcarProblemas.Checked = True) Then
                verificarChkProblemas()
            End If
            resumen_pend_prod_log = True
            imgProcesar.Visible = True
            dtg_faltantes.DataSource = Nothing
            Application.DoEvents()
            Dim sql As String = armarSqlConsulta()
            Dim dt As New DataTable
            Dim sum As Double = 0
            dt = objOpSimplesLn.listar_datatable(sql, "CORSAN")

            dt = calcular_prod_log(dt)
            If (consol_linea_prod) Then
                dt = consolidarLineaProducción(dt)
            End If
            dt = verificarColumnaPermisos(dt)
            dt.Rows.Add()
            For j = 0 To dt.Columns.Count - 1
                If (dt.Columns(j).ColumnName = "Cant_pedida" Or dt.Columns(j).ColumnName = "cantidad_despachada" Or dt.Columns(j).ColumnName = "Pendiente" Or dt.Columns(j).ColumnName = "KilosPendiente" Or dt.Columns(j).ColumnName = "Costo_total" Or dt.Columns(j).ColumnName = "valor_total" Or dt.Columns(j).ColumnName = "pend_log_b2" Or dt.Columns(j).ColumnName = "val_pend_log_b2" Or dt.Columns(j).ColumnName = "pend_log" Or dt.Columns(j).ColumnName = "val_pend_log" Or dt.Columns(j).ColumnName = "pend_prod" Or dt.Columns(j).ColumnName = "val_pend_prod") Then
                    For i = 0 To dt.Rows.Count - 2
                        sum += dt.Rows(i).Item(j)
                    Next
                    dt.Rows(dt.Rows.Count - 1).Item(j) = sum
                    sum = 0
                End If
            Next
            dtg_consulta.DataSource = Nothing

            ''Si no es usuario de calidad
            If (permiso <> "CALIDAD" And permiso <> "AUXCALIDAD" And objUsuarioEn.usuario <> "ADMIN") And calidad = True Then
                dt.Columns("calidad").ReadOnly = True
                dt.Columns("producido").ReadOnly = True
                dt.Columns("adicional").ReadOnly = True
            End If
            dtg_consulta.DataSource = dt

            dtg_consulta.Rows(dtg_consulta.Rows.Count - 1).DefaultCellStyle.BackColor = Color.Red
            dtg_consulta.Rows(dtg_consulta.Rows.Count - 1).DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
            For i = 0 To dtg_consulta.Columns.Count - 1
                If (dtg_consulta.Columns(i).Name = "fecha") Then
                    dtg_consulta.Columns(i).DefaultCellStyle.Format = "d"
                ElseIf (dtg_consulta.Columns(i).Name = "codigo") Then
                    If (chkMarcarProblemas.Checked) Then
                        pintarProblemas()
                    End If
                ElseIf (dtg_consulta.Columns(i).Name = "pend_prod" Or dtg_consulta.Columns(i).Name = "val_pend_prod") Then
                    dtg_consulta.Columns(i).DefaultCellStyle.BackColor = Color.Yellow
                    dtg_consulta.Columns(i).HeaderCell.Style.BackColor = Color.Yellow
                    dtg_consulta.Columns(i).HeaderCell.Style.ForeColor = Color.Black
                    If dtg_consulta.Columns(i).Name = "pend_prod" Then
                        dtg_consulta.Columns(i).DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
                    End If
                ElseIf (dtg_consulta.Columns(i).Name = "pend_log" Or dtg_consulta.Columns(i).Name = "val_pend_log") Then
                    dtg_consulta.Columns(i).DefaultCellStyle.BackColor = Color.Lime
                    dtg_consulta.Columns(i).HeaderCell.Style.BackColor = Color.Lime
                    dtg_consulta.Columns(i).HeaderCell.Style.ForeColor = Color.Black
                    If dtg_consulta.Columns(i).Name = "pend_log" Then
                        dtg_consulta.Columns(i).DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
                    End If
                ElseIf (dtg_consulta.Columns(i).Name = "pend_log_b2" Or dtg_consulta.Columns(i).Name = "val_pend_log_b2") Then
                    dtg_consulta.Columns(i).DefaultCellStyle.BackColor = Color.Aquamarine
                    dtg_consulta.Columns(i).HeaderCell.Style.BackColor = Color.Aquamarine
                    dtg_consulta.Columns(i).HeaderCell.Style.ForeColor = Color.Black
                    If dtg_consulta.Columns(i).Name = "pend_log_b2" Then
                        dtg_consulta.Columns(i).DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
                    End If
                ElseIf (dtg_consulta.Columns(i).Name = "id_Cor") Then
                    dtg_consulta.Columns(i).Visible = False
                ElseIf (dtg_consulta.Columns(i).Name = "certificado") Then
                    For k = 0 To dtg_consulta.Rows.Count - 1
                        If Not IsDBNull(dtg_consulta.Item(i, k).Value) Then
                            If dtg_consulta.Item(i, k).Value = "S" Then
                                dtg_consulta.Item(i, k).Style.BackColor = Color.Green
                            End If
                        End If
                    Next
                End If
                If (dtg_consulta.Columns(i).Name <> "adicional") Then
                    dtg_consulta.Columns(i).ReadOnly = True
                End If
            Next

            imgProcesar.Visible = False
            lbl_ult_act.Text = "ÚLTIMA CONSULTA: " & Now.Hour & ":" & Now.Minute & ":" & Now.Second
            tab_principal.SelectedTab = tab_resumen
            cargar_tot_inventarios()
        Else
            MessageBox.Show("Seleccione al menos 1 item a consolidar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
    'Private Sub cargar_tot_inventarios()
    '    Dim sum_b3 As Double = 0
    '    Dim sum_b7 As Double = 0
    '    If txt_codigo_inventarios.Text <> "" Then
    '        Dim sql As String = "SELECT sum(s.stock ) as stock,s.bodega " & _
    '                        "FROM v_referencias_sto_hoy s , referencias r " & _
    '                           "WHERE bodega IN (3,7) AND r.codigo = s.codigo AND s.codigo like'" & txt_codigo_inventarios.Text & "%' " & _
    '                               "GROUP BY s.bodega"
    '        Dim dt As DataTable = objOpSimplesLn.listar_datatable(sql, "CORSAN")
    '        For i = 0 To dt.Rows.Count - 1
    '            If IsNumeric(dt.Rows(i).Item("stock")) Then
    '                If dt.Rows(i).Item("bodega") = 3 Then
    '                    sum_b3 = dt.Rows(i).Item("stock")
    '                ElseIf (dt.Rows(i).Item("bodega") = 7) Then
    '                    sum_b7 = dt.Rows(i).Item("stock")
    '                End If
    '            End If
    '        Next
    '    End If
    '    txt_inv_total_b3.Text = (sum_b3).ToString("N0")
    '    txt_inv_total_b7.Text = (sum_b7).ToString("N0")
    '    txt_inv_total.Text = (sum_b3 + sum_b7).ToString("N0")
    'End Sub
    Private Sub cargar_tot_inventarios()
        Dim sum_b3 As Double = 0
        Dim sum_b7 As Double = 0
        If txt_codigo_inventarios.Text <> "" Then
            Dim sql As String = "SELECT r.codigo,r.descripcion,s.bodega As bod,sum(s.stock ) as stock " & _
                            "FROM v_referencias_sto_hoy s , referencias r " & _
                               "WHERE bodega IN (3,7) AND r.codigo = s.codigo AND s.codigo like'" & txt_codigo_inventarios.Text & "%' " & _
                                   "GROUP BY  r.codigo,r.descripcion,s.bodega"
            Dim dt As DataTable = objOpSimplesLn.listar_datatable(sql, "CORSAN")
            dtg_inventario.DataSource = dt
            For i = 0 To dtg_inventario.Rows.Count - 1
                If IsNumeric(dtg_inventario.Item("stock", i).Value) Then
                    If dtg_inventario.Item("bod", i).Value = 3 Then
                        sum_b3 += dtg_inventario.Item("stock", i).Value
                    ElseIf (dtg_inventario.Item("bod", i).Value = 7) Then
                        sum_b7 += dtg_inventario.Item("stock", i).Value
                    End If
                    dtg_inventario.Item("codigo", i).ToolTipText = dtg_inventario.Item("descripcion", i).Value
                End If
            Next
            dtg_inventario.Columns("descripcion").Visible = False
        End If
        txt_inv_total_b3.Text = (sum_b3).ToString("N0")
        txt_inv_total_b7.Text = (sum_b7).ToString("N0")
        txt_inv_total.Text = (sum_b3 + sum_b7).ToString("N0")

    End Sub
    Private Function armarSqlConsulta() As String
        Dim sql As String = ""
        Dim sql_select As String = "SELECT "
        Dim sql_from As String = "FROM J_v_pendientes_por_vendedor_id_cor p "
        Dim sql_where As String = "WHERE "
        Dim sql_group As String = " GROUP BY "
        Dim columna_select As String = ""
        Dim columna_group As String = ""
        Dim sql_order As String = ""
        Dim colPendienteSeleccionada As Boolean = False
        Dim columna_num As Boolean = False
        Dim iva As Double = objOpSimplesLn.getIvaPorc()
        select_col_stock = False
        IngresarNotaToolStripMenuItem.Enabled = False


        For i = 0 To chk_col_consol.CheckedItems.Count - 1
            If (chk_col_consol.CheckedItems(i).ToString <> "valor_unitario") Then
                columna_select = ""
                columna_group = ""
                If (chk_col_consol.CheckedItems(i).ToString = "Cant_pedida" Or chk_col_consol.CheckedItems(i).ToString = "cantidad_despachada" Or chk_col_consol.CheckedItems(i).ToString = "valor_unitario" Or chk_col_consol.CheckedItems(i).ToString = "Pendiente" Or chk_col_consol.CheckedItems(i).ToString = "KilosPendiente" Or chk_col_consol.CheckedItems(i).ToString = "Costo_total" Or chk_col_consol.CheckedItems(i).ToString = "valor_total" Or chk_col_consol.CheckedItems(i).ToString = "costo_unitario") Then
                    If (chk_col_consol.CheckedItems(i).ToString = "costo_unitario") Then
                        columna_select = "(SUM(p.Costo_total)/SUM(p.Pendiente)) As " & chk_col_consol.CheckedItems(i).ToString
                    Else
                        If (colPendienteSeleccionada = False) Then
                            columna_select = "SUM( p." & chk_col_consol.CheckedItems(i).ToString & ") As " & chk_col_consol.CheckedItems(i).ToString
                            colPendienteSeleccionada = True
                        End If
                    End If
                    If (chk_col_consol.CheckedItems(i).ToString = "Pendiente") Then
                        If (colPendienteSeleccionada = False) Then
                            columna_select = "SUM( p." & chk_col_consol.CheckedItems(i).ToString & ") As " & chk_col_consol.CheckedItems(i).ToString
                            columna_group = ""
                        End If
                    Else
                        columna_select = "SUM( p." & chk_col_consol.CheckedItems(i).ToString & ") As " & chk_col_consol.CheckedItems(i).ToString
                        columna_group = ""
                    End If
                ElseIf (chk_col_consol.CheckedItems(i).ToString = "dias_vencido") Then
                    columna_select = "(SELECT MAX(Dias_Vencido)As Dias_Vencido FROM V_Doc_Vencidos WHERE Dias_Vencido >10 AND nit = p.nit)As " & chk_col_consol.CheckedItems(i).ToString
                    columna_group = ""
                Else
                    If ((chk_col_consol.CheckedItems(i).ToString = "codigo" Or chk_col_consol.CheckedItems(i).ToString = "linea_produccion") And select_col_stock = False) Then
                        select_col_stock = True
                        colPendienteSeleccionada = True
                        If (chk_col_consol.CheckedItems(i).ToString = "linea_produccion") Then
                            columna_select = "p.id_Cor,p.linea_produccion,"
                            columna_group = "p.id_Cor,p.linea_produccion,"
                        End If
                        columna_select &= "p.codigo,p.descripcion,p.bodega,avg(r.stock) + ISNULL((select stock from v_referencias_sto_hoy where  bodega=2 and codigo=p.codigo and ano=year(getdate()) and mes=month(getdate())),0) As stock," &
                                          "((avg(r.stock) + ISNULL((select stock from v_referencias_sto_hoy where  bodega=2 and codigo=p.codigo and ano=year(getdate()) and mes=month(getdate())),0))-SUM(p.Pendiente))As pend_prod, " &
                                             "((avg(r.stock) + ISNULL((select stock from v_referencias_sto_hoy where  bodega=2 and codigo=p.codigo and ano=year(getdate()) and mes=month(getdate())),0))-SUM(p.Pendiente))As val_pend_prod, " &
                                            "(avg(r.stock)) As pend_log," &
                                            "(avg(r.stock)) As val_pend_log," &
                                            "ISNULL((select stock from v_referencias_sto_hoy where  bodega=2 and codigo=p.codigo and ano=year(getdate()) and mes=month(getdate())),0) as pend_log_b2," &
                                            "ISNULL((select stock from v_referencias_sto_hoy where  bodega=2 and codigo=p.codigo and ano=year(getdate()) and mes=month(getdate())),0) as val_pend_log_b2," &
                                            "SUM(p.Pendiente) As Pendiente," &
                                            "((SUM(p.valor_total))/SUM(p.Pendiente)) As valor_unitario"
                        columna_group &= "p.codigo, p.descripcion,p.bodega"
                        'avg(r.stock) + ISNULL((select stock from v_referencias_sto_hoy where  bodega=2 and codigo=p.codigo  and ano=year(getdate()) and mes=month(getdate())),0) As pend_log'
                        'avg(r.stock) + ISNULL((select stock from v_referencias_sto_hoy where  bodega=2 and codigo=p.codigo  and ano=year(getdate()) and mes=month(getdate())),0) As val_pend_log'
                        sql_from &= ",v_referencias_sto_hoy r "
                        sql_where &= "p.bodega = r.bodega AND p.codigo = r.codigo AND p.autorizacion not in ('N')"
                        If Not (chkMarcarProblemas.Checked) Then
                            If (chk_col_consol.CheckedItems(i).ToString = "linea_produccion") Then
                                If (sql_order = "") Then
                                    sql_order = " ORDER BY p.orden,p.bodega"
                                    If columna_group = "" Then
                                        columna_group = "p.orden"
                                    Else
                                        columna_group &= ",p.orden"
                                    End If
                                End If
                            ElseIf (chk_col_consol.CheckedItems(i).ToString = "codigo") Then
                                If (sql_order = "") Then
                                    sql_order = " ORDER BY p.codigo"
                                End If
                            End If
                        End If
                    ElseIf (chk_col_consol.CheckedItems(i).ToString <> "codigo" And chk_col_consol.CheckedItems(i).ToString <> "linea_produccion") Then
                        If (chk_col_consol.CheckedItems(i).ToString = "fecha") Then
                            columna_select = "CAST(p.fecha AS date) As fecha"
                            columna_group = "CAST(p.fecha AS date)"
                            sql_order = " ORDER BY CAST(p.fecha AS date)"
                        Else
                            If chk_col_consol.CheckedItems(i).ToString = "concepto_4" Then
                                columna_select = "(select descripcion from terceros_4 where concepto_4=p." & chk_col_consol.CheckedItems(i).ToString & ") as canal"
                            Else
                                columna_select = "p." & chk_col_consol.CheckedItems(i).ToString
                            End If
                            columna_group = "p." & chk_col_consol.CheckedItems(i).ToString
                        End If
                        resumen_pend_prod_log = False
                    End If
                    If (chkMarcarProblemas.Checked) Then
                        If (chk_col_consol.CheckedItems(i).ToString = "codigo") Then

                            If (columna_select <> "") Then
                                columna_select &= ","
                            End If

                            If (columna_group <> "") Then
                                columna_group &= ","
                            End If
                            columna_select &= "p.autorizacion,p.bloqueo, " & _
                            "(SELECT CASE WHEN p.nit in (SELECT nit FROM V_Doc_Vencidos WHERE Dias_Vencido >10 AND nit = p.nit) THEN 'S' ELSE 'N' END)As doc_vencidos," & _
                            "(SELECT (SELECT CASE WHEN  ((SELECT CASE WHEN (SUM (c.saldo)) IS NULL THEN 0 ELSE SUM (c.saldo) END)+(SELECT SUM (Valor_total)* " & (iva + 1) & " FROM J_v_pendientes_por_vendedor_id_cor WHERE nit = p.nit )) > AVG(p.cupo_credito) THEN 'S' ELSE 'N' END) As cupo FROM  V_cartera_edades_jjv c WHERE p.nit = c.nit ) As cupo"
                            columna_group &= "p.bloqueo,p.autorizacion"
                            sql_where &= "AND p.autorizacion not in('N')"
                            sql_order = " ORDER BY p.numero"
                        End If
                    End If
                    If (chk_col_consol.CheckedItems(i).ToString = "linea_produccion") Then
                        If (i = 0) Then
                            consol_linea_prod = True
                        End If
                    Else
                        consol_linea_prod = False
                    End If
                End If
                If (i = 0) Then
                    If (columna_group <> "") Then
                        sql_group &= "" & columna_group & ""
                    End If

                    sql_select &= "" & columna_select & ""
                    If columna_select = "p.numero" Then
                        columna_num = True
                    End If
                Else
                    If (columna_group <> "") Then
                        If (sql_group = " GROUP BY ") Then
                            sql_group &= "" & columna_group & ""
                        Else
                            sql_group &= "," & columna_group & ""
                        End If
                    End If
                    If (columna_select <> "") Then
                        If permiso = "ADMIN" Or permiso = "DIR_PRODUCCION" Or permiso = "COOR_PROD" Then
                            If columna_select = "p.numero" Then
                                columna_num = True
                            End If
                            If columna_select = "p.nota_prod" And columna_num = True Then
                                IngresarNotaToolStripMenuItem.Enabled = True
                            End If
                        End If
                        sql_select &= "," & columna_select & ""
                    End If
                End If
                If (i = chk_col_consol.CheckedItems.Count - 1) Then
                    sql_select &= " "
                End If
            End If
        Next
        If (txt_cliente.Text.Trim <> "") Then
            If (sql_where = "WHERE ") Then
                sql_where &= " p.nit =" & txt_cliente.Text
            Else
                sql_where &= " AND p.nit =" & txt_cliente.Text
            End If
        Else
            For i = 0 To ChkListvendedores.CheckedItems.Count - 1
                If (ChkListvendedores.CheckedItems(i).ToString = "TODOS") Then
                    i = ChkListvendedores.CheckedItems.Count - 1
                    If (vendedores <> "") Then
                        If (sql_where = "WHERE ") Then
                            sql_where &= "p.vendedor IN(" & vendedores & ")"
                        Else
                            sql_where &= "AND p.vendedor IN(" & vendedores & ")"
                        End If
                    End If
                Else
                    If (i = 0) Then
                        If (sql_where = "WHERE ") Then
                            sql_where &= "p.vendedor IN('" & ChkListvendedores.CheckedItems(i).ToString & "'"
                        Else
                            sql_where &= "AND p.vendedor IN('" & ChkListvendedores.CheckedItems(i).ToString & "'"
                        End If
                    Else
                        sql_where &= ",'" & ChkListvendedores.CheckedItems(i).ToString & "'"
                    End If
                    If (i = ChkListvendedores.CheckedItems.Count - 1) Then
                        sql_where &= ") "
                    End If

                End If
            Next
            If (ChkListvendedores.CheckedItems.Count = 0) Then
                If (vendedores <> "") Then
                    If (sql_where = "WHERE ") Then
                        sql_where &= "p.vendedor IN(" & vendedores & ")"
                    Else
                        sql_where &= "AND p.vendedor IN(" & vendedores & ")"
                    End If
                End If
            End If
            For i = 0 To chk_ciudades.CheckedItems.Count - 1
                If (chk_ciudades.CheckedItems(i).ToString = "TODO") Then
                    i = chk_ciudades.CheckedItems.Count - 1
                Else
                    If (i = 0) Then
                        If (sql_where = "WHERE ") Then
                            sql_where &= "p.ciudad IN('" & chk_ciudades.CheckedItems(i).ToString & "'"
                        Else
                            sql_where &= "AND p.ciudad IN('" & chk_ciudades.CheckedItems(i).ToString & "'"
                        End If
                    Else
                        sql_where &= ",'" & chk_ciudades.CheckedItems(i).ToString & "'"
                    End If
                    If (i = chk_ciudades.CheckedItems.Count - 1) Then
                        sql_where &= ") "
                    End If

                End If
            Next
        End If
        If (txt_cod_filtro.Text.Trim <> "") Then
            If (sql_where = "WHERE ") Then
                sql_where &= " p.codigo like'" & txt_cod_filtro.Text & "%' "
            Else
                sql_where &= " AND p.codigo like'" & txt_cod_filtro.Text & "%' "
            End If
        ElseIf (txt_excluir_cod.Text.Trim <> "") Then
            If (sql_where = "WHERE ") Then
                sql_where &= " p.codigo not like'" & txt_excluir_cod.Text & "%' "
            Else
                sql_where &= " AND p.codigo not like'" & txt_excluir_cod.Text & "%' "
            End If
        ElseIf (chkLinea.CheckedItems.Count <> 0) Then
            For i = 0 To chkLinea.CheckedItems.Count - 1
                If (chkLinea.CheckedItems(i).ToString = "TODOS") Then
                    i = chkLinea.CheckedItems.Count - 1
                Else
                    If (i = 0) Then
                        If (sql_where = "WHERE ") Then
                            sql_where &= "p.linea_produccion IN('" & chkLinea.CheckedItems(i).ToString & "'"
                        Else
                            sql_where &= "AND p.linea_produccion IN('" & chkLinea.CheckedItems(i).ToString & "'"
                        End If
                    Else
                        sql_where &= ",'" & chkLinea.CheckedItems(i).ToString & "'"
                    End If
                    If (i = chkLinea.CheckedItems.Count - 1) Then
                        sql_where &= ") "
                    End If
                End If
            Next
        End If
        If (txtNumero.Text.Trim <> "") Then
            If (sql_where = "WHERE ") Then
                sql_where &= " p.numero like'" & txtNumero.Text & "%' "
            Else
                sql_where &= " AND p.numero like'" & txtNumero.Text & "%' "
            End If
        End If
        If (cbo_bodega.SelectedValue <> "TODO") Then
            If (sql_where = "WHERE ") Then
                sql_where &= " p.bodega = " & cbo_bodega.SelectedValue & " "
            Else
                sql_where &= " AND p.bodega = " & cbo_bodega.SelectedValue & " "
            End If
        End If
        If (sql_where = "WHERE ") Then
            sql_where = ""
        End If
        If (sql_group = "GROUP BY ") Then
            sql_group = ""
        End If
        sql_where &= " and p.nota1 is null "
        If (mostrar_producido_calidad()) Then
            sql_select &= ",producido,(SELECT CASE WHEN (p.numero IN (SELECT numero_pedido FROM prgproduccion.dbo.J_certificado_calidad WHERE numero_pedido = p.numero  GROUP BY numero_pedido))THEN 'S' ELSE 'N' END) As certificado,calidad,adicional "
            sql_group &= ",producido,calidad,adicional "
        End If
        sql = sql_select & sql_from & sql_where & sql_group & sql_order
        If (select_col_stock) Then
            buscarFaltantes(sql_where)
        End If
        Return sql
    End Function
    Private Function mostrar_producido_calidad() As Boolean
        Dim resp As Boolean = False
        Dim numero As Boolean = False
        Dim cliente As Boolean = False
        Dim codigo As Boolean = False
        Dim cantidad As Boolean = False
        Dim notas As Boolean = false
        For i = 0 To chk_col_consol.CheckedItems.Count - 1
            If (chk_col_consol.CheckedItems(i) = "codigo") Then
                codigo = True
            ElseIf (chk_col_consol.CheckedItems(i) = "nit" Or chk_col_consol.CheckedItems(i) = "nombres") Then
                cliente = True
            ElseIf (chk_col_consol.CheckedItems(i) = "numero") Then
                numero = True
            ElseIf (chk_col_consol.CheckedItems(i) = "Cant_pedida") Then
                cantidad = True
            ElseIf (chk_col_consol.CheckedItems(i) = "notas") Then
                notas = True
            End If
        Next
        If (cliente And numero And codigo And cantidad And notas) Then
            resp = True
            calidad = True
        End If
        Return resp
    End Function

    Private Sub pintarProblemas()
        Dim sum_problemas As Double = 0
        Dim sum_prob_log As Double = 0
        Dim sum_prob_prod As Double = 0
        Dim sum_prob_cupo As Double = 0
        Dim sum_prob_doc_venc As Double = 0
        Dim sum_prob_bloqueo As Double = 0
        For i = 0 To dtg_consulta.RowCount - 2
            If IsDBNull(dtg_consulta.Item("autorizacion", i).Value) Then
                If (dtg_consulta.Item("cupo", i).Value.ToString = "S" Or dtg_consulta.Item("doc_vencidos", i).Value.ToString = "S" Or dtg_consulta.Item("bloqueo", i).Value.ToString <> "0") Then
                    dtg_consulta.Rows(i).DefaultCellStyle.BackColor = Color.Red
                    If Not IsDBNull(dtg_consulta.Item("valor_total", i).Value) Then
                        sum_problemas += dtg_consulta.Item("valor_total", i).Value
                        If (dtg_consulta.Item("bloqueo", i).Value.ToString <> "0") Then
                            sum_prob_bloqueo += dtg_consulta.Item("valor_total", i).Value
                        ElseIf (dtg_consulta.Item("doc_vencidos", i).Value.ToString = "S") Then
                            sum_prob_doc_venc += dtg_consulta.Item("valor_total", i).Value
                        ElseIf (dtg_consulta.Item("cupo", i).Value.ToString = "S") Then
                            sum_prob_cupo += dtg_consulta.Item("valor_total", i).Value
                        End If
                    End If
                    If Not IsDBNull(dtg_consulta.Item("val_pend_log", i).Value) Then
                        sum_prob_log += dtg_consulta.Item("val_pend_log", i).Value
                    End If
                    If Not IsDBNull(dtg_consulta.Item("val_pend_prod", i).Value) Then
                        sum_prob_prod += dtg_consulta.Item("val_pend_prod", i).Value
                    End If
                End If
            ElseIf (dtg_consulta.Item("autorizacion", i).Value <> "S" And dtg_consulta.Item("autorizacion", i).Value <> "A") Then
                If (dtg_consulta.Item("cupo", i).Value = "S" Or dtg_consulta.Item("doc_vencidos", i).Value = "S" Or dtg_consulta.Item("bloqueo", i).Value <> "0") Then
                    dtg_consulta.Rows(i).DefaultCellStyle.BackColor = Color.Red
                    If Not IsDBNull(dtg_consulta.Item("valor_total", i).Value) Then
                        sum_problemas += dtg_consulta.Item("valor_total", i).Value
                    End If
                    If Not IsDBNull(dtg_consulta.Item("val_pend_prod", i).Value) Then
                        sum_prob_prod += dtg_consulta.Item("val_pend_prod", i).Value
                    End If
                End If
            End If
        Next
        txtSumProblemas.Text = sum_problemas.ToString("C0")
        txtSumProbLog.Text = sum_prob_log.ToString("C0")
        txtSumProbProd.Text = sum_prob_prod.ToString("C0")

        txtProbBloqueo.Text = sum_prob_bloqueo.ToString("C0")
        txtProbDocVenc.Text = sum_prob_doc_venc.ToString("C0")
        txtProCupo.Text = sum_prob_cupo.ToString("C0")
    End Sub

    Private Sub btn_cerrar_Click(sender As System.Object, e As System.EventArgs) Handles btn_cerrar.Click
        txt_nit.Text = ""
        txt_nombres.Text = ""
        dtg_clientes.DataSource = Nothing
        groupCliente.Visible = False
    End Sub
    Private Sub cargar_clientes()
        Dim sql As String = "Select nit,nombres,ciudad FROM terceros "
        Dim whereSql As String = "WHERE (concepto_1 like '%3%' or concepto_1 like '%4%' or concepto_1 like '%9%') "
        If (txt_nit.Text <> "") Then
            whereSql &= " AND nit like '" & txt_nit.Text & "%'"
        ElseIf (txt_nombres.Text <> "") Then
            whereSql &= "AND nombres like '%" & txt_nombres.Text & "%'"
        End If
        sql &= whereSql
        dtg_clientes.DataSource = objOpSimplesLn.listar_datatable(sql, "CORSAN")
    End Sub
    Private Sub dtg_clientes_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtg_clientes.CellContentClick
        If (e.RowIndex >= 0) Then
            If (dtg_clientes.Columns(e.ColumnIndex).Name = colOk.Name) Then
                txt_cliente.Text = ""
                txt_cliente.Text = dtg_clientes.Item("nit", e.RowIndex).Value
                groupCliente.Visible = False
                dtg_clientes.DataSource = Nothing
                txt_nit.Text = ""
                txt_nombres.Text = ""
            End If
        End If
    End Sub
    Private Sub txt_nit_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txt_nit.KeyPress
        soloNumero(e)
    End Sub
    Private Sub soloNumero(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If (Char.IsDigit(e.KeyChar) Or e.KeyChar = ".") Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub
    Private Sub txt_nit_TextChanged(sender As System.Object, e As System.EventArgs) Handles txt_nit.TextChanged
        carga_comp = False
        txt_nombres.Text = ""
        carga_comp = True
        If (carga_comp And txt_nit.Text.Length > 2) Then
            cargar_clientes()
        End If
    End Sub
    Private Sub txt_nombres_TextChanged(sender As System.Object, e As System.EventArgs) Handles txt_nombres.TextChanged
        carga_comp = False
        txt_nit.Text = ""
        carga_comp = True
        If (carga_comp And txt_nombres.Text.Length > 3) Then
            cargar_clientes()
        End If
    End Sub
    Private Sub cargar_ciudades()
        If (carga_comp) Then
            chk_ciudades.Items.Clear()
            Dim whereSql As String = "WHERE ter.concepto_1 = 04 "
            Dim orderSql As String = "ORDER BY ter.ciudad"
            Dim groupSql As String = "GROUP BY ter.ciudad "
            Dim sql As String = "SELECT ter.ciudad " & _
                                     "FROM terceros ter "
            sql &= whereSql & groupSql & orderSql
            Dim lista As New List(Of Object)
            lista = objOpSimplesLn.lista(sql)
            For i As Integer = 0 To lista.Count - 1 Step 1
                If (i = 0) Then
                    chk_ciudades.Items.Add("TODO")
                End If
                chk_ciudades.Items.Add(lista(i))
            Next
        End If
    End Sub

    Private Sub btn_excel_Click(sender As System.Object, e As System.EventArgs) Handles btn_excel.Click
        objOperacionesForm.ExportarDatosExcel(dtg_consulta, "Pendientes")
    End Sub

    Private Sub cbo_departamento_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)
        cargar_ciudades()
    End Sub
    Private Sub buscarFaltantes(ByVal whereSql As String)
        Dim dt_con_faltantes As New DataTable
        Dim sql_con_faltantes As String = ""
        Dim diferente As Boolean = False
        Dim dt_completo As New DataTable
        Dim dt_faltante As New DataTable
        Dim dtNew As New DataTable
        Dim sql_faltante As String = "SELECT distinct p.numero,p.codigo " & _
                                        "FROM J_v_pendientes_por_vendedor_id_cor p,v_referencias_sto_hoy r " & _
                                            whereSql & _
                                                    " ORDER by p.numero,p.codigo"
        If (whereSql = "WHERE p.bodega = r.bodega AND p.codigo = r.codigo AND p.autorizacion not in ('N')") Then
            whereSql = ""
        Else
            whereSql = whereSql.Replace("  ", " ")
            whereSql = whereSql.Replace("p.bodega in (2,3) AND p.codigo = r.codigo AND", "")
        End If
        whereSql = ""
        Dim sql_completo As String = "SELECT p.numero,p.codigo " & _
                                      "FROM J_v_pendientes_por_vendedor_id_cor p " & _
                                      whereSql & _
                                       " ORDER by p.numero,p.codigo"
        dt_completo = objOpSimplesLn.listar_datatable(sql_completo, "CORSAN")
        dt_faltante = objOpSimplesLn.listar_datatable(sql_faltante, "CORSAN")
        Dim k As Integer = 0
        If (dt_completo.Rows.Count <> dt_faltante.Rows.Count) Then
            For i = 0 To dt_faltante.Rows.Count - 1
                If (dt_completo.Rows(i).Item("numero") <> dt_faltante.Rows(k).Item("numero") Or dt_completo.Rows(i).Item("codigo") <> dt_faltante.Rows(k).Item("codigo")) Then
                    If (sql_con_faltantes = "") Then
                        sql_con_faltantes = "SELECT p.fecha,p.numero,p.codigo,p.descripcion,p.vendedor,p.nit,p.nombres,p.Cant_pedida,p.cantidad_despachada,p.Pendiente,p.valor_unitario,p.KilosPendiente,p.valor_total,p.ciudad,p.bodega FROM V_pendientes_por_vendedor p WHERE numero = " & dt_completo.Rows(i).Item("numero") & "  AND codigo = '" & dt_completo.Rows(i).Item("codigo") & "'"
                        dt_con_faltantes = objOpSimplesLn.listar_datatable(sql_con_faltantes, "CORSAN")
                    Else
                        sql_con_faltantes = "SELECT p.fecha,p.numero,p.codigo,p.descripcion,p.vendedor,p.nit,p.nombres,p.Cant_pedida,p.cantidad_despachada,p.Pendiente,p.valor_unitario,p.KilosPendiente,p.valor_total,p.ciudad,p.bodega FROM V_pendientes_por_vendedor p WHERE numero = " & dt_completo.Rows(i).Item("numero") & "  AND codigo = '" & dt_completo.Rows(i).Item("codigo") & "'"
                        dtNew = objOpSimplesLn.listar_datatable(sql_con_faltantes, "CORSAN")
                        dt_con_faltantes.ImportRow(dtNew.Rows(0))
                    End If
                    diferente = True
                End If
                If (diferente) Then
                    diferente = False
                Else
                    k += 1
                End If
                If i = dt_faltante.Rows.Count - 1 Then
                    If (sql_con_faltantes = "") Then
                        For z = i + 1 To dt_completo.Rows.Count - 1
                            If (sql_con_faltantes = "") Then
                                sql_con_faltantes = "SELECT p.fecha,p.numero,p.codigo,p.descripcion,p.vendedor,p.nit,p.nombres,p.Cant_pedida,p.cantidad_despachada,p.Pendiente,p.valor_unitario,p.KilosPendiente,p.valor_total,p.ciudad,p.bodega FROM V_pendientes_por_vendedor p WHERE numero = " & dt_completo.Rows(z).Item("numero") & "  AND codigo = '" & dt_completo.Rows(z).Item("codigo") & "'"
                                dt_con_faltantes = objOpSimplesLn.listar_datatable(sql_con_faltantes, "CORSAN")
                            Else
                                dtNew = New DataTable
                                sql_con_faltantes = "SELECT p.fecha,p.numero,p.codigo,p.descripcion,p.vendedor,p.nit,p.nombres,p.Cant_pedida,p.cantidad_despachada,p.Pendiente,p.valor_unitario,p.KilosPendiente,p.valor_total,p.ciudad,p.bodega FROM V_pendientes_por_vendedor p WHERE numero = " & dt_completo.Rows(z).Item("numero") & "  AND codigo = '" & dt_completo.Rows(z).Item("codigo") & "'"
                                dtNew = objOpSimplesLn.listar_datatable(sql_con_faltantes, "CORSAN")
                                dt_con_faltantes.ImportRow(dtNew.Rows(0))
                            End If
                        Next
                    End If
                End If
            Next
            dtg_faltantes.DataSource = dt_con_faltantes
            If dt_con_faltantes.Rows.Count > 0 Then
                dtg_faltantes.Columns("fecha").DefaultCellStyle.Format = "d"
            End If
        End If
    End Sub
    Private Function calcular_prod_log(ByRef dt As DataTable) As DataTable
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
                    If (dt.Rows(i).Item("bodega") = 3) Then
                        sum_prod_bod3 += dt.Rows(i).Item("pend_prod")
                        sum_val_prod_bod3 += dt.Rows(i).Item("val_pend_prod")
                        sum_stock_bod3 += dt.Rows(i).Item("stock")
                    Else
                        sum_prod_bod7 += dt.Rows(i).Item("pend_prod")
                        sum_val_prod_bod7 += dt.Rows(i).Item("val_pend_prod")
                        sum_stock_bod7 += dt.Rows(i).Item("stock")
                    End If

                Next
            ElseIf (dt.Columns(j).ColumnName = "pend_log") Then
                For i = 0 To dt.Rows.Count - 1
                    If (dt.Rows(i).Item("pend_log") > dt.Rows(i).Item("Pendiente")) Then
                        dt.Rows(i).Item("pend_log") = dt.Rows(i).Item("Pendiente")
                    End If
                    dt.Rows(i).Item("val_pend_log") = dt.Rows(i).Item("pend_log") * dt.Rows(i).Item("valor_unitario")
                    If (dt.Rows(i).Item("bodega") = 3) Then
                        sum_log_bod3 += dt.Rows(i).Item("pend_log")
                        sum_val_log_bod3 += dt.Rows(i).Item("val_pend_log")
                    Else
                        sum_log_bod7 += dt.Rows(i).Item("pend_log")
                        sum_val_log_bod7 += dt.Rows(i).Item("val_pend_log")
                    End If
                Next
                'j = dt.Columns.Count - 1
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
        If (resumen_pend_prod_log) Then
            txt_prod_bod7.Text = (sum_prod_bod7).ToString("N0")
            txt_log_bod7.Text = sum_log_bod7.ToString("N0")
            txt_prod_bod3.Text = (sum_prod_bod3).ToString("N0")
            txt_log_bod3.Text = sum_log_bod3.ToString("N0")
            txt_tot_log.Text = (sum_log_bod3 + sum_log_bod7).ToString("N0")
            txt_tot_prod.Text = ((sum_prod_bod3 + sum_prod_bod7)).ToString("N0")
            txtStockB3.Text = (sum_stock_bod3).ToString("N0")
            txtStockB7.Text = (sum_stock_bod7).ToString("N0")
            txtTotStock.Text = ((sum_stock_bod3 + sum_stock_bod7)).ToString("N0")
            If (permiso_valores) Then
                txt_prod_bod7.Text &= " - " & sum_val_prod_bod7.ToString("C0")
                txt_log_bod7.Text &= " - " & sum_val_log_bod7.ToString("C0")
                txt_prod_bod3.Text &= " - " & sum_val_prod_bod3.ToString("C0")
                txt_log_bod3.Text &= " - " & sum_val_log_bod3.ToString("C0")
                txt_tot_log.Text &= " - " & (sum_val_log_bod3 + sum_val_log_bod7).ToString("C0")
                txt_tot_prod.Text &= " - " & (sum_val_prod_bod3 + sum_val_prod_bod7).ToString("C0")
            End If
        Else
            txt_prod_bod7.Text = "NO APLICA"
            txt_log_bod7.Text = "NO APLICA"
            txt_prod_bod3.Text = "NO APLICA"
            txt_log_bod3.Text = "NO APLICA"
            txt_tot_log.Text = "NO APLICA"
            txt_tot_prod.Text = "NO APLICA"
            txtStockB3.Text = "NO APLICA"
            txtStockB7.Text = "NO APLICA"
            txtTotStock.Text = "NO APLICA"
        End If
   
        Return dt
    End Function

    Private Sub btnQuitarcol_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuitarCol.Click
        Dim Columna As String = listPermisosUsuario.SelectedItem
        Dim indexMod As Integer = 0
        Dim resp As Integer = 0
        Dim sql As String = ""
        If (Columna <> "" And permiso <> "") Then
            resp = MessageBox.Show("Esta seguro de quitar este permiso? ", "Quitar", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
            If (resp = 6) Then
                sql = "DELETE FROM J_spic_per_columna_pendientes WHERE columna ='" & Columna & "' AND permiso = '" & permiso & "'"
                If (objOpSimplesLn.ejecutar(sql, "CORSAN") > 0) Then
                    indexMod = listPermisosUsuario.SelectedIndex
                    listPermisosUsuario.Items.Remove(listPermisosUsuario.Items(indexMod))
                Else
                    MsgBox("Error al eliminar")
                End If
            End If
        Else
            MsgBox("Seleccione permiso y columna a eliminar")
        End If
    End Sub

    Private Sub listColumnas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles listColumnas.SelectedIndexChanged
        columnaArbol = listColumnas.SelectedItem
        addColumna()
    End Sub

    Private Sub btnConfigPermisos_Click(sender As Object, e As EventArgs) Handles btnConfigPermisos.Click
        groupPermisos.Visible = True
    End Sub

    Private Sub btnOcultPermisos_Click(sender As Object, e As EventArgs) Handles btnOcultPermisos.Click
        groupPermisos.Visible = False
    End Sub
   
    Private Function consolidarLineaProducción(ByVal dt As DataTable) As DataTable
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
            If (dt.Columns(k).ColumnName <> "notas" And dt.Columns(k).ColumnName <> "notas5" And dt.Columns(k).ColumnName <> "notas_aut" And dt.Columns(k).ColumnName <> "autoriz_texto" And dt.Columns(k).ColumnName <> "nota_prod") Then
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

    Private Sub chkMarcarProblemas_CheckedChanged(sender As Object, e As EventArgs) Handles chkMarcarProblemas.CheckedChanged
        If (chkMarcarProblemas.Checked = True) Then
            verificarChkProblemas()
        End If
    End Sub
    Private Sub verificarChkProblemas()
        Dim nit As Boolean = False
        Dim numero As Boolean = False
        Dim codigo As Boolean = False
        Dim valor_total As Boolean = False
        For i = 0 To chk_col_consol.CheckedItems.Count - 1
            If (chk_col_consol.CheckedItems(i).ToString = "numero") Then
                numero = True
            ElseIf (chk_col_consol.CheckedItems(i).ToString = "nit") Then
                nit = True
            ElseIf (chk_col_consol.CheckedItems(i).ToString = "codigo") Then
                codigo = True
            ElseIf (chk_col_consol.CheckedItems(i).ToString = "valor_total") Then
                valor_total = True
            End If
        Next
        If (nit = False Or numero = False Or codigo = False Or valor_total = False) Then
            MessageBox.Show("Para utilizar la funcion,'MARCAR PROBLEMAS',verifique que minimamente este seleccionado 'numero','nit','codigo','valor_total'", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            chkMarcarProblemas.Checked = False
        End If
    End Sub
    Private Function verificarColumnaPermisos(ByRef dt As DataTable) As DataTable
        Dim permis_valor_unitario As Boolean = False
        Dim permiso_logistica As Boolean = False
        Dim permiso_produccion As Boolean = False
        Dim mostrarValorUnitario As Boolean = False
        Dim mostrarProducido_calidad As Boolean = False
        For i = 0 To dt_columnas_permiso.Rows.Count - 1
            If (dt_columnas_permiso.Rows(i).Item("columna") = "valor_unitario") Then
                permis_valor_unitario = True
            ElseIf (dt_columnas_permiso.Rows(i).Item("columna") = "pend_log") Then
                permiso_logistica = True
            ElseIf (dt_columnas_permiso.Rows(i).Item("columna") = "pend_prod") Then
                permiso_produccion = True
            ElseIf (dt_columnas_permiso.Rows(i).Item("columna") = "producido") Then
                mostrarProducido_calidad = True
            End If

        Next
        If Not (permis_valor_unitario) Then
            For i = 0 To dt.Columns.Count - 1
                If (dt.Columns(i).ColumnName = "valor_unitario") Then
                    i = dt.Columns.Count - 1
                    mostrarValorUnitario = False
                End If
            Next
        Else
            For i = 0 To chk_col_consol.CheckedItems.Count - 1
                If (chk_col_consol.CheckedItems(i) = "valor_unitario") Then
                    mostrarValorUnitario = True
                End If
            Next
        End If
        If Not (permiso_valores) Then
            eliminarColumna(dt, "val_pend_prod")
            eliminarColumna(dt, "val_pend_log")
        End If
        If Not (permiso_logistica) Then
            eliminarColumna(dt, "pend_log")
        End If
        If Not (permiso_produccion) Then
            eliminarColumna(dt, "pend_prod")
        End If
        If Not (mostrarValorUnitario) Then
            eliminarColumna(dt, "valor_unitario")
        End If
        If Not (mostrarProducido_calidad) Then
            eliminarColumna(dt, "producido")
            eliminarColumna(dt, "calidad")
            eliminarColumna(dt, "adicional")
        End If
        Return dt
    End Function
    Private Sub eliminarColumna(ByRef dt As DataTable, ByVal col As String)
        For i = 0 To dt.Columns.Count - 1
            If (dt.Columns(i).ColumnName = col) Then
                dt.Columns.Remove(col)
                i = dt.Columns.Count
                'No se le coloca el -1 por que la columna se elimino por lo tanto con el -1 se desborda
            End If
        Next
    End Sub
    'Private Sub dtg_consulta_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtg_consulta.CellContentClick
    '    If (e.RowIndex = -1) Then
    '        If (dtg_consulta.Rows.Count > 0) Then
    '            Dim nit As Boolean = False
    '            Dim numero As Boolean = False
    '            Dim codigo As Boolean = False
    '            Dim valor_total As Boolean = False
    '            For i = 0 To dtg_consulta.Columns.Count - 1
    '                If (dtg_consulta.Columns(i).Name = "numero") Then
    '                    numero = True
    '                ElseIf (dtg_consulta.Columns(i).Name = "nit") Then
    '                    nit = True
    '                ElseIf (dtg_consulta.Columns(i).Name = "codigo") Then
    '                    codigo = True
    '                ElseIf (dtg_consulta.Columns(i).Name = "valor_total") Then
    '                    valor_total = True
    '                End If
    '            Next
    '            If (nit = True And numero = True And codigo = True And valor_total = True) Then
    '                pintarProblemas()
    '            End If
    '        End If
    '    End If
    'End Sub

    Private Sub chkLinea_ItemCheck(sender As Object, e As ItemCheckEventArgs) Handles chkLinea.ItemCheck
        If (carga_comp) Then
            carga_comp = False
            txt_cod_filtro.Text = ""
            carga_comp = True
        End If
    End Sub

    Private Sub dtg_consulta_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtg_consulta.CellContentClick
        'If (e.RowIndex = -1) Then
        '    imgProcesar.Visible = True
        '    Application.DoEvents()
        '    Dim pintar_problemas As Boolean = False
        '    For i = 0 To dtg_consulta.ColumnCount - 1
        '        If (dtg_consulta.Columns(i).Name = "doc_vencidos") Then
        '            pintar_problemas = True
        '            i = dtg_consulta.ColumnCount - 1
        '        End If
        '    Next
        '    If (pintar_problemas) Then
        '        pintarProblemas()
        '    End If
        '    imgProcesar.Visible = False
        'End If
        If (e.RowIndex >= 0) Then
            If (dtg_consulta.Columns(e.ColumnIndex).Name = "producido" Or dtg_consulta.Columns(e.ColumnIndex).Name = "calidad") Then
                If IsDBNull(dtg_consulta.Item(e.ColumnIndex, e.RowIndex).Value) Then
                    dtg_consulta.Item(e.ColumnIndex, e.RowIndex).Value = 1
                ElseIf (dtg_consulta.Item(e.ColumnIndex, e.RowIndex).Value) Then
                    dtg_consulta.Item(e.ColumnIndex, e.RowIndex).Value = 0
                Else
                    dtg_consulta.Item(e.ColumnIndex, e.RowIndex).Value = 1
                End If
                Dim estado As Integer = 0
                If (dtg_consulta.Item(e.ColumnIndex, e.RowIndex).Value) Then
                    estado = 1
                End If
                Dim numero As Double = dtg_consulta.Item("numero", e.RowIndex).Value
                Dim codigo As String = dtg_consulta.Item("codigo", e.RowIndex).Value

                Dim sql As String = "UPDATE documentos_lin_ped SET " & dtg_consulta.Columns(e.ColumnIndex).Name & " = " & estado & " WHERE numero =" & numero & " AND codigo = '" & codigo & "'"
                If (objOpSimplesLn.ejecutar(sql, "CORSAN") > 0) Then
                    If (permiso = "CALIDAD" Or permiso = "AUX_CALIDAD" Or objUsuarioEn.usuario = "ADMIN") And calidad = True Then
                        Dim cantidad As String = dtg_consulta.Item("cant_pedida", e.RowIndex).Value
                        Dim notas As String = dtg_consulta.Item("notas", e.RowIndex).Value
                        Dim nombres As String = dtg_consulta.Item("nombres", e.RowIndex).Value
                        enviarCorreoCalidad(numero, codigo, cantidad, notas, nombres)
                    End If
                    MessageBox.Show("Registro modificado en forma correcta", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("No se modifico ningun registro", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        End If
    End Sub

    Private Sub dtg_consulta_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dtg_consulta.CellValueChanged
        If (e.RowIndex >= 0) Then
            If (dtg_consulta.Columns(e.ColumnIndex).Name = "adicional") Then
                Dim numero As Double = dtg_consulta.Item("numero", e.RowIndex).Value
                Dim codigo As String = dtg_consulta.Item("codigo", e.RowIndex).Value
                Dim adicional As String = dtg_consulta.Item("adicional", e.RowIndex).Value
                Dim sql As String = "UPDATE documentos_lin_ped SET " & dtg_consulta.Columns(e.ColumnIndex).Name & " = '" & adicional & "' WHERE numero =" & numero & " AND codigo = '" & codigo & "'"
                If (objOpSimplesLn.ejecutar(sql, "CORSAN") > 0) Then
                    MessageBox.Show("Registro modificado en forma correcta", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("No se modifico ningun registro", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        End If
    End Sub

    Private Sub txt_cod_filtro_TextChanged(sender As Object, e As EventArgs) Handles txt_cod_filtro.TextChanged
        txt_codigo_inventarios.Text = txt_cod_filtro.Text
    End Sub


    Private Sub btn_act_inventarios_Click(sender As Object, e As EventArgs) Handles btn_act_inventarios.Click
        imgProcesar.Visible = True
        Application.DoEvents()
        cargar_tot_inventarios()
        imgProcesar.Visible = False
    End Sub
    Private Sub txt_cliente_Click(sender As Object, e As EventArgs) Handles txt_cliente.Click
        txt_cliente.Text = ""
        groupCliente.Visible = True
        txt_nombres.Focus()
    End Sub
    Private Sub IngresarNotaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IngresarNotaToolStripMenuItem.Click
        Dim numero As Integer = dtg_consulta.Item("numero", dtg_consulta.CurrentCell.RowIndex).Value
        Dim formu As New frm_notas_prod
        formu.main(numero, Me)
        formu.Show
    End Sub
    Private Sub enviarCorreoCalidad(ByVal numero As Double, ByVal codigo As String, ByVal cantidad As String, ByVal notas As String, ByVal nombres As String)
        Dim sql_admin As String = "SELECT mail,Mail_login  FROM Jjv_usuarios WHERE usuario = 'ADMIN' "
        Dim dt_admin As DataTable = objOpSimplesLn.listar_datatable(sql_admin, "CORSAN")
        Dim mail As String

        Dim asunto As String = "Pedido aprobado por calidad"
        Dim cuerpo As String = "Número del pedido : " & numero & vbCrLf & _
                               "Codigo de referencia : " & codigo & vbCrLf & _
                               "Nombre de cliente : " & nombres & vbCrLf & _
                               "Cantidad pedida: " & cantidad & vbCrLf & _
                               "Notas: " & notas & vbCrLf & _
                               "Fecha: " & Now
        Dim mailEnvia As String = dt_admin.Rows(0).Item("mail")
        Dim mailEnviaPass As String = dt_admin.Rows(0).Item("Mail_login")
        mail = "david.hincapie@corsan.com.co"
        obj_correoLn.EnviarCorreo(mail, cuerpo, asunto, "", mailEnvia, mailEnviaPass, False)
        mail = "liliana.garcia@corsan.com.co"
        obj_correoLn.EnviarCorreo(mail, cuerpo, asunto, "", mailEnvia, mailEnviaPass, False)
        mail = "serviciocliente@corsan.com.co"
        obj_correoLn.EnviarCorreo(mail, cuerpo, asunto, "", mailEnvia, mailEnviaPass, False)
    End Sub
    Private Sub tsb_pendientes_ventas_Click(sender As Object, e As EventArgs) Handles tsb_pendientes_ventas.Click
        Dim frm As New Frm_informe_pend__vent
        frm.Show()
    End Sub
End Class