Imports logicaNegocios
Imports entidadNegocios
Public Class frm_documentacion_pendiente
    Dim usuario As UsuarioEn
    Private obj_correoLn As New EnvCorreoLN
    Private objOpSimplesLn As New Op_simpesLn
    Public Sub main(ByVal usuario As UsuarioEn)
        Me.usuario = usuario
        If usuario.permiso.Trim = "AUX_CARTERA" Or usuario.permiso.Trim = "ADMIN" Then
            col_env.Visible = True
        Else
            col_env.Visible = False
        End If
    End Sub
    Public Sub cargar_clientes()
        Dim fecIni As String = objOpSimplesLn.cambiarFormatoFecha(Convert.ToDateTime(cbo_fecha_in.Value))
        Dim fecFin As String = objOpSimplesLn.cambiarFormatoFecha(Convert.ToDateTime(cbo_fecha_fin.Value))
        Dim sql As String = "SELECT t.nit,t.vendedor,t.ciudad,t.nombres,t.direccion,t.telefono_1,t.fax,t.celular,t.mail,t.cupo_credito,c.descripcion AS condicion,d.descripcion AS tipo_cliente, " & _
                                " s.cedula_rpl_legal AS CC_rep,s.rep_legal,s.razon_comercial,s.fecha_creacion AS fec_cre,s.fec_ult_actualizacion AS fec_act" & _
                                    " FROM terceros t,  condiciones_pago c, terceros_2 d,JB_doc_terceros s " & _
                                    " WHERE (t.condicion = c.condicion AND t.concepto_2 = d.concepto_2 AND t.nit = s.nit) "
        Dim whereSql As String = " AND s.fec_ult_actualizacion >= '" & fecIni & "' AND s.fec_ult_actualizacion <= '" & fecFin & "'"

        If txt_nit.Text <> "" Then
            whereSql = " AND t.nit = " & txt_nit.Text
        End If
        If txt_nombre.Text <> "" Then
            whereSql = " AND t.nombres like '%" & txt_nombre.Text & "%'"
        End If
        If txt_vendedor.Text <> "" Then
            whereSql = " AND t.vendedor = " & txt_vendedor.Text
        End If
        sql &= whereSql

        dtg_clientes.DataSource = objOpSimplesLn.listar_datatable(sql, "CORSAN")

        For i = 0 To dtg_clientes.RowCount - 1
            Dim fec_cr As Date = dtg_clientes.Item("fec_cre", i).Value
            Dim fec_cr_val As Date = Now.AddYears(-1)
            If fec_cr_val >= fec_cr Then
                dtg_clientes.Rows(i).DefaultCellStyle.BackColor = Color.Red
            End If
            sql = "SELECT n.id AS ID,n.nombre AS Documento,c.fecha_doc AS Fecha_Documento ,c.fecha_ven AS Fecha_Vencimiento FROM JB_control_doc_clientes_ctrl c, JB_nom_documentos n " & _
                                " WHERE c.id_doc = n.id AND c.nit = " & dtg_clientes.Item("nit", i).Value
            Dim dt As DataTable = objOpSimplesLn.listar_datatable(sql, "CORSAN")
            Dim var As Integer = 3

            For w = 0 To dt.Rows.Count - 1
                If Not IsDBNull(dt.Rows(w).Item("Fecha_Vencimiento")) Then
                    If dt.Rows(w).Item("ID") = 4 Or dt.Rows(w).Item("ID") = 6 Then
                        Dim fec_crs As Date = dt.Rows(w).Item("Fecha_Vencimiento")
                        Dim fec_cr_vals As Date = Now
                        If fec_cr_vals >= fec_crs Then
                            var -= 1
                        End If
                    End If
                End If
                If dt.Rows(w).Item("ID") = 1 Then
                    If Not IsDBNull(dt.Rows(w).Item("Fecha_Documento")) Then
                        Dim fec_crS As Date = dt.Rows(w).Item("Fecha_Documento")
                        Dim das As Integer = fec_crS.Year
                        If das < 2012 Then
                            var -= 1
                        End If
                    End If
                End If
            Next
            If var < 3 Then
                dtg_clientes.Rows(i).DefaultCellStyle.BackColor = Color.Red
            End If
            var = 3
        Next
        dtg_clientes.Columns("cupo_credito").DefaultCellStyle.Format = "C1"
        dtg_clientes.Columns("fec_cre").DefaultCellStyle.Format = "g"
        dtg_clientes.Columns("fec_act").DefaultCellStyle.Format = "g"
        dtg_clientes.Columns("nit").DefaultCellStyle.Format = "N0"
        dtg_clientes.Columns("vendedor").DefaultCellStyle.Format = "N0"
        dtg_clientes.Columns("telefono_1").DefaultCellStyle.Format = "N0"
        dtg_clientes.Columns("celular").DefaultCellStyle.Format = "N0"
        dtg_clientes.Columns("CC_rep").DefaultCellStyle.Format = "N0"
    End Sub
    Private Sub frm_documentacion_pendiente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cbo_fecha_in.Value = Now.AddYears(-1)
        cbo_fecha_fin.Value = Now.AddDays(1)
        cargar_clientes()
    End Sub

    Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
        cargar_clientes()
    End Sub

    Private Sub soloNumero(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If (Char.IsDigit(e.KeyChar) Or e.KeyChar = ".") Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub
    Private Sub txt_nit_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_nit.KeyPress
        soloNumero(e)
    End Sub

    Private Sub txt_vendedor_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_vendedor.KeyPress
        soloNumero(e)
    End Sub
    Dim cliente_cor As String = ""
    Dim vendedor_cor As String = ""
    Private Sub dtg_clientes_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtg_clientes.CellClick
        If (e.RowIndex >= 0) Then
            Dim col As String = dtg_clientes.Columns(e.ColumnIndex).Name
            If col = col_ver.Name Then
                Dim frm As New frm_documentacion_crear
                frm.main(dtg_clientes.Item("nit", e.RowIndex).Value, 1, usuario)
                frm.ShowDialog()
            End If
            If (col = col_env.Name) Then
                group_correo.Visible = True
                dtg_clientes.Enabled = False
                chk_camar.Checked = False
                chk_cc.Checked = False
                chk_estados.Checked = False
                chk_pagare.Checked = False
                chk_rut.Checked = False
                chk_solicitud.Checked = False
                cliente_cor = dtg_clientes.Item("nombres", e.RowIndex).Value
                vendedor_cor = dtg_clientes.Item("vendedor", e.RowIndex).Value
            End If
        End If
    End Sub
   
    Private Sub btn_nuevo_Click(sender As Object, e As EventArgs) Handles btn_nuevo.Click
        Dim frm As New frm_documentacion_crear
        frm.main(0, 0, usuario)
        frm.ShowDialog()
    End Sub
    Private Sub enviarCorreoInicioPlanilla(ByVal cliente As String, ByVal vendedor As Integer)
        Dim sql As String = "SELECT mail,Mail_login  FROM Jjv_usuarios WHERE usuario = '" & usuario.usuario.Trim & "'"
        'Dim sql As String = "SELECT mail,Mail_login  FROM Jjv_usuarios WHERE usuario = 'ADMIN'"
        Dim dt_admin As DataTable = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        sql = "SELECT mail,Mail_login  FROM Jjv_usuarios WHERE usuario = '" & vendedor & "'"
        Dim mail As String = objOpSimplesLn.consultValorTodo(sql, "CORSAN")
        'mail = "julian.bayer@corsan.com.co"
        Dim asunto As String = "Documentación pendiente para el cliente: " & cliente
        Dim cuerpo As String = "LOS DOCUMENTOS QUE HACEN FALTA SON:" & vbCrLf
        If chk_rut.Checked = True Then
            cuerpo &= "-RUT" & vbCrLf
        End If
        If chk_camar.Checked = True Then
            cuerpo &= "-CAMARA DE COMERCIO" & vbCrLf
        End If
        If chk_cc.Checked = True Then
            cuerpo &= "-CEDULA REPRESENTANTE LEGAL" & vbCrLf
        End If
        If chk_estados.Checked = True Then
            cuerpo &= "-ESTADOS FINANCIEROS" & vbCrLf
        End If
        If chk_pagare.Checked = True Then
            cuerpo &= "-PAGARÉ" & vbCrLf
        End If
        If chk_solicitud.Checked = True Then
            cuerpo &= "-SOLICITUD DE CREDITO/CONTADO" & vbCrLf
        End If
        Dim mailEnvia As String = dt_admin.Rows(0).Item("mail")
        Dim mailEnviaPass As String = dt_admin.Rows(0).Item("Mail_login")
        If obj_correoLn.EnviarCorreo(mail.Trim, cuerpo, asunto, "", mailEnvia, mailEnviaPass, False) Then
            MessageBox.Show("El Correo se Envio con exito.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information)
            group_correo.Visible = False
            dtg_clientes.Enabled = True
        Else
            MessageBox.Show("Error al enviar el correo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            group_correo.Visible = False
            dtg_clientes.Enabled = True
        End If
    End Sub

    Private Sub btn_enviar_Click(sender As Object, e As EventArgs) Handles btn_enviar.Click
        enviarCorreoInicioPlanilla(cliente_cor, vendedor_cor)
    End Sub

    Private Sub btn_cancelar_Click(sender As Object, e As EventArgs) Handles btn_cancelar.Click
        group_correo.Visible = False
        dtg_clientes.Enabled = True
    End Sub
End Class