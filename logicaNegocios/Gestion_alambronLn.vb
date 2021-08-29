Imports accesoDatos
Public Class Gestion_alambronLn
    Public Function extraerDatoCodigoBarras(ByVal dato As String, ByVal codigoBarra As String) As String
        Dim numSeparador As Integer = 0
        Dim contSeparador As Integer = 0
        Dim respuesta As String = ""
        Select Case dato
            Case "proveedor"
                numSeparador = 0
            Case "num_importacion"
                numSeparador = 1
            Case "detalle"
                numSeparador = 2
            Case "num_rollo"
                numSeparador = 3
        End Select
        For i = 0 To codigoBarra.Length - 1
            If (numSeparador = contSeparador) Then
                If (codigoBarra(i) <> "-") Then
                    respuesta &= codigoBarra(i)
                End If
            End If
            If (codigoBarra(i) = "-") Then
                contSeparador += 1
            End If
        Next
        Return respuesta
    End Function
End Class
