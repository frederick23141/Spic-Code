Imports logicaNegocios

Public Class frm_no_conforme_gest
    Dim objOpsimpesLn As New Op_simpesLn
    Dim obj_gestion_materia_primaLn As New Gestion_materia_primaLn
    Dim obj_Ing_prodLn As New Ing_prodLn
    Dim objOrdenProdLn As New OrdenProdLn
    Dim objTraslado_bodLn As New traslado_bodLn
    Dim bodega As String = ""
    Dim nro_orden As String = ""
    Dim id_detalle As String = ""
    Dim id_rollo As String = ""
    Dim consecutivo As String = ""
    Dim numero_transaccion As Double = 0
    Dim nit_r As Integer
    Dim pesog As Double

    Public Sub main(ByVal nit As Integer)
        nit_r = nit
        tb_no_conforme.SelectedTab = tb_tiqueto
    End Sub
    Private Sub btn_trasladar_Click(sender As Object, e As EventArgs) Handles btn_trasladar.Click
        consecutivo = txt_lector.Text
        Dim dt As New DataTable
        Dim sql As String = ""
        Dim peso As String = lbl_peso.Text
        Dim codigo As String = lblcodigo.Text
        Dim tipo As String = "EIPP"
        Dim bodega_trans As String = "4"
        Dim dFec As Date = Now
        Dim usuario As String = nit_r
        Dim stock As Double
        Dim sql_costo_unit As String = "SELECT costo_unitario " &
                                                   "FROM referencias  " &
                                                          "WHERE codigo='" & codigo & "'"
        Dim costo_unit As Double = objOpsimpesLn.consultValorTodo(sql_costo_unit, "CORSAN")
        Dim modelo As String = "03"
        Dim listSql As New List(Of Object)

        dt.Columns.Add("codigo")
        dt.Columns.Add("cantidad")
        dt.Rows.Add()
        dt.Rows(dt.Rows.Count - 1).Item("codigo") = codigo
        dt.Rows(dt.Rows.Count - 1).Item("cantidad") = pesog

        bodega = validar_bodega()

        If bodega = "2" Then
            stock = objOpsimpesLn.consultarStock(codigo, 2)
            If stock >= pesog Then
                tipo = "TRB1"
                listSql.AddRange(traslado_bodega(codigo, pesog, tipo, costo_unit))
                nro_orden = obj_gestion_materia_primaLn.extraerDatoCodigoBarras("num_consecutivo", consecutivo)
                id_detalle = obj_gestion_materia_primaLn.extraerDatoCodigoBarras("detalle", consecutivo)
                id_rollo = obj_gestion_materia_primaLn.extraerDatoCodigoBarras("id_rollo", consecutivo)
                If obj_Ing_prodLn.ExecuteSqlTransaction(listSql, "CORSAN") Then
                    sql = "update j_rollos_tref set no_conforme='S'  where cod_orden=" & nro_orden & " and id_detalle=" & id_detalle & " and id_rollo=" & id_rollo & " and traslado is null and anulado is null"
                    objOpsimpesLn.ejecutar(sql, "PRODUCCION")
                    nuevo()
                    MessageBox.Show("Rollo trasladado a la 4 ", "Trasladada a la 4!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Else
                Using New Centered_MessageBox(Me)
                    MessageBox.Show("No hay stock para realizar la transacción ", "Sin stock!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End Using
            End If
        ElseIf bodega = "3" Then
            stock = objOpsimpesLn.consultarStock(codigo, 3)
            If stock >= peso Then
                realizar_transaccion_traslado(codigo, peso, tipo, modelo, costo_unit)
                nro_orden = obj_gestion_materia_primaLn.extraerDatoCodigoBarras("num_consecutivo", consecutivo)
                id_detalle = obj_gestion_materia_primaLn.extraerDatoCodigoBarras("detalle", consecutivo)
                id_rollo = obj_gestion_materia_primaLn.extraerDatoCodigoBarras("id_rollo", consecutivo)
                sql = "update no_conforme='S' j_rollos_tref where cod_orden=" & nro_orden & " and id_detalle=" & id_detalle & " and id_rollo=" & id_rollo & " and traslado is null and anulado is null"
                objOpsimpesLn.ejecutar(sql, "PRODUCCION")
            Else
                Using New Centered_MessageBox(Me)
                    MessageBox.Show("No hay stock para realizar la transacción ", "Sin stock!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End Using
            End If

        ElseIf bodega = "11" Then
            stock = objOpsimpesLn.consultarStock(codigo, 11)
            If stock >= peso Then
                realizar_transaccion_traslado(codigo, peso, tipo, modelo, costo_unit)
            Else
                Using New Centered_MessageBox(Me)
                    MessageBox.Show("No hay stock para realizar la transacción ", "Sin stock!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End Using
            End If
        ElseIf bodega = "12" Then
            stock = objOpsimpesLn.consultarStock(codigo, 12)
            If stock >= peso Then
                realizar_transaccion_traslado(codigo, peso, tipo, modelo, costo_unit)
            Else
                Using New Centered_MessageBox(Me)
                    MessageBox.Show("No hay stock para realizar la transacción ", "Sin stock!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End Using
            End If
        End If
    End Sub
    Private Function traslado_bodega(ByVal codigo As String, ByVal cantidad As Double, ByVal tipo As String, ByVal costo_unit As Double) As List(Of Object)
        Dim listSql As New List(Of Object)
        Dim dFec As Date = Now
        Dim usuario As String = nit_r
        Dim notas As String = "SPIC fecha:" & Now & " usuario:" & usuario
        numero_transaccion = objOrdenProdLn.mover_consecutivo(tipo)
        listSql = objTraslado_bodLn.listaTransaccionDatable_traslado_bodega(numero_transaccion, codigo, 2, 4, dFec, notas, usuario, cantidad, tipo, "20", costo_unit)
        Return listSql
    End Function
    Public Function realizar_transaccion_entrada(ByVal codigo As String, ByVal peso As Double, ByVal tipo As String, ByVal modelo As String, ByVal costo_unit As Double, ByVal bodega_t As String) As Boolean
        Dim resp As Boolean = True
        Dim listTransaccion_corsan As New List(Of Object)
        Dim sql_solicitud As String = ""
        listTransaccion_corsan = cargar_Nc(codigo, peso, tipo, modelo, costo_unit)
        If obj_Ing_prodLn.ExecuteSqlTransaction(listTransaccion_corsan, "CORSAN") Then
            Using New Centered_MessageBox(Me)
                MessageBox.Show("Transacción realizada con exito! ", tipo & ": " & Convert.ToString(numero_transaccion), MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Using
        Else
            Using New Centered_MessageBox(Me)
                MessageBox.Show("Error al realizar la transacción! ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Using
            resp = False
        End If
        Return resp
    End Function
    Public Function realizar_transaccion_traslado(ByVal codigo As String, ByVal peso As Double, ByVal tipo As String, ByVal modelo As String, ByVal costo_unit As Double) As Boolean
        Dim resp As Boolean = True
        Dim listTransaccion_corsan As New List(Of Object)
        Dim sql_solicitud As String = ""
        listTransaccion_corsan = traslado_bodega(codigo, peso, tipo, modelo, costo_unit)
        If obj_Ing_prodLn.ExecuteSqlTransaction(listTransaccion_corsan, "CORSAN") Then
            Using New Centered_MessageBox(Me)
                MessageBox.Show("Transacción realizada con exito! ", tipo & ": " & Convert.ToString(numero_transaccion), MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Using
        Else
            Using New Centered_MessageBox(Me)
                MessageBox.Show("Error al realizar la transacción! ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Using
            resp = False
        End If
        Return resp
    End Function
    Private Function cargar_Nc(ByVal codigo As String, ByVal cantidad As Double, ByVal tipo As String, ByVal modelo As String, ByVal costo_unit As Double) As List(Of Object)
        Dim listSql As New List(Of Object)
        Dim dFec As Date = Now
        Dim usuario As String = nit_r
        Dim notas As String = "SPIC fecha:" & Now & " usuario:" & usuario
        Dim bod_Dest As Integer = 4
        numero_transaccion = objOrdenProdLn.mover_consecutivo(tipo)
        listSql = objTraslado_bodLn.transaccion_Scal_Brillante(cantidad, codigo, bod_Dest, dFec, notas, usuario, tipo, costo_unit, numero_transaccion)
        Return listSql
    End Function
    Private Function traslado_bodega(ByVal codigo As String, ByVal cantidad As Double, ByVal tipo As String, ByVal modelo As String, ByVal costo_unit As Double) As List(Of Object)
        Dim listSql As New List(Of Object)
        Dim dFec As Date = Now
        Dim usuario As String = nit_r
        Dim notas As String = "SPIC fecha:" & Now & " usuario:" & usuario
        Dim bod_origen As Integer = 3
        Dim bod_destino As Integer = 4
        numero_transaccion = objOrdenProdLn.mover_consecutivo(tipo)
        listSql = objTraslado_bodLn.listaTransaccionDatable_traslado_bodega(numero_transaccion, codigo, bod_origen, bod_destino, dFec, notas, usuario, cantidad, tipo, modelo, costo_unit)
        Return listSql
    End Function
    Private Function validar_bodega()
        Dim bodega As String = ""
        If rdb_bodega2.Checked Then
            bodega = "2"
        ElseIf rdb_bodega3.Checked Then
            bodega = "3"
        ElseIf rdb_bodega11.Checked Then
            bodega = "11"
        ElseIf rdb_bode12.Checked Then
            bodega = "12"
        ElseIf rdb_bodega13.Checked Then
            bodega = "13"
        ElseIf rdb_bodega14.Checked Then
            bodega = "14"
        End If
        Return bodega
    End Function
    Private Sub nuevo()
        lbl_peso.Text = ""
        lblcodigo.Text = ""
        txt_lector.Text = ""
    End Sub
    Private Sub txt_lector_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_lector.KeyDown
        If e.KeyCode = Keys.Enter Then
            consecutivo = txt_lector.Text
            Dim sql As String = ""
            Dim peso As String
            Dim codigo As String
            Dim no_conforme As String

            bodega = validar_bodega()

            If bodega = "2" Then
                nro_orden = obj_gestion_materia_primaLn.extraerDatoCodigoBarras("num_consecutivo", consecutivo)
                id_detalle = obj_gestion_materia_primaLn.extraerDatoCodigoBarras("detalle", consecutivo)
                id_rollo = obj_gestion_materia_primaLn.extraerDatoCodigoBarras("id_rollo", consecutivo)
                sql = "select peso from j_rollos_tref where cod_orden=" & nro_orden & " and id_detalle=" & id_detalle & " and id_rollo=" & id_rollo & " and traslado is null and anulado is null"
                peso = objOpsimpesLn.consultValorTodo(sql, "PRODUCCION")
                pesog = peso
                sql = "select O.prod_final from J_rollos_tref R, J_orden_prod_tef O where cod_orden =" & nro_orden & "AND id_detalle=" & id_detalle & " AND id_rollo=" & id_rollo & " And R.cod_orden = O.consecutivo"
                codigo = objOpsimpesLn.consultValorTodo(sql, "PRODUCCION")
                sql = "select no_conforme from j_rollos_tref where cod_orden=" & nro_orden & " and id_detalle=" & id_detalle & " and id_rollo=" & id_rollo & " and traslado is null and anulado is null"
                no_conforme = objOpsimpesLn.consultValorTodo(sql, "PRODUCCION")
                If no_conforme = "" Then
                    If peso <> "" Then
                        lbl_peso.Text = "" & peso & " kg"
                        lblcodigo.Text = codigo
                        txt_lector.BackColor = Color.Green
                    Else
                        MessageBox.Show("El consecutivo ingresado no es valido para leer", "No valido para leer")
                        txt_lector.Text = ""
                        txt_lector.BackColor = Color.Red
                    End If
                Else
                    MessageBox.Show("El consecutivo ya es un no conforme", "No valido para leer")
                End If
            ElseIf bodega = "3" Then
                nro_orden = obj_gestion_materia_primaLn.extraerDatoCodigoBarras("num_consecutivo", consecutivo)
                id_detalle = obj_gestion_materia_primaLn.extraerDatoCodigoBarras("detalle", consecutivo)
                id_rollo = obj_gestion_materia_primaLn.extraerDatoCodigoBarras("id_rollo", consecutivo)
                sql = "select peso from j_rollos_tref where cod_orden=" & nro_orden & " and id_detalle=" & id_detalle & " and id_rollo=" & id_rollo & " and traslado is null and anulado is null"
                peso = objOpsimpesLn.consultValorTodo(sql, "PRODUCCION")
                sql = "select O.prod_final from J_rollos_tref R, J_orden_prod_tef O where cod_orden =" & consecutivo & "AND id_detalle=" & id_detalle & " AND id_rollo=" & id_rollo & " And R.cod_orden = O.consecutivo"
                codigo = objOpsimpesLn.consultValorTodo(sql, "PRODUCCION")
                sql = "select no_conforme from j_rollos_tref where cod_orden=" & nro_orden & " and id_detalle=" & id_detalle & " and id_rollo=" & id_rollo & " and traslado is null and anulado is null"
                no_conforme = objOpsimpesLn.consultValorTodo(sql, "PRODUCCION")
                If no_conforme = "" Then
                    If peso <> "" Then
                        lbl_peso.Text = "" & peso & " kg"
                        lblcodigo.Text = codigo
                        txt_lector.BackColor = Color.Green
                    Else
                        MessageBox.Show("El consecutivo ingresado no es valido para leer", "No valido para leer")
                        txt_lector.Text = ""
                        txt_lector.BackColor = Color.Red
                    End If
                Else
                    MessageBox.Show("El consecutivo ya es un no conforme", "No valido para leer")
                End If
            ElseIf bodega = "11" Then
                nro_orden = obj_gestion_materia_primaLn.extraerDatoCodigoBarrasGalvanizado("nro_orden", consecutivo)
                id_rollo = obj_gestion_materia_primaLn.extraerDatoCodigoBarrasGalvanizado("id_rollo", consecutivo)
                sql = "select peso " & "FROM D_rollo_galvanizado_f  " &
                     "WHERE  nro_orden=" & nro_orden & " AND consecutivo_rollo =" & id_rollo & " and no_conforme is null and anular is null "
                peso = objOpsimpesLn.consultValorTodo(sql, "PRODUCCION")
                sql = "select e.final_galv " & "FROM D_rollo_galvanizado_f r , D_orden_pro_galv_enc e " &
                      "WHERE e.consecutivo_orden_G = r.nro_orden AND r.nro_orden=" & nro_orden & " AND r.consecutivo_rollo =" & id_rollo & ""
                codigo = objOpsimpesLn.consultValorTodo(sql, "PRODUCCION")
                If peso <> "" Then
                    lbl_peso.Text = "" & peso & " kg"
                    lblcodigo.Text = codigo
                    txt_lector.BackColor = Color.Green
                Else
                    MessageBox.Show("El consecutivo ingresado no es valido para leer", "No valido para leer")
                    txt_lector.Text = ""
                    txt_lector.BackColor = Color.Red
                End If
            ElseIf bodega = "12" Then
                nro_orden = obj_gestion_materia_primaLn.extraerDatoCodigoBarrasPuntilleria("orden_produccion", consecutivo)
                id_detalle = obj_gestion_materia_primaLn.extraerDatoCodigoBarrasPuntilleria("id_rollo", consecutivo)
                sql = "Select peso FROM J_orden_prod_punt_producto  WHERE  nro_orden =" & nro_orden & " And consecutivo_rollo = " & id_detalle & " and no_conforme is null"
                peso = objOpsimpesLn.consultValorTodo(sql, "PRODUCCION")
                sql = "select e.prod_final from J_orden_prod_punt_enc e join J_orden_prod_punt_producto p on e.consecutivo=p.nro_orden WHERE  p.nro_orden =" & nro_orden & " And p.consecutivo_rollo = " & id_detalle & " and p.no_conforme is null"
                codigo = objOpsimpesLn.consultValorTodo(sql, "PRODUCCION")
                If peso <> "" Then
                    lbl_peso.Text = "" & peso & " kg"
                    lblcodigo.Text = codigo
                    txt_lector.BackColor = Color.Green
                Else
                    MessageBox.Show("El consecutivo ingresado no es valido para leer", "No valido para leer")
                    txt_lector.Text = ""
                    txt_lector.BackColor = Color.Red
                End If
            End If
        End If
    End Sub

    Private Sub frm_no_conforme_gest_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txt_lector.Select()
    End Sub

    Private Sub KryptonButton1_Click(sender As Object, e As EventArgs) Handles btn_trasladar_kilos.Click

    End Sub
End Class