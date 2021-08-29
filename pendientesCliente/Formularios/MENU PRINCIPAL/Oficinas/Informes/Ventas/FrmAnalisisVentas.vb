Imports logicaNegocios
Public Class FrmAnalisisVentas
    Private objOperacionesForm As OperacionesFormularios = New OperacionesFormularios
    Private obj_op_simplesLn As New Op_simpesLn
    Dim mes As Integer
    Dim ano As Integer
    Dim dias_habiles As Integer
    Dim criterio As String
    Private Sub FrmAnalisisVentas_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim año = Now.Year
        While (año >= Now.Year - 5)
            cbo_ano.Items.Add(año)
            año -= 1
        End While
        cbo_ano.Text = Now.Year
        cbo_mes.SelectedIndex = Now.Month - 1
    End Sub

    Private Sub btnActualizar_Click(sender As System.Object, e As System.EventArgs) Handles btnActualizar.Click
        If (cbo_ano.Text <> "Seleccione") Then
            If (cbo_mes.Text <> "Seleccione") Then
                If (Now.Year >= ano) Then
                    cargar()
                Else
                    MessageBox.Show("El mes y año seleccionado soy mayores ala fecha actual,seleccione un rango de fecha valido.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                MessageBox.Show("Seleccione un mes para realizar el informe!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            MessageBox.Show("Seleccione un año para realizar el informe!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Private Sub cargar()

        imgProc.Visible = True
        Application.DoEvents()
        Dim cant_festivos As Integer = 0
        Dim dias_trbajados As Integer = 0
        Dim nomb_Cumpliminento As String
        Dim ano_ant As Integer = ano - 1
        Dim criterio_vtas As String
        Dim criterio_ppto As String
        Dim whereVentasSql As String = "WHERE g.Id_cor = v.Id_cor "
        Dim wherePptoSql As String = "WHERE Id_cor is not null and Year(p.Fecha_ppto) = " & ano & "  "
        Dim whereVentasAntSql As String = "WHERE g.Id_cor = v.Id_cor "
        Dim ult_dia_mes As Integer = DateSerial(ano, mes + 1, 0).Day
        If (ano >= 2014) Then
            cant_festivos = obj_op_simplesLn.cant_festivos(31, mes, ano)
            dias_habiles = obj_op_simplesLn.calcDiasHabilesVentas(ano & "-" & mes & "-01", ano & "-" & mes & "-" & ult_dia_mes)
            dias_habiles -= cant_festivos
            If (mes <> Now.Month) Then
                dias_trbajados = dias_habiles
            Else
                dias_trbajados = obj_op_simplesLn.calcDiasHabilesVentas(ano & "-" & mes & "-01", ano & "-" & mes & "-" & Now.Day)
                dias_trbajados -= obj_op_simplesLn.cant_festivos(Now.Day, mes, ano)
            End If
            txt_dias_habiles.Text = dias_habiles
            txt_dias_trab.Text = dias_trbajados
            txt_dias_habiles.Visible = True
            txt_dias_trab.Visible = True
            lbl_dias_habiles.Visible = True
            lbl_dias_trab.Visible = True
        Else
            txt_dias_habiles.Visible = False
            txt_dias_trab.Visible = False
            lbl_dias_habiles.Visible = False
            lbl_dias_trab.Visible = False
        End If



        If (chk_por_mes.Checked) Then
            whereVentasSql &= "And Month(v.fec) = " & mes & " And Year(v.fec) = " & ano & " "
            wherePptoSql &= "AND Month(p.Fecha_ppto) = " & mes & "   "
            If (Now.Month = mes And ano = Now.Year) Then
                whereVentasAntSql &= "And Month(v.fec) = " & mes & " And Year(v.fec) = " & ano_ant & " AND Day (v.fec) <= " & Now.Day
            Else
                whereVentasAntSql &= "And Month(v.fec) = " & mes & " And Year(v.fec) = " & ano_ant & " "
            End If
        Else
            whereVentasSql &= "And Month(v.fec) <= " & mes & " And Year(v.fec) = " & ano & " "
            wherePptoSql &= "AND Month(p.Fecha_ppto) <= " & mes & "   "
            If (Now.Month = mes And ano = Now.Year) Then
                whereVentasAntSql &= "And Month(v.fec) <= " & mes & " And Year(v.fec) = " & ano_ant & " AND Day (v.fec) <= " & Now.Day & " "
            Else
                whereVentasAntSql &= "And Month(v.fec) <= " & mes & " And Year(v.fec) = " & ano_ant & " "
            End If
        End If
        If (ChkPesos.Checked) Then
            criterio = "PESOS"
            criterio_vtas = "Vr_total"
            criterio_ppto = "Vr_total"
        Else
            criterio = "KILOS"
            criterio_vtas = "KILOS"
            criterio_ppto = "Ppto_kilos"
        End If
        Dim sql_ventas As String = "SELECT v.id_cor,g.Descripcion As linea, SUM (v." & criterio_vtas & " )As Ventas" & ano & "  " & _
                                      "FROM Jjv_V_vtas_vend_cliente_ref v , JJV_Grupos_seguimiento g " & _
                                            whereVentasSql & _
                                       "GROUP BY v.Id_cor , g.Descripcion " &
                                       "ORDER BY v.id_cor"
        Dim sql_ppto As String = "SELECT p.Id_cor,SUM (p." & criterio_ppto & " )As ppto " & _
                                 "FROM Jjv_Ppto_mes p " & _
                                        wherePptoSql & _
                                    "GROUP BY p.Id_cor "
        Dim sql_ventas_ant As String = "SELECT v.id_cor,g.Descripcion As linea, SUM (v." & criterio_vtas & " )As Ventas" & ano_ant & " " & _
                                      "FROM Jjv_V_vtas_vend_cliente_ref v , JJV_Grupos_seguimiento g " & _
                                            whereVentasAntSql & _
                                       "GROUP BY v.Id_cor , g.Descripcion " &
                                       "ORDER BY v.id_cor"
        Dim dt_consulta As New DataTable
        Dim dt_ppto As New DataTable
        Dim dt_vtas_ant As New DataTable
        dt_consulta = obj_op_simplesLn.listar_datatable(sql_ventas, "CORSAN")
        dt_ppto = obj_op_simplesLn.listar_datatable(sql_ppto, "CORSAN")
        dt_vtas_ant = obj_op_simplesLn.listar_datatable(sql_ventas_ant, "CORSAN")
        If (Now.Month = mes And ano = Now.Year) Then
            nomb_Cumpliminento = "%Cump_hoy"
            dt_consulta.Columns.Add("Ppto_hoy", GetType(Double))
        Else
            nomb_Cumpliminento = "%Cump"
        End If
        dt_consulta.Columns.Add("Ppto" & ano, GetType(Double))
        dt_consulta.Columns.Add(nomb_Cumpliminento, GetType(Double))
        dt_consulta.Columns.Add("Falta", GetType(Double))
        dt_consulta.Columns.Add("iC", GetType(Image))
        dt_consulta.Columns.Add("Ventas" & ano_ant, GetType(Double))
        dt_consulta.Columns.Add("%Crec", GetType(Double))
        dt_consulta.Columns.Add("iCr", GetType(Image))
        Dim id_cor_vtas As Integer = 0
        For i = 0 To dt_consulta.Rows.Count - 1
            id_cor_vtas = dt_consulta.Rows(i).Item("id_cor")
            For j = 0 To dt_ppto.Rows.Count - 1
                If (dt_ppto.Rows(j).Item("id_cor") = id_cor_vtas) Then
                    dt_consulta.Rows(i).Item("Ppto" & ano) = dt_ppto.Rows(j).Item("ppto")
                    If (Now.Month = mes And ano = Now.Year And dias_habiles <> 0 And Not IsDBNull(dt_consulta.Rows(i).Item("Ppto" & ano))) Then
                        dt_consulta.Rows(i).Item("Ppto_hoy") = (dt_consulta.Rows(i).Item("Ppto" & ano) / dias_habiles) * dias_trbajados
                    End If
                    j = dt_ppto.Rows.Count - 1
                End If
            Next
            For k = 0 To dt_vtas_ant.Rows.Count - 1
                If (dt_vtas_ant.Rows(k).Item("id_cor") = id_cor_vtas) Then
                    dt_consulta.Rows(i).Item("Ventas" & ano_ant) = dt_vtas_ant.Rows(k).Item("Ventas" & ano_ant)
                    k = dt_vtas_ant.Rows.Count - 1
                End If
            Next
        Next
        dt_consulta.Rows.Add()
        dt_consulta.Rows(dt_consulta.Rows.Count - 1).Item("linea") = "TOTAL"
        dtg_consulta.DataSource = Nothing
        dtg_consulta.DataSource = dt_consulta
        dtg_consulta.Columns(nomb_Cumpliminento).DefaultCellStyle.Format = "N1"
        dtg_consulta.Columns("%Crec").DefaultCellStyle.Format = "N1"
        dtg_consulta.Item(nomb_Cumpliminento, dtg_consulta.RowCount - 1).Style.Format = "N1"
        dtg_consulta.Item("%Crec", dtg_consulta.RowCount - 1).Style.Format = "N1"
        sumarCol()
        calc_porcentajes(nomb_Cumpliminento)
        faltantes()
        dtg_consulta.Rows(dtg_consulta.RowCount - 1).DefaultCellStyle.BackColor = Color.Red
        dtg_consulta.Columns("id_cor").Visible = False
        imgProc.Visible = False
    End Sub
    Private Sub faltantes()
        For i = 0 To dtg_consulta.RowCount - 1
            If Not IsDBNull(dtg_consulta.Item("id_cor", i).Value) Then
                If (dtg_consulta.Item("id_cor", i).Value <> "28" And dtg_consulta.Item("id_cor", i).Value <> "30" And dtg_consulta.Item("id_cor", i).Value <> "29") Then
                    Dim ventas As Double

                    If dtg_consulta.Columns.Contains("Ppto_hoy") Then
                        If IsDBNull(dtg_consulta.Item("Ppto_hoy", i).Value) Then
                            ventas = 0
                        Else
                            ventas = ventas = dtg_consulta.Item("Ppto_hoy", i).Value
                        End If
                        If (Now.Month = mes And ano = Now.Year) Then
                            dtg_consulta.Item("Falta", i).Value = ventas - dtg_consulta.Item("Ventas" & ano, i).Value
                        Else
                            If IsNumeric(dtg_consulta.Item("Ppto" & ano, i).Value) And IsNumeric(dtg_consulta.Item("Ventas" & ano, i).Value) Then
                                dtg_consulta.Item("Falta", i).Value = dtg_consulta.Item("Ppto" & ano, i).Value - dtg_consulta.Item("Ventas" & ano, i).Value
                            ElseIf IsNumeric(dtg_consulta.Item("Ventas" & ano, i).Value) Then
                                dtg_consulta.Item("Falta", i).Value = dtg_consulta.Item("Ventas" & ano, i).Value
                            End If
                        End If
                        If (dtg_consulta.Item("Falta", i).Value > 0) Then
                            dtg_consulta.Item("Falta", i).Style.BackColor = Color.Red
                        End If
                    End If
                Else
                    dtg_consulta.Item("Falta", i).Value = 0
                End If
            End If
        Next
    End Sub
    Private Sub sumarCol()
        Dim ano_ant As Integer = ano - 1
        Dim sum As Double = 0
        For j = 0 To dtg_consulta.Columns.Count - 1
            sum = 0
            If (dtg_consulta.Columns(j).Name = "Ventas" & ano Or dtg_consulta.Columns(j).Name = "Ppto" & ano Or dtg_consulta.Columns(j).Name = "Ventas" & ano_ant Or dtg_consulta.Columns(j).Name = "Ppto_hoy") Then
                For i = 0 To dtg_consulta.RowCount - 2
                    If Not IsDBNull(dtg_consulta.Item(dtg_consulta.Columns(j).Name, i).Value) Then
                        If (dtg_consulta.Item("id_cor", i).Value <> "28" And dtg_consulta.Item("id_cor", i).Value <> "30" And dtg_consulta.Item("id_cor", i).Value <> "29") Then
                            sum += dtg_consulta.Item(dtg_consulta.Columns(j).Name, i).Value
                        Else
                            dtg_consulta.Rows(i).DefaultCellStyle.BackColor = Color.Black
                            dtg_consulta.Rows(i).DefaultCellStyle.ForeColor = Color.White
                        End If
                    End If
                Next
                dtg_consulta.Item(dtg_consulta.Columns(j).Name, dtg_consulta.RowCount - 1).Value = sum
            End If
        Next
    End Sub
    Private Sub calc_porcentajes(ByVal nomb_Cumpliminento As String)
        Dim ano_ant As Integer = ano - 1
        For i = 0 To dtg_consulta.RowCount - 1
            If Not IsDBNull(dtg_consulta.Item("Ppto" & ano, i).Value) Then

                If (Now.Month = mes And ano = Now.Year And dias_habiles <> 0) Then
                    If Not IsDBNull(dtg_consulta.Item("Ppto_hoy", i).Value) Then
                        dtg_consulta.Item(nomb_Cumpliminento, i).Value = ((dtg_consulta.Item("Ventas" & ano, i).Value) / dtg_consulta.Item("Ppto_hoy", i).Value) * 100
                    Else
                        dtg_consulta.Item(nomb_Cumpliminento, i).Value = 0
                    End If

                Else
                    dtg_consulta.Item(nomb_Cumpliminento, i).Value = ((dtg_consulta.Item("Ventas" & ano, i).Value) / dtg_consulta.Item("Ppto" & ano, i).Value) * 100
                End If
                If (dtg_consulta.Item(nomb_Cumpliminento, i).Value >= 95) Then
                    dtg_consulta.Item("iC", i).Value = Spic.My.Resources.ok3
                ElseIf (dtg_consulta.Item(nomb_Cumpliminento, i).Value < 95) Then
                    dtg_consulta.Item("iC", i).Value = Spic.My.Resources._1371750041_14125
                End If
            Else
                dtg_consulta.Item(nomb_Cumpliminento, i).Value = 0
                dtg_consulta.Item("iC", i).Value = Spic.My.Resources._1371750041_14125
            End If
            If Not IsDBNull(dtg_consulta.Item("Ventas" & ano_ant, i).Value) Then
                dtg_consulta.Item("%Crec", i).Value = ((dtg_consulta.Item("Ventas" & ano, i).Value) / dtg_consulta.Item("Ventas" & ano_ant, i).Value) * 100
                dtg_consulta.Item("%Crec", i).Value = dtg_consulta.Item("%Crec", i).Value - 100
                'If (dtg_consulta.Item("%Crec", i).Value < 100) Then
                '    dtg_consulta.Item("%Crec", i).Value = dtg_consulta.Item("%Crec", i).Value * -1
                'ElseIf (dtg_consulta.Item("%Crec", i).Value = 100) Then
                '    dtg_consulta.Item("%Crec", i).Value = 0
                'End If

                If (dtg_consulta.Item("%Crec", i).Value >= 1) Then
                    dtg_consulta.Item("iCr", i).Value = Spic.My.Resources.ok3
                ElseIf (dtg_consulta.Item("%Crec", i).Value <= 0) Then
                    dtg_consulta.Item("iCr", i).Value = Spic.My.Resources._1371750041_14125
                End If
            Else
                dtg_consulta.Item("%Crec", i).Value = 0
                dtg_consulta.Item("iCr", i).Value = Spic.My.Resources._1371750041_14125
            End If
        Next
    End Sub
    Private Sub ChkPesos_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles ChkPesos.CheckedChanged
        If (ChkPesos.Checked = True) Then
            chkKil.Checked = False
        End If
    End Sub

    Private Sub chkKil_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkKil.CheckedChanged
        If (chkKil.Checked = True) Then
            ChkPesos.Checked = False
        End If
    End Sub

    Private Sub btn_exportar_Click(sender As System.Object, e As System.EventArgs) Handles btn_exportar.Click
        objOperacionesForm.ExportarDatosExcel(dtg_consulta, "Analisis de ventas por linea de producción (" & criterio & ") -  " & mes & " - " & ano)
    End Sub

 
    Private Sub chk_acumulado_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chk_acumulado.CheckedChanged
        If (chk_acumulado.Checked = True) Then
            chk_por_mes.Checked = False
        End If
    End Sub

    Private Sub chk_por_mes_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chk_por_mes.CheckedChanged
        If (chk_por_mes.Checked = True) Then
            chk_acumulado.Checked = False
        End If
    End Sub


    Private Sub cbo_mes_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbo_mes.SelectedIndexChanged
        mes = cbo_mes.SelectedIndex + 1
    End Sub

    Private Sub cbo_ano_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbo_ano.SelectedIndexChanged
        ano = cbo_ano.Text
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
End Class