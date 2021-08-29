Imports logicaNegocios
Imports entidadNegocios
Public Class Frm_planillas_cargue
    Private objOperacionesForm As OperacionesFormularios = New OperacionesFormularios
    Private objOpSimplesLn As New Op_simpesLn
    Private objRelojLn As New RelojLn
    Private nomb_modulo As String
    Dim carga_comp As Boolean = False
    Dim fec_ini As Date
    Dim fec_fin As Date
    Dim id_cargue As Double = 0
    Dim usuario As UsuarioEn

    Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
        dtg_consulta.CurrentCell = Nothing
        imgProcesar.Visible = True
        Application.DoEvents()
        dtg_consulta.DataSource = Nothing
        cargar_datos()
        imgProcesar.Visible = False
    End Sub
    Public Sub MAIN(ByVal id_cargue As Double, ByVal usuario As UsuarioEn)
        Me.usuario = usuario
        Me.id_cargue = id_cargue
        cargar_datos()
    End Sub
    Private Sub cargar_datos()
        Dim tamano_letra As Single = 9.0!
        dtg_consulta.DataSource = Nothing
        Dim sFec_ini As String = objOpSimplesLn.cambiarFormatoFecha(cbo_fecha_ini.Value)
        Dim sFec_fin As String = objOpSimplesLn.cambiarFormatoFecha(cbo_fecha_fin.Value)
        Dim where_id As String = ""
        Dim order_by As String = " order by r.id"
        If id_cargue <> 0 Then

        End If
        Dim sql As String = "SELECT  r.id,r.placa,r.nit,t.nombres,r.num_rollos As rollos_planilla,(SELECT COUNT(id_requisicion) FROM J_alambron_importacion_det_rollos WHERE id_requisicion = r.id ) As rollos_descargados , r.peso_cargado,r.peso_descargado,(SELECT sum(peso) FROM J_alambron_importacion_det_rollos WHERE id_requisicion = r.id ) As peso_tiquetes,( r.peso_cargado - r.peso_descargado) As diferencia_factura,(( r.peso_cargado - r.peso_descargado)- (SELECT sum(peso) FROM J_alambron_importacion_det_rollos WHERE id_requisicion = r.id)) as dife_tique ,r.fecha_inicial,r.fecha_final  " &
                                  "FROM J_alambron_requisicion r , CORSAN.dbo.V_nom_personal_Activo_con_maquila_general t " &
                                     "WHERE r.nit = t.nit "
        Dim where_fec As String = ""
        If txt_id_req.Text <> "" Then
            where_id = " AND r.id =" & txt_id_req.Text & " "
        ElseIf txt_placa.Text <> "" Then
            where_id = " AND r.placa ='" & txt_placa.Text & "' "
        Else
            where_id = " AND r.fecha_inicial >= '" & objOpSimplesLn.cambiarFormatoFecha(cbo_fecha_ini.Value) & "' AND r.fecha_inicial <= '" & objOpSimplesLn.cambiarFormatoFecha(cbo_fecha_fin.Value) & " 23:59:59'"
        End If

        If id_cargue <> 0 Then
            where_fec = ""
            where_id = " AND r.id = " & id_cargue & " "
            id_cargue = 0
        End If
        sql &= where_fec & where_id & order_by
        Dim dt As DataTable = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")
        Dim sum As Double = 0
        dt.Rows.Add()
        For j = 0 To dt.Columns.Count - 1
            If dt.Columns(j).ColumnName = "rollos_planilla" Or dt.Columns(j).ColumnName = "rollos_descargados" Or dt.Columns(j).ColumnName = "peso_descargado" Or dt.Columns(j).ColumnName = "peso_cargado" Or dt.Columns(j).ColumnName = "diferencia" Then
                For i = 0 To dt.Rows.Count - 1
                    If Not IsDBNull(dt.Rows(i).Item(j)) Then
                        sum += dt.Rows(i).Item(j)
                    End If
                Next
                dt.Rows(dt.Rows.Count - 1).Item(j) = sum
                sum = 0
            End If
        Next
        dtg_consulta.DataSource = dt
        dtg_consulta.Columns("fecha_inicial").DefaultCellStyle.Format = "g"
        dtg_consulta.Columns("fecha_final").DefaultCellStyle.Format = "g"
        dtg_consulta.Columns("rollos_planilla").DefaultCellStyle = objOperacionesForm.formatoNegrita(tamano_letra)
        dtg_consulta.Columns("rollos_descargados").DefaultCellStyle = objOperacionesForm.formatoNegrita(tamano_letra)
        dtg_consulta.Rows(dtg_consulta.Rows.Count - 1).DefaultCellStyle = objOperacionesForm.formatoNegrita(tamano_letra)
        For i = 0 To dtg_consulta.RowCount - 1
            If IsNumeric(dtg_consulta.Item("rollos_planilla", i).Value) And IsNumeric(dtg_consulta.Item("rollos_descargados", i).Value) Then
                If dtg_consulta.Item("rollos_planilla", i).Value <> dtg_consulta.Item("rollos_descargados", i).Value Then
                    dtg_consulta.Item("rollos_planilla", i).Style.BackColor = Color.Red
                    dtg_consulta.Item("rollos_descargados", i).Style.BackColor = Color.Red
                End If
            End If
            If IsNumeric(dtg_consulta.Item("dife_tique", i).Value) Then
                If dtg_consulta.Item("dife_tique", i).Value <> 0 Then
                    dtg_consulta.Item("dife_tique", i).Style.BackColor = Color.Red
                End If
            End If
        Next
    End Sub

    Private Sub ToolStripSplitButton1_Click(sender As Object, e As EventArgs) Handles ToolStripSplitButton1.Click
        objOperacionesForm.ExportarDatosExcel(dtg_consulta, "Planiallas de cargue de alambrón")
    End Sub

    Private Sub dtg_consulta_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtg_consulta.CellClick
        If e.RowIndex >= 0 And e.RowIndex < dtg_consulta.RowCount - 1 Then
            If dtg_consulta.Columns(e.ColumnIndex).Name = col_ver_rollos.Name Then
                Dim frm As New Frm_auditoria_tiquetes
                Dim id_cargue As Double = dtg_consulta.Item("id", e.RowIndex).Value
                frm.Show()
                frm.Main(id_cargue, usuario)
                Me.WindowState = FormWindowState.Minimized
            End If
        End If
    End Sub

    Private Sub Frm_planillas_cargue_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cbo_fecha_ini.Value = Now.AddDays(-Now.Day + 1)
    End Sub

    Private Sub txt_id_req_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_id_req.KeyPress
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
End Class