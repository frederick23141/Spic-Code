Imports System.Configuration
Imports logicaNegocios
Imports entidadNegocios
Imports System.IO
Imports Microsoft.Office.Interop
Public Class FrmAcumVenClien
    Private objUsuarioLn As New UsuarioLn
    Private objAcumVenLn As AcumVentLn
    Private objOperacionesForm As OperacionesFormularios = New OperacionesFormularios
    Private criterioAux As Double = 0
    Private objUsuarioEn As New UsuarioEn
    Private nom_modulo As String = ""
    Public Sub Main(ByVal nom_modulo As String, ByVal permiso As String, ByVal usuarioEn As UsuarioEn)
        Me.nom_modulo = nom_modulo
        If (permiso <> "ADMIN") Then
            btnContCambios.Visible = False
        End If
        objUsuarioEn = usuarioEn
    End Sub
    Private Sub btnContCambios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnContCambios.Click
        FrmAuditCambios.Show()
        FrmAuditCambios.Main(nom_modulo)
        FrmAuditCambios.WindowState = 2
    End Sub
    Private Sub FrmAcumVenClien_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        objAcumVenLn = New AcumVentLn
        centrarEnPantalla()
        Dim año = Now.Year
        While (año >= 2007)
            cboAñoIni.Items.Add(año)
            cboAñoFin.Items.Add(año)
            año -= 1
        End While
        chkPesos.Checked = True
        imgProc.Visible = False

    End Sub
