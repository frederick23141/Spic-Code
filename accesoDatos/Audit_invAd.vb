Imports System.Data.SqlClient
Imports System.Data
Public Class Audit_invAd
    Public Function listarBusqueda(ByVal cod As String, ByVal bodega As Integer) As DataTable
        Dim conn As New SqlConnection
        Dim objConexion As New Conexion
        conn = objConexion.abrirConexion
        Dim sql As String = "SELECT sto.bodega ,sto.codigo,sto.descripcion,sto.stock,SUM(sto.can_ent)As Entradas,SUM(sto.can_sal  )As Salidas,(Select MAX (fec) from  documentos_lin where codigo = sto.codigo  AND sw = 11)As ult_entrada,(Select MAX (fec) from  documentos_lin where codigo = sto.codigo  AND sw = 12 AND bodega = sto.bodega)As ult_salida , (Select MAX (fec) from  documentos_lin where codigo = sto.codigo  AND sw = 1 and bodega = sto.bodega)As ult_vta " & _
                                "FROM v_referencias_sto_hoy sto " & _
                                        "WHERE sto.codigo like '" & cod & "%' AND sto.bodega= " & bodega & "  AND sto.stock>0.5   " & _
                                                "GROUP BY sto.bodega ,sto.codigo,sto.descripcion,sto.stock  "
        Dim dt As New DataTable
        Dim DA As New SqlDataAdapter(sql, conn)
        DA.Fill(dt)
        Return dt
    End Function
End Class
