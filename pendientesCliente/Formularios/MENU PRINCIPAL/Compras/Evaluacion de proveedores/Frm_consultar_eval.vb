Imports logicaNegocios
Imports entidadNegocios
Public Class Frm_consultar_eval
    Private objOpSimplesLn As New Op_simpesLn
    Private objIngresoProdLn As New Ing_prodLn
    Private objOperacionesForm As OperacionesFormularios = New OperacionesFormularios
    Private carga_comp As Boolean = False
    Private Sub Frm_consultar_eval_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cboFechaIni.Value = Now.AddMonths(-18)
        cboFechaFin.Value = Now
        Dim sql As String = "SELECT id,descripcion   FROM C_categorias_proveedores "
        cboCategoria.DataSource = objIngresoProdLn.listar_datatable(sql, "PRODUCCION")
        cboCategoria.ValueMember = "id"
        cboCategoria.DisplayMember = "descripcion"
        cboCategoria.Text = "Seleccione"
        carga_comp = True
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


Private Sub cargarConsulta()
        Dim fecIni As String = objOpSimplesLn.cambiarFormatoFecha(cboFechaIni.Value)
        Dim fecFin As String = objOpSimplesLn.cambiarFormatoFecha(cboFechaFin.Value)
        Dim sql As String = ""
        Dim selectSql As String = " SELECT E.id,E.fecha ,E.proveedor,T.nombres ,CP.descripcion AS categoria,E.observaciones,(SELECT SUM (valor) from  C_eval_puntaje WHERE id_evaluacion = (SELECT TOP(1)id FROM C_eval_proveedor WHERE id = E.id)) As PUNTOS " & _
                               "FROM C_proveedor_categoria PC, C_eval_proveedor E ,CORSAN.dbo.terceros T,C_eval_puntaje P,C_categorias_proveedores CP "
        Dim whereSql As String = "WHERE PC.categoria = CP.id AND PC.nit = T.nit AND T.nit = E.proveedor And P.id_evaluacion = E.id AND E.fecha >= '" & fecIni & "' AND E.fecha<= '" & fecFin & "' "
        Dim groupSql As String = "GROUP BY E.id,E.proveedor,T.nombres ,E.observaciones,E.fecha,CP.descripcion "
        Dim orderSql As String = "ORDER BY E.fecha "

        If Not (chkTodos.Checked) Then
          If (txtNombres.Text <> "") Then
                whereSql &= "AND T.nombres like '%" & txtNombres.Text & "%'"
            ElseIf (txtNit.Text <> "") Then
                whereSql &= "AND T.nit like '%" & txtNit.Text & "%'"
            ElseIf (cboCategoria.Text <> "Seleccione") Then
                whereSql &= "AND CP.id = " & cboCategoria.SelectedValue
            End If
        End If

        sql = selectSql & whereSql & groupSql & orderSql
        dtgConsulta.DataSource = objIngresoProdLn.listar_datatable(sql, "PRODUCCION")
    End Sub
    Private Sub btn_consultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_consultar.Click
        cargarConsulta()
    End Sub

    Private Sub dtgConsulta_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgConsulta.CellContentClick
        Dim col As String = dtgConsulta.Columns(e.ColumnIndex).Name
        Dim id_evaluacion As Integer = 0
        id_evaluacion = dtgConsulta.Item("id", e.RowIndex).Value
        If (col = col_ver.Name) Then
            Dim frm As New Frm_evaluacion_proveedores
            frm.Show()
            frm.cargarPorConsulta(id_evaluacion)
        ElseIf (col = colBorrar.Name) Then
            Dim resp As Integer = MessageBox.Show("Esta seguro que desea eliminar esta evaluación? ", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If (resp = 6) Then
                Dim listSql As New List(Of Object)
                Dim sql As String
                sql = "DELETE FROM C_eval_puntaje WHERE id_evaluacion =" & id_evaluacion
                listSql.Add(sql)
                sql = "DELETE  C_eval_proveedor WHERE id= " & id_evaluacion
                listSql.Add(sql)
                If (objIngresoProdLn.ExecuteSqlTransaction(listSql, "PRODUCCION")) Then
                    cargarConsulta()
                    MessageBox.Show("El registro se elimino en forma correcta! ", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Error al elimino el registro, verifique que la celda no este en blanco! ", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
           
            End If
        ElseIf (col = colPdf.Name) Then
            cargarReporte(id_evaluacion, e.RowIndex)
        End If
    End Sub
    Private Sub ToolStripSplitButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripSplitButton1.Click
        Frm_graficar_evaluaciones.Show()
        Frm_graficar_evaluaciones.Activate()
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
End Class