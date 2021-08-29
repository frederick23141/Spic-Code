Imports entidadNegocios
Imports accesoDatos
Public Class LoginLn
    '****************************************************************************************************************
    'Se crean las instancias de las clases necesarias****************************************************************
    '****************************************************************************************************************
    Private objLoginAd As loginAd

    Public Sub New()
        objLoginAd = New loginAd
    End Sub

    Public Function tipoUsuario(ByVal usuario As String, ByVal contra As String) As UsuarioEn
        Return objLoginAd.tipoUsuario(usuario, contra)
    End Function
    Public Function insertarUsuario(ByVal usuario As UsuarioEn) As Integer
        Return objLoginAd.insertarUsuario(usuario)
    End Function
    Public Function listar_clientes(ByVal strSql As String) As DataTable
        Return objLoginAd.listar_usuarios(strSql)
    End Function
    Public Function eliminarUsuario(ByVal usuario As String) As Integer
        Return objLoginAd.eliminarUsuario(usuario)
    End Function
    Public Function mod_usuario(ByVal usuario As UsuarioEn) As Integer
        Return objLoginAd.mod_usuario(usuario)
    End Function
    Public Function obtenerEmail(ByVal vendedor As Integer) As String
        Return objLoginAd.obtenerEmail(vendedor)
    End Function
    Public Function existeUsuario(ByVal usuario As String) As Boolean
        Return objLoginAd.existeUsuario(usuario)
    End Function

End Class
