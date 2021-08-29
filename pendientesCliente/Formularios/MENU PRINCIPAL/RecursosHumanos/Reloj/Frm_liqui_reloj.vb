Imports entidadNegocios
Imports logicaNegocios
Imports accesoDatos
Imports System.Data.SqlClient
Public Class Frm_liqui_reloj
    Private objOperacionesForm As OperacionesFormularios = New OperacionesFormularios
    Private objOpSimplesLn As New Op_simpesLn
    Private nomb_modulo As String
    Private dtTrazabilidad As DataTable
    Private objRelojLn As New RelojLn
    Dim centros As String = ""
    Dim per_diagnostico As Boolean = True
    Dim usuario As New UsuarioEn
    Dim correccion As Boolean = True
    Dim filaSelect_consulta As Integer = 0
    Dim colSelect_consulta As Integer = 0
    Dim filaSelect_detalle As Integer = 0
    Dim colSelect_detalle As Integer = 0
    Dim fecIni As String
    Dim fecFin As String
    Dim id_periodo As Integer = 0
    Dim carga_comp As Boolean = False
    Dim dtg_select As String = ""
    Dim horas_laborales As Integer
    Dim horas_marcaciones As Integer
    Dim conceptos_permiso As String = ""
    Dim conceptos_liquidar As String = ""
    Dim horas_totales_periodo As Integer = 0
    Dim dFecIni_periodo As Date
    Dim dFecFin_periodo As Date
    Dim estado_consolidado As Boolean = False
    Dim periodo_liquidado As Boolean = False
    Dim consecutivo As Integer
    Dim consecutivop As Integer
    Dim mes As Integer
    Dim ano As Integer
    Dim dt_fechas_festivas As New DataTable
    Dim dt_marcacion_procesada As New DataTable
    Dim es_validacion_de_inicio As Boolean = False
    Public Sub MAIN(ByVal nomb_modulo As String, ByVal usuario As UsuarioEn, ByVal es_validacion_de_inicio As Boolean)
        Me.es_validacion_de_inicio = es_validacion_de_inicio
        Me.usuario = usuario
        Dim fecha_menos_1_mes As Date = Now.AddMonths(-1)
        Dim dt As New DataTable
        Dim dr As DataRow
        Dim sql As String
        Dim where_sql As String = ""
        If (usuario.permiso.Trim <> "ADMIN" And usuario.permiso.Trim <> "NOMINA") Then
            Dim nit As Double = usuario.nit
            Dim listCentros As DataTable = objOpSimplesLn.listar_datatable("SELECT centro FROM J_coordinador_centros_costos WHERE nit =" & nit, "PRODUCCION")
            For i = 0 To listCentros.Rows.Count - 1
                centros &= listCentros.Rows(i).Item("centro")
                If (i <> listCentros.Rows.Count - 1) Then
                    centros &= ","
                End If
            Next
            btn_guardar_liq.Enabled = False
        End If
        If centros = "" Then
            centros = "1100,1200,2100,2117,2200,2300,2400,2500,2600,2800,3100,3200,4100,4500,3500,5200,5300,5400,6200,6400, 4200,4100,4300"
        End If

        where_sql &= "WHERE centro IN(" & centros & ")"
        sql = "SELECT centro,( CAST (centro AS varchar(25))+ '-' + descripcion )As descripcion " &
                        "FROM centros " &
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
        cargar_operarios(0)

        Dim dt_conceptos As DataTable = objOpSimplesLn.listar_datatable("SELECT concepto FROM J_permiso_novedad WHERE usuario = '" & usuario.usuario.Trim & "' and concepto not in('34','36','77')", "CONTROL")
        For i = 0 To dt_conceptos.Rows.Count - 1
            conceptos_permiso &= dt_conceptos.Rows(i).Item("concepto")
            If i <> dt_conceptos.Rows.Count - 1 Then
                conceptos_permiso &= ","
            End If
        Next
        If conceptos_permiso <> "" Then
            sql = "SELECT concepto,descripcion " &
                         "FROM y_conceptos_nom " &
                         "WHERE concepto in (" & conceptos_permiso & ")"
            dt = New DataTable
            dt = objOpSimplesLn.listar_datatable(sql, "CORSAN")
            dtg_ing_novedad.DataSource = dt
        End If
        dt = New DataTable
        sql = "SELECT  idPeriodo ,'Periodo:' + CAST( (periodo  )As varchar ) +' - ' +CAST( YEAR (fecha_inicial )As varchar ) + '-' + CAST( MONTH (fecha_inicial )As varchar ) + '-' + CAST( DAY (fecha_inicial )As varchar ) " &
                         "+ ' - ' +  CAST( YEAR (fecha_final  )As varchar ) + '-' + CAST( MONTH (fecha_final )As varchar ) + '-' + CAST( DAY (fecha_final )As varchar ) As descripcion,fecha_inicial,fecha_final " &
                         "FROM y_periodos_control " &
                             "WHERE dateDiff (day,fecha_inicial,fecha_final )>5 AND ((ano = " & fecha_menos_1_mes.Year & " And mes <= " & fecha_menos_1_mes.Month & ") OR (ano = " & Now.Year & " And mes = " & Now.Month & ")) "
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
        If carga_comp = False Then
            cbo_fecha_ini.MaxDate = Now.Date
            cbo_fecha_ini.MinDate = Now.Date
            cbo_fecha_fin.MaxDate = Now.Date
            cbo_fecha_fin.MinDate = Now.Date
            cbo_fecha_ini.Value = Now.Date
            cbo_fecha_fin.Value = Now.Date
        End If

        dt = New DataTable
        sql = "SELECT  id,descripcion " &
                       "FROM j_turnos "
        dt = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        dr = dt.NewRow
        dr("id") = -1
        dr("descripcion") = "TODOS"
        dt.Rows.Add(dr)
        cbo_turno.DataSource = dt
        cbo_turno.ValueMember = "id"
        cbo_turno.DisplayMember = "descripcion"
        cbo_turno.SelectedValue = -1
        groupTurno.Visible = False
        carga_comp = True



        realizar_validacion_inicio()

    End Sub
    Private Sub realizar_validacion_inicio()
        Dim where_centro As String = ""
        If centros <> "" Then
            where_centro = " AND p.centro IN (" & centros & ") "
        End If
        If es_validacion_de_inicio Then
            fecIni = objOpSimplesLn.cambiarFormatoFecha(Convert.ToDateTime(cbo_fecha_ini.Value))
            fecFin = objOpSimplesLn.cambiarFormatoFecha(Convert.ToDateTime(cbo_fecha_fin.Value))
            If validar_marcaciones(fecIni, fecFin, where_centro, "") Then
                FrmPrincipal.Show()
                FrmPrincipal.Activate()
                FrmPrincipal.Main(usuario.permiso, usuario, False)
                Me.Close()
            Else
                MessageBox.Show("Se encontraron marcaciones malas,(Sin fecha de salida o con mas de 16 horas registradas), corrijalas para continuar", "Corrija marcaciones!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
    End Sub
    Private Sub Frm_liqui_reloj_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lbl_estado.Text = ""
        Dim dt As New DataTable
        Dim dt_turnos As New DataTable
        ''DE ESTA LINEA SE PEGA EL DATATABLE PARA CARGAR LA TABLA DE TURNOS PARA MODIFICAR O ASIGNAR
        Dim sql_turnos As String = "SELECT id,descripcion,horas,ord_diur,ord_noct,extras,compensatorio,(ord_diur + ord_noct) As OrdP  FROM j_turnos WHERE anulado = 'N' ORDER BY id"
        dt_turnos = objOpSimplesLn.listar_datatable(sql_turnos, "CORSAN")
        Dim tamano_letra As Single = 9.0!
        dtgTurno.DataSource = dt_turnos
        For i = 0 To dtgTurno.Rows.Count - 1
            If dtgTurno.Item("extras", i).Value > 0 Then
                dtgTurno.Rows(i).DefaultCellStyle.BackColor = Color.GreenYellow
            End If
        Next
    End Sub
    Private Sub btn_actualizar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_actualizar.Click
        If (cbo_periodo.SelectedValue <> 0) Then
            btn_guardar_liq.Enabled = False
            actuaizar()
            lbl_estado.Text = ""
            bloquear_modificar_valores(True)
        Else
            MessageBox.Show("Seleccione el periodo corrrespondiente a la decada", "Seleccione periodo!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        If (usuario.permiso.Trim <> "ADMIN" And usuario.permiso.Trim <> "NOMINA") Then
            EliminarMarcacionToolStripMenuItem.Enabled = False
        Else
            EliminarMarcacionToolStripMenuItem.Enabled = True
        End If
    End Sub
    Private Function actuaizar() As Boolean
        Dim resp As Boolean
        carga_comp = False
        chk_consol_centros.Checked = False
        carga_comp = True
        estado_consolidado = False
        bloquear_modificar_valores(True)
        progBar.Visible = True
        dtg_consulta.ReadOnly = True
        Dim where_centro As String = ""
        Dim where_operario As String = ""
        Dim where_turno As String = ""
        If cbo_centro.SelectedValue <> 0 Then
            where_centro = " AND p.centro =" & cbo_centro.SelectedValue
        Else
            where_centro = " AND p.centro IN(" & centros & ") "
        End If
        If cbo_operario.SelectedValue <> 0 Then
            where_operario = " AND r.nit =" & cbo_operario.SelectedValue
            where_centro = ""
        End If
        If cbo_turno.SelectedValue <> -1 Then
            where_turno = " AND t.id =" & cbo_turno.SelectedValue
        End If
        fecIni = objOpSimplesLn.cambiarFormatoFecha(Convert.ToDateTime(cbo_fecha_ini.Value))
        fecFin = objOpSimplesLn.cambiarFormatoFecha(Convert.ToDateTime(cbo_fecha_fin.Value))
        dt_fechas_festivas = objRelojLn.return_dt_fechas_festivas(fecIni, fecFin)
        resp = validar_marcaciones(fecIni, fecFin, where_centro, where_operario)
        If resp Then
            Dim tamano_letra As Single = 7.0!
            Dim sqlOrder As String = "ORDER BY r.FechaEntrada "
            lbl_estado.Text = "PROCESANDO MARCACIONES..."
            Application.DoEvents()
            dtg_consulta.DataSource = Nothing
            dtg_consulta.DataSource = procesar_marcaciones(fecIni, fecFin, where_centro, where_operario, sqlOrder, where_turno)
            totalizar(dtg_consulta)
            verificarHorasExtrasProgramadas(dtg_consulta)
            For j = 0 To dtg_consulta.Columns.Count - 1
                If (dtg_consulta.Columns(j).Name = "contrato" Or dtg_consulta.Columns(j).Name = "oficio" Or dtg_consulta.Columns(j).Name = "planta" Or dtg_consulta.Columns(j).Name = "turno" Or dtg_consulta.Columns(j).Name = "basico_hora" Or dtg_consulta.Columns(j).Name = "basico_mes" Or
                    dtg_consulta.Columns(j).Name = "domingo" Or dtg_consulta.Columns(j).Name = "festivo") Then
                    dtg_consulta.Columns(j).Visible = False
                ElseIf (dtg_consulta.Columns(j).Name = "Consec" Or dtg_consulta.Columns(j).Name = "nit" Or dtg_consulta.Columns(j).Name = "nombres") Then
                    dtg_consulta.Columns(j).DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", tamano_letra)
                    If (dtg_consulta.Columns(j).Name = "Consec" Or dtg_consulta.Columns(j).Name = "nit") Then
                        dtg_consulta.Columns(j).Visible = False
                    End If
                End If
            Next
        End If
        'If cbo_centro.SelectedValue <> 0 Then
        '    totalizar()
        'End If
        'If cbo_operario.SelectedValue <> 0 Then
        '    totalizar()
        'End If
        progBar.Value = 0
        progBar.Visible = False
        Return resp
    End Function
    Private Function validar_marcaciones(ByVal fecIni As String, ByVal fecFin As String, ByVal where_centro As String, ByVal where_operario As String) As Boolean
        lbl_estado.Text = "VALIDANDO MARCACIONES..."
        Application.DoEvents()
        dtg_consulta.DataSource = Nothing

        Dim sql As String = "SELECT  r.Consecutivo As Consec,r.nit,p.nombres,DATEDIFF (hour,fechaEntrada,FechaSalida )As total,r.FechaEntrada,r.FechaSalida " &
                     "FROM r_personal_registros r , CORSAN.dbo.V_nom_personal_Activo_con_maquila p " &
                 " WHERE (FechaSalida  is null or DATEDIFF (hour,fechaEntrada,FechaSalida )>18 or DATEDIFF (hour,fechaEntrada,FechaSalida )<0) AND p.nit = r.nit AND CAST(r.FechaEntrada AS date )  Between '" & fecIni & "' AND '" & fecFin & "  23:59:59'   " & where_centro & where_operario
        Dim dt As DataTable = objOpSimplesLn.listar_datatable(sql, "CONTROL")
        dtg_consulta.DataSource = dt
        If (dtg_consulta.Rows.Count > 0) Then
            dtg_consulta.Columns("FechaEntrada").DefaultCellStyle.Format = "g"
            dtg_consulta.Columns("FechaSalida").DefaultCellStyle.Format = "g"
            MessageBox.Show("Se encontraron marcaciones malas,(Sin fecha de salida o con mas de 16 horas registradas), corrijalas y luego actualice las consulta", "Corrija marcaciones!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        Else
            Return True
        End If
        pintarAlertas()
    End Function
    Private Sub pintarAlertas()
        For j = 0 To dtg_consulta.Columns.Count - 1
            If (dtg_consulta.Columns(j).Name = "fechaEntrada" Or dtg_consulta.Columns(j).Name = "FechaSalida") Then
                For i = 0 To dtg_consulta.Rows.Count - 1
                    If IsDBNull(dtg_consulta.Item(j, i).Value) Then
                        dtg_consulta.Item(j, i).Style.BackColor = Color.Red
                    End If
                Next
            ElseIf (dtg_consulta.Columns(j).Name = "total") Then
                For i = 0 To dtg_consulta.Rows.Count - 1
                    If Not IsDBNull(dtg_consulta.Item(j, i).Value) Then
                        If (dtg_consulta.Item(j, i).Value > 15 Or dtg_consulta.Item(j, i).Value < 0) Then
                            dtg_consulta.Item(j, i).Style.BackColor = Color.Red
                        End If
                    End If
                Next
            End If
        Next
    End Sub
    Private Function procesar_marcaciones1(ByVal fecIni As String, ByVal fecFin As String, ByVal where_centro As String, ByVal where_operario As String, ByVal sqlOrder As String, ByVal where_turno As String) As DataTable
        Dim sql As String = "SELECT CAST(r.Consecutivo As varchar)As Consec,CAST(r.nit As varchar) As nit,p.nombres,p.oficio,p.contrato,y.turno,y.planta,y.basico_mes,CAST(p.centro As varchar) As centro,y.basico_hora,r.FechaEntrada,r.FechaSalida,c.sabado,c.domingo,c.festivo,SUM(f.extras )As ExtP ,SUM(t.ord_diur ) As OrdP,r.notas,f.id As id_enc , (SELECT SUM (horas) FROM R_compromiso_horas_a_pagar WHERE Nit_Trabajador= r.nit AND Activo = 'True' AND horas >0 AND concepto_90 is null AND concepto_84 is null)As debe " &
                        "FROM r_personal_registros r , CORSAN.dbo.y_calendario c,CORSAN.dbo.V_nom_personal_activo p ,CORSAN.dbo.y_personal_contratos y , J_v_operario_fecha_turno f, CORSAN.dbo.J_turnos t  " &
                    "WHERE t.id = f.id_turno AND p.contrato = y.contrato  AND p.nit = r.nit AND f.nit = r.nit AND CAST (r.FechaEntrada AS date ) = f.fecha AND CAST (r.FechaEntrada AS date ) = c.fecha AND FechaSalida is not null AND CAST(r.FechaEntrada AS date )  Between '" & fecIni & "' AND '" & fecFin & "  23:59:59' " & where_centro & where_operario & where_turno & " " &
                        "GROUP BY Consecutivo, r.nit ,p.nombres,p.oficio,p.centro,p.contrato,y.turno,y.planta,y.basico_hora,y.basico_mes ,r.FechaEntrada,r.FechaSalida,c.sabado,c.domingo,c.festivo,r.notas,f.id " &
                        sqlOrder
        If chk_temporales.Checked = True Then
            sql = "SELECT CAST(r.Consecutivo As varchar)As Consec,CAST(r.nit As varchar) As nit,p.nombres,p.oficio,p.contrato,p.turno,p.planta,p.basico_mes,CAST(p.centro As varchar) As centro,p.basico_hora,r.FechaEntrada,r.FechaSalida,c.sabado,c.domingo,c.festivo,SUM(f.extras )As ExtP ,SUM(t.ord_diur ) As OrdP,r.notas,f.id As id_enc , (SELECT SUM (horas) FROM R_compromiso_horas_a_pagar WHERE Nit_Trabajador= r.nit AND Activo = 'True' AND horas >0 and concepto_90 is null AND concepto_84 is null)As debe " &
                        "FROM r_personal_registros r , CORSAN.dbo.y_calendario c,CONTROL.dbo.J_personal_maquila p left join CORSAN.dbo.y_personal_contratos y on p.contrato=y.contrato , J_v_operario_fecha_turno f, CORSAN.dbo.J_turnos t  " &
                    "WHERE  t.id = f.id_turno AND p.nit = r.nit AND f.nit = r.nit AND CAST (r.FechaEntrada AS date ) = f.fecha AND CAST (r.FechaEntrada AS date ) = c.fecha AND p.desactivar is null AND FechaSalida is not null AND CAST(r.FechaEntrada AS date )  Between '" & fecIni & "' AND '" & fecFin & "  23:59:59' " & where_centro & where_operario & where_turno & " " &
                        "GROUP BY Consecutivo, r.nit ,p.nombres,p.oficio,p.centro,p.contrato,p.turno,p.planta,p.basico_hora,p.basico_mes ,r.FechaEntrada,r.FechaSalida,c.sabado,c.domingo,c.festivo,r.notas,f.id " &
                        sqlOrder
        End If
        Dim dt As DataTable = objOpSimplesLn.listar_datatable(sql, "CONTROL")
        Dim dtConceptos As New DataTable
        Dim dt_procesado As New DataTable
        Dim fec_hora_entro As Date
        Dim fec_hora_salio As Date
        Dim min_dif As Double = 0
        Dim horas_add As Double = 0
        Dim horas_ord As Double = 0
        Dim ord_prog As Double = 0
        Dim ext_prog As Double = 0
        Dim dia_compensatorio As Boolean = False
        Dim turno_sab_lunes_viernes As Boolean = False
        Dim dia_festivo As Boolean = False
        Dim dia_siguiente_festivo As Boolean = False

        ''prubea corregir
        Dim ExtP As Integer = 0
        Dim OrdP As Integer = 0
        Dim total As Integer = 0
        Dim OrD As Integer = 0
        Dim RN As Integer = 0
        Dim DD As Integer = 0
        Dim DN As Integer = 0
        Dim ED As Integer = 0
        Dim EDF As Integer = 0
        Dim ENF As Integer = 0
        Dim Dcomp As Integer = 0


        dt_procesado.Columns.Add("Consec")
        dt_procesado.Columns.Add("debe")
        dt_procesado.Columns.Add("nit")
        dt_procesado.Columns.Add("nombres")
        dt_procesado.Columns.Add("centro")
        dt_procesado.Columns.Add("contrato")
        dt_procesado.Columns.Add("oficio")
        dt_procesado.Columns.Add("planta")
        dt_procesado.Columns.Add("turno")
        dt_procesado.Columns.Add("basico_hora")
        dt_procesado.Columns.Add("basico_mes", GetType(Double))
        dt_procesado.Columns.Add("dia")
        dt_procesado.Columns.Add("fechaEntrada")
        dt_procesado.Columns.Add("fechaSalida")
        dt_procesado.Columns.Add("ExtP", GetType(Integer))
        dt_procesado.Columns.Add("OrdP", GetType(Integer))
        dt_procesado.Columns.Add("total", GetType(Integer))
        dt_procesado.Columns.Add("OrD", GetType(Integer)) '------------------concepto = 1
        dt_procesado.Columns.Add("RN", GetType(Integer)) '------------------concepto = 30
        dt_procesado.Columns.Add("DD", GetType(Integer)) '------------------concepto = 31
        dt_procesado.Columns.Add("DN", GetType(Integer)) '------------------concepto = 32
        dt_procesado.Columns.Add("ED", GetType(Integer)) '------------------concepto = 13
        dt_procesado.Columns.Add("EN", GetType(Integer)) '------------------concepto = 14
        dt_procesado.Columns.Add("EDF", GetType(Integer)) '------------------concepto = 15
        dt_procesado.Columns.Add("ENF", GetType(Integer)) '------------------concepto = 16
        dt_procesado.Columns.Add("DComp", GetType(Integer)) '------------------concepto =33
        dt_procesado.Columns.Add("turnoProg")
        dt_procesado.Columns.Add("notas")
        dt_procesado.Columns.Add("id_enc")
        dt_procesado.Columns.Add("domingo")
        dt_procesado.Columns.Add("festivo")

        If (dt.Rows.Count - 1 <> -1) Then
            progBar.Maximum = dt.Rows.Count - 1
            progBar.Minimum = 0
        End If
        For i = 0 To dt.Rows.Count - 1

            'prueba Dim ExtP As Integer = 0
            OrdP = dt.Rows(i).Item("OrdP")
            total = DateDiff(DateInterval.Hour, fec_hora_entro, fec_hora_salio)
            OrD = 0
            RN = 0
            DD = 0
            DN = 0
            ED = 0
            EDF = 0
            ENF = 0
            Dcomp = 0


            progBar.PerformStep()
            progBar.Refresh()
            dt_procesado.Rows.Add()
            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("Consec") = dt.Rows(i).Item("Consec")
            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("nit") = dt.Rows(i).Item("nit")
            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("nombres") = dt.Rows(i).Item("nombres")
            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("centro") = dt.Rows(i).Item("centro")
            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("contrato") = dt.Rows(i).Item("contrato")
            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("oficio") = dt.Rows(i).Item("oficio")
            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("planta") = dt.Rows(i).Item("planta")
            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("turno") = dt.Rows(i).Item("turno")
            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("basico_hora") = dt.Rows(i).Item("basico_hora")
            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("basico_mes") = dt.Rows(i).Item("basico_mes")
            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("fechaEntrada") = dt.Rows(i).Item("FechaEntrada")
            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("fechaSalida") = dt.Rows(i).Item("FechaSalida")
            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("dia") = WeekdayName(Weekday(dt.Rows(i).Item("FechaEntrada")), True, 1)
            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ExtP") = dt.Rows(i).Item("ExtP")
            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrdP") = dt.Rows(i).Item("OrdP")
            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("notas") = dt.Rows(i).Item("notas")
            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("id_enc") = dt.Rows(i).Item("id_enc")
            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("domingo") = dt.Rows(i).Item("domingo")
            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("festivo") = dt.Rows(i).Item("festivo")
            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("debe") = dt.Rows(i).Item("debe")
            fec_hora_entro = dt.Rows(i).Item("FechaEntrada")
            fec_hora_salio = dt.Rows(i).Item("FechaSalida")
            ord_prog = dt.Rows(i).Item("OrdP")
            ext_prog = dt.Rows(i).Item("ExtP")
            addTurno(dt_procesado, i)

            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("total") = DateDiff(DateInterval.Hour, fec_hora_entro, fec_hora_salio)

            If es_compensatorio(dt_procesado, i) Then
                dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DComp") = ord_prog
                dia_compensatorio = True
            Else
                dia_compensatorio = False
            End If


            Dim HorasExtras As Integer

            dia_festivo = verificar_fecha_festiva(fec_hora_entro)

            ' se verifica si tiene dutno 10 horas L-V para poner el día como extra
            If ((objRelojLn.verificar_turno_periodo(dt.Rows(i).Item("nit"), id_periodo, 4, fec_hora_entro) Or
                 objRelojLn.verificar_turno_periodo(dt.Rows(i).Item("nit"), id_periodo, 5, fec_hora_entro) Or
                 objRelojLn.verificar_turno_periodo(dt.Rows(i).Item("nit"), id_periodo, 21, fec_hora_entro)) And dt.Rows(i).Item("sabado") = "True") Then
                turno_sab_lunes_viernes = True
                HorasExtras = DateDiff(DateInterval.Hour, fec_hora_entro, fec_hora_salio)
                'dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ExtP") += OrdP
                dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ExtP") += HorasExtras
                dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrdP") = 0

            End If






            If dia_festivo Then

                Dim horasfestivas = DateDiff(DateInterval.Hour, fec_hora_entro, fec_hora_salio)

                'Se verifica si al día es festivo y el turno programado es en el día 8 horas
                If ((objRelojLn.verificar_turno_periodo(dt.Rows(i).Item("nit"), id_periodo, 1, fec_hora_entro) Or
                     (objRelojLn.verificar_turno_periodo(dt.Rows(i).Item("nit"), id_periodo, 2, fec_hora_entro)))) Then

                    dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ExtP") = 0
                    dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DD") = horasfestivas
                    dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") = 0
                    dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrdP") = 0

                End If

                'Se verifica si al día es festivo y el turno programado es en el día 10 horas
                If ((objRelojLn.verificar_turno_periodo(dt.Rows(i).Item("nit"), id_periodo, 7, fec_hora_entro) Or
                     objRelojLn.verificar_turno_periodo(dt.Rows(i).Item("nit"), id_periodo, 8, fec_hora_entro))) Then

                    dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ExtP") = 2
                    dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DD") = horasfestivas
                    dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") = 0
                    dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrdP") = 0
                    If (horasfestivas > 8) Then
                        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EDF") += (horasfestivas - 8)
                    End If
                End If


                ''verificar si entro 8 horas en la noche
                If ((objRelojLn.verificar_turno_periodo(dt.Rows(i).Item("nit"), id_periodo, 3, fec_hora_entro))) Then
                    dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ExtP") = 0
                    dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DN") = horasfestivas
                    dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") = 0
                    dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrdP") = 0

                End If

                ''verificar si entro 10 horas en la noche
                If ((objRelojLn.verificar_turno_periodo(dt.Rows(i).Item("nit"), id_periodo, 9, fec_hora_entro))) Then
                    dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ExtP") = 2
                    dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DN") = horasfestivas
                    dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") = 0
                    dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrdP") = 0
                    If (horasfestivas > 8) Then
                        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ENF") += (horasfestivas - 8)
                    End If
                End If


            End If





            turno_sab_lunes_viernes = False

            If fec_hora_entro.Hour = 21 Then
                fec_hora_entro = fec_hora_entro.AddHours(1)
                fec_hora_entro = fec_hora_entro.AddMinutes(-fec_hora_entro.Minute)
            End If

            If fec_hora_entro.Hour = 17 Then
                fec_hora_entro = fec_hora_entro.AddHours(1)
                fec_hora_entro = fec_hora_entro.AddMinutes(-fec_hora_entro.Minute)
            End If

            If fec_hora_entro.Hour >= 4 And fec_hora_entro.Hour < 6 Then
                fec_hora_entro = fec_hora_entro.AddHours(1)
                fec_hora_entro = fec_hora_entro.AddMinutes(-fec_hora_entro.Minute)
            End If

            '   VERIFICAR PARA CONTROLAR RELOJ 
            While (fec_hora_entro <= fec_hora_salio)
                dia_siguiente_festivo = verificar_dia_siguiente_festivo(fec_hora_entro)
                dia_festivo = verificar_fecha_festiva(fec_hora_entro)
                min_dif = DateDiff(DateInterval.Minute, fec_hora_entro, fec_hora_salio)

                If (min_dif >= 45) Then
                    horas_add = 1
                    ''VALIDAR QUE ENTRO MAS DE 5 AM Y SALIO ANTES DE LAS 8 PM TURNO EN LA MAÑANA
                    If (fec_hora_entro.TimeOfDay >= TimeSpan.Parse("05:30:00") And fec_hora_entro.TimeOfDay <= TimeSpan.Parse("20:30:00")) Then
                        ''VERIFICAR DOMINGOS O FESTIVOS
                        If (dt.Rows(i).Item("domingo") = "True" Or dt.Rows(i).Item("festivo") = "True") Then
                            ''VERIFICAR DIA COMPENSATORI
                            If Not dia_compensatorio Then

                                'SE VERIFICAN TURNOS 
                                If (objRelojLn.verificar_turno_dia(dt.Rows(i).Item("nit"), objOpSimplesLn.cambiarFormatoFecha(dt.Rows(i).Item("FechaEntrada")), 1)) Then
                                    If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DD")) Then
                                        'dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DD") = horas_add
                                        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DD") = 8
                                        'horas_ord += horas_add
                                        If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD")) Then
                                            'dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") = horas_add
                                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") = 0
                                        Else
                                            'dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") += horas_add
                                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") = 0
                                        End If
                                    End If
                                End If
                            Else

                                If (objRelojLn.verificar_turno_dia(dt.Rows(i).Item("nit"), objOpSimplesLn.cambiarFormatoFecha(dt.Rows(i).Item("FechaEntrada")), 1)) Then
                                    If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DD")) Then
                                        'dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DD") = horas_add
                                        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DD") = 8
                                        'horas_ord += horas_add
                                        If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD")) Then
                                            'dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") = horas_add
                                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") = 0
                                        Else
                                            'dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") += horas_add
                                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") = 0
                                        End If
                                    End If
                                End If
                                'If (horas_ord < ord_prog) Then
                                '   horas_ord += horas_add
                                'Else
                                'If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EDF")) Then
                                '    dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EDF") = horas_add
                                ' Else
                                '      dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EDF") += horas_add
                                '   End If
                                'End If

                            End If
                        ElseIf (dt.Rows(i).Item("sabado") = "True") Then

                            If (objRelojLn.verificar_turno_dia(dt.Rows(i).Item("nit"), objOpSimplesLn.cambiarFormatoFecha(dt.Rows(i).Item("FechaEntrada")), 1)) Then
                                If Not dia_compensatorio Then
                                    ' se verifica si tiene dutno 10 horas L-V para poner el día como extra
                                    If (turno_sab_lunes_viernes) Then
                                        'If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ED")) Then
                                        'dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ED") = horas_add
                                        'Else
                                        'dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ED") += horas_add
                                        'End If
                                    Else
                                        If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD")) Then
                                            'dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DD") = horas_add
                                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") = 8
                                            'horas_ord += horas_add                                      
                                        Else
                                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") = 8
                                        End If
                                    End If
                                Else
                                    ' se verifica si tiene dutno 10 horas L-V para poner el día como extra
                                    If (turno_sab_lunes_viernes) Then
                                        'If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ED")) Then
                                        'dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ED") = horas_add
                                        'Else
                                        'dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ED") += horas_add
                                        'End If
                                    Else
                                        If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD")) Then
                                            'dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DD") = horas_add
                                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") = 8
                                            'horas_ord += horas_add                                      
                                        Else
                                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") = 8
                                        End If
                                    End If
                                End If

                            End If

                            If (objRelojLn.verificar_turno_dia(dt.Rows(i).Item("nit"), objOpSimplesLn.cambiarFormatoFecha(dt.Rows(i).Item("FechaEntrada")), 4)) Then
                                If Not dia_compensatorio Then
                                    ' se verifica si tiene dutno 10 horas L-V para poner el día como extra
                                    If (turno_sab_lunes_viernes) Then
                                        If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EDF")) Then
                                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EDF") = 8
                                        Else
                                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EDF") = 8
                                        End If
                                    Else
                                        If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD")) Then
                                            'dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DD") = horas_add
                                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") = 8
                                            'horas_ord += horas_add                                      
                                        Else
                                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") = 8
                                        End If
                                    End If
                                Else
                                    ' se verifica si tiene dutno 10 horas L-V para poner el día como extra
                                    If (turno_sab_lunes_viernes) Then
                                        'If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ED")) Then
                                        'dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ED") = horas_add
                                        'Else
                                        'dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ED") += horas_add
                                        'End If
                                    Else
                                        If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD")) Then
                                            'dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DD") = horas_add
                                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") = 8
                                            'horas_ord += horas_add                                      
                                        Else
                                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") = 8
                                        End If
                                    End If
                                End If

                            End If


                        Else
                            'DIA ORDINARIO
                            If (objRelojLn.verificar_turno_dia(dt.Rows(i).Item("nit"), objOpSimplesLn.cambiarFormatoFecha(dt.Rows(i).Item("FechaEntrada")), 1)) Then
                                If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD")) Then
                                    'dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DD") = horas_add
                                    dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") = 8
                                    'horas_ord += horas_add                                      
                                Else
                                    dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") = 8
                                End If
                            End If
                        End If
                    End If

                    ''VALIDAR QUE ENTRO MAS DE 1 pm Y SALIO ANTES DE LAS 11:30  pM TURNO EN LA tarde
                    If (fec_hora_entro.TimeOfDay >= TimeSpan.Parse("13:00:00") And fec_hora_entro.TimeOfDay <= TimeSpan.Parse("23:30:00")) Then
                        ''VERIFICAR DOMINGOS O FESTIVOS
                        If (dt.Rows(i).Item("domingo") = "True" Or dt.Rows(i).Item("festivo") = "True") Then
                            ''VERIFICAR DIA COMPENSATORI
                            If Not dia_compensatorio Then

                                'SE VERIFICAN TURNOS 
                                If (objRelojLn.verificar_turno_dia(dt.Rows(i).Item("nit"), objOpSimplesLn.cambiarFormatoFecha(dt.Rows(i).Item("FechaEntrada")), 2)) Then
                                    If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DD")) Then
                                        'dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DD") = horas_add
                                        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DD") = 7
                                        'horas_ord += horas_add
                                        If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD")) Then
                                            'dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") = horas_add
                                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") = 0
                                        Else
                                            'dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") += horas_add
                                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") = 0
                                        End If
                                    End If

                                    If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DN")) Then
                                        'dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DD") = horas_add
                                        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DN") = 1
                                        'horas_ord += horas_add
                                        If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD")) Then
                                            'dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") = horas_add
                                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") = 0
                                        Else
                                            'dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") += horas_add
                                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") = 0
                                        End If
                                    Else
                                        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DN") = 1
                                    End If
                                End If
                            Else

                                'If (horas_ord < ord_prog) Then
                                '   horas_ord += horas_add
                                'Else
                                'If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EDF")) Then
                                '    dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EDF") = horas_add
                                ' Else
                                '      dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EDF") += horas_add
                                '   End If
                                'End If

                            End If
                        ElseIf (dt.Rows(i).Item("sabado") = "True") Then

                            If (objRelojLn.verificar_turno_dia(dt.Rows(i).Item("nit"), objOpSimplesLn.cambiarFormatoFecha(dt.Rows(i).Item("FechaEntrada")), 2)) Then
                                If Not dia_compensatorio Then
                                    ' se verifica si tiene dutno 10 horas L-V para poner el día como extra
                                    If (turno_sab_lunes_viernes) Then
                                        'If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ED")) Then
                                        'dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ED") = horas_add
                                        'Else
                                        'dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ED") += horas_add
                                        'End If
                                    Else
                                        If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD")) Then
                                            'dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DD") = horas_add
                                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") = 7
                                            'horas_ord += horas_add                                      
                                        Else
                                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") = 7
                                        End If
                                        If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("RN")) Then
                                            'dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DD") = horas_add
                                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("RN") = 1
                                            'horas_ord += horas_add                                      
                                        Else
                                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("RN") = 1
                                        End If
                                    End If
                                End If
                            End If

                        Else
                            'DIA ORDINARIO
                            If (objRelojLn.verificar_turno_dia(dt.Rows(i).Item("nit"), objOpSimplesLn.cambiarFormatoFecha(dt.Rows(i).Item("FechaEntrada")), 1)) Then
                                If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD")) Then
                                    'dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DD") = horas_add
                                    dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") = 7
                                    'horas_ord += horas_add                                      
                                Else
                                    dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") = 7
                                End If

                                If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("RN")) Then
                                    'dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DD") = horas_add
                                    dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("RN") = 1
                                    'horas_ord += horas_add                                      
                                Else
                                    dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("RN") = 1
                                End If
                            End If

                        End If
                    End If


                    ''VALIDAR QUE ENTRO MAS DE 9 pm Y SALIO ANTES DE LAS 7:30 AM TURNO EN LA tarde
                    If (fec_hora_entro.TimeOfDay >= TimeSpan.Parse("21:00:00") And fec_hora_entro.TimeOfDay <= TimeSpan.Parse("07:30:00")) Then
                        ''VERIFICAR DOMINGOS O FESTIVOS
                        If (dt.Rows(i).Item("domingo") = "True" Or dt.Rows(i).Item("festivo") = "True") Then
                            ''VERIFICAR DIA COMPENSATORI
                            If Not dia_compensatorio Then

                                'SE VERIFICAN TURNOS 
                                If (objRelojLn.verificar_turno_dia(dt.Rows(i).Item("nit"), objOpSimplesLn.cambiarFormatoFecha(dt.Rows(i).Item("FechaEntrada")), 3)) Then
                                    If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DN")) Then
                                        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DD") = 0
                                        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DN") = 0
                                        'horas_ord += horas_add
                                        If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD")) Then
                                            'dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") = horas_add
                                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") = 0
                                        Else
                                            'dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") += horas_add
                                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") = 0
                                        End If
                                    Else
                                        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DD") = 0
                                        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DN") = 0
                                    End If

                                    If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("RN")) Then
                                        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DD") = 0
                                        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("RN") = 0
                                        'horas_ord += horas_add
                                        If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD")) Then
                                            'dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") = horas_add
                                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") = 0
                                        Else
                                            'dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") += horas_add
                                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") = 0
                                        End If
                                    Else
                                        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DD") = 0
                                        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("RN") = 0
                                    End If
                                End If
                            Else
                                'SE VERIFICAN TURNOS 
                                If (objRelojLn.verificar_turno_dia(dt.Rows(i).Item("nit"), objOpSimplesLn.cambiarFormatoFecha(dt.Rows(i).Item("FechaEntrada")), 3)) Then
                                    If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DN")) Then
                                        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DD") = 0
                                        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DN") = 0
                                        'horas_ord += horas_add
                                        If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD")) Then
                                            'dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") = horas_add
                                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") = 0
                                        Else
                                            'dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") += horas_add
                                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") = 0
                                        End If
                                    Else
                                        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DD") = 0
                                        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DN") = 0
                                    End If

                                    If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("RN")) Then
                                        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DD") = 0
                                        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("RN") = 0
                                        'horas_ord += horas_add
                                        If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD")) Then
                                            'dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") = horas_add
                                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") = 0
                                        Else
                                            'dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") += horas_add
                                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") = 0
                                        End If
                                    Else
                                        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DD") = 0
                                        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("RN") = 0
                                    End If
                                End If

                                'If (horas_ord < ord_prog) Then
                                '   horas_ord += horas_add
                                'Else
                                'If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EDF")) Then
                                '    dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EDF") = horas_add
                                ' Else
                                '      dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EDF") += horas_add
                                '   End If
                                'End If

                            End If
                        ElseIf (dt.Rows(i).Item("sabado") = "True") Then

                            If (objRelojLn.verificar_turno_dia(dt.Rows(i).Item("nit"), objOpSimplesLn.cambiarFormatoFecha(dt.Rows(i).Item("FechaEntrada")), 3)) Then
                                If Not dia_compensatorio Then
                                    ' se verifica si tiene dutno 10 horas L-V para poner el día como extra
                                    If (turno_sab_lunes_viernes) Then
                                        'If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ED")) Then
                                        'dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ED") = horas_add
                                        'Else
                                        'dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ED") += horas_add
                                        'End If
                                    Else
                                        If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("RN")) Then
                                            'dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DD") = horas_add
                                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("RN") = 0
                                            'horas_ord += horas_add                                      
                                        Else
                                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("RN") = 0
                                        End If

                                    End If
                                End If
                            End If

                        Else
                            'DIA ORDINARIO
                            If (objRelojLn.verificar_turno_dia(dt.Rows(i).Item("nit"), objOpSimplesLn.cambiarFormatoFecha(dt.Rows(i).Item("FechaEntrada")), 3)) Then
                                If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("RN")) Then
                                    'dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DD") = horas_add
                                    dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("RN") = 0
                                    'horas_ord += horas_add                                      
                                Else
                                    dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("RN") = 0
                                End If
                            End If

                        End If
                    End If
                Else ''si los minutos de diferencia no son mayores a 45
                    ' VERIFICAMOS SI EL SIGUEINTE DIA ES FESTIVO
                    If (dia_siguiente_festivo) Then
                        If objRelojLn.verificar_turno_dia(dt.Rows(i).Item("nit"), objOpSimplesLn.cambiarFormatoFecha(dt.Rows(i).Item("FechaEntrada")), 3) Or
                                       objRelojLn.verificar_turno_dia(dt.Rows(i).Item("nit"), objOpSimplesLn.cambiarFormatoFecha(dt.Rows(i).Item("FechaEntrada")), 9) Or
                                         objRelojLn.verificar_turno_dia(dt.Rows(i).Item("nit"), objOpSimplesLn.cambiarFormatoFecha(dt.Rows(i).Item("FechaEntrada")), 11) Or
                                             objRelojLn.verificar_turno_dia(dt.Rows(i).Item("nit"), objOpSimplesLn.cambiarFormatoFecha(dt.Rows(i).Item("FechaEntrada")), 13) Then
                            If dia_compensatorio Then
                                If (horas_ord < ord_prog) Then
                                    horas_ord += horas_add
                                Else
                                    If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EN")) Then
                                        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EN") = horas_add
                                    Else
                                        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EN") += horas_add
                                    End If
                                End If
                            Else

                                ' If (dia_festivo) Then
                                'If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ENF")) Then
                                'dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ENF") = horas_add
                                'Else
                                'dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ENF") += horas_add
                                'End If
                                'ElseIf dia_siguiente_festivo = True And fec_hora_entro.TimeOfDay >= TimeSpan.Parse("22:00:00") Then
                                'If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EN")) Then
                                'dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EN") = horas_add
                                'Else
                                'dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EN") += horas_add
                                'End If
                                '   End If


                                ' PRUEBA PARA HACER QUE NO SALGA EN ENF Y SALGA EN RECARGO NOTURNO POR SER FESTIVO NOTURNO
                                'If (dia_festivo) Then
                                'If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("RN")) Then
                                '    dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("RN") = horas_add
                                ' Else
                                '      dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("RN") += horas_add
                                '   End If
                                'ElseIf dia_siguiente_festivo = True And fec_hora_entro.TimeOfDay >= TimeSpan.Parse("22:00:00") Then
                                '    If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EN")) Then
                                '     dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EN") = horas_add
                                '  Else
                                '       dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EN") += horas_add
                                'End If
                                'End If


                                '''''PRUEBA 2 DIAS FESTIVOS
                                If (dia_festivo) Then
                                    If (dia_siguiente_festivo = True) Then
                                        If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DN")) Then
                                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DN") = horas_add
                                        Else
                                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DN") += horas_add
                                        End If
                                        ''prueba ord
                                        If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD")) Then
                                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") = 0
                                        Else
                                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") += 0
                                        End If
                                        ''prueba extp
                                        If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ExtP")) Then
                                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ExtP") = 0
                                        Else
                                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ExtP") = 0
                                        End If
                                        ''prueba ordp
                                        If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrdP")) Then
                                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrdP") = 0
                                        Else
                                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrdP") += 0
                                        End If

                                    End If

                                    If (dia_siguiente_festivo = False) Then
                                        If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("RN")) Then
                                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("RN") = horas_add
                                        Else
                                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("RN") += horas_add
                                        End If
                                    End If

                                ElseIf dia_siguiente_festivo = True And fec_hora_entro.TimeOfDay >= TimeSpan.Parse("22:00:00") Then
                                    If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EN")) Then
                                        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EN") = horas_add
                                    Else
                                        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EN") += horas_add
                                    End If
                                End If

                                'dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ExtP") += horas_add
                            End If
                        Else
                            If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("RN")) Then
                                dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("RN") = horas_add
                                horas_ord += horas_add
                                If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD")) Then
                                    dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") = horas_add
                                Else
                                    dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") += horas_add
                                End If
                            Else
                                If (dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("RN") < ord_prog And horas_ord < ord_prog) Then
                                    dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("RN") += horas_add
                                    horas_ord += horas_add
                                    If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD")) Then
                                        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") = horas_add
                                    Else
                                        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") += horas_add
                                    End If
                                Else
                                    If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EN")) Then
                                        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EN") = horas_add
                                    Else
                                        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EN") += horas_add
                                    End If
                                End If
                            End If
                        End If
                        'SI DIA SIGUEINE NO ES FESTIVO. VERIFICAMOS QUE HOY SEA FESTIVO
                    ElseIf dia_festivo = True Then


                        If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DN")) Then
                            If dt.Rows(i).Item("domingo") = "True" Or dt.Rows(i).Item("festivo") = "True" Then
                                dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DN") = 0
                            End If
                            horas_ord += horas_add
                            If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD")) Then
                                dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") = 0
                            Else
                                dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") = 0
                            End If
                        Else
                            If dt.Rows(i).Item("domingo") = "True" Or dt.Rows(i).Item("festivo") = "True" Then
                                dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DN") = 8
                            End If
                            horas_ord += horas_add
                            If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD")) Then
                                dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") = 0
                            Else
                                dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") += 1
                            End If
                        End If

                        If dt.Rows(i).Item("sabado") = "True" Then
                            If (fec_hora_entro.TimeOfDay >= TimeSpan.Parse("00:00:00") And fec_hora_entro.TimeOfDay <= TimeSpan.Parse("06:00:00")) Then
                                If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ENF")) Then
                                    dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ENF") = horas_add
                                Else
                                    dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ENF") += horas_add
                                End If
                            End If
                        End If
                    ElseIf (dt.Rows(i).Item("domingo") = "True" Or dt.Rows(i).Item("festivo") = "True") Then
                        If dt.Rows(i).Item("nit") = 8430837 Then
                            Dim a As String = fec_hora_entro
                        End If
                        If Not dia_compensatorio Then
                            If objRelojLn.verificar_turno_dia(dt.Rows(i).Item("nit"), objOpSimplesLn.cambiarFormatoFecha(dt.Rows(i).Item("FechaEntrada")), 3) Or
                                  objRelojLn.verificar_turno_dia(dt.Rows(i).Item("nit"), objOpSimplesLn.cambiarFormatoFecha(dt.Rows(i).Item("FechaEntrada")), 9) Or
                                    objRelojLn.verificar_turno_dia(dt.Rows(i).Item("nit"), objOpSimplesLn.cambiarFormatoFecha(dt.Rows(i).Item("FechaEntrada")), 11) Or
                                        objRelojLn.verificar_turno_dia(dt.Rows(i).Item("nit"), objOpSimplesLn.cambiarFormatoFecha(dt.Rows(i).Item("FechaEntrada")), 13) Or
                                        objRelojLn.verificar_turno_dia(dt.Rows(i).Item("nit"), objOpSimplesLn.cambiarFormatoFecha(dt.Rows(i).Item("FechaEntrada")), 20) Then
                                If (Weekday(fec_hora_entro, vbMonday) = 7 Or dia_festivo) Then
                                    If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DN")) Then
                                        'dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DN") = horas_add
                                        horas_ord += horas_add
                                        If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD")) Then
                                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") = horas_add
                                        Else
                                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") += horas_add
                                        End If
                                    Else
                                        If (dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DN") < ord_prog And horas_ord < ord_prog) Then
                                            'dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DN") += horas_add
                                            horas_ord += horas_add
                                            If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD")) Then
                                                dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") = horas_add
                                            Else
                                                dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") += horas_add
                                            End If
                                        Else
                                            If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ENF")) Then
                                                dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ENF") = horas_add
                                            Else
                                                dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ENF") += horas_add
                                            End If
                                        End If
                                    End If
                                Else
                                    If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("RN")) Then
                                        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("RN") = horas_add
                                        horas_ord += horas_add
                                        If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD")) Then
                                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") = horas_add
                                        Else
                                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") += horas_add
                                        End If
                                    Else
                                        If (dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("RN") < ord_prog And horas_ord < ord_prog) Then
                                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("RN") += horas_add
                                            horas_ord += horas_add
                                            If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD")) Then
                                                dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") = horas_add
                                            Else
                                                dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") += horas_add
                                            End If
                                        Else
                                            If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EN")) Then
                                                dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EN") = horas_add
                                            Else
                                                dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EN") += horas_add
                                            End If
                                        End If
                                    End If
                                End If
                            Else
                                If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ENF")) Then
                                    dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ENF") = horas_add
                                Else
                                    dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ENF") += horas_add
                                End If
                            End If
                        Else
                            If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DN")) Then
                                horas_ord += horas_add
                            Else
                                If (horas_ord < ord_prog) Then
                                    horas_ord += horas_add
                                Else
                                    If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ENF")) Then
                                        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ENF") = horas_add
                                    Else
                                        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ENF") += horas_add
                                    End If
                                End If
                            End If
                        End If
                    Else
                        If horas_ord >= ord_prog Then
                            If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EN")) Then
                                dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EN") = horas_add
                            Else
                                dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EN") += horas_add
                            End If
                        Else
                            If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("RN")) Then
                                If ord_prog <> 0 Then
                                    dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("RN") = horas_add
                                    horas_ord += horas_add
                                    If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD")) Then
                                        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") = horas_add
                                    Else
                                        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") += horas_add
                                    End If
                                Else
                                    If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EN")) Then
                                        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EN") = horas_add
                                    Else
                                        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EN") += horas_add
                                    End If
                                End If
                            Else
                                If (dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("RN") < ord_prog And horas_ord < ord_prog) Then
                                    dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("RN") += horas_add
                                    horas_ord += horas_add
                                    If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD")) Then
                                        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") = horas_add
                                    Else
                                        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") += horas_add
                                    End If
                                Else
                                    If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EN")) Then
                                        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EN") = horas_add
                                    Else
                                        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EN") += horas_add
                                    End If
                                End If
                            End If
                        End If
                    End If


                End If

                fec_hora_entro = fec_hora_entro.AddHours(1)
            End While
            'Zona para agregar conceptos
            If chk_temporales.Checked = True Then
                dtConceptos = agregar_Conceptos(fec_hora_entro, dt.Rows(i).Item("nit"))
                For k = 0 To dtConceptos.Rows.Count - 1
                    If dtConceptos.Rows(k).Item("concepto") = 13 Then
                        ' dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ED") = dtConceptos.Rows(k).Item("horas")
                    ElseIf dtConceptos.Rows(k).Item("concepto") = 14 Then
                        ' dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EN") = dtConceptos.Rows(k).Item("horas")
                    ElseIf dtConceptos.Rows(k).Item("concepto") = 15 Then
                        'dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EDF") = dtConceptos.Rows(k).Item("horas")
                    ElseIf dtConceptos.Rows(k).Item("concepto") = 16 Then
                        'dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ENF") = dtConceptos.Rows(k).Item("horas")
                    ElseIf dtConceptos.Rows(k).Item("concepto") = 31 Then
                        'dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DD") = dtConceptos.Rows(k).Item("horas")
                    ElseIf dtConceptos.Rows(k).Item("concepto") = 32 Then
                        'dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DN") = dtConceptos.Rows(k).Item("horas")
                    End If
                Next
            End If
            horas_ord = 0
        Next
        dia_compensatorio = False
        dt_procesado.Rows.Add()
        Return dt_procesado
    End Function

    Private Function procesar_marcacionesOriginal(ByVal fecIni As String, ByVal fecFin As String, ByVal where_centro As String, ByVal where_operario As String, ByVal sqlOrder As String, ByVal where_turno As String) As DataTable
        Dim sql As String = "SELECT CAST(r.Consecutivo As varchar)As Consec,CAST(r.nit As varchar) As nit,p.nombres,p.oficio,p.contrato,y.turno,y.planta,y.basico_mes,CAST(p.centro As varchar) As centro,y.basico_hora,r.FechaEntrada,r.FechaSalida,c.sabado,c.domingo,c.festivo,SUM(f.extras )As ExtP ,SUM(t.ord_diur ) As OrdP,r.notas,f.id As id_enc , (SELECT SUM (horas) FROM R_compromiso_horas_a_pagar WHERE Nit_Trabajador= r.nit AND Activo = 'True' AND horas >0 AND concepto_90 is null AND concepto_84 is null)As debe " &
                        "FROM r_personal_registros r , CORSAN.dbo.y_calendario c,CORSAN.dbo.V_nom_personal_activo p ,CORSAN.dbo.y_personal_contratos y , J_v_operario_fecha_turno f, CORSAN.dbo.J_turnos t  " &
                    "WHERE t.id = f.id_turno AND p.contrato = y.contrato  AND p.nit = r.nit AND f.nit = r.nit AND CAST (r.FechaEntrada AS date ) = f.fecha AND CAST (r.FechaEntrada AS date ) = c.fecha AND FechaSalida is not null AND CAST(r.FechaEntrada AS date )  Between '" & fecIni & "' AND '" & fecFin & "  23:59:59' " & where_centro & where_operario & where_turno & " " &
                        "GROUP BY Consecutivo, r.nit ,p.nombres,p.oficio,p.centro,p.contrato,y.turno,y.planta,y.basico_hora,y.basico_mes ,r.FechaEntrada,r.FechaSalida,c.sabado,c.domingo,c.festivo,r.notas,f.id " &
                        sqlOrder
        If chk_temporales.Checked = True Then
            sql = "SELECT CAST(r.Consecutivo As varchar)As Consec,CAST(r.nit As varchar) As nit,p.nombres,p.oficio,p.contrato,p.turno,p.planta,p.basico_mes,CAST(p.centro As varchar) As centro,p.basico_hora,r.FechaEntrada,r.FechaSalida,c.sabado,c.domingo,c.festivo,SUM(f.extras )As ExtP ,SUM(t.ord_diur ) As OrdP,r.notas,f.id As id_enc , (SELECT SUM (horas) FROM R_compromiso_horas_a_pagar WHERE Nit_Trabajador= r.nit AND Activo = 'True' AND horas >0 and concepto_90 is null AND concepto_84 is null)As debe " &
                        "FROM r_personal_registros r , CORSAN.dbo.y_calendario c,CONTROL.dbo.J_personal_maquila p left join CORSAN.dbo.y_personal_contratos y on p.contrato=y.contrato , J_v_operario_fecha_turno f, CORSAN.dbo.J_turnos t  " &
                    "WHERE  t.id = f.id_turno AND p.nit = r.nit AND f.nit = r.nit AND CAST (r.FechaEntrada AS date ) = f.fecha AND CAST (r.FechaEntrada AS date ) = c.fecha AND p.desactivar is null AND FechaSalida is not null AND CAST(r.FechaEntrada AS date )  Between '" & fecIni & "' AND '" & fecFin & "  23:59:59' " & where_centro & where_operario & where_turno & " " &
                        "GROUP BY Consecutivo, r.nit ,p.nombres,p.oficio,p.centro,p.contrato,p.turno,p.planta,p.basico_hora,p.basico_mes ,r.FechaEntrada,r.FechaSalida,c.sabado,c.domingo,c.festivo,r.notas,f.id " &
                        sqlOrder
        End If
        Dim dt As DataTable = objOpSimplesLn.listar_datatable(sql, "CONTROL")
        Dim dtConceptos As New DataTable
        Dim dt_procesado As New DataTable
        Dim fec_hora_entro As Date
        Dim fec_hora_salio As Date
        Dim min_dif As Double = 0
        Dim horas_add As Double = 0
        Dim horas_ord As Double = 0
        Dim ord_prog As Double = 0
        Dim ext_prog As Double = 0
        Dim dia_compensatorio As Boolean = False
        Dim turno_sab_lunes_viernes As Boolean = False
        Dim dia_festivo As Boolean = False
        Dim dia_siguiente_festivo As Boolean = False


        dt_procesado.Columns.Add("Consec")
        dt_procesado.Columns.Add("debe")
        dt_procesado.Columns.Add("nit")
        dt_procesado.Columns.Add("nombres")
        dt_procesado.Columns.Add("centro")
        dt_procesado.Columns.Add("contrato")
        dt_procesado.Columns.Add("oficio")
        dt_procesado.Columns.Add("planta")
        dt_procesado.Columns.Add("turno")
        dt_procesado.Columns.Add("basico_hora")
        dt_procesado.Columns.Add("basico_mes", GetType(Double))
        dt_procesado.Columns.Add("dia")
        dt_procesado.Columns.Add("fechaEntrada")
        dt_procesado.Columns.Add("fechaSalida")
        dt_procesado.Columns.Add("ExtP", GetType(Integer))
        dt_procesado.Columns.Add("OrdP", GetType(Integer))
        dt_procesado.Columns.Add("total", GetType(Integer))
        dt_procesado.Columns.Add("OrD", GetType(Integer)) '------------------concepto = 1
        dt_procesado.Columns.Add("RN", GetType(Integer)) '------------------concepto = 30
        dt_procesado.Columns.Add("DD", GetType(Integer)) '------------------concepto = 31
        dt_procesado.Columns.Add("DN", GetType(Integer)) '------------------concepto = 32
        dt_procesado.Columns.Add("ED", GetType(Integer)) '------------------concepto = 13
        dt_procesado.Columns.Add("EN", GetType(Integer)) '------------------concepto = 14
        dt_procesado.Columns.Add("EDF", GetType(Integer)) '------------------concepto = 15
        dt_procesado.Columns.Add("ENF", GetType(Integer)) '------------------concepto = 16
        dt_procesado.Columns.Add("DComp", GetType(Integer)) '------------------concepto =33
        dt_procesado.Columns.Add("turnoProg")
        dt_procesado.Columns.Add("notas")
        dt_procesado.Columns.Add("id_enc")
        dt_procesado.Columns.Add("domingo")
        dt_procesado.Columns.Add("festivo")

        If (dt.Rows.Count - 1 <> -1) Then
            progBar.Maximum = dt.Rows.Count - 1
            progBar.Minimum = 0
        End If
        For i = 0 To dt.Rows.Count - 1
            progBar.PerformStep()
            progBar.Refresh()
            dt_procesado.Rows.Add()
            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("Consec") = dt.Rows(i).Item("Consec")
            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("nit") = dt.Rows(i).Item("nit")
            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("nombres") = dt.Rows(i).Item("nombres")
            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("centro") = dt.Rows(i).Item("centro")
            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("contrato") = dt.Rows(i).Item("contrato")
            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("oficio") = dt.Rows(i).Item("oficio")
            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("planta") = dt.Rows(i).Item("planta")
            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("turno") = dt.Rows(i).Item("turno")
            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("basico_hora") = dt.Rows(i).Item("basico_hora")
            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("basico_mes") = dt.Rows(i).Item("basico_mes")
            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("fechaEntrada") = dt.Rows(i).Item("FechaEntrada")
            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("fechaSalida") = dt.Rows(i).Item("FechaSalida")
            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("dia") = WeekdayName(Weekday(dt.Rows(i).Item("FechaEntrada")), True, 1)
            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ExtP") = dt.Rows(i).Item("ExtP")
            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrdP") = dt.Rows(i).Item("OrdP")
            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("notas") = dt.Rows(i).Item("notas")
            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("id_enc") = dt.Rows(i).Item("id_enc")
            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("domingo") = dt.Rows(i).Item("domingo")
            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("festivo") = dt.Rows(i).Item("festivo")
            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("debe") = dt.Rows(i).Item("debe")
            fec_hora_entro = dt.Rows(i).Item("FechaEntrada")
            fec_hora_salio = dt.Rows(i).Item("FechaSalida")
            ord_prog = dt.Rows(i).Item("OrdP")
            ext_prog = dt.Rows(i).Item("ExtP")
            addTurno(dt_procesado, i)
            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("total") = DateDiff(DateInterval.Hour, fec_hora_entro, fec_hora_salio)
            If es_compensatorio(dt_procesado, i) Then
                dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DComp") = ord_prog
                dia_compensatorio = True
            Else
                dia_compensatorio = False
            End If
            dia_festivo = verificar_fecha_festiva(fec_hora_entro)
            ' se verifica si tiene dutno 10 horas L-V para poner el día como extra
            If ((objRelojLn.verificar_turno_periodo(dt.Rows(i).Item("nit"), id_periodo, 4, fec_hora_entro) Or
                                  objRelojLn.verificar_turno_periodo(dt.Rows(i).Item("nit"), id_periodo, 5, fec_hora_entro) Or
                                      objRelojLn.verificar_turno_periodo(dt.Rows(i).Item("nit"), id_periodo, 6, fec_hora_entro) Or
                objRelojLn.verificar_turno_periodo(dt.Rows(i).Item("nit"), id_periodo, 21, fec_hora_entro)) And dt.Rows(i).Item("sabado") = "True") Then
                'objRelojLn.verificar_turno_periodo(dt.Rows(i).Item("nit"), id_periodo, 20, fec_hora_entro) Or 
                turno_sab_lunes_viernes = True
                dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ExtP") += dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrdP")
                dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrdP") = 0
            Else
                If dia_festivo Then
                    'Se verifica si al día es festivo y el turno programado es en el día
                    If ((objRelojLn.verificar_turno_periodo(dt.Rows(i).Item("nit"), id_periodo, 1, fec_hora_entro) Or
                                 objRelojLn.verificar_turno_periodo(dt.Rows(i).Item("nit"), id_periodo, 2, fec_hora_entro) Or
                                     objRelojLn.verificar_turno_periodo(dt.Rows(i).Item("nit"), id_periodo, 7, fec_hora_entro) Or
                                       objRelojLn.verificar_turno_periodo(dt.Rows(i).Item("nit"), id_periodo, 8, fec_hora_entro))) Then
                        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ExtP") += dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrdP")
                        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrdP") = 0
                    End If

                    'SE VERIFICA SI EL DIA ES FESTIVO Y EL TURNO PROGRAMADO ES EN LA NOCHE
                    If ((objRelojLn.verificar_turno_periodo(dt.Rows(i).Item("nit"), id_periodo, 3, fec_hora_entro) Or
                                 objRelojLn.verificar_turno_periodo(dt.Rows(i).Item("nit"), id_periodo, 9, fec_hora_entro) Or
                                     objRelojLn.verificar_turno_periodo(dt.Rows(i).Item("nit"), id_periodo, 21, fec_hora_entro))) Then
                        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrdP") = 0
                        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") = 0
                        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ExtP") = 0
                        'dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ExtP") += dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrdP")

                    End If


                End If
                turno_sab_lunes_viernes = False
            End If
            If fec_hora_entro.Hour = 21 Then
                fec_hora_entro = fec_hora_entro.AddHours(1)
                fec_hora_entro = fec_hora_entro.AddMinutes(-fec_hora_entro.Minute)
                'ElseIf fec_hora_entro.Hour = 20 Then
                '    fec_hora_entro = fec_hora_entro.AddHours(2)
                '    fec_hora_entro = fec_hora_entro.AddMinutes(-fec_hora_entro.Minute)
                'ElseIf fec_hora_entro.Hour = 19 Then
                '    If fec_hora_entro.Minute >= 40 Then
                '        fec_hora_entro = fec_hora_entro.AddHours(3)
                '        fec_hora_entro = fec_hora_entro.AddMinutes(-fec_hora_entro.Minute)
                '    End If
            End If
            If fec_hora_entro.Hour = 17 Then
                fec_hora_entro = fec_hora_entro.AddHours(1)
                fec_hora_entro = fec_hora_entro.AddMinutes(-fec_hora_entro.Minute)
            End If
            If fec_hora_entro.Hour >= 4 And fec_hora_entro.Hour < 6 Then
                fec_hora_entro = fec_hora_entro.AddHours(1)
                fec_hora_entro = fec_hora_entro.AddMinutes(-fec_hora_entro.Minute)
            End If
            '   VERIFICAR PARA CONTROLAR RELOJ 
            While (fec_hora_entro <= fec_hora_salio)
                dia_siguiente_festivo = verificar_dia_siguiente_festivo(fec_hora_entro)
                dia_festivo = verificar_fecha_festiva(fec_hora_entro)
                min_dif = DateDiff(DateInterval.Minute, fec_hora_entro, fec_hora_salio)

                If (min_dif >= 45) Then
                    horas_add = 1
                    If (fec_hora_entro.TimeOfDay >= TimeSpan.Parse("05:30:00") And fec_hora_entro.TimeOfDay <= TimeSpan.Parse("20:30:00")) Then
                        If (dt.Rows(i).Item("domingo") = "True" Or dt.Rows(i).Item("festivo") = "True") Then
                            If Not dia_compensatorio Then
                                If objRelojLn.verificar_turno_dia(dt.Rows(i).Item("nit"), objOpSimplesLn.cambiarFormatoFecha(dt.Rows(i).Item("FechaEntrada")), 3) Or
                                                   objRelojLn.verificar_turno_dia(dt.Rows(i).Item("nit"), objOpSimplesLn.cambiarFormatoFecha(dt.Rows(i).Item("FechaEntrada")), 9) Or
                                                     objRelojLn.verificar_turno_dia(dt.Rows(i).Item("nit"), objOpSimplesLn.cambiarFormatoFecha(dt.Rows(i).Item("FechaEntrada")), 11) Or
                                                         objRelojLn.verificar_turno_dia(dt.Rows(i).Item("nit"), objOpSimplesLn.cambiarFormatoFecha(dt.Rows(i).Item("FechaEntrada")), 13) Or
                                                         objRelojLn.verificar_turno_dia(dt.Rows(i).Item("nit"), objOpSimplesLn.cambiarFormatoFecha(dt.Rows(i).Item("FechaEntrada")), 20) Then
                                    If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DD")) Then
                                        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DD") = horas_add
                                        horas_ord += horas_add
                                        If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD")) Then
                                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") = horas_add
                                        Else
                                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") += horas_add
                                        End If
                                    Else
                                        If (dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DD") < ord_prog And horas_ord < ord_prog) Then
                                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DD") += horas_add
                                            horas_ord += horas_add
                                            If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD")) Then
                                                dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") = horas_add
                                            Else
                                                dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") += horas_add
                                            End If
                                        Else
                                            If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EDF")) Then
                                                dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EDF") = horas_add
                                            Else
                                                dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EDF") += horas_add
                                            End If
                                        End If
                                    End If
                                Else
                                    If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EDF")) Then
                                        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EDF") = horas_add
                                    Else
                                        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EDF") += horas_add
                                    End If

                                End If
                            Else
                                If (horas_ord < ord_prog) Then
                                    horas_ord += horas_add
                                Else
                                    If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EDF")) Then
                                        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EDF") = horas_add
                                    Else
                                        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EDF") += horas_add
                                    End If
                                End If



                            End If
                        ElseIf (dt.Rows(i).Item("sabado") = "True") Then
                            If Not dia_compensatorio Then
                                ' se verifica si tiene dutno 10 horas L-V para poner el día como extra
                                If (turno_sab_lunes_viernes) Then
                                    If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ED")) Then
                                        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ED") = horas_add
                                    Else
                                        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ED") += horas_add
                                    End If
                                Else
                                    If ord_prog = 0 And ext_prog > 0 Then
                                        If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ED")) Then
                                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ED") = horas_add
                                        Else
                                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ED") += horas_add
                                        End If
                                    Else
                                        If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD")) Then
                                            If ord_prog = 0 And ext_prog = 0 Then
                                                If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ED")) Then
                                                    dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ED") = horas_add
                                                Else
                                                    dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ED") += horas_add
                                                End If
                                            Else
                                                dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") = horas_add
                                                horas_ord += horas_add
                                            End If

                                        Else
                                            If (dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") < ord_prog And horas_ord < ord_prog) Then
                                                dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") += horas_add
                                                horas_ord += horas_add
                                            Else
                                                If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ED")) Then
                                                    dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ED") = horas_add
                                                Else
                                                    dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ED") += horas_add
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        Else
                            If ord_prog = 0 And ext_prog > 0 Then
                                If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ED")) Then
                                    dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ED") = horas_add
                                Else
                                    dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ED") += horas_add
                                End If
                            Else
                                If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD")) Then
                                    dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") = horas_add
                                    horas_ord += horas_add
                                Else
                                    If (dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") < ord_prog And horas_ord < ord_prog) Then
                                        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") += horas_add
                                        horas_ord += horas_add
                                    Else
                                        If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ED")) Then
                                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ED") = horas_add
                                        Else
                                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ED") += horas_add
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    Else
                        If (dia_siguiente_festivo) Then
                            If objRelojLn.verificar_turno_dia(dt.Rows(i).Item("nit"), objOpSimplesLn.cambiarFormatoFecha(dt.Rows(i).Item("FechaEntrada")), 3) Or
                                           objRelojLn.verificar_turno_dia(dt.Rows(i).Item("nit"), objOpSimplesLn.cambiarFormatoFecha(dt.Rows(i).Item("FechaEntrada")), 9) Or
                                             objRelojLn.verificar_turno_dia(dt.Rows(i).Item("nit"), objOpSimplesLn.cambiarFormatoFecha(dt.Rows(i).Item("FechaEntrada")), 11) Or
                                                 objRelojLn.verificar_turno_dia(dt.Rows(i).Item("nit"), objOpSimplesLn.cambiarFormatoFecha(dt.Rows(i).Item("FechaEntrada")), 13) Then
                                If dia_compensatorio Then
                                    If (horas_ord < ord_prog) Then
                                        horas_ord += horas_add
                                    Else
                                        If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EN")) Then
                                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EN") = horas_add
                                        Else
                                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EN") += horas_add
                                        End If
                                    End If
                                Else

                                    ' If (dia_festivo) Then
                                    'If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ENF")) Then
                                    'dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ENF") = horas_add
                                    'Else
                                    'dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ENF") += horas_add
                                    'End If
                                    'ElseIf dia_siguiente_festivo = True And fec_hora_entro.TimeOfDay >= TimeSpan.Parse("22:00:00") Then
                                    'If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EN")) Then
                                    'dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EN") = horas_add
                                    'Else
                                    'dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EN") += horas_add
                                    'End If
                                    '   End If


                                    ' PRUEBA PARA HACER QUE NO SALGA EN ENF Y SALGA EN RECARGO NOTURNO POR SER FESTIVO NOTURNO
                                    'If (dia_festivo) Then
                                    'If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("RN")) Then
                                    '    dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("RN") = horas_add
                                    ' Else
                                    '      dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("RN") += horas_add
                                    '   End If
                                    'ElseIf dia_siguiente_festivo = True And fec_hora_entro.TimeOfDay >= TimeSpan.Parse("22:00:00") Then
                                    '    If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EN")) Then
                                    '     dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EN") = horas_add
                                    '  Else
                                    '       dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EN") += horas_add
                                    'End If
                                    'End If


                                    '''''PRUEBA 2 DIAS FESTIVOS
                                    If (dia_festivo) Then
                                        If (dia_siguiente_festivo = True) Then
                                            If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DN")) Then
                                                dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DN") = horas_add
                                            Else
                                                dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DN") += horas_add
                                            End If
                                            ''prueba ord
                                            If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD")) Then
                                                dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") = 0
                                            Else
                                                dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") += 0
                                            End If
                                            ''prueba extp
                                            If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ExtP")) Then
                                                dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ExtP") = 0
                                            Else
                                                dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ExtP") = 0
                                            End If
                                            ''prueba ordp
                                            If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrdP")) Then
                                                dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrdP") = 0
                                            Else
                                                dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrdP") += 0
                                            End If

                                        End If

                                        If (dia_siguiente_festivo = False) Then
                                            If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("RN")) Then
                                                dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("RN") = horas_add
                                            Else
                                                dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("RN") += horas_add
                                            End If
                                        End If







                                    ElseIf dia_siguiente_festivo = True And fec_hora_entro.TimeOfDay >= TimeSpan.Parse("22:00:00") Then
                                        If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EN")) Then
                                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EN") = horas_add
                                        Else
                                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EN") += horas_add
                                        End If
                                    End If

                                    'dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ExtP") += horas_add
                                End If
                            Else
                                If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("RN")) Then
                                    dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("RN") = horas_add
                                    horas_ord += horas_add
                                    If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD")) Then
                                        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") = horas_add
                                    Else
                                        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") += horas_add
                                    End If
                                Else
                                    If (dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("RN") < ord_prog And horas_ord < ord_prog) Then
                                        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("RN") += horas_add
                                        horas_ord += horas_add
                                        If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD")) Then
                                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") = horas_add
                                        Else
                                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") += horas_add
                                        End If
                                    Else
                                        If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EN")) Then
                                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EN") = horas_add
                                        Else
                                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EN") += horas_add
                                        End If
                                    End If
                                End If
                            End If
                        ElseIf dia_festivo = True Then


                            If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DN")) Then
                                If dt.Rows(i).Item("domingo") = "True" Or dt.Rows(i).Item("festivo") = "True" Then
                                    dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DN") = horas_add
                                End If
                                horas_ord += horas_add
                                If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD")) Then
                                    dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") = horas_add
                                Else
                                    dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") += horas_add
                                End If
                            Else
                                If dt.Rows(i).Item("domingo") = "True" Or dt.Rows(i).Item("festivo") = "True" Then
                                    dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DN") += horas_add
                                End If
                                horas_ord += horas_add
                                If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD")) Then
                                    dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") = horas_add
                                Else
                                    dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") += horas_add
                                End If
                            End If
                            If dt.Rows(i).Item("sabado") = "True" Then
                                If (fec_hora_entro.TimeOfDay >= TimeSpan.Parse("00:00:00") And fec_hora_entro.TimeOfDay <= TimeSpan.Parse("06:00:00")) Then
                                    If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ENF")) Then
                                        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ENF") = horas_add
                                    Else
                                        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ENF") += horas_add
                                    End If
                                End If
                            End If
                        ElseIf (dt.Rows(i).Item("domingo") = "True" Or dt.Rows(i).Item("festivo") = "True") Then
                            If dt.Rows(i).Item("nit") = 8430837 Then
                                Dim a As String = fec_hora_entro
                            End If
                            If Not dia_compensatorio Then
                                If objRelojLn.verificar_turno_dia(dt.Rows(i).Item("nit"), objOpSimplesLn.cambiarFormatoFecha(dt.Rows(i).Item("FechaEntrada")), 3) Or
                                      objRelojLn.verificar_turno_dia(dt.Rows(i).Item("nit"), objOpSimplesLn.cambiarFormatoFecha(dt.Rows(i).Item("FechaEntrada")), 9) Or
                                        objRelojLn.verificar_turno_dia(dt.Rows(i).Item("nit"), objOpSimplesLn.cambiarFormatoFecha(dt.Rows(i).Item("FechaEntrada")), 11) Or
                                            objRelojLn.verificar_turno_dia(dt.Rows(i).Item("nit"), objOpSimplesLn.cambiarFormatoFecha(dt.Rows(i).Item("FechaEntrada")), 13) Or
                                            objRelojLn.verificar_turno_dia(dt.Rows(i).Item("nit"), objOpSimplesLn.cambiarFormatoFecha(dt.Rows(i).Item("FechaEntrada")), 20) Then
                                    If (Weekday(fec_hora_entro, vbMonday) = 7 Or dia_festivo) Then
                                        If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DN")) Then
                                            'dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DN") = horas_add
                                            horas_ord += horas_add
                                            If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD")) Then
                                                dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") = horas_add
                                            Else
                                                dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") += horas_add
                                            End If
                                        Else
                                            If (dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DN") < ord_prog And horas_ord < ord_prog) Then
                                                'dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DN") += horas_add
                                                horas_ord += horas_add
                                                If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD")) Then
                                                    dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") = horas_add
                                                Else
                                                    dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") += horas_add
                                                End If
                                            Else
                                                If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ENF")) Then
                                                    dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ENF") = horas_add
                                                Else
                                                    dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ENF") += horas_add
                                                End If
                                            End If
                                        End If
                                    Else
                                        If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("RN")) Then
                                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("RN") = horas_add
                                            horas_ord += horas_add
                                            If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD")) Then
                                                dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") = horas_add
                                            Else
                                                dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") += horas_add
                                            End If
                                        Else
                                            If (dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("RN") < ord_prog And horas_ord < ord_prog) Then
                                                dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("RN") += horas_add
                                                horas_ord += horas_add
                                                If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD")) Then
                                                    dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") = horas_add
                                                Else
                                                    dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") += horas_add
                                                End If
                                            Else
                                                If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EN")) Then
                                                    dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EN") = horas_add
                                                Else
                                                    dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EN") += horas_add
                                                End If
                                            End If
                                        End If
                                    End If
                                Else
                                    If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ENF")) Then
                                        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ENF") = horas_add
                                    Else
                                        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ENF") += horas_add
                                    End If
                                End If
                            Else
                                If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DN")) Then
                                    horas_ord += horas_add
                                Else
                                    If (horas_ord < ord_prog) Then
                                        horas_ord += horas_add
                                    Else
                                        If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ENF")) Then
                                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ENF") = horas_add
                                        Else
                                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ENF") += horas_add
                                        End If
                                    End If
                                End If
                            End If
                        Else
                            If horas_ord >= ord_prog Then
                                If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EN")) Then
                                    dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EN") = horas_add
                                Else
                                    dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EN") += horas_add
                                End If
                            Else
                                If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("RN")) Then
                                    If ord_prog <> 0 Then
                                        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("RN") = horas_add
                                        horas_ord += horas_add
                                        If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD")) Then
                                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") = horas_add
                                        Else
                                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") += horas_add
                                        End If
                                    Else
                                        If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EN")) Then
                                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EN") = horas_add
                                        Else
                                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EN") += horas_add
                                        End If
                                    End If
                                Else
                                    If (dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("RN") < ord_prog And horas_ord < ord_prog) Then
                                        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("RN") += horas_add
                                        horas_ord += horas_add
                                        If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD")) Then
                                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") = horas_add
                                        Else
                                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") += horas_add
                                        End If
                                    Else
                                        If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EN")) Then
                                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EN") = horas_add
                                        Else
                                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EN") += horas_add
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
                fec_hora_entro = fec_hora_entro.AddHours(1)
            End While
            'Zona para agregar conceptos
            If chk_temporales.Checked = True Then
                dtConceptos = agregar_Conceptos(fec_hora_entro, dt.Rows(i).Item("nit"))
                For k = 0 To dtConceptos.Rows.Count - 1
                    If dtConceptos.Rows(k).Item("concepto") = 13 Then
                        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ED") = dtConceptos.Rows(k).Item("horas")
                    ElseIf dtConceptos.Rows(k).Item("concepto") = 14 Then
                        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EN") = dtConceptos.Rows(k).Item("horas")
                    ElseIf dtConceptos.Rows(k).Item("concepto") = 15 Then
                        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EDF") = dtConceptos.Rows(k).Item("horas")
                    ElseIf dtConceptos.Rows(k).Item("concepto") = 16 Then
                        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ENF") = dtConceptos.Rows(k).Item("horas")
                    ElseIf dtConceptos.Rows(k).Item("concepto") = 31 Then
                        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DD") = dtConceptos.Rows(k).Item("horas")
                    ElseIf dtConceptos.Rows(k).Item("concepto") = 32 Then
                        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DN") = dtConceptos.Rows(k).Item("horas")
                    End If
                Next
            End If
            horas_ord = 0
        Next
        dia_compensatorio = False
        dt_procesado.Rows.Add()
        Return dt_procesado
    End Function

    Private Function procesar_marcacionesz(ByVal fecIni As String, ByVal fecFin As String, ByVal where_centro As String, ByVal where_operario As String, ByVal sqlOrder As String, ByVal where_turno As String) As DataTable
        Dim sql As String = "SELECT CAST(r.Consecutivo As varchar)As Consec,CAST(r.nit As varchar) As nit,p.nombres,p.oficio,p.contrato,y.turno,y.planta,y.basico_mes,CAST(p.centro As varchar) As centro,y.basico_hora,r.FechaEntrada,r.FechaSalida,c.sabado,c.domingo,c.festivo,SUM(f.extras )As ExtP ,SUM(t.ord_diur ) As OrdP,r.notas,f.id As id_enc , (SELECT SUM (horas) FROM R_compromiso_horas_a_pagar WHERE Nit_Trabajador= r.nit AND Activo = 'True' AND horas >0 AND concepto_90 is null AND concepto_84 is null)As debe " &
                        "FROM r_personal_registros r , CORSAN.dbo.y_calendario c,CORSAN.dbo.V_nom_personal_activo p ,CORSAN.dbo.y_personal_contratos y , J_v_operario_fecha_turno f, CORSAN.dbo.J_turnos t  " &
                    "WHERE t.id = f.id_turno AND p.contrato = y.contrato  AND p.nit = r.nit AND f.nit = r.nit AND CAST (r.FechaEntrada AS date ) = f.fecha AND CAST (r.FechaEntrada AS date ) = c.fecha AND FechaSalida is not null AND CAST(r.FechaEntrada AS date )  Between '" & fecIni & "' AND '" & fecFin & "  23:59:59' " & where_centro & where_operario & where_turno & " " &
                        "GROUP BY Consecutivo, r.nit ,p.nombres,p.oficio,p.centro,p.contrato,y.turno,y.planta,y.basico_hora,y.basico_mes ,r.FechaEntrada,r.FechaSalida,c.sabado,c.domingo,c.festivo,r.notas,f.id " &
                        sqlOrder
        If chk_temporales.Checked = True Then
            sql = "SELECT CAST(r.Consecutivo As varchar)As Consec,CAST(r.nit As varchar) As nit,p.nombres,p.oficio,p.contrato,p.turno,p.planta,p.basico_mes,CAST(p.centro As varchar) As centro,p.basico_hora,r.FechaEntrada,r.FechaSalida,c.sabado,c.domingo,c.festivo,SUM(f.extras )As ExtP ,SUM(t.ord_diur ) As OrdP,r.notas,f.id As id_enc , (SELECT SUM (horas) FROM R_compromiso_horas_a_pagar WHERE Nit_Trabajador= r.nit AND Activo = 'True' AND horas >0 and concepto_90 is null AND concepto_84 is null)As debe " &
                        "FROM r_personal_registros r , CORSAN.dbo.y_calendario c,CONTROL.dbo.J_personal_maquila p left join CORSAN.dbo.y_personal_contratos y on p.contrato=y.contrato , J_v_operario_fecha_turno f, CORSAN.dbo.J_turnos t  " &
                    "WHERE  t.id = f.id_turno AND p.nit = r.nit AND f.nit = r.nit AND CAST (r.FechaEntrada AS date ) = f.fecha AND CAST (r.FechaEntrada AS date ) = c.fecha AND p.desactivar is null AND FechaSalida is not null AND CAST(r.FechaEntrada AS date )  Between '" & fecIni & "' AND '" & fecFin & "  23:59:59' " & where_centro & where_operario & where_turno & " " &
                        "GROUP BY Consecutivo, r.nit ,p.nombres,p.oficio,p.centro,p.contrato,p.turno,p.planta,p.basico_hora,p.basico_mes ,r.FechaEntrada,r.FechaSalida,c.sabado,c.domingo,c.festivo,r.notas,f.id " &
                        sqlOrder
        End If
        Dim dt As DataTable = objOpSimplesLn.listar_datatable(sql, "CONTROL")
        Dim dtConceptos As New DataTable
        Dim dt_procesado As New DataTable
        Dim fec_hora_entro As Date
        Dim fec_hora_salio As Date
        Dim min_dif As Double = 0
        Dim horas_add As Double = 0
        Dim horas_ord As Double = 0
        Dim ord_prog As Double = 0
        Dim ext_prog As Double = 0
        Dim dia_compensatorio As Boolean = False
        Dim turno_sab_lunes_viernes As Boolean = False
        Dim dia_festivo As Boolean = False
        Dim dia_siguiente_festivo As Boolean = False

        Dim horas_semanales As Integer = 0


        dt_procesado.Columns.Add("Consec")
        dt_procesado.Columns.Add("debe")
        dt_procesado.Columns.Add("nit")
        dt_procesado.Columns.Add("nombres")
        dt_procesado.Columns.Add("centro")
        dt_procesado.Columns.Add("contrato")
        dt_procesado.Columns.Add("oficio")
        dt_procesado.Columns.Add("planta")
        dt_procesado.Columns.Add("turno")
        dt_procesado.Columns.Add("basico_hora")
        dt_procesado.Columns.Add("basico_mes", GetType(Double))
        dt_procesado.Columns.Add("dia")
        dt_procesado.Columns.Add("fechaEntrada")
        dt_procesado.Columns.Add("fechaSalida")
        dt_procesado.Columns.Add("ExtP", GetType(Integer))
        dt_procesado.Columns.Add("OrdP", GetType(Integer))
        dt_procesado.Columns.Add("total", GetType(Integer))
        dt_procesado.Columns.Add("OrD", GetType(Integer)) '------------------concepto = 1
        dt_procesado.Columns.Add("RN", GetType(Integer)) '------------------concepto = 30
        dt_procesado.Columns.Add("DD", GetType(Integer)) '------------------concepto = 31
        dt_procesado.Columns.Add("DN", GetType(Integer)) '------------------concepto = 32
        dt_procesado.Columns.Add("ED", GetType(Integer)) '------------------concepto = 13
        dt_procesado.Columns.Add("EN", GetType(Integer)) '------------------concepto = 14
        dt_procesado.Columns.Add("EDF", GetType(Integer)) '------------------concepto = 15
        dt_procesado.Columns.Add("ENF", GetType(Integer)) '------------------concepto = 16
        dt_procesado.Columns.Add("DComp", GetType(Integer)) '------------------concepto =33
        dt_procesado.Columns.Add("turnoProg")
        dt_procesado.Columns.Add("notas")
        dt_procesado.Columns.Add("id_enc")
        dt_procesado.Columns.Add("domingo")
        dt_procesado.Columns.Add("festivo")

        If (dt.Rows.Count - 1 <> -1) Then
            progBar.Maximum = dt.Rows.Count - 1
            progBar.Minimum = 0
        End If
        For i = 0 To dt.Rows.Count - 1
            progBar.PerformStep()
            progBar.Refresh()
            dt_procesado.Rows.Add()
            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("Consec") = dt.Rows(i).Item("Consec")
            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("nit") = dt.Rows(i).Item("nit")
            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("nombres") = dt.Rows(i).Item("nombres")
            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("centro") = dt.Rows(i).Item("centro")
            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("contrato") = dt.Rows(i).Item("contrato")
            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("oficio") = dt.Rows(i).Item("oficio")
            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("planta") = dt.Rows(i).Item("planta")
            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("turno") = dt.Rows(i).Item("turno")
            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("basico_hora") = dt.Rows(i).Item("basico_hora")
            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("basico_mes") = dt.Rows(i).Item("basico_mes")
            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("fechaEntrada") = dt.Rows(i).Item("FechaEntrada")
            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("fechaSalida") = dt.Rows(i).Item("FechaSalida")
            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("dia") = WeekdayName(Weekday(dt.Rows(i).Item("FechaEntrada")), True, 1)
            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ExtP") = dt.Rows(i).Item("ExtP")
            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrdP") = dt.Rows(i).Item("OrdP")
            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("notas") = dt.Rows(i).Item("notas")
            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("id_enc") = dt.Rows(i).Item("id_enc")
            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("domingo") = dt.Rows(i).Item("domingo")
            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("festivo") = dt.Rows(i).Item("festivo")
            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("debe") = dt.Rows(i).Item("debe")
            fec_hora_entro = dt.Rows(i).Item("FechaEntrada")
            fec_hora_salio = dt.Rows(i).Item("FechaSalida")
            ord_prog = dt.Rows(i).Item("OrdP")
            ext_prog = dt.Rows(i).Item("ExtP")
            addTurno(dt_procesado, i)
            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("total") = DateDiff(DateInterval.Hour, fec_hora_entro, fec_hora_salio)
            If es_compensatorio(dt_procesado, i) Then
                dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DComp") = ord_prog
                dia_compensatorio = True
            Else
                dia_compensatorio = False
            End If


            dia_festivo = verificar_fecha_festiva(fec_hora_entro)

            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") = 0
            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("RN") = 0
            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DD") = 0
            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DN") = 0
            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ED") = 0
            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EN") = 0
            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ENF") = 0
            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EDF") = 0






            '' se verifica si tiene dutno 10 horas L-V para poner el día como extra
            'If ((objRelojLn.verificar_turno_periodo(dt.Rows(i).Item("nit"), id_periodo, 4, fec_hora_entro) Or
            '                      objRelojLn.verificar_turno_periodo(dt.Rows(i).Item("nit"), id_periodo, 5, fec_hora_entro) Or
            '                          objRelojLn.verificar_turno_periodo(dt.Rows(i).Item("nit"), id_periodo, 6, fec_hora_entro) Or
            '    objRelojLn.verificar_turno_periodo(dt.Rows(i).Item("nit"), id_periodo, 21, fec_hora_entro)) And dt.Rows(i).Item("sabado") = "True") Then
            '    'objRelojLn.verificar_turno_periodo(dt.Rows(i).Item("nit"), id_periodo, 20, fec_hora_entro) Or 
            '    turno_sab_lunes_viernes = True
            '    dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ExtP") += dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrdP")
            '    dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrdP") = 0
            'Else
            '    If dia_festivo Then
            '        'Se verifica si al día es festivo y el turno programado es en el día
            '        If ((objRelojLn.verificar_turno_periodo(dt.Rows(i).Item("nit"), id_periodo, 1, fec_hora_entro) Or
            '                     objRelojLn.verificar_turno_periodo(dt.Rows(i).Item("nit"), id_periodo, 2, fec_hora_entro) Or
            '                         objRelojLn.verificar_turno_periodo(dt.Rows(i).Item("nit"), id_periodo, 7, fec_hora_entro) Or
            '                           objRelojLn.verificar_turno_periodo(dt.Rows(i).Item("nit"), id_periodo, 8, fec_hora_entro))) Then
            '            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ExtP") += dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrdP")
            '            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrdP") = 0
            '        End If

            '        'SE VERIFICA SI EL DIA ES FESTIVO Y EL TURNO PROGRAMADO ES EN LA NOCHE
            '        If ((objRelojLn.verificar_turno_periodo(dt.Rows(i).Item("nit"), id_periodo, 3, fec_hora_entro) Or
            '                     objRelojLn.verificar_turno_periodo(dt.Rows(i).Item("nit"), id_periodo, 9, fec_hora_entro) Or
            '                         objRelojLn.verificar_turno_periodo(dt.Rows(i).Item("nit"), id_periodo, 21, fec_hora_entro))) Then
            '            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrdP") = 0
            '            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") = 0
            '            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ExtP") = 0
            '            'dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ExtP") += dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrdP")

            '        End If


            '    End If
            '    turno_sab_lunes_viernes = False
            'End If


            If fec_hora_entro.Hour = 21 Then
                fec_hora_entro = fec_hora_entro.AddHours(1)
                fec_hora_entro = fec_hora_entro.AddMinutes(-fec_hora_entro.Minute)
                'ElseIf fec_hora_entro.Hour = 20 Then
                '    fec_hora_entro = fec_hora_entro.AddHours(2)
                '    fec_hora_entro = fec_hora_entro.AddMinutes(-fec_hora_entro.Minute)
                'ElseIf fec_hora_entro.Hour = 19 Then
                '    If fec_hora_entro.Minute >= 40 Then
                '        fec_hora_entro = fec_hora_entro.AddHours(3)
                '        fec_hora_entro = fec_hora_entro.AddMinutes(-fec_hora_entro.Minute)
                '    End If
            End If
            If fec_hora_entro.Hour = 17 Then
                fec_hora_entro = fec_hora_entro.AddHours(1)
                fec_hora_entro = fec_hora_entro.AddMinutes(-fec_hora_entro.Minute)
            End If
            If fec_hora_entro.Hour >= 4 And fec_hora_entro.Hour < 6 Then
                fec_hora_entro = fec_hora_entro.AddHours(1)
                fec_hora_entro = fec_hora_entro.AddMinutes(-fec_hora_entro.Minute)
            End If
            '   VERIFICAR PARA CONTROLAR RELOJ 
            'While (fec_hora_entro <= fec_hora_salio)
            '    dia_siguiente_festivo = verificar_dia_siguiente_festivo(fec_hora_entro)
            '    dia_festivo = verificar_fecha_festiva(fec_hora_entro)
            '    min_dif = DateDiff(DateInterval.Minute, fec_hora_entro, fec_hora_salio)


            'If (min_dif >= 45) Then
            horas_add = 1

            ''TENIENDO EN CUENTA LA CANTIDAD DE HORAS A LA SEMANA, YU TENIENDO EN CUENTA QUE TODAS LAS QUINCENAS NO EMPIEZAN EN DIA LUNES.
            '' SE DEBE VALIDAR QUE.

            ''* LOS SABADOS COMUNES SEAN <= 48 HORAS
            ''* LOS SABADOS FESTIVOS.
            ''* SABADOS NOCTURNOS PARA HORAS DOMINICALES 
            ''* FESTIVOS 
            ''* DIAS COMUNES
            ''* DIAS COMUNES CON TURNO NOCTURNO- VALIDAR FESTIVOS DIA SIGUIENTE

            Dim horas_trabajadas As Integer
            horas_trabajadas = (fec_hora_salio.Hour - fec_hora_entro.Hour)

            ''SE VERIFICA QUE SEA FESTIVO
            If (dia_festivo) Then

                ''VERIFICAMOS SI ENTRA EN LA MAÑANA 
                If (fec_hora_entro.TimeOfDay >= TimeSpan.Parse("05:00:00") And fec_hora_entro.TimeOfDay <= TimeSpan.Parse("20:30:00")) Then
                    'VALIDAMOS PARA PONERLE EN HORAS EXTRAS SI SUPERA LAS 48 HORAS
                    If (horas_semanales < 48) Then
                        'dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DD") += horas_add
                        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DD") += horas_trabajadas
                        horas_semanales += 1
                    Else
                        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EDF") += horas_add
                        horas_semanales += 1
                    End If
                End If

                ''VERIFICAMOS SI ENTRA EN LA TARDE 
                If (fec_hora_entro.TimeOfDay >= TimeSpan.Parse("09:30:00") And fec_hora_entro.TimeOfDay <= TimeSpan.Parse("22:30:00")) Then
                    'VALIDAMOS PARA PONERLE EN HORAS EXTRAS SI SUPERA LAS 48 HORAS
                    If (horas_semanales < 48) Then
                        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DD") += horas_add
                        horas_semanales += 1
                        ''validamos que la hora de entrada, para ver si coge horas de recargo noturno
                        If (fec_hora_entro.TimeOfDay >= TimeSpan.Parse("21:00:00")) Then
                            ''coge recargo nocturno
                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DN") += horas_add
                            horas_semanales += 1
                        End If
                    Else
                        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EDF") += horas_add
                        horas_semanales += 1
                        ''validamos que la hora de entrada, para ver si coge horas de recargo noturno
                        If (fec_hora_entro.TimeOfDay >= TimeSpan.Parse("21:00:00")) Then
                            ''coge recargo nocturno
                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ENF") += horas_add
                            horas_semanales += 1
                        End If
                    End If
                End If

                ''VERIFICAMOS SI ENTRA EN LA NOCHE
                If (fec_hora_entro.TimeOfDay >= TimeSpan.Parse("17:30:00") And fec_hora_entro.TimeOfDay <= TimeSpan.Parse("07:30:00")) Then

                    'VERIFICAMOS SI EL DIA SIGUIENTE ES FESTIVO
                    If (dia_siguiente_festivo) Then

                        'VALIDAMOS PARA PONERLE EN HORAS EXTRAS SI SUPERA LAS 48 HORAS
                        If (horas_semanales < 48) Then
                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DN") += horas_add
                            horas_semanales += 1
                        Else
                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ENF") += horas_add
                            horas_semanales += 1
                        End If
                    Else
                        If (horas_semanales < 48) Then

                            If (fec_hora_entro.TimeOfDay <= TimeSpan.Parse("00:00:00")) Then
                                dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DN") += horas_add
                                horas_semanales += 1
                            Else
                                dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("RN") += horas_add
                                horas_semanales += 1
                            End If

                        Else
                            If (fec_hora_entro.TimeOfDay <= TimeSpan.Parse("00:00:00")) Then
                                dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ENF") += horas_add
                                horas_semanales += 1
                            Else
                                dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("RN") += horas_add
                                horas_semanales += 1
                            End If

                        End If

                    End If
                End If
            End If
            ''FIN DIA festivo


            ''VALIDAMOS QUE SEA SABADO CON MENOS DE 48 HORAS PARA PONER EN HORAS ORDINARIAS
            If (dt.Rows(i).Item("sabado") = "True" And horas_semanales <= 48) Then

                ''VERIFICAMOS SI ENTRA EN LA MAÑANA 
                If (fec_hora_entro.TimeOfDay >= TimeSpan.Parse("05:00:00") And fec_hora_entro.TimeOfDay <= TimeSpan.Parse("20:30:00")) Then
                    'VALIDAMOS PARA PONERLE EN HORAS EXTRAS SI SUPERA LAS 48 HORAS
                    If (horas_semanales < 48) Then
                        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") += horas_add
                        horas_semanales += 1
                    Else
                        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ED") += horas_add
                        horas_semanales += 1
                    End If
                End If

                ''VERIFICAMOS SI ENTRA EN LA TARDE 
                If (fec_hora_entro.TimeOfDay >= TimeSpan.Parse("09:30:00") And fec_hora_entro.TimeOfDay <= TimeSpan.Parse("22:30:00")) Then
                    'VALIDAMOS PARA PONERLE EN HORAS EXTRAS SI SUPERA LAS 48 HORAS
                    If (horas_semanales < 48) Then
                        ''validamos que la hora de entrada, para ver si coge horas de recargo noturno
                        If (fec_hora_entro.TimeOfDay >= TimeSpan.Parse("21:00:00")) Then
                            ''coge recargo nocturno
                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("RN") += horas_add
                            horas_semanales += 1
                        Else
                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") += horas_add
                            horas_semanales += 1
                        End If
                    Else
                        ''validamos que la hora de entrada, para ver si coge horas de recargo noturno
                        If (fec_hora_entro.TimeOfDay >= TimeSpan.Parse("21:00:00")) Then
                            ''coge recargo nocturno
                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EN") += horas_add
                            horas_semanales += 1
                        Else
                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ED") += horas_add
                            horas_semanales += 1
                        End If
                    End If
                End If

                ''VERIFICAMOS SI ENTRA EN LA NOCHE
                If (fec_hora_entro.TimeOfDay >= TimeSpan.Parse("17:30:00") And fec_hora_entro.TimeOfDay <= TimeSpan.Parse("07:30:00")) Then
                    'VALIDAMOS PARA PONERLE EN HORAS EXTRAS SI SUPERA LAS 48 HORAS
                    If (horas_semanales < 48) Then
                        If (fec_hora_entro.TimeOfDay <= TimeSpan.Parse("00:00:00")) Then
                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("RN") += horas_add
                            horas_semanales += 1
                        Else
                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DN") += horas_add
                            horas_semanales += 1
                        End If
                    Else
                        If (fec_hora_entro.TimeOfDay <= TimeSpan.Parse("00:00:00")) Then
                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EN") += horas_add
                            horas_semanales += 1
                        Else
                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ENF") += horas_add
                            horas_semanales += 1
                        End If
                    End If


                End If

            End If


            ''VALIDAMOS QUE SEA SABADO CON MAS DE 48 HORAS PARA PONER EN HORAS EXTRAS
            If (dt.Rows(i).Item("sabado") = "True" And horas_semanales > 48) Then

                ''VERIFICAMOS SI ENTRA EN LA MAÑANA 
                If (fec_hora_entro.TimeOfDay >= TimeSpan.Parse("05:00:00") And fec_hora_entro.TimeOfDay <= TimeSpan.Parse("20:30:00")) Then
                    'VALIDAMOS PARA PONERLE EN HORAS EXTRAS SI SUPERA LAS 48 HORAS
                    If (horas_semanales < 48) Then
                        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") += horas_add
                        horas_semanales += 1
                    Else
                        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ED") += horas_add
                        horas_semanales += 1
                    End If
                End If

                ''VERIFICAMOS SI ENTRA EN LA TARDE 
                If (fec_hora_entro.TimeOfDay >= TimeSpan.Parse("09:30:00") And fec_hora_entro.TimeOfDay <= TimeSpan.Parse("22:30:00")) Then
                    'VALIDAMOS PARA PONERLE EN HORAS EXTRAS SI SUPERA LAS 48 HORAS
                    If (horas_semanales < 48) Then
                        ''validamos que la hora de entrada, para ver si coge horas de recargo noturno
                        If (fec_hora_entro.TimeOfDay >= TimeSpan.Parse("21:00:00")) Then
                            ''coge recargo nocturno
                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("RN") += horas_add
                            horas_semanales += 1
                        Else
                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") += horas_add
                            horas_semanales += 1
                        End If
                    Else
                        ''validamos que la hora de entrada, para ver si coge horas de recargo noturno
                        If (fec_hora_entro.TimeOfDay >= TimeSpan.Parse("21:00:00")) Then
                            ''coge recargo nocturno
                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EN") += horas_add
                            horas_semanales += 1
                        Else
                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ED") += horas_add
                            horas_semanales += 1
                        End If
                    End If
                End If

                ''VERIFICAMOS SI ENTRA EN LA NOCHE
                If (fec_hora_entro.TimeOfDay >= TimeSpan.Parse("17:30:00") And fec_hora_entro.TimeOfDay <= TimeSpan.Parse("07:30:00")) Then
                    'VALIDAMOS PARA PONERLE EN HORAS EXTRAS SI SUPERA LAS 48 HORAS
                    If (horas_semanales < 48) Then
                        If (fec_hora_entro.TimeOfDay <= TimeSpan.Parse("00:00:00")) Then
                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("RN") += horas_add
                            horas_semanales += 1
                        Else
                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DN") += horas_add
                            horas_semanales += 1
                        End If
                    Else
                        If (fec_hora_entro.TimeOfDay <= TimeSpan.Parse("00:00:00")) Then
                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EN") += horas_add
                            horas_semanales += 1
                        Else
                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ENF") += horas_add
                            horas_semanales += 1
                        End If
                    End If


                End If

            End If




            ''VALIDAMOS QUE SEA SABADO FESTIVO
            If (dt.Rows(i).Item("sabado") = "True" And horas_semanales > 48 And dt.Rows(i).Item("festivo") = "True") Then

                ''VERIFICAMOS SI ENTRA EN LA MAÑANA 
                If (fec_hora_entro.TimeOfDay >= TimeSpan.Parse("05:00:00") And fec_hora_entro.TimeOfDay <= TimeSpan.Parse("20:30:00")) Then
                    'VALIDAMOS PARA PONERLE EN HORAS EXTRAS SI SUPERA LAS 48 HORAS
                    If (horas_semanales < 48) Then
                        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DD") += horas_add
                        horas_semanales += 1
                    Else
                        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EDF") += horas_add
                        horas_semanales += 1
                    End If
                End If

                ''VERIFICAMOS SI ENTRA EN LA TARDE 
                If (fec_hora_entro.TimeOfDay >= TimeSpan.Parse("09:30:00") And fec_hora_entro.TimeOfDay <= TimeSpan.Parse("22:30:00")) Then
                    'VALIDAMOS PARA PONERLE EN HORAS EXTRAS SI SUPERA LAS 48 HORAS
                    If (horas_semanales < 48) Then
                        ''validamos que la hora de entrada, para ver si coge horas de recargo noturno
                        If (fec_hora_entro.TimeOfDay >= TimeSpan.Parse("21:00:00")) Then
                            ''coge recargo nocturno
                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DN") += horas_add
                            horas_semanales += 1
                        Else
                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DD") += horas_add
                            horas_semanales += 1
                        End If
                    Else
                        ''validamos que la hora de entrada, para ver si coge horas de recargo noturno
                        If (fec_hora_entro.TimeOfDay >= TimeSpan.Parse("21:00:00")) Then
                            ''coge recargo nocturno
                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ENF") += horas_add
                            horas_semanales += 1
                        Else
                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EDF") += horas_add
                            horas_semanales += 1
                        End If
                    End If
                End If

                ''VERIFICAMOS SI ENTRA EN LA NOCHE
                If (fec_hora_entro.TimeOfDay >= TimeSpan.Parse("17:30:00") And fec_hora_entro.TimeOfDay <= TimeSpan.Parse("07:30:00")) Then
                    'VALIDAMOS PARA PONERLE EN HORAS EXTRAS SI SUPERA LAS 48 HORAS
                    If (horas_semanales < 48) Then
                        If (fec_hora_entro.TimeOfDay <= TimeSpan.Parse("00:00:00")) Then
                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DN") += horas_add
                            horas_semanales += 1
                        Else
                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") += horas_add
                            horas_semanales += 1
                        End If
                    Else
                        If (fec_hora_entro.TimeOfDay <= TimeSpan.Parse("00:00:00")) Then
                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ENF") += horas_add
                            horas_semanales += 1
                        Else
                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EN") += horas_add
                            horas_semanales += 1
                        End If
                    End If


                End If

            End If


            ''VALIDAMOS QUE SEA DIAS ORDINARIOS
            If (dt.Rows(i).Item("sabado") = "false" And dt.Rows(i).Item("festivo") = "false" And dt.Rows(i).Item("festivo") = "false") Then

                ''VERIFICAMOS SI ENTRA EN LA MAÑANA 
                If (fec_hora_entro.TimeOfDay >= TimeSpan.Parse("05:00:00") And fec_hora_entro.TimeOfDay <= TimeSpan.Parse("20:30:00")) Then
                    'VALIDAMOS PARA PONERLE EN HORAS EXTRAS SI SUPERA LAS 48 HORAS
                    If (horas_semanales < 48) Then
                        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") += horas_add
                        horas_semanales += 1
                    Else
                        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ED") += horas_add
                        horas_semanales += 1
                    End If
                End If

                ''VERIFICAMOS SI ENTRA EN LA TARDE 
                If (fec_hora_entro.TimeOfDay >= TimeSpan.Parse("09:30:00") And fec_hora_entro.TimeOfDay <= TimeSpan.Parse("22:30:00")) Then
                    'VALIDAMOS PARA PONERLE EN HORAS EXTRAS SI SUPERA LAS 48 HORAS
                    If (horas_semanales < 48) Then
                        ''validamos que la hora de entrada, para ver si coge horas de recargo noturno
                        If (fec_hora_entro.TimeOfDay >= TimeSpan.Parse("21:00:00")) Then
                            ''coge recargo nocturno
                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("RN") += horas_add
                            horas_semanales += 1
                        Else
                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") += horas_add
                            horas_semanales += 1
                        End If
                    Else
                        ''validamos que la hora de entrada, para ver si coge horas de recargo noturno
                        If (fec_hora_entro.TimeOfDay >= TimeSpan.Parse("21:00:00")) Then
                            ''coge recargo nocturno
                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EN") += horas_add
                            horas_semanales += 1
                        Else
                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ED") += horas_add
                            horas_semanales += 1
                        End If
                    End If
                End If

                ''VERIFICAMOS SI ENTRA EN LA NOCHE
                If (fec_hora_entro.TimeOfDay >= TimeSpan.Parse("17:30:00") And fec_hora_entro.TimeOfDay <= TimeSpan.Parse("07:30:00")) Then
                    'VALIDAMOS PARA PONERLE EN HORAS EXTRAS SI SUPERA LAS 48 HORAS
                    If (horas_semanales < 48) Then
                        If (fec_hora_entro.TimeOfDay <= TimeSpan.Parse("00:00:00")) Then
                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("RN") += horas_add
                            horas_semanales += 1
                        Else
                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") += horas_add
                            horas_semanales += 1
                        End If
                    Else
                        If (fec_hora_entro.TimeOfDay <= TimeSpan.Parse("00:00:00")) Then
                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EN") += horas_add
                            horas_semanales += 1
                        Else
                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EN") += horas_add
                            horas_semanales += 1
                        End If
                    End If


                End If

            End If












            '    If (fec_hora_entro.TimeOfDay >= TimeSpan.Parse("05:30:00") And fec_hora_entro.TimeOfDay <= TimeSpan.Parse("20:30:00")) Then
            '        If (dt.Rows(i).Item("domingo") = "True" Or dt.Rows(i).Item("festivo") = "True") Then
            '            If Not dia_compensatorio Then
            '                If objRelojLn.verificar_turno_dia(dt.Rows(i).Item("nit"), objOpSimplesLn.cambiarFormatoFecha(dt.Rows(i).Item("FechaEntrada")), 3) Or
            '                                   objRelojLn.verificar_turno_dia(dt.Rows(i).Item("nit"), objOpSimplesLn.cambiarFormatoFecha(dt.Rows(i).Item("FechaEntrada")), 9) Or
            '                                     objRelojLn.verificar_turno_dia(dt.Rows(i).Item("nit"), objOpSimplesLn.cambiarFormatoFecha(dt.Rows(i).Item("FechaEntrada")), 11) Or
            '                                         objRelojLn.verificar_turno_dia(dt.Rows(i).Item("nit"), objOpSimplesLn.cambiarFormatoFecha(dt.Rows(i).Item("FechaEntrada")), 13) Or
            '                                         objRelojLn.verificar_turno_dia(dt.Rows(i).Item("nit"), objOpSimplesLn.cambiarFormatoFecha(dt.Rows(i).Item("FechaEntrada")), 20) Then
            '                    If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DD")) Then
            '                        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DD") = horas_add
            '                        horas_ord += horas_add
            '                        If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD")) Then
            '                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") = horas_add
            '                        Else
            '                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") += horas_add
            '                        End If
            '                    Else
            '                        If (dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DD") < ord_prog And horas_ord < ord_prog) Then
            '                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DD") += horas_add
            '                            horas_ord += horas_add
            '                            If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD")) Then
            '                                dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") = horas_add
            '                            Else
            '                                dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") += horas_add
            '                            End If
            '                        Else
            '                            If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EDF")) Then
            '                                dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EDF") = horas_add
            '                            Else
            '                                dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EDF") += horas_add
            '                            End If
            '                        End If
            '                    End If
            '                Else
            '                    If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EDF")) Then
            '                        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EDF") = horas_add
            '                    Else
            '                        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EDF") += horas_add
            '                    End If

            '                End If
            '            Else
            '                If (horas_ord < ord_prog) Then
            '                    horas_ord += horas_add
            '                Else
            '                    If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EDF")) Then
            '                        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EDF") = horas_add
            '                    Else
            '                        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EDF") += horas_add
            '                    End If
            '                End If



            '            End If
            '        ElseIf (dt.Rows(i).Item("sabado") = "True") Then
            '            If Not dia_compensatorio Then
            '                ' se verifica si tiene dutno 10 horas L-V para poner el día como extra
            '                If (turno_sab_lunes_viernes) Then
            '                    If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ED")) Then
            '                        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ED") = horas_add
            '                    Else
            '                        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ED") += horas_add
            '                    End If
            '                Else
            '                    If ord_prog = 0 And ext_prog > 0 Then
            '                        If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ED")) Then
            '                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ED") = horas_add
            '                        Else
            '                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ED") += horas_add
            '                        End If
            '                    Else
            '                        If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD")) Then
            '                            If ord_prog = 0 And ext_prog = 0 Then
            '                                If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ED")) Then
            '                                    dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ED") = horas_add
            '                                Else
            '                                    dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ED") += horas_add
            '                                End If
            '                            Else
            '                                dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") = horas_add
            '                                horas_ord += horas_add
            '                            End If

            '                        Else
            '                            If (dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") < ord_prog And horas_ord < ord_prog) Then
            '                                dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") += horas_add
            '                                horas_ord += horas_add
            '                            Else
            '                                If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ED")) Then
            '                                    dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ED") = horas_add
            '                                Else
            '                                    dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ED") += horas_add
            '                                End If
            '                            End If
            '                        End If
            '                    End If
            '                End If
            '            End If
            '        Else
            '            If ord_prog = 0 And ext_prog > 0 Then
            '                If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ED")) Then
            '                    dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ED") = horas_add
            '                Else
            '                    dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ED") += horas_add
            '                End If
            '            Else
            '                If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD")) Then
            '                    dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") = horas_add
            '                    horas_ord += horas_add
            '                Else
            '                    If (dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") < ord_prog And horas_ord < ord_prog) Then
            '                        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") += horas_add
            '                        horas_ord += horas_add
            '                    Else
            '                        If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ED")) Then
            '                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ED") = horas_add
            '                        Else
            '                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ED") += horas_add
            '                        End If
            '                    End If
            '                End If
            '            End If
            '        End If
            '    Else
            '        If (dia_siguiente_festivo) Then
            '            If objRelojLn.verificar_turno_dia(dt.Rows(i).Item("nit"), objOpSimplesLn.cambiarFormatoFecha(dt.Rows(i).Item("FechaEntrada")), 3) Or
            '                           objRelojLn.verificar_turno_dia(dt.Rows(i).Item("nit"), objOpSimplesLn.cambiarFormatoFecha(dt.Rows(i).Item("FechaEntrada")), 9) Or
            '                             objRelojLn.verificar_turno_dia(dt.Rows(i).Item("nit"), objOpSimplesLn.cambiarFormatoFecha(dt.Rows(i).Item("FechaEntrada")), 11) Or
            '                                 objRelojLn.verificar_turno_dia(dt.Rows(i).Item("nit"), objOpSimplesLn.cambiarFormatoFecha(dt.Rows(i).Item("FechaEntrada")), 13) Then
            '                If dia_compensatorio Then
            '                    If (horas_ord < ord_prog) Then
            '                        horas_ord += horas_add
            '                    Else
            '                        If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EN")) Then
            '                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EN") = horas_add
            '                        Else
            '                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EN") += horas_add
            '                        End If
            '                    End If
            '                Else

            '                    ' If (dia_festivo) Then
            '                    'If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ENF")) Then
            '                    'dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ENF") = horas_add
            '                    'Else
            '                    'dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ENF") += horas_add
            '                    'End If
            '                    'ElseIf dia_siguiente_festivo = True And fec_hora_entro.TimeOfDay >= TimeSpan.Parse("22:00:00") Then
            '                    'If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EN")) Then
            '                    'dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EN") = horas_add
            '                    'Else
            '                    'dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EN") += horas_add
            '                    'End If
            '                    '   End If


            '                    ' PRUEBA PARA HACER QUE NO SALGA EN ENF Y SALGA EN RECARGO NOTURNO POR SER FESTIVO NOTURNO
            '                    'If (dia_festivo) Then
            '                    'If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("RN")) Then
            '                    '    dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("RN") = horas_add
            '                    ' Else
            '                    '      dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("RN") += horas_add
            '                    '   End If
            '                    'ElseIf dia_siguiente_festivo = True And fec_hora_entro.TimeOfDay >= TimeSpan.Parse("22:00:00") Then
            '                    '    If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EN")) Then
            '                    '     dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EN") = horas_add
            '                    '  Else
            '                    '       dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EN") += horas_add
            '                    'End If
            '                    'End If


            '                    '''''PRUEBA 2 DIAS FESTIVOS
            '                    If (dia_festivo) Then
            '                        If (dia_siguiente_festivo = True) Then
            '                            If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DN")) Then
            '                                dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DN") = horas_add
            '                            Else
            '                                dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DN") += horas_add
            '                            End If
            '                            ''prueba ord
            '                            If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD")) Then
            '                                dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") = 0
            '                            Else
            '                                dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") += 0
            '                            End If
            '                            ''prueba extp
            '                            If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ExtP")) Then
            '                                dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ExtP") = 0
            '                            Else
            '                                dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ExtP") = 0
            '                            End If
            '                            ''prueba ordp
            '                            If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrdP")) Then
            '                                dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrdP") = 0
            '                            Else
            '                                dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrdP") += 0
            '                            End If

            '                        End If

            '                        If (dia_siguiente_festivo = False) Then
            '                            If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("RN")) Then
            '                                dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("RN") = horas_add
            '                            Else
            '                                dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("RN") += horas_add
            '                            End If
            '                        End If







            '                    ElseIf dia_siguiente_festivo = True And fec_hora_entro.TimeOfDay >= TimeSpan.Parse("22:00:00") Then
            '                        If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EN")) Then
            '                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EN") = horas_add
            '                        Else
            '                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EN") += horas_add
            '                        End If
            '                    End If

            '                    'dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ExtP") += horas_add
            '                End If
            '            Else
            '                If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("RN")) Then
            '                    dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("RN") = horas_add
            '                    horas_ord += horas_add
            '                    If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD")) Then
            '                        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") = horas_add
            '                    Else
            '                        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") += horas_add
            '                    End If
            '                Else
            '                    If (dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("RN") < ord_prog And horas_ord < ord_prog) Then
            '                        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("RN") += horas_add
            '                        horas_ord += horas_add
            '                        If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD")) Then
            '                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") = horas_add
            '                        Else
            '                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") += horas_add
            '                        End If
            '                    Else
            '                        If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EN")) Then
            '                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EN") = horas_add
            '                        Else
            '                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EN") += horas_add
            '                        End If
            '                    End If
            '                End If
            '            End If
            '        ElseIf dia_festivo = True Then


            '            If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DN")) Then
            '                If dt.Rows(i).Item("domingo") = "True" Or dt.Rows(i).Item("festivo") = "True" Then
            '                    dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DN") = horas_add
            '                End If
            '                horas_ord += horas_add
            '                If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD")) Then
            '                    dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") = horas_add
            '                Else
            '                    dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") += horas_add
            '                End If
            '            Else
            '                If dt.Rows(i).Item("domingo") = "True" Or dt.Rows(i).Item("festivo") = "True" Then
            '                    dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DN") += horas_add
            '                End If
            '                horas_ord += horas_add
            '                If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD")) Then
            '                    dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") = horas_add
            '                Else
            '                    dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") += horas_add
            '                End If
            '            End If
            '            If dt.Rows(i).Item("sabado") = "True" Then
            '                If (fec_hora_entro.TimeOfDay >= TimeSpan.Parse("00:00:00") And fec_hora_entro.TimeOfDay <= TimeSpan.Parse("06:00:00")) Then
            '                    If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ENF")) Then
            '                        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ENF") = horas_add
            '                    Else
            '                        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ENF") += horas_add
            '                    End If
            '                End If
            '            End If
            '        ElseIf (dt.Rows(i).Item("domingo") = "True" Or dt.Rows(i).Item("festivo") = "True") Then
            '            If dt.Rows(i).Item("nit") = 8430837 Then
            '                Dim a As String = fec_hora_entro
            '            End If
            '            If Not dia_compensatorio Then
            '                If objRelojLn.verificar_turno_dia(dt.Rows(i).Item("nit"), objOpSimplesLn.cambiarFormatoFecha(dt.Rows(i).Item("FechaEntrada")), 3) Or
            '                      objRelojLn.verificar_turno_dia(dt.Rows(i).Item("nit"), objOpSimplesLn.cambiarFormatoFecha(dt.Rows(i).Item("FechaEntrada")), 9) Or
            '                        objRelojLn.verificar_turno_dia(dt.Rows(i).Item("nit"), objOpSimplesLn.cambiarFormatoFecha(dt.Rows(i).Item("FechaEntrada")), 11) Or
            '                            objRelojLn.verificar_turno_dia(dt.Rows(i).Item("nit"), objOpSimplesLn.cambiarFormatoFecha(dt.Rows(i).Item("FechaEntrada")), 13) Or
            '                            objRelojLn.verificar_turno_dia(dt.Rows(i).Item("nit"), objOpSimplesLn.cambiarFormatoFecha(dt.Rows(i).Item("FechaEntrada")), 20) Then
            '                    If (Weekday(fec_hora_entro, vbMonday) = 7 Or dia_festivo) Then
            '                        If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DN")) Then
            '                            'dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DN") = horas_add
            '                            horas_ord += horas_add
            '                            If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD")) Then
            '                                dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") = horas_add
            '                            Else
            '                                dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") += horas_add
            '                            End If
            '                        Else
            '                            If (dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DN") < ord_prog And horas_ord < ord_prog) Then
            '                                'dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DN") += horas_add
            '                                horas_ord += horas_add
            '                                If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD")) Then
            '                                    dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") = horas_add
            '                                Else
            '                                    dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") += horas_add
            '                                End If
            '                            Else
            '                                If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ENF")) Then
            '                                    dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ENF") = horas_add
            '                                Else
            '                                    dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ENF") += horas_add
            '                                End If
            '                            End If
            '                        End If
            '                    Else
            '                        If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("RN")) Then
            '                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("RN") = horas_add
            '                            horas_ord += horas_add
            '                            If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD")) Then
            '                                dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") = horas_add
            '                            Else
            '                                dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") += horas_add
            '                            End If
            '                        Else
            '                            If (dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("RN") < ord_prog And horas_ord < ord_prog) Then
            '                                dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("RN") += horas_add
            '                                horas_ord += horas_add
            '                                If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD")) Then
            '                                    dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") = horas_add
            '                                Else
            '                                    dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") += horas_add
            '                                End If
            '                            Else
            '                                If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EN")) Then
            '                                    dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EN") = horas_add
            '                                Else
            '                                    dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EN") += horas_add
            '                                End If
            '                            End If
            '                        End If
            '                    End If
            '                Else
            '                    If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ENF")) Then
            '                        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ENF") = horas_add
            '                    Else
            '                        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ENF") += horas_add
            '                    End If
            '                End If
            '            Else
            '                If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DN")) Then
            '                    horas_ord += horas_add
            '                Else
            '                    If (horas_ord < ord_prog) Then
            '                        horas_ord += horas_add
            '                    Else
            '                        If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ENF")) Then
            '                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ENF") = horas_add
            '                        Else
            '                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ENF") += horas_add
            '                        End If
            '                    End If
            '                End If
            '            End If
            '        Else
            '            If horas_ord >= ord_prog Then
            '                If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EN")) Then
            '                    dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EN") = horas_add
            '                Else
            '                    dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EN") += horas_add
            '                End If
            '            Else
            '                If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("RN")) Then
            '                    If ord_prog <> 0 Then
            '                        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("RN") = horas_add
            '                        horas_ord += horas_add
            '                        If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD")) Then
            '                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") = horas_add
            '                        Else
            '                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") += horas_add
            '                        End If
            '                    Else
            '                        If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EN")) Then
            '                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EN") = horas_add
            '                        Else
            '                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EN") += horas_add
            '                        End If
            '                    End If
            '                Else
            '                    If (dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("RN") < ord_prog And horas_ord < ord_prog) Then
            '                        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("RN") += horas_add
            '                        horas_ord += horas_add
            '                        If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD")) Then
            '                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") = horas_add
            '                        Else
            '                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") += horas_add
            '                        End If
            '                    Else
            '                        If IsDBNull(dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EN")) Then
            '                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EN") = horas_add
            '                        Else
            '                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EN") += horas_add
            '                        End If
            '                    End If
            '                End If
            '            End If
            '        End If
            '    End If
            'End If
            'End If

            If (horas_semanales = 48) Then
                horas_semanales = 0
            End If


            fec_hora_entro = fec_hora_entro.AddHours(1)
            'End While
            'Zona para agregar conceptos
            If chk_temporales.Checked = True Then
                dtConceptos = agregar_Conceptos(fec_hora_entro, dt.Rows(i).Item("nit"))
                For k = 0 To dtConceptos.Rows.Count - 1
                    If dtConceptos.Rows(k).Item("concepto") = 13 Then
                        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ED") = dtConceptos.Rows(k).Item("horas")
                    ElseIf dtConceptos.Rows(k).Item("concepto") = 14 Then
                        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EN") = dtConceptos.Rows(k).Item("horas")
                    ElseIf dtConceptos.Rows(k).Item("concepto") = 15 Then
                        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EDF") = dtConceptos.Rows(k).Item("horas")
                    ElseIf dtConceptos.Rows(k).Item("concepto") = 16 Then
                        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ENF") = dtConceptos.Rows(k).Item("horas")
                    ElseIf dtConceptos.Rows(k).Item("concepto") = 31 Then
                        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DD") = dtConceptos.Rows(k).Item("horas")
                    ElseIf dtConceptos.Rows(k).Item("concepto") = 32 Then
                        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DN") = dtConceptos.Rows(k).Item("horas")
                    End If
                Next
            End If
            horas_ord = 0
        Next
        dia_compensatorio = False
        dt_procesado.Rows.Add()
        Return dt_procesado
    End Function
    Private Function procesar_marcaciones(ByVal fecIni As String, ByVal fecFin As String, ByVal where_centro As String, ByVal where_operario As String, ByVal sqlOrder As String, ByVal where_turno As String) As DataTable
        Dim sql As String = "SELECT CAST(r.Consecutivo As varchar)As Consec,CAST(r.nit As varchar) As nit,p.nombres,p.oficio,p.contrato,y.turno,y.planta,y.basico_mes,CAST(p.centro As varchar) As centro,y.basico_hora,r.FechaEntrada,r.FechaSalida,c.sabado,c.domingo,c.festivo,SUM(f.extras )As ExtP ,SUM(t.ord_diur ) As OrdP,r.notas,f.id As id_enc , (SELECT SUM (horas) FROM R_compromiso_horas_a_pagar WHERE Nit_Trabajador= r.nit AND Activo = 'True' AND horas >0 AND concepto_90 is null AND concepto_84 is null)As debe " &
                        "FROM r_personal_registros r , CORSAN.dbo.y_calendario c,CORSAN.dbo.V_nom_personal_activo p ,CORSAN.dbo.y_personal_contratos y , J_v_operario_fecha_turno f, CORSAN.dbo.J_turnos t  " &
                    "WHERE t.id = f.id_turno AND p.contrato = y.contrato  AND p.nit = r.nit AND f.nit = r.nit AND CAST (r.FechaEntrada AS date ) = f.fecha AND CAST (r.FechaEntrada AS date ) = c.fecha AND FechaSalida is not null AND CAST(r.FechaEntrada AS date )  Between '" & fecIni & "' AND '" & fecFin & "  23:59:59' " & where_centro & where_operario & where_turno & " " &
                        "GROUP BY Consecutivo, r.nit ,p.nombres,p.oficio,p.centro,p.contrato,y.turno,y.planta,y.basico_hora,y.basico_mes ,r.FechaEntrada,r.FechaSalida,c.sabado,c.domingo,c.festivo,r.notas,f.id " &
                        sqlOrder
        If chk_temporales.Checked = True Then
            sql = "SELECT CAST(r.Consecutivo As varchar)As Consec,CAST(r.nit As varchar) As nit,p.nombres,p.oficio,p.contrato,p.turno,p.planta,p.basico_mes,CAST(p.centro As varchar) As centro,p.basico_hora,r.FechaEntrada,r.FechaSalida,c.sabado,c.domingo,c.festivo,SUM(f.extras )As ExtP ,SUM(t.ord_diur ) As OrdP,r.notas,f.id As id_enc , (SELECT SUM (horas) FROM R_compromiso_horas_a_pagar WHERE Nit_Trabajador= r.nit AND Activo = 'True' AND horas >0 and concepto_90 is null AND concepto_84 is null)As debe " &
                        "FROM r_personal_registros r , CORSAN.dbo.y_calendario c,CONTROL.dbo.J_personal_maquila p left join CORSAN.dbo.y_personal_contratos y on p.contrato=y.contrato , J_v_operario_fecha_turno f, CORSAN.dbo.J_turnos t  " &
                    "WHERE  t.id = f.id_turno AND p.nit = r.nit AND f.nit = r.nit AND CAST (r.FechaEntrada AS date ) = f.fecha AND CAST (r.FechaEntrada AS date ) = c.fecha AND p.desactivar is null AND FechaSalida is not null AND CAST(r.FechaEntrada AS date )  Between '" & fecIni & "' AND '" & fecFin & "  23:59:59' " & where_centro & where_operario & where_turno & " " &
                        "GROUP BY Consecutivo, r.nit ,p.nombres,p.oficio,p.centro,p.contrato,p.turno,p.planta,p.basico_hora,p.basico_mes ,r.FechaEntrada,r.FechaSalida,c.sabado,c.domingo,c.festivo,r.notas,f.id " &
                        sqlOrder
        End If
        Dim dt As DataTable = objOpSimplesLn.listar_datatable(sql, "CONTROL")
        Dim dtConceptos As New DataTable
        Dim dt_procesado As New DataTable
        Dim fec_hora_entro As Date
        Dim fec_hora_salio As Date
        Dim min_dif As Double = 0
        Dim horas_add As Double = 0
        Dim horas_ord As Double = 0
        Dim ord_prog As Double = 0
        Dim ext_prog As Double = 0
        Dim dia_compensatorio As Boolean = False
        Dim turno_sab_lunes_viernes As Boolean = False
        Dim dia_festivo As Boolean = False
        Dim dia_siguiente_festivo As Boolean = False


        ''prubea corregir
        Dim ExtP As Integer = 0
        Dim OrdP As Integer = 0
        Dim total As Integer = 0
        Dim OrD As Integer = 0
        Dim RN As Integer = 0
        Dim DD As Integer = 0
        Dim DN As Integer = 0
        Dim ED As Integer = 0
        Dim EDF As Integer = 0
        Dim ENF As Integer = 0
        Dim Dcomp As Integer = 0


        dt_procesado.Columns.Add("Consec")
        dt_procesado.Columns.Add("debe")
        dt_procesado.Columns.Add("nit")
        dt_procesado.Columns.Add("nombres")
        dt_procesado.Columns.Add("centro")
        dt_procesado.Columns.Add("contrato")
        dt_procesado.Columns.Add("oficio")
        dt_procesado.Columns.Add("planta")
        dt_procesado.Columns.Add("turno")
        dt_procesado.Columns.Add("basico_hora")
        dt_procesado.Columns.Add("basico_mes", GetType(Double))
        dt_procesado.Columns.Add("dia")
        dt_procesado.Columns.Add("fechaEntrada")
        dt_procesado.Columns.Add("fechaSalida")
        dt_procesado.Columns.Add("ExtP", GetType(Integer))
        dt_procesado.Columns.Add("OrdP", GetType(Integer))
        dt_procesado.Columns.Add("total", GetType(Integer))
        dt_procesado.Columns.Add("OrD", GetType(Integer)) '------------------concepto = 1
        dt_procesado.Columns.Add("RN", GetType(Integer)) '------------------concepto = 30
        dt_procesado.Columns.Add("DD", GetType(Integer)) '------------------concepto = 31
        dt_procesado.Columns.Add("DN", GetType(Integer)) '------------------concepto = 32
        dt_procesado.Columns.Add("ED", GetType(Integer)) '------------------concepto = 13
        dt_procesado.Columns.Add("EN", GetType(Integer)) '------------------concepto = 14
        dt_procesado.Columns.Add("EDF", GetType(Integer)) '------------------concepto = 15
        dt_procesado.Columns.Add("ENF", GetType(Integer)) '------------------concepto = 16
        dt_procesado.Columns.Add("DComp", GetType(Integer)) '------------------concepto =33
        dt_procesado.Columns.Add("turnoProg")
        dt_procesado.Columns.Add("notas")
        dt_procesado.Columns.Add("id_enc")
        dt_procesado.Columns.Add("domingo")
        dt_procesado.Columns.Add("festivo")


        If (dt.Rows.Count - 1 <> -1) Then
            progBar.Maximum = dt.Rows.Count - 1
            progBar.Minimum = 0
        End If
        For i = 0 To dt.Rows.Count - 1

            'prueba Dim ExtP As Integer = 0
            OrdP = dt.Rows(i).Item("OrdP")
            total = DateDiff(DateInterval.Hour, fec_hora_entro, fec_hora_salio)
            OrD = 0
            RN = 0
            DD = 0
            DN = 0
            ED = 0
            EDF = 0
            ENF = 0
            Dcomp = 0

            progBar.PerformStep()
            progBar.Refresh()
            dt_procesado.Rows.Add()
            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("Consec") = dt.Rows(i).Item("Consec")
            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("nit") = dt.Rows(i).Item("nit")
            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("nombres") = dt.Rows(i).Item("nombres")
            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("centro") = dt.Rows(i).Item("centro")
            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("contrato") = dt.Rows(i).Item("contrato")
            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("oficio") = dt.Rows(i).Item("oficio")
            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("planta") = dt.Rows(i).Item("planta")
            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("turno") = dt.Rows(i).Item("turno")
            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("basico_hora") = dt.Rows(i).Item("basico_hora")
            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("basico_mes") = dt.Rows(i).Item("basico_mes")
            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("fechaEntrada") = dt.Rows(i).Item("FechaEntrada")
            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("fechaSalida") = dt.Rows(i).Item("FechaSalida")
            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("dia") = WeekdayName(Weekday(dt.Rows(i).Item("FechaEntrada")), True, 1)
            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ExtP") = dt.Rows(i).Item("ExtP")
            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrdP") = dt.Rows(i).Item("OrdP")
            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("notas") = dt.Rows(i).Item("notas")
            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("id_enc") = dt.Rows(i).Item("id_enc")
            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("domingo") = dt.Rows(i).Item("domingo")
            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("festivo") = dt.Rows(i).Item("festivo")
            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("debe") = dt.Rows(i).Item("debe")
            fec_hora_entro = dt.Rows(i).Item("FechaEntrada")
            fec_hora_salio = dt.Rows(i).Item("FechaSalida")
            ord_prog = dt.Rows(i).Item("OrdP")
            ext_prog = dt.Rows(i).Item("ExtP")
            addTurno(dt_procesado, i)
            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("total") = DateDiff(DateInterval.Hour, fec_hora_entro, fec_hora_salio)
            If es_compensatorio(dt_procesado, i) Then
                dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DComp") = ord_prog
                dia_compensatorio = True
            Else
                dia_compensatorio = False
            End If


            ''iniciamos las columnas en cero


            Dim HorasTrabajadas As Integer
            HorasTrabajadas = DateDiff(DateInterval.Hour, fec_hora_entro, fec_hora_salio)

            dia_festivo = verificar_fecha_festiva(fec_hora_entro)
            dia_siguiente_festivo = verificar_dia_siguiente_festivo(fec_hora_entro)


            If fec_hora_entro.Hour = 21 Then
                fec_hora_entro = fec_hora_entro.AddHours(1)
                fec_hora_entro = fec_hora_entro.AddMinutes(-fec_hora_entro.Minute)
            End If
            If fec_hora_entro.Hour = 17 Then
                fec_hora_entro = fec_hora_entro.AddHours(1)
                fec_hora_entro = fec_hora_entro.AddMinutes(-fec_hora_entro.Minute)
            End If
            If fec_hora_entro.Hour >= 4 And fec_hora_entro.Hour < 6 Then
                fec_hora_entro = fec_hora_entro.AddHours(1)
                fec_hora_entro = fec_hora_entro.AddMinutes(-fec_hora_entro.Minute)
            End If

            '   VERIFICAR PARA CONTROLAR RELOJ

            ''   BLOQUE PARA EL DOMINGO O FESTIVO
            'If (dt.Rows(i).Item("domingo") = "True" Or dt.Rows(i).Item("festivo") = "True") Then
            '    'VERIFICAR SI ENTRA EN LA MAÑANA
            '    If (fec_hora_entro.TimeOfDay >= TimeSpan.Parse("05:00:00") And fec_hora_salio.TimeOfDay <= TimeSpan.Parse("20:30:00")) Then
            '        'VALIDAMOS EL TURNO ASIGNADO 1
            '        If objRelojLn.verificar_turno_dia(dt.Rows(i).Item("nit"), objOpSimplesLn.cambiarFormatoFecha(dt.Rows(i).Item("FechaEntrada")), 1) Then
            '            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") = 0
            '            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DD") = 8
            '        End If
            '        'VERIFICAR SI ES TURNO SABADO Y TIENE 10H L-V
            '        If objRelojLn.verificar_turno_dia(dt.Rows(i).Item("nit"), objOpSimplesLn.cambiarFormatoFecha(dt.Rows(i).Item("FechaEntrada")), 7) Then
            '            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") = 0
            '            'dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ED") = HorasTrabajadas
            '            'dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ExtP") = HorasTrabajadas
            '            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DD") = HorasTrabajadas
            '            'dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ExtP") = HorasTrabajadas
            '        End If
            '    End If
            '    'VERIFICAR SI ENTRA EN LA TARDE
            '    If (fec_hora_entro.TimeOfDay >= TimeSpan.Parse("13:00:00") And fec_hora_salio.TimeOfDay <= TimeSpan.Parse("23:30:00")) Then
            '        'VALIDAMOS EL TURNO ASIGNADO 2
            '        If objRelojLn.verificar_turno_dia(dt.Rows(i).Item("nit"), objOpSimplesLn.cambiarFormatoFecha(dt.Rows(i).Item("FechaEntrada")), 2) Then
            '            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") = 0
            '            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DD") = 7
            '            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DN") = 1
            '        End If
            '    End If
            '    'VERIFICAR SI ENTRA EN LA NOCHE
            '    If (fec_hora_entro.TimeOfDay >= TimeSpan.Parse("20:30:00") And fec_hora_salio.TimeOfDay <= TimeSpan.Parse("08:30:00")) Then
            '        'VALIDAMOS EL TURNO ASIGNADO 3
            '        If objRelojLn.verificar_turno_dia(dt.Rows(i).Item("nit"), objOpSimplesLn.cambiarFormatoFecha(dt.Rows(i).Item("FechaEntrada")), 3) Then
            '            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") = 0
            '            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DN") = 2
            '            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("RN") = 6
            '        End If

            '        'VERIFICAMOS QUE EL DIA SIGUIENTE ES FESTIVO Y ES TURNO DE LA NOCHE
            '        If (objRelojLn.verificar_turno_dia(dt.Rows(i).Item("nit"), objOpSimplesLn.cambiarFormatoFecha(dt.Rows(i).Item("FechaEntrada")), 3) And dia_siguiente_festivo = True) Then
            '            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") = 0
            '            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DN") = 8

            '        End If

            '    End If

            'End If

            ''   BLOQUE PARA EL SABADO NORMAL
            'If (dt.Rows(i).Item("sabado") = "True") Then
            '    'VERIFICAR SI ENTRA EN LA MAÑANA
            '    If (fec_hora_entro.TimeOfDay >= TimeSpan.Parse("05:30:00") And fec_hora_salio.TimeOfDay <= TimeSpan.Parse("20:30:00")) Then
            '        'VALIDAMOS EL TURNO ASIGNADO 1
            '        If objRelojLn.verificar_turno_dia(dt.Rows(i).Item("nit"), objOpSimplesLn.cambiarFormatoFecha(dt.Rows(i).Item("FechaEntrada")), 1) Then
            '            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") = 8
            '        End If
            '        'VERIFICAR SI ES TURNO SABADO Y TIENE 10H L-V
            '        If objRelojLn.verificar_turno_dia(dt.Rows(i).Item("nit"), objOpSimplesLn.cambiarFormatoFecha(dt.Rows(i).Item("FechaEntrada")), 7) Then
            '            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") = 0
            '            ' dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ED") = HorasTrabajadas
            '            'dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ExtP") = HorasTrabajadas
            '            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") = HorasTrabajadas
            '            'dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ExtP") = HorasTrabajadas
            '        End If
            '    End If
            '    'VERIFICAR SI ENTRA EN LA TARDE
            '    If (fec_hora_entro.TimeOfDay >= TimeSpan.Parse("13:30:00") And fec_hora_salio.TimeOfDay <= TimeSpan.Parse("23:30:00")) Then
            '        'VALIDAMOS EL TURNO ASIGNADO 2
            '        If objRelojLn.verificar_turno_dia(dt.Rows(i).Item("nit"), objOpSimplesLn.cambiarFormatoFecha(dt.Rows(i).Item("FechaEntrada")), 2) Then
            '            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") = 7
            '            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("RN") = 1
            '        End If
            '    End If
            '    'VERIFICAR SI ENTRA EN LA NOCHE
            '    If (fec_hora_entro.TimeOfDay >= TimeSpan.Parse("20:30:00") And fec_hora_salio.TimeOfDay <= TimeSpan.Parse("08:30:00")) Then
            '        'VALIDAMOS EL TURNO ASIGNADO 3
            '        If objRelojLn.verificar_turno_dia(dt.Rows(i).Item("nit"), objOpSimplesLn.cambiarFormatoFecha(dt.Rows(i).Item("FechaEntrada")), 3) Then
            '            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") = 0
            '            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("RN") = 2
            '            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DN") = 6
            '        End If
            '    End If

            '    'VERIFICAR SI ES TURNO SABADO Y TIENE 10H L-V
            '    If objRelojLn.verificar_turno_dia(dt.Rows(i).Item("nit"), objOpSimplesLn.cambiarFormatoFecha(dt.Rows(i).Item("FechaEntrada")), 0) Then
            '        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") = 0
            '        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ED") = HorasTrabajadas
            '        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ExtP") = HorasTrabajadas
            '    End If

            'End If

            ''   BLOQUE PARA EL SABADO FESTIVO 
            'If (dt.Rows(i).Item("sabado") = "True" And dt.Rows(i).Item("festivo") = "True") Then
            '    'VERIFICAR SI ENTRA EN LA MAÑANA
            '    If (fec_hora_entro.TimeOfDay >= TimeSpan.Parse("05:30:00") And fec_hora_salio.TimeOfDay <= TimeSpan.Parse("20:30:00")) Then
            '        'VALIDAMOS EL TURNO ASIGNADO 1
            '        If objRelojLn.verificar_turno_dia(dt.Rows(i).Item("nit"), objOpSimplesLn.cambiarFormatoFecha(dt.Rows(i).Item("FechaEntrada")), 1) Then
            '            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") = 8
            '        End If
            '        'VERIFICAR SI ES TURNO SABADO Y TIENE 10H L-V
            '        If objRelojLn.verificar_turno_dia(dt.Rows(i).Item("nit"), objOpSimplesLn.cambiarFormatoFecha(dt.Rows(i).Item("FechaEntrada")), 7) Then
            '            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") = 0
            '            ' dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ED") = HorasTrabajadas
            '            'dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ExtP") = HorasTrabajadas
            '            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DD") = HorasTrabajadas
            '            'dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ExtP") = HorasTrabajadas
            '        End If
            '    End If
            '    'VERIFICAR SI ENTRA EN LA TARDE
            '    If (fec_hora_entro.TimeOfDay >= TimeSpan.Parse("13:30:00") And fec_hora_salio.TimeOfDay <= TimeSpan.Parse("23:30:00")) Then
            '        'VALIDAMOS EL TURNO ASIGNADO 2
            '        If objRelojLn.verificar_turno_dia(dt.Rows(i).Item("nit"), objOpSimplesLn.cambiarFormatoFecha(dt.Rows(i).Item("FechaEntrada")), 2) Then
            '            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DD") = 7
            '            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DN") = 1
            '        End If
            '    End If
            '    'VERIFICAR SI ENTRA EN LA NOCHE
            '    If (fec_hora_entro.TimeOfDay >= TimeSpan.Parse("20:30:00") And fec_hora_salio.TimeOfDay <= TimeSpan.Parse("08:30:00")) Then
            '        'VALIDAMOS EL TURNO ASIGNADO 3
            '        If objRelojLn.verificar_turno_dia(dt.Rows(i).Item("nit"), objOpSimplesLn.cambiarFormatoFecha(dt.Rows(i).Item("FechaEntrada")), 3) Then
            '            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") = 0
            '            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DN") = HorasTrabajadas
            '        End If
            '    End If

            '    'VERIFICAR SI ES TURNO SABADO Y TIENE 10H L-V
            '    If objRelojLn.verificar_turno_dia(dt.Rows(i).Item("nit"), objOpSimplesLn.cambiarFormatoFecha(dt.Rows(i).Item("FechaEntrada")), 0) Then
            '        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") = 0
            '        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ED") = HorasTrabajadas
            '        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ExtP") = HorasTrabajadas
            '    End If

            'End If


            ''   BLOQUE PARA DIAS COMUNES
            'If (dt.Rows(i).Item("sabado") = "false" And dt.Rows(i).Item("domingo") = "false" And dt.Rows(i).Item("festivo") = "false") Then
            '    'VERIFICAR SI ENTRA EN LA MAÑANA
            '    If (fec_hora_entro.TimeOfDay >= TimeSpan.Parse("04:30:00") And fec_hora_salio.TimeOfDay <= TimeSpan.Parse("23:30:00")) Then
            '        'VALIDAMOS EL TURNO ASIGNADO 1
            '        If objRelojLn.verificar_turno_dia(dt.Rows(i).Item("nit"), objOpSimplesLn.cambiarFormatoFecha(dt.Rows(i).Item("FechaEntrada")), 1) Then
            '            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") = HorasTrabajadas
            '        End If

            '        'VALIDAMOS QUE TIENE TURNO DE 10H 
            '        If objRelojLn.verificar_turno_dia(dt.Rows(i).Item("nit"), objOpSimplesLn.cambiarFormatoFecha(dt.Rows(i).Item("FechaEntrada")), 7) Then
            '            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") = HorasTrabajadas
            '        End If

            '        'VALIDAMOS QUE TIENE TURNO DE 10H l-v
            '        If objRelojLn.verificar_turno_dia(dt.Rows(i).Item("nit"), objOpSimplesLn.cambiarFormatoFecha(dt.Rows(i).Item("FechaEntrada")), 4) Then
            '            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") = HorasTrabajadas

            '        End If
            '    End If
            '    'VERIFICAR SI ENTRA EN LA TARDE
            '    If (fec_hora_entro.TimeOfDay >= TimeSpan.Parse("13:00:00") And fec_hora_salio.TimeOfDay <= TimeSpan.Parse("23:30:00")) Then
            '        'VALIDAMOS EL TURNO ASIGNADO 2
            '        If objRelojLn.verificar_turno_dia(dt.Rows(i).Item("nit"), objOpSimplesLn.cambiarFormatoFecha(dt.Rows(i).Item("FechaEntrada")), 2) Then
            '            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") = 7
            '            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("RN") = 1
            '        End If
            '    End If
            '    'VERIFICAR SI ENTRA EN LA NOCHE
            '    If (fec_hora_entro.TimeOfDay >= TimeSpan.Parse("20:30:00") And fec_hora_salio.TimeOfDay <= TimeSpan.Parse("08:30:00")) Then
            '        'VALIDAMOS EL TURNO ASIGNADO 3
            '        If objRelojLn.verificar_turno_dia(dt.Rows(i).Item("nit"), objOpSimplesLn.cambiarFormatoFecha(dt.Rows(i).Item("FechaEntrada")), 3) Then
            '            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") = 0
            '            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("RN") = 8
            '        End If

            '        'VERIFICAMOS QUE EL DIA SIGUIENTE ES FESTIVO Y ES TURNO DE LA NOCHE
            '        If (objRelojLn.verificar_turno_dia(dt.Rows(i).Item("nit"), objOpSimplesLn.cambiarFormatoFecha(dt.Rows(i).Item("FechaEntrada")), 3) And dia_siguiente_festivo = True) Then
            '            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") = 0
            '            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("RN") = 2
            '            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DN") = 6

            '        End If
            '    End If
            'End If



            '' NUEVO CALCULO
            '   BLOQUE PARA EL FESTIVO
            If (dt.Rows(i).Item("festivo") = "True" Or dt.Rows(i).Item("domingo") = "True") Then
                'VERIFICAR SI ENTRA EN LA MAÑANA
                If (fec_hora_entro.TimeOfDay >= TimeSpan.Parse("04:30:00") And fec_hora_salio.TimeOfDay <= TimeSpan.Parse("20:30:00")) Then
                    'VALIDAMOS EL TURNO ASIGNADO 1
                    If objRelojLn.verificar_turno_dia(dt.Rows(i).Item("nit"), objOpSimplesLn.cambiarFormatoFecha(dt.Rows(i).Item("FechaEntrada")), 1) Then

                        If (HorasTrabajadas <= 8) Then
                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DD") = HorasTrabajadas
                        Else
                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DD") = 8
                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EDF") = HorasTrabajadas - 8
                        End If
                    End If
                    'VERIFICAR EL TURNO ASIGANDO 7
                    If objRelojLn.verificar_turno_dia(dt.Rows(i).Item("nit"), objOpSimplesLn.cambiarFormatoFecha(dt.Rows(i).Item("FechaEntrada")), 7) Then
                        If (HorasTrabajadas <= 8) Then
                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DD") = HorasTrabajadas
                        Else
                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DD") = 8
                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EDF") = HorasTrabajadas - 8
                        End If
                    End If
                    'VERIFICAR EL TURNO ASIGANDO 5
                    If objRelojLn.verificar_turno_dia(dt.Rows(i).Item("nit"), objOpSimplesLn.cambiarFormatoFecha(dt.Rows(i).Item("FechaEntrada")), 5) Then
                        If (HorasTrabajadas <= 8) Then
                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DD") = HorasTrabajadas

                        Else
                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DD") = 8
                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EDF") = HorasTrabajadas - 8
                        End If
                    End If
                End If


                'VERIFICAR SI ENTRA EN LA TARDE
                If (fec_hora_entro.TimeOfDay >= TimeSpan.Parse("09:30:00") And fec_hora_salio.TimeOfDay <= TimeSpan.Parse("23:30:00")) Then
                    'VALIDAMOS EL TURNO ASIGNADO 2
                    If objRelojLn.verificar_turno_dia(dt.Rows(i).Item("nit"), objOpSimplesLn.cambiarFormatoFecha(dt.Rows(i).Item("FechaEntrada")), 2) Then
                        If (HorasTrabajadas <= 8) Then
                            If (HorasTrabajadas = 8) Then
                                dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DD") = 7
                                dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DN") = 1
                            Else
                                dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DD") = HorasTrabajadas
                            End If
                        Else
                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DD") = 7
                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DN") = 1
                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ENF") = HorasTrabajadas - 8
                        End If
                    End If

                    'VALIDAMOS EL TURNO ASIGNADO 8
                    If objRelojLn.verificar_turno_dia(dt.Rows(i).Item("nit"), objOpSimplesLn.cambiarFormatoFecha(dt.Rows(i).Item("FechaEntrada")), 8) Then
                        If (HorasTrabajadas <= 8) Then
                            If (HorasTrabajadas = 8) Then
                                dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DD") = 7
                                dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DN") = 1
                            Else
                                dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DD") = HorasTrabajadas
                            End If
                        Else
                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DD") = 7
                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DN") = 1
                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ENF") = HorasTrabajadas - 8
                        End If
                    End If

                    'VALIDAMOS EL TURNO ASIGNADO 22
                    If objRelojLn.verificar_turno_dia(dt.Rows(i).Item("nit"), objOpSimplesLn.cambiarFormatoFecha(dt.Rows(i).Item("FechaEntrada")), 22) Then
                        If (HorasTrabajadas <= 8) Then
                            If (HorasTrabajadas = 8) Then
                                dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DD") = 7
                                dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DN") = 1
                            Else
                                dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DD") = HorasTrabajadas
                            End If
                        Else
                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DD") = 7
                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DN") = 1
                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ENF") = HorasTrabajadas - 8
                        End If
                    End If
                End If

                'VERIFICAR SI ENTRA EN LA NOCHE
                If (fec_hora_entro.TimeOfDay >= TimeSpan.Parse("14:30:00") And fec_hora_salio.TimeOfDay <= TimeSpan.Parse("08:30:00")) Then
                    'VALIDAMOS EL TURNO ASIGNADO 3
                    If objRelojLn.verificar_turno_dia(dt.Rows(i).Item("nit"), objOpSimplesLn.cambiarFormatoFecha(dt.Rows(i).Item("FechaEntrada")), 3) Then

                        If (dia_siguiente_festivo) Then
                            If (HorasTrabajadas <= 8) Then
                                If (HorasTrabajadas = 8) Then
                                    dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DN") = 8
                                Else
                                    dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DN") = HorasTrabajadas
                                End If
                            Else
                                dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DN") = 8
                                dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ENF") = HorasTrabajadas - 8
                            End If
                        Else
                            If (HorasTrabajadas <= 8) Then
                                If (HorasTrabajadas = 8) Then
                                    dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DN") = 3
                                    dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("RN") = 5
                                Else
                                    If (HorasTrabajadas >= 3) Then
                                        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DN") = 3
                                        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("RN") = HorasTrabajadas
                                    Else
                                        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DN") = HorasTrabajadas
                                    End If

                                End If
                            Else
                                dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DN") = 3
                                dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("RN") = 5
                                dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ED") = HorasTrabajadas - 8
                            End If
                        End If

                    End If

                    'VALIDAMOS EL TURNO ASIGNADO 8
                    If objRelojLn.verificar_turno_dia(dt.Rows(i).Item("nit"), objOpSimplesLn.cambiarFormatoFecha(dt.Rows(i).Item("FechaEntrada")), 8) Then

                        If (dia_siguiente_festivo) Then
                            If (HorasTrabajadas <= 8) Then
                                If (HorasTrabajadas = 8) Then
                                    dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DN") = 8
                                Else
                                    dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DN") = HorasTrabajadas
                                End If
                            Else
                                dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DN") = 8
                                dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ENF") = HorasTrabajadas - 8
                            End If
                        Else
                            If (HorasTrabajadas <= 8) Then
                                If (HorasTrabajadas = 8) Then
                                    dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DN") = 3
                                    dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("RN") = 5
                                Else
                                    If (HorasTrabajadas >= 3) Then
                                        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DN") = 3
                                        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("RN") = HorasTrabajadas
                                    Else
                                        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DN") = HorasTrabajadas
                                    End If

                                End If
                            Else
                                dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DN") = 3
                                dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("RN") = 5
                                dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ED") = HorasTrabajadas - 8
                            End If
                        End If

                    End If

                    'VALIDAMOS EL TURNO ASIGNADO 22
                    If objRelojLn.verificar_turno_dia(dt.Rows(i).Item("nit"), objOpSimplesLn.cambiarFormatoFecha(dt.Rows(i).Item("FechaEntrada")), 22) Then

                        If (dia_siguiente_festivo) Then
                            If (HorasTrabajadas <= 8) Then
                                If (HorasTrabajadas = 8) Then
                                    dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DN") = 8
                                Else
                                    dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DN") = HorasTrabajadas
                                End If
                            Else
                                dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DN") = 8
                                dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ENF") = HorasTrabajadas - 8
                            End If
                        Else
                            If (HorasTrabajadas <= 8) Then
                                If (HorasTrabajadas = 8) Then
                                    dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DN") = 3
                                    dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("RN") = 5
                                Else
                                    If (HorasTrabajadas >= 3) Then
                                        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DN") = 3
                                        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("RN") = HorasTrabajadas
                                    Else
                                        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DN") = HorasTrabajadas
                                    End If

                                End If
                            Else
                                dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DN") = 3
                                dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("RN") = 5
                                dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ED") = HorasTrabajadas - 8
                            End If
                        End If

                    End If

                End If

                ''VERIFICAR SI ES TURNO SABADO Y TIENE 10H L-V
                'If objRelojLn.verificar_turno_dia(dt.Rows(i).Item("nit"), objOpSimplesLn.cambiarFormatoFecha(dt.Rows(i).Item("FechaEntrada")), 0) Then
                '    dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") = 0
                '    dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ED") = HorasTrabajadas
                '    dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ExtP") = HorasTrabajadas
                'End If

            End If


            '   BLOQUE PARA DIAS NORMALES 
            If (dt.Rows(i).Item("festivo") = "false" And dt.Rows(i).Item("domingo") = "false" And dt.Rows(i).Item("sabado") = "false") Then
                'VERIFICAR SI ENTRA EN LA MAÑANA
                If (fec_hora_entro.TimeOfDay >= TimeSpan.Parse("04:30:00") And fec_hora_salio.TimeOfDay <= TimeSpan.Parse("20:30:00")) Then
                    'VALIDAMOS EL TURNO ASIGNADO 1
                    If objRelojLn.verificar_turno_dia(dt.Rows(i).Item("nit"), objOpSimplesLn.cambiarFormatoFecha(dt.Rows(i).Item("FechaEntrada")), 1) Then

                        If (HorasTrabajadas <= 8) Then
                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") = HorasTrabajadas
                        Else
                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("Ord") = 8
                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ED") = HorasTrabajadas - 8
                        End If
                    End If
                    'VERIFICAR EL TURNO ASIGANDO 7
                    If objRelojLn.verificar_turno_dia(dt.Rows(i).Item("nit"), objOpSimplesLn.cambiarFormatoFecha(dt.Rows(i).Item("FechaEntrada")), 7) Then
                        If (HorasTrabajadas <= 8) Then
                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") = HorasTrabajadas
                        Else
                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("Ord") = 8
                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ED") = HorasTrabajadas - 8
                        End If
                    End If
                    'VERIFICAR EL TURNO ASIGANDO 5
                    If objRelojLn.verificar_turno_dia(dt.Rows(i).Item("nit"), objOpSimplesLn.cambiarFormatoFecha(dt.Rows(i).Item("FechaEntrada")), 5) Then
                        If (HorasTrabajadas <= 8) Then
                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") = HorasTrabajadas

                        Else
                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") = 8
                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ED") = HorasTrabajadas - 8
                        End If
                    End If
                End If


                'VERIFICAR SI ENTRA EN LA TARDE
                If (fec_hora_entro.TimeOfDay >= TimeSpan.Parse("09:30:00") And fec_hora_salio.TimeOfDay <= TimeSpan.Parse("23:30:00")) Then
                    'VALIDAMOS EL TURNO ASIGNADO 2
                    If objRelojLn.verificar_turno_dia(dt.Rows(i).Item("nit"), objOpSimplesLn.cambiarFormatoFecha(dt.Rows(i).Item("FechaEntrada")), 2) Then
                        If (HorasTrabajadas <= 8) Then
                            If (HorasTrabajadas = 8) Then
                                dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") = 7
                                dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("RN") = 1
                            Else
                                dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") = HorasTrabajadas
                            End If
                        Else
                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") = 7
                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("RN") = 1
                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EN") = HorasTrabajadas - 8
                        End If
                    End If

                    'VALIDAMOS EL TURNO ASIGNADO 8
                    If objRelojLn.verificar_turno_dia(dt.Rows(i).Item("nit"), objOpSimplesLn.cambiarFormatoFecha(dt.Rows(i).Item("FechaEntrada")), 8) Then
                        If (HorasTrabajadas <= 8) Then
                            If (HorasTrabajadas = 8) Then
                                dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") = 7
                                dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("RN") = 1
                            Else
                                dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") = HorasTrabajadas
                            End If
                        Else
                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") = 7
                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("RN") = 1
                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EN") = HorasTrabajadas - 8
                        End If
                    End If

                    'VALIDAMOS EL TURNO ASIGNADO 22
                    If objRelojLn.verificar_turno_dia(dt.Rows(i).Item("nit"), objOpSimplesLn.cambiarFormatoFecha(dt.Rows(i).Item("FechaEntrada")), 22) Then
                        If (HorasTrabajadas <= 8) Then
                            If (HorasTrabajadas = 8) Then
                                dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("Ord") = 7
                                dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("RN") = 1
                            Else
                                dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") = HorasTrabajadas
                            End If
                        Else
                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") = 7
                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("RN") = 1
                            dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EN") = HorasTrabajadas - 8
                        End If
                    End If
                End If

                'VERIFICAR SI ENTRA EN LA NOCHE
                If (fec_hora_entro.TimeOfDay >= TimeSpan.Parse("14:30:00") And fec_hora_salio.TimeOfDay <= TimeSpan.Parse("08:30:00")) Then
                    'VALIDAMOS EL TURNO ASIGNADO 3
                    If objRelojLn.verificar_turno_dia(dt.Rows(i).Item("nit"), objOpSimplesLn.cambiarFormatoFecha(dt.Rows(i).Item("FechaEntrada")), 3) Then

                        If (dia_siguiente_festivo) Then
                            If (HorasTrabajadas <= 8) Then
                                If (HorasTrabajadas = 8) Then
                                    dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("RN") = 3
                                    dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DN") = 5
                                Else
                                    dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("RN") = 3
                                    dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DN") = HorasTrabajadas - 3
                                End If
                            Else
                                dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("RN") = 3
                                dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DN") = HorasTrabajadas - 8
                            End If
                        Else
                            If (HorasTrabajadas <= 8) Then
                                If (HorasTrabajadas = 8) Then
                                    dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("RN") = 8
                                Else
                                    If (HorasTrabajadas >= 3) Then
                                        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("RN") = HorasTrabajadas
                                    Else
                                        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("RN") = HorasTrabajadas
                                    End If

                                End If
                            Else
                                dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("RN") = 8
                                dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EN") = HorasTrabajadas - 8
                            End If
                        End If

                    End If

                    'VALIDAMOS EL TURNO ASIGNADO 8
                    If objRelojLn.verificar_turno_dia(dt.Rows(i).Item("nit"), objOpSimplesLn.cambiarFormatoFecha(dt.Rows(i).Item("FechaEntrada")), 8) Then

                        If (dia_siguiente_festivo) Then
                            If (HorasTrabajadas <= 8) Then
                                If (HorasTrabajadas = 8) Then
                                    dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("RN") = 3
                                    dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DN") = 5
                                Else
                                    dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("RN") = 3
                                    dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DN") = HorasTrabajadas - 3
                                End If
                            Else
                                dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("RN") = 3
                                dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DN") = HorasTrabajadas - 8
                            End If
                        Else
                            If (HorasTrabajadas <= 8) Then
                                If (HorasTrabajadas = 8) Then
                                    dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("RN") = 8
                                Else
                                    If (HorasTrabajadas >= 3) Then
                                        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("RN") = HorasTrabajadas
                                    Else
                                        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("RN") = HorasTrabajadas
                                    End If

                                End If
                            Else
                                dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("RN") = 8
                                dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EN") = HorasTrabajadas - 8
                            End If
                        End If

                    End If

                    'VALIDAMOS EL TURNO ASIGNADO 22
                    If objRelojLn.verificar_turno_dia(dt.Rows(i).Item("nit"), objOpSimplesLn.cambiarFormatoFecha(dt.Rows(i).Item("FechaEntrada")), 22) Then

                        If (dia_siguiente_festivo) Then
                            If (HorasTrabajadas <= 8) Then
                                If (HorasTrabajadas = 8) Then
                                    dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("RN") = 3
                                    dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DN") = 5
                                Else
                                    dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("RN") = 3
                                    dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DN") = HorasTrabajadas - 3
                                End If
                            Else
                                dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("RN") = 3
                                dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DN") = HorasTrabajadas - 8
                            End If
                        Else
                            If (HorasTrabajadas <= 8) Then
                                If (HorasTrabajadas = 8) Then
                                    dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("RN") = 8
                                Else
                                    If (HorasTrabajadas >= 3) Then
                                        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("RN") = HorasTrabajadas
                                    Else
                                        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("RN") = HorasTrabajadas
                                    End If

                                End If
                            Else
                                dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("RN") = 8
                                dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EN") = HorasTrabajadas - 8
                            End If
                        End If

                    End If

                End If

                ''VERIFICAR SI ES TURNO SABADO Y TIENE 10H L-V
                'If objRelojLn.verificar_turno_dia(dt.Rows(i).Item("nit"), objOpSimplesLn.cambiarFormatoFecha(dt.Rows(i).Item("FechaEntrada")), 0) Then
                '    dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("OrD") = 0
                '    dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ED") = HorasTrabajadas
                '    dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ExtP") = HorasTrabajadas
                'End If

            End If

            'Zona para agregar conceptos
            If chk_temporales.Checked = True Then
                dtConceptos = agregar_Conceptos(fec_hora_entro, dt.Rows(i).Item("nit"))
                For k = 0 To dtConceptos.Rows.Count - 1
                    If dtConceptos.Rows(k).Item("concepto") = 13 Then
                        'dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ED") = dtConceptos.Rows(k).Item("horas")
                    ElseIf dtConceptos.Rows(k).Item("concepto") = 14 Then
                        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EN") = dtConceptos.Rows(k).Item("horas")
                    ElseIf dtConceptos.Rows(k).Item("concepto") = 15 Then
                        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("EDF") = dtConceptos.Rows(k).Item("horas")
                    ElseIf dtConceptos.Rows(k).Item("concepto") = 16 Then
                        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("ENF") = dtConceptos.Rows(k).Item("horas")
                    ElseIf dtConceptos.Rows(k).Item("concepto") = 31 Then
                        'dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DD") = dtConceptos.Rows(k).Item("horas")
                    ElseIf dtConceptos.Rows(k).Item("concepto") = 32 Then
                        dt_procesado.Rows(dt_procesado.Rows.Count - 1).Item("DN") = dtConceptos.Rows(k).Item("horas")
                    End If
                Next
            End If
            horas_ord = 0
        Next
        dia_compensatorio = False
        dt_procesado.Rows.Add()
        dt_marcacion_procesada.Rows.Add()
        dt_marcacion_procesada = dt_procesado
        Return dt_procesado
    End Function
    Private Function agregar_Conceptos(ByVal fec As Date, ByVal nit As String)
        Dim dt_conceptos As New DataTable
        Dim ano As String = fec.Year
        Dim mes As String = fec.Month
        Dim dia As String = fec.Day
        Dim sql As String = "select horas,concepto from y_novedades where year(fecha)=" & ano & " and month(fecha)=" & mes & " and  day(fecha)=" & dia & " and nit=" & nit & ""
        dt_conceptos = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        Return dt_conceptos
    End Function
    Private Function es_compensatorio(ByRef dt As DataTable, ByVal fila As Integer) As Boolean
        Dim idTurno As Integer = -1
        Dim resp As Boolean = False
        If Not IsNumeric(dt.Rows(fila).Item("turnoProg")) Then
            idTurno = getPrimerIdTurno(dt.Rows(fila).Item("turnoProg"))
        End If
        If idTurno = 99 Then
            Return True
        Else
            Return False
        End If
    End Function
    Private Function getPrimerIdTurno(ByVal cadena As String) As Integer
        cadena.Trim()
        Dim id As String = ""
        If cadena <> "" Then
            For i = 0 To cadena.Length
                If (cadena(i) <> "-") Then
                    id &= cadena(i)
                Else
                    i = cadena.Length
                End If
            Next
        Else
            id = 0
        End If
        Return id
    End Function
    Private Sub consolidar1(ByVal fecIni As String, ByVal fecFin As String, ByVal where_centro As String, ByVal where_operario As String, ByVal where_turno As String)
        lbl_estado.Text = "CONSOLIDANDO MARCACIONES..."
        Application.DoEvents()
        Dim sqlOrder As String = "ORDER BY p.nombres, r.FechaEntrada "
        dtg_consulta.DataSource = Nothing
        Dim dt_datos As DataTable = procesar_marcaciones(fecIni, fecFin, where_centro, where_operario, sqlOrder, where_turno)
        Dim dt_consolidado As New DataTable
        ' dtg_consulta.DataSource = dt_datos
        Dim fila As Integer = 0
        Dim dt_tiempo_ordinario As New DataTable
        Dim consolidar_todo_extra As Boolean = False
        Dim num As String = ""
        Dim nit_consol_todo_extra As Double = 0
        Dim tot_horas_dia As Integer = 0
        dt_consolidado.Columns.Add("hDebeD")
        dt_consolidado.Columns.Add("hDebeN")
        dt_consolidado.Columns.Add("hDescD")
        dt_consolidado.Columns.Add("hDescN")
        dt_consolidado.Columns.Add("nit")
        dt_consolidado.Columns.Add("nombres")
        dt_consolidado.Columns.Add("centro")

        dt_consolidado.Columns.Add("contrato")
        dt_consolidado.Columns.Add("oficio")
        dt_consolidado.Columns.Add("planta")
        dt_consolidado.Columns.Add("turno")
        dt_consolidado.Columns.Add("basico_hora")
        dt_consolidado.Columns.Add("basico_mes")

        dt_consolidado.Columns.Add("TotOrD", GetType(Double))

        dt_consolidado.Columns.Add("OrD", GetType(Integer)) '------------------concepto = 1
        dt_consolidado.Columns.Add("RN", GetType(Integer)) '------------------concepto = 17
        dt_consolidado.Columns.Add("DD", GetType(Integer)) '------------------concepto = 31
        dt_consolidado.Columns.Add("DN", GetType(Integer)) '------------------concepto = 32
        dt_consolidado.Columns.Add("DF", GetType(Integer)) '------------------concepto = 2
        dt_consolidado.Columns.Add("ED", GetType(Integer)) '------------------concepto = 13
        dt_consolidado.Columns.Add("EN", GetType(Integer)) '------------------concepto = 14
        dt_consolidado.Columns.Add("EDF", GetType(Integer)) '------------------concepto = 15
        dt_consolidado.Columns.Add("ENF", GetType(Integer)) '------------------concepto = 16
        dt_consolidado.Columns.Add("DComp", GetType(Integer)) '-----------------concepto =33
        dt_consolidado.Columns.Add("PR", GetType(Integer)) '------------------concepto =34
        dt_consolidado.Columns.Add("PRH", GetType(Integer)) '------------------concepto =77
        dt_consolidado.Columns.Add("PV", GetType(Integer)) '------------------concepto =78
        dt_consolidado.Columns.Add("PD", GetType(Integer)) '------------------concepto =35
        dt_consolidado.Columns.Add("PE", GetType(Integer)) '------------------concepto =36
        dt_consolidado.Columns.Add("PC", GetType(Integer)) '------------------concepto =37
        dt_consolidado.Columns.Add("PN", GetType(Integer)) '------------------concepto =510
        dt_consolidado.Columns.Add("IR", GetType(Integer)) '------------------concepto =5
        dt_consolidado.Columns.Add("IA", GetType(Integer)) '------------------concepto =6
        dt_consolidado.Columns.Add("LM", GetType(Integer)) '------------------concepto =7
        dt_consolidado.Columns.Add("V", GetType(Integer)) '------------------no tiene
        dt_consolidado.Columns.Add("DS", GetType(Integer)) '------------------concepto =511
        dt_consolidado.Columns.Add("SU", GetType(Integer)) '------------------concepto =512
        dt_consolidado.Columns.Add("BON", GetType(Integer)) '------------------concepto =43
        dt_consolidado.Columns.Add("FN", GetType(Double)) '------------------516
        dt_consolidado.Columns.Add("HL", GetType(Integer)) '------------------concepto =90
        dt_consolidado.Columns.Add("HR", GetType(Double)) 'Horas ordinarias reales trabajas en el corte de novedades


        addConceptos(dt_consolidado)

        If (dt_datos.Rows.Count - 2 <> -1) Then
            progBar.Maximum = dt_datos.Rows.Count - 2
            progBar.Minimum = 0
        End If
        For i = 0 To dt_datos.Rows.Count - 2
            progBar.PerformStep()
            progBar.Refresh()
            fila = buscar_nit(dt_consolidado, dt_datos.Rows(i).Item("nit"))
            If (fila = -1) Then
                dt_consolidado.Rows.Add()
                dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("nit") = dt_datos.Rows(i).Item("nit")
                dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("nombres") = dt_datos.Rows(i).Item("nombres")
                dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("centro") = dt_datos.Rows(i).Item("centro")
                dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("contrato") = dt_datos.Rows(i).Item("contrato")
                dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("oficio") = dt_datos.Rows(i).Item("oficio")
                dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("planta") = dt_datos.Rows(i).Item("planta")
                dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("turno") = dt_datos.Rows(i).Item("turno")
                dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("basico_hora") = dt_datos.Rows(i).Item("basico_hora")
                dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("basico_mes") = dt_datos.Rows(i).Item("basico_mes")
                dt_tiempo_ordinario = objRelojLn.calcular_horas_ordinarias(id_periodo, dt_datos.Rows(i).Item("nit"), horas_laborales, horas_totales_periodo, fecFin)
                'For k = 0 To dt_tiempo_ordinario.Rows.Count - 1

                'dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("OrD") = dt_tiempo_ordinario.Rows(k).Item("OrD")
                'dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("RN") = dt_tiempo_ordinario.Rows(k).Item("RN")
                'dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("DF") = dt_tiempo_ordinario.Rows(k).Item("DF")
                'dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("DComp") = dt_tiempo_ordinario.Rows(k).Item("DComp")
                'dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("DD") = dt_tiempo_ordinario.Rows(k).Item("DD")
                'dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("DN") = dt_tiempo_ordinario.Rows(k).Item("DN")
                'dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("PR") = dt_tiempo_ordinario.Rows(k).Item("PR")
                'dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("PRH") = dt_tiempo_ordinario.Rows(k).Item("PRH")
                'dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("PV") = dt_tiempo_ordinario.Rows(k).Item("PV")
                'dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("PD") = dt_tiempo_ordinario.Rows(k).Item("PD")
                'dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("PE") = dt_tiempo_ordinario.Rows(k).Item("PE")
                'dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("PC") = dt_tiempo_ordinario.Rows(k).Item("PC")
                'dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("PN") = dt_tiempo_ordinario.Rows(k).Item("PN")
                'dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("IR") = dt_tiempo_ordinario.Rows(k).Item("IR")
                'dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("IA") = dt_tiempo_ordinario.Rows(k).Item("IA")
                'dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("LM") = dt_tiempo_ordinario.Rows(k).Item("LM")
                'dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("V") = dt_tiempo_ordinario.Rows(k).Item("V")
                'dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("SU") = dt_tiempo_ordinario.Rows(k).Item("SU")
                'dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("DS") = dt_tiempo_ordinario.Rows(k).Item("DS")
                'dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("BON") = dt_tiempo_ordinario.Rows(k).Item("BON")
                'dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("FN") = dt_tiempo_ordinario.Rows(k).Item("FN")
                'dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HL") = dt_tiempo_ordinario.Rows(k).Item("HL")
                For k = 0 To dt_tiempo_ordinario.Rows.Count - 1
                    dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("OrD") = dt_tiempo_ordinario.Rows(k).Item("OrD")
                    'dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("OrD") = 809
                    dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("RN") = dt_tiempo_ordinario.Rows(k).Item("RN")
                    'dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("DF") = dt_consolidado.Rows(k).Item("DF")
                    'dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("DComp") = dt_consolidado.Rows(k).Item("DComp")
                    'dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("DD") = dt_consolidado.Rows(k).Item("DD")
                    'dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("DN") = dt_consolidado.Rows(k).Item("DN")
                    'dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("PR") = dt_consolidado.Rows(k).Item("PR")
                    'dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("PRH") = dt_consolidado.Rows(k).Item("PRH")
                    'dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("PV") = dt_consolidado.Rows(k).Item("PV")
                    'dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("PD") = dt_consolidado.Rows(k).Item("PD")
                    'dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("PE") = dt_consolidado.Rows(k).Item("PE")
                    'dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("PC") = dt_consolidado.Rows(k).Item("PC")
                    'dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("PN") = dt_consolidado.Rows(k).Item("PN")
                    'dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("IR") = dt_consolidado.Rows(k).Item("IR")
                    'dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("IA") = dt_consolidado.Rows(k).Item("IA")
                    'dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("LM") = dt_consolidado.Rows(k).Item("LM")
                    'dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("V") = dt_consolidado.Rows(k).Item("V")
                    'dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("SU") = dt_consolidado.Rows(k).Item("SU")
                    'dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("DS") = dt_consolidado.Rows(k).Item("DS")
                    'dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("BON") = dt_consolidado.Rows(k).Item("BON")
                    'dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("FN") = dt_consolidado.Rows(k).Item("FN")
                    'dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HL") = dt_consolidado.Rows(k).Item("HL")
                Next
                fila = dt_consolidado.Rows.Count - 1
                'If IsNumeric(dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("PD")) Then
                '    If Not IsDBNull(dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR")) Then
                '        dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR") += dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("PD")
                '    Else
                '        dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR") = dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("PD")
                '    End If
                'End If
                'If IsNumeric(dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("PE")) Then
                '    If Not IsDBNull(dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR")) Then
                '        dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR") += dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("PE")
                '    Else
                '        dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR") = dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("PE")
                '    End If
                'End If
                'If IsNumeric(dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("PC")) Then
                '    If Not IsDBNull(dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR")) Then
                '        dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR") += dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("PC")
                '    Else
                '        dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR") = dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("PC")
                '    End If
                'End If
                'If IsNumeric(dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("PN")) Then
                '    If Not IsDBNull(dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR")) Then
                '        dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR") += dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("PN")
                '    Else
                '        dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR") = dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("PN")
                '    End If
                'End If
                'If IsNumeric(dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("IA")) Then
                '    If Not IsDBNull(dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR")) Then
                '        dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR") += dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("IA")
                '    Else
                '        dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR") = dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("IA")
                '    End If
                'End If
                'If IsNumeric(dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("LM")) Then
                '    If Not IsDBNull(dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR")) Then
                '        dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR") += dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("LM")
                '    Else
                '        dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR") = dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("LM")
                '    End If
                'End If
                'If IsNumeric(dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("SU")) Then
                '    If Not IsDBNull(dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR")) Then
                '        dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR") += dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("SU")
                '    Else
                '        dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR") = dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("SU")
                '    End If
                'End If
                'If IsNumeric(dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("FN")) Then
                '    If Not IsDBNull(dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR")) Then
                '        dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR") += dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("FN")
                '    Else
                '        dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR") = dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("FN")
                '    End If
                'End If
                'If IsNumeric(dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("DS")) Then
                '    If Not IsDBNull(dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR")) Then
                '        dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR") += dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("DS")
                '    Else
                '        dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR") = dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("DS")
                '    End If
                'End If
                'If IsNumeric(dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("SU")) Then
                '    If Not IsDBNull(dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR")) Then
                '        dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR") += dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("SU")
                '    Else
                '        dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR") = dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("SU")
                '    End If
                'End If
                'If IsNumeric(dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("IR")) Then
                '    If Not IsDBNull(dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR")) Then
                '        dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR") += dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("IR")
                '    Else
                '        dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR") = dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("IR")
                '    End If
                'End If
                'If IsNumeric(dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("V")) Then
                '    If Not IsDBNull(dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR")) Then
                '        dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR") += dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("V")
                '    Else
                '        dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR") = dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("V")
                '    End If
                'End If
                'If IsNumeric(dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("Dcomp")) Then
                '    If Not IsDBNull(dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR")) Then
                '        dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR") += dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("Dcomp")
                '    Else
                '        dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR") = dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("Dcomp")
                '    End If
                'End If

                If IsNumeric(dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("PD")) Then
                    If Not IsDBNull(dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR")) Then
                        dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR") += dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("PD")
                    Else
                        dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR") = dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("PD")
                    End If
                End If
                If IsNumeric(dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("PE")) Then
                    If Not IsDBNull(dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR")) Then
                        dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR") += dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("PE")
                    Else
                        dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR") = dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("PE")
                    End If
                End If
                If IsNumeric(dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("PC")) Then
                    If Not IsDBNull(dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR")) Then
                        dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR") += dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("PC")
                    Else
                        dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR") = dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("PC")
                    End If
                End If
                If IsNumeric(dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("PN")) Then
                    If Not IsDBNull(dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR")) Then
                        dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR") += dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("PN")
                    Else
                        dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR") = dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("PN")
                    End If
                End If
                If IsNumeric(dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("IA")) Then
                    If Not IsDBNull(dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR")) Then
                        dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR") += dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("IA")
                    Else
                        dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR") = dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("IA")
                    End If
                End If
                If IsNumeric(dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("LM")) Then
                    If Not IsDBNull(dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR")) Then
                        dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR") += dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("LM")
                    Else
                        dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR") = dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("LM")
                    End If
                End If
                If IsNumeric(dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("SU")) Then
                    If Not IsDBNull(dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR")) Then
                        dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR") += dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("SU")
                    Else
                        dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR") = dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("SU")
                    End If
                End If
                If IsNumeric(dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("FN")) Then
                    If Not IsDBNull(dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR")) Then
                        dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR") += dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("FN")
                    Else
                        dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR") = dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("FN")
                    End If
                End If
                If IsNumeric(dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("DS")) Then
                    If Not IsDBNull(dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR")) Then
                        dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR") += dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("DS")
                    Else
                        dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR") = dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("DS")
                    End If
                End If
                If IsNumeric(dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("SU")) Then
                    If Not IsDBNull(dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR")) Then
                        dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR") += dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("SU")
                    Else
                        dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR") = dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("SU")
                    End If
                End If
                If IsNumeric(dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("IR")) Then
                    If Not IsDBNull(dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR")) Then
                        dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR") += dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("IR")
                    Else
                        dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR") = dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("IR")
                    End If
                End If
                If IsNumeric(dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("V")) Then
                    If Not IsDBNull(dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR")) Then
                        dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR") += dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("V")
                    Else
                        dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR") = dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("V")
                    End If
                End If
                If IsNumeric(dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("Dcomp")) Then
                    If Not IsDBNull(dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR")) Then
                        dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR") += dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("Dcomp")
                    Else
                        dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR") = dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("Dcomp")
                    End If
                End If
            End If

            If consolidar_todo_extra And nit_consol_todo_extra = dt_datos.Rows(i).Item("nit") Then
                consolidar_marcacion_todo_Extra(i, fila, dt_consolidado, tot_horas_dia, dt_datos)
            Else
                consolidar_marcacion(i, fila, dt_consolidado, dt_datos)
            End If

            num = dt_datos.Rows(i).Item("Consec")
            If consolidar_todo_extra = False And verificar_varias_marcaciones_dia(dt_datos.Rows(i).Item("nit"), dt_datos.Rows(i).Item("FechaEntrada"), dt_datos) And verificar_turno_prog_doble(dt_datos.Rows(i).Item("turnoProg")) = False Then
                tot_horas_dia = horas_dia(dt_datos.Rows(i).Item("nit"), dt_datos.Rows(i).Item("FechaEntrada"))
                nit_consol_todo_extra = dt_datos.Rows(i).Item("nit")
                If (tot_horas_dia > 8) Then
                    consolidar_todo_extra = True
                Else
                    consolidar_todo_extra = False
                End If
            Else
                tot_horas_dia = 0
                consolidar_todo_extra = False
                nit_consol_todo_extra = 0
            End If
        Next
        dtg_consulta.DataSource = Nothing
        addCompromisos(dt_consolidado)
        dt_consolidado.Rows.Add()
        dtg_consulta.DataSource = dt_consolidado
        tot_ordinarias()
        descontar_incapacidades_a_ordinarias()
        descontar_novedades_permisos_a_ordinarias()
        ' descontar_dom_sancion()
        toolTipConceptos()
        pintar_dtg()
        descontar_horas_compromiso()
        tot_ordinarias()
        descontar_dom_noct_turno_noche()
        tot_ordinarias()
        descontar_dom_noct_turno_dia()
        tot_ordinarias()
        totalizar(dtg_consulta)

        verificar_horas_ordinarias_totales()
        For j = 0 To dt_datos.Columns.Count - 1
            If (dtg_consulta.Columns(j).Name = "contrato" Or dtg_consulta.Columns(j).Name = "oficio" Or dtg_consulta.Columns(j).Name = "planta" Or dtg_consulta.Columns(j).Name = "turno" Or dtg_consulta.Columns(j).Name = "basico_hora" Or dtg_consulta.Columns(j).Name = "basico_mes") Then
                dtg_consulta.Columns(j).Visible = False
            End If
        Next
        dtg_consulta.CurrentCell = Nothing
        dtg_consulta.Rows(0).Visible = False
        dtg_consulta.Rows(1).Visible = False
        progBar.Value = 0
        valorizar()
    End Sub

    Private Sub consolidar(ByVal fecIni As String, ByVal fecFin As String, ByVal where_centro As String, ByVal where_operario As String, ByVal where_turno As String, ByVal dt As DataTable)
        lbl_estado.Text = "CONSOLIDANDO MARCACIONES..."
        Application.DoEvents()
        Dim sqlOrder As String = "ORDER BY p.nombres, r.FechaEntrada "
        dtg_consulta.DataSource = Nothing
        Dim dt_datos As DataTable = procesar_marcaciones(fecIni, fecFin, where_centro, where_operario, sqlOrder, where_turno)
        Dim dt_consolidado As New DataTable
        ' dtg_consulta.DataSource = dt_datos
        Dim fila As Integer = 0
        Dim dt_tiempo_ordinario As New DataTable
        Dim consolidar_todo_extra As Boolean = False
        Dim num As String = ""
        Dim nit_consol_todo_extra As Double = 0
        Dim tot_horas_dia As Integer = 0
        dt_consolidado.Columns.Add("hDebeD")
        dt_consolidado.Columns.Add("hDebeN")
        dt_consolidado.Columns.Add("hDescD")
        dt_consolidado.Columns.Add("hDescN")
        dt_consolidado.Columns.Add("nit")
        dt_consolidado.Columns.Add("nombres")
        dt_consolidado.Columns.Add("centro")

        dt_consolidado.Columns.Add("contrato")
        dt_consolidado.Columns.Add("oficio")
        dt_consolidado.Columns.Add("planta")
        dt_consolidado.Columns.Add("turno")
        dt_consolidado.Columns.Add("basico_hora")
        dt_consolidado.Columns.Add("basico_mes")

        dt_consolidado.Columns.Add("TotOrD", GetType(Double))

        dt_consolidado.Columns.Add("OrD", GetType(Integer)) '------------------concepto = 1
        dt_consolidado.Columns.Add("RN", GetType(Integer)) '------------------concepto = 17
        dt_consolidado.Columns.Add("DD", GetType(Integer)) '------------------concepto = 31
        dt_consolidado.Columns.Add("DN", GetType(Integer)) '------------------concepto = 32
        dt_consolidado.Columns.Add("DF", GetType(Integer)) '------------------concepto = 2
        dt_consolidado.Columns.Add("ED", GetType(Integer)) '------------------concepto = 13
        dt_consolidado.Columns.Add("EN", GetType(Integer)) '------------------concepto = 14
        dt_consolidado.Columns.Add("EDF", GetType(Integer)) '------------------concepto = 15
        dt_consolidado.Columns.Add("ENF", GetType(Integer)) '------------------concepto = 16
        dt_consolidado.Columns.Add("DComp", GetType(Integer)) '-----------------concepto =33
        dt_consolidado.Columns.Add("PR", GetType(Integer)) '------------------concepto =34
        dt_consolidado.Columns.Add("PRH", GetType(Integer)) '------------------concepto =77
        dt_consolidado.Columns.Add("PV", GetType(Integer)) '------------------concepto =78
        dt_consolidado.Columns.Add("PD", GetType(Integer)) '------------------concepto =35
        dt_consolidado.Columns.Add("PE", GetType(Integer)) '------------------concepto =36
        dt_consolidado.Columns.Add("PC", GetType(Integer)) '------------------concepto =37
        dt_consolidado.Columns.Add("PN", GetType(Integer)) '------------------concepto =510
        dt_consolidado.Columns.Add("IR", GetType(Integer)) '------------------concepto =5
        dt_consolidado.Columns.Add("IA", GetType(Integer)) '------------------concepto =6
        dt_consolidado.Columns.Add("LM", GetType(Integer)) '------------------concepto =7
        dt_consolidado.Columns.Add("V", GetType(Integer)) '------------------no tiene
        dt_consolidado.Columns.Add("DS", GetType(Integer)) '------------------concepto =511
        dt_consolidado.Columns.Add("SU", GetType(Integer)) '------------------concepto =512
        dt_consolidado.Columns.Add("BON", GetType(Integer)) '------------------concepto =43
        dt_consolidado.Columns.Add("FN", GetType(Double)) '------------------516
        dt_consolidado.Columns.Add("HL", GetType(Integer)) '------------------concepto =90
        dt_consolidado.Columns.Add("HR", GetType(Double)) 'Horas ordinarias reales trabajas en el corte de novedades


        addConceptos(dt_consolidado)

        If (dt_datos.Rows.Count - 2 <> -1) Then
            progBar.Maximum = dt_datos.Rows.Count - 2
            progBar.Minimum = 0
        End If
        For i = 0 To dt_datos.Rows.Count - 2
            progBar.PerformStep()
            progBar.Refresh()
            fila = buscar_nit(dt_consolidado, dt_datos.Rows(i).Item("nit"))
            If (fila = -1) Then
                dt_consolidado.Rows.Add()
                dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("nit") = dt_datos.Rows(i).Item("nit")
                dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("nombres") = dt_datos.Rows(i).Item("nombres")
                dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("centro") = dt_datos.Rows(i).Item("centro")
                dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("contrato") = dt_datos.Rows(i).Item("contrato")
                dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("oficio") = dt_datos.Rows(i).Item("oficio")
                dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("planta") = dt_datos.Rows(i).Item("planta")
                dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("turno") = dt_datos.Rows(i).Item("turno")
                dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("basico_hora") = dt_datos.Rows(i).Item("basico_hora")
                dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("basico_mes") = dt_datos.Rows(i).Item("basico_mes")
                dt_tiempo_ordinario = objRelojLn.calcular_horas_ordinarias(id_periodo, dt_datos.Rows(i).Item("nit"), horas_laborales, horas_totales_periodo, fecFin)
                For k = 0 To dt_tiempo_ordinario.Rows.Count - 1
                    dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("OrD") = dt_tiempo_ordinario.Rows(k).Item("OrD")
                    dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("RN") = dt_tiempo_ordinario.Rows(k).Item("RN")
                    dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("DF") = dt_tiempo_ordinario.Rows(k).Item("DF")
                    dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("DComp") = dt_tiempo_ordinario.Rows(k).Item("DComp")
                    dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("DD") = dt_tiempo_ordinario.Rows(k).Item("DD")
                    dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("DN") = dt_tiempo_ordinario.Rows(k).Item("DN")
                    dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("PR") = dt_tiempo_ordinario.Rows(k).Item("PR")
                    dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("PRH") = dt_tiempo_ordinario.Rows(k).Item("PRH")
                    dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("PV") = dt_tiempo_ordinario.Rows(k).Item("PV")
                    dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("PD") = dt_tiempo_ordinario.Rows(k).Item("PD")
                    dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("PE") = dt_tiempo_ordinario.Rows(k).Item("PE")
                    dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("PC") = dt_tiempo_ordinario.Rows(k).Item("PC")
                    dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("PN") = dt_tiempo_ordinario.Rows(k).Item("PN")
                    dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("IR") = dt_tiempo_ordinario.Rows(k).Item("IR")
                    dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("IA") = dt_tiempo_ordinario.Rows(k).Item("IA")
                    dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("LM") = dt_tiempo_ordinario.Rows(k).Item("LM")
                    dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("V") = dt_tiempo_ordinario.Rows(k).Item("V")
                    dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("SU") = dt_tiempo_ordinario.Rows(k).Item("SU")
                    dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("DS") = dt_tiempo_ordinario.Rows(k).Item("DS")
                    dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("BON") = dt_tiempo_ordinario.Rows(k).Item("BON")
                    dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("FN") = dt_tiempo_ordinario.Rows(k).Item("FN")
                    dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HL") = dt_tiempo_ordinario.Rows(k).Item("HL")

                Next
                fila = dt_consolidado.Rows.Count - 1
                'If IsNumeric(dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("PD")) Then
                '    If Not IsDBNull(dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR")) Then
                '        dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR") += dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("PD")
                '    Else
                '        dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR") = dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("PD")
                '    End If
                'End If
                'If IsNumeric(dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("PE")) Then
                '    If Not IsDBNull(dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR")) Then
                '        dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR") += dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("PE")
                '    Else
                '        dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR") = dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("PE")
                '    End If
                'End If
                'If IsNumeric(dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("PC")) Then
                '    If Not IsDBNull(dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR")) Then
                '        dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR") += dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("PC")
                '    Else
                '        dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR") = dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("PC")
                '    End If
                'End If
                'If IsNumeric(dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("PN")) Then
                '    If Not IsDBNull(dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR")) Then
                '        dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR") += dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("PN")
                '    Else
                '        dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR") = dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("PN")
                '    End If
                'End If
                'If IsNumeric(dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("IA")) Then
                '    If Not IsDBNull(dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR")) Then
                '        dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR") += dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("IA")
                '    Else
                '        dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR") = dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("IA")
                '    End If
                'End If
                'If IsNumeric(dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("LM")) Then
                '    If Not IsDBNull(dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR")) Then
                '        dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR") += dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("LM")
                '    Else
                '        dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR") = dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("LM")
                '    End If
                'End If
                'If IsNumeric(dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("SU")) Then
                '    If Not IsDBNull(dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR")) Then
                '        dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR") += dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("SU")
                '    Else
                '        dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR") = dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("SU")
                '    End If
                'End If
                'If IsNumeric(dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("FN")) Then
                '    If Not IsDBNull(dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR")) Then
                '        dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR") += dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("FN")
                '    Else
                '        dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR") = dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("FN")
                '    End If
                'End If
                'If IsNumeric(dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("DS")) Then
                '    If Not IsDBNull(dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR")) Then
                '        dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR") += dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("DS")
                '    Else
                '        dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR") = dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("DS")
                '    End If
                'End If
                'If IsNumeric(dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("SU")) Then
                '    If Not IsDBNull(dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR")) Then
                '        dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR") += dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("SU")
                '    Else
                '        dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR") = dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("SU")
                '    End If
                'End If
                'If IsNumeric(dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("IR")) Then
                '    If Not IsDBNull(dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR")) Then
                '        dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR") += dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("IR")
                '    Else
                '        dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR") = dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("IR")
                '    End If
                'End If
                'If IsNumeric(dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("V")) Then
                '    If Not IsDBNull(dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR")) Then
                '        dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR") += dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("V")
                '    Else
                '        dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR") = dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("V")
                '    End If
                'End If
                'If IsNumeric(dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("Dcomp")) Then
                '    If Not IsDBNull(dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR")) Then
                '        dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR") += dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("Dcomp")
                '    Else
                '        dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR") = dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("Dcomp")
                '    End If
                'End If

                If IsNumeric(dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("PD")) Then
                    If Not IsDBNull(dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR")) Then
                        dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR") += dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("PD")
                    Else
                        dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR") = dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("PD")
                    End If
                End If
                If IsNumeric(dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("PE")) Then
                    If Not IsDBNull(dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR")) Then
                        dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR") += dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("PE")
                    Else
                        dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR") = dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("PE")
                    End If
                End If
                If IsNumeric(dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("PC")) Then
                    If Not IsDBNull(dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR")) Then
                        dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR") += dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("PC")
                    Else
                        dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR") = dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("PC")
                    End If
                End If
                If IsNumeric(dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("PN")) Then
                    If Not IsDBNull(dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR")) Then
                        dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR") += dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("PN")
                    Else
                        dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR") = dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("PN")
                    End If
                End If
                If IsNumeric(dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("IA")) Then
                    If Not IsDBNull(dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR")) Then
                        dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR") += dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("IA")
                    Else
                        dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR") = dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("IA")
                    End If
                End If
                If IsNumeric(dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("LM")) Then
                    If Not IsDBNull(dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR")) Then
                        dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR") += dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("LM")
                    Else
                        dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR") = dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("LM")
                    End If
                End If
                If IsNumeric(dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("SU")) Then
                    If Not IsDBNull(dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR")) Then
                        dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR") += dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("SU")
                    Else
                        dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR") = dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("SU")
                    End If
                End If
                If IsNumeric(dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("FN")) Then
                    If Not IsDBNull(dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR")) Then
                        dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR") += dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("FN")
                    Else
                        dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR") = dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("FN")
                    End If
                End If
                If IsNumeric(dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("DS")) Then
                    If Not IsDBNull(dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR")) Then
                        dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR") += dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("DS")
                    Else
                        dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR") = dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("DS")
                    End If
                End If
                If IsNumeric(dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("SU")) Then
                    If Not IsDBNull(dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR")) Then
                        dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR") += dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("SU")
                    Else
                        dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR") = dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("SU")
                    End If
                End If
                If IsNumeric(dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("IR")) Then
                    If Not IsDBNull(dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR")) Then
                        dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR") += dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("IR")
                    Else
                        dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR") = dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("IR")
                    End If
                End If
                If IsNumeric(dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("V")) Then
                    If Not IsDBNull(dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR")) Then
                        dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR") += dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("V")
                    Else
                        dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR") = dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("V")
                    End If
                End If
                If IsNumeric(dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("Dcomp")) Then
                    If Not IsDBNull(dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR")) Then
                        dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR") += dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("Dcomp")
                    Else
                        dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("HR") = dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("Dcomp")
                    End If
                End If
            End If

            If consolidar_todo_extra And nit_consol_todo_extra = dt_datos.Rows(i).Item("nit") Then
                consolidar_marcacion_todo_Extra(i, fila, dt_consolidado, tot_horas_dia, dt_datos)
            Else
                consolidar_marcacion(i, fila, dt_consolidado, dt_datos)
            End If

            num = dt_datos.Rows(i).Item("Consec")
            If consolidar_todo_extra = False And verificar_varias_marcaciones_dia(dt_datos.Rows(i).Item("nit"), dt_datos.Rows(i).Item("FechaEntrada"), dt_datos) And verificar_turno_prog_doble(dt_datos.Rows(i).Item("turnoProg")) = False Then
                tot_horas_dia = horas_dia(dt_datos.Rows(i).Item("nit"), dt_datos.Rows(i).Item("FechaEntrada"))
                nit_consol_todo_extra = dt_datos.Rows(i).Item("nit")
                If (tot_horas_dia > 8) Then
                    consolidar_todo_extra = True
                Else
                    consolidar_todo_extra = False
                End If
            Else
                tot_horas_dia = 0
                consolidar_todo_extra = False
                nit_consol_todo_extra = 0
            End If
        Next
        dtg_consulta.DataSource = Nothing
        addCompromisos(dt_consolidado)
        dt_consolidado.Rows.Add()
        dtg_consulta.DataSource = dt_consolidado
        tot_ordinarias()
        descontar_incapacidades_a_ordinarias()
        descontar_novedades_permisos_a_ordinarias()
        ' descontar_dom_sancion()
        toolTipConceptos()
        pintar_dtg()
        descontar_horas_compromiso()
        tot_ordinarias()
        descontar_dom_noct_turno_noche()
        tot_ordinarias()
        descontar_dom_noct_turno_dia()
        tot_ordinarias()
        totalizar(dtg_consulta)

        verificar_horas_ordinarias_totales()
        For j = 0 To dt_datos.Columns.Count - 1
            If (dtg_consulta.Columns(j).Name = "contrato" Or dtg_consulta.Columns(j).Name = "oficio" Or dtg_consulta.Columns(j).Name = "planta" Or dtg_consulta.Columns(j).Name = "turno" Or dtg_consulta.Columns(j).Name = "basico_hora" Or dtg_consulta.Columns(j).Name = "basico_mes") Then
                dtg_consulta.Columns(j).Visible = False
            End If
        Next
        dtg_consulta.CurrentCell = Nothing
        dtg_consulta.Rows(0).Visible = False
        dtg_consulta.Rows(1).Visible = False
        progBar.Value = 0
        valorizar()
    End Sub

    Private Function horas_dia(ByVal nit As Double, ByVal fec As Date) As Double
        Dim tot_horas As Integer = 0
        Dim fec_buscar As String = objOpSimplesLn.cambiarFormatoFecha(fec)
        Dim fec_dtg As String = ""
        For i = 0 To dtg_consulta.Rows.Count - 1
            If Not IsDBNull(dtg_consulta.Item("nit", i).Value) Then
                fec_dtg = objOpSimplesLn.cambiarFormatoFecha(dtg_consulta.Item("FechaEntrada", i).Value)
                If (fec_dtg = fec_buscar And dtg_consulta.Item("nit", i).Value = nit) Then
                    For j = 0 To dtg_consulta.Columns.Count - 1
                        If (dtg_consulta.Columns(j).Name = "DD" Or dtg_consulta.Columns(j).Name = "DN" Or dtg_consulta.Columns(j).Name = "ED" Or dtg_consulta.Columns(j).Name = "EN" Or
                           dtg_consulta.Columns(j).Name = "EDF" Or dtg_consulta.Columns(j).Name = "ENF" Or
                            dtg_consulta.Columns(j).Name = "OrD" Or dtg_consulta.Columns(j).Name = "DD" Or dtg_consulta.Columns(j).Name = "DN") Then
                            If Not IsDBNull(dtg_consulta.Item(j, i).Value) Then
                                tot_horas += dtg_consulta.Item(j, i).Value
                            End If
                        End If
                    Next
                End If
            End If
        Next
        Return tot_horas
    End Function
    Private Sub toolTipConceptos()
        Dim conceptos As String = ""
        Dim sql_desc_conceptos As String = "Select concepto,CAST(concepto As varchar) + ' - ' + descripcion As descripcion " &
                                                "FROM y_conceptos_nom " &
                                                      "WHERE concepto IN (" & conceptos_liquidar & ")"
        Dim dt_desc_conceptos As DataTable = objOpSimplesLn.listar_datatable(sql_desc_conceptos, "CORSAN")
        For j = 0 To dtg_consulta.Columns.Count - 1
            If IsNumeric(dtg_consulta.Item(j, 0).Value) Then
                For k = 0 To dt_desc_conceptos.Rows.Count - 1
                    If (dt_desc_conceptos.Rows(k).Item("concepto") = dtg_consulta.Item(j, 0).Value) Then
                        For i = 0 To dtg_consulta.Rows.Count - 1
                            dtg_consulta.Item(j, i).ToolTipText = dt_desc_conceptos.Rows(k).Item("descripcion")
                        Next
                        k = dt_desc_conceptos.Rows.Count - 1
                    End If
                Next
            End If
            If dtg_consulta.Columns(j).Name = "HR" Then
                For i = 0 To dtg_consulta.Rows.Count - 1
                    dtg_consulta.Item(j, i).ToolTipText = "Horas reales trabajadas Σ(Perm,Inc,Sus,Marcaciones)"
                Next
            End If
        Next

    End Sub
    Private Sub tot_ordinarias()
        Dim tot_horas As Double = 0
        For i = 2 To dtg_consulta.Rows.Count - 1
            For j = 0 To dtg_consulta.Columns.Count - 1
                If dtg_consulta.Columns(j).Name = "OrD" Or dtg_consulta.Columns(j).Name = "HL" Or dtg_consulta.Columns(j).Name = "DComp" Or dtg_consulta.Columns(j).Name = "DD" Or
                    dtg_consulta.Columns(j).Name = "DN" Or dtg_consulta.Columns(j).Name = "DF" Or dtg_consulta.Columns(j).Name = "PRH" Or dtg_consulta.Columns(j).Name = "PV" Or dtg_consulta.Columns(j).Name = "PR" Or dtg_consulta.Columns(j).Name = "PD" Or
                    dtg_consulta.Columns(j).Name = "PE" Or dtg_consulta.Columns(j).Name = "PC" Or dtg_consulta.Columns(j).Name = "PN" Or
                    dtg_consulta.Columns(j).Name = "IR" Or dtg_consulta.Columns(j).Name = "IA" Or dtg_consulta.Columns(j).Name = "LM" Or dtg_consulta.Columns(j).Name = "V" _
                        Or dtg_consulta.Columns(j).Name = "SU" Or dtg_consulta.Columns(j).Name = "DS" Then
                    If IsNumeric(dtg_consulta.Item(j, i).Value) Then
                        tot_horas += dtg_consulta.Item(j, i).Value
                    End If
                End If
            Next
            dtg_consulta.Item("TotOrD", i).Value = tot_horas
            tot_horas = 0
        Next
    End Sub
    Private Sub descontar_dom_sancion()
        Dim tot_horas_nov_permisos As Double = 0
        For i = 1 To dtg_consulta.Rows.Count - 1
            If IsNumeric(dtg_consulta.Item("DF", i).Value) Then
                For j = 0 To dtg_consulta.Columns.Count - 1
                    If dtg_consulta.Columns(j).Name = "DS" Then
                        If IsNumeric(dtg_consulta.Item(j, i).Value) Then
                            tot_horas_nov_permisos += dtg_consulta.Item(j, i).Value
                        End If
                    End If
                Next
                If Not IsDBNull(dtg_consulta.Item("DF", i).Value) Then
                    If (dtg_consulta.Item("DF", i).Value >= tot_horas_nov_permisos) Then
                        dtg_consulta.Item("DF", i).Value -= tot_horas_nov_permisos
                    End If
                End If
                tot_horas_nov_permisos = 0
            End If
        Next
    End Sub
    Private Sub descontar_novedades_permisos_a_ordinarias()
        Dim tot_horas_nov_permisos As Double = 0
        For i = 2 To dtg_consulta.Rows.Count - 1
            If IsNumeric(dtg_consulta.Item("TotOrD", i).Value) Then
                If (dtg_consulta.Item("TotOrD", i).Value > horas_totales_periodo) Then
                    For j = 0 To dtg_consulta.Columns.Count - 1
                        If dtg_consulta.Columns(j).Name = "PRH" Or dtg_consulta.Columns(j).Name = "HL" Or dtg_consulta.Columns(j).Name = "PV" Or dtg_consulta.Columns(j).Name = "PR" Or dtg_consulta.Columns(j).Name = "PD" Or
                            dtg_consulta.Columns(j).Name = "PE" Or dtg_consulta.Columns(j).Name = "PC" Or dtg_consulta.Columns(j).Name = "PN" Or dtg_consulta.Columns(j).Name = "V" Or dtg_consulta.Columns(j).Name = "SU" Then
                            If IsNumeric(dtg_consulta.Item(j, i).Value) Then
                                tot_horas_nov_permisos += dtg_consulta.Item(j, i).Value
                            End If
                        End If
                    Next
                    If Not IsDBNull(dtg_consulta.Item("OrD", i).Value) Then
                        If (dtg_consulta.Item("OrD", i).Value >= tot_horas_nov_permisos) Then
                            dtg_consulta.Item("OrD", i).Value -= tot_horas_nov_permisos
                        End If
                    End If
                    tot_horas_nov_permisos = 0
                End If
            End If
        Next
    End Sub
    Private Sub descontar_incapacidades_a_ordinarias()
        Dim tot_horas_incapacidad As Double = 0
        For i = 2 To dtg_consulta.Rows.Count - 1
            If IsNumeric(dtg_consulta.Item("TotOrD", i).Value) Then
                If (dtg_consulta.Item("TotOrD", i).Value > horas_totales_periodo) Then
                    For j = 0 To dtg_consulta.Columns.Count - 1
                        If dtg_consulta.Columns(j).Name = "IR" Or dtg_consulta.Columns(j).Name = "IA" Or dtg_consulta.Columns(j).Name = "LM" Then
                            If IsNumeric(dtg_consulta.Item(j, i).Value) Then
                                tot_horas_incapacidad += dtg_consulta.Item(j, i).Value
                            End If
                        End If
                    Next
                    If Not IsDBNull(dtg_consulta.Item("OrD", i).Value) Then
                        If (dtg_consulta.Item("OrD", i).Value >= tot_horas_incapacidad) Then
                            dtg_consulta.Item("OrD", i).Value -= tot_horas_incapacidad
                        End If
                    End If
                    If Not IsDBNull(dtg_consulta.Item("RN", i).Value) Then
                        If (dtg_consulta.Item("RN", i).Value >= tot_horas_incapacidad) Then
                            dtg_consulta.Item("RN", i).Value -= tot_horas_incapacidad
                        End If
                    End If
                    tot_horas_incapacidad = 0
                End If
            End If
        Next
    End Sub
    Private Sub addConceptos(ByRef dt As DataTable)
        dt.Rows.Add()
        dt.Rows(dt.Rows.Count - 1).Item("nombres") = "CONCEPTOS"
        dt.Rows(dt.Rows.Count - 1).Item("OrD") = 1
        dt.Rows(dt.Rows.Count - 1).Item("RN") = 17
        dt.Rows(dt.Rows.Count - 1).Item("DD") = 31
        dt.Rows(dt.Rows.Count - 1).Item("DN") = 32
        dt.Rows(dt.Rows.Count - 1).Item("DF") = 2
        dt.Rows(dt.Rows.Count - 1).Item("ED") = 13
        dt.Rows(dt.Rows.Count - 1).Item("EN") = 14
        dt.Rows(dt.Rows.Count - 1).Item("EDF") = 15
        dt.Rows(dt.Rows.Count - 1).Item("ENF") = 16
        dt.Rows(dt.Rows.Count - 1).Item("DComp") = 33
        dt.Rows(dt.Rows.Count - 1).Item("PR") = 34
        dt.Rows(dt.Rows.Count - 1).Item("PRH") = 77
        dt.Rows(dt.Rows.Count - 1).Item("PV") = 78
        dt.Rows(dt.Rows.Count - 1).Item("PD") = 35
        dt.Rows(dt.Rows.Count - 1).Item("PE") = 36
        dt.Rows(dt.Rows.Count - 1).Item("PC") = 37
        dt.Rows(dt.Rows.Count - 1).Item("PN") = 510
        dt.Rows(dt.Rows.Count - 1).Item("HL") = 90
        dt.Rows(dt.Rows.Count - 1).Item("IR") = 5
        dt.Rows(dt.Rows.Count - 1).Item("IA") = 6
        dt.Rows(dt.Rows.Count - 1).Item("LM") = 7
        dt.Rows(dt.Rows.Count - 1).Item("SU") = 512
        dt.Rows(dt.Rows.Count - 1).Item("DS") = 511
        dt.Rows(dt.Rows.Count - 1).Item("BON") = 43
        dt.Rows(dt.Rows.Count - 1).Item("V") = 10
        conceptos_liquidar = "1,30,31,32,2,13,14,15,16,33,34,35,36,37,510,5,6,7,512,511,43,10,17,77,78,90"
        Dim sql As String = "SELECT concepto,porc_basico FROM y_conceptos_nom WHERE concepto IN (" & conceptos_liquidar & ")"
        Dim dt_porc_conceptos As DataTable = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        dt.Rows.Add()
        For i = 0 To dt_porc_conceptos.Rows.Count - 1
            Select Case dt_porc_conceptos.Rows(i).Item("concepto")
                Case 1
                    dt.Rows(dt.Rows.Count - 1).Item("OrD") = dt_porc_conceptos.Rows(i).Item("porc_basico")
                Case 2
                    dt.Rows(dt.Rows.Count - 1).Item("DF") = dt_porc_conceptos.Rows(i).Item("porc_basico")
                Case 5
                    dt.Rows(dt.Rows.Count - 1).Item("IR") = dt_porc_conceptos.Rows(i).Item("porc_basico")
                Case 6
                    dt.Rows(dt.Rows.Count - 1).Item("IA") = dt_porc_conceptos.Rows(i).Item("porc_basico")
                Case 7
                    dt.Rows(dt.Rows.Count - 1).Item("LM") = dt_porc_conceptos.Rows(i).Item("porc_basico")
                Case 10
                    dt.Rows(dt.Rows.Count - 1).Item("V") = 100
                Case 13
                    dt.Rows(dt.Rows.Count - 1).Item("ED") = dt_porc_conceptos.Rows(i).Item("porc_basico")
                Case 14
                    dt.Rows(dt.Rows.Count - 1).Item("EN") = dt_porc_conceptos.Rows(i).Item("porc_basico")
                Case 15
                    dt.Rows(dt.Rows.Count - 1).Item("EDF") = dt_porc_conceptos.Rows(i).Item("porc_basico")
                Case 16
                    dt.Rows(dt.Rows.Count - 1).Item("ENF") = dt_porc_conceptos.Rows(i).Item("porc_basico")
                Case 30
                    dt.Rows(dt.Rows.Count - 1).Item("RN") = 35
                Case 31
                    dt.Rows(dt.Rows.Count - 1).Item("DD") = dt_porc_conceptos.Rows(i).Item("porc_basico")
                Case 32
                    dt.Rows(dt.Rows.Count - 1).Item("DN") = dt_porc_conceptos.Rows(i).Item("porc_basico")
                Case 33
                    dt.Rows(dt.Rows.Count - 1).Item("DComp") = dt_porc_conceptos.Rows(i).Item("porc_basico")
                Case 34
                    dt.Rows(dt.Rows.Count - 1).Item("PR") = 100
                Case 77
                    dt.Rows(dt.Rows.Count - 1).Item("PRH") = 100
                Case 78
                    dt.Rows(dt.Rows.Count - 1).Item("PV") = 100
                Case 35
                    dt.Rows(dt.Rows.Count - 1).Item("PD") = 100
                Case 36
                    dt.Rows(dt.Rows.Count - 1).Item("PE") = 100
                Case 37
                    dt.Rows(dt.Rows.Count - 1).Item("PC") = 100
                Case 43
                    dt.Rows(dt.Rows.Count - 1).Item("BON") = dt_porc_conceptos.Rows(i).Item("porc_basico")
                Case 90
                    dt.Rows(dt.Rows.Count - 1).Item("HL") = 100
                Case 510
                    dt.Rows(dt.Rows.Count - 1).Item("PN") = dt_porc_conceptos.Rows(i).Item("porc_basico")
                Case 511
                    dt.Rows(dt.Rows.Count - 1).Item("DS") = 0
                Case 512
                    dt.Rows(dt.Rows.Count - 1).Item("SU") = 0
            End Select
        Next
    End Sub
    Private Sub consolidar_marcacion(ByVal fila_datos As Integer, ByVal fila_consolidado As Integer, ByRef dt_consolidado As DataTable, ByRef dt_datos As DataTable)
        Dim fecha As New Date
        If IsDate(dt_datos.Rows(fila_datos).Item("FechaEntrada")) Then
            fecha = CDate(dt_datos.Rows(fila_datos).Item("FechaEntrada")).ToString("d")
        End If
        For j = 0 To dt_datos.Columns.Count - 1
            If (dt_datos.Columns(j).ColumnName = "DD" Or
                     dt_datos.Columns(j).ColumnName = "DN" Or dt_datos.Columns(j).ColumnName = "ED" Or dt_datos.Columns(j).ColumnName = "EN" Or dt_datos.Columns(j).ColumnName = "EDF" Or
                        dt_datos.Columns(j).ColumnName = "ENF" Or dt_datos.Columns(j).ColumnName = "RN" Or dt_datos.Columns(j).ColumnName = "OrD") Then
                If IsNumeric(dt_datos.Rows(fila_datos).Item(j)) Then
                    If dt_datos.Columns(j).ColumnName = "ENF" Or dt_datos.Columns(j).ColumnName = "EDF" Then
                        Dim dia_compensatorio As Boolean = objRelojLn.consultar_dia_compensatorio(dt_datos.Rows(fila_datos).Item("nit"), dt_datos.Rows(fila_datos).Item("FechaEntrada"))
                        If dia_compensatorio Then
                            If (dt_datos.Rows(fila_datos).Item("ExtP") > 0) Then
                                If (dt_datos.Rows(fila_datos).Item(j) > (dt_datos.Rows(fila_datos).Item("OrdP") + dt_datos.Rows(fila_datos).Item("ExtP"))) Then
                                    dt_datos.Rows(fila_datos).Item(j) = dt_datos.Rows(fila_datos).Item("ExtP")
                                End If
                            Else
                                dt_datos.Rows(fila_datos).Item(j) = 0
                            End If
                        Else
                            If ((dt_datos.Rows(fila_datos).Item("OrdP") + dt_datos.Rows(fila_datos).Item("ExtP")) > 0) Then
                                If (dt_datos.Rows(fila_datos).Item(j) > (dt_datos.Rows(fila_datos).Item("OrdP") + dt_datos.Rows(fila_datos).Item("ExtP"))) Then
                                    dt_datos.Rows(fila_datos).Item(j) = dt_datos.Rows(fila_datos).Item("ExtP")
                                End If
                            Else
                                dt_datos.Rows(fila_datos).Item(j) = 0
                            End If
                        End If
                        If ((dt_datos.Rows(fila_datos).Item("OrdP") + dt_datos.Rows(fila_datos).Item("ExtP")) > 0) Then
                            If (dt_datos.Rows(fila_datos).Item(j) > (dt_datos.Rows(fila_datos).Item("OrdP") + dt_datos.Rows(fila_datos).Item("ExtP"))) Then
                                dt_datos.Rows(fila_datos).Item(j) = 0
                            End If
                        Else
                            dt_datos.Rows(fila_datos).Item(j) = 0
                        End If
                    ElseIf dt_datos.Columns(j).ColumnName = "DD" Or dt_datos.Columns(j).ColumnName = "DN" Then
                        If IsNumeric(dt_datos.Rows(fila_datos).Item("ExtP")) Then
                            If dt_datos.Rows(fila_datos).Item("ExtP") > 0 Then
                                If (dt_datos.Rows(fila_datos).Item(j) > dt_datos.Rows(fila_datos).Item("ExtP")) Then
                                    dt_datos.Rows(fila_datos).Item(j) = dt_datos.Rows(fila_datos).Item("ExtP")
                                End If
                            Else
                                If dt_datos.Columns(j).ColumnName <> "DD" And dt_datos.Columns(j).ColumnName <> "DN" Then
                                    dt_datos.Rows(fila_datos).Item(j) = 0
                                End If
                            End If
                        Else
                            If dt_datos.Columns(j).ColumnName <> "DD" And dt_datos.Columns(j).ColumnName <> "DN" Then
                                dt_datos.Rows(fila_datos).Item(j) = 0
                            End If
                        End If
                    ElseIf dt_datos.Columns(j).ColumnName = "RN" Then
                        'se valida si la marcacion es menor a la fecha donde se inicia la decada
                        If (fecha < dFecIni_periodo) Then
                            dt_datos.Rows(fila_datos).Item(j) = 0
                        End If
                    ElseIf dt_datos.Columns(j).ColumnName = "ED" Or dt_datos.Columns(j).ColumnName = "EN" Then
                        If IsNumeric(dt_datos.Rows(fila_datos).Item("ExtP")) Then
                            If dt_datos.Rows(fila_datos).Item("ExtP") > 0 Then
                                If (dt_datos.Rows(fila_datos).Item(j) > dt_datos.Rows(fila_datos).Item("ExtP")) Then
                                    dt_datos.Rows(fila_datos).Item(j) = dt_datos.Rows(fila_datos).Item("ExtP")
                                End If
                            Else
                                dt_datos.Rows(fila_datos).Item(j) = 0
                            End If
                        Else
                            dt_datos.Rows(fila_datos).Item(j) = 0
                        End If
                    ElseIf dt_datos.Columns(j).ColumnName = "OrD" Then
                        If IsNumeric(dt_datos.Rows(fila_datos).Item("OrD")) Then
                            If Not IsDBNull(dt_consolidado.Rows(fila_consolidado).Item("HR")) Then
                                dt_consolidado.Rows(fila_consolidado).Item("HR") += dt_datos.Rows(fila_datos).Item(j)
                            Else
                                dt_consolidado.Rows(fila_consolidado).Item("HR") = dt_datos.Rows(fila_datos).Item(j)
                            End If
                        End If
                    End If
                    If dt_datos.Columns(j).ColumnName <> "OrD" Then
                        If Not IsDBNull(dt_consolidado.Rows(fila_consolidado).Item(dt_datos.Columns(j).ColumnName)) Then
                            dt_consolidado.Rows(fila_consolidado).Item(dt_datos.Columns(j).ColumnName) += dt_datos.Rows(fila_datos).Item(j)
                        Else
                            dt_consolidado.Rows(fila_consolidado).Item(dt_datos.Columns(j).ColumnName) = dt_datos.Rows(fila_datos).Item(j)
                        End If
                    End If
                End If
            End If
        Next
    End Sub
    Private Sub consolidar_marcacion_todo_Extra(ByVal fila_datos As Integer, ByVal fila_consolidado As Integer, ByRef dt_consolidado As DataTable, ByVal tot_horas_dia As Integer, ByRef dt_datos As DataTable)
        Dim horas As DueDate = 0
        For j = 0 To dt_datos.Columns.Count - 1
            If (dt_datos.Columns(j).ColumnName = "DD" Or dt_datos.Columns(j).ColumnName = "DN" Or dt_datos.Columns(j).ColumnName = "ED" Or dt_datos.Columns(j).ColumnName = "EN" Or
                    dt_datos.Columns(j).ColumnName = "EDF" Or dt_datos.Columns(j).ColumnName = "ENF" Or
                   dt_datos.Columns(j).ColumnName = "OrD" Or dt_datos.Columns(j).ColumnName = "RN" Or dt_datos.Columns(j).ColumnName = "DD" Or dt_datos.Columns(j).ColumnName = "DN") Then
                If (dt_datos.Columns(j).ColumnName = "DD" Or
                   dt_datos.Columns(j).ColumnName = "DN" Or dt_datos.Columns(j).ColumnName = "ED" Or dt_datos.Columns(j).ColumnName = "EDF" Or
                      dt_datos.Columns(j).ColumnName = "ENF") Then
                    If Not IsDBNull(dt_datos.Rows(fila_datos).Item(j)) Then
                        If Not IsDBNull(dt_consolidado.Rows(fila_consolidado).Item(dt_datos.Columns(j).ColumnName)) Then
                            dt_consolidado.Rows(fila_consolidado).Item(dt_datos.Columns(j).ColumnName) += dt_datos.Rows(fila_datos).Item(j)
                        Else
                            dt_consolidado.Rows(fila_consolidado).Item(dt_datos.Columns(j).ColumnName) = dt_datos.Rows(fila_datos).Item(j)
                        End If
                    End If
                ElseIf (dt_datos.Columns(j).ColumnName = "OrD" And IsNumeric(dt_datos.Rows(fila_datos).Item(j))) Then
                    horas = tot_horas_dia - dt_datos.Rows(fila_datos).Item(j).Item(j, fila_datos).Value
                    If IsDBNull(dt_consolidado.Rows(fila_consolidado).Item(dt_datos.Columns("ED").ColumnName)) Then
                        dt_consolidado.Rows(fila_consolidado).Item(dt_datos.Columns("ED").ColumnName) = horas
                    Else
                        dt_consolidado.Rows(fila_consolidado).Item(dt_datos.Columns("ED").ColumnName) += horas
                    End If
                    If IsDBNull(dt_consolidado.Rows(fila_consolidado).Item(dt_datos.Columns("OrD").ColumnName)) Then
                        dt_consolidado.Rows(fila_consolidado).Item(dt_datos.Columns("HR").ColumnName) = dt_datos.Rows(fila_datos).Item(j).Item(j, fila_datos).Value
                    Else
                        dt_consolidado.Rows(fila_consolidado).Item(dt_datos.Columns("HR").ColumnName) += dt_datos.Rows(fila_datos).Item(j).Item(j, fila_datos).Value
                    End If
                ElseIf (dt_datos.Columns(j).ColumnName = "RN" And IsNumeric(dt_datos.Rows(fila_datos).Item(j))) Then
                    horas = tot_horas_dia - dt_datos.Rows(fila_datos).Item(j)
                    If IsDBNull(dt_consolidado.Rows(fila_consolidado).Item(dt_datos.Columns("EN").ColumnName)) Then
                        dt_consolidado.Rows(fila_consolidado).Item(dt_datos.Columns("EN").ColumnName) = horas
                    Else
                        dt_consolidado.Rows(fila_consolidado).Item(dt_datos.Columns("EN").ColumnName) += horas
                    End If
                ElseIf (dt_datos.Columns(j).ColumnName = "DD" And IsNumeric(dt_datos.Rows(fila_datos).Item(j))) Then
                    horas = tot_horas_dia - dt_datos.Rows(fila_datos).Item(j)
                    If IsDBNull(dt_consolidado.Rows(fila_consolidado).Item(dt_datos.Columns("EDF").ColumnName)) Then
                        dt_consolidado.Rows(fila_consolidado).Item(dt_datos.Columns("EDF").ColumnName) = horas
                    Else
                        dt_consolidado.Rows(fila_consolidado).Item(dt_datos.Columns("EDF").ColumnName) += horas
                    End If
                ElseIf (dt_datos.Columns(j).ColumnName = "DN" And IsNumeric(dt_datos.Rows(fila_datos).Item(j))) Then
                    horas = tot_horas_dia - dt_datos.Rows(fila_datos).Item(j)
                    If IsDBNull(dt_consolidado.Rows(fila_consolidado).Item(dt_datos.Columns("ENF").ColumnName)) Then
                        dt_consolidado.Rows(fila_consolidado).Item(dt_datos.Columns("ENF").ColumnName) = horas
                    Else
                        dt_consolidado.Rows(fila_consolidado).Item(dt_datos.Columns("ENF").ColumnName) += horas
                    End If
                End If

            End If
        Next
    End Sub
    Private Function verificar_varias_marcaciones_dia(ByVal nit As Double, ByVal fec As Date, ByRef dt_datos As DataTable) As Boolean
        Dim cont As Integer = 0
        Dim fec_buscar As String = objOpSimplesLn.cambiarFormatoFecha(fec)
        Dim fec_dtg As String = ""
        For i = 0 To dt_datos.Rows.Count - 1
            If Not IsDBNull(dt_datos.Rows(i).Item("nit")) Then
                fec_dtg = objOpSimplesLn.cambiarFormatoFecha(dt_datos.Rows(i).Item("FechaEntrada"))
                If (fec_dtg = fec_buscar And dt_datos.Rows(i).Item("nit") = nit) Then
                    cont += 1
                End If
            End If
        Next
        If cont > 1 Then
            Return True
        Else
            Return False
        End If
    End Function
    Private Function verificar_turno_prog_doble(ByVal cadena As String) As Boolean
        Dim cont As Integer = 0
        For i = 0 To cadena.Length - 1
            If cadena(i) = "-" Then
                cont += 1
            End If
        Next
        If cont > 1 Then
            Return True
        Else
            Return False
        End If
    End Function
    Private Function buscar_nit(ByRef dt As DataTable, ByRef nit As Double) As Integer
        Dim fila As Integer = -1
        For i = 2 To dt.Rows.Count - 1
            If (dt.Rows(i).Item("nit") = nit) Then
                Return i
            End If
        Next
        Return fila
    End Function
    Private Sub btn_cerrar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_cerrar.Click
        groupFecha.Visible = False
    End Sub


    Private Sub btn_ok_fec_hora_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_ok_fec_hora.Click
        If txtMotivoMaracion.Text <> "" Then
            Dim notas As String = txtMotivoMaracion.Text & " - " & Now & " - " & usuario.nombre
            Dim fec_hora As String = objOpSimplesLn.cambiarFormatoFecha(cboCal.SelectionEnd.Date) & " " & cbo_hora.Text & ":" & cbo_min.Text & ":00"
            Dim col_fec_hora As String = ""
            Dim consecutivo As Double = dtg_consulta.Item("Consec", filaSelect_consulta).Value
            If (dtg_consulta.Columns(colSelect_consulta).Name = "FechaEntrada" Or dtg_consulta.Columns(colSelect_consulta).Name = "fechaEntrada") Then
                col_fec_hora = "FechaEntrada"
            Else
                col_fec_hora = "FechaSalida"
            End If
            Dim sql As String = "UPDATE r_personal_registros SET " & col_fec_hora & " = '" & fec_hora & "', notas = '" & notas & "' , permiso = 'C' WHERE Consecutivo = " & consecutivo
            If (objOpSimplesLn.ejecutar(sql, "CONTROL")) Then
                MessageBox.Show("Marcación actualizada en forma exitosa", "Correcto!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                dtg_consulta.Item(col_fec_hora, filaSelect_consulta).Value = fec_hora
                groupFecha.Visible = False
                realizar_validacion_inicio()
            Else
                MessageBox.Show("Eror al actualizar la fecha y hora de macación, comuniquese con el area de sistemas", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            MessageBox.Show("Debe ingresar un motivo para corregir la marcación", "Ingrese motivo!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

    End Sub

    Private Sub dtg_consulta_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dtg_consulta.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then

            DetalleToolStripMenuItem.Enabled = True
            dtg_select = dtg_consulta.Name
            If dtg_consulta.Rows.Count > 0 Then
                With (Me.dtg_consulta)
                    Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                    If Hitest.Type = DataGridViewHitTestType.Cell Then
                        .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                        If Not estado_consolidado Then
                            consecutivo = Me.dtg_consulta("consec", Me.dtg_consulta.CurrentRow.Index).Value
                            guardarconsecutivo(consecutivo)
                        End If
                    End If
                End With
                filaSelect_consulta = dtg_consulta.CurrentCell.RowIndex
                colSelect_consulta = dtg_consulta.CurrentCell.ColumnIndex
                If objRelojLn.verificar_periodo_liquidado(id_periodo) Then
                    'MessageBox.Show("Este periodo se encuentra liquidado, por lo tanto no se permite hacer cambios en turnos ni ingresar novedades", "Periodo liquidado", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    periodo_liquidado = True
                    bloquear_modificar_valores(False)
                Else
                    periodo_liquidado = False
                    If dtg_consulta.CurrentCell.RowIndex <> dtg_consulta.Rows.Count Then
                        bloquear_modificar_valores(True)
                    Else
                        bloquear_modificar_valores(False)
                    End If
                End If
            End If
        End If
    End Sub
    Public Function guardarconsecutivo(ByVal conse As Integer)
        consecutivop = conse
        Return consecutivop
    End Function

    Private Sub dtg_detalle_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dtg_detalle.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            DetalleToolStripMenuItem.Enabled = False
            dtg_select = dtg_detalle.Name
            If dtg_detalle.Rows.Count > 0 Then
                With (Me.dtg_detalle)
                    Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                    If Hitest.Type = DataGridViewHitTestType.Cell Then
                        .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                    End If
                End With
                filaSelect_detalle = dtg_detalle.CurrentCell.RowIndex
                colSelect_detalle = dtg_detalle.CurrentCell.ColumnIndex
                bloquear_group_novedad(True)
            End If
        End If
    End Sub
    Private Sub dtg_consulta_DataError(ByVal sender As Object, ByVal e As DataGridViewDataErrorEventArgs) Handles dtg_consulta.DataError

    End Sub

    Private Sub itemMod_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim dtg As DataGridView = Nothing
        Select Case dtg_select
            Case dtg_consulta.Name
                dtg = dtg_consulta
            Case dtg_detalle.Name
                dtg = dtg_detalle
        End Select
        If (dtg.CurrentCell.RowIndex >= 0 And correccion = True) Then
            If (dtg.Columns(dtg.CurrentCell.ColumnIndex).Name = "FechaEntrada" Or dtg.Columns(dtg.CurrentCell.ColumnIndex).Name = "FechaSalida" Or dtg.Columns(dtg.CurrentCell.ColumnIndex).Name = "fechaEntrada" Or dtg.Columns(dtg.CurrentCell.ColumnIndex).Name = "fechaSalida") Then
                filaSelect_consulta = dtg.CurrentCell.RowIndex
                colSelect_consulta = dtg.CurrentCell.ColumnIndex
                groupFecha.Visible = True
            End If
        End If
    End Sub
    Private Sub ToolStripSplitButton1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ToolStripSplitButton1.Click
        objOperacionesForm.ExportarDatosExcel(dtg_consulta, "Marcaciones")
    End Sub
    Private Sub btn_6am_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim fec_ini As String = objOpSimplesLn.cambiarFormatoFecha(Convert.ToDateTime(cbo_fecha_ini.Value))
        Dim fec_fin As String = objOpSimplesLn.cambiarFormatoFecha(Convert.ToDateTime(cbo_fecha_fin.Value))
        Dim iResponce = MessageBox.Show("Esta seguro que desea llevar las marcaciones del perriodo de tiempo : " & objOpSimplesLn.cambiarFormatoFecha(cbo_fecha_ini.Value) & " - " & objOpSimplesLn.cambiarFormatoFecha(cbo_fecha_fin.Value) & " a las 6:00 AM?", "Atención", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
        If (iResponce = 6) Then
            Dim sql As String = "UPDATE R_Personal_Registros  " &
                                    "SET fechaEntrada = CAST (YEAR(fechaEntrada)As varchar)+'-'+ CAST (MONTH(fechaEntrada)As varchar) +'-'+ CAST (DAY(fechaEntrada)As varchar) + ' ' + '06:00:00' " &
                                        "WHERE fechaEntrada Between '" & fec_ini & "' AND '" & fec_fin & " 23:59:59' AND CAST(fechaEntrada As time) > '04:00:00' AND CAST(fechaEntrada As time) < '06:00:00'"
            If (objOpSimplesLn.ejecutar(sql, "CONTROL") > 0) Then
                MessageBox.Show("Las marcaciones se llevaron con exito a las 6:00 AM", "Terminado!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Error al llevar las marcaciones a las 6:00 AM, comuniquese con el area de sistemas", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub
    Private Sub btn_cerrar_detalle_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_cerrar_detalle.Click
        group_detalle.Visible = False
    End Sub
    Private Sub DetalleToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        group_detalle.Visible = True
        Dim nit As Double = dtg_consulta.Item("nit", filaSelect_consulta).Value
        If (dtg_consulta.Columns(colSelect_consulta).Name = "PRH" Or dtg_consulta.Columns(colSelect_consulta).Name = "PV" Or dtg_consulta.Columns(colSelect_consulta).Name = "PR" Or dtg_consulta.Columns(colSelect_consulta).Name = "PD" Or dtg_consulta.Columns(colSelect_consulta).Name = "PE" Or dtg_consulta.Columns(colSelect_consulta).Name = "PC" _
                           Or dtg_consulta.Columns(colSelect_consulta).Name = "PN") Then
            detalle_permisos(nit)
        ElseIf dtg_consulta.Columns(colSelect_consulta).Name = "IR" Or dtg_consulta.Columns(colSelect_consulta).Name = "IA" Or dtg_consulta.Columns(colSelect_consulta).Name = "LM" Then
            detalle_incapacidades(nit)
        ElseIf (dtg_consulta.Columns(colSelect_consulta).Name = "V") Then
            detalle_vacaciones(nit)
        ElseIf (dtg_consulta.Columns(colSelect_consulta).Name = "SU" Or dtg_consulta.Columns(colSelect_consulta).Name = "DS") Then
            detalle_suspensiones(nit)
        Else
            detalle_marcaciones(nit)
        End If
    End Sub
    Private Sub detalle_marcaciones(ByVal nit As Double)
        Dim tamano_letra As Single = 9.0!
        Dim where_operario As String = " AND r.nit =" & nit
        Dim where_centro As String = ""
        Dim sqlOrder As String = ""
        Dim where_turno As String = ""
        dtg_detalle.DataSource = Nothing
        dtg_detalle.DataSource = procesar_marcaciones(fecIni, fecFin, where_centro, where_operario, sqlOrder, where_turno)
        totalizar(dtg_detalle)
        verificarHorasExtrasProgramadas(dtg_detalle)
        For j = 0 To dtg_detalle.Columns.Count - 1
            If (dtg_detalle.Columns(j).Name = "nombres" Or dtg_detalle.Columns(j).Name = "centro" Or dtg_detalle.Columns(j).Name = "contrato" Or dtg_detalle.Columns(j).Name = "oficio" Or dtg_detalle.Columns(j).Name = "planta" Or dtg_detalle.Columns(j).Name = "turno" Or dtg_detalle.Columns(j).Name = "basico_hora" Or dtg_detalle.Columns(j).Name = "basico_mes" Or
                dtg_detalle.Columns(j).Name = "domingo" Or dtg_detalle.Columns(j).Name = "festivo") Then
                dtg_detalle.Columns(j).Visible = False
            ElseIf (dtg_detalle.Columns(j).Name = "Consec" Or dtg_detalle.Columns(j).Name = "nit" Or dtg_detalle.Columns(j).Name = "nombres") Then
                dtg_detalle.Columns(j).DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", tamano_letra)
                If (dtg_detalle.Columns(j).Name = "Consec" Or dtg_detalle.Columns(j).Name = "nit") Then
                    dtg_detalle.Columns(j).Visible = False
                End If
            End If
        Next
        dtg_detalle.Columns("FechaEntrada").DefaultCellStyle.Format = "g"
        dtg_detalle.Columns("FechaSalida").DefaultCellStyle.Format = "g"
        dtg_detalle.Columns("dia").DefaultCellStyle = objOperacionesForm.formatoNegrita(tamano_letra)
    End Sub
    Private Sub detalle_permisos(ByVal nit As Double)
        Dim sql As String = "SELECT n.fecha,horas,n.concepto ,c.descripcion " &
                                "FROM y_novedades  n , y_conceptos_nom c  " &
                                    "WHERE n.concepto IN (34,35,36,37,510,512,511,77,78,90) AND n.concepto = c.concepto AND n.idPeriodo =" & id_periodo & " AND n.nit = " & nit
        dtg_detalle.DataSource = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        dtg_detalle.Columns("fecha").DefaultCellStyle.Format = "d"
    End Sub
    Private Sub detalle_incapacidades(ByVal nit As Double)
        Dim sql As String = "SELECT nit,concepto,fecha_ini_liq,fecha_fin_liq   " &
                                "FROM y_incapacidad " &
                                     "WHERE (fecha_ini_liq >= '" & objOpSimplesLn.cambiarFormatoFecha(dFecIni_periodo) & "' OR fecha_fin_liq >= '" & objOpSimplesLn.cambiarFormatoFecha(dFecFin_periodo) & "' ) AND  nit = " & nit & " "
        dtg_detalle.DataSource = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        dtg_detalle.Columns("fecha_ini_liq").DefaultCellStyle.Format = "d"
        dtg_detalle.Columns("fecha_fin_liq").DefaultCellStyle.Format = "d"
    End Sub
    Private Sub detalle_vacaciones(ByVal nit As Double)
        Dim sql As String = "SELECT nit,fecha_inicial,fecha_final   " &
                                "FROM y_vacaciones " &
                                     "WHERE (fecha_inicial >= '" & objOpSimplesLn.cambiarFormatoFecha(dFecIni_periodo) & "' OR fecha_final >= '" & objOpSimplesLn.cambiarFormatoFecha(dFecFin_periodo) & "') AND  nit = " & nit & " "
        dtg_detalle.DataSource = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        dtg_detalle.Columns("fecha_inicial").DefaultCellStyle.Format = "d"
        dtg_detalle.Columns("fecha_final").DefaultCellStyle.Format = "d"
    End Sub
    Private Sub detalle_suspensiones(ByVal nit As Double)
        Dim sql As String = "SELECT s.nit,s.fecha_inicial,s.fecha_final,s.concepto ,c.descripcion    " &
                                "FROM y_suspensiones s, y_conceptos_nom c   " &
                                     "WHERE s.concepto IN (511,512) AND s.concepto = c.concepto AND (s.fecha_inicial >= '" & objOpSimplesLn.cambiarFormatoFecha(dFecIni_periodo) & "' OR s.fecha_final >= '" & objOpSimplesLn.cambiarFormatoFecha(dFecFin_periodo) & "') AND  s.nit = " & nit & " "
        dtg_detalle.DataSource = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        dtg_detalle.Columns("fecha_inicial").DefaultCellStyle.Format = "d"
        dtg_detalle.Columns("fecha_final").DefaultCellStyle.Format = "d"
    End Sub

    Private Sub detalle_turno_prog(ByVal nit As Double)
        dtg_detalle.DataSource = Nothing
        Dim sql As String = "SELECT e.id As id_enc,e.nit,e.periodo , d.fecha,CAST(d.turno as varchar) + ' - ' + t.Descripcion As turno  " &
                                    "FROM J_prog_turno_enc e , J_prog_turno_det d , CORSAN.dbo.J_turnos t   " &
                                        "WHERE e.id = d.id_enc And t.id = d.turno AND e.nit = " & nit & " AND d.fecha >= '" & objOpSimplesLn.cambiarFormatoFecha(cbo_fecha_ini.Value) & "' AND d.fecha <= '" & objOpSimplesLn.cambiarFormatoFecha(dFecFin_periodo) & "' " &
                                            "ORDER BY e.nit,d.fecha "
        dtg_detalle.DataSource = objOpSimplesLn.listar_datatable(sql, "CONTROL")
        dtg_detalle.Columns("fecha").DefaultCellStyle.Format = "D"
    End Sub

    Private Sub dtg_detalle_DataError(ByVal sender As Object, ByVal e As DataGridViewDataErrorEventArgs) Handles dtg_detalle.DataError

    End Sub

    Private Sub addCompromisos(ByRef dt As DataTable)
        Dim sql As String = "SELECT Nit_trabajador,SUM(Horas)As tot_horas,nocturno " &
                                    "FROM R_compromiso_horas_a_pagar " &
                                            "WHERE activo = 'True' AND horas >0 AND concepto_90 is null and concepto_84 is null " &
                                            "GROUP BY Nit_trabajador,nocturno "
        Dim dt_compromisos As DataTable = objOpSimplesLn.listar_datatable(sql, "CONTROL")
        For i = 0 To dt_compromisos.Rows.Count - 1
            For k = 2 To dt.Rows.Count - 1
                If (dt_compromisos.Rows(i).Item("Nit_trabajador") = dt.Rows(k).Item("nit")) Then
                    If IsNumeric(dt_compromisos.Rows(i).Item("tot_horas")) Then
                        If Not IsDBNull(dt_compromisos.Rows(i).Item("nocturno")) Then
                            If dt_compromisos.Rows(i).Item("nocturno") = "N" Then
                                dt.Rows(k).Item("hDebeD") = dt_compromisos.Rows(i).Item("tot_horas")
                            Else
                                dt.Rows(k).Item("hDebeN") = dt_compromisos.Rows(i).Item("tot_horas")
                            End If
                        Else
                            dt.Rows(k).Item("hDebeD") = dt_compromisos.Rows(i).Item("tot_horas")
                        End If
                    End If
                End If
            Next
        Next
    End Sub
    Private Sub pintar_dtg()
        For i = 0 To dtg_consulta.Rows.Count - 1
            If Not IsDBNull(dtg_consulta.Item("hDebeD", i).Value) Then
                If (dtg_consulta.Item("hDebeD", i).Value > 0) Then
                    dtg_consulta.Item("hDebeD", i).Style.BackColor = Color.Yellow
                    dtg_consulta.Item("nit", i).Style.BackColor = Color.Yellow
                    dtg_consulta.Item("nombres", i).Style.BackColor = Color.Yellow
                    dtg_consulta.Item("hDescD", i).Style.BackColor = Color.Yellow
                End If
            End If
            If Not IsDBNull(dtg_consulta.Item("hDebeN", i).Value) Then
                If (dtg_consulta.Item("hDebeN", i).Value > 0) Then
                    dtg_consulta.Item("hDebeN", i).Style.BackColor = Color.Yellow
                    dtg_consulta.Item("nit", i).Style.BackColor = Color.Yellow
                    dtg_consulta.Item("nombres", i).Style.BackColor = Color.Yellow
                    dtg_consulta.Item("hDescN", i).Style.BackColor = Color.Yellow
                End If
            End If
            If IsNumeric(dtg_consulta.Item("HR", i).Value) Then
                If dtg_consulta.Item("HR", i).Value < horas_marcaciones Then
                    dtg_consulta.Item("HR", i).Style.BackColor = Color.Red
                End If
            End If
        Next
    End Sub
    Private Sub descontar_horas_compromiso()
        Dim col As String = ""
        Dim colDebe As String = ""
        Dim colDesc As String = ""
        For i = 0 To dtg_consulta.Rows.Count - 1
            If IsNumeric(dtg_consulta.Item("hDebeD", i).Value) Then
                col = "ED"
                colDebe = "hDebeD"
                colDesc = "hDescD"
                descontar_horas_debe(col, i, colDebe, colDesc)
            End If
            If IsNumeric(dtg_consulta.Item("hDebeN", i).Value) Then
                col = "EN"
                colDebe = "hDebeN"
                colDesc = "hDescN"
                descontar_horas_debe(col, i, colDebe, colDesc)
            End If
        Next
    End Sub
    Private Sub descontar_horas_debe(ByVal col As String, ByVal fila As Integer, ByVal colDebe As String, ByVal colDesc As String)
        Dim dif As Double = 0
        If IsNumeric(dtg_consulta.Item(col, fila).Value) Then
            If dtg_consulta.Item(colDebe, fila).Value > 0 Then
                If dtg_consulta.Item(col, fila).Value > 0 Then
                    dif = dtg_consulta.Item(col, fila).Value - dtg_consulta.Item(colDebe, fila).Value
                    If dif >= 0 Then
                        dtg_consulta.Item(col, fila).Value -= dtg_consulta.Item(colDebe, fila).Value
                        dtg_consulta.Item(colDesc, fila).Value = dtg_consulta.Item(colDebe, fila).Value
                    Else
                        dtg_consulta.Item(colDesc, fila).Value = dtg_consulta.Item(col, fila).Value
                        dtg_consulta.Item(col, fila).Value = 0
                    End If
                    dtg_consulta.Item(col, fila).Style.BackColor = Color.OrangeRed
                    dtg_consulta.Item(colDebe, fila).Style.BackColor = Color.OrangeRed
                    dtg_consulta.Item(colDesc, fila).Style.BackColor = Color.OrangeRed
                End If
            End If
        End If
    End Sub
    Private Sub descontar_dom_noct_turno_noche()
        Dim dif As Double = 0
        For i = 0 To dtg_consulta.Rows.Count - 1
            If IsNumeric(dtg_consulta.Item("TotOrD", i).Value) Then
                If dtg_consulta.Item("TotOrD", i).Value > horas_totales_periodo Then
                    dif = dtg_consulta.Item("TotOrD", i).Value - horas_totales_periodo
                    If IsNumeric(dtg_consulta.Item("DN", i).Value) Then
                        If IsNumeric(dtg_consulta.Item("OrD", i).Value) Then
                            If dtg_consulta.Item("OrD", i).Value > 0 Then
                                dtg_consulta.Item("OrD", i).Value -= dif
                            End If
                        End If
                    End If
                End If

                'Se quita por que cuando se conslida el domingo en turno de noche solo se pagan las 6 horas de RN
                'If IsNumeric(dtg_consulta.Item("DN", i).Value) Then
                'If IsNumeric(dtg_consulta.Item("RN", i).Value) Then
                'consulta.Item("RN", i).Value -= dtg_consulta.Item("DN", i).Value
                '
                'End If
            End If
        Next

    End Sub
    Private Sub descontar_dom_noct_turno_dia()
        Dim dif As Double = 0
        For i = 0 To dtg_consulta.Rows.Count - 1
            If IsNumeric(dtg_consulta.Item("TotOrD", i).Value) Then
                If dtg_consulta.Item("TotOrD", i).Value > horas_totales_periodo Then
                    dif = dtg_consulta.Item("TotOrD", i).Value - horas_totales_periodo
                    If IsNumeric(dtg_consulta.Item("DD", i).Value) Then
                        If IsNumeric(dtg_consulta.Item("DD", i).Value) Then
                            If dtg_consulta.Item("OrD", i).Value > 0 Then
                                dtg_consulta.Item("OrD", i).Value -= dif
                            End If
                        End If
                    End If
                End If
            End If
        Next
    End Sub


    Private Sub cbo_periodo_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbo_periodo.SelectedIndexChanged
        If (carga_comp) Then
            If (cbo_periodo.SelectedValue <> 0) Then
                dtg_consulta.DataSource = Nothing
                dtg_valores.DataSource = Nothing
                chk_consol_centros.Checked = False
                id_periodo = cbo_periodo.SelectedValue

                dFecIni_periodo = objOpSimplesLn.consultarVal("SELECT fecha_inicial FROM y_periodos_control WHERe idPeriodo = " & cbo_periodo.SelectedValue)
                dFecFin_periodo = objOpSimplesLn.consultarVal("SELECT fecha_final FROM y_periodos_control WHERe idPeriodo = " & cbo_periodo.SelectedValue)
                Dim sql_periodo As String = "SELECT fecha_inicial,fecha_final,periodo,mes,ano FROM y_periodos_control WHERe idPeriodo = " & cbo_periodo.SelectedValue
                Dim dt_periodo As DataTable = objOpSimplesLn.listar_datatable(sql_periodo, "CORSAN")
                For i = 0 To dt_periodo.Rows.Count - 1
                    dFecIni_periodo = dt_periodo.Rows(i).Item("fecha_inicial")
                    dFecFin_periodo = dt_periodo.Rows(i).Item("fecha_final")
                    mes = dt_periodo.Rows(i).Item("mes")
                    ano = dt_periodo.Rows(i).Item("ano")
                Next
                Dim horas_festivas As Double = objOpSimplesLn.cant_festivos_rango_dias(dFecIni_periodo.Month, dFecIni_periodo.Year, dFecIni_periodo.Day, dFecFin_periodo.Day)
                Dim sql_j_periodo_nomina As String = "SELECT fecha_ini,fecha_fin FROM J_periodos_nomina WHERE id_periodo =" & id_periodo
                Dim dt_j_periodo_nomina As DataTable = objOpSimplesLn.listar_datatable(sql_j_periodo_nomina, "CORSAN")
                horas_festivas *= 8

                horas_totales_periodo = DateDiff(DateInterval.Day, dFecIni_periodo, dFecFin_periodo) * 8
                horas_totales_periodo += 8 'Se hace esto para que coja los 10 días de la decada en la diferencia
                horas_laborales = (objOpSimplesLn.calcDiasHabilesProduccion(dFecIni_periodo, dFecFin_periodo) * 8)
                lbl_horas_laborales.Text = horas_laborales - horas_festivas
                lbl_tot_horas.Text = horas_totales_periodo
                horas_laborales = horas_laborales - horas_festivas

                For i = 0 To dt_j_periodo_nomina.Rows.Count - 1
                    If (cbo_fecha_ini.MinDate > dt_j_periodo_nomina.Rows(i).Item("fecha_ini")) Then
                        cbo_fecha_ini.MinDate = dt_j_periodo_nomina.Rows(i).Item("fecha_ini")
                        cbo_fecha_ini.MaxDate = dt_j_periodo_nomina.Rows(i).Item("fecha_fin")
                        cbo_fecha_fin.MinDate = dt_j_periodo_nomina.Rows(i).Item("fecha_ini")
                        cbo_fecha_fin.MaxDate = dt_j_periodo_nomina.Rows(i).Item("fecha_fin")
                    Else
                        cbo_fecha_ini.MaxDate = dt_j_periodo_nomina.Rows(i).Item("fecha_fin")
                        cbo_fecha_ini.MinDate = dt_j_periodo_nomina.Rows(i).Item("fecha_ini")
                        cbo_fecha_fin.MaxDate = dt_j_periodo_nomina.Rows(i).Item("fecha_fin")
                        cbo_fecha_fin.MinDate = dt_j_periodo_nomina.Rows(i).Item("fecha_ini")
                    End If
                    cbo_fecha_ini.Value = dt_j_periodo_nomina.Rows(i).Item("fecha_ini")
                    cbo_fecha_fin.Value = dt_j_periodo_nomina.Rows(i).Item("fecha_fin")
                    If Now.Date.AddDays(-1) <= dt_j_periodo_nomina.Rows(i).Item("fecha_fin") And Now.Date.AddDays(-1) >= dt_j_periodo_nomina.Rows(i).Item("fecha_ini") Then
                        cbo_fecha_fin.Value = Now.Date.AddDays(-1)
                    End If
                    Dim horas_festivas_marcaciones As Double = objOpSimplesLn.cant_festivos_rango_dias_d(cbo_fecha_ini.Value.Month, cbo_fecha_fin.Value.Month, cbo_fecha_ini.Value.Year, cbo_fecha_ini.Value.Day, cbo_fecha_fin.Value.Day)
                    horas_festivas_marcaciones *= 8
                    horas_marcaciones = (objOpSimplesLn.calcDiasHabilesProduccion(cbo_fecha_ini.Value, cbo_fecha_fin.Value) * 8)
                    horas_marcaciones = horas_marcaciones - horas_festivas_marcaciones
                    lbl_horas_marcacion.Text = horas_marcaciones
                Next
                If dt_j_periodo_nomina.Rows.Count = 0 Then
                    MessageBox.Show("No se encontro ningún corte de novedades creado para este periodo de nómina, comuniquese con el area de recursos humanos.", "Sin periodo de corte de novedades creado", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    carga_comp = False
                    cbo_periodo.SelectedValue = 0
                    carga_comp = True
                Else
                    Dim nomb_sin_turno As String = objRelojLn.verificar_empleados_sin_turno(centros, id_periodo)
                    If nomb_sin_turno <> "" Then
                        MessageBox.Show("Los siguientes empleados estan sin turno programado por lo tanto no se le liquidaran noveades: " & vbCrLf & vbCrLf & nomb_sin_turno, "Empleados sin turno", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End If
                cboCal.SelectionRange.Start = cbo_fecha_ini.Value
                cboCal.SelectionRange.End = cbo_fecha_fin.Value
                If objRelojLn.verificar_periodo_liquidado(id_periodo) Then
                    MessageBox.Show("Este periodo se encuentra liquidado, por lo tanto no se permite hacer cambios en turnos ni ingresar novedades", "Periodo liquidado", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    periodo_liquidado = True
                    bloquear_modificar_valores(False)
                Else
                    periodo_liquidado = False
                    bloquear_modificar_valores(True)
                End If
            End If
        End If
    End Sub

    Private Sub cbo_centro_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbo_centro.SelectedIndexChanged
        If carga_comp Then
            carga_comp = False
            cargar_operarios(cbo_centro.SelectedValue)
            carga_comp = True
        End If
    End Sub
    Private Sub cargar_operarios(ByVal centro As Integer)
        Dim sql As String
        Dim dt As DataTable
        Dim row As DataRow
        Dim whereCentro As String = "WHERE"
        If centro = 0 Then
            whereCentro &= " centro IN(1200,2100,2117,2200,2300,2400,2500,2600,2800,3100,3200,3500,5200,6200,6400, 4200,4100,4300)"
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
    Private Sub totalizar(ByRef dtg As DataGridView)
        Dim tamano_letra As Single = 9.0!
        Dim sum As Double = 0
        For j = 0 To dtg.Columns.Count - 1
            If (dtg.Columns(j).Name = "hDebeD" Or dtg.Columns(j).Name = "hDebeN" Or dtg.Columns(j).Name = "hDescD" Or dtg.Columns(j).Name = "hDescN" Or dtg.Columns(j).Name = "total" Or dtg.Columns(j).Name = "OrD" Or dtg.Columns(j).Name = "RN" Or dtg.Columns(j).Name = "DD" Or
                    dtg.Columns(j).Name = "DN" Or dtg.Columns(j).Name = "DF" Or dtg.Columns(j).Name = "ED" Or dtg.Columns(j).Name = "EN" _
                         Or dtg.Columns(j).Name = "EDF" Or dtg.Columns(j).Name = "ENF" Or dtg.Columns(j).Name = "DComp" Or dtg.Columns(j).Name = "TotOrD" _
                          Or dtg.Columns(j).Name = "PR" Or dtg.Columns(j).Name = "PRH" Or dtg.Columns(j).Name = "PV" Or dtg.Columns(j).Name = "PD" Or dtg.Columns(j).Name = "PE" Or dtg.Columns(j).Name = "PC" _
                           Or dtg.Columns(j).Name = "PN" Or dtg.Columns(j).Name = "HL" Or dtg.Columns(j).Name = "IR" Or dtg.Columns(j).Name = "IA" Or dtg.Columns(j).Name = "LM" Or
                           dtg.Columns(j).Name = "V" Or dtg.Columns(j).Name = "DS" Or dtg.Columns(j).Name = "SU" Or dtg.Columns(j).Name = "BON") Then
                For i = 0 To dtg.Rows.Count - 1
                    If Not IsDBNull(dtg.Item(j, i).Value) And Not IsDBNull(dtg.Item("nit", i).Value) Then
                        sum += dtg.Item(j, i).Value
                    End If
                Next
                dtg.Item(j, dtg.Rows.Count - 1).Value = sum
                sum = 0
            ElseIf (dtg.Columns(j).Name = "domingo" Or dtg.Columns(j).Name = "festivo") Then
                For i = 0 To dtg.Rows.Count - 2
                    If (dtg.Item(j, i).Value = "True") Then
                        dtg.Item("dia", i).Style.BackColor = Color.MediumAquamarine
                        dtg.Item("fechaEntrada", i).Style.BackColor = Color.MediumAquamarine
                        dtg.Item("fechaSalida", i).Style.BackColor = Color.MediumAquamarine
                    End If
                Next
            ElseIf (dtg.Columns(j).Name = "debe") Then
                For i = 0 To dtg.Rows.Count - 1
                    If Not IsDBNull(dtg.Item("debe", i).Value) Then
                        dtg.Item("nombres", i).Style.BackColor = Color.Yellow
                    End If
                Next
            End If
            dtg.Columns(j).SortMode = DataGridViewColumnSortMode.NotSortable
        Next
        dtg.Rows(dtg.Rows.Count - 1).DefaultCellStyle = objOperacionesForm.formatoNegrita(tamano_letra)
        dtg.Rows(dtg.Rows.Count - 1).DefaultCellStyle.Format = "N0"
    End Sub
    Private Function verificar_horas_ordinarias_totales() As Boolean
        Dim resp As Boolean = True
        For i = 0 To dtg_consulta.Rows.Count - 2
            If IsNumeric(dtg_consulta.Item("TotOrD", i).Value) Then
                If dtg_consulta.Item("TotOrD", i).Value <> horas_totales_periodo Then
                    dtg_consulta.Item("TotOrD", i).Style.BackColor = Color.Peru
                    resp = False
                End If
            End If
        Next
        Return resp
    End Function
    Private Sub btn_guardar_liq_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_guardar_liq.Click
        If chk_temporales.Checked = False Then
            If dtg_consulta.Rows.Count > 0 Then
                Dim iResponce = MessageBox.Show("Esta seguro que desea exportar las novedades a Dms?", "Atención", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                If (iResponce = 6) Then
                    progBar.Visible = True
                    If verificar_horas_ordinarias_totales() Then
                        gestionar_nits_sin_turno_reloj()
                        gestionar_nits_en_vacaciones()
                    Else
                        MessageBox.Show("Empleados con horas ordinarias , menores al total de tiempo de la decada, corrijalos e intentelo de nuevo (Campo 'TotOrd' marcado con verde).", "Verifique horas ordinarias", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                    guarar_liq()
                    progBar.Visible = False
                End If
            Else
                MessageBox.Show("No se encontraron datos consolidades, verifique la consulta", "No se encontraron datos consolidados", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub
    Private Sub gestionar_nits_en_vacaciones()
        Dim nits_vacaciones As String = getNits_con_vacaciones()
        If nits_vacaciones <> "" Then
            Dim dt_nits_vacaciones As DataTable = objRelojLn.get_dt_contrato_sin_turno_de_dms(nits_vacaciones)
            If dt_nits_vacaciones.Rows.Count > 0 Then
                Dim nom_sin_turno_dms As String = ""
                Dim nit_sin_turno_dms As String = ""
                For i = 0 To dt_nits_vacaciones.Rows.Count - 1
                    nom_sin_turno_dms &= "- " & dt_nits_vacaciones.Rows(i).Item("nombres") & vbCrLf
                    nit_sin_turno_dms &= dt_nits_vacaciones.Rows(i).Item("nit")
                    If i < dt_nits_vacaciones.Rows.Count - 1 Then
                        nit_sin_turno_dms &= ","
                    End If
                Next
                Dim respuesta_update_turnos = MessageBox.Show("Los siguientes empleados se encuentran con vacaciones y sin turno de DMS '2', desea reemplazar el turno?" & vbCrLf & nom_sin_turno_dms, "Colocar turno '2' a los contratos?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                If (respuesta_update_turnos = 6) Then
                    If (objRelojLn.update_contrato_turno_dms(nit_sin_turno_dms)) Then
                        MessageBox.Show("Los turnos en los contratos se modificaron en forma exitosa,se continuara con el ingreso de novedades a Dms", "Turnos modificados", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("Error al modificar, los turnos, comuniquese con el adminstrador del sistema.", "Error al moficiar turnos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End If
            End If
        End If
    End Sub
    Private Sub gestionar_nits_sin_turno_reloj()
        Dim nits As String = getNits()
        Dim dt_contrato_sin_turno_de_reloj As DataTable = objRelojLn.get_dt_contrato_sin_turno_de_reloj(nits)
        If dt_contrato_sin_turno_de_reloj.Rows.Count > 0 Then
            Dim nom_sin_turno_reloj As String = ""
            Dim nit_sin_turno_reloj As String = ""
            For i = 0 To dt_contrato_sin_turno_de_reloj.Rows.Count - 1
                nom_sin_turno_reloj &= "- " & dt_contrato_sin_turno_de_reloj.Rows(i).Item("nombres") & vbCrLf
                nit_sin_turno_reloj &= dt_contrato_sin_turno_de_reloj.Rows(i).Item("nit")
                If i < dt_contrato_sin_turno_de_reloj.Rows.Count - 1 Then
                    nit_sin_turno_reloj &= ","
                End If
            Next
            Dim respuesta_update_turnos = MessageBox.Show("Los siguientes empleados no tienen el turno del reloj '9', desea reemplazar el turno?" & vbCrLf & nom_sin_turno_reloj, "Colocar turno '9' a los contratos?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
            If (respuesta_update_turnos = 6) Then
                If (objRelojLn.update_contrato_turno_de_reloj(nit_sin_turno_reloj)) Then
                    MessageBox.Show("Los turnos en los contratos se modificaron en forma exitosa,se continuara con el ingreso de novedades a Dms", "Turnos modificados", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Error al modificar, los turnos, comuniquese con el adminstrador del sistema.", "Error al moficiar turnos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
        End If
    End Sub
    Private Function getNits() As String
        Dim nits As String = ""
        For i = 0 To dtg_consulta.Rows.Count - 1
            If Not IsDBNull(dtg_consulta.Item("nit", i).Value) Then
                nits &= dtg_consulta.Item("nit", i).Value
                If i <> dtg_consulta.Rows.Count - 2 Then
                    nits &= ","
                End If
            End If
        Next
        Return nits
    End Function
    Private Function getNits_con_vacaciones() As String
        Dim nits As String = ""
        For i = 0 To dtg_consulta.Rows.Count - 1
            If IsNumeric(dtg_consulta.Item("V", i).Value) Then
                If IsNumeric(dtg_consulta.Item("nit", i).Value) Then
                    If nits <> "" Then
                        nits &= ","
                    End If
                    nits &= dtg_consulta.Item("nit", i).Value
                End If
            End If
        Next
        Return nits
    End Function
    Private Function validar_fk_novedades()
        lbl_estado.Text = "VALIDANDO y_novedades..."
        Application.DoEvents()
        Dim resp As Boolean = True
        Dim nit As Double = 0
        Dim sql As String = ""
        Dim concepto As Integer = 0
        If (dtg_consulta.Rows.Count - 1 <> -1) Then
            progBar.Maximum = dtg_consulta.Rows.Count - 1
            progBar.Minimum = 0
        End If
        For i = 1 To dtg_consulta.Rows.Count - 2
            progBar.PerformStep()
            progBar.Refresh()
            If IsNumeric(dtg_consulta.Item("nit", i).Value) Then
                nit = dtg_consulta.Item("nit", i).Value
                For j = 0 To dtg_consulta.Columns.Count - 1
                    If (dtg_consulta.Columns(j).Name = "OrD" Or dtg_consulta.Columns(j).Name = "RN" Or dtg_consulta.Columns(j).Name = "DD" Or dtg_consulta.Columns(j).Name = "DN" _
                           Or dtg_consulta.Columns(j).Name = "DF" Or dtg_consulta.Columns(j).Name = "ED" Or dtg_consulta.Columns(j).Name = "EN" Or dtg_consulta.Columns(j).Name = "EDF" _
                           Or dtg_consulta.Columns(j).Name = "ENF" Or dtg_consulta.Columns(j).Name = "DComp") Then
                        If IsNumeric(dtg_consulta.Item(j, i).Value) Then
                            If (dtg_consulta.Item(j, i).Value) > 0 Then
                                concepto = dtg_consulta.Item(j, 0).Value
                                sql = "SELECT nit FROM y_novedades WHERE nit = " & nit & " AND idperiodo = " & id_periodo & " AND concepto = " & concepto
                                If (objOpSimplesLn.consultarVal(sql) <> "") Then
                                    resp = False
                                    j = dtg_consulta.Columns.Count - 1
                                    i = dtg_consulta.Rows.Count - 1
                                    MessageBox.Show("El nit = " & nit & ", periodo = " & id_periodo & "  , concepto = '" & concepto & "' ya se encuentra ingresado a DMS, verifique e intente exportar las novedades nuevamente. ", "Novedad duplicada", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                End If
                            End If
                        End If
                    End If
                Next
            End If
        Next
        progBar.Value = 0
        lbl_estado.Text = ""
        Return resp
    End Function
    Private Sub guarar_liq()
        If Not objRelojLn.verificar_periodo_liquidado(id_periodo) Then
            '  If validar_fk_novedades() Then
            lbl_estado.Text = "SUBIENDO NOVEDADES A DMS..."
            Application.DoEvents()
            Dim listSql As New List(Of Object)
            Dim list_compromisos As New List(Of Object)
            Dim sql_gral As String = ""
            Dim sql As String = ""
            Dim nomina As Integer = 1
            Dim contrato As Double = 0
            Dim nit As Double = 0
            Dim concepto As Double = 0
            Dim fecha As String = ""
            Dim mes As Integer = objOpSimplesLn.consultarVal("SELECT mes FROM y_periodos_control WHERE idPeriodo = " & id_periodo)
            Dim ano As Integer = objOpSimplesLn.consultarVal("SELECT ano FROM y_periodos_control WHERE idPeriodo = " & id_periodo)
            Dim periodo As Integer = objOpSimplesLn.consultarVal("SELECT periodo FROM y_periodos_control WHERE idPeriodo = " & id_periodo)
            Dim valor As Integer = 0
            Dim horas As Double = 0
            Dim dias As Double = 0
            Dim centro As Integer = 0
            Dim planta As Integer = 0
            Dim turno As Integer = 0 'NO UTILIZAR HASTA NO DEFINIR 
            Dim nro_presta As Integer = 0
            Dim oficio As Integer = 0
            Dim sumar As Integer = 0 'NO UTILIZAR HASTA NO DEFINIR CUANDO ES 1 Y 0
            Dim comp_nocturno As Boolean = False
            Dim ingreso_ordinario As Boolean = True
            sql_gral = "INSERT INTO y_novedades " &
                                        "(nomina,contrato,nit,idperiodo,concepto,fecha,mes,ano,periodo,valor,horas,dias,centro,planta,turno,nro_presta,sumar,oficio) " &
                                        "VALUES "
            If (dtg_consulta.Rows.Count - 1 <> -1) Then
                progBar.Maximum = dtg_consulta.Rows.Count - 1
                progBar.Minimum = 0
            End If

            For i = 1 To dtg_consulta.Rows.Count - 2
                progBar.PerformStep()
                progBar.Refresh()
                If Not IsDBNull(dtg_consulta.Item("nit", i).Value) Then
                    contrato = dtg_consulta.Item("contrato", i).Value
                    nit = dtg_consulta.Item("nit", i).Value
                    fecha = objOpSimplesLn.cambiarFormatoFecha(Now)
                    centro = dtg_consulta.Item("centro", i).Value
                    oficio = dtg_consulta.Item("oficio", i).Value
                    planta = dtg_consulta.Item("planta", i).Value
                    turno = dtg_consulta.Item("turno", i).Value
                    'Si esta en vacaciones no se le inrgesa tiempo ordinario para que DMS lo calcule
                    If IsNumeric(dtg_consulta.Item("V", i).Value) Then
                        If dtg_consulta.Item("V", i).Value > 0 Then
                            ingreso_ordinario = False
                        End If
                    End If
                    For j = 0 To dtg_consulta.Columns.Count - 1
                        If (dtg_consulta.Columns(j).Name = "OrD" Or dtg_consulta.Columns(j).Name = "RN" Or dtg_consulta.Columns(j).Name = "DD" Or dtg_consulta.Columns(j).Name = "DN" _
                            Or dtg_consulta.Columns(j).Name = "DF" Or dtg_consulta.Columns(j).Name = "ED" Or dtg_consulta.Columns(j).Name = "EN" Or dtg_consulta.Columns(j).Name = "EDF" _
                            Or dtg_consulta.Columns(j).Name = "ENF" Or dtg_consulta.Columns(j).Name = "DComp") Then

                            If (dtg_consulta.Columns(j).Name = "OrD" Or dtg_consulta.Columns(j).Name = "DD" Or dtg_consulta.Columns(j).Name = "DN" _
                                Or dtg_consulta.Columns(j).Name = "DF") Then
                                If ingreso_ordinario Then
                                    If IsNumeric(dtg_consulta.Item(j, i).Value) Then
                                        If (dtg_consulta.Item(j, i).Value > 0) Then
                                            concepto = dtg_consulta.Item(j, 0).Value
                                            horas = dtg_consulta.Item(j, i).Value
                                            dias = horas / 8
                                            If objRelojLn.validar_fk_novedad(nit, concepto, id_periodo) Then
                                                sql = sql_gral & "(" & nomina & "," & contrato & "," & nit & "," & id_periodo & "," & concepto & ",'" & fecha & "'," & mes & "," & ano & "," & periodo & "," & valor & "," & horas & "," & dias & "," & centro & "," & planta & "," & turno & "," & nro_presta & "," & sumar & "," & oficio & ")"
                                            Else
                                                sql = "UPDATE y_novedades " &
                                                                               " SET valor +=  " & valor & " ,horas += " & horas & ",dias += " & dias & " " &
                                                                                    "WHERE nit = " & nit & " AND idperiodo = " & id_periodo & " AND concepto = " & concepto
                                            End If
                                            listSql.Add(sql)
                                        End If
                                    End If
                                End If
                            End If
                            If (dtg_consulta.Columns(j).Name = "RN" Or dtg_consulta.Columns(j).Name = "ED" Or dtg_consulta.Columns(j).Name = "EN" Or dtg_consulta.Columns(j).Name = "EDF" _
                                  Or dtg_consulta.Columns(j).Name = "ENF" Or dtg_consulta.Columns(j).Name = "DComp") Then
                                If IsNumeric(dtg_consulta.Item(j, i).Value) Then
                                    If (dtg_consulta.Item(j, i).Value > 0) Then
                                        concepto = dtg_consulta.Item(j, 0).Value
                                        horas = dtg_consulta.Item(j, i).Value
                                        dias = horas / 8
                                        If objRelojLn.validar_fk_novedad(nit, concepto, id_periodo) Then
                                            sql = sql_gral & "(" & nomina & "," & contrato & "," & nit & "," & id_periodo & "," & concepto & ",'" & fecha & "'," & mes & "," & ano & "," & periodo & "," & valor & "," & horas & "," & dias & "," & centro & "," & planta & "," & turno & "," & nro_presta & "," & sumar & "," & oficio & ")"
                                        Else
                                            sql = "UPDATE y_novedades " &
                                                                           " SET valor +=  " & valor & " ,horas += " & horas & ",dias += " & dias & " " &
                                                                                "WHERE nit = " & nit & " AND idperiodo = " & id_periodo & " AND concepto = " & concepto
                                        End If
                                        listSql.Add(sql)
                                    End If
                                End If
                            End If
                        ElseIf (dtg_consulta.Columns(j).Name = "hDescD" Or dtg_consulta.Columns(j).Name = "hDescN") Then
                            If dtg_consulta.Columns(j).Name = "hDescD" Then
                                If IsNumeric(dtg_consulta.Item("hDescD", i).Value) Then
                                    comp_nocturno = False
                                    If (dtg_consulta.Item("hDescD", i).Value > 0) Then
                                        list_compromisos.AddRange(objRelojLn.sql_descontar_horas_compromiso(dtg_consulta.Item("nit", i).Value, dtg_consulta.Item("hDescD", i).Value, comp_nocturno))
                                    End If
                                End If
                            End If
                            If dtg_consulta.Columns(j).Name = "hDescN" Then
                                If IsNumeric(dtg_consulta.Item("hDescN", i).Value) Then
                                    comp_nocturno = True
                                    If (dtg_consulta.Item("hDescN", i).Value > 0) Then
                                        list_compromisos.AddRange(objRelojLn.sql_descontar_horas_compromiso(dtg_consulta.Item("nit", i).Value, dtg_consulta.Item("hDescN", i).Value, comp_nocturno))
                                    End If
                                End If
                            End If
                        End If
                    Next
                End If
                ingreso_ordinario = True
            Next
            If (listSql.Count > 0) Then
                listSql.Add(objRelojLn.get_sql_cerrar_j_periodos_nomina(id_periodo))
            End If
            If (objOpSimplesLn.ExecuteSqlTransactionTodo(list_compromisos, "CONTROL")) Then
                MessageBox.Show("Compromisos descontados en forma correcta!", "Correcto!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                If (objOpSimplesLn.ExecuteSqlTransactionTodo(listSql, "CORSAN")) Then
                    MessageBox.Show("Las nómina se exporto a DMS en forma correcta!", "Correcto!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    progBar.Value = 0
                    lbl_estado.Text = ""
                    periodo_liquidado = True
                    bloquear_modificar_valores(True)
                Else
                    MessageBox.Show("Error al ingresar a DMS, comuniquese con el administrador del sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                MessageBox.Show("Error al descontar los compromisos, comuniquese con el administrador del sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            '   End If
        Else
            MessageBox.Show("El periodo ya se encuentra liquidado.", "Periodo ya esta liquidado!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

    End Sub
    Private Sub subir_tiempo_ordinarioo()

    End Sub
    Private Function addTurno(ByRef dt As DataTable, ByVal fila As Integer) As DataTable
        'Se ordena por id_turno para que cuando sea compensatorio quede primero el turno 99 y se peuda manejar el compensatorio
        Dim sql As String = ""
        Dim valor As String = ""
        If Not IsDBNull(dt.Rows(fila).Item("nit")) Then
            sql = "DECLARE @valores VARCHAR(MAX) " &
                    "SELECT @valores = COALESCE( @valores , + CAST(id_turno As varchar) + '') + ' - '+ turno + ' & '    FROM J_v_operario_fecha_turno WHERE nit = " & dt.Rows(fila).Item("nit") & " AND fecha = '" & objOpSimplesLn.cambiarFormatoFecha(dt.Rows(fila).Item("fechaEntrada")) & " ' ORDER BY id_turno desc " &
                    "SELECT @valores as valores"
            valor = objOpSimplesLn.consultValorTodo(sql, "CONTROL")
            dt.Rows(fila).Item("turnoProg") = valor
        End If
        Return dt
    End Function
    Private Sub verificarHorasExtrasProgramadas(ByRef dtg As DataGridView)
        lbl_estado.Text = "VERIFICANDO HORAS EXTRAS PROGRAMADAS..."
        Application.DoEvents()
        Dim horas_prog As Double = 0
        Dim turno As Integer = 0
        Dim turnos_ok As Boolean = True
        progBar.Visible = True
        If (dtg.Rows.Count <> -1) Then
            progBar.Maximum = dtg.Rows.Count - 1
            progBar.Minimum = 0
        End If
        For i = 0 To dtg.Rows.Count - 2
            progBar.PerformStep()
            progBar.Refresh()
            Dim dia_compensatorio As Boolean = objRelojLn.consultar_dia_compensatorio(dtg.Item("nit", i).Value, dtg.Item("FechaEntrada", i).Value)
            If IsNumeric(dtg.Item("ED", i).Value) Then
                If IsNumeric(dtg.Item("ExtP", i).Value) Then
                    horas_prog = dtg.Item("ExtP", i).Value
                    If (dtg.Item("ED", i).Value > horas_prog) Then
                        dtg.Item("ED", i).Style.BackColor = Color.Red
                        If (horas_prog > 0) Then
                            dtg.Item("ExtP", i).Style.BackColor = Color.GreenYellow
                        End If
                    Else
                        dtg.Item("ED", i).Style.BackColor = Color.GreenYellow
                    End If
                End If
                horas_prog = 0
            End If
            If IsNumeric(dtg.Item("EN", i).Value) Then
                If IsNumeric(dtg.Item("ExtP", i).Value) Then
                    horas_prog = dtg.Item("ExtP", i).Value
                    If (dtg.Item("EN", i).Value > horas_prog) Then
                        dtg.Item("EN", i).Style.BackColor = Color.Red
                        If (horas_prog > 0) Then
                            dtg.Item("ExtP", i).Style.BackColor = Color.GreenYellow
                        End If
                    Else
                        dtg.Item("EN", i).Style.BackColor = Color.GreenYellow
                    End If
                End If
                horas_prog = 0
            End If
            If IsNumeric(dtg.Item("EDF", i).Value) Then
                If Not dia_compensatorio Then
                    If IsNumeric(dtg.Item("OrdP", i).Value) Then
                        horas_prog = dtg.Item("OrdP", i).Value
                    End If
                End If
                If IsNumeric(dtg.Item("ExtP", i).Value) Then
                    horas_prog += dtg.Item("ExtP", i).Value
                End If
                If (dtg.Item("EDF", i).Value > horas_prog) Then
                    dtg.Item("EDF", i).Style.BackColor = Color.Red
                    If (horas_prog > 0) Then
                        dtg.Item("ExtP", i).Style.BackColor = Color.GreenYellow
                    End If
                Else
                    dtg.Item("EDF", i).Style.BackColor = Color.GreenYellow
                End If
                horas_prog = 0
            End If
            If IsNumeric(dtg.Item("ENF", i).Value) Then
                If Not dia_compensatorio Then
                    If IsNumeric(dtg.Item("OrdP", i).Value) Then
                        horas_prog = dtg.Item("OrdP", i).Value
                    End If
                End If
                If IsNumeric(dtg.Item("ExtP", i).Value) Then
                    horas_prog += dtg.Item("ExtP", i).Value
                End If
                If (dtg.Item("ENF", i).Value > horas_prog) Then
                    dtg.Item("ENF", i).Style.BackColor = Color.Red
                    If (horas_prog > 0) Then
                        dtg.Item("ExtP", i).Style.BackColor = Color.GreenYellow
                    End If
                Else
                    dtg.Item("ENF", i).Style.BackColor = Color.GreenYellow
                End If
                horas_prog = 0
            End If
            If Not IsDBNull(dtg.Item("turnoProg", i).Value) Then
                turno = getPrimerIdTurno(dtg.Item("turnoProg", i).Value)
                If Convert.ToDateTime(dtg.Item("FechaEntrada", i).Value).Hour >= 4 And Convert.ToDateTime(dtg.Item("FechaEntrada", i).Value).Hour < 17 Then
                    If turno = 3 Or turno = 9 Or turno = 11 Or turno = 13 Or turno = 15 Or turno = 19 Or turno = 20 And turno = 21 Then
                        dtg.Item("turnoProg", i).Style.BackColor = Color.Blue
                        dtg.Item("turnoProg", i).Style.ForeColor = Color.White
                        dtg.Item("FechaEntrada", i).Style.BackColor = Color.Blue
                        dtg.Item("FechaEntrada", i).Style.ForeColor = Color.White
                        dtg.Item("FechaSalida", i).Style.BackColor = Color.Blue
                        dtg.Item("FechaSalida", i).Style.ForeColor = Color.White
                        turnos_ok = False
                    ElseIf (dtg.Item("turnoProg", i).Style.BackColor = Color.Blue) Then
                        dtg.Item("turnoProg", i).Style.BackColor = Color.GreenYellow
                        dtg.Item("turnoProg", i).Style.ForeColor = Color.Black
                        dtg.Item("FechaEntrada", i).Style.BackColor = Color.GreenYellow
                        dtg.Item("FechaEntrada", i).Style.ForeColor = Color.Black
                        dtg.Item("FechaSalida", i).Style.BackColor = Color.GreenYellow
                        dtg.Item("FechaSalida", i).Style.ForeColor = Color.Black
                    End If
                Else
                    If turno <> 3 And turno <> 9 And turno <> 11 And turno <> 13 And turno <> 15 And turno <> 19 And turno <> 99 And turno <> 16 And turno <> 20 And turno <> 21 Then
                        dtg.Item("turnoProg", i).Style.BackColor = Color.Blue
                        dtg.Item("turnoProg", i).Style.ForeColor = Color.White
                        dtg.Item("FechaEntrada", i).Style.BackColor = Color.Blue
                        dtg.Item("FechaEntrada", i).Style.ForeColor = Color.White
                        dtg.Item("FechaSalida", i).Style.BackColor = Color.Blue
                        dtg.Item("FechaSalida", i).Style.ForeColor = Color.White
                        turnos_ok = False
                    ElseIf (dtg.Item("turnoProg", i).Style.BackColor = Color.Blue) Then
                        dtg.Item("turnoProg", i).Style.BackColor = Color.GreenYellow
                        dtg.Item("turnoProg", i).Style.ForeColor = Color.Black
                        dtg.Item("FechaEntrada", i).Style.BackColor = Color.GreenYellow
                        dtg.Item("FechaEntrada", i).Style.ForeColor = Color.Black
                        dtg.Item("FechaSalida", i).Style.BackColor = Color.GreenYellow
                        dtg.Item("FechaSalida", i).Style.ForeColor = Color.Black
                    End If
                End If
                If IsNumeric(dtg.Item("total", i).Value) Then
                    If dtg.Item("total", i).Value < 8 Then
                        dtg.Item("total", i).Style.BackColor = Color.Purple
                        dtg.Item("total", i).Style.ForeColor = Color.White
                    End If
                End If
            End If
        Next
        If turnos_ok = False Then
            MessageBox.Show("Se encontraron marcaciones que no corresponden al turno programado,corrijalas programando el turno correspondiente a la marcación." & vbCrLf & vbCrLf &
                                        "cajones azules con letras blancas.", "Verifique maraciones azules", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        progBar.Value = 0
        progBar.Visible = False
        lbl_estado.Text = ""
    End Sub

    Private Sub btn_consol_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_consol.Click
        progBar.Visible = True
        dtg_valores.DataSource = Nothing
        procesar_consolidar()
        estado_consolidado = True
        lbl_estado.Text = ""
        bloquear_modificar_valores(False)
        AsignarTurnoToolStripMenuItem.Enabled = False
        EliminarMarcacionToolStripMenuItem.Enabled = False
        progBar.Visible = False
    End Sub

    Private Sub dtg_novedad_CellClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dtg_novedad.CellClick
        If e.RowIndex >= 0 Then
            Dim sql As String
            Dim idNovedad As Double = dtg_novedad.Item("idnovedad", e.RowIndex).Value
            Dim nit As Double = dtg_novedad.Item("nit", e.RowIndex).Value
            Dim concepto As Double = dtg_novedad.Item("concepto", e.RowIndex).Value
            Dim hora As Integer = dtg_novedad.Item("horas", e.RowIndex).Value
            If (dtg_novedad.Columns(e.ColumnIndex).Name = col_aut_novedad.Name) Then
                ' If objRelojLn.validar_fk_novedad(nit, concepto, id_periodo) Then
                Dim notas As String = InputBox("Ingrese motivo de autorización de novedad.", "Ingrese motivo")
                If notas <> "" Then
                    If (objRelojLn.aut_novedad_dms(idNovedad, notas)) Then
                        MessageBox.Show("La novedad se ingreso a DMS en forma correcta", "correcto", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        cargar_novedades_no_aut()
                    Else
                        MessageBox.Show("Error al ingresar la novedad,comuniquese con el administrador del sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Else
                    MessageBox.Show("Se debe Ingrese motivo autorización de novedad", "Ingrese motivo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            ElseIf (dtg_novedad.Columns(e.ColumnIndex).Name = col_no_aut_novedad.Name) Then
                Dim notas As String = InputBox("Ingrese motivo de rechazo de novedad.", "Ingrese motivo")
                If notas <> "" Then
                    If objOpSimplesLn.ejecutar(objRelojLn.autorizar_novedad_sql(idNovedad, "R", notas), "CORSAN") Then

                        Dim calc, calc_n As Integer
                        If concepto = 90 Then
                            sql = "select horas_restante from R_compromiso_horas_concepto_90 WHERE nit_trabajador=" & nit & " AND año=" & Year(Now) & ""
                            calc = objOpSimplesLn.consultValorTodo(sql, "CONTROL")
                            calc_n = calc + CInt(hora)
                            sql = "UPDATE R_compromiso_horas_concepto_90 SET horas_restante=" & calc_n & " WHERE nit_trabajador=" & nit & " AND año=" & Year(Now) & ""
                            objOpSimplesLn.ejecutar(sql, "CONTROL")
                        End If
                        MessageBox.Show("La novedad se rechazo en forma corecta", "correcto", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        cargar_novedades_no_aut()
                    Else
                        MessageBox.Show("Error al anular la novedad,comuniquese con el administrador del sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Else
                    MessageBox.Show("Se debe Ingrese motivo de rechazo de novedad", "Ingrese motivo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End If
        End If
    End Sub

    Private Sub btn_nov_no_aut_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_nov_no_aut.Click
        cargar_novedades_no_aut()
    End Sub
    Private Sub cargar_novedades_no_aut()
        Dim sql As String = "SELECT n.usuario,n.idnovedad,t.nit,t.nombres,n.concepto,y.descripcion As desc_concepto ,n.idperiodo,mes,ano,n.horas,n.valor,n.notas " &
                                 "FROM J_novedades_no_aut n, V_nom_personal_Activo_con_maquila t ,y_conceptos_nom y " &
                                    "WHERE y.concepto = n.concepto AND t.nit = n.nit AND autorizado = 'N' AND idperiodo =" & id_periodo
        If (usuario.permiso.Trim <> "ADMIN" And usuario.permiso.Trim <> "NOMINA" And usuario.permiso.Trim <> "DIR_PRODUCCION") Then
            sql &= " AND n.usuario = '" & usuario.nombresCompleto & "'"
            col_aut_novedad.Visible = False
            col_no_aut_novedad.Visible = False
        End If
        dtg_novedad.DataSource = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        group_novedad.Visible = True
    End Sub
    Private Sub CompromisoToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        cbo_fec_compromiso.Value = Now.Date
        Dim sql As String = "SELECT Id,Fecha_compromiso,Horas,Notas,Nombre_autoriza,nocturno  " &
                                    "FROM R_compromiso_horas_a_pagar " &
                                            "WHERE activo = 'True' AND Nit_Trabajador = " & dtg_consulta.Item("nit", filaSelect_consulta).Value
        dtgCompromisos.DataSource = objOpSimplesLn.listar_datatable(sql, "CONTROL")
        group_compromiso.Visible = True
        txt_observaciones_compromiso.Text = ""
    End Sub
    Private Sub IngresarNovedadToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        bloquear_group_novedad(True)
        cbo_fec_novedad.Value = Now.Date
        colSelect_consulta = dtg_consulta.CurrentCell.ColumnIndex
        filaSelect_consulta = dtg_consulta.CurrentCell.RowIndex
        group_ing_novedad.Visible = True
        txt_concepto.Text = ""
        txt_desc_novedad.Text = ""
    End Sub

    Private Sub btn_cerrar_novedades_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_cerrar_novedades.Click
        group_novedad.Visible = False
        txt_concepto.Text = ""
        txt_desc_novedad.Text = ""
    End Sub
    Private Sub bloquear_group_novedad(ByVal estado As Boolean)
        cbo_fec_novedad.Enabled = estado
        txt_horas_novedad.Enabled = estado
        txtValNov.Enabled = estado
        btn_ok_novedad.Enabled = estado
        txt_observaciones_novedad.Enabled = estado
    End Sub
    Private Sub btn_ok_novedad_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_ok_novedad.Click
        ingresar_novedad()
    End Sub
    Private Sub ingresar_novedad()
        If validar_novedad() Then
            Dim listSql As New List(Of Object)
            Dim nit As Double = dtg_consulta.Item("nit", filaSelect_consulta).Value
            Dim concepto As Double = txt_concepto.Text
            Dim sql As String = ""
            Dim sql_val As String
            Dim val_horas As String
            Dim calc_90 As Double
            Dim contrato As Double = dtg_consulta.Item("contrato", filaSelect_consulta).Value
            Dim fecha As String = objOpSimplesLn.cambiarFormatoFecha(cbo_fec_novedad.Value)
            Dim valor As Integer = txtValNov.Text
            Dim horas As Double = txt_horas_novedad.Text
            Dim centro As Integer = dtg_consulta.Item("centro", filaSelect_consulta).Value
            Dim planta As Integer = dtg_consulta.Item("planta", filaSelect_consulta).Value
            Dim turno As Integer = dtg_consulta.Item("turno", filaSelect_consulta).Value
            Dim oficio As Integer = dtg_consulta.Item("oficio", filaSelect_consulta).Value
            Dim observaciones As String = txt_observaciones_novedad.Text
            Dim nom_usuario As String = usuario.nombresCompleto
            Dim correcto As Boolean = True
            sql = objRelojLn.sql_novedad_no_aut(nit, concepto, id_periodo, fecha, contrato, valor, horas, centro, planta, turno, oficio, observaciones, nom_usuario)
            listSql.Add(sql)
            If concepto = 90 Then
                sql_val = "SELECT horas_restante FROM R_compromiso_horas_concepto_90 WHERE nit_trabajador=" & nit & " AND año=" & Year(Now) & ""
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
            ElseIf concepto = 84 Then
                Dim id As Integer = objOpSimplesLn.consultValorTodo("SELECT  (SELECT CASE WHEN MAX(id) IS NULL THEN (1) ELSE MAX(id)+1 END) as id FROM R_compromiso_horas_a_pagar", "CONTROL")
                Dim sql_compromiso As String = "INSERT INTO R_compromiso_horas_a_pagar (Id,Nit_Trabajador,Fecha_compromiso,Horas,Minutos_estaticos,Nombre_autoriza,Notas,Fecha_sistema,Activo,Horas_original,concepto_84)" &
                                                    " VALUES (" & id & "," & nit & ",GETDATE()," & horas & "," & 0 & ",'" & nom_usuario & "','" & observaciones & "',GETDATE(),1," & horas & "," & concepto & ")"
                If (objOpSimplesLn.ejecutar(sql_compromiso, "CONTROL")) Then
                    MessageBox.Show("El compromiso se genero en forma correcta!", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    correcto = False
                    MessageBox.Show("Error al ingresar el registro,comuniquese con el administrador del sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
            If correcto Then
                If (objOpSimplesLn.ExecuteSqlTransaction(listSql)) Then
                    MessageBox.Show("La novedad se ingreso en forma correcta!", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    group_ing_novedad.Visible = False
                    txt_observaciones_novedad.Text = ""
                    txt_horas_novedad.Text = ""
                    txtValNov.Text = ""
                    Application.DoEvents()
                Else
                    MessageBox.Show("Error al ingresar el registro,comuniquese con el administrador del sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
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
    Private Sub btn_ok_compromiso_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_ok_compromiso.Click
        If (validar_compromiso()) Then
            Dim sql_compromiso As String = ""
            Dim listSql As New List(Of Object)
            Dim id As Integer = objOpSimplesLn.consultValorTodo("SELECT  (SELECT CASE WHEN MAX(id) IS NULL THEN (1) ELSE MAX(id)+1 END) as id FROM R_compromiso_horas_a_pagar", "CONTROL")
            Dim fecha As String = objOpSimplesLn.cambiarFormatoFecha(cbo_fec_compromiso.Value)
            Dim motivo As String = txt_observaciones_compromiso.Text
            Dim nit As Double = dtg_consulta.Item("nit", filaSelect_consulta).Value
            Dim nombre_aut As String = usuario.nombresCompleto
            Dim hora As String = Now.Hour & ":" & Now.Minute & ":00"
            Dim tot_horas As Double = txt_horas_compromiso.Text
            Dim fecha_hora As String = fecha & " " & hora
            Dim Minutos_estaticos As Double = 0
            Dim desc_nocturno As String = ""
            Dim colDebe As String = ""
            If chk_comp_nocturno.Checked Then
                desc_nocturno = "S"
                colDebe = "hDebeN"
            Else
                desc_nocturno = "N"
                colDebe = "hDebeD"
            End If
            sql_compromiso = "INSERT INTO R_compromiso_horas_a_pagar (Id,Nit_Trabajador,Fecha_compromiso,Horas,Minutos_estaticos,Nombre_autoriza,Notas,Fecha_sistema,Activo,nocturno,Horas_original)" &
                    " VALUES (" & id & "," & nit & ",'" & fecha & "'," & tot_horas & "," & Minutos_estaticos & ",'" & nombre_aut & "','" & motivo & "','" & fecha_hora & "',1,'" & desc_nocturno & "'," & tot_horas & ")"
            listSql.Add(sql_compromiso)
            If (objOpSimplesLn.ExecuteSqlTransactionTodo(listSql, "CONTROL")) Then
                MessageBox.Show("El compromiso se realizo en forma correcta!", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information)
                group_compromiso.Visible = False
                txt_horas_compromiso.Text = ""
                txt_observaciones_compromiso.Text = ""
                Application.DoEvents()
                For j = 0 To dtg_consulta.Columns.Count - 1
                    If dtg_consulta.Columns(j).Name = colDebe Then
                        If IsNumeric(dtg_consulta.Item(j, filaSelect_consulta).Value) Then
                            dtg_consulta.Item(j, filaSelect_consulta).Value += tot_horas
                        Else
                            dtg_consulta.Item(j, filaSelect_consulta).Value = tot_horas
                        End If
                        descontar_horas_compromiso()
                    End If
                Next
                chk_comp_nocturno.Checked = False
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

    Private Sub btn_cerrar_compromiso_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_cerrar_compromiso.Click
        group_compromiso.Visible = False
    End Sub

    Private Sub btn_cerrar_ing_nov_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_cerrar_ing_nov.Click
        group_ing_novedad.Visible = False
    End Sub
    Private Sub dtg_ing_novedad_CellClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dtg_ing_novedad.CellClick
        bloquear_group_novedad(True)
        txt_concepto.Text = dtg_ing_novedad.Item("concepto", e.RowIndex).Value
        txt_desc_novedad.Text = dtg_ing_novedad.Item("descripcion", e.RowIndex).Value
        If txt_concepto.Text = "43" Then
            txt_horas_novedad.Text = "0"
            txt_horas_novedad.Enabled = False
        Else
            txtValNov.Text = "0"
            txtValNov.Enabled = False
        End If
    End Sub
    Private Sub procesar_consolidar()
        If (cbo_periodo.SelectedValue <> 0) Then
            Dim where_centro As String = ""
            Dim where_operario As String = ""
            Dim where_turno As String = ""
            If cbo_centro.SelectedValue <> 0 Then
                where_centro = " AND p.centro =" & cbo_centro.SelectedValue
            End If
            If cbo_operario.SelectedValue <> 0 Then
                where_operario = " AND r.nit =" & cbo_operario.SelectedValue
            End If
            If cbo_turno.SelectedValue <> -1 Then
                where_turno = " AND t.id =" & cbo_turno.SelectedValue
            End If
            fecIni = objOpSimplesLn.cambiarFormatoFecha(Convert.ToDateTime(cbo_fecha_ini.Value))
            fecFin = objOpSimplesLn.cambiarFormatoFecha(Convert.ToDateTime(cbo_fecha_fin.Value))
            dt_fechas_festivas = objRelojLn.return_dt_fechas_festivas(fecIni, fecFin)
            If validar_marcaciones(fecIni, fecFin, where_centro, where_operario) Then
                'consolidar(fecIni, fecFin, where_centro, where_operario, where_turno)
                consolidar(fecIni, fecFin, where_centro, where_operario, where_turno, dt_marcacion_procesada)
                If (usuario.permiso.Trim = "ADMIN" Or usuario.permiso.Trim = "NOMINA") Then
                    btn_guardar_liq.Enabled = True
                End If
            End If
        Else
            MessageBox.Show("Seleccione el periodo corrrespondiente a la decada", "Seleccione periodo!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
    Private Sub AsignarTurnoToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        If (dtg_consulta.CurrentCell.RowIndex >= 0) Then
            Dim estado As Boolean = False
            Dim turno As Double = getPrimerIdTurno(dtg_consulta.Item("turnoProg", filaSelect_consulta).Value)
            If ((dtg_consulta.Item("fechaEntrada", filaSelect_consulta).Value > dFecIni_periodo)) Then
                estado = True
            Else
                If Convert.ToDateTime(dtg_consulta.Item("FechaEntrada", filaSelect_consulta).Value).Hour >= 5 And Convert.ToDateTime(dtg_consulta.Item("FechaEntrada", filaSelect_consulta).Value).Hour < 17 Then
                    If turno = 3 Or turno = 9 Or turno = 11 Or turno = 13 Or turno = 15 Or turno = 19 Or turno = 20 And turno = 21 Then

                    Else
                        estado = True
                    End If
                Else
                    If turno <> 3 And turno <> 9 And turno <> 11 And turno <> 13 And turno <> 15 And turno <> 19 And turno <> 99 And turno <> 16 And turno <> 20 And turno <> 21 Then
                        estado = False
                    Else
                        estado = True
                    End If
                End If
                If (Convert.ToDateTime(dtg_consulta.Item("FechaEntrada", filaSelect_consulta).Value).Hour >= 4 And Convert.ToDateTime(dtg_consulta.Item("FechaEntrada", filaSelect_consulta).Value).Hour < 17 And estado = True) Then
                    estado = True
                Else
                    estado = False
                End If

                If (turno <> 3 And turno <> 9 And turno <> 11 And turno <> 13 And turno <> 15 And turno <> 19 And turno <> 99 And turno <> 16 And turno <> 20 And turno <> 21 And estado = True) Then
                    estado = True
                Else
                    estado = False
                End If
                If (Not IsNumeric(dtg_consulta.Item("RN", filaSelect_consulta).Value) And estado = True) Then
                    estado = True
                Else
                    estado = False
                End If
            End If
            If estado Then
                filaSelect_consulta = dtg_consulta.CurrentCell.RowIndex
                colSelect_consulta = dtg_consulta.CurrentCell.ColumnIndex
                groupTurno.Visible = True
                groupTurno.BringToFront()
            Else
                MessageBox.Show("No se permite turnos de decadas anteriores que esten mal programados o en turno de noche", "No permitido!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
    End Sub


    Private Sub dtgTurno_CellClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dtgTurno.CellClick
        If objRelojLn.verificar_periodo_liquidado(id_periodo) Then
            MessageBox.Show("Este periodo se encuentra liquidado, por lo tanto no se permite hacer cambios en turnos ni ingresar novedades", "Periodo liquidado", MessageBoxButtons.OK, MessageBoxIcon.Information)
            periodo_liquidado = True
            bloquear_modificar_valores(False)
            groupTurno.Visible = False
        Else
            periodo_liquidado = False
            bloquear_modificar_valores(True)
            Dim estado As Boolean = False
            Dim codigo As String = 0
            Dim id_enc As Double = 0
            Dim fec_entrada As Date
            Dim sFec As String = ""
            Dim fila_dtg As Integer = 0
            If (dtg_select = dtg_consulta.Name) Then
                fila_dtg = filaSelect_consulta
                codigo = dtgTurno.Item("id", e.RowIndex).Value
                id_enc = dtg_consulta.Item("id_enc", filaSelect_consulta).Value
                fec_entrada = dtg_consulta.Item("FechaEntrada", filaSelect_consulta).Value
                sFec = objOpSimplesLn.cambiarFormatoFecha(fec_entrada)
            ElseIf (dtg_select = dtg_detalle.Name) Then
                fila_dtg = filaSelect_detalle
                codigo = dtgTurno.Item("id", e.RowIndex).Value
                id_enc = dtg_detalle.Item("id_enc", filaSelect_detalle).Value
                fec_entrada = dtg_detalle.Item("fecha", filaSelect_detalle).Value
                sFec = objOpSimplesLn.cambiarFormatoFecha(fec_entrada)
            End If

            If (dtg_consulta.Item("fechaEntrada", filaSelect_consulta).Value > dFecIni_periodo Or (codigo <> 3 And codigo <> 9 And codigo <> 11 And codigo <> 13 And codigo <> 15 And codigo <> 19 And codigo <> 99 And codigo <> 16 And codigo <> 20 And codigo <> 21 _
                And dtgTurno.Item("ord_noct", e.RowIndex).Value = 0)) Then
                Dim permiso_Extra_fest As Boolean = permiso_modificar_turno_festivo()
                If (permiso_Extra_fest Or codigo = 99 Or getPrimerIdTurno(dtg_consulta.Item("turnoProg", filaSelect_consulta).Value) = 99) Then
                    Dim id_det As Integer = objOpSimplesLn.consultValorTodo("SELECT  (SELECT CASE WHEN MAX(id_det) IS NULL THEN (1) ELSE MAX(id_det)+1 END) as id FROM J_prog_turno_det WHERE id_enc = " & id_enc & " ", "CONTROL")
                    Dim iResponce As Integer = MessageBox.Show("Desea agregar un segundo turno? ", "Atención", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                    If (iResponce = 6) Then
                        estado = objRelojLn.add_turno_dia(id_enc, id_det, sFec, codigo)
                    Else
                        estado = objRelojLn.modificar_turno(id_enc, id_det, sFec, codigo)
                    End If
                    If (estado) Then
                        groupTurno.Visible = False
                        If estado_consolidado Then
                            procesar_consolidar()
                        Else
                            If (dtg_select = dtg_detalle.Name) Then
                                Dim fila As Integer = buscar_fechaentrada(objOpSimplesLn.cambiarFormatoFecha(dtg_detalle.Item("fecha", filaSelect_detalle).Value))
                                Dim nit As Double = dtg_consulta.Item("nit", filaSelect_consulta).Value
                                If iResponce = 6 Then
                                    dtg_consulta.Item("turnoProg", fila).Value &= " & "
                                Else
                                    dtg_consulta.Item("turnoProg", fila).Value = ""
                                End If
                                dtg_consulta.Item("turnoProg", fila).Value &= dtgTurno.Item("id", e.RowIndex).Value & " - " & dtgTurno.Item("descripcion", e.RowIndex).Value & " & "
                                detalle_turno_prog(nit)
                                dtg_consulta.Item("ExtP", fila).Value = dtgTurno.Item("extras", e.RowIndex).Value
                                dtg_consulta.Item("OrdP", fila).Value = dtgTurno.Item("OrdP", e.RowIndex).Value
                            Else
                                If iResponce = 6 Then
                                    dtg_consulta.Item("turnoProg", filaSelect_consulta).Value &= " & "
                                Else
                                    dtg_consulta.Item("turnoProg", filaSelect_consulta).Value = ""
                                End If
                                If codigo = 99 Then
                                    dtg_consulta.Item("DComp", filaSelect_consulta).Value = 8
                                    dtg_consulta.Item("turnoProg", filaSelect_consulta).Value = codigo & " - " & dtgTurno.Item("descripcion", e.RowIndex).Value & " & " & dtg_consulta.Item("turnoProg", filaSelect_consulta).Value
                                Else
                                    dtg_consulta.Item("DComp", filaSelect_consulta).Value = "0"
                                    dtg_consulta.Item("turnoProg", filaSelect_consulta).Value &= dtgTurno.Item("id", e.RowIndex).Value & " - " & dtgTurno.Item("descripcion", e.RowIndex).Value & " & "
                                End If

                                dtg_consulta.Item("ExtP", filaSelect_consulta).Value = dtgTurno.Item("extras", e.RowIndex).Value
                                dtg_consulta.Item("OrdP", filaSelect_consulta).Value = dtgTurno.Item("OrdP", e.RowIndex).Value
                            End If
                            verificarHorasExtrasProgramadas(dtg_consulta)
                            MessageBox.Show("El turno se modifico en forma correcta", "Correcto!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    Else
                        MessageBox.Show("Error al modificar el turno", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Else
                    MessageBox.Show("se excedió el número máximo de horas extras dominicales permitidas durante el mes, no se permite programar este dominical-festivo", "No se permite autorizar esta marcación!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    groupTurno.Visible = False
                End If
            Else
                MessageBox.Show("No se permite modificar un turno con recargo nocturno por que el día ya se liquido en la decada anterior", "No permitido", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                groupTurno.Visible = False
            End If
        End If
    End Sub
    Private Sub btn_cerrar_graf_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_cerrar_graf.Click
        groupTurno.Visible = False
    End Sub


    Private Sub VerProgramaciónDeTurnosToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        group_detalle.Visible = True
        Dim nit As Double = dtg_consulta.Item("nit", filaSelect_consulta).Value
        detalle_turno_prog(nit)
    End Sub
    Private Function buscar_fechaentrada(ByVal fecha As String) As Integer
        Dim fila As Integer = -1
        For i = 0 To dtg_consulta.Rows.Count - 2
            If objOpSimplesLn.cambiarFormatoFecha(dtg_consulta.Item("FechaEntrada", i).Value) = fecha Then
                fila = i
            End If
        Next
        Return fila
    End Function
    Private Sub bloquear_modificar_valores(ByVal estado As Boolean)
        itemMod.Enabled = estado
        AsignarTurnoToolStripMenuItem.Enabled = estado
        If (usuario.permiso.Trim <> "ADMIN" And usuario.permiso.Trim <> "NOMINA") Then
            EliminarMarcacionToolStripMenuItem.Enabled = False
        Else
            EliminarMarcacionToolStripMenuItem.Enabled = estado
        End If
        IngresarNovedadToolStripMenuItem.Enabled = estado
    End Sub
    Private Sub valorizar()
        lbl_estado.Text = "VALORIZANDO HORAS..."
        Application.DoEvents()
        dtg_valores.Columns.Clear()
        dtg_valores.DataSource = Nothing
        Dim tiene_sub_tte As Boolean = False
        Dim total As Double = 0
        Dim concepto As Integer = 0
        Dim horas As Integer = 0
        Dim basico_hora As Double = 0
        Dim valor As Double = 0
        Dim porcentaje As Decimal = 0
        Dim vr_total As Double = 0
        Dim salario_prom As Double = 0
        Dim subsidio_tte As Double = objRelojLn.get_sub_trasporte()
        Dim max_subsidio_tte As Double = objRelojLn.get_max_sub_trasporte()
        Dim tot_aux_transporte As Double = 0
        Dim sub_trans_hora As Double = (subsidio_tte / 30.42) / 8
        Dim col As New DataGridViewTextBoxColumn

        For j = 0 To dtg_consulta.Columns.Count - 1
            If (dtg_consulta.Columns(j).Name = "nit" Or dtg_consulta.Columns(j).Name = "nombres" Or dtg_consulta.Columns(j).Name = "centro" Or dtg_consulta.Columns(j).Name = "OrD" Or dtg_consulta.Columns(j).Name = "RN" Or dtg_consulta.Columns(j).Name = "DD" Or dtg_consulta.Columns(j).Name = "DN" _
                           Or dtg_consulta.Columns(j).Name = "DF" Or dtg_consulta.Columns(j).Name = "ED" Or dtg_consulta.Columns(j).Name = "EN" Or dtg_consulta.Columns(j).Name = "EDF" _
                           Or dtg_consulta.Columns(j).Name = "ENF" Or dtg_consulta.Columns(j).Name = "DComp" _
                           Or dtg_consulta.Columns(j).Name = "PR" Or dtg_consulta.Columns(j).Name = "PRH" Or dtg_consulta.Columns(j).Name = "PV" Or dtg_consulta.Columns(j).Name = "PD" Or dtg_consulta.Columns(j).Name = "PC" Or dtg_consulta.Columns(j).Name = "PN" _
                           Or dtg_consulta.Columns(j).Name = "IR" Or dtg_consulta.Columns(j).Name = "IA" Or dtg_consulta.Columns(j).Name = "LM" Or dtg_consulta.Columns(j).Name = "V" _
                           Or dtg_consulta.Columns(j).Name = "DS" Or dtg_consulta.Columns(j).Name = "SU" Or dtg_consulta.Columns(j).Name = "BON") Then
                col = New DataGridViewTextBoxColumn
                col.Name = dtg_consulta.Columns(j).Name
                dtg_valores.Columns.Add(col)
                dtg_valores.Columns(col.Name).SortMode = DataGridViewColumnSortMode.NotSortable
                If dtg_consulta.Columns(j).Name = "centro" Then
                    col = New DataGridViewTextBoxColumn
                    col.Name = "basico_mes"
                    dtg_valores.Columns.Add(col)
                    dtg_valores.Columns(col.Name).SortMode = DataGridViewColumnSortMode.NotSortable
                    col = New DataGridViewTextBoxColumn
                    col.Name = "total"
                    dtg_valores.Columns.Add(col)
                    dtg_valores.Columns(col.Name).SortMode = DataGridViewColumnSortMode.NotSortable
                    col = New DataGridViewTextBoxColumn
                    col.Name = "aux_trans"
                    dtg_valores.Columns.Add(col)
                    dtg_valores.Columns(col.Name).SortMode = DataGridViewColumnSortMode.NotSortable
                End If
            End If
        Next
        If (dtg_consulta.Rows.Count - 1 <> -1) Then
            progBar.Maximum = dtg_consulta.Rows.Count - 2
            progBar.Minimum = 0
        End If
        For i = 0 To dtg_consulta.Rows.Count - 1
            progBar.PerformStep()
            progBar.Refresh()
            If Not IsDBNull(dtg_consulta.Item("nit", i).Value) Then
                dtg_valores.Rows.Add()
                dtg_valores.Item("nit", dtg_valores.Rows.Count - 1).Value = dtg_consulta.Item("nit", i).Value
                dtg_valores.Item("nombres", dtg_valores.Rows.Count - 1).Value = dtg_consulta.Item("nombres", i).Value
                dtg_valores.Item("centro", dtg_valores.Rows.Count - 1).Value = dtg_consulta.Item("centro", i).Value
                dtg_valores.Item("basico_mes", dtg_valores.Rows.Count - 1).Value = Convert.ToDouble(dtg_consulta.Item("basico_mes", i).Value)
                basico_hora = dtg_consulta.Item("basico_hora", i).Value
                dtg_valores.Item("BON", dtg_valores.Rows.Count - 1).Value = dtg_consulta.Item("BON", i).Value
                If dtg_valores.Item("basico_mes", dtg_valores.Rows.Count - 1).Value >= max_subsidio_tte Then
                    tiene_sub_tte = False
                Else
                    tiene_sub_tte = True
                End If
                For j = 0 To dtg_consulta.Columns.Count - 1
                    If (dtg_consulta.Columns(j).Name = "OrD" Or dtg_consulta.Columns(j).Name = "RN" Or dtg_consulta.Columns(j).Name = "DD" Or dtg_consulta.Columns(j).Name = "DN" _
                               Or dtg_consulta.Columns(j).Name = "DF" Or dtg_consulta.Columns(j).Name = "ED" Or dtg_consulta.Columns(j).Name = "EN" Or dtg_consulta.Columns(j).Name = "EDF" _
                               Or dtg_consulta.Columns(j).Name = "ENF" Or dtg_consulta.Columns(j).Name = "DComp" _
                               Or dtg_consulta.Columns(j).Name = "PR" Or dtg_consulta.Columns(j).Name = "PRH" Or dtg_consulta.Columns(j).Name = "PV" Or dtg_consulta.Columns(j).Name = "PD" Or dtg_consulta.Columns(j).Name = "PC" Or dtg_consulta.Columns(j).Name = "PN" _
                               Or dtg_consulta.Columns(j).Name = "IR" Or dtg_consulta.Columns(j).Name = "IA" Or dtg_consulta.Columns(j).Name = "LM" _
                               Or dtg_consulta.Columns(j).Name = "DS" Or dtg_consulta.Columns(j).Name = "SU" Or dtg_consulta.Columns(j).Name = "V") Then
                        If Not IsDBNull(dtg_consulta.Item(j, 0).Value) Then
                            If IsNumeric(dtg_consulta.Item(j, i).Value) Then
                                If dtg_consulta.Item(j, i).Value > 0 Then
                                    porcentaje = dtg_consulta.Item(j, 1).Value / 100
                                    concepto = dtg_consulta.Item(j, 0).Value
                                    horas = dtg_consulta.Item(j, i).Value
                                    If dtg_consulta.Columns(j).Name = "IR" Or dtg_consulta.Columns(j).Name = "IA" Or dtg_consulta.Columns(j).Name = "LM" Then
                                        salario_prom = objRelojLn.get_salario_prom_incap(dtg_consulta.Item("nit", i).Value, dFecIni_periodo, dFecFin_periodo)
                                        salario_prom = salario_prom / 30
                                        salario_prom = salario_prom / 8
                                        valor = objRelojLn.calcular_valor_horas_encapacidad(dtg_consulta.Item("nit", i).Value, id_periodo, salario_prom, porcentaje)
                                    ElseIf (dtg_consulta.Columns(j).Name = "V") Then
                                        valor = objRelojLn.get_valor_vacaciones(dtg_consulta.Item("nit", i).Value, dFecIni_periodo, dFecFin_periodo)
                                    Else
                                        valor = (horas * basico_hora) * (porcentaje)
                                    End If
                                    dtg_valores.Item(dtg_consulta.Columns(j).Name, dtg_valores.Rows.Count - 1).ToolTipText = dtg_consulta.Item(j, i).ToolTipText & " Horas:" & dtg_consulta.Item(j, i).Value
                                    dtg_consulta.Item(j, i).ToolTipText &= " Valor $" & valor.ToString("N0")
                                    dtg_valores.Item(dtg_consulta.Columns(j).Name, dtg_valores.Rows.Count - 1).Value = valor
                                    vr_total += valor
                                Else
                                    dtg_valores.Item(dtg_consulta.Columns(j).Name, dtg_valores.Rows.Count - 1).ToolTipText = dtg_consulta.Item(j, i).ToolTipText
                                    dtg_valores.Item(dtg_consulta.Columns(j).Name, dtg_valores.Rows.Count - 1).Value = 0
                                End If
                            Else
                                dtg_valores.Item(dtg_consulta.Columns(j).Name, dtg_valores.Rows.Count - 1).ToolTipText = dtg_consulta.Item(j, i).ToolTipText
                                dtg_valores.Item(dtg_consulta.Columns(j).Name, dtg_valores.Rows.Count - 1).Value = 0
                            End If
                        End If
                    ElseIf (dtg_consulta.Columns(j).Name = "BON") Then
                        If IsNumeric(dtg_consulta.Item(j, i).Value) Then
                            If dtg_consulta.Item(j, i).Value > 0 Then
                                vr_total += dtg_consulta.Item(j, i).Value
                            Else
                                dtg_valores.Item(dtg_consulta.Columns(j).Name, dtg_valores.Rows.Count - 1).ToolTipText = dtg_consulta.Item(j, i).ToolTipText
                                dtg_valores.Item(dtg_consulta.Columns(j).Name, dtg_valores.Rows.Count - 1).Value = 0
                            End If
                        Else
                            dtg_valores.Item(dtg_consulta.Columns(j).Name, dtg_valores.Rows.Count - 1).ToolTipText = dtg_consulta.Item(j, i).ToolTipText
                            dtg_valores.Item(dtg_consulta.Columns(j).Name, dtg_valores.Rows.Count - 1).Value = 0
                        End If
                    End If
                    If (dtg_consulta.Columns(j).Name = "OrD" Or dtg_consulta.Columns(j).Name = "RN" Or dtg_consulta.Columns(j).Name = "DD" Or dtg_consulta.Columns(j).Name = "DN" _
                               Or dtg_consulta.Columns(j).Name = "DF" Or dtg_consulta.Columns(j).Name = "DComp" _
                             Or dtg_consulta.Columns(j).Name = "PE" Or dtg_consulta.Columns(j).Name = "PD" Or dtg_consulta.Columns(j).Name = "PC") Then
                        If IsNumeric(dtg_consulta.Item(j, i).Value) Then
                            If dtg_consulta.Item(j, i).Value > 0 Then
                                If tiene_sub_tte Then
                                    tot_aux_transporte += sub_trans_hora * dtg_consulta.Item(j, i).Value
                                End If
                            End If
                        End If
                    End If
                Next
                dtg_valores.Item("aux_trans", dtg_valores.Rows.Count - 1).Value = tot_aux_transporte
                If Not IsDBNull(dtg_valores.Item("aux_trans", dtg_valores.Rows.Count - 1).Value) Then
                    vr_total += dtg_valores.Item("aux_trans", dtg_valores.Rows.Count - 1).Value
                End If
                dtg_valores.Item("total", dtg_valores.Rows.Count - 1).Value = vr_total
                vr_total = 0
                tot_aux_transporte = 0
            End If
        Next
        Dim tamano_letra As Single = 9.0!
        dtg_valores.Rows.Add()
        For j = 0 To dtg_valores.Columns.Count - 1
            If (dtg_valores.Columns(j).Name = "OrD" Or dtg_valores.Columns(j).Name = "RN" Or dtg_valores.Columns(j).Name = "DD" Or dtg_valores.Columns(j).Name = "DN" _
                           Or dtg_valores.Columns(j).Name = "DF" Or dtg_valores.Columns(j).Name = "ED" Or dtg_valores.Columns(j).Name = "EN" Or dtg_valores.Columns(j).Name = "EDF" _
                           Or dtg_valores.Columns(j).Name = "ENF" Or dtg_valores.Columns(j).Name = "DComp" Or dtg_valores.Columns(j).Name = "DS" Or dtg_valores.Columns(j).Name = "SU" _
                           Or dtg_valores.Columns(j).Name = "PR" Or dtg_valores.Columns(j).Name = "PRH" Or dtg_valores.Columns(j).Name = "PV" Or dtg_valores.Columns(j).Name = "PD" Or dtg_valores.Columns(j).Name = "PC" Or dtg_valores.Columns(j).Name = "PN" _
                           Or dtg_valores.Columns(j).Name = "IR" Or dtg_valores.Columns(j).Name = "IA" Or dtg_valores.Columns(j).Name = "LM" Or
                           dtg_valores.Columns(j).Name = "V" Or dtg_valores.Columns(j).Name = "BON" Or dtg_valores.Columns(j).Name = "basico_mes" Or dtg_valores.Columns(j).Name = "total" Or dtg_valores.Columns(j).Name = "aux_trans") Then
                For i = 0 To dtg_valores.Rows.Count - 1
                    If Not IsDBNull(dtg_valores.Item(j, i).Value) Then
                        total += dtg_valores.Item(j, i).Value
                    End If
                Next
                dtg_valores.Item(j, dtg_valores.Rows.Count - 1).Value = total
                total = 0
            End If
        Next
        dtg_valores.Rows(dtg_valores.Rows.Count - 1).DefaultCellStyle = objOperacionesForm.formatoNegrita(tamano_letra)
        dtg_valores.Columns("total").DefaultCellStyle = objOperacionesForm.formatoNegrita(tamano_letra)
        progBar.Value = 0
        progBar.Visible = False
        lbl_estado.Text = ""
        If (usuario.permiso.Trim <> "ADMIN" And usuario.permiso.Trim <> "NOMINA") Then
            dtg_valores.Columns("basico_mes").Visible = False
        End If
    End Sub

    Private Sub chk_consol_centros_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chk_consol_centros.CheckedChanged
        If carga_comp Then
            Application.DoEvents()
            If chk_consol_centros.Checked Then
                If dtg_valores.Rows.Count > 0 Then
                    consolidar_valorizacion()
                Else
                    If dtg_consulta.Rows.Count > 0 Then
                        valorizar()
                        consolidar_valorizacion()
                    End If
                End If
            Else
                valorizar()
            End If
        End If
    End Sub
    Private Sub consolidar_valorizacion()
        progBar.Visible = True
        Dim tamano_letra As Single = 9.0!
        lbl_estado.Text = "CONSOLIDANDO VALORES..."
        Application.DoEvents()
        Dim dt_consolidado As New DataTable
        Dim fila As Integer = 0
        Dim centro As Integer = 0
        Dim total As Double = 0

        For j = 0 To dtg_valores.Columns.Count - 1
            If dtg_valores.Columns(j).Name <> "nit" And dtg_valores.Columns(j).Name <> "nombres" Then
                dt_consolidado.Columns.Add(dtg_valores.Columns(j).Name, GetType(Double))
                If dtg_valores.Columns(j).Name = "centro" Then
                    dt_consolidado.Columns.Add("desc_centro")
                End If
            End If
        Next
        If (dtg_valores.Rows.Count - 1 <> -1) Then
            progBar.Maximum = dtg_valores.Rows.Count - 2
            progBar.Minimum = 0
        End If
        For i = 0 To dtg_valores.Rows.Count - 2
            progBar.PerformStep()
            progBar.Refresh()
            centro = dtg_valores.Item("centro", i).Value
            fila = buscar_cento(dt_consolidado, centro)
            If fila = -1 Then
                dt_consolidado.Rows.Add()
                fila = dt_consolidado.Rows.Count - 1
                dt_consolidado.Rows(fila).Item("centro") = centro
                dt_consolidado.Rows(fila).Item("desc_centro") = objOpSimplesLn.consultarVal("SELECT descripcion FROM centros WHERE centro =" & centro)
            End If
            For j = 0 To dtg_valores.Columns.Count - 1
                If (dtg_valores.Columns(j).Name = "OrD" Or dtg_valores.Columns(j).Name = "RN" Or dtg_valores.Columns(j).Name = "DD" Or dtg_valores.Columns(j).Name = "DN" _
                            Or dtg_valores.Columns(j).Name = "DF" Or dtg_valores.Columns(j).Name = "ED" Or dtg_valores.Columns(j).Name = "EN" Or dtg_valores.Columns(j).Name = "EDF" _
                            Or dtg_valores.Columns(j).Name = "ENF" Or dtg_valores.Columns(j).Name = "DComp" _
                            Or dtg_valores.Columns(j).Name = "PR" Or dtg_valores.Columns(j).Name = "PRH" Or dtg_valores.Columns(j).Name = "PV" Or dtg_valores.Columns(j).Name = "PD" Or dtg_valores.Columns(j).Name = "PC" Or dtg_valores.Columns(j).Name = "PN" _
                            Or dtg_valores.Columns(j).Name = "IR" Or dtg_valores.Columns(j).Name = "IA" Or dtg_valores.Columns(j).Name = "LM" _
                            Or dtg_valores.Columns(j).Name = "DS" Or dtg_valores.Columns(j).Name = "SU" Or dtg_valores.Columns(j).Name = "V" Or dtg_valores.Columns(j).Name = "BON" _
                             Or dtg_valores.Columns(j).Name = "total" Or dtg_valores.Columns(j).Name = "basico_mes" Or dtg_valores.Columns(j).Name = "aux_trans") Then
                    If IsDBNull(dt_consolidado.Rows(fila).Item(dtg_valores.Columns(j).Name)) Then
                        dt_consolidado.Rows(fila).Item(dtg_valores.Columns(j).Name) = dtg_valores.Item(dtg_valores.Columns(j).Name, i).Value
                    Else
                        dt_consolidado.Rows(fila).Item(dtg_valores.Columns(j).Name) += dtg_valores.Item(dtg_valores.Columns(j).Name, i).Value
                    End If
                End If
            Next
        Next
        dt_consolidado.Rows.Add()
        For j = 0 To dt_consolidado.Columns.Count - 1
            If (dt_consolidado.Columns(j).ColumnName = "OrD" Or dt_consolidado.Columns(j).ColumnName = "RN" Or dt_consolidado.Columns(j).ColumnName = "DD" Or dt_consolidado.Columns(j).ColumnName = "DN" _
                           Or dt_consolidado.Columns(j).ColumnName = "DF" Or dt_consolidado.Columns(j).ColumnName = "ED" Or dt_consolidado.Columns(j).ColumnName = "EN" Or dt_consolidado.Columns(j).ColumnName = "EDF" _
                           Or dt_consolidado.Columns(j).ColumnName = "ENF" Or dt_consolidado.Columns(j).ColumnName = "DComp" Or dt_consolidado.Columns(j).ColumnName = "DS" Or dt_consolidado.Columns(j).ColumnName = "SU" _
                           Or dt_consolidado.Columns(j).ColumnName = "PR" Or dt_consolidado.Columns(j).ColumnName = "PRH" Or dt_consolidado.Columns(j).ColumnName = "PV" Or dt_consolidado.Columns(j).ColumnName = "PD" Or dt_consolidado.Columns(j).ColumnName = "PC" Or dt_consolidado.Columns(j).ColumnName = "PN" _
                           Or dt_consolidado.Columns(j).ColumnName = "IR" Or dt_consolidado.Columns(j).ColumnName = "IA" Or dt_consolidado.Columns(j).ColumnName = "LM" Or
                           dt_consolidado.Columns(j).ColumnName = "V" Or dt_consolidado.Columns(j).ColumnName = "BON" Or
                           dt_consolidado.Columns(j).ColumnName = "total" Or dt_consolidado.Columns(j).ColumnName = "basico_mes" Or dt_consolidado.Columns(j).ColumnName = "aux_trans") Then
                For i = 0 To dt_consolidado.Rows.Count - 1
                    If Not IsDBNull(dt_consolidado.Rows(i).Item(j)) Then
                        total += dt_consolidado.Rows(i).Item(j)
                    End If
                Next
                dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item(j) = total
                total = 0
            End If
        Next
        dtg_valores.Columns.Clear()
        dtg_valores.DataSource = dt_consolidado
        dtg_valores.Rows(dtg_valores.Rows.Count - 1).DefaultCellStyle = objOperacionesForm.formatoNegrita(tamano_letra)
        dtg_valores.Columns("total").DefaultCellStyle = objOperacionesForm.formatoNegrita(tamano_letra)
        progBar.Value = 0
        progBar.Visible = False
        lbl_estado.Text = ""
        If (usuario.permiso.Trim <> "ADMIN" And usuario.permiso.Trim <> "NOMINA") Then
            dtg_valores.Columns("basico_mes").Visible = False
        End If

    End Sub
    Private Function buscar_cento(ByRef dt As DataTable, ByVal centro As Integer) As Integer
        Dim fila As Integer = -1
        For i = 0 To dt.Rows.Count - 1
            If dt.Rows(i).Item("centro") = centro Then
                fila = i
            End If
        Next
        Return fila
    End Function

    Private Sub cbo_operario_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbo_operario.SelectedIndexChanged
        If carga_comp Then
            If cbo_operario.SelectedValue <> 0 Then
                btn_actualizar.PerformClick()
            End If
        End If
    End Sub

    Private Sub dtgCompromisos_CellClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dtgCompromisos.CellClick
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

    Private Sub btn_ver_veriables_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_ver_veriables.Click
        For j = 0 To dtg_consulta.Columns.Count - 1
            If (dtg_consulta.Columns(j).Name = "Consec" Or dtg_consulta.Columns(j).Name = "nit") Then
                dtg_consulta.Columns(j).Visible = True
            End If
        Next
    End Sub
    Private Function verificar_fecha_festiva(ByVal fecha As Date) As Boolean
        fecha = CDate(fecha.ToString("d"))
        Dim festivo As Boolean = False
        For i = 0 To dt_fechas_festivas.Rows.Count - 1
            If (dt_fechas_festivas.Rows(i).Item("fecha") = fecha) Then
                'modificar festivo
                festivo = True


                i = dt_fechas_festivas.Rows.Count - 1
            End If
        Next
        Return festivo
    End Function
    Private Function verificar_dia_siguiente_festivo(ByVal fecha As Date) As Boolean
        fecha = fecha.AddDays(+1)
        fecha = CDate(fecha.ToString("d"))
        Dim festivo As Boolean = False
        For i = 0 To dt_fechas_festivas.Rows.Count - 1
            If (dt_fechas_festivas.Rows(i).Item("fecha") = fecha) Then
                festivo = True
                i = dt_fechas_festivas.Rows.Count - 1
            End If
        Next
        Return festivo
    End Function



    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Frm_generar_marcacion.ShowDialog()
    End Sub


    Private Sub dtg_consulta_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Private Sub EliminarMarcacionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EliminarMarcacionToolStripMenuItem.Click
        Dim result As DialogResult
        result = MessageBox.Show("Realmente desea eliminar la marcacion seleccionada", "Eliminar marcacion", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
        If result = DialogResult.OK Then
            Try

                Dim func As New Op_simplesAd
                If func.eliminarmarcacion(consecutivop) Then

                Else
                    MessageBox.Show("Producto no fue eliminado", "Eliminar registros", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
                actuaizar()


            Catch ex As Exception
                MsgBox(ex.Message)

            End Try
        Else
            MessageBox.Show("Cancelando eliminacion de registros", "Eliminar registros", MessageBoxButtons.OK, MessageBoxIcon.Information)
            actuaizar()
        End If

    End Sub

    Private Sub itemMod_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles itemMod.Click
        Dim dtg As DataGridView = Nothing
        Select Case dtg_select
            Case dtg_consulta.Name
                dtg = dtg_consulta
            Case dtg_detalle.Name
                dtg = dtg_detalle
        End Select
        If (dtg.CurrentCell.RowIndex >= 0 And correccion = True) Then
            If (dtg.Columns(dtg.CurrentCell.ColumnIndex).Name = "FechaEntrada" Or dtg.Columns(dtg.CurrentCell.ColumnIndex).Name = "FechaSalida" Or dtg.Columns(dtg.CurrentCell.ColumnIndex).Name = "fechaEntrada" Or dtg.Columns(dtg.CurrentCell.ColumnIndex).Name = "fechaSalida") Then
                filaSelect_consulta = dtg.CurrentCell.RowIndex
                colSelect_consulta = dtg.CurrentCell.ColumnIndex
                groupFecha.Visible = True
            End If
        End If
    End Sub

    Private Sub DetalleToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DetalleToolStripMenuItem.Click
        group_detalle.Visible = True
        Dim nit As Double = dtg_consulta.Item("nit", filaSelect_consulta).Value
        If (dtg_consulta.Columns(colSelect_consulta).Name = "PR" Or dtg_consulta.Columns(colSelect_consulta).Name = "PRH" Or dtg_consulta.Columns(colSelect_consulta).Name = "PV" Or dtg_consulta.Columns(colSelect_consulta).Name = "PD" Or dtg_consulta.Columns(colSelect_consulta).Name = "PE" Or dtg_consulta.Columns(colSelect_consulta).Name = "PC" _
                           Or dtg_consulta.Columns(colSelect_consulta).Name = "PN") Then
            detalle_permisos(nit)
        ElseIf dtg_consulta.Columns(colSelect_consulta).Name = "IR" Or dtg_consulta.Columns(colSelect_consulta).Name = "IA" Or dtg_consulta.Columns(colSelect_consulta).Name = "LM" Then
            detalle_incapacidades(nit)
        ElseIf (dtg_consulta.Columns(colSelect_consulta).Name = "V") Then
            detalle_vacaciones(nit)
        ElseIf (dtg_consulta.Columns(colSelect_consulta).Name = "SU" Or dtg_consulta.Columns(colSelect_consulta).Name = "DS") Then
            detalle_suspensiones(nit)
        Else
            detalle_marcaciones(nit)
        End If
    End Sub

    Private Sub IngresarNovedadToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IngresarNovedadToolStripMenuItem.Click
        bloquear_group_novedad(True)
        cbo_fec_novedad.Value = Now.Date
        colSelect_consulta = dtg_consulta.CurrentCell.ColumnIndex
        filaSelect_consulta = dtg_consulta.CurrentCell.RowIndex
        group_ing_novedad.Visible = True
        txt_concepto.Text = ""
        txt_desc_novedad.Text = ""
    End Sub

    Private Sub CompromisoToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CompromisoToolStripMenuItem.Click
        cbo_fec_compromiso.Value = Now.Date
        Dim sql As String = "SELECT Id,Fecha_compromiso,Horas,Notas,Nombre_autoriza,nocturno  " &
                                    "FROM R_compromiso_horas_a_pagar " &
                                            "WHERE activo = 'True' AND Nit_Trabajador = " & dtg_consulta.Item("nit", filaSelect_consulta).Value & " and fecha_compromiso>='2020-04-01 00:00:00.000'"
        dtgCompromisos.DataSource = objOpSimplesLn.listar_datatable(sql, "CONTROL")
        dtgCompromisos.Columns("Fecha_compromiso").DefaultCellStyle.Format = "d"
        group_compromiso.Visible = True
        txt_observaciones_compromiso.Text = ""
    End Sub

    Private Sub AsignarTurnoToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AsignarTurnoToolStripMenuItem.Click
        Dim passusua As String
        Dim pass As String
        Dim npass As String
        Dim result As MsgBoxResult
        pass = obtenerPassword()
        npass = Replace(pass, " ", "")
        Dim nom_col As String = dtg_consulta.Columns(colSelect_consulta).Name
        If (dtg_consulta.CurrentCell.RowIndex >= 0) Then
            Dim estado As Boolean = False
            Dim turno As Double = getPrimerIdTurno(dtg_consulta.Item("turnoProg", filaSelect_consulta).Value)

            If ((dtg_consulta.Item("fechaEntrada", filaSelect_consulta).Value > dFecIni_periodo)) Then
                estado = True
            Else
                If Convert.ToDateTime(dtg_consulta.Item("FechaEntrada", filaSelect_consulta).Value).Hour >= 5 And Convert.ToDateTime(dtg_consulta.Item("FechaEntrada", filaSelect_consulta).Value).Hour < 17 Then
                    If turno = 3 Or turno = 9 Or turno = 11 Or turno = 13 Or turno = 15 Or turno = 19 Or turno = 20 And turno = 21 Then

                    Else
                        estado = True
                    End If
                Else
                    If turno <> 3 And turno <> 9 And turno <> 11 And turno <> 13 And turno <> 15 And turno <> 19 And turno <> 99 And turno <> 16 And turno <> 20 And turno <> 21 Then
                        estado = False
                    Else
                        estado = True
                    End If
                End If
                If (Convert.ToDateTime(dtg_consulta.Item("FechaEntrada", filaSelect_consulta).Value).Hour >= 4 And Convert.ToDateTime(dtg_consulta.Item("FechaEntrada", filaSelect_consulta).Value).Hour < 17 And estado = True) Then
                    estado = True
                Else
                    estado = False
                End If

                If (turno <> 3 And turno <> 9 And turno <> 11 And turno <> 13 And turno <> 15 And turno <> 19 And turno <> 99 And turno <> 16 And turno <> 20 And turno <> 21 And estado = True) Then
                    estado = True
                Else
                    estado = False
                End If
                If (Not IsNumeric(dtg_consulta.Item("RN", filaSelect_consulta).Value) And estado = True) Then
                    estado = True
                Else
                    estado = False
                End If
            End If
            If estado = False Then
                result = MessageBox.Show("tiene contraseña de administrador que le permita modificar?", "Clave de administrador", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                If result = vbYes Then
                    passusua = InputBox("Ingrese contraseña de administrador", "Clave de administrador")
                    If passusua = npass Then
                        estado = True
                    Else
                        MessageBox.Show("Contraseña incorrecta", "No permitido modificar!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Me.Show()
                    End If
                Else
                    Me.Show()
                End If
            End If

            If estado Then
                filaSelect_consulta = dtg_consulta.CurrentCell.RowIndex
                colSelect_consulta = dtg_consulta.CurrentCell.ColumnIndex
                groupTurno.Visible = True
                groupTurno.BringToFront()
            Else
                MessageBox.Show("No se permite turnos de decadas anteriores que esten mal programados o en turno de noche", "No permitido!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
    End Sub
    Public Function obtenerPassword()
        Dim con As New Conexion
        Dim Cmd As New SqlCommand
        Dim Password As String
        con.abrirConexion()
        Cmd = New SqlCommand("select Login from Jjv_usuarios where usuario='admin'")
        Cmd.CommandType = CommandType.Text
        Cmd.Connection = con.abrirConexion
        Password = Cmd.ExecuteScalar.ToString
        Return Password
    End Function

    Private Sub VerProgramaciónDeTurnosToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VerProgramaciónDeTurnosToolStripMenuItem.Click
        group_detalle.Visible = True
        Dim nit As Double = dtg_consulta.Item("nit", filaSelect_consulta).Value
        detalle_turno_prog(nit)
    End Sub

    Private Sub ToolStripButton1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Dim FRM As New Frm_generar_marcacion
        FRM.Show()
    End Sub
    Private Function permiso_modificar_turno_festivo() As Boolean
        Dim permiso_extra_fest As Boolean = True
        If Not IsDBNull(dtg_consulta.Item("EDF", filaSelect_consulta).Value) Or Not IsDBNull(dtg_consulta.Item("ENF", filaSelect_consulta).Value) Then
            Dim nit As Double = dtg_consulta.Item("nit", filaSelect_consulta).Value
            If Not objRelojLn.verificar_max__horas_domnicales_trab_mes(nit, mes, ano) Then
                permiso_extra_fest = False
            End If
        End If
        Return permiso_extra_fest
    End Function

    Private Sub groupTurno_Enter(sender As Object, e As EventArgs) Handles groupTurno.Enter

    End Sub
End Class