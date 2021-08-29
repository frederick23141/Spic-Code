Imports logicaNegocios
Imports entidadNegocios
Public Class frm_ordne_prdo_rec2
    Private objOpSimplesLn As New Op_simpesLn
    Private obj_Ing_prodLn As New Ing_prodLn
    Dim obj_gestion_materia_primaLn As New Gestion_materia_primaLn
    Private objOrdenProdLn As New OrdenProdLn
    Dim objTraslado_bodLn As New traslado_bodLn
    Private objOpsimpesLn As New Op_simpesLn
    Private obj_correoLn As New EnvCorreoLN
    Private id_materia_prima As String
    Private Declare Function GetTickCount Lib "kernel32" () As Integer

    'Variables para el usuario
    Dim usuario As UsuarioEn
    Dim numero_transaccion As Double

    'Variables tipo SWICHE para hacer cambios de consultas.
    Dim sw_cliente As Boolean = True
    Dim sw_mp_pf As Boolean = False

    'Variables para selccionar los codigos de materia prima y producto final
    Dim filaSelect As Integer = 0

    'Sirve para consultar la base de datos que utilizaremos en el proseso
    Dim db_produccion As String = ""
    Dim db_corsan As String = ""

    Private Sub frm_ordne_prdo_rec2_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If validar_carga_abierta() Then
            End
        Else
            e.Cancel = True
            MessageBox.Show("No puede abrir una nueva carga si no se ha cerrado la actual", "Cerrar carga actual", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub frm_ordne_prdo_rec2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargar_cbo()
        db_produccion = objOpSimplesLn.get_nom_db("PRODUCCION") & ".dbo."
        db_corsan = objOpSimplesLn.get_nom_db("CORSAN") & ".dbo."
    End Sub
    Public Sub main(ByVal usuario As UsuarioEn)
        Me.usuario = usuario
        If usuario.usuario.Trim = "recocido" Then
            tab_orden_rec.SelectedTab = pag_operario
            pag_orden.Parent = Nothing
            pag_control_ordenes.Parent = Nothing
            pag_det_ab.Parent = Nothing
        Else
            tab_orden_rec.SelectedTab = pag_control_ordenes
            PAG_imp_tiq.Parent = Nothing
            pag_operario.Parent = Nothing
        End If
    End Sub
    Private Sub cargar_cbo()
        Dim sql As String = ""
        Dim dt As New DataTable

        'CBO De Clientes
        sql = "SELECT nit,nombres " &
                " FROM J_v_pendientes_por_vendedor_id_cor " &
                    " WHERE codigo like '33R%' GROUP BY nit,nombres "
        'dt = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        dt = obj_Ing_prodLn.listar_datatable(sql, "CORSAN")
        dt.Rows.Add()
        dt.Rows(dt.Rows.Count - 1).Item("nit") = 890900160
        dt.Rows(dt.Rows.Count - 1).Item("nombres") = "INDUSTRIAS METALICAS CORSAN S.A."


        'Cargar datos de los Hornos
        sql = "SELECT codigoM,Descripción  FROM J_Maquinas WHERE TipoMaquina = '13' "
        dt = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")
        dt.Rows.Add()
        dt.Rows(dt.Rows.Count - 1).Item("codigoM") = 0
        dt.Rows(dt.Rows.Count - 1).Item("Descripción") = "Seleccione"
        cbo_horno.DataSource = dt
        cbo_horno.ValueMember = "codigoM"
        cbo_horno.DisplayMember = "Descripción"
        cbo_horno.SelectedValue = 0

        sql = "SELECT codigoM,Descripción  FROM J_Maquinas WHERE TipoMaquina = '13' "
        dt = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")
        dt.Rows.Add()
        dt.Rows(dt.Rows.Count - 1).Item("codigoM") = 0
        dt.Rows(dt.Rows.Count - 1).Item("Descripción") = "Seleccione"
        cbo_horno_filtro.DataSource = dt
        cbo_horno_filtro.ValueMember = "codigoM"
        cbo_horno_filtro.DisplayMember = "Descripción"
        cbo_horno_filtro.SelectedValue = 0

        'Cargar los CBO para años
        For i = Now.Year - 1 To Now.Year + 1
            cbo_ano_orden.Items.Add(i)
            cbo_ano_trabajr.Items.Add(i)
            cbo_ano_filtro.Items.Add(i)
        Next
        cbo_ano_orden.Text = Now.Year
        cbo_ano_trabajr.Text = Now.Year
        cbo_ano_filtro.Text = Now.Year

        'Informacion del cbo de los meses
        cbo_mes_orden.DataSource = objOpSimplesLn.returnDtMeses()
        cbo_mes_orden.ValueMember = "numMes"
        cbo_mes_orden.DisplayMember = "nombMes"
        cbo_mes_orden.SelectedValue = Now.Month
        cbo_mes_trabajar.DataSource = objOpSimplesLn.returnDtMeses()
        cbo_mes_trabajar.ValueMember = "numMes"
        cbo_mes_trabajar.DisplayMember = "nombMes"
        cbo_mes_trabajar.SelectedValue = Now.Month
        cbo_mes_filtro.DataSource = objOpSimplesLn.returnDtMeses()
        cbo_mes_filtro.ValueMember = "numMes"
        cbo_mes_filtro.DisplayMember = "nombMes"
        cbo_mes_filtro.SelectedValue = Now.Month

        'CBO del operario
        'sql = "SELECT nit,nombres FROM V_nom_personal_Activo_con_maquila WHERE centro IN (2200,2100)  order by nombres"
        'dt = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        'dt.Rows.Add()
        'dt.Rows(dt.Rows.Count - 1).Item("nit") = 0
        'dt.Rows(dt.Rows.Count - 1).Item("nombres") = "Seleccione"
        'cbo_operario.DataSource = dt
        'cbo_operario.ValueMember = "nit"
        'cbo_operario.DisplayMember = "nombres"
        'cbo_operario.SelectedValue = 0


        'sql = "SELECT nit,nombres FROM V_nom_personal_Activo_con_maquila WHERE centro IN (2200,2100)  order by nombres"
        'dt = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        'dt.Rows.Add()
        'dt.Rows(dt.Rows.Count - 1).Item("nit") = 0
        'dt.Rows(dt.Rows.Count - 1).Item("nombres") = "Seleccione"
        'cbo_op_desc.DataSource = dt
        'cbo_op_desc.ValueMember = "nit"
        'cbo_op_desc.DisplayMember = "nombres"
        'cbo_op_desc.SelectedValue = 0
    End Sub

    Private Sub chk_interno_CheckedChanged(sender As Object, e As EventArgs) Handles chk_interno.CheckedChanged
        If chk_interno.Checked Then
            sw_cliente = True
            chk_reproseso.Enabled = True
        Else
            sw_cliente = False
            chk_reproseso.Enabled = False
            chk_reproseso.Checked = False
        End If
    End Sub
    Private Function validar_campos_orden_prod()
        Dim resp As Boolean = False
        Dim count As String = 0
        If cbo_horno.SelectedValue = 0 Then
            lbl_val_horno.Visible = True
            lbl_val_msg.Visible = True
        Else
            lbl_val_horno.Visible = False
            lbl_val_msg.Visible = False
            count += 1
        End If
        If txt_nota.Text = "" Then
            lbl_val_nota.Visible = True
            lbl_val_msg.Visible = True
        Else
            lbl_val_nota.Visible = False
            lbl_val_msg.Visible = False
            count += 1
        End If

        If count = 2 Then
            resp = True
        End If
        Return resp
    End Function
    Private Sub soloNumero(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If (Char.IsDigit(e.KeyChar) Or e.KeyChar = ".") Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub
    Private Sub txt_cantidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_cantidad.KeyPress
        soloNumero(e)
    End Sub
    Private Sub ocultar_info()
        lbl_mensaje.Text = "Registra los codigos de Materia Prima y Producto Final"
        dtg_mp.Enabled = True
        btn_guardar_orden.Enabled = True
        chk_reproseso.Enabled = False

        cbo_ano_orden.Enabled = False
        cbo_mes_orden.Enabled = False
        cbo_horno.Enabled = False
        chk_interno.Enabled = False


        txt_nota.Enabled = False
        btn_agregar.Enabled = False
        lbl_mensaje.Visible = True
        btn_ag_ref.Enabled = True

        dtg_mp.Rows.Add()
        dtg_mp.Item(colCant.Name, 0).Value = 1
        If chk_interno.Checked = True Then
            dtg_mp.Item(col_cliente_pen.Name, 0).Value = "890900160"
        End If
        dtg_mp.Item(ColNumDet.Name, 0).Value = 1
    End Sub
    Private Sub guardar_orden()
        Dim sql As String = "SELECT MAX(cod_orden) FROM JB_orden_prod_rec"
        Dim cod_orden As Integer = obj_Ing_prodLn.consultar_valor(sql, "PRODUCCION") + 1
        Dim not_aud As String = "Creo:" & usuario.usuario & Now
        Dim reproceso As Integer = 0
        If chk_reproseso.Checked = True Then
            reproceso = 1
        End If
        Dim cliente As Integer = 0
        If chk_interno.Checked = True Then
            cliente = 1
        Else
            cliente = 0
        End If
        sql = "INSERT INTO JB_orden_prod_rec (cod_orden,cliente,horno,cantidad,mes,ano,nota,nota_aund,sw,oculto) VALUES (" & cod_orden & "," &
               cliente & "," & cbo_horno.SelectedValue & "," & txt_cantidad.Text & "," & cbo_mes_orden.SelectedValue &
                "," & cbo_ano_orden.Text & ",'" & txt_nota.Text & "','" & not_aud & "'," & reproceso & ",0)"
        If objOpSimplesLn.ejecutar(sql, "PRODUCCION") Then
            ocultar_info()
            lbl_orden.Text = cod_orden
        Else
            lbl_mensaje.Text = "Error al Realizar la tansaccion, comuniquese con el administrador"
            lbl_mensaje.Visible = True
        End If
    End Sub
    Private Sub btn_agregar_Click(sender As Object, e As EventArgs) Handles btn_agregar.Click
        If validar_campos_orden_prod() Then
            guardar_orden()
        End If
    End Sub
    Private Sub dtg_mp_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtg_mp.CellClick
        If (e.RowIndex >= 0) Then
            Dim col As String = dtg_mp.Columns(e.ColumnIndex).Name
            Dim cliente As String = ""
            cliente = dtg_mp.Item(col_cliente_pen.Name, e.RowIndex).Value
            If (col = col_save.Name) Then
                If dtg_mp.Item(codPF.Name, e.RowIndex).Value <> "" Then
                    If dtg_mp.Item(colCodigo_mp.Name, e.RowIndex).Value <> "" Then
                        If dtg_mp.Item(colCant.Name, e.RowIndex).Value > 1 Then
                            If val_refs_orden(lbl_orden.Text, dtg_mp.Item(colCodigo_mp.Name, e.RowIndex).Value, dtg_mp.Item(codPF.Name, e.RowIndex).Value, dtg_mp.Item(col_cliente_pen.Name, e.RowIndex).Value) Then
                                Dim sqlval As String = "SELECT mat_prima FROM JB_orden_prod_rec_refs WHERE cod_orden = " & lbl_orden.Text & " AND num = " & dtg_mp.Item(ColNumDet.Name, e.RowIndex).Value
                                Dim datval As String = objOpSimplesLn.consultValorTodo(sqlval, "PRODUCCION")
                                If datval = "" Then
                                    Dim sql As String = "INSERT INTO JB_orden_prod_rec_refs (num,cod_orden,mat_prima,prod_final,cantidad,cliente,oculto) VALUES (" &
                                                            dtg_mp.Item(ColNumDet.Name, e.RowIndex).Value & "," & lbl_orden.Text &
                                                            ",'" & dtg_mp.Item(colCodigo_mp.Name, e.RowIndex).Value & "','" &
                                                            dtg_mp.Item(codPF.Name, e.RowIndex).Value & "'," & dtg_mp.Item(colCant.Name, e.RowIndex).Value & ",'" & cliente & "',0)"
                                    If objOpSimplesLn.ejecutar(sql, "PRODUCCION") Then
                                        lbl_val_mp.Text = "REFERENCIA INGRESADA CON EXITO"
                                        lbl_val_mp.Visible = True
                                        sumar_total(lbl_orden.Text)
                                        dtg_mp.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.LimeGreen
                                    End If
                                Else
                                    Dim num As Integer = obj_Ing_prodLn.consultar_valor("select MAX(NUM) from JB_orden_prod_rec_refs where cod_orden =" & lbl_orden.Text, "PRODUCCION") + 1
                                    MessageBox.Show("La referencia no puede ser agregada, el numero debe ser mayo a:  " & num, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                End If
                            Else
                                lbl_val_mp.Text = "La referencia ya a sido ingresada"
                                lbl_val_mp.Visible = True
                            End If
                        Else
                            lbl_val_mp.Text = "El peso debe ser mayor a 1"
                            lbl_val_mp.Visible = True
                        End If
                    Else
                        lbl_val_mp.Text = "Debe ingresar una Referencia de materia prima"
                        lbl_val_mp.Visible = True
                    End If
                Else
                    lbl_val_mp.Text = "Debe ingresar una Referencia de producto final"
                    lbl_val_mp.Visible = True
                End If
            End If
            If (col = colCodigo_mp.Name Or col = colDesc_mp.Name) Then
                txtDesc.Text = ""
                txtCodigo.Text = ""
                groupCodigo.Visible = True
                dtg_mp.Enabled = False
                btn_guardar_orden.Enabled = False
                txtDesc.Focus()
                sw_mp_pf = False
                filaSelect = e.RowIndex
                dtgCodigo.DataSource = Nothing
            End If
            If (col = codPF.Name Or col = desc_pf.Name) Then
                If chk_interno.Checked = True Then
                    txtDesc.Text = ""
                    txtCodigo.Text = ""
                    groupCodigo.Visible = True
                    dtg_mp.Enabled = False
                    btn_guardar_orden.Enabled = False
                    txtDesc.Focus()
                    sw_mp_pf = True
                    filaSelect = e.RowIndex
                    dtgCodigo.DataSource = Nothing
                Else
                    group_pendientes.Visible = True
                    dtg_mp.Enabled = False
                    btn_guardar_orden.Enabled = False
                    filaSelect = e.RowIndex
                    cargarCliente()
                End If
            End If
            If (col = col_borrar.Name) Then
                If dtg_mp.Item(colCodigo_mp.Name, e.RowIndex).Value <> "" And dtg_mp.Item(codPF.Name, e.RowIndex).Value <> "" And dtg_mp.Item(col_cliente_pen.Name, e.RowIndex).Value <> "" Then
                    If val_refs_orden(lbl_orden.Text, dtg_mp.Item(colCodigo_mp.Name, e.RowIndex).Value, dtg_mp.Item(codPF.Name, e.RowIndex).Value, dtg_mp.Item(col_cliente_pen.Name, e.RowIndex).Value) Then
                        dtg_mp.Rows.RemoveAt(e.RowIndex)
                    End If
                Else
                    dtg_mp.Rows.RemoveAt(e.RowIndex)
                End If
            End If
        End If
    End Sub
    Private Sub cargarCliente()
        Dim dt As New DataTable
        Dim sql As String = "SELECT nit,nombres,codigo,descripcion ,Cant_pedida,Pendiente " &
                                    "FROM J_v_pendientes_por_vendedor_id_cor " &
                                    "WHERE (codigo like '33R%')"
        dt = objOpSimplesLn.crearDataTableVariasCol(sql, "CORSAN")
        dtg_pendientes.DataSource = dt
        dtg_pendientes.Columns("nit").Visible = False
    End Sub


    Private Sub dtg_pendientes_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtg_pendientes.CellClick
        If (e.RowIndex >= 0) Then
            Dim col As String = dtg_pendientes.Columns(e.ColumnIndex).Name
            If (col = col_selec_pen.Name) Then
                Dim codigo As String = dtg_pendientes.Item("codigo", e.RowIndex).Value
                Dim descripcion As String = dtg_pendientes.Item("descripcion", e.RowIndex).Value
                Dim cliente As String = dtg_pendientes.Item("nit", e.RowIndex).Value
                Dim cantidad As String = dtg_pendientes.Item("Cant_pedida", e.RowIndex).Value

                dtg_mp.Item(col_cliente_pen.Name, filaSelect).Value = cliente
                dtg_mp.Item(codPF.Name, filaSelect).Value = codigo
                dtg_mp.Item(desc_pf.Name, filaSelect).Value = descripcion
                dtg_mp.Item(colCant.Name, filaSelect).Value = cantidad
                group_pendientes.Visible = False
                dtg_mp.Enabled = True
                btn_guardar_orden.Enabled = True
                filaSelect = 0
            End If
        End If
    End Sub

    Private Function val_refs_orden(ByVal cod_orden As Integer, ByVal mp As String, ByVal pf As String, ByVal cli As String)
        Dim resp As Boolean = False
        Dim sql As String = "SELECT num FROM JB_orden_prod_rec_refs WHERE cod_orden = " & cod_orden &
                               " AND mat_prima = '" & mp & "' AND prod_final = '" & pf & "' AND cliente =" & cli
        Dim val As String = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")
        If val = "" Then
            resp = True
        End If
        Return resp
    End Function

    Private Sub sumar_total(ByVal ord As Integer)
        Dim sum As Double = 0
        Dim sql As String = "SELECT SUM(cantidad) FROM JB_orden_prod_rec_refs WHERE cod_orden = " & ord
        sum = obj_Ing_prodLn.consultar_valor(sql, "PRODUCCION")
        txt_cantidad.Text = sum
    End Sub
    Private Sub btnCerrarEditResp_Click(sender As Object, e As EventArgs) Handles btnCerrarEditResp.Click
        groupCodigo.Visible = False
        dtg_mp.Enabled = True
        btn_guardar_orden.Enabled = True
    End Sub
    Private Sub txtCodigo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodigo.TextChanged
        If (txtCodigo.Text.Length > 1) Then
            cargarCodigos(txtCodigo.Text, "")
        End If
    End Sub
    Private Sub txtDesc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDesc.TextChanged
        If (txtDesc.Text.Length > 1) Then
            cargarCodigos("", txtDesc.Text)
        End If
    End Sub
    Private Sub cargarCodigos(ByVal codigo As String, ByVal descripcion As String)
        Dim where_sql As String = ""
        If (codigo <> "") Then
            where_sql &= " codigo like '" & codigo & "%' "
        ElseIf (descripcion <> "") Then
            where_sql &= " descripcion like '%" & descripcion & "%'"
        End If
        If sw_mp_pf = False Then
            where_sql &= " AND (codigo like '22B%'  or codigo like '22R%' or codigo like '22X%')"
        Else
            where_sql &= " AND (codigo like '22R%')"
        End If
        Dim sql As String = "SELECT codigo,descripcion FROM referencias WHERE " & where_sql
        dtgCodigo.DataSource = objOpSimplesLn.listar_datatable(sql, "CORSAN")
    End Sub

    Private Sub dtgCodigo_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgCodigo.CellClick
        If (e.RowIndex >= 0) Then
            Dim col As String = dtgCodigo.Columns(e.ColumnIndex).Name
            If (col = colOk.Name) Then
                Dim codigo As String = dtgCodigo.Item("codigo", e.RowIndex).Value
                Dim descripcion As String = dtgCodigo.Item("descripcion", e.RowIndex).Value
                Dim pf As String = ""
                If chk_interno.Checked Then
                    pf = "22R"
                Else
                    pf = "33R"
                End If
                If sw_mp_pf = True Then
                    dtg_mp.Item(codPF.Name, filaSelect).Value = codigo
                    dtg_mp.Item(desc_pf.Name, filaSelect).Value = descripcion
                Else
                    For i = 3 To codigo.Length - 1
                        pf &= codigo(i)
                    Next
                    Dim sql As String = "SELECT descripcion FROM referencias WHERE codigo = '" & pf & "'"
                    Dim val As String = objOpSimplesLn.consultValorTodo(sql, "CORSAN")
                    If val <> "" Then
                        If chk_interno.Checked = True Then
                            dtg_mp.Item(codPF.Name, filaSelect).Value = pf
                            dtg_mp.Item(desc_pf.Name, filaSelect).Value = val
                        End If
                    Else
                        dtg_mp.Item(codPF.Name, filaSelect).Value = ""
                        dtg_mp.Item(desc_pf.Name, filaSelect).Value = ""
                        MessageBox.Show("El codigo de producto final ingresado no existe,se debe cambiar")
                    End If
                    dtg_mp.Item(colCodigo_mp.Name, filaSelect).Value = codigo
                    dtg_mp.Item(colDesc_mp.Name, filaSelect).Value = descripcion
                End If
                groupCodigo.Visible = False
                dtg_mp.Enabled = True
                btn_guardar_orden.Enabled = True
                filaSelect = 0
            End If
        End If
    End Sub

    Private Sub btn_ag_ref_Click(sender As Object, e As EventArgs) Handles btn_ag_ref.Click
        Dim count As Integer = 1
        For x = 0 To dtg_mp.RowCount - 1
            count += 1
        Next
        dtg_mp.Rows.Add()
        dtg_mp.Item(colCant.Name, count - 1).Value = 1
        dtg_mp.Item(ColNumDet.Name, count - 1).Value = count
        If chk_interno.Checked = True Then
            dtg_mp.Item(col_cliente_pen.Name, count - 1).Value = "890900160"
        End If
    End Sub

    Private Sub btn_guardar_orden_Click(sender As Object, e As EventArgs) Handles btn_guardar_orden.Click
        Dim resp As Integer = MessageBox.Show("¿Desea terminar la orden de producion?", "Terminar Orden", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
        If resp = 6 Then
            If txt_cantidad.Text <> 0 Then
                Dim frm As New Form_solicitud_mp_recocido
                Dim solicitante As String = "890900160"
                Dim observaciones As String = "Pedido automatico para recocido desde el spic"
                Dim devolver As String = "N"
                For Each row As DataGridViewRow In dtg_mp.Rows
                    frm.guardar_automatico(row.Cells("colCodigo_mp").Value.ToString(), row.Cells("colCant").Value.ToString(), cbo_mes_orden.SelectedValue, cbo_ano_orden.Text, solicitante, observaciones, devolver)
                Next
                Dim sql As String = "SELECT sum(cantidad) AS peso FROM JB_orden_prod_rec_refs WHERE cod_orden =" & lbl_orden.Text
                Dim peso As Integer = obj_Ing_prodLn.consultar_valor(sql, "PRODUCCION")
                sql = "UPDATE JB_orden_prod_rec SET cantidad = " & peso & " WHERE cod_orden = " & lbl_orden.Text
                If objOpSimplesLn.ejecutar(sql, "PRODUCCION") Then
                    MessageBox.Show("El registro se ingreso en forma exitosa ", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    limpiar()
                End If
            Else
                MessageBox.Show("No a ingresado ninguna referencia.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub
    Private Sub limpiar()
        dtg_mp.Rows.Clear()
        dtg_mp.Enabled = False
        chk_interno.Checked = True
        chk_interno.Enabled = True
        chk_reproseso.Enabled = True
        cbo_horno.Enabled = True
        cbo_horno.SelectedValue = 0
        txt_cantidad.Text = 0
        txt_nota.Text = ""
        txt_nota.Enabled = True
        btn_guardar_orden.Enabled = False
        btn_agregar.Enabled = True
        btn_ag_ref.Enabled = False
        lbl_mensaje.Visible = False
        lbl_val_mp.Visible = False
        lbl_orden.Text = 0
    End Sub

    'Programa de Orden para trabajar
    Public Function formatoNegrita() As DataGridViewCellStyle
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold)
        Return DataGridViewCellStyle1
    End Function
    Private Sub btn_act_ord_trab_Click(sender As Object, e As EventArgs) Handles btn_act_ord_trab.Click
        dtg_orden_trabajar.DataSource = Nothing
        lbl_detalle_trabajr.Text = ""
        lbl_orden_trabajr.Text = ""
        dtg_ref_reg_orden.DataSource = Nothing
        dtg_rollos_trabajr.DataSource = Nothing
        btn_ag_rollo.Enabled = False
        txt_registro_novedad.Text = ""
        btn_cerrar_planilla.Enabled = False
        group_novedades.Enabled = False
        lbl_cc_trab.Text = ""

        cargar_ordenes()
    End Sub
    Private Sub cargar_ordenes()
        Dim sql As String = "SELECT o.cod_orden AS '#',m.Nombre AS horno,o.cantidad,o.mes,o.ano,o.nota,o.sw,o.cliente " &
                                " FROM JB_orden_prod_rec o, J_Maquinas m " &
                                    " WHERE ( o.horno = m.codigoM) AND o.sw <=2   AND o.oculto = 0 " &
                                        " AND o.mes = " & cbo_mes_trabajar.SelectedValue & " AND o.ano = " & cbo_ano_trabajr.Text & " ORDER BY m.Nombre"
        dtg_orden_trabajar.DataSource = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")
        dtg_orden_trabajar.Columns("horno").DefaultCellStyle = formatoNegrita()
        dtg_orden_trabajar.Columns("horno").Frozen = True
        dtg_orden_trabajar.Columns("#").Frozen = True
        dtg_orden_trabajar.Columns("sw").Visible = False
        dtg_orden_trabajar.Columns("cliente").Visible = False
        For i = 0 To dtg_orden_trabajar.RowCount - 1
            Select Case dtg_orden_trabajar.Item("horno", i).Value
                Case "Horno-1"
                    dtg_orden_trabajar.Item("horno", i).Style.BackColor = Color.Violet
                Case "Horno-2"
                    dtg_orden_trabajar.Item("horno", i).Style.BackColor = Color.OrangeRed
                Case "Horno-3"
                    dtg_orden_trabajar.Item("horno", i).Style.BackColor = Color.Gold
                Case "Horno-4"
                    dtg_orden_trabajar.Item("horno", i).Style.BackColor = Color.LightSeaGreen
            End Select
            If dtg_orden_trabajar.Item("cliente", i).Value = 1 Then
                dtg_orden_trabajar.Rows(i).DefaultCellStyle.BackColor = Color.PowderBlue
            End If
            If dtg_orden_trabajar.Item("cliente", i).Value = 0 Then
                dtg_orden_trabajar.Rows(i).DefaultCellStyle.BackColor = Color.Orange
            End If
            If dtg_orden_trabajar.Item("sw", i).Value = 1 Then
                dtg_orden_trabajar.Rows(i).DefaultCellStyle.BackColor = Color.LimeGreen
            End If

            sql = "SELECT SUM(PESO) FROM JB_rollos_rec WHERE cod_orden_rec = " & dtg_orden_trabajar.Item("#", i).Value
            Dim cantidad As Integer = obj_Ing_prodLn.consultar_valor(sql, "PRODUCCION")
            If dtg_orden_trabajar.Item("cantidad", i).Value <= cantidad Then
                dtg_orden_trabajar.Rows(i).DefaultCellStyle.BackColor = Color.Red
            End If
        Next

    End Sub

    Private Sub dtg_orden_trabajar_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtg_orden_trabajar.CellClick
        If (e.RowIndex >= 0) Then
            Dim col As String = dtg_orden_trabajar.Columns(e.ColumnIndex).Name
            cargar_ref_orden(dtg_orden_trabajar.Item("#", e.RowIndex).Value)
            If col = col_mat_prima.Name Then
                Dim cc As String = InputBox("Ingrese su NUMERO DE DOCUMENTO DE IDENTIDAD.", "Documento de identidad.")
                If cc <> "" Then
                    If validar_cc(cc) Then
                        If validar_carga_abierta() Then
                            lbl_cc_trab.Text = cc
                            lbl_detalle_trabajr.Text = ""
                            lbl_orden_trabajr.Text = ""
                            dtg_rollos_trabajr.DataSource = Nothing
                            If validar_detalle_iniciado(dtg_orden_trabajar.Item("#", e.RowIndex).Value) Then
                                crear_detalle(dtg_orden_trabajar.Item("#", e.RowIndex).Value)
                            End If
                        Else
                            MessageBox.Show("No puede abrir una nueva carga si no se ha cerrado la actual", "Cerrar carga actual", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If
                    End If
                End If
            End If
        End If
    End Sub
    'Validar si se ha cargado rollos
    Private Function validar_carga_abierta()
        Dim resp As Boolean = True
        If dtg_rollos_trabajr.Rows.Count > 0 Then
            resp = False
        End If
        Return resp
    End Function
    Private Function validar_cc(ByVal cc As String)
        Dim resp As Boolean = False
        Dim sql As String = "select nombres from V_nom_personal_Activo_con_maquila where nit in (select nit from control.dbo.D_empleados_sin_salida) and (centro_planta = 2200 or centro_planta is null) and nit ='" & cc & "'"
        Dim name As String = objOpSimplesLn.consultValorTodo(sql, "CORSAN")
        If name <> "" Then
            resp = True
        Else
            MessageBox.Show("El documento no a sido encontrado.", "Documento no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            lbl_detalle_trabajr.Text = ""
            lbl_orden_trabajr.Text = ""
            dtg_ref_reg_orden.DataSource = Nothing
            dtg_rollos_trabajr.DataSource = Nothing
            btn_ag_rollo.Enabled = False
            txt_registro_novedad.Text = ""
            btn_cerrar_planilla.Enabled = False
            group_novedades.Enabled = False
            lbl_cc_trab.Text = ""


            Group_novedad_desc.Enabled = False
            btn_imprimir_tiq.Enabled = False
            lbl_orden_desc.Text = ""
            lbl_detalle_desc.Text = ""
            dtg_rollos_desc.DataSource = Nothing
            txt_novedad_desc.Text = ""
            txt_traccion_desc.Text = ""
            txt_novedad_carga.Text = ""
            lbl_cc_desc.Text = ""
        End If
        Return resp
    End Function
    Private Function validar_detalle_iniciado(ByVal cod_orden As Integer)
        Dim resp As Boolean = False
        Dim sql As String = "SELECT id_detalle FROM JB_orden_prod_rec_detalle WHERE estado = 0 AND cod_orden= " & cod_orden &
                                    " AND operario = " & lbl_cc_trab.Text & " AND fecha_fin IS NULL AND op_descargue IS NULL"
        Dim var As String = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")
        If var = "" Then
            resp = True
        Else
            cargar_rollos(cod_orden, var)
            lbl_detalle_trabajr.Text = var
            lbl_orden_trabajr.Text = cod_orden
            btn_ag_rollo.Enabled = True
            group_novedades.Enabled = True
            btn_cerrar_planilla.Enabled = True
        End If
        Return resp
    End Function
    Private Sub crear_detalle(ByVal cod_orden As Integer)
        Dim resp As Integer = MessageBox.Show("¿Desea iniciar la carga del Horno?", "Cargar Horno.", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
        If resp = 6 Then
            Dim sql As String = "SELECT MAX(id_detalle) FROM JB_orden_prod_rec_detalle WHERE cod_orden=" & cod_orden
            Dim id_detalle As Integer = obj_Ing_prodLn.consultar_valor(sql, "PRODUCCION") + 1

            sql = "INSERT INTO JB_orden_prod_rec_detalle (cod_orden,id_detalle,operario,estado) VALUES (" & cod_orden & "," &
                    id_detalle & "," & lbl_cc_trab.Text & ",0)"
            If objOpSimplesLn.ejecutar(sql, "PRODUCCION") Then
                lbl_detalle_trabajr.Text = id_detalle
                lbl_orden_trabajr.Text = cod_orden
                btn_ag_rollo.Enabled = True
                group_novedades.Enabled = True
                btn_cerrar_planilla.Enabled = True
            End If
        End If
    End Sub
    Private Sub cargar_ref_orden(ByVal nro_orden As Integer)
        Dim sql As String = "SELECT r.num,r.prod_final,c.nombres,r.cantidad AS can,  " &
                            " (select sum(peso) as peso from JB_rollos_rec w Where w.cod_orden_rec = r.cod_orden AND r.num = w.id_prof_final and w.trans is not null) AS tra,r.mat_prima " &
                            " FROM JB_orden_prod_rec_refs r, CORSAN.dbo.terceros c WHERE r.cliente = c.nit AND r.oculto = 0 AND r.cod_orden = " & nro_orden & " order by r.num "
        dtg_ref_reg_orden.DataSource = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")
        dtg_ref_reg_orden.Columns("num").Visible = False
        sql = "select id_prof_final,sum(peso) as peso from JB_rollos_rec where cod_orden_rec = " & nro_orden & " and trans is not null group by id_prof_final"
        Dim dt As DataTable = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")
        For i = 0 To dtg_ref_reg_orden.RowCount - 1
            For j = 0 To dt.Rows.Count - 1
                If dtg_ref_reg_orden.Item("num", i).Value = dt.Rows(j).Item("id_prof_final") Then
                    If dtg_ref_reg_orden.Item("can", i).Value <= dt.Rows(j).Item("peso") Then
                        dtg_ref_reg_orden.Rows(i).DefaultCellStyle.BackColor = Color.Red
                    End If
                End If
            Next
        Next

    End Sub

    Private Sub btn_ag_rollo_Click(sender As Object, e As EventArgs) Handles btn_ag_rollo.Click
        Dim sql As String = "SELECT sw FROM JB_orden_prod_rec WHERE cod_orden=" & lbl_orden_trabajr.Text
        Dim var As String = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")
        If var <> "" Then
            dtg_ref_reg_orden.Enabled = False
            dtg_rollos_trabajr.Enabled = False
            dtg_orden_trabajar.Enabled = False
            'cbo_operario.Enabled = False
            btn_act_ord_trab.Enabled = False
            cbo_mes_trabajar.Enabled = False
            cbo_ano_trabajr.Enabled = False
            btn_ag_rollo.Enabled = False
            group_novedades.Enabled = False
            btn_cerrar_planilla.Enabled = False
            If var = 0 Or var = 2 Then
                group_lector.Visible = True
                cbo_prod_final.Focus()
                cargar_cbo_prod_final()
                txt_lector.Enabled = False
                txt_lector.BackColor = Color.Red
            End If
            If var = 1 Then
                Group_reproseso.Visible = True
                cargar_cbo_ma_prima()
            End If
        End If
    End Sub
    Private Sub cargar_cbo_prod_final()
        Dim sql As String = ""
        Dim dt As New DataTable

        'Cargar datos de las referencias de las ordenes de produccion
        sql = "SELECT r.num,(r.prod_final+'   ('+t.nombres + ')') AS prod_final  FROM JB_orden_prod_rec_refs r, CORSAN.dbo.terceros t WHERE	t.nit = r.cliente AND r.oculto = 0 AND r.cod_orden = " & lbl_orden_trabajr.Text
        dt = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")
        dt.Rows.Add()
        dt.Rows(dt.Rows.Count - 1).Item("num") = 0
        dt.Rows(dt.Rows.Count - 1).Item("prod_final") = "Seleccione"
        cbo_prod_final.DataSource = dt
        cbo_prod_final.ValueMember = "num"
        cbo_prod_final.DisplayMember = "prod_final"
        cbo_prod_final.SelectedValue = 0
    End Sub
    Private Sub cargar_cbo_ma_prima()
        Dim sql As String = ""
        Dim dt As New DataTable

        'Cargar datos de las referencias de las ordenes de produccion
        sql = "SELECT num,mat_prima FROM JB_orden_prod_rec_refs WHERE oculto = 0 and cod_orden = " & lbl_orden_trabajr.Text
        dt = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")
        dt.Rows.Add()
        dt.Rows(dt.Rows.Count - 1).Item("num") = 0
        dt.Rows(dt.Rows.Count - 1).Item("mat_prima") = "Seleccione"
        cbo_rep_mp.DataSource = dt
        cbo_rep_mp.ValueMember = "num"
        cbo_rep_mp.DisplayMember = "mat_prima"
        cbo_rep_mp.SelectedValue = 0

        sql = "Select tipo_calidad  from J_tipo_cal_alambre "
        cbo_rep_clase.DataSource = obj_Ing_prodLn.listar_datatable(sql, "PRODUCCION")
        cbo_rep_clase.ValueMember = "tipo_calidad"
        cbo_rep_clase.DisplayMember = "tipo_calidad"
        cbo_rep_clase.Text = "Seleccione"
        cbo_rep_clase.SelectedValue = 0
    End Sub
    Private Sub txt_lector_Leave(sender As Object, e As EventArgs) Handles txt_lector.Leave
        txt_lector.BackColor = Color.Red
    End Sub
    Private Sub txt_lector_Enter(sender As Object, e As EventArgs) Handles txt_lector.Enter
        txt_lector.BackColor = Color.Green
    End Sub
    'Lector de recocido
    Private Sub txt_lector_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_lector.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            txt_lector.Text = Replace(txt_lector.Text, "'", "-")
            Dim verficacion_dev As String = obj_gestion_materia_primaLn.extraerDatoCodigoBarras("num_consecutivo", txt_lector.Text)
            Dim val As String = "SELECT mat_prima FROM JB_orden_prod_rec_refs WHERE NUM = " & cbo_prod_final.SelectedValue & " AND cod_orden = " & lbl_orden_trabajr.Text
            Dim obtenerval As String = objOpSimplesLn.consultValorTodo(val, "PRODUCCION")
            Dim validacion As Boolean
            If verficacion_dev.Trim <> "DEV" Then
                If obtenerval.ToUpper = "22B100142" Or obtenerval.ToUpper = "22B100125" Then
                    validacion = validar_barras_DEV_lote()
                Else
                    lbl_rollos_restantes.Visible = False
                    validacion = validar_barras_DEV()
                End If
                If validacion Then
                    cbo_prod_final.Focus()
                    If cbo_prod_final.SelectedValue <> 0 Then
                        lbl_error_lector.Visible = False
                        If validar_mp() Then
                            Dim codigo As String = cbo_prod_final.Text
                            If codigo.ToUpper Like "2*" Or codigo.ToUpper Like "33R100142*" Then
                                lbl_error_lector.Visible = False
                                Dim stock As Double = objOpSimplesLn.consultarStock(lbl_cod_lector.Text, 2)
                                Dim peso As Double = lbl_peso_lector.Text
                                If peso <= stock Then
                                    lbl_error_lector.Visible = False

                                    'Dim retraso As Integer
                                    'retraso = 1000 + GetTickCount
                                    'While retraso >= GetTickCount
                                    '    Application.DoEvents()
                                    'End While

                                    id_materia_prima = cbo_prod_final.SelectedValue
                                    Dim sql As String = "SELECT sum(peso) FROM JB_rollos_rec WHERE id_prof_final=" & id_materia_prima & "and cod_orden_rec=" & lbl_orden_trabajr.Text & ""
                                    Dim valor_carga As String = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")
                                    If valor_carga = "" Then
                                        valor_carga = "0"
                                    End If
                                    sql = "SELECT cantidad FROM JB_orden_prod_rec_refs where cod_orden=" & lbl_orden_trabajr.Text & " and num=" & id_materia_prima & ""
                                    Dim valar_referencia As String = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")
                                    If valar_referencia = "" Then
                                        valar_referencia = "0"
                                    End If
                                    If CDbl(valor_carga) <= CDbl(valar_referencia) Then
                                        Dim tipo_guardar As Boolean
                                        If obtenerval.ToUpper = "22B100142" Or obtenerval.ToUpper = "22B100125" Then
                                            tipo_guardar = guardar_rollo_lote()
                                        Else
                                            tipo_guardar = guardar_rollo(peso)
                                        End If
                                        If tipo_guardar Then
                                            lbl_error_lector.Visible = False
                                            lbl_peso_lector.Text = ""
                                            lbl_cod_lector.Text = ""
                                            lbl_nombre_cod.Text = ""
                                            txt_lector.Text = ""
                                            txt_lector.Focus()

                                            cargar_rollos(lbl_orden_trabajr.Text, lbl_detalle_trabajr.Text)
                                        Else
                                            lbl_error_lector.Text = "Error al registrar el rollo o los rollos."
                                            lbl_error_lector.Visible = True
                                        End If
                                    Else
                                        MessageBox.Show("Ya no se puede cargar mas rollos a este cliente", "Al cliente ya se le han cargado todos los rollos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    End If
                                Else
                                    lbl_peso_lector.Text = ""
                                    lbl_cod_lector.Text = ""
                                    lbl_nombre_cod.Text = ""
                                    txt_lector.Text = ""
                                    cbo_prod_final.SelectedValue = 0
                                    txt_lector.Focus()

                                    lbl_error_lector.Text = "No hay STOCK disponible."
                                    lbl_error_lector.Visible = True
                                End If
                            Else
                                group_lector.Enabled = False
                                txt_indicador.Text = ""
                                txt_peso_registro.Text = ""
                                Group_peso.Visible = True
                                Timer1.Enabled = True
                                SerialPort1.Open()
                            End If
                        Else
                            lbl_error_lector.Text = "El producto Final seleccionado No corresponde a la materia Prima."
                            lbl_error_lector.Visible = True
                        End If
                    Else
                        lbl_error_lector.Text = "Debe Seleccionar un producto Final"
                        lbl_error_lector.Visible = True
                    End If

                Else
                    txt_lector.Text = ""
                End If
            Else
            End If
        End If
    End Sub
    Private Function validar_barras()
        Dim resp As Boolean = False
        Dim cod_orden As String = obj_gestion_materia_primaLn.extraerDatoCodigoBarras("num_consecutivo", txt_lector.Text)
        Dim id_detalle As String = obj_gestion_materia_primaLn.extraerDatoCodigoBarras("detalle", txt_lector.Text)
        Dim id_rollo As String = obj_gestion_materia_primaLn.extraerDatoCodigoBarras("id_rollo", txt_lector.Text)

        Dim sql As String = "SELECT fec_roll FROM JB_rollos_devoluciones WHERE fec_roll = " & id_detalle & " AND num_roll = " & id_rollo
        Dim val As String = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")
        If val <> "" Then
            'lbl_error_lector.Visible = False
            'sql = "SELECT anulado FROM J_rollos_tref WHERE cod_orden = " & cod_orden & " AND id_detalle = " & id_detalle & " AND id_rollo = " & id_rollo
            'val = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")
            'If val = "" Then
            lbl_error_lector.Visible = False
            sql = "SELECT trb1 FROM JB_rollos_devoluciones WHERE fec_roll = " & id_detalle & " AND num_roll = " & id_rollo
            val = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")
            If val <> "" Then
                lbl_error_lector.Visible = False
                sql = "SELECT srec FROM JB_rollos_devoluciones WHERE fec_roll = " & id_detalle & " AND num_roll = " & id_rollo
                val = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")
                If val = "" Then
                    lbl_error_lector.Visible = False
                    sql = "SELECT destino FROM JB_rollos_devoluciones WHERE fec_roll = " & id_detalle & " AND num_roll = " & id_rollo
                    val = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")
                    If val <> "" Then
                        lbl_error_lector.Visible = False
                        sql = "SELECT cod_orden_rec FROM JB_rollos_rec WHERE cod_orden_tref = 1 AND id_detalle_tref = " & id_detalle & " AND id_rollo_tref = " & id_rollo
                        val = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")
                        If val = "" Then
                            lbl_error_lector.Visible = False
                            If cargar_peso_cod(1, id_detalle, id_rollo) Then
                                resp = True
                            Else
                                lbl_error_lector.Text = "La referencia del rollo no concide con las registradas en la orden."
                                lbl_error_lector.Visible = True
                            End If
                        Else
                            lbl_error_lector.Text = "El Rollo ya esta registrado en la orden #" & val
                            lbl_error_lector.Visible = True
                        End If
                    End If
                    If val = "P" Then
                        lbl_error_lector.Text = "El Rollo pertenece a Puntilleria"
                        lbl_error_lector.Visible = True
                    End If
                    If val = "G" Then
                        lbl_error_lector.Text = "El Rollo pertenece a Galvanizado"
                        lbl_error_lector.Visible = True
                    End If
                Else
                    lbl_error_lector.Text = "El Rollo ya esta consumido"
                    lbl_error_lector.Visible = True
                End If
            Else
                lbl_error_lector.Text = "El Rollo no a sido trasladado"
                lbl_error_lector.Visible = True
            End If
            'Else
            '    lbl_error_lector.Text = "El Rollo Esta Anulado"
            '    lbl_error_lector.Visible = True
            'End If
        Else
            lbl_error_lector.Text = "Error al leer el tiquete, VUELVA A INTENTARLO."
            lbl_error_lector.Visible = True
        End If
        Return resp
    End Function
    Private Function validar_barras_DEV()
        Dim resp As Boolean = False
        Dim cod_orden As String = obj_gestion_materia_primaLn.extraerDatoCodigoBarras("num_consecutivo", txt_lector.Text)
        Dim id_detalle As String = obj_gestion_materia_primaLn.extraerDatoCodigoBarras("detalle", txt_lector.Text)
        Dim id_rollo As String = obj_gestion_materia_primaLn.extraerDatoCodigoBarras("id_rollo", txt_lector.Text)

        Dim sql As String = "SELECT consecutivo FROM J_rollos_tref WHERE cod_orden = " & cod_orden & " AND id_detalle = " & id_detalle & " AND id_rollo = " & id_rollo
        Dim val As String = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")
        If val <> "" Then
            lbl_error_lector.Visible = False
            sql = "SELECT anulado FROM J_rollos_tref WHERE cod_orden = " & cod_orden & " AND id_detalle = " & id_detalle & " AND id_rollo = " & id_rollo
            val = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")
            If val = "" Then
                'lbl_error_lector.Visible = False
                'sql = "SELECT traslado FROM J_rollos_tref WHERE cod_orden = " & cod_orden & " AND id_detalle = " & id_detalle & " AND id_rollo = " & id_rollo
                'val = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")
                'If val <> "" Then
                lbl_error_lector.Visible = False
                    sql = "SELECT srec FROM J_rollos_tref WHERE cod_orden = " & cod_orden & " AND id_detalle = " & id_detalle & " AND id_rollo = " & id_rollo
                    val = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")
                    If val = "" Then
                        lbl_error_lector.Visible = False
                        sql = "SELECT destino FROM J_rollos_tref WHERE cod_orden = " & cod_orden & " AND id_detalle = " & id_detalle & " AND id_rollo = " & id_rollo
                        val = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")
                    If val = "" Then
                        lbl_error_lector.Visible = False
                        sql = "SELECT cod_orden_rec FROM JB_rollos_rec WHERE cod_orden_tref = " & cod_orden & " AND id_detalle_tref = " & id_detalle & " AND id_rollo_tref = " & id_rollo
                        val = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")
                        If val = "" Then
                            lbl_error_lector.Visible = False
                            If cargar_peso_cod(cod_orden, id_detalle, id_rollo) Then
                                resp = True
                            Else
                                lbl_error_lector.Text = "La referencia del rollo no concide con las registradas en la orden."
                                lbl_error_lector.Visible = True
                            End If
                        Else
                            lbl_error_lector.Text = "El Rollo ya esta registrado en la orden #" & val
                            lbl_error_lector.Visible = True
                        End If
                    End If
                    If val = "P" Then
                            lbl_error_lector.Text = "El Rollo pertenece a Puntilleria"
                            lbl_error_lector.Visible = True
                        End If
                        If val = "G" Then
                            lbl_error_lector.Text = "El Rollo pertenece a Galvanizado"
                            lbl_error_lector.Visible = True
                        End If
                    Else
                        lbl_error_lector.Text = "El Rollo ya esta consumido"
                        lbl_error_lector.Visible = True
                    End If
                'Else
                '    lbl_error_lector.Text = "El Rollo no a sido trasladado"
                '    lbl_error_lector.Visible = True
                'End If
            Else
                lbl_error_lector.Text = "El Rollo Esta Anulado"
                lbl_error_lector.Visible = True
            End If
        Else
            lbl_error_lector.Text = "Error al leer el tiquete, VUELVA A INTENTARLO."
            lbl_error_lector.Visible = True
        End If
        Return resp
    End Function
    Private Function validar_barras_DEV_lote()
        Dim resp As Boolean = False
        Dim cod_orden As String = obj_gestion_materia_primaLn.extraerDatoCodigoBarras("num_consecutivo", txt_lector.Text)
        Dim id_detalle As String = obj_gestion_materia_primaLn.extraerDatoCodigoBarras("detalle", txt_lector.Text)
        Dim val_rollo As String = "select top(1) id_rollo from J_rollos_tref where cod_orden=" & cod_orden & " and id_detalle=" & id_detalle & " and anulado is null and srec is null and no_conforme is null order by id_rollo desc "
        Dim id_rollo As String = objOpSimplesLn.consultValorTodo(val_rollo, "PRODUCCION")
        If id_rollo <> "" Then
            Dim sql As String = "SELECT consecutivo FROM J_rollos_tref WHERE cod_orden = " & cod_orden & " AND id_detalle = " & id_detalle & " AND id_rollo = " & id_rollo
            Dim val As String = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")
            If val <> "" Then
                lbl_error_lector.Visible = False
                sql = "SELECT anulado FROM J_rollos_tref WHERE cod_orden = " & cod_orden & " AND id_detalle = " & id_detalle & " AND id_rollo = " & id_rollo
                val = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")
                If val = "" Then
                    'lbl_error_lector.Visible = False
                    'sql = "SELECT traslado FROM J_rollos_tref WHERE cod_orden = " & cod_orden & " AND id_detalle = " & id_detalle & " AND id_rollo = " & id_rollo
                    'val = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")
                    'If val <> "" Then
                    lbl_error_lector.Visible = False
                    sql = "SELECT srec FROM J_rollos_tref WHERE cod_orden = " & cod_orden & " AND id_detalle = " & id_detalle & " AND id_rollo = " & id_rollo
                    val = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")
                    If val = "" Then
                        lbl_error_lector.Visible = False
                        sql = "SELECT destino FROM J_rollos_tref WHERE cod_orden = " & cod_orden & " AND id_detalle = " & id_detalle & " AND id_rollo = " & id_rollo
                        val = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")
                        If val.ToUpper = "R" Then
                            lbl_error_lector.Visible = False
                            sql = "SELECT cod_orden_rec FROM JB_rollos_rec WHERE cod_orden_tref = " & cod_orden & " AND id_detalle_tref = " & id_detalle & " AND id_rollo_tref = " & id_rollo
                            val = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")
                            If val = "" Then
                                lbl_error_lector.Visible = False
                                If cargar_peso_cod(cod_orden, id_detalle, id_rollo) Then
                                    lbl_error_lector.Visible = False
                                    resp = True
                                Else
                                    lbl_error_lector.Text = "La referencia del rollo no concide con las registradas en la orden."
                                    lbl_error_lector.Visible = True
                                End If
                            Else
                                lbl_error_lector.Text = "Todos los rollos ya han sido leidos"
                                lbl_error_lector.Visible = True
                            End If
                        End If
                        If val = "P" Then
                            lbl_error_lector.Text = "El Rollo pertenece a Puntilleria"
                            lbl_error_lector.Visible = True
                        End If
                        If val = "G" Then
                            lbl_error_lector.Text = "El Rollo pertenece a Galvanizado"
                            lbl_error_lector.Visible = True
                        End If
                    Else
                        lbl_error_lector.Text = "El Rollo ya esta consumido"
                        lbl_error_lector.Visible = True
                    End If
                    'Else
                    '    lbl_error_lector.Text = "El Rollo no a sido trasladado"
                    '    lbl_error_lector.Visible = True
                    'End If
                Else
                    lbl_error_lector.Text = "El Rollo Esta Anulado"
                    lbl_error_lector.Visible = True
                End If
            Else
                lbl_error_lector.Text = "Error al leer el tiquete o se consumio todos los rollos del tiquete, VUELVA A INTENTARLO."
                lbl_error_lector.Visible = True
            End If
        End If
        Return resp
    End Function
    Private Function cargar_peso_cod(ByVal cod_orden As String, ByVal id_detalle As String, ByVal id_rollo As String)
        Dim resp As Boolean = False
        Dim sql As String = "SELECT r.peso,o.prod_final,d.descripcion FROM J_rollos_tref r, J_orden_prod_tef o, " & db_corsan & "referencias d WHERE (r.cod_orden = o.consecutivo AND o.prod_final = d.codigo) " &
                                " AND r.cod_orden = " & cod_orden & " AND r.id_detalle = " & id_detalle & " AND r.id_rollo = " & id_rollo
        Dim dt As DataTable = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")
        Dim ref_rollo As String = ""
        For i = 0 To dt.Rows.Count - 1
            ref_rollo = dt.Rows(i).Item("prod_final")
        Next
        sql = "SELECT mat_prima FROM JB_orden_prod_rec_refs WHERE cod_orden = " & lbl_orden_trabajr.Text
        Dim dt2 As DataTable = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")

        Dim count As Integer = 0

        For i = 0 To dt2.Rows.Count - 1
            Dim ref_val As String = dt2.Rows(i).Item("mat_prima")
            If ref_rollo.ToUpper = ref_val.ToUpper Then
                count += 1
            End If
        Next
        If count >= 1 Then
            For i = 0 To dt.Rows.Count - 1
                lbl_cod_lector.Text = dt.Rows(i).Item("prod_final")
                lbl_peso_lector.Text = dt.Rows(i).Item("peso")
                lbl_nombre_cod.Text = dt.Rows(i).Item("descripcion")
            Next
            resp = True
        End If
        Return resp
    End Function
    Private Function validar_mp()
        Dim resp As Boolean = False
        Dim sql As String = "SELECT mat_prima FROM JB_orden_prod_rec_refs WHERE NUM = " & cbo_prod_final.SelectedValue & " AND cod_orden = " & lbl_orden_trabajr.Text
        Dim mp As String = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")
        Dim mp_lbl As String = lbl_cod_lector.Text
        If mp.ToUpper = mp_lbl.ToUpper Then
            resp = True
        End If
        Return resp
    End Function
    Private Function guardar_rollo(ByVal peso As Double)
        Dim resp As Boolean = False
        Dim cod_orden_tref As String = obj_gestion_materia_primaLn.extraerDatoCodigoBarras("num_consecutivo", txt_lector.Text)
        Dim id_detalle_tref As String = obj_gestion_materia_primaLn.extraerDatoCodigoBarras("detalle", txt_lector.Text)
        Dim id_rollo_tref As String = obj_gestion_materia_primaLn.extraerDatoCodigoBarras("id_rollo", txt_lector.Text)

        Dim traccion_tref As Integer = 0
        Dim colada As String = "1"
        Dim diametro As Double = 0
        Dim calidad As Integer = 0

        Dim sql As String = "SELECT MAX(id_rollo_rec) FROM JB_rollos_rec WHERE cod_orden_rec = " & lbl_orden_trabajr.Text & " AND id_detalle_rec = " & lbl_detalle_trabajr.Text
        Dim id_rollo_rec As Integer = obj_Ing_prodLn.consultar_valor(sql, "PRODUCCION") + 1
        Dim limite As Integer = obj_Ing_prodLn.consultar_valor("select limite from j_det_tref_limit", "PRODUCCION")

        If id_rollo_rec <= limite Then
            sql = "SELECT r.traccion,r.colada,t.diam_min,t.calidad " &
                    " FROM J_ROLLOS_TREF r, J_orden_prod_tef t " &
                        " WHERE (r.cod_orden = t.consecutivo) AND r.cod_orden = " & cod_orden_tref & " AND r.id_detalle = " & id_detalle_tref & " AND r.id_rollo = " & id_rollo_tref
            Dim dt As DataTable = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")

            For i = 0 To dt.Rows.Count - 1
                If dt.Rows(i).Item("traccion") <> "" Then
                    traccion_tref = dt.Rows(i).Item("traccion")
                End If
                If dt.Rows(i).Item("colada") <> "" Then
                    colada = dt.Rows(i).Item("colada")
                End If
                diametro = dt.Rows(i).Item("diam_min")
                If dt.Rows(i).Item("calidad") <> "" Then
                    calidad = dt.Rows(i).Item("calidad")
                End If
            Next
            sql = "INSERT INTO JB_rollos_rec (cod_orden_tref,id_detalle_tref,id_rollo_tref,cod_orden_rec,id_detalle_rec,id_rollo_rec,id_prof_final,peso,traccion_rec,traccion_tref,colada,diametro,clase) VALUES (" &
                cod_orden_tref & "," & id_detalle_tref & "," & id_rollo_tref & "," & lbl_orden_trabajr.Text & "," & lbl_detalle_trabajr.Text & "," & id_rollo_rec & "," & cbo_prod_final.SelectedValue &
                "," & peso & ",0," & traccion_tref & ",'" & colada & "'," & diametro & "," & calidad & ")"
            If objOpSimplesLn.ejecutar(sql, "PRODUCCION") Then
                resp = True
            End If
        End If
        Return resp
    End Function
    'GUARDA TODOS LOS ROLLOS DEL LOTE
    Private Function guardar_rollo_lote()
        Dim resp As Boolean = False
        Dim date_rollos As DataTable
        Dim cod_orden_tref As String = obj_gestion_materia_primaLn.extraerDatoCodigoBarras("num_consecutivo", txt_lector.Text)
        Dim id_detalle_tref As String = obj_gestion_materia_primaLn.extraerDatoCodigoBarras("detalle", txt_lector.Text)

        Dim rollos As String = "select id_rollo,peso from j_rollos_tref where cod_orden=" & cod_orden_tref & " and id_detalle=" & id_detalle_tref & " AND anulado is null  and srec is null and no_conforme is null order by id_rollo"
        date_rollos = objOpSimplesLn.listar_datatable(rollos, "PRODUCCION")
        Dim nro_rollos As Integer = 0
        Dim diferencia As Integer = 0
        Dim sql_nro_rollos As String = "select count(id_rollo) from j_rollos_tref where cod_orden=" & cod_orden_tref & " and id_detalle=" & id_detalle_tref & " AND anulado is null  and srec is null "
        nro_rollos = objOpSimplesLn.consultValorTodo(sql_nro_rollos, "PRODUCCION")
        Dim sql_recocido As String = "Select count(id_rollo_rec) from jb_rollos_rec where cod_orden_rec=" & lbl_orden_trabajr.Text & " AND id_detalle_rec = " & lbl_detalle_trabajr.Text
        Dim total_recocido As Integer = objOpSimplesLn.consultValorTodo(sql_recocido, "PRODUCCION")
        Dim sql_tref As String = "select count(id_rollo) from j_rollos_tref where cod_orden=" & cod_orden_tref & " and id_detalle=" & id_detalle_tref & " and anulado is null and srec is null"
        Dim total_tref As Integer = objOpSimplesLn.consultValorTodo(sql_tref, "PRODUCCION")
        Dim suma_rec_tref As Integer = total_recocido + total_tref
        Dim limite As Integer = obj_Ing_prodLn.consultar_valor("select limite from j_det_tref_limit", "PRODUCCION")
        If suma_rec_tref > limite Then
            diferencia = suma_rec_tref - limite
            If diferencia <> nro_rollos Then
                suma_rec_tref -= diferencia
                Dim i As Integer = diferencia - 1
                date_rollos.AcceptChanges()
                While i >= 0
                    date_rollos.Rows.RemoveAt(i)
                    i -= 1
                    date_rollos.AcceptChanges()
                End While
                lbl_rollos_restantes.Visible = True
                lbl_rollos_restantes.Text = "Rollos restantes:" & diferencia & ""
            End If
        End If
        Dim traccion_tref As Integer = 0
        Dim colada As String = "1"
        Dim diametro As Double = 0
        Dim calidad As Integer = 0
        If suma_rec_tref <= limite Then
            For j = 0 To date_rollos.Rows.Count - 1
                Dim sql As String = "SELECT MAX(id_rollo_rec) FROM JB_rollos_rec WHERE cod_orden_rec = " & lbl_orden_trabajr.Text & " AND id_detalle_rec = " & lbl_detalle_trabajr.Text
                Dim id_rollo_rec As Integer = obj_Ing_prodLn.consultar_valor(sql, "PRODUCCION") + 1

                sql = "SELECT r.traccion,r.colada,t.diam_min,t.calidad " &
                        " FROM J_ROLLOS_TREF r, J_orden_prod_tef t " &
                            " WHERE (r.cod_orden = t.consecutivo) AND r.cod_orden = " & cod_orden_tref & " AND r.id_detalle = " & id_detalle_tref & " AND r.id_rollo = " & date_rollos.Rows(j).Item("id_rollo")
                Dim dt As DataTable = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")

                For i = 0 To dt.Rows.Count - 1
                    If dt.Rows(i).Item("traccion") <> "" Then
                        traccion_tref = dt.Rows(i).Item("traccion")
                    End If
                    If dt.Rows(i).Item("colada") <> "" Then
                        colada = dt.Rows(i).Item("colada")
                    End If
                    diametro = dt.Rows(i).Item("diam_min")
                    If dt.Rows(i).Item("calidad") <> "" Then
                        calidad = dt.Rows(i).Item("calidad")
                    End If
                Next
                sql = "INSERT INTO JB_rollos_rec (cod_orden_tref,id_detalle_tref,id_rollo_tref,cod_orden_rec,id_detalle_rec,id_rollo_rec,id_prof_final,peso,traccion_rec,traccion_tref,colada,diametro,clase) VALUES (" &
                    cod_orden_tref & "," & id_detalle_tref & "," & date_rollos.Rows(j).Item("id_rollo") & "," & lbl_orden_trabajr.Text & "," & lbl_detalle_trabajr.Text & "," & id_rollo_rec & "," & cbo_prod_final.SelectedValue &
                    "," & date_rollos.Rows(j).Item("peso") & ",0," & traccion_tref & ",'" & colada & "'," & diametro & "," & calidad & ")"
                If objOpSimplesLn.ejecutar(sql, "PRODUCCION") Then
                    resp = True
                End If
            Next
        Else
            lbl_error_lector.Text = "Limite de 60 alcanzado."
        End If
        Return resp
    End Function
    Private Sub cargar_rollos(ByVal cod_orden As Integer, ByVal id_detalle As Integer)

        Dim sql As String = "SELECT r.id_rollo_rec AS '#',r.peso,r.traccion_rec,f.mat_prima,f.prod_final  " &
                            " FROM JB_rollos_rec r, JB_orden_prod_rec_refs f " &
                            " WHERE ( r.id_prof_final = f.num AND r.cod_orden_rec = f.cod_orden)  " &
                            " AND r.cod_orden_rec = " & cod_orden & " AND r.id_detalle_rec = " & id_detalle & " ORDER BY r.id_rollo_rec DESC"
        dtg_rollos_trabajr.DataSource = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")
        For i = 0 To dtg_rollos_trabajr.RowCount - 1
            If dtg_rollos_trabajr.Item("prod_final", i).Value Like "22R2*" Or dtg_rollos_trabajr.Item("prod_final", i).Value Like "33R2*" Then
                dtg_rollos_trabajr.Rows(i).DefaultCellStyle.BackColor = Color.CornflowerBlue
            End If
            If dtg_rollos_trabajr.Item("prod_final", i).Value Like "22R1*" Or dtg_rollos_trabajr.Item("prod_final", i).Value Like "33R1*" Then
                If dtg_rollos_trabajr.Item("prod_final", i).Value Like "22R1Q*" Or dtg_rollos_trabajr.Item("prod_final", i).Value Like "33R1Q*" Then
                    dtg_rollos_trabajr.Rows(i).DefaultCellStyle.BackColor = Color.Gold
                Else
                    dtg_rollos_trabajr.Rows(i).DefaultCellStyle.BackColor = Color.HotPink
                End If
            End If
        Next
    End Sub

    Private Sub btn_terminar_lec_Click(sender As Object, e As EventArgs) Handles btn_terminar_lec.Click
        dtg_ref_reg_orden.Enabled = True
        dtg_rollos_trabajr.Enabled = True
        dtg_orden_trabajar.Enabled = True
        'cbo_operario.Enabled = True
        btn_act_ord_trab.Enabled = True
        cbo_mes_trabajar.Enabled = True
        cbo_ano_trabajr.Enabled = True
        btn_ag_rollo.Enabled = True
        group_novedades.Enabled = True
        group_lector.Visible = False
        btn_cerrar_planilla.Enabled = True

        lbl_error_lector.Visible = False
        lbl_peso_lector.Text = ""
        lbl_cod_lector.Text = ""
        lbl_nombre_cod.Text = ""
        txt_lector.Text = ""
        cbo_prod_final.SelectedValue = 0
    End Sub

    Private Sub btn_pesar_Click(sender As Object, e As EventArgs) Handles btn_pesar.Click
        id_materia_prima = cbo_prod_final.SelectedValue
        Dim sql As String = "SELECT sum(peso) FROM JB_rollos_rec WHERE id_prof_final=" & id_materia_prima & "and cod_orden_rec=" & lbl_orden_trabajr.Text & ""
        Dim valor_carga As String = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")
        If valor_carga = "" Then
            valor_carga = "0"
        End If
        sql = "SELECT cantidad FROM JB_orden_prod_rec_refs where cod_orden=" & lbl_orden_trabajr.Text & " and num=" & id_materia_prima & ""
        Dim valar_referencia As String = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")
        If valar_referencia = "" Then
            valar_referencia = "0"
        End If
        If CDbl(valor_carga) <= CDbl(valar_referencia) Then
            If txt_peso_registro.Text <> "" Then

                lbl_error_lector.Visible = False
                Dim stock As Double = objOpSimplesLn.consultarStock(lbl_cod_lector.Text, 2)
                Dim peso As Double = txt_peso_registro.Text

                Dim peso_real As Double = peso
                Dim peso_int As Integer = peso

                Dim diferencia As Double = Format(peso_real - peso_int, "#0.0")
                If diferencia < -0.3 Then
                    peso_int -= 1
                    diferencia = Format(peso_real - peso_int, "#0.0")
                End If

                Dim peso_val As Integer = obt_pes()

                If peso_val <= stock Then
                    lbl_error_lector.Visible = False
                    If guardar_rollo(peso_int) Then
                        group_lector.Enabled = True
                        lbl_error_lector.Visible = False
                        lbl_peso_lector.Text = ""
                        lbl_cod_lector.Text = ""
                        lbl_nombre_cod.Text = ""
                        txt_lector.Text = ""
                        txt_lector.Focus()
                        cargar_rollos(lbl_orden_trabajr.Text, lbl_detalle_trabajr.Text)

                        Group_peso.Visible = False
                        Timer1.Enabled = False
                        SerialPort1.Close()
                    Else
                        lbl_error_lector.Text = "Error al registrar el rollo."
                        lbl_error_lector.Visible = True
                    End If
                Else
                    lbl_peso_lector.Text = ""
                    lbl_cod_lector.Text = ""
                    lbl_nombre_cod.Text = ""
                    txt_lector.Text = ""
                    cbo_prod_final.SelectedValue = 0
                    txt_lector.Focus()
                    lbl_error_lector.Text = "No hay STOCK disponible."
                    lbl_error_lector.Visible = True
                End If
            End If
        Else
            MessageBox.Show("Ya no se puede cargar mas rollos a este cliente", "Al cliente ya se le han cargado todos los rollos", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
    Private Function obt_pes()
        Dim peso As Double = Convert.ToDouble(lbl_peso_lector.Text)
        Dim peso_real As Double = peso
        Dim peso_int As Integer = peso

        Dim diferencia As Double = Format(peso_real - peso_int, "#0.0")
        If diferencia < -0.3 Then
            peso_int -= 1
            diferencia = Format(peso_real - peso_int, "#0.0")
        End If

        Return peso_int
    End Function

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Dim peso As String = ""
        If (txt_indicador.TextLength >= 23) Then
            txt_indicador.Text = peso
        End If
        If SerialPort1.IsOpen Then
            peso = SerialPort1.ReadExisting
        End If
        txt_indicador.Text += peso
        capturarPeso()
    End Sub
    Private Function capturarPeso() As String
        Dim pesoFinal As String = ""
        Dim primerIgual As Boolean = False
        For i = 0 To txt_indicador.TextLength - 1
            If (txt_indicador.Text(i) = "+" Or primerIgual = True) Then
                If (primerIgual = False) Then
                    i += 1
                    primerIgual = True
                End If
                If (txt_indicador.Text(i) <> "+") Then
                    If (txt_indicador.Text(i) <> " ") Then
                        If (txt_indicador.Text(i) = "0") Then
                            If (pesoFinal.Length > 0) Then
                                pesoFinal += txt_indicador.Text(i)
                            End If
                        Else
                            If (txt_indicador.Text(i) <> "k") Then
                                If (txt_indicador.Text(i) <> "g") Then
                                    If (txt_indicador.Text(i) <> "S") Then
                                        If (txt_indicador.Text(i) <> "T") Then
                                            If (txt_indicador.Text(i) <> ",") Then
                                                If (txt_indicador.Text(i) <> "G") Then
                                                    If (txt_indicador.Text(i) <> "S") Then
                                                        If (txt_indicador.Text(i) <> ",") Then
                                                            If (txt_indicador.Text(i) <> "+") Then
                                                                pesoFinal += txt_indicador.Text(i)
                                                            End If
                                                        End If
                                                    End If
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                Else
                    i = txt_indicador.TextLength
                End If
            End If
        Next
        If (pesoFinal = "") Then
            Dim primerNumeroNoCero As Boolean = False
            For i = 0 To txt_indicador.Text.Length - 1
                If ((txt_indicador.Text(i) <> "0" And txt_indicador.Text(i) <> " ") Or primerNumeroNoCero = True) Then
                    primerNumeroNoCero = True
                    pesoFinal += txt_indicador.Text(i)
                End If
            Next

        End If
        If IsNumeric(pesoFinal) Then
            If pesoFinal > 0 Then
                txt_peso_registro.Text = pesoFinal
            Else
                txt_peso_registro.Text = ""
            End If
        Else
            txt_peso_registro.Text = ""
        End If
        Return pesoFinal
    End Function

    Private Sub dtg_rollos_trabajr_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtg_rollos_trabajr.CellClick
        If (e.RowIndex >= 0) Then
            Dim col As String = dtg_rollos_trabajr.Columns(e.ColumnIndex).Name
            If col = col_borrar_rollo.Name Then
                Dim sql As String = ""
                Dim resp As Integer = MessageBox.Show("¿Desea Borrar el Rollo?", "Borrar Rollo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                If resp = 6 Then
                    sql = "DELETE JB_rollos_rec WHERE cod_orden_rec = " & lbl_orden_trabajr.Text & " AND id_detalle_rec = " & lbl_detalle_trabajr.Text & " AND id_rollo_rec = " & dtg_rollos_trabajr.Item("#", e.RowIndex).Value
                    If objOpSimplesLn.ejecutar(sql, "PRODUCCION") Then
                        cargar_rollos(lbl_orden_trabajr.Text, lbl_detalle_trabajr.Text)
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub btn_rep_terminar_Click(sender As Object, e As EventArgs) Handles btn_rep_terminar.Click
        dtg_ref_reg_orden.Enabled = True
        dtg_rollos_trabajr.Enabled = True
        dtg_orden_trabajar.Enabled = True
        'cbo_operario.Enabled = True
        btn_act_ord_trab.Enabled = True
        cbo_mes_trabajar.Enabled = True
        cbo_ano_trabajr.Enabled = True
        btn_ag_rollo.Enabled = True
        Group_reproseso.Visible = False
        group_novedades.Enabled = True
        btn_cerrar_planilla.Enabled = True

        cbo_rep_clase.SelectedValue = 0
        cbo_rep_mp.SelectedValue = 0
        lbl_rep_pf.Text = ""
        txt_rep_trac_tref.Text = ""
        txt_rep_diametro.Text = ""
        txt_rep_colada.Text = ""
    End Sub

    Private Sub cbo_rep_mp_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbo_rep_mp.SelectionChangeCommitted
        If cbo_rep_mp.SelectedValue <> 0 Then
            Dim sql As String = "SELECT prod_final FROM JB_orden_prod_rec_refs WHERE num = " & cbo_rep_mp.SelectedValue & " AND cod_orden = " & lbl_orden_trabajr.Text
            lbl_rep_pf.Text = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")
        End If
    End Sub

    Private Sub txt_rep_trac_tref_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_rep_trac_tref.KeyPress
        soloNumero(e)
    End Sub

    Private Sub txt_rep_diametro_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_rep_diametro.KeyPress
        soloNumero(e)
    End Sub

    Private Sub btn_rep_registrar_Click(sender As Object, e As EventArgs) Handles btn_rep_registrar.Click
        If validar_reproceso() Then
            If guardar_rollo_rep() Then
                'cbo_rep_clase.SelectedValue = 0
                cbo_rep_mp.SelectedValue = 0
                lbl_rep_pf.Text = ""
                'txt_rep_trac_tref.Text = ""
                txt_rep_diametro.Text = ""
                'txt_rep_colada.Text = ""
                txt_rep_peso.Text = ""
                cargar_rollos(lbl_orden_trabajr.Text, lbl_detalle_trabajr.Text)

                lbl_rep_val_error.Text = "El Rollo se Guardo con Exito"
                lbl_rep_val_error.Visible = True
            End If
        End If
    End Sub
    Private Function validar_reproceso()
        Dim resp As Boolean = False
        Dim count As Integer = 0
        lbl_rep_val_error.Text = "Los campos marcados con * son necesarios."
        If cbo_rep_mp.SelectedValue <> 0 Then
            lbl_rep_val_error.Visible = False
            lbl_rep_val_mp.Visible = False
            count += 1
        Else
            lbl_rep_val_mp.Visible = True
            lbl_rep_val_error.Visible = True
        End If

        If txt_rep_colada.Text <> "" Then
            lbl_rep_val_error.Visible = False
            lbl_rep_val_col.Visible = False
            count += 1
        Else
            lbl_rep_val_error.Visible = True
            lbl_rep_val_col.Visible = True
        End If

        If txt_rep_diametro.Text <> "" Then
            lbl_rep_val_error.Visible = False
            lbl_rep_val_diam.Visible = False
            count += 1
        Else
            lbl_rep_val_error.Visible = True
            lbl_rep_val_diam.Visible = True
        End If

        If txt_rep_trac_tref.Text <> "" Then
            lbl_rep_val_error.Visible = False
            lbl_rep_val_trac.Visible = False
            count += 1
        Else
            lbl_rep_val_error.Visible = True
            lbl_rep_val_trac.Visible = True
        End If
        If cbo_rep_clase.Text <> "" Then
            lbl_rep_val_error.Visible = False
            lbl_rep_val_cals.Visible = False
            count += 1
        Else
            lbl_rep_val_error.Visible = True
            lbl_rep_val_cals.Visible = True
        End If
        If txt_rep_peso.Text <> "" Then
            count += 1
            lbl_rep_val_error.Visible = False
            lbl_rep_val_peso.Visible = False
        Else
            lbl_rep_val_error.Visible = True
            lbl_rep_val_peso.Visible = True
        End If

        If count = 6 Then
            resp = True
            lbl_rep_val_error.Visible = False
        End If
        Return resp
    End Function
    Private Function guardar_rollo_rep()
        Dim resp As Boolean = False
        Dim sql As String = ""
        Dim peso As Double = txt_rep_peso.Text
        Dim stock As Double = objOpSimplesLn.consultarStock(cbo_rep_mp.Text, 2)
        'If peso <= stock Then
        sql = "SELECT MAX(id_rollo_rec) FROM JB_rollos_rec WHERE cod_orden_rec = " & lbl_orden_trabajr.Text & " AND id_detalle_rec = " & lbl_detalle_trabajr.Text
        Dim id_rollo_rec As Integer = obj_Ing_prodLn.consultar_valor(sql, "PRODUCCION") + 1

        lbl_rep_val_error.Visible = False
        sql = "INSERT INTO JB_rollos_rec (cod_orden_tref,id_detalle_tref,id_rollo_tref,cod_orden_rec,id_detalle_rec,id_rollo_rec,id_prof_final,peso,traccion_rec,traccion_tref,colada,diametro,clase) VALUES (" &
                "1,1,1," & lbl_orden_trabajr.Text & "," & lbl_detalle_trabajr.Text & "," & id_rollo_rec & "," & cbo_rep_mp.SelectedValue & "," & txt_rep_peso.Text & ",0," & txt_rep_trac_tref.Text & ",'" &
                txt_rep_colada.Text & "'," & txt_rep_diametro.Text & "," & cbo_rep_clase.Text & ")"
        If objOpSimplesLn.ejecutar(sql, "PRODUCCION") Then
            resp = True
        End If
        'Else
        'lbl_rep_val_error.Text = "No hay STOCK disponible."
        'lbl_rep_val_error.Visible = True
        'End If
        Return resp
    End Function

    Private Sub txt_rep_peso_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_rep_peso.KeyPress
        soloNumero(e)
    End Sub

    Private Sub btn_registrar_novedad_Click(sender As Object, e As EventArgs) Handles btn_registrar_novedad.Click
        If txt_registro_novedad.Text <> "" Then
            Dim sql As String = "SELECT novedades FROM JB_orden_prod_rec_detalle WHERE cod_orden = " & lbl_orden_trabajr.Text & " AND id_detalle = " & lbl_detalle_trabajr.Text
            Dim detalle As String = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION") & "(" & txt_registro_novedad.Text & "-" & Now & ")"
            sql = "UPDATE JB_orden_prod_rec_detalle SET novedades = '" & detalle & "' WHERE cod_orden = " & lbl_orden_trabajr.Text & " AND id_detalle = " & lbl_detalle_trabajr.Text
            If objOpSimplesLn.ejecutar(sql, "PRODUCCION") Then
                MessageBox.Show("La Novedad se Guardo Con exito", "Novedad Guardada", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txt_registro_novedad.Text = ""
            End If
        End If
    End Sub
    Private Sub btn_cerrar_planilla_Click(sender As Object, e As EventArgs) Handles btn_cerrar_planilla.Click
        If dtg_rollos_trabajr.Rows.Count <> 0 Then
            Dim resp As Integer = MessageBox.Show("¿Desea Cerrar la Planilla?", "Cerrar planilla", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
            If resp = 6 Then
                Dim validar_rollos As Boolean = False
                Dim listSql As New List(Of Object)
                Dim val As String = "SELECT top (1) f.mat_prima " &
                            " FROM JB_rollos_rec r, JB_orden_prod_rec_refs f " &
                            " WHERE ( r.id_prof_final = f.num AND r.cod_orden_rec = f.cod_orden)  " &
                            " AND r.cod_orden_rec = " & lbl_orden_trabajr.Text & " AND r.id_detalle_rec = " & lbl_detalle_trabajr.Text & " ORDER BY r.id_rollo_rec DESC"
                Dim obtenerval As String = objOpSimplesLn.consultValorTodo(val, "PRODUCCION")
                Dim sql_recocido As String = "Select count(id_rollo_rec) from jb_rollos_rec where cod_orden_rec=" & lbl_orden_trabajr.Text & " AND id_detalle_rec = " & lbl_detalle_trabajr.Text
                Dim total_recocido As Integer = objOpSimplesLn.consultValorTodo(sql_recocido, "PRODUCCION")
                Dim limite As Integer = obj_Ing_prodLn.consultar_valor("select limite from j_det_tref_limit", "PRODUCCION")
                If String.Equals(obtenerval, "22B100142") = True Or String.Equals(obtenerval, "22B100125") = True Then
                    If limite = total_recocido Then
                        validar_rollos = True
                    Else
                        validar_rollos = False
                    End If
                Else
                    validar_rollos = True
                End If
                If validar_rollos = True Then
                    listSql.AddRange(trans_srec(lbl_orden_trabajr.Text, lbl_detalle_trabajr.Text))
                    If listSql.Count > 0 Then
                        If obj_Ing_prodLn.ExecuteSqlTransaction(listSql, "CORSAN") Then
                            Dim Sql As String = "SELECT horas FROM JB_orden_prod_rec_horas "
                            Dim cant_horas As Integer = obj_Ing_prodLn.consultar_valor(Sql, "PRODUCCION")
                            Dim fecha As String = Now.Day & "-" & Now.Month & "-" & Now.Year & " " & Now.Hour + cant_horas & ":" & Now.Minute
                            MessageBox.Show("La planilla se cerro correctamente, podra imprimir los tiquetes el dia:" & fecha, "Cierre de planilla", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            lbl_detalle_trabajr.Text = ""
                            lbl_orden_trabajr.Text = ""
                            lbl_cc_trab.Text = ""
                            dtg_ref_reg_orden.DataSource = Nothing
                            dtg_rollos_trabajr.DataSource = Nothing
                            btn_ag_rollo.Enabled = False
                            txt_registro_novedad.Text = ""
                            group_novedades.Enabled = False
                            btn_cerrar_planilla.Enabled = False
                        Else
                            MessageBox.Show("Problema al realizar transaccion srec en el spic.", "Problema de transacción", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    Else
                        MessageBox.Show("La transacción Srec no se hizo.Comunicar a sistemas.", "Problema de transacción", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Else
                    MessageBox.Show("Tienes que registrar 60 rollos", "Registrar todos los rollos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            Else
                MessageBox.Show("No se a registrado ningun rollo.", "Registro de Rollos", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    'Modulo de impresion de tiquetes
    Private Sub cargar_detalles_imprimir()
        Dim sql As String = "SELECT d.cod_orden AS '#',d.id_detalle,m.Nombre AS horno,o.nombres AS op_cargue,d.fecha_cierre,d.fecha_fin,r.sw " &
                                " FROM JB_orden_prod_rec_detalle d, " & db_corsan & "V_nom_personal_Activo_con_maquila o, JB_orden_prod_rec r,J_Maquinas m " &
                                " WHERE (d.operario = o.nit AND d.cod_orden = r.cod_orden AND r.horno = m.codigoM) AND d.op_descargue IS NULL " &
                                " AND d.estado = 1 AND r.sw <= 2 ORDER BY m.Nombre"

        dtg_orden_imp.DataSource = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")
        dtg_orden_imp.Columns("horno").DefaultCellStyle = formatoNegrita()
        dtg_orden_imp.Columns("horno").Frozen = True
        dtg_orden_imp.Columns("#").Frozen = True
        dtg_orden_imp.Columns("sw").Visible = False
        dtg_orden_imp.Columns("fecha_fin").Visible = True
        For i = 0 To dtg_orden_imp.RowCount - 1
            Select Case dtg_orden_imp.Item("horno", i).Value
                Case "Horno-1"
                    dtg_orden_imp.Item("horno", i).Style.BackColor = Color.Violet
                Case "Horno-2"
                    dtg_orden_imp.Item("horno", i).Style.BackColor = Color.OrangeRed
                Case "Horno-3"
                    dtg_orden_imp.Item("horno", i).Style.BackColor = Color.Gold
                Case "Horno-4"
                    dtg_orden_imp.Item("horno", i).Style.BackColor = Color.LightSeaGreen
            End Select
            If dtg_orden_imp.Item("sw", i).Value = 1 Then
                dtg_orden_imp.Rows(i).DefaultCellStyle.BackColor = Color.LightGreen
            End If
        Next
        pintar_imprimir()
    End Sub
    Private Sub cbo_op_desc_SelectionChangeCommitted(sender As Object, e As EventArgs)
        'If cbo_op_desc.SelectedValue <> 0 Then
        '    dtg_orden_imp.DataSource = Nothing
        '    cargar_detalles_imprimir()
        '    dtg_rollos_desc.DataSource = Nothing
        '    txt_novedad_desc.Text = ""
        '    txt_traccion_desc.Text = ""
        'Else
        '    dtg_orden_imp.DataSource = Nothing
        '    Group_novedad_desc.Enabled = False
        '    btn_imprimir_tiq.Enabled = False
        '    lbl_orden_desc.Text = ""
        '    lbl_detalle_desc.Text = ""
        '    dtg_rollos_desc.DataSource = Nothing
        '    txt_novedad_desc.Text = ""
        '    txt_traccion_desc.Text = ""
        'End If
    End Sub

    Private Sub dtg_orden_imp_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtg_orden_imp.CellClick
        If (e.RowIndex >= 0) Then
            Dim col As String = dtg_orden_imp.Columns(e.ColumnIndex).Name
            Dim fec_c, turno As String
            fec_c = "" & System.DateTime.Now.Hour & ":" & System.DateTime.Now.Minute & ""

            If CDate(fec_c) >= "6:00" And CDate(fec_c) <= "14:00" Then
                turno = "1"
            ElseIf CDate(fec_c) >= "14:00" And CDate(fec_c) <= "22:00" Then
                turno = "2"
            ElseIf CDate(fec_c) >= "22:00" And CDate(fec_c) <= "6:00" Then
                turno = "3"
            End If
            cargar_novedad_cargue(dtg_orden_imp.Item("#", e.RowIndex).Value, dtg_orden_imp.Item("id_detalle", e.RowIndex).Value)
            If col = co_imp_t.Name Then
                Dim cc As String = InputBox("Ingrese su NUMERO DE DOCUMENTO DE IDENTIDAD.", "Documento de identidad.")
                If cc <> "" Then
                    If validar_cc(cc) Then
                        lbl_detalle_desc.Text = dtg_orden_imp.Item("id_detalle", e.RowIndex).Value
                        lbl_orden_desc.Text = dtg_orden_imp.Item("#", e.RowIndex).Value
#Disable Warning BC42104 ' La variable 'turno' se usa antes de que se le haya asignado un valor. Podría darse una excepción de referencia NULL en tiempo de ejecución.
                        objOpsimpesLn.ExecuteSqlTransactionTodo(objOrdenProdLn.crearPlanInspCalRec(lbl_orden_desc.Text, lbl_detalle_desc.Text, turno), "PRODUCCION")
#Enable Warning BC42104 ' La variable 'turno' se usa antes de que se le haya asignado un valor. Podría darse una excepción de referencia NULL en tiempo de ejecución.
                        cargarPlanInspRec()
                        dtg_rollos_desc.DataSource = Nothing
                        Group_novedad_desc.Enabled = True
                        btn_imprimir_tiq.Enabled = True
                        cargar_rollos_desc(lbl_orden_desc.Text, lbl_detalle_desc.Text)
                        lbl_cc_desc.Text = cc
                    End If
                End If
            End If
        End If
    End Sub
    Private Sub cargar_novedad_cargue(ByVal cod_orden As Integer, ByVal id_detalle As Integer)
        Dim sql As String = "SELECT novedades FROM JB_orden_prod_rec_detalle WHERE cod_orden=" & cod_orden & " AND id_detalle = " & id_detalle
        txt_novedad_carga.Text = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")
    End Sub
    Private Sub cargar_rollos_desc(ByVal cod_orden As String, ByVal id_detalle As String)
        Dim sql As String = "SELECT r.id_rollo_rec AS '#',r.peso,r.traccion_rec,f.mat_prima,f.prod_final  " &
                         " FROM JB_rollos_rec r, JB_orden_prod_rec_refs f " &
                         " WHERE ( r.id_prof_final = f.num AND r.cod_orden_rec = f.cod_orden)  " &
                         " AND r.cod_orden_rec = " & cod_orden & " AND r.id_detalle_rec = " & id_detalle & " ORDER BY r.id_rollo_rec DESC"
        dtg_rollos_desc.DataSource = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")
        For i = 0 To dtg_rollos_desc.RowCount - 1
            If dtg_rollos_desc.Item("prod_final", i).Value Like "22R2*" Or dtg_rollos_desc.Item("prod_final", i).Value Like "33R2*" Then
                dtg_rollos_desc.Rows(i).DefaultCellStyle.BackColor = Color.CornflowerBlue
            End If
            If dtg_rollos_desc.Item("prod_final", i).Value Like "22R1*" Or dtg_rollos_desc.Item("prod_final", i).Value Like "33R1*" Then
                If dtg_rollos_desc.Item("prod_final", i).Value Like "22R1Q*" Or dtg_rollos_desc.Item("prod_final", i).Value Like "33R1Q*" Then
                    dtg_rollos_desc.Rows(i).DefaultCellStyle.BackColor = Color.Gold
                Else
                    dtg_rollos_desc.Rows(i).DefaultCellStyle.BackColor = Color.HotPink
                End If
            End If
            If dtg_rollos_desc.Item("traccion_rec", i).Value = 0 Then
                dtg_rollos_desc.Item("traccion_rec", i).Style.BackColor = Color.Red
            End If
        Next
    End Sub
    Private Sub btn_novedad_desc_Click(sender As Object, e As EventArgs) Handles btn_novedad_desc.Click
        If txt_novedad_desc.Text <> "" Then
            Dim sql As String = "SELECT novedades FROM JB_orden_prod_rec_detalle WHERE cod_orden = " & lbl_orden_desc.Text & " AND id_detalle = " & lbl_detalle_desc.Text
            Dim detalle As String = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION") & "(" & txt_novedad_desc.Text & "-" & Now & ")"
            sql = "UPDATE JB_orden_prod_rec_detalle SET novedad_desc = '" & detalle & "' WHERE cod_orden = " & lbl_orden_desc.Text & " AND id_detalle = " & lbl_detalle_desc.Text
            If objOpSimplesLn.ejecutar(sql, "PRODUCCION") Then
                MessageBox.Show("La Novedad se Guardo Con exito", "Novedad Guardada", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txt_novedad_desc.Text = ""
            End If
        End If
    End Sub

    Private Sub dtg_rollos_desc_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtg_rollos_desc.CellClick
        If (e.RowIndex >= 0) Then
            Dim col As String = dtg_rollos_desc.Columns(e.ColumnIndex).Name
            If col = "traccion_rec" Then
                lbl_traccion_desc.Text = e.RowIndex
                dtg_rollos_desc.Enabled = False
                dtg_orden_imp.Enabled = False

                Group_novedad_desc.Enabled = False
                btn_imprimir_tiq.Enabled = False
                group_traccion.Enabled = True
                txt_traccion_desc.Focus()
            End If
        End If
    End Sub
    Private Sub txt_traccion_desc_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_traccion_desc.KeyPress
        soloNumero(e)
    End Sub

    Private Sub btn_guardar_trac_Click(sender As Object, e As EventArgs) Handles btn_guardar_trac.Click
        If txt_traccion_desc.Text <> "" Then
            guardar_traccion(lbl_traccion_desc.Text)
        Else
            MessageBox.Show("Debe digitar una traccion.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Private Sub guardar_traccion(ByVal rollo As Integer)
        Dim lisSql As New List(Of Object)
        Dim sql As String = ""
        For i = rollo To dtg_rollos_desc.RowCount - 1
            sql = "UPDATE JB_rollos_rec SET traccion_rec = " & txt_traccion_desc.Text & " WHERE cod_orden_rec = " & lbl_orden_desc.Text & " AND id_detalle_rec = " & lbl_detalle_desc.Text & " AND id_rollo_rec = " & dtg_rollos_desc.Item("#", i).Value
            lisSql.Add(sql)
        Next
        If obj_Ing_prodLn.ExecuteSqlTransaction(lisSql, "PRODUCCION") Then
            MessageBox.Show("Traccion ingresada con exito", "Traccion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            lbl_traccion_desc.Text = ""
            dtg_rollos_desc.Enabled = True
            dtg_orden_imp.Enabled = True
            Group_novedad_desc.Enabled = True
            btn_imprimir_tiq.Enabled = True
            group_traccion.Enabled = False
            txt_traccion_desc.Text = ""
            cargar_rollos_desc(lbl_orden_desc.Text, lbl_detalle_desc.Text)
        End If
    End Sub

    Private Function validar_traccion()
        Dim resp As Boolean = False
        Dim count As Integer = 0
        Dim count2 As Integer = 0
        For i = 0 To dtg_rollos_desc.RowCount - 1
            If dtg_rollos_desc.Item("traccion_rec", i).Value > 0 Then
                count += 1
            End If
            count2 += 1
        Next
        If count = count2 Then
            resp = True
        End If
        Return resp
    End Function

    Private Sub btn_imprimir_tiq_Click(sender As Object, e As EventArgs) Handles btn_imprimir_tiq.Click
        If validar_traccion() Then
            If validar_tiempos(lbl_orden_desc.Text, lbl_detalle_desc.Text) Then
                btn_imprimir_tiq.Enabled = False
                dtg_rollos_desc.Enabled = False
                dtg_orden_imp.Enabled = False
                btn_actualizar.Enabled = False
                Dim resp As Integer = MessageBox.Show("¿Desea Imprimir tiquetes?", "Imprimir Tiquetes planilla", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                If resp = 6 Then
                    If My.Computer.Network.IsAvailable Then
                        Dim sql As String
                        sql = "select cod_orden from JB_orden_prod_rec_detalle" &
                        " WHERE cod_orden = " & lbl_orden_desc.Text & " And id_detalle = " & lbl_detalle_desc.Text & " and estado = 4 and op_descargue is not null "

                        If objOpSimplesLn.consultValorTodo(sql, "PRODUCCION") = "" Then
                            transacciones()
                            'sql = "UPDATE j_rollos_tref SET no_conforme='S' FROM j_rollos_tref t join JB_ROLLOS_REC r on t.cod_orden=r.cod_orden_rec and t.id_detalle=r.id_detalle_rec and t.id_rollo=r.id_rollo_tref" &
                            '    " where r.no_conforme is not null and r.cod_orden_rec=" & lbl_orden_desc.Text & " and r.id_detalle_rec=" & lbl_detalle_desc.Text & ""
                            'objOpsimpesLn.ejecutar(sql, "PRODUCCION")
                        Else
                            MessageBox.Show("Esta planilla ya fue impresa", "Ya impresa", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    Else
                        MessageBox.Show("El computador no esta conectado a la red", "No Conectado", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Else
                    btn_imprimir_tiq.Enabled = True
                    dtg_rollos_desc.Enabled = True
                    dtg_orden_imp.Enabled = True
                    btn_actualizar.Enabled = True
                End If
            End If
        Else
            MessageBox.Show("Todos los Rollos deben tener Traccion.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Private Function validar_tiempos(ByVal cod_orden As Integer, ByVal id_detalle As Integer)
        Dim resp As Boolean = False
        Dim sql As String = "select fecha_fin from JB_orden_prod_rec_detalle where cod_orden = " & cod_orden & " and id_detalle = " & id_detalle
        Dim fecha_val As DateTime = Now.Year & "/" & Now.Month & "/" & Now.Day & " " & Now.Hour & ":" & Now.Minute & ":" & Now.Second
        Dim fecha_fin As DateTime = obj_Ing_prodLn.consultar_valor(sql, "PRODUCCION")
        If fecha_val >= fecha_fin Then
            resp = True
        Else
            MessageBox.Show("Podra imprimir los rollos despues de:" & fecha_fin, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Return resp
    End Function

    Private Sub transacciones()
        Dim bodega As Integer = 0
        Dim listSql As New List(Of Object)
        Dim dt As New DataTable

        Dim val2 As Integer = 0
        Dim val3 As Integer = 0
        Dim peso As Double = 0
        Dim codigo As String = ""

        Dim sql As String = "SELECT SUM(peso) AS cantidad, d.prod_final AS codigo FROM JB_rollos_rec r, JB_orden_prod_rec_refs d " &
                        " WHERE (r.id_prof_final = d.num AND r.cod_orden_rec = d.cod_orden) " &
                            " AND r.id_detalle_rec = " & lbl_detalle_desc.Text & " AND r.cod_orden_rec = " & lbl_orden_desc.Text &
                                " GROUP BY d.prod_final"
        dt = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")
        For i = 0 To dt.Rows.Count - 1
            If dt.Rows(i).Item("codigo") Like "2*" Then
                val2 += 1
            Else
                val3 += 1
            End If
        Next
        If val2 > 0 Then
            sql = "SELECT SUM(peso) AS cantidad, d.prod_final AS codigo FROM JB_rollos_rec r, JB_orden_prod_rec_refs d " &
                        " WHERE (r.id_prof_final = d.num AND r.cod_orden_rec = d.cod_orden) AND d.prod_final LIKE '2%' " &
                            " AND r.id_detalle_rec = " & lbl_detalle_desc.Text & " AND r.cod_orden_rec = " & lbl_orden_desc.Text &
                                " GROUP BY d.prod_final"
            Dim dt2 As DataTable = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")
            listSql.AddRange(transaccion(dt2, "EPPP", 2, "01", lbl_cc_desc.Text))
            sql = "SELECT r.cod_orden_rec,r.id_detalle_rec,r.id_rollo_rec " &
                        " FROM JB_rollos_rec r,JB_orden_prod_rec_refs d " &
                            " WHERE (r.id_prof_final = d.num AND r.cod_orden_rec = d.cod_orden) " &
                            " AND d.prod_final LIKE '2%' AND cod_orden_rec = " & lbl_orden_desc.Text & " AND r.id_detalle_rec = " & lbl_detalle_desc.Text
            Dim dt3 As DataTable = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")
            For i = 0 To dt3.Rows.Count - 1
                sql = "UPDATE " & db_produccion & "JB_rollos_rec SET trans = " & numero_transaccion & ", tipo_trans = 'EPPP' " &
                        " WHERE cod_orden_rec = " & dt3.Rows(i).Item("cod_orden_rec") & " AND id_detalle_rec = " & dt3.Rows(i).Item("id_detalle_rec") & " AND id_rollo_rec = " & dt3.Rows(i).Item("id_rollo_rec")
                listSql.Add(sql)
            Next
        End If
        If val3 > 0 Then
            sql = "SELECT SUM(peso) AS cantidad, d.prod_final AS codigo FROM JB_rollos_rec r, JB_orden_prod_rec_refs d " &
            " WHERE (r.id_prof_final = d.num AND r.cod_orden_rec = d.cod_orden) AND d.prod_final LIKE '3%' " &
                " AND r.id_detalle_rec = " & lbl_detalle_desc.Text & " AND r.cod_orden_rec = " & lbl_orden_desc.Text &
                    " GROUP BY d.prod_final"
            Dim dt2 As DataTable = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")
            For i = 0 To dt2.Rows.Count - 1
                peso += dt2.Rows(i).Item("cantidad")
                codigo = dt2.Rows(i).Item("codigo")
            Next
            listSql.AddRange(transaccion(dt2, "EPPT", 3, "01", lbl_cc_desc.Text))
            sql = "SELECT r.cod_orden_rec,r.id_detalle_rec,r.id_rollo_rec " &
            " FROM JB_rollos_rec r,JB_orden_prod_rec_refs d " &
                " WHERE (r.id_prof_final = d.num AND r.cod_orden_rec = d.cod_orden) " &
                " AND d.prod_final LIKE '3%' AND cod_orden_rec = " & lbl_orden_desc.Text & " AND r.id_detalle_rec = " & lbl_detalle_desc.Text
            Dim dt3 As DataTable = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")
            For i = 0 To dt3.Rows.Count - 1
                sql = "UPDATE " & db_produccion & "JB_rollos_rec SET trans = " & numero_transaccion & ", tipo_trans = 'EPPT' " &
                        " WHERE cod_orden_rec = " & dt3.Rows(i).Item("cod_orden_rec") & " AND id_detalle_rec = " & dt3.Rows(i).Item("id_detalle_rec") & " AND id_rollo_rec = " & dt3.Rows(i).Item("id_rollo_rec")
                listSql.Add(sql)
            Next
        End If
        sql = "UPDATE " & db_produccion & "JB_orden_prod_rec_detalle SET estado = 4,fecha_fin=getdate(),op_descargue=" & lbl_cc_desc.Text &
                    " WHERE cod_orden = " & lbl_orden_desc.Text & " And id_detalle = " & lbl_detalle_desc.Text
        listSql.Add(sql)
        If obj_Ing_prodLn.ExecuteSqlTransaction(listSql, "CORSAN") Then
            sql = "SELECT sw FROM JB_orden_prod_rec WHERE cod_orden =" & lbl_orden_desc.Text
            Dim sw As Integer = obj_Ing_prodLn.consultar_valor(sql, "PRODUCCION")
            consultar_datos_impresion(lbl_orden_desc.Text, lbl_detalle_desc.Text)
            MessageBox.Show("Los tiquetes se imprimieron correctamente.", "Impresion de tiquetes", MessageBoxButtons.OK, MessageBoxIcon.Information)
            If val3 > 0 Then
                If My.Computer.Network.Ping("www.google.com", 10) Then
                    enviarCorreoRecTransBod3(lbl_orden_desc.Text, lbl_detalle_desc.Text, numero_transaccion, peso, codigo)
                Else
                    MessageBox.Show("No hay internet por lo tanto no se enviara el correo.", "Enviar correo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
            txt_novedad_carga.Text = ""
            Group_novedad_desc.Enabled = False
            btn_imprimir_tiq.Enabled = False
            dtg_rollos_desc.DataSource = Nothing
            lbl_orden_desc.Text = ""
            lbl_detalle_desc.Text = ""
            cargar_detalles_imprimir()
            dtg_rollos_desc.Enabled = True
            dtg_orden_imp.Enabled = True
            btn_actualizar.Enabled = True
            lbl_cc_desc.Text = ""
        Else
            MessageBox.Show("No se hizo la transacción,comunicar al area de sistemas", "Transaccion no ejecutada", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Function trans_srec(ByVal cod_orden As Integer, ByVal id_detalle As Integer)
        Dim listSql As New List(Of Object)
        Dim dt As New DataTable
        Dim sql As String = ""
        Dim stock As Double = 0
        Dim peso As Double = 0
        Dim referencias As String = ""
        Dim val_stock As Integer = 0
        Dim val_stock2 As Integer = 0
        Dim var As String = ""
        Dim resp As Boolean = False
        sql = "SELECT horas FROM JB_orden_prod_rec_horas "
        Dim cant_horas As Integer = obj_Ing_prodLn.consultar_valor(sql, "PRODUCCION")

        sql = "SELECT sw FROM JB_orden_prod_rec WHERE cod_orden = " & cod_orden
        var = obj_Ing_prodLn.consultar_valor(sql, "PRODUCCION")
        sql = "SELECT SUM(s.peso) AS cantidad, d.mat_prima AS codigo FROM JB_rollos_rec r, JB_orden_prod_rec_refs d, j_rollos_tref s" &
                        " WHERE (r.id_prof_final = d.num AND r.cod_orden_rec = d.cod_orden AND s.cod_orden = r.cod_orden_tref and s.id_detalle = r.id_detalle_tref AND s.id_rollo = r.id_rollo_tref)  " &
                            " AND r.id_detalle_rec = " & id_detalle & " AND r.cod_orden_rec = " & cod_orden &
                                " GROUP BY d.mat_prima"
        If var = 1 Then
            sql = "SELECT SUM(r.peso) AS cantidad, d.mat_prima AS codigo FROM JB_rollos_rec r, JB_orden_prod_rec_refs d, j_rollos_tref s" &
                                " WHERE (r.id_prof_final = d.num AND r.cod_orden_rec = d.cod_orden AND s.cod_orden = r.cod_orden_tref and s.id_detalle = r.id_detalle_tref AND s.id_rollo = r.id_rollo_tref)  " &
                                    " AND r.id_detalle_rec = " & id_detalle & " AND r.cod_orden_rec = " & cod_orden &
                                        " GROUP BY d.mat_prima"
        End If
        dt = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")
        For i = 0 To dt.Rows.Count - 1
            stock = objOpSimplesLn.consultarStock(dt.Rows(i).Item("codigo"), 2)
            peso = dt.Rows(i).Item("cantidad")
            If peso <= stock Then
                val_stock += 1
            Else
                'referencias &= dt.Rows(i).Item("codigo") & ","
            End If
            val_stock2 += 1
        Next

        If val_stock = val_stock2 Then
            listSql.AddRange(transaccion(dt, "SREC", 2, "01", lbl_cc_trab.Text))
            sql = "UPDATE " & db_produccion & "JB_orden_prod_rec_detalle SET estado = 1, fecha_cierre=getdate(),fecha_fin = DATEADD(HH," & cant_horas & ",getdate()) WHERE cod_orden = " & cod_orden & " AND id_detalle = " & id_detalle
            resp = True
            listSql.Add(sql)
        Else
            MessageBox.Show("No hay stock en bodega 2 de alguna de las referencias", "No hay stock en bodega 2", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        If var <> "" And resp = True Then
            If var = 0 Or var = 2 Then
                sql = "SELECT cod_orden_tref,id_detalle_tref,id_rollo_tref " &
                            " FROM JB_rollos_rec " &
                                " WHERE cod_orden_rec = " & cod_orden & " AND id_detalle_rec = " & id_detalle
                Dim dt2 As New DataTable
                dt2 = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")
                For i = 0 To dt2.Rows.Count - 1
                    If dt.Rows(0).Item("codigo").ToString().ToUpper() = "22B100142" Or dt.Rows(0).Item("codigo").ToString().ToUpper() = "22B100125" Then
                        sql = "UPDATE " & db_produccion & "j_rollos_tref SET srec = '" & numero_transaccion & "' WHERE cod_orden = " & dt2.Rows(i).Item("cod_orden_tref") & " AND id_detalle = " & dt2.Rows(i).Item("id_detalle_tref") & " AND id_rollo = " & dt2.Rows(i).Item("id_rollo_tref")
                    Else
                        sql = "UPDATE " & db_produccion & "j_rollos_tref SET srec = '" & numero_transaccion & "',destino='R',traslado=1 WHERE cod_orden = " & dt2.Rows(i).Item("cod_orden_tref") & " AND id_detalle = " & dt2.Rows(i).Item("id_detalle_tref") & " AND id_rollo = " & dt2.Rows(i).Item("id_rollo_tref")
                    End If
                    listSql.Add(sql)
                Next
            End If
        End If
        Return listSql
    End Function
    'TRANSACCION EPPP AL IMPRIMIR UN ROLLO
    Private Function transaccion(ByVal datacodigo As DataTable, ByVal tipo As String, ByVal bodega As Integer, ByVal modelo As String, ByVal op As String) As List(Of Object)
        Dim listSql As New List(Of Object)
        Dim dFec As Date = Now
        Dim usuario As String = op
        Dim notas As String = "SPIC fecha:" & Now & ",usuario:" & usuario & ""
        numero_transaccion = objOrdenProdLn.mover_consecutivo(tipo)
        listSql = objTraslado_bodLn.listaTransaccionDatable(numero_transaccion, datacodigo, bodega, dFec, notas, usuario, tipo, modelo)
        Return listSql
    End Function
    Public Sub consultar_datos_impresion(ByVal cod_orden As Integer, ByVal id_detalle As Integer)
        db_produccion = objOpSimplesLn.get_nom_db("PRODUCCION") & ".dbo."
        db_corsan = objOpSimplesLn.get_nom_db("CORSAN") & ".dbo."
        Dim sql As String = "SELECT c.mat_prima,c.prod_final,s.descripcion,p.nombres AS Operario,r.diametro,r.clase,r.colada,r.traccion_tref,r.traccion_rec,r.peso,r.id_rollo_rec,h.nombres AS cliente " &
                            " FROM JB_rollos_rec r, JB_orden_prod_rec_refs c, JB_orden_prod_rec_detalle d," & db_corsan & "referencias s, " & db_corsan & "V_nom_personal_Activo_con_maquila p, CORSAN.dbo.terceros h " &
                            " WHERE (c.prod_final = s.codigo AND r.cod_orden_rec = c.cod_orden AND r.id_prof_final = c.num " &
                            " AND r.cod_orden_rec = d.cod_orden AND r.id_detalle_rec = d.id_detalle AND d.operario = p.nit AND h.nit = c.cliente) " &
                            " AND r.cod_orden_rec =" & cod_orden & " AND r.id_detalle_rec=" & id_detalle & " ORDER BY r.id_rollo_rec DESC"

        Dim dt As DataTable = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")
        For i = 0 To dt.Rows.Count - 1
            Dim consecutivo_barras As String = cod_orden & "-" & id_detalle & "-" & dt.Rows(i).Item("id_rollo_rec")
            Dim destino As String = ""

            If dt.Rows(i).Item("prod_final") Like "2*" Then
                destino = "CLIENTE: Interno"
            Else
                destino = "CLIENTE: Externo"
                If dt.Rows(i).Item("prod_final") Like "33R100142*" Then
                    destino = "CLIENTE: Externo"
                Else
                    destino = dt.Rows(i).Item("cliente")
                End If
            End If
            Dim prod_f As String = dt.Rows(i).Item("prod_final")
            imprimirTiquete(dt.Rows(i).Item("descripcion"), dt.Rows(i).Item("Operario"), dt.Rows(i).Item("prod_final"), dt.Rows(i).Item("clase"), dt.Rows(i).Item("diametro"), dt.Rows(i).Item("mat_prima"), dt.Rows(i).Item("colada"), dt.Rows(i).Item("traccion_tref"), dt.Rows(i).Item("traccion_rec"), dt.Rows(i).Item("peso"), Now, consecutivo_barras, destino)
            If prod_f.ToUpper Like "22*" Then
                Dim retrasoS As Integer
                retrasoS = 1800 + GetTickCount
                While retrasoS >= GetTickCount
                    Application.DoEvents()
                End While
                imprimirTiquete(dt.Rows(i).Item("descripcion"), dt.Rows(i).Item("Operario"), dt.Rows(i).Item("prod_final"), dt.Rows(i).Item("clase"), dt.Rows(i).Item("diametro"), dt.Rows(i).Item("mat_prima"), dt.Rows(i).Item("colada"), dt.Rows(i).Item("traccion_tref"), dt.Rows(i).Item("traccion_rec"), dt.Rows(i).Item("peso"), Now, consecutivo_barras, destino & "(COPIA)")
            End If
            Dim retraso As Integer
            retraso = 1800 + GetTickCount
            While retraso >= GetTickCount
                Application.DoEvents()
            End While
        Next
    End Sub

    Private Sub imprimirTiquete(ByVal nomb_pf As String, ByVal operario As String, ByVal prod_f As String, ByVal clase As String, ByVal diametro As String, ByVal materia_p As String,
                                ByVal colada As String, ByVal traccion As Integer, ByVal traccionr As Integer, ByVal pesoref As Double, ByVal fecha As Date, ByVal consecutivo_barras As String, ByVal destino As String)
        Dim proc As New Process
        modificarPlantilla(nomb_pf, operario, prod_f, clase, diametro, materia_p, colada, traccion, traccionr, pesoref, fecha, consecutivo_barras, destino)
        proc.StartInfo.FileName = Environment.CurrentDirectory & "\plantillaRecocidoImp.txt"
        proc.StartInfo.Verb = "Print"
        proc.StartInfo.CreateNoWindow = False
        proc.Start()
    End Sub

    Private Sub modificarPlantilla(ByVal nomb_pf As String, ByVal operario As String, ByVal prod_f As String, ByVal clase As String, ByVal diametro As String, ByVal materia_p As String,
                                   ByVal colada As String, ByVal traccion As Integer, ByVal traccionr As Integer, ByVal pesoref As Double, ByVal fecha As Date, ByVal consecutivo_barras As String, ByVal destino As String)
        Dim fic As String
        Dim nuevoFic As String
        fic = Environment.CurrentDirectory & "\plantillaRecocido.txt"
        nuevoFic = Environment.CurrentDirectory & "\plantillaRecocidoImp.txt"
        Dim pesoimp As Double = Format(pesoref, "#0.0")
        Dim sw As New System.IO.StreamWriter(nuevoFic)
        Dim texto As String
        Dim sr As New System.IO.StreamReader(fic)
        texto = sr.ReadToEnd()
        texto = Replace(texto, "@alambre", nomb_pf)
        texto = Replace(texto, "@operario", operario)
        texto = Replace(texto, "@ref", prod_f)
        texto = Replace(texto, "@clase", clase)
        texto = Replace(texto, "@diametro", diametro & "(mm)")
        texto = Replace(texto, "@mp", materia_p)
        texto = Replace(texto, "@colada", colada)
        texto = Replace(texto, "@traccionb", traccion)
        texto = Replace(texto, "@traccionr", traccionr)
        texto = Replace(texto, "@peso", pesoimp & "(Kg)")
        texto = Replace(texto, "@fecha", fecha)
        texto = Replace(texto, "@ordenr", consecutivo_barras)
        texto = Replace(texto, "@destino", destino)
        texto = Replace(texto, "@barras", consecutivo_barras)
        sr.Close()
        sw.WriteLine(texto)
        sw.Close()
    End Sub
    Private Sub txt_orden_filtro_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_orden_filtro.KeyPress
        soloNumero(e)
    End Sub
    Private Sub cargar_ordenes_control()
        Dim sql As String = "SELECT o.cod_orden AS '#',m.Nombre AS horno,o.cantidad,(SELECT SUM(PESO) FROM JB_rollos_rec z WHERE z.cod_orden_rec = o.cod_orden AND z.trans Is Not Null)  AS trabajdo, " &
                            "(SELECT COUNT(id_detalle) FROM JB_orden_prod_rec_detalle K WHERE K.cod_orden = o.cod_orden and k.estado = 0) AS AB," &
                            "(SELECT COUNT(id_detalle) FROM JB_orden_prod_rec_detalle K WHERE K.cod_orden = o.cod_orden and k.estado = 1) AS PR," &
                            "(SELECT COUNT(id_detalle) FROM JB_orden_prod_rec_detalle K WHERE K.cod_orden = o.cod_orden and k.estado = 4) AS TER," &
                            "o.mes,o.ano,o.sw,o.oculto,o.nota,o.cliente " &
                        " FROM JB_orden_prod_rec o, " & db_corsan & "terceros c, J_Maquinas m " &
                            " WHERE (o.cliente = c.nit AND o.horno = m.codigoM) AND o.sw < 3 "

        Dim whereSql As String = ""
        If txt_orden_filtro.Text <> "" Then
            whereSql &= " AND o.cod_orden = " & txt_orden_filtro.Text
        Else
            If cbo_horno_filtro.SelectedValue <> 0 Then
                whereSql &= " AND m.codigoM = " & cbo_horno_filtro.SelectedValue
            End If
        End If
        If txt_orden_filtro.Text = "" Then
            whereSql &= " AND mes = " & cbo_mes_filtro.SelectedValue & " AND ano = " & cbo_ano_filtro.Text
        End If

        sql &= whereSql & " ORDER BY m.Nombre"
        dtg_ordenes_control.DataSource = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")
        dtg_ordenes_control.Columns("horno").DefaultCellStyle = formatoNegrita()
        dtg_ordenes_control.Columns("horno").Frozen = True
        dtg_ordenes_control.Columns("#").Frozen = True
        dtg_ordenes_control.Columns("sw").Visible = False
        dtg_ordenes_control.Columns("cliente").Visible = False
        dtg_ordenes_control.Columns("oculto").Visible = False
        For i = 0 To dtg_ordenes_control.RowCount - 1
            Select Case dtg_ordenes_control.Item("horno", i).Value
                Case "Horno-1"
                    dtg_ordenes_control.Item("horno", i).Style.BackColor = Color.Violet
                Case "Horno-2"
                    dtg_ordenes_control.Item("horno", i).Style.BackColor = Color.OrangeRed
                Case "Horno-3"
                    dtg_ordenes_control.Item("horno", i).Style.BackColor = Color.Gold
                Case "Horno-4"
                    dtg_ordenes_control.Item("horno", i).Style.BackColor = Color.LightSeaGreen
            End Select


            If dtg_ordenes_control.Item("cliente", i).Value = 1 Then
                dtg_ordenes_control.Rows(i).DefaultCellStyle.BackColor = Color.PowderBlue
            End If
            If dtg_ordenes_control.Item("cliente", i).Value = 0 Then
                dtg_ordenes_control.Rows(i).DefaultCellStyle.BackColor = Color.Orange
            End If

            sql = "SELECT SUM(PESO) FROM JB_rollos_rec WHERE cod_orden_rec = " & dtg_ordenes_control.Item("#", i).Value
            Dim cantidad As Integer = obj_Ing_prodLn.consultar_valor(sql, "PRODUCCION")
            If dtg_ordenes_control.Item("cantidad", i).Value <= cantidad Then
                dtg_ordenes_control.Rows(i).DefaultCellStyle.BackColor = Color.Red
            End If

            If Not IsDBNull(dtg_ordenes_control.Item("oculto", i).Value) Then
                If (dtg_ordenes_control.Item("oculto", i).Value = 1) Then
                    dtg_ordenes_control.Item(col_ocultar.Name, i).Value = Spic.My.Resources.ok3
                End If
            End If
        Next
    End Sub
    Private Sub dtg_ordenes_control_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtg_ordenes_control.CellClick
        Dim col As String = dtg_ordenes_control.Columns(e.ColumnIndex).Name
        Dim fila As Integer = e.RowIndex
        If (col = col_ocultar.Name) Then
            If (MessageBox.Show("Esta seguro que desea ocultar o desocultar la ORDEN?", "ocultar Orden?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) = 6) Then
                Dim estado As Integer
                Dim accion As String = ""

                If Not IsDBNull(dtg_ordenes_control.Item("oculto", e.RowIndex).Value) Then
                    If (dtg_ordenes_control.Item("oculto", e.RowIndex).Value = 0) Then
                        accion = "ocultar"
                        estado = 1
                        dtg_ordenes_control.Item(col, e.RowIndex).Value = Spic.My.Resources.ok3
                        dtg_ordenes_control.Item("oculto", e.RowIndex).Value = estado
                    Else
                        accion = "desocultar"
                        estado = 0
                        dtg_ordenes_control.Item("oculto", e.RowIndex).Value = estado
                        dtg_ordenes_control.Item(col, e.RowIndex).Value = Spic.My.Resources.x
                    End If
                Else
                    accion = "ocultar"
                    estado = 1
                    dtg_ordenes_control.Item(col, e.RowIndex).Value = Spic.My.Resources.ok3
                    dtg_ordenes_control.Item("oculto", e.RowIndex).Value = estado
                End If
                Dim consecutivo As Integer = dtg_ordenes_control.Item("#", dtg_ordenes_control.CurrentCell.RowIndex).Value
                Dim nombre_usuario As String = usuario.usuario
                Dim sql As String = "UPDATE JB_orden_prod_rec SET oculto = " & estado & ",nota_aund +=  '" & accion & " " & nombre_usuario & " " & Now.Date & "' WHERE cod_orden = " & consecutivo
                If (objOpSimplesLn.ejecutar(sql, "PRODUCCION")) Then
                    MessageBox.Show("La orden se " & accion & " en forma exitosa!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Error al " & accion & " la orden, comuniquese con el administrador del sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        End If
    End Sub
    Private Sub cbo_prod_final_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbo_prod_final.SelectionChangeCommitted
        If cbo_prod_final.SelectedValue <> 0 Then
            txt_lector.Enabled = True
            txt_lector.Focus()
        Else
            txt_lector.Enabled = False
        End If
    End Sub
    Private Sub btn_actualiar_Click(sender As Object, e As EventArgs) Handles btn_actualiar.Click
        dtg_control_det.DataSource = Nothing

        cargar_ordenes_control()
    End Sub
    Private Sub btn_nueva_orden_Click(sender As Object, e As EventArgs) Handles btn_nueva_orden.Click
        tab_orden_rec.SelectedTab = pag_orden
    End Sub
    Private Sub btn_actualizar_Click(sender As Object, e As EventArgs) Handles btn_actualizar.Click
        dtg_orden_imp.DataSource = Nothing
        Group_novedad_desc.Enabled = False
        btn_imprimir_tiq.Enabled = False
        lbl_orden_desc.Text = ""
        lbl_detalle_desc.Text = ""
        dtg_rollos_desc.DataSource = Nothing
        txt_novedad_desc.Text = ""
        txt_traccion_desc.Text = ""
        cargar_detalles_imprimir()
        txt_novedad_carga.Text = ""
        lbl_cc_desc.Text = ""
    End Sub
    Private Sub cargar_detalles_abiertos()
        Dim sql As String = "SELECT d.cod_orden,d.id_detalle,m.Nombre AS horno,p.nombres AS operario " &
                            " FROM JB_orden_prod_rec_detalle d,jb_orden_prod_rec o, J_Maquinas m,CORSAN.dbo.V_nom_personal_Activo_con_maquila p " &
                            " WHERE (d.cod_orden = o.cod_orden AND o.horno = m.codigoM AND p.nit = d.operario) " &
                            " AND d.ESTADO = 0 ORDER BY m.nombre"
        dtg_detalles_abiertos.DataSource = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")
        For i = 0 To dtg_detalles_abiertos.RowCount - 1
            Select Case dtg_detalles_abiertos.Item("horno", i).Value
                Case "Horno-1"
                    dtg_detalles_abiertos.Item("horno", i).Style.BackColor = Color.Violet
                Case "Horno-2"
                    dtg_detalles_abiertos.Item("horno", i).Style.BackColor = Color.OrangeRed
                Case "Horno-3"
                    dtg_detalles_abiertos.Item("horno", i).Style.BackColor = Color.Gold
                Case "Horno-4"
                    dtg_detalles_abiertos.Item("horno", i).Style.BackColor = Color.LightSeaGreen
            End Select
        Next
    End Sub
    Private Sub btn_actualizar_detalles_ab_Click(sender As Object, e As EventArgs) Handles btn_actualizar_detalles_ab.Click
        dtg_detalles_abiertos.DataSource = Nothing
        cargar_detalles_abiertos()
    End Sub
    Private Sub dtg_detalles_abiertos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtg_detalles_abiertos.CellClick
        Dim col As String = dtg_detalles_abiertos.Columns(e.ColumnIndex).Name
        Dim fila As Integer = e.RowIndex
        Dim sql As String = ""
        Dim listSql As New List(Of Object)
        If (col = col_ver_det_ab.Name) Then
            Dim cod_orden As Integer = dtg_detalles_abiertos.Item("cod_orden", e.RowIndex).Value
            Dim id_detalle As Integer = dtg_detalles_abiertos.Item("id_detalle", e.RowIndex).Value
            sql = "SELECT r.id_rollo_rec AS '#',r.peso,r.traccion_rec AS trac,f.prod_final,r.cod_orden_rec,r.id_detalle_rec  " &
                         " FROM JB_rollos_rec r, JB_orden_prod_rec_refs f " &
                         " WHERE ( r.id_prof_final = f.num AND r.cod_orden_rec = f.cod_orden)  " &
                         " AND r.cod_orden_rec = " & cod_orden & " AND r.id_detalle_rec = " & id_detalle & " ORDER BY r.id_rollo_rec DESC"
            dtg_rollos_det_ab.DataSource = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")
            dtg_rollos_det_ab.Columns("id_detalle_rec").Visible = False
            dtg_rollos_det_ab.Columns("cod_orden_rec").Visible = False
            For i = 0 To dtg_rollos_det_ab.RowCount - 1
                If dtg_rollos_det_ab.Item("prod_final", i).Value Like "22R2*" Or dtg_rollos_det_ab.Item("prod_final", i).Value Like "33R2*" Then
                    dtg_rollos_det_ab.Rows(i).DefaultCellStyle.BackColor = Color.CornflowerBlue
                End If
                If dtg_rollos_det_ab.Item("prod_final", i).Value Like "22R1*" Or dtg_rollos_det_ab.Item("prod_final", i).Value Like "33R1*" Then
                    If dtg_rollos_det_ab.Item("prod_final", i).Value Like "22R1Q*" Or dtg_rollos_det_ab.Item("prod_final", i).Value Like "33R1Q*" Then
                        dtg_rollos_det_ab.Rows(i).DefaultCellStyle.BackColor = Color.Gold
                    Else
                        dtg_rollos_det_ab.Rows(i).DefaultCellStyle.BackColor = Color.HotPink
                    End If
                End If
            Next
        End If
        If (col = col_borrar_det_ab.Name) Then
            Dim resp As Integer = MessageBox.Show("¿Eliminar La Planilla?", "Eliminar Planilla", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
            If resp = 6 Then
                sql = "DELETE JB_orden_prod_rec_detalle WHERE cod_orden = " & dtg_detalles_abiertos.Item("cod_orden", e.RowIndex).Value & " AND id_detalle = " & dtg_detalles_abiertos.Item("id_detalle", e.RowIndex).Value
                listSql.Add(sql)
                sql = "DELETE JB_rollos_rec WHERE cod_orden_rec = " & dtg_detalles_abiertos.Item("cod_orden", e.RowIndex).Value & " AND id_detalle_rec = " & dtg_detalles_abiertos.Item("id_detalle", e.RowIndex).Value
                listSql.Add(sql)
                If objOpSimplesLn.ExecuteSqlTransactionTodo(listSql, "PRODUCCION") Then
                    MessageBox.Show("Planilla Borrada con Exito.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    dtg_detalles_abiertos.DataSource = Nothing
                    cargar_detalles_abiertos()
                End If
            End If
        End If
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        group_pendientes.Visible = False
        dtg_mp.Enabled = True
        btn_guardar_orden.Enabled = True
    End Sub


    Private Sub btn_tiq_manual_Click(sender As Object, e As EventArgs) Handles btn_tiq_manual.Click
        frm_tiq_manual_rec.ShowDialog()
    End Sub
    Dim cons_ms As Integer = 0
    Private Sub dtg_ordenes_control_MouseDown(sender As Object, e As MouseEventArgs) Handles dtg_ordenes_control.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            ms_orden_prod.Enabled = True
            If dtg_ordenes_control.Rows.Count > 0 Then
                With (Me.dtg_ordenes_control)
                    Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                    If Hitest.Type = DataGridViewHitTestType.Cell Then
                        .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                        cons_ms = Me.dtg_ordenes_control("#", Me.dtg_ordenes_control.CurrentRow.Index).Value
                    End If
                End With
            End If
        End If
    End Sub
    Private Sub VerListadoDeReferenciasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VerListadoDeReferenciasToolStripMenuItem.Click
        If cons_ms <> 0 Then
            frm_list_referencias_rec.main(cons_ms)
            frm_list_referencias_rec.ShowDialog()
        End If
    End Sub

    Private Sub VerListadoDePlanillasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VerListadoDePlanillasToolStripMenuItem.Click
        dtg_control_det.DataSource = Nothing
        If cons_ms <> 0 Then
            Dim sql As String = "SELECT  (convert(varchar,d.cod_orden) + '-' + convert(varchar,d.id_detalle)) AS '#', " &
                                " d.fecha_cierre AS fec_carga,p.nombres AS ope_carga,d.novedades AS nov_carga,d.fecha_fin AS fec_desc,p2.nombres AS op_descarga,d.novedad_desc AS nov_desc, " &
                                " (SELECT SUM(peso) FROM JB_rollos_rec z WHERE z.cod_orden_rec = d.cod_orden AND z.id_detalle_rec = d.id_detalle) AS cantidad " &
                                    " FROM JB_orden_prod_rec_detalle d, JB_orden_prod_rec o,CORSAN.dbo.V_nom_personal_Activo_con_maquila p,CORSAN.dbo.V_nom_personal_Activo_con_maquila p2 " &
                                        " WHERE (p.nit =d.operario AND d.cod_orden = o.cod_orden AND d.op_descargue = p2.nit) AND d.estado = 4 AND o.cod_orden =" & cons_ms &
                                            " ORDER BY d.id_detalle"
            dtg_control_det.DataSource = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")
        End If
    End Sub

    Private Sub AgregarNuevaReferenciaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AgregarNuevaReferenciaToolStripMenuItem.Click
        If cons_ms <> 0 Then
            Dim cliente As Integer = 0
            If (MessageBox.Show("Desea Registrar otra referencia en el horno?", "Agregar referencia?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) = 6) Then
                lbl_orden.Text = cons_ms
                Dim sql As String = "SELECT r.num,r.mat_prima,d.descripcion AS mp,r.prod_final,d2.descripcion AS pf,r.cantidad,r.cliente " &
                                        " FROM JB_orden_prod_rec_refs r, CORSAN.dbo.referencias d, CORSAN.dbo.referencias d2 " &
                                            " WHERE (r.mat_prima = d.codigo AND r.prod_final = d2.codigo) " &
                                                " AND r.cod_orden=" & cons_ms & " ORDER BY r.num"
                Dim dt As DataTable = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")
                Dim s As Integer = 1
                sql = "SELECT cliente FROM JB_orden_prod_rec WHERE cod_orden = " & cons_ms
                cliente = obj_Ing_prodLn.consultar_valor(sql, "PRODUCCION")
                For i = 0 To dt.Rows.Count - 1
                    s += 1
                Next

                sql = "SELECT MAX(num) FROM JB_orden_prod_rec_refs WHERE cod_orden=" & cons_ms
                s = obj_Ing_prodLn.consultar_valor(sql, "PRODUCCION") + 1
                ocultar_info()
                If cliente = 1 Then
                    chk_interno.Checked = True
                Else
                    chk_interno.Checked = False
                End If
                dtg_mp.Rows.Add()
                dtg_mp.Item(ColNumDet.Name, 0).Value = s
                dtg_mp.Rows.RemoveAt(1)
                tab_orden_rec.SelectedTab = pag_orden
            End If

        End If
    End Sub
    Private Sub enviarCorreoRecTransBod3(ByVal cod_orden As String, ByVal id_detalle As String, ByVal transaccion As String, ByVal peso As Double, ByVal codigo As String)
        Dim sql_admin As String = "SELECT mail,Mail_login  FROM Jjv_usuarios WHERE usuario = 'ADMIN' "
        Dim dt_admin As DataTable = objOpsimpesLn.listar_datatable(sql_admin, "CORSAN")
        Dim mail As String = "diego.vargas@corsan.com.co"
        Dim asunto As String = "Producto de Recocido para bodega 3 , código:" & codigo & "; Termino"
        Dim cuerpo As String = "Número de la orden : " & cod_orden & " - detalle : " & id_detalle & vbCrLf &
                                "Transaccion : " & transaccion & " " & vbCrLf &
                                "Tipo trans :  EPPT" & vbCrLf &
                               "Peso : " & peso & " " & vbCrLf &
                               "Código : " & codigo & " " & vbCrLf &
                                                           "Fecha: " & Now
        Dim mailEnvia As String = dt_admin.Rows(0).Item("mail")
        Dim mailEnviaPass As String = dt_admin.Rows(0).Item("Mail_login")
        obj_correoLn.EnviarCorreo(mail, cuerpo, asunto, "", mailEnvia, mailEnviaPass, False)
        mail = "jairo.marquez@corsan.com.co"
        obj_correoLn.EnviarCorreo(mail, cuerpo, asunto, "", mailEnvia, mailEnviaPass, False)
        mail = "david.hincapie@corsan.com.co"
        obj_correoLn.EnviarCorreo(mail, cuerpo, asunto, "", mailEnvia, mailEnviaPass, False)
    End Sub
    Private Sub pintar_imprimir()
        For Each row As DataGridViewRow In dtg_orden_imp.Rows
            If row.Cells.Item("fecha_fin").Value <= Now Then
                row.DataGridView.Rows(row.Index).DefaultCellStyle.BackColor = Color.Salmon
            End If
            If row.Index = (dtg_orden_imp.Rows.Count - 1) Then
                Exit For
            End If
        Next
    End Sub
    Private Sub IngresarMantenimientoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IngresarMantenimientoToolStripMenuItem.Click
        Dim frm As New Frm_Mantenimiento_Planta
        frm.Show()
    End Sub
    Private Sub cargarPlanInspRec()
        dtg_plan_rec.DataSource = objOrdenProdLn.cargarPlanInspCalRec(lbl_orden_desc.Text, lbl_detalle_desc.Text)
        dtg_plan_rec.Columns("cod_detalle").Visible = False
        dtg_plan_rec.Columns("cod_orden").Visible = False
        dtg_plan_rec.Columns("id_hora").Visible = False
        dtg_plan_rec.Columns("hora").ReadOnly = True
    End Sub
    Private Sub dtg_plan_rec_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dtg_plan_rec.CellValueChanged
        Dim col As String = dtg_plan_rec.Columns(e.ColumnIndex).Name
        Dim sql As String = ""
        Dim valor As String = ""
        Dim cod_orden As String = ""
        Dim cod_detalle As String = ""
        Dim id_hora As String = ""
        Dim validar As Boolean = True
        If (col <> "hora") Then
            valor = dtg_plan_rec.Item(col, e.RowIndex).Value.ToString
            If (valor <> "") Then
                If (col = "resistencia") Then
                    If (IsNumeric(valor)) Then
                        validar = True
                    Else
                        validar = False
                        dtg_plan_rec.Item(col, e.RowIndex).Value = ""
                        MessageBox.Show("Verifique que el valor ingresado sea númerico", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If
            End If

            If (validar) Then
                cod_orden = dtg_plan_rec.Item("cod_orden", e.RowIndex).Value
                cod_detalle = dtg_plan_rec.Item("cod_detalle", e.RowIndex).Value
                id_hora = dtg_plan_rec.Item("id_hora", e.RowIndex).Value
                sql = "UPDATE J_plan_insp_cal SET " & col & " = '" & valor & "' WHERE cod_orden = " & cod_orden & " AND cod_detalle = " & cod_detalle & " AND id_hora = " & id_hora
                objOpsimpesLn.ejecutar(sql, "PRODUCCION")
            End If
        End If
    End Sub
End Class