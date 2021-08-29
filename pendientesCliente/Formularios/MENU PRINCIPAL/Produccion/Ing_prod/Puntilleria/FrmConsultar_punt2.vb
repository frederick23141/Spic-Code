Imports logicaNegocios
Public Class FrmConsultar_punt2
    Private objOpsimpesLn As New Op_simpesLn
    Private obj_Ing_prodLn As New Ing_prodLn
    Private objOperacionesForm As New OperacionesFormularios
    Dim carga_comp As Boolean = False
    Private Sub FrmConsultar_punt2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim sql As String
        Dim dt As DataTable
        Dim row As DataRow
        Dim año = Now.Year
        While (año >= Now.Year - 5)
            cboAñoIni.Items.Add(año)
            año -= 1
        End While

        Sql = "select  seccion   from J_seccion_maquina_punt group by seccion "
        dt = New DataTable
        dt = obj_Ing_prodLn.listar_datatable(Sql, "PRODUCCION")
        row = dt.NewRow
        row("seccion") = 0
        row("seccion") = "TODOS"
        dt.Rows.Add(row)
        cboSeccion.DataSource = dt
        cboSeccion.ValueMember = "seccion"
        cboSeccion.DisplayMember = "seccion"
        cboSeccion.Text = "Seleccione"

        cbo_mes.DataSource = objOpsimpesLn.returnDtMeses()
        cbo_mes.ValueMember = "numMes"
        cbo_mes.DisplayMember = "nombMes"
        cbo_mes.Text = "Seleccione"
        carga_comp = True
    End Sub
    Private Sub cargar_consulta()
        If (cbo_mes.Text <> "Seleccione") Then
            If (cboAñoIni.Text <> "Seleccione") Then
                If (cboSeccion.Text <> "Seleccione") Then
                    Dim mes As Integer = cbo_mes.SelectedValue
                    Dim ano As String = cboAñoIni.Text
                    Dim seccion As String = cboSeccion.Text
                    Dim dt As New DataTable
                    Dim whereSql As String = "WHERE mes=" & mes & " AND ano=" & ano
                    Dim orderSql As String = "ORDER BY seccion"
                    If (cboSeccion.Text <> "TODOS") Then
                        whereSql &= " AND seccion = '" & seccion & "' "
                    End If
                    Dim sql As String = "SELECT * FROM J_v_puntilleria " & _
                             whereSql & _
                                    orderSql
                    dt = obj_Ing_prodLn.listar_datatable(sql, "PRODUCCION")
                    dt.Columns.Add("%paros", GetType(Double))
                    dt.Columns.Add("T_sin just", GetType(Double))
                    dt.Columns.Add("%T_sin just", GetType(Double))

                    For i = 0 To dt.Rows.Count - 1
                        If (Not (IsDBNull(dt.Rows(i).Item("Paros")) And Not IsDBNull(dt.Rows(i).Item("T_trabajado")) And Not IsDBNull(dt.Rows(i).Item("T_programado")))) Then
                            dt.Rows(i).Item("%paros") = (dt.Rows(i).Item("Paros") / dt.Rows(i).Item("T_trabajado") * 100)
                            dt.Rows(i).Item("T_sin just") = dt.Rows(i).Item("T_programado") - (dt.Rows(i).Item("T_trabajado") + dt.Rows(i).Item("Paros"))
                            dt.Rows(i).Item("%T_sin just") = (dt.Rows(i).Item("T_sin just") / dt.Rows(i).Item("T_programado") * 100)
                        End If

                    Next
            
                    dtg_consulta.DataSource = dt
                    dtg_consulta.Columns("%paros").DefaultCellStyle.Format = "N1"
                    dtg_consulta.Columns("%T_sin just").DefaultCellStyle.Format = "N1"
                    dtg_consulta.Columns("mes").Visible = False
                    dtg_consulta.Columns("ano").Visible = False
                    formatoNegrita(dtg_consulta)
                Else
                    MessageBox.Show("Seleccione una sección para generar la consulta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                MessageBox.Show("Seleccione un año para generar la consulta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            MessageBox.Show("Seleccione un mes para generar la consulta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
       
    End Sub
    Public Sub formatoNegrita(ByVal dtg As DataGridView)
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        dtg.Columns("Seccion").DefaultCellStyle = DataGridViewCellStyle1
    End Sub

    Private Sub cbo_mes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_mes.SelectedIndexChanged
        If (carga_comp) Then
            If (cbo_mes.Text <> "Seleccione") Then
                If (cboAñoIni.Text <> "Seleccione") Then
                    cargar_consulta()
                End If
            End If
        End If
    End Sub
   

    Private Sub cboAñoIni_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAñoIni.SelectedIndexChanged
        If (carga_comp) Then
            If (cbo_mes.Text <> "Seleccione") Then
                If (cboAñoIni.Text <> "Seleccione") Then
                    cargar_consulta()
                End If
            End If
        End If
    End Sub

    Private Sub cboSeccion_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSeccion.SelectedIndexChanged
        If (carga_comp) Then
            If (cbo_mes.Text <> "Seleccione" And cboAñoIni.Text <> "Seleccione" And cboSeccion.Text <> "Seleecione") Then
                cargar_consulta()
            End If
        End If
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
        objOperacionesForm.ExportarDatosExcel(dtg_consulta, "Puntilleria")
    End Sub

End Class