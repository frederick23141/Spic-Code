Imports logicaNegocios
Imports entidadNegocios
Imports accesoDatos
Public Class frm_consumos_alambron
    Dim objIngresoProdLn As New Ing_prodLn
    Private obj_Ing_prodLn As New Ing_prodLn
    Private objOpSimplesLn As New Op_simpesLn
    Dim horage, minutoge, horags, minutogs As String
    Dim Total_consumido As Double
    Dim total_producido As Double
    Private Sub frm_consumos_alambron_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cboFechaIni.Value = Today
        cboFechaFin.Value = Today
        lbl_consumido.Visible = False
        lbl_producido.Visible = False
    End Sub
    Private Sub btn_cargar_Click(sender As Object, e As EventArgs) Handles btn_cargar.Click
        Dim sql As String

        Dim dt As New DataTable
        Dim dt2 As New DataTable
        Dim horae As String
        Dim horas As String
        dtg_matprima.DataSource = Nothing
        dtg_alambron.DataSource = Nothing
        dtg_matprima_repro.DataSource = Nothing
        dtg_recocido.DataSource = Nothing
        Total_consumido = 0
        total_producido = 0
        lbl_consumido.Visible = True
        lbl_producido.Visible = True
        lbl_consumido.Text = "Total consumido:"
        lbl_producido.Text = "Total producido:"
        Dim fecIni As String = objOpSimplesLn.cambiarFormatoFecha(cboFechaIni.Value)
        Dim fecFin As String = objOpSimplesLn.cambiarFormatoFecha(cboFechaFin.Value)
        horae = horage & ":" & minutoge & ":00"
        horas = horags & ":" & minutogs & ":00"
        If horas = "24:00:00" Then
            horas = "23:59:59"
        End If
        If horas = "24:00:00" Then
            horae = "23:59:59"
        End If
        Dim fecha_horae As String
        Dim fecha_horas As String
        fecha_horae = fecIni & " " & horae
        fecha_horas = fecFin & " " & horas
        If chk_mat_ptrima.Checked = True Then
            sql = "select t.materia_prima,sum(r.peso) as prod_brilla " & _
                  "from J_orden_prod_tef t inner join J_rollos_tref r on t.consecutivo=r.cod_orden inner join J_det_orden_prod d on d.cod_orden=r.cod_orden and d.id_detalle=r.id_detalle" & _
                   " where r.anulado  is null AND r.manuales is null AND d.fec_hora_fin >='" & fecha_horae & "' and d.fec_hora_fin <='" & fecha_horas & "' and t.materia_prima like '%11%' and t.materia_prima not like '%22R%'" & _
                  " group by t.materia_prima order by t.materia_prima "
            dt = objIngresoProdLn.listar_datatable(sql, "PRODUCCION")
            sql = "select t.materia_prima,sum(r.peso) as prod_brilla " & _
               "from J_orden_prod_tef t inner join J_rollos_tref r on t.consecutivo=r.cod_orden inner join J_det_orden_prod d on d.cod_orden=r.cod_orden and d.id_detalle=r.id_detalle" & _
                " where r.anulado  is null AND r.manuales is null AND d.fec_hora_fin >='" & fecha_horae & "' and d.fec_hora_fin <='" & fecha_horas & "' and t.materia_prima like '%22%' " & _
               " group by t.materia_prima order by t.materia_prima "
            dt2 = objIngresoProdLn.listar_datatable(sql, "PRODUCCION")
        Else
            sql = "SELECT t.consecutivo as nro_orden,t.prod_final,t.materia_prima,t.cant_prog, sum(r.peso) as lleva " & _
               " from J_orden_prod_tef t inner join J_rollos_tref r on t.consecutivo=r.cod_orden inner join J_det_orden_prod d on d.cod_orden=r.cod_orden and d.id_detalle=r.id_detalle " & _
               " where r.anulado  is null AND r.manuales is null and d.fec_hora_fin >='" & fecha_horae & "' and d.fec_hora_fin <='" & fecha_horas & "' and t.materia_prima like '%11%' and t.materia_prima not like '%22R%' group by t.consecutivo,t.prod_final,t.materia_prima,t.cant_prog order by t.materia_prima"
            dt = objIngresoProdLn.listar_datatable(sql, "PRODUCCION")
            sql = "SELECT t.consecutivo as nro_orden,t.prod_final,t.materia_prima,t.cant_prog, sum(r.peso) as lleva " & _
               " from J_orden_prod_tef t inner join J_rollos_tref r on t.consecutivo=r.cod_orden inner join J_det_orden_prod d on d.cod_orden=r.cod_orden and d.id_detalle=r.id_detalle " & _
               " where r.anulado  is null AND r.manuales is null and d.fec_hora_fin >='" & fecha_horae & "' and d.fec_hora_fin <='" & fecha_horas & "' and t.materia_prima like '%22%' group by t.consecutivo,t.prod_final,t.materia_prima,t.cant_prog order by t.materia_prima"
            dt2 = objIngresoProdLn.listar_datatable(sql, "PRODUCCION")
        End If
        dtg_matprima.DataSource = dt
        dtg_matprima_repro.DataSource = dt2
        sql = "select codigo,sum(cantidad) as kilos from documentos_lin" & _
            " WHERE fec >='" & fecIni & " 0:00:00' and fec <='" & fecFin & " 0:00:00' and tipo='SMPP' AND bodega=2  group by codigo order by codigo"
        dt = objIngresoProdLn.listar_datatable(sql, "CORSAN")
        dtg_alambron.DataSource = dt

        sql = "select codigo,sum(cantidad) as kilos from documentos_lin" & _
          " WHERE fec >='" & fecIni & " 0:00:00' and fec <='" & fecFin & " 0:00:00' and tipo='SCAE' AND bodega=2  group by codigo order by codigo"
        dt = objIngresoProdLn.listar_datatable(sql, "CORSAN")
        dtg_recocido.DataSource = dt
        sql = "select codigo,sum(cantidad) as kilos from documentos_lin" & _
        " WHERE fec >='" & fecIni & " 0:00:00' and fec <='" & fecFin & " 0:00:00' and tipo='SCAE' AND bodega=2  group by codigo order by codigo"
        dt = objIngresoProdLn.listar_datatable(sql, "CORSAN")
        dtg_recocido.DataSource = dt

        sql = "select codigo,sum(cantidad) as kilos from documentos_lin" & _
        " WHERE fec >='" & fecIni & " 0:00:00' and fec <='" & fecFin & " 0:00:00' and tipo='SCAL' AND bodega=2  group by codigo order by codigo"
        dt = objIngresoProdLn.listar_datatable(sql, "CORSAN")
        dtg_brillante_consu.DataSource = dt

        If chk_mat_ptrima.Checked = True Then
            dtg_matprima.DataSource = totalizarAcu("A")
            dtg_matprima_repro.DataSource = totalizarAcu("R")
        Else
            dtg_matprima.DataSource = totalizarDet("A")
            dtg_matprima_repro.DataSource = totalizarDet("R")
        End If
        dtg_alambron.DataSource = totalizar_alambron()
        dtg_recocido.DataSource = totalizar_recocido()
        dtg_brillante_consu.DataSource = totalizar_brillante()
        pintartotal()
        lbl_consumido.Text &= Total_consumido
        lbl_producido.Text &= total_producido
    End Sub
    Private Function totalizarDet(ByVal id As String)
        Dim cant_prog As Integer = 0
        Dim cant_prod As Integer = 0
        Dim indice As Integer = 0
        Dim dt As DataTable
        If id = "A" Then
            dt = DirectCast(dtg_matprima.DataSource, DataTable)
            For Each row As DataRow In dt.Rows
                If row.Item("cant_prog") >= 0 Then
                    cant_prog += row.Item("cant_prog")
                End If
                If row.Item("lleva") >= 0 Then
                    cant_prod += row.Item("lleva")
                End If
                If indice = (dt.Rows.Count - 1) Then
                    dt.Rows.Add()
                    dt.Rows(dt.Rows.Count - 1).Item("materia_prima") = "TOTAL"
                    dt.Rows(dt.Rows.Count - 1).Item("cant_prog") = cant_prog
                    dt.Rows(dt.Rows.Count - 1).Item("lleva") = cant_prod
                    total_producido += cant_prod
                    Exit For
                End If
                indice += 1
            Next
        ElseIf id = "R" Then
            dt = DirectCast(dtg_matprima_repro.DataSource, DataTable)
            For Each row As DataRow In dt.Rows
                If row.Item("cant_prog") >= 0 Then
                    cant_prog += row.Item("cant_prog")
                End If
                If row.Item("lleva") >= 0 Then
                    cant_prod += row.Item("lleva")
                End If
                If indice = (dt.Rows.Count - 1) Then
                    dt.Rows.Add()
                    dt.Rows(dt.Rows.Count - 1).Item("materia_prima") = "TOTAL"
                    dt.Rows(dt.Rows.Count - 1).Item("cant_prog") = cant_prog
                    dt.Rows(dt.Rows.Count - 1).Item("lleva") = cant_prod
                    total_producido += cant_prod
                    Exit For
                End If
                indice += 1
            Next
        End If
