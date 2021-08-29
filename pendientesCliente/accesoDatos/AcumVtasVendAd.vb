Imports System.Data.SqlClient
Imports System.Data
Imports entidadNegocios
Public Class acumVtasVendAd
    Private conn As New SqlConnection
    Private conn2 As New SqlConnection
    Private comando As New SqlCommand
    Dim objConexion As New Conexion
    Dim objAcumVtasVendEn As New AcumVtasVendEn
    Public Function listarAcumVtasVend(ByVal min As Double, ByVal max As Double, ByVal mesIni As Double, ByVal añoIni As Double, ByVal mesFin As Double, ByVal añoFin As Double, ByVal criterio As String) As List(Of AcumVtasVendEn)
        Dim listaAcumVtasVend As New List(Of AcumVtasVendEn)
        Dim reader As SqlDataReader

        Dim i As Double = 0
        Dim sql As String = ""
        Dim sum As Double = 0
        Dim diaIni As Double = 1
        Dim diaFin As Double = 31
        Dim tot As Double = 0
        If (mesFin = 2) Then
            diaFin = 28
        End If
        If (mesFin = 4 Or mesFin = 6 Or mesFin = 9 Or mesFin = 11) Then
            diaFin = 30
        End If

        Dim vecVend(99) As Double
        Dim k As Double = 0
        comando.CommandType = CommandType.Text
        conn = objConexion.abrirConexion
        comando.Connection = conn
        comando.CommandText = ("select vendedor FROM v_vendedores WHERE     (vendedor >= " & min & ") AND (vendedor <= " & max & ") AND (bloqueo = 0) ORDER BY vendedor")
        reader = comando.ExecuteReader
        While (reader.Read)
            If IsDBNull(reader(0)) Then
            Else
                vecVend(k) = reader(0)
                k = k + 1

            End If
        End While
        reader.Close()
        conn.Close()
        For i = 1 To 27
            objAcumVtasVendEn = New AcumVtasVendEn
            Select Case i
                Case 1
                    objAcumVtasVendEn.Descripcion = "AL BRILL"
                Case 2
                    objAcumVtasVendEn.Descripcion = "AL RECO"
                Case 3
                    objAcumVtasVendEn.Descripcion = "AL ESPE"
                Case 4
                    objAcumVtasVendEn.Descripcion = "VARILLAS"
                Case 5
                    objAcumVtasVendEn.Descripcion = "AL PUAS"
                Case 6
                    objAcumVtasVendEn.Descripcion = "AL GALV"
                Case 7
                    objAcumVtasVendEn.Descripcion = "M. POLLO"
                Case 8
                    objAcumVtasVendEn.Descripcion = "C.C 350-700"
                Case 9
                    objAcumVtasVendEn.Descripcion = "C.C 400-800"
                Case 10
                    objAcumVtasVendEn.Descripcion = "C.C 500-1000"
                Case 11
                    objAcumVtasVendEn.Descripcion = "CL GRANEL"
                Case 12
                    objAcumVtasVendEn.Descripcion = "CL VARETA"
                Case 13
                    objAcumVtasVendEn.Descripcion = "CL ZINC"
                Case 14
                    objAcumVtasVendEn.Descripcion = "HEL Y ANULA"
                Case 15
                    objAcumVtasVendEn.Descripcion = "CL ELECTRO"
                Case 16
                    objAcumVtasVendEn.Descripcion = "CL ACERO"
                Case 17
                    objAcumVtasVendEn.Descripcion = "GRAPAS"
                Case 18
                    objAcumVtasVendEn.Descripcion = "CL HERRAR"
                Case 19
                    objAcumVtasVendEn.Descripcion = "TR ESTUFA"
                Case 20
                    objAcumVtasVendEn.Descripcion = "TR LAMINA"
                Case 21
                    objAcumVtasVendEn.Descripcion = "TR MADERA"
                Case 22
                    objAcumVtasVendEn.Descripcion = "TR AGLOM"
                Case 23
                    objAcumVtasVendEn.Descripcion = "TR CHAZO"
                Case 24
                    objAcumVtasVendEn.Descripcion = "REMACHES"
                Case 25
                    objAcumVtasVendEn.Descripcion = "CARRIAJE"
                Case 26
                    objAcumVtasVendEn.Descripcion = "TR DRIWALL"
                Case 27
                    objAcumVtasVendEn.Descripcion = "ARANDELA"
            End Select
            For j = 0 To 98
                If vecVend(j) > 0 Then

                    comando.CommandType = CommandType.Text   'RECORDAR QUEEEEEEEEEEEEEEE EL MES 12 ES PROBLEMA
                    conn = objConexion.abrirConexion
                    comando.Connection = conn
                    comando.CommandText = ("select sum (" & criterio & ") from Jjv_V_vtas_vend_cliente_ref  where vendedor= " & vecVend(j) & " and id_cor = " & i & " and fec >='" & añoIni & "-" & mesIni & "-" & diaIni & "' and fec <=' " & añoFin & "-" & mesFin & "-" & diaFin & "' ")
                    reader = comando.ExecuteReader
                    If (reader.Read) Then
                        If IsDBNull(reader(0)) Then
                        Else
                            sum = reader(0)
                        End If
                    End If
                    reader.Close()
                    conn.Close()

                    If (sum <> 0) Then
                        tot = tot + sum

                        Select Case vecVend(j)
                            Case 1001
                                objAcumVtasVendEn.vend1001 = sum
                            Case 1002
                                objAcumVtasVendEn.vend1002 = sum
                            Case 1003
                                objAcumVtasVendEn.vend1003 = sum
                            Case 1004
                                objAcumVtasVendEn.vend1004 = sum
                            Case 1005
                                objAcumVtasVendEn.vend1005 = sum
                            Case 1006
                                objAcumVtasVendEn.vend1006 = sum
                            Case 1007
                                objAcumVtasVendEn.vend1007 = sum
                            Case 1008
                                objAcumVtasVendEn.vend1008 = sum
                            Case 1009
                                objAcumVtasVendEn.vend1009 = sum
                            Case 1010
                                objAcumVtasVendEn.vend1010 = sum
                            Case 1011
                                objAcumVtasVendEn.vend1011 = sum
                            Case 1012
                                objAcumVtasVendEn.vend1012 = sum
                            Case 1013
                                objAcumVtasVendEn.vend1013 = sum
                            Case 1014
                                objAcumVtasVendEn.vend1014 = sum
                            Case 1015
                                objAcumVtasVendEn.vend1015 = sum
                            Case 1016
                                objAcumVtasVendEn.vend1016 = sum
                            Case 1017
                                objAcumVtasVendEn.vend1017 = sum
                            Case 1018
                                objAcumVtasVendEn.vend1018 = sum
                            Case 1019
                                objAcumVtasVendEn.vend1019 = sum
                            Case 1020
                                objAcumVtasVendEn.vend1020 = sum
                            Case 1021
                                objAcumVtasVendEn.vend1021 = sum
                            Case 1022
                                objAcumVtasVendEn.vend1022 = sum
                            Case 1023
                                objAcumVtasVendEn.vend1023 = sum
                            Case 1024
                                objAcumVtasVendEn.vend1024 = sum
                            Case 1025
                                objAcumVtasVendEn.vend1025 = sum
                            Case 1026
                                objAcumVtasVendEn.vend1026 = sum
                            Case 1027
                                objAcumVtasVendEn.vend1027 = sum
                            Case 1028
                                objAcumVtasVendEn.vend1028 = sum
                            Case 1029
                                objAcumVtasVendEn.vend1029 = sum
                            Case 1030
                                objAcumVtasVendEn.vend1030 = sum
                            Case 1031
                                objAcumVtasVendEn.vend1031 = sum
                            Case 1032
                                objAcumVtasVendEn.vend1032 = sum
                            Case 1033
                                objAcumVtasVendEn.vend1033 = sum
                            Case 1034
                                objAcumVtasVendEn.vend1034 = sum
                            Case 1035
                                objAcumVtasVendEn.vend1035 = sum
                            Case 1036
                                objAcumVtasVendEn.vend1036 = sum
                            Case 1037
                                objAcumVtasVendEn.vend1037 = sum
                            Case 1038
                                objAcumVtasVendEn.vend1038 = sum
                            Case 1039
                                objAcumVtasVendEn.vend1039 = sum
                            Case 1040
                                objAcumVtasVendEn.vend1040 = sum
                            Case 1041
                                objAcumVtasVendEn.vend1041 = sum
                            Case 1042
                                objAcumVtasVendEn.vend1042 = sum
                            Case 1043
                                objAcumVtasVendEn.vend1043 = sum
                            Case 1044
                                objAcumVtasVendEn.vend1044 = sum
                            Case 1045
                                objAcumVtasVendEn.vend1045 = sum
                            Case 1046
                                objAcumVtasVendEn.vend1046 = sum
                            Case 1047
                                objAcumVtasVendEn.vend1047 = sum
                            Case 1048
                                objAcumVtasVendEn.vend1048 = sum
                            Case 1049
                                objAcumVtasVendEn.vend1049 = sum
                            Case 1050
                                objAcumVtasVendEn.vend1050 = sum
                            Case 1051
                                objAcumVtasVendEn.vend1051 = sum
                            Case 1052
                                objAcumVtasVendEn.vend1052 = sum
                            Case 1053
                                objAcumVtasVendEn.vend1053 = sum
                            Case 1054
                                objAcumVtasVendEn.vend1054 = sum
                            Case 1055
                                objAcumVtasVendEn.vend1055 = sum
                            Case 1056
                                objAcumVtasVendEn.vend1056 = sum
                            Case 1057
                                objAcumVtasVendEn.vend1057 = sum
                            Case 1058
                                objAcumVtasVendEn.vend1058 = sum
                            Case 1059
                                objAcumVtasVendEn.vend1059 = sum
                            Case 1060
                                objAcumVtasVendEn.vend1060 = sum
                            Case 1061
                                objAcumVtasVendEn.vend1061 = sum
                            Case 1062
                                objAcumVtasVendEn.vend1062 = sum
                            Case 1063
                                objAcumVtasVendEn.vend1063 = sum
                            Case 1064
                                objAcumVtasVendEn.vend1064 = sum
                            Case 1065
                                objAcumVtasVendEn.vend1065 = sum
                            Case 1066
                                objAcumVtasVendEn.vend1066 = sum
                            Case 1067
                                objAcumVtasVendEn.vend1067 = sum
                            Case 1068
                                objAcumVtasVendEn.vend1068 = sum
                            Case 1069
                                objAcumVtasVendEn.vend1069 = sum
                            Case 1070
                                objAcumVtasVendEn.vend1070 = sum
                            Case 1071
                                objAcumVtasVendEn.vend1071 = sum
                            Case 1072
                                objAcumVtasVendEn.vend1072 = sum
                            Case 1073
                                objAcumVtasVendEn.vend1073 = sum
                            Case 1074
                                objAcumVtasVendEn.vend1074 = sum
                            Case 1075
                                objAcumVtasVendEn.vend1075 = sum
                            Case 1076
                                objAcumVtasVendEn.vend1076 = sum
                            Case 1077
                                objAcumVtasVendEn.vend1077 = sum
                            Case 1078
                                objAcumVtasVendEn.vend1078 = sum
                            Case 1079
                                objAcumVtasVendEn.vend1079 = sum
                            Case 1080
                                objAcumVtasVendEn.vend1080 = sum
                            Case 1081
                                objAcumVtasVendEn.vend1081 = sum
                            Case 1082
                                objAcumVtasVendEn.vend1082 = sum
                            Case 1083
                                objAcumVtasVendEn.vend1083 = sum
                            Case 1084
                                objAcumVtasVendEn.vend1084 = sum
                            Case 1085
                                objAcumVtasVendEn.vend1085 = sum
                            Case 1086
                                objAcumVtasVendEn.vend1086 = sum
                            Case 1087
                                objAcumVtasVendEn.vend1087 = sum
                            Case 1088
                                objAcumVtasVendEn.vend1088 = sum
                            Case 1089
                                objAcumVtasVendEn.vend1089 = sum
                            Case 1090
                                objAcumVtasVendEn.vend1090 = sum
                            Case 1091
                                objAcumVtasVendEn.vend1091 = sum
                            Case 1092
                                objAcumVtasVendEn.vend1092 = sum
                            Case 1093
                                objAcumVtasVendEn.vend1093 = sum
                            Case 1094
                                objAcumVtasVendEn.vend1094 = sum
                            Case 1095
                                objAcumVtasVendEn.vend1095 = sum
                            Case 1096
                                objAcumVtasVendEn.vend1096 = sum
                            Case 1097
                                objAcumVtasVendEn.vend1097 = sum
                            Case 1098
                                objAcumVtasVendEn.vend1098 = sum
                            Case 1099
                                objAcumVtasVendEn.vend1099 = sum
                        End Select
                    End If
                End If
                sum = 0
            Next
            objAcumVtasVendEn.Total_x_Fila = tot
            listaAcumVtasVend.Add(objAcumVtasVendEn)
            reader.Close()
            conn.Close()
            sum = 0
            tot = 0
        Next
        reader.Close()
        conn.Close()

        Return listaAcumVtasVend
    End Function


 
End Class
