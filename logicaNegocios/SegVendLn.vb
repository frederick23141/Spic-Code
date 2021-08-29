Imports entidadNegocios
Imports accesoDatos
Public Class SegVendLn
    Private objUsuarioLn As New UsuarioLn
    Private objSegVendAd As SegVendAd
    Private objOp_simplesAd As New Op_simplesAd
    Dim objOpSimplesLn As New Op_simpesLn
    Public Sub New()
        objSegVendAd = New SegVendAd
    End Sub

    Public Function listarNuev(ByVal mes As Integer, ByVal año As Integer, ByVal criterio As String, ByVal inter As Boolean) As List(Of SegVendEn)
        Dim iva As Double = objOpSimplesLn.getIvaPorc()
        Return objSegVendAd.listarNuev(mes, año, criterio, inter, iva)
    End Function
    Public Function DetalleVentasVend(ByVal mes As Integer, ByVal ano As Integer, ByVal whereVendedor As String, ByVal usuario As UsuarioEn) As DataTable
        Return objSegVendAd.DetalleVentasVend(mes, ano, whereVendedor, usuario)
    End Function
    Public Function DetaPptoVtas(ByVal mes As Integer, ByVal ano As Integer, ByVal whereVendedor As String) As DataTable
        Return objSegVendAd.DetaPptoVtas(mes, ano, whereVendedor)
    End Function
    Public Function DetalleRec(ByVal mes As Integer, ByVal año As Integer, ByVal whereVendedor As String, ByVal usuario As UsuarioEn) As DataTable
        Return objSegVendAd.DetalleRec(mes, año, whereVendedor, usuario)
    End Function
    Public Function DetallePptoRec(ByVal mes As Integer, ByVal año As Integer, ByVal whereVendedor As String) As DataTable
        Return objSegVendAd.DetallePptoRec(mes, año, whereVendedor)
    End Function
    Public Function DetallePend(ByVal whereVendedor As String, ByVal usuario As UsuarioEn) As DataTable
        Return objSegVendAd.DetallePend(whereVendedor, usuario)
    End Function
    Public Function DetalleDev(ByVal mes As Integer, ByVal año As Integer, ByVal whereVendedor As String, ByVal usuario As UsuarioEn) As DataTable
        Return objSegVendAd.DetalleDev(mes, año, whereVendedor, usuario)
    End Function
    Public Function Detalle_no_reflej(ByVal whereVendedor As String, ByVal usuario As UsuarioEn) As DataTable
        Return objSegVendAd.Detalle_no_reflej(whereVendedor, usuario)
    End Function
    Public Function listarIndividual(ByVal mes As Integer, ByVal año As Integer, ByVal vendedor As Integer, ByVal criterio As String) As List(Of SegVendEn)
        Dim iva As Double = objOpSimplesLn.getIvaPorc()
        Return objSegVendAd.listarIndividual(mes, año, vendedor, criterio, iva)
    End Function
    Public Function tot_vtas(ByVal mes As Integer, ByVal año As Integer, ByVal min As Integer, ByVal max As Integer) As Double
        Return objSegVendAd.tot_vtas(mes, año, min, max)
    End Function
    Public Function total_ptes(ByVal min As Integer, ByVal max As Integer) As Double
        Return objSegVendAd.total_ptes(min, max)
    End Function
    Public Function Detalle_consol_pend_idCor(ByVal whereVendedor As String, ByVal usuario As UsuarioEn) As DataTable
        Return objSegVendAd.Detalle_consol_pend_idCor(whereVendedor, usuario)
    End Function
    Public Function Detalle_consol_vtas_idCor(ByVal mes As Integer, ByVal ano As Integer, ByVal whereVendedor As String, ByVal usuario As UsuarioEn) As DataTable
        Return objSegVendAd.Detalle_consol_vtas_idCor(mes, ano, whereVendedor, usuario)
    End Function
    Public Function listarSeg(ByVal criterio As String, ByVal usuario_vendedor As Integer, ByVal inter As Boolean, ByVal vendedores As String, ByVal mes As Integer, ByVal ano As Integer) As DataTable
        Dim dt As New DataTable
        Dim dt_ventas As New DataTable
        Dim dt_pres_ventas As New DataTable
        Dim dt_pendientes As New DataTable
        Dim dt_no_reflejados As New DataTable
        Dim dt_recaudos As New DataTable
        Dim dt_anticipos As New DataTable
        Dim dt_pres_recaudos As New DataTable
        Dim dt_devoluciones As New DataTable
        Dim dt_cheques_dev As New DataTable
        Dim dt_costo_tot As New DataTable
        Dim dt_vr_total As New DataTable
      
        dt.Columns.Add("Vendedor")
        dt.Columns.Add("Ventas", GetType(Double))
        dt.Columns.Add("Valor_total", GetType(Double))
        dt.Columns.Add("Costo", GetType(Double))
        dt.Columns.Add("Pres_ventas", GetType(Double))
        dt.Columns.Add("Pend", GetType(Double))
        dt.Columns.Add("No_reflej", GetType(Double))
        dt.Columns.Add("Rec", GetType(Double))
        dt.Columns.Add("Anticipos", GetType(Double))
        dt.Columns.Add("Pres_rec", GetType(Double))
        dt.Columns.Add("Dev", GetType(Double))
        dt.Columns.Add("chequesDev", GetType(Double))
        dt.Columns.Add("porCumVtas", GetType(Double))
        dt.Columns.Add("porCumRec", GetType(Double))
        dt.Columns.Add("porDev", GetType(Double))
        dt.Columns.Add("Por_util", GetType(Double))
        Dim listVend As New List(Of Object)
        Dim vendMin As Integer = 0
        Dim vendMax As Integer = 0
