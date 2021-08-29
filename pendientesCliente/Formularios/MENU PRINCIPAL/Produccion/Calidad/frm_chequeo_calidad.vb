Imports logicaNegocios
Public Class frm_chequeo_calidad
    Private objIngresoProdLn As New Ing_prodLn
    Private objOpSimplesLn As New Op_simpesLn
    Private Sub Frm_chequeo_calidad_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargar_Consulta()
    End Sub
    Private Sub cargar_Consulta()
        Dim sql As String
        Dim dt As DataTable
        sql = "SELECT (r.cod_orden + '-' + r.id_detalle + '-' + cast(r.id_rollo as nvarchar)) as consecutivo,r.cod_orden,r.id_detalle,r.id_rollo,o.prod_final,t.descripcion,r.peso,r.fecha_hora" &
               " FROM J_rollos_tref r, J_orden_prod_tef o,J_det_orden_prod d, CORSAN.dbo.referencias t" &
               " WHERE (r.cod_orden = o.consecutivo AND o.prod_final = t.codigo and d.cod_orden=r.cod_orden and d.id_detalle=r.id_detalle) and o.ano >=2019" &
                " AND r.anulado IS NULL and r.destino is null and r.traslado is null and r.scae is null and r.scal is null and r.calidad is null and d.transaccion_entrada is not null"

        dt = objIngresoProdLn.listar_datatable(sql, "PRODUCCION")
        blinding_Chequeo = New BindingSource()
        blinding_Chequeo.DataSource = dt
        dtg_Chequeo.DataSource = blinding_Chequeo
        dtg_Chequeo.Columns("cod_orden").Visible = False
        dtg_Chequeo.Columns("id_detalle").Visible = False
        dtg_Chequeo.Columns("id_rollo").Visible = False
        pintar_Botones()
    End Sub
    Private Sub Txt_consecutivo_TextChanged(sender As Object, e As EventArgs) Handles txt_consecutivo.TextChanged
        blinding_Chequeo.Filter = String.Format("consecutivo LIKE '{0}%'", txt_consecutivo.Text)
        pintar_Botones()
    End Sub
    Private Sub pintar_Botones()
        Dim valor As Double = 0
        Dim indice As Integer = 0
        For Each row As DataGridViewRow In dtg_Chequeo.Rows
            row.Cells("btnAprobar").Style.BackColor = Color.Green
            row.Cells("btnDesapro").Style.BackColor = Color.Coral
        Next
    End Sub
    Private Sub Dtg_Chequeo_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtg_Chequeo.CellContentClick
        Dim fila As Integer = e.RowIndex
        Dim col As String = dtg_Chequeo.Columns(e.ColumnIndex).Name
        Dim sql As String
        If (col = "btnAprobar") Then
            Dim result As MsgBoxResult
            result = MessageBox.Show("Esta seguro que desea aprobar el rollo?", "Aprobar rollo", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
            If result = vbYes Then
                sql = "update calidad='S' where cod_orden=" & dtg_Chequeo.Item("cod_orden", fila).Value & "" &
                       " And id_detalle=" & dtg_Chequeo.Item("id_detalle", fila).Value & " and id_rollo= " & dtg_Chequeo.Item("id_rollo", fila).Value & ""
                objOpSimplesLn.ejecutar(sql, "PRODUCCION")
                MessageBox.Show("El rollo fue aprobado", "Rollo aprobado", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        ElseIf (col = "btnDesapro") Then
            Dim result As MsgBoxResult
            result = MessageBox.Show("Esta seguro que desea desaprobar el rollo?", "desaprobar rollo", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
            If result = vbYes Then
                sql = "update calidad='N' where cod_orden=" & dtg_Chequeo.Item("cod_orden", fila).Value & "" &
                       "And id_detalle=" & dtg_Chequeo.Item("id_detalle", fila).Value & " and id_rollo= " & dtg_Chequeo.Item("id_rollo", fila).Value & ""
                objOpSimplesLn.ejecutar(sql, "PRODUCCION")
                MessageBox.Show("El rollo fue desaprobado", "Rollo desaprobado", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub
End Class