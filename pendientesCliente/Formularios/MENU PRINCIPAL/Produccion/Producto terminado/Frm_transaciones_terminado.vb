Imports logicaNegocios
Imports entidadNegocios
Public Class Frm_transaciones_terminado
    Dim nit_usuario As String
    Private obj_Ing_prodLn As New Ing_prodLn
    Private objOpSimplesLn As New Op_simpesLn
    Private objTraslado_bodLn As New traslado_bodLn
    Dim cargaComp As Boolean = False
    Private objOrdenProdLn As New OrdenProdLn
    Dim numero_transaccion As Double
    Dim tipo As String
    Dim reiniciar_mov As Boolean = False
    Public Sub Main(ByVal nit As Double, ByVal tipo As String)
        Me.nit_usuario = nit
        Me.tipo = tipo
        bloquear_frm_transaccion(True)
        cargar_operario()
        txtCodigoLector.Enabled = False
        txtCodigoLector.Focus()
        cargaComp = True
    End Sub
    Private Function ingProdDms(ByVal dt As DataTable, ByVal tipo As String) As List(Of Object)
        Dim bodega As String = 1
        Dim dFec As Date = Now
        Dim usuario As String = cbo_operario.SelectedValue
        Dim notas As String = "SPIC fecha:" & Now & " usuario:" & usuario
        numero_transaccion = objOrdenProdLn.mover_consecutivo(tipo)
        Return objTraslado_bodLn.listaTransaccionDatable(numero_transaccion, dt, bodega, dFec, notas, usuario, tipo, "01")
    End Function

    Public Sub addProducto(ByVal codigo As String, ByVal cantidad As Double, ByVal num_transaccion As Double)
        Using New Centered_MessageBox(Me)
            dtgConsulta.Rows.Add()
            Dim i As Integer = dtgConsulta.RowCount - 1
            While (i >= 1)
                dtgConsulta.Item(colCodigo.Name, i).Value = dtgConsulta.Item(colCodigo.Name, i - 1).Value
                dtgConsulta.Item(colCant.Name, i).Value = dtgConsulta.Item(colCant.Name, i - 1).Value
                dtgConsulta.Item(col_num_transaccion.Name, i).Value = dtgConsulta.Item(col_num_transaccion.Name, i - 1).Value
                dtgConsulta.Item(col_tipo.Name, i).Value = dtgConsulta.Item(col_tipo.Name, i - 1).Value
                i -= 1
            End While
            dtgConsulta.Item(colCodigo.Name, 0).Value = codigo
            dtgConsulta.Item(colCant.Name, 0).Value = cantidad
            dtgConsulta.Item(col_tipo.Name, 0).Value = tipo
            dtgConsulta.Item(col_num_transaccion.Name, 0).Value = num_transaccion
            leer_nuevo()
            If reiniciar_mov Then
                lbl_movimientos.Text = (Convert.ToDouble(lbl_movimientos.Text) + 1)
            Else
                contar_movimientos()
            End If
        End Using
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

    Private Sub txtCodigoLector_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigoLector.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            txtCodigoLector.Text = Replace(txtCodigoLector.Text, "'", "-")
            If validarCodigoBarras(txtCodigoLector.Text) Then
                Dim codigo As String = extraerDatoCodigoBarras("codigo", txtCodigoLector.Text)
                Dim cantidad As String = extraerDatoCodigoBarras("cantidad", txtCodigoLector.Text)
                Dim iResponce = 0
                Using New Centered_MessageBox(Me)
                    iResponce = MessageBox.Show(tipo & ": " & codigo & " TOTAL: " & cantidad & "?", "Confirmar transacción", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                End Using
                If iResponce = 6 Then
                    transaccion(codigo, cantidad)
                End If
            End If
        End If
    End Sub
    Private Function validarCodigoBarras(ByVal codigo_barras As String) As Boolean
        Dim resp As Boolean = False
        Dim codigo As String = extraerDatoCodigoBarras("codigo", codigo_barras)
        Dim cantidad As String = extraerDatoCodigoBarras("cantidad", codigo_barras)
        If codigo <> "" And cantidad <> "" Then
            Dim sql As String = "SELECT codigo FROM referencias WHERE codigo ='" & codigo & "'"
            Dim id As String = objOpSimplesLn.consultValorTodo(sql, "CORSAN")
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
    Private Sub leer_nuevo()
        cargaComp = False
        txtCodigoLector.Text = ""
        txtCodigoLector.Focus()
        cargaComp = True
    End Sub
    Private Function ingProdDms(ByVal dt As DataTable) As List(Of Object)
        Dim bodega As String = 3
        Dim dFec As Date = Now
        Dim usuario As String = cbo_operario.SelectedValue
        Dim notas As String = "SPIC fecha:" & Now & " usuario:" & usuario
        numero_transaccion = objOrdenProdLn.mover_consecutivo(tipo)
        Return objTraslado_bodLn.listaTransaccionDatable(numero_transaccion, dt, bodega, dFec, notas, usuario, tipo, "01")
    End Function


    Private Sub txtCodigoLector_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodigoLector.Enter
        txtCodigoLector.BackColor = Color.Green
        txtCodigoLector.Text = ""
    End Sub


    Private Sub txtCodigoLector_Leave(sender As Object, e As EventArgs) Handles txtCodigoLector.Leave
        txtCodigoLector.BackColor = Color.Red
    End Sub


    Private Sub bloquear_frm_transaccion(ByVal estado As Boolean)
        txtCodigoLector.Enabled = estado
    End Sub

    Private Sub transaccion(ByVal codigo As String, ByVal cantidad As Double)
        Dim dt_codigos_valores As New DataTable
        dt_codigos_valores.Columns.Add("codigo")
        dt_codigos_valores.Columns.Add("cantidad", GetType(Double))
        dt_codigos_valores.Rows.Add()
        dt_codigos_valores.Rows(dt_codigos_valores.Rows.Count - 1).Item("codigo") = codigo
        dt_codigos_valores.Rows(dt_codigos_valores.Rows.Count - 1).Item("cantidad") = cantidad
        Dim resp_transaccion As Boolean = False
        resp_transaccion = obj_Ing_prodLn.ExecuteSqlTransaction(ingProdDms(dt_codigos_valores), "CORSAN")
        If resp_transaccion Then
            Using New Centered_MessageBox(Me)
                ' MessageBox.Show("Trsansaccion ingresada con exito," & tipo & ": " & numero_transaccion & "", "" & tipo & ": " & numero_transaccion & "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                addProducto(codigo, cantidad, numero_transaccion)
                leer_nuevo()
            End Using
        Else
            Using New Centered_MessageBox(Me)
                MessageBox.Show("No se encuentran productos para la trensacción", "Sin productos", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Using
        End If
    End Sub

    Private Sub Frm_transaciones_terminado_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
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


    Private Sub chk_todo_CheckedChanged(sender As Object, e As EventArgs) Handles chk_todo.CheckedChanged
        cargar_operario()
    End Sub
    Private Sub cargar_operario()
        Dim sql As String = "SELECT nit,nombres FROM V_nom_personal_Activo_con_maquila "
        Dim where_sql As String = ""
        If chk_todo.Checked Then
            where_sql = "WHERE centro not in (4200) ORDER BY nombres "
        Else
            where_sql = "WHERE centro = 2600  ORDER BY nombres "
        End If
        sql &= where_sql
        Dim dt As DataTable = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        dt.Rows.Add()
        dt.Rows(dt.Rows.Count - 1).Item("nit") = 0
        dt.Rows(dt.Rows.Count - 1).Item("nombres") = "SELECCIONE EMPACADOR"
        cbo_operario.DataSource = dt
        cbo_operario.ValueMember = "nit"
        cbo_operario.DisplayMember = "nombres"
        cbo_operario.SelectedValue = 0
    End Sub

    Private Sub cbo_operario_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbo_operario.SelectedIndexChanged
        If cargaComp Then
            dtgConsulta.Rows.Clear()
            contar_movimientos()
            If cbo_operario.SelectedValue <> 0 Then
                txtCodigoLector.Enabled = True
                txtCodigoLector.Focus()
            Else
                txtCodigoLector.Enabled = False
            End If
        End If
    End Sub

    Private Sub cbo_operario_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbo_operario.KeyPress
        e.Handled = True
    End Sub
    Private Sub contar_movimientos()
        reiniciar_mov = False
        Dim cant As Integer = 0
        For i = 0 To dtgConsulta.RowCount - 1
            cant += 1
        Next
        lbl_movimientos.Text = cant
    End Sub

    Private Sub btn_reiniciar_contador_Click(sender As Object, e As EventArgs) Handles btn_reiniciar_contador.Click
        reiniciar_mov = True
        lbl_movimientos.Text = "0"
        txtCodigoLector.Focus()
    End Sub
End Class