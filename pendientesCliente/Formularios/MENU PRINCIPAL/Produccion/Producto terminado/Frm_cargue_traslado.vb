Imports logicaNegocios
Imports entidadNegocios
Public Class Frm_cargue_traslado
    Dim nit_usuario As String
    Dim objTraslado_bodLn As New traslado_bodLn
    Private obj_Ing_prodLn As New Ing_prodLn
    Private objOpSimplesLn As New Op_simpesLn
    Dim cargaComp As Boolean = False
    Private objOrdenProdLn As New OrdenProdLn
    Dim num_fact As Double = 0
    Dim placa As String = ""
    Dim id_cargue As Double = 0
    Private objOperacionesForm As OperacionesFormularios = New OperacionesFormularios
    Public Sub Main(ByVal nit As Double)
        Me.nit_usuario = nit
        bloquear_frm_transaccion(False)
        verificarCarguesPendientes()
    End Sub
    Private Sub Frm_cargue_traslado_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Location.X.Equals(10)
        Me.Location.Y.Equals(10)
        habilitarCampos(False)
        txtCodigoLector.Focus()
        cargaComp = True
    End Sub

    Private Sub habilitarCampos(ByVal estado As Boolean)
        txtCodigoLector.Enabled = estado
        dtgConsulta.Enabled = estado
    End Sub
    Private Sub txtCodigoLector_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigoLector.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            Dim codigo_barras As String = txtCodigoLector.Text
            If validarCodigoBarras(codigo_barras) Then
                Dim codigo As String = extraerDatoCodigoBarras("codigo", codigo_barras)
                Dim lote As String = extraerDatoCodigoBarras("lote", codigo_barras)
                Dim consecutivo As String = extraerDatoCodigoBarras("consecutivo", codigo_barras)
                If validarProductoConTransaacion(codigo, lote, consecutivo) Then
                    If validarProductoConTransaacion(codigo, lote, consecutivo) Then
                        If (validar_producto_pedido(codigo)) Then
                            If validar_cantidad((codigo)) Then
                                add_producto(codigo, lote, consecutivo)
                            End If
                        End If
                    End If
                End If
            End If
        ElseIf e.KeyChar = "." Then
            e.KeyChar = "-"
        End If
    End Sub
    Private Function validarProductoConTransaacion(ByVal codigo As Double, ByVal lote As Double, ByVal consecutivo As Double) As Boolean
        Dim resp As Boolean = False
        Dim sql As String = "SELECT peso FROM J_terminado_productos " & _
                                  " WHERE transaccion IS NULL AND codigo ='" & codigo & "' AND lote = " & lote & " AND consecutivo=" & consecutivo
        Dim peso As String = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")
        If peso <> "" Then
            resp = True
        End If
        Return resp
    End Function
    Private Function validarCodigoBarras(ByVal codigo_barras As String) As Boolean
        Dim resp As Boolean = False
        Dim codigo As String = extraerDatoCodigoBarras("codigo", codigo_barras)
        Dim lote As String = extraerDatoCodigoBarras("lote", codigo_barras)
        Dim consecutivo As String = extraerDatoCodigoBarras("consecutivo", codigo_barras)
        If codigo <> "" And lote <> "" And consecutivo <> "" Then
            Dim sql As String = "SELECT codigo FROM J_terminado_productos WHERE codigo ='" & codigo & "' AND lote = " & lote & " AND consecutivo = " & consecutivo & " "
            Dim id As String = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")
            If id <> "" Then
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
            Case "lote"
                numSeparador = 1
            Case "consecutivo"
                numSeparador = 2
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
    Private Sub contar_movimientos()
        Dim cant As Integer = 0
        For i = 0 To dtgConsulta.RowCount - 1
            cant += 1
        Next
        lbl_movimientos.Text = cant
    End Sub

    Private Sub txtCodigoLector_Leave(sender As Object, e As EventArgs) Handles txtCodigoLector.Leave
        txtCodigoLector.BackColor = Color.Red
    End Sub
    Private Sub dtg_pedido_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtg_pedido.CellContentClick
        If (e.RowIndex >= 0) Then
            tab_ppal.SelectedTab = tab_transaccion
            txtCodigoLector.Focus()
            bloquear_frm_transaccion(True)
            txtCodigoLector.Focus()
            num_fact = dtg_pedido.Item("numero", e.RowIndex).Value
            If crear_planilla_cargue() Then
                cargar_item_factura()
            End If
        End If
    End Sub
    Private Sub bloquear_frm_transaccion(ByVal estado As Boolean)
        txtCodigoLector.Enabled = estado
    End Sub

    Private Sub txt_nit_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_nit.KeyPress
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
    Private Sub txt_nit_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_nit.TextChanged
        If (cargaComp) Then
            If (Trim(txt_nit.Text).Length > 4) Then
                poner_nombre_cliente()
            Else
                imgCed.Image = Spic.My.Resources._1371750041_14125
                Me.Text = "Ingrese nit"
                habilitarCampos(False)
                dtgConsulta.DataSource = Nothing
            End If

        End If
    End Sub
    Private Sub poner_nombre_cliente()
        Dim nombre As String = objOpSimplesLn.consultarVal("SELECT nombres FROM terceros WHERE nit = '" & txt_nit.Text & "'")
        If (nombre <> "") Then
            nit_usuario = txt_nit.Text
            imgCed.Image = Spic.My.Resources.ok3
            Me.Text = nombre
            txt_nombres.Text = nombre
            habilitarCampos(True)
        Else
            imgCed.Image = Spic.My.Resources._1371750041_14125
            Me.Text = "Ingrese nit"
            habilitarCampos(False)
            dtgConsulta.DataSource = Nothing
        End If
    End Sub
    Private Sub cargar_facturas(ByVal nit As Double)
        Dim sql As String = "SELECT TOP(10)d.tipo,d.numero ,d.fecha_hora " & _
                            "FROM documentos d , terceros t " & _
                                "WHERE t.nit = d.nit And d.nit = " & nit & " " & _
                                    "ORDER BY numero desc"
        dtgConsulta.DataSource = objOpSimplesLn.listar_datatable(sql, "CORSAN")
    End Sub
    Private Sub cargar_item_factura()
        Dim tamano_letra As Single = 8.0!
        Dim sql As String = "SELECT  codigo,cantidad " & _
                                "FROM documentos_lin " & _
                                    "WHERE tipo = 'FACT' AND numero = " & num_fact
        Dim dt As DataTable = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        dt.Columns.Add("cargado", GetType(Double))
        dt.Columns.Add("pendiente", GetType(Double))
        dtg_pedido.DataSource = dt
        dtg_pedido.Columns("cargado").DefaultCellStyle = objOperacionesForm.formatoNegrita(tamano_letra)
        dtg_pedido.Columns("pendiente").DefaultCellStyle = objOperacionesForm.formatoNegrita(tamano_letra)
        dtg_pedido.Columns("pendiente").DefaultCellStyle.BackColor = Color.Red
    End Sub
    Private Function validar_producto_pedido(ByVal codigo As String) As Boolean
        Dim resp As Boolean = False
        For i = 0 To dtg_pedido.Rows.Count - 1
            If dtg_pedido.Item("codigo", i).Value = codigo Then
                resp = True
                i = dtg_pedido.Rows.Count - 1
            End If
        Next
        Return resp
    End Function
    Private Function validar_cantidad(ByVal codigo As String) As Boolean
        Dim resp As Boolean = True
        For i = 0 To dtg_pedido.Rows.Count - 1
            If dtg_pedido.Item("codigo", i).Value = codigo Then
                If dtg_pedido.Item("cantidad", i).Value = dtg_pedido.Item("cargado", i).Value Then
                    resp = False
                End If
            End If
        Next
        Return resp
    End Function
    Private Sub add_producto(ByVal codigo As String, ByVal lote As String, ByVal consecutivo As String)
        For i = 0 To dtg_pedido.Rows.Count - 1
            If dtg_pedido.Item("codigo", i).Value = codigo Then
                dtg_pedido.Item("cargado", i).Value += 1
                dtg_pedido.Item("pendiente", i).Value = dtg_pedido.Item("cantidad", i).Value - dtg_pedido.Item("cargado", i).Value
                dtg_codigos_cargados.Rows.Add()
                dtg_pedido.Item(col_cod_cargado.Name, i).Value = codigo
                dtg_pedido.Item(col_lote_cargado.Name, i).Value = lote
                dtg_pedido.Item(col_consecutivo_cargado.Name, i).Value = consecutivo
                contar_movimientos()
            End If
        Next

    End Sub

    Private Sub btn_terminar_Click(sender As Object, e As EventArgs) Handles btn_terminar.Click
        temirnar_cargue()
    End Sub
    Private Sub temirnar_cargue()
        Dim sql As String = "UPDATE J_terminado_planilla_cargue SET fecha_terminado = GETDATE() WHERE id =" & id_cargue
        If objOpSimplesLn.ejecutar(sql, "CORSAN") > 0 Then
            Using New Centered_MessageBox(Me)
                MessageBox.Show("El cargue finalizó en forma correcta", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Using
        Else
            Using New Centered_MessageBox(Me)
                MessageBox.Show("Error al terminar la planilla de cargue", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Using
        End If
    End Sub
    Private Sub btn_salir_Click(sender As Object, e As EventArgs) Handles btn_salir.Click
        salir()
    End Sub
    Private Sub salir()
        Dim cerrar As Boolean = False
        If dtgConsulta.Rows.Count = 0 Then
            cerrar = True
        Else
            Dim iResponce = 0
            Using New Centered_MessageBox(Me)
                iResponce = MessageBox.Show("Desea salir sin terminar el cargue?", "Atención", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
            End Using
            If iResponce = 6 Then
                cerrar = True
            End If
        End If
        If cerrar Then
            Dim frm As New Frm_ppal_alambron
            frm.Show()
            Me.Close()
        End If
    End Sub
    Private Sub btn_salir_pedido_Click(sender As Object, e As EventArgs) Handles btn_salir_pedido.Click
        salir()
    End Sub

    Private Sub txt_placa_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_placa.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            If txt_placa.Text <> "" Then
                txt_nit.Enabled = True
                placa = txt_placa.Text
            End If
        End If
    End Sub
    Private Function crear_planilla_cargue() As Boolean
        Dim id As String = objOpSimplesLn.consultValorTodo("SELECT MAX(id)+1 FROM J_terminado_planilla_cargue", "PRODUCCION")
        If id = "" Then
            id = 1
        End If
        Dim sql As String = "INSERT INTO J_terminado_planilla_cargue (id,nit_empleado,placa,fact,nit_cliente,fecha) " & _
                                "VALUES(" & id & "," & nit_usuario & "," & placa & "," & num_fact & "," & txt_nit.Text & ",GETDATE())"
        If objOpSimplesLn.ejecutar(sql, "CORSAN") > 0 Then
            id_cargue = id
            Return True
        Else
            Using New Centered_MessageBox(Me)
                MessageBox.Show("Erorr al crear la planilla de cargue", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Using
            Return True
        End If
    End Function
    Private Sub verificarCarguesPendientes()
        Using New Centered_MessageBox(Me)
            Dim sql As String = "SELECT c.id,p.codigo,p.lote,p.consecutivo,c.placa,c.fact,c.nit_cliente " & _
                                    "FROM J_terminado_planilla_cargue c, J_terminado_productos p " & _
                                        "WHERE c.id = p.id_cargue  and c.fecha_terminado IS NULL AND c.nit_empleado =" & nit_usuario
            Dim dt As DataTable = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")
            If dt.Rows.Count > 0 Then
                dtgConsulta.Rows.Clear()
                MessageBox.Show("Tiene un cargue pendiente por cerrar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
                For i = 0 To dt.Rows.Count - 1
                    If i = 0 Then
                        placa = dt.Rows(i).Item("placa")
                        num_fact = dt.Rows(i).Item("fact")
                        txt_placa.Text = placa
                        txt_nit.Text = dt.Rows(i).Item("nit_cliente")
                        poner_nombre_cliente()
                        id_cargue = dt.Rows(i).Item("id")
                    End If
                    add_producto(dt.Rows(i).Item("codigo"), dt.Rows(i).Item("lote"), dt.Rows(i).Item("placa"))
                Next
                tab_ppal.SelectedTab = tab_transaccion
                txtCodigoLector.Focus()
            End If
        End Using
    End Sub
End Class