Imports logicaNegocios
Imports entidadNegocios
Imports accesoDatos
Public Class Frm_auditoria_puntilleria
    Private objOpSimplesLn As New Op_simpesLn
    Private objOperacionesForm As OperacionesFormularios = New OperacionesFormularios
    Dim horage, minutoge, horags, minutogs As String
    Public Sub Main()
        cargar_datos()
    End Sub
    Public Sub cargar_datos()
        Dim horae As String
        Dim horas As String
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
        fecha_horae = fecini & " " & horae
        fecha_horas = fecfin & " " & horas

        Dim tamano_letra As Single = 9.0
        dtg_auditoria.DataSource = Nothing
        Dim sql As String
        If chk_no_conforme.Checked Then
            sql = "SELECT p.nro_orden,p.consecutivo_rollo,p.peso, e.prod_final, r.descripcion ,(select fecha from CORSAN.dbo.documentos where numero=p.trans and tipo=p.tipo_trans) AS fecha_hora, p.tipo_trans, p.trans, p.sppp, e.maquina, m.Nombre AS maq, p.tamboreado,  p.nit_operario , t.nombres,	p.nit_operario2, p.no_conforme " &
                                    "FROM	J_orden_prod_punt_producto p ,J_orden_prod_punt_enc e , CORSAN.dbo.referencias r , CORSAN.dbo.V_nom_personal_Activo_con_maquila  t , j_maquinas m,J_seccion_maquina_punt s " &
                                        "WHERE	p.nro_orden = e.consecutivo and s.maquina =  m.codigoM  AND r.codigo = e.prod_final AND t.nit = p.nit_operario AND m.codigoM = e.maquina AND p.anular IS NULL AND no_conforme IS not NULL"

        Else
            sql = "SELECT p.nro_orden,p.consecutivo_rollo,p.peso, e.prod_final, r.descripcion ,p.fecha_hora, p.tipo_trans, p.trans, p.sppp, e.maquina, m.Nombre AS maq, p.tamboreado,  p.nit_operario , t.nombres,	p.nit_operario2, p.no_conforme " &
                         "FROM	J_orden_prod_punt_producto p ,J_orden_prod_punt_enc e , CORSAN.dbo.referencias r , CORSAN.dbo.V_nom_personal_Activo_con_maquila  t , j_maquinas m,J_seccion_maquina_punt s " &
                             "WHERE	p.nro_orden = e.consecutivo and s.maquina =  m.codigoM AND r.codigo = e.prod_final AND t.nit = p.nit_operario AND m.codigoM = e.maquina AND p.anular IS NULL AND no_conforme IS  NULL"
        End If

        If chk_historial.Checked Then
            sql = "SELECT p.nro_orden,p.consecutivo_rollo,p.peso, e.prod_final, r.descripcion ,p.fecha_hora, p.tipo_trans, p.trans, p.sppp, e.maquina, m.Nombre AS maq, p.tamboreado,  p.nit_operario , t.nombres,	p.nit_operario2, p.no_conforme, w.D_defecto " & _
                    " FROM	J_orden_prod_punt_producto p ,J_orden_prod_punt_enc e , CORSAN.dbo.referencias r , CORSAN.dbo.V_nom_personal_Activo_con_maquila  t , j_maquinas m, J_defectos_puntilla a,  J_desperdicios_defecto w " & _
                        " WHERE	a.defecto = w.Id_defecto AND p.consecutivo_rollo = a.consecutivo_rollo AND p.nro_orden = a.nro_orden AND p.nro_orden = e.consecutivo AND r.codigo = e.prod_final AND t.nit = p.nit_operario AND m.codigoM = e.maquina AND p.anular IS NOT NULL AND no_conforme IS not NULL"
        End If

        Dim wheresql As String = ""

        If chk_tamb.Checked = True Then
            If chk_sin_tamb.Checked = False Then
                wheresql &= " AND tamboreado IS not null"
            End If
            If chk_env_empaque.Checked = False Then
                wheresql &= " AND sppp IS NULL"
            End If
        End If
        If chk_sin_tamb.Checked = True Then
            If chk_tamb.Checked = False Then
                wheresql &= " AND tamboreado IS null AND sppp IS NULL"
            End If
        End If
        If chk_env_empaque.Checked = True Then
            wheresql &= " AND sppp IS not NULL AND hornos is null"
        End If
        If chk_hornos.Checked = True Then
            wheresql &= " AND sppp IS not NULL AND hornos IS NOT NULL"
        End If
        If chk_bod8.Checked = True Then
            wheresql &= " AND (trb28 IS not NULL OR eipp IS NOT NULL)"
        End If
        If txt_ordenProduccion.Text <> "" Then
            wheresql &= " AND nro_orden = '" & txt_ordenProduccion.Text & "'"
        Else
            wheresql &= " AND fecha_hora >= '" & fecha_horae & "' AND fecha_hora <= '" & fecha_horas & "'"
        End If
        If cbo_maquina.SelectedValue <> 0 Then
            wheresql &= " AND e.maquina = " & cbo_maquina.SelectedValue
        End If
        If cbo_operario.SelectedValue <> 0 Then
            wheresql &= " AND nit_operario = " & cbo_operario.SelectedValue
        End If
        If txt_prod_final.Text <> "" Then
            wheresql &= " AND e.prod_final like '" & txt_prod_final.Text & "%'"
        End If
        If cbo_grupos.Text <> "" Then
            wheresql &= " AND s.seccion like '%" & cbo_grupos.Text & "%'"
        End If

        sql &= wheresql

        Dim dt As DataTable = objOpSimplesLn.listar_datatable(Sql, "PRODUCCION")
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
        dtg_auditoria.DataSource = dt
        dtg_auditoria.CurrentCell = Nothing
        dtg_auditoria.Rows(dtg_auditoria.Rows.Count - 1).DefaultCellStyle = objOperacionesForm.formatoNegrita(tamano_letra)
        dtg_auditoria.Columns("peso").DefaultCellStyle.Format = "N1"
        pintar_dtg()
    End Sub

    Private Sub Frm_auditoria_puntilleria_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargar_combo_datos()
        cboFechaIni.Value = Today
        cboFechaFin.Value = Today
        'cbo_fecha_ini.Value = Now.AddMonths(-1)
        'cbo_fecha_ini.Value = cbo_fecha_ini.Value.AddDays(-Now.Day + 1)
        'cbo_fecha_fin.Value = cbo_fecha_ini.Value.AddDays((DateSerial(Year(cbo_fecha_ini.Value), Month(cbo_fecha_ini.Value) + 1, 0).Day) - 1)
    End Sub
    Private Sub pintar_dtg()
        For i = 0 To dtg_auditoria.Rows.Count - 2
            If IsDBNull(dtg_auditoria.Item("tamboreado", i).Value) Then
                dtg_auditoria.Rows(i).DefaultCellStyle.BackColor = Color.LightCoral
            ElseIf Not IsDBNull(dtg_auditoria.Item("tamboreado", i).Value) And IsDBNull(dtg_auditoria.Item("sppp", i).Value) Then
                dtg_auditoria.Rows(i).DefaultCellStyle.BackColor = Color.Gold
            ElseIf Not (IsDBNull(dtg_auditoria.Item("sppp", i).Value)) Then
                dtg_auditoria.Rows(i).DefaultCellStyle.BackColor = Color.Violet
            ElseIf Not (IsDBNull(dtg_auditoria.Item("no_conforme", i).Value)) Then
                dtg_auditoria.Rows(i).DefaultCellStyle.BackColor = Color.ForestGreen
            End If
            If chk_hornos.Checked Then
                dtg_auditoria.Rows(i).DefaultCellStyle.BackColor = Color.OrangeRed
            End If
        Next
    End Sub


    Private Sub cargar_combo_datos()
        'Cargar datos de los operarios
        Dim sql As String = "SELECT nit,nombres  FROM V_nom_personal_Activo_con_maquila WHERE centro = 2300  order by nombres"
        Dim dt As DataTable = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        dt.Rows.Add()
        dt.Rows(dt.Rows.Count - 1).Item("nit") = 0
        dt.Rows(dt.Rows.Count - 1).Item("nombres") = "Seleccione"
        cbo_operario.DataSource = dt
        cbo_operario.ValueMember = "nit"
        cbo_operario.DisplayMember = "nombres"
        cbo_operario.SelectedValue = 0

        'Cargar datos de las maquinas
        sql = "SELECT codigoM, Nombre  FROM J_Maquinas WHERE TipoMaquina = '2' order by nombre"
        dt = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")
        dt.Rows.Add()
        dt.Rows(dt.Rows.Count - 1).Item("codigoM") = 0
        dt.Rows(dt.Rows.Count - 1).Item("nombre") = "Seleccione"
        cbo_maquina.DataSource = dt
        cbo_maquina.ValueMember = "codigoM"
        cbo_maquina.DisplayMember = "nombre"
        cbo_maquina.SelectedValue = 0
    End Sub

    Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
        dtg_auditoria.CurrentCell = Nothing
        img_procesar.Visible = True
        Application.DoEvents()
        dtg_auditoria.DataSource = Nothing
        cargar_datos()
        img_procesar.Visible = False
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        Me.UseWaitCursor = True
        Application.DoEvents()
        objOperacionesForm.exportarExcel(dtg_auditoria)
        Me.UseWaitCursor = False
    End Sub
    Private Sub chk_historial_CheckedChanged(sender As Object, e As EventArgs) Handles chk_historial.CheckedChanged
        chk_sin_tamb.Checked = False
        chk_tamb.Checked = False
        chk_env_empaque.Checked = False
        chk_todo.Checked = False
        chk_no_conforme.Checked = False
    End Sub

    Private Sub chk_sin_tamb_CheckedChanged(sender As Object, e As EventArgs) Handles chk_sin_tamb.CheckedChanged
        chk_historial.Checked = False
    End Sub

    Private Sub chk_tamb_CheckedChanged(sender As Object, e As EventArgs) Handles chk_tamb.CheckedChanged
        chk_historial.Checked = False
    End Sub

    Private Sub Cbo_hora_entrada_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbo_hora_entrada.SelectedIndexChanged
        horage = cbo_hora_entrada.SelectedItem
    End Sub

    Private Sub Cbo_min_entrada_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbo_min_entrada.SelectedIndexChanged
        minutoge = cbo_min_entrada.SelectedItem
    End Sub

    Private Sub Cbo_hora_salida_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbo_hora_salida.SelectedIndexChanged
        horags = cbo_hora_salida.SelectedItem
    End Sub

    Private Sub Cbo_min_salida_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbo_min_salida.SelectedIndexChanged
        minutogs = cbo_min_salida.SelectedItem
    End Sub

    Private Sub chk_env_empaque_CheckedChanged(sender As Object, e As EventArgs) Handles chk_env_empaque.CheckedChanged
        chk_historial.Checked = False
    End Sub

    Private Sub chk_no_conforme_CheckedChanged(sender As Object, e As EventArgs) Handles chk_no_conforme.CheckedChanged
        chk_historial.Checked = False
    End Sub

    Private Sub chk_todo_CheckedChanged(sender As Object, e As EventArgs) Handles chk_todo.CheckedChanged
        chk_historial.Checked = False
    End Sub
End Class