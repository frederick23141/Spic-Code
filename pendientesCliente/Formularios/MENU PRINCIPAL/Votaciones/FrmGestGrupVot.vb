Imports System.Configuration
Imports logicaNegocios
Imports entidadNegocios
Imports System.IO
Imports Microsoft.Office.Interop
Public Class FrmGestGrupVot
    Public strSql As String = ""
    Private objVotacionesLn As New VotacionesLn
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
    Private Sub txtNit_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNit.TextChanged
        txtNombres.Text = ""
        cargarGrid()
    End Sub
Private Sub cargarGrid()
        If txtNit.Text <> "" And txtNombres.Text <> "" Then

            strSql = "SELECT ter.nombres,ter.grupo_vot ,grup.descripcion, ter.nit " & _
                         "FROM terceros ter , Jjv_grupos_votaciones grup,J_votaciones vot  " & _
                            "WHERE ter.nit LIKE '" & txtNit.Text & "%' AND " & _
                             "  ter.nombres LIKE '%" & txtNombres.Text & "%' AND ter.grupo_vot is not  null AND grup.id = ter.grupo_vot AND ter.nit = vot.id_tercero "

        ElseIf txtNit.Text = "" And txtNombres.Text <> "" Then

            strSql = "SELECT ter.nombres,ter.grupo_vot ,grup.descripcion, ter.nit " & _
                           "FROM terceros ter , Jjv_grupos_votaciones grup,J_votaciones vot  " & _
                     "WHERE ter.nombres LIKE '%" & txtNombres.Text & "%' AND ter.grupo_vot is not  null AND ter.grupo_vot is not  null AND grup.id = ter.grupo_vot AND ter.nit = vot.id_tercero "

        ElseIf txtNit.Text <> "" And txtNombres.Text = "" Then

            strSql = "SELECT ter.nombres,ter.grupo_vot ,grup.descripcion, ter.nit " & _
                               "FROM terceros ter , Jjv_grupos_votaciones grup,J_votaciones vot  " & _
                         "WHERE ter.nit LIKE '" & txtNit.Text & "%' AND ter.grupo_vot is not  null AND ter.grupo_vot is not  null AND grup.id = ter.grupo_vot AND ter.nit = vot.id_tercero "
        End If
        If (txtNit.Text = "" And txtNombres.Text = "") Then
            strSql = "SELECT ter.nombres,ter.grupo_vot ,grup.descripcion, ter.nit " & _
                "FROM terceros ter , Jjv_grupos_votaciones grup,J_votaciones vot  " & _
                    " WHERE ter.grupo_vot is not  null AND ter.grupo_vot is not  null AND grup.id = ter.grupo_vot AND ter.nit = vot.id_tercero "

        End If
        If (strSql <> "") Then
            dtgGestGrup.DataSource = objVotacionesLn.listar_datatable(strSql)
            dtgGestGrup.Columns("nombres").ReadOnly = True
            dtgGestGrup.Columns("descripcion").ReadOnly = True
            dtgGestGrup.Columns("nit").ReadOnly = True
            dtgGestGrup.Columns("grupo_vot").HeaderCell.Style.BackColor = Color.GreenYellow
            dtgGestGrup.Columns("grupo_vot").HeaderCell.Style.ForeColor = Color.Black
        End If

    End Sub

    Private Sub txtNombres_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNombres.TextChanged
        txtNit.Text = ""
        cargarGrid()
    End Sub

    Private Sub FrmGestGrupVot_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargarGrid()
    End Sub
    Private Sub ModificarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ModificarToolStripMenuItem.Click
        Dim pos As Integer = dtgGestGrup.CurrentCell.RowIndex
        dtgGestGrup.CurrentCell = Nothing
        Dim nit As Double = dtgGestGrup("nit", pos).Value
        Dim grupo As String = dtgGestGrup("grupo_vot", pos).Value
        Dim sql As String = "UPDATE terceros SET grupo_vot = " & grupo & "	WHERE nit = " & nit & " "
        If (grupo <> "") Then
            If (objVotacionesLn.ejecutar(sql) >= 1) Then
                cargarGrid()
                MessageBox.Show("El registro de modifico en forma correcta! ", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Error al modifico  el registro, verifique que la celda no este en blanco! ", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            MessageBox.Show("Verifique que los items a modificar esten correctamente digitados! ", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub EliminarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EliminarToolStripMenuItem.Click
        Dim pos As Integer = dtgGestGrup.CurrentCell.RowIndex
        dtgGestGrup.CurrentCell = Nothing
        Dim nombre As String = dtgGestGrup("nombres", pos).Value
        Dim nit As String = dtgGestGrup("nit", pos).Value
        Dim resp As Boolean = MessageBox.Show("Esta seguro que desea el empleado " & nombre & " se encuentra desvinculado de la compañia? ", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If (resp) Then
            Dim sql As String = "DELETE  J_votaciones WHERE id_tercero= " & nit
            If (objVotacionesLn.ejecutar(sql) >= 1) Then
                cargarGrid()
                MessageBox.Show("El registro de elimino en forma correcta! ", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Error al elimino el registro, verifique que la celda no este en blanco! ", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If

    End Sub

   
    Private Sub btn_reiniciar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_reiniciar.Click
        Dim sql As String = "UPDATE J_votaciones SET puntos =0 , votante =0 "

        If (objVotacionesLn.ejecutar(sql) > 0) Then
            MessageBox.Show("Las votaciones de reiniciaron en forma correcta! ", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Error al reiniciar votaciones, comuniquese con el administrador del sistema! ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
End Class