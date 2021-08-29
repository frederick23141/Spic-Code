Imports logicaNegocios
Public Class Frm_eficiencias
    Private obj_Ing_prodLn As New Ing_prodLn
    Private carga_comp As Boolean = False
    Private objOperacionesForm As New OperacionesFormularios
    Private objOpSimplesLn As New Op_simpesLn
    Private nom_modulo As String
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
    Private Sub Frm_eficiencias_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim sql As String
        cbo_fecha_ini.Value = Now.Year & "-" & Now.Month & "-01"
        cbo_fecha_fin.Value = Now.Date.Date
        sql = "select  id,descripcion   from j_secciones "
        cbo_seccion.DataSource = obj_Ing_prodLn.listar_datatable(sql, "PRODUCCION")
        cbo_seccion.ValueMember = "id"
        cbo_seccion.DisplayMember = "descripcion"
        cbo_seccion.Text = "Seleccione"
        carga_comp = True
    End Sub

    Private Sub cbo_fecha_fin_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_fecha_fin.ValueChanged
        cargar_consulta()
    End Sub
    Public Sub cargar_trefilacion(ByVal fec_ini As String, ByVal fec_fin As String)
        dtg_consulta.DataSource = obj_Ing_prodLn.efic_trfilacion(fec_ini, fec_fin)
    End Sub
    Public Sub cargar_puas(ByVal fec_ini As String, ByVal fec_fin As String)
        dtg_consulta.DataSource = obj_Ing_prodLn.efic_puas(fec_ini, fec_fin)
    End Sub
    Public Sub cargar_puntilleria(ByVal fec_ini As String, ByVal fec_fin As String)
        dtg_consulta.DataSource = obj_Ing_prodLn.efic_puntilleria(fec_ini, fec_fin)
    End Sub
    Private Sub cbo_seccion_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_seccion.SelectedIndexChanged
        cargar_consulta()
    End Sub
    Public Sub cargar_consulta()
        If (carga_comp) Then
            If (cbo_seccion.Text <> "Seleccione") Then
                Dim fec_ini As String = objOpSimplesLn.cambiarFormatoFecha(cbo_fecha_ini.Value.Date)
                Dim fec_fin As String = objOpSimplesLn.cambiarFormatoFecha(cbo_fecha_fin.Value.Date)
                Dim sum_pxn As Double = 0
                Dim sum_prod_esp As Double = 0
                Select Case cbo_seccion.SelectedValue
                    Case 1
                        cargar_trefilacion(fec_ini, fec_fin)
                    Case 2
                        cargar_puas(fec_ini, fec_fin)
                    Case 3
                        dtg_consulta.DataSource = Nothing
                        MessageBox.Show("Funcionalidad no implementada para esta area!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Case 4
                        dtg_consulta.DataSource = Nothing
                        MessageBox.Show("Funcionalidad no implementada para esta area!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Case 5
                        dtg_consulta.DataSource = Nothing
                        MessageBox.Show("Funcionalidad no implementada para esta area!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Case 6
                        dtg_consulta.DataSource = Nothing
                        MessageBox.Show("Funcionalidad no implementada para esta area!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Case 7
                        cargar_puntilleria(fec_ini, fec_fin)
                    Case 8
                End Select
                If (dtg_consulta.RowCount > 0) Then
                    sum_prod_esp = sumarColumnas("Esperada")
                    sum_pxn = sumarColumnas("Pxn")
                    dtg_consulta.Item("Operario", dtg_consulta.RowCount - 1).Value = "TOTAL"
                    dtg_consulta.Item("Pxn", dtg_consulta.RowCount - 1).Value = sum_pxn
                    dtg_consulta.Item("Esperada", dtg_consulta.RowCount - 1).Value = sum_prod_esp
                    dtg_consulta.Item("Eficiencia", dtg_consulta.RowCount - 1).Value = (sum_pxn / sum_prod_esp) * 100
                    formatoNegrita()
                    dtg_consulta.Columns("Eficiencia").DefaultCellStyle.Format = "N1"
                End If
            Else
                MessageBox.Show("Seleccione una sección! ", "Seleccione", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
        End If
    End Sub
    Private Sub cbo_fecha_ini_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_fecha_ini.ValueChanged
        cargar_consulta()
    End Sub
    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        FrmPrincipal.Show()
        Me.Close()
        FrmPrincipal.Activate()
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        FrmLogin.Show()
        FrmPrincipal.Close()
        Me.Close()
    End Sub

    Private Sub btn_excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_excel.Click
        objOperacionesForm.ExportarDatosExcel(dtg_consulta, "Trefilación")
    End Sub
    Private Function sumarColumnas(ByVal nomColumna As String) As Double
        Dim total As Double = 0
        For i As Integer = 0 To dtg_consulta.RowCount - 1
            If Not IsDBNull(dtg_consulta.Item(nomColumna.ToLower, i).Value) Then
                total = total + CDbl(dtg_consulta.Item(nomColumna.ToLower, i).Value)
            End If
        Next
        Return total
    End Function
    Public Sub formatoNegrita()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        dtg_consulta.Columns(0).DefaultCellStyle = DataGridViewCellStyle1
        dtg_consulta.Rows(dtg_consulta.RowCount - 1).DefaultCellStyle = DataGridViewCellStyle1
    End Sub
   
End Class