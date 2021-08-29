Imports logicaNegocios
Imports entidadNegocios
Imports accesoDatos
Public Class Frm_informe_pend__vent
    Private obj_Ing_prodLn As New Ing_prodLn
    Private Sub Frm_informe_pend__vent_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargar_pendientes_Ventas()
        cargar_pendientes_Ventas_2()
    End Sub
    'Pendientes de ventas para el concepto 1 
    Private Sub cargar_pendientes_Ventas()
        Dim sum As Double = 0
        Dim sql As String = "SELECT p.id_Cor,p.linea_produccion,p.codigo,p.descripcion,p.bodega,AVG(r.stock)As stock,(AVG(r.stock)-SUM(p.Pendiente))As pend_prod, (AVG(r.stock)-SUM(p.Pendiente))As val_pend_prod, (AVG(r.stock))As pend_log,(AVG(r.stock))As val_pend_log,SUM(p.Pendiente)As Pendiente,(SUM(p.valor_total)/SUM(p.Pendiente)) As valor_unitario,SUM( p.valor_total) As valor_total " & _
                    "FROM J_v_pendientes_por_vendedor_id_cor p ,v_referencias_sto_hoy r " & _
                        "WHERE p.bodega = r.bodega AND p.codigo = r.codigo and p.concepto in (1) and year(p.fecha)=year(GETDATE()) and month(p.fecha)=month(GETDATE())" & _
                            "GROUP BY p.id_Cor,p.linea_produccion,p.codigo, p.descripcion,p.bodega " & _
                             " ORDER BY p.id_Cor,p.linea_produccion,p.bodega"
        Dim dt As New DataTable
        dt = obj_Ing_prodLn.listar_datatable(sql, "CORSAN")
        calcular_prod_log(dt)
        dt = consolidarLineaProduccion(dt)

        dt.Rows.Add()
        For j = 0 To dt.Columns.Count - 1
            If (dt.Columns(j).ColumnName = "pend_prod" Or dt.Columns(j).ColumnName = "pend_log" Or dt.Columns(j).ColumnName = "val_pend_prod" Or dt.Columns(j).ColumnName = "val_pend_log" Or dt.Columns(j).ColumnName = "Cant_pedida" Or dt.Columns(j).ColumnName = "cantidad_despachada" Or dt.Columns(j).ColumnName = "Pendiente" Or dt.Columns(j).ColumnName = "KilosPendiente" Or dt.Columns(j).ColumnName = "Costo_total" Or dt.Columns(j).ColumnName = "valor_unitario" Or dt.Columns(j).ColumnName = "valor_total") Then
                For i = 0 To dt.Rows.Count - 2
                    sum += dt.Rows(i).Item(j)
                Next
                dt.Rows(dt.Rows.Count - 1).Item(j) = sum
                sum = 0
            ElseIf (dt.Columns(j).ColumnName = "linea_produccion") Then
                dt.Rows(dt.Rows.Count - 1).Item(j) = "TOTAL"
            End If
        Next
        dtg_pedidos_ventas.DataSource = Nothing
        dtg_pedidos_ventas.DataSource = dt
        dtg_pedidos_ventas.Rows(dtg_pedidos_ventas.Rows.Count - 1).DefaultCellStyle.BackColor = Color.Red
        dtg_pedidos_ventas.Rows(dtg_pedidos_ventas.Rows.Count - 1).DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        For i = 0 To dtg_pedidos_ventas.Columns.Count - 1
            If (dtg_pedidos_ventas.Columns(i).Name = "pend_prod" Or dtg_pedidos_ventas.Columns(i).Name = "val_pend_prod") Then
                dtg_pedidos_ventas.Columns(i).DefaultCellStyle.BackColor = Color.Yellow
                dtg_pedidos_ventas.Columns(i).HeaderCell.Style.BackColor = Color.Yellow
                dtg_pedidos_ventas.Columns(i).HeaderCell.Style.ForeColor = Color.Black
                If dtg_pedidos_ventas.Columns(i).Name = "pend_prod" Then
                    dtg_pedidos_ventas.Columns(i).DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
                End If
            ElseIf (dtg_pedidos_ventas.Columns(i).Name = "pend_log" Or dtg_pedidos_ventas.Columns(i).Name = "val_pend_log") Then
                dtg_pedidos_ventas.Columns(i).DefaultCellStyle.BackColor = Color.Lime
                dtg_pedidos_ventas.Columns(i).HeaderCell.Style.BackColor = Color.Lime
                dtg_pedidos_ventas.Columns(i).HeaderCell.Style.ForeColor = Color.Black
                If dtg_pedidos_ventas.Columns(i).Name = "pend_log" Then
                    dtg_pedidos_ventas.Columns(i).DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
                End If
            ElseIf (dtg_pedidos_ventas.Columns(i).Name = "id_Cor") Then
                dtg_pedidos_ventas.Columns(i).Visible = False
            End If
        Next
    End Sub
    'Pendiente de ventas para el concepto 2
    Private Sub cargar_pendientes_Ventas_2()
        Dim sum As Double = 0
        Dim sql As String = "SELECT p.id_Cor,p.linea_produccion,p.codigo,p.descripcion,p.bodega,AVG(r.stock)As stock,(AVG(r.stock)-SUM(p.Pendiente))As pend_prod, (AVG(r.stock)-SUM(p.Pendiente))As val_pend_prod, (AVG(r.stock))As pend_log,(AVG(r.stock))As val_pend_log,SUM(p.Pendiente)As Pendiente,(SUM(p.valor_total)/SUM(p.Pendiente)) As valor_unitario,SUM( p.valor_total) As valor_total " & _
                    "FROM J_v_pendientes_por_vendedor_id_cor p ,v_referencias_sto_hoy r " & _
                        "WHERE p.bodega = r.bodega AND p.codigo = r.codigo and p.concepto in (2)" & _
                            "GROUP BY p.id_Cor,p.linea_produccion,p.codigo, p.descripcion,p.bodega " & _
                             " ORDER BY p.id_Cor,p.linea_produccion,p.bodega"
        Dim dt As New DataTable
        dt = obj_Ing_prodLn.listar_datatable(sql, "CORSAN")
        calcular_prod_log(dt)
        dt = consolidarLineaProduccion(dt)

        dt.Rows.Add()
        For j = 0 To dt.Columns.Count - 1
            If (dt.Columns(j).ColumnName = "pend_prod" Or dt.Columns(j).ColumnName = "pend_log" Or dt.Columns(j).ColumnName = "val_pend_prod" Or dt.Columns(j).ColumnName = "val_pend_log" Or dt.Columns(j).ColumnName = "Cant_pedida" Or dt.Columns(j).ColumnName = "cantidad_despachada" Or dt.Columns(j).ColumnName = "Pendiente" Or dt.Columns(j).ColumnName = "KilosPendiente" Or dt.Columns(j).ColumnName = "Costo_total" Or dt.Columns(j).ColumnName = "valor_unitario" Or dt.Columns(j).ColumnName = "valor_total") Then
                For i = 0 To dt.Rows.Count - 2
                    sum += dt.Rows(i).Item(j)
                Next
                dt.Rows(dt.Rows.Count - 1).Item(j) = sum
                sum = 0
            ElseIf (dt.Columns(j).ColumnName = "linea_produccion") Then
                dt.Rows(dt.Rows.Count - 1).Item(j) = "TOTAL"
            End If
        Next
        dtg_pedidos_ventas2.DataSource = Nothing
        dtg_pedidos_ventas2.DataSource = dt
        dtg_pedidos_ventas2.Rows(dtg_pedidos_ventas2.Rows.Count - 1).DefaultCellStyle.BackColor = Color.Red
        dtg_pedidos_ventas2.Rows(dtg_pedidos_ventas2.Rows.Count - 1).DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        For i = 0 To dtg_pedidos_ventas2.Columns.Count - 1
            If (dtg_pedidos_ventas2.Columns(i).Name = "pend_prod" Or dtg_pedidos_ventas2.Columns(i).Name = "val_pend_prod") Then
                dtg_pedidos_ventas2.Columns(i).DefaultCellStyle.BackColor = Color.Yellow
                dtg_pedidos_ventas2.Columns(i).HeaderCell.Style.BackColor = Color.Yellow
                dtg_pedidos_ventas2.Columns(i).HeaderCell.Style.ForeColor = Color.Black
                If dtg_pedidos_ventas2.Columns(i).Name = "pend_prod" Then
                    dtg_pedidos_ventas2.Columns(i).DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
                End If
            ElseIf (dtg_pedidos_ventas2.Columns(i).Name = "pend_log" Or dtg_pedidos_ventas2.Columns(i).Name = "val_pend_log") Then
                dtg_pedidos_ventas2.Columns(i).DefaultCellStyle.BackColor = Color.Lime
                dtg_pedidos_ventas2.Columns(i).HeaderCell.Style.BackColor = Color.Lime
                dtg_pedidos_ventas2.Columns(i).HeaderCell.Style.ForeColor = Color.Black
                If dtg_pedidos_ventas2.Columns(i).Name = "pend_log" Then
                    dtg_pedidos_ventas2.Columns(i).DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
                End If
            ElseIf (dtg_pedidos_ventas2.Columns(i).Name = "id_Cor") Then
                dtg_pedidos_ventas2.Columns(i).Visible = False
            End If
        Next
    End Sub
    Private Sub calcular_prod_log(ByRef dt As DataTable)
        Dim sum_prod_bod7 As Double = 0
        Dim sum_log_bod7 As Double = 0
        Dim sum_val_prod_bod7 As Double = 0
        Dim sum_val_log_bod7 As Double = 0
        Dim sum_prod_bod3 As Double = 0
        Dim sum_log_bod3 As Double = 0
        Dim sum_val_prod_bod3 As Double = 0
        Dim sum_val_log_bod3 As Double = 0
        Dim sum_stock_bod3 As Double = 0
        Dim sum_stock_bod7 As Double = 0

        For j = 0 To dt.Columns.Count - 1
            If (dt.Columns(j).ColumnName = "pend_prod") Then
                For i = 0 To dt.Rows.Count - 1
                    If (dt.Rows(i).Item("pend_prod") >= 0) Then
                        dt.Rows(i).Item("pend_prod") = 0
                    Else
                        dt.Rows(i).Item("pend_prod") *= -1
                    End If
                    dt.Rows(i).Item("val_pend_prod") = (dt.Rows(i).Item("pend_prod") * dt.Rows(i).Item("valor_unitario"))
                Next
            ElseIf (dt.Columns(j).ColumnName = "pend_log") Then
                For i = 0 To dt.Rows.Count - 1
                    If (dt.Rows(i).Item("pend_log") > dt.Rows(i).Item("Pendiente")) Then
                        dt.Rows(i).Item("pend_log") = dt.Rows(i).Item("Pendiente")
                    End If
                    dt.Rows(i).Item("val_pend_log") = (dt.Rows(i).Item("pend_log") * dt.Rows(i).Item("valor_unitario"))
                Next
                j = dt.Columns.Count - 1
            End If
        Next
    End Sub
    Private Function consolidarLineaProduccion(ByVal dt As DataTable) As DataTable
        Dim dt_consolidado As New DataTable
        Dim id_cor_ant As Integer = 0
        Dim bod_ant As Integer = 0
        Dim addFila As Boolean = False
        Dim nomCol As String = ""
        Dim valor As Double = 0
        dt_consolidado.Columns.Add("id_Cor", GetType(Double))
        dt_consolidado.Columns.Add("linea_produccion")
        dt_consolidado.Columns.Add("bodega", GetType(Double))
        dt_consolidado.Columns.Add("stock", GetType(Double))
        dt_consolidado.Columns.Add("pend_prod", GetType(Double))
        dt_consolidado.Columns.Add("val_pend_prod", GetType(Double))
        dt_consolidado.Columns.Add("pend_log", GetType(Double))
        dt_consolidado.Columns.Add("val_pend_log", GetType(Double))
        dt_consolidado.Columns.Add("Pendiente", GetType(Double))
        dt_consolidado.Columns.Add("valor_unitario", GetType(Double))
        For k = dt.Columns.IndexOf("valor_unitario") + 1 To dt.Columns.Count - 1
            If (dt.Columns(k).ColumnName <> "notas" And dt.Columns(k).ColumnName <> "notas5" And dt.Columns(k).ColumnName <> "notas_aut" And dt.Columns(k).ColumnName <> "autoriz_texto") Then
                dt_consolidado.Columns.Add(dt.Columns(k).ColumnName, GetType(Double))
            End If
        Next
        For i = 0 To dt.Rows.Count - 1
            If (id_cor_ant <> dt.Rows(i).Item("id_Cor") Or bod_ant <> dt.Rows(i).Item("bodega") Or i = 0) Then
                addFila = True
            End If
            If (addFila) Then
                dt_consolidado.Rows.Add()
                dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("id_Cor") = dt.Rows(i).Item("id_Cor")
                dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("linea_produccion") = dt.Rows(i).Item("linea_produccion")
                dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item("bodega") = dt.Rows(i).Item("bodega")
                For j = 0 To dt_consolidado.Columns.Count - 1
                    If (dt_consolidado.Columns(j).ColumnName <> "id_Cor" And dt_consolidado.Columns(j).ColumnName <> "bodega" And dt_consolidado.Columns(j).ColumnName <> "linea_produccion") Then
                        dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item(j) = 0
                    End If
                Next
            End If
            For k = dt.Columns.IndexOf("stock") To dt.Columns.Count - 1
                nomCol = dt.Columns(k).ColumnName
                valor = dt.Rows(i).Item(nomCol)
                dt_consolidado.Rows(dt_consolidado.Rows.Count - 1).Item(dt_consolidado.Columns.IndexOf(nomCol)) += dt.Rows(i).Item(nomCol)
            Next
            id_cor_ant = dt.Rows(i).Item("id_Cor")
            bod_ant = dt.Rows(i).Item("bodega")
            addFila = False
            If (i = dt.Rows.Count - 1) Then

            End If
        Next
        Return dt_consolidado
    End Function
End Class