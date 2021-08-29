Imports logicaNegocios
Imports Microsoft.VisualBasic.PowerPacks.Printing.Compatibility.VB6
Imports System.Drawing.Printing
Public Class Frm_codigos_terminado
    Private objOpSimplsLn As New Op_simpesLn
    Dim carga_comp As Boolean = False
    Dim filaSelect As Integer = 0
    Dim frm As Frm_generar_tiquetes_terminado
    Public Sub Main(ByVal frm As Frm_generar_tiquetes_terminado)
        Me.frm = frm
        cargarCodigos(txtCodigo.Text, txtDesc.Text)
        txtCodigo.Focus()
    End Sub

    Private Sub dtgCodigo_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgCodigo.CellClick
        If (e.RowIndex >= 0) Then
            Dim codigo As String = dtgCodigo.Item("codigo", e.RowIndex).Value
            Dim descripcion As String = dtgCodigo.Item("descripcion", e.RowIndex).Value
            frm.txtCodigo.Text = codigo
            frm.txtDesc.Text = descripcion
            frm.txt_cant_empaque.Focus()
            Me.Close()
        End If
    End Sub
    Private Sub txtDesc_TextChanged(sender As Object, e As EventArgs) Handles txtDesc.TextChanged
        cargarCodigos(txtCodigo.Text, txtDesc.Text)
    End Sub

    Private Sub txtCodigo_TextChanged(sender As Object, e As EventArgs) Handles txtCodigo.TextChanged
        cargarCodigos(txtCodigo.Text, txtDesc.Text)
    End Sub
    Private Sub cargarCodigos(ByVal codigo As String, ByVal descripcion As String)
        Dim where_sql As String = ""
        Dim sql As String
        If codigo = "" And descripcion = "" Then
            sql = "SELECT codigo,descripcion FROM referencias WHERE codigo like '3T%' OR codigo like '3W%'"
        Else
            If (codigo <> "") Then
                where_sql &= " codigo like '" & codigo & "%' "
            ElseIf (descripcion <> "") Then
                If codigo = "" Then
                    where_sql &= " descripcion like '%" & descripcion & "%'"
                Else
                    where_sql &= " AND descripcion like '%" & descripcion & "%'"
                End If
            End If
            sql = "SELECT codigo,descripcion FROM referencias WHERE (codigo like '3T%' OR codigo like '3W%') AND " & where_sql & ""
        End If
        Dim dt As DataTable = objOpSimplsLn.listar_datatable(sql, "CORSAN")
        Dim tamano_letra As Single = 12.0!
        dtgCodigo.DataSource = dt
        dtgCodigo.Columns("codigo").ReadOnly = True
        dtgCodigo.Columns("descripcion").ReadOnly = True
    End Sub

End Class