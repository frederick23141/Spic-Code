Imports accesoDatos

Public Class UsuarioLn
    Private objOpSimplesAd As New Op_simplesAd

    Public Function coordinadorVend(ByVal usuario As String) As String
        Dim sVendedores As String = ""
        Dim listUsuarios As List(Of Object)
        Dim sql As String = "SELECT vendedor FROM J_spic_coord_vend WHERE usuario ='" & usuario & "'"
        listUsuarios = objOpSimplesAd.lista(sql)
        For i = 0 To listUsuarios.Count - 1
            sVendedores &= Convert.ToString(listUsuarios(i))
            If (i <> listUsuarios.Count - 1) Then
                sVendedores += ","
            End If
        Next
        Return sVendedores
    End Function

End Class
