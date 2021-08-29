Public Class Gestion_materia_primaLn
    Public Function extraerDatoCodigoBarras(ByVal dato As String, ByVal codigoBarra As String) As String
        Dim numSeparador As Integer = 0
        Dim contSeparador As Integer = 0
        Dim respuesta As String = ""
        Select Case dato
            Case "num_consecutivo"
                numSeparador = 0
            Case "detalle"
                numSeparador = 1
            Case "id_rollo"
                numSeparador = 2
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
    Public Function extraerDatoCodigoBarrasRecocido(ByVal dato As String, ByVal codigoBarra As String) As String
        Dim numSeparador As Integer = 0
        Dim contSeparador As Integer = 0
        Dim respuesta As String = ""
        Select Case dato
            Case "nro_orden"
                numSeparador = 0
            Case "id_detalle"
                numSeparador = 1
            Case "id_rollo"
                numSeparador = 2
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
    Public Function extraerDatoCodigoBarrasGalvanizado(ByVal dato As String, ByVal codigoBarra As String) As String
        Dim numSeparador As Integer = 0
        Dim contSeparador As Integer = 0
        Dim respuesta As String = ""
        Select Case dato
            Case "nro_orden"
                numSeparador = 0
            Case "id_rollo"
                numSeparador = 1
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
    Public Function extraerDatoCodigoBarrasPuntilleria(ByVal dato As String, ByVal codigoBarra As String) As String
        Dim numSeparador As Integer = 0
        Dim contSeparador As Integer = 0
        Dim respuesta As String = ""
        Select Case dato
            Case "oden_produccion"
                numSeparador = 0
            Case "id_rollo"
                numSeparador = 1
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


    Public Function extraerMinMax(ByVal dato As String, ByVal resistencia As String) As String
        Dim numSeparador As Integer = 0
        Dim contSeparador As Integer = 0
        Dim respuesta As String = ""
        Select Case dato
            Case "min"
                numSeparador = 0
            Case "max"
                numSeparador = 1
        End Select
        For i = 0 To resistencia.Length - 1
            If (numSeparador = contSeparador) Then
                If (resistencia(i) <> "-") Then
                    respuesta &= resistencia(i)
                End If
            End If
            If (resistencia(i) = "-") Then
                contSeparador += 1
            End If
        Next
        Return respuesta
    End Function
End Class
