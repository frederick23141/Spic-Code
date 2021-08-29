Imports System.Data.SqlClient
Imports System.Data
Imports entidadNegocios
Public Class VtasClientAd
    Private conn As New SqlConnection
    Private conn2 As New SqlConnection
    Private comando As New SqlCommand
    Dim objConexion As New Conexion
    Private objVtasClienProdEn As VtasClientEn

    Public Function listarClienProd(ByVal min As Double, ByVal max As Double, ByVal mesIni As Double, ByVal añoIni As Double, ByVal mesFin As Double, ByVal añoFin As Double, ByVal codigoMin As String, ByVal codigoMax As String) As List(Of VtasClientEn)
        Dim listaVtasClienProdEn As New List(Of VtasClientEn)
        Dim vrUnitVrKilDev As Integer = 0
        Dim reader As SqlDataReader
        Dim reader2 As SqlDataReader
        Dim nit As Double
        Dim sw As Boolean = False
        'Dim criterio As String = "kilos"

        Dim diaFin As Double = 31
        If (mesFin = 2) Then
            diaFin = 28
        End If
        If (mesFin = 4 Or mesFin = 6 Or mesFin = 9 Or mesFin = 11) Then
            diaFin = 30
        End If
        comando.CommandType = CommandType.Text   'RECORDAR QUEEEEEEEEEEEEEEE EL MES 12 ES PROBLEMA
        conn = objConexion.abrirConexion
        comando.Connection = conn
        comando.CommandText = ("select nit from Jjv_V_vtas_vend_cliente_ref  where fec>='" & añoIni & "-" & mesIni & "-01'and fec<='" & añoFin & "-" & mesFin & "-" & diaFin & "' and vendedor >= " & min & " and vendedor <= " & max & " and  id_cor >=1 and id_cor<=27 and codigo  between '" & codigoMin & "' and '" & codigoMax & "' group by nit")
        reader = comando.ExecuteReader
        While (reader.Read)
            If IsDBNull(reader(0)) Then
            Else
                nit = reader(0)

                conn2 = objConexion.abrirConexion2
                comando.CommandType = CommandType.Text
                comando.Connection = conn2    ' 0     1     2       3       4           5      6        7   
                comando.CommandText = "select ciudad,nit,nombres,codigo,descripcion,cantidad,Kilos,Vr_total from Jjv_V_vtas_vend_cliente_ref  where fec>='" & añoIni & "-" & mesIni & "-01'and fec<='" & añoFin & "-" & mesFin & "-" & diaFin & "' and nit =" & nit & " and  id_cor >=1 and id_cor<=27  and codigo  between '" & codigoMin & "' and '" & codigoMax & "' order  by codigo   "
                reader2 = comando.ExecuteReader

                While reader2.Read 'intentar cambiar por un if
                    'EL PROBLÑEMA ESTA CON LAS DEVOLUCIONES OJO
                    sw = False
                    If IsDBNull(reader) Then
                    Else
                        objVtasClienProdEn = New VtasClientEn
                        objVtasClienProdEn.Ciudad = reader2(0)
                        objVtasClienProdEn.Nit = reader2(1)
                        objVtasClienProdEn.Nombres = reader2(2)
                        objVtasClienProdEn.Codigo = reader2(3)
                        objVtasClienProdEn.Descripcion = reader2(4)
                        objVtasClienProdEn.Cantidad = reader2(5)
                        objVtasClienProdEn.Kilos = reader2(6)
                        objVtasClienProdEn.Vr_Tot = reader2(7)
                        'If (reader2(7) <= 0) Then
                        '    objVtasClienProdEn.Vr_unit = 0
                        '    objVtasClienProdEn.Vr_Kilo = 0
                        'Else
                        '    objVtasClienProdEn.Vr_unit = (reader2(7) / reader2(5))
                        '    objVtasClienProdEn.Vr_Kilo = (reader2(7) / reader2(6))
                        'End If
                        
                        While (reader2.Read)
                            sw = True
                            If (objVtasClienProdEn.Codigo = reader2(3)) Then
                                vrUnitVrKilDev = (reader2(7) / reader2(6))
                                objVtasClienProdEn.Cantidad = objVtasClienProdEn.Cantidad + reader2(5)
                                objVtasClienProdEn.Kilos = objVtasClienProdEn.Kilos + reader2(6)
                                objVtasClienProdEn.Vr_Tot = objVtasClienProdEn.Vr_Tot + reader2(7)
                                'If (reader2(7) <= 0) Then
                                '    objVtasClienProdEn.Vr_unit = objVtasClienProdEn.Vr_unit - (reader2(7) / reader2(5))
                                '    objVtasClienProdEn.Vr_Kilo = objVtasClienProdEn.Vr_Kilo - (reader2(7) / reader2(6))
                                'Else
                                '    objVtasClienProdEn.Vr_unit = objVtasClienProdEn.Vr_unit + (reader2(7) / reader2(5))
                                '    objVtasClienProdEn.Vr_Kilo = objVtasClienProdEn.Vr_Kilo + (reader2(7) / reader2(6))
                                'End If
                              
                            Else
                                listaVtasClienProdEn.Add(objVtasClienProdEn)
                                objVtasClienProdEn = New VtasClientEn

                                objVtasClienProdEn.Ciudad = reader2(0)
                                objVtasClienProdEn.Nit = reader2(1)
                                objVtasClienProdEn.Nombres = reader2(2)
                                objVtasClienProdEn.Codigo = reader2(3)
                                objVtasClienProdEn.Descripcion = reader2(4)
                                objVtasClienProdEn.Cantidad = reader2(5)
                                objVtasClienProdEn.Kilos = reader2(6)
                                objVtasClienProdEn.Vr_Tot = reader2(7)
                                'If (reader2(7) <= 0) Then
                                '    objVtasClienProdEn.Vr_unit = objVtasClienProdEn.Vr_unit - (reader2(7) / reader2(5))
                                '    objVtasClienProdEn.Vr_Kilo = objVtasClienProdEn.Vr_Kilo - (reader2(7) / reader2(6))
                                'Else
                                '    objVtasClienProdEn.Vr_unit = objVtasClienProdEn.Vr_unit + (reader2(7) / reader2(5))
                                '    objVtasClienProdEn.Vr_Kilo = objVtasClienProdEn.Vr_Kilo + (reader2(7) / reader2(6))
                                'End If
                            End If
                        End While

                    End If

                End While
                listaVtasClienProdEn.Add(objVtasClienProdEn)
                reader2.Close()
                conn2.Close()
            End If
        End While


        Return listaVtasClienProdEn
    End Function


End Class
