Imports logicaNegocios
Imports entidadNegocios
Public Class Frm_reloj
    Private objOpSimplesLn As New Op_simpesLn
    Dim carga_comp As Boolean = False
    Private objOperacionesForm As OperacionesFormularios = New OperacionesFormularios
    Dim centros As String = ""
    Dim fila_select As Integer = 0
    Dim fila_select_detalle As Integer = 0
    Public Sub Main(ByVal objUsuario As UsuarioEn)
        Dim sql As String
        Dim dt As New DataTable
        Dim dr As DataRow
        If (objUsuario.permiso.Trim <> "ADMIN") Then
            Dim nit As Double = objUsuario.nit
            If Not IsNothing(objUsuario.nit) Then
                Dim listCentros As DataTable = objOpSimplesLn.listar_datatable("SELECT centro FROM J_coordinador_centros_costos WHERE nit =" & nit, "PRODUCCION")
                For i = 0 To listCentros.Rows.Count - 1
                    centros &= listCentros.Rows(i).Item("centro")
                    If (i <> listCentros.Rows.Count - 1) Then
                        centros &= ","
                    End If
                Next
            End If
        End If
        If centros <> "" Then
            sql = "SELECT centro,(CONVERT (varchar ,centro )+ ' - ' + descripcion )As descripcion FROM centros WHERE centro IN (" & centros & ") ORDER by centro "
        Else
            sql = "SELECT centro,(CONVERT (varchar ,centro )+ ' - ' + descripcion )As descripcion FROM centros WHERE centro IN (SELECT centro FROM V_nom_personal_Activo_con_maquila  GROUP BY centro) AND centro not in (4200,4300,4324,4328,4332,4334,4398,4399) ORDER by centro "
        End If

        dt = New DataTable
        dt = objOpSimplesLn.listar_datatable(Sql, "CORSAN")
        dr = dt.NewRow
        dr("descripcion") = "TODO"
        dr("centro") = 0
        dt.Rows.Add(dr)
        cboCentro.DataSource = dt
        cboCentro.ValueMember = "centro"
        cboCentro.DisplayMember = "descripcion"
        cboCentro.SelectedValue = 0
        carga_comp = True
    End Sub
    Private Sub Frm_tiempos_laborados_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Dim año = Now.Year
        While (año >= Now.Year - 5)
            cboAnoIni.Items.Add(año)
            año -= 1
        End While
        cboAnoIni.Text = Now.Year
        cboMesIni.SelectedIndex = Now.Month - 1
        cboMesFin.SelectedIndex = Now.Month - 1


    End Sub


    Private Sub btnActualizar_Click(sender As System.Object, e As System.EventArgs) Handles btnActualizar.Click
        itemDetalle.Enabled = True
        groupDetalle.Visible = False
        dtgDetalle.DataSource = Nothing
        img_procesar.Visible = True
        dtgConsulta.DataSource = Nothing
        Application.DoEvents()
        If (chkOrd.Checked Or chkExtra.Checked Or chkAusent.Checked) Then
            itemDetalle.Enabled = False
            trasabilidad()
        ElseIf (chkDetalle.Checked) Then
            cargarDetalle()
        Else
            cargar_consulta()
        End If
        img_procesar.Visible = False
    End Sub
    Private Sub alertas()
        Dim alerta As Double = 0
        For i = 0 To dtgConsulta.Rows.Count - 1
            If Not IsDBNull(dtgConsulta.Item("tiempo_ord", i).Value) Then
                'convierto a días y digo que son 2 horas extras por día
                alerta = (dtgConsulta.Item("tiempo_ord", i).Value / 8) * 2
                If Not IsDBNull(dtgConsulta.Item("tiempo_extra", i).Value) Then
                    If (dtgConsulta.Item("tiempo_extra", i).Value = 0) Then
                        dtgConsulta.Item("tiempo_extra", i).Style.BackColor = Color.GreenYellow
                    ElseIf (dtgConsulta.Item("tiempo_extra", i).Value <= alerta) Then
                        dtgConsulta.Item("tiempo_extra", i).Style.BackColor = Color.Yellow
                    Else
                        dtgConsulta.Item("tiempo_extra", i).Style.BackColor = Color.Red
                    End If
                Else
                    dtgConsulta.Item("tiempo_extra", i).Style.BackColor = Color.GreenYellow
                End If
            Else
                dtgConsulta.Item("tiempo_extra", i).Style.BackColor = Color.GreenYellow
            End If
            If IsDBNull(dtgConsulta.Item("tiempo_ausentismo", i).Value) Then
                dtgConsulta.Item("tiempo_ausentismo", i).Style.BackColor = Color.GreenYellow
            ElseIf (dtgConsulta.Item("tiempo_ausentismo", i).Value = 0) Then
                dtgConsulta.Item("tiempo_ausentismo", i).Style.BackColor = Color.GreenYellow
            Else
                dtgConsulta.Item("tiempo_ausentismo", i).Style.BackColor = Color.Red
            End If
            'If IsDBNull(dtgConsulta.Item("tiempo_debe", i).Value) Then
            '    dtgConsulta.Item("tiempo_debe", i).Style.BackColor = Color.GreenYellow
            'ElseIf (dtgConsulta.Item("tiempo_debe", i).Value = 0) Then
            '    dtgConsulta.Item("tiempo_debe", i).Style.BackColor = Color.GreenYellow
            'Else
            '    dtgConsulta.Item("tiempo_debe", i).Style.BackColor = Color.Red
            'End If
        Next
    End Sub
    Private Sub cargar_consulta()
        dtgConsulta.DataSource = Nothing
        Dim tamano_letra As Single = 9.0!
        Dim anoIni As String = cboAnoIni.Text
        Dim mesIni As String = cboMesIni.SelectedIndex + 1
        Dim mesFin As String = cboMesFin.SelectedIndex + 1
        Dim dt_tiempo_extra As New DataTable
        Dim dt_ppal As New DataTable
        Dim dt_tiempo_ausentismo As New DataTable
        Dim dt_tiempo_debe As New DataTable
        Dim centro As String = ""
        Dim whereCentro As String = ""
        If (cboCentro.SelectedValue <> 0) Then
            centro = cboCentro.SelectedValue
            whereCentro = " AND  v.centro  = " & centro
        Else
            If (centros <> "") Then
                whereCentro = " AND  v.centro in (" & centros & ") "
            Else
                whereCentro = " AND v.centro not in (4200,4300,4324,4328,4332,4334,4398,4399)"
            End If
        End If



        Dim sql_tiempo_ordinario As String = "SELECT v.ano,v.mes,v.centro,CAST(v.centro AS varchar(25))+ ' - ' +c.descripcion As descripcion, SUM(v.TiempoOrd ) as tiempo_ord,COUNT(distinct(v.nit))As empleados_con_tiempo_ordinario " & _
                                                    "FROM  Jjv_tiempo_ord_acum  v,centros c " & _
                                                        "WHERE v.mes >= " & mesIni & " And v.ano = " & anoIni & " AND  v.mes <= " & mesFin & "  And c.centro = v.centro  " & whereCentro & " " & _
                                                            "GROUP BY  v.centro,c.descripcion, v.ano,v.mes  " & _
                                                            "ORDER BY v.ano,v.mes,v.centro "
        Dim sql_tiempo_extra As String = "SELECT v.centro,c.descripcion,SUM(v.TiempoExt ) as tiempo_extra,COUNT(distinct(v.nit))As empleados_con_tiempo_extra , v.ano,v.mes  " & _
                                        "FROM Jjv_tiempo_ext_acum v,centros c  " & _
                                            "WHERE c.centro = v.centro  AND v.mes >= " & mesIni & " And v.ano = " & anoIni & " AND  v.mes <= " & mesFin & "  " & whereCentro & " " & _
                                                    "GROUP BY  v.centro, v.ano,v.mes,c.descripcion  " & _
                                                            "ORDER BY v.ano,v.mes,v.centro "

        Dim sql_tiempo_ausentismo As String = "SELECT v.centro,c.descripcion,SUM(v.TotHorasAusent ) as tiempo_ausentismo,COUNT(distinct(v.nit))As empleados_con_ausentismo , v.ano,v.mes " & _
                                                "FROM Jjv_ausentismo v,centros c  " & _
                                                      "WHERE  c.centro = v.centro AND v.mes >= " & mesIni & " And v.ano = " & anoIni & " AND  v.mes <= " & mesFin & "  " & whereCentro & " " & _
                                                            "GROUP BY v.centro, v.ano,v.mes,c.descripcion   " & _
                                                            "ORDER BY v.ano,v.mes,v.centro "
        Dim sql_tiempo_debe As String = "SELECT v.centro,c.descripcion,SUM(r.Horas) as tiempo_debe,COUNT(distinct(r.Nit_Trabajador))As empleados_tiempo_debe,YEAR(r.Fecha_compromiso) As ano,MONTH(r.Fecha_compromiso) As mes " & _
                                            "FROM CONTROL.dbo.R_compromiso_horas_a_pagar r ,V_nom_personal_Activo_con_maquila  v ,centros c " & _
                                                "WHERE c.centro = v.centro  AND r.horas >0 and r.Activo = 'true' AND r.Nit_Trabajador = v.nit  " & whereCentro & " " & _
                                                    "GROUP BY v.centro,c.descripcion,YEAR(r.Fecha_compromiso) ,MONTH(r.Fecha_compromiso) "

        dt_ppal = objOpSimplesLn.listar_datatable(sql_tiempo_ordinario, "CORSAN")
        dt_ppal.Columns.Add("tiempo_extra", GetType(Double))
        dt_ppal.Columns.Add("empleados_con_tiempo_extra", GetType(Double))
        dt_ppal.Columns.Add("tiempo_ausentismo", GetType(Double))
        dt_ppal.Columns.Add("empleados_con_ausentismo", GetType(Double))
        dt_ppal.Columns.Add("tiempo_debe", GetType(Double))
        dt_ppal.Columns.Add("empleados_tiempo_debe", GetType(Double))
        dt_ppal.Columns.Add("tot_laborado", GetType(Double))
        dt_ppal.Columns.Add("porc_ausentismo", GetType(Double))
        dt_ppal.Columns.Add("porc_extra", GetType(Double))

        dt_tiempo_extra = objOpSimplesLn.listar_datatable(sql_tiempo_extra, "CORSAN")
        dt_tiempo_ausentismo = objOpSimplesLn.listar_datatable(sql_tiempo_ausentismo, "CORSAN")
        dt_tiempo_debe = objOpSimplesLn.listar_datatable(sql_tiempo_debe, "CORSAN")

        dt_ppal = addItem(dt_tiempo_extra, dt_ppal, "tiempo_extra", "empleados_con_tiempo_extra")
        dt_ppal = addItem(dt_tiempo_ausentismo, dt_ppal, "tiempo_ausentismo", "empleados_con_ausentismo")
        dt_ppal = addItem(dt_tiempo_debe, dt_ppal, "tiempo_debe", "empleados_tiempo_debe")




        dt_ppal.Rows.Add()
        dt_ppal = totalizarDtg(dt_ppal)
        dtgConsulta.DataSource = dt_ppal
        dtgConsulta.Columns("empleados_con_tiempo_extra").HeaderText = "total"
        dtgConsulta.Columns("empleados_con_tiempo_ordinario").HeaderText = "total"
        dtgConsulta.Columns("empleados_con_ausentismo").HeaderText = "total"
        dtgConsulta.Columns("empleados_tiempo_debe").HeaderText = "total"
        dtgConsulta.Columns("centro").Visible = False

        dtgConsulta.Columns("porc_ausentismo").DefaultCellStyle.Format = "N2"
        dtgConsulta.Columns("porc_extra").DefaultCellStyle.Format = "N2"
        dtgConsulta.Rows(dtgConsulta.Rows.Count - 1).DefaultCellStyle = objOperacionesForm.formatoNegrita(tamano_letra)
        For i = 0 To dtgConsulta.Columns.Count - 1
            If (dtgConsulta.Columns(i).HeaderText = "total") Then
                dtgConsulta.Columns(i).DefaultCellStyle = objOperacionesForm.formatoNegrita(tamano_letra)
            End If
        Next
        alertas()
    End Sub
    Private Sub cargarDetalle()
        Dim tamano_letra As Single = 9.0!
        Dim anoIni As String = cboAnoIni.Text
        Dim mesIni As String = cboMesIni.SelectedIndex + 1
        Dim mesFin As String = cboMesFin.SelectedIndex + 1
        Dim dt_tiempo_extra As New DataTable
        Dim dt_ppal As New DataTable
        Dim dt_tiempo_ausentismo As New DataTable
        Dim dt_tiempo_debe As New DataTable
        Dim centro As String = ""
        Dim whereCentro As String = ""
        If (cboCentro.SelectedValue <> 0) Then
            centro = cboCentro.SelectedValue
            whereCentro = " AND  v.centro  = " & centro
        Else
            If (centros <> "") Then
                whereCentro = " AND  v.centro in (" & centros & ") "
            Else
                whereCentro = " AND v.centro not in (4200,4300,4324,4328,4332,4334,4398,4399) "
            End If
        End If
        Dim sql_tiempo_ordinario As String = "SELECT v.ano,v.mes,v.centro,c.descripcion ,v.nit,v.nombres, SUM(v.TiempoOrd)as tiempo_ord, SUM(v.Vr_totalOrd  ) as vr_ord " & _
                                                    "FROM  Jjv_tiempo_ord_acum  v,centros c " & _
                                                        "WHERE v.mes >= " & mesIni & " And v.ano = " & anoIni & " AND  v.mes <= " & mesFin & " And c.centro = v.centro " & whereCentro & " " & _
                                                            "GROUP BY  v.centro,c.descripcion, v.ano,v.mes,v.nit,v.nombres " & _
                                                        "ORDER BY ano,mes,v.centro,v.nombres "
        Dim sql_tiempo_extra As String = "SELECT v.centro,c.descripcion,v.nit,nombres,SUM(v.TiempoExt ) as tiempo_extra, SUM(v.Vr_totalExt) as vr_extra, v.ano,v.mes  " & _
                                        "FROM Jjv_tiempo_ext_acum v,centros c  " & _
                                            "WHERE c.centro = v.centro AND v.mes >= " & mesIni & " And v.ano = " & anoIni & " AND  v.mes <= " & mesFin & " And c.centro = v.centro " & whereCentro & " " & _
                                                    "GROUP BY  v.centro,c.descripcion, v.ano,v.mes,v.nit,v.nombres " & _
                                                        "ORDER BY ano,mes,v.centro,v.nombres "

        Dim sql_tiempo_ausentismo As String = "SELECT v.centro,c.descripcion, v.nit,v.nombres,SUM(v.TotHorasAusent ) as tiempo_ausentismo, SUM(v.VrtotAusent) as vr_aus , v.ano,v.mes " & _
                                                "FROM Jjv_ausentismo v,centros c  " & _
                                                      "WHERE c.centro = v.centro AND v.mes >= " & mesIni & " And v.ano = " & anoIni & " AND  v.mes <= " & mesFin & " And c.centro = v.centro " & whereCentro & " " & _
                                                            "GROUP BY  v.centro,c.descripcion, v.ano,v.mes,v.nit,v.nombres " & _
                                                        "ORDER BY ano,mes,v.centro,v.nombres "

        Dim sql_tiempo_debe As String = "SELECT v.centro,v.nit,v.nombres,SUM(r.Horas) as tiempo_debe " & _
                                         "FROM CONTROL.dbo.R_compromiso_horas_a_pagar r ,V_nom_personal_Activo_con_maquila  v " & _
                                             "WHERE r.horas >0 and r.Activo = 'true' AND r.Nit_Trabajador = v.nit  " & whereCentro & " " & _
                                                 "GROUP BY v.centro,v.nit,v.nombres "
        dt_ppal = objOpSimplesLn.listar_datatable(sql_tiempo_ordinario, "CORSAN")
        dt_ppal.Columns.Add("tiempo_extra", GetType(Double))
        dt_ppal.Columns.Add("vr_extra", GetType(Double))
        dt_ppal.Columns.Add("tiempo_ausentismo", GetType(Double))
        dt_ppal.Columns.Add("vr_aus", GetType(Double))
        ' dt_ppal.Columns.Add("tiempo_debe", GetType(Double))
        dt_ppal.Columns.Add("tot_laborado", GetType(Double))
        dt_ppal.Columns.Add("porc_ausentismo", GetType(Double))
        dt_ppal.Columns.Add("porc_extra", GetType(Double))

        dt_tiempo_extra = objOpSimplesLn.listar_datatable(sql_tiempo_extra, "CORSAN")
        dt_tiempo_ausentismo = objOpSimplesLn.listar_datatable(sql_tiempo_ausentismo, "CORSAN")
        ' dt_tiempo_debe = objOpSimplesLn.listar_datatable(sql_tiempo_debe, "CORSAN")

        dt_ppal = addDetalle(dt_tiempo_extra, dt_ppal, "tiempo_extra", "vr_extra")
        dt_ppal = addDetalle(dt_tiempo_ausentismo, dt_ppal, "tiempo_ausentismo", "vr_aus")
        '   dt_ppal = addDetalle(dt_tiempo_debe, dt_ppal, "tiempo_debe", "")



        dt_ppal.Rows.Add()
        dt_ppal = totalizarDtg(dt_ppal)
        dtgConsulta.DataSource = dt_ppal

        dtgConsulta.Columns("porc_ausentismo").DefaultCellStyle.Format = "N2"
        dtgConsulta.Columns("porc_extra").DefaultCellStyle.Format = "N2"
        dtgConsulta.Columns("vr_aus").DefaultCellStyle.Format = "C0"
        dtgConsulta.Columns("vr_extra").DefaultCellStyle.Format = "C0"
        dtgConsulta.Columns("vr_ord").DefaultCellStyle.Format = "C0"
        dtgConsulta.Rows(dtgConsulta.Rows.Count - 1).DefaultCellStyle = objOperacionesForm.formatoNegrita(tamano_letra)
        For i = 0 To dtgConsulta.Columns.Count - 1
            If (dtgConsulta.Columns(i).HeaderText = "total") Then
                dtgConsulta.Columns(i).DefaultCellStyle = objOperacionesForm.formatoNegrita(tamano_letra)
            End If
        Next
        alertas()

    End Sub
    Private Function addDetalle(ByRef dt_nueva As DataTable, ByVal dt_ppal As DataTable, ByVal nomb_col1 As String, ByVal nomb_col2 As String) As DataTable
        Dim encontrado As Boolean = False
        For j = 0 To dt_nueva.Rows.Count - 1
            For i = 0 To dt_ppal.Rows.Count - 1
                If nomb_col2 <> "" Then
                    If (dt_ppal.Rows(i).Item("nit") = dt_nueva.Rows(j).Item("nit") And dt_ppal.Rows(i).Item("mes") = dt_nueva.Rows(j).Item("mes") And dt_ppal.Rows(i).Item("ano") = dt_nueva.Rows(j).Item("ano")) Then
                        dt_ppal.Rows(i).Item(nomb_col1) = dt_nueva.Rows(j).Item(nomb_col1)
                        dt_ppal.Rows(i).Item(nomb_col2) = dt_nueva.Rows(j).Item(nomb_col2)
                        encontrado = True
                    End If
                Else
                    If (dt_ppal.Rows(i).Item("nit") = dt_nueva.Rows(j).Item("nit")) Then
                        dt_ppal.Rows(i).Item(nomb_col1) = dt_nueva.Rows(j).Item(nomb_col1)
                        encontrado = True
                    End If
                End If

            Next
            If (encontrado = False) Then
                dt_ppal.Rows.Add()

                dt_ppal.Rows(dt_ppal.Rows.Count - 1).Item("nit") = dt_nueva.Rows(j).Item("nit")
                dt_ppal.Rows(dt_ppal.Rows.Count - 1).Item("centro") = dt_nueva.Rows(j).Item("centro")
                dt_ppal.Rows(dt_ppal.Rows.Count - 1).Item("nombres") = dt_nueva.Rows(j).Item("nombres")
                dt_ppal.Rows(dt_ppal.Rows.Count - 1).Item(nomb_col1) = dt_nueva.Rows(j).Item(nomb_col1)

                If nomb_col2 <> "" Then
                    dt_ppal.Rows(dt_ppal.Rows.Count - 1).Item("mes") = dt_nueva.Rows(j).Item("mes")
                    dt_ppal.Rows(dt_ppal.Rows.Count - 1).Item("ano") = dt_nueva.Rows(j).Item("ano")
                    dt_ppal.Rows(dt_ppal.Rows.Count - 1).Item(nomb_col2) = dt_nueva.Rows(j).Item(nomb_col2)
                    dt_ppal.Rows(dt_ppal.Rows.Count - 1).Item("descripcion") = dt_nueva.Rows(j).Item("descripcion")
                End If
            End If
            encontrado = False
        Next
        Return dt_ppal
    End Function
    Private Sub trasabilidad()
        Dim tamano_letra As Single = 9.0!
        Dim dt_nueva As New DataTable
        Dim tabla As String = ""
        Dim campo As String = ""
        Dim sql As String = ""
        Dim anoIni As String = cboAnoIni.Text
        Dim mesIni As String = cboMesIni.SelectedIndex + 1
        Dim mesFin As String = cboMesFin.SelectedIndex + 1
        Dim dt As New DataTable
        Dim dt_trasabilidad As New DataTable
        Dim centro As String = ""
        Dim nombMes As String = ""
        Dim nombMes_valor As String = ""
        Dim sum As Double = 0
        Dim whereCentro As String = ""
        Dim col_1 As String = ""
        Dim col_2 As String = ""
        Dim col_1_tabla As String = ""
        Dim col_2_tabla As String = ""
        Dim order_sql As String = ""
        If chkDetalle.Checked Then
            col_1 = "nit"
            col_2 = "nombres"
            col_1_tabla = "t.nit"
            col_2_tabla = "t.nombres"
            order_sql = "ORDER BY t.ano,t.mes," & col_2_tabla & " "
        Else
            col_1 = "centro"
            col_2 = "descripcion"
            col_1_tabla = "t.centro"
            col_2_tabla = "c.descripcion"
            order_sql = "ORDER BY t.ano,t.mes," & col_1_tabla & " "
        End If
        If (cboCentro.SelectedValue <> 0) Then
            centro = cboCentro.SelectedValue
            whereCentro = " AND  t.centro  = " & centro
        Else
            If (centros <> "") Then
                whereCentro = " AND  t.centro in (" & centros & ") "
            Else
                whereCentro = " AND t.centro not in (4200,4300,4324,4328,4332,4334,4398,4399) "
            End If
        End If
        If (chkOrd.Checked) Then
            tabla = "Jjv_tiempo_ord_acum"
            campo = " SUM(t.TiempoOrd)as suma ,SUM(t.vr_totalOrd)as suma_valor "
        ElseIf (chkExtra.Checked) Then
            tabla = "Jjv_tiempo_ext_acum"
            campo = "SUM(t.TiempoExt ) as suma,SUM(t.Vr_totalExt)as suma_valor "
        ElseIf (chkAusent.Checked) Then
            tabla = "Jjv_ausentismo"
            campo = "SUM(t.TotHorasAusent ) as suma,SUM(t.VrtotAusent)as suma_valor "
        End If

        sql = "SELECT t.ano,t.mes," & col_1_tabla & "," & col_2_tabla & "," & campo & " FROM centros c , " & tabla & " t " & _
                "WHERE   c.centro = t.centro AND t.mes >= " & mesIni & " And t.ano >= " & anoIni & " AND t.mes <= " & mesFin & " " & whereCentro & " " & _
                "GROUP BY t.ano,t.mes," & col_1_tabla & "," & col_2_tabla & " " & _
                    order_sql
        dt = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        dt_nueva = armarDt(dt, col_1, col_2)
        For i = 0 To dt.Rows.Count - 1
            nombMes = MonthName(dt.Rows(i).Item("mes"), True).ToUpper & " - " & dt.Rows(i).Item("ano")
            nombMes_valor = nombMes & "_val"
            nombMes &= "_horas"
            For j = 1 To dt_nueva.Rows.Count - 1
                If (dt_nueva.Rows(j).Item(col_1) = dt.Rows(i).Item(col_1)) Then
                    dt_nueva.Rows(j).Item(nombMes) = dt.Rows(i).Item("suma")
                    dt_nueva.Rows(j).Item(nombMes_valor) = dt.Rows(i).Item("suma_valor")
                    j = dt_nueva.Rows.Count - 1
                End If
            Next
        Next
        dt_nueva.Rows.Add()
        dt_nueva.Rows(dt_nueva.Rows.Count - 1).Item(col_2) = "TOTAL"
        For j = dt_nueva.Columns.IndexOf(col_2) To dt_nueva.Columns.Count - 1
            If (dt_nueva.Columns.Count > 2) Then
                If (j = dt_nueva.Columns.IndexOf(col_2)) Then
                    j += 1
                End If
                For i = 1 To dt_nueva.Rows.Count - 1
                    If Not IsDBNull(dt_nueva.Rows(i).Item(j)) Then
                        sum += dt_nueva.Rows(i).Item(j)
                    End If
                Next
                dt_nueva.Rows(dt_nueva.Rows.Count - 1).Item(j) = sum
                sum = 0
            End If
        Next


        dtgConsulta.DataSource = dt_nueva
        dtgConsulta.Rows(dtgConsulta.Rows.Count - 1).DefaultCellStyle = objOperacionesForm.formatoNegrita(tamano_letra)
        dtgConsulta.CurrentCell = Nothing
        dtgConsulta.Rows(0).Visible = False
    End Sub
    Private Function armarDt(ByRef dtDatos As DataTable, ByVal col_1 As String, ByVal col_2 As String) As DataTable
        Dim dtResp As New DataTable
        Dim nombMes As String = ""
        Dim nombMes_valor As String = ""
        Dim dato As String = ""
        Dim datoEncontrado As Boolean = False
        Dim mesAnoEncontrado As Boolean = False
        dtResp.Columns.Add(col_1, GetType(Double))
        dtResp.Columns.Add(col_2)
        For i = 0 To dtDatos.Rows.Count - 1
            If i = 0 Then
                dtResp.Rows.Add()
            End If
            nombMes = MonthName(dtDatos.Rows(i).Item("mes"), True).ToUpper & " - " & dtDatos.Rows(i).Item("ano")
            nombMes_valor = nombMes & "_val"
            nombMes &= "_horas"
            dato = dtDatos.Rows(i).Item(col_1)
            For j = 0 To dtResp.Columns.Count - 1
                If (dtResp.Columns(j).ColumnName = nombMes) Then
                    mesAnoEncontrado = True
                End If
            Next
            If (mesAnoEncontrado = False) Then
                dtResp.Columns.Add(nombMes, GetType(Double))
                dtResp.Columns.Add(nombMes_valor, GetType(Double))
                dtResp.Rows(0).Item(nombMes) = dtDatos.Rows(i).Item("mes")
                dtResp.Rows(0).Item(nombMes_valor) = dtDatos.Rows(i).Item("mes")
            End If
            For k = 1 To dtResp.Rows.Count - 1
                If (dtResp.Rows(k).Item(col_1) = dato) Then
                    datoEncontrado = True
                End If
            Next
            If (datoEncontrado = False) Then
                dtResp.Rows.Add()
                dtResp.Rows(dtResp.Rows.Count - 1).Item(col_1) = dtDatos.Rows(i).Item(col_1)
                dtResp.Rows(dtResp.Rows.Count - 1).Item(col_2) = dtDatos.Rows(i).Item(col_2)
            End If
            datoEncontrado = False
            mesAnoEncontrado = False
        Next
        Return dtResp
    End Function
    Private Function addItem(ByRef dt_nueva As DataTable, ByVal dt_ppal As DataTable, ByVal nomb_col1 As String, ByVal nomb_col2 As String) As DataTable
        Dim encontrado As Boolean = False
        For j = 0 To dt_nueva.Rows.Count - 1
            For i = 0 To dt_ppal.Rows.Count - 1
                If (dt_nueva.TableName = "dt_tiempo_ausentismo") Then
                    If (dt_ppal.Rows(i).Item("centro") = dt_nueva.Rows(j).Item("centro") And dt_ppal.Rows(i).Item("mes") = dt_nueva.Rows(j).Item("mes") And dt_ppal.Rows(i).Item("ano") = dt_nueva.Rows(j).Item("ano")) Then
                        dt_ppal.Rows(i).Item(nomb_col1) = dt_nueva.Rows(j).Item(nomb_col1)
                        dt_ppal.Rows(i).Item(nomb_col2) = dt_nueva.Rows(j).Item(nomb_col2)
                        encontrado = True
                        i = dt_ppal.Rows.Count - 1
                    End If
                Else
                    If (dt_ppal.Rows(i).Item("centro") = dt_nueva.Rows(j).Item("centro")) Then
                        dt_ppal.Rows(i).Item(nomb_col1) = dt_nueva.Rows(j).Item(nomb_col1)
                        dt_ppal.Rows(i).Item(nomb_col2) = dt_nueva.Rows(j).Item(nomb_col2)
                        encontrado = True
                        i = dt_ppal.Rows.Count - 1
                    End If
                End If

            Next
            If (encontrado = False) Then
                dt_ppal.Rows.Add()
                dt_ppal.Rows(dt_ppal.Rows.Count - 1).Item("centro") = dt_nueva.Rows(j).Item("centro")
                dt_ppal.Rows(dt_ppal.Rows.Count - 1).Item("descripcion") = dt_nueva.Rows(j).Item("descripcion")
                dt_ppal.Rows(dt_ppal.Rows.Count - 1).Item(nomb_col1) = dt_nueva.Rows(j).Item(nomb_col1)
                dt_ppal.Rows(dt_ppal.Rows.Count - 1).Item(nomb_col2) = dt_nueva.Rows(j).Item(nomb_col2)
                If (dt_nueva.TableName <> "dt_tiempo_ausentismo") Then
                    dt_ppal.Rows(dt_ppal.Rows.Count - 1).Item("mes") = dt_nueva.Rows(j).Item("mes")
                    dt_ppal.Rows(dt_ppal.Rows.Count - 1).Item("ano") = dt_nueva.Rows(j).Item("ano")
                End If
            End If
            encontrado = False
        Next
        Return dt_ppal
    End Function
    Private Function totalizarDtg(ByRef dt As DataTable) As DataTable
        Dim sum As Double = 0
        For i = 0 To dt.Columns.Count - 1
            If (dt.Columns(i).ColumnName = "empleados_con_tiempo_extra" Or dt.Columns(i).ColumnName = "empleados_con_ausentismo" Or dt.Columns(i).ColumnName = "empleados_con_tiempo_ordinario" Or dt.Columns(i).ColumnName = "vr_extra" Or dt.Columns(i).ColumnName = "vr_ord" Or dt.Columns(i).ColumnName = "vr_aus" Or dt.Columns(i).ColumnName = "tiempo_ord" Or dt.Columns(i).ColumnName = "tiempo_ausentismo" Or dt.Columns(i).ColumnName = "tiempo_extra" Or dt.Columns(i).ColumnName = "tot_laborado" Or dt.Columns(i).ColumnName = "tiempo_debe" Or dt.Columns(i).ColumnName = "empleados_tiempo_debe") Then
                For j = 0 To dt.Rows.Count - 2
                    If Not IsDBNull(dt.Rows(j).Item(i)) Then
                        sum += dt.Rows(j).Item(i)
                    End If
                    If (dt.Columns(i).ColumnName = "tiempo_ord") Then
                        If Not IsDBNull(dt.Rows(j).Item("tiempo_ord")) And Not IsDBNull(dt.Rows(j).Item("tiempo_extra")) Then
                            dt.Rows(j).Item("tot_laborado") = dt.Rows(j).Item("tiempo_ord") + dt.Rows(j).Item("tiempo_extra")
                        End If
                        If Not IsDBNull(dt.Rows(j).Item("tiempo_extra")) And Not IsDBNull(dt.Rows(j).Item("tiempo_ord")) Then
                            dt.Rows(j).Item("porc_extra") = (dt.Rows(j).Item("tiempo_extra") / dt.Rows(j).Item("tiempo_ord")) * 100
                        End If
                    ElseIf (dt.Columns(i).ColumnName = "tiempo_ausentismo") Then
                        If Not IsDBNull(dt.Rows(j).Item("tiempo_ausentismo")) And Not IsDBNull(dt.Rows(j).Item("tiempo_ord")) Then
                            dt.Rows(j).Item("porc_ausentismo") = (dt.Rows(j).Item("tiempo_ausentismo") / dt.Rows(j).Item("tiempo_ord")) * 100
                        End If
                    End If
                Next
                dt.Rows(dt.Rows.Count - 1).Item(i) = sum
                sum = 0
            ElseIf (dt.Columns(i).ColumnName = "descripcion") Then
                dt.Rows(dt.Rows.Count - 1).Item(i) = "TOTAL"
            End If
            If Not IsDBNull(dt.Rows(dt.Rows.Count - 1).Item("tiempo_ausentismo")) And Not IsDBNull(dt.Rows(dt.Rows.Count - 1).Item("tiempo_ord")) Then
                dt.Rows(dt.Rows.Count - 1).Item("porc_ausentismo") = (dt.Rows(dt.Rows.Count - 1).Item("tiempo_ausentismo") / dt.Rows(dt.Rows.Count - 1).Item("tiempo_ord")) * 100
            End If
            If Not IsDBNull(dt.Rows(dt.Rows.Count - 1).Item("tiempo_extra")) And Not IsDBNull(dt.Rows(dt.Rows.Count - 1).Item("tiempo_ord")) Then
                dt.Rows(dt.Rows.Count - 1).Item("porc_extra") = (dt.Rows(dt.Rows.Count - 1).Item("tiempo_extra") / dt.Rows(dt.Rows.Count - 1).Item("tiempo_ord")) * 100
            End If
        Next
        Return dt
    End Function

    Private Sub btnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Click
        objOperacionesForm.ExportarDatosExcel(dtgConsulta, "Tiempos laborados")
    End Sub


    Private Sub chkOrd_CheckedChanged(sender As Object, e As EventArgs) Handles chkOrd.CheckedChanged
        If (chkOrd.Checked) Then
            chkExtra.Checked = False
            chkAusent.Checked = False
        End If
    End Sub
    Private Sub chkExtra_CheckedChanged(sender As Object, e As EventArgs) Handles chkExtra.CheckedChanged
        If (chkExtra.Checked) Then
            chkOrd.Checked = False
            chkAusent.Checked = False
        End If
    End Sub
    Private Sub chkAusent_CheckedChanged(sender As Object, e As EventArgs) Handles chkAusent.CheckedChanged
        If (chkAusent.Checked) Then
            chkExtra.Checked = False
            chkOrd.Checked = False
        End If
    End Sub

    Private Sub dtgConsulta_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dtgConsulta.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            With (Me.dtgConsulta)
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                End If
            End With
            If dtgConsulta.Columns.Count > 0 Then
                If (dtgConsulta.Columns(dtgConsulta.CurrentCell.ColumnIndex).Name = "empleados_con_tiempo_extra" Or dtgConsulta.Columns(dtgConsulta.CurrentCell.ColumnIndex).Name = "empleados_con_ausentismo" Or dtgConsulta.Columns(dtgConsulta.CurrentCell.ColumnIndex).Name = "empleados_con_tiempo_ordinario" Or dtgConsulta.Columns(dtgConsulta.CurrentCell.ColumnIndex).Name = "vr_extra" Or dtgConsulta.Columns(dtgConsulta.CurrentCell.ColumnIndex).Name = "vr_ord" Or dtgConsulta.Columns(dtgConsulta.CurrentCell.ColumnIndex).Name = "vr_aus" Or dtgConsulta.Columns(dtgConsulta.CurrentCell.ColumnIndex).Name = "tiempo_ord" Or dtgConsulta.Columns(dtgConsulta.CurrentCell.ColumnIndex).Name = "tiempo_ausentismo" Or dtgConsulta.Columns(dtgConsulta.CurrentCell.ColumnIndex).Name = "tiempo_extra" Or dtgConsulta.Columns(dtgConsulta.CurrentCell.ColumnIndex).Name = "tiempo_debe" Or dtgConsulta.Columns(dtgConsulta.CurrentCell.ColumnIndex).Name = "empleados_tiempo_debe") Then
                    itemDetalle.Enabled = True
                Else
                    itemDetalle.Enabled = False
                End If
            Else
                itemDetalle.Enabled = False
            End If
            If chkAusent.Checked Or chkExtra.Checked Or chkOrd.Checked And (dtgConsulta.Columns(dtgConsulta.CurrentCell.ColumnIndex).Name <> "centro" And dtgConsulta.Columns(dtgConsulta.CurrentCell.ColumnIndex).Name <> "descripcion" And dtgConsulta.Columns(dtgConsulta.CurrentCell.ColumnIndex).Name <> "nit" And dtgConsulta.Columns(dtgConsulta.CurrentCell.ColumnIndex).Name <> "nombres") Then
                GraficarToolStripMenuItem.Enabled = True
                itemDetalle.Enabled = True
            Else
                GraficarToolStripMenuItem.Enabled = False
            End If
            fila_select = (dtgConsulta.CurrentCell.RowIndex)
        End If
    End Sub

    Private Sub itemDetalle_Click(sender As Object, e As EventArgs) Handles itemDetalle.Click
        If (dtgConsulta.CurrentCell.RowIndex >= 0) Then
            If dtgConsulta.Columns(dtgConsulta.CurrentCell.ColumnIndex).Name <> "nit" And dtgConsulta.Columns(dtgConsulta.CurrentCell.ColumnIndex).Name <> "nombres" Then
                Dim tamano_letra As Single = 9.0!
                groupDetalle.Visible = True
                Dim dt As New DataTable
                Dim sum As Double = 0
                Dim anoIni As String = cboAnoIni.Text
                Dim mesIni As String = cboMesIni.SelectedIndex + 1
                Dim mesFin As String = cboMesFin.SelectedIndex + 1
                Dim consolidado As Boolean = False
                Dim conceptos As String = ""
                Dim sql As String = ""
                Dim col As String = dtgConsulta.Columns(dtgConsulta.CurrentCell.ColumnIndex).Name
                Dim whereCentro As String = ""
                Dim whereNit As String = ""
                Dim sqlNit As String = ""
                Dim centro As String = ""
                If (cboCentro.SelectedValue <> 0) Then
                    centro = cboCentro.SelectedValue
                    whereCentro = " AND  y.centro  = " & centro
                Else
                    If (centros <> "") Then
                        whereCentro = " AND  y.centro in (" & centros & ") "
                    Else
                        whereCentro = " AND y.centro not in (4200,4300,4324,4328,4332,4334,4398,4399)"
                    End If
                End If

                If col = "tiempo_extra" Or col = "vr_extra" Or col = "empleados_con_tiempo_extra" Or chkExtra.Checked Then
                    conceptos = "'13', '14', '15', '16'"
                ElseIf col = "tiempo_ausentismo" Or col = "vr_aus" Or col = "empleados_con_ausentismo" Or chkAusent.Checked Then
                    conceptos = "'5', '6', '7', '8', '9','10','11','25', '34', '77', '35', '36', '37', '68', '510', '511', '512', '513', '516'"
                ElseIf col = "tiempo_ord" Or col = "empleados_con_tiempo_ordinario" Or col = "vr_ord" Or chkOrd.Checked Then
                    conceptos = "'1','2','31', '32'"
                ElseIf col = "tiempo_debe" Or col = "empleados_tiempo_debe" Then

                End If

                For i = 0 To dtgConsulta.Columns.Count - 1
                    If (dtgConsulta.Columns(i).Name = "nit") Then
                        whereNit = "AND y.nit = " & dtgConsulta.Item("nit", dtgConsulta.CurrentCell.RowIndex).Value & " "
                        sqlNit = ",y.nit,t.nombres"
                        i = dtgConsulta.Columns.Count - 1
                    End If
                Next
                If (dtgConsulta.CurrentCell.RowIndex <> dtgConsulta.Rows.Count - 1) Then
                    If Not chkDetalle.Checked Then
                        whereCentro = "AND y.centro = " & dtgConsulta.Item("centro", dtgConsulta.CurrentCell.RowIndex).Value
                    End If
                Else
                    If centro <> "" Then
                        whereCentro = "AND y.centro = " & centro
                    End If
                    whereNit = ""
                    sqlNit = ""
                End If
                If col = "tiempo_debe" Or col = "empleados_tiempo_debe" Then
                    sql = "SELECT r.fecha_compromiso,y.centro,y.nit,y.nombres,SUM(r.Horas) as tiempo_debe " & _
                            "FROM CONTROL.dbo.R_compromiso_horas_a_pagar r ,V_nom_personal_Activo_con_maquila  y " & _
                                "WHERE r.horas >0 and r.Activo = 'true' AND r.Nit_Trabajador = y.nit  " & whereCentro & " " & whereNit & " " & _
                                    "GROUP BY y.centro,y.nit,y.nombres,r.fecha_compromiso "
                Else
                    If (conceptos <> "") Then
                        If chkAusent.Checked Or chkExtra.Checked Or chkOrd.Checked Then
                            Dim mes_select As Integer = dtgConsulta.Item(col, 0).Value
                            sql = "SELECT y.centro,c.concepto" & sqlNit & ",c.descripcion,SUM(y.horas)As horas,SUM(y.valor) as valor " &
                            " FROM y_liquidacion y , y_conceptos_nom c , terceros t " &
                                "WHERE (mes) = " & mes_select & " And (ano)  = " & anoIni & " AND t.nit = y.nit AND y.concepto = c.concepto AND y.concepto IN (" & conceptos & ") " & whereCentro & " " & whereNit & " " & _
                                    "GROUP BY y.centro,c.concepto" & sqlNit & ",c.descripcion "
                        Else
                            sql = "SELECT y.centro,c.concepto" & sqlNit & ",c.descripcion,SUM(y.horas)As horas,SUM(y.valor) as valor " &
                                    " FROM y_liquidacion y , y_conceptos_nom c , terceros t " &
                                        "WHERE (mes) >= " & mesIni & " And (ano)  = " & anoIni & " AND  (mes)  <= " & mesFin & "  AND t.nit = y.nit AND y.concepto = c.concepto AND y.concepto IN (" & conceptos & ") " & whereCentro & " " & whereNit & " " & _
                                            "GROUP BY y.centro,c.concepto" & sqlNit & ",c.descripcion "
                        End If

                    End If
                End If
                dt = objOpSimplesLn.listar_datatable(sql, "CORSAN")
                dt.Rows.Add()
                For j = 0 To dt.Columns.Count - 1
                    If (dt.Columns(j).ColumnName = "horas" Or dt.Columns(j).ColumnName = "valor" Or dt.Columns(j).ColumnName = "tiempo_debe") Then
                        For i = 0 To dt.Rows.Count - 2
                            If Not IsDBNull(dt.Rows(i).Item(j)) Then
                                sum += dt.Rows(i).Item(j)
                            End If
                        Next
                        dt.Rows(dt.Rows.Count - 1).Item(j) = sum
                        sum = 0
                    End If
                Next
                dtgDetalle.DataSource = dt
                dtgDetalle.Rows(dtgDetalle.Rows.Count - 1).DefaultCellStyle = objOperacionesForm.formatoNegrita(tamano_letra)
            End If

        End If
    End Sub

    Private Sub btn_cerrar_graf_Click(sender As Object, e As EventArgs) Handles btn_cerrar_graf.Click
        dtgDetalle.DataSource = Nothing
        groupDetalle.Visible = False
    End Sub

    Private Sub GraficarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GraficarToolStripMenuItem.Click
        graficar_trazabilidad(fila_select)
    End Sub
    Public Sub graficar_trazabilidad(ByVal fila As Integer)
        btn_cerrar_grafico.Visible = True
        Chart1.Visible = True
        Chart1.Titles.Clear()
        Chart1.Series.Clear()
        Chart1.ChartAreas.Clear()
        Chart1.ChartAreas.Add(0)
        Chart1.Series.Add("horas")
        Dim valor As Integer = 0
        Dim cant As Integer = 0
        Dim num_dia_semana As Integer = 0
        For j = 2 To dtgConsulta.Columns.Count - 1
            If IsNumeric(dtgConsulta.Item(j, fila).Value) Then
                valor = dtgConsulta.Item(j, fila).Value
                If Not buscar_palabra_val(dtgConsulta.Columns(j).Name) Then
                    Chart1.Series("horas").Points.AddXY(dtgConsulta.Columns(j).Name, valor)
                    Chart1.Series("horas").Points(cant).ToolTip = dtgConsulta.Columns(j).Name
                End If
            End If
        Next
        Chart1.Series("horas").ChartType = DataVisualization.Charting.SeriesChartType.Line

        Chart1.Series("horas").IsValueShownAsLabel = True
        Chart1.ChartAreas(0).AxisX.Title = "Meses"
        Chart1.ChartAreas(0).AxisY.Title = "Tiempos laborados"
        Chart1.Refresh()
    End Sub

    Private Sub btn_cerrar_grafico_Click(sender As Object, e As EventArgs) Handles btn_cerrar_grafico.Click
        Chart1.Visible = False
        btn_cerrar_grafico.Visible = False
    End Sub
    Private Function buscar_palabra_val(ByVal texto As String) As Boolean
        Dim palabra As String = ""
        Dim encontro As Boolean = False
        For i = 0 To texto.Length - 1
            If texto(i) = "v" Or texto(i) = "V" Then
                encontro = True
            End If
            If encontro Then
                palabra &= texto(i)
            End If
        Next
        If palabra = "val" Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub DetalleDeIncapacidadesAñoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DetalleDeIncapacidadesAñoToolStripMenuItem.Click
        groupDetalle.Visible = True
        Dim tamano_letra As Single = 9.0!
        Dim sql As String = ""
        Dim anoIni As String = cboAnoIni.Text
        Dim conceptos As String = "'5', '6', '7', '8', '9','10','11', '25', '34', '35', '36', '37', '68', '77', '510', '511', '512', '513', '516'"
        Dim whereCentro As String = ""
        Dim centro As String = ""
        Dim whereNit As String = ""
        Dim sqlNit As String = ""
        Dim dt As New DataTable
        Dim sum As Double = 0
        For i = 0 To dtgConsulta.Columns.Count - 1
            If (dtgConsulta.Columns(i).Name = "nit") Then
                whereNit = "AND y.nit = " & dtgConsulta.Item("nit", dtgConsulta.CurrentCell.RowIndex).Value & " "
                sqlNit = ",y.nit,t.nombres"
                i = dtgConsulta.Columns.Count - 1
            ElseIf dtgConsulta.Columns(i).Name = "centro" Then
                If IsNumeric(dtgConsulta.Item("centro", fila_select).Value) Then
                    centro = dtgConsulta.Item("centro", fila_select).Value
                    whereCentro &= " AND  y.centro  = " & centro
                End If
            End If
        Next
        If (cboCentro.SelectedValue <> 0) Then
            centro = cboCentro.SelectedValue
            whereCentro &= " AND  y.centro  = " & centro
        Else
            If (centros <> "") Then
                whereCentro &= " AND  y.centro in (" & centros & ") "
            Else
                whereCentro &= " AND y.centro not in (4200,4300,4324,4328,4332,4334,4398,4399)"
            End If
        End If
        sql = "SELECT     nit, nombres,  centro, Descr_centro, concepto,desc_concepto,diagnostico, descripcion,( CAST (dias_incap AS decimal(18,0)))As dias_incap,( CAST (dias_incap AS decimal(18,0))) * 8 As horas_incap, fecha_inicial, fecha_final,valor_pagado As valor " & _
                "FROM Jjv_nom_detalle_incap y " & _
                     "WHERE YEAR(fecha_inicial)  = " & anoIni & " AND concepto IN (" & conceptos & ") " & whereCentro & " " & whereNit & " " & _
                        "ORDER BY nombres"
        dt = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        dt.Rows.Add()
        For j = 0 To dt.Columns.Count - 1
            If (dt.Columns(j).ColumnName = "horas" Or dt.Columns(j).ColumnName = "valor" Or dt.Columns(j).ColumnName = "tiempo_debe") Then
                For i = 0 To dt.Rows.Count - 2
                    If Not IsDBNull(dt.Rows(i).Item(j)) Then
                        sum += dt.Rows(i).Item(j)
                    End If
                Next
                dt.Rows(dt.Rows.Count - 1).Item(j) = sum
                sum = 0
            End If
        Next
        dtgDetalle.DataSource = dt
        dtgDetalle.Rows(dtgDetalle.Rows.Count - 1).DefaultCellStyle = objOperacionesForm.formatoNegrita(tamano_letra)
        dtgDetalle.Columns("fecha_inicial").DefaultCellStyle.Format = "d"
        dtgDetalle.Columns("fecha_final").DefaultCellStyle.Format = "d"
        dtgDetalle.Columns("nit").Frozen = True
        dtgDetalle.Columns("nombres").Frozen = True
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        group_detalle_concepto.Visible = True
        group_detalle_concepto.BringToFront()
        Dim tamano_letra As Single = 9.0!
        Dim sql As String = ""
        Dim anoIni As String = cboAnoIni.Text
        Dim mesIni As String = cboMesIni.SelectedIndex + 1
        Dim mesFin As String = cboMesFin.SelectedIndex + 1
        Dim whereCentro As String = ""
        Dim concepto As String = ""
        Dim centro As String = ""
        Dim whereNit As String = ""
        Dim sqlNit As String = ""
        Dim dt As New DataTable
        Dim sum As Double = 0
        For i = 0 To dtgDetalle.Columns.Count - 1
            If (dtgDetalle.Columns(i).Name = "nit") Then
                whereNit = "AND y.nit = " & dtgDetalle.Item("nit", dtgDetalle.CurrentCell.RowIndex).Value & " "
                sqlNit = ",y.nit,t.nombres"
                i = dtgDetalle.Columns.Count - 1
            ElseIf dtgDetalle.Columns(i).Name = "centro" Then
                If IsNumeric(dtgDetalle.Item("centro", fila_select_detalle).Value) Then
                    centro = dtgDetalle.Item("centro", fila_select_detalle).Value
                    whereCentro &= " AND  y.centro  = " & centro
                End If
            ElseIf dtgDetalle.Columns(i).Name = "concepto" Then
                If IsNumeric(dtgDetalle.Item("concepto", fila_select_detalle).Value) Then
                    concepto = dtgDetalle.Item("concepto", fila_select_detalle).Value
                End If
            End If
        Next

        sql = "SELECT y.centro,t.nombres,c.concepto" & sqlNit & ",c.descripcion,SUM(y.horas)As horas,SUM(y.valor) as valor " &
                        " FROM y_liquidacion y , y_conceptos_nom c , terceros t " &
                            "WHERE (mes) >= " & mesIni & " And (ano)  = " & anoIni & " AND  (mes)  <= " & mesFin & "  AND t.nit = y.nit AND y.concepto = c.concepto AND y.concepto = " & concepto & " " & whereCentro & " " & whereNit & " " & _
                                "GROUP BY t.nombres,y.centro,c.concepto" & sqlNit & ",c.descripcion "
        dt = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        dt.Rows.Add()
        For j = 0 To dt.Columns.Count - 1
            If (dt.Columns(j).ColumnName = "horas" Or dt.Columns(j).ColumnName = "valor" Or dt.Columns(j).ColumnName = "tiempo_debe") Then
                For i = 0 To dt.Rows.Count - 2
                    If Not IsDBNull(dt.Rows(i).Item(j)) Then
                        sum += dt.Rows(i).Item(j)
                    End If
                Next
                dt.Rows(dt.Rows.Count - 1).Item(j) = sum
                sum = 0
            End If
        Next
        dtg_detalle_concepto.DataSource = dt
        dtg_detalle_concepto.Rows(dtg_detalle_concepto.Rows.Count - 1).DefaultCellStyle = objOperacionesForm.formatoNegrita(tamano_letra)
        dtg_detalle_concepto.Columns("nombres").Frozen = True
    End Sub
    Private Sub dtgDetalle_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dtgDetalle.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            With (Me.dtgDetalle)
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                End If
            End With
            fila_select_detalle = (dtgDetalle.CurrentCell.RowIndex)
        End If
    End Sub

    Private Sub btn_cerrar_det_concepto_Click(sender As Object, e As EventArgs) Handles btn_cerrar_det_concepto.Click
        group_detalle_concepto.Visible = False
    End Sub
End Class