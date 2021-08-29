Imports logicaNegocios
Imports entidadNegocios
Imports accesoDatos
Public Class frm_traslado_puas_2_3
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

    Private Sub frm_traslado_puas_2_3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim sql As String = "SELECT T.tipo,T.sw " &
                       "FROM  tipo_transacciones T " &
                             "WHERE T.tipo = 'TRB1' "
        dtTransacciones = obj_Ing_prodLn.listar_datatable(sql, "CORSAN")
        cboTipo.DataSource = dtTransacciones
        cboTipo.ValueMember = "sw"
        cboTipo.DisplayMember = "tipo"
        Me.Location.X.Equals(10)
        Me.Location.Y.Equals(10)
        txtCodigoLector.Select()
        cargaComp = True
        db_produccion = objOpSimplesLn.get_nom_db("PRODUCCION") & ".dbo."
    End Sub
    Public Sub Main(ByVal nit As Double, ByVal bod_origen As Integer, ByVal bod_destino As Integer, ByVal modelo As String)
        Me.nit_usuario = nit
        Me.bod_origen = bod_origen
        Me.bod_destino = bod_destino
        Me.modelo = modelo
        habilitarCampos(True)
        bloquear_frm_transaccion(True)
        txtCodigoLector.Select()
        Me.Text = "movimiento puas: bodega " & bod_origen & " - " & bod_destino
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
                    MessageBox.Show("Falta ingresar nro rollos ", "verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                MessageBox.Show("Falta el CÓDIGO ", "verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Using
        Return False
    End Function
    Private Function validarCodigoBarras(ByVal consecutivo As String) As Boolean
        Dim resp As Boolean = False
        Dim consecutivo_materia_prima As String = obj_gestion_materia_primaLn.extraerDatoCodigoBarrasGalvanizado("nro_orden", consecutivo)
        Dim id_rollo As String = obj_gestion_materia_primaLn.extraerDatoCodigoBarrasGalvanizado("id_rollo", consecutivo)
        Dim sql As String
        Dim id As String
        If consecutivo_materia_prima <> "" And id_rollo <> "" Then
            Sql = "SELECT nro_orden FROM D_orden_prod_puas_producto WHERE nro_orden =" & consecutivo_materia_prima & " AND consecutivo_rollo = " & id_rollo
            id = objOpSimplesLn.consultValorTodo(Sql, "PRODUCCION")
            If id <> "" Then
                tipo_codigo = "P"
                resp = True
            End If
        End If
        If resp = False Then
            Using New Centered_MessageBox(Me)
                MessageBox.Show("Intente leerlo nuevamente", "Problemas con el tiquete", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Using
        End If
        Return resp
    End Function
    Private Sub txtCodigoLector_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCodigoLector.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            txtCodigoLector.Text = Replace(txtCodigoLector.Text, "'", "-")
            Dim consecutivo As String = txtCodigoLector.Text
            If validarCodigoBarras(consecutivo) Then
                Dim nro_orden As String = obj_gestion_materia_primaLn.extraerDatoCodigoBarrasGalvanizado("nro_orden", consecutivo)
                Dim id_rollo As String = obj_gestion_materia_primaLn.extraerDatoCodigoBarrasGalvanizado("id_rollo", consecutivo)
                Dim sql_codigo As String = "select e.prod_final " &
                                                         "FROM D_orden_prod_puas_producto r , D_orden_prod_puas e " &
                                                                "WHERE e.cod_orden = r.nro_orden AND r.nro_orden=" & nro_orden & " AND r.consecutivo_rollo =" & id_rollo
                Dim sql_peso As String = "select r.peso_real " &
                                                         "FROM D_orden_prod_puas_producto r , D_orden_prod_puas e " &
                                                                "WHERE e.cod_orden = r.nro_orden AND r.nro_orden=" & nro_orden & " AND r.consecutivo_rollo =" & id_rollo
                Dim peso As String = objOpSimplesLn.consultValorTodo(sql_peso, "PRODUCCION")
                Dim codigo As String = objOpSimplesLn.consultValorTodo(sql_codigo, "PRODUCCION")
                codigo = codigo.ToUpper
                codigo_aut = codigo_aut.ToUpper

                lblCodigo.Text = codigo
                lblDescipcion.Text = objOpSimplesLn.getDescripcionCodigo(codigo)
                txtCodigoLector.ForeColor = Color.Black
                btnGuardar.Focus()
            End If
        ElseIf e.KeyChar = "." Then
            e.KeyChar = "-"
        End If
    End Sub
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
    Private Function traslado_bodega(ByVal codigo As String, ByVal cantidad As Double, ByVal tipo As String, ByVal costo_unit As Double) As List(Of Object)
        Dim listSql As New List(Of Object)
        Dim dFec As Date = Now
        Dim usuario As String = nit_usuario
        Dim notas As String = "SPIC fecha:" & Now & " usuario:" & usuario
        numero_transaccion = objOrdenProdLn.mover_consecutivo(tipo)
        listSql = objTraslado_bodLn.listaTransaccionDatable_traslado_bodega(numero_transaccion, codigo, bod_origen, bod_destino, dFec, notas, usuario, cantidad, tipo, modelo, costo_unit)
        Return listSql
    End Function
    Private Sub guardar()
        Using New Centered_MessageBox(Me)
            Dim resp_transaccion As Boolean = False
            Dim tipo As String = cboTipo.Text
            Dim notas As String = "SPIC traslado(HandHeld) " & Now & " usuario: " & nit_usuario
            Dim cantidad As Double = Convert.ToDouble(txtKilos.Text)
            Dim codigo As String = Trim(lblCodigo.Text)
            Dim sql_fc = "SELECT Conversion from Referencias where codigo='" & codigo & "'"
            Dim fc As String = objOpSimplesLn.consultValorTodo(sql_fc, "CORSAN")
            Dim peso As Double
            If fc <> "" Then
                peso = cantidad * CDbl(fc)
            Else
                peso = 0
            End If
            Dim bodega As String = Me.bod_origen
            Dim dFec As Date = Now
            Dim usuario As String = nit_usuario
            Dim stock As Double = objOpSimplesLn.consultarStock(codigo, bodega)
            Dim consecutivo As String = txtCodigoLector.Text
            Dim listSql As New List(Of Object)
            Dim sql_solicitud As String = ""
            Dim costo_unit As Double

#Disable Warning BC42024 ' Variable local sin usar: 'consecutivo_materia_prima'.
            Dim consecutivo_materia_prima As String
#Enable Warning BC42024 ' Variable local sin usar: 'consecutivo_materia_prima'.
            Dim id_detalle As String
#Disable Warning BC42024 ' Variable local sin usar: 'id_rollo'.
            Dim id_rollo As String
#Enable Warning BC42024 ' Variable local sin usar: 'id_rollo'.

            Dim dt As New DataTable
            dt.Columns.Add("codigo")
            dt.Columns.Add("cantidad")
            dt.Rows.Add()
            dt.Rows(dt.Rows.Count - 1).Item("codigo") = codigo
            dt.Rows(dt.Rows.Count - 1).Item("cantidad") = cantidad
            For i = 0 To dt.Rows.Count - 1
                costo_unit = objOrdenProdLn.consultCostoUnit(dt.Rows(i).Item("codigo"))
            Next
            If cantidad <= stock Then
                listSql.AddRange(traslado_bodega(codigo, cantidad, tipo, costo_unit))
                sql_solicitud = "INSERT INTO " & db_produccion & "J_salida_despacho_transaccion" &
                                       "(numero,id_detalle,tipo,num_transaccion,peso) " &
                                               "VALUES (" & num_solicitud & "," & num_sol_detalle & ",'" & tipo & "'," & numero_transaccion & "," & cantidad & ") "
                listSql.Add(sql_solicitud)
                If obj_Ing_prodLn.ExecuteSqlTransaction(listSql, "CORSAN") Then
#Disable Warning BC42104 ' La variable 'id_detalle' se usa antes de que se le haya asignado un valor. Podría darse una excepción de referencia NULL en tiempo de ejecución.
                    If id_detalle = "" Then
#Enable Warning BC42104 ' La variable 'id_detalle' se usa antes de que se le haya asignado un valor. Podría darse una excepción de referencia NULL en tiempo de ejecución.
                        id_detalle = 0
                    End If
                    addRollo(codigo, cantidad)
                    leer_nuevo()
                    MessageBox.Show("Transacción realizada con exito! ", tipo & ": " & Convert.ToString(numero_transaccion), MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Problemas al realizar la transacción", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                MessageBox.Show("No hay stock en bodega! ", tipo & ": " & Convert.ToString(numero_transaccion), MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End Using
    End Sub
    Public Sub addRollo(ByVal codigo As String, ByVal cant As String)
        Using New Centered_MessageBox(Me)
            dtgConsulta.Rows.Add()
            Dim i As Integer = dtgConsulta.RowCount - 1
            While (i >= 1)
                dtgConsulta.Item(colCant.Name, i).Value = dtgConsulta.Item(colCant.Name, i - 1).Value
                dtgConsulta.Item(colCodigo.Name, i).Value = dtgConsulta.Item(colCodigo.Name, i - 1).Value
                i -= 1
            End While
            dtgConsulta.Item(colCant.Name, 0).Value = cant
            dtgConsulta.Item(colCodigo.Name, 0).Value = Convert.ToString(codigo)
            leer_nuevo()
        End Using
    End Sub
    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If (validarFrm()) Then
            Application.DoEvents()
            guardar()
            Application.DoEvents()
        End If
    End Sub

    Private Sub btn_salir_Click(sender As Object, e As EventArgs) Handles btn_salir.Click
        Dim frm As New frm_ppal_despachos
        frm.Show()
        frm.Activate()
        Me.Close()
    End Sub
End Class