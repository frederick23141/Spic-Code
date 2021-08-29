Imports accesoDatos
Public Class traslado_bodLn
    Private objOrdenProdLn As New OrdenProdLn
    Private objOperacionesDb As New OperacionesDb
    Private objOpSimplesAd As New Op_simplesAd
    Private objOp_simpesLn As New Op_simpesLn
    Public Function trasladoBodega(ByVal kilos As Integer, ByVal codigo As String, ByVal bodega As Integer, ByVal dFec As Date, ByVal notas As String, ByVal usuario As String, ByVal tipo As String) As DataTable
        Dim dt As New DataTable
        dt.Columns.Add("numero")
        dt.Columns.Add("seq")
        dt.Rows.Add()

        Dim sql As String
        Dim seq As Integer = 0
        Dim listSql As New List(Of Object)
        Dim valorUnitatio As Double = objOrdenProdLn.consultVrUnit(codigo)
        Dim costUnit As Integer = objOrdenProdLn.consultCostoUnit(codigo)
        Dim numero As Double = 0
        Dim nit As String = "890900160"
        Dim vrTotal As Double = valorUnitatio * kilos
        Dim vendedor As Integer = 0
        Dim pc As String = My.Computer.Name
        Dim sFecha As String = ""
        Dim fecha_hora As String
        Dim swDoc As Integer = consultarSwTipo(tipo)
        Dim swDoc_lin As Integer = consultarSwTipo(tipo)
        Dim inserto As Boolean = False
        If (objOrdenProdLn.insertarProxMes(codigo)) Then
            dFec = dFec.AddMonths(1)
            fecha_hora = "" & System.DateTime.Now.Month + 1 & "-" & "01" & "-" & System.DateTime.Now.Year & " " & System.DateTime.Now.Hour & ":" & System.DateTime.Now.Minute & ":" & System.DateTime.Now.Second & ""
            sFecha = dFec.Year & "-" & dFec.Month & "-01"
        Else
            fecha_hora = "" & System.DateTime.Now.Month & "-" & System.DateTime.Now.Day & "-" & System.DateTime.Now.Year & " " & System.DateTime.Now.Hour & ":" & System.DateTime.Now.Minute & ":" & System.DateTime.Now.Second & ""
            sFecha = dFec.Year & "-" & dFec.Month & "-" & dFec.Day
        End If
        If (swDoc = 11) Then
            swDoc_lin = swDoc
        ElseIf (swDoc = 12) Then
            swDoc_lin = 3
        End If

        If (existeEncTransaccionSpic(dFec, tipo)) Then
            numero = consultNumeroExistenteXtipo(tipo, dFec)
            seq = objOperacionesDb.consultValor("SELECT MAX(seq)+1 FROM documentos_lin WHERE tipo = '" & tipo & "' AND numero = " & numero, "CORSAN")
            sql = " UPDATE documentos " & _
               "SET valor_total  = valor_total+ " & vrTotal & ",valor_aplicado  = valor_aplicado + " & vrTotal & ",fecha_hora = GETDATE () " & _
                        "WHERE numero = " & numero & " AND YEAR (fecha ) = " & dFec.Year & " AND MONTH (fecha ) = " & dFec.Month & " AND DAY (fecha )=" & dFec.Day & ""
        Else
            numero = objOrdenProdLn.mover_consecutivo(tipo)
            seq = 1
            sql = " INSERT INTO  documentos " & _
               "(sw,tipo,numero,nit,fecha,vencimiento,valor_total,vendedor,valor_aplicado,anulado,modelo,notas ,usuario,pc,fecha_hora,bodega,duracion,concepto ,centro_doc,spic) " & _
                  "VALUES (" & swDoc & ",'" & tipo & "'," & numero & "," & nit & ",'" & sFecha & "','" & sFecha & "'," & vrTotal & "," & vendedor & "," & 0 & ",0 " & _
                    ",'01','" & notas & "','" & usuario & "','" & pc & "','" & sFecha & "'," & bodega & ",15,0,0,'S') "
        End If
        listSql.Add(sql)
        sql = "INSERT INTO documentos_lin(sw,tipo,numero,codigo,seq,fec,nit,cantidad,porcentaje_iva,valor_unitario,porcentaje_descuento " & _
                  ",costo_unitario,adicional,vendedor,bodega,und,cantidad_und,cantidad_pedida,maneja_inventario,costo_unitario_sin,cantidad_dos) " & _
                "VALUES(" & swDoc_lin & ",'" & tipo & "'," & numero & ",'" & codigo & "'," & seq & ",'" & sFecha & "'," & nit & "," & kilos & ",16," & valorUnitatio & ",0, " & _
                    "" & costUnit & ",'" & notas & "',0," & bodega & ",'UND',1,0,'S',0.0000000000000000,1) "
        listSql.Add(sql)
        'Script para ingresar a referencias_sto (STOCK) 
        listSql.Add(actualizarRefSto(kilos, costUnit, codigo, dFec, bodega, swDoc))
        listSql.Add(sqlActUltEntradaUltSalida(swDoc, codigo))
        inserto = objOperacionesDb.ExecuteSqlTransaction(listSql)
        If (inserto) Then
            sql = "INSERT INTO J_transac_spic_dms (numero,tipo,fecha,usuario,pc,cantidad,notas,seq) " & _
                        "VALUES(" & numero & ",'" & tipo & "','" & sFecha & "','" & usuario & "','" & pc & "'," & kilos & ",'" & notas & "'," & seq & ")"
            If (objOperacionesDb.ejecutar(sql, "PRODUCCION") = 0) Then
                MsgBox("Erorr al insertar en J_transac_spic_dms comuniquese con el administrador del sistema")
            End If
            dt.Rows(0).Item("numero") = numero
            dt.Rows(0).Item("seq") = seq
        Else
            dt.Rows(0).Item("numero") = 0
            dt.Rows(0).Item("seq") = 0
        End If
        Return dt
    End Function
    Public Function sqlActUltEntradaUltSalida(ByVal swTipo As Integer, ByVal codigo As String) As String
        Dim sql As String = ""
        If (swTipo = 11 Or swTipo = 16) Then
            sql = "UPDATE referencias SET fec_ultima_salida = GETDATE () WHERE codigo = '" & codigo & "'"
        ElseIf (swTipo = 12 Or swTipo = 3) Then
            sql = "UPDATE referencias SET fec_ultima_entrada = GETDATE () WHERE codigo = '" & codigo & "'"
        End If
        Return sql
    End Function
    Public Function consultarSwTipo(ByVal tipo As String) As Integer
        Dim sql As String = "SELECT sw FROM tipo_transacciones WHERE  tipo = '" & tipo & "'"
        Dim sw As Double = Convert.ToDouble(objOperacionesDb.consultValor(sql, "CORSAN"))
        Return sw
    End Function
    Private Function actualizarRefSto(ByVal kilos As Double, ByVal costUnit As Double,
                                      ByVal codigo As String, ByVal dFec As Date, ByVal bodega As Integer, ByVal swTipo As Integer) As String
        Dim sql As String = ""
        Dim pes As Double = Format(kilos, "#0.0")
        kilos = pes
        'sw 11 resta(salida) , sw 12 suma(entrada)
        If (swTipo = "11" Or swTipo = "16") Then
            sql = "UPDATE referencias_sto " & _
                       "SET can_sal += " & kilos & " , " & _
                              "cos_sal +=" & costUnit * kilos & " , " & _
                                  "cos_otr_sal +=" & costUnit * kilos & " , " & _
                                        "can_otr_sal += " & kilos & " , " & _
                                 "nro_com = (CASE WHEN nro_com is null  THEN 1 ELSE nro_com + 1 END ) " & _
                           " WHERE bodega = " & bodega & " AND codigo ='" & codigo & "' AND mes = " & dFec.Month & " and ano = " & dFec.Year & " "
        ElseIf (swTipo = "12" Or swTipo = "3") Then
            sql = "UPDATE referencias_sto " & _
                       "SET can_ent = (CASE WHEN can_ent is null  THEN " & kilos & " ELSE can_ent +" & kilos & " END ), " & _
                               "cos_ent = (CASE WHEN cos_ent is null  THEN " & costUnit * kilos & " ELSE cos_ent +" & costUnit * kilos & " END ), " & _
                                   "can_com = (CASE WHEN can_com is null  THEN " & kilos & " ELSE can_com +" & kilos & " END ), " & _
                       "cos_com = (CASE WHEN cos_com is null  THEN " & costUnit * kilos & " ELSE cos_com +" & costUnit * kilos & " END ), " & _
                                     "nro_com = (CASE WHEN nro_com is null  THEN 1 ELSE nro_com + 1 END ) " & _
                           " WHERE bodega = " & bodega & " AND codigo ='" & codigo & "' AND mes = " & dFec.Month & " and ano = " & dFec.Year & " "
        End If
        Return sql
    End Function
    Private Function existe_referencias_sto(ByVal codigo As String, ByVal bodega As Integer, ByVal fec As Date) As Boolean
        Dim resp As Boolean = False
        Dim mes As Integer = fec.Month
        Dim ano As Integer = fec.Year
        Dim sql As String = "SELECT codigo FROM referencias_sto WHERE codigo = '" & codigo & "' AND mes = " & mes & " AND ano = " & ano & " AND bodega = " & bodega & " "
        If objOp_simpesLn.consultarVal(sql) <> "" Then
            resp = True
        Else
            resp = False
        End If
        Return resp
    End Function
    Private Function crear_referencias_sto(ByVal codigo As String, ByVal bodega As Integer, ByVal fec As Date) As String
        Dim mes As Integer = fec.Month
        Dim ano As Integer = fec.Year
        Dim sql As String = "INSERT INTO referencias_sto " & _
                                "(bodega, codigo, ano, mes, can_ini, can_ent, can_sal, cos_ini, cos_ent, cos_sal, can_vta, cos_vta, val_vta, can_dev_vta, cos_dev_vta, val_dev, can_com, cos_com, can_dev_com, cos_dev_com, " & _
                                      "can_otr_ent, cos_otr_ent, can_otr_sal, cos_otr_sal, can_tra, cos_tra, sub_cos, baj_cos, nro_vta, nro_dev_vta, nro_com, nro_dev_com, nro_ped, can_ped, cos_ini_aju, cos_ent_aju, cos_sal_aju) " & _
                                        "VALUES (" & bodega & ", '" & codigo & "', " & ano & ", " & mes & ", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, " & _
                                            "0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)"
        Return sql
    End Function
    Public Function consultUltNumeroXtipo(ByVal tipo As String) As Double
        Dim sql As String = "SELECT MAX (numero )FROM documentos WHERE  tipo = '" & tipo & "'"
        Dim numero As Double = Convert.ToDouble(objOperacionesDb.consultValor(sql, "CORSAN"))
        Return numero
    End Function
    Public Function consultNumeroExistenteXtipo(ByVal tipo As String, ByVal fec As Date) As Double
        Dim sql As String = "SELECT numero FROM documentos WHERE tipo = '" & tipo & "' AND YEAR (fecha ) = " & fec.Year & " AND MONTH (fecha ) = " & fec.Month & " AND DAY (fecha )=" & fec.Day & " AND spic is not null"
        Dim numero As Double = Convert.ToDouble(objOperacionesDb.consultValor(sql, "CORSAN"))
        Return numero
    End Function
    Public Function consultUltStockInsuficiente(ByVal tipo As String) As Double
        Dim sql As String = "SELECT MAX (numero )FROM J_audit_stock_insuficiente "
        Dim numero As Double = Convert.ToDouble(objOperacionesDb.consultValor(sql, "CORSAN"))
        Return numero
    End Function
    Public Sub guardarTranStockInsuficiente(ByVal codigo As String, ByVal kilos As Double, ByVal tipo As String, ByVal nit As String)
        Dim sql As String = "INSERT INTO J_audit_stock_insuficiente " & _
           "(codigo,kilos,tipo,nit,fecha) " & _
        "VALUES " & _
          "('" & codigo & "'," & kilos & ",'" & tipo & "'," & nit & ",GETDATE ())"
        If (objOperacionesDb.ejecutar(sql, "CORSAN") = 0) Then
            MsgBox("Error al realizar la transacción , comuniquese con el administrador del sistema! ")
        End If
    End Sub
    Public Function obtenerBodegaXcodigo(ByVal codigo As String) As String
        Dim resp = codigo(0)
        Return resp
    End Function
    Public Function existeEncTransaccionSpic(ByVal fec As Date, ByVal tipo As String) As Boolean
        Dim sql As String = "SELECT numero FROM documentos WHERE tipo = '" & tipo & "' AND YEAR (fecha ) = " & fec.Year & " AND MONTH (fecha ) = " & fec.Month & " AND DAY (fecha )=" & fec.Day & " AND spic is not null"
        If (objOperacionesDb.consultValor(sql, "CORSAN") <> "") Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Function extraerDatoCodigoBarras(ByVal dato As String, ByVal codigoBarra As String) As String
        Dim numSeparador As Integer = 0
        Dim contSeparador As Integer = 0
        Dim respuesta As String = ""
        Select Case dato
            Case "cod_orden"
                numSeparador = 0
            Case "cod_detalle"
                numSeparador = 1
            Case "num_rollo"
                numSeparador = 2
        End Select
        For i = 0 To codigoBarra.Length - 1
            If (numSeparador = contSeparador) Then
                If (codigoBarra(i) <> "-") Then
                    respuesta &= codigoBarra(i)
                End If
            End If
            If (codigoBarra(i) = "-") Then
                contSeparador += 1
            End If
        Next
        Return respuesta
    End Function
    'Para transacciones realizadas por lector de código de barras
    Public Function armarSqlEncTransaccion(ByVal swTipo As Integer, ByVal tipo As String, ByVal kilos As Double, ByVal bodega As Integer, ByVal usuario As String, ByVal notas As String, ByVal dFec As Date, ByVal numero As Double, ByVal vrTotal As Double, ByVal codigo As String) As String
        Dim sql As String = ""
        Dim listSql As New List(Of Object)
        Dim nit As String = "890900160"
        Dim vendedor As Integer = 0
        Dim fecha_hora As String
        Dim pc As String = My.Computer.Name
        Dim sFecha As String = ""
        If (objOrdenProdLn.insertarProxMes(codigo)) Then
            dFec = dFec.AddMonths(1)
            fecha_hora = "" & System.DateTime.Now.Month + 1 & "-" & "01" & "-" & System.DateTime.Now.Year & " " & System.DateTime.Now.Hour & ":" & System.DateTime.Now.Minute & ":" & System.DateTime.Now.Second & ""
            sFecha = dFec.Year & "-" & dFec.Month & "-01"
        Else
            fecha_hora = "" & System.DateTime.Now.Month & "-" & System.DateTime.Now.Day & "-" & System.DateTime.Now.Year & " " & System.DateTime.Now.Hour & ":" & System.DateTime.Now.Minute & ":" & System.DateTime.Now.Second & ""
            sFecha = dFec.Year & "-" & dFec.Month & "-" & dFec.Day
        End If
        sql = " INSERT INTO  documentos " & _
               "(sw,tipo,numero,nit,fecha,vencimiento,valor_total,vendedor,valor_aplicado,anulado,modelo,notas ,usuario,pc,fecha_hora,bodega,duracion,concepto ,centro_doc,spic) " & _
                  "VALUES (" & swTipo & ",'" & tipo & "'," & numero & "," & nit & ",'" & sFecha & "','" & sFecha & "'," & vrTotal & "," & vendedor & "," & 0 & ",0 " & _
                    ",'01','" & notas & "','" & usuario & "','" & pc & "','" & sFecha & "'," & bodega & ",15,0,0,'S') "
        Return sql
    End Function
    Public Function armarSqlDetTransaccion(ByVal swTipo As Integer, ByVal tipo As String, ByVal kilos As Double, ByVal usuario As String, ByVal notas As String, ByVal dFec As Date, ByVal numero As Double, ByVal codigo As String, ByVal seq As Integer, ByVal valorUnitatio As Double, ByVal costUnit As Double, ByVal bodega As Integer) As String
        Dim sql As String = ""
        Dim listSql As New List(Of Object)
        Dim nit As String = "890900160"
        Dim fecha_hora As String
        Dim sFecha As String = ""
        If (objOrdenProdLn.insertarProxMes(codigo)) Then
            dFec = dFec.AddMonths(1)
            fecha_hora = "" & System.DateTime.Now.Month + 1 & "-" & "01" & "-" & System.DateTime.Now.Year & " " & System.DateTime.Now.Hour & ":" & System.DateTime.Now.Minute & ":" & System.DateTime.Now.Second & ""
            sFecha = dFec.Year & "-" & dFec.Month & "-01"
        Else
            fecha_hora = "" & System.DateTime.Now.Month & "-" & System.DateTime.Now.Day & "-" & System.DateTime.Now.Year & " " & System.DateTime.Now.Hour & ":" & System.DateTime.Now.Minute & ":" & System.DateTime.Now.Second & ""
            sFecha = dFec.Year & "-" & dFec.Month & "-" & dFec.Day
        End If
        sql = "INSERT INTO documentos_lin(sw,tipo,numero,codigo,seq,fec,nit,cantidad,porcentaje_iva,valor_unitario,porcentaje_descuento " & _
                   ",costo_unitario,adicional,vendedor,bodega,und,cantidad_und,cantidad_pedida,maneja_inventario,costo_unitario_sin,cantidad_dos) " & _
                 "VALUES(" & swTipo & ",'" & tipo & "'," & numero & ",'" & codigo & "'," & seq & ",'" & sFecha & "'," & nit & "," & kilos & ",16," & valorUnitatio & ",0, " & _
                     "" & costUnit & ",'" & notas & "',0," & bodega & ",'UND',1,0,'S',0.0000000000000000,1) "
        Return sql
    End Function
    Public Function anularTransaccion(ByVal numero As Double, ByVal tipo As String, ByVal motivo As String) As List(Of Object)
        Dim resp As Double = False
        Dim listSql As New List(Of Object)
        'Dim costo_total As Double = costo_unitario * cantidad
        'Dim vr_total As Double = vr_unitario * cantidad
        'Dim sql_audit_doc_lin As String = "INSERT INTO J_documentos_lin_anulados(sw,tipo,numero,codigo,seq,fec,nit,cantidad,porcentaje_iva,valor_unitario,porcentaje_descuento " & _
        '         ",costo_unitario,adicional,vendedor,bodega,und,cantidad_und,cantidad_pedida,maneja_inventario,costo_unitario_sin,cantidad_dos,id) " & _
        '       "VALUES(" & sw & ",'" & tipo & "'," & numero & ",'" & codigo & "'," & seq & ",'" & sFecha & "',890900160," & cantidad & ",16," & vr_unitario & ",0, " & _
        '           "" & costo_unitario & ",'" & motivo & "',0," & bodega & ",'UND',1,0,'S',0.0000000000000000,1," & id & ") "
        Dim sql_doc As String = "SELECT bodega,fecha,sw FROM documentos WHERE numero =" & numero & " AND tipo = '" & tipo & "'"
        Dim sql_doc_lin As String = "SELECT codigo,cantidad,costo_unitario FROM documentos_lin WHERE numero =" & numero & " AND tipo = '" & tipo & "'"
        Dim dt_doc As DataTable = objOp_simpesLn.listar_datatable(sql_doc, "CORSAN")
        Dim dt_doc_lin As DataTable = objOp_simpesLn.listar_datatable(sql_doc_lin, "CORSAN")
        Dim bodega As Integer = 0
        Dim fecha As Date
        Dim sFecha As String = ""
        Dim sw As Integer = 0
        For i = 0 To dt_doc.Rows.Count - 1
            bodega = dt_doc.Rows(i).Item("bodega")
            fecha = dt_doc.Rows(i).Item("fecha")
            sw = dt_doc.Rows(i).Item("sw")
        Next
        Dim sqlDoc_update As String = " UPDATE documentos " &
               "SET anulado  = 1 ,  notas = '" & motivo & "' " &
                        "WHERE numero = " & numero & " AND tipo = '" & tipo & "'"
        Dim sqlDocLin_update As String = "DELETE FROM documentos_lin " &
                                      "WHERE numero = " & numero & " AND tipo = '" & tipo & "' "
        sFecha = fecha.Year & "-" & fecha.Month & "-" & fecha.Day
        listSql.Add(sqlDoc_update)
        listSql.Add(sqlDocLin_update)
        Dim sqlRefSto As String = ""
        Dim cantidad As Double = 0
        Dim costo_total As Double = 0
        Dim costo_unitario As Double = 0
        Dim codigo As String = ""
        For i = 0 To dt_doc_lin.Rows.Count - 1
            'sw 11 resta(salida) , sw 3 suma(entrada)
            cantidad = dt_doc_lin.Rows(i).Item("cantidad")
            costo_unitario = dt_doc_lin.Rows(i).Item("costo_unitario")
            costo_total = costo_unitario * cantidad
            codigo = dt_doc_lin.Rows(i).Item("codigo")
            If (sw = "11" Or sw = "16") Then
                sqlRefSto = "UPDATE referencias_sto " &
                           "SET can_sal -= " & cantidad & " , " &
                                  "cos_sal -=" & costo_total & " , " &
                                      "cos_otr_sal -=" & costo_total & " , " &
                                            "can_otr_sal -= " & cantidad & " , " &
                                     "nro_com = (CASE WHEN nro_com is null  THEN 1 ELSE nro_com + 1 END ) " &
                               " WHERE bodega = " & bodega & " AND codigo ='" & codigo & "' AND mes = " & fecha.Month & " and ano = " & fecha.Year & " "
            ElseIf (sw = "12" Or sw = "3") Then
                sqlRefSto = "UPDATE referencias_sto " &
                          "SET can_ent -= " & cantidad & " , " &
                                 "cos_ent -=" & costo_total & " , " &
                                      "cos_com -=" & costo_total & " , " &
                                           "can_com -= " & cantidad & " , " &
                                    "nro_com = (CASE WHEN nro_com is null  THEN 1 ELSE nro_com + 1 END ) " &
                              " WHERE bodega = " & bodega & " AND codigo ='" & codigo & "' AND mes = " & fecha.Month & " and ano = " & fecha.Year & " "

            End If
            listSql.Add(sqlRefSto)
            sqlRefSto = ""
        Next
        '   listSql.Add(sql_audit_doc_lin)
        Return listSql
    End Function
    Public Function anularTransaccionPuas(ByVal numero As Double, ByVal tipo As String, ByVal motivo As String) As List(Of Object)
        Dim resp As Double = False
        Dim listSql As New List(Of Object)
        'Dim costo_total As Double = costo_unitario * cantidad
        'Dim vr_total As Double = vr_unitario * cantidad
        'Dim sql_audit_doc_lin As String = "INSERT INTO J_documentos_lin_anulados(sw,tipo,numero,codigo,seq,fec,nit,cantidad,porcentaje_iva,valor_unitario,porcentaje_descuento " & _
        '         ",costo_unitario,adicional,vendedor,bodega,und,cantidad_und,cantidad_pedida,maneja_inventario,costo_unitario_sin,cantidad_dos,id) " & _
        '       "VALUES(" & sw & ",'" & tipo & "'," & numero & ",'" & codigo & "'," & seq & ",'" & sFecha & "',890900160," & cantidad & ",16," & vr_unitario & ",0, " & _
        '           "" & costo_unitario & ",'" & motivo & "',0," & bodega & ",'UND',1,0,'S',0.0000000000000000,1," & id & ") "
        Dim sql_doc As String = "SELECT bodega,fecha,sw FROM documentos WHERE numero =" & numero & " AND tipo = '" & tipo & "'"
        Dim sql_doc_lin As String = "SELECT codigo,cantidad,costo_unitario FROM documentos_lin WHERE numero =" & numero & " AND tipo = '" & tipo & "'"
        Dim dt_doc As DataTable = objOp_simpesLn.listar_datatable(sql_doc, "CORSAN")
        Dim dt_doc_lin As DataTable = objOp_simpesLn.listar_datatable(sql_doc_lin, "CORSAN")
        Dim bodega As Integer = 0
        Dim fecha As Date
        Dim sFecha As String = ""
        Dim sw As Integer = 0
        For i = 0 To dt_doc.Rows.Count - 1
            bodega = 2
            fecha = dt_doc.Rows(i).Item("fecha")
            sw = dt_doc.Rows(i).Item("sw")
        Next
        Dim sqlDoc_update As String = " UPDATE documentos " &
               "SET anulado  = 1 ,  notas = '" & motivo & "' " &
                        "WHERE numero = " & numero & " AND tipo = '" & tipo & "'"
        Dim sqlDocLin_update As String = "DELETE FROM documentos_lin " &
                                      "WHERE numero = " & numero & " AND tipo = '" & tipo & "' "
        sFecha = fecha.Year & "-" & fecha.Month & "-" & fecha.Day
        listSql.Add(sqlDoc_update)
        listSql.Add(sqlDocLin_update)
        Dim sqlRefSto As String = ""
        Dim cantidad As Double = 0
        Dim costo_total As Double = 0
        Dim costo_unitario As Double = 0
        Dim codigo As String = ""
        For i = 0 To dt_doc_lin.Rows.Count - 1
            'sw 11 resta(salida) , sw 3 suma(entrada)
            cantidad = dt_doc_lin.Rows(i).Item("cantidad")
            costo_unitario = dt_doc_lin.Rows(i).Item("costo_unitario")
            costo_total = costo_unitario * cantidad
            codigo = dt_doc_lin.Rows(i).Item("codigo")
            If (sw = "11" Or sw = "16") Then
                sqlRefSto = "UPDATE referencias_sto " &
                           "SET can_sal -= " & cantidad & " , " &
                                  "cos_sal -=" & costo_total & " , " &
                                      "cos_otr_sal -=" & costo_total & " , " &
                                            "can_otr_sal -= " & cantidad & " , " &
                                     "nro_com = (CASE WHEN nro_com is null  THEN 1 ELSE nro_com + 1 END ) " &
                               " WHERE bodega = " & bodega & " AND codigo ='" & codigo & "' AND mes = " & fecha.Month & " and ano = " & fecha.Year & " "
            ElseIf (sw = "12" Or sw = "3") Then
                sqlRefSto = "UPDATE referencias_sto " &
                          "SET can_ent -= " & cantidad & " , " &
                                 "cos_ent -=" & costo_total & " , " &
                                      "cos_com -=" & costo_total & " , " &
                                           "can_com -= " & cantidad & " , " &
                                    "nro_com = (CASE WHEN nro_com is null  THEN 1 ELSE nro_com + 1 END ) " &
                              " WHERE bodega = " & bodega & " AND codigo ='" & codigo & "' AND mes = " & fecha.Month & " and ano = " & fecha.Year & " "

            End If
            listSql.Add(sqlRefSto)
            sqlRefSto = ""
        Next
        '   listSql.Add(sql_audit_doc_lin)
        Return listSql
    End Function
    Public Function anularTransaccionSinStock(ByVal numero As Double, ByVal motivo As String) As Boolean
        Dim resp As Double = False
        Dim sql As String = "UPDATE J_audit_stock_insuficiente SET anulado = 'S', notas = '" & motivo & "' WHERE numero = " & numero
        If (objOpSimplesAd.ejecutar(sql, "CORSAN") > 0) Then
            resp = True
        End If
        Return resp
    End Function
    Public Function transaccionDatable(ByVal dt_codigos_valores As DataTable, ByVal bodega As Integer, ByVal dFec As Date, ByVal notas As String, ByVal usuario As String, ByVal tipo As String, ByVal modelo As String) As Double
        Dim sql As String
        Dim seq As Integer = 0
        Dim listSql As New List(Of Object)
        Dim valorUnitatio As Double = 0
        Dim costUnit As Integer = 0
        Dim numero As Double = 0
        Dim fecha_hora As String
        Dim nit As String = "890900160"
        Dim vrTotal As Double = calcularVrTotal(dt_codigos_valores)
        Dim vendedor As Integer = 0
        Dim pc As String = My.Computer.Name
        Dim sFecha As String = ""
        Dim swDoc As Integer = consultarSwTipo(tipo)
        Dim swDoc_lin As Integer = consultarSwTipo(tipo)
        Dim inserto As Boolean = False
        Dim sFecha_hora As String = ""
        If (swDoc = 11) Then
            swDoc_lin = swDoc
        ElseIf (swDoc = 12) Then
            swDoc_lin = 3
        End If
        numero = objOrdenProdLn.mover_consecutivo(tipo)
        If (objOrdenProdLn.insertarProxMes(dt_codigos_valores.Rows(0).Item("codigo"))) Then
            dFec = dFec.AddMonths(1)
            sFecha_hora = dFec.Year & "-" & dFec.Month & "-01"
            fecha_hora = "" & System.DateTime.Now.Month + 1 & "-" & "01" & "-" & System.DateTime.Now.Year & " " & System.DateTime.Now.Hour & ":" & System.DateTime.Now.Minute & ":" & System.DateTime.Now.Second & ""
            sFecha = dFec.Year & "-" & dFec.Month & "-01"
        Else
            sFecha_hora = Format(Now, "yyyy/MM/dd HH:mm:ss")
            fecha_hora = "" & System.DateTime.Now.Month & "-" & System.DateTime.Now.Day & "-" & System.DateTime.Now.Year & " " & System.DateTime.Now.Hour & ":" & System.DateTime.Now.Minute & ":" & System.DateTime.Now.Second & ""
            sFecha = objOp_simpesLn.cambiarFormatoFecha(Now)
        End If
        sql = " INSERT INTO  documentos " & _
            "(sw,tipo,numero,nit,fecha,vencimiento,valor_total,vendedor,valor_aplicado,anulado,modelo,notas ,usuario,pc,fecha_hora,bodega,duracion,concepto ,centro_doc,spic) " & _
                "VALUES (" & swDoc & ",'" & tipo & "'," & numero & "," & nit & ",'" & sFecha & "','" & sFecha & "'," & vrTotal & "," & vendedor & "," & 0 & ",0 " & _
                  ",'" & modelo & "','" & notas & "','" & usuario & "','" & pc & "','" & sFecha_hora & "'," & bodega & ",15,0,0,'S') "
        listSql.Add(sql)
        For i = 0 To dt_codigos_valores.Rows.Count - 1
            valorUnitatio = objOrdenProdLn.consultVrUnit(dt_codigos_valores.Rows(i).Item("codigo"))
            costUnit = objOrdenProdLn.consultCostoUnit(dt_codigos_valores.Rows(i).Item("codigo"))
            seq = i
            sql = "INSERT INTO documentos_lin(sw,tipo,numero,codigo,seq,fec,nit,cantidad,porcentaje_iva,valor_unitario,porcentaje_descuento " & _
               ",costo_unitario,adicional,vendedor,bodega,und,cantidad_und,cantidad_pedida,maneja_inventario,costo_unitario_sin,cantidad_dos) " & _
             "VALUES(" & swDoc_lin & ",'" & tipo & "'," & numero & ",'" & dt_codigos_valores.Rows(i).Item("codigo") & "'," & seq & ",'" & sFecha & "'," & nit & "," & dt_codigos_valores.Rows(i).Item("cantidad") & ",16," & valorUnitatio & ",0, " & _
                 "" & costUnit & ",'" & notas & "',0," & bodega & ",'UND',1,0,'S',0.0000000000000000,1) "
            listSql.Add(sql)
            'Script para ingresar a referencias_sto (STOCK) 
            listSql.Add(actualizarRefSto(dt_codigos_valores.Rows(i).Item("cantidad"), costUnit, dt_codigos_valores.Rows(i).Item("codigo"), dFec, bodega, swDoc))
            listSql.Add(sqlActUltEntradaUltSalida(swDoc, dt_codigos_valores.Rows(i).Item("codigo")))
        Next

        inserto = objOperacionesDb.ExecuteSqlTransaction(listSql)
        If (inserto) Then
            Return numero
        Else
            Return 0
        End If
    End Function
    Public Function transaccion_alambron_b2(ByVal kilos As Integer, ByVal codigo As String, ByVal bodega As Integer, ByVal dFec As Date, ByVal notas As String, ByVal usuario As String, ByVal tipo As String, ByVal valor_promedio As Double, ByVal numero As Double) As List(Of Object)
        Dim dt As New DataTable
        dt.Columns.Add("numero")
        dt.Columns.Add("seq")
        dt.Rows.Add()
        Dim sql As String
        Dim seq As Integer = 0
        Dim fecha_hora As String
        Dim listSql As New List(Of Object)
        Dim valorUnitatio As Double = valor_promedio
        Dim costUnit As Integer = valor_promedio
        Dim nit As String = "890900160"
        Dim vrTotal As Double = valorUnitatio * kilos
        Dim vendedor As Integer = 0
        Dim pc As String = My.Computer.Name
        Dim sFecha As String = ""
        dFec = Now
        Dim swDoc As Integer = consultarSwTipo(tipo)
        Dim swDoc_lin As Integer = consultarSwTipo(tipo)
        Dim inserto As Boolean = False
        Dim sFecha_hora As String = ""
        If (objOrdenProdLn.insertarProxMes(codigo)) Then
            dFec = dFec.AddMonths(1)
            sFecha_hora = dFec.Year & "-" & dFec.Month & "-01"
            fecha_hora = "" & System.DateTime.Now.Month + 1 & "-" & "01" & "-" & System.DateTime.Now.Year & " " & System.DateTime.Now.Hour & ":" & System.DateTime.Now.Minute & ":" & System.DateTime.Now.Second & ""
            sFecha = dFec.Year & "-" & dFec.Month & "-01"
        Else
            sFecha_hora = Format(Now, "yyyy/MM/dd HH:mm:ss")
            fecha_hora = "" & System.DateTime.Now.Month & "-" & System.DateTime.Now.Day & "-" & System.DateTime.Now.Year & " " & System.DateTime.Now.Hour & ":" & System.DateTime.Now.Minute & ":" & System.DateTime.Now.Second & ""
            sFecha = objOp_simpesLn.cambiarFormatoFecha(Now)
        End If
        If (swDoc = 11) Then
            swDoc_lin = swDoc
        ElseIf (swDoc = 12) Then
            swDoc_lin = 3
        End If
        seq = 1
        sql = " INSERT INTO  documentos " & _
           "(sw,tipo,numero,nit,fecha,vencimiento,valor_total,vendedor,valor_aplicado,anulado,modelo,notas ,usuario,pc,fecha_hora,bodega,duracion,concepto ,centro_doc,spic) " & _
              "VALUES (" & swDoc & ",'" & tipo & "'," & numero & "," & nit & ",'" & sFecha & "','" & sFecha & "'," & vrTotal & "," & vendedor & "," & 0 & ",0 " & _
                ",'01','" & notas & "','" & usuario & "','" & pc & "','" & sFecha_hora & "'," & bodega & ",15,0,0,'S') "
        listSql.Add(sql)
        sql = "INSERT INTO documentos_lin(sw,tipo,numero,codigo,seq,fec,nit,cantidad,porcentaje_iva,valor_unitario,porcentaje_descuento " & _
                  ",costo_unitario,adicional,vendedor,bodega,und,cantidad_und,cantidad_pedida,maneja_inventario,costo_unitario_sin,cantidad_dos) " & _
                "VALUES(" & swDoc_lin & ",'" & tipo & "'," & numero & ",'" & codigo & "'," & seq & ",'" & sFecha & "'," & nit & "," & kilos & ",16," & valorUnitatio & ",0, " & _
                    "" & costUnit & ",'" & notas & "',0," & bodega & ",'UND',1,0,'S',0.0000000000000000,1) "
        listSql.Add(sql)
        'Script para ingresar a referencias_sto (STOCK) 
        listSql.Add(actualizarRefSto(kilos, costUnit, codigo, dFec, bodega, swDoc))
        listSql.Add(sqlActUltEntradaUltSalida(swDoc, codigo))
        Return listSql
    End Function
    'TRANSACCION DE PUAS'
    Public Function transaccion_Puas(ByVal kilos As Integer, ByVal codigo As String, ByVal bodega As Integer, ByVal dFec As Date, ByVal notas As String, ByVal usuario As String, ByVal tipo As String, ByVal valor_promedio As Double, ByVal numero As Double) As List(Of Object)
        Dim dt As New DataTable
        dt.Columns.Add("numero")
        dt.Columns.Add("seq")
        dt.Rows.Add()
        Dim sql As String
        Dim fecha_hora As String
        Dim seq As Integer = 0
        Dim sFecha_hora As String = ""
        Dim listSql As New List(Of Object)
        Dim valorUnitatio As Double = valor_promedio
        Dim costUnit As Integer = valor_promedio
        Dim nit As String = "890900160"
        Dim vrTotal As Double = valorUnitatio * kilos
        Dim vendedor As Integer = 0
        Dim pc As String = My.Computer.Name
        Dim sFecha As String = ""
        Dim swDoc As Integer = consultarSwTipo(tipo)
        Dim swDoc_lin As Integer = consultarSwTipo(tipo)
        Dim inserto As Boolean = False
        If (objOrdenProdLn.insertarProxMes(codigo)) Then
            dFec = dFec.AddMonths(1)
            sFecha_hora = dFec.Year & "-" & dFec.Month & "-01"
            fecha_hora = "" & System.DateTime.Now.Month + 1 & "-" & "01" & "-" & System.DateTime.Now.Year & " " & System.DateTime.Now.Hour & ":" & System.DateTime.Now.Minute & ":" & System.DateTime.Now.Second & ""
            sFecha = dFec.Year & "-" & dFec.Month & "-01"
        Else
            sFecha_hora = Format(Now, "yyyy/MM/dd HH:mm:ss")
            fecha_hora = "" & System.DateTime.Now.Month & "-" & System.DateTime.Now.Day & "-" & System.DateTime.Now.Year & " " & System.DateTime.Now.Hour & ":" & System.DateTime.Now.Minute & ":" & System.DateTime.Now.Second & ""
            sFecha = objOp_simpesLn.cambiarFormatoFecha(Now)
        End If
        If (swDoc = 11) Then
            swDoc_lin = swDoc
        ElseIf (swDoc = 12) Then
            swDoc_lin = 3
        End If
        seq = 1
        sql = " INSERT INTO  documentos " &
           "(sw,tipo,numero,nit,fecha,vencimiento,valor_total,vendedor,valor_aplicado,anulado,modelo,notas ,usuario,pc,fecha_hora,bodega,duracion,concepto ,centro_doc,spic) " &
              "VALUES (" & swDoc & ",'" & tipo & "'," & numero & "," & nit & ",'" & sFecha & "','" & sFecha & "'," & vrTotal & "," & vendedor & "," & 0 & ",0 " &
                ",'01','" & notas & "','" & usuario & "','" & pc & "','" & sFecha_hora & "'," & bodega & ",15,0,0,'S') "
        listSql.Add(sql)
        sql = "INSERT INTO documentos_lin(sw,tipo,numero,codigo,seq,fec,nit,cantidad,porcentaje_iva,valor_unitario,porcentaje_descuento " &
                  ",costo_unitario,adicional,vendedor,bodega,und,cantidad_und,cantidad_pedida,maneja_inventario,costo_unitario_sin,cantidad_dos) " &
                "VALUES(" & swDoc_lin & ",'" & tipo & "'," & numero & ",'" & codigo & "'," & seq & ",'" & sFecha & "'," & nit & "," & kilos & ",16," & valorUnitatio & ",0, " &
                    "" & costUnit & ",'" & notas & "',0," & bodega & ",'UND',1,0,'S',0.0000000000000000,1) "
        listSql.Add(sql)
        'Script para ingresar a referencias_sto (STOCK) 
        listSql.Add(actualizarRefSto(kilos, costUnit, codigo, dFec, bodega, swDoc))
        listSql.Add(sqlActUltEntradaUltSalida(swDoc, codigo))
        Return listSql
    End Function
    Public Function transaccion_Desp(ByVal kilos As Integer, ByVal codigo As String, ByVal bodega As Integer, ByVal dFec As Date, ByVal notas As String, ByVal usuario As String, ByVal tipo As String, ByVal valor_promedio As Double, ByVal numero As Double) As List(Of Object)
        Dim dt As New DataTable
        dt.Columns.Add("numero")
        dt.Columns.Add("seq")
        dt.Rows.Add()
        Dim sql As String
        Dim fecha_hora As String
        Dim seq As Integer = 0
        Dim sFecha_hora As String = ""
        Dim listSql As New List(Of Object)
        Dim valorUnitatio As Double = valor_promedio
        Dim costUnit As Integer = valor_promedio
        Dim nit As String = "890900160"
        Dim vrTotal As Double = valorUnitatio * kilos
        Dim vendedor As Integer = 0
        Dim pc As String = My.Computer.Name
        Dim sFecha As String = ""
        Dim swDoc As Integer = consultarSwTipo(tipo)
        Dim swDoc_lin As Integer = consultarSwTipo(tipo)
        Dim inserto As Boolean = False
        If (objOrdenProdLn.insertarProxMes(codigo)) Then
            dFec = dFec.AddMonths(1)
            sFecha_hora = dFec.Year & "-" & dFec.Month & "-01"
            fecha_hora = "" & System.DateTime.Now.Month + 1 & "-" & "01" & "-" & System.DateTime.Now.Year & " " & System.DateTime.Now.Hour & ":" & System.DateTime.Now.Minute & ":" & System.DateTime.Now.Second & ""
            sFecha = dFec.Year & "-" & dFec.Month & "-01"
        Else
            sFecha_hora = Format(Now, "yyyy/MM/dd HH:mm:ss")
            fecha_hora = "" & System.DateTime.Now.Month & "-" & System.DateTime.Now.Day & "-" & System.DateTime.Now.Year & " " & System.DateTime.Now.Hour & ":" & System.DateTime.Now.Minute & ":" & System.DateTime.Now.Second & ""
            sFecha = objOp_simpesLn.cambiarFormatoFecha(Now)
        End If
        If (swDoc = 11) Then
            swDoc_lin = swDoc
        ElseIf (swDoc = 12) Then
            swDoc_lin = 3
        End If
        seq = 1
        sql = " INSERT INTO  documentos " &
           "(sw,tipo,numero,nit,fecha,vencimiento,valor_total,vendedor,valor_aplicado,anulado,modelo,notas ,usuario,pc,fecha_hora,bodega,duracion,concepto ,centro_doc,spic) " &
              "VALUES (" & swDoc & ",'" & tipo & "'," & numero & "," & nit & ",'" & sFecha & "','" & sFecha & "'," & vrTotal & "," & vendedor & "," & 0 & ",0 " &
                ",'02','" & notas & "','" & usuario & "','" & pc & "','" & sFecha_hora & "'," & bodega & ",15,0,0,'S') "
        listSql.Add(sql)
        sql = "INSERT INTO documentos_lin(sw,tipo,numero,codigo,seq,fec,nit,cantidad,porcentaje_iva,valor_unitario,porcentaje_descuento " &
                  ",costo_unitario,adicional,vendedor,bodega,und,cantidad_und,cantidad_pedida,maneja_inventario,costo_unitario_sin,cantidad_dos) " &
                "VALUES(" & swDoc_lin & ",'" & tipo & "'," & numero & ",'" & codigo & "'," & seq & ",'" & sFecha & "'," & nit & "," & kilos & ",16," & valorUnitatio & ",0, " &
                    "" & costUnit & ",'" & notas & "',0," & bodega & ",'UND',1,0,'S',0.0000000000000000,1) "
        listSql.Add(sql)
        'Script para ingresar a referencias_sto (STOCK) 
        listSql.Add(actualizarRefSto(kilos, costUnit, codigo, dFec, bodega, swDoc))
        listSql.Add(sqlActUltEntradaUltSalida(swDoc, codigo))
        Return listSql
    End Function
    'transaccion scal brillante , trefilacion,scae y sar
    Public Function transaccion_Scal_Brillante(ByVal kilos As Integer, ByVal codigo As String, ByVal bodega As Integer, ByVal dFec As Date, ByVal notas As String, ByVal usuario As String, ByVal tipo As String, ByVal valor_promedio As Double, ByVal numero As Double) As List(Of Object)
        Dim dt As New DataTable
        dt.Columns.Add("numero")
        dt.Columns.Add("seq")
        dt.Rows.Add()
        Dim sql As String
        Dim fecha_hora As String
        Dim sFecha_hora As String = ""
        Dim seq As Integer = 0
        Dim listSql As New List(Of Object)
        Dim valorUnitatio As Double = valor_promedio
        Dim costUnit As Integer = valor_promedio
        Dim nit As String = "890900160"
        Dim vrTotal As Double = valorUnitatio * kilos
        Dim vendedor As Integer = 0
        Dim pc As String = My.Computer.Name
        Dim sFecha As String = ""
        Dim swDoc As Integer = consultarSwTipo(tipo)
        Dim swDoc_lin As Integer = consultarSwTipo(tipo)
        Dim inserto As Boolean = False
        If (objOrdenProdLn.insertarProxMes(codigo)) Then
            dFec = dFec.AddMonths(1)
            sFecha_hora = dFec.Year & "-" & dFec.Month & "-01"
            fecha_hora = "" & System.DateTime.Now.Month + 1 & "-" & "01" & "-" & System.DateTime.Now.Year & " " & System.DateTime.Now.Hour & ":" & System.DateTime.Now.Minute & ":" & System.DateTime.Now.Second & ""
            sFecha = dFec.Year & "-" & dFec.Month & "-01"
        Else
            sFecha_hora = Format(Now, "yyyy/MM/dd HH:mm:ss")
            fecha_hora = "" & System.DateTime.Now.Month & "-" & System.DateTime.Now.Day & "-" & System.DateTime.Now.Year & " " & System.DateTime.Now.Hour & ":" & System.DateTime.Now.Minute & ":" & System.DateTime.Now.Second & ""
            sFecha = objOp_simpesLn.cambiarFormatoFecha(Now)
        End If
        If (swDoc = 11) Then
            swDoc_lin = swDoc
        ElseIf (swDoc = 12) Then
            swDoc_lin = 3
        End If
        seq = 1
        sql = " INSERT INTO  documentos " & _
           "(sw,tipo,numero,nit,fecha,vencimiento,valor_total,vendedor,valor_aplicado,anulado,modelo,notas ,usuario,pc,fecha_hora,bodega,duracion,concepto ,centro_doc,spic) " & _
              "VALUES (" & swDoc & ",'" & tipo & "'," & numero & "," & nit & ",'" & sFecha & "','" & sFecha & "'," & vrTotal & "," & vendedor & "," & 0 & ",0 " & _
                ",'01','" & notas & "','" & usuario & "','" & pc & "','" & sFecha_hora & "'," & bodega & ",15,0,0,'S') "
        listSql.Add(sql)
        sql = "INSERT INTO documentos_lin(sw,tipo,numero,codigo,seq,fec,nit,cantidad,porcentaje_iva,valor_unitario,porcentaje_descuento " & _
                  ",costo_unitario,adicional,vendedor,bodega,und,cantidad_und,cantidad_pedida,maneja_inventario,costo_unitario_sin,cantidad_dos) " & _
                "VALUES(" & swDoc_lin & ",'" & tipo & "'," & numero & ",'" & codigo & "'," & seq & ",'" & sFecha & "'," & nit & "," & kilos & ",16," & valorUnitatio & ",0, " & _
                    "" & costUnit & ",'" & notas & "',0," & bodega & ",'UND',1,0,'S',0.0000000000000000,1) "
        listSql.Add(sql)
        'Script para ingresar a referencias_sto (STOCK) 
        listSql.Add(actualizarRefSto(kilos, costUnit, codigo, dFec, bodega, swDoc))
        listSql.Add(sqlActUltEntradaUltSalida(swDoc, codigo))
        Return listSql
    End Function
    Public Function listaTransaccionDatable(ByVal numero As Integer, ByVal dt_codigos_valores As DataTable, ByVal bodega As Integer, ByVal dFec As Date, ByVal notas As String, ByVal usuario As String, ByVal tipo As String, ByVal modelo As String) As List(Of Object)
        Dim sql As String
        Dim seq As Integer = 0
        Dim listSql As New List(Of Object)
        Dim valorUnitatio As Double = 0
        Dim costUnit As Integer = 0
        Dim fecha_hora As String
        Dim nit As String = "890900160"
        Dim vrTotal As Double = calcularVrTotal(dt_codigos_valores)
        Dim vendedor As Integer = 0
        Dim pc As String = My.Computer.Name
        Dim sFecha_hora As String = ""
        Dim sFecha As String = ""
        Dim swDoc As Integer = consultarSwTipo(tipo)
        Dim swDoc_lin As Integer = consultarSwTipo(tipo)
        Dim inserto As Boolean = False
        If (swDoc = 11) Then
            swDoc_lin = swDoc
        ElseIf (swDoc = 12) Then
            swDoc_lin = 3
        End If
        If (objOrdenProdLn.insertarProxMes(dt_codigos_valores.Rows(0).Item("codigo"))) Then
            dFec = dFec.AddMonths(1)
            sFecha_hora = dFec.Year & "-" & dFec.Month & "-01"
            fecha_hora = "" & System.DateTime.Now.Month + 1 & "-" & "01" & "-" & System.DateTime.Now.Year & " " & System.DateTime.Now.Hour & ":" & System.DateTime.Now.Minute & ":" & System.DateTime.Now.Second & ""
            sFecha = dFec.Year & "-" & dFec.Month & "-01"
        Else
            sFecha_hora = Format(Now, "yyyy/MM/dd HH:mm:ss")
            fecha_hora = "" & System.DateTime.Now.Month & "-" & System.DateTime.Now.Day & "-" & System.DateTime.Now.Year & " " & System.DateTime.Now.Hour & ":" & System.DateTime.Now.Minute & ":" & System.DateTime.Now.Second & ""
            sFecha = objOp_simpesLn.cambiarFormatoFecha(Now)
        End If
        sql = " INSERT INTO  documentos " & _
            "(sw,tipo,numero,nit,fecha,vencimiento,valor_total,vendedor,valor_aplicado,anulado,modelo,notas ,usuario,pc,fecha_hora,bodega,duracion,concepto ,centro_doc,spic) " & _
                "VALUES (" & swDoc & ",'" & tipo & "'," & numero & "," & nit & ",'" & sFecha & "','" & sFecha & "'," & vrTotal & "," & vendedor & "," & 0 & ",0 " & _
                  ",'" & modelo & "','" & notas & "','" & usuario & "','" & pc & "','" & sFecha_hora & "'," & bodega & ",15,0,0,'S') "
        listSql.Add(sql)
        For i = 0 To dt_codigos_valores.Rows.Count - 1
            If Not existe_referencias_sto(dt_codigos_valores.Rows(i).Item("codigo"), bodega, dFec) Then
                listSql.Add(crear_referencias_sto(dt_codigos_valores.Rows(i).Item("codigo"), bodega, dFec))
            End If
            valorUnitatio = objOrdenProdLn.consultVrUnit(dt_codigos_valores.Rows(i).Item("codigo"))
            costUnit = objOrdenProdLn.consultCostoUnit(dt_codigos_valores.Rows(i).Item("codigo"))
            seq = i
            sql = "INSERT INTO documentos_lin(sw,tipo,numero,codigo,seq,fec,nit,cantidad,porcentaje_iva,valor_unitario,porcentaje_descuento " & _
               ",costo_unitario,adicional,vendedor,bodega,und,cantidad_und,cantidad_pedida,maneja_inventario,costo_unitario_sin,cantidad_dos) " & _
             "VALUES(" & swDoc_lin & ",'" & tipo & "'," & numero & ",'" & dt_codigos_valores.Rows(i).Item("codigo") & "'," & seq & ",'" & sFecha & "'," & nit & "," & dt_codigos_valores.Rows(i).Item("cantidad") & ",16," & valorUnitatio & ",0, " & _
                 "" & costUnit & ",'" & notas & "',0," & bodega & ",'UND',1,0,'S',0.0000000000000000,1) "
            listSql.Add(sql)
            'Script para ingresar a referencias_sto (STOCK) 
            Dim CANT As Double = dt_codigos_valores.Rows(i).Item("cantidad")
            Dim cas As Double = Format(CANT, "#0.0")
            listSql.Add(actualizarRefSto(cas, costUnit, dt_codigos_valores.Rows(i).Item("codigo"), dFec, bodega, swDoc))
            listSql.Add(sqlActUltEntradaUltSalida(swDoc, dt_codigos_valores.Rows(i).Item("codigo")))
        Next
        Return (listSql)
    End Function
    'señal fecha hora
   Public Function listaTransaccionDatable_importaciones(ByVal numero As Integer, ByVal dt_codigos_valores As DataTable, ByVal bodega As Integer, ByVal dFec As Date, ByVal notas As String, ByVal usuario As String, ByVal tipo As String, _
                                                            ByVal nit_proveedor As Double, ByVal modelo As String) As List(Of Object)
        If modelo = "1" Then
            modelo = "01"
        End If
        Dim sql As String
        Dim seq As Integer = 0
        Dim listSql As New List(Of Object)
        Dim valorUnitatio As Double = 0
        Dim nit As String = nit_proveedor
        Dim vrTotal As Double = calcular_costo_total_importacion(dt_codigos_valores)
        Dim vendedor As Integer = 0
        Dim pc As String = My.Computer.Name
        Dim fecha_hora As String
        Dim sFecha_hora As String = ""
        Dim sFecha As String = ""
        Dim swDoc As Integer = consultarSwTipo(tipo)
        Dim swDoc_lin As Integer = consultarSwTipo(tipo)
        Dim costo_kilo As Double = 0
        Dim porc_iva As Double = objOp_simpesLn.getIvaPorc()
        Dim vr_iva As Double = 0
        Dim vr_tot_mercancia As Double = 0
        If tipo = "CMP1" And (modelo = "01" Or modelo = "03") Then
            vr_iva = vrTotal * porc_iva
            vrTotal += vr_iva
            vr_tot_mercancia = vrTotal - vr_iva
        End If
        If (swDoc = 11) Then
            swDoc_lin = swDoc
        ElseIf (swDoc = 12) Then
            swDoc_lin = 3
        End If
        If (objOrdenProdLn.insertarProxMes(dt_codigos_valores.Rows(0).Item("codigo"))) Then
            dFec = dFec.AddMonths(1)
            sFecha_hora = dFec.Year & "-" & dFec.Month & "-01"
            fecha_hora = "" & System.DateTime.Now.Month + 1 & "-" & "01" & "-" & System.DateTime.Now.Year & " " & System.DateTime.Now.Hour & ":" & System.DateTime.Now.Minute & ":" & System.DateTime.Now.Second & ""
            sFecha = dFec.Year & "-" & dFec.Month & "-01"
        Else
            sFecha_hora = Format(Now, "yyyy/MM/dd HH:mm:ss")
            fecha_hora = "" & System.DateTime.Now.Month & "-" & System.DateTime.Now.Day & "-" & System.DateTime.Now.Year & " " & System.DateTime.Now.Hour & ":" & System.DateTime.Now.Minute & ":" & System.DateTime.Now.Second & ""
            sFecha = objOp_simpesLn.cambiarFormatoFecha(Now)
        End If

        sql = " INSERT INTO  documentos " & _
            "(sw,tipo,numero,nit,fecha,vencimiento,valor_total,vendedor,valor_aplicado,anulado,modelo,notas ,usuario,pc,fecha_hora,bodega,duracion,concepto ,centro_doc,spic,iva,valor_mercancia) " & _
                "VALUES (" & swDoc & ",'" & tipo & "'," & numero & "," & nit & ",'" & sFecha & "','" & sFecha & "'," & vrTotal & "," & vendedor & "," & 0 & ",0 " & _
                  ",'" & modelo & "','" & notas & "','" & usuario & "','" & pc & "','" & sFecha & "'," & bodega & ",15,0,0,'S'," & vr_iva & "," & vr_tot_mercancia & ") "
        listSql.Add(sql)
        For i = 0 To dt_codigos_valores.Rows.Count - 1
            valorUnitatio = dt_codigos_valores.Rows(i).Item("costo_kilo")
            costo_kilo = dt_codigos_valores.Rows(i).Item("costo_kilo")
            seq = i
            sql = "INSERT INTO documentos_lin(sw,tipo,numero,codigo,seq,fec,nit,cantidad,porcentaje_iva,valor_unitario,porcentaje_descuento " & _
               ",costo_unitario,adicional,vendedor,bodega,und,cantidad_und,cantidad_pedida,maneja_inventario,costo_unitario_sin,cantidad_dos) " & _
             "VALUES(" & swDoc_lin & ",'" & tipo & "'," & numero & ",'" & dt_codigos_valores.Rows(i).Item("codigo") & "'," & seq & ",'" & sFecha & "'," & nit & "," & dt_codigos_valores.Rows(i).Item("cantidad") & ",16," & valorUnitatio & ",0, " & _
                 "" & costo_kilo & ",'" & notas & "',0," & bodega & ",'UND',1,0,'S',0.0000000000000000,1) "
            listSql.Add(sql)
            'Script para ingresar a referencias_sto (STOCK) 
            listSql.Add(actualizarRefSto(dt_codigos_valores.Rows(i).Item("cantidad"), costo_kilo, dt_codigos_valores.Rows(i).Item("codigo"), dFec, bodega, swDoc))
            listSql.Add(sqlActUltEntradaUltSalida(swDoc, dt_codigos_valores.Rows(i).Item("codigo")))
        Next
        If tipo = "CMP1" And (modelo = "01" Or modelo = "03") Then
            listSql.AddRange(script_cuentas(tipo, modelo, numero, vr_tot_mercancia, nit_proveedor, sFecha))
        End If

        Return (listSql)
    End Function
    Private Function calcular_costo_total_importacion(ByVal dt_codigos_valores As DataTable) As Double
        Dim costo_total As Double = 0
        Dim cantidad As Double = 0
        Dim costo_unitario As Double = 0
        For i = 0 To dt_codigos_valores.Rows.Count - 1
            cantidad = dt_codigos_valores.Rows(i).Item("cantidad")
            costo_unitario = dt_codigos_valores.Rows(i).Item("costo_kilo")
            costo_total += cantidad * costo_unitario
        Next
        Return costo_total
    End Function
    Private Function calcularVrTotal(ByVal dt As DataTable) As Double
        Dim valorUnitatio As Double = 0
        Dim sum As Double = 0
        For i = 0 To dt.Rows.Count - 1
            If Not IsDBNull(dt.Rows(i).Item("codigo")) And Not IsDBNull(dt.Rows(i).Item("cantidad")) Then
                valorUnitatio = objOrdenProdLn.consultVrUnit(dt.Rows(i).Item("codigo"))
                sum += dt.Rows(i).Item("cantidad")
            End If
        Next
        Return sum
    End Function
    Private Function calcularVrTotal_ver_da(ByVal codigo As String, ByVal cantidad As Double) As Double
        Dim valorUnitatio As Double = 0
        Dim sum As Double = 0
        valorUnitatio = objOrdenProdLn.consultVrUnit(codigo)
        sum += cantidad
        Return sum
    End Function
    Public Function listaTransaccionDatable_traslado_bodega(ByVal numero As Integer, ByVal codigo As String, ByVal bodega_origen As Integer, ByVal bodega_destino As Integer, ByVal dFec As Date, ByVal notas As String, ByVal usuario As String, ByVal cantidad As Double, ByVal tipo As String, ByVal modelo As String, ByVal costo_kilo As Double) As List(Of Object)
        Dim sql As String
        Dim sql_lin_salida As String = ""
        Dim sql_lin_entrada As String = ""
        Dim seq As Integer = 0
        Dim fecha_hora As String
        Dim listSql As New List(Of Object)
        Dim nit As String = "890900160"
        Dim vrTotal As Double = costo_kilo * cantidad
        Dim costo_total As Double = costo_kilo * cantidad
        Dim vendedor As Integer = 0
        Dim pc As String = My.Computer.Name
        Dim sFecha_hora As String = ""
        Dim sFecha As String = ""
        Dim swDoc As Integer = 16
        Dim swDoc_lin As Integer = 0
        Dim inserto As Boolean = False
        Dim vr_unitario As Double = costo_kilo

        If (objOrdenProdLn.insertarProxMes(codigo)) Then
            dFec = dFec.AddMonths(1)
            sFecha_hora = dFec.Year & "-" & dFec.Month & "-01"
            fecha_hora = "" & System.DateTime.Now.Month + 1 & "-" & "01" & "-" & System.DateTime.Now.Year & " " & System.DateTime.Now.Hour & ":" & System.DateTime.Now.Minute & ":" & System.DateTime.Now.Second & ""
            sFecha = sFecha_hora
        Else
            sFecha_hora = Format(Now, "yyyy/MM/dd HH:mm:ss")
            fecha_hora = "" & System.DateTime.Now.Month & "-" & System.DateTime.Now.Day & "-" & System.DateTime.Now.Year & " " & System.DateTime.Now.Hour & ":" & System.DateTime.Now.Minute & ":" & System.DateTime.Now.Second & ""
            sFecha = objOp_simpesLn.cambiarFormatoFecha(Now)
        End If
        If Not existe_referencias_sto(codigo, bodega_destino, dFec) Then
            listSql.Add(crear_referencias_sto(codigo, bodega_destino, dFec))
        End If
        sql = " INSERT INTO  documentos " & _
            "(sw,tipo,numero,nit,fecha,vencimiento,valor_total,vendedor,valor_aplicado,anulado,modelo,notas ,usuario,pc,fecha_hora,bodega,duracion,concepto ,centro_doc,spic) " & _
                "VALUES (" & swDoc & ",'" & tipo & "'," & numero & "," & nit & ",'" & sFecha & "','" & sFecha & "'," & vrTotal & "," & vendedor & "," & 0 & ",0 " & _
                  ",'" & modelo & "','" & notas & "','" & usuario & "','" & pc & "','" & sFecha_hora & "'," & bodega_origen & ",15,0,0,'S') "
        listSql.Add(sql)

        '******************* ----------Se adiciona la salida

        seq = 1
        swDoc_lin = 16
        sql = "INSERT INTO documentos_lin(sw,tipo,numero,codigo,seq,fec,nit,cantidad,porcentaje_iva,valor_unitario,porcentaje_descuento " & _
           ",costo_unitario,adicional,vendedor,bodega,und,cantidad_und,cantidad_pedida,maneja_inventario,costo_unitario_sin,cantidad_dos) " & _
         "VALUES(" & swDoc_lin & ",'" & tipo & "'," & numero & ",'" & codigo & "'," & seq & ",'" & sFecha & "'," & nit & "," & cantidad & ",16," & vr_unitario & ",0, " & _
             "" & costo_kilo & ",'" & notas & "',0," & bodega_origen & ",'UND',1,0,'S',0.0000000000000000,1) "
        listSql.Add(sql)
        'Script para ingresar a referencias_sto (STOCK) 
        listSql.Add(actualizarRefSto(cantidad, costo_kilo, codigo, dFec, bodega_origen, swDoc_lin))
        listSql.Add(sqlActUltEntradaUltSalida(swDoc_lin, codigo))



        '******************* ----------Se adiciona la Entrada
        vr_unitario = 0
        seq = 2
        swDoc_lin = 12
        sql = "INSERT INTO documentos_lin(sw,tipo,numero,codigo,seq,fec,nit,cantidad,porcentaje_iva,valor_unitario,porcentaje_descuento " & _
           ",costo_unitario,adicional,vendedor,bodega,und,cantidad_und,cantidad_pedida,maneja_inventario,costo_unitario_sin,cantidad_dos) " & _
         "VALUES(" & swDoc_lin & ",'" & tipo & "'," & numero & ",'" & codigo & "'," & seq & ",'" & sFecha & "'," & nit & "," & cantidad & ",16," & vr_unitario & ",0, " & _
             "" & costo_kilo & ",'" & notas & "',0," & bodega_destino & ",'UND',1,0,'S',0.0000000000000000,1) "
        listSql.Add(sql)
        'Script para ingresar a referencias_sto (STOCK) 
        listSql.Add(actualizarRefSto(cantidad, costo_kilo, codigo, dFec, bodega_destino, swDoc_lin))
        listSql.Add(sqlActUltEntradaUltSalida(swDoc_lin, codigo))

        Return (listSql)
    End Function
    Private Function script_cuentas(ByVal tipo As String, ByVal modelo As String, ByVal numero As Double, ByVal costo_total As Double, ByVal nit As Double, ByVal fec As String) As List(Of Object)
        Dim listSql As New List(Of Object)
        Dim sql_consulta_tipo_transacciones_mod As String = "SELECT cta1,cta2,cta3 " & _
                                                                "FROM tipo_transacciones_mod " & _
                                                                            "WHERE tipo ='" & tipo & "' AND modelo= '" & modelo & "'"
        Dim dt_cuentas As DataTable = objOp_simpesLn.listar_datatable(sql_consulta_tipo_transacciones_mod, "CORSAN")
        Dim sql_movimientos As String = ""
        Dim sql As String = ""
        Dim seq As Integer = 1
        Dim valor As Double = 0
        Dim iva As Double = objOp_simpesLn.getIvaPorc()
        Dim valor_iva As Double = costo_total * iva
        Dim centro As Double = 0
        For j = 0 To dt_cuentas.Columns.Count - 1
            If Not IsDBNull(dt_cuentas.Rows(0).Item(j)) Then
                Select Case dt_cuentas.Rows(0).Item(j)
                    Case 220501
                        valor = costo_total + valor_iva
                        valor *= -1
                        sql_movimientos = "INSERT INTO movimiento (tipo, numero,seq, nit, fec,  cuenta, centro, valor) " & _
                                            "VALUES ('" & tipo & "', " & numero & "," & seq & ", " & nit & ",'" & fec & "', " & dt_cuentas.Rows(0).Item(j) & ", " & centro & ", " & valor & ")"
                        listSql.Add(sql_movimientos)
                        seq += 1
                    Case 14050100
                        valor = costo_total
                        sql_movimientos = "INSERT INTO movimiento (tipo, numero,seq, nit, fec,  cuenta, centro, valor) " & _
                                            "VALUES ('" & tipo & "', " & numero & "," & seq & ", " & nit & ", '" & fec & "', " & dt_cuentas.Rows(0).Item(j) & ", " & centro & ", " & valor & ")"
                        listSql.Add(sql_movimientos)
                        seq += 1
                    Case 24080505
                        valor = valor_iva
                        sql_movimientos = "INSERT INTO movimiento (tipo, numero,seq, nit, fec,  cuenta, centro, valor,base) " & _
                                            "VALUES ('" & tipo & "', " & numero & "," & seq & ", " & nit & ", '" & fec & "', " & dt_cuentas.Rows(0).Item(j) & ", " & centro & ", " & valor & "," & costo_total & ")"
                        listSql.Add(sql_movimientos)
                        seq += 1
                End Select
            End If
        Next
        Return listSql
    End Function
End Class
