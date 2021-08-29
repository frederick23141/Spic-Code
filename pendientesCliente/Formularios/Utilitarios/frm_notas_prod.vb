Imports logicaNegocios
Imports entidadNegocios
Public Class frm_notas_prod
    Dim numero As Integer
    Dim form As Frm_super_modulo_consult_pendientes
    Private objOpSimplesLn As New Op_simpesLn
    Sub main(ByVal nuemro As Integer, ByVal formu As Frm_super_modulo_consult_pendientes)
        numero = nuemro
        form = formu
    End Sub
    Private Sub frm_notas_prod_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtg_nota.DataSource = objOpSimplesLn.listar_datatable("Select numero,codigo,descripcion,nota_prod,Id_ref from J_v_pendientes_por_vendedor_id_cor where numero=" & numero & "", "CORSAN")
        dtg_nota.Columns("Id_ref").Visible = False
    End Sub
    Private Sub IngresarNotaProdToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IngresarNotaProdToolStripMenuItem.Click
        Dim numero As Integer = dtg_nota.Item("numero", dtg_nota.CurrentCell.RowIndex).Value
        Dim id_ref As Integer = dtg_nota.Item("Id_ref", dtg_nota.CurrentCell.RowIndex).Value
        Dim resp As Boolean = False
        Dim sql As String
        Dim formul As New Ingresar_modif_notasprod
        Dim valor As String
        sql = "select nota_prod from documentos_lin_ped where numero=" & numero & " and Id=" & id_ref & ""
        valor = objOpSimplesLn.consultValorTodo(sql, "CORSAN")
        If valor <> "" Then
            resp = True
        End If
        If resp = True Then
            Dim result As MsgBoxResult
            result = MessageBox.Show("Desea modificar la nota de producción", "Modificar nota de producción", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
            If result = MsgBoxResult.Yes Then
                formul.main(form, numero, id_ref, resp)
                formul.Show()
            Else
                Exit Sub
            End If
        Else
            formul.main(form, numero, id_ref, resp)
            formul.Show()
        End If
        Me.Close()
    End Sub
End Class