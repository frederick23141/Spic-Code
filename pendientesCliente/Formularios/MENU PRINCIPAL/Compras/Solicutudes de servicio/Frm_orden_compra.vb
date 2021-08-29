Imports logicaNegocios
Imports entidadNegocios
Public Class Frm_orden_compra
    Private objOpSimplesLn As New Op_simpesLn
    Private objEnvCorreoLN As New EnvCorreoLN
    Private val_punt As New obj_val_punt
    Public carga_comp As Boolean = False
    Dim objIngresoProdLn As New Ing_prodLn
    Private objOrdenProdLn As New OrdenProdLn
    Private obj_Ing_prodLn As New Ing_prodLn
    Private objTraslado_bodLn As New traslado_bodLn
    Dim permiso As String
    Dim numeroExistente As Integer
    Dim colSelect As Integer = 0
    Dim nomb_modulo As String
    Dim idventana As String
    Dim num_principal As Integer
    Dim user As String
    Dim entregas_parciales As String = ""
    Dim numero_transaccion As Double

    Public Sub Main(ByVal usuario As UsuarioEn, ByVal numeroExistente As Integer, ByVal nomb_modulo As String, ByVal idven As String)
        permiso = usuario.permiso.Trim
        user = usuario.nit.Trim
        Me.nomb_modulo = nomb_modulo
        num_principal = numeroExistente
        idventana = idven
        If (permiso.Trim <> "ADMIN" And permiso <> "COMPRAS" And permiso <> "ALMACEN" And permiso <> "DIR_PRODUCCION") Then
            cboautoriza.Enabled = False
            cbocuenta.Visible = False
            colCantAut.ReadOnly = True
            col_cant_entregada.ReadOnly = True
            colPrecio.ReadOnly = True
            Id_proveedor.Visible = False
            colProveedor.Visible = False
            lblfactura.Visible = False
            txtnumerofac.Visible = False
            btnfinalizar.Visible = False
            cboResponsable.Enabled = True
            If (numeroExistente <> 0) Then
                btnGuardar.Enabled = False
                dtgSolicitud.Enabled = False
                groupDatosSol.Enabled = False
                txtObservaciones.ReadOnly = True
                cboResponsable.Enabled = False
                colNuevo.Visible = False
                colBorrar.Visible = False
                colCant.ReadOnly = True
            Else
                If Not IsDBNull(usuario.nit) Then
                    If (usuario.nit <> "") Then
                        cboResponsable.SelectedValue = 0
                        'cboResponsable.Enabled = False
                    End If
                End If
            End If
        Else
            colProveedor.Visible = True
            txtObserAlmacen.ReadOnly = False
            chk_ped_realizado.Enabled = True
            If (numeroExistente <> 0) Then
                If idventana = "S" Then
                    lblfactura.Visible = True
                    txtnumerofac.Visible = True
                    chk_contabilizado.Visible = True
                Else
                    lblfactura.Visible = False
                    txtnumerofac.Visible = False
                    chk_contabilizado.Visible = False
                End If
                colDesc.ReadOnly = True
                groupDatosSol.Enabled = False
                cboResponsable.Enabled = False
                txtObservaciones.ReadOnly = True
                colNuevo.Visible = False
                colBorrar.Visible = False
                colCant.ReadOnly = True
            Else
                If idventana = "S" Then
                    lblfactura.Visible = True
                    txtnumerofac.Visible = True
                Else
                    lblfactura.Visible = False
                    txtnumerofac.Visible = False
                End If
            End If
        End If
        Me.numeroExistente = numeroExistente
        caluclar_val_autorizado()
        If idventana = "S" Then
            Me.Text = "Generar solicitud de servicio"
            Label10.Text = "Observaciones de Solicitud"
            btn_Transaccion_Salida.Visible = True
        End If
        carga_comp = True
    End Sub
    Private Sub Frm_orden_compra_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_cbo()

        For i = 0 To 5
            dtgSolicitud.Rows.Add()
            dtgSolicitud.Item(colCant.Name, i).Value = 0
            dtgSolicitud.Item(colCantAut.Name, i).Value = 0
            dtgSolicitud.Item(Id_proveedor.Name, i).Value = 0
            dtgSolicitud.Item(ColNumDet.Name, i).Value = i
        Next
    End Sub

    Public Sub cargar_cbo()
        Dim sql As String
        Dim dt As New DataTable
        Dim dr As DataRow


        sql = "SELECT nit,nombres FROM V_nom_personal_Activo_con_maquila order by nombres"
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
        cboRecive.DataSource = dt
        cboRecive.ValueMember = "nit"
        cboRecive.DisplayMember = "nombres"
        cboRecive.Text = "Seleccione"

        If numeroExistente = 0 Then
            dt = New DataTable
            sql = "SELECT P.nit,P.nombres FROM corsan.dbo.V_nom_personal_Activo_con_maquila P,J_solicitud_compra_responsables R where P.nit = R.nit and p.nit=" & user & " order by P.nombres"
            dt = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")
            dr = dt.NewRow
            dr("nit") = 0
            dr("nombres") = "Seleccione"
            dt.Rows.Add(dr)
            cboResponsable.DataSource = dt
            cboResponsable.ValueMember = "nit"
            cboResponsable.DisplayMember = "nombres"
            cboResponsable.Text = "Seleccione"
        Else
            dt = New DataTable
            sql = "SELECT P.nit,P.nombres FROM corsan.dbo.V_nom_personal_Activo_con_maquila P,J_solicitud_compra_responsables R where P.nit = R.nit order by P.nombres"
            dt = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")
            dr = dt.NewRow
            dr("nit") = 0
            dr("nombres") = "Seleccione"
            dt.Rows.Add(dr)
            cboResponsable.DataSource = dt
            cboResponsable.ValueMember = "nit"
            cboResponsable.DisplayMember = "nombres"
            cboResponsable.Text = "Seleccione"
        End If

        dt = New DataTable
        sql = "SELECT nit,nombres FROM V_nom_personal_Activo_con_maquila where centro not in (4200) order by nombres"
        dt = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        dr = dt.NewRow
        dr("nit") = 0
        dr("nombres") = "Seleccione"
        dt.Rows.Add(dr)
        cboautoriza.DataSource = dt
        cboautoriza.ValueMember = "nit"
        cboautoriza.DisplayMember = "nombres"
        cboautoriza.Text = "Seleccione"


        sql = "select cuenta,CONCAT(cuenta,'-', descripcion) as descripcion  from cuentas where cuenta in (SELECT cuenta FROM J_ppto_gastos_permisos_cuentas WHERE permiso = 'ADMIN')"
        dt = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        dr = dt.NewRow
        dr("cuenta") = 0
        dr("descripcion") = "Seleccione"
        dt.Rows.Add(dr)
        cbocuenta.DataSource = dt
        cbocuenta.ValueMember = "cuenta"
        cbocuenta.DisplayMember = "descripcion"
      
        sql = "SELECT CONVERT (varchar ,centro )As centro  FROM centros WHERE centro >1099 GROUP BY centro ORDER by centro "
        dt = New DataTable
        dt = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        dr = dt.NewRow
        dr("centro") = "Seleccione"
        dt.Rows.Add(dr)
        cboCentro.DataSource = dt
        cboCentro.ValueMember = "centro"
        cboCentro.DisplayMember = "centro"
        cboCentro.Text = "Seleccione"

    End Sub
    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        dtgSolicitud.CurrentCell = Nothing
        If (validar()) Then
            If (numeroExistente = 0) Then
                If (permiso = "ADMIN" Or permiso = "COMPRAS" Or permiso = "ALMACEN") Then
                    pintarFaltantes()
                    guardarCompleto()
                Else
                    crearSolicitud()
                End If
            Else
                If (permiso = "ADMIN" Or permiso = "COMPRAS" Or permiso = "ALMACEN") Then
                    pintarFaltantes()
                    guardarCambios()
                End If
            End If
        End If
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        nuevo()
    End Sub
    Private Sub nuevo()
        entregas_parciales = ""
        cboResponsable.Enabled = True
        cboResponsable.SelectedValue = 0
        txtObservaciones.ReadOnly = False
        btnGuardar.Enabled = True
        dtgSolicitud.Enabled = True
        groupDatosSol.Enabled = True
        cboQuienSolicita.Text = "Seleccione"
        cboCentro.Text = "Seleccione"
        cboRecive.Text = "Seleccione"
        dtgSolicitud.DataSource = Nothing
        txtObservaciones.Text = ""
        cboautoriza.Text = "Seleccione"
        dtgSolicitud.Rows.Clear()
        For i = 0 To 5
            dtgSolicitud.Rows.Add()
            dtgSolicitud.Item(colCant.Name, i).Value = 0
            dtgSolicitud.Item(col_cant_entregada.Name, i).Value = 0
            dtgSolicitud.Item(colCantAut.Name, i).Value = 0
            dtgSolicitud.Item(ColNumDet.Name, i).Value = i
            dtgSolicitud.Item(Id_proveedor.Name, i).Value = 0
        Next
        txtValTot.Text = 0
        numeroExistente = 0
    End Sub
    Private Sub guardarCompleto()
        Dim centro As String = cboCentro.SelectedValue
        Dim insertoCorrecto As Boolean = False
        Dim listSql As New List(Of Object)
        Dim numero As Integer = 0
        Dim solicitante As String = cboQuienSolicita.SelectedValue
        Dim fecha_solicitud As String = objOpSimplesLn.cambiarFormatoFecha(cboFechaSol.Value)
        Dim fecha_espera As String = objOpSimplesLn.cambiarFormatoFecha(cboFechaEsp.Value)
        Dim recive As String = cboRecive.SelectedValue
        Dim fecha_recive As String = objOpSimplesLn.cambiarFormatoFecha(cboFecRecepcion.Value)
        Dim observaciones As String = txtObservaciones.Text
        Dim autoriza As String = cboautoriza.SelectedValue
        Dim responsable As String = cboResponsable.SelectedValue
        Dim sqlDet As String = ""
        Dim sqlEnc As String = ""
        Dim medida As String = ""
        Dim cuenta As String = ""
        Dim entregado As String = "0"
        Dim ped_realizado As String = ""
        Dim precio_unit As Double = 0
        Dim notas_almacen As String = txtObserAlmacen.Text
        Dim numerfact As String = txtnumerofac.Text
        Dim contabilizado As String = "N"
        Dim trans_salida As String = ""
