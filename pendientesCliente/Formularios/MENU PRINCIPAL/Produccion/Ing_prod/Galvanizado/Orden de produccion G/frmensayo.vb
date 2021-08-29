Imports logicaNegocios
Imports accesoDatos
Imports entidadNegocios
Imports System.Data.SqlClient
Public Class frmensayo
    Private objOpsimpesLn As New Op_simpesLn

    Private Sub guardar_transaccion_rollo()

        Dim resp_transaccion As Boolean = False
        Dim tipo As String = ""
#Disable Warning BC42024 ' Variable local sin usar: 'consecutivos'.
        Dim consecutivos As String
#Enable Warning BC42024 ' Variable local sin usar: 'consecutivos'.
        Dim dFec As Date = Now
        Dim bodega As String = "3"
        Dim listTransaccion_corsan As New List(Of Object)
#Disable Warning BC42024 ' Variable local sin usar: 'capa'.
        Dim capa As String
#Enable Warning BC42024 ' Variable local sin usar: 'capa'.
        Dim peso As String = Convert.ToDouble(txtpeso.Text)
#Disable Warning BC42024 ' Variable local sin usar: 'descripcion'.
        Dim descripcion As String
#Enable Warning BC42024 ' Variable local sin usar: 'descripcion'.
#Disable Warning BC42024 ' Variable local sin usar: 'nombre_cliente'.
        Dim nombre_cliente As String
#Enable Warning BC42024 ' Variable local sin usar: 'nombre_cliente'.
#Disable Warning BC42024 ' Variable local sin usar: 'consecutivo'.
        Dim consecutivo As String
#Enable Warning BC42024 ' Variable local sin usar: 'consecutivo'.
#Disable Warning BC42024 ' Variable local sin usar: 'consecutivod'.
        Dim consecutivod As String
#Enable Warning BC42024 ' Variable local sin usar: 'consecutivod'.
        Dim dts As New galvanizadoEn
        Dim func As New galvanizadoAd
        Dim dt As New DataTable
        Dim sqlguardar As String = ""
        Dim sql_tolerancias As String = "SELECT rollo, porc_tolerancia, rango_superior FROM J_galv_tolerancia"
        Dim dt_tolerancias As DataTable = objOpsimpesLn.listar_datatable(sql_tolerancias, "PRODUCCION")
        Dim s_fecha As Date = Now
        Dim diferencia As Double = 0
        Dim fuera_rango As Boolean = True
        Dim validar_rango As Boolean = True
        If bodega = 3 Then
            tipo = "EPPT"
            For i = 0 To dt_tolerancias.Rows.Count - 1
                Dim calc As Double
                If peso >= dt_tolerancias.Rows(i).Item("rollo") - (dt_tolerancias.Rows(i).Item("rollo") * (dt_tolerancias.Rows(i).Item("porc_tolerancia") / 100)) And peso <= dt_tolerancias.Rows(i).Item("rango_superior") Then
                    fuera_rango = False
                    If dt_tolerancias.Rows(i).Item("rollo") = 25 Then
                        calc = dt_tolerancias.Rows(i).Item("rollo") - (dt_tolerancias.Rows(i).Item("rollo") * (dt_tolerancias.Rows(i).Item("porc_tolerancia") / 100)) + 0.4
                        If peso > calc And Convert.ToDouble(peso) <= dt_tolerancias.Rows(i).Item("rango_superior") Then
                            MessageBox.Show("Peso fuera del rango máximo establecido " & Convert.ToDouble(dt_tolerancias.Rows(i).Item("rollo") * ((dt_tolerancias.Rows(i).Item("porc_tolerancia") / 100) + 1)) & " , por lo tanto no se hara el registro", "Peso fuera de rango", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            validar_rango = False
                        End If
                    Else
                        calc = dt_tolerancias.Rows(i).Item("rollo") - (dt_tolerancias.Rows(i).Item("rollo") * (dt_tolerancias.Rows(i).Item("porc_tolerancia") / 100)) + 0.6
                        If peso > calc And Convert.ToDouble(peso) <= dt_tolerancias.Rows(i).Item("rango_superior") Then
                            MessageBox.Show("Peso fuera del rango máximo establecido " & Convert.ToDouble(dt_tolerancias.Rows(i).Item("rollo") * ((dt_tolerancias.Rows(i).Item("porc_tolerancia") / 100) + 1)) & " , por lo tanto no se hara el registro", "Peso fuera de rango", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            validar_rango = False
                        End If
                    End If
                    diferencia = (Convert.ToDouble(peso)) - dt_tolerancias.Rows(i).Item("rollo")
                    peso = dt_tolerancias.Rows(i).Item("rollo")
                End If
            Next


        End If


    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        guardar_transaccion_rollo()
    End Sub
End Class