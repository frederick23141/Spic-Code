Imports entidadNegocios
Imports accesoDatos

Public Class Op_simpesLn
    Private obj_op_simplesAd As New Op_simplesAd
    Private objOperacionesDb As New OperacionesDb
    Public Function listar_datatable(ByVal sql As String, ByVal db As String) As DataTable
        Return obj_op_simplesAd.listar_datatable(sql, db)
    End Function
    Public Function lista(ByVal sql As String) As List(Of Object)
        Return obj_op_simplesAd.lista(sql)
    End Function
    Public Function validar_num_may(ByVal h_trab As Double, ByVal h_prog As Double) As Boolean
        Dim resp As Boolean = False
        If (h_trab > h_prog) Then
            resp = True
        End If
        Return resp
    End Function
    Public Function consultarVal(ByVal sql As String) As String
        Return obj_op_simplesAd.consultValor(sql)
    End Function
    Public Function matriz(ByVal sql As String, ByVal tamano As Integer, ByVal campos As Integer) As Object(,)
        Return obj_op_simplesAd.matriz(sql, tamano, campos)
    End Function
    Public Function calcDiasHabiles(ByVal fecIni As Date, ByVal fecFin As Date) As Integer
        Dim dif As Integer
        Dim fec As Date = fecIni
        dif = (fecFin - fecIni).Days
        For i = 1 To dif
            If Weekday(fec, vbMonday) = 6 Or Weekday(fec, vbMonday) = 7 Then
                dif -= 1
            End If
            fec = DateAdd(DateInterval.Day, 1, fec)
        Next
        Return dif
    End Function
    Public Function ExecuteSqlTransaction(ByVal listSql As List(Of Object)) As Boolean
        Return objOperacionesDb.ExecuteSqlTransaction(listSql)
    End Function
    Public Function ExecuteSqlTransactionTodo(ByVal listSql As List(Of Object), ByVal db As String) As Boolean
        Return objOperacionesDb.ExecuteSqlTransactionTodo(listSql, db)
    End Function
    Public Function listaOfListas(ByVal sql As String, ByVal db As String, ByVal numCol As Integer) As List(Of Object)
        Return obj_op_simplesAd.listaOfListas(sql, db, numCol)
    End Function
    Public Function listaBasesDatos(ByVal sql As String, ByVal db As String, ByVal numCol As Integer) As List(Of Object)
        Return obj_op_simplesAd.listaBasesDatos(sql, db, numCol)
    End Function
    Public Function cambiarFormatoFecha(ByVal fec As Date) As String
        Dim strFec As String = fec.Year & "-" & fec.Month & "-" & fec.Day
        Return strFec
    End Function
    Public Function ejecutar(ByVal Sql As String, ByVal db As String) As Integer
        Return obj_op_simplesAd.ejecutar(Sql, db)
    End Function
    Public Function validarCodigo(ByVal codigo As String) As Boolean
        Dim resp As String = consultarVal("SELECT codigo FROM referencias WHERE codigo = '" & codigo & "'")
        If (resp = "") Then
            Return False
        Else
            Return True
        End If
    End Function
    Public Function validarCodigoEstado(ByVal codigo As String) As Boolean
        Dim resp As String = consultarVal("select ref_anulada from referencias WHERE codigo = '" & codigo & "'")
        If (resp = "S") Then
            Return False
        Else
            Return True
        End If
    End Function
    Public Function crearDataTable(ByVal sql As String, ByVal db As String) As DataTable
        Return obj_op_simplesAd.crearDataTable(sql, db)
    End Function
    Public Function operacionSumaDtg(ByVal texto As String) As Double
        Dim valor As String = ""
        Dim valoresSum As String = ""
        For i = 0 To texto.Length - 1
            If (IsNumeric(texto(i)) Or texto(i) = "+") Then
                valor += texto(i)
            End If
        Next
        Dim total As Double
        Dim sw As Boolean = False
        If Not valor = "" Then
            For i = 0 To valor.Length - 1
                If (valor(i) = "+") Then
                    If (sw = False) Then
                        total = Convert.ToDouble(valoresSum)
                    Else
                        total += Convert.ToDouble(valoresSum)
                    End If
                    valoresSum = ""
                    sw = True
                Else
                    valoresSum &= valor(i)
                End If
            Next
            total += Convert.ToDouble(valoresSum)
        End If
        Return total

    End Function
    Public Function crearDataTableVariasCol(ByVal sql As String, ByVal db As String) As DataTable
        Return obj_op_simplesAd.crearDataTableVariasCol(sql, db)
    End Function
    Public Function existeEmpleado(ByVal nit As String) As Boolean
        Dim sql As String = "SELECT nit FROM V_nom_personal_Activo_con_maquila WHERE nit = '" & nit & "'"
        If (obj_op_simplesAd.consultValor(sql) = "") Then
            Return False
        Else
            Return True
        End If
    End Function
    Public Function consultarStock(ByVal codigo As String, ByVal bodega As Integer) As Double
        Dim resp As String
        Dim stock As Double = 0
        Dim sql As String = "SELECT stock,bodega " & _
                                    "FROM v_referencias_sto_hoy " & _
                                         "WHERE codigo = '" & codigo & "' and bodega = " & bodega & " "

        resp = objOperacionesDb.consultValor(sql, "CORSAN")
        If (resp <> "") Then
            stock = resp
        End If
        Return stock
    End Function
    Public Function return_objReferenciaEn(ByVal codigo As String) As ReferenciaEn
        Return objOperacionesDb.return_objReferenciaEn(codigo)
    End Function
    Public Function returnCorreosModulo(ByVal modulo As String) As String
        Dim resp As String
        Dim sql As String = "SELECT destinatarios_correo " & _
                                    "FROM J_spic_modulos " & _
                                         "WHERE  descripcion = '" & modulo & "'"
        resp = objOperacionesDb.consultValor(sql, "CORSAN")
        Return resp
    End Function
    Public Function ponerFechaUltEntReferencias(ByVal codigo As String) As Boolean
        Dim sql As String = "UPDATE referencias SET fec_ultima_entrada = GETDATE () WHERE codigo = '" & codigo & "'"
        If (objOperacionesDb.ejecutar(sql, "CORSAN") > 0) Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Function ponerFechaUltSalReferencias(ByVal codigo As String) As Boolean
        Dim sql As String = "UPDATE referencias SET fec_ultima_salida = GETDATE () WHERE codigo = '" & codigo & "'"
        If (objOperacionesDb.ejecutar(sql, "CORSAN") > 0) Then
            Return True
        Else
            Return False
        End If
    End Function
    Private Function planillaNoTrbajada(ByVal consecutivoPpal, ByVal consecutivoDetalle) As Boolean
        Dim sql As String = "SELECT nit FROM V_nom_personal_Activo_con_maquila WHERE cod_orden = " & consecutivoPpal & " AND id_detalle = " & consecutivoDetalle
        If (objOperacionesDb.consultValor(sql, "PRODUCCION") = "") Then
            Return False
        Else
            Return True
        End If
    End Function
    Public Function obtenerBodegaXcodigo(ByVal codigo As String) As String
        Dim resp = codigo(0)
        Return resp
    End Function
    Public Function returnDtMeses() As DataTable
        Dim dt As New DataTable
        Dim row As DataRow
        dt = New DataTable
        dt.Columns.Add("numMes")
        dt.Columns.Add("nombMes")
        row = dt.NewRow
        row("numMes") = 1
        row("nombMes") = "Enero"
        dt.Rows.Add(row)
        row = dt.NewRow
        row("numMes") = 2
        row("nombMes") = "Febrero"
        dt.Rows.Add(row)
        row = dt.NewRow
        row("numMes") = 3
        row("nombMes") = "Marzo"
        dt.Rows.Add(row)
        row = dt.NewRow
        row("numMes") = 4
        row("nombMes") = "Abril"
        dt.Rows.Add(row)
        row = dt.NewRow
        row("numMes") = 5
        row("nombMes") = "Mayo"
        dt.Rows.Add(row)
        row = dt.NewRow
        row("numMes") = 6
        row("nombMes") = "Junio"
        dt.Rows.Add(row)
        row = dt.NewRow
        row("numMes") = 7
        row("nombMes") = "Julio"
        dt.Rows.Add(row)
        row = dt.NewRow
        row("numMes") = 8
        row("nombMes") = "Agosto"
        dt.Rows.Add(row)
        row = dt.NewRow
        row("numMes") = 9
        row("nombMes") = "Septiembre"
        dt.Rows.Add(row)
        row = dt.NewRow
        row("numMes") = 10
        row("nombMes") = "Octubre"
        dt.Rows.Add(row)
        row = dt.NewRow
        row("numMes") = 11
        row("nombMes") = "Noviembre"
        dt.Rows.Add(row)
        row = dt.NewRow
        row("numMes") = 12
        row("nombMes") = "Diciembre"
        dt.Rows.Add(row)
        Return dt
    End Function
    Public Function cant_festivos(ByVal dia As Integer, ByVal mes As Integer, ByVal ano As Integer) As Integer
        Dim sql As String = "SELECT COUNT(dia) FROM J_dias_festivos WHERE mes = " & mes & " AND ano = " & ano & " AND dia <= " & dia
        Dim resp As String = obj_op_simplesAd.consultValor(sql)
        If (resp = "") Then
            Return 0
        Else
            Return resp
        End If
    End Function
    Public Function cant_festivos2(ByVal dia As Integer, ByVal mes As Integer, ByVal ano As Integer) As Integer
        Dim sql As String = "SELECT COUNT(dia) FROM J_dias_festivos2 WHERE mes = " & mes & " AND ano = " & ano & " AND dia <= " & dia
        Dim resp As String = obj_op_simplesAd.consultValor(sql)
        If (resp = "") Then
            Return 0
        Else
            Return resp
        End If
    End Function
    Public Function cant_festivos_mes(ByVal mes As Integer, ByVal ano As Integer) As Integer
        Dim sql As String = "SELECT COUNT(dia) FROM J_dias_festivos WHERE mes = " & mes & " AND ano = " & ano
        Dim resp As String = obj_op_simplesAd.consultValor(sql)
        If (resp = "") Then
            Return 0
        Else
            Return resp
        End If
    End Function
    Public Function cant_festivos_rango_dias(ByVal mes As Integer, ByVal ano As Integer, ByVal dia_ini As Integer, ByVal dia_fin As Integer) As Integer
        Dim sql As String = "SELECT COUNT(dia) FROM J_dias_festivos WHERE ano = " & ano & " and mes = " & mes & " and dia >= " & dia_ini & " AND dia <= " & dia_fin & ""
        Dim resp As String = obj_op_simplesAd.consultValor(sql)
        If (resp = "") Then
            Return 0
        Else
            Return resp
        End If
    End Function
    Public Function cant_festivos_rango_dias_d(ByVal mes As Integer, ByVal mesf As Integer, ByVal ano As Integer, ByVal dia_ini As Integer, ByVal dia_fin As Integer) As Integer
        Dim sql As String
        If mes = mesf Then
            sql = "SELECT COUNT(dia) FROM J_dias_festivos WHERE ano = " & ano & " and mes = " & mes & " and dia >= " & dia_ini & " AND dia <= " & dia_fin & ""
        Else
            sql = "WITH festivos as" & _
                  "(  " & _
                     " SELECT COUNT(dia) as dia FROM J_dias_festivos WHERE ano = 2017 and mes = " & mes & " and dia >= " & dia_ini & "" & _
                     " UNION ALL" & _
                     " SELECT COUNT(dia) as dia from J_dias_festivos WHERE ano = 2017 and mes =  " & mesf & " and dia <= " & dia_fin & "" & _
                  ")" & _
                   "SELECT SUM(dia) FROM FESTIVOS"
        End If
        Dim resp As String = obj_op_simplesAd.consultValor(sql)
        If (resp = "") Then
            Return 0
        Else
            Return resp
        End If
    End Function
    Public Function calcDiasHabilesVentas(ByVal fecIni As Date, ByVal fecFin As Date) As Integer
        Dim dif As Integer
