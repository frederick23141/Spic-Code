Imports logicaNegocios
Imports entidadNegocios
Imports accesoDatos
Public Class frm_auditoria_inventarios
    Private objOpsimpesLn As New Op_simpesLn
    Dim obj_op_simplesLn As New Op_simpesLn
    Private obj_Ing_prodLn As New Ing_prodLn
    Dim usuario As UsuarioEn
    Private objOrdenProdLn As New OrdenProdLn
    Dim objTraslado_bodLn As New traslado_bodLn
    Private objOpSimplesLn As New Op_simpesLn
    Private numero_transaccion As Double
    Private objOperacionesForm As OperacionesFormularios = New OperacionesFormularios

    Public Sub main(ByVal usuario As UsuarioEn)
        Me.usuario = usuario
    End Sub


    Private Sub frm_auditoria_inventarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dt As New DataTable
        Dim sql As String = "SELECT T.tipo,T.sw " & _
                          "FROM  tipo_transacciones T "
        dt = objOpsimpesLn.listar_datatable(sql, "CORSAN")
        cbo_tipo.DataSource = dt
        cbo_tipo.ValueMember = "sw"
        cbo_tipo.DisplayMember = "tipo"
        cbo_tipo.Text = "Seleccione"


        sql = "SELECT bodega,(CONVERT(varchar,bodega)+'--'+ descripcion) as descripcion FROM bodegas ORDER BY bodega"
        dt = objOpsimpesLn.listar_datatable(sql, "CORSAN")
        dt.Rows.Add()
        dt.Rows(dt.Rows.Count - 1).Item("bodega") = 0
        dt.Rows(dt.Rows.Count - 1).Item("descripcion") = "Seleccione"
        cbo_bodega.DataSource = dt
        cbo_bodega.ValueMember = "bodega"
        cbo_bodega.DisplayMember = "descripcion"
        cbo_bodega.SelectedValue = 0
    End Sub

    Private Sub cargar_datos()
        Dim sql As String = ""
        Dim sql_inventareado As String = ""
        Dim sql_sin_invenario As String = ""

        Dim whereSql As String = ""
        If chk_consolidar.Checked Then
            sql = "SELECT o.prod_final ,ref.descripcion ,SUM(r.peso) AS stock " & _
                    " FROM J_inventario_alambre j , J_orden_prod_tef o,J_rollos_tref r , CORSAN.dbo.referencias ref " & _
                        " WHERE ref.codigo = o.prod_final And j.cod_orden = r.cod_orden And j.id_detalle = r.id_detalle And j.id_rollo = r.id_rollo And o.consecutivo = r.cod_orden "
            sql_inventareado = "SELECT o.prod_final,SUM(r.peso) AS Inventariado " & _
                                    " FROM J_inventario_alambre j , J_orden_prod_tef o,J_rollos_tref r , CORSAN.dbo.referencias ref " & _
                                        " WHERE j.estado Is Not null And ref.codigo = o.prod_final And j.cod_orden = r.cod_orden And j.id_detalle = r.id_detalle And j.id_rollo = r.id_rollo And o.consecutivo = r.cod_orden "
            sql_sin_invenario = "SELECT o.prod_final,SUM(r.peso) AS no_inventariado " & _
                                    " FROM J_inventario_alambre j , J_orden_prod_tef o,J_rollos_tref r , CORSAN.dbo.referencias ref " & _
                                        " WHERE j.estado Is null And ref.codigo = o.prod_final And j.cod_orden = r.cod_orden And j.id_detalle = r.id_detalle And j.id_rollo = r.id_rollo And o.consecutivo = r.cod_orden "
            If txt_inventario.Text <> "" Then
                whereSql &= " AND j.inventario = " & txt_inventario.Text
            End If
            sql &= whereSql & " GROUP BY o.prod_final ,ref.descripcion "
            sql_inventareado &= whereSql & " GROUP BY o.prod_final ,ref.descripcion "
            sql_sin_invenario &= whereSql & " GROUP BY o.prod_final ,ref.descripcion "
        Else
            sql = "SELECT j.cod_orden , j.id_detalle ,  j.id_rollo ,o.prod_final ,ref.descripcion ,r.peso, j.estado " & _
                    " FROM J_inventario_alambre j , J_orden_prod_tef o,J_rollos_tref r , CORSAN.dbo.referencias ref " & _
                        " WHERE ref.codigo = o.prod_final And j.cod_orden = r.cod_orden And j.id_detalle = r.id_detalle And j.id_rollo = r.id_rollo And o.consecutivo = r.cod_orden "
            If chk_solo_faltantes.Checked Then
                whereSql &= " AND j.estado Is Null "
            End If
            If chk_solo_fisico.Checked Then
                whereSql &= " AND j.estado Is Not Null "
            End If
            If txt_inventario.Text <> "" Then
                whereSql &= " AND j.inventario = " & txt_inventario.Text
            End If
            sql &= whereSql
        End If
        If chk_consolidar.Checked Then
            Dim dt As DataTable = consolidar(sql, sql_inventareado, sql_sin_invenario)
            Dim sum As Double = 0
            dt.Rows.Add()
            For j = 0 To dt.Columns.Count - 1
                If dt.Columns(j).ColumnName = "diferencia" Or dt.Columns(j).ColumnName = "stock" Or dt.Columns(j).ColumnName = "Fisico" Then
                    For i = 0 To dt.Rows.Count - 1
                        If Not IsDBNull(dt.Rows(i).Item(j)) Then
                            sum += dt.Rows(i).Item(j)
                        End If
                    Next
                    dt.Rows(dt.Rows.Count - 1).Item(j) = sum
                    sum = 0
                ElseIf dt.Columns(j).ColumnName = "prod_final" Then
                    dt.Rows(dt.Rows.Count - 1).Item(j) = "Total"

                End If
            Next
            dtg_auditoria.DataSource = dt
        Else
            Dim dt As DataTable = objOpsimpesLn.listar_datatable(sql, "PRODUCCION")
            Dim sum As Double = 0
            dt.Rows.Add()
            For j = 0 To dt.Columns.Count - 1
                If dt.Columns(j).ColumnName = "peso" Then
                    For i = 0 To dt.Rows.Count - 1
                        If Not IsDBNull(dt.Rows(i).Item(j)) Then
                            sum += dt.Rows(i).Item(j)
                        End If
                    Next
                    dt.Rows(dt.Rows.Count - 1).Item(j) = sum
                    sum = 0
                ElseIf dt.Columns(j).ColumnName = "descripcion" Then
                    dt.Rows(dt.Rows.Count - 1).Item(j) = "Total"
                End If
            Next
            dtg_auditoria.DataSource = dt

            Me.dtg_auditoria.Columns("estado").Visible = False
            For Each Row As DataGridViewRow In dtg_auditoria.Rows
                If IsDBNull(Row.Cells("estado").Value) = False Then
                    Row.DefaultCellStyle.BackColor = Color.Green
                End If
            Next
        End If
    End Sub

    Private Function consolidar(ByVal sql1 As String, ByVal sql2 As String, ByVal sql3 As String) As DataTable
        Dim dt As New DataTable
        dt = obj_op_simplesLn.listar_datatable(sql1, "PRODUCCION")
        add_inv(dt, sql2)
        add_sin_inv(dt, sql3)
        Return dt
    End Function

    Private Sub add_sin_inv(ByRef dt As DataTable, ByVal sql As String)
        dt.Columns.Add("diferencia", GetType(Double))
        Dim dt_sn As DataTable = obj_op_simplesLn.listar_datatable(sql, "PRODUCCION")

        For i = 0 To dt.Rows.Count - 1
            For k = 0 To dt_sn.Rows.Count - 1
                Dim var1 As String = dt.Rows(i).Item("prod_final")
                Dim var2 As String = dt_sn.Rows(k).Item("prod_final")
                If var1.ToUpper = var2.ToUpper Then
                    dt.Rows(i).Item("diferencia") = dt_sn.Rows(k).Item("no_inventariado")
                End If
            Next
        Next
    End Sub
    Private Sub add_inv(ByRef dt As DataTable, ByVal sql As String)
        dt.Columns.Add("Fisico", GetType(Double))
        Dim dt_n As DataTable = obj_op_simplesLn.listar_datatable(sql, "PRODUCCION")

        For i = 0 To dt.Rows.Count - 1
            For k = 0 To dt_n.Rows.Count - 1
                Dim var1 As String = dt.Rows(i).Item("prod_final")
                Dim var2 As String = dt_n.Rows(k).Item("prod_final")
                If var1.ToUpper = var2.ToUpper Then
                    dt.Rows(i).Item("Fisico") = dt_n.Rows(k).Item("Inventariado")
                End If
            Next
        Next
    End Sub

    Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
        img_cargar.Visible = True
        dtg_auditoria.DataSource = Nothing
        If txt_inventario.Text <> "" Then
            cargar_datos()
        Else
            txt_inventario.Enabled = False
            dtg_auditoria.Enabled = False
            group_consulta_inv.Visible = True
            txt_nit_consulta_inv.Focus()
            txt_nit_consulta_inv.Text = ""
            txt_nomb_consulta_inv.Text = ""
            cargar_inventario()
        End If
        img_cargar.Visible = False
    End Sub

    Private Sub txt_inventario_Click(sender As Object, e As EventArgs) Handles txt_inventario.Click
        txt_inventario.Enabled = False
        dtg_auditoria.Enabled = False
        group_consulta_inv.Visible = True
        txt_nit_consulta_inv.Focus()
        txt_nit_consulta_inv.Text = ""
        txt_nomb_consulta_inv.Text = ""
        cargar_inventario()
    End Sub

    Private Sub btnCerrarPF_Click(sender As Object, e As EventArgs) Handles btnCerrarPF.Click
        txt_inventario.Enabled = True
        dtg_auditoria.Enabled = True
        group_consulta_inv.Visible = False
    End Sub

    Private Sub txt_nit_consulta_inv_TextChanged(sender As Object, e As EventArgs) Handles txt_nit_consulta_inv.TextChanged
        If (txt_nit_consulta_inv.Text.Length > 3) Then
            cargar_inventario()
        End If
    End Sub

    Private Sub txt_nomb_consulta_inv_TextChanged(sender As Object, e As EventArgs) Handles txt_nomb_consulta_inv.TextChanged
        If (txt_nomb_consulta_inv.Text.Length > 3) Then
            cargar_inventario()
        End If
    End Sub
    Private Sub cargar_inventario()
        Dim sql As String = "SELECT i.id,i.nit,p.nombres,i.fecha,i.codigo,i.bodega,i.fecha_terminado " & _
                                " FROM J_inventario_enc i, CORSAN.dbo.V_nom_personal_Activo_con_maquila p " & _
                                    " WHERE (i.nit = p.nit AND i.fecha_terminado Is Not Null) "
        Dim whereSql As String = ""
        If txt_nit_consulta_inv.Text <> "" Then
            whereSql &= " AND i.nit like '" & txt_nit_consulta_inv.Text & "%'"
        End If
        If txt_nomb_consulta_inv.Text <> "" Then
            whereSql &= " AND p.nombres like '" & txt_nomb_consulta_inv.Text & "%'"
        End If
        sql &= whereSql & " ORDER BY i.id "
        Dim dt As DataTable = objOpsimpesLn.listar_datatable(sql, "PRODUCCION")
        dtg_consulta.DataSource = dt
    End Sub

    Private Sub dtg_consulta_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtg_consulta.CellClick
        img_cargar.Visible = True
        Dim fila As Integer = e.RowIndex
        Dim col As String = dtg_consulta.Columns(e.ColumnIndex).Name
        If (fila >= 0) Then
            If (col = "btn_inv") Then
                txt_inventario.Text = dtg_consulta.Item("id", fila).Value
                txt_inventario.Enabled = True
                dtg_auditoria.Enabled = True
                group_consulta_inv.Visible = False
                If txt_inventario.Text <> "" Then
                    cargar_datos()
                End If
            End If
        End If
        img_cargar.Visible = False
    End Sub

    Private Sub chk_consolidar_CheckStateChanged(sender As Object, e As EventArgs) Handles chk_consolidar.CheckStateChanged
        chk_solo_faltantes.Checked = False
        chk_solo_fisico.Checked = False
    End Sub

    Private Sub chk_solo_fisico_CheckStateChanged(sender As Object, e As EventArgs) Handles chk_solo_fisico.CheckStateChanged
        chk_consolidar.Checked = False
        chk_solo_faltantes.Checked = False
    End Sub

    Private Sub chk_solo_faltantes_CheckStateChanged(sender As Object, e As EventArgs) Handles chk_solo_faltantes.CheckStateChanged
        chk_consolidar.Checked = False
        chk_solo_fisico.Checked = False
    End Sub

    Private Sub validar_transaccion()
        img_cargar.Visible = True
        If chk_consolidar.Checked Then
            If txt_inventario.Text <> "" Then
                cargar_datos()
                If dtg_auditoria.Rows.Count <> 0 Then
                    group_filtro.Enabled = False
                    dtg_auditoria.Enabled = False
                    group_transaccion.Visible = True
                Else
                    MessageBox.Show("La consulta esta vacia, verifique el numero del inventario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                MessageBox.Show("Debe seleccionar un inventario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            MessageBox.Show("Es necesario consolidar la consulta, Seleccione el campo de Consolidar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        img_cargar.Visible = False
    End Sub

    Private Sub btn_transaccion_Click(sender As Object, e As EventArgs) Handles btn_transaccion.Click
        validar_transaccion()
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        group_filtro.Enabled = True
        group_transaccion.Visible = False
        txt_modelo.Text = ""
        cbo_bodega.SelectedValue = 0
    End Sub
    Private Sub transaccion_z()
        Dim sql As String = ""
        Dim tipo As String = cbo_tipo.Text
        Dim bodega As String = cbo_bodega.SelectedValue
        Dim modelo As String = txt_modelo.Text

        Dim listTransaccion_corsan As New List(Of Object)
        Dim listSql As New List(Of Object)
        Dim dt As New DataTable
        Dim codigo As String
        Dim peso As Double
        Dim dt2 As New DataTable
        Dim stocks As Double = 0

        Dim peso_ver As String = ""
        dt.Columns.Add("codigo")
        dt.Columns.Add("cantidad")

        For i = 0 To dtg_auditoria.RowCount - 1
            If Not IsDBNull(dtg_auditoria.Item("diferencia", i).Value) Then
                codigo = dtg_auditoria.Item("prod_final", i).Value
                peso = dtg_auditoria.Item("diferencia", i).Value
                If peso > 0 Then
                    stocks = objOpsimpesLn.consultarStock(codigo, bodega)
                    If peso <= stocks Then
                        dt.Rows.Add()
                        dt.Rows(dt.Rows.Count - 1).Item("codigo") = codigo
                        dt.Rows(dt.Rows.Count - 1).Item("cantidad") = peso
                    End If
                End If
            End If
        Next
        If dt.Rows.Count <> 0 Then
            listTransaccion_corsan.AddRange(transaccion(dt, tipo, bodega, modelo))

            If obj_Ing_prodLn.ExecuteSqlTransaction(listTransaccion_corsan, "CORSAN") Then
                sql = "SELECT cod_orden,id_detalle,id_rollo " & _
                            " FROM J_inventario_alambre " & _
                                " WHERE estado Is Null And inventario =  " & txt_inventario.Text
                dt2 = obj_op_simplesLn.listar_datatable(sql, "PRODUCCION")

                sql = "SELECT codigo FROM J_inventario_enc WHERE id = " & txt_inventario.Text
                Dim codigo2 As String = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")
                Dim var As String = ""

                If codigo2 = "2200" Then
                    var = "srec"
                End If
                If codigo2 = "2300" Then
                    var = "scla"
                End If
                If codigo2 = "2800" Then
                    var = "saga"
                End If
                If var <> "" Then
                    For j = 0 To dt2.Rows.Count - 1
                        sql = "UPDATE J_rollos_tref SET " & var & "= 1 WHERE cod_orden = " & dt2.Rows(j).Item("cod_orden") & _
                                " AND id_detalle = " & dt2.Rows(j).Item("id_detalle") & " AND id_rollo = " & dt2.Rows(j).Item("id_rollo")
                        listSql.Add(sql)
                    Next
                    If obj_Ing_prodLn.ExecuteSqlTransaction(listSql, "PRODUCCION") Then
                        MessageBox.Show("El proceso se realiz correctamente. ", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        group_filtro.Enabled = True
                        dtg_auditoria.Enabled = True
                        group_transaccion.Visible = False
                        txt_modelo.Text = ""
                        cbo_bodega.SelectedValue = 0
                    End If
                Else
                    MessageBox.Show("Error al realizar la operacion. ", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        Else
            group_filtro.Enabled = True
            dtg_auditoria.Enabled = True
            group_transaccion.Visible = False
            txt_modelo.Text = ""
            cbo_bodega.SelectedValue = 0
        End If
    End Sub

    Private Function transaccion(ByVal datacodigo As DataTable, ByVal tipo As String, ByVal bodega As Integer, ByVal modelo As String) As List(Of Object)
        Dim listSql As New List(Of Object)
        Dim dFec As Date = Now
        Dim sql As String = "SELECT nit FROM J_inventario_enc WHERE id = " & txt_inventario.Text
        Dim usuario As String = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")
        Dim notas As String = "SPIC fecha:" & Now & " usuario:" & usuario & "; Se realizo por Ajuste de inventario"
        numero_transaccion = objOrdenProdLn.mover_consecutivo(tipo)
        listSql = objTraslado_bodLn.listaTransaccionDatable(numero_transaccion, datacodigo, bodega, dFec, notas, usuario, tipo, modelo)
        Return listSql
    End Function


    Private Sub btn_guardar_trans_Click(sender As Object, e As EventArgs) Handles btn_guardar_trans.Click
        If txt_modelo.Text <> "" Then
            If cbo_bodega.SelectedValue <> 0 Then
                transaccion_z()
            Else
                MessageBox.Show("debe seleccionar una bodega. ", "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            MessageBox.Show("debe ingresar un modelo. ", "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        Me.UseWaitCursor = True
        Application.DoEvents()
        objOperacionesForm.exportarExcel(dtg_auditoria)
        Me.UseWaitCursor = False
    End Sub
End Class