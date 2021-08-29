Imports System.Data.SqlClient
Imports System.Data
Imports entidadNegocios
Public Class Informe_daneAd
    Private obj_op_simplesAd As New Op_simplesAd
    '    Public Function listarBusqueda(ByVal ano As Integer) As DataView
    '        Dim conn As New SqlConnection
    '        Dim reader As SqlDataReader
    '        Dim comando As New SqlCommand
    '        Dim objConexion As New Conexion
    '        Dim dr As DataRow
    '        Dim list_vend As New List(Of Integer)
    '        Dim stock As Double = 0
    '        Dim codigo As String = ""
    '        Dim sql As String = ""
    '        Dim dt As DataTable = const_tabla(ano)
    '        Dim centro_aux As Integer = 0
    '        sql = "SELECT   centro,descripcion,mes,COUNT (distinct nit )As cantidad " & _
    '                  "FROM Jjv_valort " & _
    '                        "WHERE ano = " & ano & " " & _
    '                                "GROUP BY centro,descripcion,mes"
    '        comando.CommandType = CommandType.Text
    '        conn = objConexion.abrirConexion
    '        comando.Connection = conn
    '        comando.CommandText = sql
    '        reader = comando.ExecuteReader
    '        dr = dt.NewRow
    '        If (reader.Read) Then
    '            centro_aux = reader("centro")
    '        End If
    '        While (reader.Read)
    '            dr("Centro") = reader("centro")
    '            dr("Desripciòn") = reader("descripcion")
    '            dr(MonthName(reader("mes"), True)) = reader("cantidad")
    '            If (centro_aux <> reader("centro")) Then
    '                centro_aux = reader("centro")
    '                dt.Rows.Add(dr)
    '                dr = dt.NewRow
    '            End If
    '        End While
    '        conn.Close()
    '        reader.Close()
    '        Dim view As DataView = New DataView(dt)
    '        view.Sort = "Centro"
    '        Return (view)

    '    End Function
    Public Function const_tabla(ByVal ano As Integer) As DataTable
        Dim conn As New SqlConnection
        Dim reader As SqlDataReader
        Dim comando As New SqlCommand
        Dim objConexion As New Conexion
        Dim dt As New DataTable
        dt.Columns.Add("centro")
        dt.Columns.Add("Desripciòn")
        Dim sql As String = ""
        comando.CommandType = CommandType.Text
        conn = objConexion.abrirConexion
        comando.Connection = conn
        sql = "SELECT mes, ano " & _
                    "from Jjv_valort " & _
                        "WHERE   ano =" & ano & " " & _
                           "GROUP BY mes, ano"
        comando.CommandText = sql
        reader = comando.ExecuteReader
        While (reader.Read)
            dt.Columns.Add(MonthName(reader("mes"), True), GetType(Int64))
        End While
        conn.Close()
        reader.Close()
        Return dt
    End Function
    'Public Function listarBusqueda(ByVal ano As Integer, ByVal tipo As String) As DataView
    '    Dim conn As New SqlConnection
    '    Dim reader As SqlDataReader
    '    Dim mes As Integer = 1
    '    Dim vec_usu() As String = cargar_usuarios(mes, ano)
    '    Dim comando As New SqlCommand
    '    Dim objConexion As New Conexion
    '    Dim dt As DataTable = const_tabla(ano)
    '    Dim dr1 As DataRow = dt.NewRow
    '    Dim dr2 As DataRow = dt.NewRow
    '    Dim dr3 As DataRow = dt.NewRow
    '    Dim dr4 As DataRow = dt.NewRow
    '    Dim dr5 As DataRow = dt.NewRow
    '    Dim dr6 As DataRow = dt.NewRow
    '    Dim dr7 As DataRow = dt.NewRow
    '    Dim dr8 As DataRow = dt.NewRow
    '    Dim dr9 As DataRow = dt.NewRow
    '    Dim dr10 As DataRow = dt.NewRow
    '    Dim dr11 As DataRow = dt.NewRow
    '    Dim dr12 As DataRow = dt.NewRow
    '    Dim dr13 As DataRow = dt.NewRow
    '    Dim dr14 As DataRow = dt.NewRow
    '    Dim dr15 As DataRow = dt.NewRow
    '    Dim dr16 As DataRow = dt.NewRow
    '    Dim dr17 As DataRow = dt.NewRow
    '    Dim dr18 As DataRow = dt.NewRow
    '    Dim dr19 As DataRow = dt.NewRow
    '    Dim dr20 As DataRow = dt.NewRow
    '    Dim dr21 As DataRow = dt.NewRow
    '    Dim dr22 As DataRow = dt.NewRow
    '    Dim dr23 As DataRow = dt.NewRow
    '    Dim dr24 As DataRow = dt.NewRow
    '    Dim dr25 As DataRow = dt.NewRow

    '    Dim cont1 As Integer = 0
    '    Dim cont2 As Integer = 0
    '    Dim cont3 As Integer = 0
    '    Dim cont4 As Integer = 0
    '    Dim cont5 As Integer = 0
    '    Dim cont6 As Integer = 0
    '    Dim cont7 As Integer = 0
    '    Dim cont8 As Integer = 0
    '    Dim cont9 As Integer = 0
    '    Dim cont10 As Integer = 0
    '    Dim cont11 As Integer = 0
    '    Dim cont12 As Integer = 0
    '    Dim cont13 As Integer = 0
    '    Dim cont14 As Integer = 0
    '    Dim cont15 As Integer = 0
    '    Dim cont16 As Integer = 0
    '    Dim cont17 As Integer = 0
    '    Dim cont18 As Integer = 0
    '    Dim cont19 As Integer = 0
    '    Dim cont20 As Integer = 0
    '    Dim cont21 As Integer = 0
    '    Dim cont22 As Integer = 0
    '    Dim cont23 As Integer = 0
    '    Dim cont24 As Integer = 0
    '    Dim cont25 As Integer = 0
    '    Dim sql As String = ""

    '    Dim centro_aux As String = ""
    '    Dim descipcion As String = ""
    '    Dim where As String = """"
    '    Dim tipo_consulta As String = ""
    '    Dim cont As Double = 0
    '    Select Case tipo
    '        Case "Personal"
    '            tipo_consulta = "COUNT (distinct val.nit )As cantidad "
    '        Case "Horas"
    '            tipo_consulta = "SUM(val.tHoras) As cantidad "
    '        Case "Salario"
    '            tipo_consulta = "SUM(val.valor) As cantidad "

    '    End Select
    '    For j = 1 To 12
    '        For i = 0 To 300
    '            If vec_usu(i) Is Nothing Then
    '            Else
    '                sql = "SELECT top (1)liq.centro,liq.mes ,liq.ano,nom_per.tipo_contrato    " & _
    '                                        "FROM y_liquidacion liq , Jjv_nom_per_todo nom_per " & _
    '                                               " where(liq.nit = " & vec_usu(i) & " And liq.ano = " & ano & " And liq.nit = nom_per.nit And liq.mes = " & mes & ") " & _
    '                                                           "Group by liq.centro,liq.mes,liq.ano,nom_per.tipo_contrato  " & _
    '                                                                "order by tipo_contrato asc"

    '                comando.CommandType = CommandType.Text
    '                conn = objConexion.abrirConexion
    '                comando.Connection = conn
    '                comando.CommandText = sql
    '                reader = comando.ExecuteReader
    '                If (reader.Read) Then
    '                    Select Case reader("centro")
    '                        Case 4100
    '                            If (reader("tipo_contrato") <> "Z") Then
    '                                dr1("descipcion") = "AMINISTRACION PRODUCCION"
    '                                cont1 += 1
    '                                dr1(MonthName(reader("mes"), True)) = cont1
    '                            Else
    '                                dr2("descipcion") = "APRENDIZ PRODUCCION"
    '                                cont2 += 1
    '                                dr2(MonthName(reader("mes"), True)) = cont2
    '                            End If

    '                        Case 1100
    '                            dr3("descipcion") = ("COMPRAS Y SUMINISTROS")
    '                            cont3 += 1
    '                            dr3(MonthName(reader("mes"), True)) = cont3
    '                        Case 1200
    '                            dr4("descipcion") = "ALMACEN TECNICO"
    '                            cont4 += 1
    '                            dr4(MonthName(reader("mes"), True)) = cont4
    '                        Case 3100
    '                            If (reader("tipo_contrato") <> "Z") Then
    '                                dr5("descipcion") = "MANTENIMIENTO"
    '                                cont5 += 1
    '                                dr5(MonthName(reader("mes"), True)) = cont5
    '                            Else
    '                                cont6 += 1
    '                                dr6(MonthName(reader("mes"), True)) = cont6
    '                            End If
    '                        Case 3200
    '                            dr7("descipcion") = "SERVICIOS GENERALES"
    '                            cont7 += 1
    '                            dr7(MonthName(reader("mes"), True)) = cont7
    '                        Case 2100
    '                            If (reader("tipo_contrato") = "Z") Then
    '                                cont19 += 1
    '                                dr19(MonthName(reader("mes"), True)) = cont19
    '                            Else
    '                                dr8("descipcion") = "TREFILACION"
    '                                cont8 += 1
    '                                dr8(MonthName(reader("mes"), True)) = cont8
    '                            End If
    '                        Case 2200

    '                            If (reader("tipo_contrato") = "Z") Then
    '                                dr19("descipcion") = "APRENDIZ"
    '                                cont19 += 1
    '                                dr19(MonthName(reader("mes"), True)) = cont19
    '                            Else
    '                                dr9("descipcion") = "HORNOS RECOCIDOS"
    '                                cont9 += 1
    '                                dr9(MonthName(reader("mes"), True)) = cont9
    '                            End If
    '                        Case 2300

    '                            If (reader("tipo_contrato") = "Z") Then
    '                                dr19("descipcion") = "APRENDIZ"
    '                                cont19 += 1
    '                                dr19(MonthName(reader("mes"), True)) = cont19
    '                            Else
    '                                dr10("descipcion") = "PUNTILLERIA"
    '                                cont10 += 1
    '                                dr10(MonthName(reader("mes"), True)) = cont10
    '                            End If

    '                        Case 2400
    '                            dr11("descipcion") = "EMPAQUE PUNTILLERIA"
    '                            cont11 += 1
    '                            dr11(MonthName(reader("mes"), True)) = cont11
    '                            'If (reader("tipo_contrato") = "Z") Then
    '                            '    dr19(MonthName(reader("mes"), True)) = Convert.ToDouble(dr19.ToString) + 1
    '                            '    dr19("descipcion") = "APRENDIZ"
    '                            'End If
    '                        Case 2500

    '                            If (reader("tipo_contrato") = "Z") Then
    '                                dr19("descipcion") = "APRENDIZ"
    '                                cont19 += 1
    '                                dr19(MonthName(reader("mes"), True)) = cont19
    '                            Else
    '                                dr12("descipcion") = "TORNILLERIA"
    '                                cont12 += 1
    '                                dr12(MonthName(reader("mes"), True)) = cont12
    '                            End If
    '                        Case 2600

    '                            If (reader("tipo_contrato") = "Z") Then
    '                                dr19("descipcion") = "APRENDIZ"
    '                                cont19 += 1
    '                                dr19(MonthName(reader("mes"), True)) = cont19
    '                            Else
    '                                dr13("descipcion") = "EMPAQUE TORNILLERIA"
    '                                cont13 += 1
    '                                dr13(MonthName(reader("mes"), True)) = cont13
    '                            End If
    '                        Case 2800
    '                            If (reader("tipo_contrato") = "Z") Then
    '                                dr19("descipcion") = "APRENDIZ"
    '                                cont19 += 1
    '                                dr19(MonthName(reader("mes"), True)) = cont19
    '                            Else
    '                                dr14("descipcion") = "PLANTA GALVANIZADO"
    '                                cont14 += 1
    '                                dr14(MonthName(reader("mes"), True)) = cont14
    '                            End If
    '                        Case 3800

    '                            If (reader("tipo_contrato") = "Z") Then
    '                                dr19("descipcion") = "APRENDIZ"
    '                                cont19 += 1
    '                                dr19(MonthName(reader("mes"), True)) = cont19
    '                            Else
    '                                cont15 += 1
    '                                dr15("descipcion") = "PLANTA ALAMBRE GALVANIZADO"
    '                                dr15(MonthName(reader("mes"), True)) = cont15
    '                            End If
    '                        Case 5200
    '                            If (reader("tipo_contrato") = "Z") Then
    '                                dr19("descipcion") = "APRENDIZ"
    '                                cont19 += 1
    '                                dr19(MonthName(reader("mes"), True)) = cont19
    '                            Else
    '                                cont16 += 1
    '                                dr16("descipcion") = "ALAMBRE GALV. POR INMERSION"
    '                                dr16(MonthName(reader("mes"), True)) = cont16
    '                            End If
    '                        Case 6200

    '                            If (reader("tipo_contrato") = "Z") Then
    '                                cont19 += 1
    '                                dr19(MonthName(reader("mes"), True)) = cont19
    '                                dr19("descipcion") = "APRENDIZ"
    '                            Else
    '                                cont17 += 1
    '                                dr17("descipcion") = "TRATAMIENTOS TERMICOS"
    '                                dr17(MonthName(reader("mes"), True)) = cont17
    '                            End If
    '                        Case 6400
    '                            If (reader("tipo_contrato") = "Z") Then
    '                                cont19 += 1
    '                                dr19(MonthName(reader("mes"), True)) = cont19
    '                                dr19("descipcion") = "APRENDIZ"
    '                            Else
    '                                cont18 += 1
    '                                dr18("descipcion") = "MAQUINA DE PUAS"
    '                                dr18(MonthName(reader("mes"), True)) = cont18
    '                            End If
    '                            'Case 2700
    '                            '    cont20 += 1
    '                            '    dr20("descipcion") = "CONTROL DESPERDICIOS"
    '                            '    dr20(MonthName(reader("mes"), True)) = cont20
    '                        Case 4300
    '                            If (reader("tipo_contrato") = "Z") Then
    '                                cont22 += 1
    '                                dr22("descipcion") = "APRENDIZ VENTAS"
    '                                dr22(MonthName(reader("mes"), True)) = cont22
    '                            Else
    '                                cont21 += 1
    '                                dr21("descipcion") = "VENTAS"
    '                                dr21(MonthName(reader("mes"), True)) = cont21
    '                            End If
    '                        Case 3500
    '                            cont23 += 1
    '                            dr23("descipcion") = "DESPACHOS"
    '                            dr23(MonthName(reader("mes"), True)) = cont23
    '                        Case 4200
    '                            If (reader("tipo_contrato") <> "Z") Then
    '                                cont24 += 1
    '                                dr24("descipcion") = "ADMINISTRACION GENERAL"
    '                                dr24(MonthName(reader("mes"), True)) = cont24
    '                            Else
    '                                cont25 += 1
    '                                dr25(MonthName(reader("mes"), True)) = cont25
    '                                dr25(MonthName(reader("mes"), True)) = cont25
    '                            End If

    '                    End Select
    '                End If
    '            End If
    '            conn.Close()


    '        Next
    '        mes += 1
    '        cont1 = 0
    '        cont2 = 0
    '        cont3 = 0
    '        cont4 = 0
    '        cont5 = 0
    '        cont6 = 0
    '        cont7 = 0
    '        cont8 = 0
    '        cont9 = 0
    '        cont10 = 0
    '        cont11 = 0
    '        cont12 = 0
    '        cont13 = 0
    '        cont14 = 0
    '        cont15 = 0
    '        cont16 = 0
    '        cont17 = 0
    '        cont18 = 0
    '        cont19 = 0
    '        cont21 = 0
    '        cont22 = 0
    '        cont23 = 0
    '        cont24 = 0
    '        cont25 = 0
    '        vec_usu = cargar_usuarios(mes, ano)

    '    Next
    '    dr25("descipcion") = "APRENDIZ ADMINISTRACION GENERAL"
    '    dr19("descipcion") = "APRENDIZ"
    '    dr6("descipcion") = "APRENDIZ MANTENIMEINTO"
    '    dt.Rows.Add(dr1)
    '    dt.Rows.Add(dr2)
    '    dt.Rows.Add(dr3)
    '    dt.Rows.Add(dr4)
    '    dt.Rows.Add(dr5)
    '    dt.Rows.Add(dr6)
    '    dt.Rows.Add(dr7)
    '    dt.Rows.Add(dr8)
    '    dt.Rows.Add(dr9)
    '    dt.Rows.Add(dr10)
    '    dt.Rows.Add(dr11)
    '    dt.Rows.Add(dr12)
    '    dt.Rows.Add(dr13)
    '    dt.Rows.Add(dr14)
    '    dt.Rows.Add(dr15)
    '    dt.Rows.Add(dr16)
    '    dt.Rows.Add(dr17)
    '    dt.Rows.Add(dr18)
    '    dt.Rows.Add(dr19)
    '    ' dt.Rows.Add(dr20)
    '    dt.Rows.Add(dr21)
    '    dt.Rows.Add(dr22)
    '    dt.Rows.Add(dr23)
    '    dt.Rows.Add(dr24)
    '    dt.Rows.Add(dr25)
    '    Dim view As DataView = New DataView(dt)
    '    'view.Sort = "Centro"
    '    Return (view)

    'End Function
    Public Function listarBusqueda(ByVal ano As Integer, ByVal tipo As String) As DataView
        Dim conn As New SqlConnection
        Dim reader As SqlDataReader
        Dim comando As New SqlCommand
        Dim objConexion As New Conexion
        Dim dr As DataRow
        Dim list_vend As New List(Of Integer)
        Dim stock As Double = 0
        Dim codigo As String = ""
        Dim sql As String = ""
        Dim dt As DataTable
        dt = const_tabla(ano)
        Dim centro_aux As String = ""
        Dim descipcion As String = ""
        Dim where As String = """"
        Dim tipo_consulta As String = ""
        Dim tipo_centro As String = ""
        Select Case tipo
            Case "Personal"
                tipo_consulta = "COUNT (distinct val.nit )As cantidad "
            Case "Horas"
                tipo_consulta = "SUM(val.tHoras) As cantidad "
            Case "Salario"
                tipo_consulta = "SUM(val.valor) As cantidad "

        End Select

        For i = 1 To 26
            where = "WHERE ano = " & ano & " AND "
            Select Case i
                Case 1
                    where = where & "val.centro like '41%' and val.tipo_contrato<>'z' AND val.nit not in (SELECT  nit from Jjv_valort WHERE ano = val.ano and mes =val.mes AND centro like ('41%') and tipo_contrato='z'  )"
                    descipcion = "ADMINISTRACION PRODUCCION"
                    tipo_centro = "4100"
                Case 2
                    where = where & "val.centro like '41%' and val.tipo_contrato='z' AND val.nit not in (SELECT  nit from Jjv_valort WHERE ano =val.ano and mes =val.mes AND centro like ('41%')  and tipo_contrato<>'z' ) "
                    descipcion = "APRENDIZ  ADMINISTRACION PRODC."
                    tipo_centro = "A4100"
                Case 3
                    where = where & "val.centro like '11%' and val.tipo_contrato<>'z' "
                    descipcion = "COMPRAS Y SUMINISTROS"
                    tipo_centro = "1100"
                Case 4
                    where = where & "val.centro like '12%' and val.tipo_contrato<>'z'"
                    descipcion = "ALMACEN TECNICO"
                    tipo_centro = "1200"
                Case 5
                    where = where & "val.centro like '31%' and val.tipo_contrato<>'z' AND val.nit not in (SELECT  nit from Jjv_valort WHERE ano  =val.ano and mes =val.mes  and (tipo_contrato='z')  ) "
                    descipcion = "MANTENIMIENTO"
                Case 6
                    where = where & "val.centro like '31%' and val.tipo_contrato='z' AND val.nit not in (SELECT  nit from Jjv_valort WHERE ano =val.ano and mes =val.mes and tipo_contrato<>'z' ) "
                    descipcion = "APRENDIZ MANTENIMEINTO"
                    tipo_centro = "3100"
                Case 7
                    where = where & "val.centro like '32%' and val.tipo_contrato<>'z'"
                    descipcion = "SERVICIOS GENERALES"
                    tipo_centro = "3200"
                Case 8
                    where = where & "val.centro like '21%' and val.tipo_contrato<>'z'"
                    descipcion = "TREFILACION"
                    tipo_centro = "2100"
                Case 9
                    where = where & "val.centro like '22%' and val.tipo_contrato<>'z'"
                    descipcion = "HORNOS RECOCIDOS"
                    tipo_centro = "2200"
                Case 10
                    where = where & "val.centro like '23%' and val.tipo_contrato<>'z'"
                    descipcion = "PUNTILLERIA"
                    tipo_centro = "2300"
                Case 11
                    where = where & "val.centro like '24%' and val.tipo_contrato<>'z' "
                    descipcion = "EMPAQUE PUNTILLERIA"
                    tipo_centro = "2400"
                Case 12
                    where = where & "val.centro like '25%' and val.tipo_contrato<>'z'"
                    descipcion = "TORNILLERIA"
                    tipo_centro = "2500"
                Case 13
                    where = where & "val.centro like '26%' and val.tipo_contrato<>'z'"
                    descipcion = "EMPAQUE TORNILLERIA"
                    tipo_centro = "2600"
                Case 14
                    where = where & "val.centro like '28%' and val.tipo_contrato<>'z'"
                    descipcion = "PLANTA GALVANIZADO"
                    tipo_centro = "2800"
                Case 15
                    where = where & "val.centro like '52%' and val.tipo_contrato<>'z'"
                    descipcion = "PLANTA ALAMBRE GALVANIZADO"
                    tipo_centro = "5200"
                Case 16
                    where = where & "val.centro like '38%' and val.tipo_contrato<>'z'"
                    descipcion = "ALAMBRE GALV. POR INMERSION"
                    tipo_centro = "3800"
                Case 17
                    where = where & "val.centro like '62%' and val.tipo_contrato<>'z'"
                    descipcion = "TRATAMIENTOS TERMICOS"
                    tipo_centro = "6200"
                Case 18
                    where = where & "val.centro like '64%' and val.tipo_contrato<>'z'"
                    descipcion = "MAQUINA DE PUAS"
                    tipo_centro = "6400"
                Case 19
                    where = where & "val.centro in(2100,2200,2300,2400,2500,2600,2800,3800,5200,6200,6400) and val.tipo_contrato<>'z' AND val.nit not in (SELECT  nit from Jjv_valort WHERE ano =val.ano and mes =val.mes AND val.centro in(2100,2200,2300,2400,2500,2600,2800,3800,5200,6200,6400) and val.tipo_contrato <> 'z' ) "
                    descipcion = "APRENDIZ"
                    tipo_centro = "A"
                Case 20
                    where = where & "val.centro like '27%' and val.tipo_contrato<>'z'"
                    descipcion = "CONTROL DESPERDICIOS"
                    tipo_centro = "2700"
                Case 21
                    where = where & "val.centro like '43%' and val.tipo_contrato<>'z' AND val.nit not in (SELECT  nit from Jjv_valort WHERE ano =val.ano and mes =val.mes AND centro like ('43%')  and tipo_contrato='z') "
                    descipcion = "VENTAS"
                    tipo_centro = "4300"
                Case 22
                    where = where & "val.centro like '43%' and val.tipo_contrato='z' AND val.nit not in (SELECT  nit from Jjv_valort WHERE ano =val.ano and mes =val.mes AND centro like ('43%')  and tipo_contrato<>'z') "
                    descipcion = "APRENDIZ VENTAS"
                    tipo_centro = "A4300"
                Case 23
                    where = where & "val.centro like '35%' and val.tipo_contrato<>'z'"
                    descipcion = "DESPACHOS"
                    tipo_centro = "3500"
                Case 24
                    where = where & "val.centro like '42%' and val.tipo_contrato<>'Z'  AND val.nit not in (SELECT  nit from Jjv_valort WHERE ano =val.ano and mes =val.mes AND centro like ('42%')  and tipo_contrato='z' or centro <> 4200 ) "
                    descipcion = "ADMINISTRACION GENERAL"
                    tipo_centro = "4200"
                Case 25
                    where = where & "val.centro like '42%' and val.tipo_contrato='Z'  AND val.nit not in (SELECT  nit from Jjv_valort WHERE ano =val.ano and mes =val.mes AND centro like ('42%')  and tipo_contrato<>'z' or centro <> 4200) "
                    descipcion = "APRENDIZ ADMINISTRACION GENERAL"
                    tipo_centro = "A4200"
                Case 26
                    where = where & "val.centro like '45%' and val.tipo_contrato='z' AND val.nit not in (SELECT  nit from Jjv_valort WHERE ano =val.ano and mes =val.mes AND centro like ('45%')  and tipo_contrato<>'z') "
                    descipcion = "AUXILIARES PORTERIA"
                    tipo_centro = "4500"
            End Select
            sql = "SELECT val.mes, " & tipo_consulta & " " & _
                          " FROM Jjv_valort val " & _
                                     where & _
                             " group by val.mes   "

            comando.CommandType = CommandType.Text
            conn = objConexion.abrirConexion
            comando.Connection = conn
            comando.CommandText = sql
            reader = comando.ExecuteReader
            dr = dt.NewRow
            dr("Desripciòn") = descipcion
            dr("centro") = tipo_centro
            While (reader.Read)
                dr(MonthName(reader("mes"), True)) = reader("cantidad")
            End While
            dt.Rows.Add(dr)
            If (descipcion = "SERVICIOS GENERALES" Or descipcion = "APRENDIZ" Or descipcion = "DESPACHOS") Then
                dr = dt.NewRow
                dr("Desripciòn") = "Totales"
                dt.Rows.Add(dr)
            End If
            dr = dt.NewRow
            conn.Close()
            reader.Close()
        Next
        dr = dt.NewRow
        dr("Desripciòn") = "TOTAL GENERAL"
        dt.Rows.Add(dr)
        dt = add_totales_reales(dt, ano, tipo)
        restar_centros_repetidos(dt, ano)
        Dim view As DataView = New DataView(dt)
        'view.Sort = "Centro"
        Return (view)

    End Function

    Public Function listarBusqueda_(ByVal ano As Integer, ByVal tipo As String) As DataView
        Dim conn As New SqlConnection
        Dim reader As SqlDataReader
        Dim comando As New SqlCommand
        Dim objConexion As New Conexion
        Dim dr As DataRow
        Dim list_vend As New List(Of Integer)
        Dim stock As Double = 0
        Dim codigo As String = ""
        Dim sql As String = ""
        Dim dt As DataTable
        dt = const_tabla(ano)
        Dim centro_aux As String = ""
        Dim descipcion As String = ""
        Dim where As String = """"
        Dim tipo_consulta As String = ""
        Dim tipo_centro As String = ""
        Select Case tipo
            Case "Personal"
                tipo_consulta = "  "

        End Select

        For i = 1 To 25
            where = "WHERE ano = " & ano & " AND "
            Select Case i
                Case 1
                    where = where & "val.centro like '41%' and val.tipo_contrato<>'z' AND val.nit not in (SELECT  nit from Jjv_valort WHERE ano = val.ano and mes =val.mes AND centro like ('41%') and tipo_contrato='z'  )"
                    descipcion = "ADMINISTRACION PRODUCCION"
                    tipo_centro = "4100"
                Case 2
                    where = where & "val.centro like '41%' and val.tipo_contrato='z' AND val.nit not in (SELECT  nit from Jjv_valort WHERE ano =val.ano and mes =val.mes AND centro like ('41%')  and tipo_contrato<>'z' ) "
                    descipcion = "APRENDIZ  ADMINISTRACION PRODC."
                    tipo_centro = "A4100"
                Case 3
                    where = where & "val.centro like '11%' and val.tipo_contrato<>'z' "
                    descipcion = "COMPRAS Y SUMINISTROS"
                    tipo_centro = "1100"
                Case 4
                    where = where & "val.centro like '12%' and val.tipo_contrato<>'z'"
                    descipcion = "ALMACEN TECNICO"
                    tipo_centro = "1200"
                Case 5
                    where = where & "val.centro like '31%' and val.tipo_contrato<>'z' AND val.nit not in (SELECT  nit from Jjv_valort WHERE ano  =val.ano and mes =val.mes  and (tipo_contrato='z')  ) "
                    descipcion = "MANTENIMIENTO"
                Case 6
                    where = where & "val.centro like '31%' and val.tipo_contrato='z' AND val.nit not in (SELECT  nit from Jjv_valort WHERE ano =val.ano and mes =val.mes and tipo_contrato<>'z' ) "
                    descipcion = "APRENDIZ MANTENIMEINTO"
                    tipo_centro = "3100"
                Case 7
                    where = where & "val.centro like '32%' and val.tipo_contrato<>'z'"
                    descipcion = "SERVICIOS GENERALES"
                    tipo_centro = "3200"
                Case 8
                    where = where & "val.centro like '21%' and val.tipo_contrato<>'z'"
                    descipcion = "TREFILACION"
                    tipo_centro = "2100"
                Case 9
                    where = where & "val.centro like '22%' and val.tipo_contrato<>'z'"
                    descipcion = "HORNOS RECOCIDOS"
                    tipo_centro = "2200"
                Case 10
                    where = where & "val.centro like '23%' and val.tipo_contrato<>'z'"
                    descipcion = "PUNTILLERIA"
                    tipo_centro = "2300"
                Case 11
                    where = where & "val.centro like '24%' and val.tipo_contrato<>'z' "
                    descipcion = "EMPAQUE PUNTILLERIA"
                    tipo_centro = "2400"
                Case 12
                    where = where & "val.centro like '25%' and val.tipo_contrato<>'z'"
                    descipcion = "TORNILLERIA"
                    tipo_centro = "2500"
                Case 13
                    where = where & "val.centro like '26%' and val.tipo_contrato<>'z'"
                    descipcion = "EMPAQUE TORNILLERIA"
                    tipo_centro = "2600"
                Case 14
                    where = where & "val.centro like '28%' and val.tipo_contrato<>'z'"
                    descipcion = "PLANTA GALVANIZADO"
                    tipo_centro = "2800"
                Case 15
                    where = where & "val.centro like '52%' and val.tipo_contrato<>'z'"
                    descipcion = "PLANTA ALAMBRE GALVANIZADO"
                    tipo_centro = "5200"
                Case 16
                    where = where & "val.centro like '38%' and val.tipo_contrato<>'z'"
                    descipcion = "ALAMBRE GALV. POR INMERSION"
                    tipo_centro = "3800"
                Case 17
                    where = where & "val.centro like '62%' and val.tipo_contrato<>'z'"
                    descipcion = "TRATAMIENTOS TERMICOS"
                    tipo_centro = "6200"
                Case 18
                    where = where & "val.centro like '64%' and val.tipo_contrato<>'z'"
                    descipcion = "MAQUINA DE PUAS"
                    tipo_centro = "6400"
                Case 19
                    where = where & "val.centro in(2100,2200,2300,2400,2500,2600,2800,3800,5200,6200,6400) and val.tipo_contrato<>'z' AND val.nit not in (SELECT  nit from Jjv_valort WHERE ano =val.ano and mes =val.mes AND val.centro in(2100,2200,2300,2400,2500,2600,2800,3800,5200,6200,6400) and val.tipo_contrato <> 'z' ) "
                    descipcion = "APRENDIZ"
                    tipo_centro = "A"
                Case 20
                    where = where & "val.centro like '27%' and val.tipo_contrato<>'z'"
                    descipcion = "CONTROL DESPERDICIOS"
                    tipo_centro = "2700"
                Case 21
                    where = where & "val.centro like '43%' and val.tipo_contrato<>'z' AND val.nit not in (SELECT  nit from Jjv_valort WHERE ano =val.ano and mes =val.mes AND centro like ('43%')  and tipo_contrato='z') "
                    descipcion = "VENTAS"
                    tipo_centro = "4300"
                Case 22
                    where = where & "val.centro like '43%' and val.tipo_contrato='z' AND val.nit not in (SELECT  nit from Jjv_valort WHERE ano =val.ano and mes =val.mes AND centro like ('43%')  and tipo_contrato<>'z') "
                    descipcion = "APRENDIZ VENTAS"
                    tipo_centro = "A4300"
                Case 23
                    where = where & "val.centro like '35%' and val.tipo_contrato<>'z'"
                    descipcion = "DESPACHOS"
                    tipo_centro = "3500"
                Case 24
                    where = where & "val.centro like '42%' and val.tipo_contrato<>'Z'  AND val.nit not in (SELECT  nit from Jjv_valort WHERE ano =val.ano and mes =val.mes AND centro like ('42%')  and tipo_contrato='z' or centro <> 4200 ) "
                    descipcion = "ADMINISTRACION GENERAL"
                    tipo_centro = "4200"
                Case 25
                    where = where & "val.centro like '42%' and val.tipo_contrato='Z'  AND val.nit not in (SELECT  nit from Jjv_valort WHERE ano =val.ano and mes =val.mes AND centro like ('42%')  and tipo_contrato<>'z' or centro <> 4200) "
                    descipcion = "APRENDIZ ADMINISTRACION GENERAL"
                    tipo_centro = "A4200"
            End Select
            sql = "SELECT val.mes, " & tipo_consulta & " " & _
                          " FROM Jjv_valort val " & _
                                     where & _
                             " group by val.mes   "

            comando.CommandType = CommandType.Text
            conn = objConexion.abrirConexion
            comando.Connection = conn
            comando.CommandText = sql
            reader = comando.ExecuteReader
            dr = dt.NewRow
            dr("Desripciòn") = descipcion
            dr("centro") = tipo_centro
            While (reader.Read)
                dr(MonthName(reader("mes"), True)) = reader("cantidad")
            End While
            dt.Rows.Add(dr)
            If (descipcion = "SERVICIOS GENERALES" Or descipcion = "APRENDIZ" Or descipcion = "DESPACHOS") Then
                dr = dt.NewRow
                dr("Desripciòn") = "Totales"
                dt.Rows.Add(dr)
            End If
            dr = dt.NewRow
            conn.Close()
            reader.Close()
        Next
        dr = dt.NewRow
        dr("Desripciòn") = "TOTAL GENERAL"
        dt.Rows.Add(dr)
        dt = add_totales_reales(dt, ano, tipo)
        restar_centros_repetidos(dt, ano)
        Dim view As DataView = New DataView(dt)
        'view.Sort = "Centro"
        Return (view)

    End Function

    Private Sub restar_centros_repetidos(ByRef dt As DataTable, ByVal ano As Integer)
        Dim sql As String = "SELECT  ano,mes,nit,count(distinct (val.centro) ) As cant " & _
                                    "FROM Jjv_valort val " & _
                                            "WHERE ano = " & ano & " and val.tipo_contrato<>'z' " & _
                                            "group by nit,ano,mes " & _
                                                "order by count(distinct (val.centro) )  "
        Dim cento_mov As Integer = 0
        Dim a As String = ""
        Dim dt_repetidos As DataTable = obj_op_simplesAd.listar_datatable(sql, "CORSAN")
        For i = 0 To dt_repetidos.Rows.Count - 1
            If dt_repetidos.Rows(i).Item("cant") Then
                If dt_repetidos.Rows(i).Item("cant") > 1 Then
                    cento_mov = centro_ult_mov(dt_repetidos.Rows(i).Item("nit"), dt_repetidos.Rows(i).Item("ano"), dt_repetidos.Rows(i).Item("mes"))
                    For j = 2 To dt.Columns.Count - 1
                        If (dt.Columns(j).ColumnName) = MonthName(dt_repetidos.Rows(i).Item("mes"), True) Then
                            For k = 0 To dt.Rows.Count - 1
                                If IsNumeric(dt.Rows(k).Item("centro")) Then
                                    If dt.Rows(k).Item("centro") = cento_mov Then
                                        If dt_repetidos.Rows(i).Item("mes") = 7 Then
                                            dt.Rows(k).Item(dt.Columns(j).ColumnName) -= 1
                                            a = dt_repetidos.Rows(i).Item("nit")
                                            k = dt.Rows.Count - 1
                                        End If
                                    End If
                                End If
                            Next
                        End If
                    Next
                End If
            End If
        Next
    End Sub
    Private Function centro_ult_mov(ByVal nit As Integer, ByVal ano As Integer, ByVal mes As Integer) As Integer
        Dim sql As String = "SELECT centro " & _
                                "FROM Jjv_valort " & _
                                  "WHERE ano = " & ano & " And mes = " & mes & " And nit = " & nit & " " & _
                                            "group by centro "
        Dim centro As Integer = obj_op_simplesAd.consultValor(sql)
        Return centro
    End Function
    Public Function datos(ByVal nit As Integer, ByVal fecha As String) As Double
        Dim conn As New SqlConnection
        Dim resp As Double
        Dim objConexion As New Conexion
        Dim reader As SqlDataReader
        Dim comando As New SqlCommand
        conn = objConexion.abrirConexion
        comando.Connection = conn
        comando.CommandType = CommandType.Text
        comando.CommandText = ("(SELECT  " & _
                                   "CASE " & _
                                        "  WHEN fecha_retiro >='2012-01-01' THEN centro  " & _
                                        " WHEN fecha_retiro is  null THEN centro  " & _
                                   "  End " & _
                                       "FROM y_personal_contratos where nit = 1036631617)")
        reader = comando.ExecuteReader
        If reader.Read Then
            If IsDBNull(reader(0)) Then
            Else
                resp = reader(0)
            End If

        End If
        conn.Close()
        Return resp

    End Function
    Public Function cargar_usuarios(ByVal mes As Integer, ByVal ano As Integer) As String()
        Dim objConexion As New Conexion
        Dim reader As SqlDataReader
        Dim vec_usu(300) As String
        Dim comando As New SqlCommand
        Dim k As Double = 0
        comando.CommandType = CommandType.Text
        Dim conn As New SqlConnection
        conn = objConexion.abrirConexion
        comando.Connection = conn
        Dim sql As String = "Select nit  from Jjv_nom_dat_liq where ano = " & ano & " and mes = " & mes & " group by mes,nit"
        comando.CommandText = (sql)
        reader = comando.ExecuteReader
        While (reader.Read)
            If IsDBNull(reader(0)) Then
            Else
                vec_usu(k) = reader(0)
                k = k + 1
            End If
        End While
        conn.Close()
        Return vec_usu
    End Function

    Public Function const_tabla_var(ByVal ano As Integer, ByVal mes As Integer) As DataTable
        Dim conn As New SqlConnection
        Dim reader As SqlDataReader
        Dim comando As New SqlCommand
        Dim objConexion As New Conexion
        Dim dt As New DataTable
        Dim fec As Date = DateAdd("m", -1, ano & "-" & mes & "-01")
        dt.Columns.Add("Desripciòn")
        dt.Columns.Add("Variación", GetType(Int64))
        Dim sql As String = ""
        comando.CommandType = CommandType.Text
        conn = objConexion.abrirConexion
        comando.Connection = conn
        sql = "SELECT mes, ano " & _
                    "from Jjv_valort val " & _
                        "WHERE (val.mes = " & mes & " )AND (val.ano = " & ano & " OR val.ano = " & ano - 1 & " OR val.ano = " & ano - 2 & " OR val.ano = " & ano - 3 & " ) OR  (val.mes = " & fec.Month & " AND val.ano = " & fec.Year & " ) " & _
                           " GROUP BY mes, ano  " & _
                                  "ORDER BY val.ano DESC,val.mes DESC"
        comando.CommandText = sql
        reader = comando.ExecuteReader
        While (reader.Read)
            dt.Columns.Add((MonthName(reader("mes"), True)) & "-" & reader("ano"), GetType(Int64))
        End While
        conn.Close()
        reader.Close()
        Return dt
    End Function
    Public Function vec_varianza(ByVal ano As Integer, ByVal tipo As String, ByVal mes As Integer) As Double()
        Dim conn As New SqlConnection
        Dim reader As SqlDataReader
        Dim comando As New SqlCommand
        Dim objConexion As New Conexion
        Dim codigo As String = ""
        Dim sql As String = ""
        Dim where As String = """"
        Dim tipo_consulta As String = ""
        Dim vec(29) As Double
        Dim j As Integer = 0
        Select Case tipo
            Case "Personal"
                tipo_consulta = "COUNT (distinct val.nit )As cantidad "
            Case "Horas"
                tipo_consulta = "SUM(val.tHoras) As cantidad "
            Case "Salario"
                tipo_consulta = "SUM(val.valor) As cantidad "

        End Select
        For i = 1 To 25
            where = "WHERE ano = " & ano - 1 & " AND mes = " & mes & " AND "

            Select Case i
                Case 1
                    where = where & "val.centro like '41%' and val.tipo_contrato<>'z' AND val.nit not in (SELECT  nit from Jjv_valort WHERE ano = val.ano and mes =val.mes AND centro like ('41%') and tipo_contrato='z'  )"
                Case 2
                    where = where & "val.centro like '41%' and val.tipo_contrato='z' AND val.nit not in (SELECT  nit from Jjv_valort WHERE ano =val.ano and mes =val.mes AND centro like ('41%')  and tipo_contrato<>'z' ) "

                Case 3
                    where = where & "val.centro like '11%' and val.tipo_contrato<>'z' "

                Case 4
                    where = where & "val.centro like '12%' and val.tipo_contrato<>'z'"

                Case 5
                    where = where & "val.centro like '31%' and val.tipo_contrato<>'z' AND val.nit not in (SELECT  nit from Jjv_valort WHERE ano  =val.ano and mes =val.mes  and (tipo_contrato='z')  ) "

                Case 6
                    where = where & "val.centro like '31%' and val.tipo_contrato='z' AND val.nit not in (SELECT  nit from Jjv_valort WHERE ano =val.ano and mes =val.mes and tipo_contrato<>'z' ) "

                Case 7
                    where = where & "val.centro like '32%' and val.tipo_contrato<>'z'"
                Case 8
                    where = where & "val.centro like '21%' and val.tipo_contrato<>'z'"
                Case 9
                    where = where & "val.centro like '22%' and val.tipo_contrato<>'z'"

                Case 10
                    where = where & "val.centro like '23%' and val.tipo_contrato<>'z'"

                Case 11
                    where = where & "val.centro like '24%' and val.tipo_contrato<>'z' "

                Case 12
                    where = where & "val.centro like '25%' and val.tipo_contrato<>'z'"

                Case 13
                    where = where & "val.centro like '26%' and val.tipo_contrato<>'z'"

                Case 14
                    where = where & "val.centro like '28%' and val.tipo_contrato<>'z'"

                Case 15
                    where = where & "val.centro like '52%' and val.tipo_contrato<>'z'"

                Case 16
                    where = where & "val.centro like '38%' and val.tipo_contrato<>'z'"

                Case 17
                    where = where & "val.centro like '62%' and val.tipo_contrato<>'z'"

                Case 18
                    where = where & "val.centro like '64%' and val.tipo_contrato<>'z'"

                Case 19
                    where = where & "val.centro in(2100,2200,2300,2400,2500,2600,2800,3800,5200,6200,6400) and val.tipo_contrato<>'z' AND val.nit not in (SELECT  nit from Jjv_valort WHERE ano =val.ano and mes =val.mes AND val.centro in(2100,2200,2300,2400,2500,2600,2800,3800,5200,6200,6400) and val.tipo_contrato <> 'z' ) "

                Case 20
                    where = where & "val.centro like '27%' and val.tipo_contrato<>'z'"

                Case 21
                    where = where & "val.centro like '43%' and val.tipo_contrato<>'z' AND val.nit not in (SELECT  nit from Jjv_valort WHERE ano =val.ano and mes =val.mes AND centro like ('43%')  and tipo_contrato='z') "

                Case 22
                    where = where & "val.centro like '43%' and val.tipo_contrato='z' AND val.nit not in (SELECT  nit from Jjv_valort WHERE ano =val.ano and mes =val.mes AND centro like ('43%')  and tipo_contrato<>'z') "

                Case 23
                    where = where & "val.centro like '35%' and val.tipo_contrato<>'z'"

                Case 24
                    where = where & "val.centro like '42%' and val.tipo_contrato<>'Z'  AND val.nit not in (SELECT  nit from Jjv_valort WHERE ano =val.ano and mes =val.mes AND centro like ('42%')  and tipo_contrato='z' or centro <> 4200 ) "

                Case 25
                    where = where & "val.centro like '42%' and val.tipo_contrato='Z'  AND val.nit not in (SELECT  nit from Jjv_valort WHERE ano =val.ano and mes =val.mes AND centro like ('42%')  and tipo_contrato<>'z' or centro <> 4200) "

            End Select
            sql = "SELECT val.mes, " & tipo_consulta & " " & _
                          " FROM Jjv_valort val " & _
                                     where & _
                             " group by val.mes   "

            comando.CommandType = CommandType.Text
            conn = objConexion.abrirConexion
            comando.Connection = conn
            comando.CommandText = sql
            reader = comando.ExecuteReader
            If (reader.Read) Then
                vec(j) = reader("cantidad")

            End If
            j += 1
            conn.Close()
            reader.Close()
        Next

        Return (vec)

    End Function
    Public Function listar_variacion(ByVal ano As Integer, ByVal tipo As String, ByVal mes As Integer) As DataView
        Dim conn As New SqlConnection
        Dim reader As SqlDataReader
        Dim comando As New SqlCommand
        Dim objConexion As New Conexion
        Dim dr As DataRow
        Dim codigo As String = ""
        Dim sql As String = ""
        Dim dt As DataTable
        Dim fec As Date = DateAdd("m", -1, ano & "-" & mes & "-01")
        dt = const_tabla_var(ano, mes)
        Dim centro_aux As String = ""
        Dim descipcion As String = ""
        Dim where As String = """"
        Dim tipo_consulta As String = ""
        Select Case tipo
            Case "Personal"
                tipo_consulta = "COUNT (distinct val.nit )As cantidad "
            Case "Horas"
                tipo_consulta = "SUM(val.tHoras) As cantidad "
            Case "Salario"
                tipo_consulta = "SUM(val.valor) As cantidad "

        End Select

        For i = 1 To 26
            where = "WHERE ((val.mes = " & mes & " AND val.ano = " & ano & ")OR  (val.mes = " & mes & " AND val.ano = " & ano - 1 & ") OR (val.mes = " & mes & " AND val.ano = " & ano - 2 & ")OR  (val.mes = " & mes & " AND val.ano = " & ano - 3 & ") OR  (val.mes = " & fec.Month & " AND val.ano = " & fec.Year & ")) AND "
            Select Case i
                Case 1
                    where = where & "val.centro like '41%' and val.tipo_contrato<>'z' AND val.nit not in (SELECT  nit from Jjv_valort WHERE ano = val.ano and mes =val.mes AND centro like ('41%') and tipo_contrato='z'  )"
                    descipcion = "ADMINISTRACION PRODUCCION"
                Case 2
                    where = where & "val.centro like '41%' and val.tipo_contrato='z' AND val.nit not in (SELECT  nit from Jjv_valort WHERE ano =val.ano and mes =val.mes AND centro like ('41%')  and tipo_contrato<>'z' ) "
                    descipcion = "APRENDIZ  ADMINISTRACION PRODC."
                Case 3
                    where = where & "val.centro like '11%' and val.tipo_contrato<>'z' "
                    descipcion = "COMPRAS Y SUMINISTROS"
                Case 4
                    where = where & "val.centro like '12%' and val.tipo_contrato<>'z'"
                    descipcion = "ALMACEN TECNICO"
                Case 5
                    where = where & "val.centro like '31%' and val.tipo_contrato<>'z' AND val.nit not in (SELECT  nit from Jjv_valort WHERE ano  =val.ano and mes =val.mes  and (tipo_contrato='z')  ) "
                    descipcion = "MANTENIMIENTO"
                Case 6
                    where = where & "val.centro like '31%' and val.tipo_contrato='z' AND val.nit not in (SELECT  nit from Jjv_valort WHERE ano =val.ano and mes =val.mes and tipo_contrato<>'z' ) "
                    descipcion = "APRENDIZ MANTENIMEINTO"
                Case 7
                    where = where & "val.centro like '32%' and val.tipo_contrato<>'z'"
                    descipcion = "SERVICIOS GENERALES"
                Case 8
                    where = where & "val.centro like '21%' and val.tipo_contrato<>'z'"
                    descipcion = "TREFILACION"
                Case 9
                    where = where & "val.centro like '22%' and val.tipo_contrato<>'z'"
                    descipcion = "HORNOS RECOCIDOS"
                Case 10
                    where = where & "val.centro like '23%' and val.tipo_contrato<>'z'"
                    descipcion = "PUNTILLERIA"
                Case 11
                    where = where & "val.centro like '24%' and val.tipo_contrato<>'z' "
                    descipcion = "EMPAQUE PUNTILLERIA"
                Case 12
                    where = where & "val.centro like '25%' and val.tipo_contrato<>'z'"
                    descipcion = "TORNILLERIA"
                Case 13
                    where = where & "val.centro like '26%' and val.tipo_contrato<>'z'"
                    descipcion = "EMPAQUE TORNILLERIA"
                Case 14
                    where = where & "val.centro like '28%' and val.tipo_contrato<>'z'"
                    descipcion = "PLANTA GALVANIZADO"
                Case 15
                    where = where & "val.centro like '52%' and val.tipo_contrato<>'z'"
                    descipcion = "PLANTA ALAMBRE GALVANIZADO"
                Case 16
                    where = where & "val.centro like '38%' and val.tipo_contrato<>'z'"
                    descipcion = "ALAMBRE GALV. POR INMERSION"
                Case 17
                    where = where & "val.centro like '62%' and val.tipo_contrato<>'z'"
                    descipcion = "TRATAMIENTOS TERMICOS"
                Case 18
                    where = where & "val.centro like '64%' and val.tipo_contrato<>'z'"
                    descipcion = "MAQUINA DE PUAS"
                Case 19
                    where = where & "val.centro in(2100,2200,2300,2400,2500,2600,2800,3800,5200,6200,6400) and val.tipo_contrato='z' AND val.nit not in (SELECT  nit from Jjv_valort WHERE ano =val.ano and mes =val.mes AND val.centro in(2100,2200,2300,2400,2500,2600,2800,3800,5200,6200,6400) and val.tipo_contrato <> 'z' ) "
                    descipcion = "APRENDIZ"
                Case 20
                    where = where & "val.centro like '27%' and val.tipo_contrato<>'z'"
                    descipcion = "CONTROL DESPERDICIOS"
                Case 21
                    where = where & "val.centro like '43%' and val.tipo_contrato<>'z' AND val.nit not in (SELECT  nit from Jjv_valort WHERE ano =val.ano and mes =val.mes AND centro like ('43%')  and tipo_contrato='z') "
                    descipcion = "VENTAS"
                Case 22
                    where = where & "val.centro like '43%' and val.tipo_contrato='z' AND val.nit not in (SELECT  nit from Jjv_valort WHERE ano =val.ano and mes =val.mes AND centro like ('43%')  and tipo_contrato<>'z') "
                    descipcion = "APRENDIZ VENTAS"
                Case 23
                    where = where & "val.centro like '35%' and val.tipo_contrato<>'z'"
                    descipcion = "DESPACHOS"
                Case 24
                    where = where & "val.centro like '42%' and val.tipo_contrato<>'Z'  AND val.nit not in (SELECT  nit from Jjv_valort WHERE ano =val.ano and mes =val.mes AND centro like ('42%')  and tipo_contrato='z' or centro <> 4200 ) "
                    descipcion = "ADMINISTRACION GENERAL"
                Case 25
                    where = where & "val.centro like '42%' and val.tipo_contrato='Z'  AND val.nit not in (SELECT  nit from Jjv_valort WHERE ano =val.ano and mes =val.mes AND centro like ('42%')  and tipo_contrato<>'z' or centro <> 4200) "
                    descipcion = "APRENDIZ ADMINISTRACION GENERAL"
                Case 26
                    where = where & "val.centro like '45%' and val.tipo_contrato='z' AND val.nit not in (SELECT  nit from Jjv_valort WHERE ano =val.ano and mes =val.mes AND centro like ('45%')  and tipo_contrato<>'z') "
                    descipcion = "AUXILIARES PORTERIA"
            End Select
            sql = "SELECT val.mes, " & tipo_consulta & " ,val.ano " & _
                          " FROM Jjv_valort val " & _
                                     where & _
                             " group by val.mes  ,val.ano "

            comando.CommandType = CommandType.Text
            conn = objConexion.abrirConexion
            comando.Connection = conn
            comando.CommandText = sql
            reader = comando.ExecuteReader
            dr = dt.NewRow
            dr("Desripciòn") = descipcion
            While (reader.Read)

                dr((MonthName(reader("mes"), True)) & "-" & reader("ano")) = reader("cantidad")

            End While
            dt.Rows.Add(dr)
            If (descipcion = "SERVICIOS GENERALES" Or descipcion = "APRENDIZ" Or descipcion = "DESPACHOS") Then
                dr = dt.NewRow
                dr("Desripciòn") = "Totales"
                dt.Rows.Add(dr)
            End If
            dr = dt.NewRow
            conn.Close()
            reader.Close()
        Next
        dr = dt.NewRow
        dr("Desripciòn") = "TOTAL GENERAL"
        dt.Rows.Add(dr)
        Dim view As DataView = New DataView(dt)
        'view.Sort = "Centro"
        Return (view)

    End Function

    Public Function add_totales_reales(ByVal dt As DataTable, ByVal ano As Integer, ByVal tipo As String) As DataTable
        Dim conn As New SqlConnection
        Dim reader As SqlDataReader
        Dim comando As New SqlCommand
        Dim objConexion As New Conexion
        Dim dr As DataRow
        Select Case tipo
            Case "Personal"
                tipo = "COUNT (distinct val.nit )As cantidad "
            Case "Horas"
                tipo = "SUM(val.tHoras) As cantidad "
            Case "Salario"
                tipo = "SUM(val.valor) As cantidad "

        End Select
        Dim sql As String = "SELECT  MONTH (liq.fecha ) As mes, YEAR (liq.fecha)As ano, COUNT ( distinct  liq.nit)as cantidad " & _
                                 "FROM y_liquidacion liq " & _
                                        "WHERE(Year(liq.fecha) = " & ano & ") " & _
                                            "GROUP BY  MONTH (liq.fecha ),YEAR (liq.fecha) " & _
                                                 "ORDER BY MONTH (liq.fecha )"
        comando.CommandType = CommandType.Text
        conn = objConexion.abrirConexion
        comando.Connection = conn
        comando.CommandText = sql
        reader = comando.ExecuteReader
        dr = dt.NewRow
        dr("Desripciòn") = "TOTAL REAL"
        While (reader.Read)
            For i = 0 To dt.Columns.Count - 1
                If (dt.Columns(i).ColumnName = MonthName(reader("mes"), True)) Then
                    dr(MonthName(reader("mes"), True)) = reader("cantidad")
                End If
            Next
        End While
        dt.Rows.Add(dr)
        'dr = dt.NewRow
        'dr("Desripciòn") = "VARIACIÓN EN CENTRO DE COSTOS"
        'dt.Rows.Add(dr)
        Return dt
    End Function

End Class
