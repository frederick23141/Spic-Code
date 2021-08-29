Imports logicaNegocios
Imports entidadNegocios
Public Class Frm_programacion_turnos
    Private objOperacionesForm As OperacionesFormularios = New OperacionesFormularios
    Private objOpSimplesLn As New Op_simpesLn
    Private objRelojLn As New RelojLn
    Private nomb_modulo As String
    Private dtTrazabilidad As DataTable
    Dim centros As String = ""
    Dim per_diagnostico As Boolean = True
    Dim usuario As New UsuarioEn
    Dim correccion As Boolean = False
    Dim filaSelect As Integer = 0
    Dim colSelect As Integer = 0
    Dim carga_comp As Boolean = False
    Dim fec_ini As Date
    Dim fec_fin As Date
    Dim id_periodo As Double
    Dim dt_turnos As New DataTable
    Dim conceptos As String = ""
    Private dragging As Boolean
    Private posicionX, posicionY As Integer
    Private horas_laborales As Integer = 0
    Dim motivo_extras As Integer = 0
    Dim listCentros As New DataTable
    Dim dt_porc_conceptos As DataTable
    Dim mes As Integer
    Dim ano As Integer

    Public Sub MAIN(ByVal nomb_modulo As String, ByVal usuario As UsuarioEn)
        Me.usuario = usuario
        Dim fecha_menos_1_mes As Date = Now.AddMonths(-1)
        Dim sql_mot_extras As String = "SELECT id,descripcion FROM J_motivo_horas_extras"
        dtg_mot_extras.DataSource = objOpSimplesLn.listar_datatable(sql_mot_extras, "CONTROL")
        Dim dt_conceptos As DataTable = objOpSimplesLn.listar_datatable("SELECT concepto FROM J_permiso_novedad WHERE usuario = '" & usuario.usuario.Trim & "' and concepto not in('34','36','77')", "CONTROL")
        For i = 0 To dt_conceptos.Rows.Count - 1
            conceptos &= dt_conceptos.Rows(i).Item("concepto")
            If i <> dt_conceptos.Rows.Count - 1 Then
                conceptos &= ","
            End If
        Next
        Dim dt As New DataTable
        Dim sql As String = ""
        If (usuario.permiso.Trim <> "ADMIN" And usuario.permiso.Trim <> "NOMINA") Then
            Dim nit As Double = usuario.nit
            listCentros = objOpSimplesLn.listar_datatable("SELECT centro FROM J_coordinador_centros_costos WHERE nit =" & nit, "PRODUCCION")
            For i = 0 To listCentros.Rows.Count - 1
                centros &= listCentros.Rows(i).Item("centro")
                If (i <> listCentros.Rows.Count - 1) Then
                    centros &= ","
                End If
            Next
        End If
        If centros = "" Then
            centros = "1100,1200,2100,2117,2200,2300,2400,2500,2600,2800,3100,3200,3500,4100,4200,4300,4500,5200,5300,5400,6200,6400"
        End If
        dt = New DataTable
        Dim dr As DataRow
        Dim where_sql As String = ""
        where_sql &= "WHERE centro IN(1100,1200,2100,2117,2200,2300,2400,2500,2600,2800,3100,3200,3500,4100,4200,4300,4500,5200,5300,5400,6200,6400)"
        sql = "SELECT centro,( CAST (centro AS varchar(25))+ '-' + descripcion )As descripcion " & _
                        "FROM centros " & _
                            where_sql
        dt = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        dr = dt.NewRow
        dr("centro") = 0
        dr("descripcion") = "TODO"
        dt.Rows.Add(dr)
        cbo_centro.DataSource = dt
        cbo_centro.ValueMember = "centro"
        cbo_centro.DisplayMember = "descripcion"
        cbo_centro.SelectedValue = 0
        sql = "SELECT concepto,descripcion " & _
            "FROM y_conceptos_nom " & _
            "WHERE concepto in (" & conceptos & ")"
        dt = New DataTable
        dt = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        dtg_novedad.DataSource = dt
        cargar_operarios(0)

        dt = New DataTable
        sql = "SELECT  idPeriodo ,'Periodo:' + CAST( (periodo  )As varchar ) +' - ' +CAST( YEAR (fecha_inicial )As varchar ) + '-' + CAST( MONTH (fecha_inicial )As varchar ) + '-' + CAST( DAY (fecha_inicial )As varchar ) " &
                         "+ ' - ' +  CAST( YEAR (fecha_final  )As varchar ) + '-' + CAST( MONTH (fecha_final )As varchar ) + '-' + CAST( DAY (fecha_final )As varchar ) As descripcion,fecha_inicial,fecha_final " &
                         "FROM y_periodos_control " &
                             "WHERE dateDiff (day,fecha_inicial,fecha_final )>5 AND ((ano = " & fecha_menos_1_mes.Year & " And mes = " & fecha_menos_1_mes.Month & ") OR (ano = " & Now.Year & " And mes = " & Now.Month & ")) and periodo>=1 and periodo<=3 "
        dt = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        dr = dt.NewRow
        dr("idPeriodo") = 0
        dr("descripcion") = "Seleccione"
        dt.Rows.Add(dr)
        cbo_periodo.DataSource = dt
        cbo_periodo.ValueMember = "idPeriodo"
        cbo_periodo.DisplayMember = "descripcion"
        cbo_periodo.SelectedValue = 0
        For i = 0 To dt.Rows.Count - 2
            If Now.Date >= dt.Rows(i).Item("fecha_inicial") And Now.Date <= dt.Rows(i).Item("fecha_final") Then
                carga_comp = True
                cbo_periodo.SelectedValue = dt.Rows(i).Item("idPeriodo")
                i = dt.Rows.Count - 1
            End If
        Next

        sql = "SELECT concepto,porc_basico FROM y_conceptos_nom WHERE concepto IN (13,9,15,16)"
        dt_porc_conceptos = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        carga_comp = True
    End Sub
    Private Sub Frm_programacion_turnos_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim sql_turnos As String = "SELECT id,descripcion,horas,ord_diur,ord_noct,extras,compensatorio FROM j_turnos WHERE anulado = 'N' ORDER BY id"
        dt_turnos = objOpSimplesLn.listar_datatable(sql_turnos, "CORSAN")
        Dim tamano_letra As Single = 9.0!
        dtgTurno.DataSource = dt_turnos
        dtgTurno.Rows(dtgTurno.Rows.Count - 1).DefaultCellStyle = objOperacionesForm.formatoNegrita(tamano_letra)
    End Sub

    Private Sub btnConsol_Click(sender As Object, e As EventArgs) Handles btnConsol.Click
        dtg_consulta.CurrentCell = Nothing
        imgProcesar.Visible = True
        Application.DoEvents()
        If cbo_periodo.SelectedValue <> 0 Then
            dtg_consulta.DataSource = Nothing
            Dim where_centro As String = ""
            If cbo_centro.SelectedValue <> 0 Then
                where_centro = "AND p.centro =" & cbo_centro.SelectedValue
            ElseIf centros <> "" Then
                where_centro = " AND p.centro IN (" & centros & ")"
            End If
            cargar_datos(where_centro)
        Else
            MessageBox.Show("Seleccione un periodo", "Seleccione!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        imgProcesar.Visible = False
        Application.DoEvents()
    End Sub
    Private Sub cargar_datos(ByVal where_centro As String)
        dtg_consulta.DataSource = Nothing
        dtg_consulta.CurrentCell = Nothing
        For i = 0 To dtg_consulta.Columns.Count - 1
            dtg_consulta.Columns.RemoveAt(i)
        Next
        Dim tamano_letra As Single = 7.0!
        Dim where_nit As String = ""
        If cbo_operario.SelectedValue <> 0 Then
            where_nit = " AND p.nit =" & cbo_operario.SelectedValue
        End If
        Dim sql As String = "SELECT (SELECT SUM(Horas) FROM CONTROL.dbo.R_compromiso_horas_a_pagar  WHERE Nit_Trabajador = p.nit AND Activo = 'True' AND Horas >0)As Comp,(SELECT SUM(horas) FROM J_novedades_no_aut  WHERE nit = p.nit AND idperiodo = " & id_periodo & "  )As Nov,CAST( p.nit As varchar) AS nit,p.nombres,p.centro,p.oficio,p.contrato ,c.planta,c.turno ,c.basico_hora " & _
                                 "FROM V_nom_personal_activo p,y_personal_contratos c " & _
                                    "WHERE p.contrato=c.contrato and p.nit NOT IN (SELECT nit FROM CONTROL.dbo.J_pers_planta_no_marca) " & where_centro & where_nit & _
                                    " ORDER BY p.nombres"
        If chk_temporales.Checked = True Then
            sql = "SELECT (SELECT SUM(Horas) FROM CONTROL.dbo.R_compromiso_horas_a_pagar  WHERE Nit_Trabajador = p.nit AND Activo = 'True' AND Horas >0)As Comp,(SELECT SUM(horas) FROM J_novedades_no_aut  WHERE nit = p.nit AND idperiodo = " & id_periodo & "  )As Nov,CAST( p.nit As varchar) AS nit,p.nombres,p.centro,p.oficio,p.contrato ,p.planta,c.turno ,p.basico_hora " & _
                                 "FROM CONTROL.dbo.J_personal_maquila p  left join y_personal_contratos c on p.contrato=c.contrato " & _
                                    "WHERE p.nit NOT IN (SELECT nit FROM CONTROL.dbo.J_pers_planta_no_marca) and p.desactivar is null and p.estado='A' " & where_centro & where_nit & _
                                    " ORDER BY p.nombres"
        End If
        Dim dt As DataTable = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        dt.Columns.Add("motivo_extras")
        dt.Columns.Add("ValExt", GetType(Double))
        dt.Columns.Add("TotExt")
        dt.Columns.Add("ED")
        dt.Columns.Add("EN")
        dt.Columns.Add("EDF")
        dt.Columns.Add("ENF")
        dt.Rows.Add()
        dt.Rows(dt.Rows.Count - 1).Item("nombres") = "sabado"
        dt.Rows.Add()
        dt.Rows(dt.Rows.Count - 1).Item("nombres") = "fecha"
        dt.Rows.Add()
        dt.Rows(dt.Rows.Count - 1).Item("nombres") = "domingo"
        dt.Rows.Add()
        dt.Rows(dt.Rows.Count - 1).Item("nombres") = "festivo"
        addDias(dt)
        dt.Columns.Add("id")
        add_programacion(dt)
        dtg_consulta.DataSource = dt
        pintar_dtg()
        For i = 0 To dtg_consulta.Columns.Count - 1
            If (dtg_consulta.Columns(i).Name = "centro" Or dtg_consulta.Columns(i).Name = "oficio" Or dtg_consulta.Columns(i).Name = "contrato" Or dtg_consulta.Columns(i).Name = "planta" Or dtg_consulta.Columns(i).Name = "turno" Or dtg_consulta.Columns(i).Name = "id" Or dtg_consulta.Columns(i).Name = "motivo_extras" Or dtg_consulta.Columns(i).Name = "basico_hora") Then
                dtg_consulta.Columns(i).Visible = False
            Else
                dtg_consulta.Columns(i).ReadOnly = True
            End If
            dtg_consulta.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
        Next
        For i = 0 To dtg_consulta.Rows.Count - 1
            calcular_extras_turno(i)
        Next
        dtg_consulta.CurrentCell = Nothing
        dtg_consulta.Rows(dtg_consulta.Rows.Count - 1).Visible = False
        dtg_consulta.Rows(dtg_consulta.Rows.Count - 3).Visible = False
        dtg_consulta.Rows(dtg_consulta.Rows.Count - 2).Visible = False
        dtg_consulta.Rows(dtg_consulta.Rows.Count - 4).Visible = False
        dtg_consulta.Columns("Comp").Frozen = True
        dtg_consulta.Columns("Nov").Frozen = True
        dtg_consulta.Columns("nit").Frozen = True
        dtg_consulta.Columns("nombres").Frozen = True
        dtg_consulta.Columns("TotExt").Frozen = True
        dtg_consulta.Columns("nit").DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", tamano_letra)
        dtg_consulta.Columns("nombres").DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", tamano_letra)

    End Sub
    Private Sub calcular_extras_turno(ByVal fila As Integer)
        Dim en As Double = 0
        Dim ed As Double = 0
        Dim edf As Double = 0
        Dim enf As Double = 0
        Dim dom_fest As Boolean = False
        Dim sabado As Boolean = True
        Dim idTurno As Double = 0
        Dim turno_noche As Boolean = False
        Dim extras_turno As Double = 0
        Dim ord_turno As Double = 0
        Dim valor As Double = 0
        Dim vr_tot_extras As Double = 0
        Dim basico_hora As Double = 0
        If IsNumeric(dtg_consulta.Item("nit", fila).Value) Then
            basico_hora = dtg_consulta.Item("basico_hora", fila).Value
            For j = 0 To dtg_consulta.Columns.Count - 1
                If (dtg_consulta.Columns(j).Name <> "nit" And dtg_consulta.Columns(j).Name <> "nombres" And dtg_consulta.Columns(j).Name <> "centro" And dtg_consulta.Columns(j).Name <> "oficio" And dtg_consulta.Columns(j).Name <> "contrato" And dtg_consulta.Columns(j).Name <> "planta" And dtg_consulta.Columns(j).Name <> "turno" And dtg_consulta.Columns(j).Name <> "id" And dtg_consulta.Columns(j).Name <> "Nov" And dtg_consulta.Columns(j).Name <> "Comp" And dtg_consulta.Columns(j).Name <> "TotExt" And dtg_consulta.Columns(j).Name <> "ED" And dtg_consulta.Columns(j).Name <> "EN" And dtg_consulta.Columns(j).Name <> "EDF" And dtg_consulta.Columns(j).Name <> "ENF" And dtg_consulta.Columns(j).Name <> "motivo_extras" And dtg_consulta.Columns(j).Name <> "ValExt" And dtg_consulta.Columns(j).Name <> "basico_hora") Then
                    If (dtg_consulta.Item(j, dtg_consulta.Rows.Count - 2).Value = "True" Or dtg_consulta.Item(j, dtg_consulta.Rows.Count - 1).Value = "True") Then
                        dom_fest = True
                    Else
                        dom_fest = False
                    End If
                    If (dtg_consulta.Item(j, dtg_consulta.Rows.Count - 4).Value = "True") Then
                        sabado = True
                    Else
                        sabado = False
                    End If
                    If Not IsDBNull(dtg_consulta.Item(j, fila).Value) Then
                        idTurno = getPrimerIdTurno(j, fila)
                        extras_turno = get_extras_turno(idTurno)
                        ord_turno = get_ordinarias_turno(idTurno)
                        If idTurno = 3 Or idTurno = 9 Or idTurno = 13 Or idTurno = 15 Or idTurno = 19 Then
                            turno_noche = True
                        Else
                            turno_noche = False
                        End If
                        If dom_fest = True Then
                            If turno_noche Then
                                en += extras_turno
                            Else
                                edf += ord_turno + extras_turno
                            End If
                        ElseIf sabado Then
                            If turno_noche Then
                                enf += ord_turno + extras_turno
                            Else
                                ed += extras_turno
                            End If
                        Else
                            If turno_noche Then
                                en += extras_turno
                            Else
                                ed += extras_turno
                            End If
                        End If
                    End If
                End If
            Next
            If ed > 0 Then
                valor = valor_horas(13, ed, basico_hora)
                dtg_consulta.Item("ED", fila).Value = ed
                dtg_consulta.Item("ED", fila).ToolTipText = " Valor $" & valor.ToString("N0")
                vr_tot_extras += valor
            End If
            If en > 0 Then
                valor = valor_horas(9, en, basico_hora)
                dtg_consulta.Item("EN", fila).Value = en
                dtg_consulta.Item("EN", fila).ToolTipText = " Valor $" & valor.ToString("N0")
                vr_tot_extras += valor
            End If
            If edf > 0 Then
                valor = valor_horas(15, edf, basico_hora)
                dtg_consulta.Item("EDF", fila).Value = edf
                dtg_consulta.Item("EDF", fila).ToolTipText = " Valor $" & valor.ToString("N0")
                vr_tot_extras += valor
            End If
            If enf > 0 Then
                valor = valor_horas(15, enf, basico_hora)
                dtg_consulta.Item("ENF", fila).Value = enf
                dtg_consulta.Item("ENf", fila).ToolTipText = " Valor $" & valor.ToString("N0")
                vr_tot_extras += valor
            End If
            dtg_consulta.Item("TotExt", fila).Value = ed + en + edf + enf
            dtg_consulta.Item("ValExt", fila).Value = vr_tot_extras
        End If
    End Sub
    Private Function valor_horas(ByVal concepto As Integer, ByVal horas As Integer, ByVal basico_hora As Double) As Double
        Dim valor As Double = 0
        Dim porc_concepto As Double = 0
        For i = 0 To dt_porc_conceptos.Rows.Count - 1
            If dt_porc_conceptos.Rows(i).Item("concepto") = concepto Then
                porc_concepto = dt_porc_conceptos.Rows(i).Item("porc_basico")
                i = dt_porc_conceptos.Rows.Count - 1
            End If
        Next
        valor = (basico_hora * horas) * (porc_concepto / 100)
        Return valor
    End Function
    Private Function get_extras_turno(ByVal id_turno As Integer) As Double
        Dim horas As Double = 0
        For i = 0 To dt_turnos.Rows.Count - 1
            If dt_turnos.Rows(i).Item("id") = id_turno Then
                horas = dt_turnos.Rows(i).Item("extras")
                i = dt_turnos.Rows.Count - 1
            End If
        Next
        Return horas
    End Function
    Private Function get_ordinarias_turno(ByVal id_turno As Integer) As Double
        Dim horas As Double = 0
        For i = 0 To dt_turnos.Rows.Count - 1
            If dt_turnos.Rows(i).Item("id") = id_turno Then
                horas = dt_turnos.Rows(i).Item("ord_diur")
                i = dt_turnos.Rows.Count - 1
            End If
        Next
        Return horas
    End Function
    Private Sub add_programacion(ByRef dt As DataTable)
        Dim where_centro As String = ""
        Dim where_nit As String = ""
        If cbo_centro.SelectedValue <> 0 Then
            where_centro = " AND v.centro =" & cbo_centro.SelectedValue & " "
        Else
            where_centro = " AND v.centro IN(" & centros & ") "
        End If
        If cbo_operario.SelectedValue <> 0 Then
            where_centro = " AND v.nit =" & cbo_operario.SelectedValue
        End If
        Dim sql_programacion As String = "SELECT e.id,e.nit,e.periodo , d.fecha,CAST(d.turno as varchar) + ' - ' + t.Descripcion As turno,t.id as id_turno, t.ord_diur ,t.ord_noct , t.extras , e.motivo_extras " & _
                                            "FROM J_prog_turno_enc e , J_prog_turno_det d , CORSAN.dbo.J_turnos t ,CORSAN.dbo.V_nom_personal_Activo_con_maquila v " & _
                                                "WHERE v.nit = e.nit AND e.id = d.id_enc AND t.id = d.turno  AND e.periodo = " & id_periodo & " " & where_centro & where_nit & _
                                                    "ORDER BY e.nit"
        Dim dt_programacion As DataTable = objOpSimplesLn.listar_datatable(sql_programacion, "CONTROL")
        Dim nit As Double = 0
        Dim nom_dia As String = ""
        Dim fec As Date
        For i = 0 To dt_programacion.Rows.Count - 1
            nit = dt_programacion.Rows(i).Item("nit")
            For k = 0 To dt.Rows.Count - 1
                If Not IsDBNull(dt.Rows(k).Item("nit")) Then
                    If (dt.Rows(k).Item("nit") = nit) Then
                        dt.Rows(k).Item("motivo_extras") = dt_programacion.Rows(i).Item("motivo_extras")
                        If IsNumeric(dt.Rows(k).Item("TotExt")) Then
                            dt.Rows(k).Item("TotExt") += dt_programacion.Rows(i).Item("extras")
                        Else
                            dt.Rows(k).Item("TotExt") = dt_programacion.Rows(i).Item("extras")
                        End If
                        For j = 0 To dt.Columns.Count - 1
                            If (dt.Columns(j).ColumnName <> "nit" And dt.Columns(j).ColumnName <> "nombres" And dt.Columns(j).ColumnName <> "centro" And dt.Columns(j).ColumnName <> "oficio" And dt.Columns(j).ColumnName <> "contrato" And dt.Columns(j).ColumnName <> "planta" And dt.Columns(j).ColumnName <> "turno" And dt.Columns(j).ColumnName <> "id" And dt.Columns(j).ColumnName <> "Nov" And dt.Columns(j).ColumnName <> "Comp" And dt.Columns(j).ColumnName <> "TotExt" And dt.Columns(j).ColumnName <> "motivo_extras" And dt.Columns(j).ColumnName <> "ED" And dt.Columns(j).ColumnName <> "EN" And dt.Columns(j).ColumnName <> "EDF" And dt.Columns(j).ColumnName <> "ENF" And dt.Columns(j).ColumnName <> "ValExt" And dt.Columns(j).ColumnName <> "basico_hora") Then
                                fec = dt_programacion.Rows(i).Item("fecha")
                                nom_dia = WeekdayName(Weekday(fec), True, 1) & fec.Day & "-" & MonthName(fec.Month)
                                If (fec = dt.Rows(dt.Rows.Count - 3).Item(j) And (dt.Rows(dt.Rows.Count - 1).Item(j) = "True" Or dt.Rows(dt.Rows.Count - 2).Item(j) = "True")) Then
                                    If Not objRelojLn.verificar_desc_compensatorio(nit, fec, dt_programacion, "fecha", "id_turno") Then
                                        If IsNumeric(dt.Rows(k).Item("TotExt")) Then
                                            dt.Rows(k).Item("TotExt") += dt_programacion.Rows(i).Item("ord_diur")
                                            dt.Rows(k).Item("TotExt") += dt_programacion.Rows(i).Item("ord_noct")
                                        Else
                                            dt.Rows(k).Item("TotExt") = dt_programacion.Rows(i).Item("ord_diur")
                                            dt.Rows(k).Item("TotExt") = dt_programacion.Rows(i).Item("ord_noct")
                                        End If
                                    End If
                                End If
                                If dt.Columns(j).ColumnName = nom_dia Then
                                    If IsDBNull(dt.Rows(k).Item(j)) Then
                                        dt.Rows(k).Item(j) = dt_programacion.Rows(i).Item("turno")
                                    Else
                                        dt.Rows(k).Item(j) &= " & " & dt_programacion.Rows(i).Item("turno")
                                    End If
                                    dt.Rows(k).Item("id") = dt_programacion.Rows(i).Item("id")
                                End If
                            End If
                        Next
                    End If
                End If
            Next
        Next

    End Sub
    Private Sub addDias(ByRef dt As DataTable)
        Dim id_periodo As Integer = cbo_periodo.SelectedValue
        Dim nom_dia As String = ""
        Dim sql As String = "SELECT fecha,sabado,domingo,festivo FROM y_calendario WHERE fecha>= '" & objOpSimplesLn.cambiarFormatoFecha(fec_ini) & "' AND fecha <= '" & objOpSimplesLn.cambiarFormatoFecha(fec_fin) & "' order by fecha"
        Dim dt_dias As DataTable = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        Dim fec As Date
        For i = 0 To dt_dias.Rows.Count - 1
            fec = dt_dias.Rows(i).Item("fecha")
            nom_dia = WeekdayName(Weekday(fec), True, 1) & fec.Day & "-" & MonthName(fec.Month)
            dt.Columns.Add(nom_dia)
            dt.Rows(dt.Rows.Count - 4).Item(nom_dia) = dt_dias.Rows(i).Item("sabado")
            dt.Rows(dt.Rows.Count - 3).Item(nom_dia) = dt_dias.Rows(i).Item("fecha")
            dt.Rows(dt.Rows.Count - 2).Item(nom_dia) = dt_dias.Rows(i).Item("domingo")
            dt.Rows(dt.Rows.Count - 1).Item(nom_dia) = dt_dias.Rows(i).Item("festivo")
        Next
    End Sub
    Private Sub pintar_dtg()
        Dim nom_dia_hoy As String = WeekdayName(Weekday(Now), True, 1) & Now.Day & "-" & MonthName(Now.Month)
        Dim nit As Double = 0
        For i = 0 To dtg_consulta.Rows.Count - 1
            If Not IsDBNull(dtg_consulta.Item("nit", i).Value) Then
                nit = dtg_consulta.Item("nit", i).Value
            End If
            If (dtg_consulta.Item("nombres", i).Value = "domingo" Or dtg_consulta.Item("nombres", i).Value = "festivo") Then
                For j = 0 To dtg_consulta.Columns.Count - 1
                    If (dtg_consulta.Columns(j).Name <> "TotExt" And dtg_consulta.Columns(j).Name <> "nit" And dtg_consulta.Columns(j).Name <> "nombres" And dtg_consulta.Columns(j).Name <> "centro" And dtg_consulta.Columns(j).Name <> "oficio" And dtg_consulta.Columns(j).Name <> "contrato" And dtg_consulta.Columns(j).Name <> "planta" And dtg_consulta.Columns(j).Name <> "turno" And dtg_consulta.Columns(j).Name <> "id" And dtg_consulta.Columns(j).Name <> "Nov" And dtg_consulta.Columns(j).Name <> "motivo_extras" And dtg_consulta.Columns(j).Name <> "ED" And dtg_consulta.Columns(j).Name <> "EN" And dtg_consulta.Columns(j).Name <> "EDF" And dtg_consulta.Columns(j).Name <> "ENF" And dtg_consulta.Columns(j).Name <> "ValExt" And dtg_consulta.Columns(j).Name <> "basico_hora") Then
                        If Not IsDBNull(dtg_consulta.Item(j, i).Value) Then
                            If (dtg_consulta.Item(j, i).Value = "True") Then
                                dtg_consulta.Columns(j).DefaultCellStyle.BackColor = Color.LightBlue
                            End If
                        End If
                    End If
                Next
            End If
            If Not IsDBNull(dtg_consulta.Item("Comp", i).Value) Then
                If (dtg_consulta.Item("Comp", i).Value > 0) Then
                    dtg_consulta.Item("Comp", i).Style.BackColor = Color.Yellow
                    dtg_consulta.Item("nit", i).Style.BackColor = Color.Yellow
                    dtg_consulta.Item("nombres", i).Style.BackColor = Color.Yellow
                End If
            End If
            If i < dtg_consulta.Rows.Count - 4 Then
                For j = 0 To dtg_consulta.Columns.Count - 1
                    If (dtg_consulta.Columns(j).Name <> "TotExt" And dtg_consulta.Columns(j).Name <> "nit" And dtg_consulta.Columns(j).Name <> "nombres" And dtg_consulta.Columns(j).Name <> "centro" And dtg_consulta.Columns(j).Name <> "oficio" And dtg_consulta.Columns(j).Name <> "contrato" And dtg_consulta.Columns(j).Name <> "planta" And dtg_consulta.Columns(j).Name <> "turno" And dtg_consulta.Columns(j).Name <> "id" And dtg_consulta.Columns(j).Name <> "Comp" And dtg_consulta.Columns(j).Name <> "Nov" And dtg_consulta.Columns(j).Name <> "motivo_extras" And dtg_consulta.Columns(j).Name <> "ValExt" And dtg_consulta.Columns(j).Name <> "basico_hora" And dtg_consulta.Columns(j).Name <> "ED" And dtg_consulta.Columns(j).Name <> "EN" And dtg_consulta.Columns(j).Name <> "EDF" And dtg_consulta.Columns(j).Name <> "ENF") Then
                        If Not IsDBNull(dtg_consulta.Item(j, i).Value) Then
                            If getPrimerIdTurno(j, i) = 100 Or getSegundoIdTurno(j, i) = 100 Then
                                'Incapacidad
                                dtg_consulta.Item(j, i).Style.BackColor = Color.Red
                            ElseIf getPrimerIdTurno(j, i) = 101 Or getSegundoIdTurno(j, i) = 101 Then
                                'Vacaciones
                                dtg_consulta.Item(j, i).Style.BackColor = Color.GreenYellow
                            End If
                        End If
                    End If
                Next
            End If
        Next

    End Sub
    Private Sub itemMod_Click(sender As Object, e As EventArgs) Handles itemMod.Click
        filaSelect = dtg_consulta.CurrentCell.RowIndex
        colSelect = dtg_consulta.CurrentCell.ColumnIndex
        groupTurno.Visible = True
    End Sub

    Private Sub dtgTurno_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgTurno.CellClick
        If (e.RowIndex >= 0) Then
            If dtgTurno.Columns(e.ColumnIndex).Name = "id" Or dtgTurno.Columns(e.ColumnIndex).Name = "descripcion" Then
                If Not objRelojLn.verificar_periodo_liquidado(id_periodo) Then
                    Dim codigo As String = dtgTurno.Item("id", e.RowIndex).Value
                    Dim codigo_no_trab As String = ""
                    Dim descripcion As String = dtgTurno.Item("descripcion", e.RowIndex).Value
                    Dim iResponce As Integer = 0
                    Dim dom_fest As Boolean = False
                    Dim sabado As Boolean = False
                    Dim terminar As Boolean = False
                    Dim permiso_Extra_fest As Boolean = True
                    If (colSelect >= 2) Then
                        For i = colSelect To dtg_consulta.Columns.Count - 1
                            If (dtg_consulta.Columns(i).Name <> "TotExt" And dtg_consulta.Columns(i).Name <> "nit" And dtg_consulta.Columns(i).Name <> "nombres" And dtg_consulta.Columns(i).Name <> "centro" And dtg_consulta.Columns(i).Name <> "oficio" And dtg_consulta.Columns(i).Name <> "contrato" And dtg_consulta.Columns(i).Name <> "planta" And dtg_consulta.Columns(i).Name <> "turno" And dtg_consulta.Columns(i).Name <> "id" And dtg_consulta.Columns(i).Name <> "Nov" And dtg_consulta.Columns(i).Name <> "motivo_extras" And dtg_consulta.Columns(i).Name <> "TotExt" And dtg_consulta.Columns(i).Name <> "ED" And dtg_consulta.Columns(i).Name <> "EN" And dtg_consulta.Columns(i).Name <> "EDF" And dtg_consulta.Columns(i).Name <> "ENF" And dtg_consulta.Columns(i).Name <> "ValExt" And dtg_consulta.Columns(i).Name <> "basico_hora") Then
                                If (dtg_consulta.Item(i, dtg_consulta.Rows.Count - 2).Value = "True" Or dtg_consulta.Item(i, dtg_consulta.Rows.Count - 1).Value = "True") Then
                                    dom_fest = True
                                    permiso_Extra_fest = permiso_modificar_turno_festivo()
                                Else
                                    dom_fest = False
                                End If

                                If (permiso_Extra_fest Or codigo = 99 Or getPrimerIdTurno(i, filaSelect) = 0 Or getPrimerIdTurno(i, filaSelect) = 100 Or getPrimerIdTurno(i, filaSelect) = 101) Then
                                    If (dtg_consulta.Item(i, dtg_consulta.Rows.Count - 4).Value = "True") Then
                                        sabado = True
                                    Else
                                        sabado = False
                                    End If
                                    If codigo <> 0 Then
                                        If (i = colSelect) Then
                                            If IsDBNull(dtg_consulta.Item(i, filaSelect).Value) Then
                                                dtg_consulta.Item(i, filaSelect).Value = codigo & " - " & descripcion
                                            Else
                                                If getPrimerIdTurno(i, filaSelect) = 0 Then
                                                    dtg_consulta.Item(i, filaSelect).Value = codigo & " - " & descripcion
                                                ElseIf codigo = 0 Or codigo = 100 Or codigo = 101 Then
                                                    dtg_consulta.Item(i, filaSelect).Value = codigo & " - " & descripcion
                                                Else
                                                    iResponce = MessageBox.Show("Desea agregar un segundo turno al día (" & dtg_consulta.Columns(i).HeaderText & ")? ", "Atención", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                                                    If (iResponce = 6) Then
                                                        If (valiar_dos_turnos_dia(i, filaSelect)) Then
                                                            MessageBox.Show("Ya se asignaron el máximo de turnos para este día", "Verifique!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                                        Else
                                                            If codigo = 99 Or codigo = 100 Then
                                                                If Not IsDBNull(dtg_consulta.Item(i, filaSelect).Value) Then
                                                                    restarExtras(i, dom_fest)
                                                                End If
                                                                dtg_consulta.Item(i, filaSelect).Value = codigo & " - " & descripcion & " & " & dtg_consulta.Item(i, filaSelect).Value
                                                            Else
                                                                dtg_consulta.Item(i, filaSelect).Value &= " & " & codigo & " - " & descripcion
                                                            End If

                                                        End If
                                                    Else
                                                        If dtg_consulta.Item(i, filaSelect).Value <> "" Then
                                                            restarExtras(i, dom_fest)
                                                        End If
                                                        dtg_consulta.Item(i, filaSelect).Value = codigo & " - " & descripcion
                                                    End If
                                                End If
                                                If codigo <> 99 Then
                                                    iResponce = MessageBox.Show("Desea replicar el turno por el resto de la programación? ", "Atención", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                                                    If (iResponce <> 6) Then
                                                        terminar = True
                                                    End If
                                                Else
                                                    terminar = True
                                                End If
                                            End If
                                        Else
                                            If (dom_fest) Then
                                                ' para que en los turnos de 12 horas noche  comienzen el domingo y no trabajen el sabado
                                                If codigo = 3 Or codigo = 11 Then
                                                    dtg_consulta.Item(i, filaSelect).Value = codigo & " - " & descripcion
                                                Else
                                                    If IsDBNull(dtg_consulta.Item(i, filaSelect).Value) Then
                                                        dtg_consulta.Item(i, filaSelect).Value = 0 & " - " & "NO TRABAJA"
                                                    End If
                                                End If
                                            ElseIf sabado Then
                                                If codigo = 4 Or codigo = 5 Or codigo = 6 Or codigo = 3 Or codigo = 11 Or codigo = 20 Or codigo = 21 Then
                                                    dtg_consulta.Item(i, filaSelect).Value = 0 & " - " & "NO TRABAJA"
                                                Else
                                                    If IsDBNull(dtg_consulta.Item(i, filaSelect).Value) Then
                                                        dtg_consulta.Item(i, filaSelect).Value = codigo & " - " & descripcion
                                                    Else
                                                        restarExtras(i, dom_fest)
                                                        dtg_consulta.Item(i, filaSelect).Value = codigo & " - " & descripcion
                                                    End If
                                                End If
                                            Else
                                                If IsDBNull(dtg_consulta.Item(i, filaSelect).Value) Then
                                                    dtg_consulta.Item(i, filaSelect).Value = codigo & " - " & descripcion
                                                Else
                                                    restarExtras(i, dom_fest)
                                                    dtg_consulta.Item(i, filaSelect).Value = codigo & " - " & descripcion
                                                End If
                                            End If
                                        End If
                                    Else
                                        If Not IsDBNull(dtg_consulta.Item(i, filaSelect).Value) Then
                                            If dtg_consulta.Item(i, filaSelect).Value <> "" Then
                                                restarExtras(i, dom_fest)
                                            End If
                                        End If
                                        dtg_consulta.Item(i, filaSelect).Value = codigo & " - " & descripcion
                                        terminar = True
                                    End If
                                Else
                                    MessageBox.Show("se excedió el número máximo de horas extras dominicales permitidas durante el mes, no se permite programar este dominical-festivo", "No se permite autorizar esta marcación!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                    dtg_consulta.Item(i, filaSelect).Value = 0 & " - " & "NO TRABAJA"
                                    groupTurno.Visible = False
                                End If
                            End If
                            calcular_extras_turno(filaSelect)
                            If terminar Then
                                i = dtg_consulta.Columns.Count - 1
                            End If
                        Next
                    Else
                        dtg_consulta.Item(colSelect, filaSelect).Value = codigo & " - " & descripcion
                    End If
                    pintar_dtg()
                    If verificarExtras(filaSelect) Then
                        If IsNumeric(dtg_consulta.Item("motivo_extras", filaSelect).Value) Then
                            If dtg_consulta.Item("motivo_extras", filaSelect).Value = 0 Then
                                group_motivo_extras.Visible = True
                            Else
                                motivo_extras = dtg_consulta.Item("motivo_extras", filaSelect).Value
                                guardar(filaSelect)
                            End If
                        Else
                            group_motivo_extras.Visible = True
                        End If
                    Else
                        guardar(filaSelect)
                    End If
                Else
                    MessageBox.Show("Este periodo se encuentra liquidado, por lo tanto no se permite hacer cambios en turnos ni ingresar novedades", "Periodo liquidado sin turno", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
                groupTurno.Visible = False
            End If
        End If
    End Sub
    Private Sub restarExtras(ByVal num_col As Integer, ByVal dom_fest As Boolean)
        Dim id_turno As Integer = getPrimerIdTurno(num_col, filaSelect)
        Dim sql As String = "SELECT extras,ord_diur,ord_noct FROM j_turnos WHERE id = " & id_turno
        Dim dt_turno As DataTable = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        For i = 0 To dt_turno.Rows.Count - 1
            If IsNumeric(dtg_consulta("TotExt", filaSelect).Value) Then
                dtg_consulta("TotExt", filaSelect).Value -= dt_turno.Rows(i).Item("extras")
            End If
            If dom_fest Then
                If IsNumeric(dtg_consulta("TotExt", filaSelect).Value) Then
                    dtg_consulta("TotExt", filaSelect).Value -= dt_turno.Rows(i).Item("ord_diur")
                    dtg_consulta("TotExt", filaSelect).Value -= dt_turno.Rows(i).Item("ord_noct")
                End If
            End If
        Next
    End Sub
    Private Function valiar_dos_turnos_dia(ByVal col As Integer, ByVal fila As Integer) As Boolean
        Dim cadena As String = dtg_consulta.Item(col, fila).Value.ToString.Trim
        Dim resp As Boolean = False
        If cadena <> "" Then
            For i = 0 To cadena.Length - 1
                If (cadena(i) = "&") Then
                    resp = True
                End If
            Next
        End If
        Return resp
    End Function
    Private Sub calcular_horas__________(ByVal fila As Integer)
        Dim es_domingo_compensatorio As Boolean = False
        Dim idTurno As Integer = 0
        Dim horas_diur As Integer = 0
        Dim horas_noct As Integer = 0
        Dim horas_fest_diur As Integer = 0
        Dim horas_fest_noct As Integer = 0
        Dim horas_ext_fest As Integer = 0
        Dim horas_extras As Integer = 0
        Dim horas_no_aut As Integer = 0
        Dim dif As Integer = 0
        Dim dif_no_aut As Integer = 0
        Dim dom_fest_no_lab As Integer = 0
        Dim desc_compensatorio As Integer = 0
        Dim dom_fest As Boolean = False
        For i = 0 To dtg_consulta.Columns.Count - 1
            If (dtg_consulta.Columns(i).Name <> "TotExt" And dtg_consulta.Columns(i).Name <> "nit" And dtg_consulta.Columns(i).Name <> "nombres" And dtg_consulta.Columns(i).Name <> "centro" And dtg_consulta.Columns(i).Name <> "oficio" And dtg_consulta.Columns(i).Name <> "contrato" And dtg_consulta.Columns(i).Name <> "planta" And dtg_consulta.Columns(i).Name <> "turno" And dtg_consulta.Columns(i).Name <> "id" And dtg_consulta.Columns(i).Name <> "Nov" And dtg_consulta.Columns(i).Name <> "motivo_extras" And dtg_consulta.Columns(i).Name <> "ED" And dtg_consulta.Columns(i).Name <> "EN" And dtg_consulta.Columns(i).Name <> "EDF" And dtg_consulta.Columns(i).Name <> "ENF" And dtg_consulta.Columns(i).Name <> "ValExt" And dtg_consulta.Columns(i).Name <> "basico_hora") Then
                If (dtg_consulta.Item(i, dtg_consulta.Rows.Count - 2).Value = "True" Or dtg_consulta.Item(i, dtg_consulta.Rows.Count - 1).Value = "True") Then
                    dom_fest = True
                Else
                    dom_fest = False
                End If
                If (valiar_dos_turnos_dia(i, fila)) Then
                    For z = 0 To 1
                        If z = 0 Then
                            idTurno = getPrimerIdTurno(i, fila)
                            If idTurno = 99 Then
                                es_domingo_compensatorio = True
                            End If
                        Else
                            idTurno = getSegundoIdTurno(i, fila)
                        End If
                        For k = 0 To dt_turnos.Rows.Count - 1
                            If (dt_turnos.Rows(k).Item("id") = idTurno) Then
                                If dt_turnos.Rows(k).Item("ord_diur") <> 0 Then
                                    If (dom_fest) Then
                                        If es_domingo_compensatorio Then
                                            horas_fest_diur += dt_turnos.Rows(k).Item("ord_diur")
                                        Else
                                            horas_ext_fest += dt_turnos.Rows(k).Item("ord_diur")
                                        End If

                                    Else
                                        horas_diur += dt_turnos.Rows(k).Item("ord_diur")
                                    End If
                                End If
                                If (dt_turnos.Rows(k).Item("Ord_noct") <> 0) Then
                                    If (dom_fest) Then
                                        If es_domingo_compensatorio Then
                                            horas_fest_noct += dt_turnos.Rows(k).Item("Ord_noct")
                                        Else
                                            horas_ext_fest += dt_turnos.Rows(k).Item("Ord_noct")
                                        End If
                                    Else
                                        horas_noct += dt_turnos.Rows(k).Item("Ord_noct")
                                    End If
                                End If
                                If (dt_turnos.Rows(k).Item("extras") <> 0) Then
                                    If (dom_fest) Then
                                        horas_ext_fest += dt_turnos.Rows(k).Item("extras")
                                    Else
                                        horas_extras += dt_turnos.Rows(k).Item("extras")
                                    End If

                                End If
                                If (dt_turnos.Rows(k).Item("compensatorio") <> 0) Then
                                    If Not es_domingo_compensatorio Then
                                        desc_compensatorio = dt_turnos.Rows(k).Item("compensatorio")
                                    End If

                                End If
                                k = dt_turnos.Rows.Count - 1
                            End If
                        Next
                    Next
                Else
                    idTurno = getPrimerIdTurno(i, fila)
                    For k = 0 To dt_turnos.Rows.Count - 1
                        If (dt_turnos.Rows(k).Item("id") = idTurno) Then
                            If dt_turnos.Rows(k).Item("ord_diur") <> 0 Then
                                If (dom_fest) Then
                                    horas_ext_fest += dt_turnos.Rows(k).Item("ord_diur")
                                Else
                                    horas_diur += dt_turnos.Rows(k).Item("ord_diur")
                                End If
                            End If
                            If (dt_turnos.Rows(k).Item("Ord_noct") <> 0) Then
                                If (dom_fest) Then
                                    horas_ext_fest += dt_turnos.Rows(k).Item("ord_noct")
                                Else
                                    horas_noct += dt_turnos.Rows(k).Item("ord_noct")
                                End If
                            End If
                            If (dt_turnos.Rows(k).Item("extras") <> 0) Then
                                If (dom_fest) Then
                                    horas_ext_fest += dt_turnos.Rows(k).Item("extras")
                                Else
                                    horas_extras += dt_turnos.Rows(k).Item("extras")
                                End If
                            End If
                            If (dt_turnos.Rows(k).Item("compensatorio") <> 0) Then
                                desc_compensatorio = dt_turnos.Rows(k).Item("compensatorio")
                            End If
                            k = dt_turnos.Rows.Count - 1
                        End If
                    Next
                End If
                If dom_fest Then
                    If Not es_domingo_compensatorio Then
                        dom_fest_no_lab += 8
                    End If
                End If
                es_domingo_compensatorio = False
            End If
        Next

        If ((horas_diur + horas_noct + desc_compensatorio) > horas_laborales) Then
            dif_no_aut = (horas_diur + horas_noct + desc_compensatorio) - horas_laborales
            If (horas_diur > horas_noct) Then
                horas_diur -= dif_no_aut
            Else
                horas_noct -= dif_no_aut
            End If
        End If

        If (horas_diur > 0 Or horas_noct > 0) Then
            If (horas_diur + horas_noct + desc_compensatorio) < horas_laborales Then
                dif = (horas_laborales - (horas_diur + horas_noct + desc_compensatorio))
                If (horas_extras > 0) Then
                    If (horas_diur > horas_noct) Then
                        horas_diur += dif
                    Else
                        horas_noct += dif
                    End If
                    horas_extras -= dif
                End If
            End If
        End If
        dtg_consulta.Item("OrD", fila).Value = horas_diur
        dtg_consulta.Item("RN", fila).Value = horas_noct
        dtg_consulta.Item("TotExt", fila).Value = horas_extras
        dtg_consulta.Item("OrNoAut", fila).Value = horas_no_aut
        dtg_consulta.Item("DD", fila).Value = horas_fest_diur
        dtg_consulta.Item("DN", fila).Value = horas_fest_noct
        dtg_consulta.Item("ExtF", fila).Value = horas_ext_fest
        dtg_consulta.Item("DF", fila).Value = dom_fest_no_lab
        dtg_consulta.Item("DComp", fila).Value = desc_compensatorio
    End Sub
    Private Sub btn_cerrar_graf_Click(sender As Object, e As EventArgs) Handles btn_cerrar_graf.Click
        groupTurno.Visible = False
    End Sub
    Private Sub dtg_consulta_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dtg_consulta.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            With (Me.dtg_consulta)
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                End If
            End With
            colSelect = dtg_consulta.CurrentCell.ColumnIndex
            filaSelect = dtg_consulta.CurrentCell.RowIndex
            If objRelojLn.verificar_periodo_liquidado(id_periodo) Then
                ' MessageBox.Show("El periodo seleccionado ya se encuentra liquidado, por lo tanto no se permiten modificaciones", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                habilitar_click(False)
            Else
                habilitar_click(True)
            End If
        End If
    End Sub
    Private Sub habilitar_click(ByVal estado As Boolean)
        estado = True
        itemMod.Enabled = estado
        IngresarNovedadToolStripMenuItem.Enabled = estado
        EliminarTurnoToolStripMenuItem.Enabled = estado
    End Sub
    Private Sub dtg_consulta_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dtg_consulta.CellValueChanged
        If (dtg_consulta.Columns(e.ColumnIndex).Name = "TotExt" And carga_comp) Then
            If Not IsNumeric(dtg_consulta.Item(e.ColumnIndex, e.RowIndex).Value) Then
                dtg_consulta.Item(e.ColumnIndex, e.RowIndex).Value = ""
                MessageBox.Show("El valor ingresado Comp er númerico", "Verifique!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
    End Sub
    Private Sub dtg_consulta_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dtg_consulta.DataError

    End Sub

    Private Sub btn_ok_novedad_Click(sender As Object, e As EventArgs) Handles btn_ok_novedad.Click
        ingresar_novedad()
    End Sub
    Private Sub ingresar_novedad()
        If validar_novedad() Then
            Dim listSql As New List(Of Object)
            Dim nit As Double = dtg_consulta.Item("nit", filaSelect).Value
            Dim concepto As Double = txt_concepto.Text
            Dim sql As String = ""
            Dim sql_val As String
            Dim val_horas As String
            Dim calc_90 As Double
            Dim contrato As Double = dtg_consulta.Item("contrato", filaSelect).Value
            Dim fecha As String = objOpSimplesLn.cambiarFormatoFecha(cbo_fec_novedad.Value)
            Dim valor As Integer = txtValNov.Text
            Dim horas As Double = txt_horas_novedad.Text
            Dim centro As Integer = dtg_consulta.Item("centro", filaSelect).Value
            Dim planta As Integer = dtg_consulta.Item("planta", filaSelect).Value
            Dim turno As Integer = dtg_consulta.Item("turno", filaSelect).Value
            Dim oficio As Integer = dtg_consulta.Item("oficio", filaSelect).Value
            Dim observaciones As String = txt_observaciones_novedad.Text
            Dim nom_usuario As String = usuario.nombresCompleto
            Dim correcto As Boolean = True
            sql = objRelojLn.sql_novedad_no_aut(nit, concepto, id_periodo, fecha, contrato, valor, horas, centro, planta, turno, oficio, observaciones, nom_usuario)
            listSql.Add(sql)
            If concepto = 90 Then
                sql_val = "SELECT horas_restante FROM R_compromiso_horas_concepto_90 WHERE nit_trabajador=" & CInt(nit) & " AND año=" & Year(Now) & ""
                val_horas = objOpSimplesLn.consultValorTodo(sql_val, "CONTROL")

                If val_horas = "" Then
                    MessageBox.Show("Empleado no registrado en el concepto 9!", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
                MessageBox.Show("Se va ha ingresar permisos de horas libres,actualmente tiene disponible:" & val_horas & ",De 12 que son originalmente", "Permiso libre", MessageBoxButtons.OK, MessageBoxIcon.Information)
                If CDbl(val_horas) > 0 Then
                    If CDbl(val_horas) >= CDbl(horas) Then
                        calc_90 = CDbl(val_horas) - CDbl(horas)
                        MessageBox.Show("Horas disponibles que quedan:" & calc_90 & ",De 12 que son originalmente", "Permiso libre", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        sql_val = "UPDATE R_compromiso_horas_concepto_90 SET horas_restante=" & calc_90 & " WHERE nit_trabajador=" & nit & " AND año=" & Year(Now) & ""
                        objOpSimplesLn.ejecutar(sql_val, "CONTROL")
                        Dim id As Integer = objOpSimplesLn.consultValorTodo("SELECT  (SELECT CASE WHEN MAX(id) IS NULL THEN (1) ELSE MAX(id)+1 END) as id FROM R_compromiso_horas_a_pagar", "CONTROL")
                        Dim sql_compromiso As String = "INSERT INTO R_compromiso_horas_a_pagar (Id,Nit_Trabajador,Fecha_compromiso,Horas,Minutos_estaticos,Nombre_autoriza,Notas,Fecha_sistema,Activo,Horas_original,concepto_90)" &
                                                            " VALUES (" & id & "," & nit & ",GETDATE()," & horas & "," & 0 & ",'" & nom_usuario & "','" & observaciones & "',GETDATE(),1," & horas & "," & concepto & ")"
                        If (objOpSimplesLn.ejecutar(sql_compromiso, "CONTROL")) Then
                            MessageBox.Show("El compromiso se genero en forma correcta!", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Else
                            correcto = False
                            MessageBox.Show("Error al ingresar el registro,comuniquese con el administrador del sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    Else
                        correcto = False
                        MessageBox.Show("Las horas de la novedad sobrepasan el limite de horas que es:" & val_horas & "!", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If

                Else
                    correcto = False
                    MessageBox.Show("Se ha pasado el limite de 12 horas!", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End If
            If correcto Then
                If (objOpSimplesLn.ExecuteSqlTransaction(listSql)) Then
                    MessageBox.Show("La novedad se ingreso en forma correcta!", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    dtg_consulta.Item(colSelect, filaSelect).Style.BackColor = Color.Red
                    If Not IsDBNull(dtg_consulta.Item("Nov", filaSelect).Value) Then
                        dtg_consulta.Item("Nov", filaSelect).Value += horas
                    Else
                        dtg_consulta.Item("Nov", filaSelect).Value = horas
                    End If
                    group_novedad.Visible = False
                    txt_observaciones_novedad.Text = ""
                    txt_horas_novedad.Text = ""
                    txtValNov.Text = ""
                Else
                    MessageBox.Show("Error al ingresar el registro,comuniquese con el administrador del sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        End If
    End Sub

    Private Function getPrimerIdTurno(ByVal col As Integer, ByVal fila As Integer) As Integer
        Dim cadena As String = dtg_consulta.Item(col, fila).Value.ToString.Trim
        Dim id As String = ""
        If cadena <> "" Then
            For i = 0 To cadena.Length
                If (cadena(i) <> "-") Then
                    If (cadena(i) <> "&") Then
                        id &= cadena(i)
                    End If
                Else
                    i = cadena.Length
                End If
            Next
        Else
            id = 0
        End If
        Return id
    End Function
    Private Function getSegundoIdTurno(ByVal col As Integer, ByVal fila As Integer) As Integer
        Dim cadena As String = dtg_consulta.Item(col, fila).Value.ToString
        cadena = cadena.Replace(" "c, String.Empty)
        Dim id As String = ""
        Dim separador_encontrado As Boolean = False
        If cadena <> "" Then
            For i = 0 To cadena.Length - 1
                If (cadena(i) = "&" Or separador_encontrado) Then
                    separador_encontrado = True
                    If (cadena(i) <> "-" And cadena(i) <> "&") Then
                        id &= cadena(i)
                    ElseIf (cadena(i) = "-") Then
                        i = cadena.Length - 1
                    End If
                End If
            Next
        Else
            id = 0
        End If
        If id = "" Then
            id = 0
        End If
        Return id
    End Function
    Private Sub bloquear_group_novedad(ByVal estado As Boolean)
        cbo_fec_novedad.Enabled = estado
        txt_horas_novedad.Enabled = estado
        txtValNov.Enabled = estado
        btn_ok_novedad.Enabled = estado
        txt_observaciones_novedad.Enabled = estado
    End Sub
    Private Sub dtg_novedad_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtg_novedad.CellClick
        bloquear_group_novedad(True)
        txt_concepto.Text = dtg_novedad.Item("concepto", e.RowIndex).Value
        txt_desc_novedad.Text = dtg_novedad.Item("descripcion", e.RowIndex).Value
        If txt_concepto.Text = "43" Then
            txt_horas_novedad.Text = "0"
            txt_horas_novedad.Enabled = False
        Else
            txtValNov.Text = "0"
            txtValNov.Enabled = False
        End If
    End Sub
    Private Function validar_novedad() As Boolean
        Dim resp As Boolean = False
        If (txt_concepto.Text <> "") Then
            If (txt_horas_novedad.Text <> "") Then
                If (txtValNov.Text <> "") Then
                    If (txt_observaciones_novedad.Text <> "") Then
                        resp = True
                    Else
                        MessageBox.Show("debe ingresar la obervación de la novedad", "Ingrese obervación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                Else
                    MessageBox.Show("Comp ingresar el valor de la novedad", "Ingrese horas", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                MessageBox.Show("Comp ingresar las horas de la novedad", "Ingrese horas", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            MessageBox.Show("Seleccione un concepto para la novedad", "Seleccione concepto", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Return resp
    End Function

    Private Sub IngresarNovedadToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IngresarNovedadToolStripMenuItem.Click
        If IsDate(dtg_consulta.Item(colSelect, dtg_consulta.Rows.Count - 3).Value) Then
            bloquear_group_novedad(True)
            cbo_fec_novedad.Value = dtg_consulta.Item(colSelect, dtg_consulta.Rows.Count - 3).Value
            colSelect = dtg_consulta.CurrentCell.ColumnIndex
            filaSelect = dtg_consulta.CurrentCell.RowIndex
            group_novedad.Visible = True
            txt_concepto.Text = ""
            txt_desc_novedad.Text = ""
        Else
            MessageBox.Show("Seleccione una columna de fecha de programación para ingresar la novedad", "Seleccione columna de fecha", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub btn_cerrar_novedades_Click(sender As Object, e As EventArgs) Handles btn_cerrar_novedades.Click
        group_novedad.Visible = False
        txt_concepto.Text = ""
        txt_desc_novedad.Text = ""
    End Sub
    Private Sub soloNumero(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If (Char.IsDigit(e.KeyChar) Or e.KeyChar = ".") Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txt_horas_novedad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_horas_novedad.KeyPress
        soloNumero(e)
    End Sub
    Private Sub txtValNov_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtValNov.KeyPress
        soloNumero(e)
    End Sub
    Private Sub OtorgarPermisoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OtorgarPermisoToolStripMenuItem.Click
        If IsDate(dtg_consulta.Item(colSelect, dtg_consulta.Rows.Count - 3).Value) Then
            cboFechaPer.Value = dtg_consulta.Item(colSelect, dtg_consulta.Rows.Count - 3).Value
            group_permiso.Visible = True
            txt_observacion_permiso.Text = ""
        Else
            MessageBox.Show("Seleccione una columna de fecha de programación para ingresar el permiso", "Seleccione columna de fecha", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub btn_cerrar_permiso_Click(sender As Object, e As EventArgs) Handles btn_cerrar_permiso.Click
        group_permiso.Visible = False
        txt_observacion_permiso.Text = ""
    End Sub

    Private Sub btn_ok_permiso_Click(sender As Object, e As EventArgs) Handles btn_ok_permiso.Click
        If validar_permiso() Then
            Dim sql As String = ""
            Dim id As Integer = objOpSimplesLn.consultValorTodo("SELECT  (SELECT CASE WHEN MAX(id) IS NULL THEN (1) ELSE MAX(id)+1 END) as id FROM J_permiso_marcacion", "CONTROL")
            Dim fecha_permiso As String = objOpSimplesLn.cambiarFormatoFecha(cboFechaPer.Value)
            Dim motivo As String = txt_observacion_permiso.Text
            Dim nit As Double = dtg_consulta.Item("nit", filaSelect).Value
            Dim hora As String = Now.Hour & ":" & Now.Minute & ":00"
            Dim fecha_hora As String = fecha_permiso & " " & hora
            Dim hora_permiso As String = cbo_hora.Text & ":" & cbo_min.Text
            sql = "INSERT INTO J_permiso_marcacion (id,nit,fecha,hora_permiso,autoriza,notas) " & _
                    " VALUES (" & id & "," & nit & ",'" & fecha_hora & "','" & hora_permiso & "'," & usuario.nit & " ,'" & motivo & "' )"
            If (objOpSimplesLn.ejecutar(sql, "CONTROL") > 0) Then
                MessageBox.Show("El permiso se otorgo en forma correcta!", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information)
                group_permiso.Visible = False
                txt_observacion_permiso.Text = ""
                dtg_consulta.Item(colSelect, filaSelect).Style.BackColor = Color.Red
            Else
                MessageBox.Show("Error al ingresar el registro,comuniquese con el administrador del sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub
    Private Function validar_permiso() As Boolean
        Dim resp As Boolean = False
        If (txt_observacion_permiso.Text <> "") Then
            resp = True
        Else
            MessageBox.Show("Comp ingresar la obervación del permiso", "Ingrese obervación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Return resp
    End Function
    Private Sub CompromisoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CompromisoToolStripMenuItem.Click
        If IsDate(dtg_consulta.Item(colSelect, dtg_consulta.Rows.Count - 3).Value) Then
            cbo_fec_compromiso.Value = dtg_consulta.Item(colSelect, dtg_consulta.Rows.Count - 3).Value
            Dim sql As String = "SELECT id,Fecha_compromiso,Horas,Notas,Nombre_autoriza,nocturno " & _
                                        "FROM R_compromiso_horas_a_pagar " & _
                                                "WHERE activo = 'True' AND Nit_Trabajador = " & dtg_consulta.Item("nit", filaSelect).Value
            dtgCompromisos.DataSource = objOpSimplesLn.listar_datatable(sql, "CONTROL")
            group_compromiso.Visible = True
            txt_observaciones_compromiso.Text = ""
        Else
            MessageBox.Show("Seleccione una columna de fecha de programación para ingresar el compromiso", "Seleccione columna de fecha", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

    End Sub

    Private Sub btn_ok_compromiso_Click(sender As Object, e As EventArgs) Handles btn_ok_compromiso.Click
        If (validar_compromiso()) Then
            Dim sql_compromiso As String = ""
            Dim listSql As New List(Of Object)
            Dim id As Integer = objOpSimplesLn.consultValorTodo("SELECT  (SELECT CASE WHEN MAX(id) IS NULL THEN (1) ELSE MAX(id)+1 END) as id FROM R_compromiso_horas_a_pagar", "CONTROL")
            Dim fecha As String = objOpSimplesLn.cambiarFormatoFecha(cbo_fec_compromiso.Value)
            Dim motivo As String = txt_observaciones_compromiso.Text
            Dim nit As Double = dtg_consulta.Item("nit", filaSelect).Value
            Dim nombre_aut As String = usuario.nombresCompleto
            Dim hora As String = Now.Hour & ":" & Now.Minute & ":00"
            Dim tot_horas As Double = txt_horas_compromiso.Text
            Dim fecha_hora As String = fecha & " " & hora
            Dim Minutos_estaticos As Double = 0
            Dim desc_nocturno As String = ""
            If chk_comp_nocturno.Checked Then
                desc_nocturno = "S"
            Else
                desc_nocturno = "N"
            End If
            Dim iResponce = MessageBox.Show("Desea que se genere el permiso de salida?", "Generar permiso de salida", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
            If (iResponce = 6) Then
                Dim hora_permiso As String = cbo_hora_compromiso.Text & ":" & cbo_min_compromiso.Text
                Dim sql_permiso_salida As String = ""
                Dim id_permiso As Integer = objOpSimplesLn.consultValorTodo("SELECT  (SELECT CASE WHEN MAX(id) IS NULL THEN (1) ELSE MAX(id)+1 END) as id FROM J_permiso_marcacion", "CONTROL")
                sql_permiso_salida = "INSERT INTO J_permiso_marcacion (id,nit,fecha,hora_permiso,autoriza,notas) " & _
                        " VALUES (" & id_permiso & "," & nit & ",'" & fecha_hora & "','" & hora_permiso & "'," & usuario.nit & " ,'" & motivo & "' )"
                listSql.Add(sql_permiso_salida)
            End If
            sql_compromiso = "INSERT INTO R_compromiso_horas_a_pagar (Id,Nit_Trabajador,Fecha_compromiso,Horas,Minutos_estaticos,Nombre_autoriza,Notas,Fecha_sistema,Activo,nocturno,Horas_original)" & _
                   " VALUES (" & id & "," & nit & ",'" & fecha & "'," & tot_horas & "," & Minutos_estaticos & ",'" & nombre_aut & "','" & motivo & "','" & fecha_hora & "',1,'" & desc_nocturno & "'," & tot_horas & ")"
            listSql.Add(sql_compromiso)
            If (objOpSimplesLn.ExecuteSqlTransactionTodo(listSql, "CONTROL")) Then
                MessageBox.Show("El compromiso se realizo en forma correcta!", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information)
                group_compromiso.Visible = False
                txt_horas_compromiso.Text = ""
                txt_observaciones_compromiso.Text = ""
                dtg_consulta.Item(colSelect, filaSelect).Style.BackColor = Color.Red
                'If Not IsDBNull(dtg_consulta.Item("DComp", filaSelect).Value) Then
                '    dtg_consulta.Item("DComp", filaSelect).Value += tot_horas
                'Else
                '    dtg_consulta.Item("DComp", filaSelect).Value = tot_horas
                'End If
            Else
                MessageBox.Show("Error al ingresar el registro,comuniquese con el administrador del sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub
    Private Function validar_compromiso() As Boolean
        Dim resp As Boolean = False
        If (txt_horas_compromiso.Text <> "") Then
            If (txt_observaciones_compromiso.Text <> "") Then
                resp = True
            Else
                MessageBox.Show("Comp ingresar la obervación del compromiso", "Ingrese obervación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            MessageBox.Show("Comp ingresar las horas del compromiso", "Ingrese horas", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Return resp
    End Function

    Private Sub btn_cerrar_compromiso_Click(sender As Object, e As EventArgs) Handles btn_cerrar_compromiso.Click
        group_compromiso.Visible = False
        txt_horas_compromiso.Text = ""
        txt_observaciones_compromiso.Text = ""
    End Sub

    'Private Sub dtg_consulta_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtg_consulta.CellClick
    '    If (e.RowIndex >= 0) Then
    '        If (dtg_consulta.Columns(e.ColumnIndex).Name = col_guardar.Name) Then
    '            filaSelect = e.RowIndex
    '            If verificarExtras(e.RowIndex) Then
    '                group_motivo_extras.Visible = True
    '            Else
    '                guardar(e.RowIndex)
    '            End If

    '        End If
    '    End If
    'End Sub
    Private Sub guardar(ByVal fila As Integer)
        dtg_consulta.CurrentCell = Nothing
        If validar(fila) Then
            If motivo_extras <> 0 Or verificarExtras(fila) = False Then
                Dim list_sql As New List(Of Object)
                Dim id As Double = 0
                Dim nit As Double = dtg_consulta.Item("nit", fila).Value
                Dim sql_enc_gral As String = ""
                Dim sql_det_gral As String = ""
                Dim sql_det As String = ""
                Dim id_det As Integer = 0
                Dim turno As Integer = 0
                Dim fecha As String = ""
                Dim sql_delete As String = ""
                Dim exite_periodo_programado As Boolean = False
                If IsNumeric(dtg_consulta.Item("id", fila).Value) Then
                    id = dtg_consulta.Item("id", fila).Value
                    sql_delete = "DELETE FROM J_prog_turno_det WHERE id_enc = " & id
                    list_sql.Add(sql_delete)
                    sql_delete = "DELETE FROM J_prog_turno_enc WHERE id = " & id
                    list_sql.Add(sql_delete)
                Else
                    id = objOpSimplesLn.consultValorTodo("SELECT  (SELECT CASE WHEN MAX(id) IS NULL THEN (1) ELSE MAX(id)+1 END) as id FROM J_prog_turno_enc", "CONTROL")
                End If
                sql_enc_gral = "INSERT INTO J_prog_turno_enc (id,nit,periodo,motivo_extras) VALUES (" & id & "," & nit & "," & id_periodo & "," & motivo_extras & ")"
                list_sql.Add(sql_enc_gral)
                sql_det_gral = "INSERT INTO J_prog_turno_det (id_enc,id_det,fecha,turno) VALUES (" & id & ""
                For j = 0 To dtg_consulta.Columns.Count - 1
                    If (dtg_consulta.Columns(j).Name <> "nit" And dtg_consulta.Columns(j).Name <> "Comp" And dtg_consulta.Columns(j).Name <> "nombres" And dtg_consulta.Columns(j).Name <> "centro" And dtg_consulta.Columns(j).Name <> "oficio" And dtg_consulta.Columns(j).Name <> "contrato" And dtg_consulta.Columns(j).Name <> "planta" And dtg_consulta.Columns(j).Name <> "turno" And dtg_consulta.Columns(j).Name <> "id" And dtg_consulta.Columns(j).Name <> "TotExt" And dtg_consulta.Columns(j).Name <> "Nov" And dtg_consulta.Columns(j).Name <> "motivo_extras" And dtg_consulta.Columns(j).Name <> "ED" And dtg_consulta.Columns(j).Name <> "EN" And dtg_consulta.Columns(j).Name <> "EDF" And dtg_consulta.Columns(j).Name <> "ENF" And dtg_consulta.Columns(j).Name <> "basico_hora" And dtg_consulta.Columns(j).Name <> "ValExt") Then
                        If Not IsDBNull(dtg_consulta.Item(j, fila).Value) Then
                            If (valiar_dos_turnos_dia(j, fila)) Then
                                For i = 0 To 1
                                    id_det += 1
                                    If i = 0 Then
                                        turno = getPrimerIdTurno(j, fila)
                                    Else
                                        turno = getSegundoIdTurno(j, fila)
                                    End If
                                    fecha = objOpSimplesLn.cambiarFormatoFecha(dtg_consulta.Item(j, dtg_consulta.Rows.Count - 3).Value)
                                    sql_det = sql_det_gral & "," & id_det & ",'" & fecha & "'," & turno & ")"
                                    list_sql.Add(sql_det)
                                Next
                            Else
                                id_det += 1
                                turno = getPrimerIdTurno(j, fila)
                                fecha = objOpSimplesLn.cambiarFormatoFecha(dtg_consulta.Item(j, dtg_consulta.Rows.Count - 3).Value)
                                sql_det = sql_det_gral & "," & id_det & ",'" & fecha & "'," & turno & ")"
                                list_sql.Add(sql_det)
                            End If
                        End If
                    End If
                Next
                If (objOpSimplesLn.ExecuteSqlTransactionTodo(list_sql, "CONTROL")) Then
                    MessageBox.Show("El registro de guardo en forma exitosa!", "Correcto!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    dtg_consulta.Item("id", fila).Value = id
                    dtg_consulta.Item("motivo_extras", fila).Value = motivo_extras
                    motivo_extras = 0
                    group_motivo_extras.Visible = False
                Else
                    MessageBox.Show("Error al guardar, comuniquese con el administrador del sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                MessageBox.Show("Seleccione motivo de progración de horas extras", "Ingrese motivo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
    End Sub
    Private Function validar(ByVal fila As Integer) As Boolean
        Dim resp As Boolean = True
        For j = 0 To dtg_consulta.Columns.Count - 1
            If (dtg_consulta.Columns(j).Name <> "TotExt" And dtg_consulta.Columns(j).Name <> "nit" And dtg_consulta.Columns(j).Name <> "nombres" And dtg_consulta.Columns(j).Name <> "centro" And dtg_consulta.Columns(j).Name <> "oficio" And dtg_consulta.Columns(j).Name <> "contrato" And dtg_consulta.Columns(j).Name <> "planta" And dtg_consulta.Columns(j).Name <> "turno" And dtg_consulta.Columns(j).Name <> "id" And dtg_consulta.Columns(j).Name <> "Comp" And dtg_consulta.Columns(j).Name <> "Nov" And dtg_consulta.Columns(j).Name <> "motivo_extras" And dtg_consulta.Columns(j).Name <> "ED" And dtg_consulta.Columns(j).Name <> "EN" And dtg_consulta.Columns(j).Name <> "EDF" And dtg_consulta.Columns(j).Name <> "ENF" And dtg_consulta.Columns(j).Name <> "basico_hora" And dtg_consulta.Columns(j).Name <> "ValorExt") Then
                If IsDBNull(dtg_consulta.Item(j, fila).Value) Then
                    resp = False
                    j = dtg_consulta.Columns.Count - 1
                End If
            End If
        Next
        If resp = False Then
            MessageBox.Show("Se deben programar todos los días del periodo", "Ingrese programación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Return resp
    End Function

    Private Sub txt_horas_compromiso_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_horas_compromiso.KeyPress
        soloNumero(e)
    End Sub
    Private Sub cbo_periodo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbo_periodo.SelectedIndexChanged
        If (carga_comp) Then
            If (cbo_periodo.SelectedValue <> 0) Then
                dtg_consulta.DataSource = Nothing
                Dim sql_periodo As String = "SELECT fecha_inicial,fecha_final,periodo,mes,ano FROM y_periodos_control WHERe idPeriodo = " & cbo_periodo.SelectedValue
                Dim dt_periodo As DataTable = objOpSimplesLn.listar_datatable(sql_periodo, "CORSAN")
                Dim horas_totales As Integer = 0
                Dim dFecIni_periodo As Date
                Dim dFecFin_periodo As Date
                For i = 0 To dt_periodo.Rows.Count - 1
                    dFecIni_periodo = dt_periodo.Rows(i).Item("fecha_inicial")
                    dFecFin_periodo = dt_periodo.Rows(i).Item("fecha_final")
                    mes = dt_periodo.Rows(i).Item("mes")
                    ano = dt_periodo.Rows(i).Item("ano")
                Next
                Dim horas_festivas As Double = objOpSimplesLn.cant_festivos_rango_dias(dFecIni_periodo.Month, dFecIni_periodo.Year, dFecIni_periodo.Day, dFecFin_periodo.Day)
                horas_festivas *= 8
                id_periodo = cbo_periodo.SelectedValue
                fec_ini = objOpSimplesLn.cambiarFormatoFecha(dFecIni_periodo)
                fec_fin = objOpSimplesLn.cambiarFormatoFecha(dFecFin_periodo)

                horas_totales = DateDiff(DateInterval.Day, dFecIni_periodo, dFecFin_periodo) * 8
                horas_totales += 8 'Se hace esto para que coja los 10 días de la decada en la diferencia
                horas_laborales = (objOpSimplesLn.calcDiasHabilesProduccion(dFecIni_periodo, dFecFin_periodo) * 8)
                horas_laborales = horas_laborales - horas_festivas
                lbl_horas_laborales.Text = horas_laborales
                lbl_tot_horas.Text = horas_totales
                lblFest.Text = horas_totales - horas_laborales
                Dim nomb_sin_turno As String = objRelojLn.verificar_empleados_sin_turno(centros, id_periodo)
                If nomb_sin_turno <> "" Then
                    MessageBox.Show("Los siguientes empleados estan sin turno programado por lo tanto no se le liquidaran noveades: " & vbCrLf & vbCrLf & nomb_sin_turno, "Empleados sin turno", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
                If objRelojLn.verificar_periodo_liquidado(id_periodo) Then
                    MessageBox.Show("Este periodo se encuentra liquidado, por lo tanto no se permite hacer cambios en turnos ni ingresar novedades", "Periodo liquidado sin turno", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
        End If
    End Sub

    Private Sub DetalleDeNovedadescompromisosYPermisosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DetalleDeNovedadescompromisosYPermisosToolStripMenuItem.Click
        Dim nit As Double = dtg_consulta.Item("nit", filaSelect).Value
        Dim dt_detalle As New DataTable
        dt_detalle.Columns.Add("tipo")
        dt_detalle.Columns.Add("fecha")
        dt_detalle.Columns.Add("horas")
        dt_detalle.Columns.Add("valor", GetType(Double))
        dt_detalle.Columns.Add("observaciones")
        Dim sql_compromisos As String = "SELECT Fecha_compromiso ,horas,notas FROM R_compromiso_horas_a_pagar WHERE Activo = 'True' AND Horas >0 AND Nit_Trabajador = " & nit
        Dim sql_permisos As String = "SELECT  CAST(fecha  As varchar ) + ' ' + CAST(hora_permiso As varchar ) As fecha,notas  from J_permiso_marcacion WHERE fecha_salida is null AND nit = " & nit
        Dim sql_novedades As String = "SELECT n.fecha,n.horas,valor , (CAST(c.concepto as varchar) + ' - ' + c.descripcion) As descripcion  FROM J_novedades_no_aut n , y_conceptos_nom c WHERE c.concepto = n.concepto AND n.concepto IN (" & conceptos & ") AND n.idperiodo = " & id_periodo & " AND nit = " & nit
        Dim dt_compromisos As DataTable = objOpSimplesLn.listar_datatable(sql_compromisos, "CONTROL")
        Dim dt_permisos As DataTable = objOpSimplesLn.listar_datatable(sql_permisos, "CONTROL")
        Dim dt_novedades As DataTable = objOpSimplesLn.listar_datatable(sql_novedades, "CORSAN")
        For i = 0 To dt_compromisos.Rows.Count - 1
            dt_detalle.Rows.Add()
            dt_detalle.Rows(dt_detalle.Rows.Count - 1).Item("tipo") = "Compromiso"
            dt_detalle.Rows(dt_detalle.Rows.Count - 1).Item("fecha") = dt_compromisos.Rows(i).Item("Fecha_compromiso")
            dt_detalle.Rows(dt_detalle.Rows.Count - 1).Item("horas") = dt_compromisos.Rows(i).Item("horas")
            dt_detalle.Rows(dt_detalle.Rows.Count - 1).Item("observaciones") = dt_compromisos.Rows(i).Item("notas")
        Next
        For i = 0 To dt_permisos.Rows.Count - 1
            dt_detalle.Rows.Add()
            dt_detalle.Rows(dt_detalle.Rows.Count - 1).Item("tipo") = "Permiso"
            dt_detalle.Rows(dt_detalle.Rows.Count - 1).Item("fecha") = dt_permisos.Rows(i).Item("fecha")
            dt_detalle.Rows(dt_detalle.Rows.Count - 1).Item("observaciones") = dt_permisos.Rows(i).Item("notas")
        Next
        For i = 0 To dt_novedades.Rows.Count - 1
            dt_detalle.Rows.Add()
            dt_detalle.Rows(dt_detalle.Rows.Count - 1).Item("tipo") = "Novedad - " & dt_novedades.Rows(i).Item("descripcion")
            dt_detalle.Rows(dt_detalle.Rows.Count - 1).Item("fecha") = dt_novedades.Rows(i).Item("fecha")
            dt_detalle.Rows(dt_detalle.Rows.Count - 1).Item("horas") = dt_novedades.Rows(i).Item("horas")
            dt_detalle.Rows(dt_detalle.Rows.Count - 1).Item("valor") = dt_novedades.Rows(i).Item("valor")
        Next
        group_detalle.Visible = True
        dtg_detalle.DataSource = dt_detalle
    End Sub

    Private Sub btn_cerrar_detalle_Click(sender As Object, e As EventArgs) Handles btn_cerrar_detalle.Click
        group_detalle.Visible = False
        dtg_detalle.DataSource = Nothing
    End Sub

    Private Sub group_detalle_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles group_detalle.MouseDown
        dragging = True
        posicionX = e.X
        posicionY = e.Y
    End Sub

    Private Sub group_detalle_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles group_detalle.MouseMove
        If dragging = True Then
            group_detalle.Location = New Point(group_detalle.Location.X + e.X -
            posicionX, group_detalle.Location.Y + e.Y - posicionY)
            Me.Refresh()
        End If
    End Sub

    Private Sub group_detalle1_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles group_detalle.MouseUp
        dragging = False
    End Sub

    Private Sub EliminarTurnoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EliminarTurnoToolStripMenuItem.Click
        If IsDate(dtg_consulta.Item(colSelect, dtg_consulta.Rows.Count - 3).Value) Then
            Dim dom_fest As Boolean = False
            If dtg_consulta.Item(colSelect, dtg_consulta.Rows.Count - 2).Value = "True" Or dtg_consulta.Item(colSelect, dtg_consulta.Rows.Count - 1).Value = "True" Then
                dom_fest = True
            End If
            If dtg_consulta.Item(colSelect, filaSelect).Value <> "" Then
                restarExtras(colSelect, dom_fest)
            End If
            dtg_consulta.Item(colSelect, filaSelect).Value = ""
        Else
            MessageBox.Show("Seleccione una columna de fecha de programación para ingresar el permiso", "Seleccione columna de fecha", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub


    Private Sub ToolStripSplitButton1_Click(sender As Object, e As EventArgs) Handles ToolStripSplitButton1.Click
        objOperacionesForm.ExportarDatosExcel(dtg_consulta, "Turnos")
    End Sub

    Private Sub dtg_mot_extras_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtg_mot_extras.CellClick
        If e.RowIndex >= 0 Then
            motivo_extras = dtg_mot_extras.Item("id", e.RowIndex).Value
            guardar(filaSelect)
        End If
    End Sub
    Private Function verificarExtras(ByVal fila As Integer) As Boolean
        For j = 0 To dtg_consulta.Columns.Count - 1
            If dtg_consulta.Columns(j).Name = "TotExt" Then
                If IsNumeric(dtg_consulta.Item(j, fila).Value) Then
                    If dtg_consulta.Item(j, fila).Value > 0 Then
                        Return True
                    End If
                End If
            End If
        Next
        Return False
    End Function
    Private Function verificar_permiso_centro(ByVal centro As Integer) As Boolean
        For i = 0 To listCentros.Rows.Count - 1
            If listCentros.Rows(i).Item("centro") = centro Then
                Return True
            End If
        Next
        If listCentros.Rows.Count = 0 Then
            Return True
        End If
        Return False
    End Function

    Private Sub btn_cerrar_mot_extras_Click(sender As Object, e As EventArgs) Handles btn_cerrar_mot_extras.Click
        group_motivo_extras.Visible = False
    End Sub



    Private Sub cbo_centro_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbo_centro.SelectedIndexChanged
        If carga_comp Then
            cargar_operarios(cbo_centro.SelectedValue)
        End If
    End Sub
    Private Sub cargar_operarios(ByVal centro As Integer)
        Dim sql As String
        Dim dt As DataTable
        Dim row As DataRow
        Dim whereCentro As String = "WHERE"
        If centro = 0 Then
            whereCentro &= " centro IN(" & centros & ")"
        Else
            whereCentro &= " centro  =" & centro
        End If
        sql = "Select nit,nombres  from V_nom_personal_Activo_con_maquila " & whereCentro & " ORDER BY nombres "
        dt = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        row = dt.NewRow
        row("nit") = 0
        row("nombres") = "TODOS"
        dt.Rows.Add(row)
        cbo_operario.DataSource = dt
        cbo_operario.ValueMember = "nit"
        cbo_operario.DisplayMember = "nombres"
        cbo_operario.SelectedValue = 0
    End Sub

    Private Sub VerMarcacionesDelPeriodoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VerMarcacionesDelPeriodoToolStripMenuItem.Click
        Dim tamano_letra As Single = 9.0!
        Dim nit As Double = dtg_consulta.Item("nit", filaSelect).Value
        dtg_detalle_marcaciones.DataSource = Nothing
        group_detalle_marcaciones.Visible = True
        dtg_detalle_marcaciones.DataSource = objRelojLn.detalle_marcaciones(nit, fec_ini, fec_fin)
        dtg_detalle_marcaciones.Columns("FechaEntrada").DefaultCellStyle.Format = "g"
        dtg_detalle_marcaciones.Columns("FechaSalida").DefaultCellStyle.Format = "g"
        dtg_detalle_marcaciones.Columns("dia").DefaultCellStyle = objOperacionesForm.formatoNegrita(tamano_letra)
    End Sub

    Private Sub btn_cerrar_det_marcaciones_Click(sender As Object, e As EventArgs) Handles btn_cerrar_det_marcaciones.Click
        group_detalle_marcaciones.Visible = False
    End Sub
    Private Sub dtgCompromisos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgCompromisos.CellClick
        If e.RowIndex >= 0 Then
            If dtgCompromisos.Columns(e.ColumnIndex).Name = colBorrar.Name Then
                Dim id As Double = dtgCompromisos.Item("id", e.RowIndex).Value
                If objRelojLn.anularCompromiso(id) Then
                    MessageBox.Show("El compromiso se anulo en forma correcta", "Correcto!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    group_compromiso.Visible = False
                Else
                    MessageBox.Show("Error al anular el compromiso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        End If
    End Sub
    Private Function permiso_modificar_turno_festivo() As Boolean
        Dim permiso_extra_fest As Boolean = True
        Dim nit As Double = dtg_consulta.Item("nit", filaSelect).Value
        If Not objRelojLn.verificar_max__horas_domnicales_trab_mes(nit, mes, ano) Then
            permiso_extra_fest = False
        End If
        Return permiso_extra_fest
    End Function
End Class