Imports System.Data.SqlClient
Imports System.Data
Imports entidadNegocios
Public Class SegVendAd
    Private conn As New SqlConnection
    Private comando As New SqlCommand
    Private objConexion As New Conexion
    Private objSegVendEn As New SegVendEn

    Public Function listarNuev(ByVal mes As Integer, ByVal año As Integer, ByVal criterio As String) As List(Of SegVendEn)
        Dim listaNuevEn As New List(Of SegVendEn)
        Dim vecVend() As Integer = vendedores()
        Dim vendedor As Integer = 0
        Dim Pptoventas As Double = 0

        For i = 0 To 99
            If (vecVend(i) > 0) Then
                vendedor = vecVend(i)
                Pptoventas = presVtas(mes, año, vendedor, criterio)
                If (Pptoventas > 0) Then
                    objSegVendEn = New SegVendEn
                    objSegVendEn.Vendedor = vendedor
                    objSegVendEn.Ventas = ventasVend(mes, año, vendedor, criterio)
                    objSegVendEn.Pres_Ventas = Pptoventas
                    objSegVendEn.Rec = Recaudos(mes, año, vendedor)
                    objSegVendEn.Pres_rec = PresRecaudos(mes, año, vendedor)
                    objSegVendEn.Pend = Pendientes(mes, año, vendedor, criterio)
                    objSegVendEn.Dev = Devoluciones(mes, año, vendedor, criterio)
                    objSegVendEn.porCumVtas = (objSegVendEn.Ventas * 100) / objSegVendEn.Pres_Ventas
                    objSegVendEn.porCumRec = (objSegVendEn.Rec * 100) / objSegVendEn.Pres_rec
                    objSegVendEn.porDev = ((objSegVendEn.Dev * -1) * 100) / objSegVendEn.Ventas

                    listaNuevEn.Add(objSegVendEn)
                End If

            End If

        Next
        objSegVendEn = New SegVendEn
        objSegVendEn.Vendedor = "TOTALES"
        listaNuevEn.Add(objSegVendEn)
        Return listaNuevEn
    End Function
    Public Function listarIndividual(ByVal mes As Integer, ByVal año As Integer, ByVal vendedor As Integer, ByVal criterio As String) As List(Of SegVendEn)
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
            objSegVendEn.Pend = Pendientes(mes, año, vendedor, criterio)
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

    Private Function vendedores() As Integer()
        Dim reader As SqlDataReader
        Dim vecVend(99) As Integer
        Dim k As Double = 0
        Dim sSql As String = ""
        comando.CommandType = CommandType.Text
        conn = objConexion.abrirConexion
        comando.Connection = conn
        sSql = "select  vendedor " & _
                    " from v_vendedores " & _
                           "where (vendedor >= 1001) AND (vendedor <= 1099) AND (bloqueo = 0) ORDER BY vendedor"
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
    Private Function Pendientes(ByVal mes As Integer, ByVal año As Integer, ByVal vendedor As Integer, ByVal criterio As String) As Double
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

        sSql = "select distinct codigo," & criterio & " , vendedor " & _
                        "from Jjv_Ptes_Con_Stock " & _
                                "where vendedor=" & vendedor & " "
        comando.CommandText = (sSql)
        reader = comando.ExecuteReader
        While (reader.Read)
            If IsDBNull(reader(1)) Then
            Else
                TotPend += reader(1)
            End If
        End While
        conn.Close()
        Return TotPend
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
        Return totRec
    End Function
    Public Function DetalleVentasVend(ByVal mes As Integer, ByVal año As Integer, ByVal min As Integer, ByVal max As Integer) As DataTable
        conn = objConexion.abrirConexion
        Dim dt As New DataTable
        Dim DA As New SqlDataAdapter("select  fec,vendedor,nit,nombres,ciudad,condicion, cantidad,Kilos,(Vr_total/Kilos) as vr_kilo,(Cto_total/Kilos) as cto_kilo,Vr_total,(Vr_total/Kilos-Cto_total/Kilos)/(Vr_total/Kilos)*100 as porc_util  from Jjv_V_vtas_vend_cliente_ref where vendedor >=" & min & "  and vendedor <= " & max & " and MONTH (fec )=" & mes & " and YEAR (fec)=" & año & " order  by nit", conn)
        DA.Fill(dt)
        Return dt
    End Function
    Public Function DetaPptoVtas(ByVal mes As Integer, ByVal año As Integer, ByVal min As Integer, ByVal max As Integer) As DataTable
        conn = objConexion.abrirConexion
        Dim dt As New DataTable
        Dim DA As New SqlDataAdapter("select vendedor,Id_cor,ppto_kilos,Vr_total,Vr_kilo,Cto_kilo,Porc_util,Fecha_mod1 as fec_modificacion,Dias_habil,Cto_total from Jjv_Ppto_mes where vendedor >=" & min & "  and vendedor <= " & max & " and MONTH (Fecha_ppto  )=" & mes & "  and YEAR (Fecha_ppto)=" & año & "", conn)
        DA.Fill(dt)
        Return dt
    End Function
    Public Function DetalleRec(ByVal mes As Integer, ByVal año As Integer, ByVal min As Integer, ByVal max As Integer) As DataTable
        conn = objConexion.abrirConexion
        Dim dt As New DataTable
        Dim DA As New SqlDataAdapter(" select Rec.vendedor,Rec.ciudad,ter.nit  ,Rec.nombres ,Rec.tipo,Rec.tipo_aplica,Rec.VALOR,Rec.DESCUENTO,Rec.Total_rec,Rec.fecha  from Jjv_Recaudos_consol Rec , terceros ter where Rec.vendedor >=" & min & "  and Rec.vendedor <= " & max & " and MONTH (Rec.fecha  )= " & mes & " and YEAR (Rec.fecha)=" & año & " and ter.nombres  = Rec.nombres ", conn)
        DA.Fill(dt)
        Return dt
    End Function
    Public Function DetallePptoRec(ByVal mes As Integer, ByVal año As Integer, ByVal min As Integer, ByVal max As Integer) As DataTable
        conn = objConexion.abrirConexion
        Dim dt As New DataTable
        Dim DA As New SqlDataAdapter(" select nit,Año,Mes,Ppto_vtas ,Ppto_Calculado,Fecha_mod_ppto_rec,Ppto_client_contado,Ppto_total,TotClientCont from Jjv_ppto_vtas_recaudos_consol where nit >=" & min & "  and nit <= " & max & " and mes=" & mes & " and Año =" & año & "", conn)
        DA.Fill(dt)
        Return dt
    End Function
    Public Function DetallePend(ByVal mes As Integer, ByVal año As Integer, ByVal min As Integer, ByVal max As Integer) As DataTable
        conn = objConexion.abrirConexion
        Dim dt As New DataTable
        Dim DA As New SqlDataAdapter("select distinct vendedor, codigo,nit,nombres,fecha,Valor_total,cant_Pedida as Cant, kilosPendiente as Kilos, (costo_total/cant_Pedida )as Cto_Kilo,valor_unitario,(valor_unitario-(costo_total/cant_Pedida ))/(valor_unitario)*100 as Por_util,descripcion , bloqueo,condicion,cupo_credito  from Jjv_Ptes_Con_Stock where vendedor >=" & min & "  and vendedor <= " & max & " and MONTH (fecha  )=" & mes & " and YEAR (fecha)=" & año & "", conn)
        DA.Fill(dt)
        Return dt
    End Function
    Public Function DetalleDev(ByVal mes As Integer, ByVal año As Integer, ByVal min As Integer, ByVal max As Integer) As DataTable
        conn = objConexion.abrirConexion
        Dim dt As New DataTable
        Dim DA As New SqlDataAdapter("select  vendedor,nit,nombres,ciudad,condicion, cantidad,Kilos,Cto_total,Vr_total from Jjv_V_vtas_vend_cliente_ref where vendedor >=" & min & "  and vendedor <= " & max & " and MONTH (fec )=" & mes & " and YEAR (fec)=" & año & " and sw = 2", conn)
        DA.Fill(dt)
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
                        "from Jjv_Ptes_Con_Stock " & _
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


End Class
