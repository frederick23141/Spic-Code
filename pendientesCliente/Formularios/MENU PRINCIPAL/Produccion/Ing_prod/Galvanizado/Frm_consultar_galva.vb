Imports logicaNegocios
Imports System.Windows.Forms.DataVisualization.Charting

Public Class Frm_consultar_galva
    Private obj_Ing_prodLn As New Ing_prodLn
    Private objOpercionesForm As New OperacionesFormularios
    Dim carga_completa As Boolean = False
    Private objOperacionesForm As New OperacionesFormularios
    Private objOpSimplesLn As New Op_simpesLn
    Private Sub Frm_consultar_galva_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cbo_fecha_ini.Value = Now.AddDays(-1)
        cbo_fecha_fin.Value = Now.AddDays(-1)
        Dim sql As String = "select Codigo,Descripcion from J_turnos  "
        Dim dt As DataTable = obj_Ing_prodLn.listar_datatable(sql, "PRODUCCION")
        Dim col As New DataColumn
        Dim dr As DataRow
        dr = dt.NewRow
        dr("Codigo") = 0
        dr("Descripcion") = "TODOS"
        dt.Rows.Add(dr)
        cbo_turno.DataSource = dt
        cbo_turno.ValueMember = "Codigo"
        cbo_turno.DisplayMember = "Descripcion"
        cbo_turno.Text = "TODOS"
        carga_completa = True
        cargar_consulta()
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
        objOpercionesForm.ExportarDatosExcel(dtg_consulta, "Galvanizado")
    End Sub
    Public Sub calcular_totales(ByVal dtg As DataGridView)
        dtg_consulta.Item("referencia", dtg_consulta.RowCount - 1).Value = "TOTAL"
        dtg_consulta.Item("kilos_prod", dtg_consulta.RowCount - 1).Value = sumarColumnas("kilos_prod", dtg_consulta)
        'dtg_consulta.Item("Paros", dtg_consulta.RowCount - 1).Value = sumarColumnas("Paros", dtg_consulta)
        'If Not (chk_consol_tur.Checked) Then
        '    dtg_consulta.Item("Paro1", dtg_consulta.RowCount - 1).Value = sumarColumnas("Paro1", dtg_consulta)
        '    dtg_consulta.Item("Paro2", dtg_consulta.RowCount - 1).Value = sumarColumnas("Paro2", dtg_consulta)
        '    dtg_consulta.Item("Paro3", dtg_consulta.RowCount - 1).Value = sumarColumnas("Paro3", dtg_consulta)
        '    dtg_consulta.Item("Paro4", dtg_consulta.RowCount - 1).Value = sumarColumnas("Paro4", dtg_consulta)
        '    dtg_consulta.Item("Paro5", dtg_consulta.RowCount - 1).Value = sumarColumnas("Paro5", dtg_consulta)
        '    dtg_consulta.Item("Paro6", dtg_consulta.RowCount - 1).Value = sumarColumnas("Paro6", dtg_consulta)
        '    dtg_consulta.Item("Paro7", dtg_consulta.RowCount - 1).Value = sumarColumnas("Paro7", dtg_consulta)
        '    dtg_consulta.Item("Paro8", dtg_consulta.RowCount - 1).Value = sumarColumnas("Paro8", dtg_consulta)
        '    dtg_consulta.Item("Paro9", dtg_consulta.RowCount - 1).Value = sumarColumnas("Paro9", dtg_consulta)
        'End If
        dtg_consulta.Item("Min_trab", dtg_consulta.RowCount - 1).Value = sumarColumnas("Min_trab", dtg_consulta)
    End Sub
    Private Function sumarColumnas(ByVal nomColumna As String, ByVal dtg As DataGridView) As Double
        Dim total As Double = 0
        For i As Integer = 0 To dtg.RowCount - 1
            total = total + CDbl(dtg.Item(nomColumna.ToLower, i).Value)
        Next
        Return total
    End Function
    Public Sub formatoNegrita(ByVal dtg As DataGridView)
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        dtg.Columns(0).DefaultCellStyle = DataGridViewCellStyle1
        dtg.Rows(dtg.RowCount - 1).DefaultCellStyle = DataGridViewCellStyle1
        If (chkConsolDia.Checked) Then
            dtg_consulta.Columns("fecha").DefaultCellStyle.Format = "d"
        End If
    End Sub
    Private Sub cargar_paros(ByVal turno As String)
        btn_cerrar_graf.Visible = True
        Chart1.Visible = True
        G_grafico.Visible = True
        Dim sql As String
        Dim where_fec As String = ""
        Dim max As Double = 0
        Dim fec_ini As String = objOpSimplesLn.cambiarFormatoFecha(cbo_fecha_ini.Value.Date)
        Dim fec_fin As String = objOpSimplesLn.cambiarFormatoFecha(cbo_fecha_fin.Value.Date)
        where_fec = " WHERE fecha>= '" & fec_ini & "' AND fecha<= '" & fec_fin & "' "
        If (turno = "TODOS") Then
            sql = "SELECT  SUM (paro1 )As paro1,SUM (paro2 )As paro2,SUM (paro3 )As paro3,SUM (paro4 )As paro4,SUM (paro5 )As paro5,SUM (paro6 )As paro6,SUM (paro7 )As paro7, " & _
                                     "SUM(paro8)As paro8 , SUM(paro9)As paro9 " & _
                                         "FROM J_prod_galv  " & _
                                           where_fec

        Else
            sql = "SELECT  SUM (prod.paro1 )As paro1,SUM (prod.paro2 )As paro2,SUM (prod.paro3 )As paro3,SUM (prod.paro4 )As paro4,SUM (prod.paro5 )As paro5,SUM (prod.paro6 )As paro6,SUM (prod.paro7 )As paro7, " & _
                                     "SUM(prod.paro8)As paro8 , SUM(prod.paro9)As paro9 " & _
                                         "FROM J_prod_galv prod,J_turnos tur " & _
                                            where_fec & "AND prod.turno = tur.codigo AND tur.codigo = '" & cbo_turno.SelectedValue & "' "
        End If
        Dim mat(,) As Object = obj_Ing_prodLn.mat_paros(sql, 8)
        Chart1.Visible = True
        Chart1.Titles.Clear()
        Chart1.Series.Clear()
        Chart1.ChartAreas.Clear()
        Chart1.ChartAreas.Add(0)
        For i = 0 To 8
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
    Private Sub ProducciónToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        G_grafico.Visible = True
        If (cbo_turno.Text <> "Seleccione") Then
            chk_prod.Checked = True
            graficar()
        Else
            MessageBox.Show("Seleccione items de consulta para graficar! ", "Campos", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub
    Public Sub graficar()
        If (cbo_turno.Text <> "Seleccione") Then
            btn_cerrar_graf.Visible = True
            Chart1.Visible = True
            Dim fec_ini As String = objOpSimplesLn.cambiarFormatoFecha(cbo_fecha_ini.Value.Date)
            Dim fec_fin As String = objOpSimplesLn.cambiarFormatoFecha(cbo_fecha_fin.Value.Date)
            Dim dias As Integer = ((cbo_fecha_fin.Value.Date - cbo_fecha_ini.Value.Date).Days) + 1
            Dim sql As String = ""
            Dim select_from As String = "SELECT SUM (kilos_prod) As Kilos ,DAY (fecha )" & _
                                        "FROM J_prod_galv "
            Dim where_sql As String = ""
            Dim criterio As String = ""
            Dim group As String = " GROUP by DAY (fecha ) , MONTH (fecha ) "
            Dim order As String = " ORDER by MONTH (fecha )"
            If (cbo_turno.Text <> "TODOS") Then
                criterio = " AND turno = " & cbo_turno.SelectedValue
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
            Chart1.ChartAreas(0).AxisX.Title = "DÌAS"
            Chart1.ChartAreas(0).AxisY.Title = "Kilos producidos"
            Chart1.Refresh()
        Else
            MessageBox.Show("Seleccione turno(s) a graficar ! ", "Seleccione", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Private Sub btn_cerrar_graf_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Chart1.Visible = False
        G_grafico.Visible = False
        btn_cerrar_graf.Visible = False
    End Sub



    Private Sub btn_excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        objOperacionesForm.ExportarDatosExcel(dtg_consulta, "Galvanizado")
    End Sub
    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FrmPrincipal.Show()
        Me.Close()
        FrmPrincipal.Activate()
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FrmLogin.Show()
        FrmPrincipal.Close()
        Me.Close()
    End Sub
    Private Sub EliminarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EliminarToolStripMenuItem.Click
        Dim pos As Integer = dtg_consulta.CurrentCell.RowIndex
        If (pos <> dtg_consulta.RowCount - 1) Then
            Dim id = dtg_consulta("id", pos).Value
            Dim sql As String = "DELETE FROM J_prod_galv WHERE id = " & id
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
        If (cbo_turno.Text <> "Seleccione") Then
            Dim select_sql As String = ""
            Dim sql As String = ""
            Dim from_sql As String = ""
            Dim sFec_ini As String = objOpSimplesLn.cambiarFormatoFecha(cbo_fecha_ini.Value.Date)
            Dim sFec_fin As String = objOpSimplesLn.cambiarFormatoFecha(cbo_fecha_fin.Value.Date)
            Dim groupSql As String = "GROUP BY cal.descripcion  "
            If (chk_consol_ref.Checked) Then
                select_sql = "SELECT cal.descripcion As referencia,d.descripcion As destino,SUM(prod.horas_trab * 60) as Min_trab,SUM(tur.Horas * 60)As min_turno,SUM(kilos_prod)As kilos_prod "
                groupSql &= ",d.descripcion"
            ElseIf (chk_consol_tur.Checked) Then
                select_sql = "SELECT cal.descripcion As referencia,tur.descripcion as Turno,d.descripcion As destino,SUM(prod.horas_trab * 60) as Min_trab,SUM(tur.Horas * 60)As min_turno,SUM(kilos_prod)As kilos_prod "
                groupSql &= ",tur.descripcion,d.descripcion "
            ElseIf (chkConsolDia.Checked) Then
                select_sql = "SELECT cal.descripcion  As referencia,prod.fecha ,d.descripcion As destino,SUM(prod.horas_trab * 60) as Min_trab,SUM(tur.Horas * 60)As min_turno,SUM(kilos_prod)As kilos_prod "
                groupSql &= ", prod.fecha,d.descripcion "
            End If
            Dim criterio As String = "WHERE d.id = prod.destino AND prod.calibre = cal.id AND tur.codigo = prod.turno AND prod.fecha>= '" & sFec_ini & "' AND prod.fecha<= '" & sFec_fin & "' "
            from_sql = " FROM j_turnos tur,j_prod_galv prod ,j_calibres cal,J_destino_galv d "
            If (cbo_turno.Text <> "TODOS") Then
                criterio += " AND prod.turno = " & cbo_turno.SelectedValue & " "
                menStripDtg.Enabled = True
            End If
            sql = select_sql + from_sql + criterio + groupSql
            dtg_consulta.DataSource = obj_Ing_prodLn.listar_datatable(sql, "PRODUCCION")
            formatoNegrita(dtg_consulta)
            calcular_totales(dtg_consulta)
            pintar_col_mod()
            If (Chart1.Visible = True) Then
                If (chk_paro.Checked) Then
                    If (cbo_turno.Text <> "TODOS" Or cbo_turno.Text = "Seleccione") Then
                        If (cbo_turno.Text <> "") Then
                            cargar_paros(cbo_turno.SelectedValue)
                        Else
                            cargar_paros("TODO")
                        End If

                    Else
                        cargar_paros(cbo_turno.SelectedValue)
                    End If
                Else
                    graficar()
                End If
            End If
        Else
            MessageBox.Show("Seleccione operario ó maquina a consultar! ", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            Dim fec_ini As String = objOpSimplesLn.cambiarFormatoFecha(cbo_fecha_ini.Value.Date)
            Dim fec_fin As String = objOpSimplesLn.cambiarFormatoFecha(cbo_fecha_fin.Value.Date)
             cargar_consulta()
            If (Chart1.Visible = True) Then
                If (chk_prod.Checked) Then
                    graficar()
                ElseIf (chk_paro.Checked) Then
                    If (cbo_turno.Text <> "Seleccione") Then
                        cargar_paros(cbo_turno.Text)
                    Else
                        MessageBox.Show("Seleccione maquina a graficar", "Seleccione maquina", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If

                End If
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
                If (cbo_turno.Text = "TODOS") Then
                    cargar_paros("TODOS")
                Else
                    cargar_paros(cbo_turno.SelectedValue)
                End If

                chk_prod.Checked = False
            Else
                chk_prod.Checked = True
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
        If (cbo_turno.Text <> "Seleccione") Then
            chk_paro.Checked = False
            chk_paro.Checked = True
        Else
            MessageBox.Show("Seleccione turno a graficar! ", "Seleccione", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

    Private Sub chk_consol_tur_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_consol_tur.CheckedChanged
        If (carga_completa) Then
            If (chk_consol_tur.Checked = True) Then
                carga_completa = False
                chkConsolDia.Checked = False
                chk_consol_ref.Checked = False
                 cargar_consulta()
                menStripDtg.Enabled = False
                carga_completa = True
            Else
                cargar_consulta()
                menStripDtg.Enabled = True
            End If
        End If
    End Sub

    Private Sub cbo_turno_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_turno.SelectedIndexChanged
        If (carga_completa) Then
            If (cbo_turno.Text <> "Seleccione") Then
                cargar_consulta()
            End If
        End If
    End Sub

    
    Private Sub chkConsolDia_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkConsolDia.CheckedChanged
        If (carga_completa) Then
            carga_completa = False
            chk_consol_tur.Checked = False
            chk_consol_ref.Checked = False
            carga_completa = True
            cargar_consulta()

        End If
    End Sub

    Private Sub cbo_fecha_ini_ValueChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_fecha_ini.ValueChanged
        If (carga_completa) Then
         cargar_consulta()
        End If
    End Sub

    Private Sub cbo_fecha_fin_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_fecha_fin.ValueChanged
        If (carga_completa) Then
            cargar_consulta()
        End If
    End Sub

    Private Sub chk_consol_ref_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chk_consol_ref.CheckedChanged
        If (carga_completa) Then
            carga_completa = False
            chk_consol_tur.Checked = False
            chkConsolDia.Checked = False
            carga_completa = True
            cargar_consulta()
        End If
    End Sub
End Class