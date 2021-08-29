Imports logicaNegocios
Imports entidadNegocios
Public Class Frm_gestionar_no_conforme
    Private objOpSimplesLn As New Op_simpesLn
    Dim nit As New Double
    Dim objTraslado_bodLn As New traslado_bodLn
    Dim obj_Ing_prodLn As New Ing_prodLn
    Dim numero_transaccion As Double = 0
    Dim objOrdenProdLn As New OrdenProdLn
    Dim carga_comp As Boolean = False
    Public Sub MAIN(ByVal nit As Integer)
        Me.nit = nit
        cargar_cbo()
        carga_comp = True
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
    Private Sub cargar_cbo()
        Dim dt As New DataTable
        dt.Columns.Add("id")
        dt.Columns.Add("descripcion")
        dt.Rows.Add()
        dt.Rows(dt.Rows.Count - 1).Item("id") = 0
        dt.Rows(dt.Rows.Count - 1).Item("descripcion") = "SELECCIONE"
        dt.Rows.Add()
        dt.Rows(dt.Rows.Count - 1).Item("id") = 1
        dt.Rows(dt.Rows.Count - 1).Item("descripcion") = "Entregar a bodega de producto no conforme, TRB1 mod 13 (3 a 4)"
        'dt.Rows.Add()
        'dt.Rows(dt.Rows.Count - 1).Item("id") = 2
        'dt.Rows(dt.Rows.Count - 1).Item("descripcion") = "Entregar a bodega de proceso, SIP bod 4 - EIPP bod 2 (4 a 2)"
        dt.Rows.Add()
        dt.Rows(dt.Rows.Count - 1).Item("id") = 3
        dt.Rows(dt.Rows.Count - 1).Item("descripcion") = "Salida de no conforme a chatara, SAI2 bod 3"
        dt.Rows.Add()
        dt.Rows(dt.Rows.Count - 1).Item("id") = 4
        dt.Rows(dt.Rows.Count - 1).Item("descripcion") = "Salida de no conforme a chatara, SAI2 bod 4"
        dt.Rows.Add()
        dt.Rows(dt.Rows.Count - 1).Item("id") = 5
        dt.Rows(dt.Rows.Count - 1).Item("descripcion") = "Salida de no conforme a proceso(SOLO SALIDA), SIP bod 4"
        cbo_transaccion.DataSource = dt
        cbo_transaccion.DisplayMember = "descripcion"
        cbo_transaccion.ValueMember = "id"
    End Sub


    Private Sub traslado_bodega_no_conforme()
        Dim tipo As String = "TRB1"
        Dim modelo As String = "13"
        Dim notas As String = "SPIC traslado(HandHeld) " & Now & " usuario: " & nit
        Dim peso As Double = Convert.ToDouble(txt_peso.Text)
        Dim codigo As String = txt_codigo.Text
        Dim bodega As String = objTraslado_bodLn.obtenerBodegaXcodigo(codigo)
        Dim dFec As Date = Now
        Dim usuario As String = nit
        Dim stock As Double = objOpSimplesLn.consultarStock(codigo, bodega)
        Dim sql_costo_unit As String = "SELECT costo_unitario " & _
                                                   "FROM referencias  " & _
                                                          "WHERE codigo='" & codigo & "'"
        Dim costo_unit As Double = objOpSimplesLn.consultValorTodo(sql_costo_unit, "CORSAN")
        'Dim sql_vr_unit As String = "SELECT valor_unitario " & _
        '                                       "FROM referencias  " & _
        '                                              "WHERE codigo=" & codigo
        'Dim vr_unit As Double = objOpSimplesLn.consultValorTodo(sql_costo_unit, "CORSAN")
        If stock >= peso Then
            realizar_transaccion_traslado(codigo, peso, tipo, modelo, costo_unit)
        Else
            Using New Centered_MessageBox(Me)
                MessageBox.Show("No hay stock para reliazar la transacción ", "Sin stock!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Using
        End If
    End Sub
    Public Function realizar_transaccion_traslado(ByVal codigo As String, ByVal peso As Double, ByVal tipo As String, ByVal modelo As String, ByVal costo_unit As Double) As Boolean
        Dim resp As Boolean = True
        Dim listTransaccion_corsan As New List(Of Object)
        Dim sql_solicitud As String = ""
        listTransaccion_corsan = traslado_bodega(codigo, peso, tipo, modelo, costo_unit)
        If obj_Ing_prodLn.ExecuteSqlTransaction(listTransaccion_corsan, "CORSAN") Then
            Using New Centered_MessageBox(Me)
                MessageBox.Show("Transacción realizada con exito! ", tipo & ": " & Convert.ToString(numero_transaccion), MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Using
            add_transaccion(numero_transaccion, tipo, modelo, codigo, peso, "3-4")
        Else
            Using New Centered_MessageBox(Me)
                MessageBox.Show("Error al realizar la transacción! ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Using
            resp = False
        End If
        Return resp
    End Function
    Private Function traslado_bodega(ByVal codigo As String, ByVal cantidad As Double, ByVal tipo As String, ByVal modelo As String, ByVal costo_unit As Double) As List(Of Object)
        Dim listSql As New List(Of Object)
        Dim dFec As Date = Now
        Dim usuario As String = nit
        Dim notas As String = "SPIC fecha:" & Now & " usuario:" & usuario
        Dim bod_origen As Integer = 3
        Dim bod_destino As Integer = 4
        numero_transaccion = objOrdenProdLn.mover_consecutivo(tipo)
        listSql = objTraslado_bodLn.listaTransaccionDatable_traslado_bodega(numero_transaccion, codigo, bod_origen, bod_destino, dFec, notas, usuario, cantidad, tipo, modelo, costo_unit)
        Return listSql
    End Function

    Private Sub btn_guardar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_guardar.Click
        If txt_codigo.Text <> "" And txt_peso.Text <> "" And cbo_transaccion.SelectedValue <> 0 Then
            Dim resp As Integer = 0
            Using New Centered_MessageBox(Me)
                resp = MessageBox.Show("Confirmar transacción " & cbo_transaccion.Text & "? ", "Confirmar tipo de transacción?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
            End Using
            If resp = 6 Then
                Select Case cbo_transaccion.SelectedValue
                    Case 1
                        traslado_bodega_no_conforme()
                    Case 2
                        sacar_no_confome_entrar_proceso()
                    Case 3
                        sacar_3_a_chatarra()
                    Case 4
                        sacar_no_confome_a_chatarra()
                    Case 5
                        sacar_no_confome_solo()
                End Select
                nuevo()
            End If

        Else
            Using New Centered_MessageBox(Me)
                MessageBox.Show("Todos los campos son obligatorios! ", "Llene todos los campos", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Using
        End If
    End Sub
    Private Sub sacar_no_confome_entrar_proceso()
        'Sale de bodega no conforme
        Dim tipo_salida As String = "SIP"
        Dim modelo_salida As String = "03"
        Dim codigo_salida As String = txt_codigo.Text
        Dim cantidad As Double = txt_peso.Text
        Dim bodega_salida As Double = 4
        Dim stock As Double = objOpSimplesLn.consultarStock(codigo_salida, bodega_salida)
        Dim num_transaccion_salida As Double = 0
        If stock >= cantidad Then
            Dim listSql As New List(Of Object)
            listSql = transaccion(codigo_salida, cantidad, tipo_salida, modelo_salida, bodega_salida)
            num_transaccion_salida = numero_transaccion
            Dim tipo_entrada As String = "EIPP"
            Dim modelo_entrada As String = "03"
            Dim codigo_entrada As String = convertirCodigo2(codigo_salida)
            Dim bodega_entrada As String = objOpSimplesLn.obtenerBodegaXcodigo(codigo_entrada)
            listSql.AddRange(transaccion(codigo_entrada, cantidad, tipo_entrada, modelo_entrada, bodega_entrada))
            Dim num_transaccion_entrada As Double = numero_transaccion
            If objOpSimplesLn.ExecuteSqlTransaction(listSql) Then
                Using New Centered_MessageBox(Me)
                    MessageBox.Show("Transacciones realizadas con exito ", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End Using
                add_transaccion(num_transaccion_salida, tipo_salida, modelo_salida, codigo_salida, cantidad, bodega_salida)
                add_transaccion(num_transaccion_entrada, tipo_entrada, modelo_entrada, codigo_entrada, cantidad, bodega_entrada)
            Else
                Using New Centered_MessageBox(Me)
                    MessageBox.Show("Error al realizar la transacción ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Using
            End If

        Else
            Using New Centered_MessageBox(Me)
                MessageBox.Show("No hay stock para la transacción ", "Sin stock", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Using
        End If

    End Sub
    Private Sub sacar_no_confome_solo()
        'Sale de bodega no conforme
        Dim tipo_salida As String = "SIP"
        Dim modelo_salida As String = "03"
        Dim codigo_salida As String = txt_codigo.Text
        Dim cantidad As Double = txt_peso.Text
        Dim bodega_salida As Double = 4
        Dim stock As Double = objOpSimplesLn.consultarStock(codigo_salida, bodega_salida)
        Dim num_transaccion_salida As Double = 0
        If stock >= cantidad Then
            Dim listSql As New List(Of Object)
            listSql = transaccion(codigo_salida, cantidad, tipo_salida, modelo_salida, bodega_salida)
            num_transaccion_salida = numero_transaccion
            If objOpSimplesLn.ExecuteSqlTransaction(listSql) Then
                Using New Centered_MessageBox(Me)
                    MessageBox.Show("Transaccion realizada con exito ", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End Using
                add_transaccion(num_transaccion_salida, tipo_salida, modelo_salida, codigo_salida, cantidad, bodega_salida)
            Else
                Using New Centered_MessageBox(Me)
                    MessageBox.Show("Error al realizar la transacción ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Using
            End If

        Else
            Using New Centered_MessageBox(Me)
                MessageBox.Show("No hay stock para la transacción ", "Sin stock", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Using
        End If
    End Sub
    Private Sub sacar_no_confome_a_chatarra()
        'Sale de bodega no conforme apra chatarra
        Dim tipo_salida As String = "SAI2"
        Dim modelo_salida As String = "01"
        Dim codigo_salida As String = txt_codigo.Text
        Dim cantidad As Double = txt_peso.Text
        Dim bodega_salida As Double = 4
        Dim stock As Double = objOpSimplesLn.consultarStock(codigo_salida, bodega_salida)
        If stock >= cantidad Then
            Dim listSql As New List(Of Object)
            listSql = transaccion(codigo_salida, cantidad, tipo_salida, modelo_salida, bodega_salida)
            If objOpSimplesLn.ExecuteSqlTransaction(listSql) Then
                Using New Centered_MessageBox(Me)
                    MessageBox.Show("Transacción realizadas con exito, " & tipo_salida & "-" & numero_transaccion, "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End Using
                add_transaccion(numero_transaccion, tipo_salida, modelo_salida, codigo_salida, cantidad, bodega_salida)
            Else
                Using New Centered_MessageBox(Me)
                    MessageBox.Show("Error al realizar la transacción ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Using
            End If
        Else
            Using New Centered_MessageBox(Me)
                MessageBox.Show("No hay stock para la transacción ", "Sin stock", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Using
        End If
    End Sub
    Private Sub sacar_3_a_chatarra()
        'Sale de bodega 3 apra chatarra
        Dim tipo_salida As String = "SAI2"
        Dim modelo_salida As String = "01"
        Dim codigo_salida As String = txt_codigo.Text
        Dim cantidad As Double = txt_peso.Text
        Dim bodega_salida As Double = 3
        Dim stock As Double = objOpSimplesLn.consultarStock(codigo_salida, bodega_salida)
        If stock >= cantidad Then
            Dim listSql As New List(Of Object)
            listSql = transaccion(codigo_salida, cantidad, tipo_salida, modelo_salida, bodega_salida)
            If objOpSimplesLn.ExecuteSqlTransaction(listSql) Then
                Using New Centered_MessageBox(Me)
                    MessageBox.Show("Transacción realizadas con exito, " & tipo_salida & "-" & numero_transaccion, "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End Using
                add_transaccion(numero_transaccion, tipo_salida, modelo_salida, codigo_salida, cantidad, bodega_salida)
            Else
                Using New Centered_MessageBox(Me)
                    MessageBox.Show("Error al realizar la transacción ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Using
            End If
        Else
            Using New Centered_MessageBox(Me)
                MessageBox.Show("No hay stock para la transacción ", "Sin stock", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Using
        End If
    End Sub
    Private Function convertirCodigo2(ByVal cod_terminado As String) As String
        Dim cod_proceso As String = ""
        For i = 0 To cod_terminado.Count - 1
            If i = 0 Or i = 1 Then
                If cod_terminado(i) = "3" Then
                    cod_proceso &= "2"
                Else
                    cod_proceso &= cod_terminado(i)
                End If
            Else
                cod_proceso &= cod_terminado(i)
            End If
        Next
        Return cod_proceso
    End Function
    Private Function transaccion(ByVal codigo As String, ByVal cantidad As Double, ByVal tipo As String, ByVal modelo As String, ByVal bodega As Double) As List(Of Object)
        Dim dFec As Date = Now
        Dim usuario As String = nit
        Dim notas As String = "SPIC fecha:" & Now & " usuario:" & usuario
        Dim dt As New DataTable
        dt.Columns.Add("codigo")
        dt.Columns.Add("cantidad")
        dt.Rows.Add()
        dt.Rows(dt.Rows.Count - 1).Item("codigo") = codigo
        dt.Rows(dt.Rows.Count - 1).Item("cantidad") = cantidad
        numero_transaccion = objOrdenProdLn.mover_consecutivo(tipo)
        Dim listSql As List(Of Object) = objTraslado_bodLn.listaTransaccionDatable(numero_transaccion, dt, bodega, dFec, notas, usuario, tipo, modelo)
        Return listSql
    End Function
    Private Sub add_transaccion(ByVal numero As Double, ByVal tipo As String, ByVal modelo As String, ByVal codigo As String, ByVal cantidad As Double, ByVal bodega As String)
        dtg_consulta.Rows.Add()
        dtg_consulta.Item(col_codigo.Name, dtg_consulta.Rows.Count - 1).Value = codigo
        dtg_consulta.Item(col_cantidad.Name, dtg_consulta.Rows.Count - 1).Value = cantidad
        dtg_consulta.Item(col_numero.Name, dtg_consulta.Rows.Count - 1).Value = numero
        dtg_consulta.Item(col_tipo.Name, dtg_consulta.Rows.Count - 1).Value = tipo
        dtg_consulta.Item(col_modelo.Name, dtg_consulta.Rows.Count - 1).Value = modelo
        dtg_consulta.Item(col_bod.Name, dtg_consulta.Rows.Count - 1).Value = bodega
    End Sub
    Private Sub txt_peso_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txt_peso.KeyPress
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
    Private Sub nuevo()
        txt_codigo.Text = ""
        txt_peso.Text = ""
        Me.Text = "Ingrese código"
        txt_stock.Text = ""
        txt_bodega.Text = ""
        txt_peso.Enabled = False
    End Sub

    Private Sub cbo_transaccion_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbo_transaccion.SelectedIndexChanged
        If carga_comp Then
            Select Case cbo_transaccion.SelectedValue
                Case 1
                    cbo_transaccion.BackColor = Color.GreenYellow
                    txt_codigo.BackColor = Color.GreenYellow
                    txt_peso.BackColor = Color.GreenYellow
                Case 2
                    cbo_transaccion.BackColor = Color.Blue
                    txt_codigo.BackColor = Color.Blue
                    txt_peso.BackColor = Color.Blue
                Case 3
                    cbo_transaccion.BackColor = Color.Yellow
                    txt_codigo.BackColor = Color.Yellow
                    txt_peso.BackColor = Color.Yellow
                Case 4
                    cbo_transaccion.BackColor = Color.Red
                    txt_codigo.BackColor = Color.Red
                    txt_peso.BackColor = Color.Red
                Case 5
                    cbo_transaccion.BackColor = Color.Green
                    txt_codigo.BackColor = Color.Green
                    txt_peso.BackColor = Color.Green
                Case Else
                    cbo_transaccion.BackColor = Color.White
                    txt_codigo.BackColor = Color.White
                    txt_peso.BackColor = Color.White
            End Select
            nuevo()
        End If
    End Sub

    Private Sub txt_codigo_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txt_codigo.TextChanged
        If carga_comp Then
            If objOpSimplesLn.validarCodigo(txt_codigo.Text) Then
                Dim sql As String = "SELECT descripcion FROM referencias WHERE (codigo like '33R%' OR codigo like '33B%' OR codigo like '33X%' OR codigo like '22R%' OR codigo like '22B%' OR codigo like '22X%') AND codigo = '" & txt_codigo.Text & "'"
                Me.Text = objOpSimplesLn.consultarVal(sql)
                txt_peso.Focus()
                txt_peso.Enabled = True
                Dim bodega As Integer = 0
                If cbo_transaccion.SelectedValue = 2 Or cbo_transaccion.SelectedValue = 4 Or cbo_transaccion.SelectedValue = 5 Then
                    bodega = 4
                ElseIf cbo_transaccion.SelectedValue = 3 Then
                    bodega = 3
                Else
                    bodega = objOpSimplesLn.obtenerBodegaXcodigo(txt_codigo.Text)
                End If
                txt_bodega.Text = bodega
                txt_stock.Text = objOpSimplesLn.consultarStock(txt_codigo.Text, bodega).ToString("N0")
            Else
                txt_peso.Enabled = False
                txt_peso.Text = ""
            End If
        End If
    End Sub
End Class