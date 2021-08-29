Imports logicaNegocios
Public Class FrmAuditCambios
    Private objOpSimplesLn As New Op_simpesLn
    Dim dt As New DataTable
    Dim cargaComp As Boolean = False
    Dim nom_modulo As String
    Public Sub Main(ByVal nom_modulo)
        cboModuloFiltro.SelectedValue = nom_modulo
    End Sub
    Private Sub FrmAuditCambios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargarCbo()
        cargarConsulta()
        cargaComp = True
    End Sub
    Private Sub cargarConsulta()
        Dim whereSql As String = ""
        Dim sql As String = ""
        If (cboModuloFiltro.Text <> "Todo") Then
            whereSql = "AND C.modulo = '" & cboModuloFiltro.SelectedValue & "'"
        End If
        sql = "SELECT C.numero,M.nom_modulo,T.nombres as responsable,fecha,C.descripcion FROM J_spic_audit_cambios C ,j_spic_modulos M, terceros T WHERE T.nit = C.responsable AND M.descripcion = C.modulo " & whereSql
        dt = objOpSimplesLn.crearDataTableVariasCol(sql, "CORSAN")
        dtgMaestro.DataSource = dt
    End Sub

    Private Sub dtgMaestro_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgMaestro.CellContentClick
        Dim iResponce As Integer
        If (e.RowIndex >= 0) Then
            If (dtgMaestro.Columns(e.ColumnIndex).Name = "btnDelete") Then
                iResponce = MessageBox.Show("Realmente desea eliminar el registro? ", "Atención", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                If (iResponce = 6) Then
                    delete(e.RowIndex)
                End If
            End If
        End If
    End Sub
    Private Sub save()
        Dim fec As String = objOpSimplesLn.cambiarFormatoFecha(cboFec.Value)
        Dim sql As String = "INSERT INTO J_spic_audit_cambios (modulo,responsable,fecha,descripcion) VALUES ('" & cboModulo.SelectedValue & "','" & cboResponsable.SelectedValue & "','" & fec & "','" & txtDescripcion.Text & "')"
        If (objOpSimplesLn.ejecutar(sql, "CORSAN") > 0) Then
            MessageBox.Show("El registro se ingreso en forma correcta!", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cargarConsulta()
        Else
            MessageBox.Show("Error al ingresar el registro,comuniquese con el administrador del sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Private Sub nuevo()
        cboModulo.Text = "Seleccione"
        cboResponsable.Text = "Seleccione"
        txtDescripcion.Text = ""
    End Sub
    Private Sub delete(ByVal fila As Integer)
        Dim valor As String = dtgMaestro.Item("numero", fila).Value
        Dim sql As String = "DELETE FROM J_spic_audit_cambios WHERE numero = '" & valor & "'"
        If (objOpSimplesLn.ejecutar(sql, "CORSAN") > 0) Then
            MessageBox.Show("El registro se elimino en forma correcta!", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cargarConsulta()
        Else
            MessageBox.Show("Error al eliminar el registro,comuniquese con el administrador del sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Private Sub cargarCbo()
        Dim sql As String = ""
        Dim col As New DataColumn
        Dim dt As DataTable
        Dim dr As DataRow
        sql = "SELECT descripcion,nom_modulo FROM J_spic_modulos ORDER BY nom_modulo "
        dt = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        dr = dt.NewRow
        dr("nom_modulo") = "Seleccione"
        dt.Rows.Add(dr)
        cboModulo.DataSource = dt
        cboModulo.ValueMember = "descripcion"
        cboModulo.DisplayMember = "nom_modulo"
        cboModulo.Text = "Seleccione"

        dt = New DataTable
        sql = "SELECT descripcion,nom_modulo FROM J_spic_modulos ORDER BY nom_modulo "
        dt = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        dr = dt.NewRow
        dr("nom_modulo") = "Seleccione"
        dt.Rows.Add(dr)
        cboModuloFiltro.DataSource = dt
        cboModuloFiltro.ValueMember = "descripcion"
        cboModuloFiltro.DisplayMember = "nom_modulo"
        cboModuloFiltro.Text = "Todo"

        dt = New DataTable
        sql = "SELECT nit,nombres FROM v_nom_personal ORDER BY nombres"
        dt = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        dr = dt.NewRow
        dr("nombres") = "Seleccione"
        dt.Rows.Add(dr)
        cboResponsable.DataSource = dt
        cboResponsable.ValueMember = "nit"
        cboResponsable.DisplayMember = "nombres"
        cboResponsable.Text = "Seleccione"

    End Sub

    Private Sub cboModuloFiltro_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboModuloFiltro.SelectedIndexChanged
        If (cargaComp) Then
            cargarConsulta()
        End If
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        nuevo()
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        save()
        nuevo()
    End Sub
End Class