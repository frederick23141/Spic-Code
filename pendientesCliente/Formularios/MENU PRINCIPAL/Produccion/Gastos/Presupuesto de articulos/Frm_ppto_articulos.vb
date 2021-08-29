Imports logicaNegocios
Imports entidadNegocios
Public Class Frm_ppto_articulos
    Private obj_op_simplesLn As New Op_simpesLn
    Private obj_Ing_prodLn As New Ing_prodLn
    Private objOperacionesForm As New OperacionesFormularios
    Dim carga_comp As Boolean = False
    Dim usuario As New UsuarioEn
    Public Sub MAIN(ByVal usuario As UsuarioEn)
        Me.usuario = usuario
        Dim where_sql As String = ""
        Dim sql As String = ""
        Dim centros As String = ""
        Dim dt As New DataTable
        Dim dr As DataRow
        If (usuario.permiso.Trim <> "ADMIN" And usuario.permiso.Trim <> "COMPRAS") Then
            Dim nit As Double = usuario.nit
            Dim listCentros As DataTable = obj_op_simplesLn.listar_datatable("SELECT centro FROM J_coordinador_centros_costos WHERE nit =" & nit, "PRODUCCION")
            For i = 0 To listCentros.Rows.Count - 1
                centros &= listCentros.Rows(i).Item("centro")
                If (i <> listCentros.Rows.Count - 1) Then
                    centros &= ","
                End If
            Next
        End If
        If centros = "" Then
            centros = "1200,2100,2117,2200,2300,2400,2500,2600,2800,3100,3200,4100,3500,5200,6200,6400"
        End If

        where_sql &= "WHERE centro IN(" & centros & ")"
        Sql = "SELECT centro,( CAST (centro AS varchar(25))+ '-' + descripcion )As descripcion " & _
                        "FROM centros " & _
                            where_sql
        dt = obj_op_simplesLn.listar_datatable(sql, "CORSAN")
        dr = dt.NewRow
        dr("centro") = 0
        dr("descripcion") = "Seleccione"
        dt.Rows.Add(dr)
        cbo_centro.DataSource = dt
        cbo_centro.ValueMember = "centro"
        cbo_centro.DisplayMember = "descripcion"
        cbo_centro.SelectedValue = 0
    End Sub
    Private Sub Frm_ppto_articulos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim año = Now.Year
        While (año >= Now.Year - 5)
            cbo_ano.Items.Add(año)
            año -= 1
        End While
        cbo_ano.Text = Now.Year
        cbo_mes.SelectedIndex = Now.Month - 1
        consultar()
        carga_comp = True
    End Sub
    Private Sub llenarDtg()
        dtg_presupuesto.DataSource = Nothing
        dtg_presupuesto.Columns.Clear()
        dtg_presupuesto.Columns.Add("codigo", "codigo")
        dtg_presupuesto.Columns.Add("descripcion", "descripcion")
        dtg_presupuesto.Columns.Add("cantidad", "cantidad")
        dtg_presupuesto.Columns.Add("costo", "costo")
        Dim sql As String = "SELECT p.codigo,r.descripcion " & _
                                    "FROM J_ppto_articulos_codigos p , CORSAN.dbo.referencias r " & _
                                          "WHERE p.codigo = r.codigo " & _
                                            " ORDER BY r.descripcion"
        Dim dt_lineas As DataTable = obj_op_simplesLn.listar_datatable(sql, "PRODUCCION")
        For i = 0 To dt_lineas.Rows.Count - 1
            dtg_presupuesto.Rows.Add()
            dtg_presupuesto.Item("codigo", i).Value = dt_lineas.Rows(i).Item("codigo")
            dtg_presupuesto.Item("descripcion", i).Value = dt_lineas.Rows(i).Item("descripcion")
            dtg_presupuesto.Item("cantidad", i).Value = 0
            dtg_presupuesto.Item("costo", i).Value = 0
        Next
        dtg_presupuesto.Rows.Add()
        formatoDtg()
        totalizarDtg()
    End Sub
    Private Sub totalizarDtg()
        Dim sum As Double = 0
        Dim nom_col As String = ""
        For j = 0 To dtg_presupuesto.Columns.Count - 1
            nom_col = dtg_presupuesto.Columns(j).Name
            If (nom_col = "cantidad" Or nom_col = "costo") Then
                For i = 0 To dtg_presupuesto.Rows.Count - 2
                    If Not IsDBNull(dtg_presupuesto.Item(j, i).Value) Then
                        sum += dtg_presupuesto.Item(j, i).Value
                    End If
                Next
                dtg_presupuesto.Item(j, dtg_presupuesto.Rows.Count - 1).Value = sum
                sum = 0
            End If
        Next
    End Sub

    Private Sub guardar()
        dtg_presupuesto.CurrentCell = Nothing
        Dim listSql As New List(Of Object)
        Dim ano As Integer = cbo_ano.Text
        Dim mes As Integer = cbo_mes.SelectedIndex + 1
        Dim centro As Integer = cbo_centro.SelectedValue
        Dim sql_gral As String = "INSERT INTO J_ppto_articulos (ano,mes,centro,codigo,cantidad,costo) VALUES (" & ano & "," & mes & "," & centro & " "
        Dim sql As String = ""
        Dim sql_delete As String = "DELETE FROM J_ppto_articulos WHERE centro = " & centro & " AND mes =" & cbo_mes.SelectedIndex + 1 & " AND ano = " & cbo_ano.Text
        listSql.Add(sql_delete)
        For i = 0 To dtg_presupuesto.Rows.Count - 2
            If dtg_presupuesto.Item("cantidad", i).Value > 0 Then
                sql = sql_gral & "," & dtg_presupuesto.Item("codigo", i).Value & "," & dtg_presupuesto.Item("cantidad", i).Value & "," & dtg_presupuesto.Item("costo", i).Value & ")"
                listSql.Add(sql)
            End If
        Next
        If (obj_Ing_prodLn.ExecuteSqlTransaction(listSql, "PRODUCCION")) Then
            MessageBox.Show("El registro se guardo en forma exitosa!", "Exito!", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Error al ingresar el registro, comuniquese con el area de sistemas", "Verifique!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Private Sub consultar()
        dtg_presupuesto.Columns.Clear()
        llenarDtg()
        Dim dt As New DataTable
        Dim centro As Integer = cbo_centro.SelectedValue
        Dim sql As String = "SELECT p.centro,p.codigo,r.descripcion,p.cantidad,costo " & _
                                        "FROM J_ppto_articulos p , CORSAN.dbo.referencias  r " & _
                                            "WHERE p.centro = " & centro & " AND p.codigo = r.codigo AND mes =" & cbo_mes.SelectedIndex + 1 & " AND ano = " & cbo_ano.Text & " " & _
                                            "ORDER BY r.descripcion"
        dt = obj_Ing_prodLn.listar_datatable(sql, "PRODUCCION")
        For i = 0 To dt.Rows.Count - 1
            For k = 0 To dtg_presupuesto.Rows.Count - 1
                If Not IsDBNull(dtg_presupuesto.Item("codigo", k).Value) Then
                    If dtg_presupuesto.Item("codigo", k).Value = dt.Rows(i).Item("codigo") Then
                        dtg_presupuesto.Item("cantidad", k).Value = dt.Rows(i).Item("cantidad")
                        If Not IsDBNull(dtg_presupuesto.Item("costo", k).Value) Then
                            dtg_presupuesto.Item("costo", k).Value = dt.Rows(i).Item("costo")
                        Else
                            dtg_presupuesto.Item("costo", k).Value = 0
                        End If
                        k = dtg_presupuesto.Rows.Count - 1
                    End If
                End If
            Next
        Next
        totalizarDtg()
        For j = 0 To dtg_presupuesto.Columns.Count - 1
            If (dtg_presupuesto.Columns(j).Name = "cantidad") Then
                dtg_presupuesto.Columns(j).ReadOnly = False
            End If
        Next
    End Sub
    Private Function validar() As Boolean
        Dim resp As Boolean = True
        If cbo_centro.SelectedValue <> 0 Then
            For i = 0 To dtg_presupuesto.Rows.Count - 1
                If Not IsDBNull(dtg_presupuesto.Item("cantidad", i).Value) Then
                    If Not IsNumeric(dtg_presupuesto.Item("cantidad", i).Value) Then
                        resp = False
                    End If
                Else
                    dtg_presupuesto.Item("kilos", i).Value = 0
                End If
            Next
        Else
            MessageBox.Show("Seleccione un centro de costos", "Seleccione centro de costos", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            resp = False
        End If

        Return resp
    End Function
    Private Sub btn_guardar_Click(sender As Object, e As EventArgs) Handles btn_guardar.Click
      guardarPpto()
    End Sub
    Private Sub guardarPpto()
        dtg_presupuesto.CurrentCell = Nothing
        If (validar()) Then
            Dim sql As String = "SELECT * FROM J_ppto_articulos WHERE centro = " & cbo_centro.SelectedValue & " AND mes =" & cbo_mes.SelectedIndex + 1 & " AND ano = " & cbo_ano.Text
            If (obj_Ing_prodLn.consultValor(sql, "PRODUCCION") = "") Then
                guardar()
            Else
                Dim resp As Integer = 0
                resp = MessageBox.Show("Ya existe presupuesto para: centro de costos " & cbo_centro.SelectedValue & " En el mes: " & cbo_mes.SelectedIndex + 1 & "-" & cbo_ano.Text & " desea sobre-escribirlo? ", "Modificar presupuesto", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If resp = 6 Then
                    guardar()
                Else
                    llenarDtg()
                End If
            End If

        Else
            MessageBox.Show("Verifique que los valores ingresados sean númericos    ", "Verifique!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
    Private Sub btn_actualizar_Click(sender As Object, e As EventArgs) Handles btn_actualizar.Click
        carga_comp = False
        If cbo_centro.SelectedValue <> 0 Then
              consultar()
        Else
            MessageBox.Show("Seleccione un centro de costos", "Seleccione centro de costos", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

        carga_comp = True
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

    Private Sub formatoDtg()
        Dim tamano_letra As Single = 9.0!
        For i = 0 To dtg_presupuesto.Columns.Count - 1
            If (dtg_presupuesto.Columns(i).Name = "codigo") Then
                dtg_presupuesto.Columns(i).ReadOnly = True
            ElseIf (dtg_presupuesto.Columns(i).Name = "descripcion") Then
                dtg_presupuesto.Columns(i).ReadOnly = True
            ElseIf (dtg_presupuesto.Columns(i).Name = "cantidad") Then
                dtg_presupuesto.Columns(i).ReadOnly = False
            End If
        Next
        dtg_presupuesto.Item("descripcion", dtg_presupuesto.Rows.Count - 1).Value = "TOTAL"
        dtg_presupuesto.Rows(dtg_presupuesto.Rows.Count - 1).DefaultCellStyle = objOperacionesForm.formatoNegrita(tamano_letra)
        dtg_presupuesto.Columns("descripcion").SortMode = DataGridViewColumnSortMode.NotSortable
        dtg_presupuesto.Columns("codigo").SortMode = DataGridViewColumnSortMode.NotSortable
        dtg_presupuesto.Columns("cantidad").SortMode = DataGridViewColumnSortMode.NotSortable
        dtg_presupuesto.Rows(dtg_presupuesto.Rows.Count - 1).ReadOnly = True
        dtg_presupuesto.Columns("cantidad").DefaultCellStyle.BackColor = Color.GreenYellow
    End Sub
    Private Sub dtg_presupuesto_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dtg_presupuesto.CellValueChanged
        If (e.RowIndex <> dtg_presupuesto.Rows.Count - 1) Then
            If (dtg_presupuesto.Columns(e.ColumnIndex).Name = "cantidad") Then
                If IsNumeric(dtg_presupuesto.Item(e.ColumnIndex, e.RowIndex).Value) Then
                    Dim codigo As String = dtg_presupuesto.Item("codigo", e.RowIndex).Value
                    Dim sql As String = "SELECT costo_unitario  FROM referencias  WHERE codigo = '" & codigo & "'"
                    Dim costo_unit As String = obj_op_simplesLn.consultarVal(sql)
                    Dim costo_total As Double = 0
                    If costo_unit = "" Then
                        costo_unit = 0
                    End If
                    costo_total = Convert.ToDouble(costo_unit) * dtg_presupuesto.Item(e.ColumnIndex, e.RowIndex).Value
                    dtg_presupuesto.Item("costo", e.RowIndex).Value = costo_total
                    If (carga_comp) Then
                        totalizarDtg()
                    End If
                Else
                    carga_comp = False
                    dtg_presupuesto.Item(e.ColumnIndex, e.RowIndex).Value = 0
                    dtg_presupuesto.Item("costo", e.RowIndex).Value = 0
                    MessageBox.Show("Solo se permite el ingreso de valores numericos", "Verifique!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    carga_comp = True
                End If
            End If
        End If
    End Sub
    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        objOperacionesForm.ExportarDatosExcel(dtg_presupuesto, "Presupuesto de articulos")
    End Sub



    Private Sub btnNuevo_Click_1(sender As Object, e As EventArgs) Handles btnNuevo.Click
        llenarDtg()
    End Sub

    Private Sub txtDiasHabil_KeyPress(sender As Object, e As KeyPressEventArgs)
        soloNumero(e)
    End Sub

    Private Sub txtDiasAdic_KeyPress(sender As Object, e As KeyPressEventArgs)
        If (e.KeyChar.ToString <> ".") Then
            soloNumero(e)
        End If
    End Sub

    Private Sub cbo_centro_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbo_centro.SelectedIndexChanged
        If carga_comp Then
            consultar()
        End If
    End Sub
End Class