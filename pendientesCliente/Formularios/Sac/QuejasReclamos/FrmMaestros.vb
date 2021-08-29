Imports logicaNegocios
Imports System.IO
Public Class FrmMaestros
    Private objQuejaRecLn As New QuejaRecLn
    Dim cargaComp As Boolean = False
    Private objOperacionesForm As New OperacionesFormularios
    Private Sub cboTabla_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTabla.SelectedIndexChanged
        If (cargaComp) Then
            Dim sql As String = ""
            Dim numCol As Integer
            If (cboTabla.Text = "Area_responsable") Then
                sql = "select J_area.nit,J_area.descripcion,ter.nombres  from J_area_resp J_area,terceros ter WHERE ter.nit= J_area.nit"
                numCol = 3
            ElseIf (cboTabla.Text = "Pqr") Then
                sql = "SELECT id_pqr,descripcion  	FROM J_pqr "
                numCol = 2
            ElseIf (cboTabla.Text = "Insatisfaccion") Then
                sql = "	SELECT id_insatisfac,descripcion  	FROM J_insatisfactor  "
                numCol = 2
            End If
            If (cboTabla.Text <> "Seleccione") Then
                consultar(sql, numCol)
            End If
        End If
    End Sub
    Private Sub FrmMaestros_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dt As New DataTable
        Dim row As DataRow
        dt.Columns.Add("id")
        dt.Columns.Add("descripcion")
        row = dt.NewRow
        row("id") = 0
        row("descripcion") = "Seleccione"
        dt.Rows.Add(row)
        row = dt.NewRow
        row("id") = 1
        row("descripcion") = "Area_responsable"
        dt.Rows.Add(row)
        row = dt.NewRow
        row("id") = 2
        row("descripcion") = "Pqr"
        dt.Rows.Add(row)
        row = dt.NewRow
        row("id") = 3
        row("descripcion") = "Insatisfaccion"
        dt.Rows.Add(row)
        cboTabla.DataSource = dt
        cboTabla.DisplayMember = "descripcion"
        cboTabla.ValueMember = "id"
        cargaComp = True
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        dtgMaestros.Rows.Add()
    End Sub

    Private Sub dtgMaestros_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgMaestros.CellClick
        Dim numCol As Integer = e.ColumnIndex
        Dim nomCol As String = dtgMaestros.Columns(numCol).Name
        Dim resp As Integer = 0
        Dim sql As String = ""
        Dim id As Double = 0
        Dim desc As String = ""
        Dim existe As Boolean = False
        Dim frm As New FrmTerceros
        If (nomCol = "txtId") Then
            frm.Show()
            frm.main("maestros", e.RowIndex, "")
        ElseIf (nomCol = "BtnGuardar") Then
            id = dtgMaestros.Item("txtId", e.RowIndex).Value
            desc = dtgMaestros.Item("txtDesc", e.RowIndex).Value
            existe = objQuejaRecLn.existeReg("Select * FROM J_area_resp WHERE nit = " & id)
            If (existe) Then
                sql = "UPDATE J_area_resp  SET descripcion  = '" & desc & "' WHERE nit = " & id & " "
            Else
                sql = "INSERT INTO  J_area_resp  (nit ,descripcion) VALUES (" & id & ",'" & desc & "')"
            End If
            resp = objQuejaRecLn.ejecutar(sql)
            If (resp >= 1) Then
                MessageBox.Show("Item modificado en forma exitosa", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        ElseIf (nomCol = "btnBorrar") Then
            Dim respuesta As Integer = MessageBox.Show("Esta seguro que desea eliminar el registro? ", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If (respuesta = 6) Then
                eliminar()
            End If
        End If
    End Sub
    Private Sub eliminar()
        Dim fila As Integer = dtgMaestros.CurrentCell.RowIndex
        Dim sql As String = ""
        Dim resp As Integer = 0
        Dim id_queja As Double = dtgMaestros.Item("txtId", fila).Value
        If (id_queja <> 0) Then
            sql = "DELETE FROM J_area_resp WHERE nit = " & dtgMaestros.Item("txtId", dtgMaestros.CurrentCell.RowIndex).Value
            resp = objQuejaRecLn.ejecutar(sql)
            If (resp >= 1) Then
                MessageBox.Show("Se elimino en forma exitosa", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Erorr al eliminar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
        dtgMaestros.Rows(fila).Visible = False
    End Sub
    Private Sub consultar(ByVal sql As String, ByVal numCol As Integer)
        dtgMaestros.Rows.Clear()
        Dim dt As New DataTable
        Select Case cboTabla.SelectedValue
            Case 1
                dtgMaestros.Columns("txtNombre").Visible = True
            Case 2
                dtgMaestros.Columns("txtNombre").Visible = False

            Case 3
                dtgMaestros.Columns("txtNombre").Visible = False

        End Select
        Dim mat(,) As Object = objQuejaRecLn.listar_vector_maestros(sql, numCol)
        Dim tam As Integer = ((mat.Length) / numCol) - 1
        For i = 0 To tam - 1
            dtgMaestros.Rows.Add()
            dtgMaestros.Item("txtId", i).Value = mat(i, 0)
            dtgMaestros.Item("txtDesc", i).Value = mat(i, 1)
            If (numCol = 3) Then
                dtgMaestros.Item("txtnombre", i).Value = mat(i, 2)
            End If

        Next
    End Sub
    Private Sub btnActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActualizar.Click
        Dim sql As String = ""
        Dim numCol As Integer
        If (cboTabla.Text = "Area_responsable") Then
            sql = "select J_area.nit,J_area.descripcion,ter.nombres  from J_area_resp J_area,terceros ter WHERE ter.nit= J_area.nit"
            numCol = 3
        ElseIf (cboTabla.Text = "Pqr") Then
            sql = "SELECT id_pqr,descripcion  	FROM J_pqr "
            numCol = 2
        ElseIf (cboTabla.Text = "Insatisfaccion") Then
            sql = "	SELECT id_insatisfac,descripcion  	FROM J_insatisfactor  "
            numCol = 2
        End If
        If (cboTabla.Text <> "Seleccione") Then
            consultar(sql, numCol)
        End If
    End Sub

    Private Sub btn_excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_excel.Click
        objOperacionesForm.ExportarDatosExcel(dtgMaestros, "Galvanizado")
    End Sub
End Class