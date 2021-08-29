Imports System.Data.SqlClient
Imports System.Data
Imports entidadNegocios

Public Class SegVendAd
    Private conn As New SqlConnection
    Private comando As New SqlCommand
    Private objConexion As New Conexion
    Private objSegVendEn As New SegVendEn

    Public Function listarNuev(ByVal mes As Integer, ByVal año As Integer, ByVal criterio As String, ByVal inter As Boolean, ByVal iva As Double) As List(Of SegVendEn)
        Dim listaNuevEn As New List(Of SegVendEn)
        Dim vecVend() As Integer = vendedores(inter)
        Dim vendedor As Integer = 0
        Dim Pptoventas As Double = 0
        Dim ventas As Double = 0
        Dim pend As Double = 0
        For i = 0 To 99
            If (vecVend(i) > 0) Then
                vendedor = vecVend(i)
                Pptoventas = presVtas(mes, año, vendedor, criterio)
                ventas = ventasVend(mes, año, vendedor, criterio)
                pend = Pendientes(vendedor, criterio)
                If (Pptoventas > 0 Or ventas > 0 Or pend > 0) Then
                    objSegVendEn = New SegVendEn
                    objSegVendEn.Vendedor = vendedor
                    objSegVendEn.Ventas = ventas
                    objSegVendEn.Pres_Ventas = Pptoventas
                    objSegVendEn.Rec = Recaudos(mes, año, vendedor)
                    objSegVendEn.Pres_rec = PresRecaudos(mes, año, vendedor)
                    objSegVendEn.Pend = pend
                    objSegVendEn.No_reflej = no_reflej(vendedor, iva)
                    objSegVendEn.Dev = Devoluciones(mes, año, vendedor, criterio)
                    objSegVendEn.porCumVtas = (objSegVendEn.Ventas * 100) / objSegVendEn.Pres_Ventas
                    If (objSegVendEn.Pres_rec = 0) Then
                        objSegVendEn.porCumRec = 0
                    Else
                        objSegVendEn.porCumRec = (objSegVendEn.Rec * 100) / objSegVendEn.Pres_rec
                    End If
                    objSegVendEn.porDev = ((objSegVendEn.Dev * -1) * 100) / objSegVendEn.Ventas
                    objSegVendEn.Por_util = porc_util(mes, año, vendedor)
                    listaNuevEn.Add(objSegVendEn)
                End If

            End If

        Next
        'If (inter = True) Then
        '    listaNuevEn.Add(listarInternacional(mes, año, 1099, criterio))
        'End If
        objSegVendEn = New SegVendEn
        objSegVendEn.Vendedor = "TOTALES"
        listaNuevEn.Add(objSegVendEn)
        Return listaNuevEn
    End Function
    Public Function listarIndividual(ByVal mes As Integer, ByVal año As Integer, ByVal vendedor As Integer, ByVal criterio As String, ByVal iva As Double) As List(Of SegVendEn)
        Dim listaNuevEn As New List(Of SegVendEn)
        Dim Pptoventas As Double = 0
        Pptoventas = presVtas(mes, año, vendedor, criterio)
        If (Pptoventas > 0) Then
            objSegVendEn = New SegVendEn
            objSegVendEn.Vendedor = vendedor
            objSegVendEn.Ventas = ventasVend(mes, año, vendedor, criterio)
            objSegVendEn.Pres_Ventas = Pptoventas
            objSegVendEn.Rec = Recaudos(mes, año, vendedor)
            objSegVendEn.Pres_rec = PresRecaudos(mes, año, vendedor)
            objSegVendEn.Pend = Pendientes(vendedor, criterio)
            objSegVendEn.No_reflej = no_reflej(vendedor, iva)
            objSegVendEn.Dev = Devoluciones(mes, año, vendedor, criterio)
            objSegVendEn.porCumVtas = (objSegVendEn.Ventas * 100) / objSegVendEn.Pres_Ventas
            objSegVendEn.porCumRec = (objSegVendEn.Rec * 100) / objSegVendEn.Pres_rec
            objSegVendEn.porDev = ((objSegVendEn.Dev * -1) * 100) / objSegVendEn.Ventas

            listaNuevEn.Add(objSegVendEn)
        End If
        objSegVendEn = New SegVendEn
        objSegVendEn.Vendedor = "TOTALES"
        listaNuevEn.Add(objSegVendEn)
        Return listaNuevEn
    End Function

    Private Function vendedores(ByVal inter As Boolean) As Integer()
        Dim reader As SqlDataReader
        Dim vecVend(99) As Integer
        Dim k As Double = 0
        Dim sSql As String = ""
        comando.CommandType = CommandType.Text
        conn = objConexion.abrirConexion
        comando.Connection = conn
        If (inter) Then
            sSql = "select  vendedor " & _
                    " from v_vendedores " & _
                           "where (vendedor >= 1001) AND (vendedor <= 1099) AND (bloqueo = 0) ORDER BY vendedor"
        Else
            sSql = "select  vendedor " & _
                    " from v_vendedores " & _
                           "where (vendedor >= 1001) AND (vendedor <= 1060) AND (bloqueo = 0) ORDER BY vendedor"
        End If
        comando.CommandText = (sSql)
        reader = comando.ExecuteReader
        While (reader.Read)
            If IsDBNull(reader(0)) Then
            Else
                vecVend(k) = reader(0)
                k = k + 1
            End If
        End While
        conn.Close()
        Return vecVend
    End Function
    Private Function ventasVend(ByVal mes As Integer, ByVal año As Integer, ByVal vendedor As Integer, ByVal criterio As String) As Double
        Dim totVtas As Double = 0
        Dim reader As SqlDataReader
        Dim sSql As String = ""
        comando.CommandType = CommandType.Text
        conn = objConexion.abrirConexion
        comando.Connection = conn
        If (criterio = "kilos") Then
            criterio = "KILOS"
        Else
            criterio = "Vr_total"
        End If
        sSql = "select SUM(" & criterio & ") " & _
                        "from Jjv_V_vtas_vend_cliente_ref " & _
                                "where vendedor=" & vendedor & " and MONTH (fec )=" & mes & " and YEAR (fec)=" & año & ""
        comando.CommandText = (sSql)
        reader = comando.ExecuteReader
        While (reader.Read)
            If IsDBNull(reader(0)) Then
            Else
                totVtas = reader(0)
            End If
        End While
        conn.Close()
        If (totVtas = vbNull) Then
            totVtas = 0
        End If
        Return totVtas
    End Function
    Private Function presVtas(ByVal mes As Integer, ByVal año As Integer, ByVal vendedor As Integer, ByVal criterio As String) As Double
        Dim TotpresVtas As Double = 0
        Dim reader As SqlDataReader
        Dim sSql As String = ""
        comando.CommandType = CommandType.Text
        conn = objConexion.abrirConexion
        comando.Connection = conn
        If (criterio = "kilos") Then
            criterio = "Ppto_kilos"
        Else
            criterio = "Vr_total"
        End If
        sSql = "select SUM (" & criterio & ") " & _
                    "from Jjv_Ppto_mes " & _
                            "where vendedor=" & vendedor & " and MONTH (Fecha_ppto  )=" & mes & "  and YEAR (Fecha_ppto)=" & año & ""
        comando.CommandText = (sSql)
        reader = comando.ExecuteReader
        While (reader.Read)
            If IsDBNull(reader(0)) Then
            Else
                TotpresVtas = reader(0)
            End If
        End While
        conn.Close()
        Return TotpresVtas
    End Function
    Private Function PresRecaudos(ByVal mes As Integer, ByVal año As Integer, ByVal vendedor As Integer) As Double
        Dim Totrec As Double = 0
        Dim reader As SqlDataReader
        Dim sSql As String = ""
        comando.CommandType = CommandType.Text
        conn = objConexion.abrirConexion
        comando.Connection = conn
        sSql = "select Ppto_total " & _
                    " from Jjv_ppto_vtas_recaudos_consol " & _
                            "where nit=" & vendedor & " and mes=" & mes & " and Año =" & año & ""
        comando.CommandText = (sSql)
        reader = comando.ExecuteReader
        While (reader.Read)
            If IsDBNull(reader(0)) Then
            Else
                Totrec = reader(0)
            End If
        End While

        conn.Close()
        Return Totrec
    End Function
    Private Function Pendientes(ByVal vendedor As Integer, ByVal criterio As String) As Double
        Dim TotPend As Double = 0
        Dim reader As SqlDataReader
        Dim sSql As String = ""
        comando.CommandType = CommandType.Text
        conn = objConexion.abrirConexion
        comando.Connection = conn
        If (criterio = "kilos") Then
            criterio = "KilosPendiente"
        Else
            criterio = "Valor_total"
        End If

        sSql = "select distinct codigo," & criterio & " , vendedor,numero " & _
                        "from V_pendientes_por_vendedor " & _
                                "where vendedor=" & vendedor & " "
        comando.CommandText = (sSql)
        reader = comando.ExecuteReader
        While (reader.Read)
            If IsDBNull(reader(1)) Then
            Else
                TotPend += reader(1)
            End If
        End While
        If (TotPend = vbNull) Then
            TotPend = 0
        End If
        conn.Close()
        Return TotPend
    End Function
    Private Function no_reflej(ByVal vendedor As Integer, ByVal iva As Double) As Double
        Dim resp As Double = 0
        Dim reader As SqlDataReader
        Dim sSql As String = ""
        comando.CommandType = CommandType.Text
        conn = objConexion.abrirConexion
        comando.Connection = conn
        sSql = "Select SUM (valor_total ) from JJV_documentos_ped where vendedor = " & vendedor & " and anulado =0"
        comando.CommandText = (sSql)
        reader = comando.ExecuteReader
        If (reader.Read) Then
            If IsDBNull(reader(0)) Then
            Else
                resp = (reader(0) / (iva + 1))
            End If
        End If
        If (resp = vbNull) Then
            resp = 0
        End If
        conn.Close()
        Return resp
    End Function
    Private Function Devoluciones(ByVal mes As Integer, ByVal año As Integer, ByVal vendedor As Integer, ByVal criterio As String) As Double
        Dim totDev As Double = 0
        Dim reader As SqlDataReader
        Dim sSql As String = ""
        comando.CommandType = CommandType.Text
        conn = objConexion.abrirConexion
        comando.Connection = conn
        If (criterio = "kilos") Then
            criterio = "KILOS"
        Else
            criterio = "Vr_total"
        End If
        sSql = "  select SUM(" & criterio & ") " & _
                    " from Jjv_V_vtas_vend_cliente_ref " & _
                            "where vendedor=" & vendedor & " and MONTH (fec )=" & mes & " and YEAR (fec)=" & año & " and sw = 2"
        comando.CommandText = (sSql)
        reader = comando.ExecuteReader
        While (reader.Read)
            If IsDBNull(reader(0)) Then
            Else
                totDev = reader(0)
            End If
        End While
        If (totDev = vbNull) Then
            totDev = 0
        End If
        conn.Close()
        Return totDev
    End Function
    Private Function Recaudos(ByVal mes As Integer, ByVal año As Integer, ByVal vendedor As Integer) As Double
        Dim totRec As Double = 0
        Dim reader As SqlDataReader
        Dim sSql As String = ""
        comando.CommandType = CommandType.Text
        conn = objConexion.abrirConexion
        comando.Connection = conn
        sSql = " select SUM (Total_rec) " & _
                        "from Jjv_Recaudos_consol " & _
                                "where vendedor=" & vendedor & " and MONTH (fecha  )=" & mes & " and YEAR (fecha)=" & año & ""
        comando.CommandText = (sSql)
        reader = comando.ExecuteReader
        While (reader.Read)
            If IsDBNull(reader(0)) Then
            Else
                totRec = reader(0)
            End If
        End While
        conn.Close()
        If (totRec = vbNull) Then
            totRec = 0
        End If
        totRec = totRec - chequesDev(mes, año, vendedor)
        Return totRec
    End Function
    Private Function chequesDev(ByVal mes As Integer, ByVal ano As Integer, ByVal vendedor As Integer) As Double
        Dim sum As Double = 0
        Dim reader As SqlDataReader
        Dim sSql As String = ""
        comando.CommandType = CommandType.Text
        conn = objConexion.abrirConexion
        comando.Connection = conn
        sSql = "select SUM (valor_total ) AS suma  " & _
                     " from documentos  " & _
                                "where vendedor=" & vendedor & " and MONTH (fecha  )=" & mes & " and YEAR (fecha)=" & ano & " AND (tipo IN ('NDCD', 'NDCH'))"
        comando.CommandText = (sSql)
        reader = comando.ExecuteReader
        While (reader.Read)
            If Not IsDBNull(reader(0)) Then
                sum = reader("suma")
            End If

        End While
        conn.Close()
        Return sum
    End Function
    Public Function DetalleVentasVend(ByVal mes As Integer, ByVal año As Integer, ByVal whereVendedor As String, ByVal usuario As UsuarioEn) As DataTable
        conn = objConexion.abrirConexion
        Dim dt As New DataTable
        Dim sql As String = ""
        If (whereVendedor <> "") Then
            whereVendedor = "vendedor in (" & whereVendedor & ") "
        Else
            whereVendedor = "vendedor>=1001 AND vendedor <=1099"
        End If
        sql = "SELECT  numero,tipo,fec,vendedor,nit,nombres,ciudad,condicion,descripcion, cantidad,Kilos,(SELECT CASE WHEN Kilos=0 THEN 0 ELSE (Vr_total/Kilos)END) as vr_kilo,(SELECT CASE WHEN Kilos =0 THEN 0 ELSE (Cto_total/Kilos)END) as cto_kilo,Cto_total ,Vr_total As Valor_tot,(SELECT CASE WHEN Kilos =0 THEN 0 ELSE((Vr_total/Kilos-Cto_total/Kilos)/(Cto_total/Kilos)*100 )END)as porc_util " &
                                    "FROM Jjv_V_vtas_vend_cliente_ref " &
                                            "WHERE " & whereVendedor & " and MONTH (fec )=" & mes & " and YEAR (fec)=" & año & " order  by nit"
        Dim DA As New SqlDataAdapter(sql, conn)
        DA.Fill(dt)
        conn.Close()
        Return dt
    End Function
    Public Function DetaPptoVtas(ByVal mes As Integer, ByVal año As Integer, ByVal whereVendedor As String) As DataTable
        conn = objConexion.abrirConexion
        Dim dt As New DataTable
        If (whereVendedor <> "") Then
            whereVendedor = "vendedor in (" & whereVendedor & ") "
        Else
            whereVendedor = "vendedor>=1001 AND vendedor <=1099"
        End If
        Dim sql As String = "select vendedor,Id_cor,ppto_kilos,Vr_total,Vr_kilo,Cto_kilo,Porc_util,Fecha_mod1 as fec_modificacion,Dias_habil,Cto_total from Jjv_Ppto_mes where " & whereVendedor & "  and MONTH (Fecha_ppto  )=" & mes & "  and YEAR (Fecha_ppto)=" & año & ""
        Dim DA As New SqlDataAdapter(sql, conn)
        DA.Fill(dt)
        conn.Close()
        Return dt
    End Function
    Public Function DetalleRec(ByVal mes As Integer, ByVal año As Integer, ByVal whereVendedor As String, ByVal usuario As UsuarioEn) As DataTable
        conn = objConexion.abrirConexion
        Dim sql As String = ""
        If (whereVendedor <> "") Then
            whereVendedor = "Rec.vendedor in (" & whereVendedor & ") "
        Else
            whereVendedor = "Rec.vendedor>=1001 AND Rec.vendedor <=1099"
        End If
        sql = " select Rec.vendedor,Rec.ciudad,Rec.nit  ,Rec.nombres ,Rec.tipo,Rec.tipo_aplica,Rec.VALOR,Rec.DESCUENTO,Rec.Total_rec,Rec.fecha  from Jjv_Recaudos_consol Rec  where " & whereVendedor & "  and MONTH (Rec.fecha  )= " & mes & " and YEAR (Rec.fecha)=" & año
        Dim dt As New DataTable
        Dim DA As New SqlDataAdapter(sql, conn)
        DA.Fill(dt)
        conn.Close()
        Return dt
    End Function
    Public Function DetallePptoRec(ByVal mes As Integer, ByVal año As Integer, ByVal whereVendedor As String) As DataTable
        conn = objConexion.abrirConexion
        Dim dt As New DataTable
        If (whereVendedor <> "") Then
            whereVendedor = "nit in (" & whereVendedor & ") "
        Else
            whereVendedor = "nit>= 1001 AND nit <=1099"
        End If
        Dim DA As New SqlDataAdapter(" select nit,Año,Mes,Ppto_vtas ,Ppto_Calculado,Fecha_mod_ppto_rec,Ppto_client_contado,Ppto_total,TotClientCont from Jjv_ppto_vtas_recaudos_consol where " & whereVendedor & "  and mes=" & mes & " and Año =" & año & "", conn)
        DA.Fill(dt)
        conn.Close()
        Return dt
    End Function
    Public Function DetallePend(ByVal whereVendedor As String, ByVal usuario As UsuarioEn) As DataTable
        conn = objConexion.abrirConexion
        Dim sql As String = ""
        Dim dt As New DataTable
        If (whereVendedor <> "") Then
            whereVendedor = "vendedor in (" & whereVendedor & ") "
        Else
            whereVendedor = "vendedor>=1001 AND vendedor <=1099"
        End If
        sql = "select distinct vendedor,numero, codigo,nit,nombres,ciudad,fecha,Valor_total,cant_Pedida,pendiente, kilosPendiente as Kilos, (costo_total/cant_Pedida )as Cto_Kilo,valor_unitario,(valor_unitario-(costo_total/cant_Pedida ))/(valor_unitario)*100 as Por_util,descripcion , bloqueo,condicion,cupo_credito  from V_pendientes_por_vendedor where " & whereVendedor & "  and valor_unitario <> 0  "
        Dim DA As New SqlDataAdapter(sql, conn)
        DA.Fill(dt)
        conn.Close()
        Return dt
    End Function
    Public Function Detalle_consol_pend_idCor(ByVal whereVendedor As String, ByVal usuario As UsuarioEn) As DataTable
        conn = objConexion.abrirConexion
        Dim dt As New DataTable
        Dim sql As String = ""
        If (whereVendedor <> "") Then
            whereVendedor = "pend.vendedor in (" & whereVendedor & ") "
        Else
            whereVendedor = "pend.vendedor>=1001 AND pend.vendedor <=1099"
        End If
        sql = "SELECT seg_idcor.Descripcion ,SUM (pend.KilosPendiente )as kilos,SUM (pend.Cant_pedida-pend.cantidad_despachada ) as Cantidad , SUM (pend.Valor_total  )as Valor_tot,sum(pend.Costo_total) as costo_total,sum((pend.Valor_total-pend.costo_total))/sum(pend.Valor_total) * 100  as margen " & _
                                "FROM J_v_pendientes_por_vendedor_id_cor pend INNER JOIN referencias ref ON pend.codigo = ref.codigo , JJV_Grupos_seguimiento seg_idcor  " & _
                                        "WHERE(seg_idcor.Id_cor = ref.Id_cor And " & whereVendedor & " ) " & _
                                                "GROUP  by seg_idcor.Descripcion "
        Dim DA As New SqlDataAdapter(sql, conn)
        DA.Fill(dt)
        conn.Close()
        Return dt
    End Function
    Public Function Detalle_consol_vtas_idCor(ByVal mes As Integer, ByVal ano As Integer, ByVal whereVendedor As String, ByVal usuario As UsuarioEn) As DataTable
        conn = objConexion.abrirConexion
        Dim dt As New DataTable
        Dim sql As String = ""
        If (whereVendedor <> "") Then
            whereVendedor = "vendedor in (" & whereVendedor & ") "
        Else
            whereVendedor = "vendedor>=1001 AND vendedor <=1099"
        End If
        If (usuario.Vendedor = 1047) Then
            sql = "SELECT  seg_idcor.Descripcion ,SUM (vtas.KILOS )as kilos,SUM (vtas.CANTIDAD  ) as Cantidad , SUM (vtas.Vr_total   )as Valor_tot,SUM (vtas.Cto_total ) As Cto_total  ,(SELECT CASE WHEN SUM (vtas.Vr_total) =0 THEN 0 ELSE ((SUM (vtas.Vr_total  )- SUM (vtas.Cto_total )) /SUM (vtas.Vr_total)*100 )END)AS Porc_util " & _
                                    "FROM Jjv_V_vtas_vend_cliente_ref vtas INNER JOIN referencias ref ON vtas.codigo = ref.codigo, JJV_Grupos_seguimiento seg_idcor  " & _
                                            "WHERE(vendedor = 1002 AND ciudad <>'caucasia' AND ciudad <>'choco' AND ciudad <>'quibdo' AND ciudad <>'quibdo' And Month(fec) = " & mes & " And Year(fec) = " & ano & " And seg_idcor.Id_cor = ref.Id_cor) " & _
                                                       "GROUP  by seg_idcor.Descripcion "
        Else
            sql = "SELECT  seg_idcor.Descripcion ,SUM (vtas.KILOS )as kilos,SUM (vtas.CANTIDAD  ) as Cantidad , SUM (vtas.Vr_total   )as Valor_tot,SUM (vtas.Cto_total ) As Cto_total  ,(SELECT CASE WHEN SUM (vtas.Vr_total) =0 THEN 0 ELSE ((SUM (vtas.Vr_total  )- SUM (vtas.Cto_total )) /SUM (vtas.Vr_total)*100 )END)AS Porc_util " & _
                                    "FROM Jjv_V_vtas_vend_cliente_ref vtas INNER JOIN referencias ref ON vtas.codigo = ref.codigo, JJV_Grupos_seguimiento seg_idcor  " & _
                                            "WHERE(" & whereVendedor & " And Month(fec) = " & mes & " And Year(fec) = " & ano & " And seg_idcor.Id_cor = ref.Id_cor) " & _
                                                       "GROUP  by seg_idcor.Descripcion "
        End If
        Dim DA As New SqlDataAdapter(sql, conn)
        DA.Fill(dt)
        conn.Close()
        Return dt
    End Function

    Public Function DetalleDev(ByVal mes As Integer, ByVal año As Integer, ByVal whereVendedor As String, ByVal usuario As UsuarioEn) As DataTable
        conn = objConexion.abrirConexion
        Dim sql As String = ""
        If (whereVendedor <> "") Then
            whereVendedor = "vendedor in (" & whereVendedor & ") "
        Else
            whereVendedor = "vendedor>=1001 AND vendedor <=1099"
        End If
        sql = "select  vendedor,nit,nombres,ciudad,condicion, cantidad,Kilos,Cto_total,Vr_total from Jjv_V_vtas_vend_cliente_ref where " & whereVendedor & "  and MONTH (fec )=" & mes & " and YEAR (fec)=" & año & " and sw = 2"
        Dim dt As New DataTable
        Dim DA As New SqlDataAdapter(sql, conn)
        DA.Fill(dt)
        conn.Close()
        Return dt
    End Function
    Public Function Detalle_no_reflej(ByVal whereVendedor As String, ByVal usuario As UsuarioEn) As DataTable
        conn = objConexion.abrirConexion
        Dim sql As String = ""
        Dim dt As New DataTable
        If (whereVendedor <> "") Then
            whereVendedor = "doc.vendedor in (" & whereVendedor & ") "
        Else
            whereVendedor = "doc.vendedor>=1001 AND doc.vendedor <=1099"
        End If
        sql = "Select  doc.bodega,doc.autorizacion , doc.numero,ter.nombres,doc.nit,ter.ciudad,doc.vendedor,doc.fecha,doc.valor_total as valor_tot,doc.notas,doc.notas_aut  " & _
                                         "FROM JJV_documentos_ped doc, Terceros ter " & _
                                                "WHERE doc.anulado = 0 and  " & whereVendedor & "  and ter.nit= doc.nit"
        Dim DA As New SqlDataAdapter(sql, conn)
        DA.Fill(dt)
        conn.Close()
        Return dt
    End Function
    Public Function total_ptes(ByVal min As Integer, ByVal max As Integer) As Double
        Dim totVtas As Double = 0
        Dim reader As SqlDataReader
        Dim sSql As String = ""
        comando.CommandType = CommandType.Text
        conn = objConexion.abrirConexion
        comando.Connection = conn
        sSql = "select distinct codigo,Valor_total,nit " & _
                        "from V_pendientes_por_vendedor " & _
                            "WHERE vendedor >= " & min & " and vendedor <= " & max & " "
        comando.CommandText = (sSql)
        reader = comando.ExecuteReader
        While (reader.Read)
            If IsDBNull(reader(1)) Then
            Else
                totVtas += reader(1)
            End If
        End While
        conn.Close()
        Return totVtas
    End Function

    Public Function tot_vtas(ByVal mes As Integer, ByVal año As Integer, ByVal min As Integer, ByVal max As Integer) As Double
        Dim totVtas As Double = 0
        Dim reader As SqlDataReader
        Dim sSql As String = ""
        comando.CommandType = CommandType.Text
        conn = objConexion.abrirConexion
        comando.Connection = conn
        sSql = "select SUM(Vr_total) " & _
                        "from Jjv_V_vtas_vend_cliente_ref " & _
                                "where vendedor >= " & min & " and vendedor <= " & max & " and MONTH (fec )=" & mes & " and YEAR (fec)=" & año & ""
        comando.CommandText = (sSql)
        reader = comando.ExecuteReader
        While (reader.Read)
            If IsDBNull(reader(0)) Then
            Else
                totVtas = reader(0)
            End If
        End While
        conn.Close()
        Return totVtas
    End Function
    Public Function listarInternacional(ByVal mes As Integer, ByVal año As Integer, ByVal vendedor As Integer, ByVal criterio As String, ByVal iva As Double) As SegVendEn
        Dim Pptoventas As Double = 0
        Pptoventas = presVtas(mes, año, vendedor, criterio)
        '   If (Pptoventas > 0) Then
        objSegVendEn = New SegVendEn
        objSegVendEn.Vendedor = vendedor
        objSegVendEn.Ventas = ventasVend(mes, año, vendedor, criterio)
        objSegVendEn.Pres_Ventas = Pptoventas
        objSegVendEn.Rec = Recaudos(mes, año, vendedor)
        objSegVendEn.Pres_rec = PresRecaudos(mes, año, vendedor)
        objSegVendEn.Pend = Pendientes(vendedor, criterio)
        objSegVendEn.No_reflej = no_reflej(vendedor, iva)
        objSegVendEn.Dev = Devoluciones(mes, año, vendedor, criterio)
        objSegVendEn.porCumVtas = (objSegVendEn.Ventas * 100) / objSegVendEn.Pres_Ventas
        objSegVendEn.porCumRec = (objSegVendEn.Rec * 100) / objSegVendEn.Pres_rec
        objSegVendEn.porDev = ((objSegVendEn.Dev * -1) * 100) / objSegVendEn.Ventas

        ' End If
        Return objSegVendEn
    End Function
    Public Function porc_util(ByVal mes As Integer, ByVal año As Integer, ByVal vendedor As Double) As Double
        Dim p_util As Double = 0
        Dim cto_tot As Double = 0
        Dim vr_tot As Double = 0
        Dim reader As SqlDataReader
        Dim sSql As String = ""
        comando.CommandType = CommandType.Text
        conn = objConexion.abrirConexion
        comando.Connection = conn
        sSql = "SELECT SUM (Cto_total) as Cto_total,SUM (Vr_total ) as Vr_total " & _
                        "FROM Jjv_V_vtas_vend_cliente_ref " & _
                                "WHERE  vendedor=" & vendedor & " and MONTH (fec )=" & mes & " and YEAR (fec)=" & año & ""
        comando.CommandText = (sSql)
        reader = comando.ExecuteReader
        While (reader.Read)
            If IsDBNull(reader(0)) Then
            Else
                cto_tot = reader("Cto_total")
                vr_tot = reader("Vr_total")
            End If
        End While
        p_util = (vr_tot - cto_tot) / (cto_tot) * 100
        conn.Close()
        Return p_util
    End Function


End Class
