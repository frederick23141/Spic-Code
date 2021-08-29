Imports logicaNegocios

Public Class FrmInvMetrologia
    Private objOpSimplesLn As New Op_simpesLn
    Private objIngProdLn As New Ing_prodLn
    Dim colSelect As Integer = 0
    Dim filaSelect As Integer = 0
    Private objOperacionesForm As New OperacionesFormularios
    Dim carga_comp As Boolean = False
    Private Sub FrmMaePeriodos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim año = Now.Year + 3
        While (año >= Now.Year - 5)
            cbo_ano_consulta.Items.Add(año)
            cbo_ano_periodo.Items.Add(año)
            año -= 1
        End While
        cbo_ano_consulta.SelectedItem = Now.Year
        cbo_ano_periodo.SelectedItem = Now.Year
        cbo_mes_consulta.SelectedIndex = Now.Month - 1
        cbo_mes_periodo.SelectedIndex = Now.Month - 1
        cargarConsulta()
        carga_comp = True
    End Sub
    Private Sub cargarConsulta()
        dtgMaestro.DataSource = Nothing
        Dim dt As DataTable
        Dim ano As Integer = cbo_ano_consulta.Text
        Dim mes As Integer = cbo_mes_consulta.SelectedIndex + 1
        Dim sql As String = "SELECT n.id,n.id_periodo,'Periodo:' + CAST( (y.periodo  )As varchar ) +' - ' +CAST( YEAR (y.fecha_inicial )As varchar ) + '-' + CAST( MONTH (y.fecha_inicial )As varchar ) + '-' + CAST( DAY (y.fecha_inicial )As varchar ) " & _
                        "+ ' - ' +  CAST( YEAR (y.fecha_final  )As varchar ) + '-' + CAST( MONTH (y.fecha_final )As varchar ) + '-' + CAST( DAY (y.fecha_final )As varchar ) As descripcion_periodo,n.fecha_ini,n.fecha_fin,n.liquidado " & _
                                    " FROM J_periodos_nomina n,y_periodos_control y " & _
                                                "WHERE y.idPeriodo = n.id_periodo AND y.ano =" & ano & " AND y.mes = " & mes
        dt = objOpSimplesLn.crearDataTableVariasCol(sql, "CORSAN")
        dt.Rows.Add()
        dtgMaestro.DataSource = dt
        dtgMaestro.Columns("fecha_ini").DefaultCellStyle.Format = "d"
        dtgMaestro.Columns("fecha_fin").DefaultCellStyle.Format = "d"
    End Sub

    Private Sub FrmMaePeriodos_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgMaestro.CellClick
        If (e.RowIndex >= 0) Then
            colSelect = e.ColumnIndex
            filaSelect = e.RowIndex
            Dim numCol As Integer = e.ColumnIndex
            Dim nombCol As String = dtgMaestro.Columns(numCol).Name
            Dim fila As Integer = e.RowIndex
            If (nombCol = "btnSave" Or nombCol = "btnDelete") Then
                Select Case nombCol
                    Case "btnSave"
                        If validar(e.RowIndex) Then
                            If validar_periodo_existente(dtgMaestro.Item("id_periodo", e.RowIndex).Value) Then
                                save(fila)
                            Else
                                MessageBox.Show("Ya existe una programación para este periodo de nómina", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            End If

                        End If
                    Case "btnDelete"
                        delete(fila)
                End Select
            ElseIf (nombCol = "fecha_ini" Or nombCol = "fecha_fin") Then
                If IsDBNull(dtgMaestro.Item("liquidado", e.RowIndex).Value) Then
                    groupFecha.Visible = True
                Else
                    If ((dtgMaestro.Item("liquidado", e.RowIndex).Value = "N")) Then
                        groupFecha.Visible = True
                    Else
                        MessageBox.Show("Este periodo ya se encuentra liquidado, por lo tanto no se permiten cambios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                End If
            ElseIf (nombCol = "id_periodo") Then
                group_periodos.Visible = True
                cargar_periodos()
            End If

        End If
    End Sub
    Private Sub save(ByVal fila As Integer)
        Dim operacion As String = ""
        Dim sqlExistePeriodo As String = ""
        Dim sqlExisteLiquiadado As String = ""
        Dim sql As String = ""
        Dim id As Double = objOpSimplesLn.consultarVal("SELECT  (SELECT CASE WHEN MAX(id) IS NULL THEN (1) ELSE MAX(id)+1 END) as id FROM J_periodos_nomina")
        Dim fec_ini As String = dtgMaestro.Item("fecha_ini", fila).Value
        Dim fec_fin As String = dtgMaestro.Item("fecha_fin", fila).Value
        Dim id_periodo As Integer = dtgMaestro.Item("id_periodo", fila).Value
        Dim desc_periodo As String = dtgMaestro.Item("descripcion_periodo", fila).Value
        Dim liquidado As String = "N"
        sqlExistePeriodo = "SELECT id FROM J_periodos_nomina  WHERE id_periodo = " & id_periodo
        sqlExisteLiquiadado = "SELECT id FROM J_periodos_nomina  WHERE id_periodo = " & id_periodo & " AND liquidado = 'S' "
        If (objIngProdLn.consultValor(sqlExistePeriodo, "CORSAN") <> "") Then
            If Not (objIngProdLn.consultValor(sqlExisteLiquiadado, "CORSAN") <> "") Then
                Dim iResponce = MessageBox.Show("El  periodo numero = " & desc_periodo & " ya existe y no esta liquidado,desea reemplazarlo? ", "Atención", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                If (iResponce = 6) Then
                    sql = "UPDATE J_periodos_nomina SET fecha_ini ='" & fec_ini & "' ,fecha_fin = '" & fec_fin & "' " & _
                                    "WHERE id_periodo = " & id_periodo
                    operacion = "MODIFICO"
                End If
            Else
                MessageBox.Show("Este periodo ya se encuentra liquidado, por lo tanto no se permiten cambios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Else
            sql = "INSERT INTO J_periodos_nomina (id,fecha_ini,fecha_fin,liquidado,id_periodo) " & _
                                    "VALUES (" & id & ",'" & fec_ini & "','" & fec_fin & "','" & liquidado & "'," & id_periodo & ")"
            operacion = "INGRESO"
        End If
        If (sql <> "") Then
            If (objOpSimplesLn.ejecutar(sql, "CORSAN") > 0) Then
                MessageBox.Show("El registro se " & operacion & " en forma correcta!", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information)
                cargarConsulta()
            Else
                MessageBox.Show("Error al ingresar el registro,comuniquese con el administrador del sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If

    End Sub
    Private Sub delete(ByVal fila As Integer)
        dtgMaestro.CurrentCell = Nothing
        If (IsDBNull(dtgMaestro.Item("id", fila).Value)) Then
            dtgMaestro.Rows(fila).Visible = False
        Else
            Dim id As Integer = dtgMaestro.Item("id", fila).Value
            Dim desc_periodo As String = dtgMaestro.Item("descripcion_periodo", fila).Value
            If ((dtgMaestro.Item("liquidado", fila).Value = "N")) Then
                Dim iResponce = MessageBox.Show("Esta seguro que desea eliminar el  periodo" & desc_periodo & " ? ", "Atención", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                If (iResponce = 6) Then
                    Dim sql As String = "DELETE FROM J_periodos_nomina WHERE id = " & id
                    If (objOpSimplesLn.ejecutar(sql, "CORSAN") > 0) Then
                        MessageBox.Show("El registro se elimino en forma correcta!", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        cargarConsulta()
                    Else
                        MessageBox.Show("Error al eliminar el registro,comuniquese con el administrador del sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If
            Else
                MessageBox.Show("Este periodo ya se encuentra liquidado, por lo tanto no se permiten cambios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If

    End Sub
    Private Sub cboCal_DateSelected(sender As Object, e As DateRangeEventArgs) Handles cboCal.DateSelected
        dtgMaestro.Item(colSelect, filaSelect).Value = objOpSimplesLn.cambiarFormatoFecha(cboCal.SelectionEnd.Date)
        groupFecha.Visible = False
    End Sub
    Private Sub btn_cerrar_Click(sender As Object, e As EventArgs) Handles btn_cerrar.Click
        groupFecha.Visible = False
    End Sub
    Private Function validar(ByVal fila As Integer) As Boolean
        Dim resp As Boolean = True
        Dim dias_dif As Integer = 0
        If (Not IsDBNull(dtgMaestro.Item("fecha_ini", fila).Value) And Not IsDBNull(dtgMaestro.Item("fecha_fin", fila).Value) And Not IsDBNull(dtgMaestro.Item("id_periodo", fila).Value)) Then
            dias_dif = DateDiff(DateInterval.Day, Convert.ToDateTime(dtgMaestro.Item("fecha_ini", fila).Value), Convert.ToDateTime(dtgMaestro.Item("fecha_fin", fila).Value))
            If (dias_dif <= 0) Then
                MessageBox.Show("La fecha final debe ser mayor a la incial", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                resp = False
            ElseIf (dias_dif > 15) Then
                MessageBox.Show("La diferencia entre la fecha inicial y final no puede ser mayor a 15", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                resp = False
            End If
        Else
            MessageBox.Show("Todos los campos son obligatorios", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            resp = False
        End If
        Return resp
    End Function

    Private Sub btn_actualizar_Click(sender As Object, e As EventArgs) Handles btn_actualizar.Click
        cargarConsulta()
    End Sub

    Private Sub btn_excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_excel.Click
        objOperacionesForm.ExportarDatosExcel(dtgMaestro, "Relacion fecha-pedido-facturación y entrega")
    End Sub


    Private Sub cbo_ano_periodo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbo_ano_periodo.SelectedIndexChanged
        If carga_comp Then
            cargar_periodos()
        End If
    End Sub

    Private Sub cbo_mes_periodo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbo_mes_periodo.SelectedIndexChanged
        If carga_comp Then
            cargar_periodos()
        End If
    End Sub
    Private Sub cargar_periodos()
        Dim sql As String = "SELECT  idPeriodo ,'Periodo:' + CAST( (periodo  )As varchar ) +' - ' +CAST( YEAR (fecha_inicial )As varchar ) + '-' + CAST( MONTH (fecha_inicial )As varchar ) + '-' + CAST( DAY (fecha_inicial )As varchar ) " & _
                        "+ ' - ' +  CAST( YEAR (fecha_final  )As varchar ) + '-' + CAST( MONTH (fecha_final )As varchar ) + '-' + CAST( DAY (fecha_final )As varchar ) As descripcion " & _
                        "FROM y_periodos_control " & _
                            "WHERE ano = " & cbo_ano_periodo.Text & " And mes = " & cbo_mes_periodo.SelectedIndex + 1 & " "
        dtg_periodos.DataSource = objOpSimplesLn.listar_datatable(sql, "CORSAN")

    End Sub

    Private Sub dtg_periodos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtg_periodos.CellClick
        If e.RowIndex >= 0 Then
            dtgMaestro.Item(colSelect, filaSelect).Value = dtg_periodos.Item("idPEriodo", e.RowIndex).Value
            dtgMaestro.Item("descripcion_periodo", filaSelect).Value = dtg_periodos.Item("descripcion", e.RowIndex).Value
            group_periodos.Visible = False
        End If
    End Sub


    Private Sub btn_cerrar_novedades_Click(sender As Object, e As EventArgs) Handles btn_cerrar_novedades.Click
        group_periodos.Visible = False
    End Sub
    Private Function validar_periodo_existente(ByVal id_periodo As Integer) As Boolean
        Dim sql As String = "SELECT id_periodo FROM J_periodos_nomina WHERE id_periodo =" & id_periodo
        If (objOpSimplesLn.consultarVal(sql) <> "") Then
            Return False
        Else
            Return True
        End If

    End Function
End Class