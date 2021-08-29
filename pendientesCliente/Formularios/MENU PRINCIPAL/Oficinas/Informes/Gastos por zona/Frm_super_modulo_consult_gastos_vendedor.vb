Imports logicaNegocios
Imports entidadNegocios
Public Class Frm_super_modulo_consult_gastos_vendedor
    Private objUsuarioLn As New UsuarioLn
    Private objOperacionesForm As New OperacionesFormularios
    Private objOpSimplesLn As New Op_simpesLn
    Dim carga_comp As Boolean = False
    Private objUsuarioEn As New UsuarioEn
    Dim vendedores As String = ""
    Public Sub Main(ByVal objUsuarioEn As UsuarioEn)
        Me.objUsuarioEn = objUsuarioEn
        vendedores = objUsuarioLn.coordinadorVend(objUsuarioEn.usuario)
        cargar_campos()
        cargar_ciudades()
        carga_comp = True
    End Sub

    Private Sub Frm_super_modulo_consult_gastos_vendedor_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        cbo_fecha_ini.Value = Now.AddMonths(-1)
        cbo_fecha_fin.Value = Now
    End Sub

    Private Sub cargar_campos()
        Dim dt_departamento As New DataTable
        Dim sql_departamento As String = "SELECT descripcion  + ' - ' +  CAST(departamento AS varchar(25)) As descripcion FROM y_departamentos WHERE departamento <> '.' ORDER BY descripcion "

        dt_departamento = objOpSimplesLn.listar_datatable(sql_departamento, "CORSAN")
        For i = 0 To dt_departamento.Rows.Count - 1
            If (i = 0) Then
                chk_departamentos.Items.Add("TODOS")
            End If
            chk_departamentos.Items.Add(dt_departamento.Rows(i).Item("descripcion"))
        Next


        Dim whereVend As String = ""
        If (vendedores <> "") Then
            whereVend = "AND v.vendedor in(" & vendedores & ")"
        End If
        Dim sql_columnas As String = "SELECT vendedor,fecha,tipo,numero,desc_zona,desc_departamento,cuenta,desc_cuenta,centro,desc_centro,nit,nombres,valor,explicacion  " & _
                                        "FROM J_v_gastos_vend_zona  " & _
                                            "WHERE nit = 1 "
        Dim sql_vendedores As String = "SELECT CAST(v.vendedor As varchar )+ '-' + v.nombre_vendedor As vendedor " & _
                                            "FROM v_vendedores v , J_v_gastos_vend_zona c " & _
                                                "WHERE c.vendedor = v.vendedor " & whereVend & " " & _
                                                    "group by v.vendedor,v.nombre_vendedor " & _
                                                        "ORDER BY v.vendedor "
        Dim dt_columnas As New DataTable
        Dim dt_vendedores As New DataTable
        dt_columnas = objOpSimplesLn.listar_datatable(sql_columnas, "CORSAN")
        dt_vendedores = objOpSimplesLn.listar_datatable(sql_vendedores, "CORSAN")
        For i = 0 To dt_columnas.Columns.Count - 1
            chk_col_consol.Items.Add(dt_columnas.Columns(i).ColumnName)
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
            imgProcesar.Visible = True
            Application.DoEvents()
            Dim sql As String = armarSqlConsulta()
            Dim dt As New DataTable
            Dim sum As Double = 0
            dt = objOpSimplesLn.listar_datatable(sql, "CORSAN")
            dt.Rows.Add()
            For j = 0 To dt.Columns.Count - 1
                If (dt.Columns(j).ColumnName = "valor") Then
                    For i = 0 To dt.Rows.Count - 2
                        If Not IsDBNull(dt.Rows(i).Item(j)) Then
                            sum += dt.Rows(i).Item(j)
                        End If
                    Next
                    dt.Rows(dt.Rows.Count - 1).Item(j) = sum
                    sum = 0
                End If
            Next
            dtg_consulta.DataSource = Nothing
            dtg_consulta.DataSource = dt
            dtg_consulta.Rows(dtg_consulta.Rows.Count - 1).DefaultCellStyle.BackColor = Color.Red
            dtg_consulta.Rows(dtg_consulta.Rows.Count - 1).DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
            For i = 0 To dtg_consulta.Columns.Count - 1
                If (dtg_consulta.Columns(i).Name = "fecha") Then
                    dtg_consulta.Columns(i).DefaultCellStyle.Format = "d"
                End If
            Next
            imgProcesar.Visible = False
        Else
            MessageBox.Show("Seleccione al menos 1 item a consolidar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
    Private Function armarSqlConsulta() As String
        Dim fec_ini As String = objOpSimplesLn.cambiarFormatoFecha(cbo_fecha_ini.Value)
        Dim fec_fin As String = objOpSimplesLn.cambiarFormatoFecha(cbo_fecha_fin.Value)
        Dim sql As String = ""
        Dim sql_select As String = "SELECT "
        Dim sql_from As String = "FROM J_v_gastos_vend_zona "
        Dim sql_where As String = "WHERE fecha >='" & fec_ini & "' AND fecha <='" & fec_fin & "' "
        Dim sql_where_vencimeinto As String = ""
        Dim sql_group As String = "GROUP BY "
        Dim columna_select As String = ""
        Dim columna_group As String = ""
        Dim sin_vencer As Boolean = False


        For i = 0 To chk_col_consol.CheckedItems.Count - 1
            If (chk_col_consol.CheckedItems(i).ToString = "valor") Then
                columna_select = "SUM( " & chk_col_consol.CheckedItems(i).ToString & ") As " & chk_col_consol.CheckedItems(i).ToString
                columna_group = ""
            Else
                If (chk_col_consol.CheckedItems(i).ToString = "departamento") Then
                    columna_select = "(SELECT descripcion FROM y_departamentos WHERE departamento = y_dpto AND pais = y_pais) As departamento"
                    columna_group = "y_dpto,y_pais"
                Else
                    columna_select = chk_col_consol.CheckedItems(i).ToString
                    columna_group = chk_col_consol.CheckedItems(i).ToString
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
                sql_select &= "," & columna_select & ""
            End If
            If (i = chk_col_consol.CheckedItems.Count - 1) Then
                sql_select &= " "
            End If

        Next
        If sql_where_vencimeinto <> "" Then
            sql_where_vencimeinto &= ") "
            sql_where &= sql_where_vencimeinto
        End If
        If (txt_cliente.Text.Trim <> "") Then
            sql_where &= " AND nit =" & txt_cliente.Text
        Else
            If ChkListvendedores.CheckedItems.Count > 0 Then
                For i = 0 To ChkListvendedores.CheckedItems.Count - 1
                    If (ChkListvendedores.CheckedItems(i).ToString = "TODOS") Then
                        If vendedores <> "" Then
                            sql_where &= "AND Vendedor IN(" & vendedores & ")"
                        End If
                        i = ChkListvendedores.CheckedItems.Count - 1
                    Else
                        If (i = 0) Then
                            sql_where &= "AND Vendedor IN('" & extraer_dato(ChkListvendedores.CheckedItems(i).ToString) & "'"
                        Else
                            sql_where &= ",'" & extraer_dato(ChkListvendedores.CheckedItems(i).ToString) & "'"
                        End If
                        If (i = ChkListvendedores.CheckedItems.Count - 1) Then
                            sql_where &= ") "
                        End If

                    End If
                Next
            Else
                If vendedores <> "" Then
                    sql_where &= "AND vendedor IN(" & vendedores & ")"
                End If
            End If
            For i = 0 To chk_zonas.CheckedItems.Count - 1
                If (chk_zonas.CheckedItems(i).ToString = "TODO") Then
                    i = chk_zonas.CheckedItems.Count - 1
                Else
                    If (i = 0) Then
                        sql_where &= "AND id_zona IN('" & extraer_dato(chk_zonas.CheckedItems(i).ToString) & "'"
                    Else
                        sql_where &= ",'" & extraer_dato(chk_zonas.CheckedItems(i).ToString) & "'"
                    End If
                    If (i = chk_zonas.CheckedItems.Count - 1) Then
                        sql_where &= ") "
                    End If

                End If
            Next
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
        sql = sql_select & sql_from & sql_where & sql_group
        Return sql
    End Function
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
        ' Dim whereSql As String = "WHERE (concepto_1 like '%3%' or concepto_1 like '%4%' or concepto_1 like '%9%') "
        Dim whereSql As String = "WHERE "
        If (txt_nit.Text <> "") Then
            whereSql &= "  nit like '" & txt_nit.Text & "%'"
        ElseIf (txt_nombres.Text <> "") Then
            whereSql &= " nombres like '%" & txt_nombres.Text & "%'"
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
        chk_zonas.Items.Clear()
        Dim whereSql As String = "WHERE y.departamento = z.departamento  "
        Dim orderSql As String = "ORDER BY z.descripcion"

        Dim sql As String = "SELECT CAST(z.id_zona As varchar) + '-' + z.descripcion + ' * ' + y.descripcion As descripcion " & _
                                 "FROM J_zonas_ventas z , y_departamentos y "
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
                            whereSql &= "z.departamento IN('" & departamento & "'"
                        Else
                            whereSql &= "AND z.departamento IN('" & departamento & "'"
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
        sql &= whereSql & orderSql
        Dim lista As New List(Of Object)
        lista = objOpSimplesLn.lista(sql)
        For i As Integer = 0 To lista.Count - 1 Step 1
            If (i = 0) Then
                chk_zonas.Items.Add("TODO")
            End If
            chk_zonas.Items.Add(lista(i))
        Next
    End Sub
    Private Sub btn_excel_Click(sender As System.Object, e As System.EventArgs) Handles btn_excel.Click
        objOperacionesForm.ExportarDatosExcel(dtg_consulta, "Costos por zona")
    End Sub
    Private Sub chkLinea_ItemCheck(sender As Object, e As ItemCheckEventArgs)
        If (carga_comp) Then
            carga_comp = False
            carga_comp = True
        End If
    End Sub


    Private Sub chk_departamentos_SelectedValueChanged(sender As Object, e As EventArgs) Handles chk_departamentos.SelectedValueChanged
        If carga_comp Then
            cargar_ciudades()
        End If
    End Sub
    Private Function extraer_dato(ByVal cad_dato As String) As String
        Dim dato As String = ""
        cad_dato = cad_dato.Trim
        For i = 0 To cad_dato.Count - 1
            If cad_dato(i) = "-" Then
                i = cad_dato.Count
            Else
                dato &= cad_dato(i)
            End If
        Next
        Return dato
    End Function

End Class