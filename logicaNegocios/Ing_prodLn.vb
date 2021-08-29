Imports entidadNegocios
Imports accesoDatos
Public Class Ing_prodLn
    Private obj_Ing_prodAd As New Ing_prod_ad
    Private obj_Op_simpesLn As New Op_simpesLn

    Public Function listar_datatable(ByVal cadena As String, ByVal db As String) As DataTable
        Return obj_Ing_prodAd.listar_datatable(cadena, db)
    End Function

    Public Function listar_Estado(ByVal cadena As String, ByVal db As String) As String
        Return obj_Ing_prodAd.listar_Estado(cadena, db)
    End Function

    Public Function consultar_valor(ByVal sql As String, ByVal db As String) As String
        Return obj_Ing_prodAd.consultar_valor(sql, db)
    End Function
    Public Function ejecutar(ByVal Sql As String, ByVal db As String) As Integer
        Return obj_Ing_prodAd.ejecutar(Sql, db)
    End Function
    Public Function listar_consulta(ByVal sql As String) As DataTable
        Return obj_Ing_prodAd.listar_consulta(sql)
    End Function
    Public Function vec_paros(ByVal sql As String, ByVal tamano As Integer) As Object()
        Return obj_Ing_prodAd.vec_paros(sql, tamano)
    End Function
    Public Function mat_paros(ByVal sql As String, ByVal tamano As Integer) As Object(,)
        Return obj_Ing_prodAd.mat_paros(sql, tamano)
    End Function
    Public Function vec_dias_kilos(ByVal sql As String, ByVal dias As Integer) As Object(,)
        Return obj_Ing_prodAd.vec_dias_kilos(sql, dias)
    End Function
    Public Function vec_datos(ByVal sql As String, ByVal cant As Integer) As Object()
        Return obj_Ing_prodAd.vec_datos(sql, cant)
    End Function
    Public Function vec_dias_mes_kilos(ByVal sql As String, ByVal dias As Integer) As Object(,)
        Return obj_Ing_prodAd.vec_dias_mes_kilos(sql, dias)
    End Function
    Public Function modif_prod(ByVal id_prod As Integer, ByVal h_trab As Double, ByVal fecha As Date, ByVal tabla As String) As Integer
        Dim sql As String = "UPDATE " & tabla & " SET horas_trab= " & h_trab & ",fecha = " & fecha & " WHERE id =" & id_prod
        Return obj_Ing_prodAd.ejecutar(sql, "PRODUCCION")
    End Function
    Public Function efic_trfilacion(ByVal fec_ini As String, ByVal fec_fin As String) As DataView
        Return obj_Ing_prodAd.efic_trfilacion(fec_ini, fec_fin)
    End Function
    Public Function efic_puas(ByVal fec_ini As String, ByVal fec_fin As String) As DataTable
        Return obj_Ing_prodAd.efic_puas(fec_ini, fec_fin)
    End Function
    Public Function efic_puntilleria(ByVal fec_ini As String, ByVal fec_fin As String) As DataTable
        Return obj_Ing_prodAd.efic_puntilleria(fec_ini, fec_fin)
    End Function
    Public Function ExecuteSqlTransaction(ByVal listSql As List(Of Object), ByVal db As String) As Boolean
        Return obj_Ing_prodAd.ExecuteSqlTransaction(listSql, db)
    End Function
    Public Function listaForm(ByVal consecutivoPpal As String, ByVal tam As Integer, ByVal sql As String) As List(Of Object)
        Return obj_Ing_prodAd.listaForm(consecutivoPpal, tam, sql)
    End Function
    Public Function listaRegistro(ByVal sql As String, ByVal db As String, ByVal numCol As Integer) As List(Of Object)
        Return obj_Ing_prodAd.listaRegistro(sql, db, numCol)
    End Function
    Public Function listarOperarios(ByVal centro As String) As DataTable
        Dim sql As String
        If (centro = "todos") Then
            sql = "Select nit,nombres   from V_nom_personal_Activo_con_maquila WHERE centro not in (4200) ORDER BY nombres "
        Else
            sql = "Select nit,nombres  from V_nom_personal_Activo_con_maquila WHERE centro = " & centro & " ORDER BY nombres "
        End If
        Return obj_Ing_prodAd.listar_datatable(sql, "CORSAN")
    End Function
    Public Function listarTurnos() As DataTable
        Dim sql As String = "SELECT Codigo,Descripcion FROM J_turnos ORDER BY Descripcion "
        Return obj_Ing_prodAd.listar_datatable(sql, "PRODUCCION")
    End Function
    Public Function listarMaquinas(ByVal tipo As String) As DataTable
        Dim sql As String = "SELECT  codigoM,nombre   FROM j_Maquinas WHERE TipoMaquina in (" & tipo & ") AND activa = 1"
        Return obj_Ing_prodAd.listar_datatable(sql, "PRODUCCION")
    End Function
    Public Function listarReferencias(ByVal tipo As String) As DataTable
        Dim sql As String = "SELECT  id_ref,descripcion   FROM J_referencias WHERE tipo in (" & tipo & ") "
        Return obj_Ing_prodAd.listar_datatable(sql, "PRODUCCION")
    End Function
    Public Function listarContenedores() As DataTable
        Dim sql As String = "SELECT  codigo,descripcion   FROM J_contenedores "
        Return obj_Ing_prodAd.listar_datatable(sql, "PRODUCCION")
    End Function
    Public Function Operarios(ByVal centro As String) As DataTable
        Dim sql As String = ""
        If (centro = "todos") Then
            sql = "SELECT nit,nombres FROM V_nom_personal_Activo_con_maquila order by nombres "
        Else
            sql = "SELECT nit,nombres FROM V_nom_personal_Activo_con_maquila WHERE centro = " & centro & " order by nombres "
        End If
        Return obj_Ing_prodAd.listar_datatable(sql, "CORSAN")
    End Function
    Public Function espRoyosBerg(ByVal ref As String) As Double
        Dim cant As Double
        Select Case ref
            Case "153"
                cant = 32
            Case "154"
                cant = 30
            Case "155"
                cant = 50
            Case "151"
                cant = 45
            Case "150"
                cant = 26
            Case "148"
                cant = 32
            Case "147"
                cant = 50
            Case "146"
                cant = 55
            Case "149"
                cant = 30
        End Select
        Return cant
    End Function
    Public Function cargarObjCertCalidad(ByVal numero As Double) As FichaAlambEn
        Return obj_Ing_prodAd.cargarObjCertCalidad(numero)
    End Function
    Public Function cargarObjRolloCalidad(ByVal numero As Double) As List(Of List(Of DetalleRollosEn))
        Return obj_Ing_prodAd.cargarObjRolloCalidad(numero)
    End Function
    Public Function existeFichaTecnica(ByVal codigo As String) As Boolean
        Dim sql As String = "SELECT * FROM J_referencia_ficha_tec WHERE codigo = '" & codigo & "'"
        If (obj_Ing_prodAd.consultar_valor(sql, "PRODUCCION") <> "0") Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Function existeFichaTecnica_nit(ByVal codigo As String, ByVal nit As String) As Boolean
        Dim sql As String = "SELECT * FROM J_referencia_ficha_tec WHERE codigo = '" & codigo & "' and nit=" & nit & ""
        If (obj_Ing_prodAd.consultar_valor(sql, "PRODUCCION") <> "0") Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Function existeCiclo(ByVal codigo As String) As Boolean
        Dim sql As String = "SELECT * FROM J_rec_ciclos WHERE id = '" & codigo & "'"
        If (obj_Ing_prodAd.consultar_valor(sql, "PRODUCCION") <> "0") Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Function existeCodigo(ByVal codigo As String) As Boolean
        Dim sql As String = "SELECT codigo FROM referencias WHERE codigo = '" & codigo & "'"
        If (obj_Ing_prodAd.consultar_valor(sql, "CORSAN") = "0") Then
            Return False
        Else
            Return True
        End If
    End Function
    Public Function descCodigo(ByVal codigo As String) As String
        Dim sql As String = "SELECT descripcion FROM referencias WHERE codigo = '" & codigo & "'"
        Dim resp As String = ""
        resp = obj_Ing_prodAd.consultar_valor(sql, "CORSAN")
        Return resp
    End Function
    Public Function existeTipoTransaccion(ByVal tipo As String) As Boolean
        Dim sql As String = "SELECT tipo FROM tipo_transacciones WHERE tipo = '" & tipo & "'"
        If (obj_Ing_prodAd.consultar_valor(sql, "CORSAN") = "0") Then
            Return False
        Else
            Return True
        End If
    End Function
    Public Function listaValores(ByVal sql As String, ByVal db As String, ByVal numCol As Integer) As List(Of Object)
        Return obj_Ing_prodAd.listaValores(sql, db, numCol)
    End Function
    Public Function consultValor(ByVal sql As String, ByVal db As String) As String
        Return obj_Ing_prodAd.consultValor(sql, db)
    End Function
    Public Function calcularHorometro(ByVal inicial As String, ByVal final As String) As Integer
        Dim swMinutos As Boolean = False
        Dim minutos As Integer = 0
        Dim horasIni As String = 0
        Dim horasFin As String = 0
        Dim minIni As String = 0
        Dim minFin As String = 0
        For i = 0 To inicial.Length - 1
            If (inicial(i) <> ".") Then
                If (swMinutos = False) Then
                    If (inicial(i) <> ".") Then
                        horasIni &= inicial(i)
                    End If
                Else
                    If (inicial(i) <> ".") Then
                        minIni &= inicial(i)
                    End If
                End If
            Else
                swMinutos = True
            End If
        Next
        swMinutos = False
        For i = 0 To final.Length - 1
            If (final(i) <> ".") Then
                If (swMinutos = False) Then
                    If (final(i) <> ".") Then
                        horasFin &= final(i)
                    End If
                Else
                    If (final(i) <> ".") Then
                        minFin &= final(i)
                    End If
                End If
            Else
                swMinutos = True
            End If
        Next
        horasIni = horasIni * 60
        horasFin = horasFin * 60
        minutos = (Convert.ToDouble(horasFin) + Convert.ToDouble(minFin)) - (Convert.ToDouble(horasIni) + Convert.ToDouble(minIni))
        Return minutos
    End Function
    Public Function guardar_desperdicio(ByVal fecha As String, ByVal nit As Double, ByVal centro As String, ByVal kilos As Double, ByVal tipo As Integer, ByVal causal As Integer, ByVal defecto As Integer,
                        ByVal observaciones As String, ByVal id_exixtente As Double, ByVal destino As Integer, ByVal cod_maq As String) As List(Of Object)
        Dim listSql As New List(Of Object)
        Dim id As Double = 0
        Dim sql As String
        If (id_exixtente <> 0) Then
            listSql.Add("DELETE FROM J_desperdicios WHERE id = " & id_exixtente & " ")
            id = id_exixtente
        Else
            id = obj_Op_simpesLn.consultValorTodo("SELECT  (SELECT CASE WHEN MAX(id) IS NULL THEN (1) ELSE MAX(id)+1 END) as id FROM J_desperdicios", "PRODUCCION")
        End If
        sql = "INSERT INTO J_desperdicios (id,fecha,nit,centro,kilos,tipo,observaciones,id_causal,id_defecto,fecha_ingreso,destino,cod_maq) VALUES (" & id & ",'" & fecha & "'," & nit & "," & centro & "," & kilos & "," & tipo & ",'" & observaciones & "'," & causal & "," & defecto & ",GETDATE()," & destino & ",'" & cod_maq & "')"
        listSql.Add(sql)
        Return listSql
    End Function
    'Este metodo fue creado para el area de puntilleria se agrego los campos de cod_maquina,cod_refer y turno para los desperdicios
    Public Function guardar_desperdicio_nuevo(ByVal fecha As String, ByVal nit As Double, ByVal centro As String, ByVal kilos As Double, ByVal tipo As Integer, ByVal causal As Integer, ByVal defecto As Integer,
                    ByVal observaciones As String, ByVal id_exixtente As Double, ByVal destino As Integer, ByVal turno As String, ByVal cod_refer As String, ByVal cod_maq As String) As List(Of Object)
        Dim listSql As New List(Of Object)
        Dim id As Double = 0
        Dim sql As String
        If (id_exixtente <> 0) Then
            listSql.Add("DELETE FROM J_desperdicios WHERE id = " & id_exixtente & " ")
            id = id_exixtente
        Else
            id = obj_Op_simpesLn.consultValorTodo("SELECT  (SELECT CASE WHEN MAX(id) IS NULL THEN (1) ELSE MAX(id)+1 END) as id FROM J_desperdicios", "PRODUCCION")
        End If
        sql = "INSERT INTO J_desperdicios (id,fecha,nit,centro,kilos,tipo,observaciones,id_causal,id_defecto,fecha_ingreso,destino,codigo_ref,cod_maq,turno) VALUES (" & id & ",'" & fecha & "'," & nit & "," & centro & "," & kilos & "," & tipo & ",'" & observaciones & "'," & causal & "," & defecto & ",GETDATE()," & destino & ",'" & cod_refer & "'," & cod_maq & "," & turno & ")"
        listSql.Add(sql)
        Return listSql
    End Function
End Class
