Imports logicaNegocios
Public Class frm_defectos
    Private objOpsimpesLn As New Op_simpesLn
    Private Sub frm_defectos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim sql As String
        Dim dt As New DataTable
        Dim row As DataRow
        sql = "SELECT d.Id_defecto,d.D_defecto " &
                        " FROM J_desperdicios_defecto d , J_desperdicio_def_centro c " &
                            "WHERE d.id_defecto = c.id_defecto AND c.centro =2100 AND d.id_defecto not in (46)"
        dt = objOpsimpesLn.listar_datatable(sql, "PRODUCCION")
        row = dt.NewRow
        row("Id_defecto") = 0
        row("D_defecto") = "Seleccione"
        dt.Rows.Add(row)
        cbo_defecto.DataSource = dt
        cbo_defecto.ValueMember = "Id_defecto"
        cbo_defecto.DisplayMember = "D_defecto"
        cbo_defecto.SelectedValue = 0
    End Sub
    Public Function recibir_defecto()
        Dim defecto As Integer
        defecto = cbo_defecto.SelectedValue
        Return defecto
    End Function
    Private Sub btn_ingresar_Click(sender As Object, e As EventArgs) Handles btn_ingresar.Click
        Me.Close()
    End Sub
End Class