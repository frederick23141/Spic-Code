Imports System.Data.SqlClient
Imports entidadNegocios
Public Class Entrada_usuarioAd
    Inherits Conexion
    Dim cmd As SqlCommand
    Public Function insertar(ByVal dts As entradausuarioEn) As Boolean
        Try
            abrirConexionControl()
            cmd = New SqlCommand("D_insertar_empleado")
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = abrirConexionControl()

            cmd.Parameters.AddWithValue("@consecutivo", dts.gconsecutivo)
            cmd.Parameters.AddWithValue("@nit", dts.gnit)
            cmd.Parameters.AddWithValue("@fecha_entrada", dts.gfecha_entrada)
            cmd.Parameters.AddWithValue("@fecha_salida", dts.gfecha_salida)
            cmd.Parameters.AddWithValue("@notas", dts.gnotas)
            cmd.Parameters.AddWithValue("@permiso", dts.gpermiso)
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
    Public Function generar_consecutivo()
        Try
            Dim cont As Integer
            abrirConexionControl()
            cmd = New SqlCommand("D_generar_consecutivo")
            cmd.CommandType = CommandType.StoredProcedure


            cmd.Connection = abrirConexionControl()

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