#Disable Warning BC42104 ' La variable 'dt' se usa antes de que se le haya asignado un valor. Podría darse una excepción de referencia NULL en tiempo de ejecución.
        Return dt
#Enable Warning BC42104 ' La variable 'dt' se usa antes de que se le haya asignado un valor. Podría darse una excepción de referencia NULL en tiempo de ejecución.
    End Function
    Private Function totalizarAcu(ByVal id As String)
        Dim mat_consu As Integer = 0
        Dim indice As Integer = 0
        Dim dt As DataTable
        If id = "A" Then
            dt = DirectCast(dtg_matprima.DataSource, DataTable)
            For Each row As DataRow In dt.Rows
                If row.Item("prod_brilla") >= 0 Then
                    mat_consu += row.Item("prod_brilla")
                End If
                If indice = (dt.Rows.Count - 1) Then
                    dt.Rows.Add()
                    dt.Rows(dt.Rows.Count - 1).Item("materia_prima") = "TOTAL"
                    dt.Rows(dt.Rows.Count - 1).Item("prod_brilla") = mat_consu
                    total_producido += mat_consu
                    Exit For
                End If
                indice += 1
            Next
        ElseIf id = "R" Then
            dt = DirectCast(dtg_matprima_repro.DataSource, DataTable)
            For Each row As DataRow In dt.Rows
                If row.Item("prod_brilla") >= 0 Then
                    mat_consu += row.Item("prod_brilla")
                End If
                If indice = (dt.Rows.Count - 1) Then
                    dt.Rows.Add()
                    dt.Rows(dt.Rows.Count - 1).Item("materia_prima") = "TOTAL"
                    dt.Rows(dt.Rows.Count - 1).Item("prod_brilla") = mat_consu
                    total_producido += mat_consu
                    Exit For
                End If
                indice += 1
            Next
        End If
