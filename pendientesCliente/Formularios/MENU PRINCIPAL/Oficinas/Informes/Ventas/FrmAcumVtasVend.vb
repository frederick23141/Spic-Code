Imports System.Configuration
Imports logicaNegocios
Imports System.IO
Imports entidadNegocios
Imports Microsoft.Office.Interop
Public Class FrmAcumVtasVend
    Private objUsuarioLn As New UsuarioLn
    Private objAcumVtasVendLn As AcumVtasVendLn
    Private objOperacionesForm As OperacionesFormularios = New OperacionesFormularios
    Private objusuarioEn As New UsuarioEn
    Dim fec_ini As String = ""
    Dim fec_fin As String = ""
    Private nom_modulo As String = ""
    Public Sub Main(ByVal nom_modulo As String, ByVal permiso As String, ByVal usuarioEn As UsuarioEn)
        Me.nom_modulo = nom_modulo
        If (permiso <> "ADMIN") Then
            btnContCambios.Visible = False
        End If
        objusuarioEn = usuarioEn
    End Sub
    Private Sub btnContCambios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnContCambios.Click
        FrmAuditCambios.Show()
        FrmAuditCambios.Main(nom_modulo)
        FrmAuditCambios.WindowState = 2
    End Sub
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

    Private Sub btnBuscar_Click_(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Dim vendedores As String = objUsuarioLn.coordinadorVend(objusuarioEn.usuario)
        dtgAcumVtasVend.DataSource = Nothing
        Dim min As Double
        Dim max As Double
        Dim mesini As Double
        Dim añoIni As Double
        Dim mesFin As Double
        Dim añoFin As Double
        Dim criterio As String
        Dim diaFin As Double = 31
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
                        If (mesFin = 2) Then
                            diaFin = 28
                        End If
                        If (mesFin = 4 Or mesFin = 6 Or mesFin = 9 Or mesFin = 11) Then
                            diaFin = 30
                        End If
                        fec_ini = añoIni & "-" & mesini & "-01"
                        fec_fin = añoFin & "-" & mesFin & "-" & diaFin & ""
                        If (chkKilos.Checked = True) Then
                            criterio = "kilos"
                        Else
                            criterio = "Vr_total"
                        End If
                        'dtgAcumVtasVend.DataSource = objAcumVtasVendLn.listarAcumVtasVend(min, max, mesini, añoIni, mesFin, añoFin, criterio)
                        dtgAcumVtasVend.DataSource = objAcumVtasVendLn.listar_consulta(min, max, mesini, añoIni, mesFin, añoFin, criterio, vendedores, chk_vend_hoy.Checked)
                        'Formato numero para las celdas del grid
                        dtgAcumVtasVend.Columns(0).Frozen = True
                        imgProc.Visible = False
                        pintarCol(dtgAcumVtasVend)
                        sumar_filas_grid(dtgAcumVtasVend)
                        sumar_col_grid(dtgAcumVtasVend)

                        dtgAcumVtasVend.Columns(1).DefaultCellStyle.Format = "N0"
                        dtgAcumVtasVend.Columns("id_cor").Visible = False
                        If (criterio = "kilos") Then
                            dtgAcumVtasVend.DefaultCellStyle.Format = "N0"
                        Else
                            dtgAcumVtasVend.DefaultCellStyle.Format = "C0"
                        End If
                        eliminarInactivos()
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
    Private Sub eliminarInactivos()
        Dim ultFila As Integer = dtgAcumVtasVend.RowCount - 1
        For i = 3 To dtgAcumVtasVend.ColumnCount - 1
            If Not IsDBNull(dtgAcumVtasVend.Item(i, ultFila).Value) Then
                If (dtgAcumVtasVend.Item(i, ultFila).Value = 0) Then
                    dtgAcumVtasVend.Columns(i).Visible = False
                End If
            End If
        Next
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
    Private Sub pintarCol(ByVal dtg As DataGridView)
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        dtgAcumVtasVend.Columns(2).DefaultCellStyle = DataGridViewCellStyle1
        dtgAcumVtasVend.Rows(dtg.RowCount - 1).DefaultCellStyle = DataGridViewCellStyle1
        With dtg
            .RowsDefaultCellStyle.BackColor = Color.White
            .AlternatingRowsDefaultCellStyle.BackColor = Color.Gainsboro
        End With
    End Sub
    Public Sub sumar_col_grid(ByVal dtg As DataGridView)
        Dim suma As Double = 0
        dtg.Item("Linea_producción", dtg.RowCount - 1).Value = "TOTAL"
        For j = 2 To dtg.ColumnCount - 1
            For i = 0 To dtg.RowCount - 2
                If Not IsDBNull(dtg.Item(j, i).Value) Then
                    suma = suma + dtg.Item(j, i).Value
                End If
            Next
            dtg.Item(j, dtg.RowCount - 1).Value = suma
            suma = 0
        Next
    End Sub
    Public Sub sumar_filas_grid(ByVal dtg As DataGridView)
        Dim suma As Double = 0
        '   dtg.Item("Tot_x_fila", dtg.RowCount - 1).Value = "TOTAL"
        For j = 0 To dtg.RowCount - 1
            For i = 2 To dtg.ColumnCount - 1
                If Not IsDBNull(dtg.Item(i, j).Value) Then
                    suma = suma + dtg.Item(i, j).Value
                End If
            Next
            dtg.Item("Tot_x_fila", j).Value = suma
            suma = 0
        Next
    End Sub
    Private Sub men_detalle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles men_detalle.Click
        If (dtgAcumVtasVend.CurrentCell.RowIndex > -1 And dtgAcumVtasVend.CurrentCell.ColumnIndex <> 0) Then
            Dim cad As String = dtgAcumVtasVend.Columns(dtgAcumVtasVend.CurrentCell.ColumnIndex).HeaderText.ToString
            Dim vend As String = ""
            For i = 0 To cad.Length - 1
                If IsNumeric(cad(i)) Then
                    vend += cad(i)
                End If
            Next
            If (vend <> "") Then
                vend = Convert.ToInt16(vend)
            End If
            Dim id_cor As Integer = dtgAcumVtasVend.Item("id_cor", dtgAcumVtasVend.CurrentCell.RowIndex).Value
            Frm_detalle_acomulado_ventas_por_vendedor.Show()
            Frm_detalle_acomulado_ventas_por_vendedor.Activate()
            Frm_detalle_acomulado_ventas_por_vendedor.Main(vend, fec_ini, fec_fin, id_cor)


        End If
    End Sub
    Private Sub dtgAcumVtasVend_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dtgAcumVtasVend.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            With (Me.dtgAcumVtasVend)
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                End If
            End With
        End If
    End Sub
    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        FrmPrincipal.Show()
        Me.Close()
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        FrmLogin.Show()
        FrmPrincipal.Close()
        Me.Close()
    End Sub
    Private Sub btn_exportar_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exportar.ButtonClick
        objOperacionesForm.ExportarDatosExcel(dtgAcumVtasVend, "Acumulado vtas vendededor ")
    End Sub

End Class