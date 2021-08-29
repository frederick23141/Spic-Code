Imports logicaNegocios
Imports entidadNegocios
Public Class Frm_evaluacione_desempeno
    Private objOpSimplesLn As New Op_simpesLn
    Dim carga_comp As Boolean = False
    Dim objIngresoProdLn As New Ing_prodLn
    Dim id_evaluacion_existente As Integer = 0
    Dim id_existente As Integer = 0
    Dim fec_excistente As String = ""
    Dim list_tipo_evaluacion As List(Of Integer)
    Dim tipo_Evalua As String
    Dim usuario As String
    Dim centros As String = ""
    Dim nota_final As Double
    Private objOperacionesForm As OperacionesFormularios = New OperacionesFormularios
    Private Sub J_evaluacione_desempeno_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        TabControl1.SelectedTab = TabPage2
        TabControl1.SelectedTab = TabPage1
        Me.WindowState = FormWindowState.Maximized
        lbl_titulo.Location = New System.Drawing.Point(Me.Width / 2 - lbl_titulo.Width, 11)
    End Sub
    Public Sub Main(ByVal objUsuario As UsuarioEn, ByVal tipo_Evalua As String, ByVal evaluado As String, ByVal evaluador As String)
        Me.usuario = objUsuario.usuario
        Me.tipo_Evalua = tipo_Evalua
        If (objUsuario.permiso.Trim <> "ADMIN") Then
            Dim nit As Double = objUsuario.nit
            Dim listCentros As DataTable = objOpSimplesLn.listar_datatable("SELECT centro FROM J_coordinador_centros_costos WHERE nit =" & nit, "PRODUCCION")
            For i = 0 To listCentros.Rows.Count - 1
                centros &= listCentros.Rows(i).Item("centro")
                If (i <> listCentros.Rows.Count - 1) Then
                    centros &= ","
                End If
            Next
        End If
        cargar_cbo()
        If tipo_Evalua = "A" Then
            cbo_evaluador.SelectedValue = evaluador
            cbo_evaluado.SelectedValue = evaluador
            cbo_evaluado.Enabled = False
            cbo_evaluador.Enabled = False
            cargar_cargo_evaluador()
        Else
            If Not IsNothing(objUsuario.nit) Then
                cbo_evaluado.SelectedValue = evaluado
                cbo_evaluado.Enabled = False
                cbo_evaluador.Enabled = False
                cbo_evaluador.SelectedValue = evaluador
                cargar_cargo_evaluador()
            End If
        End If
        cargar_cargo()
        carga_comp = True
    End Sub
    Public Sub cargarEvaluacion(ByVal id_evaluacion As Integer, ByVal id_tipo_eval As Integer)
        lbl_modificar.Text = "MODIFICANDO ID:" & id_evaluacion
        cbo_tipo.SelectedValue = id_tipo_eval
        id_evaluacion_existente = id_evaluacion
        Dim sql_enc As String = "SELECT id,nit,nit_eval ,fecha,observaciones,nivel_educativo  " &
                                     "FROM J_eval_enc enc " &
                                      "WHERE enc.id = " & id_evaluacion & ""
        Dim sql_det As String = "SELECT id_criterio,calificacion " &
                                 "FROM J_eval_det det " &
                                 "WHERE id_enc = " & id_evaluacion & ""
        Dim dt_enc As New DataTable
        Dim dt_det As New DataTable
        dt_enc = objOpSimplesLn.listar_datatable(sql_enc, "CORSAN")
        dt_det = objOpSimplesLn.listar_datatable(sql_det, "CORSAN")
        For i = 0 To dt_enc.Rows.Count - 1
            id_existente = dt_enc.Rows(i).Item("id")
            fec_excistente = objOpSimplesLn.cambiarFormatoFecha(dt_enc.Rows(i).Item("fecha"))
            cbo_evaluado.SelectedValue = dt_enc.Rows(i).Item("nit")
            cbo_evaluador.SelectedValue = dt_enc.Rows(i).Item("nit_eval")
            txtNotas.Text = dt_enc.Rows(i).Item("observaciones")
            If Not IsDBNull(dt_enc.Rows(i).Item("nivel_educativo")) Then
                cbo_nivel_educativo.SelectedValue = dt_enc.Rows(i).Item("nivel_educativo")
            End If
        Next
        For i = 0 To dt_det.Rows.Count - 1
            dtgEvaluacion.Item("col_calificacion", numFila(dt_det.Rows(i).Item("id_criterio"))).Value = dt_det.Rows(i).Item("calificacion")
        Next
    End Sub
    Public Sub cargarEvaluacionConsol(ByVal nit As Double, ByVal fecha As Date)
        Dim ano As Integer = fecha.Year
        Dim tipo_Eval As String
        Dim div_Promed As Integer = 0
        Dim sum_Cal1 As Double = 0
        Dim sum_Cal2 As Double = 0
        Dim sum_Cal3 As Double = 0
        Dim not1 As Double = 0
        Dim not2 As Double = 0
        Dim not3 As Double = 0

        Dim sql_enc As String = "SELECT id,nit,nit_eval ,fecha,observaciones,nivel_educativo,tipo,calificacion  " &
                                     "FROM J_eval_enc enc " &
                                      "WHERE enc.nit = " & nit & " and year(fecha)=" & ano & ""

        Dim dt_enc As New DataTable
        Dim dt_det As New DataTable
        dt_enc = objOpSimplesLn.listar_datatable(sql_enc, "CORSAN")

        For i = 0 To dt_enc.Rows.Count - 1
            tipo_Eval = dt_enc.Rows(i).Item("tipo").ToString.ToUpper()
            tipo_Eval = tipo_Eval.Replace(" ", "")
            If tipo_Eval = "J" Then
                not1 = dt_enc.Rows(i).Item("calificacion")
            ElseIf tipo_Eval = "C" Then
                not2 = dt_enc.Rows(i).Item("calificacion")
            ElseIf tipo_Eval = "A" Then
                not3 = dt_enc.Rows(i).Item("calificacion")
            End If
            Dim sql_det As String = "SELECT id_criterio,calificacion " &
                                 "FROM J_eval_det det " &
                                 "WHERE id_enc = " & dt_enc.Rows(i).Item("id") & ""
            dt_det = objOpSimplesLn.listar_datatable(sql_det, "CORSAN")
            div_Promed = div_Promed + 1
            For j = 0 To dt_det.Rows.Count - 1
                tipo_Eval = dt_enc.Rows(i).Item("tipo").ToString.ToUpper()
                tipo_Eval = tipo_Eval.Replace(" ", "")
                If tipo_Eval = "J" Then
                    dtg_Consolidado_Notas.Item("col_calificacion", numFila(dt_det.Rows(j).Item("id_criterio"))).Value = dt_det.Rows(j).Item("calificacion")
                ElseIf tipo_Eval = "C" Then
                    dtg_Consolidado_Notas.Item("col_calificacion1", numFila(dt_det.Rows(j).Item("id_criterio"))).Value = dt_det.Rows(j).Item("calificacion")
                ElseIf tipo_Eval = "A" Then
                    dtg_Consolidado_Notas.Item("col_calificacion2", numFila(dt_det.Rows(j).Item("id_criterio"))).Value = dt_det.Rows(j).Item("calificacion")
                End If
            Next
        Next
        For i = 0 To dtg_Consolidado_Notas.Rows.Count - 1
            If Not IsDBNull(dtg_Consolidado_Notas.Item("col_calificacion", i).Value) Then
                sum_Cal1 = sum_Cal1 + dtg_Consolidado_Notas.Item("col_calificacion", i).Value
            End If
            If Not IsDBNull(dtg_Consolidado_Notas.Item("col_calificacion1", i).Value) Then
                sum_Cal2 = sum_Cal2 + dtg_Consolidado_Notas.Item("col_calificacion1", i).Value
            End If
            If Not IsDBNull(dtg_Consolidado_Notas.Item("col_calificacion2", i).Value) Then
                sum_Cal3 = sum_Cal3 + dtg_Consolidado_Notas.Item("col_calificacion2", i).Value
            End If
            If (sum_Cal1 + sum_Cal2 + sum_Cal3) > 0 And div_Promed > 0 Then
                dtg_Consolidado_Notas.Item("col_calificacion3", i).Value = Format((sum_Cal1 + sum_Cal2 + sum_Cal3) / div_Promed, "0.00")
            End If
            sum_Cal1 = 0
            sum_Cal2 = 0
            sum_Cal3 = 0
        Next
        lbl_nota_final_J.Text &= " " & not1
        lbl_nota_final_C.Text &= " " & not2
        lbl_nota_final_A.Text &= " " & not3
        lbl_nota_prod_Final.Text &= " " & Format((not1 + not2 + not3) / div_Promed, "0.00")
        dtg_Consolidado_Notas.Columns("col_calificacion3").DefaultCellStyle.Format = "N1"
    End Sub
    Private Function numFila(ByVal id_criterio As Integer) As Integer
        For i = 0 To dtgEvaluacion.Rows.Count - 1
            If (dtgEvaluacion.Item("tipo_factor", i).Value <> "tipo_criterio") Then
                If (dtgEvaluacion.Item("id_factor", i).Value = id_criterio) Then
                    Return i
                End If
            End If
        Next
        Return 0
    End Function
    Private Sub cargar_criterios_evaluacion(ByVal tipo_evaluacion As Integer)
        Dim primero As Boolean = True
        Dim fila As DataRow
        Dim tipo_tipo_criterio_ant As String = ""
        Dim sql As String = "SELECT te.id As id_tipo_evaluacion, te.descripcion As titulo, tc.id As id_tipo_criterio, tc.descripcion As desc_tipo_criterio, tc.porc_tipo,cr.id As id_criterio,cr.nombre As nomb_criterio ,cr.descripcion As desc_criterio,cr.valor_porc As porc_criterio,cr.tipo_meta " &
                                 "FROM J_eval_criterio cr  ,J_eval_tipo_criterio tc, J_eval_tipo te " &
                                        "WHERE(cr.id_tipo_evaluacion = te.id And cr.id_tipo_criterio = tc.id And cr.id_tipo_evaluacion = " & tipo_evaluacion & ") " &
                                   "ORDER BY tc.id "
        Dim dt_evaluacion As New DataTable
        Dim dt_datos As DataTable = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        fila = dt_datos.Rows(dt_datos.Rows.Count - 1)
        dt_evaluacion.Columns.Add("tipo_factor")
        dt_evaluacion.Columns.Add("id_factor")
        dt_evaluacion.Columns.Add("col_factor")
        dt_evaluacion.Columns.Add("col_descripcion")
        dt_evaluacion.Columns.Add("col_porcentaje")
        dt_evaluacion.Columns.Add("col_calificacion")
        dt_evaluacion.Columns.Add("col_proc_und")
        dt_evaluacion.Columns.Add("tipo_meta")
        For i = 0 To dt_datos.Rows.Count - 1
            Dim f_actual As DataRow = dt_datos.Rows(i)
            If (primero) Then
                primero = False
                lbl_titulo.Text = dt_datos.Rows(i).Item("titulo")
                dt_evaluacion.Rows.Add()
                tipo_tipo_criterio_ant = dt_datos.Rows(i).Item("id_tipo_criterio")
                dt_evaluacion.Rows(dt_evaluacion.Rows.Count - 1).Item("tipo_factor") = "tipo_criterio"
                dt_evaluacion.Rows(dt_evaluacion.Rows.Count - 1).Item("id_factor") = dt_datos.Rows(i).Item("id_tipo_criterio")
                dt_evaluacion.Rows(dt_evaluacion.Rows.Count - 1).Item("col_factor") = dt_datos.Rows(i).Item("desc_tipo_criterio")
                dt_evaluacion.Rows(dt_evaluacion.Rows.Count - 1).Item("col_porcentaje") = dt_datos.Rows(i).Item("porc_tipo")
            Else
                If (dt_datos.Rows(i).Item("id_tipo_criterio") <> tipo_tipo_criterio_ant) Then
                    dt_evaluacion.Rows.Add()
                    tipo_tipo_criterio_ant = dt_datos.Rows(i).Item("id_tipo_criterio")
                    dt_evaluacion.Rows(dt_evaluacion.Rows.Count - 1).Item("tipo_factor") = "tipo_criterio"
                    dt_evaluacion.Rows(dt_evaluacion.Rows.Count - 1).Item("id_factor") = dt_datos.Rows(i).Item("id_tipo_criterio")
                    dt_evaluacion.Rows(dt_evaluacion.Rows.Count - 1).Item("col_factor") = dt_datos.Rows(i).Item("desc_tipo_criterio")
                    dt_evaluacion.Rows(dt_evaluacion.Rows.Count - 1).Item("col_porcentaje") = dt_datos.Rows(i).Item("porc_tipo")
                End If

            End If
            dt_evaluacion.Rows.Add()
            dt_evaluacion.Rows(dt_evaluacion.Rows.Count - 1).Item("tipo_factor") = "criterio"
            dt_evaluacion.Rows(dt_evaluacion.Rows.Count - 1).Item("id_factor") = dt_datos.Rows(i).Item("id_criterio")
            dt_evaluacion.Rows(dt_evaluacion.Rows.Count - 1).Item("col_factor") = dt_datos.Rows(i).Item("nomb_criterio")
            dt_evaluacion.Rows(dt_evaluacion.Rows.Count - 1).Item("col_descripcion") = dt_datos.Rows(i).Item("desc_criterio")
            dt_evaluacion.Rows(dt_evaluacion.Rows.Count - 1).Item("col_porcentaje") = dt_datos.Rows(i).Item("porc_criterio")
            dt_evaluacion.Rows(dt_evaluacion.Rows.Count - 1).Item("tipo_meta") = dt_datos.Rows(i).Item("tipo_meta")



            If cbo_tipo.Text = "EVALUACIÓN DESEMPEÑO OPERARIOS" Then
                If i = dt_datos.Rows.Count - 3 Then
                    dt_evaluacion.Rows(dt_evaluacion.Rows.Count - 1).Item("col_calificacion") = calificar_nc()
                End If
            End If
            If cbo_tipo.Text = "EVALUACIÓN DESEMPEÑO OPERARIOS" Then
                If i = dt_datos.Rows.Count - 2 Then
                    dt_evaluacion.Rows(dt_evaluacion.Rows.Count - 1).Item("col_calificacion") = calificar_desperdicios()
                    If dt_evaluacion.Rows(dt_evaluacion.Rows.Count - 1).Item("col_calificacion") = 0 Then
                        dt_evaluacion.Rows(dt_evaluacion.Rows.Count - 1).Item("col_calificacion") = 5
                    End If
                End If
            End If
            If i = dt_datos.Rows.Count - 1 Then
                If cbo_tipo.Text <> "EVALUACIÓN DESEMPEÑO MONTACARGA" Then
                    dt_evaluacion.Rows(dt_evaluacion.Rows.Count - 1).Item("col_calificacion") = calificar_ausentismos()
                End If
            End If
        Next
        dtgEvaluacion.DataSource = dt_evaluacion
        dtgEvaluacion.Columns("col_factor").Width = 190
        dtgEvaluacion.Columns("col_descripcion").Width = 480
        dtgEvaluacion.Columns("col_porcentaje").Width = 40
        dtgEvaluacion.Columns("col_calificacion").Width = 40
        dtgEvaluacion.Columns("col_factor").HeaderText = "FACTOR"
        dtgEvaluacion.Columns("col_descripcion").HeaderText = "DESCRIPCIÓN"
        dtgEvaluacion.Columns("col_porcentaje").HeaderText = "%"
        dtgEvaluacion.Columns("col_calificacion").HeaderText = "CAL"
        dtgEvaluacion.Columns("col_proc_und").HeaderText = "%_und"

        dtgEvaluacion.Columns("col_proc_und").Visible = False
        dtgEvaluacion.Columns("tipo_factor").Visible = False
        dtgEvaluacion.Columns("id_factor").Visible = False
        dtgEvaluacion.Columns("col_factor").ReadOnly = True
        dtgEvaluacion.Columns("col_descripcion").ReadOnly = True
        dtgEvaluacion.Columns("col_porcentaje").ReadOnly = True
        dtgEvaluacion.Columns("tipo_meta").Visible = False

        dtgEvaluacion.Rows(dtgEvaluacion.Rows.Count - 1).ReadOnly = False
        If cbo_tipo.Text = "EVALUACIÓN DESEMPEÑO OPERARIOS" Then
            dtgEvaluacion.Rows(dtgEvaluacion.Rows.Count - 2).ReadOnly = True
        End If
        If cbo_tipo.Text = "EVALUACIÓN DESEMPEÑO OPERARIOS" Then
            nota_final = 0
            If calificar_desperdicios() = 0 Then
                dtgEvaluacion.Rows(dtgEvaluacion.Rows.Count - 3).ReadOnly = False
            Else
                dtgEvaluacion.Rows(dtgEvaluacion.Rows.Count - 3).ReadOnly = True
            End If

        End If
        dtgEvaluacion.Columns("col_calificacion").DefaultCellStyle.Format = "N1"
        dtgEvaluacion.Columns("col_factor").DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!, System.Drawing.FontStyle.Bold)
        dtgEvaluacion.Columns("col_calificacion").DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Bold)
        pintarFormulario()
        nota_final = 0
    End Sub
    'Cargar notas de todas las evaluaciones hechas
    Public Sub cargar_criterios_consolidados(ByVal tipo_evaluacion As Integer)
        Dim primero As Boolean = True
        Dim fila As DataRow
        Dim tipo_tipo_criterio_ant As String = ""
        Dim sql As String = "SELECT te.id As id_tipo_evaluacion, te.descripcion As titulo, tc.id As id_tipo_criterio, tc.descripcion As desc_tipo_criterio, tc.porc_tipo,cr.id As id_criterio,cr.nombre As nomb_criterio ,cr.descripcion As desc_criterio,cr.valor_porc As porc_criterio,cr.tipo_meta " &
                                 "FROM J_eval_criterio cr  ,J_eval_tipo_criterio tc, J_eval_tipo te " &
                                        "WHERE(cr.id_tipo_evaluacion = te.id And cr.id_tipo_criterio = tc.id And cr.id_tipo_evaluacion = " & tipo_evaluacion & ") " &
                                   "ORDER BY tc.id "
        Dim dt_evaluacion As New DataTable
        Dim dt_datos As DataTable = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        fila = dt_datos.Rows(dt_datos.Rows.Count - 1)
        dt_evaluacion.Columns.Add("tipo_factor")
        dt_evaluacion.Columns.Add("id_factor")
        dt_evaluacion.Columns.Add("col_factor")
        dt_evaluacion.Columns.Add("col_descripcion")
        dt_evaluacion.Columns.Add("col_porcentaje")
        dt_evaluacion.Columns.Add("col_calificacion")
        dt_evaluacion.Columns.Add("col_calificacion1")
        dt_evaluacion.Columns.Add("col_calificacion2")
        dt_evaluacion.Columns.Add("col_calificacion3")
        dt_evaluacion.Columns.Add("col_proc_und")
        dt_evaluacion.Columns.Add("tipo_meta")
        For i = 0 To dt_datos.Rows.Count - 1
            Dim f_actual As DataRow = dt_datos.Rows(i)
            If (primero) Then
                primero = False
                lbl_titulo.Text = dt_datos.Rows(i).Item("titulo")
                dt_evaluacion.Rows.Add()
                tipo_tipo_criterio_ant = dt_datos.Rows(i).Item("id_tipo_criterio")
                dt_evaluacion.Rows(dt_evaluacion.Rows.Count - 1).Item("tipo_factor") = "tipo_criterio"
                dt_evaluacion.Rows(dt_evaluacion.Rows.Count - 1).Item("id_factor") = dt_datos.Rows(i).Item("id_tipo_criterio")
                dt_evaluacion.Rows(dt_evaluacion.Rows.Count - 1).Item("col_factor") = dt_datos.Rows(i).Item("desc_tipo_criterio")
                dt_evaluacion.Rows(dt_evaluacion.Rows.Count - 1).Item("col_porcentaje") = dt_datos.Rows(i).Item("porc_tipo")
            Else
                If (dt_datos.Rows(i).Item("id_tipo_criterio") <> tipo_tipo_criterio_ant) Then
                    dt_evaluacion.Rows.Add()
                    tipo_tipo_criterio_ant = dt_datos.Rows(i).Item("id_tipo_criterio")
                    dt_evaluacion.Rows(dt_evaluacion.Rows.Count - 1).Item("tipo_factor") = "tipo_criterio"
                    dt_evaluacion.Rows(dt_evaluacion.Rows.Count - 1).Item("id_factor") = dt_datos.Rows(i).Item("id_tipo_criterio")
                    dt_evaluacion.Rows(dt_evaluacion.Rows.Count - 1).Item("col_factor") = dt_datos.Rows(i).Item("desc_tipo_criterio")
                    dt_evaluacion.Rows(dt_evaluacion.Rows.Count - 1).Item("col_porcentaje") = dt_datos.Rows(i).Item("porc_tipo")
                End If

            End If
            dt_evaluacion.Rows.Add()
            dt_evaluacion.Rows(dt_evaluacion.Rows.Count - 1).Item("tipo_factor") = "criterio"
            dt_evaluacion.Rows(dt_evaluacion.Rows.Count - 1).Item("id_factor") = dt_datos.Rows(i).Item("id_criterio")
            dt_evaluacion.Rows(dt_evaluacion.Rows.Count - 1).Item("col_factor") = dt_datos.Rows(i).Item("nomb_criterio")
            dt_evaluacion.Rows(dt_evaluacion.Rows.Count - 1).Item("col_descripcion") = dt_datos.Rows(i).Item("desc_criterio")
            dt_evaluacion.Rows(dt_evaluacion.Rows.Count - 1).Item("col_porcentaje") = dt_datos.Rows(i).Item("porc_criterio")
            dt_evaluacion.Rows(dt_evaluacion.Rows.Count - 1).Item("tipo_meta") = dt_datos.Rows(i).Item("tipo_meta")



            'If cbo_tipo.Text = "EVALUACIÓN DESEMPEÑO OPERARIOS" Then
            '    If i = dt_datos.Rows.Count - 3 Then
            '        dt_evaluacion.Rows(dt_evaluacion.Rows.Count - 1).Item("col_calificacion") = calificar_nc()
            '    End If
            'End If
            'If cbo_tipo.Text = "EVALUACIÓN DESEMPEÑO OPERARIOS" Then
            '    If i = dt_datos.Rows.Count - 2 Then
            '        dt_evaluacion.Rows(dt_evaluacion.Rows.Count - 1).Item("col_calificacion") = calificar_desperdicios()
            '        If dt_evaluacion.Rows(dt_evaluacion.Rows.Count - 1).Item("col_calificacion") = 0 Then
            '            dt_evaluacion.Rows(dt_evaluacion.Rows.Count - 1).Item("col_calificacion") = 5
            '        End If
            '    End If
            'End If
            'If i = dt_datos.Rows.Count - 1 Then
            '    If cbo_tipo.Text <> "EVALUACIÓN DESEMPEÑO MONTACARGA" Then
            '        dt_evaluacion.Rows(dt_evaluacion.Rows.Count - 1).Item("col_calificacion") = calificar_ausentismos()
            '    End If
            'End If
        Next
        dtg_Consolidado_Notas.DataSource = dt_evaluacion
        dtg_Consolidado_Notas.Columns("col_factor").Width = 190
        dtg_Consolidado_Notas.Columns("col_descripcion").Width = 480
        dtg_Consolidado_Notas.Columns("col_porcentaje").Width = 40
        dtg_Consolidado_Notas.Columns("col_calificacion").Width = 40
        dtg_Consolidado_Notas.Columns("col_factor").HeaderText = "FACTOR"
        dtg_Consolidado_Notas.Columns("col_descripcion").HeaderText = "DESCRIPCIÓN"
        dtg_Consolidado_Notas.Columns("col_porcentaje").HeaderText = "%"
        dtg_Consolidado_Notas.Columns("col_calificacion").HeaderText = "c_Jefe"
        dtg_Consolidado_Notas.Columns("col_calificacion1").HeaderText = "c_Compa"
        dtg_Consolidado_Notas.Columns("col_calificacion2").HeaderText = "c_Auto"
        dtg_Consolidado_Notas.Columns("col_calificacion3").HeaderText = "prom_Cal"
        dtg_Consolidado_Notas.Columns("col_proc_und").HeaderText = "%_und"

        dtg_Consolidado_Notas.Columns("col_proc_und").Visible = False
        dtg_Consolidado_Notas.Columns("tipo_factor").Visible = False
        dtg_Consolidado_Notas.Columns("id_factor").Visible = False
        dtg_Consolidado_Notas.Columns("col_factor").ReadOnly = True
        dtg_Consolidado_Notas.Columns("col_descripcion").ReadOnly = True
        dtg_Consolidado_Notas.Columns("col_porcentaje").ReadOnly = True
        dtg_Consolidado_Notas.Columns("tipo_meta").Visible = False

        dtg_Consolidado_Notas.Rows(dtgEvaluacion.Rows.Count - 1).ReadOnly = False
        If cbo_tipo.Text = "EVALUACIÓN DESEMPEÑO OPERARIOS" Then
            dtg_Consolidado_Notas.Rows(dtgEvaluacion.Rows.Count - 2).ReadOnly = True
        End If
        If cbo_tipo.Text = "EVALUACIÓN DESEMPEÑO OPERARIOS" Then
            nota_final = 0
            If calificar_desperdicios() = 0 Then
                dtg_Consolidado_Notas.Rows(dtgEvaluacion.Rows.Count - 3).ReadOnly = False
            Else
                dtg_Consolidado_Notas.Rows(dtgEvaluacion.Rows.Count - 3).ReadOnly = True
            End If

        End If
        dtg_Consolidado_Notas.Columns("col_calificacion").DefaultCellStyle.Format = "N1"
        dtg_Consolidado_Notas.Columns("col_calificacion1").DefaultCellStyle.Format = "N1"
        dtg_Consolidado_Notas.Columns("col_calificacion2").DefaultCellStyle.Format = "N1"
        dtg_Consolidado_Notas.Columns("col_calificacion3").DefaultCellStyle.Format = "N1"
        dtg_Consolidado_Notas.Columns("col_factor").DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!, System.Drawing.FontStyle.Bold)
        dtg_Consolidado_Notas.Columns("col_calificacion").DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Bold)
        dtg_Consolidado_Notas.Columns("col_calificacion1").DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Bold)
        dtg_Consolidado_Notas.Columns("col_calificacion2").DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Bold)
        dtg_Consolidado_Notas.Columns("col_calificacion3").DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Bold)
        dtg_Consolidado_Notas.Columns(8).DefaultCellStyle.BackColor = Color.Salmon
        pintarFormulario_Con()
        nota_final = 0
    End Sub
    Private Sub pintarFormulario()
        Dim cont_tipo As Integer = 0
        For i = 0 To dtgEvaluacion.Rows.Count - 1
            If (dtgEvaluacion.Item("tipo_factor", i).Value = "tipo_criterio") Then
                dtgEvaluacion.Rows(i).DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold)
                dtgEvaluacion.Rows(i).ReadOnly = True
                cont_tipo += 1
            End If
            Select Case cont_tipo
                Case 1
                    dtgEvaluacion.Rows(i).DefaultCellStyle.BackColor = Color.NavajoWhite
                Case 2
                    dtgEvaluacion.Rows(i).DefaultCellStyle.BackColor = Color.YellowGreen
                Case 3
                    dtgEvaluacion.Rows(i).DefaultCellStyle.BackColor = Color.LightSteelBlue
            End Select
        Next
    End Sub
    Private Sub pintarFormulario_Con()
        Dim cont_tipo As Integer = 0
        For i = 0 To dtg_Consolidado_Notas.Rows.Count - 1
            If (dtg_Consolidado_Notas.Item("tipo_factor", i).Value = "tipo_criterio") Then
                dtg_Consolidado_Notas.Rows(i).DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold)
                dtg_Consolidado_Notas.Rows(i).ReadOnly = True
                cont_tipo += 1
            End If
            Select Case cont_tipo
                Case 1
                    dtg_Consolidado_Notas.Rows(i).DefaultCellStyle.BackColor = Color.NavajoWhite
                Case 2
                    dtg_Consolidado_Notas.Rows(i).DefaultCellStyle.BackColor = Color.YellowGreen
                Case 3
                    dtg_Consolidado_Notas.Rows(i).DefaultCellStyle.BackColor = Color.LightSteelBlue
            End Select
        Next
    End Sub
    Private Sub cargar_cbo()
        Dim sql As String
        Dim dt As New DataTable
        Dim dr As DataRow
        If centros <> "" Then
            sql = "SELECT nit,nombres  FROM V_nom_personal_Activo_con_maquila_general wHERE centro in (" & centros & ") ORDER BY nombres"
        Else
            sql = "SELECT nit,nombres  FROM V_nom_personal_Activo_con_maquila_general ORDER BY nombres"
        End If

        dt = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        dr = dt.NewRow
        dr("nit") = 0
        dr("nombres") = "SELECCIONE"
        dt.Rows.Add(dr)
        cbo_evaluado.DataSource = dt
        cbo_evaluado.ValueMember = "nit"
        cbo_evaluado.DisplayMember = "nombres"
        cbo_evaluado.SelectedValue = 0


        dt = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        dr = dt.NewRow
        dr("nit") = 0
        dr("nombres") = "SELECCIONE"
        dt.Rows.Add(dr)
        cbo_evaluador.DataSource = dt
        cbo_evaluador.ValueMember = "nit"
        cbo_evaluador.DisplayMember = "nombres"
        cbo_evaluador.SelectedValue = 0

        dt = New DataTable
        sql = "SELECT id,nivel FROM J_eval_nivel_educativo "
        dt = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        dr = dt.NewRow
        dr("id") = 0
        dr("nivel") = "SELECCIONE"
        dt.Rows.Add(dr)
        cbo_nivel_educativo.DataSource = dt
        cbo_nivel_educativo.ValueMember = "id"
        cbo_nivel_educativo.DisplayMember = "nivel"
        cbo_nivel_educativo.SelectedValue = 0

        sql = "SELECT id,descripcion  FROM J_eval_tipo WHERE id in ("
        Dim sql_permisos_eval As String = "SELECT  id_tipo_eval FROM J_eval_permisos where id_usuario = '" & usuario & "' "
        Dim dt_permisos As DataTable = objOpSimplesLn.listar_datatable(sql_permisos_eval, "CORSAN")
        If (dt_permisos.Rows.Count > 0) Then
            For i = 0 To dt_permisos.Rows.Count - 1
                sql &= dt_permisos.Rows(i).Item("id_tipo_eval")
                If (i <> dt_permisos.Rows.Count - 1) Then
                    sql &= ","
                End If
            Next
            sql &= ")"
            sql &= " ORDER BY descripcion"
            dt = objOpSimplesLn.listar_datatable(sql, "CORSAN")
            dr = dt.NewRow
            dr("id") = 0
            dr("descripcion") = "SELECCIONE"
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
    Private Sub cargar_cargo()
        cargar_efic()
        Dim nit As Double = cbo_evaluado.SelectedValue
        Dim sql_fec_ingreso As String = "SELECT fecha_ingreso  FROM y_personal_contratos where estado = 'A' AND  nit = " & nit
        Dim fec_ingreso As String

        If objOpSimplesLn.consultarVal(sql_fec_ingreso) <> "" Then
            fec_ingreso = objOpSimplesLn.cambiarFormatoFecha(objOpSimplesLn.consultarVal(sql_fec_ingreso))
        End If
