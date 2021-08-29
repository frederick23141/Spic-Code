Imports logicaNegocios
Imports entidadNegocios
Public Class frm_control_orden_puas
    Dim puas_ent As New Puas_ordenEn
    Private objOpSimplesLn As New Op_simpesLn
    Dim dt As DataTable
    Dim nro_orden, cant_prog As Integer
    Dim nit As Double
    Dim cod_maquina As String
    Dim maquina, mat_prima, mat_prima2, producto, nom_oper, productoDes, mp1Des, mp2Des As String
    Public Sub main()
        TabControlPuas.SelectedTab = tab_maquinas
    End Sub
    Private Sub frm_control_orden_puas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargar_Nombres()
        TabControlPuas.SelectedTab = tab_maquinas
        cargar_cbo()
        tab_infor.Parent = Nothing
        tab_ordenes.Parent = Nothing
        tab_trab.Parent = Nothing
    End Sub
    Private Sub cargar_Nombres()
        Dim sql As String
        sql = "SELECT m.codigoM,m.Descripción,s.seccion  FROM J_maquinas m , D_seccion_maquina_puas s WHERE s.maquina = m.codigoM AND m.tipoMAquina = 4 ORDER BY m.codigoM"
        dt = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")
        lbl_maquina1.Text = dt.Rows(0).Item("Descripción")
        lbl_maquina2.Text = dt.Rows(1).Item("Descripción")
        lbl_maquina3.Text = dt.Rows(2).Item("Descripción")
        lbl_maquina4.Text = dt.Rows(3).Item("Descripción")
        lbl_maquina5.Text = dt.Rows(4).Item("Descripción")
        lbl_maquina6.Text = dt.Rows(5).Item("Descripción")
        lbl_maquina7.Text = dt.Rows(6).Item("Descripción")
        lbl_maquina8.Text = dt.Rows(7).Item("Descripción")
        lbl_maquina9.Text = dt.Rows(8).Item("Descripción")
        lbl_maquina10.Text = dt.Rows(9).Item("Descripción")
        lbl_maquina11.Text = dt.Rows(10).Item("Descripción")
        lbl_maquina12.Text = dt.Rows(11).Item("Descripción")
    End Sub
    Private Sub cant_registrada()
        Dim sql, reg As String
        sql = "SELECT count(nro_orden) FROM D_orden_prod_puas_producto WHERE nro_orden=" & nro_orden & "  and no_conforme is null and anular is null"
        reg = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")
        If reg <> "" Then
            lbl_cant_reg_r.Text = reg
        Else
            lbl_cant_reg_r.Text = ""
        End If
    End Sub
    Private Sub cargar_cbo()
        cbo_mes_trab.DataSource = objOpSimplesLn.returnDtMeses()
        cbo_mes_trab.ValueMember = "numMes"
        cbo_mes_trab.DisplayMember = "nombMes"
        cbo_mes_trab.SelectedValue = Now.Month
        For i = Now.Year - 1 To Now.Year + 1
            cbo_an_trab.Items.Add(i)
        Next
        cbo_an_trab.Text = Now.Year
    End Sub
    Private Sub cargar_ordenes(ByVal cod_maquina As String)
        If cbo_an_trab.Text = "Seleccione" Then
            cbo_an_trab.SelectedValue = Now.Year
        End If
        If cbo_mes_trab.Text = "Seleccione" Then
            cbo_mes_trab.SelectedValue = Now.Month
        End If
        Dim sql As String = "select o.cod_orden AS 'Nro',s.seccion,w.Descripción AS Maquina,o.prod_final AS PF,r.descripcion AS nom_PF,o.cant_prog,o.mat_prim AS MP,o.mat_prim2 AS MP2,o.nota,o.mes,o.ano,o.fecha_creacion " &
                            " from D_orden_prod_puas o, D_seccion_maquina_puas s, CORSAN.dbo.referencias r, J_Maquinas w " &
                            " WHERE o.maquina = s.maquina AND o.prod_final = r.codigo AND o.maquina = w.codigoM " &
                            " AND o.maquina=" & cod_maquina & "  AND year(o.fecha_creacion) = " & cbo_an_trab.Text & " AND month(o.fecha_creacion) = " & cbo_mes_trab.SelectedValue & "  and o.oculto=0  ORDER BY s.seccion"
        dtg_orden_trab.DataSource = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")
        dtg_orden_trab.Columns("seccion").DefaultCellStyle = formatoNegrita()
        dtg_orden_trab.Columns("seccion").Frozen = True
        dtg_orden_trab.Columns("Maquina").DefaultCellStyle = formatoNegrita()
        dtg_orden_trab.Columns("cant_prog").DefaultCellStyle.Format = "N0"


        For i = 0 To dtg_orden_trab.RowCount - 1
            Select Case dtg_orden_trab.Item("seccion", i).Value
                Case "Seccion A"
                    dtg_orden_trab.Item("seccion", i).Style.BackColor = Color.Violet
                Case "Seccion B"
                    dtg_orden_trab.Item("seccion", i).Style.BackColor = Color.OrangeRed
                Case "Seccion C"
                    dtg_orden_trab.Item("seccion", i).Style.BackColor = Color.Gold
                Case "Seccion D"
                    dtg_orden_trab.Item("seccion", i).Style.BackColor = Color.LightSeaGreen
            End Select
        Next
        dtg_orden_trab.Columns("fecha_creacion").Visible = False
        'pintar_operarios()
    End Sub
    Private Sub cargar_Pre_Orden(ByVal Puas_ent As Puas_ordenEn)
        nro_orden = Puas_ent.pnro
        maquina = Puas_ent.pmaquina
        mat_prima = Puas_ent.pmat_p
        mat_prima2 = Puas_ent.pmat_p2
        producto = Puas_ent.ppruducto
        cant_prog = Puas_ent.pcant_prog
        nom_oper = Puas_ent.pnoper
        nit = Puas_ent.pnit
        productoDes = Puas_ent.pproductoDes
        mp1Des = Puas_ent.pmat_pDes
        mp2Des = Puas_ent.pmat_p2Des
        lbl_orden_r.Text = nro_orden
        lbl_maquina_r.Text = maquina
        lbl_mat_p_r.Text = mp1Des
        lbl_mat_p2_r.Text = mp2Des
        lbl_producto_r.Text = productoDes
        lbl_cant_prog_r.Text = cant_prog
        lbl_operario_r.Text = nom_oper
        cant_registrada()
    End Sub
    Private Sub cargar_zona(ByVal puas_ent As Puas_ordenEn)
        puas_ent = puas_ent
        nro_orden = puas_ent.pnro
        maquina = puas_ent.pmaquina
        mat_prima = puas_ent.pmat_p
        producto = puas_ent.ppruducto
        cant_prog = puas_ent.pcant_prog
        nom_oper = puas_ent.pnoper
        nit = puas_ent.pnit
        mat_prima2 = puas_ent.pmat_p2
        'cargar_dtg_mp()
        cargar_producto(nro_orden)
    End Sub
    Public Sub cargar_dtg_mp()
        Dim dt As New DataTable
        Dim sql As String
        Dim real As String
        Dim lleva As String
        'sql = "SELECT nro_orden_galv as orden_galv ,nro_rollo_galv as rollo_galv ,peso FROM D_orden_prod_puas_mp WHERE nro_orden_puas=" & nro_orden_puas & ""
        'dt = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")
        'dtg_mp.DataSource = dt
        ''BALANCE DE MATERIA PRIMA
        sql = "SELECT peso_lleva FROM D_orden_prod_puas_cont_mp_prod WHERE codigo='" & mat_prima & "'"
        real = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")
        sql = "SELECT peso_lleva FROM D_orden_prod_puas_cont_mp_prod WHERE codigo='" & mat_prima2 & "'"
        lleva = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")
        lbl_mp1.Text = mat_prima & "(mp)"
        lblmp2.Text = mat_prima2 & "(mp2)"
        lbl_productof.Text = producto
        lbl_r_mp1.Text = real
        lbl_r_mp2.Text = lleva
    End Sub
    Public Sub cargar_producto(ByVal nro_orden_puas As Integer)
        Dim dt As New DataTable
        Dim reg, sql As String
        sql = "SELECT consecutivo_rollo,peso_real FROM D_orden_prod_puas_producto WHERE nro_orden=" & nro_orden_puas & " and no_conforme is null and anular is null order by consecutivo_rollo"
        dt = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")
        dtg_producto.DataSource = dt
        sql = "SELECT consecutivo_rollo,peso_prom FROM D_orden_prod_puas_producto WHERE nro_orden=" & nro_orden_puas & " and no_conforme is not null order by consecutivo_rollo"
        dt = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")
        dtg_nc.DataSource = dt
        sql = "SELECT count(nro_orden) FROM D_orden_prod_puas_producto WHERE nro_orden=" & nro_orden_puas & " and no_conforme is null and anular is null"
        reg = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")
        If reg <> "" Then
            lbl_producto_sal.Text = reg
        Else
            lbl_producto_sal.Text = ""
        End If
    End Sub
    Public Function decimal_Format(ByVal value As Double, ByVal decimales As Integer) As Double
        Dim aux_value As Double = Math.Pow(10, decimales)
        Return (Math.Truncate(value * aux_value) / aux_value)
    End Function
    Public Function formatoNegrita() As DataGridViewCellStyle
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold)
        Return DataGridViewCellStyle1
    End Function
    Public Sub pintar_operarios()
        Dim fecha As String = CDate(Now)
        Dim fecha_hora As String = objOpSimplesLn.cambiarFormatoFecha(Now)
        fecha_hora = CDate(fecha_hora & " 00:01:00")
        Dim fecha_6 As String = objOpSimplesLn.cambiarFormatoFecha(Now)
        fecha_6 = CDate(fecha_6 & " 05:45:00")
        Dim fecha_5_m As String = objOpSimplesLn.cambiarFormatoFecha(Now.AddDays(1))
        fecha_5_m = CDate(fecha_5_m & " 05:45:00")
        If CDate(fecha) >= CDate(fecha_6) And CDate(fecha) <= CDate(fecha_5_m) Then
            For Each Row As DataGridViewRow In dtg_orden_trab.Rows
                fecha_hora = CDate(fecha_hora).AddDays(1)
                If CDate(fecha) >= CDate(fecha_hora) Then
                    fecha_hora = CDate(fecha_hora).AddDays(-1)
                    If Not IsDBNull(Row.Cells("fecha_creacion").Value) Then
                        If Row.Cells("fecha_creacion").Value = fecha_hora Then
                            Row.DefaultCellStyle.BackColor = Color.GreenYellow
                        Else
                            Row.DefaultCellStyle.BackColor = Color.LightCoral
                        End If
                    Else
                        Row.DefaultCellStyle.BackColor = Color.LightCoral
                    End If
                Else
                    fecha_hora = objOpSimplesLn.cambiarFormatoFecha(Now)
                    fecha_hora = fecha_hora & " 00:00:00"
                    If Not IsDBNull(Row.Cells("fecha_creacion").Value) Then
                        If Row.Cells("fecha_creacion").Value = CDate(fecha_hora) Then
                            Row.DefaultCellStyle.BackColor = Color.GreenYellow
                        Else
                            Row.DefaultCellStyle.BackColor = Color.LightCoral
                        End If
                    Else
                        Row.DefaultCellStyle.BackColor = Color.LightCoral
                    End If
                End If
                If Row.Cells("PF").Value.Contains("33B") Or Row.Cells("PF").Value.Contains("33X") Or Row.Cells("PF").Value.Contains("33R") Then
                    Row.DefaultCellStyle.BackColor = Color.GreenYellow
                End If
            Next
        End If
    End Sub
    Private Sub dtg_orden_trab_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtg_orden_trab.CellClick
        If (e.RowIndex >= 0) Then
            If dtg_orden_trab.Rows(e.RowIndex).DefaultCellStyle.BackColor <> Color.LightCoral Then
                Dim col As String = dtg_orden_trab.Columns(e.ColumnIndex).Name
                If col = col_trabajar.Name Then
                    Dim nit As String
                    Dim mp2 As String
                    nit = InputBox("Introduzca el número de la cedula", "Nro cedula")
                    If IsNumeric(nit) Then
                        Dim consultar As String = "select nombres from V_nom_personal_Activo_con_maquila where nit in (select nit from control.dbo.D_empleados_sin_salida) and centro_planta=6400 and nit=" & nit & ""
                        Dim resultado = objOpSimplesLn.consultValorTodo(consultar, "CORSAN")
                        Dim val_control_real, val_control_lleva, sql As String

                        sql = "SELECT peso_real FROM D_orden_prod_puas_cont_mp_prod WHERE codigo='" & dtg_orden_trab.Item("MP", e.RowIndex).Value & "'"
                        val_control_real = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")
                        sql = "SELECT peso_lleva FROM D_orden_prod_puas_cont_mp_prod WHERE codigo='" & dtg_orden_trab.Item("MP", e.RowIndex).Value & "'"
                        val_control_lleva = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")
                        If IsDBNull(dtg_orden_trab.Item("MP2", e.RowIndex).Value) Then
                            mp2 = ""
                        Else
                            mp2 = dtg_orden_trab.Item("MP2", e.RowIndex).Value
                        End If
                        If resultado <> "" Then
                            Dim frm As New frm_control_orden_puas
                            Dim sql_des As String
                            Dim mp1des, mp2des, pfdesc As String
                            sql_des = "select descripcion from REFERENCIAS where codigo='" & dtg_orden_trab.Item("MP", e.RowIndex).Value & "'"
                            mp1des = dtg_orden_trab.Item("MP", e.RowIndex).Value & " " & objOpSimplesLn.consultValorTodo(sql_des, "CORSAN")
                            sql_des = "select descripcion from REFERENCIAS where codigo='" & mp2 & "'"
                            mp2des = mp2 & " " & objOpSimplesLn.consultValorTodo(sql_des, "CORSAN")
                            sql_des = "select descripcion from REFERENCIAS where codigo='" & dtg_orden_trab.Item("PF", e.RowIndex).Value & "'"
                            pfdesc = dtg_orden_trab.Item("PF", e.RowIndex).Value & " " & objOpSimplesLn.consultValorTodo(sql_des, "CORSAN")
                            Dim Puas_ent As Puas_ordenEn = New Puas_ordenEn(dtg_orden_trab.Item("Nro", e.RowIndex).Value,
                                              dtg_orden_trab.Item("cant_prog", e.RowIndex).Value, 0, nit, dtg_orden_trab.Item("Maquina", e.RowIndex).Value,
                                              dtg_orden_trab.Item("MP", e.RowIndex).Value, mp2, dtg_orden_trab.Item("PF", e.RowIndex).Value, resultado, pfdesc, mp1des, mp2des)
                            cargar_Pre_Orden(Puas_ent)
                            tab_infor.Parent = TabControlPuas
                            TabControlPuas.SelectedTab = tab_infor
                            'timer_MP.Enabled = True
                        Else
                            MessageBox.Show("El usuario no existe en el sistema", "Usuario no esta en el sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If
                    Else
                        MessageBox.Show("Debe ser numerico el dato de entrada", "Debe ser numerico", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                End If
            Else
                MessageBox.Show("No se puede trabajar ordenes que esten en color rojo! ", "Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
    End Sub
    Private Sub Btn_Atras_Maq_Click_1(sender As Object, e As EventArgs) Handles btn_Atras_Maq.Click
        tab_maquinas.Parent = TabControlPuas
        TabControlPuas.SelectedTab = tab_maquinas
    End Sub

    Private Sub Btn_Atras_ordenes_Click_1(sender As Object, e As EventArgs) Handles btn_Atras_ordenes.Click
        tab_ordenes.Parent = TabControlPuas
        TabControlPuas.SelectedTab = tab_ordenes
    End Sub
    Private Sub btn_maq1_Click(sender As Object, e As EventArgs) Handles btn_maq1.Click
        tab_ordenes.Parent = TabControlPuas
        cargar_ordenes(dt.Rows(0).Item("codigoM"))
        cod_maquina = dt.Rows(0).Item("codigoM")
        TabControlPuas.SelectedTab = tab_ordenes
    End Sub
    Private Sub btn_maq2_Click(sender As Object, e As EventArgs) Handles btn_maq2.Click
        tab_ordenes.Parent = TabControlPuas
        cargar_ordenes(dt.Rows(1).Item("codigoM"))
        cod_maquina = dt.Rows(1).Item("codigoM")
        TabControlPuas.SelectedTab = tab_ordenes
    End Sub
    Private Sub btn_maq3_Click(sender As Object, e As EventArgs) Handles btn_maq3.Click
        tab_ordenes.Parent = TabControlPuas
        cargar_ordenes(dt.Rows(2).Item("codigoM"))
        cod_maquina = dt.Rows(2).Item("codigoM")
        TabControlPuas.SelectedTab = tab_ordenes
    End Sub
    Private Sub btn_maq4_Click(sender As Object, e As EventArgs) Handles btn_maq4.Click
        tab_ordenes.Parent = TabControlPuas
        cargar_ordenes(dt.Rows(3).Item("codigoM"))
        cod_maquina = dt.Rows(3).Item("codigoM")
        TabControlPuas.SelectedTab = tab_ordenes
    End Sub
    Private Sub btn_maq5_Click(sender As Object, e As EventArgs) Handles btn_maq5.Click
        tab_ordenes.Parent = TabControlPuas
        cargar_ordenes(dt.Rows(4).Item("codigoM"))
        cod_maquina = dt.Rows(4).Item("codigoM")
        TabControlPuas.SelectedTab = tab_ordenes
    End Sub
    Private Sub btn_maq6_Click(sender As Object, e As EventArgs) Handles btn_maq6.Click
        tab_ordenes.Parent = TabControlPuas
        cargar_ordenes(dt.Rows(5).Item("codigoM"))
        cod_maquina = dt.Rows(5).Item("codigoM")
        TabControlPuas.SelectedTab = tab_ordenes
    End Sub
    Private Sub btn_maq7_Click(sender As Object, e As EventArgs) Handles btn_maq7.Click
        tab_ordenes.Parent = TabControlPuas
        cargar_ordenes(dt.Rows(6).Item("codigoM"))
        cod_maquina = dt.Rows(6).Item("codigoM")
        TabControlPuas.SelectedTab = tab_ordenes
    End Sub
    Private Sub btn_maq8_Click(sender As Object, e As EventArgs) Handles btn_maq8.Click
        tab_ordenes.Parent = TabControlPuas
        cargar_ordenes(dt.Rows(7).Item("codigoM"))
        cod_maquina = dt.Rows(7).Item("codigoM")
        TabControlPuas.SelectedTab = tab_ordenes
    End Sub

    Private Sub Btn_cargar_ordenes_Click_1(sender As Object, e As EventArgs) Handles btn_cargar_ordenes.Click
        cargar_ordenes(cod_maquina)
    End Sub
    Private Sub btn_maq9_Click(sender As Object, e As EventArgs) Handles btn_maq9.Click
        tab_ordenes.Parent = TabControlPuas
        cargar_ordenes(dt.Rows(8).Item("codigoM"))
        cod_maquina = dt.Rows(8).Item("codigoM")
        TabControlPuas.SelectedTab = tab_ordenes
    End Sub
    Private Sub IngresarParos_Click(sender As Object, e As EventArgs)
        Dim frm As New Frm_paros_puas
        frm.ShowDialog()
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs)
        Dim frm As New Frm_paros_puas
        frm.ShowDialog()
    End Sub
    Private Sub btn_inicio_Click(sender As Object, e As EventArgs) Handles btn_inicio.Click
        tab_maquinas.Parent = TabControlPuas
        TabControlPuas.SelectedTab = tab_maquinas
    End Sub

    Private Sub tst_mantenimiento_Click(sender As Object, e As EventArgs) Handles tst_mantenimiento.Click
        Dim frm As New Frm_Mantenimiento_Planta
        frm.Show()
    End Sub

    Private Sub btn_Atras_zona_Click(sender As Object, e As EventArgs) Handles btn_Atras_zona.Click
        tab_infor.Parent = TabControlPuas
        TabControlPuas.SelectedTab = tab_infor
    End Sub

    Private Sub tsanular_Click(sender As Object, e As EventArgs) Handles tsanular.Click
        Dim frm As New frm_anular_rollo_puas
        frm.main(nit, maquina, mat_prima, mat_prima2)
        frm.Show()
    End Sub

    Private Sub tsparo_Click(sender As Object, e As EventArgs) Handles tsparo.Click
        Dim frm As New Frm_paros_puas
        frm.ShowDialog()
    End Sub

    'Private Sub timer_MP_Tick(sender As Object, e As EventArgs) Handles timer_MP.Tick
    '    cargar_dtg_mp()
    'End Sub

    Private Sub btn_registrar_producto_Click(sender As Object, e As EventArgs) Handles btn_registrar_producto.Click
        'If validar_mp() Then
        Dim sql As String
        sql = "SELECT m.codigoM FROM J_maquinas m , D_seccion_maquina_puas s WHERE s.maquina = m.codigoM AND m.tipoMAquina = 4 and m.Descripción = '" & maquina & "'  ORDER BY m.codigoM"
        Dim codmq As String = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")
        Dim frm As New frm_reg_prod_f_puas
        frm.main(producto, nro_orden, nit, mat_prima, mat_prima2, maquina, codmq, Me)
        frm.ShowDialog()
        'tab_maquinas.Parent = TabControlPuas
        'TabControlPuas.SelectedTab = tab_maquinas
        'Else
        '    MessageBox.Show("Debe leer al menos un rollo de materia prima", "Leer materia prima", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        'End If
    End Sub

    Private Sub btn_trabajar_Click(sender As Object, e As EventArgs) Handles btn_trabajar.Click
        puas_ent.pnro = nro_orden
        puas_ent.pmaquina = maquina
        puas_ent.pmat_p2 = mat_prima2
        puas_ent.pmat_p = mat_prima
        puas_ent.ppruducto = producto
        puas_ent.pcant_prog = cant_prog
        puas_ent.pnoper = nom_oper
        puas_ent.pnit = nit
        cargar_zona(puas_ent)
        tab_trab.Parent = TabControlPuas
        TabControlPuas.SelectedTab = tab_trab
    End Sub

    Private Sub btn_maq10_Click(sender As Object, e As EventArgs) Handles btn_maq10.Click
        tab_ordenes.Parent = TabControlPuas
        cargar_ordenes(dt.Rows(9).Item("codigoM"))
        cod_maquina = dt.Rows(9).Item("codigoM")
        TabControlPuas.SelectedTab = tab_ordenes
    End Sub
    Private Sub btn_maq11_Click(sender As Object, e As EventArgs) Handles btn_maq11.Click
        tab_ordenes.Parent = TabControlPuas
        cargar_ordenes(dt.Rows(10).Item("codigoM"))
        cod_maquina = dt.Rows(10).Item("codigoM")
        TabControlPuas.SelectedTab = tab_ordenes
    End Sub
    Private Sub btn_maq12_Click(sender As Object, e As EventArgs) Handles btn_maq12.Click
        tab_ordenes.Parent = TabControlPuas
        cargar_ordenes(dt.Rows(11).Item("codigoM"))
        cod_maquina = dt.Rows(11).Item("codigoM")
        TabControlPuas.SelectedTab = tab_ordenes
    End Sub
    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControlPuas.SelectedIndexChanged
        If TabControlPuas.SelectedTab.Name = "tab_maquinas" Then
            tab_infor.Parent = Nothing
            tab_ordenes.Parent = Nothing
            tab_maquinas.Parent = TabControlPuas
            tab_trab.Parent = Nothing

        ElseIf TabControlPuas.SelectedTab.Name = "tab_ordenes" Then
            tab_maquinas.Parent = Nothing
            tab_infor.Parent = Nothing
            tab_trab.Parent = Nothing
            tab_ordenes.Parent = TabControlPuas
        ElseIf TabControlPuas.SelectedTab.Name = "tab_infor" Then
            tab_maquinas.Parent = Nothing
            tab_ordenes.Parent = Nothing
            tab_trab.Parent = Nothing
            tab_infor.Parent = TabControlPuas
        Else
            tab_maquinas.Parent = Nothing
            tab_ordenes.Parent = Nothing
            tab_infor.Parent = Nothing
            tab_trab.Parent = TabControlPuas
        End If
    End Sub

    'Private Sub btn_registrar_mat_prima_Click(sender As Object, e As EventArgs) Handles btn_registrar_mat_prima.Click
    '    Dim frm As New frm_reg_mp_puas
    '    frm.main(mat_prima, mat_prima2, nro_orden, nit, Me)
    '    frm.ShowDialog()
    '    'tab_maquinas.Parent = TabControl1
    '    'TabControl1.SelectedTab = tab_maquinas
    'End Sub
    'Private Function validar_mp()
    '    Dim resp As Boolean = False
    '    If dtg_mp.Rows.Count > 0 Then
    '        resp = True
    '    End If
    '    Return resp
    'End Function
End Class