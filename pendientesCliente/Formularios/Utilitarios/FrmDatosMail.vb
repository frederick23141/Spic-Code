Imports logicaNegocios
Imports entidadNegocios
'Imports accesoDatos
Imports System.Text.RegularExpressions
Public Class FrmDatosMail
    Private Declare Function ShellExecute Lib "shell32.dll" Alias "ShellExecuteA" (ByVal hwnd As Long, ByVal lpOperation As String, ByVal lpFile As String, ByVal lpParameters As String, ByVal lpDirectory As String, ByVal nShowCmd As Long) As Long
    Private ruta As String = ""
    Private objEnvCorreoLN As EnvCorreoLN
    Private objUsuario As UsuarioEn
    'Private objUsuarioAd As New loginAd

    Private Sub FrmDatosMail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        objEnvCorreoLN = New EnvCorreoLN
        Me.CenterToScreen()
        imagenEnviar.Visible = False
    End Sub
    Public Sub capturarPantalla()
        Dim FSize As Size = frmPendientes.Size
        Dim bm As New Bitmap(FSize.Width, FSize.Height)
        Dim gf As Graphics
        Dim screenCap As Image
        gf = Graphics.FromImage(bm)
        gf.CopyFromScreen(0, 0, 0, 0, FSize)
        screenCap = bm
        Dim rutaArchiovo As String = (Environment.CurrentDirectory & "\informacion.jpg")
        screenCap.Clone()
        screenCap.Save(rutaArchiovo)
        bm.Dispose()
    End Sub
    Public Sub iniciarValores(ByVal rutaAdjunto As String, ByVal objUsuarioEn As UsuarioEn, ByVal nombre_cliente As String)
        ruta = rutaAdjunto
        LinkLabel1.Text = "RUTA"
        objUsuario = objUsuarioEn
        txtUsuario.Text = objUsuarioEn.Email
        txtContra.Text = objUsuarioEn.EmailClave
        txtAsunto.Text = "Autorizar pedido a: " & nombre_cliente
        txtContenido.Text = "" & vbCrLf & "" & vbCrLf & "" & vbCrLf & "" & vbCrLf & "" & vbCrLf & "" & vbCrLf & "Cordialmente: " & vbCrLf & objUsuarioEn.nombre & vbCrLf & "Servicio al cliente"
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Shell("rundll32.exe C:\WINDOWS\system32\shimgvw.dll,ImageView_Fullscreen " & ruta & "")
    End Sub
    Private Sub btnEnviar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEnviar.Click
        If validaciones() Then
            If (validar_Mail(txtUsuario.Text) = False) Then
                MessageBox.Show("Email incorrecto!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                imagenEnviar.Visible = True
                Application.DoEvents()
                Dim destino As String = txtA.Text
                Dim texto As String = txtContenido.Text
                Dim titulo As String = txtAsunto.Text
                Dim direccion As String = Environment.CurrentDirectory & "\informacion.jpg"
                Dim email As String = txtUsuario.Text
                Dim contra As String = txtContra.Text
                If (objEnvCorreoLN.EnviarCorreo(destino, texto, titulo, direccion, email, contra, False)) Then
                    MessageBox.Show("Correo enviado en forma exitosa!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Close()
                End If
                imagenEnviar.Visible = False
            End If
        Else
            MessageBox.Show("Se deben diligenciar todos los campos!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Private Function validar_Mail(ByVal sMail As String) As Boolean
           Dim emailRegex As New System.Text.RegularExpressions.Regex( 
     "^(?<user>[^@]+)@(?<host>.+)$")
        Dim emailMatch As System.Text.RegularExpressions.Match =
           emailRegex.Match(sMail)
        Return emailMatch.Success
    End Function
    Public Function validaciones() As Boolean
        If (txtA.Text = "" Or txtContenido.Text = "" Or txtAsunto.Text = "" Or txtContra.Text = "") Then
            Return False
        Else
            Return True
        End If
    End Function

End Class