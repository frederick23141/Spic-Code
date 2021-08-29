Imports System.Data.SqlClient
Imports System.Data
Imports entidadNegocios
'****************************************************************************************************************
'Se crean los parametros para la conexion ***********************************************************************
'****************************************************************************************************************
Public Class DespachoAd
    Private conn As New SqlConnection
    Private comando As New SqlCommand
    Private errores As String
    Dim objConexion As New Conexion
    '****************************************************************************************************************
    'Se listan los resultados de el Nit de el cliente para sus despachos*********************************************
    '****************************************************************************************************************
    Public Function listarDespacho(ByVal nit As Double, ByVal fecha As String) As DataTable
        conn = objConexion.abrirConexion
        Dim sql As String = "Select d.tipo,d.numero,d.fec,d.codigo,r.descripcion,Pedida=d.cantidad_pedida,Despa=d.cantidad,Pendte=d.cantidad_pedida-d.cantidad,d.valor_unitario,Despacho=p.numero,Conductor=v.nombre_vendedor,hora_salida=y.fecha_hora_salida,hora_Llegada=y.fecha_hora_llegada FROM documentos_lin d,referencias r,terceros t,documentos e LEFT JOIN documentos_despachos p ON e.tipo=p.tipo_desp and e.numero=p.numero_desp LEFT JOIN documentos_desp_enc y ON p.numero=y.numero LEFT JOIN v_vendedores v ON p.nit=v.vendedor WHERE d.codigo=r.codigo and d.nit=t.nit and d.tipo=e.tipo and d.numero=e.numero and e.nit= " & nit & " and fec >= '" & fecha & " ' ORDER BY d.fec DESC,d.tipo,d.numero DESC "
        Dim dt As New DataTable
        Try
            Dim DA As New SqlDataAdapter(sql, conn)
            DA.Fill(dt)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        conn.Close()
        Return dt
    End Function
End Class
