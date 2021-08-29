Imports logicaNegocios
Imports entidadNegocios
Imports accesoDatos
Public Class Frm_transacion_bodega_G
    Dim bod_origen As Double = 0
    Dim bod_destino As Double = 0
    Private numero_transaccion As Double
    Dim modelo As String = ""
    Dim nit_usuario As String
    Dim tipo_t As String
    Dim codigo_materia_prima As String
    Dim cargaComp As Boolean = False
    Dim dtTransacciones As New DataTable
    Dim obj_gestion_materia_primaLn As New Gestion_materia_primaLn
    Dim objTraslado_bodLn As New traslado_bodLn
    Private objOpSimplesLn As New Op_simpesLn
    Private objOrdenProdLn As New OrdenProdLn
    Private obj_Ing_prodLn As New Ing_prodLn
    Private objOperacionesDb As New OperacionesDb
    Public Sub Main(ByVal codigo As String, ByVal nit As Double, ByVal bod_origen As Integer, ByVal modelo As String)
        Me.nit_usuario = nit
        Me.bod_origen = bod_origen
        Me.modelo = modelo
        Me.codigo_materia_prima = codigo
        habilitarCampos(True)
        bloquear_Frm_transacion_bodega_G(False)
        Me.Text = codigo & "  Transaccion"
    End Sub
    Private Sub Frm_transacion_bodega_G_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim sql As String = "SELECT T.tipo,T.sw " & _
                           "FROM  tipo_transacciones T " & _
                                 "WHERE T.tipo = 'SAGA' "
        dtTransacciones = obj_Ing_prodLn.listar_datatable(sql, "CORSAN")
        cboTipo.DataSource = dtTransacciones
        cboTipo.ValueMember = "sw"
        cboTipo.DisplayMember = "tipo"
        cboTipo.Text = "SAGA"
        cargar_bobina()
        habilitarCampos(True)
        txtCodigoLector.Focus()
        cargaComp = True
    End Sub
    Private Sub bloquear_Frm_transacion_bodega_G(ByVal estado As Boolean)
        txtCodigoLector.Enabled = estado
        btnGuardar.Enabled = estado
        cboTipo.Enabled = estado
    End Sub
    Private Sub habilitarCampos(ByVal estado As Boolean)
        txtCodigoLector.Enabled = estado
        btnGuardar.Enabled = estado
        cboTipo.Enabled = estado
    End Sub
   
    Public Sub cargar_bobina()
        Dim dt As New DataTable
        Dim row As DataRow
        Dim sql As String

        sql = "select * from D_Bobina_Devanador "
        dt = New DataTable
        dt = obj_Ing_prodLn.listar_datatable(sql, "PRODUCCION")
        row = dt.NewRow
        row("nro_bobina") = 0
        dt.Rows.Add(row)
        cbobobina.DataSource = dt
        cbobobina.ValueMember = "nro_bobina"
        cbobobina.DisplayMember = "nro_bobina"
        cbobobina.Text = "Seleccione"
        cbobobina.SelectedValue = 0
    End Sub
    Private Sub guardar()
        Using New Centered_MessageBox(Me)
            Dim resp_transaccion As Boolean = False
            Dim tipo As String = cboTipo.Text
            Dim notas As String = "SPIC traslado(HandHeld) " & Now & " usuario: " & nit_usuario
            Dim peso As Double = Convert.ToDouble(txtKilos.Text)
            Dim codigo As String = Trim(lblCodigo.Text)
            Dim bodega As String = 11
            Dim dFec As Date = Now
            Dim usuario As String = nit_usuario
            Dim consecutivo As String = txtCodigoLector.Text
            Dim listTransaccion_corsan As New List(Of Object)
            Dim saga As String
            Dim consult_saga As String
            Dim result_saga As String
            Dim bobina As Integer = cbobobina.SelectedValue
            Dim guardar_bobina As String
            Dim dt As New DataTable
            dt.Columns.Add("codigo")
            dt.Columns.Add("cantidad")
            dt.Rows.Add()
            dt.Rows(dt.Rows.Count - 1).Item("codigo") = codigo
            dt.Rows(dt.Rows.Count - 1).Item("cantidad") = peso
            Dim consecutivo_materia_prima As String = obj_gestion_materia_primaLn.extraerDatoCodigoBarras("num_consecutivo", consecutivo)
            Dim id_detalle As String = obj_gestion_materia_primaLn.extraerDatoCodigoBarras("detalle", consecutivo)
            Dim id_rollo As String = obj_gestion_materia_primaLn.extraerDatoCodigoBarras("id_rollo", consecutivo)

            consult_saga = "select saga from J_rollos_tref where  id_detalle =" & id_detalle & "  AND id_rollo =" & id_rollo & "and cod_orden=" & consecutivo_materia_prima & ""
            result_saga = objOpSimplesLn.consultValorTodo(consult_saga, "PRODUCCION")
            If result_saga = "" Then
                listTransaccion_corsan.AddRange(transaccion(dt, codigo, peso, tipo))

                Dim db_produccion As String = objOpSimplesLn.get_nom_db("PRODUCCION") & ".dbo."

                saga = "update " & db_produccion & "J_rollos_tref set saga=" & numero_transaccion & " where  id_detalle =" & id_detalle & "  AND id_rollo =" & id_rollo & "and cod_orden=" & consecutivo_materia_prima & ""
                guardar_bobina = "update " & db_produccion & "J_rollos_tref set bobina=" & bobina & " where  id_detalle =" & id_detalle & "  AND id_rollo =" & id_rollo & "and cod_orden=" & consecutivo_materia_prima & ""

                listTransaccion_corsan.Add(saga)
                listTransaccion_corsan.Add(guardar_bobina)
                'objOperacionesDb.consultValor(saga, "PRODUCCION")
                'objOperacionesDb.consultValor(guardar_bobina, "PRODUCCION")

                obj_Ing_prodLn.ExecuteSqlTransaction(listTransaccion_corsan, "CORSAN")
                leer_nuevo()
                MessageBox.Show("El rollo ha sido gastado del inventario", "Rollo gastado", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("El rollo ya esta consumido", "Rollo ya gastado", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        End Using
    End Sub

    Private Function validarCodigoBarras(ByVal consecutivo As String) As Boolean
        Dim resp As Boolean = False
        Dim consecutivo_materia_prima As String = obj_gestion_materia_primaLn.extraerDatoCodigoBarras("num_consecutivo", consecutivo)
        Dim id_detalle As String = obj_gestion_materia_primaLn.extraerDatoCodigoBarras("detalle", consecutivo)
        Dim id_rollo As String = obj_gestion_materia_primaLn.extraerDatoCodigoBarras("id_rollo", consecutivo)
        If consecutivo_materia_prima <> "" And id_rollo <> "" And id_detalle <> "" Then
            Dim sql As String = "select consecutivo from J_rollos_tref WHERE cod_orden =" & consecutivo_materia_prima & " AND id_detalle = " & id_detalle & " AND id_rollo = " & id_rollo
            Dim id As String = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")
            If id <> "" Then
                resp = True
            End If
        End If
        If resp = False Then
            Using New Centered_MessageBox(Me)
                MessageBox.Show("Intenete leerlo nuevamente", "Problemas con el tiquete", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Using

        End If
        Return resp
    End Function
    Private Function transaccion(ByVal datacodigo As DataTable, ByVal codigo As String, ByVal cantidad As Double, ByVal tipo As String) As List(Of Object)
        Dim listSql As New List(Of Object)
        Dim dFec As Date = Now
        Dim usuario As String = nit_usuario
        Dim notas As String = "SPIC fecha:" & Now & " usuario:" & usuario
        numero_transaccion = objOrdenProdLn.mover_consecutivo(tipo)
        listSql = objTraslado_bodLn.listaTransaccionDatable(numero_transaccion, datacodigo, bod_origen, dFec, notas, usuario, tipo, modelo)
        Return listSql
    End Function

    Private Sub txtCodigoLector_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigoLector.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            txtCodigoLector.Text = Replace(txtCodigoLector.Text, "'", "-")
            Dim consecutivo As String = txtCodigoLector.Text
            If validarCodigoBarras(consecutivo) Then
                If validarTraslado(consecutivo) Then
                    Dim consecutivo_materia_prima As String = obj_gestion_materia_primaLn.extraerDatoCodigoBarras("num_consecutivo", consecutivo)
                    Dim id_detalle As String = obj_gestion_materia_primaLn.extraerDatoCodigoBarras("detalle", consecutivo)
                    Dim id_rollo As String = obj_gestion_materia_primaLn.extraerDatoCodigoBarras("id_rollo", consecutivo)
                    Dim sql_codigo As String = "select O.prod_final " & _
                                                    "FROM J_orden_prod_tef O, J_rollos_tref R " & _
                                                           "WHERE O.consecutivo =" & consecutivo_materia_prima & " AND R.id_detalle =" & id_detalle & "  AND R.id_rollo =" & id_rollo & "and R.cod_orden=O.consecutivo"
                    Dim sql_peso As String = "SELECT R.peso FROM J_orden_prod_tef O, J_rollos_tref R " & _
                                       " WHERE peso IS NOT NULL AND O.consecutivo =" & consecutivo_materia_prima & " AND R.id_detalle = " & id_detalle & " AND R.id_rollo=" & id_rollo & "and R.cod_orden=O.consecutivo"
                    Dim peso As String = objOpSimplesLn.consultValorTodo(sql_peso, "PRODUCCION")
                    Dim codigo As String = objOpSimplesLn.consultValorTodo(sql_codigo, "PRODUCCION")
                    codigo = codigo.ToUpper
                    codigo_materia_prima = codigo_materia_prima.ToUpper
                    If codigo = codigo_materia_prima Then
                        Dim stock As Double = objOpSimplesLn.consultarStock(codigo, 11)
                        If peso <= stock Then
                            lblCodigo.Text = codigo
                            lblDescipcion.Text = objOpSimplesLn.getDescripcionCodigo(codigo)
                            txtKilos.Text = peso
                            txtCodigoLector.ForeColor = Color.Black
                        Else
                            Using New Centered_MessageBox(Me)
                                MessageBox.Show("No hay stock disponible", "Sin stock", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            End Using
                        End If


                    Else
                        Using New Centered_MessageBox(Me)
                            MessageBox.Show("El código de alambre brillante no pertenece a la orden", "Código no pertenece a la orden", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Using
                        leer_nuevo()
                    End If
                Else
                    Using New Centered_MessageBox(Me)
                        MessageBox.Show("El codigo aun no peretenece a la bodega", "Alambre brillante no perteneciente a la bodega", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Using
                    leer_nuevo()
                End If
            End If
        ElseIf e.KeyChar = "." Then
            e.KeyChar = "-"
        End If

    End Sub
    Private Function validarTraslado(ByVal consecutivo As String) As Boolean
        Dim resp As Boolean = False
        Dim consecutivo_materia_prima As String = obj_gestion_materia_primaLn.extraerDatoCodigoBarras("num_consecutivo", consecutivo)
        Dim id_detalle As String = obj_gestion_materia_primaLn.extraerDatoCodigoBarras("detalle", consecutivo)
        Dim id_rollo As String = obj_gestion_materia_primaLn.extraerDatoCodigoBarras("id_rollo", consecutivo)
        Dim sqlTraslado = "SELECT traslado FROM J_rollos_tref  WHERE cod_orden =" & consecutivo_materia_prima & " AND id_detalle = " & id_detalle & " AND id_rollo = " & id_rollo
        'cambiar el cosltarvalorprueba
        If (objOperacionesDb.consultValor(sqlTraslado, "PRODUCCION") <> "") Then
            sqlTraslado = "SELECT destino FROM J_rollos_tref  WHERE cod_orden =" & consecutivo_materia_prima & " AND id_detalle = " & id_detalle & " AND id_rollo = " & id_rollo
            If (objOperacionesDb.consultValor(sqlTraslado, "PRODUCCION") = "G") Then
                resp = True
            End If
        End If
        Return resp
    End Function
    Private Function validarFrm() As Boolean
        Using New Centered_MessageBox(Me)
            If (lblCodigo.Text <> "") Then
                If (txtKilos.Text <> "") Then
                    If (cboTipo.Text <> "Seleccione") Then
                        If (obj_Ing_prodLn.existeCodigo(lblCodigo.Text)) Then
                            If IsNumeric(txtKilos.Text) Then
                                If cbobobina.SelectedValue <> 0 Then
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
                                    MessageBox.Show("Seleccione una bobina por favor ", "verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
    Private Sub leer_nuevo()
        cargaComp = False
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
    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If (validarFrm()) Then
            Application.DoEvents()
            guardar()
            Application.DoEvents()
        End If
        Me.Close()
    End Sub
    Private Sub cboTipo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipo.SelectedIndexChanged
        If (cargaComp) Then
            btnGuardar.Focus()
        End If
    End Sub
    Private Sub cboTipo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboTipo.KeyPress
        e.KeyChar = ""
    End Sub

    Private Sub btnGuardar_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGuardar.Enter
        txtCodigoLector.BackColor = Color.Green
    End Sub
    Private Sub txtCodigoLector_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodigoLector.Leave
        txtCodigoLector.BackColor = Color.Red
    End Sub

    Private Sub txtCodigoLector_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodigoLector.Enter
        txtCodigoLector.BackColor = Color.Green
        txtCodigoLector.Text = ""
    End Sub
    Private Sub btnGuardar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles btnGuardar.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            btnGuardar.PerformClick()
        End If
    End Sub
    Private Sub txtKilos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtKilos.KeyPress
        soloNumero(e)
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
End Class