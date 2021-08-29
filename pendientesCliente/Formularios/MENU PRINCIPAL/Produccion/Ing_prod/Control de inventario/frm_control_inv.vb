Imports logicaNegocios
Imports entidadNegocios
Public Class frm_control_inv
    Private objOpSimplesLn As New Op_simpesLn
    Private obj_Ing_prodLn As New Ing_prodLn
    Dim objTraslado_bodLn As New traslado_bodLn
    Dim obj_gestion_alambronLn As New Gestion_alambronLn
    'VARIABLES GLOBALES PARA CONTROL DE INVENTARIOS INICIADOS
    Dim id_inv As Integer = 0
    Dim operario As String = ""
    Public Sub main(ByVal nit As String)
        Me.operario = nit
        inv_pendiente()
    End Sub
    Private Sub inv_pendiente()
        Using New Centered_MessageBox(Me)
            Dim sql As String = "SELECT id,bodega,fec_fin FROM JB_control_inventario WHERE operario = " & operario
            Dim dt As DataTable = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")
            If dt.Rows.Count > 0 Then
                For i = 0 To dt.Rows.Count - 1
                    If IsDBNull(dt.Rows(i).Item("fec_fin")) Then
                        id_inv = dt.Rows(i).Item("id")
                        cbo_bodega.SelectedValue = dt.Rows(i).Item("bodega")
                        cargar_rollos(cbo_bodega.SelectedValue)
                        pan_iniciar.Enabled = False
                        pan_rollos.Enabled = True
                        tbl_inventario.SelectedTab = pag_rollos
                        txt_lector.Focus()
                    End If
                Next
            End If
        End Using
    End Sub
    Private Sub frm_control_inv_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim sql As String = "SELECT CAST(bodega As varchar(25)) As bodega, CAST(bodega As varchar(25)) + '-' + descripcion As descripcion  " & _
                                " FROM bodegas " & _
                                    " WHERE bodega IN (1,2,11,12,13,14)"
        Dim dt As DataTable = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        dt.Rows.Add()
        dt.Rows(dt.Rows.Count - 1).Item("bodega") = 7
        dt.Rows(dt.Rows.Count - 1).Item("descripcion") = "(2)-BODEGA (BRILLANTE,ESPECIAL,RECOCIDO)"

        dt.Rows.Add()
        dt.Rows(dt.Rows.Count - 1).Item("bodega") = 0
        dt.Rows(dt.Rows.Count - 1).Item("descripcion") = "Seleccione"
       
        cbo_bodega.DataSource = dt
        cbo_bodega.ValueMember = "bodega"
        cbo_bodega.DisplayMember = "descripcion"
        cbo_bodega.SelectedValue = 0
    End Sub

    Private Sub cbo_bodega_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbo_bodega.SelectionChangeCommitted
        If cbo_bodega.SelectedValue = 0 Then
            btn_iniciar.Enabled = False
        Else
            btn_iniciar.Enabled = True
        End If
    End Sub
    Private Sub crear_inv()
        Using New Centered_MessageBox(Me)
            Dim iResponce As Integer = MessageBox.Show("¿Desea iniciar un nuevo inventario?", "Atención", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
            If iResponce = 6 Then
                Dim sql As String = "SELECT (CASE WHEN max(id) IS NULL THEN 1 ELSE max(id)+1 END)  FROM JB_control_inventario"
                id_inv = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")
                sql = "INSERT INTO JB_control_inventario (id,bodega,operario,fec_ini) VALUES(" & id_inv & "," & cbo_bodega.SelectedValue & "," & operario & ",GETDATE())"
                If objOpSimplesLn.ejecutar(sql, "PRODUCCION") Then
                    If cbo_bodega.SelectedValue = 11 Then
                        congelar_inv(11, "SAGA", "G")
                    ElseIf cbo_bodega.SelectedValue = 12 Then
                        congelar_inv(12, "SCLA", "P")
                    ElseIf cbo_bodega.SelectedValue = 13 Then
                        congelar_inv(13, "SREC", "R")
                    ElseIf cbo_bodega.SelectedValue = 14 Then
                        congelar_inv(14, "SPU", "A")
                    ElseIf cbo_bodega.SelectedValue = 1 Then
                        congelar_inv(1, "smpp_b2", "A1")
                    ElseIf cbo_bodega.SelectedValue = 2 Then
                        congelar_inv(2, "smpp_b2", "A2")
                    ElseIf cbo_bodega.SelectedValue = 7 Then
                        congelar_inv(7, "", "INVB2")
                    End If
                End If
            End If
        End Using
    End Sub
    Private Sub congelar_inv(ByVal bodega As Integer, ByVal trans As String, ByVal dest As String)
        Dim sql As String = ""
        Dim identb2 As String = ""
        Dim dt As New DataTable
        Dim listSql As New List(Of Object)
        If bodega = 1 Or bodega = 2 Then
            If dest = "A2" Then
                sql = "select nit_proveedor,num_importacion,id_solicitud_det,numero_rollo from J_alambron_importacion_det_rollos WHERE " & trans & " IS NULL AND num_transaccion_salida is not null"
                dt = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")

            Else
                sql = "select nit_proveedor,num_importacion,id_solicitud_det,numero_rollo from J_alambron_importacion_det_rollos WHERE peso is not null AND num_transaccion is not null AND num_transaccion_salida is null"
                dt = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")
            End If
            For i = 0 To dt.Rows.Count - 1
                sql = "INSERT INTO JB_control_inventario_alambron (id_inv,nit_proveedor,num_importacion,id_solicitud_det,numero_rollo,estado,tipo) VALUES (" & _
                        id_inv & "," & dt.Rows(i).Item("nit_proveedor") & "," & dt.Rows(i).Item("num_importacion") & "," & dt.Rows(i).Item("id_solicitud_det") & "," & dt.Rows(i).Item("numero_rollo") & ",0,'A')"
                listSql.Add(sql)
            Next
        End If
        If bodega = 7 Then
            Dim resp As Integer
            Using New Centered_MessageBox(Me)
                resp = InputBox("Desea hacer inventario en la bodega de trefilacion sobre 1-Brillante,2-Especial,3-Recocido?", "Ingrese", , 50, 100)
            End Using
            Select Case resp
                Case 1
                    sql = "select j.cod_orden,j.id_detalle,j.id_rollo" & _
                         " from j_rollos_tref j inner join J_orden_prod_tef o on o.consecutivo=j.cod_orden inner join J_det_orden_prod d on d.cod_orden=j.cod_orden and d.id_detalle=j.id_detalle" & _
                         " where j.anulado is null and j.traslado is null  and j.destino is null and saga is null and srec is null and scla is null and o.prod_final like '22b%' " & _
                          " order by  j.cod_orden,j.id_detalle,j.id_rollo"
                    identb2 = "T"
                    dt = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")
                Case 2
                    sql = "select j.cod_orden,j.id_detalle,j.id_rollo" & _
                         " from j_rollos_tref j inner join J_orden_prod_tef o on o.consecutivo=j.cod_orden inner join J_det_orden_prod d on d.cod_orden=j.cod_orden and d.id_detalle=j.id_detalle" & _
                         " where j.anulado is null and j.traslado is null and j.destino is null and saga is null and srec is null and scla is null and o.prod_final like '22x%' " & _
                          " order by  j.cod_orden,j.id_detalle,j.id_rollo"
                    identb2 = "E"
                    dt = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")
                Case 3
                    sql = " select r.cod_orden_rec,r.id_detalle_rec,r.id_rollo_rec " & _
                          " from JB_orden_prod_rec o inner join  JB_orden_prod_rec_detalle d on o.cod_orden=d.cod_orden inner join JB_rollos_rec r on d.cod_orden=r.cod_orden_rec and d.id_detalle=r.id_detalle_rec" & _
                          " where r.trans is not null and r.tipo_trans = 'EPPP' AND r.SCAE IS NULL and d.op_descargue is not null and estado=4"
                    identb2 = "R"
                    dt = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")
            End Select
            For i = 0 To dt.Rows.Count - 1
                sql = "INSERT INTO JB_control_inventario_rollos (id_inv,cod_orden,id_detalle,id_rollo,estado,tipo) VALUES (" & _
                        id_inv & "," & dt.Rows(i).Item("cod_orden") & "," & dt.Rows(i).Item("id_detalle") & "," & dt.Rows(i).Item("id_rollo") & ",0,'" & identb2 & "')"
                listSql.Add(sql)
            Next
        End If
        dt = New DataTable
        If bodega <> 2 And bodega <> 1 And bodega <> 14 And bodega <> 7 Then
            sql = "SELECT cod_orden,id_detalle,id_rollo FROM J_rollos_tref WHERE " & trans & " IS NULL AND destino ='" & dest & "' AND anulado IS NULL"
            dt = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")

            For i = 0 To dt.Rows.Count - 1
                sql = "INSERT INTO JB_control_inventario_rollos (id_inv,cod_orden,id_detalle,id_rollo,estado,tipo) VALUES (" & _
                        id_inv & "," & dt.Rows(i).Item("cod_orden") & "," & dt.Rows(i).Item("id_detalle") & "," & dt.Rows(i).Item("id_rollo") & ",0,'B')"
                listSql.Add(sql)
            Next
        End If
        dt = New DataTable
        If bodega = 12 Or bodega = 14 Then
            sql = "SELECT nro_orden AS cod_orden, consecutivo_rollo AS id_rollo FROM D_rollo_galvanizado_f WHERE destino = '" & dest & "' AND SAGA IS NULL AND anular IS NULL"
            dt = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")
            For i = 0 To dt.Rows.Count - 1
                sql = "INSERT INTO JB_control_inventario_rollos (id_inv,cod_orden,id_detalle,id_rollo,estado,tipo) VALUES (" & _
                        id_inv & "," & dt.Rows(i).Item("cod_orden") & ",''," & dt.Rows(i).Item("id_rollo") & ",0,'G')"
                listSql.Add(sql)
            Next
        End If
        If objOpSimplesLn.ExecuteSqlTransactionTodo(listSql, "PRODUCCION") Then
            Using New Centered_MessageBox(Me)
                MessageBox.Show("Inventario iniciado con Exito", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                pan_iniciar.Enabled = False
                pan_rollos.Enabled = True
                tbl_inventario.SelectedTab = pag_rollos
                If bodega <> 1 And bodega <> 2 Then
                    sql = "SELECT count(cod_orden) FROM JB_control_inventario_rollos WHERE estado = 0 AND id_inv = " & id_inv
                Else
                    If dest = "A1" Or dest = "A2" Then
                        sql = "SELECT count(nit_proveedor) FROM JB_control_inventario_alambron WHERE estado = 0 AND id_inv = " & id_inv
                    ElseIf dest = "INVB2" Then
                        sql = "SELECT count(cod_orden) FROM JB_control_inventario_rollos WHERE estado = 0 AND id_inv = " & id_inv
                    End If
                End If
                lbl_rollos.Text = obj_Ing_prodLn.consultar_valor(sql, "PRODUCCION")
                txt_lector.Focus()
            End Using
        End If
    End Sub
    Private Sub btn_iniciar_Click(sender As Object, e As EventArgs) Handles btn_iniciar.Click
        crear_inv()
    End Sub
    Private Sub cargar_rollos(ByVal bodega As Integer)
        dtg_inv.DataSource = Nothing
        Dim sql As String
        If bodega <> 1 And bodega <> 2 Then
            sql = "SELECT cod_orden,id_detalle,id_rollo FROM JB_control_inventario_rollos WHERE id_inv = " & id_inv & " AND estado = 1"
            dtg_inv.DataSource = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")
            sql = "SELECT count(cod_orden) FROM JB_control_inventario_rollos WHERE estado = 0 AND id_inv = " & id_inv
        Else
            sql = "SELECT nit_proveedor,num_importacion,id_solicitud_det,numero_rollo FROM JB_control_inventario_alambron WHERE id_inv = " & id_inv & " AND estado = 1"
            dtg_inv.DataSource = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")
            sql = "SELECT count(nit_proveedor) FROM JB_control_inventario_alambron WHERE estado = 0 AND id_inv = " & id_inv
        End If
            lbl_rollos.Text = obj_Ing_prodLn.consultar_valor(sql, "PRODUCCION")
    End Sub

    Private Sub txt_lector_Enter(sender As Object, e As EventArgs) Handles txt_lector.Enter
        txt_lector.BackColor = Color.Green
    End Sub

    Private Sub txt_lector_Leave(sender As Object, e As EventArgs) Handles txt_lector.Leave
        txt_lector.BackColor = Color.Red
    End Sub

    Private Sub txt_lector_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_lector.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            txt_lector.Text = Replace(txt_lector.Text, "'", "-")
            validar_rollos()
        ElseIf e.KeyChar = "." Then
            e.KeyChar = "-"
        End If
    End Sub
    Private Sub validar_rollos()
        Dim codOrden As String = ""
        Dim idDetalle As String = ""
        Dim idRollo As String = ""
        Dim sql As String = ""
        Dim val As String = ""
        Dim dest As String = ""
        Dim tipo As String = ""
        If cbo_bodega.SelectedValue = 11 Then
            dest = "G"
            tipo = "SAGA"
            rdb_bri.Enabled = True
            rdb_galv.Enabled = False
            rdb_recocido.Enabled = False
            rdb_alambron.Enabled = False
        ElseIf cbo_bodega.SelectedValue = 12 Then
            dest = "P"
            tipo = "SCLA"
            rdb_bri.Enabled = True
            rdb_galv.Enabled = True
            rdb_recocido.Enabled = False
            rdb_alambron.Enabled = False
        ElseIf cbo_bodega.SelectedValue = 13 Then
            dest = "R"
            tipo = "SREC"
            rdb_bri.Enabled = True
            rdb_galv.Enabled = False
            rdb_recocido.Enabled = False
            rdb_alambron.Enabled = False
        ElseIf cbo_bodega.SelectedValue = 14 Then
            dest = "A"
            tipo = "SPU"
            rdb_galv.Checked = True
            rdb_bri.Enabled = False
            rdb_recocido.Enabled = False
            rdb_alambron.Enabled = False
        ElseIf cbo_bodega.SelectedValue = 1 Then
            dest = "A1"
            tipo = "smpp_b2"
            rdb_galv.Checked = False
            rdb_bri.Enabled = False
            rdb_recocido.Enabled = False
            rdb_alambron.Enabled = True
        ElseIf cbo_bodega.SelectedValue = 2 Then
            dest = "A2"
            tipo = "smpp_b2"
            rdb_galv.Checked = False
            rdb_bri.Enabled = False
            rdb_recocido.Enabled = False
            rdb_alambron.Enabled = True
        ElseIf cbo_bodega.SelectedValue = 7 Then
            rdb_galv.Checked = False
            rdb_bri.Enabled = True
            rdb_alambron.Enabled = False
            rdb_recocido.Enabled = True
        End If

        If rdb_alambron.Checked Then
            Dim nit_proveedor As String = obj_gestion_alambronLn.extraerDatoCodigoBarras("proveedor", txt_lector.Text)
            Dim num_importacion As String = obj_gestion_alambronLn.extraerDatoCodigoBarras("num_importacion", txt_lector.Text)
            Dim detalle As String = obj_gestion_alambronLn.extraerDatoCodigoBarras("detalle", txt_lector.Text)
            Dim num_rollo As String = obj_gestion_alambronLn.extraerDatoCodigoBarras("num_rollo", txt_lector.Text)

            If nit_proveedor <> "" And num_importacion <> "" And detalle <> "" And num_rollo <> "" Then
                If dest = "A2" Then
                    sql = "SELECT smpp_b2 FROM J_alambron_importacion_det_rollos WHERE num_importacion =" & num_importacion & " AND nit_proveedor =" & nit_proveedor & "  AND id_solicitud_det =" & detalle & " AND numero_rollo =" & num_rollo
                    val = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")
                    If val = "" Then
                        sql = "SELECT num_transaccion_salida FROM J_alambron_importacion_det_rollos WHERE num_importacion =" & num_importacion & " AND nit_proveedor =" & nit_proveedor & "  AND id_solicitud_det =" & detalle & " AND numero_rollo =" & num_rollo
                        val = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")
                        If val <> "" Then
                            sql = "SELECT estado FROM JB_control_inventario_alambron WHERE num_importacion=" & num_importacion & " AND nit_proveedor =" & nit_proveedor & "  AND id_solicitud_det =" & detalle & " AND numero_rollo =" & num_rollo & " AND tipo = 'A' AND id_inv =" & id_inv & ""
                            val = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")
                            If val = "0" Then
                                sql = "UPDATE JB_control_inventario_alambron SET estado = 1,destino = 'A2'  WHERE num_importacion=" & num_importacion & " AND nit_proveedor =" & nit_proveedor & "  AND id_solicitud_det =" & detalle & " AND numero_rollo =" & num_rollo & " AND tipo = 'A' AND id_inv =" & id_inv & ""
                                If objOpSimplesLn.ejecutar(sql, "PRODUCCION") Then
                                    txt_lector.Text = ""
                                    cargar_rollos(cbo_bodega.SelectedValue)
                                End If
                            ElseIf val = "" Then
                                Using New Centered_MessageBox(Me)
                                    MessageBox.Show("El alambron, no esta registrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                End Using
                            ElseIf val = "1" Then
                                Using New Centered_MessageBox(Me)
                                    MessageBox.Show("El alambron ya a sido registrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                End Using
                            End If
                        Else
                            MessageBox.Show("El alambron esta en bodega 1.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If
                    Else
                        MessageBox.Show("El alambron ya ha sido consumido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                Else
                    sql = "SELECT num_transaccion FROM J_alambron_importacion_det_rollos WHERE num_importacion =" & num_importacion & " AND nit_proveedor =" & nit_proveedor & "  AND id_solicitud_det =" & detalle & " AND numero_rollo =" & num_rollo
                    val = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")
                    If val <> "" Then
                        sql = "SELECT num_transaccion_salida FROM J_alambron_importacion_det_rollos WHERE num_importacion =" & num_importacion & " AND nit_proveedor =" & nit_proveedor & "  AND id_solicitud_det =" & detalle & " AND numero_rollo =" & num_rollo
                        val = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")
                        If val = "" Then
                            sql = "SELECT estado FROM JB_control_inventario_alambron WHERE num_importacion=" & num_importacion & " AND nit_proveedor =" & nit_proveedor & "  AND id_solicitud_det =" & detalle & " AND numero_rollo =" & num_rollo & " AND tipo = 'A' AND id_inv =" & id_inv & ""
                            val = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")
                            If val = "0" Then
                                sql = "UPDATE JB_control_inventario_alambron SET estado = 1,destino = 'A1'  WHERE num_importacion=" & num_importacion & " AND nit_proveedor =" & nit_proveedor & "  AND id_solicitud_det =" & detalle & " AND numero_rollo =" & num_rollo & " AND tipo = 'A' AND id_inv =" & id_inv & ""
                                If objOpSimplesLn.ejecutar(sql, "PRODUCCION") Then
                                    txt_lector.Text = ""
                                    cargar_rollos(cbo_bodega.SelectedValue)
                                End If
                            ElseIf val = "" Then
                                Using New Centered_MessageBox(Me)
                                    MessageBox.Show("El alambron, no esta registrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                End Using
                            ElseIf val = "1" Then
                                Using New Centered_MessageBox(Me)
                                    MessageBox.Show("El alambron ya a sido registrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                End Using
                            End If
                        Else
                            MessageBox.Show("El alambron pertenece a bodega 2.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If
                    Else
                        MessageBox.Show("El alambron no esta registrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If

                End If
            Else
                MessageBox.Show("El alambron no se ha leido bien.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

        End If

        If rdb_bri.Checked Then
            codOrden = objTraslado_bodLn.extraerDatoCodigoBarras("cod_orden", txt_lector.Text)
            idDetalle = objTraslado_bodLn.extraerDatoCodigoBarras("cod_detalle", txt_lector.Text)
            idRollo = objTraslado_bodLn.extraerDatoCodigoBarras("num_rollo", txt_lector.Text)
            If cbo_bodega.SelectedValue = 7 Then
                sql = "select top(1) tipo from JB_control_inventario_rollos where id_inv=" & id_inv & ""
                Dim tipos As String = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")
                If tipos = "T" Then
                    If codOrden <> "" And idDetalle <> "" And idRollo <> "" Then
                        sql = "SELECT traslado FROM J_ROLLOS_TREF WHERE cod_orden = " & codOrden & " AND id_detalle = " & idDetalle & " AND id_rollo = " & idRollo
                        val = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")
                        If val = "" Then
                            sql = "SELECT anulado FROM J_ROLLOS_TREF WHERE cod_orden = " & codOrden & " AND id_detalle = " & idDetalle & " AND id_rollo = " & idRollo
                            val = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")
                            If val = "" Then
                                sql = "SELECT estado FROM JB_control_inventario_rollos WHERE cod_orden = " & codOrden & " AND id_detalle = " & idDetalle & " AND id_rollo = " & idRollo & " AND id_inv =" & id_inv & " AND tipo='" & tipos & "'"
                                val = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")
                                If val = "0" Then
                                    sql = "UPDATE JB_control_inventario_rollos SET estado = 1 WHERE cod_orden = " & codOrden & " AND id_detalle = " & idDetalle & " AND id_rollo = " & idRollo & " AND id_inv =" & id_inv & " AND tipo='" & tipos & "'"
                                    If objOpSimplesLn.ejecutar(sql, "PRODUCCION") Then
                                        txt_lector.Text = ""
                                        cargar_rollos(cbo_bodega.SelectedValue)
                                    End If
                                ElseIf val = "" Then
                                    Using New Centered_MessageBox(Me)
                                        MessageBox.Show("El rollo, no esta registrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                    End Using
                                ElseIf val = "1" Then
                                    Using New Centered_MessageBox(Me)
                                        MessageBox.Show("El rollo ya a sido registrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                    End Using
                                End If

                            Else
                                Using New Centered_MessageBox(Me)
                                    MessageBox.Show("El rollo esta anulado:" & cbo_bodega.SelectedValue, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                End Using
                            End If
                        Else
                            Using New Centered_MessageBox(Me)
                                MessageBox.Show("El rollo no es de bodega 2.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            End Using
                        End If
                    End If
                ElseIf tipo = "E" Then
                    If codOrden <> "" And idDetalle <> "" And idRollo <> "" Then
                        sql = "SELECT traslado FROM J_ROLLOS_TREF WHERE cod_orden = " & codOrden & " AND id_detalle = " & idDetalle & " AND id_rollo = " & idRollo
                        val = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")
                        If val = "" Then
                            sql = "SELECT anulado FROM J_ROLLOS_TREF WHERE cod_orden = " & codOrden & " AND id_detalle = " & idDetalle & " AND id_rollo = " & idRollo
                            val = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")
                            If val = "" Then
                                sql = "SELECT estado FROM JB_control_inventario_rollos WHERE cod_orden = " & codOrden & " AND id_detalle = " & idDetalle & " AND id_rollo = " & idRollo & " AND id_inv =" & id_inv & " AND tipo='" & tipos & "'"
                                val = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")
                                If val = "0" Then
                                    sql = "UPDATE JB_control_inventario_rollos SET estado = 1 WHERE cod_orden = " & codOrden & " AND id_detalle = " & idDetalle & " AND id_rollo = " & idRollo & " AND id_inv =" & id_inv & " AND tipo='" & tipos & "'"
                                    If objOpSimplesLn.ejecutar(sql, "PRODUCCION") Then
                                        txt_lector.Text = ""
                                        cargar_rollos(cbo_bodega.SelectedValue)
                                    End If
                                ElseIf val = "" Then
                                    Using New Centered_MessageBox(Me)
                                        MessageBox.Show("El rollo, no esta registrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                    End Using
                                ElseIf val = "1" Then
                                    Using New Centered_MessageBox(Me)
                                        MessageBox.Show("El rollo ya a sido registrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                    End Using
                                End If

                            Else
                                Using New Centered_MessageBox(Me)
                                    MessageBox.Show("El rollo esta anulado:" & cbo_bodega.SelectedValue, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                End Using
                            End If
                        Else
                            Using New Centered_MessageBox(Me)
                                MessageBox.Show("El rollo no es de bodega 2.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            End Using
                        End If
                    End If
                Else
                    Using New Centered_MessageBox(Me)
                        MessageBox.Show("No es brillante o especial", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End Using
                End If
            Else
                If codOrden <> "" And idDetalle <> "" And idRollo <> "" Then
                    sql = "SELECT anulado FROM J_ROLLOS_TREF WHERE cod_orden = " & codOrden & " AND id_detalle = " & idDetalle & " AND id_rollo = " & idRollo
                    val = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")
                    If val = "" Then
                        sql = "SELECT destino FROM J_ROLLOS_TREF WHERE cod_orden = " & codOrden & " AND id_detalle = " & idDetalle & " AND id_rollo = " & idRollo
                        val = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")
                        If val <> "" And val = dest Then
                            sql = "SELECT " & tipo & " FROM J_ROLLOS_TREF WHERE cod_orden = " & codOrden & " AND id_detalle = " & idDetalle & " AND id_rollo = " & idRollo
                            val = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")
                            If val = "" Then
                                sql = "SELECT estado FROM JB_control_inventario_rollos WHERE cod_orden = " & codOrden & " AND id_detalle = " & idDetalle & " AND id_rollo = " & idRollo & " AND id_inv =" & id_inv & " AND tipo='B'"
                                val = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")
                                If val = "0" Then
                                    sql = "UPDATE JB_control_inventario_rollos SET estado = 1 WHERE cod_orden = " & codOrden & " AND id_detalle = " & idDetalle & " AND id_rollo = " & idRollo & " AND id_inv =" & id_inv & " AND tipo='B'"
                                    If objOpSimplesLn.ejecutar(sql, "PRODUCCION") Then
                                        txt_lector.Text = ""
                                        cargar_rollos(cbo_bodega.SelectedValue)
                                    End If
                                ElseIf val = "" Then
                                    Using New Centered_MessageBox(Me)
                                        MessageBox.Show("El rollo, no esta registrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                    End Using
                                ElseIf val = "1" Then
                                    Using New Centered_MessageBox(Me)
                                        MessageBox.Show("El rollo ya a sido registrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                    End Using
                                End If
                            Else
                                Using New Centered_MessageBox(Me)
                                    MessageBox.Show("El rollo ya a sido consumido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                End Using
                            End If
                        Else
                            Using New Centered_MessageBox(Me)
                                MessageBox.Show("El rollo,no pertenece a esta bodega:" & cbo_bodega.SelectedValue, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            End Using
                        End If
                    Else
                        Using New Centered_MessageBox(Me)
                            MessageBox.Show("El rollo esta anulado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End Using
                    End If
                End If
            End If
        End If
        If rdb_recocido.Checked = True Then
            codOrden = objTraslado_bodLn.extraerDatoCodigoBarras("cod_orden", txt_lector.Text)
            idDetalle = objTraslado_bodLn.extraerDatoCodigoBarras("cod_detalle", txt_lector.Text)
            idRollo = objTraslado_bodLn.extraerDatoCodigoBarras("num_rollo", txt_lector.Text)
            If codOrden <> "" And idDetalle <> "" And idRollo <> "" Then
                sql = "SELECT trans FROM JB_rollos_rec WHERE cod_orden_rec = " & codOrden & " AND id_detalle_rec = " & idDetalle & " AND id_rollo_rec = " & idRollo
                val = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")
                If val <> "" Then
                    sql = "SELECT tipo_trans FROM JB_rollos_rec WHERE cod_orden_rec = " & codOrden & " AND id_detalle_rec = " & idDetalle & " AND id_rollo_rec = " & idRollo
                    val = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")
                    If val = "EPPP" Then
                        sql = "SELECT scae FROM JB_rollos_rec WHERE cod_orden_rec = " & codOrden & " AND id_detalle_rec = " & idDetalle & " AND id_rollo_rec = " & idRollo
                        val = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")
                        If val = "" Then
                            sql = "SELECT estado FROM JB_control_inventario_rollos WHERE cod_orden = " & codOrden & " AND id_detalle = " & idDetalle & " AND id_rollo = " & idRollo & " AND id_inv =" & id_inv & " AND tipo='R'"
                            val = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")
                            If val = "0" Then
                                sql = "UPDATE JB_control_inventario_rollos SET estado = 1 WHERE cod_orden = " & codOrden & " AND id_detalle = " & idDetalle & " AND id_rollo = " & idRollo & " AND id_inv =" & id_inv & " AND tipo='R'"
                                If objOpSimplesLn.ejecutar(sql, "PRODUCCION") Then
                                    txt_lector.Text = ""
                                    cargar_rollos(cbo_bodega.SelectedValue)
                                End If
                            ElseIf val = "" Then
                                Using New Centered_MessageBox(Me)
                                    MessageBox.Show("El rollo, no esta registrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                End Using
                            ElseIf val = "1" Then
                                Using New Centered_MessageBox(Me)
                                    MessageBox.Show("El rollo ya a sido registrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                End Using
                            End If
                        Else
                            Using New Centered_MessageBox(Me)
                                MessageBox.Show("El rollo ya ha sido consumido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            End Using
                        End If
                    Else
                        Using New Centered_MessageBox(Me)
                            MessageBox.Show("El rollo no tiene transaccion EPPP por lo tanto no es de bodega 2.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End Using
                    End If
                Else
                    Using New Centered_MessageBox(Me)
                        MessageBox.Show("El rollo de recocido no tiene transaccion.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End Using
                End If
            Else
                Using New Centered_MessageBox(Me)
                    MessageBox.Show("El consecutivo no es valido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End Using
            End If
        End If
        If rdb_galv.Checked Then
            codOrden = objTraslado_bodLn.extraerDatoCodigoBarras("cod_orden", txt_lector.Text)
            idRollo = objTraslado_bodLn.extraerDatoCodigoBarras("cod_detalle", txt_lector.Text)
            If codOrden <> "" And idRollo <> "" Then
                sql = "SELECT anular FROM D_rollo_galvanizado_f WHERE  nro_orden = " & codOrden & " AND consecutivo_rollo=" & idRollo
                val = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")
                If val = "" Then
                    sql = "SELECT destino FROM D_rollo_galvanizado_f WHERE  nro_orden = " & codOrden & " AND consecutivo_rollo=" & idRollo
                    val = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")
                    If val <> "" And val = dest Then
                        sql = "SELECT saga FROM D_rollo_galvanizado_f WHERE  nro_orden = " & codOrden & " AND consecutivo_rollo=" & idRollo
                        val = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")
                        If val = "" Then
                            sql = "SELECT estado FROM JB_control_inventario_rollos WHERE cod_orden = " & codOrden & "  AND id_rollo = " & idRollo & " AND id_inv =" & id_inv & " AND tipo='G'"
                            val = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")
                            If val = "0" Then
                                sql = "UPDATE JB_control_inventario_rollos SET estado = 1 WHERE cod_orden = " & codOrden & "  AND id_rollo = " & idRollo & " AND id_inv =" & id_inv & " AND tipo='G'"
                                If objOpSimplesLn.ejecutar(sql, "PRODUCCION") Then
                                    txt_lector.Text = ""
                                    cargar_rollos(cbo_bodega.SelectedValue)
                                End If
                            ElseIf val = "" Then
                                Using New Centered_MessageBox(Me)
                                    MessageBox.Show("El rollo, no esta registrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                End Using
                            ElseIf val = "1" Then
                                Using New Centered_MessageBox(Me)
                                    MessageBox.Show("El rollo ya a sido registrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                End Using
                            End If
                        Else
                            Using New Centered_MessageBox(Me)
                                MessageBox.Show("El rollo ya a sido consumido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            End Using
                        End If
                    Else
                        Using New Centered_MessageBox(Me)
                            MessageBox.Show("El rollo,no pertenece a esta bodega:" & cbo_bodega.SelectedValue, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End Using
                    End If
                Else
                    Using New Centered_MessageBox(Me)
                        MessageBox.Show("El rollo esta anulado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End Using
                End If
            End If
        End If
    End Sub

    Private Sub btn_terminar_Click(sender As Object, e As EventArgs) Handles btn_terminar.Click
        Using New Centered_MessageBox(Me)
            Dim iResponce As Integer = MessageBox.Show("¿Desea terminar el inventario?", "Atención", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
            If iResponce = 6 Then
                Dim sql As String = "UPDATE JB_control_inventario SET fec_fin= GETDATE() WHERE id=" & id_inv
                If objOpSimplesLn.ejecutar(sql, "PRODUCCION") Then
                    Using New Centered_MessageBox(Me)
                        MessageBox.Show("Inventario terminado exitosamente.", "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End Using
                    id_inv = 0
                    cbo_bodega.SelectedValue = 0
                    dtg_inv.DataSource = Nothing
                    pan_iniciar.Enabled = True
                    pan_rollos.Enabled = False
                    tbl_inventario.SelectedTab = pag_iniciar
                End If
            End If
        End Using
    End Sub

    Private Sub frm_control_inv_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
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

End Class