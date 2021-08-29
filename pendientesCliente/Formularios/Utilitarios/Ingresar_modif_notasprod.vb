Imports logicaNegocios
Imports entidadNegocios
Imports accesoDatos
Imports System.Data.SqlClient
Public Class Ingresar_modif_notasprod
    Dim nro_ped As Integer
    Dim ref_id As Integer
    Dim respuesta As Boolean
    Dim formu As Frm_super_modulo_consult_pendientes
    Dim objIngresoProdLn As New Ing_prodLn
    Public Sub main(ByVal form As Frm_super_modulo_consult_pendientes, ByVal numero As Integer, ByVal Id_ref As Integer, ByVal resp As Boolean)
        Dim sql As String
        Dim infor As String
        nro_ped = numero
        ref_id = Id_ref
        respuesta = resp
        formu = form
        sql = "select nota_prod from documentos_lin_ped where numero =" & nro_ped & " and Id=" & ref_id & ""
        If respuesta = True Then
            Me.Text = "Modificar nota de producción"
            Button1.Text = "Modificar"
            infor = objIngresoProdLn.consultar_valor(sql, "CORSAN")
            txt_nota.Text = infor
        End If
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim sql As String
        Dim nota_prod As String = txt_nota.Text
        sql = "UPDATE documentos_lin_ped SET nota_prod ='" & nota_prod & "' where numero=" & nro_ped & " and Id=" & ref_id & ""
        If (objIngresoProdLn.ejecutar(sql, "CORSAN")) Then
            MessageBox.Show("Nota guardada correctamente", "Nota guardada", MessageBoxButtons.OK)
        End If
        Me.Close()
        formu.btn_actualizar.PerformClick()
    End Sub
End Class