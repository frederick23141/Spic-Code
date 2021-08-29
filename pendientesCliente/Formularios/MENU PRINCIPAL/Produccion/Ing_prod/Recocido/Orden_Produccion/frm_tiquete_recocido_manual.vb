Imports logicaNegocios
Imports accesoDatos
Imports entidadNegocios
Public Class frm_tiquete_recocido_manual
    Dim frm_recocido_orden As New frm_ordne_prdo_rec2
    Private objOpsimpesLn As New Op_simpesLn
    'Esta formulario sirve para generar los tiquetes de recocido 
    Private Sub btn_imprimir_Click(sender As Object, e As EventArgs) Handles btn_imprimir.Click
        If validar_Campos() Then
            Dim nro_orden As Integer = CInt(txt_orden.Text)
            Dim id_detale As Integer = CInt(txt_detalle.Text)
            Dim sql As String
            Dim result_val As String
            sql = "select cod_orden from JB_orden_prod_rec_detalle where cod_orden=" & nro_orden & " and id_detalle=" & id_detale & ""
            result_val = objOpsimpesLn.consultValorTodo(sql, "PRODUCCION")
            If result_val <> "" Then
                frm_recocido_orden.consultar_datos_impresion(nro_orden, id_detale)
            Else
                MessageBox.Show("La orden ingresada no existe", "Orden ingresada no existe", MessageBoxButtons.OK)
            End If
        End If
    End Sub
    Private Function validar_Campos()
        Dim valor As Boolean = False
        If txt_orden.Text <> "" Then
            If txt_detalle.Text <> "" Then
                valor = True
            Else
                MessageBox.Show("Ingrese el id detalle", "Id detalle no ingresado", MessageBoxButtons.OK)
            End If
        Else
            MessageBox.Show("Ingrese el nro de la orden", "Orden no ingresada", MessageBoxButtons.OK)
        End If
        Return valor
    End Function
End Class