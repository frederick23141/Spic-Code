Imports System.Configuration
Imports logicaNegocios
Imports System.Threading
Imports entidadNegocios
Imports System.IO
Imports Microsoft.Office.Interop
Imports System.Windows.Forms.DataVisualization.Charting
Public Class Form_informe_dane
    Private nom_modulo As String
    Private objinforme_daneLn As New Informe_daneLn
    Private objOperacionesForm As OperacionesFormularios = New OperacionesFormularios
    Public Sub Main(ByVal nom_modulo As String, ByVal permiso As String)
        Me.nom_modulo = nom_modulo
        If (permiso <> "ADMIN") Then
            btnContCambios.Visible = False
        End If
    End Sub
    Private Sub btnContCambios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnContCambios.Click
        FrmAuditCambios.Show()
        FrmAuditCambios.Main(nom_modulo)
        FrmAuditCambios.WindowState = 2
    End Sub

    Private Sub Form_informe_dane_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim año = Now.Year
        While (año >= Now.Year - 5)
            cboAñoIni.Items.Add(año)
            año -= 1
        End While
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Dim mes As Integer = cbo_mes.SelectedIndex + 1

        If Not (cbo_tipo.Text = "Seleccione" Or cboAñoIni.Text = "Seleccione") Then
            imgProcesar.Visible = True
            Application.DoEvents()

            If (chk_var.Checked = True) Then
                If Not (cbo_mes.SelectedIndex = -1) Then
                    dtg_pend_prod.DataSource = objinforme_daneLn.listar_variacion(cboAñoIni.SelectedItem, cbo_tipo.Text, mes)
                    calc_variacion(mes, cboAñoIni.SelectedItem)
                Else
                    MessageBox.Show("Seleccione todos los criterios de busqueda!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                End If

            Else
                dtg_pend_prod.DataSource = objinforme_daneLn.listarBusqueda(cboAñoIni.SelectedItem, cbo_tipo.Text)
            End If
            formatoNegrita(dtg_pend_prod)
            sumarColumnas(dtg_pend_prod, 0, 6)
            sumarColumnas(dtg_pend_prod, 8, 19)
            sumarColumnas(dtg_pend_prod, 21, 26)
            sumar_general(dtg_pend_prod)
            pintar_variaciom_totales(dtg_pend_prod)
            imgProcesar.Visible = False
        Else
            MessageBox.Show("Seleccione todos los criterios de busqueda!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
    Public Sub calc_variacion(ByVal mes As Integer, ByVal ano As Integer)
        Dim fec_ant As Date = DateAdd("m", -1, ano & "-" & mes & "-01")
        For i = 0 To dtg_pend_prod.RowCount - 1
            If (IsDBNull(dtg_pend_prod.Item((MonthName(mes, True)) & "-" & ano, i).Value)) Then
                dtg_pend_prod.Item((MonthName(mes, True)) & "-" & ano, i).Value = 0
            End If
            If (IsDBNull(dtg_pend_prod.Item((MonthName(fec_ant.Month, True)) & "-" & fec_ant.Year, i).Value)) Then
                dtg_pend_prod.Item((MonthName(fec_ant.Month, True)) & "-" & fec_ant.Year, i).Value = 0
            End If
            dtg_pend_prod.Item("Variación", i).Value = dtg_pend_prod.Item((MonthName(mes, True)) & "-" & ano, i).Value - dtg_pend_prod.Item((MonthName(fec_ant.Month, True)) & "-" & fec_ant.Year, i).Value
            dtg_pend_prod.Columns((MonthName(fec_ant.Month, True)) & "-" & fec_ant.Year).HeaderCell.Style.BackColor = Color.GreenYellow
            dtg_pend_prod.Columns((MonthName(mes, True)) & "-" & ano).HeaderCell.Style.BackColor = Color.GreenYellow
            dtg_pend_prod.Columns("Variación").HeaderCell.Style.BackColor = Color.GreenYellow
        Next
    End Sub
    Private Sub PrincipalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrincipalToolStripMenuItem.Click
        FrmPrincipal.Show()
        FrmPrincipal.TopMost = True
        FrmPrincipal.WindowState = 0
        Me.Close()
    End Sub

    Private Sub SalirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalirToolStripMenuItem.Click
        FrmLogin.Show()
        FrmPrincipal.Close()
        Me.Close()

    End Sub

    Private Sub ExportarAExcelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportarAExcelToolStripMenuItem.Click
        objOperacionesForm.ExportarDatosExcel(dtg_pend_prod, "Informe dane ")
    End Sub
    Public Sub formatoNegrita(ByVal dtg As DataGridView)
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        dtg.Rows(7).DefaultCellStyle = DataGridViewCellStyle1
        dtg.Rows(20).DefaultCellStyle = DataGridViewCellStyle1
        dtg.Rows(29).DefaultCellStyle = DataGridViewCellStyle1
        dtg.Rows(25).DefaultCellStyle = DataGridViewCellStyle1
    End Sub

    Private Sub sumarColumnas(ByVal dtg As DataGridView, ByVal prim As Integer, ByVal ult As Integer)
        Dim total As Double = 0
        For j = 2 To dtg.ColumnCount - 1
            For i = prim To ult
                If IsNumeric(dtg.Item(j, i).Value) Then
                    total = total + dtg.Item(j, i).Value
                End If
            Next
            dtg(j, ult + 1).Value = total
            total = 0
        Next
    End Sub
    Private Sub sumar_general(ByVal dtg As DataGridView)
        Dim total As Double = 0
        For j = 2 To dtg.ColumnCount - 1
            For i = 0 To dtg.RowCount - 2
                If (i <> 25 And i <> 20 And i <> 7) Then
                    If IsNumeric(dtg.Item(j, i).Value) Then
                        total = total + dtg.Item(j, i).Value
                    End If
                End If

            Next
            dtg(j, dtg.RowCount - 2).Value = total
            total = 0
        Next
    End Sub

    Private Sub chk_var_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_var.CheckedChanged
        If (chk_var.Checked = True) Then
            cbo_mes.Visible = True
            lbl_mes.Visible = True
        Else
            cbo_mes.Visible = False
            lbl_mes.Visible = False
        End If
    End Sub
    Public Sub pintar_variaciom_totales(ByVal dtg As DataGridView)
        Dim real As Integer = dtg.RowCount - 1
        Dim var As Integer = dtg.RowCount - 2
        Dim resta As Integer
        For j = 1 To dtg.ColumnCount - 1
            If IsNumeric(dtg.Item(j, var).Value) And IsNumeric(dtg.Item(j, real).Value) Then
                resta = (dtg.Item(j, var).Value - dtg.Item(j, real).Value)
                If (resta <> 0) Then
                    dtg.Item(j, var).Style.BackColor = Color.Red
                Else
                    dtg.Item(j, var).Style.BackColor = Color.Green
                End If
            End If
        Next
    End Sub
    Private Sub btn_grafica_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Chart1.Visible = True
        btn_cerrar.Visible = True
        Dim nomb_col As String = ""
        Dim valor As Double = 0
        Dim fila As Integer = dtg_pend_prod.RowCount - 1
        Chart1.Titles.Clear()
        Chart1.Series.Clear()
        'Chart1.Series.Add("Meses")
        'For j = 1 To dtg_pend_prod.ColumnCount - 1
        '    nomb_col = dtg_pend_prod.Columns(j).HeaderText
        '    valor = dtg_pend_prod.Item(j, fila).Value
        '    'Chart1.Series.Add(nomb_col)
        '    'Chart1.Series(nomb_col).Points.AddXY(0, valor)
        '    ''Chart1.Series(nomb_col).Points.Add()
        '    'Chart1.Series.Add(j)
        '    'Chart1.Series(j).Points.AddXY(0, 0)

        '    Chart1.Series("Meses").Points.Add(valor)
        '    Chart1.Series("Meses").Points(j - 1).AxisLabel = nomb_col

        '    'Chart1.Series(nomb_col).Points.Add(1)
        '    'Chart1.Series(nomb_col).Points(1).AxisLabel = "dato 2"

        '    'Chart1.Series(nomb_col).Points.Add(2)
        '    'Chart1.Series(nomb_col).Points(2).AxisLabel = "dato 3"

        'Next
        Chart1.ChartAreas(0).Area3DStyle.Enable3D = True
        Chart1.ChartAreas(0).Area3DStyle.Rotation = 20
        Chart1.ChartAreas(0).Area3DStyle.PointDepth = 75
        Chart1.ChartAreas(0).Area3DStyle.PointGapDepth = 35
        For j = 1 To dtg_pend_prod.ColumnCount - 1
            nomb_col = dtg_pend_prod.Columns(j).HeaderText
            valor = dtg_pend_prod.Item(j, fila).Value
            Chart1.Series.Add(nomb_col)
            Chart1.Series(nomb_col).Points.Add()
            Chart1.Series(nomb_col).Points(0).YValues = ({valor})
            ' Chart1.Series(nomb_col)("PointWidth") = "2"
            Chart1.Series(nomb_col).Points(0).AxisLabel = nomb_col
            Chart1.ChartAreas(0).AxisX.Title = "Meses"
            Chart1.Series(0).Points(0).Label = valor
        Next

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Chart1.Visible = True
        btn_cerrar.Visible = True
        Chart1.Titles.Clear()
        Chart1.Series.Clear()
        ' Chart1.Series("Series1").ChartType = DataVisualization.Charting.SeriesChartType.Line
        Chart1.Series.Add("Series1")
        Chart1.Series("Series1").Points.AddXY("Jan", 10)
        Chart1.Series("Series1").Points.AddXY("Feb", 15)
        Chart1.Series("Series1").Points.AddXY("Mar", 20)
        Chart1.Series("Series1").Points.AddXY("Apr", 5)
        Chart1.Series("Series1").Points.AddXY("May", 6)
        Chart1.Series("Series1").Points.AddXY("Jun", 18)
        Chart1.Series("Series1").Points.AddXY("Jul", 25)
        Chart1.Series("Series1").Points.AddXY("Aug", 5)
        Chart1.Series("Series1").Points.AddXY("Sep", 12)
        Chart1.Series("Series1").Points.AddXY("Oct", 18)
        Chart1.Series("Series1").Points.AddXY("Nov", 27)
        Chart1.Series("Series1").Points.AddXY("Dec", 29)

        Chart1.Series("Series1")("PointWidth") = "0.2"
        Chart1.Series("Series1").IsValueShownAsLabel = True
        Chart1.Series("Series1").LegendText = "Totals By Month"
        Chart1.ChartAreas(0).AxisX.Title = "Months"
        Chart1.Refresh() ' Call standard .NET Refresh method to force paint
        'Chart1.Series(0).Points.Add(10)
        'Chart1.Series(0).Points(0).AxisLabel = "dato 1"
        'Chart1.Series(0).Points(0).Label = 10
        'Chart1.Series(0).Points(0).Color = Color.Red

        'Chart1.Series(0).Points.Add(20)
        'Chart1.Series(0).Points(1).AxisLabel = "dato 2"
        'Chart1.Series(0).Points(0).ToolTip = "Feb"

        'Chart1.Series(0).Points.Add(30)
        'Chart1.Series(0).Points(2).AxisLabel = "dato 3"
        'Chart1.Series(0).Points(0).ToolTip = "Marzo"
    End Sub
End Class