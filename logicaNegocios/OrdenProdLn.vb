Imports accesoDatos
Imports entidadNegocios

Public Class OrdenProdLn
    Private obj_Ing_prodAd As New Ing_prod_ad
    Private objOpsimpesLn As New Op_simpesLn
    Private objOperacionesDb As New OperacionesDb
    Public Function ingProdDms(ByVal kilos As Double, ByVal codigo As String, ByVal bodega As Integer, ByVal dFec As Date, ByVal notas As String, ByVal usuario As String, ByVal id_detalle As Double, ByVal cod_orden As Double, ByVal mp As String, ByVal numero As Double, ByVal tipo As String, sFecha As String, ByVal fecha_hora As String) As List(Of Object)
        Dim sql As String
        Dim sqlRefSto As String = ""
        Dim listSql As New List(Of Object)
        Dim resp As Integer = 0
        Dim valorUnitatio As Double = consultVrUnit(codigo)
        Dim costUnit As Double = consultCostoUnit(codigo)
        'Dim numero As Double = consultNumeroTransaccion(tipo)
        Dim nit As String = "890900160"
        Dim vrTotal As Double = valorUnitatio * kilos
        Dim vendedor = 0
        Dim pc As String = My.Computer.Name

        sql = " INSERT INTO  documentos " &
                "(sw,tipo,numero,nit,fecha,vencimiento,valor_total,vendedor,valor_aplicado,anulado,modelo,notas ,usuario,pc,fecha_hora,bodega,duracion,concepto ,centro_doc,mp) " &
                   "VALUES (12,'" & tipo & "'," & numero & "," & nit & ",'" & sFecha & "','" & sFecha & "'," & vrTotal & "," & vendedor & "," & vrTotal & ",0 " &
                     ",'01','" & notas & "','" & usuario & "','" & pc & "','" & fecha_hora & "'," & bodega & ",15,0,0,'" & mp & "') "
        listSql.Add(sql)
        sql = "INSERT INTO documentos_lin(sw,tipo,numero,codigo,seq,fec,nit,cantidad,porcentaje_iva,valor_unitario,porcentaje_descuento " &
                  ",costo_unitario,adicional,vendedor,bodega,und,cantidad_und,cantidad_pedida,maneja_inventario,costo_unitario_sin,cantidad_dos) " &
                "VALUES(3,'" & tipo & "'," & numero & ",'" & codigo & "',1,'" & sFecha & "'," & nit & "," & kilos & ",16," & valorUnitatio & ",0, " &
                    "" & costUnit & ",'" & notas & "',0," & bodega & ",'UND',1,0,'S',0.0000000000000000,1) "
        listSql.Add(sql)
        'Script para ingresar a referencias_sto (STOCK)
        sqlRefSto = "UPDATE referencias_sto " &
                        "SET can_ent = (CASE WHEN can_ent is null  THEN " & kilos & " ELSE can_ent +" & kilos & " END ), " &
                                "cos_ent = (CASE WHEN cos_ent is null  THEN " & costUnit * kilos & " ELSE cos_ent +" & costUnit * kilos & " END ), " &
                                    "can_com = (CASE WHEN can_com is null  THEN " & kilos & " ELSE can_com +" & kilos & " END ), " &
                        "cos_com = (CASE WHEN cos_com is null  THEN " & costUnit * kilos & " ELSE cos_com +" & costUnit * kilos & " END ), " &
                                      "nro_com = (CASE WHEN nro_com is null  THEN 1 ELSE nro_com + 1 END ) " &
                            " WHERE bodega = " & bodega & " AND codigo ='" & codigo & "' AND mes = " & dFec.Month & " and ano = " & dFec.Year & " "
        listSql.Add(sqlRefSto)
        Return listSql
    End Function

    Public Function consultVrUnit(ByVal codigo As String) As String
        Dim sql As String = "select valor_unitario   from referencias where codigo = '" & codigo & "'"
        Return objOperacionesDb.consultValor(sql, "CORSAN")
    End Function
    Public Function consultCostoUnit(ByVal codigo As String) As String
        Dim sql As String = "select costo_unitario   from referencias where codigo = '" & codigo & "'"
        Return objOperacionesDb.consultValor(sql, "CORSAN")
    End Function
    Public Function consultNumeroTransaccion(ByVal tipo As String) As Double
        Dim sql As String = "SELECT MAX (numero )FROM documentos WHERE  tipo = '" & tipo & "'"
        Dim numero As Double = Convert.ToDouble(objOperacionesDb.consultValor(sql, "CORSAN"))
        Return numero + 1
    End Function
    Public Function updateHorometro(ByVal valor As Double, ByVal horometro As String, ByVal consecutivoDet As Double, ByVal consecutivoPpal As Double) As Integer
        Dim sql As String = "UPDATE J_det_orden_prod SET " & horometro & "  = " & valor & " WHERE  id_detalle =" & consecutivoDet & " AND cod_orden =" & consecutivoPpal
        Return objOperacionesDb.ejecutar(sql, "PRODUCCION")
    End Function
    Public Function calcEsperada(ByVal velocidad As Double, ByVal diametro As Double, ByVal minProg As Double) As Double
        Dim resp As Double = 0
        resp = (((velocidad * (diametro ^ 2)) * 22.2) * ((minProg) / 60))
        Return resp
    End Function
    Public Function validarHorometro(ByVal sHoroIni As String, ByVal sHoroFin As String) As String
        Dim resp As String = ""
        Dim horoIni As Double = 0
        Dim horoFin As Double = 0
        If (sHoroIni = "" Or sHoroFin = "" Or sHoroIni = "0" Or sHoroFin = "0") Then
            resp = "Se debe diligenciar tanto el horometro inicial como el final"
        Else
            horoIni = Convert.ToDouble(sHoroIni)
            horoFin = Convert.ToDouble(sHoroFin)
            If (horoIni > horoFin) Then
                resp = "Horometro inicial es mayor al inicial"
            ElseIf (((horoFin - horoIni) * 60) > 800) Then
                resp = "El calculo del horometro es mayor a 12 horas"
            End If
        End If
        Return resp
    End Function
    Public Sub guardarDetParo(ByVal codOrden As String, ByVal codDet As String, ByVal numParo As String, ByVal Hini As String, ByVal hFin As String, ByVal total As Double)
        Dim resp As Integer = 0
        Dim sql As String = "INSERT INTO   J_det_orden_paros  (cod_orden,cod_det,num_paro,h_ini,h_fin,total) VALUES " & _
                                      "(" & codOrden & ", " & codDet & "," & numParo & ",'" & Hini & "','" & hFin & "'," & total & ") "
        resp = objOperacionesDb.ejecutar(sql, "PRODUCCION")
    End Sub
    'Se verifica si se hizo cierre en el mes actual para ingresar produccion conm fecha del mes proximo
    Public Function insertarProxMes(ByVal codigo As String) As Boolean
        Dim dfecProxMes As Date = Convert.ToDateTime(Now.AddMonths(1))
        Dim sql As String = "SELECT  mes FROM referencias_sto  WHERE codigo ='" & codigo & "' AND mes = " & dfecProxMes.Month & " and ano = " & dfecProxMes.Year & ""
        If (objOperacionesDb.consultValor(sql, "CORSAN") <> "") Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Function existePlanilla(ByVal cod_orden As String, ByVal cod_detalle As String) As Boolean
        Dim sql As String = "SELECT cod_orden FROM J_det_orden_prod WHERE cod_orden = " & cod_orden & " AND id_detalle = " & cod_detalle
        If (objOperacionesDb.consultValor(sql, "PRODUCCION") <> "") Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Function eliminarConsecutivo(ByVal cod_orden As String, ByVal idDetalle As String, ByVal notas As String) As Boolean
        Dim sqlDet As String = "UPDATE  J_det_orden_prod  SET anulado = 1,notas += '" & notas & "' WHERE id_detalle =" & idDetalle & " AND cod_orden =" & cod_orden
        Dim sqlRollo As String = "DELETE FROM J_rollos_tref WHERE id_detalle =" & idDetalle & " AND cod_orden =" & cod_orden
        Dim sqlPlanInsp As String = "DELETE FROM J_plan_insp WHERE cod_detalle =" & idDetalle & " AND cod_orden =" & cod_orden
        Dim sqlAnularEficiencia As String = "UPDATE  J_prod_tref_completo SET anulado = 1 , notas += '-ANULADO:" & notas & "' WHERE id_detalle =" & idDetalle & " AND consecutivo =" & cod_orden
        Dim list As New List(Of Object)
        Dim resp As Boolean
        list.Add(sqlDet)
        list.Add(sqlRollo)
        list.Add(sqlPlanInsp)
        list.Add(sqlAnularEficiencia)
        resp = obj_Ing_prodAd.ExecuteSqlTransaction(list, "PRODUCCION")
        Return resp
    End Function
    Public Function return_objDetalleRollosEn(ByVal cod_orden As String, ByVal cod_detalle As String, ByVal num_rollo As String) As DetalleRollosEn
        Return obj_Ing_prodAd.return_objDetalleRollosEn(cod_orden, cod_detalle, num_rollo)
    End Function
    Public Function return_objOrdenProdLn(ByVal cod_orden As String, ByVal cod_detalle As String) As OrdenProdEn
        Return obj_Ing_prodAd.return_objOrdenProdEn(cod_orden, cod_detalle)
    End Function

    Public Function crearPlanInsp(ByVal usuario As String, ByVal consecutivoPpal As String, ByVal consecutivoDet As String, ByVal turno As Integer) As List(Of Object)
        Dim lisSql As New List(Of Object)
        Dim sql As String = ""
        Dim hora As String = ""
        For i = 0 To 3
            Select Case i
                Case 0
                    If (turno = 1) Then
                        hora = "6:00-8:00"
                    ElseIf (turno = 2) Then
                        hora = "14:01-16:00"
                    ElseIf (turno = 3) Then
                        hora = "22:01-00:00"
                    End If
                Case 1
                    If (turno = 1) Then
                        hora = "8:01-10:00"
                    ElseIf (turno = 2) Then
                        hora = "16:00-18:00"
                    ElseIf (turno = 3) Then
                        hora = "00:01-2:00"
                    End If
                Case 2
                    If (turno = 1) Then
                        hora = "10:01-12:00"
                    ElseIf (turno = 2) Then
                        hora = "18:01-20:00"
                    ElseIf (turno = 3) Then
                        hora = "2:01-4:00"
                    End If
                Case 3
                    If (turno = 1) Then
                        hora = "12:01-14:00"
                    ElseIf (turno = 2) Then
                        hora = "20:01-22:00"
                    ElseIf (turno = 3) Then
                        hora = "4:01-6:00"
                    End If
            End Select
            sql = "INSERT INTO J_plan_insp " &
                                "(id_hora,cod_orden,cod_detalle,hora) " &
                                    "VALUES " &
                           "(" & i & "," & consecutivoPpal & "," & consecutivoDet & ",'" & hora & "')"
            lisSql.Add(sql)
        Next
        Return lisSql
    End Function
    Public Function prod_Turno(ByVal usuario As String, ByVal consecutivoPpal As String, ByVal consecutivoDet As String, ByVal turno As Integer, ByVal nit As String, ByVal fecha_r As Date) As DataTable
        Dim lisSql As New List(Of Object)
        Dim sql As String = ""
        Dim sub_sql As String
        Dim hora As String = ""
        Dim h_ini, h_fin As String
        Dim max_fec As String
        Dim res_fec As Date
        Dim fecIni As String
        Dim fecFin As String
        Dim resp As Boolean = True
        max_fec = "select max(fecha_prod) as fecha from J_det_orden_prod where operario=" & nit & " and anulado is null"
        res_fec = objOpsimpesLn.consultValorTodo(max_fec, "PRODUCCION")
        sub_sql = "select distinct cod_orden from J_det_orden_prod where operario=" & nit & " and id_turno=" & turno & " and YEAR(fecha_prod)=" & fecha_r.Year & " and MONTH(fecha_prod)=" & fecha_r.Month & " and DAY(fecha_prod)=" & fecha_r.Day & ""
        sql = " select min(fecha_hora) from j_rollos_tref where cod_orden in (" & sub_sql & ")  and no_conforme is null and anulado is null"
        If objOpsimpesLn.consultValorTodo(sql, "PRODUCCION") <> "" Then
            fecIni = cambiarFormatoFecha(objOpsimpesLn.consultValorTodo(sql, "PRODUCCION"))
        Else
            resp = False
        End If
        sql = " select max(fecha_hora) from j_rollos_tref where cod_orden in (" & sub_sql & ")  and no_conforme is null and anulado is null"
        If objOpsimpesLn.consultValorTodo(sql, "PRODUCCION") <> "" Then
            fecFin = cambiarFormatoFecha(objOpsimpesLn.consultValorTodo(sql, "PRODUCCION"))
        Else
            resp = False
        End If
        Dim fecha_hora_ini As String
        Dim fecha_hora_fin As String
        Dim dt As New DataTable
        dt.Columns.Add("Hora")
        dt.Columns.Add("kg")
        If resp Then
            For i = 0 To 7
                Dim row As DataRow = dt.NewRow()

                Select Case i
                    Case 0
                        If (turno = 1) Then
                            hora = "6:01-7:00"
                            h_ini = "06:01"
                            h_fin = "07:00"
