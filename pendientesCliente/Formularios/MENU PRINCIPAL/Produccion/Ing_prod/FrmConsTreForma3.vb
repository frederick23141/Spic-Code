Imports logicaNegocios
Imports System.Windows.Forms.DataVisualization.Charting
Imports System.Drawing.Imaging
Public Class FrmConsTreForma3
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
        carga_completa = True
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

        If chk_produccion.Checked Then
            where_sql = " WHERE fecha>= '" & fec_ini & "' AND fecha<= '" & fec_fin & "' "
        ElseIf chk_fec_orden.Checked = True Then
            If fec_ini = fec_fin Then
                where_sql = "WHERE year(fecha_creacion) = " & CInt(cbo_fecha_fin.Value.Year) & " and month(fecha_creacion)= " & CInt(cbo_fecha_fin.Value.Month) & " and day(fecha_creacion)=" & CInt(cbo_fecha_fin.Value.Day) & ""
            Else
                where_sql = " WHERE fecha_creacion>= '" & fec_ini & "' AND fecha_creacion<= '" & fec_fin & "' "
            End If
        Else
            where_sql = " WHERE fec_transaccion>= '" & fec_ini & "' AND fec_transaccion<= '" & fec_fin & "' "
        End If
        If (cbo_maquina.Text <> "TODO" And cbo_maquina.Text <> "Seleccione") Then
            where_sql += " AND codigoM= " & cbo_maquina.SelectedValue
        ElseIf (cbo_operario.Text <> "TODO" And cbo_operario.Text <> "Seleccione") Then
            where_sql += " AND nit = " & cbo_operario.SelectedValue
        End If
        If (cbo_turno_ini.Text <> "Seleccione") Then
            where_sql += " AND id_turno >= " & cbo_turno_ini.Text
        End If
        If (cbo_turno_fin.Text <> "Seleccione") Then
            where_sql += " AND id_turno <= " & cbo_turno_fin.Text
        End If
        select_sql = "SELECT id,nit,codigoM,cod_destino,velocidad,h_ini,und_ini,und_fin,destino ,h_fin,id_turno,fecha,consecutivo,id_detalle,maquina,turno,diametro ,nombres,alambron , reproceso , kilos_esp, Min_prog,Min_trab,T_sin_just,fec_transaccion,tran_prod,tran_amarres,tran_no_confor,tran_smpp,paro0, paro1,paro2,paro3,paro4,paro5,paro6,paro7,paro8,paro9,paro10,paro11,paro12,paro13,paro14,Paros,notas,anulado "
        from_sql = "FROM j_v_tref_completo "
        sql = select_sql & from_sql & where_sql & orderSql
        dt = obj_Ing_prodLn.listar_datatable(sql, "PRODUCCION")
        column = New DataColumn("Efic", GetType(Double))
        dt.Columns.Add(column)
        dt.Rows.Add()

        dtg_consulta.DataSource = dt
        formatoNegrita(dtg_consulta)
        ' dtg_consulta.Columns("fecha").DefaultCellStyle.Format = "D"

        dtg_consulta.Columns("btnElim").Visible = False
        dtg_consulta.Columns("Efic").DefaultCellStyle.Format = "N2"
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
        dtg_consulta.Columns("nit").Visible = False
        dtg_consulta.Columns("velocidad").Visible = False
        dtg_consulta.Columns("id_turno").Visible = True
        dtg_consulta.Columns("h_ini").Visible = False
        dtg_consulta.Columns("h_fin").Visible = False
        dtg_consulta.Columns("und_ini").Visible = False
        dtg_consulta.Columns("und_fin").Visible = False
        dtg_consulta.Columns("destino").Visible = False
        dtg_consulta.Columns("codigoM").Visible = False
        dtg_consulta.Columns("cod_destino").Visible = False
        dtg_consulta.Columns("anulado").Visible = False
        totalGrid()
        'calcular_totales(dtg_consulta)
        insertVelEfic()
        marcarAnulados()
    End Sub
    Private Sub marcarAnulados()
        For i = 0 To dtg_consulta.Rows.Count - 1
            For j = 0 To dtg_consulta.Columns.Count - 1
                If (dtg_consulta.Columns(j).Name = "anulado") Then
                    If Not IsDBNull(dtg_consulta.Item(j, i).Value) Then
                        If (dtg_consulta.Item(j, i).Value = 1) Then
                            dtg_consulta.Rows(i).DefaultCellStyle.BackColor = Color.Red
                        End If
                    End If
                End If
            Next
        Next
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
            If (dtg_consulta.Columns(i).Name <> "fec_transaccion" And dtg_consulta.Columns(i).Name <> "tran_prod" And dtg_consulta.Columns(i).Name <> "tran_amarres" And dtg_consulta.Columns(i).Name <> "tran_no_confor" And dtg_consulta.Columns(i).Name <> "tran_smpp" And dtg_consulta.Columns(i).Name <> "id" And dtg_consulta.Columns(i).Name <> "consecutivo" And dtg_consulta.Columns(i).Name <> "id_detalle" And dtg_consulta.Columns(i).Name <> "notas" And dtg_consulta.Columns(i).Name <> "fecha" And dtg_consulta.Columns(i).Name <> "notas" And dtg_consulta.Columns(i).Name <> "nombres" And dtg_consulta.Columns(i).Name <> "maquina" And dtg_consulta.Columns(i).Name <> "Maquina" And dtg_consulta.Columns(i).Name <> "turno" And dtg_consulta.Columns(i).Name <> "diametro") Then
                If (dtg_consulta.Columns(i).Visible = True) Then
                    For j = 0 To dtg_consulta.RowCount - 2
                        If Not IsDBNull(dtg_consulta.Item(i, j).Value) Then
                            sum += dtg_consulta.Item(i, j).Value
                        End If
                    Next
                    dtg_consulta.Item(i, dtg_consulta.RowCount - 1).Value = sum
                    sum = 0
                End If
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
        Dim selectFromSql As String = "SELECT prod." & criterio & ",SUM (prod.reproceso) AS reproceso,SUM (prod.alambron) AS alambron,(SUM (prod.reproceso) + SUM (prod.alambron))AS prod_total,SUM(prod.kilos_esp)AS kilos_esp,SUM(prod.Min_prog)AS Min_prog,SUM(prod.Min_trab)AS Min_trab,SUM(prod.T_sin_just)AS T_sin_just,SUM(prod.paros)AS paros " &
                              "FROM j_v_tref_completo prod "
        Dim whereSql As String
        If chk_fec_orden.Checked = False Then
            whereSql = "WHERE fecha>= '" & fec_ini & "' AND fecha <= '" & fec_fin & "' "
        Else
            If fec_ini = fec_fin Then
                whereSql = "WHERE year(fecha_creacion) = " & CInt(cbo_fecha_fin.Value.Year) & " and month(fecha_creacion)= " & CInt(cbo_fecha_fin.Value.Month) & " and day(fecha_creacion)=" & CInt(cbo_fecha_fin.Value.Day) & ""
            Else
                whereSql = " WHERE fecha_creacion>= '" & fec_ini & "' AND fecha_creacion<= '" & fec_fin & "' "
            End If
        End If
        Dim groupSql As String = " GROUP BY prod." & criterio & " ORDER BY " & criterio & " "

        If (cbo_maquina.Text <> "TODO" And cbo_maquina.Text <> "Seleccione") Then
            whereSql += " AND codigoM= " & cbo_maquina.SelectedValue
        ElseIf (cbo_operario.Text <> "TODO" And cbo_operario.Text <> "Seleccione") Then
            whereSql += " AND nit = " & cbo_operario.SelectedValue
        End If
        If (cbo_turno_ini.Text <> "Seleccione") Then
            whereSql += " AND id_turno >= " & cbo_turno_ini.Text
        End If
        If (cbo_turno_fin.Text <> "Seleccione") Then
            whereSql += " AND id_turno <= " & cbo_turno_fin.Text
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

    'calcular consulta de (hf-hi)- min_trab + paros
    Private Sub calcPorcentajes()
        For i = 0 To dtg_consulta.RowCount - 1
            If Not IsDBNull(dtg_consulta.Item("Min_prog", i).Value) Then
                If Not IsNothing(dtg_consulta.Item("Min_prog", i).Value) Then
                    If (dtg_consulta.Item("Min_prog", i).Value > 0) Then
                        dtg_consulta.Item("porc_rend", i).Value = dtg_consulta.Item("Min_trab", i).Value / dtg_consulta.Item("Min_prog", i).Value * 100
                        dtg_consulta.Item("porc_paro", i).Value = dtg_consulta.Item("paros", i).Value / dtg_consulta.Item("Min_prog", i).Value * 100
                        dtg_consulta.Item("porc_t_sin_just", i).Value = dtg_consulta.Item("T_sin_just", i).Value / dtg_consulta.Item("Min_prog", i).Value * 100
                    End If
                End If
            End If
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
    Private Sub dtg_consulta_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtg_consulta.CellContentClick
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
                    sql = "DELETE FROM J_prod_tref_completo WHERE id =" & id
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

    Private Sub ParosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ParosToolStripMenuItem.Click
        If (carga_completa) Then
            'If (cbo_maquina.Text <> "Seleccione" Or cbo_operario.Text <> "Seleccione") Then
            cargar_paros()
                'Else
                '    MessageBox.Show("Seleccione items a graficar", "Seleccione maquina", MessageBoxButtons.OK, MessageBoxIcon.Error)
                'End If
            End If
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
        sql = "SELECT  SUM (paro0)As paro0,SUM (paro1 )As paro1,SUM (paro2 )As paro2,SUM (paro3 )As paro3,SUM (paro4 )As paro4,SUM (paro5 )As paro5,SUM (paro6 )As paro6,SUM (paro7 )As paro7, " &
                                     "SUM(paro8)As paro8 , SUM(paro9)As paro9, SUM(paro10) As paro10, SUM(paro11) As paro11, SUM(paro12) As paro12, SUM(paro13) As paro13, SUM(paro14) As paro14" &
                                         "FROM j_v_tref_completo  " &
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
                resp = "SOLDAR MP"
            Case 5
                resp = "ENREDOS"
            Case 6
                resp = "DAÑO_ELECTRICO"
            Case 7
                resp = "DAÑO_MECANICO"
            Case 8
                resp = "OTROS"
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
            Case 14
                resp = "ALIST. INICIO TURNO"
        End Select
        Return resp & "(" & numParo & ")"
    End Function
    Private Sub btn_cerrar_graf_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cerrar_graf.Click
        Chart1.Visible = False
        G_consol.Visible = False
        btn_cerrar_graf.Visible = False
    End Sub

    Private Sub guardarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles guardarToolStripMenuItem.Click
        SaveFileDialog1.ShowDialog()
    End Sub

    Private Sub SaveFileDialog1_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles SaveFileDialog1.FileOk
        Dim ruta As String = SaveFileDialog1.FileName
        Chart1.SaveImage(ruta, System.Drawing.Imaging.ImageFormat.Png)
    End Sub

    Private Sub chk_todos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_todos.CheckedChanged
        Dim sql As String = ""
        If (chk_todos.Checked) Then
            sql = "Select nit,nombres   from V_nom_personal_Activo_con_maquila WHERE centro not in (4200) ORDER BY nombres "
        Else
            sql = "Select nit,nombres   from V_nom_personal_Activo_con_maquila WHERE (centro  = 2100 or centro is null) ORDER BY nombres "
        End If
        cbo_operario.DataSource = obj_Ing_prodLn.listar_datatable(sql, "CORSAN")
        cbo_operario.ValueMember = "nit"
        cbo_operario.DisplayMember = "nombres"
        cbo_operario.Text = "Seleccione"
    End Sub

    Private Sub itemMod_Click(sender As System.Object, e As System.EventArgs) Handles itemMod.Click
        If (chk_porc_paros.Checked) Then
            MessageBox.Show("No se puede moficar mientras esta activada la opción de ver porcentajes,desactivela y recargue la consulta", "Desactive los porcentajes", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            moficiar(dtg_consulta.CurrentCell.RowIndex)
        End If
    End Sub
    Private Sub moficiar(ByVal fila As Integer)
        Dim frm As New Frm_ing_emp_punt
        frm.Visible = True
        frm.carga_comp = False
        frm.id_modificar = dtg_consulta.Item("id", fila).Value
        frm.cbo_fecha.Value = dtg_consulta.Item("fecha", fila).Value
        frm.cbo_operario.SelectedValue = dtg_consulta.Item("nit", fila).Value
        frm.cbo_turno.SelectedValue = dtg_consulta.Item("id_turno", fila).Value
        frm.dtg_planilla.Rows.Add()
        frm.dtg_planilla.Item(frm.colVel.Name, 0).Value = dtg_consulta.Item("velocidad", fila).Value
        frm.dtg_planilla.Item(frm.txt_calibre.Name, 0).Value = dtg_consulta.Item("diametro", fila).Value
        frm.dtg_planilla.Item(frm.txt_hora_ini.Name, 0).Value = dtg_consulta.Item("h_ini", fila).Value.ToString
        frm.dtg_planilla.Item(frm.txt_hora_fin.Name, 0).Value = dtg_consulta.Item("h_fin", fila).Value.ToString
        frm.dtg_planilla.Item(frm.txt_un_ini.Name, 0).Value = dtg_consulta.Item("und_ini", fila).Value
        frm.dtg_planilla.Item(frm.txt_uni_fin.Name, 0).Value = dtg_consulta.Item("und_fin", fila).Value
        frm.dtg_planilla.Item(frm.txtAlamb.Name, 0).Value = dtg_consulta.Item("alambron", fila).Value
        frm.dtg_planilla.Item(frm.txt_repr.Name, 0).Value = dtg_consulta.Item("reproceso", fila).Value
        frm.dtg_planilla.Item(frm.id_maquina.Name, 0).Value = dtg_consulta.Item("maquina", fila).Value
        frm.dtg_planilla.Item(frm.cbo_destino.Name, 0).Value = dtg_consulta.Item("destino", fila).Value
        frm.dtg_planilla.Item(frm.col_cod_maquina.Name, 0).Value = dtg_consulta.Item("codigoM", fila).Value
        frm.dtg_planilla.Item(frm.col_cod_destino.Name, 0).Value = dtg_consulta.Item("cod_destino", fila).Value
        frm.txt_estado_modificar.Text = "Modificando id: " & dtg_consulta.Item("id", fila).Value
        frm.operario = dtg_consulta.Item("nit", fila).Value
        If Not IsDBNull(dtg_consulta.Item("notas", fila).Value) Then
            frm.txtNotas.Text = dtg_consulta.Item("notas", fila).Value
        End If
        If Not IsDBNull(dtg_consulta.Item("consecutivo", fila).Value) Then
            frm.consec_ppal = dtg_consulta.Item("consecutivo", fila).Value
            frm.consec_det = dtg_consulta.Item("id_detalle", fila).Value
        End If
        frm.dtg_planilla.Item(frm.txt_p0.Name, 0).Value = dtg_consulta.Item("paro0", fila).Value
        frm.dtg_planilla.Item(frm.txt_p1.Name, 0).Value = dtg_consulta.Item("paro1", fila).Value
        frm.dtg_planilla.Item(frm.txt_p2.Name, 0).Value = dtg_consulta.Item("paro2", fila).Value
        frm.dtg_planilla.Item(frm.txt_p3.Name, 0).Value = dtg_consulta.Item("paro3", fila).Value
        frm.dtg_planilla.Item(frm.txt_p4.Name, 0).Value = dtg_consulta.Item("paro4", fila).Value
        frm.dtg_planilla.Item(frm.txt_p5.Name, 0).Value = dtg_consulta.Item("paro5", fila).Value
        frm.dtg_planilla.Item(frm.txt_p6.Name, 0).Value = dtg_consulta.Item("paro6", fila).Value
        frm.dtg_planilla.Item(frm.txt_p7.Name, 0).Value = dtg_consulta.Item("paro7", fila).Value
        frm.dtg_planilla.Item(frm.txt_p8.Name, 0).Value = dtg_consulta.Item("paro8", fila).Value
        frm.dtg_planilla.Item(frm.txt_p9.Name, 0).Value = dtg_consulta.Item("paro9", fila).Value
        frm.dtg_planilla.Item(frm.txt_p10.Name, 0).Value = dtg_consulta.Item("paro10", fila).Value
        frm.dtg_planilla.Item(frm.txt_p11.Name, 0).Value = dtg_consulta.Item("paro11", fila).Value
        frm.dtg_planilla.Item(frm.txt_p12.Name, 0).Value = dtg_consulta.Item("paro12", fila).Value
        frm.dtg_planilla.Item(frm.txt_p13.Name, 0).Value = dtg_consulta.Item("paro13", fila).Value
        frm.dtg_planilla.Item(frm.txt_p14.Name, 0).Value = dtg_consulta.Item("paro14", fila).Value
        frm.cargar_resultados_modificacion()
        frm.carga_comp = True
    End Sub
    Private Sub dtg_consulta_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles dtg_consulta.MouseDown
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
        carga_completa = False
        chk_porc_paros.Checked = False
        carga_completa = True
        If (chkConsolOp.Checked) Then
            If (chkConsolMaq.Checked) Then
                chkConsolMaq.Checked = False
            End If
            consolidar()
        ElseIf (chkConsolMaq.Checked = True) Then
            consolidar()
        Else
            cargar_consulta()
        End If
        imgProcesar.Visible = False
    End Sub

    Private Sub chkConsolOp_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkConsolOp.CheckedChanged
        If (chkConsolOp.Checked) Then
            cbo_turno_fin.Text = "Seleccione"
            cbo_turno_ini.Text = "Seleccione"
            chkConsolMaq.Checked = False
        Else
            cbo_turno_fin.Text = "Seleccione"
            cbo_turno_ini.Text = "Seleccione"
        End If
    End Sub

    Private Sub chkConsolMaq_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkConsolMaq.CheckedChanged
        If (chkConsolMaq.Checked) Then
            cbo_turno_fin.Text = "Seleccione"
            cbo_turno_ini.Text = "Seleccione"
            chkConsolOp.Checked = False
        Else
            cbo_turno_fin.Text = "Seleccione"
            cbo_turno_ini.Text = "Seleccione"
        End If
    End Sub

    Private Sub chk_porc_paros_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chk_porc_paros.CheckedChanged
        If (carga_completa) Then
            imgProcesar.Visible = True
            Application.DoEvents()
            Dim t_programado As Double = 0
            If (chk_porc_paros.Checked) Then
                For i = 0 To dtg_consulta.Rows.Count - 1
                    t_programado = dtg_consulta.Item("Min_prog", i).Value
                    For j = dtg_consulta.Columns("T_sin_just").Index To dtg_consulta.Columns("paros").Index
                        dtg_consulta.Columns(j).DefaultCellStyle.Format = "N2"
                        If Not IsDBNull(dtg_consulta.Item(j, i).Value) Then
                            If Not IsNothing(dtg_consulta.Item(j, i).Value) Then
                                dtg_consulta.Item(j, i).Value = (dtg_consulta.Item(j, i).Value / t_programado) * 100
                            End If
                        End If
                    Next
                Next
            Else
                For i = 0 To dtg_consulta.Rows.Count - 1
                    t_programado = dtg_consulta.Item("Min_prog", i).Value
                    For j = dtg_consulta.Columns("T_sin_just").Index To dtg_consulta.Columns("paros").Index
                        dtg_consulta.Columns(j).DefaultCellStyle.Format = "N0"
                        If Not IsDBNull(dtg_consulta.Item(j, i).Value) Then
                            If Not IsNothing(dtg_consulta.Item(j, i).Value) Then
                                dtg_consulta.Item(j, i).Value = (t_programado * (dtg_consulta.Item(j, i).Value / 10000)) * 100
                            End If
                        End If
                    Next
                Next
            End If
            imgProcesar.Visible = False
        End If
    End Sub

    Private Sub chk_produccion_CheckedChanged(sender As Object, e As EventArgs) Handles chk_produccion.CheckedChanged
        If carga_completa Then
            carga_completa = False
            If chk_produccion.Checked = True Then
                chk_transaccion.Checked = False
                chk_fec_orden.Checked = False
            ElseIf chk_transaccion.Checked = False Then
                chk_fec_orden.Checked = False
                chk_produccion.Checked = False
            ElseIf chk_fec_orden.Checked = True Then
                chk_produccion.Checked = False
                chk_transaccion.Checked = False
            Else
                chk_produccion.Checked = True
            End If
            carga_completa = True
        End If
    End Sub
    Private Sub chk_transaccion_CheckedChanged(sender As Object, e As EventArgs) Handles chk_transaccion.CheckedChanged
        If carga_completa Then
            carga_completa = False
            If chk_transaccion.Checked Then
                chk_produccion.Checked = False
                chk_fec_orden.Checked = False
            ElseIf chk_produccion.Checked = True Then
                chk_transaccion.Checked = False
                chk_fec_orden.Checked = False

            ElseIf chk_fec_orden.Checked = True Then
                chk_transaccion.Checked = False
                chk_produccion.Checked = False
            Else
                chk_produccion.Checked = True
            End If
            carga_completa = True
        End If
    End Sub

    Private Sub Chk_fec_orden_CheckedChanged(sender As Object, e As EventArgs) Handles chk_fec_orden.CheckedChanged
        If carga_completa Then
            carga_completa = False
            If chk_fec_orden.Checked = True Then
                chk_produccion.Checked = False
                chk_transaccion.Checked = False
            ElseIf chk_produccion.Checked = True Then
                chk_transaccion.Checked = False
                chk_fec_orden.Checked = False
            ElseIf chk_transaccion.Checked = True Then
                chk_fec_orden.Checked = False
                chk_produccion.Checked = False
            Else
                chk_produccion.Checked = True
            End If
            carga_completa = True
        End If
    End Sub

    Private Sub Tsb_Exportar_Click(sender As Object, e As EventArgs) Handles tsb_Exportar.Click
        Dim ruta As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\grafico.png"
        Chart1.SaveImage(ruta, ChartImageFormat.Png)
    End Sub
End Class
