Imports logicaNegocios
Imports entidadNegocios

Public Class frm_manuales_spic
    Private objOpSimplesLn As New Op_simpesLn
    Private obj_Ing_prodLn As New Ing_prodLn
    Public Sub main(ByVal usuario As UsuarioEn)
        If usuario.permiso.Trim = "ADMIN" Then
            btn_nuevo.Enabled = True
        Else
            btn_nuevo.Enabled = False
        End If
    End Sub
    Private Sub frm_manuales_spic_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargar_man()
    End Sub
    Public Sub cargar_man()
        Dim sql As String = "SELECT id_man AS '#',nombre,direccion FROM JB_manuales_dir WHERE area = 1"
        dtg_produccion.DataSource = objOpSimplesLn.listar_datatable(sql, "CORSAN")
    End Sub

    Private Sub dtg_produccion_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtg_produccion.CellClick
        If (e.RowIndex >= 0) Then
            Dim col As String = dtg_produccion.Columns(e.ColumnIndex).Name
            If col = col_pdf.Name Then
                Dim proc As New Process
                proc.StartInfo.FileName = dtg_produccion.Item("direccion", e.RowIndex).Value
                proc.Start()
            End If
        End If
    End Sub

    Private Sub btn_nuevo_Click(sender As Object, e As EventArgs) Handles btn_nuevo.Click
        Dim sql As String = "SELECT MAX(id_man) FROM JB_manuales_dir"
        Dim numero As Integer = obj_Ing_prodLn.consultar_valor(sql, "CORSAN") + 1
        Dim frm As New frm_ag_manual
        frm.MAIN(numero)
        frm.ShowDialog()
    End Sub

    Private Sub btn_act_Click(sender As Object, e As EventArgs) Handles btn_act.Click
        cargar_man()
    End Sub
End Class