#Disable Warning BC42104 ' La variable 'fecIni' se usa antes de que se le haya asignado un valor. Podría darse una excepción de referencia NULL en tiempo de ejecución.
                            fecha_hora_ini = fecIni & " " & h_ini
#Enable Warning BC42104 ' La variable 'fecIni' se usa antes de que se le haya asignado un valor. Podría darse una excepción de referencia NULL en tiempo de ejecución.
                            fecha_hora_fin = fecIni & " " & h_fin

                        ElseIf (turno = 2) Then
                            hora = "14:01-15:00"
                            h_ini = "14:01"
                            h_fin = "15:00"
                            fecha_hora_ini = fecIni & " " & h_ini
                            fecha_hora_fin = fecIni & " " & h_fin
                        ElseIf (turno = 3) Then
                            hora = "22:01-23:00"
                            h_ini = "22:01"
                            h_fin = "23:00"
                            fecha_hora_ini = fecIni & " " & h_ini
                            fecha_hora_fin = fecIni & " " & h_fin
                        End If
                    Case 1
                        If (turno = 1) Then
                            hora = "7:01-8:00"
                            h_ini = "07:01"
                            h_fin = "08:00"
                            fecha_hora_ini = fecIni & " " & h_ini
                            fecha_hora_fin = fecIni & " " & h_fin
                        ElseIf (turno = 2) Then
                            hora = "15:01-16:00"
                            h_ini = "15:01"
                            h_fin = "16:00"
                            fecha_hora_ini = fecIni & " " & h_ini
                            fecha_hora_fin = fecIni & " " & h_fin
                        ElseIf (turno = 3) Then
                            hora = "23:01-00:00"
                            h_ini = "23:01"
                            h_fin = "23:59"
                            fecha_hora_ini = fecIni & " " & h_ini
                            fecha_hora_fin = fecIni & " " & h_fin
                        End If
                    Case 2
                        If (turno = 1) Then
                            hora = "8:01-9:00"
                            h_ini = "08:01"
                            h_fin = "09:00"
                            fecha_hora_ini = fecIni & " " & h_ini
                            fecha_hora_fin = fecIni & " " & h_fin
                        ElseIf (turno = 2) Then
                            hora = "16:01-17:00"
                            h_ini = "16:01"
                            h_fin = "17:00"
                            fecha_hora_ini = fecIni & " " & h_ini
                            fecha_hora_fin = fecIni & " " & h_fin
                        ElseIf (turno = 3) Then
                            hora = "00:01-1:00"
                            h_ini = "00:01"
                            h_fin = "01:00"
