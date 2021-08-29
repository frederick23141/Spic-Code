Imports logicaNegocios
Imports entidadNegocios
Public Class frm_control_inv_aud
    Private objOpSimplesLn As New Op_simpesLn
    Private objOperacionesForm As OperacionesFormularios = New OperacionesFormularios
    Private objOrdenProdLn As New OrdenProdLn
    Dim objTraslado_bodLn As New traslado_bodLn
    Dim numero_transaccion As Double
    Private obj_Ing_prodLn As New Ing_prodLn

    Private Sub frm_control_inv_aud_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargar_inv()
    End Sub

    Public Sub main(ByVal usuario As UsuarioEn)
        If usuario.permiso.Trim <> "ADMIN" Then
            col_tras.Visible = False
        Else
            col_tras.Visible = True
        End If
    End Sub
    Private Sub cargar_inv()
        Dim sql As String = "SELECT id,bodega,operario,fec_ini,fec_fin,estado FROM JB_control_inventario WHERE fec_fin IS NOT NULL"
        dtg_inv.DataSource = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")
        dtg_inv.Columns("estado").Visible = False
        For i = 0 To dtg_inv.RowCount - 1
            If Not IsDBNull(dtg_inv.Item("estado", i).Value) Then
                dtg_inv.Rows(i).DefaultCellStyle.BackColor = Color.Coral
            End If
        Next
    End Sub
    Private Sub dtg_inv_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtg_inv.CellClick
        Dim sql, val As String
        Dim col As String = dtg_inv.Columns(e.ColumnIndex).Name
        Dim fila As Integer = e.RowIndex
        If (col = col_ver.Name) Then
            dtg_consolidado.DataSource = Nothing
            dtg_fisico.DataSource = Nothing
            dtg_sistema.DataSource = Nothing
            If dtg_inv.Item("bodega", e.RowIndex).Value = 1 Or dtg_inv.Item("bodega", e.RowIndex).Value = 2 Then
                consolidar_alamb(dtg_inv.Item("bodega", e.RowIndex).Value, dtg_inv.Item("id", e.RowIndex).Value)
            ElseIf dtg_inv.Item("bodega", e.RowIndex).Value = 7 Then
                sql = "select top(1) tipo from JB_control_inventario_rollos where id_inv=" & dtg_inv.Item("id", e.RowIndex).Value & ""
                val = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")
                cargar_cons_bodega7(dtg_inv.Item("id", e.RowIndex).Value, dtg_inv.Item("bodega", e.RowIndex).Value, val)
            Else
                cargar_cons(dtg_inv.Item("id", e.RowIndex).Value, dtg_inv.Item("bodega", e.RowIndex).Value)
            End If
#Disable Warning BC42104 ' La variable 'val' se usa antes de que se le haya asignado un valor. Podría darse una excepción de referencia NULL en tiempo de ejecución.
            cargar_sistema(dtg_inv.Item("bodega", e.RowIndex).Value, dtg_inv.Item("id", e.RowIndex).Value, val)
