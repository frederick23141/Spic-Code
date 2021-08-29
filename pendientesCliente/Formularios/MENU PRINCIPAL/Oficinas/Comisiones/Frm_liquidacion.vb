Imports entidadNegocios
Imports logicaNegocios
Class Frm_liquidacion
    Private objOperacionesForm As OperacionesFormularios = New OperacionesFormularios
    Private obj_op_simplesLn As New Op_simpesLn
    Private nomb_modulo As String
    Dim dt_ventas As New DataTable
    Dim dt_recaudos As New DataTable
    Dim dt_rentabilidad As New DataTable
    Dim dt_com_ventas As New DataTable
    Dim dt_com_coor_dir As New DataTable
    Dim usuario As UsuarioEn
    Dim carga_comp As Boolean = False
    Dim num_ndch_partir As Double = 0
    Dim fecha_ndch_partir As Date
    Dim strDtgSeleccion As String = ""
    Private BindingSource1 As Windows.Forms.BindingSource = New BindingSource
    Dim congelar As String = ""



    Public Sub Main(ByVal nomb_modulo As String, ByVal usuario As UsuarioEn)
        Me.nomb_modulo = nomb_modulo
        Me.usuario = usuario
        If (usuario.permiso.Trim = "VENDEDOR") Then
            cbo_vend.SelectedValue = usuario.Vendedor
            cbo_vend_filtro.SelectedValue = usuario.Vendedor
            cbo_vend.Enabled = False
            cbo_vend_filtro.Enabled = False
            btn_admin_reglas.Enabled = False
            menStripDtg.Enabled = False
            menModScript.Enabled = False
            TabControl1.TabPages.Remove(tab_liq_rent)
            TabControl1.TabPages.Remove(tab_com_vtas)
            TabControl1.TabPages.Remove(tab_com_coor_vend)
        End If
        carga_comp = True

    End Sub

    Private Sub Frm_liquidacion_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        For i = Now.Year - 1 To Now.Year + 1
            cbo_ano_cong.Items.Add(i)
        Next
        cbo_fecha_ini.Value = DateSerial(Year(Now), Month(Now), 1)
        cbo_fecha_fin.Value = DateSerial(Year(Now), Month(Now) + 1, 0)
        Dim sql As String = "SELECT id,descripcion FROM J_tipo_comision "
        Dim dt As New DataTable
        Dim dr As DataRow
        Dim año = Now.Year
        cbo_mes_cong.SelectedIndex = Now.Month - 1
        cbo_ano_cong.Text = Now.Year
        sql = " SELECT CAST(vendedor AS varchar(25))As vendedor FROM  v_vendedores WHERE  vendedor >= 1001 and vendedor <=1099 and bloqueo =0  GROUP BY vendedor "

        dt = New DataTable
        dt = obj_op_simplesLn.listar_datatable(sql, "CORSAN")
        dr = dt.NewRow
        dr("vendedor") = "TODOS"
        dr("vendedor") = "TODOS"
        dt.Rows.Add(dr)
        cbo_vend.DataSource = dt
        cbo_vend.ValueMember = "vendedor"
        cbo_vend.DisplayMember = "vendedor"
        cbo_vend.Text = "TODOS"

        dt = New DataTable
        dt = obj_op_simplesLn.listar_datatable(sql, "CORSAN")
        dr = dt.NewRow
        dr("vendedor") = "TODOS"
        dr("vendedor") = "TODOS"
        dt.Rows.Add(dr)
        cbo_vend_filtro.DataSource = dt
        cbo_vend_filtro.ValueMember = "vendedor"
        cbo_vend_filtro.DisplayMember = "vendedor"


        TabControl1.SelectedTab = tab_consol_rec
        TabControl1.SelectedTab = tab_info_rec
        TabControl1.SelectedTab = tab_liq_rec
        TabControl1.SelectedTab = tab_liq_rent
        TabControl1.SelectedTab = tab_liq_vtas

    End Sub
    Private Function buscarNumFila(ByVal nomb_col As String, ByVal texto_fila As String, ByVal dtg As DataGridView) As Integer
        For i = 0 To dtg.Rows.Count - 1
            If Not IsDBNull(dtg.Item(nomb_col, i).Value) Then
                If (dtg.Item(nomb_col, i).Value.ToString = texto_fila) Then
                    Return i
                End If
            End If
        Next
        Return 0
    End Function
    Private Sub btnActualizar_Click(sender As System.Object, e As System.EventArgs) Handles btnActualizar.Click
        carga_comp = False
        cbo_vend_filtro.SelectedValue = "TODOS"
        cbo_tipo_clasificación.SelectedItem = "TODO"
        img_procesar.Visible = True
        Application.DoEvents()
        cargar_consulta()
        img_procesar.Visible = False
        carga_comp = True
        If (cbo_vend.Text <> "TODOS") Then
            cbo_vend_filtro.SelectedValue = cbo_vend.SelectedValue
            ocultar_vend_consolidado()
        End If
    End Sub
    Private Sub cargar_consulta()
        Dim tamano_letra As Single = 9.0!
        dt_ventas = New DataTable
        dt_recaudos = New DataTable
        dt_rentabilidad = New DataTable
        armar_dtg()
        Dim sql_script_modulos As String = "SELECT descripcion_col, script,consecutivo,numero  FROM  J_script_modulos_prueba WHERE desc_modulo ='" & nomb_modulo & "'"
        Dim dt_script As DataTable = obj_op_simplesLn.listar_datatable(sql_script_modulos, "CORSAN")
        Dim sql_consulta As String = ""
        For i = 0 To dt_script.Rows.Count - 1
            sql_consulta = modificarSql(dt_script.Rows(i).Item("script"))
            If (dt_script.Rows(i).Item("consecutivo") = 1 Or dt_script.Rows(i).Item("consecutivo") = 2 Or dt_script.Rows(i).Item("consecutivo") = 3) Then
                add_item(dt_script.Rows(i).Item("descripcion_col"), sql_consulta, dt_script.Rows(i).Item("consecutivo"), dt_script.Rows(i).Item("numero"))
            ElseIf (dt_script.Rows(i).Item("consecutivo") = 4 Or dt_script.Rows(i).Item("consecutivo") = 5) Then
                cargar_informes(sql_consulta, dt_script.Rows(i).Item("consecutivo"), dt_script.Rows(i).Item("numero"))
            End If
        Next
        dtg_ventas.DataSource = dt_ventas
        dtg_recaudos.DataSource = dt_recaudos

        dtg_rentabilidad.DataSource = dt_rentabilidad
        totalizarCol(1)
        totalizarCol(2)
        totalizarCol(3)
        totalizarFilas(0, 3, 1)
        totalizarFilas(3, 10, 1)
        totalizarFilas(0, 11, 2)
        totalizarFilas(0, 7, 3)
        calc_porc(10, 11, 1)
        calc_porc(11, 12, 2)

        If (usuario.permiso.Trim <> "VENDEDOR") Then
            calcular_rentabilidad()
            informe_comisiones_ventas()
            comisiones_coordinadores()
            comisiones_director()
            totalizar_comisiones()

            dtg_com_coor_dir.DataSource = Nothing
            dtg_com_coor_dir.DataSource = dt_com_coor_dir

            dtg_ventas.Rows(3).DefaultCellStyle = objOperacionesForm.formatoNegrita(tamano_letra)
            dtg_ventas.Rows(10).DefaultCellStyle = objOperacionesForm.formatoNegrita(tamano_letra)

            dtg_rentabilidad.Rows(0).DefaultCellStyle = objOperacionesForm.formatoNegrita(tamano_letra)
            dtg_rentabilidad.Rows(7).DefaultCellStyle = objOperacionesForm.formatoNegrita(tamano_letra)

            dtg_ventas.Rows(11).DefaultCellStyle.ForeColor = Color.Blue
            dtg_rentabilidad.Rows(8).DefaultCellStyle.ForeColor = Color.Blue

            dtg_ventas.Rows(11).DefaultCellStyle.Format = "N2"
            dtg_rentabilidad.Rows(8).DefaultCellStyle.Format = "N2"

            dtg_com_vtas.Columns("Porc_comisión").DefaultCellStyle.Format = "N2" 'Cumplimiento
            dtg_com_vtas.Columns("Cumplimiento").DefaultCellStyle.Format = "N2"
            dtg_com_vtas.Columns("Ventas").DefaultCellStyle.Format = "N0"
            dtg_com_vtas.Columns("Presupuesto").DefaultCellStyle.Format = "N0"
            dtg_com_vtas.Columns("val_comisión").DefaultCellStyle.Format = "N0"
            dtg_com_coor_dir.Columns("Cumplimiento").DefaultCellStyle.Format = "N2"
            dtg_com_coor_dir.Columns("Cump_regla").DefaultCellStyle.Format = "N2"

            dtg_com_vtas.Rows(dtg_com_vtas.Rows.Count - 1).DefaultCellStyle.BackColor = Color.Red
            dtg_ventas.Columns(2).Frozen = True
            dtg_ventas.Columns(3).Frozen = True
            dtg_rentabilidad.Columns(2).Frozen = True
            dtg_rentabilidad.Columns(3).Frozen = True
        End If






        dtg_recaudos.Rows(0).DefaultCellStyle = objOperacionesForm.formatoNegrita(tamano_letra)
        dtg_recaudos.Rows(11).DefaultCellStyle = objOperacionesForm.formatoNegrita(tamano_letra)


        dtg_recaudos.Rows(12).DefaultCellStyle.ForeColor = Color.Blue


        dtg_recaudos.Rows(12).DefaultCellStyle.Format = "N2"
        dtg_consol_rec.Columns(col_total_rec.Name).DefaultCellStyle.Format = "N0"
        dtg_consol_rec.Columns(col_comision.Name).DefaultCellStyle.Format = "N0"

        dtg_recaudos.Columns(2).Frozen = True
        dtg_recaudos.Columns(3).Frozen = True

        dtg_ventas.Columns("consecutivo").Visible = False
        dtg_ventas.Columns("numero").Visible = False

        dtg_recaudos.Columns("consecutivo").Visible = False
        dtg_recaudos.Columns("numero").Visible = False
        If (usuario.permiso.Trim <> "VENDEDOR") Then
            dtg_rentabilidad.Columns("consecutivo").Visible = False
            dtg_rentabilidad.Columns("numero").Visible = False
        End If
        nomb_vendedores()
    End Sub
    Private Sub nomb_vendedores()
        Dim sql_nomb_vendedores As String = "SELECT CAST(nit AS varchar(25))As nit ,nombres FROM terceros WHERE nit >=1001 and nit <=1099"
        Dim dt_nom_vendedores As DataTable = obj_op_simplesLn.listar_datatable(sql_nomb_vendedores, "CORSAN")
        nomb_vendedores_columna(dtg_ventas, dt_nom_vendedores)
        nomb_vendedores_columna(dtg_recaudos, dt_nom_vendedores)
        nomb_vendedores_columna(dtg_rentabilidad, dt_nom_vendedores)

        nomb_vendedores_fila(dtg_informe_recaudos, dt_nom_vendedores)
        nomb_vendedores_fila(dtg_consol_rec, dt_nom_vendedores)
        nomb_vendedores_fila(dtg_com_vtas, dt_nom_vendedores)
    End Sub
    Private Sub nomb_vendedores_columna(ByVal dtg As DataGridView, ByRef dt_nom_vendedores As DataTable)
        For j = 1 To dtg.Columns.Count - 1
            For k = 0 To dt_nom_vendedores.Rows.Count - 1
                If dtg.Columns(j).Name = dt_nom_vendedores.Rows(k).Item("nit") Then
                    For i = 0 To dtg.Rows.Count - 1
                        dtg.Item(j, i).ToolTipText = dt_nom_vendedores.Rows(k).Item("nombres")
                    Next
                    k = dt_nom_vendedores.Rows.Count - 1
                End If
            Next
        Next
    End Sub
    Private Sub nomb_vendedores_fila(ByVal dtg As DataGridView, ByRef dt_nom_vendedores As DataTable)
        For j = 0 To dtg.Columns.Count - 1
            If dtg.Columns(j).Name = "Vendedor" Or dtg.Columns(j).Name = "vendedor" Or dtg.Columns(j).Name = "col_vendedor" Then
                For i = 0 To dtg.Rows.Count - 2
                    If Not IsDBNull(dtg.Item(j, i).Value) Then
                        For k = 0 To dt_nom_vendedores.Rows.Count - 1
                            If dtg.Item(j, i).Value = dt_nom_vendedores.Rows(k).Item("nit") Then
                                For z = 0 To dtg.Columns.Count - 1
                                    dtg.Item(z, i).ToolTipText = dt_nom_vendedores.Rows(k).Item("nombres")
                                Next
                                k = dt_nom_vendedores.Rows.Count - 1
                            End If
                        Next
                    End If
                Next
                j = dtg.Columns.Count - 1
            End If
        Next
    End Sub
    Private Sub comisiones_coordinadores()
        Dim sql_reglas_coor As String = "SELECT d.id_tipo_cumplimiento,d.porc_cump,d.monto_pagar ,r.usuario " &
                                                 "FROM J_reglas_comisiones_det_coor d , J_reglas_comisiones r  " &
                                                        "WHERE d.numero = r.numero  " &
                                                   "ORDER BY r.usuario,d.porc_cump "
        Dim dt_reglas As New DataTable
        dt_reglas = obj_op_simplesLn.listar_datatable(sql_reglas_coor, "CORSAN")
        Dim sql As String = "SELECT c.grupo As Grupo ,r.usuario As Usuario,d.id_tipo_cumplimiento As Tipo   FROM J_reglas_comisiones_grupo_usuario c ,J_reglas_comisiones_det_coor d, J_reglas_comisiones r " &
                                        "WHERE r.usuario = c.usuario And r.numero = d.numero  " &
                                  "GROUP BY c.grupo ,r.usuario,d.id_tipo_cumplimiento "
        dt_com_coor_dir = New DataTable
        Dim sql_grupos_vend As String = "SELECT  V.grupo , V.vendedor FROM J_reglas_comisiones_grupo_vend V"
        Dim dt_grupos_vend As DataTable = obj_op_simplesLn.listar_datatable(sql_grupos_vend, "CORSAN")
        Dim dt_grupo As New DataTable
        Dim list_grupos As New List(Of DataTable)

        dt_com_coor_dir = obj_op_simplesLn.listar_datatable(sql, "CORSAN")
        dt_com_coor_dir.Columns.Add("Valor", GetType(Double))
        dt_com_coor_dir.Columns.Add("Presupuesto", GetType(Double))
        dt_com_coor_dir.Columns.Add("Cumplimiento", GetType(Double))
        dt_com_coor_dir.Columns.Add("Cump_regla", GetType(Double))
        dt_com_coor_dir.Columns.Add("Monto", GetType(Double))
        dt_com_coor_dir.Columns.Add("Vendedores")


        Dim primero As Boolean = True
        Dim grupo_ant As Integer = 0
        For i = 0 To dt_grupos_vend.Rows.Count - 1
            If (grupo_ant <> dt_grupos_vend.Rows(i).Item("grupo")) Then
                If (primero = False) Then
                    list_grupos.Add(dt_grupo)
                End If
                dt_grupo = New DataTable
                dt_grupo.Columns.Add("grupo")
                dt_grupo.Columns.Add("vendedor")
                grupo_ant = dt_grupos_vend.Rows(i).Item("grupo")
            End If
            primero = False
            dt_grupo.Rows.Add()
            dt_grupo.Rows(dt_grupo.Rows.Count - 1).Item("grupo") = dt_grupos_vend.Rows(i).Item("grupo")
            dt_grupo.Rows(dt_grupo.Rows.Count - 1).Item("vendedor") = dt_grupos_vend.Rows(i).Item("vendedor")
        Next
        list_grupos.Add(dt_grupo)
        Dim sum_vtas As Double = 0
        Dim sum_pres_vtas As Double = 0
        Dim sum_rec As Double = 0
        Dim sum_pres_rec As Double = 0
        Dim vendedores As String = ""
        Dim grupo As Integer = 0
        Dim tipo As String = "Ventas"
        For i = 0 To list_grupos.Count - 1
            dt_grupo = New DataTable
            dt_grupo = list_grupos(i)
            For j = 0 To dt_grupo.Rows.Count - 1
                For k = 0 To dtg_com_vtas.Rows.Count - 1
                    If (dtg_com_vtas.Item("Vendedor", k).Value = dt_grupo.Rows(j).Item("vendedor")) Then
                        If Not IsDBNull(dtg_com_vtas.Item("Ventas", k).Value) Then
                            sum_vtas += dtg_com_vtas.Item("Ventas", k).Value
                        End If
                        If Not IsDBNull(dtg_com_vtas.Item("Presupuesto", k).Value) Then
                            sum_pres_vtas += dtg_com_vtas.Item("Presupuesto", k).Value
                        End If
                        If Not IsDBNull(dtg_com_vtas.Item("Vendedor", k).Value) Then
                            vendedores &= dtg_com_vtas.Item("Vendedor", k).Value & "-"
                        End If
                        If Not IsDBNull(dt_grupo.Rows(j).Item("grupo")) Then
                            grupo = dt_grupo.Rows(j).Item("grupo")
                        End If
                        k = dtg_com_vtas.Rows.Count - 1
                    End If
                Next
                For r = 0 To dtg_recaudos.Columns.Count - 1
                    If (dtg_recaudos.Columns(r).Name = dt_grupo.Rows(j).Item("vendedor").ToString) Then
                        If Not IsDBNull(dtg_recaudos.Item(r, buscarNumFila("descripción", "TOTAL  RECAUDOS  MES", dtg_recaudos)).Value) Then
                            sum_rec += dtg_recaudos.Item(r, buscarNumFila("descripción", "TOTAL  RECAUDOS  MES", dtg_recaudos)).Value
                        End If
                        If Not IsDBNull(dtg_recaudos.Item(r, buscarNumFila("descripción", "PRESUPUESTO", dtg_recaudos)).Value) Then
                            sum_pres_rec += dtg_recaudos.Item(r, buscarNumFila("descripción", "PRESUPUESTO", dtg_recaudos)).Value
                        End If
                        '        vendedores &= dtg_recaudos.Columns(r).Name & "-"
                        r = dtg_recaudos.Columns.Count - 1
                    End If
                Next
            Next
            For k = 0 To dt_com_coor_dir.Rows.Count - 1
                If (dt_com_coor_dir.Rows(k).Item("Grupo") = grupo) Then
                    dt_com_coor_dir.Rows(k).Item("Vendedores") = vendedores
                    If (dt_com_coor_dir.Rows(k).Item("Tipo") = "Ventas") Then
                        dt_com_coor_dir.Rows(k).Item("Valor") = sum_vtas
                        dt_com_coor_dir.Rows(k).Item("Presupuesto") = sum_pres_vtas
                        dt_com_coor_dir.Rows(k).Item("Cumplimiento") = (sum_vtas / sum_pres_vtas) * 100
                    ElseIf (dt_com_coor_dir.Rows(k).Item("Tipo") = "Recaudos") Then
                        dt_com_coor_dir.Rows(k).Item("Valor") = sum_rec
                        dt_com_coor_dir.Rows(k).Item("Presupuesto") = sum_pres_rec
                        dt_com_coor_dir.Rows(k).Item("Cumplimiento") = (sum_rec / sum_pres_rec) * 100
                    Else
                        If ((sum_rec / sum_pres_rec) * 100 >= 95 And (sum_vtas / sum_pres_vtas) * 100 >= 95) Then
                            dt_com_coor_dir.Rows(k).Item("Cumplimiento") = 100
                        End If
                    End If

                End If
            Next
            grupo = 0
            vendedores = ""
            sum_vtas = 0
            sum_pres_vtas = 0
            sum_rec = 0
            sum_pres_rec = 0
        Next
        For j = 0 To dt_reglas.Rows.Count - 1
            For i = 0 To dt_com_coor_dir.Rows.Count - 1
                If (dt_reglas(j).Item("usuario") = dt_com_coor_dir.Rows(i).Item("Usuario")) Then
                    If Not IsDBNull(dt_com_coor_dir.Rows(i).Item("Cumplimiento")) Then
                        If Not IsDBNull(dt_reglas(j).Item("porc_cump")) Then
                            If (dt_com_coor_dir.Rows(i).Item("Cumplimiento") >= dt_reglas(j).Item("porc_cump")) Then
                                dt_com_coor_dir.Rows(i).Item("Monto") = dt_reglas.Rows(j).Item("monto_pagar")
                                dt_com_coor_dir.Rows(i).Item("Cump_regla") = dt_reglas.Rows(j).Item("porc_cump")
                            End If
                        End If
                    End If
                End If
            Next
        Next

    End Sub
    Private Sub comisiones_director()
        Dim sum_vtas As Double = 0
        Dim sum_pres_vtas As Double = 0
        Dim sum_rec As Double = 0
        Dim sum_pres_rec As Double = 0
        Dim sql_dir As String = "SELECT d.id_tipo_cumplimiento,r.usuario  " &
                                              "FROM J_reglas_comisiones_det_dir d , J_reglas_comisiones r  " &
                                                     "WHERE d.numero = r.numero  " &
                                                "	GROUP BY  d.id_tipo_cumplimiento ,r.usuario  "
        Dim dt_dir As New DataTable
        dt_dir = obj_op_simplesLn.listar_datatable(sql_dir, "CORSAN")
        Dim sql_relgas_dir As String = "SELECT d.id_tipo_cumplimiento,d.porc_cump,d.monto_pagar ,r.usuario " &
                                                 "FROM J_reglas_comisiones_det_dir d , J_reglas_comisiones r  " &
                                                        "WHERE d.numero = r.numero  " &
                                                   "ORDER BY r.usuario,d.porc_cump "
        Dim dt_reglas As New DataTable
        dt_reglas = obj_op_simplesLn.listar_datatable(sql_relgas_dir, "CORSAN")
        sum_vtas = dtg_ventas.Item("TOTAL", buscarNumFila("descripción", "TOTAL  VENTAS  MES", dtg_ventas)).Value
        sum_pres_vtas = dtg_ventas.Item("TOTAL", buscarNumFila("descripción", "PRESUPUESTO", dtg_ventas)).Value
        sum_rec = dtg_recaudos.Item("TOTAL", buscarNumFila("descripción", "TOTAL  RECAUDOS  MES", dtg_recaudos)).Value
        sum_pres_rec = dtg_recaudos.Item("TOTAL", buscarNumFila("descripción", "PRESUPUESTO", dtg_recaudos)).Value
        For i = 0 To dt_dir.Rows.Count - 1
            dt_com_coor_dir.Rows.Add()
            dt_com_coor_dir.Rows(dt_com_coor_dir.Rows.Count - 1).Item("Usuario") = dt_dir.Rows(i).Item("usuario")
            dt_com_coor_dir.Rows(dt_com_coor_dir.Rows.Count - 1).Item("Tipo") = dt_dir.Rows(i).Item("id_tipo_cumplimiento")
            dt_com_coor_dir.Rows(dt_com_coor_dir.Rows.Count - 1).Item("Vendedores") = "TODO"
            If (dt_com_coor_dir.Rows(dt_com_coor_dir.Rows.Count - 1).Item("Tipo") = "Ventas") Then
                dt_com_coor_dir.Rows(dt_com_coor_dir.Rows.Count - 1).Item("Valor") = sum_vtas
                dt_com_coor_dir.Rows(dt_com_coor_dir.Rows.Count - 1).Item("Presupuesto") = sum_pres_vtas
                dt_com_coor_dir.Rows(dt_com_coor_dir.Rows.Count - 1).Item("Cumplimiento") = (sum_vtas / sum_pres_vtas) * 100
            Else
                dt_com_coor_dir.Rows(dt_com_coor_dir.Rows.Count - 1).Item("Valor") = sum_rec
                dt_com_coor_dir.Rows(dt_com_coor_dir.Rows.Count - 1).Item("Presupuesto") = sum_pres_rec
                dt_com_coor_dir.Rows(dt_com_coor_dir.Rows.Count - 1).Item("Cumplimiento") = (sum_rec / sum_pres_rec) * 100
            End If
        Next

        For j = 0 To dt_reglas.Rows.Count - 1
            For i = 0 To dt_com_coor_dir.Rows.Count - 1
                If (dt_reglas(j).Item("usuario") = dt_com_coor_dir.Rows(i).Item("Usuario")) Then
                    If (dt_com_coor_dir.Rows(i).Item("Cumplimiento") >= dt_reglas(j).Item("porc_cump")) Then
                        dt_com_coor_dir.Rows(i).Item("Monto") = dt_reglas.Rows(j).Item("monto_pagar")
                        dt_com_coor_dir.Rows(i).Item("Cump_regla") = dt_reglas.Rows(j).Item("porc_cump")
                    End If
                End If
            Next
        Next

    End Sub
    Private Sub totalizar_comisiones()
        dt_com_ventas.Rows.Add()
        dt_com_ventas.Rows(dt_com_ventas.Rows.Count - 1).Item("Vendedor") = "TOTAL"
        Dim sum As Double = 0
        For j = 0 To dt_com_ventas.Columns.Count - 1
            If (dt_com_ventas.Columns(j).ColumnName = "Ventas" Or dt_com_ventas.Columns(j).ColumnName = "Presupuesto" Or dt_com_ventas.Columns(j).ColumnName = "val_comisión" Or dt_com_ventas.Columns(j).ColumnName = "Porc_comisión") Then
                For i = 0 To dt_com_ventas.Rows.Count - 2
                    If Not IsDBNull(dt_com_ventas.Rows(i).Item(j)) Then
                        sum += dt_com_ventas.Rows(i).Item(j)
                    End If
                Next
                dt_com_ventas.Rows(dt_com_ventas.Rows.Count - 1).Item(j) = sum
                sum = 0
            ElseIf (dt_com_ventas.Columns(j).ColumnName = "Cumplimiento") Then
                If (dt_com_ventas.Rows(dt_com_ventas.Rows.Count - 1).Item("Presupuesto") <> 0) Then
                    dt_com_ventas.Rows(dt_com_ventas.Rows.Count - 1).Item(j) = (dt_com_ventas.Rows(dt_com_ventas.Rows.Count - 1).Item("Ventas") / dt_com_ventas.Rows(dt_com_ventas.Rows.Count - 1).Item("Presupuesto")) * 100
                Else
                    dt_com_ventas.Rows(dt_com_ventas.Rows.Count - 1).Item(j) = 0
                End If

            End If

        Next
    End Sub
    Private Sub informe_comisiones_ventas()
        Dim sql_reglas_vtas_vend As String = ""
        Dim dt_reglas_com_vend As New DataTable
        Dim cumplimiento As Double = 0
        Dim sobre_cod_ant As String = ""
        Dim menos_cod_ant As String = ""
        Dim comision_sobre_cod_ant As Double = 0
        Dim comision_menos_cod_ant As Double = 0
        Dim fec_ini As String = obj_op_simplesLn.cambiarFormatoFecha(cbo_fecha_ini.Value)
        Dim fec_fin As String = obj_op_simplesLn.cambiarFormatoFecha(cbo_fecha_fin.Value)
        For i = 0 To dt_com_ventas.Rows.Count - 1
            For j = 2 To dt_ventas.Columns.Count - 1
                If (dt_ventas.Columns(j).ColumnName = dt_com_ventas.Rows(i).Item("Vendedor").ToString) Then
                    dt_com_ventas.Rows(i).Item("Ventas") = dt_ventas.Rows(dt_ventas.Rows.Count - 3).Item(j)
                    j = dt_ventas.Columns.Count - 1
                End If
            Next
            If Not IsDBNull(dt_com_ventas.Rows(i).Item("Presupuesto")) And Not IsDBNull(dt_com_ventas.Rows(i).Item("Ventas")) Then
                cumplimiento = (dt_com_ventas.Rows(i).Item("Ventas") / dt_com_ventas.Rows(i).Item("Presupuesto") * 100)
                dt_com_ventas.Rows(i).Item("Cumplimiento") = cumplimiento
                sql_reglas_vtas_vend = "SELECT d.porc_cump ,d.porc_pagar,d.sobre_codigo ,d.menos_codigo,d.todo " &
                                          "FROM J_reglas_comisiones_det_vtas d , J_reglas_comisiones r " &
                                              "WHERE r.numero = d.numero AND r.anulado is null AND r.usuario = '" & dt_com_ventas.Rows(i).Item("vendedor") & "' " &
                                                  "ORDER BY d.porc_pagar "
                dt_reglas_com_vend = obj_op_simplesLn.listar_datatable(sql_reglas_vtas_vend, "CORSAN")
                sobre_cod_ant = ""
                menos_cod_ant = ""
                comision_sobre_cod_ant = 0
                comision_menos_cod_ant = 0
                For j = 0 To dt_reglas_com_vend.Rows.Count - 1
                    If (cumplimiento >= dt_reglas_com_vend.Rows(j).Item("porc_cump")) Then
                        If (dt_reglas_com_vend.Rows(j).Item("todo") = "S") Then
                            dt_com_ventas.Rows(i).Item("Porc_comisión") = dt_reglas_com_vend.Rows(j).Item("porc_pagar")
                            dt_com_ventas.Rows(i).Item("val_comisión") = dt_com_ventas.Rows(i).Item("Ventas") * (dt_reglas_com_vend.Rows(j).Item("porc_pagar") / 100)
                        Else
                            If Not IsDBNull(dt_reglas_com_vend.Rows(j).Item("sobre_codigo")) Then
                                If (dt_reglas_com_vend.Rows(j).Item("sobre_codigo") <> "") Then
                                    Dim sql As String = "SELECT  SUM(Vr_total)As total  FROM J_congelado_ventas WHERE vendedor = " & dt_com_ventas.Rows(i).Item("Vendedor") & " AND fec>='" & fec_ini & "' AND fec<='" & fec_fin & "'   AND codigo like '" & dt_reglas_com_vend.Rows(j).Item("sobre_codigo") & "%' "
                                    Dim val As String = obj_op_simplesLn.consultarVal(sql)
                                    If (sobre_cod_ant = dt_reglas_com_vend.Rows(j).Item("sobre_codigo")) Then
                                        comision_sobre_cod_ant = 0
                                    End If
                                    If (val <> "") Then
                                        If Not IsDBNull(dt_com_ventas.Rows(i).Item("val_comisión")) Then
                                            If (dt_com_ventas.Rows(i).Item("val_comisión").ToString <> "") Then
                                                comision_sobre_cod_ant = val * (dt_reglas_com_vend.Rows(j).Item("porc_pagar") / 100)
                                            Else
                                                comision_sobre_cod_ant = val * (dt_reglas_com_vend.Rows(j).Item("porc_pagar") / 100)
                                            End If
                                        Else
                                            comision_sobre_cod_ant = val * (dt_reglas_com_vend.Rows(j).Item("porc_pagar") / 100)
                                        End If
                                    End If
                                    sobre_cod_ant = dt_reglas_com_vend.Rows(j).Item("sobre_codigo")
                                ElseIf Not IsDBNull(dt_reglas_com_vend.Rows(j).Item("menos_codigo")) Then
                                    If (dt_reglas_com_vend.Rows(j).Item("menos_codigo") <> "") Then
                                        Dim sql As String = "SELECT  SUM(Vr_total)As total  FROM J_congelado_ventas WHERE vendedor = " & dt_com_ventas.Rows(i).Item("Vendedor") & " AND fec>='" & fec_ini & "' and fec < ='" & fec_fin & "'   AND codigo not like '" & dt_reglas_com_vend.Rows(j).Item("menos_codigo") & "%' "
                                        Dim val As String = obj_op_simplesLn.consultarVal(sql)
                                        If (menos_cod_ant = dt_reglas_com_vend.Rows(j).Item("menos_codigo")) Then
                                            comision_menos_cod_ant = 0
                                        End If
                                        If Not IsDBNull(dt_com_ventas.Rows(i).Item("val_comisión")) Then
                                            If (dt_com_ventas.Rows(i).Item("val_comisión").ToString <> "") Then
                                                comision_menos_cod_ant = val * (dt_reglas_com_vend.Rows(j).Item("porc_pagar") / 100)
                                            Else
                                                comision_menos_cod_ant = val * (dt_reglas_com_vend.Rows(j).Item("porc_pagar") / 100)
                                            End If
                                        Else
                                            comision_menos_cod_ant = val * (dt_reglas_com_vend.Rows(j).Item("porc_pagar") / 100)
                                        End If
                                        menos_cod_ant = dt_reglas_com_vend.Rows(j).Item("menos_codigo")

                                    End If
                                End If
                            ElseIf Not IsDBNull(dt_reglas_com_vend.Rows(j).Item("menos_codigo")) Then
                                If (dt_reglas_com_vend.Rows(j).Item("menos_codigo") <> "") Then
                                    Dim sql As String = "SELECT  SUM(Vr_total)As total  FROM J_congelado_pendientes WHERE vendedor = " & dt_com_ventas.Rows(i).Item("Vendedor") & " AND fec>='" & fec_ini & "' AND fec<='" & fec_fin & "'   AND codigo not like '" & dt_reglas_com_vend.Rows(j).Item("menos_codigo") & "%' "
                                    Dim val As String = obj_op_simplesLn.consultarVal(sql)
                                    If (menos_cod_ant = dt_reglas_com_vend.Rows(j).Item("menos_codigo")) Then
                                        comision_menos_cod_ant = 0
                                    End If
                                    If Not IsDBNull(dt_com_ventas.Rows(i).Item("val_comisión")) Then
                                        If (dt_com_ventas.Rows(i).Item("val_comisión").ToString <> "") Then
                                            comision_menos_cod_ant = val * (dt_reglas_com_vend.Rows(j).Item("porc_pagar") / 100)
                                        Else
                                            comision_menos_cod_ant = val * (dt_reglas_com_vend.Rows(j).Item("porc_pagar") / 100)
                                        End If
                                    Else
                                        comision_menos_cod_ant = val * (dt_reglas_com_vend.Rows(j).Item("porc_pagar") / 100)
                                    End If
                                    menos_cod_ant = dt_reglas_com_vend.Rows(j).Item("menos_codigo")
                                End If
                            End If
                        End If

                    End If
                Next
                If (comision_menos_cod_ant <> 0 Or comision_sobre_cod_ant <> 0) Then
                    dt_com_ventas.Rows(i).Item("val_comisión") = comision_menos_cod_ant + comision_sobre_cod_ant
                End If
                If IsDBNull(dt_com_ventas.Rows(i).Item("val_comisión")) Then
                    dt_com_ventas.Rows(i).Item("val_comisión") = 0
                    dt_com_ventas.Rows(i).Item("Porc_comisión") = 0
                ElseIf (dt_com_ventas.Rows(i).Item("val_comisión").ToString = "") Then
                    dt_com_ventas.Rows(i).Item("val_comisión") = 0
                    dt_com_ventas.Rows(i).Item("Porc_comisión") = 0
                End If
            End If
        Next
        dtg_com_vtas.DataSource = dt_com_ventas
    End Sub
    Private Sub Informe_comisiones_recaudos()

        Dim dt As New DataTable
        dt.Columns.Add("Vendedor")
        dt.Columns.Add("Ppto_recaudos", GetType(Date))
        dt.Columns.Add("Recaudo_total", GetType(Date))
        dt.Columns.Add("Cumpl_rec", GetType(Date))
        dt.Columns.Add("vendedor", GetType(Date))
        dt.Columns.Add("porc_pagar", GetType(Date))
        dt.Columns.Add("Total_recaudos", GetType(Date))
        dt.Columns.Add("Comisión", GetType(Date))

    End Sub
    Private Sub cargar_informes(ByVal sql As String, ByVal consecitivo As Integer, ByVal numero As Integer)
        Dim dt As DataTable = obj_op_simplesLn.listar_datatable(sql, "CORSAN")
        Dim fec_ini As String = obj_op_simplesLn.cambiarFormatoFecha(cbo_fecha_ini.Value)
        Dim fec_fin As String = obj_op_simplesLn.cambiarFormatoFecha(cbo_fecha_fin.Value)
        Select Case consecitivo
            Case 4
                Dim dt_ndch_venc As DataTable = obj_op_simplesLn.listar_datatable("SELECT tipo,numero,vencimiento,valor FROM J_comisiones_ndch_por_factura WHERE fecha>='" & fec_ini & "' AND fecha <= '" & fec_fin & "'", "CORSAN")
                Dim a As String = ""
                Dim criterio_vend As String = ""
                Dim view As New DataView
                Dim vendedor_ant As String = ""
                Dim sql_reglas_com_vend As String = ""
                Dim sql_reglas_com_gral As String = "SELECT regla, dias_venc_min, dias_venc_max " &
                                                                "FROM dbo.J_reglas_tipo_cumplimiento " &
                                                                    "WHERE regla not like 'vent%'"
                Dim ndch_partida As Boolean = False
                Dim dt_reglas_com_gral As DataTable = obj_op_simplesLn.listar_datatable(sql_reglas_com_gral, "CORSAN")
                Dim dt_reglas_com_vend As New DataTable


                Dim dias_vencido As Integer
                dt.Columns.Add("consecutivo")
                dt.Columns.Add("num_script")
                dt.Columns.Add("Descripción")
                'dt.Columns.Add("Vencimiento", GetType(Date))
                dt.Columns.Add("D_vencido", GetType(Double))
                dt.Columns.Add("Porc_comisión", GetType(Double))
                dt.Columns.Add("Val_comisión", GetType(Double))
                dt.Columns.Add("Regla", GetType(String))
                For i = 0 To dt.Rows.Count - 1
                    dt.Rows(i).Item("Descripción") = "Recaudo general"
                    dt.Rows(i).Item("consecutivo") = consecitivo
                    dt.Rows(i).Item("num_script") = numero
                    If (i = 0 Or vendedor_ant <> dt.Rows(i).Item("vendedor").ToString) Then
                        vendedor_ant = dt.Rows(i).Item("vendedor")
                        sql_reglas_com_vend = "SELECT t.regla ,t.dias_venc_min,t.dias_venc_max ,d.porc_pagar " &
                                                    "FROM J_reglas_comisiones_det_recaudos d, J_reglas_comisiones r , J_reglas_tipo_cumplimiento t " &
                                                        "WHERE r.numero = d.numero AND t.id = d.id_tipo_cumpl AND r.anulado is null AND r.usuario = '" & dt.Rows(i).Item("vendedor") & "' " &
                                                            "ORDER BY d.porc_pagar "
                        dt_reglas_com_vend = New DataTable
                        dt_reglas_com_vend = obj_op_simplesLn.listar_datatable(sql_reglas_com_vend, "CORSAN")
                    End If
                    a = dt.Rows(i).Item("numero")
                    If a = 130763 Then
                        a = 0
                    End If
                    ' fec_fact = Convert.ToDateTime(dt.Rows(i).Item("fecha_aplica"))
                    'fecha_aplicacion = Convert.ToDateTime(dt.Rows(i).Item("fecha"))
                    'fecha_venc = fec_fact.AddDays(dt.Rows(i).Item("dias_condicion"))
                    'dt.Rows(i).Item("Vencimiento") = fecha_venc
                    dias_vencido = DateDiff(DateInterval.Day, dt.Rows(i).Item("vencimiento"), dt.Rows(i).Item("fecha"))
                    dt.Rows(i).Item("D_vencido") = dias_vencido
                    For j = 0 To dt_reglas_com_vend.Rows.Count - 1
                        If (dias_vencido < 0) Then
                            dias_vencido = 0
                        End If
                        If (dias_vencido >= dt_reglas_com_vend.Rows(j).Item("dias_venc_min") And dias_vencido <= dt_reglas_com_vend.Rows(j).Item("dias_venc_max")) Then
                            dt.Rows(i).Item("Porc_comisión") = dt_reglas_com_vend.Rows(j).Item("porc_pagar")
                            dt.Rows(i).Item("val_comisión") = dt.Rows(i).Item("Total_rec") * (dt_reglas_com_vend.Rows(j).Item("porc_pagar") / 100)
                            dt.Rows(i).Item("Regla") = dt_reglas_com_vend.Rows(j).Item("regla")
                        End If
                    Next
                    If (dt.Rows(i).Item("Porc_comisión").ToString = "") Then
                        For j = 0 To dt_reglas_com_gral.Rows.Count - 1
                            If (dias_vencido < 0) Then
                                dias_vencido = 0
                            End If
                            If (dias_vencido >= dt_reglas_com_gral.Rows(j).Item("dias_venc_min") And dias_vencido <= dt_reglas_com_gral.Rows(j).Item("dias_venc_max")) Then
                                dt.Rows(i).Item("Porc_comisión") = 0
                                dt.Rows(i).Item("val_comisión") = 0
                                dt.Rows(i).Item("Regla") = dt_reglas_com_gral.Rows(j).Item("regla")
                            End If
                        Next
                    End If
                Next
                vendedor_ant = 0
                Dim dt_tipo_doc As New DataTable
                Dim sql_script_tipos_documentos As String = "SELECT descripcion_col,script,consecutivo,numero FROM  J_script_modulos_prueba WHERE desc_modulo ='" & nomb_modulo & "' AND consecutivo = 6"
                Dim dt_script As DataTable = obj_op_simplesLn.listar_datatable(sql_script_tipos_documentos, "CORSAN")
                Dim sql_consulta As String
                cbo_tipo_clasificación.Items.Clear()
                cbo_tipo_clasificación.Items.Add("TODO")
                cbo_tipo_clasificación.Items.Add("Recaudo general")
                For k = 0 To dt_script.Rows.Count - 1
                    sql_consulta = modificarSql(dt_script.Rows(k).Item("script"))
                    dt_tipo_doc = obj_op_simplesLn.listar_datatable(sql_consulta, "CORSAN")
                    cbo_tipo_clasificación.Items.Add(dt_script.Rows(k).Item("descripcion_col"))
                    For i = 0 To dt_tipo_doc.Rows.Count - 1

                        If (dt_tipo_doc.Rows(i).Item("tipo") = "NDCH") Then
                            If (dt_tipo_doc.Rows(i).Item("tipo") = "NDCH") Then
                                For z = 0 To dt_ndch_venc.Rows.Count - 1
                                    If (dt_ndch_venc.Rows(z).Item("numero") = dt_tipo_doc.Rows(i).Item("numero")) Then
                                        ndch_partida = True
                                    End If
                                Next
                            End If
                        End If
                        If (dt_tipo_doc.Rows(i).Item("tipo") = "NDCH") Then
                            If (ndch_partida) Then
                                For z = 0 To dt_ndch_venc.Rows.Count - 1
                                    If (dt_ndch_venc.Rows(z).Item("numero") = dt_tipo_doc.Rows(i).Item("numero")) Then
                                        dt.Rows.Add()
                                        dt.Rows(dt.Rows.Count - 1).Item("num_script") = dt_script.Rows(k).Item("numero")
                                        dt.Rows(dt.Rows.Count - 1).Item("consecutivo") = dt_script.Rows(k).Item("consecutivo")
                                        dt.Rows(dt.Rows.Count - 1).Item("Vencimiento") = dt_ndch_venc.Rows(z).Item("vencimiento")
                                        dias_vencido = DateDiff(DateInterval.Day, dt_ndch_venc.Rows(z).Item("vencimiento"), dt_tipo_doc.Rows(i).Item("fecha"))
                                        dt.Rows(dt.Rows.Count - 1).Item("Total_rec") = dt_ndch_venc.Rows(z).Item("valor")

                                        dt.Rows(dt.Rows.Count - 1).Item("tipo") = dt_tipo_doc.Rows(i).Item("tipo")
                                        dt.Rows(dt.Rows.Count - 1).Item("numero") = dt_tipo_doc.Rows(i).Item("numero")
                                        dt.Rows(dt.Rows.Count - 1).Item("vendedor") = dt_tipo_doc.Rows(i).Item("vendedor")
                                        dt.Rows(dt.Rows.Count - 1).Item("fecha") = dt_tipo_doc.Rows(i).Item("fecha")
                                        dt.Rows(dt.Rows.Count - 1).Item("Descripción") = dt_script.Rows(k).Item("descripcion_col")
                                        dt.Rows(dt.Rows.Count - 1).Item("D_vencido") = dias_vencido
                                        If (i = 0 Or vendedor_ant <> dt.Rows(dt.Rows.Count - 1).Item("vendedor").ToString) Then
                                            vendedor_ant = dt.Rows(dt.Rows.Count - 1).Item("vendedor")
                                            sql_reglas_com_vend = "SELECT t.regla ,t.dias_venc_min,t.dias_venc_max ,d.porc_pagar " &
                                                                        "FROM J_reglas_comisiones_det_recaudos d, J_reglas_comisiones r , J_reglas_tipo_cumplimiento t " &
                                                                            "WHERE r.numero = d.numero AND t.id = d.id_tipo_cumpl AND r.anulado is null AND r.usuario = '" & dt.Rows(dt.Rows.Count - 1).Item("vendedor") & "' " &
                                                                                "ORDER BY d.porc_pagar "
                                            dt_reglas_com_vend = New DataTable
                                            dt_reglas_com_vend = obj_op_simplesLn.listar_datatable(sql_reglas_com_vend, "CORSAN")
                                        End If
                                        For j = 0 To dt_reglas_com_vend.Rows.Count - 1
                                            If (dias_vencido >= dt_reglas_com_vend.Rows(j).Item("dias_venc_min") And dias_vencido <= dt_reglas_com_vend.Rows(j).Item("dias_venc_max")) Then
                                                dt.Rows(dt.Rows.Count - 1).Item("Porc_comisión") = dt_reglas_com_vend.Rows(j).Item("porc_pagar")
                                                dt.Rows(dt.Rows.Count - 1).Item("val_comisión") = dt.Rows(dt.Rows.Count - 1).Item("Total_rec") * (dt_reglas_com_vend.Rows(j).Item("porc_pagar") / 100)
                                                dt.Rows(dt.Rows.Count - 1).Item("Regla") = dt_reglas_com_vend.Rows(j).Item("regla")
                                            End If
                                        Next
                                        If (dt.Rows(dt.Rows.Count - 1).Item("Porc_comisión").ToString = "") Then
                                            For j = 0 To dt_reglas_com_gral.Rows.Count - 1
                                                If (dias_vencido < 0) Then
                                                    dias_vencido = 0
                                                End If
                                                If (dias_vencido >= dt_reglas_com_gral.Rows(j).Item("dias_venc_min") And dias_vencido <= dt_reglas_com_gral.Rows(j).Item("dias_venc_max")) Then
                                                    dt.Rows(dt.Rows.Count - 1).Item("Porc_comisión") = 0
                                                    dt.Rows(dt.Rows.Count - 1).Item("val_comisión") = 0
                                                    dt.Rows(dt.Rows.Count - 1).Item("Regla") = dt_reglas_com_gral.Rows(j).Item("regla")
                                                End If
                                            Next
                                        End If
                                    End If
                                Next
                            End If
                        End If

                        If Not ndch_partida Then
                            dt.Rows.Add()
                            dias_vencido = 0
                            dt.Rows(dt.Rows.Count - 1).Item("num_script") = dt_script.Rows(k).Item("numero")
                            dt.Rows(dt.Rows.Count - 1).Item("consecutivo") = dt_script.Rows(k).Item("consecutivo")
                            dt.Rows(dt.Rows.Count - 1).Item("Descripción") = dt_script.Rows(k).Item("descripcion_col")
                            dt.Rows(dt.Rows.Count - 1).Item("D_vencido") = dias_vencido
                            dt.Rows(dt.Rows.Count - 1).Item("tipo") = dt_tipo_doc.Rows(i).Item("tipo")
                            dt.Rows(dt.Rows.Count - 1).Item("numero") = dt_tipo_doc.Rows(i).Item("numero")
                            dt.Rows(dt.Rows.Count - 1).Item("vendedor") = dt_tipo_doc.Rows(i).Item("vendedor")
                            dt.Rows(dt.Rows.Count - 1).Item("fecha") = dt_tipo_doc.Rows(i).Item("fecha")
                            dt.Rows(dt.Rows.Count - 1).Item("Total_rec") = dt_tipo_doc.Rows(i).Item("valor_total")
                        End If


                        If (i = 0 Or vendedor_ant <> dt.Rows(dt.Rows.Count - 1).Item("vendedor").ToString) Then
                            vendedor_ant = dt.Rows(dt.Rows.Count - 1).Item("vendedor")
                            sql_reglas_com_vend = "SELECT t.regla ,t.dias_venc_min,t.dias_venc_max ,d.porc_pagar " &
                                                        "FROM J_reglas_comisiones_det_recaudos d, J_reglas_comisiones r , J_reglas_tipo_cumplimiento t " &
                                                            "WHERE r.numero = d.numero AND t.id = d.id_tipo_cumpl AND r.anulado is null AND r.usuario = '" & dt.Rows(dt.Rows.Count - 1).Item("vendedor") & "' " &
                                                                "ORDER BY d.porc_pagar "
                            dt_reglas_com_vend = New DataTable
                            dt_reglas_com_vend = obj_op_simplesLn.listar_datatable(sql_reglas_com_vend, "CORSAN")
                        End If
                        For j = 0 To dt_reglas_com_vend.Rows.Count - 1
                            If (dias_vencido >= dt_reglas_com_vend.Rows(j).Item("dias_venc_min") And dias_vencido <= dt_reglas_com_vend.Rows(j).Item("dias_venc_max")) Then
                                dt.Rows(dt.Rows.Count - 1).Item("Porc_comisión") = dt_reglas_com_vend.Rows(j).Item("porc_pagar")
                                dt.Rows(dt.Rows.Count - 1).Item("val_comisión") = dt.Rows(dt.Rows.Count - 1).Item("Total_rec") * (dt_reglas_com_vend.Rows(j).Item("porc_pagar") / 100)
                                dt.Rows(dt.Rows.Count - 1).Item("Regla") = dt_reglas_com_vend.Rows(j).Item("regla")
                            End If
                        Next
                        If (dt.Rows(dt.Rows.Count - 1).Item("Porc_comisión").ToString = "") Then
                            For j = 0 To dt_reglas_com_gral.Rows.Count - 1
                                If (dias_vencido < 0) Then
                                    dias_vencido = 0
                                End If
                                If (dias_vencido >= dt_reglas_com_gral.Rows(j).Item("dias_venc_min") And dias_vencido <= dt_reglas_com_gral.Rows(j).Item("dias_venc_max")) Then
                                    dt.Rows(dt.Rows.Count - 1).Item("Porc_comisión") = 0
                                    dt.Rows(dt.Rows.Count - 1).Item("val_comisión") = 0
                                    dt.Rows(dt.Rows.Count - 1).Item("Regla") = dt_reglas_com_gral.Rows(j).Item("regla")
                                End If
                            Next
                        End If
                        ndch_partida = False
                    Next
                    dt_tipo_doc = New DataTable
                Next
                cbo_tipo_clasificación.SelectedItem = "TODO"
                dt.Rows.Add()
                dt.Rows(dt.Rows.Count - 1).Item("tipo") = "TOTAL"
                dt.Rows(dt.Rows.Count - 1).Item("vendedor") = "TODOS"
                BindingSource1.DataSource = dt
                view = New DataView(dt)
                view.Sort = "vendedor,Regla"
                dtg_informe_recaudos.DataSource = view
                dtg_informe_recaudos.Columns("num_script").Visible = False
                dtg_informe_recaudos.Columns("consecutivo").Visible = False
                totalizarDtgInfoRec()
                dtg_informe_recaudos.Columns("Vencimiento").DefaultCellStyle.Format = "d"
                dtg_informe_recaudos.Columns("fecha").DefaultCellStyle.Format = "d"
                '  dtg_informe_recaudos.Columns("fecha_aplica").DefaultCellStyle.Format = "d"
                dtg_informe_recaudos.Columns("Porc_comisión").DefaultCellStyle.Format = "N2"
                For i = 0 To dtg_informe_recaudos.Rows.Count - 1
                    If IsDBNull(dtg_informe_recaudos.Item("tipo_aplica", i).Value) Then
                        dtg_informe_recaudos.Rows(i).DefaultCellStyle.BackColor = Color.Red
                    End If
                Next
                consilidar_recaudos()
                sumarConsolRec()
            Case 5
                dt_com_ventas = New DataTable
                dt_com_ventas.Columns.Add("Vendedor")
                dt_com_ventas.Columns.Add("Ventas", GetType(Double))
                dt_com_ventas.Columns.Add("Presupuesto", GetType(Double))
                dt_com_ventas.Columns.Add("Cumplimiento", GetType(Double))
                dt_com_ventas.Columns.Add("Porc_comisión", GetType(Double))
                dt_com_ventas.Columns.Add("val_comisión", GetType(Double))
                Dim sql_vendedores As String = " SELECT vendedor FROM J_congelado_ventas  WHERE fec>='" & fec_ini & "' AND fec <='" & fec_fin & "' GROUP BY vendedor "
                Dim dt_vendedores As New DataTable
                dt_vendedores = obj_op_simplesLn.listar_datatable(sql_vendedores, "CORSAN")
                For i = 0 To dt_vendedores.Rows.Count - 1
                    dt_com_ventas.Rows.Add()
                    dt_com_ventas.Rows(dt_com_ventas.Rows.Count - 1).Item("Vendedor") = dt_vendedores.Rows(i).Item("vendedor")
                    For j = 0 To dt.Rows.Count - 1
                        If (dt_vendedores.Rows(i).Item("vendedor") = dt.Rows(j).Item("vendedor")) Then
                            dt_com_ventas.Rows(dt_com_ventas.Rows.Count - 1).Item("Presupuesto") = dt.Rows(j).Item("total")
                            j = dt.Rows.Count - 1
                        End If
                    Next
                Next

        End Select
    End Sub
    Private Sub consilidar_recaudos()
        dtg_consol_rec.Rows.Clear()
        Dim vend_ant As String = ""
        Dim sum_rec As Double = 0
        Dim sum_valor_com As Double = 0
        Dim regla_ant As String = ""
        Dim porc_ant As String = ""
        Dim primero As Boolean = True
        For i = 0 To dtg_informe_recaudos.RowCount - 1
            If Not IsDBNull(dtg_informe_recaudos.Item("tipo", i).Value) Then
                If (dtg_informe_recaudos.Item("tipo", i).Value <> "TOTAL") Then
                    'If (dtg_informe_recaudos.Item("Regla", i).Value = "Recaudos mas de 120 días" And dtg_informe_recaudos.Item("vendedor", i).Value = 1024) Then
                    '    dtg_informe_recaudos.Item("Regla", i).Value = ""
                    'End If
                    If (primero) Then
                        primero = False
                        vend_ant = dtg_informe_recaudos.Item("vendedor", i).Value
                        regla_ant = dtg_informe_recaudos.Item("Regla", i).Value
                        porc_ant = dtg_informe_recaudos.Item("Porc_comisión", i).Value / 100
                    End If
                    If (vend_ant <> dtg_informe_recaudos.Item("vendedor", i).Value.ToString) Then
                        dtg_consol_rec.Rows.Add()
                        dtg_consol_rec.Item("col_vendedor", dtg_consol_rec.Rows.Count - 1).Value = vend_ant
                        dtg_consol_rec.Item("col_regla", dtg_consol_rec.Rows.Count - 1).Value = regla_ant
                        dtg_consol_rec.Item("Porc_regla", dtg_consol_rec.Rows.Count - 1).Value = porc_ant * 100
                        dtg_consol_rec.Item("col_comision", dtg_consol_rec.Rows.Count - 1).Value = sum_valor_com
                        dtg_consol_rec.Item("col_total_rec", dtg_consol_rec.Rows.Count - 1).Value = sum_rec
                        dtg_consol_rec.Rows.Add()
                        dtg_consol_rec.Item("col_regla", dtg_consol_rec.Rows.Count - 1).Value = "TOTAL"
                        dtg_consol_rec.Rows(dtg_consol_rec.Rows.Count - 1).DefaultCellStyle.BackColor = Color.Red
                        sum_rec = 0
                        sum_valor_com = 0
                        vend_ant = dtg_informe_recaudos.Item("vendedor", i).Value
                        regla_ant = dtg_informe_recaudos.Item("regla", i).Value
                        porc_ant = dtg_informe_recaudos.Item("Porc_comisión", i).Value / 100
                    ElseIf (vend_ant = dtg_informe_recaudos.Item("vendedor", i).Value) Then
                        If (dtg_informe_recaudos.Item("Regla", i).Value <> regla_ant) Then
                            dtg_consol_rec.Rows.Add()
                            dtg_consol_rec.Item("col_vendedor", dtg_consol_rec.Rows.Count - 1).Value = vend_ant
                            dtg_consol_rec.Item("col_regla", dtg_consol_rec.Rows.Count - 1).Value = regla_ant
                            dtg_consol_rec.Item("Porc_regla", dtg_consol_rec.Rows.Count - 1).Value = porc_ant * 100
                            dtg_consol_rec.Item("col_comision", dtg_consol_rec.Rows.Count - 1).Value = sum_valor_com
                            dtg_consol_rec.Item("col_total_rec", dtg_consol_rec.Rows.Count - 1).Value = sum_rec
                            regla_ant = dtg_informe_recaudos.Item("regla", i).Value
                            porc_ant = dtg_informe_recaudos.Item("Porc_comisión", i).Value / 100
                            sum_rec = 0
                            sum_valor_com = 0
                        End If
                    End If
                    sum_rec += dtg_informe_recaudos.Item("Total_rec", i).Value
                    sum_valor_com += dtg_informe_recaudos.Item("Val_comisión", i).Value
                    If (i = dtg_informe_recaudos.RowCount - 2) Then
                        dtg_consol_rec.Rows.Add()
                        dtg_consol_rec.Item("col_vendedor", dtg_consol_rec.Rows.Count - 1).Value = vend_ant
                        dtg_consol_rec.Item("col_regla", dtg_consol_rec.Rows.Count - 1).Value = regla_ant
                        dtg_consol_rec.Item("Porc_regla", dtg_consol_rec.Rows.Count - 1).Value = porc_ant * 100
                        dtg_consol_rec.Item("col_comision", dtg_consol_rec.Rows.Count - 1).Value = sum_valor_com
                        dtg_consol_rec.Item("col_total_rec", dtg_consol_rec.Rows.Count - 1).Value = sum_rec
                        regla_ant = dtg_informe_recaudos.Item("Regla", i).Value
                        porc_ant = dtg_informe_recaudos.Item("Porc_comisión", i).Value
                        dtg_consol_rec.Rows.Add()
                        dtg_consol_rec.Item("col_regla", dtg_consol_rec.Rows.Count - 1).Value = "TOTAL"
                        dtg_consol_rec.Rows(dtg_consol_rec.Rows.Count - 1).DefaultCellStyle.BackColor = Color.Red
                    End If
                End If
            End If
        Next
    End Sub
    Private Sub add_item(ByVal descripcion As String, ByVal sql As String, ByVal consecitivo As Integer, ByVal numero As Integer)
        Dim num_row As Integer = 0
        Select Case consecitivo
            Case 1
                dt_ventas.Rows.Add()
                num_row = dt_ventas.Rows.Count - 1
                dt_ventas.Rows(num_row).Item("descripción") = descripcion
                dt_ventas.Rows(num_row).Item("consecutivo") = consecitivo
                dt_ventas.Rows(num_row).Item("numero") = numero
            Case 2
                dt_recaudos.Rows.Add()
                num_row = dt_recaudos.Rows.Count - 1
                dt_recaudos.Rows(num_row).Item("descripción") = descripcion
                dt_recaudos.Rows(num_row).Item("consecutivo") = consecitivo
                dt_recaudos.Rows(num_row).Item("numero") = numero
            Case 3
                dt_rentabilidad.Rows.Add()
                num_row = dt_rentabilidad.Rows.Count - 1
                dt_rentabilidad.Rows(num_row).Item("descripción") = descripcion
                dt_rentabilidad.Rows(num_row).Item("consecutivo") = consecitivo
                dt_rentabilidad.Rows(num_row).Item("numero") = numero
        End Select
        If (sql <> "") Then
            Dim dt As DataTable = obj_op_simplesLn.listar_datatable(sql, "CORSAN")
            For i = 0 To dt.Rows.Count - 1
                Select Case consecitivo
                    Case 1

                        For j = 0 To dt_ventas.Columns.Count - 1
                            If (dt_ventas.Columns(j).ColumnName = dt.Rows(i).Item("vendedor").ToString) Then
                                dt_ventas.Rows(num_row).Item(j) = dt.Rows(i).Item("total")
                            End If
                        Next
                    Case 2

                        For j = 0 To dt_recaudos.Columns.Count - 1
                            If (dt_recaudos.Columns(j).ColumnName = dt.Rows(i).Item("vendedor").ToString) Then
                                dt_recaudos.Rows(num_row).Item(j) = dt.Rows(i).Item("total")
                            End If
                        Next
                    Case 3
                        For j = 0 To dt_rentabilidad.Columns.Count - 1
                            If (dt_rentabilidad.Columns(j).ColumnName = dt.Rows(i).Item("vendedor").ToString) Then
                                dt_rentabilidad.Rows(num_row).Item(j) = dt.Rows(i).Item("total")
                            End If
                        Next
                End Select

            Next
        End If

    End Sub
    Private Sub armar_dtg()
        Dim fec_ini As String = obj_op_simplesLn.cambiarFormatoFecha(cbo_fecha_ini.Value)
        Dim fec_fin As String = obj_op_simplesLn.cambiarFormatoFecha(cbo_fecha_fin.Value)
        Dim sql_vend_vtas As String = "SELECT vendedor FROM  J_congelado_ventas WHERE fec >='" & fec_ini & "' and fec <='" & fec_fin & "'"
        Dim sql_vend_rec As String = "SELECT vendedor FROM  documentos WHERE fecha >='" & fec_ini & "' and fecha <='" & fec_fin & "' "
        Dim dt_vend_vtas As New DataTable
        Dim dt_vend_rec As New DataTable
        Dim col As New DataGridViewColumn
        dt_ventas.Columns.Add("numero", GetType(String))
        dt_ventas.Columns.Add("consecutivo", GetType(String))
        dt_recaudos.Columns.Add("numero", GetType(String))
        dt_recaudos.Columns.Add("consecutivo", GetType(String))
        dt_rentabilidad.Columns.Add("numero", GetType(String))
        dt_rentabilidad.Columns.Add("consecutivo", GetType(String))

        dt_ventas.Columns.Add("descripción", GetType(String))
        dt_ventas.Columns.Add("TOTAL", GetType(Double))
        dt_recaudos.Columns.Add("descripción", GetType(String))
        dt_recaudos.Columns.Add("TOTAL", GetType(Double))
        dt_rentabilidad.Columns.Add("descripción", GetType(String))
        dt_rentabilidad.Columns.Add("TOTAL", GetType(Double))
        If (cbo_vend.Text = "TODOS") Then
            sql_vend_vtas &= " AND vendedor >=1001 AND vendedor <= 1099 "
            sql_vend_rec &= " AND vendedor >=1001 AND vendedor <= 1099 "
        Else
            sql_vend_vtas &= " AND vendedor =" & cbo_vend.SelectedValue
            sql_vend_rec &= " AND vendedor =" & cbo_vend.SelectedValue
        End If
        sql_vend_vtas &= " GROUP BY vendedor"
        sql_vend_rec &= " GROUP BY vendedor"
        dt_vend_vtas = obj_op_simplesLn.listar_datatable(sql_vend_vtas, "CORSAN")
        dt_vend_rec = obj_op_simplesLn.listar_datatable(sql_vend_rec, "CORSAN")
        For i = 0 To dt_vend_vtas.Rows.Count - 1
            dt_ventas.Columns.Add(dt_vend_vtas.Rows(i).Item("vendedor"), GetType(Double))
            dt_rentabilidad.Columns.Add(dt_vend_vtas.Rows(i).Item("vendedor"), GetType(Double))
        Next
        For i = 0 To dt_vend_rec.Rows.Count - 1
            dt_recaudos.Columns.Add(dt_vend_rec.Rows(i).Item("vendedor"), GetType(Double))
        Next
    End Sub
    Private Sub btn_ppal_Click(sender As System.Object, e As System.EventArgs) Handles btn_ppal.Click
        FrmPrincipal.Show()
        Me.Close()
        FrmPrincipal.Activate()
    End Sub
    Private Function modificarSql(ByVal sql As String) As String
        Dim criterio_vend As String
        If (cbo_vend.Text = "TODOS") Then
            criterio_vend = " AND vendedor >=1001 AND vendedor <= 1099 "
        Else
            criterio_vend = " AND vendedor =" & cbo_vend.Text & " "
        End If
        Dim fec_ini As String = obj_op_simplesLn.cambiarFormatoFecha(cbo_fecha_ini.Value)
        Dim fec_fin As String = obj_op_simplesLn.cambiarFormatoFecha(cbo_fecha_fin.Value)
        sql = Replace(sql, "@fec_ini", fec_ini)
        sql = Replace(sql, "@fec_fin", fec_fin)
        sql = Replace(sql, "@criterio_vend", criterio_vend)
        Return sql
    End Function
    Private Sub btn_salir_Click(sender As System.Object, e As System.EventArgs) Handles btn_salir.Click
        FrmLogin.Show()
        FrmPrincipal.Close()
        FrmLogin.Activate()
        Me.Close()
    End Sub
    Private Sub totalizarCol(ByVal consecutivo As Integer)
        Dim sum As Double = 0
        Select Case consecutivo
            Case 1
                For i = 0 To dtg_ventas.Rows.Count - 1
                    For j = 4 To dtg_ventas.ColumnCount - 1
                        If Not IsDBNull(dtg_ventas.Item(j, i).Value) Then
                            sum += dtg_ventas.Item(j, i).Value
                        End If
                    Next
                    dtg_ventas.Item("TOTAL", i).Value = sum
                    sum = 0
                Next
            Case 2
                For i = 0 To dtg_recaudos.Rows.Count - 1
                    For j = 4 To dtg_recaudos.ColumnCount - 1
                        If Not IsDBNull(dtg_recaudos.Item(j, i).Value) Then
                            sum += dtg_recaudos.Item(j, i).Value
                        End If
                    Next
                    dtg_recaudos.Item("TOTAL", i).Value = sum
                    sum = 0
                Next
            Case 3
                For i = 0 To dtg_rentabilidad.Rows.Count - 1
                    For j = 4 To dtg_rentabilidad.ColumnCount - 1
                        If Not IsDBNull(dtg_rentabilidad.Item(j, i).Value) Then
                            sum += dtg_rentabilidad.Item(j, i).Value
                        End If
                    Next
                    dtg_rentabilidad.Item("TOTAL", i).Value = sum
                    sum = 0
                Next
        End Select

    End Sub
    Private Sub totalizarFilas(ByVal filaIni As Integer, ByVal filaMax As Integer, ByVal consecutivo As Integer)
        Dim sum As Double = 0
        Dim dtg As New DataGridView
        Select Case consecutivo
            Case 1
                For i = 3 To dtg_ventas.ColumnCount - 1
                    For j = filaIni To filaMax - 1
                        If Not IsDBNull(dtg_ventas.Item(i, j).Value) Then
                            If Not IsDBNull(dtg_ventas.Item(i, j).Value) Then
                                sum += dtg_ventas.Item(i, j).Value
                            End If
                        End If
                    Next
                    dtg_ventas.Item(i, filaMax).Value = sum
                    sum = 0
                Next
            Case 2
                For i = 3 To dtg_recaudos.ColumnCount - 1
                    For j = filaIni To filaMax - 1
                        If Not IsDBNull(dtg_recaudos.Item(i, j).Value) Then
                            If Not IsDBNull(dtg_recaudos.Item(i, j).Value) Then
                                sum += dtg_recaudos.Item(i, j).Value
                            End If
                        End If
                    Next
                    dtg_recaudos.Item(i, filaMax).Value = sum
                    sum = 0
                Next
            Case 3
                For i = 3 To dtg_rentabilidad.ColumnCount - 1
                    For j = filaIni To filaMax - 1
                        If Not IsDBNull(dtg_rentabilidad.Item(i, j).Value) Then
                            If Not IsDBNull(dtg_rentabilidad.Item(i, j).Value) Then
                                sum += dtg_rentabilidad.Item(i, j).Value
                            End If
                        End If
                    Next
                    dtg_rentabilidad.Item(i, filaMax).Value = sum
                    sum = 0
                Next
        End Select
    End Sub
    Private Sub calc_porc(ByVal fila As Integer, ByVal fila_resultado As Integer, ByVal consecutivo As Integer)
        Dim porc As Double = 0
        Dim val100 As Double = 0
        Select Case consecutivo
            Case 1
                val100 = dtg_ventas.Item("TOTAL", fila).Value
                For i = 3 To dtg_ventas.Columns.Count - 1
                    If Not IsDBNull(dtg_ventas.Item(i, fila).Value) Then
                        If (val100 <> 0) Then
                            dtg_ventas.Item(i, fila_resultado).Value = dtg_ventas.Item(i, fila).Value / val100 * 100
                        End If
                    End If
                Next
            Case 2
                val100 = dtg_recaudos.Item("TOTAL", fila).Value
                For i = 3 To dtg_recaudos.Columns.Count - 1
                    If Not IsDBNull(dtg_recaudos.Item(i, fila).Value) Then
                        If (val100 <> 0) Then
                            dtg_recaudos.Item(i, fila_resultado).Value = dtg_recaudos.Item(i, fila).Value / val100 * 100
                        End If
                    End If
                Next
            Case 3
                val100 = dtg_rentabilidad.Item("TOTAL", fila).Value
                For i = 3 To dtg_rentabilidad.Columns.Count - 1
                    If Not IsDBNull(dtg_rentabilidad.Item(i, fila).Value) Then
                        If (val100 <> 0) Then
                            dtg_rentabilidad.Item(i, fila_resultado).Value = dtg_rentabilidad.Item(i, fila).Value / val100 * 100
                        End If
                    End If
                Next
        End Select

    End Sub
    Private Sub calcular_rentabilidad()
        For j = 3 To dtg_ventas.Columns.Count - 1
            dtg_rentabilidad.Item(j, dtg_rentabilidad.RowCount - 1).Value = (dtg_rentabilidad.Item(j, dtg_rentabilidad.RowCount - 2).Value / dtg_ventas.Item(j, dtg_ventas.RowCount - 3).Value) * 100
        Next
    End Sub

    Private Sub LiquidaciónRecaudosToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles LiquidaciónRecaudosToolStripMenuItem.Click
        Me.UseWaitCursor = True
        Application.DoEvents()
        objOperacionesForm.exportarExcel(dtg_recaudos)
        Me.UseWaitCursor = False
    End Sub

    Private Sub LoquidaciónRentabilidadToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles LoquidaciónRentabilidadToolStripMenuItem.Click
        Me.UseWaitCursor = True
        Application.DoEvents()
        objOperacionesForm.exportarExcel(dtg_rentabilidad)
        Me.UseWaitCursor = False
    End Sub

    Private Sub InformeRecaudosToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles InformeRecaudosToolStripMenuItem.Click
        Me.UseWaitCursor = True
        Application.DoEvents()
        objOperacionesForm.exportarExcel(dtg_informe_recaudos)
        Me.UseWaitCursor = False
    End Sub

    Private Sub ConsolidadoDeRecaudosToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ConsolidadoDeRecaudosToolStripMenuItem.Click
        Me.UseWaitCursor = True
        Application.DoEvents()
        objOperacionesForm.exportarExcel(dtg_consol_rec)
        Me.UseWaitCursor = False
    End Sub

    Private Sub LiquicaciónVentasToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles LiquicaciónVentasToolStripMenuItem.Click
        Me.UseWaitCursor = True
        Application.DoEvents()
        objOperacionesForm.exportarExcel(dtg_ventas)
        Me.UseWaitCursor = False
    End Sub
    Private Sub toolComisionesVentas_Click(sender As System.Object, e As System.EventArgs) Handles toolComisionesVentas.Click
        Me.UseWaitCursor = True
        Application.DoEvents()
        objOperacionesForm.exportarExcel(dtg_com_vtas)
        Me.UseWaitCursor = False
    End Sub

    Private Sub toolComCoorDir_Click(sender As System.Object, e As System.EventArgs) Handles toolComCoorDir.Click
        Me.UseWaitCursor = True
        Application.DoEvents()
        objOperacionesForm.exportarExcel(dtg_com_coor_dir)
        Me.UseWaitCursor = False
    End Sub
    Private Sub sumarConsolRec()
        Dim sum_com As Double = 0
        Dim sum_rec As Double = 0
        For i = 0 To dtg_consol_rec.Rows.Count - 1
            If (dtg_consol_rec.Item(col_regla.Name, i).Value <> "TOTAL") Then
                sum_com += dtg_consol_rec.Item(col_comision.Name, i).Value
                sum_rec += dtg_consol_rec.Item(col_total_rec.Name, i).Value
            Else
                dtg_consol_rec.Item(col_comision.Name, i).Value = sum_com
                dtg_consol_rec.Item(col_total_rec.Name, i).Value = sum_rec
                sum_com = 0
                sum_rec = 0
            End If
        Next
    End Sub



    Private Sub btn_ok_congelar_Click(sender As System.Object, e As System.EventArgs) Handles btn_ok_congelar.Click
        Dim resp As Boolean = False
        If (cbo_mes_cong.Text <> "Seleccione" And cbo_ano_cong.Text <> "Seleccione") Then
            img_procesar.Visible = True
            Application.DoEvents()
            Dim mes As Integer = cbo_mes_cong.SelectedIndex + 1
            Dim ano As Integer = cbo_ano_cong.Text
            Select Case congelar
                Case "A"
                    resp = congelar_anticipos(mes, ano)
                Case "C"
                    resp = congelar_cartera(mes, ano)
                Case "P"
                    resp = congelar_pendientes(mes, ano)
                Case "V"
                    resp = congelar_ventas(mes, ano)
            End Select
            If (resp) Then
                MessageBox.Show("Los datos del mes " & mes & " del año " & ano & " se congelaron en forma correcta!", "Correcto!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                group_congelar.Visible = False
            Else
                MessageBox.Show("Error al congelar, comuniquese con el administrador del sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            img_procesar.Visible = False
        Else
            MessageBox.Show("Seleccione mes y año a congelar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Private Function congelar_anticipos(ByVal mes As Integer, ByVal ano As Integer) As Boolean
        Dim resp
        Dim sql_recaudos As String = "SELECT tipo,numero,vendedor,fecha,valor_total , valor_aplicado   " &
                                        "FROM documentos " &
                                            "WHERE nit= nit AND sw Like '5'  AND tipo IN ('RCR1','RCO1','RCEX') AND  (valor_total > valor_aplicado or (iva_fletes <0   AND valor_total=valor_aplicado)) AND MONTH (fecha)=" & mes & " AND YEAR (fecha)=" & ano & " "

        Dim dt_anticipos As New DataTable
        dt_anticipos = obj_op_simplesLn.listar_datatable(sql_recaudos, "CORSAN")
        Dim list_sql As New List(Of Object)
        Dim sql_delete As String = "DELETE FROM J_comisiones_rec_congelados WHERE mes =  " & mes & " AND ano = " & ano & ""
        list_sql.Add(sql_delete)
        Dim sql_insert_ppal As String = "INSERT INTO J_comisiones_rec_congelados (mes,ano,vendedor,fec_hora_cong,tipo,numero,fecha,valor_total,valor_aplicado) VALUES("
        Dim sql_insert As String = ""
        For i = 0 To dt_anticipos.Rows.Count - 1
            sql_insert = sql_insert_ppal & "" & mes & "," & ano & "," & dt_anticipos.Rows(i).Item("vendedor") & ",GETDATE (),'" & dt_anticipos.Rows(i).Item("tipo") & "'," & dt_anticipos.Rows(i).Item("numero") & ",'" & obj_op_simplesLn.cambiarFormatoFecha(dt_anticipos.Rows(i).Item("fecha")) & "'," & dt_anticipos.Rows(i).Item("valor_total") & "," & dt_anticipos.Rows(i).Item("valor_aplicado") & "  )"
            list_sql.Add(sql_insert)
        Next
        resp = obj_op_simplesLn.ExecuteSqlTransaction(list_sql)
        Return resp
    End Function
    Private Function congelar_cartera(ByVal mes As Integer, ByVal ano As Integer) As Boolean
        Dim resp
        Dim sql_cartera As String = "SELECT numero,fecha,nit,condicion,vendedor,vencimiento,valor_aplicado,notas,valor_total,tipo  " &
                                        "FROM V_cartera_edades_jjv " &
                                            "WHERE saldo >0 AND Dias_Vencido >0 "

        Dim dt_cartera As New DataTable
        dt_cartera = obj_op_simplesLn.listar_datatable(sql_cartera, "CORSAN")
        Dim list_sql As New List(Of Object)
        Dim sql_delete As String = "DELETE FROM J_congelado_cartera WHERE mes =  " & mes & " AND ano = " & ano & ""
        list_sql.Add(sql_delete)
        Dim sql_insert_ppal As String = "INSERT INTO J_congelado_cartera (ano,mes,numero,fecha,nit,condicion,vendedor,vencimiento,valor_aplicado,notas,valor_total,tipo,fecha_cong) VALUES("
        Dim sql_insert As String = ""
        For i = 0 To dt_cartera.Rows.Count - 1
            sql_insert = sql_insert_ppal & "" & ano & "," & mes & "," & dt_cartera.Rows(i).Item("numero") & " ,'" & obj_op_simplesLn.cambiarFormatoFecha(dt_cartera.Rows(i).Item("fecha")) & "'," & dt_cartera.Rows(i).Item("nit") & "," & dt_cartera.Rows(i).Item("condicion") & "," & dt_cartera.Rows(i).Item("vendedor") & ",'" & obj_op_simplesLn.cambiarFormatoFecha(dt_cartera.Rows(i).Item("vencimiento")) & "'," & dt_cartera.Rows(i).Item("valor_aplicado") & ",'" & dt_cartera.Rows(i).Item("notas") & "'," & dt_cartera.Rows(i).Item("valor_total") & ",'" & dt_cartera.Rows(i).Item("tipo") & "',GETDATE() )"
            list_sql.Add(sql_insert)
        Next
        resp = obj_op_simplesLn.ExecuteSqlTransaction(list_sql)
        Return resp
    End Function
    Private Function congelar_pendientes(ByVal mes As Integer, ByVal ano As Integer) As Boolean
        Dim resp
        Dim sql_pendientes As String = "SELECT fecha,numero,codigo,cant_pedida,cantidad_despachada,valor_unitario,vendedor,nit,notas  " &
                                        "FROM V_pendientes_por_vendedor " &
                                            "WHERE  MONTH (fecha)=" & mes & " AND YEAR (fecha)=" & ano & " "

        Dim dt_pendientes As New DataTable
        dt_pendientes = obj_op_simplesLn.listar_datatable(sql_pendientes, "CORSAN")
        Dim list_sql As New List(Of Object)
        Dim sql_delete As String = "DELETE FROM J_congelado_pendientes WHERE mes =  " & mes & " AND ano = " & ano & ""
        list_sql.Add(sql_delete)
        Dim sql_insert_ppal As String = "INSERT INTO J_congelado_pendientes (ano,mes,fecha,numero,codigo,cant_pedida,cant_despachada,valor_unitario,vendedor,nit,notas,fecha_cong) VALUES("
        Dim sql_insert As String = ""
        For i = 0 To dt_pendientes.Rows.Count - 1
            sql_insert = sql_insert_ppal & "" & ano & "," & mes & ",'" & obj_op_simplesLn.cambiarFormatoFecha(dt_pendientes.Rows(i).Item("fecha")) & "'," & dt_pendientes.Rows(i).Item("numero") & ",'" & dt_pendientes.Rows(i).Item("codigo") & "'," & dt_pendientes.Rows(i).Item("cant_pedida") & "," & dt_pendientes.Rows(i).Item("cantidad_despachada") & "," & dt_pendientes.Rows(i).Item("valor_unitario") & "," & dt_pendientes.Rows(i).Item("vendedor") & "," & dt_pendientes.Rows(i).Item("nit") & ",'" & dt_pendientes.Rows(i).Item("notas") & "',GETDATE())"
            list_sql.Add(sql_insert)

        Next
        resp = obj_op_simplesLn.ExecuteSqlTransaction(list_sql)
        Return resp
    End Function
    Private Function congelar_ventas(ByVal mes As Integer, ByVal ano As Integer) As Boolean
        Dim resp
        Dim sql_ventas As String = "SELECT vendedor,SUM(vr_total) As vr_total,SUM(Cto_total) AS Cto_total,codigo,fec,tipo " &
                                        "FROM Jjv_V_vtas_vend_cliente_ref " &
                                            "WHERE  MONTH (fec)=" & mes & " AND YEAR (fec)=" & ano & " " &
                                                "GROUP BY vendedor,codigo,fec,tipo "

        Dim dt_ventas As New DataTable
        dt_ventas = obj_op_simplesLn.listar_datatable(sql_ventas, "CORSAN")
        Dim list_sql As New List(Of Object)
        Dim sql_delete As String = "DELETE FROM J_congelado_ventas WHERE mes =  " & mes & " AND ano = " & ano & ""
        list_sql.Add(sql_delete)
        Dim sql_insert_ppal As String = "INSERT INTO J_congelado_ventas (ano,mes,vr_total,Cto_total,vendedor,codigo,fec,tipo,fecha_cong) VALUES("
        Dim sql_insert As String = ""
        For i = 0 To dt_ventas.Rows.Count - 1
            sql_insert = sql_insert_ppal & "" & ano & "," & mes & "," & dt_ventas.Rows(i).Item("vr_total") & "," & dt_ventas.Rows(i).Item("Cto_total") & "," & dt_ventas.Rows(i).Item("vendedor") & ",'" & dt_ventas.Rows(i).Item("codigo") & "','" & obj_op_simplesLn.cambiarFormatoFecha(dt_ventas.Rows(i).Item("fec")) & "','" & dt_ventas.Rows(i).Item("tipo") & "',GETDATE())"
            list_sql.Add(sql_insert)
        Next
        resp = obj_op_simplesLn.ExecuteSqlTransaction(list_sql)
        Return resp
    End Function
    Private Sub btn_Cerrar_Click(sender As System.Object, e As System.EventArgs) Handles btn_Cerrar.Click
        group_congelar.Visible = False
    End Sub


    Private Sub btn_admin_reglas_Click(sender As System.Object, e As System.EventArgs) Handles btn_admin_reglas.Click
        Frm_reglas_comisiones.Show()
        Frm_reglas_comisiones.main(usuario.usuario)
        Frm_reglas_comisiones.Activate()
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub cbo_vend_filtro_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbo_vend_filtro.SelectedIndexChanged
        If (carga_comp) Then
            Filtrar_DataGridView("vendedor", cbo_vend_filtro.SelectedValue, "Descripción", cbo_tipo_clasificación.Text, BindingSource1, dtg_informe_recaudos)
        End If

    End Sub

    Private Sub Filtrar_DataGridView(
       ByVal Columna As String,
       ByVal texto As String,
       ByVal Columna2 As String,
       ByVal texto2 As String,
       ByVal BindingSource As BindingSource,
       ByVal DataGridView As DataGridView)

        ' verificar que el DataSource no esté vacio  
        If BindingSource1.DataSource Is Nothing Then
            Exit Sub
        End If

        Try
            img_procesar.Visible = True
            Application.DoEvents()

            Dim filtro As String = String.Empty
            Dim filtro2 As String = ""
            If (texto = "TODOS") Then
                texto = ""
            End If
            If (texto2 = "TODO") Then
                texto2 = ""
            End If
            filtro = "like '" & texto.Trim & "%'"
            filtro2 = "like '" & texto2 & "%'"
            ' Opción para no filtrar  



            ' armar el sql  
            filtro = "([" & Columna & "]" & filtro & " AND [" & Columna2 & "]  " & filtro2 & " OR [" & Columna & "]like'TODO%'  ) "


            ' asigar el criterio a la propiedad Filter del BindingSource  
            BindingSource.Filter = filtro
            ' enlzar el datagridview al BindingSource  
            DataGridView.DataSource = BindingSource.DataSource
            Dim column As DataGridViewColumn = DataGridView.Columns("vendedor")
            Dim column1 As DataGridViewColumn = DataGridView.Columns("D_vencido")
            DataGridView.Sort(column, SortOrder.Ascending)

            totalizarDtgInfoRec()
            ' retornar la cantidad de registros encontrados  

            ' errores  
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
        End Try
        img_procesar.Visible = False
    End Sub
    Private Sub totalizarDtgInfoRec()
        Dim tamano_letra As Single = 9.0!
        Dim fila As Integer = buscarNumFila("tipo", "TOTAL", dtg_informe_recaudos)
        Dim sum As Double = 0
        For j = 0 To dtg_informe_recaudos.Columns.Count - 1
            If (dtg_informe_recaudos.Columns(j).Name = "Total_rec" Or dtg_informe_recaudos.Columns(j).Name = "Val_comisión") Then
                For i = 0 To dtg_informe_recaudos.Rows.Count - 1
                    If i <> fila Then
                        If Not IsDBNull(dtg_informe_recaudos.Item(j, i).Value) Then
                            sum += dtg_informe_recaudos.Item(j, i).Value
                        End If
                    End If
                Next
                dtg_informe_recaudos.Item(j, fila).Value = sum
                sum = 0
            End If
        Next
        dtg_informe_recaudos.Rows(fila).DefaultCellStyle = objOperacionesForm.formatoNegrita(tamano_letra)
        dtg_informe_recaudos.Rows(fila).DefaultCellStyle.BackColor = Color.Red
    End Sub

    Private Sub cbo_tipo_clasificación_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbo_tipo_clasificación.SelectedIndexChanged
        If (carga_comp) Then
            Filtrar_DataGridView("vendedor", cbo_vend_filtro.SelectedValue, "Descripción", cbo_tipo_clasificación.Text, BindingSource1, dtg_informe_recaudos)
        End If
    End Sub

    'Private Sub dtg_informe_recaudos_CellValueChanged(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtg_informe_recaudos.CellValueChanged
    '    If (carga_comp) Then
    '        If (dtg_informe_recaudos.Columns(e.ColumnIndex).Name = "vencimiento") Then
    '            If (dtg_informe_recaudos.Item("tipo", e.RowIndex).Value = "NDCH") Then
    '                If (IsDate(dtg_informe_recaudos.Item("vencimiento", e.RowIndex).Value)) Then
    '                    Dim dias_venc As Integer = DateDiff(DateInterval.Day, dtg_informe_recaudos.Item("vencimiento", e.RowIndex).Value, dtg_informe_recaudos.Item("fecha", e.RowIndex).Value)
    '                    dtg_informe_recaudos.Item("D_vencido", e.RowIndex).Value = dias_venc
    '                    Dim list_sql As New List(Of Object)
    '                    Dim sql As String = "DELETE FROM J_comisiones_ndch_venc WHERE tipo = 'NDCH' AND numero = " & dtg_informe_recaudos.Item("numero", e.RowIndex).Value
    '                    list_sql.Add(sql)
    '                    sql = "INSERT INTO J_comisiones_ndch_venc (tipo,numero,fecha,vencimiento) VALUES ('NDCH'," & dtg_informe_recaudos.Item("numero", e.RowIndex).Value & ",'" & obj_op_simplesLn.cambiarFormatoFecha(dtg_informe_recaudos.Item("fecha", e.RowIndex).Value) & "','" & obj_op_simplesLn.cambiarFormatoFecha(dtg_informe_recaudos.Item("vencimiento", e.RowIndex).Value) & "')"
    '                    list_sql.Add(sql)
    '                    If (obj_op_simplesLn.ExecuteSqlTransaction(list_sql)) Then
    '                        MessageBox.Show("El registro de guardo en forma exitosa", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '                    Else
    '                        MessageBox.Show("Error al guardar el registro, comuniquese con el administrador del sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '                    End If
    '                Else
    '                    carga_comp = False
    '                    MessageBox.Show("Formato de fecha invalido, verifique (AAA/MM/DD)", "Fecha invalida", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '                    dtg_informe_recaudos.Item("fecha_venc", e.RowIndex).Value = ""
    '                    dtg_informe_recaudos.Item("D_vencido", e.RowIndex).Value = ""
    '                    carga_comp = True
    '                End If
    '            End If
    '        End If
    '    End If
    'End Sub

    Private Sub dtg_informe_recaudos_DataError(sender As System.Object, e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dtg_informe_recaudos.DataError

    End Sub

    Private Sub btn_terminar_ndch_fact_Click(sender As System.Object, e As System.EventArgs) Handles btn_terminar_ndch_fact.Click
        If (validar_dtg_ndch()) Then
            If (guardar_partes_ndch()) Then
                MessageBox.Show("La NDCH se partio por facturas en forma correcta,actualice la consulta al terminar de partir todas las NDCH para ver reflejados los cambios!", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Information)
                group_partir_ndch.Visible = False
                dtg_ndch_fact.Rows.Clear()
                txt_valor_ndch.Text = ""
                txt_num_ndch.Text = ""
                For i = 0 To dtg_informe_recaudos.Rows.Count - 1
                    If Not IsDBNull(dtg_informe_recaudos.Item("numero", i).Value) Then
                        If (dtg_informe_recaudos.Item("numero", i).Value = num_ndch_partir) Then
                            dtg_informe_recaudos.Rows(i).DefaultCellStyle.BackColor = Color.Black
                            dtg_informe_recaudos.Rows(i).DefaultCellStyle.ForeColor = Color.White
                        End If
                    End If
                Next
            Else
                MessageBox.Show("Error al guardar, comuniquese con el administrador del sistema", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub
    Private Function guardar_partes_ndch() As Boolean
        Dim sql As String = ""
        Dim listSql As New List(Of Object)
        Dim valor As Double = 0
        sql = "DELETE FROM J_comisiones_ndch_por_factura WHERE numero = " & num_ndch_partir
        listSql.Add(sql)
        For i = 0 To dtg_ndch_fact.RowCount - 1
            If (dtg_ndch_fact.Item(col_ndch_valor.Name, i).Value < 0) Then
                valor = dtg_ndch_fact.Item(col_ndch_valor.Name, i).Value
            Else
                valor = dtg_ndch_fact.Item(col_ndch_valor.Name, i).Value * -1
            End If

            sql = "INSERT INTO J_comisiones_ndch_por_factura (numero,seq,tipo,valor,fecha,vencimiento )VALUES (" & num_ndch_partir & "," & i & ",'NDCH'," & valor & ",'" & obj_op_simplesLn.cambiarFormatoFecha(fecha_ndch_partir) & "','" & obj_op_simplesLn.cambiarFormatoFecha(dtg_ndch_fact.Item(col_ndch_vencimiento.Name, i).Value) & "' )"
            listSql.Add(sql)
        Next
        If (obj_op_simplesLn.ExecuteSqlTransaction(listSql)) Then
            Return True
        Else
            Return False
        End If
    End Function
    Private Function validar_dtg_ndch() As Boolean
        Dim correcto As Boolean = True
        Dim sum As Double = 0
        For i = 0 To dtg_ndch_fact.RowCount - 1
            If Not IsDBNull(dtg_ndch_fact.Item(col_ndch_valor.Name, i).Value) Then
                If Not IsDBNull(dtg_ndch_fact.Item(col_ndch_valor.Name, i).Value) Then
                    If Not IsNumeric(dtg_ndch_fact.Item(col_ndch_valor.Name, i).Value) Then
                        correcto = False
                    End If
                End If
            End If
            If Not IsDBNull(dtg_ndch_fact.Item(col_ndch_vencimiento.Name, i).Value) Then
                If Not IsDBNull(dtg_ndch_fact.Item(col_ndch_vencimiento.Name, i).Value) Then
                    If (dtg_ndch_fact.Item(col_ndch_vencimiento.Name, i).Value = "") Then
                        correcto = False
                    Else
                        sum += dtg_ndch_fact.Item(col_ndch_valor.Name, i).Value
                    End If
                End If
            End If
        Next
        If (correcto) Then
            If (Convert.ToDouble(txt_valor_ndch.Text) <> sum) Then
                correcto = False
                MessageBox.Show("El valor total de las partes(facturas) es mayor al valor total de la NDCH", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            MessageBox.Show("Verifique las fechas y valores de las NDCH", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Return correcto
    End Function


    Private Sub itemPartirNdch_Click(sender As System.Object, e As System.EventArgs) Handles itemPartirNdch.Click
        If (dtg_informe_recaudos.Item("tipo", dtg_informe_recaudos.CurrentCell.RowIndex).Value = "NDCH") Then
            fecha_ndch_partir = dtg_informe_recaudos.Item("fecha", dtg_informe_recaudos.CurrentCell.RowIndex).Value
            If (dtg_informe_recaudos.Item("Total_rec", dtg_informe_recaudos.CurrentCell.RowIndex).Value < -1) Then
                txt_valor_ndch.Text = Format(dtg_informe_recaudos.Item("Total_rec", dtg_informe_recaudos.CurrentCell.RowIndex).Value * -1, "N0")
            Else
                txt_valor_ndch.Text = Format(dtg_informe_recaudos.Item("Total_rec", dtg_informe_recaudos.CurrentCell.RowIndex).Value, "N0")
            End If
            txt_num_ndch.Text = dtg_informe_recaudos.Item("numero", dtg_informe_recaudos.CurrentCell.RowIndex).Value
            num_ndch_partir = dtg_informe_recaudos.Item("numero", dtg_informe_recaudos.CurrentCell.RowIndex).Value
            Dim sql_consult_partida As String = "SELECT SUM (valor) FROM J_comisiones_ndch_por_factura WHERE numero = " & num_ndch_partir
            Dim resp As Integer = 0
            Dim vr_total As String = obj_op_simplesLn.consultarVal(sql_consult_partida)
            If (vr_total <> "") Then
                resp = MessageBox.Show("Esta NDCH ya se encuentra partida, desea eliminar las particiones y volver a generarlas? ", "Eliminar particiones", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If (resp = 6) Then
                    Dim sql_eliminar As String = "DELETE FROM J_comisiones_ndch_por_factura WHERE numero =" & num_ndch_partir
                    If (obj_op_simplesLn.ejecutar(sql_eliminar, "CORSAN")) Then
                        For i = 0 To dtg_informe_recaudos.Rows.Count - 1
                            If Not IsDBNull(dtg_informe_recaudos.Item("numero", i).Value) Then
                                If (dtg_informe_recaudos.Item("numero", i).Value = num_ndch_partir) Then
                                    dtg_informe_recaudos.Rows(i).DefaultCellStyle.BackColor = Color.Black
                                    dtg_informe_recaudos.Rows(i).DefaultCellStyle.ForeColor = Color.White
                                End If
                            End If
                        Next
                        MessageBox.Show("Las particiones se eliminaron en forma exitosa,actualice la consulta al terminar de partir todas las NDCH para ver reflejados los cambios!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("Error al eliminar las particiones, comuniquese con el administrador del sistema", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If
            ElseIf (dtg_informe_recaudos.Rows(dtg_informe_recaudos.CurrentCell.RowIndex).DefaultCellStyle.BackColor = Color.Black) Then
                MessageBox.Show("Esta NDCH ya fue gestionada,actualice la consulta para visualizar los cambios", "Actualizar", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                group_partir_ndch.Visible = True
                lbl_tot_fact.Text = ""
                dtg_ndch_fact.Rows.Add()
            End If
        Else
            MessageBox.Show("Esta operación solo aplica para NDCH", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub btn_ocult_group_ndch_Click(sender As System.Object, e As System.EventArgs) Handles btn_ocult_group_ndch.Click
        group_partir_ndch.Visible = False
        dtg_ndch_fact.Rows.Clear()
        lbl50.Text = ""
        txt_num_ndch.Text = ""
    End Sub

    Private Sub dtg_informe_recaudos_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles dtg_informe_recaudos.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            If (usuario.permiso.Trim <> "VENDEDOR") Then
                With (Me.dtg_informe_recaudos)
                    Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                    If Hitest.Type = DataGridViewHitTestType.Cell Then
                        .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                    End If
                End With
            End If
        End If
    End Sub

    Private Sub dtg_ndch_fact_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtg_ndch_fact.CellClick
        If (e.RowIndex >= 0) Then
            Dim col As String = dtg_ndch_fact.Columns(e.ColumnIndex).Name
            If (col = col_borrar_rec.Name) Then
                dtg_ndch_fact.Rows.RemoveAt(e.RowIndex)
                lbl_tot_fact.Text = Format(tot_dtg_ndch(), "N0")
                If (dtg_ndch_fact.RowCount = 0) Then
                    dtg_ndch_fact.Rows.Add()
                End If
            ElseIf (col = col_add_rec.Name) Then
                dtg_ndch_fact.Rows.Add()
            End If
        End If
    End Sub

    Private Sub dtg_ndch_fact_DataError(sender As System.Object, e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dtg_ndch_fact.DataError

    End Sub
    Private Sub dtg_ndch_fact_CellValueChanged(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtg_ndch_fact.CellValueChanged
        If (carga_comp) Then
            If (dtg_ndch_fact.Columns(e.ColumnIndex).Name = col_ndch_vencimiento.Name) Then
                If Not (IsDate(dtg_ndch_fact.Item(col_ndch_vencimiento.Name, e.RowIndex).Value)) Then
                    carga_comp = False
                    MessageBox.Show("Formato de fecha invalido, verifique (AAA/MM/DD)", "Fecha invalida", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    dtg_ndch_fact.Item(col_ndch_vencimiento.Name, e.RowIndex).Value = ""
                    carga_comp = True
                End If
            ElseIf (dtg_ndch_fact.Columns(e.ColumnIndex).Name = col_ndch_valor.Name) Then
                If IsNumeric(dtg_ndch_fact.Item(col_ndch_valor.Name, e.RowIndex).Value) Then
                    lbl_tot_fact.Text = Format(tot_dtg_ndch(), "N0")
                Else
                    MessageBox.Show("El valor ingresado no es númerico", "Valor invalido", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    carga_comp = False
                    dtg_ndch_fact.Item(col_ndch_valor.Name, e.RowIndex).Value = ""
                    carga_comp = True
                End If
            End If
        End If
    End Sub
    Private Function tot_dtg_ndch() As Double
        Dim sum As Double = 0
        For i = 0 To dtg_ndch_fact.Rows.Count - 1
            If Not IsDBNull(dtg_ndch_fact.Item(col_ndch_valor.Name, i).Value) Then
                If IsNumeric(dtg_ndch_fact.Item(col_ndch_valor.Name, i).Value) Then
                    sum += dtg_ndch_fact.Item(col_ndch_valor.Name, i).Value
                Else
                    MessageBox.Show("El valor ingresado no es númerico", "Valor invalido", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    carga_comp = False
                    dtg_ndch_fact.Item(col_ndch_valor.Name, i).Value = ""
                    carga_comp = True
                End If
            End If
        Next
        Return sum
    End Function
    Private Sub ocultar_vend_consolidado()
        Dim encontrado As Boolean = False
        For i = 0 To dtg_consol_rec.RowCount - 1
            If (dtg_consol_rec.Item(col_vendedor.Name, i).Value <> cbo_vend.SelectedValue) Then
                dtg_consol_rec.Rows(i).Visible = False
            Else
                encontrado = True
            End If
            If (encontrado) Then
                If (dtg_consol_rec.Item(col_vendedor.Name, i).Value <> cbo_vend.SelectedValue) Then
                    dtg_consol_rec.Rows(i).Visible = True
                    encontrado = False
                End If
            End If
        Next
    End Sub
    Private Sub dtg_ventas_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dtg_ventas.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            strDtgSeleccion = dtg_ventas.Name
            With (Me.dtg_ventas)
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                End If
            End With
        End If
    End Sub
    Private Sub dtg_recaudos_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dtg_recaudos.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            strDtgSeleccion = dtg_recaudos.Name
            With (Me.dtg_recaudos)
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                End If
            End With
        End If
    End Sub
    Private Sub dtg_rentabilidad_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dtg_rentabilidad.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            strDtgSeleccion = dtg_rentabilidad.Name
            With (Me.dtg_rentabilidad)
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                End If
            End With
        End If
    End Sub
    Private Sub item_mod_script_Opening(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles item_mod_script.Click
        Dim dtg As DataGridView = Nothing
        Dim numero As Integer = 0
        Dim consecutivo As Integer = 0
        Select Case strDtgSeleccion
            Case dtg_ventas.Name
                dtg = dtg_ventas
            Case dtg_recaudos.Name
                dtg = dtg_recaudos
            Case dtg_rentabilidad.Name
                dtg = dtg_rentabilidad
        End Select
        numero = dtg("numero", dtg.CurrentCell.RowIndex).Value
        consecutivo = dtg("consecutivo", dtg.CurrentCell.RowIndex).Value
        consultar_script_mod(numero, consecutivo)

    End Sub
    Private Sub consultar_script_mod(ByVal numero As Integer, ByVal consecutivo As Integer)
        Dim sql As String = ""
        Dim desc_modulo As String = "nod_liquidacion_com"
        sql = "SELECT descripcion_col ,script  FROM J_script_modulos_prueba WHERE numero = " & numero & " AND desc_modulo = '" & desc_modulo & "' AND consecutivo = " & consecutivo & ""
        Dim dt As DataTable = obj_op_simplesLn.listar_datatable(sql, "CORSAN")
        For i = 0 To dt.Rows.Count - 1
            lbl_desc_item.Text = dt.Rows(i).Item("descripcion_col")
            txt_mod_script.Text = dt.Rows(i).Item("script")
        Next

        txt_consec_mod_script.Text = consecutivo
        txt_num_mod_script.Text = numero
        group_mod_script.Visible = True
    End Sub
    Private Sub btn_ocult_mod_script_Click(sender As System.Object, e As System.EventArgs) Handles btn_ocult_mod_script.Click
        group_mod_script.Visible = False
    End Sub
    Private Sub btn_term_mod_script_Click(sender As System.Object, e As System.EventArgs) Handles btn_term_mod_script.Click
        Dim script As String = txt_mod_script.Text
        Dim numero As Integer = txt_num_mod_script.Text
        Dim consecutivo As Integer = txt_consec_mod_script.Text
        Dim desc_modulo As String = "nod_liquidacion_com"

        If (obj_op_simplesLn.modificar_script(script, numero, consecutivo, desc_modulo, "CORSAN") > 0) Then
            MessageBox.Show("El script se modifico en forma correcta", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Error al modificar el script, comuniquese con el administrador del sistema.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub


    Private Sub item_mod_script_informe_Click(sender As System.Object, e As System.EventArgs) Handles item_mod_script_informe.Click
        Dim numero As Integer = dtg_informe_recaudos.Item("num_script", dtg_informe_recaudos.CurrentCell.RowIndex).Value
        Dim consecutivo As Integer = dtg_informe_recaudos.Item("consecutivo", dtg_informe_recaudos.CurrentCell.RowIndex).Value.ToString
        consultar_script_mod(numero, consecutivo)
    End Sub



    Private Sub tool_cong_anticipos_Click(sender As Object, e As EventArgs) Handles tool_cong_anticipos.Click
        group_congelar.Visible = True
        group_congelar.Text = "Congelar anticipos"
        congelar = "A"
    End Sub


    Private Sub tool_cong_cartera_Click(sender As Object, e As EventArgs) Handles tool_cong_cartera.Click
        group_congelar.Visible = True
        group_congelar.Text = "Congelar cartera"
        congelar = "C"
    End Sub

    Private Sub tool_cong_pendientes_Click(sender As Object, e As EventArgs) Handles tool_cong_pendientes.Click
        group_congelar.Visible = True
        group_congelar.Text = "Congelar pendientes"
        congelar = "P"
    End Sub

    Private Sub tool_cong_ventas_Click(sender As Object, e As EventArgs) Handles tool_cong_ventas.Click
        group_congelar.Visible = True
        group_congelar.Text = "Congelar ventas"
        congelar = "V"
    End Sub


End Class