#Region "Funciones y procedimientos formulario"
    Private Sub centrarEnPantalla()
        Me.Left = (Screen.PrimaryScreen.WorkingArea.Width - Me.Width) / 2
        Me.Top = (Screen.PrimaryScreen.WorkingArea.Height - Me.Height) / 2
    End Sub

    Private Function sumarColumnas(ByVal nomColumna As String, ByVal dtg As DataGridView) As Double
        Dim total As Double = 0

        ' recorrer las filas y obtener los items de la columna indicada en "nombre_Columna"  
        Try
            For i As Integer = 0 To dtg.RowCount - 1
                total = total + CDbl(dtg.Item(nomColumna.ToLower, i).Value)
            Next

        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try

        ' retornar el valor  
        Return total
    End Function
    Private Sub limpiarCampos()
        txtValtot.Text = ""
        txtTotVentaCli.Text = ""
    End Sub

    Private Sub buscarColumnas(ByVal criterio As Double)
        Dim total As Double = 0
        Try
            Dim dtg As DataGridView = dtgAcumVentas

            Dim sw As Boolean = False

            Dim i As Integer = 0
            While i <= dtg.RowCount - 1
                If Not (IsDBNull(dtg.Item("nit".ToLower, i).Value)) Then
                    If (dtg.Item("nit".ToLower, i).Value) = criterio Then

                        MsgBox("Dato encontrado en la fila: " & i + 1)
                        dtg.Item("nit".ToLower, i).Style.BackColor = System.Drawing.Color.OrangeRed
                        dtg.Item("vendedor".ToLower, i).Style.BackColor = System.Drawing.Color.OrangeRed
                        dtg.Item("ciudad".ToLower, i).Style.BackColor = System.Drawing.Color.OrangeRed
                        dtg.Item("nombres".ToLower, i).Style.BackColor = System.Drawing.Color.OrangeRed
                        dtg.Item("alBrill".ToLower, i).Style.BackColor = System.Drawing.Color.OrangeRed
                        total = total + CDbl(dtg.Item("alBrill".ToLower, i).Value)
                        dtg.Item("alReco".ToLower, i).Style.BackColor = System.Drawing.Color.OrangeRed
                        total = total + CDbl(dtg.Item("alReco".ToLower, i).Value)
                        dtg.Item("alEspe".ToLower, i).Style.BackColor = System.Drawing.Color.OrangeRed
                        total = total + CDbl(dtg.Item("alEspe".ToLower, i).Value)
                        dtg.Item("varillas".ToLower, i).Style.BackColor = System.Drawing.Color.OrangeRed
                        total = total + CDbl(dtg.Item("varillas".ToLower, i).Value)
                        dtg.Item("alPuas".ToLower, i).Style.BackColor = System.Drawing.Color.OrangeRed
                        total = total + CDbl(dtg.Item("alPuas".ToLower, i).Value)
                        dtg.Item("alGalv".ToLower, i).Style.BackColor = System.Drawing.Color.OrangeRed
                        total = total + CDbl(dtg.Item("alGalv".ToLower, i).Value)
                        dtg.Item("mallPollo".ToLower, i).Style.BackColor = System.Drawing.Color.OrangeRed
                        total = total + CDbl(dtg.Item("mallPollo".ToLower, i).Value)
                        dtg.Item("cc350_700".ToLower, i).Style.BackColor = System.Drawing.Color.OrangeRed
                        total = total + CDbl(dtg.Item("cc350_700".ToLower, i).Value)
                        dtg.Item("cc400_800".ToLower, i).Style.BackColor = System.Drawing.Color.OrangeRed
                        total = total + CDbl(dtg.Item("cc400_800".ToLower, i).Value)
                        dtg.Item("cc500_1000".ToLower, i).Style.BackColor = System.Drawing.Color.OrangeRed
                        total = total + CDbl(dtg.Item("cc500_1000".ToLower, i).Value)
                        dtg.Item("clGranel".ToLower, i).Style.BackColor = System.Drawing.Color.OrangeRed
                        total = total + CDbl(dtg.Item("clGranel".ToLower, i).Value)
                        dtg.Item("clVareta".ToLower, i).Style.BackColor = System.Drawing.Color.OrangeRed
                        total = total + CDbl(dtg.Item("clVareta".ToLower, i).Value)
                        dtg.Item("clZinc".ToLower, i).Style.BackColor = System.Drawing.Color.OrangeRed
                        total = total + CDbl(dtg.Item("clZinc".ToLower, i).Value)
                        dtg.Item("helicoYAnula".ToLower, i).Style.BackColor = System.Drawing.Color.OrangeRed
                        total = total + CDbl(dtg.Item("helicoYAnula".ToLower, i).Value)
                        dtg.Item("helectro".ToLower, i).Style.BackColor = System.Drawing.Color.OrangeRed
                        total = total + CDbl(dtg.Item("helectro".ToLower, i).Value)
                        dtg.Item("clAcero".ToLower, i).Style.BackColor = System.Drawing.Color.OrangeRed
                        total = total + CDbl(dtg.Item("clAcero".ToLower, i).Value)
                        dtg.Item("grapas".ToLower, i).Style.BackColor = System.Drawing.Color.OrangeRed
                        total = total + CDbl(dtg.Item("grapas".ToLower, i).Value)
                        dtg.Item("clHerrar".ToLower, i).Style.BackColor = System.Drawing.Color.OrangeRed
                        total = total + CDbl(dtg.Item("clHerrar".ToLower, i).Value)
                        dtg.Item("trEstufa".ToLower, i).Style.BackColor = System.Drawing.Color.OrangeRed
                        total = total + CDbl(dtg.Item("trEstufa".ToLower, i).Value)
                        dtg.Item("trMadera".ToLower, i).Style.BackColor = System.Drawing.Color.OrangeRed
                        total = total + CDbl(dtg.Item("trMadera".ToLower, i).Value)
                        dtg.Item("trLamina".ToLower, i).Style.BackColor = System.Drawing.Color.OrangeRed
                        total = total + CDbl(dtg.Item("trLamina".ToLower, i).Value)
                        dtg.Item("trAGlom".ToLower, i).Style.BackColor = System.Drawing.Color.OrangeRed
                        total = total + CDbl(dtg.Item("trAGlom".ToLower, i).Value)
                        dtg.Item("trChazo".ToLower, i).Style.BackColor = System.Drawing.Color.OrangeRed
                        total = total + CDbl(dtg.Item("trChazo".ToLower, i).Value)
                        dtg.Item("remaches".ToLower, i).Style.BackColor = System.Drawing.Color.OrangeRed
                        total = total + CDbl(dtg.Item("remaches".ToLower, i).Value)
                        dtg.Item("carriaje".ToLower, i).Style.BackColor = System.Drawing.Color.OrangeRed
                        total = total + CDbl(dtg.Item("carriaje".ToLower, i).Value)
                        dtg.Item("trDrywall".ToLower, i).Style.BackColor = System.Drawing.Color.OrangeRed
                        total = total + CDbl(dtg.Item("trDrywall".ToLower, i).Value)
                        dtg.Item("arandela".ToLower, i).Style.BackColor = System.Drawing.Color.OrangeRed
                        total = total + CDbl(dtg.Item("arandela".ToLower, i).Value)
                        dtg.Item("clas_cor".ToLower, i).Style.BackColor = System.Drawing.Color.OrangeRed
                        total = total + CDbl(dtg.Item("clas_cor".ToLower, i).Value)
                        criterioAux = criterio
                        sw = True
                    End If
                End If
                i = i + 1
            End While
            txtTotVentaCli.Text = Format(total, "###,###,###")
            If sw = False Then

            End If
            If (sw = False) Then
                MsgBox("Nit no encontrado ,Verifique!")
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try

    End Sub

    Private Sub limpiarColumnas()
        Dim dtg As DataGridView = dtgAcumVentas
        Dim i As Integer = 0
        While i <= dtg.RowCount - 1
            If Not (IsDBNull(dtg.Item("nit".ToLower, i).Value)) Then
                If (dtg.Item("nit".ToLower, i).Value) = criterioAux Then
                    dtg.Item("nit".ToLower, i).Style.BackColor = System.Drawing.Color.White
                    dtg.Item("nit".ToLower, i).Style.BackColor = System.Drawing.Color.White
                    dtg.Item("vendedor".ToLower, i).Style.BackColor = System.Drawing.Color.White
                    dtg.Item("ciudad".ToLower, i).Style.BackColor = System.Drawing.Color.White
                    dtg.Item("nombres".ToLower, i).Style.BackColor = System.Drawing.Color.White
                    dtg.Item("alBrill".ToLower, i).Style.BackColor = System.Drawing.Color.White
                    dtg.Item("alReco".ToLower, i).Style.BackColor = System.Drawing.Color.White
                    dtg.Item("alEspe".ToLower, i).Style.BackColor = System.Drawing.Color.White
                    dtg.Item("varillas".ToLower, i).Style.BackColor = System.Drawing.Color.White
                    dtg.Item("alPuas".ToLower, i).Style.BackColor = System.Drawing.Color.White
                    dtg.Item("alGalv".ToLower, i).Style.BackColor = System.Drawing.Color.White
                    dtg.Item("mallPollo".ToLower, i).Style.BackColor = System.Drawing.Color.White
                    dtg.Item("cc350_700".ToLower, i).Style.BackColor = System.Drawing.Color.White
                    dtg.Item("cc400_800".ToLower, i).Style.BackColor = System.Drawing.Color.White
                    dtg.Item("cc500_1000".ToLower, i).Style.BackColor = System.Drawing.Color.White
                    dtg.Item("clGranel".ToLower, i).Style.BackColor = System.Drawing.Color.White
                    dtg.Item("clVareta".ToLower, i).Style.BackColor = System.Drawing.Color.White
                    dtg.Item("clZinc".ToLower, i).Style.BackColor = System.Drawing.Color.White
                    dtg.Item("helicoYAnula".ToLower, i).Style.BackColor = System.Drawing.Color.White
                    dtg.Item("helectro".ToLower, i).Style.BackColor = System.Drawing.Color.White
                    dtg.Item("clAcero".ToLower, i).Style.BackColor = System.Drawing.Color.White
                    dtg.Item("grapas".ToLower, i).Style.BackColor = System.Drawing.Color.White
                    dtg.Item("clHerrar".ToLower, i).Style.BackColor = System.Drawing.Color.White
                    dtg.Item("trEstufa".ToLower, i).Style.BackColor = System.Drawing.Color.White
                    dtg.Item("trMadera".ToLower, i).Style.BackColor = System.Drawing.Color.White
                    dtg.Item("trLamina".ToLower, i).Style.BackColor = System.Drawing.Color.White
                    dtg.Item("trAGlom".ToLower, i).Style.BackColor = System.Drawing.Color.White
                    dtg.Item("trChazo".ToLower, i).Style.BackColor = System.Drawing.Color.White
                    dtg.Item("remaches".ToLower, i).Style.BackColor = System.Drawing.Color.White
                    dtg.Item("carriaje".ToLower, i).Style.BackColor = System.Drawing.Color.White
                    dtg.Item("trDrywall".ToLower, i).Style.BackColor = System.Drawing.Color.White
                    dtg.Item("arandela".ToLower, i).Style.BackColor = System.Drawing.Color.White
                    dtg.Item("clas_cor".ToLower, i).Style.BackColor = System.Drawing.Color.White
                End If
            End If
            i = i + 1
        End While
    End Sub
    Public Sub sumarTodo()
        Dim mesIni As Double = cboMesIni.SelectedIndex + 1
        Dim añoIni As Double = cboAñoIni.SelectedItem
        Dim mesFin As Double = cboMesFin.SelectedIndex + 1
        Dim añoFin As Double = cboAñoFin.SelectedItem
        Dim min As Double = txtMin.Text
        Dim max As Double = txtMax.Text
        ''Dim criterio As String
        ''If (chkKilos.Checked = True) Then
        ''    criterio = "kilos"
        ''Else
        ''    criterio = "Vr_total"
        ''End If
        For i = 0 To dtgAcumVentas.ColumnCount - 1

        Next
        Dim sum As Double = 0
        For i = 5 To dtgAcumVentas.ColumnCount - 1
            For j = 1 To dtgAcumVentas.RowCount - 1
                If Not IsDBNull(dtgAcumVentas(i, j).Value) Then
                    sum += dtgAcumVentas(i, j).Value
                End If
            Next
            dtgAcumVentas(i, 0).Value = sum
            sum = 0
        Next
        txtValtot.Text = Format(objAcumVenLn.obtenerTot(min, max, mesIni, añoIni, mesFin, añoFin, "Vr_total"), "###,###,###")
        txttotKilos.Text = Format(objAcumVenLn.obtenerTot(min, max, mesIni, añoIni, mesFin, añoFin, "kilos"), "###,###,###")
    End Sub
