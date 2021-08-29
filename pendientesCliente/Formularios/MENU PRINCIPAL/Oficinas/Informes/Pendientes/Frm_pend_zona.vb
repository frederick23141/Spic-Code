Imports logicaNegocios
Public Class Frm_pend_zona
    Private objOperacionesForm As OperacionesFormularios = New OperacionesFormularios
    Private objOpSimplesLn As New Op_simpesLn
    Dim nit As String = ""
    Dim carga_comp As Boolean = False
    Dim pais As String
    Dim ciudad As String
    Dim departamento As String
    Private Sub Frm_pend_zona_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        cargar_cbo()
        carga_comp = True
    End Sub

    Private Sub cargar_consulta()
        imgProc.Visible = True
        Application.DoEvents()
        Dim sql As String = ""
        Dim selectSql As String = "SELECT * FROM J_v_pendientes_zona "
        Dim whereSql As String = "WHERE "
        If (cbo_ruta.Text <> "Seleccione" And cbo_ruta.Text <> "TODO") Then
            whereSql &= "id_ruta =" & cbo_ruta.SelectedValue
        ElseIf (txt_codigo.Text <> "") Then
            whereSql &= "codigo  like '" & txt_codigo.Text & "%'"
        ElseIf (txt_vend_max.Text <> "" And txt_vend_min.Text <> "") Then
            whereSql &= "vend >=" & txt_vend_min.Text & " AND vend <=" & txt_vend_max.Text
        ElseIf (txtNumero.Text <> "") Then
            whereSql &= "numero like '" & txtNumero.Text & "%'"
        ElseIf (nit <> "") Then
            whereSql &= "nit = " & nit
        Else
            whereSql = ""
        End If
        sql = selectSql & whereSql
        dtg_consulta.DataSource = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        dtg_consulta.Columns("fecha").DefaultCellStyle.Format = "d"

        sql = "SELECT p.fecha,p.numero,p.vendedor as vend,y.descripcion as pais ,d.descripcion As departamento ,p.ciudad,p.nit,p.nombres,p.codigo,p.descripcion," & _
                    "p.Cant_pedida, p.cantidad_despachada, p.valor_unitario, p.Pendiente, p.KilosPendiente, p.Valor_total, p.autorizacion," & _
                    "p.autoriz_texto, p.usuario, p.bodega, p.direccion, p.telefono_1, p.condicion, p.pc, p.Id_cor, p.nota_vta, p.notas_aut, p.notas5, c.zona, p.y_ciudad, c.departamento As y_departamento, c.pais As y_pais " & _
            "FROM V_pendientes_por_vendedor p  ,y_ciudades c ,y_departamentos d , y_paises y " & _
            "WHERE p.y_ciudad = c.ciudad And p.y_dpto = c.departamento And p.y_pais = c.pais And c.zona Is null " & _
                            "AND c.pais = y.pais AND c.departamento = d.departamento "
        dtgSinRuta.DataSource = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        dtgSinRuta.Columns("fecha").DefaultCellStyle.Format = "d"
        dtgSinRuta.Columns("y_ciudad").Visible = False
        dtgSinRuta.Columns("y_departamento").Visible = False
        dtgSinRuta.Columns("y_pais").Visible = False
        tab_pen_sin_ruta.Text = "Pendientes sin ruta (" & dtgSinRuta.RowCount & " 'items')"
        If (dtgSinRuta.RowCount > 0) Then
            txt_estado_sin_ruta.BackColor = Color.Red
        Else
            txt_estado_sin_ruta.BackColor = Color.Green
        End If
        tab1.SelectedTab = tab_pen_con_ruta
        imgProc.Visible = False
    End Sub

    Private Sub btn_exportar_Click(sender As System.Object, e As System.EventArgs) Handles btn_exportar.Click
        objOperacionesForm.ExportarDatosExcel(dtg_consulta, "Pendientes por zona")
    End Sub

    Private Sub btn_ppal_Click(sender As System.Object, e As System.EventArgs) Handles btn_ppal.Click
        FrmPrincipal.Show()
        Me.Close()
        FrmPrincipal.Activate()
    End Sub

    Private Sub btn_salir_Click(sender As System.Object, e As System.EventArgs) Handles btn_salir.Click
        FrmLogin.Show()
        FrmPrincipal.Close()
        FrmLogin.Activate()
        Me.Close()
    End Sub
    Private Sub cargar_cbo()
        Dim sql As String
        Dim dt As New DataTable
        Dim dr As DataRow

        sql = "SELECT codigo,descripcion  FROM J_zona_ciudad ORDER BY descripcion"
        dt = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        dr = dt.NewRow
        dr("codigo") = 0
        dr("descripcion") = "TODO"
        dt.Rows.Add(dr)
        cbo_ruta.DataSource = dt
        cbo_ruta.ValueMember = "codigo"
        cbo_ruta.DisplayMember = "descripcion"
        cbo_ruta.Text = "Seleccione"

        dt = New DataTable
        dt = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        dr = dt.NewRow
        dr("codigo") = 0
        dr("descripcion") = "TODO"
        dt.Rows.Add(dr)
        cboRutaAsignar.DataSource = dt
        cboRutaAsignar.ValueMember = "codigo"
        cboRutaAsignar.DisplayMember = "descripcion"
        cboRutaAsignar.Text = "Seleccione"
    End Sub

    Private Sub btnActualizar_Click(sender As System.Object, e As System.EventArgs) Handles btnActualizar.Click
        If (cbo_ruta.Text <> "Seleccione" Or txt_codigo.Text <> "" Or txt_codigo.Text <> "" Or (txt_vend_max.Text <> "" And txt_vend_min.Text <> "") Or txtNumero.Text <> "" Or nit <> "") Then
            cargar_consulta()
        Else
            MessageBox.Show("Seleccione al menos 1 item a consultar!", "Correcto!", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
    Private Sub cargar_clientes()
        Dim sql As String = "Select nit,nombres,ciudad FROM terceros "
        Dim whereSql As String = "WHERE (concepto_1 = 4 or concepto_1 = 9) "
        If (txt_nit.Text <> "") Then
            whereSql &= " AND nit like '" & txt_nit.Text & "%'"
        ElseIf (txt_nombres.Text <> "") Then
            whereSql &= "AND nombres like '%" & txt_nombres.Text & "%'"
        End If
        sql &= whereSql
        dtg_clientes.DataSource = objOpSimplesLn.listar_datatable(sql, "CORSAN")
    End Sub
    Private Sub txt_nombres_TextChanged(sender As System.Object, e As System.EventArgs) Handles txt_nombres.TextChanged
        carga_comp = False
        txt_nit.Text = ""
        carga_comp = True
        If (carga_comp And txt_nombres.Text.Length > 3) Then
            cargar_clientes()
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

    Private Sub dtg_clientes_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtg_clientes.CellContentClick
        If (e.RowIndex >= 0) Then
            If (dtg_clientes.Columns(e.ColumnIndex).Name = colOk.Name) Then
                carga_comp = False
                cbo_ruta.Text = "Seleccione"
                txt_codigo.Text = ""
                txtNumero.Text = ""
                txt_vend_min.Text = ""
                txt_vend_max.Text = ""
                txt_cliente.Text = ""
                txt_cliente.Text = ""
                nit = ""
                nit = dtg_clientes.Item("nit", 0).Value
                txt_cliente.Text = dtg_clientes.Item("nombres", 0).Value
                groupCliente.Visible = False
                dtg_clientes.DataSource = Nothing
                txt_nit.Text = ""
                txt_nombres.Text = ""
                carga_comp = True
                cargar_consulta()
            End If
        End If
    End Sub

    Private Sub cbo_ruta_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbo_ruta.SelectedIndexChanged
        If (carga_comp) Then
            carga_comp = False
            txt_codigo.Text = ""
            txtNumero.Text = ""
            txt_vend_min.Text = ""
            txt_vend_max.Text = ""
            txt_cliente.Text = ""
            nit = ""
            carga_comp = True
        End If
    End Sub

    Private Sub txt_codigo_TextChanged(sender As System.Object, e As System.EventArgs) Handles txt_codigo.TextChanged
        If (carga_comp) Then
            carga_comp = False
            cbo_ruta.Text = "Seleccione"
            txtNumero.Text = ""
            txt_vend_min.Text = ""
            txt_vend_max.Text = ""
            txt_cliente.Text = ""
            nit = ""
            txt_cliente.Text = ""
            carga_comp = True
        End If
    End Sub

    Private Sub txtNumero_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtNumero.TextChanged
        If (carga_comp) Then
            carga_comp = False
            cbo_ruta.Text = "Seleccione"
            txt_codigo.Text = ""
            txt_vend_min.Text = ""
            txt_vend_max.Text = ""
            txt_cliente.Text = ""
            txt_cliente.Text = ""
            nit = ""
            carga_comp = True
        End If
    End Sub

    Private Sub txt_vend_min_TextChanged(sender As System.Object, e As System.EventArgs) Handles txt_vend_min.TextChanged
        If (carga_comp) Then
            carga_comp = False
            cbo_ruta.Text = "Seleccione"
            txt_codigo.Text = ""
            txtNumero.Text = ""
            txt_cliente.Text = ""
            nit = ""
            txt_cliente.Text = ""
            carga_comp = True
        End If
    End Sub

    Private Sub txt_vend_max_TextChanged(sender As System.Object, e As System.EventArgs) Handles txt_vend_max.TextChanged
        If (carga_comp) Then
            carga_comp = False
            cbo_ruta.Text = "Seleccione"
            txt_codigo.Text = ""
            txtNumero.Text = ""
            txt_cliente.Text = ""
            nit = ""
            txt_cliente.Text = ""
            carga_comp = True
        End If
    End Sub

    Private Sub txt_vend_max_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txt_vend_max.KeyPress
        soloNumero(e)
    End Sub
    
    Private Sub txt_vend_min_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txt_vend_min.KeyPress
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

    Private Sub txt_nit_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txt_nit.KeyPress
        soloNumero(e)
    End Sub

    Private Sub txtNumero_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumero.KeyPress
        soloNumero(e)
    End Sub

    Private Sub Frm_pend_zona_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = 116 Then
            cargar_consulta()
        ElseIf (e.KeyCode = 13) Then
            If (groupCliente.Visible = True) Then
                If (dtg_clientes.RowCount >= 1) Then
                    carga_comp = False
                    cbo_ruta.Text = "Seleccione"
                    txt_codigo.Text = ""
                    txtNumero.Text = ""
                    txt_vend_min.Text = ""
                    txt_vend_max.Text = ""
                    txt_cliente.Text = ""
                    txt_cliente.Text = ""
                    nit = ""
                    nit = dtg_clientes.Item("nit", 0).Value
                    txt_cliente.Text = dtg_clientes.Item("nombres", 0).Value
                    groupCliente.Visible = False
                    dtg_clientes.DataSource = Nothing
                    txt_nit.Text = ""
                    txt_nombres.Text = ""
                    carga_comp = True
                    cargar_consulta()
                End If
            End If

        End If
    End Sub

    Private Sub txt_cliente_MouseClick(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles txt_cliente.MouseClick
        groupCliente.Visible = True
        txt_nombres.Focus()
    End Sub

    Private Sub btn_cerrar_Click(sender As System.Object, e As System.EventArgs) Handles btn_cerrar.Click
        carga_comp = False
        txt_nit.Text = ""
        txt_nombres.Text = ""
        dtg_clientes.DataSource = Nothing
        groupCliente.Visible = False
        carga_comp = True
    End Sub
    Private Sub dtgSinRuta_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dtgSinRuta.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            With (Me.dtgSinRuta)
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                End If
            End With
        End If
    End Sub

    Private Sub itemAsignarRuta_Click(sender As System.Object, e As System.EventArgs) Handles itemAsignarRuta.Click
        If (dtgSinRuta.RowCount > 0) Then
            pais = dtgSinRuta("y_pais", dtgSinRuta.CurrentCell.RowIndex).Value
            ciudad = dtgSinRuta("y_ciudad", dtgSinRuta.CurrentCell.RowIndex).Value
            departamento = dtgSinRuta("y_departamento", dtgSinRuta.CurrentCell.RowIndex).Value
            lblInfoCiudad.Text = dtgSinRuta("ciudad", dtgSinRuta.CurrentCell.RowIndex).Value & "-" & dtgSinRuta("departamento", dtgSinRuta.CurrentCell.RowIndex).Value & "-" & dtgSinRuta("pais", dtgSinRuta.CurrentCell.RowIndex).Value
            GroupAsignarRuta.Visible = True
        End If
    End Sub

    Private Sub btnCerrarAsignar_Click(sender As System.Object, e As System.EventArgs) Handles btnCerrarAsignar.Click
        GroupAsignarRuta.Visible = False
        pais = ""
        ciudad = ""
        departamento = ""
        lblInfoCiudad.Text = ""
        cboRutaAsignar.Text = "Seleccione"
    End Sub
    Private Sub asignarRuta()
        Dim zona As String = cboRutaAsignar.SelectedValue
        Dim sql As String = "UPDATE y_ciudades SET zona = '" & zona & "' WHERE ciudad = '" & ciudad & "' AND pais = '" & pais & "' AND departamento = '" & departamento & "'"
        If (objOpSimplesLn.ejecutar(sql, "CORSAN") > 0) Then
            MessageBox.Show("Ruta asiganada con exito, actualice la consulta", "Correcto!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            dtgSinRuta.CurrentCell = Nothing
            For i = 0 To dtgSinRuta.RowCount - 1
                If (dtgSinRuta("y_ciudad", i).Value = ciudad And dtgSinRuta("y_pais", i).Value = pais Or dtgSinRuta("y_departamento", i).Value = departamento) Then
                    dtgSinRuta.Rows(i).Visible = False
                End If
            Next
        Else
            MessageBox.Show("Error al asignar la ruta, comuniquese con el area de sistemas", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End If

        GroupAsignarRuta.Visible = False
        pais = ""
        ciudad = ""
        departamento = ""
        lblInfoCiudad.Text = ""
        cboRutaAsignar.Text = "Seleccione"
    End Sub

    Private Sub btnOkAsignar_Click(sender As System.Object, e As System.EventArgs) Handles btnOkAsignar.Click
        If Not (pais = "" Or ciudad = "" Or departamento = "") Then
            If (cboRutaAsignar.Text <> "Seleccione") Then
                asignarRuta()
            Else
                MessageBox.Show("Seleccione una ruta a asignar", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            MessageBox.Show("Error al asignar la ruta, comuniquese con el area de sistemas", "]Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
End Class