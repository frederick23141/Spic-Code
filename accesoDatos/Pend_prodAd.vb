Imports System.Data.SqlClient
Imports System.Data
Imports entidadNegocios
Public Class Pend_prodAd

    Public Function listar_id_cor() As String(,)
        Dim conn As New SqlConnection
        Dim i As Integer = 0
        Dim reader As SqlDataReader
        Dim comando As New SqlCommand
        Dim objConexion As New Conexion
        Dim mat(40, 2) As String
        comando.CommandType = CommandType.Text
        conn = objConexion.abrirConexion
        comando.Connection = conn
        comando.CommandText = "select Id_cor,Descripcion   from JJV_Grupos_seguimiento ORDER BY id_cor"
        reader = comando.ExecuteReader
        While (reader.Read)
            mat(i, 0) = reader("id_cor")
            mat(i, 1) = reader("Descripcion")
            i += 1
        End While
        mat(i, 0) = -1
        mat(i, 1) = "TODOS"
        conn.Close()
        Return mat
    End Function
    Public Function listar_tipo_idCor() As String()
        Dim conn As New SqlConnection
        Dim i As Integer = 0
        Dim reader As SqlDataReader
        Dim comando As New SqlCommand
        Dim objConexion As New Conexion
        Dim vec(10) As String
        comando.CommandType = CommandType.Text
        conn = objConexion.abrirConexion
        comando.Connection = conn
        comando.CommandText = "select Descripcion_tipo  from JJV_Grupos_seguimiento group by Descripcion_tipo"
        reader = comando.ExecuteReader
        While (reader.Read)
            If Not IsDBNull(reader("Descripcion_tipo")) Then
                vec(i) = reader("Descripcion_tipo")
                i += 1
            End If
        End While
        vec(i) = "TODOS"
        conn.Close()
        Return vec
    End Function
    Public Function listar_pend_prod(ByVal idcor_min As Integer, ByVal idcor_max As Integer) As DataTable
        Dim conn As New SqlConnection
        Dim objConexion As New Conexion
        Dim sql As String = ""
             conn = objConexion.abrirConexion
        Dim dt As New DataTable
        Dim DA As New SqlDataAdapter(sql, conn)
        DA.Fill(dt)
        Return dt
    End Function
    Public Function listarBusqueda(ByVal idcor_min As Integer, ByVal idcor_max As Integer, ByVal tipo As String) As DataView
        Dim conn As New SqlConnection
        Dim reader As SqlDataReader
        Dim comando As New SqlCommand
        Dim objConexion As New Conexion
        Dim dt As New DataTable
        Dim dr As DataRow
        Dim list_vend As New List(Of Integer)
        Dim stock As Double = 0
        Dim codigo As String = ""
        Dim sql As String = ""
        Dim oldCoode As String = ""
        dt.Columns.Add("Bod") '
        dt.Columns.Add("Còdigo") '
        dt.Columns.Add("Descripciòn") '
        dt.Columns.Add("Nùmero", GetType(Int64))
        dt.Columns.Add("Nit", GetType(Int64))
        dt.Columns.Add("Nombres")
        dt.Columns.Add("Kilos_Pend", GetType(Int64)) '
        dt.Columns.Add("Stock", GetType(Int64))
        dt.Columns.Add("Fecha", GetType(Date))
        dt.Columns.Add("Cant_Pend", GetType(Int64)) '
        dt.Columns.Add("Prioridad", GetType(Int64))
        dt.Columns.Add("Notas")

        If (tipo = "TODOS") Then
            sql = "SELECT distinct pend.bodega,pend.KilosPendiente,pend.nit,ter.nombres,pend.codigo ,pend.maximo ,pend.minimo,pend.descripcion , (pend.Cant_pedida- pend.cantidad_despachada  )AS cantidad, pend.numero,pend.fecha ,pend.notas " & _
                               "FROM V_pendientes_por_vendedor pend,terceros ter " & _
                                     "WHERE ter.nit = pend.nit "
        Else
            If (tipo = "") Then
                sql = "SELECT distinct pend.bodega,pend.KilosPendiente,pend.nit,ter.nombres,pend.codigo ,pend.maximo ,pend.minimo,pend.descripcion , (pend.Cant_pedida- pend.cantidad_despachada  )AS cantidad, pend.numero,pend.fecha ,pend.notas " & _
                                     "FROM V_pendientes_por_vendedor pend,terceros ter " & _
                                            "WHERE pend.Id_cor >=" & idcor_min & " AND pend.Id_cor <=" & idcor_max & " AND ter.nit = pend.nit "
            Else
                sql = "SELECT distinct pend.bodega,pend.KilosPendiente,pend.nit,ter.nombres,pend.codigo ,pend.maximo ,pend.minimo,pend.descripcion , (pend.Cant_pedida- pend.cantidad_despachada  )AS cantidad, pend.numero,pend.fecha ,pend.notas " & _
                                "FROM V_pendientes_por_vendedor pend INNER JOIN referencias ref ON pend.codigo = ref.codigo , JJV_Grupos_seguimiento seg_idcor ,terceros ter " & _
                                          "WHERE seg_idcor.Tipo  =" & tipo & " and seg_idcor.Id_cor = ref.Id_cor and ter.nit = pend.nit "
            End If
        End If
        comando.CommandType = CommandType.Text
        conn = objConexion.abrirConexion
        comando.Connection = conn
        comando.CommandText = sql
        reader = comando.ExecuteReader
        While (reader.Read)
            codigo = reader("codigo")
            stock = cant_stock(codigo)
            dr = dt.NewRow

            dr("Còdigo") = codigo
            dr("Descripciòn") = reader("descripcion")
            dr("Bod") = reader("bodega")
            dr("Nùmero") = reader("numero")
            dr("Nit") = reader("nit")
            dr("Nombres") = reader("nombres")
            dr("Kilos_Pend") = reader("KilosPendiente")
            dr("Stock") = stock
            dr("Cant_Pend") = reader("cantidad")
            dr("Prioridad") = stock - reader("cantidad")
            dr("Fecha") = reader("fecha")
            dr("Notas") = reader("notas")
            dt.Rows.Add(dr)
        End While
        conn.Close()
        reader.Close()

        dt = agregar_no_reflej(idcor_min, idcor_max, tipo, dt)
        conn.Close()
        reader.Close()
        Dim view As DataView = New DataView(dt)

        ' Lo ordenamos por el campo Nombre.
        '
        view.Sort = "Còdigo"
        Return (view)

    End Function
    Public Function agregar_no_reflej(ByVal idcor_min As Integer, ByVal idcor_max As Integer, ByVal tipo As String, ByVal dt As DataTable) As DataTable
        Dim conn As New SqlConnection
        Dim reader As SqlDataReader
        Dim comando As New SqlCommand
        Dim objConexion As New Conexion
        Dim list_vend As New List(Of Integer)
        Dim dr As DataRow
        Dim stock As Double = 0
        Dim codigo As String = ""
        Dim sql As String = ""
        If (tipo = "TODOS") Then
            sql = "SELECT distinct pend.bodega,(ref.conversion * pend.cantidad) as kilos,pend.nit,ter.nombres,pend.codigo ,pend.maximo ,pend.minimo,pend.descripcion , pend.cantidad, pend.numero,pend.fecha ,pend.notas " & _
                        "FROM Jjv_pedidos_problema pend INNER JOIN referencias ref ON pend.codigo = ref.codigo , terceros ter " & _
                             "WHERE ter.nit = pend.nit  "
        Else
            If (tipo = "") Then
                sql = "SELECT distinct pend.bodega,(ref.conversion * pend.cantidad) as kilos,pend.nit,ter.nombres,pend.codigo ,pend.maximo ,pend.minimo,pend.descripcion , pend.cantidad, pend.numero,pend.fecha ,pend.notas " & _
                            "FROM Jjv_pedidos_problema pend INNER JOIN referencias ref ON pend.codigo = ref.codigo , terceros ter " & _
                                    "WHERE ref.Id_cor >=" & idcor_min & " and ref.Id_cor <=" & idcor_max & " AND ter.nit = pend.nit "
            Else
                sql = "SELECT distinct pend.bodega,(ref.conversion * pend.cantidad) as kilos,pend.nit,ter.nombres,pend.codigo ,pend.maximo ,pend.minimo,pend.descripcion , pend.cantidad, pend.numero,pend.fecha ,pend.notas " & _
                                 "FROM Jjv_pedidos_problema pend INNER JOIN referencias ref ON pend.codigo = ref.codigo , JJV_Grupos_seguimiento seg_idcor  , terceros ter " & _
                                         "WHERE seg_idcor.Tipo  =" & tipo & " and seg_idcor.Id_cor = ref.Id_cor AND ter.nit = pend.nit "
            End If
        End If
        comando.CommandType = CommandType.Text
        conn = objConexion.abrirConexion
        comando.Connection = conn
        comando.CommandText = sql
        reader = comando.ExecuteReader
        While (reader.Read)
            codigo = reader("codigo")
            stock = cant_stock(codigo)
            dr = dt.NewRow
            dr("Stock") = stock
            dr("Bod") = reader("bodega")
            dr("Nùmero") = reader("numero")
            dr("Nit") = reader("nit")
            dr("Nombres") = reader("nombres")
            dr("Cant_Pend") = reader("cantidad")
            dr("Kilos_Pend") = reader("kilos")
            dr("Prioridad") = stock - reader("cantidad")
            dr("Còdigo") = codigo
            dr("Descripciòn") = reader("descripcion")
            dr("Fecha") = reader("fecha")
            dr("Notas") = reader("notas")

            dt.Rows.Add(dr)
        End While
        conn.Close()
        reader.Close()
        Return dt
    End Function
    Public Function cant_stock(ByVal codigo As String) As Double
        Dim conn As New SqlConnection
        Dim reader As SqlDataReader
        Dim comando As New SqlCommand
        Dim objConexion As New Conexion
        Dim sum As Double = 0
        comando.CommandType = CommandType.Text
        conn = objConexion.abrirConexion
        comando.Connection = conn
        comando.CommandText = "select SUM(stock )from v_referencias_sto_hoy " & _
                                    "where  bodega in (3,7)and Id_cor is not null and codigo ='" & codigo & "' "
        reader = comando.ExecuteReader
        While (reader.Read)
            If Not IsDBNull(reader(0)) Then
                sum = reader(0)
            End If

        End While
        conn.Close()
        Return sum
    End Function
    Public Function listarConsolidado(ByVal idcor_min As Integer, ByVal idcor_max As Integer, ByVal tipo As String) As DataTable
        Dim conn As New SqlConnection
        Dim reader As SqlDataReader
        Dim comando As New SqlCommand
        Dim objConexion As New Conexion
        Dim dt As New DataTable
        Dim dr As DataRow
        Dim stock As Double = 0
        Dim codigo As String = ""
        Dim sql As String = ""
        Dim fec_pto As String = Now.Year & "-" & Now.Month & "-1"
        dt.Columns.Add("Còdigo") '
        dt.Columns.Add("Descripciòn") '
        dt.Columns.Add("Kilos_Pend", GetType(Int64)) '
        dt.Columns.Add("Stock", GetType(Int64))
        dt.Columns.Add("Cant_Pend", GetType(Int64)) '
        dt.Columns.Add("Prioridad", GetType(Int64))
        dt.Columns.Add("Entradas", GetType(Int64))
        dt.Columns.Add("Salidas", GetType(Int64))

        'dt.Columns.Add("Producciòn", GetType(Int64)) '


        If (tipo = "TODOS") Then
            sql = "SELECT SUM (pend.KilosPendiente )as Kilos_Pend,pend.codigo,pend.descripcion ,(SUM (pend.Cant_pedida  )- SUM(pend.cantidad_despachada ))As Cant_Pend ,(SELECT SUM (Vr_total ) FROM  Jjv_V_vtas_vend_cliente_ref WHERE codigo = pend.codigo )AS ventas ,SUM (sto.can_ent )AS Entradas,SUM (sto.can_sal  )AS Salidas " & _
                          "FROM V_pendientes_por_vendedor pend ,v_referencias_sto_hoy sto " & _
                                    "WHERE(pend.codigo = sto.codigo) " & _
                                             "GROUP BY pend.codigo ,pend.descripcion  "
        Else
            If (tipo = "") Then
                sql = "SELECT SUM (pend.KilosPendiente )as Kilos_Pend,pend.codigo,pend.descripcion ,(SUM (pend.Cant_pedida  )- SUM(pend.cantidad_despachada ))As Cant_Pend ,(SELECT SUM (Vr_total ) FROM  Jjv_V_vtas_vend_cliente_ref WHERE codigo = pend.codigo )AS ventas ,SUM (sto.can_ent )AS Entradas,SUM (sto.can_sal  )AS Salidas " & _
                             "FROM V_pendientes_por_vendedor  pend ,v_referencias_sto_hoy sto " & _
                                    "WHERE(pend.Id_cor >= " & idcor_min & " And pend.Id_cor <= " & idcor_max & " And sto.codigo = pend.codigo) " & _
                                            "GROUP  by pend.codigo,pend.descripcion "
            Else

                sql = "SELECT SUM (pend.KilosPendiente )as Kilos_Pend,pend.codigo,pend.descripcion ,(SUM (pend.Cant_pedida  )- SUM(pend.cantidad_despachada ))As Cant_Pend ,(SELECT SUM (Vr_total ) FROM  Jjv_V_vtas_vend_cliente_ref WHERE codigo = pend.codigo )AS ventas ,SUM (sto.can_ent )AS Entradas,SUM (sto.can_sal  )AS Salidas  " & _
                                 "FROM V_pendientes_por_vendedor pend INNER JOIN referencias ref ON pend.codigo = ref.codigo , JJV_Grupos_seguimiento seg_idcor ,v_referencias_sto_hoy sto " & _
                                                "WHERE(seg_idcor.Tipo = " & tipo & " And seg_idcor.Id_cor = ref.Id_cor And sto.codigo = pend.codigo) " & _
                                                   "GROUP  by pend.codigo,pend.descripcion " & _
                                                         "ORDER BY pend.codigo"
            End If
        End If
        comando.CommandType = CommandType.Text
        conn = objConexion.abrirConexion
        comando.Connection = conn
        comando.CommandText = sql
        reader = comando.ExecuteReader
        While (reader.Read)
            codigo = reader("codigo")
            stock = cant_stock(codigo)
            dr = dt.NewRow

            dr("Còdigo") = codigo
            dr("Descripciòn") = reader("descripcion")
            dr("Kilos_Pend") = reader("Kilos_Pend")
            dr("Entradas") = reader("Entradas")
            dr("Salidas") = reader("Salidas")
            dr("Stock") = stock
            dr("Cant_Pend") = reader("Cant_Pend")
            dr("Prioridad") = stock - reader("Cant_Pend")
            ' dr("Ppto_prod") = reader("ppto_kilos")
            ' dr("Producciòn") = produccion(idcor_min, idcor_max, tipo)
            'dr("X_cumplir") = ""
            'dr("Ppto_vtas") = ""

            dt.Rows.Add(dr)
        End While
        conn.Close()
        reader.Close()

        'dt = consol_no_reflej(idcor_min, idcor_max, tipo, dt)
        conn.Close()
        reader.Close()
        Return (dt)

    End Function
    Public Function consol_no_reflej(ByVal idcor_min As Integer, ByVal idcor_max As Integer, ByVal tipo As String, ByVal dt As DataTable) As DataTable
        Dim conn As New SqlConnection
        Dim reader As SqlDataReader
        Dim comando As New SqlCommand
        Dim objConexion As New Conexion
        Dim list_vend As New List(Of Integer)
        Dim dr As DataRow
        Dim stock As Double = 0
        Dim codigo As String = ""
        Dim sql As String = ""
        If (tipo = "TODOS") Then
            sql = "SELECT SUM (ref.conversion * pend.cantidad )as kilos,pend.codigo,seg_idcor.descripcion ,SUM (pend.cantidad ) As cantidad ,(SUM (pend.Cant_pedida  )- SUM(pend.cantidad_despachada ))As cantidad ,(SELECT SUM (Vr_total ) FROM  Jjv_V_vtas_vend_cliente_ref WHERE codigo = pend.codigo )AS ventas " & _
                        "FROM Jjv_pedidos_problema pend INNER JOIN referencias ref ON pend.codigo = ref.codigo , terceros ter , JJV_Grupos_seguimiento seg_idcor " & _
                                "WHERE(ter.nit = pend.nit And seg_idcor.Id_cor = ref.Id_cor) " & _
                                        "GROUP BY pend.codigo,seg_idcor.Descripcion  "
        Else
            If (tipo = "") Then
                sql = "SELECT SUM (ref.conversion * pend.cantidad )as kilos,pend.codigo,seg_idcor.descripcion ,SUM (pend.cantidad ) As cantidad ,,(SUM (pend.Cant_pedida  )- SUM(pend.cantidad_despachada ))As cantidad ,(SELECT SUM (Vr_total ) FROM  Jjv_V_vtas_vend_cliente_ref WHERE codigo = pend.codigo )AS ventas " & _
                        "FROM Jjv_pedidos_problema pend INNER JOIN referencias ref ON pend.codigo = ref.codigo , terceros ter , JJV_Grupos_seguimiento seg_idcor " & _
                                    "WHERE ref.Id_cor >=" & idcor_min & " and ref.Id_cor <=" & idcor_max & " AND ter.nit = pend.nit And seg_idcor.Id_cor = ref.Id_cor " & _
                                            "GROUP BY pend.codigo,seg_idcor.Descripcion  "
            Else
                sql = "SELECT SUM (ref.conversion * pend.cantidad )as kilos,pend.codigo,seg_idcor.descripcion ,SUM (pend.cantidad ) As cantidad , ,(SUM (pend.Cant_pedida  )- SUM(pend.cantidad_despachada ))As cantidad ,(SELECT SUM (Vr_total ) FROM  Jjv_V_vtas_vend_cliente_ref WHERE codigo = pend.codigo )AS ventas " & _
                                 "FROM Jjv_pedidos_problema pend INNER JOIN referencias ref ON pend.codigo = ref.codigo , JJV_Grupos_seguimiento seg_idcor  , terceros ter  " & _
                                         "WHERE seg_idcor.Tipo  =" & tipo & " and seg_idcor.Id_cor = ref.Id_cor AND ter.nit = pend.nit And seg_idcor.Id_cor = ref.Id_cor " & _
                                            "GROUP BY pend.codigo,seg_idcor.Descripcion  "
            End If
        End If
        comando.CommandType = CommandType.Text
        conn = objConexion.abrirConexion
        comando.Connection = conn
        comando.CommandText = sql
        reader = comando.ExecuteReader
        While (reader.Read)
            codigo = reader("codigo")
            stock = cant_stock(codigo)
            dr = dt.NewRow
            dr("Còdigo") = codigo
            dr("Descripciòn") = reader("descripcion")
            dr("Kilos_Pend") = reader("kilos")
            dr("Stock") = stock
            dr("Cant_Pend") = reader("cantidad")
            dr("Prioridad") = stock - reader("cantidad")
            'dr("Ppto_prod") = ""
            'dr("Producciòn") = ""
            'dr("X_cumplir") = ""
            'dr("Ppto_vtas") = ""


            dt.Rows.Add(dr)
        End While
        conn.Close()
        reader.Close()
        Return dt
    End Function
    Public Function Detalle_consol_pend_idCor() As DataTable
        Dim conn As New SqlConnection
        Dim reader As SqlDataReader
        Dim comando As New SqlCommand
        Dim objConexion As New Conexion
        Dim dt As New DataTable
        Dim dr As DataRow
        Dim stock As Double = 0
        Dim codigo As String = ""
        Dim sql As String = ""
        Dim fec_pto As String = Now.Year & "-" & Now.Month & "-1"
        Dim vtas As Double = 0
        Dim ppto_vtas As Double = 0
        dt.Columns.Add("Descripciòn") '
        dt.Columns.Add("Kilos_Pend", GetType(Int64)) '
        dt.Columns.Add("Stock", GetType(Int64))
        dt.Columns.Add("Cant_Pend", GetType(Int64)) '
        dt.Columns.Add("Prioridad", GetType(Int64))
        dt.Columns.Add("Entradas", GetType(Int64))
        dt.Columns.Add("Ventas", GetType(Int64))
        dt.Columns.Add("Ppto_vtas", GetType(Int64))
        dt.Columns.Add("Por_vender", GetType(Int64))

        'dt.Columns.Add("Producciòn", GetType(Int64)) '
        sql = "SELECT seg_idcor.Id_cor , seg_idcor.Descripcion ,SUM (pend.KilosPendiente )as Kilos_Pend,(SUM (pend.Cant_pedida  )- SUM(pend.cantidad_despachada ))As Cant_Pend , SUM (pend.Valor_total  )as Valor_tot " & _
                     "FROM V_pendientes_por_vendedor pend  INNER JOIN referencias ref ON pend.codigo = ref.codigo , JJV_Grupos_seguimiento seg_idcor " & _
                        "WHERE seg_idcor.Id_cor = ref.Id_cor  " & _
                                "GROUP  by seg_idcor.Descripcion ,seg_idcor.Id_cor "
        comando.CommandType = CommandType.Text
        conn = objConexion.abrirConexion
        comando.Connection = conn
        comando.CommandText = sql
        reader = comando.ExecuteReader
        While (reader.Read)
            stock = cant_stock_idCor(reader("Id_cor"))
            vtas = cant_vtas_idCor(reader("Id_cor"))
            ppto_vtas = ppto_Vtas_idCor(reader("Id_cor"))
            dr = dt.NewRow

            dr("Descripciòn") = reader("descripcion")
            dr("Kilos_Pend") = reader("Kilos_Pend")
            dr("Stock") = stock
            dr("Cant_Pend") = reader("Cant_Pend")
            dr("Ppto_vtas") = ppto_vtas
            dr("Entradas") = cant_ent_idCor(reader("Id_cor"))
            dr("Ventas") = vtas
            dr("Prioridad") = stock - reader("Cant_Pend")
            dr("Por_vender") = ppto_vtas - vtas
            ' dr("Ppto_prod") = reader("ppto_kilos")
            ' dr("Producciòn") = produccion(idcor_min, idcor_max, tipo)
            'dr("X_cumplir") = ""
            'dr("Ppto_vtas") = ""

            dt.Rows.Add(dr)
        End While
        conn.Close()
        reader.Close()


        'dt = consol_no_reflej(idcor_min, idcor_max, tipo, dt)
        conn.Close()
        reader.Close()

        Return (dt)
    End Function
    Public Function cant_ent_idCor(ByVal id_cor As Integer) As Double
        Dim conn As New SqlConnection
        Dim reader As SqlDataReader
        Dim comando As New SqlCommand
        Dim objConexion As New Conexion
        Dim resp As Double = 0
        comando.CommandType = CommandType.Text
        conn = objConexion.abrirConexion
        comando.Connection = conn
        comando.CommandText = "SELECT SUM (sto.can_ent ) " & _
                                "FROM v_referencias_sto_hoy  sto  " & _
                                    "WHERE sto.Id_cor = " & id_cor & ""
        reader = comando.ExecuteReader
        While (reader.Read)
            If Not IsDBNull(reader(0)) Then
                resp = reader(0)
            End If

        End While
        conn.Close()
        Return resp
    End Function
    Public Function ppto_Vtas_idCor(ByVal id_cor As Integer) As Double
        Dim conn As New SqlConnection
        Dim reader As SqlDataReader
        Dim comando As New SqlCommand
        Dim objConexion As New Conexion
        Dim resp As Double = 0
        comando.CommandType = CommandType.Text
        conn = objConexion.abrirConexion
        comando.Connection = conn
        comando.CommandText = "Select SUM (Vr_kilo ) from Jjv_Ppto_mes where Id_cor = " & id_cor & " AND MONTH (Fecha_ppto )=" & Now.Month & " AND YEAR (Fecha_ppto ) = " & Now.Year & " "
        reader = comando.ExecuteReader
        While (reader.Read)
            If Not IsDBNull(reader(0)) Then
                resp = reader(0)
            End If

        End While
        conn.Close()
        Return resp
    End Function
    Public Function cant_stock_idCor(ByVal id_cor As Integer) As Double
        Dim conn As New SqlConnection
        Dim reader As SqlDataReader
        Dim comando As New SqlCommand
        Dim objConexion As New Conexion
        Dim resp As Double = 0
        comando.CommandType = CommandType.Text
        conn = objConexion.abrirConexion
        comando.Connection = conn
        Dim sql As String = "SELECT SUM (sto.stock ) " &
                                    "FROM v_referencias_sto_hoy  sto " &
                                            "WHERE sto.Id_cor = " & id_cor
        comando.CommandText = sql
        reader = comando.ExecuteReader
        While (reader.Read)
            If Not IsDBNull(reader(0)) Then
                resp = reader(0)
            End If

        End While
        conn.Close()
        Return resp
    End Function
    Public Function cant_vtas_idCor(ByVal id_cor As Integer) As Double
        Dim conn As New SqlConnection
        Dim reader As SqlDataReader
        Dim comando As New SqlCommand
        Dim objConexion As New Conexion
        Dim resp As Double = 0
        comando.CommandType = CommandType.Text
        conn = objConexion.abrirConexion
        comando.Connection = conn
        comando.CommandText = "SELECT SUM (vtas.Kilos   ) " &
                                 "FROM Jjv_V_vtas_vend_cliente_ref vtas " &
                                      "WHERE  vtas.Id_cor = " & id_cor & " And MONTH ( vtas.fec) = " & Now.Month & " And YEAR (fec)= " & Now.Year & "  "
        reader = comando.ExecuteReader
        While (reader.Read)
            If Not IsDBNull(reader(0)) Then
                resp = reader(0)
            End If

        End While
        conn.Close()
        Return resp
    End Function
    Public Function produccion(ByVal idcor_min As Integer, ByVal idcor_max As Integer, ByVal tipo As String)
        Dim conn As New SqlConnection
        Dim comando1 As SqlCommand
        comando1 = New SqlCommand
        Dim resp As Double = 0
        Dim reader As SqlDataReader
        Dim sql As String = ""
        Dim objConexion As New Conexion
        comando1.CommandType = CommandType.Text
        conn = objConexion.abrirConexion
        comando1.Connection = conn
        If (tipo = "TODOS") Then
            sql = "SELECT SUM (can_ent)  FROM jjv_stock_entradas WHERE id_cor Is Not null"
        Else
            If (tipo = "") Then
                sql = "SELECT SUM (can_ent)  FROM jjv_stock_entradas WHERE id_cor >=" & idcor_min & " And Id_cor <=" & idcor_max & " "
            Else
                sql = "SELECT SUM(can_ent) from jjv_stock_entradas prod , JJV_Grupos_seguimiento seg " & _
                            "where prod.Id_cor = seg.Id_cor AND seg.Tipo = " & tipo & " "
            End If
        End If

        comando1.CommandText = (sql)
        reader = comando1.ExecuteReader
        If (reader.Read) Then
            If IsDBNull(reader(0)) Then
            Else
                resp = reader(0)
            End If
        End If
        Return resp
    End Function
End Class