#Enable Warning BC42104 ' La variable 'val' se usa antes de que se le haya asignado un valor. Podría darse una excepción de referencia NULL en tiempo de ejecución.
            cargar_fisico(dtg_inv.Item("bodega", e.RowIndex).Value, dtg_inv.Item("id", e.RowIndex).Value, val)
        End If
        If col = col_tras.Name Then
            Dim respTemrinar As String = MessageBox.Show("¿Desea cuadrar los Inventarios? ", "¿Cuadrar Inventario?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
            If respTemrinar = "6" Then
                If IsDBNull(dtg_inv.Item("estado", e.RowIndex).Value) Then
                    transaccion_d(dtg_inv.Item("id", e.RowIndex).Value, dtg_inv.Item("bodega", e.RowIndex).Value)
                Else
                    MessageBox.Show("El inventario ya ha sido cuadrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End If
        End If
    End Sub
    Private Sub transaccion_d(ByVal id_inv As Integer, ByVal bodega As Integer)
        Dim sql As String = ""
        Dim tipo As String = ""
        Dim dt As New DataTable
        Dim listSql As New List(Of Object)

        Dim db_produccion As String = objOpSimplesLn.get_nom_db("PRODUCCION") & ".dbo."
        Dim peso As Double = 0
        Dim stock As Double = 0
        Dim val_stock As Integer = 0
        Dim val_stock2 As Integer = 0
        Dim ref As String = ""

        If bodega = 11 Then
            tipo = "SAGA"
        ElseIf bodega = 12 Then
            tipo = "SCLA"
        ElseIf bodega = 13 Then
            tipo = "SREC"
        ElseIf bodega = 14 Then
            tipo = "SPU"
        End If
        If bodega = 11 Or bodega = 12 Or bodega = 13 Then
            sql = "SELECT s.prod_final AS codigo,sum(d.peso) AS cantidad " & _
                " FROM JB_control_inventario_rollos r,J_rollos_tref d,j_orden_prod_tef s, CORSAN.dbo.referencias a " & _
                " WHERE (r.cod_orden = d.cod_orden AND r.id_detalle = d.id_detalle AND r.id_rollo = d.id_rollo AND r.cod_orden = s.consecutivo AND s.prod_final = a.codigo) " & _
                " AND r.id_inv = " & id_inv & " AND r.estado = 0 AND r.tipo='B' GROUP BY s.prod_final,a.descripcion"
            dt = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")
            For i = 0 To dt.Rows.Count - 1
                stock = objOpSimplesLn.consultarStock(dt.Rows(i).Item("codigo"), bodega)
                peso = dt.Rows(i).Item("cantidad") - 0.2
                dt.Rows(i).Item("cantidad") = peso
                If peso <= stock Then
                    val_stock += 1
                Else
                    ref &= dt.Rows(i).Item("codigo") & "-"
                End If
                val_stock2 += 1
            Next
            If val_stock <> 0 Or val_stock2 <> 0 Then
                If val_stock = val_stock2 Then
                    listSql.AddRange(transaccion(dt, tipo, bodega, "01"))
                    sql = "UPDATE " & db_produccion & "JB_control_inventario SET estado = 1 WHERE id = " & id_inv
                    listSql.Add(sql)
                    sql = " SELECT cod_orden,id_detalle,id_rollo " & _
                                " FROM JB_control_inventario_rollos  " & _
                                    " WHERE estado = 0 AND tipo = 'B' AND id_inv = " & id_inv
                    dt = New DataTable
                    dt = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")
                    For i = 0 To dt.Rows.Count - 1
                        sql = "UPDATE " & db_produccion & "j_rollos_tref SET " & tipo & " = '" & numero_transaccion & "' WHERE cod_orden = " & dt.Rows(i).Item("cod_orden") & " AND id_detalle = " & dt.Rows(i).Item("id_detalle") & " AND id_rollo = " & dt.Rows(i).Item("id_rollo")
                        listSql.Add(sql)
                    Next
                Else
                    MessageBox.Show("No hay Stock disponible en las referencias:" & ref, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End If
        End If
        If bodega = 12 Or bodega = 14 Then
            val_stock = 0
            val_stock2 = 0
            ref = ""
            sql = "SELECT sum(d.peso) AS cantidad, o.final_galv AS codigo " & _
                        " FROM JB_control_inventario_rollos r, D_rollo_galvanizado_f d,D_orden_pro_galv_enc o, CORSAN.dbo.referencias t " & _
                            " WHERE (r.cod_orden = d.nro_orden AND r.id_rollo = d.consecutivo_rollo AND r.cod_orden = o.consecutivo_orden_G AND o.final_galv = t.codigo) " & _
                            " AND r.id_inv = " & id_inv & " AND r.tipo = 'G' AND r.estado = 0 GROUP BY o.final_galv,t.descripcion"
            dt = New DataTable
            dt = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")
            For i = 0 To dt.Rows.Count - 1
                stock = objOpSimplesLn.consultarStock(dt.Rows(i).Item("codigo"), bodega)
                peso = dt.Rows(i).Item("cantidad") - 0.2
                dt.Rows(i).Item("cantidad") = peso
                If peso <= stock Then
                    val_stock += 1
                Else
                    ref &= dt.Rows(i).Item("codigo") & "-"
                End If
                val_stock2 += 1
            Next
            If val_stock <> 0 Or val_stock2 <> 0 Then
                If val_stock = val_stock2 Then
                    listSql.AddRange(transaccion(dt, tipo, bodega, "01"))
                    sql = "UPDATE " & db_produccion & "JB_control_inventario SET estado = 1 WHERE id = " & id_inv
                    listSql.Add(sql)
                    sql = " SELECT cod_orden,id_rollo " & _
                                " FROM JB_control_inventario_rollos  " & _
                                    " WHERE estado = 0 and tipo = 'G' AND id_inv = " & id_inv
                    dt = New DataTable
                    dt = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")
                    For i = 0 To dt.Rows.Count - 1
                        sql = "UPDATE " & db_produccion & "D_rollo_galvanizado_f SET saga = '" & numero_transaccion & "' WHERE nro_orden = " & dt.Rows(i).Item("cod_orden") & " AND consecutivo_rollo = " & dt.Rows(i).Item("id_rollo")
                        listSql.Add(sql)
                    Next
                Else
                    MessageBox.Show("No hay Stock disponible en las referencias:" & ref, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End If
        End If
        If obj_Ing_prodLn.ExecuteSqlTransaction(listSql, "CORSAN") Then
            MessageBox.Show("El cuadre de inventario se realizo con exito.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cargar_inv()
        Else
            MessageBox.Show("Error al realizar el cuadre de inventario, comuniquese con el administrador del sistema.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Private Function transaccion(ByVal datacodigo As DataTable, ByVal tipo As String, ByVal bodega As Integer, ByVal modelo As String) As List(Of Object)
        Dim listSql As New List(Of Object)
        Dim dFec As Date = Now
        Dim notas As String = "SPIC fecha:" & Now & " Ajuste Auditoria"
        numero_transaccion = objOrdenProdLn.mover_consecutivo(tipo)
        listSql = objTraslado_bodLn.listaTransaccionDatable(numero_transaccion, datacodigo, bodega, dFec, notas, "Auditoria", tipo, modelo)
        Return listSql
    End Function
    Private Sub cargar_cons_bodega7(ByVal id_inv As Integer, ByVal bodega As Integer, tipo As String)
        Dim dt As New DataTable
        Dim sql As String = ""
        Dim sum As Double = 0
        Dim dt_sis As DataTable
        Dim dt_fis As DataTable
        If tipo = "T" Then
            sql = "SELECT s.prod_final,a.descripcion,sum(d.peso) AS total " & _
               " FROM JB_control_inventario_rollos r,J_rollos_tref d,j_orden_prod_tef s, CORSAN.dbo.referencias a " & _
               " WHERE (r.cod_orden = d.cod_orden AND r.id_detalle = d.id_detalle AND r.id_rollo = d.id_rollo AND r.cod_orden = s.consecutivo AND s.prod_final = a.codigo) " & _
               " AND r.id_inv = " & id_inv & " AND r.tipo='T' GROUP BY s.prod_final,a.descripcion"
            dt = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")

            sql = "SELECT s.prod_final,a.descripcion,sum(d.peso) AS sistema " & _
                " FROM JB_control_inventario_rollos r,J_rollos_tref d,j_orden_prod_tef s, CORSAN.dbo.referencias a " & _
                " WHERE (r.cod_orden = d.cod_orden AND r.id_detalle = d.id_detalle AND r.id_rollo = d.id_rollo AND r.cod_orden = s.consecutivo AND s.prod_final = a.codigo) " & _
                " AND r.id_inv = " & id_inv & " AND r.estado = 0 AND r.tipo='T' GROUP BY s.prod_final,a.descripcion"
            dt_sis = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")
            sql = "SELECT s.prod_final,a.descripcion,sum(d.peso) AS fisico " & _
                " FROM JB_control_inventario_rollos r,J_rollos_tref d,j_orden_prod_tef s, CORSAN.dbo.referencias a " & _
                " WHERE (r.cod_orden = d.cod_orden AND r.id_detalle = d.id_detalle AND r.id_rollo = d.id_rollo AND r.cod_orden = s.consecutivo AND s.prod_final = a.codigo) " & _
                " AND r.id_inv = " & id_inv & " AND r.estado = 1 AND r.tipo='T' GROUP BY s.prod_final,a.descripcion"
            dt_fis = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")
        ElseIf tipo = "E" Then
            sql = "SELECT s.prod_final,a.descripcion,sum(d.peso) AS total " & _
               " FROM JB_control_inventario_rollos r,J_rollos_tref d,j_orden_prod_tef s, CORSAN.dbo.referencias a " & _
                " WHERE (r.cod_orden = d.cod_orden AND r.id_detalle = d.id_detalle AND r.id_rollo = d.id_rollo AND r.cod_orden = s.consecutivo AND s.prod_final = a.codigo) " & _
            " AND r.id_inv = " & id_inv & " AND r.tipo='E' GROUP BY s.prod_final,a.descripcion"
            dt = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")

            sql = "SELECT s.prod_final,a.descripcion,sum(d.peso) AS sistema " & _
                " FROM JB_control_inventario_rollos r,J_rollos_tref d,j_orden_prod_tef s, CORSAN.dbo.referencias a " & _
                " WHERE (r.cod_orden = d.cod_orden AND r.id_detalle = d.id_detalle AND r.id_rollo = d.id_rollo AND r.cod_orden = s.consecutivo AND s.prod_final = a.codigo) " & _
                " AND r.id_inv = " & id_inv & " AND r.estado = 0 AND r.tipo='E' GROUP BY s.prod_final,a.descripcion"
            dt_sis = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")
            sql = "SELECT s.prod_final,a.descripcion,sum(d.peso) AS fisico " & _
                " FROM JB_control_inventario_rollos r,J_rollos_tref d,j_orden_prod_tef s, CORSAN.dbo.referencias a " & _
                " WHERE (r.cod_orden = d.cod_orden AND r.id_detalle = d.id_detalle AND r.id_rollo = d.id_rollo AND r.cod_orden = s.consecutivo AND s.prod_final = a.codigo) " & _
                " AND r.id_inv = " & id_inv & " AND r.estado = 1 AND r.tipo='E' GROUP BY s.prod_final,a.descripcion"
            dt_fis = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")
        ElseIf tipo = "R" Then
            sql = "SELECT (select prod_final from JB_orden_prod_rec_refs where num=d.id_prof_final) as prod_final ,a.descripcion,sum(d.peso) AS total " & _
                  " FROM JB_control_inventario_rollos r,JB_rollos_rec d,JB_orden_prod_rec s,JB_orden_prod_rec_refs j, CORSAN.dbo.referencias a " & _
                  " WHERE (r.cod_orden = d.cod_orden_tref AND r.id_detalle = d.id_detalle_tref AND r.id_rollo = d.id_rollo_tref AND r.cod_orden = s.consecutivo AND s.prod_final = a.codigo) " & _
                  " AND r.id_inv = " & id_inv & " AND r.tipo='R' GROUP BY prod_final,a.descripcion"
            dt = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")
            sql = "SELECT (select prod_final from JB_orden_prod_rec_refs where num=d.id_prof_final) as prod_final,a.descripcion,sum(d.peso) AS sistema " & _
                " FROM JB_control_inventario_rollos r,JB_rollos_rec d,JB_orden_prod_rec s,JB_orden_prod_rec_refs j, CORSAN.dbo.referencias a " & _
                " WHERE (r.cod_orden = d.cod_orden_tref AND r.id_detalle = d.id_detalle_tref AND r.id_rollo = d.id_rollo_tref AND r.cod_orden = s.consecutivo AND s.prod_final = a.codigo) " & _
                " AND r.id_inv = " & id_inv & " AND r.estado = 0 AND r.tipo='R' GROUP BY s.prod_final,a.descripcion"
            dt_sis = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")
            sql = "SELECT (select prod_final from JB_orden_prod_rec_refs where num=d.id_prof_final) as prod_final,a.descripcion,sum(d.peso) AS fisico " & _
                " FROM JB_control_inventario_rollos r,JB_rollos_rec d,JB_orden_prod_rec s,JB_orden_prod_rec_refs j, CORSAN.dbo.referencias a " & _
                " WHERE (r.cod_orden = d.cod_orden_tref AND r.id_detalle = d.id_detalle_tref AND r.id_rollo = d.id_rollo_tref AND r.cod_orden = s.consecutivo AND s.prod_final = a.codigo) " & _
                " AND r.id_inv = " & id_inv & " AND r.estado = 1 AND r.tipo='R' GROUP BY prod_final,a.descripcion"
            dt_fis = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")
        End If
        
        dt.Columns.Add("sistema", GetType(Double))
#Disable Warning BC42104 ' La variable 'dt_sis' se usa antes de que se le haya asignado un valor. Podría darse una excepción de referencia NULL en tiempo de ejecución.
        For i = 0 To dt_sis.Rows.Count - 1
#Enable Warning BC42104 ' La variable 'dt_sis' se usa antes de que se le haya asignado un valor. Podría darse una excepción de referencia NULL en tiempo de ejecución.
            For j = 0 To dt.Rows.Count - 1
                Dim val1 As String = dt_sis.Rows(i).Item("prod_final")
                Dim val2 As String = dt.Rows(j).Item("prod_final")
                If val1.ToUpper = val2.ToUpper Then
                    dt.Rows(j).Item("sistema") = dt_sis.Rows(i).Item("sistema")
                End If
            Next
        Next
        dt.Columns.Add("fisico", GetType(Double))
#Disable Warning BC42104 ' La variable 'dt_fis' se usa antes de que se le haya asignado un valor. Podría darse una excepción de referencia NULL en tiempo de ejecución.
        For i = 0 To dt_fis.Rows.Count - 1
#Enable Warning BC42104 ' La variable 'dt_fis' se usa antes de que se le haya asignado un valor. Podría darse una excepción de referencia NULL en tiempo de ejecución.
            For j = 0 To dt.Rows.Count - 1
                Dim val1 As String = dt_fis.Rows(i).Item("prod_final")
                Dim val2 As String = dt.Rows(j).Item("prod_final")
                If val1.ToUpper = val2.ToUpper Then
                    dt.Rows(j).Item("fisico") = dt_fis.Rows(i).Item("fisico")
                End If
            Next
        Next
        totalizar_dt(dt, 2)
        dtg_consolidado.DataSource = dt
        dtg_consolidado.Columns("total").DefaultCellStyle.Format = "N1"
        dtg_consolidado.Columns("fisico").DefaultCellStyle.Format = "N1"
        dtg_consolidado.Columns("fisico").DefaultCellStyle.NullValue = "0"
        dtg_consolidado.Columns("sistema").DefaultCellStyle.Format = "N1"
        dtg_consolidado.Columns("sistema").DefaultCellStyle.NullValue = "0"
        dtg_consolidado.Rows(dtg_consolidado.Rows.Count - 1).DefaultCellStyle = objOperacionesForm.formatoNegrita(9)
    End Sub
    Private Sub cargar_cons(ByVal id_inv As Integer, ByVal bodega As Integer)
        Dim dt As New DataTable
        Dim sql As String = ""
        Dim sum As Double = 0

        If bodega = 11 Or bodega = 13 Or bodega = 12 Then
            sql = "SELECT s.prod_final,a.descripcion,sum(d.peso) AS total " & _
                   " FROM JB_control_inventario_rollos r,J_rollos_tref d,j_orden_prod_tef s, CORSAN.dbo.referencias a " & _
                   " WHERE (r.cod_orden = d.cod_orden AND r.id_detalle = d.id_detalle AND r.id_rollo = d.id_rollo AND r.cod_orden = s.consecutivo AND s.prod_final = a.codigo) " & _
                   " AND r.id_inv = " & id_inv & " AND r.tipo='B' GROUP BY s.prod_final,a.descripcion"
            dt = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")
            sql = "SELECT s.prod_final,a.descripcion,sum(d.peso) AS sistema " & _
                " FROM JB_control_inventario_rollos r,J_rollos_tref d,j_orden_prod_tef s, CORSAN.dbo.referencias a " & _
                " WHERE (r.cod_orden = d.cod_orden AND r.id_detalle = d.id_detalle AND r.id_rollo = d.id_rollo AND r.cod_orden = s.consecutivo AND s.prod_final = a.codigo) " & _
                " AND r.id_inv = " & id_inv & " AND r.estado = 0 AND r.tipo='B' GROUP BY s.prod_final,a.descripcion"
            Dim dt_sis As DataTable = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")
            sql = "SELECT s.prod_final,a.descripcion,sum(d.peso) AS fisico " & _
                " FROM JB_control_inventario_rollos r,J_rollos_tref d,j_orden_prod_tef s, CORSAN.dbo.referencias a " & _
                " WHERE (r.cod_orden = d.cod_orden AND r.id_detalle = d.id_detalle AND r.id_rollo = d.id_rollo AND r.cod_orden = s.consecutivo AND s.prod_final = a.codigo) " & _
                " AND r.id_inv = " & id_inv & " AND r.estado = 1 AND r.tipo='B' GROUP BY s.prod_final,a.descripcion"
            Dim dt_fis As DataTable = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")
            dt.Columns.Add("sistema", GetType(Double))
            For i = 0 To dt_sis.Rows.Count - 1
                For j = 0 To dt.Rows.Count - 1
                    Dim val1 As String = dt_sis.Rows(i).Item("prod_final")
                    Dim val2 As String = dt.Rows(j).Item("prod_final")
                    If val1.ToUpper = val2.ToUpper Then
                        dt.Rows(j).Item("sistema") = dt_sis.Rows(i).Item("sistema")
                    End If
                Next
            Next
            dt.Columns.Add("fisico", GetType(Double))
            For i = 0 To dt_fis.Rows.Count - 1
                For j = 0 To dt.Rows.Count - 1
                    Dim val1 As String = dt_fis.Rows(i).Item("prod_final")
                    Dim val2 As String = dt.Rows(j).Item("prod_final")
                    If val1.ToUpper = val2.ToUpper Then
                        dt.Rows(j).Item("fisico") = dt_fis.Rows(i).Item("fisico")
                    End If
                Next
            Next
        End If

        If bodega = 12 Or bodega = 14 Then
            consolidar_galv(dt, bodega, id_inv)
        End If
   
        totalizar_dt(dt, 2)
        dtg_consolidado.DataSource = dt
        dtg_consolidado.Columns("total").DefaultCellStyle.Format = "N1"
        dtg_consolidado.Columns("fisico").DefaultCellStyle.Format = "N1"
        dtg_consolidado.Columns("fisico").DefaultCellStyle.NullValue = "0"
        dtg_consolidado.Columns("sistema").DefaultCellStyle.Format = "N1"
        dtg_consolidado.Columns("sistema").DefaultCellStyle.NullValue = "0"
        dtg_consolidado.Rows(dtg_consolidado.Rows.Count - 1).DefaultCellStyle = objOperacionesForm.formatoNegrita(9)
    End Sub
    Private Function consolidar_galv(ByRef dt As DataTable, ByVal bodega As Integer, ByVal id_inv As Integer)
        Dim sql As String = "SELECT sum(d.peso) AS total, o.final_galv AS prod_final,t.descripcion " & _
                                " FROM JB_control_inventario_rollos r, D_rollo_galvanizado_f d,D_orden_pro_galv_enc o, CORSAN.dbo.referencias t " & _
                                    " WHERE (r.cod_orden = d.nro_orden AND r.id_rollo = d.consecutivo_rollo AND r.cod_orden = o.consecutivo_orden_G AND o.final_galv = t.codigo) " & _
                                    " AND r.id_inv = " & id_inv & " AND r.tipo = 'G' GROUP BY o.final_galv,t.descripcion"
        Dim dt1 As DataTable = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")
        sql = "SELECT sum(d.peso) AS sistema, o.final_galv AS prod_final,t.descripcion " & _
                        " FROM JB_control_inventario_rollos r, D_rollo_galvanizado_f d,D_orden_pro_galv_enc o, CORSAN.dbo.referencias t " & _
                            " WHERE (r.cod_orden = d.nro_orden AND r.id_rollo = d.consecutivo_rollo AND r.cod_orden = o.consecutivo_orden_G AND o.final_galv = t.codigo) " & _
                            " AND r.id_inv = " & id_inv & " AND r.tipo = 'G' AND r.estado = 0 GROUP BY o.final_galv,t.descripcion"
        Dim dt2 As DataTable = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")
        sql = "SELECT sum(d.peso) AS fisico, o.final_galv AS prod_final,t.descripcion " & _
                   " FROM JB_control_inventario_rollos r, D_rollo_galvanizado_f d,D_orden_pro_galv_enc o, CORSAN.dbo.referencias t " & _
                       " WHERE (r.cod_orden = d.nro_orden AND r.id_rollo = d.consecutivo_rollo AND r.cod_orden = o.consecutivo_orden_G AND o.final_galv = t.codigo) " & _
                       " AND r.id_inv = " & id_inv & " AND r.tipo = 'G' AND r.estado = 1 GROUP BY o.final_galv,t.descripcion"
        Dim dt3 As DataTable = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")

        dt1.Columns.Add("sistema", GetType(Double))
        For i = 0 To dt2.Rows.Count - 1
            For j = 0 To dt1.Rows.Count - 1
                Dim val1 As String = dt2.Rows(i).Item("prod_final")
                Dim val2 As String = dt1.Rows(j).Item("prod_final")
                If val1.ToUpper = val2.ToUpper Then
                    dt1.Rows(j).Item("sistema") = dt2.Rows(i).Item("sistema")
                End If
            Next
        Next
        dt1.Columns.Add("fisico", GetType(Double))
        For i = 0 To dt3.Rows.Count - 1
            For j = 0 To dt1.Rows.Count - 1
                Dim val1 As String = dt3.Rows(i).Item("prod_final")
                Dim val2 As String = dt1.Rows(j).Item("prod_final")
                If val1.ToUpper = val2.ToUpper Then
                    dt1.Rows(j).Item("fisico") = dt3.Rows(i).Item("fisico")
                End If
            Next
        Next
        If bodega = 12 Then
            For i = 0 To dt1.Rows.Count - 1
                dt.Rows.Add()
                dt.Rows(dt.Rows.Count - 1).Item("fisico") = dt1.Rows(i).Item("fisico")
                dt.Rows(dt.Rows.Count - 1).Item("sistema") = dt1.Rows(i).Item("sistema")
                dt.Rows(dt.Rows.Count - 1).Item("total") = dt1.Rows(i).Item("total")
                dt.Rows(dt.Rows.Count - 1).Item("descripcion") = dt1.Rows(i).Item("descripcion")
                dt.Rows(dt.Rows.Count - 1).Item("prod_final") = dt1.Rows(i).Item("prod_final")
            Next
        Else
            dt = dt1
        End If
        Return dt
    End Function
    'Consolidar alambron
    Private Sub consolidar_alamb(ByVal bodega As Integer, ByVal id_inv As Integer)
        Dim dt As New DataTable
        Dim sql As String = "select  d.codigo,sum(r.peso) AS total " & _
                  "  from J_alambron_solicitud_det d INNER JOIN J_alambron_importacion_det_rollos r ON " & _
                  " d.nit_proveedor=r.nit_proveedor and d.num_importacion=r.num_importacion and d.id_det=r.id_solicitud_det inner join " & _
                  " JB_control_inventario_alambron a on  r.nit_proveedor=a.nit_proveedor and r.num_importacion=a.num_importacion and r.id_solicitud_det=a.id_solicitud_det and r.numero_rollo=a.numero_rollo " & _
                  " where a.id_inv = " & id_inv & " group by d.codigo"
        Dim dt1 As DataTable = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")
        sql = "select d.codigo,sum(r.peso) AS sistema " & _
                  "  from J_alambron_solicitud_det d INNER JOIN J_alambron_importacion_det_rollos r ON " & _
                  " d.nit_proveedor=r.nit_proveedor and d.num_importacion=r.num_importacion and d.id_det=r.id_solicitud_det inner join " & _
                  " JB_control_inventario_alambron a on  r.nit_proveedor=a.nit_proveedor and r.num_importacion=a.num_importacion and r.id_solicitud_det=a.id_solicitud_det and r.numero_rollo=a.numero_rollo " & _
                  " where a.estado = 0 AND a.id_inv = " & id_inv & " group by d.codigo"
        Dim dt2 As DataTable = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")
        sql = "select d.codigo,sum(r.peso) AS fisico " & _
                  "  from J_alambron_solicitud_det d INNER JOIN J_alambron_importacion_det_rollos r ON " & _
                  " d.nit_proveedor=r.nit_proveedor and d.num_importacion=r.num_importacion and d.id_det=r.id_solicitud_det inner join " & _
                  " JB_control_inventario_alambron a on  r.nit_proveedor=a.nit_proveedor and r.num_importacion=a.num_importacion and r.id_solicitud_det=a.id_solicitud_det and r.numero_rollo=a.numero_rollo " & _
                  " where a.estado = 1 AND a.id_inv = " & id_inv & " group by d.codigo"
        Dim dt3 As DataTable = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")

        dt1.Columns.Add("sistema", GetType(Double))
        For i = 0 To dt2.Rows.Count - 1
            For j = 0 To dt1.Rows.Count - 1
                Dim val1 As String = dt2.Rows(i).Item("codigo")
                Dim val2 As String = dt1.Rows(j).Item("codigo")
                If val1.ToUpper = val2.ToUpper Then
                    dt1.Rows(j).Item("sistema") = dt2.Rows(i).Item("sistema")
                End If
            Next
        Next
        dt1.Columns.Add("fisico", GetType(Double))
        For i = 0 To dt3.Rows.Count - 1
            For j = 0 To dt1.Rows.Count - 1
                Dim val1 As String = dt3.Rows(i).Item("codigo")
                Dim val2 As String = dt1.Rows(j).Item("codigo")
                If val1.ToUpper = val2.ToUpper Then
                    dt1.Rows(j).Item("fisico") = dt3.Rows(i).Item("fisico")
                End If
            Next
        Next
        dt = dt1
        totalizar_dt(dt, 4)
        dtg_consolidado.DataSource = dt
        dtg_consolidado.Columns("total").DefaultCellStyle.Format = "N1"
        dtg_consolidado.Columns("fisico").DefaultCellStyle.Format = "N1"
        dtg_consolidado.Columns("fisico").DefaultCellStyle.NullValue = "0"
        dtg_consolidado.Columns("sistema").DefaultCellStyle.Format = "N1"
        dtg_consolidado.Columns("sistema").DefaultCellStyle.NullValue = "0"
        dtg_consolidado.Rows(dtg_consolidado.Rows.Count - 1).DefaultCellStyle = objOperacionesForm.formatoNegrita(9)
    End Sub
    Private Function totalizar_dt(ByRef dt As DataTable, ByVal tipo As Integer)
        Dim sum As Double = 0
        dt.Rows.Add()
        If tipo = 1 Then
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
        End If
        If tipo = 2 Then
            sum = 0
            For j = 0 To dt.Columns.Count - 1
                If dt.Columns(j).ColumnName = "total" Then
                    For i = 0 To dt.Rows.Count - 1
                        If Not IsDBNull(dt.Rows(i).Item(j)) Then
                            sum += dt.Rows(i).Item(j)
                        End If
                    Next
                    dt.Rows(dt.Rows.Count - 1).Item(j) = sum
                    sum = 0
                End If
            Next
            For j = 0 To dt.Columns.Count - 1
                If dt.Columns(j).ColumnName = "sistema" Then
                    For i = 0 To dt.Rows.Count - 1
                        If Not IsDBNull(dt.Rows(i).Item(j)) Then
                            sum += dt.Rows(i).Item(j)
                        End If
                    Next
                    dt.Rows(dt.Rows.Count - 1).Item(j) = sum
                    sum = 0
                End If
            Next
            For j = 0 To dt.Columns.Count - 1
                If dt.Columns(j).ColumnName = "fisico" Then
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
        End If
        If tipo = 3 Then
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
                If dt.Columns(j).ColumnName = "codigo" Then
                    dt.Rows(dt.Rows.Count - 1).Item(j) = "TOTAL"
                End If
            Next
        End If
        If tipo = 4 Then
            sum = 0
            For j = 0 To dt.Columns.Count - 1
                If dt.Columns(j).ColumnName = "total" Then
                    For i = 0 To dt.Rows.Count - 1
                        If Not IsDBNull(dt.Rows(i).Item(j)) Then
                            sum += dt.Rows(i).Item(j)
                        End If
                    Next
                    dt.Rows(dt.Rows.Count - 1).Item(j) = sum
                    sum = 0
                End If
            Next
            For j = 0 To dt.Columns.Count - 1
                If dt.Columns(j).ColumnName = "sistema" Then
                    For i = 0 To dt.Rows.Count - 1
                        If Not IsDBNull(dt.Rows(i).Item(j)) Then
                            sum += dt.Rows(i).Item(j)
                        End If
                    Next
                    dt.Rows(dt.Rows.Count - 1).Item(j) = sum
                    sum = 0
                End If
            Next
            For j = 0 To dt.Columns.Count - 1
                If dt.Columns(j).ColumnName = "fisico" Then
                    For i = 0 To dt.Rows.Count - 1
                        If Not IsDBNull(dt.Rows(i).Item(j)) Then
                            sum += dt.Rows(i).Item(j)
                        End If
                    Next
                    dt.Rows(dt.Rows.Count - 1).Item(j) = sum
                    sum = 0
                End If
                If dt.Columns(j).ColumnName = "codigo" Then
                    dt.Rows(dt.Rows.Count - 1).Item(j) = "TOTAL"
                End If
            Next
        End If
        Return dt
    End Function
    Private Sub cargar_sistema(ByVal bodega As Integer, ByVal id_inv As Integer, ByVal tipo As String)
        Dim dt As New DataTable
        Dim dt2 As New DataTable
        Dim sql As String = ""
        If bodega = 11 Or bodega = 12 Or bodega = 13 Then
            sql = "SELECT (CONVERT(VARCHAR,r.cod_orden) +'-' + CONVERT(VARCHAR,r.id_detalle) + '-' + CONVERT(VARCHAR,r.id_rollo)) AS consecutivo " & _
                                        ",s.prod_final,a.descripcion,d.peso " & _
                                " FROM JB_control_inventario_rollos r,J_rollos_tref d,j_orden_prod_tef s, CORSAN.dbo.referencias a " & _
                                " WHERE (r.cod_orden = d.cod_orden AND r.id_detalle = d.id_detalle AND r.id_rollo = d.id_rollo AND r.cod_orden = s.consecutivo AND s.prod_final = a.codigo) " & _
                                        " AND r.estado = 0 AND r.tipo = 'B' AND r.id_inv =" & id_inv
            dt = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")
        End If
        If bodega = 7 Then
            sql = "select top(1) tipo from JB_control_inventario_rollos where id_inv=" & id_inv & ""
            Dim tipos As String = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")
            If tipos = "T" Then
                sql = "SELECT (CONVERT(VARCHAR,r.cod_orden) +'-' + CONVERT(VARCHAR,r.id_detalle) + '-' + CONVERT(VARCHAR,r.id_rollo)) AS consecutivo " & _
                                            ",s.prod_final,a.descripcion,d.peso " & _
                                    " FROM JB_control_inventario_rollos r,J_rollos_tref d,j_orden_prod_tef s, CORSAN.dbo.referencias a " & _
                                    " WHERE (r.cod_orden = d.cod_orden AND r.id_detalle = d.id_detalle AND r.id_rollo = d.id_rollo AND r.cod_orden = s.consecutivo AND s.prod_final = a.codigo) " & _
                                            " AND r.estado = 0 AND r.tipo = '" & tipos & "' AND r.id_inv =" & id_inv
            ElseIf tipos = "E" Then
                sql = "SELECT (CONVERT(VARCHAR,r.cod_orden) +'-' + CONVERT(VARCHAR,r.id_detalle) + '-' + CONVERT(VARCHAR,r.id_rollo)) AS consecutivo " & _
                                            ",s.prod_final,a.descripcion,d.peso " & _
                                    " FROM JB_control_inventario_rollos r,J_rollos_tref d,j_orden_prod_tef s, CORSAN.dbo.referencias a " & _
                                    " WHERE (r.cod_orden = d.cod_orden AND r.id_detalle = d.id_detalle AND r.id_rollo = d.id_rollo AND r.cod_orden = s.consecutivo AND s.prod_final = a.codigo) " & _
                                            " AND r.estado = 0 AND r.tipo = '" & tipos & "' AND r.id_inv =" & id_inv
            ElseIf tipos = "R" Then
                sql = "SELECT (CONVERT(VARCHAR,r.cod_orden) +'-' + CONVERT(VARCHAR,r.id_detalle) + '-' + CONVERT(VARCHAR,r.id_rollo)) AS consecutivo " & _
                   ",s.prod_final,a.descripcion,d.peso " & _
                   " FROM JB_control_inventario_rollos r,JB_rollos_rec d,JB_orden_prod_rec s, CORSAN.dbo.referencias a " & _
                   " WHERE (r.cod_orden = d.cod_orden AND r.id_detalle = d.id_detalle AND r.id_rollo = d.id_rollo AND r.cod_orden = s.cod_orden AND s.prod_final = a.codigo) " & _
                   " AND r.estado = 0 AND r.tipo = '" & tipos & "' AND r.id_inv =" & id_inv
            End If
            dt = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")
        End If
        If bodega = 12 Or bodega = 14 Then
            sql = "SELECT (CONVERT(VARCHAR,r.cod_orden) +'-' + CONVERT(VARCHAR,r.id_rollo)) AS consecutivo ,s.final_galv,a.descripcion,d.peso " & _
                        " FROM JB_control_inventario_rollos r, D_rollo_galvanizado_f d, D_orden_pro_galv_enc s, CORSAN.dbo.referencias a " & _
                            " WHERE (r.cod_orden = d.nro_orden AND r.id_rollo = d.consecutivo_rollo AND r.cod_orden = s.consecutivo_orden_G AND s.final_galv = a.codigo) " & _
                            " AND r.estado = 0 AND r.tipo = 'G' AND r.id_inv = " & id_inv
            dt2 = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")
        End If
        If bodega = 1 Or bodega = 2 Then
            sql = "select  (CONVERT(VARCHAR,a.nit_proveedor) +'-' + CONVERT(VARCHAR,a.num_importacion)+'-' + CONVERT(VARCHAR,a.id_solicitud_det) +'-' + CONVERT(VARCHAR,a.numero_rollo)) AS consecutivo,d.codigo,r.peso" & _
                  "  from J_alambron_solicitud_det d INNER JOIN J_alambron_importacion_det_rollos r ON " & _
                  " d.nit_proveedor=r.nit_proveedor and d.num_importacion=r.num_importacion and d.id_det=r.id_solicitud_det inner join " & _
                  " JB_control_inventario_alambron a on  r.nit_proveedor=a.nit_proveedor and r.num_importacion=a.num_importacion and r.id_solicitud_det=a.id_solicitud_det and r.numero_rollo=a.numero_rollo " & _
                  " where a.estado = 0 AND a.id_inv = " & id_inv
            dt = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")
        End If
        If bodega = 12 Then
            For i = 0 To dt2.Rows.Count - 1
                dt.Rows.Add()
                dt.Rows(dt.Rows.Count - 1).Item("consecutivo") = dt2.Rows(i).Item("consecutivo")
                dt.Rows(dt.Rows.Count - 1).Item("prod_final") = dt2.Rows(i).Item("final_galv")
                dt.Rows(dt.Rows.Count - 1).Item("peso") = dt2.Rows(i).Item("peso")
                dt.Rows(dt.Rows.Count - 1).Item("descripcion") = dt2.Rows(i).Item("descripcion")
            Next
        End If
        If bodega <> 1 And bodega <> 2 Then
            totalizar_dt(dt, 1)
        Else
            totalizar_dt(dt, 3)
        End If

        dtg_sistema.DataSource = dt
        dtg_sistema.Columns("peso").DefaultCellStyle.Format = "N1"
        dtg_sistema.Rows(dtg_sistema.Rows.Count - 1).DefaultCellStyle = objOperacionesForm.formatoNegrita(9)
    End Sub
    Private Sub cargar_fisico(ByVal bodega As Integer, ByVal id_inv As Integer, ByVal tipo As String)
        Dim sql As String = ""
        Dim dt As New DataTable
        Dim dt2 As New DataTable
        If bodega = 11 Or bodega = 12 Or bodega = 13 Then
            sql = "SELECT (CONVERT(VARCHAR,r.cod_orden) +'-' + CONVERT(VARCHAR,r.id_detalle) + '-' + CONVERT(VARCHAR,r.id_rollo)) AS consecutivo " & _
                                ",s.prod_final,a.descripcion,d.peso " & _
                        " FROM JB_control_inventario_rollos r,J_rollos_tref d,j_orden_prod_tef s, CORSAN.dbo.referencias a " & _
                        " WHERE (r.cod_orden = d.cod_orden AND r.id_detalle = d.id_detalle AND r.id_rollo = d.id_rollo AND r.cod_orden = s.consecutivo AND s.prod_final = a.codigo) " & _
                                " AND r.estado = 1 AND r.tipo = 'B' AND r.id_inv =" & id_inv
            dt = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")
        End If
        If bodega = 7 Then
            sql = "select top(1) tipo from JB_control_inventario_rollos where id_inv=" & id_inv & ""
            Dim tipos As String = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")
            If tipos = "T" Then
                sql = "SELECT (CONVERT(VARCHAR,r.cod_orden) +'-' + CONVERT(VARCHAR,r.id_detalle) + '-' + CONVERT(VARCHAR,r.id_rollo)) AS consecutivo " & _
                         ",s.prod_final,a.descripcion,d.peso " & _
                 " FROM JB_control_inventario_rollos r,J_rollos_tref d,j_orden_prod_tef s, CORSAN.dbo.referencias a " & _
                 " WHERE (r.cod_orden = d.cod_orden AND r.id_detalle = d.id_detalle AND r.id_rollo = d.id_rollo AND r.cod_orden = s.consecutivo AND s.prod_final = a.codigo) " & _
                         " AND r.estado = 1 AND r.tipo = '" & tipos & "' AND r.id_inv =" & id_inv
            ElseIf tipos = "E" Then
                sql = "SELECT (CONVERT(VARCHAR,r.cod_orden) +'-' + CONVERT(VARCHAR,r.id_detalle) + '-' + CONVERT(VARCHAR,r.id_rollo)) AS consecutivo " & _
                      ",s.prod_final,a.descripcion,d.peso " & _
              " FROM JB_control_inventario_rollos r,J_rollos_tref d,j_orden_prod_tef s, CORSAN.dbo.referencias a " & _
              " WHERE (r.cod_orden = d.cod_orden AND r.id_detalle = d.id_detalle AND r.id_rollo = d.id_rollo AND r.cod_orden = s.consecutivo AND s.prod_final = a.codigo) " & _
                      " AND r.estado = 1 AND r.tipo = '" & tipos & "' AND r.id_inv =" & id_inv
            ElseIf tipo = "R" Then
                sql = "SELECT (CONVERT(VARCHAR,r.cod_orden) +'-' + CONVERT(VARCHAR,r.id_detalle) + '-' + CONVERT(VARCHAR,r.id_rollo)) AS consecutivo " & _
                         ",s.prod_final,a.descripcion,d.peso " & _
                 " FROM JB_control_inventario_rollos r,JB_rollos_rec d,JB_orden_prod_rec s, CORSAN.dbo.referencias a " & _
                 " WHERE (r.cod_orden = d.cod_orden AND r.id_detalle = d.id_detalle AND r.id_rollo = d.id_rollo AND r.cod_orden = s.cod_orden AND s.prod_final = a.codigo) " & _
                         " AND r.estado = 1 AND r.tipo = '" & tipos & "' AND r.id_inv =" & id_inv
            End If
            dt = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")
        End If
        If bodega = 12 Or bodega = 14 Then
            sql = "SELECT (CONVERT(VARCHAR,r.cod_orden) +'-' + CONVERT(VARCHAR,r.id_rollo)) AS consecutivo ,s.final_galv,a.descripcion,d.peso " & _
                        " FROM JB_control_inventario_rollos r, D_rollo_galvanizado_f d, D_orden_pro_galv_enc s, CORSAN.dbo.referencias a " & _
                            " WHERE (r.cod_orden = d.nro_orden AND r.id_rollo = d.consecutivo_rollo AND r.cod_orden = s.consecutivo_orden_G AND s.final_galv = a.codigo) " & _
                            " AND r.estado = 1 AND r.tipo = 'G' AND r.id_inv = " & id_inv
            dt2 = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")
        End If
        If bodega = 1 Or bodega = 2 Then
            sql = "select  (CONVERT(VARCHAR,a.nit_proveedor) +'-' + CONVERT(VARCHAR,a.num_importacion)+'-' + CONVERT(VARCHAR,a.id_solicitud_det) +'-' + CONVERT(VARCHAR,a.numero_rollo)) AS consecutivo,d.codigo,r.peso" & _
                  "  from J_alambron_solicitud_det d INNER JOIN J_alambron_importacion_det_rollos r ON " & _
                  " d.nit_proveedor=r.nit_proveedor and d.num_importacion=r.num_importacion and d.id_det=r.id_solicitud_det inner join " & _
                  " JB_control_inventario_alambron a on  r.nit_proveedor=a.nit_proveedor and r.num_importacion=a.num_importacion and r.id_solicitud_det=a.id_solicitud_det and r.numero_rollo=a.numero_rollo " & _
                  " where a.estado = 1 AND a.id_inv = " & id_inv
            dt = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")
        End If
        If bodega = 12 Then
            For i = 0 To dt2.Rows.Count - 1
                dt.Rows.Add()
                dt.Rows(dt.Rows.Count - 1).Item("consecutivo") = dt2.Rows(i).Item("consecutivo")
                dt.Rows(dt.Rows.Count - 1).Item("prod_final") = dt2.Rows(i).Item("final_galv")
                dt.Rows(dt.Rows.Count - 1).Item("peso") = dt2.Rows(i).Item("peso")
                dt.Rows(dt.Rows.Count - 1).Item("descripcion") = dt2.Rows(i).Item("descripcion")
            Next
        End If
        If bodega <> 1 And bodega <> 2 Then
            totalizar_dt(dt, 1)
        Else
            totalizar_dt(dt, 3)
        End If
        dtg_fisico.DataSource = dt
        dtg_fisico.Columns("peso").DefaultCellStyle.Format = "N1"
        dtg_fisico.Rows(dtg_fisico.Rows.Count - 1).DefaultCellStyle = objOperacionesForm.formatoNegrita(9)
    End Sub

    Private Sub FisicoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FisicoToolStripMenuItem.Click
        Me.UseWaitCursor = True
        Application.DoEvents()
        objOperacionesForm.exportarExcel(dtg_fisico)
        Me.UseWaitCursor = False
    End Sub

    Private Sub SistemaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SistemaToolStripMenuItem.Click
        Me.UseWaitCursor = True
        Application.DoEvents()
        objOperacionesForm.exportarExcel(dtg_sistema)
        Me.UseWaitCursor = False
    End Sub

    Private Sub ConsolidadoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConsolidadoToolStripMenuItem.Click
        Me.UseWaitCursor = True
        Application.DoEvents()
        objOperacionesForm.exportarExcel(dtg_consolidado)
        Me.UseWaitCursor = False
    End Sub
End Class