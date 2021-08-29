Imports accesoDatos
Public Class RelojLn
    Dim objOpSimplesLn As New Op_simpesLn
    Public Function calcular_horas_ordinarias(ByVal periodo As Double, ByVal nit As Double, ByVal horas_laborales As Double, ByVal horas_totales As Double, ByVal fecha_limite_marcaciones As Date) As DataTable
        Dim sql As String = "SELECT e.id,e.nit,e.periodo , d.fecha, t.id As id_turno,CAST(d.turno as varchar) + ' - ' + t.Descripcion As turno , t.ord_diur,t.ord_noct,t.compensatorio,extras,y.domingo ,y.festivo, y.sabado " & _
                                "FROM J_prog_turno_enc e , J_prog_turno_det d , CORSAN.dbo.J_turnos t , CORSAN.dbo.y_calendario y " & _
                                    "WHERE e.id = d.id_enc And t.id = d.turno And e.periodo = " & periodo & "  And nit = " & nit & " And y.fecha = d.fecha " & _
                                         "ORDER BY e.nit"
        Dim dt As DataTable = objOpSimplesLn.listar_datatable(sql, "CONTROL")
        Dim sql_permisos As String = "SELECT horas,concepto FROM y_novedades WHERE concepto IN (34,35,36,37,510,77,78,90) AND idPeriodo =" & periodo & " AND nit = " & nit
        Dim dt_permisos As DataTable = objOpSimplesLn.listar_datatable(sql_permisos, "CORSAN")
        Dim dt_suspension As New DataTable
        Dim sql_bonificacion As String = "SELECT valor,concepto FROM y_novedades WHERE concepto IN (43) AND idPeriodo =" & periodo & " AND nit = " & nit
        Dim dt_bonificacion As DataTable = objOpSimplesLn.listar_datatable(sql_bonificacion, "CORSAN")
        Dim sql_falta_no_just As String = "SELECT valor,concepto FROM y_novedades WHERE concepto IN (516) AND idPeriodo =" & periodo & " AND nit = " & nit
        Dim dt_falta_no_just As DataTable = objOpSimplesLn.listar_datatable(sql_bonificacion, "CORSAN")
        Dim dt_incapacidad As New DataTable
        Dim dt_vacaciones As New DataTable
        Dim dt_resp As New DataTable
        Dim idTurno As Integer = 0
        Dim horas_dom_sancion As Integer = 0
        Dim horas_diur As Integer = 0
        Dim horas_noct As Integer = 0
        Dim dom_fest_no_lab As Integer = 0
        Dim desc_compensatorio As Integer = 0
        Dim horas_extras As Integer = 0
        Dim dif As Integer = 0
        Dim dif_no_aut As Integer = 0
        Dim dom As Boolean = False
        Dim fest As Boolean = False
        Dim dom_diur As Integer = 0
        Dim dom_noct As Integer = False
        Dim sabado As Boolean = False
        Dim proyectar_rec_noct As Boolean = False
        Dim fecha As New Date
        dt_resp.Columns.Add("periodo")
        dt_resp.Columns.Add("nit")
        dt_resp.Columns.Add("OrD")
        dt_resp.Columns.Add("RN") '------------------concepto =17
        dt_resp.Columns.Add("DF")
        dt_resp.Columns.Add("DD", GetType(Double))
        dt_resp.Columns.Add("DN", GetType(Double))
        dt_resp.Columns.Add("DComp")
        dt_resp.Columns.Add("PR", GetType(Double)) '------------------concepto =34
        dt_resp.Columns.Add("PRH", GetType(Double)) '------------------concepto =77
        dt_resp.Columns.Add("PV", GetType(Double)) '------------------concepto =78
        dt_resp.Columns.Add("PD", GetType(Double)) '------------------concepto =35
        dt_resp.Columns.Add("PE", GetType(Double)) '------------------concepto =36
        dt_resp.Columns.Add("PC", GetType(Double)) '------------------concepto =37
        dt_resp.Columns.Add("PN", GetType(Double)) '------------------concepto =510
        dt_resp.Columns.Add("IR", GetType(Double)) '------------------concepto =5
        dt_resp.Columns.Add("IA", GetType(Double)) '------------------concepto =6
        dt_resp.Columns.Add("LM", GetType(Double)) '------------------concepto =7
        dt_resp.Columns.Add("V", GetType(Double)) '------------------no tiene
        dt_resp.Columns.Add("DS", GetType(Double)) '------------------511
        dt_resp.Columns.Add("SU", GetType(Double)) '------------------512
        dt_resp.Columns.Add("BON", GetType(Double)) '------------------43
        dt_resp.Columns.Add("FN", GetType(Double)) '------------------516
        dt_resp.Columns.Add("HL", GetType(Double)) '------------------CONCEPTO = 90
        For i = 0 To dt.Rows.Count - 1
            fecha = dt.Rows(i).Item("fecha")
            If fecha > fecha_limite_marcaciones Then
                proyectar_rec_noct = True
            Else
                proyectar_rec_noct = False
            End If
            idTurno = dt.Rows(i).Item("id_turno")
            If (dt.Rows(i).Item("domingo") = "True") Then
                dom = True
            Else
                dom = False
            End If
            If (dt.Rows(i).Item("festivo") = "True") Then
                fest = True
            Else
                fest = False
            End If
            If (dt.Rows(i).Item("sabado") = "True") Then
                sabado = True
            Else
                sabado = False
            End If
            If i = 0 Then
                dt_resp.Rows.Add()
                dt_resp.Rows(dt_resp.Rows.Count - 1).Item("nit") = dt.Rows(i).Item("nit")
                dt_resp.Rows(dt_resp.Rows.Count - 1).Item("periodo") = dt.Rows(i).Item("periodo")
            End If
            If dom Or fest Then
                If verificar_dom_sansion(nit, dt.Rows(i).Item("fecha")) Then
                    horas_dom_sancion += 8
                Else
                    If dom Then
                        If idTurno = 3 Or idTurno = 11 Or idTurno = 13 Or idTurno = 19 Or idTurno = 9 Then
                            If verificar_fest_compensatorio(dt.Rows(i).Item("fecha"), dt) Then
                                desc_compensatorio += dt.Rows(i).Item("compensatorio")
                                If (proyectar_rec_noct) Then
                                    dom_noct += 2
                                    horas_noct += dt.Rows(i).Item("ord_noct") - 2
                                Else
                                    dom_noct += dt.Rows(i).Item("ord_noct")
                                End If
                            Else
                                If verificar_dia_incapacidad(nit, dt.Rows(i).Item("fecha")) = False And verificar_dia_vacaciones(nit, dt.Rows(i).Item("fecha")) = False Then
                                    dom_fest_no_lab += 8
                                    If (proyectar_rec_noct) Then
                                        dom_noct += 2
                                        horas_noct += dt.Rows(i).Item("ord_noct") - 2
                                    End If
                                End If
                            End If
                        Else
                            If verificar_fest_compensatorio(dt.Rows(i).Item("fecha"), dt) Then
                                desc_compensatorio += dt.Rows(i).Item("compensatorio")
                                dom_diur += dt.Rows(i).Item("ord_diur")
                            Else
                                If verificar_dia_incapacidad(nit, dt.Rows(i).Item("fecha")) = False And verificar_dia_vacaciones(nit, dt.Rows(i).Item("fecha")) = False Then
                                    dom_fest_no_lab += 8
                                End If
                            End If
                        End If
                    Else
                        If verificar_fest_compensatorio(dt.Rows(i).Item("fecha"), dt) Then
                            desc_compensatorio += dt.Rows(i).Item("compensatorio")
                            dom_diur += dt.Rows(i).Item("ord_diur")
                            dom_noct += dt.Rows(i).Item("ord_noct")
                        Else
                            If verificar_dia_incapacidad(nit, dt.Rows(i).Item("fecha")) = False And verificar_dia_vacaciones(nit, dt.Rows(i).Item("fecha")) = False Then
                                If idTurno = 3 Or idTurno = 11 Or idTurno = 13 Or idTurno = 19 Or idTurno = 9 Then
                                    If (proyectar_rec_noct) Then
                                        'dom_noct += 2
                                        'horas_noct += dt.Rows(i).Item("ord_noct") - 2
                                    Else
                                        'dom_noct += dt.Rows(i).Item("ord_noct")
                                    End If
                                End If
                                'dom_fest_no_lab += 8
                            End If
                        End If
                    End If
                End If
            ElseIf sabado Then
                If verificar_fest_compensatorio(dt.Rows(i).Item("fecha"), dt) Then
                    desc_compensatorio += dt.Rows(i).Item("compensatorio")
                    dom_noct += dt.Rows(i).Item("ord_noct")
                    If idTurno = 3 Or idTurno = 11 Or idTurno = 13 Or idTurno = 19 Or idTurno = 9 Then
                        If (proyectar_rec_noct) Then
                            horas_noct += 2
                            dom_noct += dt.Rows(i).Item("ord_noct") - 2
                        End If
                    End If
                Else
                    horas_diur += dt.Rows(i).Item("ord_diur")
                    If (proyectar_rec_noct) Then
                        If Not (idTurno = 3 Or idTurno = 11 Or idTurno = 13 Or idTurno = 19) Then
                            horas_noct += dt.Rows(i).Item("ord_noct")
                        End If
                    End If
                End If
            Else
                desc_compensatorio += dt.Rows(i).Item("compensatorio")
                If verificar_dia_incapacidad(nit, dt.Rows(i).Item("fecha")) = False And verificar_dia_vacaciones(nit, dt.Rows(i).Item("fecha")) = False Then
                    horas_diur += dt.Rows(i).Item("ord_diur")
                    If (proyectar_rec_noct) Then
                        horas_noct += dt.Rows(i).Item("ord_noct")
                    End If
                End If
            End If
            horas_extras += dt.Rows(i).Item("extras")

        Next
        ''FIN DEL CICLO *************************************************

        For i = 0 To dt_permisos.Rows.Count - 1
            If dt_resp.Rows.Count = 0 Then
                dt_resp.Rows.Add()
                dt_resp.Rows(dt_resp.Rows.Count - 1).Item("nit") = nit
            End If
            If i = 0 Then
                dt_resp.Rows(dt_resp.Rows.Count - 1).Item("PR") = 0
                dt_resp.Rows(dt_resp.Rows.Count - 1).Item("PRH") = 0
                dt_resp.Rows(dt_resp.Rows.Count - 1).Item("PV") = 0
                dt_resp.Rows(dt_resp.Rows.Count - 1).Item("PD") = 0
                dt_resp.Rows(dt_resp.Rows.Count - 1).Item("PE") = 0
                dt_resp.Rows(dt_resp.Rows.Count - 1).Item("PC") = 0
                dt_resp.Rows(dt_resp.Rows.Count - 1).Item("PN") = 0
                dt_resp.Rows(dt_resp.Rows.Count - 1).Item("HL") = 0
            End If
            Select Case dt_permisos.Rows(i).Item("concepto")
                Case 34
                    dt_resp.Rows(dt_resp.Rows.Count - 1).Item("PR") += dt_permisos.Rows(i).Item("horas")
                Case 77
                    dt_resp.Rows(dt_resp.Rows.Count - 1).Item("PRH") += dt_permisos.Rows(i).Item("horas")
                Case 78
                    dt_resp.Rows(dt_resp.Rows.Count - 1).Item("PV") += dt_permisos.Rows(i).Item("horas")
                Case 35
                    dt_resp.Rows(dt_resp.Rows.Count - 1).Item("PD") += dt_permisos.Rows(i).Item("horas")
                Case 36
                    dt_resp.Rows(dt_resp.Rows.Count - 1).Item("PE") += dt_permisos.Rows(i).Item("horas")
                Case 37
                    dt_resp.Rows(dt_resp.Rows.Count - 1).Item("PC") += dt_permisos.Rows(i).Item("horas")
                Case 510
                    dt_resp.Rows(dt_resp.Rows.Count - 1).Item("PN") += dt_permisos.Rows(i).Item("horas")
                Case 90
                    dt_resp.Rows(dt_resp.Rows.Count - 1).Item("HL") += dt_permisos.Rows(i).Item("horas")
            End Select
        Next
        dt_incapacidad = concepto_horas_incapacidad(nit, periodo)
        For i = 0 To dt_incapacidad.Rows.Count - 1
            If i = 0 Then
                If dt_resp.Rows.Count = 0 Then
                    dt_resp.Rows.Add()
                End If
                dt_resp.Rows(dt_resp.Rows.Count - 1).Item("IR") = 0
                dt_resp.Rows(dt_resp.Rows.Count - 1).Item("IA") = 0
                dt_resp.Rows(dt_resp.Rows.Count - 1).Item("LM") = 0
            End If
            If dt_resp.Rows.Count = 0 Then
                dt_resp.Rows.Add()
                dt_resp.Rows(dt_resp.Rows.Count - 1).Item("nit") = nit
            End If
            Select Case dt_incapacidad.Rows(i).Item("concepto")
                Case 5
                    dt_resp.Rows(dt_resp.Rows.Count - 1).Item("IR") += dt_incapacidad.Rows(i).Item("horas")
                Case 6
                    dt_resp.Rows(dt_resp.Rows.Count - 1).Item("IA") += dt_incapacidad.Rows(i).Item("horas")
                Case 7
                    dt_resp.Rows(dt_resp.Rows.Count - 1).Item("LM") += dt_incapacidad.Rows(i).Item("horas")
            End Select
        Next
        dt_suspension = dt_horas_suspension(nit, periodo)
        For i = 0 To dt_suspension.Rows.Count - 1
            If i = 0 Then
                If dt_resp.Rows.Count = 0 Then
                    dt_resp.Rows.Add()
                End If
                dt_resp.Rows(dt_resp.Rows.Count - 1).Item("SU") = 0
            End If
            If dt_resp.Rows.Count = 0 Then
                dt_resp.Rows.Add()
                dt_resp.Rows(dt_resp.Rows.Count - 1).Item("nit") = nit
            End If
            Select Case dt_suspension.Rows(i).Item("concepto")
                Case 512
                    dt_resp.Rows(dt_resp.Rows.Count - 1).Item("SU") += dt_suspension.Rows(i).Item("horas")
            End Select
        Next
        For i = 0 To dt_bonificacion.Rows.Count - 1
            If i = 0 Then
                If dt_resp.Rows.Count = 0 Then
                    dt_resp.Rows.Add()
                End If
                dt_resp.Rows(dt_resp.Rows.Count - 1).Item("BON") = 0
            End If
            If dt_resp.Rows.Count = 0 Then
                dt_resp.Rows.Add()
                dt_resp.Rows(dt_resp.Rows.Count - 1).Item("nit") = nit
            End If
            Select Case dt_bonificacion.Rows(i).Item("concepto")
                Case 43
                    dt_resp.Rows(dt_resp.Rows.Count - 1).Item("BON") += dt_bonificacion.Rows(i).Item("valor")
            End Select
        Next
        For i = 0 To dt_falta_no_just.Rows.Count - 1
            If i = 0 Then
                If dt_resp.Rows.Count = 0 Then
                    dt_resp.Rows.Add()
                End If
                dt_resp.Rows(dt_resp.Rows.Count - 1).Item("FN") = 0
            End If
            If dt_resp.Rows.Count = 0 Then
                dt_resp.Rows.Add()
                dt_resp.Rows(dt_resp.Rows.Count - 1).Item("nit") = nit
            End If
            Select Case dt_falta_no_just.Rows(i).Item("concepto")
                Case 516
                    dt_resp.Rows(dt_resp.Rows.Count - 1).Item("FN") += dt_falta_no_just.Rows(i).Item("valor")
                    horas_diur += dt_falta_no_just.Rows(i).Item("valor")
            End Select
        Next
        dt_vacaciones = dt_horas_vacaciones(nit, periodo)
        For i = 0 To dt_vacaciones.Rows.Count - 1
            If dt_resp.Rows.Count = 0 Then
                dt_resp.Rows.Add()
                dt_resp.Rows(dt_resp.Rows.Count - 1).Item("nit") = nit
            End If
            dt_resp.Rows(dt_resp.Rows.Count - 1).Item("V") += dt_vacaciones.Rows(i).Item("horas")
        Next
        If ((horas_diur + desc_compensatorio) > horas_laborales) Then
            dif_no_aut = (horas_diur + desc_compensatorio) - horas_laborales
            horas_diur -= dif_no_aut
        End If
        'cuando es descanzo compensatorio los sabados para que reste a dom_festivas
        dif = horas_totales - horas_laborales
        If (desc_compensatorio + dom_fest_no_lab + horas_dom_sancion) > dif Then
            If dom_fest_no_lab > 0 Then
                dom_fest_no_lab -= dif
            End If
        End If
        If (horas_diur > 0) Then
            If (horas_diur + desc_compensatorio ) < horas_laborales Then
                dif = (horas_laborales - (horas_diur + desc_compensatorio))
                If (horas_extras > 0) Then
                    horas_diur += dif
                    horas_extras -= dif
                Else
                    horas_diur += dif
                End If
            End If
        End If
        Dim dif_ord_fest_lab As Integer = horas_totales - horas_laborales
        If (dom_fest_no_lab + horas_dom_sancion + desc_compensatorio) < dif_ord_fest_lab Then
            horas_diur += dif_ord_fest_lab - (dom_fest_no_lab + horas_dom_sancion + desc_compensatorio)
        End If
        If (dt_resp.Rows.Count > 0) Then
            dt_resp.Rows(dt_resp.Rows.Count - 1).Item("OrD") = horas_diur
            dt_resp.Rows(dt_resp.Rows.Count - 1).Item("RN") = horas_noct
            dt_resp.Rows(dt_resp.Rows.Count - 1).Item("DF") = dom_fest_no_lab
            dt_resp.Rows(dt_resp.Rows.Count - 1).Item("DComp") = desc_compensatorio
            dt_resp.Rows(dt_resp.Rows.Count - 1).Item("DD") = dom_diur
            dt_resp.Rows(dt_resp.Rows.Count - 1).Item("DN") = dom_noct
            dt_resp.Rows(dt_resp.Rows.Count - 1).Item("DS") = horas_dom_sancion
        End If
        Return dt_resp
    End Function
    Private Function verificar_fest_compensatorio(ByVal fec As String, ByRef dt As DataTable) As Boolean
        Dim resp As Boolean = False
        For i = 0 To dt.Rows.Count - 1
            If dt.Rows(i).Item("fecha") = fec And dt.Rows(i).Item("id_turno") = 99 Then
                resp = True
                i = dt.Rows.Count - 1
            End If
        Next
        Return resp
    End Function
    Public Function get_sql_cerrar_j_periodos_nomina(ByVal id_periodo As Integer) As String
        Dim sql As String = "UPDATE J_periodos_nomina SET liquidado = 'S' WHERE id_periodo =" & id_periodo
        Return sql
    End Function
    Public Function verificar_periodo_liquidado(ByVal id_periodo As Integer) As Boolean
        Dim sql As String = "SELECT id FROM J_periodos_nomina WHERE liquidado = 'S' AND id_periodo = " & id_periodo
        If objOpSimplesLn.consultarVal(sql) <> "" Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Function consultar_horas_turno(ByVal id_turno As Integer) As Integer
        Dim sql As String = "SELECT horas FROM J_turnos WHERE id = " & id_turno
        Return objOpSimplesLn.consultarVal(sql)
    End Function
    Public Function sql_descontar_horas_compromiso(ByVal nit As Double, ByVal horas As Double, ByVal nocturno As Boolean) As List(Of Object)
        Dim listSql As New List(Of Object)
        Dim horas_final As Double = 0
        Dim horas_dt As Double = 0
        Dim horas_debe As Double = horas
        Dim whereNocturno As String = ""
        If nocturno Then
            whereNocturno &= "AND nocturno  = 'S'"
        Else
            whereNocturno &= "AND (nocturno = 'N' or nocturno is null)"
        End If
        Dim sql_consulta As String = " SELECT id,fecha_compromiso,horas FROM R_compromiso_horas_a_pagar " & _
                                            "WHERE  Activo = 'True'  AND horas >0 AND Nit_Trabajador = " & nit
        Dim sql_update As String = "UPDATE  R_compromiso_horas_a_pagar SET Horas -= " & horas & " " & _
                                          "WHERE Activo = 'True' AND Horas >0 AND Nit_Trabajador = " & nit & whereNocturno
        Dim dt As DataTable = objOpSimplesLn.listar_datatable(sql_consulta, "CONTROL")
        For i = 0 To dt.Rows.Count - 1
            horas_dt = dt.Rows(i).Item("horas")
            If (horas_dt >= horas) Then
                horas_final = horas
                i = dt.Rows.Count - 1
            Else
                horas_final = (horas - (horas_dt))
                horas -= horas_final
            End If

            horas_debe = horas_final
            If horas > 0 Then
                listSql.Add("UPDATE  R_compromiso_horas_a_pagar SET Horas -= " & horas & " " & _
                             "WHERE  id = " & dt.Rows(i).Item("id"))
            End If
            horas = horas_debe
        Next
        Return listSql
    End Function
    Public Function aut_novedad_dms(ByVal idNovedad As Double, ByVal notas As String) As Boolean
        Dim listSql As New List(Of Object)
        Dim sql As String = "SELECT nomina,contrato,nit,idperiodo,concepto,fecha,mes,ano,periodo,valor,horas,dias,centro,planta,turno,nro_presta,sumar,oficio,notas,usuario " &
                                "FROM J_novedades_no_aut " & _
                                    "WHERE idnovedad =" & idNovedad
        Dim dt_no_aut As DataTable = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        Dim sql_insert As String = ""
        For i = 0 To dt_no_aut.Rows.Count - 1
            If validar_fk_novedad(dt_no_aut.Rows(i).Item("nit"), dt_no_aut.Rows(i).Item("concepto"), dt_no_aut.Rows(i).Item("idperiodo")) Then
                sql_insert = "INSERT INTO y_novedades" & _
                                                "(nomina,contrato,nit,idperiodo,concepto,fecha,mes,ano,periodo,valor,horas,dias,centro,planta,turno,nro_presta,sumar,oficio) " & _
                                                "VALUES (" & dt_no_aut.Rows(i).Item("nomina") & "," & dt_no_aut.Rows(i).Item("contrato") & "," & dt_no_aut.Rows(i).Item("nit") & "," & dt_no_aut.Rows(i).Item("idperiodo") & "," & dt_no_aut.Rows(i).Item("concepto") & ",'" & objOpSimplesLn.cambiarFormatoFecha(dt_no_aut.Rows(i).Item("fecha")) & "'," & dt_no_aut.Rows(i).Item("mes") & ", " & _
                                                    "" & dt_no_aut.Rows(i).Item("ano") & "," & dt_no_aut.Rows(i).Item("periodo") & "," & dt_no_aut.Rows(i).Item("valor") & "," & dt_no_aut.Rows(i).Item("horas") & "," & dt_no_aut.Rows(i).Item("dias") & "," & dt_no_aut.Rows(i).Item("centro") & "," & dt_no_aut.Rows(i).Item("planta") & "," & dt_no_aut.Rows(i).Item("turno") & "," & dt_no_aut.Rows(i).Item("nro_presta") & "," & Convert.ToInt16(dt_no_aut.Rows(i).Item("sumar")) & "," & dt_no_aut.Rows(i).Item("oficio") & ") "
            Else
                sql_insert = "UPDATE y_novedades " & _
                                               " SET valor +=  " & dt_no_aut.Rows(i).Item("valor") & " ,horas += " & dt_no_aut.Rows(i).Item("horas") & ",dias += " & dt_no_aut.Rows(i).Item("dias") & " " & _
                                                    "WHERE nit = " & dt_no_aut.Rows(i).Item("nit") & " AND idperiodo = " & dt_no_aut.Rows(i).Item("idperiodo") & " AND concepto = " & dt_no_aut.Rows(i).Item("concepto")
            End If
        Next
        If sql_insert <> "" Then
            listSql.Add(sql_insert)
            listSql.Add(autorizar_novedad_sql(idNovedad, "S", notas))
        End If
        If objOpSimplesLn.ExecuteSqlTransaction(listSql) Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Function autorizar_novedad_sql(ByVal idNovedad As Double, ByVal autorizacion As String, ByVal notas As String) As String
        Dim sql As String = "UPDATE J_novedades_no_aut SET autorizado = '" & autorizacion & "',notas_aut = '" & notas & "' WHERE idNovedad =" & idNovedad
        Return sql
    End Function
    Public Function validar_fk_novedad_no_aut(ByVal nit As Double, ByVal concepto As Integer, ByVal id_periodo As Double)
        Dim resp As Boolean = True
        Dim sql As String = "SELECT nit FROM J_novedades_no_aut WHERE nit = " & nit & " AND idperiodo = " & id_periodo & " AND concepto = " & concepto & "  AND autorizado  ='N'"
        If (objOpSimplesLn.consultarVal(sql) <> "") Then
            resp = False
        End If
        Return resp
    End Function
    Public Function validar_fk_novedad(ByVal nit As Double, ByVal concepto As Integer, ByVal id_periodo As Double)
        Dim resp As Boolean = True
        Dim sql As String = "SELECT nit FROM y_novedades WHERE nit = " & nit & " AND idperiodo = " & id_periodo & " AND concepto = " & concepto
        If (objOpSimplesLn.consultarVal(sql) <> "") Then
            resp = False
        End If
        Return resp
    End Function
    Public Function verificar_empleados_sin_turno(ByVal centros As String, ByVal id_periodo As Integer) As String
        Dim whereCentro As String = ""
        If centros <> "" Then
            whereCentro = "centro IN (" & centros & ") AND "
        End If

        Dim sql As String = "SELECT nit,nombres ,centro " & _
                                "FROM V_nom_personal_Activo_con_maquila " & _
                                   "WHERE " & whereCentro & "  nit NOT IN (SELECT nit FROM CONTROL.dbo.J_prog_turno_enc WHERE periodo = " & id_periodo & ") AND nit NOT IN (SELECT nit FROM CONTROL.dbo.J_pers_planta_no_marca)" & _
                                    "ORDER BY nombres"
        Dim dt As DataTable = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        Dim nomb_sin_turno As String = ""
        For i = 0 To dt.Rows.Count - 1
            nomb_sin_turno &= dt.Rows(i).Item("nombres") & vbCrLf
        Next
        Return nomb_sin_turno
    End Function
    Public Function sqlAddEntrada(ByVal nit As Double, ByVal permiso As String, ByVal maquila As String) As String
        Dim centro As String = obtener_centro(nit)
        Dim concecutivo As Double = objOpSimplesLn.consultValorTodo("SELECT  (SELECT CASE WHEN MAX(Consecutivo) IS NULL THEN (1) ELSE MAX(Consecutivo)+1 END) as Concecutivo FROM R_Personal_Registros", "CONTROL")
        Dim sql As String = "INSERT INTO R_Personal_Registros " &
                                "(Consecutivo,nit,FechaEntrada,permiso,maquila,centro) VALUES " &
                                    "(" & concecutivo & "," & nit & ",GETDATE (),'" & permiso & "','" & maquila & "'," & centro & ") "
        Return sql
    End Function
    Public Function sqlAddEntradaVisit(ByVal nit As Double, ByVal nombre As String) As String
        Dim centro As String = obtener_centro(nit)
        Dim concecutivo As Double = objOpSimplesLn.consultValorTodo("SELECT  (SELECT CASE WHEN MAX(Consecutivo) IS NULL THEN (1) ELSE MAX(Consecutivo)+1 END) as Concecutivo FROM R_Personal_Registros_visitante", "CONTROL")
        Dim sql As String = "INSERT INTO R_Personal_Registros_visitante" &
                                "(Consecutivo,nit,FechaEntrada,nombres) VALUES " &
                                    "(" & concecutivo & "," & nit & ",GETDATE(),'" & nombre & "')"
        Return sql
    End Function
    Public Function sqlAddSalida(ByVal nit As Double, ByVal permiso As String, ByVal maquila As String) As String
        Dim centro As String = obtener_centro(nit)
        Dim fec_min As Date = Now.AddHours(-14)
        Dim sFec_min As String = fec_min.Year & "-" & fec_min.Month & "-" & fec_min.Day & " " & fec_min.Hour & ":" & fec_min.Minute & ":00"
        Dim sql As String = "UPDATE R_Personal_Registros " &
                               "SET FechaSalida = GETDATE (),permiso = '" & permiso & "',maquila = '" & maquila & "' " &
                                     "WHERE nit = " & nit & " AND FechaEntrada >= '" & sFec_min & "' AND FechaSalida is null "

        Return sql
    End Function
    Public Function sqlAddSalidaVisit(ByVal nit As Double) As String
        Dim fec_min As Date = Now.AddHours(-14)
        Dim sFec_min As String = fec_min.Year & "-" & fec_min.Month & "-" & fec_min.Day & " " & fec_min.Hour & ":" & fec_min.Minute & ":00"
        Dim sql As String = "UPDATE R_Personal_Registros_visitante " &
                               "SET FechaSalida = GETDATE () " &
                                     "WHERE nit = " & nit & " AND FechaEntrada >= '" & sFec_min & "' AND FechaSalida is null "

        Return sql
    End Function
    Public Function esSalida(ByVal nit As Double) As Boolean
        Dim fec_min As Date = Now.AddHours(-14)
        Dim sFec_min As String = fec_min.Year & "-" & fec_min.Month & "-" & fec_min.Day & " " & fec_min.Hour & ":" & fec_min.Minute & ":00"
        Dim sql As String = "SELECT Consecutivo " & _
                                "FROM R_Personal_Registros" & _
                                     " WHERE nit = " & nit & " AND FechaEntrada >= '" & sFec_min & "' AND FechaSalida is null "

        If objOpSimplesLn.consultValorTodo(sql, "CONTROL") <> "" Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Function getHorasTrabajadas(ByVal nit As Double) As Double
        Dim horas As String = ""
        Dim sql As String = "SELECT DATEDIFF ( HOUR , FechaEntrada , GETDATE() ) As horas " & _
                                "FROM R_Personal_Registros " & _
                                     "WHERE Consecutivo = (SELECT MAX(consecutivo) FROM R_Personal_Registros WHERE nit = " & nit & " AND fechaSalida is null) "
        horas = objOpSimplesLn.consultValorTodo(sql, "CONTROL")
        If horas = "" Then
            Return 0
        Else
            Return horas
        End If
    End Function
    Public Function getDiffUltSalida(ByVal nit As Double) As Double
        Dim horas As String = ""
        Dim sql As String = "SELECT DATEDIFF (HOUR ,MAX(FechaSalida),GETDATE()) " & _
                                "FROM R_Personal_Registros " & _
                                     "WHERE nit =" & nit
        horas = objOpSimplesLn.consultValorTodo(sql, "CONTROL")
        If horas = "" Then
            Return 1
        Else
            Return horas
        End If
    End Function
    Public Function sqlUpdatePermisoSalida(ByVal nit As Double) As String
        Dim sql As String = "UPDATE J_permiso_marcacion  " & _
                                "SET Fecha_salida = GETDATE () " & _
                                     "WHERE nit = " & nit & " AND Fecha_salida is null "

        Return sql
    End Function
    Public Function permisoSalida(ByVal nit As Double) As Boolean
        Dim sql As String = "SELECT nit " & _
                                "FROM J_permiso_marcacion " & _
                                     "WHERE nit = " & nit & " AND Fecha_salida is null "
        If objOpSimplesLn.consultValorTodo(sql, "CONTROL") <> "" Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Function concepto_horas_incapacidad(ByVal nit As Double, ByVal periodo As Integer) As DataTable
        Dim horas As Double = 0
        Dim dt_resp As New DataTable
        Dim dt_datos As New DataTable
        Dim fecha_ini As Date
        Dim fecha_fin As Date
        Dim fec_ini_calculo As Date
        Dim fec_fin_calculo As Date
        Dim sql_periodo As String = "SELECT fecha_inicial,fecha_final " & _
                                        "FROM y_periodos_control " & _
                                                "WHERE IdPeriodo = " & periodo
        Dim dt_periodo As DataTable = objOpSimplesLn.listar_datatable(sql_periodo, "CORSAN")
        For i = 0 To dt_periodo.Rows.Count - 1
            fecha_ini = dt_periodo.Rows(i).Item("fecha_inicial")
            fecha_fin = dt_periodo.Rows(i).Item("fecha_final")
        Next

        Dim sql As String = "SELECT nit,concepto,fecha_ini_liq,fecha_fin_liq   " & _
                                "FROM y_incapacidad " & _
                                     "WHERE (fecha_ini_liq >= '" & objOpSimplesLn.cambiarFormatoFecha(fecha_ini) & "' OR fecha_fin_liq >= '" & objOpSimplesLn.cambiarFormatoFecha(fecha_ini) & "' ) AND  nit = " & nit & " "
        dt_resp.Columns.Add("concepto")
        dt_resp.Columns.Add("horas")
        dt_datos = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        For i = 0 To dt_datos.Rows.Count - 1
            If (dt_datos.Rows(i).Item("fecha_ini_liq") > fecha_ini) Then
                fec_ini_calculo = dt_datos.Rows(i).Item("fecha_ini_liq")
            Else
                fec_ini_calculo = fecha_ini
            End If
            If (dt_datos.Rows(i).Item("fecha_fin_liq") < fecha_fin) Then
                fec_fin_calculo = dt_datos.Rows(i).Item("fecha_fin_liq")
            Else
                fec_fin_calculo = fecha_fin
            End If
            horas = (DateDiff(DateInterval.Day, fec_ini_calculo, fec_fin_calculo) + 1) * 8
            If horas > 0 Then
                dt_resp.Rows.Add()
                dt_resp.Rows(dt_resp.Rows.Count - 1).Item("concepto") = dt_datos.Rows(i).Item("concepto")
                dt_resp.Rows(dt_resp.Rows.Count - 1).Item("horas") = horas
            End If
        Next
        Return dt_resp
    End Function
    Public Function dt_horas_vacaciones(ByVal nit As Double, ByVal periodo As Integer) As DataTable
        Dim horas As Double = 0
        Dim dt_resp As New DataTable
        Dim dt_datos As New DataTable
        Dim fecha_ini As Date
        Dim fecha_fin As Date
        Dim fec_ini_calculo As Date
        Dim fec_fin_calculo As Date
        Dim sql_periodo As String = "SELECT fecha_inicial,fecha_final " & _
                                        "FROM y_periodos_control " & _
                                                "WHERE IdPeriodo = " & periodo
        Dim dt_periodo As DataTable = objOpSimplesLn.listar_datatable(sql_periodo, "CORSAN")
        For i = 0 To dt_periodo.Rows.Count - 1
            fecha_ini = dt_periodo.Rows(i).Item("fecha_inicial")
            fecha_fin = dt_periodo.Rows(i).Item("fecha_final")
        Next

        Dim sql As String = "SELECT nit,fecha_inicial,fecha_final   " & _
                                "FROM y_vacaciones " & _
                                     "WHERE  dias >0  AND (fecha_inicial >= '" & objOpSimplesLn.cambiarFormatoFecha(fecha_ini) & "' OR fecha_final >= '" & objOpSimplesLn.cambiarFormatoFecha(fecha_ini) & "') AND  nit = " & nit & " "
        dt_resp.Columns.Add("horas")
        dt_datos = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        For i = 0 To dt_datos.Rows.Count - 1
            dt_resp.Rows.Add()
            If (dt_datos.Rows(i).Item("fecha_inicial") > fecha_ini) Then
                fec_ini_calculo = dt_datos.Rows(i).Item("fecha_inicial")
            Else
                fec_ini_calculo = fecha_ini
            End If
            If (dt_datos.Rows(i).Item("fecha_final") < fecha_fin) Then
                fec_fin_calculo = dt_datos.Rows(i).Item("fecha_final")
            Else
                fec_fin_calculo = fecha_fin
            End If
            horas = (DateDiff(DateInterval.Day, fec_ini_calculo, fec_fin_calculo) + 1) * 8
            If horas < 0 Then
                horas = 0
            End If
            dt_resp.Rows(dt_resp.Rows.Count - 1).Item("horas") = horas
        Next
        Return dt_resp
    End Function
    Public Function dt_horas_suspension(ByVal nit As Double, ByVal periodo As Double) As DataTable
        Dim horas As Double = 0
        Dim dt_resp As New DataTable
        Dim dt_datos As New DataTable
        Dim fecha_ini As Date
        Dim fecha_fin As Date
        Dim fec_ini_calculo As Date
        Dim fec_fin_calculo As Date

        Dim sql_periodo As String = "SELECT fecha_inicial,fecha_final " & _
                                        "FROM y_periodos_control " & _
                                                "WHERE IdPeriodo = " & periodo
        Dim dt_periodo As DataTable = objOpSimplesLn.listar_datatable(sql_periodo, "CORSAN")
        For i = 0 To dt_periodo.Rows.Count - 1
            fecha_ini = dt_periodo.Rows(i).Item("fecha_inicial")
            fecha_fin = dt_periodo.Rows(i).Item("fecha_final")
        Next
        Dim sql As String = "SELECT nit,fecha_inicial,fecha_final,concepto   " & _
                                "FROM y_suspensiones " & _
                                     "WHERE concepto_suspension = 27 AND concepto = 512 AND (fecha_inicial >= '" & objOpSimplesLn.cambiarFormatoFecha(fecha_ini) & "' OR fecha_final >= '" & objOpSimplesLn.cambiarFormatoFecha(fecha_ini) & "') AND  nit = " & nit & " "
        dt_resp.Columns.Add("concepto")
        dt_resp.Columns.Add("horas")
        dt_datos = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        For i = 0 To dt_datos.Rows.Count - 1
            dt_resp.Rows.Add()
            If (dt_datos.Rows(i).Item("fecha_inicial") > fecha_ini) Then
                fec_ini_calculo = dt_datos.Rows(i).Item("fecha_inicial")
            Else
                fec_ini_calculo = fecha_ini
            End If
            If (dt_datos.Rows(i).Item("fecha_final") < fecha_fin) Then
                fec_fin_calculo = dt_datos.Rows(i).Item("fecha_final")
            Else
                fec_fin_calculo = fecha_fin
            End If
            horas = (DateDiff(DateInterval.Day, fec_ini_calculo, fec_fin_calculo) + 1) * 8
            dt_resp.Rows(dt_resp.Rows.Count - 1).Item("horas") = horas
            dt_resp.Rows(dt_resp.Rows.Count - 1).Item("concepto") = dt_datos.Rows(i).Item("concepto")
        Next
        Return dt_resp
    End Function
    Public Function modificar_turno(ByVal id_enc As Double, ByVal id_det As Double, ByVal sfec As String, ByVal codigo As Integer) As Boolean
        Dim listSql As New List(Of Object)
        Dim sql_delte As String = "DELETE FROM J_prog_turno_det WHERE id_enc =" & id_enc & " AND fecha = '" & sfec & "'"
        Dim sql_insert As String = "INSERT into J_prog_turno_det (id_enc,id_det,fecha,turno) VALUES (" & id_enc & "," & id_det & ",'" & sfec & "'," & codigo & ") "
        listSql.Add(sql_delte)
        listSql.Add(sql_insert)
        If (objOpSimplesLn.ExecuteSqlTransactionTodo(listSql, "CONTROL")) Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Function add_turno_dia(ByVal id_enc As Double, ByVal id_det As Double, ByVal sfec As String, ByVal codigo As Integer) As Boolean
        Dim listSql As New List(Of Object)
        Dim sql_insert As String = "INSERT into J_prog_turno_det (id_enc,id_det,fecha,turno) VALUES (" & id_enc & "," & id_det & ",'" & sfec & "'," & codigo & ") "
        listSql.Add(sql_insert)
        If (objOpSimplesLn.ExecuteSqlTransactionTodo(listSql, "CONTROL")) Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Function update_contrato_turno_de_reloj(ByVal nit_sin_contratos As String) As Boolean
        Dim sql As String = "UPDATE y_personal_contratos  " & _
                                "SET turno = 9 " & _
                                 "WHERE estado = 'A' AND nit IN (" & nit_sin_contratos & ")"
        If (objOpSimplesLn.ejecutar(sql, "CORSAN") > 0) Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Function update_contrato_turno_dms(ByVal nit_sin_contratos As String) As Boolean
        Dim sql As String = "UPDATE y_personal_contratos  " & _
                                "SET turno = 2 " & _
                                 "WHERE estado = 'A' AND nit IN (" & nit_sin_contratos & ")"
        If (objOpSimplesLn.ejecutar(sql, "CORSAN") > 0) Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Function get_dt_contrato_sin_turno_de_reloj(ByVal nits As String) As DataTable
        Dim sql As String = "SELECT y.nit,t.nombres     " & _
                                "FROM y_personal_contratos y , terceros t  " & _
                                    "WHERE y.nit = t.nit AND y.estado = 'A' AND y.turno <> 9 AND y.nit IN (" & nits & ")"
        Dim dt_resp As DataTable = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        Return dt_resp
    End Function
    Public Function get_dt_contrato_sin_turno_de_dms(ByVal nits As String) As DataTable
        Dim sql As String = "SELECT y.nit,t.nombres     " & _
                                "FROM y_personal_contratos y , terceros t  " & _
                                    "WHERE y.nit = t.nit AND y.estado = 'A' AND y.turno <> 2 AND y.nit IN (" & nits & ")"
        Dim dt_resp As DataTable = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        Return dt_resp
    End Function
    Public Function sql_novedad_no_aut(ByVal nit As Double, ByVal concepto As Integer, ByVal id_periodo As Double, ByVal fecha As String, ByVal contrato As Double, ByVal valor As Double, _
                                        ByVal horas As Integer, ByVal centro As Integer, ByVal planta As Integer, ByVal turno As Integer, ByVal oficio As Integer, ByVal observaciones As String, ByVal nom_usuario As String) As String
        Dim sql As String = ""
        Dim nro_presta As Integer = 0
        Dim dias As Double = horas / 8
        Dim nomina As Integer = 1
        Dim sumar As Integer = 0 'NO UTILIZAR HASTA NO DEFINIR CUANDO ES 1 Y 0
        Dim mes As Integer = objOpSimplesLn.consultarVal("SELECT mes FROM y_periodos_control WHERE idPeriodo = " & id_periodo)
        Dim ano As Integer = objOpSimplesLn.consultarVal("SELECT ano FROM y_periodos_control WHERE idPeriodo = " & id_periodo)
        Dim periodo As Integer = objOpSimplesLn.consultarVal("SELECT periodo FROM y_periodos_control WHERE idPeriodo = " & id_periodo)
        Dim autorizado As String = "N"
        If validar_fk_novedad_no_aut(nit, concepto, id_periodo) Then
            sql = "INSERT INTO J_novedades_no_aut " & _
                                        "(nomina,contrato,nit,idperiodo,concepto,fecha,mes,ano,periodo,valor,horas,dias,centro,planta,turno,nro_presta,sumar,oficio,notas,usuario , autorizado) " & _
                                        "VALUES (" & nomina & "," & contrato & "," & nit & "," & id_periodo & "," & concepto & ",'" & fecha & "'," & mes & ", " & _
                                            "" & ano & "," & periodo & "," & valor & "," & horas & "," & dias & "," & centro & "," & planta & "," & turno & "," & nro_presta & "," & sumar & "," & oficio & ",'" & observaciones & "','" & nom_usuario & "','" & autorizado & "') "
        Else
            sql = "UPDATE J_novedades_no_aut " & _
                                          " SET valor +=  " & valor & " ,horas += " & horas & ",dias += " & dias & " ,notas += ' -- ' + '" & observaciones & "' " & _
                                               "WHERE nit = " & nit & " AND idperiodo = " & id_periodo & " AND concepto = " & concepto & " AND autorizado  ='N'"
        End If
        Return sql
    End Function
    Public Function verificar_desc_compensatorio(ByVal nit As Double, ByVal fec As Date, ByRef dt_datos As DataTable, ByVal nom_col_fec As String, ByVal nom_col_id_turno As String) As Boolean
        Dim fec_buscar As String = objOpSimplesLn.cambiarFormatoFecha(fec)
        Dim fec_dtg As String = ""
        Dim id_turno As Integer = 0
        For i = 0 To dt_datos.Rows.Count - 1
            If Not IsDBNull(dt_datos.Rows(i).Item("nit")) Then
                fec_dtg = objOpSimplesLn.cambiarFormatoFecha(dt_datos.Rows(i).Item(nom_col_fec))
                If (fec_dtg = fec_buscar And dt_datos.Rows(i).Item("nit") = nit) Then
                    id_turno = dt_datos.Rows(i).Item(nom_col_id_turno)
                    If id_turno = 99 Then
                        Return True
                    End If
                End If
            End If
        Next
        Return False
    End Function
    Public Function verificar_turno_dia(ByVal nit As Double, ByVal fecha As String, ByVal id_turno As Integer) As Boolean
        Dim sql As String = "SELECT id_turno FROM J_v_operario_fecha_turno WHERE nit = " & nit & " AND fecha = '" & fecha & "' AND id_turno =" & id_turno
        If objOpSimplesLn.consultValorTodo(sql, "CONTROL") <> "" Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Function verificar_turno_periodo(ByVal nit As Double, ByVal idPeriodo As Integer, ByVal id_turno As Integer, ByVal fecha As Date) As Boolean
        Dim sFec As String = objOpSimplesLn.cambiarFormatoFecha(fecha)
        Dim sql As String = "SELECT id_turno FROM J_v_operario_fecha_turno WHERE nit = " & nit & " AND periodo = " & idPeriodo & " AND id_turno =" & id_turno & " AND fecha <= '" & sFec & "'"
        If objOpSimplesLn.consultValorTodo(sql, "CONTROL") <> "" Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Function verificar_dia_incapacidad(ByVal nit As Double, ByVal fecha As String) As Boolean
        Dim sql As String = "SELECT nit FROM y_incapacidad " & _
                                "WHERE nit = " & nit & "  AND '" & objOpSimplesLn.cambiarFormatoFecha(fecha) & "' Between fecha_ini_liq AND fecha_fin_liq "
        If objOpSimplesLn.consultValorTodo(sql, "CORSAN") <> "" Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Function verificar_dia_vacaciones(ByVal nit As Double, ByVal fecha As String) As Boolean
        Dim sql As String = "SELECT nit FROM y_vacaciones " & _
                                    "WHERE nit = " & nit & "  AND '" & objOpSimplesLn.cambiarFormatoFecha(fecha) & "' Between fecha_inicial  AND fecha_final  "
        If objOpSimplesLn.consultValorTodo(sql, "CORSAN") <> "" Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Function verificar_dom_sansion(ByVal nit As Double, ByVal fecha As String) As Boolean
        Dim sql As String = "SELECT nit FROM y_suspensiones " & _
                                    "WHERE concepto = 511 AND nit = " & nit & "  AND '" & objOpSimplesLn.cambiarFormatoFecha(fecha) & "' = fecha_inicial"
        If objOpSimplesLn.consultValorTodo(sql, "CORSAN") <> "" Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Function get_salario_prom_incap(ByVal nit As Double, ByVal fecha_ini As Date, ByVal fecha_fin As Date) As Double
        Dim sql As String = "SELECT salario_base " & _
                                      "FROM y_incapacidad " & _
                                           "WHERE (fecha_ini_liq >= '" & objOpSimplesLn.cambiarFormatoFecha(fecha_ini) & "' OR fecha_fin_liq >= '" & objOpSimplesLn.cambiarFormatoFecha(fecha_ini) & "' ) AND  nit = " & nit & " "
        Dim resp As String = objOpSimplesLn.consultarVal(sql)
        If resp = "" Then
            resp = 0
        End If
        Return resp
    End Function
    Public Function calcular_valor_horas_encapacidad(ByVal nit As Double, ByVal periodo As Integer, ByVal salario_hora_promedio As Double, ByVal porcentaje As Decimal) As Double
        Dim valor As Double = 0
        Dim dt_incapacidad As DataTable = concepto_horas_incapacidad(nit, periodo)
        Dim horas As Double = 0
        For i = 0 To dt_incapacidad.Rows.Count - 1
            horas = dt_incapacidad.Rows(i).Item("horas")
            For k = 8 To horas Step 8
                If k <= 16 Then
                    valor += (8 * salario_hora_promedio)
                Else
                    valor += (8 * salario_hora_promedio) * (porcentaje)
                End If
            Next
        Next
        Return valor
    End Function
    Public Function get_valor_vacaciones(ByVal nit As Double, ByVal fecha_ini As Date, ByVal fecha_fin As Date) As Double
        Dim sql As String = "SELECT (CASE WHEN (valor) is null THEN 0 else valor END) + " & _
                                    "(CASE WHEN (valor_festivo) is null THEN 0 else valor_festivo END) + " & _
                                    "(CASE WHEN (valor_dinero) is null THEN 0 else valor_dinero END) As valor   " & _
                            "FROM y_vacaciones " & _
                            "WHERE  dias >0 AND fecha_inicial >='" & objOpSimplesLn.cambiarFormatoFecha(fecha_ini) & "' AND '" & objOpSimplesLn.cambiarFormatoFecha(fecha_ini) & "' <= '" & objOpSimplesLn.cambiarFormatoFecha(fecha_fin) & "' AND  nit = " & nit & " "
        Dim resp As String = objOpSimplesLn.consultarVal(sql)
        If resp = "" Then
            resp = 0
        End If
        Return resp
    End Function

    Public Function detalle_marcaciones(ByVal nit As Double, ByVal fec_ini As Date, ByVal fec_fin As Date) As DataTable
        Dim sql As String = "SELECT  CAST(r.Consecutivo As varchar)As Consecutivo,CAST(r.nit As varchar) As nit,t.nombres,DATENAME ( WEEKDAY , r.FechaEntrada  ) As dia,r.FechaEntrada,r.FechaSalida,c.sabado,c.domingo,c.festivo " & _
                           "FROM r_personal_registros r , CORSAN.dbo.y_calendario c , CORSAN.dbo.terceros t  " & _
                       "WHERE  t.nit = r.nit AND CAST (r.FechaEntrada AS date ) = c.fecha AND FechaSalida is not null AND CAST(r.FechaEntrada AS date )  Between '" & objOpSimplesLn.cambiarFormatoFecha(fec_ini) & "' AND '" & objOpSimplesLn.cambiarFormatoFecha(fec_fin) & "  23:59:59' AND r.nit =" & nit
        Dim dt As DataTable = objOpSimplesLn.listar_datatable(sql, "CONTROL")
        For i = 0 To dt.Rows.Count - 1
            If IsDate(dt.Rows(i).Item("FechaEntrada")) Then
                dt.Rows(i).Item("dia") = WeekdayName(Weekday(dt.Rows(i).Item("FechaEntrada")), True, 1)
            End If
        Next
        Return dt
    End Function
    Public Function get_sub_trasporte() As Double
        Dim sql As String = "SELECT subsidio_tte  FROM y_nominas "
        Dim resp As String = objOpSimplesLn.consultarVal(sql)
        If resp = "" Then
            resp = 0
        End If
        Return resp
    End Function
    Public Function get_max_sub_trasporte() As Double
        Dim sql As String = "SELECT maximo_tte  FROM y_nominas "
        Dim resp As String = objOpSimplesLn.consultarVal(sql)
        If resp = "" Then
            resp = 0
        End If
        Return resp
    End Function
    Public Function consultar_dia_compensatorio(ByVal nit As Double, ByVal fecha As Date) As Boolean
        Dim sfec As String = objOpSimplesLn.cambiarFormatoFecha(fecha)
        Dim sql As String = "SELECT nit " & _
                                "FROM J_prog_turno_enc e , J_prog_turno_det d  " & _
                                    "WHERE e.id = d.id_enc and turno = 99 and fecha = '" & sfec & "' and nit = " & nit & " "
        If objOpSimplesLn.consultValorTodo(sql, "CONTROL") = "" Then
            Return False
        Else
            Return True
        End If
    End Function
    Public Function anularCompromiso(ByVal id As Double) As Boolean
        Dim sql, nit, val_horas, concepto As String
        Dim calc, calc_n As Integer
        sql = "select nit_trabajador from R_compromiso_horas_a_pagar where id = " & id & " AND concepto_90 is not null"
        concepto = objOpSimplesLn.consultValorTodo(sql, "CONTROL")
        sql = "select nit_trabajador from R_compromiso_horas_a_pagar WHERE id = " & id
        nit = objOpSimplesLn.consultValorTodo(sql, "CONTROL")
        sql = "select horas_restante from R_compromiso_horas_concepto_90 WHERE nit_trabajador=" & nit & " AND año=" & Year(Now) & ""
        calc = objOpSimplesLn.consultValorTodo(sql, "CONTROL")
        sql = "SELECT horas FROM R_compromiso_horas_a_pagar  WHERE id = " & id
        val_horas = objOpSimplesLn.consultValorTodo(sql, "CONTROL")
        sql = "UPDATE R_compromiso_horas_a_pagar SET Activo = 0 WHERE id = " & id
        If objOpSimplesLn.ejecutar(sql, "CONTROL") > 0 Then
            If concepto <> "" Then
                If CInt(calc) < 12 Then
                    calc_n = calc + CInt(val_horas)
                    sql = "UPDATE R_compromiso_horas_concepto_90 SET horas_restante=" & calc_n & " WHERE nit_trabajador=" & nit & " AND año=" & Year(Now) & ""
                    objOpSimplesLn.ejecutar(sql, "CONTROL")
                End If
            End If
            Return True
        Else
            Return False
        End If
    End Function
    Public Function return_dt_fechas_festivas(ByVal fec_ini As String, ByVal fec_fin As String) As DataTable
        Dim sql As String = "SELECT fecha FROM y_calendario WHERE (domingo = 'True' or festivo = 'True') AND fecha>= '" & fec_ini & "' AND fecha<= '" & fec_fin & "'"
        Dim dt As DataTable = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        Return dt
    End Function
    Public Function verificar_max__horas_domnicales_trab_mes(ByVal nit As Double, ByVal mes As Integer, ByVal ano As Integer) As Boolean
        Dim horas_mes As String = ""
        Dim sql As String = "SELECT SUM(y.horas)As horas " & _
                                "FROM y_liquidacion y , y_conceptos_nom c , terceros t " & _
                                     "WHERE (mes) = " & mes & " And (ano)  = " & ano & "  AND t.nit = y.nit AND y.concepto = c.concepto AND y.concepto IN ('15', '16') AND y.nit = " & nit & " "

        horas_mes = objOpSimplesLn.consultarVal(sql)
        If horas_mes = "" Then
            horas_mes = 0
        End If
        If horas_mes <= 12 Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Function validar_permiso_sin_ced(ByVal nit As Double) As Boolean
        Dim resp As Boolean = False
        Dim fec As String = objOpSimplesLn.cambiarFormatoFecha(Now.AddMonths(-6))
        Dim sql As String = "SELECT nit FROM R_Personal_Registros WHERE  FechaSalida is not null AND nit = " & nit & " AND permiso = 'Z' AND FechaEntrada>='" & fec & "'"
        If objOpSimplesLn.consultValorTodo(sql, "CONTROL") = "" Then
            resp = True
        End If
        Return resp
    End Function
    Public Function validar_personal_maquila(ByVal codigo_ced As String) As Boolean
        Dim resp As Boolean = False
        Dim sql As String = "SELECT nit FROM J_personal_maquila WHERE cod_barras = '" & codigo_ced & "' and desactivar is null and estado='A'"
        If objOpSimplesLn.consultValorTodo(sql, "CONTROL") <> "" Then
            resp = True
        End If
        Return resp
    End Function
    Public Function obtener_centro(ByVal nit As String)
        Dim sql, centro As String
        Dim sw As Boolean = False
        sql = "select centro from y_personal_contratos where nit=" & nit & ""
        centro = objOpSimplesLn.consultValorTodo(sql, "CORSAN")
        If centro <> "" Then
            sw = True
        End If
        If sw = False Then
            sql = "select centro from j_personal_maquila where nit=" & nit & ""
            centro = objOpSimplesLn.consultValorTodo(sql, "CONTROL")
        End If
        If sw = False Then
            centro = "0"
        End If
        Return centro
    End Function
End Class
