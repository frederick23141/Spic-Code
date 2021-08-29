Imports logicaNegocios
Imports entidadNegocios
Public Class Frm_consultar_eval_desempeno
    Private objOpSimplesLn As New Op_simpesLn
    Private objIngresoProdLn As New Ing_prodLn
    Private objOperacionesForm As OperacionesFormularios = New OperacionesFormularios
    Private carga_comp As Boolean = False
    Dim usuario As String
    Dim objUsuarioEn As UsuarioEn
    Dim dt_permisos As New DataTable
    Dim centros As String = ""
    Dim consol As Boolean = False
    Private Sub Frm_consultar_eval_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cboFechaIni.Value = Now.AddMonths(-3)
        cboFechaFin.Value = Now
    End Sub
    Public Sub Main(ByVal objUsuarioEn As UsuarioEn)
        Me.usuario = objUsuarioEn.usuario
        Me.objUsuarioEn = objUsuarioEn
        Dim dt As New DataTable
        Dim dr As DataRow
        Dim sql As String
        Dim nit As Double = objUsuarioEn.nit
        Dim sql_criterios_centros As String = ""
        Dim db As String = ""
        cargarCbo()


        If (objUsuarioEn.permiso.Trim <> "ADMIN" And objUsuarioEn.permiso.Trim <> "NOMINA") Then
            sql_criterios_centros = "SELECT centro FROM J_coordinador_centros_costos WHERE nit =" & nit
            db = "PRODUCCION"
        Else
            sql_criterios_centros = "SELECT centro FROM V_nom_personal_Activo_con_maquila GROUP BY centro"
            db = "CORSAN"
        End If
        Dim listCentros As DataTable = objOpSimplesLn.listar_datatable(sql_criterios_centros, db)
        For i = 0 To listCentros.Rows.Count - 1
            centros &= listCentros.Rows(i).Item("centro")
            If centros <> "" Then
                If (i <> listCentros.Rows.Count - 1) Then
                    centros &= ","
                End If
            End If
        Next
        Dim where_sql As String = ""
        If centros = "" Then
            where_sql &= ""
        Else
            where_sql &= "WHERE centro IN(" & centros & ")"
        End If

        Sql = "SELECT centro,( CAST (centro AS varchar(25))+ '-' + descripcion )As descripcion " & _
                        "FROM centros " & _
                            where_sql
        dt = objOpSimplesLn.listar_datatable(Sql, "CORSAN")
        dr = dt.NewRow
        dr("centro") = 0
        dr("descripcion") = "TODO"
        dt.Rows.Add(dr)
        cbo_centro.DataSource = dt
        cbo_centro.ValueMember = "centro"
        cbo_centro.DisplayMember = "descripcion"
        cbo_centro.SelectedValue = 0

        carga_comp = True
    End Sub
    Private Sub cargarCbo()
        Dim dt As New DataTable
        Dim dr As DataRow
        Dim sql As String
        sql = "SELECT id,descripcion  FROM J_eval_tipo WHERE id in ("
        Dim sql_permisos_eval As String = "SELECT  id_tipo_eval FROM J_eval_permisos where id_usuario = '" & usuario & "'"
        dt_permisos = objOpSimplesLn.listar_datatable(sql_permisos_eval, "CORSAN")
        If (dt_permisos.Rows.Count > 0) Then
            For i = 0 To dt_permisos.Rows.Count - 1
                sql &= dt_permisos.Rows(i).Item("id_tipo_eval")
                If (i <> dt_permisos.Rows.Count - 1) Then
                    sql &= ","
                End If
            Next
            sql &= ")"

            dt = objOpSimplesLn.listar_datatable(sql, "CORSAN")
            dr = dt.NewRow
            dr("id") = 0
            dr("descripcion") = "TODO"
            dt.Rows.Add(dr)
            cbo_tipo.DataSource = dt
            cbo_tipo.ValueMember = "id"
            cbo_tipo.DisplayMember = "descripcion"
            cbo_tipo.SelectedValue = 0



        Else
            MessageBox.Show("Usted no tiene permiso para gestionar ningun tipo de evaluación.", "No tiene permisos", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.Close()
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

    Private Sub txtNombres_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNombres.TextChanged
        If (txtNombres.Text <> "") Then
            If (txtNombres.Text.Length >= 4) Then
                txtNit.Text = ""
            End If
        End If
    End Sub

    Private Sub txtNit_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNit.TextChanged
        If (txtNit.Text <> "") Then
            If (txtNit.Text.Length >= 3) Then
                txtNombres.Text = ""
            End If
        End If
    End Sub
    Private Sub consolidarCriterio()
        Dim fecIni As String = objOpSimplesLn.cambiarFormatoFecha(cboFechaIni.Value)
        Dim fecFin As String = objOpSimplesLn.cambiarFormatoFecha(cboFechaFin.Value)
        Dim sql As String = ""
        Dim selectSql As String
        Dim whereCentro As String = ""
        If centros = "" Then
            whereCentro &= ""
        Else
            whereCentro &= " v.centro IN(" & centros & ") AND "
        End If
        If cbo_centro.SelectedValue <> 0 Then
            whereCentro &= " v.centro  = " & cbo_centro.SelectedValue & " AND "
        End If
        Dim whereSql As String = " WHERE " & whereCentro & " v.nit = e.nit AND d.id_criterio  = c.id  AND c.id_tipo_evaluacion = t.id AND d.id_enc = e.id AND tc.id = c.id_tipo_criterio AND anulado is null AND e.fecha >= '" & fecIni & "' AND e.fecha<= '" & fecFin & "' "
        Dim orderSql As String = "ORDER BY t.descripcion,tc.descripcion  "
        Dim groupSql As String = ""
        Dim dt As New DataTable
        selectSql = "SELECT t.descripcion,tc.descripcion  ,c.nombre,AVG (d.calificacion)As promedio  " & _
                                         "  FROM J_eval_det d , J_eval_criterio c  , J_eval_tipo t , J_eval_enc e ,V_nom_personal_Activo_con_maquila v , J_eval_tipo_criterio tc "
        groupSql = " group by t.descripcion ,c.nombre,tc.descripcion "
        If (cbo_tipo.SelectedValue <> 0) Then
            whereSql &= "AND  t.id  = '" & cbo_tipo.SelectedValue & "'"
        Else
            whereSql &= "AND  t.id  in ("
            For i = 0 To dt_permisos.Rows.Count - 1
                whereSql &= dt_permisos.Rows(i).Item("id_tipo_eval")
                If (i <> dt_permisos.Rows.Count - 1) Then
                    whereSql &= ","
                End If
            Next
            whereSql &= ") "
        End If
        sql = selectSql & whereSql & groupSql & orderSql
        dt = objIngresoProdLn.listar_datatable(sql, "CORSAN")
        dtgConsulta.DataSource = dt
        dtgConsulta.Columns("promedio").DefaultCellStyle.Format = "N2"

    End Sub
    Private Sub cargarConsulta()
        Dim fecIni As String = objOpSimplesLn.cambiarFormatoFecha(cboFechaIni.Value)
        Dim fecFin As String = objOpSimplesLn.cambiarFormatoFecha(cboFechaFin.Value)
        Dim sql As String = ""
        Dim selectSql As String
        Dim whereCentro As String = ""
        If centros = "" Then
            whereCentro &= ""
        Else
            whereCentro &= " vista.centro IN(" & centros & ") AND "
        End If
        If cbo_centro.SelectedValue <> 0 Then
            whereCentro &= " vista.centro  = " & cbo_centro.SelectedValue & " AND "
        End If
        Dim whereSql As String = "WHERE " & whereCentro & " anulado is null AND fecha >= '" & fecIni & "' AND fecha<= '" & fecFin & "' "
        If cbo_evaluador.Text <> "Todo" And cbo_evaluador.Text <> "" Then
            Dim tipo As String
            If cbo_evaluador.Text = "Jefe" Then
                tipo = "J"
            ElseIf cbo_evaluador.Text = "Compañero" Then
                tipo = "C"
            Else
                tipo = "A"
            End If
            whereSql &= " and tipo='" & tipo & "'"
        End If
        Dim orderSql As String = ""
        Dim groupSql As String = ""
        Dim dt As New DataTable
        Dim tituloX As String = ""
        Dim tituloY As String = ""
        Dim col_nomb_serie As String = ""
        Dim col_nomb_valor As String = ""
        If (chk_consolidar.Checked) Then
            tituloX = "Tipo_evaliación"
            tituloY = "Promedio"
            col_nomb_serie = "tipo_evaluacion"
            col_nomb_valor = "promedio"
            selectSql = "SELECT id_tipo_evaluacion,tipo_evaluacion, AVG(calificacion) As promedio  " &
                                     "FROM j_v_evaluacion_desempeno vista  "
            groupSql = "GROUP BY id_tipo_evaluacion,tipo_evaluacion "
        ElseIf (chk_consol_centro.Checked) Then
            consol = True
            tituloX = "Centro_costos"
            tituloY = "Promedio"
            col_nomb_serie = "Centro_costos"
            col_nomb_valor = "promedio"
            selectSql = "SELECT v.centro,v.descripcion As desc_centro ,tc.descripcion ,c.nombre,AVG (d.calificacion)As promedio  " &
                                     "FROM J_eval_det d , J_eval_criterio c  , J_eval_tipo t , J_eval_enc e ,V_nom_personal_Activo_con_maquila v , J_eval_tipo_criterio tc , j_v_evaluacion_desempeno vista "
            whereSql = " WHERE vista.id = e.id AND  v.centro IN(1100,1200,2100,2200,2300,2400,2500,2600,2800,3100,3200,3500,4100,4200,4300,4324,4328,4332,4334,4340,4398,4399,5200,6200,6400) AND  v.nit = e.nit AND d.id_criterio  = c.id  AND c.id_tipo_evaluacion = t.id AND d.id_enc = e.id AND tc.id = c.id_tipo_criterio AND e.anulado is null AND e.fecha >= '" & fecIni & "' AND e.fecha<= '" & fecFin & "' AND  t.id  in (1,16,2,4,3,5,6,7,8,9,10,11,12,13,14,15,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31)   "
            groupSql = "group by v.centro,v.descripcion,c.nombre,tc.descripcion  "
        ElseIf (Chk_Empleados_Completos.Checked) Then

        Else
            tituloX = "Empleado"
            tituloY = "Calificación"
            col_nomb_serie = "nombres"
            col_nomb_valor = "calificación"
            selectSql = "SELECT id,id_tipo_evaluacion,tipo_evaluacion,tipo as hecha_por,nit,nombres,centro,fecha,calificacion As calificación,observaciones  " & _
                                         "FROM j_v_evaluacion_desempeno vista "
            If (txtNombres.Text <> "") Then
                whereSql &= "AND nombres like '%" & txtNombres.Text & "%'"
            ElseIf (txtNit.Text <> "") Then
                whereSql &= "AND nit like '%" & txtNombres.Text & "%'"
            End If
        End If


        If (cbo_tipo.SelectedValue <> 0) Then
            whereSql &= "AND vista.id_tipo_evaluacion = '" & cbo_tipo.SelectedValue & "'"
        Else
            whereSql &= "AND vista.id_tipo_evaluacion in ("
            For i = 0 To dt_permisos.Rows.Count - 1
                whereSql &= dt_permisos.Rows(i).Item("id_tipo_eval")
                If (i <> dt_permisos.Rows.Count - 1) Then
                    whereSql &= ","
                End If
            Next
            whereSql &= ") "
        End If
#Disable Warning BC42104 ' La variable 'selectSql' se usa antes de que se le haya asignado un valor. Podría darse una excepción de referencia NULL en tiempo de ejecución.
        sql = selectSql & whereSql & groupSql & orderSql
#Enable Warning BC42104 ' La variable 'selectSql' se usa antes de que se le haya asignado un valor. Podría darse una excepción de referencia NULL en tiempo de ejecución.
        dt = objIngresoProdLn.listar_datatable(sql, "CORSAN")
        dtgConsulta.DataSource = dt
        If (chk_consolidar.Checked Or chk_consol_centro.Checked) Then
            dtgConsulta.Columns("promedio").DefaultCellStyle.Format = "N2"
        Else
            orderSql &= " ORDER BY tipo_evaluacion "
            dtgConsulta.Columns("calificación").DefaultCellStyle.Format = "N2"
            dtgConsulta.Columns("fecha").DefaultCellStyle.Format = "d"
            dtgConsulta.Columns("id_tipo_evaluacion").Visible = False
        End If



        If (Chart1.Visible = True) Then
            Dim nomb_serie As String = ""
            Chart1.Titles.Clear()
            Chart1.Series.Clear()
            Chart1.ChartAreas.Clear()
            Chart1.ChartAreas.Add(0)
            For i = 0 To dt.Rows.Count - 1
                nomb_serie = dt.Rows(i).Item(col_nomb_serie)
                Chart1.Series.Add(nomb_serie)
                Chart1.Series(nomb_serie).Points.AddXY("", dt.Rows(i).Item(col_nomb_valor))
                Chart1.Series(nomb_serie).IsValueShownAsLabel = True
                Chart1.Series(nomb_serie)("PointWidth") = "1.5"
                Chart1.Series(nomb_serie).ToolTip = nomb_serie
            Next
            Chart1.ChartAreas(0).AxisX.Title = tituloX
            Chart1.ChartAreas(0).AxisY.Title = tituloY
            Chart1.ChartAreas(0).Area3DStyle.Enable3D = False
            Chart1.Refresh()
        End If


    End Sub
    Private Sub btn_consultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_consultar.Click
        dtgConsulta.DataSource = Nothing
        If chk_consol_criterios.Checked Then
            consolidarCriterio()
            consol = True
        Else
            cargarConsulta()
            consol = False
        End If

    End Sub

    Private Sub dtgConsulta_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgConsulta.CellContentClick
        If Not consol Then
            Dim col As String = dtgConsulta.Columns(e.ColumnIndex).Name
            Dim id_evaluacion As Integer = 0
            id_evaluacion = dtgConsulta.Item("id", e.RowIndex).Value
            Dim id_tipo_eval As Integer = dtgConsulta.Item("id_tipo_evaluacion", e.RowIndex).Value
            If (col = col_ver.Name) Then
                Dim frm As New Frm_evaluacione_desempeno
                Dim dt As DataTable = objOpSimplesLn.listar_datatable("select tipo,nit,nit_eval from J_eval_enc where id=" & id_evaluacion & "", "CORSAN")
                frm.Show()
                frm.Main(objUsuarioEn, dt(0).Item("tipo"), dt(0).Item("nit"), dt(0).Item("nit_eval"))
                frm.cargarEvaluacion(id_evaluacion, id_tipo_eval)
                frm.cargar_criterios_consolidados(id_tipo_eval)
                frm.cargarEvaluacionConsol(dt(0).Item("nit"), cboFechaIni.Value)
            ElseIf (col = colBorrar.Name) Then
                Dim resp As Integer = MessageBox.Show("Esta seguro que desea eliminar esta evaluación? ", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If (resp = 6) Then
                    Dim listSql As New List(Of Object)
                    Dim sql As String
                    sql = "UPDATE J_eval_enc SET anulado = 1 WHERE id =" & id_evaluacion
                    listSql.Add(sql)
                    If (objIngresoProdLn.ExecuteSqlTransaction(listSql, "CORSAN")) Then
                        cargarConsulta()
                        MessageBox.Show("El registro se elimino en forma correcta! ", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("Error al elimino el registro, verifique que la celda no este en blanco! ", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If

                End If
                'ElseIf (col = colPdf.Name) Then
                '    'cargarReporte(id_evaluacion, e.RowIndex)
            End If
        End If
    End Sub

    Private Sub btnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Click
        objOperacionesForm.ExportarDatosExcel(dtgConsulta, "Evaluaciones")
    End Sub

    Private Sub cboCategoria_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_tipo.SelectedIndexChanged
        If (carga_comp) Then
            txtNit.Text = ""
            txtNombres.Text = ""
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim listCriteriosEvaluacionEn As New List(Of CriteriosEvaluacionEn)
        Dim listClas_provEn As New List(Of Clas_provEn)
        Dim objEncEvaluacion As New EncEvaluacionEn
        objEncEvaluacion = llenarEncEvaluacion(1)
    End Sub

    Private Function llenarEncEvaluacion(ByVal fila As Integer) As EncEvaluacionEn
        Dim objEncEvaluacion As New EncEvaluacionEn
        objEncEvaluacion.contacto = objIngresoProdLn.consultar_valor("SELECT nomb_contacto FROM C_proveedor_categoria WHERE NIT = " & dtgConsulta.Item("proveedor", fila).Value, "PRODUCCION")
        Dim sFec As String = objOpSimplesLn.cambiarFormatoFecha(dtgConsulta.Item("fecha", fila).Value)
        objEncEvaluacion.fecha = dtgConsulta.Item("fecha", fila).Value
        objEncEvaluacion.nit = dtgConsulta.Item("proveedor", fila).Value
        objEncEvaluacion.nombre = dtgConsulta.Item("nombres", fila).Value
        objEncEvaluacion.numero = dtgConsulta.Item("id", fila).Value
        objEncEvaluacion.observaciones = dtgConsulta.Item("observaciones", fila).Value
        objEncEvaluacion.punt_ant = objIngresoProdLn.consultar_valor("SELECT SUM (valor) from  C_eval_puntaje WHERE id_evaluacion = (SELECT TOP(1)id FROM C_eval_proveedor WHERE proveedor = " & dtgConsulta.Item("proveedor", fila).Value & " AND id <> " & dtgConsulta.Item("id", fila).Value & " AND fecha <'" & sFec & "' ORDER BY fecha desc)", "PRODUCCION")
        objEncEvaluacion.punt_obtenido = objIngresoProdLn.consultar_valor("SELECT SUM(valor) FROM C_eval_puntaje P WHERE id_evaluacion = " & dtgConsulta.Item("id", fila).Value, "PRODUCCION")
        Return objEncEvaluacion
    End Function
    Private Function llenarObjCriterioEv(ByVal id As Double) As List(Of CriteriosEvaluacionEn)
        Dim listCriteriosEvaluacionEn As New List(Of CriteriosEvaluacionEn)
        Dim objCriteriosEvaluacionEn As New CriteriosEvaluacionEn
        Dim sql As String = "SELECT C.id_factor,F.factor  ,C.id_criterio,C.criterio,C.valor As punt_max ,E.valor " & _
                                   "FROM C_criterios C,C_factor F ,C_eval_puntaje E " & _
                                   "WHERE C.id_factor = F.id_factor AND E.id_factor = C.id_factor  AND E.id_evaluacion = " & id & " "
        Dim dt As DataTable = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")
        Dim fact_ant As Integer = 0
        Dim sw As Boolean = False
        For i = 0 To dt.Rows.Count - 1
            If (sw = False) Then
                sw = True
                objCriteriosEvaluacionEn.puntaje = dt.Rows(i).Item("valor")
                fact_ant = dt.Rows(i).Item("id_factor")
            End If
            objCriteriosEvaluacionEn.factor = dt.Rows(i).Item("factor")
            objCriteriosEvaluacionEn.criterio = dt.Rows(i).Item("criterio")
            objCriteriosEvaluacionEn.puntaje_maximo = dt.Rows(i).Item("punt_max")
            If (dt.Rows(i).Item("id_factor") <> fact_ant) Then
                objCriteriosEvaluacionEn.puntaje = dt.Rows(i).Item("valor")
                fact_ant = dt.Rows(i).Item("id_factor")
            End If
            listCriteriosEvaluacionEn.Add(objCriteriosEvaluacionEn)
            objCriteriosEvaluacionEn = New CriteriosEvaluacionEn
        Next
        Return listCriteriosEvaluacionEn
    End Function
    Private Function llenarObjClasificacionEv(ByVal fila As Integer) As List(Of Clas_provEn)
        Dim listClas_provEn As New List(Of Clas_provEn)
        Dim objClas_provEn As New Clas_provEn
        Dim puntaje As Double = objIngresoProdLn.consultar_valor("SELECT SUM(valor) FROM C_eval_puntaje P WHERE id_evaluacion = " & dtgConsulta.Item("id", fila).Value, "PRODUCCION")
        Dim sql As String = "SELECT puntaje,descripcion,clasificacion FROM C_clasificacion"
        Dim dt As DataTable = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")
        For i = 0 To dt.Rows.Count - 1
            objClas_provEn.puntaje = puntaje
            objClas_provEn.descripcion = dt.Rows(i).Item("descripcion")
            objClas_provEn.descripcion = dt.Rows(i).Item("clasificacion")
            If (puntaje >= 15 And puntaje <= 35) Then
                objClas_provEn.calificacion_real = "Deficiente"
            ElseIf (puntaje >= 36 And puntaje <= 60) Then
                objClas_provEn.calificacion_real = "Regular"
            ElseIf (puntaje >= 61 And puntaje <= 85) Then
                objClas_provEn.calificacion_real = "Bueno"
            ElseIf (puntaje >= 86 And puntaje <= 100) Then
                objClas_provEn.calificacion_real = "Excelente"
            End If
            listClas_provEn.Add(objClas_provEn)
            objClas_provEn = New Clas_provEn
        Next
        Return listClas_provEn
    End Function
    Private Sub cargarReporte(ByVal id As Double, ByVal fila As Integer)
        Dim listClas_provEn As New List(Of Clas_provEn)
        Dim listCriteriosEvaluacionEn As New List(Of CriteriosEvaluacionEn)
        Dim objEncEvaluacion As New EncEvaluacionEn
        objEncEvaluacion = llenarEncEvaluacion(fila)
        listCriteriosEvaluacionEn = llenarObjCriterioEv(id)
        listClas_provEn = llenarObjClasificacionEv(fila)
        Dim frm As New FrmReportesEvaluaciones()
        frm.Main("Evaluación", listCriteriosEvaluacionEn, listClas_provEn, objEncEvaluacion)
        frm.Show()
    End Sub


    Private Sub chk_consolidar_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chk_consolidar.CheckedChanged
        If (chk_consolidar.Checked) Then
            cbo_tipo.SelectedValue = 0
            txtNit.Text = ""
            txtNombres.Text = ""
            chk_consol_centro.Checked = False
            chk_consol_criterios.Checked = False
        End If
    End Sub
    Private Sub btn_cerrar_graf_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cerrar_graf.Click
        Chart1.Visible = False
        btn_cerrar_graf.Visible = False
    End Sub

    Private Sub btn_graficar_Click(sender As System.Object, e As System.EventArgs) Handles btn_graficar.Click
        Chart1.Visible = True
        btn_cerrar_graf.Visible = True
        cargarConsulta()
    End Sub
    Private Sub chk_consol_centro_CheckedChanged(sender As Object, e As EventArgs) Handles chk_consol_centro.CheckedChanged
        If (chk_consol_centro.Checked) Then
            cbo_tipo.SelectedValue = 0
            txtNit.Text = ""
            txtNombres.Text = ""
            chk_consolidar.Checked = False
            chk_consol_criterios.Checked = False
        End If
    End Sub
    Private Sub chk_consol_criterios_CheckedChanged(sender As Object, e As EventArgs) Handles chk_consol_criterios.CheckedChanged
        If (chk_consol_criterios.Checked) Then
            cbo_tipo.SelectedValue = 0
            txtNit.Text = ""
            txtNombres.Text = ""
            chk_consolidar.Checked = False
            chk_consol_centro.Checked = False
        End If
    End Sub
End Class