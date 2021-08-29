Imports logicaNegocios

Public Class Frm_encuesta_clientes
    Dim id_existente As Integer = 0

    Private objOpSimplsLn As New Op_simpesLn
    Private Sub Frm_encuesta_clientes_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        llenarDatatable()
    End Sub
    Private Sub llenarDatatable()
        lbl_modificar.Text = ""
        Dim dt As New DataTable
        Dim sql As String = "SELECT id,pregunta FROM J_encu_preguntas WHERE anulado is null"
        dt = objOpSimplsLn.listar_datatable(sql, "CORSAN")
        dt.Columns.Add("Calificación", GetType(Double))

        dtgEvaluacion.DataSource = dt
        dtgEvaluacion.Columns("id").Visible = False
        dtgEvaluacion.Columns("pregunta").ReadOnly = False
    End Sub

    Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
        If (validar()) Then
            guardar()
        End If
    End Sub
    Private Sub guardar()
        Dim listSql As New List(Of Object)
        Dim listTipoComunicacion As New List(Of Object)
        Dim listTipoCompra As New List(Of Object)
        Dim contacto As String = txtContacto.Text
        Dim cargo As String = txtCargo.Text
        Dim id As Double
        Dim nit As String = txtNit.Text
        Dim sugerenia As String = txtSugerencia.Text
        Dim tipoComunicacion As Integer = 0
        Dim tipoCompra As Integer = 0
        Dim sqlTipoCompra As String = "INSERT INTO J_encu_enc_tipo_compra (id_enc,tipo_compra) VALUES "
        Dim sqlTipoCom As String = "INSERT INTO J_encu_enc_tipo_com (id_enc,tipo_comunicacion) VALUES "
        If id_existente <> 0 Then
            id = id_existente
            listSql.Add("DELETE FROM J_encu_detalle WHERE id " & id_existente)
            listSql.Add("DELETE FROM  J_encu_enc_tipo_com FROM WHERE id " & id_existente)
            listSql.Add("DELETE FROM  J_encu_enc_tipo_compra FROM WHERE id " & id_existente)
            listSql.Add("DELETE FROM J_encu_encabezado WHERE id " & id_existente)
        Else
            id = objOpSimplsLn.consultarVal("SELECT  (SELECT CASE WHEN MAX(id) IS NULL THEN (1) ELSE MAX(id)+1 END) as id FROM J_encu_encabezado")
        End If
        If (chk_tel.Checked) Then
            listTipoComunicacion.Add(1)
        End If

        If (chk_personal.Checked) Then

            listTipoComunicacion.Add(2)
        End If
        If (chk_internet.Checked) Then
            listTipoComunicacion.Add(3)
        End If

        If (chkPrecio.Checked) Then
            listTipoCompra.Add(1)
        End If

        If (chkCalidad.Checked) Then
            listTipoCompra.Add(2)
        End If

        If (chkMarca.Checked) Then
            listTipoCompra.Add(3)
        End If

        If (chkPortafolio.Checked) Then
            listTipoCompra.Add(4)
        End If
        If (chkRota.Checked) Then
            listTipoCompra.Add(5)
        End If

        Dim sql_enc As String = "INSERT INTO J_encu_encabezado (id,fecha,nit,sugerencia,contacto,cargo) VALUES (" & id & ",GETDATE()," & nit & ",'" & sugerenia & "','" & contacto & "','" & cargo & "')"
        listSql.Add(sql_enc)
        Dim sql_det As String = "INSERT INTO J_encu_detalle (id_encuesta,pregunta,califiacion) VALUES "
        For i = 0 To dtgEvaluacion.RowCount - 1
            listSql.Add(sql_det & "(" & id & "," & dtgEvaluacion.Item("id", i).Value & "," & dtgEvaluacion.Item("Calificación", i).Value & ")")
        Next

        For i = 0 To listTipoCompra.Count - 1
            listSql.Add(sqlTipoCompra & "(" & id & "," & listTipoCompra(i) & ")")
        Next

        For i = 0 To listTipoComunicacion.Count - 1
            listSql.Add(sqlTipoCom & "(" & id & "," & listTipoComunicacion(i) & ")")
        Next

        If (objOpSimplsLn.ExecuteSqlTransaction(listSql)) Then
            MessageBox.Show("La encuesta se guardo en forma exitosa", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information)
            nuevo()
        Else
            MessageBox.Show("Error al aguardar la encuesta, comuniquese con el administrador del sistema", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub
    Private Function validar() As Boolean
        Dim resp As Boolean = False
        If (txtNit.Text <> "") Then
            If (txtContacto.Text <> "") Then
                If (txtCargo.Text <> "") Then
                    If (objOpSimplsLn.consultarVal("SELECT nit FROM terceros WHERE nit = " & txtNit.Text) <> "") Then
                        If Not (objOpSimplsLn.consultarVal("SELECT nit FROM J_encu_encabezado WHERE nit = " & txtNit.Text & " AND YEAR (fecha) = " & Now.Year) <> "") Then
                            If (chk_internet.Checked Or chk_personal.Checked Or chk_tel.Checked) Then
                                If (chkCalidad.Checked Or chkMarca.Checked Or chkPortafolio.Checked Or chkPrecio.Checked Or chkRota.Checked) Then
                                    For i = 0 To dtgEvaluacion.RowCount - 1
                                        If IsNumeric(dtgEvaluacion.Item("Calificación", i).Value) Then
                                            If (dtgEvaluacion.Item("Calificación", i).Value >= 1 And dtgEvaluacion.Item("Calificación", i).Value <= 5) Then
                                                resp = True
                                            Else
                                                i = dtgEvaluacion.RowCount - 1
                                                resp = False
                                                MessageBox.Show("Todas las preguntas deben ser calificadas entre (1 y 5), verifique", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                            End If
                                        Else
                                            i = dtgEvaluacion.RowCount - 1
                                            resp = False
                                            MessageBox.Show("Todos las preguntas deben ser calificadas, verifique", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                        End If
                                    Next
                                Else
                                    MessageBox.Show("Seleccione por lo menos un motivo de compra, verifique", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                End If
                            Else
                                MessageBox.Show("Seleccione por lo menos un tipo de comunicación, verifique", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            End If
                        Else
                            MessageBox.Show("Esta cliente ya se encuetra calificado para el " & Now.Year & "", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If
                    Else
                        MessageBox.Show("No existe este nit en terceros, verifique", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                Else
                    MessageBox.Show("El cargo es obligatorio", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                MessageBox.Show("El contacto es obligatorio", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            MessageBox.Show("El nit es obligatorio", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Return resp
    End Function

    Private Sub btnNuevo_Click(sender As System.Object, e As System.EventArgs) Handles btnNuevo.Click
        nuevo()
    End Sub
    Private Sub nuevo()
        id_existente = 0
        lbl_modificar.Text = ""
        txtCorreo.Text = ""
        txtNit.Text = ""
        txtNombres.Text = ""
        txtCargo.Text = ""
        txtContacto.Text = ""
        txtSugerencia.Text = ""
        txtTel.Text = ""
        txtVendedor.Text = ""
        For i = 0 To dtgEvaluacion.RowCount - 1
            dtgEvaluacion.Item("Calificación", i).Value = 0
        Next
        chk_tel.Checked = False
        chk_personal.Checked = False
        chk_internet.Checked = False

        chkPrecio.Checked = False
        chkCalidad.Checked = False
        chkMarca.Checked = False
        chkPortafolio.Checked = False
        chkRota.Checked = False
    End Sub

    Private Sub txtNit_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtNit.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
        If (e.KeyChar = Microsoft.VisualBasic.ChrW(13) And txtNit.Text <> "") Then
            Dim nit As Double = txtNit.Text
            If (objOpSimplsLn.consultarVal("SELECT nit FROM terceros WHERE nit = " & txtNit.Text) <> "") Then
                If (txtNit.Text <> "") Then
                    cargar_info_client()
                Else
                    MessageBox.Show("Ingrese un nit", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                MessageBox.Show("No existe este nit en terceros, verifique", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

        End If
    End Sub
    Private Sub cargar_info_client()
        If (objOpSimplsLn.consultarVal("SELECT nit FROM J_encu_encabezado WHERE anulado is null AND nit = " & txtNit.Text & " AND YEAR (fecha) = " & Now.Year) = "" Or id_existente <> 0) Then
            Dim sql As String = "SELECT  nit,nombres,mail,telefono_1,vendedor FROM terceros WHERE nit =" & txtNit.Text
            Dim dt As DataTable = objOpSimplsLn.listar_datatable(sql, "CORSAN")
            For i = 0 To dt.Rows.Count - 1
                If Not IsDBNull(dt.Rows(i).Item("nombres")) Then
                    txtNombres.Text = dt.Rows(i).Item("nombres")
                End If
                If Not IsDBNull(dt.Rows(i).Item("mail")) Then
                    txtCorreo.Text = dt.Rows(i).Item("mail")
                End If
                If Not IsDBNull(dt.Rows(i).Item("telefono_1")) Then
                    txtTel.Text = dt.Rows(i).Item("telefono_1")
                End If
                If Not IsDBNull(dt.Rows(i).Item("vendedor")) Then
                    txtVendedor.Text = dt.Rows(i).Item("vendedor")
                End If
            Next
        Else
            MessageBox.Show("Ya existe evaluación para el año " & Now.Year & ", verifique", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            nuevo()
        End If

    
    End Sub

    Private Sub btn_busc_cliente_Click(sender As System.Object, e As System.EventArgs) Handles btn_busc_cliente.Click
        groupCliente.Visible = True
        txt_nombres.Focus()
    End Sub
    Private Sub dtg_clientes_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtg_clientes.CellContentClick
        If (e.RowIndex >= 0) Then
            If (dtg_clientes.Columns(e.ColumnIndex).Name = colOk.Name) Then
                txtNit.Text = dtg_clientes.Item("nit", e.RowIndex).Value
                groupCliente.Visible = False
                dtg_clientes.DataSource = Nothing
                txt_nombres.Text = ""
                cargar_info_client()
            End If
        End If
    End Sub
    Private Sub txt_nombres_TextChanged(sender As System.Object, e As System.EventArgs) Handles txt_nombres.TextChanged
        If (txt_nombres.Text.Length > 3) Then
            cargar_clientes()
        End If
    End Sub
    Private Sub cargar_clientes()
        Dim sql As String = "Select nit,nombres,ciudad FROM terceros "
        Dim whereSql As String = "WHERE (concepto_1 like '%3%' or concepto_1 like '%4%' or concepto_1 like '%9%') "
        If (txt_nombres.Text <> "") Then
            whereSql &= "AND nombres like '%" & txt_nombres.Text & "%'"
        End If
        sql &= whereSql
        dtg_clientes.DataSource = objOpSimplsLn.listar_datatable(sql, "CORSAN")
    End Sub
    Private Sub btn_cerrar_Click(sender As System.Object, e As System.EventArgs) Handles btn_cerrar.Click
        txt_nombres.Text = ""
        dtg_clientes.DataSource = Nothing
        groupCliente.Visible = False
    End Sub
    Public Sub cargarEncuesta(ByVal id_encuesta As Integer)
        id_existente = id_encuesta
        lbl_modificar.Text = "MODIFICANDO ID:" & id_encuesta
        Dim sql_enc As String = "SELECT fecha,nit,sugerencia,contacto,cargo FROM J_encu_encabezado WHERE id = " & id_encuesta
        Dim sql_det As String = "SELECT pregunta,califiacion FROM J_encu_detalle WHERE id_encuesta = " & id_encuesta
        Dim sql_tipo_com As String = "SELECT tipo_comunicacion FROM J_encu_enc_tipo_com WHERE id_enc = " & id_encuesta
        Dim sql_tipo_compra As String = "SELECT tipo_compra FROM J_encu_enc_tipo_compra WHERE id_enc = " & id_encuesta

        Dim dt_enc As DataTable = objOpSimplsLn.listar_datatable(sql_enc, "CORSAN")
        Dim dt_det As DataTable = objOpSimplsLn.listar_datatable(sql_det, "CORSAN")
        Dim dt_tipo_com As DataTable = objOpSimplsLn.listar_datatable(sql_tipo_com, "CORSAN")
        Dim dt_tipo_compra As DataTable = objOpSimplsLn.listar_datatable(sql_tipo_compra, "CORSAN")

        If (dt_enc.Rows.Count > 0) Then
            txtNit.Text = dt_enc.Rows(0).Item("nit")
            txtCargo.Text = dt_enc.Rows(0).Item("cargo")
            txtContacto.Text = dt_enc.Rows(0).Item("contacto")
            txtSugerencia.Text = dt_enc.Rows(0).Item("sugerencia")
            cargar_info_client()
        End If
        For i = 0 To dt_det.Rows.Count - 1
            For j = 0 To dtgEvaluacion.RowCount - 1
                If (dtgEvaluacion.Item("id", i).Value = dt_det.Rows(i).Item("pregunta")) Then
                    dtgEvaluacion.Item("Calificación", i).Value = dt_det.Rows(i).Item("califiacion")
                End If
            Next
        Next
        For i = 0 To dt_tipo_com.Rows.Count - 1
            Select Case dt_tipo_com.Rows(i).Item("tipo_comunicacion")
                Case 1
                    chk_tel.Checked = True
                Case 2
                    chk_personal.Checked = True
                Case 3
                    chk_internet.Checked = True
            End Select
        Next
        For i = 0 To dt_tipo_compra.Rows.Count - 1
            Select Case dt_tipo_compra.Rows(i).Item("tipo_compra")
                Case 1
                    chkPrecio.Checked = True
                Case 2
                    chkCalidad.Checked = True
                Case 3
                    chkMarca.Checked = True
                Case 4
                    chkPortafolio.Checked = True
                Case 5
                    chkRota.Checked = True
            End Select

        Next
    End Sub
End Class