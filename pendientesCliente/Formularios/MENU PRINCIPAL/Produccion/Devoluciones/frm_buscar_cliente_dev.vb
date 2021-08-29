Imports logicaNegocios
Imports entidadNegocios
Public Class frm_buscar_cliente_dev
    Private objOpSimplesLn As New Op_simpesLn
    Public Sub main()
        Me.ShowDialog()
        dtg_cliente.DataSource = Nothing
        txt_nit.Text = ""
        txt_nombre.Focus()
        txt_nombre.Text = ""
    End Sub

    Private Sub consultar_cliente(ByVal nit As String, ByVal nombre As String)
        Dim sql As String = "SELECT nit,nombres FROM terceros WHERE "
        If nit <> "" Then
            sql &= " nit LIKE '" & nit & "%'"
        Else
            sql &= " nombres LIKE '%" & nombre & "%'"
        End If
        dtg_cliente.DataSource = objOpSimplesLn.listar_datatable(sql, "CORSAN")
    End Sub

    Private Sub txt_nombre_TextChanged(sender As Object, e As EventArgs) Handles txt_nombre.TextChanged
        If (txt_nombre.Text.Length > 3) Then
            consultar_cliente("", txt_nombre.Text)
        End If
    End Sub

    Private Sub txt_nit_TextChanged(sender As Object, e As EventArgs) Handles txt_nit.TextChanged
        If (txt_nit.Text.Length > 3) Then
            consultar_cliente(txt_nit.Text, "")
        End If
    End Sub

    Private Sub dtg_cliente_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtg_cliente.CellClick
        If (e.RowIndex >= 0) Then
            Dim col As String = dtg_cliente.Columns(e.ColumnIndex).Name
            If (col = col_selec.Name) Then
                frm_imp_tiq_dev.recibir_cliente(dtg_cliente.Item("nit", e.RowIndex).Value, dtg_cliente.Item("nombres", e.RowIndex).Value)
                Me.Close()
            End If
        End If
    End Sub
End Class