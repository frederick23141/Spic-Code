Imports System.Data.SqlClient
Imports System.Data
Imports entidadNegocios
Imports System.Data.SqlServerCe
Public Class Ing_prod_ad
    Private conn As New SqlConnection
    Public Function listar_datatable(ByVal cadena As String, ByVal db As String) As DataTable
        Dim objConexion As New Conexion
        If (db = "CORSAN") Then
            conn = objConexion.abrirConexion
        ElseIf (db = "PRODUCCION") Then
            conn = objConexion.abrirConexion_prod
        ElseIf (db = "CONTROL") Then
            conn = objConexion.abrirConexionControl
        End If
        Dim dt As New DataTable
        Dim DA As New SqlDataAdapter(cadena, conn)
        DA.SelectCommand.CommandTimeout = 900
        DA.Fill(dt)
        conn.Close()
        Return dt
    End Function

    Public Function listar_Estado(ByVal cadena As String, ByVal db As String) As String
        Dim objConexion As New Conexion
        Dim comando As New SqlCommand
        If (db = "CORSAN") Then
            conn = objConexion.abrirConexion
        ElseIf (db = "PRODUCCION") Then
            conn = objConexion.abrirConexion_prod
        ElseIf (db = "CONTROL") Then
            conn = objConexion.abrirConexionControl
        End If

        Dim resp As String = 0
        Dim reader As SqlDataReader
        comando.Connection = conn
        comando.CommandType = CommandType.Text
        comando.CommandText = (cadena)
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
    Public Function consultar_valor(ByVal sql As String, ByVal db As String) As String
        Dim objConexion As New Conexion
        Dim comando As New SqlCommand
        If (db = "CORSAN") Then
            conn = objConexion.abrirConexion
        ElseIf (db = "PRODUCCION") Then
            conn = objConexion.abrirConexion_prod
        ElseIf (db = "CONTROL") Then
            conn = objConexion.abrirConexionControl
        End If
        Dim resp As String = 0
        Dim reader As SqlDataReader
        comando.Connection = conn
        comando.CommandType = CommandType.Text
        comando.CommandText = (sql)
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
    Public Function ejecutar(ByVal Sql As String, ByVal db As String) As Integer
        Dim resp As Integer = 0
        Try
            Dim objConexion As New Conexion
            Dim comando1 As New System.Data.SqlClient.SqlCommand
            If (db = "CORSAN") Then
                conn = objConexion.abrirConexion
            ElseIf (db = "PRODUCCION") Then
                conn = objConexion.abrirConexion_prod
            End If
            comando1.CommandType = System.Data.CommandType.Text
            comando1.Connection = conn
            comando1.CommandText = Sql
            resp = (comando1.ExecuteNonQuery())
        Catch ex As Exception
            MsgBox(ex.Message.ToString & "error")
        Finally

        End Try
        conn.Close()
        Return resp
    End Function

    Public Function listar_consulta(ByVal sql As String) As DataTable
        Dim objConexion As New Conexion
        conn = objConexion.abrirConexion_prod
        Dim dt As New DataTable
        Dim DA As New SqlDataAdapter(sql, conn)
        DA.Fill(dt)
        conn.Close()
        Return dt
    End Function
    Public Function vec_paros(ByVal sql As String, ByVal tamano As Integer) As Object()
        Dim vec(tamano) As Object
        Dim objConexion As New Conexion
        Dim comando As New SqlCommand
        Dim resp As Double = 0
        Dim reader As SqlDataReader
        conn = objConexion.abrirConexion_prod
        comando.Connection = conn
        comando.CommandType = CommandType.Text
        comando.CommandText = (sql)
        reader = comando.ExecuteReader
        If reader.Read Then
            If IsDBNull(reader(0)) Then
            Else
                For i = 0 To tamano
                    vec(i) = reader(i)
                Next

            End If
        End If
        conn.Close()
        Return vec
    End Function
    Public Function mat_paros(ByVal sql As String, ByVal tamano As Integer) As Object(,)
        Dim mat(tamano, 1) As Object
        Dim objConexion As New Conexion
        Dim comando As New SqlCommand
        Dim resp As Double = 0
        Dim reader As SqlDataReader
        Dim s As String = ""
        conn = objConexion.abrirConexion_prod
        comando.Connection = conn
        comando.CommandType = CommandType.Text
        comando.CommandText = (sql)
        reader = comando.ExecuteReader
        If reader.Read Then
            If IsDBNull(reader(0)) Then
            Else
                For i = 0 To tamano
                    mat(i, 0) = reader(i)
                    s = reader.GetName(i)
                    mat(i, 1) = reader.GetName(i)
                Next

            End If
        End If
        conn.Close()
        Return mat
    End Function
    Public Function vec_dias_kilos(ByVal sql As String, ByVal dias As Integer) As Object(,)
        Dim mat(dias, 1) As Object
        Dim objConexion As New Conexion
        Dim comando As New SqlCommand
        Dim resp As Double = 0
        Dim reader As SqlDataReader
        Dim i As Integer = 0
        conn = objConexion.abrirConexion_prod
        comando.Connection = conn
        comando.CommandType = CommandType.Text
        comando.CommandText = (sql)
        reader = comando.ExecuteReader
        While reader.Read
            If IsDBNull(reader(0)) Then
            Else
                mat(i, 0) = reader(0)
                mat(i, 1) = reader(1)
                i += 1
            End If
        End While
        conn.Close()
        Return mat
    End Function
    Public Function vec_dias_mes_kilos(ByVal sql As String, ByVal dias As Integer) As Object(,)
        Dim mat(dias, 2) As Object
        Dim objConexion As New Conexion
        Dim comando As New SqlCommand
        Dim resp As Double = 0
        Dim reader As SqlDataReader
        Dim i As Integer = 0
        conn = objConexion.abrirConexion_prod
        comando.Connection = conn
        comando.CommandType = CommandType.Text
        comando.CommandText = (sql)
        reader = comando.ExecuteReader
        While reader.Read
            If IsDBNull(reader(0)) Then
            Else
                mat(i, 0) = reader(0)
                mat(i, 1) = reader(1)
                mat(i, 2) = reader(2)
                i += 1
            End If
        End While
        conn.Close()
        Return mat
    End Function
    Public Function vec_datos(ByVal sql As String, ByVal cant As Integer) As Object()
        Dim vec(cant) As Object
        Dim objConexion As New Conexion
        Dim comando As New SqlCommand
        Dim resp As Double = 0
        Dim reader As SqlDataReader
        Dim i As Integer = 0
        conn = objConexion.abrirConexion_prod
        comando.Connection = conn
        comando.CommandType = CommandType.Text
        comando.CommandText = (sql)
        reader = comando.ExecuteReader
        If (reader.Read) Then
            vec(i) = reader(i)
            i += 1
        End If
        conn.Close()
        Return vec
    End Function
    Public Function efic_trfilacion(ByVal fec_ini As String, ByVal fec_fin As String) As DataView
        Dim conn As New SqlConnection
        Dim reader As SqlDataReader
        Dim comando As New SqlCommand
        Dim objConexion As New Conexion
        Dim dt As New DataTable
        Dim dr As DataRow
        Dim sql As String = ""
        Dim kil_prod As Double = 0
        Dim kil_esp As Double = 0
        Dim fecha_ant As Date
        Dim sw As Boolean = False
        Dim may_h_trab_dia As Double = 0
        Dim esp_dia As Double = 0
        Dim nit_ant As Double = 0
        Dim esp_ant As Double = 0
        Dim esp_dia_ant As Double = 0
        Dim cont As Integer = 0
        Dim nomb_ant As String = ""
        Dim unico_en_dia As Boolean = False   'bandera para saber si el registro es el unico en el dia
        dt.Columns.Add("Operario")
        dt.Columns.Add("Maquina")
        dt.Columns.Add("Pxn", GetType(Int64))
        dt.Columns.Add("Esperada", GetType(Int64))
        dt.Columns.Add("Eficiencia", GetType(Int64))
        sql = "SELECT  ter.nombres ,ter.nit ,prod.fecha ,horas_trab,prod.kil_esperado ,SUM (prod.alambron+prod.reproceso )as Pxn " & _
                "FROM J_prod_trefilacion prod, J_Maquinas maq,CORSAN.dbo.terceros ter " & _
                  "WHERE fecha >='" & fec_ini & "' and fecha <= '" & fec_fin & "' AND maq.codigoM = prod.maquina AND ter.nit = prod.nit " & _
                       "GROUP BY ter.nombres ,prod.fecha ,horas_trab,prod.kil_esperado ,ter.nit  " & _
                           "ORDER BY ter.nombres,prod.fecha"
        comando.CommandType = CommandType.Text
        conn = objConexion.abrirConexion_prod
        comando.Connection = conn
        comando.CommandText = sql
        reader = comando.ExecuteReader
        While (reader.Read)
            If (sw = False) Then
                nit_ant = reader("nit")
                nomb_ant = reader("nombres")
                fecha_ant = reader("fecha")
                may_h_trab_dia = reader("horas_trab")
                esp_ant = reader("kil_esperado")
                sw = True
            End If
            If (nit_ant <> reader("nit")) Then
                dr = dt.NewRow
                dr("Operario") = nomb_ant
                dr("Maquina") = maqu_may_horas(nit_ant, fec_ini, fec_fin, "J_prod_trefilacion")
                dr("Pxn") = kil_prod
                If (cont = 0) Then
                    kil_esp += esp_ant
                Else
                    kil_esp += esp_dia
                End If
                dr("Esperada") = kil_esp
                dr("Eficiencia") = (kil_prod / kil_esp) * 100
                dt.Rows.Add(dr)
                kil_prod = 0
                nit_ant = reader("nit")
                nomb_ant = reader("nombres")
                fecha_ant = reader("fecha")
                may_h_trab_dia = reader("horas_trab")
                esp_dia = 0
                kil_esp = 0
            End If
            If (fecha_ant = reader("fecha")) Then
                If (reader("horas_trab") >= may_h_trab_dia) Then
                    esp_dia = reader("kil_esperado")
                    may_h_trab_dia = reader("horas_trab")
                    cont += 1
                End If
            Else
                If (cont = 0) Then
                    kil_esp += esp_ant
                Else
                    kil_esp += esp_dia
                End If
                esp_ant = reader("kil_esperado")
                may_h_trab_dia = reader("horas_trab")
                fecha_ant = reader("fecha")
                cont = 0
            End If
            If (reader("Pxn") > 15000) Then
                kil_prod = 15000
            Else
                kil_prod += reader("Pxn")
            End If

        End While
        dr = dt.NewRow
        dr("Operario") = nomb_ant
        dr("Maquina") = maqu_may_horas(nit_ant, fec_ini, fec_fin, "J_prod_trefilacion")
        dr("Pxn") = kil_prod
        If (cont = 0) Then
            kil_esp += esp_ant
        Else
            kil_esp += esp_dia
        End If
        dr("Esperada") = kil_esp
        dr("Eficiencia") = (kil_prod / kil_esp) * 100
        dt.Rows.Add(dr)
        conn.Close()
        reader.Close()
        Dim view As DataView = New DataView(dt)
        Return (view)

    End Function
    Public Function efic_puas(ByVal fec_ini As String, ByVal fec_fin As String) As DataTable
        Dim dt As New DataTable
        Dim dr As DataRow
        Dim nit As Double = 0
        Dim pxn As Double = 0
        Dim prod_esp As Double = 0
        Dim objConexion As New Conexion
        Dim comando As New SqlCommand
        Dim resp As Double = 0
        Dim reader As SqlDataReader
        Dim sql As String = "SELECT ter.nit,ter.nombres As Operario,SUM (prod.roy_prod  )As Pxn,SUM (prod.roy_esp  )As Esperada " & _
                             "FROM j_prod_puas prod ,CORSAN.dbo.terceros ter " & _
                              "WHERE prod.fecha >='" & fec_ini & "' and prod.fecha <= '" & fec_fin & "'AND ter.nit = prod.nit  " & _
                               "GROUP by ter.nit,ter.nombres " & _
                                "ORDER BY ter.nombres"
        dt.Columns.Add("Operario")
        dt.Columns.Add("Maquina")
        dt.Columns.Add("Pxn", GetType(Int64))
        dt.Columns.Add("Esperada", GetType(Int64))
        dt.Columns.Add("Eficiencia", GetType(Int64))
        conn = objConexion.abrirConexion_prod
        comando.Connection = conn
        comando.CommandType = CommandType.Text
        comando.CommandText = (sql)
        reader = comando.ExecuteReader
        While reader.Read
            If IsDBNull(reader(0)) Then
            Else
                dr = dt.NewRow
                nit = reader("nit")
                pxn = reader("Pxn")
                prod_esp = reader("Esperada")
                dr("Operario") = reader("Operario")
                dr("Maquina") = maqu_may_horas(nit, fec_ini, fec_fin, "J_prod_puas")
                dr("Pxn") = pxn
                dr("Esperada") = prod_esp
                dr("Eficiencia") = (pxn / prod_esp) * 100
                dt.Rows.Add(dr)
            End If
        End While
        conn.Close()
        Return dt
    End Function
    Public Function efic_puntilleria(ByVal fec_ini As String, ByVal fec_fin As String) As DataTable
        Dim dt As New DataTable
        Dim dr As DataRow
        Dim nit As Double = 0
        Dim pxn As Double = 0
        Dim prod_esp As Double = 0
        Dim objConexion As New Conexion
        Dim comando As New SqlCommand
        Dim resp As Double = 0
        Dim reader As SqlDataReader
        Dim sql As String = "SELECT ter.nit,ter.nombres As Operario,SUM (prod.kilos_prod  )As Pxn,SUM (prod.kil_esperado  )As Esperada " & _
                             "FROM J_prod_puntilleria prod ,CORSAN.dbo.terceros ter " & _
                              "WHERE prod.fecha >='" & fec_ini & "' and prod.fecha <= '" & fec_fin & "'AND ter.nit = prod.nit  " & _
                               "GROUP by ter.nit,ter.nombres " & _
                                "ORDER BY ter.nombres"
        dt.Columns.Add("Operario")
        dt.Columns.Add("Maquina")
        dt.Columns.Add("Pxn", GetType(Int64))
        dt.Columns.Add("Esperada", GetType(Int64))
        dt.Columns.Add("Eficiencia", GetType(Int64))
        conn = objConexion.abrirConexion_prod
        comando.Connection = conn
        comando.CommandType = CommandType.Text
        comando.CommandText = (sql)
        reader = comando.ExecuteReader
        While reader.Read
            If IsDBNull(reader(0)) Then
            Else
                dr = dt.NewRow
                nit = reader("nit")
                pxn = reader("Pxn")
                prod_esp = reader("Esperada")
                dr("Operario") = reader("Operario")
                dr("Maquina") = maqu_may_horas(nit, fec_ini, fec_fin, "J_prod_puntilleria")
                dr("Pxn") = pxn
                dr("Esperada") = prod_esp
                dr("Eficiencia") = (pxn / prod_esp) * 100
                dt.Rows.Add(dr)
            End If
        End While
        conn.Close()
        Return dt
    End Function
    Public Function maqu_may_horas(ByVal nit As Double, ByVal fec_ini As String, ByVal fec_fin As String, ByVal tab_seccion As String) As String
        Dim maq As String = ""
        Dim objConexion As New Conexion
        Dim comando As New SqlCommand
        Dim resp As Double = 0
        Dim reader As SqlDataReader
        Dim sql As String = " SELECT SUM (prod.horas_trab )As Suma,maq.Nombre As maq " & _
                                 "FROM " & tab_seccion & " prod, J_Maquinas maq " & _
                                  "WHERE prod.maquina = maq.codigoM AND prod.fecha >= '" & fec_ini & "' AND fecha <= '" & fec_fin & "' AND nit = " & nit & "  " & _
                                   "GROUP BY maq.Nombre " & _
                                    "ORDER BY  SUM (prod.horas_trab ) desc"
        conn = objConexion.abrirConexion_prod
        comando.Connection = conn
        comando.CommandType = CommandType.Text
        comando.CommandText = (sql)
        reader = comando.ExecuteReader
        While reader.Read
            maq = reader("maq")
        End While
        conn.Close()
        Return maq
    End Function
    Public Function ExecuteSqlTransaction(ByVal listSql As List(Of Object), ByVal db As String) As Boolean
        Dim conn As New SqlConnection
        Dim resp As Boolean = False
        Dim objConexion As New Conexion
        Dim comando As New SqlCommand
        Dim sql As String = ""
        If (db = "CORSAN") Then
            conn = objConexion.abrirConexion
        ElseIf (db = "PRODUCCION") Then
            conn = objConexion.abrirConexion_prod
        End If
        Dim transaction As SqlTransaction
        transaction = conn.BeginTransaction("Insertar")
        comando.Connection = conn
        comando.Transaction = transaction
        Try
            For i As Integer = 0 To listSql.Count - 1 Step 1
                sql = (listSql(i))
                comando.CommandText = sql
                comando.ExecuteNonQuery()
            Next
            ' Attempt to commit the transaction.
            transaction.Commit()
            resp = True
        Catch ex As Exception
            Console.WriteLine("Commit Exception Type: {0}", ex.GetType())
            MsgBox("  Message: {0}" & ex.Message)
            Try
                transaction.Rollback()
            Catch ex2 As Exception
                Console.WriteLine("Rollback Exception Type: {0}", ex2.GetType())
                Console.WriteLine("  Message: {0}", ex2.Message)
            End Try
        End Try
        conn.Close()
        Return resp
    End Function
    Public Function listaForm(ByVal consecutivoPpal As String, ByVal tam As Integer, ByVal sql As String) As List(Of Object)
        Dim objConexion As New Conexion
        Dim reader As SqlDataReader
        Dim lista_valores As New List(Of Object)
        Dim comando As New SqlCommand
        Dim conn As New SqlConnection
        comando.CommandType = CommandType.Text
        conn = objConexion.abrirConexion_prod
        comando.Connection = conn
        comando.CommandText = (Sql)
        reader = comando.ExecuteReader
        If (reader.Read) Then
            For i = 0 To tam - 1
                lista_valores.Add(reader(i))
            Next
        End If
        conn.Close()
        Return lista_valores
    End Function
    Public Function listaRegistro(ByVal sql As String, ByVal db As String, ByVal numCol As Integer) As List(Of Object)
        Dim objConexion As New Conexion
        Dim reader As SqlDataReader
        Dim lista_valores As New List(Of Object)
        Dim comando As New SqlCommand
        Dim conn As New SqlConnection
        comando.CommandType = CommandType.Text
        If (db = "CORSAN") Then
            conn = objConexion.abrirConexion
        ElseIf (db = "PRODUCCION") Then
            conn = objConexion.abrirConexion_prod
        End If
        comando.Connection = conn
        comando.CommandText = (sql)
        reader = comando.ExecuteReader
        If (reader.Read) Then
            For i = 0 To numCol
                If IsDBNull(reader(i)) Then
                    lista_valores.Add(0)
                Else
                    lista_valores.Add(reader(i))
                End If
            Next
        End If
        conn.Close()
        Return lista_valores
    End Function
    Public Function return_objOrdenProdEn(ByVal cod_orden As String, ByVal cod_det As String) As OrdenProdEn
        Dim objOrdenProdEn As New OrdenProdEn
        Dim sql As String = "SELECT  fecha_prod,maquina,origen ,calidad,diametro,velocidad,diam_min ,prod_final,descripcion " & _
                                    "FROM J_v_orden_prod_det_tref " & _
                                "WHERE cod_orden='" & cod_orden & "' AND id_detalle = " & cod_det
        Dim objConexion As New Conexion
        Dim reader As SqlDataReader
        Dim comando As New SqlCommand
        Dim conn As New SqlConnection
        comando.CommandType = CommandType.Text
        conn = objConexion.abrirConexion_prod
        comando.Connection = conn
        comando.CommandText = (sql)
        reader = comando.ExecuteReader
        If (reader.Read) Then
            objOrdenProdEn.fecha = "dogijdoifgjodfgdfg"
            objOrdenProdEn.maquina = reader("maquina")
            objOrdenProdEn.origen = reader("origen")
            objOrdenProdEn.calidad = reader("calidad")
            objOrdenProdEn.diam_alambron = reader("diametro")
            objOrdenProdEn.velocidad = reader("velocidad")
            objOrdenProdEn.cod_prod_final = reader("diam_min")
            objOrdenProdEn.prod_final_desc = reader("prod_final")
        End If
        conn.Close()
        Return objOrdenProdEn
    End Function
    Public Function return_objDetalleRollosEn(ByVal cod_orden As String, ByVal cod_det As String, ByVal num_rollo As String) As DetalleRollosEn
        Dim objDetalleRollosEn As New DetalleRollosEn
        Dim sql As String = "SELECT  id_rollo,peso " & _
                                    "FROM J_rollos_tref " & _
                                "WHERE cod_orden='" & cod_orden & "' AND id_detalle = " & cod_det & "AND id_rollo = " & num_rollo
        Dim objConexion As New Conexion
        Dim reader As SqlDataReader
        Dim comando As New SqlCommand
        Dim conn As New SqlConnection
        comando.CommandType = CommandType.Text
        conn = objConexion.abrirConexion_prod
        comando.Connection = conn
        comando.CommandText = (sql)
        reader = comando.ExecuteReader
        If (reader.Read) Then
            objDetalleRollosEn.numRollo = reader("id_rollo")
            objDetalleRollosEn.peso = reader("peso")
        End If
        conn.Close()
        Return objDetalleRollosEn
    End Function
    Public Function cargarObjCertCalidad(ByVal numero As Double) As FichaAlambEn
        Dim sql As String = "SELECT numero,fecha,nit,codigo,rec_real,res_real,procedencia,mat_prima,colada,cal_real,responsable,coordinador,nombres,descripcion,nomb_responsable,nomb_coordinador,desc_materia_prima,tot_peso,cal_est,res_est,rec_est,nomb_procedencia,numero_pedido " & _
                                        "FROM J_v_certif_calidad " & _
                                "WHERE numero = " & numero
        Dim objFichaAlambEn As New FichaAlambEn
        Dim objConexion As New Conexion
        Dim reader As SqlDataReader
        Dim comando As New SqlCommand
        Dim conn As New SqlConnection
        comando.CommandType = CommandType.Text
        conn = objConexion.abrirConexion_prod
        comando.Connection = conn
        comando.CommandText = (sql)
        reader = comando.ExecuteReader
        If (reader.Read) Then
            objFichaAlambEn.consecutivo = reader("numero")
            objFichaAlambEn.fecha = reader("fecha")
            objFichaAlambEn.nit = reader("nit")
            objFichaAlambEn.nombres = reader("nombres")
            objFichaAlambEn.codigo = reader("codigo")
            objFichaAlambEn.descripcion = reader("descripcion")
            objFichaAlambEn.rec_real = reader("rec_real")
            objFichaAlambEn.proc = reader("nomb_procedencia")
            objFichaAlambEn.responsable = reader("nomb_responsable")
            objFichaAlambEn.coordinador = reader("nomb_Coordinador")
            If Not IsDBNull(reader("tot_peso")) Then
                Dim pes As Double = Format(reader("tot_peso"), "#0.0")
                objFichaAlambEn.peso = pes
                objFichaAlambEn.total_peso = pes
            Else
                objFichaAlambEn.peso = 0
                objFichaAlambEn.total_peso = 0
            End If
            objFichaAlambEn.mat_prima = reader("mat_prima")
            objFichaAlambEn.calidad_real = reader("cal_real")
            objFichaAlambEn.calidad_est = reader("cal_est")
            If Not IsDBNull(reader("rec_est")) Then
                objFichaAlambEn.rec_est = reader("rec_est")
            Else
                objFichaAlambEn.rec_est = "N/A"
            End If
            If Not IsDBNull(reader("numero_pedido")) Then
                objFichaAlambEn.numero = reader("numero_pedido")
            Else
                objFichaAlambEn.numero = "0"
            End If
            objFichaAlambEn.resistencia_est = reader("res_est")
            objFichaAlambEn.desc_mat_prima = reader("desc_materia_prima")
        End If
        conn.Close()
        Return objFichaAlambEn
    End Function
    Public Function cargarObjRolloCalidad(ByVal numero As Double) As List(Of List(Of DetalleRollosEn))
        Dim listDetRollos As New List(Of DetalleRollosEn)
        Dim listDetRollos2 As New List(Of DetalleRollosEn)
        Dim listOfList As New List(Of List(Of DetalleRollosEn))
        Dim sql As String = "SELECT num_rollo,peso,colada,traccion " & _
                                        "FROM J_rollos_certificados " & _
                                "WHERE numero_cert = " & numero & _
                                " ORDER BY num_rollo"
        Dim objDetalleRollosEn As New DetalleRollosEn
        Dim objConexion As New Conexion
        Dim reader As SqlDataReader
        Dim comando As New SqlCommand
        Dim conn As New SqlConnection
        Dim i As Integer = 0
        comando.CommandType = CommandType.Text
        conn = objConexion.abrirConexion_prod
        comando.Connection = conn
        comando.CommandText = (sql)
        reader = comando.ExecuteReader
        While (reader.Read)
            objDetalleRollosEn.numRollo = reader("num_rollo")
            objDetalleRollosEn.peso = reader("peso")
            If IsDBNull(reader("colada")) And IsDBNull(reader("traccion")) Then
                objDetalleRollosEn.colada = 0
                objDetalleRollosEn.traccion = 0
            Else
                objDetalleRollosEn.colada = reader("colada")
                objDetalleRollosEn.traccion = reader("traccion")
            End If
            If (i <= 17) Then
                listDetRollos.Add(objDetalleRollosEn)
            Else
                listDetRollos2.Add(objDetalleRollosEn)
            End If
            objDetalleRollosEn = New DetalleRollosEn
            i += 1
        End While
        listOfList.Add(listDetRollos)
        listOfList.Add(listDetRollos2)
        conn.Close()
        Return listOfList
    End Function
    Public Function listaValores(ByVal sql As String, ByVal db As String, ByVal numCol As Integer) As List(Of Object)
        Dim objConexion As New Conexion
        Dim reader As SqlDataReader
        Dim lista_valores As New List(Of Object)
        Dim comando As New SqlCommand
        Dim conn As New SqlConnection
        comando.CommandType = CommandType.Text
        If (db = "CORSAN") Then
            conn = objConexion.abrirConexion
        ElseIf (db = "PRODUCCION") Then
            conn = objConexion.abrirConexion_prod
        End If
        comando.Connection = conn
        comando.CommandText = (sql)
        reader = comando.ExecuteReader
        While (reader.Read)
            If IsDBNull(reader(0)) Then
            Else
                For i = 0 To numCol
                    lista_valores.Add(reader(i))
                Next
            End If
        End While
        conn.Close()
        Return lista_valores
    End Function
    Public Function consultValor(ByVal sql As String, ByVal db As String) As String
        Dim resp As String = ""
        Dim comando As New System.Data.SqlClient.SqlCommand
        Dim conn As New SqlConnection
        Dim objConexion As New Conexion
        comando = New SqlCommand
        Dim i As Integer = 0
        Dim reader As SqlDataReader
        comando.CommandType = CommandType.Text
        If (db = "CORSAN") Then
            conn = objConexion.abrirConexion
        ElseIf (db = "PRODUCCION") Then
            conn = objConexion.abrirConexion_prod
        End If
        comando.Connection = conn
        comando.CommandText = (sql)
        reader = comando.ExecuteReader
        While (reader.Read)
            If Not IsDBNull(reader(0)) Then
                resp = reader(0)
            End If
        End While
        conn.Close()
        Return resp
    End Function
End Class