Imports System.Data.SqlClient
Imports System.Data
Imports entidadNegocios
Public Class anticipoAd
    Dim objConexion As New Conexion
    Public Function listar_anticipo(ByVal fecIni As String, ByVal fecFin As String, ByVal vendmin As Integer, ByVal vendMax As Integer, ByVal condicion As String) As DataTable
        Dim conn As New SqlConnection
        conn = objConexion.abrirConexion
        Dim dt As New DataTable
        Dim sql As String = "SELECT doc.vendedor ,doc.sw,doc.tipo,doc.numero,doc.nit,ter.nombres,ter.condicion,YEAR(doc.fecha) AS 'AÑO',MONTH(doc.fecha) AS 'MES',doc.fecha,doc.valor_total,doc.valor_aplicado,(doc.valor_total - doc.valor_aplicado ) as Saldo,(SELECT SUM (pend.Vr_total )FROM J_v_pend_vend pend WHERE pend.nit = doc.nit )As Pendientes " & _
                                    "FROM documentos doc ,terceros ter " & _
                                            "WHERE ter.nit= doc.nit AND doc.sw Like '5' AND doc.vendedor >=" & vendmin & " and doc.vendedor <= " & vendMax & " " & condicion & " " & condicion & " AND doc.tipo IN ('RCR1','RCO1','RCEX') AND  doc.fecha>='" & fecIni & "' AND  doc.fecha<='" & fecFin & "' AND(doc.valor_total>doc.valor_aplicado or (doc.iva_fletes <0   AND doc.valor_total=doc.valor_aplicado)) " & _
                                                    "ORDER BY doc.vendedor"
        Dim DA As New SqlDataAdapter(sql, conn)
        DA.Fill(dt)
        conn.Close()
        Return dt
    End Function
    Public Function consolidar_anticipo(ByVal fecIni As String, ByVal fecFin As String, ByVal vendmin As Integer, ByVal vendMax As Integer, ByVal condicion As String) As DataTable
        Dim conn As New SqlConnection
        conn = objConexion.abrirConexion
        Dim dt As New DataTable
        Dim sql As String = "SELECT doc.vendedor ,SUM(doc.valor_total)As vrTotal,SUM(doc.valor_aplicado)As vrAplicado,SUM((doc.valor_total - doc.valor_aplicado )) as Saldo " & _
                                       "FROM documentos doc ,terceros ter " & _
                                        "WHERE ter.nit= doc.nit AND doc.sw Like '5' AND doc.vendedor >=" & vendmin & " and doc.vendedor <= " & vendMax & " " & condicion & " AND doc.tipo IN ('RCR1','RCO1','RCEX') AND  doc.fecha>='" & fecIni & "' AND  doc.fecha<='" & fecFin & "' AND(doc.valor_total>doc.valor_aplicado or (doc.iva_fletes <0   AND doc.valor_total=doc.valor_aplicado))  " & _
                                         "GROUP BY doc.vendedor,doc.vendedor  "
        Dim DA As New SqlDataAdapter(sql, conn)
        DA.Fill(dt)
        conn.Close()
        Return dt
    End Function
    Public Function listar_anticipo_nomb(ByVal vendmin As Integer, ByVal vendMax As Integer, ByVal nombre As String, ByVal condicion As String) As DataTable
        Dim conn As New SqlConnection
        conn = objConexion.abrirConexion
        Dim dt As New DataTable
        Dim sql As String = "SELECT doc.vendedor ,doc.sw,doc.tipo,doc.numero,doc.nit,ter.nombres,YEAR(doc.fecha) AS 'AÑO',MONTH(doc.fecha) AS 'MES',doc.fecha,doc.valor_total,doc.valor_aplicado,doc.valor_total - doc.valor_aplicado as 'SALDO' " & _
                                    "FROM documentos doc ,terceros ter " & _
                                            "WHERE  (doc.sw Like '5') " & condicion & " AND (doc.tipo='RCR1') AND ((doc.valor_total>doc.valor_aplicado) or doc.iva_fletes<0 )AND YEAR(doc.fecha)=" & Now.Year - 2 & "  and doc.tipo IN ('RCR1','RCO1','RCEX') and doc.valor_total=doc.valor_aplicado  and doc.vendedor >= " & vendmin & " and doc.vendedor  <= " & vendMax & " and ter.nit = doc.nit and ter.nombres like '%" & nombre & "%' " & _
                                                    "ORDER BY doc.vendedor"
        Dim DA As New SqlDataAdapter(sql, conn)
        DA.Fill(dt)
        conn.Close()
        Return dt
    End Function
    Public Function listar_anticipo_nit(ByVal vendmin As Integer, ByVal vendMax As Integer, ByVal nit As Double, ByVal condicion As String) As DataTable
        Dim conn As New SqlConnection
        conn = objConexion.abrirConexion
        Dim dt As New DataTable
        Dim sql As String = "SELECT doc.vendedor ,doc.sw,doc.tipo,doc.numero,doc.nit,ter.nombres,YEAR(doc.fecha) AS 'AÑO',MONTH(doc.fecha) AS 'MES',doc.fecha,doc.valor_total,doc.valor_aplicado,doc.valor_total - doc.valor_aplicado as 'SALDO' " & _
                                    "FROM documentos doc ,terceros ter " & _
                                            "WHERE  (doc.sw Like '5') AND (doc.tipo='RCR1') " & condicion & " AND ((doc.valor_total>doc.valor_aplicado) or doc.iva_fletes<0 )AND YEAR(doc.fecha)>" & Now.Year - 2 & " and doc.tipo IN ('RCR1','RCO1','RCEX') and doc.valor_total=doc.valor_aplicado  and doc.vendedor >= " & vendmin & " and doc.vendedor  <= " & vendMax & " and ter.nit = doc.nit and doc.nit like '%" & nit & "%' " & _
                                                    "ORDER BY doc.vendedor"
        Dim DA As New SqlDataAdapter(sql, conn)
        DA.Fill(dt)
        conn.Close()
        Return dt
    End Function


End Class
