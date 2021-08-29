Imports logicaNegocios
Imports entidadNegocios
Public Class FrmAutorizar

    Private nomUsuario As String
    Private numeroPed As Integer
    Private vendedor As Integer = 0
    Private mailEnvia As String = ""
    Private mailEnviaPass As String = ""
    Private nombre_cliente As String = ""

    Private objAnalisisPresLn As AnalisisLn
    Private objIngVtasLn As New IngVtasLn
    Private tipoGestion As String = ""
    Private objEnvCorreoLN As New EnvCorreoLN
    Private objLoginLn As New LoginLn

    ''centramos la pantalla
    Private Sub FrmAutorizar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
        objAnalisisPresLn = New AnalisisLn
    End Sub

    ''iniciamos variables de los objetos
    Public Sub inicializarVar(ByVal numero As Integer, ByVal tipo As String, ByVal vend As Integer, ByVal objUsuarioEn As UsuarioEn, ByVal nombre_cli As String)
        numeroPed = numero
        nomUsuario = objUsuarioEn.nombresCompleto
        tipoGestion = tipo
        vendedor = vend
        nombre_cliente = nombre_cli
        mailEnvia = objUsuarioEn.Email
        mailEnviaPass = objUsuarioEn.EmailClave
    End Sub

    ''se guardan los datos para enviar a los vendedores. del frm autorizar
    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If validaciones() Then
            Dim resp As Integer = 0
            Dim usuario As String = nomUsuario
            Dim contenido As String = ""
            Dim notas As String = txtNota.Text & "       Gestionado por: " & nomUsuario & "  Fecha:" & Now.Date
            Dim titulo As String = "El pediddo numero " & numeroPed & " del cliente " & nombre_cliente & " ha sido autorizado!"
            Dim mailDestino As String = ""
            If (vendedor = 1020) Then
                mailDestino = "andrea.gonzalez@corsan.com.co"
            Else
                mailDestino = objLoginLn.obtenerEmail(vendedor)
            End If
            'mailDestino = "jorge.escobar@corsan.com.co"
            If (tipoGestion = "no_reflej") Then

                If (objIngVtasLn.ingresar_no_reflej(numeroPed, notas) = True) Then
                    objIngVtasLn.anular_no_reflej(numeroPed)
                    MessageBox.Show("Pedido se autorizo en forma correcta!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    FrmAnalisisPedido.dtg_no_reflejados.CurrentCell = Nothing
                    For i = 0 To FrmAnalisisPedido.dtg_no_reflejados.RowCount - 1
                        If (FrmAnalisisPedido.dtg_no_reflejados.Item("numero", i).Value = numeroPed) Then
                            FrmAnalisisPedido.dtg_no_reflejados.Rows(i).Visible = False
                            ' dtg_no_reflejados.Rows.RemoveAt(i)
                        End If
                    Next
                    resp = MessageBox.Show("Desea enviar correo de confirmación al vendedor? ", "correo", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    If (resp = 6) Then
                        contenido = notas & "" & vbCrLf & "" & vbCrLf & "" & vbCrLf & "" & vbCrLf & "" & vbCrLf & "" & vbCrLf & "Cordialmente: " & vbCrLf & nomUsuario
                        objEnvCorreoLN.EnviarCorreo(mailDestino, notas, titulo, "", mailEnvia, mailEnviaPass, False)
                        MessageBox.Show("Correo enviado en forma correcta!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End If

            Else
                objAnalisisPresLn.autorizarPed(notas, numeroPed)
                FrmAnalisisPedido.insertarEnGrid()
                MessageBox.Show("El pedido de autorizo en forma correcta!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            Me.Close()
        Else
            MessageBox.Show("Se deben diligenciar todos los campos!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

    ''validamos que no esten vacios los campos
    Private Function validaciones() As Boolean
        If (txtNota.Text = "" Or chkAuto.Checked = False) Then
            Return False
        Else
            Return True
        End If
    End Function
End Class