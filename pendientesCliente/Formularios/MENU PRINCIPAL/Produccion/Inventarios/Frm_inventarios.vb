Imports logicaNegocios
Imports entidadNegocios
Public Class Galvanizado
    Dim nit_usuario As String
    Dim objTraslado_bodLn As New traslado_bodLn
    Private obj_Ing_prodLn As New Ing_prodLn
    Private objOpSimplesLn As New Op_simpesLn

    Dim cargaComp As Boolean = False
    Private objOrdenProdLn As New OrdenProdLn
    Private objOperacionesForm As OperacionesFormularios = New OperacionesFormularios
    Private id As Double = 0
    Dim tipos As Integer = 0
    Dim tp As String = ""

    Public Sub Main(ByVal nit As Double)
        Me.nit_usuario = nit
        bloquear_frm_transaccion(False)
        verificarInventariosPendientes()
        txt_codigo.Focus()
    End Sub
    Private Sub Frm_inventarios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Location.X.Equals(10)
        Me.Location.Y.Equals(10)
        habilitarCampos(False)
        txt_codigo.Focus()
        cargaComp = True

        Dim dt As New DataTable
        Dim sql As String

        sql = "SELECT centro,(CONVERT(varchar, centro) + '--' + descripcion) AS descripcion FROM centros WHERE centro IN (2200,2300,2800)"
        dt = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        dt.Rows.Add()
        dt.Rows(dt.Rows.Count - 1).Item("centro") = 0
        dt.Rows(dt.Rows.Count - 1).Item("descripcion") = "OTROS"
        cbo_proceso.DataSource = dt
        cbo_proceso.ValueMember = "centro"
        cbo_proceso.DisplayMember = "descripcion"
        cbo_proceso.SelectedValue = 0
    End Sub

    Private Sub habilitarCampos(ByVal estado As Boolean)
        txtCodigoLector.Enabled = estado
    End Sub
    Private Sub txtCodigoLector_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigoLector.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            txtCodigoLector.Text = Replace(txtCodigoLector.Text, "'", "-")
            validar_rollos()
        ElseIf e.KeyChar = "." Then
            e.KeyChar = "-"
        End If
    End Sub

    Private Sub validar_rollos()
        If tipos = 0 Then
            Dim codOrden As String = objTraslado_bodLn.extraerDatoCodigoBarras("cod_orden", txtCodigoLector.Text)
            Dim idDetalle As String = objTraslado_bodLn.extraerDatoCodigoBarras("cod_detalle", txtCodigoLector.Text)
            Dim idRollo As String = objTraslado_bodLn.extraerDatoCodigoBarras("num_rollo", txtCodigoLector.Text)

            Dim sql As String = "SELECT destino FROM J_rollos_tref WHERE cod_orden =" & codOrden & _
                                    " AND id_detalle = " & idDetalle & " AND id_rollo =" & idRollo
            Dim destino As String = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")
            If tp = destino Then
                If destino = "P" Then
                    sql = "SELECT scla FROM J_rollos_tref WHERE cod_orden =" & codOrden & _
                                    " AND id_detalle = " & idDetalle & " AND id_rollo =" & idRollo
                End If
                If destino = "R" Then
                    sql = "SELECT srec FROM J_rollos_tref WHERE cod_orden =" & codOrden & _
                                    " AND id_detalle = " & idDetalle & " AND id_rollo =" & idRollo
                End If
                If destino = "G" Then
                    sql = "SELECT saga FROM J_rollos_tref WHERE cod_orden =" & codOrden & _
                                        " AND id_detalle = " & idDetalle & " AND id_rollo =" & idRollo
                End If
                Dim vals As String = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")
                If vals <> "" Then
                    Using New Centered_MessageBox(Me)
                        MessageBox.Show("El rollo ya esta en proceso.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        txtCodigoLector.Text = ""
                    End Using
                Else
                    sql = "SELECT anulado FROM J_rollos_tref WHERE cod_orden =" & codOrden & _
                                        " AND id_detalle = " & idDetalle & " AND id_rollo =" & idRollo
                    Dim anulado As String = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")
                    If anulado <> "" Then
                        Using New Centered_MessageBox(Me)
                            MessageBox.Show("El rollo esta anulado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            txtCodigoLector.Text = ""
                        End Using
                    Else
                        sql = "SELECT estado FROM J_inventario_alambre " & _
                                    " WHERE cod_orden = " & codOrden & _
                                        " AND id_detalle = " & idDetalle & " AND id_rollo =" & idRollo & " AND inventario=" & id
                        Dim estado As String = ""
                        estado = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")
                        If estado <> "" Then
                            MessageBox.Show("El Rollo ya a sido ingresado. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            txtCodigoLector.Text = ""
                        Else
                            lector_centros()
                        End If
                    End If
                End If
            Else
                Dim var As String = ""
                If tp = "P" Then
                    var = "Puntilleria"
                End If
                If tp = "R" Then
                    var = "Recocido"
                End If
                If tp = "G" Then
                    var = "Galvanizado"
                End If
                Using New Centered_MessageBox(Me)
                    MessageBox.Show("El rollo no esta registrado en " & var & ".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    txtCodigoLector.Text = ""
                End Using
            End If
        Else
            lector_otros()
        End If
    End Sub

    Private Sub lector_otros()
        txtCodigoLector.Text = Replace(txtCodigoLector.Text, "'", "-")
        Dim codigo_barras As String = txtCodigoLector.Text
        If validarCodigoBarras(codigo_barras) Then
            Dim codigo As String = extraerDatoCodigoBarras("codigo", codigo_barras)
            Dim cantidad As String = extraerDatoCodigoBarras("cantidad", codigo_barras)
            Dim cantidad_multiplicar As String = ""
            Using New Centered_MessageBox(Me)
                cantidad_multiplicar = InputBox("Ingrese cantidad de productos contados, luego presione aceptar", "Cantidad de unidades", , -16, 50)
            End Using
            If IsNumeric(cantidad_multiplicar) Then
                If (cantidad_multiplicar) > 0 Then
                    cantidad *= cantidad_multiplicar
                    If Not (add_producto(codigo, cantidad)) Then
                        Using New Centered_MessageBox(Me)
                            MessageBox.Show("El código no pertenece al inventario", "No pertenece al inventario", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End Using
                    End If
                Else
                    Using New Centered_MessageBox(Me)
                        MessageBox.Show("La cantidad ingresada debe ser mayor a 0", "Cantidad incorrecta", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End Using
                End If
            Else
                Using New Centered_MessageBox(Me)
                    MessageBox.Show("El valor ingresado debe ser númerico", "valor debe ser númerico", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End Using
            End If
        End If
        txtCodigoLector.Text = ""
    End Sub
    Private Sub lector_centros()
        txtCodigoLector.Text = Replace(txtCodigoLector.Text, "'", "-")
        Dim codOrden As String = objTraslado_bodLn.extraerDatoCodigoBarras("cod_orden", txtCodigoLector.Text)
        Dim idDetalle As String = objTraslado_bodLn.extraerDatoCodigoBarras("cod_detalle", txtCodigoLector.Text)
        Dim idRollo As String = objTraslado_bodLn.extraerDatoCodigoBarras("num_rollo", txtCodigoLector.Text)
        Dim sql As String = "UPDATE J_inventario_alambre SET estado = 1 WHERE cod_orden = " & codOrden & _
                                " AND id_detalle = " & idDetalle & " AND id_rollo = " & idRollo & " AND inventario = " & id
        If (objOpSimplesLn.ejecutar(sql, "PRODUCCION")) Then
            cargar_rollos(id)
        Else
            Using New Centered_MessageBox(Me)
                MessageBox.Show("Error al registrar el rollo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Using
        End If
        txtCodigoLector.Text = ""
    End Sub

    Private Sub cargar_rollos(ByVal id As Integer)
        Dim sql As String = "SELECT t.cod_orden,t.id_detalle,t.id_rollo,s.destino FROM J_rollos_tref s, J_inventario_alambre t " & _
                                " WHERE(t.cod_orden = s.cod_orden And t.id_detalle = s.id_detalle And t.id_rollo = s.id_rollo) " & _
                                    " AND t.inventario = " & id & " AND estado Is Not Null "
        Dim dt As New DataTable

        dt = objOpSimplesLn.crearDataTableVariasCol(sql, "PRODUCCION")
        dtgItems.DataSource = dt

        tab_ppal.SelectedTab = tab_transaccion
        btn_comenzar.Enabled = False
        habilitarCampos(True)
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

    Private Sub bloquear_frm_transaccion(ByVal estado As Boolean)
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

    Private Function add_producto(ByVal codigo As String, ByVal cantidad As Double) As Boolean
        Dim resp As Boolean = False
        For i = 0 To dtgItems.Rows.Count - 1
            If dtgItems.Item("codigo", i).Value = codigo Then
                If IsNumeric(dtgItems.Item("fisico", i).Value) Then
                    dtgItems.Item("fisico", i).Value += cantidad
                Else
                    dtgItems.Item("fisico", i).Value = cantidad
                End If
                Dim sql As String = "UPDATE J_inventario_det SET fisico += " & cantidad & " " & _
                                          "WHERE id = " & id & " AND codigo = '" & codigo & "'"
                If objOpSimplesLn.ejecutar(sql, "PRODUCCION") > 0 Then
                    resp = True
                    Using New Centered_MessageBox(Me)
                        MessageBox.Show("Producto agregado en forma correcta", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End Using
                Else
                    Using New Centered_MessageBox(Me)
                        MessageBox.Show("Error al agregar el producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Using
                End If
            End If
        Next
        Return resp
    End Function

    Private Sub btn_terminar_Click(sender As Object, e As EventArgs) Handles btn_terminar.Click
        If id > 0 Then
            temirnar_inventario()
        End If
    End Sub
    Private Sub temirnar_inventario()
        Dim sql As String = "UPDATE J_inventario_enc SET fecha_terminado = GETDATE() WHERE id =" & id
        If objOpSimplesLn.ejecutar(sql, "PRODUCCION") > 0 Then
            Using New Centered_MessageBox(Me)
                MessageBox.Show("El inventario finalizó en forma correcta", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                nuevo()
            End Using
        Else
            Using New Centered_MessageBox(Me)
                MessageBox.Show("Error al terminar el inventario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Using
        End If
    End Sub
    Private Sub nuevo()
        txt_codigo.Text = ""
        txtCodigoLector.Text = ""
        dtgItems.DataSource = Nothing
        tab_ppal.SelectedTab = tab_ped
        habilitarCampos(False)
    End Sub

    Private Function verificarInventariosPendientes() As Boolean
        Dim resp As Boolean = False
        Using New Centered_MessageBox(Me)
            Dim sql As String = "SELECT id,codigo,bodega " & _
                                    "FROM J_inventario_enc c " & _
                                        "WHERE fecha_terminado is null AND c.nit =" & nit_usuario
            Dim dt As DataTable = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")
            For i = 0 To dt.Rows.Count - 1
                dtgItems.CurrentCell = Nothing
                id = dt.Rows(i).Item("id")
                If dt.Rows(i).Item("codigo") = 2200 Or dt.Rows(i).Item("codigo") = 2300 Or dt.Rows(i).Item("codigo") = 2800 Then
                    MessageBox.Show("Tiene un inventario pendiente por cerrar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    If dt.Rows(i).Item("codigo") = 2300 Then
                        tp = "P"
                    End If
                    If dt.Rows(i).Item("codigo") = 2200 Then
                        tp = "R"
                    End If
                    If dt.Rows(i).Item("codigo") = 2800 Then
                        tp = "G"
                    End If
                    tipos = 0
                    cargar_rollos(id)
                Else
                    tipos = 1
                    txt_codigo.Text = dt.Rows(i).Item("codigo")
                    txt_bodega.Text = dt.Rows(i).Item("bodega")
                    MessageBox.Show("Tiene un inventario pendiente por cerrar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    cargar_inventario(id)
                End If
                resp = True
            Next

        End Using
        Return resp
    End Function
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
            frm.Activate()
            frm.Show()
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub btn_comenzar_Click(sender As Object, e As EventArgs) Handles btn_comenzar.Click
        If cbo_proceso.SelectedValue <> 0 Then
            cargar_centros()
        Else
            cargar_otros()
        End If
    End Sub

    Private Sub cargar_otros()
        If txt_codigo.Text <> "" Then
            If txt_bodega.Text <> "" Then
                Using New Centered_MessageBox(Me)
                    Dim iResponce As Integer = MessageBox.Show("Seguro de iniciar inventario?", "Atención", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                    If iResponce = 6 Then
                        Dim codigo As String = txt_codigo.Text
                        Dim bodega As String = txt_bodega.Text
                        Dim sql_stock As String = "SELECT codigo,stock " & _
                                                          "FROM v_referencias_sto_hoy  " & _
                                                                "WHERE codigo like '" & codigo & "%' AND bodega = " & bodega & " " & _
                                                                         "ORDER BY codigo"
                        Dim dt_stock As DataTable = objOpSimplesLn.listar_datatable(sql_stock, "CORSAN")
                        If dt_stock.Rows.Count > 0 Then
                            Dim listSql As New List(Of Object)
                            Dim sql_id As String = "SELECT (CASE	 WHEN max(id) IS NULL THEN 1 ELSE max(id)+1 END) " & _
                                                 "FROM J_inventario_enc"
                            id = objOpSimplesLn.consultValorTodo(sql_id, "PRODUCCION")
                            Dim sql As String = "INSERT INTO J_inventario_enc (id,nit,fecha,codigo,bodega) VALUES ( " & id & ", " & nit_usuario & ",GETDATE(),'" & codigo & "'," & bodega & ") "
                            listSql.Add(sql)
                            listSql.AddRange(add_detalle(dt_stock))
                            Using New Centered_MessageBox(Me)
                                If objOpSimplesLn.ExecuteSqlTransactionTodo(listSql, "PRODUCCION") Then
                                    tipos = 1
                                    cargar_inventario(id)
                                    Using New Centered_MessageBox(Me)
                                        MessageBox.Show("Inventarios iniciados con exito", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    End Using
                                    tab_ppal.SelectedTab = tab_transaccion

                                Else
                                    Using New Centered_MessageBox(Me)
                                        MessageBox.Show("Erorr al crear la planilla de separe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    End Using
                                End If
                            End Using
                        Else
                            Using New Centered_MessageBox(Me)
                                MessageBox.Show("El rango de código ingresado no existe", "Rango de codigo incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            End Using
                        End If
                    End If
                End Using
            Else
                Using New Centered_MessageBox(Me)
                    MessageBox.Show("Ingrese bodega", "Ingrese bodega", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End Using
            End If
        Else
            Using New Centered_MessageBox(Me)
                MessageBox.Show("Ingrese código para inventarios", "Ingrese código", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Using
        End If
    End Sub

    Private Sub cargar_centros()
        Using New Centered_MessageBox(Me)
            Dim iResponce As Integer = MessageBox.Show("Seguro de iniciar inventario?", "Atención", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
            If iResponce = 6 Then
                Dim bodega As String = ""
                Dim dato As String = ""
                If cbo_proceso.SelectedValue = 2300 Then
                    bodega = "12"
                    tp = "P"
                    dato = "scla"
                End If
                If cbo_proceso.SelectedValue = 2200 Then
                    bodega = "13"
                    tp = "R"
                    dato = "srec"
                End If
                If cbo_proceso.SelectedValue = 2800 Then
                    bodega = "11"
                    tp = "G"
                    dato = "saga"
                End If

                Dim listSql As New List(Of Object)
                Dim sql_id As String = "SELECT (CASE	 WHEN max(id) IS NULL THEN 1 ELSE max(id)+1 END) " & _
                                     "FROM J_inventario_enc"
                id = objOpSimplesLn.consultValorTodo(sql_id, "PRODUCCION")
                Dim sql As String = "INSERT INTO J_inventario_enc (id,nit,fecha,codigo,bodega) VALUES ( " & id & ", " & nit_usuario & ",GETDATE(),'" & cbo_proceso.SelectedValue & "'," & bodega & ") "
                listSql.Add(sql)
                listSql.AddRange(cargar_rollos_centro(tp, dato, id))
                Using New Centered_MessageBox(Me)
                    If objOpSimplesLn.ExecuteSqlTransactionTodo(listSql, "PRODUCCION") Then
                        Using New Centered_MessageBox(Me)
                            tipos = 0
                            cargar_rollos(id)
                            MessageBox.Show("Inventarios iniciados con exito", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End Using
                        tab_ppal.SelectedTab = tab_transaccion
                    Else
                        Using New Centered_MessageBox(Me)
                            MessageBox.Show("Erorr al crear la planilla de separe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Using
                    End If
                End Using
            End If
        End Using
    End Sub

    Private Function cargar_rollos_centro(ByVal tp As String, ByVal dato As String, ByVal id As Integer)
        Dim listSql As New List(Of Object)
        Dim sql As String = "SELECT cod_orden,id_detalle,id_rollo FROM J_rollos_tref " & _
                                " WHERE destino = '" & tp & "' AND " & dato & " Is Null AND anulado Is Null"
        Dim dt As DataTable = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")
        For i = 0 To dt.Rows.Count - 1
            sql = "INSERT INTO J_inventario_alambre (cod_orden,id_detalle,id_rollo,inventario) " & _
                        " VALUES ('" & dt.Rows(i).Item("cod_orden") & "','" & dt.Rows(i).Item("id_detalle") & "','" & dt.Rows(i).Item("id_rollo") & "'," & id & ")"
            listSql.Add(sql)
        Next
        Return listSql
    End Function
    Private Function add_detalle(ByRef dt As DataTable) As List(Of Object)
        Dim listSql As New List(Of Object)
        Dim sql_general As String = "INSERT INTO J_inventario_det (id,fisico,codigo,stock) VALUES( " & id & ",0,"
        Dim sql As String = ""
        For i = 0 To dt.Rows.Count - 1
            sql = sql_general & "'" & dt.Rows(i).Item("codigo") & "'," & dt.Rows(i).Item("stock") & ")"
            listSql.Add(sql)
        Next
        Return listSql
    End Function

    Private Sub txt_bodega_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_bodega.KeyPress
        soloNumero(e)
    End Sub
    Private Sub cargar_inventario(ByVal id As Integer)
        Dim tamano_letra As Single = 7.5!
        Dim sql As String = "SELECT codigo,fisico " & _
                                    "FROM J_inventario_det " & _
                                        "WHERE id = " & id & " " & _
                                            "ORDER BY codigo"
        Dim dt As DataTable = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")
        dtgItems.DataSource = dt
        dtgItems.Columns("codigo").DefaultCellStyle = objOperacionesForm.formatoNegrita(tamano_letra)
        dtgItems.Columns("fisico").DefaultCellStyle = objOperacionesForm.formatoNegrita(tamano_letra)
        tab_ppal.SelectedTab = tab_transaccion
        btn_comenzar.Enabled = False
        habilitarCampos(True)
    End Sub

    Private Sub cbo_proceso_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbo_proceso.SelectionChangeCommitted
        If cbo_proceso.SelectedValue <> 0 Then
            txt_bodega.Enabled = False
            txt_codigo.Enabled = False
            If cbo_proceso.SelectedValue = 2200 Then

            End If
        Else
            txt_bodega.Enabled = True
            txt_codigo.Enabled = True
        End If

    End Sub
End Class