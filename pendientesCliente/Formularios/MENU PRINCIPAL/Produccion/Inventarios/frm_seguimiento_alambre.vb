Imports logicaNegocios
Imports entidadNegocios
Public Class frm_seguimiento_alambre
    Dim usuario As UsuarioEn
    Private objOpsimpesLn As New Op_simpesLn
    Private objOperacionesForm As OperacionesFormularios = New OperacionesFormularios
    Dim db_corsan As String = ""

    Public Sub main(ByVal usuario As UsuarioEn)
        Me.usuario = usuario
        If usuario.permiso.Trim = "ADMIN" Or usuario.permiso.Trim = "DIR_PRODUCCION" Or usuario.permiso.Trim = "COORD_PRODUCCION" Then
            chk_consolidar.Checked = True
            chk_consolidar.Enabled = True
            col_tiq.Visible = True
        Else
            col_tiq.Visible = False
            chk_consolidar.Checked = False
            chk_consolidar.Enabled = True
        End If
        db_corsan = objOpsimpesLn.get_nom_db("CORSAN") & ".dbo."
    End Sub

    Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
        dtg_alambre.DataSource = Nothing
        cargar_datos()
    End Sub

    Private Sub cargar_datos()
        img_procesar.Visible = True
        Dim dtg As New DataTable
        Dim tamano_letra As Single = 9.0
        Dim sql As String = "SELECT r.cod_orden,r.id_detalle,r.id_rollo,o.prod_final,t.descripcion,r.peso,r.fecha_hora,r.traslado,d.fecha " &
                                " FROM J_rollos_tref r, J_orden_prod_tef o, CORSAN.dbo.referencias t," & db_corsan & "documentos d " &
                                    " WHERE (r.cod_orden = o.consecutivo AND o.prod_final = t.codigo AND r.traslado=d.numero) AND r.anulado IS NULL  AND d.tipo='TRB1'"
        If chk_consolidar.Checked Then
            sql = "SELECT o.prod_final,t.descripcion,sum(r.peso) AS peso " &
                    " FROM J_rollos_tref r, J_orden_prod_tef o, CORSAN.dbo.referencias t," & db_corsan & "documentos d " &
                        " WHERE (r.cod_orden = o.consecutivo AND o.prod_final = t.codigo AND r.traslado=d.numero) AND r.anulado IS NULL  AND d.tipo='TRB1' "
        End If

        Dim whereSql As String = ""
        If chk_bod11.Checked Then
            whereSql &= " AND r.traslado IS NOT NULL AND r.destino = 'G' AND r.saga IS NULL "
        End If
        If chk_bod12.Checked Then
            whereSql &= " AND r.traslado IS NOT NULL AND r.destino = 'P' AND r.scla IS NULL "

            Dim sqlp As String = "SELECT r.nro_orden, r.consecutivo_rollo,o.final_galv,r.peso,t.descripcion,r.traslado,d.fecha " &
                                    " FROM D_rollo_galvanizado_f r, D_orden_pro_galv_enc o,CORSAN.dbo.referencias t,CORSAN.dbo.documentos d " &
                                        " WHERE (r.nro_orden = o.consecutivo_orden_G AND o.final_galv = t.codigo AND r.traslado=d.numero) AND d.tipo='TRB1' AND o.final_galv LIKE '2%' " &
                                            " AND r.destino = 'P' AND saga IS NULL ORDER BY O.final_galv"
            If chk_consolidar.Checked Then
                sqlp = "SELECT o.final_galv,sum(r.peso) AS peso,t.descripcion " &
                        " FROM D_rollo_galvanizado_f r, D_orden_pro_galv_enc o,CORSAN.dbo.referencias t,CORSAN.dbo.documentos d " &
                            " WHERE (r.nro_orden = o.consecutivo_orden_G AND o.final_galv = t.codigo AND r.traslado=d.numero) AND d.tipo='TRB1' AND o.final_galv LIKE '2%' " &
                                " AND r.destino = 'P' AND saga IS NULL AND no_conforme IS NULL AND anular IS NULL " &
                                    " GROUP BY o.final_galv, t.descripcion"
            End If
            dtg = objOpsimpesLn.listar_datatable(sqlp, "PRODUCCION")
        End If
        If chk_bod13.Checked Then
            whereSql &= " AND r.traslado IS NOT NULL AND r.destino = 'R' AND r.srec IS NULL"
        End If
        If txt_codigo.Text <> "" Then
            whereSql &= " AND o.prod_final like '" & txt_codigo.Text & "%'"
        End If

        If chk_consolidar.Checked Then
            whereSql &= " GROUP BY o.prod_final, t.descripcion"
        Else
            whereSql &= " ORDER BY d.fecha"
        End If

        sql &= whereSql

        If chk_bod2.Checked Then
            'sql = "SELECT r.orden_prod_rec, r.id_detalle, r.id_rollo_rec, o.prod_final, c.descripcion, r.peso, r.trans " & _
            '        " FROM J_orden_prod_rec_rollo r, J_orden_prod_rec o, CORSAN.dbo.referencias c " & _
            '            " WHERE (r.orden_prod_rec = o.consecutivo AND o.prod_final = c.codigo) " & _
            '                " AND r.tipo_trans = 'EPPP' AND r.destino = 'TR' AND r.scae IS NULL"


            whereSql = ""
            sql = "SELECT r.cod_orden,r.id_detalle,r.id_rollo,o.prod_final,t.descripcion,r.peso,r.fecha_hora " &
                                    " FROM J_rollos_tref r, J_orden_prod_tef o,J_det_orden_prod d, CORSAN.dbo.referencias t" &
                                        " WHERE (r.cod_orden = o.consecutivo AND o.prod_final = t.codigo and d.cod_orden=r.cod_orden and d.id_detalle=r.id_detalle) AND r.anulado IS NULL and r.destino is null and r.traslado is null and r.scae is null and r.scal is null and d.transaccion_entrada is not null"
            If txt_codigo.Text <> "" Then
                whereSql &= " AND o.prod_final like '" & txt_codigo.Text & "%'"
            End If
            sql &= whereSql
        End If

        If chk_puas.Checked Then
            sql = "SELECT r.nro_orden, r.consecutivo_rollo,o.final_galv,r.peso,t.descripcion,r.traslado,d.fecha " &
                                  " FROM D_rollo_galvanizado_f r, D_orden_pro_galv_enc o,CORSAN.dbo.referencias t,CORSAN.dbo.documentos d " &
                                      " WHERE (r.nro_orden = o.consecutivo_orden_G AND o.final_galv = t.codigo AND r.traslado=d.numero) AND d.tipo='TRB1' AND o.final_galv LIKE '2%' " &
                                          " AND r.destino = 'A' AND saga IS NULL ORDER BY O.final_galv"
            If chk_consolidar.Checked Then
                sql = "SELECT o.final_galv,sum(r.peso) AS peso,t.descripcion " &
                        " FROM D_rollo_galvanizado_f r, D_orden_pro_galv_enc o,CORSAN.dbo.referencias t,CORSAN.dbo.documentos d " &
                            " WHERE (r.nro_orden = o.consecutivo_orden_G AND o.final_galv = t.codigo AND r.traslado=d.numero) AND d.tipo='TRB1' AND o.final_galv LIKE '2%' " &
                                " AND r.destino = 'A' AND saga IS NULL AND no_conforme IS NULL AND anular IS NULL " &
                                    " GROUP BY o.final_galv, t.descripcion"
            End If
        End If
        If chk_noconforme.Checked Then
            whereSql = ""
            sql = "SELECT r.cod_orden,r.id_detalle,r.id_rollo,o.prod_final,t.descripcion,r.peso,r.fecha_hora,r.traslado " &
                                    " FROM J_rollos_tref r, J_orden_prod_tef o,J_det_orden_prod d, CORSAN.dbo.referencias t" &
                                        " WHERE (r.cod_orden = o.consecutivo AND o.prod_final = t.codigo and d.cod_orden=r.cod_orden and d.id_detalle=r.id_detalle) AND r.anulado IS NULL and r.destino is null and r.traslado is null and r.scae is null and r.scal is null and r.no_conforme is not null"
            If txt_codigo.Text <> "" Then
                whereSql &= " AND o.prod_final like '" & txt_codigo.Text & "%'"
            End If
            If chk_consolidar.Checked Then
                sql = "SELECT o.prod_final,t.descripcion,sum(r.peso) as peso" &
                            " FROM J_rollos_tref r, J_orden_prod_tef o,J_det_orden_prod d, CORSAN.dbo.referencias t" &
                                " WHERE (r.cod_orden = o.consecutivo AND o.prod_final = t.codigo and d.cod_orden=r.cod_orden and d.id_detalle=r.id_detalle) AND r.anulado IS NULL and r.destino is null and r.traslado is null and r.scae is null and r.scal is null and r.no_conforme is not null"
                whereSql &= " GROUP BY o.prod_final, t.descripcion"
            End If
            sql &= whereSql
        End If

        Dim dt As DataTable = objOpsimpesLn.listar_datatable(sql, "PRODUCCION")

        If chk_bod12.Checked Then
            For i = 0 To dtg.Rows.Count - 1
                dt.Rows.Add()
                dt.Rows(dt.Rows.Count - 1).Item("prod_final") = dtg.Rows(i).Item("final_galv")
                dt.Rows(dt.Rows.Count - 1).Item("peso") = dtg.Rows(i).Item("peso")
                dt.Rows(dt.Rows.Count - 1).Item("descripcion") = dtg.Rows(i).Item("descripcion")
                If chk_consolidar.Checked = False Then
                    dt.Rows(dt.Rows.Count - 1).Item("cod_orden") = dtg.Rows(i).Item("nro_orden")
                    dt.Rows(dt.Rows.Count - 1).Item("id_rollo") = dtg.Rows(i).Item("consecutivo_rollo")
                    dt.Rows(dt.Rows.Count - 1).Item("traslado") = dtg.Rows(i).Item("traslado")
                    dt.Rows(dt.Rows.Count - 1).Item("fecha") = dtg.Rows(i).Item("fecha")
                End If
            Next
        End If

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
        Next
        dtg_alambre.DataSource = dt
        If chk_consolidar.Checked Then
            dtg_alambre.Columns("col_tiq").Visible = False
        Else
            dtg_alambre.Columns("col_tiq").Visible = True
            If usuario.permiso.Trim = "ADMIN" Or usuario.permiso.Trim = "DIR_PRODUCCION" Then
                dtg_alambre.Columns("cod_orden").Visible = True
                dtg_alambre.Columns("id_detalle").Visible = True
                dtg_alambre.Columns("id_rollo").Visible = True
                dtg_alambre.Columns("col_tiq").Visible = True
            Else
                dtg_alambre.Columns("cod_orden").Visible = False
                dtg_alambre.Columns("id_detalle").Visible = False
                dtg_alambre.Columns("id_rollo").Visible = False
                dtg_alambre.Columns("col_tiq").Visible = False
            End If
        End If


        dtg_alambre.CurrentCell = Nothing
        dtg_alambre.Rows(dtg_alambre.Rows.Count - 1).DefaultCellStyle = objOperacionesForm.formatoNegrita(tamano_letra)
        dtg_alambre.Columns("peso").DefaultCellStyle.Format = "N1"

        pintar_dtg()
        img_procesar.Visible = False
    End Sub

    Private Sub pintar_dtg()
        For i = 0 To dtg_alambre.Rows.Count - 2
            If chk_bod2.Checked = True Then
                dtg_alambre.Rows(i).DefaultCellStyle.BackColor = Color.LimeGreen
            End If
            If chk_bod11.Checked = True Then
                dtg_alambre.Rows(i).DefaultCellStyle.BackColor = Color.Violet
            End If
            If chk_bod12.Checked = True Then
                dtg_alambre.Rows(i).DefaultCellStyle.BackColor = Color.Gold
            End If
            If chk_bod13.Checked = True Then
                dtg_alambre.Rows(i).DefaultCellStyle.BackColor = Color.Tomato
            End If
            If chk_puas.Checked Then
                dtg_alambre.Rows(i).DefaultCellStyle.BackColor = Color.DarkGray
            End If
            If chk_noconforme.Checked Then
                dtg_alambre.Rows(i).DefaultCellStyle.BackColor = Color.Turquoise
            End If
        Next
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        Me.UseWaitCursor = True
        Application.DoEvents()
        objOperacionesForm.exportarExcel(dtg_alambre)
        Me.UseWaitCursor = False
    End Sub

    Private Sub dtg_alambre_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtg_alambre.CellClick
        Dim col As String = dtg_alambre.Columns(e.ColumnIndex).Name
        Dim fila As Integer = e.RowIndex
        Dim sql As String = ""
        If (col = col_tiq.Name) Then
            If (MessageBox.Show("Desea Imprimir copia de el tiquete?", "Generar Copia?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) = 6) Then
                Dim ref As String = dtg_alambre.Item("prod_final", e.RowIndex).Value
                If ref.ToUpper Like "22B*" Or ref.ToUpper Like "22X*" Then
                    Dim cod_orden As String = dtg_alambre.Item("cod_orden", e.RowIndex).Value
                    Dim id_detalle As String = dtg_alambre.Item("id_detalle", e.RowIndex).Value
                    Dim id_rollo As String = dtg_alambre.Item("id_rollo", e.RowIndex).Value

                    Dim operario As String = ""
                    Dim clase As Integer = 0
                    Dim diametro As Double = 0
                    Dim mat_prima As String = ""
                    Dim colada As String = ""
                    Dim traccion As Integer = 0
                    Dim peso As Double = 0
                    Dim destino As String = ""
                    Dim fec As DateTime = Now
                    Dim fecha As String = fec

                    sql = "select r.peso,r.colada,r.traccion, o.materia_prima, o.diam_min,o.calidad,t.nombres,v.nombres as operario " &
                            " from j_rollos_tref r, J_orden_prod_tef o,CORSAN.dbo.terceros t, J_det_orden_prod d, CORSAN.dbo.V_nom_personal_Activo_con_maquila v " &
                                " where (r.cod_orden = o.consecutivo AND o.nit =  t.nit AND r.cod_orden = d.cod_orden AND r.id_detalle = d.id_detalle AND d.operario = v.nit) " &
                                " AND r.cod_orden = " & cod_orden & " and r.id_detalle = " & id_detalle & " and r.id_rollo = " & id_rollo
                    Dim dt As DataTable = objOpsimpesLn.listar_datatable(sql, "PRODUCCION")

                    For i = 0 To dt.Rows.Count - 1
                        operario = dt.Rows(i).Item("operario")
                        clase = dt.Rows(i).Item("calidad")
                        diametro = dt.Rows(i).Item("diam_min")
                        mat_prima = dt.Rows(i).Item("materia_prima")
                        colada = dt.Rows(i).Item("colada")
                        traccion = dt.Rows(i).Item("traccion")
                        peso = Format(dt.Rows(i).Item("peso"), "#0.0")
                        destino = "Interno (COPIA)"
                    Next
                    imprimirTiquete_brillante(peso, id_rollo, diametro, clase, operario, fecha, ref, destino, colada, mat_prima, traccion, cod_orden, id_detalle)
                End If
                If ref.ToUpper Like "22G*" Then

                End If
                If ref.ToUpper Like "22R*" Then

                End If
            End If
        End If
    End Sub

    Private Sub imprimirTiquete_brillante(ByVal peso As String, ByVal numRollo As Integer, ByVal calibre As String, ByVal calidad As Double, ByVal nombOperario As String, ByVal fecha As String, ByVal producto As String, ByVal destino As String, ByVal colada As String, ByVal cod_mat_prima As String, ByVal traccion As String, ByVal cod_orden As String, ByVal id_detalle As String)
        Dim proc As New Process
        modificarPlantilla_brillante(nombOperario, calidad, calibre, peso, fecha, producto, numRollo, destino, colada, cod_mat_prima, traccion, cod_orden, id_detalle)
        proc.StartInfo.FileName = Environment.CurrentDirectory & "\nuevaPlantilla.txt"
        proc.StartInfo.Verb = "Print"
        proc.StartInfo.CreateNoWindow = False
        proc.Start()
    End Sub
    Private Sub modificarPlantilla_brillante(ByVal operario As String, ByVal clase As String, ByVal calibre As String, ByVal peso As String, ByVal fec As String, ByVal producto As String, ByVal numRollo As Integer, ByVal destino As String, ByVal colada As String, ByVal cod_mat_prima As String, ByVal traccion As String, ByVal cod_orden As String, ByVal id_detalle As String)
        Dim fic As String = Environment.CurrentDirectory & "\plantilla.txt"
        Dim nuevoFic As String = Environment.CurrentDirectory & "\nuevaPlantilla.txt"
        Dim sw As New System.IO.StreamWriter(nuevoFic)
        Dim texto As String
        Dim sr As New System.IO.StreamReader(fic)
        Dim codOrden As String = cod_orden & "-" & id_detalle & "-" & numRollo
        texto = sr.ReadToEnd()
        texto = Replace(texto, "@Operario", operario)
        texto = Replace(texto, "@Clase", clase)
        texto = Replace(texto, "@Calibre", calibre)
        texto = Replace(texto, "@Peso", peso & " (Kg)")
        texto = Replace(texto, "@Fecha", fec)
        texto = Replace(texto, "@Orden", codOrden)
        texto = Replace(texto, "@CodigoBarras", codOrden)
        texto = Replace(texto, "@Ref", producto)
        texto = Replace(texto, "@destino", destino)
        texto = Replace(texto, "@colada", colada)
        texto = Replace(texto, "@matPrima", cod_mat_prima)
        texto = Replace(texto, "@traccion", traccion)

        sr.Close()
        sw.WriteLine(texto)
        sw.Close()

    End Sub
End Class