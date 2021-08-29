Imports logicaNegocios
Imports entidadNegocios
Public Class Frm_consult_salida_almacen
    Private objOpSimplesLn As New Op_simpesLn
    Dim objIngresoProdLn As New Ing_prodLn
    Dim carga_comp As Boolean = False
    Dim usuario As UsuarioEn
    Private objOperacionesForm As OperacionesFormularios = New OperacionesFormularios
    Public Sub Main(ByVal usuario As UsuarioEn)
        Me.usuario = usuario
        If (usuario.permiso.Trim <> "ADMIN" And usuario.permiso.Trim <> "COMPRAS" And usuario.permiso.Trim <> "DIR_LOGISTICA" And usuario.permiso.Trim <> "DIR_PRODUCCION" And usuario.permiso.Trim <> "COOR_PROD") Then
            dtgConsulta.Columns(colBorrar.Name).Visible = False
            If Not IsDBNull(usuario.nit) Then
                If (usuario.permiso.Trim <> "ALMACEN") Then
                    cboSolicita.SelectedValue = usuario.nit
                    cboSolicita.Enabled = False
                End If
            End If
        End If

    End Sub
    Private Sub Frm_consult_salida_almacen_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cboFechaIni.Value = Now.AddMonths(-2)
        cboFechaFin.Value = Now
        cargar_cbo()
        carga_comp = True
    End Sub
    Private Sub dtgConsulta_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgConsulta.CellContentClick
        If (e.RowIndex >= 0) Then
            Dim col As String = dtgConsulta.Columns(e.ColumnIndex).Name
            Dim numero As Integer = dtgConsulta.Item("numero", e.RowIndex).Value
            If (col = colEditar.Name) Then
                Dim dt_codigo As New DataTable
                Dim sqlStock As String = ""
                Dim sqlCodigo As String = ""
                Dim medida As String = ""
                Dim sql_referencias As String = ""
                Dim frm As New Frm_salida_almacen
                Dim cant_num_det As Integer = objIngresoProdLn.consultar_valor("SELECT COUNT (id_detalle) FROM J_salida_almacen_det WHERE numero = " & numero, "PRODUCCION")
                Dim sql_detalle As String = "SELECT D.numero,D.id_detalle,D.codigo,r.descripcion,D.cantidad,D.cant_entregada,d.centro " & _
                                                "FROM J_salida_almacen_det D , CORSAN.dbo.referencias r " & _
                                                        "WHERE r.codigo = D.codigo AND  D.numero = " & numero
                Dim dt_detalle As DataTable = objOpSimplesLn.listar_datatable(sql_detalle, "PRODUCCION")
                Dim sql_encabezado As String = "SELECT e.numero,e.fecha,e.aprueba,e.entrega,e.solicita,e.observaciones " & _
                                                    "FROM J_salida_almacen_enc e " & _
                                                        "WHERE numero = " & numero
                Dim dt_encabezado As DataTable = objOpSimplesLn.listar_datatable(sql_encabezado, "PRODUCCION")
                Dim sqlStock_b1 As String = ""
                Dim sqlStock_b5 As String = ""
                Dim stock_b1 As String = ""
                Dim stock_b5 As String = ""
                frm.Show()
                frm.Main(usuario, numero, "nod_salida_almacen")
                frm.carga_comp = False
                frm.numeroExistente = numero
                For i = 0 To dt_encabezado.Rows.Count - 1
                    frm.cboQuienSolicita.SelectedValue = dt_encabezado.Rows(i).Item("solicita")
                    frm.cboFechaSol.Value = objOpSimplesLn.cambiarFormatoFecha(dt_encabezado.Rows(i).Item("fecha"))
                    frm.txtObservaciones.Text = dt_encabezado.Rows(i).Item("observaciones")
                    If Not (IsDBNull(dt_encabezado.Rows(i).Item("aprueba"))) Then
                        frm.cboAprueba.SelectedValue = dt_encabezado.Rows(i).Item("aprueba")
                    End If
                    If Not (IsDBNull(dt_encabezado.Rows(i).Item("entrega"))) Then
                        frm.cboEntrega.SelectedValue = dt_encabezado.Rows(i).Item("entrega")
                    End If
                    If (cant_num_det > (frm.dtgSolicitud.RowCount - 1)) Then
                        Dim diferencia As Integer = cant_num_det - (frm.dtgSolicitud.RowCount - 1)
                        For j = 0 To diferencia
                            frm.dtgSolicitud.Rows.Add()
                        Next
                    End If
                Next


                For i = 0 To dt_detalle.Rows.Count - 1
                    sqlStock_b1 = "SELECT stock " & _
                                      "FROM v_referencias_sto_hoy " & _
                                           "WHERE bodega = 1 AND codigo = '" & dt_detalle.Rows(i).Item("codigo") & "'"
                    sqlStock_b5 = "SELECT stock " & _
                                     "FROM v_referencias_sto_hoy " & _
                                          "WHERE bodega = 5 AND codigo = '" & dt_detalle.Rows(i).Item("codigo") & "'"
                    stock_b1 = objOpSimplesLn.consultarVal(sqlStock_b1)
                    stock_b5 = objOpSimplesLn.consultarVal(sqlStock_b5)
                    frm.dtgSolicitud.Item(frm.ColNumDet.Name, i).Value = dt_detalle.Rows(i).Item("id_detalle")
                    frm.dtgSolicitud.Item(frm.colCodigo.Name, i).Value = dt_detalle.Rows(i).Item("codigo")
                    frm.dtgSolicitud.Item(frm.colCant.Name, i).Value = dt_detalle.Rows(i).Item("cantidad")
                    frm.dtgSolicitud.Item(frm.colDesc.Name, i).Value = dt_detalle.Rows(i).Item("descripcion")
                    frm.dtgSolicitud.Item(frm.cboCentro.Name, i).Value = dt_detalle.Rows(i).Item("centro")
                    frm.dtgSolicitud.Item(frm.colStock_b1.Name, i).Value = stock_b1
                    frm.dtgSolicitud.Item(frm.colStock_b5.Name, i).Value = stock_b5
                    sqlCodigo = "SELECT generico,costo_unitario   " & _
                               "FROM referencias " & _
                                    "WHERE codigo = '" & dt_detalle.Rows(i).Item("codigo") & "'"
                    dt_codigo = objOpSimplesLn.listar_datatable(sqlCodigo, "CORSAN")
                    For k = 0 To dt_codigo.Rows.Count - 1
                        frm.dtgSolicitud.Item(frm.colMedida.Name, i).Value = dt_codigo.Rows(k).Item("generico")
                        frm.dtgSolicitud.Item(frm.colCosto.Name, i).Value = dt_codigo.Rows(k).Item("costo_unitario")
                    Next

                    If Not (IsDBNull(dt_detalle.Rows(i).Item("cant_entregada"))) Then
                        frm.dtgSolicitud.Item(frm.col_cant_entregada.Name, i).Value = dt_detalle.Rows(i).Item("cant_entregada")
                    Else
                        frm.dtgSolicitud.Item(frm.col_cant_entregada.Name, i).Value = 0
                    End If
                Next
                frm.eliminarNoUsadas()
                frm.carga_comp = True
            ElseIf (col = colBorrar.Name) Then
                Dim motivo As String = InputBox("Ingrese el motivo de la anulación del consecutivo, luego presione aceptar", "Motivo")
                If (motivo <> "") Then
                    Dim listSql As New List(Of Object)
                    Dim sql As String
                    motivo &= " " & usuario.usuario & " " & Now
                    sql = "UPDATE J_salida_almacen_enc SET anulado = 1,observaciones += '" & motivo & "' WHERE numero =" & numero
                    listSql.Add(sql)
                    If (objIngresoProdLn.ExecuteSqlTransaction(listSql, "PRODUCCION")) Then
                        cargarConsulta()
                        MessageBox.Show("El registro se elimino en forma correcta! ", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("Error al elimino el registro, verifique que la celda no este en blanco! ", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub cargar_cbo()
        Dim sql As String
        Dim dt As New DataTable
        Dim dr As DataRow
        dt = New DataTable
        sql = "SELECT nit,nombres FROM V_nom_personal_Activo_con_maquila where centro not in (4200) order by nombres"
        dt = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        dr = dt.NewRow
        dr("nit") = 0
        dr("nombres") = "TODO"
        dt.Rows.Add(dr)
        cboSolicita.DataSource = dt
        cboSolicita.ValueMember = "nit"
        cboSolicita.DisplayMember = "nombres"
        cboSolicita.Text = "TODO"

    End Sub
    Private Sub cargarConsulta()
        Dim fecIni As String = objOpSimplesLn.cambiarFormatoFecha(cboFechaIni.Value)
        Dim fecFin As String = objOpSimplesLn.cambiarFormatoFecha(cboFechaFin.Value)
        Dim dt As New DataTable
        Dim sql As String = ""
        Dim selectSql As String = ""
        Dim groupSql As String = ""
        Dim whereSql As String = "WHERE  E.anulado is null AND E.fecha >= '" & fecIni & "' AND E.fecha <= '" & fecFin & " 23:59:59' AND E.solicita = P.nit "
        Dim orderSql As String = " ORDER BY "
        If (chkConsolProd.Checked) Then
            colBorrar.Visible = False
            colEditar.Visible = False
            selectSql = "SELECT P.nombres As nom_solicita,D.codigo,R.descripcion,SUM(D.cant_entregada) As cant_entregada" & _
                           "FROM J_salida_almacen_enc E , CORSAN.dbo.V_nom_personal_Activo_con_maquila P ,J_salida_almacen_det D, CORSAN.dbo.referencias R "
            whereSql &= " AND R.codigo = D.codigo AND D.numero = E.numero "
            groupSql &= " GROUP BY P.nombres,D.codigo,R.descripcion"
            orderSql &= "P.nombres "
        Else
            colBorrar.Visible = True
            colEditar.Visible = True
            selectSql = "SELECT E.numero,E.fecha,P.nombres As nom_solicita,E.observaciones As contenido,E.observaciones As observaciones_orden,E.terminado,E.tipo_trans As tipo,E.trans   " & _
                           "FROM J_salida_almacen_enc E , CORSAN.dbo.V_nom_personal_Activo_con_maquila P "
            orderSql &= "E.fecha Desc  "
        End If
   


        If (chkTerminados.Checked = False) Then
            whereSql &= "AND E.terminado is null "
        End If
        If (cboSolicita.Text <> "TODO") Then
            whereSql &= "AND E.solicita = " & cboSolicita.SelectedValue & " "
        End If
        If (txtNumero.Text <> "") Then
            whereSql &= "AND E.numero = " & txtNumero.Text & " "
        End If
   

        sql = selectSql & whereSql & groupSql & orderSql
        dt = objIngresoProdLn.listar_datatable(sql, "PRODUCCION")
        If (chkConsolProd.Checked = False) Then
            dt = addContenido(dt)
        End If



        dtgConsulta.DataSource = dt

        If (chkConsolProd.Checked = False) Then
            dtgConsulta.Columns("fecha").DefaultCellStyle.Format = "g"
            dtgConsulta.Columns("numero").HeaderText = "#"
            dtgConsulta.Columns("contenido").DefaultCellStyle.WrapMode = DataGridViewTriState.True
            pintarTerminadas()
        End If
      
        dtgConsulta.Columns("nom_solicita").DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))


    End Sub
    Private Function addContenido(ByRef dt As DataTable) As DataTable
        Dim sql As String = ""
        Dim valor As String = ""
        For i = 0 To dt.Rows.Count - 1
            sql = "DECLARE @valores VARCHAR(MAX) " & _
                    "SELECT @valores = COALESCE( @valores + ' " & vbCrLf & "', '')  + ' - ' + r.descripcion + ' -> ' + CAST(d.cantidad AS varchar(25))  FROM J_salida_almacen_det d,CORSAN.dbo.referencias r WHERE d.codigo = r.codigo AND d.numero = " & dt.Rows(i).Item("numero") & " " & _
                    "SELECT @valores as valores"
            valor = objIngresoProdLn.consultar_valor(sql, "PRODUCCION")
            dt.Rows(i).Item("contenido") = valor
        Next
        Return dt
    End Function
    Private Sub pintarTerminadas()
        For i = 0 To dtgConsulta.RowCount - 1
            If Not IsDBNull(dtgConsulta.Item("terminado", i).Value) Then
                If (dtgConsulta.Item("terminado", i).Value.ToString <> "") Then
                    If (dtgConsulta.Item("terminado", i).Value = 1) Then
                        dtgConsulta.Rows(i).DefaultCellStyle.BackColor = Color.GreenYellow
                    End If
                End If
            End If
        Next
    End Sub
    Private Sub btnActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActualizar.Click
        img_procesar.Visible = True
        Application.DoEvents()
        cargarConsulta()
        img_procesar.Visible = False
    End Sub

    Private Sub txtNumero_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNumero.TextChanged
        If (carga_comp) Then
            carga_comp = False
            If (usuario.permiso.Trim = "ADMIN" Or usuario.permiso.Trim = "COMPRAS") Then
                cboSolicita.Text = "TODO"
            End If

            cargarConsulta()
            carga_comp = True
        End If
    End Sub

    Private Sub cboFechaIni_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFechaIni.ValueChanged
        If (carga_comp) Then
            cargarConsulta()
        End If
    End Sub

    Private Sub cboFechaFin_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFechaFin.ValueChanged
        If (carga_comp) Then
            cargarConsulta()
        End If
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        Dim frm As New Frm_salida_almacen
        frm.Show()
        frm.Main(usuario, 0, "nod_salida_almacen")
    End Sub

    Private Sub ToolStripButton3_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton3.Click
        Me.UseWaitCursor = True
        Application.DoEvents()
        objOperacionesForm.exportarExcel(dtgConsulta)
        Me.UseWaitCursor = False
    End Sub
    Private Sub txtTope_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
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


End Class