Imports logicaNegocios
Imports entidadNegocios
Public Class frm_maestro_fichas2
    Private objOpSimplesLn As New Op_simpesLn
    Private objIngProdLn As New Ing_prodLn
    Dim usuario As UsuarioEn
    Private objOperacionesForm As OperacionesFormularios = New OperacionesFormularios

    'Variables para control de modificaciones y consultas
    Dim clien As Integer = 0

    Dim nue As Integer = 0

    Public Sub main(ByVal usuario As UsuarioEn)
        Me.usuario = usuario
        'If usuario.permiso.Trim = "ADMIN" Or usuario.permiso.Trim = "CALIDAD" Then
        '    btnEdit.Visible = True
        '    btnDelete.Visible = True
        '    btnNuevo.Visible = True
        'Else
        '    btnEdit.Visible = False
        '    btnDelete.Visible = False
        '    btnNuevo.Visible = False
        'End If
    End Sub

    Private Sub frm_maestro_fichas2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim sql As String = "Select nit,nombres  from Jjv_prov_alambron  "
        Dim dt2 As New DataTable
        Dim row As DataRow
        dt2 = New DataTable
        dt2 = objIngProdLn.listar_datatable(sql, "CORSAN")
        row = dt2.NewRow
        row("nit") = 0
        row("nombres") = "Seleccione"
        dt2.Rows.Add(row)
        cboOrigen.DataSource = dt2
        cboOrigen.ValueMember = "nit"
        cboOrigen.DisplayMember = "nombres"
        cboOrigen.Text = "Seleccione"
        cboOrigen.SelectedValue = 0
    End Sub

    Private Sub consultar_fichas()
        Dim sql As String = "SELECT j.codigo,j.resistencia,j.diametro,j.procedencia,j.calidad,j.recubrimiento,j.nit ,t.nombres,J.nota " &
                                " FROM J_referencia_ficha_tec j, CORSAN.dbo.terceros t WHERE (j.nit = t.nit) "
        Dim whereSql As String = ""

        If (txt_codigo_fil.Text <> "") Then
            whereSql &= " AND j.codigo like '%" & txt_codigo_fil.Text & "%'"
        End If

        If txt_cliente_fil.Text <> "" Then
            whereSql &= " AND j.nit ='" & txt_cliente_fil.Text & "'"
        End If
        sql &= whereSql

        Dim dt As DataTable = objOpSimplesLn.crearDataTableVariasCol(sql, "PRODUCCION")
        dtg_fichas.DataSource = dt
    End Sub

    Private Sub btn_consultar_Click(sender As Object, e As EventArgs) Handles btn_consultar.Click
        consultar_fichas()
    End Sub
    'si la variable clien = 1 es por que se va a buscar un cliente para hacer fltro, de lo contrario es para una nueva ficha
    Private Sub btn_buscar_cliente_fil_Click(sender As Object, e As EventArgs) Handles btn_buscar_cliente_fil.Click
        txt_cliente_fil.Text = ""
        groupCliente.Visible = True
        txt_nombres.Focus()
        txt_nombres.Text = ""
        txt_nit.Text = ""
        bloquear_todo()
        clien = 1
    End Sub
    Private Sub btn_buscar_cliente_Click(sender As Object, e As EventArgs) Handles btn_buscar_cliente.Click
        txt_cliente_fil.Text = ""
        groupCliente.Visible = True
        txt_nombres.Focus()
        txt_nombres.Text = ""
        txt_nit.Text = ""
        bloquear_todo()
        clien = 0
    End Sub
    'si la variable clien = 0, al cerrar nos pondra el nit de corsan
    Private Sub btn_cerrar_Click(sender As Object, e As EventArgs) Handles btn_cerrar.Click
        groupCliente.Visible = False
        desbloquear_todo()
        If clien = 0 Then
            txtCliente.Text = "890900160"
        End If
    End Sub
    Private Sub bloquear_todo()
        Toolbar1.Enabled = False
        group_filtro.Enabled = False
        dtg_fichas.Enabled = False
        group_ficha.Enabled = False
    End Sub

    Private Sub desbloquear_todo()
        If clien = 0 Then
            group_ficha.Enabled = True
        Else
            dtg_fichas.Enabled = True
            group_filtro.Enabled = True
            Toolbar1.Enabled = True
        End If
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
    Private Sub txt_nit_TextChanged(sender As Object, e As EventArgs) Handles txt_nit.TextChanged
        txt_nombres.Text = ""
        If (txt_nit.Text.Length > 2 And txt_nombres.Text = "") Then
            cargar_clientes()
        End If
    End Sub

    Private Sub txt_nombres_TextChanged(sender As Object, e As EventArgs) Handles txt_nombres.TextChanged
        txt_nit.Text = ""
        If (txt_nombres.Text.Length > 2 And txt_nit.Text = "") Then
            cargar_clientes()
        End If
    End Sub
    Private Sub dtg_clientes_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtg_clientes.CellClick
        If (e.RowIndex >= 0) Then
            If (dtg_clientes.Columns(e.ColumnIndex).Name = colOk.Name) Then

                If clien = 0 Then
                    txtCliente.Text = dtg_clientes.Item("nit", e.RowIndex).Value
                Else
                    txt_cliente_fil.Text = dtg_clientes.Item("nit", e.RowIndex).Value
                End If
                groupCliente.Visible = False
                dtg_clientes.DataSource = Nothing
                desbloquear_todo()
            End If
        End If
    End Sub
    'si la variable nue = 0, es por que vamos a generar un nuevo registro y si nue = 1 entonces es por que guardamos un registro y limpiaremos campos
    Private Sub nuevo()
        If nue = 0 Then
            dtg_fichas.Enabled = False
            group_filtro.Enabled = False
            group_ficha.Enabled = True
            Toolbar1.Enabled = False
        Else
            dtg_fichas.Enabled = True
            group_filtro.Enabled = True
            group_ficha.Enabled = False
            Toolbar1.Enabled = True
        End If
        txtCodigo.Enabled = True
        txtCodigo.Text = ""
        txtResis.Text = ""
        txtRec.Text = ""
        txtDiametro.Text = ""
        cboOrigen.SelectedValue = 0
        txtCal.Text = ""
        txtCliente.Text = ""
        btn_buscar_cliente.Enabled = True
        txt_nota.Text = ""
    End Sub
    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        nue = 0
        nuevo()
    End Sub
    Private Sub btn_guardar_Click(sender As Object, e As EventArgs) Handles btn_guardar.Click
        If validar_campos() Then
            guardar_ficha()
        End If
    End Sub
    'Valida los campos de una forma que muestre que campos faltan sin necesidad de ventanas emergentes.
    Private Function validar_campos()
        Dim resp As Boolean = False
        Dim val As Integer = 0
        If txtCodigo.Text <> "" Then
            val += 1
            Label12.Visible = False
        Else
            Label12.Visible = True
            Label19.Visible = True
        End If

        If txtResis.Text <> "" Then
            val += 1
            Label13.Visible = False
        Else
            Label13.Visible = True
            Label19.Visible = True
        End If

        If txtDiametro.Text <> "" Then
            val += 1
            Label18.Visible = False
        Else
            Label18.Visible = True
            Label19.Visible = True
        End If

        If cboOrigen.SelectedValue <> 0 Then
            val += 1
            Label15.Visible = False
        Else
            Label15.Visible = True
            Label19.Visible = True
        End If

        If txtCal.Text <> "" Then
            val += 1
            Label16.Visible = False
        Else
            Label16.Visible = True
            Label19.Visible = True
        End If
        If txtCliente.Text <> "" Then
            val += 1
            Label17.Visible = False
        Else
            Label17.Visible = True
            Label19.Visible = True
        End If

        If val = 6 Then
            resp = True
            Label19.Visible = False
        End If
        Return resp
    End Function
    'Valida que la referencia no este registrada para el mismo Cliente
    Private Function validar_existente()
        Dim resp As Boolean = False
        Dim val As String = ""
        Dim sql As String = "SELECT codigo FROM J_referencia_ficha_tec WHERE codigo = '" & txtCodigo.Text & "' AND nit =" & txtCliente.Text
        val = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")

        If val = "" Then
            resp = True
        End If

        Return resp
    End Function

    Private Sub guardar_ficha()
        Dim sql As String = ""
            If validar_existente() Then
            sql = "INSERT INTO J_referencia_ficha_tec (codigo,resistencia,diametro,procedencia,calidad,recubrimiento,nit,nota) VALUES ('" &
                                       txtCodigo.Text & "','" & txtResis.Text & "','" & txtDiametro.Text & "'," & cboOrigen.SelectedValue & ",'" & txtCal.Text & "','" & txtRec.Text & "'," & txtCliente.Text & ",'" & txt_nota.Text & "')"
            If objOpSimplesLn.ejecutar(sql, "PRODUCCION") Then
                    MessageBox.Show("La ficha tecnica de la referencia: '" & txtCodigo.Text & "', para el cliente: '" & txtCliente.Text & "' se creo con exito.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    nue = 1
                    nuevo()
                    consultar_fichas()
                Else
                    MessageBox.Show("Error al Guardar la ficha tecnica Comuniqueese con el administrador del sistema.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                sql = "UPDATE J_referencia_ficha_tec SET resistencia = '" & txtResis.Text & _
                        "',procedencia = '" & cboOrigen.SelectedValue & "',calidad = '" & txtCal.Text & "',recubrimiento = '" & _
                            txtRec.Text & "',nota = '" & txt_nota.Text & "' WHERE codigo = '" & txtCodigo.Text & "' AND nit = '" & txtCliente.Text & "'"

                If objOpSimplesLn.ejecutar(sql, "PRODUCCION") Then
                    MessageBox.Show("La ficha tecnica de la referencia: '" & txtCodigo.Text & "', para el cliente: '" & txtCliente.Text & "' se Modifico con exito.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    nue = 1
                    nuevo()
                    consultar_fichas()
                Else
                    MessageBox.Show("Error al Guardar la ficha tecnica Comuniqueese con el administrador del sistema.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
        End If
    End Sub

    Private Sub dtg_fichas_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtg_fichas.CellClick
        If (e.RowIndex >= 0) Then
            Dim numCol As Integer = e.ColumnIndex
            Dim nombCol As String = dtg_fichas.Columns(numCol).Name
            Dim fila As Integer = e.RowIndex
            Dim listValores As New List(Of String)
            If (nombCol = "btnEdit") Then
                Dim resp As Integer = MessageBox.Show("¿Desea Editar la Ficha Tecnica?", "Editar Ficha", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                If resp = 6 Then
                    txtCodigo.Text = dtg_fichas.Item("codigo", e.RowIndex).Value
                    If Not IsDBNull(dtg_fichas.Item("resistencia", e.RowIndex).Value) Then
                        txtResis.Text = dtg_fichas.Item("resistencia", e.RowIndex).Value
                    End If
                    If Not IsDBNull(dtg_fichas.Item("diametro", e.RowIndex).Value) Then
                        txtDiametro.Text = dtg_fichas.Item("diametro", e.RowIndex).Value
                    End If
                    If Not IsDBNull(dtg_fichas.Item("procedencia", e.RowIndex).Value) Then
                        cboOrigen.SelectedValue = dtg_fichas.Item("procedencia", e.RowIndex).Value
                    End If
                    If Not IsDBNull(dtg_fichas.Item("calidad", e.RowIndex).Value) Then
                        txtCal.Text = dtg_fichas.Item("calidad", e.RowIndex).Value
                    End If
                    If Not IsDBNull(dtg_fichas.Item("recubrimiento", e.RowIndex).Value) Then
                        txtRec.Text = dtg_fichas.Item("recubrimiento", e.RowIndex).Value
                    End If
                    If Not IsDBNull(dtg_fichas.Item("nit", e.RowIndex).Value) Then
                        txtCliente.Text = dtg_fichas.Item("nit", e.RowIndex).Value
                    End If
                    If Not IsDBNull(dtg_fichas.Item("nota", e.RowIndex).Value) Then
                        txt_nota.Text = dtg_fichas.Item("nota", e.RowIndex).Value
                    End If

                    dtg_fichas.Enabled = False
                    group_filtro.Enabled = False
                    Toolbar1.Enabled = False
                    group_ficha.Enabled = True

                    txtCodigo.Enabled = False
                    btn_buscar_cliente.Enabled = False
                End If
            End If
            If (nombCol = "btnDelete") Then
                Dim resp As Integer = MessageBox.Show("¿Desea Borrar la Ficha Tecnica?", "Borrar Ficha", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                If resp = 6 Then
                    Dim sql As String = "DELETE J_referencia_ficha_tec WHERE codigo = '" & dtg_fichas.Item("codigo", e.RowIndex).Value & "' AND nit =" & dtg_fichas.Item("nit", e.RowIndex).Value
                    If objIngProdLn.ejecutar(sql, "PRODUCCION") Then
                        MessageBox.Show("La ficha tecnica de la referencia: '" & dtg_fichas.Item("codigo", e.RowIndex).Value & "', para el cliente: '" & dtg_fichas.Item("nit", e.RowIndex).Value & "' se Borro con exito.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        consultar_fichas()
                    Else
                        MessageBox.Show("Error al Eliminar la ficha tecnica Comuniqueese con el administrador del sistema.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub btn_cancelar_Click(sender As Object, e As EventArgs) Handles btn_cancelar.Click
        nue = 1
        nuevo()
        Label12.Visible = False
        Label13.Visible = False
        Label15.Visible = False
        Label16.Visible = False
        Label17.Visible = False
        Label19.Visible = False
    End Sub

    Private Sub btn_excel_Click(sender As Object, e As EventArgs) Handles btn_excel.Click
        Me.UseWaitCursor = True
        Application.DoEvents()
        objOperacionesForm.exportarExcel(dtg_fichas)
        Me.UseWaitCursor = False
    End Sub
End Class