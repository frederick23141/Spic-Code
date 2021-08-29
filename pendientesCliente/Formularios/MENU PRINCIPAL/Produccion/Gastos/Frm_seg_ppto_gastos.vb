Imports logicaNegocios
Imports entidadNegocios
Imports accesoDatos
Public Class Frm_seg_ppto_gastos
    Private obj_op_simplesLn As New Op_simpesLn
    Private obj_Ing_prodLn As New Ing_prodLn
    Private objOperacionesForm As New OperacionesFormularios
    Dim carga_comp As Boolean = False
    Dim usuario As New UsuarioEn
    Dim mes As Integer = 0
    Dim ano As Integer = 0
    Dim fila_select As Integer = 0
    Dim fila_detalle As Integer = 0
    Dim centros As String = ""
    Private columnaArbol As String
    Private permiso As String = ""
    Private per_cuentas As String = ""
    Private obj_ppto_produccionLn As New Ppto_produccionLn
    Public Sub MAIN(ByVal usuario As UsuarioEn)
        Me.usuario = usuario
        asignar_permisos()
        Dim where_sql As String = ""
        Dim sql As String = ""
        Dim dt As New DataTable
        If usuario.permiso.Trim <> "ADMIN" And usuario.permiso.Trim <> "DIR_PRODUCCION" Then
            btnConfigPermisos.Visible = False
        End If
        If (usuario.permiso.Trim <> "ADMIN" And usuario.permiso.Trim <> "COMPRAS" And usuario.permiso.Trim <> "DIR_PRODUCCION" And usuario.permiso.Trim <> "COOR_PROD") Then
            btnConfigPermisos.Visible = False
            Dim nit As Double = usuario.nit
            Dim listCentros As DataTable = obj_op_simplesLn.listar_datatable("SELECT centro FROM J_coordinador_centros_costos WHERE nit =" & nit, "PRODUCCION")
            For i = 0 To listCentros.Rows.Count - 1
                centros &= listCentros.Rows(i).Item("centro")
                If (i <> listCentros.Rows.Count - 1) Then
                    centros &= ","
                End If
            Next
        Else
            Dim sql_permisos As String = "SELECT descripcion  FROM J_spic_permiso "
            cargarLista(listaTipoUsu, sql_permisos)
            Dim sql_cuentas As String = "SELECT cuenta  FROM J_ppto_gastos_cuentas "
            cargarLista(list_cuentas, sql_cuentas)
        End If
        If centros = "" Then
            where_sql &= "WHERE centro IN(1200,2100,2117,2200,2300,2400,2500,2600,2800,3100,3200,4100,3500,5200,6200,6400)"
        Else
            where_sql &= "WHERE centro IN(" & centros & ")"
        End If
        sql = "SELECT centro,( CAST (centro AS varchar(25))+ '-' + descripcion )As descripcion " & _
                        "FROM centros " & _
                            where_sql
        dt = obj_op_simplesLn.listar_datatable(sql, "CORSAN")
        dt.Rows.Add()
        dt.Rows(dt.Rows.Count - 1).Item("centro") = 0
        dt.Rows(dt.Rows.Count - 1).Item("descripcion") = "TODO"
        cbo_centro.DataSource = dt
        cbo_centro.ValueMember = "centro"
        cbo_centro.DisplayMember = "descripcion"
        cbo_centro.SelectedValue = 0
        consultar()

    End Sub
    Private Sub cargarLista(ByVal lista As ListBox, ByVal sql As String)
        lista.Items.Clear()
        Dim list As New List(Of Object)
        list = obj_op_simplesLn.lista(sql)
        For i = 0 To list.Count - 1
            lista.Items.Add(list(i))
        Next
    End Sub
    Private Sub Frm_seg_ppto_gastos_load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim año = Now.Year
        While (año >= Now.Year - 5)
            cbo_ano.Items.Add(año)
            año -= 1
        End While
        cbo_ano.Text = Now.Year
        cbo_mes.SelectedIndex = Now.Month - 1
        mes = cbo_mes.SelectedIndex + 1
        ano = cbo_ano.Text
        tab_ppal.SelectedTab = tab_articulos
        tab_ppal.SelectedTab = tab_gastos
        carga_comp = True
    End Sub


    Private Sub consultar()
        img_procesar.Visible = True
        Application.DoEvents()
        Dim dt As New DataTable
        dt = armar_dt()
        dt.Columns.Add("diferencia", GetType(Double))
        dt.Columns.Add("porc_cump", GetType(Double))
        dt.Columns.Add("diferencia_orden", GetType(Double))
        dt.Columns.Add("porc_cump_orden", GetType(Double))
        dt.Rows.Add()
        calcular_cumplimiento(dt)
        calcular_diferencia_orden(dt)
        totalizarDt(dt)
        totalizar_tipo_producto(dt)
        ' eliminar_sin_ppto(dt)
        dtg_consulta.DataSource = dt
        dtg_consulta.Columns("acum_ppto").DisplayIndex = dtg_consulta.Columns.Count - 1
        dtg_consulta.Columns("acum_saldo").DisplayIndex = dtg_consulta.Columns.Count - 2
        add_tendencia(dt)
        formatoDtg()
        dtg_consulta.Columns("porc_cump").HeaderText = "%mes"
        dtg_consulta.Columns("porc_cump_orden").HeaderText = "%mes_orden"
        dtg_consulta.Columns("tipo").Visible = False
        img_procesar.Visible = False
    End Sub
    Private Sub asignar_permisos()
        Dim sql As String = "SELECT cuenta FROM J_ppto_gastos_permisos_cuentas WHERE permiso = '" & usuario.permiso & "'"
        Dim dt As DataTable = obj_op_simplesLn.listar_datatable(sql, "CORSAN")
        For i = 0 To dt.Rows.Count - 1
            per_cuentas &= "'" & dt.Rows(i).Item("cuenta") & "'"
            If (i <> dt.Rows.Count - 1) Then
                per_cuentas &= ","
            End If
        Next
    End Sub
    Private Function armar_dt() As DataTable
        Dim where_permiso As String = ""
        Dim where_centro As String = ""
        If per_cuentas <> "" Then
            where_permiso = " AND c.cuenta IN (" & per_cuentas & " ) "
        End If
        If centros <> "" Then
            where_centro = " AND centro IN( " & centros & ") "
        End If
        If cbo_centro.SelectedValue <> 0 Then
            where_centro = " AND centro = " & cbo_centro.SelectedValue
        End If
        Dim sql As String = "SELECT p.mes,p.ano,t.descripcion As tipo,c.cuenta ,c.descripcion As desc_cuenta ,(SELECT SUM (ppto) FROM J_ppto_gastos WHERE cuenta = c.cuenta  AND p.mes = mes AND ano =  p.ano " & where_centro & " ) As presupuesto ,  (SELECT SUM (valor) FROM movimiento WHERE cuenta = c.cuenta AND Year(fec) = p.ano AND MONTH(fec) = p.mes " & where_centro & " ) As saldo,(select sum(cantidad * precio_unit) from PRGPRODUCCION.dbo.J_solicitud_compra_det m join PRGPRODUCCION.dbo.J_solicitud_compra_enc l on m.numero=l.numero  where m.cuenta=c.cuenta and l.terminado is null) as ordenes_debe ,(SELECT SUM (ppto) FROM J_ppto_gastos WHERE cuenta = c.cuenta  AND ano =  p.ano " & where_centro & " ) As acum_ppto, (SELECT SUM (valor) FROM movimiento WHERE cuenta = c.cuenta AND Year(fec) = p.ano  " & where_centro & "  ) As acum_saldo " & _
                             "FROM j_ppto_gastos_tipo t, J_ppto_gastos_cuentas g , cuentas c , J_ppto_gastos p    " & _
                                "WHERE g.tipo = t.id And g.cuenta = c.cuenta And p.cuenta = g.cuenta And p.mes = " & mes & " And p.ano = " & ano & " " & where_permiso & _
                                    "GROUP BY p.mes,p.ano,t.descripcion, c.cuenta ,c.descripcion ,g.orden   " & _
                                        "ORDER BY p.ano,p.mes,g.orden "
        'Dim sql As String = "SELECT p.mes,p.ano,t.descripcion As tipo,m.cuenta ,c.descripcion As desc_cuenta , ppto As presupuesto , SUM(valor) A55s saldo " & _
        '        ",(SELECT SUM (ppto) FROM J_ppto_gastos WHERE cuenta = m.cuenta  AND ano =  p.ano) As acum_ppto, (SELECT SUM (valor) FROM movimiento WHERE cuenta = m.cuenta AND Year(fec) = p.ano ) As acum_saldo " & _
        '                         "FROM j_ppto_gastos_tipo t, J_ppto_gastos_cuentas g , cuentas c , J_ppto_gastos p , movimiento m , centros s   " & _
        '                            "WHERE s.centro = m.centro And m.cuenta = c.cuenta And g.tipo = t.id And g.cuenta = c.cuenta And p.cuenta = g.cuenta And p.mes = " & mes & " And p.ano = " & ano & " And p.mes = Month(m.fec) And p.ano = Year(m.fec) " & where_centro & where_permiso & _
        '                            "GROUP BY p.mes,p.ano,t.descripcion ,m.cuenta ,c.descripcion , ppto ,g.orden  " & _
        '                                "ORDER BY p.ano,p.mes,g.orden"
        '  Dim sql As String = "SELECT p.mes,p.ano,t.descripcion As tipo,g.cuenta ,c.descripcion As desc_cuenta , ppto As presupuesto , SUM(debito)-SUM(credito) As saldo " & _
        '           "FROM j_ppto_gastos_tipo t, J_ppto_gastos_cuentas g , cuentas c , J_ppto_gastos p , cuentas_val v " & _
        '    "WHERE g.tipo = t.id And g.cuenta = c.cuenta And p.cuenta = g.cuenta And p.mes = " & mes & " And p.ano = " & ano & " And v.cuenta = c.cuenta And p.mes = v.mes And p.ano = v.ano " & _
        '     "GROUP BY t.descripcion ,g.cuenta ,c.descripcion  , ppto ,g.orden ,p.mes,p.ano " & _
        '      "ORDER BY  p.mes,p.ano, g.orden"
        Dim dt As DataTable = obj_op_simplesLn.listar_datatable(sql, "CORSAN")
        Dim dt_final As New DataTable
        Dim tipo_Ant As String = ""
        For j = 0 To dt.Columns.Count - 1
            If dt.Columns(j).ColumnName = "tipo" Or dt.Columns(j).ColumnName = "cuenta" Or dt.Columns(j).ColumnName = "desc_cuenta" Then
                dt_final.Columns.Add(dt.Columns(j).ColumnName)
            Else
                dt_final.Columns.Add(dt.Columns(j).ColumnName, GetType(Double))
            End If
        Next
        For i = 0 To dt.Rows.Count - 1
            If Not IsDBNull(dt.Rows(i).Item("tipo")) Then
                If tipo_Ant <> (dt.Rows(i).Item("tipo")) Then
                    If tipo_Ant <> "" Then
                        dt_final.Rows.Add()
                        dt_final.Rows(dt_final.Rows.Count - 1).Item("desc_cuenta") = "TOTAL " & tipo_Ant
                    End If
                    tipo_Ant = (dt.Rows(i).Item("tipo"))
                End If
                dt_final.Rows.Add()
                For j = 0 To dt.Columns.Count - 1
                    dt_final.Rows(dt_final.Rows.Count - 1).Item(dt.Columns(j).ColumnName) = dt.Rows(i).Item(j)
                Next
            End If
        Next
        If dt.Rows.Count > 0 Then
            dt_final.Rows.Add()
            dt_final.Rows(dt_final.Rows.Count - 1).Item("desc_cuenta") = "TOTAL " & tipo_Ant
        End If
        Return dt_final
    End Function

    Private Sub eliminar_sin_ppto(ByRef dt As DataTable)
        For i = 0 To dt.Rows.Count - 1
            If i < dt.Rows.Count Then
                If Not IsDBNull(dt.Rows(i).Item("presupuesto")) Then
                    dt.Rows(i).Delete()
                End If
            End If
        Next
    End Sub
    
    Private Sub calcular_cumplimiento_articulos(ByRef dt As DataTable)
        Dim sum_ppto As Double = 0
        Dim sum_cantidad As Double = 0
        If dt.Rows.Count > 0 Then
            For i = 0 To dt.Rows.Count - 2
                If IsNumeric(dt.Rows(i).Item("cantidad")) Then
                    If (dt.Rows(i).Item("presupuesto") = 0 Or dt.Rows(i).Item("cantidad") = 0) Then
                        dt.Rows(i).Item("porc_cump") = 0
                        dt.Rows(i).Item("diferencia") = 0
                    Else
                        dt.Rows(i).Item("porc_cump") = (dt.Rows(i).Item("cantidad") / dt.Rows(i).Item("presupuesto")) * 100
                        dt.Rows(i).Item("diferencia") = dt.Rows(i).Item("presupuesto") - dt.Rows(i).Item("cantidad")
                        dt.Rows(i).Item("diferencia_costo") = dt.Rows(i).Item("costo_ppto") - dt.Rows(i).Item("cto_total")
                        sum_ppto += dt.Rows(i).Item("presupuesto")
                        sum_cantidad += dt.Rows(i).Item("cantidad")
                    End If
                End If
            Next
            dt.Rows(dt.Rows.Count - 1).Item("porc_cump") = (sum_cantidad / sum_ppto) * 100
        End If
    End Sub
    Private Sub calcular_cumplimiento(ByRef dt As DataTable)
        Dim sum_ppto As Double = 0
        Dim sum_saldo As Double = 0
        If dt.Rows.Count > 0 Then
            For i = 0 To dt.Rows.Count - 2
                If IsNumeric(dt.Rows(i).Item("saldo")) Then
                    If IsNumeric(dt.Rows(i).Item("presupuesto")) Then
                        If (dt.Rows(i).Item("presupuesto") = 0 Or dt.Rows(i).Item("saldo") = 0) Then
                            dt.Rows(i).Item("porc_cump") = 0
                        Else
                            dt.Rows(i).Item("porc_cump") = (dt.Rows(i).Item("saldo") / dt.Rows(i).Item("presupuesto")) * 100
                            sum_ppto += dt.Rows(i).Item("presupuesto")
                            sum_saldo += dt.Rows(i).Item("saldo")
                        End If
                    Else
                        dt.Rows(i).Item("presupuesto") = 0
                        dt.Rows(i).Item("porc_cump") = 0
                    End If
                    dt.Rows(i).Item("diferencia") = dt.Rows(i).Item("presupuesto") - dt.Rows(i).Item("saldo")
                ElseIf IsNumeric(dt.Rows(i).Item("presupuesto")) Then
                    dt.Rows(i).Item("diferencia") = dt.Rows(i).Item("presupuesto") - 0
                Else
                    dt.Rows(i).Item("diferencia") = 0
                End If
            Next
            dt.Rows(dt.Rows.Count - 1).Item("porc_cump") = (sum_saldo / sum_ppto) * 100
        End If
    End Sub
    Private Sub calcular_diferencia_orden(ByRef dt As DataTable)
        Dim sum_ppto As Double = 0
        Dim sum_saldo As Double = 0
        Dim sum_ordenes As Double = 0
        If dt.Rows.Count > 0 Then
            For i = 0 To dt.Rows.Count - 2
                If IsNumeric(dt.Rows(i).Item("saldo")) Then
                    If IsNumeric(dt.Rows(i).Item("presupuesto")) Then
                        If Not IsNumeric(dt.Rows(i).Item("ordenes_debe")) Then
                            dt.Rows(i).Item("ordenes_debe") = 0
                        End If
                        If (dt.Rows(i).Item("presupuesto") = 0 Or dt.Rows(i).Item("saldo") = 0) Then
                            dt.Rows(i).Item("porc_cump_orden") = 0
                        Else
                            dt.Rows(i).Item("porc_cump_orden") = (((dt.Rows(i).Item("saldo") + dt.Rows(i).Item("ordenes_debe")) / dt.Rows(i).Item("presupuesto")) * 100)
                            sum_ppto += dt.Rows(i).Item("presupuesto")
                            sum_saldo += dt.Rows(i).Item("saldo")
                            sum_ordenes += dt.Rows(i).Item("ordenes_debe")
                        End If
                        dt.Rows(i).Item("diferencia_orden") = dt.Rows(i).Item("presupuesto") - (dt.Rows(i).Item("saldo") + dt.Rows(i).Item("ordenes_debe"))
                    Else
                        dt.Rows(i).Item("presupuesto") = 0
                        dt.Rows(i).Item("porc_cump_orden") = 0
                    End If
                ElseIf IsNumeric(dt.Rows(i).Item("presupuesto")) Then
                    dt.Rows(i).Item("diferencia_orden") = dt.Rows(i).Item("presupuesto") - 0
                Else
                    dt.Rows(i).Item("diferencia_orden") = 0
                End If
            Next
            dt.Rows(dt.Rows.Count - 1).Item("porc_cump_orden") = (((sum_saldo + sum_ordenes) / sum_ppto) * 100)
        End If
    End Sub
    Private Sub btn_actualizar_Click(sender As Object, e As EventArgs) Handles btn_actualizar.Click
        carga_comp = False
        consultar()
        consultar_articulos()
        carga_comp = True
    End Sub
    Private Sub consultar_articulos()
        img_procesar.Visible = True
        Application.DoEvents()
        Dim where_centro As String = ""

        If cbo_centro.SelectedValue <> 0 Then
            where_centro = " AND p.centro = " & cbo_centro.SelectedValue
        Else
            If centros <> "" Then
                where_centro = " AND p.centro IN( " & centros & ") "
            End If
        End If

        Dim sql As String = "SELECT year(d.fecha) As ano, month(d.fecha) As mes, d.tipo,d.centro_doc,l.codigo,r.descripcion, AVG(l.costo_unitario) * SUM(l.cantidad) as cto_total ,SUM(l.cantidad ) as cantidad ,p.cantidad As presupuesto,p.costo As costo_ppto " & _
                                "FROM documentos d , documentos_lin l , referencias r, PRGPRODUCCION.dbo.J_ppto_articulos p " & _
                                    "WHERE p.centro = d.centro_doc AND p.codigo = l.codigo AND l.codigo = r.codigo  AND d.tipo = 'COIS'AND MONTH(d.fecha)=" & mes & " and p.ano= YEAR(d.fecha) AND p.mes=MONTH(d.fecha) and year(d.fecha)=" & ano & " AND d.numero = l.numero AND d.tipo = l.tipo " & where_centro & " " & _
                                        "GROUP BY d.tipo,d.centro_doc,l.codigo,year(d.fecha) , month(d.fecha) ,r.descripcion,p.cantidad,p.costo  " & _
                                            "ORDER BY d.centro_doc,r.descripcion "
        Dim dt As DataTable = obj_op_simplesLn.listar_datatable(sql, "CORSAN")

        dt.Columns.Add("diferencia", GetType(Double))
        dt.Columns.Add("diferencia_costo", GetType(Double))
        dt.Columns.Add("porc_cump", GetType(Double))
        dt.Rows.Add()

        calcular_cumplimiento_articulos(dt)
        totalizarDt(dt)
        dtg_ppto_aticulos.DataSource = dt
        formatoDtg_articulos()
        dtg_ppto_aticulos.Columns("porc_cump").HeaderText = "%mes"
        dtg_ppto_aticulos.Columns("cto_total").DefaultCellStyle.Format = "c0"
        dtg_ppto_aticulos.Columns("costo_ppto").DefaultCellStyle.Format = "c0"
        dtg_ppto_aticulos.Columns("diferencia_costo").DefaultCellStyle.Format = "c0"
        img_procesar.Visible = False
    End Sub
    Private Sub formatoDtg()
        Dim nom_col As String = ""
        Dim tamano_letra As Single = 7.5!
        If dtg_consulta.Rows.Count > 0 Then
            dtg_consulta.Item("tipo", dtg_consulta.Rows.Count - 1).Value = "TOTAL"
            dtg_consulta.Columns("porc_cump").DefaultCellStyle = objOperacionesForm.formatoNegrita(tamano_letra)
            dtg_consulta.Columns("porc_cump").DefaultCellStyle.Format = "N2"
            dtg_consulta.Columns("porc_cump_orden").DefaultCellStyle = objOperacionesForm.formatoNegrita(tamano_letra)
            dtg_consulta.Columns("porc_cump_orden").DefaultCellStyle.Format = "N2"
            dtg_consulta.Columns("porc_tend_mes").DefaultCellStyle.Format = "N2"
            dtg_consulta.Columns("cump_prod").DefaultCellStyle.Format = "N2"
            dtg_consulta.Columns("centro_tendencia").Visible = False
            dtg_consulta.Columns("porc_tend_hoy").DefaultCellStyle.Format = "N2"
            dtg_consulta.Columns("saldo").DefaultCellStyle = objOperacionesForm.formatoNegrita(tamano_letra)
            dtg_consulta.Columns("porc_tend_mes").HeaderText = "%_tend_mes"
            dtg_consulta.Columns("porc_tend_hoy").HeaderText = "%_tend_hoy"
            dtg_consulta.Columns("cump_prod").HeaderText = "%_prod"
            dtg_consulta.Columns("cump_hoy_prod").HeaderText = "%_hoy_prod"
            For j = 0 To dtg_consulta.Columns.Count - 1
                nom_col = dtg_consulta.Columns(j).Name
                If (nom_col = "porc_tend_hoy" Or nom_col = "porc_tend_mes" Or nom_col = "porc_cump" Or nom_col = "cuenta" Or nom_col = "diferencia" Or nom_col = "porc_cump_orden" Or nom_col = "diferencia_orden") Then
                    For i = 0 To dtg_consulta.Rows.Count - 1
                        If nom_col = "cuenta" Then
                            If IsDBNull(dtg_consulta.Item(j, i).Value) Then
                                dtg_consulta.Rows(i).DefaultCellStyle = objOperacionesForm.formatoNegrita(tamano_letra)
                            End If
                        ElseIf nom_col = "porc_cump" Or nom_col = "porc_cump_orden" Then
                            If Not IsDBNull(dtg_consulta.Item(j, i).Value) Then
                                If (dtg_consulta.Item(j, i).Value >= 100) Then
                                    dtg_consulta.Item(j, i).Style.BackColor = Color.Red
                                ElseIf dtg_consulta.Item(j, i).Value >= 90 And dtg_consulta.Item(j, i).Value <= 99 Then
                                    dtg_consulta.Item(j, i).Style.BackColor = Color.Yellow
                                Else
                                    dtg_consulta.Item(j, i).Style.BackColor = Color.GreenYellow
                                End If
                            End If
                        ElseIf nom_col = "porc_tend_mes" Then
                            If Not IsDBNull(dtg_consulta.Item(j, i).Value) Then
                                If (dtg_consulta.Item(j, i).Value >= 100) Then
                                    dtg_consulta.Item(j, i).Style.BackColor = Color.Red
                                ElseIf dtg_consulta.Item(j, i).Value >= 90 And dtg_consulta.Item(j, i).Value <= 99 Then
                                    dtg_consulta.Item(j, i).Style.BackColor = Color.Yellow
                                Else
                                    dtg_consulta.Item(j, i).Style.BackColor = Color.GreenYellow
                                End If
                            End If
                        ElseIf nom_col = "porc_tend_hoy" Then
                            If Not IsDBNull(dtg_consulta.Item(j, i).Value) Then
                                If (dtg_consulta.Item(j, i).Value >= 100) Then
                                    dtg_consulta.Item(j, i).Style.BackColor = Color.Red
                                ElseIf dtg_consulta.Item(j, i).Value >= 90 And dtg_consulta.Item(j, i).Value <= 99 Then
                                    dtg_consulta.Item(j, i).Style.BackColor = Color.Yellow
                                Else
                                    dtg_consulta.Item(j, i).Style.BackColor = Color.GreenYellow
                                End If
                            End If
                        ElseIf nom_col = "diferencia" Or nom_col = "diferencia_orden" Then
                            If Not IsDBNull(dtg_consulta.Item(j, i).Value) Then
                                If (dtg_consulta.Item(j, i).Value < 0) Then
                                    dtg_consulta.Item(j, i).Style.BackColor = Color.Red
                                End If
                            End If
                        End If
                    Next
                End If
            Next
        End If
    End Sub
    Private Sub formatoDtg_articulos()
        Dim nom_col As String = ""
        Dim tamano_letra As Single = 7.5!
        If dtg_ppto_aticulos.Rows.Count > 0 Then
            dtg_ppto_aticulos.Item("tipo", dtg_ppto_aticulos.Rows.Count - 1).Value = "TOTAL"
            dtg_ppto_aticulos.Columns("porc_cump").DefaultCellStyle = objOperacionesForm.formatoNegrita(tamano_letra)
            dtg_ppto_aticulos.Columns("porc_cump").DefaultCellStyle.Format = "N2"
            dtg_ppto_aticulos.Columns("cantidad").DefaultCellStyle = objOperacionesForm.formatoNegrita(tamano_letra)
            For j = 0 To dtg_ppto_aticulos.Columns.Count - 1
                nom_col = dtg_ppto_aticulos.Columns(j).Name
                If (nom_col = "porc_cump" Or nom_col = "diferencia") Then
                    For i = 0 To dtg_ppto_aticulos.Rows.Count - 1
                        If nom_col = "porc_cump" Then
                            If Not IsDBNull(dtg_ppto_aticulos.Item(j, i).Value) Then
                                If (dtg_ppto_aticulos.Item(j, i).Value >= 100) Then
                                    dtg_ppto_aticulos.Item(j, i).Style.BackColor = Color.Red
                                ElseIf dtg_ppto_aticulos.Item(j, i).Value >= 90 And dtg_ppto_aticulos.Item(j, i).Value <= 99 Then
                                    dtg_ppto_aticulos.Item(j, i).Style.BackColor = Color.Yellow
                                Else
                                    dtg_ppto_aticulos.Item(j, i).Style.BackColor = Color.GreenYellow
                                End If
                            End If
                        ElseIf nom_col = "diferencia" Then
                            If Not IsDBNull(dtg_ppto_aticulos.Item(j, i).Value) Then
                                If (dtg_ppto_aticulos.Item(j, i).Value < 0) Then
                                    dtg_ppto_aticulos.Item(j, i).Style.BackColor = Color.Red
                                End If
                            End If
                        End If
                    Next
                End If
            Next
        End If
    End Sub
    Private Sub totalizar_tipo_producto(ByRef dt As DataTable)
        Dim sum As Double = 0
        For j = 0 To dt.Columns.Count - 1
            If (dt.Columns(j).ColumnName = "presupuesto" Or dt.Columns(j).ColumnName = "saldo" Or dt.Columns(j).ColumnName = "porc_cump" Or dt.Columns(j).ColumnName = "diferencia" Or dt.Columns(j).ColumnName = "acum_ppto" Or dt.Columns(j).ColumnName = "acum_saldo" Or dt.Columns(j).ColumnName = "ordenes_debe" Or dt.Columns(j).ColumnName = "diferencia_orden" Or dt.Columns(j).ColumnName = "porc_cump_orden") Then
                For i = 0 To dt.Rows.Count - 2
                    If Not IsDBNull(dt.Rows(i).Item(j)) Then
                        sum += dt.Rows(i).Item(j)
                    End If
                    If IsDBNull(dt.Rows(i).Item("cuenta")) Then

                        If i <> dt.Columns.Count - 3 Then
                            If (dt.Columns(j).ColumnName = "porc_cump") Then
                                If IsNumeric(dt.Rows(i).Item("saldo")) And IsNumeric(dt.Rows(i).Item("presupuesto")) Then
                                    dt.Rows(i).Item(j) = (dt.Rows(i).Item("saldo") / dt.Rows(i).Item("presupuesto")) * 100
                                End If
                            ElseIf (dt.Columns(j).ColumnName = "porc_cump_orden") Then
                                If IsNumeric(dt.Rows(i).Item("saldo")) And IsNumeric(dt.Rows(i).Item("presupuesto")) And IsNumeric(dt.Rows(i).Item("ordenes_debe")) Then
                                    dt.Rows(i).Item(j) = ((dt.Rows(i).Item("saldo") + dt.Rows(i).Item("ordenes_debe")) / dt.Rows(i).Item("presupuesto")) * 100
                                Else
                                    dt.Rows(i).Item(j) = (dt.Rows(i).Item("saldo") / dt.Rows(i).Item("presupuesto")) * 100
                                End If
                            Else
                                dt.Rows(i).Item(j) = sum
                                sum = 0
                            End If
                        End If
                    End If
                Next
                sum = 0
            End If
        Next
    End Sub
    Private Sub totalizarDt(ByRef dt As DataTable)
        Dim sum As Double = 0

        If dt.Columns.Count > 0 Then
            For j = 0 To dt.Columns.Count - 1
                If (dt.Columns(j).ColumnName = "costo_ppto" Or dt.Columns(j).ColumnName = "presupuesto" Or dt.Columns(j).ColumnName = "cantidad" Or dt.Columns(j).ColumnName = "saldo" Or dt.Columns(j).ColumnName = "diferencia" Or dt.Columns(j).ColumnName = "cantidad" Or dt.Columns(j).ColumnName = "acum_ppto" Or dt.Columns(j).ColumnName = "acum_saldo" Or dt.Columns(j).ColumnName = "cto_total" Or dt.Columns(j).ColumnName = "diferencia_costo" Or dt.Columns(j).ColumnName = "diferencia_orden" Or dt.Columns(j).ColumnName = "porc_cump_orden") Then
                    For i = 0 To dt.Rows.Count - 2
                        If Not IsDBNull(dt.Rows(i).Item(j)) Then
                            sum += dt.Rows(i).Item(j)
                        End If
                    Next
                    dt.Rows(dt.Rows.Count - 1).Item(j) = sum
                    sum = 0
                End If
            Next
        End If

    End Sub
    Private Sub cbo_mes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbo_mes.SelectedIndexChanged
        If carga_comp Then
            mes = cbo_mes.SelectedIndex + 1
        End If
    End Sub

    Private Sub cbo_ano_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbo_ano.SelectedIndexChanged
        If carga_comp Then
            ano = cbo_ano.Text
        End If
    End Sub

    Private Sub dtg_consulta_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dtg_consulta.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            With (Me.dtg_consulta)
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                End If
            End With
        End If
        fila_select = dtg_consulta.CurrentCell.RowIndex
    End Sub

    Private Sub itemDetalle_Click(sender As Object, e As EventArgs) Handles itemDetalle.Click
        If Not IsDBNull(dtg_consulta.Item("cuenta", fila_select).Value) Then
            dtg_detalle.DataSource = Nothing
            groupDetalle.Visible = True
            Dim tamano_letra As Single = 7.5!
            Dim mes_detalle As Integer = dtg_consulta.Item("mes", fila_select).Value
            Dim ano_detalle As Integer = dtg_consulta.Item("ano", fila_select).Value
            Dim cuenta As Integer = dtg_consulta.Item("cuenta", fila_select).Value
            Dim where_centro As String = ""
            If centros <> "" Then
                If cbo_centro.SelectedValue <> 0 Then
                    where_centro = " AND s.centro = " & cbo_centro.SelectedValue
                Else
                    where_centro = " AND s.centro IN( " & centros & ") "
                End If

            End If
            Dim sql As String = "SELECT c.cuenta,s.centro,s.descripcion As desc_centro,sum( m.valor) as saldo  " & _
                      "FROM terceros ter,j_ppto_gastos_tipo t, J_ppto_gastos_cuentas g , cuentas c , movimiento m , centros s  " & _
                                  "WHERE ter.nit = m.nit AND s.centro = SUBSTRING ( cast(m.centro As varchar (25)) ,0 , 3 ) + '00' And m.cuenta = c.cuenta And g.tipo = t.id And g.cuenta = c.cuenta  And Month(m.fec) = " & mes & " And YEAR(m.fec) = " & ano & " And c.cuenta = " & cuenta & "  " & where_centro & " " & _
                              "GROUP BY c.cuenta ,s.centro,s.descripcion "
            Dim dt As DataTable = obj_op_simplesLn.listar_datatable(sql, "CORSAN")
            dt.Columns.Add("presupuesto", GetType(Double))
            dt.Columns.Add("porc_cump", GetType(Double))
            dt.Columns.Add("diferencia", GetType(Double))
            sql = "SELECT centro,SUM(ppto) As presupuesto " & _
                        "FROM J_ppto_gastos " & _
                                "WHERE centro is not null AND mes = " & mes & " AND ano = " & ano & " AND cuenta = " & cuenta & " " & _
                                    "GROUP BY centro"
            Dim dt_ppto As DataTable = obj_op_simplesLn.listar_datatable(sql, "CORSAN")
            If dt_ppto.Rows.Count = 0 And dt.Rows.Count = 1 Then
                dt.Rows(dt.Rows.Count - 1).Item("presupuesto") = dtg_consulta.Item("presupuesto", fila_select).Value
            Else
                For i = 0 To dt_ppto.Rows.Count - 1
                    For z = 0 To dt.Rows.Count - 1
                        If dt_ppto.Rows(i).Item("centro") = dt.Rows(z).Item("centro") Then
                            dt.Rows(z).Item("presupuesto") = dt_ppto.Rows(i).Item("presupuesto")
                            z = dt.Rows.Count - 1
                        End If
                    Next
                Next
            End If
            dt.Rows.Add()
            calcular_cumplimiento(dt)
            totalizarDt(dt)
            If dt_ppto.Rows.Count = 0 And dt.Rows.Count > 1 Then
                dt.Rows(dt.Rows.Count - 1).Item("presupuesto") = dtg_consulta.Item("presupuesto", fila_select).Value
            End If
            dtg_detalle.DataSource = dt
            For j = 0 To dt.Columns.Count - 1
                If (dt.Columns(j).ColumnName = "diferencia" Or dt.Columns(j).ColumnName = "presupuesto" Or dt.Columns(j).ColumnName = "saldo" Or dt.Columns(j).ColumnName = "cantidad") Then
                    dtg_detalle.Columns(j).DefaultCellStyle.Format = "N0"
                ElseIf (dt.Columns(j).ColumnName = "porc_cump") Then
                    dtg_detalle.Columns(j).DefaultCellStyle.Format = "N2"
                End If
            Next
            dtg_detalle.Rows(dtg_detalle.Rows.Count - 1).DefaultCellStyle = objOperacionesForm.formatoNegrita(tamano_letra)
        End If
    End Sub


    Private Sub btn_cerrar_Click(sender As Object, e As EventArgs) Handles btn_cerrar.Click
        groupDetalle.Visible = False
    End Sub
    Private Sub btnOcultPermisos_Click(sender As Object, e As EventArgs) Handles btnOcultPermisos.Click
        groupPermisos.Visible = False
    End Sub
    Private Sub btnAddColumna_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddColumna.Click
        addColumna()
    End Sub
    Private Sub addColumna()
        If (permiso <> "") Then
            Dim sql As String = "INSERT INTO J_ppto_gastos_permisos_cuentas(cuenta,permiso) VALUES ('" & columnaArbol & "','" & permiso & "')"
            If (obj_op_simplesLn.consultarVal("SELECT cuenta FROM J_ppto_gastos_permisos_cuentas WHERE cuenta = '" & columnaArbol & "' AND permiso = '" & permiso & "'") <> "") Then
                MessageBox.Show("El tipo ya fue asignado para este permiso")
            ElseIf (obj_op_simplesLn.ejecutar(sql, "CORSAN")) Then
                listPermisosUsuario.Items.Add(columnaArbol)
            Else
                MsgBox("Error al otorgar el permiso")
            End If
        Else
            MessageBox.Show("Seleccione tipo de permiso para asignar funcionalidad", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
    Private Sub btnQuitarcol_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuitarCol.Click
        Dim Columna As String = listPermisosUsuario.SelectedItem
        Dim indexMod As Integer = 0
        Dim resp As Integer = 0
        Dim sql As String = ""
        If (Columna <> "" And permiso <> "") Then
            resp = MessageBox.Show("Esta seguro de quitar este permiso? ", "Quitar", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
            If (resp = 6) Then
                sql = "DELETE FROM J_ppto_gastos_permisos_cuentas WHERE permiso ='" & Columna & "' AND cuenta = '" & permiso & "'"
                If (obj_op_simplesLn.ejecutar(sql, "CORSAN") > 0) Then
                    indexMod = listPermisosUsuario.SelectedIndex
                    listPermisosUsuario.Items.Remove(listPermisosUsuario.Items(indexMod))
                Else
                    MsgBox("Error al eliminar")
                End If
            End If
        Else
            MsgBox("Seleccione permiso y columna a eliminar")
        End If
    End Sub
    Private Sub listColumnas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles list_cuentas.SelectedIndexChanged
        columnaArbol = list_cuentas.SelectedItem
        addColumna()
    End Sub
    Private Sub listPermisosUsuario_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles listaTipoUsu.SelectedIndexChanged
        permiso = listaTipoUsu.SelectedItem
        Dim sql As String = "SELECT cuenta FROM J_ppto_gastos_permisos_cuentas   WHERE permiso = '" & permiso & "'"
        cargarLista(listPermisosUsuario, sql)
    End Sub

    Private Sub btnConfigPermisos_Click(sender As Object, e As EventArgs) Handles btnConfigPermisos.Click
        groupPermisos.Visible = True
    End Sub

    Private Sub DetalleToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DetalleToolStripMenuItem.Click
        objOperacionesForm.ExportarDatosExcel(dtg_detalle, "Seguimiento de gastos")
    End Sub

    Private Sub GeneralToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GeneralToolStripMenuItem.Click
        objOperacionesForm.ExportarDatosExcel(dtg_consulta, "Seguimiento de gastos")
    End Sub

    Private Sub btn_cerrar_producto_Click(sender As Object, e As EventArgs) Handles btn_cerrar_producto.Click
        group_producto.Visible = False
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        If Not IsDBNull(dtg_detalle.Item("cuenta", fila_detalle).Value) Then
            dtg_det_producto.DataSource = Nothing
            group_producto.Visible = True
            group_producto.BringToFront()
            Dim tamano_letra As Single = 7.5!
            Dim mes_detalle As Integer = dtg_consulta.Item("mes", fila_select).Value
            Dim ano_detalle As Integer = dtg_consulta.Item("ano", fila_select).Value
            Dim cuenta As Integer = dtg_detalle.Item("cuenta", fila_detalle).Value
            Dim where_centro As String = ""
            If centros <> "" Then
                where_centro = " AND s.centro IN( " & centros & ") "
            End If
            Dim sql As String = ""

            sql = "SELECT s.centro , s.descripcion,c.descripcion As desc_cuenta,ref.codigo, ref.descripcion,SUM (lin.cantidad )As cantidad  ,SUM (lin.cantidad  * lin.costo_unitario)As saldo " & _
                        "FROM j_ppto_gastos_tipo t, J_ppto_gastos_cuentas g , cuentas c , J_ppto_gastos p , movimiento m , centros s ,documentos_lin lin , documentos doc, referencias ref " & _
                         "WHERE m.numero = doc.numero And m.tipo = doc.tipo And doc.numero = lin.numero And lin.tipo = doc.tipo And ref.codigo = lin.codigo And s.centro = m.centro And m.cuenta = c.cuenta And g.tipo = t.id And g.cuenta = c.cuenta And p.cuenta = g.cuenta And p.mes = " & mes & " And p.ano = " & ano & " And p.mes = Month(m.fec) And p.ano = Year(m.fec) And c.cuenta = " & cuenta & "  " & where_centro & " " & _
                         "GROUP BY s.centro , s.descripcion,c.descripcion ,ref.codigo, ref.descripcion"
            Dim dt As DataTable = obj_op_simplesLn.listar_datatable(sql, "CORSAN")
            dt.Rows.Add()
            totalizarDt(dt)
            dtg_det_producto.DataSource = dt
            For j = 0 To dt.Columns.Count - 1
                If (dt.Columns(j).ColumnName = "diferencia" Or dt.Columns(j).ColumnName = "saldo" Or dt.Columns(j).ColumnName = "cantidad") Then
                    dtg_det_producto.Columns(j).DefaultCellStyle.Format = "N0"
                End If
            Next
            dtg_det_producto.Rows(dtg_det_producto.Rows.Count - 1).DefaultCellStyle = objOperacionesForm.formatoNegrita(tamano_letra)
        End If
    End Sub
    Private Sub dtg_detalle_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dtg_detalle.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            With (Me.dtg_detalle)
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                End If
            End With
        End If
        fila_detalle = dtg_detalle.CurrentCell.RowIndex
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        objOperacionesForm.ExportarDatosExcel(dtg_det_producto, "Seguimiento de gastos")
    End Sub
    Private Sub add_tendencia(ByRef dt As DataTable)
        dt.Columns.Add("centro_tendencia")
        Dim dt_dias_habileS_general As DataTable = obj_ppto_produccionLn.cargar_dias_habiles_general(mes, ano)
        Dim dias_habiles As Double = 0
        Dim dias_adic As Double = 0
        Dim dias_trabajados_otros As Double = 0
        For i = 0 To dt_dias_habileS_general.Rows.Count - 1
            dias_habiles = dt_dias_habileS_general.Rows(i).Item("dias_habiles")
            dias_adic = dt_dias_habileS_general.Rows(i).Item("dias_adic")
            dias_trabajados_otros = dt_dias_habileS_general.Rows(i).Item("dias_trabajados_otros")
        Next
        Dim dt_ppto_prod As DataTable = obj_ppto_produccionLn.cargar_seguimiento_gral_area(dias_habiles, dias_adic, dias_trabajados_otros, mes, ano)
        Dim sql_centro_cuenta As String = "SELECT centro,cuenta FROM J_ppto_gastos_centro_cuenta "
        Dim dt_centro_cuenta As DataTable = obj_op_simplesLn.listar_datatable(sql_centro_cuenta, "CORSAN")
        dt.Columns.Add("cump_prod", GetType(Double))
        dt.Columns.Add("cump_hoy_prod", GetType(Double))
        dt.Columns.Add("tend_mes", GetType(Double))
        dt.Columns.Add("tend_hoy", GetType(Double))
        dt.Columns.Add("porc_tend_mes", GetType(Double))
        dt.Columns.Add("porc_tend_hoy", GetType(Double))
        For i = 0 To dt_centro_cuenta.Rows.Count - 1
            For k = 0 To dt.Rows.Count - 1
                If IsNumeric(dt.Rows(k).Item("cuenta")) Then
                    If dt_centro_cuenta.Rows(i).Item("cuenta") = dt.Rows(k).Item("cuenta") Then
                        dt.Rows(k).Item("centro_tendencia") = dt_centro_cuenta.Rows(i).Item("centro")
                        k = dt.Rows.Count - 1
                    End If
                End If
            Next
        Next
        For i = 0 To dt_ppto_prod.Rows.Count - 1
            For k = 0 To dt.Rows.Count - 1
                If IsNumeric(dt.Rows(k).Item("centro_tendencia")) Then
                    If dt_ppto_prod.Rows(i).Item("centro") = dt.Rows(k).Item("centro_tendencia") Then
                        dt.Rows(k).Item("cump_prod") = dt_ppto_prod.Rows(i).Item("cump")
                        dt.Rows(k).Item("cump_hoy_prod") = dt_ppto_prod.Rows(i).Item("cump_hoy")
                        If IsNumeric(dt.Rows(k).Item("saldo")) And IsNumeric(dt.Rows(k).Item("presupuesto")) And IsNumeric(dt_ppto_prod.Rows(i).Item("cump_hoy")) Then
                            dt.Rows(k).Item("tend_mes") = dt.Rows(k).Item("presupuesto") * (dt_ppto_prod.Rows(i).Item("cump") / 100)
                            dt.Rows(k).Item("tend_hoy") = dt.Rows(k).Item("presupuesto") * (dt_ppto_prod.Rows(i).Item("cump_hoy") / 100)
                            If IsNumeric(dt.Rows(k).Item("saldo")) Then
                                dt.Rows(k).Item("porc_tend_hoy") = (dt.Rows(k).Item("saldo") / dt.Rows(k).Item("tend_mes")) * 100
                                dt.Rows(k).Item("porc_tend_mes") = (dt.Rows(k).Item("saldo") / dt.Rows(k).Item("tend_hoy")) * 100
                            End If
                        End If
                    End If
                End If
            Next
        Next

    End Sub
End Class