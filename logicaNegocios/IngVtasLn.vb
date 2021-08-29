Imports entidadNegocios
Imports accesoDatos
Public Class IngVtasLn
    Private objIngVtasAd As New ingVtasAd
    Private objOp_simplesAd As New Op_simplesAd

    Public Function clientDisponible(ByVal nit As Long, ByVal vend As Double) As Boolean
        Return objIngVtasAd.clientDisponible(nit, vend)
    End Function
    Public Function listarRef(ByVal strSql As String) As DataTable
        Return objIngVtasAd.listarRef(strSql)
    End Function
    Public Function infoCliente(ByVal nit As Double) As Object()
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
    Public Function costoProducto(ByVal cod As String) As Double
        Return objIngVtasAd.costoProducto(cod)
    End Function
    Public Function precio_lista(ByVal cod As String, ByVal lista As String) As Double
        Return objIngVtasAd.precio_lista(cod, lista)
    End Function
    Public Function precio_min_vta(ByVal cod As String) As Double
        Return objIngVtasAd.precio_min_vta(cod)
    End Function
    Public Function doc_ven(ByVal nit As Double) As String
        Return objIngVtasAd.doc_ven(nit)
    End Function
    Public Function insertar(ByVal Sql As String) As Integer
        Return objIngVtasAd.insertar(Sql)
    End Function
    Public Function get_condicion(ByVal nit As Double) As String
        Return objIngVtasAd.get_condicion(nit)
    End Function
    Public Function update(ByVal sql As String) As Integer
        Return objIngVtasAd.update(sql)
    End Function
    Public Sub eliminar(ByVal sql As String)
        objIngVtasAd.eliminar(sql)
    End Sub
    Public Function cons_bloqueo(ByVal nit As Double) As Integer
        Return objIngVtasAd.cons_bloqueo(nit)
    End Function
    Public Function ingresar_no_reflej(ByVal numero As Double, ByVal notas_aut As String) As Boolean
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
    Public Function existeConsecutivo(ByVal numero As Double) As Boolean
        Return objIngVtasAd.existeConsecutivo(numero)
    End Function
    Public Function mov_180_dias(ByVal nit As Double) As Boolean
        Return objIngVtasAd.mov_180_dias(nit)
    End Function
    Public Function esNuevo(ByVal nit As Double) As Boolean
        Dim fechaCrea As Date
        Dim fechaCorte As Date = Now.AddMonths(-4)
        Dim sql As String = "SELECT fecha_creacion   " & _
                                "FROM terceros  " & _
                                    "WHERE nit = " & nit
        fechaCrea = objOp_simplesAd.consultValor(sql)
        If (fechaCrea >= fechaCorte) Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Function doc_venc_mas_30(ByVal nit As Double) As Boolean
        Dim sql As String = "SELECT     nit FROM  V_Doc_Vencidos where Dias_Vencido >30 and Nit = " & nit & ""
        If (objOp_simplesAd.consultValor(sql) <> "") Then
            Return True
        Else
            Return False
        End If
    End Function
End Class
