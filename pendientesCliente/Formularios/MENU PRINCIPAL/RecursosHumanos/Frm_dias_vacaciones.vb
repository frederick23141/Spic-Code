Imports logicaNegocios
Public Class Frm_dias_vacaciones

    Private objOpSimplesLn As New Op_simpesLn
    Private obj_Ing_prodLn As New Ing_prodLn
    Private cargaComp As Boolean = False
    Private objOperacionesForm As New OperacionesFormularios
   
  
    Private Sub FrmConsultTransacDms_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dt As New DataTable
        Dim dr As DataRow
        Dim sql As String = "SELECT CAST(centro AS varchar(25)) As centro,CAST(centro AS varchar(25)) + '-' + descripcion As descripcion " & _
                               "FROM V_nom_personal_Activo_con_maquila " & _
                                   "GROUP BY centro,descripcion "
        dt = obj_Ing_prodLn.listar_datatable(sql, "CORSAN")
        dr = dt.NewRow
        dr("centro") = "TODO"
        dr("descripcion") = "TODO"
        dt.Rows.Add(dr)
        cboCentro.DataSource = dt
        cboCentro.ValueMember = "centro"
        cboCentro.DisplayMember = "descripcion"
        cboCentro.SelectedValue = "TODO"
        cbo_fecha.Value = Now
        cargaComp = True
    End Sub
    Private Sub btnActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActualizar.Click
        imgProcesar.Visible = True
        Application.DoEvents()
        cargarCosulta()
        imgProcesar.Visible = False
    End Sub
    Private Sub cargarCosulta()
        cargaComp = False
        Dim fec As String = objOpSimplesLn.cambiarFormatoFecha(cbo_fecha.Value)
        Dim selectSql As String = "SELECT p.nit,p.nombres,p.fecha_ingreso,DATEDIFF (MONTH ,fecha_ingreso,'" & fec & "')As antiguedad,DATEDIFF (MONTH ,fecha_ingreso,'" & fec & "')* 1.25 As dias_ganados_vac,p.centro,p.descripcion,p.Cargo, " & _
                                    "(SELECT SUM (dias_vac_pag )As dias_pag_vac FROM Jjv_dias_pag_vac WHERE nit = p.nit)As dias_pag_vac,((DATEDIFF (MONTH ,fecha_ingreso,'" & fec & "')* 1.25 )-((SELECT (SELECT CASE WHEN (SUM (dias_vac_pag ))is null THEN 0 ELSE SUM (dias_vac_pag ) END  FROM Jjv_dias_pag_vac WHERE nit = p.nit))+(SELECT (SELECT CASE WHEN( SUM (horas_vac_acum))is not null THEN SUM (horas_vac_acum) ELSE 0 END)  FROM Jjv_dias_vac_acum_ant where nit = p.nit )))As dias_debe " & _
                                        "FROM V_nom_personal_Activo_con_maquila p  "

        Dim whereSql As String = ""
        Dim order_sql As String = "ORDER BY p.nombres"
        Dim sql As String = ""
        Dim dt As DataTable
        If (txt_empleado.Text <> "") Then
            whereSql = "WHERE p.nit = " & txt_empleado.Text
        ElseIf (cboCentro.SelectedValue <> "TODO") Then
            whereSql = "WHERE p.centro = " & cboCentro.SelectedValue
        End If
        sql = selectSql & whereSql & order_sql
        dt = obj_Ing_prodLn.listar_datatable(sql, "CORSAN")
        dtg_consulta.DataSource = dt
        dtg_consulta.Columns("fecha_ingreso").DefaultCellStyle.Format = "d"
        cargaComp = True
    End Sub

    Private Sub btn_excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_excel.Click
        objOperacionesForm.ExportarDatosExcel(dtg_consulta, "Días vacaciones")
    End Sub
    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        FrmPrincipal.Show()
        Me.Close()
        FrmPrincipal.Activate()
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        FrmLogin.Show()
        FrmPrincipal.Close()
        Me.Close()
    End Sub
    Private Sub txt_empleado_MouseClick(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles txt_empleado.MouseClick
        txt_empleado.Text = ""
        groupCliente.Visible = True
        txt_nombres.Focus()
    End Sub
    Private Sub dtg_clientes_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtg_clientes.CellContentClick
        If (e.RowIndex >= 0) Then
            If (dtg_clientes.Columns(e.ColumnIndex).Name = colOk.Name) Then
                txt_empleado.Text = ""
                txt_empleado.Text = dtg_clientes.Item("nit", e.RowIndex).Value
                groupCliente.Visible = False
                dtg_clientes.DataSource = Nothing
                txt_nit.Text = ""
                txt_nombres.Text = ""
            End If
        End If
    End Sub
    Private Sub txt_nit_TextChanged(sender As System.Object, e As System.EventArgs) Handles txt_nit.TextChanged
        cargaComp = False
        txt_nombres.Text = ""
        cargaComp = True
        If (cargaComp And txt_nit.Text.Length > 2) Then
            cargar_empleados()
        End If
    End Sub
    Private Sub txt_nombres_TextChanged(sender As System.Object, e As System.EventArgs) Handles txt_nombres.TextChanged
        cargaComp = False
        txt_nit.Text = ""
        cargaComp = True
        If (cargaComp And txt_nombres.Text.Length > 3) Then
            cargar_empleados()
        End If
    End Sub
    Private Sub cargar_empleados()
        Dim sql As String = "Select nit,nombres,ciudad FROM V_nom_personal_Activo_con_maquila "
        Dim whereSql As String = "WHERE  "
        If (txt_nit.Text <> "") Then
            whereSql &= " nit like '" & txt_nit.Text & "%'"
        ElseIf (txt_nombres.Text <> "") Then
            whereSql &= " nombres like '%" & txt_nombres.Text & "%'"
        End If
        sql &= whereSql
        dtg_clientes.DataSource = objOpSimplesLn.listar_datatable(sql, "CORSAN")
    End Sub
    Private Sub btn_cerrar_Click(sender As System.Object, e As System.EventArgs) Handles btn_cerrar.Click
        txt_nit.Text = ""
        txt_nombres.Text = ""
        dtg_clientes.DataSource = Nothing
        groupCliente.Visible = False
    End Sub
End Class