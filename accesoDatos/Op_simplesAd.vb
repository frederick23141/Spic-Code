Imports System.Data.SqlClient
Imports System.Data
Imports entidadNegocios
Imports System.Data.SqlServerCe

Public Class Op_simplesAd
    Private conn As New SqlConnection
    Dim cmd As SqlCommand
    Public Function listar_datatable(ByVal sql As String, ByVal db As String) As DataTable
        Dim objConexion As New Conexion
        If (db = "CORSAN") Then
            conn = objConexion.abrirConexion
        ElseIf (db = "PRODUCCION") Then
            conn = objConexion.abrirConexion_prod
        ElseIf (db = "CONTROL") Then
            conn = objConexion.abrirConexionControl
        End If
        Dim dt As New DataTable

        Dim DA As New SqlDataAdapter(sql, conn)
        DA.SelectCommand.CommandTimeout = 900
        DA.Fill(dt)
        conn.Close()
        Return dt
    End Function
    Public Function lista(ByVal sql As String) As List(Of Object)
        Dim objConexion As New Conexion
        Dim reader As SqlDataReader
        Dim lista_valores As New List(Of Object)
        Dim comando As New SqlCommand
        Dim conn As New SqlConnection
        comando.CommandType = CommandType.Text
        conn = objConexion.abrirConexion
        comando.Connection = conn
        comando.CommandText = (sql)
        reader = comando.ExecuteReader
        While (reader.Read)
            If IsDBNull(reader(0)) Then
            Else
                lista_valores.Add(reader(0))
            End If
        End While
        conn.Close()
        Return lista_valores
    End Function
    Public Function consultValor(ByVal sql As String) As String
        Dim resp As String = ""
        Dim comando As New System.Data.SqlClient.SqlCommand
        Dim conn As New SqlConnection
        Dim objConexion As New Conexion
        comando = New SqlCommand
        Dim i As Integer = 0
        Dim reader As SqlDataReader
        comando.CommandType = CommandType.Text
        conn = objConexion.abrirConexion
        If conn.State = ConnectionState.Open Then
            comando.Connection = conn
            comando.CommandText = (sql)
            reader = comando.ExecuteReader
            While (reader.Read)
                If Not IsDBNull(reader(0)) Then
                    resp = reader(0)
                End If
            End While
            conn.Close()
        Else
            MsgBox("No se pudo establecer conexión con la base de datos")
        End If
        Return resp
    End Function
    Public Function consultValorTodo(ByVal sql As String, ByVal db As String) As String
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
        ElseIf (db = "CONTROL") Then
            conn = objConexion.abrirConexionControl
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
    Public Function matriz(ByVal sql As String, ByVal tamano As Integer, ByVal campos As Integer) As Object(,)
        Dim mat(tamano, campos) As Object
        Dim objConexion As New Conexion
        Dim comando As New SqlCommand
        Dim resp As Double = 0
        Dim reader As SqlDataReader
        Dim i As Integer = 0
        conn = objConexion.abrirConexion
        comando.Connection = conn
        comando.CommandType = CommandType.Text
        comando.CommandText = (sql)
        comando.CommandTimeout = 900
        reader = comando.ExecuteReader
        While reader.Read
            If IsDBNull(reader(0)) Then
            Else
                For j = 0 To campos
                    mat(i, j) = reader(j)
                Next
                i += 1
            End If
        End While
        conn.Close()
        Return mat
    End Function

    Public Function listaOfListas(ByVal sql As String, ByVal db As String, ByVal numCol As Integer) As List(Of Object)
        Dim listPpal As New List(Of Object)
        Dim list As New List(Of Object)
        Dim objConexion As New Conexion
        Dim reader As SqlDataReader
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
            If Not (IsDBNull(reader(0))) Then
                For i = 0 To numCol
                    list.Add(reader(i))
                Next
                listPpal.Add(list)
                list = New List(Of Object)
            End If
        End While
        conn.Close()
        Return listPpal
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
            ElseIf (db = "CONTROL") Then
                conn = objConexion.abrirConexionControl
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
    Public Function modificar_script(ByVal sql_script As String, ByVal numero As Integer, ByVal consecutivo As Integer, ByVal desc_modulo As String, ByVal db As String) As Integer
        Dim resp As Integer = 0
        Try
            Dim sql As String = "UPDATE J_script_modulos_prueba SET script =@script WHERE numero =@numero AND desc_modulo =@desc_modulo AND consecutivo =@consecutivo "
            Dim objConexion As New Conexion
            Dim comando1 As New System.Data.SqlClient.SqlCommand
            If (db = "CORSAN") Then
                conn = objConexion.abrirConexion
            ElseIf (db = "PRODUCCION") Then
                conn = objConexion.abrirConexion_prod
            End If
            comando1.CommandType = System.Data.CommandType.Text
            comando1.Parameters.Add("@script", SqlDbType.VarChar).Value = Sql_script
            comando1.Parameters.Add("@numero", SqlDbType.VarChar).Value = numero
            comando1.Parameters.Add("@desc_modulo", SqlDbType.VarChar).Value = desc_modulo
            comando1.Parameters.Add("@consecutivo", SqlDbType.VarChar).Value = consecutivo
            comando1.Connection = conn
            comando1.CommandText = sql
            resp = (comando1.ExecuteNonQuery())
        Catch ex As Exception
            MsgBox(ex.Message.ToString & "error")
        Finally

        End Try
        conn.Close()
        Return resp
    End Function

    Public Function modificar_estadomaquinas(ByVal codigom As String, ByVal db As String) As String
        Dim resp As Integer = 0
        Try
            Dim sql As String = "UPDATE j_maquinas SET Estado = 'A' WHERE codigoM = " & codigom & " "
            Dim objConexion As New Conexion
            Dim comando1 As New System.Data.SqlClient.SqlCommand
            If (db = "CORSAN") Then
                conn = objConexion.abrirConexion
            ElseIf (db = "PRODUCCION") Then
                conn = objConexion.abrirConexion_prod
            End If
            comando1.CommandType = System.Data.CommandType.Text
            comando1.Parameters.Add(codigom, SqlDbType.VarChar).Value = codigom
            comando1.Connection = conn
            comando1.CommandText = sql
            resp = (comando1.ExecuteNonQuery())
        Catch ex As Exception
            MsgBox(ex.Message.ToString & "error")
        Finally

        End Try
        conn.Close()
        Return resp
    End Function
    Public Function modificar_estadomaquinasI(ByVal codigom As String, ByVal db As String) As String
        Dim resp As Integer = 0
        Try
            Dim sql As String = "UPDATE j_maquinas SET Estado = 'I' WHERE codigoM = " & codigom & "  "
            Dim objConexion As New Conexion
            Dim comando1 As New System.Data.SqlClient.SqlCommand
            If (db = "CORSAN") Then
                conn = objConexion.abrirConexion
            ElseIf (db = "PRODUCCION") Then
                conn = objConexion.abrirConexion_prod
            End If
            comando1.CommandType = System.Data.CommandType.Text
            comando1.Parameters.Add(codigom, SqlDbType.VarChar).Value = codigom
            comando1.Connection = conn
            comando1.CommandText = sql
            resp = (comando1.ExecuteNonQuery())
        Catch ex As Exception
            MsgBox(ex.Message.ToString & "error")
        Finally

        End Try
        conn.Close()
        Return resp
    End Function
    Public Function modificar_estadomaquinasP(ByVal codigom As String, ByVal db As String) As String
        Dim resp As Integer = 0
        Try
            Dim sql As String = "UPDATE J_Maquinas SET Estado = 'P' WHERE codigoM = " & codigom & " "
            Dim objConexion As New Conexion
            Dim comando1 As New System.Data.SqlClient.SqlCommand
            If (db = "CORSAN") Then
                conn = objConexion.abrirConexion
            ElseIf (db = "PRODUCCION") Then
                conn = objConexion.abrirConexion_prod
            End If
            comando1.CommandType = System.Data.CommandType.Text
            comando1.Parameters.Add(codigom, SqlDbType.VarChar).Value = codigom
            comando1.Connection = conn
            comando1.CommandText = sql
            resp = (comando1.ExecuteNonQuery())
        Catch ex As Exception
            MsgBox(ex.Message.ToString & "error")
        Finally

        End Try
        conn.Close()
        Return resp
    End Function

    Public Function modificar_estadomaquinasPN(ByVal codigom As String, ByVal paro As String, ByVal db As String) As String
        Dim resp As Integer = 0
        Try
            Dim sql As String = "UPDATE J_Maquinas SET Paro = " & paro & "   WHERE codigoM = " & codigom & " "
            Dim objConexion As New Conexion
            Dim comando1 As New System.Data.SqlClient.SqlCommand
            If (db = "CORSAN") Then
                conn = objConexion.abrirConexion
            ElseIf (db = "PRODUCCION") Then
                conn = objConexion.abrirConexion_prod
            End If

            comando1.CommandType = System.Data.CommandType.Text
            comando1.Parameters.Add(paro, SqlDbType.VarChar).Value = paro
            comando1.Parameters.Add(codigom, SqlDbType.VarChar).Value = codigom
            comando1.Connection = conn
            comando1.CommandText = sql
            resp = (comando1.ExecuteNonQuery())
        Catch ex As Exception
            MsgBox(ex.Message.ToString & "error")
        Finally

        End Try
        conn.Close()
        Return resp
    End Function
    Public Function listaBasesDatos(ByVal sql As String, ByVal db As String, ByVal numCol As Integer) As List(Of Object)
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
            For i = 0 To numCol
                lista_valores.Add(reader(i))
            Next
        End While
        conn.Close()
        Return lista_valores
    End Function
    Public Function crearDataTable(ByVal sql As String, ByVal db As String) As DataTable
        Dim objConexion As New Conexion
        Dim reader As SqlDataReader
        Dim dt As New DataTable
        Dim comando As New SqlCommand
        Dim conn As New SqlConnection
        Dim numCol As Integer = 0
        Dim dr As DataRow
        comando.CommandType = CommandType.Text
        If (db = "CORSAN") Then
            conn = objConexion.abrirConexion
        ElseIf (db = "PRODUCCION") Then
            conn = objConexion.abrirConexion_prod
        End If
        comando.Connection = conn
        comando.CommandText = (sql)
        reader = comando.ExecuteReader
        numCol = reader.FieldCount - 1
        For i = 0 To numCol
            dt.Columns.Add(reader.GetName(i).ToString)
        Next
        While (reader.Read)
            For i = 0 To numCol
                dr = dt.NewRow
                dr(reader.GetName(i).ToString) = reader(i)
                dt.Rows.Add(dr)
            Next
        End While
        conn.Close()
        Return dt
    End Function
    Public Function crearDataTableVariasCol(ByVal sql As String, ByVal db As String) As DataTable
        Dim objConexion As New Conexion
        Dim reader As SqlDataReader
        Dim dt As New DataTable
        Dim comando As New SqlCommand
        Dim conn As New SqlConnection
        Dim dr As DataRow
        Dim numCol As Integer = 0
        comando.CommandType = CommandType.Text
        If (db = "CORSAN") Then
            conn = objConexion.abrirConexion
        ElseIf (db = "PRODUCCION") Then
            conn = objConexion.abrirConexion_prod
        End If
        comando.Connection = conn
        comando.CommandText = (sql)
        reader = comando.ExecuteReader
        numCol = reader.FieldCount - 1
        For i = 0 To numCol
            dt.Columns.Add(reader.GetName(i).ToString)
        Next
        While (reader.Read)
            For i = 0 To numCol
                If (i = 0) Then
                    dr = dt.NewRow
                End If
