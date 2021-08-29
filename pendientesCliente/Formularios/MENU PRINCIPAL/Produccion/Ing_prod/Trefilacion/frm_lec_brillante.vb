Imports logicaNegocios
Imports entidadNegocios
Public Class Frm_lec_brillante
    Dim bod_origen As Integer = 2
    Dim modelo As String = ""
    Dim nit_usuario As String
    Dim codigo_aut As String = ""
    Dim num_solicitud As Double = 0
    Dim num_sol_detalle As Double = 0
    Dim cargaComp As Boolean = False
    Dim dtTransacciones As New DataTable
    Dim objTraslado_bodLn As New traslado_bodLn
    Dim obj_gestion_materia_primaLn As New Gestion_materia_primaLn
    Dim obj_gestion_alambronLn As New Gestion_alambronLn
    Private objEnvCorreoLN As New EnvCorreoLN
    Private objOrdenProdLn As New OrdenProdLn
    Private obj_Ing_prodLn As New Ing_prodLn
    Private objOpSimplesLn As New Op_simpesLn
    Private numero_transaccion As Double
    Dim cod_principal As Integer
    Dim cod_detalle As Integer
    Dim db_produccion As String = ""
    Private Sub Frm_lector_brillante_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.txt_lector.Focus()
        Me.txt_lector.BackColor = Color.Green
    End Sub
    Public Sub main(ByVal cod_orden_tref As String, ByVal id_detalle_tref As String, ByVal nit As String, ByVal id As String)
        cod_principal = cod_orden_tref
        cod_detalle = id_detalle_tref
        nit_usuario = nit
        If id = "S" Then
            btn_cerrar.Visible = False
        End If
    End Sub
    Private Sub btn_leer_Click(sender As Object, e As EventArgs) Handles btn_leer.Click
        If validar_barras_DEV() Then
            Dim cod_orden As String = obj_gestion_materia_primaLn.extraerDatoCodigoBarras("num_consecutivo", txt_lector.Text)
            Dim id_detalle As String = obj_gestion_materia_primaLn.extraerDatoCodigoBarras("detalle", txt_lector.Text)
            Dim id_rollo As String = obj_gestion_materia_primaLn.extraerDatoCodigoBarras("id_rollo", txt_lector.Text)
            Dim resp_transaccion As Boolean = False
            Dim sql As String
            sql = "select materia_prima from J_orden_prod_tef where consecutivo=" & cod_principal & ""
            Dim mat_prima As String = Trim(objOpSimplesLn.consultValorTodo(sql, "PRODUCCION"))
            Dim tipo As String = "SCAL"
            Dim notas As String = "SPIC traslado(HandHeld) " & Now & " usuario: " & nit_usuario
            sql = "select peso from j_rollos_tref where cod_orden=" & cod_orden & "and id_detalle =" & id_detalle & "and id_rollo=" & id_rollo & ""
            Dim peso_sql = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")
            Dim peso As Double = Convert.ToDouble(peso_sql)
            sql = "select prod_final from J_orden_prod_tef where consecutivo=" & cod_orden & ""
            Dim codigo_sql As String = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")
            Dim codigo As String = Trim(codigo_sql)
            Dim bodega As String = 2
            Dim dFec As Date = Now
            sql = "select nro_consu from j_rollos_tref where cod_orden=" & cod_orden & "and id_detalle =" & id_detalle & "and id_rollo=" & id_rollo & ""
            Dim consumo As String = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")
            Dim usuario As String = nit_usuario
            Dim stock As Double = objOpSimplesLn.consultarStock(codigo, bodega)
            Dim listSql As New List(Of Object)
            Dim sql_solicitud As String = ""
            Dim costo_unit As Double
            Dim dt As New DataTable
            dt.Columns.Add("codigo")
            dt.Columns.Add("cantidad")
            dt.Rows.Add()
            dt.Rows(dt.Rows.Count - 1).Item("codigo") = codigo
            dt.Rows(dt.Rows.Count - 1).Item("cantidad") = peso
            For i = 0 To dt.Rows.Count - 1
                costo_unit = objOrdenProdLn.consultCostoUnit(dt.Rows(i).Item("codigo"))
            Next
            If mat_prima.ToUpper = codigo.ToUpper Then
                If consumo = "" Then
                    If peso < stock Then
                        listSql.AddRange(trans_consu_brilla(codigo, peso, tipo, costo_unit))

                        sql = "UPDATE j_rollos_tref SET scal = " & numero_transaccion & ", nro_consu=1 where cod_orden=" & cod_orden & "and id_detalle =" & id_detalle & "and id_rollo=" & id_rollo & ""
                        objOpSimplesLn.ejecutar(sql, "PRODUCCION")

                        sql = "INSERT INTO JB_orden_prod_tref_mp_bri" &
                                               "(cod_orden,id_detalle,cod_bri,id_bri,rollo_bri) " &
                                                       "VALUES (" & cod_principal & "," & cod_detalle & "," & cod_orden & "," & id_detalle & "," & id_rollo & ") "
                        objOpSimplesLn.ejecutar(sql, "PRODUCCION")

                        If obj_Ing_prodLn.ExecuteSqlTransaction(listSql, "CORSAN") Then
                            MessageBox.Show("Transacción realizada con exito! ", tipo & ": " & Convert.ToString(numero_transaccion), MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Me.Close()
                        Else
                            MessageBox.Show("Problemas al realizar la transacción", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    Else
                        MessageBox.Show("El pedido es mas grande que el stock! ", tipo & ": " & Convert.ToString(numero_transaccion), MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                ElseIf consumo = "1" Then
                    sql = "UPDATE j_rollos_tref  SET nro_consu='2' where cod_orden=" & cod_orden & "and id_detalle =" & id_detalle & "and id_rollo=" & id_rollo & ""
                    objOpSimplesLn.ejecutar(sql, "PRODUCCION")
                Else
                    MessageBox.Show("EL rollo ya se ha consumido dos veces", "Consumir otro rollo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                MessageBox.Show("Se esta leyendo un rollo diferente al de la materia prima! ", tipo & ": " & Convert.ToString(numero_transaccion), MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub
    Private Function trans_consu_brilla(ByVal codigo As String, ByVal cantidad As Double, ByVal tipo As String, ByVal costo_unit As Double)
        Dim listSql As New List(Of Object)
        Dim dFec As Date = Now
        Dim usuario As String = nit_usuario
        Dim notas As String = "SPIC fecha:" & Now & " usuario:" & usuario
        numero_transaccion = objOrdenProdLn.mover_consecutivo(tipo)
        listSql = objTraslado_bodLn.transaccion_Scal_Brillante(cantidad, codigo, bod_origen, dFec, notas, usuario, tipo, costo_unit, numero_transaccion)
        Return listSql
    End Function
    Private Function validar_barras_DEV()
        Dim resp As Boolean = False
        If txt_lector.Text <> "" Then
            Dim cod_orden As String = obj_gestion_materia_primaLn.extraerDatoCodigoBarras("num_consecutivo", txt_lector.Text)
            Dim id_detalle As String = obj_gestion_materia_primaLn.extraerDatoCodigoBarras("detalle", txt_lector.Text)
            Dim id_rollo As String = obj_gestion_materia_primaLn.extraerDatoCodigoBarras("id_rollo", txt_lector.Text)
            lbl_error_lector.Text = ""
            If cod_orden <> "" And id_detalle <> "" And id_rollo <> "" Then
                Dim sql As String = "SELECT consecutivo FROM J_rollos_tref WHERE cod_orden = " & cod_orden & " AND id_detalle = " & id_detalle & " AND id_rollo = " & id_rollo
                Dim val As String = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")
              
                If val <> "" Then
                    sql = "SELECT transaccion_entrada FROM J_det_orden_prod WHERE cod_orden = " & cod_orden & "AND id_detalle = " & id_detalle & ""
                    val = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")
                    If val <> "" Then
                        sql = "SELECT anulado FROM J_rollos_tref WHERE cod_orden = " & cod_orden & " AND id_detalle = " & id_detalle & " AND id_rollo = " & id_rollo
                        val = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")
                        If val = "" Then
                            sql = "SELECT destino FROM J_rollos_tref WHERE cod_orden = " & cod_orden & " AND id_detalle = " & id_detalle & " AND id_rollo = " & id_rollo
                            val = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")
                            If val = "" Then
                                sql = "SELECT cod_orden FROM JB_orden_prod_tref_mp_bri WHERE cod_orden = " & cod_principal & " AND id_detalle = " & cod_detalle & " AND cod_bri = " & cod_orden & "and id_bri=" & id_detalle & "and rollo_bri=" & id_rollo & ""
                                val = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")
                                If val = "" Then
                                    sql = "SELECT scal FROM J_rollos_tref WHERE cod_orden = " & cod_orden & " AND id_detalle = " & id_detalle & " AND id_rollo = " & id_rollo
                                    val = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")
                                    If val = "" Then
                                        resp = True
                                    Else
                                        lbl_error_lector.Text = "El Rollo ya esta consumido"
                                        limpiar_txt()
                                    End If
                                Else
                                    lbl_error_lector.Text = "El Rollo ya esta en la planilla"
                                    limpiar_txt()
                                End If
                            Else
                                lbl_error_lector.Text = "El Rollo No pertenece a bodega 2"
                            End If
                        Else
                            lbl_error_lector.Text = "El Rollo Esta Anulado"
                            limpiar_txt()
                        End If
                    Else
                        lbl_error_lector.Text = "El tiquete que se intenta consumir aun no se ha cargado al inventario."
                        limpiar_txt()
                    End If
                Else
                    lbl_error_lector.Text = "El tiquete que se intenta consumir no existe."
                    limpiar_txt()
                End If
            Else
                lbl_error_lector.Text = "Tiquete no ingresado correctamente."
                limpiar_txt()
               
            End If
        Else
            lbl_error_lector.Text = "Esta vacio el campo, VUELVA A INTENTARLO."
            limpiar_txt()
        End If
        Return resp
    End Function
    Private Sub txt_lector_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_lector.KeyDown
        If e.KeyCode = Keys.Enter Then
            btn_leer.PerformClick()
        End If
    End Sub
    Private Sub limpiar_txt()
        txt_lector.Text = ""
    End Sub

    Private Sub btn_cerrar_Click(sender As Object, e As EventArgs) Handles btn_cerrar.Click
        Me.Close()
    End Sub
End Class
