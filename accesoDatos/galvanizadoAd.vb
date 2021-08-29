Imports System.Data.SqlClient
Imports entidadNegocios
Public Class galvanizadoAd
    'Autor david hincapie
    'metodos utilizados por la ventana galvanizado y por todas sus subventanas para comunicarse con la base de datos
    Inherits Conexion
    Dim cmd As SqlCommand
    Public Function mostrar()
        Try
            abrirConexion()
            cmd = New SqlCommand("select codigo,descripcion from referencias where ref_anulada='n' and capa is not null")
            cmd.CommandType = CommandType.Text
            cmd.Connection = abrirConexion()
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
    Public Function mostrar_rollosguardados()
        Try
            abrirConexion_prod()
            cmd = New SqlCommand("select id,codigo_rollo,descripcion,peso,fecha,defecto,capa from D_aux_rollos_galvanizado")
            cmd.CommandType = CommandType.Text
            cmd.Connection = abrirConexion_prod()
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

    Public Function Agregar_rollo(ByVal dts As galvanizadoEn) As Boolean
        Try
            abrirConexion_prod()

            cmd = New SqlCommand("insertar_rollo_galvanizado")
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = abrirConexion_prod()
            cmd.Parameters.AddWithValue("@codigo_rollo", dts.gcodigo_rollo)
            cmd.Parameters.AddWithValue("@descripcion", dts.gdescripcion)
            cmd.Parameters.AddWithValue("@idoperador", dts.gidoperador)
            cmd.Parameters.AddWithValue("@peso", dts.gpeso)
            cmd.Parameters.AddWithValue("@defecto", dts.gdefecto)
            cmd.Parameters.AddWithValue("@capa", dts.gcapa)
            cmd.Parameters.AddWithValue("@bobina", dts.gbobina)

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
End Class
