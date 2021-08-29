Imports logicaNegocios
Public Class FrmMaestroTransHandHeld
    Private objOpSimplesLn As New Op_simpesLn
    Private objIngProdLn As New Ing_prodLn
    Private cargaComp As Boolean = False
    Private Sub FrmMaestroFichas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargarConsulta()
        chekearIngresados()
        cargaComp = True
    End Sub
  
    Private Sub save(ByVal fila As Integer)
        Dim sql As String = ""
        Dim tipo As String = dtgMaestro.Item("tipo", fila).Value
        sql = "INSERT INTO J_transacciones_handHeld " & _
                           "(tipo) " & _
                                "VALUES " & _
                             "('" & tipo & "')"

        If (objOpSimplesLn.ejecutar(sql, "CORSAN") >= 0) Then

        Else
            MessageBox.Show("Error en el ingreso del registro, comuniquese con el administrador del sistema ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Private Sub delete(ByVal fila As Integer)
        Dim tipo As String = dtgMaestro.Item("tipo", fila).Value
            Dim sql As String = "DELETE FROM J_transacciones_handHeld WHERE tipo = '" & tipo & "'"
            If (objOpSimplesLn.ejecutar(sql, "CORSAN") > 0) Then

            Else
                MessageBox.Show("Error al eliminar el registro,comuniquese con el administrador del sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
    End Sub
    Private Sub cargarConsulta()
        Dim dt As DataTable
        Dim sql As String = "Select tipo,descripcion FROM tipo_transacciones " & _
                            "WHERE sw in (11,12) AND tipo not in ('COAE','COCF','COHT','COIS','COPA','COSP','COUN','EAI','EPTE')"
        dt = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        dtgMaestro.DataSource = dt
        dtgMaestro.Columns("tipo").ReadOnly = True
        dtgMaestro.Columns("descripcion").ReadOnly = True
    End Sub

    Private Sub chekearIngresados()
        Dim list As New List(Of Object)
        Dim tipo As String = ""
        list = objOpSimplesLn.lista("SELECT tipo FROM J_transacciones_handHeld")
        For i = 0 To list.Count - 1
            tipo = list(i)
            chekearFila(tipo)
        Next
    End Sub
    Private Sub chekearFila(ByVal tipo As String)
        For i = 0 To dtgMaestro.RowCount - 1
            If (dtgMaestro.Item("tipo", i).Value = tipo) Then
                dtgMaestro.Item(chkAdd.Name, i).Value = 1
                i = dtgMaestro.RowCount - 1
            End If
        Next
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

    Private Sub dtgMaestro_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgMaestro.CellValueChanged
        If (cargaComp) Then
            If (e.RowIndex >= 0) Then
                Dim numCol As Integer = e.ColumnIndex
                Dim nombCol As String = dtgMaestro.Columns(numCol).Name
                Dim fila As Integer = e.RowIndex
                If (nombCol = chkAdd.Name) Then
                    If (dtgMaestro.Item(chkAdd.Name, fila).Value) Then
                        save(fila)
                    Else
                        delete(fila)
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub dtgMaestro_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgMaestro.CellContentClick
        If (e.RowIndex >= 0) Then
            dtgMaestro.CurrentCell = Nothing
        End If
    End Sub
End Class