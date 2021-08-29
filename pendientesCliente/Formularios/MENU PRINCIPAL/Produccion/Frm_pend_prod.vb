Imports System.Configuration
Imports logicaNegocios
Imports System.IO
Imports Microsoft.Office.Interop
Imports System.Windows.Forms.DataVisualization.Charting
Public Class Frm_pend_prod
    Private obj_pend_prodLn As New Pend_prodLn
    Private objOpercionesForm As New OperacionesFormularios
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
    Private Sub Frm_pend_prod_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim id_cor(,) As String = obj_pend_prodLn.listar_id_cor()
        For i = 0 To 40
            If (id_cor(i, 1) <> "") Then
                cbo_linea_prod.Items.Add(id_cor(i, 1))
            End If
        Next
        Dim tipo_idcor() As String = obj_pend_prodLn.listar_tipo_idCor()
        For i = 0 To 10
            If (tipo_idcor(i) <> "") Then
                cbo_planta.Items.Add(tipo_idcor(i))
            End If
        Next
        cbo_planta.Items.Add("RESUMEN")
        chk_detalle.Checked = True
    End Sub

    Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'cargar_info()
        MsgBox(cbo_linea_prod.SelectedIndex)
        MsgBox(cbo_planta.SelectedIndex)
    End Sub
    Private Sub cargar_info(ByVal idcor_min As Integer, ByVal idcor_max As Integer)
        dtg_pend_prod.DataSource = obj_pend_prodLn.listar_pend_prod(idcor_min, idcor_max)
    End Sub

    Private Sub cbo_linea_prod_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_linea_prod.SelectedIndexChanged
        imgProcesar.Visible = True
        Application.DoEvents()
        cbo_planta.Text = ""
        Dim idcor As Integer = cbo_linea_prod.SelectedIndex + 1
        If (chk_detalle.Checked = True) Then

            If (cbo_linea_prod.Text = "TODOS") Then
                dtg_pend_prod.DataSource = obj_pend_prodLn.listarBusqueda(0, 0, "TODOS")
            Else
                dtg_pend_prod.DataSource = obj_pend_prodLn.listarBusqueda(idcor, idcor, "")
                'cargar_info(idcor, idcor)
            End If
            ' dtg_pend_prod.DataSource = obj_pend_prodLn.listarBusqueda(idcor, idcor, "")
            
            dtg_pend_prod.Columns("Fecha").DefaultCellStyle.Format = "d"
        Else
            If (cbo_linea_prod.Text = "TODOS") Then
                dtg_pend_prod.DataSource = obj_pend_prodLn.listarConsolidado(0, 0, "TODOS")
            Else
                dtg_pend_prod.DataSource = obj_pend_prodLn.listarConsolidado(idcor, idcor, "")
            End If

            'cargar_info(idcor, idcor)
        End If
        imgProcesar.Visible = False
        txt_tot_cant.Text = sumarColumnas("Cant_Pend", dtg_pend_prod).ToString("N0")
        txt_tot_kilos.Text = sumarColumnas("Kilos_Pend", dtg_pend_prod).ToString("N0")
        dtg_pend_prod.Focus()
    End Sub


    Private Sub cbo_tipo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_planta.SelectedIndexChanged
        imgProcesar.Visible = True
        Application.DoEvents()
        If (chk_detalle.Checked = True) Then
            cbo_linea_prod.Text = ""

            If (cbo_planta.Text = "TODOS") Then
                dtg_pend_prod.DataSource = obj_pend_prodLn.listarBusqueda(0, 0, "TODOS")
                dtg_pend_prod.Columns("Fecha").DefaultCellStyle.Format = "d"
            ElseIf (cbo_planta.Text = "RESUMEN") Then
                dtg_pend_prod.DataSource = obj_pend_prodLn.Detalle_consol_pend_idCor()
                sumar_filas_grid(dtg_pend_prod)
            Else
                dtg_pend_prod.DataSource = obj_pend_prodLn.listarBusqueda(0, 0, cbo_planta.SelectedIndex + 1)
                dtg_pend_prod.Columns("Fecha").DefaultCellStyle.Format = "d"
                'cargar_info(idcor, idcor)
            End If

        Else
            If (cbo_planta.Text = "TODOS") Then
                dtg_pend_prod.DataSource = obj_pend_prodLn.listarConsolidado(0, 0, "TODOS")
            ElseIf (cbo_planta.Text = "RESUMEN") Then
                dtg_pend_prod.DataSource = obj_pend_prodLn.Detalle_consol_pend_idCor()
                sumar_filas_grid(dtg_pend_prod)
            Else
                dtg_pend_prod.DataSource = obj_pend_prodLn.listarConsolidado(0, 0, cbo_planta.SelectedIndex + 1)
                'cargar_info(idcor, idcor)
            End If
           
        End If
        txt_tot_cant.Text = sumarColumnas("Cant_Pend", dtg_pend_prod).ToString("N0")
        txt_tot_kilos.Text = sumarColumnas("Kilos_Pend", dtg_pend_prod).ToString("N0")
        imgProcesar.Visible = False
        dtg_pend_prod.Focus()

    End Sub

   Private Sub PrincipalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrincipalToolStripMenuItem.Click
        FrmPrincipal.Show()
        FrmPrincipal.Activate()
        Me.Close()
    End Sub
    Private Sub SalirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalirToolStripMenuItem.Click
        FrmLogin.Show()
        FrmPrincipal.Close()
        FrmLogin.Activate()
        Me.Close()
    End Sub

    Private Sub ExportarAExcelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportarAExcelToolStripMenuItem.Click
        objOpercionesForm.ExportarDatosExcel(dtg_pend_prod, "Pendientes")
    End Sub
    Private Function sumarColumnas(ByVal nomColumna As String, ByVal dtg As DataGridView) As Double
        Dim total As Double = 0
        For i As Integer = 0 To dtg.RowCount - 1
            total = total + CDbl(dtg.Item(nomColumna.ToLower, i).Value)
        Next
        Return total
    End Function

    Private Sub chk_detalle_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_detalle.CheckedChanged
        If (chk_detalle.Checked = False) Then
            chk_consol.Checked = True
        Else
            chk_consol.Checked = False
        End If
        cbo_planta.Text = ""
        cbo_linea_prod.Text = ""
    End Sub

    Private Sub chk_consol_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_consol.CheckedChanged
        If (chk_consol.Checked = False) Then
            chk_detalle.Checked = True
        Else
            chk_detalle.Checked = False
        End If
        cbo_planta.Text = ""
        cbo_linea_prod.Text = ""
    End Sub
    Public Sub sumar_filas_grid(ByVal dtg As DataGridView)
        Dim suma As Double = 0
        dtg.Item("Descripciòn", dtg.RowCount - 1).Value = "TOTAL"
        dtg.Rows(dtg.RowCount - 1).DefaultCellStyle.BackColor = Color.Red
        For j = 1 To dtg.ColumnCount - 1
            For i = 0 To dtg.RowCount - 1
                suma = suma + dtg.Item(j, i).Value
            Next
            dtg.Item(j, dtg.RowCount - 1).Value = suma
            suma = 0
        Next
    End Sub
End Class