#Disable Warning BC42104 ' La variable 'dr' se usa antes de que se le haya asignado un valor. Podría darse una excepción de referencia NULL en tiempo de ejecución.
                dr(reader.GetName(i).ToString) = reader(i)
#Enable Warning BC42104 ' La variable 'dr' se usa antes de que se le haya asignado un valor. Podría darse una excepción de referencia NULL en tiempo de ejecución.
                If (i = numCol) Then
                    dt.Rows.Add(dr)
                End If
            Next
        End While
        conn.Close()
        Return dt
    End Function
    Public Function verificar_conexion() As Boolean
        Dim objConexion As New Conexion
        Dim reader As SqlDataReader
        Dim comando As New SqlCommand
        Dim conn As New SqlConnection
        Dim sql As String = "SELECT nit FROM terceros WHERE nit = 890900160"
        If objConexion.verificarConexion Then
            comando.CommandType = CommandType.Text
            conn = objConexion.abrirConexion
            comando.Connection = conn
            comando.CommandText = (sql)
            Try
                reader = comando.ExecuteReader
                conn.Close()
                Return True
            Catch
                Return False
            End Try
        Else
            Return False
        End If
    End Function
    ''autor del metodo: david hincapié
    Public Function eliminarmarcacion(ByVal dts As Integer) As Boolean
        Dim objetoconexion As New Conexion
        Try
            objetoconexion.abrirConexionControl()
            cmd = New SqlCommand("eliminar_marcacion")
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = objetoconexion.abrirConexionControl

            cmd.Parameters.Add("@consecutivo", SqlDbType.NVarChar, 50).Value = dts

            If cmd.ExecuteNonQuery Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try

    End Function
    ''autor del metodo:David hincapié
    Public Function eliminar_alambron_sinasignar(ByVal nit As String, ByVal importacion As Integer, ByVal solicitud As Integer, ByVal rollo As Integer) As Boolean
        Dim objetoconexion As New Conexion
        Try
            objetoconexion.abrirConexion_prod()

            cmd = New SqlCommand("D_borrar_alambron_sin_asignar")
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = objetoconexion.abrirConexion_prod()

            cmd.Parameters.Add("@nit_proveedor", SqlDbType.NVarChar, 50).Value = nit
            cmd.Parameters.Add("@num_importacion", SqlDbType.NVarChar, 50).Value = importacion
            cmd.Parameters.Add("@numero_rollo", SqlDbType.NVarChar, 50).Value = solicitud
            cmd.Parameters.Add("@id_solicitud_det", SqlDbType.NVarChar, 50).Value = rollo


            If cmd.ExecuteNonQuery Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try

    End Function
    Public Function mostrar_estupefa_e_s() As DataTable
        Try
            Dim con As New Conexion
            con.abrirConexion()
            cmd = New SqlCommand("mostrar_estupefaciente_e_s")
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = con.abrirConexion()

            If cmd.ExecuteNonQuery Then
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Return dt

            Else
                Return Nothing

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function mostrar_estupefa_informacion() As DataTable
        Try
            Dim con As New Conexion
            con.abrirConexion()
            cmd = New SqlCommand("mostrar_estupefaciente_infor")
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = con.abrirConexion()

            If cmd.ExecuteNonQuery Then
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Return dt

            Else
                Return Nothing

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function
    Public Function mostrar_compromiso() As DataTable
        Try
            Dim con As New Conexion
            con.abrirConexionControl()
            cmd = New SqlCommand("mostrar_compromiso")
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = con.abrirConexionControl()

            If cmd.ExecuteNonQuery Then
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Return dt

            Else
                Return Nothing

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function
    Public Function mostrar_Sautorizar() As DataTable
        Try
            Dim con As New Conexion
            con.abrirConexion()
            cmd = New SqlCommand("mostrar_Sautorizar")
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = con.abrirConexion()

            If cmd.ExecuteNonQuery Then
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Return dt

            Else
                Return Nothing

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function
    Public Function guardar_imagen(ByVal img() As Byte, ByVal nit As Double) As Boolean
        Dim comando As New SqlCommand
        Dim conn As New SqlConnection
        Dim objConexion As New Conexion
        Dim resp As Boolean = False
        Dim sql, nit_p As String
        Dim sw As Boolean = False
        sql = "select nit from y_personal_contratos where nit=" & nit
        nit_p = consultValorTodo(sql, "CORSAN")
        If nit_p <> "" Then
            sw = True
        End If
        Try
            If sw = True Then
                conn = objConexion.abrirConexion
            Else
                conn = objConexion.abrirConexionControl
            End If
            comando.CommandType = CommandType.Text
            comando.Connection = conn
            With comando
                .CommandType = CommandType.Text
                If sw = True Then
                    .CommandText = "UPDATE y_personal_contratos SET foto = @Imagen WHERE estado = 'A' AND nit =" & nit
                Else
                    .CommandText = "UPDATE J_personal_maquila SET foto = @Imagen WHERE estado = 'A' AND nit =" & nit
                End If
                .Connection = conn
                .Parameters.Add(New SqlParameter("@Imagen", SqlDbType.Image)).Value = img
            End With
            comando.ExecuteNonQuery()
            resp = True
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            comando.Parameters.Clear()
            conn.Close()
        End Try
        Return resp
    End Function
    Public Function ExtraerImagen(ByVal nit As Double) As Byte()
        Dim comando As New SqlCommand
        Dim conn As New SqlConnection
        Dim objConexion As New Conexion
        Dim sql, nit_p As String
        Dim sw As Boolean = False
        sql = "select nit from y_personal_contratos where nit=" & nit
        nit_p = consultValorTodo(sql, "CORSAN")
        If nit_p <> "" Then
            sw = True
        End If
        If sw = True Then
            conn = objConexion.abrirConexion
        Else
            conn = objConexion.abrirConexionControl
        End If
        With comando
            .CommandType = CommandType.Text
            If sw = True Then
                .CommandText = "Select foto From y_personal_contratos Where estado = 'A' AND nit = " & nit
            Else
                .CommandText = "Select foto From J_personal_maquila WHERE estado = 'A' AND nit =" & nit
            End If
            .Connection = conn
        End With
        With conn
            Dim MyPhoto() As Byte = CType(comando.ExecuteScalar(), Byte())
            .Close()
            Return MyPhoto
        End With
    End Function
    Public Function get_nom_db(ByVal db As String) As String
        Dim nombre As String = ""
        Dim objConexion As New Conexion
        If (db = "CORSAN") Then
            conn = objConexion.abrirConexion
        ElseIf (db = "PRODUCCION") Then
            conn = objConexion.abrirConexion_prod
        ElseIf (db = "CONTROL") Then
            conn = objConexion.abrirConexionControl
        End If
        nombre = conn.Database
        conn.Close()
        Return nombre
    End Function
End Class
