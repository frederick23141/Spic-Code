Imports logicaNegocios
Imports entidadNegocios
Public Class Frm_maximos_minimos
    Private objOpSimplesLn As New Op_simpesLn
    Dim carga_comp As Boolean = False
    Private objOperacionesForm As OperacionesFormularios = New OperacionesFormularios

    Private Sub Frm_maximos_minimos_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        cboFechaFin.Value = Now
        cboFechaIni.Value = Now.AddDays(-(Now.Day - 1))
        Dim sql As String = "SELECT CAST(bodega AS varchar(25))As bodega FROM v_referencias_sto GROUP BY bodega"
        Dim dt As New DataTable
        Dim dr As DataRow

        dt = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        dr = dt.NewRow
        dr("bodega") = "TODO"
        dt.Rows.Add(dr)
        cbo_bodega.DataSource = dt
        cbo_bodega.ValueMember = "bodega"
        cbo_bodega.DisplayMember = "bodega"
        cbo_bodega.SelectedValue = "TODO"
    End Sub


    Private Sub btnActualizar_Click(sender As System.Object, e As System.EventArgs) Handles btnActualizar.Click
        img_procesar.Visible = True
        Application.DoEvents()
        cargar_consulta()
        img_procesar.Visible = False
    End Sub
    Private Sub cargar_consulta()
        Dim fecIni As String = objOpSimplesLn.cambiarFormatoFecha(cboFechaIni.Value)
        Dim fecFin As String = objOpSimplesLn.cambiarFormatoFecha(cboFechaFin.Value)
        Dim sql As String = ""
        Dim selectSql As String = "SELECT  v.bodega,v.codigo,r.descripcion,MAX (v.can_sal )As Maximo,MIN (v.can_sal )As Minimo,(SELECT stock FROM v_referencias_sto_hoy WHERE codigo = v.codigo AND v.bodega = bodega ) As stock,(SELECT can_sal FROM v_referencias_sto_hoy WHERE codigo = v.codigo AND v.bodega = bodega ) As salidas_mes_actual,(SELECT SUM(pendiente) FROM V_pendientes_por_vendedor WHERE codigo = v.codigo AND v.bodega = bodega ) As pendientes " & _
                                        "FROM v_referencias_sto v , referencias r "
        Dim whereSql As String = " WHERE r.codigo = v.codigo AND (v.ano >= " & cboFechaIni.Value.Year & " AND v.ano <= " & cboFechaFin.Value.Year & " AND v.mes>= " & cboFechaIni.Value.Month & " AND v.mes <= " & cboFechaFin.Value.Month & ") "
        Dim groupSql As String = "GROUP BY v.codigo,r.descripcion ,v.bodega"
        Dim dt As New DataTable
        If (txt_codigo.Text <> "") Then
            whereSql &= "AND v.codigo like '" & txt_codigo.Text & "%' "
        End If
        If (cbo_bodega.Text <> "TODO") Then
            whereSql &= "AND v.bodega = " & cbo_bodega.Text & " "
        End If
        sql = selectSql & whereSql & groupSql
        dt = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        dt.Columns.Add("sugerido_compra", GetType(Double))
        sugerido_compra(dt)
        If (chkOcult.Checked) Then
            ocultarCeros(dt)
        End If
        dtgConsulta.DataSource = dt
        dtgConsulta.Columns("Maximo").HeaderText = "Máximo"
        marcar_stock_menor_a_sugerido()
    End Sub
    Private Sub sugerido_compra(ByRef dt As DataTable)
        For i = 0 To dt.Rows.Count - 1
            If (Not IsDBNull(dt.Rows(i).Item("Maximo")) And Not IsDBNull(dt.Rows(i).Item("Minimo"))) Then
                dt.Rows(i).Item("sugerido_compra") = ((dt.Rows(i).Item("Maximo") + dt.Rows(i).Item("Minimo")) / 2) * 1.1
            End If
        Next
    End Sub
    Private Sub ocultarCeros(ByRef dt As DataTable)
        For i = 0 To dt.Rows.Count - 1
            If (dt.Rows(i).Item("Maximo") = 0 And dt.Rows(i).Item("Minimo") = 0 And dt.Rows(i).Item("stock") = 0) Then
                dt.Rows(i).Delete()
            End If
        Next
    End Sub
    Private Sub chk_todo_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chk_todo_cod.CheckedChanged
        If (chk_todo_cod.Checked) Then
            txt_codigo.Text = ""
        End If
    End Sub
    Private Sub marcar_stock_menor_a_sugerido()
        For i = 0 To dtgConsulta.RowCount - 1
            If (dtgConsulta.Item("stock", i).Value < dtgConsulta.Item("sugerido_compra", i).Value) Then
                dtgConsulta.Rows(i).DefaultCellStyle.BackColor = Color.Red
            End If
        Next
    End Sub
   Private Sub btnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Click
        objOperacionesForm.ExportarDatosExcel(dtgConsulta, "Informe de máximos y minimos")
    End Sub
End Class