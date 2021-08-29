Imports accesoDatos
Public Class Audit_invLn
    Dim objAudit_inv As New Audit_invAd
    Public Function listarBusqueda(ByVal cod As String, ByVal bodega As Integer) As DataTable
        Return objAudit_inv.listarBusqueda(cod, bodega)
    End Function

End Class
