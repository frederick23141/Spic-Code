Imports System.Data.SqlClient
Imports System.Data
Imports entidadNegocios

Public Class AnalisisAd2

    '****************************************************************************************************************
    'Se crean los parametros para la conexion ***********************************************************************
    '****************************************************************************************************************
    Public listaAnalisisBloq As New List(Of AnalisisEn)

    Public listaAnalisisVenc As New List(Of AnalisisEn)
    Public listaAnalisisBueno As New List(Of AnalisisEn)
    Public listaAnalisisCupo As New List(Of AnalisisEn)
    Public listaCupoYdocVenc As New List(Of AnalisisEn)
    Dim objAnalisisEn As AnalisisEn
    Dim objPendAd As New pendientesAd
    Public dt As DataTable
    Public dt2 As DataTable
    Private vendedores As String
    Public Sub LLenarTodo(ByVal min As Double, ByVal max As Double, ByVal vendedores As String, ByVal iva As Double)
        Me.vendedores = vendedores
        listaAnalisisBloq = New List(Of AnalisisEn)
        listaAnalisisVenc = New List(Of AnalisisEn)
        listaAnalisisBueno = New List(Of AnalisisEn)
        listaAnalisisCupo = New List(Of AnalisisEn)
        listaCupoYdocVenc = New List(Of AnalisisEn)
        listarBuenos(min, max, iva)
        listarBloq(min, max)
        'listarCupo(min, max)
        'listarDocVenc(min, max)
    End Sub
    Public Function listarBuenos(ByVal min As Integer, ByVal max As Integer, ByVal iva As Double) As List(Of AnalisisEn)()
        Dim criterioVendedor As String = ""
        criterioVendedor = " Ptes.vendedor>=" & min & " and Ptes.vendedor<=" & max & " "
        If (vendedores <> "") Then
            criterioVendedor &= " AND Ptes.vendedor in(" & vendedores & ") "
        End If
        Dim conn2 As New SqlConnection
        Dim comando As New SqlCommand
        Dim objConexion As New Conexion
        Dim reader2 As SqlDataReader
        Dim vec(1) As List(Of AnalisisEn)
        Dim cont As Integer = 0
        conn2 = objConexion.abrirConexion
        comando.CommandType = CommandType.Text
        comando.Connection = conn2

        comando.CommandText = "SELECT  distinct Ptes.codigo,Ptes.fecha,Ptes. descripcion,Ptes.Pendiente,Ptes.KilosPendiente,Ptes.Valor_total,Ptes.notas AS NOTAS_PED ,Ptes.vendedor,Ptes.ciudad,Ptes.nit,Ptes.nombres,Ptes.bloqueo,Ptes.condicion AS Credito, Ptes.numero,Ptes.autorizacion ,Ptes.nota_vta,Ptes.notas5,ptes.notas_aut,ptes.Cant_pedida,ptes.valor_unitario,ptes.bodega FROM V_pendientes_por_vendedor Ptes , terceros cli WHERE ((Ptes.autorizacion = 's'or Ptes.autorizacion = 'a' ) or  ((Ptes.nit not in (SELECT     nit FROM  V_Doc_Vencidos  where " & criterioVendedor & " and Dias_Vencido >10 )) and (Ptes.bloqueo =0 )))and  " & criterioVendedor & " and cli.nit = Ptes.nit  ORDER BY Ptes.nit,Ptes.numero"
        reader2 = comando.ExecuteReader
        While reader2.Read
            If IsDBNull(reader2) Then
            Else

                objAnalisisEn = New AnalisisEn
                objAnalisisEn.fechaA = reader2("fecha")
                objAnalisisEn.codigoA = reader2("codigo")
                objAnalisisEn.descripcionA = reader2("descripcion")
                objAnalisisEn.pendienteA = reader2("Pendiente")
                objAnalisisEn.kilosA = reader2("KilosPendiente")
                objAnalisisEn.valTotA = reader2("Valor_total")
                objAnalisisEn.notasA = reader2("NOTAS_PED")
                objAnalisisEn.vendedorA = reader2("vendedor")
                objAnalisisEn.ciudadaA = reader2("ciudad")
                objAnalisisEn.nitA = reader2("nit")
                objAnalisisEn.nombresA = reader2("nombres")
                objAnalisisEn.bloqueoA = reader2("bloqueo")
                objAnalisisEn.creditoA = reader2("Credito")
                objAnalisisEn.Numero = reader2("numero")
                objAnalisisEn.aut = reader2("autorizacion")
                objAnalisisEn.notas_venta = reader2("nota_vta")
                objAnalisisEn.notas_prod = reader2("notas5")
                objAnalisisEn.notas_aut = reader2("notas_aut")
                objAnalisisEn.bodega = reader2("bodega")
                objAnalisisEn.valor_unitario = reader2("valor_unitario")
                objAnalisisEn.Cant_pedida = reader2("Cant_pedida")

                If (IsDBNull(reader2("autorizacion"))) Then
                    If (pendSincupo(reader2("nit"), reader2("numero"), iva)) Then
                        '  If (True) Then
                        listaAnalisisCupo.Add(objAnalisisEn)
                    Else
                        listaAnalisisBueno.Add(objAnalisisEn)
                    End If

                Else
                    If (reader2("autorizacion") = "S" Or reader2("autorizacion") = "A") Then
                        listaAnalisisBueno.Add(objAnalisisEn)
                    Else
                        If (pendSincupo(reader2("nit"), reader2("numero"), iva)) Then
                            ' If (True) Then
                            listaAnalisisCupo.Add(objAnalisisEn)
                        Else
                            listaAnalisisBueno.Add(objAnalisisEn)
                        End If

                    End If

                End If

            End If
        End While
        reader2.Close()
        conn2.Close()
        vec(0) = listaAnalisisBueno
        vec(1) = listaAnalisisCupo
        Return vec
    End Function
    Public Function listarBloq(ByVal min As Integer, ByVal max As Integer) As List(Of AnalisisEn)
        Dim criterioVendedor As String = ""
        criterioVendedor = " Ptes.vendedor>=" & min & " and Ptes.vendedor<=" & max & " "
        If (vendedores <> "") Then
            criterioVendedor &= " AND Ptes.vendedor in(" & vendedores & ") "
        End If
        Dim conn2 As New SqlConnection
        Dim comando As New SqlCommand
        Dim objConexion As New Conexion
        Dim reader2 As SqlDataReader
        Dim sql As String
        conn2 = objConexion.abrirConexion
        comando.CommandType = CommandType.Text
        comando.Connection = conn2

        sql = "SELECT  distinct Ptes.codigo,Ptes.fecha,Ptes. descripcion,Ptes.Pendiente,Ptes.KilosPendiente,Ptes.Valor_total,Ptes.notas AS NOTAS_PED ,Ptes.vendedor,Ptes.ciudad,Ptes.nit,Ptes.nombres,Ptes.bloqueo,Ptes.condicion AS Credito, Ptes.numero,Ptes.autorizacion ,nota_vta,notas5,ptes.Cant_pedida,ptes.valor_unitario,ptes.bodega FROM V_pendientes_por_vendedor Ptes , terceros cli where  " & criterioVendedor & "  and (ptes.autorizacion<>'s' and ptes.autorizacion<>'a' or ptes.autorizacion is null)  and ptes.bloqueo <>0 and cli.nit = Ptes.nit ORDER BY numero"
        comando.CommandText = sql
        reader2 = comando.ExecuteReader
        While reader2.Read
            If IsDBNull(reader2) Then
            Else
                objAnalisisEn = New AnalisisEn
                objAnalisisEn.fechaA = reader2("fecha")
                objAnalisisEn.codigoA = reader2("codigo")
                objAnalisisEn.descripcionA = reader2("descripcion")
                objAnalisisEn.pendienteA = reader2("Pendiente")
                objAnalisisEn.kilosA = reader2("KilosPendiente")
                objAnalisisEn.valTotA = reader2("Valor_total")
                objAnalisisEn.notasA = reader2("NOTAS_PED")
                objAnalisisEn.vendedorA = reader2("vendedor")
                objAnalisisEn.ciudadaA = reader2("ciudad")
                objAnalisisEn.nitA = reader2("nit")
                objAnalisisEn.nombresA = reader2("nombres")
                objAnalisisEn.bloqueoA = reader2("bloqueo")
                objAnalisisEn.creditoA = reader2("Credito")
                objAnalisisEn.Numero = reader2("numero")
                objAnalisisEn.aut = reader2("autorizacion")
                objAnalisisEn.notas_venta = reader2("nota_vta")
                objAnalisisEn.notas_prod = reader2("notas5")
                objAnalisisEn.bodega = reader2("bodega")
                objAnalisisEn.valor_unitario = reader2("valor_unitario")
                objAnalisisEn.Cant_pedida = reader2("Cant_pedida")
                listaAnalisisBloq.Add(objAnalisisEn)

            End If
        End While

        reader2.Close()
        conn2.Close()
        Return listaAnalisisBloq
    End Function
    Public Function listarDocVenc(ByVal min As Integer, ByVal max As Integer) As DataTable
        Dim criterioVendedor As String = ""
        criterioVendedor = " Ptes.vendedor>=" & min & " and Ptes.vendedor<=" & max & " "
        If (vendedores <> "") Then
            criterioVendedor &= " AND Ptes.vendedor in(" & vendedores & ") "
        End If
        Dim conn As New SqlConnection
        Dim sql As String = "SELECT distinct ptes.nit As nitA, ptes.numero As Numero,ptes.autorizacion as aut ,ptes.fecha As fechaA,Ptes.codigo as codigoA , ptes.descripcion As descripcionA,ptes.Pendiente As pendienteA,ptes.KilosPendiente as kilosA,ptes.Valor_total as valTotA,ptes.vendedor As vendedorA,ptes.ciudad,ptes.nombres As nombresA,ptes.bloqueo As bloqueoA,ptes.condicion AS creditoA,ptes.notas AS NOTAS_PED,nota_vta,notas5 As notasProd,ptes.Cant_pedida,ptes.valor_unitario,ptes.bodega " & _
                                       " from V_pendientes_por_vendedor  ptes,V_Doc_Vencidos doc_ven ,terceros cli " & _
                                        " WHERE ptes.bloqueo=0 and (ptes.autorizacion<>'s' and ptes.autorizacion<>'a' or ptes.autorizacion is null) and  " & criterioVendedor & " " & _
                                         " and doc_ven.Nit = ptes.nit  and doc_ven.Dias_Vencido >10 and cli.nit =ptes.nit " & _
                                          " ORDER BY ptes.numero "
        Dim objConexion As New Conexion
        conn = objConexion.abrirConexion
        Dim dt_doc_venc As New DataTable
        Dim DA As New SqlDataAdapter(sql, conn)
        DA.Fill(dt_doc_venc)
        conn.Close()
        Return dt_doc_venc
    End Function
    Public Function listar_No_Reflej(ByVal tipo As String) As DataTable
        Dim criterioVendedor As String = ""
        'criterioVendedor = " AND ped.vendedor>=1001 and ped.vendedor<=1099 "
        If (vendedores <> "") Then
            criterioVendedor &= " AND ped.vendedor in(" & vendedores & ") "
        End If
            Dim conn As New SqlConnection
            Dim comando As New SqlCommand
            Dim objConexion As New Conexion
            conn = objConexion.abrirConexion
            Dim dt As New DataTable
            Dim sql As String = ""
            tipo = Trim(tipo)
            'porc_util = (vrKilo - ctoKilo) / (vrKilo) * 100
            If (tipo = "CARTERA") Then
            sql = "SELECT lin.bodega,ped.autorizacion,ped.Problema,lin.precio_si_costo_cero AS p_min,ped.nit ,ped.vendedor,lin.numero as Numero,ter.nombres,ter.ciudad ,lin.codigo,ref.descripcion , lin.valor_unitario,(lin.valor_unitario * lin.cantidad ) As vr_total,ped.fecha ,lin.cantidad,ped.notas,ped.notas_aut ,ped.nota_vta ,notas5 As notas_prod " & _
                                     "FROM jjv_documentos_lin_ped lin, jjv_documentos_ped ped ,referencias ref , terceros ter " & _
                                          "WHERE lin.numero = ped.numero and ref.codigo = lin.codigo and ped.anulado =0 and ped.nit= ter.nit and ped.autorizacion ='X' " & _
                                                " ORDER BY lin.numero "
            Else
            sql = "SELECT lin.bodega,ped.autorizacion,ped.Problema,lin.precio_si_costo_cero AS p_min,((lin.valor_unitario-ref.costo_unitario)/lin.valor_unitario*100)As Rnt,ped.nit,ped.vendedor,lin.numero as Numero,ter.nombres,ter.ciudad ,lin.codigo,ref.descripcion , lin.valor_unitario,(lin.valor_unitario * lin.cantidad ) As vr_total,ped.fecha ,lin.cantidad,ped.notas,ped.notas_aut,ped.nota_vta,ped.notas5 As notas_prod   " & _
                                     "FROM jjv_documentos_lin_ped lin, jjv_documentos_ped ped ,referencias ref , terceros ter " & _
                                          "WHERE lin.numero = ped.numero and ref.codigo = lin.codigo and ped.anulado =0 and ped.nit= ter.nit " & criterioVendedor & " " & _
                                                " ORDER BY lin.numero "
            End If
            Dim DA As New SqlDataAdapter(sql, conn)
            DA.Fill(dt)
            conn.Close()
            Return dt
    End Function
    Public Function consultarStock(ByVal codigo As String) As String
        Dim conn As New SqlConnection
        Dim comando As New SqlCommand
        Dim objConexion As New Conexion
        conn = objConexion.abrirConexion()
        Dim reader2 As SqlDataReader
        Dim resp As String = ""
        'Try
        conn = objConexion.abrirConexion
        comando.CommandType = CommandType.Text
        comando.Connection = conn
        comando.CommandText = "SELECT stock,bodega " & _
                                    "FROM v_referencias_sto_hoy " & _
                                         "WHERE codigo = '" & codigo & "' and bodega in (3,7) "
        reader2 = comando.ExecuteReader
        While reader2.Read
            If IsDBNull(reader2) Then
            Else
                resp = resp & "Bodega " & reader2("bodega") & " = " & Convert.ToInt64(reader2("stock")) & vbCrLf
            End If
        End While

        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try
        conn.Close()
        Return resp
    End Function
    Public Function consultarCantPend(ByVal codigo As String) As Double
        Dim conn As New SqlConnection
        Dim comando As New SqlCommand
        Dim objConexion As New Conexion
        conn = objConexion.abrirConexion()
        Dim reader2 As SqlDataReader
        Dim resp As String = ""
        'Try
        conn = objConexion.abrirConexion
        comando.CommandType = CommandType.Text
        comando.Connection = conn
        comando.CommandText = "SELECT  (SUM(pend.Cant_pedida)-SUM(pend.cantidad_despachada ))As cantidad   " & _
                                    " FROM V_pendientes_por_vendedor pend " & _
                                            " WHERE  pend.codigo = '" & codigo & "'"
        reader2 = comando.ExecuteReader
        While reader2.Read
            If IsDBNull(reader2) Then
            Else
                resp = reader2("cantidad")
            End If
        End While

        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try
        conn.Close()
        Return resp
    End Function
    Public Function anular_no_reflej(ByVal numero As Integer) As Integer
        Dim conn As New SqlConnection
        Dim comando As New SqlCommand
        Dim objConexion As New Conexion
        Dim resp As Integer = 0
        'Try
        conn = objConexion.abrirConexion
        Dim comando1 As New System.Data.SqlClient.SqlCommand
        comando1.CommandType = System.Data.CommandType.Text
        comando1.Connection = conn
        Dim stringSql As String = "UPDATE JJV_documentos_ped SET anulado =  1 where numero = " & numero
        comando1.CommandText = stringSql
        resp = comando1.ExecuteNonQuery()
        'Catch ex As Exception
        '    MsgBox(ex.Message.ToString & "error")
        '    MsgBox("Error desde el updatre de autorizar")
        'Finally
        'End Try
        conn.Close()
        Return resp
    End Function
    Public Sub operaCupo(ByVal min As Integer, ByVal max As Integer, ByVal iva As Double)
        Dim conn2 As New SqlConnection
        Dim comando As New SqlCommand
        Dim objConexion As New Conexion
        Dim reader2 As SqlDataReader
        Dim nit As Integer
        Dim valPend As Double = 0
        Dim suma As Double = 0
        Dim vr_tot As Double = 0
        Dim saldo_tot As Double = 0
        Dim vecClien() As String = cargarClientes(min, max)
        For i = 0 To vecClien.Length
            If vecClien(i) > 0 Then
                nit = vecClien(i)
                conn2 = objConexion.abrirConexion
                comando.CommandType = CommandType.Text
                comando.Connection = conn2
                comando.CommandText = "select (select Saldo_Tot from  Jjv_Saldo_Sup_cupo_cred where Nit = " & nit & ")"
                reader2 = comando.ExecuteReader
                While reader2.Read
                    saldo_tot = reader2(0)
                End While
                vr_tot = objPendAd.sumValTot(nit, iva)
                suma = saldo_tot - vr_tot
                If (suma < 0) Then
                    'listarCupo(min, max, nit)
                End If
            End If

        Next
        conn2.Close()

    End Sub
    Public Function pendSincupo(ByVal nit As Integer, ByVal numero As Integer, ByVal iva As Double) As Boolean
        Dim conn2 As New SqlConnection
        Dim resp As Boolean = False
        Dim comando As New SqlCommand
        Dim objConexion As New Conexion
        Dim reader2 As SqlDataReader
        Dim cupo As Double = 0
        Dim vr_tot As Double = 0
        Dim cartera As Double = 0
        Dim sum As Double = 0
        Dim sql As String = "select (select cupo_credito  from terceros  where Nit = " & nit & "),(select SUm (saldo)  from V_cartera_edades_jjv   where Nit = " & nit & ")"
        conn2 = objConexion.abrirConexion
        comando.CommandType = CommandType.Text
        comando.Connection = conn2
        comando.CommandText = sql
        reader2 = comando.ExecuteReader
        If reader2.Read Then
            If IsDBNull(reader2(0)) Then
                cupo = 0
            Else
                cupo = reader2(0)
                'If (cupo <> 0) Then
                '    If (cupo >= 100000 And cupo <= 20000000) Then
                '        cupo = cupo * 1.3
                '    ElseIf (cupo >= 21000000 And cupo <= 40000000) Then
                '        cupo = cupo * 1.2
                '    ElseIf (cupo >= 41000000 And cupo <= 80000000) Then
                '        cupo = cupo * 1.1
                '    End If
                'End If
            End If
            If IsDBNull(reader2(1)) Then
                cartera = 0
            Else
                cartera = reader2(1)
            End If
        End If
        vr_tot = objPendAd.sumValTot(nit, iva)
        sum = cupo - cartera - vr_tot
        If (sum >= 0) Then
            resp = False
        Else
            resp = True
        End If
        conn2.Close()
        Return resp

    End Function
    Public Function cargarClientes(ByVal min As Integer, ByVal max As Integer) As String()
        Dim conn As New SqlConnection
        Dim comando As New SqlCommand
        Dim objConexion As New Conexion
        Dim reader As SqlDataReader
        Dim vecClien(200) As String
        Dim k As Double = 0
        Dim sql As String = "SELECT     nit FROM  V_pendientes_por_vendedor    where   (nit  not in (SELECT     nit FROM  V_Doc_Vencidos )) and (bloqueo=0 and autorizacion <>'s' and autorizacion <>'a') and( vendedor >=" & min & " and vendedor <=" & max & ") and (nit in (select nit from Jjv_Saldo_Sup_cupo_cred ))"
        comando.CommandType = CommandType.Text
        conn = objConexion.abrirConexion
        comando.Connection = conn
        comando.CommandText = (sql)
        reader = comando.ExecuteReader
        While (reader.Read)
            If IsDBNull(reader(0)) Then
            Else
                vecClien(k) = reader(0)
                k = k + 1
            End If
        End While
        conn.Close()
        Return vecClien
    End Function
    Public Sub autorizarPed(ByVal notas As String, ByVal numero As Integer)
        Dim conn As New SqlConnection
        Dim comando As New SqlCommand
        Dim objConexion As New Conexion
        Try
            conn = objConexion.abrirConexion
            Dim comando1 As New System.Data.SqlClient.SqlCommand
            comando1.CommandType = System.Data.CommandType.Text
            comando1.Connection = conn
            Dim stringSql As String = "UPDATE documentos_ped SET despacho = 'S' , autorizacion = 'S', autoriz_texto = '" & notas & "' where numero = " & numero & ""
            comando1.CommandText = stringSql
            comando1.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message.ToString & "error")
            MsgBox("ERROR DESDE EL UPDATE")
        Finally
        End Try
        conn.Close()
    End Sub
    Public Function sum_no_reflej(ByVal vend_min As Integer, ByVal vend_max As Integer, ByVal iva As Double) As Double
        Dim conn As New SqlConnection
        Dim comando As New SqlCommand
        Dim objConexion As New Conexion
        Dim reader As SqlDataReader
        Dim resp As Double = 0
        Dim sql As String = "Select  SUM (valor_total)  FROM JJV_documentos_ped WHERE anulado = 0 and vendedor >= " & vend_min & " and vendedor <= " & vend_max & ""
        comando.CommandType = CommandType.Text
        conn = objConexion.abrirConexion
        comando.Connection = conn
        comando.CommandText = (sql)
        reader = comando.ExecuteReader
        If (reader.Read) Then
            If IsDBNull(reader(0)) Then
            Else
                resp = (reader(0) / (iva + 1))
            End If
        End If
        conn.Close()
        Return resp
    End Function
    Public Function retornarBloq() As List(Of AnalisisEn)
        Return listaAnalisisBloq
    End Function
    Public Function retornarBueno() As List(Of AnalisisEn)
        Return listaAnalisisBueno
    End Function
    Public Function retornarCupo() As List(Of AnalisisEn)
        Return listaAnalisisCupo
    End Function
    Public Function retornarCupoYdocVenc() As List(Of AnalisisEn)
        Return listaCupoYdocVenc
    End Function
    Public Function ejecutar(ByVal sql As String) As Integer
        Dim resp As Integer = 0
        Dim conn As New SqlConnection
        Try
            Dim objConexion As New Conexion
            Dim comando1 As New System.Data.SqlClient.SqlCommand
            conn = objConexion.abrirConexion
            comando1.CommandType = System.Data.CommandType.Text
            comando1.Connection = conn
            comando1.CommandText = sql
            resp = (comando1.ExecuteNonQuery())
        Catch ex As Exception
            MsgBox(ex.Message.ToString & "error")
        Finally

        End Try
        conn.Close()
        Return resp
    End Function


End Class
