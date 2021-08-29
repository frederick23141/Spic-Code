Imports logicaNegocios
Imports System.Windows.Forms.DataVisualization.Charting

Public Class Frm_consultar_tref
    Private obj_Ing_prodLn As New Ing_prodLn
    Private objOpercionesForm As New OperacionesFormularios
    Dim carga_completa As Boolean = False
    Private objOperacionesForm As New OperacionesFormularios
    Private objOpSimplesLn As New Op_simpesLn
    Private Sub Frm_consultar_tref_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cbo_fecha_ini.Value = Now.AddDays(-1)
        cbo_fecha_fin.Value = Now.AddDays(-1)
        Dim sql As String
        Dim dt As DataTable
        Dim row As DataRow
        sql = "Select nit,nombres  from V_nom_personal_Activo_con_maquila WHERE centro = 2100 ORDER BY nombres "
        dt = obj_Ing_prodLn.listar_datatable(sql, "CORSAN")
        row = dt.NewRow
        row("nit") = 0
        row("nombres") = "TODOS"
        dt.Rows.Add(row)
        cbo_operario.DataSource = dt
        cbo_operario.ValueMember = "nit"
        cbo_operario.DisplayMember = "nombres"
        cbo_operario.Text = "Seleccione"
        sql = "select  codigoM,nombre   from j_Maquinas where TipoMaquina = 1 AND activa = 1 "
        dt = obj_Ing_prodLn.listar_datatable(sql, "PRODUCCION")
        row = dt.NewRow
        row("codigoM") = 0
        row("nombre") = "TODOS"
        dt.Rows.Add(row)
        cbo_maquina.DataSource = dt
        cbo_maquina.ValueMember = "codigoM"
        cbo_maquina.DisplayMember = "nombre"
        cbo_maquina.Text = "Seleccione"
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
        objOpercionesForm.ExportarDatosExcel(dtg_consulta, "Trefilaciòn")
    End Sub
    Private Sub cbo_operario_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_operario.SelectedIndexChanged
        If (carga_completa) Then
            If (cbo_operario.Text <> "Seleccione") Then
                Dim operario As String = cbo_operario.Text
                Dim maquina As String = cbo_maquina.Text
                If (chk_consol_op.Checked) Then
                    conslidar_operario(operario)
                Else
                    cargar_consulta()
                End If
                If Not (chk_consol_op.Checked) Then
                    dtg_consulta.Columns("diametro").DefaultCellStyle.Format = "N2"
                    dtg_consulta.Columns("Fecha").DefaultCellStyle.Format = "d"
                End If
                cbo_maquina.Text = "Seleccione"
                If (Chart1.Visible = True) Then
                    graficar()
                End If
            End If
        End If
    End Sub

    Private Sub cbo_fecha_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If (carga_completa And cbo_fecha_ini.Text <> "") Then
            Dim criterio As String = ""
            Dim select_sql As String = ""
            Dim group_sql As String = ""
            If (cbo_operario.Text <> "Seleccione") Then
                select_sql = "SELECT prod.id,ter.nombres,prod.fecha ,turno.Descripcion As turno,horas_trab As H_trab,diametro,((prod.alambron)+(prod.reproceso ))As kilos_prod, (kil_esperado)As kilos_esp,((prod.alambron)+(prod.reproceso ))/(kil_esperado)*100 As Efic, ((turno.horas)*60 -  (horas_trab )*60-( (paro0 )+ (paro1 )+ (paro2 )+ (paro3 )+ (paro4 )+ (paro5 )+ (paro6 )+ (paro7 )+ (paro8) + (paro9) + (paro10) + (paro11))) as T_sin_just, ( (paro0 )+ (paro1 )+ (paro2 )+ (paro3 )+ (paro4 )+ (paro5 )+ (paro6 )+ (paro7 )+ (paro8) + (paro9) + (paro10) + (paro11))As Paros  "
                criterio = "prod.nit = " & cbo_operario.SelectedValue & " "
            ElseIf (cbo_maquina.Text <> "Seleccione") Then
                select_sql = "SELECT prod.nit,ter.nombres,(SUM (prod.alambron)+SUM (prod.reproceso ))As kilos_prod,SUM (kil_esperado)As kilos_esp,SUM (horas_trab)As H_trab,(((SUM (prod.alambron)+SUM (prod.reproceso ))/SUM (kil_esperado))*100)As Efic, (SUM (turno.horas)*60 - SUM (horas_trab )*60-(SUM (paro0 )+SUM (paro1 )+SUM (paro2 )+SUM (paro3 )+SUM (paro4 )+SUM (paro5 )+SUM (paro6 )+SUM (paro7 )+ SUM(paro8) + SUM(paro9) + SUM(paro10) + SUM(paro11))) as T_sin_just, (SUM (paro0 )+SUM (paro1 )+SUM (paro2 )+SUM (paro3 )+SUM (paro4 )+SUM (paro5 )+SUM (paro6 )+SUM (paro7 )+ SUM(paro8) + SUM(paro9) + SUM(paro10) + SUM(paro11))As Paros "
                criterio = "prod.maquina = " & cbo_maquina.SelectedValue & " "
                group_sql = "GROUP by prod.nit,ter.nombres"
            End If
            If (cbo_operario.Text <> "Seleccione" Or cbo_maquina.Text <> "Seleccione") Then
                Dim fec As String = objOpSimplesLn.cambiarFormatoFecha(cbo_fecha_ini.Value.Date)
                Dim sql As String = ""
                If (cbo_operario.Text <> "TODOS" Or cbo_maquina.Text <> "TODOS" And (cbo_operario.Text <> "Seleccione" And cbo_maquina.Text <> "Seleccione")) Then
                    Dim nit As Double = cbo_operario.SelectedValue
                    sql = select_sql & _
                                       "FROM J_prod_trefilacion prod , corsan.dbo.V_nom_personal_Activo_con_maquila ter,j_turnos turno " & _
                                               "WHERE  " & criterio & " And ter.nit = prod.nit And turno.Codigo = prod.turno AND prod.fecha= '" & fec & "' " & _
                                                     group_sql
                ElseIf (cbo_operario.Text = "TODOS" Or cbo_maquina.Text = "TODOS") Then
                    sql = select_sql & _
                                   "FROM J_prod_trefilacion prod , corsan.dbo.V_nom_personal_Activo_con_maquila ter,j_turnos turno " & _
                                               "WHERE  ter.nit = prod.nit And turno.Codigo = prod.turno AND prod.fecha= '" & fec & "' " & _
                                                     group_sql

                End If
                cargar_consulta(sql)
                If (Chart1.Visible = True) Then
                    graficar()
                End If
            Else
                MessageBox.Show("Seleccione operario a consultar! ", "Seleccione", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If


        End If

    End Sub
    Public Sub cargar_consulta(ByVal sql As String)
        dtg_consulta.DataSource = obj_Ing_prodLn.listar_datatable(sql, "PRODUCCION")
        formatoNegrita(dtg_consulta)
        calcular_totales(dtg_consulta)
    End Sub
    Public Sub calcular_totales(ByVal dtg As DataGridView)
        dtg_consulta.Item("nombres", dtg_consulta.RowCount - 1).Value = "TOTAL"
        dtg_consulta.Item("kilos_esp", dtg_consulta.RowCount - 1).Value = sumarColumnas("kilos_esp", dtg_consulta)
        dtg_consulta.Item("Efic", dtg_consulta.RowCount - 1).Value = sumarColumnas("Efic", dtg_consulta)
        dtg_consulta.Item("Paros", dtg_consulta.RowCount - 1).Value = sumarColumnas("Paros", dtg_consulta)
        dtg_consulta.Item("T_sin_just", dtg_consulta.RowCount - 1).Value = sumarColumnas("T_sin_just", dtg_consulta)
        If (chk_consol_op.Checked) Then
            dtg_consulta.Item("H_prog", dtg_consulta.RowCount - 1).Value = sumarColumnas("H_prog", dtg_consulta)
            dtg_consulta.Item("H_trab", dtg_consulta.RowCount - 1).Value = sumarColumnas("H_trab", dtg_consulta)
        Else
            If (cbo_maquina.Text = "Seleccione") Then
                dtg_consulta.Item("Min_trab", dtg_consulta.RowCount - 1).Value = sumarColumnas("Min_trab", dtg_consulta)
                dtg_consulta.Item("Min_prog", dtg_consulta.RowCount - 1).Value = sumarColumnas("Min_prog", dtg_consulta)
            End If
        End If
        dtg_consulta.Item("alambron", dtg_consulta.RowCount - 1).Value = sumarColumnas("alambron", dtg_consulta)
        dtg_consulta.Item("reproceso", dtg_consulta.RowCount - 1).Value = sumarColumnas("reproceso", dtg_consulta)

    End Sub
    Private Function sumarColumnas(ByVal nomColumna As String, ByVal dtg As DataGridView) As Double
        Dim total As Double = 0
        For i As Integer = 0 To dtg.RowCount - 1
            total = total + CDbl(dtg.Item(nomColumna.ToLower, i).Value)
        Next
        If (nomColumna = "Efic") Then
            total = total / (dtg.RowCount - 1)
        End If
        Return total
    End Function
    Public Sub formatoNegrita(ByVal dtg As DataGridView)
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        dtg.Columns(0).DefaultCellStyle = DataGridViewCellStyle1
        dtg.Rows(dtg.RowCount - 1).DefaultCellStyle = DataGridViewCellStyle1
    End Sub
    Private Sub cargar_paros(ByVal id_maquina As Integer)
        btn_cerrar_graf.Visible = True
        Chart1.Visible = True
        G_grafico.Visible = True
        Dim mes As Integer = 0
        Dim where_fec As String = ""
        where_fec = " WHERE fecha>= '" & objOpSimplesLn.cambiarFormatoFecha(cbo_fecha_ini.Value.Date) & "' AND fecha<= '" & objOpSimplesLn.cambiarFormatoFecha(cbo_fecha_fin.Value.Date) & "' "
        Dim sql As String
        If (id_maquina = -1) Then
            sql = "SELECT  SUM (paro0)As paro0,SUM (paro1 )As paro1,SUM (paro2 )As paro2,SUM (paro3 )As paro3,SUM (paro4 )As paro4,SUM (paro5 )As paro5,SUM (paro6 )As paro6,SUM (paro7 )As paro7, " & _
                                     "SUM(paro8)As paro8 , SUM(paro9)As paro9, SUM(paro10) As paro10, SUM(paro11) As paro11 " & _
                                         "FROM J_prod_trefilacion  " & _
                                            where_fec & " "

        Else
            sql = "SELECT  SUM (paro0)As paro0,SUM (paro1 )As paro1,SUM (paro2 )As paro2,SUM (paro3 )As paro3,SUM (paro4 )As paro4,SUM (paro5 )As paro5,SUM (paro6 )As paro6,SUM (paro7 )As paro7, " & _
                                     "SUM(paro8)As paro8 , SUM(paro9)As paro9, SUM(paro10) As paro10, SUM(paro11) As paro11 " & _
                                         "FROM J_prod_trefilacion  " & _
                                            where_fec & " AND maquina = " & id_maquina & " "
        End If
        Dim vec() As Object = obj_Ing_prodLn.vec_paros(sql, 11)
        Chart1.Visible = True
        Chart1.Titles.Clear()
        Chart1.Series.Clear()
        Chart1.ChartAreas.Clear()
        Chart1.ChartAreas.Add(0)
        For i = 0 To vec.Length - 1
            Chart1.Series.Add("Paro" & i)
            Chart1.Series("Paro" & i).Points.AddXY("", vec(i))
            Chart1.Series("Paro" & i).IsValueShownAsLabel = True
            Chart1.Series("Paro" & i)("PointWidth") = "1.5"
            Chart1.Series("Paro" & i).ToolTip = "Paro" & i

        Next
        Chart1.ChartAreas(0).AxisX.Title = "Paros"
        Chart1.ChartAreas(0).AxisY.Title = "Tiempo (minutos)"
        Chart1.ChartAreas(0).Area3DStyle.Enable3D = False
        Chart1.Refresh()
    End Sub
    Private Sub ProducciónToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProducciónToolStripMenuItem.Click
        G_grafico.Visible = True
        If ((cbo_operario.Text <> "Seleccione" Or cbo_maquina.Text <> "Seleccione")) Then
            graficar()
        Else
            MessageBox.Show("Seleccione items de consulta para graficar! ", "Campos", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub
    Public Sub graficar()
        If (cbo_operario.Text <> "Seleccione" Or cbo_maquina.Text <> "Seleccione") Then
            btn_cerrar_graf.Visible = True
            Chart1.Visible = True
            G_grafico.Visible = True
            Dim fec_ini As String = objOpSimplesLn.cambiarFormatoFecha(cbo_fecha_ini.Value.Date)
            Dim fec_fin As String = objOpSimplesLn.cambiarFormatoFecha(cbo_fecha_fin.Value.Date)
            Dim dias As Integer = ((cbo_fecha_fin.Value.Date - cbo_fecha_ini.Value.Date).Days) + 1
            Dim sql As String = ""
            Dim select_from As String = "SELECT (SUM (alambron )+ SUM (reproceso )) As Kilos ,DAY (fecha ) , MONTH (fecha ) " & _
                                            " FROM J_prod_trefilacion "
            Dim where_sql As String = ""
            Dim group As String = " GROUP by DAY (fecha ) , MONTH (fecha ) "
            Dim order As String = " ORDER by MONTH (fecha )"
            Dim criterio As String = ""
            where_sql = " WHERE fecha>= '" & fec_ini & "' AND fecha<= '" & fec_fin & "' "
            If (cbo_operario.Text <> "Seleccione") Then
                If (cbo_operario.Text <> "TODOS") Then
                    criterio = "AND nit = " & cbo_operario.SelectedValue & " "
                End If
            ElseIf (cbo_maquina.Text <> "Seleccione") Then
                If (cbo_maquina.Text <> "TODOS") Then
                    criterio = "AND maquina = " & cbo_maquina.SelectedValue & " "
                End If
            End If
            where_sql += criterio
            sql = select_from & where_sql & group & order
            Dim mat(,) As Object = obj_Ing_prodLn.vec_dias_mes_kilos(sql, dias)
            Chart1.Titles.Clear()
            Chart1.Series.Clear()
            Chart1.ChartAreas.Clear()
            Chart1.ChartAreas.Add(0)
            Chart1.Series.Add("Produccion")
            For i = 0 To (mat.Length / 3) - 2
                If Not (mat(i, 1) Is Nothing) Then
                    Chart1.Series("Produccion").Points.AddXY(MonthName(mat(i, 2)) & mat(i, 1), mat(i, 0))
                End If
            Next
            Chart1.Series("Produccion").ChartType = DataVisualization.Charting.SeriesChartType.Line
            Chart1.ChartAreas(0).AxisX.Title = "DÌAS"
            Chart1.ChartAreas(0).AxisY.Title = "Kilos producidos"
            Chart1.Refresh()
        Else
            MessageBox.Show("Seleccione operario(s) ó maquina(s) para graficar! ", "Seleccione", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub
    Private Sub btn_cerrar_graf_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cerrar_graf.Click
        Chart1.Visible = False
        G_grafico.Visible = False
        btn_cerrar_graf.Visible = False
    End Sub
    Private Sub btn_excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_excel.Click
        objOperacionesForm.ExportarDatosExcel(dtg_consulta, "Trefilación")
    End Sub
    Private Sub cbo_maquina_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_maquina.SelectedIndexChanged
        If (carga_completa) Then
            If (cbo_maquina.Text <> "Seleccione") Then
                Dim operario As String = cbo_operario.Text
                Dim maquina As String = cbo_maquina.Text
                cbo_operario.Text = "Seleccione"
                cargar_consulta()
            End If
            cbo_operario.Text = "Seleccione"
            chk_consol_op.Checked = False
        End If
        menStripDtg.Enabled = False
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
            Dim id = dtg_consulta("id", pos).Value
            Dim sql As String = "DELETE FROM J_prod_trefilacion WHERE id = " & id
            If (obj_Ing_prodLn.ejecutar(sql, "PRODUCCION") >= 1) Then
                dtg_consulta.CurrentCell = Nothing
                dtg_consulta.Rows(pos).Visible = False
                calcular_totales(dtg_consulta)
            Else
                MessageBox.Show("Error al eliminar el registro, verifique que no sea una celda en blanco! ", "Campos", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Private Sub chk_prod_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_prod.CheckedChanged
    If (carga_completa) Then
            If chk_prod.Checked = True Then
                chk_paro.Checked = False
                graficar()
            Else
                chk_paro.Checked = True
            End If
        End If
    End Sub

    Private Sub chk_paro_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_paro.CheckedChanged
        If (carga_completa) Then
            If chk_paro.Checked = True Then
                If (cbo_maquina.Text <> "Seleccione") Then
                    If (cbo_maquina.Text = "TODOS") Then
                        cargar_paros(-1)
                    Else
                        cargar_paros(cbo_maquina.SelectedValue)
                    End If

                    chk_prod.Checked = False
                Else
                    MessageBox.Show("Seleccione maquina a graficar", "Seleccione maquina", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                chk_prod.Checked = True
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

    Private Sub cbo_fecha_ini_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If (carga_completa) Then
            Dim fec_ini As String = cbo_fecha_ini.Value.Date
            Dim fec_fin As String = cbo_fecha_fin.Value.Date
            If (chk_consol_op.Checked) Then
                conslidar_operario(cbo_operario.SelectedValue)
            Else
                cargar_consulta()
            End If
            If (Chart1.Visible = True) Then
                If (chk_prod.Checked) Then
                    graficar()
                ElseIf (chk_paro.Checked) Then
                    If (cbo_maquina.Text <> "Seleccione") Then
                        cargar_paros(cbo_maquina.SelectedValue)
                    Else
                        MessageBox.Show("Seleccione maquina a graficar", "Seleccione maquina", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If

                End If
            End If
        End If
    End Sub
    Private Sub cbo_fecha_fin_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If (carga_completa) Then
            Dim fec_ini As String = cbo_fecha_ini.Value.Date
            Dim fec_fin As String = cbo_fecha_fin.Value.Date
            If (chk_consol_op.Checked) Then
                conslidar_operario(cbo_operario.SelectedValue)
            Else
                cargar_consulta()
            End If
            If (Chart1.Visible = True) Then
                If (chk_prod.Checked) Then
                    graficar()
                ElseIf (chk_paro.Checked) Then
                    If (cbo_maquina.Text <> "Seleccione") Then
                        cargar_paros(cbo_maquina.Text)
                    Else
                        MessageBox.Show("Seleccione maquina a graficar", "Seleccione maquina", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If

                End If
            End If
        End If
    End Sub
    Private Sub btn_pantallazo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_pantallazo.Click
        If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
            Dim ruta As String = SaveFileDialog1.FileName
            capturarPantalla(ruta)
        End If
    End Sub
    Public Sub capturarPantalla(ByVal ruta As String)
        Dim FSize As Size = Me.Size
        Dim bm As New Bitmap(Me.Width, Me.Height - 10)
        Dim gf As Graphics
        Dim screenCap As Image
        gf = Graphics.FromImage(bm)
        gf.CopyFromScreen(0, 0, 0, 0, FSize)
        screenCap = bm
        screenCap.Clone()
        screenCap.Save(ruta)
        bm.Dispose()
    End Sub
    Private Sub chk_consol_op_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_consol_op.CheckedChanged
        If (carga_completa) Then
            If (chk_consol_op.Checked = True) Then
                If (cbo_operario.Text <> "Seleccione") Then
                    conslidar_operario(cbo_operario.SelectedValue)
                Else
                    MessageBox.Show("Seleccione operario(s) a consolidar", "Seleccione operario", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
                menStripDtg.Enabled = False
            Else
                cargar_consulta()
                menStripDtg.Enabled = True
            End If
        End If
    End Sub
    Public Sub conslidar_operario(ByVal operario As String)
        Dim select_sql As String = ""
        Dim from_sql As String = ""
        Dim where_sql As String = ""
        Dim where_sql_fec As String = " AND prod.fecha>= '" & cbo_fecha_ini.Value.Date & "' AND prod.fecha<= '" & cbo_fecha_fin.Value.Date & "' "
        Dim group_sql As String = ""
        Dim sql As String = ""
        If (operario <> "Seleccione") Then
            select_sql = "SELECT prod.nit,ter.nombres,SUM (prod.alambron)As alambron ,SUM (prod.reproceso)As reproceso ,SUM (kil_esperado)As kilos_esp,SUM (turno.horas)As H_prog,SUM (horas_trab)As H_trab,(((SUM (prod.alambron)+SUM (prod.reproceso ))/SUM (kil_esperado))*100)As Efic, (SUM (turno.horas)*60 - SUM (horas_trab )*60- " & _
                            " (SUM (paro0 )+SUM (paro1 )+SUM (paro2 )+SUM (paro3 )+SUM (paro4 )+SUM (paro5 )+SUM (paro6 )+SUM (paro7 )+ SUM(paro8) + SUM(paro9) + SUM(paro10) + SUM(paro11))) as T_sin_just, (SUM (paro0 )+SUM (paro1 )+SUM (paro2 )+SUM (paro3 )+SUM (paro4 )+SUM (paro5 )+SUM (paro6 )+SUM (paro7 )+ SUM(paro8) + SUM(paro9) + SUM(paro10) + SUM(paro11))As Paros "
            from_sql = "FROM J_prod_trefilacion prod,corsan.dbo.V_nom_personal_Activo_con_maquila ter ,J_turnos turno "
            where_sql = "WHERE ter.nit = prod.nit AND  prod.turno = turno.codigo"
            group_sql = " GROUP by prod.nit,ter.nombres"
            If (cbo_operario.Text <> "TODOS") Then
                where_sql += " AND prod.nit = " & cbo_operario.SelectedValue
            End If
        End If
        sql = select_sql & from_sql & where_sql & where_sql_fec & group_sql
        dtg_consulta.DataSource = obj_Ing_prodLn.listar_datatable(sql, "PRODUCCION")
        formatoNegrita(dtg_consulta)
        calcular_totales(dtg_consulta)
        menStripDtg.Enabled = False
    End Sub
    Public Sub cargar_consulta()
        If (cbo_operario.Text <> "Seleccione" Or cbo_maquina.Text <> "Seleccione") Then
            Dim select_sql As String = ""
            Dim from_sql As String = ""
            Dim where_sql As String = ""
            Dim where_sql_fec As String = ""
            Dim group_sql As String = ""
            Dim sql As String = ""
            Dim fec_ini As String = objOpSimplesLn.cambiarFormatoFecha(cbo_fecha_ini.Value.Date)
            Dim fec_fin As String = objOpSimplesLn.cambiarFormatoFecha(cbo_fecha_fin.Value.Date)
            where_sql_fec = "And prod.fecha>= '" & fec_ini & "' AND prod.fecha<= '" & fec_fin & "' "
            If (cbo_operario.Text <> "Seleccione") Then
                select_sql = "SELECT prod.id,ter.nombres,prod.fecha,turno.Descripcion As turno,(turno.horas * 60 )As Min_prog , maq.Nombre  as maquina,dest.descripcion As destino,(horas_trab * 60 ) As Min_trab,diametro,prod.alambron,prod.reproceso , (kil_esperado)As kilos_esp,((prod.alambron)+(prod.reproceso ))/(kil_esperado)*100 As Efic, ((turno.horas)*60 -  (horas_trab )*60- " & _
                                           " ( (paro0 )+ (paro1 )+ (paro2 )+ (paro3 )+ (paro4 )+ (paro5 )+ (paro6 )+ (paro7 )+ (paro8) + (paro9) + (paro10) + (paro11))) as T_sin_just, ( (paro0 )+ (paro1 )+ (paro2 )+ (paro3 )+ (paro4 )+ (paro5 )+ (paro6 )+ (paro7 )+ (paro8) + (paro9) + (paro10) + (paro11))As Paros  "
                from_sql = "FROM J_prod_trefilacion prod,corsan.dbo.V_nom_personal_Activo_con_maquila ter , J_turnos turno,J_Maquinas maq ,J_destino_tref dest "
                where_sql = "WHERE ter.nit = prod.nit AND turno.Codigo = prod.turno AND prod.maquina = maq.codigoM AND dest.codigo = prod.cod_destino "
                If (cbo_operario.Text <> "TODOS") Then
                    where_sql += " AND prod.nit = " & cbo_operario.SelectedValue
                    menStripDtg.Enabled = True
                End If
            ElseIf (cbo_maquina.Text <> "Seleccione") Then
                select_sql = "SELECT prod.nit,ter.nombres,SUM (prod.alambron) as Alambron,SUM (prod.reproceso ) As reproceso,SUM (kil_esperado)As kilos_esp,SUM (horas_trab)As H_trab,(((SUM (prod.alambron)+SUM (prod.reproceso ))/SUM (kil_esperado))*100)As Efic, (SUM (turno.horas)*60 - SUM (horas_trab )*60- " & _
                                " (SUM (paro0 )+SUM (paro1 )+SUM (paro2 )+SUM (paro3 )+SUM (paro4 )+SUM (paro5 )+SUM (paro6 )+SUM (paro7 )+ SUM(paro8) + SUM(paro9) + SUM(paro10) + SUM(paro11))) as T_sin_just, (SUM (paro0 )+SUM (paro1 )+SUM (paro2 )+SUM (paro3 )+SUM (paro4 )+SUM (paro5 )+SUM (paro6 )+SUM (paro7 )+ SUM(paro8) + SUM(paro9) + SUM(paro10) + SUM(paro11))As Paros "
                from_sql = "FROM J_prod_trefilacion prod,corsan.dbo.V_nom_personal_Activo_con_maquila ter , J_turnos turno "
                where_sql = "WHERE ter.nit = prod.nit AND turno.Codigo = prod.turno "
                group_sql = " GROUP by prod.nit,ter.nombres ,prod.id"
                If (cbo_maquina.Text <> "TODOS") Then
                    where_sql += " AND prod.maquina = '" & cbo_maquina.SelectedValue & "'"
                End If
            End If
            sql = select_sql & from_sql & where_sql & where_sql_fec & group_sql
            dtg_consulta.DataSource = obj_Ing_prodLn.listar_datatable(sql, "PRODUCCION")
            If (cbo_operario.Text <> "Seleccione") Then
                dtg_consulta.Columns("fecha").DefaultCellStyle.Format = "d"
            End If
            formatoNegrita(dtg_consulta)
            calcular_totales(dtg_consulta)
            pintar_col_mod()
            If (Chart1.Visible = True) Then
                If (chk_paro.Checked) Then
                    If (cbo_maquina.Text <> "Seleccione") Then
                        If (cbo_maquina.Text = "TODOS") Then
                            cargar_paros(-1)
                        Else
                            cargar_paros(cbo_maquina.SelectedValue)
                        End If
                    End If
                Else
                    graficar()
                End If
            End If
        Else
            MessageBox.Show("Seleccione operario ó maquina a consultar! ", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub ModificarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ModificarToolStripMenuItem.Click
        Dim pos As Integer = dtg_consulta.CurrentCell.RowIndex
        Dim id As String = dtg_consulta("id", pos).Value
        Dim horas_trab As String = dtg_consulta("h_trab", pos).Value
        Dim fecha As String = dtg_consulta("fecha", pos).Value
        If (id <> "" And horas_trab <> "" And fecha <> "") Then
            If (obj_Ing_prodLn.modif_prod(id, horas_trab, fecha, "J_prod_trefilacion") >= 1) Then
                MessageBox.Show("El registro de modifico en forma correcta! ", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Error al eliminar al modificar el registro, verifique que la celda no este en blanco! ", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            MessageBox.Show("Verifique que los items a modificar esten correctamente digitados! ", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Private Sub ParosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ParosToolStripMenuItem.Click
        chk_paro.Checked = True
    End Sub
    Public Sub pintar_col_mod()
        For i = 0 To dtg_consulta.ColumnCount - 1
            If (dtg_consulta.Columns(i).Name = "fecha" Or dtg_consulta.Columns(i).Name = "H_trab") Then
                dtg_consulta.Columns(i).HeaderCell.Style.BackColor = Color.GreenYellow
                dtg_consulta.Columns(i).HeaderCell.Style.ForeColor = Color.Black
            Else
                dtg_consulta.Columns(i).ReadOnly = True
            End If
        Next
    End Sub

End Class