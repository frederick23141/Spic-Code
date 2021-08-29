Imports logicaNegocios
Public Class frm_Ing_Tornilleria_Trans
    Private objOpSimplesLn As New Op_simpesLn
    Private Sub Frm_Ing_Tornilleria_Trans_Load(sender As Object, e As EventArgs)
        cargar_cbo()
        cargar_inventario()
    End Sub
    Private Sub cargar_cbo()
        Dim dt As DataTable
        Dim row As DataRow
        Dim sql As String = "select codigo,descripcion from referencias where codigo like '2r%' and ref_anulada = 'N'"
        dt = New DataTable
        dt = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        row = dt.NewRow
        row("codigo") = 0
        row("codigo") = "Seleccione"
        dt.Rows.Add(row)
        cbo_Codigo_Ent.DataSource = dt
        cbo_Codigo_Ent.ValueMember = "codigo"
        cbo_Codigo_Ent.DisplayMember = "codigo"
        cbo_Codigo_Ent.Text = "Seleccione"
        cbo_Codigo_Ent.SelectedValue = 0


        sql = "select codigo,descripcion from referencias where codigo like '2t%' and ref_anulada = 'N'"
        dt = New DataTable
        dt = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        row = dt.NewRow
        row("codigo") = 0
        row("codigo") = "Seleccione"
        dt.Rows.Add(row)
        cbo_Codigo_Sal.DataSource = dt
        cbo_Codigo_Sal.ValueMember = "codigo"
        cbo_Codigo_Sal.DisplayMember = "codigo"
        cbo_Codigo_Sal.Text = "Seleccione"
        cbo_Codigo_Sal.SelectedValue = 0
    End Sub
    Private Sub cargar_inventario()
        Dim sql As String
        sql = " SELECT g.Descripcion as linea_de_produccion, s.bodega,s.codigo,r.descripcion,s.can_ini,s.can_ent ,s.can_sal,((s.can_ini+s.can_ent)-(s.can_sal))As stock,cos_ini,cos_ent,cos_sal,((s.cos_ini+s.cos_ent) -s.cos_sal)As costo_stock , s.mes,s.ano " &
             " FROM referencias_sto s , referencias r ,JJV_Grupos_seguimiento g WHERE r.codigo = s.codigo AND mes = " & Now.Month & " AND ano = " & Now.Year & "   AND g.Id_cor = r.Id_cor  AND s.codigo like'2R%' AND s.bodega = 2 ORDER BY g.Descripcion"
        dtg_Trans_Entrada.DataSource = objOpSimplesLn.listar_datatable(sql, "CORSAN")
    End Sub
    Private Sub Btn_Realizar_Transaccion_En_Click(sender As Object, e As EventArgs) Handles btn_Realizar_Transaccion_En.Click

    End Sub

    Private Sub Btn_Realizar_Transaccion_Sal_Click(sender As Object, e As EventArgs) Handles btn_Realizar_Transaccion_Sal.Click

    End Sub
End Class