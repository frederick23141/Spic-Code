Imports System.Data.SqlClient
Imports System.Data
Imports entidadNegocios
Public Class Ppto_recaudoAd
    Private conn As New SqlConnection
    Private conn2 As New SqlConnection
    Private comando As New SqlCommand
    Private objConexion As New Conexion
    Private objPpto_recaudoEn As New Ppto_recaudoEn
    Private objDtallePptoRecEn As New DtallePptoRecEn

    Public Function listarPptoRec(ByVal fechaRec As String) As List(Of Ppto_recaudoEn)
        Dim listaPpto_recaudoEn As New List(Of Ppto_recaudoEn)
        Dim vecVend() As Integer = vendedores()
        Dim vendedor As Integer = 0
        Dim dias As Integer = 0
        Dim dPptoCalc As Double = 0

        If (Now.Month = 4 Or Now.Month = 6 Or Now.Month = 9 Or Now.Month = 11) Then
            dias = 30 - Now.Day + 1
        Else
            dias = 31 - Now.Day + 1
        End If
        If (Now.Month = 2) Then
            dias = 28 - Now.Day + 1
        End If


        For i = 0 To 99
            If (vecVend(i) > 0) Then
                vendedor = vecVend(i)
                dPptoCalc = calcularPptoRecCalc(vendedor, dias)
                If dPptoCalc > 0 Then
                    objPpto_recaudoEn = New Ppto_recaudoEn
                    objPpto_recaudoEn.Vendedor = vendedor
                    objPpto_recaudoEn.Nombres = nombVendedor(vendedor)
                    objPpto_recaudoEn.FechaPpto = fechaRec
                    objPpto_recaudoEn.Ppto_calculado = dPptoCalc
                    objPpto_recaudoEn.Ppto_client_contado = calcularPptoCont(vendedor)
                    objPpto_recaudoEn.Total = objPpto_recaudoEn.Ppto_calculado + objPpto_recaudoEn.Ppto_client_contado
                    objPpto_recaudoEn.TotClienCont = contClienContado(vendedor)
                    objPpto_recaudoEn.FecMod = Now.Date

                    listaPpto_recaudoEn.Add(objPpto_recaudoEn)
                End If
            End If
        Next
        objPpto_recaudoEn = New Ppto_recaudoEn
        objPpto_recaudoEn.Nombres = "TOTALES"
        listaPpto_recaudoEn.Add(objPpto_recaudoEn)
        Return listaPpto_recaudoEn
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
    Private Function nombVendedor(ByVal vendedor As Integer) As String
        Dim reader As SqlDataReader
        Dim nombre As String = ""
        Dim sSql As String = ""
        comando.CommandType = CommandType.Text
        conn = objConexion.abrirConexion
        comando.Connection = conn
        sSql = "select  nombre_vendedor " & _
                    " from v_vendedores " & _
                           "where vendedor=" & vendedor & ""
        comando.CommandText = (sSql)
        reader = comando.ExecuteReader
        While (reader.Read)
            If IsDBNull(reader(0)) Then
            Else
                nombre = reader(0)
            End If
        End While
        conn.Close()
        Return nombre
    End Function
    Private Function calcularPptoRecCalc(ByVal vendedor As Integer, ByVal dias As Integer) As Double
        Dim pptoCalc As Double
        Dim reader As SqlDataReader
        Dim sSql As String = ""
        comando.CommandType = CommandType.Text
        conn = objConexion.abrirConexion
        comando.Connection = conn
        sSql = "select SUM (saldo) " & _
                      "from V_CARTERA_EDADES " & _
                            " WHERE     (Saldo <> 0) AND (Vendedor = " & vendedor & ") AND Dias_Vencido >= -" & dias & " "
        comando.CommandText = (sSql)
        reader = comando.ExecuteReader
        While (reader.Read)
            If IsDBNull(reader(0)) Then
            Else
                pptoCalc = reader(0)
            End If
        End While
        conn.Close()
        Return pptoCalc
    End Function
    Private Function calcularPptoCont(ByVal vendedor As Integer) As Double
        Dim pptoCalc As Double
        Dim fecha As String = Now.Year & "-" & Now.Month - 5 & "-01"
        Dim sSql As String = ""

        Dim reader As SqlDataReader
        comando.CommandType = CommandType.Text
        conn = objConexion.abrirConexion
        comando.Connection = conn
        sSql = "select SUM (Vr_total ) /6 " & _
                      "from Jjv_V_vtas_vend_cliente_ref " & _
                        "  WHERE     (Vr_total <> 0) AND (Vendedor = " & vendedor & ") AND (condicion=201) AND (fec >='" & fecha & "') "
        comando.CommandText = (sSql)
        reader = comando.ExecuteReader
        While (reader.Read)
            If IsDBNull(reader(0)) Then
            Else
                pptoCalc = reader(0)
            End If
        End While
        conn.Close()
        Return pptoCalc
    End Function
    Private Function contClienContado(ByVal vendedor As Integer) As Double

        Dim fecha As String = Now.Year & "-" & Now.Month - 5 & "-01"
        Dim sSql As String = ""
        Dim cont As Integer = 0

        Dim reader As SqlDataReader
        comando.CommandType = CommandType.Text
        conn = objConexion.abrirConexion
        comando.Connection = conn
        sSql = "select   COUNT (nit ) " & _
                      "from Jjv_V_vtas_vend_cliente_ref " & _
                            "WHERE     (Vr_total <> 0) AND (Vendedor = " & vendedor & ") AND (condicion=201) AND (fec >='" & fecha & "')group by nit "
        comando.CommandText = (sSql)
        reader = comando.ExecuteReader
        While (reader.Read)
            If IsDBNull(reader(0)) Then
            Else
                cont += 1
            End If
        End While
        conn.Close()
        Return cont
    End Function

    Public Function listaDtalleVend(ByVal vendedor As Integer) As DataTable
        Dim fecha As String = Now.Year & "-" & Now.Month - 5 & "-01"
        Dim sSql As String = ""
        Dim dias As Integer = 0

        If (Now.Month = 4 Or Now.Month = 6 Or Now.Month = 9 Or Now.Month = 11) Then
            dias = 30 - Now.Day + 1
        Else
            dias = 31 - Now.Day + 1
        End If
        If (Now.Month = 2) Then
            dias = 28 - Now.Day + 1
        End If
        sSql = " select vendedor,(nombres)as Nombres,(Dias_Vencido)as D_venc,(Sin_Vencer)as Sin_venc,de_1_a_30,de_31_a_60,de_61_a_90,de_91_a_120,Mas_de_120 " & _
                       "from Jjv_cartera_edades_Cliente " & _
                            " WHERE     (Saldo <> 0) AND (Vendedor = " & vendedor & ") AND Dias_Vencido >= -" & dias & ""
        conn = objConexion.abrirConexion
        Dim dt As New DataTable
        Dim DA As New SqlDataAdapter(sSql, conn)
        DA.Fill(dt)
        conn.Close()
        Return dt
    End Function

    Public Function listarDtallePpto() As List(Of DtallePptoRecEn)
        Dim listaDtallePpto As New List(Of DtallePptoRecEn)
        Dim vecVend() As Integer = vendedores()
        Dim vendedor As Integer = 0
        Dim dias As Integer = 0
        Dim fecha As Date
        Dim mes As Integer
        Dim año As Integer
        fecha = DateAdd("m", -5, Now.Year & "-" & Now.Month & "-01")
        mes = fecha.Month
        año = fecha.Year
        If (Now.Month = 4 Or Now.Month = 6 Or Now.Month = 9 Or Now.Month = 11) Then
            dias = 30 - Now.Day + 1
        Else
            dias = 31 - Now.Day + 1
        End If
        If (Now.Month = 2) Then
            dias = 28 - Now.Day + 1
        End If
        For i = 0 To 99
            If (vecVend(i) > 0) Then
                objDtallePptoRecEn = New DtallePptoRecEn
                vendedor = vecVend(i)

                objDtallePptoRecEn.Mes1 = vtasContMesVend(vendedor, mes, año)
                objDtallePptoRecEn.Mes2 = vtasContMesVend(vendedor, mes + 1, año)
                objDtallePptoRecEn.Mes3 = vtasContMesVend(vendedor, mes + 2, año)
                objDtallePptoRecEn.Mes4 = vtasContMesVend(vendedor, mes + 3, año)
                objDtallePptoRecEn.Mes5 = vtasContMesVend(vendedor, mes + 4, año)
                objDtallePptoRecEn.Mes6 = vtasContMesVend(vendedor, mes + 5, año)
                If (objDtallePptoRecEn.Mes1 = 0 And objDtallePptoRecEn.Mes2 = 0 And objDtallePptoRecEn.Mes3 = 0 And objDtallePptoRecEn.Mes4 = 0 And objDtallePptoRecEn.Mes5 = 0 And objDtallePptoRecEn.Mes6 = 0) Then
                Else

                    objDtallePptoRecEn.Vendedor = vendedor
                    llenarDatosCartera(objDtallePptoRecEn, vendedor)
                    listaDtallePpto.Add(objDtallePptoRecEn)
                End If

            End If
        Next
        objDtallePptoRecEn = New DtallePptoRecEn
        listaDtallePpto.Add(objDtallePptoRecEn)
        Return listaDtallePpto
    End Function

    Private Function llenarDatosCartera(ByVal objDtallePptoRecEn As DtallePptoRecEn, ByVal vendedor As Integer) As DtallePptoRecEn

        Dim fecha As String = Now.Year & "-" & Now.Month - 5 & "-01"
        Dim sSql As String = ""
        Dim dias As Integer = 0

        If (Now.Month = 4 Or Now.Month = 6 Or Now.Month = 9 Or Now.Month = 11) Then
            dias = 30 - Now.Day + 1
        Else
            dias = 31 - Now.Day + 1
        End If
        If (Now.Month = 2) Then
            dias = 28 - Now.Day + 1
        End If

        Dim reader As SqlDataReader
        comando.CommandType = CommandType.Text
        conn = objConexion.abrirConexion
        comando.Connection = conn
        sSql = "select Sum (Sin_Vencer) as Sin_Vencer, Sum (de_1_a_30 ) as de_1_a_30,Sum (de_31_a_60  ) as de_31_a_60,Sum (de_61_a_90   ) as de_61_a_90, Sum (de_91_a_120   ) as de_91_a_120,Sum (Mas_de_120) as Mas_de_120 " & _
                    " from V_CARTERA_EDADES " & _
                            "WHERE     (Saldo <> 0) AND (Vendedor = " & vendedor & ") AND Dias_Vencido >= -" & dias & ""
        comando.CommandText = (sSql)
        reader = comando.ExecuteReader
        While (reader.Read)
            If IsDBNull(reader(0)) Then
            Else
                objDtallePptoRecEn.Sin_vencer = reader(0)
                objDtallePptoRecEn.De_1_a_30 = reader(1)
                objDtallePptoRecEn.De_31_a_60 = reader(2)
                objDtallePptoRecEn.De_61_a_90 = reader(3)
                objDtallePptoRecEn.De_91_a_120 = reader(4)
                objDtallePptoRecEn.Mas_120 = reader(5)

            End If
        End While
        conn.Close()
        Return objDtallePptoRecEn
    End Function

    Private Function vtasContMesVend(ByVal vendedor As Integer, ByVal mes As Integer, ByVal año As Integer) As Double
        If (mes > 12) Then
            año += 1
            mes = mes - 12
        End If
        Dim total As Double = 0
        Dim sSql As String
        Dim reader As SqlDataReader
        comando.CommandType = CommandType.Text
        conn = objConexion.abrirConexion
        comando.Connection = conn
        sSql = "select SUM (Vr_total )  " & _
                            "from Jjv_V_vtas_vend_cliente_ref " & _
                                "  WHERE     (Vr_total <> 0) AND (Vendedor = " & vendedor & ") AND (condicion=201) AND (MONTH (fec)=" & mes & " and YEAR (fec)=" & año & ")"
        comando.CommandText = (sSql)
        reader = comando.ExecuteReader
        While (reader.Read)
            If IsDBNull(reader(0)) Then
            Else
                total = reader(0)

            End If
        End While
        conn.Close()
        Return total
    End Function
    Public Sub insertarPres(ByVal fechaPres As Date, ByVal vendedor As Double, ByVal nombre As String, ByVal ppto_rec As Double, ByVal ppto_clien_cont As Double, ByVal pptoTot As Double, ByVal totClienCont As Integer)
        Dim mes As String = fechaPres.Month
        Dim año As String = fechaPres.Year
        Try

            conn = objConexion.abrirConexion
            Dim comando1 As New System.Data.SqlClient.SqlCommand
            comando1.CommandType = System.Data.CommandType.Text
            comando1.Connection = conn
            Dim sSql As String
            sSql = " insert into Jjv_ppto_vtas_recaudos_consol " & _
                                "values (" & año & "," & mes & "," & vendedor & ",'" & nombre & "'," & 0 & "," & ppto_rec & ",GETDATE()," & ppto_clien_cont & "," & pptoTot & "," & totClienCont & ")"
            Dim stringSql As String = sSql
            comando1.CommandText = stringSql
            comando1.ExecuteNonQuery()


        Catch ex As Exception
            MsgBox(" insert into Jjv_ppto_vtas_recaudos_consol values (" & año & "," & mes & "," & vendedor & ",'" & nombre & "'," & 0 & "," & ppto_rec & ",GETDATE()," & ppto_clien_cont & "," & pptoTot & "," & totClienCont & ")")
            MsgBox(ex.Message.ToString & "error")

        Finally

        End Try
        conn.Close()
    End Sub
    Public Function listarConsulta(ByVal año As Integer, ByVal mes As Integer) As List(Of Ppto_recaudoEn)
        Dim listaPpto_recaudoEn As New List(Of Ppto_recaudoEn)
        Dim reader As SqlDataReader
        Dim SSql As String
        Dim fechaRec As String = año & "-" & mes & "-1"
        Dim fecMod As Date
        comando.CommandType = CommandType.Text
        conn = objConexion.abrirConexion
        comando.Connection = conn
        SSql = "select Nit,Vendedor,Fecha_mod_ppto_rec,Ppto_calculado,Ppto_client_contado,Ppto_total,TotClientCont ,Fecha_mod_ppto_rec " & _
                        "from Jjv_ppto_vtas_recaudos_consol " & _
                                "where Mes = " & mes & " and Año = " & año & ""
        comando.CommandText = (sSql)
        reader = comando.ExecuteReader
        While (reader.Read)
            If IsDBNull(reader(0)) Then
            Else
                objPpto_recaudoEn = New Ppto_recaudoEn

                objPpto_recaudoEn.Vendedor = reader(0)
                objPpto_recaudoEn.Nombres = reader(1)
                objPpto_recaudoEn.FechaPpto = fechaRec
                objPpto_recaudoEn.Ppto_calculado = reader(3)
                objPpto_recaudoEn.Ppto_client_contado = reader(4)
                objPpto_recaudoEn.Total = reader(5)
                objPpto_recaudoEn.TotClienCont = reader(6)
                fecMod = reader(7)
                objPpto_recaudoEn.FecMod = fecMod.Year & "-" & fecMod.Month & "-" & fecMod.Day

                listaPpto_recaudoEn.Add(objPpto_recaudoEn)

            End If
        End While
        conn.Close()
        objPpto_recaudoEn = New Ppto_recaudoEn
        objPpto_recaudoEn.Nombres = "TOTAL"
        listaPpto_recaudoEn.Add(objPpto_recaudoEn)
        Return listaPpto_recaudoEn

    End Function
    Public Sub eliminarPres(ByVal año As Integer, ByVal mes As Integer)
        conn = objConexion.abrirConexion
        Dim comando1 As New System.Data.SqlClient.SqlCommand
        comando1.CommandType = System.Data.CommandType.Text
        comando1.Connection = conn
        Dim stringSql As String = "delete  from Jjv_ppto_vtas_recaudos_consol " & _
                                                "where  Año =" & año & " and Mes = " & mes & ""
        comando1.CommandText = stringSql
        comando1.ExecuteNonQuery()
    End Sub
    Public Function existePresRec(ByVal año As Integer, ByVal mes As Integer) As Boolean
        Dim reader As SqlDataReader
        comando.CommandType = CommandType.Text
        conn = objConexion.abrirConexion
        comando.Connection = conn
        comando.CommandText = "SELECT nit FROM Jjv_ppto_vtas_recaudos_consol " & _
            " where  Año =" & año & " and Mes =" & mes & ""
        reader = comando.ExecuteReader
        If (reader.Read) Then
            conn.Close()
            Return True
        End If
        Return False
    End Function


End Class
