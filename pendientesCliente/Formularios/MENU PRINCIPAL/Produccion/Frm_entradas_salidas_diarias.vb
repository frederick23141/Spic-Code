Imports logicaNegocios
Imports entidadNegocios
Imports accesoDatos
Public Class Frm_entradas_salidas_diarias
    Private objOpSimplesLn As New Op_simpesLn
    Dim carga_comp As Boolean = False
    Private objOperacionesForm As OperacionesFormularios = New OperacionesFormularios

    Private Sub Frm_entradas_salidas_diarias_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim sql As String = "SELECT CAST(bodega As varchar(25)) As bodega, CAST(bodega As varchar(25)) + '-' + descripcion As descripcion  FROM bodegas "
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
        cbo_bodega.SelectedValue = "TODO"
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
      
        chk_agrup_bod.Checked = True
        labelcontar()
    End Sub


    Private Sub btnActualizar_Click(sender As System.Object, e As System.EventArgs) Handles btnActualizar.Click
        If (validar()) Then
            img_procesar.Visible = True
            Application.DoEvents()
            cargar_consulta()
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
        If (cbo_bodega.SelectedValue <> "TODO") Then
            resp = True
        ElseIf (txt_codigo.Text <> "") Then
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
        Dim tamano_letra As Single = 9.0!
        dtgConsulta.DataSource = Nothing
        Dim grupos_seguimiento As Boolean = True
        If (txt_codigo.Text <> "") Then
            If Not (txt_codigo.Text(0) = "3" Or txt_codigo.Text(0) = "2") Then
                grupos_seguimiento = False
            End If
        End If
        Dim fec_ini As String = objOpSimplesLn.cambiarFormatoFecha(cbo_fecha_ini.Value.Date)
        Dim fec_fin As String = objOpSimplesLn.cambiarFormatoFecha(cbo_fecha_fin.Value.Date)

        Dim sql As String = ""
        Dim selectSql As String = "SELECT "
        Dim from_sql As String = "FROM J_referencia_entradas_salidas_sw r "
        Dim whereSql As String = "WHERE CAST(r.fec AS date ) >= '" & fec_ini & "' AND CAST(r.fec AS date ) <= '" & fec_fin & "' "
        Dim groupSql As String = ""
        Dim orderSql As String = ""
        If (grupos_seguimiento) Then
            selectSql &= "g.Descripcion as linea_de_produccion, "
            from_sql &= ",JJV_Grupos_seguimiento g "
            whereSql &= " AND g.Id_cor = r.Id_cor "
            orderSql &= "ORDER BY g.Descripcion "
            If groupSql = "" Then
                groupSql &= "GROUP BY g.Descripcion "
            Else
                groupSql &= ",g.Descripcion, "
            End If

        End If
        If (chk_agrup_bod.Checked) Then
            selectSql &= "bodega,"
            If (groupSql = "") Then
                groupSql = "GROUP BY r.bodega "
            Else
                groupSql &= ",r.bodega "
            End If
        End If
        If (chkConsolDia.Checked) Then
            selectSql &= "CAST(r.fec AS date ) As fec,"
            If (groupSql = "") Then
                groupSql = "GROUP BY CAST(r.fec AS date ) "
            Else
                groupSql &= ",CAST(r.fec AS date ) "
            End If
        End If
        If (chk_consol_linea.Checked) Then
            selectSql &= "SUM(r.entradas)As entradas,SUM(r.salidas)As salidas "
            If (chk_agrup_bod.Checked) Then
                If (groupSql = "") Then
                    groupSql = "GROUP BY r.bodega "
                Else
                    groupSql &= ",r.bodega "
                End If

            End If
            If (grupos_seguimiento) Then
                If (groupSql = "") Then
                    groupSql = "GROUP BY g.Descripcion "
                Else
                    groupSql &= ",g.Descripcion "
                End If
            End If
        Else
            selectSql &= "r.codigo,r.descripcion,SUM(r.entradas)As entradas,SUM(r.salidas)As salidas "
            If (groupSql = "") Then
                groupSql = "GROUP BY r.codigo,r.descripcion "
            Else
                groupSql &= ",r.codigo,r.descripcion "
            End If
        End If
        Dim dt As New DataTable
        If (txtDesc.Text.Trim <> "") Then
            whereSql &= " AND r.descripcion like'%" & txtDesc.Text & "%' "
        End If
        If (txt_codigo.Text.Trim <> "") Then
            whereSql &= " AND r.codigo like'" & txt_codigo.Text & "%' "
        End If
        If (chkLinea.CheckedItems.Count <> 0) Then
            For i = 0 To chkLinea.CheckedItems.Count - 1
                If (chkLinea.CheckedItems(i).ToString = "TODOS") Then
                    i = chkLinea.CheckedItems.Count - 1
                Else
                    If (i = 0) Then
                        whereSql &= "AND g.descripcion  IN('" & chkLinea.CheckedItems(i).ToString & "'"
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
            whereSql &= "AND r.bodega = " & cbo_bodega.SelectedValue & " "
        End If
        sql = selectSql & from_sql & whereSql & groupSql & orderSql
        dt = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        dt.Rows.Add()
        dt = totalizarDtg(dt)
        dtgConsulta.DataSource = dt
        dtgConsulta.Rows(dtgConsulta.Rows.Count - 1).DefaultCellStyle = objOperacionesForm.formatoNegrita(tamano_letra)
        For i = 0 To dtgConsulta.Columns.Count - 1
            If (dtgConsulta.Columns(i).Name = "fec") Then
                dtgConsulta.Columns(i).DefaultCellStyle.Format = "d"
            End If
        Next
    End Sub

    Private Function totalizarDtg(ByRef dt As DataTable) As DataTable
        Dim sum As Double = 0
        For i = 0 To dt.Columns.Count - 1
            If (dt.Columns(i).ColumnName = "entradas" Or dt.Columns(i).ColumnName = "salidas" Or dt.Columns(i).ColumnName = "cantidad" Or dt.Columns(i).ColumnName = "vr_total" Or dt.Columns(i).ColumnName = "costo_total") Then
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



    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Frm_clasificacion.ShowDialog()
    End Sub
End Class