Imports logicaNegocios
Imports entidadNegocios
Imports accesoDatos
Public Class frm_Trb_2_3_desp
    Dim bod_origen As Integer = 0
    Dim bod_destino As Integer = 0
    Dim modelo As String = ""
    Dim nit_usuario As String
    Dim tipo_codigo As String
    Dim codigo_aut As String = ""
    Dim num_solicitud As Double = 0
    Dim num_sol_detalle As Double = 0
    Dim cargaComp As Boolean = False
    Dim dtTransacciones As New DataTable
    Dim objTraslado_bodLn As New traslado_bodLn
    Dim obj_gestion_materia_primaLn As New Gestion_materia_primaLn
    Dim obj_gestion_alambronLn As New Gestion_alambronLn
    Private objEnvCorreoLN As New EnvCorreoLN
    Private objOrdenProdLn As New OrdenProdLn
    Private obj_Ing_prodLn As New Ing_prodLn
    Private objOpSimplesLn As New Op_simpesLn
    Private numero_transaccion As Double
    Private objOperacionesDb As New OperacionesDb
    Dim db_produccion As String = ""

    Public Sub Main(ByVal nit As Double, ByVal bod_origen As Integer, ByVal bod_destino As Integer, ByVal modelo As String)
        Me.nit_usuario = nit
        Me.bod_origen = bod_origen
        Me.bod_destino = bod_destino
        Me.modelo = modelo
        habilitarCampos(True)
        bloquear_frm_transaccion(True)
        txtCodigoLector.Select()
        Me.Text = "movimiento: bodega " & bod_origen & " - " & bod_destino
    End Sub
    Private Sub frm_Trb_2_3_desp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim sql As String = "SELECT T.tipo,T.sw " & _
                            "FROM  tipo_transacciones T " & _
                                  "WHERE T.tipo = 'TRB1' "
        dtTransacciones = obj_Ing_prodLn.listar_datatable(sql, "CORSAN")
        cboTipo.DataSource = dtTransacciones
        cboTipo.ValueMember = "sw"
        cboTipo.DisplayMember = "tipo"
     
        Me.Location.X.Equals(10)
        txtCodigoLector.Select()
        cargaComp = True
        db_produccion = objOpSimplesLn.get_nom_db("PRODUCCION") & ".dbo."
    End Sub
    Private Sub habilitarCampos(ByVal estado As Boolean)
        txtCodigoLector.Enabled = estado
        cboTipo.Enabled = estado
        btnGuardar.Enabled = estado
        dtgConsulta.Enabled = estado
    End Sub
    Private Sub bloquear_frm_transaccion(ByVal estado As Boolean)
        txtCodigoLector.Enabled = estado
        btnGuardar.Enabled = estado
        cboTipo.Enabled = estado
    End Sub
    Private Function validarFrm() As Boolean
        Using New Centered_MessageBox(Me)
            If (lblCodigo.Text <> "") Then
                If (txtKilos.Text <> "") Then
                    If (cboTipo.Text <> "Seleccione") Then
                        If (obj_Ing_prodLn.existeCodigo(lblCodigo.Text)) Then
                            If IsNumeric(txtKilos.Text) Then
                                If (Convert.ToDouble(txtKilos.Text) > 0) Then
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
                    MessageBox.Show("Falta ingresar kilos ", "verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                MessageBox.Show("Falta el CÓDIGO ", "verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Using
        Return False
    End Function
    Private Function validarCodigoBarras(ByVal consecutivo As String) As Boolean
        Dim resp As Boolean = False
        Dim consecutivo_materia_prima As String = obj_gestion_materia_primaLn.extraerDatoCodigoBarras("num_consecutivo", consecutivo)
        Dim id_detalle As String = obj_gestion_materia_primaLn.extraerDatoCodigoBarras("detalle", consecutivo)
        Dim id_rollo As String = obj_gestion_materia_primaLn.extraerDatoCodigoBarras("id_rollo", consecutivo)

        If consecutivo_materia_prima <> "" And id_rollo <> "" And id_detalle <> "" Then
            Dim sql As String = "select consecutivo from J_rollos_tref WHERE cod_orden =" & consecutivo_materia_prima & " AND id_detalle = " & id_detalle & " AND id_rollo = " & id_rollo
            Dim id As String = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")
            If id <> "" Then
                tipo_codigo = "T"
                resp = True
            End If
        Else
            consecutivo_materia_prima = obj_gestion_materia_primaLn.extraerDatoCodigoBarrasGalvanizado("nro_orden", consecutivo)
            id_rollo = obj_gestion_materia_primaLn.extraerDatoCodigoBarrasGalvanizado("id_rollo", consecutivo)
            If consecutivo_materia_prima <> "" And id_rollo <> "" Then
                Dim sql As String = "select nro_orden from D_rollo_galvanizado_f WHERE nro_orden =" & consecutivo_materia_prima & " AND consecutivo_rollo = " & id_rollo
                Dim id As String = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")
                If id <> "" Then
                    tipo_codigo = "G"
                    resp = True
                End If
            End If
        End If
        If resp = False Then
            Using New Centered_MessageBox(Me)
                MessageBox.Show("Intente leerlo nuevamente", "Problemas con el tiquete", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Using
        End If
        Return resp
    End Function
    Private Function validarTraslado(ByVal consecutivo As String) As Boolean
        Dim resp As Boolean = False
        Dim consecutivo_materia_prima As String = obj_gestion_materia_primaLn.extraerDatoCodigoBarras("num_consecutivo", consecutivo)
        Dim id_detalle As String = obj_gestion_materia_primaLn.extraerDatoCodigoBarras("detalle", consecutivo)
        Dim id_rollo As String = obj_gestion_materia_primaLn.extraerDatoCodigoBarras("id_rollo", consecutivo)
        Dim val As String
        Dim sqlTraslado = "SELECT traslado FROM J_rollos_tref  WHERE cod_orden =" & consecutivo_materia_prima & " AND id_detalle = " & id_detalle & " AND id_rollo = " & id_rollo
        If (objOperacionesDb.consultValor(sqlTraslado, "PRODUCCION") = "") Then
            sqlTraslado = "SELECT anulado FROM J_rollos_tref  WHERE cod_orden =" & consecutivo_materia_prima & " AND id_detalle = " & id_detalle & " AND id_rollo = " & id_rollo
            If (objOperacionesDb.consultValor(sqlTraslado, "PRODUCCION") = "") Then
                sqlTraslado = "SELECT transaccion_entrada FROM J_det_orden_prod WHERE cod_orden = " & consecutivo_materia_prima & "AND id_detalle = " & id_detalle & ""
                val = objOpSimplesLn.consultValorTodo(sqlTraslado, "PRODUCCION")
                If val <> "" Then
                    resp = True
                Else
                    MessageBox.Show("La planilla del rollo que intenta pasar aun no se ha cerrado", "Planilla no cerrada", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                MessageBox.Show("El rollo esta anulado", "Rollo anulado", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            MessageBox.Show("El rollo ya ha sido trasladado", "Rollo sin trasladar", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        Return resp
    End Function
    Private Function validarTrasladoG(ByVal consecutivo As String) As Boolean
        Dim resp As Boolean = False
        Dim consecutivo_materia_prima As String = obj_gestion_materia_primaLn.extraerDatoCodigoBarrasGalvanizado("nro_orden", consecutivo)
        Dim id_rollo As String = obj_gestion_materia_primaLn.extraerDatoCodigoBarrasGalvanizado("id_rollo", consecutivo)
#Disable Warning BC42024 ' Variable local sin usar: 'val'.
        Dim val As String
#Enable Warning BC42024 ' Variable local sin usar: 'val'.
        Dim sqlTraslado = "select traslado from D_rollo_galvanizado_f WHERE nro_orden =" & consecutivo_materia_prima & " AND consecutivo_rollo = " & id_rollo
        If (objOperacionesDb.consultValor(sqlTraslado, "PRODUCCION") = "") Then
            sqlTraslado = "SELECT anular from D_rollo_galvanizado_f WHERE nro_orden =" & consecutivo_materia_prima & " AND consecutivo_rollo = " & id_rollo
            If (objOperacionesDb.consultValor(sqlTraslado, "PRODUCCION") = "") Then
                resp = True
            Else
                MessageBox.Show("El rollo esta anulado", "Rollo anulado", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            MessageBox.Show("El rollo ya ha sido trasladado", "Rollo sin trasladar", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        Return resp
    End Function
    Private Function validarTrasladoP(ByVal consecutivo As String) As Boolean
        Dim resp As Boolean = False
        Dim consecutivo_materia_prima As String = obj_gestion_materia_primaLn.extraerDatoCodigoBarrasGalvanizado("nro_orden", consecutivo)
        Dim id_rollo As String = obj_gestion_materia_primaLn.extraerDatoCodigoBarrasGalvanizado("id_rollo", consecutivo)
#Disable Warning BC42024 ' Variable local sin usar: 'val'.
        Dim val As String
#Enable Warning BC42024 ' Variable local sin usar: 'val'.
        Dim sqlTraslado = "select traslado from D_orden_prod_puas_producto WHERE nro_orden =" & consecutivo_materia_prima & " AND consecutivo_rollo = " & id_rollo
        If (objOperacionesDb.consultValor(sqlTraslado, "PRODUCCION") = "") Then
            sqlTraslado = "SELECT anular from D_orden_prod_puas_producto WHERE nro_orden =" & consecutivo_materia_prima & " AND consecutivo_rollo = " & id_rollo
            If (objOperacionesDb.consultValor(sqlTraslado, "PRODUCCION") = "") Then
                resp = True
            Else
                MessageBox.Show("El rollo esta anulado", "Rollo anulado", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            MessageBox.Show("El rollo ya ha sido trasladado", "Rollo sin trasladar", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        Return resp
    End Function
    Private Sub leer_nuevo()
        cargaComp = False
        txtKilos.Text = 0
        lblCodigo.Text = "LEA CÓDIGO"
        lblDescipcion.Text = "LEA CÓDIGO"
        txtCodigoLector.Text = ""
        txtCodigoLector.ForeColor = Color.DarkGray
        txtCodigoLector.Focus()
        cargaComp = True
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
    Private Sub contar_movimientos()
        Dim cant As Integer = 0
        For i = 0 To dtgConsulta.RowCount - 1
            cant += 1
        Next
        lbl_movimientos.Text = cant
    End Sub
    Public Sub addRollo(ByVal consecutivo As String, ByVal id_detalle As String, ByVal num_rollo As String, ByVal tipo As String, ByVal peso As Double, ByVal cost_unitario As Double, ByVal codigo As String, ByVal descripcion As String)
        Using New Centered_MessageBox(Me)
            dtgConsulta.Rows.Add()
            Dim i As Integer = dtgConsulta.RowCount - 1
            While (i >= 1)
                dtgConsulta.Item(colConsecutivo.Name, i).Value = dtgConsulta.Item(colConsecutivo.Name, i - 1).Value
                dtgConsulta.Item(colNumRollo.Name, i).Value = dtgConsulta.Item(colNumRollo.Name, i - 1).Value
                dtgConsulta.Item(col_id_det.Name, i).Value = dtgConsulta.Item(col_id_det.Name, i - 1).Value
                dtgConsulta.Item(colPeso.Name, i).Value = dtgConsulta.Item(colPeso.Name, i - 1).Value
                dtgConsulta.Item(col_num_transaccion.Name, i).Value = dtgConsulta.Item(col_num_transaccion.Name, i - 1).Value
                dtgConsulta.Item(colCodigo.Name, i).Value = dtgConsulta.Item(colCodigo.Name, i - 1).Value
                dtgConsulta.Item(col_tipo.Name, i).Value = dtgConsulta.Item(col_tipo.Name, i - 1).Value
                i -= 1
            End While
            dtgConsulta.Item(colConsecutivo.Name, 0).Value = consecutivo
            dtgConsulta.Item(col_tipo.Name, 0).Value = tipo
            dtgConsulta.Item(col_num_transaccion.Name, 0).Value = numero_transaccion
            dtgConsulta.Item(colPeso.Name, 0).Value = peso
            dtgConsulta.Item(colCodigo.Name, 0).Value = Convert.ToString(codigo)
            dtgConsulta.Item(colNumRollo.Name, 0).Value = num_rollo
            dtgConsulta.Item(col_id_det.Name, 0).Value = id_detalle
            leer_nuevo()
        End Using
    End Sub
    Private Sub guardar()
        Using New Centered_MessageBox(Me)
            Dim resp_transaccion As Boolean = False
            Dim tipo As String = cboTipo.Text
            Dim notas As String = "SPIC traslado(HandHeld) " & Now & " usuario: " & nit_usuario
            Dim peso As Double = Convert.ToDouble(txtKilos.Text)
            Dim codigo As String = Trim(lblCodigo.Text)
            Dim bodega As String = Me.bod_origen
            Dim dFec As Date = Now
            Dim usuario As String = nit_usuario
            Dim stock As Double = objOpSimplesLn.consultarStock(codigo, bodega)
            Dim consecutivo As String = txtCodigoLector.Text
            Dim listSql As New List(Of Object)
            Dim sql_solicitud As String = ""
            Dim costo_unit As Double

            Dim consecutivo_materia_prima As String
            Dim id_detalle As String
            Dim id_rollo As String

            Dim dt As New DataTable
            dt.Columns.Add("codigo")
            dt.Columns.Add("cantidad")
            dt.Rows.Add()
            dt.Rows(dt.Rows.Count - 1).Item("codigo") = codigo
            dt.Rows(dt.Rows.Count - 1).Item("cantidad") = peso
            For i = 0 To dt.Rows.Count - 1
                costo_unit = objOrdenProdLn.consultCostoUnit(dt.Rows(i).Item("codigo"))
            Next
            If peso <= stock Then
                listSql.AddRange(traslado_bodega(codigo, peso, tipo, costo_unit))
                Dim sql As String
                If tipo_codigo = "T" Then
                    consecutivo_materia_prima = obj_gestion_materia_primaLn.extraerDatoCodigoBarras("num_consecutivo", consecutivo)
                    id_detalle = obj_gestion_materia_primaLn.extraerDatoCodigoBarras("detalle", consecutivo)
                    id_rollo = obj_gestion_materia_primaLn.extraerDatoCodigoBarras("id_rollo", consecutivo)
                    sql = "UPDATE " & db_produccion & "J_rollos_tref SET destino = 'D',traslado=" & numero_transaccion & " where  id_detalle =" & id_detalle & "  AND id_rollo =" & id_rollo & "and cod_orden=" & consecutivo_materia_prima & ""
                Else
                    consecutivo_materia_prima = obj_gestion_materia_primaLn.extraerDatoCodigoBarrasGalvanizado("nro_orden", consecutivo)
                    id_rollo = obj_gestion_materia_primaLn.extraerDatoCodigoBarrasGalvanizado("id_rollo", consecutivo)
                    sql = "UPDATE " & db_produccion & "D_rollo_galvanizado_f set destino='B3',traslado=" & numero_transaccion & " WHERE nro_orden =" & consecutivo_materia_prima & " AND consecutivo_rollo = " & id_rollo
                End If
                listSql.Add(sql)

                sql_solicitud = "INSERT INTO " & db_produccion & "J_salida_despacho_transaccion" &
                                       "(numero,id_detalle,tipo,num_transaccion,peso) " &
                                               "VALUES (" & num_solicitud & "," & num_sol_detalle & ",'" & tipo & "'," & numero_transaccion & "," & peso & ") "
                listSql.Add(sql_solicitud)
                If obj_Ing_prodLn.ExecuteSqlTransaction(listSql, "CORSAN") Then
#Disable Warning BC42104 ' La variable 'id_detalle' se usa antes de que se le haya asignado un valor. Podría darse una excepción de referencia NULL en tiempo de ejecución.
                    If id_detalle = "" Then
#Enable Warning BC42104 ' La variable 'id_detalle' se usa antes de que se le haya asignado un valor. Podría darse una excepción de referencia NULL en tiempo de ejecución.
                        id_detalle = 0
                    End If
                    addRollo(consecutivo_materia_prima, id_detalle, id_rollo, tipo, peso, costo_unit, codigo, lblDescipcion.Text)
                    contar_movimientos()
                    leer_nuevo()
                    MessageBox.Show("Transacción realizada con exito! ", tipo & ": " & Convert.ToString(numero_transaccion), MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("Problemas al realizar la transacción", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Else
                    MessageBox.Show("El pedido es mas grande que el stock! ", tipo & ": " & Convert.ToString(numero_transaccion), MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End Using
    End Sub
    Private Sub txtCodigoLector_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigoLector.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            txtCodigoLector.Text = Replace(txtCodigoLector.Text, "'", "-")
            Dim consecutivo As String = txtCodigoLector.Text
            If validarCodigoBarras(consecutivo) Then
                If tipo_codigo = "T" Then
                    If validarTraslado(consecutivo) Then
                        Dim consecutivo_materia_prima As String = obj_gestion_materia_primaLn.extraerDatoCodigoBarras("num_consecutivo", consecutivo)
                        Dim id_detalle As String = obj_gestion_materia_primaLn.extraerDatoCodigoBarras("detalle", consecutivo)
                        Dim id_rollo As String = obj_gestion_materia_primaLn.extraerDatoCodigoBarras("id_rollo", consecutivo)
                        Dim sql_codigo As String = "select O.prod_final " &
                                                 "FROM J_orden_prod_tef O, J_rollos_tref R " &
                                                        "WHERE O.consecutivo =" & consecutivo_materia_prima & " AND R.id_detalle =" & id_detalle & "  AND R.id_rollo =" & id_rollo & "and R.cod_orden=O.consecutivo"
                        Dim sql_peso As String = "SELECT R.peso FROM J_orden_prod_tef O, J_rollos_tref R " &
                                           " WHERE peso IS NOT NULL AND O.consecutivo =" & consecutivo_materia_prima & " AND R.id_detalle = " & id_detalle & " AND R.id_rollo=" & id_rollo & "and R.cod_orden=O.consecutivo"
                        Dim peso As String = objOpSimplesLn.consultValorTodo(sql_peso, "PRODUCCION")
                        Dim codigo As String = objOpSimplesLn.consultValorTodo(sql_codigo, "PRODUCCION")
                        codigo = codigo.ToUpper

                        lblCodigo.Text = codigo
                        lblDescipcion.Text = objOpSimplesLn.getDescripcionCodigo(codigo)
                        txtKilos.Text = peso
                        txtCodigoLector.ForeColor = Color.Black
                        btnGuardar.Focus()
                    Else
                        leer_nuevo()
                    End If
                ElseIf tipo_codigo = "G" Then
                    If validarTrasladoG(consecutivo) Then
                        Dim nro_orden As String = obj_gestion_materia_primaLn.extraerDatoCodigoBarrasGalvanizado("nro_orden", consecutivo)
                        Dim id_rollo As String = obj_gestion_materia_primaLn.extraerDatoCodigoBarrasGalvanizado("id_rollo", consecutivo)
                        Dim sql_codigo As String = "select e.final_galv " &
                                                     "FROM D_rollo_galvanizado_f r , D_orden_pro_galv_enc e " &
                                                            "WHERE e.consecutivo_orden_G = r.nro_orden AND r.nro_orden=" & nro_orden & " AND r.consecutivo_rollo =" & id_rollo
                        Dim sql_peso As String = "select r.peso " &
                                                     "FROM D_rollo_galvanizado_f r , D_orden_pro_galv_enc e " &
                                                            "WHERE e.consecutivo_orden_G = r.nro_orden AND r.nro_orden=" & nro_orden & " AND r.consecutivo_rollo =" & id_rollo
                        Dim peso As String = objOpSimplesLn.consultValorTodo(sql_peso, "PRODUCCION")
                        Dim codigo As String = objOpSimplesLn.consultValorTodo(sql_codigo, "PRODUCCION")
                        codigo = codigo.ToUpper
                        codigo_aut = codigo_aut.ToUpper

                        lblCodigo.Text = codigo
                        lblDescipcion.Text = objOpSimplesLn.getDescripcionCodigo(codigo)
                        txtKilos.Text = peso
                        txtCodigoLector.ForeColor = Color.Black
                        btnGuardar.Focus()
                    Else
                        leer_nuevo()
                    End If
                End If
            End If
        ElseIf e.KeyChar = "." Then
            e.KeyChar = "-"
        End If
    End Sub
    Private Function traslado_bodega(ByVal codigo As String, ByVal cantidad As Double, ByVal tipo As String, ByVal costo_unit As Double) As List(Of Object)
        Dim listSql As New List(Of Object)
        Dim dFec As Date = Now
        Dim usuario As String = nit_usuario
        Dim notas As String = "SPIC fecha:" & Now & " usuario:" & usuario
        numero_transaccion = objOrdenProdLn.mover_consecutivo(tipo)
        listSql = objTraslado_bodLn.listaTransaccionDatable_traslado_bodega(numero_transaccion, codigo, bod_origen, bod_destino, dFec, notas, usuario, cantidad, tipo, modelo, costo_unit)
        Return listSql
    End Function
    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If (validarFrm()) Then
            Application.DoEvents()
            guardar()
            Application.DoEvents()
        End If
    End Sub
    Private Sub btnGuardar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles btnGuardar.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            btnGuardar.PerformClick()
        End If
    End Sub

    Private Sub txtKilos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtKilos.KeyPress
        soloNumero(e)
    End Sub

    Private Sub cboTipo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboTipo.KeyPress
        e.KeyChar = ""
    End Sub

    Private Sub cboTipo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipo.SelectedIndexChanged
        If (cargaComp) Then
            btnGuardar.Focus()
        End If
    End Sub

    Private Sub cboTipo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTipo.TextChanged
        If (cargaComp And Trim(cboTipo.Text).Length > 2) Then
            If (obj_Ing_prodLn.existeTipoTransaccion(cboTipo.Text)) Then
                imgTipo.Image = Spic.My.Resources.ok3
            Else
                imgTipo.Image = Spic.My.Resources._1371750041_14125
            End If
        End If
    End Sub
    Private Sub txtCodigoLector_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodigoLector.Leave
        txtCodigoLector.BackColor = Color.Red
    End Sub
    Private Sub txtCodigoLector_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodigoLector.Enter
        txtCodigoLector.BackColor = Color.Green
        txtCodigoLector.Text = ""
    End Sub
    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Dim frm As New frm_ppal_despachos
        frm.Show()
        frm.Activate()
        Me.Close()
    End Sub
End Class