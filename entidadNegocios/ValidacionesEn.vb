Public Class ValidacionesEn
    Private errores As String

    Public Function validarNumero(ByVal numero As Integer) As String
        If Not IsNumeric(numero) Then
            errores = "ingrese solo caracteres númericos"
        End If
        Return errores
    End Function
   

End Class
