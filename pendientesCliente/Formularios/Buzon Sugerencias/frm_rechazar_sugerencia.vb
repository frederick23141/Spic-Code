
Imports entidadNegocios
Imports logicaNegocios
Public Class frm_rechazar_sugerencia
    Dim id_sug As Integer = 0
    Dim doc As Integer = 0

    Private objOpSimplesLn As New Op_simpesLn
    Private obj_correoLn As New EnvCorreoLN
    Dim usuario As UsuarioEn

    Public Sub main(ByVal num As Integer, ByVal doc As Integer, ByVal us As UsuarioEn)
        Me.Text = "Denegar Sugerencia #" & num
        id_sug = num
        txt_razon.Focus()
        txt_razon.Text = ""
        Me.doc = doc
        usuario = us
    End Sub

    ''metodo que se encarga de controlar la denegacion de la sugerencia
    Private Sub denegar()
        If txt_razon.Text <> "" Then
            Dim sql As String = "UPDATE JB_buzon_sugerencias SET estado = 3, fec_rech = GETDATE(),motivo_rech = '" & txt_razon.Text & "' WHERE id_sugerencia = " & id_sug
            If objOpSimplesLn.ejecutar(sql, "CORSAN") Then
                MessageBox.Show("La sugerencia #" & id_sug & " se denego Correctamente.", "Sugerencia Denegada", MessageBoxButtons.OK, MessageBoxIcon.Information)
                enviar_correo(doc)
                Me.Close()
            End If
        Else
            MessageBox.Show("Debe digitar un motivo para poder denegar la Sugerencia.", "Digitar Motivo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
    Private Sub btn_denegar_Click(sender As Object, e As EventArgs) Handles btn_denegar.Click
        denegar()
    End Sub

    ''metodo que se encarga de enviar el correo con la informacion de la sugerencia denegada
    Private Sub enviar_correo(ByVal nit As Integer)
        Dim sql As String = "SELECT mail,Mail_login  FROM Jjv_usuarios WHERE usuario = 'ADMIN'"
        Dim dt_admin As DataTable = objOpSimplesLn.listar_datatable(sql, "CORSAN")

        sql = "SELECT mail FROM v_nom_personal WHERE nit =" & nit
        Dim mail As String = objOpSimplesLn.consultValorTodo(sql, "CORSAN")

        Dim asunto As String = "Sugerencia denegada"
        Dim cuerpo As String = "SUGERENCIA DENEGADA" & vbCrLf & _
                                "" & vbCrLf & _
                                "Consecutivo:  " & id_sug & vbCrLf & _
                                "Fecha:  " & Now & vbCrLf & _
                                "RAZON:  " & txt_razon.Text & vbCrLf & _
                                "DENEGADA POR:  " & usuario.nombresCompleto

        Dim mailEnvia As String = dt_admin.Rows(0).Item("mail")
        Dim mailEnviaPass As String = dt_admin.Rows(0).Item("Mail_login")
        obj_correoLn.EnviarCorreo(mail.Trim, cuerpo, asunto, "", mailEnvia, mailEnviaPass, False)
    End Sub
End Class