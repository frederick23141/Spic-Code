Imports logicaNegocios
Public Class FrmConsultQuejasRec
    Private carga_completa As Boolean = False
    Private objQuejasRecLn As New QuejaRecLn
    Private objOperacionesForm As New OperacionesFormularios
    Private objOp_simpesLn As New Op_simpesLn
    Private Sub FrmConsultQuejasRec_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cbo_fecha_ini.Value = Now.AddMonths(-1)
        cbo_fecha_fin.Value = Now.Date
        cargarCbo()
        informeGeneral()
        carga_completa = True
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
    Private Sub cargarCbo()
        Dim sql As String
        Dim dt As DataTable
        Dim row As DataRow
        sql = "SELECT descripcion,id  from J_area_resp "
        dt = New DataTable
        dt = objQuejasRecLn.listar_datatable(sql)
        row = dt.NewRow
        row("id") = 0
        row("descripcion") = "TODOS"
        dt.Rows.Add(row)
        cboResp.DataSource = dt
        cboResp.ValueMember = "id"
        cboResp.DisplayMember = "descripcion"
        cboResp.Text = "Seleccione"

        sql = "	SELECT id_pqr,descripcion  from J_pqr   "
        dt = New DataTable
        dt = objQuejasRecLn.listar_datatable(sql)
        row = dt.NewRow
        row("id_pqr") = 0
        row("descripcion") = "TODOS"
        dt.Rows.Add(row)
        cboPqr.DataSource = dt
        cboPqr.ValueMember = "id_pqr"
        cboPqr.DisplayMember = "descripcion"
        cboPqr.Text = "Seleccione"

        sql = "SELECT id_insatisfac ,descripcion  from J_insatisfactor    "
        dt = New DataTable
        dt = objQuejasRecLn.listar_datatable(sql)
        row = dt.NewRow
        row("id_insatisfac") = 0
        row("descripcion") = "TODOS"
        dt.Rows.Add(row)
        cboInsatisfact.DataSource = dt
        cboInsatisfact.ValueMember = "id_insatisfac"
        cboInsatisfact.DisplayMember = "descripcion"
        cboInsatisfact.Text = "Seleccione"

        sql = "SELECT tipo FROM V_cartera_edades_jjv WHERE tipo like 'DVR%' or tipo like 'NCMC%'GROUP BY tipo "
        dt = New DataTable
        dt = objQuejasRecLn.listar_datatable(sql)
        row = dt.NewRow
        row("tipo") = "TODOS"
        dt.Rows.Add(row)
        cboTipoNotaC.DataSource = dt
        cboTipoNotaC.DisplayMember = "tipo"
        cboTipoNotaC.Text = "Seleccione"

        sql = "SELECT CAST(vendedor AS varchar(25))As vendedor FROM v_vendedores WHERE bloqueo =0 and vendedor >= 1001 and vendedor <= 1099 "
        dt = New DataTable
        dt = objQuejasRecLn.listar_datatable(sql)
        row = dt.NewRow
        row("vendedor") = "TODOS"
        dt.Rows.Add(row)
        cbo_vendedor.DataSource = dt
        cbo_vendedor.ValueMember = "vendedor"
        cbo_vendedor.DisplayMember = "vendedor"
        cbo_vendedor.Text = "Seleccione"

    End Sub
    Private Sub consultar()
        If (cboResp.Text <> "") Then
            Dim listaCodigo As New List(Of Object)
            Dim idQueja As String = ""
            Dim codigos As String = ""
            Dim fecIni As String = objOp_simpesLn.cambiarFormatoFecha(Convert.ToDateTime(cbo_fecha_ini.Value))
            Dim fecFin As String = objOp_simpesLn.cambiarFormatoFecha(Convert.ToDateTime(cbo_fecha_fin.Value))
            Dim sql As String = ""
            Dim col As New DataColumn
            Dim dt As New DataTable
            Dim selectSql As String = "SELECT   queja.id_queja As Id,queja.descAreaResp As D_Resp, queja.descAreaResp, queja.cliente As nit,queja.vendedor, queja.nomCliente As nombre,queja.ciudad, queja.descAreaResp As codigo, queja.descAreaResp As desCodigo, queja.descInsatis As insatisfactor, queja.fecha_ingreso, queja.descPqr As Pqr, queja.desc_problema, " & _
                                     "queja.causas_detect, queja.acciones_seguir, queja.monto, queja.fecha_cierre, queja.motivo_cierre, queja.observaciones,  queja.ncmc As n_credito"
            Dim fromSql As String = " FROM J_V_quejas_rec queja "
            Dim whereSql As String = " WHERE queja.fecha_ingreso >= '" & fecIni & "' AND queja.fecha_ingreso <= '" & fecFin & "' "
            If (cboResp.Text <> "TODOS" And cboResp.Text <> "Seleccione") Then
                whereSql += " AND queja.idResp = " & cboResp.SelectedValue
            End If
            If (cboInsatisfact.Text <> "Seleccione" And cboInsatisfact.Text <> "TODOS") Then
                whereSql += " AND queja.insatisfaccion = " & cboInsatisfact.SelectedValue
            ElseIf (cboPqr.Text <> "Seleccione" And cboPqr.Text <> "TODOS") Then
                whereSql += " AND queja.pqr = " & cboPqr.SelectedValue
            End If
            If (cboTipoNotaC.Text <> "Seleccione" And cboTipoNotaC.Text <> "TODOS") Then
                fromSql += ",V_cartera_edades_jjv car"
                whereSql += " AND car.numero = queja.ncmc AND car.nit = queja.cliente AND car.tipo = '" & cboTipoNotaC.Text & "'"
            End If
            If (txt_cliente.Text <> "") Then
                whereSql &= " AND queja.cliente = " & txt_cliente.Text & " "
            End If
            If (cbo_vendedor.Text <> "Seleccione" And cbo_vendedor.Text <> "TODOS") Then
                whereSql &= " AND queja.vendedor = " & cbo_vendedor.SelectedValue & " "
            End If
            sql = selectSql & fromSql & whereSql
            dt = objQuejasRecLn.listar_datatable(sql)
            col.ColumnName = "TipoNotaC"
            dt.Columns.Add(col)
            col = New DataColumn
            col.ColumnName = "VrTotal"
            dt.Columns.Add(col)

            dtg_consulta.DataSource = dt
            dtg_consulta.Columns("fecha_ingreso").DefaultCellStyle.Format = "d"
            dtg_consulta.Columns("fecha_cierre").DefaultCellStyle.Format = "d"
            dtg_consulta.Columns("codigo").DefaultCellStyle.WrapMode = DataGridViewTriState.True
            dtg_consulta.Columns("desCodigo").DefaultCellStyle.WrapMode = DataGridViewTriState.True
            If (dtg_consulta.RowCount - 1 <> -1) Then
                progBar.Maximum = dtg_consulta.RowCount - 1
                progBar.Minimum = 0
            End If

            For i = 0 To dtg_consulta.RowCount - 1
                progBar.Value = i
                idQueja = dtg_consulta.Item("Id", i).Value
                listaCodigo = objQuejasRecLn.listarCodigo(idQueja)
                For j = 0 To listaCodigo.Count - 1
                    codigos += listaCodigo(j) & "-"
                    If (j <> listaCodigo.Count - 1) Then
                        codigos += vbCrLf
                    End If
                Next
                If (codigos <> "") Then
                    dtg_consulta.Item("codigo", i).Value = codigos
                    actTxtDesc(codigos, i)
                    codigos = ""
                Else
                    dtg_consulta.Item("codigo", i).Value = ""
                    dtg_consulta.Item("desCodigo", i).Value = ""
                End If
            Next
            dtg_consulta.Columns("codigo").AutoSizeMode = 6
            dtg_consulta.Columns("desCodigo").Width = 320

            dtg_consulta.Columns("Id").AutoSizeMode = 4
            dtg_consulta.Columns("Id").Frozen = True
            dtg_consulta.Columns("descAreaResp").AutoSizeMode = 6
            dtg_consulta.Columns("nit").AutoSizeMode = 6
            dtg_consulta.Columns("nombre").AutoSizeMode = 6
            dtg_consulta.Columns("ciudad").AutoSizeMode = 6
            dtg_consulta.Columns("insatisfactor").AutoSizeMode = 6
            dtg_consulta.Columns("fecha_ingreso").AutoSizeMode = 6
            dtg_consulta.Columns("Pqr").AutoSizeMode = 6
            dtg_consulta.Columns("desc_problema").AutoSizeMode = 6

            dtg_consulta.Columns("causas_detect").AutoSizeMode = 6
            dtg_consulta.Columns("acciones_seguir").AutoSizeMode = 6
            dtg_consulta.Columns("monto").AutoSizeMode = 6
            dtg_consulta.Columns("fecha_cierre").AutoSizeMode = 6

            dtg_consulta.Columns("motivo_cierre").AutoSizeMode = 6
            dtg_consulta.Columns("observaciones").AutoSizeMode = 6
            dtg_consulta.Columns("n_credito").AutoSizeMode = 6
            dtg_consulta.Columns("D_Resp").AutoSizeMode = 6
            insertarDrespYNotaC()
            informeGeneral()
            pintarEstado()
            progBar.Value = 0
        End If
    End Sub
    Private Sub pintarEstado()
        For i = 0 To dtg_consulta.RowCount - 1
            If (dtg_consulta.Item("D_Resp", i).Value <> "") Then
                dtg_consulta.Item("D_Resp", i).Style.BackColor = Color.GreenYellow
            Else
                dtg_consulta.Item("D_Resp", i).Style.BackColor = Color.Red
            End If
        Next
    End Sub
    Private Sub insertarDrespYNotaC()
        For i = 0 To dtg_consulta.RowCount - 1
            If (dtg_consulta.Item("fecha_cierre", i).Value <> "1/1/1900 12:00:00 AM") Then
                dtg_consulta.Item("D_Resp", i).Value = objOp_simpesLn.calcDiasHabiles(dtg_consulta.Item("fecha_ingreso", i).Value, dtg_consulta.Item("fecha_cierre", i).Value)
            Else
                dtg_consulta.Item("D_Resp", i).Value = ""
            End If
            If (dtg_consulta.Item("n_credito", i).Value <> "0") Then
                Dim sql As String = "SELECT tipo  FROM  V_cartera_edades_jjv 	WHERE (tipo like 'DVR%' OR tipo like 'NCMC') and numero = " & dtg_consulta.Item("n_credito", i).Value & " and nit= " & dtg_consulta.Item("nit", i).Value
                dtg_consulta.Item("TipoNotaC", i).Value = objQuejasRecLn.consultValor(sql)
                dtg_consulta.Item("VrTotal", i).Value = objQuejasRecLn.consultValor("SELECT valor_total  FROM  V_cartera_edades_jjv 	WHERE (tipo like 'DVR%' OR tipo like 'NCMC') and numero = " & dtg_consulta.Item("n_credito", i).Value & " and nit= " & dtg_consulta.Item("nit", i).Value)
            End If
        Next
    End Sub
    Private Sub cboInsatisfact_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboInsatisfact.SelectedIndexChanged
        If (carga_completa) Then
            txt_cliente.Text = ""
            cboPqr.Text = "Seleccione"
        End If
    End Sub

    Private Sub cboResp_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboResp.SelectedIndexChanged
        If (carga_completa) Then
            txt_cliente.Text = ""
        End If
    End Sub

    Private Sub cboPqr_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPqr.SelectedIndexChanged
        If (carga_completa) Then
            txt_cliente.Text = ""
            cboInsatisfact.Text = "Seleccione"
        End If
    End Sub

    Private Sub informeGeneral()
        Dim dResp As Double = 0
        Dim alcance As Double = 0
        Dim fecIni As String = objOp_simpesLn.cambiarFormatoFecha(Convert.ToDateTime(cbo_fecha_ini.Value))
        Dim fecFin As String = objOp_simpesLn.cambiarFormatoFecha(Convert.ToDateTime(cbo_fecha_fin.Value))
        Dim selectFromSql As String = "SELECT COUNT(*) FROM J_V_quejas_rec "
        Dim whereSql As String = " WHERE fecha_ingreso >= '" & fecIni & "' AND fecha_ingreso <= '" & fecFin & "' "
        If (cboResp.Text <> "TODOS" And cboResp.Text <> "Seleccione") Then
            whereSql += " AND idResp = " & cboResp.SelectedValue
        End If
        If (cboInsatisfact.Text <> "Seleccione" And cboInsatisfact.Text <> "TODOS") Then
            whereSql += " AND insatisfaccion = " & cboInsatisfact.SelectedValue
        ElseIf (cboPqr.Text <> "Seleccione" And cboPqr.Text <> "TODOS") Then
            whereSql += " AND pqr = " & cboPqr.SelectedValue
        End If
        txtRecivido.Text = objQuejasRecLn.consultValor(selectFromSql & whereSql)
        txtPend.Text = objQuejasRecLn.consultValor(selectFromSql & whereSql & " AND fecha_cierre= '1/1/1900 12:00:00 AM' ")
        txtSol.Text = objQuejasRecLn.consultValor(selectFromSql & whereSql & " AND fecha_cierre<> '1/1/1900 12:00:00 AM' ")
        If (txtSol.Text <> "0") Then

            For i = 0 To dtg_consulta.RowCount - 1
                If ((Convert.ToString(dtg_consulta.Item("D_Resp", i).Value)) <> "") Then
                    dResp += dtg_consulta.Item("D_Resp", i).Value
                End If

            Next
            If (dResp > 0) Then
                txtPromDresp.Text = dResp / txtSol.Text
            End If
        End If
        If (cboResp.Text = "Seleccione") Then
            txtArea.Text = "Todos"
        Else
            txtArea.Text = cboResp.Text
        End If
        If (txtSol.Text <> "0" And txtRecivido.Text <> "0") Then
            alcance = Convert.ToInt16((txtSol.Text / txtRecivido.Text) * 100)
            txtAlc.Text = alcance
            If (alcance >= 85) Then
                imgAlcance.Image = Spic.My.Resources.ok3
            ElseIf (alcance >= 61 And alcance <= 84) Then
                imgAlcance.Image = Spic.My.Resources.estable
            ElseIf (alcance <= 60) Then
                imgAlcance.Image = Spic.My.Resources._1371750041_14125
            End If
        ElseIf (txtSol.Text = "0") Then
            txtAlc.Text = 0
            imgAlcance.Image = Spic.My.Resources._1371750041_14125
        End If
    End Sub
    Private Sub actTxtDesc(ByVal codigos As String, ByVal fila As Integer)
        Dim sql As String = ""
        Dim codigo As String = ""
        dtg_consulta.Item("desCodigo", fila).Value = ""
        For i = 0 To codigos.Length - 1
            If (codigos(i) <> "-") Then
                If (codigos(i) <> "" & vbCr & "" And codigos(i) <> "" & vbLf & "") Then
                    codigo += codigos(i)
                End If
            End If
            If ((codigos(i) = "-" Or i = codigos.Length - 1) And (codigo <> "")) Then
                sql = "SELECT descripcion FROM referencias WHERE codigo = '" & codigo & "'"
                codigo = ""
                dtg_consulta.Item("desCodigo", fila).Value += objQuejasRecLn.consultValor(sql)
                If (i <> codigos.Length - 1) Then
                    dtg_consulta.Item("desCodigo", fila).Value += vbCrLf
                End If
            End If
        Next
    End Sub
    Private Sub btn_excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_excel.Click
        objOperacionesForm.ExportarDatosExcel(dtg_consulta, "Quejas y reclamos")
    End Sub
    Private Sub cboTipoNotaC_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipoNotaC.SelectedIndexChanged
        If (carga_completa) Then
            txt_cliente.Text = ""
        End If
    End Sub

    Private Sub btnActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActualizar.Click
        consultar()
    End Sub

    Private Sub txt_cliente_MouseClick(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles txt_cliente.MouseClick
        txt_cliente.Text = ""
        groupCliente.Visible = True
        txt_nombres.Focus()
    End Sub
    Private Sub btn_cerrar_Click(sender As System.Object, e As System.EventArgs) Handles btn_cerrar.Click
        carga_completa = False
        txt_nit.Text = ""
        txt_nombres.Text = ""
        dtg_clientes.DataSource = Nothing
        groupCliente.Visible = False
        carga_completa = True
    End Sub
    Private Sub dtg_clientes_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtg_clientes.CellContentClick
        If (e.RowIndex >= 0) Then
            If (dtg_clientes.Columns(e.ColumnIndex).Name = colOk.Name) Then
                carga_completa = False
                txt_cliente.Text = ""
                txt_cliente.Text = dtg_clientes.Item("nit", e.RowIndex).Value
                groupCliente.Visible = False
                dtg_clientes.DataSource = Nothing
                txt_nit.Text = ""
                txt_nombres.Text = ""
                carga_completa = True
                consultar()
            End If
        End If
    End Sub
    Private Sub txt_nit_TextChanged(sender As System.Object, e As System.EventArgs) Handles txt_nit.TextChanged
        carga_completa = False
        txt_nombres.Text = ""
        carga_completa = True
        If (carga_completa And txt_nit.Text.Length > 2) Then
            cargar_clientes()
        End If
    End Sub
    Private Sub txt_nombres_TextChanged(sender As System.Object, e As System.EventArgs) Handles txt_nombres.TextChanged
        carga_completa = False
        txt_nit.Text = ""
        carga_completa = True
        If (carga_completa And txt_nombres.Text.Length > 3) Then
            cargar_clientes()
        End If
    End Sub
    Private Sub cargar_clientes()
        Dim sql As String = "Select nit,nombres,ciudad FROM terceros "
        Dim whereSql As String = "WHERE (concepto_1 like '%3%' or concepto_1 like '%4%' or concepto_1 like '%9%') "
        If (txt_nit.Text <> "") Then
            whereSql &= " AND nit like '" & txt_nit.Text & "%'"
        ElseIf (txt_nombres.Text <> "") Then
            whereSql &= "AND nombres like '%" & txt_nombres.Text & "%'"
        End If
        sql &= whereSql
        dtg_clientes.DataSource = objOp_simpesLn.listar_datatable(sql, "CORSAN")
    End Sub

    Private Sub cbo_vendedor_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbo_vendedor.SelectedIndexChanged
        If (carga_completa) Then
            txt_cliente.Text = ""
        End If
    End Sub
End Class