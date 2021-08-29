Imports logicaNegocios
Imports entidadNegocios
Public Class frm_auditoria_recocido
    Private objOpSimplesLn As New Op_simpesLn
    Private objOperacionesForm As OperacionesFormularios = New OperacionesFormularios
    Public Sub main(ByVal usuario As UsuarioEn)
        If usuario.permiso.Trim <> "ADMIN" And usuario.permiso.Trim <> "DIR_PRODUCCION" Then
            chk_consolidar.Checked = True
            chk_consolidar.Enabled = False
        End If
    End Sub
    Private Sub consultar()
        Dim fecIni As String = objOpSimplesLn.cambiarFormatoFecha(Convert.ToDateTime(cbo_fecha_in.Value))
        Dim fecFin As String = objOpSimplesLn.cambiarFormatoFecha(Convert.ToDateTime(cbo_fecha_fin.Value))
        fecFin = fecFin & " 23:59:00"
        Dim sql As String = ""
        Dim horno As String
        Dim consulta As String
        If cbo_horno.SelectedValue = 0 Then
            horno = ""
        Else
            horno = " and g.horno=" & cbo_horno.SelectedValue & ""
        End If
        Dim dt As New DataTable
        If chk_consolidar.Checked = False Then
            If rdb_sin_r.Checked Then
                sql = "SELECT (CONVERT(VARCHAR,r.cod_orden) +'-' + CONVERT(VARCHAR,r.id_detalle) + '-' + CONVERT(VARCHAR,r.id_rollo)) AS consecutivo,o.prod_final,d.descripcion,r.peso,r.colada,r.traccion " &
                        " FROM J_ROLLOS_TREF r, j_orden_prod_tef o,CORSAN.dbo.referencias d " &
                            " WHERE (r.cod_orden = o.consecutivo AND o.prod_final = d.codigo) " &
                                " AND DESTINO = 'R' AND traslado IS NOT NULL AND SREC IS NULL AND ANULADO IS NULL "

                If txt_codigo.Text <> "" Then
                    sql &= " AND o.prod_final like '" & txt_codigo.Text & "%'"
                End If
                sql &= " ORDER BY r.cod_orden,r.id_detalle,r.id_rollo"
            End If
            If rdb_rec.Checked Then
                sql = "SELECT	(CONVERT(VARCHAR,r.cod_orden_rec) +'-' + CONVERT(VARCHAR,r.id_detalle_rec) + '-' + CONVERT(VARCHAR,r.id_rollo_rec)) AS consecutivo_rec, " &
                                " (CONVERT(VARCHAR,r.cod_orden_tref) +'-' + CONVERT(VARCHAR,r.id_detalle_tref) + '-' + CONVERT(VARCHAR,r.id_rollo_tref)) AS consecutivo_tref, " &
                                " s.mat_prima,d.descripcion AS mp,s.prod_final,d2.descripcion AS pf,r.peso,r.traccion_rec,r.colada,f.fecha_cierre as fecha_carga " &
                        " FROM JB_rollos_rec r, JB_orden_prod_rec_refs s,CORSAN.dbo.referencias d,CORSAN.dbo.referencias d2,JB_orden_prod_rec_detalle f,JB_orden_prod_rec g " &
                            " WHERE	(r.cod_orden_rec = s.cod_orden AND r.id_prof_final = s.num AND d.codigo = s.mat_prima AND s.prod_final = d2.codigo AND r.cod_orden_rec = f.cod_orden AND r.id_detalle_rec = f.id_detalle and r.cod_orden_rec=g.cod_orden) " &
                                " and f.fecha_cierre >= '" & fecIni & "' AND f.fecha_cierre <= '" & fecFin & "' " & horno & ""

                If txt_codigo.Text <> "" Then
                    sql &= " And s.prod_final Like '" & txt_codigo.Text & "%'"
                End If
                sql &= " ORDER BY r.cod_orden_rec DESC, r.id_detalle_rec , r.id_rollo_rec "
            End If
            If rdb_reco.Checked Then
                sql = "SELECT	(CONVERT(VARCHAR,r.cod_orden_rec) +'-' + CONVERT(VARCHAR,r.id_detalle_rec) + '-' + CONVERT(VARCHAR,r.id_rollo_rec)) AS consecutivo_rec, " &
                                " (CONVERT(VARCHAR,r.cod_orden_tref) +'-' + CONVERT(VARCHAR,r.id_detalle_tref) + '-' + CONVERT(VARCHAR,r.id_rollo_tref)) AS consecutivo_tref, " &
                                " s.mat_prima,d.descripcion AS mp,s.prod_final,d2.descripcion AS pf,r.peso,r.traccion_rec,r.colada " &
                        " FROM JB_rollos_rec r, JB_orden_prod_rec_refs s,CORSAN.dbo.referencias d,CORSAN.dbo.referencias d2,JB_orden_prod_rec_detalle f " &
                            " WHERE	(r.cod_orden_rec = s.cod_orden AND r.id_prof_final = s.num AND d.codigo = s.mat_prima AND s.prod_final = d2.codigo AND r.cod_orden_rec = f.cod_orden AND r.id_detalle_rec = f.id_detalle) " &
                                " AND r.trans IS NULL AND r.tipo_trans IS NULL AND f.estado = 1 "

                If txt_codigo.Text <> "" Then
                    sql &= " AND s.prod_final like '" & txt_codigo.Text & "%'"
                End If
                sql &= " ORDER BY r.cod_orden_rec DESC, r.id_detalle_rec , r.id_rollo_rec "
            End If
            If rdb_term.Checked Then
                sql = "SELECT	(CONVERT(VARCHAR,r.cod_orden_rec) +'-' + CONVERT(VARCHAR,r.id_detalle_rec) + '-' + CONVERT(VARCHAR,r.id_rollo_rec)) AS consecutivo_rec, " &
                                " (CONVERT(VARCHAR,r.cod_orden_tref) +'-' + CONVERT(VARCHAR,r.id_detalle_tref) + '-' + CONVERT(VARCHAR,r.id_rollo_tref)) AS consecutivo_tref, " &
                                " s.mat_prima,d.descripcion AS mp,s.prod_final,d2.descripcion AS pf,r.peso,r.traccion_rec,r.colada,f.fecha_cierre as fecha_carga  " &
                        " FROM JB_rollos_rec r, JB_orden_prod_rec_refs s,CORSAN.dbo.referencias d,CORSAN.dbo.referencias d2,JB_orden_prod_rec_detalle f,CORSAN.dbo.documentos doc,JB_orden_prod_rec g" &
                            " WHERE	(r.trans = doc.numero AND r.cod_orden_rec = s.cod_orden AND r.id_prof_final = s.num AND d.codigo = s.mat_prima AND s.prod_final = d2.codigo AND r.cod_orden_rec = f.cod_orden AND r.id_detalle_rec = f.id_detalle and r.cod_orden_rec=g.cod_orden) " &
                                " AND r.trans IS NOT NULL AND r.tipo_trans IS NOT NULL AND f.estado = 4 AND r.tipo_trans = 'EPPT' AND f.fecha_fin >= '" & fecIni & "' AND f.fecha_fin <= '" & fecFin & "'" & horno & ""

                If txt_codigo.Text <> "" Then
                    sql &= " And s.prod_final Like '" & txt_codigo.Text & "%'"
                End If
                sql &= " ORDER BY doc.fecha"
            End If
            If rdb_proc.Checked Then
                sql = "SELECT	(CONVERT(VARCHAR,r.cod_orden_rec) +'-' + CONVERT(VARCHAR,r.id_detalle_rec) + '-' + CONVERT(VARCHAR,r.id_rollo_rec)) AS consecutivo_rec, " &
                                " (CONVERT(VARCHAR,r.cod_orden_tref) +'-' + CONVERT(VARCHAR,r.id_detalle_tref) + '-' + CONVERT(VARCHAR,r.id_rollo_tref)) AS consecutivo_tref, " &
                                " s.mat_prima,d.descripcion AS mp,s.prod_final,d2.descripcion AS pf,r.peso,r.traccion_rec,r.colada,f.fecha_cierre as fecha_carga  " &
                        " FROM JB_rollos_rec r, JB_orden_prod_rec_refs s,CORSAN.dbo.referencias d,CORSAN.dbo.referencias d2,JB_orden_prod_rec_detalle f,CORSAN.dbo.documentos doc,JB_orden_prod_rec g " &
                            " WHERE	(r.trans = doc.numero AND r.cod_orden_rec = s.cod_orden AND r.id_prof_final = s.num AND d.codigo = s.mat_prima AND s.prod_final = d2.codigo AND r.cod_orden_rec = f.cod_orden AND r.id_detalle_rec = f.id_detalle and r.cod_orden_rec=g.cod_orden) " &
                                " AND r.trans IS NOT NULL AND r.tipo_trans IS NOT NULL AND f.estado = 4 AND r.tipo_trans = 'EPPP' AND f.fecha_fin >= '" & fecIni & "' AND f.fecha_fin <= '" & fecFin & "'" & horno & ""

                If txt_codigo.Text <> "" Then
                    sql &= " And s.prod_final Like '" & txt_codigo.Text & "%'"
                End If
            End If
            If rdb_noconforme.Checked Then
                sql = "select cod_orden_rec,id_detalle_rec,id_rollo_rec,(select codigo from CORSAN.dbo.documentos_lin where numero=eipp) as codigo,peso from jb_rollos_rec where no_conforme='S'"
                If txt_codigo.Text <> "" Then
                    sql &= " AND s.prod_final like '" & txt_codigo.Text & "%'"
                End If

            End If
        Else
            If rdb_sin_r.Checked Then
                sql = "SELECT O.prod_final,d.descripcion,SUM(r.peso) AS peso " &
                        " FROM J_ROLLOS_TREF r, j_orden_prod_tef o,CORSAN.dbo.referencias d " &
                            " WHERE (r.cod_orden = o.consecutivo AND o.prod_final = d.codigo) " &
                                " AND DESTINO = 'R' AND traslado IS NOT NULL AND SREC IS NULL AND ANULADO IS NULL " &
                                    "GROUP BY O.prod_final,D.descripcion"
            End If
            If rdb_rec.Checked Then
                sql = "SELECT	s.prod_final,d2.descripcion,sum(r.peso) AS peso " &
                        " FROM JB_rollos_rec r, JB_orden_prod_rec_refs s,CORSAN.dbo.referencias d,CORSAN.dbo.referencias d2,JB_orden_prod_rec_detalle f " &
                            " WHERE	(r.cod_orden_rec = s.cod_orden AND r.id_prof_final = s.num AND d.codigo = s.mat_prima AND s.prod_final = d2.codigo AND r.cod_orden_rec = f.cod_orden AND r.id_detalle_rec = f.id_detalle) " &
                                "  f.fecha_cierre >= '" & fecIni & "' AND f.fecha_cierre <= '" & fecFin & "'" &
                                    " GROUP BY s.prod_final,d2.descripcion"
            End If
            If rdb_reco.Checked Then
                sql = "SELECT	s.prod_final,d2.descripcion,sum(r.peso) AS peso " &
                        " FROM JB_rollos_rec r, JB_orden_prod_rec_refs s,CORSAN.dbo.referencias d,CORSAN.dbo.referencias d2,JB_orden_prod_rec_detalle f " &
                            " WHERE	(r.cod_orden_rec = s.cod_orden AND r.id_prof_final = s.num AND d.codigo = s.mat_prima AND s.prod_final = d2.codigo AND r.cod_orden_rec = f.cod_orden AND r.id_detalle_rec = f.id_detalle) " &
                                " AND r.trans IS NULL AND r.tipo_trans IS NULL AND f.estado = 1 " &
                                    " GROUP BY s.prod_final,d2.descripcion"
            End If
            If rdb_term.Checked Then
                sql = "SELECT	s.prod_final,d2.descripcion,sum(r.peso) AS peso " &
                        " FROM JB_rollos_rec r, JB_orden_prod_rec_refs s,CORSAN.dbo.referencias d,CORSAN.dbo.referencias d2,JB_orden_prod_rec_detalle f,CORSAN.dbo.documentos doc " &
                            " WHERE	(r.trans = doc.numero AND r.cod_orden_rec = s.cod_orden AND r.id_prof_final = s.num AND d.codigo = s.mat_prima AND s.prod_final = d2.codigo AND r.cod_orden_rec = f.cod_orden AND r.id_detalle_rec = f.id_detalle) " &
                                " AND r.trans IS NOT NULL AND r.tipo_trans IS NOT NULL AND f.estado = 4 AND doc.tipo = 'EPPT' AND f.fecha_fin >= '" & fecIni & "' AND f.fecha_fin <= '" & fecFin & "'" &
                                    " GROUP BY s.prod_final,d2.descripcion"
            End If
            If rdb_proc.Checked Then
                sql = "SELECT	s.prod_final,d2.descripcion,sum(r.peso) AS peso " &
                        " FROM JB_rollos_rec r, JB_orden_prod_rec_refs s,CORSAN.dbo.referencias d,CORSAN.dbo.referencias d2,JB_orden_prod_rec_detalle f,CORSAN.dbo.documentos doc " &
                            " WHERE	(r.trans = doc.numero AND r.cod_orden_rec = s.cod_orden AND r.id_prof_final = s.num AND d.codigo = s.mat_prima AND s.prod_final = d2.codigo AND r.cod_orden_rec = f.cod_orden AND r.id_detalle_rec = f.id_detalle) " &
                                " AND r.trans IS NOT NULL AND r.tipo_trans IS NOT NULL AND f.estado = 4 AND doc.tipo = 'EPPP' AND f.fecha_fin >= '" & fecIni & "' AND f.fecha_fin <= '" & fecFin & "'" &
                                    " GROUP BY s.prod_final,d2.descripcion"
            End If
            If rdb_noconforme.Checked Then
                sql = "select c.prod_final,sum(r.peso) as peso from jb_rollos_rec r join JB_orden_prod_rec_refs c on r.id_prof_final=c.num  where no_conforme='S' and r.scae is null and r.consu_noconfor is null GROUP BY c.prod_final "
            End If
        End If
        consulta = Replace(sql, vbTab, "")
        dt = objOpSimplesLn.listar_datatable(consulta, "PRODUCCION")
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
            End If
            If dt.Columns(j).ColumnName = "descripcion" Or dt.Columns(j).ColumnName = "pf" Then
                dt.Rows(dt.Rows.Count - 1).Item(j) = "TOTAL"
            End If
        Next
        dtg_consulta.DataSource = dt
        dtg_consulta.Columns("peso").DefaultCellStyle.Format = "N1"
        If chk_consolidar.Checked = False Then
            If rdb_proc.Checked = True Or rdb_term.Checked = True Or rdb_rec.Checked = True Then
                dtg_consulta.Columns("fecha_carga").DefaultCellStyle.Format = "dd/MM/yyyy"
            End If
        End If
        dtg_consulta.Rows(dtg_consulta.Rows.Count - 1).DefaultCellStyle = objOperacionesForm.formatoNegrita(14)

        pintar()

    End Sub
    Private Sub pintar()
        For i = 0 To dtg_consulta.RowCount - 1
            If rdb_sin_r.Checked Then
                dtg_consulta.Rows(i).DefaultCellStyle.BackColor = Color.Orchid
            End If
            If rdb_rec.Checked Then
                dtg_consulta.Rows(i).DefaultCellStyle.BackColor = Color.Gold
            End If
            If rdb_term.Checked Then
                dtg_consulta.Rows(i).DefaultCellStyle.BackColor = Color.Green
            End If
            If rdb_proc.Checked Then
                dtg_consulta.Rows(i).DefaultCellStyle.BackColor = Color.Aqua
            End If
        Next
    End Sub

    Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
        Application.DoEvents()
        dtg_consulta.DataSource = Nothing
        consultar()
    End Sub
    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        Me.UseWaitCursor = True
        Application.DoEvents()
        objOperacionesForm.exportarExcel(dtg_consulta)
        Me.UseWaitCursor = False
    End Sub
    Private Sub chk_consolidar_CheckedChanged(sender As Object, e As EventArgs) Handles chk_consolidar.CheckedChanged
        If chk_consolidar.Checked Then
            txt_codigo.Text = ""
            txt_codigo.Enabled = False
        Else
            txt_codigo.Enabled = True
        End If
    End Sub
    Private Sub frm_auditoria_recocido_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim sql As String = ""
        Dim dt As New DataTable
        cbo_fecha_in.Value = Now.AddDays(-1)
        cbo_fecha_fin.Value = Now.Date

        Sql = "SELECT codigoM,Descripción  FROM J_Maquinas WHERE TipoMaquina = '13' "
        dt = objOpSimplesLn.listar_datatable(Sql, "PRODUCCION")
        dt.Rows.Add()
        dt.Rows(dt.Rows.Count - 1).Item("codigoM") = 0
        dt.Rows(dt.Rows.Count - 1).Item("Descripción") = "Seleccione"
        cbo_horno.DataSource = dt
        cbo_horno.ValueMember = "codigoM"
        cbo_horno.DisplayMember = "Descripción"
        cbo_horno.SelectedValue = 0
    End Sub
End Class