Imports logicaNegocios
Public Class Frm_proveedor_categoria
    Private objIngProdLn As New Ing_prodLn
    Private carga_comp As Boolean = False

    Private Sub Frm_proveedor_categoria_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargarConsulta()
        cargarCbo()
        carga_comp = True
    End Sub
    Private Sub cargarConsulta()
        Dim sql As String = "SELECT P.id,C.descripcion as categoria,P.categoria As id_categoria,T.nombres,P.nit,P.nomb_contacto " & _
                            "FROM C_proveedor_categoria P ,corsan.dbo.terceros T,C_categorias_proveedores C " & _
                                    "WHERE T.nit = P.nit AND P.categoria = C.id"
        dtgConsulta.DataSource = objIngProdLn.listar_datatable(sql, "PRODUCCION")
        dtgConsulta.Columns("id_categoria").Visible = False
    End Sub
    Private Sub cargarCbo()
        Dim sql As String
        sql = "SELECT nit,nombres   FROM TERCEROS T WHERE T.concepto_1 in (9,4,2) ORDER BY T.nombres "
        cboProveedor.DataSource = objIngProdLn.listar_datatable(sql, "CORSAN")
        cboProveedor.ValueMember = "nit"
        cboProveedor.DisplayMember = "nombres"
        cboProveedor.Text = "Seleccione"
        sql = "SELECT id,descripcion   FROM C_categorias_proveedores "
        cboCategoria.DataSource = objIngProdLn.listar_datatable(sql, "PRODUCCION")
        cboCategoria.ValueMember = "id"
        cboCategoria.DisplayMember = "descripcion"
        cboCategoria.Text = "Seleccione"
    End Sub
    Private Sub dtgConsulta_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgConsulta.CellContentClick
        Dim nomb_col As String = dtgConsulta.Columns(e.ColumnIndex).Name
        If (nomb_col = colBorrar.Name) Then
            Dim resp As Integer = MessageBox.Show("Esta seguro que desea eliminar esta evaluación? ", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If (resp = 6) Then
                Dim listSql As New List(Of Object)
                Dim sql As String
                Dim id As Integer = dtgConsulta.Item("id", e.RowIndex).Value
                sql = "DELETE FROM C_proveedor_categoria  WHERE id =" & id

                listSql.Add(sql)
                If (objIngProdLn.ejecutar(sql, "PRODUCCION")) Then
                    cargarConsulta()
                    MessageBox.Show("El registro se elimino en forma correcta! ", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Error al elimino el registro! ", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        End If
    End Sub
    Private Sub nuevo()
        cboProveedor.Text = "Seleccione"
        cboCategoria.Text = "Seleccione"
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If (cboCategoria.Text <> "Seleccione" And cboProveedor.Text <> "Seleccione" And txtContacto.Text <> "") Then
            guardar()
        Else
            MessageBox.Show("Verifique que el proveedor y la categoria esten seleccionados! ", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Private Sub guardar()
        Dim proveedor As String = cboProveedor.SelectedValue
        Dim categoria As Integer = cboCategoria.SelectedValue
        Dim contacto As String = txtContacto.Text
        Dim sql As String = "INSERT INTO C_proveedor_categoria (nit,categoria,nomb_contacto) VALUES (" & proveedor & ", " & categoria & ",'" & contacto & "')"
        If (objIngProdLn.ejecutar(sql, "PRODUCCION")) Then
            cargarConsulta()
            MessageBox.Show("El registro se guardo en forma correcta! ", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Error al guardar el registro! ", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
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

    Private Sub cboCategoria_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCategoria.SelectedIndexChanged
        If (carga_comp) Then
            cargarConsulta()
        End If

    End Sub
End Class