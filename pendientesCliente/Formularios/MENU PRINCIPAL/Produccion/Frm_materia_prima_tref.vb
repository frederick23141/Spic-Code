Imports logicaNegocios
Imports entidadNegocios
Public Class Frm_materia_prima_tref
    Private objOpsimpesLn As New Op_simpesLn
    'Este modulo es para saber la materia prima que se ha consumido
    Private Sub btn_actualizar_Click(sender As Object, e As EventArgs) Handles btn_actualizar.Click
        If txt_nro_orden.Text <> "" And txt_detalle.Text <> "" Then
            If IsNumeric(txt_nro_orden.Text) And IsNumeric(txt_detalle.Text) Then
                Dim nro_orden As Integer = CInt(txt_nro_orden.Text)
                Dim id_detalle As Integer = CInt(txt_detalle.Text)
                Dim sql_reproce, sql_alambron As String
                sql_reproce = "SELECT t.prod_final,(convert(varchar,o.cod_rec)+'-'+convert(varchar, o.det_rec)+'-'+convert(varchar, o.roll_rec)) as consecutivo,r.peso " & _
                              " FROM JB_orden_prod_tref_mp_rec o,JB_orden_prod_rec_refs t, JB_rollos_rec r  WHERE ( r.id_prof_final = t.num AND r.cod_orden_rec = t.cod_orden) and r.cod_orden_rec=o.cod_rec and r.id_detalle_rec=o.det_rec and r.id_rollo_rec=o.roll_rec and o.cod_orden = " & nro_orden & " AND o.id_detalle = " & id_detalle & ""
                dtg_reproceso.DataSource = objOpsimpesLn.listar_datatable(sql_reproce, "PRODUCCION")

                sql_alambron = "SELECT t.codigo,d.nit_proveedor,d.num_importacion,d.id_solicitud_det,d.numero_rollo,d.peso" & _
                               " FROM J_alambron_importacion_det_rollos d , J_orden_prod_rollo_mp o ,J_alambron_solicitud_det t" & _
                              " WHERE o.id_rollo_mp = d.id And d.num_importacion = t.num_importacion And d.id_solicitud_det = t.id_det And o.cod_orden = " & nro_orden & " And o.id_detalle = " & id_detalle & "" & _
                              "ORDER BY d.id "

                dtg_alambron.DataSource = objOpsimpesLn.listar_datatable(sql_alambron, "PRODUCCION")
            Else
                MessageBox.Show("los campos deben ser numericos", "Campos numericos", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            MessageBox.Show("No se puede dejar los campos vacios", "Llenar los dos campos", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

    End Sub
End Class