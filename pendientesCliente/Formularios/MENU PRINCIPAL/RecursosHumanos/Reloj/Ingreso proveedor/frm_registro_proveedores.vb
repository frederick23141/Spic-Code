Imports logicaNegocios
Imports entidadNegocios
Public Class frm_registro_proveedores
    Dim nombre_Empresa As String = ""
    Dim nombre_Cont As String = ""
    Dim nit_Cont As String = ""
    Dim sql As String
    Dim val As String
    Dim nit_consulta As String = ""
    Private objOpSimplesLn As New Op_simpesLn
    Private Sub btn_guardar_Click(sender As Object, e As EventArgs) Handles btn_guardar.Click
        If validar_Ingreso_Contratista() Then
            nit_Cont = txt_nit_prov.Text
            nombre_Cont = txt_nomb_prov.Text
            nombre_Empresa = txt_empresa.Text
            sql = "select nit_Contratista from J_control_contratistas where nit_Contratista=" & nit_Cont & ""
            val = objOpSimplesLn.consultValorTodo(sql, "CONTROL")
            If val = "" Then
                sql = "INSERT INTO J_control_contratistas (nit_Contratista,nombre_Contratista,nombre_Empresa) VALUES " &
                       "(" & nit_Cont & ",'" & nombre_Cont & "','" & nombre_Empresa & "')"
                objOpSimplesLn.ejecutar(sql, "CONTROL")
                cargar_consulta()
                MessageBox.Show("El contratista ha sido registrado")
                nuevo()
            Else
                MessageBox.Show("El contratista ya esta registrado")
                nuevo()
            End If
        End If
    End Sub
    Private Sub cargar_consulta()
        Dim dt As DataTable
        sql = "select nit_Contratista as nit,nombre_Contratista as nombre,nombre_Empresa as empresa from J_control_contratistas"
        dt = objOpSimplesLn.listar_datatable(sql, "CONTROL")
        blinding_temporales = New BindingSource()
        blinding_temporales.DataSource = dt
        dtg_contratista.DataSource = blinding_temporales
    End Sub
    Private Function validar_Ingreso_Contratista()
        Dim resp As Boolean = False
        If txt_nomb_prov.Text <> "" Then
            If txt_empresa.Text <> "" Then
                If txt_nit_prov.Text <> "" And CInt(txt_nit_prov.Text) Then
                    resp = True
                End If
            End If
        End If
        Return resp
    End Function
    Private Sub nuevo()
        txt_empresa.Text = ""
        txt_nit_prov.Text = ""
        txt_nomb_prov.Text = ""
    End Sub

    Private Sub txt_buscar_TextChanged(sender As Object, e As EventArgs) Handles txt_buscar.TextChanged
        blinding_temporales.Filter = String.Format("nombre LIKE '{0}%'", txt_buscar.Text)
    End Sub
    Private Sub frm_registro_proveedores_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargar_consulta()
    End Sub
    Private Sub AsignarDiasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AsignarDiasToolStripMenuItem.Click
        Dim frm As New Asignar_dias()
        frm.main(nit_consulta)
        frm.ShowDialog()
    End Sub
    Private Sub dtg_contratista_MouseDown(sender As Object, e As MouseEventArgs) Handles dtg_contratista.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then

            If dtg_contratista.Rows.Count > 0 Then
                With (Me.dtg_contratista)
                    Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                    If Hitest.Type = DataGridViewHitTestType.Cell Then
                        .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                        nit_consulta = Me.dtg_contratista("nit", Me.dtg_contratista.CurrentRow.Index).Value
                    End If
                End With
            End If
        End If
    End Sub
    Private Sub ConsultarDiasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConsultarDiasToolStripMenuItem.Click
        Dim frm As New Consulta_dias_per
        frm.main(nit_consulta, "S")
        frm.ShowDialog()
    End Sub
End Class