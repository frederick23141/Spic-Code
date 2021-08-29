Imports logicaNegocios
Imports entidadNegocios
Public Class Frm_consultar_encuesta_cli
    Private objOpSimplesLn As New Op_simpesLn
    Private objIngresoProdLn As New Ing_prodLn
    Private objOperacionesForm As OperacionesFormularios = New OperacionesFormularios
    Private carga_comp As Boolean = False

    Private Sub Frm_consultar_eval_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cboFechaIni.Value = Now.AddYears(-1)
        cboFechaFin.Value = Now
    End Sub
    Public Sub Main(ByVal objUsuarioEn As UsuarioEn)
        carga_comp = True
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

    Private Sub txtNombres_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNombres.TextChanged
        If (txtNombres.Text <> "") Then
            If (txtNombres.Text.Length >= 4) Then
                txtNit.Text = ""
            End If
        End If
    End Sub

    Private Sub txtNit_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNit.TextChanged
        If (txtNit.Text <> "") Then
            If (txtNit.Text.Length >= 3) Then
                txtNombres.Text = ""
            End If
        End If
    End Sub
    Private Sub cargarConsulta()
        dtgConsulta.DataSource = Nothing
        Dim fecIni As String = objOpSimplesLn.cambiarFormatoFecha(cboFechaIni.Value)
        Dim fecFin As String = objOpSimplesLn.cambiarFormatoFecha(cboFechaFin.Value)
        Dim sql As String = ""
        Dim selectSql As String = "SELECT "
        Dim whereSql As String = "WHERE fecha >= '" & fecIni & "' AND fecha<= '" & fecFin & "' "
        Dim groupSql As String = "GROUP BY "
        Dim dt As New DataTable
        If (chk_consol_ciudad.Checked) Then
            selectSql &= "ciudad "
            groupSql &= "ciudad "
        End If
        If (chk_consol_pregunta.Checked) Then
            If (selectSql = "SELECT ") Then
                selectSql &= "id_pregunta,pregunta "
            Else
                selectSql &= ",id_pregunta,pregunta "
            End If
            If (groupSql = "GROUP BY ") Then
                groupSql &= "id_pregunta,pregunta "
            Else
                groupSql &= ",id_pregunta,pregunta "
            End If
        End If
        If (chk_consol_vend.Checked) Then
            If (selectSql = "SELECT ") Then
                selectSql &= "vendedor "
            Else
                selectSql &= ",vendedor "
            End If
            If (groupSql = "GROUP BY ") Then
                groupSql &= "vendedor "
            Else
                groupSql &= ",vendedor "
            End If
        End If
        If (chk_consol_ciudad.Checked = False And chk_consol_pregunta.Checked = False And chk_consol_vend.Checked = False) Then
            selectSql &= " id,fecha,nit,nombres,ciudad  "
            groupSql &= "id,fecha,nit,nombres,ciudad  "
        End If
        selectSql &= ",AVG(prom_cal) As prom_cal "
        selectSql &= "FROM J_v_encuesta_clientes  "
        If (txtNombres.Text <> "") Then
            whereSql &= "AND nombres like '%" & txtNombres.Text & "%'"
        ElseIf (txtNit.Text <> "") Then
            whereSql &= "AND nit like '%" & txtNit.Text & "%'"
        End If

        sql = selectSql & whereSql & groupSql
        dt = objIngresoProdLn.listar_datatable(sql, "CORSAN")
        dt.Columns.Add("Porc", GetType(Double))
        dt.Rows.Add()
        totalizar(dt)
        calcularPorc(dt)
        dtgConsulta.DataSource = dt
        dtgConsulta.Rows(dtgConsulta.Rows.Count - 1).DefaultCellStyle.BackColor = Color.Red
        dtgConsulta.Columns("prom_cal").DefaultCellStyle.Format = "N2"
        dtgConsulta.Columns("Porc").DefaultCellStyle.Format = "N1"

        If (chk_consol_ciudad.Checked Or chk_consol_pregunta.Checked Or chk_consol_vend.Checked) Then
            col_ver.Visible = False
            colBorrar.Visible = False
        Else
            dtgConsulta.Columns("fecha").DefaultCellStyle.Format = "d"
            dtgConsulta.Columns("id").Visible = False
            col_ver.Visible = True
            colBorrar.Visible = True
        End If


    End Sub
    Private Sub btn_consultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_consultar.Click
        img_procesar.Visible = True
        Application.DoEvents()
        cargarConsulta()
        img_procesar.Visible = False
    End Sub
    Private Sub totalizar(ByRef dt As DataTable)
        Dim sum As Double = 0
        For i = 0 To dt.Rows.Count - 2
            sum += dt.Rows(i).Item("prom_cal")
        Next
        If (sum > 0) Then
            dt.Rows(dt.Rows.Count - 1).Item("prom_cal") = sum / (dt.Rows.Count - 1)
        End If
    End Sub
    Private Sub calcularPorc(ByRef dt As DataTable)
        For i = 0 To dt.Rows.Count - 1
            If Not IsDBNull(dt.Rows(i).Item("prom_cal")) Then
                dt.Rows(i).Item("Porc") = (dt.Rows(i).Item("prom_cal") / 5) * 100
            End If
        Next
    End Sub
    Private Sub dtgConsulta_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgConsulta.CellContentClick
        If (e.RowIndex >= 0) Then
            Dim col As String = dtgConsulta.Columns(e.ColumnIndex).Name
            If (col = col_ver.Name) Then
                Dim id_encuesta As Integer = dtgConsulta.Item("id", e.RowIndex).Value
                Dim frm As New Frm_encuesta_clientes
                frm.Show()
                frm.cargarEncuesta(id_encuesta)
            ElseIf (col = colBorrar.Name) Then
                Dim id_encuesta As Integer = dtgConsulta.Item("id", e.RowIndex).Value
                Dim resp As Integer = MessageBox.Show("Esta seguro que desea eliminar esta evaluación? ", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If (resp = 6) Then
                    Dim listSql As New List(Of Object)
                    Dim sql As String
                    sql = "UPDATE J_encu_encabezado SET anulado = 1 WHERE id =" & id_encuesta
                    listSql.Add(sql)
                    If (objIngresoProdLn.ExecuteSqlTransaction(listSql, "CORSAN")) Then
                        cargarConsulta()
                        MessageBox.Show("El registro se elimino en forma correcta! ", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("Error al elimino el registro, verifique que la celda no este en blanco! ", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If

                End If
                'ElseIf (col = colPdf.Name) Then
                '    'cargarReporte(id_evaluacion, e.RowIndex)
            End If
        End If
    End Sub

    Private Sub btnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Click
        objOperacionesForm.ExportarDatosExcel(dtgConsulta, "Encuestas")
    End Sub

    Private Sub cboCategoria_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If (carga_comp) Then
            txtNit.Text = ""
            txtNombres.Text = ""
        End If
    End Sub

  
  
 
End Class