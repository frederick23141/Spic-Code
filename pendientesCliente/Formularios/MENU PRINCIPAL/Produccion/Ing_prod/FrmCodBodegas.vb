Imports logicaNegocios
Public Class FrmCodBodebas
    Private objOpSimplesLn As New Op_simpesLn
    Private bod As String
    Private tipo As String
    Public Sub main(ByVal bod As String, ByVal tipo As String)
        Me.bod = bod
        Me.tipo = tipo
        If (bod = "1") Then
            cargar()
        End If
    End Sub
    Public Sub cargar()
        Dim strSql As String = "SELECT codigo,descripcion FROM referencias "
        Dim whereSql As String = "WHERE ref_anulada <> 'S' AND "
        Dim whereBod As String = " "
        Dim valor As String = ""
        If (txtCodigo.Text <> "") Then
            valor = txtCodigo.Text
            whereSql += "codigo like '" & valor & "%' "
        ElseIf (txtDesc.Text <> "") Then
            valor = txtDesc.Text
            whereSql += "descripcion like '" & valor & "%' "
        End If
        If (bod = "1") Then
            whereBod = "codigo like'1%'"
        ElseIf (bod = "2,3") Then
            whereBod = "(codigo like'22B%' or codigo like '33B%' or codigo like '22X%' or codigo like '33X%')"
        End If
        If txtCodigo.Text <> "" Or txtDesc.Text <> "" Then
            strSql = strSql & whereSql
        Else
            strSql = strSql & whereSql & whereBod
        End If
        dtgConsulta.DataSource = objOpSimplesLn.listar_datatable(strSql, "CORSAN")

    End Sub
    Private Sub txtCodigo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodigo.TextChanged
        txtDesc.Text = ""
        If (txtCodigo.Text.Length >= 3) Then
            cargar()
        End If
    End Sub

    Private Sub txtDesc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDesc.TextChanged
        txtCodigo.Text = ""
        If (txtDesc.Text.Length >= 3) Then
            cargar()
        End If
    End Sub

    Private Sub dtgConsulta_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgConsulta.CellContentClick
        Dim fila As Integer = e.RowIndex
        Dim col As String = dtgConsulta.Columns(e.ColumnIndex).Name
        If (fila >= 0) Then
            If (col = "btnSeleccion") Then
                If (tipo = "MP") Then
                    FrmOrdenProdTef.txtMatPrima.Text = dtgConsulta.Item("codigo", fila).Value
                ElseIf (tipo = "PF") Then
                    FrmOrdenProdTef.txtProdFinal.Text = dtgConsulta.Item("codigo", fila).Value
                ElseIf (tipo = "AL") Then
                    FrmOrdenProdTef.txt_cod_alambron.Text = dtgConsulta.Item("codigo", fila).Value
                ElseIf (tipo = "REC") Then
                    Frm_ing_recocido.txtCodigos.Text = dtgConsulta.Item("codigo", fila).Value
                End If

                Me.Close()
            End If
        End If
    End Sub
End Class