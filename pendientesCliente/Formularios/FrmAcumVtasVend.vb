Imports System.Configuration
Imports logicaNegocios
Imports accesoDatos
Imports System.IO
Imports Microsoft.Office.Interop
Public Class FrmAcumVtasVend
    Private objAcumVtasVendLn As AcumVtasVendLn
    Private objOperacionesForm As OperacionesFormularios = New OperacionesFormularios

    Private Sub FrmAnalisisPres_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        objAcumVtasVendLn = New AcumVtasVendLn
        Dim año = Now.Year
        While (año >= 2007)
            cboAñoIni.Items.Add(año)
            cboAñoFin.Items.Add(año)
            año -= 1
        End While
        chkPesos.Checked = True
        imgProc.Visible = False
    End Sub

    Private Sub PrincipalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrincipalToolStripMenuItem.Click
        FrmPrincipal.Show()
        Me.Close()
    End Sub

    Private Sub SalirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalirToolStripMenuItem.Click
        FrmLogin.Show()
        FrmPrincipal.Close()
        Me.Close()
    End Sub

    Private Sub ExportarAExcelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportarAExcelToolStripMenuItem.Click
        objOperacionesForm.ExportarDatosExcel(dtgAcumVtasVend, "Acumulado vtas vendededor ")
    End Sub

    Private Sub txtMin_TextChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMin.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            btnBuscar.PerformClick()
        End If
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

    End Sub
    Private Sub txtMax_TextChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMax.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            btnBuscar.PerformClick()
        End If
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub chkPesos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If chkPesos.Checked = True Then
            chkKilos.Checked = False
        End If
    End Sub

    Private Sub chkKilos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If chkKilos.Checked = True Then
            chkPesos.Checked = False
        End If
    End Sub

    Private Sub btnBuscar_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        dtgAcumVtasVend.DataSource = Nothing
        Dim min As Double
        Dim max As Double
        Dim mesini As Double
        Dim añoIni As Double
        Dim mesFin As Double
        Dim añoFin As Double
        Dim criterio As String
        If (txtMin.Text <> "" And txtMax.Text <> "") Then
            If (chkKilos.Checked = True Or chkPesos.Checked = True) Then


                If (txtMin.Text < 1001 Or txtMin.Text > 1099 Or txtMax.Text < 1001 Or txtMax.Text > 1099) Then
                    MsgBox("El rango de el vendedor debe estar entre 1001 y 1099")
                Else
                    If (cboAñoFin.SelectedIndex <> -1 And cboAñoIni.SelectedIndex <> -1 And cboMesFin.SelectedIndex <> -1 And cboAñoIni.SelectedIndex <> -1) Then
                        imgProc.Visible = True
                        Application.DoEvents()
                        min = txtMin.Text
                        max = txtMax.Text
                        mesini = cboMesIni.SelectedIndex + 1
                        añoIni = cboAñoIni.SelectedItem
                        mesFin = cboMesFin.SelectedIndex + 1
                        añoFin = cboAñoFin.SelectedItem
                        If (chkKilos.Checked = True) Then
                            criterio = "kilos"
                        Else
                            criterio = "Vr_total"
                        End If
                        dtgAcumVtasVend.DataSource = objAcumVtasVendLn.listarAcumVtasVend(min, max, mesini, añoIni, mesFin, añoFin, criterio)
                        'Formato numero para las celdas del grid
                        ocultarVendInactivos()
                        dtgAcumVtasVend.Columns(0).Frozen = True
                        imgProc.Visible = False
                        pintarCol(dtgAcumVtasVend)
                        sumar_filas_grid(dtgAcumVtasVend)
                        ' dtgAcumVtasVend.Columns(1).DefaultCellStyle.Format = "N0"
                        If (criterio = "kilos") Then
                            dtgAcumVtasVend.DefaultCellStyle.Format = "N0"
                        Else
                            dtgAcumVtasVend.DefaultCellStyle.Format = "C0"
                        End If
                    Else
                        MsgBox("Seleccione una fecha")
                    End If

                End If
            Else
                MsgBox("Seleccione discriminaciòn (Kilos-Pesos)")
            End If
        Else
            MsgBox("Criterio de busqueda vacio")
        End If
    End Sub

    Private Sub chkPesos_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPesos.CheckedChanged
        If chkPesos.Checked = True Then
            chkKilos.Checked = False
        End If
    End Sub

    Private Sub chkKilos_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkKilos.CheckedChanged
        If chkKilos.Checked = True Then
            chkPesos.Checked = False
        End If
    End Sub
    Public Sub ocultarVendInactivos()
        Dim sum As Double = 0
        For i = 1 To dtgAcumVtasVend.ColumnCount - 1
            For j = 0 To dtgAcumVtasVend.RowCount - 1
                sum = sum + dtgAcumVtasVend.Item(i, j).Value
            Next
            If (sum = 0) Then
                dtgAcumVtasVend.Columns(i).Visible = False
            Else
                dtgAcumVtasVend.Columns(i).Visible = True
            End If
            sum = 0
        Next
    End Sub

    Private Sub pintarCol(ByVal dtg As DataGridView)
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        dtgAcumVtasVend.Columns(1).DefaultCellStyle = DataGridViewCellStyle1
        dtgAcumVtasVend.Rows(dtg.RowCount - 1).DefaultCellStyle = DataGridViewCellStyle1
        With dtg
            .RowsDefaultCellStyle.BackColor = Color.White
            .AlternatingRowsDefaultCellStyle.BackColor = Color.Gainsboro
        End With
    End Sub
    Public Sub sumar_filas_grid(ByVal dtg As DataGridView)
        Dim suma As Double = 0
        dtg.Item("Descripcion", dtg.RowCount - 1).Value = "TOTAL"
        For j = 1 To dtg.ColumnCount - 1
            For i = 0 To dtg.RowCount - 1
                suma = suma + dtg.Item(j, i).Value
            Next
            dtg.Item(j, dtg.RowCount - 1).Value = suma
            suma = 0
        Next
    End Sub
End Class