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
        comando.CommandText = ("select vendedor FROM Jjv_V_vtas_vend_cliente_ref WHERE     (vendedor >= " & min & ") AND (vendedor <= " & max & ") and fec >='" & añoIni & "-" & mesIni & "-" & diaIni & "' and fec <=' " & añoFin & "-" & mesFin & "-" & diaFin & "' GROUP BY vendedor  ORDER BY vendedor")
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
        For i = 1 To 29
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
                Case 28
                    objAcumVtasVendEn.Descripcion = "SERVICIO DE RECOCIDO"
                Case 29
                    objAcumVtasVendEn.Descripcion = "CHATARRA"
            End Select
            For j = 0 To 98
                If vecVend(j) > 0 Then

                    comando.CommandType = CommandType.Text   'RECORDAR QUEEEEEEEEEEEEEEE EL MES 12 ES PROBLEMA
                    conn = objConexion.abrirConexion
                    comando.Connection = conn
                    sql = "select sum (" & criterio & ") from Jjv_V_vtas_vend_cliente_ref  where vendedor= " & vecVend(j) & " and id_cor = " & i & " and fec >='" & añoIni & "-" & mesIni & "-" & diaIni & "' and fec <=' " & añoFin & "-" & mesFin & "-" & diaFin & "' "
                    comando.CommandText = (sql)
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
                                objAcumVtasVendEn.V1001 = sum
                            Case 1002
                                objAcumVtasVendEn.V1002 = sum
                            Case 1003
                                objAcumVtasVendEn.V1003 = sum
                            Case 1004
                                objAcumVtasVendEn.V1004 = sum
                            Case 1005
                                objAcumVtasVendEn.V1005 = sum
                            Case 1006
                                objAcumVtasVendEn.V1006 = sum
                            Case 1007
                                objAcumVtasVendEn.V1007 = sum
                            Case 1008
                                objAcumVtasVendEn.V1008 = sum
                            Case 1009
                                objAcumVtasVendEn.V1009 = sum
                            Case 1010
                                objAcumVtasVendEn.V1010 = sum
                            Case 1011
                                objAcumVtasVendEn.V1011 = sum
                            Case 1012
                                objAcumVtasVendEn.V1012 = sum
                            Case 1013
                                objAcumVtasVendEn.V1013 = sum
                            Case 1014
                                objAcumVtasVendEn.V1014 = sum
                            Case 1015
                                objAcumVtasVendEn.V1015 = sum
                            Case 1016
                                objAcumVtasVendEn.V1016 = sum
                            Case 1017
                                objAcumVtasVendEn.V1017 = sum
                            Case 1018
                                objAcumVtasVendEn.V1018 = sum
                            Case 1019
                                objAcumVtasVendEn.V1019 = sum
                            Case 1020
                                objAcumVtasVendEn.V1020 = sum
                            Case 1021
                                objAcumVtasVendEn.V1021 = sum
                            Case 1022
                                objAcumVtasVendEn.V1022 = sum
                            Case 1023
                                objAcumVtasVendEn.V1023 = sum
                            Case 1024
                                objAcumVtasVendEn.V1024 = sum
                            Case 1025
                                objAcumVtasVendEn.V1025 = sum
                            Case 1026
                                objAcumVtasVendEn.V1026 = sum
                            Case 1027
                                objAcumVtasVendEn.V1027 = sum
                            Case 1028
                                objAcumVtasVendEn.V1028 = sum
                            Case 1029
                                objAcumVtasVendEn.V1029 = sum
                            Case 1030
                                objAcumVtasVendEn.V1030 = sum
                            Case 1031
                                objAcumVtasVendEn.V1031 = sum
                            Case 1032
                                objAcumVtasVendEn.V1032 = sum
                            Case 1033
                                objAcumVtasVendEn.V1033 = sum
                            Case 1034
                                objAcumVtasVendEn.V1034 = sum
                            Case 1035
                                objAcumVtasVendEn.V1035 = sum
                            Case 1036
                                objAcumVtasVendEn.V1036 = sum
                            Case 1037
                                objAcumVtasVendEn.V1037 = sum
                            Case 1038
                                objAcumVtasVendEn.V1038 = sum
                            Case 1039
                                objAcumVtasVendEn.V1039 = sum
                            Case 1040
                                objAcumVtasVendEn.V1040 = sum
                            Case 1041
                                objAcumVtasVendEn.V1041 = sum
                            Case 1042
                                objAcumVtasVendEn.V1042 = sum
                            Case 1043
                                objAcumVtasVendEn.V1043 = sum
                            Case 1044
                                objAcumVtasVendEn.V1044 = sum
                            Case 1045
                                objAcumVtasVendEn.V1045 = sum
                            Case 1046
                                objAcumVtasVendEn.V1046 = sum
                            Case 1047
                                objAcumVtasVendEn.V1047 = sum
                            Case 1048
                                objAcumVtasVendEn.V1048 = sum
                            Case 1049
                                objAcumVtasVendEn.V1049 = sum
                            Case 1050
                                objAcumVtasVendEn.V1050 = sum
                            Case 1051
                                objAcumVtasVendEn.V1051 = sum
                            Case 1052
                                objAcumVtasVendEn.V1052 = sum
                            Case 1053
                                objAcumVtasVendEn.V1053 = sum
                            Case 1054
                                objAcumVtasVendEn.V1054 = sum
                            Case 1055
                                objAcumVtasVendEn.V1055 = sum
                            Case 1056
                                objAcumVtasVendEn.V1056 = sum
                            Case 1057
                                objAcumVtasVendEn.V1057 = sum
                            Case 1058
                                objAcumVtasVendEn.V1058 = sum
                            Case 1059
                                objAcumVtasVendEn.V1059 = sum
                            Case 1060
                                objAcumVtasVendEn.V1060 = sum
                            Case 1061
                                objAcumVtasVendEn.V1061 = sum
                            Case 1062
                                objAcumVtasVendEn.V1062 = sum
                            Case 1063
                                objAcumVtasVendEn.V1063 = sum
                            Case 1064
                                objAcumVtasVendEn.V1064 = sum
                            Case 1065
                                objAcumVtasVendEn.V1065 = sum
                            Case 1066
                                objAcumVtasVendEn.V1066 = sum
                            Case 1067
                                objAcumVtasVendEn.V1067 = sum
                            Case 1068
                                objAcumVtasVendEn.V1068 = sum
                            Case 1069
                                objAcumVtasVendEn.V1069 = sum
                            Case 1070
                                objAcumVtasVendEn.V1070 = sum
                            Case 1071
                                objAcumVtasVendEn.V1071 = sum
                            Case 1072
                                objAcumVtasVendEn.V1072 = sum
                            Case 1073
                                objAcumVtasVendEn.V1073 = sum
                            Case 1074
                                objAcumVtasVendEn.V1074 = sum
                            Case 1075
                                objAcumVtasVendEn.V1075 = sum
                            Case 1076
                                objAcumVtasVendEn.V1076 = sum
                            Case 1077
                                objAcumVtasVendEn.V1077 = sum
                            Case 1078
                                objAcumVtasVendEn.V1078 = sum
                            Case 1079
                                objAcumVtasVendEn.V1079 = sum
                            Case 1080
                                objAcumVtasVendEn.V1080 = sum
                            Case 1081
                                objAcumVtasVendEn.V1081 = sum
                            Case 1082
                                objAcumVtasVendEn.V1082 = sum
                            Case 1083
                                objAcumVtasVendEn.V1083 = sum
                            Case 1084
                                objAcumVtasVendEn.V1084 = sum
                            Case 1085
                                objAcumVtasVendEn.V1085 = sum
                            Case 1086
                                objAcumVtasVendEn.V1086 = sum
                            Case 1087
                                objAcumVtasVendEn.V1087 = sum
                            Case 1088
                                objAcumVtasVendEn.V1088 = sum
                            Case 1089
                                objAcumVtasVendEn.V1089 = sum
                            Case 1090
                                objAcumVtasVendEn.V1090 = sum
                            Case 1091
                                objAcumVtasVendEn.V1091 = sum
                            Case 1092
                                objAcumVtasVendEn.V1092 = sum
                            Case 1093
                                objAcumVtasVendEn.V1093 = sum
                            Case 1094
                                objAcumVtasVendEn.V1094 = sum
                            Case 1095
                                objAcumVtasVendEn.V1095 = sum
                            Case 1096
                                objAcumVtasVendEn.V1096 = sum
                            Case 1097
                                objAcumVtasVendEn.V1097 = sum
                            Case 1098
                                objAcumVtasVendEn.V1098 = sum
                            Case 1099
                                objAcumVtasVendEn.V1099 = sum
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
        objAcumVtasVendEn = New AcumVtasVendEn
        listaAcumVtasVend.Add(objAcumVtasVendEn)

        Return listaAcumVtasVend
    End Function
    Public Function listar_consulta(ByVal min As Double, ByVal max As Double, ByVal mesIni As Double, ByVal añoIni As Double, ByVal mesFin As Double, ByVal añoFin As Double, ByVal criterio As String, ByVal vendedores As String, ByVal vend_hoy As Boolean) As DataTable
        Dim conn As New SqlConnection
        Dim reader As SqlDataReader
        Dim comando As New SqlCommand
        Dim objConexion As New Conexion
        Dim dt As New DataTable
        Dim dr As DataRow
        Dim sql As String = ""
        Dim sw As Boolean = False
        Dim id_cor_ant As Integer = 0
        Dim desc_ant As String = ""
        Dim suma_ant As Double = 0
        Dim diaFin As Integer = DateSerial(añoFin, mesFin + 1, 0).Day
        Dim vend As String = ""
        Dim criterioVendedor As String = ""
        Dim where_vend As String = ""
        dt = construir_table(dt, min, max, mesIni, añoIni, mesFin, añoFin, diaFin, vend_hoy, vendedores)
        comando.CommandType = CommandType.Text
        conn = objConexion.abrirConexion
        comando.Connection = conn
        If (vendedores <> "") Then
            If (vend_hoy) Then
                criterioVendedor = " AND vend_hoy in (" & vendedores & ")"
            Else
                criterioVendedor = " AND vendedor in (" & vendedores & ")"
            End If

        Else
            If (vend_hoy) Then
                criterioVendedor = "  AND vend_hoy >= " & min & " AND vend_hoy <=  " & max & " "
            Else
                criterioVendedor = "  AND vendedor >=  " & min & "  AND vendedor <=  " & max & " "
            End If

        End If
        sql = "SELECT SUM(vtas." & criterio & " ) As suma,vtas.Id_cor ,vtas.vendedor ,seg.Descripcion " & _
                 "FROM Jjv_V_vtas_vend_cliente_ref vtas ,JJV_Grupos_seguimiento seg " & _
                        "WHERE (vtas.fec >='" & añoIni & "-" & mesIni & "-01' AND vtas.fec <=' " & añoFin & "-" & mesFin & "-" & diaFin & "' And seg.Id_cor = vtas.Id_cor " & criterioVendedor & ") " & _
                            "GROUP BY vtas.Id_cor ,vtas.vendedor ,seg.Descripcion  " & _
                                    "ORDER BY vtas.id_cor "
        comando.CommandText = sql
        reader = comando.ExecuteReader
        While (reader.Read)
            vend = reader("vendedor")
            If (vend = 1051) Then
                If (reader("Id_cor") = 30) Then
                    sql = ""
                End If

            End If

            If (sw = False) Then
                dr = dt.NewRow
                id_cor_ant = reader("Id_cor")
                sw = True
            End If
            If Not (id_cor_ant = reader("Id_cor")) Then
