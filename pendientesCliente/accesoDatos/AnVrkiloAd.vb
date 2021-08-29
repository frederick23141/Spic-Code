Imports System.Data.SqlClient
Imports System.Data
Imports entidadNegocios
Public Class AnVrkiloAd

    '****************************************************************************************************************
    'Se crean los parametros para la conexion ***********************************************************************
    '****************************************************************************************************************
    Private conn As New SqlConnection
    Private comando As New SqlCommand


    Dim objConexion As New Conexion
    Dim objAnalisisEn As AnalisisEn


    Public Function listarPresGeneral(ByVal mes As Integer, ByVal añoIni As Integer, ByVal añoFin As Integer) As List(Of AnVrKiloEn)
        Dim objAnVrKiloEn As New AnVrKiloEn
        Dim objAnVrKiloEn2 As New AnVrKiloEn
        Dim objAnVrKiloEn3 As New AnVrKiloEn
        Dim objAnVrKiloEn4 As New AnVrKiloEn
        Dim objAnVrKiloEn5 As New AnVrKiloEn
        Dim objAnVrKiloEn6 As New AnVrKiloEn
        Dim listaAnVrKilo As New List(Of AnVrKiloEn)
        Dim reader As SqlDataReader
        Dim sql As String = ""
        Dim i As Integer = 1
        Try
            conn = objConexion.abrirConexion
            comando.CommandType = CommandType.Text
            comando.Connection = conn
            sql = "select SUM (KILOS),SUM (Vr_total ),SUM (Cto_total ) from Jjv_V_vtas_vend_cliente_ref where MONTH (fec) = " & mes & " and YEAR (fec) >= " & añoIni & " and YEAR (fec) <= " & añoFin & " group by MONTH (fec),YEAR (fec)"
            comando.CommandText = sql
            reader = comando.ExecuteReader
            objAnVrKiloEn = New AnVrKiloEn
            objAnVrKiloEn.Descripcion = "Kilos"

            objAnVrKiloEn2 = New AnVrKiloEn
            objAnVrKiloEn2.Descripcion = "Valor Total"

            objAnVrKiloEn3 = New AnVrKiloEn
            objAnVrKiloEn3.Descripcion = "Costo Total"

            objAnVrKiloEn4 = New AnVrKiloEn
            objAnVrKiloEn4.Descripcion = "Valor Kilo"

            objAnVrKiloEn5 = New AnVrKiloEn
            objAnVrKiloEn5.Descripcion = "Costo Kilo"

            objAnVrKiloEn6 = New AnVrKiloEn
            objAnVrKiloEn6.Descripcion = "Porc Utilidad"

            While (reader.Read)
                If IsDBNull(reader(0)) Then
                Else
                  
                    Select Case i
                        Case 1
                            objAnVrKiloEn.mes1 = reader(0)
                            objAnVrKiloEn2.mes1 = reader(1)
                            objAnVrKiloEn3.mes1 = reader(2)
                        Case 2
                            objAnVrKiloEn.mes2 = reader(0)
                            objAnVrKiloEn2.mes2 = reader(1)
                            objAnVrKiloEn3.mes2 = reader(2)
                        Case 3
                            objAnVrKiloEn.mes3 = reader(0)
                            objAnVrKiloEn2.mes3 = reader(1)
                            objAnVrKiloEn3.mes3 = reader(2)
                        Case 4
                            objAnVrKiloEn.mes4 = reader(0)
                            objAnVrKiloEn2.mes4 = reader(1)
                            objAnVrKiloEn3.mes4 = reader(2)
                        Case 5
                            objAnVrKiloEn.mes5 = reader(0)
                            objAnVrKiloEn2.mes5 = reader(1)
                            objAnVrKiloEn3.mes5 = reader(2)
                        Case 6
                            objAnVrKiloEn.mes6 = reader(0)
                            objAnVrKiloEn2.mes6 = reader(1)
                            objAnVrKiloEn3.mes6 = reader(2)
                        Case 7
                            objAnVrKiloEn.mes7 = reader(0)
                            objAnVrKiloEn2.mes7 = reader(1)
                            objAnVrKiloEn3.mes7 = reader(2)
                        Case 8
                            objAnVrKiloEn.mes8 = reader(0)
                            objAnVrKiloEn2.mes8 = reader(1)
                            objAnVrKiloEn3.mes8 = reader(2)
                        Case 9
                            objAnVrKiloEn.mes9 = reader(0)
                            objAnVrKiloEn2.mes9 = reader(1)
                            objAnVrKiloEn3.mes9 = reader(2)
                        Case 10
                            objAnVrKiloEn.mes10 = reader(0)
                            objAnVrKiloEn2.mes10 = reader(1)
                            objAnVrKiloEn3.mes10 = reader(2)
                        Case 11
                            objAnVrKiloEn.mes11 = reader(0)
                            objAnVrKiloEn2.mes11 = reader(1)
                            objAnVrKiloEn3.mes11 = reader(2)
                        Case 12
                            objAnVrKiloEn.mes12 = reader(0)
                            objAnVrKiloEn2.mes12 = reader(1)
                            objAnVrKiloEn3.mes12 = reader(2)
                        Case 13
                            objAnVrKiloEn.mes13 = reader(0)
                            objAnVrKiloEn2.mes13 = reader(1)
                            objAnVrKiloEn3.mes13 = reader(2)
                        Case 14
                            objAnVrKiloEn.mes14 = reader(0)
                            objAnVrKiloEn2.mes14 = reader(1)
                            objAnVrKiloEn3.mes14 = reader(2)
                        Case 15
                            objAnVrKiloEn.mes15 = reader(0)
                            objAnVrKiloEn2.mes15 = reader(1)
                            objAnVrKiloEn3.mes15 = reader(2)

                    End Select

                End If
                i += 1

            End While
            listaAnVrKilo.Add(objAnVrKiloEn)
            listaAnVrKilo.Add(objAnVrKiloEn2)
            listaAnVrKilo.Add(objAnVrKiloEn3)
            listaAnVrKilo.Add(objAnVrKiloEn4)
            listaAnVrKilo.Add(objAnVrKiloEn5)
            listaAnVrKilo.Add(objAnVrKiloEn6)

        Catch ex As ApplicationException
            MsgBox(ex.Message)
        End Try
        conn.Close()
        Return listaAnVrKilo
    End Function

End Class

