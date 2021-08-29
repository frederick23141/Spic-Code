Imports logicaNegocios
Imports entidadNegocios
Imports Microsoft.Office.Interop
Public Class FrmQuejaRec
    Private objQuejaRecLn As New QuejaRecLn
    Private usuarioEn As UsuarioEn
    Private objEnvCorreoLN As New EnvCorreoLN
    Private objOperacionesForm As New OperacionesFormularios
    Private objOpSimplesLn As New Op_simpesLn
    Private permiso As Boolean = True
    Private cargaComp As Boolean = False
    Private nom_modulo As String
    Private obj_correoLn As New EnvCorreoLN
    Dim fila_select As Integer
    Public Sub main(ByVal usuario As UsuarioEn, ByVal nom_modulo As String, ByVal permiso As String)
        OpenFileDialog1.Filter = "(*.Pdf)|*.Pdf"
        Dim sql As String = "SELECT id,descripcion FROM J_pqr_tipo_tratamiento"
        dtgEstado.DataSource = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        Me.nom_modulo = nom_modulo
        usuarioEn = usuario
        If (Trim(usuario.permiso) <> "SAC" And Trim(usuario.permiso) <> "ADMIN") Then
            dtgQuejaRec.ReadOnly = True
            permiso = False
            btnCerrar.Enabled = False
            btnCorreoResp.Enabled = False
        End If
        cbo_fecha_ini.Value = Now.AddMonths(-1)
        cbo_fecha_fin.Value = Now.Date
        chkAbierto.Checked = True
        pintar_col_calc()
        cargaComp = True
        If (permiso <> "ADMIN") Then
            btnContCambios.Visible = False
        End If
        OpenFileDialog1.DefaultExt = "pdf"
    End Sub
    Private Sub btnContCambios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnContCambios.Click
        FrmAuditCambios.Show()
        FrmAuditCambios.Main(nom_modulo)
        FrmAuditCambios.WindowState = 2
    End Sub
    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        dtgQuejaRec.Rows.Add()
        dtgQuejaRec.Item(col_tratamiento_pqr.Name, dtgQuejaRec.Rows.Count - 1).Value = "Pendiente"
        dtgQuejaRec.Item(col_id_tratamiento_pqr.Name, dtgQuejaRec.Rows.Count - 1).Value = 1
    End Sub
    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        FrmPrincipal.Show()
        Me.Close()
        FrmPrincipal.Activate()
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        FrmLogin.Show()
        FrmPrincipal.Close()
        Me.Close()
    End Sub


    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click

        Dim motivo As String = InputBox("ingrese motivo de cierre!")

        If (motivo <> "") Then
            dtgQuejaRec.Item("txtFecCierre", dtgQuejaRec.CurrentCell.RowIndex).Value = Now.Date
            dtgQuejaRec.Item("txtMcierre", dtgQuejaRec.CurrentCell.RowIndex).Value = motivo
            If (gudardar2() = 0) Then
                dtgQuejaRec.Item("txtFecCierre", dtgQuejaRec.CurrentCell.RowIndex).Value = ""
                dtgQuejaRec.Item("txtMcierre", dtgQuejaRec.CurrentCell.RowIndex).Value = ""
            Else
                Dim resp As Integer = MessageBox.Show("Desea enviar correo de confirmación de cierre de queja al cliente? ", "Mail", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If (resp = 6) Then
                    Dim nit As String = dtgQuejaRec.Item("txtNitCliente", dtgQuejaRec.CurrentCell.RowIndex).Value
                    Dim mail As String = objQuejaRecLn.consultValor("SELECT mail FROM  terceros WHERE nit = " & nit & "")
                    'Sele manda correo al cliente con copia al responsable del area
                    Dim asunto As String = "RESPUESTA CIERRE PQR NÚMERO: " & dtgQuejaRec.Item("txtId", dtgQuejaRec.CurrentCell.RowIndex).Value & " CORSAN"
                    Dim contenido As String = "Comprometidos en mejorar nuestro servicio y calidad, atender su requerimiento es un placer. Le informamos que su PQR ha sido gestionada y cerrada con " & vbCrLf & _
                                                "Motivo: " & motivo & vbCrLf &
                                                "Es un placer servirle." & vbCrLf & vbCrLf & vbCrLf & vbCrLf & _
                                                "Coordinación Servicio al Cliente" & vbCrLf & _
                                                "INDUSTRIAS METALICAS CORSAN S.A." & vbCrLf & _
                                                 "Tel.  (57) (4) 4440755 Ext 195" & vbCrLf & _
                                                 "Fax. (57) (4) 2855660" & vbCrLf & _
                                                "Cra. 42 No.  85B-71, Autopista Sur  Itagüí - Colombia"


                    Dim sql As String = "SELECT mail,Mail_login  FROM Jjv_usuarios WHERE usuario = 'PTR'"
                    Dim dt_admin As DataTable = objOpSimplesLn.listar_datatable(sql, "CORSAN")
                    Dim mailEnvia As String = dt_admin.Rows(0).Item("mail")
                    Dim mailEnviaPass As String = dt_admin.Rows(0).Item("Mail_login")
                    If obj_correoLn.EnviarCorreo(mail.Trim, contenido, asunto, "", mailEnvia, mailEnviaPass, False) Then
                        MessageBox.Show("El Correo se envio de Forma correcta", "Envio Exitoso", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("Error al enviar el correo.", "Error Correo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                    End If
                End If
                If Not ((chkCerrado.Checked) Or (chkAbierto.Checked = False And chkCerrado.Checked = False)) Then
                    dtgQuejaRec.Rows(dtgQuejaRec.CurrentCell.RowIndex).Visible = False
                Else
                    dtgQuejaRec.Item("txtDiasResp", dtgQuejaRec.CurrentCell.RowIndex).Value = objOpSimplesLn.calcDiasHabiles(dtgQuejaRec.Item("txtFecIng", dtgQuejaRec.CurrentCell.RowIndex).Value, dtgQuejaRec.Item("txtFecCierre", dtgQuejaRec.CurrentCell.RowIndex).Value)
                End If

            End If
        Else
            MessageBox.Show("Ingrese un motivo para cerrar la queja ó reclamo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If


    End Sub

    Private Sub btnCorreoCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCorreoCliente.Click
        If (Convert.ToString(dtgQuejaRec.Item("txtNitCliente", dtgQuejaRec.CurrentCell.RowIndex).Value) <> "") Then
            Dim resp As Double = dtgQuejaRec.Item("txtNitCliente", dtgQuejaRec.CurrentCell.RowIndex).Value
            Dim mail As String = objQuejaRecLn.consultValor("SELECT mail FROM  terceros WHERE nit = " & resp & "")
            Dim asunto As String = ""
            If (Convert.ToString(dtgQuejaRec.Item("txtId", dtgQuejaRec.CurrentCell.RowIndex).Value) <> "") Then
                asunto = "Pqr numero: " & dtgQuejaRec.Item("txtId", dtgQuejaRec.CurrentCell.RowIndex).Value
            End If
            enviarMail(mail, asunto)
        Else
            MessageBox.Show("Seleccione un cliente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If

    End Sub


    Private Sub dtgQuejaRec_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgQuejaRec.CellClick
        If (permiso) Then
            Dim numCol As Integer = e.ColumnIndex
            Dim nomCol As String = dtgQuejaRec.Columns(numCol).Name
            fila_select = e.RowIndex
            If (nomCol = "BtnGuardar") Then
                If (gudardar()) Then
                    Dim resp As Integer = MessageBox.Show("Desea enviar correo de confirmación de ingreso de queja al cliente? ", "Mail", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    If (resp = 6) Then
                        Dim nit As String = dtgQuejaRec.Item("txtNitCliente", dtgQuejaRec.CurrentCell.RowIndex).Value
                        Dim asunto As String = "ACUSO RECIBO PQR CORSAN"
                        Dim mail As String = objQuejaRecLn.consultValor("SELECT mail FROM  terceros WHERE nit = " & nit & "")
                        'Sele manda correo al cliente con copia al responsable del area
                        Dim contenido As String = "Usted es importante para nosotros por tanto, la información que nos transmita clara y oportuna nos ayuda a mejorar día a día." & vbCrLf & _
                                                    "Su PQR ha sido recibida e ingresada en nuestro sistema y será atendida por un agente SAC." & vbCrLf & vbCrLf & _
                                                    "Consecutivo asignado PQR: " & dtgQuejaRec.Item("txtId", dtgQuejaRec.CurrentCell.RowIndex).Value & vbCrLf & vbCrLf & vbCrLf & vbCrLf & _
                                                    "Coordinación de Servicio al Cliente" & vbCrLf & _
                                                    "INDUSTRIAS METALICAS CORSAN S.A." & vbCrLf & _
                                                     "Tel.  (57) (4) 4440755 Ext 195" & vbCrLf & _
                                                     "Fax. (57) (4) 2855660" & vbCrLf & _
                                                    "Cra. 42 No.  85B-71, Autopista Sur  Itagüí - Colombia"

                        mail = "JDBAYER09@GMAIL.COM"
                        Dim sql As String = "SELECT mail,Mail_login  FROM Jjv_usuarios WHERE usuario = 'PTR'"
                        Dim dt_admin As DataTable = objOpSimplesLn.listar_datatable(sql, "CORSAN")
                        Dim mailEnvia As String = dt_admin.Rows(0).Item("mail")
                        Dim mailEnviaPass As String = dt_admin.Rows(0).Item("Mail_login")

                        If obj_correoLn.EnviarCorreo(mail.Trim, contenido, asunto, "", mailEnvia, mailEnviaPass, False) Then
                            MessageBox.Show("El Correo se envio de Forma correcta", "Envio Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Else
                            MessageBox.Show("Error al enviar el correo.", "Error Correo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If
                    End If
                End If
            ElseIf (nomCol = "btnBorrar") Then
                Dim resp As Integer = MessageBox.Show("Esta seguro que desea eliminar el registro? ", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If (resp = 6) Then
                    eliminar()
                End If
            ElseIf (nomCol = "txtCliente") Then
                Dim frm As New FrmTerceros
                frm.Show()
                frm.main("quejas", e.RowIndex, "txtCliente")
                frm.Text = "CLIENTES"
            ElseIf (nomCol = "txtResp") Then
                Dim frm As New FrmTerceros
                frm.Show()
                frm.main("quejas", e.RowIndex, "txtResp")
                frm.Text = "RESPONSABLES"
            ElseIf (nomCol = "txtInsatis") Then
                Dim frm As New FrmTerceros
                frm.Show()
                frm.main("quejas", e.RowIndex, "txtInsatis")
                frm.Text = "INSATISFACCIÓN"
                frm.lblNit.Text = "Id"
                frm.lblNombres.Text = "Descripción"
            ElseIf (nomCol = "txtPqr") Then
                Dim frm As New FrmTerceros
                frm.Show()
                frm.main("quejas", e.RowIndex, "txtPqr")
                frm.Text = "PQR"
                frm.lblNit.Text = "Id"
                frm.lblNombres.Text = "Descripción"
            ElseIf (nomCol = "txtNotaCredito") Then
                If (Convert.ToString(dtgQuejaRec.Item("txtNitCliente", e.RowIndex).Value) <> "") Then
                    Dim frm As New FrmDvrNcmc
                    frm.Show()
                    frm.main(e.RowIndex, dtgQuejaRec.Item("txtNitCliente", e.RowIndex).Value)
                Else
                    MessageBox.Show("Seleccione un cliente para ver sus DVR-NCMC", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            ElseIf (nomCol = "txtFecIng") Then
                cboCal.Visible = True
            ElseIf (nomCol = "txtCodigo") Then
                Dim frm As New FrmTerceros
                frm.Show()
                frm.main("quejas", e.RowIndex, "txtCodigo")
                frm.Text = "PRODUCTOS"
                frm.lblNit.Text = "Código"
                frm.lblNombres.Text = "Descripción"
            ElseIf (nomCol = col_tratamiento_pqr.Name) Then
                If Not IsNothing(dtgQuejaRec.Item(txtId.Name, dtgQuejaRec.CurrentCell.RowIndex).Value) Then
                    group_estado.Visible = True
                End If
            ElseIf (nomCol = col_doc.Name) Then
                If Not IsNothing(dtgQuejaRec.Item(txtId.Name, dtgQuejaRec.CurrentCell.RowIndex).Value) Then
                    Dim sql As String = "SELECT ruta_doc FROM J_quejas_rec WHERE id_queja=" & dtgQuejaRec.Item(txtId.Name, dtgQuejaRec.CurrentCell.RowIndex).Value
                    Dim ruta As String = objOpSimplesLn.consultarVal(sql)
                    If ruta <> "" Then
                        Dim proc As New Process
                        proc.StartInfo.FileName = ruta
                        proc.StartInfo.Verb = "Open"
                        proc.Start()
                    Else
                        MessageBox.Show("No se a adjuntado ningun archivo a la Pqr", "Sin adjunto", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                End If


            End If
        End If
    End Sub
    Private Sub cboCal_DateSelected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DateRangeEventArgs) Handles cboCal.DateSelected
        dtgQuejaRec.Item("txtFecIng", dtgQuejaRec.CurrentCell.RowIndex).Value = (cboCal.SelectionEnd.Date)
        cboCal.Visible = False
    End Sub
    Private Function gudardar() As Integer
        Dim fila As Integer = dtgQuejaRec.CurrentCell.RowIndex
        Dim resp As Boolean = False
        If (validarCampos(fila)) Then
            Dim listaSql As New List(Of Object)
            Dim vecSql(10) As String
            Dim operacion As String = ""
            Dim sql As String = ""
            Dim desc As String = ""
            Dim existe As Boolean = False
            Dim id_queja As Double = dtgQuejaRec.Item("txtId", fila).Value
            Dim responsable As Double = dtgQuejaRec.Item("txtidResp", fila).Value
            Dim nit As Double = dtgQuejaRec.Item("txtNitCliente", fila).Value
            Dim insatisfact As String = dtgQuejaRec.Item("txtIdInsaticfac", fila).Value
            Dim fecIng As String = Now.Year & "/" & Now.Month & "/" & Now.Day
            Dim pqr As Double = dtgQuejaRec.Item("txtIdPqr", fila).Value
            Dim descProb As String = dtgQuejaRec.Item("txtDescProblema", fila).Value
            Dim causas As String = dtgQuejaRec.Item("txtCausasDetect", fila).Value
            Dim acciones As String = dtgQuejaRec.Item("txtAcciones", fila).Value
            Dim monto As Double = 0
            If IsNumeric(dtgQuejaRec.Item("txtMonto", fila).Value) Then
                monto = dtgQuejaRec.Item("txtMonto", fila).Value
            End If
            Dim flete As Double = 0
            If Not IsDBNull(dtgQuejaRec.Item(col_flete.Name, fila).Value) Then
                flete = dtgQuejaRec.Item(col_flete.Name, fila).Value
            End If
            Dim fecCierre As String = "1900/1/1"
            Dim motivoCierre As String = dtgQuejaRec.Item("txtMcierre", fila).Value
            Dim codigos As String = dtgQuejaRec.Item("txtCodigo", fila).Value
            Dim consec As Integer = 0
            Dim codigo As String = ""
            Dim observaciones As String = dtgQuejaRec.Item("txtObservacion", fila).Value
            Dim ncmc As Double = dtgQuejaRec.Item("txtNotaCredito", fila).Value
            Dim fecCierrreSql As String = ""
            If (id_queja <> 0) Then
                existe = objQuejaRecLn.existeReg("Select id_queja FROM J_quejas_rec WHERE id_queja = " & id_queja)
            End If
            If (existe) Then
                'Se cambio ya que podia modificar las fechas de ingreso de las pqr, para evitar ese error
                'sql = "UPDATE J_quejas_rec  SET responsable  = '" & responsable & "',cliente = " & nit & ", insatisfaccion= '" & insatisfact & "',fecha_ingreso='" & fecIng & "',pqr= " & pqr & ",desc_problema='" & descProb & "',causas_detect='" & causas & "',acciones_seguir='" & acciones & "',monto =" & monto & ",flete = " & flete & ",fecha_cierre='" & fecCierre & "',motivo_cierre='" & motivoCierre & "',observaciones= '" & observaciones & "',ncmc = " & ncmc & " " & _
                '                " WHERE id_queja = " & id_queja & " "
                sql = "UPDATE J_quejas_rec  SET responsable  = '" & responsable & "',cliente = " & nit & ", insatisfaccion= '" & insatisfact & "',pqr= " & pqr & ",desc_problema='" & descProb & "',causas_detect='" & causas & "',acciones_seguir='" & acciones & "',monto =" & monto & ",flete = " & flete & ",fecha_cierre='" & fecCierre & "',motivo_cierre='" & motivoCierre & "',observaciones= '" & observaciones & "',ncmc = " & ncmc & " " & _
                " WHERE id_queja = " & id_queja & " "
                operacion = "actualizado"
                listaSql.Add(sql)
                consec = id_queja
                sql = "DELETE FROM J_quejas_rec_det  WHERE idQuejaRec =" & consec
                listaSql.Add(sql)
            Else
                consec = (objQuejaRecLn.genConsect("SELECT MAX(id_queja) FROM  J_quejas_rec"))
                sql = "INSERT INTO  J_quejas_rec  ( id_queja, responsable, cliente, insatisfaccion, fecha_ingreso, pqr, desc_problema, causas_detect, acciones_seguir, monto, fecha_cierre, motivo_cierre, observaciones, ncmc ) " & _
                        " VALUES (" & consec & ",'" & responsable & "'," & nit & ",'" & insatisfact & "','" & fecIng & "'," & pqr & ",'" & descProb & "','" & causas & "','" & acciones & "'," & monto & ",'" & fecCierre & "','" & motivoCierre & "','" & observaciones & "'," & ncmc & ")"
                operacion = "guadado"
                listaSql.Add(sql)
            End If
            codigos = Trim(codigos)
            If (codigos <> "") Then
                For i = 0 To codigos.Length - 1
                    If (codigos(i) <> "-") Then
                        If (codigos(i) <> "" & vbCr & "" And codigos(i) <> "" & vbLf & "") Then
                            codigo += codigos(i)
                        End If
                    End If
                    If (codigos(i) = "-" Or i = codigos.Length - 1) Then
                        sql = "INSERT INTO  J_quejas_rec_det (Codigo,idQuejaRec) VALUES ('" & codigo & "'," & consec & ")"
                        codigo = ""
                        listaSql.Add(sql)
                    End If
                Next
            End If

            resp = objQuejaRecLn.ExecuteSqlTransaction(listaSql)
            If (resp) Then
                If (operacion = "guadado") Then
                    dtgQuejaRec.Item("txtId", fila).Value = consec
                    Dim id_estado As Double = dtgQuejaRec.Item(col_id_tratamiento_pqr.Name, fila).Value
                    Dim desc_estado As String = dtgQuejaRec.Item(col_tratamiento_pqr.Name, fila).Value
                    cambiar_estado_pqr("Ingreso de Pqr", id_estado, desc_estado)
                End If
                MessageBox.Show("" & operacion & " en forma exitosa", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Erorr al " & operacion, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            MessageBox.Show("Los campos : Responsable, insatisfacción,cliente,pqr,descripción del problema,fecha de ingreso son obligatorios", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        Return resp
    End Function

    Private Function gudardar2() As Integer
        Dim fila As Integer = dtgQuejaRec.CurrentCell.RowIndex
        Dim resp As Boolean = False
        If (validarCampos(fila)) Then
            Dim listaSql As New List(Of Object)
            Dim vecSql(10) As String
            Dim operacion As String = ""
            Dim sql As String = ""
            Dim desc As String = ""
            Dim existe As Boolean = False
            Dim id_queja As Double = dtgQuejaRec.Item("txtId", fila).Value
            Dim responsable As Double = dtgQuejaRec.Item("txtidResp", fila).Value
            Dim nit As Double = dtgQuejaRec.Item("txtNitCliente", fila).Value
            Dim insatisfact As String = dtgQuejaRec.Item("txtIdInsaticfac", fila).Value
            Dim fecIng As String = Now.Year & "/" & Now.Month & "/" & Now.Day
            Dim pqr As Double = dtgQuejaRec.Item("txtIdPqr", fila).Value
            Dim descProb As String = dtgQuejaRec.Item("txtDescProblema", fila).Value
            Dim causas As String = dtgQuejaRec.Item("txtCausasDetect", fila).Value
            Dim acciones As String = dtgQuejaRec.Item("txtAcciones", fila).Value
            Dim monto As Double = 0
            If IsNumeric(dtgQuejaRec.Item("txtMonto", fila).Value) Then
                monto = dtgQuejaRec.Item("txtMonto", fila).Value
            End If
            Dim flete As Double = 0
            If Not IsDBNull(dtgQuejaRec.Item(col_flete.Name, fila).Value) Then
                flete = dtgQuejaRec.Item(col_flete.Name, fila).Value
            End If
            Dim fecCierre As String = Now.Year & "/" & Now.Month & "/" & Now.Day
            Dim motivoCierre As String = dtgQuejaRec.Item("txtMcierre", fila).Value
            Dim codigos As String = dtgQuejaRec.Item("txtCodigo", fila).Value
            Dim consec As Integer = 0
            Dim codigo As String = ""
            Dim observaciones As String = dtgQuejaRec.Item("txtObservacion", fila).Value
            Dim ncmc As Double = dtgQuejaRec.Item("txtNotaCredito", fila).Value
            Dim fecCierrreSql As String = ""
            If (id_queja <> 0) Then
                existe = objQuejaRecLn.existeReg("Select id_queja FROM J_quejas_rec WHERE id_queja = " & id_queja)
            End If
            If (existe) Then
                'Se cambio ya que podia modificar las fechas de ingreso de las pqr, para evitar ese error
                'sql = "UPDATE J_quejas_rec  SET responsable  = '" & responsable & "',cliente = " & nit & ", insatisfaccion= '" & insatisfact & "',fecha_ingreso='" & fecIng & "',pqr= " & pqr & ",desc_problema='" & descProb & "',causas_detect='" & causas & "',acciones_seguir='" & acciones & "',monto =" & monto & ",flete = " & flete & ",fecha_cierre='" & fecCierre & "',motivo_cierre='" & motivoCierre & "',observaciones= '" & observaciones & "',ncmc = " & ncmc & " " & _
                '                " WHERE id_queja = " & id_queja & " "
                sql = "UPDATE J_quejas_rec  SET responsable  = '" & responsable & "',cliente = " & nit & ", insatisfaccion= '" & insatisfact & "',pqr= " & pqr & ",desc_problema='" & descProb & "',causas_detect='" & causas & "',acciones_seguir='" & acciones & "',monto =" & monto & ",flete = " & flete & ",fecha_cierre='" & fecCierre & "',motivo_cierre='" & motivoCierre & "',observaciones= '" & observaciones & "',ncmc = " & ncmc & " " & _
                " WHERE id_queja = " & id_queja & " "
                operacion = "actualizado"
                listaSql.Add(sql)
                consec = id_queja
                sql = "DELETE FROM J_quejas_rec_det  WHERE idQuejaRec =" & consec
                listaSql.Add(sql)
            Else
                consec = (objQuejaRecLn.genConsect("SELECT MAX(id_queja) FROM  J_quejas_rec"))
                sql = "INSERT INTO  J_quejas_rec  ( id_queja, responsable, cliente, insatisfaccion, fecha_ingreso, pqr, desc_problema, causas_detect, acciones_seguir, monto, fecha_cierre, motivo_cierre, observaciones, ncmc ) " & _
                        " VALUES (" & consec & ",'" & responsable & "'," & nit & ",'" & insatisfact & "','" & fecIng & "'," & pqr & ",'" & descProb & "','" & causas & "','" & acciones & "'," & monto & ",'" & fecCierre & "','" & motivoCierre & "','" & observaciones & "'," & ncmc & ")"
                operacion = "guadado"
                listaSql.Add(sql)
            End If
            codigos = Trim(codigos)
            If (codigos <> "") Then
                For i = 0 To codigos.Length - 1
                    If (codigos(i) <> "-") Then
                        If (codigos(i) <> "" & vbCr & "" And codigos(i) <> "" & vbLf & "") Then
                            codigo += codigos(i)
                        End If
                    End If
                    If (codigos(i) = "-" Or i = codigos.Length - 1) Then
                        sql = "INSERT INTO  J_quejas_rec_det (Codigo,idQuejaRec) VALUES ('" & codigo & "'," & consec & ")"
                        codigo = ""
                        listaSql.Add(sql)
                    End If
                Next
            End If

            resp = objQuejaRecLn.ExecuteSqlTransaction(listaSql)
            If (resp) Then
                If (operacion = "guadado") Then
                    dtgQuejaRec.Item("txtId", fila).Value = consec
                    Dim id_estado As Double = dtgQuejaRec.Item(col_id_tratamiento_pqr.Name, fila).Value
                    Dim desc_estado As String = dtgQuejaRec.Item(col_tratamiento_pqr.Name, fila).Value
                    cambiar_estado_pqr("Ingreso de Pqr", id_estado, desc_estado)
                End If
                MessageBox.Show("" & operacion & " en forma exitosa", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Erorr al " & operacion, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            MessageBox.Show("Los campos : Responsable, insatisfacción,cliente,pqr,descripción del problema,fecha de ingreso son obligatorios", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        Return resp
    End Function
    Private Sub eliminar()
        Dim listaSql As New List(Of Object)
        Dim fila As Integer = dtgQuejaRec.CurrentCell.RowIndex
        Dim sql As String = ""
        Dim resp As Boolean = 0
        Dim id_queja As Double = dtgQuejaRec.Item("txtId", fila).Value
        If (Convert.ToString(dtgQuejaRec.Item("txtId", fila).Value) <> "") Then
            sql = "DELETE FROM J_quejas_rec_det  WHERE idQuejaRec =" & id_queja
            listaSql.Add(sql)
            sql = "DELETE FROM J_quejas_rec WHERE id_queja = " & id_queja
            listaSql.Add(sql)
            resp = objQuejaRecLn.ExecuteSqlTransaction(listaSql)
            If (resp) Then
                MessageBox.Show("Se elimino en forma exitosa", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Erorr al eliminar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
        dtgQuejaRec.Rows(fila).Visible = False
    End Sub
    Public Sub pintar_col_calc()
        For i = 0 To dtgQuejaRec.ColumnCount - 1
            If (dtgQuejaRec.Columns(i).Name = "txtFecIng" Or dtgQuejaRec.Columns(i).Name = "txtCliente" Or dtgQuejaRec.Columns(i).Name = "txtPqr" Or dtgQuejaRec.Columns(i).Name = "txtResp" Or dtgQuejaRec.Columns(i).Name = "txtCodigo" Or dtgQuejaRec.Columns(i).Name = "txtNotaCredito" Or dtgQuejaRec.Columns(i).Name = "txtInsatis") Then
                dtgQuejaRec.Columns(i).HeaderCell.Style.BackColor = Color.GreenYellow
                dtgQuejaRec.Columns(i).HeaderCell.Style.ForeColor = Color.Black
            End If
        Next
    End Sub
    Private Sub dtgQuejaRec_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dtgQuejaRec.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            With (Me.dtgQuejaRec)
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                End If
            End With
            Dim numCol As Integer = dtgQuejaRec.CurrentCell.ColumnIndex
            Dim nombCol As String = dtgQuejaRec.Columns(dtgQuejaRec.CurrentCell.ColumnIndex).Name
            If (nombCol = "txtCodigo") Then
                EditarCampoToolStripMenuItem.Visible = True
            Else
                EditarCampoToolStripMenuItem.Visible = False
            End If
            fila_select = dtgQuejaRec.CurrentCell.RowIndex
        End If
    End Sub
    Public Function FechaSQL(ByVal fecha As Date) As String
        Dim fechaFormateada As String
        fechaFormateada = fecha.Year & "/" & fecha.Month & "/" & fecha.Day
        Return fechaFormateada
    End Function
Private Sub consultar()
        dtgQuejaRec.Rows.Clear()
        Dim condicion As String = "WHERE "
        Dim fecIni As String = objOpSimplesLn.cambiarFormatoFecha(cbo_fecha_ini.Value.Date)
        Dim fecFin As String = objOpSimplesLn.cambiarFormatoFecha(cbo_fecha_fin.Value.Date)
        condicion += " fecha_ingreso >= '" & fecIni & "' AND fecha_ingreso<= '" & fecFin & "' "
        If (txtBuscar.Text <> "") Then
            condicion += " AND id_queja  = '" & txtBuscar.Text & "' "
        ElseIf (txtNit.Text <> "") Then
            condicion += " AND cliente  like '" & txtNit.Text & "%' "
        ElseIf (txtNombres.Text <> "") Then
            condicion += " AND nomCliente  like '%" & txtNombres.Text & "%' "
        ElseIf Not (chkAbierto.Checked And chkCerrado.Checked) Then
            If (chkAbierto.Checked) Then
                condicion += " AND fecha_cierre = '1/1/1900 00:00:00'"
            ElseIf (chkCerrado.Checked) Then
                condicion += " AND fecha_cierre <> '1/1/1900 12:00:00 AM'"
            End If
        End If
        If (txt_codigo_filtrar.Text.Trim <> "") Then
            condicion &= " AND id_queja IN (SELECT idQuejaRec FROM J_quejas_rec_det WHERE codigo like '" & txt_codigo_filtrar.Text.Trim & "%') "
        End If
        Select Case Trim(usuarioEn.permiso)
            Case "PRODUCCION"
                condicion += " AND (idResp=" & 1 & " OR idResp=" & 4 & ")"
        End Select

        Dim sql As String = "SELECT   id_queja, descAreaResp, idResp, cliente, nomCliente, insatisfaccion, descInsatis, fecha_ingreso, pqr, descPqr, desc_problema, " & _
                                   "causas_detect, acciones_seguir, monto, fecha_cierre, motivo_cierre, observaciones,   ncmc, nitResp,vendedor,flete,ciudad " & _
                                     "FROM J_V_quejas_rec " & _
                                        condicion
        Dim numCol As Integer = 22
        Dim mat(,) As Object = objQuejaRecLn.listar_vector(sql, numCol)
        Dim tam As Integer = UBound(mat) - LBound(mat)
        progBar.Maximum = tam
        progBar.Minimum = 0
        'If (tam = 0) Then
        '    tam = -1 'Se pone esto por que cuando no hay registro, el sistema en el siguiente ciclo entra 1 vez
        'End If
        For i = 0 To tam
            progBar.Value = i
            dtgQuejaRec.Rows.Add()
            dtgQuejaRec.Item("txtId", i).Value = mat(i, 0)
            dtgQuejaRec.Item("txtResp", i).Value = mat(i, 1)
            dtgQuejaRec.Item("txtidResp", i).Value = mat(i, 2)
            dtgQuejaRec.Item("txtNitCliente", i).Value = mat(i, 3)
            dtgQuejaRec.Item("txtCliente", i).Value = mat(i, 4)
            dtgQuejaRec.Item("txtIdInsaticfac", i).Value = mat(i, 5)
            dtgQuejaRec.Item("txtInsatis", i).Value = mat(i, 6)
            dtgQuejaRec.Item("txtFecIng", i).Value = mat(i, 7)
            dtgQuejaRec.Item("txtIdPqr", i).Value = mat(i, 8)
            dtgQuejaRec.Item("txtPqr", i).Value = mat(i, 9)
            dtgQuejaRec.Item("txtDescProblema", i).Value = mat(i, 10)
            dtgQuejaRec.Item("txtCausasDetect", i).Value = mat(i, 11)
            dtgQuejaRec.Item("txtAcciones", i).Value = mat(i, 12)
            dtgQuejaRec.Item("txtMonto", i).Value = mat(i, 13)
            If Convert.ToString((mat(i, 14)) = "1/1/1900 12:00:00 AM") Then
                mat(i, 14) = ""
            End If
            dtgQuejaRec.Item("txtFecCierre", i).Value = mat(i, 14)
            dtgQuejaRec.Item("txtMcierre", i).Value = mat(i, 15)
            dtgQuejaRec.Item("txtObservacion", i).Value = mat(i, 16)
            'dtgQuejaRec.Item("txtCodigo", i).Value = mat(i, 17)
            dtgQuejaRec.Item("txtNotaCredito", i).Value = mat(i, 17)
            dtgQuejaRec.Item("txtNitResp", i).Value = mat(i, 18)
            dtgQuejaRec.Item("txtCodigo", i).Value = mat(i, 19)
            If Not (IsNothing(mat(i, 19))) Then
                If (mat(i, 19) <> "") Then
                    actTxtDesc(mat(i, 19), i)
                End If
            End If
            dtgQuejaRec.Item("colVend", i).Value = mat(i, 20)
            dtgQuejaRec.Item(col_flete.Name, i).Value = mat(i, 21)
            dtgQuejaRec.Item(col_ciudad.Name, i).Value = mat(i, 22)
            estado_queja(i)
            If (Convert.ToString(mat(i, 14)) <> "") Then
                dtgQuejaRec.Item("txtDiasResp", i).Value = objOpSimplesLn.calcDiasHabiles(dtgQuejaRec.Item("txtFecIng", i).Value, dtgQuejaRec.Item("txtFecCierre", i).Value)
            End If
        Next
        progBar.Value = 0
    End Sub
    Private Sub btnActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActualizar.Click
        If tab_ppal.SelectedTab.Name = tab_quejas.Name Then
            consultar()
        Else
            cargar_dias_transito()
        End If
    End Sub
    Private Sub cargar_dias_transito()
        dtg_transito.DataSource = Nothing
        Dim tamano_letra As Single = 9.0!
        Dim condicion As String = ""
        Dim fecIni As String = objOpSimplesLn.cambiarFormatoFecha(cbo_fecha_ini.Value.Date)
        Dim fecFin As String = objOpSimplesLn.cambiarFormatoFecha(cbo_fecha_fin.Value.Date)
        Dim calcular As Boolean = False
        condicion += " AND q.fecha_ingreso >= '" & fecIni & "' AND q.fecha_ingreso<= '" & fecFin & "' "
        If (txtBuscar.Text <> "") Then
            condicion += " AND q.id_queja  = '" & txtBuscar.Text & "' "
        ElseIf (txtNit.Text <> "") Then
            condicion += " AND q.cliente  like '" & txtNit.Text & "%' "
        ElseIf (txtNombres.Text <> "") Then
            condicion += " AND q.nomCliente  like '%" & txtNombres.Text & "%' "
        ElseIf Not (chkAbierto.Checked And chkCerrado.Checked) Then
            If (chkAbierto.Checked) Then
                condicion += " AND q.fecha_cierre = '1/1/1900 12:00:00 AM'"
            ElseIf (chkCerrado.Checked) Then
                condicion += " AND q.fecha_cierre <> '1/1/1900 12:00:00 AM'"
            End If
        End If
        Select Case Trim(usuarioEn.permiso)
            Case "PRODUCCION"
                condicion += " AND (idResp=" & 1 & " OR idResp=" & 4 & ")"
        End Select
        Dim sql As String = "SELECT t.id,z.id_queja ,q.fecha_ingreso,t.descripcion,CAST(z.fecha As date ) As fecha_cambio,z.usuario,z.observaciones,z.id As id_tras  " & _
                         "FROM J_pqr_tipo_tratamiento t ,J_pqr_trasabilidad_tratamiento z ,J_V_quejas_rec q  " & _
                            "WHERE t.id = z.id_tratamiento AND z.anulado is null AND q.id_queja = z.id_queja " & condicion & " " & _
                                    "ORDER BY z.id_queja ,z.fecha "

        Dim dt As DataTable = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        Dim fecha As New Date
        Dim queja_ant As Double = 0
        Dim dias As Integer = 0
        dt.Columns.Add("dias_transito")
        For i = 0 To dt.Rows.Count - 1
            If i + 1 < dt.Rows.Count Then
                If i = 0 Then
                    queja_ant = dt.Rows(i).Item("id_queja")
                End If
                If queja_ant <> dt.Rows(i).Item("id_queja") Then
                    queja_ant = dt.Rows(i).Item("id_queja")
                End If
                If i + 1 <= dt.Rows.Count Then
                    calcular = True
                Else
                    calcular = False
                End If
                If calcular Then
                    If dt.Rows(i).Item("id_queja") <> dt.Rows(i + 1).Item("id_queja") Then
                        calcular = False
                    End If
                End If
                If calcular Then
                    If Not IsDBNull(dt.Rows(i).Item("fecha_cambio")) Then
                        If Not IsDBNull(dt.Rows(i + 1).Item("fecha_cambio")) Then
                            dias = DateDiff(DateInterval.Day, dt.Rows(i).Item("fecha_cambio"), dt.Rows(i + 1).Item("fecha_cambio"))
                        Else
                            dias = DateDiff(DateInterval.Day, dt.Rows(i).Item("fecha_cambio"), Now.Date)
                        End If
                        dt.Rows(i).Item("dias_transito") = dias
                    End If
                Else
                    dt.Rows(i).Item("dias_transito") = 0
                End If
            End If
        Next
        If chk_consol_estados.Checked() Then
            Dim view As New DataView
            view = New DataView(consolidar_dias_transito(dt))
            view.Sort = "id"
            dtg_transito.DataSource = view
        Else
            dtg_transito.DataSource = dt
            dtg_transito.Columns("fecha_cambio").DefaultCellStyle.Format = "G"
        End If
        dtg_transito.Columns("dias_transito").DefaultCellStyle = objOperacionesForm.formatoNegrita(tamano_letra)

    End Sub
    Private Function consolidar_dias_transito(ByRef dt As DataTable) As DataTable
        Dim dt_nuevo As New DataTable
        dt_nuevo.Columns.Add("id")
        dt_nuevo.Columns.Add("descripcion")
        dt_nuevo.Columns.Add("dias_transito", GetType(Double))
        Dim fila As Integer = 0
        For i = 0 To dt.Rows.Count - 1
            If IsNumeric(dt.Rows(i).Item("id")) Then
                fila = buscar_id_transito(dt_nuevo, dt.Rows(i).Item("id"))
                If fila = -1 Then
                    dt_nuevo.Rows.Add()
                    dt_nuevo.Rows(dt_nuevo.Rows.Count - 1).Item("id") = dt.Rows(i).Item("id")
                    dt_nuevo.Rows(dt_nuevo.Rows.Count - 1).Item("descripcion") = dt.Rows(i).Item("descripcion")
                    If IsNumeric(dt.Rows(i).Item("dias_transito")) Then
                        dt_nuevo.Rows(dt_nuevo.Rows.Count - 1).Item("dias_transito") = dt.Rows(i).Item("dias_transito")
                    Else
                        dt_nuevo.Rows(dt_nuevo.Rows.Count - 1).Item("dias_transito") = 0
                    End If
                Else
                    If IsNumeric(dt.Rows(i).Item("dias_transito")) Then
                        dt_nuevo.Rows(fila).Item("dias_transito") += dt.Rows(i).Item("dias_transito")
                    End If
                End If
            End If
        Next
        Return dt_nuevo
    End Function
    Private Function buscar_id_transito(ByRef dt As DataTable, ByVal id_queja As Integer) As Integer
        Dim fila As Integer = -1
        Dim dt_nuevo As New DataTable
        For i = 0 To dt.Rows.Count - 1
            If IsNumeric(dt.Rows(i).Item("id")) Then
                If dt.Rows(i).Item("id") = id_queja Then
                    fila = i
                    i = dt.Rows.Count - 1
                End If
            End If
        Next
        Return fila
    End Function
    Private Sub btnCorreoResp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCorreoResp.Click
        If (Convert.ToString(dtgQuejaRec.Item("txtNitResp", dtgQuejaRec.CurrentCell.RowIndex).Value) <> "") Then
            Dim resp As Double = dtgQuejaRec.Item("txtNitResp", dtgQuejaRec.CurrentCell.RowIndex).Value
            Dim mailResp As String = objQuejaRecLn.consultValor("SELECT email2 FROM  terceros WHERE nit = " & resp & "")
            Dim asunto As String = ""
            If (Convert.ToString(dtgQuejaRec.Item("txtId", dtgQuejaRec.CurrentCell.RowIndex).Value) <> "") Then
                asunto = "Pqr numero: " & dtgQuejaRec.Item("txtId", dtgQuejaRec.CurrentCell.RowIndex).Value
            End If
            enviarMail(mailResp, asunto)
        Else
            MessageBox.Show("Seleccione un responsable", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If

    End Sub
    Private Sub enviarMail(ByVal destino As String, ByVal asunto As String)
        FrmDatosMail.Show()
        FrmDatosMail.Visible = True
        FrmDatosMail.txtA.Text = destino
        FrmDatosMail.txtUsuario.Text = usuarioEn.Email
        FrmDatosMail.txtContra.Text = usuarioEn.EmailClave
        FrmDatosMail.LinkLabel1.Visible = False
        FrmDatosMail.txtAsunto.Text = asunto
        FrmDatosMail.Activate()
    End Sub
    Private Function validarCampos(ByVal fila As Integer) As Boolean
        If (Convert.ToString(dtgQuejaRec.Item("txtResp", fila).Value) <> "" And Convert.ToString(dtgQuejaRec.Item("txtInsatis", fila).Value) <> "" And Convert.ToString(dtgQuejaRec.Item("txtCliente", fila).Value) <> "" And Convert.ToString(dtgQuejaRec.Item("txtIdPqr", fila).Value) <> "" And Convert.ToString(dtgQuejaRec.Item("txtDescProblema", fila).Value) <> "" And Convert.ToString(dtgQuejaRec.Item("txtFecIng", fila).Value) <> "") Then
            Return True
        Else
            Return False

        End If
    End Function

    Private Sub chkAbierto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAbierto.CheckedChanged
        txtBuscar.Text = ""
    End Sub

    Private Sub chkCerrado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCerrado.CheckedChanged
        txtBuscar.Text = ""
    End Sub
    Private Function validar_Mail(ByVal sMail As String) As Boolean
        Dim emailRegex As New System.Text.RegularExpressions.Regex("^(?<user>[^@]+)@(?<host>.+)$")
        If IsNothing(sMail) Then
            sMail = ""
        End If
        Dim emailMatch As System.Text.RegularExpressions.Match =
           emailRegex.Match(sMail)
        Return emailMatch.Success
    End Function
    Private Sub enviarConfirmacion(ByVal asunto As String, ByVal cuerpo As String, ByVal mail As String)
        Dim mailEnvia As String = usuarioEn.Email
        Dim mailEnviaPass As String = usuarioEn.EmailClave
        If (validar_Mail(mail)) Then
            objEnvCorreoLN.EnviarCorreo(mail, cuerpo, asunto, "", mailEnvia, mailEnviaPass, False)
        Else
            MessageBox.Show("No se pudo enviar la confirmación ya que el cliente no tiene un mail valido,verifique datos del tercero!", "verifique", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub
    Private Sub btnCorreoFacili_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCorreoFacili.Click
        Dim asunto As String = ""
        If (Convert.ToString(dtgQuejaRec.Item("txtId", dtgQuejaRec.CurrentCell.RowIndex).Value) <> "") Then
            asunto = "Pqr numero: " & dtgQuejaRec.Item("txtId", dtgQuejaRec.CurrentCell.RowIndex).Value
        End If
        enviarMail("serviciocliente@corsan.com.co", asunto)
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        FrmConsultQuejasRec.Show()
        FrmConsultQuejasRec.Activate()
    End Sub
    Private Sub EditarCampoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditarCampoToolStripMenuItem.Click
        Dim numCol As Integer = dtgQuejaRec.CurrentCell.ColumnIndex
        Dim nombCol As String = dtgQuejaRec.Columns(dtgQuejaRec.CurrentCell.ColumnIndex).Name
        If (nombCol = "txtCodigo") Then
            Dim valor As String = dtgQuejaRec.Item("txtCodigo", dtgQuejaRec.CurrentCell.RowIndex).Value
            Dim total As String = ""
            Dim codigo As String = ""
            total = quitarSaltos(valor)
            Dim resp As String = InputBox("Borre las  referencias hasta '-' , luego precione aceptar", "Eliminar", total)
            If (resp <> "") Then
                total = ponerSaltos(resp)
                dtgQuejaRec.Item("txtCodigo", dtgQuejaRec.CurrentCell.RowIndex).Value = total
                actTxtDesc(total, dtgQuejaRec.CurrentCell.RowIndex)
            Else
                Dim resp2 As Integer = MessageBox.Show("Desea dejar la totalidad del campo en blanco? ", "limpiar", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If (resp2 = 6) Then
                    total = ponerSaltos(resp)
                    dtgQuejaRec.Item("txtCodigo", dtgQuejaRec.CurrentCell.RowIndex).Value = total
                    actTxtDesc(total, dtgQuejaRec.CurrentCell.RowIndex)
                End If

            End If

        End If

    End Sub
    Private Function quitarSaltos(ByVal valor As String)
        Dim total As String = ""
        Dim codigo As String = ""
        For i = 0 To valor.Length - 1
            If (valor(i) <> "-") Then
                If (valor(i) <> "" & vbCr & "" And valor(i) <> "" & vbLf & "") Then
                    codigo += valor(i)

                End If
            End If
            If ((valor(i) = "-" Or i = valor.Length - 1) And codigo <> "") Then
                total += codigo
                If (i <> valor.Length - 1) Then
                    total += "-"
                End If
                codigo = ""
            End If
        Next
        Return total
    End Function
    Private Function ponerSaltos(ByVal valor As String)
        Dim total As String = ""
        Dim codigo As String = ""
        For i = 0 To valor.Length - 1
            If (valor(i) <> "-") Then
                If (valor(i) <> "" & vbCr & "" And valor(i) <> "" & vbLf & "") Then
                    codigo += valor(i)
                End If
            End If
            If ((valor(i) = "-" Or i = valor.Length - 1) And (codigo <> "")) Then
                total += codigo
                If (i <> valor.Length - 1) Then
                    total += "-" & vbCrLf
                End If
                codigo = ""
            End If
        Next
        Return total
    End Function
    Private Sub actTxtDesc(ByVal codigos As String, ByVal fila As Integer)
        Dim sql As String = ""
        Dim codigo As String = ""
        dtgQuejaRec.Item("txtDescCodigo", fila).Value = ""
        For i = 0 To codigos.Length - 1
            If (codigos(i) <> "-") Then
                If (codigos(i) <> "" & vbCr & "" And codigos(i) <> "" & vbLf & "") Then
                    codigo += codigos(i)
                End If
            End If
            If ((codigos(i) = "-" Or i = codigos.Length - 1) And (codigo <> "")) Then
                sql = "SELECT descripcion FROM referencias WHERE codigo = '" & codigo & "'"
                codigo = ""
                dtgQuejaRec.Item("txtDescCodigo", fila).Value += objQuejaRecLn.consultValor(sql)
                If (i <> codigos.Length - 1) Then
                    dtgQuejaRec.Item("txtDescCodigo", fila).Value += vbCrLf
                End If


            End If
        Next
    End Sub

    Private Sub txtNombres_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNombres.TextChanged
        If ((txtBuscar.Text = "" And txtNit.Text = "" And txtNombres.Text = "") Or (txtNombres.Text <> "")) Then
            txtNit.Text = ""
            txtBuscar.Text = ""
        End If

    End Sub

    Private Sub txtNit_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNit.TextChanged
        If ((txtBuscar.Text = "" And txtNit.Text = "" And txtNombres.Text = "") Or (txtNit.Text <> "")) Then
            txtNombres.Text = ""
            txtBuscar.Text = ""
        End If
    End Sub

    Private Sub txtBuscar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBuscar.TextChanged
        If ((txtBuscar.Text = "" And txtNit.Text = "" And txtNombres.Text = "") Or (txtBuscar.Text <> "")) Then
            txtNit.Text = ""
            txtNombres.Text = ""
        End If

    End Sub

    Private Sub btn_cerrar_graf_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_cerrar_graf.Click
        group_estado.Visible = False
    End Sub

    Private Sub btn_ok_estado_Click(sender As Object, e As EventArgs) Handles btn_ok_estado.Click
        If txt_observacion_estado.Text <> "" Then
            Dim desc_estado As String = dtgEstado.Item("descripcion", dtgEstado.CurrentCell.RowIndex).Value
            Dim id_estado As Integer = dtgEstado.Item("id", dtgEstado.CurrentCell.RowIndex).Value
            cambiar_estado_pqr(txt_observacion_estado.Text, id_estado, desc_estado)
        Else
            MessageBox.Show("Se debe ingresar una observación para el cambio de estado de la PQR", "verifique", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub
    Private Sub cambiar_estado_pqr(ByVal observacion As String, ByVal id_estado As Double, ByVal desc_estado As String)
        If Not IsNothing(dtgQuejaRec.Item(txtId.Name, dtgQuejaRec.CurrentCell.RowIndex).Value) Then
            Dim id_pqr As Double = dtgQuejaRec.Item(txtId.Name, fila_select).Value

            Dim sql As String = "INSERT INTO J_pqr_trasabilidad_tratamiento (id_queja,id_tratamiento,fecha,usuario,observaciones ) VALUES ( " & id_pqr & " , " & id_estado & " ,GETDATE(), '" & usuarioEn.nombre & "','" & observacion & "')"
            If (objOpSimplesLn.ejecutar(sql, "CORSAN")) Then
                MessageBox.Show("El estado de la PQR se ingreso en forma correcta", "Correcto!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                dtgQuejaRec.Item(col_tratamiento_pqr.Name, fila_select).Value = desc_estado
                dtgQuejaRec.Item(col_id_tratamiento_pqr.Name, fila_select).Value = id_estado
                txt_observacion_estado.Text = ""
                group_estado.Visible = False
            Else
                MessageBox.Show("Eror al actualizar el estado de la Pqr", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            txt_observacion_estado.Text = ""
            group_estado.Visible = False
        End If
    End Sub
    Public Sub estado_queja(ByVal fila As Integer)
        Dim id_queja As Double = dtgQuejaRec.Item(txtId.Name, fila).Value
        Dim sql As String = "SELECT t.id,t.descripcion,z.fecha ,DATEdIFF(DAY,fecha,GETDATE())As dias_estado " & _
                             "FROM J_pqr_tipo_tratamiento t ,J_pqr_trasabilidad_tratamiento z   " & _
                                "WHERE t.id = z.id_tratamiento AND z.fecha = (SELECT MAX(fecha) FROM J_pqr_trasabilidad_tratamiento WHERE id_queja =z.id_queja )AND z.id_queja = " & id_queja
        Dim dt As DataTable = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        If dt.Rows.Count = 0 Then
            dtgQuejaRec.Item(col_tratamiento_pqr.Name, fila).Value = "Pendiente"
            dtgQuejaRec.Item(col_id_tratamiento_pqr.Name, fila).Value = 1
            dtgQuejaRec.Item(col_dias_tratamiento.Name, fila).Value = 0
        Else
            For i = 0 To dt.Rows.Count - 1
                dtgQuejaRec.Item(col_tratamiento_pqr.Name, fila).Value = dt.Rows(i).Item("descripcion")
                dtgQuejaRec.Item(col_id_tratamiento_pqr.Name, fila).Value = dt.Rows(i).Item("id")
                dtgQuejaRec.Item(col_dias_tratamiento.Name, fila).Value = dt.Rows(i).Item("dias_estado")
            Next
        End If

    End Sub

    Private Sub AuditoriaDeEstadosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AuditoriaDeEstadosToolStripMenuItem.Click
        group_audit_estados.Visible = True
        Dim tamano_letra As Single = 9.0!
        Dim id_queja As Double = dtgQuejaRec.Item(txtId.Name, dtgQuejaRec.CurrentCell.RowIndex).Value
        Dim sql As String = "SELECT t.id,t.descripcion,CAST(z.fecha As date ) As fecha,z.usuario,z.observaciones,z.id As id_tras  " & _
                         "FROM J_pqr_tipo_tratamiento t ,J_pqr_trasabilidad_tratamiento z   " & _
                            "WHERE t.id = z.id_tratamiento AND z.anulado is null AND z.id_queja =" & id_queja & " " & _
                                    "ORDER BY z.fecha"

        Dim dt As DataTable = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        Dim fecha As New Date
        dt.Columns.Add("dias_transito")
        For i = 0 To dt.Rows.Count - 1
            If i + 1 < dt.Rows.Count Then
                If Not IsDBNull(dt.Rows(i).Item("fecha")) Then
                    If Not IsDBNull(dt.Rows(i + 1).Item("fecha")) Then
                        dt.Rows(i).Item("dias_transito") = DateDiff(DateInterval.Day, dt.Rows(i).Item("fecha"), dt.Rows(i + 1).Item("fecha"))
                    Else
                        dt.Rows(i).Item("dias_transito") = DateDiff(DateInterval.Day, dt.Rows(i).Item("fecha"), Now.Date)
                    End If
                End If
            End If

        Next
        dtg_audit_estados.DataSource = dt
        dtg_audit_estados.Columns("fecha").DefaultCellStyle.Format = "G"
        dtg_audit_estados.Columns("dias_transito").DefaultCellStyle = objOperacionesForm.formatoNegrita(tamano_letra)
    End Sub

    Private Sub btn_cerrar_audit_estados_Click(sender As Object, e As EventArgs) Handles btn_cerrar_audit_estados.Click
        group_audit_estados.Visible = False
    End Sub

    Private Sub AdjuntarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AdjuntarToolStripMenuItem.Click
        OpenFileDialog1.ShowDialog()
    End Sub
    Private Sub OpenFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk
        Dim ext As String = OpenFileDialog1.DefaultExt
        If ext = "pdf" Then
            Dim ruta As String = OpenFileDialog1.FileName
            Dim id As String = dtgQuejaRec.Item(txtId.Name, fila_select).Value
            'Dim Destination As String = "\\sst\Dms_con\AQUI PROGRAMA\SPIC\doc_sac\"
            'System.IO.File.Copy(ruta, Destination, True)
            Dim Destination As String = "\\sistemas2\prodtrefpunt\SPIC\doc_sac\" & id & "." & ext
            Dim sql As String = "UPDATE J_quejas_rec SET ruta_doc='" & Destination & "' WHERE id_queja =" & id
            If objOpSimplesLn.ejecutar(sql, "CORSAN") Then
                System.IO.File.Copy(ruta, Destination, True)
                MessageBox.Show("Documento adjunto en forma correcta", "Correcto!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Eror al adjuntar el documento", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            MessageBox.Show("Solo se admite formato pdf", "Solo pdf", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If


    End Sub

    Private Sub dtg_audit_estadosCellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtg_audit_estados.CellClick
        Dim fila As Integer = e.RowIndex
        Dim col As String = dtg_audit_estados.Columns(e.ColumnIndex).Name
        If (col = btn_anular.Name) Then
            Dim resp As Integer = MessageBox.Show("Desea anular el tratamiento seleccionado?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If (resp = 6) Then
                Dim motivo As String = InputBox("ingrese motivo de anulación!")
                If motivo <> "" Then
                    Dim id_tras As Double = dtg_audit_estados.Item("id_tras", e.RowIndex).Value
                    Dim sql As String = "UPDATE J_pqr_trasabilidad_tratamiento SET anulado = 'S'  ,observaciones +=' anulado : " & motivo & " " & Now & " " & usuarioEn.nit & "' WHERE id =" & id_tras & ""
                    If (objOpSimplesLn.ejecutar(sql, "CORSAN")) Then
                        MessageBox.Show("El estado de la PQR se elimino en forma correcta", "Correcto!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("Eror al actualizar el estado de la Pqr", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                    dtg_audit_estados.CurrentCell = Nothing
                    dtg_audit_estados.Rows.RemoveAt(e.RowIndex)
                End If
            End If
        End If
    End Sub

    Private Sub DíasTransitoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DíasTransitoToolStripMenuItem.Click
        objOperacionesForm.ExportarDatosExcel(dtg_transito, "Pqr")
    End Sub

    Private Sub PQRToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PQRToolStripMenuItem.Click
        objOperacionesForm.ExportarDatosExcel(dtgQuejaRec, "Transito")
    End Sub

    Private Sub btn_factura_Click(sender As System.Object, e As System.EventArgs) Handles btn_factura.Click
        Dim numero_fact As String = InputBox("Número de factura")
        If IsNumeric(numero_fact) Then
            Dim sql_enc As String = "SELECT d.numero, d.vendedor,d.nit,t.nombres,t.ciudad,d.condicion,t.direccion,t.telefono_1 ,d.fecha,d.vencimiento ,d.iva,d.valor_total,d.notas " & _
                                         "FROM documentos d, terceros t " & _
                                              "WHERE t.nit = d.nit AND  tipo = 'FACT' AND d.numero = " & numero_fact & "   "
            Dim sql_det As String = "SELECT r.codigo,r.descripcion,d.cantidad,d.valor_unitario ,d.valor_unitario * d.cantidad As vr_total,r.generico,d.pedido  " & _
                                       "FROM documentos_lin d , referencias r   " & _
                                              "WHERE r.codigo = d.codigo AND d.tipo = 'FACT' AND d.numero = " & numero_fact & "  " & _
                                                 "ORDER BY r.descripcion"
            Dim dt_enc As DataTable = objOpSimplesLn.listar_datatable(sql_enc, "CORSAN")
            Dim dt_det As DataTable = objOpSimplesLn.listar_datatable(sql_det, "CORSAN")
            If dt_enc.Rows.Count > 0 Then
                Dim objFacturaEncEn As New FacturaEncEn
                Dim objFacturaDetEn As New FacturaDetEn
                Dim listDet As New List(Of FacturaDetEn)
                For i = 0 To dt_enc.Rows.Count - 1
                    objFacturaEncEn.ciudad = dt_enc.Rows(i).Item("ciudad") '
                    objFacturaEncEn.condicion = dt_enc.Rows(i).Item("condicion") '
                    objFacturaEncEn.direccion = dt_enc.Rows(i).Item("direccion") '
                    objFacturaEncEn.fecha = dt_enc.Rows(i).Item("fecha") '
                    objFacturaEncEn.fecha_venc = dt_enc.Rows(i).Item("vencimiento") '
                    objFacturaEncEn.iva = dt_enc.Rows(i).Item("iva") '
                    objFacturaEncEn.nit = dt_enc.Rows(i).Item("nit") '
                    objFacturaEncEn.nombres = dt_enc.Rows(i).Item("nombres") '
                    objFacturaEncEn.numero = dt_enc.Rows(i).Item("numero") '
                    objFacturaEncEn.sub_total = dt_enc.Rows(i).Item("valor_total") - dt_enc.Rows(i).Item("iva")
                    objFacturaEncEn.telefono = dt_enc.Rows(i).Item("telefono_1") '
                    objFacturaEncEn.valor_total = dt_enc.Rows(i).Item("valor_total")
                    objFacturaEncEn.vendedor = dt_enc.Rows(i).Item("vendedor") '
                    objFacturaEncEn.notas = dt_enc.Rows(i).Item("notas") '
                Next
                For i = 0 To dt_det.Rows.Count - 1
                    objFacturaDetEn = New FacturaDetEn
                    objFacturaDetEn.cantidad = dt_det.Rows(i).Item("cantidad")
                    objFacturaDetEn.codigo = dt_det.Rows(i).Item("codigo")
                    objFacturaDetEn.descripcion = dt_det.Rows(i).Item("descripcion")
                    objFacturaDetEn.valor_total = dt_det.Rows(i).Item("vr_total")
                    objFacturaDetEn.valor_unitario = dt_det.Rows(i).Item("valor_unitario")
                    objFacturaDetEn.unidad = dt_det.Rows(i).Item("generico") '
                    objFacturaEncEn.pedido = dt_det.Rows(i).Item("pedido") '
                    listDet.Add(objFacturaDetEn)

                Next
                Dim frm As New Frm_rpt_fact
                frm.Main("Factura número " & numero_fact, objFacturaEncEn, listDet)
                frm.Show()
            Else
                MessageBox.Show("El número de factura no existe", "Número no existe!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            MessageBox.Show("El número de factura es incorrecto", "Número incorrecto!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
End Class