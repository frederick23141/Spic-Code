Imports entidadNegocios
Imports logicaNegocios
Public Class frm_list_referencias_rec

    Private objOpSimplesLn As New Op_simpesLn
    Dim num_orden, num_orden_editar As Integer
    Dim num_ref As Integer
    Public Sub main(ByVal cod_orden As Integer)
        Me.Text = "LISTADO DE REFERENCIAS DE LA ORDEN #" & cod_orden
        lbl_titulo.Text = "LISTADO DE REFERENCIAS DE LA ORDEN #" & cod_orden
        num_orden = cod_orden
        dtg_consulta.DataSource = Nothing
    End Sub

    Private Sub consultar(ByVal cod_orden As Integer)
        Dim sql As String = "SELECT r.cod_orden,r.num,r.prod_final,c.nombres,r.cantidad,r.mat_prima,r.oculto, (SELECT SUM(PESO) FROM JB_rollos_rec d WHERE d.cod_orden_rec = r.cod_orden AND d.id_prof_final = r.num AND d.trans Is Not Null)  AS trabajado FROM JB_orden_prod_rec_refs r, CORSAN.dbo.terceros c WHERE r.cliente = c.nit AND r.cantidad > 0 AND cod_orden = " & cod_orden & " order by r.num "
        dtg_consulta.DataSource = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")
        dtg_consulta.Columns("oculto").Visible = False
        dtg_consulta.Columns("cod_orden").Visible = False
        sql = "select id_prof_final,sum(peso) as peso from JB_rollos_rec where cod_orden_rec = " & cod_orden & " and trans is not null group by id_prof_final"
        Dim dt As DataTable = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")
        For i = 0 To dtg_consulta.RowCount - 1
            For j = 0 To dt.Rows.Count - 1
                If dtg_consulta.Item("num", i).Value = dt.Rows(j).Item("id_prof_final") Then
                    If dtg_consulta.Item("cantidad", i).Value <= dt.Rows(j).Item("peso") Then
                        dtg_consulta.Rows(i).DefaultCellStyle.BackColor = Color.Red
                    End If
                End If
            Next

            If Not IsDBNull(dtg_consulta.Item("oculto", i).Value) Then
                If (dtg_consulta.Item("oculto", i).Value = 1) Then
                    dtg_consulta.Item(col_ocultar.Name, i).Value = Spic.My.Resources.ok3
                End If
            End If
        Next
    End Sub

    Private Sub dtg_consulta_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtg_consulta.CellClick
        Dim col As String = dtg_consulta.Columns(e.ColumnIndex).Name
        Dim fila As Integer = e.RowIndex
        num_orden_editar = dtg_consulta.Item("cod_orden", e.RowIndex).Value
        num_ref = dtg_consulta.Item("num", e.RowIndex).Value
        If (col = col_ocultar.Name) Then
            If (MessageBox.Show("Esta seguro que desea ocultar o desocultar la ORDEN?", "ocultar Orden?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) = 6) Then
                Dim estado As Integer
                Dim accion As String = ""

                If Not IsDBNull(dtg_consulta.Item("oculto", e.RowIndex).Value) Then
                    If (dtg_consulta.Item("oculto", e.RowIndex).Value = 0) Then
                        accion = "ocultar"
                        estado = 1
                        dtg_consulta.Item(col, e.RowIndex).Value = Spic.My.Resources.ok3
                        dtg_consulta.Item("oculto", e.RowIndex).Value = estado
                    Else
                        accion = "desocultar"
                        estado = 0
                        dtg_consulta.Item("oculto", e.RowIndex).Value = estado
                        dtg_consulta.Item(col, e.RowIndex).Value = Spic.My.Resources.x
                    End If
                Else
                    accion = "ocultar"
                    estado = 1
                    dtg_consulta.Item(col, e.RowIndex).Value = Spic.My.Resources.ok3
                    dtg_consulta.Item("oculto", e.RowIndex).Value = estado
                End If
                Dim consecutivo As Integer = dtg_consulta.Item("num", dtg_consulta.CurrentCell.RowIndex).Value
                Dim sql As String = "UPDATE JB_orden_prod_rec_refs SET oculto = " & estado & " WHERE num = " & consecutivo & " AND cod_orden = " & num_orden
                If (objOpSimplesLn.ejecutar(sql, "PRODUCCION")) Then
                    MessageBox.Show("La orden se " & accion & " en forma exitosa!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Error al " & accion & " la orden, comuniquese con el administrador del sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        End If
    End Sub

    Private Sub btn_consultar_Click(sender As Object, e As EventArgs) Handles btn_consultar.Click
        dtg_consulta.DataSource = Nothing
        consultar(num_orden)
    End Sub
    Private Sub EditarCantidadToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditarCantidadToolStripMenuItem.Click
        Dim n_cantidad As String = InputBox("Ingrese la nueva cantidad de la referencia:", "Nueva cantidad")
        Dim sql As String
        Dim val_trab As String
        If IsNumeric(n_cantidad) Then
            sql = "SELECT SUM(PESO) FROM JB_rollos_rec d inner join JB_orden_prod_rec_refs r on d.cod_orden_rec = r.cod_orden and d.id_prof_final = r.num WHERE d.cod_orden_rec =" & num_orden_editar & "  AND d.id_prof_final =" & num_ref & " AND d.trans Is Not Null"
            val_trab = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")
            If val_trab = "" Then
                val_trab = "0"
            End If
            If CDbl(n_cantidad) > CDbl(val_trab) Then
                sql = "update JB_orden_prod_rec_refs set cantidad=" & n_cantidad & " where cod_orden=" & num_orden_editar & " and num=" & num_ref & ""
                objOpSimplesLn.ejecutar(sql, "PRODUCCION")
                MessageBox.Show("Cantidad actualizada", "Actualizada", MessageBoxButtons.OK, MessageBoxIcon.Information)
                consultar(num_orden)
            Else
                MessageBox.Show("Cantidad ingresada debe ser mayor a la existente", "Actualizada", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            MessageBox.Show("Ingrese correctamente la cantidad", "Debe ser numerica", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

 
    Private Sub dtg_consulta_CellMouseDown(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dtg_consulta.CellMouseDown
        num_orden_editar = dtg_consulta.Item("cod_orden", e.RowIndex).Value
        num_ref = dtg_consulta.Item("num", e.RowIndex).Value
    End Sub
End Class