#Disable Warning BC42104 ' La variable 'dr' se usa antes de que se le haya asignado un valor. Podría darse una excepción de referencia NULL en tiempo de ejecución.
                dt.Rows.Add(dr)
#Enable Warning BC42104 ' La variable 'dr' se usa antes de que se le haya asignado un valor. Podría darse una excepción de referencia NULL en tiempo de ejecución.
                dr = dt.NewRow
                id_cor_ant = reader("Id_cor")
                desc_ant = reader("Descripcion")
                suma_ant = reader("suma")
            End If
            dr("Linea_producción") = reader("Descripcion")
            dr(vend) = reader("suma")
            dr("id_cor") = reader("Id_cor")
        End While
        dt.Rows.Add(dr)
        dr = dt.NewRow
        dr(vend) = suma_ant
        dr("Linea_producción") = desc_ant
        dr("id_cor") = id_cor_ant
        dt.Rows.Add(dr)
        conn.Close()
        reader.Close()
        Return dt
    End Function
    Public Function construir_table(ByVal dt As DataTable, ByVal vend_min As Integer, ByVal vend_max As Integer, ByVal mesIni As Integer, ByVal añoIni As Integer, ByVal mesFin As Integer, ByVal añoFin As Integer, ByVal diaFin As Integer, ByVal vend_hoy As Boolean, ByVal vendedores As String) As DataTable
        Dim conn As New SqlConnection
        Dim reader As SqlDataReader
        Dim comando As New SqlCommand
        Dim objConexion As New Conexion
        dt.Columns.Add("Linea_producción")
        dt.Columns.Add("id_cor")
        dt.Columns.Add("Tot_x_fila", GetType(Int64))
        Dim criterioVendedor As String = ""
        If (vendedores <> "") Then
            If (vend_hoy) Then
                criterioVendedor = "  vend_hoy in (" & vendedores & ")"
            Else
                criterioVendedor = "  vendedor in (" & vendedores & ")"
            End If

        Else
            If (vend_hoy) Then
                criterioVendedor = "   vend_hoy >= 1001 AND vend_hoy <= 1099"
            Else
                criterioVendedor = "   vendedor >= 1001 AND vendedor <= 1099"
            End If

        End If
        Dim sql As String = "SELECT vtas.vendedor  " & _
                                    "FROM Jjv_V_vtas_vend_cliente_ref vtas " & _
                                            "WHERE " & criterioVendedor & " AND vtas.fec >='" & añoIni & "-" & mesIni & "-01' AND vtas.fec <=' " & añoFin & "-" & mesFin & "-" & diaFin & "' " & _
                                                " GROUP BY  vtas.vendedor  "
        comando.CommandType = CommandType.Text
        conn = objConexion.abrirConexion
        comando.Connection = conn
        comando.CommandText = sql
        reader = comando.ExecuteReader
        While (reader.Read)
            dt.Columns.Add(reader("vendedor"), GetType(Int64))
        End While
        Return dt
    End Function
    Public Function listar_detalle(ByVal sql As String) As DataTable
        Dim objConexion As New Conexion
        conn = objConexion.abrirConexion
        Dim dt As New DataTable
        Dim DA As New SqlDataAdapter(sql, conn)
        DA.Fill(dt)
        conn.Close()
        Return dt
    End Function
 
End Class
