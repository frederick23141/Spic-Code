Imports logicaNegocios
Imports entidadNegocios
Public Class Frm_lector_cod_alambron
    Dim nit_usuario As String
    Dim objTraslado_bodLn As New traslado_bodLn
    Private obj_Ing_prodLn As New Ing_prodLn
    Private objOpSimplesLn As New Op_simpesLn
    Dim cargaComp As Boolean = False
    Private objEnvCorreoLN As New EnvCorreoLN
    Dim objOrdenProdLn As New OrdenProdLn
    Dim numero_transaccion As Double
    Dim id_requisicion As Double
    Dim obj_gestion_alambronLn As New Gestion_alambronLn
    Public Sub Main(ByVal nit As Double)
        Me.nit_usuario = nit
        Dim nombre As String = objOpSimplesLn.consultarVal("SELECT nombres FROM V_nom_personal_Activo_con_maquila WHERE nit = '" & nit_usuario & "'")
        If (nombre <> "") Then
            Me.Text = nombre
            habilitarCampos(True)
            txtPlaca.Focus()
            verificarTransaccionesPendientes(nit_usuario)
        End If
        cargaComp = True
    End Sub

    Private Function sumarKilos() As Double
        Dim sum As Double = 0
        For i = 0 To dtgConsulta.RowCount - 1
            sum += dtgConsulta.Item(colPeso.Name, i).Value
        Next
        Return sum
    End Function
    Private Sub nuevo()
        cargaComp = False
        txtPeso.Text = "PESO"
        txtPeso.ForeColor = Color.DarkGray
        lblCodigo.Text = "LEA CÓDIGO"
        lblDescipcion.Text = "LEA CÓDIGO"
        txtCodigoLector.Text = ""
        txtCodigoLector.ForeColor = Color.DarkGray
        btn_cargar.Enabled = False
        txtPeso.Enabled = False
        txtCodigoLector.Focus()
        id_requisicion = 0
        tab_ppal.SelectedTab = tab_requisicion
        dtgConsulta.Rows.Clear()
        lbl_movimientos.Text = "0"
        btn_next_requisicion.Enabled = True
        cargaComp = True
    End Sub
    Private Sub leer_nuevo()
        cargaComp = False
        txtPeso.Text = "PESO"
        txtPeso.ForeColor = Color.DarkGray
        lblCodigo.Text = "LEA CÓDIGO"
        lblDescipcion.Text = "LEA CÓDIGO"
        txtCodigoLector.Text = ""
        txtCodigoLector.ForeColor = Color.DarkGray
        btn_cargar.Enabled = False
        txtPeso.Enabled = False
        txtCodigoLector.Focus()
        cargaComp = True
    End Sub

    Public Sub addRollo(ByVal num_importacion As String, ByVal consecutivo As String, ByVal peso As Double, ByVal num_rollo As Integer, ByVal id_detalle As Integer, ByVal nit_prov As Double)
        Using New Centered_MessageBox(Me)
            Dim costo_kilo As Double = obj_Ing_prodLn.consultar_valor("SELECT costo_kilo FROM  J_alambron_solicitud_det WHERE num_importacion = " & num_importacion & " AND nit_proveedor =" & nit_prov & " AND id_det =" & id_detalle, "PRODUCCION")
            Dim codigo As String = obj_Ing_prodLn.consultar_valor("SELECT codigo FROM J_alambron_solicitud_det WHERE num_importacion =" & num_importacion & " AND nit_proveedor =" & nit_prov & "  AND id_det =" & id_detalle, "PRODUCCION")
            Dim descripcion As String = obj_Ing_prodLn.consultar_valor("SELECT descripcion  FROM  referencias WHERE codigo = '" & codigo & "'", "CORSAN")
            Dim listTransaccion As New List(Of Object)
            Dim sql_peso_rollo As String = ""
            sql_peso_rollo = "UPDATE J_alambron_importacion_det_rollos " &
                                   " SET peso =" & peso & " ,id_requisicion = " & id_requisicion & " " &
                                           "WHERE num_importacion=" & num_importacion & " AND numero_rollo =" & num_rollo & " AND nit_proveedor =" & nit_prov & " AND id_solicitud_det =" & id_detalle
            If objOpSimplesLn.ejecutar(sql_peso_rollo, "PRODUCCION") > 0 Then
                dtgConsulta.Rows.Add()
                Dim i As Integer = dtgConsulta.RowCount - 1
                While (i >= 1)
                    dtgConsulta.Item(colConsecutivo.Name, i).Value = dtgConsulta.Item(colConsecutivo.Name, i - 1).Value
                    dtgConsulta.Item(colPeso.Name, i).Value = dtgConsulta.Item(colPeso.Name, i - 1).Value
                    dtgConsulta.Item(colCodigo.Name, i).Value = dtgConsulta.Item(colCodigo.Name, i - 1).Value
                    dtgConsulta.Item(col_numero_imp.Name, i).Value = dtgConsulta.Item(col_numero_imp.Name, i - 1).Value
                    dtgConsulta.Item(colNumRollo.Name, i).Value = dtgConsulta.Item(colNumRollo.Name, i - 1).Value
                    dtgConsulta.Item(col_costo_kilo.Name, i).Value = dtgConsulta.Item(col_costo_kilo.Name, i - 1).Value
                    dtgConsulta.Item(col_id_det.Name, i).Value = dtgConsulta.Item(col_id_det.Name, i - 1).Value
                    dtgConsulta.Item(col_nit_prov.Name, i).Value = dtgConsulta.Item(col_nit_prov.Name, i - 1).Value
                    dtgConsulta.Item(col_estado_muestra.Name, i).Value = dtgConsulta.Item(col_estado_muestra.Name, i - 1).Value
                    i -= 1
                End While
                dtgConsulta.Item(colConsecutivo.Name, 0).Value = consecutivo
                dtgConsulta.Item(colPeso.Name, 0).Value = peso
                dtgConsulta.Item(colCodigo.Name, 0).Value = Convert.ToString(codigo)
                dtgConsulta.Item(col_numero_imp.Name, 0).Value = num_importacion
                dtgConsulta.Item(colNumRollo.Name, 0).Value = num_rollo
                dtgConsulta.Item(col_costo_kilo.Name, 0).Value = costo_kilo
                dtgConsulta.Item(col_id_det.Name, 0).Value = id_detalle
                dtgConsulta.Item(col_nit_prov.Name, 0).Value = Convert.ToString(nit_prov)
                dtgConsulta.Item(col_estado_muestra.Name, 0).Value = 0
                contar_movimientos()
                leer_nuevo()
                If nit_prov = 999999999 Then
                    dtgConsulta.Rows(0).DefaultCellStyle.BackColor = Color.Yellow
                End If
            Else
                MessageBox.Show("Problemas al ingresar el rollo a la planilla ", Convert.ToString(numero_transaccion), MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End Using
    End Sub
    Public Function realizar_transaccion(ByVal dt_valores As DataTable, ByVal nit_proveedor As Double, ByVal num_importacion As Double) As Boolean
        Dim resp As Boolean = True
        Using New Centered_MessageBox(Me)
            Dim tipo As String = ""
            Dim modelo As String = ""
            Dim listTransaccion_prod As New List(Of Object)
            Dim listTransaccion_corsan As New List(Of Object)
            Dim nombre_proveedor As String = objOpSimplesLn.consultarVal("SELECT nombres FROM terceros WHERE nit = " & nit_proveedor)
            Dim sql_enc As String = "SELECT numero_importacion,nit_proveedor, tipo, modelo " &
                                       "FROM J_alambron_solicitud_enc " &
                                           "WHERE numero_importacion = " & num_importacion & " AND nit_proveedor =" & nit_proveedor
            Dim dt_enc As DataTable = objOpSimplesLn.listar_datatable(sql_enc, "PRODUCCION")
            For i = 0 To dt_enc.Rows.Count - 1
                tipo = dt_enc.Rows(i).Item("tipo")
                modelo = Convert.ToString(dt_enc.Rows(i).Item("modelo"))
                nit_proveedor = dt_enc.Rows(i).Item("nit_proveedor")
            Next
            Dim sql_peso_rollo As String = ""
            listTransaccion_corsan.AddRange(ingProdDms(dt_valores, tipo, nit_proveedor, modelo, num_importacion))
            For i = 0 To dt_valores.Rows.Count - 1
                If Not IsDBNull(dt_valores.Rows(i).Item("codigo")) Then
                    If Not IsDBNull(dt_valores.Rows(i).Item("peso")) Then
                        If Not IsDBNull(dt_valores.Rows(i).Item("num_importacion")) Then
                            If Not IsDBNull(dt_valores.Rows(i).Item("num_rollo")) Then
                                If Not IsDBNull(dt_valores.Rows(i).Item("costo_kilo")) Then
                                    If Not IsDBNull(dt_valores.Rows(i).Item("detalle")) Then
                                        sql_peso_rollo = "UPDATE J_alambron_importacion_det_rollos " &
                                                    " SET num_transaccion =" & numero_transaccion & " " &
                                                         "WHERE num_importacion=" & dt_valores.Rows(i).Item("num_importacion") & " AND  id_solicitud_det =" & dt_valores.Rows(i).Item("detalle") & " AND numero_rollo =" & dt_valores.Rows(i).Item("num_rollo") & " AND nit_proveedor =" & nit_proveedor
                                        listTransaccion_prod.Add(sql_peso_rollo)
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            Next
            If obj_Ing_prodLn.ExecuteSqlTransaction(listTransaccion_corsan, "CORSAN") Then
                MessageBox.Show("Transacción realizada con exito! " & vbCrLf &
                                  " " & nombre_proveedor, tipo & ": " & Convert.ToString(numero_transaccion), MessageBoxButtons.OK, MessageBoxIcon.Information)
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
    Private Function terminar_cargue() As Boolean
        Dim resp As Boolean = True
        Dim sql_terminar_cargue As String = " UPDATE J_alambron_requisicion " &
                                          "SET fecha_final = GETDATE() , num_rollos = " & txt_cant_rollos.Text & " " &
                                             "WHERE id = " & id_requisicion
        If objOpSimplesLn.ejecutar(sql_terminar_cargue, "PRODUCCION") > 0 Then
            Using New Centered_MessageBox(Me)
                MessageBox.Show("La planilla se cerro en forma correcta!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Using
        Else
            Using New Centered_MessageBox(Me)
                MessageBox.Show("Error al cerrar la planilla!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Using
            resp = False
        End If
        Return resp
    End Function
    Private Sub habilitarCampos(ByVal estado As Boolean)
        btn_cargar.Enabled = estado
        dtgConsulta.Enabled = estado
        txtPeso.Enabled = estado
        txtCodigoLector.Enabled = estado
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

    Private Sub txtPeso_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPeso.KeyPress
        soloNumero(e)
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            btn_cargar.Focus()
        End If
    End Sub
    Private Sub txt_torsionKeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_torsion.KeyPress
        soloNumero(e)
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            txt_traccion.Focus()
        End If
    End Sub
    Private Sub txt_traccion_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_traccion.KeyPress
        soloNumero(e)
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            txt_recalado.Focus()
        End If
    End Sub
    Private Sub txt_recalado_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_recalado.KeyPress
        soloNumero(e)
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            txt_cal_final.Focus()
        End If
    End Sub
    Private Sub txt_cal_final_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_cal_final.KeyPress
        soloNumero(e)
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            btn_terminar_muestra.Focus()
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
                Dim sql As String = "SELECT codigo FROM J_alambron_solicitud_det WHERE num_importacion =" & num_importacion & " AND nit_proveedor =" & nit_proveedor & "  AND id_det =" & detalle
                Dim codigo As String = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")
                If validarRolloRegistrado(num_importacion, num_rollo, nit_proveedor, detalle) Then
                    lblCodigo.Text = codigo
                    lblDescipcion.Text = objOpSimplesLn.getDescripcionCodigo(codigo)
                    txtPeso.Enabled = True
                    txtPeso.Text = ""
                    txtCodigoLector.ForeColor = Color.Black
                    btn_cargar.Enabled = True
                    txtPeso.Focus()
                Else
                    If nit_proveedor = 999999999 Then
                        Dim resp As Integer
                        Using New Centered_MessageBox(Me)
                            resp = MessageBox.Show("Desea desactivar este tiquete único? ", "Desactivar?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                        End Using
                        If resp = 6 Then
                            Using New Centered_MessageBox(Me)

                                Dim listSQL As New List(Of Object)
                                sql = "SELECT id_requisicion FROM  J_alambron_importacion_det_rollos WHERE num_importacion=" & num_importacion & " AND numero_rollo =" & num_rollo & " AND nit_proveedor =" & nit_proveedor & " AND id_solicitud_det =" & detalle
                                Dim req As String = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")

                                sql = "update J_alambron_requisicion set num_rollos=num_rollos-1 where id=" & req
                                listSQL.Add(sql)

                                Dim sql_detele_rollo As String = "DELETE FROM  J_alambron_importacion_det_rollos " &
                                                                        " WHERE num_importacion =" & num_importacion & " AND numero_rollo = " & num_rollo & " AND nit_proveedor=" & nit_proveedor & " AND id_solicitud_det =" & detalle
                                If objOpSimplesLn.ejecutar(sql_detele_rollo, "PRODUCCION") > 0 Then
                                    If obj_Ing_prodLn.ExecuteSqlTransaction(listSQL, "PRODUCCION") Then
                                    Else
                                        Using New Centered_MessageBox(Me)
                                            MessageBox.Show("ERROR", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                        End Using
                                    End If
                                    MessageBox.Show("El rollo se desactivo en forma correcta!", "Rollo desactivado", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                Else
                                    MessageBox.Show("Error al desactivar el rollo!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                End If
                            End Using
                        End If
                    Else
                        Using New Centered_MessageBox(Me)
                            MessageBox.Show("El rollo ya se registro!", "Rollo registrado", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Using
                    End If
                    leer_nuevo()
                End If
            End If
        End If
    End Sub
    Private Function validarRolloRegistrado(ByVal num_importacion As Double, ByVal num_rollo As Double, ByVal nit_proveedor As Double, ByVal id_detalle As Integer) As Boolean
        Dim resp As Boolean = False
        Dim sql As String = "SELECT num_importacion FROM J_alambron_importacion_det_rollos " &
                                    " WHERE peso IS NOT NULL AND num_importacion =" & num_importacion & " AND numero_rollo = " & num_rollo & " AND nit_proveedor=" & nit_proveedor & " AND id_solicitud_det =" & id_detalle
        Dim id As String = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")
        If id = "" Then
            resp = True
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
                MessageBox.Show("Intenete leerlo nuevamente", "Problemas con el tiquete", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Using
            leer_nuevo()
        End If
        Return resp
    End Function
    Private Function validar() As Boolean
        Dim resp As Boolean = True
        If IsNumeric(txtPeso.Text) Then
            Dim mensaje As String = ""
            If (txtPeso.Text < 200) Then
                mensaje = "El peso esta por debajo de lo establecido"
            ElseIf (txtPeso.Text > 2700) Then
                mensaje = "El peso esta por encima de lo establecido"
            End If
            If mensaje <> "" Then
                Using New Centered_MessageBox(Me)
                    MessageBox.Show(mensaje, "Verifique peso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End Using
                resp = False
            End If
            If Not validarCodigoBarras(txtCodigoLector.Text) Then
                resp = False
            End If
        Else
            Using New Centered_MessageBox(Me)
                MessageBox.Show("ingrese un peso correcto", "Verifique peso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Using
            resp = False
        End If
        Return resp
    End Function

    Private Sub btnRealiTran_Click(sender As Object, e As EventArgs) Handles btn_cargar.Click
        If validar() Then
            Dim consecutivo As String = txtCodigoLector.Text
            Dim nit_prov As Double = obj_gestion_alambronLn.extraerDatoCodigoBarras("proveedor", consecutivo)
            Dim num_importacion As String = obj_gestion_alambronLn.extraerDatoCodigoBarras("num_importacion", consecutivo)
            Dim detalle As String = obj_gestion_alambronLn.extraerDatoCodigoBarras("detalle", consecutivo)
            Dim num_rollo As String = obj_gestion_alambronLn.extraerDatoCodigoBarras("num_rollo", consecutivo)
            Dim peso As Double = txtPeso.Text
            addRollo(num_importacion, consecutivo, peso, num_rollo, detalle, nit_prov)
        End If
    End Sub

    Private Function ingProdDms(ByVal dt As DataTable, ByVal tipo As String, ByVal nit_proveedor As Integer, ByVal modelo As String, ByVal num_imp As Integer) As List(Of Object)
        Dim bodega As String = 1
        Dim dFec As Date = Now
        Dim usuario As String = nit_usuario
        Dim notas As String = "SP No." & num_imp & ". " & Now.Year & "-" & Now.Month & "-" & Now.Day & " usr:" & usuario
        numero_transaccion = objOrdenProdLn.mover_consecutivo(tipo)

        Return objTraslado_bodLn.listaTransaccionDatable_importaciones(numero_transaccion, dt, bodega, dFec, notas, usuario, tipo, nit_proveedor, modelo)
    End Function
    Private Sub txtPeso_TextChanged(sender As Object, e As EventArgs) Handles txtPeso.TextChanged
        If cargaComp Then
            txtPeso.ForeColor = Color.Black
        End If
    End Sub
    Private Sub txtPlaca_Enter(sender As Object, e As EventArgs) Handles txtPlaca.Enter
        txtPlaca.BackColor = Color.Lime
    End Sub
    Private Sub txtPlaca_Leave(sender As Object, e As EventArgs) Handles txtPlaca.Leave
        txtPlaca.BackColor = Color.White
    End Sub
    Private Sub txtMulaCargada_Enter(sender As Object, e As EventArgs) Handles txtMulaCargada.Enter
        txtMulaCargada.BackColor = Color.Lime
    End Sub
    Private Sub txtMulaCargada_Leave(sender As Object, e As EventArgs) Handles txtMulaCargada.Leave
        txtMulaCargada.BackColor = Color.White
    End Sub
    Private Sub txtMulaDescargadaEnter(sender As Object, e As EventArgs) Handles txtMulaDescargada.Enter
        txtMulaDescargada.BackColor = Color.Lime
    End Sub
    Private Sub txtMulaDescargada_Leave(sender As Object, e As EventArgs) Handles txtMulaDescargada.Leave
        txtMulaDescargada.BackColor = Color.White
    End Sub
    Private Sub txtPeso_Enter(sender As Object, e As EventArgs) Handles txtPeso.Enter
        txtPeso.BackColor = Color.Lime
        txtPeso.Text = ""
    End Sub
    Private Sub txtPeso_Leave(sender As Object, e As EventArgs) Handles txtPeso.Leave
        txtPeso.BackColor = Color.White
    End Sub

    Private Sub txtCodigoLector_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodigoLector.Enter
        txtCodigoLector.BackColor = Color.Green
        txtCodigoLector.Text = ""
    End Sub
    Private Sub txtCodigoLector_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodigoLector.Leave
        txtCodigoLector.BackColor = Color.Red
    End Sub
    Private Sub txt_torsion_Enter(sender As Object, e As EventArgs) Handles txt_torsion.Enter
        txt_torsion.BackColor = Color.Lime
    End Sub
    Private Sub txt_torsion_Leave(sender As Object, e As EventArgs) Handles txt_torsion.Leave
        txt_torsion.BackColor = Color.White
    End Sub
    Private Sub txt_traccion_Enter(sender As Object, e As EventArgs) Handles txt_traccion.Enter
        txt_traccion.BackColor = Color.Lime
    End Sub
    Private Sub txt_traccion_Leave(sender As Object, e As EventArgs) Handles txt_traccion.Leave
        txt_traccion.BackColor = Color.White
    End Sub
    Private Sub txt_recalado_Enter(sender As Object, e As EventArgs) Handles txt_recalado.Enter
        txt_recalado.BackColor = Color.Lime
    End Sub
    Private Sub txt_recalado_Leave(sender As Object, e As EventArgs) Handles txt_recalado.Leave
        txt_recalado.BackColor = Color.White
    End Sub
    Private Sub txt_cal_final_Enter(sender As Object, e As EventArgs) Handles txt_cal_final.Enter
        txt_cal_final.BackColor = Color.Lime
    End Sub
    Private Sub txt_cal_final_Leave(sender As Object, e As EventArgs) Handles txt_cal_final.Leave
        txt_cal_final.BackColor = Color.White
    End Sub
    Private Sub txtMulaCargada_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMulaCargada.KeyPress
        soloNumero(e)
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            txtMulaDescargada.Focus()
        End If
    End Sub

    Private Sub txtPlaca_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPlaca.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            txtMulaCargada.Focus()
        End If
    End Sub

    Private Sub txtMulaDescargada_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMulaDescargada.KeyPress
        soloNumero(e)
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            txt_cant_rollos.Focus()
        End If
    End Sub
    Private Sub txt_cant_rollos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_cant_rollos.KeyPress
        soloNumero(e)
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            btn_next_requisicion.Focus()
        End If
    End Sub

    Private Sub btn_next_requisicion_Click(sender As Object, e As EventArgs) Handles btn_next_requisicion.Click
        If validar_requisicion() Then
            If iniciarRequisicion() Then
                Using New Centered_MessageBox(Me)
                    MessageBox.Show("Requisición creada con exito", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End Using
                tab_ppal.SelectedTab = tab_cargue
                btn_next_requisicion.Enabled = False
                txtCodigoLector.Focus()
            Else
                Using New Centered_MessageBox(Me)
                    MessageBox.Show("Error al crear la requisición", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End Using
            End If
        End If
    End Sub
    Private Function validar_requisicion() As Boolean
        Dim mensaje As String = ""
        Dim resp As Boolean = False
        Dim nombre As String = objOpSimplesLn.consultarVal("SELECT nombres FROM V_nom_personal_Activo_con_maquila WHERE nit = '" & nit_usuario & "'")
        If (nombre <> "") Then
            If (txtPlaca.Text <> "") Then
                If (txtMulaCargada.Text <> "") Then
                    If (txtMulaDescargada.Text <> "") Then
                        If (txtMulaDescargada.Text <> "") Then
                            resp = True
                        Else
                            mensaje = "Ingrese la cantidad de rollos que trae el caeeo"
                        End If

                    Else
                        mensaje = "Ingrese  el peso de la mula cargada"
                    End If
                Else
                    mensaje = "Ingrese  el peso de la mula cargada"
                End If
            Else
                mensaje = "Ingrese la placa del camión"
            End If
        Else
            mensaje = "Ingrese una cédula correcta"
        End If
        If resp Then
            If Convert.ToDouble(txtMulaCargada.Text) <= Convert.ToDouble(txtMulaDescargada.Text) Then
                mensaje = "El peso de la mula cargada debe ser mayor al peso descarada!"
                resp = False
            End If
        End If
        If mensaje <> "" Then
            Using New Centered_MessageBox(Me)
                MessageBox.Show(mensaje, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Using
        End If
        Return resp
    End Function
    Private Function iniciarRequisicion() As Boolean
        id_requisicion = objOpSimplesLn.consultValorTodo("SELECT (CASE WHEN MAX(id) IS NULL THEN 1 ELSE MAX(id)+1 END) FROM J_alambron_requisicion", "PRODUCCION")
        Dim resp As Boolean = False
        Dim placa As String = txtPlaca.Text
        Dim cargado As String = txtMulaCargada.Text
        Dim descargado As String = txtMulaDescargada.Text
        Dim num_rollos As String = txt_cant_rollos.Text
        Dim sql As String = "INSERT INTO J_alambron_requisicion (id,fecha_inicial,nit,placa,peso_cargado,peso_descargado,num_rollos) " &
                                "VALUES(" & id_requisicion & ",GETDATE()," & nit_usuario & ",'" & placa & "'," & cargado & "," & descargado & "," & num_rollos & ") "
        If objOpSimplesLn.ejecutar(sql, "PRODUCCION") > 0 Then
            Return True
        Else
            Return False
        End If
    End Function



    Private Sub nuevo_requisicion()
        cargaComp = False
        txtPlaca.Text = ""
        txtMulaCargada.Text = ""
        txtMulaDescargada.Text = ""
        txtPeso.Text = "PESO"
        txtPeso.ForeColor = Color.DarkGray
        lblCodigo.Text = "LEA CÓDIGO"
        lblDescipcion.Text = "LEA CÓDIGO"
        txtCodigoLector.Text = ""
        txtCodigoLector.ForeColor = Color.DarkGray
        btn_cargar.Enabled = False
        txtPeso.Enabled = False
        txtCodigoLector.Focus()
        id_requisicion = 0
        tab_ppal.SelectedTab = tab_requisicion
        btn_next_requisicion.Enabled = True
        txt_cant_rollos.Text = ""
        cargaComp = True
    End Sub

    Private Sub tab_cargue_Click(sender As Object, e As EventArgs) Handles tab_cargue.Click
        If Not validar_requisicion() Then
            tab_ppal.SelectedTab = tab_requisicion
        End If
    End Sub

    Private Sub tab_cargue_DragEnter(sender As Object, e As DragEventArgs) Handles tab_cargue.DragEnter
        If Not validar_requisicion() Then
            tab_ppal.SelectedTab = tab_requisicion
        End If
    End Sub

    Private Sub dtgConsulta_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgConsulta.CellClick
        Using New Centered_MessageBox(Me)
            If e.RowIndex >= 0 Then
                If dtgConsulta.Columns(e.ColumnIndex).Name = col_muestra.Name Then
                    If (dtgConsulta.Item(col_estado_muestra.Name, e.RowIndex).Value) = 0 Then
                        Dim resp As Integer
                        resp = MessageBox.Show("Desea realizar una muestra a estre rollo? ", "Muestra?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                        If resp = 6 Then
                            Using New Centered_MessageBox(Me)
                                dtgConsulta.Item(col_estado_muestra.Name, e.RowIndex).Value = 1
                                dtgConsulta.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Red
                                MessageBox.Show("Rollo en estado de muestra", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            End Using
                        End If
                    ElseIf dtgConsulta.Item(col_estado_muestra.Name, e.RowIndex).Value = 1 Then
                        tab_ppal.SelectedTab = tab_muestra
                        txt_consecutivo_muestra.Text = dtgConsulta.Item(colConsecutivo.Name, e.RowIndex).Value
                    ElseIf dtgConsulta.Item(col_estado_muestra.Name, e.RowIndex).Value = 2 Then
                        MessageBox.Show("Ya se le realizo la muestra a estre rollo", "Ya se realizo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                ElseIf dtgConsulta.Columns(e.ColumnIndex).Name = col_borrar.Name Then
                    Dim resp As Integer
                    Using New Centered_MessageBox(Me)
                        resp = MessageBox.Show("Seguro que desea reiniciar el tiquete? ", "Reiniciar tiquete?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                    End Using
                    If resp = 6 Then
                        reinicar_tiquete(e.RowIndex)
                    End If
                End If
            End If
        End Using
    End Sub
    Private Sub reinicar_tiquete(ByVal fila As Integer)
        dtgConsulta.CurrentCell = Nothing

        Dim sql As String = ""
        Dim consecutivo As String = dtgConsulta.Item(colCodigo.Name, fila).Value
        Dim nit_prov As Double = dtgConsulta.Item(col_nit_prov.Name, fila).Value
        Dim num_importacion As String = dtgConsulta.Item(col_numero_imp.Name, fila).Value
        Dim detalle As String = dtgConsulta.Item(col_id_det.Name, fila).Value
        Dim num_rollo As String = dtgConsulta.Item(colNumRollo.Name, fila).Value
        sql = "UPDATE J_alambron_importacion_det_rollos " &
                                   " SET peso=NULL ,id_requisicion=NULL " &
                                           "WHERE num_importacion=" & num_importacion & " AND numero_rollo =" & num_rollo & " AND nit_proveedor =" & nit_prov & " AND id_solicitud_det =" & detalle

        If objOpSimplesLn.ejecutar(sql, "PRODUCCION") > 0 Then
            dtgConsulta.Rows.RemoveAt(fila)
            contar_movimientos()
            Using New Centered_MessageBox(Me)
                MessageBox.Show("El tiquete se reinicio en forma correcta", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Using
        End If

    End Sub
    Private Sub verificarTransaccionesPendientes(ByVal nit As Double)
        Using New Centered_MessageBox(Me)
            Dim sql As String = "SELECT CAST (e.nit_proveedor  AS varchar(25) ) + '-' + CAST (e.numero_importacion AS varchar(25) ) +'-'+ CAST (d.id_det AS varchar(25) )+'-'+ CAST (r.numero_rollo  AS varchar(25) ) As consecutivo,e.nit_proveedor ,e.numero_importacion,e.fecha,d.codigo,r.numero_rollo ,r.peso,d.costo_kilo,d.id_det ,r.numero_rollo , a.id As id_requisicion, a.placa , a.peso_cargado,a.peso_descargado,a.num_rollos  " &
                                     "FROM J_alambron_importacion_det_rollos r , J_alambron_solicitud_det d , J_alambron_solicitud_enc e ,J_alambron_requisicion a	 " &
                                         "WHERE r.num_transaccion is null AND r.nit_proveedor <> 999999999 AND   d.nit_proveedor = e.nit_proveedor AND r.nit_proveedor = d.nit_proveedor AND  d.num_importacion = e.numero_importacion  AND r.num_importacion = d.num_importacion  AND r.id_solicitud_det  = d.id_det AND a.id = r.id_requisicion AND a.nit = '" & nit & "' AND YEAR(a.fecha_inicial) = " & Now.Year & " AND MONTH(a.fecha_inicial) = " & Now.Month & ""
            Dim dt As DataTable = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")
            If dt.Rows.Count > 0 Then
                dtgConsulta.Rows.Clear()
                lbl_movimientos.Text = "0"
                MessageBox.Show("Tiene rollos pendientes por cargar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
                For i = 0 To dt.Rows.Count - 1
                    If i = 0 Then
                        id_requisicion = dt.Rows(i).Item("id_requisicion")
                        txtPlaca.Text = dt.Rows(i).Item("placa")
                        txtMulaCargada.Text = dt.Rows(i).Item("peso_cargado")
                        txtMulaDescargada.Text = dt.Rows(i).Item("peso_descargado")
                        txt_cant_rollos.Text = dt.Rows(i).Item("num_rollos")
                    End If
                    dtgConsulta.Rows.Add()
                    dtgConsulta.Item(colConsecutivo.Name, dtgConsulta.Rows.Count - 1).Value = dt.Rows(i).Item("consecutivo")
                    dtgConsulta.Item(colCodigo.Name, dtgConsulta.Rows.Count - 1).Value = Convert.ToString(dt.Rows(i).Item("codigo"))
                    dtgConsulta.Item(colPeso.Name, dtgConsulta.Rows.Count - 1).Value = dt.Rows(i).Item("peso")
                    dtgConsulta.Item(col_numero_imp.Name, dtgConsulta.Rows.Count - 1).Value = dt.Rows(i).Item("numero_importacion")
                    dtgConsulta.Item(col_id_det.Name, dtgConsulta.Rows.Count - 1).Value = dt.Rows(i).Item("id_det")
                    dtgConsulta.Item(colNumRollo.Name, dtgConsulta.Rows.Count - 1).Value = dt.Rows(i).Item("numero_rollo")
                    dtgConsulta.Item(col_costo_kilo.Name, dtgConsulta.Rows.Count - 1).Value = dt.Rows(i).Item("costo_kilo")
                    dtgConsulta.Item(col_nit_prov.Name, dtgConsulta.Rows.Count - 1).Value = dt.Rows(i).Item("nit_proveedor")
                    dtgConsulta.Item(col_estado_muestra.Name, dtgConsulta.Rows.Count - 1).Value = 0
                    If dt.Rows(i).Item("nit_proveedor") = 999999999 Then
                        dtgConsulta.Rows(dtgConsulta.Rows.Count - 1).DefaultCellStyle.BackColor = Color.Yellow
                    End If
                Next
                tab_ppal.SelectedTab = tab_cargue
                btn_next_requisicion.Enabled = False
                txtCodigoLector.Focus()
            End If
        End Using
    End Sub
    Private Function verificar_proveedores_transacciones() As Boolean
        Dim resp As Boolean = False
        Dim dt_codigos_valores As New DataTable
        dtgConsulta.Sort(col_nit_prov, System.ComponentModel.ListSortDirection.Ascending)
        Dim prov_ant As Double = 0
        Dim nit_proveedor As Double = 0
        Dim num_importacion As Double = 0
        For i = 0 To dtgConsulta.Rows.Count - 1
            If Not IsDBNull(dtgConsulta.Item(col_nit_prov.Name, i).Value) Then
                nit_proveedor = dtgConsulta.Item(col_nit_prov.Name, i).Value
                If nit_proveedor <> 999999999 Then
                    num_importacion = dtgConsulta.Item(col_numero_imp.Name, i).Value
                    If prov_ant <> nit_proveedor Then
                        prov_ant = nit_proveedor
                        dt_codigos_valores = New DataTable
                        dt_codigos_valores = get_datos(nit_proveedor)
                        If realizar_transaccion(dt_codigos_valores, nit_proveedor, num_importacion) Then
                            resp = True
                        End If
                    End If
                End If
            End If
        Next
        Return resp
    End Function
    Private Function get_datos(ByVal nit_proveedor As Double) As DataTable
        Dim dt As New DataTable
        dt.Columns.Add("codigo")
        dt.Columns.Add("peso")
        dt.Columns.Add("cantidad")
        dt.Columns.Add("nit_proveedor")
        dt.Columns.Add("costo_kilo")
        dt.Columns.Add("num_importacion")
        dt.Columns.Add("detalle")
        dt.Columns.Add("num_rollo")
        For i = 0 To dtgConsulta.RowCount - 1
            If Not IsDBNull(dtgConsulta.Item(colCodigo.Name, i).Value) Then
                If Not IsDBNull(dtgConsulta.Item(colPeso.Name, i).Value) Then
                    If Not IsDBNull(dtgConsulta.Item(col_costo_kilo.Name, i).Value) Then
                        If dtgConsulta.Item(col_nit_prov.Name, i).Value = nit_proveedor Then
                            dt.Rows.Add()
                            dt.Rows(dt.Rows.Count - 1).Item("codigo") = dtgConsulta.Item(colCodigo.Name, i).Value
                            dt.Rows(dt.Rows.Count - 1).Item("cantidad") = dtgConsulta.Item(colPeso.Name, i).Value
                            dt.Rows(dt.Rows.Count - 1).Item("costo_kilo") = dtgConsulta.Item(col_costo_kilo.Name, i).Value
                            dt.Rows(dt.Rows.Count - 1).Item("nit_proveedor") = dtgConsulta.Item(col_nit_prov.Name, i).Value
                            dt.Rows(dt.Rows.Count - 1).Item("num_importacion") = dtgConsulta.Item(col_numero_imp.Name, i).Value
                            dt.Rows(dt.Rows.Count - 1).Item("detalle") = dtgConsulta.Item(col_id_det.Name, i).Value
                            dt.Rows(dt.Rows.Count - 1).Item("peso") = dtgConsulta.Item(colPeso.Name, i).Value
                            dt.Rows(dt.Rows.Count - 1).Item("num_rollo") = dtgConsulta.Item(colNumRollo.Name, i).Value
                        End If
                    End If
                End If
            End If
        Next
        Return dt
    End Function
    Private Sub add_proveedor_transaccion(ByVal nit_provedor As Double, ByVal codigo As String, ByVal cantidad As Double, ByVal costo_kilo As Double)

    End Sub
    Private Function cant_proveedores() As Integer
        Dim cant As Double = 0
        Dim prov_ant As Double = 0
        For i = 0 To dtgConsulta.Rows.Count - 1
            If Not IsDBNull(dtgConsulta.Item(col_nit_prov.Name, i).Value) Then
                If prov_ant <> dtgConsulta.Item(col_nit_prov.Name, i).Value Then
                    cant += 1
                    prov_ant = dtgConsulta.Item(col_nit_prov.Name, i).Value
                End If
            End If
        Next
        Return cant
    End Function
    Private Sub btn_terminar_muestra_Click(sender As Object, e As EventArgs) Handles btn_terminar_muestra.Click
        If validar_muestra() Then
            Using New Centered_MessageBox(Me)
                Dim consecutivo As String = txt_consecutivo_muestra.Text
                Dim nit_proveedor As String = obj_gestion_alambronLn.extraerDatoCodigoBarras("proveedor", consecutivo)
                Dim num_importacion As String = obj_gestion_alambronLn.extraerDatoCodigoBarras("num_importacion", consecutivo)
                Dim detalle As String = obj_gestion_alambronLn.extraerDatoCodigoBarras("detalle", consecutivo)
                Dim num_rollo As String = obj_gestion_alambronLn.extraerDatoCodigoBarras("num_rollo", consecutivo)
                Dim torsion As Double = txt_torsion.Text
                Dim traccion As Double = txt_traccion.Text
                Dim recalado As Double = txt_recalado.Text
                Dim calidad_final As Double = txt_cal_final.Text
                Dim sql As String = "INSERT INTO J_alambron_muestra (num_importacion, id_solicitud_det, numero_rollo, torsion, traccion, recalado, calidad_final,nit_proveedor) " &
                                        "VALUES (" & num_importacion & ", " & detalle & ",  " & num_rollo & ", " & torsion & ",  " & traccion & ",  " & recalado & ",  " & calidad_final & "," & nit_proveedor & ")"
                If objOpSimplesLn.ejecutar(sql, "PRODUCCION") Then
                    For i = 0 To dtgConsulta.Rows.Count - 1
                        If dtgConsulta.Item(colConsecutivo.Name, i).Value = consecutivo Then
                            dtgConsulta.Item(col_estado_muestra.Name, i).Value = 2
                            dtgConsulta.Rows(i).DefaultCellStyle.BackColor = Color.GreenYellow
                            nueva_muestra()
                            i = dtgConsulta.Rows.Count - 1
                        End If
                    Next
                    MessageBox.Show("Muestra realizada", "Se realizo en forma correcta", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    tab_ppal.SelectedTab = tab_cargue
                Else
                    MessageBox.Show("Error al realizar la muestra", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End Using
        End If
    End Sub
    Private Function validar_muestra() As Boolean
        Dim resp As Boolean = False
        If txt_consecutivo_muestra.Text <> "" And txt_torsion.Text <> "" And txt_traccion.Text <> "" And txt_recalado.Text <> "" And txt_cal_final.Text <> "" Then
            resp = True
        End If
        If resp = False Then
            Using New Centered_MessageBox(Me)
                MessageBox.Show("Llene todos los campos de la muestra", "Campos requeridos", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Using
        End If
        Return resp
    End Function
    Private Sub nueva_muestra()
        txt_consecutivo_muestra.Text = ""
        txt_torsion.Text = ""
        txt_traccion.Text = ""
        txt_recalado.Text = ""
        txt_cal_final.Text = ""
    End Sub

    Private Sub btn_cargar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles btn_cargar.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            btn_cargar.PerformClick()
        End If
    End Sub
    Private Sub btn_terminar_muestra_KeyPress(sender As Object, e As KeyPressEventArgs) Handles btn_terminar_muestra.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            btn_terminar_muestra.PerformClick()
        End If
    End Sub

    Private Sub btn_next_requisicion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles btn_next_requisicion.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            btn_next_requisicion.PerformClick()
        End If
    End Sub

    Private Sub btn_traslado_Click(sender As Object, e As EventArgs) Handles btn_traslado.Click
        Dim frm As New Frm_ppal_alambron
        frm.Show()
        frm.Activate()
        Me.Close()
    End Sub
    Private Sub contar_movimientos()
        Dim cant As Integer = 0
        For i = 0 To dtgConsulta.RowCount - 1
            cant += 1
        Next
        lbl_movimientos.Text = cant
    End Sub

    Private Sub btn_transaccion_Click(sender As Object, e As EventArgs) Handles btn_transaccion.Click
        Dim resp As Integer
        If dtgConsulta.Rows.Count > 0 Then
            Using New Centered_MessageBox(Me)
                resp = MessageBox.Show("Seguro que termino de descargar el camión? ", "Terminar?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
            End Using
            If resp = 6 Then
                If IsNumeric(txt_cant_rollos.Text) Then
                    If Convert.ToDouble(txt_cant_rollos.Text) = dtgConsulta.RowCount Then
                        If (verificar_proveedores_transacciones()) Then
                            If terminar_cargue() Then
                                nuevo_requisicion()
                                nuevo()
                                Using New Centered_MessageBox(Me)
                                    MessageBox.Show("Requisición terminada con exito", "Termino", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                End Using
                            Else
                                Using New Centered_MessageBox(Me)
                                    MessageBox.Show("Error al cerrar la requisición", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                End Using
                            End If
                        Else
                            Using New Centered_MessageBox(Me)
                                MessageBox.Show("La cantidad de rollos leidos no coninside con la ingresada en la planilla", "Ya se realizo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            End Using
                        End If
                    Else
                        Using New Centered_MessageBox(Me)
                            MessageBox.Show("La cantidad de rollos registrados no coinside con la planilla", "Cantidad de rollos no coinside", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End Using
                    End If
                Else
                    Using New Centered_MessageBox(Me)
                        MessageBox.Show("Ingrese la cantidad de rollos en la planilla de descargue", "Ingrese cantidad de rollos", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End Using
                End If
            End If
        Else
            Using New Centered_MessageBox(Me)
                MessageBox.Show("No se encontraron rollos por cargar", "No hay rollos por cargar", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Using
        End If

    End Sub
End Class