Imports logicaNegocios
Public Class FrmMaestroFichas
    Private objOpSimplesLn As New Op_simpesLn
    Private objIngProdLn As New Ing_prodLn
    Dim dt As New DataTable
    Dim carga_comp As Boolean = False
    Private Sub FrmMaestroFichas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargarCbo()
        cargarConsulta()
        carga_comp = True
    End Sub
    Private Sub dtgMaestro_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgMaestro.CellContentClick
        If (e.RowIndex >= 0) Then
            Dim numCol As Integer = e.ColumnIndex
            Dim nombCol As String = dtgMaestro.Columns(numCol).Name
            Dim fila As Integer = e.RowIndex
            Dim listValores As New List(Of String)
            If (nombCol = "btnEdit" Or nombCol = "btnDelete") Then
                If (objIngProdLn.existeFichaTecnica(dtgMaestro.Item("codigo", fila).Value)) Then
                    Select Case nombCol
                        Case "btnEdit"
                            txtCodigo.Text = dtgMaestro.Item("codigo", e.RowIndex).Value
                            If Not IsDBNull(dtgMaestro.Item("resistencia", e.RowIndex).Value) Then
                                txtResis.Text = dtgMaestro.Item("resistencia", e.RowIndex).Value
                            End If
                            If Not IsDBNull(dtgMaestro.Item("procedencia", e.RowIndex).Value) Then
                                cboOrigen.SelectedValue = dtgMaestro.Item("procedencia", e.RowIndex).Value
                            End If
                            If Not IsDBNull(dtgMaestro.Item("calidad", e.RowIndex).Value) Then
                                txtCal.Text = dtgMaestro.Item("calidad", e.RowIndex).Value
                            End If
                            If Not IsDBNull(dtgMaestro.Item("recubrimiento", e.RowIndex).Value) Then
                                txtRec.Text = dtgMaestro.Item("recubrimiento", e.RowIndex).Value
                            End If
                            If Not IsDBNull(dtgMaestro.Item("nit", e.RowIndex).Value) Then
                                txtCli.Text = dtgMaestro.Item("nit", e.RowIndex).Value
                            End If
                        Case "btnDelete"
                            delete(fila)
                            cargarConsulta()
                    End Select
                Else
                    MessageBox.Show("El código de producto ingresado no existe,verifique", "verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        End If
    End Sub
    Private Sub save()
        If (validar()) Then
            Dim codigo As String = txtCodigo.Text
            Dim resistencia As String = txtResis.Text
            Dim procedencia As String = cboOrigen.SelectedValue
            Dim calidad As String = txtCal.Text
            Dim recubrimiento As String = txtRec.Text
            Dim cliente As String = txtCli.Text
            Dim sql As String = ""
            Dim listSql As New List(Of Object)
            sql = "DELETE FROM J_referencia_ficha_tec WHERE codigo = '" & codigo & "' AND nit = " & cliente
            listSql.Add(sql)
            sql = "INSERT INTO J_referencia_ficha_tec " & _
                                                   "(codigo,resistencia,procedencia,calidad,recubrimiento, nit) " & _
                                           "VALUES ('" & codigo & "','" & resistencia & "','" & procedencia & "', '" & calidad & "','" & recubrimiento & "','" & cliente & "')"
            listSql.Add(sql)
            If (objIngProdLn.ExecuteSqlTransaction(listSql, "PRODUCCION")) Then
                MessageBox.Show("El registro se ingreso en forma exitosa ", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                nuevo()
            Else
                MessageBox.Show("Error en el ingreso del registro, comuniquese con el administrador del sistema ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            cargarConsulta()
        End If
    End Sub
    Private Function validar() As Boolean
        If (txtCodigo.Text <> "") Then
            If (objIngProdLn.consultar_valor("SELECT codigo FROM referencias WHERE codigo ='" & txtCodigo.Text & "'", "CORSAN") <> "0") Then
                Return True
            Else
                MessageBox.Show("El código del producto no existe, verifique! ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If
        End If
        Return False
    End Function
    Private Sub nuevo()
        txtCodigo.Text = ""
        txtResis.Text = ""
        cboOrigen.Text = "Seleccione"
        txtCal.Text = ""
        txtRec.Text = ""
        txtCli.Text = "890900160"
    End Sub
    Private Sub delete(ByVal fila As Integer)
        Dim cliente As String = dtgMaestro.Item("nit", fila).Value
        Dim codigo As String = dtgMaestro.Item("codigo", fila).Value
        Dim sql As String = "DELETE FROM J_referencia_ficha_tec WHERE codigo = '" & codigo & "' AND nit =" & cliente
        If (objOpSimplesLn.ejecutar(sql, "PRODUCCION") > 0) Then
            MessageBox.Show("El registro se elimino en forma correcta!", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cargarConsulta()
        Else
            MessageBox.Show("Error al eliminar el registro,comuniquese con el administrador del sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Private Sub cargarConsulta()
        Dim sql As String = "SELECT j.codigo,j.resistencia,j.procedencia,j.calidad,j.recubrimiento,j.nit ,t.nombres FROM J_referencia_ficha_tec j INNER JOIN CORSAN.dbo.terceros t ON j.nit = t.nit"

        If (txtCodFiltro.Text <> "") Then
            sql = sql & " WHERE codigo like '%" & txtCodFiltro.Text & "%'"
        End If
        dt = objOpSimplesLn.crearDataTableVariasCol(sql, "PRODUCCION")
        dtgMaestro.DataSource = dt
    End Sub
    Private Sub cargarCbo()
        Dim sql As String = "Select nit,nombres  from Jjv_prov_alambron  "
        Dim dt2 As New DataTable
        Dim row As DataRow
        dt2 = New DataTable
        dt2 = objIngProdLn.listar_datatable(sql, "CORSAN")
        row = dt2.NewRow
        row("nit") = 0
        row("nombres") = "Seleccione"
        dt2.Rows.Add(row)
        cboOrigen.DataSource = dt2
        cboOrigen.ValueMember = "nit"
        cboOrigen.DisplayMember = "nombres"
        cboOrigen.Text = "Seleccione"
        cboOrigen.SelectedValue = 0
    End Sub

    Private Sub btnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificar.Click
        save()
    End Sub


    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        nuevo()
    End Sub

    Private Sub txtCodFiltro_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodFiltro.TextChanged
        cargarConsulta()
    End Sub
    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        FrmLogin.Show()
        FrmPrincipal.Close()
        FrmLogin.Activate()
        Me.Close()
    End Sub

    Private Sub btn_ppal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ppal.Click
        FrmPrincipal.Show()
        Me.Close()
        FrmPrincipal.Activate()
    End Sub

    Private Sub txtCli_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCli.Click
        txtCli.Text = ""
        groupCliente.Visible = True
        txt_nombres.Focus()
    End Sub

    Private Sub txt_nombres_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_nombres.TextChanged
        carga_comp = False
        txt_nit.Text = ""
        carga_comp = True
        If (carga_comp And txt_nombres.Text.Length > 3) Then
            cargar_clientes()
        End If
    End Sub

    Private Sub txt_nit_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_nit.TextChanged
        carga_comp = False
        txt_nombres.Text = ""
        carga_comp = True
        If (carga_comp And txt_nit.Text.Length > 2) Then
            cargar_clientes()
        End If
    End Sub

    Private Sub dtg_clientes_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtg_clientes.CellContentClick
        If (e.RowIndex >= 0) Then
            If (dtg_clientes.Columns(e.ColumnIndex).Name = colOk.Name) Then
                txtCli.Text = ""
                txtCli.Text = dtg_clientes.Item("nit", e.RowIndex).Value
                groupCliente.Visible = False
                dtg_clientes.DataSource = Nothing
                txt_nit.Text = ""
                txt_nombres.Text = ""
            End If
        End If
    End Sub

    Private Sub cargar_clientes()
        Dim sql As String = "Select nit,nombres,ciudad FROM terceros "
        Dim whereSql As String = "WHERE (concepto_1 like '%3%' or concepto_1 like '%4%' or concepto_1 like '%9%') "
        If (txt_nit.Text <> "") Then
            whereSql &= " AND nit like '" & txt_nit.Text & "%'"
        ElseIf (txt_nombres.Text <> "") Then
            whereSql &= "AND nombres like '%" & txt_nombres.Text & "%'"
        End If
        sql &= whereSql
        dtg_clientes.DataSource = objOpSimplesLn.listar_datatable(sql, "CORSAN")
    End Sub

    Private Sub btn_cerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cerrar.Click
        txt_nit.Text = ""
        txt_nombres.Text = ""
        txtCli.Text = "890900160"
        dtg_clientes.DataSource = Nothing
        groupCliente.Visible = False
    End Sub

End Class