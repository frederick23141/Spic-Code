Imports System.Data.SqlClient
Imports System.Data
Imports entidadNegocios
Public Class loginAd
    '****************************************************************************************************************
    'Se crean los parametros para la conexion ***********************************************************************
    '****************************************************************************************************************



    Private objUsuarioEn As New UsuarioEn
    Public Function existeUsuario(ByVal usuario As String) As Boolean
        Dim comando As New SqlCommand
        Dim conn As New SqlConnection
        Dim objConexion As New Conexion
        Dim reader As SqlDataReader
        Dim resp As Boolean = False
        comando.CommandType = CommandType.Text
        conn = objConexion.abrirConexion
        comando.Connection = conn
        comando.CommandText = "select Usuario  " & _
                                    " from Jjv_usuarios  " & _
                                            " where usuario = '" & usuario & "'"
        reader = comando.ExecuteReader
        While (reader.Read)
            resp = True

        End While
        conn.Close()
        Return resp
    End Function
    Public Function tipoUsuario(ByVal usuario As String, ByVal contra As String) As UsuarioEn
        Dim comando As New SqlCommand
        Dim conn As New SqlConnection
        Dim objConexion As New Conexion
        Dim reader As SqlDataReader
        Dim tipo As String = ""
        comando.CommandType = CommandType.Text
        conn = objConexion.abrirConexion
        comando.Connection = conn
        comando.CommandText = "select Autorizacion,Mail,Mail_login,nombres,bodega,vendedor,Nombres ,Usuario,cargo,nit " & _
                                    " from Jjv_usuarios  " & _
                                            " where usuario = '" & usuario & "' and Login='" & contra & "'"
        reader = comando.ExecuteReader
        While (reader.Read)
            If IsDBNull(reader(0)) Then
            Else
                objUsuarioEn.permiso = reader(0)
                objUsuarioEn.nombre = reader(3)
                objUsuarioEn.Vendedor = reader(5)
                objUsuarioEn.bodega = reader(4)
                objUsuarioEn.nombresCompleto = reader("Nombres")
                objUsuarioEn.usuario = reader("Usuario")
                If Not (IsDBNull(reader("cargo"))) Then
                    objUsuarioEn.cargo = reader("cargo")
                Else
                    objUsuarioEn.cargo = ""
                End If
                If Not (IsDBNull(reader(2))) Then
                    objUsuarioEn.Email = reader(1)
                    objUsuarioEn.EmailClave = reader(2)
                End If
                If Not (IsDBNull(reader("nit"))) Then
                    objUsuarioEn.nit = reader("nit")
                End If
            End If

        End While
        conn.Close()
        Return objUsuarioEn
    End Function
    Public Function insertarUsuario(ByVal usuario As UsuarioEn) As Integer
        Dim comando As New SqlCommand
        Dim conn As New SqlConnection
        Dim resp As Integer = 0
        Dim objConexion As New Conexion
        Try
            conn = objConexion.abrirConexion
            Dim comando1 As New System.Data.SqlClient.SqlCommand
            comando1.CommandType = System.Data.CommandType.Text
            comando1.Connection = conn

            Dim stringSql As String = "insert into Jjv_usuarios (Usuario ,Login ,Autorizacion,Vendedor,Mail,Mail_login,Nombres,bodega,cargo,nit ) " & _
                                            " values ('" & usuario.nombre & "','" & usuario.clave & "','" & usuario.permiso & "'," & usuario.Vendedor & ",'" & usuario.Email & "','" & usuario.EmailClave & "','" & usuario.nombresCompleto & "', " & usuario.bodega & "," & usuario.cargo & "," & usuario.nit & ")"
            comando1.CommandText = stringSql
            resp = comando1.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox(ex.Message.ToString & "error")
        Finally

        End Try
        conn.Close()
        Return resp
    End Function
    Public Function listar_usuarios(ByVal strSQL As String) As DataTable
        Dim comando As New SqlCommand
        Dim conn As New SqlConnection
        Dim objConexion As New Conexion
        conn = objConexion.abrirConexion
        Dim dt As New DataTable
        Dim DA As New SqlDataAdapter(strSQL, conn)
        DA.Fill(dt)
        conn.Close()
        Return dt
    End Function
    Public Function eliminarUsuario(ByVal usuario As String) As Integer
        Dim comando As New SqlCommand
        Dim conn As New SqlConnection
        Dim objConexion As New Conexion
        Dim resp As Integer = 0
        conn = objConexion.abrirConexion
        Dim comando1 As New System.Data.SqlClient.SqlCommand
        comando1.CommandType = System.Data.CommandType.Text
        comando1.Connection = conn
        Dim stringSql As String = "delete from Jjv_usuarios where Usuario = '" & usuario & "'"
        comando1.CommandText = stringSql
        resp = comando1.ExecuteNonQuery()
        conn.Close()
        Return resp
    End Function
    Public Function mod_usuario(ByVal usuario As UsuarioEn) As Integer
        Dim comando As New SqlCommand
        Dim conn As New SqlConnection
        Dim objConexion As New Conexion
        Dim resp As Integer = 0
        Try
            conn = objConexion.abrirConexion
            Dim comando1 As New System.Data.SqlClient.SqlCommand
            comando1.CommandType = System.Data.CommandType.Text
            comando1.Connection = conn
            comando1.Parameters.Add("@nombres", SqlDbType.VarChar).Value = usuario.nombresCompleto
            comando1.Parameters.Add("@mail", SqlDbType.VarChar).Value = usuario.Email
            comando1.Parameters.Add("@vendedor", SqlDbType.Int).Value = usuario.Vendedor
            comando1.Parameters.Add("@bodega", SqlDbType.Int).Value = usuario.bodega
            comando1.Parameters.Add("@aut", SqlDbType.VarChar).Value = usuario.permiso
            comando1.Parameters.Add("@usuario", SqlDbType.VarChar).Value = usuario.nombre
            comando1.Parameters.Add("@clave", SqlDbType.VarChar).Value = usuario.clave
            comando1.Parameters.Add("@clave_correo", SqlDbType.VarChar).Value = usuario.EmailClave
            comando1.Parameters.Add("@cargo", SqlDbType.VarChar).Value = usuario.cargo
            comando1.Parameters.Add("@nit", SqlDbType.VarChar).Value = usuario.nit
            'Usuario ,Login ,Autorizacion,Vendedor,Mail,Mail_login,Nombres,bodega

            Dim stringSql As String = "UPDATE Jjv_usuarios SET Nombres = @nombres,Mail= @mail , Vendedor= @vendedor, bodega= @bodega ,Autorizacion= @aut ,Login = @clave,Mail_login=@clave_correo,cargo = @cargo,nit = @nit   where Usuario = @usuario"
            comando1.CommandText = stringSql
            resp = comando1.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message.ToString & "error")
            MsgBox("Error desde el update de autorizar")
        Finally
        End Try
        conn.Close()
        Return resp
    End Function
    Public Function obtenerEmail(ByVal vendedor As Integer) As String
        Dim comando As New SqlCommand
        Dim conn As New SqlConnection
        Dim objConexion As New Conexion
        Dim mail As String = ""
        Dim reader As SqlDataReader
        Try
            comando.CommandType = CommandType.Text
            conn = objConexion.abrirConexion
            comando.Connection = conn
            Dim stringSql As String = ""
            stringSql = "select Mail  from Jjv_usuarios where Vendedor = " & vendedor
            comando.CommandText = stringSql
            reader = comando.ExecuteReader
            While (reader.Read)
                If IsDBNull(reader(0)) Then
                Else
                    mail = reader("Mail")
                End If
            End While
        Catch ex As Exception
            MsgBox(ex.Message.ToString & "error")
        Finally

        End Try
        conn.Close()
        Return mail
    End Function

End Class
