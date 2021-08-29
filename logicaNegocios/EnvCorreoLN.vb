Imports entidadNegocios
Imports accesoDatos
Imports System.Net.Security
Imports System.Security.Cryptography.X509Certificates
Imports System.Net.Mime.MediaTypeNames

Public Class EnvCorreoLN
    Private objOpSimplesAd As New Op_simplesAd
    Private Declare Function IsNetworkAlive Lib "SENSAPI.DLL" (ByRef lpdwFlags As Long) As Long

    Public Function EnviarCorreo(ByVal mailDestino As String, ByVal textoMsg As String, ByVal titulo As String, ByVal ruta As String, ByVal email As String, ByVal contra As String, ByVal esHtml As Boolean) As Boolean
        Dim sw As Boolean = True


        'Datos importantes 
        ' Campo servidor smtp "smtp.live.com" para hotmail este
        'Para enviar por Hotmail utilizamos smtp.live.com y para enviar por Gmail utilizamos smtp.gmail.com
        'puerto   587
        'MsgBox(mailDestino & "+" & textoMsg & "+" & titulo & "+" & ruta)
        ' Capturo cada uno de los campos del formulario
        Dim sqlServSal As String = "SELECT ip FROM J_spic_servidores_correo WHERE descripcion ='Saliente'"
        Dim sqlPuertoSal As String = "SELECT puerto FROM J_spic_servidores_correo WHERE descripcion ='Saliente'"
        Dim correo As New System.Net.Mail.MailMessage()
        Dim SMTP As String = objOpSimplesAd.consultValor(sqlServSal)
        Dim Usuario As String = email.Trim
        Dim Contraseña As String = contra.Trim
        Dim Para As String = mailDestino.Trim
        Dim Contenido As String = textoMsg
        Dim Asunto As String = titulo
        Dim Puerto As Integer = Integer.Parse(objOpSimplesAd.consultValor(sqlPuertoSal))
        Dim direccion As String = ""
        Dim tam As Integer = 0
        If (ruta <> "") Then
            Dim archivo As New System.Net.Mail.Attachment(ruta)
            correo.Attachments.Add(archivo)
        End If


        'MsgBox("usuario=" & Usuario & "asunto= " & Asunto & "para= " & Para & "contenido = " & Contenido)
        'Declaro la variable para enviar el correo

        correo.From = New System.Net.Mail.MailAddress(Usuario)
        'correo.Subject = "Correo de prueba"
        correo.Subject = Asunto
        If (Para(Para.Length - 1) = ";") Then
            tam = Para.Length - 2
        Else
            tam = Para.Length - 1
        End If
        For i = 0 To tam
            If Para(i) = ";" Then
                correo.To.Add(direccion)
                direccion = ""
            Else
                direccion &= Para(i)
            End If

        Next

        correo.To.Add(direccion)
        'correo.To.Add(Para)
        'correo.CC.Add("sistemas@corsan.com.co")
      
        correo.Body = Contenido
        correo.IsBodyHtml = esHtml
        'Configuracion del servidor
        Try
            Dim Servidor As New System.Net.Mail.SmtpClient
            Servidor.Host = SMTP
            Servidor.Port = Puerto
            Servidor.EnableSsl = True
            Servidor.Credentials = New System.Net.NetworkCredential(Usuario, Contraseña)
            Net.ServicePointManager.ServerCertificateValidationCallback = Function(s As Object, certificate As X509Certificate, chain As X509Chain, sslPolicyErrors As SslPolicyErrors) True
            Servidor.Send(correo)
        Catch ex As System.Net.Mail.SmtpException
            MsgBox("No se logro enviar correo " & ex.Message.ToString)
            sw = False
        End Try
        Return sw
    End Function

End Class
