Imports logicaNegocios
Public Class Frm_gestionar_tendencias
    Private objOpSimplesLn As New Op_simpesLn
    Private objIngresoProdLn As New Ing_prodLn
    Private objOperacionesForm As OperacionesFormularios = New OperacionesFormularios
    Private carga_comp As Boolean = False
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
    Private Sub cargarConsulta()
        Dim sql As String = ""
        Dim selectSql As String = " SELECT  A.id_tendencia,A.fecha_tend,A.nit,T.nombres ,A.fecha_ini,A.fecha_fin,A.notas " & _
                                     "FROM C_analisis_tend A , CORSAN.dbo.terceros T "
        Dim whereSql As String = "WHERE T.nit = A.nit  "
        If (txtNit.Text <> "") Then
            whereSql &= "AND T.nit like '" & txtNit.Text & "%'"
        ElseIf (txtNombres.Text <> "") Then
            whereSql &= "AND T.nombres like '%" & txtNombres.Text & "%'"
        End If
        sql = selectSql & whereSql
        dtgConsulta.DataSource = objIngresoProdLn.listar_datatable(sql, "PRODUCCION")
    End Sub
    Private Sub dtgConsulta_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgConsulta.CellContentClick
        Dim col As String = dtgConsulta.Columns(e.ColumnIndex).Name
        Dim id As Integer = 0
        id = dtgConsulta.Item("id_tendencia", e.RowIndex).Value
        If (col = col_ver.Name) Then
            Dim frm As New Frm_graficar_evaluaciones
            frm.Show()
            frm.cargarGrafico(id)
        ElseIf (col = colBorrar.Name) Then
            Dim resp As Integer
            resp = MessageBox.Show("Esta seguro de eliminar este registro? ", "Quitar", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
            If (resp = 6) Then
                Dim eliminoCorrecto As Boolean = False
                Dim sql As String = "DELETE FROM C_analisis_tend WHERE id_tendencia = " & id
                eliminoCorrecto = objIngresoProdLn.ejecutar(sql, "PRODUCCION")
                If (eliminoCorrecto) Then
                    MessageBox.Show("La tendencia fue eliminada en forma exitosa! ", "Correcto!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    cargarConsulta()
                Else
                    MessageBox.Show("Error al eliminar la tendencia comuniquese con el administrador del sistema ", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        End If
    End Sub

    Private Sub txtNit_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNit.TextChanged
        If (txtNit.Text.Trim.Length > 2) Then
            carga_comp = False
            txtNombres.Text = ""
            cargarConsulta()
            carga_comp = True
        End If
    End Sub

    Private Sub txtNombres_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNombres.TextChanged
        If (txtNombres.Text.Trim.Length > 3) Then
            carga_comp = False
            cargarConsulta()
            txtNit.Text = ""
            carga_comp = True
        End If
    End Sub
End Class