#Disable Warning BC42104 ' La variable 'fecFin' se usa antes de que se le haya asignado un valor. Podría darse una excepción de referencia NULL en tiempo de ejecución.
                            fecha_hora_ini = fecFin & " " & h_ini
#Enable Warning BC42104 ' La variable 'fecFin' se usa antes de que se le haya asignado un valor. Podría darse una excepción de referencia NULL en tiempo de ejecución.
                            fecha_hora_fin = fecFin & " " & h_fin
                        End If
                    Case 3
                        If (turno = 1) Then
                            hora = "9:01-10:00"
                            h_ini = "09:01"
                            h_fin = "10:00"
                            fecha_hora_ini = fecIni & " " & h_ini
                            fecha_hora_fin = fecIni & " " & h_fin
                        ElseIf (turno = 2) Then
                            hora = "17:01-18:00"
                            h_ini = "17:01"
                            h_fin = "18:00"
                            fecha_hora_ini = fecIni & " " & h_ini
                            fecha_hora_fin = fecIni & " " & h_fin
                        ElseIf (turno = 3) Then
                            hora = "1:01-2:00"
                            h_ini = "01:01"
                            h_fin = "02:00"
                            fecha_hora_ini = fecFin & " " & h_ini
                            fecha_hora_fin = fecFin & " " & h_fin
                        End If
                    Case 4
                        If (turno = 1) Then
                            hora = "10:01-11:00"
                            h_ini = "10:01"
                            h_fin = "11:00"
                            fecha_hora_ini = fecIni & " " & h_ini
                            fecha_hora_fin = fecIni & " " & h_fin
                        ElseIf (turno = 2) Then
                            hora = "18:01-19:00"
                            h_ini = "18:01"
                            h_fin = "19:00"
                            fecha_hora_ini = fecIni & " " & h_ini
                            fecha_hora_fin = fecIni & " " & h_fin
                        ElseIf (turno = 3) Then
                            hora = "2:01-3:00"
                            h_ini = "02:01"
                            h_fin = "03:00"
                            fecha_hora_ini = fecFin & " " & h_ini
                            fecha_hora_fin = fecFin & " " & h_fin
                        End If
                    Case 5
                        If (turno = 1) Then
                            hora = "11:01-12:00"
                            h_ini = "11:01"
                            h_fin = "12:00"
                            fecha_hora_ini = fecIni & " " & h_ini
                            fecha_hora_fin = fecIni & " " & h_fin
                        ElseIf (turno = 2) Then
                            hora = "19:01-20:00"
                            h_ini = "19:01"
                            h_fin = "20:00"
                            fecha_hora_ini = fecIni & " " & h_ini
                            fecha_hora_fin = fecIni & " " & h_fin
                        ElseIf (turno = 3) Then
                            hora = "3:01-4:00"
                            h_ini = "03:01"
                            h_fin = "04:00"
                            fecha_hora_ini = fecFin & " " & h_ini
                            fecha_hora_fin = fecFin & " " & h_fin
                        End If
                    Case 6
                        If (turno = 1) Then
                            hora = "12:01-13:00"
                            h_ini = "12:01"
                            h_fin = "13:00"
                            fecha_hora_ini = fecIni & " " & h_ini
                            fecha_hora_fin = fecIni & " " & h_fin
                        ElseIf (turno = 2) Then
                            hora = "20:01-21:00"
                            h_ini = "20:01"
                            h_fin = "21:00"
                            fecha_hora_ini = fecIni & " " & h_ini
                            fecha_hora_fin = fecIni & " " & h_fin
                        ElseIf (turno = 3) Then
                            hora = "4:01-5:00"
                            h_ini = "04:01"
                            h_fin = "05:00"
                            fecha_hora_ini = fecFin & " " & h_ini
                            fecha_hora_fin = fecFin & " " & h_fin
                        End If
                    Case 7
                        If (turno = 1) Then
                            hora = "13:01-14:00"
                            h_ini = "13:01"
                            h_fin = "14:00"
                            fecha_hora_ini = fecIni & " " & h_ini
                            fecha_hora_fin = fecIni & " " & h_fin
                        ElseIf (turno = 2) Then
                            hora = "21:01-22:00"
                            h_ini = "21:01"
                            h_fin = "22:00"
                            fecha_hora_ini = fecIni & " " & h_ini
                            fecha_hora_fin = fecIni & " " & h_fin
                        ElseIf (turno = 3) Then
                            hora = "5:01-6:00"
                            h_ini = "05:01"
                            h_fin = "06:00"
                            fecha_hora_ini = fecFin & " " & h_ini
                            fecha_hora_fin = fecFin & " " & h_fin
                        End If
                End Select
