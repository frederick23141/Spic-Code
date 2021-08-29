Imports logicaNegocios
Imports entidadNegocios
Public Class Frm_transaciones_alambron
    Dim nit_usuario As String
    Dim objTraslado_bodLn As New traslado_bodLn
    Private obj_Ing_prodLn As New Ing_prodLn
    Private objOpSimplesLn As New Op_simpesLn
    Dim cargaComp As Boolean = False
    Private objEnvCorreoLN As New EnvCorreoLN
    Private objOrdenProdLn As New OrdenProdLn
    Dim obj_gestion_alambronLn As New Gestion_alambronLn
    Dim dtTransacciones As New DataTable
    Dim numero_transaccion As Double
    Dim codigo_aut As String = ""
    Dim num_solicitud As Double = 0
    Dim num_sol_detalle As Double = 0
    Dim bod_origen As Double = 0
    Dim bod_destino As Double = 0
    Dim modelo As String = ""
    Dim cantidad As String = ""
    Public Sub Main(ByVal nit As Double, ByVal bod_origen As Integer, ByVal bod_destino As Integer, ByVal modelo As String)
        Me.nit_usuario = nit
        Me.bod_origen = bod_origen
        Me.bod_destino = bod_destino
        Me.modelo = modelo
        habilitarCampos(True)
        cargar_solicitudes()
        bloquear_frm_transaccion(False)
        Me.Text = "movimiento: bodega " & bod_origen & " - " & bod_destino
    End Sub
    Private Sub Frm_transaciones_alambron_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim sql As String = "SELECT T.tipo,T.sw " & _
                              "FROM  tipo_transacciones T " & _
                                    "WHERE T.tipo = 'TRB1' "
        dtTransacciones = obj_Ing_prodLn.listar_datatable(sql, "CORSAN")
        cboTipo.DataSource = dtTransacciones
        cboTipo.ValueMember = "sw"
        cboTipo.DisplayMember = "tipo"
        cboTipo.Text = "Seleccione"
        Me.Location.X.Equals(10)
        Me.Location.Y.Equals(10)
        habilitarCampos(False)
        txtCodigoLector.Focus()
        cargaComp = True
    End Sub
    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If (validarFrm()) Then
            Application.DoEvents()
            guardar()
            Application.DoEvents()
        End If
    End Sub
    Private Sub guardar()
        Dim tipo As String = cboTipo.Text
        Dim notas As String = "SPIC traslado(HandHeld) " & Now & " usuario: " & nit_usuario
        Dim peso As Double = Convert.ToDouble(txtKilos.Text)
        Dim codigo As String = Trim(lblCodigo.Text)
        Dim bodega As String = objTraslado_bodLn.obtenerBodegaXcodigo(codigo)
        Dim dFec As Date = Now
        Dim usuario As String = nit_usuario
        Dim stock As Double = objOpSimplesLn.consultarStock(codigo, bodega)
        Dim consecutivo As String = txtCodigoLector.Text
        Dim nit_prov As Double = obj_gestion_alambronLn.extraerDatoCodigoBarras("proveedor", consecutivo)
        Dim num_importacion As String = obj_gestion_alambronLn.extraerDatoCodigoBarras("num_importacion", consecutivo)
        Dim detalle As String = obj_gestion_alambronLn.extraerDatoCodigoBarras("detalle", consecutivo)
        Dim num_rollo As String = obj_gestion_alambronLn.extraerDatoCodigoBarras("num_rollo", consecutivo)
        Dim sql_costo_unit As String = "SELECT d.costo_kilo " & _
                                                "FROM J_alambron_solicitud_det d " & _
                                                       "WHERE d.num_importacion =" & num_importacion & " AND d.nit_proveedor =" & nit_prov & "  AND d.id_det =" & detalle
        Dim costo_unit As Double = objOpSimplesLn.consultValorTodo(sql_costo_unit, "PRODUCCION")

        realizar_transaccion(codigo, peso, nit_prov, num_importacion, tipo, detalle, num_rollo, costo_unit)
    End Sub
    Public Function realizar_transaccion(ByVal codigo As String, ByVal peso As Double, ByVal nit_proveedor As Double, ByVal num_importacion As Double, ByVal tipo As String, ByVal detalle As Double, ByVal num_rollo As Double, ByVal costo_unit As Double) As Boolean
        Dim resp As Boolean = True
        Using New Centered_MessageBox(Me)
            Dim listTransaccion_prod As New List(Of Object)
            Dim listTransaccion_corsan As New List(Of Object)
            Dim sql_rollo As String = ""
            Dim consecutivo As String = txtCodigoLector.Text
            Dim sql_solicitud As String = ""
            Dim sql_devuelto As String
            listTransaccion_corsan = traslado_bodega(codigo, peso, tipo, costo_unit)
            sql_solicitud = "INSERT INTO J_salida_alambron_transaccion " & _
                                "(numero,id_detalle,tipo,num_transaccion) " & _
                                        "VALUES (" & num_solicitud & "," & num_sol_detalle & ",'" & tipo & "'," & numero_transaccion & ") "
            listTransaccion_prod.Add(sql_solicitud)
            If bod_origen = 1 And bod_destino = 2 Then
                sql_rollo = "UPDATE J_alambron_importacion_det_rollos " & _
                                                " SET num_transaccion_salida =" & numero_transaccion & " ,tipo_salida = '" & tipo & "' " & _
                                                     "WHERE num_importacion=" & num_importacion & " AND  id_solicitud_det =" & detalle & " AND numero_rollo =" & num_rollo & " AND nit_proveedor =" & nit_proveedor

            Else
                sql_rollo = "UPDATE J_alambron_importacion_det_rollos " & _
                                                " SET num_transaccion_salida = NULL ,tipo_salida = NULL " & _
                                                     "WHERE num_importacion=" & num_importacion & " AND  id_solicitud_det =" & detalle & " AND numero_rollo =" & num_rollo & " AND nit_proveedor =" & nit_proveedor

                sql_devuelto = "UPDATE J_alambron_importacion_det_rollos " & _
                                                " SET num_transaccion_dev =" & numero_transaccion & "" & _
                                                     "WHERE num_importacion=" & num_importacion & " AND  id_solicitud_det =" & detalle & " AND numero_rollo =" & num_rollo & " AND nit_proveedor =" & nit_proveedor
                objOpSimplesLn.ejecutar(sql_devuelto, "PRODUCCION")
            End If
            listTransaccion_prod.Add(sql_rollo)

            If obj_Ing_prodLn.ExecuteSqlTransaction(listTransaccion_corsan, "CORSAN") Then
                MessageBox.Show("Transacción realizada con exito! ", tipo & ": " & Convert.ToString(numero_transaccion), MessageBoxButtons.OK, MessageBoxIcon.Information)
                addRollo(num_importacion, consecutivo, peso, num_rollo, detalle, nit_proveedor, tipo)
                leer_nuevo()
                contar_movimientos()
                If Not obj_Ing_prodLn.ExecuteSqlTransaction(listTransaccion_prod, "PRODUCCION") Then
                    Using New Centered_MessageBox(Me)
                        MessageBox.Show("Eror al actualziar los Códigos de barra,comuniquese con sistemas!", "Problemas", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Using
                    resp = False
                End If
            Else
                Using New Centered_MessageBox(Me)
                    MessageBox.Show("Error al realizar la transacción! ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    resp = False
                End Using
            End If
        End Using
        Return resp
    End Function
    Public Sub addRollo(ByVal num_importacion As String, ByVal consecutivo As String, ByVal peso As Double, ByVal num_rollo As Integer, ByVal id_detalle As Integer, ByVal nit_prov As Double, ByVal tipo As String)
        Using New Centered_MessageBox(Me)
            Dim codigo As String = obj_Ing_prodLn.consultar_valor("SELECT codigo FROM  J_alambron_solicitud_det WHERE num_importacion = " & num_importacion & " AND nit_proveedor =" & nit_prov & " AND id_det =" & id_detalle, "PRODUCCION")
            Dim descripcion As String = obj_Ing_prodLn.consultar_valor("SELECT descripcion  FROM  referencias WHERE codigo = '" & codigo & "'", "CORSAN")
            Dim listTransaccion As New List(Of Object)
            dtgConsulta.Rows.Add()
            Dim i As Integer = dtgConsulta.RowCount - 1
            While (i >= 1)
                dtgConsulta.Item(colConsecutivo.Name, i).Value = dtgConsulta.Item(colConsecutivo.Name, i - 1).Value
                dtgConsulta.Item(col_tipo.Name, i).Value = dtgConsulta.Item(col_tipo.Name, i - 1).Value
                dtgConsulta.Item(col_num_transaccion.Name, i).Value = dtgConsulta.Item(col_num_transaccion.Name, i - 1).Value
                dtgConsulta.Item(colPeso.Name, i).Value = dtgConsulta.Item(colPeso.Name, i - 1).Value
                dtgConsulta.Item(colCodigo.Name, i).Value = dtgConsulta.Item(colCodigo.Name, i - 1).Value
                dtgConsulta.Item(col_numero_imp.Name, i).Value = dtgConsulta.Item(col_numero_imp.Name, i - 1).Value
                dtgConsulta.Item(colNumRollo.Name, i).Value = dtgConsulta.Item(colNumRollo.Name, i - 1).Value
                dtgConsulta.Item(col_id_det.Name, i).Value = dtgConsulta.Item(col_id_det.Name, i - 1).Value
                dtgConsulta.Item(col_nit_prov.Name, i).Value = dtgConsulta.Item(col_nit_prov.Name, i - 1).Value
                dtgConsulta.Item(col_estado_muestra.Name, i).Value = dtgConsulta.Item(col_estado_muestra.Name, i - 1).Value
                i -= 1
            End While
            dtgConsulta.Item(colConsecutivo.Name, 0).Value = consecutivo
            dtgConsulta.Item(col_tipo.Name, 0).Value = tipo
            dtgConsulta.Item(col_num_transaccion.Name, 0).Value = numero_transaccion
            dtgConsulta.Item(colPeso.Name, 0).Value = peso
            dtgConsulta.Item(colCodigo.Name, 0).Value = Convert.ToString(codigo)
            dtgConsulta.Item(col_numero_imp.Name, 0).Value = num_importacion
            dtgConsulta.Item(colNumRollo.Name, 0).Value = num_rollo
            dtgConsulta.Item(col_id_det.Name, 0).Value = id_detalle
            dtgConsulta.Item(col_nit_prov.Name, 0).Value = nit_prov
            dtgConsulta.Item(col_estado_muestra.Name, 0).Value = 0
            leer_nuevo()
            If nit_prov = 999999999 Then
                dtgConsulta.Rows(0).DefaultCellStyle.BackColor = Color.Yellow
            End If

        End Using
    End Sub
    Private Sub nuevo()
        cargaComp = False
        lblCodigo.Text = ""
        txtKilos.Text = ""
        lblDescipcion.Text = ""
        cboTipo.Text = "Seleccione"
        imgTipo.Image = Spic.My.Resources._1371750041_14125
        lblDescipcion.Text = ""
        cargaComp = True
    End Sub
    Private Function validarFrm() As Boolean
        Dim sql As String = "SELECT (D.cantidad - (SELECT COUNT(numero) FROM J_salida_alambron_transaccion  WHERE numero = D.numero AND id_detalle = D.id_detalle))As pendiente" &
            " FROM J_salida_alambron_enc E ,J_salida_alambron_det D, CORSAN.dbo.referencias R" &
            " WHERE E.anulado is null AND  R.codigo = D.codigo AND D.numero = E.numero  and e.numero=" & num_solicitud & ""
        Dim cantidad As String = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")
        Using New Centered_MessageBox(Me)
            If (lblCodigo.Text <> "") Then
                If (txtKilos.Text <> "") Then
                    If (cboTipo.Text <> "Seleccione") Then
                        If (obj_Ing_prodLn.existeCodigo(lblCodigo.Text)) Then
                            If IsNumeric(txtKilos.Text) Then
                                If (Convert.ToDouble(txtKilos.Text) > 0) Then
                                    If cantidad <> "0" Then
                                        If (cboTipo.Text <> "Seleccione") Then
                                            If (obj_Ing_prodLn.existeTipoTransaccion(cboTipo.Text)) Then
                                                If txtCodigoLector.Text <> "" Then
                                                    If validarCodigoBarras(txtCodigoLector.Text) Then
                                                        Return True
                                                    Else
                                                        MessageBox.Show("El código de barras no se encuentra asignado", "Código de barras no asignado", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                                    End If
                                                Else
                                                    MessageBox.Show("No se leyo ningun código de barras", "verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                                End If
                                            Else
                                                MessageBox.Show("No existe el tipo de transacción! ", "verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                            End If
                                        Else
                                            MessageBox.Show("Seleccione un tipo de transacción! ", "verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                        End If
                                    Else
                                        MessageBox.Show("No se puede leer más alambron en este pedido! ", "verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    End If
                                Else
                                    MessageBox.Show("Los kilos no pueden ser negativos ó iguales a (0) ", "verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                End If
                            Else
                                MessageBox.Show("Verifique que el campo 'KILOS' sea un número y no contenga letras! ", "verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End If
                        Else
                            MessageBox.Show("El código ingresado no existe,verifique! ", "verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    Else
                        MessageBox.Show("Falta el TIPO de transacción", "verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Else
                    MessageBox.Show("Faltan los kilos ", "verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                MessageBox.Show("Falta el CÓDIGO ", "verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Using

        Return False
    End Function

    Private Sub cboTipo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipo.TextChanged
        If (cargaComp And Trim(cboTipo.Text).Length > 2) Then
            If (obj_Ing_prodLn.existeTipoTransaccion(cboTipo.Text)) Then
                imgTipo.Image = Spic.My.Resources.ok3
            Else
                imgTipo.Image = Spic.My.Resources._1371750041_14125
            End If
        End If
    End Sub
    Private Sub habilitarCampos(ByVal estado As Boolean)
        txtCodigoLector.Enabled = estado
        cboTipo.Enabled = estado
        btnGuardar.Enabled = estado
        dtgConsulta.Enabled = estado
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

    Private Sub txtCedula_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        soloNumero(e)
    End Sub

    Private Sub txtKilos_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtKilos.KeyPress
        soloNumero(e)
    End Sub

    Private Sub cboTipo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboTipo.KeyPress
        e.KeyChar = ""
    End Sub
    Private Sub cboTipo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipo.SelectedIndexChanged
        If (cargaComp) Then
            btnGuardar.Focus()
        End If
    End Sub

    Private Sub txtCodigoLector_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigoLector.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then

            txtCodigoLector.Text = Replace(txtCodigoLector.Text, "'", "-")
                Dim consecutivo As String = txtCodigoLector.Text
                If validarCodigoBarras(consecutivo) Then
                    Dim nit_proveedor As String = obj_gestion_alambronLn.extraerDatoCodigoBarras("proveedor", consecutivo)
                    Dim num_importacion As String = obj_gestion_alambronLn.extraerDatoCodigoBarras("num_importacion", consecutivo)
                    Dim detalle As String = obj_gestion_alambronLn.extraerDatoCodigoBarras("detalle", consecutivo)
                    Dim num_rollo As String = obj_gestion_alambronLn.extraerDatoCodigoBarras("num_rollo", consecutivo)
                    If validarRolloRegistrado(num_importacion, num_rollo, nit_proveedor, detalle) Then
                        Dim sql_codigo As String = "SELECT d.codigo " &
                                                     "FROM J_alambron_solicitud_det d " &
                                                            "WHERE d.num_importacion =" & num_importacion & " AND d.nit_proveedor =" & nit_proveedor & "  AND d.id_det =" & detalle
                        Dim sql_peso As String = "SELECT peso FROM J_alambron_importacion_det_rollos " &
                                           " WHERE peso IS NOT NULL AND num_importacion =" & num_importacion & " AND numero_rollo = " & num_rollo & " AND nit_proveedor=" & nit_proveedor & " AND id_solicitud_det =" & detalle
                        Dim peso As String = objOpSimplesLn.consultValorTodo(sql_peso, "PRODUCCION")
                        Dim codigo As String = objOpSimplesLn.consultValorTodo(sql_codigo, "PRODUCCION")
                        If codigo = codigo_aut Then
                            If validarRolloConTransaccion(num_importacion, num_rollo, nit_proveedor, detalle) Then
                                lblCodigo.Text = codigo
                                lblDescipcion.Text = objOpSimplesLn.getDescripcionCodigo(codigo)
                                txtKilos.Text = peso
                                txtCodigoLector.ForeColor = Color.Black
                                btnGuardar.Focus()
                            Else
                                If nit_proveedor = 999999999 Then
                                    Dim resp As Integer
                                    Using New Centered_MessageBox(Me)
                                        resp = MessageBox.Show("Desea desactivar este tiquete único? ", "Desactivar?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                                    End Using
                                    If resp = 6 Then
                                        Using New Centered_MessageBox(Me)
                                            Dim sql_detele_rollo As String = "DELETE FROM  J_alambron_importacion_det_rollos " &
                                                                                    " WHERE num_importacion =" & num_importacion & " AND numero_rollo = " & num_rollo & " AND nit_proveedor=" & nit_proveedor & " AND id_solicitud_det =" & detalle
                                            If objOpSimplesLn.ejecutar(sql_detele_rollo, "PRODUCCION") > 0 Then
                                                MessageBox.Show("El rollo se desactivo en forma correcta!", "Rollo desactivado", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                            Else
                                                MessageBox.Show("Error al desactivar el rollo!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                            End If
                                        End Using
                                    End If
                                Else
                                    Using New Centered_MessageBox(Me)
                                        MessageBox.Show("Ya se le hizo una salida al rollo", "Rollo con salida", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    End Using
                                    leer_nuevo()
                                End If
                            End If
                        Else
                            Using New Centered_MessageBox(Me)
                                MessageBox.Show("El código de alambrón no pertenece al pedido", "Código no pertenece al pedido", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End Using
                            leer_nuevo()
                        End If
                    Else
                        Using New Centered_MessageBox(Me)
                            MessageBox.Show("El código de barras no se encuentra asignado", "Código de barras no asignado", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Using
                        leer_nuevo()
                    End If
                End If

        ElseIf e.KeyChar = "." Then
            e.KeyChar = "-"
        End If
    End Sub
    Private Function validarRolloRegistrado(ByVal num_importacion As Double, ByVal num_rollo As Double, ByVal nit_proveedor As Double, ByVal id_detalle As Integer) As Boolean
        Dim resp As Boolean = False
        Dim sql As String = "SELECT peso FROM J_alambron_importacion_det_rollos " & _
                                  " WHERE peso IS NOT NULL AND num_importacion =" & num_importacion & " AND numero_rollo = " & num_rollo & " AND nit_proveedor=" & nit_proveedor & " AND id_solicitud_det =" & id_detalle
        Dim peso As String = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")
        If peso <> "" Then
            resp = True
        End If
        Return resp
    End Function
    Private Function validarRolloConTransaccion(ByVal num_importacion As Double, ByVal num_rollo As Double, ByVal nit_proveedor As Double, ByVal id_detalle As Integer) As Boolean
        Dim resp As Boolean = False
        Dim sql As String = "SELECT num_importacion FROM J_alambron_importacion_det_rollos " & _
                                    " WHERE num_transaccion_salida IS NOT NULL AND num_importacion =" & num_importacion & " AND numero_rollo = " & num_rollo & " AND nit_proveedor=" & nit_proveedor & " AND id_solicitud_det =" & id_detalle
        Dim id As String = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")
        If id = "" Then
            resp = True
        End If

        If bod_origen = 2 And bod_destino = 1 Then
            If resp = True Then
                resp = False
            Else
                resp = True
            End If

        End If
        Return resp
    End Function
    Private Function validarCodigoBarras(ByVal consecutivo As String) As Boolean
        Dim resp As Boolean = False
        Dim nit_proveedor As String = obj_gestion_alambronLn.extraerDatoCodigoBarras("proveedor", consecutivo)
        Dim num_importacion As String = obj_gestion_alambronLn.extraerDatoCodigoBarras("num_importacion", consecutivo)
        Dim id_detalle As String = obj_gestion_alambronLn.extraerDatoCodigoBarras("detalle", consecutivo)
        Dim numero_rollo As String = obj_gestion_alambronLn.extraerDatoCodigoBarras("num_rollo", consecutivo)
        If num_importacion <> "" And numero_rollo <> "" And id_detalle <> "" And nit_proveedor <> "" Then
            Dim sql As String = "SELECT id FROM J_alambron_importacion_det_rollos WHERE num_importacion =" & num_importacion & " AND numero_rollo = " & numero_rollo & " AND nit_proveedor = " & nit_proveedor & " AND id_solicitud_det = " & id_detalle
            Dim id As String = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")
            If id <> "" Then
                resp = True
            End If
        End If
        If resp = False Then
            Using New Centered_MessageBox(Me)
                MessageBox.Show("Intente leerlo nuevamente", "Problemas con el tiquete", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Using
            leer_nuevo()
        End If
        Return resp
    End Function
    Private Sub leer_nuevo()
        cargaComp = False
        lblCodigo.Text = "LEA CÓDIGO"
        lblDescipcion.Text = "LEA CÓDIGO"
        txtCodigoLector.Text = ""
        txtCodigoLector.ForeColor = Color.DarkGray
        txtCodigoLector.Focus()
        cargaComp = True
    End Sub
    Private Sub btnGuardar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles btnGuardar.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            btnGuardar.PerformClick()
        End If
    End Sub
    'Solo para 'TRB1' modelo 08 traslado de la 1 a la 2
    'Solo para 'TRB1' modelo 12 traslado de la 2 a la 1
    Private Function traslado_bodega(ByVal codigo As String, ByVal cantidad As Double, ByVal tipo As String, ByVal costo_unit As Double) As List(Of Object)
        Dim listSql As New List(Of Object)
        Dim dFec As Date = Now
        Dim usuario As String = nit_usuario
        Dim notas As String = "SPIC fecha:" & Now & " usuario:" & usuario
        numero_transaccion = objOrdenProdLn.mover_consecutivo(tipo)
        listSql = objTraslado_bodLn.listaTransaccionDatable_traslado_bodega(numero_transaccion, codigo, bod_origen, bod_destino, dFec, notas, usuario, cantidad, tipo, modelo, costo_unit)
        Return listSql
    End Function

    Private Sub btn_traslado_Click(sender As Object, e As EventArgs) Handles btn_salir.Click
        Dim frm As New Frm_ppal_alambron
        frm.Activate()
        frm.Show()
        Me.Close()
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
    Private Sub cargar_solicitudes()
        Dim whereSql As String = ""
        If bod_origen = 2 And bod_destino = 1 Then
            whereSql &= " AND e.devolver = 'S' "
        Else
            whereSql &= " AND (e.devolver = 'N' OR e.devolver IS NULL ) "
        End If
        Dim sql As String = "SELECT E.numero,D.id_detalle,E.fecha,D.codigo,(D.cantidad - (SELECT COUNT(numero) FROM J_salida_alambron_transaccion  WHERE numero = D.numero AND id_detalle = D.id_detalle))As pendiente,R.descripcion " & _
                               "FROM J_salida_alambron_enc E ,J_salida_alambron_det D, CORSAN.dbo.referencias R " & _
                                 " WHERE E.anulado is null AND  R.codigo = D.codigo AND D.numero = E.numero AND (D.cantidad - (SELECT COUNT(numero) FROM J_salida_alambron_transaccion  WHERE numero = D.numero AND id_detalle = D.id_detalle)) > 0 " & whereSql & _
                                    "ORDER BY E.fecha "

        dtg_pedido.DataSource = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")
        dtg_pedido.Columns("id_detalle").Visible = False
        dtg_pedido.Columns("fecha").DefaultCellStyle.Format = "d"
        dtg_pedido.Columns("numero").HeaderText = "#"
    End Sub
    Private Sub dtg_pedido_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtg_pedido.CellContentClick
        If (e.RowIndex >= 0) Then
            Dim col As String = dtg_pedido.Columns(e.ColumnIndex).Name
            If (col = colVer.Name) Then
                cantidad = dtg_pedido.Item("pendiente", e.RowIndex).Value
                If cantidad <> "0" Then
                    tab_ppal.SelectedTab = tab_transaccion
                    txtCodigoLector.Focus()
                    codigo_aut = dtg_pedido.Item("codigo", e.RowIndex).Value
                    num_solicitud = dtg_pedido.Item("numero", e.RowIndex).Value
                    num_sol_detalle = dtg_pedido.Item("id_detalle", e.RowIndex).Value

                    Me.Text = codigo_aut & " - movimiento: bodega " & bod_origen & " - " & bod_destino
                    bloquear_frm_transaccion(True)
                    txtCodigoLector.Focus()
                Else
                    Using New Centered_MessageBox(Me)
                        MessageBox.Show("NO es posible leer más tiquetes de alambron.", "No se puede leer tiquetes de alambron.", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Using
                End If
            End If
        End If
    End Sub
    Private Sub bloquear_frm_transaccion(ByVal estado As Boolean)
        txtCodigoLector.Enabled = estado
        btnGuardar.Enabled = estado
        cboTipo.Enabled = estado
    End Sub

    Private Sub btn_salir_pedido_Click(sender As Object, e As EventArgs) Handles btn_salir_pedido.Click
        Dim frm As New Frm_ppal_alambron
        frm.Show()
        frm.Activate()
        Me.Close()
    End Sub

    Private Sub btn_actulizar_Click(sender As Object, e As EventArgs) Handles btn_actulizar.Click
        cargar_solicitudes()
    End Sub

  
    Private Sub txt_nit_KeyPress(sender As Object, e As KeyPressEventArgs)
        soloNumero(e)
    End Sub
End Class