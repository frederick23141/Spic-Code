Imports logicaNegocios
Public Class Frm_ing_galv
    Private carga_compl As Boolean = False
    Private objOperacionesForm = New OperacionesFormularios
    Private obj_op_simplesLn As New Op_simpesLn
    Private obj_Ing_prodLn As New Ing_prodLn
    Private h_prog As Double = 0
    Private h_trab As Double = 0
    Private nom_modulo As String
    Public Sub Main(ByVal nom_modulo As String, ByVal permiso As String)
        Me.nom_modulo = nom_modulo
        If (permiso <> "ADMIN") Then
            btnContCambios.Visible = False
        End If
    End Sub
    Private Sub btnContCambios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnContCambios.Click
        FrmAuditCambios.Show()
        FrmAuditCambios.Main(nom_modulo)
        FrmAuditCambios.WindowState = 2
    End Sub
    Private Sub Frm_ing_galv_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cbo_fecha.Value = Now.AddDays(-1)
        Dim sql As String = "select Codigo,Descripcion from J_turnos  "
        Dim col As New DataColumn
        cbo_fecha.Value = Now.AddDays(-1)
        cbo_turno.DataSource = obj_Ing_prodLn.listar_datatable(sql, "PRODUCCION")
        cbo_turno.ValueMember = "Codigo"
        cbo_turno.DisplayMember = "Descripcion"
        cbo_turno.Text = "Seleccione"

        cargar_cbo_dtg()
        carga_compl = True
    End Sub
    Private Sub limpiar()
        cbo_turno.Text = "Seleccione"
        dtg_planilla.Rows.Clear()
        cargar_cbo_dtg()
    End Sub
    Private Sub cargar_cbo_dtg()
        Dim sql As String = ""
        Dim dt As DataTable
        Dim row As DataRow
        sql = "select  id,descripcion   from j_calibres where maquina = 2122 "
        dt = obj_Ing_prodLn.listar_datatable(sql, "PRODUCCION")
        row = dt.NewRow
        row("id") = 0
        row("descripcion") = ""
        dt.Rows.Add(row)
        cbo_calibre.DataSource = dt
        cbo_calibre.ValueMember = "id"
        cbo_calibre.DisplayMember = "descripcion"

        dt = New DataTable
        sql = "SELECT id,descripcion FROM J_destino_galv "
        dt = obj_Ing_prodLn.listar_datatable(sql, "PRODUCCION")
        row = dt.NewRow
        row("id") = 0
        row("descripcion") = ""
        dt.Rows.Add(row)
        cbo_destino.DataSource = dt
        cbo_destino.ValueMember = "id"
        cbo_destino.DisplayMember = "descripcion"

        dt = New DataTable
        sql = "SELECT id,descripcion FROM J_prod_galv_tipo "
        dt = obj_Ing_prodLn.listar_datatable(sql, "PRODUCCION")
        row = dt.NewRow
        row("id") = 0
        row("descripcion") = ""
        dt.Rows.Add(row)
        cbo_tipo.DataSource = dt
        cbo_tipo.ValueMember = "id"
        cbo_tipo.DisplayMember = "descripcion"

        For i = 0 To 9
            dtg_planilla.Rows.Add()
        Next
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

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If (cbo_turno.Text <> "Seleccione" And txt_h_trab.Text <> "") Then
            guardar()
        Else
            MessageBox.Show("Verifique que todos los items de la planilla  este llenos! ", "Campos", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub
    Private Sub guardar()
        dtg_planilla.CurrentCell = Nothing
        Dim list_sql As New List(Of Object)
        Dim uni_ini As String = 0
        Dim uni_fin As String = 0
        Dim resp As Integer = 0
        Dim fecha As String = obj_op_simplesLn.cambiarFormatoFecha(cbo_fecha.Value.Date)
        Dim turno As Integer = cbo_turno.SelectedValue
        'Se  le suman los paros antiguos para que cada registro quede con su tiempo sin just individual
        Dim calibre As String = ""
        Dim paro1 As Integer = 0
        Dim paro2 As Integer = 0
        Dim paro3 As Integer = 0
        Dim paro4 As Integer = 0
        Dim paro5 As Integer = 0
        Dim paro6 As Integer = 0
        Dim paro7 As Integer = 0
        Dim paro8 As Integer = 0
        Dim paro9 As Integer = 0
        Dim sql_det_total As String = ""
        Dim tipo As Double = 0
        Dim destino As Double = 0
        Dim kilos As Double = 0
        Dim id As Double = obj_Ing_prodLn.consultValor("SELECT  (SELECT CASE WHEN MAX(id) IS NULL THEN (1) ELSE MAX(id)+1 END) as id FROM J_prod_galv_enc", "PRODUCCION")
        Dim sql_enc As String = "INSERT INTO J_prod_galv_enc (id,fecha,maquina ,turno,horas_trab) " & _
                                               "VALUES(" & id & ",'" & fecha & "',2122, " & turno & ", " & txt_h_trab.Text & ") "
        Dim sql_det_gral As String = "INSERT INTO J_prod_galv_det (id_enc,id_det,destino ,tipo,calibre,kilos_prod,paro1,paro2,paro3,paro4,paro5,paro6,paro7,paro8,paro9) " & _
                                               "VALUES(" & id & ","
        list_sql.Add(sql_enc)
        If (verificar_planilla(dtg_planilla)) Then
            For i = 0 To dtg_planilla.RowCount - 1
                calibre = dtg_planilla("cbo_calibre", i).Value
                destino = dtg_planilla(cbo_destino.Name, i).Value
                tipo = dtg_planilla(cbo_destino.Name, i).Value
                kilos = dtg_planilla(txt_kilos.Name, i).Value
                If (calibre <> 0) Then
                    sql_det_total = sql_det_gral & i & "," & destino & "," & tipo & "," & calibre & "," & kilos & ", " & _
                    add_paros(i, dtg_planilla)
                    list_sql.Add(sql_det_total)
                End If
            Next
            If (obj_Ing_prodLn.ExecuteSqlTransaction(list_sql, "PRODUCCION")) Then
                MessageBox.Show("Su planilla fue ingresada en forma exitosa! ", "Correcto!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                limpiar()
            Else
                MessageBox.Show("Error al ingresar la planilla a la base de datos,verifique que todos los datos esten correctos ò comuniquese con el administrador del sistema! ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            MessageBox.Show("Verifique que los datos de todos los registros de la planilla  sean correctos! ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub
    Public Function verificar_planilla(ByVal dtg As DataGridView) As Boolean
        Dim resp As Boolean = True
        Dim calibre As Integer = 0
        Dim kilos As Double = 0
        Dim tipo As Double = 0
        Dim destino As Double = 0
        For i = 0 To dtg_planilla.RowCount - 1
            calibre = dtg_planilla.Item("cbo_calibre", i).Value
            destino = dtg_planilla(cbo_destino.Name, i).Value
            tipo = dtg_planilla(cbo_destino.Name, i).Value
            kilos = dtg_planilla("txt_kilos", i).Value
            dtg_planilla.Rows(i).DefaultCellStyle.BackColor = Color.Red
            If (calibre <> 0 Or kilos <> Nothing) Then
                If Not (calibre <> 0 And kilos <> 0 And tipo <> 0 And destino <> 0) Then
                    resp = False
                    i = dtg_planilla.RowCount - 1
                End If
            End If
        Next
        Return resp
    End Function
    Public Function add_paros(ByVal indice As Integer, ByVal dtg As DataGridView) As String
        Dim sql As String = ""
        Dim paro1 As Integer = 0
        Dim paro2 As Integer = 0
        Dim paro3 As Integer = 0
        Dim paro4 As Integer = 0
        Dim paro5 As Integer = 0
        Dim paro6 As Integer = 0
        Dim paro7 As Integer = 0
        Dim paro8 As Integer = 0
        Dim paro9 As Integer = 0
        Dim num As String = ""

        For i = dtg.Columns("txt_p1").Index To dtg.ColumnCount - 1
            If (dtg.Columns(i).HeaderText.ToString).Length > 2 Then
                num = Convert.ToInt16(dtg.Columns(i).HeaderText(1).ToString) & (dtg.Columns(i).HeaderText(2).ToString)
            Else
                num = (dtg.Columns(i).HeaderText(1).ToString)
            End If

            Select Case num
                Case 1
                    If Not IsDBNull(dtg.Item(i, indice).Value) Then
                        If (dtg.Item(i, indice).Value <> "") Then
                            paro1 = dtg.Item(i, indice).Value
                        End If
                    End If
                Case 2
                    If Not IsDBNull(dtg.Item(i, indice).Value) Then
                        If (dtg.Item(i, indice).Value <> "") Then
                            paro2 = dtg.Item(i, indice).Value
                        End If
                    End If
                Case 3
                    If Not IsDBNull(dtg.Item(i, indice).Value) Then
                        If (dtg.Item(i, indice).Value <> "") Then
                            paro3 = dtg.Item(i, indice).Value
                        End If
                    End If
                Case 4
                    If Not IsDBNull(dtg.Item(i, indice).Value) Then
                        If (dtg.Item(i, indice).Value <> "") Then
                            paro4 = dtg.Item(i, indice).Value
                        End If
                    End If
                Case 5
                    If Not IsDBNull(dtg.Item(i, indice).Value) Then
                        If (dtg.Item(i, indice).Value <> "") Then
                            paro5 = dtg.Item(i, indice).Value
                        End If
                    End If
                Case 6
                    If Not IsDBNull(dtg.Item(i, indice).Value) Then
                        If (dtg.Item(i, indice).Value <> "") Then
                            paro6 = dtg.Item(i, indice).Value
                        End If
                    End If
                Case 7
                    If Not IsDBNull(dtg.Item(i, indice).Value) Then
                        If (dtg.Item(i, indice).Value <> "") Then
                            paro7 = dtg.Item(i, indice).Value
                        End If
                    End If
                Case 8
                    If Not IsDBNull(dtg.Item(i, indice).Value) Then
                        If (dtg.Item(i, indice).Value <> "") Then
                            paro8 = dtg.Item(i, indice).Value
                        End If
                    End If
                Case 9
                    If Not IsDBNull(dtg.Item(i, indice).Value) Then
                        If (dtg.Item(i, indice).Value <> "") Then
                            paro9 = dtg.Item(i, indice).Value
                        End If
                    End If

            End Select
        Next
        sql = paro1 & " , " & paro2 & " , " & paro3 & " , " & paro4 & " , " & paro5 & " , " & paro6 & " , " & paro7 & " , " & paro8 & " , " & paro9 & "  )"
        Return sql
    End Function
    Public Function sumar_paros(ByVal indice As Integer, ByVal dtg As DataGridView) As Double
        Dim sum As Double = 0
        For i = dtg.Columns("txt_p1").Index To dtg.ColumnCount - 1
            If (dtg.Item(i, indice).Value <> "") Then
                sum = sum + dtg.Item(i, indice).Value
            End If
        Next
        Return sum
    End Function
    Private Sub cbo_turno_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_turno.SelectedIndexChanged
        If (cbo_turno.Text <> "Seleccione" And cbo_turno.Text <> "System.Data.DataRowView" And (cbo_turno.SelectedValue).ToString <> "System.Data.DataRowView") Then
            Dim horas As String = ""
            Dim texto As String = cbo_turno.Text
            For i = 0 To texto.Length - 1
                If IsNumeric(texto(i)) Then
                    horas += texto(i)
                End If
            Next
            h_prog = Convert.ToInt16(horas)
        End If
    End Sub
    Private Sub dtg_planilla_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtg_planilla.CellValueChanged
        If (carga_compl) Then
            Dim col As String = dtg_planilla.Columns(e.ColumnIndex).Name
            Dim fila As Integer = e.RowIndex
            Dim id_calibre As Integer = dtg_planilla.Item("cbo_calibre", fila).Value
            Dim sql As String = "select milimetros from j_calibres where id= " & id_calibre
            If (col = "cbo_calibre") Then
                dtg_planilla.Item("txt_mm", fila).Value = obj_Ing_prodLn.consultar_valor(sql, "PRODUCCION")
            End If
        End If
    End Sub

    Private Sub txt_h_trab_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_h_trab.KeyPress

        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
        If (e.KeyChar = Microsoft.VisualBasic.ChrW(13)) Then
            txt_h_trab.Focus()
        End If
    End Sub

    Private Sub txt_h_trab_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_h_trab.TextChanged
        If (txt_h_trab.Text <> "") Then
            h_trab = txt_h_trab.Text
        End If
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Frm_consultar_galva_forma2.Show()
    End Sub
    Private Sub dtg_planillaCellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtg_planilla.CellContentClick
        Dim fila As Integer = e.RowIndex
        Dim col As String = dtg_planilla.Columns(e.ColumnIndex).Name
        If (col = "btn_borrar") Then
            dtg_planilla.Rows.RemoveAt(e.RowIndex)
        ElseIf (col = colAdd.Name) Then
            dtg_planilla.Rows.Add()
        End If
    End Sub
End Class