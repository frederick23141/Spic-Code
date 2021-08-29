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
    Public Function vendedores() As Integer()
        Dim reader As SqlDataReader
        Dim vecVend(99) As Integer
        Dim k As Double = 0
        comando.CommandType = CommandType.Text
        conn = objConexion.abrirConexion
        comando.Connection = conn
        comando.CommandText = ("select vendedor FROM v_vendedores WHERE     (vendedor >= 1001) AND (vendedor <= 1099) AND (bloqueo = 0) ORDER BY vendedor")
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
        comando.CommandText = ("select COUNT (nit) from terceros where  vendedor=" & vendedor & "  and nit  in (select nit from documentos  where  vendedor=" & vendedor & "  and sw =1 and fecha >='" & sFecini & "' and fecha <='" & sFecFin & "' group by nit )")
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
        comando.CommandText = ("select COUNT (nit) from terceros where  vendedor=" & vendedor & " and bloqueo=0 and nit in (select nit from documentos  where  vendedor=" & vendedor & " and sw =1 and fecha >='" & sFecini & "' and fecha <='" & sFecFin & "' group by nit )")
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
        comando.CommandType = CommandType.Text
        conn = objConexion.abrirConexion
        comando.Connection = conn
        comando.CommandText = ("select COUNT (nit) from terceros where  vendedor=" & vendedor & " and bloqueo=1 and nit in (select nit from documentos  where  vendedor=" & vendedor & " and sw =1 and fecha >='" & sFecini & "' and fecha <='" & sFecFin & "' group by nit )")
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
        comando.CommandType = CommandType.Text
        conn = objConexion.abrirConexion
        comando.Connection = conn
        comando.CommandText = ("select COUNT (nit) from terceros where  vendedor=" & vendedor & " and bloqueo=2 and nit in (select nit from documentos  where  vendedor=" & vendedor & " and sw =1 and fecha >='" & sFecini & "' and fecha <='" & sFecFin & "' group by nit )")
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
        comando.CommandType = CommandType.Text
        conn = objConexion.abrirConexion
        comando.Connection = conn
        comando.CommandText = ("select COUNT (nit) from terceros where  vendedor=" & vendedor & " and bloqueo=3 and nit in (select nit from documentos  where  vendedor=" & vendedor & " and sw =1 and fecha >='" & sFecini & "' and fecha <='" & sFecFin & "' group by nit )")
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
        Dim mesFin As Integer = Now.Month - 1
        Dim añoFin As Integer = Now.Year
        Dim fechaIni As Date
        Dim sFecFin As String

        fechaIni = DateAdd("m", -12, Now.Year & "-" & Now.Month & "-01")

        mesFin = Now.Month - 7
        If (mesFin <= 0) Then
            mesFin = 12 - mesFin
            añoFin = Now.Year - 1
        End If

        If (mesFin = 4 Or mesFin = 6 Or mesFin = 9 Or mesFin = 11) Then
            diaFin = 30
        Else
            diaFin = 31
        End If
        If (mesFin = 2) Then
            diaFin = 28
        End If

        sFecini = fechaIni.Year & "-" & fechaIni.Month & "-01 "
        sFecFin = añoFin & "-" & mesFin & "-" & diaFin
        Dim reader As SqlDataReader
        Dim tot As Double
        Dim cont As Integer = 0
        comando.CommandType = CommandType.Text
        conn = objConexion.abrirConexion
        comando.Connection = conn
        comando.CommandText = ("select  count  (nit) from documentos  where  vendedor=" & vendedor & " and sw =1 and fecha >='" & sFecini & "' and fecha <='" & sFecFin & "' group by nit ")
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
        Dim tot As Double
        Dim cont As Integer = 0
        comando.CommandType = CommandType.Text
        conn = objConexion.abrirConexion
        comando.Connection = conn
        ' MsgBox(" fecga de fin select  count  (nit) from documentos  where  vendedor=" & vendedor & " and sw =1 and fecha >='" & sFecini & "' and fecha <='" & sFecFin & "' group by nit ")
        comando.CommandText = ("select  count  (nit) from documentos  where  vendedor=" & vendedor & " and sw =1 and fecha >='" & sFecini & "' and fecha <='" & sFecFin & "' group by nit ")
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
        Dim mesFin As Integer = Now.Month - 1
        Dim añoFin As Integer = Now.Year
        Dim fechaIni As Date
        Dim sFecFin As String

        fechaIni = DateAdd("m", -12, Now.Year & "-" & Now.Month & "-01")

        mesFin = Now.Month - 7
        If (mesFin <= 0) Then
            mesFin = 12 - mesFin
            añoFin = Now.Year - 1
        End If

        If (mesFin = 4 Or mesFin = 6 Or mesFin = 9 Or mesFin = 11) Then
            diaFin = 30
        Else
            diaFin = 31
        End If
        If (mesFin = 2) Then
            diaFin = 28
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
    Public Function listarEstClient() As List(Of EstClienVendEn)
        Dim listaEstClient As New List(Of EstClienVendEn)
        Dim vecVend As Integer() = vendedores()
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
        Dim mesFin As Integer = Now.Month - 1
        Dim añoFin As Integer = Now.Year
        Dim fechaIni As Date
        Dim sFecFin As String

        fechaIni = DateAdd("m", -12, Now.Year & "-" & Now.Month & "-01")

        mesFin = Now.Month - 7
        If (mesFin <= 0) Then
            mesFin = 12 - mesFin
            añoFin = Now.Year - 1
        End If

        If (mesFin = 4 Or mesFin = 6 Or mesFin = 9 Or mesFin = 11) Then
            diaFin = 30
        Else
            diaFin = 31
        End If
        If (mesFin = 2) Then
            diaFin = 28
        End If

        sFecini = fechaIni.Year & "-" & fechaIni.Month & "-01 "
        sFecFin = añoFin & "-" & mesFin & "-" & diaFin

        cadena = "select nombres,nit,ciudad,condicion,bloqueo,cupo_credito,fecha_creacion from terceros where nit in (select  D.nit from documentos  D where  D.vendedor=" & vendedor & " and D.sw =1 and D.fecha >='" & sFecini & "' and D.fecha <='" & sFecFin & "' group by D.nit  )"
        MsgBox(cadena)
        conn = objConexion.abrirConexion
        Dim dt As New DataTable
        Dim DA As New SqlDataAdapter(cadena, conn)
        DA.Fill(dt)
        conn.Close()
        Return dt
    End Function
    Public Function listarAtendFecFin(ByVal vendedor As Integer) As DataTable
        Dim cadena As String

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

        cadena = "select nombres,nit,ciudad,condicion,bloqueo,cupo_credito,fecha_creacion from terceros where nit in (select  D.nit from documentos  D where  D.vendedor=" & vendedor & " and D.sw =1 and D.fecha >='" & sFecini & "' and D.fecha <='" & sFecFin & "' group by D.nit  )"

        conn = objConexion.abrirConexion
        Dim dt As New DataTable
        Dim DA As New SqlDataAdapter(cadena, conn)
        DA.Fill(dt)
        conn.Close()
        Return dt
    End Function




    Public Function listarNuevosFecIni(ByVal vendedor As Integer) As DataTable

        Dim cadena As String

        Dim diaFin As Integer = 1
        Dim sFecini As String = ""
        Dim mesFin As Integer = Now.Month - 1
        Dim añoFin As Integer = Now.Year
        Dim fechaIni As Date
        Dim sFecFin As String

        fechaIni = DateAdd("m", -12, Now.Year & "-" & Now.Month & "-01")

        mesFin = Now.Month - 7
        If (mesFin <= 0) Then
            mesFin = 12 - mesFin
            añoFin = Now.Year - 1
        End If

        If (mesFin = 4 Or mesFin = 6 Or mesFin = 9 Or mesFin = 11) Then
            diaFin = 30
        Else
            diaFin = 31
        End If
        If (mesFin = 2) Then
            diaFin = 28
        End If

        sFecini = fechaIni.Year & "-" & fechaIni.Month & "-01 "
        sFecFin = añoFin & "-" & mesFin & "-" & diaFin

        cadena = "select vendedor,nit,nombres,ciudad,condicion,bloqueo,cupo_credito,fecha_creacion from terceros where  vendedor=" & vendedor & " and bloqueo=0 and fecha_creacion >='" & sFecini & "' and fecha_creacion <= '" & sFecFin & "' and nit in (select nit from documentos  where  vendedor=" & vendedor & " and sw =1)"

        conn = objConexion.abrirConexion
        Dim dt As New DataTable
        Dim DA As New SqlDataAdapter(cadena, conn)
        DA.Fill(dt)
        conn.Close()
        Return dt
    End Function
    Public Function listarNuevosFecFin(ByVal vendedor As Integer) As DataTable
        Dim cadena As String

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

        cadena = "select vendedor,nit,nombres,ciudad,condicion,bloqueo,cupo_credito,fecha_creacion from terceros where  vendedor=" & vendedor & " and bloqueo=0 and fecha_creacion >='" & sFecini & "' and fecha_creacion <= '" & sFecFin & "' and nit in (select nit from documentos  where  vendedor=" & vendedor & " and sw =1)"

        conn = objConexion.abrirConexion
        Dim dt As New DataTable
        Dim DA As New SqlDataAdapter(cadena, conn)
        DA.Fill(dt)
        conn.Close()
        Return dt
    End Function





    

End Class