#Disable Warning BC42024 ' Variable local sin usar: 'sql'.
        Dim sql As String
#Enable Warning BC42024 ' Variable local sin usar: 'sql'.
#Disable Warning BC42024 ' Variable local sin usar: 'fest'.
        Dim fest As String
#Enable Warning BC42024 ' Variable local sin usar: 'fest'.
        Dim fec As Date = fecIni
        dif = (fecFin - fecIni).Days + 1
        For i = 1 To dif
            If (Weekday(fec, vbMonday) = 6 Or Weekday(fec, vbMonday) = 7) Then
                dif -= 1
            End If
            fec = DateAdd(DateInterval.Day, 1, fec)
        Next
        Return dif
    End Function
    Public Function calcDiasHabilesProduccion(ByVal fecIni As Date, ByVal fecFin As Date) As Integer
        Dim dif As Integer
        Dim fec As Date = fecIni
        dif = (fecFin - fecIni).Days + 1
        For i = 1 To dif
            If (Weekday(fec, vbMonday) = 7) Then
                dif -= 1
            End If
            fec = DateAdd(DateInterval.Day, 1, fec)
        Next
        Return dif
    End Function
    Public Function consultarCantPend(ByVal codigo As String, ByVal bodega As String) As Double
        Dim sql As String = "SELECT  (SUM(pend.Cant_pedida)-SUM(pend.cantidad_despachada ))As cantidad   " & _
                                    " FROM V_pendientes_por_vendedor pend " & _
                                            " WHERE  pend.codigo = '" & codigo & "' AND bodega = " & bodega
        Dim resp As String = obj_op_simplesAd.consultValor(sql)
        If (resp = "") Then
            Return 0
        Else
            Return resp
        End If
    End Function
    Public Function existeNumeroPedido(ByVal numero As Double) As Boolean
        Dim sql As String = "SELECT numero FROM documentos_ped WHERE numero = " & numero
        If (objOperacionesDb.consultValor(sql, "CORSAN") = "") Then
            Return False
        Else
            Return True
        End If
    End Function
    Public Function modificar_script(ByVal sql_script As String, ByVal numero As Integer, ByVal consecutivo As Integer, ByVal desc_modulo As String, ByVal db As String) As Integer
        Return obj_op_simplesAd.modificar_script(sql_script, numero, consecutivo, desc_modulo, db)
    End Function

    Public Function modificar_estadoM(ByVal codigo As String, ByVal db As String) As String
        Return obj_op_simplesAd.modificar_estadomaquinas(codigo, db)
    End Function

    Public Function modificar_estadoMI(ByVal codigo As String, ByVal db As String) As String
        Return obj_op_simplesAd.modificar_estadomaquinasI(codigo, db)
    End Function

    Public Function modificar_estadoMP(ByVal codigo As String, ByVal db As String) As String
        Return obj_op_simplesAd.modificar_estadomaquinasP(codigo, db)
    End Function

    Public Function modificar_estadoMPN(ByVal codigo As String, ByVal paro As String, ByVal db As String) As String
        Return obj_op_simplesAd.modificar_estadomaquinasPN(codigo, paro, db)
    End Function




    Function consultValorTodo(sql As String, db As String) As String
        Return obj_op_simplesAd.consultValorTodo(sql, db)
    End Function
    Function verificar_conexion() As Boolean
        Return obj_op_simplesAd.verificar_conexion()
    End Function
    Public Function getDescripcionCodigo(ByVal codigo As String) As String
        Dim resp As String
        Dim sql As String = "SELECT descripcion " & _
                                    "FROM referencias " & _
                                         "WHERE  codigo = '" & codigo & "'"
        resp = objOperacionesDb.consultValor(sql, "CORSAN")
        Return resp
    End Function
    Public Function getIvaPorc() As Double
        Dim resp As Double
        Dim sql As String = "SELECT porcentaje " & _
                                    "FROM J_iva_porcentaje "
        resp = objOperacionesDb.consultValor(sql, "CORSAN")
        Return resp
    End Function
    Public Function guardar_imagen(ByVal img() As Byte, ByVal nit As Double) As Boolean
        Return obj_op_simplesAd.guardar_imagen(img, nit)
    End Function
    Public Function ExtraerImagen(ByVal nit As Double) As Byte()
        Return obj_op_simplesAd.ExtraerImagen(nit)
    End Function
    'Debe traer todo
    Public Function validarNit(ByVal nit As Double) As Boolean
        Dim sql As String = "select nit from V_nom_personal_Activo_con_maquila  WHERE nit = " & nit
        If (consultarVal(sql) <> "") Then
            Return True
        Else
            Return False
        End If

    End Function
    Public Function validarNitdes(ByVal nit As Double) As Boolean
        Dim sql As String = "select nit from terceros  WHERE nit = " & nit
        If (consultarVal(sql) <> "") Then
            Return True
        Else
            Return False
        End If

    End Function
    Public Function validarNitCont(ByVal nit As Double) As Boolean
        Dim sql As String = "select top(1) nit_Contratista from J_control_contratistas  WHERE nit_Contratista = " & nit
        If (consultValorTodo(sql, "CONTROL") <> "") Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Function validarDiaPerCont(ByVal nit As Double) As Boolean
        Dim ano As String = Now.Year
        Dim mes As String = Now.Month
        Dim day As String = Now.Day

        Dim sql As String = "select nit_Contra from J_perm_dias_cont  WHERE nit_contra = " & nit & "and ano=" & ano & " and mes=" & mes & " and dia=" & day & ""
        If (consultValorTodo(sql, "CONTROL") <> "") Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Function get_nom_db(ByVal db As String) As String
        Return obj_op_simplesAd.get_nom_db(db)
    End Function
    Public Function buscarTexto(ByVal texto As String, ByVal busqueda As String) As Boolean
        Dim i As Integer
        i = InStr(1, texto, busqueda)
        If i > 0 Then
            buscarTexto = True
        Else
            buscarTexto = False
        End If
    End Function
End Class
