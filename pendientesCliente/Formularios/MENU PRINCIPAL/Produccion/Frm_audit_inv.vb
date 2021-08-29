Imports System.Configuration
Imports logicaNegocios
Imports entidadNegocios
Imports System.IO
Imports Microsoft.Office.Interop
Imports System.ComponentModel
Imports System.Threading
Public Class Frm_audit_inv
    Dim objAudit_invLn As New Audit_invLn
    Private eje_proceso As Threading.Thread
    Private objOpercionesForm As OperacionesFormularios = New OperacionesFormularios
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
    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        If (txt_codigo.Text <> "") Then
            If (cbo_bod.Text.ToString <> "Seleccione") Then
                'imgProc.Visible = True
                'pic_cargando.Visible = True
                'eje_proceso = New Threading.Thread(AddressOf cargar_todo)
                'If eje_proceso.ThreadState <> Threading.ThreadState.Running Then
                '    eje_proceso.Start()
                'End If
                cargar_todo()
            Else
                MessageBox.Show("Seleccione bodega!", "Seleccione!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            MessageBox.Show("Digite còdigo a consultar!", "Código vacio!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        'pic_cargando.Visible = False
    End Sub
    Public Sub cargar_todo()
        'pic_cargando.Visible = True
        imgProc.Visible = True
        Application.DoEvents()
        Dim cod As String = txt_codigo.Text
        Dim bodega As Integer = cbo_bod.Text
        dtg_audit_inv.DataSource = objAudit_invLn.listarBusqueda(cod, bodega)
        dtg_audit_inv.Columns("ult_entrada").DefaultCellStyle.Format = "d"
        dtg_audit_inv.Columns("ult_salida").DefaultCellStyle.Format = "d"
        dtg_audit_inv.Columns("ult_vta").DefaultCellStyle.Format = "d"
        imgProc.Visible = False
        totalisar_grid(dtg_audit_inv)
        formatoNegrita(dtg_audit_inv)
        ' pic_cargando.Visible = False
    End Sub
   
    Private Sub Frm_audit_inv_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Control.CheckForIllegalCrossThreadCalls = False
        ' pic_cargando.Visible = False
    End Sub
    Private Sub SalirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalirToolStripMenuItem.Click
        FrmLogin.Show()
        FrmPrincipal.Close()
        FrmLogin.Activate()
        Me.Close()
    End Sub
    Private Sub PrincipalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrincipalToolStripMenuItem.Click
        FrmPrincipal.Show()
        FrmPrincipal.Activate()
        Me.Close()
    End Sub

    Private Sub ExportarAExcelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportarAExcelToolStripMenuItem.Click
        objOpercionesForm.ExportarDatosExcel(dtg_audit_inv, "Pendientes buenos")
    End Sub
    Private Sub totalisar_grid(ByVal dtg As DataGridView)
        Dim total As Double = 0
        dtg.Item("bodega", dtg.RowCount - 1).Value = cbo_bod.Text
        dtg.Item("codigo", dtg.RowCount - 1).Value = txt_codigo.Text
        dtg.Item("descripcion", dtg.RowCount - 1).Value = "TOTALES"
        For j = 3 To 5
            For i As Integer = 0 To dtg.RowCount - 1
                total = total + CDbl(dtg.Item(j, i).Value)
            Next
            dtg.Item(j, dtg.RowCount - 1).Value = total
            total = 0
        Next
    End Sub
    Public Sub formatoNegrita(ByVal dtg As DataGridView)
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        dtg.Rows(dtg.RowCount - 1).DefaultCellStyle = DataGridViewCellStyle1
    End Sub
End Class