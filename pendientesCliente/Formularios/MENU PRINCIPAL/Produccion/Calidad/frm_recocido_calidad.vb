Imports logicaNegocios
Imports entidadNegocios
Public Class frm_recocido_calidad
    Dim usuario As UsuarioEn
    Private objOpSimplesLn As New Op_simpesLn
    Private obj_Ing_prodLn As New Ing_prodLn
    Dim detalle As Integer = 0
    Private objOperacionesForm As OperacionesFormularios = New OperacionesFormularios

    Public Sub main(ByVal usuario As UsuarioEn)
        Me.usuario = usuario
    End Sub

    Private Sub cargar_ordenes()
        Dim sql As String = "SELECT r.consecutivo, r.ano, r.mes, r.cliente, t.nombres, r.materia_prima, x.descripcion as mp, r.prod_final, z.descripcion as pf, r.cant_programada, r.nota, r.oculto" & _
                                " FROM J_orden_prod_rec r, CORSAN.dbo.terceros t, CORSAN.dbo.referencias x,  CORSAN.dbo.referencias z" & _
                                        " WHERE (r.cliente = t.nit AND r.materia_prima = x.codigo AND r.prod_final = z.codigo) AND cliente <> '890900160'"
        Dim whereSql As String = ""
        Dim dt As DataTable

        Dim sqlKilos As String
        Dim dtKilos As DataTable
        Dim sum As Integer
        If txt_orden.Text <> "" Then
            whereSql &= " AND r.consecutivo = " & txt_orden.Text
        Else
            If txt_cliente.Text <> "" Then
                whereSql &= " AND r.cliente = '" & txt_cliente.Text & "'"
            End If
            If txt_codigo.Text <> "" Then
                whereSql &= " AND r.prod_final = '" & txt_codigo.Text & "'"
            End If
            whereSql &= " AND r.ano = " & cbo_ano_filtro.Text
            whereSql &= " AND r.mes = " & cbo_mes_filtro.SelectedValue
        End If
    
        sql &= whereSql
        dt = objOpSimplesLn.crearDataTableVariasCol(sql, "PRODUCCION")
        dtg_orden_prod.DataSource = dt
        dtg_orden_prod.Columns("oculto").Visible = False
        For i = 0 To dtg_orden_prod.RowCount - 1
            If dtg_orden_prod.Item("consecutivo", i).Value <> "" Then
                sqlKilos = "SELECT peso FROM J_orden_prod_rec_rollo WHERE no_conforme Is Null AND orden_prod_rec = " & dtg_orden_prod.Item("consecutivo", i).Value
                dtKilos = objOpSimplesLn.listar_datatable(sqlKilos, "PRODUCCION")

                For j = 0 To dtKilos.Columns.Count - 1
                    If (dtKilos.Columns(j).ColumnName = "peso") Then
                        For h = 0 To dtKilos.Rows.Count - 1
                            If Not IsDBNull(dtKilos.Rows(h).Item(j)) Then
                                sum += dtKilos.Rows(h).Item(j)
                            End If
                        Next
                    End If
                Next
                If Not (IsDBNull(dtg_orden_prod.Item("cant_programada", i).Value) Or IsDBNull(sum)) Then
                    If (sum >= dtg_orden_prod.Item("cant_programada", i).Value) Then
                        dtg_orden_prod.Rows(i).DefaultCellStyle.BackColor = Color.Gold
                    End If
                End If
                sum = 0
            End If
        Next
    End Sub

    Private Sub btn_consultar_Click(sender As Object, e As EventArgs) Handles btn_consultar.Click
        dtg_orden_prod.DataSource = Nothing
        cargar_ordenes()
      
    End Sub

    Private Sub frm_recocido_calidad_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For i = Now.Year - 1 To Now.Year + 1
            cbo_ano_filtro.Items.Add(i)
            cbo_ano_op.Items.Add(i)
        Next
        cbo_ano_filtro.Text = Now.Year
        cbo_ano_op.Text = Now.Year

        cbo_mes_filtro.DataSource = objOpSimplesLn.returnDtMeses()
        cbo_mes_filtro.ValueMember = "numMes"
        cbo_mes_filtro.DisplayMember = "nombMes"
        cbo_mes_filtro.SelectedValue = Now.Month

        cbo_mes_op.DataSource = objOpSimplesLn.returnDtMeses()
        cbo_mes_op.ValueMember = "numMes"
        cbo_mes_op.DisplayMember = "nombMes"
        cbo_mes_op.SelectedValue = Now.Month


        Dim dt As New DataTable
        Dim sql As String

        'CBO del operario
        sql = "SELECT nit,nombres FROM V_nom_personal_Activo_con_maquila WHERE centro = 4100  order by nombres"
        dt = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        dt.Rows.Add()
        dt.Rows(dt.Rows.Count - 1).Item("nit") = 0
        dt.Rows(dt.Rows.Count - 1).Item("nombres") = "Seleccione"
        cbo_operario.DataSource = dt
        cbo_operario.ValueMember = "nit"
        cbo_operario.DisplayMember = "nombres"
        cbo_operario.SelectedValue = 0

        'CBO del operario
        sql = "SELECT Id_defecto,D_defecto FROM J_desperdicios_defecto WHERE id_defecto in (1,4,5,8,9,10,25,26,38,39,40,46,47,51)"
        dt = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")
        dt.Rows.Add()
        dt.Rows(dt.Rows.Count - 1).Item("Id_defecto") = 0
        dt.Rows(dt.Rows.Count - 1).Item("D_defecto") = "Seleccione"
        cbo_defecto.DataSource = dt
        cbo_defecto.ValueMember = "Id_defecto"
        cbo_defecto.DisplayMember = "D_defecto"
        cbo_defecto.SelectedValue = 0
    End Sub
    
    Private Sub txt_cliente_Click(sender As Object, e As EventArgs) Handles txt_cliente.Click
        cargarCliente()
        txtnitB.Text = ""
        txtClienteB.Text = ""
        group_filtro.Enabled = False
        dtg_orden_prod.Enabled = False
    End Sub
    Private Sub cargarCliente()
        Dim dt As New DataTable
        Dim sql As String = "SELECT nit,nombres,codigo,descripcion,Cant_pedida,Pendiente " & _
                                    "FROM J_v_pendientes_por_vendedor_id_cor " & _
                                    "WHERE (codigo like '33R%')"
        GroupClientes.Visible = True
        dt = objOpSimplesLn.crearDataTableVariasCol(sql, "CORSAN")
        dgt_cliente.DataSource = dt
    End Sub

    Private Sub filtro(ByVal nit As String, ByVal nombre As String)
        Dim where_sql As String = ""
        If (nit <> "") Then
            where_sql &= " nit like '%" & nit & "%' "
        ElseIf (nombre <> "") Then
            where_sql &= " nombres like '%" & nombre & "%'"
        End If
        Dim sql As String = "SELECT nit,nombres,codigo,descripcion,Cant_pedida,Pendiente " & _
                                    "FROM J_v_pendientes_por_vendedor_id_cor " & _
                                    "WHERE " & where_sql & " AND (codigo like '33R%')"
        dgt_cliente.DataSource = objOpSimplesLn.listar_datatable(sql, "CORSAN")
    End Sub
    Private Sub txtnitB_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtnitB.TextChanged
        If (txtnitB.Text.Length > 2) Then
            filtro(txtnitB.Text, "")
        End If
    End Sub

    Private Sub txtClienteB_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtClienteB.TextChanged
        If (txtClienteB.Text.Length > 2) Then
            filtro("", txtClienteB.Text)
        End If
    End Sub
    Private Sub btn_cerrar_clientes_Click(sender As Object, e As EventArgs) Handles btn_cerrar_clientes.Click
        group_filtro.Enabled = True
        dtg_orden_prod.Enabled = True
        GroupClientes.Visible = False
    End Sub

    Private Sub dgt_cliente_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgt_cliente.CellContentClick
        Dim fila As Integer = e.RowIndex
        Dim col As String = dgt_cliente.Columns(e.ColumnIndex).Name
        If (fila >= 0) Then
            If (col = "brnSelectCli") Then
                txt_cliente.Text = dgt_cliente.Item("nit", fila).Value
                group_filtro.Enabled = True
                dtg_orden_prod.Enabled = True
                GroupClientes.Visible = False
            End If
        End If
    End Sub

    Private Sub dtg_orden_prod_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtg_orden_prod.CellClick
        Dim fila As Integer = e.RowIndex
        Dim col As String = dtg_orden_prod.Columns(e.ColumnIndex).Name
        If (fila >= 0) Then
            If (col = "col_ver") Then
                cargar_detalle(dtg_orden_prod.Item("consecutivo", fila).Value)

                txt_consecutivo.Text = dtg_orden_prod.Item("consecutivo", fila).Value
                txt_nombre_cliente.Text = dtg_orden_prod.Item("nombres", fila).Value
                txt_prod_final.Text = dtg_orden_prod.Item("prod_final", fila).Value
                txt_nombre_prod.Text = dtg_orden_prod.Item("pf", fila).Value
                txt_cantidad.Text = dtg_orden_prod.Item("cant_programada", fila).Value

                tbl_calidad_rec.SelectedTab = p_detalle
                dtg_detall_orden.Enabled = True
                dtg_rollo_orden.Enabled = True
                group_opciones.Enabled = True
            End If
        End If
    End Sub
    Private Sub cargar_detalle(ByVal consecutivo As Integer)
        Dim sql As String = "SELECT o.id_detalle,o.operario, p.nombres, o.horno, m.Descripción, o.base, o.nro_ciclos,(c.nombre + '-(' + convert(varchar, c.tiempo) + '-Horas)') AS Ciclo, o.revisado " & _
                                        " FROM J_orden_prod_rec_detalle o, CORSAN.dbo.V_nom_personal_Activo_con_maquila p, J_Maquinas m, J_rec_ciclos c " & _
                                            " WHERE (o.operario = p.nit AND o.horno = m.codigoM AND o.nro_ciclos = c.id) AND o.estado <> 0 AND o.nro_orden = " & consecutivo & " ORDER BY o.id_detalle"
        Dim dt As DataTable = objOpSimplesLn.crearDataTableVariasCol(sql, "PRODUCCION")

        dtg_detall_orden.DataSource = dt
        dtg_detall_orden.Columns("operario").Visible = False
        dtg_detall_orden.Columns("horno").Visible = False
        dtg_detall_orden.Columns("nro_ciclos").Visible = False
        dtg_detall_orden.Columns("revisado").Visible = False
        For i = 0 To dtg_detall_orden.RowCount - 1
            If Not (IsDBNull(dtg_detall_orden.Item("revisado", i).Value)) Then
                dtg_detall_orden.Rows(i).DefaultCellStyle.BackColor = Color.DeepSkyBlue
            End If
        Next
    End Sub

    Private Sub dtg_detall_orden_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtg_detall_orden.CellClick
        Dim fila As Integer = e.RowIndex
        Dim col As String = dtg_detall_orden.Columns(e.ColumnIndex).Name
        If (fila >= 0) Then
            If (col = "col_rollos") Then
                detalle = dtg_detall_orden.Item("id_detalle", fila).Value
                lbl_detalle.Text = detalle
                cargar_rollos()
            End If
        End If
    End Sub
    Private Sub cargar_rollos()
        Dim sql As String = " SELECT z.orden_prod_rec AS Orden,z.id_detalle AS Detalle ,z.id_rollo_rec AS '#', z.peso, z.traccion_rec AS Trac,z.no_conforme, z.revisado  " & _
                 " FROM J_rollos_tref r, J_orden_prod_tef o , J_orden_prod_rec_rollo z " & _
                     " WHERE(r.cod_orden = o.consecutivo And r.cod_orden = z.cod_orden_tref And r.id_rollo = z.id_rollo_tref And r.id_detalle = z.id_detalle_tref) " & _
                          " AND z.id_detalle = " & detalle & " AND z.orden_prod_rec = " & txt_consecutivo.Text & " ORDER BY z.id_rollo_rec DESC"

        Dim dt As DataTable = objOpSimplesLn.crearDataTableVariasCol(sql, "PRODUCCION")
        dtg_rollo_orden.DataSource = dt
        dtg_rollo_orden.Columns("no_conforme").Visible = False
        dtg_rollo_orden.Columns("revisado").Visible = False
        For i = 0 To dtg_rollo_orden.RowCount - 1
            If Not (IsDBNull(dtg_rollo_orden.Item("revisado", i).Value)) Then
                If Not (IsDBNull(dtg_rollo_orden.Item("no_conforme", i).Value)) Then
                    dtg_rollo_orden.Rows(i).DefaultCellStyle.BackColor = Color.Red
                Else
                    dtg_rollo_orden.Rows(i).DefaultCellStyle.BackColor = Color.LimeGreen
                End If
            End If
        Next
        btn_registrar_rollo.Enabled = True
        btn_bache_conforme.Enabled = True
    End Sub

    Private Sub btn_registrar_rollo_Click(sender As Object, e As EventArgs) Handles btn_registrar_rollo.Click
        Dim sql As String = "SELECT revisado FROM J_orden_prod_rec_detalle WHERE id_detalle = " & lbl_detalle.Text & _
                                " AND nro_orden = " & txt_consecutivo.Text
        Dim dato As Integer = 0
        dato = obj_Ing_prodLn.consultar_valor(sql, "PRODUCCION")
        If dato <> 0 Then
            MessageBox.Show("El detalle Ya a sido Revisado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            group_no_conforme.Visible = True
            group_opciones.Enabled = False
            dtg_rollo_orden.Enabled = False
            dtg_detall_orden.Enabled = False

        End If
    End Sub

    Private Sub btn_bache_conforme_Click(sender As Object, e As EventArgs) Handles btn_bache_conforme.Click
        Dim sql As String = "SELECT revisado FROM J_orden_prod_rec_detalle WHERE id_detalle = " & lbl_detalle.Text & _
                               " AND nro_orden = " & txt_consecutivo.Text
        Dim dato As Integer = 0
        dato = obj_Ing_prodLn.consultar_valor(sql, "PRODUCCION")
        If dato <> 0 Then
            MessageBox.Show("El detalle Ya a sido Revisado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            Dim resp As Integer = MessageBox.Show("Desea registrar el detalle como conforme?", "Registrar Detalle", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
            If resp = 6 Then
                detalle_conforme()
            End If
        End If
    End Sub
    Private Sub detalle_conforme()
        Dim sql As String = "UPDATE J_orden_prod_rec_detalle SET revisado = 1 WHERE id_detalle = " & lbl_detalle.Text & _
                                " AND nro_orden = " & txt_consecutivo.Text
        Dim listSql As New List(Of Object)
        listSql.Add(sql)
        sql = "UPDATE J_orden_prod_rec_rollo SET revisado = 1 WHERE id_detalle = " & lbl_detalle.Text & _
                " AND orden_prod_rec = " & txt_consecutivo.Text
        listSql.Add(sql)
        If obj_Ing_prodLn.ExecuteSqlTransaction(listSql, "PRODUCCION") Then
            MessageBox.Show("El detalle se Registro con exito.", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cargar_rollos()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        group_no_conforme.Visible = False
        group_opciones.Enabled = True
        dtg_rollo_orden.Enabled = True
        dtg_detall_orden.Enabled = True

        cbo_operario.Enabled = False
        cbo_defecto.Enabled = False
        txt_nota.Enabled = False
        Btn_registrar_rollo_nc.Enabled = False
        lbl_codigo.Text = "N"
        lbl_peso.Text = "N"
        lbl_nombre.Text = "N"
        cbo_defecto.SelectedValue = 0
        cbo_operario.SelectedValue = 0
        txt_nota.Text = ""
    End Sub

    Private Sub btn_consultar_nC_Click(sender As Object, e As EventArgs) Handles btn_consultar_nC.Click
        Dim sql As String = "SELECT r.orden_prod_rec,r.id_detalle,r.id_rollo_rec,o.cliente,cli.nombres AS Nombre_cliente,o.mes,o.ano,m.materia_prima AS alambron,o.materia_prima,o.prod_final,x.descripcion,r.peso,r.traccion_rec, t.colada,n.Nombre,d.base, " & _
                             " (c.nombre + '-(' + convert(varchar, c.tiempo) + '-Horas)') AS ciclo,d.operario, op.nombres,nc.fecha  AS fecha_rechazo,de.D_defecto,opc.nombres AS Op_calidad,nc.nota " & _
                             " FROM J_orden_prod_rec_rollo r, J_orden_prod_rec o, J_orden_prod_rec_detalle d, CORSAN.dbo.referencias x, J_rollos_tref t, J_orden_prod_tef m,J_Maquinas n, " & _
                             " J_rec_ciclos c, CORSAN.dbo.V_nom_personal_Activo_con_maquila op, J_orden_prod_rec_rollos_no_conforme nc,J_desperdicios_defecto de,CORSAN.dbo.V_nom_personal_Activo_con_maquila opc,CORSAN.dbo.terceros cli " & _
                             " WHERE (r.orden_prod_rec = o.consecutivo AND r.orden_prod_rec = d.nro_orden AND r.id_detalle = d.id_detalle AND o.prod_final = x.codigo " & _
                             "	AND r.cod_orden_tref = t.cod_orden AND r.id_detalle_tref = t.id_detalle AND r.id_rollo_tref = t.id_rollo " & _
                             "	AND t.cod_orden = m.consecutivo AND d.horno = n.codigoM AND d.nro_ciclos = c.id AND d.operario = op.nit " & _
                             "	AND r.orden_prod_rec = nc.orden_prod AND r.id_detalle = nc.id_detalle AND r.id_rollo_rec = nc.id_rollo " & _
                            "	AND nc.defecto = de.Id_defecto AND nc.operario_calidad = opc.nit AND o.cliente = cli.nit) " & _
                            " AND r.no_conforme IS NOT NULL AND o.mes = " & cbo_mes_op.SelectedValue & " AND o.ano = " & cbo_ano_op.Text
        Dim dt As DataTable = objOpSimplesLn.crearDataTableVariasCol(sql, "PRODUCCION")
        dtg_consulta.DataSource = dt
    End Sub

    Private Sub txt_lecto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_lecto.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            txt_lecto.Text = Replace(txt_lecto.Text, "'", "-")
            Dim obj_gestion_materia_primaLn As New Gestion_materia_primaLn
            Dim codOrden As String = obj_gestion_materia_primaLn.extraerDatoCodigoBarras("num_consecutivo", txt_lecto.Text)
            Dim idDetalle As String = obj_gestion_materia_primaLn.extraerDatoCodigoBarras("detalle", txt_lecto.Text)
            Dim idRollo As String = obj_gestion_materia_primaLn.extraerDatoCodigoBarras("id_rollo", txt_lecto.Text)
            Dim sql As String = ""

            If codOrden = txt_consecutivo.Text Then
                If idDetalle = lbl_detalle.Text Then
                    sql = "SELECT no_conforme FROM J_orden_prod_rec_rollo " & _
                                " WHERE orden_prod_rec = " & codOrden & " AND id_detalle =" & idDetalle & " AND id_rollo_rec =" & idRollo
                    Dim rev As String = ""
                    rev = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")

                    If rev <> "" Then
                        MessageBox.Show("El Rollo ya esta registrado como no conforme", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Else
                        sql = "SELECT r.peso,o.prod_final,d.descripcion FROM J_orden_prod_rec_rollo r, J_orden_prod_rec o, CORSAN.dbo.referencias d" & _
                                 " WHERE (r.orden_prod_rec = o.consecutivo AND o.prod_final = d.codigo ) " & _
                                    " AND r.orden_prod_rec = " & codOrden & " AND r.id_detalle =" & idDetalle & " AND r.id_rollo_rec =" & idRollo
                        Dim dt As DataTable = objOpSimplesLn.crearDataTableVariasCol(sql, "PRODUCCION")
                        For i = 0 To dt.Rows.Count - 1
                            lbl_peso.Text = dt.Rows(i).Item("peso")
                            lbl_codigo.Text = dt.Rows(i).Item("prod_final")
                            lbl_nombre.Text = dt.Rows(i).Item("descripcion")
                        Next
                        cbo_operario.Enabled = True
                        cbo_defecto.Enabled = True
                        txt_nota.Enabled = True
                        Btn_registrar_rollo_nc.Enabled = True
                    End If
                Else
                    MessageBox.Show("El Rollo no pertenece al detalle: " & lbl_detalle.Text, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                MessageBox.Show("El Rollo no pertenece a La orden de produccion: " & txt_consecutivo.Text, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txt_lecto.Text = ""
            End If


        End If
    End Sub
    Private Sub txt_lecto_Enter(sender As Object, e As EventArgs) Handles txt_lecto.Enter
        txt_lecto.BackColor = Color.Green
        txt_lecto.Text = ""
    End Sub
    Private Sub txt_lecto_Leave(sender As Object, e As EventArgs) Handles txt_lecto.Leave
        txt_lecto.BackColor = Color.Red
    End Sub
    Private Sub marcar_rollo()
        Dim obj_gestion_materia_primaLn As New Gestion_materia_primaLn
        Dim codOrden As String = obj_gestion_materia_primaLn.extraerDatoCodigoBarras("num_consecutivo", txt_lecto.Text)
        Dim idDetalle As String = obj_gestion_materia_primaLn.extraerDatoCodigoBarras("detalle", txt_lecto.Text)
        Dim idRollo As String = obj_gestion_materia_primaLn.extraerDatoCodigoBarras("id_rollo", txt_lecto.Text)

        Dim listSql As New List(Of Object)
        Dim sql As String = "INSERT INTO J_orden_prod_rec_rollos_no_conforme (orden_prod,id_detalle,id_rollo,defecto,operario_calidad,nota,fecha) " & _
                                " VALUES (" & codOrden & "," & idDetalle & "," & idRollo & ",'" & cbo_defecto.SelectedValue & _
                                    "','" & cbo_operario.SelectedValue & "','" & txt_nota.Text & "',GETDATE())"
        listSql.Add(sql)
        sql = "UPDATE J_orden_prod_rec_rollo SET revisado = 1, no_conforme = 1 WHERE id_detalle = " & idDetalle & _
               " AND orden_prod_rec = " & codOrden & " AND id_rollo_rec =" & idRollo
        listSql.Add(sql)
        If obj_Ing_prodLn.ExecuteSqlTransaction(listSql, "PRODUCCION") Then
            MessageBox.Show("El detalle se Registro con exito.", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information)
            group_no_conforme.Visible = False
            group_opciones.Enabled = True
            dtg_rollo_orden.Enabled = True
            dtg_detall_orden.Enabled = True

            cbo_operario.Enabled = False
            cbo_defecto.Enabled = False
            txt_nota.Enabled = False
            Btn_registrar_rollo_nc.Enabled = False
            lbl_codigo.Text = "N"
            lbl_peso.Text = "N"
            lbl_nombre.Text = "N"
            cbo_defecto.SelectedValue = 0
            cbo_operario.SelectedValue = 0
            txt_nota.Text = ""
            cargar_rollos()
        Else
            MessageBox.Show("Error al realizar la operacion, Comuniquese con el administrador del sistema.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub Btn_registrar_rollo_nc_Click(sender As Object, e As EventArgs) Handles Btn_registrar_rollo_nc.Click
        If cbo_defecto.SelectedValue <> 0 Then
            If cbo_operario.SelectedValue <> 0 Then
                If txt_nota.Text <> "" Then
                    marcar_rollo()
                Else
                    MessageBox.Show("Debe ingresar una nota.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                MessageBox.Show("Debe seleccionar un Operario.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            MessageBox.Show("Debe Seleccionar un defecto.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btn_excel_Click(sender As Object, e As EventArgs) Handles btn_excel.Click
        objOperacionesForm.ExportarDatosExcel(dtg_consulta, "Informe de Alambre Recocido rechazado del mes: " & cbo_mes_op.Text)
    End Sub
End Class