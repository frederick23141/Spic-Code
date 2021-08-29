Imports System.Data.SqlClient
Imports System.Data
Imports entidadNegocios

Public Class AnalisisPresAd
    Private conn As New SqlConnection
    Private conn2 As New SqlConnection
    Private comando As New SqlCommand
    Dim objConexion As New Conexion
    Dim objAnalisisPresEn As New AnalisisPresEn

   
    Public Function listarAnalisisPres2(ByVal min As Double, ByVal max As Double, ByVal criterio As String) As List(Of AnalisisPresEn)
        Dim reader2 As SqlDataReader
        Dim listaAnalisisPres As New List(Of AnalisisPresEn)
        Dim id_cor As Double
        Dim año As Double = Now.Year - 1
        Dim mes As Double = Now.Month + 1
        If (Now.Month = 12) Then
            mes = 1
            año = Now.Year
        End If
        Dim mesAux As Double = mes
        Dim añoAux As Double = año
        Dim valAux As Double = 0
        Dim i As Double = 0
        Dim sql As String = " "
        Dim sum As Double = 0

        For k = 1 To 27

            id_cor = k
            año = Now.Year - 1
            mes = Now.Month + 1
            If (Now.Month = 12) Then
                mes = 1
                año = Now.Year
            End If
            i = 1
            objAnalisisPresEn = New AnalisisPresEn
            For i = 1 To 12
                Select Case id_cor
                    Case 1
                        objAnalisisPresEn.Descripcion = "AL BRILL"
                    Case 2
                        objAnalisisPresEn.Descripcion = "AL RECO"
                    Case 3
                        objAnalisisPresEn.Descripcion = "AL ESPE"
                    Case 4
                        objAnalisisPresEn.Descripcion = "VARILLAS"
                    Case 5
                        objAnalisisPresEn.Descripcion = "AL PUAS"
                    Case 6
                        objAnalisisPresEn.Descripcion = "AL GALV"
                    Case 7
                        objAnalisisPresEn.Descripcion = "M. POLLO"
                    Case 8
                        objAnalisisPresEn.Descripcion = "C.C 350-700"
                    Case 9
                        objAnalisisPresEn.Descripcion = "C.C 400-800"
                    Case 10
                        objAnalisisPresEn.Descripcion = "C.C 500-1000"
                    Case 11
                        objAnalisisPresEn.Descripcion = "CL GRANEL"
                    Case 12
                        objAnalisisPresEn.Descripcion = "CL VARETA"
                    Case 13
                        objAnalisisPresEn.Descripcion = "CL ZINC"
                    Case 14
                        objAnalisisPresEn.Descripcion = "HEL Y ANULA"
                    Case 15
                        objAnalisisPresEn.Descripcion = "CL ELECTRO"
                    Case 16
                        objAnalisisPresEn.Descripcion = "CL ACERO"
                    Case 17
                        objAnalisisPresEn.Descripcion = "GRAPAS"
                    Case 18
                        objAnalisisPresEn.Descripcion = "CL HERRAR"
                    Case 19
                        objAnalisisPresEn.Descripcion = "TR ESTUFA"
                    Case 20
                        objAnalisisPresEn.Descripcion = "TR LAMINA"
                    Case 21
                        objAnalisisPresEn.Descripcion = "TR MADERA"
                    Case 22
                        objAnalisisPresEn.Descripcion = "TR AGLOM"
                    Case 23
                        objAnalisisPresEn.Descripcion = "TR CHAZO"
                    Case 24
                        objAnalisisPresEn.Descripcion = "REMACHES"
                    Case 25
                        objAnalisisPresEn.Descripcion = "CARRIAJE"
                    Case 26
                        objAnalisisPresEn.Descripcion = "TR DRIWALL"
                    Case 27
                        objAnalisisPresEn.Descripcion = "ARANDELA"
                End Select

                conn2 = objConexion.abrirConexion2
                comando.CommandType = CommandType.Text
                comando.Connection = conn2
                sql = "select sum (" & criterio & " ) from Jjv_V_vtas_vend_cliente_ref   where MONTH (fec)=" & mes & " and YEAR (fec)=" & año & "  and vendedor >= " & min & " and vendedor <= " & max & " and Id_cor = " & id_cor & ""
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
                            objAnalisisPresEn.mes1 = sum

                        Case 2
                            objAnalisisPresEn.mes2 = sum
                        Case 3
                            objAnalisisPresEn.mes3 = sum
                        Case 4
                            objAnalisisPresEn.mes4 = sum
                        Case 5
                            objAnalisisPresEn.mes5 = sum
                        Case 6
                            objAnalisisPresEn.mes6 = sum
                        Case 7
                            objAnalisisPresEn.mes7 = sum
                        Case 8
                            objAnalisisPresEn.mes8 = sum
                        Case 9
                            objAnalisisPresEn.mes9 = sum
                        Case 10
                            objAnalisisPresEn.mes10 = sum
                        Case 11
                            objAnalisisPresEn.mes11 = sum
                        Case 12
                            objAnalisisPresEn.mes12 = sum

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
            listaAnalisisPres.Add(objAnalisisPresEn)
        Next
        objAnalisisPresEn = New AnalisisPresEn
        objAnalisisPresEn.Descripcion = "TOTAL"

        listaAnalisisPres.Add(objAnalisisPresEn)
        Return listaAnalisisPres
    End Function
    Public Function cargarVendedores() As String()
        Dim reader As SqlDataReader
        Dim vecVend(99) As String
        Dim k As Double = 0
        comando.CommandType = CommandType.Text
        conn = objConexion.abrirConexion
        comando.Connection = conn
        comando.CommandText = ("select vendedor FROM v_vendedores WHERE     (vendedor >= 1001) AND (vendedor <= 1099) AND (bloqueo = 0) ORDER BY vendedor")
        reader = comando.ExecuteReader
        While (reader.Read)
            If IsDBNull(reader(0)) Then
            Else
                vecVend(k) = reader(0)
                k = k + 1
            End If
        End While
        vecVend(k) = ("Nacionales")
        vecVend(k + 1) = ("Todos")
        conn.Close()
        Return vecVend
    End Function
    Public Function cargarConsultaVtasMes(ByVal vendedorMin As Integer, ByVal vendedorMax As Integer, ByVal mes As Integer, ByVal año As Integer, ByVal id_cor As Integer) As DataTable
        conn = objConexion.abrirConexion
        Dim DA As New SqlDataAdapter("select CIUDAD,NIT, NOMBRES,Codigo,DESCRIPCION,CANTIDAD as CANT,KILOS,VR_TOTAL,VALOR_UNITARIO as VR_UNIT,COSTO_UNITARIO as COST_UNIT,((SELECT CASE WHEN KILOS  = 0 THEN null ELSE (VALOR_UNITARIO)*100/(Vr_total /KILOS  ) END))as VR_KILO from Jjv_V_vtas_vend_cliente_ref   where MONTH (fec)=" & mes & " and YEAR (fec)=" & año & "  and vendedor >= " & vendedorMin & "  and vendedor <= " & vendedorMax & " and Id_cor = " & id_cor & " order by nit", conn)
        Dim dt As New DataTable
        DA.Fill(dt)
        conn.Close()
        Return dt
    End Function
End Class
