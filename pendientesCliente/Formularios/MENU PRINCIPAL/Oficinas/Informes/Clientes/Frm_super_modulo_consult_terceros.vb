Imports logicaNegocios
Imports entidadNegocios
Public Class Frm_super_modulo_consult_terceros
    Private objUsuarioLn As New UsuarioLn
    Private objOperacionesForm As New OperacionesFormularios
    Private objOpSimplesLn As New Op_simpesLn
    Dim carga_comp As Boolean = False
    Private objUsuarioEn As New UsuarioEn
    Dim fila_select As Integer = 0
    Dim vendedores As String = ""
    Public Sub Main(ByVal objUsuarioEn As UsuarioEn)
        Me.objUsuarioEn = objUsuarioEn
        vendedores = objUsuarioLn.coordinadorVend(objUsuarioEn.usuario)
        cargar_campos()
        carga_comp = True
        cargar_ciudades()
    End Sub

    Private Sub Frm_super_modulo_consult_terceros_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load


    End Sub

    Private Sub cargar_campos()
        dtg_tipo.DataSource = objOpSimplesLn.listar_datatable("SELECT concepto_2,descripcion FROM terceros_2", "CORSAN")
        Dim dt_departamento As New DataTable
        Dim sql_departamento As String = "SELECT descripcion  + ' - ' +  CAST(departamento AS varchar(25)) As descripcion FROM y_departamentos WHERE departamento <> '.' ORDER BY descripcion "
        dt_departamento = objOpSimplesLn.listar_datatable(sql_departamento, "CORSAN")
        Dim sql_tipo_tercero As String = "SELECT concepto_2,descripcion FROM terceros_2 "
        Dim dt_tipo_tercero As DataTable = objOpSimplesLn.listar_datatable(sql_tipo_tercero, "CORSAN")
        For i = 0 To dt_departamento.Rows.Count - 1
            If (i = 0) Then
                chk_departamentos.Items.Add("TODOS")
            End If
            chk_departamentos.Items.Add(dt_departamento.Rows(i).Item("descripcion"))
        Next

        Dim vendedores As String = objUsuarioLn.coordinadorVend(objUsuarioEn.usuario)
        Dim whereVend As String = ""
        If (vendedores <> "") Then
            whereVend = " vendedor in(" & vendedores & ")"
        Else
            whereVend = " vendedor >= 1001 and vendedor <= 1099"
        End If
        Dim sql_columnas As String = "SELECT vendedor,(SELECT descripcion FROM y_departamentos WHERE departamento = y_dpto AND pais = y_pais) As departamento,ciudad ,nit,nombres,direccion,telefono_1,bloqueo,concepto_2 As tipo_tercero ,mail,cupo_credito,condicion,fecha_creacion " & _
                                        "FROM  terceros   " & _
                                            "WHERE nit = 1 "
        Dim sql_vendedores As String = "SELECT vendedor " & _
                                        "FROM terceros  " & _
                                        "WHERE " & whereVend & " " & _
                                           "GROUP BY vendedor"
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
        For i = 0 To dt_tipo_tercero.Rows.Count - 1
            If (i = 0) Then
                chk_tipo_tercero.Items.Add("TODOS")
            End If
            chk_tipo_tercero.Items.Add(dt_tipo_tercero.Rows(i).Item("descripcion"))
        Next

    End Sub

    Private Sub btn_actualizar_Click(sender As System.Object, e As System.EventArgs) Handles btn_actualizar.Click
        If (chk_col_consol.CheckedItems.Count > 0) Then
            imgProcesar.Visible = True
            itemMod.Enabled = False
            Application.DoEvents()
            Dim sql As String = armarSqlConsulta()
            Dim dt As New DataTable
            dt = objOpSimplesLn.listar_datatable(sql, "CORSAN")
            dtg_consulta.DataSource = Nothing
            dtg_consulta.DataSource = dt
            For i = 0 To dtg_consulta.Columns.Count - 1
                If (dtg_consulta.Columns(i).Name = "fecha_creacion") Then
                    dtg_consulta.Columns(i).DefaultCellStyle.Format = "d"
                End If
            Next
            imgProcesar.Visible = False
        Else
            MessageBox.Show("Seleccione al menos 1 item a consolidar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
    Private Function armarSqlConsulta() As String
        Dim sql As String = ""
        Dim sql_select As String = "SELECT "
        Dim sql_from As String = "FROM terceros t ,terceros_2 c "
        Dim sql_where As String = "WHERE t.concepto_2 = c.concepto_2 "
        Dim columna_select As String = ""

        For i = 0 To chk_col_consol.CheckedItems.Count - 1
            If (chk_col_consol.CheckedItems(i).ToString = "tipo_tercero") Then
                columna_select = "(c.descripcion) As tipo_tercero "
            ElseIf (chk_col_consol.CheckedItems(i).ToString = "nit") Then
                itemMod.Enabled = True
                columna_select = chk_col_consol.CheckedItems(i).ToString
            ElseIf (chk_col_consol.CheckedItems(i).ToString = "departamento") Then
                columna_select = "(SELECT descripcion FROM y_departamentos WHERE departamento = y_dpto AND pais = y_pais) As departamento"
            Else
                columna_select = chk_col_consol.CheckedItems(i).ToString
            End If

            If (i = 0) Then
                sql_select &= "" & columna_select & ""
            Else
                sql_select &= "," & columna_select & ""
            End If
            If (i = chk_col_consol.CheckedItems.Count - 1) Then
                sql_select &= " "
            End If
        Next
        If (txt_cliente.Text.Trim <> "") Then
            sql_where &= " AND t.nit =" & txt_cliente.Text
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
                            sql_where &= "AND Vendedor IN('" & ChkListvendedores.CheckedItems(i).ToString & "'"
                        Else
                            sql_where &= ",'" & ChkListvendedores.CheckedItems(i).ToString & "'"
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
                        sql_where &= "AND t.ciudad IN('" & chk_ciudades.CheckedItems(i).ToString & "'"
                    Else
                        sql_where &= ",'" & chk_ciudades.CheckedItems(i).ToString & "'"
                    End If
                    If (i = chk_ciudades.CheckedItems.Count - 1) Then
                        sql_where &= ") "
                    End If

                End If
            Next
            For i = 0 To chk_tipo_tercero.CheckedItems.Count - 1
                If (chk_tipo_tercero.CheckedItems(i).ToString = "TODO") Then
                    i = chk_tipo_tercero.CheckedItems.Count - 1
                Else
                    If (i = 0) Then
                        sql_where &= "AND c.descripcion IN('" & chk_tipo_tercero.CheckedItems(i).ToString & "'"
                    Else
                        sql_where &= ",'" & chk_tipo_tercero.CheckedItems(i).ToString & "'"
                    End If
                    If (i = chk_tipo_tercero.CheckedItems.Count - 1) Then
                        sql_where &= ") "
                    End If

                End If
            Next
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
        End If
        sql = sql_select & sql_from & sql_where
        Return sql
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
        objOperacionesForm.ExportarDatosExcel(dtg_consulta, "Terceros")
    End Sub

    Private Sub chk_departamentos_SelectedValueChanged(sender As Object, e As EventArgs) Handles chk_departamentos.SelectedValueChanged
        If carga_comp Then
            cargar_ciudades()
        End If
    End Sub



    Private Sub itemMod_Click(sender As Object, e As EventArgs) Handles itemMod.Click
        group_tipo.Show()
    End Sub

    Private Sub dtg_consulta_MouseDown(sender As Object, e As MouseEventArgs) Handles dtg_consulta.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            With (Me.dtg_consulta)
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                End If
            End With
            fila_select = dtg_consulta.CurrentCell.RowIndex
        End If
    End Sub

    Private Sub btn_cerrar_tipo_Click(sender As Object, e As EventArgs) Handles btn_cerrar_tipo.Click
        group_tipo.Visible = False
    End Sub

    Private Sub dtg_tipo_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtg_tipo.CellClick
        If e.RowIndex >= 0 Then
            Dim concepto As String = dtg_tipo.Item("concepto_2", e.RowIndex).Value
            Dim nit As Double = dtg_consulta.Item("nit", fila_select).Value
            Dim sql As String = "UPDATE terceros SET concepto_2 = '" & concepto & "' WHERE nit =" & nit
            If objOpSimplesLn.ejecutar(sql, "CORSAN") > 0 Then
                MessageBox.Show("El tercero se modifico con exito", "Exito!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                For j = 0 To dtg_consulta.Columns.Count - 1
                    If dtg_consulta.Columns(j).Name = "tipo_tercero" Then
                        dtg_consulta.Item(j, fila_select).Value = dtg_tipo.Item("descripcion", e.RowIndex).Value
                        j = dtg_consulta.Columns.Count - 1
                    End If
                Next
                group_tipo.Visible = False
            Else
                MessageBox.Show("Error al modificar, comuniquese con el adminstrador del sistema", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub
End Class