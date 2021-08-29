Imports System.Configuration
Imports logicaNegocios
Imports entidadNegocios
Imports System.IO
Imports Microsoft.Office.Interop
Imports System.ComponentModel
Public Class FrmAnVrKilo
    Private objAnVrKiloLn As AnVrKiloLn
    Private totColumnas As Integer = 0
    Private objOperacionesForm As OperacionesFormularios = New OperacionesFormularios
    Private nom_modulo As String = ""
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
    Private Sub FrmAnVrKilo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        objAnVrKiloLn = New AnVrKiloLn
        Dim año = Now.Year
        While (2000 <= año)
            cboAñoIni.Items.Add(año)
            cboAñoFin.Items.Add(año)
            cboAnoIniDet.Items.Add(año)
            cboAnoFinDet.Items.Add(año)
            año -= 1
        End While
    End Sub
    Private Sub ocultarCulVacias(ByVal dtg As DataGridView, ByVal mes As Integer, ByVal año As Integer)
        Dim nombMes As String = MonthName(mes, True).ToUpper
        'Esto se coloca por que cuando se tira un mes mayor al actual el comienza a poner los nombres a los meses y los corre ejm(selecciona dic y estamos a agosto eentonces a dic2012 le lleva el valor de dic 2011)
        If (mes > Now.Month) Then
            año = año - 1
        End If
        For i = 1 To dtg.ColumnCount - 1
            If (dtg(i, 1).Value = 0) Then
                dtg.Columns(i).Visible = False
            Else
                dtg.Columns(i).Visible = True

                dtg.Columns(i).HeaderText = nombMes & " - " & año
                año -= 1
            End If
        Next
        dtg.Columns(0).HeaderText = "Descripciòn"
    End Sub
    Private Sub pintarCol(ByVal dtg As DataGridView)
        With dtg
            .RowsDefaultCellStyle.BackColor = Color.White
            .AlternatingRowsDefaultCellStyle.BackColor = Color.Gainsboro
        End With
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Dim mes_ini As Integer = cboMesIni.SelectedIndex + 1
        Dim mes_fin As Integer = cboMesFin.SelectedIndex + 1
        Dim ano_ini As Integer = cboAñoIni.SelectedItem
        Dim ano_fin As Integer = cboAñoFin.SelectedItem

        If (cboMesIni.SelectedIndex <> -1 And cboAñoIni.SelectedIndex <> -1 And cboAñoFin.SelectedIndex <> -1) Then
            If (ano_ini > ano_fin) Then
                MessageBox.Show("EL año inicial debe ser menos que el año inicial ", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                imgProcesar.Visible = True
                Application.DoEvents()
                llenarGrid(mes_ini, ano_ini, mes_fin, ano_fin)
                imgProcesar.Visible = False
            End If

        Else
            MessageBox.Show("Todos los campos deben estar llenos!", "Verifique!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub
    Public Sub calcularValores(ByVal dtg As DataGridView)
        Dim a As Double = 0
        For i = 1 To dtg.ColumnCount - 1
            dtg(i, 3).Value = dtg(i, 1).Value / dtg(i, 0).Value
            dtg(i, 4).Value = dtg(i, 2).Value / dtg(i, 0).Value
            a = (dtg(i, 3).Value - dtg(i, 4).Value) / dtg(i, 3).Value * 100
            dtg(i, 5).Value = a
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
    Public Sub llenarGrid(ByVal mes_ini As Integer, ByVal ano_ini As Integer, ByVal mes_fin As Integer, ByVal ano_fin As Integer)
        'dtgAnVrKilo.DataSource = objAnVrKiloLn.listarPresGeneral(mes, añoIni, añoFin)
        'ocultarCulVacias(dtgAnVrKilo, mes, añoFin)

        'calcularValores(dtgAnVrKilo)

        dtgAnVrKilo.DataSource = objAnVrKiloLn.list_analisos_vrKilo_meses(mes_ini, ano_ini, mes_fin, ano_fin)
        calcularValores(dtgAnVrKilo)
        formatoCeldas()
        pintarCol(dtgAnVrKilo)
    End Sub
    Public Sub formatoCeldas()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        dtgAnVrKilo.Columns(0).DefaultCellStyle = DataGridViewCellStyle1
        dtgAnVrKilo.Rows(1).DefaultCellStyle.Format = "c0"
        dtgAnVrKilo.Rows(2).DefaultCellStyle.Format = "c0"
        dtgAnVrKilo.Rows(3).DefaultCellStyle.Format = "c0"
        dtgAnVrKilo.Rows(4).DefaultCellStyle.Format = "c0"
        dtgAnVrKilo.Rows(5).DefaultCellStyle.Format = "N2"
        dtgAnVrKilo.Columns(0).Frozen = True
    End Sub
    Private Sub btn_consult_detalle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_consult_detalle.Click
        imgProcesar.Visible = True
        Application.DoEvents()
        Dim mes_ini As Integer = cboMesIniDet.SelectedIndex + 1
        Dim mes_fin As Integer = cboMesFinDet.SelectedIndex + 1
        Dim ano_ini As Integer = cboAnoIniDet.SelectedItem
        Dim ano_fin As Integer = cboAnoFinDet.SelectedItem
        dtg_detalle.DataSource = objAnVrKiloLn.detalle_analisis_vrkilo(mes_ini, ano_ini, mes_fin, ano_fin)
        formatoCeldasDetalle()
        pintarInicioMes()
        ' dtg_detalle.Columns("Id_cor").Visible = False
        sumar_col_grid(dtg_detalle)
        imgProcesar.Visible = False
    End Sub
    Private Sub pintarInicioMes()
        For i = 0 To dtg_detalle.RowCount - 2
            If (dtg_detalle.Item("Id_cor", i).Value = 1) Then
                dtg_detalle.Rows(i).DefaultCellStyle.BackColor = Color.GreenYellow
            End If
        Next
    End Sub
    Public Sub sumar_col_grid(ByVal dtg As DataGridView)
        Dim suma As Double = 0
        Dim filas As Int32 = dtg.RowCount - 1
        For j = 3 To dtg.ColumnCount - 1
            suma = 0
            For i = 0 To filas
                If Not IsDBNull(dtg.Item(j, i).Value) Then
                    suma = suma + dtg.Item(j, i).Value
                End If

            Next
            dtg_detalle.Item(j, filas).Value = suma
        Next
        dtg_detalle.Item(0, filas).Value = "TOTALES"
        dtg_detalle.Item("Porc_util", filas).Value = dtg_detalle.Item("Porc_util", filas).Value / filas - 1
    End Sub
    Private Sub AnalisisValorKiloToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AnalisisValorKiloToolStripMenuItem.Click
        objOperacionesForm.ExportarDatosExcel(dtgAnVrKilo, "Analisis Valor_Kilo ")
    End Sub

    Private Sub DeatalleMesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeatalleMesToolStripMenuItem.Click
        objOperacionesForm.ExportarDatosExcel(dtg_detalle, "Analisis Valor_Kilo Detalle mes ")
    End Sub
    Public Sub formatoCeldasDetalle()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        dtg_detalle.Columns(0).DefaultCellStyle = DataGridViewCellStyle1
        dtg_detalle.Rows(dtg_detalle.RowCount - 1).DefaultCellStyle = DataGridViewCellStyle1
        dtg_detalle.Columns("Vr_tot").DefaultCellStyle.Format = "c0"
        dtg_detalle.Columns("Cto_tot").DefaultCellStyle.Format = "c0"
        dtg_detalle.Columns("Cto_kilo").DefaultCellStyle.Format = "c0"
        dtg_detalle.Columns("Porc_util").DefaultCellStyle.Format = "N1"
        dtg_detalle.Columns(0).Frozen = True
    End Sub
    Private Sub dtg_detalle_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dtg_detalle.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            With (Me.dtg_detalle)
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                End If
            End With
        End If
    End Sub
    Private Sub graficar(ByVal nombCol As String)
        Dim idCor As Integer = dtg_detalle.Item("Id_cor", dtg_detalle.CurrentCell.RowIndex).Value
        Dim cantMeses As Integer = 0
        For i = 0 To dtg_detalle.RowCount - 2
            If (dtg_detalle.Item("Id_cor", i).Value = 1) Then
                cantMeses += 1
            End If
        Next
        Dim j As Integer = 0
        Dim mat(cantMeses, 1) As Object
        For i = 0 To dtg_detalle.RowCount - 2
            If (dtg_detalle.Item("Id_cor", i).Value = idCor) Then
                mat(j, 0) = dtg_detalle.Item(nombCol, i).Value
                mat(j, 1) = dtg_detalle.Item("mes", i).Value
                j += 1
            End If

        Next
        FrmGraficoVrKilo.Show()
        FrmGraficoVrKilo.main(mat, nombCol)
    End Sub

    Private Sub VarlorTotalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VarlorTotalToolStripMenuItem.Click
        graficar("Vr_tot")
    End Sub

    Private Sub ValorKiloToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ValorKiloToolStripMenuItem.Click
        graficar("Kilos")
    End Sub
    Private Sub CostoTotalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CostoTotalToolStripMenuItem.Click
        graficar("Cto_tot")
    End Sub

    Private Sub CostoKiloToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CostoKiloToolStripMenuItem1.Click
        graficar("Cto_kilo")
    End Sub

    Private Sub PorcUtilidadToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PorcUtilidadToolStripMenuItem.Click
        graficar("Porc_util")
    End Sub
End Class