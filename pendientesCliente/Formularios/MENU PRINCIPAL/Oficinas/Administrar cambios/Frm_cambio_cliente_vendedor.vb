Imports logicaNegocios
Public Class Frm_cambio_cliente_vendedor
    Private objIngProdLn As New Ing_prodLn
    Private objOpSimplesLn As New Op_simpesLn
    Dim carga_comp As Boolean = False
    Private objOp_simpesLn As New Op_simpesLn

    Private Sub Frm_cambio_clientevendedor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarCbo()
        carga_comp = True
    End Sub
    Private Sub cargarCbo()
        Dim sql As String = "SELECT vendedor,nombre_vendedor,bloqueo, (CONVERT (VARCHAR, vendedor) + '--' + nombre_vendedor) AS dato" &
                                    " From v_vendedores" &
                                        " Where bloqueo = 0 And vendedor >= 1001 And vendedor <= 1099 Order By vendedor"
        Dim dt2 As New DataTable
        Dim row As DataRow
        dt2 = New DataTable
        dt2 = objIngProdLn.listar_datatable(sql, "CORSAN")
        row = dt2.NewRow
        row("vendedor") = 0
        row("dato") = "Seleccione"
        dt2.Rows.Add(row)
        cbo_vend_origen.DataSource = dt2
        cbo_vend_origen.ValueMember = "vendedor"
        cbo_vend_origen.DisplayMember = "dato"
        cbo_vend_origen.Text = "Seleccione"
        cbo_vend_origen.SelectedValue = 0

        dt2 = New DataTable
        dt2 = objIngProdLn.listar_datatable(sql, "CORSAN")
        row = dt2.NewRow
        row("vendedor") = 0
        row("dato") = "Seleccione"
        dt2.Rows.Add(row)
        cbo_vend_dest.DataSource = dt2
        cbo_vend_dest.ValueMember = "vendedor"
        cbo_vend_dest.DisplayMember = "dato"
        cbo_vend_dest.Text = "Seleccione"
        cbo_vend_dest.SelectedValue = 0
    End Sub
    Private Sub btn_buscar_cliente_Click(sender As Object, e As EventArgs) Handles btn_buscar_cliente.Click
        cbo_vend_origen.Enabled = False
        cbo_vend_origen.SelectedValue = 0

        txtCliente.Text = ""
        txt_nombres.Text = ""
        txt_nit.Text = ""
        dtg_clientes.DataSource = Nothing
        groupCliente.Visible = True
        txt_nombres.Focus()

        group_vendedores.Enabled = False
        group_accion.Enabled = False
        groupCliente.Visible = True

        txtOrg.Text = ""
    End Sub
    Private Sub txt_nombres_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_nombres.TextChanged
        carga_comp = False
        txt_nit.Text = ""
        carga_comp = True
        If (carga_comp And txt_nombres.Text.Length > 3) Then
            cargar_clientes()
        End If
    End Sub
    Private Sub txt_nit_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_nit.TextChanged
        carga_comp = False
        txt_nombres.Text = ""
        carga_comp = True
        If (carga_comp And txt_nit.Text.Length > 2) Then
            cargar_clientes()
        End If
    End Sub
    Private Sub cargar_clientes()
        Dim sql As String = "Select nit AS NIT, nombres AS Cliente, vendedor AS Vendedor FROM terceros "
        Dim whereSql As String = "WHERE (concepto_1 like '%3%' or concepto_1 like '%4%' or concepto_1 like '%9%') " &
                                    "AND vendedor >=1001 And vendedor <= 1099 "
        If (txt_nit.Text <> "") Then
            whereSql &= " And nit Like '" & txt_nit.Text & "%'"
        ElseIf (txt_nombres.Text <> "") Then
            whereSql &= "AND nombres like '%" & txt_nombres.Text & "%'"
        End If
        sql &= whereSql
        dtg_clientes.DataSource = objOpSimplesLn.listar_datatable(sql, "CORSAN")
    End Sub
    Private Sub cargar_vend_org()
        Dim sql As String = "Select nit AS NIT, nombres AS Cliente, vendedor AS Vendedor FROM terceros "
        Dim whereSql As String = "WHERE (vendedor >=1001 And vendedor <= 1099) AND vendedor = " & cbo_vend_origen.SelectedValue
        sql &= whereSql
        dtg_clientes_ven_org.DataSource = objOpSimplesLn.listar_datatable(sql, "CORSAN")
    End Sub
    Private Sub dtg_clientes_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtg_clientes.CellContentClick
        If (e.RowIndex >= 0) Then
            If (dtg_clientes.Columns(e.ColumnIndex).Name = colOk.Name) Then
                txtCliente.Text = ""
                txtCliente.Text = dtg_clientes.Item("nit", e.RowIndex).Value
                txtOrg.Text = ""
                txtOrg.Text = dtg_clientes.Item("vendedor", e.RowIndex).Value
                groupCliente.Visible = False
                dtg_clientes.DataSource = Nothing
                txt_nit.Text = ""
                txt_nombres.Text = ""
                group_accion.Enabled = True
                group_vendedores.Enabled = True
                cbo_vend_dest.Enabled = True
            End If
        End If
    End Sub
    Private Sub btn_cerrar_Click(sender As Object, e As EventArgs) Handles btn_cerrar.Click
        groupCliente.Visible = False
        group_accion.Enabled = True
        group_vendedores.Enabled = True
        cbo_vend_origen.Enabled = True
        cbo_vend_origen.SelectedValue = 0
    End Sub
    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        limpiar()
    End Sub
    Private Sub cbo_vend_origen_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbo_vend_origen.SelectionChangeCommitted
        If (cbo_vend_origen.SelectedValue = 0) Then
            limpiar()
        Else
            txtOrg.Text = cbo_vend_origen.SelectedValue

            cargar_vend_org()
            btn_buscar_cliente.Enabled = False
            group_accion.Enabled = True
            cbo_vend_dest.Enabled = True
        End If
    End Sub
    Private Sub limpiar()
        groupCliente.Visible = False
        group_vendedores.Enabled = True
        cbo_vend_origen.Enabled = True
        cbo_vend_origen.SelectedValue = 0
        cbo_vend_dest.SelectedValue = 0
        txtCliente.Text = ""
        dtg_clientes_ven_org.DataSource = Nothing
        btn_buscar_cliente.Enabled = True
        group_accion.Enabled = False
        txtOrg.Text = ""
        txtDest.Text = ""
        cbo_vend_dest.Enabled = False
        chk_cartera.Checked = True
        chk_clientes.Checked = True
        chk_pendientes.Checked = True
    End Sub
    Private Sub cbo_vend_dest_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbo_vend_dest.SelectionChangeCommitted
        txtDest.Text = cbo_vend_dest.SelectedValue
    End Sub
    Private Sub btn_actualizar_Click(sender As Object, e As EventArgs) Handles btn_actualizar.Click

        If (cbo_vend_dest.SelectedValue <> 0) Then
            imgProcesar.Visible = True
            If (txtCliente.Text <> "" And cbo_vend_origen.SelectedValue = 0) Then
                cliente_espesifico()
            End If
            If (cbo_vend_origen.SelectedValue <> 0 And txtCliente.Text = "") Then
                clientes_vendedor()
            End If
            imgProcesar.Visible = False
        Else
            MessageBox.Show("Debe seleccionar un vendedor de destino! ", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub
    Private Sub clientes_vendedor()
        If (chk_cartera.Checked = True Or chk_clientes.Checked = True Or chk_pendientes.Checked = True) Then
            Dim resp As Integer = MessageBox.Show("Desea realizar los cambios?", "Traslado", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
            Dim sql As String
            Dim listSql As New List(Of Object)
            If resp = 6 Then

                If (chk_pendientes.Checked = True) Then
                    sql = "UPDATE documentos_ped SET vendedor = " & cbo_vend_dest.SelectedValue &
                            " WHERE numero IN (SELECT numero FROM V_pendientes_por_vendedor  " &
                                "WHERE vendedor = " & cbo_vend_origen.SelectedValue & " GROUP BY numero) and vendedor = " & cbo_vend_origen.SelectedValue
                    listSql.Add(sql)
                End If
                If (chk_clientes.Checked = True) Then
                    sql = "UPDATE terceros SET vendedor = " & cbo_vend_dest.SelectedValue & " WHERE vendedor = " & cbo_vend_origen.SelectedValue
                    listSql.Add(sql)
                End If
                If (chk_cartera.Checked = True) Then
                    Dim sql_cartera As String = "SELECT tipo,numero " &
                                                    "FROM v_cartera_edades_jjv " &
                                                          "WHERE saldo>0 AND vendedor = " & cbo_vend_origen.SelectedValue
                    Dim dt As DataTable = objOpSimplesLn.listar_datatable(sql_cartera, "CORSAN")
                    Dim sql_plantilla_doc As String = "UPDATE   documentos " &
                                                            "SET vendedor = " & cbo_vend_dest.SelectedValue & " " &
                                                                "WHERE "
                    Dim sql_plantilla_doc_lin As String = "UPDATE   documentos_lin " &
                                                            "SET vendedor = " & cbo_vend_dest.SelectedValue & " " &
                                                                "WHERE "
                    For i = 0 To dt.Rows.Count - 1
                        listSql.Add(sql_plantilla_doc & "tipo = '" & dt.Rows(i).Item("tipo") & "' AND numero = " & dt.Rows(i).Item("numero"))
                        listSql.Add(sql_plantilla_doc_lin & "tipo = '" & dt.Rows(i).Item("tipo") & "' AND numero = " & dt.Rows(i).Item("numero"))
                    Next

                End If
                If (objOp_simpesLn.ExecuteSqlTransactionTodo(listSql, "CORSAN")) Then
                    MessageBox.Show("Registro  en forma correcta", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    limpiar()
                Else
                    MessageBox.Show("Eror al eliminar el registro, comuniquese con el administrador del sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

            End If

        Else
            MessageBox.Show("Debe seleccionar almenos una opcion! ", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Private Sub cliente_espesifico()
        If (chk_cartera.Checked = True Or chk_clientes.Checked = True Or chk_pendientes.Checked = True) Then
            Dim resp As Integer = MessageBox.Show("Desea realizar los cambios?", "Traslado", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
            Dim sql As String
            Dim listSql As New List(Of Object)
            If resp = 6 Then

                If (chk_pendientes.Checked = True) Then
                    sql = "UPDATE documentos_ped Set vendedor =" & cbo_vend_dest.SelectedValue &
                            " WHERE numero In (Select numero FROM V_pendientes_por_vendedor" &
                                " WHERE nit =" & txtCliente.Text & " GROUP BY numero) And nit =" & txtCliente.Text
                    listSql.Add(sql)
                End If
                If (chk_clientes.Checked = True) Then
                    sql = "UPDATE terceros Set vendedor = " & cbo_vend_dest.SelectedValue & " WHERE nit = " & txtCliente.Text
                    listSql.Add(sql)
                End If
                If (chk_cartera.Checked = True) Then
                    Dim sql_cartera As String = "SELECT tipo,numero " &
                                              "FROM v_cartera_edades_jjv " &
                                                    "WHERE saldo>0 AND nit = " & txtCliente.Text
                    Dim dt As DataTable = objOpSimplesLn.listar_datatable(sql_cartera, "CORSAN")
                    Dim sql_plantilla_doc As String = "UPDATE   documentos " &
                                                            "SET vendedor = " & cbo_vend_dest.SelectedValue & " " &
                                                                "WHERE "
                    Dim sql_plantilla_doc_lin As String = "UPDATE   documentos_lin " &
                                                            "SET vendedor = " & cbo_vend_dest.SelectedValue & " " &
                                                                "WHERE "
                    For i = 0 To dt.Rows.Count - 1
                        listSql.Add(sql_plantilla_doc & "tipo = '" & dt.Rows(i).Item("tipo") & "' AND numero = " & dt.Rows(i).Item("numero"))
                        listSql.Add(sql_plantilla_doc_lin & "tipo = '" & dt.Rows(i).Item("tipo") & "' AND numero = " & dt.Rows(i).Item("numero"))
                    Next
                End If
                If (objOp_simpesLn.ExecuteSqlTransactionTodo(listSql, "CORSAN")) Then
                    MessageBox.Show("Registro  en forma correcta", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    limpiar()
                Else
                    MessageBox.Show("Eror al eliminar el registro, comuniquese con el administrador del sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

            End If
        Else
            MessageBox.Show("Debe seleccionar almenos una opcion! ", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
End Class