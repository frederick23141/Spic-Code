Imports logicaNegocios
Imports entidadNegocios
Public Class FrmGestTransaSinStock
    Dim objTraslado_bodLn As New traslado_bodLn
    Private objOpSimplesLn As New Op_simpesLn
    Private objIngProdLn As New Ing_prodLn
    Private objUsuarioEn As New UsuarioEn
    Private permiso As String
    Private objOperacionesForm As New OperacionesFormularios
    Public Sub MAIN(ByVal usuario As UsuarioEn, ByVal permiso As String)
        Me.objUsuarioEn = usuario
        Me.permiso = permiso
        cargarConsulta()
        If (Me.permiso <> "ADMIN") Then
            dtgConsulta.Columns(btnDelete.Name.ToString).Visible = False
            dtgConsulta.Columns("solucionado").Visible = False
            dtgConsulta.Columns("anulado").Visible = False
            dtgConsulta.Columns("notas").Visible = False
        End If
    End Sub

    Private Sub dtgConsulta_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgConsulta.CellContentClick
        If (e.RowIndex >= 0) Then
            Dim numCol As Integer = e.ColumnIndex
            Dim nombCol As String = dtgConsulta.Columns(numCol).Name
            Dim fila As Integer = e.RowIndex
            Dim resp As String = ""
            If (nombCol = btnEdit.Name.ToString Or nombCol = btnDelete.Name.ToString Or nombCol = btnAutorizar.Name.ToString) Then
                Select Case nombCol
                    Case btnEdit.Name
                        If (dtgConsulta.Item("codigo", fila).Value.ToString <> "") Then
                            If (objOpSimplesLn.validarCodigo(dtgConsulta.Item("codigo", fila).Value)) Then
                                If IsNumeric(dtgConsulta.Item("kilos", fila).Value) Then
                                    modificar(fila)
                                    cargarConsulta()
                                Else
                                    MessageBox.Show("El valor ingresado para los kilos es incorrecto,verifique", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                End If

                            Else
                                MessageBox.Show("El código ingresado no existe,verifique", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End If
                        Else
                            MessageBox.Show("El código no puede ser ingresado en blanco,verifique", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    Case btnDelete.Name
                        delete(fila)
                        cargarConsulta()
                    Case btnAutorizar.Name
                        If (dtgConsulta.Item("codigo", fila).Value.ToString <> "") Then
                            If (objOpSimplesLn.validarCodigo(dtgConsulta.Item("codigo", fila).Value)) Then
                                If IsNumeric(dtgConsulta.Item("kilos", fila).Value) Then
                                    resp = InputBox("Ingrese motivo de autorización de la transacción!", "Autorizar")
                                    If (resp <> "") Then
                                        autorizar(fila, resp)
                                        cargarConsulta()
                                    End If
                                Else
                                    MessageBox.Show("El valor ingresado para los kilos es incorrecto,verifique", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                End If

                            Else
                                MessageBox.Show("El código ingresado no existe,verifique", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End If
                        Else
                            MessageBox.Show("El código no puede ser ingresado en blanco,verifique", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                End Select
            End If
        End If
    End Sub
    Private Sub autorizar(ByVal fila As Integer, ByVal motivo As String)
        Dim sqlUpdate As String = "UPDATE J_audit_stock_insuficiente SET solucionado = 'S',notas = 'Autorizo usuario:" & objUsuarioEn.nombre & " " & Now.Date & " motivo:" & motivo & "' WHERE numero = " & dtgConsulta.Item("numero", fila).Value & ""
        Dim stockInsuficiente As Boolean = False
        Dim usuario As String = objUsuarioEn.usuario
        Dim tipo As String = dtgConsulta.Item("tipo", fila).Value
        Dim notas As String = "SPIC aut_traslado " & Now.Date & " usuario: " & usuario
        Dim kilos As Double = Convert.ToDouble(dtgConsulta.Item("kilos", fila).Value)
        Dim codigo As String = Trim(dtgConsulta.Item("codigo", fila).Value)
        Dim bodega As String = objTraslado_bodLn.obtenerBodegaXcodigo(codigo)
        Dim dFec As Date = Now
        Dim stock As Double = objOpSimplesLn.consultarStock(dtgConsulta.Item("codigo", fila).Value, bodega)
        Dim dt As New DataTable
        If (kilos > stock) Then
            MessageBox.Show("Stock insuficiente, no se puede realizar la transacción!", "Corrija", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            dt = objTraslado_bodLn.trasladoBodega(kilos, codigo, bodega, dFec, notas, usuario, tipo)
            If (dt.Rows(0).Item("numero") > 0) Then
                MessageBox.Show("Transacción realizada con exito! ", "Extio", MessageBoxButtons.OK, MessageBoxIcon.Information)
                modificar(fila)
                If (objOpSimplesLn.ejecutar(sqlUpdate, "CORSAN") <= 0) Then
                    MessageBox.Show("Error al poner las notas de auditoria, comuniquese cone l administrador del sistema! ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                MessageBox.Show("Error al realizar la transacción , comuniquese con el administrador del sistema! ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Private Sub modificar(ByVal fila As Integer)
        Dim kilos As Double = dtgConsulta.Item("kilos", fila).Value
        Dim codigo As String = Trim(dtgConsulta.Item("codigo", fila).Value)
        Dim sql As String = "UPDATE J_audit_stock_insuficiente SET kilos = '" & kilos & "',codigo = '" & codigo & "',notas = 'modifico usuario:" & objUsuarioEn.nombre & Now & "' WHERE numero = " & dtgConsulta.Item("numero", fila).Value & ""
        If (objOpSimplesLn.ejecutar(sql, "CORSAN")) Then
            MessageBox.Show("El registro se modifico en forma exitosa ", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Error en la modificacón del registro, comuniquese con el administrador del sistema ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Private Sub delete(ByVal fila As Integer)
        Dim resp As String = InputBox("Ingrese motivo de eliminación de la transacción!", "Eliminar")
        If (resp <> "") Then
            Dim sql As String = "UPDATE J_audit_stock_insuficiente SET anulado = 'S', notas = 'Elimino usuario:" & objUsuarioEn.nombre & " " & Now.Date & " motivo:" & resp & "' WHERE numero = " & dtgConsulta.Item("numero", fila).Value & ""
            If (objOpSimplesLn.ejecutar(sql, "CORSAN") > 0) Then
                MessageBox.Show("El registro se elimino en forma correcta!", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Error al eliminar el registro,comuniquese con el administrador del sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub
    Private Sub cargarConsulta()
        Dim dt As DataTable
        Dim whereSql As String = "WHERE T.nit = A.nit  "
        If (txtNumero.Text <> "") Then
            whereSql &= "AND A.numero like '" & txtNumero.Text & "%' "
        End If
        If (txtCodigo.Text <> "") Then
            whereSql &= "AND A.codigo = '" & txtCodigo.Text & "' "
        End If
        If (permiso <> "ADMIN") Then
            whereSql &= " AND anulado is null AND solucionado is null "
        End If
        Dim sql As String = "SELECT  A.numero, A.codigo, A.kilos, A.tipo, A.nit, T.nombres, A.fecha, A.solucionado, A.anulado, A.notas " & _
                                "FROM J_audit_stock_insuficiente A ,terceros T " & whereSql
        dt = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        dtgConsulta.DataSource = dt
        dtgConsulta.Columns("numero").ReadOnly = True
        dtgConsulta.Columns("tipo").ReadOnly = True
        dtgConsulta.Columns("nit").ReadOnly = True
        dtgConsulta.Columns("nombres").ReadOnly = True
        dtgConsulta.Columns("fecha").ReadOnly = True
        dtgConsulta.Columns("solucionado").ReadOnly = True
        dtgConsulta.Columns("anulado").ReadOnly = True
        dtgConsulta.Columns("notas").ReadOnly = True
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

    Private Sub btnActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActualizar.Click
        cargarConsulta()
    End Sub

    Private Sub txtNumero_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNumero.TextChanged
        If (txtNumero.Text.Length > 1 Or txtNumero.Text.Length = 0) Then
            cargarConsulta()
            txtCodigo.Text = ""
        End If
    End Sub
 Private Sub btn_excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_excel.Click
        objOperacionesForm.ExportarDatosExcel(dtgConsulta, "Transacciones sin stock")
    End Sub

    Private Sub txtCodigo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodigo.TextChanged
        txtNumero.Text = ""
    End Sub
End Class