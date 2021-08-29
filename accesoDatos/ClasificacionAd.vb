Imports System.Data.SqlClient
Imports entidadNegocios
'@autor de la clase:david hincapie
'En esta clase esta el metodo mostrar que invoca a un procedimiento que muestra la consulta en un data grid view
' y tambien el metodo editar que invoca al procedimiento editar_linea que permite modificar la linea de produccion de un producto seleeccionado
'El metodo contar registros invoca un procedimiento que trae el numero de resgistros de una consulta en este caso de los productos sin clasificacion
Public Class ClasificacionAd
    Inherits Conexion
    Dim cmd As SqlCommand

    Public Function mostrar() As DataTable

        Try
            abrirConexion()
            cmd = New SqlCommand("D_mostrar_productos")
            cmd.CommandType = CommandType.StoredProcedure

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

    Public Function mostrarsinclasificacion() As DataTable

        Try
            abrirConexion()
            cmd = New SqlCommand("D_productos_sinclasificar")
            cmd.CommandType = CommandType.StoredProcedure

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
    Public Function editar(ByVal dts As vlinea) As Boolean
        Try
            abrirConexion()
            cmd = New SqlCommand("D_editar_linea")
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = abrirConexion()
            cmd.Parameters.AddWithValue("@codigo", dts.gcodigo)
            cmd.Parameters.AddWithValue("@linea", dts.glinea)
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
    Public Function contarregistros()
        Try
            Dim cont As Integer
            abrirConexion()
            cmd = New SqlCommand("D_contar_sinclasificar")
            cmd.CommandType = CommandType.StoredProcedure


            cmd.Connection = abrirConexion()

            If cmd.ExecuteNonQuery Then
                cont = cmd.ExecuteScalar
                Return cont
            Else
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try

    End Function
End Class
