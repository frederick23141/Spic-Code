Imports System.Configuration
Imports logicaNegocios
Imports System.IO
Imports Microsoft.Office.Interop
Public Class FrmPpto_recaudo
    Private objPpto_recaudoLn As Ppto_recaudoLn
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
    Private Sub FrmPpto_recaudo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
        objPpto_recaudoLn = New Ppto_recaudoLn
        Dim año = Now.Year
        If Now.Month = 12 Then
            cboMes.Items.Add(nombreMeses(12))
            cboMes.Items.Add(nombreMeses(1))
            cboAño.Items.Add(Now.Year + 1)
            cboAño.Items.Add(Now.Year)
        Else
            cboMes.Items.Add(nombreMeses(Now.Month))
            cboMes.Items.Add(nombreMeses(Now.Month + 1))
            cboAño.Items.Add(Now.Year)
            cboAño.Items.Add(Now.Year + 1)
        End If

        cboMes.SelectedIndex = 1
        cboAño.SelectedIndex = 0
        imgProcesar.Visible = False
        btnGuardar.Enabled = False

    End Sub

    Private Sub btnGen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGen.Click
        Dim fecha As String
        Dim mes As Integer = 0
        Dim año As Integer = 0
        imgProcesar.Visible = True
        Application.DoEvents()

        If (cboMes.SelectedIndex = 0) Then
            mes = Now.Month
        End If
        If (cboMes.SelectedIndex = 1) Then
            mes = Now.Month + 1
        End If
        año = cboAño.Text
        fecha = año & "-" & mes & "-01 "

        dtgPptoRec.DataSource = objPpto_recaudoLn.listarPptoRec(fecha)
        dtgDetallePpto.DataSource = objPpto_recaudoLn.listarDtallePpto()
        sumarTotCarteraVend(dtgDetallePpto)
        sumarColDetalle(dtgDetallePpto)
        nombreColumnasMeses(dtgDetallePpto)
        sumarColumnasPpto(dtgPptoRec)
        formatoNegritaPpto()
        formatoNegritaDtalle()

        imgProcesar.Visible = False
        btnGuardar.Enabled = True
    End Sub
    Private Sub dtgPptoRec_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgPptoRec.CellDoubleClick
        Dim valor As Double = 0
        Dim resp As String = 0
        If (e.ColumnIndex = 5) Then
            If (e.RowIndex = -1 Or e.RowIndex = dtgPptoRec.RowCount - 1) Then
            Else
                valor = CInt(dtgPptoRec(5, e.RowIndex).Value)
                resp = InputBox(" Valor actual:  " & valor.ToString("C0") & " " & vbCrLf & " Ingrese nuevo valor:", "Modificar presupuesto", valor)
                If (resp <> "") Then
                    dtgPptoRec.Item(5, e.RowIndex).Value = resp
                    sumarColumnasPpto(dtgPptoRec)

                End If
            End If

        End If

    End Sub
    Private Sub dtgDetallePpto_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgDetallePpto.CellDoubleClick

        Dim resp As String = 0
        Dim vendedor As Integer
        If (e.RowIndex = -1) Then
        Else
            If e.RowIndex <> dtgDetallePpto.RowCount - 1 Then
                vendedor = dtgDetallePpto.Item(0, e.RowIndex).Value
                FrmDtalleRecVend.Show()
                FrmDtalleRecVend.lblTitulo.Text = vendedor
                Application.DoEvents()
                FrmDtalleRecVend.dtgDtalleVend.DataSource = objPpto_recaudoLn.listaDtalleVend(vendedor)

            End If
        End If
    End Sub
    Private Sub dtgDetallePpto_CellFormatting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dtgDetallePpto.CellFormatting
        Dim var As Integer = 0

        If (dtgDetallePpto.RowCount Mod 2 = 1) Then
            var = 1
        End If
        If e.RowIndex Mod 2 = var Then
            e.CellStyle.BackColor = Color.Gainsboro
        End If
    End Sub
    Private Sub dtgPptoRec_CellFormatting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dtgPptoRec.CellFormatting
        Dim var As Integer = 0

        If (dtgPptoRec.RowCount Mod 2 = 1) Then
            var = 1
        End If
        If e.RowIndex Mod 2 = var Then
            e.CellStyle.BackColor = Color.Gainsboro
        End If
    End Sub
    Public Sub sumarColumnasPpto(ByVal dtg As DataGridView)
        Dim suma As Double = 0
        For j = 3 To dtg.ColumnCount - 2

            For i = 0 To dtg.RowCount - 2
                suma = suma + dtg.Item(j, i).Value
            Next

            dtg.Item(j, dtg.RowCount - 1).Value = suma
            suma = 0
        Next
        dtg.Item(2, dtg.RowCount - 1).Value = dtg.Item(2, dtg.RowCount - 2).Value
        dtg.Item(7, dtg.RowCount - 1).Value = dtg.Item(7, dtg.RowCount - 2).Value
    End Sub
    Private Sub nombreColumnasMeses(ByVal dtg As DataGridView)

        Dim mes As Integer
        Dim año As Integer
        Dim k As Integer = 8
        mes = Now.Month
        año = Now.Year

        For i = 1 To 6
            If mes = 0 Then
                mes = 12
                año = año - 1
            End If
            dtg.Columns(k).HeaderText = nombreMeses(mes) & " " & año
            mes = mes - 1
            k += 1
        Next
    End Sub
    Public Sub sumarColDetalle(ByVal dtg As DataGridView)
        Dim suma As Double = 0
        For j = 1 To dtg.ColumnCount - 1

            For i = 0 To dtg.RowCount - 1
                suma = suma + dtg.Item(j, i).Value
            Next

            dtg.Item(j, dtg.RowCount - 1).Value = suma
            suma = 0
        Next
        dtg.Item(0, dtg.RowCount - 1).Value = "TOTALES"
    End Sub
    Public Sub sumarTotCarteraVend(ByVal dtg As DataGridView)
        Dim suma As Double = 0
        For i = 0 To dtg.RowCount - 2
            For j = 1 To 6
                suma = suma + dtg.Item(j, i).Value
            Next

            dtg.Item(7, i).Value = suma
            suma = 0
        Next
    End Sub

    Private Function nombreMeses(ByVal num As Integer) As String
        Dim s As String = ""
        Select Case num
            Case 1
                Return "Enero"
            Case 2
                Return "febrero"
            Case 3
                Return "Marzo"
            Case 4
                Return "Abril"
            Case 5
                Return "mayo"
            Case 6
                Return "Junio"
            Case 7
                Return "Julio"
            Case 8
                Return "Agosto"
            Case 9
                Return "Septiembre"
            Case 10
                Return "Octubre"
            Case 11
                Return "Noviembre"
            Case 12
                Return "Diciembre"
        End Select
        Return s
    End Function
    Private Sub ExportarAExcelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportarAExcelToolStripMenuItem.Click
        objOperacionesForm.ExportarDatosExcel(dtgPptoRec, "Presupuesto Recaudo")
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

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If (dtgPptoRec.RowCount > 1) Then
            Dim fechaPpto As Date = dtgPptoRec.Item(2, 1).Value
            Dim vendedor As Double = 0
            Dim Nombre As String = ""
            Dim ppto_rec As Double
            Dim ppto_clien_cont As Double
            Dim pptoTot As Double
            Dim totClienCont As Double
            objPpto_recaudoLn.eliminarPres(fechaPpto.Year, fechaPpto.Month)
            For i = 0 To dtgPptoRec.RowCount - 2
                vendedor = dtgPptoRec.Item(0, i).Value
                Nombre = dtgPptoRec.Item(1, i).Value
                ppto_rec = dtgPptoRec.Item(3, i).Value
                ppto_clien_cont = dtgPptoRec.Item(4, i).Value
                pptoTot = dtgPptoRec.Item(5, i).Value
                totClienCont = dtgPptoRec.Item(6, i).Value
                objPpto_recaudoLn.insertarPres(fechaPpto, vendedor, Nombre, ppto_rec, ppto_clien_cont, pptoTot, totClienCont)


            Next

            MessageBox.Show("El presupuesto se guardo en forma correcta!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If


    End Sub
    Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
        FrmConsulPptoRec.Show()
        'dtgDetallePpto.DataSource = objPpto_recaudoLn.listarDtallePpto()
    End Sub
    Public Sub consultarPpto(ByVal año As Integer, ByVal mes As Integer)
        If (objPpto_recaudoLn.existePresRec(año, mes)) Then
            dtgPptoRec.DataSource = objPpto_recaudoLn.listarConsulta(año, mes)
            If (dtgPptoRec.RowCount > 1) Then
                sumarColumnasPpto(dtgPptoRec)
                formatoNegritaPpto()
                imgProcesar.Visible = False
                btnGuardar.Enabled = True
            End If
        Else
            MessageBox.Show("El presupuesto para " & año & "-" & mes & " No existe!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Public Sub formatoNegritaPpto()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        dtgPptoRec.Rows(dtgPptoRec.RowCount - 1).DefaultCellStyle = DataGridViewCellStyle1
        dtgPptoRec.Columns(5).DefaultCellStyle = DataGridViewCellStyle1
    End Sub
    Public Sub formatoNegritaDtalle()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        dtgDetallePpto.Rows(dtgDetallePpto.RowCount - 1).DefaultCellStyle = DataGridViewCellStyle1
        dtgDetallePpto.Columns(7).DefaultCellStyle = DataGridViewCellStyle1

    End Sub
    Private Sub btnEliminar_Cick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click

        FrmElimPresRec.Show()
    End Sub
    Public Sub eliminarPpto(ByVal año As Integer, ByVal mes As Integer)
        If (objPpto_recaudoLn.existePresRec(año, mes)) Then
            objPpto_recaudoLn.eliminarPres(año, mes)
            MessageBox.Show("El presupuesto para " & año & "-" & mes & " se elimino en forma correcta!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            MessageBox.Show("El presupuesto para " & año & "-" & mes & " No existe", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

End Class