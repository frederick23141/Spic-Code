Imports logicaNegocios
Imports entidadNegocios
Imports accesoDatos
Public Class frm_orden_prod_punti_empaque
    Private obj_Ing_prodLn As New Ing_prodLn
    Private objOpsimpesLn As New Op_simpesLn
    Private numero_transaccion As Double
    Private objOrdenProdLn As New OrdenProdLn
    Dim objTraslado_bodLn As New traslado_bodLn
    Dim obj_gestion_materia_primaLn As New Gestion_materia_primaLn
    Private objOperacionesDb As New OperacionesDb

    Private val_punt As New obj_val_punt

    Private Sub frm_orden_prod_punti_empaque_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim Sql As String = "SELECT T.tipo,T.sw " & _
        "FROM  tipo_transacciones T " & _
              "WHERE T.tipo = 'SPPP' "
        cbo_transaccion_empaque.DataSource = obj_Ing_prodLn.listar_datatable(Sql, "CORSAN")
        cbo_transaccion_empaque.ValueMember = "sw"
        cbo_transaccion_empaque.DisplayMember = "tipo"
        cbo_transaccion_empaque.SelectedIndex = 0

        btn_transaccion_empaque.Enabled = True

        txt_lector_empaque.Text = ""
        txt_kilos_empaque.Text = ""
        lblCodigoEmpaque.Text = ""
        lblDescEmpaque.Text = ""
        txt_lector_empaque.Focus()

        txt_lector_empaque.Enabled = True
    End Sub
    Private Sub txt_lector_empaque_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_lector_empaque.Leave
        txt_lector_empaque.BackColor = Color.Red
    End Sub

    Private Sub txt_lector_empaque_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_lector_empaque.Enter
        txt_lector_empaque.BackColor = Color.Green
    End Sub


    Private Sub txt_lector_empaque_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_lector_empaque.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            txt_lector_empaque.Text = Replace(txt_lector_empaque.Text, "'", "-")
            If val_punt.validar_no_conforme(txt_lector_empaque.Text) Then
                Dim consecutivo As String = txt_lector_empaque.Text
                If val_punt.validarCodigoBarrasPuntilleria(consecutivo) Then
                    If val_punt.validarTransaccionEmpaque(consecutivo) Then
                        If val_punt.validarProductoAnulado(consecutivo) Then
                            Dim orden_produccion As String = obj_gestion_materia_primaLn.extraerDatoCodigoBarrasPuntilleria("orden_produccion", consecutivo)
                            Dim consecutivo_rollo As String = obj_gestion_materia_primaLn.extraerDatoCodigoBarrasPuntilleria("id_rollo", consecutivo)
                            Dim sql_codigo As String = "select O.prod_final " &
                                                            "FROM J_orden_prod_punt_enc O, J_orden_prod_punt_producto R " &
                                                                   "WHERE O.consecutivo =" & orden_produccion & "  AND R.consecutivo_rollo =" & consecutivo_rollo & "and R.nro_orden=O.consecutivo"
                            Dim sql_peso As String = "SELECT R.peso FROM J_orden_prod_punt_enc O, J_orden_prod_punt_producto R " &
                                               " WHERE peso IS NOT NULL AND O.consecutivo =" & orden_produccion & " AND R.consecutivo_rollo=" & consecutivo_rollo & "and R.nro_orden=O.consecutivo"
                            Dim peso As Double = objOpsimpesLn.consultValorTodo(sql_peso, "PRODUCCION")
                            peso = peso - 0.1
                            Dim codigo As String = objOpsimpesLn.consultValorTodo(sql_codigo, "PRODUCCION")
                            Dim stock As Double = objOpsimpesLn.consultarStock(codigo, 2)
                            If peso <= stock Then
                                codigo = codigo.ToUpper
                                lblCodigoEmpaque.Text = codigo
                                lblDescEmpaque.Text = objOpsimpesLn.getDescripcionCodigo(codigo)
                                txt_kilos_empaque.Text = peso
                                txt_lector_empaque.ForeColor = Color.Black
                                txt_lector_empaque.Enabled = False
                            Else
                                MessageBox.Show("No hay stock disponible", "No hay stock disponible", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End If
                        Else
                            MessageBox.Show("El producto se encuentra anulado", "Producto anulado", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    End If
                End If
            Else
                MessageBox.Show("El producto se a ingresado como no conforme. ", "verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        ElseIf e.KeyChar = "." Then
            e.KeyChar = "-"
        End If
    End Sub
    Private Sub btn_transaccion_empaque_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_transaccion_empaque.Click
        If (validarEmpaque()) Then
            btn_transaccion_empaque.Enabled = False
            Dim resp As Integer = MessageBox.Show("¿Desea Enviar el contenedor a Empaque?", "Enviar a Epaque", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
            If resp = 6 Then
                Dim consecutivo As String = txt_lector_empaque.Text
                If val_punt.validarCodigoBarrasPuntilleria(consecutivo) Then
                    If val_punt.validarTransaccionEmpaque(consecutivo) Then
                        Dim orden_produccion As String = obj_gestion_materia_primaLn.extraerDatoCodigoBarrasPuntilleria("orden_produccion", consecutivo)
                        Dim id_rollo As String = obj_gestion_materia_primaLn.extraerDatoCodigoBarrasPuntilleria("id_rollo", consecutivo)
                        Application.DoEvents()
                        realizar_transaccion_empaque(orden_produccion, id_rollo)
                        Application.DoEvents()
                    End If
                End If
            Else
                btn_transaccion_empaque.Enabled = True
            End If
        End If
    End Sub
    Private Sub realizar_transaccion_empaque(ByVal orden_produccion As String, ByVal id_rollo As String)
        Using New Centered_MessageBox(Me)
            Dim resp_transaccion As Boolean = False
            Dim tipo As String = cbo_transaccion_empaque.Text
            Dim notas As String = "SPIC " & Now
            Dim peso As Double = Convert.ToDouble(txt_kilos_empaque.Text)
            Dim codigo As String = Trim(lblCodigoEmpaque.Text)
            Dim bodega As String = 2
            Dim dFec As Date = Now
            Dim consecutivo As String = txt_lector_empaque.Text
            Dim listTransaccion_corsan As New List(Of Object)
            Dim sql As String
            Dim dt As New DataTable
            Dim modelo As String = ""

            dt.Columns.Add("codigo")
            dt.Columns.Add("cantidad")
            dt.Rows.Add()
            dt.Rows(dt.Rows.Count - 1).Item("codigo") = codigo
            dt.Rows(dt.Rows.Count - 1).Item("cantidad") = peso
            Dim stock As Double = objOpsimpesLn.consultarStock(codigo, bodega)
            peso = peso - 0.1
            If peso <= stock Then
                If lblCodigoEmpaque.Text Like "2GR*" Then
                    modelo = "06"
                Else
                    modelo = "05"
                End If
                listTransaccion_corsan.AddRange(transaccion(dt, tipo, bodega, modelo, consecutivo))
                sql = "UPDATE J_orden_prod_punt_producto SET sppp=" & numero_transaccion & " WHERE  nro_orden =" & orden_produccion & "  AND consecutivo_rollo =" & id_rollo
                If obj_Ing_prodLn.ExecuteSqlTransaction(listTransaccion_corsan, "CORSAN") Then
                    Dim id As Double = objOpsimpesLn.consultValorTodo("SELECT id FROM J_orden_prod_punt_producto WHERE  nro_orden =" & orden_produccion & "  AND consecutivo_rollo =" & id_rollo, "PRODUCCION")
                    If objOperacionesDb.ejecutar(sql, "PRODUCCION") >= 1 Then
                        Me.Close()
                        MessageBox.Show("El producto a sido enviado para empaque " & vbCrLf & "ID EMPAQUE = " & id & "", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("Error al cabiar la producción de estado, comunicarse con el administrador del sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                Else
                    MessageBox.Show("Error al realizar la transacción, comunicarse con el administrador del sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                Using New Centered_MessageBox(Me)
                    MessageBox.Show("No hay stock disponible", "Sin stock", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End Using
            End If
        End Using
    End Sub
    Private Function transaccion(ByVal datacodigo As DataTable, ByVal tipo As String, ByVal bodega As Integer, ByVal modelo As String, ByVal cont As String) As List(Of Object)
        Dim listSql As New List(Of Object)
        Dim dFec As Date = Now
        Dim usuario As String = "Puntilleria"
        Dim notas As String = "SPIC fecha:" & Now & "(" & cont & ")"
        numero_transaccion = objOrdenProdLn.mover_consecutivo(tipo)
        listSql = objTraslado_bodLn.listaTransaccionDatable(numero_transaccion, datacodigo, bodega, dFec, notas, usuario, tipo, modelo)
        Return listSql
    End Function
    Private Function validarEmpaque() As Boolean
        Using New Centered_MessageBox(Me)
            Dim sql As String = ""
            If (lblCodigoEmpaque.Text <> "") Then
                If (txt_kilos_empaque.Text <> "") Then
                    If (cbo_transaccion_empaque.Text <> "Seleccione") Then
                        If (obj_Ing_prodLn.existeCodigo(lblCodigoEmpaque.Text)) Then
                            If IsNumeric(txt_kilos_empaque.Text) Then
                                If (Convert.ToDouble(txt_kilos_empaque.Text) > 0) Then
                                    If (obj_Ing_prodLn.existeTipoTransaccion(cbo_transaccion_empaque.Text)) Then
                                        If txt_lector_empaque.Text <> "" Then
                                            If val_punt.validarCodigoBarrasPuntilleria(txt_lector_empaque.Text) Then
                                                If val_punt.validar_empaque(txt_lector_empaque.Text, lblCodigoEmpaque.Text) Then
                                                    Return True
                                                End If
                                            Else
                                                MessageBox.Show("El código de barras no se encuentra asignado", "Código de barras no asignado", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                            End If
                                        Else
                                            MessageBox.Show("No se leyo ningun código de barras", "verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                        End If
                                    Else
                                        MessageBox.Show("No existe el tipo de transacción! ", "verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    End If
                                Else
                                    MessageBox.Show("Los kilos no pueden ser negativos ó iguales a (0) ", "verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                End If
                            Else
                                MessageBox.Show("Verifique que el campo 'KILOS' sea un número y no contenga letras! ", "verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End If
                        Else
                            MessageBox.Show("El código ingresado no existe,verifique! ", "verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    Else
                        MessageBox.Show("Falta el TIPO de transacción", "verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Else
                    MessageBox.Show("Faltan los kilos ", "verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                MessageBox.Show("Falta el CÓDIGO ", "verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Using
        Return False
    End Function
End Class