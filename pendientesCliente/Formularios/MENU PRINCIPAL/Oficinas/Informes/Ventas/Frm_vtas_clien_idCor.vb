Imports System.Configuration
Imports entidadNegocios
Imports logicaNegocios
Public Class Frm_vtas_clien_idCor
    Private objUsuarioLn As New UsuarioLn
    Private objUsuarioEn As New UsuarioEn
    Private objOperacionesForm As OperacionesFormularios = New OperacionesFormularios
    Private obj_vtas_clien_idCorLn As New Vtas_clien_idCorLn
    Private nom_modulo As String
    Public Sub Main(ByVal nom_modulo As String, ByVal permiso As String, ByVal objUsuarioEn As UsuarioEn)
        Me.nom_modulo = nom_modulo
        If (permiso <> "ADMIN") Then
            btnContCambios.Visible = False
        End If
        Me.objUsuarioEn = objUsuarioEn
    End Sub
    Private Sub btnContCambios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnContCambios.Click
        FrmAuditCambios.Show()
        FrmAuditCambios.Main(nom_modulo)
        FrmAuditCambios.WindowState = 2
    End Sub
    Private Sub Frm_vtas_clien_idCor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ano = Now.Year
        While (Now.Year - 5 <= ano)
            cbo_ano_ini.Items.Add(ano)
            cbo_ano_fin.Items.Add(ano)
            ano -= 1
        End While
        cbo_ano_ini.SelectedIndex = 3
        cbo_ano_fin.SelectedIndex = 0
    End Sub
    Private Sub btn_buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar.Click
        If (txtNit.Text <> "" And cbo_ano_fin.Text <> "" And cbo_ano_ini.Text <> "") Then
            Dim vendedores As String = objUsuarioLn.coordinadorVend(objUsuarioEn.usuario)
            dtg_consulta_pesos.DataSource = obj_vtas_clien_idCorLn.listar_consulta(txtNit.Text, cbo_ano_ini.Text, cbo_ano_fin.Text, vendedores, chk_vend_hoy.Checked)
            formato_celdas(dtg_consulta_pesos)
        Else
            MessageBox.Show("Seleccione todos los criterios de busqueda!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub
    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        FrmLogin.Show()
        FrmPrincipal.Close()
        Me.Close()
    End Sub

    Private Sub btn_ppal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ppal.Click
        FrmPrincipal.Show()
        Me.Close()
    End Sub
    Private Sub ConsolidadoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConsolidadoToolStripMenuItem.Click
        objOperacionesForm.ExportarDatosExcel(dtg_consulta_pesos, "Ventas cliente - linea producción")
    End Sub

    Private Sub DetalleToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DetalleToolStripMenuItem.Click
        objOperacionesForm.ExportarDatosExcel(dtg_detalle, "Ventas cliente - linea producción")
    End Sub
    Private Sub formato_celdas(ByVal dtg As DataGridView)
        Dim cad As String = ""
        For i = 0 To dtg.ColumnCount - 1
            cad = dtg.Columns(i).HeaderText.ToString
            Select Case cad(0)
                Case "%"
                    dtg.Columns(i).DefaultCellStyle.Format = "N1"
                Case "k"
                    dtg.Columns(i).DefaultCellStyle.Format = "N0"
                Case "V"
                    dtg.Columns(i).DefaultCellStyle.Format = "C0"
            End Select
        Next
    End Sub
    Private Sub dtgResultClient_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dtg_consulta_pesos.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            With (Me.dtg_consulta_pesos)
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                End If
            End With
        End If
    End Sub

    Private Sub men_detalle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles men_detalle.Click
        Frm_traz_cli_vend.Activate()
        If (dtg_consulta_pesos.CurrentCell.RowIndex > -1 And dtg_consulta_pesos.CurrentCell.ColumnIndex <> 0 And dtg_consulta_pesos.CurrentCell.ColumnIndex <> 1 And dtg_consulta_pesos.CurrentCell.ColumnIndex <> 2) Then
            Dim cad As String = dtg_consulta_pesos.Columns(dtg_consulta_pesos.CurrentCell.ColumnIndex).HeaderText.ToString
            Dim ano As String = ""
            For i = 0 To cad.Length - 1
                If IsNumeric(cad(i)) Then
                    ano += cad(i)
                End If
            Next
            If (ano <> "") Then
                ano = Convert.ToInt16(ano)
            End If
            Dim nit As Double = dtg_consulta_pesos.Item("nit", dtg_consulta_pesos.CurrentCell.RowIndex).Value
            Dim id_cor As Integer = dtg_consulta_pesos.Item("Id_cor", dtg_consulta_pesos.CurrentCell.RowIndex).Value
            dtg_detalle.DataSource = obj_vtas_clien_idCorLn.listar_detalle(ano, nit, id_cor)
        End If
    End Sub
    Private Sub txt_nombre_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_nombre.KeyPress
        If Not Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
        If (txt_nombre.Text <> "") Then
            Dim sql As String = "SELECT nit,nombres FROM terceros WHERE nombres like '" & txt_nombre.Text & "%'"
            dtg_clientes.DataSource = obj_vtas_clien_idCorLn.cargar_table(sql)
        End If

    End Sub
    Private Sub dtg_clientes_CellContentDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtg_clientes.CellContentDoubleClick
        If (e.ColumnIndex >= 0) Then
            Dim nit As Integer = dtg_clientes("nit", e.RowIndex).Value
            txtNit.Text = nit
            btn_buscar.PerformClick()
        End If

    End Sub
    Private Sub txtNit_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNit.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

End Class