#Disable Warning BC42024 ' Variable local sin usar: 'sql_ver_trans'.
        Dim sql_ver_trans As String
#Enable Warning BC42024 ' Variable local sin usar: 'sql_ver_trans'.
#Disable Warning BC42024 ' Variable local sin usar: 'val_trans'.
        Dim val_trans As String
#Enable Warning BC42024 ' Variable local sin usar: 'val_trans'.
#Disable Warning BC42024 ' Variable local sin usar: 'val_Cantidad_Act'.
        Dim val_Cantidad_Act As String
#Enable Warning BC42024 ' Variable local sin usar: 'val_Cantidad_Act'.
        If chk_contabilizado.Checked Then
            contabilizado = "S"
        End If
        If (chk_ped_realizado.Checked) Then
            ped_realizado = 1
        Else
            ped_realizado = "NULL"
        End If
        If (numeroExistente = 0) Then
            numero = objIngresoProdLn.consultar_valor("SELECT MAX (numero)  FROM J_solicitud_compra_enc ", "PRODUCCION") + 1
        Else
            numero = numeroExistente
        End If
        sqlEnc = "INSERT INTO J_solicitud_compra_enc (numero,solicitante,fecha_solicitud,fecha_espera,recive,fecha_recive,observaciones,autoriza,responsable,pedido_realizado,centro,obserAlmacen,d_orden,numero_fact,contabilizado) " &
                          "VALUES (" & numero & "," & solicitante & ",'" & fecha_solicitud & "','" & fecha_espera & "','" & recive & "','" & fecha_recive & "','" & observaciones & "'," & autoriza & "," & responsable & "," & ped_realizado & "," & centro & ",'" & notas_almacen & "','" & idventana & "','" & numerfact & "','" & contabilizado & "') "
        listSql.Add(sqlEnc)
        For i = 0 To dtgSolicitud.RowCount - 1
            If (dtgSolicitud.Item(colDesc.Name, i).Value <> "") Then
                If (dtgSolicitud.Item(colDesc.Name, i).Value.ToString <> "") Then
                    If Not IsDBNull(dtgSolicitud.Item(colMedida.Name, i).Value) Then
                        If (dtgSolicitud.Item(colMedida.Name, i).Value.ToString <> "") Then
                            medida = dtgSolicitud.Item(colMedida.Name, i).Value
                        Else
                            medida = ""
                        End If
                    Else
                        medida = ""
                    End If
                    If Not IsDBNull(dtgSolicitud.Item(cbocuenta.Name, i).Value) Then
                        If (dtgSolicitud.Item(cbocuenta.Name, i).Value <> Nothing) Then
                            cuenta = dtgSolicitud.Item(cbocuenta.Name, i).Value
                        Else
                            cuenta = "0"
                        End If
                    Else
                        cuenta = "0"
                    End If
                    If Not IsDBNull(dtgSolicitud.Item(col_cant_entregada.Name, i).Value) Then
                        If IsNumeric(dtgSolicitud.Item(col_cant_entregada.Name, i).Value) Then
                            entregado = dtgSolicitud.Item(col_cant_entregada.Name, i).Value
                        End If
                    End If

                    If Not IsDBNull(dtgSolicitud.Item(colPrecio.Name, i).Value) Then
                        If IsNumeric(dtgSolicitud.Item(colPrecio.Name, i).Value) Then
                            precio_unit = dtgSolicitud.Item(colPrecio.Name, i).Value
                        End If
                    End If
                    sqlDet = "INSERT INTO J_solicitud_compra_det (numero,num_det,descripcion_solicitante,cantidad,cantidad_aut,medida,entregado,precio_unit,nit_proveedor,cuenta,cantidad_trans,cantidad_trans_ent) VALUES(" & numero & "," & i & ",'" & dtgSolicitud.Item(colDesc.Name, i).Value & "'," & dtgSolicitud.Item(colCant.Name, i).Value & "," & dtgSolicitud.Item(colCantAut.Name, i).Value & ",'" & medida & "'," & entregado & "," & precio_unit & ",'" & dtgSolicitud.Item(Id_proveedor.Name, i).Value & "'," & cuenta & ",0,0)"
                    listSql.Add(sqlDet)
                End If
            End If
        Next
        insertoCorrecto = objIngresoProdLn.ExecuteSqlTransaction(listSql, "PRODUCCION")

        'For i = 0 To dtgSolicitud.RowCount - 1

        '    If Not IsDBNull(dtgSolicitud.Item(colDesc.Name, i).Value) Then
        '        Dim cod As String = dtgSolicitud.Item(colDesc.Name, i).Value
        '        If Not IsNothing(cod) Then
        '            If Not cod.ToUpper Like ("2T*") Then
        '                If val_punt.validar_codigos_bodega_8(dtgSolicitud.Item(colDesc.Name, i).Value) Then
        '                    If CInt(dtgSolicitud.Item(colCant.Name, i).Value) >= CInt(dtgSolicitud.Item(colCantAut.Name, i).Value) Then
        '                        sql_ver_trans = " select cantidad_trans from J_solicitud_compra_det where numero=" & numero & " and num_det=" & i & ""
        '                        val_Cantidad_Act = objOpSimplesLn.consultValorTodo(sql_ver_trans, "PRODUCCION")
        '                        If CInt(dtgSolicitud.Item(colCant.Name, i).Value) > CInt(val_Cantidad_Act) Then
        '                            If Not IsDBNull(dtgSolicitud.Item(colCantAut.Name, i).Value) Then
        '                                If IsNumeric(dtgSolicitud.Item(colCantAut.Name, i).Value) Then
        '                                    If dtgSolicitud.Item(colCantAut.Name, i).Value > 0 Then
        '                                        Dim resta_Trans As Double
        '                                        resta_Trans = CDbl(dtgSolicitud.Item(colCantAut.Name, i).Value) - CDbl(val_Cantidad_Act)
        '                                        realizarSalidaTrans(dtgSolicitud.Item(colDesc.Name, i).Value, resta_Trans)
        '                                        sql_ver_trans = "UPDATE J_solicitud_compra_det SET cantidad_trans+=" & resta_Trans & "  where numero=" & numero & " and num_det=" & i & ""
        '                                        objOpSimplesLn.ejecutar(sql_ver_trans, "PRODUCCION")
        '                                    End If
        '                                End If
        '                            End If
        '                        End If
        '                    Else
        '                        MessageBox.Show("No se puede dar salida a esta cantidad!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '                    End If
        '                End If
        '                'If val_punt.validar_codigos_bodega_8(dtgSolicitud.Item(colDesc.Name, i).Value) Then
        '                '    If CInt(dtgSolicitud.Item(colCant.Name, i).Value) >= CInt(dtgSolicitud.Item(col_cant_entregada.Name, i).Value) Then
        '                '        sql_ver_trans = " select cantidad_trans_ent from J_solicitud_compra_det where numero=" & numero & " and num_det=" & i & ""
        '                '        val_Cantidad_Act = objOpSimplesLn.consultValorTodo(sql_ver_trans, "PRODUCCION")

        '                '        If CInt(dtgSolicitud.Item(colCant.Name, i).Value) > CInt(val_Cantidad_Act) Then
        '                '            If Not IsDBNull(dtgSolicitud.Item(col_cant_entregada.Name, i).Value) Then
        '                '                If IsNumeric(dtgSolicitud.Item(col_cant_entregada.Name, i).Value) Then
        '                '                    If IsNumeric(dtgSolicitud.Item(col_cant_entregada.Name, i).Value) Then
        '                '                        If dtgSolicitud.Item(col_cant_entregada.Name, i).Value > 0 Then
        '                '                            Dim resta_Trans As Double
        '                '                            resta_Trans = CDbl(dtgSolicitud.Item(col_cant_entregada.Name, i).Value) - CDbl(val_Cantidad_Act)
        '                '                            realizarEntradaTrans(dtgSolicitud.Item(colDesc.Name, i).Value, resta_Trans)
        '                '                            sql_ver_trans = "UPDATE J_solicitud_compra_det SET cantidad_trans_ent+=" & resta_Trans & "  where numero=" & numero & " and num_det=" & i & ""
        '                '                            objOpSimplesLn.ejecutar(sql_ver_trans, "PRODUCCION")
        '                '                        End If
        '                '                    End If
        '                '                End If
        '                '            End If
        '                '        End If
        '                '    Else
        '                '        MessageBox.Show("No se puede Entregar esta cantidad!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '                '    End If
        '                'End If
        '            ElseIf cod Like ("2T*") Then
        '                If Not IsDBNull(dtgSolicitud.Item(colCant.Name, i).Value) Then
        '                    If IsNumeric(dtgSolicitud.Item(colCant.Name, i).Value) Then
        '                        Dim sql As String
        '                        Dim resp As String
        '                        sql = " select transTornilleria from J_solicitud_compra_det where numero=" & numero & " and num_det=" & i & ""
        '                        resp = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")
        '                        If resp = "" Then
        '                            If dtgSolicitud.Item(colCant.Name, i).Value > 0 Then
        '                                realizarSalidaTransTorni(dtgSolicitud.Item(colDesc.Name, i).Value, dtgSolicitud.Item(colCant.Name, i).Value)
        '                                sql_ver_trans = "UPDATE J_solicitud_compra_det SET transTornilleria='S'  where numero=" & numero & " and num_det=" & i & ""
        '                                objOpSimplesLn.ejecutar(sql_ver_trans, "PRODUCCION")
        '                            End If
        '                        End If
        '                    End If
        '                End If
        '            End If
        '        End If
        '    End If

        'Next
        If (insertoCorrecto) Then
            MessageBox.Show("La solicitud fue guardada en forma exitosa!,solicitud número " & numero, "Correcto!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            nuevo()
        Else
            MessageBox.Show("Error al guardar la solicitud comuniquese con el administrador del sistema ", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Private Sub realizarSalidaTransTorni(ByVal cod As String, ByVal cant_entregada As Integer)
        Dim listTransaccion_corsan As New List(Of Object)
        Dim tipo As String = ""
        Dim costo_unit As Double
        tipo = "TRB1"
        Dim stock As Double = objOpSimplesLn.consultarStock(cod, 2)
        If cant_entregada <= stock Then
            listTransaccion_corsan.AddRange(traslado_bodega(cod, cant_entregada, tipo, costo_unit, cboQuienSolicita.SelectedValue))
        End If
        If obj_Ing_prodLn.ExecuteSqlTransaction(listTransaccion_corsan, "CORSAN") Then
            MessageBox.Show("Se a hecho la trb1 a bodega 8! ", tipo & ": " & Convert.ToString(numero_transaccion), MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
    Private Sub realizarSalidaTrans(ByVal cod As String, ByVal cant_entregada As Integer)
        Dim resp_transaccion As Boolean = False
        Dim tipo As String = "SPPP"
        Dim notas As String = "SPPP,FEHA:" & Now & " usuario: " & user
        Dim peso As Double = cant_entregada
        Dim codigo As String = cod
        Dim bodega As String = 8
        Dim dFec As Date = Now
        Dim usuario As String = user
        Dim stock As Double = objOpSimplesLn.consultarStock(codigo, bodega)
        Dim listSql As New List(Of Object)
        Dim sql_solicitud As String = ""
        Dim costo_unit As Double

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
            listSql.AddRange(trans_Bod_8(dt, codigo, peso, tipo, costo_unit))
            If obj_Ing_prodLn.ExecuteSqlTransaction(listSql, "CORSAN") Then
                MessageBox.Show("Se a hecho transacción de salida! ", tipo & ": " & Convert.ToString(numero_transaccion), MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("No se a hecho transacción de salida! ", tipo & ": " & Convert.ToString(numero_transaccion), MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Else
            MessageBox.Show("El pedido es mas grande que el stock! ", tipo & ": " & Convert.ToString(numero_transaccion), MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
    Private Sub realizarEntradaTrans(ByVal cod As String, ByVal cant_entregada As Integer)
        Dim resp_transaccion As Boolean = False
        Dim tipo As String = "EMM"
        Dim notas As String = "EMM,FECHA:" & Now & " usuario: " & user
        Dim peso As Double = cant_entregada
        Dim codigo As String = cod
        Dim bodega As String = 8
        Dim dFec As Date = Now
        Dim usuario As String = user
        Dim stock As Double = objOpSimplesLn.consultarStock(codigo, bodega)
        Dim listSql As New List(Of Object)
        Dim sql_solicitud As String = ""
        Dim costo_unit As Double

        Dim dt As New DataTable
        dt.Columns.Add("codigo")
        dt.Columns.Add("cantidad")
        dt.Rows.Add()
        dt.Rows(dt.Rows.Count - 1).Item("codigo") = codigo
        dt.Rows(dt.Rows.Count - 1).Item("cantidad") = peso
        For i = 0 To dt.Rows.Count - 1
            costo_unit = objOrdenProdLn.consultCostoUnit(dt.Rows(i).Item("codigo"))
        Next
        listSql.AddRange(trans_Bod_8(dt, codigo, peso, tipo, costo_unit))
        If obj_Ing_prodLn.ExecuteSqlTransaction(listSql, "CORSAN") Then
            MessageBox.Show("Se a hecho transacción de entrada! ", tipo & ": " & Convert.ToString(numero_transaccion), MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Problema con la transacción de entrada ", tipo & ": " & Convert.ToString(numero_transaccion), MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
    Private Function traslado_bodega(ByVal codigo As String, ByVal cantidad As Double, ByVal tipo As String, ByVal costo_unit As Double, ByVal nit_usuario As String) As List(Of Object)
        Dim listSql As New List(Of Object)
        Dim dFec As Date = Now
        Dim usuario As String = nit_usuario
        Dim notas As String = "SPIC fecha:" & Now & " usuario:" & usuario
        Dim bod_origen As Integer = 2
        Dim bod_destino As Integer = 8
        numero_transaccion = objOrdenProdLn.mover_consecutivo(tipo)
        listSql = objTraslado_bodLn.listaTransaccionDatable_traslado_bodega(numero_transaccion, codigo, bod_origen, bod_destino, dFec, notas, usuario, cantidad, tipo, "29", costo_unit)
        Return listSql
    End Function
    Private Function trans_Bod_8(ByVal datacodigo As DataTable, ByVal codigo As String, ByVal cantidad As Double, ByVal tipo As String, ByVal costo_unit As Double) As List(Of Object)
        Dim listSql As New List(Of Object)
        Dim dFec As Date = Now
        Dim model As String
        Dim usuario As String = user
        Dim notas As String = "SPIC fecha:" & Now & " usuario:" & user
        model = "01"
        numero_transaccion = objOrdenProdLn.mover_consecutivo(tipo)
        listSql = objTraslado_bodLn.listaTransaccionDatable(numero_transaccion, datacodigo, 8, dFec, notas, usuario, tipo, model)
        Return listSql
    End Function
    Private Function crearSolicitud() As Integer
        Dim centro As String = cboCentro.Text
        Dim insertoCorrecto As Boolean = False
        Dim listSql As New List(Of Object)
        Dim numero As Integer = 0
        Dim solicitante As String = cboQuienSolicita.SelectedValue
        Dim fecha_solicitud As String = objOpSimplesLn.cambiarFormatoFecha(cboFechaSol.Value)
        Dim fecha_espera As String = objOpSimplesLn.cambiarFormatoFecha(cboFechaEsp.Value)
        Dim sqlDet As String = ""
        Dim sqlEnc As String = ""
        Dim medida As String = ""
        Dim ped_realizado As String = ""
        Dim contabilizado As String = "N"
        If chk_contabilizado.Checked Then
            contabilizado = "S"
        End If
        If (chk_ped_realizado.Checked) Then
            ped_realizado = 1
        Else
            ped_realizado = "NULL"
        End If
        If (numeroExistente = 0) Then
            numero = objIngresoProdLn.consultar_valor("SELECT MAX (numero)  FROM J_solicitud_compra_enc ", "PRODUCCION") + 1
        Else
            numero = numeroExistente
        End If
        sqlEnc = "INSERT INTO J_solicitud_compra_enc (numero,solicitante,fecha_solicitud,fecha_espera,observaciones,responsable,pedido_realizado,centro,d_orden,contabilizado) " & _
                                "VALUES (" & numero & "," & solicitante & ",'" & fecha_solicitud & "','" & fecha_espera & "','" & txtObservaciones.Text & "','" & cboResponsable.SelectedValue & "'," & ped_realizado & "," & centro & ",'" & idventana & "','" & contabilizado & "')"
        listSql.Add(sqlEnc)
        For i = 0 To dtgSolicitud.RowCount - 1
            If (dtgSolicitud.Item(colDesc.Name, i).Value <> "") Then
                If Not IsDBNull(dtgSolicitud.Item(colMedida.Name, i).Value) Then
                    If Not IsNothing(dtgSolicitud.Item(colMedida.Name, i).Value) Then
                        medida = dtgSolicitud.Item(colMedida.Name, i).Value
                    Else
                        medida = ""
                    End If
                Else
                    medida = ""
                End If

                sqlDet = "INSERT INTO J_solicitud_compra_det (numero,num_det,descripcion_solicitante,cantidad,medida,entregado,nit_proveedor,cantidad_trans,cantidad_trans_ent) VALUES(" & numero & "," & i & ",'" & dtgSolicitud.Item(colDesc.Name, i).Value & "'," & dtgSolicitud.Item(colCant.Name, i).Value & ",'" & medida & "',0," & dtgSolicitud.Item(Id_proveedor.Name, i).Value & ",0,0)"

                listSql.Add(sqlDet)
            End If
        Next
        insertoCorrecto = objIngresoProdLn.ExecuteSqlTransaction(listSql, "PRODUCCION")
        If (insertoCorrecto) Then
            Dim texto As String = "Orden de compra generada por: " & cboQuienSolicita.Text & vbCrLf & _
                                   " número: " & numero & vbCrLf & _
                                   "observaciones: " & txtObservaciones.Text
            Dim titulo As String = "Orden de compra generada por: " & cboQuienSolicita.Text
            Dim destino As String = objOpSimplesLn.returnCorreosModulo(nomb_modulo)
            ' enviarCorreo(numero, texto, titulo, destino)
            MessageBox.Show("La solicitud fue guardada en forma exitosa!,solicitud número " & numero & " ", "Correcto!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            nuevo()
        Else
            MessageBox.Show("Error al guardar la solicitud comuniquese con el administrador del sistema ", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            numero = 0
        End If
        Return numero
    End Function
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
            If (cboFechaEsp.Value >= cboFechaSol.Value) Then
                If (cboQuienSolicita.Text <> "Seleccione" And dtgSolicitud.RowCount >= 0) Then
                    If (cboCentro.Text <> "Seleccione") Then
                        If (cboResponsable.SelectedValue <> 0) Then
                            For i = 0 To dtgSolicitud.RowCount - 1
                                If (dtgSolicitud.Item(colDesc.Name, i).Value <> "") Then
                                    cantProductos += 1
                                    If (dtgSolicitud.Item(colCant.Name, i).Value <> 0) Then
                                        If (dtgSolicitud.Item(colMedida.Name, i).Value <> "") Then
                                            If (permiso.Trim = "ADMIN" Or permiso = "COMPRAS" Or permiso = "ALMACEN") Then
                                                resp = True
                                            Else
                                                resp = True
                                            End If
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
                        MessageBox.Show("El centro de costos es obligatorio", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If

                Else
                    MessageBox.Show("Verifique que el campo quien solicita y los productos este llenos ", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                MessageBox.Show("La fecha de espera no puede ser mayor a la fecha de solicitud ", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            MessageBox.Show("El campo observaciones es obligatorio ", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Return resp
    End Function
    Private Sub guardarCambios()
        Dim centro As String = cboCentro.SelectedValue
        Dim modificoCorrecto As Boolean = False
        Dim listSql As New List(Of Object)
        Dim numero As Integer = 0
        Dim recive As String = ""
        Dim fecha_recive As String = ""
        Dim observaciones As String = txtObservaciones.Text
        Dim autoriza As String = cboautoriza.SelectedValue
        Dim responsable As String = cboResponsable.SelectedValue
        Dim num_det As Integer = 0
        Dim sqlDet As String = ""
        Dim medida As String = ""
        Dim cuenta As String = ""
        Dim entregado As String = "0"
        Dim ped_realizado As String = ""
        Dim precio_unit As Double = 0
        Dim obserAlamacen As String = txtObserAlmacen.Text
        Dim numerfact As String = txtnumerofac.Text
        Dim contabilizado As String = "N"
        Dim trans_salida As String = ""
#Disable Warning BC42024 ' Variable local sin usar: 'sql_ver_trans'.
        Dim sql_ver_trans As String
#Enable Warning BC42024 ' Variable local sin usar: 'sql_ver_trans'.
#Disable Warning BC42024 ' Variable local sin usar: 'val_trans'.
        Dim val_trans As String
#Enable Warning BC42024 ' Variable local sin usar: 'val_trans'.
#Disable Warning BC42024 ' Variable local sin usar: 'val_Cantidad_Ori'.
        Dim val_Cantidad_Ori As String
#Enable Warning BC42024 ' Variable local sin usar: 'val_Cantidad_Ori'.
#Disable Warning BC42024 ' Variable local sin usar: 'val_Cantidad_Act'.
        Dim val_Cantidad_Act As String
#Enable Warning BC42024 ' Variable local sin usar: 'val_Cantidad_Act'.
        If chk_contabilizado.Checked Then
            contabilizado = "S"
        End If
        If (chk_ped_realizado.Checked) Then
            ped_realizado = 1
        Else
            ped_realizado = "NULL"
        End If
        If (cboRecive.Text <> "Seleccione") Then
            recive = cboRecive.SelectedValue
            fecha_recive = objOpSimplesLn.cambiarFormatoFecha(cboFecRecepcion.Value)
        End If
        If (numeroExistente = 0) Then
            numero = objIngresoProdLn.consultar_valor("SELECT MAX (numero)  FROM J_solicitud_compra_enc ", "PRODUCCION") + 1
        Else
            numero = numeroExistente
        End If
        Dim dt_orden_ant As DataTable = objIngresoProdLn.listar_datatable("SELECT num_det,descripcion_solicitante,entregado FROM J_solicitud_compra_det WHERE numero =" & numero, "PRODUCCION")
        Dim sqlEnc As String = "UPDATE J_solicitud_compra_enc SET recive = '" & recive & "',fecha_recive = '" & fecha_recive & "', " &
                                                        "observaciones = '" & observaciones & "',autoriza = " & autoriza & ",responsable = " & responsable & " , pedido_realizado = " & ped_realizado & ", centro = " & centro & ", obserAlmacen = '" & obserAlamacen & "', numero_fact = '" & numerfact & "', contabilizado = '" & contabilizado & "' " &
                                    "WHERE numero =" & numero
        listSql.Add(sqlEnc)
        For i = 0 To dtgSolicitud.RowCount - 1
            If Not IsNothing(dtgSolicitud.Item(colDesc.Name, i).Value) Then
                If (dtgSolicitud.Item(colDesc.Name, i).Value.ToString <> "") Then
                    num_det = dtgSolicitud.Item(ColNumDet.Name, i).Value
                    If Not IsDBNull(dtgSolicitud.Item(colMedida.Name, i).Value) Then
                        If (dtgSolicitud.Item(colMedida.Name, i).Value.ToString <> "") Then
                            medida = dtgSolicitud.Item(colMedida.Name, i).Value
                        Else
                            medida = ""
                        End If
                    Else
                        medida = ""
                    End If
                    If Not IsDBNull(dtgSolicitud.Item(cbocuenta.Name, i).Value) Then
                        If (dtgSolicitud.Item(cbocuenta.Name, i).Value.ToString <> "") Then
                            cuenta = dtgSolicitud.Item(cbocuenta.Name, i).Value
                        Else
                            cuenta = ""
                        End If
                    Else
                        cuenta = ""
                    End If
                    If Not IsDBNull(dtgSolicitud.Item(col_cant_entregada.Name, i).Value) Then
                        If IsNumeric(dtgSolicitud.Item(col_cant_entregada.Name, i).Value) Then
                            entregado = dtgSolicitud.Item(col_cant_entregada.Name, i).Value
                        End If
                    End If
                    If Not IsDBNull(dtgSolicitud.Item(colPrecio.Name, i).Value) Then
                        If IsNumeric(dtgSolicitud.Item(colPrecio.Name, i).Value) Then
                            precio_unit = dtgSolicitud.Item(colPrecio.Name, i).Value
                        End If
                    End If
                    'Dim cod As String = dtgSolicitud.Item(colDesc.Name, i).Value
                    'If Not cod.ToUpper Like ("2T*") Then
                    '    If Not IsDBNull(dtgSolicitud.Item(colDesc.Name, i).Value) Then
                    '        If val_punt.validar_codigos_bodega_8(dtgSolicitud.Item(colDesc.Name, i).Value) Then
                    '            If CInt(dtgSolicitud.Item(colCant.Name, i).Value) >= CInt(dtgSolicitud.Item(colCantAut.Name, i).Value) Then
                    '                sql_ver_trans = " select cantidad_trans from J_solicitud_compra_det where numero=" & numero & " and num_det=" & i & ""
                    '                val_Cantidad_Act = objOpSimplesLn.consultValorTodo(sql_ver_trans, "PRODUCCION")
                    '                If CInt(dtgSolicitud.Item(colCant.Name, i).Value) > CInt(val_Cantidad_Act) Then
                    '                    If Not IsDBNull(dtgSolicitud.Item(colCantAut.Name, i).Value) Then
                    '                        If IsNumeric(dtgSolicitud.Item(colCantAut.Name, i).Value) Then
                    '                            If dtgSolicitud.Item(colCantAut.Name, i).Value > 0 Then
                    '                                Dim resta_Trans As Double
                    '                                resta_Trans = CDbl(dtgSolicitud.Item(colCantAut.Name, i).Value) - CDbl(val_Cantidad_Act)
                    '                                realizarSalidaTrans(dtgSolicitud.Item(colDesc.Name, i).Value, resta_Trans)
                    '                                sql_ver_trans = "UPDATE J_solicitud_compra_det SET cantidad_trans+=" & resta_Trans & "  where numero=" & numero & " and num_det=" & i & ""
                    '                                listSql.Add(sql_ver_trans)
                    '                            End If
                    '                        End If
                    '                    End If
                    '                End If
                    '            Else
                    '                MessageBox.Show("No se puede dar salida a esta cantidad!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    '            End If
                    '        End If
                    '    End If
                    'Else
                    '    If Not IsDBNull(dtgSolicitud.Item(colCant.Name, i).Value) Then
                    '        If IsNumeric(dtgSolicitud.Item(colCant.Name, i).Value) Then
                    '            Dim sql As String
                    '            Dim resp As String
                    '            sql = " select transTornilleria from J_solicitud_compra_det where numero=" & numero & " and num_det=" & i & ""
                    '            resp = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")
                    '            If resp = "" Then
                    '                If dtgSolicitud.Item(colCant.Name, i).Value > 0 Then
                    '                    realizarSalidaTransTorni(dtgSolicitud.Item(colDesc.Name, i).Value, dtgSolicitud.Item(colCant.Name, i).Value)
                    '                    sql_ver_trans = "UPDATE J_solicitud_compra_det SET transTornilleria='S'  where numero=" & numero & " and num_det=" & i & ""
                    '                    objOpSimplesLn.ejecutar(sql_ver_trans, "PRODUCCION")
                    '                End If
                    '            End If
                    '        End If
                    '    End If
                    'End If
                    'If Not IsDBNull(dtgSolicitud.Item(colDesc.Name, i).Value) Then
                    '    If val_punt.validar_codigos_bodega_8(dtgSolicitud.Item(colDesc.Name, i).Value) Then
                    '        If CInt(dtgSolicitud.Item(colCant.Name, i).Value) >= CInt(dtgSolicitud.Item(col_cant_entregada.Name, i).Value) Then
                    '            sql_ver_trans = " select cantidad_trans_ent from J_solicitud_compra_det where numero=" & numero & " and num_det=" & i & ""
                    '            val_Cantidad_Act = objOpSimplesLn.consultValorTodo(sql_ver_trans, "PRODUCCION")

                    '            If CInt(dtgSolicitud.Item(colCant.Name, i).Value) > CInt(val_Cantidad_Act) Then
                    '                If Not IsDBNull(dtgSolicitud.Item(col_cant_entregada.Name, i).Value) Then
                    '                    If IsNumeric(dtgSolicitud.Item(col_cant_entregada.Name, i).Value) Then
                    '                        If IsNumeric(dtgSolicitud.Item(col_cant_entregada.Name, i).Value) Then
                    '                            If dtgSolicitud.Item(col_cant_entregada.Name, i).Value > 0 Then
                    '                                Dim resta_Trans As Double
                    '                                resta_Trans = CDbl(dtgSolicitud.Item(col_cant_entregada.Name, i).Value) - CDbl(val_Cantidad_Act)
                    '                                realizarEntradaTrans(dtgSolicitud.Item(colDesc.Name, i).Value, resta_Trans)
                    '                                sql_ver_trans = "UPDATE J_solicitud_compra_det SET cantidad_trans_ent+=" & resta_Trans & "  where numero=" & numero & " and num_det=" & i & ""
                    '                                listSql.Add(sql_ver_trans)
                    '                            End If
                    '                        End If
                    '                    End If
                    '                End If
                    '            End If
                    '        Else
                    '            MessageBox.Show("No se puede dar entrada a esta cantidad!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    '        End If
                    '    End If
                    'End If
                    If (existeNumDet(num_det, numero)) Then
                        sqlDet = "UPDATE J_solicitud_compra_det SET cantidad = " & dtgSolicitud.Item(colCant.Name, i).Value & ",cantidad_aut = " & dtgSolicitud.Item(colCantAut.Name, i).Value & ",medida = '" & medida & "' ,entregado = " & entregado & " ,precio_unit = " & precio_unit & ",nit_proveedor = " & dtgSolicitud.Item(Id_proveedor.Name, i).Value & ",cuenta = " & cuenta & "" & _
                                        " WHERE numero =" & numero & " AND num_det =" & num_det
                    Else
                        sqlDet = "INSERT INTO J_solicitud_compra_det (numero,num_det,cantidad,cantidad_aut,medida,entregado,precio_unit,nit_proveedor,cuenta) VALUES(" & numero & "," & i & "," & dtgSolicitud.Item(colCant.Name, i).Value & "," & dtgSolicitud.Item(colCantAut.Name, i).Value & ",'" & medida & "'," & entregado & "," & precio_unit & "," & dtgSolicitud.Item(Id_proveedor.Name, i).Value & "," & cuenta & ")"
                    End If
                    For j = 0 To dt_orden_ant.Rows.Count - 1
                        If num_det = dt_orden_ant.Rows(j).Item("num_det") Then
                            If entregado <> 0 Then
                                If IsDBNull(dt_orden_ant.Rows(j).Item("entregado")) Then
                                    entregas_parciales &= "-" & dt_orden_ant.Rows(j).Item("descripcion_solicitante") & " = " & entregado & vbCrLf
                                ElseIf (entregado >= dt_orden_ant.Rows(j).Item("entregado")) Then
                                    entregas_parciales &= "-" & dt_orden_ant.Rows(j).Item("descripcion_solicitante") & " = " & entregado & vbCrLf
                                End If
                            End If
                        End If
                    Next
                    listSql.Add(sqlDet)
                End If
            End If
        Next
        modificoCorrecto = objIngresoProdLn.ExecuteSqlTransaction(listSql, "PRODUCCION")
        If (modificoCorrecto) Then
            Dim texto As String = ""
            Dim titulo As String = ""
            Dim destino As String = objOpSimplesLn.consultarVal("SELECT Mail FROM  Jjv_usuarios WHERE nit = " & cboResponsable.SelectedValue)
            If (solicitudCompleta()) Then
                If idventana = "O" Then
                    texto = "Orden de compra: " & numero & " se encuentra completa "
                    titulo = "Orden de compra: " & numero & " se encuentra completa "
                    For i = 0 To dtgSolicitud.RowCount - 1
                        If Not IsDBNull(dtgSolicitud.Item(colDesc.Name, i).Value) Then
                            If dtgSolicitud.Item(colDesc.Name, i).Value <> "" Then
                                If dtgSolicitud.Item(colCantAut.Name, i).Value = dtgSolicitud.Item(col_cant_entregada.Name, i).Value Then
                                    texto &= "el item:" & dtgSolicitud.Item(colDesc.Name, i).Value & "" & vbCrLf
                                End If
                            End If
                        End If
                    Next
                Else
                    texto = "La solicitud: " & numero & " se encuentra completa "
                    titulo = "La solicitud: " & numero & " se encuentra completa "
                    For i = 0 To dtgSolicitud.RowCount - 1
                        If Not IsDBNull(dtgSolicitud.Item(colDesc.Name, i).Value) Then
                            If dtgSolicitud.Item(colDesc.Name, i).Value <> "" Then
                                If dtgSolicitud.Item(colCantAut.Name, i).Value = dtgSolicitud.Item(col_cant_entregada.Name, i).Value Then
                                    texto &= "el item:" & dtgSolicitud.Item(colDesc.Name, i).Value & "" & vbCrLf
                                End If
                            End If
                        End If
                    Next
                End If
                If (objIngresoProdLn.ejecutar("UPDATE J_solicitud_compra_enc SET terminado = 1 WHERE numero =" & numero, "PRODUCCION") > 0) Then
                    MessageBox.Show("La solicitud fue  terminada en forma correcta ", "Correcto!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("La orden se modifico, pero no se cerro , comuniquese con el administrador del sistema!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                If (entregas_parciales <> "") Then
                    texto = "Items con entrega parcial:" & vbCrLf & entregas_parciales
                    titulo = "Entrega parcial de la orden o solicitud número: " & numero & " "
                    entregas_parciales = ""
                End If
                MessageBox.Show("La solicitud fue modificada en forma exitosa! ", "Correcto!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            If (destino <> "") Then
                enviarCorreo(numero, texto, titulo, destino)
                enviarCorreo(numero, texto, titulo, "lady.restrepo@corsan.com.co")
                enviarCorreo(numero, texto, titulo, "carlos.correa@corsan.com.co")
            End If
        Else
            MessageBox.Show("Error al guardar la modificada comuniquese con el administrador del sistema ", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Private Function existeNumDet(ByVal num_det As Integer, ByVal numero As Integer) As Boolean
        Dim sql As String = "SELECT num_det FROM J_solicitud_compra_det WHERE num_det = " & num_det & " AND numero = " & numero
        If (objIngresoProdLn.consultValor(sql, "PRODUCCION") = "") Then
            Return False
        Else
            Return True
        End If
    End Function
    Public Sub pintarFaltantes()
        Dim colorFalta As Color = Color.NavajoWhite
        Dim colorOk As Color = Color.White
        If (cboQuienSolicita.Text = "Seleccione") Then
            cboQuienSolicita.BackColor = colorFalta
        Else
            cboQuienSolicita.BackColor = colorOk
        End If
        If (cboRecive.Text = "Seleccione") Then
            cboRecive.BackColor = colorFalta
        Else
            cboRecive.BackColor = colorOk
        End If
        If (txtObservaciones.Text.ToString = "") Then
            txtObservaciones.BackColor = colorFalta
        Else
            txtObservaciones.BackColor = colorOk
        End If
        If (cboautoriza.Text = "Seleccione") Then
            cboautoriza.BackColor = colorFalta
        Else
            cboautoriza.BackColor = colorOk
        End If
        If (cboResponsable.Text = "Seleccione") Then
            cboResponsable.BackColor = colorFalta
        Else
            cboResponsable.BackColor = colorOk
        End If
        If (objOpSimplesLn.cambiarFormatoFecha(cboFecRecepcion.Value) = "1900-1-1") Then
            cboFecRecepcion.BackColor = colorFalta
        Else
            cboFecRecepcion.BackColor = colorOk
        End If

    End Sub
    Private Function solicitudCompleta() As Boolean
        Dim resp As Boolean = False
        For i = 0 To dtgSolicitud.RowCount - 1
            If (dtgSolicitud.Item(colDesc.Name, i).Value <> "") Then
                If (dtgSolicitud.Item(colDesc.Name, i).Value.ToString <> "") Then
                    If Not IsDBNull(dtgSolicitud.Item(col_cant_entregada.Name, i).Value) Then
                        If IsNumeric(dtgSolicitud.Item(col_cant_entregada.Name, i).Value) Then
                            If Not IsDBNull(dtgSolicitud.Item(colCant.Name, i).Value) Then
                                If IsNumeric(dtgSolicitud.Item(colCantAut.Name, i).Value) Then
                                    If (dtgSolicitud.Item(col_cant_entregada.Name, i).Value >= dtgSolicitud.Item(colCantAut.Name, i).Value) Then
                                        resp = True
                                    Else
                                        'i = dtgSolicitud.RowCount - 1
                                        resp = False
                                        Exit For
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
        Dim col As String = dtgSolicitud.Columns(e.ColumnIndex).Name
        If (col = colBorrar.Name) Then
            Dim resp As Integer = MessageBox.Show("Seguro que desea eliminar el registro? ", "Eliminar?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If (resp = 6) Then
                If (numeroExistente <> 0) Then
                    If (dtgSolicitud.Item(colDesc.Name, e.RowIndex).Value <> "") Then
                        Dim num_detalle As Integer = dtgSolicitud.Item(ColNumDet.Name, e.RowIndex).Value
                        Dim sql As String = "DELETE FROM J_solicitud_compra_det WHERE numero = " & numeroExistente & " AND num_det =" & num_detalle
                        If (objOpSimplesLn.ejecutar(sql, "PRODUCCION") <= 0) Then
                            MessageBox.Show("Error al eliminar el registrocomuniquese con el administrador del sistema ", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    End If
                End If
                dtgSolicitud.Rows.RemoveAt(e.RowIndex)
            End If
        ElseIf (col = colNuevo.Name) Then
            dtgSolicitud.Rows.Add()
            dtgSolicitud.Item(colCant.Name, dtgSolicitud.RowCount - 1).Value = 0
            dtgSolicitud.Item(col_cant_entregada.Name, dtgSolicitud.RowCount - 1).Value = 0
            dtgSolicitud.Item(colCantAut.Name, dtgSolicitud.RowCount - 1).Value = 0
            dtgSolicitud.Item(colProveedor.Name, dtgSolicitud.RowCount - 1).Value = 0
            dtgSolicitud.Item(Id_proveedor.Name, dtgSolicitud.RowCount - 1).Value = 0
            'dtgSolicitud.Item(ColNumDet.Name, dtgSolicitud.RowCount - 1).Value = dtgSolicitud.Item(colPrecio.Name, dtgSolicitud.RowCount - 2).Value + 1
        ElseIf (col = "colProveedor") Then
            Dim frm As New Frm_terceros_orden
            frm.Show()
            frm.main("quejas", e.RowIndex, "colProveedor", Me)
            frm.Text = "CLIENTES"
        ElseIf (col = "Reporte") Then
            VisualizadorReporte.Show()
        End If
    End Sub

    Private Sub dtgSolicitud_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
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
            ElseIf (col = colCantAut.Name) Then
                If (valor = "") Then
                    MessageBox.Show("La cantidad autorizada no puede ser ingresado vacia", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    carga_comp = False
                    dtgSolicitud.Item(col, e.RowIndex).Value = 0
                    carga_comp = True
                Else
                    If Not IsNumeric(valor) Then
                        MessageBox.Show("El valor ingresado debe ser númerico", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        carga_comp = False
                        dtgSolicitud.Item(col, e.RowIndex).Value = 0
                        carga_comp = True
                    Else
                        caluclar_val_autorizado()
                    End If
                End If
            ElseIf (col = colPrecio.Name) Then
                If (valor = "") Then
                    MessageBox.Show("El precio unitario no puede ser ingresado vacio", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    carga_comp = False
                    dtgSolicitud.Item(col, e.RowIndex).Value = 0
                    carga_comp = True
                Else
                    If Not IsNumeric(valor) Then
                        MessageBox.Show("El valor ingresado debe ser númerico", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        carga_comp = False
                        dtgSolicitud.Item(col, e.RowIndex).Value = 0
                        carga_comp = True
                    Else
                        caluclar_val_autorizado()
                    End If
                End If
            End If
            If (permiso.Trim = "ADMIN" Or permiso = "COMPRAS" Or permiso = "ALMACEN") Then
                pintarFaltantes()
            End If
        End If
    End Sub
    Private Sub cboRecive_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRecive.SelectedIndexChanged
        If (carga_comp) Then
            If (permiso.Trim = "ADMIN" Or permiso = "COMPRAS" Or permiso = "ALMACEN") Then
                pintarFaltantes()
                cboFecRecepcion.Value = Now
            End If
        End If
    End Sub

    Private Sub cboautoriza_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboautoriza.SelectedIndexChanged
        If (carga_comp) Then
            If (permiso.Trim = "ADMIN" Or permiso = "COMPRAS" Or permiso = "ALMACEN") Then
                pintarFaltantes()
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

    Private Sub chk_ped_realizado_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chk_ped_realizado.CheckedChanged
        If (chk_ped_realizado.Checked) Then
            chk_ped_realizado.BackColor = Color.GreenYellow
        Else
            chk_ped_realizado.BackColor = Nothing
        End If
    End Sub
    Public Sub caluclar_val_autorizado()
        txtValTot.Text = 0
        For i = 0 To dtgSolicitud.RowCount - 1
            If IsNumeric(dtgSolicitud.Item(colPrecio.Name, i).Value) Then
                If (dtgSolicitud.Item(colPrecio.Name, i).Value <> 0) Then
                    If IsNumeric(dtgSolicitud.Item(colCantAut.Name, i).Value) Then
                        If (dtgSolicitud.Item(colCantAut.Name, i).Value <> 0) Then
                            If IsNumeric(txtValTot.Text) Then
                                txtValTot.Text += (dtgSolicitud.Item(colCantAut.Name, i).Value * dtgSolicitud.Item(colPrecio.Name, i).Value)
                            Else
                                txtValTot.Text = (dtgSolicitud.Item(colCantAut.Name, i).Value * dtgSolicitud.Item(colPrecio.Name, i).Value)
                            End If
                        End If
                    End If
                End If
            End If
        Next
        txtValTot.Text = Format(Convert.ToDouble(txtValTot.Text), "###,###,###")
    End Sub
    Private Sub dtgSolicitud_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim Hitest As DataGridView.HitTestInfo = dtgSolicitud.HitTest(e.X, e.Y)
            If Hitest.Type = DataGridViewHitTestType.Cell Then
                dtgSolicitud.CurrentCell = dtgSolicitud.Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
            End If
        End If
    End Sub
    Private Sub btnfinalizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnfinalizar.Click
        Dim result As MsgBoxResult
        Dim sql As String
        Dim frm As New Frm_consult_ordenes_compra

        If numeroExistente <> 0 Then
            result = MessageBox.Show("Desea finalizar la orden o solicitud?", "finalizar pedido", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
            If result = vbYes Then
                sql = "update J_solicitud_compra_enc set terminado=1 where numero=" & numeroExistente & ""
                If objOpSimplesLn.consultValorTodo(sql, "PRODUCCION") = True Then
                    Dim numero As String = num_principal
                    Dim texto As String
                    Dim titulo As String
                    If idventana = "O" Then
                        texto = "Orden de compra: " & numero & " se encuentra completa " & vbCrLf
                        titulo = "Orden de compra: " & numero & " se encuentra completa "
                        For i = 0 To dtgSolicitud.RowCount - 1
                            If Not IsDBNull(dtgSolicitud.Item(colDesc.Name, i).Value) Then
                                If dtgSolicitud.Item(colDesc.Name, i).Value <> "" Then
                                    If dtgSolicitud.Item(colCantAut.Name, i).Value = dtgSolicitud.Item(col_cant_entregada.Name, i).Value Then
                                        texto &= "el item:" & dtgSolicitud.Item(colDesc.Name, i).Value & "" & vbCrLf
                                    End If
                                End If
                            End If
                        Next
                    Else
                        texto = "La solicitud: " & numero & " se encuentra completa "
                        titulo = "La solicitud: " & numero & " se encuentra completa "
                        For i = 0 To dtgSolicitud.RowCount - 1
                            If Not IsDBNull(dtgSolicitud.Item(colDesc.Name, i).Value) Then
                                If dtgSolicitud.Item(colDesc.Name, i).Value <> "" Then
                                    If dtgSolicitud.Item(colCantAut.Name, i).Value = dtgSolicitud.Item(col_cant_entregada.Name, i).Value Then
                                        texto &= "el item:" & dtgSolicitud.Item(colDesc.Name, i).Value & "" & vbCrLf
                                    End If
                                End If
                            End If
                        Next
                    End If
                    Dim destino As String = objOpSimplesLn.consultarVal("SELECT Mail FROM  Jjv_usuarios WHERE nit = " & cboResponsable.SelectedValue)
                    enviarCorreo(numero, texto, titulo, destino)
                    enviarCorreo(numero, texto, titulo, "lady.restrepo@corsan.com.co")
                    enviarCorreo(numero, texto, titulo, "carlos.correa@corsan.com.co")
                End If
                Me.Close()
            End If
        Else
            MessageBox.Show("No se puede finalizar un orden o solicitud que no existe", "finalizar pedido", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
    Private Sub dtgSolicitud_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dtgSolicitud.CellFormatting
        Dim fila As Integer = e.RowIndex
        Dim col As String = dtgSolicitud.Columns(e.ColumnIndex).Name
        If (fila >= 0) Then
            If (col = "colDesc") Then
                dtgSolicitud.Rows(e.RowIndex).Cells(e.ColumnIndex).ToolTipText = "Si se ingresa un codigo de puntilleria se realizara una transacción" &
                    " de salida una vez se llene el campo cantidad autorizada,cuando se llene el campo cantidad entregada se realizara una transacción de entrada."
            End If
        End If
    End Sub
    Private Sub cargar_codigos()
        Dim dt As DataTable
        Dim sql As String
        sql = "SELECT codigo,descripcion FROM referencias_Puntilleria"
        dt = obj_Ing_prodLn.listar_datatable(sql, "CORSAN")
        bs_cod = New BindingSource()
        bs_cod.DataSource = dt
        dtg_codigo.DataSource = bs_cod
        dtg_codigo.AutoResizeColumns()
    End Sub
    Private Sub cargar_inventario()
        Dim dt As DataTable
        Dim sql As String
        sql = "SELECT g.Descripcion as linea_Produccion, s.bodega,s.codigo,r.descripcion,s.can_ini,s.can_ent ,s.can_sal,((s.can_ini+s.can_ent)-(s.can_sal))As stock, s.mes,s.ano  " &
               " FROM referencias_sto s , referencias r ,JJV_Grupos_seguimiento g " &
               " WHERE r.codigo = s.codigo AND ano=year(getdate()) and mes = month(getdate())  AND g.Id_cor = r.Id_cor  AND s.codigo like'2%' AND s.bodega = 8 ORDER BY g.Descripcion "
        dt = obj_Ing_prodLn.listar_datatable(sql, "CORSAN")
        bs_cod = New BindingSource()
        bs_cod.DataSource = dt
        dtg_codigo.DataSource = bs_cod
        dtg_codigo.AutoResizeColumns()
    End Sub
    Private Sub Pb_cerrar_Click(sender As Object, e As EventArgs) Handles Pb_cerrar.Click
        p_cerrar.Visible = False
    End Sub
    Private Sub Btn_codigos_Click(sender As Object, e As EventArgs) Handles btn_codigos.Click
        p_cerrar.Visible = True
        cargar_codigos()
    End Sub
    Private Sub txt_buscar_TextChanged(sender As Object, e As EventArgs) Handles txt_buscar.TextChanged
        bs_cod.Filter = String.Format("descripcion LIKE '{0}%'", txt_buscar.Text)
    End Sub

    Private Sub tsb_Bodega8_Click(sender As Object, e As EventArgs) Handles tsb_Bodega8.Click
        p_cerrar.Visible = True
        cargar_inventario()
    End Sub
    Private Sub btn_Transaccion_Salida_Click(sender As Object, e As EventArgs) Handles btn_Transaccion_Salida.Click
        Dim sql_ver_trans As String
        Dim valor_Val As String
        Dim val As Boolean = False

        For i = 0 To dtgSolicitud.RowCount - 1
            sql_ver_trans = " select transSalidad from J_solicitud_compra_det where numero=" & num_principal & " and num_det=" & i & ""
            valor_Val = objOpSimplesLn.consultValorTodo(sql_ver_trans, "PRODUCCION")
            If valor_Val = "" Then
                If Not IsDBNull(dtgSolicitud.Item(colDesc.Name, i).Value) Then
                    Dim cod As String = dtgSolicitud.Item(colDesc.Name, i).Value
                    If Not IsNothing(cod) Then
                        If Not cod.ToUpper Like ("2T*") Then
                            If val_punt.validar_codigos_bodega_8(dtgSolicitud.Item(colDesc.Name, i).Value) Then
                                If CInt(dtgSolicitud.Item(colCant.Name, i).Value) >= CInt(dtgSolicitud.Item(colCantAut.Name, i).Value) Then
                                    'sql_ver_trans = " select cantidad_trans from J_solicitud_compra_det where numero=" & num_principal & " and num_det=" & i & ""
                                    'val_Cantidad_Act = objOpSimplesLn.consultValorTodo(sql_ver_trans, "PRODUCCION")
                                    'If CInt(dtgSolicitud.Item(colCant.Name, i).Value) > CInt(val_Cantidad_Act) Then
                                    If Not IsDBNull(dtgSolicitud.Item(colCantAut.Name, i).Value) Then
                                        If IsNumeric(dtgSolicitud.Item(colCantAut.Name, i).Value) Then
                                            If dtgSolicitud.Item(colCantAut.Name, i).Value > 0 Then

                                                realizarSalidaTrans(dtgSolicitud.Item(colDesc.Name, i).Value, CDbl(dtgSolicitud.Item(colCantAut.Name, i).Value))
                                                sql_ver_trans = "UPDATE J_solicitud_compra_det SET transSalidad='S'  where numero=" & num_principal & " and num_det=" & i & ""
                                                objOpSimplesLn.ejecutar(sql_ver_trans, "PRODUCCION")
                                                val = True
                                            End If
                                        End If
                                    End If
                                    'End If
                                Else
                                    MessageBox.Show("No se puede dar salida a esta cantidad!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                End If
                            End If
                        ElseIf cod Like ("2T*") Then
                            If Not IsDBNull(dtgSolicitud.Item(colCant.Name, i).Value) Then
                                If IsNumeric(dtgSolicitud.Item(colCant.Name, i).Value) Then
                                    Dim sql As String
                                    Dim resp As String
                                    sql = " select transTornilleria from J_solicitud_compra_det where numero=" & num_principal & " and num_det=" & i & ""
                                    resp = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")
                                    If resp = "" Then
                                        If dtgSolicitud.Item(colCant.Name, i).Value > 0 Then
                                            realizarSalidaTransTorni(dtgSolicitud.Item(colDesc.Name, i).Value, dtgSolicitud.Item(colCant.Name, i).Value)
                                            sql_ver_trans = "UPDATE J_solicitud_compra_det SET transTornilleria='S'  where numero=" & num_principal & " and num_det=" & i & ""
                                            objOpSimplesLn.ejecutar(sql_ver_trans, "PRODUCCION")
                                            val = True
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            Else
                MessageBox.Show("Ya ha sido finalizada esta solicitud", "Solicitud ya finalizada", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Next
        If val = True Then
            MessageBox.Show("Salida Finalizada de forma correcta", "Salida finalizada", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub chk_no_recurrente_CheckedChanged(sender As Object, e As EventArgs) Handles chk_no_recurrente.CheckedChanged
        If chk_no_recurrente.Checked = True Then
            chk_proceso.Checked = False
        End If
    End Sub
    Private Sub chk_proceso_CheckedChanged(sender As Object, e As EventArgs) Handles chk_proceso.CheckedChanged
        If chk_proceso.Checked = True Then
            chk_no_recurrente.Checked = False
        End If
    End Sub

End Class