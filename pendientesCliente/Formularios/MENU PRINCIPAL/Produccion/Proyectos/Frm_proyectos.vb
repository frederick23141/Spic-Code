Imports logicaNegocios
Imports entidadNegocios
Public Class Frm_proyectos
    Private obj_op_simplesLn As New Op_simpesLn
    Private obj_Ing_prodLn As New Ing_prodLn
    Private objOperacionesForm As New OperacionesFormularios
    Private dtg_select As String = ""
    Private total_ejecutado As Double = 0
    Dim usuario As UsuarioEn
    Dim permiso As String = ""

    Private Sub Frm_proyectos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cbo_fec_ini.Value = Now.Date
        cbo_fec_fin.Value = Now.Date
        Dim sql As String = ""
        Dim dt As New DataTable
        sql = "SELECT centro,( CAST (centro AS varchar(25))+ '-' + descripcion )As descripcion " &
                     "FROM centros " &
                        "WHERE centro >1099"
        dt = obj_op_simplesLn.listar_datatable(sql, "CORSAN")
        dt.Rows.Add()
        dt.Rows(dt.Rows.Count - 1).Item("centro") = 0
        dt.Rows(dt.Rows.Count - 1).Item("descripcion") = "Seleccione"
        cbo_centro.DataSource = dt
        cbo_centro.ValueMember = "centro"
        cbo_centro.DisplayMember = "descripcion"
        cbo_centro.SelectedValue = 0

        dtg_ppto.Rows.Add()
    End Sub
    Public Sub MAIN(ByVal usuario As UsuarioEn, ByVal id_proyecto As Integer, ByVal fec_ini As Date, ByVal fec_fin As Date)
        Me.usuario = usuario
        If usuario.permiso.Trim <> "ADMIN" Then
            col_borrar.Visible = False
            col_nota_au.Visible = False
        End If
        If id_proyecto <> 0 Then
            tab_ppal.Enabled = True
            tab_ppal.SelectedTab = tab_gastos
            txt_id_proyecto.Text = id_proyecto
            cargar_proyecto(id_proyecto)
            cargar_presupuesto(id_proyecto)
            cargar_gastos(id_proyecto)
            dtg_orden_compra.DataSource = cargar_ordenes("O", cbo_centro.SelectedValue)
            dtg_orden_servicio.DataSource = cargar_ordenes("S", cbo_centro.SelectedValue)
            dtg_orden_compra.Columns("fecha_solicitud").DefaultCellStyle.Format = "d"
            dtg_orden_servicio.Columns("fecha_solicitud").DefaultCellStyle.Format = "d"
            cbo_fec_ini.Value = fec_ini
            cbo_fec_fin.Value = fec_fin

            btn_guardar.Visible = False
            btn_guardar.Enabled = False
            cbo_centro.Enabled = False
            txt_titulo.Enabled = False
            txt_justificacion.Enabled = False
            cbo_fec_ini.Enabled = False
            cbo_fec_fin.Enabled = False
        End If
    End Sub
    Private Sub cargar_proyecto(ByVal id_proyecto As Integer)
        Dim sql As String = "SELECT  p.titulo ,p.centro ,p.justificacion ,p.fec_ini,p.fec_fin " &
                                " FROM j_proyectos p " &
                                    "WHERE id_proyecto =" & id_proyecto
        Dim dt As DataTable = obj_op_simplesLn.listar_datatable(sql, "PRODUCCION")
        For i = 0 To dt.Rows.Count - 1
            txt_titulo.Text = dt.Rows(i).Item("titulo")
            txt_justificacion.Text = dt.Rows(i).Item("justificacion")
            cbo_fec_ini.Value = dt.Rows(i).Item("fec_ini")
            cbo_fec_fin.Value = dt.Rows(i).Item("fec_fin")
            cbo_centro.SelectedValue = dt.Rows(i).Item("centro")
        Next
    End Sub
    Private Sub btn_guardar_Click(sender As Object, e As EventArgs) Handles btn_guardar.Click
        If validar() Then
            guardar()
        End If
    End Sub
    Private Function validar() As Boolean
        If txt_titulo.Text <> "" Then
            If txt_justificacion.Text <> "" Then
                If cbo_centro.SelectedValue <> 0 Then
                    Return True
                Else
                    MessageBox.Show("Seleccione un centro de costos", "Seleccione un centro de costos", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                MessageBox.Show("Ingrese una justificación para el proyecto", "Ingrese justificación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            MessageBox.Show("Ingrese un titulo para el proyecto", "Ingrese titulo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Return False
    End Function
    Private Sub guardar()
        Dim sql As String = ""
        Dim fec_ini As String = obj_op_simplesLn.cambiarFormatoFecha(cbo_fec_ini.Value)
        Dim fec_fin As String = obj_op_simplesLn.cambiarFormatoFecha(cbo_fec_fin.Value)
        Dim listSql As New List(Of Object)
        Dim id_proyecto As Integer = 0
        Dim titulo As String = txt_titulo.Text
        Dim justificacion As String = txt_justificacion.Text
        Dim centro As String = cbo_centro.SelectedValue
        If txt_id_proyecto.Text <> "" Then
            id_proyecto = txt_id_proyecto.Text
            sql = "DELETE FROM J_proyectos_item_gasto WHERE id_proyecto = " & id_proyecto
            listSql.Add(sql)
            sql = "DELETE FROM J_proyectos_items WHERE id_proyecto = " & id_proyecto
            listSql.Add(sql)
            sql = "DELETE FROM j_proyectos WHERE id_proyecto = " & id_proyecto
            listSql.Add(sql)
        Else
            id_proyecto = obj_op_simplesLn.consultValorTodo("SELECT (SELECT CASE WHEN MAX(id_proyecto) IS NULL THEN 1 ELSE MAX(id_proyecto) + 1 END) FROM j_proyectos", "PRODUCCION")
        End If
        txt_id_proyecto.Text = id_proyecto
        sql = "INSERT INTO j_proyectos (id_proyecto,titulo,justificacion,centro,fec_ini,fec_fin) " &
                       "VALUES (" & id_proyecto & ",'" & titulo & "','" & justificacion & "'," & centro & ",'" & fec_ini & "','" & fec_fin & "')"
        listSql.Add(sql)
        listSql.AddRange(guardar_ppto(id_proyecto))
        If obj_Ing_prodLn.ExecuteSqlTransaction(listSql, "PRODUCCION") Then
            txt_id_proyecto.Text = id_proyecto
            cargar_proyecto(id_proyecto)
            cargar_presupuesto(id_proyecto)
            cargar_gastos(id_proyecto)
            MessageBox.Show("El proyecto se ingreso en forma correcta", "Proyecto guardado", MessageBoxButtons.OK, MessageBoxIcon.Information)
            group_add_item.Visible = True

            btn_guardar.Visible = False
            btn_guardar.Enabled = False
            cbo_centro.Enabled = False
            txt_titulo.Enabled = False
            txt_justificacion.Enabled = False
            cbo_fec_ini.Enabled = False
            cbo_fec_fin.Enabled = False
            tab_ppal.Enabled = True
            btn_cerrar_anadir.Visible = False
        Else
            MessageBox.Show("El proyecto no fue guardado,comuniquese con el administrador del sistema", "Error al guardar", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Private Function guardar_ppto(ByVal id_proyecto As Integer) As List(Of Object)
        Dim listSql As New List(Of Object)
        Dim sql_ppal As String = "INSERT INTO J_proyectos_items (id_proyecto,id_item,descripcion,ppto) VALUES(" & id_proyecto & ","
        Dim sql As String = ""
        Dim id As Integer = 0
        For i = 0 To dtg_ppto.RowCount - 1
            If IsNumeric(dtg_ppto.Item(col_ppto.Name, i).Value) Then
                If IsNumeric(dtg_ppto.Item(col_id.Name, i).Value) Then
                    id = dtg_ppto.Item(col_id.Name, i).Value
                ElseIf id = 0 Then
                    id = obj_op_simplesLn.consultValorTodo("SELECT (SELECT CASE WHEN MAX(id_proyecto) IS NULL THEN 1 ELSE MAX(id_proyecto) + 1 END) FROM J_proyectos_items WHERE id_proyecto = " & id_proyecto, "PRODUCCION")
                Else
                    id += 1
                End If
                dtg_ppto.Item(col_id.Name, i).Value = id
                sql = sql_ppal & dtg_ppto.Item(col_id.Name, i).Value & ",'" & dtg_ppto.Item(col_descripcion.Name, i).Value & "'," & dtg_ppto.Item(col_ppto.Name, i).Value & ")"
                listSql.Add(sql)
            End If
        Next
        Return listSql
    End Function
    Private Sub btn_nuevo_Click(sender As Object, e As EventArgs) Handles btn_nuevo.Click
        nuevo()
    End Sub
    Private Sub nuevo()
        txt_titulo.Text = ""
        txt_justificacion.Text = ""
        cbo_centro.SelectedValue = 0
        dtg_orden_compra.DataSource = Nothing
        dtg_orden_servicio.DataSource = Nothing
        dtg_ppto.DataSource = Nothing
        dtg_saldos.DataSource = Nothing
        dtg_accesorios.DataSource = Nothing
        dtg_ppto.Rows.Clear()
        dtg_ppto.Rows.Add()
        txt_val_ejecutado.Text = ""
        txt_id_proyecto.Text = ""
        total_ejecutado = 0
        txt_ppto_item.Text = ""
        txt_val_ppto.Text = ""
        txt_tot_compra_pend.Text = ""
        txt_tot_serv_pend.Text = ""
        cbo_fec_ini.Value = Now
        cbo_fec_fin.Value = Now
        tab_ppal.Enabled = False


        btn_guardar.Visible = True
        btn_guardar.Enabled = True
        cbo_centro.Enabled = True
        txt_titulo.Enabled = True
        txt_justificacion.Enabled = True
        cbo_fec_ini.Enabled = True
        cbo_fec_fin.Enabled = True
    End Sub
    Private Sub dtg_ppto_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtg_ppto.CellClick
        Dim listSql As New List(Of Object)
        Dim sql As String = ""
        Dim id_proyecto As Integer = txt_id_proyecto.Text
        If (e.RowIndex >= 0) Then
            Dim col As String = dtg_ppto.Columns(e.ColumnIndex).Name
            If (col = col_borrar.Name) Then
                sql = "DELETE J_proyectos_item_gasto WHERE id_item = " & dtg_ppto.Item("col_id", e.RowIndex).Value & " AND id_proyecto =" & id_proyecto
                listSql.Add(sql)
                sql = "DELETE J_proyectos_items WHERE id_item = " & dtg_ppto.Item("col_id", e.RowIndex).Value & " AND id_proyecto =" & id_proyecto
                listSql.Add(sql)
                If obj_Ing_prodLn.ExecuteSqlTransaction(listSql, "PRODUCCION") Then
                    'dtg_ppto.Rows.RemoveAt(e.RowIndex)

                    cargar_proyecto(id_proyecto)
                    cargar_presupuesto(id_proyecto)
                    cargar_gastos(id_proyecto)
                    totalizar_ppto()
                End If
            ElseIf (col = col_add.Name) Then
                group_add_item.Visible = True
                btn_cerrar_anadir.Visible = True
            ElseIf (col = col_edit.Name) Then
                lbl_id_item.Text = dtg_ppto.Item("col_id", e.RowIndex).Value
                group_editar_fecha.Visible = True
                dtg_ppto.Enabled = False
            End If
        End If
    End Sub
    Private Sub txt_ppto_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txt_ppto_item.KeyPress
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
    Private Sub btn_agregar_Click(sender As Object, e As EventArgs) Handles btn_agregar.Click
        Dim listSql As New List(Of Object)
        Dim id As Integer = 0
        Dim id_proyecto As Integer = txt_id_proyecto.Text
        Dim sql As String = ""
        Dim val_id As String = ""

        If txt_desc_item.Text <> "" Then
            If txt_ppto_item.Text <> "" Then


                sql = "SELECT MAX(id_item) FROM J_proyectos_items WHERE id_proyecto = " & id_proyecto
                val_id = obj_op_simplesLn.consultValorTodo(sql, "PRODUCCION")
                If val_id <> "" Then
                    id = obj_op_simplesLn.consultValorTodo(sql, "PRODUCCION")
                    id += 1
                Else
                    id = 1
                End If


                Dim fec_ini As String = obj_op_simplesLn.cambiarFormatoFecha(cbo_ini_item.Value)
                Dim fec_fin As String = obj_op_simplesLn.cambiarFormatoFecha(cbo_fin_item.Value)


                sql = "INSERT INTO J_proyectos_items (id_proyecto,id_item,descripcion,ppto,fecha_ini,fecha_fin,nota_audi) VALUES (" & _
                        id_proyecto & "," & id & ",'" & txt_desc_item.Text & "'," & txt_ppto_item.Text & ",'" & fec_ini & "','" & fec_fin & "','Primera fecha final establecida:" & fec_fin & ";')"
                listSql.Add(sql)
                If obj_Ing_prodLn.ExecuteSqlTransaction(listSql, "PRODUCCION") Then
                    cargar_proyecto(id_proyecto)
                    cargar_presupuesto(id_proyecto)
                    cargar_gastos(id_proyecto)
                    'dtg_ppto.Rows.Add()
                    'dtg_ppto.Item(col_descripcion.Name, dtg_ppto.Rows.Count - 1).Value = txt_desc_item.Text
                    'dtg_ppto.Item(col_ppto.Name, dtg_ppto.Rows.Count - 1).Value = Convert.ToDouble(txt_ppto_item.Text)

                    group_add_item.Visible = False

                    txt_desc_item.Text = ""
                    txt_ppto_item.Text = ""
                    totalizar_ppto()
                End If

            Else
                MessageBox.Show("Ingrese un presupuesto", "Ingrese presupuesto", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            MessageBox.Show("Ingrese una descripción", "Ingrese descripción", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
    Private Sub cargar_gastos(ByVal id_proyecto As Double)
        txt_val_ejecutado.Text = ""
        total_ejecutado = 0
        Dim sql As String = "SELECT m.tipo,m.numero,m.seq,m.cuenta,c.descripcion,m.nit,t.nombres,m.fec,m.valor As total,m.explicacion,((SELECT id_item FROM PRGPRODUCCION.dbo.J_proyectos_item_gasto WHERE id_proyecto = " & id_proyecto & "  AND tipo = m.tipo AND numero = m.numero AND seq = m.seq)) AS item " &
                                 "FROM movimiento m , terceros t , cuentas c " &
                                    "WHERE c.cuenta = m.cuenta AND t.nit = m.nit AND m.centro =" & cbo_centro.SelectedValue
        Dim dt As DataTable = obj_op_simplesLn.listar_datatable(sql, "CORSAN")
        totalizarDt(dt)
        dtg_saldos.DataSource = dt
        dtg_saldos.Columns("fec").DefaultCellStyle.Format = "d"

        dt = New DataTable
        'sql = "SELECT d.tipo,d.numero,l.seq,d.fecha,l.codigo ,r.descripcion,l.costo_unitario,l.cantidad,l.costo_unitario * l.cantidad  As total,((SELECT id_item FROM PRGPRODUCCION.dbo.J_proyectos_item_gasto WHERE id_proyecto =  " & id_proyecto & "  AND tipo = l.tipo AND numero = l.numero  AND seq = l.seq)) AS item " &
        '            "FROM documentos d , documentos_lin l , referencias r  " &
        '                 "WHERE r.codigo = l.codigo AND l.numero = d.numero AND l.tipo = d.tipo AND d.centro_doc = " & cbo_centro.SelectedValue

        sql = "SELECT d.tipo,d.numero,l.seq,d.fecha,l.codigo ,r.descripcion,l.costo_unitario,l.cantidad,l.costo_unitario * l.cantidad  As total " & _
                    " FROM documentos d , documentos_lin l , referencias r " & _
                        " WHERE d.centro_doc = '" & cbo_centro.SelectedValue & "' and r.codigo = l.codigo AND l.numero = d.numero AND l.tipo = d.tipo"
        dt = obj_op_simplesLn.listar_datatable(sql, "CORSAN")
        Dim dt2 As New DataTable
        sql = "SELECT id_item,tipo,numero,seq FROM PRGPRODUCCION.dbo.J_proyectos_item_gasto " & _
                    " WHERE id_proyecto = " & id_proyecto
        dt2 = obj_op_simplesLn.listar_datatable(sql, "CORSAN")
        dt.Columns.Add("item", GetType(Integer))
        For i = 0 To dt2.Rows.Count - 1
            For j = 0 To dt.Rows.Count - 1
                If dt2.Rows(i).Item("tipo") = dt.Rows(j).Item("tipo") And dt2.Rows(i).Item("numero") = dt.Rows(j).Item("numero") And dt2.Rows(i).Item("seq") = dt.Rows(j).Item("seq") Then
                    dt.Rows(j).Item("item") = dt2.Rows(i).Item("id_item")
                End If
            Next
        Next
        totalizarDt(dt)
        dtg_accesorios.DataSource = dt
        dtg_accesorios.Columns("fecha").DefaultCellStyle.Format = "d"
        For i = 0 To dtg_accesorios.RowCount - 1
            If Not IsDBNull(dtg_accesorios.Item("item", i).Value) Then
                dtg_accesorios.Rows(i).DefaultCellStyle.BackColor = Color.DarkOrange
            End If
        Next
        For i = 0 To dtg_saldos.RowCount - 1
            If Not IsDBNull(dtg_saldos.Item("item", i).Value) Then
                dtg_saldos.Rows(i).DefaultCellStyle.BackColor = Color.DarkOrange
            End If
        Next
    End Sub
    Private Function totalizarDt(ByRef dt As DataTable) As DataTable
        Dim sum As Double = 0
        dt.Rows.Add()
        For i = 0 To dt.Columns.Count - 1
            If (dt.Columns(i).ColumnName = "total" Or dt.Columns(i).ColumnName = "vr_total") Then
                For j = 0 To dt.Rows.Count - 2
                    If Not IsDBNull(dt.Rows(j).Item(i)) Then
                        sum += dt.Rows(j).Item(i)
                    End If
                Next
                dt.Rows(dt.Rows.Count - 1).Item(i) = sum
                If (dt.Columns(i).ColumnName = "total") Then
                    total_ejecutado += sum
                    txt_val_ejecutado.Text = total_ejecutado.ToString("C0")
                    sum = 0
                End If
            End If
        Next
        Return dt
    End Function
    Private Function cargar_ordenes(ByVal tipo As String, ByVal centro As Integer) As DataTable
        Dim sql As String = "SELECT  E.terminado,E.numero,E.numero_fact,SUM(D.cantidad_aut * D.precio_unit )As vr_total,E.solicitante,P.nombres As nom_responsable,E.observaciones As contenido,E.fecha_solicitud,E.centro, E.obserAlmacen As observaciones_alamcen,E.observaciones As observaciones_orden " &
                              "From J_solicitud_compra_det D , J_solicitud_compra_enc E , CORSAN.dbo.V_nom_personal_Activo_con_maquila P " &
                                 "Where E.numero = D.numero And E.responsable = P.nit And E.d_orden = '" & tipo & "'  AND E.anulado is null AND E.centro =" & centro & " " &
                                    "GROUP BY E.numero,E.solicitante,P.nombres,E.fecha_solicitud,E.centro,E.recive,e.fecha_recive,E.fecha_aut ,E.responsable,E.autoriza,E.observaciones,E.obserAlmacen ,E.terminado,E.pedido_realizado,E.autorizado,E.numero_fact,E.contabilizado " &
                                         "ORDER BY E.numero"
        Dim dt As DataTable = obj_op_simplesLn.listar_datatable(sql, "PRODUCCION")
        Dim total_pend As Double = 0
        For i = 0 To dt.Rows.Count - 1
            If Not IsNumeric(dt.Rows(i).Item("terminado")) Then
                If IsNumeric(dt.Rows(i).Item("vr_total")) Then
                    total_pend += dt.Rows(i).Item("vr_total")
                End If
            End If
        Next
        If tipo = "O" Then
            txt_tot_compra_pend.Text = total_pend.ToString("C0")
        Else
            txt_tot_serv_pend.Text = total_pend.ToString("C0")
        End If
        addContenido(dt)
        totalizarDt(dt)
        Return dt
    End Function
    Private Function addContenido(ByRef dt As DataTable) As DataTable
        Dim sql As String = ""
        Dim valor As String = ""
        For i = 0 To dt.Rows.Count - 1
            sql = "DECLARE @valores VARCHAR(MAX) " &
                    "SELECT @valores = COALESCE( @valores + ' " & vbCrLf & "', '') + descripcion_solicitante + ' -> ' + CAST(cantidad AS varchar(25))   FROM J_solicitud_compra_det where numero = " & dt.Rows(i).Item("numero") & " " &
                    "SELECT @valores as valores"
            valor = obj_op_simplesLn.consultValorTodo(sql, "PRODUCCION")
            dt.Rows(i).Item("contenido") = valor
        Next
        Return dt
    End Function
    Private Sub cargar_presupuesto(ByVal id_proyecto As Integer)
        dtg_ppto.Rows.Clear()
        Dim sql As String = "SELECT id_item,descripcion,ppto,fecha_ini,fecha_fin,nota_audi " &
                              "FROM J_proyectos_items " &
                                 "WHERE id_proyecto=" & id_proyecto
        Dim dt As DataTable = obj_op_simplesLn.listar_datatable(sql, "PRODUCCION")
        For i = 0 To dt.Rows.Count - 1

            dtg_ppto.Rows.Add()
            dtg_ppto.Item(col_id.Name, dtg_ppto.Rows.Count - 1).Value = dt.Rows(i).Item("id_item")
            dtg_ppto.Item(col_descripcion.Name, dtg_ppto.Rows.Count - 1).Value = dt.Rows(i).Item("descripcion")
            dtg_ppto.Item(col_ppto.Name, dtg_ppto.Rows.Count - 1).Value = dt.Rows(i).Item("ppto")

            dtg_ppto.Item(col_fec_fin.Name, dtg_ppto.Rows.Count - 1).Value = dt.Rows(i).Item("fecha_fin")
            dtg_ppto.Item(col_fec_ini.Name, dtg_ppto.Rows.Count - 1).Value = dt.Rows(i).Item("fecha_ini")
            dtg_ppto.Item(col_nota_au.Name, dtg_ppto.Rows.Count - 1).Value = dt.Rows(i).Item("nota_audi")

            dtg_ppto.Item(col_ejecutado.Name, dtg_ppto.Rows.Count - 1).Value = 0
        Next
        Dim sql_gastos As String = "SELECT i.id_item,SUM(m.valor)As valor  " &
                "FROM J_proyectos_item_gasto i , CORSAN.dbo.movimiento m " &
                    "WHERE  i.seq = m.seq AND i.id_proyecto = " & id_proyecto & " AND m.tipo = i.tipo AND m.numero = i.numero AND m.centro = " & cbo_centro.SelectedValue & " " &
                        "GROUP BY i.id_item "
        Dim dt_gastos As DataTable = obj_op_simplesLn.listar_datatable(sql_gastos, "PRODUCCION")
        For i = 0 To dt_gastos.Rows.Count - 1
            For k = 0 To dtg_ppto.Rows.Count - 1
                If IsNumeric(dtg_ppto.Item(col_id.Name, k).Value) Then
                    If dtg_ppto.Item(col_id.Name, k).Value = dt_gastos.Rows(i).Item("id_item") Then
                        If IsNumeric(dtg_ppto.Item(col_ejecutado.Name, k).Value) Then
                            dtg_ppto.Item(col_ejecutado.Name, k).Value += dt_gastos.Rows(i).Item("valor")
                        Else
                            dtg_ppto.Item(col_ejecutado.Name, k).Value = dt_gastos.Rows(i).Item("valor")
                        End If
                        dtg_ppto.Item(col_diferencia.Name, k).Value = dtg_ppto.Item(col_ppto.Name, k).Value - dtg_ppto.Item(col_ejecutado.Name, k).Value
                    End If
                End If
            Next
        Next
        Dim sql_accesorios As String = "SELECT  i.id_item, l.cantidad * l.costo_unitario As valor " &
                                            "FROM documentos d , documentos_lin l ,  PRGPRODUCCION.dbo.J_proyectos_item_gasto i  " &
                                                 "WHERE  i.id_proyecto = " & id_proyecto & " AND i.seq = l.seq AND l.tipo = i.tipo AND l.numero = i.numero AND l.numero = d.numero AND l.tipo = d.tipo AND d.centro_doc = " & cbo_centro.SelectedValue
        Dim dt_accesorios As DataTable = obj_op_simplesLn.listar_datatable(sql_accesorios, "CORSAN")
        For i = 0 To dt_accesorios.Rows.Count - 1
            For k = 0 To dtg_ppto.Rows.Count - 1
                If IsNumeric(dtg_ppto.Item(col_id.Name, k).Value) Then
                    If dtg_ppto.Item(col_id.Name, k).Value = dt_accesorios.Rows(i).Item("id_item") Then
                        If IsNumeric(dtg_ppto.Item(col_ejecutado.Name, k).Value) Then
                            dtg_ppto.Item(col_ejecutado.Name, k).Value += dt_accesorios.Rows(i).Item("valor")
                        Else
                            dtg_ppto.Item(col_ejecutado.Name, k).Value = dt_accesorios.Rows(i).Item("valor")
                        End If
                        dtg_ppto.Item(col_diferencia.Name, k).Value = dtg_ppto.Item(col_ppto.Name, k).Value - dtg_ppto.Item(col_ejecutado.Name, k).Value
                    End If
                End If
            Next
        Next
        totalizar_ppto()
        calcular_cump()
        cargar_items(id_proyecto)
    End Sub
    Private Sub cargar_items(ByVal id_proyecto As Double)
        Dim sql As String = "Select id_item,descripcion " &
                     "FROM J_proyectos_items " &
                        "WHERE id_proyecto =" & id_proyecto
        Dim dt As DataTable = New DataTable
        dt = obj_op_simplesLn.listar_datatable(sql, "PRODUCCION")
        dt.Rows.Add()
        dt.Rows(dt.Rows.Count - 1).Item("id_item") = 0
        dt.Rows(dt.Rows.Count - 1).Item("descripcion") = "Seleccione"
        cbo_item.DataSource = dt
        cbo_item.ValueMember = "id_item"
        cbo_item.DisplayMember = "descripcion"
        cbo_item.SelectedValue = 0
    End Sub
    Private Sub calcular_cump()
        For i = 0 To dtg_ppto.Rows.Count - 1
            If IsNumeric(dtg_ppto.Item(col_ejecutado.Name, i).Value) And IsNumeric(dtg_ppto.Item(col_ppto.Name, i).Value) Then
                If (dtg_ppto.Item(col_ejecutado.Name, i).Value > 0) And (dtg_ppto.Item(col_ppto.Name, i).Value > 0) Then
                    dtg_ppto.Item(col_cump.Name, i).Value = dtg_ppto.Item(col_ejecutado.Name, i).Value / dtg_ppto.Item(col_ppto.Name, i).Value
                    If (dtg_ppto.Item(col_cump.Name, i).Value > 1) Then
                        dtg_ppto.Item(col_cump.Name, i).Style.BackColor = Color.Red
                    ElseIf dtg_ppto.Item(col_cump.Name, i).Value >= 0.9 And dtg_ppto.Item(col_cump.Name, i).Value <= 0.99 Then
                        dtg_ppto.Item(col_cump.Name, i).Style.BackColor = Color.Yellow
                    Else
                        dtg_ppto.Item(col_cump.Name, i).Style.BackColor = Color.Green
                    End If
                End If
            End If
        Next
    End Sub
    Private Sub dtg_saldos_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dtg_saldos.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            dtg_select = dtg_saldos.Name
            With (Me.dtg_saldos)
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                End If
            End With
        End If
    End Sub
    Private Sub dtg_accesorios_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dtg_accesorios.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            dtg_select = dtg_accesorios.Name
            With (Me.dtg_accesorios)
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                End If
            End With
        End If
    End Sub
    Private Sub itemAsignar_Gasto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles itemAsignarGasto.Click
        group_asignar_gasto.Visible = True
        dtg_saldos.Enabled = False
        dtg_accesorios.Enabled = False
    End Sub

    Private Sub btn_asignar_gasto_Click(sender As Object, e As EventArgs) Handles btn_asignar_gasto.Click
        If cbo_item.SelectedValue <> 0 Then
            Dim dtg As New DataGridView
            Dim listSql As New List(Of Object)
            Dim sql As String = ""
            If dtg_select = dtg_saldos.Name Then
                dtg = dtg_saldos
            Else
                dtg = dtg_accesorios
            End If
            'sql = "DELETE FROM J_proyectos_item_gasto WHERE id_proyecto=" & txt_id_proyecto.Text & " And id_item=" & cbo_item.SelectedValue
            'listSql.Add(sql)
            sql = "INSERT INTO J_proyectos_item_gasto (id_proyecto,id_item,tipo,numero,seq) " &
                                    "VALUES (" & txt_id_proyecto.Text & "," & cbo_item.SelectedValue & ",'" & dtg.Item("tipo", dtg.CurrentCell.RowIndex).Value & "'," & dtg.Item("numero", dtg.CurrentCell.RowIndex).Value & "," & dtg.Item("seq", dtg.CurrentCell.RowIndex).Value & ")"
            listSql.Add(sql)
            If obj_Ing_prodLn.ExecuteSqlTransaction(listSql, "PRODUCCION") Then
                MessageBox.Show("El gasto de agrego en forma correcta", "Gasto asignado", MessageBoxButtons.OK, MessageBoxIcon.Information)
                group_asignar_gasto.Visible = False
                cargar_presupuesto(txt_id_proyecto.Text)
                dtg_saldos.Enabled = True
                dtg_accesorios.Enabled = True
                dtg.Rows(dtg.CurrentCell.RowIndex).DefaultCellStyle.BackColor = Color.GreenYellow
            Else
                MessageBox.Show("El gasto no fue asignado,comuniquese con el administrador del sistema", "Error al guardar", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            MessageBox.Show("Seleccione un item", "Seleccione item", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

    End Sub

    Private Sub btn_cerrar_asignar_gasto_Click(sender As Object, e As EventArgs) Handles btn_cerrar_asignar_gasto.Click
        group_asignar_gasto.Visible = False
        dtg_saldos.Enabled = True
        dtg_accesorios.Enabled = True
    End Sub

    Private Sub btn_cerrar_anadir_Click(sender As Object, e As EventArgs) Handles btn_cerrar_anadir.Click
        group_add_item.Visible = False
        txt_desc_item.Text = ""
        txt_ppto_item.Text = ""
    End Sub
    Private Sub totalizar_ppto()
        Dim sum As Double = 0
        For i = 0 To dtg_ppto.RowCount - 1
            If IsNumeric(dtg_ppto.Item(col_ppto.Name, i).Value) Then
                sum += dtg_ppto.Item(col_ppto.Name, i).Value
            End If
        Next
        txt_val_ppto.Text = sum.ToString("C0")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        group_editar_fecha.Visible = False
        cbo_fecha_final_ed.Value = Now
        dtg_ppto.Enabled = False
        txt_nota.Text = ""
        dtg_ppto.Enabled = True
    End Sub

    Private Sub btn_modificar_fecha_Click(sender As Object, e As EventArgs) Handles btn_modificar_fecha.Click
        Dim fec_fin As String = obj_op_simplesLn.cambiarFormatoFecha(cbo_fecha_final_ed.Value)
        Dim id_proyecto As Integer = txt_id_proyecto.Text
        Dim id_item As Integer = lbl_id_item.Text

        Dim sql As String = "SELECT nota_audi FROM J_proyectos_items WHERE id_proyecto = " & id_proyecto & " AND id_item = " & id_item
        Dim nota As String = obj_op_simplesLn.consultValorTodo(sql, "PRODUCCION")
        sql = "SELECT fecha_fin FROM J_proyectos_items WHERE id_proyecto = " & id_proyecto & " AND id_item = " & id_item
        nota &= "La fecha final anterior es:" & obj_op_simplesLn.consultValorTodo(sql, "PRODUCCION") & ", y la modifico " & usuario.usuario.Trim & ", su razon es: (" & txt_nota.Text & ");"
        If txt_nota.Text <> "" Then
            sql = "UPDATE J_proyectos_items SET nota_audi = '" & nota & "',fecha_fin = '" & fec_fin & "' WHERE id_proyecto = " & id_proyecto & " AND id_item = " & id_item

            If (obj_op_simplesLn.ejecutar(sql, "PRODUCCION")) Then
                group_editar_fecha.Visible = False
                cbo_fecha_final_ed.Value = Now
                dtg_ppto.Enabled = False
                txt_nota.Text = ""
                dtg_ppto.Enabled = True
                MessageBox.Show("La Fecha final se Cambio correctamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
                cargar_proyecto(id_proyecto)
                cargar_presupuesto(id_proyecto)
                cargar_gastos(id_proyecto)
            Else
                MessageBox.Show("Error al cambiar la fecha final, comuniquese con el administrador del sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                group_editar_fecha.Visible = False
                cbo_fecha_final_ed.Value = Now
                dtg_ppto.Enabled = False
                txt_nota.Text = ""
                dtg_ppto.Enabled = True
            End If
        Else
            MessageBox.Show("Debe ingresar una Razon.", "Seleccione item", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        Me.UseWaitCursor = True
        Application.DoEvents()
        objOperacionesForm.exportarExcel(dtg_ppto)
        Me.UseWaitCursor = False

        Me.UseWaitCursor = True
        Application.DoEvents()
        objOperacionesForm.exportarExcel(dtg_saldos)
        Me.UseWaitCursor = False

        Me.UseWaitCursor = True
        Application.DoEvents()
        objOperacionesForm.exportarExcel(dtg_accesorios)
        Me.UseWaitCursor = False
    End Sub

End Class