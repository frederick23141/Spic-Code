Imports logicaNegocios

Public Class FrmIngTornilleria
    Private objIngProdLn As New Ing_prodLn
    Private objOpSimplesLn As New Op_simpesLn
    Private carga_comp As Boolean = False
    Dim vel As String = ""
    Dim mill_esp As String = ""
    Dim totParos As Integer = 0
    Dim colSelect As Integer = 0
    Dim id_existente As Integer = 0
    Private Sub FrmIngTornilleria_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cbo_fecha.Value = Now.AddDays(-1)
        cargar_paros()
        cargar_cbo()

        dtgConsRef.DataSource = objOpSimplesLn.listar_datatable("SELECT codigo,descripcion FROM referencias WHERE codigo like '%2t%' ORDER BY descripcion", "CORSAN")
        dtgConsRef.Columns("codigo").Visible = False
        For i = 0 To 4
            dtgReferencias.Rows.Add()
        Next
        carga_comp = True
    End Sub
    Private Sub cargar_cbo()
        Dim sql As String
        Dim dt As New DataTable
        Dim dr As DataRow

        sql = "select nit,nombres  from V_nom_personal_Activo_con_maquila WHERE centro = 2500 ORDER BY nombres"
        dt = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        dr = dt.NewRow
        dr("nit") = 0
        dr("nombres") = "Seleccione"
        dt.Rows.Add(dr)
        cbo_operario.DataSource = dt
        cbo_operario.ValueMember = "nit"
        cbo_operario.DisplayMember = "nombres"
        cbo_operario.Text = "Seleccione"

        dt = New DataTable
        sql = "SELECT Codigo,Descripcion  FROM J_turnos "
        dt = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")
        dr = dt.NewRow
        dr("Codigo") = 0
        dr("Descripcion") = "Seleccione"
        dt.Rows.Add(dr)
        cbo_turno.DataSource = dt
        cbo_turno.ValueMember = "Codigo"
        cbo_turno.DisplayMember = "Descripcion"
        cbo_turno.Text = "Seleccione"

        dt = New DataTable
        sql = "SELECT id,descripcion FROM J_secciones WHERE id >= 10 AND id <= 13 ORDER BY descripcion"
        dt = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")
        dr = dt.NewRow
        dr("id") = 0
        dr("descripcion") = "Seleccione"
        dt.Rows.Add(dr)
        cboSeccion.DataSource = dt
        cboSeccion.ValueMember = "id"
        cboSeccion.DisplayMember = "descripcion"
        cboSeccion.Text = "Seleccione"

        dt = New DataTable
        sql = "SELECT CodigoM,Nombre FROM J_Maquinas WHERE tipoMaquina = 11 ORDER BY Nombre"
        dt = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")
        dr = dt.NewRow
        dr("CodigoM") = 0
        dr("Nombre") = "Seleccione"
        dt.Rows.Add(dr)
        cboMaquina.DataSource = dt
        cboMaquina.ValueMember = "CodigoM"
        cboMaquina.DisplayMember = "Nombre"
        cboMaquina.Text = "Seleccione"
    End Sub
    Private Sub cargar_paros()
        For i = 0 To 9
            dtgParos.Rows.Add()
        Next
        dtgParos.Item(col_num_0_9.Name, 0).Value = 1
        dtgParos.Item(col_num_0_9.Name, 1).Value = 2
        dtgParos.Item(col_num_0_9.Name, 2).Value = 3
        dtgParos.Item(col_num_0_9.Name, 3).Value = 4
        dtgParos.Item(col_num_0_9.Name, 4).Value = 5
        dtgParos.Item(col_num_0_9.Name, 5).Value = 6
        dtgParos.Item(col_num_0_9.Name, 6).Value = 7
        dtgParos.Item(col_num_0_9.Name, 7).Value = 8
        dtgParos.Item(col_num_0_9.Name, 8).Value = 9
        dtgParos.Item(col_num_0_9.Name, 9).Value = 10

        dtgParos.Item(col_desc_0_9.Name, 0).Value = "Mantenimiento programado"
        dtgParos.Item(col_desc_0_9.Name, 1).Value = "Falta de enregia"
        dtgParos.Item(col_desc_0_9.Name, 2).Value = "Daño Electrico"
        dtgParos.Item(col_desc_0_9.Name, 3).Value = "Daño Mecanico"
        dtgParos.Item(col_desc_0_9.Name, 4).Value = "Falta de M.P"
        dtgParos.Item(col_desc_0_9.Name, 5).Value = "Falta de Operario"
        dtgParos.Item(col_desc_0_9.Name, 6).Value = "Reunión/capacitación"
        dtgParos.Item(col_desc_0_9.Name, 7).Value = "Comida"
        dtgParos.Item(col_desc_0_9.Name, 8).Value = "Daño sistema lubricación"
        dtgParos.Item(col_desc_0_9.Name, 9).Value = "Montaje"

        dtgParos.Item(col_num_10_20.Name, 0).Value = 11
        dtgParos.Item(col_num_10_20.Name, 1).Value = 12
        dtgParos.Item(col_num_10_20.Name, 2).Value = 13
        dtgParos.Item(col_num_10_20.Name, 3).Value = 14
        dtgParos.Item(col_num_10_20.Name, 4).Value = 15
        dtgParos.Item(col_num_10_20.Name, 5).Value = 16
        dtgParos.Item(col_num_10_20.Name, 6).Value = 17
        dtgParos.Item(col_num_10_20.Name, 7).Value = 18
        dtgParos.Item(col_num_10_20.Name, 8).Value = 19
        dtgParos.Item(col_num_10_20.Name, 9).Value = 20

        dtgParos.Item(col_desc_10_20.Name, 0).Value = "Ajuste maquina"
        dtgParos.Item(col_desc_10_20.Name, 1).Value = "Cambio de referncia"
        dtgParos.Item(col_desc_10_20.Name, 2).Value = "Ajuste alimentación"
        dtgParos.Item(col_desc_10_20.Name, 3).Value = "Falta de hta"
        dtgParos.Item(col_desc_10_20.Name, 4).Value = "Selección de mateia prima"
        dtgParos.Item(col_desc_10_20.Name, 5).Value = "Asistencia a otra maquina"
        dtgParos.Item(col_desc_10_20.Name, 6).Value = "Otros"



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

    Private Sub txtProd_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        soloNumero(e)
    End Sub


    Private Sub cargar_resumen()
        sumarProd()
        Dim horas As Integer = 0
        Dim t_sinJust As Double = 0
        If (txtHoras.Text <> "") Then
            horas = txtHoras.Text
        End If

        txtResperada.Text = mill_esp
        If txtResperada.Text = "" Then
            txtResperada.Text = "64"
        End If

        If (txtRproducido.Text <> "" And txtResperada.Text <> "") Then
            txtRconfiab.Text = (txtRproducido.Text / txtResperada.Text).ToString("##.#%")
        End If
        If (txtHoras.Text <> "") Then
            'txtRnivFallos.Text = (totParos / ((txtHoras.Text * 60) - (20))).ToString("##.#%")
            txtRnivFallos.Text = (((txtHoras.Text * 60) - totParos) / (txtHoras.Text * 60)).ToString("##.#%")
            If (txtRproducido.Text <> "") Then
                t_sinJust = ((((horas) * 60) - totParos - ((txtRproducido.Text * 1000) / vel))) / 60
                txtRtSinJust.Text = t_sinJust.ToString("N2")
            End If
            If (txtRtSinJust.Text <> "") Then
                txtRutil.Text = (1 - ((totParos / 60 + txtRtSinJust.Text) / horas)).ToString("##.#%")
            End If
        End If
    End Sub
    Private Sub sumarProd()
        Dim sum As Integer = 0
        For i = 0 To dtgReferencias.RowCount - 1
            If (dtgReferencias.Item(colMillares.Name, i).Value <> "") Then
                sum += dtgReferencias.Item(colMillares.Name, i).Value
            End If
        Next
        If (sum > 0) Then
            txtRproducido.Text = sum
        End If
    End Sub
    Private Sub cbo_turno_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_turno.SelectedIndexChanged
        If (carga_comp) Then
            txtHoras.Text = objIngProdLn.consultValor("SELECT horas FROM J_turnos WHERE Codigo = " & cbo_turno.SelectedValue, "PRODUCCION")
            cargar_resumen()
        End If
    End Sub
    Private Sub totalParos()
        Dim total As Integer = 0
        For i = 0 To dtgParos.RowCount - 1
            If (dtgParos.Item(col_val_0_9.Name, i).Value <> "") Then
                total += dtgParos.Item(col_val_0_9.Name, i).Value
            End If
            If (dtgParos.Item(col_val_10_20.Name, i).Value <> "") Then
                total += dtgParos.Item(col_val_10_20.Name, i).Value
            End If
        Next
        totParos = total
        txtTotParos.Text = total
    End Sub

    Private Sub cboMaquina_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMaquina.SelectedIndexChanged
        If (carga_comp) Then
            vel = objIngProdLn.consultValor("SELECT vel_actual FROM j_maquinas WHERE CodigoM = " & cboMaquina.SelectedValue, "PRODUCCION")
            mill_esp = objIngProdLn.consultValor("SELECT ProdActual FROM j_maquinas WHERE CodigoM = " & cboMaquina.SelectedValue, "PRODUCCION")
            cargar_resumen()
        End If
    End Sub

    Private Sub dtgParos_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgParos.CellValueChanged
        If (carga_comp) Then
            totalParos()
            cargar_resumen()
        End If
    End Sub
    Private Sub guardar()
        If (validar()) Then
            Dim turno As Integer = cbo_turno.SelectedValue
            Dim insertoCorrecto As Boolean = False
            Dim listSql As New List(Of Object)
            Dim id As String = objIngProdLn.consultValor("SELECT MAX (id)+1 FROM J_prod_tornilleria_enc", "PRODUCCION")
            Dim operario As String = cbo_operario.SelectedValue
            Dim fecha As String = objOpSimplesLn.cambiarFormatoFecha(cbo_fecha.Value)
            Dim seccion As String = cboSeccion.SelectedValue
            Dim maquina As String = cboMaquina.SelectedValue
            If (id = "") Then
                id = 1
            End If
            Dim sql As String = "INSERT INTO J_prod_tornilleria_enc (id,operario,fecha,seccion,maquina,turno) " & _
                                    "VALUES (" & id & "," & operario & ",'" & fecha & "'," & seccion & "," & maquina & "," & turno & ")"
            listSql.Add(sql)
            listSql.AddRange(sqlParos(id))
            listSql.AddRange(sqlDet(id))
            insertoCorrecto = objIngProdLn.ExecuteSqlTransaction(listSql, "PRODUCCION")
            If (insertoCorrecto) Then
                MessageBox.Show("La produccion de  guardado en forma correcta", "Correcto!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'nuevo()
            Else
                MessageBox.Show("Error al guardar la produccion comuniquese con el administrador del sistema ", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub
    Private Sub modificar()
        If (validar()) Then
            Dim turno As Integer = cbo_turno.SelectedValue
            Dim insertoCorrecto As Boolean = False
            Dim listSql As New List(Of Object)
            Dim operario As String = cbo_operario.SelectedValue
            Dim fecha As String = objOpSimplesLn.cambiarFormatoFecha(cbo_fecha.Value)
            Dim seccion As String = cboSeccion.SelectedValue
            Dim maquina As String = cboMaquina.SelectedValue
            Dim sql As String = "UPDATE J_prod_tornilleria_enc SET turno = " & turno & ", operario = " & operario & ",fecha = '" & fecha & "',seccion = " & seccion & ",maquina = " & maquina & " " & _
                                    "WHERE id= " & id_existente
            listSql.Add(sql)
            listSql.AddRange(sqlParosmodificar(id_existente))
            listSql.AddRange(sqlDetModificar(id_existente))
            insertoCorrecto = objIngProdLn.ExecuteSqlTransaction(listSql, "PRODUCCION")
            If (insertoCorrecto) Then
                MessageBox.Show("La produccion de  guardado en forma correcta", "Correcto!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                nuevo()
            Else
                MessageBox.Show("Error al guardar la produccion comuniquese con el administrador del sistema ", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub
    Private Function sqlDet(ByVal id As Integer) As List(Of Object)
        Dim sql As String = ""
        Dim listSql As New List(Of Object)
        For i = 0 To dtgReferencias.RowCount - 1
            If (dtgReferencias.Item(colNombRef.Name, i).Value <> "") Then
                If (dtgReferencias.Item(colNombRef.Name, i).Value <> "" And dtgReferencias.Item(colMillares.Name, i).Value <> "") Then
                    sql = "INSERT INTO  J_prod_tornilleria_det (id_prod_tornilleria,id_ref,kilos) VALUES " &
                                    "(" & id & ",'" & dtgReferencias.Item(colIdRef.Name, i).Value & "'," & dtgReferencias.Item(colMillares.Name, i).Value & ")"
                    listSql.Add(sql)
                End If
            End If
        Next
        Return listSql
    End Function
    Private Function sqlDetModificar(ByVal id As Integer) As List(Of Object)
        Dim sql As String = ""
        Dim listSql As New List(Of Object)
        For i = 0 To dtgReferencias.RowCount - 1
            If (dtgReferencias.Item(colNombRef.Name, i).Value <> "") Then
                If (dtgReferencias.Item(colNombRef.Name, i).Value <> "" And dtgReferencias.Item(colMillares.Name, i).Value <> "") Then
                    sql = "UPDATE J_prod_tornilleria_det SET kilos =  " & dtgReferencias.Item(colMillares.Name, i).Value & _
                                    "WHERE id_prod_tornilleria = " & id & " AND id_ref = " & dtgReferencias.Item(colIdRef.Name, i).Value
                    listSql.Add(sql)
                End If
            End If
        Next
        Return listSql
    End Function
    Private Function sqlParosmodificar(ByVal id As Integer) As List(Of Object)
        Dim sqlPlantilla As String = ""
        Dim sql As String = ""
        Dim listSql As New List(Of Object)
        For i = 0 To dtgParos.RowCount - 1
            If (dtgParos.Item(col_val_0_9.Name, i).Value <> "") Then
                sql = "UPDATE J_paros_tornilleria SET tiempo =  " & dtgParos.Item(col_val_0_9.Name, i).Value & " " & _
                                            "WHERE id_planilla = " & id & " AND id_paro = " & dtgParos.Item(col_num_0_9.Name, i).Value
                listSql.Add(sql)
            End If
            If (dtgParos.Item(col_val_10_20.Name, i).Value <> "") Then
                sql = "UPDATE J_paros_tornilleria SET tiempo =  " & dtgParos.Item(col_val_10_20.Name, i).Value & " " & _
                                           "WHERE id_planilla = " & id & " AND id_paro = " & dtgParos.Item(col_num_10_20.Name, i).Value
                listSql.Add(sql)
            End If
        Next
        Return listSql
    End Function
    Private Function sqlParos(ByVal id As Integer) As List(Of Object)
        Dim sqlPlantilla As String = "INSERT INTO J_paros_tornilleria (id_planilla,id_paro,tiempo) " & _
                                            "VALUES(" & id & ","
        Dim sql As String = ""
        Dim listSql As New List(Of Object)
        For i = 0 To dtgParos.RowCount - 1
            If (dtgParos.Item(col_val_0_9.Name, i).Value <> "") Then
                sql = sqlPlantilla & dtgParos.Item(col_num_0_9.Name, i).Value & "," & dtgParos.Item(col_val_0_9.Name, i).Value & " )"
                listSql.Add(sql)
            End If
            If (dtgParos.Item(col_val_10_20.Name, i).Value <> "") Then
                sql = sqlPlantilla & dtgParos.Item(col_num_10_20.Name, i).Value & "," & dtgParos.Item(col_val_10_20.Name, i).Value & " )"
                listSql.Add(sql)
            End If
        Next
        Return listSql
    End Function
    Private Function validar() As Boolean
        If (cbo_operario.Text <> "Seleccione") Then
            If (cboMaquina.Text <> "Seleccione") Then
                If (cbo_turno.Text <> "Seleccione") Then
                    If (cboSeccion.Text <> "Seleccione") Then
                        If (dtgReferencias.RowCount >= 0) Then
                            If (validarDtgRef()) Then
                                Return True
                            End If
                        Else
                            MessageBox.Show("Se debe ingresar por lo menos una referencia!", "Verifique!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    Else
                        MessageBox.Show("El campo sección es obligatorio", "Verifique!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Else
                    MessageBox.Show("El campo turno es obligatorio", "Verifique!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                MessageBox.Show("El campo maquina es obligatorio", "Verifique!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            MessageBox.Show("El campo operario es obligatorio", "Verifique!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        Return False
    End Function
    Private Function validarDtgRef() As Boolean
        For i = 0 To dtgReferencias.RowCount - 1
            If (dtgReferencias.Item(colNombRef.Name, i).Value <> "" Or dtgReferencias.Item(colMillares.Name, i).Value <> "") Then
                If (dtgReferencias.Item(colNombRef.Name, i).Value = "" Or dtgReferencias.Item(colMillares.Name, i).Value = "") Then
                    MessageBox.Show("Verifique que todas las referencias tengan sus respectivos millares!", "Verifique!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                End If
            End If
        Next
        Return True
    End Function

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        dtgParos.CurrentCell = Nothing
        dtgReferencias.CurrentCell = Nothing
        If (id_existente = 0) Then
            guardar()
        Else
            modificar()
        End If
    End Sub
    Private Sub nuevo()
        carga_comp = False
        cbo_operario.SelectedValue = 0
        cboMaquina.SelectedValue = 0
        cbo_turno.SelectedValue = 0
        cboSeccion.SelectedValue = 0
        dtgReferencias.Rows.Clear()
        For i = 0 To 4
            dtgReferencias.Rows.Add()
        Next
        carga_comp = True
        txtRconfiab.Text = ""
        txtRnivFallos.Text = ""
        txtRproducido.Text = ""
        txtRtSinJust.Text = ""
        txtRutil.Text = ""
        txtHoras.Text = ""
        txtTotParos.Text = ""
        limpiarParos()
    End Sub
    Private Sub limpiarParos()
        carga_comp = False
        For i = 0 To dtgParos.RowCount - 1
            dtgParos.Item(col_val_0_9.Name, i).Value = ""
            dtgParos.Item(col_val_10_20.Name, i).Value = ""
        Next
        carga_comp = True
    End Sub
    Private Sub dtgConsRef_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgConsRef.CellClick
        If (e.RowIndex >= 0) Then
            'If Not (existeReferencia(dtgConsRef.Item("codigo", e.RowIndex).Value)) Then
            dtgReferencias.Item(colNombRef.Name, colSelect).Value = dtgConsRef.Item("descripcion", e.RowIndex).Value
            dtgReferencias.Item(colIdRef.Name, colSelect).Value = dtgConsRef.Item("codigo", e.RowIndex).Value
            GroupRef.Visible = False
            dtgReferencias.Enabled = True
            'Else
            '    MessageBox.Show("Esta referencia ya se encuentra en la lista!", "Verifique!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'End If

        End If

    End Sub
    Private Function existeReferencia(ByVal id_ref As Integer)
        For i = 0 To dtgReferencias.RowCount - 1
            If (dtgReferencias.Item(colIdRef.Name, i).Value = id_ref) Then
                Return True
            End If
        Next
        Return False
    End Function
    Private Sub dtgReferencias_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgReferencias.CellClick
        Dim col As String = dtgReferencias.Columns(e.ColumnIndex).Name
        If (col = colNombRef.Name) Then
            GroupRef.Visible = True
            dtgReferencias.Enabled = False
            colSelect = e.RowIndex
        ElseIf (col = colBorrar.Name) Then
            dtgReferencias.Rows.RemoveAt(e.RowIndex)
            cargar_resumen()
            dtgReferencias.Rows.add
        End If

    End Sub

    Private Sub dtgReferencias_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgReferencias.CellValueChanged
        If (carga_comp) Then
            Dim col As String = dtgReferencias.Columns(e.ColumnIndex).Name
            If (col = colMillares.Name) Then
                If IsNumeric(dtgReferencias.Item(colMillares.Name, e.RowIndex).Value) Then
                    cargar_resumen()
                Else
                    carga_comp = False
                    MessageBox.Show("El valor ingresado en millares debe ser númerico", "Verifique!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    dtgReferencias.Item(colMillares.Name, e.RowIndex).Value = ""
                    carga_comp = True
                End If
            End If
        End If

    End Sub

    Private Sub btnCerrarEditResp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrarEditResp.Click
        GroupRef.Visible = False
        dtgReferencias.Enabled = True
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        nuevo()
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Dim frm As New Frm_consulta_tornilleria
        frm.Show()
        frm.Activate()
    End Sub
    Public Sub cargar_por_id(ByVal id As String)
        dtgReferencias.Rows.Clear()
        id_existente = id
        Dim sql_enc As String = "SELECT operario,fecha,seccion,maquina,turno FROM J_prod_tornilleria_enc WHERE id = " & id
        Dim sql_det As String = "SELECT D.id_ref,D.kilos,R.descripcion AS desc_ref  FROM J_prod_tornilleria_det D,CORSAN.dbo.referencias R WHERE   R.codigo = D.id_ref  AND  D.id_prod_tornilleria = " & id
        Dim sql_paros As String = "SELECT id_paro,tiempo FROM J_paros_tornilleria WHERE id_planilla  = " & id
        Dim dt As New DataTable
        dt = objIngProdLn.listar_datatable(sql_enc, "PRODUCCION")
        For i = 0 To dt.Rows.Count - 1
            cbo_operario.SelectedValue = dt.Rows(i).Item("operario")
            cboMaquina.SelectedValue = dt.Rows(i).Item("maquina")
            cboSeccion.SelectedValue = dt.Rows(i).Item("seccion")
            cbo_turno.SelectedValue = dt.Rows(i).Item("turno")
            cbo_fecha.Value = dt.Rows(i).Item("fecha")
        Next
        dt = New DataTable
        dt = objIngProdLn.listar_datatable(sql_det, "PRODUCCION")
        For i = 0 To dt.Rows.Count - 1
            dtgReferencias.Rows.Add()
            dtgReferencias.Item(colIdRef.Name, i).Value = dt.Rows(i).Item("id_ref")
            dtgReferencias.Item(colMillares.Name, i).Value = dt.Rows(i).Item("kilos").ToString
            dtgReferencias.Item(colNombRef.Name, i).Value = dt.Rows(i).Item("desc_ref")
        Next
        dt = New DataTable
        dt = objIngProdLn.listar_datatable(sql_paros, "PRODUCCION")
        For i = 0 To dt.Rows.Count - 1
            For j = 0 To dtgParos.RowCount - 1
                If (dtgParos.Item(col_num_0_9.Name, j).Value = dt.Rows(i).Item("id_paro")) Then
                    dtgParos.Item(col_val_10_20.Name, j).Value = dt.Rows(i).Item("tiempo").ToString
                    j = dtgParos.RowCount - 1
                ElseIf (dtgParos.Item(col_num_10_20.Name, j).Value = dt.Rows(i).Item("id_paro")) Then
                    dtgParos.Item(col_val_10_20.Name, j).Value = dt.Rows(i).Item("tiempo").ToString
                    j = dtgParos.RowCount - 1
                End If
            Next
            
        Next
    End Sub

    Private Sub chk_todos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_todos.CheckedChanged
        Dim sql As String
        Dim dt As New DataTable
        Dim dr As DataRow
        If (chk_todos.Checked) Then
            sql = "Select nit,nombres   from V_nom_personal_Activo_con_maquila WHERE centro not in (4200) ORDER BY nombres"
        Else
            sql = "select nit,nombres  from V_nom_personal_Activo_con_maquila WHERE centro = 2500 ORDER BY nombres"
        End If
        dt = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        dr = dt.NewRow
        dr("nit") = 0
        dr("nombres") = "Seleccione"
        dt.Rows.Add(dr)
        cbo_operario.DataSource = dt
        cbo_operario.ValueMember = "nit"
        cbo_operario.DisplayMember = "nombres"
        cbo_operario.Text = "Seleccione"
    End Sub


End Class