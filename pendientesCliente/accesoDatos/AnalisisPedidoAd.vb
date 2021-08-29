Imports System.Data.SqlClient
Imports System.Data
Imports entidadNegocios
Public Class AnalisisAd2
    '****************************************************************************************************************
    'Se crean los parametros para la conexion ***********************************************************************
    '****************************************************************************************************************
    Private conn As New SqlConnection
    Private conn2 As New SqlConnection
    Private comando As New SqlCommand
    Public listaAnalisisBloq As New List(Of AnalisisEn)

    Public listaAnalisisVenc As New List(Of AnalisisEn)
    Public listaAnalisisBueno As New List(Of AnalisisEn)
    Public listaAnalisisCupo As New List(Of AnalisisEn)
    Public listaCupoYdocVenc As New List(Of AnalisisEn)

    Dim objConexion As New Conexion
    Dim objAnalisisEn As AnalisisEn
    Dim objPendAd As New pendientesAd
    Public dt As DataTable
    Public dt2 As DataTable
    Public Sub LLenarTodo(ByVal min As Double, ByVal max As Double)
        listaAnalisisBloq = New List(Of AnalisisEn)
        listaAnalisisVenc = New List(Of AnalisisEn)
        listaAnalisisBueno = New List(Of AnalisisEn)
        listaAnalisisCupo = New List(Of AnalisisEn)
        listaCupoYdocVenc = New List(Of AnalisisEn)

        listarBuenos(min, max)
        listarBloq(min, max)
        'listarCupo(min, max)
        listarDocVenc(min, max)
    End Sub

    Public Sub listarBuenos(ByVal min As Integer, ByVal max As Integer)
        Dim reader2 As SqlDataReader
        Dim cont As Integer = 0
        conn2 = objConexion.abrirConexion2
        comando.CommandType = CommandType.Text
        comando.Connection = conn2

        comando.CommandText = "SELECT  distinct codigo,fecha, descripcion,Pendiente,KilosPendiente,Valor_total,notas AS NOTAS_PED ,vendedor,ciudad,nit,nombres,Promed_Dias_pago,bloqueo,condicion AS Credito,numero,autorizacion  from Jjv_Ptes_Con_Stock Ptes   where ((autorizacion = 's'or autorizacion = 'a' ) or  ((nit not in (SELECT     nit FROM  V_Doc_Vencidos  where vendedor>=" & min & " and vendedor<=" & max & " and Dias_Vencido >1 )) and (bloqueo =0 )))and  vendedor>=" & min & "	 and vendedor<=" & max & " ORDER BY nit,numero "
        'MsgBox("SELECT fecha, codigo,descripcion,Pendiente,KilosPendiente,stock,Valor_total,notas AS NOTAS_PED ,vendedor,ciudad,ptes.nit,nombres,Promed_Dias_pago,bloqueo,condicion AS Credito,numero,autorizacion  from Jjv_Ptes_Con_Stock Ptes   where ((autorizacion = 's'or autorizacion = 'a' ) or  ((nit not in (SELECT     nit FROM  V_Doc_Vencidos  where vendedor>=" & min & " and vendedor<=" & max & " and Dias_Vencido >1 )) and (bloqueo =0 )))and  vendedor>=" & min & "	 and vendedor<=" & max & "")
        reader2 = comando.ExecuteReader
        While reader2.Read
            If IsDBNull(reader2) Then
            Else

                objAnalisisEn = New AnalisisEn
                objAnalisisEn.fechaA = reader2(1)
                objAnalisisEn.codigoA = reader2(0)
                objAnalisisEn.descripcionA = reader2(2)
                objAnalisisEn.pendienteA = reader2(3)
                objAnalisisEn.kilosA = reader2(4)
                objAnalisisEn.valTotA = reader2(5)
                objAnalisisEn.notasA = reader2(6)
                objAnalisisEn.vendedorA = reader2(7)
                objAnalisisEn.ciudadaA = reader2(8)
                objAnalisisEn.nitA = reader2(9)
                objAnalisisEn.nombresA = reader2(10)
                objAnalisisEn.promDiasA = reader2(11)
                objAnalisisEn.bloqueoA = reader2(12)
                objAnalisisEn.creditoA = reader2(13)
                objAnalisisEn.Numero = reader2(14)
                objAnalisisEn.aut = reader2(15)
                If (IsDBNull(reader2(15))) Then
                    If (pendSincupo(reader2(9), reader2(14))) Then
                        listaAnalisisCupo.Add(objAnalisisEn)
                    Else
                        listaAnalisisBueno.Add(objAnalisisEn)
                    End If

                Else
                    If (reader2(15) = "S" Or reader2(15) = "A") Then
                        listaAnalisisBueno.Add(objAnalisisEn)
                    Else
                        If (pendSincupo(reader2(9), reader2(14))) Then
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
    End Sub
    Public Function listarBloq(ByVal min As Integer, ByVal max As Integer) As List(Of AnalisisEn)
        Dim reader2 As SqlDataReader
        Dim sql As String
        conn2 = objConexion.abrirConexion2
        comando.CommandType = CommandType.Text
        comando.Connection = conn2
        sql = "SELECT   distinct codigo,fecha, descripcion,Pendiente,KilosPendiente,Valor_total,notas AS NOTAS_PED ,vendedor,ciudad,nit,nombres,Promed_Dias_pago,bloqueo,condicion AS Credito,numero,autorizacion  from Jjv_Ptes_Con_Stock where  vendedor >=" & min & " and vendedor <=" & max & "  and (autorizacion<>'s' and autorizacion<>'a' or autorizacion is null)  and bloqueo <>0 ORDER BY numero"
        comando.CommandText = sql
        reader2 = comando.ExecuteReader
        While reader2.Read
            If IsDBNull(reader2) Then
            Else
                objAnalisisEn = New AnalisisEn
                objAnalisisEn.fechaA = reader2(1)
                objAnalisisEn.codigoA = reader2(0)
                objAnalisisEn.descripcionA = reader2(2)
                objAnalisisEn.pendienteA = reader2(3)
                objAnalisisEn.kilosA = reader2(4)
                objAnalisisEn.valTotA = reader2(5)
                objAnalisisEn.notasA = reader2(6)
                objAnalisisEn.vendedorA = reader2(7)
                objAnalisisEn.ciudadaA = reader2(8)
                objAnalisisEn.nitA = reader2(9)
                objAnalisisEn.nombresA = reader2(10)
                objAnalisisEn.promDiasA = reader2(11)
                objAnalisisEn.bloqueoA = reader2(12)
                objAnalisisEn.creditoA = reader2(13)
                objAnalisisEn.Numero = reader2(14)
                objAnalisisEn.aut = reader2(15)
                listaAnalisisBloq.Add(objAnalisisEn)

            End If
        End While

        reader2.Close()
        conn2.Close()
        Return listaAnalisisBloq
    End Function
    Public Function listarDocVenc(ByVal min As Integer, ByVal max As Integer) As List(Of AnalisisEn)
        Dim reader2 As SqlDataReader
        Try
            conn2 = objConexion.abrirConexion2
            comando.CommandType = CommandType.Text
            comando.Connection = conn2
            comando.CommandText = "SELECT   distinct ptes.codigo,ptes.fecha, ptes.descripcion,ptes.Pendiente,ptes.KilosPendiente,ptes.Valor_total,ptes.notas AS NOTAS_PED ,ptes.vendedor,ptes.ciudad,ptes.nit,ptes.nombres,ptes.Promed_Dias_pago,ptes.bloqueo,ptes.condicion AS Credito,ptes.numero,ptes.autorizacion " & _
                                        "from Jjv_Ptes_Con_Stock  ptes,V_Doc_Vencidos doc_ven " & _
                                                "WHERE ptes.bloqueo=0 and (ptes.autorizacion<>'s' and ptes.autorizacion<>'a' or ptes.autorizacion is null) and  ptes.vendedor >=" & min & "  and ptes.vendedor <=" & max & " " & _
                                                      "and doc_ven.Nit = ptes.nit  and doc_ven.Dias_Vencido >1 " & _
                                                            "ORDER BY ptes.numero "
            reader2 = comando.ExecuteReader
            While reader2.Read
                If IsDBNull(reader2) Then
                Else
                    objAnalisisEn = New AnalisisEn
                    objAnalisisEn.fechaA = reader2(1)
                    objAnalisisEn.codigoA = reader2(0)
                    objAnalisisEn.descripcionA = reader2(2)
                    objAnalisisEn.pendienteA = reader2(3)
                    objAnalisisEn.kilosA = reader2(4)
                    objAnalisisEn.valTotA = reader2(5)
                    objAnalisisEn.notasA = reader2(6)
                    objAnalisisEn.vendedorA = reader2(7)
                    objAnalisisEn.ciudadaA = reader2(8)
                    objAnalisisEn.nitA = reader2(9)
                    objAnalisisEn.nombresA = reader2(10)
                    objAnalisisEn.promDiasA = reader2(11)
                    objAnalisisEn.bloqueoA = reader2(12)
                    objAnalisisEn.creditoA = reader2(13)
                    objAnalisisEn.Numero = reader2(14)
                    objAnalisisEn.aut = reader2(15)
                    listaAnalisisVenc.Add(objAnalisisEn)
                    'listaCupoYdocVenc.Add(objAnalisisEn)

                End If
            End While

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return listaAnalisisVenc
    End Function
    Public Function listar_No_Reflej() As DataTable
        conn = objConexion.abrirConexion
        Dim dt As New DataTable
        Dim sql As String = "SELECT lin.bodega,ped.autorizacion,ped.nit,ped.vendedor,lin.numero,ter.nombres,ter.ciudad ,lin.codigo,ref.descripcion , lin.valor_unitario,ped.fecha ,lin.cantidad,ped.notas,ped.notas_aut   " & _
                                 "FROM jjv_documentos_lin_ped lin, jjv_documentos_ped ped ,referencias ref , terceros ter " & _
                                      "WHERE lin.numero = ped.numero and ref.codigo = lin.codigo and ped.anulado =0 and ped.nit= ter.nit " & _
                                            " ORDER BY lin.numero "
        Dim DA As New SqlDataAdapter(sql, conn)
        DA.Fill(dt)
        conn.Close()
        Return dt
    End Function
    Public Function anular_no_reflej(ByVal numero As Integer) As Integer
        Dim resp As Integer = 0
        Try
            conn = objConexion.abrirConexion
            Dim comando1 As New System.Data.SqlClient.SqlCommand
            comando1.CommandType = System.Data.CommandType.Text
            comando1.Connection = conn
            Dim stringSql As String = "UPDATE JJV_documentos_ped SET anulado =  1 where numero = " & numero
            comando1.CommandText = stringSql
            resp = comando1.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message.ToString & "error")
            MsgBox("Error desde el updatre de autorizar")
        Finally
        End Try
        conn.Close()
        Return resp
    End Function
    Public Sub operaCupo(ByVal min As Integer, ByVal max As Integer)
        Dim reader2 As SqlDataReader
        Dim nit As Integer
        Dim cupo As Double = 0
        Dim valPend As Double = 0
        Dim suma As Double = 0
        Dim vr_tot As Double = 0
        Dim saldo_tot As Double = 0
        Dim vecClien() As String = cargarClientes(min, max)

        For i = 0 To vecClien.Length
            If vecClien(i) > 0 Then
                nit = vecClien(i)
                conn2 = objConexion.abrirConexion2
                comando.CommandType = CommandType.Text
                comando.Connection = conn2
                comando.CommandText = "select (select Saldo_Tot from  Jjv_Saldo_Sup_cupo_cred where Nit = " & nit & ")"
                reader2 = comando.ExecuteReader
                While reader2.Read
                    saldo_tot = reader2(0)
                End While
                vr_tot = objPendAd.sumValTot(nit)
                suma = saldo_tot - vr_tot
                If (suma < 0) Then
                    'listarCupo(min, max, nit)
                End If
            End If

        Next


    End Sub
    Public Function pendSincupo(ByVal nit As Integer, ByVal numero As Integer) As Boolean
        Dim reader2 As SqlDataReader
        Dim cupo As Double = 0
        Dim vr_tot As Double = 0
        Dim cartera As Double = 0
        Dim sum As Double = 0
        conn2 = objConexion.abrirConexion2
        comando.CommandType = CommandType.Text
        comando.Connection = conn2
        comando.CommandText = "select (select avg (cupo_credito)*1.30   from Jjv_Ptes_Con_Stock  where Nit = " & nit & "),(select SUm (saldo)  from v_cartera_edades   where Nit = " & nit & ")"
        reader2 = comando.ExecuteReader
        If reader2.Read Then
            If IsDBNull(reader2(0)) Then
                cupo = 0
            Else
                cupo = reader2(0)
            End If
            If IsDBNull(reader2(1)) Then
                cartera = 0
            Else
                cartera = reader2(1)
            End If
        End If
        vr_tot = objPendAd.sumValTot(nit)
        sum = cupo - cartera - vr_tot
        If (sum > 0) Then
            Return False
        Else
            Return True
        End If
    End Function
    Public Function cargarClientes(ByVal min As Integer, ByVal max As Integer) As String()
        Dim reader As SqlDataReader
        Dim vecClien(200) As String
        Dim k As Double = 0
        comando.CommandType = CommandType.Text
        conn = objConexion.abrirConexion
        comando.Connection = conn
        comando.CommandText = ("SELECT     nit FROM  Jjv_Ptes_Con_Stock    where   (nit  not in (SELECT     nit FROM  V_Doc_Vencidos )) and (bloqueo=0 and autorizacion <>'s' and autorizacion <>'a') and( vendedor >=" & min & " and vendedor <=" & max & ") and (nit in (select nit from Jjv_Saldo_Sup_cupo_cred ))")
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
        Try
            conn = objConexion.abrirConexion
            Dim comando1 As New System.Data.SqlClient.SqlCommand
            comando1.CommandType = System.Data.CommandType.Text
            comando1.Connection = conn
            Dim stringSql As String = "UPDATE documentos_ped SET despacho = 'S' , autorizacion = 'S', notas = '" & notas & "' where numero = " & numero & ""
            comando1.CommandText = stringSql
            comando1.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message.ToString & "error")
            MsgBox("ERROR DESDE EL UPDATE")
        Finally
        End Try
        conn.Close()
    End Sub
    Public Function retornarBloq() As List(Of AnalisisEn)
        Return listaAnalisisBloq
    End Function
    Public Function retornarVenc() As List(Of AnalisisEn)
        Return listaAnalisisVenc
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


End Class
