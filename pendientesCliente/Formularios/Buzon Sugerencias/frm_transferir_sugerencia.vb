Imports entidadNegocios
Imports logicaNegocios
Public Class frm_transferir_sugerencia
    Dim id_sug As Integer = 0
    Dim usuario As UsuarioEn
    Dim doc As Integer = 0

    Private objOpSimplesLn As New Op_simpesLn
    Private obj_correoLn As New EnvCorreoLN
    Private obj_Ing_prodLn As New Ing_prodLn

    Public Sub main(ByVal consecutivo As Integer, ByVal us As UsuarioEn, ByVal doc As Integer)
        Me.Text = "Transferir Sugerencia #" & consecutivo
        id_sug = consecutivo
        usuario = us
        Me.doc = doc
    End Sub

    ''metodo que se encarga de el control de la transferencia de las solicitudes
    Private Sub frm_transferir_sugerencia_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim sql As String = ""
        Dim dt As New DataTable

        'CBO De Clientes
        sql = "SELECT id_area,area FROM JB_buzon_sugerencias_area ORDER BY area"
        dt = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        dt.Rows.Add()
        dt.Rows(dt.Rows.Count - 1).Item("id_area") = 0
        dt.Rows(dt.Rows.Count - 1).Item("area") = "Seleccione Area"
        cbo_area.DataSource = dt
        cbo_area.ValueMember = "id_area"
        cbo_area.DisplayMember = "area"
        cbo_area.SelectedValue = 0
    End Sub

    ''metodo que se encarga de actualizar las sugerencias para su estado 
    Private Sub btn_transferir_Click(sender As Object, e As EventArgs) Handles btn_transferir.Click
        Dim listSql As New List(Of Object)
        If cbo_area.SelectedValue <> 0 Then
            Dim sql As String = "UPDATE JB_buzon_sugerencias SET area = " & cbo_area.SelectedValue & " WHERE id_sugerencia = " & id_sug
            listSql.Add(sql)
            If obj_Ing_prodLn.ExecuteSqlTransaction(listSql, "CORSAN") Then
                MessageBox.Show("La sugerencia #" & id_sug & " se Transfirio Correctamente.", "Sugerencia Transferida", MessageBoxButtons.OK, MessageBoxIcon.Information)
                enviar_correo(cbo_area.SelectedValue)
                Me.Close()
            End If
        Else
            MessageBox.Show("Debe digitar un motivo para poder denegar la Sugerencia.", "Digitar Motivo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    ''metodo que se encarga de enviar la informacion de la nueva sugerencia
    Private Sub enviar_correo(ByVal areas As Integer)
        Dim sql As String = "SELECT mail,Mail_login  FROM Jjv_usuarios WHERE usuario = 'ADMIN'"
        Dim dt_admin As DataTable = objOpSimplesLn.listar_datatable(sql, "CORSAN")

        sql = "SELECT correo FROM JB_buzon_sugerencias_area WHERE id_area =" & areas
        Dim mail As String = objOpSimplesLn.consultValorTodo(sql, "CORSAN")

        Dim asunto As String = "Nueva Sugerencia"
        Dim cuerpo As String = "TIENE UNA NUEVA SUGERENCIA" & vbCrLf & _
                                "" & vbCrLf & _
                                "Consecutivo: " & id_sug & vbCrLf & _
                                "Fecha: " & Now & vbCrLf & _
                                "TRANSFERIDA POR: " & usuario.nombresCompleto & vbCrLf & _
                                "POR FAVOR REVISAR EL SPIC."
        Dim mailEnvia As String = dt_admin.Rows(0).Item("mail")
        Dim mailEnviaPass As String = dt_admin.Rows(0).Item("Mail_login")
        obj_correoLn.EnviarCorreo(mail.Trim, cuerpo, asunto, "", mailEnvia, mailEnviaPass, False)
    End Sub
End Class