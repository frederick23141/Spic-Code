Imports logicaNegocios
Imports entidadNegocios
Imports accesoDatos
Public Class Frm_limite_consumo_alambron
    Dim objIngresoProdLn As New Ing_prodLn
    Private obj_Ing_prodLn As New Ing_prodLn
    Private objOperacionesForm As OperacionesFormularios = New OperacionesFormularios
    Dim nit As String
    Dim usuario As String
    Private objOpSimplesLn As New Op_simpesLn
    Private Sub Frm_limite_consumo_alambron_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargar_consulta()
    End Sub
    Public Sub main(ByVal usuario As String)
        usuario = usuario
    End Sub
    Private Sub cargar_consulta()
        Dim sql As String
        Dim dt As New DataTable
        sql = "select concat(nit_proveedor,'-',num_importacion,'-',id_solicitud_det,'-',numero_rollo) as consecutivo,nit_proveedor,num_importacion,id_solicitud_det,numero_rollo,peso,limite_consumos from J_alambron_importacion_det_rollos" & _
              " where num_transaccion is not null and num_transaccion_salida is not null"
        dt = objIngresoProdLn.listar_datatable(sql, "PRODUCCION")
        bs_alambron = New BindingSource()
        bs_alambron.DataSource = dt
        dtg_alambron_bd_2.DataSource = bs_alambron

        dtg_alambron_bd_2.Columns("nit_proveedor").Visible = False
        dtg_alambron_bd_2.Columns("num_importacion").Visible = False
        dtg_alambron_bd_2.Columns("id_solicitud_det").Visible = False
        dtg_alambron_bd_2.Columns("numero_rollo").Visible = False
        pn_limite_lecturas.Visible = False
    End Sub
    Private Sub txt_consecu_TextChanged(sender As Object, e As EventArgs) Handles txt_consecu.TextChanged
        bs_alambron.Filter = String.Format("consecutivo LIKE '{0}%'", txt_consecu.Text)
    End Sub
    Private Sub dtg_alambron_bd_2_MouseDown(sender As Object, e As MouseEventArgs) Handles dtg_alambron_bd_2.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            With (Me.dtg_alambron_bd_2)
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                End If
            End With
        End If
    End Sub
    Private Sub ModificarLimiteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ModificarLimiteToolStripMenuItem.Click
        pn_limite_lecturas.Visible = True
    End Sub
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        pn_limite_lecturas.Visible = False
    End Sub
    Private Sub btn_editar_Click(sender As Object, e As EventArgs) Handles btn_editar.Click
        If txt_limite_consumo.Text <> "" Then
            Dim nit_provedor As Integer = dtg_alambron_bd_2.Item("nit_proveedor", dtg_alambron_bd_2.CurrentCell.RowIndex).Value
            Dim num_imp As Integer = dtg_alambron_bd_2.Item("num_importacion", dtg_alambron_bd_2.CurrentCell.RowIndex).Value
            Dim id_detalle As Integer = dtg_alambron_bd_2.Item("id_solicitud_det", dtg_alambron_bd_2.CurrentCell.RowIndex).Value
            Dim num_rollo As Integer = dtg_alambron_bd_2.Item("numero_rollo", dtg_alambron_bd_2.CurrentCell.RowIndex).Value
            Dim auditoria As String = "El usuario que realizo el cambio fue:" & usuario & ""
            Dim sql = "UPDATE J_alambron_importacion_det_rollos SET limite_consumos=" & txt_limite_consumo.Text & " where nit_proveedor=" & nit_provedor & " and num_importacion=" & num_imp & "" & _
                  " and id_solicitud_det=" & id_detalle & " and numero_rollo=" & num_rollo & ""
            objOpSimplesLn.ejecutar(sql, "PRODUCCION")
            sql = "INSERT INTO J_alambron_auditoria_consumo (nit_proveedor,num_importacion,id_solicitud_det,numero_rollo,Auditoria) VALUES (" & nit_provedor & "," & num_imp & "," & id_detalle & "," & num_rollo & ",'" & auditoria & "')"
            objOpSimplesLn.ejecutar(sql, "PRODUCCION")
            MessageBox.Show("El rollo de alambron a sido actualizado", "Rollo actualizado", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txt_limite_consumo.Text = ""
            pn_limite_lecturas.Visible = False
            cargar_consulta()
        End If
    End Sub
    Private Sub btn_exportar_Click(sender As Object, e As EventArgs) Handles btn_exportar.Click
        objOperacionesForm.ExportarDatosExcel(dtg_alambron_bd_2, "Alambron")
    End Sub
End Class