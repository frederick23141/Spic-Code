Imports System.Configuration
Imports logicaNegocios
Imports System.IO
Imports Microsoft.Office.Interop
Public Class Frm_traz_cli_vend
    Private objEstClienVendLn As New EstClienVendLn
    Private objOperacionesForm As OperacionesFormularios = New OperacionesFormularios
    Private nit As Double = 0
    Public Sub Main(ByVal client As Integer)
        nit = client
    End Sub
    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        FrmLogin.Show()
        FrmPrincipal.Close()
        FrmLogin.Activate()
        Me.Close()
    End Sub

    Private Sub KilosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KilosToolStripMenuItem.Click
        objOperacionesForm.ExportarDatosExcel(dtg_consulta_kilos, "Detalle kilos")
    End Sub

    Private Sub PesosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PesosToolStripMenuItem.Click
        objOperacionesForm.ExportarDatosExcel(dtg_consulta_pesos, "Detalle pesos")
    End Sub

    Private Sub Frm_traz_cli_vend_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim año = Now.Year
        While (2000 <= año)
            cboAñoIni.Items.Add(año)
            cboAñoFin.Items.Add(año)
            año -= 1
        End While
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Dim mes_ini As Integer = cboMesIni.SelectedIndex + 1
        Dim mes_fin As Integer = cboMesFin.SelectedIndex + 1
        Dim ano_ini As Integer = cboAñoIni.SelectedItem
        Dim ano_fin As Integer = cboAñoFin.SelectedItem
        If (mes_fin = 12) Then
            ano_fin += 1
            mes_fin = 1
        End If
        Dim fec_ini As Date = ano_ini & "-" & mes_ini & "-01"
        Dim fec_fin As Date = ano_fin & "-" & mes_fin + 1 & "-01"
        dtg_consulta_pesos.DataSource = objEstClienVendLn.listar_traz(nit, "Vr_total", fec_ini, fec_fin)
        dtg_consulta_kilos.DataSource = objEstClienVendLn.listar_traz(nit, "KILOS", fec_ini, fec_fin)
    End Sub
End Class