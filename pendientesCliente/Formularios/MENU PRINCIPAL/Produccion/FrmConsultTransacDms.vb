Imports logicaNegocios
Public Class FrmConsultTransacDms

    Private objOpSimplesLn As New Op_simpesLn
    Private obj_Ing_prodLn As New Ing_prodLn
    Private cargaComp As Boolean = False
    Private objOperacionesForm As New OperacionesFormularios
    Private nom_modulo As String
    Private permiso As String = ""
    Public Sub Main(ByVal nom_modulo As String, ByVal permiso As String)
        Me.permiso = permiso
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
    Private Sub FrmConsultTransacDms_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim sql As String = "SELECT tipo " & _
                               "FROM documentos " & _
                                   "GROUP BY tipo "
        cboTipo.DataSource = obj_Ing_prodLn.listar_datatable(sql, "CORSAN")
        cboTipo.ValueMember = "tipo"
        cboTipo.DisplayMember = "tipo"
        cboTipo.Text = "Seleccione"
        cbo_fecha_ini.Value = Now.AddDays(-1)
        Dim sql_bodega As String = "SELECT CAST(bodega As varchar(25))  As bodega, CAST(bodega As varchar(25)) + '-' + descripcion As descripcion  FROM bodegas  "
        Dim dt_bodega As DataTable = objOpSimplesLn.listar_datatable(sql_bodega, "CORSAN")
        dt_bodega.Rows.Add()
        dt_bodega.Rows(dt_bodega.Rows.Count - 1).Item("bodega") = "TODO"
        dt_bodega.Rows(dt_bodega.Rows.Count - 1).Item("descripcion") = "TODO"
        cboBodega.DataSource = dt_bodega
        cboBodega.ValueMember = "bodega"
        cboBodega.DisplayMember = "descripcion"
        cboBodega.SelectedValue = "TODO"
        cargaComp = True
    End Sub
    Private Sub btnActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActualizar.Click
        imgProcesar.Visible = True
        Application.DoEvents()
        cargarCosulta()
        imgProcesar.Visible = False
    End Sub
    Private Sub cargarCosulta()
        cargaComp = False
        dtg_consulta.DataSource = Nothing
        Dim fecIni As String = objOpSimplesLn.cambiarFormatoFecha(cbo_fecha_ini.Value)
        Dim fecfin As String = objOpSimplesLn.cambiarFormatoFecha(cbo_fecha_fin.Value)
        Dim codigo As String = txtCodigo.Text
        Dim tipo As String = cboTipo.Text
        Dim numero As String = txtNumero.Text.Trim
        Dim whereCodigo As String = ""
        Dim whereTipo As String = ""
        Dim whereNumero As String = ""
        Dim whereMp As String = ""
        Dim whereMaquina As String = ""
        Dim whereBod As String = ""
        Dim sql As String = ""
        Dim dt As DataTable
        Dim row As DataRow
        Dim whereFec As String = ""
        Dim whereOrden As String = ""

        If (txtOrdenProd.Text <> "" And chkConsolidar.Checked = False) Then
            whereOrden = " AND lin.adicional like '%" & txtOrdenProd.Text & "%' "
        ElseIf (txtNumero.Text <> "") Then
            whereNumero = "AND lin.numero like '" & numero & "%'"
            If (cboTipo.Text <> "TODO" And cboTipo.Text <> "Seleccione") Then
                whereTipo = "AND doc.tipo = '" & tipo & "'"
            End If
        Else
            If cboBodega.SelectedValue <> "TODO" Then
                whereBod = " AND lin.bodega = " & cboBodega.SelectedValue & " "
            End If
            whereFec = " AND lin.fec >='" & fecIni & "' AND lin.fec <='" & fecfin & "  23:59:59'"

            If (codigo.Trim <> "") Then
                whereCodigo = "AND lin.codigo like '" & codigo & "%'"
                chkTodoCod.Checked = False
            Else
                chkTodoCod.Checked = True
            End If
            If (cboTipo.Text <> "TODO" And cboTipo.Text <> "Seleccione") Then
                whereTipo = "AND doc.tipo = '" & tipo & "'"
                chkTodoTipo.Checked = False
            Else
                chkTodoTipo.Checked = True
            End If
            If (chk_reproceso.Checked Or chkAlambron.Checked) Then
                If (chk_reproceso.Checked And chkAlambron.Checked) Then
                    whereMp = ""
                ElseIf (chk_reproceso.Checked) Then
                    whereMp = " AND doc.mp = 'R' "
                ElseIf (chkAlambron.Checked) Then
                    whereMp = " AND (doc.mp = 'A' or doc.mp is null or doc.mp = '')"
                End If
            End If
            If (txt_maquina.Text.Trim <> "") Then
                whereMaquina = "AND lin.adicional like '%No." & txt_maquina.Text.Trim & "%'"
            End If
            End If
            If (chkConsolidar.Checked) Then
            sql = "SELECT lin.tipo,lin.codigo As código,ref.descripcion,SUM(lin.cantidad)As cantidad,(SUM(lin.cantidad) * AVG(ref.conversion)) As kilos,SUM(lin.valor_unitario) As vr_unitario ,SUM (lin.valor_unitario * lin.cantidad)As vr_total,SUM (lin.costo_unitario * lin.cantidad)As costo_total,lin.bodega " & _
           "FROM documentos_lin lin , documentos doc, referencias ref " & _
                  "WHERE   doc.numero = lin.numero AND lin.tipo = doc.tipo " & whereFec & "  " & whereCodigo & " " & whereTipo & " " & whereNumero & " " & whereBod & " AND ref.codigo = lin.codigo  " & whereMp & " " & whereMaquina & " " & _
                  "GROUP BY lin.tipo,lin.codigo,ref.descripcion,lin.bodega "
            Else
            sql = "SELECT lin.tipo,doc.modelo,lin.seq ,lin.numero As número,lin.codigo As código,doc.nit,ref.descripcion,lin.fec,lin.cantidad,lin.valor_unitario,lin.cantidad * ref.conversion As kilos,(lin.valor_unitario * lin.cantidad)As vr_total, (lin.costo_unitario * lin.cantidad)As costo_total,lin.bodega,lin.adicional,doc.mp,ref.id_cor  " & _
                        "FROM documentos_lin lin , documentos doc, referencias ref " & _
                               "WHERE doc.numero = lin.numero " & whereFec & " " & whereCodigo & " " & whereTipo & " " & whereNumero & whereOrden & whereBod & " AND lin.tipo = doc.tipo AND ref.codigo = lin.codigo  " & whereMp & " " & whereMaquina & "  " & _
                               "ORDER BY lin.tipo,lin.numero,lin.seq,doc.mp "
            If cboTipo.Text = "EPPP" Then
                sql = "SELECT lin.tipo,doc.modelo,lin.seq ,lin.numero As número,lin.codigo As código,doc.nit,ref.descripcion,lin.fec,lin.cantidad,lin.valor_unitario,lin.cantidad * ref.conversion As kilos,(lin.valor_unitario * lin.cantidad)As vr_total, (lin.costo_unitario * lin.cantidad)As costo_total,lin.bodega,lin.adicional,doc.mp,(select top(1) o.materia_prima from PRGPRODUCCION.dbo.J_det_orden_prod d, PRGPRODUCCION.dbo.J_orden_prod_tef o WHERE d.cod_orden=o.consecutivo and transaccion_entrada=lin.numero) As materia_prima,ref.id_cor  " & _
                     "FROM documentos_lin lin , documentos doc, referencias ref " & _
                            "WHERE doc.numero = lin.numero " & whereFec & " " & whereCodigo & " " & whereTipo & " " & whereNumero & whereOrden & whereBod & " AND lin.tipo = doc.tipo AND ref.codigo = lin.codigo  " & whereMp & " " & whereMaquina & "  " & _
                            "ORDER BY lin.tipo,lin.numero,lin.seq,doc.mp "
            End If
            End If
            dt = obj_Ing_prodLn.listar_datatable(sql, "CORSAN")
            row = dt.NewRow
            row("tipo") = "TODOS"
            dt.Rows.Add(row)
        dtg_consulta.DataSource = dt
        For j = 0 To dtg_consulta.Columns.Count - 1
            If dtg_consulta.Columns(j).Name = "valor_unitario" Or dtg_consulta.Columns(j).Name = "cantidad" Or dtg_consulta.Columns(j).Name = "vr_total" Or dtg_consulta.Columns(j).Name = "costo_total" Or dtg_consulta.Columns(j).Name = "kilos" Then
                If dtg_consulta.Columns(j).Name = "cantidad" Then
                    dtg_consulta.Columns(j).DefaultCellStyle.Format = "N1"
                End If
                dtg_consulta.Item(dtg_consulta.Columns(j).Name, dtg_consulta.RowCount - 1).Value = sumarColumnas(dtg_consulta.Columns(j).Name, dtg_consulta)
            End If
        Next
        formatoDtg(dtg_consulta)
        If (permiso.Trim <> "ADMIN" And permiso.Trim <> "DIR_PRODUCCION") Then
            ocultarValores()
        End If
        cargaComp = True
    End Sub
    Public Sub formatoDtg(ByVal dtg As DataGridView)
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        dtg.Rows(dtg.RowCount - 1).DefaultCellStyle = DataGridViewCellStyle1
        If Not (chkConsolidar.Checked) Then
            dtg_consulta.Columns("fec").DefaultCellStyle.Format = "d"
            dtg.Columns("número").DefaultCellStyle = DataGridViewCellStyle1
            dtg.Columns("tipo").DefaultCellStyle = DataGridViewCellStyle1
        End If
    End Sub
    Private Function sumarColumnas(ByVal nomColumna As String, ByVal dtg As DataGridView) As Double
        Dim total As Double = 0
        For i As Integer = 0 To dtg.RowCount - 1
            If Not IsDBNull(dtg.Item(nomColumna.ToLower, i).Value) Then
                total = total + CDbl(dtg.Item(nomColumna.ToLower, i).Value)
            End If
        Next
        Return total
    End Function


    Private Sub cboBodega_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBodega.SelectedIndexChanged
        If (cargaComp) Then
            cargaComp = False
            txtNumero.Text = ""
            cargaComp = True
        End If
    End Sub

    Private Sub cbo_fecha_ini_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_fecha_ini.ValueChanged
        If (cargaComp) Then
            cargaComp = False
            txtNumero.Text = ""
            cargaComp = True
        End If
    End Sub
    Private Sub cbo_fecha_fin_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_fecha_fin.ValueChanged
        If (cargaComp) Then
            cargaComp = False
            txtNumero.Text = ""
            cargaComp = True
        End If
    End Sub

    Private Sub chkTodoCod_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTodoCod.CheckedChanged
        If (cargaComp) Then
            cargaComp = False
            If (chkTodoCod.Checked) Then
                cargaComp = False
                txtCodigo.Text = ""
                cargaComp = True
            End If
            txtNumero.Text = ""
            cargaComp = True
        End If
    End Sub

    Private Sub chkTodoTipo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTodoTipo.CheckedChanged
        If (cargaComp) Then
            cargaComp = False
            If (chkTodoTipo.Checked) Then

                cboTipo.Text = "TODO"
            End If
            txtNumero.Text = ""
            cargaComp = True
        End If
    End Sub

    Private Sub btn_excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_excel.Click
        objOperacionesForm.ExportarDatosExcel(dtg_consulta, "Transacciones Dms")
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
    Private Sub ocultarValores()
        For i = 0 To dtg_consulta.Columns.Count - 1
            If (dtg_consulta.Columns(i).Name = "vrt_total" Or dtg_consulta.Columns(i).Name = "costo_total") Then
                dtg_consulta.Columns(i).Visible = False
            End If
        Next
    End Sub
    Private Sub btntref_Click(sender As Object, e As EventArgs) Handles btntref.Click
        Dim frm_matp_tref As New Frm_materia_prima_tref
        frm_matp_tref.Show()
    End Sub
End Class