Imports entidadNegocios
Imports accesoDatos
Imports logicaNegocios
Public Class frm_consulta_buzon
    Private objOpSimplesLn As New Op_simpesLn
    Dim usuario As New UsuarioEn
    Private objOperacionesForm As OperacionesFormularios = New OperacionesFormularios
    Private objOpSimplesAd As New Op_simplesAd
    Private obj_correoLn As New EnvCorreoLN
    Dim areas As String = ""
    Dim consecutivo_mod As Integer = 0
    Dim cc_operario As Integer = 0


    '' carga del formulario
    Public Sub main(ByVal usuario As UsuarioEn)
        Me.usuario = usuario
        areas = cons_areas(usuario.usuario)

        Dim sql As String = ""
        Dim dt As New DataTable

        'CBO De Clientes
        If areas <> "" Then
            sql = "SELECT id_area,area FROM JB_buzon_sugerencias_area WHERE id_area IN (" & areas & ") ORDER BY area"
        Else
            sql = "SELECT id_area,area FROM JB_buzon_sugerencias_area WHERE id_area IN (999) ORDER BY area"
        End If


        dt = objOpSimplesLn.listar_datatable(Sql, "CORSAN")
        dt.Rows.Add()
        dt.Rows(dt.Rows.Count - 1).Item("id_area") = 0
        dt.Rows(dt.Rows.Count - 1).Item("area") = "Seleccione Area"
        cbo_area.DataSource = dt
        cbo_area.ValueMember = "id_area"
        cbo_area.DisplayMember = "area"
        cbo_area.SelectedValue = 0

        cbo_fec_ini.Value = Now
        cbo_fec_fin.Value = Now
    End Sub


    '' metodo poar aconsultar el area en JB_buzon_sugerencias
    Public Function cons_areas(ByVal dusuario As String) As String
        Dim sVendedores As String = ""
        Dim listUsuarios As List(Of Object)
        Dim sql As String = "SELECT area FROM JB_buzon_permisos WHERE usuario = '" & dusuario & "'"
        listUsuarios = objOpSimplesAd.lista(sql)
        For i = 0 To listUsuarios.Count - 1
            sVendedores &= Convert.ToString(listUsuarios(i))
            If (i <> listUsuarios.Count - 1) Then
                sVendedores += ","
            End If
        Next
        Return sVendedores
    End Function

    Private Sub btn_consultar_Click(sender As Object, e As EventArgs) Handles btn_consultar.Click
        consultar()
    End Sub

    Public Sub consultar()
        Dim whereSql As String = ""
        'CARGAR ESTADOS
        If chk_aprobado.Checked = True Or chk_cerrado.Checked = True Or chk_denegado.Checked = True Or chk_ejecucion.Checked = True Or chk_enviado.Checked = True Then
            Dim estados As String = ""
            If chk_enviado.Checked = True Then
                If estados = "" Then
                    estados = "1"
                Else
                    estados &= ",1"
                End If
            End If
            If chk_aprobado.Checked = True Then
                If estados = "" Then
                    estados = "2"
                Else
                    estados &= ",2"
                End If
            End If
            If chk_denegado.Checked = True Then
                If estados = "" Then
                    estados = "3"
                Else
                    estados &= ",3"
                End If
            End If
            If chk_ejecucion.Checked = True Then
                If estados = "" Then
                    estados = "4"
                Else
                    estados &= ",4"
                End If
            End If
            If chk_cerrado.Checked = True Then
                If estados = "" Then
                    estados = "5"
                Else
                    estados &= ",5"
                End If
            End If
            whereSql &= " AND s.estado in(" & estados & ")"
        End If
        'CARGAR INVERSION
        If chk_si.Checked = True Or chk_no.Checked = True Then
            Dim req_inv As String = ""
            If chk_si.Checked = True Then
                If req_inv = "" Then
                    req_inv = "'S'"
                Else
                    req_inv &= ",'S'"
                End If
            End If
            If chk_no.Checked = True Then
                If req_inv = "" Then
                    req_inv = "'N'"
                Else
                    req_inv &= ",'N'"
                End If
            End If
            whereSql &= " AND s.req_inversion in(" & req_inv & ") "
        End If
        'CARGAR TIPO
        If chk_preventiva.Checked = True Or chk_correctiva.Checked = True Or chk_mejora.Checked = True Or chk_sugerencia.Checked = True Then
            Dim tipo As String = ""
            If chk_preventiva.Checked = True Then
                If tipo = "" Then
                    tipo = "'P'"
                Else
                    tipo &= ",'P'"
                End If
            End If
            If chk_correctiva.Checked = True Then
                If tipo = "" Then
                    tipo = "'C'"
                Else
                    tipo &= ",'C'"
                End If
            End If
            If chk_mejora.Checked = True Then
                If tipo = "" Then
                    tipo = "'M'"
                Else
                    tipo &= ",'M'"
                End If
            End If
            If chk_sugerencia.Checked = True Then
                If tipo = "" Then
                    tipo = "'S'"
                Else
                    tipo &= ",'S'"
                End If
            End If
            whereSql &= " AND s.tipo IN(" & tipo & ")"
        End If
        'CARGAR AREA
        If cbo_area.SelectedValue <> 0 Then
            whereSql &= " AND s.area ='" & cbo_area.SelectedValue & "'"
        Else
            whereSql &= " AND s.area IN (" & areas & ")"
        End If

        If txt_consecutivo.Text <> "" Then
            whereSql &= " AND id_sugerencia=" & txt_consecutivo.Text
        End If
        'CARGAR FECHA
        If rdb_ninguno.Checked = False Then
            Dim fecIni As String = objOpSimplesLn.cambiarFormatoFecha(Convert.ToDateTime(cbo_fec_ini.Value))
            Dim fecFin As String = objOpSimplesLn.cambiarFormatoFecha(Convert.ToDateTime(cbo_fec_fin.Value))
            Dim dato As String = ""
            If rdb_aprobacion.Checked = True Then
                dato = " AND s.fec_aprov >='" & fecIni & " 00:00:00:00' AND  s.fec_aprov <='" & fecFin & " 23:59:59:59'"
            End If
            If rdb_cierre.Checked = True Then
                dato = " AND s.fech_cierre >='" & fecIni & " 00:00:00:00' AND  s.fech_cierre <='" & fecFin & " 23:59:59:59'"
            End If
            If rdb_denegado.Checked = True Then
                dato = " AND s.fec_rech >='" & fecIni & " 00:00:00:00' AND  s.fec_rech <='" & fecFin & " 23:59:59:59'"
            End If
            If rdb_ejecucion.Checked = True Then
                dato = " AND s.fec_ejec >='" & fecIni & " 00:00:00:00' AND  s.fec_ejec <='" & fecFin & " 23:59:59:59'"
            End If
            If rdb_envio.Checked = True Then
                dato = " AND s.fecha >='" & fecIni & " 00:00:00:00' AND  s.fecha <='" & fecFin & " 23:59:59:59'"
            End If

            whereSql &= dato
        End If
        Dim sql As String = "SELECT s.id_sugerencia AS '#',s.documento AS Doc, p.nombres, a.area,s.tipo,s.sugerencia,s.estado,s.req_inversion AS Req_Inv,s.inversion, s.fecha AS Fecha_Envio, " & _
                            " s.fec_aprov AS Fecha_Aprob,s.fec_rech AS Fecha_rec, s.motivo_rech,s.fec_ejec AS Fecha_Ejec, s.fech_cierre AS Fecha_cierre " & _
                            " FROM JB_buzon_sugerencias s, JB_buzon_sugerencias_area a,v_nom_personal p " & _
                            " WHERE s.documento = p.nit and s.area = a.id_area " & _
                            " AND s.estado IS NOT NULL AND s.area IS NOT NULL" & whereSql & " ORDER BY s.fecha DESC"
        Dim dt As DataTable = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        dtg_buzon.DataSource = dt
        dtg_buzon.Columns("estado").Visible = False
        dtg_buzon.Columns("inversion").DefaultCellStyle.NullValue = "0"
        dtg_buzon.Columns("inversion").DefaultCellStyle.Format = "C0"
        dtg_buzon.Columns("#").DefaultCellStyle = formatoNegrita()
        For i = 0 To dtg_buzon.RowCount - 1
            If dtg_buzon.Item("estado", i).Value = 2 Then
                dtg_buzon.Rows(i).DefaultCellStyle.BackColor = Color.PaleGreen
            End If
            If dtg_buzon.Item("estado", i).Value = 3 Then
                dtg_buzon.Rows(i).DefaultCellStyle.BackColor = Color.PeachPuff
            End If
            If dtg_buzon.Item("estado", i).Value = 4 Then
                dtg_buzon.Rows(i).DefaultCellStyle.BackColor = Color.Khaki
            End If
            If dtg_buzon.Item("estado", i).Value = 5 Then
                dtg_buzon.Rows(i).DefaultCellStyle.BackColor = Color.LightGray
            End If
        Next

    End Sub

    ''metodo para obtener el datagridview
    Private Sub dtg_buzon_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dtg_buzon.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            ms_opciones.Enabled = True
            If dtg_buzon.Rows.Count > 0 Then
                With (Me.dtg_buzon)
                    Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                    If Hitest.Type = DataGridViewHitTestType.Cell Then
                        .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                        consecutivo_mod = Me.dtg_buzon("#", Me.dtg_buzon.CurrentRow.Index).Value
                        cc_operario = Me.dtg_buzon("Doc", Me.dtg_buzon.CurrentRow.Index).Value
                        If consecutivo_mod <> 0 Then
                            If usuario.usuario.Trim.ToUpper = "ELIZABETH.FRANCO" Or usuario.usuario.Trim.ToUpper = "ADMIN" Or usuario.usuario.Trim.ToUpper = "FRIOS" Or usuario.usuario.Trim.ToUpper = "NOMINA" Then
                                CerrarToolStripMenuItem.Enabled = True
                            Else
                                CerrarToolStripMenuItem.Enabled = False
                            End If
                        End If
                    End If
                End With
            End If
        End If
    End Sub

    ''dar formato de casillas a negrita
    Public Function formatoNegrita() As DataGridViewCellStyle
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold)
        Return DataGridViewCellStyle1
    End Function

    ''metodo que se encarga de validar la fecha de aprovacion en JB_buzon_sugerencia y lo retorna 
    Private Function validar_aprobado(ByVal id_sug As Integer)
        Dim resp As Boolean = False
        Dim sql As String = "SELECT fec_aprov FROM JB_buzon_sugerencias WHERE id_sugerencia = " & id_sug
        Dim fec As String = objOpSimplesLn.consultValorTodo(sql, "CORSAN")
        If fec <> "" Then
            resp = True
        End If
        Return resp
    End Function

    ''metodo que se encarga de validar la fecha de negacion en JB_buzon_sugerencia y lo retorna 
    Private Function validar_denegado(ByVal id_sug As Integer)
        Dim resp As Boolean = False
        Dim sql As String = "SELECT fec_rech FROM JB_buzon_sugerencias WHERE id_sugerencia = " & id_sug
        Dim fec As String = objOpSimplesLn.consultValorTodo(sql, "CORSAN")
        If fec <> "" Then
            resp = True
        End If
        Return resp
    End Function

    ''metodo que se encarga de validar la fecha de ejecucion en JB_buzon_sugerencia y lo retorna 
    Private Function validar_ejecutado(ByVal id_sug As Integer)
        Dim resp As Boolean = False
        Dim sql As String = "SELECT fec_ejec FROM JB_buzon_sugerencias WHERE id_sugerencia = " & id_sug
        Dim fec As String = objOpSimplesLn.consultValorTodo(sql, "CORSAN")
        If fec <> "" Then
            resp = True
        End If
        Return resp
    End Function

    ''metodo que se encarga de validar la fecha de cerrado en JB_buzon_sugerencia y lo retorna 
    Private Function validar_cerrado(ByVal id_sug As Integer)
        Dim resp As Boolean = False
        Dim sql As String = "SELECT fech_cierre FROM JB_buzon_sugerencias WHERE id_sugerencia = " & id_sug
        Dim fec As String = objOpSimplesLn.consultValorTodo(sql, "CORSAN")
        If fec = "" Then
            resp = True
        End If
        Return resp
    End Function

    ''metodo que se encarga de controlar las sugerencias. cierre, actualizacion.
    Private Sub CerrarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CerrarToolStripMenuItem.Click
        Dim val As Boolean = False
        If validar_cerrado(consecutivo_mod) = True Then
            If validar_aprobado(consecutivo_mod) = True Then
                If validar_ejecutado(consecutivo_mod) = True Then
                    val = True
                End If
            ElseIf validar_denegado(consecutivo_mod) = True Then
                val = True
            End If

            If val = True Then
                Dim resp As Integer = MessageBox.Show("¿Desea Cerrar la Sugerencia?", "Cerrar Sugerencia", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                If resp = 6 Then
                    Dim sql As String = "UPDATE JB_buzon_sugerencias SET estado = 5, fech_cierre = GETDATE() WHERE id_sugerencia = " & consecutivo_mod
                    If objOpSimplesLn.ejecutar(sql, "CORSAN") Then
                        MessageBox.Show("La sugerencia #" & consecutivo_mod & " se cerro Correctamente.", "Sugerencia Cerrada", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        enviar_Correo_Cerrado(consecutivo_mod)
                        consultar()
                    End If
                End If
            Else
                MessageBox.Show("La sugerencia #" & consecutivo_mod & " debe estar denegada o en ejecucion.", "Sugerencia Cerrada", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Else
            MessageBox.Show("La sugerencia #" & consecutivo_mod & " ya esta cerrada.", "Sugerencia Cerrada", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub


    '' metodo que se encarga de controlar la aprobacion de las sugerencias. 
    Private Sub AprobarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AprobarToolStripMenuItem.Click
        Dim val As Boolean = False
        If validar_cerrado(consecutivo_mod) = True Then
            If validar_aprobado(consecutivo_mod) = False Then
                If validar_denegado(consecutivo_mod) = False Then
                    val = True
                End If
            End If
        End If
        If val = True Then
            Dim resp As Integer = MessageBox.Show("¿Desea Aprobar la Sugerencia?", "Aprobar Sugerencia", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
            If resp = 6 Then
                Dim sql As String = "UPDATE JB_buzon_sugerencias SET estado = 2, fec_aprov = GETDATE() WHERE id_sugerencia = " & consecutivo_mod
                If objOpSimplesLn.ejecutar(sql, "CORSAN") Then
                    MessageBox.Show("La sugerencia #" & consecutivo_mod & " se aprobo Correctamente.", "Sugerencia Aprobada", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    consultar()
                End If
            End If
        Else
            MessageBox.Show("La sugerencia #" & consecutivo_mod & " no puede estar aprobada o denegada.", "Sugerencia Cerrada", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    '' metodo que se encarga de negar las sugerencias 
    Private Sub DenegarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DenegarToolStripMenuItem.Click
        Dim val As Boolean = False
        If validar_cerrado(consecutivo_mod) = True Then
            If validar_aprobado(consecutivo_mod) = False Then
                If validar_denegado(consecutivo_mod) = False Then
                    val = True
                End If
            End If
        End If
        If val = True Then
            Dim resp As Integer = MessageBox.Show("¿Desea Denegar la Sugerencia?", "Denegar Sugerencia", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
            If resp = 6 Then
                frm_rechazar_sugerencia.main(consecutivo_mod, cc_operario, usuario)
                frm_rechazar_sugerencia.ShowDialog()
                consultar()
            End If
        Else
            MessageBox.Show("La sugerencia #" & consecutivo_mod & " no puede estar aprobada o denegada.", "Sugerencia Denegada", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    ''metodo que se encarga de poner en ejecucion las sugerencias
    Private Sub PonerEnEjecucionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PonerEnEjecucionToolStripMenuItem.Click
        Dim val As Boolean = False

        If validar_cerrado(consecutivo_mod) = True Then
            If validar_aprobado(consecutivo_mod) = True Then
                If validar_denegado(consecutivo_mod) = False Then
                    If validar_ejecutado(consecutivo_mod) = False Then
                        val = True
                    End If
                End If
            End If
        End If
        If val = True Then
            Dim resp As Integer = MessageBox.Show("¿Desea poner en ejecucion la Sugerencia?", "Ejecutar Sugerencia", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
            If resp = 6 Then
                frm_ejecutar_sugerencia.main(consecutivo_mod, usuario, cc_operario)
                frm_ejecutar_sugerencia.ShowDialog()
                consultar()
            End If
        Else
            MessageBox.Show("La sugerencia #" & consecutivo_mod & " no puede estar denegada o Cerrada.", "Sugerencia Cerrada.", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub


    ''metodo que se encarga de transferir las solicitudes en estado de sin aprobar, ejecutar o denegar
    Private Sub TransferirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TransferirToolStripMenuItem.Click
        Dim val As Boolean = False
        If validar_cerrado(consecutivo_mod) = True Then
            If validar_aprobado(consecutivo_mod) = False Then
                If validar_denegado(consecutivo_mod) = False Then
                    If validar_ejecutado(consecutivo_mod) = False Then
                        val = True
                    End If
                End If
            End If
        End If
        If val = True Then
            Dim resp As Integer = MessageBox.Show("¿Desea Transferir la sugerencia.", "Transferir Sugerencia", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
            If resp = 6 Then
                frm_transferir_sugerencia.main(consecutivo_mod, usuario, cc_operario)
                frm_transferir_sugerencia.ShowDialog()
                consultar()
            End If
        Else
            MessageBox.Show("Solo se pueden Transferir sugerencias sin, aprobar, ejecutar o denegar.", "No se Puede Transferir", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub


    ''metodo que se encarga de exportar los datos a excel
    Private Sub btn_exportar_Click(sender As Object, e As EventArgs) Handles btn_exportar.Click
        Me.UseWaitCursor = True
        Application.DoEvents()
        objOperacionesForm.exportarExcel(dtg_buzon)
        Me.UseWaitCursor = False
    End Sub


    '' metodo que se encarga de controlar las sugerencias  ejecutadas 
    Private Sub SugerenciaEjecutadaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SugerenciaEjecutadaToolStripMenuItem.Click
        Dim val As Boolean = False
        If validar_cerrado(consecutivo_mod) = True Then
            If validar_aprobado(consecutivo_mod) = True Then
                If validar_ejecutado(consecutivo_mod) = True Then
                    val = True
                End If
            ElseIf validar_denegado(consecutivo_mod) = True Then
                val = True
            End If

            If val = True Then
                enviar_correo(consecutivo_mod)
            Else
                MessageBox.Show("La sugerencia #" & consecutivo_mod & " debe estar denegada o en ejecucion.", "Sugerencia Cerrada", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Else
            MessageBox.Show("La sugerencia #" & consecutivo_mod & " ya esta cerrada.", "Sugerencia Cerrada", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub


    '' metodo que se encarga de enviar el correo con la informacion de la solicitud ejecutada
    Private Sub enviar_correo(ByVal sug As Integer)
        Dim sql As String = "SELECT mail,Mail_login  FROM Jjv_usuarios WHERE usuario = 'ADMIN'"
        Dim dt_admin As DataTable = objOpSimplesLn.listar_datatable(sql, "CORSAN")


        Dim mail As String = "calidad@corsan.com.co"

        Dim asunto As String = "Sugerencia ejecutada."
        Dim cuerpo As String = "SUGERENCIA EJECUTADA" & vbCrLf &
                                "" & vbCrLf &
                                "LA SUGERENCIA #" & sug & "  SE ENCUENTRA TERMINADA, POR FAVOR REVISAR EL SPIC."
        Dim mailEnvia As String = dt_admin.Rows(0).Item("mail")
        Dim mailEnviaPass As String = dt_admin.Rows(0).Item("Mail_login")
        obj_correoLn.EnviarCorreo(mail.Trim, cuerpo, asunto, "", mailEnvia, mailEnviaPass, False)
        mail = "faysury.rios@corsan.com.co"
        obj_correoLn.EnviarCorreo(mail.Trim, cuerpo, asunto, "", mailEnvia, mailEnviaPass, False)
    End Sub

    ''metodo que se encarga de enviar el correo con la informacion de la solicitud cerrada
    Private Sub enviar_Correo_Cerrado(ByVal sug As Integer)
        Dim sql As String = "SELECT mail,Mail_login  FROM Jjv_usuarios WHERE usuario = 'ADMIN'"
        Dim dt_admin As DataTable = objOpSimplesLn.listar_datatable(sql, "CORSAN")


        sql = "SELECT mail FROM V_nom_personal_Activo_con_maquila WHERE nit=" & cc_operario & ""
        Dim mail As String = objOpSimplesLn.consultValorTodo(sql, "CORSAN")

        Dim asunto As String = "SUGERENCIA CERRADA."
        Dim cuerpo As String = "SUGERENCIA CERRADA" & vbCrLf & _
                                "" & vbCrLf & _
                                "LA SUGERENCIA #" & sug & ",REALIZADA POR USTED HA SIDO CERRADA , POR FAVOR REVISAR EL SPIC."
        Dim mailEnvia As String = dt_admin.Rows(0).Item("mail")
        Dim mailEnviaPass As String = dt_admin.Rows(0).Item("Mail_login")
        obj_correoLn.EnviarCorreo(mail.Trim, cuerpo, asunto, "", mailEnvia, mailEnviaPass, False)
    End Sub
End Class