Imports System.Data.SqlClient
Imports System.Data
Imports entidadNegocios
Public Class Gestion_ped_Ad
    Private conn As New SqlConnection
    Private comando As SqlCommand
    Dim objConexion As New Conexion

    Public Function listar_ped() As DataTable
        conn = objConexion.abrirConexion
        Dim dt As New DataTable
        Dim sql As String = "SELECT " & _
                                        " doc.sw, doc.bodega,doc.numero, doc.nit,ter.nombres ,doc.vendedor,doc.fecha, doc.condicion,doc.dias_validez, doc.descuento_pie, " & _
                                        " doc.valor_total, doc.fecha_hora, doc.usuario, doc.pc, doc.anulado" & _
                                        " FROM JJV_documentos_ped doc ,terceros ter  where doc.anulado =0 and doc.nit= ter.nit "
        Dim DA As New SqlDataAdapter(sql, conn)
        DA.Fill(dt)
        conn.Close()
        Return dt
    End Function
    Public Function anular_ped(ByVal numero As Integer) As Integer
        Dim resp As Integer = 0
        Try
            conn = objConexion.abrirConexion
            Dim comando1 As New System.Data.SqlClient.SqlCommand
            comando1.CommandType = System.Data.CommandType.Text
            comando1.Connection = conn
            Dim stringSql As String = "UPDATE JJV_documentos_ped SET anulado =  1 where numero = " & numero
            comando1.CommandText = stringSql
            resp = comando1.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message.ToString & "error")
            MsgBox("Error desde el updatre de autorizar")
        Finally
        End Try
        conn.Close()
        Return resp
    End Function


End Class
