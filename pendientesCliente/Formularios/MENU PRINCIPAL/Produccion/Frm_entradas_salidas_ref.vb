Imports logicaNegocios
Imports entidadNegocios
Imports accesoDatos
Public Class Frm_entradas_salidas_ref
    Private objOpSimplesLn As New Op_simpesLn
    Dim carga_comp As Boolean = False
    Private objOperacionesForm As OperacionesFormularios = New OperacionesFormularios
    Public Sub MAIN(ByVal permiso As String)
        Dim where_bod As String = ""
        If permiso.Trim = "SAC" Then
            where_bod = "WHERE bodega IN (3,7)"
        End If
        Dim sql As String = "SELECT CAST(bodega As varchar(25)) As bodega, CAST(bodega As varchar(25)) + '-' + descripcion As descripcion  FROM bodegas  " & where_bod
        Dim dt As New DataTable
        Dim dr As DataRow

        dt = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        dr = dt.NewRow
        dr("bodega") = "TODO"
        dr("descripcion") = "TODO"
        dt.Rows.Add(dr)
        cbo_bodega.DataSource = dt
        cbo_bodega.ValueMember = "bodega"
        cbo_bodega.DisplayMember = "descripcion"
        cbo_bodega.SelectedValue = "3"
        If permiso.Trim <> "ADMIN" And permiso.Trim <> "DIR_PRODUCCION" And permiso.Trim <> "COMPRAS" Then
            chk_costos.Visible = False
        End If
        cbo_fecha_ini_fil.Value = Now.AddMonths(-3)
        cbo_fecha_ini_fil.Value = cbo_fecha_ini_fil.Value.AddDays(-Now.Day + 1)
        cbo_fecha_fin_fil.Value = cbo_fecha_ini_fil.Value
    End Sub
    Private Sub Frm_entradas_salidas_ref_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim dt_linea As New DataTable
        Dim sql_linea As String = "SELECT CAST(Id_cor AS varchar(25))As Id_cor, Descripcion FROM JJV_Grupos_seguimiento"
        dt_linea = objOpSimplesLn.listar_datatable(sql_linea, "CORSAN")

        For i = 0 To dt_linea.Rows.Count - 1
            If (i = 0) Then
                chkLinea.Items.Add("TODOS")
            End If
            chkLinea.Items.Add(dt_linea.Rows(i).Item("Descripcion"))
        Next
        Dim año = Now.Year
        While (año >= Now.Year - 5)
            cbo_ano.Items.Add(año)
            año -= 1
        End While
        cbo_ano.Text = Now.Year
        cbo_mes.SelectedIndex = Now.Month - 1
        chk_agrup_bod.Checked = True
        labelcontar()
    End Sub

    Dim contador_prog As Integer = 0
    Private Sub btnActualizar_Click(sender As System.Object, e As System.EventArgs) Handles btnActualizar.Click
        If (validar()) Then
            img_procesar.Visible = True
            Application.DoEvents()
            If tab_ppal.SelectedTab.Name = tab_ent_sal_stock.Name Then
                cargar_consulta()
            Else
                armarDt_trasabilidad()
            End If
            img_procesar.Visible = False
        End If
    End Sub
    'trae el total de registros de una consulta
    Public Sub labelcontar()
        Dim i As Integer
        Dim a As New ClasificacionAd
        i = a.contarregistros
        LinkLabel1.Text = "Productos sin clasificar:" & i
        If i = 0 Then
            LinkLabel1.LinkColor = Color.Green
        Else
            LinkLabel1.LinkColor = Color.Red
        End If
    End Sub
    Private Function validar() As Boolean
        Dim resp As Boolean = False
        If (txt_codigo.Text <> "") Then
            resp = True
        ElseIf (txtDesc.Text <> "") Then
            resp = True
        ElseIf (chkLinea.CheckedItems.Count > 0) Then
            resp = True
            For i = 0 To chkLinea.CheckedItems.Count - 1
                If (chkLinea.CheckedItems(i).ToString = "TODOS") Then
                    resp = False
                End If
            Next
        End If
        If (resp = False) Then
            MessageBox.Show("Seleccione un codigo ó linea de producción a consultar", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Return resp
    End Function
    Private Sub cargar_consulta()
        dtgConsulta.DataSource = Nothing
        Dim tamano_letra As Single = 9.0!
        Dim grupos_seguimiento As Boolean = True
        If (txt_codigo.Text <> "") Then
            If Not (txt_codigo.Text(0) = "3" Or txt_codigo.Text(0) = "2") Then
                grupos_seguimiento = False
            End If
        End If

        Dim ano As String = cbo_ano.Text
        Dim mes As String = cbo_mes.SelectedIndex + 1
        Dim sql As String = ""
        Dim selectSql As String = "SELECT "
        Dim from_sql As String = "FROM referencias_sto s , referencias r "
        Dim whereSql As String = "WHERE r.codigo = s.codigo AND mes = " & mes & " AND ano = " & ano & "  "
        If chk_ocultar_vacios.Checked = True And chk_inactivas.Checked = True Then
            whereSql = "WHERE r.codigo = s.codigo AND mes = " & mes & " AND ano = " & ano & " and (s.can_ini>=1 or s.can_ent>=1 or s.can_sal>=1 or cos_ini>=1 or cos_ent>=1 or cos_sal>1) AND r.ref_anulada <> 'S'  "
        ElseIf chk_ocultar_vacios.Checked = True Then
            whereSql = "WHERE r.codigo = s.codigo AND mes = " & mes & " AND ano = " & ano & " and (s.can_ini>=1 or s.can_ent>=1 or s.can_sal>=1 or cos_ini>=1 or cos_ent>=1 or cos_sal >= 1 or cos_ini >= 1 or cos_ent >= 1 or cos_sal >= 1)"
        ElseIf chk_inactivas.Checked = True Then
            whereSql = "WHERE r.codigo = s.codigo AND mes = " & mes & " AND ano = " & ano & " AND r.ref_anulada <> 'S'"
        End If
        Dim groupSql As String = ""
        Dim orderSql As String = ""
        If (grupos_seguimiento) Then
            selectSql &= "g.Descripcion as linea_de_produccion, "
            from_sql &= ",JJV_Grupos_seguimiento g "
            whereSql &= " AND g.Id_cor = r.Id_cor "
            orderSql &= "ORDER BY g.Descripcion "
        End If
        If (chk_agrup_bod.Checked) Then
            selectSql &= "s.bodega,"
        End If
        If (chk_consol_linea.Checked) Then
            selectSql &= "SUM(s.can_ini)As can_ini,SUM(s.can_ent)As can_ent,SUM(s.can_sal)As can_sal,((SUM(s.can_ini)+SUM(s.can_ent)) -SUM(s.can_sal))As stock , SUM(s.cos_ini)As cos_ini,SUM(cos_ent)As cos_ent,SUM(cos_sal)As cos_sal,((SUM(s.cos_ini)+SUM(s.cos_ent)) -SUM(s.cos_sal))As costo_stock, s.mes,s.ano "
            groupSql &= "GROUP BY s.mes,s.ano "
            If (chk_agrup_bod.Checked) Then
                groupSql &= ",s.bodega "
            End If
            If (grupos_seguimiento) Then
                groupSql &= ",g.Descripcion "
            End If
        Else
            selectSql &= "s.codigo,r.descripcion,s.can_ini,s.can_ent ,s.can_sal,((s.can_ini+s.can_ent)-(s.can_sal))As stock,cos_ini,cos_ent,cos_sal,((s.cos_ini+s.cos_ent) -s.cos_sal)As costo_stock , s.mes,s.ano "
        End If
        Dim dt As New DataTable
        Dim dt_oculto As New DataTable
        If (txtDesc.Text.Trim <> "") Then
            whereSql &= " AND r.descripcion like'%" & txtDesc.Text & "%' "
        End If
        If (txt_codigo.Text.Trim <> "") Then
            whereSql &= " AND s.codigo like'" & txt_codigo.Text & "%' "
        End If
        If (chkLinea.CheckedItems.Count <> 0) Then
            For i = 0 To chkLinea.CheckedItems.Count - 1
                If (chkLinea.CheckedItems(i).ToString = "TODOS") Then
                    i = chkLinea.CheckedItems.Count - 1
                Else
                    If (i = 0) Then
                        whereSql &= "AND g.descripcion IN('" & chkLinea.CheckedItems(i).ToString & "'"
                    Else
                        whereSql &= ",'" & chkLinea.CheckedItems(i).ToString & "'"
                    End If
                    If (i = chkLinea.CheckedItems.Count - 1) Then
                        whereSql &= ") "
                    End If
                End If
            Next
        End If
        If (cbo_bodega.SelectedValue <> "TODO") Then
            whereSql &= "AND s.bodega = " & cbo_bodega.SelectedValue & " "
        End If
        If chk_fil_ult_movimiento.Checked Then
            Dim fec_ult_ent As String = objOpSimplesLn.cambiarFormatoFecha(cbo_fecha_ini_fil.Value)
            Dim fec_ult_sal As String = objOpSimplesLn.cambiarFormatoFecha(cbo_fecha_fin_fil.Value)
            whereSql &= " AND (fec_ultima_entrada<='" & fec_ult_ent & "' AND fec_ultima_salida <='" & fec_ult_ent & "') "
            selectSql &= ",r.fec_ultima_entrada,r.fec_ultima_salida "
            If groupSql <> "" Then
                groupSql &= " r.fec_ultima_entrada,r.fec_ultima_salida "
            End If
        End If
        sql = selectSql & from_sql & whereSql & groupSql & orderSql

        dt = objOpSimplesLn.listar_datatable(sql, "CORSAN")

        dt.Rows.Add()
        dt = totalizarDtg(dt)
        dtgConsulta.DataSource = dt
        
        dtgConsulta.Rows(dtgConsulta.Rows.Count - 1).DefaultCellStyle = objOperacionesForm.formatoNegrita(tamano_letra)
        mostrar_ocultar_costos()
        If chk_fil_ult_movimiento.Checked Then
            dtgConsulta.Columns("fec_ultima_entrada").DefaultCellStyle.Format = "d"
            dtgConsulta.Columns("fec_ultima_salida").DefaultCellStyle.Format = "d"
        End If
    End Sub
    Private Sub mostrar_ocultar_costos()
        For i = 0 To dtgConsulta.Columns.Count - 1
            If dtgConsulta.Columns(i).Name = "cos_ini" Or dtgConsulta.Columns(i).Name = "cos_ent" Or dtgConsulta.Columns(i).Name = "cos_sal" Or dtgConsulta.Columns(i).Name = "costo_stock" Then
                dtgConsulta.Columns(i).Visible = chk_costos.Checked
            End If
        Next
    End Sub

    Private Function ocultar_vacios(ByVal dt As DataTable)
        Dim valor As Double = 0
        Dim indice As Integer = 0
        Dim row As DataRow
        For Each row In dt.Rows
            If row.Item("can_ini") = 0 And row.Item("can_ent") = 0 And row.Item("can_sal") = 0 Then
                dt.Rows.Remove(row)
                dt.AcceptChanges()
            End If
        Next
        Return dt
    End Function
    Private Function totalizarDtg(ByRef dt As DataTable) As DataTable
        Dim sum As Double = 0
        For i = 0 To dt.Columns.Count - 1
            If (dt.Columns(i).ColumnName = "can_ini" Or dt.Columns(i).ColumnName = "can_sal" Or dt.Columns(i).ColumnName = "can_ent" Or dt.Columns(i).ColumnName = "stock" Or dt.Columns(i).ColumnName = "cos_ini" Or dt.Columns(i).ColumnName = "cos_sal" Or dt.Columns(i).ColumnName = "cos_ent" Or dt.Columns(i).ColumnName = "costo_stock") Then
                For j = 0 To dt.Rows.Count - 2
                    If Not IsDBNull(dt.Rows(j).Item(i)) Then
                        sum += dt.Rows(j).Item(i)
                    End If
                Next
                dt.Rows(dt.Rows.Count - 1).Item(i) = sum
                sum = 0
            ElseIf (dt.Columns(i).ColumnName = "linea_de_produccion") Then
                dt.Rows(dt.Rows.Count - 1).Item(i) = "TOTAL"
            End If
        Next
        Return dt
    End Function

    Private Sub sugerido_compra(ByRef dt As DataTable)
        For i = 0 To dt.Rows.Count - 1
            If (Not IsDBNull(dt.Rows(i).Item("Maximo")) And Not IsDBNull(dt.Rows(i).Item("Minimo"))) Then
                dt.Rows(i).Item("sugerido_compra") = ((dt.Rows(i).Item("Maximo") + dt.Rows(i).Item("Minimo")) / 2) * 1.1
            End If
        Next
    End Sub
    Private Sub ocultarCeros(ByRef dt As DataTable)
        For i = 0 To dt.Rows.Count - 1
            If (dt.Rows(i).Item("Maximo") = 0 And dt.Rows(i).Item("Minimo") = 0 And dt.Rows(i).Item("stock") = 0) Then
                dt.Rows(i).Delete()
            End If
        Next
    End Sub
    Private Sub btnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Click
        objOperacionesForm.ExportarDatosExcel(dtgConsulta, "Informe de inventarios")
    End Sub


    Private Sub chk_mostrar_costos_CheckedChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Frm_clasificacion.ShowDialog()
    End Sub

    Private Sub chk_fil_ult_movimiento_CheckedChanged(sender As Object, e As EventArgs) Handles chk_fil_ult_movimiento.CheckedChanged
        If chk_fil_ult_movimiento.Checked Then
            cbo_fecha_ini_fil.Enabled = True
            cbo_fecha_fin_fil.Enabled = True
        Else
            cbo_fecha_ini_fil.Enabled = False
            cbo_fecha_fin_fil.Enabled = False
        End If
    End Sub

    Private Sub armarDt_trasabilidad()
        Dim ano As String = cbo_ano.Text
        Dim codigo_filtro As String = txt_codigo.Text
        Dim where_sql As String = " AND s.bodega =" & cbo_bodega.SelectedValue & " AND s.ano = " & cbo_ano.Text & " "
        If txt_codigo.Text <> "" Then
            where_sql &= " AND s.codigo like'" & txt_codigo.Text & "%' "
        End If
        If (chkLinea.CheckedItems.Count <> 0) Then
            For i = 0 To chkLinea.CheckedItems.Count - 1
                If (chkLinea.CheckedItems(i).ToString = "TODOS") Then
                    i = chkLinea.CheckedItems.Count - 1
                Else
                    If (i = 0) Then
                        where_sql &= "AND g.descripcion IN('" & chkLinea.CheckedItems(i).ToString & "'"
                    Else
                        where_sql &= ",'" & chkLinea.CheckedItems(i).ToString & "'"
                    End If
                    If (i = chkLinea.CheckedItems.Count - 1) Then
                        where_sql &= ") "
                    End If
                End If
            Next
        End If
        Dim sql As String = "SELECT s.mes,s.ano,s.bodega,r.codigo,r.descripcion ,s.can_ent ,s.can_sal,s.stock " &
                         "From v_referencias_sto s , referencias r , jjv_grupos_seguimiento g " &
                             "WHERE g.id_cor = r.id_cor AND  r.codigo = s.codigo  AND (can_sal >0 or can_ent >0 or stock >0)  " & where_sql & " " &
                                "ORDER BY s.mes,s.ano"

        Dim codigo As String = ""
        Dim dtDatos As DataTable = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        Dim dtResp As New DataTable
        Dim nombMes As String = ""
        Dim nombMes_ent As String = ""
        Dim nombMes_stock As String = ""
        Dim mesAnoEncontrado As Boolean = False
        Dim codigo_encontrado As Boolean = False
        Dim fila_codigo As Integer = 0
        dtResp.Columns.Add("bodega")
        dtResp.Columns.Add("codigo")
        dtResp.Columns.Add("descripcion")
        For i = 0 To dtDatos.Rows.Count - 1
            nombMes = MonthName(dtDatos.Rows(i).Item("mes"), True).ToUpper & " - " & dtDatos.Rows(i).Item("ano")
            nombMes_ent = nombMes & "_ENT"
            nombMes_stock = nombMes & "_STOCK"
            nombMes &= "_SAL"
            For j = 0 To dtResp.Columns.Count - 1
                If (dtResp.Columns(j).ColumnName = nombMes) Then
                    mesAnoEncontrado = True
                    j = dtResp.Columns.Count - 1
                End If
            Next
            If (mesAnoEncontrado = False) Then
                dtResp.Columns.Add(nombMes, GetType(Double))
                dtResp.Columns.Add(nombMes_ent, GetType(Double))
                dtResp.Columns.Add(nombMes_stock, GetType(Double))
            End If
            codigo = dtDatos.Rows(i).Item("codigo")
            For k = 0 To dtResp.Rows.Count - 1
                If dtResp.Rows(k).Item("codigo") = codigo Then
                    codigo_encontrado = True
                    fila_codigo = k
                    k = dtResp.Rows.Count - 1
                End If
            Next
            If codigo_encontrado = False Then
                dtResp.Rows.Add()
                fila_codigo = dtResp.Rows.Count - 1
                dtResp.Rows(fila_codigo).Item("bodega") = dtDatos.Rows(i).Item("bodega")
                dtResp.Rows(fila_codigo).Item("codigo") = dtDatos.Rows(i).Item("codigo")
                dtResp.Rows(fila_codigo).Item("descripcion") = dtDatos.Rows(i).Item("descripcion")
            End If
            dtResp.Rows(fila_codigo).Item(nombMes_ent) = dtDatos.Rows(i).Item("can_ent")
            dtResp.Rows(fila_codigo).Item(nombMes) = dtDatos.Rows(i).Item("can_sal")
            dtResp.Rows(fila_codigo).Item(nombMes_stock) = dtDatos.Rows(i).Item("stock")
            mesAnoEncontrado = False
            codigo_encontrado = False
            fila_codigo = 0
        Next
        dtg_trasabilidad.DataSource = dtResp
        dtg_trasabilidad.Columns("bodega").Frozen = True
        dtg_trasabilidad.Columns("codigo").Frozen = True
        dtg_trasabilidad.Columns("descripcion").Frozen = True
        mostrar_ocultar_det_tras(False)
        Dim stock_ant As Double = 0


        For i = 0 To dtg_trasabilidad.RowCount - 1
            For j = 0 To dtg_trasabilidad.Columns.Count - 1
                If dtg_trasabilidad.Columns(j).Name Like "*STOCK*" Then
                    'If i = 0 Then
                    '    If IsNumeric(dtg_trasabilidad.Item(j, i).Value) Then
                    '        stock_ant = dtg_trasabilidad.Item(j, i).Value
                    '    End If
                    'End If
                    If IsNumeric(dtg_trasabilidad.Item(j, i).Value) Then
                        If dtg_trasabilidad.Item(j, i).Value = stock_ant Then
                            dtg_trasabilidad.Item(j, i).Style.BackColor = Color.Red
                        Else
                            dtg_trasabilidad.Item(j, i).Style.BackColor = Color.YellowGreen
                        End If
                    Else
                        dtg_trasabilidad.Item(j, i).Style.BackColor = Color.Red
                    End If
                    If IsNumeric(dtg_trasabilidad.Item(j, i).Value) Then
                        stock_ant = dtg_trasabilidad.Item(j, i).Value
                    Else
                        stock_ant = 0
                    End If
                End If
            Next
            stock_ant = 0
        Next

    End Sub

    Private Sub chk_det_tras_CheckedChanged(sender As Object, e As EventArgs) Handles chk_det_tras.CheckedChanged
        If chk_det_tras.Checked Then
            mostrar_ocultar_det_tras(True)
        Else
            mostrar_ocultar_det_tras(False)
        End If

    End Sub
    Private Sub mostrar_ocultar_det_tras(ByVal estado As Boolean)
        For j = 0 To dtg_trasabilidad.ColumnCount - 1
            If dtg_trasabilidad.Columns(j).Name Like "*ENT*" Or dtg_trasabilidad.Columns(j).Name Like "*SAL*" Then
                dtg_trasabilidad.Columns(j).Visible = estado
            End If
        Next
    End Sub
    Private Sub Chk_costos_CheckedChanged(sender As Object, e As EventArgs) Handles chk_costos.CheckedChanged
        mostrar_ocultar_costos()
    End Sub

    Private Sub cbo_bodega_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbo_bodega.SelectedIndexChanged

    End Sub
End Class