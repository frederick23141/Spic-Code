Imports logicaNegocios
Imports entidadNegocios
Public Class Frm_salida_almacen
    Private objOpSimplesLn As New Op_simpesLn
    Private objEnvCorreoLN As New EnvCorreoLN
    Public carga_comp As Boolean = False
    Dim objIngresoProdLn As New Ing_prodLn
    Dim permiso As String
    Dim filaSelect As Integer = 0
    Dim nomb_modulo As String
    Dim entregas_parciales As String = ""
    Private obj_Ing_prodLn As New Ing_prodLn
    Dim objTraslado_bodLn As New traslado_bodLn
    Private objOrdenProdLn As New OrdenProdLn
    Private numero_transaccion As Double
    Dim nit_usuario As String
    Public numeroExistente As Integer

    Public Sub Main(ByVal usuario As UsuarioEn, ByVal numeroExistente As Integer, ByVal nomb_modulo As String)
        permiso = usuario.permiso.Trim
        Me.nomb_modulo = nomb_modulo
        nit_usuario = usuario.nit
        If (permiso.Trim <> "ADMIN" And permiso <> "COMPRAS" And permiso <> "ALMACEN") Then
            cboEntrega.Enabled = False
            col_cant_entregada.ReadOnly = True
            group_transaccion.Enabled = False
            If (numeroExistente <> 0) Then
                btnGuardar.Enabled = False
                dtgSolicitud.Enabled = False
                groupDatosSol.Enabled = False
                txtObservaciones.ReadOnly = True
                cboAprueba.Enabled = False
                colNuevo.Visible = False
                colBorrar.Visible = False
                colCant.ReadOnly = True
            End If
        Else
            If (numeroExistente <> 0) Then
                colDesc.ReadOnly = True
                groupDatosSol.Enabled = False
                cboAprueba.Enabled = False
                txtObservaciones.ReadOnly = True
                colNuevo.Visible = False
                colBorrar.Visible = False
                colCant.ReadOnly = True
            End If
        End If
        If (permiso = "ALMACEN") Then
            If Not IsDBNull(usuario.nit) Then
                If (usuario.nit <> "") Then
                    cboEntrega.SelectedValue = usuario.nit
                End If
            End If
        End If
        If numeroExistente = 0 Then
            If Not IsDBNull(usuario.nit) Then
                If (usuario.nit <> "") Then
                    cboAprueba.SelectedValue = usuario.nit
                End If
            End If
        End If
        Me.numeroExistente = numeroExistente
        carga_comp = True
    End Sub
    Private Sub Frm_salida_almacen_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_cbo()
        For i = 0 To 5
            dtgSolicitud.Rows.Add()
            dtgSolicitud.Item(colCant.Name, i).Value = 0
            dtgSolicitud.Item(ColNumDet.Name, i).Value = i
        Next
        cboFechaSol.Value = Now
    End Sub
    Private Sub cargar_tipo()
        Dim sql As String = "SELECT tipo,tipo + ' - ' + descripcion As descripcion " & _
                           "FROM tipo_transacciones " & _
                               "WHERE tipo IN ('SMPP','COIS')"
        Dim dt As DataTable = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        dt.Rows.Add()
        dt.Rows(dt.Rows.Count - 1).Item("tipo") = 0
        dt.Rows(dt.Rows.Count - 1).Item("descripcion") = "Seleccione"
        cbo_tipo.DataSource = dt
        cbo_tipo.ValueMember = "tipo"
        cbo_tipo.DisplayMember = "descripcion"
        cbo_tipo.SelectedValue = 0
    End Sub
    Private Sub cbo_tipo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbo_tipo.SelectedIndexChanged
        If carga_comp Then
            If cbo_tipo.Text <> "Seleccione" Then
                cargar_modelo()
            End If
        End If
    End Sub
    Private Sub cargar_modelo()
        Dim sql As String = "SELECT CAST( modelo As varchar) As modelo, modelo + ' - ' + descripcion As descripcion " & _
                                "FROM tipo_transacciones_mod " & _
                                    "WHERE tipo ='" & cbo_tipo.SelectedValue & "'"
        Dim dt As DataTable = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        dt.Rows.Add()
        dt.Rows(dt.Rows.Count - 1).Item("modelo") = 0
        dt.Rows(dt.Rows.Count - 1).Item("descripcion") = "Seleccione"
        cbo_modelo.DataSource = dt
        cbo_modelo.ValueMember = "modelo"
        cbo_modelo.DisplayMember = "descripcion"
        cbo_modelo.SelectedValue = 0
    End Sub
    Private Sub cargar_cbo()
        cargar_tipo()
        Dim sql As String
        Dim dt As New DataTable
        Dim dr As DataRow
        sql = "SELECT nit,nombres FROM V_nom_personal_Activo_con_maquila  order by nombres"
        dt = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        dr = dt.NewRow
        dr("nit") = 0
        dr("nombres") = "Seleccione"
        dt.Rows.Add(dr)
        cboQuienSolicita.DataSource = dt
        cboQuienSolicita.ValueMember = "nit"
        cboQuienSolicita.DisplayMember = "nombres"
        cboQuienSolicita.Text = "Seleccione"

        dt = New DataTable
        sql = "SELECT nit,nombres FROM V_nom_personal_Activo_con_maquila where centro = 1200 order by nombres"
        dt = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        dr = dt.NewRow
        dr("nit") = 0
        dr("nombres") = "Seleccione"
        dt.Rows.Add(dr)
        cboEntrega.DataSource = dt
        cboEntrega.ValueMember = "nit"
        cboEntrega.DisplayMember = "nombres"
        cboEntrega.Text = "Seleccione"

        dt = New DataTable
        sql = "SELECT nit,nombres FROM V_nom_personal_Activo_con_maquila  order by nombres"
        dt = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        dr = dt.NewRow
        dr("nit") = 0
        dr("nombres") = "Seleccione"
        dt.Rows.Add(dr)
        cboAprueba.DataSource = dt
        cboAprueba.ValueMember = "nit"
        cboAprueba.DisplayMember = "nombres"
        cboAprueba.Text = "Seleccione"

        sql = "SELECT centro FROM centros WHERE centro >1099 AND (descripcion not like '%caja%' AND descripcion not like '%maquina%') GROUP BY centro, descripcion ORDER by centro "
        dt = New DataTable
        dt = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        cboCentro.DataSource = dt
        cboCentro.ValueMember = "centro"
        cboCentro.DisplayMember = "centro"


    End Sub
    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If (validar()) Then
            guardar()
        End If
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        nuevo()
    End Sub
    Private Sub nuevo()
        entregas_parciales = ""
        cboAprueba.Enabled = True
        txtObservaciones.ReadOnly = False
        btnGuardar.Enabled = True
        dtgSolicitud.Enabled = True
        groupDatosSol.Enabled = True
        cboQuienSolicita.Text = "Seleccione"
        dtgSolicitud.DataSource = Nothing
        colCant.ReadOnly = False
        txtObservaciones.Text = ""
        cboEntrega.Text = "Seleccione"
        dtgSolicitud.Rows.Clear()
        For i = 0 To 5
            dtgSolicitud.Rows.Add()
            dtgSolicitud.Item(colCant.Name, i).Value = 0
            dtgSolicitud.Item(col_cant_entregada.Name, i).Value = 0
            dtgSolicitud.Item(ColNumDet.Name, i).Value = i
        Next
        numeroExistente = 0
    End Sub
    Private Sub guardar()
        dtgSolicitud.CurrentCell = Nothing
        Dim insertoCorrecto As Boolean = False
        Dim listSql As New List(Of Object)
        Dim numero As Integer = 0
        Dim solicitante As String = cboQuienSolicita.SelectedValue
        Dim entrega As String = cboEntrega.SelectedValue
        Dim observaciones As String = txtObservaciones.Text
        Dim autoriza As String = cboEntrega.SelectedValue
        Dim aprueba As String = cboAprueba.SelectedValue
        Dim sqlDet As String = ""
        Dim sqlEnc As String = ""
        Dim medida As String = ""
        Dim entregado As String = "0"

        If (numeroExistente = 0) Then
            numero = objIngresoProdLn.consultar_valor("SELECT MAX (numero)  FROM J_salida_almacen_enc ", "PRODUCCION") + 1
        Else
            numero = numeroExistente
        End If
        sqlDet = "DELETE FROM J_salida_almacen_det WHERE numero =" & numero
        listSql.Add(sqlDet)
        sqlEnc = "DELETE FROM J_salida_almacen_enc WHERE numero =" & numero
        listSql.Add(sqlEnc)
        sqlEnc = "INSERT INTO J_salida_almacen_enc (numero,fecha,aprueba,entrega,solicita,observaciones) " & _
                            "VALUES (" & numero & ",GETDATE(),'" & aprueba & "','" & entrega & "'," & solicitante & ",'" & observaciones & "')"
        listSql.Add(sqlEnc)


        For i = 0 To dtgSolicitud.RowCount - 1
            If (dtgSolicitud.Item(colDesc.Name, i).Value <> "") Then
                If (dtgSolicitud.Item(colDesc.Name, i).Value.ToString <> "") Then
                    If Not IsDBNull(dtgSolicitud.Item(col_cant_entregada.Name, i).Value) Then
                        If IsNumeric(dtgSolicitud.Item(col_cant_entregada.Name, i).Value) Then
                            entregado = dtgSolicitud.Item(col_cant_entregada.Name, i).Value
                        End If
                    End If
                    If Not IsDBNull(dtgSolicitud.Item(col_cant_entregada.Name, i).Value) Then
                        If IsNumeric(dtgSolicitud.Item(col_cant_entregada.Name, i).Value) Then
                            entregado = dtgSolicitud.Item(col_cant_entregada.Name, i).Value
                        End If
                    End If
                    If Not IsDBNull(dtgSolicitud.Item(col_cant_entregada.Name, i).Value) Then
                        If IsNumeric(dtgSolicitud.Item(col_cant_entregada.Name, i).Value) Then
                            entregado = dtgSolicitud.Item(col_cant_entregada.Name, i).Value
                        End If
                    End If
                    sqlDet = "INSERT INTO J_salida_almacen_det (numero,id_detalle,codigo,cantidad,cant_entregada,centro) VALUES " & _
                                "(" & numero & "," & i & ",'" & dtgSolicitud.Item(colCodigo.Name, i).Value & "'," & dtgSolicitud.Item(colCant.Name, i).Value & "," & entregado & "," & dtgSolicitud.Item(cboCentro.Name, i).Value & " )"
                    listSql.Add(sqlDet)
                End If
            End If
        Next
        insertoCorrecto = objIngresoProdLn.ExecuteSqlTransaction(listSql, "PRODUCCION")
        If (insertoCorrecto) Then
            If (solicitudCompleta()) Then
                If (objIngresoProdLn.ejecutar("UPDATE J_salida_almacen_enc SET terminado = 1 WHERE numero =" & numero, "PRODUCCION") > 0) Then
                    MessageBox.Show("La solicitud fue  terminada en forma correcta ", "Correcto!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("La orden se modifico, pero no se cerro , comuniquese con el administrador del sistema!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                MessageBox.Show("La solicitud fue modificada en forma exitosa! ", "Correcto!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            MessageBox.Show("La solicitud fue guardada en forma exitosa!,solicitud número " & numero, "Correcto!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            nuevo()
        Else
            MessageBox.Show("Error al guardar la solicitud comuniquese con el administrador del sistema ", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
   
    Private Sub enviarCorreo(ByVal numero As String, ByVal texto As String, ByVal titulo As String, ByVal destino As String)
        imgProc.Visible = True
        Application.DoEvents()
        Dim direccion As String = ""
        Dim email As String = objOpSimplesLn.consultarVal("SELECT Mail from jjv_usuarios WHERE usuario ='ADMIN'")
        Dim contra As String = objOpSimplesLn.consultarVal("SELECT Mail_login from jjv_usuarios WHERE usuario ='ADMIN'")
        If Not (objEnvCorreoLN.EnviarCorreo(destino, texto, titulo, direccion, email, contra, False)) Then
            Using New Centered_MessageBox(Me)
                MessageBox.Show("Error al enviar el correo,comuniquese con el administrador del sistema!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Using
        End If
        imgProc.Visible = False
    End Sub
    Private Function validar() As Boolean
        Dim resp As Boolean = False
        Dim cantProductos As Integer = 0
        dtgSolicitud.CurrentCell = Nothing
        If (txtObservaciones.Text <> "") Then
            If (cboQuienSolicita.Text <> "Seleccione" And dtgSolicitud.RowCount >= 0) Then
                If (cboAprueba.Text <> "Seleccione") Then
                    For i = 0 To dtgSolicitud.RowCount - 1
                        If (dtgSolicitud.Item(colCodigo.Name, i).Value <> "") Then
                            cantProductos += 1
                            If (dtgSolicitud.Item(colCant.Name, i).Value <> 0) Then
                                If (dtgSolicitud.Item(colMedida.Name, i).Value <> "") Then
                                    resp = True
                                Else
                                    resp = False
                                    MessageBox.Show("Se debe ingresar el tipo de  medida del producto", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                End If

                            Else
                                resp = False
                                MessageBox.Show("La cantidad del  producto de la fila " & i + 1 & " no puede ser ingresado en 0 ", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                i = dtgSolicitud.RowCount - 1
                            End If

                        End If
                    Next
                    If (cantProductos = 0) Then
                        MessageBox.Show("Se debe ingresar al menos 1 producto para crear la solicitud ", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        resp = False
                    End If
                Else
                    MessageBox.Show("Responsable es obligatorio", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                MessageBox.Show("Verifiqe que el campo quien solicita y los productos este llenos ", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            MessageBox.Show("El campo observaciones es obligatorio ", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        Return resp
    End Function
  
    Private Function existeNumDet(ByVal num_det As Integer, ByVal numero As Integer) As Boolean
        Dim sql As String = "SELECT num_det FROM J_salida_almacen_det WHERE num_det = " & num_det & " AND numero = " & numero
        If (objIngresoProdLn.consultValor(sql, "PRODUCCION") = "") Then
            Return False
        Else
            Return True
        End If
    End Function
 
    Private Function solicitudCompleta() As Boolean
        Dim resp As Boolean = False
        For i = 0 To dtgSolicitud.RowCount - 1
            If (dtgSolicitud.Item(colDesc.Name, i).Value <> "") Then
                If (dtgSolicitud.Item(colDesc.Name, i).Value.ToString <> "") Then
                    If Not IsDBNull(dtgSolicitud.Item(col_cant_entregada.Name, i).Value) Then
                        If IsNumeric(dtgSolicitud.Item(col_cant_entregada.Name, i).Value) Then
                            If Not IsDBNull(dtgSolicitud.Item(colCant.Name, i).Value) Then
                                If IsNumeric(dtgSolicitud.Item(colCant.Name, i).Value) Then
                                    If (dtgSolicitud.Item(col_cant_entregada.Name, i).Value >= dtgSolicitud.Item(colCant.Name, i).Value) Then
                                        resp = True
                                    Else
                                        i = dtgSolicitud.RowCount - 1
                                        resp = False
                                    End If

                                End If
                            End If
                        End If
                    End If

                End If
            End If
        Next
        Return resp
    End Function

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        FrmPrincipal.Show()
        Me.Close()
        FrmPrincipal.Activate()
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        FrmLogin.Show()
        FrmPrincipal.Close()
        Me.Close()
    End Sub
    Private Sub dtgSolicitud_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgSolicitud.CellClick
        If (e.RowIndex >= 0) Then
            Dim col As String = dtgSolicitud.Columns(e.ColumnIndex).Name
            If (col = colBorrar.Name) Then
                Dim resp As Integer = MessageBox.Show("Seguro que desea eliminar el registro? ", "Eliminar?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If (resp = 6) Then
                    If (numeroExistente <> 0) Then
                        If (dtgSolicitud.Item(colDesc.Name, e.RowIndex).Value <> "") Then
                            Dim num_detalle As Integer = dtgSolicitud.Item(ColNumDet.Name, e.RowIndex).Value
                            Dim sql As String = "DELETE FROM J_salida_almacen_det WHERE numero = " & numeroExistente & " AND id_det =" & num_detalle
                            If (objOpSimplesLn.ejecutar(sql, "PRODUCCION") <= 0) Then
                                MessageBox.Show("Error al eliminar el registrocomuniquese con el administrador del sistema ", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End If
                        End If
                    End If
                    dtgSolicitud.Rows.RemoveAt(e.RowIndex)
                    dtgSolicitud.Rows.Add()
                    dtgSolicitud.Item(colCant.Name, dtgSolicitud.RowCount - 1).Value = 0
                    dtgSolicitud.Item(col_cant_entregada.Name, dtgSolicitud.RowCount - 1).Value = 0
                End If
            ElseIf (col = colNuevo.Name) Then
                dtgSolicitud.Rows.Add()
                dtgSolicitud.Item(colCant.Name, dtgSolicitud.RowCount - 1).Value = 0
                dtgSolicitud.Item(col_cant_entregada.Name, dtgSolicitud.RowCount - 1).Value = 0
            ElseIf (col = colCodigo.Name Or col = colDesc.Name) Then
                txtDesc.Text = ""
                txtCodigo.Text = ""
                groupCodigo.Visible = True
                txtDesc.Focus()
                filaSelect = e.RowIndex
            End If
        End If
    End Sub

    Private Sub dtgSolicitud_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgSolicitud.CellValueChanged
        If (carga_comp And e.RowIndex >= 0) Then
            Dim col As String = dtgSolicitud.Columns(e.ColumnIndex).Name
            Dim valor As String = dtgSolicitud.Item(col, e.RowIndex).Value
            If (col = colCant.Name) Then
                If (valor = "") Then
                    MessageBox.Show("El la cantidad del producto no puede ser ingresado vacio", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    carga_comp = False
                    dtgSolicitud.Item(col, e.RowIndex).Value = 0
                    carga_comp = True
                Else
                    If Not IsNumeric(valor) Then
                        MessageBox.Show("El valor ingresado debe ser númerico", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        carga_comp = False
                        dtgSolicitud.Item(col, e.RowIndex).Value = 0
                        carga_comp = True
                    End If
                End If
            ElseIf (col = col_cant_entregada.Name) Then
                If (valor = "") Then
                    MessageBox.Show("El la cantidad entregada no puede ser ingresado vacio", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    carga_comp = False
                    dtgSolicitud.Item(col, e.RowIndex).Value = 0
                    carga_comp = True
                Else
                    If Not IsNumeric(valor) Then
                        MessageBox.Show("El valor ingresado debe ser númerico", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        carga_comp = False
                        dtgSolicitud.Item(col, e.RowIndex).Value = 0
                        carga_comp = True
                    End If
                End If
         
            End If
        End If
    End Sub


    Public Sub eliminarNoUsadas()
        For i = 0 To dtgSolicitud.RowCount - 1
            If IsNothing(dtgSolicitud.Item(colDesc.Name, i).Value) Then
                dtgSolicitud.Rows(i).Visible = False
            Else
                If (dtgSolicitud.Item(colDesc.Name, i).Value.ToString = "") Then
                    dtgSolicitud.Rows(i).Visible = False
                End If
            End If
        Next
    End Sub

    Private Sub btnCerrarEditResp_Click(sender As Object, e As EventArgs) Handles btnCerrarEditResp.Click
        groupCodigo.Visible = False
        dtgCodigo.DataSource = Nothing
    End Sub

    Private Sub dtgCodigo_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgCodigo.CellClick
        If (e.RowIndex >= 0) Then
            Dim codigo As String = dtgCodigo.Item("codigo", e.RowIndex).Value
            Dim descripcion As String = dtgCodigo.Item("descripcion", e.RowIndex).Value
            Dim costo_unitario As Double = 0
            Dim generico As String = ""
            If Not IsDBNull(dtgCodigo.Item("costo_unitario", e.RowIndex).Value) Then
                costo_unitario = dtgCodigo.Item("costo_unitario", e.RowIndex).Value
            End If
            If Not IsDBNull(dtgCodigo.Item("generico", e.RowIndex).Value) Then
                generico = dtgCodigo.Item("generico", e.RowIndex).Value
            End If

            Dim sqlStock_b1 As String = "SELECT stock " & _
                                    "FROM v_referencias_sto_hoy " & _
                                         "WHERE bodega = 1 AND codigo = '" & codigo & "'"
            Dim sqlStock_b5 As String = "SELECT stock " & _
                             "FROM v_referencias_sto_hoy " & _
                                  "WHERE bodega = 5 AND codigo = '" & codigo & "'"
            Dim stock_b1 As String = objOpSimplesLn.consultarVal(sqlStock_b1)
            Dim stock_b5 As String = objOpSimplesLn.consultarVal(sqlStock_b5)
            dtgSolicitud.Item(colCodigo.Name, filaSelect).Value = codigo
            dtgSolicitud.Item(colDesc.Name, filaSelect).Value = descripcion
            dtgSolicitud.Item(colStock_b1.Name, filaSelect).Value = stock_b1
            dtgSolicitud.Item(colStock_b5.Name, filaSelect).Value = stock_b5
            dtgSolicitud.Item(colCosto.Name, filaSelect).Value = costo_unitario
            dtgSolicitud.Item(colMedida.Name, filaSelect).Value = generico
            btnCerrarEditResp.PerformClick()
        End If
    End Sub

    Private Sub txtDesc_TextChanged(sender As Object, e As EventArgs) Handles txtDesc.TextChanged
        If (txtDesc.Text.Length > 1) Then
            cargarCodigos("", txtDesc.Text)
        End If
    End Sub

    Private Sub txtCodigo_TextChanged(sender As Object, e As EventArgs) Handles txtCodigo.TextChanged
        If (txtCodigo.Text.Length > 1) Then
            cargarCodigos(txtCodigo.Text, "")
        End If
    End Sub
    Private Sub cargarCodigos(ByVal codigo As String, ByVal descripcion As String)
        Dim where_sql As String = ""
        If (codigo <> "") Then
            where_sql &= " codigo like '" & codigo & "%' "
        ElseIf (descripcion <> "") Then
            where_sql &= " descripcion like '%" & descripcion & "%'"
        End If
        Dim sql As String = "SELECT codigo,descripcion,costo_unitario,generico FROM referencias WHERE " & where_sql & ""
        dtgCodigo.DataSource = objOpSimplesLn.listar_datatable(sql, "CORSAN")
    End Sub

    Private Sub btn_transaccion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_transaccion.Click
        If numeroExistente <> 0 Then
            Dim msgbox As DialogResult
            msgbox = MessageBox.Show("Desea realizar la transaccion? ", "Seleccione", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
            If msgbox = vbYes Then
                If validar_transaccion() Then
                    transaccion()
                End If
            End If
        Else
            MessageBox.Show("Seleccione una solicitud de almacén", "Seleccione solicitud!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        
    End Sub
    Private Function validar_transaccion()
        Dim resp As Boolean = False
        If cbo_tipo.SelectedValue <> "0" Then
            If cbo_modelo.SelectedValue <> 0 Then
                If cbo_bodega.Text <> "Seleccione" Then
                    resp = True
                Else
                    MessageBox.Show("Seleccione una bodega", "Seleccione bodega!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                MessageBox.Show("Seleccione modelo de transacción", "Seleccione modelo!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            MessageBox.Show("Seleccione tipo de transacción", "Seleccione tipo!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Return resp
    End Function
    Private Sub transaccion()
        Using New Centered_MessageBox(Me)
            Dim sql_codigos_transaccio As String = ""
            Dim resp_transaccion As Boolean = False
            Dim tipo As String = cbo_tipo.SelectedValue
            Dim modelo As String = cbo_modelo.SelectedValue
            Dim bodega As Integer = cbo_bodega.Text
            Dim notas As String = "SPIC traslado(HandHeld) " & Now & " usuario: " & nit_usuario
            Dim dFec As Date = Now
            Dim usuario As String = nit_usuario
            Dim listSql As New List(Of Object)
            Dim listTransaccion_corsan As New List(Of Object)
            Dim listTransaccion_prod As New List(Of Object)
            Dim sqltrans As String
            Dim resp As Boolean = False
            Dim sql_solicitud As String = ""
            Dim stock As Double = 0
            Dim val_stock As Boolean = True
            dtgSolicitud.CurrentCell = Nothing
            For i = 0 To dtgSolicitud.RowCount - 1
                If (dtgSolicitud.Item(col_cant_entregada.Name, i).Value <> 0) Then
                    resp = True
                End If
            Next
            Dim dt As New DataTable
            If resp Then
                sqltrans = "select trans from J_salida_almacen_enc where numero=" & numeroExistente & ""
                Dim trans As String = objOpSimplesLn.consultValorTodo(sqltrans, "PRODUCCION")
                If trans = "" Then
                    dt.Columns.Add("codigo")
                    dt.Columns.Add("cantidad")
                    For i = 0 To dtgSolicitud.Rows.Count - 1
                        If dtgSolicitud.Item("colCodigo", i).Value <> Nothing And IsNumeric(dtgSolicitud.Item("colCant", i).Value <> Nothing) Then
                            stock = objOpSimplesLn.consultarStock(dtgSolicitud.Item("colCodigo", i).Value, bodega)
                            If (dtgSolicitud.Item("colCant", i).Value <= stock) Then
                                dt.Rows.Add()
                                dt.Rows(dt.Rows.Count - 1).Item("codigo") = dtgSolicitud.Item("colCodigo", i).Value
                                dt.Rows(dt.Rows.Count - 1).Item("cantidad") = dtgSolicitud.Item("colCant", i).Value
                            Else
                                val_stock = False
                                MessageBox.Show("No hay stock disponible para " & dtgSolicitud.Item(colDesc.Name, i).Value & ",  bodega " & bodega, "ingrese códigos", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            End If
                        End If
                    Next
                    If val_stock Then
                        If dt.Rows.Count > 0 Then
                            listTransaccion_corsan.AddRange(traslado_bodega(dt, tipo, modelo, bodega))
                            obj_Ing_prodLn.ExecuteSqlTransaction(listTransaccion_corsan, "CORSAN")
                            Dim sql As String = "update J_salida_almacen_enc set trans=" & numero_transaccion & " , tipo_trans='" & tipo & "' where  numero =" & numeroExistente & ""
                            objOpSimplesLn.listar_datatable(sql, "PRODUCCION")
                            MessageBox.Show("Transacción realizada con exito! ", tipo & ": " & Convert.ToString(numero_transaccion), MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Else
                            MessageBox.Show("Ingrese códigos para la transacción", "ingrese códigos", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If
                    End If
                Else
                    MessageBox.Show("Salida ya transaccionada! ", tipo & ": " & "Ya transaccionada", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                MessageBox.Show("No se encontro ningun producto entregado ", tipo & ": " & " transaccionar", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End Using
    End Sub
    Private Function traslado_bodega(ByVal dt As DataTable, ByVal tipo As String, ByVal modelo As String, ByVal bodega As Integer) As List(Of Object)
        Dim listSql As New List(Of Object)
        Dim dFec As Date = Now
        Dim usuario As String = nit_usuario
        Dim notas As String = "SPIC fecha:" & Now & " usuario:" & usuario
        numero_transaccion = objOrdenProdLn.mover_consecutivo(tipo)
        listSql = objTraslado_bodLn.listaTransaccionDatable(numero_transaccion, dt, bodega, dFec, notas, usuario, tipo, modelo)
        Return listSql
    End Function
End Class