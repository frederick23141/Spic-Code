Imports System.Configuration
Imports logicaNegocios
Imports entidadNegocios
Public Class FrmVtasClienProd
    Private objUsuarioLn As New UsuarioLn
    Private objClientLn As New VtasClientLn
    Private objUsuarioEn As New UsuarioEn
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
    Private Sub FrmCVtasClienProd_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        centrarEnPantalla()
        Dim año = Now.Year
        While (año >= 2007)
            cboAñoIni.Items.Add(año)
            cboAñoFin.Items.Add(año)
            año -= 1
        End While
        imgProcesar.Visible = False
    End Sub
    Private Sub centrarEnPantalla()
        Me.Left = (Screen.PrimaryScreen.WorkingArea.Width - Me.Width) / 2
        Me.Top = (Screen.PrimaryScreen.WorkingArea.Height - Me.Height) / 2
    End Sub


    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click

        If (cboMesIni.SelectedIndex <> -1 And cboAñoIni.SelectedIndex <> -1 And cboMesFin.SelectedIndex <> -1 And cboAñoFin.SelectedIndex <> -1 And txtMin.Text <> "" And txtMax.Text <> "") Then
            If (txtCodIni.Text <> "" And TxtCodFin.Text <> "") Then
                If (txtMin.Text >= 1001 And txtMax.Text <= 1099) Then
                    If (txtMin.Text > txtMax.Text) Then
                        MsgBox("El vendedor  inicial debe ser mayor al vendedor final")
                    Else
                        If (cboAñoIni.SelectedIndex >= cboAñoFin.SelectedIndex) Then
                            ejecutar()
                        Else
                            MsgBox("El año final debe ser mayor al año inicial")
                        End If

                    End If
                Else
                    MsgBox("En vendedor minimo debe ser:1001 y el maximo:1099")
                End If
            Else
                MsgBox("Selecione rango de codigo")

            End If
        Else
            MsgBox("Selecione todos los criterios de busqueda")
        End If
    End Sub
    Private Sub ejecutar()
        Dim vendedores As String = objUsuarioLn.coordinadorVend(objUsuarioEn.usuario)
        Dim nitMin As Double
        Dim nitMax As Double
        Dim mesIni As Double
        Dim añoIni As Double
        Dim mesFin As Double
        Dim añoFin As Double
        Dim cogIni As String
        Dim cogFin As String
        imgProcesar.Visible = True
        Application.DoEvents()
        nitMin = txtMin.Text
        nitMax = txtMax.Text
        mesIni = cboMesIni.SelectedIndex + 1
        añoIni = cboAñoIni.SelectedItem
        mesFin = cboMesFin.SelectedIndex + 1
        añoFin = cboAñoFin.SelectedItem
        cogIni = txtCodIni.Text
        cogFin = TxtCodFin.Text
        DtgVtasClienProd.DataSource = objClientLn.listarClienProd(nitMin, nitMax, mesIni, añoIni, mesFin, añoFin, cogIni, cogFin, vendedores)
        'calCularVrUnit_VrKilos()
        DtgVtasClienProd.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        DtgVtasClienProd.DefaultCellStyle.Format = "##,##0"
        imgProcesar.Visible = False
        txt_cant.Text = sumarColumnas("Cantidad", DtgVtasClienProd).ToString("C0")
        txt_vr_total.Text = sumarColumnas("Vr_total", DtgVtasClienProd).ToString("C0")
        txt_kilos.Text = sumarColumnas("KILOS", DtgVtasClienProd).ToString("N0")
        DtgVtasClienProd.Columns("Cantidad").DefaultCellStyle.Format = ("C0")
        DtgVtasClienProd.Columns("Vr_total").DefaultCellStyle.Format = ("C0")
        DtgVtasClienProd.Columns("Kilos").DefaultCellStyle.Format = ("N0")
    End Sub
    Private Sub dtgAnalisisPres_CellFormatting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DtgVtasClienProd.CellFormatting
        Dim var As Integer = 0

        If (DtgVtasClienProd.RowCount Mod 2 = 1) Then
            var = 1
        End If
        If e.RowIndex Mod 2 = var Then
            e.CellStyle.BackColor = Color.Gainsboro
        End If
    End Sub
    Private Sub calCularVrUnit_VrKilos()
        For i = 0 To DtgVtasClienProd.RowCount - 1
            For j = 0 To DtgVtasClienProd.ColumnCount - 1
                If (DtgVtasClienProd(7, i).Value > 0) Then
                    DtgVtasClienProd(8, i).Value = DtgVtasClienProd(7, i).Value / DtgVtasClienProd(5, i).Value
                    DtgVtasClienProd(9, i).Value = DtgVtasClienProd(7, i).Value / DtgVtasClienProd(6, i).Value
                End If
            Next

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
        objOperacionesForm.ExportarDatosExcel(DtgVtasClienProd, "Vtas cliente producto  ")
    End Sub

    Private Sub txtMin_TextChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMin.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            BtnBuscar.PerformClick()
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
            BtnBuscar.PerformClick()
        End If
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

    End Sub
    Private Function sumarColumnas(ByVal nomColumna As String, ByVal dtg As DataGridView) As Double
        Dim total As Double = 0
        For i As Integer = 0 To dtg.RowCount - 1
            total = total + CDbl(dtg.Item(nomColumna.ToLower, i).Value)
        Next
        If (nomColumna = "Porc_util") Then
            total = total / dtg.RowCount - 1
        End If
        Return total
    End Function
End Class