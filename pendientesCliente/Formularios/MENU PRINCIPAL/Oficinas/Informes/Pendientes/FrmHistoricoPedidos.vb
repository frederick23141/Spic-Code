Imports logicaNegocios
Public Class FrmAuditPedidos
    Dim objOpSimplesLn As New Op_simpesLn
    Dim carga_comp As Boolean = True
    Private objOperacionesForm As OperacionesFormularios = New OperacionesFormularios
    Private Sub cargarConsulta()
        Dim sqlCorsan As String = ""
        Dim sqlNoReflej As String = ""
        Dim sqlSelect As String = "SELECT D.bodega,D.numero,D.fecha,D.nit,T.nombres,D.condicion,D.valor_total,D.autorizacion,D.usuario ,D.pc,D.notas,D.autoriz_texto,D.notas5,D.notas_aut,D.nota_vta "
        Dim sqlFrom As String = "FROM terceros T, "
        Dim sqlWhere As String = "WHERE numero >= 10250000 and T.nit = D.nit  "
        If (txtNit.Text <> "") Then
            sqlWhere &= "AND D.nit like '" & txtNit.Text & "%'"
        ElseIf (txtNombres.Text <> "") Then
            sqlWhere &= "AND T.nombres like '%" & txtNombres.Text & "%'"
        ElseIf (txtNumero.Text <> "") Then
            sqlWhere &= "AND D.numero like '" & txtNumero.Text & "%'"
        End If
        sqlCorsan = sqlSelect & sqlFrom & " documentos_ped D " & sqlWhere
        sqlNoReflej = sqlSelect & sqlFrom & " JJV_documentos_ped D " & sqlWhere
        dtgDms.DataSource = objOpSimplesLn.listar_datatable(sqlCorsan, "CORSAN")
        dtgNoReflej.DataSource = objOpSimplesLn.listar_datatable(sqlNoReflej, "CORSAN")
    End Sub
    Private Sub txtNombres_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNombres.TextChanged
        If (txtNit.Text = "" And txtNombres.Text = "" And txtNumero.Text = "") Then
            dtgDms.DataSource = Nothing
            dtgNoReflej.DataSource = Nothing
        End If
        If (carga_comp And (txtNombres.Text.Length > 5)) Then
            carga_comp = False
            txtNit.Text = ""
            txtNumero.Text = ""
            cargarConsulta()
            carga_comp = True
        End If
    End Sub
    Private Sub txtNumero_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNumero.TextChanged
        If (txtNit.Text = "" And txtNombres.Text = "" And txtNumero.Text = "") Then
            dtgDms.DataSource = Nothing
            dtgNoReflej.DataSource = Nothing
        End If
        If (carga_comp And (txtNumero.Text.Length > 5)) Then
            carga_comp = False
            txtNit.Text = ""
            txtNombres.Text = ""
            cargarConsulta()
            carga_comp = True
        End If
    End Sub
    Private Sub txtNit_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNit.TextChanged
        If (txtNit.Text = "" And txtNombres.Text = "" And txtNumero.Text = "") Then
            dtgDms.DataSource = Nothing
            dtgNoReflej.DataSource = Nothing
        End If
        If (carga_comp And (txtNit.Text.Length > 2)) Then
            carga_comp = False
            txtNumero.Text = ""
            txtNombres.Text = ""
            cargarConsulta()
            carga_comp = True
        End If
    End Sub

    Private Sub DmsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DmsToolStripMenuItem.Click
        objOperacionesForm.ExportarDatosExcel(dtgDms, "Pedidos Dms")
    End Sub

    Private Sub NoReflejadosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NoReflejadosToolStripMenuItem.Click
        objOperacionesForm.ExportarDatosExcel(dtgNoReflej, "pedidos No reflejados")
    End Sub

    Private Sub btn_ppal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ppal.Click
        FrmPrincipal.Show()
        Me.Close()
        FrmPrincipal.Activate()
    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        FrmLogin.Show()
        FrmPrincipal.Close()
        Me.Close()
    End Sub
End Class