#End Region



#Region "Controles del formulario"
    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        limpiarCampos()
        Dim vendedores As String = objUsuarioLn.coordinadorVend(objUsuarioEn.usuario)
        If (cboMesIni.SelectedIndex <> -1 And cboAñoIni.SelectedIndex <> -1 And cboMesFin.SelectedIndex <> -1 And cboAñoFin.SelectedIndex <> -1 And txtMin.Text <> "" And txtMax.Text <> "") Then
            If (chkKilos.Checked = True Or chkPesos.Checked = True) Then
                If (txtMin.Text > txtMax.Text) Then
                    MsgBox("El vendedor  inicial debe ser mayor al vendedor final")
                Else
                    If (cboAñoIni.SelectedIndex >= cboAñoFin.SelectedIndex) Then
                        If (cboMesIni.SelectedIndex <= cboMesFin.SelectedIndex) Then
                            imgProc.Visible = True
                            Application.DoEvents()
                            Dim mesIni As Double = cboMesIni.SelectedIndex + 1
                            Dim añoIni As Double = cboAñoIni.SelectedItem
                            Dim mesFin As Double = cboMesFin.SelectedIndex + 1
                            Dim añoFin As Double = cboAñoFin.SelectedItem
                            Dim min As Double = txtMin.Text
                            Dim max As Double = txtMax.Text
                            Dim criterio As String
                            If (chkKilos.Checked = True) Then
                                criterio = "kilos"
                            Else
                                criterio = "Vr_total"
                            End If
                            dtgAcumVentas.DataSource = objAcumVenLn.ppalVent(min, max, mesIni, añoIni, mesFin, añoFin, criterio, vendedores, chkVendHoy.Checked)
                            sumarTodo()
                            formatoNegrita(dtgAcumVentas)
                            imgProc.Visible = False
                        Else
                            MsgBox("El mes final debe ser mayor al mes inicial")
                        End If

                    Else
                        MsgBox("El año final debe ser mayor al año inicial")
                    End If


                End If
            Else
                MsgBox("Selecione discriminaciòn por kilos ò pesos")

            End If
        Else
            MsgBox("Selecione todos los criterios de busqueda")
        End If

    End Sub
    Private Sub btnBuscarPedido_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarPedido.Click
        If (txtCriterio.Text <> "") Then
            limpiarColumnas()
            buscarColumnas(txtCriterio.Text)
        Else
            MsgBox("Se debe ingresar un criterio para la busqueda")
        End If

    End Sub
    Public Sub formatoNegrita(ByVal dtg As DataGridView)
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        dtg.Columns(0).DefaultCellStyle = DataGridViewCellStyle1
        dtg.Rows(0).DefaultCellStyle = DataGridViewCellStyle1
        'dtg.Rows(0).DefaultCellStyle.BackColor = Color.Red
    End Sub
    '*******************************************************************************************
    'Controles toolTrip Menu********************************************************************
    '*******************************************************************************************

    Private Sub GestiònClientesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmPendientes.Show()
        Me.Close()
        frmPendientes.Activate()
    End Sub

    Private Sub AnalisisPedidoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FrmAnalisisPedido.Show()
        Me.Close()
        FrmAnalisisPedido.Activate()
    End Sub

    Private Sub SalirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalirToolStripMenuItem.Click
        FrmLogin.Show()
        FrmPrincipal.Close()
        Me.Close()
    End Sub

    Private Sub chkKilos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkKilos.CheckedChanged
        If chkKilos.Checked = True Then
            chkPesos.Checked = False
        End If
    End Sub

    Private Sub chkPesos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPesos.CheckedChanged
        If chkPesos.Checked = True Then
            chkKilos.Checked = False
        End If
    End Sub


    Private Sub PrincipalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrincipalToolStripMenuItem.Click
        FrmPrincipal.Show()
        Me.Close()
        FrmPrincipal.Activate()
    End Sub

    Private Sub ExportarAExcelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportarAExcelToolStripMenuItem.Click
        objOperacionesForm.ExportarDatosExcel(dtgAcumVentas, "Acumulado ventas")
    End Sub
    Private Sub txtCriterio_TextChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCriterio.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            btnBuscarPedido.PerformClick()
        End If
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

#End Region


End Class