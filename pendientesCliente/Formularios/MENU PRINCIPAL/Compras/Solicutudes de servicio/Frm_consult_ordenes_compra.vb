Imports logicaNegocios
Imports entidadNegocios
Imports accesoDatos
Imports System.Data.SqlClient
Public Class Frm_consult_ordenes_compra
    Private objOpSimplesLn As New Op_simpesLn
    Dim objIngresoProdLn As New Ing_prodLn
    Dim carga_comp As Boolean = False
    Dim usuario As UsuarioEn
    Dim idventana As String
    Dim numero As Integer
    Dim Cmd As New SqlCommand
    Private objOperacionesForm As OperacionesFormularios = New OperacionesFormularios
    Public Sub Main(ByVal usuario As UsuarioEn, ByVal idven As String)
        Me.usuario = usuario
        If (usuario.permiso.Trim <> "ADMIN" And usuario.permiso.Trim <> "COMPRAS" And usuario.permiso.Trim <> "DIR_LOGISTICA" And usuario.permiso.Trim <> "DIR_PRODUCCION" And usuario.permiso.Trim <> "COOR_PROD") Then
            dtgConsulta.Columns(colBorrar.Name).Visible = False
            menStripDtg.Enabled = False
            txtTope.ReadOnly = True
            btnActTope.Enabled = False
            If Not IsDBNull(usuario.nit) Then
                If (usuario.permiso.Trim <> "ALMACEN") Then
                    cboResponsable.SelectedValue = usuario.nit
                    cboResponsable.Enabled = False
                End If
            End If
        End If
        If usuario.permiso.Trim <> "ADMIN" And usuario.permiso.Trim <> "COMPRAS" And usuario.permiso.Trim <> "COOR_PROD" And usuario.permiso.Trim <> "DIR_PRODUCCION" Then
            itemAutorizar.Enabled = False
            DesautorizarToolStripMenuItem.Enabled = False
            itemFinalizar.Enabled = False
            PresupuestarToolStripMenuItem.Enabled = False
        End If
        idventana = idven
        Reporte.Visible = False
        If idventana = "S" Then
            Me.Text = "Consultar solicitudes de servicios"
            Me.txtTope.Visible = False
            Me.btnActTope.Visible = False
            Me.Label7.Visible = False
            Reporte.Visible = True
            chk_incluir_cont.Visible = True
        End If
        carga_comp = True
    End Sub
    Private Sub Frm_consult_ordenes_compra_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cboFechaIni.Value = Now.AddMonths(-5)
        cboFechaFin.Value = Now
        cargar_cbo()
        txtTope.Text = obtenerTope()
    End Sub

    Private Sub dtgConsulta_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgConsulta.CellContentClick
        If (e.RowIndex >= 0) Then
            Dim col As String = dtgConsulta.Columns(e.ColumnIndex).Name
            numero = dtgConsulta.Item("numero", e.RowIndex).Value

            If (col = colEditar.Name) Then
                Dim sql_referencias As String = ""

                Dim cant_num_det As Integer = objIngresoProdLn.consultar_valor("SELECT COUNT (num_det) FROM J_solicitud_compra_det WHERE numero = " & numero, "PRODUCCION")
                Dim sql_detalle As String = "SELECT D.numero,D.num_det,D.cantidad,D.descripcion_solicitante,D.cantidad_aut,D.medida,D.entregado,D.precio_unit,D.nit_proveedor,(SELECT nombres FROM CORSAN.dbo.terceros where nit = D.nit_proveedor)as proveedor,D.cuenta  " &
                                                "FROM J_solicitud_compra_det D " &
                                                        "WHERE  D.numero = " & numero & " "
                Dim dt As DataTable = objOpSimplesLn.listar_datatable(sql_detalle, "PRODUCCION")
                Dim dt_referencias As New DataTable
                Dim frm As New Frm_orden_compra
                If idventana = "S" Then
                    frm.Main(usuario, numero, "nod_generar_sol_compra", idventana)
                    frm.carga_comp = False
                    frm.Text = "Generar solicitud de servicio"
                    frm.Label10.Text = "Observaciones Solicitud de servicio"
                ElseIf idventana = "O" Then
                    frm.Main(usuario, numero, "nod_generar_sol_compra", idventana)
                    frm.carga_comp = False
                End If
                frm.Show()
                If Not IsDBNull(dtgConsulta.Item("pedido_realizado", e.RowIndex).Value) Then
                    frm.chk_ped_realizado.Checked = True
                End If
                frm.cboQuienSolicita.SelectedValue = dtgConsulta.Item("solicitante", e.RowIndex).Value
                frm.cboCentro.SelectedValue = dtgConsulta.Item("centro", e.RowIndex).Value
                frm.cboFechaSol.Value = objOpSimplesLn.cambiarFormatoFecha(dtgConsulta.Item("fecha_solicitud", e.RowIndex).Value)
                frm.cboFechaEsp.Value = objOpSimplesLn.cambiarFormatoFecha(dtgConsulta.Item("fecha_espera", e.RowIndex).Value)
                frm.txtObservaciones.Text = dtgConsulta.Item("observaciones_orden", e.RowIndex).Value

                If IsDBNull(dtgConsulta.Item("numero_fact", e.RowIndex).Value) = True Then
                    frm.txtnumerofac.Text = ""
                Else
                    frm.txtnumerofac.Text = dtgConsulta.Item("numero_fact", e.RowIndex).Value
                End If
                    If Not IsDBNull(dtgConsulta.Item("observaciones_alamcen", e.RowIndex).Value) Then
                        frm.txtObserAlmacen.Text = dtgConsulta.Item("observaciones_alamcen", e.RowIndex).Value
                    End If
                    If Not (IsDBNull(dtgConsulta.Item("recive", e.RowIndex).Value)) Then
                        If (dtgConsulta.Item("recive", e.RowIndex).Value <> "") Then
                            frm.cboRecive.SelectedValue = dtgConsulta.Item("recive", e.RowIndex).Value
                        End If
                    End If
                    If Not (IsDBNull(dtgConsulta.Item("fecha_recive", e.RowIndex).Value)) Then
                        frm.cboFecRecepcion.Value = dtgConsulta.Item("fecha_recive", e.RowIndex).Value
                    End If
                    If Not (IsDBNull(dtgConsulta.Item("responsable", e.RowIndex).Value)) Then
                        frm.cboResponsable.SelectedValue = dtgConsulta.Item("responsable", e.RowIndex).Value
                    End If
                    If Not (IsDBNull(dtgConsulta.Item("autoriza", e.RowIndex).Value)) Then
                        frm.cboautoriza.SelectedValue = dtgConsulta.Item("autoriza", e.RowIndex).Value
                    End If
                    If Not (IsDBNull(dtgConsulta.Item("contabilizado", e.RowIndex).Value)) Then
                        If dtgConsulta.Item("contabilizado", e.RowIndex).Value = "S" Then
                            frm.chk_contabilizado.Checked = True
                        End If
                    End If
                    If (cant_num_det > (frm.dtgSolicitud.RowCount - 1)) Then
                        Dim diferencia As Integer = cant_num_det - (frm.dtgSolicitud.RowCount - 1)
                        For i = 0 To diferencia
                            frm.dtgSolicitud.Rows.Add()
                        Next
                    End If

                    For i = 0 To dt.Rows.Count - 1
                    frm.dtgSolicitud.Item("ColNumDet", i).Value = dt.Rows(i).Item("num_det")
                    frm.dtgSolicitud.Item("colDesc", i).Value = dt.Rows(i).Item("descripcion_solicitante")
                    frm.dtgSolicitud.Item("colCant", i).Value = dt.Rows(i).Item("cantidad")
                    frm.dtgSolicitud.Item("colMedida", i).Value = dt.Rows(i).Item("medida")
                    If IsDBNull(dt.Rows(i).Item("nit_proveedor")) Then
                        frm.dtgSolicitud.Item("Id_proveedor", i).Value = 890900160
                    Else
                        frm.dtgSolicitud.Item("Id_proveedor", i).Value = dt.Rows(i).Item("nit_proveedor")
                        End If
                        frm.dtgSolicitud.Item("colProveedor", i).Value = dt.Rows(i).Item("proveedor")
                        If Not (IsDBNull(dt.Rows(i).Item("entregado"))) Then
                            frm.dtgSolicitud.Item("col_cant_entregada", i).Value = dt.Rows(i).Item("entregado")
                        Else
                            frm.dtgSolicitud.Item("col_cant_entregada", i).Value = 0
                        End If
                        If Not (IsDBNull(dt.Rows(i).Item("cantidad_aut"))) Then
                            frm.dtgSolicitud.Item("colCantAut", i).Value = dt.Rows(i).Item("cantidad_aut")
                        Else
                            frm.dtgSolicitud.Item("colCantAut", i).Value = 0
                        End If
                        If Not (IsDBNull(dt.Rows(i).Item("precio_unit"))) Then
                            frm.dtgSolicitud.Item("colPrecio", i).Value = dt.Rows(i).Item("precio_unit")
                        Else
                            frm.dtgSolicitud.Item("colPrecio", i).Value = 0
                    End If
                    If Not (IsDBNull(dt.Rows(i).Item("cuenta"))) Then
                        frm.dtgSolicitud.Rows(i).Cells.Item("cbocuenta").Value = dt.Rows(i).Item("cuenta").ToString
                    Else
                        frm.dtgSolicitud.Item("cbocuenta", i).Value = "0"
                    End If
                    Next
                    frm.pintarFaltantes()
                    frm.eliminarNoUsadas()
                    frm.caluclar_val_autorizado()
                    frm.carga_comp = True
                ElseIf (col = colBorrar.Name) Then
                    Dim motivo As String = InputBox("Ingrese el motivo de la anulación del consecutivo, luego presione aceptar", "Motivo")
                    If (motivo <> "") Then
                        Dim listSql As New List(Of Object)
                        Dim sql As String
                        motivo &= " " & usuario.usuario & " " & Now
                        sql = "UPDATE J_solicitud_compra_enc SET anulado = 1,observaciones += '" & motivo & "' WHERE numero =" & numero
                        listSql.Add(sql)
                        If (objIngresoProdLn.ExecuteSqlTransaction(listSql, "PRODUCCION")) Then
                            cargarConsulta()
                            MessageBox.Show("El registro se elimino en forma correcta! ", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Else
                            MessageBox.Show("Error al elimino el registro, verifique que la celda no este en blanco! ", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    End If
                    'Genera los reportes de las solicitudes de servicio
                ElseIf (col = Reporte.Name) Then
                Dim reporte As New VisualizadorReporte
                Dim num_det As Integer
                num_det = obteneridrollo()
                reporte.guardar_numero(numero, num_det)
                reporte.ShowDialog()
            End If
        End If
    End Sub
    'Obtiene el numero de de servicios añadido a la solicitud
    Public Function obteneridrollo()
        Dim con As New Conexion
        Dim num_det_max As Integer
        con.abrirConexion_prod()
        Cmd = New SqlCommand("select MAX(num_det) from J_solicitud_compra_det where numero=" & numero)
        Cmd.CommandType = CommandType.Text
        Cmd.Connection = con.abrirConexion_prod
        num_det_max = Cmd.ExecuteScalar.ToString
        Return num_det_max
    End Function

    Private Sub cargar_cbo()
        Dim sql As String
        Dim dt As New DataTable
        Dim dr As DataRow
        dt = New DataTable
        sql = "SELECT nit,nombres FROM V_nom_personal_Activo_con_maquila order by nombres"
        dt = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        dr = dt.NewRow
        dr("nit") = 0
        dr("nombres") = "TODO"
        dt.Rows.Add(dr)
        cboResponsable.DataSource = dt
        cboResponsable.ValueMember = "nit"
        cboResponsable.DisplayMember = "nombres"
        cboResponsable.Text = "TODO"

        sql = "SELECT CONVERT (varchar ,centro )As centro FROM V_nom_personal_Activo_con_maquila GROUP BY centro "
        dt = New DataTable
        dt = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        dr = dt.NewRow
        dr("centro") = "TODO"
        dt.Rows.Add(dr)
        cboCentro.DataSource = dt
        cboCentro.ValueMember = "centro"
        cboCentro.DisplayMember = "centro"
        cboCentro.Text = "TODO"
    End Sub
    Private Sub cargarConsulta()
        dtgConsulta.DataSource = Nothing
        Dim fecIni As String = objOpSimplesLn.cambiarFormatoFecha(cboFechaIni.Value)
        Dim fecFin As String = objOpSimplesLn.cambiarFormatoFecha(cboFechaFin.Value)
        Dim dt As New DataTable
        Dim sql As String = ""
        Dim whereSql As String
        Dim whereFec As String = " AND E.anulado is null AND E.fecha_solicitud >= '" & fecIni & "' AND E.fecha_solicitud <= '" & fecFin & "' "
        Dim selectSql As String = "SELECT  E.numero,E.numero_fact,SUM(cast(D.cantidad_aut as bigint) * cast(D.precio_unit as bigint) ) As vr_total,E.solicitante,P.nombres As nom_responsable,E.observaciones As contenido,E.fecha_aut,E.fecha_solicitud,E.fecha_espera,E.centro, " &
                                         "E.obserAlmacen As observaciones_alamcen,E.observaciones As observaciones_orden ,E.recive,E.fecha_recive ,E.responsable,E.autoriza,E.terminado,E.pedido_realizado,E.autorizado,E.contabilizado,E.presupuestado,sum(d.cantidad) as cantidad  " &
                                "FROM J_solicitud_compra_det D , J_solicitud_compra_enc E , CORSAN.dbo.V_nom_personal_Activo_con_maquila P "
        If idventana = "S" Then
            whereSql = "WHERE  E.numero = D.numero AND E.responsable = P.nit AND E.d_orden = '" & idventana & "'"
            If chk_incluir_cont.Checked = False Then
                whereSql &= " AND (E.contabilizado <> 'S' OR E.contabilizado is null) "
            End If
        Else
            whereSql = "WHERE  E.numero = D.numero AND E.responsable = P.nit AND (E.d_orden <> 'S' or E.d_orden is null)  "
        End If
        Dim groupSql As String = "GROUP BY E.numero,E.solicitante,P.nombres,E.fecha_solicitud,E.fecha_espera,E.centro,E.recive,e.fecha_recive,E.fecha_aut ,E.responsable,E.autoriza,E.observaciones,E.obserAlmacen ,E.terminado,E.pedido_realizado,E.autorizado,E.numero_fact,E.contabilizado,E.presupuestado   ORDER BY E.numero  "
        If txt_proveedor.Text <> "" Then
            whereSql &= "AND D.nit_proveedor ='" & txt_proveedor.Text & "' "
        Else
            If (txtNumero.Text <> "") Then
                whereSql &= "AND E.numero = " & txtNumero.Text & " "
            Else
                whereSql &= whereFec
                If (chkTerminados.Checked = False) Then
                    whereSql &= "AND E.terminado is null  " '"AND d.entregado is not null"
                End If
                If (txtContenido.Text.Trim <> "") Then
                    whereSql &= "AND D.descripcion_solicitante like '%" & txtContenido.Text & "%' "
                Else
                    If (cboResponsable.SelectedValue <> 0) Then
                        whereSql &= "AND E.responsable = " & cboResponsable.SelectedValue & " "
                    End If

                    If (cboCentro.Text <> "TODO") Then
                        whereSql &= "AND P.centro = " & cboCentro.SelectedValue & " "
                    End If
                End If
            End If
        End If
        If chk_desau.Checked = False Then
            'whereSql &= " AND autorizado is null "
        End If

        If chk_presup.Checked = True Then
            whereSql &= " AND presupuestado is not null "
        End If


        sql = selectSql & whereSql & groupSql
        dt = objIngresoProdLn.listar_datatable(sql, "PRODUCCION")
        addContenido(dt)
        If idventana = "S" Then
            addProveedores(dt)
        End If
        dtgConsulta.DataSource = dt
        If idventana = "O" Then
            dtgConsulta.Columns("autoriza").Visible = False
        End If
        dtgConsulta.Columns("autoriza").Visible = False
        dtgConsulta.Columns("responsable").Visible = False
        dtgConsulta.Columns("solicitante").Visible = False
        dtgConsulta.Columns("recive").Visible = False
        dtgConsulta.Columns("autorizado").Visible = False
        dtgConsulta.Columns("terminado").Visible = False
        dtgConsulta.Columns("fecha_recive").Visible = False
        dtgConsulta.Columns("pedido_realizado").Visible = False
        dtgConsulta.Columns("fecha_solicitud").DefaultCellStyle.Format = "d"
        dtgConsulta.Columns("fecha_espera").DefaultCellStyle.Format = "d"
        dtgConsulta.Columns("fecha_aut").DefaultCellStyle.Format = "d"
        dtgConsulta.Columns("numero").HeaderText = "#"
        dtgConsulta.Columns("fecha_solicitud").HeaderText = "fecha"
        dtgConsulta.Columns("nom_responsable").DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        pintarAutorizados()
        pintarPedRezalizados()
        pintarTerminadas()
        solicitudes_encima_tope()
        dtgConsulta.Columns("contenido").DefaultCellStyle.WrapMode = DataGridViewTriState.True
        If idventana <> "S" Then
            dtgConsulta.Columns("numero_fact").Visible = False
            dtgConsulta.Columns("contabilizado").Visible = False
        Else
            pintarContabilizados()
        End If
        For i = 0 To dtgConsulta.RowCount - 1
            If Not IsDBNull(dtgConsulta.Item("autorizado", i).Value) Then
                If (dtgConsulta.Item("autorizado", i).Value.ToString = "N") Then
                    dtgConsulta.Rows(i).DefaultCellStyle.BackColor = Color.Salmon
                End If
            End If
        Next
        For i = 0 To dtgConsulta.RowCount - 1
            If Not IsDBNull(dtgConsulta.Item("presupuestado", i).Value) Then
                If (dtgConsulta.Item("presupuestado", i).Value.ToString = "S") And (dtgConsulta.Item("autorizado", i).Value.ToString = "") And (dtgConsulta.Item("contabilizado", i).Value.ToString = "N") And (dtgConsulta.Item("pedido_realizado", i).Value.ToString = "") And (dtgConsulta.Item("terminado", i).Value.ToString = "") Then
                    dtgConsulta.Rows(i).DefaultCellStyle.BackColor = Color.MediumPurple
                End If
            End If
        Next
    End Sub
    Private Function addContenido(ByRef dt As DataTable) As DataTable
        Dim sql As String = ""
        Dim valor As String = ""
        For i = 0 To dt.Rows.Count - 1
            sql = "DECLARE @valores VARCHAR(MAX) " &
                    "SELECT @valores = COALESCE( @valores + ' " & vbCrLf & "', '') + descripcion_solicitante + ' -> ' + CAST(cantidad AS varchar(25))   FROM J_solicitud_compra_det where numero = " & dt.Rows(i).Item("numero") & " " &
                    "SELECT @valores as valores"
            valor = objIngresoProdLn.consultar_valor(sql, "PRODUCCION")
            dt.Rows(i).Item("contenido") = valor
        Next
        Return dt
    End Function
    Private Function addProveedores(ByRef dt As DataTable) As DataTable
        dt.Columns.Add("proveedor")
        dt.Columns("proveedor").SetOrdinal(4)
        Dim sql As String = ""
        Dim valor As String = ""
        For i = 0 To dt.Rows.Count - 1
            sql = "DECLARE @valores VARCHAR(MAX) " &
                    "SELECT @valores = COALESCE( @valores + ' " & vbCrLf & "', '') +  CAST(t.nombres AS varchar(25))   FROM J_solicitud_compra_det d , corsan.dbo.terceros t where t.nit = d.nit_proveedor AND d.numero = " & dt.Rows(i).Item("numero") & " " &
                    "SELECT @valores as valores"
            valor = objIngresoProdLn.consultar_valor(sql, "PRODUCCION")
            dt.Rows(i).Item("proveedor") = valor
        Next
        Return dt
    End Function
    Private Sub pintarContabilizados()
        For i = 0 To dtgConsulta.RowCount - 1
            If Not IsDBNull(dtgConsulta.Item("contabilizado", i).Value) Then
                If (dtgConsulta.Item("contabilizado", i).Value.ToString = "S") Then
                    dtgConsulta.Rows(i).DefaultCellStyle.BackColor = Color.LightGray
                End If
            End If
        Next
    End Sub
    Private Sub pintarAutorizados()
        For i = 0 To dtgConsulta.RowCount - 1
            If Not IsDBNull(dtgConsulta.Item("autorizado", i).Value) Then
                If (dtgConsulta.Item("autorizado", i).Value.ToString = "S") Then
                    dtgConsulta.Rows(i).DefaultCellStyle.BackColor = Color.DodgerBlue
                End If
            End If
        Next
    End Sub
    Private Sub pintarPedRezalizados()
        For i = 0 To dtgConsulta.RowCount - 1
            If Not IsDBNull(dtgConsulta.Item("pedido_realizado", i).Value) Then
                If (dtgConsulta.Item("pedido_realizado", i).Value.ToString <> "") Then
                    If (dtgConsulta.Item("pedido_realizado", i).Value) Then
                        dtgConsulta.Rows(i).DefaultCellStyle.BackColor = Color.Gold
                    End If
                End If
            End If
        Next
    End Sub
    Private Sub pintarTerminadas()
        For i = 0 To dtgConsulta.RowCount - 1
            If Not IsDBNull(dtgConsulta.Item("terminado", i).Value) Then
                If (dtgConsulta.Item("terminado", i).Value.ToString <> "") Then
                    If (dtgConsulta.Item("terminado", i).Value = 1) Then
                        dtgConsulta.Rows(i).DefaultCellStyle.BackColor = Color.GreenYellow
                    End If
                End If
            End If
        Next
    End Sub
    Private Sub btnActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActualizar.Click
        img_procesar.Visible = True
        Application.DoEvents()
        cargarConsulta()
        img_procesar.Visible = False
    End Sub


    Private Sub cboCentro_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCentro.SelectedIndexChanged
        If (carga_comp) Then
            carga_comp = False
            If (usuario.permiso.Trim = "ADMIN" Or usuario.permiso.Trim = "COMPRAS") Then
                cboResponsable.Text = "TODO"
                txtNumero.Text = ""
            End If
            cargarConsulta()
            carga_comp = True
        End If
    End Sub

    Private Sub cboQuienSolicita_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboResponsable.SelectedIndexChanged
        If (carga_comp) Then
            carga_comp = False
            cboCentro.Text = "TODO"
            txtNumero.Text = ""
            cargarConsulta()
            carga_comp = True
        End If
    End Sub

    Private Sub txtNumero_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNumero.TextChanged
        If (carga_comp) Then
            carga_comp = False
            If (usuario.permiso.Trim = "ADMIN" Or usuario.permiso.Trim = "COMPRAS") Then
                cboCentro.Text = "TODO"
                cboResponsable.Text = "TODO"
            End If

            cargarConsulta()
            carga_comp = True
        End If
    End Sub

    Private Sub cboFechaIni_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFechaIni.ValueChanged
        If (carga_comp) Then
            cargarConsulta()
        End If
    End Sub

    Private Sub cboFechaFin_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFechaFin.ValueChanged
        If (carga_comp) Then
            cargarConsulta()
        End If
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        Dim frm As New Frm_orden_compra
        frm.Show()
        frm.Main(usuario, 0, "nod_generar_sol_compra", idventana)
    End Sub

    Private Sub ToolStripButton3_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton3.Click
        Me.UseWaitCursor = True
        Application.DoEvents()
        objOperacionesForm.exportarExcel(dtgConsulta)
        Me.UseWaitCursor = False
    End Sub
    Private Sub solicitudes_encima_tope()
        For i = 0 To dtgConsulta.RowCount - 1
            If IsNumeric(dtgConsulta.Item("vr_total", i).Value) Then
                If IsNumeric(txtTope.Text) Then
                    If (Convert.ToDouble(dtgConsulta.Item("vr_total", i).Value) >= Convert.ToDouble(txtTope.Text)) Then
                        If Not IsDBNull(dtgConsulta.Item("autorizado", i).Value) Then
                            If (dtgConsulta.Item("autorizado", i).Value = "S") Then
                                dtgConsulta.Item("vr_total", i).Style.BackColor = Color.Blue
                            Else
                                dtgConsulta.Item("vr_total", i).Style.BackColor = Color.Black
                            End If
                        Else
                            dtgConsulta.Item("vr_total", i).Style.BackColor = Color.Black
                        End If

                        dtgConsulta.Item("vr_total", i).Style.ForeColor = Color.White
                    End If
                End If
            End If
        Next
    End Sub
    Private Sub txtTope_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTope.KeyPress
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

    Private Function obtenerTope() As Double
        Dim tope As String
        Dim sql As String = "SELECT tope FROM J_solicitud_tope "
        tope = objIngresoProdLn.consultar_valor(sql, "PRODUCCION")
        If (tope = "") Then
            Return 0
        Else
            Return tope
        End If
    End Function

    Private Sub btnActTope_Click(sender As Object, e As EventArgs) Handles btnActTope.Click
        If IsNumeric(txtTope.Text) Then
            Dim motivo As String = InputBox("Ingrese el motivo de la anulación del consecutivo, luego presione aceptar", "Motivo")
            If (motivo <> "") Then
                Dim sql As String
                motivo &= " " & usuario.usuario & " " & Now
                sql = "UPDATE J_solicitud_tope SET tope = " & txtTope.Text & ", notas += '" & " " & " " & motivo & "'"
                If (objIngresoProdLn.ejecutar(sql, "PRODUCCION")) Then
                    cargarConsulta()
                    MessageBox.Show("El registro se actualizo en forma correcta! ", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Error al elimino el registro, verifique que la celda no este en blanco! ", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                MessageBox.Show("Debe ingresar un mitvo, el tope no se actualizo!", "No se actualizo el tope", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtTope.Text = ""
            End If
        Else
            MessageBox.Show("El valor ingresado debe ser númerico", "No se actualizo el tope", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtTope.Text = obtenerTope()
        End If
    End Sub

    Private Sub itemAutorizar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles itemAutorizar.Click
        Dim numero As Integer = dtgConsulta.Item("numero", dtgConsulta.CurrentCell.RowIndex).Value
        Dim sql As String = "UPDATE J_solicitud_compra_enc SET autorizado = 'S' WHERE numero = " & numero
        If (objIngresoProdLn.ejecutar(sql, "PRODUCCION")) Then
            cargarConsulta()
            MessageBox.Show("El registro se autorizo en forma correcta! ", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Error al autorizar el registro, verifique que la celda no este en blanco! ", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Private Sub dtgConsulta_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dtgConsulta.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            With (Me.dtgConsulta)
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                End If
            End With
        End If
    End Sub
    Private Sub DesautorizarToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles DesautorizarToolStripMenuItem.Click
        Dim numero As Integer = dtgConsulta.Item("numero", dtgConsulta.CurrentCell.RowIndex).Value
        Dim Sql As String = "UPDATE J_solicitud_compra_enc SET autorizado = NULL WHERE numero = " & numero
        If (objIngresoProdLn.ejecutar(sql, "PRODUCCION")) Then
            cargarConsulta()
            MessageBox.Show("El registro se desautorizo en forma correcta! ", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Error al autorizar el registro, verifique que la celda no este en blanco! ", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub


    Private Sub PresupuestarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PresupuestarToolStripMenuItem.Click
        Dim numero As Integer = dtgConsulta.Item("numero", dtgConsulta.CurrentCell.RowIndex).Value
        Dim Sql As String = "UPDATE J_solicitud_compra_enc SET presupuestado = 'S' WHERE numero = " & numero
        If (objIngresoProdLn.ejecutar(Sql, "PRODUCCION")) Then
            cargarConsulta()
            MessageBox.Show("El registro se presupuesto en forma correcta! ", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Error al autorizar el registro, verifique que la celda no este en blanco! ", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Private Sub itemFinalizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles itemFinalizar.Click
        Dim result As MsgBoxResult
        Dim sql As String
        Dim frm As New Frm_consult_ordenes_compra
        If (usuario.permiso.Trim = "ADMIN" Or usuario.permiso.Trim = "COMPRAS" Or usuario.permiso.Trim = "ALMACEN") Then
            If numero <> 0 Then
                result = MessageBox.Show("Desea finalizar el pedido", "finalizar pedido", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                If result = vbYes Then
                    sql = "update J_solicitud_compra_enc set terminado=1 where numero=" & numero & ""
                    objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")
                    cargarConsulta()
                End If
            Else
                MessageBox.Show("No se puede finalizar un orden o solicitud que no existe", "finalizar pedido", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            MessageBox.Show("No tiene permiso para finalizar un pedido", "finalizar pedido", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
End Class