#Disable Warning BC42024 ' Variable local sin usar: 'mat'.
        Dim mat(,) As Object
#Enable Warning BC42024 ' Variable local sin usar: 'mat'.
        Dim tam As Integer = 0
        Dim sql As String = ""
        Dim sqlVend As String = ""
        Dim criterioVendedor As String = ""
        Dim criterioVendNit As String = ""
        If (usuario_vendedor = 1020) Then
            vendMax = 1095
            vendMin = 1001
            If (vendedores <> "") Then
                criterioVendedor = "vendedor in (" & vendedores & ")"
                criterioVendNit = "nit in (" & vendedores & ")"
            Else
                vendMin = 1001
                If (inter) Then
                    vendMax = 1099
                Else
                    vendMax = 1095
                End If
                criterioVendedor = "vendedor >= " & vendMin & " AND vendedor <= " & vendMax & ""
                criterioVendNit = "nit >= " & vendMin & " AND nit <= " & vendMax & ""
            End If
            sqlVend = "SELECT  vendedor " & _
                             "FROM v_vendedores " & _
                                "WHERE " & criterioVendedor & " AND bloqueo = 0  ORDER BY vendedor"
            listVend = objOp_simplesAd.lista(sqlVend)
            If (vendedores <> "") Then
                criterioVendedor = "vendedor in ("
                For i = 0 To listVend.Count - 1
                    criterioVendedor &= listVend(i)
                    If (i <> listVend.Count - 1) Then
                        criterioVendedor &= ","
                    End If
                Next
                criterioVendedor &= ") "
            End If
        Else
            listVend.Add(usuario_vendedor)
            vendMin = usuario_vendedor
            vendMax = usuario_vendedor
            criterioVendedor = "vendedor >= " & vendMin & " AND vendedor <= " & vendMax & " "
            criterioVendNit = "nit >= " & vendMin & " AND nit <= " & vendMax & ""
        End If
        tam = listVend.Count - 1
        For i = 0 To tam
            dt.Rows.Add()
            dt.Rows(i).Item("Vendedor") = listVend(i)
        Next


        dt.Rows.Add()
        dt.Rows(dt.Rows.Count - 1).Item("Vendedor") = "TOTAL"
        'VALOR TOTAL
        sql = "SELECT vtas.vendedor, SUM (vtas.Vr_total )AS total " & _
                    "FROM Jjv_V_vtas_vend_cliente_ref vtas " & _
                        "WHERE (Month(vtas.fec) = " & mes & " And Year(vtas.fec) = " & ano & " AND " & criterioVendedor & " ) " & _
                          "GROUP BY vtas.vendedor"
        dt_vr_total = objOp_simplesAd.listar_datatable(sql, "CORSAN")
        dt = addItems(dt, dt_vr_total, "Valor_total")
        'VENTAS
        sql = "SELECT vtas.vendedor, SUM (vtas." & criterio & "  )AS total " & _
                    "FROM Jjv_V_vtas_vend_cliente_ref vtas " & _
                        "WHERE (Month(vtas.fec) = " & mes & " And Year(vtas.fec) = " & ano & " AND " & criterioVendedor & " ) " & _
                          "GROUP BY vtas.vendedor"
        dt_ventas = objOp_simplesAd.listar_datatable(sql, "CORSAN")
        dt = addItems(dt, dt_ventas, "Ventas")
        'PPTO VENTAS
        sql = "select vendedor,SUM (Vr_total )As total " & _
                                "from Jjv_Ppto_mes " & _
                                    "where(Month(Fecha_ppto) = " & mes & " And Year(Fecha_ppto) = " & ano & " AND " & criterioVendedor & ") " & _
                                        "group by Vendedor "
        dt_pres_ventas = objOp_simplesAd.listar_datatable(sql, "CORSAN")
        dt = addItems(dt, dt_pres_ventas, "Pres_ventas")
        'PENDIENTES
        sql = "SELECT vendedor,SUM (" & criterio & " )As total " & _
                "FROM j_v_pend_vend   " & _
                  "WHERE  " & criterioVendedor & " " & _
                         "GROUP BY vendedor"
        dt_pendientes = objOp_simplesAd.listar_datatable(sql, "CORSAN")
        dt = addItems(dt, dt_pendientes, "Pend")
        'NO REFLEJADOS
        sql = "SELECT vendedor,SUM (valor_total )As total " & _
                  "FROM J_v_pend_noreflejados " & _
                   "WHERE  anulado = 0 AND (" & criterioVendedor & ") " & _
                        "GROUP BY vendedor"
        dt_no_reflejados = objOp_simplesAd.listar_datatable(sql, "CORSAN")
        dt = addItems(dt, dt_no_reflejados, "No_reflej")
        'RECAUDOS
        sql = "SELECT vendedor ,SUM (Total_rec)As total " & _
                    "FROM Jjv_Recaudos_consol " & _
                        "WHERE(Month(fecha) = " & mes & " AND Year(fecha) = " & ano & " AND (" & criterioVendedor & ")) " & _
                     "GROUP BY vendedor"
        dt_recaudos = objOp_simplesAd.listar_datatable(sql, "Rec")
        dt = addItems(dt, dt_recaudos, "Rec")
        'PPTO RECAUDOS
        sql = "SELECT nit As vendedor, SUM (Ppto_total )As total " & _
                              "FROM Jjv_ppto_vtas_recaudos_consol ppto " & _
                               "WHERE(mes = " & mes & " And año = " & ano & " AND (" & criterioVendNit & ")) " & _
                                   "GROUP BY nit "
        dt_pres_recaudos = objOp_simplesAd.listar_datatable(sql, "CORSAN")
        dt = addItems(dt, dt_pres_recaudos, "Pres_rec")

        'DEVOLUCIONES
        sql = "SELECT vendedor,SUM(" & criterio & " )As total " & _
                        "FROM Jjv_V_vtas_vend_cliente_ref  " & _
                        "WHERE(Month(fec) = " & mes & " And Year(fec) = " & ano & " And sw = 2 AND (" & criterioVendedor & ")) " & _
                     "GROUP BY vendedor "
        dt_devoluciones = objOp_simplesAd.listar_datatable(sql, "CORSAN")
        dt = addItems(dt, dt_devoluciones, "Dev")
        'CHEQUES DEV
        sql = "SELECT vendedor,SUM (valor_total) As total " & _
                          "FROM documentos " & _
                            "WHERE tipo IN ('NDCH') AND MONTH (fecha )= " & mes & " and YEAR (fecha )= " & ano & " AND (" & criterioVendedor & ") " & _
                             "GROUP BY vendedor "
        dt_cheques_dev = objOp_simplesAd.listar_datatable(sql, "CORSAN")
        dt = addItems(dt, dt_cheques_dev, "chequesDev")
        'ANTICIPOS
        sql = "SELECT vendedor ,SUM (valor_total)-SUM (valor_aplicado) as total " & _
                                               "FROM documentos " & _
                                                       "WHERE nit= nit AND sw Like '5' AND  (" & criterioVendedor & ") AND tipo IN ('RCR1','RCO1','RCEX') AND  MONTH(fecha)=" & mes & " AND  YEAR(fecha)=" & ano & " AND(valor_total > valor_aplicado or (iva_fletes <0   AND valor_total=valor_aplicado)) " & _
                                                               "group by vendedor"
        dt_anticipos = objOp_simplesAd.listar_datatable(sql, "CORSAN")
        dt = addItems(dt, dt_anticipos, "Anticipos")
        'COSTO_TOTAL
        sql = " SELECT vendedor,SUM (Cto_total) as total " & _
                    "FROM Jjv_V_vtas_vend_cliente_ref  " & _
                        "WHERE(Month(fec) = " & mes & " And Year(fec) = " & ano & ") AND (" & criterioVendedor & ") " & _
                          "group by vendedor  "
        dt_costo_tot = objOp_simplesAd.listar_datatable(sql, "CORSAN")
        dt = addItems(dt, dt_costo_tot, "Costo")
        sumar_col(dt, "Ventas")
        sumar_col(dt, "Valor_total")
        sumar_col(dt, "Pres_Ventas")
        sumar_col(dt, "Pend")
        sumar_col(dt, "No_reflej")
        sumar_col(dt, "Rec")
        sumar_col(dt, "Dev")
        sumar_col(dt, "chequesDev")
        sumar_col(dt, "Anticipos")
        sumar_col(dt, "Costo")
        sumar_col(dt, "Pres_rec")
        dt = porUtil(dt)
        dt = restarChequesDev(dt)
        dt = sumarAnticipos(dt)
        dt = calcPorcCumpl("Valor_total", "Pres_Ventas", "porCumVtas", dt)
        dt = calcPorcCumpl("Rec", "Pres_rec", "porCumRec", dt)
        dt = calcPorcCumpl("Dev", "Ventas", "porDev", dt)

        dt = eliminarInactivos(dt)
        Return dt
    End Function
    Public Function sumar_col(ByVal dt As DataTable, ByVal col As String) As DataTable
        Dim suma As Double = 0
        For i = 0 To dt.Rows.Count - 2
            If Not IsDBNull(dt.Rows(i).Item(col)) Then
                suma = suma + dt.Rows(i).Item(col)
            End If
        Next
        dt.Rows(dt.Rows.Count - 1).Item(col) = suma
        Return dt
    End Function
    Private Function addItems(ByVal dt_ppal As DataTable, ByVal dt_datos As DataTable, ByVal col As String) As DataTable
        For i = 0 To dt_ppal.Rows.Count - 2
            For j = 0 To dt_datos.Rows.Count - 1
                If (dt_ppal.Rows(i).Item("Vendedor") = dt_datos.Rows(j).Item("vendedor")) Then
                    dt_ppal.Rows(i).Item(col) = dt_datos.Rows(j).Item("total")
                    j = dt_datos.Rows.Count - 1
                End If
            Next
        Next
        Return dt_ppal
    End Function

    Public Function porc_util(ByVal mat(,) As Object, ByVal dt As DataTable) As DataTable
        Dim p_util As Double = 0
        Dim cto_tot As Double = 0
        Dim vr_tot As Double = 0
        For i = 0 To dt.Rows.Count - 2
            For j = 0 To dt.Rows.Count - 2
                If (dt.Rows(i).Item("Vendedor") = mat(j, 0)) Then
                    cto_tot = mat(j, 1)
                    vr_tot = mat(j, 2)
                    p_util = (vr_tot - cto_tot) / (vr_tot) * 100
                    dt.Rows(i).Item("Por_util") = p_util
                End If
            Next
        Next
        Return dt
    End Function
    Private Function restarChequesDev(ByVal dt As DataTable) As DataTable
        For i = 0 To dt.Rows.Count - 1
            If ((Not IsDBNull(dt.Rows(i).Item("chequesDev")) And (Not IsDBNull(dt.Rows(i).Item("Rec"))))) Then
                dt.Rows(i).Item("Rec") = dt.Rows(i).Item("Rec") - dt.Rows(i).Item("chequesDev")
            End If
        Next
        Return dt
    End Function
    Private Function sumarAnticipos(ByVal dt As DataTable) As DataTable
        For i = 0 To dt.Rows.Count - 1
            If Not IsDBNull(dt.Rows(i).Item("Anticipos")) Then
                dt.Rows(i).Item("Rec") += dt.Rows(i).Item("Anticipos")
            End If
        Next
        Return dt
    End Function
    Private Function calcPorcCumpl(ByVal col1 As String, ByVal col2 As String, ByVal colDestino As String, ByVal dt As DataTable) As DataTable
        For i = 0 To dt.Rows.Count - 1
            If (Not IsDBNull(dt.Rows(i).Item(col2)) And (Not IsDBNull(dt.Rows(i).Item(col1)))) Then
                If (dt.Rows(i).Item(col2) <> 0) Then
                    dt.Rows(i).Item(colDestino) = (dt.Rows(i).Item(col1) * 100) / dt.Rows(i).Item(col2)
                End If
            End If
        Next
        Return dt
    End Function
    Private Function porUtil(ByVal dt As DataTable) As DataTable
        For i = 0 To dt.Rows.Count - 1
            If (Not IsDBNull(dt.Rows(i).Item("Valor_total")) And Not IsDBNull(dt.Rows(i).Item("Costo"))) Then
                dt.Rows(i).Item("Por_util") = (dt.Rows(i).Item("Valor_total") - dt.Rows(i).Item("Costo")) / (dt.Rows(i).Item("Valor_total")) * 100
            End If
        Next
        Return dt
    End Function
    Private Function eliminarInactivos(ByVal dt As DataTable) As DataTable
        For i = 0 To dt.Rows.Count - 2
            If i < dt.Rows.Count Then
                If IsDBNull(dt.Rows(i).Item("Ventas")) And IsDBNull(dt.Rows(i).Item("Pres_Ventas")) And IsDBNull(dt.Rows(i).Item("Rec")) And IsDBNull(dt.Rows(i).Item("Pend")) Then
                    dt.Rows(i).Delete()
                    i -= 1
                End If
            End If
        Next
        Return dt
    End Function
End Class
