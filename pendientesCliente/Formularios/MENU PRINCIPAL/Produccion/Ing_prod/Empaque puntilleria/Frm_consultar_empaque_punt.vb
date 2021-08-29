Imports logicaNegocios
Imports System.Windows.Forms.DataVisualization.Charting

Public Class Frm_consultar_empaque_punt
    Private obj_Ing_prodLn As New Ing_prodLn
    Private objOpercionesForm As New OperacionesFormularios
    Dim carga_completa As Boolean = False
    Private objOperacionesForm As New OperacionesFormularios
    Dim ano As Integer = Now.Year
    Dim maquina_paro As String = 0
    Dim objOpSimplesLn As New Op_simpesLn
    Dim tot_cartones As Double = 0
    Private Sub Frm_consultar_empaque_punt_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cbo_fecha_ini.Value = Now.AddDays(-Now.Day + 1)
        cbo_fecha_fin.Value = Now
        Dim sql As String
        Dim dt As DataTable

        sql = "Select nit,nombres  from V_nom_personal_Activo_con_maquila WHERE centro = 2400 ORDER BY nombres "
        dt = obj_Ing_prodLn.listar_datatable(sql, "CORSAN")
        dt.Rows.Add()
        dt.Rows(dt.Rows.Count - 1).Item("nit") = 900029909
        dt.Rows(dt.Rows.Count - 1).Item("nombres") = "EMPAQUES Y CONTENIDOS S.A"
        dt.Rows.Add()
        dt.Rows(dt.Rows.Count - 1).Item("nit") = 811001365
        dt.Rows(dt.Rows.Count - 1).Item("nombres") = "COLPACK  S.A.S"
        dt.Rows.Add()
        dt.Rows(dt.Rows.Count - 1).Item("nit") = 900505976
        dt.Rows(dt.Rows.Count - 1).Item("nombres") = "APL SERVICIOS"
        dt.Rows.Add()
        dt.Rows(dt.Rows.Count - 1).Item("nit") = 900338739
        dt.Rows(dt.Rows.Count - 1).Item("nombres") = "DECORMAQUILAS S.A.S"
        dt.Rows.Add()
        dt.Rows(dt.Rows.Count - 1).Item("nit") = 32512279
        dt.Rows(dt.Rows.Count - 1).Item("nombres") = "ACCESORIOS Y PRODUCTOS A Y P"
        dt.Rows.Add()
        dt.Rows(dt.Rows.Count - 1).Item("nit") = 0
        dt.Rows(dt.Rows.Count - 1).Item("nombres") = "TODO"
        cbo_operario.DataSource = dt
        cbo_operario.ValueMember = "nit"
        cbo_operario.DisplayMember = "nombres"
        cbo_operario.SelectedValue = 0
        carga_completa = True
    End Sub

    Private Sub PrincipalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FrmPrincipal.Show()
        FrmPrincipal.Activate()
        Me.Close()
    End Sub
    Private Sub SalirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FrmLogin.Show()
        FrmPrincipal.Close()
        FrmLogin.Activate()
        Me.Close()
    End Sub

    Private Sub ExportarAExcelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        objOpercionesForm.ExportarDatosExcel(dtg_consulta, "Pùas")
    End Sub

    Private Sub actualizar()
        If (carga_completa) Then
            imgProcesar.Visible = True
            cargar_consulta()
            imgProcesar.Visible = False
        End If
    End Sub
    Private Sub btn_excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_excel.Click
        objOperacionesForm.ExportarDatosExcel(dtg_consulta, "Empaque de puntilleria")
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
    Private Sub EliminarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EliminarToolStripMenuItem.Click
        Dim pos As Integer = dtg_consulta.CurrentCell.RowIndex
        If (pos <> dtg_consulta.RowCount - 1) Then
            Dim id = dtg_consulta("id_empaque", pos).Value
            Dim sql As String = "UPDATE J_ing_emp_punt_enc SET anulado = 's'WHERE id_empaque = " & id
            If (obj_Ing_prodLn.ejecutar(sql, "PRODUCCION") >= 1) Then
                dtg_consulta.CurrentCell = Nothing
                dtg_consulta.Rows(pos).Visible = False
            Else
                MessageBox.Show("Error al eliminar el registro, verifique que no sea una celda en blanco! ", "Campos", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub
    Public Sub cargar_consulta()
        dtg_consulta.DataSource = Nothing
        Dim tamano_letra As Single = 9.0!
        Dim fec_ini As String = objOpSimplesLn.cambiarFormatoFecha(cbo_fecha_ini.Value.Date)
        Dim fec_fin As String = objOpSimplesLn.cambiarFormatoFecha(cbo_fecha_fin.Value.Date)
        Dim dt As New DataTable
        Dim nit As Double = cbo_operario.SelectedValue
        Dim sql As String = ""
        Dim where_sql As String = "WHERE anulado is null "
        Dim select_sql As String = "SELECT "
        Dim from_sql As String = "FROM J_v_empaque_puntilleria v "
        Dim group_sql As String = "GROUP BY "
        Dim datos_efic As String = ",SUM(cantidad)As cantidad,SUM(cartones)As cartones,SUM(esperado) As esperado,SUM(kilos) As kilos ,(SELECT CASE WHEN SUM(esperado) =0 THEN 0 ELSE (SUM(cartones)/SUM(esperado))*100 END) As Efic  "
        If txt_transaccion.Text <> "" Then
            where_sql &= "AND num_transaccion = " & txt_transaccion.Text & " "
        Else
            If chk_fec_transaccion.Checked Then
                where_sql &= " AND fec_transaccion >='" & fec_ini & "' AND fec_transaccion <= '" & fec_fin & "' "
            Else
                where_sql &= " AND fecha >='" & fec_ini & "' AND fecha <= '" & fec_fin & "' "
            End If

            If (cbo_operario.SelectedValue <> 0) Then
                where_sql &= " AND "
                where_sql &= "nit = " & cbo_operario.SelectedValue & " "
                menStripDtg.Enabled = True
            End If
            If (chk_granel.Checked) Then
                where_sql &= "AND granel =0 "
            End If
            If (chk_excluir_arandela.Checked) Then
                where_sql &= "AND codigo not like '3pt%' "
            End If
            If (chk_excluir_grapa.Checked) Then
                where_sql &= "AND codigo not like '3g%' "
            End If
            If (chk_excluir_empaques_contenidos.Checked) Then
                where_sql &= "AND nit not in  (900029909,811001365,900505976,900338739) "
            End If
            If (chk_consol_dia.Checked) Then
                If (group_sql <> "GROUP BY ") Then
                    group_sql &= ","
                End If
                If (select_sql <> "SELECT ") Then
                    select_sql &= ","
                End If
                If chk_fec_transaccion.Checked Then
                    group_sql &= "fec_transaccion "
                    select_sql &= "fec_transaccion "
                Else
                    group_sql &= "fecha "
                    select_sql &= "fecha "
                End If
               
            End If
            If (chk_consol_op.Checked) Then
                If (group_sql <> "GROUP BY ") Then
                    group_sql &= ","
                End If
                If (select_sql <> "SELECT ") Then
                    select_sql &= ","
                End If
                group_sql &= "nit,nombres,mes, ano  "
                select_sql &= "mes, ano ,nit,nombres,(SELECT        SUM(valor) AS valor " & _
                               "FROM  CORSAN.dbo.y_liquidacion AS yl " & _
                               "WHERE (nit = v.nit) AND (mes = v.mes) AND (ano = v.ano) AND (concepto IN (1, 2, 17, 13, 14, 15, 16, 31, 32, 33)))*1.45 AS salario "
            End If
            If (chk_consol_ref.Checked) Then
                If (group_sql <> "GROUP BY ") Then
                    group_sql &= ","
                End If
                If (select_sql <> "SELECT ") Then
                    select_sql &= ","
                End If
                group_sql &= "codigo,descripcion "
                select_sql &= "codigo,descripcion "
            End If
            If (chk_turno.Checked) Then
                If (group_sql <> "GROUP BY ") Then
                    group_sql &= ","
                End If
                If (select_sql <> "SELECT ") Then
                    select_sql &= ","
                End If
                group_sql &= "turno "
                select_sql &= "turno "
            End If
        End If
        If select_sql = "SELECT " Then
            If (group_sql <> "GROUP BY ") Then
                group_sql &= ","
            End If
            select_sql &= "id_empaque,num_transaccion,fec_transaccion,fecha,nit,nombres,codigo,descripcion,turno,granel "
            group_sql &= "id_empaque,num_transaccion,fec_transaccion,fecha,nit,nombres,codigo,descripcion,turno,granel  "
        End If
        select_sql &= datos_efic
        sql = select_sql & from_sql & where_sql & group_sql
        dt = obj_Ing_prodLn.listar_datatable(sql, "PRODUCCION")
        dt.Rows.Add()
        totalizarDt(dt)
        dtg_consulta.DataSource = dt
        porc_participacion(dt)
        dtg_consulta.Rows(dtg_consulta.Rows.Count - 1).DefaultCellStyle = objOperacionesForm.formatoNegrita(tamano_letra)
        For i = 0 To dtg_consulta.Columns.Count - 1
            If (dtg_consulta.Columns(i).Name = "fecha" Or dtg_consulta.Columns(i).Name = "fec_transaccion") Then
                dtg_consulta.Columns(i).DefaultCellStyle.Format = "d"
            ElseIf (dtg_consulta.Columns(i).Name = "Efic") Then
                dtg_consulta.Columns(i).DefaultCellStyle.Format = "N2"
            ElseIf (dtg_consulta.Columns(i).Name = "nit") Then
                dtg_consulta.Columns(i).DefaultCellStyle.Format = "N0"
            End If
        Next
        Dim sql_prom_dia As String = "SELECT (CAST(AVG(CAST(cartones AS decimal(18, 2))) AS decimal(18, 2))) As cartones  FROM J_v_empaque_puntilleria " & where_sql & " GROUP BY fecha"
        Dim sql_emp_contenidos As String = "SELECT SUM(cartones) FROM J_v_empaque_puntilleria " & where_sql & " AND nit =  900029909 "
        Dim sql_colpack As String = "SELECT SUM(cartones) FROM J_v_empaque_puntilleria " & where_sql & " AND nit =  811001365 "
        Dim sql_apl As String = "SELECT SUM(cartones) FROM J_v_empaque_puntilleria " & where_sql & " AND nit =900505976"
        Dim sql_decor As String = "SELECT SUM(cartones) FROM J_v_empaque_puntilleria " & where_sql & " AND nit =900338739"
        Dim prom_dia As Double = 0
        Dim emp_contenido As Double = obj_Ing_prodLn.consultar_valor(sql_emp_contenidos, "PRODUCCION")
        Dim colpack As Double = obj_Ing_prodLn.consultar_valor(sql_colpack, "PRODUCCION")
        Dim apl As Double = obj_Ing_prodLn.consultar_valor(sql_apl, "PRODUCCION")
        Dim decor As Double = obj_Ing_prodLn.consultar_valor(sql_decor, "PRODUCCION")
        Dim dt_prom_dia As DataTable = objOpSimplesLn.listar_datatable(sql_prom_dia, "PRODUCCION")
        Dim sum_prom_dia As Double = 0
        For i = 0 To dt_prom_dia.Rows.Count - 1
            sum_prom_dia += dt_prom_dia.Rows(i).Item("cartones")
        Next
        If (dt_prom_dia.Rows.Count > 0) Then
            prom_dia = sum_prom_dia / dt_prom_dia.Rows.Count
        End If
        lbl_prom_dia.Text = prom_dia.ToString("N2")
        lbl_emp_contenidos.Text = emp_contenido.ToString("N0")
        lbl_colpack.Text = colpack.ToString("N0")
        lbl_apl.Text = apl.ToString("N0")
        lbl_decor.Text = decor.ToString("N0")
        dtg_consulta.Columns("porc_participacion").DefaultCellStyle.Format = "N2"
        dtg_consulta.Columns("porc_participacion").HeaderText = "%participación"
        'For i = 0 To dtg_consulta.Columns.Count - 1
        '    If (dtg_consulta.Columns(i).Name = "id_empaque") Then
        '        dtg_consulta.Columns(i).Visible = False
        '    End If
        'Next
    End Sub
    Private Sub porc_participacion(ByRef dt As DataTable)
        dt.Columns.Add("porc_participacion", GetType(Double))
        dt.Columns.Add("vr_kilo", GetType(Double))
        Dim cartones As Double = 0
        Dim vr_kilo As Double = 0
        Dim kilos As Double = 0
        Dim salario As Double = 0
        For i = 0 To dt.Rows.Count - 1
            cartones = dt.Rows(i).Item("cartones")
            dt.Rows(i).Item("porc_participacion") = (cartones / tot_cartones) * 100
            If chk_consol_op.Checked Then
                If IsNumeric(dt.Rows(i).Item("kilos")) And IsNumeric(dt.Rows(i).Item("salario")) Then
                    kilos = dt.Rows(i).Item("kilos")
                    salario = dt.Rows(i).Item("salario")
                    vr_kilo = (salario / kilos)
                    dt.Rows(i).Item("vr_kilo") = vr_kilo
                End If
            End If
        Next
    End Sub
    Private Sub totalizarDt(ByVal dt As DataTable)
        Dim sum As Double = 0
        For j = 0 To dt.Columns.Count - 1
            If (dt.Columns(j).ColumnName = "kilos" Or dt.Columns(j).ColumnName = "vr_kilo" Or dt.Columns(j).ColumnName = "min_trab" Or dt.Columns(j).ColumnName = "cantidad" Or dt.Columns(j).ColumnName = "cartones" Or dt.Columns(j).ColumnName = "esperado" Or dt.Columns(j).ColumnName = "salario") Then
                For i = 0 To dt.Rows.Count - 2
                    If Not IsDBNull(dt.Rows(i).Item(j)) Then
                        sum += dt.Rows(i).Item(j)
                    End If
                Next
                dt.Rows(dt.Rows.Count - 1).Item(j) = sum
                If (dt.Columns(j).ColumnName = "cartones") Then
                    tot_cartones = sum
                    lbl_tot_cartones.Text = tot_cartones.ToString("N0")
                End If
                sum = 0
            End If
        Next
        If Not IsDBNull(dt.Rows(dt.Rows.Count - 1).Item("cartones")) And Not IsDBNull(dt.Rows(dt.Rows.Count - 1).Item("esperado")) Then
            If (dt.Rows(dt.Rows.Count - 1).Item("cartones")) > 0 And (dt.Rows(dt.Rows.Count - 1).Item("esperado") > 0) Then
                dt.Rows(dt.Rows.Count - 1).Item("Efic") = (dt.Rows(dt.Rows.Count - 1).Item("cartones") / dt.Rows(dt.Rows.Count - 1).Item("esperado")) * 100
            End If
        End If
    End Sub
    Private Sub dtg_consulta_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dtg_consulta.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            With (Me.dtg_consulta)
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                End If
            End With
        End If
    End Sub

    Private Sub btn_actualizar_Click(sender As System.Object, e As System.EventArgs) Handles btn_actualizar.Click
        imgProcesar.Visible = True
        Application.DoEvents()
        actualizar()
        imgProcesar.Visible = False
    End Sub

    Private Sub txt_transaccion_KeyPress(sender As Object, e As EventArgs) Handles txt_transaccion.KeyPress
        soloNumero(e)
    End Sub
    Private Sub soloNumero(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If (Char.IsDigit(e.KeyChar) Or e.KeyChar = ".") Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub
End Class