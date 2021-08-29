Imports logicaNegocios
Public Class Frm_fecha_entrega
    Private obj_op_simplesLn As New Op_simpesLn
    Private objOperacionesForm As New OperacionesFormularios
    Dim carga_comp As Boolean = False
    Dim dt_consulta As New DataTable
    Dim id_exixtente As Integer = 0

    Private Sub Frm_fecha_entrega_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        lbl_modificando.Text = ""
        cargar_ciudades()
        cbo_fecha.Value = Now
        Dim año = Now.Year
        While (año >= Now.Year - 5)
            cbo_ano.Items.Add(año)
            año -= 1
        End While
        cbo_ano.Text = Now.Year
        cbo_mes.SelectedIndex = Now.Month - 2
        cbo_fecha_ini.Value = Now.AddMonths(-1)
        cbo_fecha_ini.Value = cbo_fecha_ini.Value.AddDays(-Now.Day + 1)
        cbo_fecha_fin.Value = cbo_fecha_ini.Value.AddDays((DateSerial(Year(cbo_fecha_ini.Value), Month(cbo_fecha_ini.Value) + 1, 0).Day) - 1)
        Dim sql As String = "SELECT tipo FROM tipo_transacciones"
        cbo_tipo.DataSource = obj_op_simplesLn.listar_datatable(sql, "CORSAN")
        cbo_tipo.DisplayMember = "tipo"
        cbo_tipo.ValueMember = "tipo"
        cbo_tipo.SelectedValue = "FACT"
        carga_comp = True
    End Sub
    Private Sub buscar_tercero()
        Dim whereSql As String = "WHERE "
        Dim sql As String = ""

        If (tab_ppal.SelectedTab.Name = tab_ingreso.Name) Then
            If (txt_nombre.Text <> "") Then
                whereSql &= "nombres like '%" & txt_nombre.Text & "%'"
            ElseIf (txtNit.Text <> "") Then
                whereSql &= "nit like '" & txtNit.Text & "%'"
            End If
            sql = "SELECT nombres,nit FROM terceros " & whereSql
            dtg_transportador.DataSource = obj_op_simplesLn.listar_datatable(Sql, "CORSAN")
        ElseIf (tab_ppal.SelectedTab.Name = tab_consulta.Name) Then
            If (txt_nombres.Text <> "") Then
                whereSql &= "nombres like '%" & txt_nombres.Text & "%'"
            ElseIf (txt_nit_consult.Text <> "") Then
                whereSql &= "nit like '" & txt_nit_consult.Text & "%'"
            End If
            sql = "SELECT nombres,nit FROM terceros " & whereSql
            dtg_trasportador.DataSource = obj_op_simplesLn.listar_datatable(sql, "CORSAN")
        End If

    End Sub

    Private Sub dtg_clientes_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtg_transportador.CellClick
        If (e.RowIndex >= 0) Then
            carga_comp = False
            txtNit.Text = dtg_transportador.Item("nit", e.RowIndex).Value
            carga_comp = True
        End If
    End Sub

    Private Sub txt_nombre_TextChanged(sender As System.Object, e As System.EventArgs) Handles txt_nombre.TextChanged
        If (carga_comp) Then
            carga_comp = False
            txtNit.Text = ""
            carga_comp = False
            If (txt_nombre.Text <> "" And txt_nombre.Text.Length > 3) Then
                buscar_tercero()
            End If
            carga_comp = True
        End If
    End Sub

    Private Sub txtNit_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtNit.TextChanged
        If (carga_comp) Then
            carga_comp = False
            txt_nombre.Text = ""
            carga_comp = False
            If (txtNit.Text <> "" And txtNit.Text.Length > 3) Then
                buscar_tercero()
            End If
            carga_comp = True
        End If
    End Sub
    Private Sub guardar()
        If (validar()) Then
            Dim listSql As New List(Of Object)
            Dim mes As Integer = cbo_mes.SelectedIndex + 1
            Dim ano As Integer = cbo_ano.Text
            Dim Fec As String
            Dim numero As Double = txtNumero.Text
            Dim nit As Double = txtNit.Text
            Dim tipo As String = cbo_tipo.SelectedValue
            Dim sql As String
            If (id_exixtente <> 0) Then
                listSql.Add("DELETE FROM J_factura_fecha_entrega WHERE id = " & id_exixtente & " ")
            End If
            If (chk_sin_fecha.Checked) Then
                Dim sqlFecFact As String = "SELECT fecha FROM documentos WHERE numero = " & numero & " AND tipo = '" & tipo & "'"
                Dim dias_est As String = ""
                Dim sql_dias_est As String = "SELECT dias_estandar " & _
                                                "FROM y_ciudades " & _
                                                    "WHERE  ciudad = (SELECT y_ciudad FROM terceros WHERE nit = (SELECT nit FROM documentos WHERE numero =" & numero & " and tipo = 'FACT'))  " & _
                                                    "AND departamento = (SELECT y_dpto  FROM terceros  WHERE nit = (SELECT nit FROM documentos WHERE numero =" & numero & " and tipo = 'FACT')) "
                dias_est = obj_op_simplesLn.consultarVal(sql_dias_est)
                If (dias_est = "") Then
                    dias_est = 0
                End If
                Dim fec_fact As Date = obj_op_simplesLn.consultarVal(sqlFecFact)
                cbo_fecha.Value = fec_fact.AddDays(+dias_est)
                Dim dias_estandar As String = obj_op_simplesLn.consultarVal(sql_dias_est)
                Fec = obj_op_simplesLn.cambiarFormatoFecha(cbo_fecha.Value)
                sql = "INSERT INTO J_factura_fecha_entrega (tipo,numero,nit_transportador,fecha,sin_fecha,mes_flete,ano_flete) VALUES ('" & tipo & "'," & numero & "," & nit & ",'" & Fec & "','S'," & mes & "," & ano & ")"
                cbo_fecha.Value = Now
            Else
                Fec = obj_op_simplesLn.cambiarFormatoFecha(cbo_fecha.Value)
                sql = "INSERT INTO J_factura_fecha_entrega (tipo,numero,nit_transportador,fecha,mes_flete,ano_flete) VALUES ('" & tipo & "'," & numero & "," & nit & ",'" & Fec & "'," & mes & "," & ano & ")"
            End If
            listSql.Add(sql)
            If (obj_op_simplesLn.ExecuteSqlTransaction(listSql)) Then
                MessageBox.Show("El registro se guardo en forma exitosa!", "Exito!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                addDtg(tipo, numero, nit, Fec)
                nuevo()
            Else
                MessageBox.Show("Error al ingresar el registro, comuniquese con el area de sistemas", "Verifique!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub
    Private Sub nuevo()
        carga_comp = False
        id_exixtente = 0
        lbl_modificando.Text = ""
        txtNumero.Text = ""
        chk_sin_fecha.Checked = False
        carga_comp = True
    End Sub
    Private Function validarRegistro() As Boolean
        If (id_exixtente = 0) Then
            Dim nomb_existente As String = obj_op_simplesLn.consultarVal("Select t.nombres FROM J_factura_fecha_entrega j , terceros t WHERE t.nit = j.nit_transportador AND j.numero = " & txtNumero.Text & " And j.tipo = '" & cbo_tipo.SelectedValue & "'")
            Dim respuesta As Integer = 6
            If nomb_existente <> "" Then
                respuesta = MessageBox.Show("Esta factura esta asignada a: " & nomb_existente & ",desea ingresarla dupicada?", "Ingresar duplicada?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            End If
            If (respuesta) Then
                Return True
            Else
                Return False
            End If
        Else
            Return True
        End If
    End Function
    Private Function validar() As Boolean
        tab_ppal.SelectedTab = tab_ingreso
        If (cbo_ano.Text <> "Seleccione") Then
            If (cbo_mes.Text <> "Seleccione") Then
                If (cbo_tipo.Text <> "Seleccione") Then
                    If (txtNit.Text <> "") Then
                        If (txtNumero.Text <> "") Then
                            If obj_op_simplesLn.validarNitdes(txtNit.Text) Then
                                If (validarNumero()) Then
                                    If (validarRegistro()) Then
                                        Return True
                                    Else
                                        MessageBox.Show("Ya existe un registro para esta factura!", "Verifique!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    End If

                                Else
                                    MessageBox.Show("El numero de factura no existe!", "Verifique!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                End If
                            Else
                                MessageBox.Show("El nit del transportador no existe!", "Verifique!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End If
                        Else
                            MessageBox.Show("Digite un número de factura!", "Verifique!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    Else
                        MessageBox.Show("Digite un nit de transportador!", "Verifique!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Else
                    MessageBox.Show("Seleccione un tipo de transacción!", "Verifique!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                MessageBox.Show("Ingrese el mes para el flete", "Verifique!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            MessageBox.Show("Ingrese el año para el flete", "Verifique!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        Return False
    End Function
    Private Sub btn_guardar_Click(sender As System.Object, e As System.EventArgs) Handles btn_guardar.Click
        guardar()
    End Sub
    Private Function validarNumero() As Boolean
        Dim sql As String = "SELECT numero FROM documentos WHERE numero = " & txtNumero.Text & " AND tipo ='" & cbo_tipo.SelectedValue & "'"
        If (obj_op_simplesLn.consultarVal(sql) <> "") Then
            Return True
        Else
            Return False
        End If
    End Function
    Private Sub txtNumero_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumero.KeyPress
        soloNumero(e)
    End Sub
    Private Sub txt_num_fact_consulta_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txt_num_fact_consulta.KeyPress
        soloNumero(e)
    End Sub
    Private Sub txtNit_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtNit.KeyPress
        soloNumero(e)
    End Sub
    Private Sub btn_actualizar_Click(sender As System.Object, e As System.EventArgs) Handles btn_actualizar.Click
        dtg_consulta.DataSource = Nothing
        img_procesar.Visible = True
        Application.DoEvents()
        If (chk_consol_ciudad.Checked Or chk_consol_trans.Checked) Then
            dtg_consulta.Columns(col_modificar.Name).Visible = False
            consolidar()
        Else
            dtg_consulta.Columns(col_modificar.Name).Visible = True
            cargar_detalle()
        End If
        img_procesar.Visible = False
    End Sub
    Private Sub cargar_detalle()
        Dim tamano_letra As Single = 7.5!
        dtg_consulta.DataSource = Nothing
        dt_consulta = New DataTable
        tab_ppal.SelectedTab = tab_consulta
        Dim where_sql As String = ""
        Dim mes_ini As Double = cbo_fecha_ini.Value.Month
        Dim ano_ini As Double = cbo_fecha_ini.Value.Year
        Dim mes_fin As Double = cbo_fecha_fin.Value.Month
        Dim ano_fin As Double = cbo_fecha_fin.Value.Year
        Dim sql_conector As String = ""
        If (ano_ini <> ano_fin) Then
            sql_conector = "OR"
        Else
            sql_conector = "AND"
        End If
        If (txt_nit_consult.Text <> "") Then
            If (where_sql = "") Then
                where_sql = "WHERE "
            Else
                where_sql &= "AND "
            End If
            where_sql &= " nit_transportador = " & txt_nit_consult.Text & " "
        End If
        If (txt_num_fact_consulta.Text <> "") Then
            If (where_sql = "") Then
                where_sql = "WHERE "
            Else
                where_sql &= "AND "
            End If
            where_sql &= "numero = " & txt_num_fact_consulta.Text & " "
        Else
            For i = 0 To chk_ciudades.CheckedItems.Count - 1
                If (chk_ciudades.CheckedItems(i).ToString = "TODO") Then
                    i = chk_ciudades.CheckedItems.Count - 1
                Else
                    If (i = 0) Then
                        If (where_sql = "") Then
                            where_sql = "WHERE "
                        Else
                            where_sql &= "AND "
                        End If
                        where_sql &= " ciudad IN('" & chk_ciudades.CheckedItems(i).ToString & "'"
                    Else
                        where_sql &= ",'" & chk_ciudades.CheckedItems(i).ToString & "'"
                    End If
                    If (i = chk_ciudades.CheckedItems.Count - 1) Then
                        where_sql &= ") "
                    End If

                End If
            Next
            If (where_sql = "") Then
                where_sql = "WHERE "
            Else
                where_sql &= "AND "
            End If
            where_sql &= "((mes_flete >=" & mes_ini & " AND  ano_flete >=" & ano_ini & ") " & sql_conector & " (mes_flete <=" & mes_fin & " AND  ano_flete <=" & ano_fin & ")) "
            If chk_solo_urbanos.Checked Then
                Dim str_trans_urbanos As String = return_trans_urbanos()
                where_sql &= " AND nit_transportador IN (" & str_trans_urbanos & ") "
            Else
                If (chk_excluir_contado.Checked) Then
                    where_sql &= " AND condicion NOT IN (201,202,208,215,2012) "
                End If
                If (chk_excluir_sin_fecha.Checked) Then
                    where_sql &= " AND SF is null "
                End If
                If (chk_excluir_urbanos.Checked) Then
                    Dim str_trans_urbanos As String = return_trans_urbanos()
                    where_sql &= " AND nit_transportador NOT IN (" & str_trans_urbanos & ") "
                End If
            End If

        End If


        'Query con fecha del pedido descomentariar todo donde se encuentre fec_ped
        'Dim sql As String = "SELECT f.id,(CONVERT (varchar ,f.mes_flete )+ '-' + CONVERT (varchar ,f.ano_flete ))As mes_flete ,f.sin_fecha As SF,(SELECT nombres FROM terceros WHERE nit =  f.nit_transportador)As transportador,t.nit,t.nombres,t.ciudad ,d.numero,d.tipo,SUM (l.cantidad )As kilos,SUM (l.cantidad * l.valor_unitario)As valor_total,SUM (l.cantidad * l.costo_unitario)As costo_total,p.fecha As fec_ped,d.fecha As fec_fact,f.fecha As fec_recibido " & _
        '"FROM terceros t , documentos d , documentos_lin  l , J_factura_fecha_entrega f ,documentos_ped p " & _
        '      "WHERE f.anulado is null AND t.nit = d.nit And d.numero = l.numero And d.tipo = l.tipo And f.numero = d.numero And f.tipo = d.tipo And p.numero = d.documento " & whereFec & whereTransportador & whereNumFact & _
        '          "GROUP BY f.id,t.nit,t.nombres,t.ciudad ,d.numero,d.tipo,p.fecha,d.fecha, f.nit_transportador,f.fecha,f.sin_fecha,f.mes_flete,f.ano_flete  " & _
        '              "ORDER BY f.id"
        Dim sql As String = "SELECT id,y_ciudad,y_dpto,y_pais,mes_flete,ano_flete,mes_ano_flete ,SF, transportador,nit_transportador,nit,nombres,condicion as cond,ciudad,numero,tipo,kilos,valor_total,costo_total,fec_ped,fec_fact,fec_recibido,col_dias_fact,dias_est " & _
          "FROM J_factura_fecha_entrega_V   " & _
                 where_sql & _
                      "ORDER BY id"


        dt_consulta = obj_op_simplesLn.listar_datatable(sql, "CORSAN")
        dt_consulta.Columns.Add("col_dias_rec", GetType(Double))
        dt_consulta.Columns.Add("Tot_dias", GetType(Double))
        dt_consulta.Columns("dias_est").SetOrdinal(dt_consulta.Columns.Count - 1)
        ' dt_consulta.Columns.Add("col_dias_fact")

        calcularDias()
        dt_consulta.Rows.Add()
        dt_consulta.Rows(dt_consulta.Rows.Count - 1).Item("mes_ano_flete") = "TOTAL"
        Dim sum As Double = 0
        For j = 0 To dt_consulta.Columns.Count - 1
            If (dt_consulta.Columns(j).ColumnName = "Tot_dias" Or dt_consulta.Columns(j).ColumnName = "valor_total" Or dt_consulta.Columns(j).ColumnName = "costo_total" Or dt_consulta.Columns(j).ColumnName = "col_dias_fact" Or dt_consulta.Columns(j).ColumnName = "col_dias_rec" Or dt_consulta.Columns(j).ColumnName = "kilos" Or dt_consulta.Columns(j).ColumnName = "dias_est") Then
                For i = 0 To dt_consulta.Rows.Count - 2
                    If Not IsDBNull(dt_consulta.Rows(i).Item(j)) Then
                        sum += dt_consulta.Rows(i).Item(j)
                    End If
                Next
                dt_consulta.Rows(dt_consulta.Rows.Count - 1).Item(j) = sum
                If dt_consulta.Columns(j).ColumnName = "Tot_dias" Then
                    lbl_prom_total.Text = "Prom total: " & (sum / (dt_consulta.Rows.Count - 1)).ToString("N2")
                ElseIf dt_consulta.Columns(j).ColumnName = "col_dias_fact" Then
                    lbl_prom_ped_fact.Text = "Prom ped-fact: " & (sum / (dt_consulta.Rows.Count - 1)).ToString("N2")
                ElseIf dt_consulta.Columns(j).ColumnName = "col_dias_rec" Then
                    lbl_prom_fact_rec.Text = "Prom fact-recibido: " & (sum / (dt_consulta.Rows.Count - 1)).ToString("N2")
                End If
                sum = 0
            End If

        Next
        dtg_consulta.DataSource = dt_consulta
        pintar_sin_fec()
        dtg_consulta.Columns("mes_flete").Visible = False
        dtg_consulta.Columns("ano_flete").Visible = False
        dtg_consulta.Columns("y_ciudad").Visible = False
        dtg_consulta.Columns("y_dpto").Visible = False
        dtg_consulta.Columns("y_pais").Visible = False
        dtg_consulta.Columns("col_dias_fact").HeaderText = "Ped-Fact"
        dtg_consulta.Columns("col_dias_rec").HeaderText = "Fact-Recibido"
        dtg_consulta.Columns("fec_ped").DefaultCellStyle.Format = "d"
        dtg_consulta.Columns("fec_fact").DefaultCellStyle.Format = "d"
        dtg_consulta.Columns("fec_recibido").DefaultCellStyle.Format = "d"
        dtg_consulta.Columns("dias_est").DefaultCellStyle.Format = "N1"
        dtg_consulta.Columns("Tot_dias").DefaultCellStyle.Format = "N0"
        dtg_consulta.Columns("fec_recibido").ReadOnly = False
        dtg_consulta.Rows(dtg_consulta.Rows.Count - 1).DefaultCellStyle.BackColor = Color.Red
        dtg_consulta.Columns("Tot_dias").DefaultCellStyle = objOperacionesForm.formatoNegrita(tamano_letra)
    End Sub
    Private Function return_trans_urbanos() As String
        Dim dt_trans_urbanos As DataTable = obj_op_simplesLn.listar_datatable("SELECT nit FROM J_trasnportadores_urbanos", "CORSAN")
        Dim str_tras_urbanos As String = ""
        For i = 0 To dt_trans_urbanos.Rows.Count - 1
            If i <> 0 Then
                str_tras_urbanos &= ","
            End If
            str_tras_urbanos &= dt_trans_urbanos.Rows(i).Item("nit")
        Next
        Return str_tras_urbanos
    End Function
    Private Sub pintar_sin_fec()
        For i = 0 To dtg_consulta.Rows.Count - 1
            If Not IsDBNull(dtg_consulta.Item("SF", i).Value) Then
                dtg_consulta.Rows(i).DefaultCellStyle.BackColor = Color.Red
            End If
        Next
    End Sub
    Private Sub calcularDias()
        For i = 0 To dt_consulta.Rows.Count - 1
            If IsDate(dt_consulta.Rows(i).Item("fec_ped")) Then
                dt_consulta.Rows(i).Item("col_dias_fact") = (Convert.ToDateTime(dt_consulta.Rows(i).Item("fec_fact")) - Convert.ToDateTime(dt_consulta.Rows(i).Item("fec_ped"))).Days
            Else
                dt_consulta.Rows(i).Item("col_dias_fact") = 0
            End If
            dt_consulta.Rows(i).Item("col_dias_rec") = (Convert.ToDateTime(dt_consulta.Rows(i).Item("fec_recibido")) - Convert.ToDateTime(dt_consulta.Rows(i).Item("fec_fact"))).Days
            dt_consulta.Rows(i).Item("Tot_dias") = dt_consulta.Rows(i).Item("col_dias_fact") + dt_consulta.Rows(i).Item("col_dias_rec")
        Next
    End Sub
    Private Function anular(ByVal tipo As String, ByVal numero As Double) As Boolean
        Dim respuesta As Integer = MessageBox.Show("Esta seguro que desea borrar el flete?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        Dim resp As Boolean = False
        If (respuesta = 6) Then
            Dim sql As String = "DELETE J_factura_fecha_entrega WHERE numero = " & numero & " AND tipo ='" & tipo & "'"
            If (obj_op_simplesLn.ejecutar(sql, "CORSAN")) Then
                resp = True
            Else
                resp = False
            End If
        Else
            MessageBox.Show("Ingrese motivo de anulación", "Verifique!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        Return resp
    End Function
    Private Sub dtg_consulta_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtg_consulta.CellClick
        If (e.RowIndex >= 0) Then
            Dim col As String = dtg_consulta.Columns(e.ColumnIndex).Name
            If (col = col_borrar.Name) Then
                Dim numero As Double = dtg_consulta.Item("numero", e.RowIndex).Value
                Dim tipo As String = dtg_consulta.Item("tipo", e.RowIndex).Value
                If (anular(tipo, numero)) Then
                    MessageBox.Show("El registro se borro en forma exitosa!", "Exito!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    dtg_consulta.CurrentCell = Nothing
                    dtg_consulta.Rows(e.RowIndex).Visible = False
                Else
                    MessageBox.Show("Error al borrar el registro, comuniquese con el area de sistemas", "Verifique!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            ElseIf (col = col_modificar.Name) Then
                carga_comp = False
                lbl_modificando.Text = "Modificando id:" & dtg_consulta.Item("id", e.RowIndex).Value
                id_exixtente = dtg_consulta.Item("id", e.RowIndex).Value
                tab_ppal.SelectedTab = tab_ingreso
                cbo_mes.SelectedIndex = dtg_consulta.Item("mes_flete", e.RowIndex).Value - 1
                cbo_ano.Text = dtg_consulta.Item("ano_flete", e.RowIndex).Value
                cbo_tipo.SelectedValue = dtg_consulta.Item("tipo", e.RowIndex).Value
                txtNumero.Text = dtg_consulta.Item("numero", e.RowIndex).Value
                cbo_fecha.Value = dtg_consulta.Item("fec_recibido", e.RowIndex).Value
                txtNit.Text = dtg_consulta.Item("nit_transportador", e.RowIndex).Value
                txt_nombre.Text = dtg_consulta.Item("transportador", e.RowIndex).Value
                carga_comp = True
            End If
        End If
    End Sub
    Private Sub dtg_ingreso_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtg_ingreso.CellClick
        If (e.RowIndex >= 0) Then
            Dim col As String = dtg_ingreso.Columns(e.ColumnIndex).Name
            If (col = col_borrar_ingreso.Name) Then
                Dim numero As Double = dtg_ingreso.Item(col_numero.Name, e.RowIndex).Value
                Dim tipo As String = dtg_ingreso.Item(col_tipo.Name, e.RowIndex).Value
                If (anular(tipo, numero)) Then
                    MessageBox.Show("El registro se borro en forma exitosa!", "Exito!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    dtg_consulta.CurrentCell = Nothing
                    dtg_ingreso.Rows(e.RowIndex).Visible = False
                Else
                    MessageBox.Show("Error al borrar el registro, comuniquese con el area de sistemas", "Verifique!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        End If
    End Sub
    Private Sub addDtg(ByVal tipo As String, ByVal numero As Double, ByVal nit As Double, ByVal fec_entrega As String)
        dtg_ingreso.Rows.Add()
        Dim fila As Integer = dtg_ingreso.Rows.Count - 1
        dtg_ingreso.Item(col_numero.Name, fila).Value = numero
        dtg_ingreso.Item(col_nit_transportador.Name, fila).Value = nit
        dtg_ingreso.Item(col_nomb_transportador.Name, fila).Value = obj_op_simplesLn.consultarVal("SELECT nombres FROM terceros WHERE nit = " & nit)
        dtg_ingreso.Item(col_fecha_entrega.Name, fila).Value = fec_entrega
        dtg_ingreso.Item(col_tipo.Name, fila).Value = tipo
    End Sub


    Private Sub txt_nit_consult_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs)
        soloNumero(e)
    End Sub
    Private Sub btn_excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_excel.Click
        objOperacionesForm.ExportarDatosExcel(dtg_consulta, "Relacion fecha-pedido-facturación y entrega")
    End Sub

    Private Sub chk_sin_fecha_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chk_sin_fecha.CheckedChanged
        If (chk_sin_fecha.Checked) Then
            cbo_fecha.Enabled = False
        Else
            cbo_fecha.Enabled = True
        End If
    End Sub
    Private Sub Frm_pend_zona_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = 116 Then
            guardar()
        End If
    End Sub
    Private Sub cargar_ciudades()
        chk_ciudades.Items.Clear()
        Dim whereSql As String = "WHERE ter.concepto_1 = 04 "
        Dim orderSql As String = "ORDER BY ter.ciudad"
        Dim groupSql As String = "GROUP BY ter.ciudad "
        Dim sql As String = "SELECT ter.ciudad " & _
                                 "FROM terceros ter "
        sql &= whereSql & groupSql & orderSql
        Dim lista As New List(Of Object)
        lista = obj_op_simplesLn.lista(sql)
        For i As Integer = 0 To lista.Count - 1 Step 1
            If (i = 0) Then
                chk_ciudades.Items.Add("TODO")
            End If
            chk_ciudades.Items.Add(lista(i))
        Next
    End Sub

    Private Sub chk_consol_trans_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chk_consol_trans.CheckedChanged
          If (chk_consol_ciudad.Checked) Then
            txt_num_fact_consulta.Text = ""
        End If
    End Sub

    Private Sub chk_consol_ciudad_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chk_consol_ciudad.CheckedChanged
        If (chk_consol_ciudad.Checked) Then
            txt_num_fact_consulta.Text = ""
        End If
    End Sub
    Private Sub consolidar()
        Dim tamano_letra As Single = 7.5!
        Dim ocult_datos_ciudad As Boolean = False
        Dim sql As String = ""
        Dim dt As New DataTable
        Dim whereExcContado As String = ""
        Dim whereExcSf As String = ""
        Dim whereCiudad As String = ""
        Dim whereTransportador As String = ""

        Dim whereExcContadoSF As String = ""
        Dim whereExcSfSF As String = ""
        Dim whereExcTransUrbano As String = ""

        Dim mes_ini As Double = cbo_fecha_ini.Value.Month
        Dim ano_ini As Double = cbo_fecha_ini.Value.Year
        Dim mes_fin As Double = cbo_fecha_fin.Value.Month
        Dim ano_fin As Double = cbo_fecha_fin.Value.Year
        Dim sql_conector As String = ""
        'Se conecta para hacer el filtro perfecto de  ranto de fecha inicial y final
        If (ano_ini <> ano_fin) Then
            sql_conector = "OR"
        Else
            sql_conector = "AND"
        End If
        Dim whereFec As String = "WHERE ((vf.mes_flete >=" & mes_ini & " AND  vf.ano_flete >=" & ano_ini & " ) " & sql_conector & " (vf.mes_flete <=" & mes_fin & " AND  vf.ano_flete <=" & ano_fin & "))"

        If (txt_nit_consult.Text <> "") Then
            whereTransportador = " AND vf.nit_transportador = " & txt_nit_consult.Text & " "
        End If
        For i = 0 To chk_ciudades.CheckedItems.Count - 1
            If (chk_ciudades.CheckedItems(i).ToString = "TODO") Then
                i = chk_ciudades.CheckedItems.Count - 1
            Else
                If (i = 0) Then

                    whereCiudad &= " AND vf.ciudad IN('" & chk_ciudades.CheckedItems(i).ToString & "'"
                Else
                    whereCiudad &= ",'" & chk_ciudades.CheckedItems(i).ToString & "'"
                End If
                If (i = chk_ciudades.CheckedItems.Count - 1) Then
                    whereCiudad &= ") "
                End If

            End If
        Next
        If chk_solo_urbanos.Checked Then
            Dim str_trans_urbanos As String = return_trans_urbanos()
            whereExcTransUrbano &= " AND nit_transportador IN (" & str_trans_urbanos & ") "
        Else
            If (chk_excluir_contado.Checked) Then
                whereExcContado &= " AND vf.condicion NOT IN (201,202,208,215,2012) "
            End If
            If (chk_excluir_sin_fecha.Checked) Then
                whereExcSf &= " AND vf.SF is null "
            End If

            If (chk_excluir_contado.Checked) Then
                whereExcContadoSF &= " AND condicion NOT IN (201,202,208,215,2012) "
            End If
            If (chk_excluir_sin_fecha.Checked) Then
                whereExcSfSF &= " AND SF is null "
            End If
            If (chk_excluir_urbanos.Checked) Then
                Dim str_trans_urbanos As String = return_trans_urbanos()
                whereExcTransUrbano &= " AND nit_transportador NOT IN (" & str_trans_urbanos & ") "
            End If
        End If

        If (chk_consol_trans.Checked And chk_consol_ciudad.Checked) Then
            ocult_datos_ciudad = True
            item_mod_dias_est.Enabled = True
            sql = "SELECT vf.y_ciudad,vf.y_dpto,vf.y_pais,vf.ciudad,vf.nit_transportador,vf.transportador,SUM (vf.kilos )As kilos,SUM (vf.valor_total )As vr_total,SUM (vf.costo_total )As cto_total,AVG(vf.col_dias_fact )As p_d_entrega,SUM(vf.dias_est)As t_d_est,AVG(vf.dias_est)As dias_est,(SELECT COUNT (*)FROM J_v_fecha_fact_entrega WHERE vf.y_ciudad = y_ciudad AND vf.y_dpto = y_dpto AND vf.y_pais = y_pais   AND SF = 'S' AND vf.nit_transportador = nit_transportador AND ((mes_flete >=" & mes_ini & " AND ano_flete >= " & ano_ini & ") " & sql_conector & " (mes_flete <=" & mes_fin & " AND mes_flete <=" & ano_fin & ")) " & whereExcContadoSF & whereExcSfSF & whereCiudad & whereTransportador & ") As SF ,COUNT(*)As cant,SUM(vf.Ped_fact )As Ped_fact,SUM(vf.col_dias_fact )As Fact_ent " &
                    "FROM J_factura_fecha_entrega_V vf " &
                    whereFec & whereCiudad & whereTransportador & whereExcContado & whereExcSf & whereExcTransUrbano &
                    "GROUP BY    vf.nit_transportador,vf.transportador,vf.y_ciudad,vf.y_dpto,vf.y_pais,vf.ciudad   "
        ElseIf (chk_consol_trans.Checked) Then
            item_mod_dias_est.Enabled = False
            If (whereCiudad <> "") Then
                sql = "SELECT vf.nit_transportador,vf.transportador,SUM (vf.kilos )As kilos,SUM (vf.valor_total )As vr_total,SUM (vf.costo_total )As cto_total,AVG(vf.col_dias_fact )As p_d_entrega,SUM(vf.dias_est)As t_d_est,AVG(vf.dias_est)As dias_est,(SELECT COUNT (*)FROM J_v_fecha_fact_entrega WHERE  vf.y_ciudad = y_ciudad AND vf.y_dpto = y_dpto AND vf.y_pais = y_pais AND SF = 'S' AND vf.nit_transportador = nit_transportador AND ((mes_flete >=" & mes_ini & " AND ano_flete >= " & ano_ini & ") " & sql_conector & " (mes_flete <=" & mes_fin & " AND mes_flete <=" & ano_fin & "))" & whereExcContadoSF & whereExcSfSF & whereCiudad & whereTransportador & ") As SF ,COUNT(*)As cant,SUM(vf.Ped_fact )As Ped_fact,SUM(vf.col_dias_fact )As Fact_ent " &
                    "FROM J_factura_fecha_entrega_V vf " &
                    whereFec & whereCiudad & whereTransportador & whereExcContado & whereExcSf & whereExcTransUrbano &
                    "GROUP BY    vf.nit_transportador,vf.transportador,vf.ciudad ,vf.ciudad  ,vf.y_Ciudad,vf.y_dpto,vf.y_pais "
            Else
                sql = "SELECT vf.nit_transportador,vf.transportador,SUM (vf.kilos )As kilos,SUM (vf.valor_total )As vr_total,SUM (vf.costo_total )As cto_total,AVG(vf.col_dias_fact )As p_d_entrega,SUM(vf.dias_est)As t_d_est,AVG(vf.dias_est)As dias_est,(SELECT COUNT (*)FROM J_v_fecha_fact_entrega WHERE SF = 'S' AND vf.nit_transportador = nit_transportador AND ((mes_flete >=" & mes_ini & " AND ano_flete >= " & ano_ini & ") " & sql_conector & " (mes_flete <=" & mes_fin & " AND mes_flete <=" & ano_fin & "))" & whereExcContadoSF & whereExcSfSF & whereTransportador & ") As SF ,COUNT(*)As cant,SUM(vf.Ped_fact )As Ped_fact,SUM(vf.col_dias_fact )As Fact_ent " &
                    "FROM J_factura_fecha_entrega_V vf " &
                    whereFec & whereTransportador & whereExcContado & whereExcSf & whereExcTransUrbano &
                    "GROUP BY    vf.nit_transportador,vf.transportador  "
            End If

        Else
            ocult_datos_ciudad = True
            item_mod_dias_est.Enabled = True
            sql = "SELECT vf.ciudad,vf.y_ciudad,vf.y_dpto,vf.y_pais,SUM (vf.kilos )As kilos,SUM (vf.valor_total )As vr_total,SUM (vf.costo_total )As cto_total,AVG(vf.col_dias_fact )As p_d_entrega,SUM(vf.dias_est)As t_d_est,AVG(vf.dias_est)As dias_est,(SELECT COUNT (*)FROM J_v_fecha_fact_entrega WHERE vf.y_ciudad = y_ciudad AND vf.y_dpto = y_dpto AND vf.y_pais = y_pais AND SF = 'S'  AND  ((mes_flete >=" & mes_ini & " AND ano_flete >= " & ano_ini & ") " & sql_conector & " (mes_flete <=" & mes_fin & " AND mes_flete <=" & ano_fin & ")) " & whereExcContadoSF & whereExcSfSF & whereCiudad & whereTransportador & ") As SF ,COUNT(*)As cant,SUM(vf.Ped_fact )As Ped_fact,SUM(vf.col_dias_fact )As Fact_ent " &
                             "FROM J_factura_fecha_entrega_V vf " &
                             whereFec & whereCiudad & whereTransportador & whereExcContado & whereExcSf & whereExcTransUrbano &
                             "GROUP BY    vf.y_ciudad,vf.y_dpto,vf.y_pais,vf.ciudad   "
        End If
        dt = obj_op_simplesLn.listar_datatable(sql, "CORSAN")
        dt.Columns.Add("Tot_dias", GetType(Double))
        dt.Columns.Add("efic_entrega", GetType(Double))
        dt.Columns.Add("porc_(SF)", GetType(Double))
        For i = 0 To dt.Rows.Count - 1
            If (Not IsDBNull(dt.Rows(i).Item("Fact_ent")) And (Not IsDBNull(dt.Rows(i).Item("t_d_est")))) Then
                If (dt.Rows(i).Item("Fact_ent") > 0) Then
                    dt.Rows(i).Item("efic_entrega") = (dt.Rows(i).Item("t_d_est") / dt.Rows(i).Item("Fact_ent")) * 100
                End If
            End If
            If (Not IsDBNull(dt.Rows(i).Item("SF")) And (Not IsDBNull(dt.Rows(i).Item("cant")))) Then
                dt.Rows(i).Item("porc_(SF)") = (dt.Rows(i).Item("SF") / dt.Rows(i).Item("cant")) * 100
            End If
            If (IsNumeric(dt.Rows(i).Item("Ped_fact")) And (IsNumeric(dt.Rows(i).Item("Fact_ent")))) Then
                dt.Rows(i).Item("Tot_dias") = dt.Rows(i).Item("Ped_fact") + dt.Rows(i).Item("Fact_ent")
            End If
        Next

        dt.Rows.Add()
        dtg_consulta.DataSource = dt
        If (ocult_datos_ciudad) Then
            dtg_consulta.Columns("y_ciudad").Visible = False
            dtg_consulta.Columns("y_dpto").Visible = False
            dtg_consulta.Columns("y_pais").Visible = False
        End If
        dtg_consulta.Columns("efic_entrega").DefaultCellStyle.Format = "N2"
        dtg_consulta.Columns("porc_(SF)").DefaultCellStyle.Format = "N2"
        dtg_consulta.Columns("p_d_entrega").DefaultCellStyle.Format = "N1"
        If (chk_consol_ciudad.Checked And chk_consol_trans.Checked) Then
            dtg_consulta.Columns("dias_est").DefaultCellStyle.Format = "N1"
            dtg_consulta.Columns("t_d_est").DefaultCellStyle.Format = "N1"
        End If
        If Not (chk_consol_trans.Checked = True And chk_consol_ciudad.Checked = False) Then
            dtg_consulta.Columns("dias_est").DefaultCellStyle.Format = "N1"
        End If
        dtg_consulta.Rows(dtg_consulta.Rows.Count - 1).DefaultCellStyle.BackColor = Color.Red
        dtg_consulta.Columns("Tot_dias").DefaultCellStyle = objOperacionesForm.formatoNegrita(tamano_letra)
        pintar_efic_mas_cien()
        tot_consolidado()
    End Sub
    Private Sub pintar_efic_mas_cien()
        For i = 0 To dtg_consulta.Rows.Count - 2
            If Not IsDBNull(dtg_consulta.Item("efic_entrega", i).Value) Then
                If (dtg_consulta.Item("efic_entrega", i).Value.ToString <> "") Then
                    If (dtg_consulta.Item("efic_entrega", i).Value > 100) Then
                        dtg_consulta.Rows(i).DefaultCellStyle.BackColor = Color.YellowGreen
                    End If
                End If
            End If
        Next
    End Sub
    Private Sub tot_consolidado()
        Dim sum As Double = 0
        Dim col As String = ""
        For j = 0 To dtg_consulta.Columns.Count - 1
            If (dtg_consulta.Columns(j).Name = "Tot_dias" Or dtg_consulta.Columns(j).Name = "kilos" Or dtg_consulta.Columns(j).Name = "cto_total" Or dtg_consulta.Columns(j).Name = "vr_total" Or dtg_consulta.Columns(j).Name = "Ped_fact" Or dtg_consulta.Columns(j).Name = "Fact_ent" Or dtg_consulta.Columns(j).Name = "p_d_entrega" Or dtg_consulta.Columns(j).Name = "cant" Or dtg_consulta.Columns(j).Name = "dias_est" Or dtg_consulta.Columns(j).Name = "t_d_est" Or dtg_consulta.Columns(j).Name = "SF") Then
                col = dtg_consulta.Columns(j).Name
                For i = 0 To dtg_consulta.Rows.Count - 2
                    If Not IsDBNull(dtg_consulta.Item(col, i).Value) Then
                        If (dtg_consulta.Item(col, i).Value.ToString <> "") Then
                            sum += dtg_consulta.Item(col, i).Value
                        End If
                    End If
                Next
                If (dtg_consulta.Columns(j).Name = "p_d_entrega") Then
                    If (dtg_consulta.Rows.Count > 1) Then
                        sum = sum / dtg_consulta.Rows.Count
                    End If
                End If
                dtg_consulta.Item(col, dtg_consulta.Rows.Count - 1).Value = sum
                If dtg_consulta.Columns(j).Name = "Tot_dias" Then
                    lbl_prom_total.Text = "Prom total: " & Convert.ToDouble((sum / (dtg_consulta.Item("cant", dtg_consulta.RowCount - 1).Value))).ToString("N2")
                ElseIf dtg_consulta.Columns(j).Name = "Ped_fact" Then
                    lbl_prom_ped_fact.Text = "Prom ped-fact: " & Convert.ToDouble((sum / (dtg_consulta.Item("cant", dtg_consulta.RowCount - 1).Value))).ToString("N2")
                ElseIf dtg_consulta.Columns(j).Name = "Fact_ent" Then
                    lbl_prom_fact_rec.Text = "Prom fact-recibido: " & Convert.ToDouble((sum / (dtg_consulta.Item("cant", dtg_consulta.RowCount - 1).Value))).ToString("N2")
                End If
                sum = 0
            End If
        Next
        If (Not IsDBNull(dtg_consulta.Item("Fact_ent", dtg_consulta.Rows.Count - 1).Value) And (Not IsDBNull(dtg_consulta.Item("t_d_est", dtg_consulta.Rows.Count - 1).Value))) Then
            If (dtg_consulta.Item("Fact_ent", dtg_consulta.Rows.Count - 1).Value > 0) Then
                dtg_consulta.Item("efic_entrega", dtg_consulta.Rows.Count - 1).Value = (dtg_consulta.Item("t_d_est", dtg_consulta.Rows.Count - 1).Value / dtg_consulta.Item("Fact_ent", dtg_consulta.Rows.Count - 1).Value) * 100
            End If
        End If
        If (Not IsDBNull(dtg_consulta.Item("SF", dtg_consulta.Rows.Count - 1).Value) And (Not IsDBNull(dtg_consulta.Item("cant", dtg_consulta.Rows.Count - 1).Value))) Then
            If (dtg_consulta.Item("cant", dtg_consulta.Rows.Count - 1).Value > 0) Then
                dtg_consulta.Item("porc_(SF)", dtg_consulta.Rows.Count - 1).Value = (dtg_consulta.Item("SF", dtg_consulta.Rows.Count - 1).Value / dtg_consulta.Item("cant", dtg_consulta.Rows.Count - 1).Value) * 100
            End If
        End If
    End Sub

    Private Sub dtg_consulta_CellValueChanged(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtg_consulta.CellValueChanged
        If (carga_comp) Then
            If (dtg_consulta.Columns(e.ColumnIndex).Name = "fec_recibido") Then
                Dim respuesta As Integer = MessageBox.Show("Esta seguro que desea modificar la fecha de recibido?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                Dim resp As Boolean = False
                Dim id As Integer = dtg_consulta.Item("id", e.RowIndex).Value
                If (respuesta = 6) Then
                    If IsDate(obj_op_simplesLn.cambiarFormatoFecha(dtg_consulta.Item(e.ColumnIndex, e.RowIndex).Value)) Then
                        Dim fec_recibido As String = obj_op_simplesLn.cambiarFormatoFecha(dtg_consulta.Item(e.ColumnIndex, e.RowIndex).Value)
                        Dim sql As String = "UPDATE J_factura_fecha_entrega  SET fecha = '" & fec_recibido & "' WHERE id = " & id
                        If (obj_op_simplesLn.ejecutar(sql, "CORSAN")) Then
                            dtg_consulta.Item("col_dias_fact", e.RowIndex).Value = DateDiff(DateInterval.Day, dtg_consulta.Item("fec_fact", e.RowIndex).Value, dtg_consulta.Item("fec_recibido", e.RowIndex).Value)
                            resp = True
                        Else
                            resp = False
                        End If
                    Else
                        MessageBox.Show("Formato de fecha invalido,asegurece que sea AAAA-MM-DDD", "Verifique!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Else
                    Dim fec_ant As String = obj_op_simplesLn.consultarVal("SELECT fecha FROM J_factura_fecha_entrega WHERE id = " & id)
                    dtg_consulta.Item(e.ColumnIndex, e.RowIndex).Value = fec_ant
                End If
            End If
        End If

    End Sub
    Private Sub dtg_consulta_DataError(sender As System.Object, e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dtg_consulta.DataError

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
    Private Sub item_mod_dias_est_Opening(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles item_mod_dias_est.Click
        Dim y_dpto As Integer
        Dim y_pais As Integer
        Dim y_ciudad As String = ""
        Dim resp As String = ""
        Dim sql As String = ""
        y_dpto = dtg_consulta("y_dpto", dtg_consulta.CurrentCell.RowIndex).Value
        y_ciudad = dtg_consulta("y_ciudad", dtg_consulta.CurrentCell.RowIndex).Value
        y_pais = dtg_consulta("y_pais", dtg_consulta.CurrentCell.RowIndex).Value
        resp = InputBox("Ingrese días estandar para la ciudad: & " & dtg_consulta("ciudad", dtg_consulta.CurrentCell.RowIndex).Value & " ")

        If IsNumeric(resp) Then
            sql = "UPDATE y_ciudades SET dias_estandar = " & resp & " WHERE departamento =" & y_dpto & "  AND pais = " & y_pais & " AND ciudad =" & y_ciudad
            If (obj_op_simplesLn.ejecutar(sql, "CORSAN")) Then
                MessageBox.Show("La ciudad fue actualizada en forma correcta!", "Exito!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("El registro no fue actualizado, comuniquese con el administrador del sistema!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            MessageBox.Show("El valor ingresado debe ser númerico!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Private Sub txt_nit_consult_MouseClick(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles txt_nit_consult.MouseClick
        txt_nit_consult.Text = ""
        groupCliente.Visible = True
        txt_nombres.Focus()
    End Sub
    Private Sub txt_nit_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txt_nit_busc.KeyPress
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
    Private Sub txt_nit_TextChanged(sender As System.Object, e As System.EventArgs) Handles txt_nit_busc.TextChanged
        carga_comp = False
        txt_nombres.Text = ""
        carga_comp = True
        If (carga_comp And txt_nit_busc.Text.Length > 2) Then
            buscar_tercero()
        End If
    End Sub
    Private Sub txt_nombres_TextChanged(sender As System.Object, e As System.EventArgs) Handles txt_nombres.TextChanged
        carga_comp = False
        txt_nit_busc.Text = ""
        carga_comp = True
        If (carga_comp And txt_nombres.Text.Length > 3) Then
            buscar_tercero()
        End If
    End Sub
    Private Sub dtg_trasportador_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtg_trasportador.CellContentClick
        If (e.RowIndex >= 0) Then
            If (dtg_trasportador.Columns(e.ColumnIndex).Name = colOk.Name) Then
                txt_nit_consult.Text = ""
                txt_nit_consult.Text = dtg_trasportador.Item("nit", e.RowIndex).Value
                groupCliente.Visible = False
                dtg_trasportador.DataSource = Nothing
                txt_nit_busc.Text = ""
                txt_nombres.Text = ""
            End If
        End If
    End Sub

   

    Private Sub btn_cerrar_Click(sender As Object, e As EventArgs) Handles btn_cerrar.Click
        groupCliente.Visible = False
    End Sub

    Private Sub chk_solo_urbanos_CheckedChanged(sender As Object, e As EventArgs) Handles chk_solo_urbanos.CheckedChanged
        If chk_solo_urbanos.Checked Then
            chk_excluir_contado.Enabled = False
            chk_excluir_sin_fecha.Enabled = False
            chk_excluir_urbanos.Enabled = False
        Else
            chk_excluir_contado.Enabled = True
            chk_excluir_sin_fecha.Enabled = True
            chk_excluir_urbanos.Enabled = True
        End If
    End Sub
End Class