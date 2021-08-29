Imports logicaNegocios
Imports entidadNegocios
Public Class Frm_super_modulo_consult_vtas
    Private objUsuarioLn As New UsuarioLn
    Private objOperacionesForm As New OperacionesFormularios
    Private objOpSimplesLn As New Op_simpesLn
    Dim carga_comp As Boolean = False
    Private objUsuarioEn As New UsuarioEn
    Dim vendedores As String = ""
    Dim calcular_participacion_kg As Boolean = False
    Dim calcular_participacion_valor As Boolean = False
    Public Sub Main(ByVal objUsuarioEn As UsuarioEn)
        Me.objUsuarioEn = objUsuarioEn
        vendedores = objUsuarioLn.coordinadorVend(objUsuarioEn.usuario)
        cargar_campos()
        cargar_ciudades()
        carga_comp = True
    End Sub

    Private Sub Frm_super_modulo_consult_vtas_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        cbo_fecha_ini.Value = Now.AddMonths(-1)
        cbo_fecha_fin.Value = Now
    End Sub

    Private Sub cargar_campos()
        Dim row As DataRow
        Dim dt_bodega As New DataTable
        Dim dt_departamento As New DataTable
        Dim sql_bodega As String = "SELECT CAST(bodega AS varchar(25))As bodega FROM Jjv_V_vtas_vend_cliente_ref GROUP BY bodega "
        Dim sql_departamento As String = "SELECT descripcion  + ' - ' +  CAST(departamento AS varchar(25)) As descripcion FROM y_departamentos WHERE departamento <> '.' ORDER BY descripcion "
        Dim sql_linea As String = "SELECT CAST(Id_cor AS varchar(25))As Id_cor, Descripcion FROM JJV_Grupos_seguimiento"
        Dim dt_linea As New DataTable
        dt_linea = objOpSimplesLn.listar_datatable(sql_linea, "CORSAN")
        For i = 0 To dt_linea.Rows.Count - 1
            If (i = 0) Then
                chkLinea.Items.Add("TODOS")
            End If
            chkLinea.Items.Add(dt_linea.Rows(i).Item("Descripcion"))
        Next

        dt_bodega = objOpSimplesLn.listar_datatable(sql_bodega, "CORSAN")
        row = dt_bodega.NewRow
        row("bodega") = "TODO"
        row("bodega") = "TODO"
        dt_bodega.Rows.Add(row)
        cbo_bodega.DataSource = dt_bodega
        cbo_bodega.ValueMember = "bodega"
        cbo_bodega.DisplayMember = "bodega"
        cbo_bodega.SelectedValue = "TODO"

        dt_departamento = objOpSimplesLn.listar_datatable(sql_departamento, "CORSAN")
        For i = 0 To dt_departamento.Rows.Count - 1
            If (i = 0) Then
                chk_departamentos.Items.Add("TODOS")
            End If
            chk_departamentos.Items.Add(dt_departamento.Rows(i).Item("descripcion"))
        Next


        Dim whereVend As String = ""
        If (vendedores <> "") Then
            whereVend = "AND vendedor in(" & vendedores & ")"
        ElseIf objUsuarioEn.Vendedor <> 1020 Then
            whereVend = "AND vendedor =" & objUsuarioEn.Vendedor
        Else
            whereVend = "AND vendedor >= 1001 and vendedor <= 1099"
        End If
        Dim sql_columnas As String = ""
        If objUsuarioEn.permiso.Trim <> "VENDEDOR" Then
            sql_columnas = "SELECT ano,mes,tipo,vendedor,numero,seq,(SELECT descripcion FROM y_departamentos WHERE departamento = y_dpto AND pais = y_pais) As departamento ,ciudad,fec,nit,nombres,condicion,telefono_1,direccion,bloqueo,codigo,descripcion,id_grupo_producto As grupo_producto,desc_id_cor As linea_prod,bodega,valor_unitario,valor_kilo,costo_unitario,costo_kilo ,Vr_total,Kilos,cantidad As Cantidad,Cto_total,(Vr_total-Cto_total)As Rnt,(Vr_total / Cto_total) / Cto_total * 100 As Porc_rnt, nit as presupuesto,pedido " &
                                            ",comercial AS grupo FROM Jjv_V_vtas_vend_cliente_ref  " &
                                                "WHERE nit = 1 "
        Else
            sql_columnas = "SELECT ano,mes,tipo,vendedor,numero,seq,(SELECT descripcion FROM y_departamentos WHERE departamento = y_dpto AND pais = y_pais) As departamento ,ciudad,fec,nit,nombres,condicion,telefono_1,direccion,bloqueo,codigo,descripcion,id_grupo_producto As grupo_producto,desc_id_cor As linea_prod,bodega,valor_unitario,valor_kilo,costo_unitario,costo_kilo ,Vr_total,Kilos,cantidad As Cantidad,Cto_total,(Vr_total-Cto_total)As Rnt,(Vr_total / Cto_total) / Cto_total * 100 As Porc_rnt, nit as presupuesto,pedido " &
                                            ",comercial AS grupo FROM Jjv_V_vtas_vend_cliente_ref  " &
                                                "WHERE nit = 1 "
        End If

        Dim sql_vendedores As String = "SELECT vendedor " &
                                        "FROM v_vendedores " &
                                            "WHERE vendedor >= 1001 AND vendedor <= 1099 " & whereVend & " "
        Dim dt_columnas As New DataTable
        Dim dt_vendedores As New DataTable
        dt_columnas = objOpSimplesLn.listar_datatable(sql_columnas, "CORSAN")
        dt_columnas.Columns.Add("Porc_part_kg")
        dt_columnas.Columns.Add("Porc_part_vr")
        dt_vendedores = objOpSimplesLn.listar_datatable(sql_vendedores, "CORSAN")
        For i = 0 To dt_columnas.Columns.Count - 1
            If (objUsuarioEn.permiso.Trim <> "ADMIN") Then
                If (dt_columnas.Columns(i).ColumnName <> "Rnt" And dt_columnas.Columns(i).ColumnName <> "Porc_rnt" And dt_columnas.Columns(i).ColumnName <> "Cto_total") Then
                    chk_col_consol.Items.Add(dt_columnas.Columns(i).ColumnName)
                End If
            Else
                chk_col_consol.Items.Add(dt_columnas.Columns(i).ColumnName)
            End If
        Next
        For i = 0 To dt_vendedores.Rows.Count - 1
            If (i = 0) Then
                ChkListvendedores.Items.Add("TODOS")
            End If
            ChkListvendedores.Items.Add(dt_vendedores.Rows(i).Item("vendedor"))
        Next

    End Sub

    Private Sub btn_actualizar_Click(sender As System.Object, e As System.EventArgs) Handles btn_actualizar.Click
        If (chk_col_consol.CheckedItems.Count > 0) Then
            Dim tamano_letra As Single = 9.0!
            imgProcesar.Visible = True
            Application.DoEvents()
            Dim sql As String = armarSqlConsulta()
            Dim dt As New DataTable
            Dim sum As Double = 0
            dt = objOpSimplesLn.listar_datatable(sql, "CORSAN")
            dt.Rows.Add()
            For j = 0 To dt.Columns.Count - 1
                If (dt.Columns(j).ColumnName = "Vr_total" Or dt.Columns(j).ColumnName = "Kilos" Or dt.Columns(j).ColumnName = "Cto_total" Or dt.Columns(j).ColumnName = "Cantidad" Or dt.Columns(j).ColumnName = "Rnt" Or dt.Columns(j).ColumnName = "presupuesto") Then
                    For i = 0 To dt.Rows.Count - 2
                        If Not IsDBNull(dt.Rows(i).Item(j)) Then
                            sum += dt.Rows(i).Item(j)
                        End If
                    Next
                    dt.Rows(dt.Rows.Count - 1).Item(j) = sum
                    sum = 0
                End If
            Next
            If calcular_participacion_kg Then
                dt.Columns.Add("Porc_part_kg", GetType(Double))
                calcular_porc_participacion("Kilos", "Porc_part_kg", dt)
            End If
            If calcular_participacion_valor Then
                dt.Columns.Add("Porc_part_vr", GetType(Double))
                calcular_porc_participacion("Vr_total", "Porc_part_vr", dt)
            End If
            dtg_consulta.DataSource = Nothing
            dtg_consulta.DataSource = dt
            dtg_consulta.Rows(dtg_consulta.Rows.Count - 1).DefaultCellStyle.BackColor = Color.Red
            dtg_consulta.Rows(dtg_consulta.Rows.Count - 1).DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
            For i = 0 To dtg_consulta.Columns.Count - 1
                If (dtg_consulta.Columns(i).Name = "fec") Then
                    dtg_consulta.Columns(i).DefaultCellStyle.Format = "d"
                ElseIf (dtg_consulta.Columns(i).Name = "Porc_rnt") Then
                    dtg_consulta.Columns(i).DefaultCellStyle.Format = "N2"
                ElseIf (dtg_consulta.Columns(i).Name = "Porc_part_kg" Or dtg_consulta.Columns(i).Name = "Porc_part_vr") Then
                    dtg_consulta.Columns(i).DefaultCellStyle = objOperacionesForm.formatoNegrita(tamano_letra)
                    dtg_consulta.Columns(i).DefaultCellStyle.Format = "N2"
                End If
            Next
            imgProcesar.Visible = False
        Else
            MessageBox.Show("Seleccione al menos 1 item a consolidar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
    Private Function armarSqlConsulta() As String
        calcular_participacion_kg = False
        calcular_participacion_valor = False
        Dim fec_ini As String = objOpSimplesLn.cambiarFormatoFecha(cbo_fecha_ini.Value)
        Dim fec_fin As String = objOpSimplesLn.cambiarFormatoFecha(cbo_fecha_fin.Value)
        Dim sql As String = ""
        Dim sql_select As String = "SELECT "
        Dim sql_from As String = "FROM Jjv_V_vtas_vend_cliente_ref "
        Dim sql_where As String = "WHERE fec >='" & fec_ini & "' AND fec <='" & fec_fin & "' "
        Dim sql_group As String = "GROUP BY "
        Dim orderSql As String = ""
        Dim columna_select As String = ""
        Dim columna_group As String = ""
        Dim desc_tabla As String = ""
        If verificar_col_check("presupuesto") Then
            desc_tabla = "v"
            sql_from &= desc_tabla & " "
        End If
        For i = 0 To chk_col_consol.CheckedItems.Count - 1
            If (chk_col_consol.CheckedItems(i).ToString = "Vr_total" Or chk_col_consol.CheckedItems(i).ToString = "Kilos" Or chk_col_consol.CheckedItems(i).ToString = "Cto_total" Or chk_col_consol.CheckedItems(i).ToString = "Cantidad") Then
                If desc_tabla <> "" Then
                    columna_select = "SUM( " & desc_tabla & "." & chk_col_consol.CheckedItems(i).ToString & ") As " & chk_col_consol.CheckedItems(i).ToString
                Else
                    columna_select = "SUM( " & chk_col_consol.CheckedItems(i).ToString & ") As " & chk_col_consol.CheckedItems(i).ToString
                End If
                columna_group = ""
                'ElseIf (chk_col_consol.CheckedItems(i).ToString = "presupuesto") Then
                '    If verificar_col_check("vendedor") Then
                '        columna_select = "AVG( " & chk_col_consol.CheckedItems(i).ToString & ") As " & chk_col_consol.CheckedItems(i).ToString
                '    Else
                '        columna_select = "AVG( " & chk_col_consol.CheckedItems(i).ToString & ") As " & chk_col_consol.CheckedItems(i).ToString
                '    End If
            ElseIf (chk_col_consol.CheckedItems(i).ToString = "Rnt") Then
                ',(Vr_total-Cto_total)As rnt,(Vr_total - Cto_total) / Vr_total * 100 As porc_rnt
                columna_select = "(SUM(Vr_total)-SUM(Cto_total))As Rnt"
                columna_group = ""
            ElseIf (chk_col_consol.CheckedItems(i).ToString = "valor_unitario" Or chk_col_consol.CheckedItems(i).ToString = "costo_unitario" Or chk_col_consol.CheckedItems(i).ToString = "costo_kilo" Or chk_col_consol.CheckedItems(i).ToString = "valor_kilo") Then
                If desc_tabla <> "" Then
                    columna_select = "AVG( " & desc_tabla & "." & chk_col_consol.CheckedItems(i).ToString & ") As " & chk_col_consol.CheckedItems(i).ToString
                Else
                    columna_select = "AVG( " & chk_col_consol.CheckedItems(i).ToString & ") As " & chk_col_consol.CheckedItems(i).ToString
                End If
                columna_group = ""
            ElseIf (chk_col_consol.CheckedItems(i).ToString = "Porc_rnt") Then
                columna_select = "(SELECT CASE WHEN SUM(Vr_total) =0 THEN 0 ELSE( (SUM(Vr_total) - SUM(Cto_total)) / SUM(Cto_total) * 100) END) As Porc_rnt "
                columna_group = ""
            ElseIf (chk_col_consol.CheckedItems(i).ToString = "Porc_part_kg") Then
                calcular_participacion_kg = True
                columna_group = ""
                columna_select = ""
            ElseIf (chk_col_consol.CheckedItems(i).ToString = "Porc_part_vr") Then
                calcular_participacion_valor = True
                columna_group = ""
                columna_select = ""
            Else
                If (chk_col_consol.CheckedItems(i).ToString = "linea_prod") Then
                    columna_select = "desc_id_cor"
                    columna_group = "desc_id_cor,orden"
                    orderSql = " ORDER BY orden "
                ElseIf (chk_col_consol.CheckedItems(i).ToString = "grupo_producto") Then
                    columna_select = "descripcion_grupo_producto"
                    columna_group = "descripcion_grupo_producto,id_grupo_producto"
                    orderSql = " ORDER BY id_grupo_producto "
                ElseIf (chk_col_consol.CheckedItems(i).ToString = "departamento") Then
                    columna_select = "(SELECT descripcion FROM y_departamentos WHERE departamento = y_dpto AND pais = y_pais) As departamento"
                    columna_group = "y_dpto,y_pais"
                Else
                    If desc_tabla <> "" Then
                        columna_select = desc_tabla & "." & chk_col_consol.CheckedItems(i).ToString
                        columna_group = desc_tabla & "." & chk_col_consol.CheckedItems(i).ToString
                    Else
                        columna_select = chk_col_consol.CheckedItems(i).ToString
                        columna_group = chk_col_consol.CheckedItems(i).ToString
                    End If
                End If
            End If
            If (i = 0) Then
                If (columna_group <> "") Then
                    sql_group &= "" & columna_group & ""
                End If
                sql_select &= "" & columna_select & ""
            Else
                If (columna_group <> "") Then
                    sql_group &= "," & columna_group & ""
                End If
                If columna_select <> "" Then
                    sql_select &= "," & columna_select & ""
                End If
            End If
            If (i = chk_col_consol.CheckedItems.Count - 1) Then
                sql_select &= " "
            End If
        Next
        If (txt_cliente.Text.Trim <> "") Then
            sql_where &= " AND nit =" & txt_cliente.Text
        Else

            If ChkListvendedores.CheckedItems.Count > 0 Then
                For i = 0 To ChkListvendedores.CheckedItems.Count - 1
                    If (ChkListvendedores.CheckedItems(i).ToString = "TODOS") Then
                        If vendedores <> "" Then
                            If objUsuarioEn.Vendedor <> 1020 Then
                                sql_where &= "AND Vendedor =" & objUsuarioEn.Vendedor & ""
                            Else
                                sql_where &= "AND Vendedor IN(" & vendedores & ")"
                            End If
                        ElseIf objUsuarioEn.Vendedor <> 1020 Then
                            sql_where &= "AND Vendedor =" & objUsuarioEn.Vendedor & ""
                        End If
                        i = ChkListvendedores.CheckedItems.Count - 1
                    Else
                        If (i = 0) Then
                            If chk_desligar.Checked Then
                                sql_where &= " AND nit IN (SELECT nit FROM terceros WHERE vendedor IN ('" & ChkListvendedores.CheckedItems(i).ToString & "'"
                            Else
                                sql_where &= "AND Vendedor IN('" & ChkListvendedores.CheckedItems(i).ToString & "'"
                            End If
                        Else
                            sql_where &= ",'" & ChkListvendedores.CheckedItems(i).ToString & "'"
                        End If
                        If (i = ChkListvendedores.CheckedItems.Count - 1) Then
                            If chk_desligar.Checked Then
                                sql_where &= ")) "
                            Else
                                sql_where &= ") "
                            End If
                        End If
                    End If
                Next
            Else
                If vendedores <> "" Then
                    sql_where &= "AND Vendedor IN(" & vendedores & ")"
                Else
                    If objUsuarioEn.Vendedor <> 1020 Then
                        sql_where &= "AND Vendedor =" & objUsuarioEn.Vendedor & ""
                    End If
                End If
            End If
            For i = 0 To chk_ciudades.CheckedItems.Count - 1
                If (chk_ciudades.CheckedItems(i).ToString = "TODO") Then
                    i = chk_ciudades.CheckedItems.Count - 1
                Else
                    If (i = 0) Then
                        sql_where &= "AND ciudad IN('" & chk_ciudades.CheckedItems(i).ToString & "'"
                    Else
                        sql_where &= ",'" & chk_ciudades.CheckedItems(i).ToString & "'"
                    End If
                    If (i = chk_ciudades.CheckedItems.Count - 1) Then
                        sql_where &= ") "
                    End If

                End If
            Next
        End If
        If (txt_cod_filtro.Text.Trim <> "") Then
            sql_where &= " AND codigo like'" & txt_cod_filtro.Text & "%' "
        ElseIf (chkLinea.CheckedItems.Count <> 0) Then
            For i = 0 To chkLinea.CheckedItems.Count - 1
                If (chkLinea.CheckedItems(i).ToString = "TODOS") Then
                    i = chkLinea.CheckedItems.Count - 1
                Else
                    If (i = 0) Then
                        If (sql_where = "WHERE ") Then
                            sql_where &= "desc_id_cor IN('" & chkLinea.CheckedItems(i).ToString & "'"
                        Else
                            sql_where &= "AND desc_id_cor IN('" & chkLinea.CheckedItems(i).ToString & "'"
                        End If
                    Else
                        sql_where &= ",'" & chkLinea.CheckedItems(i).ToString & "'"
                    End If
                    If (i = chkLinea.CheckedItems.Count - 1) Then
                        sql_where &= ") "
                    End If
                End If
            Next
        End If
        If (cbo_bodega.SelectedValue <> "TODO") Then
            sql_where &= " AND bodega = " & cbo_bodega.SelectedValue & " "
        End If
        If (chk_departamentos.CheckedItems.Count <> 0) Then
            Dim departamento As String = ""
            Dim separador_encontrado As Boolean = False
            For i = 0 To chk_departamentos.CheckedItems.Count - 1
                separador_encontrado = False
                departamento = ""
                If (chk_departamentos.CheckedItems(i).ToString = "TODOS") Then
                    i = chk_departamentos.CheckedItems.Count - 1
                Else
                    For k = 0 To chk_departamentos.CheckedItems(i).ToString.Length - 1
                        If (chk_departamentos.CheckedItems(i).ToString(k) = "-") Then
                            separador_encontrado = True
                        End If
                        If (separador_encontrado) Then
                            If IsNumeric(chk_departamentos.CheckedItems(i).ToString(k)) Then
                                departamento &= chk_departamentos.CheckedItems(i).ToString(k)
                            End If
                        End If
                    Next
                    If (i = 0) Then
                        If (sql_where = "WHERE ") Then
                            sql_where &= "y_dpto IN('" & departamento & "'"
                        Else
                            sql_where &= "AND y_dpto IN('" & departamento & "'"
                        End If
                    Else
                        sql_where &= ",'" & departamento & "'"
                    End If
                    If (i = chk_departamentos.CheckedItems.Count - 1) Then
                        sql_where &= ") "
                    End If
                End If
            Next
        End If
        sql = sql_select & sql_from & sql_where & sql_group & orderSql
        Dim sql_cantidades As String = "SELECT ano,mes, COUNT (DISTINCT (numero) ) As cant_fact , COUNT (DISTINCT (nit) ) As cant_nit,COUNT (DISTINCT (pedido) ) As cant_pedidos , SUM(kilos) As kilos , SUM(Vr_total ) As valor_total " & _
                                            "FROM Jjv_V_vtas_vend_cliente_ref " & _
                                                  sql_where & " AND tipo = 'FACT' " & _
                                                    "GROUP BY ano,mes "
        Dim sql_total_para_tipos_despachos As String = "SELECT ano,mes, numero, COUNT (DISTINCT (pedido) ) As cant_pedidos " & _
                                                            "FROM Jjv_V_vtas_vend_cliente_ref " & _
                                                                    sql_where & " AND tipo = 'FACT' " & _
                                                                          "GROUP BY numero, ano,mes "
        Dim dt_agregada As DataTable = objOpSimplesLn.listar_datatable(sql_cantidades, "CORSAN")
        dt_agregada.Columns.Add("desp_completos", GetType(Double))
        dt_agregada.Columns.Add("desp_parciales", GetType(Double))
        Dim dt_tipos_despachos As DataTable = objOpSimplesLn.listar_datatable(sql_total_para_tipos_despachos, "CORSAN")
        adicionar_tipos_despachos(dt_agregada, dt_tipos_despachos)
        dtg_agregada.DataSource = dt_agregada
        Return sql
    End Function
    Private Sub calcular_porc_participacion(ByVal tipo As String, ByVal nom_col_porcentaje As String, ByRef dt As DataTable)
        Dim total As Double = 0
        For j = 0 To dt.Columns.Count - 1
            If dt.Columns(j).ColumnName = tipo Then
                total = dt.Rows(dt.Rows.Count - 1).Item(tipo)
                For i = 0 To dt.Rows.Count - 1
                    dt.Rows(i).Item(nom_col_porcentaje) = (dt.Rows(i).Item(tipo) / total) * 100
                Next
            End If
        Next
    End Sub
    Private Sub adicionar_tipos_despachos(ByRef dt_agregada As DataTable, ByRef dt_tipos_despachos As DataTable)
        If dt_tipos_despachos.Rows.Count > 0 Then
            Dim cant_completos As Integer = 0
            Dim cant_parciales As Integer = 0
            For i = 0 To dt_tipos_despachos.Rows.Count - 1
                If IsNumeric(dt_tipos_despachos.Rows(i).Item("cant_pedidos")) Then
                    If dt_tipos_despachos.Rows(i).Item("cant_pedidos") = 1 Then
                        cant_completos += 1
                    Else
                        cant_parciales += 1
                    End If
                End If
            Next
            dt_agregada.Rows(dt_agregada.Rows.Count - 1).Item("desp_completos") = cant_completos
            dt_agregada.Rows(dt_agregada.Rows.Count - 1).Item("desp_parciales") = cant_parciales
        End If
    End Sub
    Private Function verificar_col_check(ByVal col As String) As Boolean
        For i = 0 To chk_col_consol.CheckedItems.Count - 1
            If chk_col_consol.CheckedItems(i).ToString = col Then
                Return True
            End If
        Next
        Return False
    End Function
    Private Sub txt_cliente_MouseClick(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles txt_cliente.MouseClick
        txt_cliente.Text = ""
        groupCliente.Visible = True
        txt_nombres.Focus()
    End Sub
    Private Sub btn_cerrar_Click(sender As System.Object, e As System.EventArgs) Handles btn_cerrar.Click
        txt_nit.Text = ""
        txt_nombres.Text = ""
        dtg_clientes.DataSource = Nothing
        groupCliente.Visible = False
    End Sub
    Private Sub cargar_clientes()
        Dim sql As String = "Select nit,nombres,ciudad FROM terceros "
        Dim whereSql As String = "WHERE (concepto_1 like '%3%' or concepto_1 like '%4%' or concepto_1 like '%9%') "
        If (txt_nit.Text <> "") Then
            whereSql &= " AND nit like '" & txt_nit.Text & "%'"
        ElseIf (txt_nombres.Text <> "") Then
            whereSql &= "AND nombres like '%" & txt_nombres.Text & "%'"
        End If
        If vendedores <> "" Then
            whereSql &= " AND vendedor IN (" & vendedores & ")"
        End If
        sql &= whereSql
        dtg_clientes.DataSource = objOpSimplesLn.listar_datatable(sql, "CORSAN")
    End Sub
    Private Sub dtg_clientes_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtg_clientes.CellContentClick
        If (e.RowIndex >= 0) Then
            If (dtg_clientes.Columns(e.ColumnIndex).Name = colOk.Name) Then
                txt_cliente.Text = ""
                txt_cliente.Text = dtg_clientes.Item("nit", e.RowIndex).Value
                groupCliente.Visible = False
                dtg_clientes.DataSource = Nothing
                txt_nit.Text = ""
                txt_nombres.Text = ""
            End If
        End If
    End Sub
    Private Sub txt_nit_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txt_nit.KeyPress
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
    Private Sub txt_nit_TextChanged(sender As System.Object, e As System.EventArgs) Handles txt_nit.TextChanged
        carga_comp = False
        txt_nombres.Text = ""
        carga_comp = True
        If (carga_comp And txt_nit.Text.Length > 2) Then
            cargar_clientes()
        End If
    End Sub
    Private Sub txt_nombres_TextChanged(sender As System.Object, e As System.EventArgs) Handles txt_nombres.TextChanged
        carga_comp = False
        txt_nit.Text = ""
        carga_comp = True
        If (carga_comp And txt_nombres.Text.Length > 3) Then
            cargar_clientes()
        End If
    End Sub
    Private Sub cargar_ciudades()
        If (carga_comp) Then
            chk_ciudades.Items.Clear()
            Dim whereSql As String = "WHERE ter.concepto_1 = 04 "
            Dim orderSql As String = "ORDER BY ter.ciudad"
            Dim groupSql As String = "GROUP BY ter.ciudad "
            Dim sql As String = "SELECT ter.ciudad " & _
                                     "FROM terceros ter "
            If (chk_departamentos.CheckedItems.Count <> 0) Then
                Dim departamento As String = ""
                Dim separador_encontrado As Boolean = False
                For i = 0 To chk_departamentos.CheckedItems.Count - 1
                    separador_encontrado = False
                    departamento = ""
                    If (chk_departamentos.CheckedItems(i).ToString = "TODOS") Then
                        i = chk_departamentos.CheckedItems.Count - 1
                    Else
                        For k = 0 To chk_departamentos.CheckedItems(i).ToString.Length - 1
                            If (chk_departamentos.CheckedItems(i).ToString(k) = "-") Then
                                separador_encontrado = True
                            End If
                            If (separador_encontrado) Then
                                If IsNumeric(chk_departamentos.CheckedItems(i).ToString(k)) Then
                                    departamento &= chk_departamentos.CheckedItems(i).ToString(k)
                                End If
                            End If
                        Next
                        If (i = 0) Then
                            If (whereSql = "WHERE ") Then
                                whereSql &= "y_dpto IN('" & departamento & "'"
                            Else
                                whereSql &= "AND y_dpto IN('" & departamento & "'"
                            End If
                        Else
                            whereSql &= ",'" & departamento & "'"
                        End If
                        If (i = chk_departamentos.CheckedItems.Count - 1) Then
                            whereSql &= ") "
                        End If
                    End If
                Next
            End If
            sql &= whereSql & groupSql & orderSql
            Dim lista As New List(Of Object)
            lista = objOpSimplesLn.lista(sql)
            For i As Integer = 0 To lista.Count - 1 Step 1
                If (i = 0) Then
                    chk_ciudades.Items.Add("TODO")
                End If
                chk_ciudades.Items.Add(lista(i))
            Next
        End If
    End Sub
    Private Sub btn_excel_Click(sender As System.Object, e As System.EventArgs) Handles btn_excel.Click
        objOperacionesForm.ExportarDatosExcel(dtg_consulta, "Ventas")
    End Sub
    Private Sub chkLinea_ItemCheck(sender As Object, e As ItemCheckEventArgs) Handles chkLinea.ItemCheck
        If (carga_comp) Then
            carga_comp = False
            txt_cod_filtro.Text = ""
            carga_comp = True
        End If
    End Sub

 
    Private Sub chk_departamentos_SelectedValueChanged(sender As Object, e As EventArgs) Handles chk_departamentos.SelectedValueChanged
        If carga_comp Then
            cargar_ciudades()
        End If
    End Sub

    Private Sub chk_desligar_CheckedChanged(sender As Object, e As EventArgs) Handles chk_desligar.CheckedChanged
        If chk_desligar.Checked Then
            MessageBox.Show("Se activo la opcion de desligar vendedores, tenga en cuando que no se tendra en cuenta el filtro de vendedores para su proxima consulta,TENGA EN CUENTA SE DEBE SELECCIONAR AL MENOS UN VENDEDOR.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
End Class