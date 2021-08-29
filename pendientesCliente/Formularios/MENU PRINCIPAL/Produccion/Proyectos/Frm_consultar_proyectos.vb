Imports logicaNegocios
Imports entidadNegocios
Public Class Frm_consultar_proyectos
    Private obj_op_simplesLn As New Op_simpesLn
    Private obj_Ing_prodLn As New Ing_prodLn
    Private objOperacionesForm As New OperacionesFormularios
    Dim usuario As UsuarioEn

    Public Sub main(ByVal usuario As UsuarioEn)
        Me.usuario = usuario
    End Sub

    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        Dim where_sql As String = ""
        If cbo_centro.SelectedValue <> 0 Then
            where_sql &= " AND p.centro =" & cbo_centro.SelectedValue
        End If
        Dim sql As String = "SELECT p.id_proyecto , p.titulo ,p.centro ,c.descripcion ,p.fec_ini,p.fec_fin ,SUM(i.ppto) As presupuesto " & _
                                "FROM j_proyectos p , j_proyectos_items i , CORSAN.dbo.centros c " &
                                    "WHERE c.centro = p.centro AND p.id_proyecto = i.id_proyecto  " & where_sql &
                                        "GROUP BY p.id_proyecto , p.titulo ,p.centro ,c.descripcion ,p.fec_ini,p.fec_fin  "
        Dim dt As DataTable = obj_op_simplesLn.listar_datatable(sql, "PRODUCCION")
        totalizarDt(dt)
        dtg_consulta.DataSource = dt
        dtg_consulta.Columns("presupuesto").DefaultCellStyle.Format = "C0"
    End Sub
    Private Function totalizarDt(ByRef dt As DataTable) As DataTable
        Dim sum As Double = 0
        dt.Rows.Add()
        For i = 0 To dt.Columns.Count - 1
            If (dt.Columns(i).ColumnName = "presupuesto") Then
                For j = 0 To dt.Rows.Count - 2
                    If Not IsDBNull(dt.Rows(j).Item(i)) Then
                        sum += dt.Rows(j).Item(i)
                    End If
                Next
                dt.Rows(dt.Rows.Count - 1).Item(i) = sum
                sum = 0
            End If
        Next
        Return dt
    End Function

    Private Sub dtg_consulta_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtg_consulta.CellClick
        If e.RowIndex >= 0 Then
            If dtg_consulta.Columns(e.ColumnIndex).Name = col_editar.Name Then
                Frm_proyectos.Show()
                Frm_proyectos.MAIN(usuario, dtg_consulta.Item("id_proyecto", e.RowIndex).Value, dtg_consulta.Item("fec_ini", e.RowIndex).Value, dtg_consulta.Item("fec_fin", e.RowIndex).Value)
            End If
        End If
    End Sub

    Private Sub Frm_consultar_proyectos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim sql As String = ""
        Dim dt As New DataTable
        sql = "SELECT centro,( CAST (centro AS varchar(25))+ '-' + descripcion )As descripcion " &
                     "FROM centros  " &
                        "WHERE centro >1099"
        dt = obj_op_simplesLn.listar_datatable(sql, "CORSAN")
        dt.Rows.Add()
        dt.Rows(dt.Rows.Count - 1).Item("centro") = 0
        dt.Rows(dt.Rows.Count - 1).Item("descripcion") = "Seleccione"
        cbo_centro.DataSource = dt
        cbo_centro.ValueMember = "centro"
        cbo_centro.DisplayMember = "descripcion"
        cbo_centro.SelectedValue = 0
    End Sub
End Class