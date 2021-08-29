Imports logicaNegocios
Imports entidadNegocios
Public Class Frm_super_modulo_consult_recaudos
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
        Dim row As DataRow
        Dim dt As New DataTable
        Dim sql As String = ""
        Dim sql_condicion As String = "SELECT condicion FROM condiciones_pago "
        dt = objOpSimplesLn.listar_datatable(sql_condicion, "CORSAN")
        row = dt.NewRow
        row("condicion") = "TODOS"
        dt.Rows.Add(row)
        cboCondicion.DataSource = dt
        cboCondicion.ValueMember = "condicion"
        cboCondicion.DisplayMember = "condicion"
        cboCondicion.SelectedValue = "TODOS"
        carga_comp = True
    End Sub

    Private Sub Frm_super_modulo_consult_recaudosa_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        cbo_fecha_ini.Value = Now.AddDays(-(Now.Day - 1))
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
            whereVend = "AND vendedor in(" & vendedores & ")"
        ElseIf objUsuarioEn.Vendedor <> 1020 Then
            whereVend = "AND vendedor =" & objUsuarioEn.Vendedor
        Else
            whereVend = "AND vendedor >= 1001 and vendedor <= 1099"
        End If
        Dim sql_columnas As String = "SELECT  numero,vendedor,nit,nombres,(SELECT descripcion FROM y_departamentos WHERE departamento = y_dpto AND pais = y_pais) As departamento,ciudad,condicion,fecha,tipo,tipo_aplica,valor,descuento,total_rec,numero_aplica,fecha_aplica,fecha_cruce " &
                                        "FROM Jjv_Recaudos_consol  " &
                                            "WHERE nit = 1 "
        Dim sql_vendedores As String = "SELECT CAST(vendedor As varchar )+ '-' + nombre_vendedor As vendedor " & _
                                            "FROM v_vendedores " & _
                                              "WHERE vendedor >= 1001 and vendedor <= 1099 AND bloqueo = 0"
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
                If (dt.Columns(j).ColumnName = "valor" Or dt.Columns(j).ColumnName = "descuento" Or dt.Columns(j).ColumnName = "total_rec" Or dt.Columns(j).ColumnName = "Total_rec1") Then
                    For i = 0 To dt.Rows.Count - 3
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
                If (dtg_consulta.Columns(i).Name = "fecha" Or dtg_consulta.Columns(i).Name = "fecha_aplica" Or dtg_consulta.Columns(i).Name = "fecha_cruce") Then
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
        Dim sql_from As String = "FROM Jjv_Recaudos_consol "
        Dim sql_where As String = "WHERE fecha >='" & fec_ini & "' AND fecha <='" & fec_fin & "' "
        Dim sql_group As String = "GROUP BY "
        Dim columna_select As String = ""
        Dim columna_group As String = ""


        For i = 0 To chk_col_consol.CheckedItems.Count - 1
            If (chk_col_consol.CheckedItems(i).ToString = "valor" Or chk_col_consol.CheckedItems(i).ToString = "descuento" Or chk_col_consol.CheckedItems(i).ToString = "total_rec" Or chk_col_consol.CheckedItems(i).ToString = "Total_rec1") Then
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
                            If vendedores <> "" Then
                                sql_where &= "AND Vendedor IN(" & vendedores & ""
                            Else
                                sql_where &= "AND Vendedor IN('" & extraer_vendedor(ChkListvendedores.CheckedItems(i).ToString) & "'"
                            End If
                        Else
                            sql_where &= ",'" & extraer_vendedor(ChkListvendedores.CheckedItems(i).ToString) & "'"
                        End If
                        If (i = ChkListvendedores.CheckedItems.Count - 1) Then
                            sql_where &= ") "
                        End If

                    End If
                Next
            Else
                If vendedores <> "" Then
                    sql_where &= "AND Vendedor IN(" & vendedores & ")"
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
        If cboCondicion.SelectedValue <> "TODOS" Then
            sql_where &= " AND condicion = " & cboCondicion.SelectedValue & " "
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
        objOperacionesForm.ExportarDatosExcel(dtg_consulta, "Cartera")
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
    Private Function extraer_vendedor(ByVal cad_vendedor As String) As String
        Dim vendedor As String = ""
        cad_vendedor = cad_vendedor.Trim
        For i = 0 To cad_vendedor.Count - 1
            If cad_vendedor(i) = "-" Then
                i = cad_vendedor.Count
            Else
                vendedor &= cad_vendedor(i)
            End If
        Next
        Return vendedor
    End Function

End Class