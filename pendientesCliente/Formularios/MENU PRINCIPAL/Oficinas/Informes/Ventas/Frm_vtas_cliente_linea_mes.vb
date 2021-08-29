Imports logicaNegocios
Imports entidadNegocios
Public Class Frm_vtas_cliente_linea_mes
    Private obj_vtas_cliente_linea_mesLn As New vtas_cliente_linea_mesLn
    Private obj_op_simplesLn As New Op_simpesLn
    Private objOperacionesFormularios As New OperacionesFormularios
    Dim carga_comp As Boolean = False
    Dim objUsuarioEn As New UsuarioEn
    Dim vendedores As String = ""
    Private objUsuarioLn As New UsuarioLn
    Public Sub Main(ByVal objUsuarioEn As UsuarioEn)
        Me.objUsuarioEn = objUsuarioEn
        If objUsuarioEn.Vendedor <> 1020 Then
            vendedores = objUsuarioEn.Vendedor
        Else
            vendedores = objUsuarioLn.coordinadorVend(objUsuarioEn.usuario)
        End If
        If objUsuarioEn.permiso.Trim <> "ADMIN" Then
            chk_porc_util.Enabled = False
            chk_porc_util.Checked = False
        End If
    End Sub
    Private Sub Frm_vtas_cliente_linea_mes_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim ano = Now.Year
        While (2000 <= ano)
            cboAñoIni.Items.Add(ano)
            cboAñoFin.Items.Add(ano)
            ano -= 1
        End While
        carga_comp = True
    End Sub
    Private Sub btn_actualizar_Click(sender As System.Object, e As System.EventArgs) Handles btn_actualizar.Click
        Dim mes_ini As Integer = cboMesIni.SelectedIndex + 1
        Dim mes_fin As Integer = cboMesFin.SelectedIndex + 1
        Dim ano_ini As Integer = cboAñoIni.SelectedItem
        Dim ano_fin As Integer = cboAñoFin.SelectedItem
        Dim nit As Double
        If (cboMesIni.SelectedIndex <> -1 And cboAñoIni.SelectedIndex <> -1 And cboAñoFin.SelectedIndex <> -1) Then
            If (ano_ini > ano_fin) Then
                MessageBox.Show("EL año inicial debe ser menos que el año inicial ", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                If (txtNit.Text <> "") Then
                    dtg_consulta.DataSource = Nothing
                    Dim dt As New DataTable
                    nit = txtNit.Text
                    imgProcesar.Visible = True
                    Application.DoEvents()
                    Dim whereVendedor As String = ""
                    If vendedores <> "" Then
                        whereVendedor = " AND vendedor IN (" & vendedores & ")"
                    End If
                    dt = obj_vtas_cliente_linea_mesLn.list_analisos_vrKilo_meses(mes_ini, ano_ini, mes_fin, ano_fin, nit, whereVendedor)
                    dt.Rows.Add()
                    dtg_consulta.DataSource = dt
                    For i = 5 To dtg_consulta.Columns.Count - 1
                        dtg_consulta.Columns(i).DefaultCellStyle.Format = "N2"
                        i += 3
                    Next
                    tot_grid()
                    dtg_consulta.Columns("id_cor").Visible = False
                    For i = 4 To dtg_consulta.Columns.Count - 1
                        dtg_consulta.Columns(i).Visible = False
                        i += 3
                    Next
                    gestionar_columas()
                    imgProcesar.Visible = False
                Else
                    MessageBox.Show("Seleccione un nit", "Verifique!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

            End If

        Else
            MessageBox.Show("Todos los campos deben estar llenos!", "Verifique!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Private Sub gestionar_columas()
        For j = 0 To dtg_consulta.ColumnCount - 1
            If obj_op_simplesLn.buscarTexto(dtg_consulta.Columns(j).Name, "kilos") And chk_kilos.Checked = False Then
                dtg_consulta.Columns(j).Visible = False
            ElseIf obj_op_simplesLn.buscarTexto(dtg_consulta.Columns(j).Name, "vr_total") And chk_valor_total.Checked = False Then
                dtg_consulta.Columns(j).Visible = False
            ElseIf obj_op_simplesLn.buscarTexto(dtg_consulta.Columns(j).Name, "p_util") And chk_porc_util.Checked = False Then
                dtg_consulta.Columns(j).Visible = False
            End If
        Next
    End Sub
    Private Sub tot_grid()
        Dim tamano_letra As Single = 9.0!
        dtg_consulta.Item("Linea", dtg_consulta.Rows.Count - 1).Value = "TOTAL"
        dtg_consulta.Rows(dtg_consulta.Rows.Count - 1).DefaultCellStyle = objOperacionesFormularios.formatoNegrita(tamano_letra)
        dtg_consulta.Columns("Linea").DefaultCellStyle = objOperacionesFormularios.formatoNegrita(tamano_letra)
        dtg_consulta.Rows(dtg_consulta.Rows.Count - 1).DefaultCellStyle.BackColor = Color.Red
        Dim sum As Double = 0
        For i = 1 To dtg_consulta.Columns.Count - 1
            For j = 0 To dtg_consulta.Rows.Count - 1
                If Not IsDBNull(dtg_consulta.Item(i, j).Value) Then
                    sum += dtg_consulta.Item(i, j).Value
                End If
            Next
            dtg_consulta.Item(i, dtg_consulta.Rows.Count - 1).Value = sum
            sum = 0
        Next
        For i = 3 To dtg_consulta.Columns.Count - 1
            'Porc_util                                                                              'vr_total                                                  'costo                                             'vr_total

            'dtg_consulta.Columns(i + 2).Name = ""
            dtg_consulta.Item(i + 2, dtg_consulta.Rows.Count - 1).Value = (dtg_consulta.Item(i, dtg_consulta.Rows.Count - 1).Value - dtg_consulta.Item(i + 1, dtg_consulta.Rows.Count - 1).Value) / (dtg_consulta.Item(i, dtg_consulta.Rows.Count - 1).Value) * 100
            i += 3
        Next
    End Sub
    Private Sub txt_nombre_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_nombre.KeyPress
        If (carga_comp) Then
            If Not Char.IsDigit(e.KeyChar) Then
                e.Handled = False
            ElseIf Char.IsControl(e.KeyChar) Then
                e.Handled = False
            Else
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub txtNit_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNit.KeyPress
        If (carga_comp) Then
            If Char.IsDigit(e.KeyChar) Then
                e.Handled = False
            ElseIf Char.IsControl(e.KeyChar) Then
                e.Handled = False
            Else
                e.Handled = True
            End If
           
        End If
    End Sub
    Private Sub buscar_tercero()
        Dim whereSql As String = "WHERE "
        If (txt_nombre.Text <> "") Then
            whereSql &= "nombres like '%" & txt_nombre.Text & "%'"
        ElseIf (txtNit.Text <> "") Then
            whereSql &= "nit like '" & txtNit.Text & "%'"
        End If
        Dim sql As String = "SELECT nombres,nit FROM terceros " & whereSql
        dtg_clientes.DataSource = obj_op_simplesLn.listar_datatable(sql, "CORSAN")
    End Sub

    Private Sub dtg_clientes_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtg_clientes.CellClick
        If (e.RowIndex >= 0) Then
            carga_comp = False
            txtNit.Text = dtg_clientes.Item("nit", e.RowIndex).Value
            carga_comp = True
        End If
    End Sub

    Private Sub txt_nombre_TextChanged(sender As System.Object, e As System.EventArgs) Handles txt_nombre.TextChanged
        If (carga_comp) Then
            carga_comp = False
            txtNit.Text = ""
            carga_comp = False
            If (txt_nombre.Text <> "" And txt_nombre.Text.Length > 3) Then
                buscar_tercero()
            End If
            carga_comp = True
        End If
    End Sub

    Private Sub txtNit_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtNit.TextChanged
        If (carga_comp) Then
            carga_comp = False
            txt_nombre.Text = ""
            carga_comp = False
            If (txtNit.Text <> "" And txtNit.Text.Length > 3) Then
                buscar_tercero()
            End If
            carga_comp = True
        End If
    End Sub

    Private Sub btn_exportar_excel_Click(sender As System.Object, e As System.EventArgs) Handles btn_exportar_excel.Click
        objOperacionesFormularios.ExportarDatosExcel(dtg_consulta, "Ventas-cliente-linea de producción (mes)")
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
   
End Class