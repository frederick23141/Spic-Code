Imports entidadNegocios
Imports accesoDatos
Public Class IngVtasLn
    Private objIngVtasAd As New ingVtasAd

    Public Function clientDisponible(ByVal nit As Integer, ByVal vend As Integer) As Boolean
        Return objIngVtasAd.clientDisponible(nit, vend)
    End Function
    Public Function listarRef(ByVal strSql As String) As DataTable
        Return objIngVtasAd.listarRef(strSql)
    End Function
    Public Function infoCliente(ByVal nit As Integer) As Object()
        Return objIngVtasAd.infoCliente(nit)
    End Function
    Public Function listar_clientes(ByVal strSql As String) As DataTable
        Return objIngVtasAd.listar_clientes(strSql)
    End Function
    Public Function descProd(ByVal ref As String) As String
        Return objIngVtasAd.descProd(ref)
    End Function
    Public Function consec_ult_ped() As Integer
        Return objIngVtasAd.consec_ult_ped()
    End Function
    Public Function precio_min_vta(ByVal cod As String) As Double
        Return objIngVtasAd.precio_min_vta(cod)
    End Function
    Public Function problema(ByVal nit As Double) As String
        Return objIngVtasAd.problema(nit)
    End Function
    Public Function insertar(ByVal Sql As String) As Integer
        Return objIngVtasAd.insertar(Sql)
    End Function
    Public Function get_condicion(ByVal nit As Double) As String
        Return objIngVtasAd.get_condicion(nit)
    End Function
    Public Sub update_consec(ByVal sql As String)
        objIngVtasAd.update_consec(sql)
    End Sub
    Public Function cons_bloqueo(ByVal nit As Double) As Integer
        Return objIngVtasAd.cons_bloqueo(nit)
    End Function
    Public Function ingresar_no_reflej(ByVal numero As Double, ByVal notas_aut As String) As Integer
        Return objIngVtasAd.ingresar_no_reflej(numero, notas_aut)
    End Function
    Public Function anular_no_reflej(ByVal numero As Integer) As Integer
        Return objIngVtasAd.anular_no_reflej(numero)
    End Function
    Public Function listarDatos(ByVal sql As String) As DataTable
        Return objIngVtasAd.listarDatos(sql)
    End Function
    Public Function listar_info_ptes(ByVal sql As String) As DataTable
        Return objIngVtasAd.listar_info_ptes(sql)
    End Function
    Public Function listar_ptes_problema(ByVal sql As String) As DataTable
        Return objIngVtasAd.listar_ptes_problema(sql)
    End Function
    Public Function vr_total_problem(ByVal min As Integer, ByVal max As Integer) As Integer
        Return objIngVtasAd.vr_total_problem(min, max)
    End Function
    Public Function existeFact(ByVal nit As Double, ByVal numero As Double) As Boolean
        Return objIngVtasAd.existeFact(nit, numero)
    End Function
    Public Function existePedido(ByVal nit As Double, ByVal numero As Double) As Boolean
        Return objIngVtasAd.existePedido(nit, numero)
    End Function
End Class
