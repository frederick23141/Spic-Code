Imports logicaNegocios
Imports entidadNegocios
Imports accesoDatos
Public Class Frm_consumos_puntilleria
    Dim objIngresoProdLn As New Ing_prodLn
    Private obj_Ing_prodLn As New Ing_prodLn
    Private objOpSimplesLn As New Op_simpesLn
    Dim horage, minutoge, horags, minutogs As String
    Private Sub Frm_consumos_puntilleria_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cboFechaIni.Value = Today
        cboFechaFin.Value = Today
    End Sub
    Private Sub btn_cargar_Click(sender As Object, e As EventArgs) Handles btn_cargar.Click
        Dim sql As String
        Dim dt As New DataTable
        Dim dt2 As New DataTable
        Dim horae As String
        Dim horas As String
        dtg_mat_punt.DataSource = Nothing
        dtg_scla.DataSource = Nothing
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
            sql = "select e.origen as materia_prima,sum(p.peso) as lleva  " & _
                  "from J_orden_prod_punt_enc e inner join J_orden_prod_punt_producto p on e.consecutivo=p.nro_orden" & _
                   " where (e.oculto=0 or e.oculto is null) AND p.fecha_hora >='" & fecha_horae & "' and p.fecha_hora<='" & fecha_horas & "'" & _
                  " group by e.origen order by e.origen "
            dt = objIngresoProdLn.listar_datatable(sql, "PRODUCCION")
        Else
            sql = "select e.consecutivo as nro_orden,e.origen as materia_prima,e.prod_final,e.cant_prog,sum(p.peso) as lleva  " & _
               " from J_orden_prod_punt_enc e inner join J_orden_prod_punt_producto p on e.consecutivo=p.nro_orden  " & _
               " where (e.oculto=0 or e.oculto is null) and p.fecha_hora >='" & fecha_horae & "' and p.fecha_hora <='" & fecha_horas & "' group by E.consecutivo,e.origen,e.prod_final,e.cant_prog   "
            dt = objIngresoProdLn.listar_datatable(sql, "PRODUCCION")
        End If
        dtg_mat_punt.DataSource = dt
        sql = "select codigo,sum(cantidad) as kilos from documentos_lin" & _
          " WHERE fec >='" & fecIni & " 0:00:00' and fec <='" & fecFin & " 0:00:00' and tipo='SCLA' AND bodega=12  group by codigo order by codigo"
        dt = objIngresoProdLn.listar_datatable(sql, "CORSAN")
        dtg_scla.DataSource = dt

        If chk_mat_ptrima.Checked = True Then
            dtg_mat_punt.DataSource = totalizarAcu()
        Else
            dtg_mat_punt.DataSource = totalizarDet()
        End If
        dtg_scla.DataSource = totalizar_matprima()
        pintartotal()
    End Sub
    Private Function totalizarDet()
        Dim cant_prog As Integer = 0
        Dim cant_prod As Integer = 0
        Dim indice As Integer = 0
        Dim dt As DataTable
        dt = DirectCast(dtg_mat_punt.DataSource, DataTable)
        For Each row As DataRow In dt.Rows
            If row.Item("cant_prog") >= 0 Then
                cant_prog += row.Item("cant_prog")
            End If
            If row.Item("lleva") >= 0 Then
                cant_prod += row.Item("lleva")
            End If
            If indice = (dt.Rows.Count - 1) Then
                dt.Rows.Add()
                dt.Rows(dt.Rows.Count - 1).Item("prod_final") = "TOTAL"
                dt.Rows(dt.Rows.Count - 1).Item("cant_prog") = cant_prog
                dt.Rows(dt.Rows.Count - 1).Item("lleva") = cant_prod
                Exit For
            End If
            indice += 1
        Next
        Return dt
    End Function
    Private Function totalizarAcu()
        Dim mat_consu As Integer = 0
        Dim indice As Integer = 0
        Dim dt As DataTable

        dt = DirectCast(dtg_mat_punt.DataSource, DataTable)
        For Each row As DataRow In dt.Rows
            If row.Item("lleva") >= 0 Then
                mat_consu += row.Item("lleva")
            End If
            If indice = (dt.Rows.Count - 1) Then
                dt.Rows.Add()
                dt.Rows(dt.Rows.Count - 1).Item("materia_prima") = "TOTAL"
                dt.Rows(dt.Rows.Count - 1).Item("lleva") = mat_consu
                Exit For
            End If
            indice += 1
        Next
        Return dt
    End Function
    Private Function totalizar_matprima()
        Dim alam_consu As Integer = 0
        Dim indice As Integer = 0
        Dim dt As DataTable = DirectCast(dtg_scla.DataSource, DataTable)
        For Each row As DataRow In dt.Rows
            If row.Item("kilos") >= 0 Then
                alam_consu += row.Item("kilos")
            End If
            If indice = (dt.Rows.Count - 1) Then
                dt.Rows.Add()
                dt.Rows(dt.Rows.Count - 1).Item("codigo") = "TOTAL"
                dt.Rows(dt.Rows.Count - 1).Item("kilos") = alam_consu
                Exit For
            End If
            indice += 1
        Next
        Return dt
    End Function
    Public Sub pintartotal()
        If dtg_mat_punt.Rows.Count > 0 Then
            dtg_mat_punt.Rows(dtg_mat_punt.Rows.Count - 1).DefaultCellStyle.BackColor = Color.Salmon
            dtg_mat_punt.Rows(dtg_mat_punt.Rows.Count - 1).DefaultCellStyle.Font = New Font(dtg_mat_punt.CurrentCell.InheritedStyle.Font, FontStyle.Bold)
        End If
        If dtg_scla.Rows.Count > 0 Then
            dtg_scla.Rows(dtg_scla.Rows.Count - 1).DefaultCellStyle.BackColor = Color.Salmon
            dtg_scla.Rows(dtg_scla.Rows.Count - 1).DefaultCellStyle.Font = New Font(dtg_scla.CurrentCell.InheritedStyle.Font, FontStyle.Bold)
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