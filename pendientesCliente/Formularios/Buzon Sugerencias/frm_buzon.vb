Imports entidadNegocios
Imports logicaNegocios
Public Class frm_buzon
    Private objOpSimplesLn As New Op_simpesLn
    Private obj_Ing_prodLn As New Ing_prodLn
    Private obj_correoLn As New EnvCorreoLN

    ''carga del formulario
    Private Sub frm_buzon_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        pn_area.Enabled = False
        pn_info.Enabled = True
        pn_puntos.Visible = False
        txt_centro.Text = ""
        txt_documento.Text = ""
        txt_inversion.Text = ""
        txt_nom_centro.Text = ""
        txt_nombre.Text = ""
        txt_sugerencia.Text = ""
    End Sub

    ''metodo que se encarga de buscar el empleado
    Private Sub btn_busc_emp_Click(sender As Object, e As EventArgs) Handles btn_busc_emp.Click
        If txt_documento.Text <> "" Then
            Dim sql As String = "SELECT nombres,o.centro,c.descripcion " & _
                                    " FROM V_nom_personal_Activo_con_maquila o, centros c " & _
                                        " WHERE o.centro = c.centro and nit = " & txt_documento.Text
            Dim dt As DataTable = objOpSimplesLn.listar_datatable(sql, "CORSAN")
            For i = 0 To dt.Rows.Count - 1
                txt_centro.Text = dt.Rows(i).Item("centro")
                txt_nom_centro.Text = dt.Rows(i).Item("descripcion")
                txt_nombre.Text = dt.Rows(i).Item("nombres")
            Next
            If txt_nombre.Text <> "" Then
                sql = "SELECT MAX(id_sugerencia) FROM JB_buzon_sugerencias"
                Dim consecutivo As Integer = obj_Ing_prodLn.consultar_valor(sql, "CORSAN") + 1
                sql = "INSERT INTO JB_buzon_sugerencias (id_sugerencia,documento) VALUES (" & consecutivo & "," & txt_documento.Text & ")"
                If objOpSimplesLn.ejecutar(sql, "CORSAN") Then
                    sql = "SELECT puntos FROM JB_buzon_sugerencias_puntos WHERE doc =" & txt_documento.Text
                    Dim p As String = objOpSimplesLn.consultValorTodo(sql, "CORSAN")
                    If p = "" Then
                        sql = "INSERT INTO JB_buzon_sugerencias_puntos (doc,puntos) VALUES (" & txt_documento.Text & ",0)"
                        objOpSimplesLn.ejecutar(sql, "CORSAN")
                    End If
                    pn_info.Enabled = False
                    pn_area.Enabled = True
                    lbl_consecutivo.Text = consecutivo
                    lbl_puntos.Text = cargar_puntos()
                Else
                    MessageBox.Show("Erorr al cargar la informacion, Comuniquese con el administrador del sistema.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                MessageBox.Show("No se a Encontrado la informacion, Revise el documento de identidad.", "Documento", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txt_documento.Text = ""
            End If
        Else
            MessageBox.Show("Debe digitar su documento de Identidad.", "Documento", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    ''validar solo numeros en campo del documento
    Private Sub txt_documento_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_documento.KeyPress
        soloNumero(e)
        If (e.KeyChar = Microsoft.VisualBasic.ChrW(13)) Then
            btn_busc_emp.PerformClick()
        End If
    End Sub

    ''metodo que valida solo numeros
    Private Sub soloNumero(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If (Char.IsDigit(e.KeyChar) Or e.KeyChar = ".") Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txt_inversion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_inversion.KeyPress
        soloNumero(e)
    End Sub

    ''metodo que se encarga de hacer la consulta a la db para cargar los puntos
    Private Function cargar_puntos()
        pn_puntos.Visible = True
        Dim sql As String = "SELECT puntos FROM JB_buzon_sugerencias_puntos WHERE doc = " & txt_documento.Text
        Dim punt As Integer = obj_Ing_prodLn.consultar_valor(sql, "CORSAN")
        Return punt
    End Function
    Private Sub btn_enviar_Click(sender As Object, e As EventArgs) Handles btn_enviar.Click
        'ESTA VALIDACION SE HACE GRANDE PARA PODER TOMAR TODOS LOS RADIO BUTTON
        If rdb_a1.Checked = True Or rdb_a2.Checked = True Or rdb_a3.Checked Or rdb_a4.Checked Or rdb_a5.Checked Or rdb_a6.Checked Or rdb_a7.Checked Or rdb_a8.Checked Or rdb_a9.Checked Or rdb_a10.Checked Or rdb_a11.Checked Or rdb_a12.Checked Or rdb_a13.Checked Or rdb_a14.Checked Or rdb_a14.Checked Or rdb_a15.Checked Or rdb_a16.Checked Or rdb_a17.Checked Or rdb_a18.Checked Or rdb_a19.Checked Or rdb_a20.Checked Or rdb_a21.Checked Or rdb_a22.Checked Or rdb_a23.Checked Or rdb_a24.Checked Or rdb_a25.Checked Or rdb_a26.Checked Or rdb_a27.Checked Or rdb_a28.Checked Or rdb_a29.Checked Or rdb_a30.Checked Or rdb_a31.Checked Or rdb_a32.Checked Or rdb_a33.Checked Or rdb_a34.Checked Then
            If rdb_prev.Checked = True Or rdb_corr.Checked = True Or rdb_mej.Checked = True Or rdb_sug.Checked = True Then
                If rdb_si.Checked = True Or rdb_no.Checked = True Then
                    If txt_sugerencia.Text <> "" Then
                        Dim inversion As Double = 0
                        If rdb_si.Checked = True Then
                            inversion = txt_inversion.Text
                            If inversion = 0 Then
                                MessageBox.Show("El monto de la inversion debe ser mayo a 0.", "INVERSION", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Else
                                enviar_sugerencia(lbl_consecutivo.Text, inversion)
                            End If
                        Else
                            enviar_sugerencia(lbl_consecutivo.Text, 0)
                        End If
                    Else
                        MessageBox.Show("Debe Escribir la sugerencia.", "Sugerencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                Else
                    MessageBox.Show("Debe seleccionar si la sugerencia necesita inversion.", "INVERSION", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                MessageBox.Show("Debe seleccionar un tipo de sugerencia.", "TIPO SUGERENCIA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            MessageBox.Show("Debe seleccionar el area para la cual va  a asignar la sugerencia.", "Area", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    ''metodo para enviar la sugerencias
    Private Sub enviar_sugerencia(ByVal cons As Integer, ByVal inversion As Double)
        Dim resp As Integer = MessageBox.Show("¿Desea Enviar la Sugerencia?", "Enviar Sugerencia", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
        If resp = 6 Then
            Dim listSql As New List(Of Object)
            Dim areas As Integer = area()
            Dim sugerencia As String = txt_sugerencia.Text
            Dim tipo As String = ""
            Dim req_inv As String = ""
            Dim sumar As Integer = 0

            If rdb_prev.Checked = True Then
                tipo = "P"
                sumar = 5
            ElseIf rdb_mej.Checked = True Then
                tipo = "M"
                sumar = 5
            ElseIf rdb_corr.Checked = True Then
                tipo = "C"
                sumar = 3
            ElseIf rdb_sug.Checked = True Then
                tipo = "S"
                sumar = 1
            End If

            If rdb_si.Checked = True Then
                req_inv = "S"
            Else
                req_inv = "N"
            End If

            Dim sql As String = "UPDATE JB_buzon_sugerencias SET area = '" & areas & "', inversion = '" & inversion & "',sugerencia = '" & sugerencia &
                                "',estado = 1,req_inversion = '" & req_inv & "',tipo = '" & tipo & "',fecha = GETDATE() " &
                                " WHERE id_sugerencia = " & cons
            listSql.Add(sql)

            sql = "INSERT INTO JB_buzon_historial_puntos (doc,fec,cant,razon) VALUES (" &
                        txt_documento.Text & ",getdate()," & sumar & ",'REGISTRO DE NUEVA SUGERENCIA')"
            listSql.Add(sql)

            Dim puntos As Integer = lbl_puntos.Text + sumar
            sql = "UPDATE JB_buzon_sugerencias_puntos SET puntos =" & puntos & " WHERE doc =" & txt_documento.Text
            listSql.Add(sql)

            If obj_Ing_prodLn.ExecuteSqlTransaction(listSql, "CORSAN") Then
                enviar_Correo_Admin()
                MessageBox.Show("La sugerencia se a enviado con exito, sus puntos totales son:" & cargar_puntos(), "Sugerencia Enviada", MessageBoxButtons.OK, MessageBoxIcon.Information)
                limpiar()
            Else
                MessageBox.Show("Erorr al cargar la informacion, Comuniquese con el administrador del sistema.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    ''se envia correo para que verifiquen el spic de las sugerencias 
    Private Sub enviar_correo(ByVal areas As Integer)
        Dim sql As String = "SELECT mail,Mail_login  FROM Jjv_usuarios WHERE usuario = 'ADMIN'"
        Dim dt_admin As DataTable = objOpSimplesLn.listar_datatable(sql, "CORSAN")

        sql = "SELECT correo FROM JB_buzon_sugerencias_area WHERE id_area =" & areas
        Dim mail As String = objOpSimplesLn.consultValorTodo(sql, "CORSAN")
        Dim asunto As String = "Nueva Sugerencia"
        Dim cuerpo As String = "TIENE UNA NUEVA SUGERENCIA" & vbCrLf &
                                "" & vbCrLf &
                                "Consecutivo: " & lbl_consecutivo.Text & vbCrLf &
                                " Fecha: " & Now & vbCrLf &
                                "POR FAVOR REVISAR EL SPIC."

        Dim mailEnvia As String = dt_admin.Rows(0).Item("mail")
        Dim mailEnviaPass As String = dt_admin.Rows(0).Item("Mail_login")
        obj_correoLn.EnviarCorreo(mail.Trim, cuerpo, asunto, "", mailEnvia, mailEnviaPass, False)
    End Sub

    '' metodo para enviar el correo a el administrador. para revisar en el spic
    Private Sub enviar_Correo_Admin()
        Dim sql As String = "SELECT mail,Mail_login  FROM Jjv_usuarios WHERE usuario = 'ADMIN'"
        Dim dt_admin As DataTable = objOpSimplesLn.listar_datatable(sql, "CORSAN")

        Dim mail As String = "calidad@corsan.com.co"
        Dim mail2 As String = "faysury.rios@corsan.com.co"
        Dim asunto As String = "Nueva Sugerencia"
        Dim cuerpo As String = "TIENE UNA NUEVA SUGERENCIA" & vbCrLf &
                                "" & vbCrLf &
                                "Consecutivo: " & lbl_consecutivo.Text & vbCrLf &
                                " Fecha: " & Now & vbCrLf &
                                "POR FAVOR REVISAR EL SPIC."

        Dim mailEnvia As String = dt_admin.Rows(0).Item("mail")
        Dim mailEnviaPass As String = dt_admin.Rows(0).Item("Mail_login")
        obj_correoLn.EnviarCorreo(mail.Trim, cuerpo, asunto, "", mailEnvia, mailEnviaPass, False)
        obj_correoLn.EnviarCorreo(mail2.Trim, cuerpo, asunto, "", mailEnvia, mailEnviaPass, False)
    End Sub

    Private Function area()
        Dim areas As Integer = 0
        If rdb_a1.Checked = True Then
            areas = 1
        ElseIf rdb_a2.Checked = True Then
            areas = 2
        ElseIf rdb_a3.Checked = True Then
            areas = 3
        ElseIf rdb_a4.Checked = True Then
            areas = 4
        ElseIf rdb_a5.Checked = True Then
            areas = 4
        ElseIf rdb_a6.Checked = True Then
            areas = 6
        ElseIf rdb_a7.Checked = True Then
            areas = 7
        ElseIf rdb_a8.Checked = True Then
            areas = 8
        ElseIf rdb_a9.Checked = True Then
            areas = 9
        ElseIf rdb_a10.Checked = True Then
            areas = 10
        ElseIf rdb_a11.Checked = True Then
            areas = 11
        ElseIf rdb_a12.Checked = True Then
            areas = 12
        ElseIf rdb_a13.Checked = True Then
            areas = 13
        ElseIf rdb_a14.Checked = True Then
            areas = 14
        ElseIf rdb_a15.Checked = True Then
            areas = 15
        ElseIf rdb_a16.Checked = True Then
            areas = 16
        ElseIf rdb_a17.Checked = True Then
            areas = 17
        ElseIf rdb_a18.Checked = True Then
            areas = 18
        ElseIf rdb_a19.Checked = True Then
            areas = 19
        ElseIf rdb_a20.Checked = True Then
            areas = 20
        ElseIf rdb_a21.Checked = True Then
            areas = 21
        ElseIf rdb_a22.Checked = True Then
            areas = 22
        ElseIf rdb_a23.Checked = True Then
            areas = 23
        ElseIf rdb_a24.Checked = True Then
            areas = 24
        ElseIf rdb_a25.Checked = True Then
            areas = 25
        ElseIf rdb_a26.Checked = True Then
            areas = 26
        ElseIf rdb_a27.Checked = True Then
            areas = 27
        ElseIf rdb_a28.Checked = True Then
            areas = 28
        ElseIf rdb_a29.Checked = True Then
            areas = 29
        ElseIf rdb_a30.Checked = True Then
            areas = 30
        ElseIf rdb_a31.Checked = True Then
            areas = 31
        ElseIf rdb_a32.Checked = True Then
            areas = 32
        ElseIf rdb_a33.Checked = True Then
            areas = 33
        ElseIf rdb_a34.Checked = True Then
            areas = 34
        End If
        Return areas
    End Function
    Private Sub btn_cancelar_Click(sender As Object, e As EventArgs) Handles btn_cancelar.Click
        cancelar_sug()
    End Sub


    ''metodo para borrar la sugerencia de la base de datos en JB_buzon_sugerencias
    Private Sub cancelar_sug()
        Dim sql As String = "DELETE JB_buzon_sugerencias WHERE id_sugerencia=" & lbl_consecutivo.Text
        If objOpSimplesLn.ejecutar(sql, "CORSAN") Then
            limpiar()
        Else
            MessageBox.Show("Erorr al cargar la informacion, Comuniquese con el administrador del sistema.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    ''reestablecer los campos
    Private Sub limpiar()
        pn_area.Enabled = False
        pn_info.Enabled = True
        pn_puntos.Visible = False
        txt_documento.Text = ""
        txt_documento.Focus()
        txt_centro.Text = ""
        txt_nom_centro.Text = ""
        txt_nombre.Text = ""
        txt_sugerencia.Text = ""
        lbl_consecutivo.Text = ""
        txt_inversion.Text = 0

        rdb_si.Checked = False
        rdb_no.Checked = False
        rdb_prev.Checked = False
        rdb_mej.Checked = False
        rdb_corr.Checked = False
        rdb_sug.Checked = False


        rdb_a1.Checked = False
        rdb_a2.Checked = False
        rdb_a3.Checked = False
        rdb_a4.Checked = False
        rdb_a5.Checked = False
        rdb_a5.Checked = False
        rdb_a7.Checked = False
        rdb_a8.Checked = False
        rdb_a9.Checked = False
        rdb_a10.Checked = False
        rdb_a11.Checked = False
        rdb_a12.Checked = False
        rdb_a13.Checked = False
        rdb_a14.Checked = False
        rdb_a15.Checked = False
        rdb_a16.Checked = False
        rdb_a17.Checked = False
        rdb_a18.Checked = False
        rdb_a19.Checked = False
        rdb_a20.Checked = False
        rdb_a21.Checked = False
        rdb_a22.Checked = False
        rdb_a23.Checked = False
        rdb_a24.Checked = False
        rdb_a25.Checked = False
        rdb_a26.Checked = False
        rdb_a27.Checked = False
        rdb_a28.Checked = False
        rdb_a29.Checked = False
        rdb_a30.Checked = False
        rdb_a31.Checked = False
        rdb_a32.Checked = False
        rdb_a33.Checked = False
        rdb_a34.Checked = False
    End Sub

    'PARTE DE CODIGO DE FORMA PARA DAR UNA MEJOR VISIBIIDAD DE LOS DATOS MARCADOS EN EL PROGRAMA
    Private Sub rdb_a1_CheckedChanged(sender As Object, e As EventArgs) Handles rdb_a1.CheckedChanged
        If rdb_a1.Checked Then
            rdb_a1.BackColor = Color.Blue
        Else
            rdb_a1.BackColor = Color.Transparent
        End If
    End Sub
    Private Sub rdb_a2_CheckedChanged(sender As Object, e As EventArgs) Handles rdb_a2.CheckedChanged
        If rdb_a2.Checked Then
            rdb_a2.BackColor = Color.Blue
        Else
            rdb_a2.BackColor = Color.Transparent
        End If
    End Sub
    Private Sub rdb_a3_CheckedChanged(sender As Object, e As EventArgs) Handles rdb_a3.CheckedChanged
        If rdb_a3.Checked Then
            rdb_a3.BackColor = Color.Blue
        Else
            rdb_a3.BackColor = Color.Transparent
        End If
    End Sub
    Private Sub rdb_a4_CheckedChanged(sender As Object, e As EventArgs) Handles rdb_a4.CheckedChanged
        If rdb_a4.Checked Then
            rdb_a4.BackColor = Color.Blue
        Else
            rdb_a4.BackColor = Color.Transparent
        End If
    End Sub
    Private Sub rdb_a5_CheckedChanged(sender As Object, e As EventArgs) Handles rdb_a5.CheckedChanged
        If rdb_a5.Checked Then
            rdb_a5.BackColor = Color.Blue
        Else
            rdb_a5.BackColor = Color.Transparent
        End If
    End Sub
    Private Sub rdb_a6_CheckedChanged(sender As Object, e As EventArgs) Handles rdb_a6.CheckedChanged
        If rdb_a6.Checked Then
            rdb_a6.BackColor = Color.Blue
        Else
            rdb_a6.BackColor = Color.Transparent
        End If
    End Sub
    Private Sub rdb_a7_CheckedChanged(sender As Object, e As EventArgs) Handles rdb_a7.CheckedChanged
        If rdb_a7.Checked Then
            rdb_a7.BackColor = Color.Blue
        Else
            rdb_a7.BackColor = Color.Transparent
        End If
    End Sub
    Private Sub rdb_a8_CheckedChanged(sender As Object, e As EventArgs) Handles rdb_a8.CheckedChanged
        If rdb_a8.Checked Then
            rdb_a8.BackColor = Color.Blue
        Else
            rdb_a8.BackColor = Color.Transparent
        End If
    End Sub
    Private Sub rdb_a9_CheckedChanged(sender As Object, e As EventArgs) Handles rdb_a9.CheckedChanged
        If rdb_a9.Checked Then
            rdb_a9.BackColor = Color.Blue
        Else
            rdb_a9.BackColor = Color.Transparent
        End If
    End Sub
    Private Sub rdb_a10_CheckedChanged(sender As Object, e As EventArgs) Handles rdb_a10.CheckedChanged
        If rdb_a10.Checked Then
            rdb_a10.BackColor = Color.Blue
        Else
            rdb_a10.BackColor = Color.Transparent
        End If
    End Sub
    Private Sub rdb_a11_CheckedChanged(sender As Object, e As EventArgs) Handles rdb_a11.CheckedChanged
        If rdb_a11.Checked Then
            rdb_a11.BackColor = Color.Blue
        Else
            rdb_a11.BackColor = Color.Transparent
        End If
    End Sub
    Private Sub rdb_a12_CheckedChanged(sender As Object, e As EventArgs) Handles rdb_a12.CheckedChanged
        If rdb_a12.Checked Then
            rdb_a12.BackColor = Color.Blue
        Else
            rdb_a12.BackColor = Color.Transparent
        End If
    End Sub
    Private Sub rdb_a13_CheckedChanged(sender As Object, e As EventArgs) Handles rdb_a13.CheckedChanged
        If rdb_a13.Checked Then
            rdb_a13.BackColor = Color.Blue
        Else
            rdb_a13.BackColor = Color.Transparent
        End If
    End Sub
    Private Sub rdb_a14_CheckedChanged(sender As Object, e As EventArgs) Handles rdb_a14.CheckedChanged
        If rdb_a14.Checked Then
            rdb_a14.BackColor = Color.Blue
        Else
            rdb_a14.BackColor = Color.Transparent
        End If
    End Sub
    Private Sub rdb_a15_CheckedChanged(sender As Object, e As EventArgs) Handles rdb_a15.CheckedChanged
        If rdb_a15.Checked Then
            rdb_a15.BackColor = Color.Blue
        Else
            rdb_a15.BackColor = Color.Transparent
        End If
    End Sub
    Private Sub rdb_a16_CheckedChanged(sender As Object, e As EventArgs) Handles rdb_a16.CheckedChanged
        If rdb_a16.Checked Then
            rdb_a16.BackColor = Color.Blue
        Else
            rdb_a16.BackColor = Color.Transparent
        End If
    End Sub
    Private Sub rdb_a17_CheckedChanged(sender As Object, e As EventArgs) Handles rdb_a17.CheckedChanged
        If rdb_a17.Checked Then
            rdb_a17.BackColor = Color.Blue
        Else
            rdb_a17.BackColor = Color.Transparent
        End If
    End Sub
    Private Sub rdb_a18_CheckedChanged(sender As Object, e As EventArgs) Handles rdb_a18.CheckedChanged
        If rdb_a18.Checked Then
            rdb_a18.BackColor = Color.Blue
        Else
            rdb_a18.BackColor = Color.Transparent
        End If
    End Sub
    Private Sub rdb_a19_CheckedChanged(sender As Object, e As EventArgs) Handles rdb_a19.CheckedChanged
        If rdb_a19.Checked Then
            rdb_a19.BackColor = Color.Blue
        Else
            rdb_a19.BackColor = Color.Transparent
        End If
    End Sub
    Private Sub rdb_a20_CheckedChanged(sender As Object, e As EventArgs) Handles rdb_a20.CheckedChanged
        If rdb_a20.Checked Then
            rdb_a20.BackColor = Color.Blue
        Else
            rdb_a20.BackColor = Color.Transparent
        End If
    End Sub
    Private Sub rdb_a21_CheckedChanged(sender As Object, e As EventArgs) Handles rdb_a21.CheckedChanged
        If rdb_a21.Checked Then
            rdb_a21.BackColor = Color.Blue
        Else
            rdb_a21.BackColor = Color.Transparent
        End If
    End Sub
    Private Sub rdb_a22_CheckedChanged(sender As Object, e As EventArgs) Handles rdb_a22.CheckedChanged
        If rdb_a22.Checked Then
            rdb_a22.BackColor = Color.Blue
        Else
            rdb_a22.BackColor = Color.Transparent
        End If
    End Sub
    Private Sub rdb_a23_CheckedChanged(sender As Object, e As EventArgs) Handles rdb_a23.CheckedChanged
        If rdb_a23.Checked Then
            rdb_a23.BackColor = Color.Blue
        Else
            rdb_a23.BackColor = Color.Transparent
        End If
    End Sub
    Private Sub rdb_a24_CheckedChanged(sender As Object, e As EventArgs) Handles rdb_a24.CheckedChanged
        If rdb_a24.Checked Then
            rdb_a24.BackColor = Color.Blue
        Else
            rdb_a24.BackColor = Color.Transparent
        End If
    End Sub
    Private Sub rdb_a25_CheckedChanged(sender As Object, e As EventArgs) Handles rdb_a25.CheckedChanged
        If rdb_a25.Checked Then
            rdb_a25.BackColor = Color.Blue
        Else
            rdb_a25.BackColor = Color.Transparent
        End If
    End Sub
    Private Sub rdb_a26_CheckedChanged(sender As Object, e As EventArgs) Handles rdb_a26.CheckedChanged
        If rdb_a26.Checked Then
            rdb_a26.BackColor = Color.Blue
        Else
            rdb_a26.BackColor = Color.Transparent
        End If
    End Sub
    Private Sub rdb_a27_CheckedChanged(sender As Object, e As EventArgs) Handles rdb_a27.CheckedChanged
        If rdb_a27.Checked Then
            rdb_a27.BackColor = Color.Blue
        Else
            rdb_a27.BackColor = Color.Transparent
        End If
    End Sub
    Private Sub rdb_a28_CheckedChanged(sender As Object, e As EventArgs) Handles rdb_a28.CheckedChanged
        If rdb_a28.Checked Then
            rdb_a28.BackColor = Color.Blue
        Else
            rdb_a28.BackColor = Color.Transparent
        End If
    End Sub
    Private Sub rdb_a29_CheckedChanged(sender As Object, e As EventArgs) Handles rdb_a29.CheckedChanged
        If rdb_a29.Checked Then
            rdb_a29.BackColor = Color.Blue
        Else
            rdb_a29.BackColor = Color.Transparent
        End If
    End Sub
    Private Sub rdb_a30_CheckedChanged(sender As Object, e As EventArgs) Handles rdb_a30.CheckedChanged
        If rdb_a30.Checked Then
            rdb_a30.BackColor = Color.Blue
        Else
            rdb_a30.BackColor = Color.Transparent
        End If
    End Sub

    Private Sub rdb_prev_CheckedChanged(sender As Object, e As EventArgs) Handles rdb_prev.CheckedChanged
        If rdb_prev.Checked Then
            rdb_prev.BackColor = Color.Blue
        Else
            rdb_prev.BackColor = Color.Transparent
        End If
    End Sub

    Private Sub rdb_corr_CheckedChanged(sender As Object, e As EventArgs) Handles rdb_corr.CheckedChanged
        If rdb_corr.Checked Then
            rdb_corr.BackColor = Color.Blue
        Else
            rdb_corr.BackColor = Color.Transparent
        End If
    End Sub

    Private Sub rdb_mej_CheckedChanged(sender As Object, e As EventArgs) Handles rdb_mej.CheckedChanged
        If rdb_mej.Checked Then
            rdb_mej.BackColor = Color.Blue
        Else
            rdb_mej.BackColor = Color.Transparent
        End If
    End Sub

    Private Sub rdb_si_CheckedChanged(sender As Object, e As EventArgs) Handles rdb_si.CheckedChanged
        If rdb_si.Checked Then
            rdb_si.BackColor = Color.Blue
            txt_inversion.Enabled = True

            txt_inversion.Focus()
            txt_inversion.Text = 0
        Else
            rdb_si.BackColor = Color.Transparent
        End If
    End Sub

    Private Sub rdb_no_CheckedChanged(sender As Object, e As EventArgs) Handles rdb_no.CheckedChanged
        If rdb_no.Checked Then
            rdb_no.BackColor = Color.Blue
            txt_inversion.Enabled = False
            txt_inversion.Text = 0
        Else
            rdb_no.BackColor = Color.Transparent
        End If
    End Sub

    Private Sub rdb_sug_CheckedChanged(sender As Object, e As EventArgs) Handles rdb_sug.CheckedChanged
        If rdb_sug.Checked Then
            rdb_sug.BackColor = Color.Blue
        Else
            rdb_sug.BackColor = Color.Transparent
        End If
    End Sub

    Private Sub rdb_a31_CheckedChanged(sender As Object, e As EventArgs) Handles rdb_a31.CheckedChanged
        If rdb_a31.Checked Then
            rdb_a31.BackColor = Color.Blue
        Else
            rdb_a31.BackColor = Color.Transparent
        End If
    End Sub

    Private Sub rdb_a33_CheckedChanged(sender As Object, e As EventArgs) Handles rdb_a33.CheckedChanged
        If rdb_a33.Checked Then
            rdb_a33.BackColor = Color.Blue
        Else
            rdb_a33.BackColor = Color.Transparent
        End If
    End Sub

    Private Sub rdb_a32_CheckedChanged(sender As Object, e As EventArgs) Handles rdb_a32.CheckedChanged
        If rdb_a32.Checked Then
            rdb_a32.BackColor = Color.Blue
        Else
            rdb_a32.BackColor = Color.Transparent
        End If
    End Sub

    Private Sub rdb_a34_CheckedChanged(sender As Object, e As EventArgs) Handles rdb_a34.CheckedChanged
        If rdb_a34.Checked Then
            rdb_a34.BackColor = Color.Blue
        Else
            rdb_a34.BackColor = Color.Transparent
        End If
    End Sub

    Private Sub btn_premios_Click(sender As Object, e As EventArgs) Handles btn_premios.Click
        frm_buzon_red_premios.main(txt_nombre.Text, txt_documento.Text, lbl_puntos.Text)
        frm_buzon_red_premios.Show()
        cancelar_sug()
        Me.Close()
    End Sub

    Private Sub frm_buzon_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Dim consecutivodd As String = lbl_consecutivo.Text
        If consecutivodd <> "" Then
            cancelar_sug()
        End If
    End Sub
End Class