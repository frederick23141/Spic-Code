Imports logicaNegocios
Imports System.Windows.Forms.DataVisualization.Charting

Public Class Frm_consulta_tornilleria
    Private obj_Ing_prodLn As New Ing_prodLn
    Private objOpercionesForm As New OperacionesFormularios
    Dim carga_completa As Boolean = False
    Private objOperacionesForm As New OperacionesFormularios
    Dim ano As Integer = Now.Year
    Dim maquina_paro As String = 0
    Dim objOpSimplesLn As New Op_simpesLn
    Private Sub Frm_consulta_tornilleria_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cbo_fecha_ini.Value = Now.AddDays(-(Now.Day - 1))
        cbo_fecha_fin.Value = Now
        Dim sql As String
        Dim dt As DataTable
        Dim row As DataRow

        sql = "Select nit,nombres  from V_nom_personal_Activo_con_maquila WHERE centro = 2500 ORDER BY nombres "
        dt = obj_Ing_prodLn.listar_datatable(sql, "CORSAN")
        row = dt.NewRow
        row("nit") = 0
        row("nombres") = "TODO"
        dt.Rows.Add(row)
        cbo_operario.DataSource = dt
        cbo_operario.ValueMember = "nit"
        cbo_operario.DisplayMember = "nombres"
        cbo_operario.Text = "TODO"

        sql = "select  codigoM,nombre   from j_Maquinas where TipoMaquina =11 AND activa = 1 "
        dt = New DataTable
        dt = obj_Ing_prodLn.listar_datatable(sql, "PRODUCCION")
        row = dt.NewRow
        row("codigoM") = 0
        row("nombre") = "TODO"
        dt.Rows.Add(row)
        cbo_maquina.DataSource = dt
        cbo_maquina.ValueMember = "codigoM"
        cbo_maquina.DisplayMember = "nombre"
        cbo_maquina.Text = "TODO"

        dt = New DataTable
        sql = "SELECT id,descripcion FROM J_secciones WHERE id >= 10 AND id <= 13 ORDER BY descripcion"
        dt = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")
        row = dt.NewRow
        row("id") = 0
        row("descripcion") = "TODO"
        dt.Rows.Add(row)
        cboSeccion.DataSource = dt
        cboSeccion.ValueMember = "id"
        cboSeccion.DisplayMember = "descripcion"
        cboSeccion.Text = "TODO"
        cargar_consulta()
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
    Private Sub cbo_operario_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_operario.SelectedIndexChanged
        If (carga_completa) Then
            cargar_consulta()
        End If
    End Sub
    Public Sub calcular_totales(ByVal dtg As DataGridView)
        dtg_consulta.Item("nombres", dtg_consulta.RowCount - 1).Value = "TOTAL"
        dtg_consulta.Item("kilos_prod", dtg_consulta.RowCount - 1).Value = sumarColumnas("kilos_prod", dtg_consulta)
        dtg_consulta.Item("kilos_esp", dtg_consulta.RowCount - 1).Value = sumarColumnas("kilos_esp", dtg_consulta)
        dtg_consulta.Item("roy_prod", dtg_consulta.RowCount - 1).Value = sumarColumnas("roy_prod", dtg_consulta)
        dtg_consulta.Item("roy_esp", dtg_consulta.RowCount - 1).Value = sumarColumnas("roy_esp", dtg_consulta)
        dtg_consulta.Item("Efic", dtg_consulta.RowCount - 1).Value = sumarColumnas("Efic", dtg_consulta)
        dtg_consulta.Item("Paros", dtg_consulta.RowCount - 1).Value = sumarColumnas("Paros", dtg_consulta)
        If (cbo_operario.Text <> "Seleccione") Then
            If Not (chk_consol_op.Checked) Then
                dtg_consulta.Item("t_sin_just", dtg_consulta.RowCount - 1).Value = sumarColumnas("t_sin_just", dtg_consulta)
                dtg_consulta.Item("Min_trab", dtg_consulta.RowCount - 1).Value = sumarColumnas("Min_trab", dtg_consulta)
            End If
        End If
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
        If Not (chk_consol_op.Checked) Then
            dtg_consulta.Columns("fecha").DefaultCellStyle.Format = "d"
        End If
    End Sub

    Private Sub btn_excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_excel.Click
        objOperacionesForm.ExportarDatosExcel(dtg_consulta, "Tornilleria")
    End Sub

    Private Sub cbo_maquina_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_maquina.SelectedIndexChanged
        If (carga_completa) Then
            cargar_consulta()
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
    Public Sub cargar_consulta()
        Dim dt As New DataTable
        Dim dr As DataRow
        Dim sql As String = ""
        Dim fec_ini As String = objOpSimplesLn.cambiarFormatoFecha(cbo_fecha_ini.Value.Date)
        Dim fec_fin As String = objOpSimplesLn.cambiarFormatoFecha(cbo_fecha_fin.Value.Date)
        Dim select_sql As String
        Dim whereSql As String
        Dim groupSql As String
        Dim orderSql As String
        If chk_paros.Checked = False Then
            select_sql = "SELECT P.id,det.id_ref as referencia,P.operario As nit_operario,T.nombres As operario,P.fecha,P.seccion As id_seccion,p.maquina As id_maquina ,S.descripcion As sección ,M.Nombre As maquina,Tur.Descripcion as turno,(select tiempo from J_paros_tornilleria paros where paros.id_planilla=p.id and id_paro=1) as paro1, " &
                                           "(select tiempo from J_paros_tornilleria paros where paros.id_planilla=p.id and id_paro=2) as paro2,(select tiempo from J_paros_tornilleria paros where paros.id_planilla=p.id and id_paro=3) as paro3,(select tiempo from J_paros_tornilleria paros where paros.id_planilla=p.id and id_paro=4) as paro4," &
                                           "(select tiempo from J_paros_tornilleria paros where paros.id_planilla=p.id and id_paro=5) as paro5,(select tiempo from J_paros_tornilleria paros where paros.id_planilla=p.id and id_paro=6) as paro6,(select tiempo from J_paros_tornilleria paros where paros.id_planilla=p.id and id_paro=7) as paro7," &
                                           "(select tiempo from J_paros_tornilleria paros where paros.id_planilla=p.id and id_paro=8) as paro8,(select tiempo from J_paros_tornilleria paros where paros.id_planilla=p.id and id_paro=9) as paro9,(select tiempo from J_paros_tornilleria paros where paros.id_planilla=p.id and id_paro=10) as paro10," &
                                            "(select tiempo from J_paros_tornilleria paros where paros.id_planilla=p.id and id_paro=11) as paro11,(select tiempo from J_paros_tornilleria paros where paros.id_planilla=p.id and id_paro=12) as paro12,(select tiempo from J_paros_tornilleria paros where paros.id_planilla=p.id and id_paro=13) as paro13," &
                                            "(select tiempo from J_paros_tornilleria paros where paros.id_planilla=p.id and id_paro=14) as paro14,(select tiempo from J_paros_tornilleria paros where paros.id_planilla=p.id and id_paro=15) as paro15,(select tiempo from J_paros_tornilleria paros where paros.id_planilla=p.id and id_paro=16) as paro16," &
                                            "(select tiempo from J_paros_tornilleria paros where paros.id_planilla=p.id and id_paro=17) as paro17, " &
                                              "SUM (det.kilos ) as producción " &
                                               "FROM J_prod_tornilleria_enc P , corsan.dbo.V_nom_personal_Activo_con_maquila T , J_secciones S , J_Maquinas M,J_turnos Tur , J_prod_tornilleria_det det "
            whereSql = "WHERE P.fecha >= '" & fec_ini & "' AND fecha <= '" & fec_fin & "' AND  T.nit = P.operario  AND S.id = P.seccion AND M.codigoM = P.maquina AND det.id_prod_tornilleria = P.id AND Tur.codigo = P.turno  "
            groupSql = "GROUP BY  P.id,P.operario,det.id_ref,T.nombres,P.fecha,P.seccion,p.maquina ,S.descripcion,M.Nombre,Tur.Descripcion  "

            If (cbo_maquina.Text <> "TODO") Then
                whereSql &= "AND M.codigoM =" & cbo_maquina.SelectedValue
            End If
            If (cbo_operario.Text <> "TODO") Then
                whereSql &= "AND T.nit = " & cbo_operario.SelectedValue
            End If
            If (cboSeccion.Text <> "TODO") Then
                whereSql &= "AND S.id = " & cboSeccion.SelectedValue
            End If
            sql = select_sql & whereSql & groupSql
            dt = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")
            dr = dt.NewRow
            dt.Rows.Add(dr)
            dtg_consulta.DataSource = dt
            dtg_consulta.Columns("nit_operario").Visible = False
            dtg_consulta.Columns("id_seccion").Visible = False
            dtg_consulta.Columns("id_maquina").Visible = False
            totalizar()
            formatoNegrita(dtg_consulta)
            colMoficiar.Visible = True
            colBorrar.Visible = True
        Else
            select_sql = "SELECT p.maquina As id_maquina,M.Nombre As maquina,par.id_paro as nro_paro,sum((par.tiempo)) as minutos" &
                              " FROM J_prod_tornilleria_enc P join J_Maquinas M on P.maquina=M.codigoM  join  J_paros_tornilleria par on P.id=par.id_planilla"
            whereSql = " WHERE P.fecha >= '" & fec_ini & "' AND fecha <= '" & fec_fin & "'"
            groupSql = " GROUP BY p.maquina,M.Nombre,par.id_paro "
            orderSql = " ORDER BY M.nombre,par.id_paro"
            If (cbo_maquina.Text <> "TODO") Then
                whereSql &= "AND M.codigoM =" & cbo_maquina.SelectedValue
            End If
            sql = select_sql & whereSql & groupSql
            dt = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")
            dr = dt.NewRow
            dt.Rows.Add(dr)
            dtg_consulta.DataSource = dt
            dtg_consulta.Columns("id_maquina").Visible = False
            totalizar_paros()
            'formatoNegrita(dtg_consulta)
            colMoficiar.Visible = False
            colBorrar.Visible = False
        End If
    End Sub
    Private Sub totalizar()
        Dim fec_ini As String = objOpSimplesLn.cambiarFormatoFecha(cbo_fecha_ini.Value.Date)
        Dim fec_fin As String = objOpSimplesLn.cambiarFormatoFecha(cbo_fecha_fin.Value.Date)
        Dim sum As Double = 0
        For i = 0 To dtg_consulta.RowCount - 2
            sum += dtg_consulta.Item("producción", i).Value
        Next
        dtg_consulta.Item("operario", dtg_consulta.RowCount - 1).Value = "TOTAL"
        dtg_consulta.Item("producción", dtg_consulta.RowCount - 1).Value = sum
    End Sub
    Private Sub totalizar_paros()
        Dim fec_ini As String = objOpSimplesLn.cambiarFormatoFecha(cbo_fecha_ini.Value.Date)
        Dim fec_fin As String = objOpSimplesLn.cambiarFormatoFecha(cbo_fecha_fin.Value.Date)
        Dim sum As Double = 0
        For i = 0 To dtg_consulta.RowCount - 2
            sum += dtg_consulta.Item("minutos", i).Value
        Next
        dtg_consulta.Item("maquina", dtg_consulta.RowCount - 1).Value = "TOTAL"
        dtg_consulta.Item("minutos", dtg_consulta.RowCount - 1).Value = sum
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
    Private Sub cbo_fecha_ini_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_fecha_ini.ValueChanged
        If (carga_completa) Then
            Dim fec_ini As String = objOpSimplesLn.cambiarFormatoFecha(cbo_fecha_ini.Value.Date)
            Dim fec_fin As String = objOpSimplesLn.cambiarFormatoFecha(cbo_fecha_fin.Value.Date)
            cargar_consulta()
        End If
    End Sub

    Private Sub cbo_fecha_fin_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_fecha_fin.ValueChanged
        If (carga_completa) Then
            Dim fec_ini As String = objOpSimplesLn.cambiarFormatoFecha(cbo_fecha_ini.Value.Date)
            Dim fec_fin As String = objOpSimplesLn.cambiarFormatoFecha(cbo_fecha_fin.Value.Date)
            cargar_consulta()
        End If
    End Sub
    Public Sub conslidar_operario(ByVal operario As String)
        Dim dt As New DataTable
        Dim dr As DataRow
        Dim sql As String = ""
        Dim fec_ini As String = objOpSimplesLn.cambiarFormatoFecha(cbo_fecha_ini.Value.Date)
        Dim fec_fin As String = objOpSimplesLn.cambiarFormatoFecha(cbo_fecha_fin.Value.Date)
        Dim fromSql As String = "FROM J_prod_tornilleria_enc P , corsan.dbo.V_nom_personal_Activo_con_maquila T , J_secciones S , J_Maquinas M ,J_prod_tornilleria_det det  "
        Dim select_sql As String = "SELECT P.operario As nit_operario,T.nombres As operario,P.fecha,P.seccion As id_seccion ,S.descripcion As seccion , " & _
                                          "SUM (det.kilos ) as producción "
        Dim whereSql As String = "WHERE P.fecha >= '" & fec_ini & "' AND fecha <= '" & fec_fin & "' AND T.nit = P.operario  AND S.id = P.seccion AND det.id_prod_tornilleria = P.id AND M.codigoM = P.maquina "
        Dim groupSql As String = " GROUP BY  P.operario,T.nombres,P.fecha,P.seccion ,S.descripcion "


        If (cbo_maquina.Text <> "TODO") Then
            select_sql &= ",M.Nombre As maquina "
            groupSql &= ",M.Nombre "
            whereSql &= "AND M.codigoM =" & cbo_maquina.SelectedValue
        End If
        If (cbo_operario.Text <> "TODO") Then
            whereSql &= "AND T.nit = " & cbo_operario.SelectedValue
        End If
        If (cboSeccion.Text <> "TODO") Then
            whereSql &= "AND S.id = " & cboSeccion.SelectedValue
        End If
        sql = select_sql & fromSql & whereSql & groupSql
        dt = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")
        dr = dt.NewRow
        dt.Rows.Add(dr)
        dtg_consulta.DataSource = dt
        dtg_consulta.Columns("nit_operario").Visible = False
        dtg_consulta.Columns("id_seccion").Visible = False
        totalizar()
        formatoNegrita(dtg_consulta)
        colMoficiar.Visible = False
        colBorrar.Visible = False
    End Sub

    Private Sub chk_consol_op_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_consol_op.CheckedChanged
        If (carga_completa) Then
            If (chk_consol_op.Checked = True) Then
                conslidar_operario(cbo_operario.SelectedValue)
            Else
                cargar_consulta()
            End If
            If chk_paros.Checked = True Then
                chk_paros.Checked = False
            End If
        End If
    End Sub

    Private Sub cboSeccion_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSeccion.SelectedIndexChanged
        If (carga_completa) Then
            cargar_consulta()
        End If
    End Sub


    Private Sub dtg_consulta_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtg_consulta.CellClick
        Dim col As String = dtg_consulta.Columns(e.ColumnIndex).Name
        If (e.RowIndex >= 0) Then
            If (col = colBorrar.Name) Then
                Dim argumento As String = InputBox("ingrese motivo de la mofidicación del procedimiento")
                If (argumento <> "") Then
                    Dim listSql As New List(Of Object)
                    Dim sql As String = ""
                    sql = "DELETE FROM J_paros_tornilleria WHERE id_planilla = " & dtg_consulta.Item("id", e.RowIndex).Value
                    listSql.Add(sql)
                    sql = "DELETE FROM J_prod_tornilleria_det WHERE id_prod_tornilleria = " & dtg_consulta.Item("id", e.RowIndex).Value
                    listSql.Add(sql)
                    Sql = "DELETE FROM J_prod_tornilleria_enc WHERE id = " & dtg_consulta.Item("id", e.RowIndex).Value
                    listSql.Add(sql)
                    If (obj_Ing_prodLn.ExecuteSqlTransaction(listSql, "PRODUCCION")) Then
                        MessageBox.Show("El registro fue eliminado en forma correcta", "Correcto!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        dtg_consulta.Rows.RemoveAt(e.RowIndex)
                    Else
                        MessageBox.Show("Error al eliminar el registro comuniquese con el administrador del sistema ", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If
            ElseIf (col = colMoficiar.Name) Then
                Dim frm As New FrmIngTornilleria
                frm.Show()
                frm.Activate()
                frm.cargar_por_id(dtg_consulta.Item("id", e.RowIndex).Value)
            End If
        End If
    End Sub

    Private Sub Actualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Actualizar.Click
        If (carga_completa) Then
            If (chk_consol_op.Checked = True) Then
                conslidar_operario(cbo_operario.SelectedValue)
            Else
                cargar_consulta()
            End If
        End If
    End Sub

    Private Sub chk_paros_CheckedChanged(sender As Object, e As EventArgs) Handles chk_paros.CheckedChanged
        If chk_consol_op.Checked = True Then
            chk_consol_op.Checked = False
        End If
    End Sub
End Class