#Disable Warning BC42104 ' La variable 'dt' se usa antes de que se le haya asignado un valor. Podría darse una excepción de referencia NULL en tiempo de ejecución.
        Return dt
#Enable Warning BC42104 ' La variable 'dt' se usa antes de que se le haya asignado un valor. Podría darse una excepción de referencia NULL en tiempo de ejecución.
    End Function
    Private Function totalizar_alambron()
        Dim alam_consu As Integer = 0
        Dim indice As Integer = 0
        Dim dt As DataTable = DirectCast(dtg_alambron.DataSource, DataTable)
        For Each row As DataRow In dt.Rows
            If row.Item("kilos") >= 0 Then
                alam_consu += row.Item("kilos")
            End If
            If indice = (dt.Rows.Count - 1) Then
                dt.Rows.Add()
                dt.Rows(dt.Rows.Count - 1).Item("codigo") = "TOTAL"
                dt.Rows(dt.Rows.Count - 1).Item("kilos") = alam_consu
                Total_consumido += alam_consu
                Exit For
            End If
            indice += 1
        Next
        Return dt
    End Function
    Private Function totalizar_recocido()
        Dim alam_consu As Integer = 0
        Dim indice As Integer = 0
        Dim dt As DataTable = DirectCast(dtg_recocido.DataSource, DataTable)
        For Each row As DataRow In dt.Rows
            If row.Item("kilos") >= 0 Then
                alam_consu += row.Item("kilos")
            End If
            If indice = (dt.Rows.Count - 1) Then
                dt.Rows.Add()
                dt.Rows(dt.Rows.Count - 1).Item("codigo") = "TOTAL"
                dt.Rows(dt.Rows.Count - 1).Item("kilos") = alam_consu
                Total_consumido += alam_consu
                Exit For
            End If
            indice += 1
        Next
        Return dt
    End Function
    Private Function totalizar_brillante()
        Dim alam_consu As Integer = 0
        Dim indice As Integer = 0
        Dim dt As DataTable = DirectCast(dtg_brillante_consu.DataSource, DataTable)
        For Each row As DataRow In dt.Rows
            If row.Item("kilos") >= 0 Then
                alam_consu += row.Item("kilos")
            End If
            If indice = (dt.Rows.Count - 1) Then
                dt.Rows.Add()
                dt.Rows(dt.Rows.Count - 1).Item("codigo") = "TOTAL"
                dt.Rows(dt.Rows.Count - 1).Item("kilos") = alam_consu
                Total_consumido += alam_consu
                Exit For
            End If
            indice += 1
        Next
        Return dt
    End Function
    Public Sub pintartotal()
        If dtg_matprima.Rows.Count > 0 Then
            dtg_matprima.Rows(dtg_matprima.Rows.Count - 1).DefaultCellStyle.BackColor = Color.Salmon
            dtg_matprima.Rows(dtg_matprima.Rows.Count - 1).DefaultCellStyle.Font = New Font(dtg_matprima.CurrentCell.InheritedStyle.Font, FontStyle.Bold)
        End If
        If dtg_matprima_repro.Rows.Count > 0 Then
            dtg_matprima_repro.Rows(dtg_matprima_repro.Rows.Count - 1).DefaultCellStyle.BackColor = Color.Salmon
            dtg_matprima_repro.Rows(dtg_matprima_repro.Rows.Count - 1).DefaultCellStyle.Font = New Font(dtg_matprima_repro.CurrentCell.InheritedStyle.Font, FontStyle.Bold)
        End If
        If dtg_alambron.Rows.Count > 0 Then
            dtg_alambron.Rows(dtg_alambron.Rows.Count - 1).DefaultCellStyle.BackColor = Color.Salmon
            dtg_alambron.Rows(dtg_alambron.Rows.Count - 1).DefaultCellStyle.Font = New Font(dtg_alambron.CurrentCell.InheritedStyle.Font, FontStyle.Bold)
        End If
        If dtg_recocido.Rows.Count > 0 Then
            dtg_recocido.Rows(dtg_recocido.Rows.Count - 1).DefaultCellStyle.BackColor = Color.Salmon
            dtg_recocido.Rows(dtg_recocido.Rows.Count - 1).DefaultCellStyle.Font = New Font(dtg_recocido.CurrentCell.InheritedStyle.Font, FontStyle.Bold)
        End If
        If dtg_brillante_consu.Rows.Count > 0 Then
            dtg_brillante_consu.Rows(dtg_brillante_consu.Rows.Count - 1).DefaultCellStyle.BackColor = Color.Salmon
            dtg_brillante_consu.Rows(dtg_brillante_consu.Rows.Count - 1).DefaultCellStyle.Font = New Font(dtg_brillante_consu.CurrentCell.InheritedStyle.Font, FontStyle.Bold)
        End If
    End Sub
    Private Sub cbo_hora_entrada_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbo_hora_entrada.SelectedIndexChanged
        horage = cbo_hora_entrada.SelectedItem
    End Sub
    Private Sub cbo_min_entrada_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbo_min_entrada.SelectedIndexChanged
        minutoge = cbo_min_entrada.SelectedItem
    End Sub
    Private Sub cbo_hora_salida_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbo_hora_salida.SelectedIndexChanged
        horags = cbo_hora_salida.SelectedItem
    End Sub
    Private Sub cbo_min_salida_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbo_min_salida.SelectedIndexChanged
        minutogs = cbo_min_salida.SelectedItem
    End Sub
End Class