Imports logicaNegocios
Imports entidadNegocios
Public Class Frm_consultar_solicitud_mp_puas
    Private objOpSimplesLn As New Op_simpesLn
    Dim objIngresoProdLn As New Ing_prodLn
    Dim carga_comp As Boolean = False
    Dim usuario As UsuarioEn
    Private objOperacionesForm As OperacionesFormularios = New OperacionesFormularios
    Public Sub Main(ByVal usuario As UsuarioEn)
        Me.usuario = usuario
        If (usuario.permiso.Trim <> "ADMIN" And usuario.permiso.Trim <> "COMPRAS" And usuario.permiso.Trim <> "DIR_LOGISTICA" And usuario.permiso.Trim <> "DIR_PRODUCCION" And usuario.permiso.Trim <> "COOR_PROD") Then
            dtgConsulta.Columns(colBorrar.Name).Visible = False
            If Not IsDBNull(usuario.nit) Then
                If (usuario.permiso.Trim <> "ALMACEN") Then
                    cboSolicita.SelectedValue = usuario.nit
                    cboSolicita.Enabled = False
                End If
            End If
        End If
    End Sub

    Private Sub Frm_consultar_salida_mp_recocido_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cboFechaIni.Value = Now.AddMonths(-2)
        cboFechaFin.Value = Now
        cargar_cbo()
        carga_comp = True
    End Sub

    Private Sub cargar_cbo()
        Dim sql As String
        Dim dt As New DataTable
        Dim dr As DataRow
        dt = New DataTable
        sql = "SELECT nit,nombres FROM V_nom_personal_Activo_con_maquila where centro in (6400) order by nombres"
        dt = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        dr = dt.NewRow
        dr("nit") = 0
        dr("nombres") = "TODO"
        dt.Rows.Add(dr)
        cboSolicita.DataSource = dt
        cboSolicita.ValueMember = "nit"
        cboSolicita.DisplayMember = "nombres"
        cboSolicita.Text = "TODO"
    End Sub

    Private Sub dtgConsulta_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgConsulta.CellContentClick
        If (e.RowIndex >= 0) Then
            Dim col As String = dtgConsulta.Columns(e.ColumnIndex).Name
            Dim numero As Integer = dtgConsulta.Item("numero", e.RowIndex).Value
            Dim id_detalle As Integer = dtgConsulta.Item("id_detalle", e.RowIndex).Value
            If (col = colVer.Name) Then
                Dim dt As New DataTable
                Dim sql As String = "SELECT l.tipo,l.numero,l.cantidad,l.fec " & _
                                        "FROM J_salida_materia_prima_PU_transaccion t , CORSAN.dbo.documentos_lin l   " & _
                                          "WHERE  l.bodega = '14' AND l.tipo = t.tipo AND l.numero = t.num_transaccion AND t.numero = " & numero & "  AND t.id_detalle = " & id_detalle & ""
                dt = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")
                dtgTransacciones.DataSource = dt
                groupTransacciones.Visible = True
            ElseIf (col = colBorrar.Name) Then
                Dim motivo As String = InputBox("Ingrese el motivo de la anulación del consecutivo, luego presione aceptar", "Motivo")
                If (motivo <> "") Then
                    Dim listSql As New List(Of Object)
                    Dim sql As String
                    motivo &= " " & usuario.usuario & " " & Now
                    sql = "UPDATE J_salida_materia_prima_PU_enc SET anulado = 1,observaciones += '" & motivo & "' WHERE numero =" & numero
                    listSql.Add(sql)
                    If (objIngresoProdLn.ExecuteSqlTransaction(listSql, "PRODUCCION")) Then
                        cargarConsulta()
                        MessageBox.Show("El registro se elimino en forma correcta! ", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("Error al elimino el registro, verifique que la celda no este en blanco! ", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub cargarConsulta()
        Dim fecIni As String = objOpSimplesLn.cambiarFormatoFecha(cboFechaIni.Value)
        Dim fecFin As String = objOpSimplesLn.cambiarFormatoFecha(cboFechaFin.Value)
        Dim dt As New DataTable
        Dim sql As String = ""
        Dim selectSql As String = ""
        Dim whereSql As String = "WHERE t.nit = E.solicitante AND  E.anulado is null AND E.fecha >= '" & fecIni & "' AND E.fecha <= '" & fecFin & "' "
        Dim orderSql As String = " ORDER BY "
        If chk_devolver.Checked Then
            whereSql &= " AND devolver = 'S' "
        Else
            whereSql &= " AND (devolver = 'N' OR devolver IS NULL ) "
        End If
        selectSql = "SELECT E.numero,D.id_detalle,E.fecha,D.codigo,D.cantidad,(SELECT CASE WHEN (SELECT sum(peso) FROM J_salida_materia_prima_PU_transaccion  WHERE numero = D.numero AND id_detalle = D.id_detalle ) is null THEN 0 ELSE D.cantidad-(D.cantidad -(SELECT sum(peso) FROM J_salida_materia_prima_PU_transaccion  WHERE numero = D.numero AND id_detalle = D.id_detalle )) END ) As entregado_kilos,E.solicitante,t.nombres,E.observaciones " &
                       "FROM J_salida_materia_prima_PU_enc E ,J_salida_materia_prima_PU_det D, CORSAN.dbo.terceros t "
        whereSql &= " AND  D.numero = E.numero "
        orderSql &= "E.fecha "
        If (cboSolicita.Text <> "TODO") Then
            whereSql &= "AND E.solicitante = " & cboSolicita.SelectedValue & " "
        End If
        If (txtNumero.Text <> "") Then
            whereSql &= "AND E.numero = " & txtNumero.Text & " "
        ElseIf (txt_codigo.Text <> "") Then
            whereSql &= "AND D.codigo like'" & txt_codigo.Text & "%' "
        End If
        If Not (chkTerminados.Checked) Then
            whereSql &= " AND (SELECT CASE WHEN (SELECT sum(peso) FROM J_salida_materia_prima_PU_transaccion  WHERE numero = D.numero AND id_detalle = D.id_detalle ) is null THEN 0 ELSE (D.cantidad -(SELECT sum(peso) FROM J_salida_materia_prima_PU_transaccion  WHERE numero = D.numero AND id_detalle = D.id_detalle )) END )<D.cantidad "
        End If

        sql = selectSql & whereSql & orderSql
        dt = objIngresoProdLn.listar_datatable(sql, "PRODUCCION")
        dtgConsulta.DataSource = dt
        dtgConsulta.Columns("fecha").DefaultCellStyle.Format = "d"
        dtgConsulta.Columns("numero").HeaderText = "#"
        dtgConsulta.CurrentCell = Nothing
        pintarTerminadas()
    End Sub

    Private Sub pintarTerminadas()
        For i = 0 To dtgConsulta.RowCount - 1
            If Not IsDBNull(dtgConsulta.Item("cantidad", i).Value) Then
                If (dtgConsulta.Item("entregado_kilos", i).Value.ToString <> "") Then
                    If (dtgConsulta.Item("entregado_kilos", i).Value >= dtgConsulta.Item("cantidad", i).Value) Then
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

    Private Sub txtNumero_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNumero.TextChanged
        If (carga_comp) Then
            carga_comp = False
            If (usuario.permiso.Trim = "ADMIN" Or usuario.permiso.Trim = "COMPRAS") Then
                cboSolicita.Text = "TODO"
            End If
            carga_comp = True
        End If
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        Dim frm As New frm_solicitud_mp_puas
        frm.Show()
        frm.Main(usuario, 0)
    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        Me.UseWaitCursor = True
        Application.DoEvents()
        objOperacionesForm.exportarExcel(dtgConsulta)
        Me.UseWaitCursor = False
    End Sub
    Private Sub txtTope_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
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
    Private Sub btnCerrarEditResp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrarEditResp.Click
        groupTransacciones.Visible = False
    End Sub
End Class