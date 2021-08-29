Imports System.Data.SqlClient
Imports System.Data
Imports entidadNegocios
Public Class Dtalle_seg_ppto_ad
    Private objConexion As New Conexion
    Public Function listarBusqueda(ByVal min As Integer, ByVal max As Integer, ByVal fec_ini As String, ByVal fec_fin As String, ByVal criterio As String) As DataTable
        Dim dt As New DataTable
        Dim dr As DataRow
        Dim tipo_vend As String = ""
        Dim list_vend As New List(Of Integer)
        dt.Columns.Add("Descripciòn")
        dt.Columns.Add(New DataColumn("Ppto_Vtas", GetType(Long)))
        dt.Columns.Add(New DataColumn("Pendientes", GetType(Long)))

        If (min = max) Then
            tipo_vend = min
        ElseIf (min = 1001 And max = 1037) Then
            tipo_vend = "Nacionales"
        ElseIf (min = 1001 And max = 1099) Then
            tipo_vend = "Todos"
        End If
        dt.Columns.Add(New DataColumn(tipo_vend, GetType(Long)))
        dt.Columns.Add(New DataColumn("x_cumplir", GetType(Long)))
        For i = 1 To 27
            Select Case i
                Case 1
                    dr = dt.NewRow
                    dr("Descripciòn") = "AL BRILL"
                    dr("Ppto_Vtas") = ppto_vtas_idcor(i, fec_ini, fec_fin, min, max, criterio)
                    dr("Pendientes") = pendientes_todos(fec_ini, fec_fin, i, min, max, criterio)
                    dr(tipo_vend) = tot_vtas(fec_ini, fec_fin, min, max, i, criterio)
                    dr("x_cumplir") = (dr("Ppto_Vtas") - dr("Pendientes") - dr(tipo_vend))
                    If Not (dr("x_cumplir") = 0) Then
                        dt.Rows.Add(dr)
                    End If
                Case 2
                    dr = dt.NewRow
                    dr("Descripciòn") = "AL RECO"
                    dr("Ppto_Vtas") = ppto_vtas_idcor(i, fec_ini, fec_fin, min, max, criterio)
                    dr("Pendientes") = pendientes_todos(fec_ini, fec_fin, i, min, max, criterio)
                    dr(tipo_vend) = tot_vtas(fec_ini, fec_fin, min, max, i, criterio)
                    dr("x_cumplir") = dr("Ppto_Vtas") - dr("Pendientes") - dr(tipo_vend)
                    If Not (dr("x_cumplir") = 0) Then
                        dt.Rows.Add(dr)
                    End If
                Case 3
                    dr = dt.NewRow
                    dr("Descripciòn") = "AL ESPE"
                    dr("Ppto_Vtas") = ppto_vtas_idcor(i, fec_ini, fec_fin, min, max, criterio)
                    dr("Pendientes") = pendientes_todos(fec_ini, fec_fin, i, min, max, criterio)
                    dr(tipo_vend) = tot_vtas(fec_ini, fec_fin, min, max, i, criterio)
                    dr("x_cumplir") = dr("Ppto_Vtas") - dr("Pendientes") - dr(tipo_vend)
                    If Not (dr("x_cumplir") = 0) Then
                        dt.Rows.Add(dr)
                    End If
                Case 4
                    dr = dt.NewRow
                    dr("Descripciòn") = "VARILLAS"
                    dr("Ppto_Vtas") = ppto_vtas_idcor(i, fec_ini, fec_fin, min, max, criterio)
                    dr("Pendientes") = pendientes_todos(fec_ini, fec_fin, i, min, max, criterio)
                    dr(tipo_vend) = tot_vtas(fec_ini, fec_fin, min, max, i, criterio)
                    dr("x_cumplir") = dr("Ppto_Vtas") - dr("Pendientes") - dr(tipo_vend)
                    If Not (dr("x_cumplir") = 0) Then
                        dt.Rows.Add(dr)
                    End If
                Case 5
                    dr = dt.NewRow
                    dr("Descripciòn") = "AL PUAS"
                    dr("Ppto_Vtas") = ppto_vtas_idcor(i, fec_ini, fec_fin, min, max, criterio)
                    dr("Pendientes") = pendientes_todos(fec_ini, fec_fin, i, min, max, criterio)
                    dr(tipo_vend) = tot_vtas(fec_ini, fec_fin, min, max, i, criterio)
                    dr("x_cumplir") = dr("Ppto_Vtas") - dr("Pendientes") - dr(tipo_vend)
                    If Not (dr("x_cumplir") = 0) Then
                        dt.Rows.Add(dr)
                    End If
                Case 6
                    dr = dt.NewRow
                    dr("Descripciòn") = "AL GALV"
                    dr("Ppto_Vtas") = ppto_vtas_idcor(i, fec_ini, fec_fin, min, max, criterio)
                    dr("Pendientes") = pendientes_todos(fec_ini, fec_fin, i, min, max, criterio)
                    dr(tipo_vend) = tot_vtas(fec_ini, fec_fin, min, max, i, criterio)
                    dr("x_cumplir") = dr("Ppto_Vtas") - dr("Pendientes") - dr(tipo_vend)
                    If Not (dr("x_cumplir") = 0) Then
                        dt.Rows.Add(dr)
                    End If
                Case 7
                    dr = dt.NewRow
                    dr("Descripciòn") = "M. POLLO"
                    dr("Ppto_Vtas") = ppto_vtas_idcor(i, fec_ini, fec_fin, min, max, criterio)
                    dr("Pendientes") = pendientes_todos(fec_ini, fec_fin, i, min, max, criterio)
                    dr(tipo_vend) = tot_vtas(fec_ini, fec_fin, min, max, i, criterio)
                    dr("x_cumplir") = dr("Ppto_Vtas") - dr("Pendientes") - dr(tipo_vend)
                    If Not (dr("x_cumplir") = 0) Then
                        dt.Rows.Add(dr)
                    End If
                Case 8
                    dr = dt.NewRow
                    dr("Descripciòn") = "C.C 350-700"
                    dr("Ppto_Vtas") = ppto_vtas_idcor(i, fec_ini, fec_fin, min, max, criterio)
                    dr("Pendientes") = pendientes_todos(fec_ini, fec_fin, i, min, max, criterio)
                    dr(tipo_vend) = tot_vtas(fec_ini, fec_fin, min, max, i, criterio)
                    dr("x_cumplir") = dr("Ppto_Vtas") - dr("Pendientes") - dr(tipo_vend)
                    If Not (dr("x_cumplir") = 0) Then
                        dt.Rows.Add(dr)
                    End If
                Case 9
                    dr = dt.NewRow
                    dr("Descripciòn") = "C.C 400-800"
                    dr("Ppto_Vtas") = ppto_vtas_idcor(i, fec_ini, fec_fin, min, max, criterio)
                    dr("Pendientes") = pendientes_todos(fec_ini, fec_fin, i, min, max, criterio)
                    dr(tipo_vend) = tot_vtas(fec_ini, fec_fin, min, max, i, criterio)
                    dr("x_cumplir") = dr("Ppto_Vtas") - dr("Pendientes") - dr(tipo_vend)
                    If Not (dr("x_cumplir") = 0) Then
                        dt.Rows.Add(dr)
                    End If
                Case 10
                    dr = dt.NewRow
                    dr("Descripciòn") = "C.C 500-1000"
                    dr("Ppto_Vtas") = ppto_vtas_idcor(i, fec_ini, fec_fin, min, max, criterio)
                    dr("Pendientes") = pendientes_todos(fec_ini, fec_fin, i, min, max, criterio)
                    dr(tipo_vend) = tot_vtas(fec_ini, fec_fin, min, max, i, criterio)
                    dr("x_cumplir") = dr("Ppto_Vtas") - dr("Pendientes") - dr(tipo_vend)
                    If Not (dr("x_cumplir") = 0) Then
                        dt.Rows.Add(dr)
                    End If
                Case 11
                    dr = dt.NewRow
                    dr("Descripciòn") = "CL GRANEL"
                    dr("Ppto_Vtas") = ppto_vtas_idcor(i, fec_ini, fec_fin, min, max, criterio)
                    dr("Pendientes") = pendientes_todos(fec_ini, fec_fin, i, min, max, criterio)
                    dr(tipo_vend) = tot_vtas(fec_ini, fec_fin, min, max, i, criterio)
                    dr("x_cumplir") = dr("Ppto_Vtas") - dr("Pendientes") - dr(tipo_vend)
                    If Not (dr("x_cumplir") = 0) Then
                        dt.Rows.Add(dr)
                    End If
                Case 12
                    dr = dt.NewRow
                    dr("Descripciòn") = "CL VARETA"
                    dr("Ppto_Vtas") = ppto_vtas_idcor(i, fec_ini, fec_fin, min, max, criterio)
                    dr("Pendientes") = pendientes_todos(fec_ini, fec_fin, i, min, max, criterio)
                    dr(tipo_vend) = tot_vtas(fec_ini, fec_fin, min, max, i, criterio)
                    dr("x_cumplir") = dr("Ppto_Vtas") - dr("Pendientes") - dr(tipo_vend)
                    If Not (dr("x_cumplir") = 0) Then
                        dt.Rows.Add(dr)
                    End If
                Case 13
                    dr = dt.NewRow
                    dr("Descripciòn") = "CL ZINC"
                    dr("Ppto_Vtas") = ppto_vtas_idcor(i, fec_ini, fec_fin, min, max, criterio)
                    dr("Pendientes") = pendientes_todos(fec_ini, fec_fin, i, min, max, criterio)
                    dr(tipo_vend) = tot_vtas(fec_ini, fec_fin, min, max, i, criterio)
                    dr("x_cumplir") = dr("Ppto_Vtas") - dr("Pendientes") - dr(tipo_vend)
                    If Not (dr("x_cumplir") = 0) Then
                        dt.Rows.Add(dr)
                    End If
                Case 14
                    dr = dt.NewRow
                    dr("Descripciòn") = "HEL Y ANULA"
                    dr("Ppto_Vtas") = ppto_vtas_idcor(i, fec_ini, fec_fin, min, max, criterio)
                    dr("Pendientes") = pendientes_todos(fec_ini, fec_fin, i, min, max, criterio)
                    dr(tipo_vend) = tot_vtas(fec_ini, fec_fin, min, max, i, criterio)
                    dr("x_cumplir") = dr("Ppto_Vtas") - dr("Pendientes") - dr(tipo_vend)
                    If Not (dr("x_cumplir") = 0) Then
                        dt.Rows.Add(dr)
                    End If
                Case 15
                    dr = dt.NewRow
                    dr("Descripciòn") = "CL ELECTRO"
                    dr("Ppto_Vtas") = ppto_vtas_idcor(i, fec_ini, fec_fin, min, max, criterio)
                    dr("Pendientes") = pendientes_todos(fec_ini, fec_fin, i, min, max, criterio)
                    dr(tipo_vend) = tot_vtas(fec_ini, fec_fin, min, max, i, criterio)
                    dr("x_cumplir") = dr("Ppto_Vtas") - dr("Pendientes") - dr(tipo_vend)
                    If Not (dr("x_cumplir") = 0) Then
                        dt.Rows.Add(dr)
                    End If
                Case 16
                    dr = dt.NewRow
                    dr("Descripciòn") = "CL ACERO"
                    dr("Ppto_Vtas") = ppto_vtas_idcor(i, fec_ini, fec_fin, min, max, criterio)
                    dr("Pendientes") = pendientes_todos(fec_ini, fec_fin, i, min, max, criterio)
                    dr(tipo_vend) = tot_vtas(fec_ini, fec_fin, min, max, i, criterio)
                    dr("x_cumplir") = dr("Ppto_Vtas") - dr("Pendientes") - dr(tipo_vend)
                    If Not (dr("x_cumplir") = 0) Then
                        dt.Rows.Add(dr)
                    End If
                Case 17
                    dr = dt.NewRow
                    dr("Descripciòn") = "GRAPAS"
                    dr("Ppto_Vtas") = ppto_vtas_idcor(i, fec_ini, fec_fin, min, max, criterio)
                    dr("Pendientes") = pendientes_todos(fec_ini, fec_fin, i, min, max, criterio)
                    dr(tipo_vend) = tot_vtas(fec_ini, fec_fin, min, max, i, criterio)
                    dr("x_cumplir") = dr("Ppto_Vtas") - dr("Pendientes") - dr(tipo_vend)
                    If Not (dr("x_cumplir") = 0) Then
                        dt.Rows.Add(dr)
                    End If
                Case 18
                    dr = dt.NewRow
                    dr("Descripciòn") = "CL HERRAR"
                    dr("Ppto_Vtas") = ppto_vtas_idcor(i, fec_ini, fec_fin, min, max, criterio)
                    dr("Pendientes") = pendientes_todos(fec_ini, fec_fin, i, min, max, criterio)
                    dr(tipo_vend) = tot_vtas(fec_ini, fec_fin, min, max, i, criterio)
                    dr("x_cumplir") = dr("Ppto_Vtas") - dr("Pendientes") - dr(tipo_vend)
                    If Not (dr("x_cumplir") = 0) Then
                        dt.Rows.Add(dr)
                    End If
                Case 19
                    dr = dt.NewRow
                    dr("Descripciòn") = "TR ESTUFA"
                    dr("Ppto_Vtas") = ppto_vtas_idcor(i, fec_ini, fec_fin, min, max, criterio)
                    dr("Pendientes") = pendientes_todos(fec_ini, fec_fin, i, min, max, criterio)
                    dr(tipo_vend) = tot_vtas(fec_ini, fec_fin, min, max, i, criterio)
                    dr("x_cumplir") = dr("Ppto_Vtas") - dr("Pendientes") - dr(tipo_vend)
                    If Not (dr("x_cumplir") = 0) Then
                        dt.Rows.Add(dr)
                    End If
                Case 20
                    dr = dt.NewRow
                    dr("Descripciòn") = "TR LAMINA"
                    dr("Ppto_Vtas") = ppto_vtas_idcor(i, fec_ini, fec_fin, min, max, criterio)
                    dr("Pendientes") = pendientes_todos(fec_ini, fec_fin, i, min, max, criterio)
                    dr(tipo_vend) = tot_vtas(fec_ini, fec_fin, min, max, i, criterio)
                    dr("x_cumplir") = dr("Ppto_Vtas") - dr("Pendientes") - dr(tipo_vend)
                    If Not (dr("x_cumplir") = 0) Then
                        dt.Rows.Add(dr)
                    End If
                Case 21
                    dr = dt.NewRow
                    dr("Descripciòn") = "TR MADERA"
                    dr("Ppto_Vtas") = ppto_vtas_idcor(i, fec_ini, fec_fin, min, max, criterio)
                    dr("Pendientes") = pendientes_todos(fec_ini, fec_fin, i, min, max, criterio)
                    dr(tipo_vend) = tot_vtas(fec_ini, fec_fin, min, max, i, criterio)
                    dr("x_cumplir") = dr("Ppto_Vtas") - dr("Pendientes") - dr(tipo_vend)
                    If Not (dr("x_cumplir") = 0) Then
                        dt.Rows.Add(dr)
                    End If
                Case 22
                    dr = dt.NewRow
                    dr("Descripciòn") = "TR AGLOM"
                    dr("Ppto_Vtas") = ppto_vtas_idcor(i, fec_ini, fec_fin, min, max, criterio)
                    dr("Pendientes") = pendientes_todos(fec_ini, fec_fin, i, min, max, criterio)
                    dr(tipo_vend) = tot_vtas(fec_ini, fec_fin, min, max, i, criterio)
                    dr("x_cumplir") = dr("Ppto_Vtas") - dr("Pendientes") - dr(tipo_vend)
                    If Not (dr("x_cumplir") = 0) Then
                        dt.Rows.Add(dr)
                    End If
                Case 23
                    dr = dt.NewRow
                    dr("Descripciòn") = "TR CHAZO"
                    dr("Ppto_Vtas") = ppto_vtas_idcor(i, fec_ini, fec_fin, min, max, criterio)
                    dr("Pendientes") = pendientes_todos(fec_ini, fec_fin, i, min, max, criterio)
                    dr(tipo_vend) = tot_vtas(fec_ini, fec_fin, min, max, i, criterio)
                    dr("x_cumplir") = dr("Ppto_Vtas") - dr("Pendientes") - dr(tipo_vend)
                    If Not (dr("x_cumplir") = 0) Then
                        dt.Rows.Add(dr)
                    End If
                Case 24
                    dr = dt.NewRow
                    dr("Descripciòn") = "REMACHES"
                    dr("Ppto_Vtas") = ppto_vtas_idcor(i, fec_ini, fec_fin, min, max, criterio)
                    dr("Pendientes") = pendientes_todos(fec_ini, fec_fin, i, min, max, criterio)
                    dr(tipo_vend) = tot_vtas(fec_ini, fec_fin, min, max, i, criterio)
                    dr("x_cumplir") = dr("Ppto_Vtas") - dr("Pendientes") - dr(tipo_vend)
                    If Not (dr("x_cumplir") = 0) Then
                        dt.Rows.Add(dr)
                    End If
                Case 25
                    dr = dt.NewRow
                    dr("Descripciòn") = "CARRIAJE"
                    dr("Ppto_Vtas") = ppto_vtas_idcor(i, fec_ini, fec_fin, min, max, criterio)
                    dr("Pendientes") = pendientes_todos(fec_ini, fec_fin, i, min, max, criterio)
                    dr(tipo_vend) = tot_vtas(fec_ini, fec_fin, min, max, i, criterio)
                    dr("x_cumplir") = dr("Ppto_Vtas") - dr("Pendientes") - dr(tipo_vend)
                    If Not (dr("x_cumplir") = 0) Then
                        dt.Rows.Add(dr)
                    End If
                Case 26
                    dr = dt.NewRow
                    dr("Descripciòn") = "TR DRIWALL"
                    dr("Ppto_Vtas") = ppto_vtas_idcor(i, fec_ini, fec_fin, min, max, criterio)
                    dr("Pendientes") = pendientes_todos(fec_ini, fec_fin, i, min, max, criterio)
                    dr(tipo_vend) = tot_vtas(fec_ini, fec_fin, min, max, i, criterio)
                    dr("x_cumplir") = dr("Ppto_Vtas") - dr("Pendientes") - dr(tipo_vend)
                    If Not (dr("x_cumplir") = 0) Then
                        dt.Rows.Add(dr)
                    End If
                Case 27
                    dr = dt.NewRow
                    dr("Descripciòn") = "ARANDELA"
                    dr("Ppto_Vtas") = ppto_vtas_idcor(i, fec_ini, fec_fin, min, max, criterio)
                    dr("Pendientes") = pendientes_todos(fec_ini, fec_fin, i, min, max, criterio)
                    dr(tipo_vend) = tot_vtas(fec_ini, fec_fin, min, max, i, criterio)
                    dr("x_cumplir") = dr("Ppto_Vtas") - dr("Pendientes") - dr(tipo_vend)
                    If Not (dr("x_cumplir") = 0) Then
                        dt.Rows.Add(dr)
                    End If
            End Select
        Next
        dr = dt.NewRow
        dr("Descripciòn") = "TOTAL"
        dt.Rows.Add(dr)

        'Dim dt As New DataTable
        'Dim dr As DataRow = dt.NewRow
        'dt.Columns.Add()
        'dt.Columns.Add("nombre_cuenta")
        'dt.Columns.Add("nombre")
        'dt.Columns.Add("apellido")
        'dt.Columns.Add("celular")
        'dr() = "12345″"
        'dr("nombre_cuenta") = "Juan Perez"
        'dr("nombre") = "Juan"
        'dr("apellido") = "Perez"
        'dr("celular") = "507.60000000″"
        'dt.Rows.Add(dr)
        'dr = dt.NewRow
        'dr() = "12345″"
        'dr("nombre_cuenta") = "Juan Perez"
        'dr("nombre") = "Juan"
        'dr("apellido") = "Perez"
        'dr("celular") = "507.60000000″"
        'dt.Rows.Add(dr)
        dt.AcceptChanges()

        Return dt

    End Function
    Public Function listar_vendedores() As List(Of Integer)
        Dim reader As SqlDataReader
        Dim list_vend As New List(Of Integer)
        Dim k As Double = 0
        Dim comando As New SqlCommand
        Dim conn As New SqlConnection
        comando.CommandType = CommandType.Text
        conn = objConexion.abrirConexion
        comando.Connection = conn
        comando.CommandText = ("select vendedor FROM v_vendedores WHERE     (vendedor >= 1001) AND (vendedor <= 1099) AND (bloqueo = 0) ORDER BY vendedor")
        reader = comando.ExecuteReader
        While (reader.Read)
            If IsDBNull(reader(0)) Then
            Else
                list_vend.Add(reader("vendedor"))
                k = k + 1
            End If
        End While
        conn.Close()
        Return list_vend
    End Function
    Private Function ppto_vtas_idcor(ByVal id_cor As Integer, ByVal fec_ini As String, ByVal fec_fin As String, ByVal min As Integer, ByVal max As Integer, ByVal criterio As String) As Double
        Dim comando1 As New SqlCommand
        Dim resp As Double = 0
        Dim reader As SqlDataReader
        Dim sql As String = ""
        Dim conn As New SqlConnection
        If (criterio = "kilos") Then
            criterio = "Ppto_kilos"
        Else
            criterio = "Vr_total"
        End If
        comando1.CommandType = CommandType.Text
        conn = objConexion.abrirConexion
        comando1.Connection = conn
        comando1.Parameters.Add("@id_cor", SqlDbType.VarChar).Value = id_cor
        comando1.Parameters.Add("@min", SqlDbType.VarChar).Value = min
        comando1.Parameters.Add("@max", SqlDbType.VarChar).Value = max
        comando1.Parameters.Add("@fec_ini", SqlDbType.SmallDateTime).Value = fec_ini
        comando1.Parameters.Add("@fec_fin", SqlDbType.SmallDateTime).Value = fec_fin
        sql = "select SUM (" & criterio & ") from Jjv_Ppto_mes where Id_cor=@id_cor and Fecha_ppto >=@fec_ini and Fecha_ppto <=@fec_fin and Vendedor <> 10011099 and Vendedor >= @min and Vendedor <= @max"
        comando1.CommandText = (sql)
        reader = comando1.ExecuteReader
        If (reader.Read) Then
            If IsDBNull(reader(0)) Then
            Else
                resp = reader(0)
            End If
        End If
        Return resp
        conn.Close()
    End Function
    Private Function pendientes_todos(ByVal fec_ini As String, ByVal fec_fin As String, ByVal id_cor As Integer, ByVal min As Integer, ByVal max As Integer, ByVal criterio As String) As Double
        Dim comando1 As New SqlCommand
        Dim resp As Double = 0
        Dim reader As SqlDataReader
        Dim sql As String = ""
        Dim conn As New SqlConnection
        comando1.CommandType = CommandType.Text
        If (criterio = "kilos") Then
            criterio = "KilosPendiente"
        Else
            criterio = "Valor_total"
        End If
        conn = objConexion.abrirConexion
        comando1.Connection = conn
        comando1.Parameters.Add("@id_cor", SqlDbType.VarChar).Value = id_cor
        comando1.Parameters.Add("@min", SqlDbType.VarChar).Value = min
        comando1.Parameters.Add("@max", SqlDbType.VarChar).Value = max
        sql = "SELECT distinct codigo,fecha, numero, " & criterio & " " & _
                        "FROM Jjv_Ptes_Con_Stock " & _
                                "WHERE Valor_total >0 and Vendedor >= @min and Vendedor <= @max and  Id_cor =@id_cor"
        comando1.CommandText = (sql)
        reader = comando1.ExecuteReader
        While (reader.Read)
            If IsDBNull(reader(3)) Then
            Else
                resp += reader(3)
            End If
        End While
        Return resp
        conn.Close()
    End Function
    Private Function tot_vtas(ByVal fec_ini As String, ByVal fec_fin As String, ByVal min As Integer, ByVal max As Integer, ByVal id_cor As Integer, ByVal criterio As String) As Double
        Dim comando1 As New SqlCommand
        Dim resp As Double = 0
        Dim reader As SqlDataReader
        Dim sql As String = ""
        Dim conn As New SqlConnection
        comando1.CommandType = CommandType.Text
        If (criterio = "kilos") Then
            criterio = "KILOS"
        Else
            criterio = "Vr_total"
        End If
        conn = objConexion.abrirConexion
        comando1.Connection = conn
        comando1.Parameters.Add("@id_cor", SqlDbType.VarChar).Value = id_cor
        comando1.Parameters.Add("@fec_ini", SqlDbType.SmallDateTime).Value = fec_ini
        comando1.Parameters.Add("@fec_fin", SqlDbType.SmallDateTime).Value = fec_fin
        comando1.Parameters.Add("@min", SqlDbType.VarChar).Value = min
        comando1.Parameters.Add("@max", SqlDbType.VarChar).Value = max
        sql = "Select Sum (" & criterio & ") " & _
                        "from Jjv_V_vtas_vend_cliente_ref " & _
                            "where vendedor > = @min and vendedor <= @max and Id_cor = @id_cor and fec >=@fec_ini and Fec <=@fec_fin"
        comando1.CommandText = (sql)
        reader = comando1.ExecuteReader
        While (reader.Read)
            If IsDBNull(reader(0)) Then
            Else
                resp += reader(0)
            End If
        End While
        Return resp
        conn.Close()
    End Function

End Class
