Imports logicaNegocios
Imports System.Windows.Forms.DataVisualization.Charting
Public Class FrmConsTref3
    Private obj_Ing_prodLn As New Ing_prodLn
    Private objOpercionesForm As New OperacionesFormularios
    Dim carga_completa As Boolean = False
    Private objOperacionesForm As New OperacionesFormularios
    Private objOpSimplesLn As New Op_simpesLn

    Private Sub FrmConsTref3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cbo_fecha_ini.Value = Now.AddDays(-1)
        cbo_fecha_fin.Value = Now.AddDays(-1)
        cargarMaquinas()
        cargarOperarios()
        cargar_consulta()
        carga_completa = True
    End Sub
    Private Sub cbo_fecha_ini_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_fecha_ini.ValueChanged
        If (carga_completa) Then
            Dim fec_ini As String = cbo_fecha_ini.Value.Date
            Dim fec_fin As String = cbo_fecha_fin.Value.Date
            If (chkConsolMaq.Checked Or chkConsolOp.Checked) Then
                consolidar()
            Else
                cargar_consulta()
            End If
            If (Chart1.Visible = True) Then
                cargar_paros()
            End If
        End If
    End Sub
    Private Sub cbo_fecha_fin_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_fecha_fin.ValueChanged
        If (carga_completa) Then
            Dim fec_ini As String = cbo_fecha_ini.Value.Date
            Dim fec_fin As String = cbo_fecha_fin.Value.Date
            If (chkConsolMaq.Checked Or chkConsolOp.Checked) Then
                consolidar()
            Else
                cargar_consulta()
            End If
            If (Chart1.Visible = True) Then
                cargar_paros()
            End If
        End If
    End Sub
    Public Sub cargar_consulta()
        Dim dt As DataTable
        Dim column As New DataColumn
        Dim select_sql As String = ""
        Dim from_sql As String = ""
        Dim where_sql As String = ""
        Dim sql As String = ""
        Dim orderSql As String = " ORDER BY fecha"
        Dim fec_ini As String = objOpSimplesLn.cambiarFormatoFecha(cbo_fecha_ini.Value.Date)
        Dim fec_fin As String = objOpSimplesLn.cambiarFormatoFecha(cbo_fecha_fin.Value.Date)
        where_sql = " WHERE fecha>= '" & fec_ini & "' AND fecha<= '" & fec_fin & "' "
        If (cbo_maquina.Text <> "TODO" And cbo_maquina.Text <> "Seleccione") Then
            where_sql += " AND codigoM= " & cbo_maquina.SelectedValue
        ElseIf (cbo_operario.Text <> "TODO" And cbo_operario.Text <> "Seleccione") Then
            where_sql += " AND nit = " & cbo_operario.SelectedValue
        End If
        select_sql = "SELECT id,fecha,consecutivo,id_detalle,maquina,diametro ,nombres,alambron , reproceso , kilos_esp, Min_prog,Min_trab,T_sin_just,paro0, paro1,paro2,paro3,paro4,paro5,paro6,paro7,paro8,paro9,paro10,paro11,paro12,paro13,Paros,notas "
        from_sql = "FROM j_v_tref3 "
        sql = select_sql & from_sql & where_sql & orderSql
        dt = obj_Ing_prodLn.listar_datatable(sql, "PRODUCCION")
        column = New DataColumn("Efic", GetType(Double))
        dt.Columns.Add(column)
        dt.Rows.Add()
        dtg_consulta.DataSource = dt
        formatoNegrita(dtg_consulta)
        ' dtg_consulta.Columns("fecha").DefaultCellStyle.Format = "D"
        dtg_consulta.Columns("btnElim").Visible = True
        dtg_consulta.Columns("Efic").DefaultCellStyle.Format = "N1"
        dtg_consulta.Columns("alambron").DefaultCellStyle.Format = "N0"
        dtg_consulta.Columns("reproceso").DefaultCellStyle.Format = "N0"
        dtg_consulta.Columns("kilos_esp").DefaultCellStyle.Format = "N0"
        dtg_consulta.Columns("Min_trab").DefaultCellStyle.Format = "N0"
        dtg_consulta.Columns("T_sin_just").DefaultCellStyle.Format = "N0"
        dtg_consulta.Columns("Min_prog").DefaultCellStyle.Format = "N0"
        dtg_consulta.Columns("paro1").DefaultCellStyle.Format = "N0"
        dtg_consulta.Columns("paro2").DefaultCellStyle.Format = "N0"
        dtg_consulta.Columns("paro3").DefaultCellStyle.Format = "N0"
        dtg_consulta.Columns("paro4").DefaultCellStyle.Format = "N0"
        dtg_consulta.Columns("paro5").DefaultCellStyle.Format = "N0"
        dtg_consulta.Columns("paro6").DefaultCellStyle.Format = "N0"
        dtg_consulta.Columns("paro7").DefaultCellStyle.Format = "N0"
        dtg_consulta.Columns("paro8").DefaultCellStyle.Format = "N0"
        dtg_consulta.Columns("paro9").DefaultCellStyle.Format = "N0"
        dtg_consulta.Columns("paro10").DefaultCellStyle.Format = "N0"
        dtg_consulta.Columns("paro11").DefaultCellStyle.Format = "N0"
        totalGrid()
        'calcular_totales(dtg_consulta)
        insertVelEfic()
    End Sub
    Private Sub totalGrid()
        Dim criterio As String = ""
        If (chkConsolMaq.Checked) Then
            criterio = "Maquina"
        Else
            criterio = "nombres"
        End If
        Dim sum As Double = 0
        For i = 1 To dtg_consulta.ColumnCount - 1
            If (dtg_consulta.Columns(i).Name <> "id" And dtg_consulta.Columns(i).Name <> "consecutivo" And dtg_consulta.Columns(i).Name <> "id_detalle" And dtg_consulta.Columns(i).Name <> "notas" And dtg_consulta.Columns(i).Name <> "fecha" And dtg_consulta.Columns(i).Name <> "notas" And dtg_consulta.Columns(i).Name <> "nombres" And dtg_consulta.Columns(i).Name <> "maquina" And dtg_consulta.Columns(i).Name <> "Maquina") Then
                For j = 0 To dtg_consulta.RowCount - 2
                    If Not IsDBNull(dtg_consulta.Item(i, j).Value) Then
                        sum += dtg_consulta.Item(i, j).Value
                    End If
                Next
                dtg_consulta.Item(i, dtg_consulta.RowCount - 1).Value = sum
                sum = 0
            End If
        Next
        dtg_consulta.Item(criterio, dtg_consulta.RowCount - 1).Value = "TOTAL"
    End Sub
    Public Sub insertVelEfic()
        For fila = 0 To dtg_consulta.RowCount - 1
            If IsDBNull(dtg_consulta.Item("alambron", fila).Value) Then
                dtg_consulta.Item("alambron", fila).Value = 0
            End If
            If IsDBNull(dtg_consulta.Item("reproceso", fila).Value) Then
                dtg_consulta.Item("reproceso", fila).Value = 0
            End If
            If IsDBNull(dtg_consulta.Item("kilos_esp", fila).Value) Then
                dtg_consulta.Item("kilos_esp", fila).Value = 0
            End If

            dtg_consulta.Item("Efic", fila).Value = ((dtg_consulta.Item("alambron", fila).Value + dtg_consulta.Item("reproceso", fila).Value) / dtg_consulta.Item("kilos_esp", fila).Value) * 100
        Next
    End Sub
    Public Sub calcular_totales(ByVal dtg As DataGridView)
        dtg_consulta.Item("nombres", dtg_consulta.RowCount - 1).Value = "TOTAL"
        dtg_consulta.Item("kilos_esp", dtg_consulta.RowCount - 1).Value = sumarColumnas("kilos_esp", dtg_consulta)
        dtg_consulta.Item("Efic", dtg_consulta.RowCount - 1).Value = sumarColumnas("Efic", dtg_consulta)
        dtg_consulta.Item("Paros", dtg_consulta.RowCount - 1).Value = sumarColumnas("Paros", dtg_consulta)
        dtg_consulta.Item("T_sin_just", dtg_consulta.RowCount - 1).Value = sumarColumnas("T_sin_just", dtg_consulta)
        dtg_consulta.Item("Min_trab", dtg_consulta.RowCount - 1).Value = sumarColumnas("Min_trab", dtg_consulta)
        dtg_consulta.Item("alambron", dtg_consulta.RowCount - 1).Value = sumarColumnas("alambron", dtg_consulta)
        dtg_consulta.Item("reproceso", dtg_consulta.RowCount - 1).Value = sumarColumnas("reproceso", dtg_consulta)
        dtg_consulta.Item("Min_prog", dtg_consulta.RowCount - 1).Value = sumarColumnas("Min_prog", dtg_consulta)
    End Sub
    Public Sub formatoNegrita(ByVal dtg As DataGridView)
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        dtg.Columns(0).DefaultCellStyle = DataGridViewCellStyle1
        dtg.Rows(dtg.RowCount - 1).DefaultCellStyle = DataGridViewCellStyle1
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
    Private Sub btn_excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_excel.Click
        objOperacionesForm.ExportarDatosExcel(dtg_consulta, "Trefilación")
    End Sub

    Private Sub chkConsolOp_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkConsolOp.CheckedChanged
        If (chkConsolOp.Checked) Then
            If (chkConsolMaq.Checked) Then
                chkConsolMaq.Checked = False
            End If
            consolidar()
        ElseIf (chkConsolMaq.Checked = False) Then
            cargar_consulta()
        End If

    End Sub

    Private Sub chkConsolMaq_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkConsolMaq.CheckedChanged
        If (chkConsolMaq.Checked) Then
            If (chkConsolOp.Checked) Then
                chkConsolOp.Checked = False
            End If
            consolidar()
        ElseIf (chkConsolOp.Checked = False) Then
            cargar_consulta()
        End If
    End Sub
    Private Sub consolidar()
        dtg_consulta.Columns("btnElim").Visible = False
        Dim criterio As String = ""
        If (chkConsolMaq.Checked) Then
            criterio = "Maquina"
        Else
            criterio = "nombres"
        End If
        Dim dt As DataTable
        Dim column As New DataColumn
        Dim fec_ini As String = objOpSimplesLn.cambiarFormatoFecha(cbo_fecha_ini.Value.Date)
        Dim fec_fin As String = objOpSimplesLn.cambiarFormatoFecha(cbo_fecha_fin.Value.Date)
        Dim selectFromSql As String = "SELECT prod." & criterio & ",SUM (prod.reproceso) AS reproceso,SUM (prod.alambron) AS alambron,SUM (prod.pod_total) AS prod_total,SUM(prod.kilos_esp)AS kilos_esp,SUM(prod.Min_prog)AS Min_prog,SUM(prod.Min_trab)AS Min_trab,SUM(prod.T_sin_just)AS T_sin_just,SUM(prod.paros)AS paros " & _
                              "FROM J_V_TREF3 prod "
        Dim whereSql As String = "WHERE fecha>= '" & fec_ini & "' AND fecha <= '" & fec_fin & "' "
        Dim groupSql As String = "GROUP BY prod." & criterio & " ORDER BY " & criterio & " "

        If (cbo_maquina.Text <> "TODO" And cbo_maquina.Text <> "Seleccione") Then
            whereSql += " AND codigoM= " & cbo_maquina.SelectedValue
        ElseIf (cbo_operario.Text <> "TODO" And cbo_operario.Text <> "Seleccione") Then
            whereSql += " AND nit = " & cbo_operario.SelectedValue
        End If
        Dim sql As String = selectFromSql & whereSql & groupSql


        dt = obj_Ing_prodLn.listar_datatable(sql, "PRODUCCION")
        column = New DataColumn("Efic", GetType(Double))
        dt.Columns.Add(column)
        column = New DataColumn("porc_rend", GetType(Double))
        dt.Columns.Add(column)
        column = New DataColumn("porc_paro", GetType(Double))
        dt.Columns.Add(column)
        column = New DataColumn("porc_t_sin_just", GetType(Double))
        dt.Columns.Add(column)
        dt.Rows.Add()
        dtg_consulta.DataSource = dt
        formatoNegrita(dtg_consulta)
        dtg_consulta.Columns("Efic").DefaultCellStyle.Format = "N1"
        dtg_consulta.Columns("porc_rend").DefaultCellStyle.Format = "N1"
        dtg_consulta.Columns("porc_paro").DefaultCellStyle.Format = "N1"
        dtg_consulta.Columns("porc_t_sin_just").DefaultCellStyle.Format = "N1"

        dtg_consulta.Columns("alambron").DefaultCellStyle.Format = "N0"
        dtg_consulta.Columns("reproceso").DefaultCellStyle.Format = "N0"
        dtg_consulta.Columns("kilos_esp").DefaultCellStyle.Format = "N0"
        dtg_consulta.Columns("Min_trab").DefaultCellStyle.Format = "N0"
        dtg_consulta.Columns("T_sin_just").DefaultCellStyle.Format = "N0"
        dtg_consulta.Columns("Min_prog").DefaultCellStyle.Format = "N0"
        dtg_consulta.Columns("prod_total").DefaultCellStyle.Format = "N0"
        totalGrid()
        insertVelEfic()
        calcPorcentajes()
    End Sub
    Private Sub calcPorcentajes()
        For i = 0 To dtg_consulta.RowCount - 1
            dtg_consulta.Item("porc_rend", i).Value = dtg_consulta.Item("Min_trab", i).Value / dtg_consulta.Item("Min_prog", i).Value * 100
            dtg_consulta.Item("porc_paro", i).Value = dtg_consulta.Item("paros", i).Value / dtg_consulta.Item("Min_prog", i).Value * 100
            dtg_consulta.Item("porc_t_sin_just", i).Value = dtg_consulta.Item("T_sin_just", i).Value / dtg_consulta.Item("Min_prog", i).Value * 100
        Next
    End Sub
    Private Sub calc_porcentajes()
        For fila = 0 To dtg_consulta.RowCount - 1
            If IsDBNull(dtg_consulta.Item("alambron", fila).Value) Then
                dtg_consulta.Item("alambron", fila).Value = 0
            End If
            If IsDBNull(dtg_consulta.Item("reproceso", fila).Value) Then
                dtg_consulta.Item("reproceso", fila).Value = 0
            End If
            If IsDBNull(dtg_consulta.Item("kilos_esp", fila).Value) Then
                dtg_consulta.Item("kilos_esp", fila).Value = 0
            End If
            If IsDBNull(dtg_consulta.Item("Min_prog", fila).Value) Then
                dtg_consulta.Item("Min_prog", fila).Value = 0
            End If
            If (dtg_consulta.Item("Min_prog", fila).Value = 0) Then

            End If
            dtg_consulta.Item("porc_rend", fila).Value = ((dtg_consulta.Item("Min_trab", fila).Value) / dtg_consulta.Item("Min_prog", fila).Value) * 100
            dtg_consulta.Item("porc_paro", fila).Value = ((dtg_consulta.Item("paros", fila).Value) / dtg_consulta.Item("Min_prog", fila).Value) * 100
            dtg_consulta.Item("porc_t_sin_just", fila).Value = ((dtg_consulta.Item("T_sin_just", fila).Value) / dtg_consulta.Item("Min_prog", fila).Value) * 100

        Next

    End Sub
    Private Sub dtg_consulta_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        Dim motivo As String = ""
        Dim col As String = dtg_consulta.Columns(e.ColumnIndex).Name
        Dim fila As Integer = e.RowIndex
        Dim id As String = ""
        Dim resp As Integer = 0
        Dim sql As String = ""
        If (col = "btnElim") Then
            motivo = InputBox("Ingrese el motivo de la anulación del consecutivo, luego presione aceptar", "Motivo")
            If (motivo <> "") Then
                motivo &= " - anulado, pc:" & My.Computer.Name & "-" & Now
                If (e.RowIndex <> dtg_consulta.RowCount - 1) Then
                    id = dtg_consulta.Item("id", e.RowIndex).Value
                    sql = "UPDATE  J_prod_tref_prueb SET anulado = 1 , notas += '" & motivo & "' WHERE id =" & id
                    resp = objOpSimplesLn.ejecutar(sql, "PRODUCCION")
                    If (resp > 0) Then
                        MessageBox.Show("El registro de elimino en forma exitosa ", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        dtg_consulta.CurrentCell = Nothing
                        dtg_consulta.Rows(fila).Visible = False
                    Else
                        MessageBox.Show("Error al eliminar el registro, comuniquese con el area de sistemas ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If
            End If
        End If
    End Sub
    Private Sub cargarMaquinas()
        Dim dt As New DataTable
        Dim dr As DataRow
        dt = obj_Ing_prodLn.listarMaquinas("1")
        dr = dt.NewRow
        dr("codigoM") = 0
        dr("nombre") = "TODO"
        dt.Rows.Add(dr)
        cbo_maquina.DataSource = dt
        cbo_maquina.ValueMember = "codigoM"
        cbo_maquina.DisplayMember = "nombre"
        cbo_maquina.Text = "Seleccione"
    End Sub
    Private Sub cargarOperarios()
        Dim dt As New DataTable
        Dim dr As DataRow
        dt = obj_Ing_prodLn.listarOperarios(2100)
        dr = dt.NewRow
        dr("nit") = 0
        dr("nombres") = "TODO"
        dt.Rows.Add(dr)
        cbo_operario.DataSource = dt
        cbo_operario.ValueMember = "nit"
        cbo_operario.DisplayMember = "nombres"
        cbo_operario.Text = "Seleccione"
    End Sub

    Private Sub cbo_operario_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_operario.SelectedIndexChanged
        If (carga_completa) Then
            carga_completa = False
            cbo_maquina.Text = "Seleccione"
            If (chkConsolMaq.Checked Or chkConsolOp.Checked) Then
                consolidar()
            Else
                cargar_consulta()
            End If
            If (Chart1.Visible = True) Then
                cargar_paros()
            End If
            carga_completa = True
        End If
    End Sub

    Private Sub cbo_maquina_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_maquina.SelectedIndexChanged
        If (carga_completa) Then
            carga_completa = False
            cbo_operario.Text = "TODO"
            If (chkConsolMaq.Checked Or chkConsolOp.Checked) Then
                consolidar()
            Else
                cargar_consulta()
            End If
            If (Chart1.Visible = True) Then
                cargar_paros()
            End If
            carga_completa = True
        End If
    End Sub

    Private Sub ParosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ParosToolStripMenuItem.Click

    End Sub
    Private Sub cargar_paros()
        btn_cerrar_graf.Visible = True
        Chart1.Visible = True
        G_consol.Visible = True
        Dim mes As Integer = 0
        Dim where_fec As String = ""
        Dim whereOperario As String = ""
        Dim whereMaquina As String = ""
        Dim sql As String = ""
        Dim nomb_paro As String = ""
        where_fec = " WHERE fecha>= '" & objOpSimplesLn.cambiarFormatoFecha(cbo_fecha_ini.Value.Date) & "' AND fecha<= '" & objOpSimplesLn.cambiarFormatoFecha(cbo_fecha_fin.Value.Date) & "' "

        If (cbo_operario.Text <> "TODO" And cbo_operario.Text <> "Seleccione") Then
            whereOperario = " AND nit = " & cbo_operario.SelectedValue
        End If
        If (cbo_maquina.Text <> "TODO" And cbo_maquina.Text <> "Seleccione") Then
            whereMaquina = " AND codigoM = " & cbo_maquina.SelectedValue
        End If
        sql = "SELECT  SUM (paro0)As paro0,SUM (paro1 )As paro1,SUM (paro2 )As paro2,SUM (paro3 )As paro3,SUM (paro4 )As paro4,SUM (paro5 )As paro5,SUM (paro6 )As paro6,SUM (paro7 )As paro7, " & _
                                     "SUM(paro8)As paro8 , SUM(paro9)As paro9, SUM(paro10) As paro10, SUM(paro11) As paro11, SUM(paro12) As paro12, SUM(paro13) As paro13 " & _
                                         "FROM J_V_TREF3  " & _
                                            where_fec & " " & whereMaquina & " " & whereOperario
        Dim vec() As Object = obj_Ing_prodLn.vec_paros(sql, 13)
        Chart1.Visible = True
        Chart1.Titles.Clear()
        Chart1.Series.Clear()
        Chart1.ChartAreas.Clear()
        Chart1.ChartAreas.Add(0)
        For i = 0 To vec.Length - 1
            nomb_paro = desc_paro(i)
            Chart1.Series.Add(nomb_paro)
            Chart1.Series(nomb_paro).Points.AddXY("", vec(i))
            Chart1.Series(nomb_paro).IsValueShownAsLabel = True
            Chart1.Series(nomb_paro)("PointWidth") = "1.5"
            Chart1.Series(nomb_paro).ToolTip = nomb_paro

        Next
        Chart1.ChartAreas(0).AxisX.Title = "Paros"
        Chart1.ChartAreas(0).AxisY.Title = "Tiempo (minutos)"
        Chart1.ChartAreas(0).Area3DStyle.Enable3D = False
        Chart1.Refresh()
    End Sub
    Private Function desc_paro(ByVal numParo As Integer) As String
        Dim resp As String = ""
        Select Case numParo
            Case 0
                resp = "ASEO"
            Case 1
                resp = "CAMBIO_DE_PROGRAMA"
            Case 2
                resp = "REVIENTE"
            Case 3
                resp = "CAMBIO_DE_HILERA"
            Case 4
                resp = "SOLDAR"
            Case 5
                resp = "ENREDOS"
            Case 6
                resp = "DAÑO_ELECTRICO"
            Case 7
                resp = "DAÑO_MECANICO"
            Case 8
                resp = "PARO_PROGRAMADO"
            Case 9
                resp = "ALIMENTACION"
            Case 10
                resp = "PROBLEMAS_MATERIA_PRIMA"
            Case 11
                resp = "ABASTECIMIENTO"
            Case 12
                resp = "CAPACITACION_Y/O_REUNION"
            Case 13
                resp = "MANTENIMIENTO_PROGRAMADO"
        End Select
        Return resp & "(" & numParo & ")"
    End Function
    Private Sub btn_cerrar_graf_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Chart1.Visible = False
        G_consol.Visible = False
        btn_cerrar_graf.Visible = False
    End Sub

    Private Sub guardarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles guardarToolStripMenuItem.Click

    End Sub

    Private Sub SaveFileDialog1_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles SaveFileDialog1.FileOk

    End Sub

    Private Sub chk_todos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_todos.CheckedChanged
        Dim sql As String = ""
        If (chk_todos.Checked) Then
            sql = "Select nit,nombres   from V_nom_personal_Activo_con_maquila WHERE centro not in (4200) ORDER BY nombres "
        Else
            sql = "Select nit,nombres   from V_nom_personal_Activo_con_maquila WHERE centro  = 2100 ORDER BY nombres "
        End If
        cbo_operario.DataSource = obj_Ing_prodLn.listar_datatable(sql, "CORSAN")
        cbo_operario.ValueMember = "nit"
        cbo_operario.DisplayMember = "nombres"
        cbo_operario.Text = "Seleccione"
    End Sub

End Class
