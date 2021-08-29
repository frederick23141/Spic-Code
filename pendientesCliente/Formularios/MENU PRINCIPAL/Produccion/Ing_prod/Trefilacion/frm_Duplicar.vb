Imports logicaNegocios
Imports System.Data.SqlClient
Public Class frm_Duplicar
    Private obj_op_simplesLn As New Op_simpesLn
    Dim cod_orden, user As String
    Dim ref_final As String
    Dim ref_alambron As String
    Dim area_destino As String
    Public Sub main(ByVal orden As String, ByVal usuario As String, ByVal prod_final As String, ByVal mat_prima As String, ByVal destino As String)
        cod_orden = orden
        user = usuario
        ref_final = prod_final
        ref_alambron = mat_prima
        area_destino = destino
    End Sub
    Private Sub txt_duplicar_Click(sender As Object, e As EventArgs) Handles txt_duplicar.Click
        Dim result As MsgBoxResult
        result = MessageBox.Show("Desea duplicar la orden?", "Duplicar orden", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = vbYes Then
            Dim sql As String
            Dim fecha As String = obj_op_simplesLn.cambiarFormatoFecha(mc_Fecha_Duplicar.SelectionRange.Start.Date)
            Dim ano As Integer = CInt(mc_Fecha_Duplicar.SelectionRange.Start.ToString("yyyy"))
            Dim mes As Integer = CInt(mc_Fecha_Duplicar.SelectionRange.Start.ToString("MM"))
            fecha = fecha & " 00:00:00"
            Dim cant_prog As String = txt_cant_prog.Text
            Dim notas As String = "Duplicada por:" & user & ""
            If area_destino = "T" Then
                Dim sql_prod As String
                sql_prod = "select costo_unitario from referencias where codigo='" & ref_final & "'"
                Dim costo_ref As String = obj_op_simplesLn.consultValorTodo(sql_prod, "CORSAN")
                sql_prod = "select Promedio from v_promedio where codigo='" & ref_alambron & "' and ano=" & Now.Year & " and mes=" & Now.Month & ""
                Dim costo_alam As String = obj_op_simplesLn.consultValorTodo(sql_prod, "CORSAN")
                sql = "SELECT  MAX (consecutivo)+1 FROM J_orden_prod_tef"
                Dim new_cod_orden As String = obj_op_simplesLn.consultValorTodo(sql, "PRODUCCION")
                If cant_prog = "" Then
                    sql = "SELECT  cant_prog FROM  J_orden_prod_tef where consecutivo=" & cod_orden & ""
                    cant_prog = obj_op_simplesLn.consultValorTodo(sql, "PRODUCCION")
                End If
                sql = " INSERT INTO  J_orden_prod_tef (consecutivo, prod_final, diam_min, diam_max, cant_prog, diametro, origen, materia_prima, trac_ini, trac_fin, numPasos, calidad, nit, tipoCliente, fecha_prog, id_maquina, mes, ano,fecha_creacion,cod_alambron,notas_auditoria,costo_prod_final,costo_mat_prima,oculto,num_ped,fecha_terminacion)" &
                      " SELECT '" & new_cod_orden & "', prod_final, diam_min, diam_max," & cant_prog & ", diametro, origen, materia_prima, trac_ini, trac_fin, numPasos, calidad, nit, tipoCliente, fecha_prog, id_maquina, '" & mes & "', '" & ano & "','" & fecha & "',cod_alambron,'" & notas & "'," & costo_ref & ", " & costo_alam & ",0,num_ped,'" & fecha & "' FROM  J_orden_prod_tef where consecutivo=" & cod_orden & ""
            ElseIf area_destino = "P" Then
                sql = "SELECT  MAX (consecutivo)+1 FROM J_orden_prod_punt_enc"
                Dim new_cod_orden As String = obj_op_simplesLn.consultValorTodo(sql, "PRODUCCION")
                If cant_prog = "" Then
                    sql = "SELECT  cant_prog FROM  J_orden_prod_punt_enc where consecutivo=" & cod_orden & ""
                    cant_prog = obj_op_simplesLn.consultValorTodo(sql, "PRODUCCION")
                End If
                sql = " INSERT INTO  J_orden_prod_punt_enc (consecutivo, maquina, origen, cant_prog, prod_final,mes,ano,fecha_creacion,notas_auditoria)" &
                     " SELECT '" & new_cod_orden & "', maquina, origen," & cant_prog & ", prod_final,'" & mes & "', '" & ano & "','" & fecha & "','" & notas & "' FROM  J_orden_prod_punt_enc where consecutivo=" & cod_orden & ""
            ElseIf area_destino = "G" Then
                sql = "SELECT  MAX (consecutivo_orden_G)+1 FROM D_orden_pro_galv_enc"
                Dim new_cod_orden As String = obj_op_simplesLn.consultValorTodo(sql, "PRODUCCION")
                If cant_prog = "" Then
                    sql = "SELECT  cant_prog FROM  D_orden_pro_galv_enc where consecutivo_orden_G=" & cod_orden & ""
                    cant_prog = obj_op_simplesLn.consultValorTodo(sql, "PRODUCCION")
                End If
                sql = " INSERT INTO  D_orden_pro_galv_enc (consecutivo_orden_G, nit_cliente, origen_galv, cant_prog, final_galv,calibre,tipoCliente,Nombre_cliente,mes,ano,fecha_creacion,notas_auditoria)" &
                     " SELECT '" & new_cod_orden & "', nit_cliente, origen_galv," & cant_prog & ", final_galv,calibre,tipoCliente,Nombre_cliente,'" & mes & "', '" & ano & "','" & fecha & "','" & notas & "'  FROM  D_orden_pro_galv_enc where consecutivo_orden_G=" & cod_orden & ""
            ElseIf area_destino = "PU" Then
                sql = "SELECT  MAX (cod_orden)+1 FROM D_orden_prod_puas"
                Dim new_cod_orden As String = obj_op_simplesLn.consultValorTodo(sql, "PRODUCCION")
                If cant_prog = "" Then
                    sql = "SELECT  cant_prog FROM  D_orden_prod_puas where cod_orden=" & cod_orden & ""
                    cant_prog = obj_op_simplesLn.consultValorTodo(sql, "PRODUCCION")
                End If
                sql = " INSERT INTO  D_orden_prod_puas (cod_orden,maquina,nom_maq,mat_prim,mat_prim2,0,cant_prog, prod_final,mes,ano,fecha_creacion,notas_auditoria)" &
                     " SELECT '" & new_cod_orden & "',maquina,nom_maq,mat_prim,mat_prim2,oculto," & cant_prog & ", prod_final,'" & mes & "', '" & ano & "','" & fecha & "','" & notas & "'  FROM  D_orden_prod_puas where cod_orden=" & cod_orden & ""
            End If
#Disable Warning BC42104 ' La variable 'sql' se usa antes de que se le haya asignado un valor. Podría darse una excepción de referencia NULL en tiempo de ejecución.
            obj_op_simplesLn.ejecutar(sql, "PRODUCCION")
#Enable Warning BC42104 ' La variable 'sql' se usa antes de que se le haya asignado un valor. Podría darse una excepción de referencia NULL en tiempo de ejecución.
            MessageBox.Show("Orden duplicada!", "Orden duplicada", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        Else
            Me.Close()
        End If
    End Sub
End Class