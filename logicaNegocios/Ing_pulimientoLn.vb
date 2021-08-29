Imports accesoDatos
Public Class Ing_pulimientoLn
    Private objOpDb As New OperacionesDb
    Private obj_op_simplesAd As New Op_simplesAd
    Public Function sqlInsertPpal(ByVal idPulimiento As Int64, ByVal operario As String, ByVal turno As String, ByVal fec As String) As String
        Return "INSERT INTO J_prod_pulimiento (consecutivo,fecha, turno, operario) VALUES (" & idPulimiento & ",'" & fec & "'," & turno & "," & operario & ")"
    End Function
    Public Function genIdPulimiento() As Int64
        Dim id As String = objOpDb.consultValor("SELECT MAX(consecutivo) FROM J_prod_pulimiento", "PRODUCCION")
        If (id = "") Then
            Return 1
        Else
            Return (Convert.ToInt64(id) + 1)
        End If
    End Function
    Public Function guardarTodo(ByVal listSql As List(Of Object)) As Boolean
        Return objOpDb.ExecuteSqlTransactionProduccion(listSql)
    End Function
    Public Function validarNumero(ByVal numero As String) As Boolean
        If (numero <> "") Then
            If (Not IsNumeric(numero)) Then
                Return False
            End If
        End If
        Return True
    End Function
    Public Function consultarInforme(ByVal operario As String, ByVal maquina As String, ByVal fecIni As String, ByVal fecFin As String) As DataTable
        Dim sqlPpal As String = "SELECT Id,fecha,nombres,codTurno,kilos,tambor,maquina,contenedor,ref,turno " & _
                        "FROM J_v_prod_pulimiento "

        Dim whereSql As String = " WHERE fecha >='" & fecIni & "' AND fecha<='" & fecFin & "' "
        If (operario <> "0") Then
            whereSql += " AND nit =" & operario
        End If
        If (maquina <> "0") Then
            whereSql += " AND codMaq=" & maquina
        End If
        sqlPpal += whereSql
        Return obj_op_simplesAd.listar_datatable(sqlPpal, "PRODUCCION")
    End Function
    Public Function consolidarConsulta(ByVal listTipo As List(Of Object), ByVal operario As String, ByVal maquina As String, ByVal fecIni As String, ByVal fecFin As String) As DataTable
        Dim selectSql As String = "SELECT"
        Dim fromSql As String = "FROM J_v_prod_pulimiento "
        Dim groupSql As String = "GROUP BY "
        Dim whereSql As String = " WHERE fecha >='" & fecIni & "' AND fecha<='" & fecFin & "' "
        Dim coma As String = ","
        If (operario <> "0") Then
            whereSql += " AND nit =" & operario
        End If
        If (maquina <> "0") Then
            whereSql += " AND codMaq=" & maquina
        End If
        For i = 0 To listTipo.Count - 1
            If (i = listTipo.Count - 1) Then
                coma = ""
            End If
            If (listTipo(i) = "operario") Then
                selectSql += " nombres, "
                groupSql += "nombres " & coma
            ElseIf (listTipo(i) = "turno") Then
                selectSql += " turno, "
                groupSql += "turno " & coma
            ElseIf (listTipo(i) = "maquina") Then
                selectSql += " maquina, "
                groupSql += "maquina " & coma
            ElseIf (listTipo(i) = "referencia") Then
                selectSql += " ref, "
                groupSql += "ref " & coma
            End If
        Next
        selectSql += "SUM(kilos)As kilos "
        Return obj_op_simplesAd.listar_datatable(selectSql & fromSql & whereSql & groupSql, "PRODUCCION")
    End Function
    Public Function kilEsperados(ByVal turno As Integer) As Double
        Dim sql As String = "SELECT esperada FROM J_esp_pulimiento WHERE turno = " & turno
        Dim valor As String = objOpDb.consultValor(sql, "PRODUCCION")
        Dim kilosEsp As Double = 0
        If (valor <> "") Then
            kilosEsp = Convert.ToDouble(valor)
        End If
        Return kilosEsp
    End Function
    Public Function calcEficiencia(ByVal kilProd, ByVal kilEsp) As Double
        Dim esperada As Double = (kilProd / kilEsp) * 100
        Return esperada
    End Function
    Public Function getTurnoPlanilla(ByVal idPlanilla As String) As Integer
        Dim turno As String = obj_op_simplesAd.consultValor("SELECT turno FROM J_prod_pulimiento WHERE id=" & idPlanilla)
        If (turno <> "") Then
            Return Convert.ToInt16(turno)
        Else
            Return 0
        End If
    End Function

End Class
