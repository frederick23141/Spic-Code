Imports entidadNegocios
Imports System.Net.Security
Imports System.Security.Cryptography.X509Certificates
Public Class EnvCorreoLN
    Private Declare Function IsNetworkAlive Lib "SENSAPI.DLL" (ByRef lpdwFlags As Long) As Long

    Public Function EnviarCorreo(ByVal mailDestino As String, ByVal textoMsg As String, ByVal titulo As String, ByVal ruta As String, ByVal email As String, ByVal contra As String) As Boolean
        Dim sw As Boolean = True
        Try

            'Datos importantes 
            ' Campo servidor smtp "smtp.live.com" para hotmail este
            'Para enviar por Hotmail utilizamos smtp.live.com y para enviar por Gmail utilizamos smtp.gmail.com
            'puerto   587

            'MsgBox(mailDestino & "+" & textoMsg & "+" & titulo & "+" & ruta)
            ' Capturo cada uno de los campos del formulario
            Dim correo As New System.Net.Mail.MailMessage()
            Dim SMTP As String = "mail.corsan.com.co"
            Dim Usuario As String = email
            Dim Contraseña As String = contra
            Dim Para As String = mailDestino
            Dim Contenido As String = textoMsg
            Dim Asunto As String = titulo
            Dim Puerto As Integer = Integer.Parse(587)
            If (ruta <> "") Then
                Dim archivo As New System.Net.Mail.Attachment(ruta)
                correo.Attachments.Add(archivo)
            End If


            'MsgBox("usuario=" & Usuario & "asunto= " & Asunto & "para= " & Para & "contenido = " & Contenido)
            'Declaro la variable para enviar el correo

            correo.From = New System.Net.Mail.MailAddress(Usuario)
            'correo.Subject = "Correo de prueba"
            correo.Subject = Asunto
            correo.To.Add(Para)
            correo.Body = Contenido



            'Configuracion del servidor
            Dim Servidor As New System.Net.Mail.SmtpClient
            Servidor.Host = SMTP
            Servidor.Port = Puerto
            Servidor.EnableSsl = True
            Servidor.Credentials = New System.Net.NetworkCredential(Usuario, Contraseña)
            Net.ServicePointManager.ServerCertificateValidationCallback = Function(s As Object, certificate As X509Certificate, chain As X509Chain, sslPolicyErrors As SslPolicyErrors) True
            Servidor.Send(correo)

        Catch ex As Exception
            MsgBox("No se logro enviar correo " + ex.Message, "Correo")
            sw = False
        End Try
        Return sw
    End Function
End Class
