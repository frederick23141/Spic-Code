Imports System.Configuration
Imports logicaNegocios
Imports System.IO
Imports Microsoft.Office.Interop
Imports System.Windows.Forms.DataVisualization.Charting
Public Class Frm_traz_vtas_consol
    Private objGenerarPresLn As New GenerarPresLn
    Private objOperacionesForm As New OperacionesFormularios
    Private nom_modulo As String
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
    Private Sub btnBuscarVend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarVend.Click
        imgProcesar.Visible = True
        Application.DoEvents()
        llenarGridPresTodos(1001, 1099, "kilos")
        imgProcesar.Visible = False

    End Sub
    Public Sub llenarGridPresTodos(ByVal min, ByVal max, ByVal criterio)
        dtgAnalisisPres.DataSource = objGenerarPresLn.listarGenerarPresTodos(min, max, criterio)
        PintarColums()
        nombreColumnasPres(dtgAnalisisPres)
        dtgAnalisisPres.Columns(0).Frozen = True
        dtgAnalisisPres.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        dtgAnalisisPres.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        imgProcesar.Visible = False
        dtgAnalisisPres.Columns(1).Visible = False
        dtgAnalisisPres.Columns(2).Visible = False
        dtgAnalisisPres.Columns(3).Visible = False
        dtgAnalisisPres.Columns(4).Visible = False
        dtgAnalisisPres.Columns(5).Visible = False
        dtgAnalisisPres.Columns(6).Visible = False
        dtgAnalisisPres.Columns(7).Visible = False
        dtgAnalisisPres.Columns(8).Visible = False
        dtgAnalisisPres.Columns(9).Visible = False
        dtgAnalisisPres.Columns(10).Visible = False
        dtgAnalisisPres.Columns(11).Visible = False
        dtgAnalisisPres.Columns(12).Visible = False
        dtgAnalisisPres.Columns(13).Visible = False
        dtgAnalisisPres.Columns(14).Visible = False
        dtgAnalisisPres.Columns(15).Visible = False
        sumFilasAnPres()
        sumarTotPres()
    End Sub
    Private Sub PintarColums()
        For i = 0 To dtgAnalisisPres.ColumnCount - 1
            Me.dtgAnalisisPres.Item(i, 27).Style.BackColor = System.Drawing.Color.Red
        Next
    End Sub
    Public Sub nombreColumnasPres(ByVal dtg As DataGridView)
        Dim mes As Double = Now.Month
        Dim año As Double = Now.Year
        Dim nombreMes As String = ""
        For i = 16 To dtgAnalisisPres.ColumnCount - 1
            If mes = 0 Then
                mes = 12
                año = año - 1
            End If
            nombreMes = MonthName(mes, True)
            If (dtg.Columns(i).HeaderText <> "Total" And dtg.Columns(i).HeaderText <> "Promedio") Then
                dtg.Columns(i).HeaderText = (nombreMes & " " & año)
                mes = mes - 1
            End If

        Next
    End Sub
  
    Public Sub sumFilasAnPres()
        Dim sum As Double = 0
        For i = 0 To dtgAnalisisPres.RowCount - 2
            For j = 19 To dtgAnalisisPres.ColumnCount - 1
                sum += dtgAnalisisPres.Item(j, i).Value
            Next
            dtgAnalisisPres.Item("Total", i).Value = sum
            dtgAnalisisPres.Item("Promedio", i).Value = sum / 12
            sum = 0
        Next
    End Sub
    Private Sub PrincipalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrincipalToolStripMenuItem.Click
        FrmPrincipal.Show()
        Me.Close()
        FrmPrincipal.Activate()
    End Sub

    Private Sub SalirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalirToolStripMenuItem.Click
        FrmLogin.Show()
        FrmPrincipal.Close()
        Me.Close()
    End Sub
    Private Sub ExportarAExcelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportarAExcelToolStripMenuItem.Click
        objOperacionesForm.ExportarDatosExcel(dtgAnalisisPres, "trazabilidad Ventas ")
    End Sub
    Public Sub sumarTotPres()
        Dim suma As Double = 0
        Dim sumaProm As Double = 0
        Dim cont As Integer = 0
        For j = 2 To dtgAnalisisPres.ColumnCount - 1
            If (j <> 12 And j <> 11 And j <> 10) Then
                For i = 1 To 27
                    suma = suma + dtgAnalisisPres.Item(j, i - 1).Value
                Next

                dtgAnalisisPres.Item(j, 27).Value = suma
                suma = 0
            End If
        Next
        For i = 0 To 26
            If dtgAnalisisPres.Item(10, i).Value <> 0 Then
                sumaProm = sumaProm + dtgAnalisisPres.Item(10, i).Value
                cont += 1
            End If
        Next
        dtgAnalisisPres.Item(10, 27).Value = sumaProm / cont
        dtgAnalisisPres.Item(1, 27).Value = dtgAnalisisPres.Item(1, 26).Value
        dtgAnalisisPres.Item(11, 27).Value = dtgAnalisisPres.Item(11, 26).Value
        dtgAnalisisPres.Item(12, 27).Value = dtgAnalisisPres.Item(12, 26).Value
        dtgAnalisisPres.Columns(2).HeaderCell.Style.BackColor = Color.GreenYellow
        dtgAnalisisPres.Columns(2).HeaderCell.Style.BackColor = Color.GreenYellow
    End Sub

End Class