#Disable Warning BC42104 ' La variable 'fec_ingreso' se usa antes de que se le haya asignado un valor. Podría darse una excepción de referencia NULL en tiempo de ejecución.
        If fec_ingreso = "12:00:00 AM" Then
#Enable Warning BC42104 ' La variable 'fec_ingreso' se usa antes de que se le haya asignado un valor. Podría darse una excepción de referencia NULL en tiempo de ejecución.
            sql_fec_ingreso = "SELECT fecha_ingreso  FROM V_nom_personal_Activo_con_maquila where nit = " & nit
            fec_ingreso = objOpSimplesLn.cambiarFormatoFecha(objOpSimplesLn.consultarVal(sql_fec_ingreso))

        End If
        If IsDBNull(fec_ingreso) Then
            MessageBox.Show("No tiene fecha de ingreso la persona que se intenta evaluar", "Sin fecha de ingreso", MessageBoxButtons.OK)
        End If
        'txt_antiguedad.Text = DateDiff(DateInterval.Month, fec_ingreso, Now)
        txt_cargo_evaluado.Text = objOpSimplesLn.consultarVal("SELECT Cargo FROM V_nom_personal_Activo_con_maquila WHERE nit = " & nit)
    End Sub
    Private Sub cbo_evaluado_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbo_evaluado.SelectedIndexChanged
        If (carga_comp) Then
            If (cbo_evaluado.SelectedValue <> "0") Then
                cargar_cargo()
            End If
        End If
    End Sub

    Private Sub cbo_evaluador_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbo_evaluador.SelectedIndexChanged
        If (carga_comp) Then
            If (cbo_evaluador.SelectedValue <> "0") Then
                cargar_cargo_evaluador()
            End If
        End If
    End Sub
    Private Sub cargar_cargo_evaluador()
        Dim nit As Double = cbo_evaluador.SelectedValue
        txt_cargo_evaluador.Text = objOpSimplesLn.consultarVal("SELECT Cargo FROM V_nom_personal_Activo_con_maquila WHERE nit = " & nit)
    End Sub
    Private Function validar() As Boolean
        If (cbo_tipo.SelectedValue <> 0) Then
            If (cbo_nivel_educativo.SelectedValue <> 0) Then
                If (cbo_evaluado.SelectedValue <> 0) Then
                    If (cbo_evaluador.SelectedValue <> 0) Then
                        If (txtNotas.Text <> "") Then
                            If (validarDtg()) Then
                                Return True
                            Else
                                MessageBox.Show("Verifique que todos los criterios esten calificados en forma correcta", "Verifique!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            End If
                        Else
                            MessageBox.Show("Ingrese una observación", "Verifique!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If
                    Else
                        MessageBox.Show("Seleccione un evaluador", "Verifique!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                Else
                    MessageBox.Show("Seleccione un evaluado", "Verifique!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                MessageBox.Show("Seleccione nivel educativo", "Verifique!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            MessageBox.Show("Seleccione un tipo de evaluación", "Verifique!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Return False
    End Function
    Private Function validarDtg() As Boolean
        Dim resp As Boolean = True
        For i = 0 To dtgEvaluacion.Rows.Count - 1
            If (dtgEvaluacion.Item("tipo_factor", i).Value <> "tipo_criterio") Then
                If Not IsDBNull(dtgEvaluacion.Item("col_calificacion", i).Value) Then
                    If Not IsNumeric(dtgEvaluacion.Item("col_calificacion", i).Value) Then
                        resp = False
                    ElseIf (dtgEvaluacion.Item("col_calificacion", i).Value = 0) Then
                        resp = False
                    End If
                Else
                    resp = False
                End If
            End If
        Next
        Return resp
    End Function

    Private Sub nuevo()
        carga_comp = False
        lbl_modificar.Text = ""
        id_evaluacion_existente = 0
        fec_excistente = ""
        txt_calificacion.Text = ""
        id_existente = 0
        cbo_evaluado.SelectedValue = 0
        txt_cargo_evaluado.Text = ""
        txt_antiguedad.Text = ""
        txtNotas.Text = ""
        For i = 0 To dtgEvaluacion.Rows.Count - 1
            dtgEvaluacion.Item("col_calificacion", i).Value = ""
        Next
        carga_comp = True
    End Sub
    Private Sub dtgEvaluacion_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dtgEvaluacion.KeyPress
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

    Private Sub dtgEvaluacion_CellValueChanged(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgEvaluacion.CellValueChanged
        If (carga_comp) Then
            Dim col As String = dtgEvaluacion.Columns(e.ColumnIndex).Name
            If (dtgEvaluacion.Item("tipo_factor", e.RowIndex).Value <> "tipo_criterio") Then
                Dim fila As Integer = e.RowIndex
                Dim puntaje As Double = 0
                Dim puntajeMax As Double = 0
                If (col = "col_calificacion") Then
                    If IsNumeric(dtgEvaluacion.Item("col_calificacion", e.RowIndex).Value) Then
                        If (dtgEvaluacion.Item("col_calificacion", e.RowIndex).Value.ToString <> "") Then
                            puntaje = dtgEvaluacion.Item("col_calificacion", e.RowIndex).Value
                            puntajeMax = 5
                            If (puntaje > puntajeMax) Then
                                MessageBox.Show("El puntaje debe estar en el rango establesido(de 1 a 5)", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                carga_comp = False
                                dtgEvaluacion.Item("col_calificacion", e.RowIndex).Value = "0"
                                carga_comp = True
                            Else
                                calcular_cal_total(e.RowIndex)
                            End If
                        End If
                    Else
                        MessageBox.Show("Ingrese solo valores númericos", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        carga_comp = False
                        dtgEvaluacion.Item("col_calificacion", e.RowIndex).Value = "0"
                        carga_comp = True
                    End If

                End If
            End If
        End If
    End Sub
    Private Sub calcular_cal_total(ByVal fila As Integer)
        Dim fila_comienzo_tipo As Integer = 0
        Dim porc_de_tipo As Double = 0
        Dim porc_de_criterio As Double = dtgEvaluacion.Item("col_porcentaje", fila).Value
        Dim calificacion As Double = dtgEvaluacion.Item("col_calificacion", fila).Value
        Dim valor_porc As Double
        Dim tipo_encontrado As Boolean = False
        Dim i As Integer = fila
        Dim cont_Item As Integer = 0
        Dim sum_tot_tipo_criterio As Double = 0
        Dim sum_tot_calificacion As Decimal = 0

        While tipo_encontrado = False
            If (dtgEvaluacion.Item("tipo_factor", i).Value = "tipo_criterio") Then
                porc_de_tipo = dtgEvaluacion.Item("col_porcentaje", i).Value
                fila_comienzo_tipo = i
                tipo_encontrado = True
                Exit While
            End If
            cont_Item += 1
            i -= 1
        End While
        tipo_encontrado = False
        i = fila
        While tipo_encontrado = False
            If dtgEvaluacion.Rows.Count - 1 < i Then
                Exit While
            End If
            If (dtgEvaluacion.Item("tipo_factor", i).Value = "tipo_criterio") Then
                tipo_encontrado = True
                Exit While
            End If
            cont_Item += 1
            i += 1
        End While
        valor_porc = (calificacion / (cont_Item - 1)) * 100
        dtgEvaluacion.Item("col_proc_und", fila).Value = valor_porc * (porc_de_criterio / 100)
        For j = fila_comienzo_tipo + 1 To dtgEvaluacion.Rows.Count - 1
            If (dtgEvaluacion.Item("tipo_factor", j).Value = "tipo_criterio") Then
                j = dtgEvaluacion.Rows.Count - 1
            Else
                If Not IsDBNull(dtgEvaluacion.Item("col_proc_und", j).Value) Then
                    sum_tot_tipo_criterio += dtgEvaluacion.Item("col_proc_und", j).Value
                End If
            End If
        Next
        dtgEvaluacion.Item("col_calificacion", fila_comienzo_tipo).Value = sum_tot_tipo_criterio * (porc_de_tipo / 100)
        dtgEvaluacion.Item("col_calificacion", fila_comienzo_tipo).Value = (dtgEvaluacion.Item("col_calificacion", fila_comienzo_tipo).Value / porc_de_tipo) * 100
        dtgEvaluacion.Item("col_calificacion", fila_comienzo_tipo).Value = Convert.ToDecimal((cont_Item - 1) * (dtgEvaluacion.Item("col_calificacion", fila_comienzo_tipo).Value / 100))
        For j = 0 To dtgEvaluacion.Rows.Count - 1
            If (dtgEvaluacion.Item("tipo_factor", j).Value = "tipo_criterio") Then
                If Not IsDBNull(dtgEvaluacion.Item("col_calificacion", j).Value) Then
                    If (dtgEvaluacion.Item("col_calificacion", j).Value.ToString <> "") Then
                        sum_tot_calificacion += dtgEvaluacion.Item("col_calificacion", j).Value * (dtgEvaluacion.Item("col_porcentaje", j).Value / 100)
                    End If
                End If
            End If
        Next
        txt_calificacion.Text = Math.Round(sum_tot_calificacion, 2)
        If (Math.Round(sum_tot_calificacion, 2) < 2) Then
            lblDescCal1.ForeColor = Color.Red
            lblValCal1.ForeColor = Color.Red
        Else
            lblDescCal1.ForeColor = Color.Black
            lblValCal1.ForeColor = Color.Black
        End If
        If (Math.Round(sum_tot_calificacion, 2) >= 2 And Math.Round(sum_tot_calificacion, 2) < 3) Then
            lblDescCal2.ForeColor = Color.Red
            lblValCal2.ForeColor = Color.Red
        Else
            lblDescCal2.ForeColor = Color.Black
            lblValCal2.ForeColor = Color.Black
        End If
        If (Math.Round(sum_tot_calificacion, 2) >= 3 And Math.Round(sum_tot_calificacion, 2) < 4) Then
            lblDescCal3.ForeColor = Color.Red
            lblValCal3.ForeColor = Color.Red
        Else
            lblDescCal3.ForeColor = Color.Black
            lblValCal3.ForeColor = Color.Black
        End If
        If (Math.Round(sum_tot_calificacion, 2) > 4) Then
            lblDescCal4.ForeColor = Color.Red
            lblValCal4.ForeColor = Color.Red
        Else
            lblDescCal4.ForeColor = Color.Black
            lblValCal4.ForeColor = Color.Black
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
    Private Sub dataGridView1_EditingControlShowing( _
ByVal sender As Object, _
ByVal e As DataGridViewEditingControlShowingEventArgs) _
Handles dtgEvaluacion.EditingControlShowing

        'Referencia a la celda 
        Dim validar As TextBox = CType(e.Control, TextBox)

        'Agregar el controlador de eventos para el KeyPress 
        AddHandler validar.KeyPress, AddressOf validar_Keypress

    End Sub


    ' Evento Keypress 
    Private Sub validar_Keypress( _
    ByVal sender As Object, _
    ByVal e As System.Windows.Forms.KeyPressEventArgs)
        'Obtener indice de la columna 
        Dim columna As Integer = dtgEvaluacion.CurrentCell.ColumnIndex

        ' Verificar columna actual 

        Dim caracter As Char = e.KeyChar

        ' referencia a la celda 
        Dim txt As TextBox = CType(sender, TextBox)

        ' Comprobar si es un número con isNumber, si es el backspace, si el caracter 
        ' es el separador decimal, y que no contiene ya el separador 
        If (Char.IsDigit(e.KeyChar) Or e.KeyChar = ".") Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

    End Sub
    'Cargar criterio de evaluacion
    Private Sub cbo_tipo_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbo_tipo.SelectedIndexChanged
        If (carga_comp) Then
            cargar_efic()
            carga_comp = False
            cargar_criterios_evaluacion(cbo_tipo.SelectedValue)
            'cargar_criterios_consolidados(cbo_tipo.SelectedValue)
            lbl_titulo.Text = cbo_tipo.Text
            carga_comp = True
        End If
    End Sub
    Private Sub cargar_efic()
        dtg_efic.DataSource = Nothing
        If (cbo_tipo.Text <> "SELECCIONE") Then
            If (cbo_evaluado.Text <> "SELECCIONE") Then
                Dim dt_efic As New DataTable
                Dim nit As Double = cbo_evaluado.SelectedValue
                Dim ano As Double = Now.Year - 1
                If (cbo_tipo.SelectedValue = 8) Then 'Para vendedores
                    Dim sql_num_vendedor As String = "SELECT vendedor FROM terceros WHERE nit = '" & nit & "'"
                    Dim vendedor As String = objOpSimplesLn.consultarVal(sql_num_vendedor)
                    If (vendedor <> "") Then
                        'Dim fec_ini As String = objOpSimplesLn.cambiarFormatoFecha(Now.AddYears(-1).AddDays(-Now.Day + 1))
                        'Dim fec_fin As String = objOpSimplesLn.cambiarFormatoFecha(Now.AddDays(-Now.Day + 1))
                        Dim sql_vtas As String = "SELECT v.vendedor, MONTH(v.fec) AS mes ,YEAR(v.fec) AS ano,CAST(YEAR(v.fec) AS varchar(25))+ '-' + CAST(MONTH(v.fec) AS varchar(25))As mes_, SUM (v.Vr_total)As ventas " & _
                                                 "FROM Jjv_V_vtas_vend_cliente_ref v  " & _
                                                  "WHERE YEAR(v.fec)= " & ano & " and v.vendedor = " & vendedor & "  " & _
                                                   "GROUP BY v.vendedor,MONTH (v.fec),YEAR (v.fec) " & _
                                                    "ORDER BY YEAR(v.fec), MONTH(v.fec) "
                        Dim sql_rec As String = "SELECT v.vendedor, MONTH(v.fecha ) AS mes ,YEAR(v.fecha) AS ano, SUM (v.Total_rec )As recaudos,CAST(YEAR(v.fecha) AS varchar(25))+ '-' + CAST(MONTH(v.fecha) AS varchar(25))As mes_ " & _
                                                 "FROM Jjv_Recaudos_consol v   " & _
                                                    "WHERE(Year(v.fecha) = " & ano & " And v.vendedor = " & vendedor & " ) " & _
                                                        "GROUP BY v.vendedor,MONTH (v.fecha),YEAR (v.fecha)  " & _
                                                        "ORDER BY YEAR(v.fecha), MONTH(v.fecha)"
                        Dim sql_ppto_rec As String = "SELECT Nit As vendedor , SUM(Ppto_total )As Vr_total, mes ,(año)As ano " & _
                                                            "FROM Jjv_ppto_vtas_recaudos_consol " & _
                                                        "WHERE(año = " & ano & " And Nit = " & vendedor & ") " & _
                                                                "GROUP BY  Nit,mes,año"
                        Dim sql_ppto_vtas As String = "SELECT vendedor , SUM(Vr_total)As Vr_total,MONTH (Fecha_ppto )  As mes ,YEAR (Fecha_ppto )As ano " & _
                                                    "FROM Jjv_Ppto_mes  " & _
                                                        "WHERE YEAR(Fecha_ppto)=" & ano & " and vendedor = " & vendedor & " " & _
                                                             "GROUP BY  vendedor,MONTH (Fecha_ppto ),YEAR (Fecha_ppto )  "

                        dt_efic = objOpSimplesLn.listar_datatable(sql_vtas, "CORSAN")
                        Dim dt_ppto_vtas As DataTable = objOpSimplesLn.listar_datatable(sql_ppto_vtas, "CORSAN")
                        Dim dt_rec As DataTable = objOpSimplesLn.listar_datatable(sql_rec, "CORSAN")
                        Dim dt_ppto_rec As DataTable = objOpSimplesLn.listar_datatable(sql_ppto_rec, "CORSAN")
                        dt_efic.Columns.Add("ppto_vtas", GetType(Double))
                        dt_efic.Columns.Add("efic_vtas", GetType(Double))
                        dt_efic.Columns.Add("recaudos", GetType(Double))
                        dt_efic.Columns.Add("ppto_rec", GetType(Double))
                        dt_efic.Columns.Add("efic_rec", GetType(Double))

                        For i = 0 To dt_efic.Rows.Count - 1
                            For j = 0 To dt_ppto_vtas.Rows.Count - 1
                                If (dt_efic.Rows(i).Item("mes") = dt_ppto_vtas.Rows(j).Item("mes") And dt_efic.Rows(i).Item("ano") = dt_ppto_vtas.Rows(j).Item("ano")) Then
                                    dt_efic.Rows(i).Item("ppto_vtas") = dt_ppto_vtas.Rows(j).Item("Vr_total")
                                    If Not IsDBNull(dt_ppto_vtas.Rows(j).Item("Vr_total")) Then
                                        dt_efic.Rows(i).Item("efic_vtas") = (dt_efic.Rows(i).Item("ventas") / dt_ppto_vtas.Rows(j).Item("Vr_total")) * 100
                                    End If
                                    j = dt_ppto_vtas.Rows.Count - 1
                                End If
                            Next
                            For k = 0 To dt_rec.Rows.Count - 1
                                If (dt_efic.Rows(i).Item("mes") = dt_rec.Rows(k).Item("mes") And dt_efic.Rows(i).Item("ano") = dt_rec.Rows(k).Item("ano")) Then
                                    dt_efic.Rows(i).Item("recaudos") = dt_rec.Rows(k).Item("recaudos")
                                    k = dt_rec.Rows.Count - 1
                                End If
                            Next
                            For z = 0 To dt_ppto_rec.Rows.Count - 1
                                If (dt_efic.Rows(i).Item("mes") = dt_ppto_rec.Rows(z).Item("mes") And dt_efic.Rows(i).Item("ano") = dt_ppto_rec.Rows(z).Item("ano")) Then
                                    dt_efic.Rows(i).Item("ppto_rec") = dt_ppto_rec.Rows(z).Item("Vr_total")
                                    If Not IsDBNull(dt_ppto_rec.Rows(z).Item("Vr_total")) Then
                                        dt_efic.Rows(i).Item("efic_rec") = (dt_efic.Rows(i).Item("recaudos") / dt_ppto_rec.Rows(z).Item("Vr_total")) * 100
                                    End If
                                    z = dt_ppto_rec.Rows.Count - 1
                                End If
                            Next
                        Next


                        For i = 0 To dt_ppto_vtas.Rows.Count - 1
                            For j = 0 To dt_efic.Rows.Count - 1
                                If (dt_efic.Rows(j).Item("mes") = dt_ppto_vtas.Rows(i).Item("mes") And dt_efic.Rows(j).Item("ano") = dt_ppto_vtas.Rows(i).Item("ano")) Then
                                    dt_efic.Rows(j).Item("ppto_vtas") = dt_ppto_vtas.Rows(i).Item("Vr_total")
                                    If Not IsDBNull(dt_ppto_vtas.Rows(i).Item("Vr_total")) Then
                                        dt_efic.Rows(j).Item("efic_vtas") = (dt_efic.Rows(j).Item("ventas") / dt_ppto_vtas.Rows(i).Item("Vr_total")) * 100
                                    End If

                                End If
                            Next

                        Next
                        If (dt_ppto_vtas.Rows.Count - 1 <> 0) Then
                            dt_efic.Rows.Add()
                            Dim sum_vtas As Double = 0
                            Dim sum_ppto_vtas As Double = 0
                            Dim sum_rec As Double = 0
                            Dim sum_ppto_rec As Double = 0
                            For i = 0 To dt_efic.Rows.Count - 1
                                If Not IsDBNull(dt_efic.Rows(i).Item("ppto_vtas")) Then
                                    If Not IsDBNull(dt_efic.Rows(i).Item("ventas")) Then
                                        sum_vtas += dt_efic.Rows(i).Item("ventas")
                                        sum_ppto_vtas += dt_efic.Rows(i).Item("ppto_vtas")
                                        sum_rec += dt_efic.Rows(i).Item("recaudos")
                                        sum_ppto_rec += dt_efic.Rows(i).Item("ppto_rec")
                                    End If
                                End If
                            Next
                            dt_efic.Rows(dt_efic.Rows.Count - 1).Item("ppto_vtas") = sum_ppto_vtas
                            dt_efic.Rows(dt_efic.Rows.Count - 1).Item("ventas") = sum_vtas
                            dt_efic.Rows(dt_efic.Rows.Count - 1).Item("efic_vtas") = (sum_vtas / sum_ppto_vtas) * 100
                            dt_efic.Rows(dt_efic.Rows.Count - 1).Item("efic_rec") = (sum_rec / sum_ppto_rec) * 100
                            dt_efic.Rows(dt_efic.Rows.Count - 1).Item("recaudos") = sum_rec
                            dt_efic.Rows(dt_efic.Rows.Count - 1).Item("ppto_rec") = sum_ppto_rec
                        End If
                        dtg_efic.DataSource = dt_efic
                        dtg_efic.Rows(dtg_efic.Rows.Count - 1).DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!, System.Drawing.FontStyle.Bold)
                        dtg_efic.Columns("efic_vtas").DefaultCellStyle.Format = "N2"
                        ' dtg_efic.Columns("ppto_vtas").Visible = False
                        dtg_efic.Columns("efic_rec").DefaultCellStyle.Format = "N2"
                        'dtg_efic.Columns("ppto_rec").Visible = False
                        'dtg_efic.Columns("recaudos").Visible = False
                        'dtg_efic.Columns("ventas").Visible = False
                        dtg_efic.Columns("vendedor").Visible = False
                        dtg_efic.Columns("mes").Visible = False
                        dtg_efic.Columns("ano").Visible = False
                        dtg_efic.Columns("mes_").Frozen = True
                    Else
                        MessageBox.Show("El empleado seleccionado no es un vendedor", "Seleccione un vendedor", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                ElseIf (cbo_tipo.SelectedValue = 13) Then 'Para operarios
                    Dim centro As String = objIngresoProdLn.consultar_valor("SELECT centro FROM V_nom_personal_Activo_con_maquila WHERE nit =" & nit, "CORSAN")
                    Dim sql_metas As String = "SELECT tipo,maquina,meta FROM J_metas_centro_maquina WHERE centro = " & centro & ""
                    Dim dt_metas As DataTable = objOpSimplesLn.listar_datatable(sql_metas, "PRODUCCION")
                    'AUSENTIMOS
                    Dim sql_ausentismos As String = "select SUM (horas )+(select SUM (horas)As total  FROM Jjv_nom_detalle_incap where nit =" & nit & " AND  YEAR (fecha_inicial )=" & ano & " ) " & _
                                                        "FROM Jjv_otros_Ausentismos " & _
                                                            "WHERE nit = " & nit & " AND YEAR (fecha )=" & ano & " "
                    Dim horas_ausentismos As String = objOpSimplesLn.consultarVal(sql_ausentismos)
                    Dim horas_habiles_ano As String = objOpSimplesLn.consultarVal("select SUM (Dias_habil )*8 As horas_habiles from Jjv_dias_habiles where Ano = " & ano & "")
                    dt_efic.Columns.Add("tipo_meta")
                    dt_efic.Columns.Add("tipo")
                    dt_efic.Columns.Add("valor", GetType(Double))
                    dt_efic.Columns.Add("total", GetType(Double))
                    dt_efic.Columns.Add("porcentaje", GetType(Double))
                    dt_efic.Columns.Add("meta", GetType(Double))
                    dt_efic.Columns.Add("efectividad", GetType(Double))
                    dt_efic.Columns.Add("ano", GetType(Double))
                    dt_efic.Columns.Add("maquina")
                    dt_efic.Rows.Add()
                    dt_efic.Rows(dt_efic.Rows.Count - 1).Item("tipo_meta") = 2
                    If (horas_ausentismos <> "") Then
                        dt_efic.Rows(dt_efic.Rows.Count - 1).Item("tipo") = "(Horas)CONSOLIDADO DE AUSENTISMOS"
                        dt_efic.Rows(dt_efic.Rows.Count - 1).Item("valor") = horas_ausentismos
                        dt_efic.Rows(dt_efic.Rows.Count - 1).Item("total") = horas_habiles_ano
                        dt_efic.Rows(dt_efic.Rows.Count - 1).Item("porcentaje") = (horas_ausentismos / horas_habiles_ano) * 100
                        dt_efic.Rows(dt_efic.Rows.Count - 1).Item("ano") = ano
                        For k = 0 To dt_metas.Rows.Count - 1
                            If (dt_metas.Rows(k).Item("tipo") = 2) Then
                                dt_efic.Rows(dt_efic.Rows.Count - 1).Item("meta") = dt_metas.Rows(k).Item("meta")
                            End If
                        Next
                    Else
                        dt_efic.Rows(dt_efic.Rows.Count - 1).Item("tipo") = "NO TIENE AUSENTISMOS"
                        dt_efic.Rows(dt_efic.Rows.Count - 1).Item("porcentaje") = 0
                        dt_efic.Rows(dt_efic.Rows.Count - 1).Item("efectividad") = 100
                    End If
                    'EFICIENCIAS
                    Dim sql_efic_operario As String = "SELECT SUM (E.producido)As producido ,SUM (E.esperado)As esperado,C.centro,( CAST (C.centro AS varchar(25))+ '-' + C.descripcion )As desc_centro " & _
                                                                "FROM J_eficiencias_generales_ano E ,CORSAN.dbo.centros C " & _
                                                                        "WHERE E.nit =" & nit & " AND E.ano = " & ano & " AND E.centro = C.centro  " & _
                                                                            "GROUP BY C.centro ,C.descripcion "
                    Dim dt As DataTable = objOpSimplesLn.listar_datatable(sql_efic_operario, "PRODUCCION")
                    Dim sql_efic_tref As String = "SELECT SUM (t.pod_total)As producido , SUM (t.kilos_esp ) As esperado,c.centro,( CAST (c.centro AS varchar(25))+ '-' + c.descripcion + '-'+t.maquina  )As desc_centro,nit,t.codigoM " & _
                                                        "FROM j_v_tref3 t , CORSAN.dbo.centros c " & _
                                                                        "WHERE Year(t.fecha) = " & ano & " And c.centro = 2100 AND t.nit =" & nit & " " & _
                                                                "GROUP BY  c.centro,c.descripcion,t.nit,t.maquina,t.codigoM  "
                    Dim dt_efic_tref As DataTable = objOpSimplesLn.listar_datatable(sql_efic_tref, "PRODUCCION")
                    Dim sum_prod As Double = 0
                    Dim sum_esp As Double = 0
                    If (dt.Rows.Count > 0) Then
                        For i = 0 To dt.Rows.Count - 1
                            dt_efic.Rows.Add()
                            dt_efic.Rows(dt_efic.Rows.Count - 1).Item("tipo_meta") = 1
                            sum_prod = dt.Rows(i).Item("producido")
                            sum_esp = dt.Rows(i).Item("esperado")
                            dt_efic.Rows(dt_efic.Rows.Count - 1).Item("valor") = dt.Rows(i).Item("producido")
                            dt_efic.Rows(dt_efic.Rows.Count - 1).Item("total") = dt.Rows(i).Item("esperado")
                            dt_efic.Rows(dt_efic.Rows.Count - 1).Item("tipo") = "EFICIENCIA EN: " & dt.Rows(i).Item("desc_centro")
                            dt_efic.Rows(dt_efic.Rows.Count - 1).Item("porcentaje") = (dt.Rows(i).Item("producido") / dt.Rows(i).Item("esperado")) * 100
                            dt_efic.Rows(dt_efic.Rows.Count - 1).Item("ano") = ano
                            For k = 0 To dt_metas.Rows.Count - 1
                                If (dt_metas.Rows(k).Item("tipo") = 1) Then
                                    dt_efic.Rows(dt_efic.Rows.Count - 1).Item("meta") = dt_metas.Rows(k).Item("meta")
                                End If
                            Next
                        Next
                    ElseIf (dt_efic_tref.Rows.Count > 0) Then
                        For i = 0 To dt_efic_tref.Rows.Count - 1
                            dt_efic.Rows.Add()
                            dt_efic.Rows(dt_efic.Rows.Count - 1).Item("tipo_meta") = 1
                            sum_prod += dt_efic_tref.Rows(i).Item("producido")
                            sum_esp += dt_efic_tref.Rows(i).Item("esperado")
                            dt_efic.Rows(dt_efic.Rows.Count - 1).Item("maquina") = dt_efic_tref.Rows(i).Item("codigoM")
                            dt_efic.Rows(dt_efic.Rows.Count - 1).Item("valor") = dt_efic_tref.Rows(i).Item("producido")
                            dt_efic.Rows(dt_efic.Rows.Count - 1).Item("total") = dt_efic_tref.Rows(i).Item("esperado")
                            dt_efic.Rows(dt_efic.Rows.Count - 1).Item("tipo") = "EFICIENCIA EN: " & dt_efic_tref.Rows(i).Item("desc_centro")
                            dt_efic.Rows(dt_efic.Rows.Count - 1).Item("porcentaje") = (dt_efic_tref.Rows(i).Item("producido") / dt_efic_tref.Rows(i).Item("esperado")) * 100
                            dt_efic.Rows(dt_efic.Rows.Count - 1).Item("ano") = ano
                            For k = 0 To dt_metas.Rows.Count - 1
                                If (dt_metas.Rows(k).Item("tipo") = 1) Then
                                    If dt_efic.Rows(dt_efic.Rows.Count - 1).Item("maquina") = dt_metas.Rows(k).Item("maquina") Then
                                        dt_efic.Rows(dt_efic.Rows.Count - 1).Item("meta") = dt_metas.Rows(k).Item("meta")
                                    End If
                                End If
                            Next
                        Next
                    Else
                        dt_efic.Rows.Add()
                        dt_efic.Rows(dt_efic.Rows.Count - 1).Item("tipo_meta") = 1
                        dt_efic.Rows(dt_efic.Rows.Count - 1).Item("tipo") = "NO EXISTEN EFICIENCIAS"
                    End If
                    If (dt.Rows.Count > 1 Or dt_efic_tref.Rows.Count > 0) Then
                        dt_efic.Rows.Add()
                        dt_efic.Rows(dt_efic.Rows.Count - 1).Item("valor") = sum_prod
                        dt_efic.Rows(dt_efic.Rows.Count - 1).Item("total") = sum_esp
                        dt_efic.Rows(dt_efic.Rows.Count - 1).Item("tipo") = "CONSOLIDADO DE EFICIENCIA"
                        dt_efic.Rows(dt_efic.Rows.Count - 1).Item("porcentaje") = (sum_prod / sum_esp) * 100
                        dt_efic.Rows(dt_efic.Rows.Count - 1).Item("ano") = ano
                        dt_efic.Rows(dt_efic.Rows.Count - 1).Item("meta") = 85
                    End If
                    'Eficienias generales por area
                    sql_efic_operario = "SELECT E.ano,E.producido,E.esperado,( CAST (C.centro AS varchar(25))+ '-' + C.descripcion )As desc_centro " & _
                                                                               "FROM J_eficiencia_por_centro E ,CORSAN.dbo.centros C  " & _
                                                                                           "WHERE C.centro = E.centro AND E.centro = " & centro
                    dt = New DataTable
                    dt = objOpSimplesLn.listar_datatable(sql_efic_operario, "PRODUCCION")
                    If (dt.Rows.Count > 0) Then
                        For i = 0 To dt.Rows.Count - 1
                            dt_efic.Rows.Add()
                            sum_prod = dt.Rows(i).Item("producido")
                            sum_esp = dt.Rows(i).Item("esperado")
                            dt_efic.Rows(dt_efic.Rows.Count - 1).Item("valor") = sum_prod
                            dt_efic.Rows(dt_efic.Rows.Count - 1).Item("total") = sum_esp
                            dt_efic.Rows(dt_efic.Rows.Count - 1).Item("tipo") = "EFICIENCIA EN: " & dt.Rows(i).Item("desc_centro")
                            dt_efic.Rows(dt_efic.Rows.Count - 1).Item("porcentaje") = (dt.Rows(i).Item("producido") / dt.Rows(i).Item("esperado")) * 100
                            dt_efic.Rows(dt_efic.Rows.Count - 1).Item("ano") = ano
                        Next
                    End If
                    'DESPERDICIOS
                    Dim prod_desperdicio As Double = 0
                    Dim desperdicio As Double = 0
                    Dim sql_desperdicios As String = "SELECT SUM (D.producido)As producido ,SUM (D.desperdicio)As desperdicio,C.centro,( CAST (C.centro AS varchar(25))+ '-' + C.descripcion )As desc_centro " & _
                                                                "FROM J_desperdicio_por_centro D ,CORSAN.dbo.centros C " & _
                                                                      "WHERE D.ano = " & ano & " And D.centro = C.centro AND C.centro = " & centro & "" & _
                                                                            "GROUP BY C.centro ,C.descripcion"
                    Dim dt_desperdicio As DataTable = objOpSimplesLn.listar_datatable(sql_desperdicios, "PRODUCCION")
                    dt_efic.Rows.Add()
                    dt_efic.Rows(dt_efic.Rows.Count - 1).Item("tipo_meta") = 3
                    If (dt_desperdicio.Rows.Count > 0) Then
                        For i = 0 To dt_desperdicio.Rows.Count - 1
                            prod_desperdicio = dt_desperdicio.Rows(i).Item("producido")
                            desperdicio = dt_desperdicio.Rows(i).Item("desperdicio")
                            dt_efic.Rows(dt_efic.Rows.Count - 1).Item("valor") = desperdicio
                            dt_efic.Rows(dt_efic.Rows.Count - 1).Item("total") = prod_desperdicio
                            dt_efic.Rows(dt_efic.Rows.Count - 1).Item("tipo") = "% DESPERDICIO EN: " & dt_desperdicio.Rows(i).Item("desc_centro")
                            dt_efic.Rows(dt_efic.Rows.Count - 1).Item("porcentaje") = (dt_desperdicio.Rows(i).Item("desperdicio") / dt_desperdicio.Rows(i).Item("producido")) * 100
                            dt_efic.Rows(dt_efic.Rows.Count - 1).Item("ano") = ano
                        Next
                        For k = 0 To dt_metas.Rows.Count - 1
                            If (dt_metas.Rows(k).Item("tipo") = 3) Then
                                dt_efic.Rows(dt_efic.Rows.Count - 1).Item("meta") = dt_metas.Rows(k).Item("meta")
                            End If
                        Next
                    Else
                        dt_efic.Rows(dt_efic.Rows.Count - 1).Item("tipo") = "NO TIENE DESPERDICIOS REGISTRADOS"
                        dt_efic.Rows(dt_efic.Rows.Count - 1).Item("efectividad") = 100
                    End If


                    'NO CONFORMIDADES

                    Dim prod_no_conformes As Double = 0
                    Dim kg_no_conformes As Double = 0
                    Dim sql_no_conformes As String = "SELECT SUM (n.producido)As producido ,SUM (n.kg_no_conformes)As kg_no_conformes,C.centro,( CAST (C.centro AS varchar(25))+ '-' + C.descripcion )As desc_centro " & _
                                                                "FROM J_no_conformidades_por_centro n ,CORSAN.dbo.centros C " & _
                                                                      "WHERE n.ano = " & ano & " And n.centro = C.centro AND C.centro = " & centro & "" & _
                                                                            "GROUP BY C.centro ,C.descripcion"
                    Dim dt_no_conformes As DataTable = objOpSimplesLn.listar_datatable(sql_no_conformes, "PRODUCCION")
                    dt_efic.Rows.Add()
                    dt_efic.Rows(dt_efic.Rows.Count - 1).Item("tipo_meta") = 4
                    If (dt_no_conformes.Rows.Count > 0) Then
                        For i = 0 To dt_no_conformes.Rows.Count - 1
                            prod_no_conformes = dt_no_conformes.Rows(i).Item("producido")
                            kg_no_conformes = dt_no_conformes.Rows(i).Item("kg_no_conformes")
                            dt_efic.Rows(dt_efic.Rows.Count - 1).Item("valor") = kg_no_conformes
                            dt_efic.Rows(dt_efic.Rows.Count - 1).Item("total") = prod_no_conformes
                            dt_efic.Rows(dt_efic.Rows.Count - 1).Item("tipo") = "% NO CONFORMIDADES EN: " & dt_no_conformes.Rows(i).Item("desc_centro")
                            dt_efic.Rows(dt_efic.Rows.Count - 1).Item("porcentaje") = (dt_no_conformes.Rows(i).Item("kg_no_conformes") / dt_no_conformes.Rows(i).Item("producido")) * 100
                            dt_efic.Rows(dt_efic.Rows.Count - 1).Item("ano") = ano
                        Next
                        For k = 0 To dt_metas.Rows.Count - 1
                            If (dt_metas.Rows(k).Item("tipo") = 4) Then
                                dt_efic.Rows(dt_efic.Rows.Count - 1).Item("meta") = dt_metas.Rows(k).Item("meta")
                            End If
                        Next
                    Else
                        dt_efic.Rows(dt_efic.Rows.Count - 1).Item("tipo") = "NO TIENE DESPERDICIOS REGISTRADOS"
                        dt_efic.Rows(dt_efic.Rows.Count - 1).Item("efectividad") = 100
                    End If
                ElseIf (cbo_tipo.SelectedValue = 1) Then 'Para COORDINADORES
                    dt_efic.Columns.Add("tipo")
                    dt_efic.Columns.Add("valor", GetType(Double))
                    dt_efic.Columns.Add("total", GetType(Double))
                    dt_efic.Columns.Add("porcentaje", GetType(Double))
                    dt_efic.Columns.Add("ano", GetType(Double))
                    dt_efic.Columns.Add("centro", GetType(Double))

                    Dim centros As String = ""
                    Dim listCentros As DataTable = objOpSimplesLn.listar_datatable("SELECT centro FROM J_coordinador_centros_costos WHERE nit =" & nit, "PRODUCCION")
                    For i = 0 To listCentros.Rows.Count - 1
                        centros &= listCentros.Rows(i).Item("centro")
                        If (i <> listCentros.Rows.Count - 1) Then
                            centros &= ","
                        End If
                    Next
                    If (centros <> "") Then
                        'AUSENTIMOS
                        Dim sqlTotEmp As String = ""
                        Dim tot_empleados As String = ""
                        Dim sql_ausentismos As String = "SELECT i.centro,i.Descr_centro , SUM (i.horas)As total " & _
                                                            " FROM Jjv_nom_detalle_incap i " & _
                                                                            "WHERE   YEAR (i.fecha_inicial )=" & ano & " AND i.centro in (" & centros & ") " & _
                                                                                    "GROUP BY I.centro,i.Descr_centro"

                        Dim dt_ausentismos As DataTable = objOpSimplesLn.listar_datatable(sql_ausentismos, "CORSAN")
                        Dim sql_otros_ausentismos As String = "SELECT o.centro,o.Descr_centro , SUM (o.horas)As total " & _
                                                          " FROM Jjv_otros_Ausentismos o " & _
                                                                          "WHERE   YEAR (o.fecha )=" & ano & " AND o.centro in (" & centros & ") " & _
                                                                                  "GROUP BY o.centro,o.Descr_centro"

                        Dim dt_otros_ausentismos As DataTable = objOpSimplesLn.listar_datatable(sql_otros_ausentismos, "CORSAN")
                        Dim horas_ausentismos As Double = 0
                        Dim horas_habiles_ano As String = objOpSimplesLn.consultarVal("select SUM (Dias_habil )*8 As horas_habiles from Jjv_dias_habiles where Ano = " & ano & "")
                        Dim centro_igual As Boolean = False
                        For i = 0 To dt_ausentismos.Rows.Count - 1
                            sqlTotEmp = "SELECT COUNT(distinct(p.nit))As tot_emp,mes,ano,centro " & _
                                          "FROM y_pago_nomina p " & _
                                                  "WHERE ano = " & ano & " AND centro = " & dt_ausentismos.Rows(i).Item("centro") & _
                                                                  "GROUP BY mes,ano,centro ORDER BY ano,mes "
                            tot_empleados = objOpSimplesLn.consultarVal(sqlTotEmp)
                            horas_ausentismos = dt_ausentismos.Rows(i).Item("total")
                            dt_efic.Rows.Add()
                            If (horas_ausentismos <> 0) Then
                                dt_efic.Rows(dt_efic.Rows.Count - 1).Item("valor") = horas_ausentismos
                                dt_efic.Rows(dt_efic.Rows.Count - 1).Item("total") = (horas_habiles_ano * tot_empleados)
                                dt_efic.Rows(dt_efic.Rows.Count - 1).Item("tipo") = "(Horas)AUSENTISMOS EN " & dt_ausentismos.Rows(i).Item("centro") & "-" & dt_ausentismos.Rows(i).Item("Descr_centro")
                                dt_efic.Rows(dt_efic.Rows.Count - 1).Item("porcentaje") = (horas_ausentismos / (horas_habiles_ano * tot_empleados)) * 100
                                dt_efic.Rows(dt_efic.Rows.Count - 1).Item("ano") = ano
                                dt_efic.Rows(dt_efic.Rows.Count - 1).Item("centro") = dt_ausentismos.Rows(i).Item("centro")
                            Else
                                dt_efic.Rows(dt_efic.Rows.Count - 1).Item("tipo") = "NO TIENE AUSENTISMOS EN " & dt_ausentismos.Rows(i).Item("centro") & "-" & dt_ausentismos.Rows(i).Item("Descr_centro")
                                dt_efic.Rows(dt_efic.Rows.Count - 1).Item("porcentaje") = 0
                                dt_efic.Rows(dt_efic.Rows.Count - 1).Item("centro") = dt_ausentismos.Rows(i).Item("centro")
                            End If
                            For j = 0 To dt_otros_ausentismos.Rows.Count - 1
                                If (dt_ausentismos.Rows(i).Item("centro") = dt_otros_ausentismos.Rows(j).Item("centro")) Then
                                    horas_ausentismos += dt_otros_ausentismos.Rows(j).Item("total")
                                    dt_efic.Rows(dt_efic.Rows.Count - 1).Item("valor") = horas_ausentismos
                                    dt_efic.Rows(dt_efic.Rows.Count - 1).Item("total") = (horas_habiles_ano * tot_empleados)
                                    centro_igual = True
                                    horas_ausentismos += dt_otros_ausentismos.Rows(j).Item("total")
                                    dt_efic.Rows(dt_efic.Rows.Count - 1).Item("porcentaje") = (horas_ausentismos / (horas_habiles_ano * tot_empleados)) * 100
                                End If
                                If (j = dt_otros_ausentismos.Rows.Count - 1) Then
                                    If (centro_igual = False) Then
                                        sqlTotEmp = "SELECT COUNT(distinct(p.nit))As tot_emp,mes,ano,centro " & _
                                          "FROM y_pago_nomina p " & _
                                                  "WHERE ano = " & ano & " AND centro = " & dt_ausentismos.Rows(i).Item("centro") & _
                                                                  "GROUP BY mes,ano,centro ORDER BY ano,mes "
                                        tot_empleados = objOpSimplesLn.consultarVal(sqlTotEmp)
                                        horas_ausentismos = dt_otros_ausentismos.Rows(j).Item("total")
                                        dt_efic.Rows.Add()
                                        If (horas_ausentismos <> 0) Then
                                            dt_efic.Rows(dt_efic.Rows.Count - 1).Item("valor") = horas_ausentismos
                                            dt_efic.Rows(dt_efic.Rows.Count - 1).Item("total") = (horas_habiles_ano * tot_empleados)
                                            dt_efic.Rows(dt_efic.Rows.Count - 1).Item("tipo") = "(Horas)AUSENTISMOS EN " & dt_otros_ausentismos.Rows(j).Item("centro") & "-" & dt_otros_ausentismos.Rows(j).Item("Descr_centro")
                                            dt_efic.Rows(dt_efic.Rows.Count - 1).Item("porcentaje") = (horas_ausentismos / (horas_habiles_ano * tot_empleados)) * 100
                                            dt_efic.Rows(dt_efic.Rows.Count - 1).Item("ano") = ano
                                            dt_efic.Rows(dt_efic.Rows.Count - 1).Item("centro") = dt_otros_ausentismos.Rows(j).Item("centro")
                                        Else
                                            dt_efic.Rows(dt_efic.Rows.Count - 1).Item("tipo") = "NO TIENE AUSENTISMOS EN " & dt_otros_ausentismos.Rows(j).Item("centro") & "-" & dt_otros_ausentismos.Rows(j).Item("Descr_centro")
                                            dt_efic.Rows(dt_efic.Rows.Count - 1).Item("porcentaje") = 0
                                            dt_efic.Rows(dt_efic.Rows.Count - 1).Item("centro") = dt_otros_ausentismos.Rows(j).Item("centro")
                                        End If
                                    End If
                                    centro_igual = True
                                End If
                            Next
                        Next

                        'EFICIENCIAS
                        Dim centro2100 As Boolean = False
                        For i = 0 To listCentros.Rows.Count - 1
                            If (listCentros.Rows(i).Item("centro") = 2100) Then
                                centro2100 = True
                            End If
                        Next
                        Dim sql_efic As String = "SELECT SUM (E.producido)As producido ,SUM (E.esperado)As esperado,C.centro,( CAST (C.centro AS varchar(25))+ '-' + C.descripcion )As desc_centro " & _
                                                                    "FROM J_eficiencias_generales_ano E ,CORSAN.dbo.centros C " & _
                                                                            "WHERE C.centro in (" & centros & ") AND E.ano = " & ano & " AND E.centro = C.centro  " & _
                                                                                "GROUP BY C.centro ,C.descripcion"
                        Dim dt As DataTable = objOpSimplesLn.listar_datatable(sql_efic, "PRODUCCION")
                        Dim sql_efic_tref As String = "SELECT SUM (t.pod_total)As producido , SUM (t.kilos_esp ) As esperado,c.centro,( CAST (c.centro AS varchar(25))+ '-' + c.descripcion + '-'+t.maquina  )As desc_centro " & _
                                                       "FROM j_v_tref3 t , CORSAN.dbo.centros c " & _
                                                                       "WHERE Year(t.fecha) = " & ano & " And c.centro IN  (2100)  " & _
                                                               "GROUP BY  c.centro,c.descripcion,t.maquina "
                        Dim dt_efic_tref As DataTable = objOpSimplesLn.listar_datatable(sql_efic_tref, "PRODUCCION")
                        Dim sum_prod As Double = 0
                        Dim sum_esp As Double = 0
                        If (dt.Rows.Count > 0) Then
                            For i = 0 To dt.Rows.Count - 1
                                dt_efic.Rows.Add()
                                sum_prod = dt.Rows(i).Item("producido")
                                sum_esp = dt.Rows(i).Item("esperado")
                                dt_efic.Rows(dt_efic.Rows.Count - 1).Item("valor") = sum_prod
                                dt_efic.Rows(dt_efic.Rows.Count - 1).Item("total") = sum_esp
                                dt_efic.Rows(dt_efic.Rows.Count - 1).Item("tipo") = "EFICIENCIA EN: " & dt.Rows(i).Item("desc_centro")
                                dt_efic.Rows(dt_efic.Rows.Count - 1).Item("porcentaje") = (dt.Rows(i).Item("producido") / dt.Rows(i).Item("esperado")) * 100
                                dt_efic.Rows(dt_efic.Rows.Count - 1).Item("ano") = ano
                                dt_efic.Rows(dt_efic.Rows.Count - 1).Item("centro") = dt.Rows(i).Item("centro")
                            Next
                        ElseIf (dt_efic_tref.Rows.Count > 0 And centro2100) Then
                            For i = 0 To dt_efic_tref.Rows.Count - 1
                                dt_efic.Rows.Add()
                                sum_prod = dt_efic_tref.Rows(i).Item("producido")
                                sum_esp = dt_efic_tref.Rows(i).Item("esperado")
                                dt_efic.Rows(dt_efic.Rows.Count - 1).Item("valor") = dt_efic_tref.Rows(i).Item("producido")
                                dt_efic.Rows(dt_efic.Rows.Count - 1).Item("total") = dt_efic_tref.Rows(i).Item("esperado")
                                dt_efic.Rows(dt_efic.Rows.Count - 1).Item("tipo") = "EFICIENCIA EN: " & dt_efic_tref.Rows(i).Item("desc_centro")
                                dt_efic.Rows(dt_efic.Rows.Count - 1).Item("porcentaje") = (dt_efic_tref.Rows(i).Item("producido") / dt_efic_tref.Rows(i).Item("esperado")) * 100
                                dt_efic.Rows(dt_efic.Rows.Count - 1).Item("ano") = ano
                                dt_efic.Rows(dt_efic.Rows.Count - 1).Item("centro") = dt_efic_tref.Rows(i).Item("centro")
                            Next
                        Else
                            dt_efic.Rows.Add()
                            dt_efic.Rows(dt_efic.Rows.Count - 1).Item("tipo") = "NO EXISTEN EFICIENCIAS"
                        End If
                        'Eficienias generales por area
                        sql_efic = "SELECT E.ano,E.producido,E.esperado,C.centro,( CAST (C.centro AS varchar(25))+ '-' + C.descripcion )As desc_centro " & _
                                                                                   "FROM  J_eficiencia_por_centro E, CORSAN.dbo.centros C  " & _
                                                                                               "WHERE C.centro = E.centro AND C.centro in (" & centros & ") "
                        dt = New DataTable
                        dt = objOpSimplesLn.listar_datatable(sql_efic, "PRODUCCION")
                        If (dt.Rows.Count > 0) Then
                            For i = 0 To dt.Rows.Count - 1
                                dt_efic.Rows.Add()
                                sum_prod = dt.Rows(i).Item("producido")
                                sum_esp = dt.Rows(i).Item("esperado")
                                dt_efic.Rows(dt_efic.Rows.Count - 1).Item("valor") = sum_prod
                                dt_efic.Rows(dt_efic.Rows.Count - 1).Item("total") = sum_esp
                                dt_efic.Rows(dt_efic.Rows.Count - 1).Item("tipo") = "EFICIENCIA EN: " & dt.Rows(i).Item("desc_centro")
                                dt_efic.Rows(dt_efic.Rows.Count - 1).Item("porcentaje") = (dt.Rows(i).Item("producido") / dt.Rows(i).Item("esperado")) * 100
                                dt_efic.Rows(dt_efic.Rows.Count - 1).Item("ano") = ano
                                dt_efic.Rows(dt_efic.Rows.Count - 1).Item("centro") = dt.Rows(i).Item("centro")
                            Next
                        End If
                        'DESPERDICIOS
                        Dim prod_desperdicio As Double = 0
                        Dim desperdicio As Double = 0
                        Dim sql_desperdicios As String = "SELECT SUM (D.producido)As producido ,SUM (D.desperdicio)As desperdicio,C.centro,( CAST (C.centro AS varchar(25))+ '-' + C.descripcion )As desc_centro " & _
                                                                    "FROM J_desperdicio_por_centro D ,CORSAN.dbo.centros C " & _
                                                                          "WHERE D.ano = " & ano & " And D.centro = C.centro AND C.centro in (" & centros & ")" & _
                                                                                "GROUP BY C.centro ,C.descripcion"
                        Dim dt_desperdicio As DataTable = objOpSimplesLn.listar_datatable(sql_desperdicios, "PRODUCCION")
                        If (dt_desperdicio.Rows.Count > 0) Then
                            For i = 0 To dt_desperdicio.Rows.Count - 1
                                dt_efic.Rows.Add()
                                prod_desperdicio = dt_desperdicio.Rows(i).Item("producido")
                                desperdicio = dt_desperdicio.Rows(i).Item("desperdicio")
                                dt_efic.Rows(dt_efic.Rows.Count - 1).Item("valor") = desperdicio
                                dt_efic.Rows(dt_efic.Rows.Count - 1).Item("total") = prod_desperdicio
                                dt_efic.Rows(dt_efic.Rows.Count - 1).Item("tipo") = "% DESPERDICIO EN: " & dt_desperdicio.Rows(i).Item("desc_centro")
                                dt_efic.Rows(dt_efic.Rows.Count - 1).Item("porcentaje") = (dt_desperdicio.Rows(i).Item("desperdicio") / dt_desperdicio.Rows(i).Item("producido")) * 100
                                dt_efic.Rows(dt_efic.Rows.Count - 1).Item("ano") = ano
                                dt_efic.Rows(dt_efic.Rows.Count - 1).Item("centro") = dt_desperdicio.Rows(i).Item("centro")
                            Next
                        Else
                            dt_efic.Rows(dt_efic.Rows.Count - 1).Item("tipo") = "NO TIENE DESPERDICIOS REGISTRADOS"
                        End If


                        'NO CONFORMIDADES

                        Dim prod_no_conformes As Double = 0
                        Dim kg_no_conformes As Double = 0
                        Dim sql_no_conformes As String = "SELECT SUM (n.producido)As producido ,SUM (n.kg_no_conformes)As kg_no_conformes,C.centro,( CAST (C.centro AS varchar(25))+ '-' + C.descripcion )As desc_centro " & _
                                                                    "FROM J_no_conformidades_por_centro n ,CORSAN.dbo.centros C " & _
                                                                          "WHERE n.ano = " & ano & " And n.centro = C.centro AND C.centro in (" & centros & ")" & _
                                                                                "GROUP BY C.centro ,C.descripcion"
                        Dim dt_no_conformes As DataTable = objOpSimplesLn.listar_datatable(sql_no_conformes, "PRODUCCION")
                        If (dt_no_conformes.Rows.Count > 0) Then
                            For i = 0 To dt_no_conformes.Rows.Count - 1
                                dt_efic.Rows.Add()
                                prod_no_conformes = dt_no_conformes.Rows(i).Item("producido")
                                kg_no_conformes = dt_no_conformes.Rows(i).Item("kg_no_conformes")
                                dt_efic.Rows(dt_efic.Rows.Count - 1).Item("valor") = kg_no_conformes
                                dt_efic.Rows(dt_efic.Rows.Count - 1).Item("total") = prod_no_conformes
                                dt_efic.Rows(dt_efic.Rows.Count - 1).Item("tipo") = "% NO CONFORMIDADES EN: " & dt_no_conformes.Rows(i).Item("desc_centro")
                                dt_efic.Rows(dt_efic.Rows.Count - 1).Item("porcentaje") = (dt_no_conformes.Rows(i).Item("kg_no_conformes") / dt_no_conformes.Rows(i).Item("producido")) * 100
                                dt_efic.Rows(dt_efic.Rows.Count - 1).Item("ano") = ano
                                dt_efic.Rows(dt_efic.Rows.Count - 1).Item("centro") = dt_no_conformes.Rows(i).Item("centro")
                            Next
                        Else
                            dt_efic.Rows(dt_efic.Rows.Count - 1).Item("tipo") = "NO TIENE DESPERDICIOS REGISTRADOS"
                        End If

                        'Eficiencia de presupuestos

                        Dim ppto As Double = 0
                        Dim prod_pptos As Double = 0
                        Dim sql_pptos As String = "SELECT SUM (p.producido)As producido ,SUM (p.presupuesto)As presupuesto,C.centro,( CAST (C.centro AS varchar(25))+ '-' + C.descripcion )As desc_centro " & _
                                                                    "FROM J_eficiencia_prod_ppto p ,CORSAN.dbo.centros C " & _
                                                                          "WHERE p.ano = " & ano & " And p.centro = C.centro AND C.centro in (" & centros & ")" & _
                                                                                "GROUP BY C.centro ,C.descripcion"
                        Dim dt_efic_ppto As DataTable = objOpSimplesLn.listar_datatable(sql_pptos, "PRODUCCION")
                        If (dt_efic_ppto.Rows.Count > 0) Then
                            For i = 0 To dt_efic_ppto.Rows.Count - 1
                                dt_efic.Rows.Add()
                                prod_pptos = dt_efic_ppto.Rows(i).Item("producido")
                                ppto = dt_efic_ppto.Rows(i).Item("presupuesto")
                                dt_efic.Rows(dt_efic.Rows.Count - 1).Item("valor") = prod_pptos
                                dt_efic.Rows(dt_efic.Rows.Count - 1).Item("total") = ppto
                                dt_efic.Rows(dt_efic.Rows.Count - 1).Item("tipo") = "% CUMPLIMIENTO EN PRESUPUESTO DE PRODUCCIÓN: " & dt_efic_ppto.Rows(i).Item("desc_centro")
                                dt_efic.Rows(dt_efic.Rows.Count - 1).Item("porcentaje") = (dt_efic_ppto.Rows(i).Item("producido") / dt_efic_ppto.Rows(i).Item("presupuesto")) * 100
                                dt_efic.Rows(dt_efic.Rows.Count - 1).Item("ano") = ano
                                dt_efic.Rows(dt_efic.Rows.Count - 1).Item("centro") = dt_efic_ppto.Rows(i).Item("centro")
                            Next
                        Else
                            dt_efic.Rows(dt_efic.Rows.Count - 1).Item("tipo") = "NO TIENE PRESUPUESTOS DE PRODUCCIÓN REGISTRADOS"
                        End If

                        'Presupuesto de gastos
                        Dim ppto_gastos As Double = 0
                        Dim gastos As Double = 0
                        Dim sql_ppto_gactos As String = "SELECT SUM (p.gasto)As gasto ,SUM (p.presupuesto)As presupuesto,C.centro,( CAST (C.centro AS varchar(25))+ '-' + C.descripcion )As desc_centro " & _
                                                                    "FROM J_eficiencia_gastos_ppto p ,CORSAN.dbo.centros C " & _
                                                                          "WHERE p.ano = " & ano & " And p.centro = C.centro AND C.centro in (" & centros & ")" & _
                                                                                "GROUP BY C.centro ,C.descripcion"
                        Dim dt_efic_ppto_gastos As DataTable = objOpSimplesLn.listar_datatable(sql_ppto_gactos, "PRODUCCION")
                        If (dt_efic_ppto_gastos.Rows.Count > 0) Then
                            For i = 0 To dt_efic_ppto_gastos.Rows.Count - 1
                                dt_efic.Rows.Add()
                                gastos = dt_efic_ppto_gastos.Rows(i).Item("gasto")
                                ppto_gastos = dt_efic_ppto_gastos.Rows(i).Item("presupuesto")
                                dt_efic.Rows(dt_efic.Rows.Count - 1).Item("valor") = gastos
                                dt_efic.Rows(dt_efic.Rows.Count - 1).Item("total") = ppto_gastos
                                dt_efic.Rows(dt_efic.Rows.Count - 1).Item("tipo") = "% CUMPLIMIENTO EN PRESUPUESTO DE GASTOS: " & dt_efic_ppto_gastos.Rows(i).Item("desc_centro")
                                dt_efic.Rows(dt_efic.Rows.Count - 1).Item("porcentaje") = (dt_efic_ppto_gastos.Rows(i).Item("gasto") / dt_efic_ppto_gastos.Rows(i).Item("presupuesto")) * 100
                                dt_efic.Rows(dt_efic.Rows.Count - 1).Item("ano") = ano
                                dt_efic.Rows(dt_efic.Rows.Count - 1).Item("centro") = dt_efic_ppto_gastos.Rows(i).Item("centro")
                            Next
                        Else
                            dt_efic.Rows(dt_efic.Rows.Count - 1).Item("tipo") = "NO TIENE PRESUPUESTO DE GASTOS REGISTRADOS"
                        End If

                    Else
                        MessageBox.Show("El empleado seleccionado no tiene asiganados centros de costo de coordinador,por lo tanto no se cargaran eficiencias.", "No es Coordinador", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If

                End If
                calc_efectivad(dt_efic)
                dtg_efic.DataSource = dt_efic
                If (cbo_tipo.SelectedValue = 13) Then 'Para operarios
                    calificar_automatico(dt_efic)
                End If
                For i = 0 To dtg_efic.Columns.Count - 1
                    If (dtg_efic.Columns(i).Name = "porcentaje") Then
                        dtg_efic.Columns("porcentaje").DefaultCellStyle.Format = "N2"
                        dtg_efic.Columns("porcentaje").DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!, System.Drawing.FontStyle.Bold)
                    ElseIf (dtg_efic.Columns(i).Name = "maquina") Then
                        dtg_efic.Columns(i).Visible = False
                    ElseIf (dtg_efic.Columns(i).Name = "meta") Then
                        dtg_efic.Columns(i).DefaultCellStyle.Format = "N2"
                    ElseIf (dtg_efic.Columns(i).Name = "efectividad") Then
                        dtg_efic.Columns(i).DefaultCellStyle.Format = "N2"
                        dtg_efic.Columns(i).DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!, System.Drawing.FontStyle.Bold)
                    End If
                Next
            End If
        End If
    End Sub
    Private Sub calificar_automatico(ByVal dt_efic As DataTable)
        For i = 0 To dt_efic.Rows.Count - 1
            If IsNumeric(dt_efic.Rows(i).Item("tipo_meta")) Then
                For k = 0 To dtgEvaluacion.Rows.Count - 1
                    If IsNumeric(dtgEvaluacion.Item("tipo_meta", k).Value) Then
                        If dt_efic.Rows(i).Item("tipo_meta") = dtgEvaluacion.Item("tipo_meta", k).Value Then
                            If (dt_efic.Rows(i).Item("tipo_meta") = 1) Then
                                If dt_efic.Rows(i).Item("efectividad") <= 60 Then
                                    dtgEvaluacion.Item("col_calificacion", k).Value = 1
                                ElseIf (dt_efic.Rows(i).Item("efectividad") > 60 And dt_efic.Rows(i).Item("efectividad") <= 70) Then
                                    dtgEvaluacion.Item("col_calificacion", k).Value = 1
                                ElseIf (dt_efic.Rows(i).Item("efectividad") > 70 And dt_efic.Rows(i).Item("efectividad") < 80) Then
                                    dtgEvaluacion.Item("col_calificacion", k).Value = 2
                                ElseIf (dt_efic.Rows(i).Item("efectividad") >= 80 And dt_efic.Rows(i).Item("efectividad") < 90) Then
                                    dtgEvaluacion.Item("col_calificacion", k).Value = 3
                                ElseIf (dt_efic.Rows(i).Item("efectividad") >= 90 And dt_efic.Rows(i).Item("efectividad") < 100) Then
                                    dtgEvaluacion.Item("col_calificacion", k).Value = 4
                                ElseIf (dt_efic.Rows(i).Item("efectividad") >= 100) Then
                                    dtgEvaluacion.Item("col_calificacion", k).Value = 5
                                End If
                            ElseIf (dt_efic.Rows(i).Item("tipo_meta") = 2 Or dt_efic.Rows(i).Item("tipo_meta") = 3 Or dt_efic.Rows(i).Item("tipo_meta") = 4) Then
                                If dt_efic.Rows(i).Item("efectividad") <= 0 Then
                                    dtgEvaluacion.Item("col_calificacion", k).Value = 5
                                ElseIf (dt_efic.Rows(i).Item("efectividad") > 0 And dt_efic.Rows(i).Item("efectividad") <= 100) Then
                                    dtgEvaluacion.Item("col_calificacion", k).Value = 4
                                ElseIf (dt_efic.Rows(i).Item("efectividad") > 100 And dt_efic.Rows(i).Item("efectividad") < 105) Then
                                    dtgEvaluacion.Item("col_calificacion", k).Value = 3
                                ElseIf (dt_efic.Rows(i).Item("efectividad") >= 105 And dt_efic.Rows(i).Item("efectividad") < 110) Then
                                    dtgEvaluacion.Item("col_calificacion", k).Value = 2
                                ElseIf (dt_efic.Rows(i).Item("efectividad") >= 110) Then
                                    dtgEvaluacion.Item("col_calificacion", k).Value = 1
                                End If
                            End If
                        End If
                    End If
                Next
            End If
        Next
    End Sub
    Private Sub calc_efectivad(ByRef dt As DataTable)
        Dim nom_col As String = ""
        Dim porc As Double = 0
        Dim meta As Double = 0
        For j = 0 To dt.Columns.Count - 1
            nom_col = dt.Columns(j).ColumnName
            If (nom_col = "meta") Then
                For i = 0 To dt.Rows.Count - 1
                    If Not IsDBNull(dt.Rows(i).Item("porcentaje")) Then
                        porc = dt.Rows(i).Item("porcentaje")
                    End If
                    If Not IsDBNull(dt.Rows(i).Item("meta")) Then
                        meta = dt.Rows(i).Item("meta")
                    End If
                    If (meta <> 0 And porc <> 0) Then
                        dt.Rows(i).Item("efectividad") = (porc / meta) * 100
                    Else
                        dt.Rows(i).Item("efectividad") = 0
                    End If
                    porc = 0
                    meta = 0
                Next
                j = dt.Columns.Count - 1
            End If
        Next
    End Sub
    Private Sub btnGuardar_Click_1(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
        dtgEvaluacion.CurrentCell = Nothing
        If (validar()) Then
            aspectos_mejorar()
            Dim listSql As New List(Of Object)
            Dim nit_evaluado As Double = cbo_evaluado.SelectedValue
            Dim nit_evaluador As Double = cbo_evaluador.SelectedValue
            Dim observaciones As String = txtNotas.Text
            Dim fec As String = ""
            Dim id As String = 0
            Dim id_criterio As Integer = 0
            Dim calificacion As Double = 0
            Dim cal_general As Double = txt_calificacion.Text
            Dim id_tipo_eval As Integer = cbo_tipo.SelectedValue
            Dim nivel_educativo As Integer = cbo_nivel_educativo.SelectedValue
            If (id = "") Then
                id = 1
            End If
            If (id_evaluacion_existente <> 0) Then
                Dim sql_delete As String = "DELETE FROM J_eval_det WHERE id_enc = " & id_existente
                listSql.Add(sql_delete)
                sql_delete = "DELETE FROM J_eval_enc WHERE id = " & id_existente
                listSql.Add(sql_delete)
                fec = fec_excistente
                id = id_evaluacion_existente
            Else
                fec = objOpSimplesLn.cambiarFormatoFecha(Now)
                id = objOpSimplesLn.consultarVal("SELECT MAX (id)+1 FROM J_eval_enc")
            End If
            Dim sql_enc As String = "INSERT INTO J_eval_enc(id,nit,nit_eval,fecha,calificacion,observaciones,id_tipo_eval,nivel_educativo,tipo) " & _
                                    "VALUES (" & id & "," & nit_evaluado & "," & nit_evaluador & ",'" & fec & "'," & cal_general & ",'" & observaciones & "'," & id_tipo_eval & "," & nivel_educativo & ",'" & tipo_Evalua & "')"
            listSql.Add(sql_enc)
            Dim sql_det As String = ""
            For i = 0 To dtgEvaluacion.Rows.Count - 1
                If (dtgEvaluacion.Item("tipo_factor", i).Value <> "tipo_criterio") Then
                    id_criterio = dtgEvaluacion.Item("id_factor", i).Value
                    calificacion = dtgEvaluacion.Item("col_calificacion", i).Value
                    sql_det = "INSERT INTO J_eval_det (id_enc,id_criterio,calificacion) " &
                                              "VALUES(" & id & "," & id_criterio & "," & calificacion & ")"
                    listSql.Add(sql_det)
                End If
            Next
            If (objOpSimplesLn.ExecuteSqlTransaction(listSql)) Then
                MessageBox.Show("La evaluación se guardo en forma correcta", "Exito!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
                ' nuevo()
            Else
                MessageBox.Show("La evaluación no se guardo, comuniquese con el area de sistemas ", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub
    Private Sub aspectos_mejorar()
        Dim calificacion As Double = 0
        Dim notas As String = ""
        For i = 0 To dtgEvaluacion.Rows.Count - 1
            calificacion = dtgEvaluacion.Item("col_calificacion", i).Value
            If (calificacion <= 3) Then
                If notas = "" Then
                    notas = " - ASPECTOS A MEJORAR:"
                Else
                    notas &= " - "
                End If
                If (dtgEvaluacion.Item("col_factor", i).Value = "OBEJTIVOS DEL CARGO") Then
                    notas &= dtgEvaluacion.Item("col_descripcion", i).Value
                Else
                    notas &= dtgEvaluacion.Item("col_factor", i).Value
                End If
            End If
        Next
        txtNotas.Text &= notas
    End Sub
    Private Function calificar_ausentismos()
        Dim d_eg, d_at, d_lm, d_f_sin_jsutificar, d_susp, d_pno_remu As Integer
        Dim maxd_l_eg, maxd_l_at, maxd_l_lm, maxd_l_f_sin_jsutificar, maxd_l_susp, maxd_l_pno_remu As Integer
        Dim calc_eg, calc_at, calc_lm, calc_f_sin_jsutificar, calc_susp, calc_pno_remu, calc_total As Integer

        'INICIALIZAR dias normales
        maxd_l_eg = 10
        '  (20 * 365) / 100
        maxd_l_at = 30
        '(30 * 365) / 100
        maxd_l_lm = 120
        '(5 * 365) / 100
        maxd_l_f_sin_jsutificar = 1
        ' (10 * 365) / 100
        maxd_l_susp = 7
        '(30 * 365) / 100
        maxd_l_pno_remu = 2
        '(5 * 365) / 100

        Dim conceptos As String = "select concepto,sum(dias) as dias from JJV_nom_ausentismos_Varios where nit=" & cbo_evaluado.SelectedValue & " and ano=" & Now.Year & " group by concepto"
        Dim dt_concepto As DataTable = objOpSimplesLn.listar_datatable(conceptos, "CORSAN")
        For i = 0 To dt_concepto.Rows.Count - 1
            If dt_concepto.Rows(i).Item("concepto") = "5" Or dt_concepto.Rows(i).Item("concepto") = "9" Then
                d_eg += dt_concepto.Rows(i).Item("dias")
            ElseIf dt_concepto.Rows(i).Item("concepto") = "7" Then
                d_lm += dt_concepto.Rows(i).Item("dias")
            ElseIf dt_concepto.Rows(i).Item("concepto") = "516" Then
                d_f_sin_jsutificar += 1
            ElseIf dt_concepto.Rows(i).Item("concepto") = "512" Or dt_concepto.Rows(i).Item("concepto") = "511" Then
                d_susp += dt_concepto.Rows(i).Item("dias")
            ElseIf dt_concepto.Rows(i).Item("concepto") = "510" Then
                d_pno_remu += dt_concepto.Rows(i).Item("dias")
            ElseIf dt_concepto.Rows(i).Item("concepto") = "25" Or dt_concepto.Rows(i).Item("concepto") = "6" Then
                d_at += dt_concepto.Rows(i).Item("dias")
            End If
        Next
        calc_eg = maxd_l_eg - d_eg
        calc_lm = maxd_l_lm - d_lm
        calc_f_sin_jsutificar = maxd_l_f_sin_jsutificar - d_f_sin_jsutificar
        calc_susp = maxd_l_susp - d_susp
        calc_pno_remu = maxd_l_pno_remu - d_pno_remu
        calc_at = maxd_l_at - d_at

        If calc_eg < 0 Then
            calc_eg = 0
        End If
        If calc_lm < 0 Then
            calc_lm = 0
        End If
        If calc_f_sin_jsutificar < 0 Then
            calc_f_sin_jsutificar = 0
        End If
        If calc_susp < 0 Then
            calc_susp = 0
        End If
        If calc_pno_remu < 0 Then
            calc_pno_remu = 0
        End If
        If calc_at < 0 Then
            calc_at = 0
        End If

        calc_eg = (20 * calc_eg) / maxd_l_eg
        calc_at = (30 * calc_at) / maxd_l_at
        calc_lm = (5 * calc_lm) / maxd_l_lm
        calc_f_sin_jsutificar = (10 * calc_f_sin_jsutificar) / maxd_l_f_sin_jsutificar
        calc_pno_remu = (5 * calc_pno_remu) / maxd_l_pno_remu
        calc_susp = (30 * calc_susp) / maxd_l_susp
        calc_total = calc_eg + calc_at + calc_lm + calc_f_sin_jsutificar + calc_pno_remu + calc_susp
        nota_final = (5 * calc_total) / 100

        Return nota_final
    End Function
    Private Function calificar_desperdicios()
        Dim califica As Double
        Dim sql As String = "select centro from V_nom_personal_Activo_con_maquila where nit=" & cbo_evaluado.SelectedValue & ""
        Dim centro As String = objOpSimplesLn.consultValorTodo(sql, "CORSAN")
        sql = "select Id_area from D_cal_despe"
        Dim dt As DataTable = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")
        Dim resp As Boolean = False
        For i = 0 To dt.Rows.Count - 1
            If dt.Rows(i).Item("Id_area") = centro Then
                resp = True
            End If
        Next
        If resp = True Then
            sql = "select sum(kilos) from J_v_desperdicios where year(fecha)=" & Now.Year & " and centro=" & centro & " and nit=" & cbo_evaluado.SelectedValue & " "
            Dim kilos_desp = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")
            sql = "select calificacion from D_cal_despe where id_area=" & centro & ""
            Dim calificacion As Double = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")
            Select Case centro
                Case "2100"
                    sql = "SELECT  sum(R.peso) as peso FROM J_det_orden_prod O JOIN J_rollos_tref R on O.cod_orden=R.cod_orden AND O.id_detalle=R.id_detalle WHERE year(o.fecha_prod)=" & Now.Year & " and O.operario=" & cbo_evaluado.SelectedValue & " and R.manuales is null and R.no_conforme is null and R.anulado is null"
                Case "2300"
                    sql = "SELECT sum(peso) FROM J_orden_prod_punt_producto WHERE YEAR(fecha_hora) = " & Now.Year & " and nit_operario=" & cbo_evaluado.SelectedValue & " and anular is null"
                Case "5200"
                    sql = "select sum(peso) from D_rollo_galvanizado_f where year(fecha_hora) = " & Now.Year & " and nit_operario=" & cbo_evaluado.SelectedValue & " and anular is null"
            End Select
            Dim producido As String = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")
            Dim limite As Double = (producido * calificacion) / 100
            If kilos_desp >= limite Then
                nota_final = 1
            Else
                califica = (100 * kilos_desp) / limite
                nota_final = (5 * califica) / 100
            End If
        End If
        Return nota_final
    End Function
    Private Function calificar_nc()
        Dim sql As String = "select sum(cantidad) from D_no_conforme_eval where nit_operario=" & cbo_evaluado.SelectedValue & ""
        Dim cantidad As String = objOpSimplesLn.consultValorTodo(sql, "CONTROL")
        Dim nota As Double
        If cantidad = "" Then
            nota = "5"
        Else
            nota = "1"
        End If
        Return nota
    End Function

    Private Sub btnNuevo_Click_1(sender As System.Object, e As System.EventArgs) Handles btnNuevo.Click
        nuevo()
    End Sub

    Private Sub btn_imagen_Click_1(sender As System.Object, e As System.EventArgs) Handles btn_imagen.Click
        If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
            Dim ruta As String = SaveFileDialog1.FileName
            capturarPantalla(ruta)
        End If
    End Sub
    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        objOperacionesForm.ExportarDatosExcel_eval(dtgEvaluacion, cbo_tipo.Text, cbo_evaluado.Text & "    Cargo:" & txt_cargo_evaluado.Text, cbo_evaluador.Text & "    Cargo: " & txt_cargo_evaluador.Text, txt_antiguedad.Text, cbo_nivel_educativo.Text, txt_calificacion.Text, txtNotas.Text)
    End Sub
End Class
