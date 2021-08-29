Imports logicaNegocios
Imports System.Data.SqlClient
Public Class frm_Bloquear_ordenes
    Dim orden As String
    Dim estados As String
    Private obj_op_simplesLn As New Op_simpesLn
    Public Sub main(ByVal nro_orden As String, ByVal estado As String)
        orden = nro_orden
        estados = estado
    End Sub
    Private Sub btn_bloquear_Click(sender As Object, e As EventArgs) Handles btn_bloquear.Click
        Dim sql As String
        If validar() Then
            Dim nota As String = txt_nota.Text
            nota = Replace(nota, vbCrLf, " ")
            If estados = "T" Then
                sql = "UPDATE J_orden_prod_tef SET notas_liquidacion =  '" & nota & "' WHERE consecutivo = " & orden & ""
                obj_op_simplesLn.ejecutar(sql, "PRODUCCION")
                Me.Close()
            ElseIf estados = "G" Then
                sql = "UPDATE D_orden_pro_galv_enc SET notas_liquidacion =  '" & nota & "' WHERE consecutivo_orden_G = " & orden & ""
                obj_op_simplesLn.ejecutar(sql, "PRODUCCION")
                Me.Close()
            ElseIf estados = "P" Then
                sql = "UPDATE J_orden_prod_punt_enc SET notas_liquidacion =  '" & nota & "' WHERE consecutivo = " & orden & ""
                obj_op_simplesLn.ejecutar(sql, "PRODUCCION")
                Me.Close()
            End If
        End If
    End Sub
    Private Function validar()
        Dim resp As Boolean = False
        If txt_nota.Text <> "" Then
            resp = True
        End If
        Return resp
    End Function
End Class