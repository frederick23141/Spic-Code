Imports logicaNegocios
Imports entidadNegocios
Public Class Frm_rotacion_personal
    Private objOpSimplesLn As New Op_simpesLn
    Dim carga_comp As Boolean = False
    Private objOperacionesForm As OperacionesFormularios = New OperacionesFormularios
    Dim centros As String = ""

    Private Sub Frm_rotacion_personal_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Dim año = Now.Year
        While (año >= Now.Year - 5)
            cboAnoIni.Items.Add(año)
            año -= 1
        End While
        cboAnoIni.Text = Now.Year
        cboMesIni.SelectedIndex = 0
        cboMesFin.SelectedIndex = Now.Month - 1


    End Sub


    Private Sub btnActualizar_Click(sender As System.Object, e As System.EventArgs) Handles btnActualizar.Click
        img_procesar.Visible = True
        dtgConsulta.DataSource = Nothing
        Application.DoEvents()
        trasabilidad()
        img_procesar.Visible = False
    End Sub
    Private Sub alertas()
        Dim alerta As Double = 0
        For i = 1 To dtgConsulta.Columns.Count - 1
            If Not IsDBNull(dtgConsulta.Item(i, dtgConsulta.Rows.Count - 2).Value) Then
                If (dtgConsulta.Item(i, dtgConsulta.Rows.Count - 2).Value) > 1.5 Then
                    dtgConsulta.Item(i, dtgConsulta.Rows.Count - 2).Style.BackColor = Color.Red
                ElseIf (dtgConsulta.Item(i, dtgConsulta.Rows.Count - 2).Value > 1.0 And dtgConsulta.Item(i, dtgConsulta.Rows.Count - 2).Value <= 1.5) Then
                    dtgConsulta.Item(i, dtgConsulta.Rows.Count - 2).Style.BackColor = Color.Yellow
                Else
                    dtgConsulta.Item(i, dtgConsulta.Rows.Count - 2).Style.BackColor = Color.Green
                End If
            End If
        Next
    End Sub
    Private Sub trasabilidad()
        Dim tamano_letra As Single = 9.0!
        Dim dt_nueva As New DataTable
        Dim tabla As String = ""
        Dim campo As String = ""
        Dim sql_tot_personal As String = ""
        Dim sql_ingreso As String = ""
        Dim sql_retiro As String = ""
        Dim anoIni As String = cboAnoIni.Text
        Dim mesIni As String = cboMesIni.SelectedIndex + 1
        Dim mesFin As String = cboMesFin.SelectedIndex + 1
        Dim dt_tot_personal As New DataTable
        Dim dt_ingreso As New DataTable
        Dim dt_retiro As New DataTable
        Dim sql_observaciones As String = "SELECT observaciones FROM J_observaciones_rotacion WHERE ano =" & anoIni
        Dim sum As Double = 0
        sql_tot_personal = "SELECT YEAR (y.fecha_pago)As ano,MONTH(y.fecha_pago)As mes,COUNT(DISTINCT y.nit)As total " & _
                     "FROM y_pago_nomina  y inner join y_personal_contratos c  on y.contrato=c.contrato" & _
                         " WHERE MONTH(y.fecha_pago) >= " & mesIni & " And YEAR (y.fecha_pago) = " & anoIni & " AND  MONTH(y.fecha_pago) <= " & mesFin & " AND c.tipo_contrato not in('Z') " & _
                            "GROUP BY YEAR (y.fecha_pago),MONTH(y.fecha_pago) " & _
                                    "ORDER by YEAR (y.fecha_pago),MONTH(y.fecha_pago) "
        sql_ingreso = "SELECT YEAR( fecha_ingreso) As ano,MONTH(fecha_ingreso) As mes, COUNT( fecha_ingreso) As total  " & _
                        "FROM y_personal_contratos " & _
                            "WHERE MONTH(fecha_ingreso) >= " & mesIni & " And YEAR (fecha_ingreso) = " & anoIni & " AND  MONTH(fecha_ingreso) <= " & mesFin & "AND tipo_contrato not in('Z') " & _
                                 "GROUP BY YEAR( fecha_ingreso),MONTH(fecha_ingreso) " & _
                                      "ORDER BY YEAR( fecha_ingreso) ,MONTH( fecha_ingreso)"
        sql_retiro = "SELECT YEAR( fecha_final) As ano,MONTH(fecha_final) As mes,COUNT( distinct(nit)) As total " & _
                            "FROM y_personal_contratos " & _
                                  "WHERE fecha_final Is Not null AND MONTH(fecha_final) >= " & mesIni & " And YEAR (fecha_final) = " & anoIni & " AND  MONTH(fecha_final) <= " & mesFin & " AND TIPO_CONTRATO NOT IN('Z')" & _
                                      "GROUP BY YEAR( fecha_final),MONTH(fecha_final)"
        dt_tot_personal = objOpSimplesLn.listar_datatable(sql_tot_personal, "CORSAN")
        dt_ingreso = objOpSimplesLn.listar_datatable(sql_ingreso, "CORSAN")
        dt_retiro = objOpSimplesLn.listar_datatable(sql_retiro, "CORSAN")
        dt_nueva = armarDt(dt_tot_personal)
        add_item(dt_nueva, dt_tot_personal, "PERSONAL EXISTENTE (TOTAL)")
        add_item(dt_nueva, dt_ingreso, "INGRESO MES")
        add_item(dt_nueva, dt_retiro, "RETIRO MES")
        add_practicantes(dt_nueva, "APRENDIZ")
        porcentajes(dt_nueva)
        dtgConsulta.DataSource = dt_nueva
        dtgConsulta.Rows(dtgConsulta.Rows.Count - 1).DefaultCellStyle.Format = "N2"
        dtgConsulta.Rows(dtgConsulta.Rows.Count - 2).DefaultCellStyle = objOperacionesForm.formatoNegrita(tamano_letra)
        dtgConsulta.Rows(dtgConsulta.Rows.Count - 2).DefaultCellStyle.Format = "N2"
        alertas()
        txt_observaciones.Text = objOpSimplesLn.consultarVal(sql_observaciones)
        dtgConsulta.CurrentCell = Nothing
        For i = 0 To dtgConsulta.Rows.Count - 1
            If dtgConsulta.Item("concepto", i).Value = "mes" Or dtgConsulta.Item("concepto", i).Value = "ano" Then
                dtgConsulta.Rows(i).Visible = False
            End If
        Next
    End Sub
    Private Sub add_item(ByRef dt_ppal As DataTable, ByVal dt_nueva As DataTable, ByVal concepto As String)
        Dim nombMes As String = ""
        Dim nombMes_dtNueva As String = ""
        dt_ppal.Rows.Add()
        dt_ppal.Rows(dt_ppal.Rows.Count - 1).Item("concepto") = concepto
        For i = 0 To dt_nueva.Rows.Count - 1
            nombMes_dtNueva = MonthName(dt_nueva.Rows(i).Item("mes"), True).ToUpper & " - " & dt_nueva.Rows(i).Item("ano")
            For j = 1 To dt_ppal.Columns.Count - 1
                nombMes = dt_ppal.Columns(j).ColumnName
                If (nombMes_dtNueva = nombMes) Then
                    dt_ppal.Rows(dt_ppal.Rows.Count - 1).Item(nombMes) = dt_nueva.Rows(i).Item("total")
                    'j = dt_ppal.Rows.Count - 1
                End If
            Next
        Next
    End Sub
    Private Function armarDt(ByRef dtDatos As DataTable) As DataTable
        Dim dtResp As New DataTable
        Dim nombMes As String = ""
        Dim mesAnoEncontrado As Boolean = False
        dtResp.Columns.Add("concepto")
        dtResp.Rows.Add()
        dtResp.Rows(dtResp.Rows.Count - 1).Item("concepto") = "ano"
        dtResp.Rows.Add()
        dtResp.Rows(dtResp.Rows.Count - 1).Item("concepto") = "mes"
        For i = 0 To dtDatos.Rows.Count - 1
            nombMes = MonthName(dtDatos.Rows(i).Item("mes"), True).ToUpper & " - " & dtDatos.Rows(i).Item("ano")
            For j = 0 To dtResp.Columns.Count - 1
                If (dtResp.Columns(j).ColumnName = nombMes) Then
                    mesAnoEncontrado = True
                End If
            Next
            If (mesAnoEncontrado = False) Then
                dtResp.Columns.Add(nombMes, GetType(Double))
                dtResp.Rows(dtResp.Rows.Count - 1).Item(nombMes) = dtDatos.Rows(i).Item("mes")
                dtResp.Rows(dtResp.Rows.Count - 2).Item(nombMes) = dtDatos.Rows(i).Item("ano")
            End If
            mesAnoEncontrado = False
        Next
        Return dtResp
    End Function
    Private Sub add_practicantes(ByRef dt_ppal As DataTable, ByVal concepto As String)
        dt_ppal.Rows.Add()
        dt_ppal.Rows(dt_ppal.Rows.Count - 1).Item("concepto") = concepto
        Dim nombMes As String = ""
        Dim nombMes_dtPract As String = ""
        Dim anoIni As String = cboAnoIni.Text
        Dim mesIni As String = cboMesIni.SelectedIndex + 1
        Dim mesFin As String = cboMesFin.SelectedIndex + 1
        Dim fec_ini As String = anoIni & "-" & mesIni & "-01"
        Dim dt_practicantes As New DataTable
        Dim dt_meses_practica As New DataTable
        Dim d_fec_fin As Date = DateSerial(anoIni, mesFin + 1, 1 - 1)
        Dim fec_fin As String = objOpSimplesLn.cambiarFormatoFecha(d_fec_fin)
        Dim fecha_ingreso As String = ""
        Dim fecha_retiro As String = ""
        Dim sql As String = "SELECT fecha_ingreso,fecha_final,nit " & _
                        "FROM y_personal_contratos " & _
                "WHERE tipo_contrato ='Z'AND fecha_ingreso <> fecha_final AND (fecha_final >='" & fec_ini & "' ) AND ( fecha_ingreso <='" & fec_fin & "' )"
        dt_practicantes = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        For i = 0 To dt_practicantes.Rows.Count - 1
            fecha_ingreso = objOpSimplesLn.cambiarFormatoFecha(dt_practicantes.Rows(i).Item("fecha_ingreso"))
            fecha_retiro = objOpSimplesLn.cambiarFormatoFecha(dt_practicantes.Rows(i).Item("fecha_final"))
            dt_meses_practica = meses_practica(fecha_ingreso, fecha_retiro)
            For j = 0 To dt_meses_practica.Rows.Count - 1
                nombMes_dtPract = MonthName(dt_meses_practica.Rows(j).Item("mes"), True).ToUpper & " - " & dt_meses_practica.Rows(j).Item("ano")
                For k = 1 To dt_ppal.Columns.Count - 1
                    nombMes = dt_ppal.Columns(k).ColumnName
                    If (nombMes_dtPract = nombMes) Then
                        If Not IsNumeric(dt_ppal.Rows(dt_ppal.Rows.Count - 1).Item(nombMes)) Then
                            dt_ppal.Rows(dt_ppal.Rows.Count - 1).Item(nombMes) = 1
                        Else
                            dt_ppal.Rows(dt_ppal.Rows.Count - 1).Item(nombMes) += 1
                        End If
                    End If
                Next
            Next
        Next
    End Sub
    Private Function meses_practica(ByVal fec_ini As String, ByVal fec_fin As String) As DataTable
        Dim dt_meses As DataTable
        Dim sql As String = "WITH FECHAS(fecha) AS ( " & _
                "SELECT CAST('" & fec_ini & "' AS date) fecha " & _
                         "UNION ALL " & _
                "SELECT DATEADD(MONTH, 1, fecha) fecha " & _
                      "FROM FECHAS " & _
                            "WHERE fecha < CAST('" & fec_fin & "' AS date) )" & _
                                 "SELECT YEAR(fecha) as ano ,  MONTH(fecha) as mes  " & _
                                    "FROM FECHAS  " & _
                                      "ORDER BY ano,mes"
        dt_meses = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        Return dt_meses
    End Function
    Private Sub btnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Click
        objOperacionesForm.ExportarDatosExcel(dtgConsulta, "Rotación de personal")
    End Sub
    Private Sub porcentajes(ByRef dt As DataTable)
        dt.Rows.Add()
        dt.Rows(dt.Rows.Count - 1).Item("concepto") = "% PERS.RETIRADO"
        dt.Rows.Add()
        dt.Rows(dt.Rows.Count - 1).Item("concepto") = "% META ROTACION"
        Dim personal_ingre As Double
        Dim personal_sal As Double
        For j = 1 To dt.Columns.Count - 1
            For i = 6 To dt.Rows.Count - 2
                If IsDBNull(dt.Rows(3).Item(j)) Then
                    personal_ingre = 0
                Else
                    personal_ingre = dt.Rows(3).Item(j)
                End If
                If IsDBNull(dt.Rows(4).Item(j)) Then
                    personal_sal = 0
                Else
                    personal_sal = dt.Rows(4).Item(j)
                End If
                dt.Rows(dt.Rows.Count - 2).Item(j) = ((personal_ingre - personal_sal) / dt.Rows(2).Item(j)) * 100
                dt.Rows(dt.Rows.Count - 1).Item(j) = "1.5"
            Next
        Next

    End Sub




    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If (txt_observaciones.Text <> "") Then
            Dim sql As String = "SELECT *  FROM J_observaciones_rotacion WHERE ano = " & cboAnoIni.Text
            If (objOpSimplesLn.consultarVal(sql) = "") Then
                guardar()
            Else
                Dim resp As Integer = 0
                resp = MessageBox.Show("Ya existe obeservación para el año: " & cboAnoIni.Text & " desea sobre-escribirlo? ", "Modificar obeservación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If resp = 6 Then
                    guardar()
                End If
            End If
        Else
            MessageBox.Show("Ingrese una observacioón! ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Private Sub guardar()
        Dim listSql As New List(Of Object)
        Dim ano As Integer = cboAnoIni.Text
        Dim sql As String = "INSERT INTO J_observaciones_rotacion (ano,observaciones) VALUES (" & ano & ",'" & txt_observaciones.Text & "')"
        Dim sql_delete As String = "DELETE FROM J_observaciones_rotacion WHERE ano = " & ano
        listSql.Add(sql_delete)
        listSql.Add(sql)
        If (objOpSimplesLn.ExecuteSqlTransaction(listSql)) Then
            MessageBox.Show("El registro se guardo en forma exitosa!", "Exito!", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Error al ingresar el registro, comuniquese con el area de sistemas", "Verifique!", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
                If (dtgConsulta.CurrentCell.RowIndex < 0 Or dtgConsulta.CurrentCell.RowIndex >= dtgConsulta.Rows.Count - 2) Then
                    menStripDtg.Enabled = False
                ElseIf (dtgConsulta.Columns(dtgConsulta.CurrentCell.ColumnIndex).Name = "concepto") Then
                    menStripDtg.Enabled = False
                Else
                    menStripDtg.Enabled = True

                End If
            Else
                menStripDtg.Enabled = False
            End If
        End If
    End Sub
    Private Sub itemDetalle_Click(sender As Object, e As EventArgs) Handles itemDetalle.Click
        groupDetalle.Visible = True
        btn_cerrar_graf.Visible = True
        Dim mes As Integer = dtgConsulta.Item(dtgConsulta.CurrentCell.ColumnIndex, 1).Value
        Dim ano As Integer = dtgConsulta.Item(dtgConsulta.CurrentCell.ColumnIndex, 0).Value
        Dim concepto As String = dtgConsulta.Item("concepto", dtgConsulta.CurrentCell.RowIndex).Value
        Dim fec_ini As String = ano & "-" & mes & "-01"
        Dim d_fec_fin As Date = DateSerial(ano, mes + 1, 1 - 1)
        Dim fec_fin As String = objOpSimplesLn.cambiarFormatoFecha(d_fec_fin)
        Dim dt As New DataTable
        Dim sql As String = ""
        Dim sql_tot_personal As String = ""
        Dim sql_ingreso As String = ""
        Dim sql_retiro As String = ""

        Dim sql_practicantes As String = ""
        sql_tot_personal = "SELECT y.nit,t.nombres " & _
                     "FROM y_pago_nomina  y , terceros t " & _
                         "WHERE t.nit = y.nit AND MONTH(y.fecha_pago) = " & mes & " And YEAR (y.fecha_pago) = " & ano & " " & _
                            "GROUP BY y.nit,t.nombres  " & _
                                    "ORDER by t.nombres"
        sql_ingreso = "SELECT y.nit,t.nombres,y.fecha_ingreso,y.fecha_final " & _
                        "FROM y_personal_contratos y, terceros t  " & _
                            "WHERE t.nit = y.nit AND  MONTH(y.fecha_ingreso) = " & mes & " And YEAR (y.fecha_ingreso) = " & ano & " " & _
                   "ORDER by t.nombres"
        sql_retiro = "SELECT y.nit,t.nombres,y.fecha_ingreso,y.fecha_final,y.fecha_retiro   " & _
                            "FROM y_personal_contratos y, terceros t " & _
                                  "WHERE  t.nit = y.nit AND fecha_final Is Not null AND MONTH(y.fecha_final) = " & mes & " And YEAR (y.fecha_final) = " & ano & " " & _
                                      "ORDER by t.nombres"
        sql_practicantes = "SELECT y.nit,t.nombres,y.fecha_ingreso,y.fecha_final " & _
                                "FROM y_personal_contratos y , terceros t  " & _
                        "WHERE t.nit = y.nit AND y.tipo_contrato ='Z'AND y.fecha_ingreso <> y.fecha_final AND (y.fecha_final >='" & fec_ini & "' ) AND ( y.fecha_ingreso <='" & fec_fin & "' )" & _
                              "ORDER by t.nombres"


        Select Case concepto
            Case "PERSONAL EXISTENTE (TOTAL)"
                sql = sql_tot_personal
            Case "INGRESO MES"
                sql = sql_ingreso
            Case "RETIRO MES"
                sql = sql_retiro
            Case "APRENDIZ"
                sql = sql_practicantes
        End Select

        dt = objOpSimplesLn.listar_datatable(sql, "CORSAN")

        dtgDetalle.DataSource = dt
        For i = 0 To dtgDetalle.Columns.Count - 1
            If dtgDetalle.Columns(i).Name = "fecha_ingreso" Or dtgDetalle.Columns(i).Name = "fecha_retiro" Or dtgDetalle.Columns(i).Name = "fecha_final" Then
                dtgDetalle.Columns(i).DefaultCellStyle.Format = "d"
            End If
        Next
    End Sub

    Private Sub btn_cerrar_graf_Click(sender As Object, e As EventArgs) Handles btn_cerrar_graf.Click
        dtgDetalle.DataSource = Nothing
        groupDetalle.Visible = False
    End Sub

    Private Sub generarGraficoLinea(ByVal sql As String, ByVal nomb_serie As String, ByVal nombX As String)
        Chart1.Visible = True
        btn_cerrar.Visible = True
        Dim listaOflistas As New List(Of Object)
        Dim lista As New List(Of Object)
        listaOflistas = objOpSimplesLn.listaOfListas(sql, "CORSAN", 1)
        Chart1.Titles.Clear()
        Chart1.Series.Clear()
        Chart1.ChartAreas.Clear()
        Chart1.ChartAreas.Add(0)
        Chart1.Series.Add(nomb_serie)
        For j = 0 To listaOflistas.Count - 1
            lista = listaOflistas(j)
            Chart1.Series(nomb_serie).Points.AddXY(MonthName(lista(0), True).ToUpper, lista(1))
        Next
        Chart1.Series(nomb_serie).ChartType = DataVisualization.Charting.SeriesChartType.Line
        Chart1.ChartAreas(0).AxisX.Title = nombX
        Chart1.ChartAreas(0).AxisY.Title = "Calificación"
        Chart1.Refresh()
    End Sub

    Private Sub PERSONALEXISTENTETOTALToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PERSONALEXISTENTETOTALToolStripMenuItem.Click
        Dim anoIni As String = cboAnoIni.Text
        Dim mesIni As String = cboMesIni.SelectedIndex + 1
        Dim mesFin As String = cboMesFin.SelectedIndex + 1
        Dim sql As String = "SELECT MONTH(fecha_pago)As mes,COUNT(DISTINCT y.nit)As total " & _
                     "FROM y_pago_nomina  y " & _
                         "WHERE MONTH(fecha_pago) >= " & mesIni & " And YEAR (fecha_pago) = " & anoIni & " AND  MONTH(fecha_pago) <= " & mesFin & " " & _
                            "GROUP BY YEAR (fecha_pago),MONTH(fecha_pago) " & _
                                    "ORDER by YEAR (fecha_pago),MONTH(fecha_pago) "
        Dim nomb_serie As String = "PERSONAL EXISTENTE (TOTAL)"
        Dim nomb_x As String = "PERSONAL EXISTENTE (TOTAL)"
        generarGraficoLinea(sql, nomb_serie, nomb_x)
    End Sub

    Private Sub INGRESOMESToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles INGRESOMESToolStripMenuItem.Click
        Dim anoIni As String = cboAnoIni.Text
        Dim mesIni As String = cboMesIni.SelectedIndex + 1
        Dim mesFin As String = cboMesFin.SelectedIndex + 1
        Dim sql As String = "SELECT MONTH(fecha_ingreso) As mes, COUNT( fecha_ingreso) As total  " & _
                        "FROM y_personal_contratos " & _
                            "WHERE MONTH(fecha_ingreso) >= " & mesIni & " And YEAR (fecha_ingreso) = " & anoIni & " AND  MONTH(fecha_ingreso) <= " & mesFin & " " & _
                                 "GROUP BY YEAR( fecha_ingreso),MONTH(fecha_ingreso) " & _
                                      "ORDER BY YEAR( fecha_ingreso) ,MONTH( fecha_ingreso) "
        Dim nomb_serie As String = "INGRESO MES"
        Dim nomb_x As String = "INGRESO MES"
        generarGraficoLinea(sql, nomb_serie, nomb_x)
    End Sub

    Private Sub RETIROMESToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RETIROMESToolStripMenuItem.Click
        Dim anoIni As String = cboAnoIni.Text
        Dim mesIni As String = cboMesIni.SelectedIndex + 1
        Dim mesFin As String = cboMesFin.SelectedIndex + 1
        Dim sql As String = "SELECT MONTH(fecha_final) As mes, COUNT( fecha_final) As total " & _
                            "FROM y_personal_contratos " & _
                                  "WHERE fecha_final Is Not null AND MONTH(fecha_final) >= " & mesIni & " And YEAR (fecha_final) = " & anoIni & " AND  MONTH(fecha_final) <= " & mesFin & " " & _
                                      "GROUP BY YEAR( fecha_final),MONTH(fecha_final)"
        Dim nomb_serie As String = "RETIRO MES"
        Dim nomb_x As String = "RETIRO MES"
        generarGraficoLinea(sql, nomb_serie, nomb_x)
    End Sub


    Private Sub btn_cerrar_Click(sender As Object, e As EventArgs) Handles btn_cerrar.Click
        btn_cerrar.Visible = False
        Chart1.Visible = False
    End Sub
 Private Sub SaveFileDialog1_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles SaveFileDialog1.FileOk
        Dim ruta As String = SaveFileDialog1.FileName
        Chart1.SaveImage(ruta, System.Drawing.Imaging.ImageFormat.Png)
    End Sub
  Private Sub guardarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles guardarToolStripMenuItem.Click
        SaveFileDialog1.ShowDialog()
    End Sub
End Class