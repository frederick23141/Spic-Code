Imports entidadNegocios
Imports logicaNegocios
Public Class Frm_cierre_forzado
    Private obj_Op_simpesLn As New Op_simpesLn
    Private obj_Ing_prodLn As New Ing_prodLn
    Private sql As String
    'Este modulo es para cerrar el spic de manera forzada
    Private Sub btncerrar_spic_Click(sender As Object, e As EventArgs) Handles btncerrar_spic.Click
        sql = "INSERT INTO J_spic_cerrar_aplicacion (descripcion,estado) values ('ABIERTO','S')"
        If obj_Op_simpesLn.ejecutar(sql, "CORSAN") > 0 Then
            Application.ExitThread()
        Else
            MessageBox.Show("No se pudo cerrar el spic", "Cerrar spic", MessageBoxButtons.OK)
        End If
    End Sub
    Private Sub Frm_cierre_forzado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        sql = "SELECT * FROM J_spic_cerrar_aplicacion"
        If obj_Ing_prodLn.consultar_valor(sql, "CORSAN") <> "0" Then
            btncerrar_spic.Visible = False
            btn_cancelar_cierre.Visible = True
        End If
    End Sub

    Private Sub btn_cancelar_cierre_Click(sender As Object, e As EventArgs) Handles btn_cancelar_cierre.Click
        sql = "DELETE FROM J_spic_cerrar_aplicacion"
        If obj_Op_simpesLn.ejecutar(sql, "CORSAN") > 0 Then
            MessageBox.Show("Se a cancelado el cierre", "Cancelado cierre", MessageBoxButtons.OK)
            Application.ExitThread()
        Else
            MessageBox.Show("No se pudo cancelar el cierre", "cancelar cierre", MessageBoxButtons.OK)
        End If
    End Sub
End Class