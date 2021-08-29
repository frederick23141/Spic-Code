Imports logicaNegocios
Imports entidadNegocios
Public Class Frm_gestionar_procedimientos
    Private objEnvCorreoLN As New EnvCorreoLN
    Private carga_comp As Boolean = False
    Private objOpSimplesLn As New Op_simpesLn
    Dim objIngresoProdLn As New Ing_prodLn
    Dim colSelect As Integer = 0
    Dim id_existente As Integer = 0
    Dim nomb_modulo As String
    Dim permiso As String
    Dim usuario As New UsuarioEn
    Private Sub Frm_crear_procedimiento_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_cbo()
        For i = 0 To 5
            dtgPasos.Rows.Add()
            dtgPasos.Item(colId.Name, i).Value = i
        Next
        carga_comp = True
    End Sub
    Public Sub Main(ByVal usuario As UsuarioEn, ByVal id_existente As Integer, ByVal nomb_modulo As String)
        permiso = usuario.permiso.Trim
        Me.nomb_modulo = nomb_modulo
        If (permiso.Trim = "ADMIN" Or permiso = "SALUD_OCUPACIONAL") Then
            colSolCambio.Visible = False
        Else
            cboFechaCreacion.Enabled = False
            cboFechaMod.Enabled = False
            txtObjetivo.ReadOnly = True
            colAdd.Visible = False
            colDelete.Visible = False
            colSave.Visible = False
            colAdd.Visible = False
            btnGuardar.Visible = False
            btnNuevo.Visible = False
            txtNombProc.ReadOnly = True
            txtCod.ReadOnly = True
            txtVersion.ReadOnly = True
            cboAprueba.Enabled = False
            cboElabora.Enabled = False
            cboRevisa.Enabled = False
            dtgPasos.ReadOnly = True
        End If
        Me.usuario = usuario
        Me.id_existente = id_existente
        carga_comp = True
    End Sub
    Private Sub cargar_cbo()
        Dim sql As String
        Dim dt As New DataTable
        Dim dr As DataRow

        sql = "SELECT id,descripcion FROM C_cargos_corsan ORDER BY descripcion"
        dt = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")
        dr = dt.NewRow
        dr("id") = 0
        dr("descripcion") = "Seleccione"
        dt.Rows.Add(dr)
        cboElabora.DataSource = dt
        cboElabora.ValueMember = "id"
        cboElabora.DisplayMember = "descripcion"
        cboElabora.Text = "Seleccione"

        dt = New DataTable
        sql = "SELECT id,descripcion FROM C_cargos_corsan ORDER BY descripcion"
        dt = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")
        dr = dt.NewRow
        dr("id") = 0
        dr("descripcion") = "Seleccione"
        dt.Rows.Add(dr)
        cboRevisa.DataSource = dt
        cboRevisa.ValueMember = "id"
        cboRevisa.DisplayMember = "descripcion"
        cboRevisa.Text = "Seleccione"

        dt = New DataTable
        sql = "SELECT id,descripcion FROM C_cargos_corsan ORDER BY descripcion"
        dt = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")
        dr = dt.NewRow
        dr("id") = 0
        dr("descripcion") = "Seleccione"
        dt.Rows.Add(dr)
        cboAprueba.DataSource = dt
        cboAprueba.ValueMember = "id"
        cboAprueba.DisplayMember = "descripcion"
        cboAprueba.Text = "Seleccione"
    End Sub
    Private Sub btnCerrarResp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrarResp.Click
        GroupBuscResp.Visible = False
        dtgPasos.Enabled = True
    End Sub
    Private Sub dtgConsultResp_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgConsultResp.CellClick
        Dim col As String = dtgConsultResp.Columns(e.ColumnIndex).Name
        If (col = colNitOk.Name And e.RowIndex >= 0) Then
            If Not (existeResponsableEnPaso(dtgConsultResp.Item("id", e.RowIndex).Value)) Then
                carga_comp = False
                dtgPasos.Item(colNitResponsable.Name, colSelect).Value &= dtgConsultResp.Item("id", e.RowIndex).Value & "-"
                dtgPasos.Item(colNombResponsable.Name, colSelect).Value &= dtgConsultResp.Item("descripcion", e.RowIndex).Value & " -"
            Else
                MessageBox.Show("Ya existe este responsable en el paso del procedimiento ", "Verifique!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            GroupBuscResp.Visible = False
            dtgPasos.Enabled = True
            dtgConsultResp.DataSource = Nothing
            txtBuscNomb.Text = ""
            carga_comp = True
        End If
    End Sub
    Private Function existeResponsableEnPaso(ByVal valor As String) As Boolean
        Dim cadena As String = ""
        If IsNothing(dtgPasos.Item(colNitResponsable.Name, colSelect).Value) Then
            cadena = ""
        Else
            cadena = dtgPasos.Item(colNitResponsable.Name, colSelect).Value
        End If
        Dim nit As String = ""
        For i = 0 To cadena.Length - 1
            If (cadena(i) <> "") Then
                If (cadena(i) = "-") Then
                    If (nit.Trim = valor) Then
                        Return True
                    End If
                    nit = ""
                Else
                    nit &= cadena(i)
                End If
            End If
        Next
        Return False
    End Function
    Private Sub dtgPasos_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgPasos.CellClick
        Dim col As String = dtgPasos.Columns(e.ColumnIndex).Name
        If (permiso.Trim = "ADMIN" Or permiso = "SALUD_OCUPACIONAL") Then
            If (col = colNombResponsable.Name) Then
                GroupBuscResp.Visible = True
                dtgPasos.Enabled = False
                txtBuscNomb.Focus()
                colSelect = e.RowIndex
                cargar_busc_responsable()
            ElseIf (col = colAdd.Name) Then
                dtgPasos.Rows.Add()
                dtgPasos.Item(colId.Name, dtgPasos.RowCount - 1).Value = dtgPasos.Item(colId.Name, dtgPasos.RowCount - 2).Value + 1
            ElseIf (col = colDelete.Name) Then
                Dim resp As Integer = MessageBox.Show("Seguro que desea eliminar el registro? ", "Eliminar?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If (resp = 6) Then
                    If (id_existente <> 0) Then
                        Dim id_detalle As Integer = dtgPasos.Item(colId.Name, e.RowIndex).Value
                        If (existePaso(id_existente, id_detalle)) Then
                            If (dtgPasos.Item(colNombResponsable.Name, e.RowIndex).Value <> "") Then

                                Dim sql As String = "DELETE FROM C_procedimientos_lin WHERE id_proc = " & id_existente & " AND id_subproc =" & id_detalle
                                If (objOpSimplesLn.ejecutar(sql, "PRODUCCION") <= 0) Then
                                    MessageBox.Show("Error al eliminar el registro comuniquese con el administrador del sistema ", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                End If
                            End If
                        Else
                            dtgPasos.Rows.RemoveAt(e.RowIndex)
                        End If
                    End If
                    dtgPasos.Rows.RemoveAt(e.RowIndex)
                End If
            ElseIf (col = colSave.Name) Then
                If (id_existente <> 0) Then
                    If (dtgPasos.Item(colNombResponsable.Name, e.RowIndex).Value.ToString <> "" And dtgPasos.Item(colActividad.Name, e.RowIndex).Value.ToString <> "") Then
                        modificarPaso(e.RowIndex)
                    Else
                        MessageBox.Show("Verifique que todos los campos esten diligenciados para guardar", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                End If
            End If
        End If
        If (col = colSolCambio.Name) Then
            groupSolCambio.Visible = True
            dtgPasos.Enabled = False
            txtDescCambio.Focus()
            colSelect = e.RowIndex
        End If
    End Sub
    Private Sub modificarPaso(ByVal fila As Integer)
        Dim insertoCorrecto As Boolean = False
        Dim id_detalle As Integer = dtgPasos.Item(colId.Name, fila).Value
        Dim sql As String = ""
        Dim listSql As New List(Of Object)
        Dim argumento As String = InputBox("ingrese motivo de la mofidicación del procedimiento")
        If (argumento <> "") Then
            Dim actividad As String = dtgPasos.Item(colActividad.Name, fila).Value
            Dim responsable As String = dtgPasos.Item(colNitResponsable.Name, fila).Value
            sql = "DELETE FROM C_resp_paso_procedimiento WHERE  id_proc =" & id_existente & " AND id_subproc  =" & id_detalle
            listSql.Add(sql)
            sql = "UPDATE C_procedimientos SET fecha_modificacion = GETDATE () , quien_modif ='" & usuario.usuario & "',notas_modif = '" & argumento & "' WHERE id_proc =" & id_existente
            sql = "UPDATE C_procedimientos_lin SET descripcion ='" & dtgPasos.Item(colActividad.Name, fila).Value & "'  WHERE id_proc =" & id_existente & " AND id_subproc =" & id_detalle
            listSql.Add(sql)
            listSql.Add(sql)
            listSql.AddRange(listarSqlResponsables(dtgPasos.Item(colNitResponsable.Name, fila).Value, dtgPasos.Item(colId.Name, fila).Value, id_existente))
            insertoCorrecto = objIngresoProdLn.ExecuteSqlTransaction(listSql, "PRODUCCION")
            If (insertoCorrecto) Then
                MessageBox.Show("El procedimiento fue guardado en forma correcta", "Correcto!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Error al guardar el procedimiento comuniquese con el administrador del sistema ", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Else
            MessageBox.Show("Se debe ingresar un motivo para la modificación del procedimiento", "Correcto!", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub
    Private Function existePaso(ByVal id_procedimiento As Integer, ByVal id_paso As Integer) As Boolean
        If (objIngresoProdLn.consultValor("SELECT id_subproc FROM C_procedimientos_lin WHERE id_proc = " & id_procedimiento & " AND id_subproc =" & id_paso, "PRODUCCION") = "") Then
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub txtBuscNomb_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBuscNomb.TextChanged
        If (carga_comp) Then
            If (txtBuscNomb.Text.Length > 4) Then
                cargar_busc_responsable()
            End If
        End If
    End Sub
    Private Sub cargar_busc_responsable()
        carga_comp = False
        Dim sql As String = "SELECT id,descripcion FROM C_cargos_corsan WHERE descripcion like '%" & txtBuscNomb.Text.Trim & "%'"
        dtgConsultResp.DataSource = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")
        carga_comp = True
    End Sub
    Private Sub nuevo()
        txtObjetivo.Text = ""
        id_existente = 0
        dtgPasos.Rows.Clear()
        txtNombProc.Text = ""
        txtCod.Text = ""
        txtVersion.Text = ""
        cboAprueba.Text = "Seleccione"
        cboElabora.Text = "Seleccione"
        cboRevisa.Text = "Seleccione"
        dtgPasos.Rows.Add()
        dtgPasos.Item(colId.Name, dtgPasos.RowCount - 1).Value = 1
    End Sub
    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If (validar()) Then
            If (id_existente = 0) Then
                guardar()
            Else
                modificar()
            End If

        End If
    End Sub
    Private Sub modificar()
        Dim argumento As String = InputBox("ingrese motivo de la mofidicación del procedimiento")
        If (argumento <> "") Then
            Dim insertoCorrecto As Boolean = False
            Dim listSql As New List(Of Object)
            Dim id_proc As String = 0
            Dim nomb_proc As String = txtNombProc.Text
            Dim codigo As String = txtCod.Text
            Dim version As String = txtVersion.Text
            Dim fec_crecion As String = objOpSimplesLn.cambiarFormatoFecha(cboFechaCreacion.Value)
            Dim aprueba As String = cboAprueba.SelectedValue
            Dim elabora As String = cboElabora.SelectedValue
            Dim revisa As String = cboRevisa.SelectedValue
            Dim objetivo As String = txtObjetivo.Text
            Dim sqlEnc As String = ""
            Dim sqlDet As String = ""
            Dim listResponsables As New List(Of String)
            Dim sqlDeleteResp As String = ""
            Dim sqlMofico As String = ""
            If (id_existente = 0) Then
                id_proc = objIngresoProdLn.consultValor("SELECT MAX(id_proc) FROM C_procedimientos", "PRODUCCION")
                If (id_proc = "") Then
                    id_proc = 1
                Else
                    id_proc = Convert.ToString(id_proc) + 1
                End If
            Else
                id_proc = id_existente
            End If
            sqlEnc = "UPDATE C_procedimientos SET nombre ='" & nomb_proc & "',codigo = '" & codigo & "',vers = '" & version & "',fecha_creacion = '" & fec_crecion & "',revisa = " & revisa & ",elabora = " & elabora & ",aprueba = " & aprueba & ",objetivo = '" & objetivo & "' " & _
                               "WHERE id_proc=" & id_proc
            listSql.Add(sqlEnc)
            sqlDeleteResp = "DELETE FROM C_resp_paso_procedimiento WHERE  id_proc =" & id_existente
            listSql.Add(sqlDeleteResp)
            For i = 0 To dtgPasos.RowCount - 1
                If (dtgPasos.Item(colActividad.Name, i).Value <> "" Or dtgPasos.Item(colNombResponsable.Name, i).Value <> "") Then
                    If (existePaso(id_proc, dtgPasos.Item(colId.Name, i).Value)) Then
                        sqlDet = "UPDATE  C_procedimientos_lin " & _
                                                             "SET descripcion = '" & dtgPasos.Item(colActividad.Name, i).Value & "' " & _
                                                                     "WHERE id_proc= " & id_proc & " And id_subproc=" & dtgPasos.Item(colId.Name, i).Value
                    Else
                        sqlDet = "INSERT INTO C_procedimientos_lin " & _
                                    "(id_proc,id_subproc,descripcion) " & _
                                                "VALUES(" & id_proc & "," & dtgPasos.Item(colId.Name, i).Value & ",'" & dtgPasos.Item(colActividad.Name, i).Value & "')"
                    End If


                    listSql.Add(sqlDet)
                    listSql.AddRange(listarSqlResponsables(dtgPasos.Item(colNitResponsable.Name, i).Value, dtgPasos.Item(colId.Name, i).Value, id_proc))
                End If
            Next
            sqlMofico = "UPDATE C_procedimientos SET fecha_modificacion = GETDATE () , quien_modif ='" & usuario.usuario & "',notas_modif = '" & argumento & "' WHERE id_proc =" & id_existente
            listSql.Add(sqlMofico)
            insertoCorrecto = objIngresoProdLn.ExecuteSqlTransaction(listSql, "PRODUCCION")
            If (insertoCorrecto) Then
                MessageBox.Show("El procedimiento fue modificado en forma correcta", "Correcto!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Error al modificar el procedimiento comuniquese con el administrador del sistema ", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
         Else
            MessageBox.Show("Se debe ingresar un motivo para la modificación del procedimiento", "Correcto!", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
    Private Sub guardar()
        Dim insertoCorrecto As Boolean = False
        Dim listSql As New List(Of Object)
        Dim id_proc As String = 0
        Dim nomb_proc As String = txtNombProc.Text
        Dim codigo As String = txtCod.Text
        Dim version As String = txtVersion.Text
        Dim fec_crecion As String = objOpSimplesLn.cambiarFormatoFecha(cboFechaCreacion.Value)
        Dim aprueba As String = cboAprueba.SelectedValue
        Dim elabora As String = cboElabora.SelectedValue
        Dim revisa As String = cboRevisa.SelectedValue
        Dim objetivo As String = txtObjetivo.Text
        Dim sqlEnc As String = ""
        Dim sqlDet As String = ""
        Dim listResponsables As New List(Of String)
        If (id_existente = 0) Then
            id_proc = objIngresoProdLn.consultValor("SELECT MAX(id_proc) FROM C_procedimientos", "PRODUCCION")
            If (id_proc = "") Then
                id_proc = 1
            Else
                id_proc = Convert.ToString(id_proc) + 1
            End If
        Else
            id_proc = id_existente
        End If
        sqlEnc = "INSERT INTO C_procedimientos (id_proc,nombre,codigo,vers,fecha_creacion,revisa,elabora,aprueba,objetivo) " & _
                           "VALUES (" & id_proc & ",'" & nomb_proc & "','" & codigo & "','" & version & "','" & fec_crecion & "'," & revisa & "," & elabora & "," & aprueba & ",'" & objetivo & "') "
        listSql.Add(sqlEnc)
        For i = 0 To dtgPasos.RowCount - 1
            If (dtgPasos.Item(colActividad.Name, i).Value <> "" Or dtgPasos.Item(colNombResponsable.Name, i).Value <> "") Then
                sqlDet = "INSERT INTO C_procedimientos_lin " & _
                                       "(id_proc,id_subproc,descripcion) " & _
                                               "VALUES(" & id_proc & "," & dtgPasos.Item(colId.Name, i).Value & ",'" & dtgPasos.Item(colActividad.Name, i).Value & "')"

                listSql.Add(sqlDet)
                listSql.AddRange(listarSqlResponsables(dtgPasos.Item(colNitResponsable.Name, i).Value, dtgPasos.Item(colId.Name, i).Value, id_proc))
            End If
        Next
        insertoCorrecto = objIngresoProdLn.ExecuteSqlTransaction(listSql, "PRODUCCION")
        If (insertoCorrecto) Then
            MessageBox.Show("El procedimiento fue guardado en forma correcta", "Correcto!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            nuevo()
        Else
            MessageBox.Show("Error al guardar el procedimiento comuniquese con el administrador del sistema ", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Private Function listarSqlResponsables(ByVal cadena As String, ByVal id_detalle As Integer, ByVal id_proc As Integer) As List(Of String)
        Dim list As New List(Of String)
        Dim sql As String = "INSERT INTO C_resp_paso_procedimiento (id_proc,id_subproc,responsable) VALUES(" & id_proc & "," & id_detalle & ", "
        Dim nit As String = ""
        For i = 0 To cadena.Length - 1
            If (cadena(i) <> "") Then
                If (cadena(i) = "-") Then
                    list.Add(sql & nit & ")")
                    nit = ""
                Else
                    nit &= cadena(i)
                End If
            End If
        Next
        Return list
    End Function
    Private Function validar() As Boolean
        dtgPasos.CurrentCell = Nothing
        If (validarPasosCompleto()) Then
            If (txtNombProc.Text <> "") Then
                If (txtCod.Text <> "") Then
                    If (txtVersion.Text <> "") Then
                        If (cboAprueba.Text <> "Seleccione") Then
                            If (cboElabora.Text <> "Seleccione") Then
                                If (cboRevisa.Text <> "Seleccione") Then
                                    If (txtObjetivo.Text <> "") Then
                                        Return True
                                    Else
                                        MessageBox.Show("El campo objetivo es obligatorio ", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    End If
                                Else
                                    MessageBox.Show("El campo revisa es obligatorio ", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                End If
                            Else
                                MessageBox.Show("El campo elabora es obligatorio ", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End If
                        Else
                            MessageBox.Show("El campo aprueba es obligatorio ", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    Else
                        MessageBox.Show("El campo versión es obligatorio ", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Else
                    MessageBox.Show("El campo código es obligatorio ", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                MessageBox.Show("El campo nombre del procedimiento es obligatorio ", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
        Return False
    End Function
    Private Function validarPasosCompleto() As Boolean
        Dim contador As Integer = 0
        If (dtgPasos.RowCount > 0) Then
            For i = 0 To dtgPasos.RowCount - 1
                If (dtgPasos.Item(colActividad.Name, i).Value <> "" Or dtgPasos.Item(colNombResponsable.Name, i).Value <> "") Then
                    If (dtgPasos.Item(colActividad.Name, i).Value = "" Or dtgPasos.Item(colNombResponsable.Name, i).Value = "") Then
                        MessageBox.Show("Verifique que todos los campos de la fila " & i + 1 & " esten diligenciados para guardar", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Return False
                    Else
                        contador += 1
                    End If
                End If
            Next
        Else
            MessageBox.Show("Se debe diligenciar al menos 1 paso", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If
        If (contador = 0) Then
            MessageBox.Show("Se debe diligenciar al menos 1 paso", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If
        Return True
    End Function
    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        nuevo()
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

    Public Sub cargar_por_consulta(ByVal id_proc As Integer)
        Dim sqlEnc As String = "SELECT nombre,codigo,vers,fecha_creacion,fecha_modificacion,elabora,revisa,aprueba,objetivo FROM C_procedimientos WHERE id_proc = " & id_proc
        Dim sqlDet As String = "SELECT P.id_subproc,P.descripcion FROM C_procedimientos_lin P WHERE id_proc = " & id_proc
        Dim sqlDet_resp As String = "SELECT P.responsable,P.id_subproc ,C.descripcion   FROM C_resp_paso_procedimiento  P ,C_cargos_corsan  C WHERE  P.responsable = C.id AND P.id_proc =  " & id_proc
        Dim dtEnc As New DataTable
        Dim dtDet As New DataTable
        Dim dtDet_resp As New DataTable
        dtEnc = objOpSimplesLn.listar_datatable(sqlEnc, "PRODUCCION")
        dtDet = objOpSimplesLn.listar_datatable(sqlDet, "PRODUCCION")
        dtDet_resp = objOpSimplesLn.listar_datatable(sqlDet_resp, "PRODUCCION")

        txtObjetivo.Text = dtEnc.Rows(0).Item("objetivo")
        txtNombProc.Text = dtEnc.Rows(0).Item("nombre")
        txtCod.Text = dtEnc.Rows(0).Item("codigo")
        txtVersion.Text = dtEnc.Rows(0).Item("vers")
        cboFechaCreacion.Value = dtEnc.Rows(0).Item("fecha_creacion")
        If Not IsDBNull(dtEnc.Rows(0).Item("fecha_modificacion")) Then
            cboFechaMod.Value = dtEnc.Rows(0).Item("fecha_modificacion")
        End If
        cboAprueba.SelectedValue = dtEnc.Rows(0).Item("aprueba")
        cboRevisa.SelectedValue = dtEnc.Rows(0).Item("revisa")
        cboElabora.SelectedValue = dtEnc.Rows(0).Item("elabora")
        dtgPasos.Rows.Clear()
        For i = 0 To dtDet.Rows.Count - 1
            dtgPasos.Rows.Add()
            dtgPasos.Item(colId.Name, dtgPasos.RowCount - 1).Value = dtDet.Rows(i).Item("id_subproc")
            dtgPasos.Item(colActividad.Name, dtgPasos.RowCount - 1).Value = dtDet.Rows(i).Item("descripcion")
            For j = 0 To dtDet_resp.Rows.Count - 1
                If (dtDet_resp.Rows(j).Item("id_subproc") = dtDet.Rows(i).Item("id_subproc")) Then
                    dtgPasos.Item(colNitResponsable.Name, dtgPasos.RowCount - 1).Value &= dtDet_resp.Rows(j).Item("responsable")
                    dtgPasos.Item(colNombResponsable.Name, dtgPasos.RowCount - 1).Value &= dtDet_resp.Rows(j).Item("descripcion")
                    If (j <> dtDet_resp.Rows.Count - 1 Or j = 0) Then
                        dtgPasos.Item(colNombResponsable.Name, dtgPasos.RowCount - 1).Value &= " -"
                        dtgPasos.Item(colNitResponsable.Name, dtgPasos.RowCount - 1).Value &= " -"
                    End If
                End If
            Next

        Next

    End Sub


    Private Sub btnSolCambio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSolCambio.Click
        If (txtDescCambio.Text <> "") Then
            enviarCorreo()
            MessageBox.Show("Su solicitud de cambio fue enviada en forma exitosa!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Se debe ingresar la descripción de cambio", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
    Private Sub enviarCorreo()
        Dim destino As String = objOpSimplesLn.returnCorreosModulo(nomb_modulo)
        Dim texto As String = txtDescCambio.Text & vbCrLf & _
                                "Procedimiento: " & txtNombProc.Text & vbCrLf & _
                                    "Paso: " & dtgPasos.Item(colId.Name, colSelect).Value
        Dim titulo As String = "Solicitud de cambio generada por: " & usuario.nombre
        Dim direccion As String = ""
        Dim email As String = objOpSimplesLn.consultarVal("SELECT Mail from jjv_usuarios WHERE usuario ='ADMIN'")
        Dim contra As String = objOpSimplesLn.consultarVal("SELECT Mail_login from jjv_usuarios WHERE usuario ='ADMIN'")
        If Not (objEnvCorreoLN.EnviarCorreo(destino, texto, titulo, direccion, email, contra, False)) Then
            Using New Centered_MessageBox(Me)
                MessageBox.Show("Error al enviar el correo,comuniquese con el administrador del sistema!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Using
        End If
    End Sub

    Private Sub btnCerrarSolCambio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrarSolCambio.Click
        groupSolCambio.Visible = False
        txtDescCambio.Text = ""
    End Sub

    Private Sub btnCerrarEditResp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrarEditResp.Click
        group_edit_resp.Visible = False
        dtgEditResponsable.Rows.Clear()
    End Sub

    Private Sub dtgEditResponsable_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgEditResponsable.CellClick
        If (e.RowIndex >= 0) Then
            If (dtgEditResponsable.Columns(e.ColumnIndex).Name = colBorrarResp.Name) Then
                dtgPasos.Item(colNitResponsable.Name, colSelect).Value = ""
                dtgPasos.Item(colNombResponsable.Name, colSelect).Value = ""
                dtgEditResponsable.Rows.RemoveAt(e.RowIndex)
                For i = 0 To dtgEditResponsable.RowCount - 1
                    dtgPasos.Item(colNitResponsable.Name, colSelect).Value &= dtgEditResponsable.Item(colNitEditResp.Name, i).Value & "-"
                    dtgPasos.Item(colNombResponsable.Name, colSelect).Value &= dtgEditResponsable.Item(colNombEditResp.Name, i).Value & "-"
                Next
                group_edit_resp.Visible = False
                dtgEditResponsable.Rows.Clear()
            End If
        End If

    End Sub
    Private Sub dtgPasos_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dtgPasos.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            With (Me.dtgPasos)
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                End If
            End With
        End If
    End Sub

    Private Sub itemEditResp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles itemEditResp.Click
        Dim cadenaNit As String = ""
        If IsNothing(dtgPasos.Item(colNitResponsable.Name, dtgPasos.CurrentCell.RowIndex).Value) Then
            cadenaNit = ""
        Else
            cadenaNit = dtgPasos.Item(colNitResponsable.Name, dtgPasos.CurrentCell.RowIndex).Value
        End If
        Dim nit As String = ""
        For i = 0 To cadenaNit.Length - 1
            If (cadenaNit(i) <> "") Then
                If (cadenaNit(i) = "-") Then
                    group_edit_resp.Visible = True
                    dtgEditResponsable.Rows.Add()
                    dtgEditResponsable.Item(colNitEditResp.Name, dtgEditResponsable.RowCount - 1).Value = nit
                    dtgEditResponsable.Item(colNombEditResp.Name, dtgEditResponsable.RowCount - 1).Value = objIngresoProdLn.consultValor("SELECT descripcion FROM C_cargos_corsan WHERE id =" & nit, "PRODUCCION")
                    nit = ""
                Else
                    nit &= cadenaNit(i)
                End If
            End If
        Next
    End Sub

 

End Class