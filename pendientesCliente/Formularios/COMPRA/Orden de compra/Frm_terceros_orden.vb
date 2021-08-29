'ventana hecha por david hincapié
Imports logicaNegocios
Public Class Frm_terceros_orden
    Private objQuejaRecLn As New QuejaRecLn
    Private formulario As String
    Private fila As Integer
    Private col As String
    Private frm As New Frm_orden_compra
    Public Sub main(ByVal frm As String, ByVal fil As Integer, ByVal columna As String, ByVal obj_frm_orden As Frm_orden_compra)
        Me.frm = obj_frm_orden
        fila = fil
        formulario = frm
        col = columna
        Select Case col
            Case "txtResp"
                areaResp()
            Case "txtInsatis"
                insatisfact()
            Case "txtPqr"
                pqr()
        End Select
    End Sub
    Public Sub terceros()
        Dim strSql As String = "SELECT nit, nombres FROM terceros  "
        Dim whereSql As String = "WHERE "
        Dim valor As String = ""
        If (txtNit.Text <> "") Then
            valor = txtNit.Text
            whereSql += "nit like '%" & valor & "%'"
        ElseIf (txtNombres.Text <> "") Then
            valor = txtNombres.Text
            whereSql += "nombres like '%" & valor & "%'"
        End If
        If (valor.Length > 3) Then
            strSql = strSql & whereSql
            dtg_clientes.DataSource = objQuejaRecLn.listar_datatable(strSql)
        End If
    End Sub
    Public Sub areaResp()
        Dim strSql As String = "SELECT resp.id,ter.nombres,resp.descripcion,ter.nit  " & _
                                    "FROM J_area_resp resp , terceros ter "
        Dim whereSql As String = "WHERE ter.nit = resp.nit "
        Dim valor As String = ""
        If (txtNit.Text <> "") Then
            valor = txtNit.Text
            whereSql += "AND ter.nit like '%" & valor & "%'"
        ElseIf (txtNombres.Text <> "") Then
            valor = txtNombres.Text
            whereSql += "AND ter.nombres like '%" & valor & "%'"
        End If
        If (valor.Length > 3 Or valor.Length = 0) Then
            strSql = strSql & whereSql
            dtg_clientes.DataSource = objQuejaRecLn.listar_datatable(strSql)
        End If
    End Sub
    Public Sub insatisfact()
        Dim strSql As String = "SELECT id_insatisfac,descripcion " & _
                                    "FROM J_insatisfactor "
        Dim whereSql As String = ""
        Dim valor As String = ""
        If (txtNit.Text <> "") Then
            valor = txtNit.Text
            whereSql += "WHERE id_insatisfac like '%" & valor & "%'"
        ElseIf (txtNombres.Text <> "") Then
            valor = txtNombres.Text
            whereSql += "WHERE descripcion like '%" & valor & "%'"
        End If
        strSql = strSql & whereSql
        dtg_clientes.DataSource = objQuejaRecLn.listar_datatable(strSql)
    End Sub
    Public Sub pqr()
        Dim strSql As String = "SELECT id_pqr,descripcion " & _
                                    "FROM J_pqr "
        Dim whereSql As String = ""
        Dim valor As String = ""
        If (txtNit.Text <> "") Then
            valor = txtNit.Text
            whereSql += "WHERE id_pqr like '%" & valor & "%'"
        ElseIf (txtNombres.Text <> "") Then
            valor = txtNombres.Text
            whereSql += "WHERE descripcion like '%" & valor & "%'"
        End If
        strSql = strSql & whereSql
        dtg_clientes.DataSource = objQuejaRecLn.listar_datatable(strSql)
    End Sub
    Public Sub codigo()
        Dim strSql As String = "SELECT codigo,descripcion  " & _
                                    "FROM referencias "
        Dim whereSql As String = ""
        Dim valor As String = ""
        If (txtNit.Text <> "") Then
            valor = txtNit.Text
            whereSql += "WHERE codigo like '%" & valor & "%'"
        ElseIf (txtNombres.Text <> "") Then
            valor = txtNombres.Text
            whereSql += "WHERE descripcion like '%" & valor & "%'"
        End If
        If (valor.Length >= 3) Then
            strSql = strSql & whereSql
            dtg_clientes.DataSource = objQuejaRecLn.listar_datatable(strSql)
        End If
    End Sub
    Private Sub txtNit_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNit.TextChanged
        txtNombres.Text = ""
        Select Case col
            Case "colProveedor"
                terceros()
            Case ""
                terceros()
            Case "txtResp"
                areaResp()
            Case "txtInsatis"
                insatisfact()
            Case "txtPqr"
                pqr()
            Case "txtCodigo"
                codigo()
        End Select
    End Sub
    Private Sub txtNombres_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNombres.TextChanged
        txtNit.Text = ""
        Select Case col
            Case "colProveedor"
                terceros()
            Case ""
                terceros()
            Case "txtResp"
                areaResp()
            Case "txtInsatis"
                insatisfact()
            Case "txtPqr"
                pqr()
            Case "txtCodigo"
                codigo()

        End Select
    End Sub
    Private Sub dtg_clientes_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtg_clientes.CellDoubleClick
        cargarDatos()
    End Sub
    Private Sub cargarDatos()


        Dim deci As Boolean = True
        If (fila >= 0) Then
            Select Case formulario
                Case "maestros"
                    FrmMaestros.dtgMaestros.Item("txtId", fila).Value = dtg_clientes.Item("nit", dtg_clientes.CurrentCell.RowIndex).Value
                    FrmMaestros.dtgMaestros.Item("txtNombre", fila).Value = dtg_clientes.Item("nombres", dtg_clientes.CurrentCell.RowIndex).Value
                    FrmMaestros.dtgMaestros.Columns("txtNombre").Visible = True
                    FrmMaestros.Activate()
                Case "quejas"
                    If (dtg_clientes.RowCount > 0) Then

                        Select Case col
                            Case "colProveedor"
                                frm.dtgSolicitud.Item("colProveedor", fila).Value = dtg_clientes.Item("nombres", 0).Value
                                frm.dtgSolicitud.Item("Id_proveedor", fila).Value = dtg_clientes.Item("nit", dtg_clientes.CurrentCell.RowIndex).Value
                            Case "txtResp"
                                FrmQuejaRec.dtgQuejaRec.Item("txtidResp", fila).Value = dtg_clientes.Item("id", dtg_clientes.CurrentCell.RowIndex).Value
                                FrmQuejaRec.dtgQuejaRec.Item("txtResp", fila).Value = dtg_clientes.Item("descripcion", dtg_clientes.CurrentCell.RowIndex).Value
                                FrmQuejaRec.dtgQuejaRec.Item("txtNitResp", fila).Value = dtg_clientes.Item("nit", dtg_clientes.CurrentCell.RowIndex).Value
                            Case "txtInsatis"
                                FrmQuejaRec.dtgQuejaRec.Item("txtIdInsaticfac", fila).Value = dtg_clientes.Item("id_insatisfac", dtg_clientes.CurrentCell.RowIndex).Value
                                FrmQuejaRec.dtgQuejaRec.Item("txtInsatis", fila).Value = dtg_clientes.Item("descripcion", dtg_clientes.CurrentCell.RowIndex).Value
                            Case "txtPqr"
                                FrmQuejaRec.dtgQuejaRec.Item("txtIdPqr", fila).Value = dtg_clientes.Item("id_pqr", dtg_clientes.CurrentCell.RowIndex).Value
                                FrmQuejaRec.dtgQuejaRec.Item("txtPqr", fila).Value = dtg_clientes.Item("descripcion", dtg_clientes.CurrentCell.RowIndex).Value
                            Case "txtCodigo"
                                If (FrmQuejaRec.dtgQuejaRec.Item("txtCodigo", fila).Value = "") Then
                                    FrmQuejaRec.dtgQuejaRec.Item("txtCodigo", fila).Value = dtg_clientes.Item("codigo", dtg_clientes.CurrentCell.RowIndex).Value
                                    FrmQuejaRec.dtgQuejaRec.Item("txtDescCodigo", fila).Value = dtg_clientes.Item("descripcion", dtg_clientes.CurrentCell.RowIndex).Value
                                Else
                                    FrmQuejaRec.dtgQuejaRec.Columns("txtCodigo").DefaultCellStyle.WrapMode = DataGridViewTriState.True
                                    FrmQuejaRec.dtgQuejaRec.Columns("txtDescCodigo").DefaultCellStyle.WrapMode = DataGridViewTriState.True

                                    FrmQuejaRec.dtgQuejaRec.Item("txtCodigo", fila).Value += vbCrLf & "-" & dtg_clientes.Item("codigo", dtg_clientes.CurrentCell.RowIndex).Value
                                    FrmQuejaRec.dtgQuejaRec.Item("txtDescCodigo", fila).Value += vbCrLf & dtg_clientes.Item("descripcion", dtg_clientes.CurrentCell.RowIndex).Value
                                End If
                        End Select
                    End If
            End Select
            Me.Close()
        End If
    End Sub
    Private Sub txtNit_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNit.KeyPress
        If (e.KeyChar = Microsoft.VisualBasic.ChrW(13) And dtg_clientes.RowCount <> 0) Then
            cargarDatos()
        End If
    End Sub

    Private Sub txtNombres_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNombres.KeyPress
        If (e.KeyChar = Microsoft.VisualBasic.ChrW(13)) Then
            cargarDatos()
        End If
    End Sub
End Class