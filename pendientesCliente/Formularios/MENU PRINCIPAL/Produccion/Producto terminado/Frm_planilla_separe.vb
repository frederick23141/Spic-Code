Imports logicaNegocios
Imports entidadNegocios
Public Class Frm_planilla_separe
    Dim nit_usuario As String
    Dim objTraslado_bodLn As New traslado_bodLn
    Private obj_Ing_prodLn As New Ing_prodLn
    Private objOpSimplesLn As New Op_simpesLn
    Dim cargaComp As Boolean = False
    Private objOrdenProdLn As New OrdenProdLn
    Private objOperacionesForm As OperacionesFormularios = New OperacionesFormularios
    Private id_planilla As Double = 0
    Public Sub Main(ByVal nit As Double)
        Me.nit_usuario = nit
        bloquear_frm_transaccion(False)
    End Sub
    Private Sub Frm_planilla_separe_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Location.X.Equals(10)
        Me.Location.Y.Equals(10)
        habilitarCampos(False)
        txtCodigoLector.Focus()
        cargaComp = True
    End Sub

    Private Sub habilitarCampos(ByVal estado As Boolean)
        txtCodigoLector.Enabled = estado
        dtgItems.Enabled = estado
    End Sub
    Private Sub txtCodigoLector_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigoLector.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            txtCodigoLector.Text = Replace(txtCodigoLector.Text, "'", "-")
            Dim codigo_barras As String = txtCodigoLector.Text
            If validarCodigoBarras(codigo_barras) Then
                Dim codigo As String = extraerDatoCodigoBarras("codigo", codigo_barras)
                Dim cantidad As String = extraerDatoCodigoBarras("cantidad", codigo_barras)
                Dim cajas As Integer = 0
                If (validar_producto_pedido(codigo)) Then
                    add_producto(codigo, cantidad, True, cajas)
                Else
                    Using New Centered_MessageBox(Me)
                        MessageBox.Show("El código no pertenece al pedido", "No pertenece al pedido", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End Using
                End If
            End If
            txtCodigoLector.Text = ""
        ElseIf e.KeyChar = "." Then
            e.KeyChar = "-"
        End If
    End Sub
    Private Function validarCodigoBarras(ByVal codigo_barras As String) As Boolean
        Dim resp As Boolean = False
        Dim codigo As String = extraerDatoCodigoBarras("codigo", codigo_barras)
        Dim cantidad As String = extraerDatoCodigoBarras("cantidad", codigo_barras)
        If codigo <> "" And cantidad <> "" Then
            Dim sql As String = "SELECT codigo FROM referencias WHERE codigo ='" & codigo & "'"
            Dim s_codigo As String = objOpSimplesLn.consultValorTodo(sql, "CORSAN")
            If s_codigo <> "" Then
                resp = True
            End If
        End If
        If resp = False Then
            Using New Centered_MessageBox(Me)
                MessageBox.Show("Intenete leerlo nuevamente", "Problemas código de barras", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Using
            leer_nuevo()
        End If
        Return resp
    End Function
    Public Function extraerDatoCodigoBarras(ByVal dato As String, ByVal codigoBarra As String) As String
        Dim numSeparador As Integer = 0
        Dim contSeparador As Integer = 0
        Dim respuesta As String = ""
        Select Case dato
            Case "codigo"
                numSeparador = 0
            Case "cantidad"
                numSeparador = 1
        End Select
        For i = 0 To codigoBarra.Length - 1
            If (numSeparador = contSeparador) Then
                If (codigoBarra(i) <> "-") Then
                    respuesta &= codigoBarra(i)
                End If
            End If
            If (codigoBarra(i) = "-") Then
                contSeparador += 1
            End If
        Next
        Return respuesta
    End Function
    Private Sub leer_nuevo()
        cargaComp = False
        txtCodigoLector.Text = ""
        txtCodigoLector.ForeColor = Color.DarkGray
        txtCodigoLector.Focus()
        cargaComp = True
    End Sub
    Private Sub txtCodigoLector_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodigoLector.Enter
        txtCodigoLector.BackColor = Color.Green
        txtCodigoLector.Text = ""
    End Sub

    Private Sub txtCodigoLector_Leave(sender As Object, e As EventArgs) Handles txtCodigoLector.Leave
        txtCodigoLector.BackColor = Color.Red
    End Sub
    Private Sub dtg_pedido_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtg_pedido.CellClick
        If (e.RowIndex >= 0) Then
            dtgItems.CurrentCell = Nothing
            dtgItems.DataSource = Nothing
            dtgItems.Rows.Clear()
            tab_ppal.SelectedTab = tab_transaccion
            txtCodigoLector.Focus()
            bloquear_frm_transaccion(True)
            txtCodigoLector.Focus()
            cargar_item_pedido()
            If Not verificarSeparesPendientes() Then
                crear_planilla_separe()
            End If
        End If
    End Sub
    'Private Function validar_pedido_temrinado() As Boolean
    '    Dim sql As String = "SELECT num_ped  FROM J_terminado_planilla_separe WHERE fecha_terminado IS NOT NULL and num_ped =" & txt_num_ped.Text
    '    Dim resp As Boolean = False
    '    If objOpSimplesLn.consultValorTodo(sql, "PRODUCCION") = "" Then
    '        resp = True
    '    End If
    '    Return resp
    'End Function
    Private Sub bloquear_frm_transaccion(ByVal estado As Boolean)
        txtCodigoLector.Enabled = estado
    End Sub

    Private Sub txt_num_ped_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_num_ped.KeyPress
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
    Private Sub txt_num_ped_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_num_ped.TextChanged
        If (cargaComp) Then
            If (Trim(txt_num_ped.Text).Length > 7) Then
                poner_nombre_cliente()
            Else
                imgCed.Image = Spic.My.Resources._1371750041_14125
                Me.Text = "Ingrese número de pedido"
                habilitarCampos(False)
                dtgItems.DataSource = Nothing
            End If

        End If
    End Sub
    Private Sub poner_nombre_cliente()
        Dim nombre As String = objOpSimplesLn.consultarVal("SELECT nombres FROM V_pendientes_por_vendedor WHERE numero = '" & txt_num_ped.Text & "'")
        If (nombre <> "") Then
            imgCed.Image = Spic.My.Resources.ok3
            Me.Text = nombre
            txt_nombres.Text = nombre
            cargar_pedidos()
            habilitarCampos(True)
        Else
            imgCed.Image = Spic.My.Resources._1371750041_14125
            Me.Text = "Ingrese nit"
            habilitarCampos(False)
            dtgItems.DataSource = Nothing
        End If
    End Sub
    Private Sub cargar_pedidos()
        Dim sql As String = "SELECT  nombres,nit,numero " & _
                              "FROM V_pendientes_por_vendedor " & _
                                  "WHERE numero = " & txt_num_ped.Text & " " & _
                                    "GROUP BY numero,nombres,nit"

        dtg_pedido.DataSource = objOpSimplesLn.listar_datatable(sql, "CORSAN")
    End Sub
    Private Sub cargar_item_pedido()
        Dim tamano_letra As Single = 7.5!
        Dim sql As String = "SELECT  codigo,pendiente As Ped,conversion As conv " & _
                                "FROM V_pendientes_por_vendedor " & _
                                    "WHERE numero = " & txt_num_ped.Text
        Dim dt As DataTable = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        dt.Columns.Add("Mov", GetType(Double))
        dt.Columns.Add("Car", GetType(Double))
        dt.Columns.Add("Pen", GetType(Double))
        dt.Columns.Add("Caj", GetType(Double))
        dt.Columns.Add("Kg", GetType(Double))
        dtgItems.DataSource = dt
        dtgItems.Columns("Mov").DefaultCellStyle = objOperacionesForm.formatoNegrita(tamano_letra)
        dtgItems.Columns("Car").DefaultCellStyle = objOperacionesForm.formatoNegrita(tamano_letra)
        dtgItems.Columns("Pen").DefaultCellStyle = objOperacionesForm.formatoNegrita(tamano_letra)
        dtgItems.Columns("conv").Visible = False
        dtgItems.Columns("codigo").ReadOnly = True
        dtgItems.Columns("Ped").ReadOnly = True
        dtgItems.Columns("Car").ReadOnly = True
        dtgItems.Columns("Pen").ReadOnly = True
        dtgItems.Columns("Kg").ReadOnly = True
        dtgItems.Columns("Ped").ReadOnly = True
        dtgItems.Columns("Mov").ReadOnly = False
        dtgItems.Columns("Pen").DefaultCellStyle.BackColor = Color.Red
    End Sub
    Private Function validar_producto_pedido(ByVal codigo As String) As Boolean
        Dim resp As Boolean = False
        For i = 0 To dtgItems.Rows.Count - 1
            If dtgItems.Item("codigo", i).Value = codigo Then
                resp = True
                i = dtgItems.Rows.Count - 1
            End If
        Next
        Return resp
    End Function
    Private Sub add_producto(ByVal codigo As String, ByVal cantidad As Double, ByVal guardar As Boolean, ByVal cajas As Integer)
        Dim kilos As Double = 0
        For i = 0 To dtgItems.Rows.Count - 1
            If dtgItems.Item("codigo", i).Value = codigo Then
                If guardar Then
                    If IsNumeric(dtgItems.Item("Mov", i).Value) Then
                        dtgItems.Item("Mov", i).Value += 1
                    Else
                        dtgItems.Item("Mov", i).Value = 1
                    End If
                End If
                If IsNumeric(dtgItems.Item("Car", i).Value) Then
                    dtgItems.Item("Car", i).Value += cantidad
                Else
                    dtgItems.Item("Car", i).Value = cantidad
                End If
                If IsNumeric(dtgItems.Item("Caj", i).Value) Then
                    dtgItems.Item("Caj", i).Value += cajas
                Else
                    dtgItems.Item("Caj", i).Value = cajas
                End If
                If IsNumeric(dtgItems.Item("Kg", i).Value) Then
                    dtgItems.Item("Kg", i).Value += (cantidad * dtgItems.Item("conv", i).Value)
                Else
                    dtgItems.Item("Kg", i).Value = (cantidad * dtgItems.Item("conv", i).Value)
                End If
                dtgItems.Item("Pen", i).Value = dtgItems.Item("Ped", i).Value - dtgItems.Item("Car", i).Value
                If dtgItems.Item("Pen", i).Value = 0 Then
                    dtgItems.Item("Pen", i).Style.BackColor = Color.Green
                End If
                If guardar Then
                    Dim sql As String = "UPDATE J_terminado_planilla_separe_det SET cantidad += " & cantidad & " " & _
                                    "WHERE id_planilla = " & id_planilla & " AND num_ped =" & txt_num_ped.Text & " AND codigo = '" & codigo & "'"
                    If objOpSimplesLn.ejecutar(sql, "PRODUCCION") > 0 Then
                        Using New Centered_MessageBox(Me)
                            MessageBox.Show("Producto agregado en forma correcta", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End Using
                    Else
                        Using New Centered_MessageBox(Me)
                            MessageBox.Show("Error al agregar el producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Using
                    End If
                End If

            End If
        Next

    End Sub

    Private Sub btn_terminar_Click(sender As Object, e As EventArgs) Handles btn_terminar.Click
        If txt_num_ped.Text <> "" Then
            temirnar_separe()
        End If
    End Sub
    Private Sub temirnar_separe()
        Dim sql As String = "UPDATE J_terminado_planilla_separe SET fecha_terminado = GETDATE() WHERE num_ped =" & txt_num_ped.Text
        If objOpSimplesLn.ejecutar(sql, "PRODUCCION") > 0 Then
            Using New Centered_MessageBox(Me)
                MessageBox.Show("El separe finalizó en forma correcta", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                nuevo()
            End Using
        Else
            Using New Centered_MessageBox(Me)
                MessageBox.Show("Error al terminar la planilla de separe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Using
        End If
    End Sub
    Private Sub nuevo()
        txt_nombres.Text = ""
        txt_num_ped.Text = ""
        txtCodigoLector.Text = ""
        dtg_pedido.DataSource = Nothing
        dtgItems.DataSource = Nothing
        tab_ppal.SelectedTab = tab_ped
        habilitarCampos(False)
    End Sub
    Private Sub crear_planilla_separe()
        Using New Centered_MessageBox(Me)
            Dim sql_id_planilla As String = "SELECT (CASE	 WHEN max(id_planilla) IS NULL THEN 1 ELSE max(id_planilla)+1 END) " & _
                                                   "FROM J_terminado_planilla_separe"
            id_planilla = objOpSimplesLn.consultValorTodo(sql_id_planilla, "PRODUCCION")
            Dim sql As String = "INSERT INTO J_terminado_planilla_separe (id_planilla,num_ped,nit_empleado,fecha) " & _
                                    "VALUES(" & id_planilla & "," & txt_num_ped.Text & "," & nit_usuario & ",GETDATE())"
            Dim sql_detalle As String = "INSERT INTO J_terminado_planilla_separe_det (id_planilla,num_ped,codigo,cantidad) " & _
                                    "VALUES(" & id_planilla & "," & txt_num_ped.Text & ""
            Dim list_sql As New List(Of Object)
            Dim cantidad As Double = 0
            list_sql.Add(sql)
            For i = 0 To dtgItems.Rows.Count - 1
                If IsDBNull(dtgItems.Item("Car", i).Value) Then
                    cantidad = 0
                End If
                If IsNothing(dtgItems.Item("Car", i).Value) Then
                    cantidad = 0
                End If
                sql = sql_detalle & ",'" & dtgItems.Item("codigo", i).Value & "'," & cantidad & ")"
                list_sql.Add(sql)
            Next
            If objOpSimplesLn.ExecuteSqlTransactionTodo(list_sql, "PRODUCCION") Then
                act_nom_Ventana()
            Else
                Using New Centered_MessageBox(Me)
                    MessageBox.Show("Erorr al crear la planilla de separe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Using

            End If
        End Using
    End Sub
    Private Function verificarSeparesPendientes() As Boolean
        Dim resp As Boolean = False
        Using New Centered_MessageBox(Me)
            Dim sql As String = "SELECT c.num_ped , c.id_planilla " & _
                                    "FROM J_terminado_planilla_separe c " & _
                                        "WHERE fecha_terminado is null AND c.num_ped =" & txt_num_ped.Text
            Dim dt As DataTable = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")
            Dim num_ped As String = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")
            For i = 0 To dt.Rows.Count - 1
                num_ped = dt.Rows(i).Item("num_ped")
                id_planilla = dt.Rows(i).Item("id_planilla")
                act_nom_Ventana()
            Next
            If num_ped <> "" Then
                dtgItems.CurrentCell = Nothing
                MessageBox.Show("Tiene una separe pendiente por cerrar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
                cargar_planilla(num_ped)
                resp = True
            End If
        End Using
        Return resp
    End Function
    Private Sub act_nom_Ventana()
        Me.Text = "PLANILA # " & id_planilla
        tab_transaccion.Text = "PLANILA # " & id_planilla
    End Sub
    Private Sub cargar_planilla(ByVal numero_ped As Double)
        Using New Centered_MessageBox(Me)
            Dim sql As String = "SELECT c.id_planilla,c.num_ped,c.codigo,c.cantidad,c.cajas " & _
                                    "FROM J_terminado_planilla_separe_det c " & _
                                        "WHERE c.id_planilla = " & id_planilla & " AND c.num_ped=" & numero_ped
            Dim dt As DataTable = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")
            Dim cantidad As Double = 0
            Dim cajas As Double = 0
            If dt.Rows.Count > 0 Then
                For i = 0 To dt.Rows.Count - 1
                    If IsNumeric(dt.Rows(i).Item("cantidad")) Then
                        cantidad = dt.Rows(i).Item("cantidad")
                    End If
                    If IsNumeric(dt.Rows(i).Item("cajas")) Then
                        cajas = dt.Rows(i).Item("cajas")
                    End If
                    add_producto(dt.Rows(i).Item("codigo"), cantidad, False, cajas)
                Next
                tab_ppal.SelectedTab = tab_transaccion
                txtCodigoLector.Focus()
            End If
        End Using
    End Sub
    Private Sub Frm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Dim cerrar As Boolean = False
        Dim iResponce = 0
        Using New Centered_MessageBox(Me)
            iResponce = MessageBox.Show("Seguro que desea salir?", "Atención", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
        End Using
        If iResponce = 6 Then
            cerrar = True
        End If
        If cerrar Then
            Dim frm As New Frm_ppal_alambron
            frm.Show()
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub dtgItems_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dtgItems.CellValueChanged
        If e.RowIndex >= 0 Then
            If dtgItems.Columns(e.ColumnIndex).Name = "Caj" Then
                If IsNumeric(dtgItems.Item(e.ColumnIndex, e.RowIndex).Value) Then
                    Dim codigo As String = dtgItems.Item("codigo", e.RowIndex).Value
                    Dim sql As String = "UPDATE J_terminado_planilla_separe_det SET cajas = " & dtgItems.Item(e.ColumnIndex, e.RowIndex).Value & " WHERE num_ped =" & txt_num_ped.Text & " AND codigo = '" & codigo & "'"
                    If objOpSimplesLn.ejecutar(sql, "PRODUCCION") = 0 Then
                        Using New Centered_MessageBox(Me)
                            MessageBox.Show("Error al agregar el producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Using
                    End If
                Else
                    Using New Centered_MessageBox(Me)
                        MessageBox.Show("El dato ingresado debe ser númerico", "Ingrese solo números", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Using
                End If
            End If
        End If
    End Sub
End Class