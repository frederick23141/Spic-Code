Imports logicaNegocios
Public Class Asignar_dias
    Dim nit_r As Double
    Private objOpSimplesLn As New Op_simpesLn
    Public Sub main(ByVal nit As Double)
        nit_r = nit
    End Sub

    Private Sub btn_asignar_Click(sender As Object, e As EventArgs) Handles btn_asignar.Click
        If validar_asignar_dias() Then
            Dim dinicial As Date = cbo_calendar.SelectionStart
            Dim dfinal As Date = cbo_calendar.SelectionEnd
            Dim sa As String = "J_permiso_dias_cont"
            Dim inicio_cont As Integer = dinicial.Day
            Dim final_cont As Integer = dfinal.Day
            Dim mes_inicial As Integer = dinicial.Month
            Dim mes_final As Integer = dfinal.Month
            Dim ano_inicial As Integer = dinicial.Year
            Dim ano_final As Integer = dfinal.Year
            Dim obser As String = txt_obj_visit.Text
            Dim sql As String = ""
            While inicio_cont <= final_cont
                sql = "insert into J_perm_dias_cont (nit_contra,dia,mes,ano,observacion) " &
                     "values (" & nit_r & "," & inicio_cont & "," & mes_inicial & "," & ano_inicial & ",'" & obser & "')"
                objOpSimplesLn.ejecutar(sql, "CONTROL")
                inicio_cont = inicio_cont + 1
            End While
            MessageBox.Show("Se le han asignado los dias", "Dias Asignados", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        End If
    End Sub
    Private Function validar_asignar_dias()
        Dim resp As Boolean = False
        If txt_obj_visit.Text <> "" Then
            resp = True
        Else
            MessageBox.Show("Ingresar objeto de visita", "Ingresar objeto", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Return resp
    End Function
End Class