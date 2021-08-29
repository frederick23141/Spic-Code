Imports logicaNegocios
Imports System.Windows.Forms.DataVisualization.Charting

Public Class Frm_consultar_puas
    Private obj_Ing_prodLn As New Ing_prodLn
    Private objOpercionesForm As New OperacionesFormularios
    Dim carga_completa As Boolean = False
    Private objOperacionesForm As New OperacionesFormularios
    Dim ano As Integer = Now.Year
    Dim maquina_paro As String = 0
    Dim objOpSimplesLn As New Op_simpesLn
    Private Sub Frm_consult_tornilleria_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cbo_fecha_ini.Value = Now.AddDays(-1)
        cbo_fecha_fin.Value = Now.AddDays(-1)
        Dim sql As String
        Dim dt As DataTable
        Dim row As DataRow

        sql = "Select nit,nombres  from V_nom_personal_Activo_con_maquila WHERE centro = 6400 ORDER BY nombres "
        dt = obj_Ing_prodLn.listar_datatable(sql, "CORSAN")
        row = dt.NewRow
        row("nit") = 0
        row("nombres") = "TODOS"
        dt.Rows.Add(row)
        cbo_operario.DataSource = dt
        cbo_operario.ValueMember = "nit"
        cbo_operario.DisplayMember = "nombres"
        cbo_operario.SelectedValue = 0

        sql = "select  codigoM,nombre   from j_Maquinas where TipoMaquina =4 AND activa = 1 "
        dt = New DataTable
        dt = obj_Ing_prodLn.listar_datatable(sql, "PRODUCCION")
        row = dt.NewRow
        row("codigoM") = 0
        row("nombre") = "TODOS"
        dt.Rows.Add(row)
        cbo_maquina.DataSource = dt
        cbo_maquina.ValueMember = "codigoM"
        cbo_maquina.DisplayMember = "nombre"
        cbo_maquina.SelectedValue = 0
        sql = "select  nombre ,codigoM  from j_Maquinas where TipoMaquina = 4 AND activa = 1"

        sql = "SELECT id,descripcion FROM J_prod_puas_tipo "
        dt = New DataTable
        dt = obj_Ing_prodLn.listar_datatable(sql, "PRODUCCION")
        row = dt.NewRow
        row("id") = 0
        row("descripcion") = "TODOS"
        dt.Rows.Add(row)
        cbo_tipo_puas.DataSource = dt
        cbo_tipo_puas.ValueMember = "id"
        cbo_tipo_puas.DisplayMember = "descripcion"
        cbo_tipo_puas.SelectedValue = 0

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
    Private Sub cbo_mes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If (carga_completa) Then
            If (cbo_operario.Text <> "Seleccione" Or cbo_maquina.Text <> "Seleccione") Then
                If (chk_consol_op.Checked) Then
                    conslidar_operario(cbo_operario.SelectedValue)
                Else
                    cargar_consulta()
                End If
                If (Chart1.Visible = True) Then
                    If (chk_paro.Checked) Then
                        If (cbo_maquina.Text <> "Seleccione") Then
                            If (cbo_maquina.Text = "TODOS") Then
                                cargar_paros("TODO")
                            Else
                                cargar_paros(cbo_maquina.Text)
                            End If
                        End If
                    Else
                        graficar()
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub actualizar()
        If (carga_completa) Then
            Dim operario As String = cbo_operario.Text
            If (chk_consol_op.Checked) Then
                conslidar_operario(operario)
            ElseIf (chk_consol_ref.Checked) Then
                conslidar_referencia()
            ElseIf (chk_consol_dia.Checked) Then
                conslidar_dia()
            Else
                cargar_consulta()

            End If
            carga_completa = False
            cbo_maquina.Text = "Seleccione"
            carga_completa = True
        End If
    End Sub
    Public Sub calcular_totales(ByVal dtg As DataGridView)
        If (chk_consol_op.Checked) Then
            dtg_consulta.Item("nombres", dtg_consulta.RowCount - 1).Value = "TOTAL"
        ElseIf (chk_consol_ref.Checked) Then
            dtg_consulta.Item("referencia", dtg_consulta.RowCount - 1).Value = "TOTAL"
        End If

        dtg_consulta.Item("kilos_prod", dtg_consulta.RowCount - 1).Value = sumarColumnas("kilos_prod", dtg_consulta)
        dtg_consulta.Item("kilos_esp", dtg_consulta.RowCount - 1).Value = sumarColumnas("kilos_esp", dtg_consulta)
        dtg_consulta.Item("roy_prod", dtg_consulta.RowCount - 1).Value = sumarColumnas("roy_prod", dtg_consulta)
        dtg_consulta.Item("roy_esp", dtg_consulta.RowCount - 1).Value = sumarColumnas("roy_esp", dtg_consulta)
        dtg_consulta.Item("Efic", dtg_consulta.RowCount - 1).Value = sumarColumnas("Efic", dtg_consulta)
        dtg_consulta.Item("Paros", dtg_consulta.RowCount - 1).Value = sumarColumnas("Paros", dtg_consulta)
        If (chk_consol_op.Checked) Then
            If (chk_consol_op.Checked = False And chk_consol_ref.Checked = False) Then
                dtg_consulta.Item("t_sin_just", dtg_consulta.RowCount - 1).Value = sumarColumnas("t_sin_just", dtg_consulta)
                dtg_consulta.Item("Min_trab", dtg_consulta.RowCount - 1).Value = sumarColumnas("Min_trab", dtg_consulta)
            End If
        End If
    End Sub
    Private Function sumarColumnas(ByVal nomColumna As String, ByVal dtg As DataGridView) As Double
        Dim total As Double = 0
        For i As Integer = 0 To dtg.RowCount - 2
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
        If Not (chk_consol_op.Checked Or chk_consol_ref.Checked) Then
            dtg_consulta.Columns("fecha").DefaultCellStyle.Format = "d"
        End If
    End Sub
    Private Sub cargar_paros(ByVal maquina As String)
        btn_cerrar_graf.Visible = True
        Chart1.Visible = True
        G_grafico.Visible = True
        Dim sql As String
        Dim where_fec As String = ""
        Dim max As Double = 0
        Dim fec_ini As String = objOpSimplesLn.cambiarFormatoFecha(cbo_fecha_ini.Value.Date)
        Dim fec_fin As String = objOpSimplesLn.cambiarFormatoFecha(cbo_fecha_fin.Value.Date)
        where_fec = " WHERE fecha>= '" & fec_ini & "' AND fecha<= '" & fec_fin & "' "
        If (maquina = "TODO") Then
            sql = "SELECT  SUM (paro1 )As paro1,SUM (paro3 )As paro3,SUM (paro4 )As paro4,SUM (paro5 )As paro5,SUM (paro6 )As paro6,SUM (paro7 )As paro7, " & _
                                     "SUM(paro8)As paro8 , SUM(paro9)As paro9, SUM(paro11) As paro11,SUM(paro11) As paro12 ,SUM (paro13 )As paro13 " & _
                                         "FROM J_prod_puas  " & _
                                           where_fec

        Else
            sql = "SELECT  SUM (prod.paro1 )As paro1,SUM (prod.paro3 )As paro3,SUM (prod.paro4 )As paro4,SUM (prod.paro5 )As paro5,SUM (prod.paro6 )As paro6,SUM (prod.paro7 )As paro7, " & _
                                     "SUM(prod.paro8)As paro8 , SUM(prod.paro9)As paro9, SUM(prod.paro11) As paro11 ,SUM (prod.paro12)As paro12,SUM (prod.paro13 )As paro13 " & _
                                         "FROM J_prod_puas prod,J_maquinas maq " & _
                                            where_fec & "AND prod.maquina = maq.codigoM AND maq.nombre = '" & maquina & "' "
        End If
        Dim mat(,) As Object = obj_Ing_prodLn.mat_paros(sql, 10)
        Chart1.Visible = True
        Chart1.Titles.Clear()
        Chart1.Series.Clear()
        Chart1.ChartAreas.Clear()
        Chart1.ChartAreas.Add(0)
        For i = 0 To 10
            If Not (mat(i, 1) = Nothing) Then
                Chart1.Series.Add(mat(i, 1))
                Chart1.Series(mat(i, 1)).Points.AddXY("", mat(i, 0))
                Chart1.Series(mat(i, 1)).IsValueShownAsLabel = True
                Chart1.Series(mat(i, 1))("PointWidth") = "1.5"
                Chart1.Series(mat(i, 1)).ToolTip = mat(i, 1)
                If (mat(i, 0) > max) Then
                    max = mat(i, 0)
                End If
            End If
        Next
        Chart1.ChartAreas(0).AxisX.Title = "Paros"
        Chart1.ChartAreas(0).AxisY.Title = "Tiempo (minutos)"
        Chart1.ChartAreas(0).Area3DStyle.Enable3D = False
    End Sub
    Private Sub ProducciónToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProducciónToolStripMenuItem.Click
        G_grafico.Visible = True
        If ((cbo_operario.Text <> "Seleccione" Or cbo_maquina.Text <> "Seleccione")) Then
            chk_prod.Checked = True
            graficar()
        Else
            MessageBox.Show("Seleccione items de consulta para graficar! ", "Campos", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub
    Public Sub graficar()
        If (cbo_operario.Text <> "Seleccione" Or cbo_maquina.Text <> "Seleccione") Then
            btn_cerrar_graf.Visible = True
            Chart1.Visible = True
            Dim fec_ini As String = objOpSimplesLn.cambiarFormatoFecha(cbo_fecha_ini.Value.Date)
            Dim fec_fin As String = objOpSimplesLn.cambiarFormatoFecha(cbo_fecha_fin.Value.Date)
            Dim dias As Integer = ((cbo_fecha_fin.Value - cbo_fecha_ini.Value).Days) + 1
            Dim sql As String = ""
            Dim select_from As String = "SELECT SUM (roy_prod) As Royos ,DAY (fecha )" & _
                                        "FROM J_prod_puas "
            Dim where_sql As String = ""
            Dim criterio As String = ""
            Dim group As String = " GROUP by DAY (fecha ) , MONTH (fecha ) "
            Dim order As String = " ORDER by MONTH (fecha )"
            If (cbo_operario.Text <> "Seleccione") Then
                If (cbo_operario.Text <> "TODOS") Then
                    criterio = "AND nit = " & cbo_operario.SelectedValue & " "
                End If
            ElseIf (cbo_maquina.Text <> "Seleccione") Then
                If (cbo_maquina.Text <> "TODOS") Then
                    criterio = "AND maquina = " & cbo_maquina.SelectedValue & " "
                End If
            End If
            where_sql = " WHERE fecha>= '" & fec_ini & "' AND fecha<= '" & fec_fin & "' " & criterio
            sql = select_from & where_sql & group & order
            Dim mat(,) As Object = obj_Ing_prodLn.vec_dias_kilos(sql, dias)
            Chart1.Titles.Clear()
            Chart1.Series.Clear()
            Chart1.ChartAreas.Clear()
            Chart1.ChartAreas.Add(0)
            Chart1.Series.Add("Produccion")
            For i = 0 To (mat.Length / 2) - 1
                If Not (mat(i, 1) Is Nothing) Then
                    Chart1.Series("Produccion").Points.AddXY("Día" & mat(i, 1), mat(i, 0))
                End If
            Next
            Chart1.Series("Produccion").ChartType = DataVisualization.Charting.SeriesChartType.Line
            Chart1.ChartAreas(0).AxisX.Title = "DÍAS"
            Chart1.ChartAreas(0).AxisY.Title = "Royos producidos"
            Chart1.Refresh()
        Else
            MessageBox.Show("Seleccione operario(s) ó maquina(s) para graficar! ", "Seleccione", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Private Sub btn_cerrar_graf_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cerrar_graf.Click
        Chart1.Visible = False
        G_grafico.Visible = False
        btn_cerrar_graf.Visible = False
        'chk_paro.Checked = False
        'chk_prod.Checked = False
    End Sub



    Private Sub btn_excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_excel.Click
        objOperacionesForm.ExportarDatosExcel(dtg_consulta, "Púas")
    End Sub

    Private Sub cbo_ano_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If (carga_completa) Then
            If (cbo_operario.Text <> "Seleccione" Or cbo_maquina.Text <> "Seleccione") Then
                If (chk_consol_op.Checked) Then
                    conslidar_operario(cbo_operario.SelectedValue)
                Else
                    cargar_consulta()
                End If
                If (Chart1.Visible = True) Then
                    If (chk_paro.Checked) Then
                        If (cbo_maquina.Text <> "Seleccione") Then
                            cargar_paros(cbo_maquina.Text)
                        End If
                    Else
                        If (chk_prod.Checked) Then
                            graficar()
                        End If

                    End If
                End If
                If (cbo_operario.Text <> "Seleccione") Then
                    cbo_maquina.Text = "Seleccione"
                ElseIf (cbo_maquina.Text <> "Seleccione") Then
                    cbo_operario.Text = "Seleccione"
                End If
                menStripDtg.Enabled = False
            End If
        End If
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
            Dim sql As String = "DELETE FROM J_prod_puas WHERE id = " & id
            If (obj_Ing_prodLn.ejecutar(sql, "PRODUCCION") >= 1) Then
                dtg_consulta.CurrentCell = Nothing
                dtg_consulta.Rows(pos).Visible = False
                calcular_totales(dtg_consulta)
            Else
                MessageBox.Show("Error al eliminar el registro, verifique que no sea una celda en blanco! ", "Campos", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub
    Public Sub cargar_consulta()
        Dim fec_ini As String = objOpSimplesLn.cambiarFormatoFecha(cbo_fecha_ini.Value.Date)
        Dim fec_fin As String = objOpSimplesLn.cambiarFormatoFecha(cbo_fecha_fin.Value.Date)
        Dim dt As New DataTable
        Dim nit As Double = cbo_operario.SelectedValue
        Dim sql As String = ""
        Dim where_sql As String = " WHERE maq.codigoM = prod.maquina AND t.id = prod.tipo AND ter.nit = prod.nit AND ref.id_ref = prod.referencia And turno.Codigo = prod.turno And prod.fecha>= '" & fec_ini & "' AND prod.fecha<= '" & fec_fin & "'"
        Dim select_sql As String = ""
        select_sql = "SELECT  prod.id,t.descripcion AS tipo,prod.fecha ,prod.nit,ter.nombres ,(prod.horas_trab * 60) as Min_trab,turno.Descripcion AS turno,(turno.Horas * 60)As min_turno,maq.Nombre As maquina,kilos_prod,kilos_esp,roy_prod,roy_esp,(SELECT CASE WHEN prod.kilos_esp  = 0 THEN 0 ELSE(((prod.kilos_prod )/prod.kilos_esp )*100) END)As Efic  ,ref.descripcion As ref,t_sin_just,prod.numero_transaccion As transaccion," & _
                             "(prod.paro1+prod.paro3+prod.paro4+prod.paro5+prod.paro6+prod.paro7+prod.paro8+prod.paro9+prod.paro11+prod.paro12+prod.paro13)As Paros,prod.paro1,prod.paro3,prod.paro4,prod.paro5,prod.paro6,prod.paro7,prod.paro8,prod.paro9,prod.paro11,prod.paro12,prod.paro13 "   '((SELECT CASE WHEN KILOS  = 0 THEN null ELSE (VALOR_UNITARIO)*100/(Vr_total /KILOS  ) END))as VR_KILO
        If (cbo_operario.Text <> "Seleccione" And cbo_operario.Text <> "TODOS") Then
            where_sql &= " AND  prod.nit = " & cbo_operario.SelectedValue & " "
            menStripDtg.Enabled = True
        ElseIf (cbo_maquina.Text <> "Seleccione" And cbo_maquina.Text <> "TODOS") Then
            where_sql &= " AND prod.maquina = " & cbo_maquina.SelectedValue & " "
            menStripDtg.Enabled = False
        End If
        If (cbo_tipo_puas.Text <> "TODOS") Then
            where_sql &= " AND t.id = " & cbo_tipo_puas.SelectedValue & " "
        End If
        sql = select_sql & _
            " FROM j_prod_puas prod , j_prod_puas_tipo t , corsan.dbo.V_nom_personal_Activo_con_maquila ter,j_turnos turno,J_referencias ref , J_maquinas maq " &
                where_sql

        dt = obj_Ing_prodLn.listar_datatable(sql, "PRODUCCION")
        dt.Rows.Add()
        dtg_consulta.DataSource = dt
        dtg_consulta.Columns("Efic").DefaultCellStyle.Format = "N2"
        If (dtg_consulta.RowCount > 0) Then
            formatoNegrita(dtg_consulta)
            calcular_totales(dtg_consulta)
            pintar_col_mod()
        End If
        If (Chart1.Visible = True) Then
            If (chk_paro.Checked) Then
                If (cbo_maquina.Text <> "TODOS" Or cbo_maquina.Text = "Seleccione") Then
                    If (maquina_paro <> "") Then
                        cargar_paros(maquina_paro)
                    Else
                        cargar_paros("TODO")
                    End If

                Else
                    cargar_paros(cbo_maquina.SelectedValue)
                End If
            Else
                graficar()
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

    Public Sub conslidar_operario(ByVal operario As String)
        Dim dt As New DataTable
        Dim fecIni As String = objOpSimplesLn.cambiarFormatoFecha(cbo_fecha_ini.Value.Date)
        Dim fecFin As String = objOpSimplesLn.cambiarFormatoFecha(cbo_fecha_fin.Value.Date)
        Dim select_sql As String = ""
        Dim from_sql As String = ""
        Dim where_sql As String = ""
        Dim where_sql_fec As String = " AND prod.fecha>= '" & fecIni & "' AND prod.fecha<= '" & fecFin & "' "
        Dim group_sql As String = ""
        Dim sql As String = ""
        If (operario <> "Seleccione") Then
            select_sql = "SELECT ter.nombres , SUM(prod.horas_trab )As horas_trab,SUM(kilos_prod )As kilos_prod,SUM(kilos_esp )As kilos_esp,SUM(roy_prod )As roy_prod,SUM(roy_esp)As roy_esp,(SELECT CASE WHEN SUM (prod.kilos_esp)= 0 THEN 0 ELSE(((SUM (prod.kilos_prod ))/SUM (prod.kilos_esp))*100)END)As Efic, " & _
                         "(SUM(paro1 )+SUM (paro3 )+SUM (paro4 )+SUM (paro5 )+SUM (paro6 )+SUM (paro7 )+ SUM(paro8) + SUM(paro9) + SUM(paro11)+ SUM(paro12)+ SUM(paro13))As Paros " ''((SELECT CASE WHEN KILOS  = 0 THEN null ELSE (VALOR_UNITARIO)*100/(Vr_total /KILOS  ) END))as VR_KILO
            from_sql = "FROM J_prod_puas prod,corsan.dbo.V_nom_personal_Activo_con_maquila ter "
            where_sql = "WHERE ter.nit = prod.nit"
            group_sql = " GROUP by ter.nombres"
            If (cbo_operario.Text <> "TODOS") Then
                where_sql += " AND prod.nit = " & cbo_operario.SelectedValue
            End If
        End If
        If (cbo_tipo_puas.Text <> "Seleccione") Then
            If (cbo_tipo_puas.Text <> "TODOS") Then
                where_sql += " AND prod.tipo = " & cbo_tipo_puas.SelectedValue
            End If
        End If
        sql = select_sql & from_sql & where_sql & where_sql_fec & group_sql
        dt = obj_Ing_prodLn.listar_datatable(sql, "PRODUCCION")
        dt.Rows.Add()
        dtg_consulta.DataSource = dt
        formatoNegrita(dtg_consulta)
        calcular_totales(dtg_consulta)
        dtg_consulta.Columns("Efic").DefaultCellStyle.Format = "N2"
    End Sub
    Public Sub conslidar_dia()
        Dim dt As New DataTable
        Dim fecIni As String = objOpSimplesLn.cambiarFormatoFecha(cbo_fecha_ini.Value.Date)
        Dim fecFin As String = objOpSimplesLn.cambiarFormatoFecha(cbo_fecha_fin.Value.Date)
        Dim select_sql As String = ""
        Dim from_sql As String = ""
        Dim where_sql As String = ""
        Dim where_sql_fec As String = ""
        Dim group_sql As String = ""
        Dim sql As String = ""
        select_sql = "SELECT fecha, SUM(prod.horas_trab )As horas_trab,SUM(kilos_prod )As kilos_prod,SUM(kilos_esp )As kilos_esp,SUM(roy_prod )As roy_prod,SUM(roy_esp)As roy_esp,(SELECT CASE WHEN SUM (prod.kilos_esp)= 0 THEN 0 ELSE(((SUM (prod.kilos_prod ))/SUM (prod.kilos_esp))*100)END)As Efic, " & _
                        "(SUM(paro1 )+SUM (paro3 )+SUM (paro4 )+SUM (paro5 )+SUM (paro6 )+SUM (paro7 )+ SUM(paro8) + SUM(paro9) + SUM(paro11)+ SUM(paro12)+ SUM(paro13))As Paros "
        from_sql = "FROM J_prod_puas prod,J_referencias R , J_prod_puas_tipo t "
        where_sql = "WHERE t.id = prod.tipo AND R.id_ref = prod.referencia AND prod.fecha>= '" & fecIni & "' AND prod.fecha<= '" & fecFin & "'  "
        group_sql = " GROUP by fecha"
        If (cbo_maquina.Text <> "Seleccione") Then
            If (cbo_maquina.Text <> "TODOS") Then
                where_sql += " AND prod.maquina = " & cbo_maquina.SelectedValue
            End If

        ElseIf (cbo_operario.Text <> "Seleccione") Then
            If (cbo_operario.Text <> "TODOS") Then
                where_sql += " AND prod.nit = " & cbo_operario.SelectedValue
            End If
        End If
        If (cbo_tipo_puas.Text <> "Seleccione") Then
            If (cbo_tipo_puas.Text <> "TODOS") Then
                where_sql += " AND prod.tipo = " & cbo_tipo_puas.SelectedValue
            End If
        End If
        sql = select_sql & from_sql & where_sql & where_sql_fec & group_sql
        dt = obj_Ing_prodLn.listar_datatable(sql, "PRODUCCION")
        dt.Rows.Add()
        dtg_consulta.DataSource = dt
        formatoNegrita(dtg_consulta)
        calcular_totales(dtg_consulta)
        dtg_consulta.Columns("fecha").DefaultCellStyle.Format = "d"
        dtg_consulta.Columns("Efic").DefaultCellStyle.Format = "N2"
    End Sub
    Public Sub conslidar_referencia()
        Dim dt As New DataTable
        Dim fecIni As String = objOpSimplesLn.cambiarFormatoFecha(cbo_fecha_ini.Value.Date)
        Dim fecFin As String = objOpSimplesLn.cambiarFormatoFecha(cbo_fecha_fin.Value.Date)
        Dim select_sql As String = ""
        Dim from_sql As String = ""
        Dim where_sql As String = ""
        Dim where_sql_fec As String = ""
        Dim group_sql As String = ""
        Dim sql As String = ""
        select_sql = "SELECT t.descripcion AS tipo ,R.descripcion As referencia , SUM(prod.horas_trab )As horas_trab,SUM(kilos_prod )As kilos_prod,SUM(kilos_esp )As kilos_esp,SUM(roy_prod )As roy_prod,SUM(roy_esp)As roy_esp,(SELECT CASE WHEN SUM (prod.kilos_esp)= 0 THEN 0 ELSE(((SUM (prod.kilos_prod ))/SUM (prod.kilos_esp))*100)END)As Efic, " & _
                        "(SUM(paro1 )+SUM (paro3 )+SUM (paro4 )+SUM (paro5 )+SUM (paro6 )+SUM (paro7 )+ SUM(paro8) + SUM(paro9) + SUM(paro11)+ SUM(paro12)+ SUM(paro13))As Paros "
        from_sql = "FROM J_prod_puas prod,J_referencias R , J_prod_puas_tipo t "
        where_sql = "WHERE t.id = prod.tipo AND R.id_ref = prod.referencia AND prod.fecha>= '" & fecIni & "' AND prod.fecha<= '" & fecFin & "'  "
        group_sql = " GROUP by R.descripcion,t.descripcion"
        If (cbo_maquina.Text <> "Seleccione") Then
            If (cbo_maquina.Text <> "TODOS") Then
                where_sql += " AND prod.maquina = " & cbo_maquina.SelectedValue
            End If

        ElseIf (cbo_operario.Text <> "Seleccione") Then
            If (cbo_operario.Text <> "TODOS") Then
                where_sql += " AND prod.nit = " & cbo_operario.SelectedValue
            End If
        End If
        If (cbo_tipo_puas.Text <> "Seleccione") Then
            If (cbo_tipo_puas.Text <> "TODOS") Then
                where_sql += " AND prod.tipo = " & cbo_tipo_puas.SelectedValue
            End If
        End If
        sql = select_sql & from_sql & where_sql & where_sql_fec & group_sql
        dt = obj_Ing_prodLn.listar_datatable(sql, "PRODUCCION")
        dt.Rows.Add()
        dtg_consulta.DataSource = dt
        formatoNegrita(dtg_consulta)
        calcular_totales(dtg_consulta)
        dtg_consulta.Columns("Efic").DefaultCellStyle.Format = "N2"
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
    Private Sub ModificarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ModificarToolStripMenuItem.Click
        Dim pos As Integer = dtg_consulta.CurrentCell.RowIndex
        Dim id As String = dtg_consulta("id", pos).Value
        Dim horas_trab As String = dtg_consulta("horas_trab", pos).Value
        Dim fecha As String = dtg_consulta("fecha", pos).Value
        If (id <> "" And horas_trab <> "" And fecha <> "") Then
            If (obj_Ing_prodLn.modif_prod(id, horas_trab, fecha, "J_prod_puas") >= 1) Then
                MessageBox.Show("El registro de modifico en forma correcta! ", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Error al eliminar al modificar el registro, verifique que la celda no este en blanco! ", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            MessageBox.Show("Verifique que los items a modificar esten correctamente digitados! ", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub ParosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ParosToolStripMenuItem.Click
        If (cbo_maquina.Text <> "Seleccione") Then
            chk_paro.Checked = False
            chk_paro.Checked = True
        Else
            MessageBox.Show("Seleccione maquina a graficar! ", "Seleccione", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Public Sub pintar_col_mod()
        For i = 0 To dtg_consulta.ColumnCount - 1
            If (dtg_consulta.Columns(i).Name = "fecha" Or dtg_consulta.Columns(i).Name = "horas_trab") Then
                dtg_consulta.Columns(i).HeaderCell.Style.BackColor = Color.GreenYellow
                dtg_consulta.Columns(i).HeaderCell.Style.ForeColor = Color.Black
            Else
                dtg_consulta.Columns(i).ReadOnly = True
            End If
        Next
    End Sub

    Private Sub btn_actualizar_Click(sender As System.Object, e As System.EventArgs) Handles btn_actualizar.Click
        imgProcesar.Visible = True
        actualizar()
        imgProcesar.Visible = False
    End Sub


End Class