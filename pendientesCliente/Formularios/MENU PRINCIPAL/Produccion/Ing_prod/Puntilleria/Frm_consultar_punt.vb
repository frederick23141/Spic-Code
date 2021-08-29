Imports logicaNegocios
Imports System.Windows.Forms.DataVisualization.Charting

Public Class Frm_consultar_punt
    Private obj_Ing_prodLn As New Ing_prodLn
    Private objOpSimples As New Op_simpesLn
    Dim carga_completa As Boolean = False
    Private objOperacionesForm As New OperacionesFormularios
    Dim ano As Integer = Now.Year
    Dim graficoParo As Boolean = False
    Dim dt As New DataTable
    Private Sub Frm_consultar_punt_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim sql As String
        Dim dt As DataTable
        Dim row As DataRow
        cbo_fecha_ini.Value = Now.AddDays(-1)
        cbo_fecha_fin.Value = Now.AddDays(-1)
        sql = "Select nit,nombres  from V_nom_personal_Activo_con_maquila WHERE centro = 2300 ORDER BY nombres "
        dt = obj_Ing_prodLn.listar_datatable(sql, "CORSAN")
        row = dt.NewRow
        row("nit") = 0
        row("nombres") = "TODOS"
        dt.Rows.Add(row)
        cbo_operario.DataSource = dt
        cbo_operario.ValueMember = "nit"
        cbo_operario.DisplayMember = "nombres"
        cbo_operario.SelectedValue = 0

        sql = "select  seccion   from J_seccion_maquina_punt group by seccion "
        dt = New DataTable
        dt = obj_Ing_prodLn.listar_datatable(sql, "PRODUCCION")
        row = dt.NewRow
        row("seccion") = "TODOS"
        dt.Rows.Add(row)
        cboSeccion.DataSource = dt
        cboSeccion.ValueMember = "seccion"
        cboSeccion.DisplayMember = "seccion"
        cboSeccion.SelectedValue = "TODOS"

        sql = "select  codigoM,nombre   from j_Maquinas where TipoMaquina in (2,3) AND activa = 1 "
        dt = New DataTable
        dt = obj_Ing_prodLn.listar_datatable(sql, "PRODUCCION")
        row = dt.NewRow
        row("codigoM") = 0
        row("nombre") = "TODOS"
        dt.Rows.Add(row)
        cbo_maquina.DataSource = dt
        cbo_maquina.ValueMember = "codigoM"
        cbo_maquina.DisplayMember = "nombre"
        cbo_maquina.Text = "Seleccione"
        cbo_maquina.SelectedValue = 0

        sql = "select  id_ref,descripcion   from J_referencias where tipo in (2,3) "
        dt = obj_Ing_prodLn.listar_datatable(sql, "PRODUCCION")
        row = dt.NewRow
        row("id_ref") = 0
        row("descripcion") = "TODOS"
        dt.Rows.Add(row)
        cboRef.DataSource = dt
        cboRef.ValueMember = "id_ref"
        cboRef.DisplayMember = "descripcion"
        cboRef.SelectedValue = 0

        sql = "select  nombre ,codigoM  from j_Maquinas where TipoMaquina in (2,3) AND activa = 1"

       
        sql = "select  nombre ,codigoM  from j_Maquinas where TipoMaquina in (2,3) AND activa = 1"

        Dim mat As Object(,) = obj_Ing_prodLn.vec_dias_kilos(sql, dt.Rows.Count)
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
        objOperacionesForm.ExportarDatosExcel(dtg_consulta, "Puntilleria")
    End Sub

    Public Sub calcular_totales()
        dt.Rows(dt.Rows.Count - 1).Item("kilos_prod") = sumarColumnas("kilos_prod")
        dt.Rows(dt.Rows.Count - 1).Item("kil_esperado") = sumarColumnas("kil_esperado")
        dt.Rows(dt.Rows.Count - 1).Item("Paros") = sumarColumnas("Paros")
        dt.Rows(dt.Rows.Count - 1).Item("horas_trab") = sumarColumnas("horas_trab")
        dt.Rows(dt.Rows.Count - 1).Item("Min_trab") = sumarColumnas("Min_trab")
        dt.Rows(dt.Rows.Count - 1).Item("Min_prog") = sumarColumnas("Min_prog")
        dt.Rows(dt.Rows.Count - 1).Item("Efic") = (dt.Rows(dt.Rows.Count - 1).Item("kilos_prod") / dt.Rows(dt.Rows.Count - 1).Item("kil_esperado")) * 100
        dt.Rows(dt.Rows.Count - 1).Item("porc_rend") = (dt.Rows(dt.Rows.Count - 1).Item("Min_trab") / dt.Rows(dt.Rows.Count - 1).Item("Min_prog")) * 100
        If (chk_porc.Checked) Then
            Dim fec_ini As String = objOpSimples.cambiarFormatoFecha(cbo_fecha_ini.Value.Date)
            Dim fec_fin As String = objOpSimples.cambiarFormatoFecha(cbo_fecha_fin.Value.Date)
            Dim dt_totales As New DataTable
            Dim sql_totales As String = ""
            Dim select_sql As String = ""
            Dim from_sql As String = ""
            Dim where_sql As String = "WHERE prod.fecha>= '" & fec_ini & "' AND prod.fecha<= '" & fec_fin & "' AND t.Codigo = prod.turno AND S.maquina = prod.maquina "
            select_sql = "SELECT (SUM(t_sin_just)/(SUM(t.Horas )*60))*100 As t_sin_just,(SUM(prod.paro1)/(SUM(t.Horas )*60))*100 As paro1,(SUM(prod.paro2)/(SUM(t.Horas )*60))*100 As paro2,(SUM(prod.paro3)/(SUM(t.Horas )*60))*100 As paro3,(SUM(prod.paro4)/(SUM(t.Horas )*60))*100 As paro4,(SUM(prod.paro5)/(SUM(t.Horas )*60))*100 As paro5,(SUM(prod.paro6)/(SUM(t.Horas )*60))*100 As paro6,(SUM(prod.paro7)/(SUM(t.Horas )*60))*100 As paro7,(SUM(prod.paro8)/(SUM(t.Horas )*60))*100 As paro8,(SUM(prod.paro9)/(SUM(t.Horas )*60))*100 As paro9,(SUM(prod.paro10)/(SUM(t.Horas )*60))*100 As paro10,(SUM(prod.paro11)/(SUM(t.Horas )*60))*100 As paro11,(SUM(prod.paro12)/(SUM(t.Horas )*60))*100 As paro12,(SUM(prod.paro13)/(SUM(t.Horas )*60))*100 As paro13,(SUM(prod.paro14)/(SUM(t.Horas )*60))*100 As paro14,(SUM(prod.paro15)/(SUM(t.Horas )*60))*100 As paro15,(SUM(prod.paro16)/(SUM(t.Horas )*60))*100 As paro16,(SUM(prod.paro17)/(SUM(t.Horas )*60))*100 As paro17,(SUM(prod.paro18)/(SUM(t.Horas )*60))*100 As paro18,(SUM(prod.paro19)/(SUM(t.Horas )*60))*100 As paro19,(SUM(prod.paro20)/(SUM(t.Horas )*60))*100 As paro20,(SUM(prod.paro21)/(SUM(t.Horas )*60))*100 As paro21,(SUM(prod.paro22)/(SUM(t.Horas )*60))*100 As paro22,(SUM(prod.paro23)/(SUM(t.Horas )*60))*100 As paro23," & _
                             "((SUM(paro1 )+SUM (paro2 )+SUM (paro3 )+SUM (paro4 )+SUM (paro5 )+SUM (paro6 )+SUM (paro7 )+ SUM(paro8) + SUM(paro9) + SUM(paro10) + SUM(paro11)+ SUM(paro12)+SUM(paro13 )+SUM (paro14 )+SUM (paro15 )+SUM (paro16 )+SUM (paro17 )+SUM (paro18 )+SUM (paro19 )+ SUM(paro20) + SUM(paro21) + SUM(paro22) + SUM(paro23))/(SUM(t.Horas )*60))*100 As Paros "
            from_sql = "FROM J_prod_puntilleria prod,J_turnos t,J_seccion_maquina_punt S  "
            If (cbo_operario.Text <> "Seleccione") Then
                If (cbo_operario.Text <> "TODOS") Then
                    where_sql += " And prod.nit = " & cbo_operario.SelectedValue
                End If
            ElseIf (cbo_maquina.Text <> "Seleccione") Then
                If (cbo_maquina.Text <> "TODOS") Then
                    where_sql += " AND prod.maquina = '" & cbo_maquina.SelectedValue & "'"
                End If
            ElseIf (cboSeccion.Text <> "Seleccione") Then
                If (cboSeccion.Text <> "TODOS") Then
                    where_sql += " AND S.seccion = '" & cboSeccion.Text & "'"
                End If
            End If
            sql_totales = select_sql & from_sql & where_sql
            dt_totales = objOpSimples.listar_datatable(sql_totales, "PRODUCCION")
            For i = 0 To dt_totales.Columns.Count - 1
                For j = 0 To dt.Columns.Count - 1
                    If (dt_totales.Columns(i).ColumnName = dt.Columns(j).ColumnName) Then
                        dt.Rows(dt.Rows.Count - 1).Item(dt.Columns(j).ColumnName) = dt_totales.Rows(dt_totales.Rows.Count - 1).Item(dt_totales.Columns(i).ColumnName)
                        j = dt.Columns.Count - 1
                    End If
                Next
            Next
        Else
            If Not chk_consol_op.Checked Then
                For i = dt.Columns("paro1").Ordinal To dt.Columns("Paros").Ordinal
                    dt.Rows(dt.Rows.Count - 1).Item(i) = sumarColumnas(dt.Columns(i).ColumnName)
                Next
            End If

            If ((cbo_operario.Text <> "Seleccione") Or cboSeccion.Text <> "Seleccione" Or cbo_maquina.Text <> "Seleccione") Then
                If (chk_consol_op.Checked = False) Then
                    dt.Rows(dt.Rows.Count - 1).Item("t_sin_just") = sumarColumnas("t_sin_just")
                End If
            End If
        End If
    End Sub
    Private Function sumarColumnas(ByVal nomColumna As String) As Double
        Dim total As Double = 0
        Dim s As String = ""
        For i As Integer = 0 To dt.Rows.Count - 2
            If Not IsDBNull(dt.Rows(i).Item(nomColumna.ToLower)) Then
                total = total + CDbl(dt.Rows(i).Item(nomColumna.ToLower))
                s = s & "-" & CDbl(dt.Rows(i).Item(nomColumna.ToLower))
            End If
        Next
        Return total
    End Function
    Public Sub formatoNegrita(ByVal dtg As DataGridView)
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        dtg.Columns(0).DefaultCellStyle = DataGridViewCellStyle1
        dtg.Rows(dtg.RowCount - 1).DefaultCellStyle = DataGridViewCellStyle1
        If (cbo_operario.Text <> "Seleccione") Then
            If Not (chk_consol_op.Checked) Then
                ' dtg_consulta.Columns("fecha").DefaultCellStyle.Format = "d"
            End If
        End If
    End Sub
    Private Sub cargar_paros()
        Dim maquina As String = cbo_maquina.Text
        If (cbo_maquina.Text <> "Seleccione" Or cboSeccion.Text <> "Seleccione") Then
            graficoParo = True
            btn_cerrar_graf.Visible = True
            Chart1.Visible = True
            Dim fec_ini As String = objOpSimples.cambiarFormatoFecha(cbo_fecha_ini.Value.Date)
            Dim fec_fin As String = objOpSimples.cambiarFormatoFecha(cbo_fecha_fin.Value.Date)
            Dim sql As String = ""
            Dim max As Double = 0
            Dim whereSql As String = ""

            If (cbo_maquina.Text <> "Seleccione") Then
                whereSql = "WHERE fecha>= '" & fec_ini & "' AND fecha<= '" & fec_fin & "' AND prod.maquina = maq.codigoM  "
                If (cbo_maquina.Text <> "TODOS") Then
                    whereSql &= "  AND maq.nombre = '" & maquina & "' "
                End If
                sql = "SELECT  SUM (prod.paro1 )As paro1,SUM (prod.paro2 )As paro2,SUM (prod.paro3 )As paro3,SUM (prod.paro4 )As paro4,SUM (prod.paro5 )As paro5,SUM (prod.paro6 )As paro6,SUM (prod.paro7 )As paro7, " & _
                                  "SUM(prod.paro8)As paro8 , SUM(prod.paro9)As paro9, SUM(prod.paro10) As paro10, SUM(prod.paro11) As paro11 ,SUM (prod.paro12)As paro12, " & _
                                  "SUM (prod.paro13 )As paro13,SUM (prod.paro14 )As paro14,SUM (prod.paro15 )As paro15,SUM (prod.paro16 )As paro16,SUM (prod.paro17 )As paro17, " & _
                                  "SUM (prod.paro18 )As paro18,SUM (prod.paro19 )As paro19,SUM (prod.paro20 )As paro20,SUM (prod.paro21 )As paro21,SUM (prod.paro22 )As paro22,,SUM (prod.paro23)As paro23 " & _
                                      "FROM J_prod_puntilleria prod,J_maquinas maq " & _
                                        whereSql
            ElseIf (cboSeccion.Text <> "Seleccione") Then
                whereSql = "WHERE fecha>= '" & fec_ini & "' AND fecha<= '" & fec_fin & "' AND S.maquina = prod.maquina  "
                If (cboSeccion.Text <> "TODOS") Then
                    whereSql &= "  AND S.seccion = '" & cboSeccion.Text & "' "
                End If
                sql = "SELECT  SUM (prod.paro1 )As paro1,SUM (prod.paro2 )As paro2,SUM (prod.paro3 )As paro3,SUM (prod.paro4 )As paro4,SUM (prod.paro5 )As paro5,SUM (prod.paro6 )As paro6,SUM (prod.paro7 )As paro7, " & _
                                  "SUM(prod.paro8)As paro8 , SUM(prod.paro9)As paro9, SUM(prod.paro10) As paro10, SUM(prod.paro11) As paro11 ,SUM (prod.paro12)As paro12, " & _
                                  "SUM (prod.paro13 )As paro13,SUM (prod.paro14 )As paro14,SUM (prod.paro15 )As paro15,SUM (prod.paro16 )As paro16,SUM (prod.paro17 )As paro17, " & _
                                  "SUM (prod.paro18 )As paro18,SUM (prod.paro19 )As paro19,SUM (prod.paro20 )As paro20,SUM (prod.paro21 )As paro21,SUM (prod.paro22 )As paro22,SUM (prod.paro23)As paro23 " & _
                        "FROM J_prod_puntilleria prod,J_seccion_maquina_punt S " & _
                                        whereSql

            End If
            Dim vec() As Object = obj_Ing_prodLn.vec_paros(sql, 22)
            Chart1.Visible = True
            Chart1.Titles.Clear()
            Chart1.Series.Clear()
            Chart1.ChartAreas.Clear()
            Chart1.ChartAreas.Add(0)
            For i = 0 To vec.Length - 1
                Chart1.Series.Add("Paro" & i + 1)
                Chart1.Series("Paro" & i + 1).Points.AddXY("", vec(i))
                Chart1.Series("Paro" & i + 1).IsValueShownAsLabel = True
                Chart1.Series("Paro" & i + 1)("PointWidth") = "1.5"
                Chart1.Series("Paro" & i + 1).ToolTip = "Paro" & i + 1
                If (vec(i) > max) Then
                    max = vec(i)
                End If
            Next
            If (cboSeccion.Text <> "Seleccione") Then
                Chart1.ChartAreas(0).AxisX.Title = "Paros - " & cboSeccion.Text
            Else
                Chart1.ChartAreas(0).AxisX.Title = "Paros"
            End If

            Chart1.ChartAreas(0).AxisY.Title = "Tiempo (minutos)"
            Chart1.ChartAreas(0).Area3DStyle.Enable3D = False
        Else
            MessageBox.Show("Seleccione maquina O sección para graficar los paros! ", "Seleccione", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub
    Private Sub ProducciónToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProducciónToolStripMenuItem.Click
        If ((cbo_operario.Text <> "Seleccione" Or cbo_maquina.Text <> "Seleccione")) Then
            graficar()
        Else
            MessageBox.Show("Seleccione items de consulta para graficar! ", "Campos", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub
    Public Sub graficar()
        If (cbo_operario.Text <> "Seleccione" Or cbo_maquina.Text <> "Seleccione") Then
            graficoParo = False
            btn_cerrar_graf.Visible = True
            Chart1.Visible = True
            Dim fec_ini As Date = objOpSimples.cambiarFormatoFecha(cbo_fecha_ini.Value.Date)
            Dim fec_fin As Date = objOpSimples.cambiarFormatoFecha(cbo_fecha_fin.Value.Date)
            Dim dias As Integer = ((fec_fin - fec_ini).Days) + 1
            Dim sql As String = ""
            Dim criterio As String = ""
            Dim select_from As String = "SELECT SUM (kilos_prod) As Kilos ,DAY (fecha )" & _
                                        "FROM J_prod_puntilleria "
            Dim where_sql As String = ""
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
            where_sql = " WHERE fecha>= '" & objOpSimples.cambiarFormatoFecha(cbo_fecha_ini.Value.Date) & "' AND fecha<= '" & objOpSimples.cambiarFormatoFecha(cbo_fecha_fin.Value.Date) & "' " & criterio
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
            Chart1.ChartAreas(0).AxisX.Title = "DÌAS"
            Chart1.ChartAreas(0).AxisY.Title = "Kilos producidos"
            Chart1.Refresh()
        Else
            MessageBox.Show("Seleccione operario(s) ó maquina(s) para graficar! ", "Seleccione", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub btn_cerrar_graf_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cerrar_graf.Click
        Chart1.Visible = False
        btn_cerrar_graf.Visible = False
    End Sub
    Private Sub btn_excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_excel.Click
        objOperacionesForm.ExportarDatosExcel(dtg_consulta, "Puntilleria")
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
            Dim sql As String = "DELETE FROM J_prod_puntilleria WHERE id = " & id
            If (obj_Ing_prodLn.ejecutar(sql, "PRODUCCION") >= 1) Then
                dtg_consulta.CurrentCell = Nothing
                dtg_consulta.Rows(pos).Visible = False
                calcular_totales()
            Else
                MessageBox.Show("Error al eliminar el registro, verifique que no sea una celda en blanco! ", "Campos", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub
    Public Sub cargar_consulta()

        dtg_consulta.DataSource = Nothing
        dt = New DataTable
        Dim fec_ini As String = objOpSimples.cambiarFormatoFecha(cbo_fecha_ini.Value.Date)
        Dim fec_fin As String = objOpSimples.cambiarFormatoFecha(cbo_fecha_fin.Value.Date)
        Dim select_sql As String = ""
        Dim from_sql As String = " FROM J_prod_puntilleria prod,corsan.dbo.V_nom_personal_Activo_con_maquila ter, J_turnos t,J_referencias ref ,J_Maquinas maq,J_seccion_maquina_punt S "
        Dim where_sql As String = " WHERE ter.nit = prod.nit AND t.Codigo = prod.turno AND ref.id_ref = prod.referencia AND prod.maquina = maq.codigoM AND S.maquina = prod.maquina  AND prod.fecha>= '" & fec_ini & "' AND prod.fecha<= '" & fec_fin & "'  "
        Dim orderSql As String = ""
        Dim group_sql As String = ""
        Dim sql As String = ""
        Dim formato As String = ""
        If (chk_porc.Checked) Then
            formato = "N2"
            If (cbo_operario.Text <> "Seleccione") Then
                select_sql = "SELECT  prod.id,prod.fecha ,prod.nit,ter.nombres,S.seccion ,maq.Nombre As maquina,prod.horas_trab,((prod.horas_trab)*60) as Min_trab,((turno.Horas )*60)-20 as Min_prog,turno.Descripcion AS turno,kilos_prod,kil_esperado,(((prod.kilos_prod )/prod.kil_esperado )*100)As Efic,(((prod.horas_trab *60 ))/((turno.Horas*60 )-20))*100 as porc_rend  ,ref.descripcion As ref,ref.codigo,(t_sin_just/(turno.Horas*60))*100 As t_sin_just,(prod.paro1/(turno.Horas*60))*100 As paro1,(prod.paro2/(turno.Horas*60))*100 As paro2,(prod.paro3/(turno.Horas*60))*100 As paro3,(prod.paro4/(turno.Horas*60))*100 As paro4,(prod.paro5/(turno.Horas*60))*100 As paro5,(prod.paro6/(turno.Horas*60))*100 As paro6,(prod.paro7/(turno.Horas*60))*100 As paro7,(prod.paro8/(turno.Horas*60))*100 As paro8,(prod.paro9/(turno.Horas*60))*100 As paro9,(prod.paro10/(turno.Horas*60))*100 As paro10,(prod.paro11/(turno.Horas*60))*100 As paro11,(prod.paro12/(turno.Horas*60))*100 As paro12,(prod.paro13/(turno.Horas*60))*100 As paro13,(prod.paro14/(turno.Horas*60))*100 As paro14,(prod.paro15/(turno.Horas*60))*100 As paro15,(prod.paro16/(turno.Horas*60))*100 As paro16,(prod.paro17/(turno.Horas*60))*100 As paro17,(prod.paro18/(turno.Horas*60))*100 As paro18,(prod.paro19/(turno.Horas*60))*100 As paro19,(prod.paro20/(turno.Horas*60))*100 As paro20,(prod.paro21/(turno.Horas*60))*100 As paro21,(prod.paro22/(turno.Horas*60))*100 As paro22,(prod.paro23/(turno.Horas*60))*100 As paro23," &
                             "((prod.paro1+prod.paro2+prod.paro3+prod.paro4+prod.paro5+prod.paro6+prod.paro7+prod.paro8+prod.paro9+prod.paro10+prod.paro11+prod.paro12+prod.paro13+prod.paro14+prod.paro15+prod.paro16+prod.paro17+prod.paro18+prod.paro19+prod.paro20+prod.paro21+prod.paro22+prod.paro23)/(turno.Horas*60))*100 As Paros,prod.observaciones "
                from_sql = "FROM J_prod_puntilleria prod,corsan.dbo.V_nom_personal_Activo_con_maquila ter, J_turnos turno,J_referencias ref ,J_Maquinas maq,J_seccion_maquina_punt S "
                where_sql = "WHERE ter.nit = prod.nit AND turno.Codigo = prod.turno AND ref.id_ref = prod.referencia AND prod.maquina = maq.codigoM AND S.maquina = prod.maquina AND prod.fecha>= '" & fec_ini & "' AND prod.fecha<= '" & fec_fin & "' "
                If (cbo_operario.Text <> "TODOS") Then
                    where_sql += " And prod.nit = " & cbo_operario.SelectedValue
                End If
            ElseIf (cbo_maquina.Text <> "Seleccione") Then
                select_sql = "SELECT ter.nombres,S.seccion , SUM(prod.horas_trab )As horas_trab ,(SUM(prod.horas_trab)*60)As Min_trab,(SUM(t.Horas)*60)-(COUNT(*)*20) as Min_prog,SUM(kilos_prod )As kilos_prod,SUM(kil_esperado )As kil_esperado,(((SUM (prod.kilos_prod ))/SUM (prod.kil_esperado))*100)As Efic,((SUM(prod.horas_trab)*60)/((SUM(t.Horas)*60)-(COUNT(*)*20)))*100 as porc_rend ,(SUM(prod.paro1)/(SUM(t.Horas )*60))*100 As paro1,(SUM(prod.paro2)/(SUM(t.Horas )*60))*100 As paro2,(SUM(prod.paro3)/(SUM(t.Horas )*60))*100 As paro3,(SUM(prod.paro4)/(SUM(t.Horas )*60))*100 As paro4,(SUM(prod.paro5)/(SUM(t.Horas )*60))*100 As paro5,(SUM(prod.paro6)/(SUM(t.Horas )*60))*100 As paro6,(SUM(prod.paro7)/(SUM(t.Horas )*60))*100 As paro7,(SUM(prod.paro8)/(SUM(t.Horas )*60))*100 As paro8,(SUM(prod.paro9)/(SUM(t.Horas )*60))*100 As paro9,(SUM(prod.paro10)/(SUM(t.Horas )*60))*100 As paro10,(SUM(prod.paro11)/(SUM(t.Horas )*60))*100 As paro11,(SUM(prod.paro12)/(SUM(t.Horas )*60))*100 As paro12,(SUM(prod.paro13)/(SUM(t.Horas )*60))*100 As paro13,(SUM(prod.paro14)/(SUM(t.Horas )*60))*100 As paro14,(SUM(prod.paro15)/(SUM(t.Horas )*60))*100 As paro15,(SUM(prod.paro16)/(SUM(t.Horas )*60))*100 As paro16,(SUM(prod.paro17)/(SUM(t.Horas )*60))*100 As paro17,(SUM(prod.paro18)/(SUM(t.Horas )*60))*100 As paro18,(SUM(prod.paro19)/(SUM(t.Horas )*60))*100 As paro19,(SUM(prod.paro20)/(SUM(t.Horas )*60))*100 As paro20,(SUM(prod.paro21)/(SUM(t.Horas )*60))*100 As paro21,(SUM(prod.paro22)/(SUM(t.Horas )*60))*100 As paro22,(SUM(prod.paro23)/(SUM(t.Horas )*60))*100 As paro23, " & _
                                    "((SUM(paro1 )+SUM (paro2 )+SUM (paro3 )+SUM (paro4 )+SUM (paro5 )+SUM (paro6 )+SUM (paro7 )+ SUM(paro8) + SUM(paro9) + SUM(paro10) + SUM(paro11)+ SUM(paro12)+SUM(paro13 )+SUM (paro14 )+SUM (paro15 )+SUM (paro16 )+SUM (paro17 )+SUM (paro18 )+SUM (paro19 )+ SUM(paro20) + SUM(paro21) + SUM(paro22) + SUM(paro23))/((SUM(t.Horas )*60)))*100 As Paros,(SUM(t_sin_just)/(SUM(t.Horas )*60))*100 As t_sin_just "
                from_sql = "FROM J_prod_puntilleria prod,corsan.dbo.V_nom_personal_Activo_con_maquila ter, J_turnos t,J_seccion_maquina_punt S   "
                where_sql = "WHERE t.Codigo = prod.turno AND ter.nit = prod.nit AND S.maquina = prod.maquina  "
                group_sql = " GROUP by ter.nombres,S.seccion "
                If (cbo_maquina.Text <> "TODOS") Then
                    where_sql += " AND prod.maquina = '" & cbo_maquina.SelectedValue & "'"
                End If
            ElseIf (cboSeccion.Text <> "Seleccione") Then
                select_sql = "SELECT S.seccion ,maq.Nombre as maquina, SUM(prod.horas_trab )As horas_trab ,(SUM(prod.horas_trab)*60) As Min_trab,(SUM(t.Horas )*60)-(COUNT(*)*20) as Min_prog,SUM(kilos_prod )As kilos_prod,SUM(kil_esperado )As kil_esperado,(((SUM (prod.kilos_prod ))/SUM (prod.kil_esperado))*100)As Efic,((SUM(prod.horas_trab)*60)/(SUM((t.Horas )*60)-(COUNT(*)*20)))*100 as porc_rend,(SUM(prod.paro1)/(SUM(t.Horas )*60))*100 As paro1,(SUM(prod.paro2)/(SUM(t.Horas )*60))*100 As paro2,(SUM(prod.paro3)/(SUM(t.Horas )*60))*100 As paro3,(SUM(prod.paro4)/(SUM(t.Horas )*60))*100 As paro4,(SUM(prod.paro5)/(SUM(t.Horas )*60))*100 As paro5,(SUM(prod.paro6)/(SUM(t.Horas )*60))*100 As paro6,(SUM(prod.paro7)/(SUM(t.Horas )*60))*100 As paro7,(SUM(prod.paro8)/(SUM(t.Horas )*60))*100 As paro8,(SUM(prod.paro9)/(SUM(t.Horas )*60))*100 As paro9,(SUM(prod.paro10)/(SUM(t.Horas )*60))*100 As paro10,(SUM(prod.paro11)/(SUM(t.Horas )*60))*100 As paro11,(SUM(prod.paro12)/(SUM(t.Horas )*60))*100 As paro12,(SUM(prod.paro13)/(SUM(t.Horas )*60))*100 As paro13,(SUM(prod.paro14)/(SUM(t.Horas )*60))*100 As paro14,(SUM(prod.paro15)/(SUM(t.Horas )*60))*100 As paro15,(SUM(prod.paro16)/(SUM(t.Horas )*60))*100 As paro16,(SUM(prod.paro17)/(SUM(t.Horas )*60))*100 As paro17,(SUM(prod.paro18)/(SUM(t.Horas )*60))*100 As paro18,(SUM(prod.paro19)/(SUM(t.Horas )*60))*100 As paro19,(SUM(prod.paro20)/(SUM(t.Horas )*60))*100 As paro20,(SUM(prod.paro21)/(SUM(t.Horas )*60))*100 As paro21,(SUM(prod.paro22)/(SUM(t.Horas )*60))*100 As paro22,(SUM(prod.paro23)/(SUM(t.Horas )*60))*100 As paro23, " & _
                             "((SUM(paro1 )+SUM (paro2 )+SUM (paro3 )+SUM (paro4 )+SUM (paro5 )+SUM (paro6 )+SUM (paro7 )+ SUM(paro8) + SUM(paro9) + SUM(paro10) + SUM(paro11)+ SUM(paro12)+SUM(paro13 )+SUM (paro14 )+SUM (paro15 )+SUM (paro16 )+SUM (paro17 )+SUM (paro18 )+SUM (paro19 )+ SUM(paro20) + SUM(paro21) + SUM(paro22) + SUM(paro23))/ (SUM(t.Horas )*60))*100 As Paros,(SUM(t_sin_just)/ (SUM(t.Horas )*60))*100 As t_sin_just "
                from_sql = "FROM J_prod_puntilleria prod,corsan.dbo.V_nom_personal_Activo_con_maquila ter,J_seccion_maquina_punt S,J_Maquinas maq,J_turnos t "
                where_sql = "WHERE  t.Codigo = prod.turno AND ter.nit = prod.nit AND S.maquina = prod.maquina AND prod.maquina = maq.codigoM "
                group_sql = " GROUP by S.seccion,maq.Nombre ORDER BY S.seccion "
                If (cboSeccion.Text <> "TODOS") Then
                    where_sql += " AND S.seccion = '" & cboSeccion.Text & "'"
                End If

            End If
        Else
            If (chk_consol_op.Checked) Then
                If (select_sql = "") Then
                    select_sql = "SELECT prod.nit,ter.nombres"
                    group_sql = "GROUP BY prod.nit,ter.nombres"
                    orderSql = " ORDER BY prod.nit,ter.nombres"
                Else
                    select_sql &= ",prod.nit,ter.nombres"
                    group_sql &= ",prod.nit,ter.nombres"
                    orderSql &= ",prod.nit,ter.nombres"
                End If
            End If
            If (chkConsolSeccion.Checked) Then
                If (select_sql = "") Then
                    select_sql = "SELECT S.seccion"
                    group_sql = "GROUP BY S.seccion"
                    orderSql = " ORDER BY S.seccion"
                Else
                    select_sql &= ",S.seccion"
                    group_sql &= ",S.seccion"
                    orderSql &= ",S.seccion"
                End If
            End If
            If (chkConsolMaquina.Checked) Then
                If (select_sql = "") Then
                    select_sql = "SELECT maq.Nombre As maquina"
                    group_sql = "GROUP BY maq.Nombre"
                    orderSql = " ORDER BY maq.Nombre"
                Else
                    select_sql &= ",maq.Nombre As maquina"
                    group_sql &= ",maq.Nombre"
                    orderSql &= ",maq.Nombre"
                End If
            End If
            If (chkConsolRef.Checked) Then
                If (select_sql = "") Then
                    select_sql = "SELECT ref.descripcion As ref"
                    group_sql = "GROUP BY ref.descripcion"
                    orderSql = " ORDER BY ref.descripcion"
                Else
                    select_sql &= ",ref.descripcion As ref"
                    group_sql &= ",ref.descripcion"
                    orderSql &= ",ref.descripcion"
                End If
            End If
            If select_sql = "" Then
                select_sql = "SELECT  prod.id,prod.fecha ,prod.nit,ter.nombres,S.seccion ,maq.Nombre As maquina,prod.horas_trab,((prod.horas_trab)*60) as Min_trab,((t.Horas )*60)- 20 as Min_prog,t.Descripcion AS turno,kilos_prod,kil_esperado,(((prod.kilos_prod )/prod.kil_esperado )*100)As Efic,(((prod.horas_trab)*60)/((t.Horas )*60)-20)*100 as porc_rend  ,ref.descripcion As ref,ref.codigo,t_sin_just,prod.paro1,prod.paro2,prod.paro3,prod.paro4,prod.paro5,prod.paro6,prod.paro7,prod.paro8,prod.paro9,prod.paro10,prod.paro11,prod.paro12,prod.paro13,prod.paro14,prod.paro15,prod.paro16,prod.paro17,prod.paro18,prod.paro19,prod.paro20,prod.paro21,prod.paro22,prod.paro23," &
                            "(prod.paro1+prod.paro2+prod.paro3+prod.paro4+prod.paro5+prod.paro6+prod.paro7+prod.paro8+prod.paro9+prod.paro10+prod.paro11+prod.paro12+prod.paro13+prod.paro14+prod.paro15+prod.paro16+prod.paro17+prod.paro18+prod.paro19+prod.paro20+prod.paro21+prod.paro22+prod.paro23)As Paros,prod.observaciones "
            Else
                select_sql &= ",SUM(prod.horas_trab )As horas_trab ,(SUM(prod.horas_trab)*60) As Min_trab,(SUM(t.Horas )*60)-(COUNT(*)*20) as Min_prog,SUM(kilos_prod )As kilos_prod,SUM(kil_esperado )As kil_esperado,(((SUM (prod.kilos_prod ))/SUM (prod.kil_esperado))*100)As Efic,((SUM(prod.horas_trab)*60)/((SUM(t.Horas )*60)-(COUNT(*)*20)))*100 as porc_rend,SUM(prod.paro1)As paro1,SUM(prod.paro2)As paro2,SUM(prod.paro3)As paro3,SUM(prod.paro4)As paro4,SUM(prod.paro5)As paro5,SUM(prod.paro6)As paro6,SUM(prod.paro7)As paro7,SUM(prod.paro8)As paro8,SUM(prod.paro9)As paro9,SUM(prod.paro10)As paro10,SUM(prod.paro11)As paro11,SUM(prod.paro12)As paro12,SUM(prod.paro13)As paro13,SUM(prod.paro14)As paro14,SUM(prod.paro15)As paro15,SUM(prod.paro16)As paro16,SUM(prod.paro17)As paro17,SUM(prod.paro18)As paro18,SUM(prod.paro19)As paro19,SUM(prod.paro20)As paro20,SUM(prod.paro21)As paro21,SUM(prod.paro22)As paro22,SUM(prod.paro23)As paro23, " & _
                           "(SUM(paro1 )+SUM (paro2 )+SUM (paro3 )+SUM (paro4 )+SUM (paro5 )+SUM (paro6 )+SUM (paro7 )+ SUM(paro8) + SUM(paro9) + SUM(paro10) + SUM(paro11)+ SUM(paro12)+SUM(paro13 )+SUM (paro14 )+SUM (paro15 )+SUM (paro16 )+SUM (paro17 )+SUM (paro18 )+SUM (paro19 )+ SUM(paro20) + SUM(paro21) + SUM(paro22) + SUM(paro23))As Paros,SUM(t_sin_just)As t_sin_just"
            End If
          
            formato = "N0"
            If (cbo_operario.Text <> "Seleccione") Then
                If (cbo_operario.Text <> "TODOS") Then
                    where_sql += " And prod.nit = " & cbo_operario.SelectedValue
                End If
            End If
            If (cbo_maquina.Text <> "Seleccione") Then
                If (cbo_maquina.Text <> "TODOS") Then
                    where_sql += " AND prod.maquina = '" & cbo_maquina.SelectedValue & "'"
                End If
            End If
            If (cboSeccion.Text <> "Seleccione") Then
                If (cboSeccion.Text <> "TODOS") Then
                    where_sql += " AND S.seccion = '" & cboSeccion.Text & "'"
                End If
            End If
            If (cboRef.Text <> "Seleccione") Then
                If (cboRef.Text <> "TODOS") Then
                    where_sql += " AND  ref.id_ref = " & cboRef.SelectedValue & " "
                End If
            End If
        End If
            sql = select_sql & from_sql & where_sql & group_sql & orderSql
            dt = obj_Ing_prodLn.listar_datatable(sql, "PRODUCCION")
            dt.Rows.Add()
            calcular_totales()
            dtg_consulta.DataSource = dt
            dtg_consulta.Columns("Porc_rend").DefaultCellStyle.Format = "N2"
            dtg_consulta.Columns("Efic").DefaultCellStyle.Format = "N2"
            formatoNegrita(dtg_consulta)
            pintar_col_mod()
            dtg_consulta.Columns("t_sin_just").DefaultCellStyle.Format = formato
            For j = dtg_consulta.Columns("paro1").Index To dtg_consulta.Columns("Paros").Index
                dtg_consulta.Columns(j).DefaultCellStyle.Format = formato
            Next
            For i = 0 To dtg_consulta.Columns.Count - 1
                If (dtg_consulta.Columns(i).Name = "fecha") Then
                    dtg_consulta.Columns(i).DefaultCellStyle.Format = "d"
                ElseIf (dtg_consulta.Columns(i).Name = "nit") Then
                    dtg_consulta.Columns(i).Visible = False
                End If
            Next
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
        dtg_consulta.DataSource = Nothing
        dt = New DataTable
        Dim fec_ini As String = objOpSimples.cambiarFormatoFecha(cbo_fecha_ini.Value.Date)
        Dim fec_fin As String = objOpSimples.cambiarFormatoFecha(cbo_fecha_fin.Value.Date)
        Dim select_sql As String = ""
        Dim from_sql As String = ""
        Dim where_sql As String = ""
        Dim where_sql_fec As String = ""
        Dim group_sql As String = ""
        Dim sql As String = ""
        where_sql_fec += " AND prod.fecha>= '" & fec_ini & "' AND prod.fecha<= '" & fec_fin & "' "
        If (operario <> "Seleccione") Then
            If (chk_porc.Checked) Then
                select_sql = "SELECT ter.nombres , SUM(prod.horas_trab )As horas_trab, (SUM(prod.horas_trab )*60)As Min_trab,(SUM(t.Horas  )*60)As Min_prog,SUM(kilos_prod )As kilos_prod,SUM(kil_esperado )As kil_esperado,(((SUM (prod.kilos_prod ))/SUM (prod.kil_esperado))*100)As Efic,((SUM(prod.horas_trab))*60/(SUM(t.Horas )*60))*100 as porc_rend, " & _
                      "((SUM(paro1 )+SUM (paro2 )+SUM (paro3 )+SUM (paro4 )+SUM (paro5 )+SUM (paro6 )+SUM (paro7 )+ SUM(paro8) + SUM(paro9) + SUM(paro10) + SUM(paro11)+ SUM(paro12)+SUM(paro13 )+SUM (paro14 )+SUM (paro15 )+SUM (paro16 )+SUM (paro17 )+SUM (paro18 )+SUM (paro19 )+ SUM(paro20) + SUM(paro21) + SUM(paro22) + SUM(paro23)) / (SUM(t.Horas  )*60) )* 100 As Paros  "
            Else
                select_sql = "SELECT ter.nombres , SUM(prod.horas_trab )As horas_trab, (SUM(prod.horas_trab )*60) As Min_trab,(SUM(t.Horas  )*60)- 20 As Min_prog,SUM(kilos_prod )As kilos_prod,SUM(kil_esperado )As kil_esperado,(((SUM (prod.kilos_prod ))/SUM (prod.kil_esperado))*100)As Efic,((SUM(prod.horas_trab))*60/(SUM(t.Horas )*60))*100 as porc_rend , " & _
                      "(SUM(paro1 )+SUM (paro2 )+SUM (paro3 )+SUM (paro4 )+SUM (paro5 )+SUM (paro6 )+SUM (paro7 )+ SUM(paro8) + SUM(paro9) + SUM(paro10) + SUM(paro11)+ SUM(paro12)+SUM(paro13 )+SUM (paro14 )+SUM (paro15 )+SUM (paro16 )+SUM (paro17 )+SUM (paro18 )+SUM (paro19 )+ SUM(paro20) + SUM(paro21) + SUM(paro22) + SUM(paro23))As Paros  "
            End If
         
            from_sql = "FROM J_prod_puntilleria prod,corsan.dbo.terceros ter,J_turnos t "
            where_sql = "WHERE prod.turno = t.codigo AND ter.nit = prod.nit"
            group_sql = " GROUP by ter.nombres"
            If (cbo_operario.Text <> "TODOS") Then
                where_sql += " AND prod.nit = " & cbo_operario.SelectedValue
            End If
        End If
        sql = select_sql & from_sql & where_sql & where_sql_fec & group_sql
        dt = obj_Ing_prodLn.listar_datatable(sql, "PRODUCCION")
        dt.Rows.Add()
        dtg_consulta.DataSource = dt
        dtg_consulta.Columns("Efic").DefaultCellStyle.Format = "N2"
        dtg_consulta.Columns("Paros").DefaultCellStyle.Format = "N2"
        dtg_consulta.Columns("porc_rend").DefaultCellStyle.Format = "N2"
        formatoNegrita(dtg_consulta)
        calcular_totales()
    End Sub

    Private Sub ModificarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ModificarToolStripMenuItem.Click
        Dim pos As Integer = dtg_consulta.CurrentCell.RowIndex
        Dim id As String = dtg_consulta("id", pos).Value
        Dim horas_trab As String = dtg_consulta("horas_trab", pos).Value
        Dim fecha As String = dtg_consulta("fecha", pos).Value
        If (id <> "" And horas_trab <> "" And fecha <> "") Then
            If (obj_Ing_prodLn.modif_prod(id, horas_trab, fecha, "J_prod_puntilleria") >= 1) Then
                MessageBox.Show("El registro de modifico en forma correcta! ", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Error al modifico al modificar el registro, verifique que la celda no este en blanco! ", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            MessageBox.Show("Verifique que los items a modificar esten correctamente digitados! ", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub ParosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ParosToolStripMenuItem.Click
        If (carga_completa) Then
            cargar_paros()
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
        If (carga_completa) Then
            carga_completa = False
            imgProcesar.Visible = True
            Application.DoEvents()
            cargar_consulta()
                If (Chart1.Visible = True) Then
                    If (graficoParo) Then
                        If (cbo_maquina.Text <> "Seleccione") Then
                            cargar_paros()
                        End If
                    Else
                        graficar()
                    End If
                End If
            carga_completa = True
            imgProcesar.Visible = False
        End If
    End Sub

    Private Sub chk_porc_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chk_porc.CheckedChanged
        'If (carga_completa) Then
        '    imgProcesar.Visible = True
        '    Application.DoEvents()
        '    Dim t_programado As Double = 0
        '    Dim formato As String = ""
        '    If (chk_porc.Checked) Then
        '        formato = "N2"
        '        For i = 0 To dtg_consulta.Rows.Count - 2
        '            t_programado = dtg_consulta.Item("Min_prog", i).Value
        '            For j = dtg_consulta.Columns("paro1").Index To dtg_consulta.Columns("Paros").Index
        '                If Not IsDBNull(dtg_consulta.Item(j, i).Value) Then
        '                    If Not IsNothing(dtg_consulta.Item(j, i).Value) Then
        '                        If (dtg_consulta.Item(j, i).Value <> 0) Then
        '                            dtg_consulta.Item(j, i).Value = (dtg_consulta.Item(j, i).Value / t_programado) * 100
        '                        End If
        '                    End If
        '                End If
        '            Next
        '        Next
        '    Else
        '        formato = "N0"
        '        For i = 0 To dtg_consulta.Rows.Count - 2
        '            t_programado = dtg_consulta.Item("Min_prog", i).Value
        '            For j = dtg_consulta.Columns("paro1").Index To dtg_consulta.Columns("Paros").Index
        '                If Not IsDBNull(dtg_consulta.Item(j, i).Value) Then
        '                    If Not IsNothing(dtg_consulta.Item(j, i).Value) Then
        '                        If (dtg_consulta.Item(j, i).Value <> 0) Then
        '                            dtg_consulta.Item(j, i).Value = (t_programado * (dtg_consulta.Item(j, i).Value / 10000)) * 100
        '                        End If
        '                    End If
        '                End If
        '            Next
        '        Next
        '    End If
        '    For j = dtg_consulta.Columns("paro1").Index To dtg_consulta.Columns("Paros").Index
        '        dtg_consulta.Columns(j).DefaultCellStyle.Format = formato
        '    Next
        '    imgProcesar.Visible = False
        'End If
    End Sub

  
    Private Sub cboRef_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboRef.SelectedIndexChanged
        dtg_consulta.Focus()
    End Sub
End Class