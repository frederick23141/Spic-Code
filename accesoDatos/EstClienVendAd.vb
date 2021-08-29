Imports System.Data.SqlClient
Imports System.Data
Imports entidadNegocios
Public Class EstClienVendAd
    Private conn As New SqlConnection
    Private conn2 As New SqlConnection
    Private comando As New SqlCommand
    Dim objConexion As New Conexion
    Dim objEstClienVendEn As New EstClienVendEn
    Dim objEstClienDatosEn As New EstClienDatosEn
    Public Function vendedores(ByVal sVendedores As String) As Integer()
        Dim reader As SqlDataReader
        Dim vecVend(99) As Integer
        Dim k As Double = 0
        Dim criterioVendedor As String = ""
        If (sVendedores <> "") Then
            criterioVendedor = " vendedor in (" & sVendedores & ")"
        Else
            criterioVendedor = " vendedor>=1001 and vendedor<=1099 "
        End If
        comando.CommandType = CommandType.Text
        conn = objConexion.abrirConexion
        comando.Connection = conn
        comando.CommandText = ("select vendedor FROM v_vendedores WHERE " & criterioVendedor & " AND bloqueo = 0 ORDER BY vendedor")
        reader = comando.ExecuteReader
        While (reader.Read)
            If IsDBNull(reader(0)) Then
            Else
                vecVend(k) = reader(0)
                k = k + 1
            End If
        End While
        conn.Close()
        Return vecVend
    End Function
    Public Function NombVend(ByVal vendedor As Integer) As String
        Dim reader As SqlDataReader
        Dim nombre As String = ""
        comando.CommandType = CommandType.Text
        conn = objConexion.abrirConexion
        comando.Connection = conn
        comando.CommandText = ("select nombre_vendedor FROM v_vendedores WHERE     vendedor= " & vendedor & " ")
        reader = comando.ExecuteReader
        While (reader.Read)
            If IsDBNull(reader(0)) Then
            Else
                nombre = reader(0)

            End If
        End While
        conn.Close()
        Return nombre
    End Function
    Public Function totClient(ByVal vendedor As Integer) As Integer
        Dim reader As SqlDataReader
        Dim tot As Double
        comando.CommandType = CommandType.Text
        conn = objConexion.abrirConexion
        comando.Connection = conn
        comando.CommandText = ("select COUNT (nit)  from terceros where vendedor=" & vendedor & "")
        reader = comando.ExecuteReader
        While (reader.Read)
            If IsDBNull(reader(0)) Then
            Else
                tot = reader(0)
            End If
        End While
        conn.Close()
        Return tot
    End Function
    Public Function totActivos(ByVal vendedor As Integer) As Integer
        Dim reader As SqlDataReader
        Dim tot As Double
        comando.CommandType = CommandType.Text
        conn = objConexion.abrirConexion
        comando.Connection = conn
        comando.CommandText = ("select COUNT (nit) from terceros where  vendedor=" & vendedor & " and bloqueo=0")
        reader = comando.ExecuteReader
        While (reader.Read)
            If IsDBNull(reader(0)) Then
            Else
                tot = reader(0)
            End If
        End While
        conn.Close()
        Return tot
    End Function
    Public Function totInac(ByVal vendedor As Integer) As Integer
        Dim reader As SqlDataReader
        Dim tot As Double
        comando.CommandType = CommandType.Text
        conn = objConexion.abrirConexion
        comando.Connection = conn
        comando.CommandText = ("select COUNT (nit) from terceros where  vendedor=" & vendedor & " and bloqueo=1")
        reader = comando.ExecuteReader
        While (reader.Read)
            If IsDBNull(reader(0)) Then
            Else
                tot = reader(0)
            End If
        End While
        conn.Close()
        Return tot
    End Function
    Public Function totBloq(ByVal vendedor As Integer) As Integer
        Dim reader As SqlDataReader
        Dim tot As Double
        comando.CommandType = CommandType.Text
        conn = objConexion.abrirConexion
        comando.Connection = conn
        comando.CommandText = ("select COUNT (nit) from terceros where  vendedor=" & vendedor & " and bloqueo=2")
        reader = comando.ExecuteReader
        While (reader.Read)
            If IsDBNull(reader(0)) Then
            Else
                tot = reader(0)
            End If
        End While
        conn.Close()
        Return tot
    End Function
    Public Function totNoUsar(ByVal vendedor As Integer) As Integer
        Dim reader As SqlDataReader
        Dim tot As Double
        comando.CommandType = CommandType.Text
        conn = objConexion.abrirConexion
        comando.Connection = conn
        comando.CommandText = ("select COUNT (nit) from terceros where  vendedor=" & vendedor & " and bloqueo=3")
        reader = comando.ExecuteReader
        While (reader.Read)
            If IsDBNull(reader(0)) Then
            Else
                tot = reader(0)
            End If
        End While
        conn.Close()
        Return tot
    End Function
    Public Function movTotclient(ByVal vendedor As Integer) As Integer
        Dim diaFin As Integer
        Dim sFecini As String = ""
        Dim mesFin As Integer = Now.Month - 1
        Dim añoFin As Integer = Now.Year
        Dim fecini As Date
        Dim sFecFin As String
        fecini = DateAdd("m", -12, Now.Year & "-" & Now.Month & "-01")
        If (Now.Month - 1 = 4 Or Now.Month - 1 = 6 Or Now.Month - 1 = 9 Or Now.Month - 1 = 11) Then
            diaFin = 30
        Else
            diaFin = 31
        End If
        If (Now.Month - 1 = 2) Then
            diaFin = 28
        End If
        If (Now.Month = 1) Then
            añoFin = Now.Year - 1
            mesFin = 12
        End If

        sFecini = fecini.Year & "-" & fecini.Month & "-01 "
        sFecFin = añoFin & "-" & mesFin & "-" & diaFin

        Dim reader As SqlDataReader
        Dim tot As Double
        comando.CommandType = CommandType.Text
        conn = objConexion.abrirConexion
        comando.Connection = conn
        ' MsgBox("select  count  (nit) from documentos  where  vendedor=" & vendedor & " and sw =1 and fecha >='" & sFecini & "' and fecha <='" & sFecFin & "' group by nit ")
        comando.CommandText = ("select COUNT (DISTINCT nit) from Jjv_V_vtas_vend_cliente_ref where  vendedor=" & vendedor & "   and fec >='" & sFecini & "' and fec <='" & sFecFin & "' ")
        reader = comando.ExecuteReader
        While (reader.Read)
            If IsDBNull(reader(0)) Then
            Else
                tot = reader(0)
            End If
        End While
        conn.Close()
        Return tot
    End Function

    Public Function totMovAct(ByVal vendedor As Integer) As Integer
        Dim sql As String = ""
        Dim diaFin As Integer
        Dim sFecini As String = ""
        Dim mesFin As Integer = Now.Month - 1
        Dim añoFin As Integer = Now.Year
        Dim fecini As Date
        Dim sFecFin As String
        fecini = DateAdd("m", -12, Now.Year & "-" & Now.Month & "-01")
        If (Now.Month - 1 = 4 Or Now.Month - 1 = 6 Or Now.Month - 1 = 9 Or Now.Month - 1 = 11) Then
            diaFin = 30
        Else
            diaFin = 31
        End If
        If (Now.Month - 1 = 2) Then
            diaFin = 28
        End If
        If (Now.Month = 1) Then
            añoFin = Now.Year - 1
            mesFin = 12
        End If

        sFecini = fecini.Year & "-" & fecini.Month & "-01 "
        sFecFin = añoFin & "-" & mesFin & "-" & diaFin
        Dim reader As SqlDataReader
        Dim tot As Double
        comando.CommandType = CommandType.Text
        conn = objConexion.abrirConexion
        comando.Connection = conn
        sql = "SELECT COUNT (DISTINCT nit) FROM Jjv_V_vtas_vend_cliente_ref 	WHERE bloqueo=0 AND fec >='" & sFecini & "' AND fec <'" & sFecFin & "' AND vendedor = " & vendedor & ""
        comando.CommandText = (sql)
        reader = comando.ExecuteReader
        While (reader.Read)
            If IsDBNull(reader(0)) Then
            Else
                tot = reader(0)
            End If
        End While
        conn.Close()
        Return tot
    End Function
    Public Function totMovInac(ByVal vendedor As Integer) As Double

        Dim diaFin As Integer
        Dim sFecini As String = ""
        Dim mesFin As Integer = Now.Month - 1
        Dim añoFin As Integer = Now.Year
        Dim fecini As Date
        Dim sFecFin As String
        fecini = DateAdd("m", -12, Now.Year & "-" & Now.Month & "-01")
        If (Now.Month - 1 = 4 Or Now.Month - 1 = 6 Or Now.Month - 1 = 9 Or Now.Month - 1 = 11) Then
            diaFin = 30
        Else
            diaFin = 31
        End If
        If (Now.Month - 1 = 2) Then
            diaFin = 28
        End If
        If (Now.Month = 1) Then
            añoFin = Now.Year - 1
            mesFin = 12
        End If

        sFecini = fecini.Year & "-" & fecini.Month & "-01 "
        sFecFin = añoFin & "-" & mesFin & "-" & diaFin
        
        Dim reader As SqlDataReader
        Dim tot As Double
        Dim sql As String = "SELECT COUNT (DISTINCT nit) FROM Jjv_V_vtas_vend_cliente_ref 	WHERE bloqueo=1 AND fec >='" & sFecini & "' AND fec <'" & sFecFin & "' AND vendedor = " & vendedor & ""
        comando.CommandType = CommandType.Text
        conn = objConexion.abrirConexion
        comando.Connection = conn
        comando.CommandText = (sql)
        reader = comando.ExecuteReader
        While (reader.Read)
            If IsDBNull(reader(0)) Then
            Else
                tot = reader(0)
            End If
        End While
        conn.Close()
        Return tot
    End Function
    Public Function totMovBloq(ByVal vendedor As Integer) As Integer

        Dim diaFin As Integer
        Dim sFecini As String = ""
        Dim mesFin As Integer = Now.Month - 1
        Dim añoFin As Integer = Now.Year
        Dim fecini As Date
        Dim sFecFin As String
        fecini = DateAdd("m", -12, Now.Year & "-" & Now.Month & "-01")
        If (Now.Month - 1 = 4 Or Now.Month - 1 = 6 Or Now.Month - 1 = 9 Or Now.Month - 1 = 11) Then
            diaFin = 30
        Else
            diaFin = 31
        End If
        If (Now.Month - 1 = 2) Then
            diaFin = 28
        End If
        If (Now.Month = 1) Then
            añoFin = Now.Year - 1
            mesFin = 12
        End If

        sFecini = fecini.Year & "-" & fecini.Month & "-01 "
        sFecFin = añoFin & "-" & mesFin & "-" & diaFin

        Dim reader As SqlDataReader
        Dim tot As Double
        Dim sql As String = "SELECT COUNT (DISTINCT nit) FROM Jjv_V_vtas_vend_cliente_ref 	WHERE bloqueo=2 AND fec >='" & sFecini & "' AND fec <'" & sFecFin & "' AND vendedor = " & vendedor & ""
        comando.CommandType = CommandType.Text
        conn = objConexion.abrirConexion
        comando.Connection = conn
        comando.CommandText = (sql)
        reader = comando.ExecuteReader
        While (reader.Read)
            If IsDBNull(reader(0)) Then
            Else
                tot = reader(0)
            End If
        End While
        conn.Close()
        Return tot
    End Function
    Public Function totMovNoUsar(ByVal vendedor As Integer) As Integer

        Dim diaFin As Integer
        Dim sFecini As String = ""
        Dim mesFin As Integer = Now.Month - 1
        Dim añoFin As Integer = Now.Year
        Dim fecini As Date
        Dim sFecFin As String
        fecini = DateAdd("m", -12, Now.Year & "-" & Now.Month & "-01")
        If (Now.Month - 1 = 4 Or Now.Month - 1 = 6 Or Now.Month - 1 = 9 Or Now.Month - 1 = 11) Then
            diaFin = 30
        Else
            diaFin = 31
        End If
        If (Now.Month - 1 = 2) Then
            diaFin = 28
        End If
        If (Now.Month = 1) Then
            añoFin = Now.Year - 1
            mesFin = 12
        End If

        sFecini = fecini.Year & "-" & fecini.Month & "-01 "
        sFecFin = añoFin & "-" & mesFin & "-" & diaFin
        Dim reader As SqlDataReader
        Dim tot As Double
        Dim sql As String = "SELECT COUNT (DISTINCT nit) FROM Jjv_V_vtas_vend_cliente_ref 	WHERE bloqueo=3 AND fec >='" & sFecini & "' AND fec <'" & sFecFin & "' AND vendedor = " & vendedor & ""
        comando.CommandType = CommandType.Text
        conn = objConexion.abrirConexion
        comando.Connection = conn
        comando.CommandText = (sql)
        reader = comando.ExecuteReader
        While (reader.Read)
            If IsDBNull(reader(0)) Then
            Else
                tot = reader(0)
            End If
        End While
        conn.Close()
        Return tot
    End Function
    Public Function atenFecini(ByVal vendedor As Integer) As Integer
        Dim diaFin As Integer = 1
        Dim sFecini As String = ""
        Dim añoFin As Integer = Now.Year
        Dim fechaIni As Date
        Dim fechaFin As Date
        Dim sfechaIni As String
        Dim sfechaFin As String
        fechaIni = DateAdd("m", -12, Now.Year & "-" & Now.Month & "-01")
        fechaFin = DateAdd("m", -6, Now.Year & "-" & Now.Month & "-01")
        sfechaIni = fechaIni.Year & "-" & fechaIni.Month & "-" & fechaIni.Day
        sfechaFin = fechaFin.Year & "-" & fechaFin.Month & "-01"
        Dim reader As SqlDataReader
        Dim tot As Double
        Dim cont As Integer = 0
        comando.CommandType = CommandType.Text
        conn = objConexion.abrirConexion
        comando.Connection = conn
        comando.CommandText = ("select  count  (nit) from documentos  where  vendedor=" & vendedor & " and sw =1 and fecha >='" & sfechaIni & "' and fecha <'" & sfechaFin & "' group by nit ")
        reader = comando.ExecuteReader
        While (reader.Read)
            If IsDBNull(reader(0)) Then
            Else
                cont += 1
            End If
        End While
        tot = cont
        conn.Close()
        Return tot
    End Function
    Public Function atenFecFin(ByVal vendedor As Integer) As Integer
        Dim diaFin As Integer
        Dim sFecini As String = ""
        Dim mesFin As Integer = Now.Month
        Dim añoFin As Integer = Now.Year
        Dim fechaIni As Date
        Dim sFecFin As String
        fechaIni = DateAdd("m", -6, Now.Year & "-" & Now.Month & "-01")


        If (Now.Month - 1 = 4 Or Now.Month - 1 = 6 Or Now.Month - 1 = 9 Or Now.Month - 1 = 11) Then
            diaFin = 30
        Else
            diaFin = 31
        End If
        If (Now.Month - 1 = 2) Then
            diaFin = 28
        End If
        If (Now.Month = 1) Then
            añoFin = Now.Year - 1
            mesFin = 12
        End If

        sFecini = fechaIni.Year & "-" & fechaIni.Month & "-01 "
        sFecFin = añoFin & "-" & mesFin & "-01"

        Dim reader As SqlDataReader
        Dim tot As Double
        Dim cont As Integer = 0
        comando.CommandType = CommandType.Text
        conn = objConexion.abrirConexion
        comando.Connection = conn
        ' MsgBox(" fecga de fin select  count  (nit) from documentos  where  vendedor=" & vendedor & " and sw =1 and fecha >='" & sFecini & "' and fecha <='" & sFecFin & "' group by nit ")
        comando.CommandText = ("select  count  (nit) from documentos  where  vendedor=" & vendedor & " and sw =1 and fecha >='" & sFecini & "' and fecha <'" & sFecFin & "' group by nit ")
        reader = comando.ExecuteReader
        While (reader.Read)
            If IsDBNull(reader(0)) Then
            Else
                cont += 1
            End If
        End While
        tot = cont
        conn.Close()
        Return tot
    End Function

    Public Function nuevosFecini(ByVal vendedor As Integer) As Integer
        Dim diaFin As Integer = 1
        Dim sFecini As String = ""
        Dim sFecFin As String = ""
        Dim mesFin As Integer = Now.Month - 1
        Dim añoFin As Integer = Now.Year
        Dim fechaIni As Date
        Dim fechaFin As Date

        fechaIni = DateAdd("m", -12, Now.Year & "-" & Now.Month & "-01")
        fechaFin = DateAdd("m", -6, Now.Year & "-" & Now.Month & "-01")

        sFecini = fechaIni.Year & "-" & fechaIni.Month & "-01 "
        sFecFin = fechaFin.Year & "-" & fechaFin.Month & "-01 "
        Dim reader As SqlDataReader
        Dim tot As Double = 0
        comando.CommandType = CommandType.Text
        conn = objConexion.abrirConexion
        comando.Connection = conn
        comando.CommandText = ("select COUNT (nit ) from terceros where  vendedor=" & vendedor & " and bloqueo=0 and fecha_creacion >='" & sFecini & "' and fecha_creacion <'" & sFecFin & "' and nit in (select nit from documentos  where  vendedor=" & vendedor & " and sw =1)")
        reader = comando.ExecuteReader
        While (reader.Read)
            If IsDBNull(reader(0)) Then
            Else
                tot = reader(0)
            End If
        End While
        conn.Close()
        Return tot
    End Function
    Public Function nuevosFecfin(ByVal vendedor As Integer) As Integer
       Dim diaFin As Integer
        Dim sFecini As String = ""
        Dim mesFin As Integer = Now.Month - 1
        Dim añoFin As Integer = Now.Year
        Dim fechaIni As Date
        Dim sFecFin As String
        fechaIni = DateAdd("m", -6, Now.Year & "-" & Now.Month & "-01")


        If (Now.Month - 1 = 4 Or Now.Month - 1 = 6 Or Now.Month - 1 = 9 Or Now.Month - 1 = 11) Then
            diaFin = 30
        Else
            diaFin = 31
        End If
        If (Now.Month - 1 = 2) Then
            diaFin = 28
        End If
        If (Now.Month = 1) Then
            añoFin = Now.Year - 1
            mesFin = 12
        End If

        sFecini = fechaIni.Year & "-" & fechaIni.Month & "-01 "
        sFecFin = añoFin & "-" & mesFin & "-" & diaFin
        Dim reader As SqlDataReader
        Dim tot As Double = 0
        comando.CommandType = CommandType.Text
        conn = objConexion.abrirConexion
        comando.Connection = conn
        comando.CommandText = ("select COUNT (nit ) from terceros where  vendedor=" & vendedor & " and bloqueo=0 and fecha_creacion >='" & sFecini & "' and fecha_creacion <= '" & sFecFin & "' and nit in (select nit from documentos  where  vendedor=" & vendedor & " and sw =1)")
        reader = comando.ExecuteReader
        While (reader.Read)
            If IsDBNull(reader(0)) Then
            Else
                tot = reader(0)
            End If
        End While
        conn.Close()
        Return tot
    End Function
    Public Function listarEstClient(ByVal sVendedores As String) As List(Of EstClienVendEn)
        Dim listaEstClient As New List(Of EstClienVendEn)
        Dim vecVend As Integer() = vendedores(sVendedores)
        Dim vendedor As Integer = 0
        Dim totClientes As Integer = 0
        For i = 0 To 98
            vendedor = vecVend(i)
            If (vecVend(i) > 0) Then
                totClientes = totClient(vendedor)
                If (totClientes > 0) Then
                    objEstClienVendEn = New EstClienVendEn
                    objEstClienVendEn.Vendedor = vecVend(i)
                    objEstClienVendEn.Nombres = NombVend(vendedor)
                    objEstClienVendEn.Tot_cliente = totClientes
                    objEstClienVendEn.Tot_act = totActivos(vendedor)
                    objEstClienVendEn.Tot_Inactivo = totInac(vendedor)
                    objEstClienVendEn.Tot_Bloq = totBloq(vendedor)
                    objEstClienVendEn.Tot_no_usar = totNoUsar(vendedor)
                    objEstClienVendEn.Mov_totales = movTotclient(vendedor)
                    objEstClienVendEn.Mov_act = totMovAct(vendedor)
                    objEstClienVendEn.Mov_inactivo = totMovInac(vendedor)
                    objEstClienVendEn.Mov_bloq = totMovBloq(vendedor)
                    objEstClienVendEn.Mov_no_usar = totMovNoUsar(vendedor)
                    objEstClienVendEn.AtendFecIni = atenFecini(vendedor)
                    objEstClienVendEn.AtendFecFin = atenFecFin(vendedor)
                    objEstClienVendEn.NefectFecIni = nuevosFecini(vendedor)
                    objEstClienVendEn.NefectFecFin = nuevosFecfin(vendedor)

                    listaEstClient.Add(objEstClienVendEn)
                End If
            End If
        Next
        objEstClienVendEn = New EstClienVendEn
        objEstClienVendEn.Nombres = "TOTALES GENERALES"
        listaEstClient.Add(objEstClienVendEn)
        Return listaEstClient
    End Function

    Public Function listarClientesCategoria(ByVal cadena As String) As DataTable
        conn = objConexion.abrirConexion
        Dim dt As New DataTable
        Dim DA As New SqlDataAdapter(cadena, conn)
        DA.Fill(dt)
        conn.Close()
        Return dt
    End Function
    Public Function listarMovTotales(ByVal cadena As String) As DataTable
        Dim diaFin As Integer
        Dim sFecini As String = ""
        Dim mesFin As Integer = Now.Month - 1
        Dim añoFin As Integer = Now.Year
        Dim fecini As Date
        Dim sFecFin As String
        fecini = DateAdd("m", -12, Now.Year & "-" & Now.Month & "-01")
        If (Now.Month - 1 = 4 Or Now.Month - 1 = 6 Or Now.Month - 1 = 9 Or Now.Month - 1 = 11) Then
            diaFin = 30
        Else
            diaFin = 31
        End If
        If (Now.Month - 1 = 2) Then
            diaFin = 28
        End If
        If (Now.Month = 1) Then
            añoFin = Now.Year - 1
            mesFin = 12
        End If
        sFecini = fecini.Year & "-" & fecini.Month & "-01 "
        sFecFin = añoFin & "-" & mesFin & "-" & diaFin

        cadena = cadena + "and fecha >='" & sFecini & "' and fecha <='" & sFecFin & "' group by nit )"

        conn = objConexion.abrirConexion
        Dim dt As New DataTable
        Dim DA As New SqlDataAdapter(cadena, conn)
        DA.Fill(dt)
        conn.Close()
        Return dt
    End Function
    Public Function listarAtenFecIni(ByVal vendedor As Integer) As DataTable
        Dim cadena As String
        Dim diaFin As Integer = 1
        Dim sFecini As String = ""
        Dim sFecFin As String = ""
        Dim mesFin As Integer = Now.Month - 1
        Dim añoFin As Integer = Now.Year
        Dim fechaIni As Date
        Dim fechaFin As Date

        fechaIni = DateAdd("m", -12, Now.Year & "-" & Now.Month & "-01")
        fechaFin = DateAdd("m", -6, Now.Year & "-" & Now.Month & "-" & Now.Day)
        sFecini = fechaIni.Year & "-" & fechaIni.Month & "-01 "
        sFecFin = fechaFin.Year & "-" & fechaFin.Month & "-01"
        cadena = "select nombres,nit,ciudad,bloqueo,cupo_credito,(SELECT SUM (vtas.Vr_total )FROM Jjv_V_vtas_vend_cliente_ref vtas WHERE vtas.fec >='08-10-2012' )As ult_6_mes from terceros where nit in (select  D.nit from documentos  D where  D.vendedor=" & vendedor & " and D.sw =1 and D.fecha >='" & sFecini & "' and D.fecha <'" & sFecFin & "' group by D.nit  )"
        conn = objConexion.abrirConexion
        Dim dt As New DataTable
        Dim DA As New SqlDataAdapter(cadena, conn)
        DA.Fill(dt)
        conn.Close()
        Return dt
    End Function
    Public Function listarAtendFecFin(ByVal vendedor As Integer) As DataTable
        Dim cadena As String
        Dim sFecini As String = ""
        Dim mesFin As Integer = Now.Month - 1
        Dim añoFin As Integer = Now.Year
        Dim fechaIni As Date
        Dim fechaFin As Date
        Dim sFecFin As String
        fechaIni = DateAdd("m", -6, Now.Year & "-" & Now.Month & "-01")
        fechaFin = DateAdd("m", -0, Now.Year & "-" & Now.Month & "-" & Now.Day)
        sFecini = fechaIni.Year & "-" & fechaIni.Month & "-01 "
        sFecFin = fechaFin.Year & "-" & fechaFin.Month & "-01"
        cadena = "select nombres,nit,ciudad,bloqueo,cupo_credito,(SELECT SUM (vtas.Vr_total )FROM Jjv_V_vtas_vend_cliente_ref vtas WHERE vtas.fec >='" & sFecini & "' )As ult_6_mes from terceros where nit in (select  D.nit from documentos  D where  D.vendedor=" & vendedor & " and D.sw =1 and D.fecha >='" & sFecini & "' and D.fecha <'" & sFecFin & "' group by D.nit  )"

        conn = objConexion.abrirConexion
        Dim dt As New DataTable
        Dim DA As New SqlDataAdapter(cadena, conn)
        DA.Fill(dt)
        conn.Close()
        Return dt
    End Function
    Public Function listarNuevosFecIni(ByVal vendedor As Integer) As DataTable
        Dim cadena As String
        Dim sFecini As String = ""
        Dim fechaIni As Date
        Dim fechaFin As Date
        Dim sFecFin As String
        fechaIni = DateAdd("m", -12, Now.Year & "-" & Now.Month & "-01")
        fechaFin = DateAdd("m", -6, Now.Year & "-" & Now.Month & "-01")
        sFecini = fechaIni.Year & "-" & fechaIni.Month & "-01 "
        sFecFin = fechaFin.Year & "-" & fechaFin.Month & "-01"
        cadena = "select ter.vendedor,ter.nit,ter.nombres,ter.ciudad,ter.bloqueo,ter.cupo_credito,(SELECT SUM (vtas.Vr_total ) FROM Jjv_V_vtas_vend_cliente_ref vtas WHERE vtas.fec >='" & sFecini & "' AND vtas.nit = ter.nit)As ult_6_mes from terceros ter where  ter.vendedor=" & vendedor & " and ter.bloqueo=0 and ter.fecha_creacion >='" & sFecini & "' and ter.fecha_creacion < '" & sFecFin & "' and ter.nit in (select nit from documentos  where  vendedor=" & vendedor & " and sw =1)"

        conn = objConexion.abrirConexion
        Dim dt As New DataTable
        Dim DA As New SqlDataAdapter(cadena, conn)
        DA.Fill(dt)
        conn.Close()
        Return dt
    End Function
    Public Function listarNuevosFecFin(ByVal vendedor As Integer) As DataTable
        Dim cadena As String
        Dim sFecini As String = ""
        Dim fechaIni As Date
        Dim fechaFin As Date
        Dim sFecFin As String
        fechaIni = DateAdd("m", -6, Now.Year & "-" & Now.Month & "-01")
        fechaFin = DateAdd("m", -0, Now.Year & "-" & Now.Month & "-01")
        sFecini = fechaIni.Year & "-" & fechaIni.Month & "-01 "
        sFecFin = fechaFin.Year & "-" & fechaFin.Month & "-01"

        cadena = "select ter.vendedor,ter.nit,ter.nombres,ter.ciudad,ter.bloqueo,ter.cupo_credito,(SELECT SUM (vtas.Vr_total )FROM Jjv_V_vtas_vend_cliente_ref vtas WHERE vtas.fec >='" & sFecini & "' AND vtas.nit = ter.nit)As ult_6_mes from terceros ter where  ter.vendedor=" & vendedor & " and ter.bloqueo=0 and ter.fecha_creacion >='" & sFecini & "' and ter.fecha_creacion < '" & sFecFin & "' and ter.nit in (select nit from documentos  where  vendedor=" & vendedor & " and sw =1)"

        conn = objConexion.abrirConexion
        Dim dt As New DataTable
        Dim DA As New SqlDataAdapter(cadena, conn)
        DA.Fill(dt)
        conn.Close()
        Return dt
    End Function
    Public Function construir_table(ByVal nit As Double, ByVal dt As DataTable, ByVal fec_ini As Date, ByVal fec_fin As Date) As DataTable
        Dim fec As Date
        dt.Columns.Add("Linea_producción")
        Dim sw As Boolean = False
        Dim i As Integer = 1
        While (sw = False)
            fec = DateAdd("m", -i, fec_fin)
            dt.Columns.Add(fec.Month & "-" & fec.Year, GetType(Int64))
            i += 1
            If (fec = fec_ini) Then
                sw = True
            End If
        End While
        Return dt
    End Function
    Public Function listar_traz(ByVal nit As Double, ByVal criterio As String, ByVal fec_ini As Date, ByVal fec_fin As Date) As DataTable
        Dim conn As New SqlConnection
        Dim reader As SqlDataReader
        Dim comando As New SqlCommand
        Dim objConexion As New Conexion
        Dim dt As New DataTable
        Dim dr As DataRow
        Dim sql As String = ""
        Dim ano As Integer = 0
        Dim sw As Boolean = False
        Dim id_cor_ant As Integer = 0
        Dim sFecini As String = ""
        Dim sFecFin As String = ""
        '   Dim fec As Date = DateAdd("m", -12, Now.Year & "-" & Now.Month & "-01")
        Dim mes As Integer = 0
        dt = construir_table(nit, dt, fec_ini, fec_fin)
        comando.CommandType = CommandType.Text
        conn = objConexion.abrirConexion
        comando.Connection = conn
        sFecini = fec_ini.Year & "-" & fec_ini.Month & "-01 "
        sFecFin = fec_fin.Year & "-" & fec_fin.Month & "-" & fec_fin.Day
        sql = "SELECT SUM (vtas." & criterio & " )as criterio,vtas.Id_cor ,MONTH (fec)  as mes,YEAR (fec )as ano, seg.Descripcion " & _
                 "FROM Jjv_V_vtas_vend_cliente_ref vtas , JJV_Grupos_seguimiento seg " & _
                  "WHERE vtas.nit = " & nit & " AND fec >='" & fec_ini & "' AND fec < '" & fec_fin & "' AND seg.id_cor = vtas.id_cor " & _
                   "GROUP BY vtas.nit,vtas.Id_cor ,MONTH (fec ),YEAR (fec ) , seg.Descripcion " & _
                    "ORDER BY vtas.Id_cor "
        comando.CommandText = sql
        reader = comando.ExecuteReader
        While (reader.Read)
            ano = reader("ano")
            mes = reader("mes")
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
            End If
            dr("Linea_producción") = reader("Descripcion")
            dr(mes & "-" & ano) = reader("criterio")
        End While
        If (dt.Rows.Count = 0) Then
            If Not (dr Is Nothing) Then
                dt.Rows.Add(dr)
            End If

        End If
        conn.Close()
        reader.Close()
        Return dt
    End Function

End Class
