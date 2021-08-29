Imports System.Configuration
Imports logicaNegocios
Imports System.IO
Imports entidadNegocios
Imports Microsoft.Office.Interop
Public Class Frm_vtas_vend_ciud
    Private objUsuarioLn As New UsuarioLn
    Private objUsuarioEn As New UsuarioEn
    Private obj_vtas_lin_ciuLn As New Vtas_vend_ciudLn
    Private objOperacionesForm As OperacionesFormularios = New OperacionesFormularios
    Private carga_comp As Boolean = False
    Private obj_op_simplesLn As New Op_simpesLn
    Private nom_modulo As String
    Public Sub Main(ByVal nom_modulo As String, ByVal permiso As String, ByVal objUsuarioEn As UsuarioEn)
        Me.nom_modulo = nom_modulo
        If (permiso <> "ADMIN") Then
            btnContCambios.Visible = False
        End If
        Me.objUsuarioEn = objUsuarioEn
    End Sub
    Private Sub btnContCambios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnContCambios.Click
        FrmAuditCambios.Show()
        FrmAuditCambios.Main(nom_modulo)
        FrmAuditCambios.WindowState = 2
    End Sub
    Private Sub Frm_vtas_lin_ciud_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim vendedores As String = objUsuarioLn.coordinadorVend(objUsuarioEn.usuario)
        Dim ano = Now.Year
        While (ano >= Now.Year - 5)
            cboAñoIni.Items.Add(ano)
            cboAñoFin.Items.Add(ano)
            ano -= 1
        End While
        Dim row As DataRow
        Dim dt As New DataTable
        Dim sql As String = ""
        Dim criterioVendedor As String = ""
        If (vendedores <> "") Then
            criterioVendedor = " vendedor in (" & vendedores & ")"
        Else
            criterioVendedor = " vendedor >= 1001 AND vendedor <= 1099"
        End If

        sql = "select vendedor,nombre_vendedor FROM v_vendedores WHERE bloqueo =0 AND " & criterioVendedor & " ORDER BY nombre_vendedor"
        dt = New DataTable
        dt = obj_vtas_lin_ciuLn.listar_cbo(sql)
        row = dt.NewRow
        row("vendedor") = 0
        row("nombre_vendedor") = "TODOS"
        dt.Rows.Add(row)
        cbo_vend.DataSource = dt
        cbo_vend.ValueMember = "vendedor"
        cbo_vend.DisplayMember = "nombre_vendedor"
        cbo_vend.Text = "Seleccione"
        carga_comp = True
    End Sub
    Private Function sumarColumnas(ByVal nomColumna As String, ByVal dtg As DataGridView) As Double
        Dim total As Double = 0
        For i As Integer = 0 To dtg.RowCount - 2
            If Not (IsDBNull(dtg.Item(nomColumna.ToLower, i).Value)) Then
                total = total + CDbl(dtg.Item(nomColumna.ToLower, i).Value)
            End If
        Next
        If (nomColumna = "Porc_util") Then
            total = total / dtg.RowCount - 2
        End If
        Return total
    End Function

    Private Sub PrincipalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FrmPrincipal.Show()
        Me.Close()
        FrmPrincipal.Activate()
    End Sub

    Private Sub SalirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FrmLogin.Show()
        FrmPrincipal.Close()
        Me.Close()
    End Sub

    Private Sub ExportarAExcelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        objOperacionesForm.ExportarDatosExcel(dtg_consulta, "Ventas - linea de producion  ")
    End Sub


    Private Sub cbo_vend_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_vend.SelectedIndexChanged
        If (carga_comp) Then
            chk_ciudades.Items.Clear()
            Dim vend As Integer = cbo_vend.SelectedValue
            Dim sql As String = "select ter.ciudad   from documentos_ped doc, terceros ter  where(doc.vendedor = 1028 And ter.nit = doc.nit) group by ter.ciudad  order by ter.ciudad "
            Dim lista As New List(Of Object)
            lista = obj_op_simplesLn.lista(sql)
            For i As Integer = 0 To lista.Count - 1 Step 1
                chk_ciudades.Items.Add(lista(i))
            Next
        End If
    End Sub
    Private Sub dtg_consulta_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtg_consulta.CellDoubleClick
        If (e.RowIndex >= 0) Then
            Dim mesini As Integer = cboMesIni.SelectedIndex + 1
            Dim añoIni As Integer = cboAñoIni.Text
            Dim mesFin As Integer = cboMesFin.SelectedIndex + 1
            Dim añoFin As Integer = cboAñoFin.Text
            Dim dia_fin As Integer = DateSerial(añoFin, mesFin + 1, 0).Day
            Dim fec_ini As String = añoIni & "/" & mesini & "/01"
            Dim fec_max As String = añoFin & "/" & mesFin & "/" & dia_fin
            Dim nit As Double = dtg_consulta.Item("nit", dtg_consulta.CurrentCell.RowIndex).Value
            Dim sql As String = "SELECT ter.ciudad,ter.nombres,vtas.nit,vtas.codigo,vtas.descripcion,SUM (vtas.KILOS) as Kilos,SUM(vtas.Vr_total)As Vr_total,SUM(vtas.Cto_total) as Cto_total,(SELECT CASE SUM(vtas.Vr_total) WHEN 0 THEN 0 ELSE((SUM(vtas.Vr_total)  - SUM(vtas.Cto_total) ) /SUM(vtas.Vr_total)  *100 )END)AS Porc_util " & _
                                                  "FROM Jjv_V_vtas_vend_cliente_ref vtas, terceros ter " & _
                                                           "WHERE ter.nit = vtas.nit AND vtas.nit = " & nit & " AND vtas.fec >= '" & fec_ini & "' AND vtas.fec<= '" & fec_max & "'" & _
                                                               " GROUP BY ter.nombres,vtas.nit,vtas.codigo,vtas.descripcion,ter.ciudad"
            dtg_detalle.DataSource = obj_vtas_lin_ciuLn.listar_vtas_lin_ciud(sql)
        End If
    End Sub
    Private Sub btn_exportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exportar.Click
        objOperacionesForm.ExportarDatosExcel(dtg_consulta, "Detalle ventas")
    End Sub

    Private Sub btn_ppal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ppal.Click
        FrmPrincipal.Show()
        Me.Close()
        FrmPrincipal.Activate()
    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        FrmLogin.Show()
        FrmPrincipal.Close()
        Me.Close()
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        If (cboAñoFin.Text <> "" And cboMesIni.Text <> "" And cboAñoIni.Text <> "" And cboMesFin.Text <> "" And cbo_vend.Text <> "Seleccione" And (chk_ciudades.CheckedItems.Count > 0 Or chkTodos.Checked <> False)) Then
            Dim mesini As Integer = cboMesIni.SelectedIndex + 1
            Dim añoIni As Integer = cboAñoIni.Text
            Dim mesFin As Integer = cboMesFin.SelectedIndex + 1
            Dim añoFin As Integer = cboAñoFin.Text
            Dim dia_fin As Integer = DateSerial(añoFin, mesFin + 1, 0).Day
            Dim fec_ini As String = añoIni & "/" & mesini & "/01"
            Dim fec_max As String = añoFin & "/" & mesFin & "/" & dia_fin
            Dim where_ciud As String = "("
            Dim vend As Integer = cbo_vend.SelectedValue
            Dim where_vend As String = " vtas.vendedor=" & vend & " AND "
            Dim dt As New DataTable
            Dim dr As DataRow

            Dim groupCuid As String = ",ter.ciudad "
            'If (cbo_ciudad.Text <> "TODOS") Then
            '    where_ciud = "AND vtas.ciudad = '" & cbo_ciudad.Text & "'"
            'End If
          
            If Not (chkTodos.Checked) Then
                For i As Integer = 0 To chk_ciudades.CheckedItems.Count - 1
                    If (i = 0) Then
                        If (i = chk_ciudades.CheckedItems.Count - 1) Then
                            where_ciud += "ter.ciudad like '%" & chk_ciudades.CheckedItems(i).ToString & "%' )"
                        Else
                            where_ciud += "ter.ciudad like '%" & chk_ciudades.CheckedItems(i).ToString & "%' "
                        End If
                    ElseIf (i = chk_ciudades.CheckedItems.Count - 1) Then
                        where_ciud += "OR ter.ciudad like '%" & chk_ciudades.CheckedItems(i).ToString & "%')"

                    Else
                        where_ciud += "OR ter.ciudad like '%" & chk_ciudades.CheckedItems(i).ToString & "%'"
                    End If
                Next
                where_ciud += " AND "
            Else
                where_ciud = ""
                groupCuid = ""
            End If
            If (chkVendHoy.Checked) Then
                where_vend = " vtas.vend_hoy=" & vend & " AND "
            Else
                where_vend = " vtas.vendedor=" & vend & " AND "
            End If
            If (vend = 0) Then
                carga_comp = False
                where_vend = ""
                carga_comp = True
            End If
            


            Dim sql As String = "SELECT vtas.vendedor,vtas.vend_hoy,ter.ciudad,y.descripcion AS departamento,ter.nombres,vtas.nit,SUM (vtas.KILOS) as Kilos,SUM(vtas.Vr_total)As Vr_total,SUM(vtas.Cto_total) as Cto_total,(SELECT CASE WHEN SUM(vtas.Vr_total) = 0 THEN 0 ELSE((SUM(vtas.Vr_total)  - SUM(vtas.Cto_total) ) /SUM(vtas.Vr_total)  *100 )END)AS Porc_util " & _
                         "FROM Jjv_V_vtas_vend_cliente_ref vtas, terceros ter ,y_departamentos y " & _
                                  "WHERE y.departamento = ter.y_dpto AND ter.nit = vtas.nit AND " & where_ciud & " " & where_vend & " vtas.fec >= '" & fec_ini & "' AND vtas.fec<= '" & fec_max & "'" & _
                                      " GROUP BY ter.nombres,vtas.nit,ter.ciudad ,vtas.vendedor,vtas.vend_hoy,y.descripcion "

            dt = obj_vtas_lin_ciuLn.listar_vtas_lin_ciud(sql)
            dr = dt.NewRow()
            dr("nombres") = "TOTAL"
            dt.Rows.Add(dr)
            dtg_consulta.DataSource = dt

            dtg_consulta.Item("Kilos", dtg_consulta.RowCount - 1).Value = sumarColumnas("Kilos", dtg_consulta)
            dtg_consulta.Item("Vr_total", dtg_consulta.RowCount - 1).Value = sumarColumnas("Vr_total", dtg_consulta)
            dtg_consulta.Item("Cto_total", dtg_consulta.RowCount - 1).Value = sumarColumnas("Cto_total", dtg_consulta)
            dtg_consulta.Item("Porc_util", dtg_consulta.RowCount - 1).Value = sumarColumnas("Porc_util", dtg_consulta)
            dtg_consulta.Columns("Porc_util").DefaultCellStyle.Format = "N2"

            dtg_consulta.Rows(dtg_consulta.RowCount - 1).DefaultCellStyle.ForeColor = Color.Red
            dtg_consulta.Rows(dtg_consulta.RowCount - 1).DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Else
            MessageBox.Show("Seleccione todos los items para generar el informe! ", "Seleccione", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Private Sub cboMesIni_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMesIni.SelectedIndexChanged
        If Not (carga_comp = False Or cboAñoFin.Text = "" Or cboMesIni.Text = "" Or cboAñoIni.Text = "" Or cboMesFin.Text = "" Or chk_ciudades.CheckedItems.Count = 0 Or cbo_vend.Text = "Seleccione") Then
            btnBuscar.PerformClick()
        End If
    End Sub

    Private Sub cboAñoIni_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAñoIni.SelectedIndexChanged
        If Not (carga_comp = False Or cboAñoFin.Text = "" Or cboMesIni.Text = "" Or cboAñoIni.Text = "" Or cboMesFin.Text = "" Or chk_ciudades.CheckedItems.Count = 0 Or cbo_vend.Text = "Seleccione") Then
            btnBuscar.PerformClick()
        End If
    End Sub

    Private Sub cboMesFin_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMesFin.SelectedIndexChanged
        If Not (carga_comp = False Or cboAñoFin.Text = "" Or cboMesIni.Text = "" Or cboAñoIni.Text = "" Or cboMesFin.Text = "" Or chk_ciudades.CheckedItems.Count = 0 Or cbo_vend.Text = "Seleccione") Then
            btnBuscar.PerformClick()
        End If
    End Sub

    Private Sub cboAñoFin_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAñoFin.SelectedIndexChanged
        If Not (carga_comp = False Or cboAñoFin.Text = "" Or cboMesIni.Text = "" Or cboAñoIni.Text = "" Or cboMesFin.Text = "" Or chk_ciudades.CheckedItems.Count = 0 Or cbo_vend.Text = "Seleccione") Then
            btnBuscar.PerformClick()
        End If
    End Sub

    Private Sub infoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles infoToolStripMenuItem.Click
        Dim nit As Integer
        nit = dtg_detalle("nit", dtg_detalle.CurrentCell.RowIndex).Value
        frmPendientes.Show()
        frmPendientes.cargarInfoClient(nit)
        frmPendientes.Activate()
    End Sub
    Private Sub dtg_detalle_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dtg_detalle.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            With (Me.dtg_detalle)
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                End If
            End With
        End If
    End Sub

    Private Sub chkTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTodos.CheckedChanged
        If (chkTodos.Checked) Then
            chk_ciudades.Enabled = False
        Else
            chk_ciudades.Enabled = True
        End If
    End Sub

    Private Sub chkVendHoy_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not (carga_comp = False Or cboAñoFin.Text = "" Or cboMesIni.Text = "" Or cboAñoIni.Text = "" Or cboMesFin.Text = "" Or chk_ciudades.CheckedItems.Count = 0 Or cbo_vend.Text = "Seleccione") Then
            btnBuscar.PerformClick()
        End If
    End Sub

End Class