Imports logicaNegocios
Imports entidadNegocios
Public Class Frm_liquidar_reloj
    Private objOperacionesForm As OperacionesFormularios = New OperacionesFormularios
    Private objOpSimplesLn As New Op_simpesLn
    Private nomb_modulo As String
    Private dtTrazabilidad As DataTable
    Dim centros As String = ""
    Dim per_diagnostico As Boolean = True
    Dim usuario As New UsuarioEn
    Dim conceptos As String = "5,6,7,8,9,10,11,25,34,35,36,37,38,511,512,513,516,510"
    Private bsDetalleAusentismos As Windows.Forms.BindingSource = New BindingSource
    Public Sub MAIN(ByVal nomb_modulo As String, ByVal usuario As UsuarioEn)
        Me.usuario = usuario
        Dim dt As DataTable = objOpSimplesLn.listar_datatable("SELECT centro_costos FROM J_ausen_per_centro_costos WHERE usuario = '" & usuario.usuario & "'", "CORSAN")
        Me.nomb_modulo = nomb_modulo
        If (dt.Rows.Count > 0) Then
            centros = " centro IN ("
            For i = 0 To dt.Rows.Count - 1
                If i <> dt.Rows.Count - 1 Then
                    centros &= dt.Rows(i).Item("centro_costos") & ","
                Else
                    centros &= dt.Rows(i).Item("centro_costos") & ") "
                End If
            Next
        End If
        dt = New DataTable
        dt = objOpSimplesLn.listar_datatable("SELECT * FROM J_ausen_per_no_diagnostico WHERE usuario = '" & usuario.usuario & "'", "CORSAN")
        If (dt.Rows.Count > 0) Then
            tbl_ppal.TabPages.Remove(tbl_diagnostico)
            per_diagnostico = False
        End If
        cargarCbo()
    End Sub
    Private Sub Frm_informe_ausentismos_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        cbo_fecha_ini.Value = Now.AddMonths(-(Now.Month - 1))
        cbo_fecha_fin.Value = Now.Date
    End Sub
    Private Sub btnActualizar_Click(sender As System.Object, e As System.EventArgs) Handles btnActualizar.Click
        imgProcesar.Visible = True
        Application.DoEvents()
        If tbl_ppal.SelectedTab.Name = tab_tendencia.Name Then
            tendencia()
        Else
            cargar_consulta()
        End If
        imgProcesar.Visible = False
    End Sub
    Private Sub btn_ppal_Click(sender As System.Object, e As System.EventArgs) Handles btn_ppal.Click
        FrmPrincipal.Show()
        Me.Close()
        FrmPrincipal.Activate()
    End Sub

    Private Sub btn_salir_Click(sender As System.Object, e As System.EventArgs) Handles btn_salir.Click
        FrmLogin.Show()
        FrmPrincipal.Close()
        FrmLogin.Activate()
        Me.Close()
    End Sub
    Private Sub cargar_consulta()
        Dim dt_info_gral As New DataTable
        Dim dt_aucentismo As New DataTable
        Dim dt_dias_mas_auc As New DataTable
        Dim dt_cant_incapacidades As New DataTable
        Dim view As New DataView
        Dim centro As Integer = cbo_centro.SelectedValue
        Dim fec_ini As String = objOpSimplesLn.cambiarFormatoFecha(cbo_fecha_ini.Value)
        Dim fec_fin As String = objOpSimplesLn.cambiarFormatoFecha(cbo_fecha_fin.Value)
        Dim whereSql As String = "WHERE  fecha_inicial >='" & fec_ini & "' AND fecha_inicial <='" & fec_fin & "' "
        Dim whereCentro As String = ""
        Dim sql_diagnostico As String = ""
        If (cbo_centro.Text <> "TODO") Then
            whereSql &= "AND centro =" & centro & " "
            whereCentro = " AND centro =" & centro & " "
        Else
            If (centros <> "") Then
                whereSql &= " AND " & centros
                whereCentro = " AND " & centros
            End If
        End If
        If (per_diagnostico) Then
            sql_diagnostico = ",diagnostico"
        End If
        Dim sql As String = "SELECT     nit, nombres,  centro, Descr_centro, oficio, Desc_ofic, concepto,desc_concepto" & sql_diagnostico & ", descripcion,( CAST (dias_incap AS decimal(18,0)) )As dias_incap, fecha_inicial, fecha_final,valor_pagado As valor " & _
                                    "FROM Jjv_nom_detalle_incap " & _
                                       whereSql
        dt_info_gral = objOpSimplesLn.listar_datatable(sql, "CORSAN")

        If (chkAusentismo.Checked) Then
            sql = "SELECT nit,nombres,centro,Descr_centro As Descr_centro,oficio,Desc_ofic,concepto,desc_concepto,(horas / 8) As dias,fecha,valor " & _
                                                  " FROM Jjv_otros_Ausentismos " & _
                                                             "WHERE fecha >='" & fec_ini & "' AND fecha <='" & fec_fin & "' " & whereCentro
            dt_aucentismo = objOpSimplesLn.listar_datatable(sql, "CORSAN")

            For i = 0 To dt_aucentismo.Rows.Count - 1
                dt_info_gral.Rows.Add()
                dt_info_gral.Rows(dt_info_gral.Rows.Count - 1).Item("nit") = dt_aucentismo.Rows(i).Item("nit")
                dt_info_gral.Rows(dt_info_gral.Rows.Count - 1).Item("nombres") = dt_aucentismo.Rows(i).Item("nombres")
                dt_info_gral.Rows(dt_info_gral.Rows.Count - 1).Item("Descr_centro") = dt_aucentismo.Rows(i).Item("Descr_centro")
                dt_info_gral.Rows(dt_info_gral.Rows.Count - 1).Item("centro") = dt_aucentismo.Rows(i).Item("centro")
                dt_info_gral.Rows(dt_info_gral.Rows.Count - 1).Item("oficio") = dt_aucentismo.Rows(i).Item("oficio")
                dt_info_gral.Rows(dt_info_gral.Rows.Count - 1).Item("Desc_ofic") = dt_aucentismo.Rows(i).Item("Desc_ofic")
                dt_info_gral.Rows(dt_info_gral.Rows.Count - 1).Item("concepto") = dt_aucentismo.Rows(i).Item("concepto")
                dt_info_gral.Rows(dt_info_gral.Rows.Count - 1).Item("desc_concepto") = dt_aucentismo.Rows(i).Item("desc_concepto")
                dt_info_gral.Rows(dt_info_gral.Rows.Count - 1).Item("fecha_inicial") = dt_aucentismo.Rows(i).Item("fecha")
                dt_info_gral.Rows(dt_info_gral.Rows.Count - 1).Item("dias_incap") = dt_aucentismo.Rows(i).Item("dias")
                dt_info_gral.Rows(dt_info_gral.Rows.Count - 1).Item("valor") = dt_aucentismo.Rows(i).Item("valor")
            Next
        End If



        Dim sum As Double = 0
        dt_info_gral.Rows.Add()
        dt_info_gral.Rows(dt_info_gral.Rows.Count - 1).Item("nombres") = "TOTAL"
        For i = 0 To dt_info_gral.Columns.Count - 1
            If (dt_info_gral.Columns(i).ColumnName = "basico_mes" Or dt_info_gral.Columns(i).ColumnName = "basico_dia" Or dt_info_gral.Columns(i).ColumnName = "valor" Or dt_info_gral.Columns(i).ColumnName = "dias_incap") Then
                For j = 0 To dt_info_gral.Rows.Count - 2
                    If Not IsDBNull(dt_info_gral.Rows(j).Item(i)) Then
                        sum += dt_info_gral.Rows(j).Item(i)
                    End If
                Next
                dt_info_gral.Rows(dt_info_gral.Rows.Count - 1).Item(i) = sum
                sum = 0
            End If
        Next
        bsDetalleAusentismos.DataSource = dt_info_gral
        view = New DataView(dt_info_gral)
        'view.Sort = "nombres"
        dtg_consulta.DataSource = view

        dt_dias_mas_auc.Columns.Add("num_dia", GetType(Double))
        dt_dias_mas_auc.Columns.Add("Día")
        dt_dias_mas_auc.Columns.Add("Cant", GetType(Double))
        dt_dias_mas_auc.Columns.Add("Valor", GetType(Double))
        For i = 0 To 6
            dt_dias_mas_auc.Rows.Add()
            dt_dias_mas_auc.Rows(i).Item("num_dia") = i
            dt_dias_mas_auc.Rows(i).Item("Cant") = 0
            dt_dias_mas_auc.Rows(i).Item("Valor") = 0
            Select Case i
                Case 1
                    dt_dias_mas_auc.Rows(i).Item("Día") = "Lunes"
                Case 2
                    dt_dias_mas_auc.Rows(i).Item("Día") = "Martes"
                Case 3
                    dt_dias_mas_auc.Rows(i).Item("Día") = "Miercoles"
                Case 4
                    dt_dias_mas_auc.Rows(i).Item("Día") = "Jueves"
                Case 5
                    dt_dias_mas_auc.Rows(i).Item("Día") = "Viernes"
                Case 6
                    dt_dias_mas_auc.Rows(i).Item("Día") = "Sabado"
                Case 0
                    dt_dias_mas_auc.Rows(i).Item("Día") = "Domingo"
            End Select
        Next
        Dim num_dia As Integer = 0
        For i = 0 To dt_info_gral.Rows.Count - 2
            num_dia = Convert.ToDateTime(dt_info_gral.Rows(i).Item("fecha_inicial")).DayOfWeek
            For j = 0 To dt_dias_mas_auc.Rows.Count - 1
                If (dt_dias_mas_auc.Rows(j).Item("num_dia") = num_dia) Then
                    dt_dias_mas_auc.Rows(j).Item("Cant") += 1
                    If Not IsDBNull(dt_info_gral.Rows(i).Item("valor")) Then
                        dt_dias_mas_auc.Rows(j).Item("Valor") += dt_info_gral.Rows(i).Item("valor")
                    End If
                    j = dt_dias_mas_auc.Rows.Count - 1
                End If
            Next
        Next
        dt_dias_mas_auc.Rows.Add()
        dt_dias_mas_auc.Rows(dt_dias_mas_auc.Rows.Count - 1).Item("Día") = "TOTAL"
        For i = 0 To dt_dias_mas_auc.Columns.Count - 1
            If (dt_dias_mas_auc.Columns(i).ColumnName = "Cant" Or dt_dias_mas_auc.Columns(i).ColumnName = "Valor") Then
                For j = 0 To dt_dias_mas_auc.Rows.Count - 2
                    If Not IsDBNull(dt_dias_mas_auc.Rows(j).Item(i)) Then
                        sum += dt_dias_mas_auc.Rows(j).Item(i)
                    End If
                Next
                dt_dias_mas_auc.Rows(dt_dias_mas_auc.Rows.Count - 1).Item(i) = sum
                sum = 0
            End If
        Next
        dtg_mas_ausentismo.DataSource = dt_dias_mas_auc

        Dim nit_ant As Integer = 0
        dt_cant_incapacidades.Columns.Add("Nit")
        dt_cant_incapacidades.Columns.Add("Nombres")
        dt_cant_incapacidades.Columns.Add("Cantidad", GetType(Double))
        dt_cant_incapacidades.Columns.Add("dias_incap", GetType(Double))
        dt_cant_incapacidades.Columns.Add("valor", GetType(Double))
        For i = 0 To dtg_consulta.Rows.Count - 2
            If (i = 0 Or nit_ant <> dtg_consulta.Item("nit", i).Value) Then
                nit_ant = dtg_consulta.Item("nit", i).Value
                dt_cant_incapacidades.Rows.Add()
                dt_cant_incapacidades.Rows(dt_cant_incapacidades.Rows.Count - 1).Item("Nit") = dtg_consulta.Item("nit", i).Value
                dt_cant_incapacidades.Rows(dt_cant_incapacidades.Rows.Count - 1).Item("Nombres") = dtg_consulta.Item("nombres", i).Value
                dt_cant_incapacidades.Rows(dt_cant_incapacidades.Rows.Count - 1).Item("Cantidad") = 1
                dt_cant_incapacidades.Rows(dt_cant_incapacidades.Rows.Count - 1).Item("dias_incap") = dtg_consulta.Item("dias_incap", i).Value
                If Not IsDBNull(dt_info_gral.Rows(i).Item("valor")) Then
                    dt_cant_incapacidades.Rows(dt_cant_incapacidades.Rows.Count - 1).Item("Valor") = dt_info_gral.Rows(i).Item("valor")
                End If
            Else
                dt_cant_incapacidades.Rows(dt_cant_incapacidades.Rows.Count - 1).Item("Cantidad") += 1
                dt_cant_incapacidades.Rows(dt_cant_incapacidades.Rows.Count - 1).Item("dias_incap") += dtg_consulta.Item("dias_incap", i).Value
                If Not IsDBNull(dt_info_gral.Rows(i).Item("valor")) Then
                    dt_cant_incapacidades.Rows(dt_cant_incapacidades.Rows.Count - 1).Item("Valor") += dt_info_gral.Rows(i).Item("valor")
                End If
            End If
        Next
        dt_cant_incapacidades.Rows.Add()
        dt_cant_incapacidades.Rows(dt_cant_incapacidades.Rows.Count - 1).Item("Nombres") = "TOTAL"
        For i = 0 To dt_cant_incapacidades.Columns.Count - 1
            If (dt_cant_incapacidades.Columns(i).ColumnName = "Cantidad" Or dt_cant_incapacidades.Columns(i).ColumnName = "dias_incap" Or dt_cant_incapacidades.Columns(i).ColumnName = "valor") Then
                For j = 0 To dt_cant_incapacidades.Rows.Count - 2
                    If Not IsDBNull(dt_cant_incapacidades.Rows(j).Item(i)) Then
                        sum += dt_cant_incapacidades.Rows(j).Item(i)
                    End If
                Next
                dt_cant_incapacidades.Rows(dt_cant_incapacidades.Rows.Count - 1).Item(i) = sum
                sum = 0
            End If
        Next
        dtg_cant_incapacidades.DataSource = dt_cant_incapacidades
        sql = "	SELECT COUNT(diagnostico ) Cantidad,SUM(valor_pagado) As valor_pagado,diagnostico,descripcion " & _
                          " FROM Jjv_nom_detalle_incap  " & _
                            whereSql & _
                   "GROUP BY diagnostico,descripcion  " & _
                   "ORDER BY Cantidad DESC "
        Dim dt_inc_mas_repiten As DataTable = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        dt_inc_mas_repiten.Rows.Add()
        dt_inc_mas_repiten.Rows(dt_inc_mas_repiten.Rows.Count - 1).Item("descripcion") = "TOTAL"
        For i = 0 To dt_inc_mas_repiten.Columns.Count - 1
            If (dt_inc_mas_repiten.Columns(i).ColumnName = "Cantidad" Or dt_inc_mas_repiten.Columns(i).ColumnName = "valor_pagado") Then
                For j = 0 To dt_inc_mas_repiten.Rows.Count - 2
                    If Not IsDBNull(dt_inc_mas_repiten.Rows(j).Item(i)) Then
                        sum += dt_inc_mas_repiten.Rows(j).Item(i)
                    End If
                Next
                dt_inc_mas_repiten.Rows(dt_inc_mas_repiten.Rows.Count - 1).Item(i) = sum
                sum = 0
            End If
        Next
        dtg_inc_mas_repiten.DataSource = dt_inc_mas_repiten

        Dim selectTotEmp As String = "SELECT COUNT(distinct(p.nit))As tot_emp,mes,ano,centro " & _
                                               "FROM y_pago_nomina p " & _
                                                       "WHERE ano >= " & cbo_fecha_ini.Value.Year & " AND ano <= " & cbo_fecha_fin.Value.Year & "  " & whereCentro & _
                                                                       "GROUP BY mes,ano,centro ORDER BY ano,mes "
        Dim dt_tot_emp As DataTable = objOpSimplesLn.listar_datatable(selectTotEmp, "CORSAN")
        Dim sql_porc_inc As String = "SELECT YEAR (i.fecha_inicial )As Ano,MONTH (i.fecha_inicial)As Mes,i.centro ,i.Descr_centro,SUM (i.dias_incap)As dias_incap,SUM (i.horas)As Horas_inc ,d.Dias_habil*8 As horas_habiles,d.Dias_habil " & _
                   "FROM Jjv_nom_detalle_incap i ,Jjv_dias_habiles d " & _
                          "WHERE  d.Mes = MONTH (i.fecha_inicial) AND d.Ano = YEAR (i.fecha_inicial) AND i .fecha_inicial >='" & fec_ini & "' AND i .fecha_inicial <='" & fec_fin & "' " & whereCentro & _
                    "GROUP BY i.centro ,MONTH (i.fecha_inicial),YEAR (i.fecha_inicial ),i.centro ,i.Descr_centro,d.Dias_habil  " & _
                    "ORDER BY YEAR (i.fecha_inicial ),MONTH (i.fecha_inicial) "
        Dim dt As DataTable = objOpSimplesLn.listar_datatable(sql_porc_inc, "CORSAN")
        Dim mes_encontrado As Boolean = False
        If (chkAusentismo.Checked) Then
            Dim dt_porc_ausentismo As New DataTable
            Dim sql_porc_ausentismo As String = "SELECT YEAR (i.fecha )As Ano,MONTH (i.fecha)As Mes,i.centro ,i.Descr_centro,SUM(horas)/8 As  dias_incap,SUM (i.horas)As Horas_inc ,d.Dias_habil*8 As horas_habiles,d.Dias_habil " & _
                    "FROM Jjv_otros_Ausentismos i ,Jjv_dias_habiles d " & _
                           "WHERE  d.Mes = MONTH (i.fecha) AND d.Ano = YEAR (i.fecha) AND i .fecha >='" & fec_ini & "' AND i .fecha <='" & fec_fin & "' " & whereCentro & _
                     "GROUP BY i.centro ,MONTH (i.fecha),YEAR (i.fecha ),i.centro ,i.Descr_centro,d.Dias_habil  " & _
                     "ORDER BY YEAR (i.fecha ),MONTH (i.fecha) "
            dt_porc_ausentismo = objOpSimplesLn.listar_datatable(sql_porc_ausentismo, "CORSAN")

            For i = 0 To dt_porc_ausentismo.Rows.Count - 1
                For j = 0 To dt.Rows.Count - 1
                    If (dt_porc_ausentismo.Rows(i).Item("ano") = dt.Rows(j).Item("ano") And dt_porc_ausentismo.Rows(i).Item("mes") = dt.Rows(j).Item("mes") And dt_porc_ausentismo.Rows(i).Item("centro") = dt.Rows(j).Item("centro")) Then
                        dt.Rows(j).Item("Horas_inc") += dt_porc_ausentismo.Rows(i).Item("Horas_inc")
                        dt.Rows(j).Item("dias_incap") += dt_porc_ausentismo.Rows(i).Item("dias_incap")
                        mes_encontrado = True
                        j = dt.Rows.Count - 1
                    End If
                Next
                If Not (mes_encontrado) Then
                    dt.Rows.Add()
                    dt.Rows(dt.Rows.Count - 1).Item("Ano") = dt_porc_ausentismo.Rows(i).Item("Ano")
                    dt.Rows(dt.Rows.Count - 1).Item("Mes") = dt_porc_ausentismo.Rows(i).Item("Mes")
                    dt.Rows(dt.Rows.Count - 1).Item("centro") = dt_porc_ausentismo.Rows(i).Item("centro")
                    dt.Rows(dt.Rows.Count - 1).Item("Descr_centro") = dt_porc_ausentismo.Rows(i).Item("Descr_centro")
                    dt.Rows(dt.Rows.Count - 1).Item("dias_incap") = dt_porc_ausentismo.Rows(i).Item("dias_incap")
                    dt.Rows(dt.Rows.Count - 1).Item("Horas_inc") = dt_porc_ausentismo.Rows(i).Item("Horas_inc")
                    dt.Rows(dt.Rows.Count - 1).Item("horas_habiles") = dt_porc_ausentismo.Rows(i).Item("horas_habiles")
                    dt.Rows(dt.Rows.Count - 1).Item("Dias_habil") = dt_porc_ausentismo.Rows(i).Item("Dias_habil")
                End If
            Next
        End If




        dt.Columns.Add("Porc", GetType(Double))
        dt.Columns.Add("tot_emp", GetType(Double))
        dt.Columns.Add("horas_habiles_tot", GetType(Double))
        For i = 0 To dt_tot_emp.Rows.Count - 1
            For j = 0 To dt.Rows.Count - 1
                If (dt_tot_emp.Rows(i).Item("ano") = dt.Rows(j).Item("ano") And dt_tot_emp.Rows(i).Item("mes") = dt.Rows(j).Item("mes")) Then
                    If (centro = 0) Then
                        If (dt_tot_emp.Rows(i).Item("centro") = dt.Rows(j).Item("centro")) Then
                            dt.Rows(j).Item("tot_emp") = dt_tot_emp.Rows(i).Item("tot_emp")
                        End If
                    Else
                        dt.Rows(j).Item("tot_emp") = dt_tot_emp.Rows(i).Item("tot_emp")
                    End If

                End If
            Next
        Next
        For i = 0 To dt.Rows.Count - 1
            If Not (IsDBNull(dt.Rows(i).Item("horas_habiles"))) Then
                If Not (IsDBNull(dt.Rows(i).Item("tot_emp"))) Then
                    dt.Rows(i).Item("horas_habiles_tot") = (dt.Rows(i).Item("horas_habiles") * dt.Rows(i).Item("tot_emp"))
                Else
                    dt.Rows(i).Item("horas_habiles_tot") = 0
                End If
            Else
                dt.Rows(i).Item("horas_habiles_tot") = 0
            End If
        Next
        For i = 0 To dt.Rows.Count - 1
            If Not (IsDBNull(dt.Rows(i).Item("horas_habiles_tot"))) Then
                dt.Rows(i).Item("Porc") = (dt.Rows(i).Item("Horas_inc") / dt.Rows(i).Item("horas_habiles_tot")) * 100
            Else
                dt.Rows(i).Item("Porc") = 0
            End If


        Next

        dtg_porc_inc.DataSource = dt
        trazabilidadAusentismos(centro, fec_ini, fec_fin)
        dtg_porc_inc.Columns("Porc").DefaultCellStyle.Format = "N2"
        dtg_porc_inc.Columns("Porc").DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        dtg_cant_incapacidades.Columns("Cantidad").DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        dtg_traz.Columns("DESCRIPCIÓN").DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        If (dtg_traz.Rows.Count > 0) Then
            dtg_traz.Rows(dtg_traz.Rows.Count - 1).DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
            dtg_traz.Rows(dtg_traz.Rows.Count - 1).DefaultCellStyle.Format = "N2"
        End If
        dtg_consulta.Columns("fecha_inicial").DefaultCellStyle.Format = "d"
        dtg_consulta.Columns("fecha_final").DefaultCellStyle.Format = "d"
        dtg_consulta.Columns("nit").Frozen = True
        dtg_consulta.Columns("nombres").Frozen = True
        dtg_mas_ausentismo.Columns("num_dia").Visible = False
        If (dtg_consulta.Rows.Count > 0) Then
            dtg_consulta.Rows(dtg_consulta.Rows.Count - 1).DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        End If

        If (dtg_mas_ausentismo.Rows.Count) Then
            dtg_mas_ausentismo.Rows(dtg_mas_ausentismo.Rows.Count - 1).DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        End If
        If (dtg_cant_incapacidades.Rows.Count > 0) Then
            dtg_cant_incapacidades.Rows(dtg_cant_incapacidades.Rows.Count - 1).DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        End If
        If (dtg_inc_mas_repiten.Rows.Count > 0) Then
            dtg_inc_mas_repiten.Rows(dtg_inc_mas_repiten.Rows.Count - 1).DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        End If

        dtg_consulta.Columns("dias_incap").DefaultCellStyle.Format = "N1"
        dtg_porc_inc.Columns("dias_incap").DefaultCellStyle.Format = "N1"

        If Not (usuario.permiso.Trim = "ADMIN" Or usuario.permiso.Trim = "NOMINA") Then

            For i = 0 To dtg_consulta.Columns.Count - 1
                If (dtg_consulta.Columns(i).Name = "basico_dia") Then
                    dtg_consulta.Columns("basico_dia").Visible = False
                ElseIf (dtg_consulta.Columns(i).Name = "basico_mes") Then
                    dtg_consulta.Columns("basico_mes").Visible = False
                ElseIf (dtg_consulta.Columns(i).Name = "valor") Then
                    dtg_consulta.Columns("valor").Visible = False
                End If
            Next
            For i = 0 To dtg_cant_incapacidades.Columns.Count - 1
                If (dtg_cant_incapacidades.Columns(i).Name = "valor") Then
                    dtg_cant_incapacidades.Columns("valor").Visible = False
                End If
            Next

            For i = 0 To dtg_mas_ausentismo.Columns.Count - 1
                If (dtg_mas_ausentismo.Columns(i).Name = "Valor") Then
                    dtg_mas_ausentismo.Columns("Valor").Visible = False
                End If
            Next
            For i = 0 To dtg_inc_mas_repiten.Columns.Count - 1
                If (dtg_inc_mas_repiten.Columns(i).Name = "valor_pagado") Then
                    dtg_inc_mas_repiten.Columns("valor_pagado").Visible = False
                End If
            Next

        End If
    End Sub
    Private Sub cargarCbo()
        Dim dt As New DataTable
        Dim dr As DataRow
        Dim sql As String
        Dim where_sql As String = ""
        If (centros <> "") Then
            where_sql &= "WHERE " & centros
        Else
            where_sql &= "WHERE centro IN(1100,1200,2100,2117,2200,2300,2400,2500,2600,2800,3100,3200,3500,4100,4200,4300,5200,6200,6400)"
        End If
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
    End Sub
    Private Sub trazabilidadAusentismos(ByVal centro As Integer, ByVal fec_ini As String, ByVal fec_fin As String)
        Dim whereCentro As String = ""
        If (centro <> 0) Then
            whereCentro = " AND centro = " & cbo_centro.SelectedValue
        End If
        Dim sql_datos_auc As String = "SELECT SUM(horas )/8 As total,MONTH (fecha )As mes ,YEAR (fecha )As ano " & _
                                            "FROM Jjv_otros_Ausentismos " & _
                                      "WHERE  fecha >='" & fec_ini & "' AND fecha <='" & fec_fin & "' " & whereCentro & " " & _
                                        "GROUP BY MONTH (fecha ) ,YEAR (fecha)"
        Dim dt_datos_auc As New DataTable
        Dim fila As Integer = 0
        dt_datos_auc = objOpSimplesLn.listar_datatable(sql_datos_auc, "CORSAN")
        Dim sql_script_modulos As String = "SELECT descripcion_col, script FROM  J_script_modulos WHERE desc_modulo ='" & nomb_modulo & "'"
        Dim dt_script As DataTable = objOpSimplesLn.listar_datatable(sql_script_modulos, "CORSAN")
        Dim sql_consulta As String = ""
        Dim nombMes As String
        For i = 0 To dt_script.Rows.Count - 1
            sql_consulta = modificarSql(dt_script.Rows(i).Item("script"), centro)
            If i = 0 Then
                crearDtTrazabilidad(sql_consulta, dt_script.Rows(i).Item("descripcion_col"))
            Else
                addItem(sql_consulta, dt_script.Rows(i).Item("descripcion_col"), centro)
            End If
        Next
        For i = 0 To dtTrazabilidad.Rows.Count - 1
            If (dtTrazabilidad.Rows(i).Item("DESCRIPCIÓN") = "TOT_DÍAS_AUSENTISMO") Then
                fila = i
                i = dtTrazabilidad.Rows.Count - 1
            End If
        Next
        For i = 0 To dt_datos_auc.Rows.Count - 1
            nombMes = MonthName(dt_datos_auc.Rows(i).Item("mes"), True).ToUpper & "-" & dt_datos_auc.Rows(i).Item("ano")
            For j = 1 To dtTrazabilidad.Columns.Count - 1
                If (dtTrazabilidad.Columns(j).ColumnName = nombMes) Then
                    If Not IsDBNull(dtTrazabilidad.Rows(fila).Item(nombMes)) Then
                        dtTrazabilidad.Rows(fila).Item(nombMes) += dt_datos_auc.Rows(i).Item("total")
                    Else
                        dtTrazabilidad.Rows(fila).Item(nombMes) = dt_datos_auc.Rows(i).Item("total")
                    End If
                    j = dtTrazabilidad.Columns.Count - 1
                End If
            Next
        Next
        datos_calculados_traz()
        dtg_traz.DataSource = dtTrazabilidad
    End Sub
    Private Sub addItem(ByVal sql As String, ByVal descripcion As String, ByVal centro As String)
        dtTrazabilidad.Rows.Add()
        Dim fila As Integer = dtTrazabilidad.Rows.Count - 1
        dtTrazabilidad.Rows(fila).Item("DESCRIPCIÓN") = descripcion
        If (sql <> "") Then
            Dim dtItem As DataTable = objOpSimplesLn.listar_datatable(sql, "CORSAN")
            Dim nombMes As String = ""

            For i = 0 To dtItem.Rows.Count - 1
                nombMes = MonthName(dtItem.Rows(i).Item("mes"), True).ToUpper & "-" & dtItem.Rows(i).Item("ano")
                For j = 1 To dtTrazabilidad.Columns.Count - 1
                    If (dtTrazabilidad.Columns(j).ColumnName = nombMes) Then
                        dtTrazabilidad.Rows(fila).Item(nombMes) = dtItem.Rows(i).Item("total")
                        j = dtTrazabilidad.Columns.Count - 1
                    End If
                Next
            Next
        End If

    End Sub
    Private Sub crearDtTrazabilidad(ByVal sql As String, descripcion As String)
        dtTrazabilidad = New DataTable
        dtTrazabilidad.Columns.Add("DESCRIPCIÓN")
        dtTrazabilidad.Rows.Add()
        dtTrazabilidad.Rows(0).Item("DESCRIPCIÓN") = descripcion
        Dim dtMeses_empleados As DataTable = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        Dim nombMes As String
        For i = 0 To dtMeses_empleados.Rows.Count - 1
            nombMes = MonthName(dtMeses_empleados.Rows(i).Item("mes"), True).ToUpper & "-" & dtMeses_empleados.Rows(i).Item("ano")
            dtTrazabilidad.Columns.Add(nombMes, GetType(Double))
            dtTrazabilidad.Rows(0).Item(nombMes) = dtMeses_empleados.Rows(i).Item("tot_emp")
        Next
    End Sub
    Private Sub datos_calculados_traz()
        Dim col As String = ""
        For i = 1 To dtTrazabilidad.Rows.Count - 1

            Select Case dtTrazabilidad.Rows(i).Item("DESCRIPCIÓN")
                Case "HORAS_HABILES"
                    For j = 1 To dtTrazabilidad.Columns.Count - 1
                        If Not IsDBNull(dtTrazabilidad.Rows(num_fil("DÍAS_HABILES")).Item(j)) Then
                            dtTrazabilidad.Rows(i).Item(j) = dtTrazabilidad.Rows(num_fil("DÍAS_HABILES")).Item(j) * 8
                        End If
                    Next
                Case "TOT_DÍAS_PRODUCTIVOS"
                    For j = 1 To dtTrazabilidad.Columns.Count - 1
                        If (Not IsDBNull(dtTrazabilidad.Rows(num_fil("DÍAS_HABILES")).Item(j)) And Not IsDBNull(dtTrazabilidad.Rows(num_fil("TOT/PERSONAL")).Item(j))) Then
                            dtTrazabilidad.Rows(i).Item(j) = dtTrazabilidad.Rows(num_fil("DÍAS_HABILES")).Item(j) * dtTrazabilidad.Rows(num_fil("TOT/PERSONAL")).Item(j)
                        End If
                    Next
                Case "TOT_HORAS_PRODUCTIVAS"
                    For j = 1 To dtTrazabilidad.Columns.Count - 1
                        If (Not IsDBNull(dtTrazabilidad.Rows(num_fil("HORAS_HABILES")).Item(j)) And Not IsDBNull(dtTrazabilidad.Rows(num_fil("TOT/PERSONAL")).Item(j))) Then
                            dtTrazabilidad.Rows(i).Item(j) = dtTrazabilidad.Rows(num_fil("HORAS_HABILES")).Item(j) * dtTrazabilidad.Rows(num_fil("TOT/PERSONAL")).Item(j)
                        End If

                    Next

                Case "TOT_HORAS_AUSENTISMO"
                    For j = 1 To dtTrazabilidad.Columns.Count - 1
                        col = dtTrazabilidad.Columns(j).ColumnName
                        If Not IsDBNull(dtTrazabilidad.Rows(num_fil("TOT_DÍAS_AUSENTISMO")).Item(j)) Then
                            dtTrazabilidad.Rows(i).Item(j) = dtTrazabilidad.Rows(num_fil("TOT_DÍAS_AUSENTISMO")).Item(j) * 8
                        End If
                    Next

                Case "PRODUCCION_vs_AUSENTISMO"
                    For j = 1 To dtTrazabilidad.Columns.Count - 1
                        If Not IsDBNull(dtTrazabilidad.Rows(num_fil("TOT_HORAS_AUSENTISMO")).Item(j)) And Not IsDBNull(dtTrazabilidad.Rows(num_fil("TOT_HORAS_PRODUCTIVAS")).Item(j)) Then
                            dtTrazabilidad.Rows(i).Item(j) = (dtTrazabilidad.Rows(num_fil("TOT_HORAS_AUSENTISMO")).Item(j) / dtTrazabilidad.Rows(num_fil("TOT_HORAS_PRODUCTIVAS")).Item(j)) * 100
                        End If
                    Next
            End Select

        Next
    End Sub
    Private Function num_fil(ByVal nomb_item) As Integer
        For i = 0 To dtTrazabilidad.Rows.Count - 1
            If (nomb_item = dtTrazabilidad.Rows(i).Item("DESCRIPCIÓN")) Then
                Return i
            End If
        Next
        Return 0
    End Function
    Private Function modificarSql(ByVal sql As String, ByVal centro As Integer) As String
        Dim mes As Integer = cbo_fecha_ini.Value.Month
        Dim ano As Integer = cbo_fecha_ini.Value.Year
        Dim mes_fin As Integer = cbo_fecha_fin.Value.Month
        Dim ano_fin As Integer = cbo_fecha_fin.Value.Year
        Dim sFec_ini As String = objOpSimplesLn.cambiarFormatoFecha(cbo_fecha_ini.Value)
        Dim sFec_fin As String = objOpSimplesLn.cambiarFormatoFecha(cbo_fecha_fin.Value)

        sql = Replace(sql, "@mes_fin", mes_fin)
        sql = Replace(sql, "@ano_fin", ano_fin)
        sql = Replace(sql, "@mes", mes)
        sql = Replace(sql, "@ano", ano)

        sql = Replace(sql, "@mes_fin", mes_fin)
        sql = Replace(sql, "@ano_fin", ano)
        sql = Replace(sql, "@fec_ini", sFec_ini)
        sql = Replace(sql, "@fec_fin", sFec_fin)
        If (centro <> 0) Then
            sql = Replace(sql, "AND centro =@centro", "AND centro =" & centro)
        Else
            sql = Replace(sql, "AND centro =@centro", "")
        End If
        Return sql
    End Function
    Private Sub tool_info_general_Click(sender As System.Object, e As System.EventArgs) Handles tool_info_general.Click
        objOperacionesForm.ExportarDatosExcel(dtg_consulta, tool_info_general.Text)
    End Sub

    Private Sub tool_mas_ausent_Click(sender As System.Object, e As System.EventArgs) Handles tool_mas_ausent.Click
        objOperacionesForm.ExportarDatosExcel(dtg_mas_ausentismo, tool_mas_ausent.Text)
    End Sub

    Private Sub tool_cant_ausent_Click(sender As System.Object, e As System.EventArgs) Handles tool_cant_ausent.Click
        objOperacionesForm.ExportarDatosExcel(dtg_cant_incapacidades, tool_cant_ausent.Text)
    End Sub

    Private Sub tool_mas_rep_Click(sender As System.Object, e As System.EventArgs) Handles tool_mas_rep.Click
        objOperacionesForm.ExportarDatosExcel(dtg_inc_mas_repiten, tool_mas_rep.Text)
    End Sub

    Private Sub tool_porc_incap_Click(sender As System.Object, e As System.EventArgs) Handles tool_porc_incap.Click
        objOperacionesForm.ExportarDatosExcel(dtg_porc_inc, tool_porc_incap.Text)
    End Sub
    Private Sub Filtrar_DataGridView( _
      ByVal Columna As String, _
      ByVal texto As String, _
      ByVal BindingSource As BindingSource, _
      ByVal DataGridView As DataGridView)

        ' verificar que el DataSource no esté vacio  
        If bsDetalleAusentismos.DataSource Is Nothing Then
            Exit Sub
        End If

        Try
            imgProcesar.Visible = True
            Application.DoEvents()

            Dim filtro As String = String.Empty

            filtro = "like '%" & texto.Trim & "%'"
            ' Opción para no filtrar  



            ' armar el sql  
            filtro = "([" & Columna & "]" & filtro & " OR [" & Columna & "] like '%TOTAL%' ) "


            ' asigar el criterio a la propiedad Filter del BindingSource  
            BindingSource.Filter = filtro
            ' enlzar el datagridview al BindingSource  
            DataGridView.DataSource = BindingSource.DataSource
            Dim column As DataGridViewColumn = DataGridView.Columns("nit")
            DataGridView.Sort(column, SortOrder.Ascending)

            totalizarInfoGral()
            ' retornar la cantidad de registros encontrados  

            ' errores  
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
        End Try
        imgProcesar.Visible = False
    End Sub

    Private Sub btnFltNombre_Click(sender As System.Object, e As System.EventArgs) Handles btnFltNombre.Click
        Filtrar_DataGridView("nombres", txtBuscarNombre.Text, bsDetalleAusentismos, dtg_consulta)
    End Sub

    Private Sub chkBuscTodo_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkBuscTodo.CheckedChanged
        If (chkBuscTodo.Checked) Then
            txtBuscarNombre.Text = ""
        End If
    End Sub
    Private Sub totalizarInfoGral()
        Dim tamano_letra As Single = 9.0!
        Dim fila As Integer = buscarNumFila("nombres", "TOTAL", dtg_consulta)
        Dim sum As Double = 0
        For j = 0 To dtg_consulta.Columns.Count - 1
            If (dtg_consulta.Columns(j).Name = "basico_mes" Or dtg_consulta.Columns(j).Name = "basico_dia" Or dtg_consulta.Columns(j).Name = "valor" Or dtg_consulta.Columns(j).Name = "dias_incap") Then
                For i = 0 To dtg_consulta.Rows.Count - 1
                    If i <> fila Then
                        If Not IsDBNull(dtg_consulta.Item(j, i).Value) Then
                            sum += dtg_consulta.Item(j, i).Value
                        End If
                    End If
                Next
                dtg_consulta.Item(j, fila).Value = sum
                sum = 0
            End If
        Next
        dtg_consulta.Rows(fila).DefaultCellStyle = objOperacionesForm.formatoNegrita(tamano_letra)
        dtg_consulta.Rows(fila).DefaultCellStyle.BackColor = Color.Red
    End Sub
    Private Function buscarNumFila(ByVal nomb_col As String, ByVal texto_fila As String, ByVal dtg As DataGridView) As Integer
        For i = 0 To dtg.Rows.Count - 1
            If Not IsDBNull(dtg.Item(nomb_col, i).Value) Then
                If (dtg.Item(nomb_col, i).Value.ToString = texto_fila) Then
                    Return i
                End If
            End If
        Next
        Return 0
    End Function
    Private Sub tendencia()
        dtg_tendencia.DataSource = Nothing
        Dim tamano_letra As Single = 9.0!
        Dim ano_ini As Integer = cbo_fecha_ini.Value.Year
        Dim ano_fin As Integer = cbo_fecha_fin.Value.Year
        Dim dt As New DataTable
        If chk_consol_mes.Checked Then
            dt = armar_dt_tendencia_mes(cbo_fecha_ini.Value, cbo_fecha_fin.Value)
        Else
            dt = armar_dt_tendencia(ano_ini, ano_fin)
        End If
        dtg_tendencia.DataSource = dt
        For j = 0 To dtg_tendencia.Columns.Count - 1
            If buscarTexto(dtg_tendencia.Columns(j).Name, "%") Then
                dtg_tendencia.Columns(j).DefaultCellStyle.Format = "N2"
            End If
        Next
        dtg_tendencia.CurrentCell = Nothing
        Dim column As New DataGridViewColumn
        If chk_consol_mes.Checked Then
            column = dtg_tendencia.Columns("H-" & cbo_fecha_ini.Value.Month & "-" & MonthName(cbo_fecha_ini.Value.Month, True).ToUpper & "_" & ano_ini)
        Else
            column = dtg_tendencia.Columns("Horas-" & ano_ini)
        End If

        dtg_tendencia.Sort(column, SortOrder.Ascending)
        dtg_tendencia.Rows(0).DefaultCellStyle = objOperacionesForm.formatoNegrita(tamano_letra)
        pintar_porc(dtg_tendencia)
    End Sub
    Private Sub pintar_porc(ByRef dtg As DataGridView)
        Dim val_porc As Double = 0
        Dim may_val As Double = 100
        For j = 0 To dtg.Columns.Count - 1
            If buscarTexto(dtg.Columns(j).Name, "%Part") Then
                For i = 0 To dtg.Rows.Count - 1
                    If i = 1 Then
                        If IsNumeric(dtg.Item(j, i).Value) Then
                            may_val = dtg.Item(j, i).Value
                        End If
                    End If
                    If IsNumeric(dtg.Item(j, i).Value) Then
                        val_porc = (dtg.Item(j, i).Value / may_val) * 100
                        dtg.Item(j, i).Style.BackColor = objOperacionesForm.return_color_menos_bien(val_porc)
                    End If
                Next
                may_val = 100
            End If
        Next

    End Sub
    Private Function armar_dt_tendencia(ByVal ano_ini As Integer, ByVal ano_fin As Integer) As DataTable
        Dim dt As New DataTable
        dt.Columns.Add("Concepto", GetType(Double))
        dt.Columns.Add("Causa")
        For ano = ano_ini To ano_fin
            dt.Columns.Add("Horas-" & ano, GetType(Double))
            dt.Columns.Add("Dias-" & ano, GetType(Double))
            dt.Columns.Add("Costo-" & ano, GetType(Double))
            If ano = ano_fin Then
                dt.Columns.Add("$-Tendencia-" & ano, GetType(Double))
                dt.Columns.Add("H-Tendencia-" & ano, GetType(Double))
            Else
                dt.Columns.Add("%Horas-" & ano, GetType(Double))
                dt.Columns.Add("%Costo-" & ano, GetType(Double))
            End If
            dt.Columns.Add("%Part-" & ano, GetType(Double))
        Next
        add_conceptos(dt)
        add_tendencia(dt, ano_ini, ano_fin)
        totalizar_dt_tendencia(dt)
        calcular_porc_tendencia(dt)
        Return dt
    End Function
    Private Sub add_conceptos(ByRef dt As DataTable)
        Dim sql As String = "SELECT concepto,descripcion " & _
                                "FROM y_conceptos_nom " & _
                                  "WHERE concepto IN (" & conceptos & ")  " & _
                                      "ORDER BY concepto"
        Dim dt_conceptos As DataTable = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        For i = 0 To dt_conceptos.Rows.Count - 1
            dt.Rows.Add()
            dt.Rows(dt.Rows.Count - 1).Item("Causa") = dt_conceptos.Rows(i).Item("descripcion")
            dt.Rows(dt.Rows.Count - 1).Item("concepto") = dt_conceptos.Rows(i).Item("concepto")
        Next
    End Sub
    Private Sub add_tendencia(ByRef dt As DataTable, ByVal ano_ini As Integer, ByVal ano_fin As Integer)
        Dim whereSql As String = "WHERE concepto IN (" & conceptos & ") AND ano BETWEEN " & ano_ini & " AND " & ano_fin & " "
        Dim centro As Integer = cbo_centro.SelectedValue
        Dim whereCentro As String = ""
        Dim sql_diagnostico As String = ""
        If (cbo_centro.Text <> "TODO") Then
            whereSql &= "AND centro =" & centro & " "
            whereCentro = " AND centro =" & centro & " "
        Else
            If (centros <> "") Then
                whereCentro = " AND " & centros & " "
            End If
        End If
        whereSql &= whereCentro
        Dim sql As String = "SELECT ano,concepto,SUM(VrtotAusent ) As vr_total , SUM(TotHorasAusent ) As horas " & _
                                "FROM Jjv_ausentismo " & _
                                 whereSql & _
                                     "GROUP BY ano,concepto " & _
                                        "	ORDER BY ano"
        Dim dt_datos As DataTable = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        For i = 0 To dt_datos.Rows.Count - 1
            For k = 0 To dt.Rows.Count - 1
                If IsNumeric(dt.Rows(k).Item("concepto")) Then
                    For j = 2 To dt.Columns.Count - 1
                        If dt.Rows(k).Item("concepto") = dt_datos.Rows(i).Item("concepto") Then
                            If extraer_ano_nom_col(dt.Columns(j).ColumnName, False) = dt_datos.Rows(i).Item("ano") Then
                                If buscarTexto(dt.Columns(j).ColumnName, "Costo") And Not buscarTexto(dt.Columns(j).ColumnName, "%") Then
                                    dt.Rows(k).Item(j) = dt_datos.Rows(i).Item("vr_total")
                                ElseIf (buscarTexto(dt.Columns(j).ColumnName, "Horas") And Not buscarTexto(dt.Columns(j).ColumnName, "%")) Then
                                    dt.Rows(k).Item(j) = dt_datos.Rows(i).Item("horas")
                                ElseIf (buscarTexto(dt.Columns(j).ColumnName, "Dias") And Not buscarTexto(dt.Columns(j).ColumnName, "%")) Then
                                    dt.Rows(k).Item(j) = dt_datos.Rows(i).Item("horas") / 8
                                End If
                            End If
                        End If
                    Next
                End If
            Next
        Next
    End Sub
    Function buscarTexto(ByVal nom_col As String, ByVal busqueda As String) As Boolean
        Dim i As Integer
        i = InStr(1, nom_col, busqueda)
        If i > 0 Then
            BuscarTexto = True
        Else
            BuscarTexto = False
        End If
    End Function
    Private Sub calcular_porc_tendencia(ByRef dt As DataTable)
        Dim ano As Integer = 0
        Dim col_destino As Integer
        Dim col_1 As Integer
        Dim col_2 As Integer
        Dim col_porc_part As Integer = 0
        Dim tot_horas As Double = 0
        For j = 2 To dt.Columns.Count - 1
            If IsNumeric(extraer_ano_nom_col(dt.Columns(j).ColumnName, False)) Then
                ano = extraer_ano_nom_col(dt.Columns(j).ColumnName, False)
                If buscarTexto(dt.Columns(j).ColumnName, "Costo") And Not buscarTexto(dt.Columns(j).ColumnName, "%") Then
                    col_destino = bucar_col_tendencia(dt, "%" & dt.Columns(j).ColumnName)
                    If col_destino <> 0 Then
                        col_1 = j
                        col_2 = bucar_col_tendencia(dt, "Costo-" & ano + 1)
                        If col_2 <> 0 Then
                            calcular_porc(dt, col_destino, col_1, col_2)
                        End If
                    Else
                        col_1 = j
                        calcular_tendencia(dt, "$-Tendencia-" & ano, col_1)
                    End If
                ElseIf (buscarTexto(dt.Columns(j).ColumnName, "Horas") And Not buscarTexto(dt.Columns(j).ColumnName, "%")) Then
                    col_destino = bucar_col_tendencia(dt, "%" & dt.Columns(j).ColumnName)
                    col_porc_part = bucar_col_tendencia(dt, "%Part-" & ano)
                    tot_horas = dt.Rows(dt.Rows.Count - 1).Item("Horas-" & ano)
                    For i = 0 To dt.Rows.Count - 1
                        If IsNumeric(dt.Rows(i).Item("Horas-" & ano)) Then
                            dt.Rows(i).Item(col_porc_part) = (dt.Rows(i).Item("Horas-" & ano) / tot_horas) * 100
                        End If
                    Next
                    If col_destino <> 0 Then
                        col_1 = j
                        col_2 = bucar_col_tendencia(dt, "Horas-" & ano + 1)
                        If col_2 <> 0 Then
                            calcular_porc(dt, col_destino, col_1, col_2)
                        End If
                    Else
                        col_1 = j
                        calcular_tendencia(dt, "H-Tendencia-" & ano, col_1)
                    End If
                End If
            End If
            col_destino = 0
            col_1 = 0
            col_2 = 0
        Next

       
    End Sub
    Private Sub calcular_porc(ByRef dt As DataTable, ByVal col_destino As Integer, ByVal col_1 As Integer, ByVal col_2 As Integer)
        Dim comienzo As Integer = 0
        If Not chk_consol_mes.Checked Then
            comienzo = 1
        End If
        For i = comienzo To dt.Rows.Count - 1
            If IsNumeric(dt.Rows(i).Item(dt.Columns(col_1).ColumnName)) And IsNumeric(dt.Rows(i).Item(dt.Columns(col_2).ColumnName)) Then
                If dt.Rows(i).Item(col_2) > 0 Then
                    dt.Rows(i).Item(dt.Columns(dt.Columns(col_destino).ColumnName).ColumnName) = (dt.Rows(i).Item(dt.Columns(col_1).ColumnName) / dt.Rows(i).Item(dt.Columns(col_2).ColumnName)) * 100
                Else
                    dt.Rows(i).Item(dt.Columns(col_destino).ColumnName) = 0
                End If
            Else
                dt.Rows(i).Item(dt.Columns(col_destino).ColumnName) = 0
            End If
        Next
    End Sub
    Private Sub calcular_tendencia(ByRef dt As DataTable, ByVal col_destino As String, ByVal col_1 As Integer)
        For i = 0 To dt.Rows.Count - 1
            If IsNumeric(dt.Rows(i).Item(col_1)) Then
                dt.Rows(i).Item(col_destino) = (dt.Rows(i).Item(dt.Columns(col_1).ColumnName) / Now.Month) * 12
            Else
                dt.Rows(i).Item(col_destino) = 0
            End If
        Next
    End Sub
    Private Sub calcular_tendencia_mes(ByRef dt As DataTable, ByVal col_destino As String, ByVal ano As Integer, ByVal tipo As String)
        Dim cant As Integer = 0
        Dim total As Double = 0
        For i = 0 To dt.Rows.Count - 1
            For j = 0 To dt.Columns.Count - 1
                If ((buscarTexto(dt.Columns(j).ColumnName, tipo)) And Not buscarTexto(dt.Columns(j).ColumnName, "%") And Not buscarTexto(dt.Columns(j).ColumnName, "Tendencia")) Then
                    If extraer_ano_nom_col(dt.Columns(j).ColumnName, True) = ano Then
                        cant += 1
                        If IsNumeric(dt.Rows(i).Item(j)) Then
                            total += dt.Rows(i).Item(j)
                        End If
                    End If
                End If
            Next
            dt.Rows(i).Item(col_destino) = (total / cant) * 12
            cant = 0
            total = 0
        Next
    End Sub
    Private Function bucar_col_tendencia(ByRef dt As DataTable, ByVal nom_col As String) As Integer
        For j = 0 To dt.Columns.Count - 1
            If dt.Columns(j).ColumnName = nom_col Then
                Return j
            End If
        Next
        Return 0
    End Function
    Private Sub totalizar_dt_tendencia(ByRef dt As DataTable)
        Dim sum As Double = 0
        dt.Rows.Add()
        dt.Rows(dt.Rows.Count - 1).Item("Causa") = "TOTAL"
        For j = 0 To dt.Columns.Count - 1
            If Not buscarTexto(dt.Columns(j).ColumnName, "%") And dt.Columns(j).ColumnName <> "Concepto" And dt.Columns(j).ColumnName <> "Causa" Then
                For i = 0 To dt.Rows.Count - 2
                    If Not IsDBNull(dt.Rows(i).Item(j)) Then
                        If IsNumeric(dt.Rows(i).Item(j)) Then
                            sum += dt.Rows(i).Item(j)
                        End If
                    End If
                Next
                dt.Rows(dt.Rows.Count - 1).Item(j) = sum
                sum = 0
            End If
        Next
    End Sub
    Private Function armar_dt_tendencia_mes(ByVal fec_ini As Date, ByVal fec_fin As Date) As DataTable
        Dim dt As New DataTable
        Dim nombMes As String = ""
        Dim num_mes As Integer = 0
        Dim num_ano As Integer = 0
        Dim agrego_tendencia As Boolean = False
        Dim fec As Date = fec_ini
        dt.Columns.Add("Concepto", GetType(Double))
        dt.Columns.Add("Causa")
        Dim cant_meses As Integer = DateDiff(DateInterval.Month, fec_ini, fec_fin)
        For i = 0 To cant_meses
            num_mes = fec.Month
            num_ano = fec.Year
            nombMes = num_mes & "-" & MonthName(num_mes, True).ToUpper & "_" & num_ano
            dt.Columns.Add("H-" & nombMes, GetType(Double))
            dt.Columns.Add("$-" & nombMes, GetType(Double))
            dt.Columns.Add("D-" & nombMes, GetType(Double))
            If num_ano = fec_fin.Year And num_mes = fec_fin.Month And agrego_tendencia = False Then
                agrego_tendencia = True
                dt.Columns.Add("H-Tendencia_" & num_ano, GetType(Double))
                dt.Columns.Add("D-Tendencia_" & num_ano, GetType(Double))
                dt.Columns.Add("$-Tendencia_" & num_ano, GetType(Double))
            Else
                dt.Columns.Add("%H-" & nombMes, GetType(Double))
                dt.Columns.Add("%$-" & nombMes, GetType(Double))
                dt.Columns.Add("%Part-" & nombMes, GetType(Double))
            End If
            fec = fec.AddMonths(+1)
        Next
        add_conceptos(dt)
        add_tendencia_mes(dt, fec_ini, fec_fin)
        totalizar_dt_tendencia(dt)
        calcular_porc_tendencia_mes(dt)
        Return dt
    End Function
    Private Sub add_tendencia_mes(ByRef dt As DataTable, ByVal fec_ini As Date, ByVal fec_fin As Date)
        Dim sql_conector As String = ""
        'Se conecta para hacer el filtro perfecto de  ranto de fecha inicial y final
        Dim whereSql As String = "WHERE concepto IN (" & conceptos & ") AND ano >= " & fec_ini.Year & " "
        Dim centro As Integer = cbo_centro.SelectedValue
        Dim whereCentro As String = ""
        Dim sql_diagnostico As String = ""
        If (cbo_centro.Text <> "TODO") Then
            whereSql &= "AND centro =" & centro & " "
            whereCentro = " AND centro =" & centro & " "
        Else
            If (centros <> "") Then
                whereCentro = " AND " & centros & " "
            End If
        End If
        whereSql &= whereCentro
        Dim sql As String = "SELECT ano,mes,concepto,SUM(VrtotAusent ) As vr_total , SUM(TotHorasAusent ) As horas " & _
                                "FROM Jjv_ausentismo " & _
                                  whereSql & _
                                     "GROUP BY ano,mes,concepto " & _
                                        "	ORDER BY ano,mes"
        Dim dt_datos As DataTable = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        For i = 0 To dt_datos.Rows.Count - 1
            For k = 0 To dt.Rows.Count - 1
                If IsNumeric(dt.Rows(k).Item("concepto")) Then
                    For j = 2 To dt.Columns.Count - 1
                        If dt.Rows(k).Item("concepto") = dt_datos.Rows(i).Item("concepto") Then
                            If Not buscarTexto(dt.Columns(j).ColumnName, "Tendencia") Then
                                If extraer_mes_nom_col(dt.Columns(j).ColumnName) = dt_datos.Rows(i).Item("mes") And extraer_ano_nom_col(dt.Columns(j).ColumnName, True) = dt_datos.Rows(i).Item("ano") Then
                                    If buscarTexto(dt.Columns(j).ColumnName, "$") And Not buscarTexto(dt.Columns(j).ColumnName, "%") Then
                                        dt.Rows(k).Item(j) = dt_datos.Rows(i).Item("vr_total")
                                    ElseIf (buscarTexto(dt.Columns(j).ColumnName, "H") And Not buscarTexto(dt.Columns(j).ColumnName, "%")) Then
                                        dt.Rows(k).Item(j) = dt_datos.Rows(i).Item("horas")
                                    ElseIf (buscarTexto(dt.Columns(j).ColumnName, "D-") And Not buscarTexto(dt.Columns(j).ColumnName, "%")) Then
                                        dt.Rows(k).Item(j) = dt_datos.Rows(i).Item("horas") / 8
                                    End If
                                End If
                            End If
                        End If
                    Next
                End If
            Next
        Next
    End Sub
    Private Function extraer_mes_nom_col(ByVal texto As String) As Integer
        Dim mes As String = ""
        Dim grabar As Boolean = False
        For i = 0 To texto.Count - 1
            If texto(i) = "-" Then
                grabar = True
            End If
            If mes <> "" And texto(i) = "-" Then
                grabar = False
                i = texto.Count - 1
            End If
            If grabar Then
                If IsNumeric(texto(i)) Then
                    mes &= texto(i)
                End If
            End If
        Next
        Return mes
    End Function
    Private Function extraer_ano_nom_col(ByVal texto As String, ByVal es_mes As Boolean) As Integer
        Dim ano As String = ""
        Dim grabar As Boolean = False
        For i = 0 To texto.Count - 1
            If texto(i) = "_" And es_mes Then
                grabar = True
            ElseIf texto(i) = "-" And es_mes = False Then
                grabar = True
            End If
            If grabar Then
                If IsNumeric(texto(i)) Then
                    ano &= texto(i)
                End If
            End If
        Next
        Return ano
    End Function
    Private Sub calcular_porc_tendencia_mes(ByRef dt As DataTable)
        Dim num_mes As Integer = 0
        Dim num_ano As Integer = 0
        Dim nombMes As String = ""
        Dim nombMes_col_2 As String = ""
        Dim col_destino As String
        Dim col_1 As Integer
        Dim col_2 As Integer
        Dim col_porc_part As Integer = 0
        Dim tot_horas As Integer = 0
        For j = 2 To dt.Columns.Count - 1
            If Not buscarTexto(dt.Columns(j).ColumnName, "Tendencia") Then
                num_mes = extraer_mes_nom_col(dt.Columns(j).ColumnName)
                num_ano = extraer_ano_nom_col(dt.Columns(j).ColumnName, True)
                If num_mes <> 0 And num_ano <> 0 Then
                    nombMes = num_mes & "-" & MonthName(num_mes, True).ToUpper & "_" & num_ano
                    If num_mes = 12 Then
                        nombMes_col_2 = 1 & "-" & MonthName(1, True).ToUpper & "_" & num_ano + 1
                    Else
                        nombMes_col_2 = num_mes + 1 & "-" & MonthName(num_mes + 1, True).ToUpper & "_" & num_ano
                    End If
                    If buscarTexto(dt.Columns(j).ColumnName, "$") And Not buscarTexto(dt.Columns(j).ColumnName, "%") Then
                        col_destino = bucar_col_tendencia(dt, "%$" & "-" & nombMes)
                        If col_destino <> 0 Then
                            col_1 = j
                            col_2 = bucar_col_tendencia(dt, "$-" & nombMes_col_2)
                            If col_2 <> 0 Then
                                calcular_porc(dt, col_destino, col_1, col_2)
                            End If
                        End If
                    ElseIf (buscarTexto(dt.Columns(j).ColumnName, "H") And Not buscarTexto(dt.Columns(j).ColumnName, "%")) Then
                        col_destino = bucar_col_tendencia(dt, "%H" & "-" & nombMes)
                        col_porc_part = bucar_col_tendencia(dt, "%Part-" & nombMes)
                        tot_horas = dt.Rows(dt.Rows.Count - 1).Item("H-" & nombMes)
                        If col_porc_part <> 0 Then
                            For i = 0 To dt.Rows.Count - 1
                                If IsNumeric(dt.Rows(i).Item("H-" & nombMes)) Then
                                    dt.Rows(i).Item(col_porc_part) = (dt.Rows(i).Item("H-" & nombMes) / tot_horas) * 100
                                End If
                            Next
                        End If
                        If col_destino <> 0 Then
                            col_1 = j
                            col_2 = bucar_col_tendencia(dt, "H-" & nombMes_col_2)
                            If col_2 <> 0 Then
                                calcular_porc(dt, col_destino, col_1, col_2)
                            End If
                        End If
                    End If
                End If
            Else
                num_ano = extraer_ano_nom_col(dt.Columns(j).ColumnName, True)
                If buscarTexto(dt.Columns(j).ColumnName, "$") And Not buscarTexto(dt.Columns(j).ColumnName, "%") Then
                    calcular_tendencia_mes(dt, "$-Tendencia_" & num_ano, num_ano, "$")
                ElseIf (buscarTexto(dt.Columns(j).ColumnName, "H") And Not buscarTexto(dt.Columns(j).ColumnName, "%")) Then
                    calcular_tendencia_mes(dt, "H-Tendencia_" & num_ano, num_ano, "H")
                End If
            End If
            col_destino = 0
            col_1 = 0
            col_2 = 0
        Next

    End Sub

    Private Sub TendenciaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TendenciaToolStripMenuItem.Click
        objOperacionesForm.ExportarDatosExcel(dtg_tendencia, "Tendencia")
    End Sub
    Private Sub dtg_tendencia_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dtg_tendencia.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            With (Me.dtg_tendencia)
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                End If
            End With
        End If
    End Sub
    Private Sub dtg_detalle_tendencia_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dtg_detalle_tendencia.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            With (Me.dtg_detalle_tendencia)
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                End If
            End With
        End If
    End Sub
    Private Sub dtg_det_empleado_tendencia_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dtg_det_empleado.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            With (Me.dtg_det_empleado)
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                End If
            End With
        End If
    End Sub
    Private Sub item_detalle_Click(sender As Object, e As EventArgs) Handles item_detalle.Click
        Dim tamano_letra As Single = 9.0!
        groupDetalleTendencia.Visible = True
        groupDetalleTendencia.BringToFront()
        Dim concepto As Integer = 0
        Dim ano As Integer = 0
        Dim sql As String = ""
        Dim dt As New DataTable
        Dim tot_horas As Double = 0
        Dim fila_total As Integer = 0
        For i = 0 To dtg_tendencia.Rows.Count - 1
            If dtg_tendencia.Item("CAUSA", i).Value = "TOTAL" Then
                fila_total = i
                i = dtg_tendencia.Rows.Count - 1
            End If
        Next
        Dim tot_horas_general As Double = 0
        If IsNumeric(dtg_tendencia("concepto", dtg_tendencia.CurrentCell.RowIndex).Value) Then
            concepto = dtg_tendencia("concepto", dtg_tendencia.CurrentCell.RowIndex).Value
        End If
        If chk_consol_mes.Checked Then
            ano = extraer_ano_nom_col(dtg_tendencia.Columns(dtg_tendencia.CurrentCell.ColumnIndex).Name, True)
            Dim mes As Integer = extraer_mes_nom_col(dtg_tendencia.Columns(dtg_tendencia.CurrentCell.ColumnIndex).Name)
            tot_horas_general = dtg_tendencia("H-" & mes & "-" & MonthName((mes), True).ToUpper & "_" & ano, fila_total).Value
            sql = sql_detalle_mes(ano, mes, concepto)
        Else
            ano = extraer_ano_nom_col(dtg_tendencia.Columns(dtg_tendencia.CurrentCell.ColumnIndex).Name, False)
            tot_horas_general = dtg_tendencia("Horas-" & ano, fila_total).Value
            sql = sql_detalle_ano(ano, concepto)
        End If
        dt = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        dt.Columns.Add("%Part-concepto", GetType(Double))
        dt.Columns.Add("%Part-total", GetType(Double))
        totalizar_dt(dt)
        tot_horas = dt.Rows(dt.Rows.Count - 1).Item("horas")
        For i = 0 To dt.Rows.Count - 1
            If IsNumeric(dt.Rows(i).Item("horas")) Then
                dt.Rows(i).Item("%Part-concepto") = (dt.Rows(i).Item("horas") / tot_horas) * 100
                dt.Rows(i).Item("%Part-total") = (dt.Rows(i).Item("horas") / tot_horas_general) * 100
            End If
        Next
        dtg_detalle_tendencia.DataSource = dt
        Dim column As DataGridViewColumn = dtg_detalle_tendencia.Columns("horas")
        dtg_detalle_tendencia.Sort(column, SortOrder.Ascending)
        dtg_detalle_tendencia.Rows(0).DefaultCellStyle = objOperacionesForm.formatoNegrita(tamano_letra)
        dtg_detalle_tendencia.Columns("%Part-concepto").DefaultCellStyle.Format = "N2"
        dtg_detalle_tendencia.Columns("%Part-total").DefaultCellStyle.Format = "N2"
        pintar_porc(dtg_detalle_tendencia)
    End Sub

    Private Sub btn_cerrar_Click(sender As Object, e As EventArgs) Handles btn_cerrar.Click
        groupDetalleTendencia.Visible = False
    End Sub
    Private Function sql_detalle_mes(ByVal ano As Integer, ByVal mes As Integer, ByVal concepto As Integer) As String
        Dim sql_tot_emp As String = "SELECT COUNT(distinct(nit))As tot_emp " & _
                                        "FROM y_liquidacion "
        Dim whereSql As String = "WHERE concepto  = concepto AND ano = " & ano & " AND mes = " & mes & " "
        sql_tot_emp &= whereSql
        Dim tot_empleados_activos As Double = objOpSimplesLn.consultarVal(sql_tot_emp)
        lbl_tot_empleados.Text = MonthName(mes, True) & "-" & ano & " : " & tot_empleados_activos
        Dim centro As Integer = cbo_centro.SelectedValue
        Dim whereCentro As String = ""
        Dim sql_diagnostico As String = ""
        If (cbo_centro.Text <> "TODO") Then
            whereSql &= "AND centro =" & centro & " "
            whereCentro = " AND centro =" & centro & " "
        Else
            If (centros <> "") Then
                whereCentro = " AND " & centros & " "
            End If
        End If
        If concepto <> 0 Then
            whereSql &= "AND concepto =" & concepto & " "
        Else
            whereSql &= "AND concepto IN(" & conceptos & ") "
        End If
        whereSql &= whereCentro
        Dim sql As String = "SELECT ano,mes,centro,nom_cent ,concepto,SUM(VrtotAusent ) As vr_total , SUM(TotHorasAusent ) As horas, SUM(TotHorasAusent )/8 As dias " & _
                                "FROM Jjv_ausentismo " & _
                                  whereSql & _
                                     "GROUP BY ano,mes,concepto,centro,nom_cent  " & _
                                        "	ORDER BY ano,mes"
        Return sql
    End Function
    Private Function sql_detalle_ano(ByVal ano As Integer, ByVal concepto As Integer) As String
        Dim sql_tot_emp As String = "SELECT COUNT(distinct(nit))As tot_emp " & _
                                            "FROM y_liquidacion "
        Dim whereSql As String = "WHERE  ano = " & ano & "  "
        sql_tot_emp &= whereSql
        Dim tot_empleados_activos As Double = objOpSimplesLn.consultarVal(sql_tot_emp)
        lbl_tot_empleados.Text = "año " & ano & " : " & tot_empleados_activos
        Dim centro As Integer = cbo_centro.SelectedValue
        Dim whereCentro As String = ""
        Dim sql_diagnostico As String = ""
        If (cbo_centro.Text <> "TODO") Then
            whereSql &= "AND centro =" & centro & " "
            whereCentro = " AND centro =" & centro & " "
        Else
            If (centros <> "") Then
                whereCentro = " AND " & centros & " "
            End If
        End If
        If concepto <> 0 Then
            whereSql &= "AND concepto =" & concepto & " "
        End If
        whereSql &= whereCentro
        Dim sql As String = "SELECT ano,centro,nom_cent ,concepto,SUM(VrtotAusent ) As vr_total , SUM(TotHorasAusent ) As horas, SUM(TotHorasAusent ) / 8   As dias " & _
                                "FROM Jjv_ausentismo " & _
                                  whereSql & _
                                     "GROUP BY ano,concepto,centro,nom_cent  " & _
                                        "	ORDER BY ano"
        Return sql
    End Function
    Private Sub totalizar_dt(ByRef dt As DataTable)
        Dim sum As Double = 0
        dt.Rows.Add()
        For j = 0 To dt.Columns.Count - 1
            If Not buscarTexto(dt.Columns(j).ColumnName, "centro") And dt.Columns(j).ColumnName <> "mes" And dt.Columns(j).ColumnName <> "ano" And dt.Columns(j).ColumnName <> "desc_centro" And dt.Columns(j).ColumnName <> "nombres" And dt.Columns(j).ColumnName <> "nit" And dt.Columns(j).ColumnName <> "ano" And dt.Columns(j).ColumnName <> "concepto" And dt.Columns(j).ColumnName <> "nom_cent" Then
                For i = 0 To dt.Rows.Count - 2
                    If Not IsDBNull(dt.Rows(i).Item(j)) Then
                        If IsNumeric(dt.Rows(i).Item(j)) Then
                            sum += dt.Rows(i).Item(j)
                        End If
                    End If
                Next
                dt.Rows(dt.Rows.Count - 1).Item(j) = sum
                sum = 0
            End If
        Next
    End Sub
    Private Function sql_detalle_empleado_ano(ByVal ano As Integer, ByVal concepto As Integer, ByVal centro As Integer) As String
        Dim whereSql As String = "WHERE ano = " & ano & "  "
        Dim whereCentro As String = ""
        Dim sql_diagnostico As String = ""
        If (centro <> 0) Then
            whereCentro = " AND centro =" & centro & " "
        Else
            If (centros <> "") Then
                whereCentro = " AND " & centros & " "
            End If
        End If
        If concepto <> 0 Then
            whereSql &= "AND concepto =" & concepto & " "
        Else
            whereSql &= "AND concepto IN(" & conceptos & ") "
        End If
        whereSql &= whereCentro
        Dim sql As String = "SELECT ano,centro,nombres,nit,COUNT(nit) As veces,concepto,desc_concepto,SUM(tothorasAusent) As tothorasAusent,SUM(vrTotAusent)As vrTotAusent  " & _
                                "FROM Jjv_ausentismo " & _
                                     whereSql & _
                                        "GROUP BY ano,centro,nombres,nit,concepto,desc_concepto"
        Return sql
    End Function
    Private Function sql_detalle_empleado_mes(ByVal ano As Integer, ByVal mes As Integer, ByVal concepto As Integer, ByVal centro As Integer) As String
        Dim whereSql As String = "WHERE ano = " & ano & " AND mes = " & mes & " "
        Dim whereCentro As String = ""
        Dim sql_diagnostico As String = ""
        If (centro <> 0) Then
            whereCentro = " AND centro =" & centro & " "
        Else
            If (centros <> "") Then
                whereCentro = " AND " & centros & " "
            End If
        End If
        If concepto <> 0 Then
            whereSql &= "AND concepto =" & concepto & " "
        Else
            whereSql &= "AND concepto IN(" & conceptos & ") "
        End If
        whereSql &= whereCentro
        Dim sql As String = "SELECT ano,mes,centro,nit,nombres,COUNT(nit) AS veces,concepto,desc_concepto,SUM(tothorasAusent)As tothorasAusent,SUM(vrTotAusent)As vrTotAusent " & _
                                   "FROM Jjv_ausentismo " & _
                                        whereSql & " " & _
                                            "GROUP BY ano,mes,centro,nit,nombres,concepto,desc_concepto " & _
                                             "ORDER BY ano,mes"
        Return sql
    End Function

    Private Sub ToolMenEmpleado_Click(sender As Object, e As EventArgs) Handles ToolMenEmpleado.Click
        dtg_det_empleado.DataSource = Nothing
        Dim tamano_letra As Single = 9.0!
        group_det_empleado.Visible = True
        group_det_empleado.BringToFront()
        Dim concepto As Integer = 0
        Dim ano As Integer = 0
        Dim sql As String = ""
        Dim dt As New DataTable
        Dim centro As Integer = 0
        Dim tot_horas As Double = 0
        Dim fila_total As Integer = 0
        For i = 0 To dtg_tendencia.Rows.Count - 1
            If dtg_tendencia.Item("CAUSA", i).Value = "TOTAL" Then
                fila_total = i
                i = dtg_tendencia.Rows.Count - 1
            End If
        Next
        Dim tot_horas_general As Double = dtg_tendencia(dtg_tendencia.CurrentCell.ColumnIndex, fila_total).Value
        Dim tot_horas_concepto As Double = dtg_detalle_tendencia("horas", 0).Value
        If IsNumeric(dtg_detalle_tendencia("concepto", dtg_detalle_tendencia.CurrentCell.RowIndex).Value) Then
            concepto = dtg_detalle_tendencia("concepto", dtg_detalle_tendencia.CurrentCell.RowIndex).Value
        End If
        If IsNumeric(dtg_detalle_tendencia("centro", dtg_detalle_tendencia.CurrentCell.RowIndex).Value) Then
            centro = dtg_detalle_tendencia("centro", dtg_detalle_tendencia.CurrentCell.RowIndex).Value
        End If
        If chk_consol_mes.Checked Then
            ano = dtg_detalle_tendencia("ano", dtg_detalle_tendencia.CurrentCell.RowIndex).Value
            Dim mes As Integer = dtg_detalle_tendencia("mes", dtg_detalle_tendencia.CurrentCell.RowIndex).Value
            sql = sql_detalle_empleado_mes(ano, mes, concepto, centro)
        Else
            ano = dtg_detalle_tendencia("ano", dtg_detalle_tendencia.CurrentCell.RowIndex).Value
            sql = sql_detalle_empleado_ano(ano, concepto, centro)
        End If
        dt = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        dt.Columns.Add("%Part-centro", GetType(Double))
        dt.Columns.Add("%Part-concepto", GetType(Double))
        dt.Columns.Add("%Part-total", GetType(Double))
        totalizar_dt(dt)
        tot_horas = dt.Rows(dt.Rows.Count - 1).Item("tothorasAusent")
        For i = 0 To dt.Rows.Count - 1
            If IsNumeric(dt.Rows(i).Item("tothorasAusent")) Then
                dt.Rows(i).Item("%Part-centro") = (dt.Rows(i).Item("tothorasAusent") / tot_horas) * 100
                dt.Rows(i).Item("%Part-concepto") = (dt.Rows(i).Item("tothorasAusent") / tot_horas_concepto) * 100
                dt.Rows(i).Item("%Part-total") = (dt.Rows(i).Item("tothorasAusent") / tot_horas_general) * 100
            End If
        Next
        dtg_det_empleado.DataSource = dt
        dtg_det_empleado.DataSource = dt
        Dim column As DataGridViewColumn = dtg_det_empleado.Columns("tothorasAusent")
        dtg_det_empleado.Sort(column, SortOrder.Ascending)
        dtg_det_empleado.Rows(0).DefaultCellStyle = objOperacionesForm.formatoNegrita(tamano_letra)
        dtg_det_empleado.Columns("%Part-centro").DefaultCellStyle.Format = "N2"
        dtg_det_empleado.Columns("%Part-concepto").DefaultCellStyle.Format = "N2"
        dtg_det_empleado.Columns("%Part-total").DefaultCellStyle.Format = "N2"
        pintar_porc(dtg_det_empleado)
    End Sub

    Private Sub btn_cerrar_empleado_Click(sender As Object, e As EventArgs) Handles btn_cerrar_empleado.Click
        group_det_empleado.Visible = False
    End Sub
End Class