Imports logicaNegocios

Public Class Frm_inv_metrologia
    Private objOpSimplesLn As New Op_simpesLn
    Private objIngProdLn As New Ing_prodLn
    Dim colSelect As Integer = 0
    Dim filaSelect As Integer = 0
    Private objOperacionesForm As New OperacionesFormularios
    Dim carga_comp As Boolean = False
    Private Sub Frm_inv_metrologia_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarConsulta()
        carga_comp = True
    End Sub
    Private Sub cargarConsulta()
        dtgMaestro.DataSource = Nothing
        Dim dt As DataTable
        Dim sql As String = "SELECT  i.id,i.centro,z.descripcion As desc_centro,i.tipo As id_tipo , t.descripcion As tipo, i.codigo ,frecuencia, i.ubicacion ,i.ultima_cal,i.siguiente_cal " & _
                                 "FROM j_inv_metrologia i,j_inv_met_tipo t , CORSAN.dbo.centros z " & _
                                    "WHERE i.tipo = t.id  AND i.centro = z.centro"
        dt = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")
        dt.Rows.Add()
        dtgMaestro.DataSource = dt
        dtgMaestro.Columns("ultima_cal").DefaultCellStyle.Format = "d"
        dtgMaestro.Columns("siguiente_cal").DefaultCellStyle.Format = "d"
        For j = 0 To dtgMaestro.Columns.Count - 1
            If dtgMaestro.Columns(j).Name = "id_tipo" Then
                dtgMaestro.Columns(j).Visible = False
            ElseIf (dtgMaestro.Columns(j).Name <> "codigo") Then
                dtgMaestro.Columns(j).ReadOnly = True
            End If

        Next
    End Sub
    Private Sub cargar_dtg_datos(ByVal sql As String, ByVal db As String)
        dtg_datos.DataSource = objOpSimplesLn.listar_datatable(sql, db)
    End Sub
    Private Sub save(ByVal fila As Integer, ByVal id_existente As Integer)
        If validar(fila) Then
            Dim listSql As New List(Of Object)
            Dim operacion As String = ""
            Dim sql As String = ""
            Dim id As Double = 0
            Dim fec_ult_cal As String = objOpSimplesLn.cambiarFormatoFecha(dtgMaestro.Item("ultima_cal", fila).Value)
            Dim fec_sig_cal As String = objOpSimplesLn.cambiarFormatoFecha(dtgMaestro.Item("siguiente_cal", fila).Value)
            Dim centro As Integer = dtgMaestro.Item("centro", fila).Value
            Dim frecuencia As Integer = dtgMaestro.Item("frecuencia", fila).Value
            Dim ubicacion As String = dtgMaestro.Item("ubicacion", fila).Value
            Dim codigo As String = dtgMaestro.Item("codigo", fila).Value
            Dim tipo As String = dtgMaestro.Item("id_tipo", fila).Value
            Dim sql_delete As String = ""
            If id_existente <> 0 Then
                id = objOpSimplesLn.consultValorTodo("SELECT  (SELECT CASE WHEN MAX(id) IS NULL THEN (1) ELSE MAX(id)+1 END) as id FROM j_inv_metrologia", "PRODUCCION")
                sql_delete = "DELETE FROM j_inv_metrologia WHERE id =" & id
            Else
                id = id_existente
            End If
            If sql_delete <> "" Then
                listSql.Add(sql_delete)
            End If
            sql = "INSERT INTO j_inv_metrologia (id,centro,tipo,codigo,frecuencia,ubicacion,ultima_cal,siguiente_cal ) " & _
                                    "VALUES (" & id & "," & centro & "," & tipo & ",'" & codigo & "'," & frecuencia & ",'" & ubicacion & "','" & fec_ult_cal & "','" & fec_sig_cal & "')"
            operacion = "INGRESO"
            listSql.Add(sql)
            If (sql <> "") Then
                If (objOpSimplesLn.ExecuteSqlTransactionTodo(listSql, "PRODUCCION")) Then
                    MessageBox.Show("El registro se " & operacion & " en forma correcta!", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    cargarConsulta()
                Else
                    MessageBox.Show("Error al ingresar el registro,comuniquese con el administrador del sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        End If
    End Sub
    Private Sub delete(ByVal fila As Integer)
        dtgMaestro.CurrentCell = Nothing
        If (IsDBNull(dtgMaestro.Item("id", fila).Value)) Then
            dtgMaestro.Rows(fila).Visible = False
        Else
            Dim id As Integer = dtgMaestro.Item("id", fila).Value
            Dim iResponce = MessageBox.Show("Esta seguro que desea eliminar el  registro? ", "Atención", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
            If (iResponce = 6) Then
                Dim sql As String = "DELETE FROM J_inv_metrologia WHERE id = " & id
                If (objOpSimplesLn.ejecutar(sql, "PRODUCCION") > 0) Then
                    MessageBox.Show("El registro se elimino en forma correcta!", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    cargarConsulta()
                Else
                    MessageBox.Show("Error al eliminar el registro,comuniquese con el administrador del sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
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
        If (Not IsDBNull(dtgMaestro.Item("siguiente_cal", fila).Value) And Not IsDBNull(dtgMaestro.Item("ubicacion", fila).Value) And Not IsDBNull(dtgMaestro.Item("codigo", fila).Value) And Not IsDBNull(dtgMaestro.Item("id_tipo", fila).Value) And Not IsDBNull(dtgMaestro.Item("ultima_cal", fila).Value) And Not IsDBNull(dtgMaestro.Item("centro", fila).Value) And Not IsDBNull(dtgMaestro.Item("frecuencia", fila).Value)) Then

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
        objOperacionesForm.ExportarDatosExcel(dtgMaestro, "Inventarios metrología")
    End Sub
    Private Sub dtg_datos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtg_datos.CellClick
        If e.RowIndex >= 0 Then
            If dtgMaestro.Columns(colSelect).Name = "codigo" Then
                dtgMaestro.Item("id_codigo", filaSelect).Value = dtg_datos.Item("id", e.RowIndex).Value
                dtgMaestro.Item("codigo", filaSelect).Value = dtg_datos.Item("descripcion", e.RowIndex).Value
            ElseIf dtgMaestro.Columns(colSelect).Name = "tipo" Then
                dtgMaestro.Item("id_tipo", filaSelect).Value = dtg_datos.Item("id", e.RowIndex).Value
                dtgMaestro.Item("tipo", filaSelect).Value = dtg_datos.Item("descripcion", e.RowIndex).Value
            ElseIf dtgMaestro.Columns(colSelect).Name = "centro" Then
                dtgMaestro.Item("centro", filaSelect).Value = dtg_datos.Item("centro", e.RowIndex).Value
                dtgMaestro.Item("desc_centro", filaSelect).Value = dtg_datos.Item("descripcion", e.RowIndex).Value
            ElseIf dtgMaestro.Columns(colSelect).Name = "frecuencia" Then
                dtgMaestro.Item("frecuencia", filaSelect).Value = dtg_datos.Item("frecuencia", e.RowIndex).Value
            ElseIf dtgMaestro.Columns(colSelect).Name = "ubicacion" Then
                dtgMaestro.Item("ubicacion", filaSelect).Value = dtg_datos.Item("descripcion", e.RowIndex).Value
            End If
            group_datos.Visible = False
        End If
    End Sub
    Private Sub btn_cerrar_novedades_Click(sender As Object, e As EventArgs) Handles btn_cerrar_novedades.Click
        group_datos.Visible = False
    End Sub

    Private Sub dtgMaestro_MouseDown(sender As Object, e As MouseEventArgs) Handles dtgMaestro.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            If dtgMaestro.Rows.Count > 0 Then
                With (Me.dtgMaestro)
                    Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                    If Hitest.Type = DataGridViewHitTestType.Cell Then
                        .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                    End If
                End With
                filaSelect = dtgMaestro.CurrentCell.RowIndex
                colSelect = dtgMaestro.CurrentCell.ColumnIndex
            End If
        End If
    End Sub

    Private Sub itemMod_Click(sender As Object, e As EventArgs) Handles itemMod.Click
        If (filaSelect >= 0) Then
            Dim sql As String = ""
            Dim numCol As Integer = colSelect
            Dim nombCol As String = dtgMaestro.Columns(numCol).Name
            Dim id As Integer = 0
            If (nombCol = "btnSave" Or nombCol = "btnDelete") Then
                Select Case nombCol
                    Case "btnSave"
                        If validar(filaSelect) Then
                            If Not IsDBNull(dtgMaestro.Item("id", filaSelect).Value) Then
                                id = dtgMaestro.Item("id", filaSelect).Value
                            End If
                            save(filaSelect, id)
                        End If
                    Case "btnDelete"
                        delete(filaSelect)
                End Select
            ElseIf (nombCol = "ultima_cal" Or nombCol = "siguiente_cal") Then
                groupFecha.Visible = True
            ElseIf (nombCol = "centro" Or nombCol = "desc_centro") Then
                group_datos.Visible = True
                sql = "SELECT centro,descripcion FROM centros WHERE centro IN (1100,1200,2100,2200,2300,2400,2500,2600,2800,3100,3200,3500,4100,4200,4300,5200,6200,6400,3300)"
                cargar_dtg_datos(sql, "CORSAN")
            ElseIf (nombCol = "tipo") Then
                group_datos.Visible = True
                sql = "SELECT id,descripcion FROM J_inv_met_tipo "
                cargar_dtg_datos(sql, "PRODUCCION")
            ElseIf (nombCol = "ubicacion") Then
                group_datos.Visible = True
                sql = "SELECT descripcion FROM J_inv_met_ubicacion "
                cargar_dtg_datos(sql, "PRODUCCION")
            ElseIf (nombCol = "frecuencia") Then
                group_datos.Visible = True
                sql = "SELECT frecuencia FROM J_inv_met_frecuencia "
                cargar_dtg_datos(sql, "PRODUCCION")
            End If
        End If
    End Sub

    Private Sub dtgMaestro_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgMaestro.CellClick
        If e.RowIndex >= 0 Then
            filaSelect = e.RowIndex
            colSelect = e.ColumnIndex
            Dim sql As String = ""
            Dim numCol As Integer = colSelect
            Dim nombCol As String = dtgMaestro.Columns(numCol).Name
            Dim id As Integer = 0
            If (nombCol = "btnSave" Or nombCol = "btnDelete") Then
                Select Case nombCol
                    Case "btnSave"
                        If validar(filaSelect) Then
                            If Not IsDBNull(dtgMaestro.Item("id", filaSelect).Value) Then
                                id = dtgMaestro.Item("id", filaSelect).Value
                            End If
                            save(filaSelect, id)
                        End If
                    Case "btnDelete"
                        delete(filaSelect)

                End Select
            End If
        End If
    End Sub
End Class