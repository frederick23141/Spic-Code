Imports logicaNegocios
Imports entidadNegocios
Public Class frm_documentacion_crear
    Private objOpSimplesLn As New Op_simpesLn
    'Variables globales para inicio
    Dim nits As String
    Dim vars As Integer
    Dim usuario As UsuarioEn
    Public Sub main(ByVal nit As String, ByVal var As Integer, ByVal usuario As UsuarioEn)
        Me.usuario = usuario
        If var = 0 Then
            txt_nit.Focus()
            group_info.Enabled = True
            dtg_doc.Enabled = False
        Else
            group_info.Enabled = False
            dtg_doc.Enabled = True
            nits = nit
            vars = var
            Me.Text = "Documentacion para el cliente:" & nit
        End If
        If usuario.permiso.Trim = "AUX_CARTERA" Or usuario.permiso.Trim = "ADMIN" Then
            btn_guardar.Visible = True
            col_guardar.Visible = True
            dtg_doc.Enabled = True
        Else
            btn_guardar.Visible = False
            col_guardar.Visible = False
            dtg_doc.Enabled = False
        End If
    End Sub
    Private Sub cargar_doc(ByVal nit As String)
        Dim sql As String = "SELECT n.id AS ID,n.nombre AS Documento,c.fecha_doc AS Fecha_Documento ,c.fecha_ven AS Fecha_Vencimiento FROM JB_control_doc_clientes_ctrl c, JB_nom_documentos n " & _
                                " WHERE c.id_doc = n.id AND c.nit = " & nit
        dtg_doc.DataSource = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        sql = "SELECT cedula_rpl_legal FROM JB_doc_terceros WHERE nit = " & nit
        txt_doc_rep.Text = objOpSimplesLn.consultValorTodo(sql, "CORSAN")
        sql = "SELECT rep_legal FROM JB_doc_terceros WHERE nit = " & nit
        txt_nom_rep_leg.Text = objOpSimplesLn.consultValorTodo(sql, "CORSAN")
        sql = "SELECT razon_comercial FROM JB_doc_terceros WHERE nit = " & nit
        txt_raz_c.Text = objOpSimplesLn.consultValorTodo(sql, "CORSAN")
        txt_nit.Text = nit
        Application.DoEvents()
        For i = 0 To dtg_doc.RowCount - 1
            If Not IsDBNull(dtg_doc.Item("Fecha_Vencimiento", i).Value) Then
                If dtg_doc.Item("ID", i).Value = 4 Or dtg_doc.Item("ID", i).Value = 6 Then
                    Dim fec_cr As Date = dtg_doc.Item("Fecha_Vencimiento", i).Value
                    Dim fec_cr_val As Date = Now
                    If fec_cr_val >= fec_cr Then
                        dtg_doc.Rows(i).DefaultCellStyle.BackColor = Color.OrangeRed
                    End If
                End If
            End If
            If dtg_doc.Item("ID", i).Value = 1 Then
                If Not IsDBNull(dtg_doc.Item("Fecha_Documento", i).Value) Then
                    Dim fec_cr As Date = dtg_doc.Item("Fecha_Documento", i).Value
                    Dim das As Integer = fec_cr.Year
                    If das < 2012 Then
                        dtg_doc.Rows(i).DefaultCellStyle.BackColor = Color.OrangeRed
                    End If
                End If
            End If
        Next
        dtg_doc.Columns("Fecha_Vencimiento").DefaultCellStyle.Format = "d"
        dtg_doc.Columns("Fecha_Documento").DefaultCellStyle.Format = "d"
    End Sub

    Private Sub frm_documentacion_crear_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If vars = 1 Then
            cargar_doc(nits)
        End If
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
    Private Sub btn_guardar_Click(sender As Object, e As EventArgs) Handles btn_guardar.Click
        If validar_guardar() Then
            MessageBox.Show("Los datos del cliente se actualizaron Correctamente.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
            frm_documentacion_pendiente.cargar_clientes()
        End If
    End Sub
    Private Function validar_guardar()
        Dim resp As Boolean = False
        Dim sql As String = ""
        Dim listSql As New List(Of Object)
        If vars = 0 Then
            sql = "INSERT INTO JB_doc_terceros (nit,cedula_rpl_legal,rep_legal,razon_comercial,fecha_creacion,fec_ult_actualizacion) " & _
                    "VALUES ('" & txt_nit.Text & "','" & txt_doc_rep.Text & "','" & txt_nom_rep_leg.Text & "','" & txt_raz_c.Text & "',GETDATE(),GETDATE())"
            listSql.Add(sql)
            For i = 1 To 6
                sql = "INSERT INTO JB_control_doc_clientes_ctrl (nit,id_doc) VALUES (" & txt_nit.Text & "," & i & ")"
                listSql.Add(sql)
            Next
        Else
            sql = "SELECT fecha_creacion FROM JB_doc_terceros WHERE nit = " & txt_nit.Text
            Dim FEC As Date = objOpSimplesLn.consultValorTodo(sql, "CORSAN")
            Dim fec_cr_val As Date = Now.AddYears(-1)
            If fec_cr_val >= FEC Then
                sql = "UPDATE JB_doc_terceros SET fecha_creacion = GETDATE() WHERE nit = " & txt_nit.Text
                listSql.Add(sql)
            End If
            sql = "UPDATE JB_doc_terceros SET fec_ult_actualizacion = GETDATE() WHERE nit = " & txt_nit.Text
            listSql.Add(sql)
        End If
        If objOpSimplesLn.ExecuteSqlTransactionTodo(listSql, "CORSAN") Then
            resp = True
        End If
        Return resp
    End Function
    Private Sub dtg_doc_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtg_doc.CellClick
        If (e.RowIndex >= 0) Then
            Dim col As String = dtg_doc.Columns(e.ColumnIndex).Name
            Dim sql As String = ""
            If (col = col_guardar.Name) Then
                Dim id As Integer = dtg_doc.Item("ID", e.RowIndex).Value
                If Not IsDBNull(dtg_doc.Item("Fecha_Documento", e.RowIndex).Value) Then
                    Dim FECHA As String = objOpSimplesLn.cambiarFormatoFecha(dtg_doc.Item("Fecha_Documento", e.RowIndex).Value)
                    If id = 1 Then
                        sql = "UPDATE JB_control_doc_clientes_ctrl SET fecha_doc = '" & FECHA & "' WHERE nit = '" & txt_nit.Text & "' AND id_doc = " & id
                    ElseIf id = 2 Then
                        sql = "UPDATE JB_control_doc_clientes_ctrl SET fecha_doc = '" & FECHA & "'  WHERE nit = '" & txt_nit.Text & "' AND id_doc = " & id
                    ElseIf id = 3 Then
                        sql = "UPDATE JB_control_doc_clientes_ctrl SET fecha_doc = '" & FECHA & "' WHERE nit = '" & txt_nit.Text & "' AND id_doc = " & id
                    ElseIf id = 4 Then
                        sql = "UPDATE JB_control_doc_clientes_ctrl SET fecha_doc = '" & FECHA & "', fecha_ven = DATEADD(YY,1,'" & FECHA & "') WHERE nit = '" & txt_nit.Text & "' AND id_doc = " & id
                    ElseIf id = 5 Then
                        sql = "UPDATE JB_control_doc_clientes_ctrl SET fecha_doc = '" & FECHA & "' WHERE nit = '" & txt_nit.Text & "' AND id_doc = " & id
                    ElseIf id = 6 Then
                        sql = "UPDATE JB_control_doc_clientes_ctrl SET fecha_doc = '" & FECHA & "', fecha_ven = DATEADD(YY,1,'" & FECHA & "') WHERE nit = '" & txt_nit.Text & "' AND id_doc = " & id
                    End If
                    If objOpSimplesLn.ejecutar(sql, "CORSAN") Then
                        cargar_doc(txt_nit.Text)
                    End If
                End If
            End If
            If (col = "Fecha_Documento") Then
                gp_fecha.Visible = True
                dtg_doc.Enabled = False
            End If
        End If
    End Sub
    Private Sub mt_fec_DateSelected(sender As Object, e As DateRangeEventArgs) Handles mt_fec.DateSelected
        dtg_doc.Item("Fecha_Documento", dtg_doc.CurrentCell.RowIndex).Value = (mt_fec.SelectionEnd.Date)
        gp_fecha.Visible = False
        dtg_doc.Enabled = True
    End Sub
    Private Sub txt_nit_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_nit.KeyPress
        soloNumero(e)
    End Sub
    Private Sub txt_doc_rep_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_doc_rep.KeyPress
        soloNumero(e)
    End Sub
End Class