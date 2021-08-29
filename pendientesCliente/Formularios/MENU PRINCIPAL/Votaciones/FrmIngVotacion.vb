Imports System.Configuration
Imports logicaNegocios
Imports System.IO
Imports Microsoft.Office.Interop
#Disable Warning BC40056 ' El espacio de nombres o el tipo especificado en el 'System.Data.SqlServerCe' Imports no contienen ningún miembro público o no se encuentran. Asegúrese de que el espacio de nombres o el tipo se hayan definido y de que contengan al menos un miembro público. Asegúrese de que el nombre del elemento importado no use ningún alias.
Imports System.Data.SqlServerCe
#Enable Warning BC40056 ' El espacio de nombres o el tipo especificado en el 'System.Data.SqlServerCe' Imports no contienen ningún miembro público o no se encuentran. Asegúrese de que el espacio de nombres o el tipo se hayan definido y de que contengan al menos un miembro público. Asegúrese de que el nombre del elemento importado no use ningún alias.

Public Class FrmIngVotacion
    Private objVotacionesLn As New VotacionesLn
    Private carga_comp As Boolean = False
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
    Private Sub FrmIngVotacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        carga_comp = True
    End Sub

    'Private Sub cboArea_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If (carga_comp) Then
    '        Dim sql As String = "SELECT nombres As Nombres,nit  FROM Jjv_personal_vot "
    '        Dim whereSql As String = "WHERE centro in ("
    '        If (cboArea.Text = "Planta") Then
    '            sql = " )"
    '        Else
    '            sql = "4200,4300)"
    '        End If
    '        sql += whereSql
    '        dtgVoto.DataSource = objVotacionesLn.listar_datatable(sql)
    '    End If
    'End Sub

    Public Sub cargarEmpleados(ByVal nit As Double)
        Dim vec_usu() As Object = objVotacionesLn.cargarInfoBasica(nit)
        If Not IsNothing(vec_usu(1)) Then
            If (objVotacionesLn.verificarVotante(txtNit.Text)) Then
                Dim grupo As String = vec_usu(1)
                txtNombres.Text = vec_usu(0)
                If (grupo = 1) Then
                    dtgVoto.Columns("txtPuntos").Visible = False
                    dtgVoto.Columns("chkVoto").Visible = True
                    imgInstruct.Image = Spic.My.Resources.Resources.instrucPlanta
                Else
                    dtgVoto.Columns("chkVoto").Visible = False
                    dtgVoto.Columns("txtPuntos").Visible = True
                    imgInstruct.Image = Spic.My.Resources.Resources.instructivoAdmin4
                End If
                Dim sql As String = "SELECT nombres As Nombres,nit  FROM terceros WHERE grupo_vot = " & grupo & " AND nit <> " & nit & " ORDER BY nombres"
                dtgVoto.DataSource = objVotacionesLn.listar_datatable(sql)
                dtgVoto.Columns("nit").Visible = False
            Else
                MessageBox.Show("La cédula " & txtNit.Text & " ya realizo su voto, el cual solo es permitido una vez! ", "Voto", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                nuevo()
            End If
        Else
            MessageBox.Show("La cédula " & txtNit.Text & " no existe, Verifique que este escrita en forma correcta! ", "Cédula", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If


    End Sub


    Private Sub txtNit_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNit.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
        If (e.KeyChar = Microsoft.VisualBasic.ChrW(13) And txtNit.Text <> "") Then
            Dim nit As Double = txtNit.Text
            cargarEmpleados(nit)
            dtgVoto.Focus()
        End If
    End Sub

    Private Sub dtgVoto_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgVoto.CellContentClick
        If (e.RowIndex <> -1) Then
            If (dtgVoto.Columns("chkVoto").Visible = True) Then
                dtgVoto.Item("chkVoto", e.RowIndex).Value = True
                If (dtgVoto.Item("chkVoto", e.RowIndex).Value = True) Then
                    For i = 0 To dtgVoto.RowCount - 1
                        If (i <> e.RowIndex) Then
                            dtgVoto.Item("chkVoto", i).Value = False
                        End If
                    Next
                End If
            End If
        End If
    End Sub

    Private Function verificarListado() As Boolean
        Dim resp As Boolean = False
        If (dtgVoto.Columns("chkVoto").Visible = True) Then
            For i = 0 To dtgVoto.RowCount - 1
                If (dtgVoto.Item("chkVoto", i).Value = True) Then
                    resp = True
                End If
            Next
        ElseIf (dtgVoto.Columns("txtPuntos").Visible = True) Then
            resp = True
            For i = 0 To dtgVoto.RowCount - 1
                If (dtgVoto.Item("txtPuntos", i).Value = 0 Or dtgVoto.Item("txtPuntos", i).Value = "") Then
                    resp = False
                End If
            Next
        End If
        Return resp
    End Function
    Private Sub nuevo()
        dtgVoto.DataSource = Nothing
        txtNit.Text = ""
        txtNombres.Text = Nothing
    End Sub


    Private Sub dtgVoto_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgVoto.CellValueChanged
        If (carga_comp) Then
            Dim fila As Integer = e.RowIndex
            Dim col As String = "txtPuntos"
            If (dtgVoto.Item(col, fila).Value <> "") Then
                If (dtgVoto.Item(col, fila).Value = 0 Or dtgVoto.Item(col, fila).Value > 10) Then
                    MessageBox.Show("Los puntos deben estar entre 1 y 10 ", "Voto", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    dtgVoto.Item(col, fila).Value = ""
                End If
            End If

        End If
    End Sub

    Private Sub btnVotar1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVotar1.Click
        dtgVoto.CurrentCell = Nothing
        Dim nit As Double = 0
        Dim puntos As Integer = 0
        Dim resp As Integer = 0
        Dim marcar As Integer = 0
        If (objVotacionesLn.verificarVotante(txtNit.Text)) Then
            If (verificarListado()) Then
                If (dtgVoto.Columns("chkVoto").Visible = True) Then
                    For i = 0 To dtgVoto.RowCount - 1
                        If (dtgVoto.Item("chkVoto", i).Value = True) Then
                            nit = dtgVoto.Item("nit", i).Value
                            puntos = 1
                            i = dtgVoto.RowCount - 1
                            resp = objVotacionesLn.sumarPuntos(puntos, nit)
                        End If
                    Next
                ElseIf (dtgVoto.Columns("txtPuntos").Visible = True) Then
                    For i = 0 To dtgVoto.RowCount - 1
                        nit = dtgVoto.Item("nit", i).Value
                        puntos = dtgVoto.Item("txtPuntos", i).Value
                        resp = objVotacionesLn.sumarPuntos(puntos, nit)

                    Next
                End If
                If (resp >= 1) Then
                    marcar = objVotacionesLn.marcarVotante(txtNit.Text)
                    nuevo()
                    MessageBox.Show("Su voto se ingreso en forma exitosa", "Voto", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("No se ingreso ningun voto, verifique sus datos ", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        Else
            MessageBox.Show("La cédula " & txtNit.Text & " ya realizo su voto, el cual solo es permitido una ves! ", "Voto", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub btnNuevo1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo1.Click
        nuevo()
    End Sub

    Private Sub btnPpal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPpal.Click
        FrmPrincipal.Show()
        Me.Close()
    End Sub

    Private Sub btnSalir1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir1.Click
        FrmLogin.Show()
        FrmPrincipal.Close()
        Me.Close()
    End Sub

End Class