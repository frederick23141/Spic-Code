Imports entidadNegocios
Imports logicaNegocios
Public Class frm_orden_prod_punt_tambores

    Private obj_Ing_prodLn As New Ing_prodLn
    Private objOpSimplesLn As New Op_simpesLn
    Dim obj_gestion_materia_primaLn As New Gestion_materia_primaLn

    Private val_punt As New obj_val_punt

    Private Sub frm_orden_prod_punt_tambores_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dt As New DataTable
        Dim row As DataRow
        Dim Sql As String = "SELECT nit,nombres FROM V_nom_personal_Activo_con_maquila WHERE centro = 2400  order by nombres"
        dt = obj_Ing_prodLn.listar_datatable(Sql, "CORSAN")
        row = dt.NewRow
        row("nit") = 0
        row("nombres") = "Seleccione"
        dt.Rows.Add(row)
        cbo_operario_tambor.DataSource = dt
        cbo_operario_tambor.ValueMember = "nit"
        cbo_operario_tambor.DisplayMember = "nombres"
        cbo_operario_tambor.SelectedValue = 0
        cbo_tambor.SelectedValue = 0

        txt_lector_tambor.BackColor = Color.Red
        txt_lector_tambor.Text = ""
        txt_kilos_tambor.Text = ""
        cbo_tambor.Text = "Seleccione"
        lbl_codigo_tambor.Text = ""
        lbl_desc_tambor.Text = ""
    End Sub

    Private Sub txt_lector_tambor_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_lector_tambor.Leave
        txt_lector_tambor.BackColor = Color.Red
    End Sub

    Private Sub txt_lector_tambor_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_lector_tambor.Enter
        txt_lector_tambor.BackColor = Color.Green
        txt_lector_tambor.Text = ""
    End Sub

    Private Sub txt_lector_tambor_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_lector_tambor.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            txt_lector_tambor.Text = Replace(txt_lector_tambor.Text, "'", "-")
            If val_punt.validar_no_conforme(txt_lector_tambor.Text) Then
                Dim consecutivo As String = txt_lector_tambor.Text
                If val_punt.validarCodigoBarrasPuntilleria(consecutivo) Then
                    Dim numero_orden As String = obj_gestion_materia_primaLn.extraerDatoCodigoBarrasPuntilleria("orden_produccion", consecutivo)
                    Dim id_detalle As String = obj_gestion_materia_primaLn.extraerDatoCodigoBarrasPuntilleria("id_rollo", consecutivo)
                    Dim sql_peso As String = "SELECT peso " & _
                                                    "FROM J_orden_prod_punt_producto " & _
                                                            "WHERE nro_orden =" & numero_orden & " AND consecutivo_rollo = " & id_detalle
                    Dim sql_codigo As String = "SELECT prod_final " & _
                                       "FROM J_orden_prod_punt_enc " & _
                                               "WHERE consecutivo =" & numero_orden
                    Dim peso As String = objOpSimplesLn.consultValorTodo(sql_peso, "PRODUCCION")
                    Dim codigo As String = objOpSimplesLn.consultValorTodo(sql_codigo, "PRODUCCION")
                    lbl_codigo_tambor.Text = codigo
                    txt_kilos_tambor.Text = peso
                    lbl_desc_tambor.Text = objOpSimplesLn.getDescripcionCodigo(codigo)
                Else
                    nuevo_tambores()
                End If
            Else
                MessageBox.Show("El producto se a ingresado como no conforme. ", "verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        ElseIf e.KeyChar = "." Then
            e.KeyChar = "-"
        End If
    End Sub
    Private Sub nuevo_tambores()
        cbo_operario_tambor.SelectedValue = 0
        cbo_tambor.SelectedValue = 0
        cbo_tambor.SelectedValue = 0
        txt_lector_tambor.Text = ""
        lbl_codigo_tambor.Text = ""
        lbl_desc_tambor.Text = ""
        txt_kilos_tambor.Text = ""
    End Sub
    Private Sub btn__reg_tambor_Click(sender As Object, e As EventArgs) Handles btn__reg_tambor.Click
        If validarTambores() Then
            ingresar_tambores()
        End If
    End Sub
    Private Function validarTambores() As Boolean
        Using New Centered_MessageBox(Me)
            If (lbl_codigo_tambor.Text <> "") Then
                If (txt_kilos_tambor.Text <> "") Then
                    If (obj_Ing_prodLn.existeCodigo(lbl_codigo_tambor.Text)) Then
                        If IsNumeric(txt_kilos_tambor.Text) Then
                            If (Convert.ToDouble(txt_kilos_tambor.Text) > 0) Then
                                If txt_lector_tambor.Text <> "" Then
                                    If cbo_operario_tambor.SelectedValue <> 0 Then
                                        If val_punt.validarCodigoBarrasPuntilleria(txt_lector_tambor.Text) Then
                                            If Not val_punt.validarProductoTamboreado(txt_lector_tambor.Text) Then
                                                If val_punt.validarProductoAnulado(txt_lector_tambor.Text) Then
                                                    If val_punt.validar_clas_tambores(txt_lector_tambor.Text, lbl_codigo_tambor.Text) Then
                                                        Return True
                                                    End If
                                                Else
                                                    MessageBox.Show("El producto a sido anulado", "Producto anulado", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                                End If
                                            Else
                                                MessageBox.Show("El producto ya se encuentra tamboreado", "Producto ya tamboreado", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                            End If
                                        Else
                                            MessageBox.Show("El código de barras no se encuentra asignado", "Código de barras no asignado", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                        End If
                                    Else
                                        MessageBox.Show("Seleccione operario de tambores", "Seleccione operario", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                    End If
                                Else
                                    MessageBox.Show("No se leyo ningun código de barras", "verifique", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                End If
                            Else
                                MessageBox.Show("Los kilos no pueden ser negativos ó iguales a (0) ", "verifique", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            End If

                        Else
                            MessageBox.Show("Verifique que el campo 'KILOS' sea un número y no contenga letras! ", "verifique", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If
                    Else
                        MessageBox.Show("El código ingresado no existe,verifique! ", "verifique", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                Else
                    MessageBox.Show("Faltan los kilos ", "verifique", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                MessageBox.Show("Falta el CÓDIGO ", "verifique", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End Using
        Return False
    End Function
    Private Sub ingresar_tambores()
        Dim operario As Double = cbo_operario_tambor.SelectedValue
        Dim num_orden As String = obj_gestion_materia_primaLn.extraerDatoCodigoBarrasPuntilleria("orden_produccion", txt_lector_tambor.Text)
        Dim id_produccion As String = obj_gestion_materia_primaLn.extraerDatoCodigoBarrasPuntilleria("id_rollo", txt_lector_tambor.Text)
        Dim sql As String = "INSERT into J_orden_prod_punt_tambores (nit,fecha,nro_orden,producto) values (" & operario & ",GETDATE()," & num_orden & "," & id_produccion & ")"
        Dim sql_tambor As String = "UPDATE J_orden_prod_punt_producto SET tamboreado = 'S' WHERE nro_orden =" & num_orden & " AND consecutivo_rollo = " & id_produccion
        Dim listSql As New List(Of Object)
        listSql.Add(sql)
        listSql.Add(sql_tambor)
        If objOpSimplesLn.ExecuteSqlTransactionTodo(listSql, "PRODUCCION") Then
            MessageBox.Show("Producto ingresado como tamboreado en forma correcto", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information)
            nuevo_tambores()
            Me.Close()
        Else
            MessageBox.Show("Error al ingresar el producto como tamboredo, comuniquese con el administrador del sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
End Class