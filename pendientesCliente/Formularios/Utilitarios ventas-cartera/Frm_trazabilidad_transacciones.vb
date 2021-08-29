Imports logicaNegocios
Public Class Frm_trazabilidad_transacciones
    Private objOpSimplesLn As New Op_simpesLn
    Private obj_Ing_prodLn As New Ing_prodLn
    Private cargaComp As Boolean = False
    Private objOperacionesForm As New OperacionesFormularios
    Dim dtPpal As New DataTable
    Private Sub Frm_trazabilidad_transacciones_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim sql As String = "SELECT tipo " & _
                       "FROM documentos " & _
                           "GROUP BY tipo "
        cboTipo.DataSource = obj_Ing_prodLn.listar_datatable(sql, "CORSAN")
        cboTipo.ValueMember = "tipo"
        cboTipo.DisplayMember = "tipo"
        cboTipo.Text = "Seleccione"
        cbo_fecha_ini.Value = Now.AddYears(-1)
        cboBodega.Text = "2"
        cargaComp = True
    End Sub

    Private Sub cargarCosulta()
        cargaComp = False
        dtPpal = New DataTable
        Dim fecIni As String = objOpSimplesLn.cambiarFormatoFecha(cbo_fecha_ini.Value)
        Dim fecfin As String = objOpSimplesLn.cambiarFormatoFecha(cbo_fecha_fin.Value)
        Dim bodega As Integer = cboBodega.Text
        Dim tipo As String = cboTipo.Text
        Dim whereTipo As String = ""
        Dim whereNit As String = txtNit.Text
        Dim codigo As String = txtCodigo.Text
        Dim whereCodigo As String = ""
        Dim nom_col As String = ""
        Dim mes_ant As Integer = 0
        Dim ano_ant As Integer = 0
        Dim nombMes As String = ""
        Dim primero As Boolean = True

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
        If (txtNit.Text <> "") Then
            whereNit = "AND doc.nit like'" & txtNit.Text.Trim & "%'"
            chk_todo_nit.Checked = False
        Else
            chk_todo_nit.Checked = True
        End If

        Dim sql_codigos As String = "SELECT lin.codigo,ref.descripcion " & _
                    "FROM documentos_lin lin , documentos doc, referencias ref " & _
                           "WHERE  lin.fec >='" & fecIni & "' AND lin.fec <='" & fecfin & "' " & whereTipo & " " & whereCodigo & " " & whereNit & "  AND doc.bodega = " & bodega & "  AND doc.numero = lin.numero AND lin.tipo = doc.tipo AND doc.bodega = lin.bodega AND ref.codigo = lin.codigo AND doc.tipo not in ('FACT','DVR1','DVR4','DVR2','DVR3')   " & _
                            "GROUP BY lin.codigo,ref.descripcion "
        Dim sql_datos_meses As String = "SELECT lin.codigo As codigo,MONTH(fec) As mes ,YEAR(fec) As ano,SUM(lin.cantidad)As cantidad,SUM (lin.valor_unitario * lin.cantidad)As vr_total " & _
                                           "FROM documentos_lin lin , documentos doc " & _
                                                  "WHERE  lin.fec >='" & fecIni & "' AND lin.fec <='" & fecfin & "' " & whereTipo & " " & whereNit & "  AND doc.bodega = " & bodega & " AND doc.numero = lin.numero AND lin.tipo = doc.tipo AND doc.bodega = lin.bodega  AND doc.tipo not in ('FACT','DVR1','DVR4','DVR2','DVR3')  " & _
                                                  "GROUP BY YEAR(fec),MONTH(fec),lin.codigo"
        Dim dt_codigos As New DataTable
        dt_codigos = objOpSimplesLn.listar_datatable(sql_codigos, "CORSAN")
        Dim dt_datos_meses As New DataTable
        dt_datos_meses = objOpSimplesLn.listar_datatable(sql_datos_meses, "CORSAN")
        dtPpal.Columns.Add("Código")
        dtPpal.Columns.Add("Descripción")
        For i = 0 To dt_codigos.Rows.Count - 1
            dtPpal.Rows.Add()
            dtPpal.Rows(dtPpal.Rows.Count - 1).Item("Código") = dt_codigos.Rows(i).Item("codigo")
            dtPpal.Rows(dtPpal.Rows.Count - 1).Item("Descripción") = dt_codigos.Rows(i).Item("descripcion")
        Next

        For i = 0 To dt_datos_meses.Rows.Count - 1
            nombMes = MonthName(dt_datos_meses.Rows(i).Item("mes"), True).ToUpper & "-" & dt_datos_meses.Rows(i).Item("ano")
            If (primero) Then
                mes_ant = dt_datos_meses.Rows(i).Item("mes")
                ano_ant = dt_datos_meses.Rows(i).Item("ano")
                dtPpal.Columns.Add(nombMes & "-cantidad", GetType(Double))
                dtPpal.Columns.Add(nombMes & "-vr_total", GetType(Double))
                primero = False
            End If
            If (mes_ant <> dt_datos_meses.Rows(i).Item("mes") Or ano_ant <> dt_datos_meses.Rows(i).Item("ano")) Then
                dtPpal.Columns.Add(nombMes & "-cantidad", GetType(Double))
                dtPpal.Columns.Add(nombMes & "-vr_total", GetType(Double))
            End If
            dtPpal.Rows(numFila(dt_datos_meses.Rows(i).Item("codigo"))).Item(nombMes & "-cantidad") = dt_datos_meses.Rows(i).Item("cantidad")
            dtPpal.Rows(numFila(dt_datos_meses.Rows(i).Item("codigo"))).Item(nombMes & "-vr_total") = dt_datos_meses.Rows(i).Item("vr_total")

            mes_ant = dt_datos_meses.Rows(i).Item("mes")
            ano_ant = dt_datos_meses.Rows(i).Item("ano")
        Next
        dtPpal.Rows.Add()
        dtPpal.Rows(dtPpal.Rows.Count - 1).Item("Descripción") = "TOTAL"
        totalizarDt()
        dtg_consulta.DataSource = dtPpal
        dtg_consulta.Rows(dtPpal.Rows.Count - 1).DefaultCellStyle.BackColor = Color.Red
        dtg_consulta.Rows(dtPpal.Rows.Count - 1).DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        For i = 0 To 1
            dtg_consulta.Columns(i).Frozen = True
        Next
        cargaComp = True
    End Sub
    Private Sub totalizarDt()
        Dim sum As Double = 0
        For j = 2 To dtPpal.Columns.Count - 1
            For i = 0 To dtPpal.Rows.Count - 1
                If Not IsDBNull(dtPpal.Rows(i).Item(j)) Then
                    sum += dtPpal.Rows(i).Item(j)
                End If
            Next
            dtPpal.Rows(dtPpal.Rows.Count - 1).Item(j) = sum
            sum = 0
        Next
    End Sub
    Private Function numFila(ByVal codigo As String) As Integer
        For i = 0 To dtPpal.Rows.Count - 1
            If (dtPpal.Rows(i).Item("Código") = codigo) Then
                Return i
            End If
        Next
        Return 0
    End Function
    Private Sub btn_actualizar_Click(sender As System.Object, e As System.EventArgs) Handles btn_actualizar.Click
        cargarCosulta()
    End Sub

    Private Sub txtNit_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtNit.KeyPress
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
    Private Sub btn_ppal_Click(sender As System.Object, e As System.EventArgs) Handles btn_ppal.Click
        FrmPrincipal.Show()
        Me.Close()
        FrmPrincipal.Activate()
    End Sub

    Private Sub btn_salir_Click(sender As System.Object, e As System.EventArgs) Handles btn_salir.Click
        FrmLogin.Show()
        FrmPrincipal.Close()
        Me.Close()
    End Sub

    Private Sub btn_excel_Click_1(sender As System.Object, e As System.EventArgs) Handles btn_excel.Click
        objOperacionesForm.ExportarDatosExcel(dtg_consulta, Me.Text)
    End Sub
End Class