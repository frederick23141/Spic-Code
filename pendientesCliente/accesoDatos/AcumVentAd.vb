Imports System.Data.SqlClient
Imports System.Data
Imports entidadNegocios
Public Class AcumVentAd
    Private conn As New SqlConnection
    Private conn2 As New SqlConnection
    Private comando As New SqlCommand
    Dim objConexion As New Conexion
    Dim objAcumVentaEn As New AcumVentEn

    Public Function obtValTot(ByVal min As Double, ByVal max As Double, ByVal mesIni As Double, ByVal añoIni As Double, ByVal mesFin As Double, ByVal añoFin As Double, ByVal criterio As String) As Double
        Dim sw1 As Double = 0
        Dim sw2 As Double = 0
        Dim total As Double = 0
        Dim reader As SqlDataReader
        conn = objConexion.abrirConexion
        comando.Connection = conn
        comando.CommandType = CommandType.Text
        comando.CommandText = ("select SUM(" & criterio & " ) from Jjv_V_vtas_vend_cliente_ref  where  YEAR (fec)>=" & añoIni & " and MONTH (fec)>=" & mesIni & " and YEAR (fec)<=" & añoFin & " and MONTH (fec)<=" & mesFin & " and vendedor >= " & min & " and vendedor <= " & max & "  and  id_cor >=1 and id_cor<=27")
        reader = comando.ExecuteReader
        While reader.Read
            If IsDBNull(reader(0)) Then
            Else
                sw1 = reader(0)
            End If
        End While
        reader.Close()
        conn.Close()
        total = sw1
        Return total
    End Function


    Public Function Ppal(ByVal min As Double, ByVal max As Double, ByVal mesIni As Double, ByVal añoIni As Double, ByVal mesFin As Double, ByVal añoFin As Double, ByVal criterio As String) As List(Of AcumVentEn)
        Dim reader As SqlDataReader
        Dim reader2 As SqlDataReader
        Dim listaVent As New List(Of AcumVentEn)
        Dim nit As Double
        Dim sw As Boolean = False
        'Dim criterio As String = "kilos"
        Dim grupo As String
        Dim grupoAux As String
        Dim valAux As Double = 0
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
        comando.CommandText = ("select nit from Jjv_V_vtas_vend_cliente_ref  where fec>='" & añoIni & "-" & mesIni & "-01'and fec<='" & añoFin & "-" & mesFin & "-" & diaFin & "' and vendedor >= " & min & " and vendedor <= " & max & " and  id_cor >=1 and id_cor<=27 group by nit")
        reader = comando.ExecuteReader
        While (reader.Read)
            If IsDBNull(reader(0)) Then
            Else
                nit = reader(0)

                conn2 = objConexion.abrirConexion2
                comando.CommandType = CommandType.Text
                comando.Connection = conn2
                comando.CommandText = "select clas_cor,vendedor,ciudad,nit,nombres,id_cor," & criterio & " from Jjv_V_vtas_vend_cliente_ref  where nit = " & nit & " and fec>='" & añoIni & "-" & mesIni & "-01'and fec<='" & añoFin & "-" & mesFin & "-" & diaFin & "' and vendedor >= " & min & " and vendedor <= " & max & " and  id_cor >=1 and id_cor<=27 "
                reader2 = comando.ExecuteReader

                While reader2.Read

                    sw = False
                    If IsDBNull(reader) Then
                    Else
                        objAcumVentaEn = New AcumVentEn

                        If IsDBNull(reader2(0)) Then
                        Else
                            objAcumVentaEn.clas_cor = reader2(0)
                        End If
                        objAcumVentaEn.Vendedor = reader2(1)
                        objAcumVentaEn.ciudad = reader2(2)
                        objAcumVentaEn.nit = reader2(3)
                        objAcumVentaEn.Nombres = reader2(4)

                        grupoAux = reader2(5)
                        valAux = reader2(6)

                        If (sw = False) Then

                            grupo = grupoAux

                            Select Case grupo
                                Case 1
                                    objAcumVentaEn.alBrill = objAcumVentaEn.alBrill + valAux
                                Case 2
                                    objAcumVentaEn.alReco = objAcumVentaEn.alReco + valAux
                                Case 3
                                    objAcumVentaEn.alEspe = objAcumVentaEn.alEspe + valAux
                                Case 4
                                    objAcumVentaEn.varillas = objAcumVentaEn.varillas + valAux
                                Case 5
                                    objAcumVentaEn.alPuas = objAcumVentaEn.alPuas + valAux
                                Case 6
                                    objAcumVentaEn.alGalv = objAcumVentaEn.alGalv + valAux
                                Case 7
                                    objAcumVentaEn.mallPollo = objAcumVentaEn.mallPollo + valAux
                                Case 8
                                    objAcumVentaEn.cc350_700 = objAcumVentaEn.cc350_700 + valAux
                                Case 9
                                    objAcumVentaEn.cc400_800 = objAcumVentaEn.cc400_800 + valAux
                                Case 10
                                    objAcumVentaEn.cc500_1000 = objAcumVentaEn.cc500_1000 + valAux
                                Case 11
                                    objAcumVentaEn.clGranel = objAcumVentaEn.clGranel + valAux
                                Case 12
                                    objAcumVentaEn.clVareta = objAcumVentaEn.clVareta + valAux
                                Case 13
                                    objAcumVentaEn.clZinc = objAcumVentaEn.clZinc + valAux
                                Case 14
                                    objAcumVentaEn.helicoYanula = objAcumVentaEn.helicoYanula + valAux
                                Case 15
                                    objAcumVentaEn.helectro = objAcumVentaEn.helectro + valAux
                                Case 16
                                    objAcumVentaEn.clAcero = objAcumVentaEn.clAcero + valAux
                                Case 17
                                    objAcumVentaEn.grapas = objAcumVentaEn.grapas + valAux
                                Case 18
                                    objAcumVentaEn.clHerrar = objAcumVentaEn.clHerrar + valAux
                                Case 19
                                    objAcumVentaEn.trEstufa = objAcumVentaEn.trEstufa + valAux
                                Case 20
                                    objAcumVentaEn.trLamina = objAcumVentaEn.trLamina + valAux
                                Case 21
                                    objAcumVentaEn.trMadera = objAcumVentaEn.trMadera + valAux
                                Case 22
                                    objAcumVentaEn.trAglom = objAcumVentaEn.trAglom + valAux
                                Case 23
                                    objAcumVentaEn.trChazo = objAcumVentaEn.trChazo + valAux
                                Case 24
                                   objAcumVentaEn.remaches = objAcumVentaEn.remaches + valAux
                                Case 25
                                    objAcumVentaEn.carriaje = objAcumVentaEn.carriaje + valAux
                                Case 26
                                    objAcumVentaEn.trDrywall = objAcumVentaEn.trDrywall + valAux
                                Case 27
                                    objAcumVentaEn.arandela = objAcumVentaEn.arandela + valAux

                            End Select

                        Else


                        End If
                        sw = True
                        While reader2.Read
                            grupo = reader2(5)
                            Select Case grupo
                                Case 1
                                    objAcumVentaEn.alBrill = objAcumVentaEn.alBrill + reader2(6)
                                Case 2
                                    objAcumVentaEn.alReco = objAcumVentaEn.alReco + reader2(6)
                                Case 3
                                    objAcumVentaEn.alEspe = objAcumVentaEn.alEspe + reader2(6)
                                Case 4
                                    objAcumVentaEn.varillas = objAcumVentaEn.varillas + reader2(6)
                                Case 5
                                    objAcumVentaEn.alPuas = objAcumVentaEn.alPuas + reader2(6)
                                Case 6
                                    objAcumVentaEn.alGalv = objAcumVentaEn.alGalv + reader2(6)
                                Case 7
                                    objAcumVentaEn.mallPollo = objAcumVentaEn.mallPollo + reader2(6)
                                Case 8
                                    objAcumVentaEn.cc350_700 = objAcumVentaEn.cc350_700 + reader2(6)
                                Case 9
                                    objAcumVentaEn.cc400_800 = objAcumVentaEn.cc400_800 + reader2(6)
                                Case 10
                                    objAcumVentaEn.cc500_1000 = objAcumVentaEn.cc500_1000 + reader2(6)
                                Case 11
                                    objAcumVentaEn.clGranel = objAcumVentaEn.clGranel + reader2(6)
                                Case 12
                                    objAcumVentaEn.clVareta = objAcumVentaEn.clVareta + reader2(6)
                                Case 13
                                    objAcumVentaEn.clZinc = objAcumVentaEn.clZinc + reader2(6)
                                Case 14
                                    objAcumVentaEn.helicoYanula = objAcumVentaEn.helicoYanula + reader2(6)
                                Case 15
                                    objAcumVentaEn.helectro = objAcumVentaEn.helectro + reader2(6)
                                Case 16
                                    objAcumVentaEn.clAcero = objAcumVentaEn.clAcero + reader2(6)
                                Case 17
                                    objAcumVentaEn.grapas = objAcumVentaEn.grapas + reader2(6)
                                Case 18
                                    objAcumVentaEn.clHerrar = objAcumVentaEn.clHerrar + reader2(6)
                                Case 19
                                    objAcumVentaEn.trEstufa = objAcumVentaEn.trEstufa + reader2(6)
                                Case 20
                                    objAcumVentaEn.trLamina = objAcumVentaEn.trLamina + reader2(6)
                                Case 21
                                    objAcumVentaEn.trMadera = objAcumVentaEn.trMadera + reader2(6)
                                Case 22
                                    objAcumVentaEn.trAglom = objAcumVentaEn.trAglom + reader2(6)
                                Case 23
                                    objAcumVentaEn.trChazo = objAcumVentaEn.trChazo + reader2(6)
                                Case 24
                                    objAcumVentaEn.remaches = objAcumVentaEn.remaches + reader2(6)
                                Case 25
                                    objAcumVentaEn.carriaje = objAcumVentaEn.carriaje + reader2(6)
                                Case 26
                                    objAcumVentaEn.trDrywall = objAcumVentaEn.trDrywall + reader2(6)
                                Case 27
                                    objAcumVentaEn.arandela = objAcumVentaEn.arandela + reader2(6)

                            End Select
                        End While


                    End If

                End While
                listaVent.Add(objAcumVentaEn)
                reader2.Close()
                conn2.Close()
            End If
        End While

        Return listaVent
    End Function


    


End Class
