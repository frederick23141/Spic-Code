Imports accesoDatos
Imports logicaNegocios
Public Class Frm_orden_prod_punt_galva
    Private objOpsimpesLn As New Op_simpesLn
    Private obj_gestion_materia_primaLn As New Gestion_materia_primaLn
    Private val_punt As New obj_val_punt
    Dim objTraslado_bodLn As New traslado_bodLn
    Private numero_transaccion As Double
    Private obj_Ing_prodLn As New Ing_prodLn
    Private objOrdenProdLn As New OrdenProdLn
    Private objOperacionesDb As New OperacionesDb
    Dim nit As String
    Private Sub main(ByVal nit_usuario As String)
        nit = nit_usuario
    End Sub
    Private Sub txt_lector_galv_Leave(sender As Object, e As EventArgs) Handles txt_lector_galv.Leave
        txt_lector_galv.BackColor = Color.Red
    End Sub

    Private Sub txt_lector_galv_Enter(sender As Object, e As EventArgs) Handles txt_lector_galv.Enter
        txt_lector_galv.BackColor = Color.Green
    End Sub
    Private Sub txt_lector_galv_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_lector_galv.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            txt_lector_galv.Text = Replace(txt_lector_galv.Text, "'", "-")
            If val_punt.validar_no_conforme(txt_lector_galv.Text) Then
                Dim consecutivo As String = txt_lector_galv.Text
                If val_punt.validarCodigoBarrasPuntilleria(consecutivo) Then
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
                        If Not codigo.ToUpper Like "2CA*" Then
                            If peso <= stock Then
                                lbl_cod_text.Text = codigo
                                txt_kilos_galv.Text = peso
                                txt_lector_galv.ForeColor = Color.Black
                                txt_lector_galv.Enabled = False

                            Else
                                MessageBox.Show("No hay stock disponible", "No hay stock disponible", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End If
                        Else
                            lbl_cod_text.Text = codigo
                            txt_kilos_galv.Text = peso
                            txt_lector_galv.ForeColor = Color.Black
                            txt_lector_galv.Enabled = False
                            If codigo.ToUpper Like "2CA*" Then
                                Dim respTemrinar As String
                                respTemrinar = MessageBox.Show("Desea cambiar el peso del contenedor? ", "Terminar planilla?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                                If (respTemrinar = "6") Then
                                    Dim n_peso As String = InputBox("Ingrese el nuevo peso deseado")
                                    txt_kilos_galv.Text = n_peso
                                End If
                            End If
                        End If
                    Else
                            MessageBox.Show("El producto se encuentra anulado", "Producto anulado", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If
            Else
                MessageBox.Show("El producto se a ingresado como no conforme. ", "verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub
    Private Sub realizar_transaccion_galv(ByVal nro_orden As String, ByVal num_rollo As String)
        Using New Centered_MessageBox(Me)
            Dim resp_transaccion As Boolean = False
            Dim tipo As String = ""
            Dim notas As String = "SPIC " & Now
            Dim peso As Double = Convert.ToDouble(txt_kilos_galv.Text)
            Dim codigo As String = Trim(lbl_cod_text.Text)
            Dim bodega As String = 2
            Dim dFec As Date = Now
            Dim consecutivo As String = nro_orden
            Dim listTransaccion_corsan As New List(Of Object)
            Dim sql As String
            Dim dt As New DataTable
            Dim modelo As String = ""
            Dim costo_unit As Double

            dt.Columns.Add("codigo")
            dt.Columns.Add("cantidad")
            dt.Rows.Add()
            dt.Rows(dt.Rows.Count - 1).Item("codigo") = codigo
            dt.Rows(dt.Rows.Count - 1).Item("cantidad") = peso

            For i = 0 To dt.Rows.Count - 1
                costo_unit = objOrdenProdLn.consultCostoUnit(dt.Rows(i).Item("codigo"))
            Next
            Dim stock As Double = objOpsimpesLn.consultarStock(codigo, bodega)
            peso = peso - 0.1
            'If peso <= stock Then
            If codigo Like "2GR*" Or codigo Like "2T*" Or codigo Like "2ccn558ns*" Or codigo Like "2ccp558ns*" Or codigo Like "2cco558ns*" Then
                modelo = "29"
                tipo = "TRB1"
                listTransaccion_corsan.AddRange(traslado_bodega(codigo, peso, tipo, costo_unit, nit))
                sql = "UPDATE J_orden_prod_punt_producto SET trb28=" & numero_transaccion & " WHERE  nro_orden =" & nro_orden & "  AND consecutivo_rollo =" & num_rollo
            Else
                modelo = "01"
                    tipo = "EIPP"
                listTransaccion_corsan.AddRange(transaccion(dt, tipo, 8, "03", consecutivo))
                sql = "UPDATE J_orden_prod_punt_producto SET eipp=" & numero_transaccion & " WHERE  nro_orden =" & nro_orden & "  AND consecutivo_rollo =" & num_rollo
                End If
                If obj_Ing_prodLn.ExecuteSqlTransaction(listTransaccion_corsan, "CORSAN") Then
                    Dim id As Double = objOpsimpesLn.consultValorTodo("SELECT id FROM J_orden_prod_punt_producto WHERE  nro_orden =" & nro_orden & "  AND consecutivo_rollo =" & num_rollo, "PRODUCCION")
                    If objOperacionesDb.ejecutar(sql, "PRODUCCION") >= 1 Then
                        Me.Close()
                        MessageBox.Show("El producto a sido enviado a bodega 8 " & vbCrLf & "", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("Error al cabiar la producción de estado, comunicarse con el administrador del sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                Else
                    MessageBox.Show("Error al realizar la transacción, comunicarse con el administrador del sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            'Else
            '    Using New Centered_MessageBox(Me)
            '        MessageBox.Show("No hay stock disponible", "Sin stock", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '    End Using
            'End If
        End Using
    End Sub
    Private Function traslado_bodega(ByVal codigo As String, ByVal cantidad As Double, ByVal tipo As String, ByVal costo_unit As Double, ByVal nit_usuario As String) As List(Of Object)
        Dim listSql As New List(Of Object)
        Dim dFec As Date = Now
        Dim usuario As String = nit_usuario
        Dim notas As String = "SPIC fecha:" & Now & " usuario:" & usuario
        Dim bod_origen As Integer = 2
        Dim bod_destino As Integer = 8
        numero_transaccion = objOrdenProdLn.mover_consecutivo(tipo)
        listSql = objTraslado_bodLn.listaTransaccionDatable_traslado_bodega(numero_transaccion, codigo, bod_origen, bod_destino, dFec, notas, usuario, cantidad, tipo, "29", costo_unit)
        Return listSql
    End Function
    Private Function transaccion(ByVal datacodigo As DataTable, ByVal tipo As String, ByVal bodega As Integer, ByVal modelo As String, ByVal nit_usuario As String) As List(Of Object)
        Dim listSql As New List(Of Object)
        Dim dFec As Date = Now
        Dim usuario As String = nit_usuario
        Dim notas As String = "SPIC fecha:" & Now & " usuario:" & usuario
        numero_transaccion = objOrdenProdLn.mover_consecutivo(tipo)
        listSql = objTraslado_bodLn.listaTransaccionDatable(numero_transaccion, datacodigo, bodega, dFec, notas, usuario, tipo, modelo)
        Return listSql
    End Function

    Private Sub Btn_galv_Click(sender As Object, e As EventArgs) Handles btn_galv.Click
        If val_punt.validar_codigos_bodega_8(lbl_cod_text.Text) Then
            Dim resp As Integer = MessageBox.Show("¿Desea Enviar el contenedor a bodega 8?", "Enviar a bodega 8", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
            Dim sql As String
            Dim val As String
            If resp = 6 Then
                Dim consecutivo As String = txt_lector_galv.Text
                Dim orden_produccion As String = obj_gestion_materia_primaLn.extraerDatoCodigoBarrasPuntilleria("orden_produccion", consecutivo)
                Dim id_rollo As String = obj_gestion_materia_primaLn.extraerDatoCodigoBarrasPuntilleria("id_rollo", consecutivo)
                If lbl_cod_text.Text.ToUpper Like "2CA*" Then
                    sql = "UPDATE J_orden_prod_punt_producto SET peso=" & txt_kilos_galv.Text & " where nro_orden=" & orden_produccion & " AND consecutivo_rollo =" & id_rollo & ""
                    objOpsimpesLn.ejecutar(sql, "PRODUCCION")
                End If
                sql = "select nro_orden from J_orden_prod_punt_producto WHERE  nro_orden =" & orden_produccion & "  AND consecutivo_rollo =" & id_rollo & " AND trb28 is null and eipp is null and tamboreado is not null"
                    val = objOpsimpesLn.consultValorTodo(sql, "PRODUCCION")
                    If val <> "" Then
                        realizar_transaccion_galv(orden_produccion, id_rollo)
                    Else
                        MessageBox.Show("Este rollo ya ha sido trasladado a bodega 8 o no ha sido tamboreado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                Else
                    Me.Close()
            End If
        Else
            MessageBox.Show("El Codigo ingresado no puede moverse hacia la bodega 8. ", "Codigo no valido", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
End Class