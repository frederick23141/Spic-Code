Imports logicaNegocios
Imports entidadNegocios
Public Class Frm_ppto_gastos
    Private obj_op_simplesLn As New Op_simpesLn
    Private obj_Ing_prodLn As New Ing_prodLn
    Private objOperacionesForm As New OperacionesFormularios
    Dim carga_comp As Boolean = False
    Dim usuario As New UsuarioEn
    Dim fila_select As Integer
    Dim centros As String = ""
    Dim dt_centros As New DataTable
    Public Sub MAIN(ByVal usuario As UsuarioEn)
        Me.usuario = usuario
        Dim sql As String = ""
        sql = "SELECT centro,(CONVERT (varchar ,centro )+ ' - ' + descripcion )As descripcion FROM centros WHERE centro IN (1100,1200,3100,3200,3600,4100,2100,2200,2300,2400,2500,2600,2800,5200,6200,6400) ORDER by centro "
        dt_centros = obj_op_simplesLn.listar_datatable(sql, "CORSAN")
        dt_centros.Columns.Add("presupuesto", GetType(Double))
        carga_comp = True
    End Sub
    Private Sub Frm_ppto_gastos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim año = Now.Year
        While (año >= Now.Year - 5)
            cbo_ano.Items.Add(año)
            año -= 1
        End While
        cbo_ano.Text = Now.Year
        cbo_mes.SelectedIndex = Now.Month - 1
        consultar()
    End Sub
    Private Sub llenarDtg()
        dtg_presupuesto.DataSource = Nothing
        Dim dt As New DataTable
        Dim sql As String = "SELECT t.descripcion As tipo,g.cuenta ,c.descripcion As desc_cuenta " & _
                                 "FROM j_ppto_gastos_tipo t, J_ppto_gastos_cuentas g , cuentas c " & _
                                    "WHERE g.tipo  = t.id AND g.cuenta = c.cuenta"
        dt = obj_op_simplesLn.listar_datatable(sql, "CORSAN")
        dt.Columns.Add("presupuesto", GetType(Double))
        dt.Columns.Add("detalle", GetType(Double))
        dtg_presupuesto.DataSource = dt
        For i = 0 To dt.Rows.Count - 1
            dt.Rows(i).Item("detalle") = 0
        Next
        formatoDtg()
    End Sub

 
    Private Sub guardar()
        dtg_presupuesto.CurrentCell = Nothing
        Dim listSql As New List(Of Object)
        Dim ano As Integer = cbo_ano.Text
        Dim mes As Integer = cbo_mes.SelectedIndex + 1
        Dim sql_gral As String = "INSERT INTO J_ppto_gastos (ano,mes,cuenta,ppto) VALUES (" & ano & "," & mes & " "
        Dim sql As String = ""
        Dim sql_delete As String = "DELETE FROM J_ppto_gastos WHERE centro is null AND mes =" & cbo_mes.SelectedIndex + 1 & " AND ano = " & cbo_ano.Text & " "
        listSql.Add(sql_delete)
        For i = 0 To dtg_presupuesto.Rows.Count - 2
            If dtg_presupuesto.Item("detalle", i).Value < 1 Then
                sql = sql_gral & "," & dtg_presupuesto.Item("cuenta", i).Value & "," & dtg_presupuesto.Item("presupuesto", i).Value & ")"
                listSql.Add(sql)
            End If
        Next
        If (obj_Ing_prodLn.ExecuteSqlTransaction(listSql, "CORSAN")) Then
            MessageBox.Show("El registro se guardo en forma exitosa!", "Exito!", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Error al ingresar el registro, comuniquese con el area de sistemas", "Verifique!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub consultar()
        dtg_presupuesto.Columns.Clear()
        Dim dt As New DataTable
        Dim ano As Integer = cbo_ano.Text
        Dim mes As Integer = cbo_mes.SelectedIndex + 1
        Dim sql As String = "SELECT t.descripcion As tipo,g.cuenta ,c.descripcion As desc_cuenta ,SUM( ppto) As presupuesto, COUNT(centro) As detalle  " & _
                             "FROM j_ppto_gastos_tipo t, J_ppto_gastos_cuentas g , cuentas c , J_ppto_gastos p " & _
                                "WHERE g.tipo  = t.id AND g.cuenta = c.cuenta AND p.cuenta = g.cuenta  AND p.mes = " & mes & "  AND p.ano = " & ano & " " & _
                                    "GROUP BY t.descripcion,g.cuenta ,c.descripcion"
        dt = obj_Ing_prodLn.listar_datatable(sql, "CORSAN")
        dtg_presupuesto.DataSource = dt
        dt.Rows.Add()
        formatoDtg()
        If dt.Rows.Count = 1 Then
            llenarDtg()
        Else
            For i = 0 To dtg_presupuesto.Rows.Count - 1
                If IsNumeric(dtg_presupuesto.Item("detalle", i).Value) Then
                    If dtg_presupuesto.Item("detalle", i).Value > 1 Then
                        dtg_presupuesto.Item("detalle", i).ReadOnly = True
                    End If
                End If
            Next
        End If
    End Sub

    Private Function validar() As Boolean
        Dim resp As Boolean = True
        For i = 0 To dtg_presupuesto.Rows.Count - 1
            If Not IsDBNull(dtg_presupuesto.Item("presupuesto", i).Value) Then
                If Not IsNumeric(dtg_presupuesto.Item("presupuesto", i).Value) Then
                    resp = False
                End If
            Else
                dtg_presupuesto.Item("presupuesto", i).Value = 0
            End If
        Next

        Return resp
    End Function

    Private Sub btn_guardar_Click(sender As Object, e As EventArgs) Handles btn_guardar.Click
        guardarPpto()
    End Sub
    Private Sub guardarPpto()
        dtg_presupuesto.CurrentCell = Nothing
        If (validar()) Then
            Dim sql As String = "SELECT *  FROM J_ppto_gastos WHERE mes =" & cbo_mes.SelectedIndex + 1 & " AND ano = " & cbo_ano.Text
            If (obj_Ing_prodLn.consultValor(sql, "CORSAN") = "") Then
                guardar()
            Else
                Dim resp As Integer = 0
                resp = MessageBox.Show("Ya existe presupuesto para: " & cbo_mes.SelectedIndex + 1 & "-" & cbo_ano.Text & " desea sobre-escribirlo? ", "Modificar presupuesto", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
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
        consultar()
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

    Private Sub dtg_ppto_detalle_KeyPress(sender As Object, e As KeyPressEventArgs)
        soloNumero(e)
    End Sub
    Private Sub txt_dias_adic_otros_KeyPress(sender As Object, e As KeyPressEventArgs)
        soloNumero(e)
    End Sub
    Private Sub txt_dias_habl_otros_KeyPress(sender As Object, e As KeyPressEventArgs)
        soloNumero(e)
    End Sub
    Private Sub btnNuevo_Click(sender As Object, e As EventArgs)
        llenarDtg()
    End Sub
    Private Sub formatoDtg()
        Dim tamano_letra As Single = 9.0!
        For i = 0 To dtg_presupuesto.Columns.Count - 1
            If (dtg_presupuesto.Columns(i).Name = "desc_cuenta") Then
                dtg_presupuesto.Columns(i).ReadOnly = True
            ElseIf (dtg_presupuesto.Columns(i).Name = "descripcion") Then
                dtg_presupuesto.Columns(i).ReadOnly = True
            ElseIf (dtg_presupuesto.Columns(i).Name = "cuenta") Then
                dtg_presupuesto.Columns(i).ReadOnly = True
            ElseIf (dtg_presupuesto.Columns(i).Name = "presupuesto") Then
                dtg_presupuesto.Columns(i).ReadOnly = False
            End If
        Next
        dtg_presupuesto.Columns("presupuesto").SortMode = DataGridViewColumnSortMode.NotSortable
        dtg_presupuesto.Columns("presupuesto").DefaultCellStyle.BackColor = Color.GreenYellow
    End Sub
    Private Sub totalizarDtg()
        Dim sum As Double = 0
        Dim nom_col As String = ""
        For j = 0 To dtg_presupuesto.Columns.Count - 1
            nom_col = dtg_presupuesto.Columns(j).Name
            If (nom_col = "kilos" Or nom_col = "cantidad") Then
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
   
    Private Sub dtg_presupuesto_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dtg_presupuesto.CellValueChanged
        If (e.RowIndex <> dtg_presupuesto.Rows.Count - 1) Then
            If (dtg_presupuesto.Columns(e.ColumnIndex).Name = "kilos") Then
                If IsNumeric(dtg_presupuesto.Item(e.ColumnIndex, e.RowIndex).Value) Then
                    If (carga_comp) Then
                        ' totalizarDtg()
                    End If
                Else
                    carga_comp = False
                    dtg_presupuesto.Item(e.ColumnIndex, e.RowIndex).Value = 0
                    MessageBox.Show("Solo se permite el ingreso de valores numericos", "Verifique!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    carga_comp = True
                End If
            End If
        End If
    End Sub
    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        objOperacionesForm.ExportarDatosExcel(dtg_presupuesto, "Presupuesto de gastos")
    End Sub



    Private Sub txtDiasHabil_KeyPress(sender As Object, e As KeyPressEventArgs)
        soloNumero(e)
    End Sub

    Private Sub txtDiasAdic_KeyPress(sender As Object, e As KeyPressEventArgs)
        If (e.KeyChar.ToString <> ".") Then
            soloNumero(e)
        End If
    End Sub

    Private Sub btnNuevo_Click_1(sender As Object, e As EventArgs) Handles btnNuevo.Click
        llenarDtg()
    End Sub
    Private Sub dtg_presupuesto_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dtg_presupuesto.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            With (Me.dtg_presupuesto)
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                End If
            End With
            fila_select = (dtg_presupuesto.CurrentCell.RowIndex)
        End If
    End Sub

    Private Sub itemDetalle_Click(sender As Object, e As EventArgs) Handles itemDetalle.Click
        If fila_select >= 0 Then
            If IsNumeric(dtg_presupuesto.Item("cuenta", fila_select).Value) Then
                groupDetalle.Visible = True
                llenar_centros()
            End If
        End If
    End Sub
    Private Sub llenar_centros()
        dtgDetalle.DataSource = Nothing
        dtgDetalle.DataSource = dt_centros
        For i = 0 To dtgDetalle.Rows.Count - 1
            dtgDetalle.Item("presupuesto", i).Value = 0
        Next
        cargar_detalle()
        dtgDetalle.Columns("presupuesto").ReadOnly = False
        dtgDetalle.Columns("centro").ReadOnly = False
        dtgDetalle.Columns("descripcion").ReadOnly = False
    End Sub
    Private Sub cargar_detalle()
        Dim dt As New DataTable
        Dim ano As Integer = cbo_ano.Text
        Dim mes As Integer = cbo_mes.SelectedIndex + 1
        Dim cuenta As Double = dtg_presupuesto.Item("cuenta", fila_select).Value
        Dim sql As String = "SELECT p.centro, SUM( ppto) As presupuesto  " & _
                             "FROM  J_ppto_gastos p  " & _
                                "WHERE   p.centro is not null AND  p.cuenta = " & cuenta & " AND p.mes = " & mes & "  AND p.ano = " & ano & " " & _
                                    "GROUP BY p.centro"
        dt = obj_Ing_prodLn.listar_datatable(sql, "CORSAN")
        For i = 0 To dt.Rows.Count - 1
            For z = 0 To dtgDetalle.Rows.Count - 1
                If dt.Rows(i).Item("centro") = dtgDetalle.Item("centro", z).Value Then
                    dtgDetalle.Item("presupuesto", z).Value = dt.Rows(i).Item("presupuesto")
                    z = dtgDetalle.Rows.Count - 1
                End If
            Next
        Next
    End Sub
    Private Sub btn_guardar_detalle_Click(sender As Object, e As EventArgs) Handles btn_guardar_detalle.Click
        dtgDetalle.CurrentCell = Nothing
        Dim cuenta As Integer = dtg_presupuesto.Item("cuenta", fila_select).Value
        Dim listSql As New List(Of Object)
        Dim ano As Integer = cbo_ano.Text
        Dim mes As Integer = cbo_mes.SelectedIndex + 1
        Dim sql_gral As String = "INSERT INTO J_ppto_gastos (ano,mes,cuenta,centro,ppto) VALUES (" & ano & "," & mes & " "
        Dim sql As String = ""
        Dim sql_delete As String = "DELETE FROM J_ppto_gastos WHERE mes =" & cbo_mes.SelectedIndex + 1 & " AND ano = " & cbo_ano.Text & " AND cuenta = " & cuenta
        Dim total As Double = 0
        listSql.Add(sql_delete)
        For i = 0 To dtgDetalle.Rows.Count - 1
            If IsNumeric(dtgDetalle.Item("presupuesto", i).Value) Then
                If dtgDetalle.Item("presupuesto", i).Value > 0 Then
                    sql = sql_gral & "," & cuenta & "," & dtgDetalle.Item("centro", i).Value & "," & dtgDetalle.Item("presupuesto", i).Value & ")"
                    listSql.Add(sql)
                    total += dtgDetalle.Item("presupuesto", i).Value
                End If
            End If
        Next
        If (obj_Ing_prodLn.ExecuteSqlTransaction(listSql, "CORSAN")) Then
            MessageBox.Show("El registro se guardo en forma exitosa!", "Exito!", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Error al ingresar el registro, comuniquese con el area de sistemas", "Verifique!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        If total > 0 Then
            dtg_presupuesto.Item("detalle", fila_select).Value = 2
            dtg_presupuesto.Item("presupuesto", fila_select).ReadOnly = True
        Else
            dtg_presupuesto.Item("presupuesto", fila_select).ReadOnly = False
            dtg_presupuesto.Item("detalle", fila_select).Value = 0
        End If
        dtg_presupuesto.Item("presupuesto", fila_select).Value = total
        groupDetalle.Visible = False
    End Sub
    Private Sub dtgDetalle_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dtgDetalle.CellValueChanged
        If (e.RowIndex <> dtgDetalle.Rows.Count - 1) Then
            If (dtgDetalle.Columns(e.ColumnIndex).Name = "kilos") Then
                If IsNumeric(dtgDetalle.Item(e.ColumnIndex, e.RowIndex).Value) Then
                    If (carga_comp) Then
                        ' totalizarDtg()
                    End If
                Else
                    carga_comp = False
                    dtgDetalle.Item(e.ColumnIndex, e.RowIndex).Value = 0
                    MessageBox.Show("Solo se permite el ingreso de valores numericos", "Verifique!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    carga_comp = True
                End If
            End If
        End If
    End Sub

    Private Sub btn_cerrar_det_Click(sender As Object, e As EventArgs) Handles btn_cerrar_det.Click
        groupDetalle.Visible = False
    End Sub
End Class