Imports accesoDatos
Imports entidadNegocios
Imports Spic
Public Class frm_seleccion_rollos_galv
    Private dt As New DataTable
    Dim codigo As String
    Dim codigore As String
    Dim cargar As Boolean
    Dim frm As FrmOrdenProdGalv
    Public Sub main(ByVal codigo As String, ByVal res As FrmOrdenProdGalv)
        codigore = codigo
        frm = res
    End Sub
    Private Sub frm_seleccion_rollos_galv_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtcodigo_rollo.Text = codigore
        mostrar()
        cargar = True
    End Sub
    Private Sub mostrar()
        Try
            Dim func As New galvanizadoAd
            dt = func.mostrar
            If dt.Rows.Count <> 0 Then
                dtg_Consulta.DataSource = dt
                dtg_Consulta.ColumnHeadersVisible = True
            Else
                dtg_Consulta.DataSource = Nothing
                dtg_Consulta.ColumnHeadersVisible = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub txtcodigo_rollo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcodigo_rollo.TextChanged
        Try
            If cargar = True Then
                Dim ds As New DataSet
                ds.Tables.Add(dt.Copy)

                Dim dv As New DataView(ds.Tables(0))

                dv.RowFilter = " codigo like '" & txtcodigo_rollo.Text & "%'"

                If dv.Count <> 0 Then
                    dtg_Consulta.DataSource = dv
                Else

                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub dtg_Consulta_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtg_Consulta.CellContentClick
        Dim fila As Integer = e.RowIndex
        Dim col As String = dtg_Consulta.Columns(e.ColumnIndex).Name
        If (fila >= 0) Then
            If (col = "btnSeleccion") Then
                codigo = dtg_Consulta.Item("codigo", fila).Value()
                frm.d_codigo(codigo)
            End If
            Me.Close()
        End If
    End Sub

    Private Sub dtg_Consulta_CurrentCellDirtyStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtg_Consulta.CurrentCellDirtyStateChanged
        If dtg_Consulta.IsCurrentCellDirty Then
            dtg_Consulta.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub
End Class