#Disable Warning BC42104 ' La variable 'fecha_hora_ini' se usa antes de que se le haya asignado un valor. Podría darse una excepción de referencia NULL en tiempo de ejecución.
#Disable Warning BC42104 ' La variable 'fecha_hora_fin' se usa antes de que se le haya asignado un valor. Podría darse una excepción de referencia NULL en tiempo de ejecución.
                sql = " select sum(peso) as peso from j_rollos_tref where cod_orden in (" & sub_sql & ") and fecha_hora >= '" & fecha_hora_ini & "' and fecha_hora <='" & fecha_hora_fin & "'" &
                               " and no_conforme is null and anulado is null  "
#Enable Warning BC42104 ' La variable 'fecha_hora_fin' se usa antes de que se le haya asignado un valor. Podría darse una excepción de referencia NULL en tiempo de ejecución.
#Enable Warning BC42104 ' La variable 'fecha_hora_ini' se usa antes de que se le haya asignado un valor. Podría darse una excepción de referencia NULL en tiempo de ejecución.
                row("Hora") = hora
                row("kg") = objOpsimpesLn.consultValorTodo(sql, "PRODUCCION")
                dt.Rows.Add(row)

            Next
        End If
        Return dt
    End Function
    'Para la referencia 22B100142
    Public Function crearPlanInspCal(ByVal usuario As String, ByVal consecutivoPpal As String, ByVal consecutivoDet As String, ByVal turno As Integer)
        Dim lisSql As New List(Of Object)
        Dim sql As String = ""
        Dim hora As String = ""
        For i = 0 To 7
            Select Case i
                Case 0
                    If (turno = 1) Then
                        hora = "6:00-7:00"
                    ElseIf (turno = 2) Then
                        hora = "14:01-15:00"
                    ElseIf (turno = 3) Then
                        hora = "22:01-23:00"
                    End If
                Case 1
                    If (turno = 1) Then
                        hora = "7:01-08:00"
                    ElseIf (turno = 2) Then
                        hora = "15:01-16:00"
                    ElseIf (turno = 3) Then
                        hora = "23:01-00:00"
                    End If
                Case 2
                    If (turno = 1) Then
                        hora = "08:01-09:00"
                    ElseIf (turno = 2) Then
                        hora = "16:01-17:00"
                    ElseIf (turno = 3) Then
                        hora = "00:01-01:00"
                    End If
                Case 3
                    If (turno = 1) Then
                        hora = "09:01-10:00"
                    ElseIf (turno = 2) Then
                        hora = "17:01-18:00"
                    ElseIf (turno = 3) Then
                        hora = "01:01-02:00"
                    End If
                Case 4
                    If (turno = 1) Then
                        hora = "10:01-11:00"
                    ElseIf (turno = 2) Then
                        hora = "18:01-19:00"
                    ElseIf (turno = 3) Then
                        hora = "02:01-03:00"
                    End If
                Case 5
                    If (turno = 1) Then
                        hora = "11:01-12:00"
                    ElseIf (turno = 2) Then
                        hora = "19:01-20:00"
                    ElseIf (turno = 3) Then
                        hora = "03:01-04:00"
                    End If
                Case 6
                    If (turno = 1) Then
                        hora = "12:01-13:00"
                    ElseIf (turno = 2) Then
                        hora = "20:01-21:00"
                    ElseIf (turno = 3) Then
                        hora = "04:01-05:00"
                    End If
                Case 7
                    If (turno = 1) Then
                        hora = "13:01-14:00"
                    ElseIf (turno = 2) Then
                        hora = "21:01-22:00"
                    ElseIf (turno = 3) Then
                        hora = "05:01-06:00"
                    End If
            End Select
            sql = "INSERT INTO J_plan_insp_cal " &
                                "(id_hora,cod_orden,cod_detalle,hora) " &
                                    "VALUES " &
                           "(" & i & "," & consecutivoPpal & "," & consecutivoDet & ",'" & hora & "')"
            lisSql.Add(sql)
        Next
        Return lisSql
    End Function
    Public Function crearPlanInspCal142(ByVal usuario As String, ByVal consecutivoPpal As String, ByVal consecutivoDet As String, ByVal turno As Integer) As List(Of Object)
        Dim lisSql As New List(Of Object)
        Dim sql As String = ""
        Dim hora As String = ""
        For i = 0 To 7
            Select Case i
                Case 0
                    If (turno = 1) Then
                        hora = "6:00-8:00"
                    ElseIf (turno = 2) Then
                        hora = "14:01-16:00"
                    ElseIf (turno = 3) Then
                        hora = "22:01-00:00"
                    End If
                Case 1
                    If (turno = 1) Then
                        hora = "8:01-10:00"
                    ElseIf (turno = 2) Then
                        hora = "16:01-18:00"
                    ElseIf (turno = 3) Then
                        hora = "00:01-2:00"
                    End If
                Case 2
                    If (turno = 1) Then
                        hora = "10:01-12:00"
                    ElseIf (turno = 2) Then
                        hora = "18:01-20:00"
                    ElseIf (turno = 3) Then
                        hora = "2:01-4:00"
                    End If
                Case 3
                    If (turno = 1) Then
                        hora = "12:01-14:00"
                    ElseIf (turno = 2) Then
                        hora = "20:01-22:00"
                    ElseIf (turno = 3) Then
                        hora = "4:01-6:00"
                    End If
            End Select
            sql = "INSERT INTO J_plan_insp_cal " &
                                "(id_hora,cod_orden,cod_detalle,hora) " &
                                    "VALUES " &
                           "(" & i & "," & consecutivoPpal & "," & consecutivoDet & ",'" & hora & "')"
            lisSql.Add(sql)
        Next
        Return lisSql
    End Function
    Public Function crearPlanInspCalRec(ByVal consecutivoPpal As String, ByVal consecutivoDet As String, ByVal turno As Integer) As List(Of Object)
        Dim lisSql As New List(Of Object)
        Dim sql As String = ""
        Dim hora As String = ""
        For i = 0 To 7
            Select Case i
                Case 0
                    If (turno = 1) Then
                        hora = "6:00-7:00"
                    ElseIf (turno = 2) Then
                        hora = "14:01-15:00"
                    ElseIf (turno = 3) Then
                        hora = "22:01-23:00"
                    End If
                Case 1
                    If (turno = 1) Then
                        hora = "7:01-08:00"
                    ElseIf (turno = 2) Then
                        hora = "15:01-16:00"
                    ElseIf (turno = 3) Then
                        hora = "23:01-00:00"
                    End If
                Case 2
                    If (turno = 1) Then
                        hora = "08:01-09:00"
                    ElseIf (turno = 2) Then
                        hora = "16:01-17:00"
                    ElseIf (turno = 3) Then
                        hora = "00:01-01:00"
                    End If
                Case 3
                    If (turno = 1) Then
                        hora = "09:01-10:00"
                    ElseIf (turno = 2) Then
                        hora = "17:01-18:00"
                    ElseIf (turno = 3) Then
                        hora = "01:01-02:00"
                    End If
                Case 4
                    If (turno = 1) Then
                        hora = "10:01-11:00"
                    ElseIf (turno = 2) Then
                        hora = "18:01-19:00"
                    ElseIf (turno = 3) Then
                        hora = "02:01-03:00"
                    End If
                Case 5
                    If (turno = 1) Then
                        hora = "11:01-12:00"
                    ElseIf (turno = 2) Then
                        hora = "19:01-20:00"
                    ElseIf (turno = 3) Then
                        hora = "03:01-04:00"
                    End If
                Case 6
                    If (turno = 1) Then
                        hora = "12:01-13:00"
                    ElseIf (turno = 2) Then
                        hora = "20:01-21:00"
                    ElseIf (turno = 3) Then
                        hora = "04:01-05:00"
                    End If
                Case 7
                    If (turno = 1) Then
                        hora = "13:01-14:00"
                    ElseIf (turno = 2) Then
                        hora = "21:01-22:00"
                    ElseIf (turno = 3) Then
                        hora = "05:01-06:00"
                    End If
            End Select
            sql = "INSERT INTO J_plan_insp_cal_rec " &
                                "(id_hora,cod_orden,cod_detalle,hora) " &
                                    "VALUES " &
                           "(" & i & "," & consecutivoPpal & "," & consecutivoDet & ",'" & hora & "')"
            lisSql.Add(sql)
        Next
        Return lisSql
    End Function
    Public Function updateFecHoraTurno(ByVal fec_hora As String, ByVal estadoTurno As Boolean, ByVal consecutivoDet As String, ByVal consecutivoPpal As String) As String
        Dim sql As String = ""
        Dim tipo As String = ""
        If (estadoTurno = False) Then
            tipo = "fec_hora_ini"
        Else
            tipo = "fec_hora_fin"
        End If
        sql = "UPDATE  J_det_orden_prod SET " & tipo & " = '" & fec_hora & "' WHERE id_detalle =" & consecutivoDet & " AND cod_orden =" & consecutivoPpal
        Return sql
    End Function
    Public Function updateTransaccionesOrden(ByVal entrada As Double, ByVal consecutivoDet As String, ByVal consecutivoPpal As String) As String
        Dim sql As String = ""
        Dim tipo As String = ""
        sql = "UPDATE  J_det_orden_prod SET transaccion_entrada = '" & entrada & "' WHERE cod_orden=" & consecutivoPpal & " and id_detalle=" & consecutivoDet & ""
        Return sql
    End Function
    Public Function cargarPlanInsp(ByVal consecutivoPpal As String, ByVal consecutivoDet As String) As DataTable
        Dim sql As String = "SELECT id_hora,cod_orden,cod_detalle,hora,diametro,resistencia,cash,helice,peso,apariencia " &
                                "FROM J_plan_insp " &
                                    "WHERE cod_orden = " & consecutivoPpal & " AND cod_detalle =" & consecutivoDet & " order by hora"
        Return obj_Ing_prodAd.listar_datatable(sql, "PRODUCCION")
    End Function

    Public Function cargarPlanInspCal(ByVal consecutivoPpal As String, ByVal consecutivoDet As String) As DataTable
        Dim sql As String = "SELECT id_hora,cod_orden,cod_detalle,hora,diametro,circularidad,peso,apariencia,resistencia,cash,helice,observaciones" &
                                " FROM J_plan_insp_cal " &
                                    "WHERE cod_orden = " & consecutivoPpal & " AND cod_detalle =" & consecutivoDet
        Return obj_Ing_prodAd.listar_datatable(sql, "PRODUCCION")
    End Function
    Public Function cargarPlanInspCalRec(ByVal consecutivoPpal As String, ByVal consecutivoDet As String) As DataTable
        Dim sql As String = "SELECT id_hora,cod_orden,cod_detalle,hora,resistencia" &
                                " FROM J_plan_insp_cal_rec " &
                                    "WHERE cod_orden = " & consecutivoPpal & " AND cod_detalle =" & consecutivoDet
        Return obj_Ing_prodAd.listar_datatable(sql, "PRODUCCION")
    End Function
    Public Function planillaNoTrbajada(ByVal consecutivoPpal, ByVal consecutivoDetalle) As Boolean
        Dim sql As String = "SELECT fec_hora_ini FROM J_det_orden_prod WHERE cod_orden = " & consecutivoPpal & " AND id_detalle = " & consecutivoDetalle
        If (objOperacionesDb.consultValor(sql, "PRODUCCION") = "") Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Function cambiarFormatoFecha(ByVal fec As Date) As String
        Dim strFec As String = fec.Year & "-" & fec.Month & "-" & fec.Day
        Return strFec
    End Function
    Public Function consecutivo_planilla_abierta_hoy(ByVal operario As Double, ByVal num_orden As Double) As String
        Dim Sfec As String = cambiarFormatoFecha(Now)
        Dim SfecMenos1dia As String = cambiarFormatoFecha(Now.AddDays(-1))
        Dim resp As String = ""
        Dim sql As String = "SELECT id_detalle  FROM J_det_orden_prod  WHERE operario = " & operario & " AND cod_orden=" & num_orden & " AND (fecha_prod = '" & Sfec & "' OR fecha_prod = '" & SfecMenos1dia & "'  ) AND cerrado is null "
        resp = obj_Ing_prodAd.consultar_valor(sql, "PRODUCCION")
        Return resp
    End Function
    Public Function mover_consecutivo(ByVal tipo As String) As Double
        Dim sqlMaxNumero As String = "SELECT CASE WHEN (MAX (siguiente)) is null THEN 0 ELSE MAX (siguiente) END  FROM consecutivos WHERE  tipo = '" & tipo & "'"
        Dim numero As Double = obj_Ing_prodAd.consultValor(sqlMaxNumero, "CORSAN")
        numero += 1
        Dim sql As String = "UPDATE consecutivos " & _
                  "SET siguiente = " & numero & " " & _
                  "WHERE tipo = '" & tipo & "'"
        objOperacionesDb.ejecutar(sql, "CORSAN")
        Return numero
    End Function

End Class
