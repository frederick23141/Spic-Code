Imports System.Configuration
Imports logicaNegocios
Imports entidadNegocios
Imports System.IO
Imports Microsoft.Office.Interop
Public Class FrmConsulVotacion
    Private objVotacionesLn As New VotacionesLn
    Dim carga_comp As Boolean = False
    Private objOperacionesForm As OperacionesFormularios = New OperacionesFormularios
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
    Private Sub cargarGrid()
        If (carga_comp) Then
            Dim selectSql As String = "  SELECT vot.puntos ,ter.nombres ,ter.nit,tipoV.descripcion As T_voto , grup.descripcion As Area,(SELECT CASE (vot.votante) WHEN 1 THEN 'Si'ElSE 'No' END )As Votante, " & _
                                        "(select COUNT(voto.id_tercero ) " & _
                                        " from J_votaciones voto , terceros terc  " & _
                                        "where voto.votante = 1 and terc.nit = voto.id_tercero and terc.grupo_vot= ter.grupo_vot ) as numVotantesEnArea "
            Dim fromSql As String = "		FROM J_votaciones vot,terceros ter, Jjv_tipo_voto tipoV , Jjv_grupos_votaciones grup "
            Dim whereSql As String = " WHERE ter.nit = vot.id_tercero AND tipoV.id = vot.tipo_voto  AND ter.grupo_vot is not  null AND grup.id = ter.grupo_vot "
            Dim strSql As String = ""
            If txtNombres.Text <> "" Then

                whereSql += " AND ter.nombres LIKE '%" & txtNombres.Text & "%' "

            ElseIf txtNombres.Text = "" Then
                whereSql += " AND  ter.grupo_vot = " & cboArea.SelectedValue & " "


            End If
            strSql = selectSql & fromSql & whereSql
            dtgGestGrup.DataSource = objVotacionesLn.listar_datatable(strSql)
            dtgGestGrup.Columns("nit").Visible = False
            pintarVotantes()

        End If
    End Sub

    Private Sub txtNombres_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNombres.TextChanged
        cargarGrid()
    End Sub

    Private Sub FrmGestGrupVot_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim sql As String = "select id,Descripcion from Jjv_grupos_votaciones  "
        cboArea.DataSource = objVotacionesLn.listar_datatable(sql)
        cboArea.ValueMember = "id"
        cboArea.DisplayMember = "Descripcion"
        cboArea.Text = "Seleccione"
        cargarGrid()
        carga_comp = True
    End Sub
   
    Private Sub cboArea_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboArea.SelectedIndexChanged
        If (carga_comp) Then
            txtNombres.Text = ""
            cargarGrid()
        End If
    End Sub
    Public Sub pintarVotantes()
        For i = 0 To dtgGestGrup.RowCount - 1
            If (dtgGestGrup.Item("Votante", i).Value = "Si") Then
                dtgGestGrup.Item("Votante", i).Style.BackColor = Color.GreenYellow
            Else
                dtgGestGrup.Item("Votante", i).Style.BackColor = Color.Red
            End If
        Next
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
    Private Sub btn_exportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exportar.Click
        objOperacionesForm.ExportarDatosExcel(dtgGestGrup, "Votaciones : " & cboArea.Text)
    End Sub
End Class