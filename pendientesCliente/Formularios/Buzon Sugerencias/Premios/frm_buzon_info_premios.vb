Imports logicaNegocios
Imports entidadNegocios

Public Class frm_buzon_info_premios
    Private objOpSimplesLn As New Op_simpesLn
    Private obj_Ing_prodLn As New Ing_prodLn
    Private obj_correoLn As New EnvCorreoLN
    Private objOperacionesForm As OperacionesFormularios = New OperacionesFormularios

    Private Sub frm_buzon_info_premios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargar_premios()

        'Cargar los CBO para años
        For i = Now.Year - 1 To Now.Year + 1
            cbo_ano.Items.Add(i)
        Next
        cbo_ano.Text = Now.Year

        cbo_mes.DataSource = objOpSimplesLn.returnDtMeses()
        cbo_mes.ValueMember = "numMes"
        cbo_mes.DisplayMember = "nombMes"
        cbo_mes.SelectedValue = Now.Month
    End Sub

    ''se obtienen los premios de la base de datos JB_buzon_premios
    Private Sub cargar_premios()
        Dim sql As String = "SELECT id,nombre,valor_puntos FROM JB_buzon_premios "
        dtg_premios.DataSource = objOpSimplesLn.listar_datatable(sql, "CORSAN")
    End Sub

    ''metodo para manipular los premios de  de la tabla de JB_buzon_premios al darle click a la casilla del datagridview
    Private Sub dtg_premios_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtg_premios.CellClick
        If (e.RowIndex >= 0) Then
            Dim col As String = dtg_premios.Columns(e.ColumnIndex).Name
            If (col = col_guardar.Name) Then
                If dtg_premios.Item("valor_puntos", e.RowIndex).Value <> 0 Then
                    If IsNumeric(dtg_premios.Item("valor_puntos", e.RowIndex).Value) Then
                        Dim sql As String = "UPDATE JB_buzon_premios SET valor_puntos=" & dtg_premios.Item("valor_puntos", e.RowIndex).Value & _
                                            " WHERE id = " & dtg_premios.Item("id", e.RowIndex).Value
                        If objOpSimplesLn.ejecutar(sql, "CORSAN") Then
                            MessageBox.Show("El cambio se Guardo Correctamente.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            cargar_premios()
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    ''invocar metodo de consultar 
    Private Sub btn_consultar_Click(sender As Object, e As EventArgs) Handles btn_consultar.Click
        consultars()
    End Sub

    ''metodo de consultars que genera una consulta con algunos criterios del formulario
    Private Sub consultars()
        Dim wheresql As String = ""
        Dim wheresqls As String = "AND p.fecha_entrega IS NULL"
        If chk_entregados.Checked = True Then
            wheresql = ",p.fecha_entrega "
            wheresqls = " AND p.fecha_entrega IS NOT NULL"
            col_entregar.Visible = False
        Else
            col_entregar.Visible = True
        End If
        If txt_empleado.Text <> "" Then
            wheresqls &= " AND p.doc = " & txt_empleado.Text
        End If
        Dim sql As String = "SELECT p.id,p.doc,v.nombres,p.premio AS id_premio,d.nombre,p.fecha_solicitud,p.valor " & wheresql & _
                            " FROM JB_buzon_solicitud_premios p, JB_buzon_premios d, v_nom_personal v " & _
                            " WHERE p.premio = d.id AND v.nit = p.doc " & wheresqls
        dtg_sol_premios.DataSource = objOpSimplesLn.listar_datatable(sql, "CORSAN")
    End Sub

    ''se gestiona la entrega del premio
    Private Sub dtg_sol_premios_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtg_sol_premios.CellClick
        If (e.RowIndex >= 0) Then
            Dim col As String = dtg_sol_premios.Columns(e.ColumnIndex).Name
            If (col = col_entregar.Name) Then
                Dim sql As String = "UPDATE JB_buzon_solicitud_premios SET fecha_entrega=GETDATE() " &
                                            " WHERE id = " & dtg_sol_premios.Item("id", e.RowIndex).Value
                If objOpSimplesLn.ejecutar(sql, "CORSAN") Then
                    MessageBox.Show("El premio se Registro como entregado.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    enviar_correo(dtg_sol_premios.Item("id_premio", e.RowIndex).Value, dtg_sol_premios.Item("doc", e.RowIndex).Value)
                    consultar()
                End If
            End If
        End If
    End Sub

    ''metodo para enviar el correo 
    Private Sub enviar_correo(ByVal premio As Integer, ByVal DOC As Integer)
        Dim sql As String = "SELECT mail,Mail_login  FROM Jjv_usuarios WHERE usuario = 'ADMIN'"
        Dim dt_admin As DataTable = objOpSimplesLn.listar_datatable(sql, "CORSAN")

        sql = "SELECT NOMBRE FROM JB_buzon_premios WHERE id =" & premio
        Dim PREM As String = objOpSimplesLn.consultValorTodo(sql, "CORSAN")
        sql = "SELECT mail FROM v_nom_personal WHERE nit=" & DOC
        Dim mail As String = objOpSimplesLn.consultValorTodo(sql, "CORSAN")
        Dim asunto As String = "Reclamacion de Premio"
        Dim cuerpo As String = "EL PREMIO SERA ENTREGADO" & vbCrLf & _
                                "" & vbCrLf & _
                                "Premio: " & premio & "-" & PREM & vbCrLf & _
                                "Documento: " & DOC & vbCrLf & _
                                "Fecha: " & Now & vbCrLf & _
                                "ACERQUESE AL AREA DE RECURSOS HUMANOS Y PREGUNTE CUANDO Y RECLAME SU PREMIO"

        Dim mailEnvia As String = dt_admin.Rows(0).Item("mail")
        Dim mailEnviaPass As String = dt_admin.Rows(0).Item("Mail_login")
        obj_correoLn.EnviarCorreo(mail.Trim, cuerpo, asunto, "", mailEnvia, mailEnviaPass, False)
    End Sub

    ''metodo para exportar a excel 
    Private Sub btn_exportar_Click(sender As Object, e As EventArgs) Handles btn_exportar.Click
        Me.UseWaitCursor = True
        Application.DoEvents()
        objOperacionesForm.exportarExcel(dtg_sol_premios)
        Me.UseWaitCursor = False
    End Sub

    ''metodo que invoca la consulta de puntos
    Private Sub btn_cons_puntos_Click(sender As Object, e As EventArgs) Handles btn_cons_puntos.Click
        consultar()
    End Sub

    ''metodo que acomula los puntos 
    Private Sub consultar()
        dtg_puntos_operarios.DataSource = Nothing
        Dim wSql As String = ""
        If chk_fil_fecha.Checked = True Then
            wSql = " AND year(s.fecha) = " & cbo_ano.Text & " AND month(s.fecha) =" & cbo_mes.SelectedValue
        End If
        Dim whereSQL As String = ""
        If txt_emp_punt.Text <> "" Then
            whereSQL = " AND p.doc = " & txt_emp_punt.Text
        End If
        Dim sql As String = "SELECT p.doc,v.nombres,V.descripcion AS area,p.puntos, " & _
                            " (SELECT COUNT(documento) FROM JB_buzon_sugerencias s WHERE s.documento = p.doc AND estado = 1 " & wSql & ") AS ENV, " & _
                            " (SELECT COUNT(documento) FROM JB_buzon_sugerencias s WHERE s.documento = p.doc AND estado = 2 " & wSql & ") AS APR, " & _
                            " (SELECT COUNT(documento) FROM JB_buzon_sugerencias s WHERE s.documento = p.doc AND s.fec_rech Is not null " & wSql & ") AS DEN, " & _
                            " (SELECT COUNT(documento) FROM JB_buzon_sugerencias s WHERE s.documento = p.doc AND estado = 4 " & wSql & ") AS EJE, " & _
                            " (SELECT COUNT(documento) FROM JB_buzon_sugerencias s WHERE s.documento = p.doc AND estado = 5 AND s.fec_rech Is null " & wSql & ") AS CER " & _
                            " FROM JB_buzon_sugerencias_puntos p, V_nom_personal_Activo_con_maquila v " & _
                            " WHERE v.nit = p.doc " & whereSQL & _
                            " ORDER BY v.nombres"
        dtg_puntos_operarios.DataSource = objOpSimplesLn.listar_datatable(sql, "CORSAN")
    End Sub

    ''controles de los cbo año y mes
    Private Sub chk_fil_fecha_CheckedChanged(sender As Object, e As EventArgs) Handles chk_fil_fecha.CheckedChanged
        If chk_fil_fecha.Checked = True Then
            cbo_ano.Enabled = True
            cbo_mes.Enabled = True
        Else
            cbo_ano.Enabled = False
            cbo_mes.Enabled = False
        End If
    End Sub

    Dim doc_emp As Integer = 0
    Dim nom_emp As String = ""

    ''cargamos el datagridview de los puntos de los operarios
    Private Sub dtg_puntos_operarios_MouseDown(sender As Object, e As MouseEventArgs) Handles dtg_puntos_operarios.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            men_emp.Enabled = True
            If dtg_puntos_operarios.Rows.Count > 0 Then
                With (Me.dtg_puntos_operarios)
                    Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                    If Hitest.Type = DataGridViewHitTestType.Cell Then
                        .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                        doc_emp = Me.dtg_puntos_operarios("doc", Me.dtg_puntos_operarios.CurrentRow.Index).Value
                        nom_emp = Me.dtg_puntos_operarios("nombres", Me.dtg_puntos_operarios.CurrentRow.Index).Value
                    End If
                End With
            End If
        End If
    End Sub

    ''metodo para ver los detalles de los puntos de los operarios
    Private Sub bt_ms_ver_detalle_Click(sender As Object, e As EventArgs) Handles bt_ms_ver_detalle.Click
        If doc_emp <> 0 And nom_emp <> "" Then
            group_detall.Visible = True
            dtg_historial.DataSource = Nothing
            Dim sql As String = "SELECT fec,cant,razon FROM JB_buzon_historial_puntos WHERE doc = " & doc_emp & " ORDER BY fec DESC"
            group_detall.Text = "Historial de cambios en los puntos de: " & nom_emp
            dtg_historial.DataSource = objOpSimplesLn.listar_datatable(sql, "CORSAN")

            dtg_puntos_operarios.Enabled = False
            btn_cons_puntos.Enabled = False
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        group_detall.Visible = False
        dtg_historial.DataSource = Nothing

        dtg_puntos_operarios.Enabled = True
        btn_cons_puntos.Enabled = True

    End Sub

    Private Sub EnviarHistorialDePuntosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EnviarHistorialDePuntosToolStripMenuItem.Click
        If doc_emp <> 0 And nom_emp <> "" Then
            enviar_correo(doc_emp)
        End If
    End Sub

    '' metodo para obtener y listar los correos de admin y de los operarios con historial de puntos
    Private Sub enviar_correo(ByVal nit As Integer)
        Dim sql As String = "SELECT mail,Mail_login  FROM Jjv_usuarios WHERE usuario = 'ADMIN'"
        Dim dt_admin As DataTable = objOpSimplesLn.listar_datatable(sql, "CORSAN")

        sql = "SELECT mail FROM v_nom_personal WHERE nit =" & nit
        Dim mail As String = objOpSimplesLn.consultValorTodo(sql, "CORSAN")
        Dim his As String = "Fecha               -               Cantidad               -               Razon" & vbCrLf

        sql = "SELECT fec,cant,razon FROM JB_buzon_historial_puntos WHERE doc = " & nit & " ORDER BY fec DESC"
        Dim dt As DataTable = objOpSimplesLn.listar_datatable(sql, "CORSAN")

        For i = 0 To dt.Rows.Count - 1
            his &= dt.Rows(i).Item("fec") & "     -     (" & dt.Rows(i).Item("cant") & ")     -     " & dt.Rows(i).Item("razon") & vbCrLf & vbCrLf
        Next

        Dim asunto As String = "Historial de Puntos."
        Dim cuerpo As String = "HISTORIAL DE PUNTOS" & vbCrLf &
                                "" & vbCrLf &
                                "Empleado:  " & nom_emp & vbCrLf & vbCrLf &
                                his
        Dim mailEnvia As String = dt_admin.Rows(0).Item("mail")
        Dim mailEnviaPass As String = dt_admin.Rows(0).Item("Mail_login")
        obj_correoLn.EnviarCorreo(mail.Trim, cuerpo, asunto, "", mailEnvia, mailEnviaPass, False)
    End Sub

    '' metodo para sumar los puntos de cada operario/empleado
    Private Sub aumetar(ByVal puntos As Integer, ByVal empleado As Integer, ByVal razon As String, ByVal var As Boolean)
        Dim sql As String = "SELECT puntos FROM JB_buzon_sugerencias_puntos WHERE doc = " & empleado
        Dim punt As Integer = obj_Ing_prodLn.consultar_valor(sql, "CORSAN") + puntos

        Dim listSql As New List(Of Object)

        sql = "UPDATE JB_buzon_sugerencias_puntos SET puntos = " & punt & "  WHERE doc = " & empleado
        listSql.Add(sql)
        sql = "INSERT INTO JB_buzon_historial_puntos (doc,fec,cant,razon) VALUES (" & _
                   empleado & ",getdate()," & puntos & ",'" & razon & "')"
        listSql.Add(sql)

        Dim razons As String = ""
        If var = True Then
            razons = "aumentaron"
        Else
            razons = "disminuyeron"
        End If

        If obj_Ing_prodLn.ExecuteSqlTransaction(listSql, "CORSAN") Then
            MessageBox.Show("Se le " & razons & " " & puntos & " por: " & razon, "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information)
            consultar()
        End If
    End Sub

    Private Sub PorImpactoDeIdeaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PorImpactoDeIdeaToolStripMenuItem.Click
        If doc_emp <> 0 And nom_emp <> "" Then
            aumetar(2, doc_emp, "POR IDEA COTIDIANA (" & My.Computer.Name & ")", True)
        End If
    End Sub
    Private Sub OtrosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OtrosToolStripMenuItem.Click
        Dim raz As String = ""
        Dim cantt As Integer = 0
        If doc_emp <> 0 And nom_emp <> "" Then
            raz = InputBox("Digite la razon por la cual va a aumentar los puntos.", "Digite la Razon.")
            If raz <> "" Then
                cantt = Convert.ToInt32(InputBox("Digite la cantidad de Puntos que desea aumentar.", "Ingrese la cantidad de puntos."))
                If cantt > 0 Then
                    aumetar(cantt, doc_emp, raz.ToUpper & " (" & My.Computer.Name & ")", True)
                End If
            End If
        End If
    End Sub

    Private Sub AhorroDe10000010000000ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AhorroDe10000010000000ToolStripMenuItem.Click
        If doc_emp <> 0 And nom_emp <> "" Then
            aumetar(3, doc_emp, "POR AHORRO 1 (" & My.Computer.Name & ")", True)
        End If
    End Sub

    Private Sub AhorroDe110000010000000ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AhorroDe110000010000000ToolStripMenuItem.Click
        If doc_emp <> 0 And nom_emp <> "" Then
            aumetar(6, doc_emp, "POR AHORRO 2 (" & My.Computer.Name & ")", True)
        End If
    End Sub

    Private Sub AhorroMayorA10000000ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AhorroMayorA10000000ToolStripMenuItem.Click
        If doc_emp <> 0 And nom_emp <> "" Then
            aumetar(9, doc_emp, "POR AHORRO 3 (SE LE DARA EL 1% DEL AHORRO) (" & My.Computer.Name & ")", True)
        End If
    End Sub

    ''metodo encargado de el descuento o reduccion de puntos
    Private Sub ReduccionDePuntosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReduccionDePuntosToolStripMenuItem.Click
        Dim raz As String = ""
        Dim cantt As Integer = 0
        If doc_emp <> 0 And nom_emp <> "" Then
            raz = InputBox("Digite la razon por la cual va a ducir los puntos.", "Digite la Razon.")
            If raz <> "" Then
                cantt = Convert.ToInt32(InputBox("Digite la cantidad de Puntos que desea reducir.", "Ingrese la cantidad de puntos."))
                If cantt > 0 Then
                    aumetar(cantt * -1, doc_emp, raz.ToUpper & " (" & My.Computer.Name & ")", False)
                End If
            End If
        End If
    End Sub
End Class