Imports entidadNegocios
Imports logicaNegocios
Public Class frm_reg_mp_puas
    Dim cod_matp As String = ""
    Dim nro_orden_puas As Integer
    Dim frm_C As New frm_control_orden_puas
    Dim cod_mp2 As String = ""
    Dim nit_oper As Integer
    Dim obj_gestion_materia_primaLn As New Gestion_materia_primaLn
    Private objOpSimplesLn As New Op_simpesLn
    Dim objTraslado_bodLn As New traslado_bodLn
    Dim numero_transaccion As Double
    Private objOrdenProdLn As New OrdenProdLn
    Private obj_Ing_prodLn As New Ing_prodLn

    Public Sub main(ByVal cod_mp As String, ByVal cod_mp2 As String, ByVal nro_orden As Integer, ByVal nit As Integer, ByVal frm As frm_control_orden_puas)
        Me.Text = "MATERIA PRIMA: " & cod_mp.ToUpper & "- MATERIA PRIMA 2:" & cod_mp2.ToUpper & ""
        cod_matp = cod_mp
        frm_C = frm
        nit_oper = nit
        nro_orden_puas = nro_orden
        limpiar_frm()
    End Sub
    Private Sub limpiar_frm()
        txt_lector.Focus()
        txt_lector.Text = ""
        lbl_codigo.Text = ""
        lbl_nom.Text = ""
        lbl_peso.Text = ""
    End Sub
    Private Sub txt_lector_Enter(sender As Object, e As EventArgs) Handles txt_lector.Enter
        txt_lector.BackColor = Color.Green
    End Sub

    Private Sub txt_lector_Leave(sender As Object, e As EventArgs) Handles txt_lector.Leave
        txt_lector.BackColor = Color.Red
    End Sub
    Private Function validar_rollo()
        Using New Centered_MessageBox(Me)
            Dim resp As Boolean = False
            Dim cod_orden As String = obj_gestion_materia_primaLn.extraerDatoCodigoBarrasGalvanizado("num_consecutivo", txt_lector.Text)
            Dim id_rollo As String = obj_gestion_materia_primaLn.extraerDatoCodigoBarrasGalvanizado("id_rollo", txt_lector.Text)
            If cod_orden <> "" And id_rollo <> "" Then
                Dim sql As String = "select anular from D_rollo_galvanizado_f where nro_orden = " & cod_orden & " and consecutivo_rollo = " & id_rollo
                Dim val As String = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")
                If val = "" Then
                    sql = "select destino from D_rollo_galvanizado_f where nro_orden = " & cod_orden & " and consecutivo_rollo = " & id_rollo
                    val = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")
                    If val = "A" Then
                        sql = "select saga from D_rollo_galvanizado_f where nro_orden = " & cod_orden & " and consecutivo_rollo = " & id_rollo
                        val = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")
                        If val = "" Then
                            sql = "select spu from D_rollo_galvanizado_f where nro_orden = " & cod_orden & " and consecutivo_rollo = " & id_rollo
                            val = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")
                            If val = "" Then
                                sql = "select final_galv from D_orden_pro_galv_enc where consecutivo_orden_G = " & cod_orden
                                val = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")
                                If val.ToUpper = cod_matp.ToUpper Then
                                    Dim stock As Double = objOpSimplesLn.consultarStock(val, "14")
                                    sql = "select peso from D_rollo_galvanizado_f where nro_orden = " & cod_orden & " and consecutivo_rollo = " & id_rollo
                                    val = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")
                                    If stock >= CDbl(val) Then
                                        resp = True
                                        sql = "SELECT r.peso,o.final_galv,rr.descripcion " &
                                                " FROM D_rollo_galvanizado_f r, D_orden_pro_galv_enc o, CORSAN.dbo.referencias rr  " &
                                                " WHERE r.nro_orden = o.consecutivo_orden_G and o.final_galv = rr.codigo " &
                                                " and r.nro_orden = " & cod_orden & " and r.consecutivo_rollo = " & id_rollo
                                        Dim dt As DataTable = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")
                                        For i = 0 To dt.Rows.Count - 1
                                            lbl_codigo.Text = dt.Rows(i).Item("final_galv")
                                            lbl_nom.Text = dt.Rows(i).Item("descripcion")
                                            lbl_peso.Text = dt.Rows(i).Item("peso")
                                        Next
                                    Else
                                        MessageBox.Show("No hay stock para asignar esta materia prima.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                    End If
                                Else
                                    MessageBox.Show("El código del rollo no es igual al de la materia prima.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                End If
                            Else
                                MessageBox.Show("El rollo ya se a consumido en puas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            End If
                        Else
                            MessageBox.Show("El rollo ya se a consumido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If
                    Else
                        MessageBox.Show("El rollo no pertenece a puas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                Else
                    MessageBox.Show("El rollo esta anulado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                MessageBox.Show("Error al leer el codigo de Barras", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
            Return resp
        End Using
    End Function

    Private Sub txt_lector_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_lector.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            txt_lector.Text = Replace(txt_lector.Text, "'", "-")
            If validar_rollo() Then
                btn_registrar.Enabled = True
            End If
        End If
    End Sub
    Private Sub btn_registrar_Click(sender As Object, e As EventArgs) Handles btn_registrar.Click
        Dim cod_orden As String = obj_gestion_materia_primaLn.extraerDatoCodigoBarrasGalvanizado("num_consecutivo", txt_lector.Text)
        Dim id_rollo As String = obj_gestion_materia_primaLn.extraerDatoCodigoBarrasGalvanizado("id_rollo", txt_lector.Text)
        guardar_tras(cod_orden, id_rollo)
    End Sub
    Private Sub guardar_tras(ByVal cod_orden As Integer, ByVal id_rollo As Integer)
        Dim listSql As New List(Of Object)
        Dim stock As Double = 0
        Dim sql As String
        Dim mp As String
        Dim peso As String
        Dim val_control_real As String
        Dim val_control_lleva As String
        Dim peso_nuevo As Double
        sql = "SELECT peso from D_rollo_galvanizado_f where nro_orden=" & cod_orden & " AND consecutivo_rollo=" & id_rollo & ""
        peso = obj_Ing_prodLn.consultar_valor(sql, "PRODUCCION")
        sql = "SELECT nro_orden_puas FROM D_orden_prod_puas_mp WHERE nro_orden_galv=" & cod_orden & " AND nro_rollo_galv=" & id_rollo & " AND nro_orden_puas=" & nro_orden_puas & ""
        mp = obj_Ing_prodLn.consultar_valor(sql, "PRODUCCION")
        If mp = "0" Then
            Dim fecha_actual As String = "" & System.DateTime.Now.Day & "-" & System.DateTime.Now.Month & "-" & System.DateTime.Now.Year & " " & System.DateTime.Now.Hour & ":" & System.DateTime.Now.Minute & ":" & System.DateTime.Now.Second & ""
            sql = "INSERT INTO D_orden_prod_puas_mp (nro_orden_galv,nro_rollo_galv,nro_orden_puas,peso,nit_oper,fecha) VALUES(" & cod_orden & "," & id_rollo & "," & nro_orden_puas & "," & peso & "," & nit_oper & ",getdate())"
            objOpSimplesLn.ejecutar(sql, "PRODUCCION")
            sql = "update D_rollo_galvanizado_f set spu = " & nro_orden_puas & " where nro_orden = " & cod_orden & " and consecutivo_rollo = " & id_rollo
            objOpSimplesLn.ejecutar(sql, "PRODUCCION")
            sql = "SELECT peso_real FROM D_orden_prod_puas_cont_mp_prod WHERE orden_puas=" & nro_orden_puas & ""
            val_control_real = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")
            sql = "SELECT peso_lleva FROM D_orden_prod_puas_cont_mp_prod WHERE orden_puas=" & nro_orden_puas & ""
            val_control_lleva = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")
            If val_control_real <> "" Then
                peso_nuevo = CDbl(val_control_real) + CDbl(peso)
                sql = "UPDATE D_orden_prod_puas_cont_mp_prod SET peso_real=" & peso_nuevo & " where orden_puas=" & nro_orden_puas & ""
                objOpSimplesLn.ejecutar(sql, "PRODUCCION")
                peso_nuevo = CDbl(val_control_lleva) + CDbl(peso)
                sql = "UPDATE D_orden_prod_puas_cont_mp_prod SET peso_lleva=" & peso_nuevo & " where orden_puas=" & nro_orden_puas & ""
                objOpSimplesLn.ejecutar(sql, "PRODUCCION")
            Else
                sql = "INSERT INTO D_orden_prod_puas_cont_mp_prod (orden_puas,peso_real,peso_lleva) values (" & nro_orden_puas & "," & peso & "," & peso & ")"
                objOpSimplesLn.ejecutar(sql, "PRODUCCION")
            End If
            MessageBox.Show("Rollo de materia prima ha sido asignado a la orden:" & nro_orden_puas & "", "Materia prima asignada", MessageBoxButtons.OK, MessageBoxIcon.Information)
            sql = "SELECT peso_real FROM D_orden_prod_puas_cont_mp_prod WHERE orden_puas=" & nro_orden_puas & ""
            val_control_real = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")
            sql = "SELECT peso_lleva FROM D_orden_prod_puas_cont_mp_prod WHERE orden_puas=" & nro_orden_puas & ""
            val_control_lleva = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")
            limpiar_frm()
            frm_C.cargar_dtg_mp()
            Me.Close()
        Else
            MessageBox.Show("Rollo de materia prima ya ha sido asignado a la orden:" & mp & "", "Materia prima asignada", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.Close()
        End If
    End Sub
    Private Function transaccion(ByVal datacodigo As DataTable, ByVal tipo As String, ByVal bodega As Integer, ByVal modelo As String) As List(Of Object)
        Dim listSql As New List(Of Object)
        Dim dFec As Date = Now
        Dim notas As String = "SPIC fecha:" & Now
        numero_transaccion = objOrdenProdLn.mover_consecutivo(tipo)
        listSql = objTraslado_bodLn.listaTransaccionDatable(numero_transaccion, datacodigo, bodega, dFec, notas, "PUAS", tipo, modelo)
        Return listSql
    End Function
End Class


