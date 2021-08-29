Imports System.Data.SqlClient
Imports System.Data
Imports entidadNegocios
Public Class GenerarPresAd
    Private conn As New SqlConnection
    Private conn2 As New SqlConnection
    Private comando As New SqlCommand
    Dim objConexion As New Conexion
    Dim objGenerarPresEn As New GenerarPresEn
    Dim objTrazabilidadEn As New TrazabilidadEn


    Public Function listarGenpres(ByVal nit As Double, ByVal criterio As String) As List(Of GenerarPresEn)
        Dim reader2 As SqlDataReader
        Dim listaGenPres As New List(Of GenerarPresEn)
        Dim id_cor As Double
        Dim año As Double = Now.Year - 1
        Dim mes As Double = Now.Month
        'If (Now.Month = 12) Then
        '    mes = 1
        '    año = Now.Year
        'End If
        Dim mesAux As Double = mes
        Dim añoAux As Double = año
        Dim valAux As Double = 0
        Dim i As Double = 0
        Dim sql As String = " "
        Dim sum As Double = 0
        If Not (existeTazabilidad()) Then
            Dim vecVend As Integer() = vecVendedores(1001, 1099)
            For i = 0 To 99
                If (vecVend(i) > 0) Then
                    GenTrazMesPas(vecVend(i), vecVend(i))
                End If
            Next
            GenTrazMesPas(1001, 1099)
        End If
        For k = 1 To 27

            id_cor = k
            año = Now.Year - 1
            mes = Now.Month
            'If (Now.Month = 12) Then
            '    mes = 1
            '    año = Now.Year
            'End If
            i = 1
            objGenerarPresEn = New GenerarPresEn
            For i = 1 To 13
                Select Case id_cor
                    Case 1
                        objGenerarPresEn.Descripcion = "AL BRILL"
                    Case 2
                        objGenerarPresEn.Descripcion = "AL RECO"
                    Case 3
                        objGenerarPresEn.Descripcion = "AL ESPE"
                    Case 4
                        objGenerarPresEn.Descripcion = "VARILLAS"
                    Case 5
                        objGenerarPresEn.Descripcion = "AL PUAS"
                    Case 6
                        objGenerarPresEn.Descripcion = "AL GALV"
                    Case 7
                        objGenerarPresEn.Descripcion = "M. POLLO"
                    Case 8
                        objGenerarPresEn.Descripcion = "C.C 350-700"
                    Case 9
                        objGenerarPresEn.Descripcion = "C.C 400-800"
                    Case 10
                        objGenerarPresEn.Descripcion = "C.C 500-1000"
                    Case 11
                        objGenerarPresEn.Descripcion = "CL GRANEL"
                    Case 12
                        objGenerarPresEn.Descripcion = "CL VARETA"
                    Case 13
                        objGenerarPresEn.Descripcion = "CL ZINC"
                    Case 14
                        objGenerarPresEn.Descripcion = "HEL Y ANULA"
                    Case 15
                        objGenerarPresEn.Descripcion = "CL ELECTRO"
                    Case 16
                        objGenerarPresEn.Descripcion = "CL ACERO"
                    Case 17
                        objGenerarPresEn.Descripcion = "GRAPAS"
                    Case 18
                        objGenerarPresEn.Descripcion = "CL HERRAR"
                    Case 19
                        objGenerarPresEn.Descripcion = "TR ESTUFA"
                    Case 20
                        objGenerarPresEn.Descripcion = "TR LAMINA"
                    Case 21
                        objGenerarPresEn.Descripcion = "TR MADERA"
                    Case 22
                        objGenerarPresEn.Descripcion = "TR AGLOM"
                    Case 23
                        objGenerarPresEn.Descripcion = "TR CHAZO"
                    Case 24
                        objGenerarPresEn.Descripcion = "REMACHES"
                    Case 25
                        objGenerarPresEn.Descripcion = "CARRIAJE"
                    Case 26
                        objGenerarPresEn.Descripcion = "TR DRIWALL"
                    Case 27
                        objGenerarPresEn.Descripcion = "ARANDELA"
                End Select

                conn2 = objConexion.abrirConexion2
                comando.CommandType = CommandType.Text
                comando.Connection = conn2
              
                If (i = 13) Then
                    sql = "select sum (" & criterio & " ) from Jjv_V_vtas_vend_cliente_ref   where MONTH (fec)=" & Now.Month & " and YEAR (fec)=" & Now.Year & "  and vendedor = " & nit & "  and Id_cor = " & id_cor & " "

                Else
             
                    sql = "select " & criterio & "  from Jjv_his_vend   where MONTH (Fecha_trazab)=" & mes & " and YEAR (Fecha_trazab)=" & año & "  and vendedor = " & nit & "  and Id_cor = " & id_cor & " "
                End If


                comando.CommandText = sql
                reader2 = comando.ExecuteReader
                If (reader2.Read) Then
                    If IsDBNull(reader2(0)) Then
                    Else
                        sum = reader2(0)
                    End If
                End If
                reader2.Close()
                conn2.Close()
          

                If (sum <> 0) Then

                    Select Case i

                        Case 1
                            objGenerarPresEn.mes1 = sum
                        Case 2
                            objGenerarPresEn.mes2 = sum
                        Case 3
                            objGenerarPresEn.mes3 = sum
                        Case 4
                            objGenerarPresEn.mes4 = sum
                        Case 5
                            objGenerarPresEn.mes5 = sum
                        Case 6
                            objGenerarPresEn.mes6 = sum
                        Case 7
                            objGenerarPresEn.mes7 = sum
                        Case 8
                            objGenerarPresEn.mes8 = sum
                        Case 9
                            objGenerarPresEn.mes9 = sum
                        Case 10
                            objGenerarPresEn.mes10 = sum
                        Case 11
                            objGenerarPresEn.mes11 = sum
                        Case 12
                            objGenerarPresEn.mes12 = sum
                        Case 13
                            objGenerarPresEn.mes13 = sum
                    End Select
                End If

                reader2.Close()
                conn2.Close()
                sum = 0
                mes = mes + 1
                If (mes = 13) Then
                    mes = 1
                    año = Now.Year
                End If

            Next
            listaGenPres.Add(objGenerarPresEn)
        Next
        objGenerarPresEn = New GenerarPresEn
        objGenerarPresEn.Descripcion = "TOTAL"


        listaGenPres.Add(objGenerarPresEn)
        Return listaGenPres
    End Function

    Public Function cargarVendedores() As DataTable

        conn = objConexion.abrirConexion2
        Dim DA As New SqlDataAdapter("select vendedor FROM v_vendedores WHERE     (vendedor >= 1001) AND (vendedor <= 1099) AND (bloqueo = 0) ORDER BY vendedor", conn)
        Dim dt As New DataTable
        conn.Close()
        Return dt
    End Function
   
    Public Function nombreVendedor(ByVal vendedor As Integer) As String

        Dim nombre As String = ""
        Dim reader As SqlDataReader
        conn = objConexion.abrirConexion
        comando.Connection = conn
        comando.CommandType = CommandType.Text
        comando.CommandText = "select nombre_vendedor   FROM v_vendedores where vendedor = " & vendedor
        reader = comando.ExecuteReader
        If (reader.Read) Then
            nombre = reader(0)

        End If
        Return nombre
        conn.Close()

    End Function

    Public Function promPres(ByVal nit As Double, ByVal criterio As String, ByVal cantidadMeses As Double) As Double()
        Dim reader2 As SqlDataReader
        Dim año As Double = Now.Year - 1
        Dim mes As Double = Now.Month + 1
        If (Now.Month = 12) Then
            mes = 1
            año = Now.Year
        End If
        Dim sql As String = " "
        Dim sum As Double = 0
        Dim mesFin As Double
        Dim diaFin As Double
        Dim añoFin As Double
        Dim total As Double = 0
        Dim vecProm(27) As Double
        Select Case cantidadMeses
            Case 3
                Select Case Now.Month
                    Case 1
                        mes = 10
                        año = Now.Year - 1
                    Case 2
                        mes = 11
                        año = Now.Year - 1
                    Case 3
                        mes = 12
                        año = Now.Year - 1

                    Case Is > 3
                        mes = Now.Month - 3
                        año = Now.Year
                End Select
            Case 6
                Select Case Now.Month
                    Case 1
                        mes = 7
                        año = Now.Year - 1
                    Case 2
                        mes = 8
                        año = Now.Year - 1
                    Case 3
                        mes = 9
                        año = Now.Year - 1
                    Case 4
                        mes = 10
                        año = Now.Year - 1
                    Case 5
                        mes = 11
                        año = Now.Year - 1
                    Case 6
                        mes = 12
                        año = Now.Year - 1
                    Case Is > 6
                        mes = Now.Month - 6
                        año = Now.Year
                End Select
            Case 12
                mes = Now.Month
                año = Now.Year - 1
        End Select
        mesFin = Now.Month - 1
        añoFin = Now.Year
        diaFin = 31
        If (mesFin = 0) Then
            mesFin = 12
            añoFin = Now.Year - 1
        End If
        If (mesFin = 2) Then
            diaFin = 28
        End If
        If (mesFin = 4 Or mesFin = 6 Or mesFin = 9 Or mesFin = 11) Then
            diaFin = 30
        End If
        For i = 1 To 27
            conn2 = objConexion.abrirConexion2
            comando.CommandType = CommandType.Text
            comando.Connection = conn2
            sql = "select sum (" & criterio & " ) from Jjv_V_vtas_vend_cliente_ref   where fec>= '" & año & "-" & mes & "-01' and  fec<= '" & añoFin & "-" & mesFin & "-" & diaFin & "'  and vendedor = " & nit & " and Id_cor = " & i & "   "
            comando.CommandText = sql
            reader2 = comando.ExecuteReader
            If (reader2.Read) Then
                If IsDBNull(reader2(0)) Then
                Else
                    sum = reader2(0)
                End If
            End If
            conn2.Close()
            
            total = sum

            If (total <> 0) Then
                vecProm(i) = CInt(total / cantidadMeses)
            Else
                vecProm(i) = 0
            End If
            total = 0
            sum = 0
        Next
        conn2.Close()
        Return vecProm
    End Function
    Public Sub insertarPres(ByVal fechaPres As String, ByVal nit As Double, ByVal id_cor As Double, ByVal ppto_kilos As Double, ByVal vr_tot As Double, ByVal vr_kilo As Double, ByVal cto_kilo As Double, ByVal porc_util As Double, ByVal dias_habil As Double, ByVal cto_tot As Double)
        Try
            conn = objConexion.abrirConexion
            Dim comando1 As New System.Data.SqlClient.SqlCommand
            comando1.CommandType = System.Data.CommandType.Text
            comando1.Connection = conn

            Dim stringSql As String = "insert into Jjv_ppto_mes ( Fecha_ppto, Vendedor, Id_cor, Ppto_kilos, Vr_total, Vr_kilo, Cto_kilo, Porc_util, Fecha_mod1, Dias_habil, Cto_total) values ('" & fechaPres & "'," & nit & "," & id_cor & "," & ppto_kilos & "," & vr_tot & "," & vr_kilo & "," & cto_kilo & "," & porc_util & ",GETDATE()," & dias_habil & "," & cto_tot & ")"
            comando1.CommandText = stringSql
            comando1.ExecuteNonQuery()


        Catch ex As Exception
            MsgBox("insert into Jjv_ppto_mes ( Fecha_ppto, Vendedor, Id_cor, Ppto_kilos, Vr_total, Vr_kilo, Cto_kilo, Porc_util, Fecha_mod1, Dias_habil, Cto_total) values ('" & fechaPres & "'," & nit & "," & id_cor & "," & ppto_kilos & "," & vr_tot & "," & vr_kilo & "," & cto_kilo & "," & porc_util & ",GETDATE()," & dias_habil & "," & cto_tot & ")")
            MsgBox(ex.Message.ToString & "error")

        Finally

        End Try
        conn.Close()
    End Sub

    Public Function consultarPres(ByVal fecha As String, ByVal vendedor As Integer) As Object
        Dim pres(27, 9) As Object
        Dim i As Integer = 0
        Dim sw As Boolean = False
        Dim reader As SqlDataReader
        Dim fec As Date
        conn = objConexion.abrirConexion
        comando.Connection = conn
        comando.CommandType = CommandType.Text
        comando.CommandText = "select Fecha_ppto,Ppto_kilos,Vr_total,Cto_total,Vr_kilo,Cto_kilo,Porc_util,Fecha_mod1,Dias_habil  from Jjv_ppto_mes where Fecha_ppto= '" & fecha & "' and Vendedor  = " & vendedor & ""
        reader = comando.ExecuteReader
        While reader.Read
            If IsDBNull(reader(0)) Then
            Else
                sw = True
                fec = (reader(0))

                pres(i, 1) = fec.Year & "-" & fec.Month & "- 01"
                pres(i, 2) = reader(1)
                pres(i, 3) = reader(2)
                pres(i, 4) = reader(3)
                pres(i, 5) = reader(4)
                pres(i, 6) = reader(5)
                pres(i, 7) = reader(6)
                pres(i, 8) = reader(7)
                pres(i, 9) = reader(8)
                i += 1

            End If
        End While
        If (sw = False) Then
            MsgBox("no se encontro presupuesto de el vendedor: " & vendedor & "en el mes: " & fecha)
            'para saber en el formulario que la matiz no contiene datos
            pres(0, 0) = -1
        End If
        conn.Close()
        Return pres

    End Function
    Public Function consulPttoTodos(ByVal fecha As String) As Object
        Dim pres(26, 1) As Object
        Dim i As Integer = 0
        Dim sql As String
        Dim reader As SqlDataReader
        conn = objConexion.abrirConexion
        comando.Connection = conn
        comando.CommandType = CommandType.Text
        sql = "select Ppto_kilos,Vr_total	from Jjv_ppto_mes  where Vendedor= 10011099 and Fecha_ppto  = '" & fecha & "'"
        comando.CommandText = sql

        reader = comando.ExecuteReader
        While reader.Read
            If IsDBNull(reader(0)) Then
            Else

                pres(i, 0) = reader(0)
                pres(i, 1) = reader(1)
                i += 1

            End If
        End While
       
        conn.Close()
        Return pres

    End Function
    Public Function consultStock() As Double()
        Dim stock(27) As Double
        Dim i As Integer = 0
        Dim reader As SqlDataReader
        conn = objConexion.abrirConexion
        comando.Connection = conn
        comando.CommandType = CommandType.Text
        comando.CommandText = "select SUM(stock ), Id_cor from v_referencias_sto_hoy where  bodega in (3,7)and Id_cor is not null  group  by Id_cor"
        reader = comando.ExecuteReader
        While reader.Read
            If IsDBNull(reader(0)) Then
            Else

                stock(i) = reader(0)
                i += 1

            End If
        End While

        conn.Close()
        Return stock
    End Function
    Public Function existePres(ByVal fecha As String, ByVal vendedor As Integer) As Boolean

        Dim sw As Boolean = False
        Dim reader As SqlDataReader
        conn = objConexion.abrirConexion
        comando.Connection = conn
        comando.CommandType = CommandType.Text
        comando.CommandText = "select vendedor  from Jjv_ppto_mes where Fecha_ppto= '" & fecha & "' and Vendedor  = " & vendedor & ""
        reader = comando.ExecuteReader
        If (reader.Read) Then
            Return True
        Else
            Return False
        End If
        conn.Close()

    End Function

    Public Sub eliminarPres(ByVal fecha As String, ByVal vendedor As Integer)
        conn = objConexion.abrirConexion
        Dim comando1 As New System.Data.SqlClient.SqlCommand
        comando1.CommandType = System.Data.CommandType.Text
        comando1.Connection = conn
        Dim stringSql As String = "delete   from Jjv_ppto_mes where  Fecha_ppto= '" & fecha & "' and Vendedor  = " & vendedor & ""
        comando1.CommandText = stringSql
        comando1.ExecuteNonQuery()


    End Sub
    Public Function consultDiasHabil(ByVal año As Integer, ByVal mes As Integer) As Integer
        Dim resp As Integer = 0
        Dim reader As SqlDataReader
        conn = objConexion.abrirConexion
        comando.Connection = conn
        comando.CommandType = CommandType.Text
        comando.CommandText = "select Dias_habil  from Jjv_dias_habiles  where ano = " & año & " and Mes =" & mes
        reader = comando.ExecuteReader
        If (reader.Read) Then
            resp = reader(0)
     
        End If
        conn.Close()
        Return resp
    End Function

    Public Function listarGenpresTodos(ByVal min As Double, ByVal max As Double, ByVal criterio As String) As List(Of GenerarPresEn)
        Dim reader2 As SqlDataReader
        Dim listaGenPres As New List(Of GenerarPresEn)
        Dim id_cor As Double
        Dim año As Double = Now.Year - 1
        Dim mes As Double = Now.Month + 1
        'If (Now.Month = 12) Then
        '    mes = 1
        '    año = Now.Year
        'End If
        Dim mesAux As Double = mes
        Dim añoAux As Double = año
        Dim valAux As Double = 0
        Dim i As Double = 0
        Dim sql As String = " "
        Dim sum As Double = 0
        If Not (existeTazabilidad()) Then
            Dim vecVend As Integer() = vecVendedores(1001, 1099)
            For i = 0 To 99
                If (vecVend(i) > 0) Then
                    GenTrazMesPas(vecVend(i), vecVend(i))
                End If
            Next
            GenTrazMesPas(1001, 1099)
        End If

        For k = 1 To 27

            id_cor = k
            año = Now.Year - 1
            mes = Now.Month
            'If (Now.Month = 12) Then
            '    mes = 1
            '    año = Now.Year
            'End If
            i = 1
            objGenerarPresEn = New GenerarPresEn
            For i = 1 To 13
                Select Case id_cor
                    Case 1
                        objGenerarPresEn.Descripcion = "AL BRILL"
                    Case 2
                        objGenerarPresEn.Descripcion = "AL RECO"
                    Case 3
                        objGenerarPresEn.Descripcion = "AL ESPE"
                    Case 4
                        objGenerarPresEn.Descripcion = "VARILLAS"
                    Case 5
                        objGenerarPresEn.Descripcion = "AL PUAS"
                    Case 6
                        objGenerarPresEn.Descripcion = "AL GALV"
                    Case 7
                        objGenerarPresEn.Descripcion = "M. POLLO"
                    Case 8
                        objGenerarPresEn.Descripcion = "C.C 350-700"
                    Case 9
                        objGenerarPresEn.Descripcion = "C.C 400-800"
                    Case 10
                        objGenerarPresEn.Descripcion = "C.C 500-1000"
                    Case 11
                        objGenerarPresEn.Descripcion = "CL GRANEL"
                    Case 12
                        objGenerarPresEn.Descripcion = "CL VARETA"
                    Case 13
                        objGenerarPresEn.Descripcion = "CL ZINC"
                    Case 14
                        objGenerarPresEn.Descripcion = "HEL Y ANULA"
                    Case 15
                        objGenerarPresEn.Descripcion = "CL ELECTRO"
                    Case 16
                        objGenerarPresEn.Descripcion = "CL ACERO"
                    Case 17
                        objGenerarPresEn.Descripcion = "GRAPAS"
                    Case 18
                        objGenerarPresEn.Descripcion = "CL HERRAR"
                    Case 19
                        objGenerarPresEn.Descripcion = "TR ESTUFA"
                    Case 20
                        objGenerarPresEn.Descripcion = "TR LAMINA"
                    Case 21
                        objGenerarPresEn.Descripcion = "TR MADERA"
                    Case 22
                        objGenerarPresEn.Descripcion = "TR AGLOM"
                    Case 23
                        objGenerarPresEn.Descripcion = "TR CHAZO"
                    Case 24
                        objGenerarPresEn.Descripcion = "REMACHES"
                    Case 25
                        objGenerarPresEn.Descripcion = "CARRIAJE"
                    Case 26
                        objGenerarPresEn.Descripcion = "TR DRIWALL"
                    Case 27
                        objGenerarPresEn.Descripcion = "ARANDELA"
                End Select

                conn2 = objConexion.abrirConexion2
                comando.CommandType = CommandType.Text
                comando.Connection = conn2
                If (i = 13) Then
                    sql = "select SUM(" & criterio & ") from Jjv_V_vtas_vend_cliente_ref  where MONTH (fec)=" & mes & " and YEAR (fec)=" & año & "  and vendedor >= " & min & " and vendedor<= " & max & " and Id_cor = " & id_cor & " "
                Else
                    sql = "select SUM(" & criterio & ") from Jjv_his_vend   where MONTH (Fecha_trazab)=" & mes & " and YEAR (Fecha_trazab)=" & año & "  and vendedor >= " & min & " and vendedor<= " & max & " and Id_cor = " & id_cor & " "
                End If
                comando.CommandText = sql
                reader2 = comando.ExecuteReader
                If (reader2.Read) Then
                    If IsDBNull(reader2(0)) Then
                    Else
                        sum = reader2(0)
                    End If
                End If
                reader2.Close()
                conn2.Close()


                If (sum <> 0) Then

                    Select Case i

                        Case 1
                            objGenerarPresEn.mes1 = sum
                        Case 2
                            objGenerarPresEn.mes2 = sum
                        Case 3
                            objGenerarPresEn.mes3 = sum
                        Case 4
                            objGenerarPresEn.mes4 = sum
                        Case 5
                            objGenerarPresEn.mes5 = sum
                        Case 6
                            objGenerarPresEn.mes6 = sum
                        Case 7
                            objGenerarPresEn.mes7 = sum
                        Case 8
                            objGenerarPresEn.mes8 = sum
                        Case 9
                            objGenerarPresEn.mes9 = sum
                        Case 10
                            objGenerarPresEn.mes10 = sum
                        Case 11
                            objGenerarPresEn.mes11 = sum
                        Case 12
                            objGenerarPresEn.mes12 = sum
                        Case 13
                            objGenerarPresEn.mes13 = sum
                    End Select
                End If
                reader2.Close()
                conn2.Close()
                sum = 0
                mes = mes + 1
                If (mes = 13) Then
                    mes = 1
                    año = Now.Year
                End If
            Next
            listaGenPres.Add(objGenerarPresEn)
        Next
        objGenerarPresEn = New GenerarPresEn
        objGenerarPresEn.Descripcion = "TOTAL"


        listaGenPres.Add(objGenerarPresEn)
        Return listaGenPres
    End Function
    'Public Sub genTrazMesPasado(ByVal min As Double, ByVal max As Double, ByVal criterio As String)
    '    Dim reader2 As SqlDataReader
    '    Dim listaGenPres As New List(Of TrazabilidadEn)
    '    Dim id_cor As Double
    '    Dim año As Double = Now.Year
    '    Dim mes As Double = Now.Month - 1
    '    If (Now.Month = 1) Then
    '        mes = 12
    '        año = Now.Year - 1
    '    End If
    '    Dim i As Double = 0
    '    Dim sql As String = " "
    '    Dim sum As Double = 0

    '    Dim kilos As Double = 0
    '    Dim pesos As Double = 0
    '    Dim cto_tot As Double = 0
    '    Dim fecha As String = "" & año & "-" & mes & "-01"
    '    Dim vendedor As Integer = 0
    '    If (min = max) Then
    '        vendedor = min
    '    Else
    '        vendedor = 10011099
    '    End If
    '    For k = 1 To 27
    '        id_cor = k

    '        i = 1
    '        objGenerarPresEn = New GenerarPresEn
    '        conn2 = objConexion.abrirConexion2
    '        comando.CommandType = CommandType.Text
    '        comando.Connection = conn2
    '        sql = "select sum (kilos ),sum (Vr_total),sum (Cto_total  ) from Jjv_V_vtas_vend_cliente_ref   where MONTH (fec)=" & mes & " and YEAR (fec)=" & año & "  and vendedor >= " & min & " and vendedor<= " & max & " and Id_cor = " & id_cor & " "
    '        comando.CommandText = sql
    '        reader2 = comando.ExecuteReader
    '        If (reader2.Read) Then
    '            If IsDBNull(reader2(0)) Then
    '            Else
    '                objTrazabilidadEn.kilos = reader2(0)
    '                objTrazabilidadEn.pesos = reader2(1)
    '                objTrazabilidadEn.cto_tot = reader2(2)
    '                objTrazabilidadEn.fecha = fecha
    '                objTrazabilidadEn.vendedor = vendedor
    '                objTrazabilidadEn.id_cor = id_cor

    '            End If
    '        End If
    '        If (objTrazabilidadEn.kilos = 0) Then
    '            objTrazabilidadEn.kilos = 0
    '            objTrazabilidadEn.pesos = 0
    '            objTrazabilidadEn.cto_tot = 0
    '            objTrazabilidadEn.fecha = ""
    '            objTrazabilidadEn.vendedor = vendedor
    '            objTrazabilidadEn.id_cor = id_cor
    '        End If

    '        reader2.Close()
    '        conn2.Close()
    '        insertTrazabilidad(objTrazabilidadEn)
    '        kilos = 0
    '        pesos = 0
    '        cto_tot = 0
    '        listaGenPres.Add(objTrazabilidadEn)
    '        objTrazabilidadEn = New TrazabilidadEn
    '    Next


    '    listaGenPres.Add(objTrazabilidadEn)
    'End Sub
    Public Sub trazTodos()
        Dim vecVend As Integer() = vecVendedores(1001, 1099)
        For i = 0 To 99
            If (vecVend(i) > 0) Then
                listarGenTazCu(vecVend(i), vecVend(i))
            End If
        Next
        listarGenTazCu(1001, 1099)
    End Sub
    Public Function listarGenTazCu(ByVal min As Integer, ByVal max As Integer) As List(Of TrazabilidadEn)
        Dim reader2 As SqlDataReader
        Dim listaGenPres As New List(Of TrazabilidadEn)
        Dim id_cor As Double
        Dim año As Double = Now.Year
        Dim mes As Double = Now.Month - 1
        If (Now.Month = 1) Then
            mes = 12
            año = Now.Year - 1
        End If
        Dim i As Double = 0
        Dim sql As String = " "
        Dim sum As Double = 0
        Dim kilos As Double = 0
        Dim pesos As Double = 0
        Dim cto_tot As Double = 0
        Dim fecha As String = "" & año & "-" & mes & "-01"
        Dim vendedor As Integer = 0
        If (min = max) Then
            vendedor = min
        Else
            vendedor = min & max
        End If

        For i = 1 To 12

            For k = 1 To 27
                id_cor = k

                'i = 1
                objGenerarPresEn = New GenerarPresEn
                conn2 = objConexion.abrirConexion2
                comando.CommandType = CommandType.Text
                comando.Connection = conn2
                sql = "select sum (kilos ),sum (Vr_total),sum (Cto_total  ) from Jjv_V_vtas_vend_cliente_ref   where MONTH (fec)=" & mes & " and YEAR (fec)=" & año & "  and vendedor >= " & min & " and <= " & max & " and Id_cor = " & id_cor & " "
                comando.CommandText = sql
                reader2 = comando.ExecuteReader
                If (reader2.Read) Then
                    If IsDBNull(reader2(0)) Then
                    Else
                        objTrazabilidadEn.kilos = reader2(0)
                        objTrazabilidadEn.pesos = reader2(1)
                        objTrazabilidadEn.cto_tot = reader2(2)
                        objTrazabilidadEn.fecha = "" & año & " - " & mes & " - 1"
                        objTrazabilidadEn.vendedor = vendedor
                        objTrazabilidadEn.id_cor = id_cor

                    End If
                End If
                If (objTrazabilidadEn.kilos = 0) Then
                    objTrazabilidadEn.kilos = 0
                    objTrazabilidadEn.pesos = 0
                    objTrazabilidadEn.cto_tot = 0
                    objTrazabilidadEn.fecha = "" & año & " - " & mes & " - 1"
                    objTrazabilidadEn.vendedor = vendedor
                    objTrazabilidadEn.id_cor = id_cor
                End If

                reader2.Close()
                conn2.Close()
                insertTrazabilidad(objTrazabilidadEn)
                kilos = 0
                pesos = 0
                cto_tot = 0
                'listaGenPres.Add(objTrazabilidadEn)
                objTrazabilidadEn = New TrazabilidadEn
            Next
            mes = mes - 1
            If (mes = 0) Then
                mes = 12
                año = año - 1
            End If
        Next

        ' listaGenPres.Add(objTrazabilidadEn)
        Return listaGenPres
    End Function
    Public Sub GenTrazMesPas(ByVal min As Integer, ByVal max As Integer)
        Dim reader2 As SqlDataReader
        Dim listaGenPres As New List(Of TrazabilidadEn)
        Dim id_cor As Double
        Dim año As Double = Now.Year
        Dim mes As Double = Now.Month - 1
        If (Now.Month = 1) Then
            mes = 12
            año = Now.Year - 1
        End If
        Dim i As Double = 0
        Dim sql As String = " "
        Dim sum As Double = 0
        Dim kilos As Double = 0
        Dim pesos As Double = 0
        Dim cto_tot As Double = 0
        Dim fecha As String = "" & año & "-" & mes & "-01"
        Dim vendedor As Integer = 0
        If (min = max) Then
            vendedor = min
        Else
            vendedor = min & max
        End If

        For k = 1 To 27
            id_cor = k

            'i = 1
            objGenerarPresEn = New GenerarPresEn
            conn2 = objConexion.abrirConexion2
            comando.CommandType = CommandType.Text
            comando.Connection = conn2
            sql = "select sum (kilos ),sum (Vr_total),sum (Cto_total  ) from Jjv_V_vtas_vend_cliente_ref   where MONTH (fec)=" & mes & " and YEAR (fec)=" & año & "  and vendedor >= " & min & " and vendedor <= " & max & " and Id_cor = " & id_cor & " "
            comando.CommandText = sql
            reader2 = comando.ExecuteReader
            If (reader2.Read) Then
                If IsDBNull(reader2(0)) Then
                Else
                    objTrazabilidadEn.kilos = reader2(0)
                    objTrazabilidadEn.pesos = reader2(1)
                    objTrazabilidadEn.cto_tot = reader2(2)
                    objTrazabilidadEn.fecha = "" & año & " - " & mes & " - 1"
                    objTrazabilidadEn.vendedor = vendedor
                    objTrazabilidadEn.id_cor = id_cor

                End If
            End If
            If (objTrazabilidadEn.kilos = 0) Then
                objTrazabilidadEn.kilos = 0
                objTrazabilidadEn.pesos = 0
                objTrazabilidadEn.cto_tot = 0
                objTrazabilidadEn.fecha = "" & año & " - " & mes & " - 1"
                objTrazabilidadEn.vendedor = vendedor
                objTrazabilidadEn.id_cor = id_cor
            End If

            reader2.Close()
            conn2.Close()
            insertTrazabilidad(objTrazabilidadEn)
            kilos = 0
            pesos = 0
            cto_tot = 0

            objTrazabilidadEn = New TrazabilidadEn
        Next

    End Sub

    Public Function promPresTodos(ByVal vendMin As Integer, ByVal vendMax As Integer, ByVal criterio As String, ByVal cantidadMeses As Double) As Double()
        Dim reader2 As SqlDataReader
        Dim año As Double = Now.Year - 1
        Dim mes As Double = Now.Month + 1
        If (Now.Month = 12) Then
            mes = 1
            año = Now.Year
        End If
        Dim sql As String = " "
        Dim mesFin As Double
        Dim diaFin As Double
        Dim añoFin As Double
        Dim total As Double = 0
        Dim vecProm(27) As Double
        Select Case cantidadMeses
            Case 3
                Select Case Now.Month
                    Case 1
                        mes = 10
                        año = Now.Year - 1
                    Case 2
                        mes = 11
                        año = Now.Year - 1
                    Case 3
                        mes = 12
                        año = Now.Year - 1

                    Case Is > 3
                        mes = Now.Month - 3
                        año = Now.Year
                End Select
            Case 6
                Select Case Now.Month
                    Case 1
                        mes = 7
                        año = Now.Year - 1
                    Case 2
                        mes = 8
                        año = Now.Year - 1
                    Case 3
                        mes = 9
                        año = Now.Year - 1
                    Case 4
                        mes = 10
                        año = Now.Year - 1
                    Case 5
                        mes = 11
                        año = Now.Year - 1
                    Case 6
                        mes = 12
                        año = Now.Year - 1
                    Case Is > 6
                        mes = Now.Month - 6
                        año = Now.Year
                End Select
            Case 12
                mes = Now.Month
                año = Now.Year - 1
        End Select
        mesFin = Now.Month - 1
        añoFin = Now.Year
        diaFin = 31
        If (mesFin = 0) Then
            mesFin = 12
            añoFin = Now.Year - 1
        End If
        If (mesFin = 2) Then
            diaFin = 28
        End If
        If (mesFin = 4 Or mesFin = 6 Or mesFin = 9 Or mesFin = 11) Then
            diaFin = 30
        End If
        For i = 1 To 27
            conn2 = objConexion.abrirConexion2
            comando.CommandType = CommandType.Text
            comando.Connection = conn2
            sql = "select SUM (" & criterio & "/" & cantidadMeses & ")   from Jjv_his_vend where vendedor >=" & vendMin & " and vendedor<=" & vendMax & " and Id_cor=" & i & " and Fecha_trazab>= '" & año & "-" & mes & "-01' and  Fecha_trazab<= '" & añoFin & "-" & mesFin & "-" & diaFin & "'"
            comando.CommandText = sql
            reader2 = comando.ExecuteReader
            If (reader2.Read) Then
                If IsDBNull(reader2(0)) Then
                Else
                    total = reader2(0)
                End If
            End If
            conn2.Close()
            If (total <> 0) Then
                vecProm(i) = total
            Else
                vecProm(i) = 0
            End If
            total = 0
        Next
        conn2.Close()
        Return vecProm
    End Function



    Public Sub GenerarPresupuestoTodos(ByVal vendMin As Integer, ByVal vendMax As Integer, ByVal fecha As Date, ByVal cantidadMeses As Double)
        Dim reader2 As SqlDataReader
        Dim año As Double = Now.Year - 1
        Dim mes As Double = Now.Month + 1
        If (Now.Month = 12) Then
            mes = 1
            año = Now.Year
        End If
        Dim sql As String = " "
        Dim mesFin As Double
        Dim diaFin As Double
        Dim añoFin As Double
        Dim total As Double = 0
        Dim vecVend() As Integer = vecVendedores(vendMin, vendMax)


        Dim StringFechaPpto = fecha.Year & "-" & fecha.Month & "-01"

        Dim vendedor As Integer
        Dim id_cor As Integer
        Dim pptoKilos As Double
        Dim vr_tot As Double
        Dim vrKilo As Double
        Dim ctoKilo As Double
        Dim porc_util As Double
        Dim fechaMod As String
        Dim diasHabil As Integer
        Dim ctoTot As Double
        If Not (existeTazabilidad()) Then
            Dim vecVend2 As Integer() = vecVendedores(1001, 1099)
            For i = 0 To 99
                If (vecVend(i) > 0) Then
                    GenTrazMesPas(vecVend2(i), vecVend2(i))
                End If
            Next
            GenTrazMesPas(1001, 1099)
        End If

        Select Case cantidadMeses
            Case 3
                Select Case Now.Month
                    Case 1
                        mes = 10
                        año = Now.Year - 1
                    Case 2
                        mes = 11
                        año = Now.Year - 1
                    Case 3
                        mes = 12
                        año = Now.Year - 1

                    Case Is > 3
                        mes = Now.Month - 3
                        año = Now.Year
                End Select
            Case 6
                Select Case Now.Month
                    Case 1
                        mes = 7
                        año = Now.Year - 1
                    Case 2
                        mes = 8
                        año = Now.Year - 1
                    Case 3
                        mes = 9
                        año = Now.Year - 1
                    Case 4
                        mes = 10
                        año = Now.Year - 1
                    Case 5
                        mes = 11
                        año = Now.Year - 1
                    Case 6
                        mes = 12
                        año = Now.Year - 1
                    Case Is > 6
                        mes = Now.Month - 6
                        año = Now.Year
                End Select
            Case 12
                mes = Now.Month
                año = Now.Year - 1
        End Select
        mesFin = Now.Month - 1
        añoFin = Now.Year
        diaFin = 31
        If (mesFin = 0) Then
            mesFin = 12
            añoFin = Now.Year - 1
        End If
        If (mesFin = 2) Then
            diaFin = 28
        End If
        If (mesFin = 4 Or mesFin = 6 Or mesFin = 9 Or mesFin = 11) Then
            diaFin = 30
        End If
        diasHabil = consultDiasHabil(fecha.Year, fecha.Month)
        For k = 0 To 99
            If (existePres(StringFechaPpto, vecVend(k))) Then
                eliminarPres(StringFechaPpto, vecVend(k))
            End If
            If (vecVend(k) > 0) Then

                For i = 1 To 27


                    vendedor = vecVend(k)
                    id_cor = i
                    fechaMod = Now.Date


                    conn2 = objConexion.abrirConexion2
                    comando.CommandType = CommandType.Text
                    comando.Connection = conn2
                    sql = "select sum (kilos)/" & cantidadMeses & ",sum (Vr_total)/" & cantidadMeses & ",sum (Cto_total)/" & cantidadMeses & "   from Jjv_V_vtas_vend_cliente_ref where vendedor =" & vendedor & " and Id_cor=" & id_cor & " and fec>= '" & año & "-" & mes & "-01' and  fec<= '" & añoFin & "-" & mesFin & "-" & diaFin & "'"
                    comando.CommandText = sql
                    reader2 = comando.ExecuteReader
                    If (reader2.Read) Then
                        If IsDBNull(reader2(0)) Or IsDBNull(reader2(1)) Or IsDBNull(reader2(2)) Then
                        Else
                            If (reader2(0) <= 0 Or reader2(1) <= 0 Or reader2(2) <= 0) Then
                            Else
                                pptoKilos = reader2(0)
                                vr_tot = reader2(1)
                                ctoTot = reader2(2)
                                ctoKilo = ctoTot / pptoKilos
                                vrKilo = vr_tot / pptoKilos
                                porc_util = (vrKilo - ctoKilo) / (vrKilo) * 100

                            End If

                        End If
                    End If
                    conn2.Close()

                    insertarPres(StringFechaPpto, vendedor, id_cor, pptoKilos, vr_tot, vrKilo, ctoKilo, porc_util, diasHabil, ctoTot)

                    vendedor = 0
                    id_cor = 0
                    fechaMod = Now.Date
                    pptoKilos = 0
                    vr_tot = 0
                    ctoTot = 0
                    ctoKilo = 0
                    vrKilo = 0
                    porc_util = 0
                Next
                conn2.Close()





            End If
        Next
        If (vendMin <> vendMax) Then
            vendedor = 10011099
            If (existePres(StringFechaPpto, vendedor)) Then
                eliminarPres(StringFechaPpto, vendedor)
            End If
            For i = 1 To 27
                id_cor = i
                conn2 = objConexion.abrirConexion2
                comando.CommandType = CommandType.Text
                comando.Connection = conn2
                sql = "select sum (kilos)/" & cantidadMeses & ",sum (Vr_total)/" & cantidadMeses & ",sum (Cto_total)/" & cantidadMeses & "   from Jjv_V_vtas_vend_cliente_ref where vendedor >=" & vendMin & " and vendedor <= " & vendMax & "and Id_cor=" & id_cor & " and fec>= '" & año & "-" & mes & "-01' and  fec<= '" & añoFin & "-" & mesFin & "-" & diaFin & "'"
                comando.CommandText = sql
                reader2 = comando.ExecuteReader
                If (reader2.Read) Then
                    If IsDBNull(reader2(0)) Or IsDBNull(reader2(1)) Or IsDBNull(reader2(2)) Then
                    Else
                        If (reader2(0) <= 0 Or reader2(1) <= 0 Or reader2(2) <= 0) Then
                        Else
                            pptoKilos = reader2(0)
                            vr_tot = reader2(1)
                            ctoTot = reader2(2)
                            ctoKilo = ctoTot / pptoKilos
                            vrKilo = vr_tot / pptoKilos
                            porc_util = (vrKilo - ctoKilo) / (vrKilo) * 100

                        End If
                    End If
                End If
                insertarPres(StringFechaPpto, vendedor, id_cor, pptoKilos, vr_tot, vrKilo, ctoKilo, porc_util, diasHabil, ctoTot)
                id_cor = 0
                fechaMod = Now.Date
                pptoKilos = 0
                vr_tot = 0
                ctoTot = 0
                ctoKilo = 0
                vrKilo = 0
                porc_util = 0
                conn2.Close()

            Next

        End If


    End Sub
    Public Function vecVendedores(ByVal vendMin As Integer, ByVal vendMax As Integer) As Integer()
        Dim reader As SqlDataReader
        Dim vecVend(99) As Integer
        Dim k As Double = 0
        comando.CommandType = CommandType.Text
        conn = objConexion.abrirConexion
        comando.Connection = conn
        comando.CommandText = ("select vendedor FROM v_vendedores WHERE     (vendedor >= " & vendMin & ") AND (vendedor <= " & vendMax & ") AND (bloqueo = 0) ORDER BY vendedor")
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

    Public Function valTotTodosIdCor(ByVal cantidadMeses As Double) As Double()
        Dim reader2 As SqlDataReader
        Dim año As Double = Now.Year - 1
        Dim mes As Double = Now.Month + 1
        If (Now.Month = 12) Then
            mes = 1
            año = Now.Year
        End If
        Dim sql As String = " "
        Dim mesFin As Double
        Dim diaFin As Double
        Dim añoFin As Double
        Dim total As Double = 0
        Dim vecProm(27) As Double
        Select Case cantidadMeses
            Case 3
                Select Case Now.Month
                    Case 1
                        mes = 10
                        año = Now.Year - 1
                    Case 2
                        mes = 11
                        año = Now.Year - 1
                    Case 3
                        mes = 12
                        año = Now.Year - 1

                    Case Is > 3
                        mes = Now.Month - 3
                        año = Now.Year
                End Select
            Case 6
                Select Case Now.Month
                    Case 1
                        mes = 7
                        año = Now.Year - 1
                    Case 2
                        mes = 8
                        año = Now.Year - 1
                    Case 3
                        mes = 9
                        año = Now.Year - 1
                    Case 4
                        mes = 10
                        año = Now.Year - 1
                    Case 5
                        mes = 11
                        año = Now.Year - 1
                    Case 6
                        mes = 12
                        año = Now.Year - 1
                    Case Is > 6
                        mes = Now.Month - 6
                        año = Now.Year
                End Select
            Case 12
                mes = Now.Month
                año = Now.Year - 1
        End Select
        mesFin = Now.Month - 1
        añoFin = Now.Year
        diaFin = 31
        If (mesFin = 0) Then
            mesFin = 12
            añoFin = Now.Year - 1
        End If
        If (mesFin = 2) Then
            diaFin = 28
        End If
        If (mesFin = 4 Or mesFin = 6 Or mesFin = 9 Or mesFin = 11) Then
            diaFin = 30
        End If
        For i = 1 To 27
            conn2 = objConexion.abrirConexion2
            comando.CommandType = CommandType.Text
            comando.Connection = conn2
            sql = "select sum (Vr_total )/ " & cantidadMeses & "   from Jjv_V_vtas_vend_cliente_ref where vendedor >=1001 and vendedor<=1099 and Id_cor=" & i & "  and fec>= '" & año & "-" & mes & "-01' and  fec<= '" & añoFin & "-" & mesFin & "-" & diaFin & "'"
            comando.CommandText = sql
            reader2 = comando.ExecuteReader
            If (reader2.Read) Then
                If IsDBNull(reader2(0)) Then
                Else
                    total = reader2(0)
                End If
            End If
            conn2.Close()
            If (total > 0) Then
                vecProm(i) = total
            Else
                vecProm(i) = 0
            End If
            total = 0
        Next
        conn2.Close()
        Return vecProm
    End Function

    'Consultar presupuesto kilos para sacar % de cumplimiento

    Public Function consultarPptoKilos(ByVal vendedor As Integer) As Double()
        Dim reader2 As SqlDataReader

        Dim sql As String = " "
        Dim fecha As String = Now.Year & "-" & Now.Month & "-01"
        Dim total As Double
        Dim vecPpto(27) As Double

        For i = 1 To 27
            conn2 = objConexion.abrirConexion2
            comando.CommandType = CommandType.Text
            comando.Connection = conn2
            sql = "select Ppto_kilos  from Jjv_Ppto_mes  where Vendedor= " & vendedor & " and Fecha_ppto = ' " & fecha & " ' and Id_cor =" & i & ""
            comando.CommandText = sql
            reader2 = comando.ExecuteReader
            If (reader2.Read) Then
                If IsDBNull(reader2(0)) Then
                Else
                    total = reader2(0)
                End If
            End If
            conn2.Close()
            If (total <> 0) Then
                vecPpto(i) = total
            Else
                vecPpto(i) = 0
            End If
            total = 0
        Next
        conn2.Close()
        Return vecPpto
    End Function


    'Consultar Ventas mes actual por id_cor para calcular % de cumplimiento

    Public Function consultarVtaMesId_cor(ByVal vendedor As Integer) As Double()
        Dim reader2 As SqlDataReader

        Dim sql As String = " "
        Dim mes As Integer = Now.Month
        Dim año As Integer = Now.Year
        Dim total As Double
        Dim vecVtaKilos(27) As Double

        For i = 1 To 27
            conn2 = objConexion.abrirConexion2
            comando.CommandType = CommandType.Text
            comando.Connection = conn2
            sql = "select SUM (kilos) from Jjv_his_vend where vendedor = " & vendedor & " and MONTH (Fecha_trazab)=" & mes & " and YEAR (Fecha_trazab)=" & año & " and Id_cor=" & i & ""
            comando.CommandText = sql
            reader2 = comando.ExecuteReader
            If (reader2.Read) Then
                If IsDBNull(reader2(0)) Then
                Else
                    total = reader2(0)
                End If
            End If
            conn2.Close()
            If (total <> 0) Then
                vecVtaKilos(i) = total
            Else
                vecVtaKilos(i) = 0
            End If
            total = 0
        Next
        conn2.Close()
        Return vecVtaKilos
    End Function

    Public Function ejmGraftica() As DataTable
        conn = objConexion.abrirConexion
        Dim dt As New DataTable
        Dim DA As New SqlDataAdapter("select Vendedor , Cto_total  from Jjv_Ppto_mes  where vendedor =1002", conn)
        DA.Fill(dt)
        conn.Close()
        Return dt
    End Function

    Public Sub insertTrazabilidad(ByVal objTrazabilidad As TrazabilidadEn)
        Try
            conn = objConexion.abrirConexion
            Dim comando As New System.Data.SqlClient.SqlCommand
            comando.CommandType = System.Data.CommandType.Text
            comando.Connection = conn

            Dim stringSql As String = "insert into Jjv_his_vend (Fecha_trazab,Id_cor,Vendedor ,Kilos , Vr_total ,Cto_total)	values ('" & objTrazabilidadEn.fecha & "'," & objTrazabilidadEn.id_cor & "," & objTrazabilidadEn.vendedor & "," & objTrazabilidadEn.kilos & "," & objTrazabilidadEn.pesos & "," & objTrazabilidadEn.cto_tot & ")"
            comando.CommandText = stringSql
            comando.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox(ex.Message.ToString & "error")

        Finally

        End Try
        conn.Close()
    End Sub

    Public Function existeTazabilidad() As Boolean
        Dim reader As SqlDataReader
        Dim sql As String = ""
        Dim fecha As String = "" & Now.Year & "-" & Now.Month - 1 & "-01"
        Dim resp As Boolean = False
        conn = objConexion.abrirConexion
        comando.CommandType = CommandType.Text
        comando.Connection = conn
        sql = "select Fecha_trazab  from Jjv_his_vend where Fecha_trazab = '" & fecha & "'"
        comando.CommandText = sql
        reader = comando.ExecuteReader
        If (reader.Read) Then
            If IsDBNull(reader(0)) Then
            Else
                resp = True
            End If
        End If
        Return resp
        conn2.Close()

    End Function
    Public Sub cerrarPres(ByVal fecha As String)
        Try
            conn = objConexion.abrirConexion
            Dim comando1 As New System.Data.SqlClient.SqlCommand
            comando1.CommandType = System.Data.CommandType.Text
            comando1.Connection = conn
            Dim stringSql As String = "UPDATE  Jjv_ppto_mes SET  Ppto_cerrado =1 WHERE Fecha_ppto  = '" & fecha & "'"
            comando1.CommandText = stringSql
            comando1.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message.ToString & "error")

        Finally
        End Try
        conn.Close()
    End Sub
    Public Function consultarCerrado(ByVal fec As String) As Boolean
        Dim reader As SqlDataReader
        Dim sql As String = ""
        Dim resp As Boolean = False
        Try
            conn = objConexion.abrirConexion
            comando.CommandType = CommandType.Text
            comando.Connection = conn
            sql = "SELECT Ppto_cerrado FROM Jjv_ppto_mes  WHERE  Fecha_ppto  = '" & fec & "' GROUP BY Ppto_cerrado "
            comando.CommandText = sql
            reader = comando.ExecuteReader
            If (reader.Read) Then
                If IsDBNull(reader(0)) Then
                Else
                    resp = reader(0)
                End If
            End If
        Catch ex As ApplicationException
            MsgBox(ex.Message)
        End Try

        Return resp
        conn2.Close()

    End Function

    Public Function listarPresGeneral(ByVal fec As String) As List(Of GenerarPresEn)
        Dim listaGenPres As New List(Of GenerarPresEn)
        Dim reader As SqlDataReader
        Dim sql As String = ""
        Try
            conn = objConexion.abrirConexion
            comando.CommandType = CommandType.Text
            comando.Connection = conn
            sql = "select  Ppto_kilos ,Vr_total ,Cto_total,Vr_kilo,Porc_util,Cto_kilo,Dias_habil   from Jjv_ppto_mes where Vendedor = 10011099 and Fecha_ppto = '" & fec & "'"
            comando.CommandText = sql
            reader = comando.ExecuteReader
            While (reader.Read)
                If IsDBNull(reader(0)) Then
                Else
                    objGenerarPresEn = New GenerarPresEn
                    objGenerarPresEn.Ppto_Kilos = reader(0)
                    objGenerarPresEn.Vr_total = reader(1)
                    objGenerarPresEn.Cto_total = reader(2)
                    objGenerarPresEn.Vr_kilo = reader(3)
                    objGenerarPresEn.Porc_util = reader(4)
                    objGenerarPresEn.Cto_kilo = reader(5)
                    objGenerarPresEn.Dias_habil = reader(6)


                    listaGenPres.Add(objGenerarPresEn)
                End If
            End While
        Catch ex As ApplicationException
            MsgBox(ex.Message)
        End Try
        conn2.Close()
        Return listaGenPres
    End Function


End Class
