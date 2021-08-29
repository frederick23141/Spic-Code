Imports System.Configuration
Imports logicaNegocios
Imports entidadNegocios
Imports System.IO
Imports Microsoft.Office.Interop
Public Class Frm_anticipo
    Dim vendedor As Int32
    Dim vendMin As Int32
    Dim vendMax As Int32
    Dim dtgSelect As String
    Private obj_anticipoLn As New anticipoLn
    Private obj_vtas_lin_ciuLn As New Vtas_vend_ciudLn
    Private objOperacionesForm As OperacionesFormularios = New OperacionesFormularios
    Private objOpSimplesLn As New Op_simpesLn
    Private nom_modulo As String = ""
    Public Sub Main(ByVal vend As Int32, ByVal nom_modulo As String, ByVal permiso As String)
        Me.nom_modulo = nom_modulo
        Dim min As Integer = vend
        Dim max As Integer = vend
        vendedor = vend
        If (vendedor = 1020) Then
            vendMin = 1001
            vendMax = 1099
        Else
            vendMin = vend
            vendMax = vend
        End If
        If (permiso <> "ADMIN" Or permiso <> "ADMIN_VENTAS") Then
            btnContCambios.Visible = False
        End If
        consultar()
    End Sub
    Private Sub btnContCambios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnContCambios.Click
        FrmAuditCambios.Show()
        FrmAuditCambios.Main(nom_modulo)
        FrmAuditCambios.WindowState = 2
    End Sub
    Private Sub Frm_anticipo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cboFecIni.Value = Now.AddMonths(-6)
        cboFecFin.Value = Now
        Dim fecIni As String = objOpSimplesLn.cambiarFormatoFecha(cboFecIni.Value)
        Dim fecFin As String = objOpSimplesLn.cambiarFormatoFecha(cboFecFin.Value)
        Dim ano = Now.Year
        Dim row As DataRow
        Dim dt As New DataTable
        Dim sql As String = "SELECT  departamento,descripcion  " & _
                               "FROM y_departamentos  " & _
                                    "ORDER BY descripcion"
        Dim sql_condicion As String = "SELECT condicion FROM condiciones_pago "
        dt = objOpSimplesLn.listar_datatable(sql_condicion, "CORSAN")
        row = dt.NewRow
        row("condicion") = "TODOS"
        dt.Rows.Add(row)
        cbo_condicion.DataSource = dt
        cbo_condicion.ValueMember = "condicion"
        cbo_condicion.DisplayMember = "condicion"
        cbo_condicion.SelectedValue = "TODOS"

        dt = New DataTable
        dt = obj_vtas_lin_ciuLn.listar_cbo(sql)
        row = dt.NewRow
        row("departamento") = 0
        row("descripcion") = "TODOS"
        dt.Rows.Add(row)
        cbo_dpto.DataSource = dt
        cbo_dpto.ValueMember = "departamento"
        cbo_dpto.DisplayMember = "descripcion"
        cbo_dpto.Text = "Seleccione"
        cbo_dpto.SelectedValue = 0
        cbo_ciudad.SelectedValue = 0
    End Sub
    Private Sub consultar()
        Dim fecIni As String = objOpSimplesLn.cambiarFormatoFecha(cboFecIni.Value)
        Dim fecFin As String = objOpSimplesLn.cambiarFormatoFecha(cboFecFin.Value)
        Dim dt As DataTable
        Dim row As DataRow
        Dim condicion As String = ""
        Dim sql As String = ""
        If (cbo_condicion.SelectedValue <> "TODOS") Then
            condicion = " AND ter.condicion = " & cbo_condicion.SelectedValue
        End If
        If (chkConsolidarVend.Checked) Then
            dt = obj_anticipoLn.consolidar_anticipo(fecIni, fecFin, vendMin, vendMax, condicion)
        Else
            dt = obj_anticipoLn.listar_anticipo(fecIni, fecFin, vendMin, vendMax, condicion)
        End If
        row = dt.NewRow
        dt.Rows.Add(row)
        dtg_anticipo.DataSource = dt
        txtNit.Text = ""
        txtNombres.Text = ""
        totalisar_grid(dtg_anticipo)
        formatoNegrita(dtg_anticipo)
        If Not (chkConsolidarVend.Checked Or chkConsClient.Checked) Then
            dtg_anticipo.Columns("fecha").DefaultCellStyle.Format = "d"
        End If
        listarPendSinAnt(condicion, fecIni, fecFin)

    End Sub
    Private Sub listarPendSinAnt(ByVal condicion As String, ByVal fecIni As String, ByVal fecFin As String)
        If (condicion = "") Then
            condicion = "AND pend.condicion in (201,208)"
        Else
            condicion = "AND pend.condicion = 201"
        End If
        Dim sql As String = "SELECT pend.vendedor, pend.nit,pend.nombres,pend.condicion,pend.codigo,pend.descripcion,pend.fecha,pend.numero,pend.valor_unitario ,pend.Cant_pedida,pend.cantidad_despachada,pend.Pendiente,pend.kilos,pend.notas,pend.autoriz_texto,pend.autorizacion " & _
                                 "FROM J_v_pend_vend pend  " & _
                                  "WHERE nit not in (select nit from J_v_anticipos where  fecha>='" & fecIni & "' AND fecha<='" & fecFin & "') AND pend.vendedor >=" & vendMin & " and pend.vendedor <= " & vendMax & " " & condicion & ""
        dtgPendSinAnt.DataSource = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        dtgPendSinAnt.Columns("fecha").DefaultCellStyle.Format = "d"
    End Sub
    Private Sub txtNit_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNit.TextChanged
        txtNombres.Text = ""
        Dim condicion As String = ""
        If (cbo_condicion.SelectedValue <> "TODOS") Then
            condicion = " AND ter.condicion = " & cbo_condicion.SelectedValue
        End If
        If (txtNit.Text <> "" And txtNit.Text.Length > 2) Then
            dtg_anticipo.DataSource = obj_anticipoLn.listar_anticipo_nit(vendMin, vendMax, txtNit.Text, condicion)
        ElseIf (txtNit.Text = "") Then
            consultar()
        End If
    End Sub
    Private Sub txtNit_keyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNit.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub
    Private Sub txtNombres_keyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNombres.KeyPress
        If Not Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtNombres_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNombres.TextChanged
        txtNit.Text = ""
        Dim condicion As String = ""
        If (cbo_condicion.SelectedValue <> "TODOS") Then
            condicion = " AND ter.condicion = " & cbo_condicion.SelectedValue
        End If
        If (txtNombres.Text <> "" And txtNombres.Text.Length > 2) Then
            dtg_anticipo.DataSource = obj_anticipoLn.listar_anticipo_nomb(vendMin, vendMax, txtNombres.Text, condicion)
        ElseIf (txtNombres.Text = "") Then
            consultar()
        End If
    End Sub
    Private Sub totalisar_grid(ByVal dtg As DataGridView)
        Dim total As Double = 0
        Dim colIni As Integer = 0
        If Not (chkConsolidarVend.Checked) Then
            dtg.Item("nombres", dtg.RowCount - 1).Value = "TOTALES"
        End If
        For i = 0 To dtg_anticipo.ColumnCount - 1
            If (dtg.Columns(i).Name = "valor_total") Then
                colIni = i
                i = dtg_anticipo.ColumnCount - 1
            End If
        Next
        For j = colIni To dtg.ColumnCount - 1
            For i As Integer = 0 To dtg.RowCount - 1
                If Not IsDBNull(dtg.Item(j, i).Value) Then
                    total = total + CDbl(dtg.Item(j, i).Value)
                End If
            Next
            dtg.Item(j, dtg.RowCount - 1).Value = total
            total = 0
        Next
    End Sub
    Public Sub formatoNegrita(ByVal dtg As DataGridView)
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        dtg.Rows(dtg.RowCount - 1).DefaultCellStyle = DataGridViewCellStyle1
    End Sub
    Private Sub cbo_dpto_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_dpto.SelectedIndexChanged
        Dim dpto_text As String = cbo_dpto.Text
        Dim dpto As String
        Dim sql As String = ""
        Dim row As DataRow
        Dim dt As New DataTable
        If (dpto_text <> "System.Data.DataRowView" And dpto_text <> ".") Then
            dpto = cbo_dpto.SelectedValue
            If (dpto = "todos") Then
                sql = "SELECT  ciudad  ,descripcion " & _
                                    "FROM y_ciudades  " & _
                                         "ORDER BY descripcion "
            Else
                sql = "SELECT  ciudad  ,descripcion " & _
                                    "FROM y_ciudades  " & _
                                          "WHERE departamento = " & dpto & " " & _
                                             "ORDER BY  descripcion "
            End If

            dt = obj_vtas_lin_ciuLn.listar_cbo(sql)
            row = dt.NewRow
            row("ciudad") = 0
            row("descripcion") = "TODOS"
            dt.Rows.Add(row)
            cbo_ciudad.DataSource = dt
            cbo_ciudad.ValueMember = "ciudad"
            cbo_ciudad.DisplayMember = "descripcion"
            cbo_ciudad.Text = "Seleccione"
        End If
    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        FrmLogin.Show()
        FrmPrincipal.Close()
        Me.Close()
    End Sub

    Private Sub btn_ppal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ppal.Click
        FrmPrincipal.Show()
        Me.Close()
    End Sub

    Private Sub btn_exportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exportar.Click
        objOperacionesForm.ExportarDatosExcel(dtg_anticipo, "Anticipos")
    End Sub


    Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
        consultar()
    End Sub

    Private Sub chkConsolidar_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkConsolidarVend.CheckedChanged
        consultar()
    End Sub

    Private Sub chkConsClient_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkConsClient.CheckedChanged
        Dim fecIni As String = objOpSimplesLn.cambiarFormatoFecha(cboFecIni.Value)
        Dim fecFin As String = objOpSimplesLn.cambiarFormatoFecha(cboFecFin.Value)
        Dim condicion As String = ""
        If (cbo_condicion.SelectedValue <> "TODOS") Then
            condicion = " AND ter.condicion = " & cbo_condicion.SelectedValue
        End If
        If (chkConsClient.Checked) Then
            Dim ultFila As Integer = 0
            Dim dt As DataTable
            Dim row As DataRow
            Dim sql As String = "SELECT doc.vendedor ,doc.nit,ter.nombres,ter.condicion,doc.tipo,SUM (doc.valor_total)As valor_total,SUM (doc.valor_aplicado)As valor_aplicado,SUM(doc.valor_total - doc.valor_aplicado - doc.iva_fletes) as Saldo,(SELECT SUM (pend.Vr_total )FROM J_v_pend_vend pend WHERE pend.nit = doc.nit )As Pendientes " & _
                                      "FROM documentos doc ,terceros ter " & _
                                       "WHERE ter.nit= doc.nit AND doc.sw Like '5' AND doc.vendedor >=" & vendMin & " and doc.vendedor <= " & vendMax & " AND doc.tipo='RCR1' AND  doc.fecha>='" & fecIni & "' " & condicion & " AND  doc.fecha<='" & fecFin & "' AND(doc.valor_total>doc.valor_aplicado or (doc.iva_fletes <0   AND doc.valor_total=doc.valor_aplicado)) " & _
                                        "GROUP BY doc.vendedor,doc.nit,ter.condicion,doc.tipo,ter.nombres "
            dt = objOpSimplesLn.listar_datatable(sql, "CORSAN")
            row = dt.NewRow
            dt.Rows.Add(row)
            dtg_anticipo.DataSource = dt
            ultFila = dtg_anticipo.RowCount - 1
            txtNit.Text = ""
            txtNombres.Text = ""
            dtg_anticipo.Item("nombres", ultFila).Value = "TOTAL"
            dtg_anticipo.Item("valor_total", ultFila).Value = sumarCol("valor_total")
            dtg_anticipo.Item("valor_aplicado", ultFila).Value = sumarCol("valor_aplicado")
            dtg_anticipo.Item("Saldo", ultFila).Value = sumarCol("Saldo")
            dtg_anticipo.Item("Pendientes", ultFila).Value = sumarCol("Pendientes")
            formatoNegrita(dtg_anticipo)
        Else
            consultar()
        End If
        listarPendSinAnt(condicion, fecIni, fecFin)
    End Sub
    Private Function sumarCol(ByVal col As String) As Double
        Dim sum As Double = 0
        For i = 0 To dtg_anticipo.RowCount - 1
            If Not (IsDBNull(dtg_anticipo.Item(col, i).Value)) Then
                sum += dtg_anticipo.Item(col, i).Value
            End If
        Next
        Return sum
    End Function

    Private Sub VerDetalleToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VerDetalleToolStripMenuItem.Click
        'Dim fila As Integer = dtg_anticipo.CurrentCell.RowIndex
        Dim fila As Integer
        Dim nit As String = ""
        If (dtgSelect = "dtg_anticipo") Then
            fila = dtg_anticipo.CurrentCell.RowIndex
            nit = dtg_anticipo("nit", fila).Value
        ElseIf (dtgSelect = "dtgPendSinAnt") Then
            fila = dtgPendSinAnt.CurrentCell.RowIndex
            nit = dtgPendSinAnt("nit", fila).Value
        End If
        If (fila >= 0) Then
            frmPendientes.Show()
            frmPendientes.cargarInfoClient(nit)
            frmPendientes.Activate()
        End If

    End Sub
    Private Sub dtg_anticipo_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dtg_anticipo.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            dtgSelect = dtg_anticipo.Name
            With (Me.dtg_anticipo)
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                End If
            End With
        End If
    End Sub

    Private Sub dtgPendSinAnt_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dtgPendSinAnt.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            dtgSelect = dtgPendSinAnt.Name
            With (Me.dtgPendSinAnt)
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                End If
            End With
        End If
    End Sub
    Private Sub chk201_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        consultar()
    End Sub
End Class