Imports accesoDatos
Public Class nominaLn
    Private objNominaAd As New nominaAd
    Private objOp_simplesAd As New Op_simplesAd
    Private Function llenarFilasCriterios(ByVal fecIni As String, ByVal fecFin As String, ByVal nit As Double)
        Dim dtGral As New DataTable
        dtGral.Columns.Add("DESCRIPCION")
        dtGral.Rows.Add()
        dtGral.Rows(0).Item("DESCRIPCION") = "TOT/PERSONAL"
        dtGral.Rows.Add()
        dtGral.Rows(1).Item("DESCRIPCION") = "DÍAS HABILES"
        dtGral.Rows.Add()
        dtGral.Rows(2).Item("DESCRIPCION") = "HORAS HABILES"
        dtGral.Rows.Add()
        dtGral.Rows(3).Item("DESCRIPCION") = "TOT DÍAS PRODUCTIVOS"
        dtGral.Rows.Add()
        dtGral.Rows(4).Item("DESCRIPCION") = "TOT HORAS PRODUCTIVAS"
        dtGral.Rows.Add()
        dtGral.Rows(5).Item("DESCRIPCION") = "TOT DÍAS AUSENTISMO"
        dtGral.Rows.Add()
        dtGral.Rows(6).Item("DESCRIPCION") = "TOT HORAS AUSENTISMO"
        dtGral.Rows.Add()
        dtGral.Rows(7).Item("DESCRIPCION") = "PRODUCCION vs AUSENTISMO"
        dtGral.Rows.Add()


        'Return dt
#Disable Warning BC42105 ' La función 'llenarFilasCriterios' no devuelve un valor en todas las rutas de acceso de código. Puede producirse una excepción de referencia NULL en tiempo de ejecución cuando se use el resultado.
    End Function
#Enable Warning BC42105 ' La función 'llenarFilasCriterios' no devuelve un valor en todas las rutas de acceso de código. Puede producirse una excepción de referencia NULL en tiempo de ejecución cuando se use el resultado.
End Class
