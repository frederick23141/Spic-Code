Imports logicaNegocios
Imports accesoDatos
Imports entidadNegocios
Public Class frm_paros_galv
    Private objOpsimpesLn As New Op_simpesLn
    Public Sub recorrer_botones_color()
        Dim fecha_fin As String
        Dim sql As String = "select bobina from D_paros_galv where bobina= "
        Dim sql_total As String = ""
        For i As Integer = 1 To 25
            sql_total = sql & i & " and h_fin is null"
            fecha_fin = objOpsimpesLn.consultValorTodo(sql_total, "PRODUCCION")
            If Button1.Text = i Then
                If fecha_fin <> "" Then
                    Button1.BackColor = Color.Red
                Else
                    Button1.BackColor = Color.GreenYellow
                End If
            End If
            If Button2.Text = i Then
                If fecha_fin <> "" Then
                    Button2.BackColor = Color.Red
                Else
                    Button2.BackColor = Color.GreenYellow
                End If
            End If
            If Button3.Text = i Then
                If fecha_fin <> "" Then
                    Button3.BackColor = Color.Red
                Else
                    Button3.BackColor = Color.GreenYellow
                End If
            End If
            If Button4.Text = i Then
                If fecha_fin <> "" Then
                    Button4.BackColor = Color.Red
                Else
                    Button4.BackColor = Color.GreenYellow
                End If
            End If
            If Button5.Text = i Then
                If fecha_fin <> "" Then
                    Button5.BackColor = Color.Red
                Else
                    Button5.BackColor = Color.GreenYellow
                End If
            End If
            If Button6.Text = i Then
                If fecha_fin <> "" Then
                    Button6.BackColor = Color.Red
                Else
                    Button6.BackColor = Color.GreenYellow
                End If
            End If
            If Button7.Text = i Then
                If fecha_fin <> "" Then
                    Button7.BackColor = Color.Red
                Else
                    Button7.BackColor = Color.GreenYellow
                End If
            End If
            If Button8.Text = i Then
                If fecha_fin <> "" Then
                    Button8.BackColor = Color.Red
                Else
                    Button8.BackColor = Color.GreenYellow
                End If
            End If
            If Button9.Text = i Then
                If fecha_fin <> "" Then
                    Button9.BackColor = Color.Red
                Else
                    Button9.BackColor = Color.GreenYellow
                End If
            End If
            If Button10.Text = i Then
                If fecha_fin <> "" Then
                    Button10.BackColor = Color.Red
                Else
                    Button10.BackColor = Color.GreenYellow
                End If
            End If
            If Button11.Text = i Then
                If fecha_fin <> "" Then
                    Button11.BackColor = Color.Red
                Else
                    Button11.BackColor = Color.GreenYellow
                End If
            End If
            If Button12.Text = i Then
                If fecha_fin <> "" Then
                    Button12.BackColor = Color.Red
                Else
                    Button12.BackColor = Color.GreenYellow
                End If
            End If
            If Button13.Text = i Then
                If fecha_fin <> "" Then
                    Button13.BackColor = Color.Red
                Else
                    Button13.BackColor = Color.GreenYellow
                End If
            End If
            If Button14.Text = i Then
                If fecha_fin <> "" Then
                    Button14.BackColor = Color.Red
                Else
                    Button14.BackColor = Color.GreenYellow
                End If
            End If
            If Button15.Text = i Then
                If fecha_fin <> "" Then
                    Button15.BackColor = Color.Red
                Else
                    Button15.BackColor = Color.GreenYellow
                End If
            End If
            If Button16.Text = i Then
                If fecha_fin <> "" Then
                    Button16.BackColor = Color.Red
                Else
                    Button16.BackColor = Color.GreenYellow
                End If
            End If
            If Button17.Text = i Then
                If fecha_fin <> "" Then
                    Button17.BackColor = Color.Red
                Else
                    Button17.BackColor = Color.GreenYellow
                End If
            End If
            If Button18.Text = i Then
                If fecha_fin <> "" Then
                    Button18.BackColor = Color.Red
                Else
                    Button18.BackColor = Color.GreenYellow
                End If
            End If
            If Button19.Text = i Then
                If fecha_fin <> "" Then
                    Button19.BackColor = Color.Red
                Else
                    Button19.BackColor = Color.GreenYellow
                End If
            End If
            If Button20.Text = i Then
                If fecha_fin <> "" Then
                    Button20.BackColor = Color.Red
                Else
                    Button20.BackColor = Color.GreenYellow
                End If
            End If
            If Button21.Text = i Then
                If fecha_fin <> "" Then
                    Button21.BackColor = Color.Red
                Else
                    Button21.BackColor = Color.GreenYellow
                End If
            End If
            If Button22.Text = i Then
                If fecha_fin <> "" Then
                    Button22.BackColor = Color.Red
                Else
                    Button22.BackColor = Color.GreenYellow
                End If
            End If
            If Button23.Text = i Then
                If fecha_fin <> "" Then
                    Button23.BackColor = Color.Red
                Else
                    Button23.BackColor = Color.GreenYellow
                End If
            End If
            If Button24.Text = i Then
                If fecha_fin <> "" Then
                    Button24.BackColor = Color.Red
                Else
                    Button24.BackColor = Color.GreenYellow
                End If
            End If
            If Button25.Text = i Then
                If fecha_fin <> "" Then
                    Button25.BackColor = Color.Red
                Else
                    Button25.BackColor = Color.GreenYellow
                End If
            End If
        Next

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim frm As New Frm_ingresar_paros
        frm.main(1)
        frm.ShowDialog()
        recorrer_botones_color()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim frm As New Frm_ingresar_paros
        frm.main(2)
        frm.ShowDialog()
        recorrer_botones_color()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim frm As New Frm_ingresar_paros
        frm.main(3)
        frm.ShowDialog()
        recorrer_botones_color()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim frm As New Frm_ingresar_paros
        frm.main(4)
        frm.ShowDialog()
        recorrer_botones_color()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim frm As New Frm_ingresar_paros
        frm.main(5)
        frm.ShowDialog()
        recorrer_botones_color()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim frm As New Frm_ingresar_paros
        frm.main(6)
        frm.ShowDialog()
        recorrer_botones_color()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim frm As New Frm_ingresar_paros
        frm.main(7)
        frm.ShowDialog()
        recorrer_botones_color()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Dim frm As New Frm_ingresar_paros
        frm.main(8)
        frm.ShowDialog()
        recorrer_botones_color()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Dim frm As New Frm_ingresar_paros
        frm.main(9)
        frm.ShowDialog()
        recorrer_botones_color()
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Dim frm As New Frm_ingresar_paros
        frm.main(10)
        frm.ShowDialog()
        recorrer_botones_color()
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        Dim frm As New Frm_ingresar_paros
        frm.main(11)
        frm.ShowDialog()
        recorrer_botones_color()
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        Dim frm As New Frm_ingresar_paros
        frm.main(12)
        frm.ShowDialog()
        recorrer_botones_color()
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        Dim frm As New Frm_ingresar_paros
        frm.main(13)
        frm.ShowDialog()
        recorrer_botones_color()
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        Dim frm As New Frm_ingresar_paros
        frm.main(14)
        frm.ShowDialog()
        recorrer_botones_color()
    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        Dim frm As New Frm_ingresar_paros
        frm.main(15)
        frm.ShowDialog()
        recorrer_botones_color()
    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        Dim frm As New Frm_ingresar_paros
        frm.main(16)
        frm.ShowDialog()
        recorrer_botones_color()
    End Sub

    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        Dim frm As New Frm_ingresar_paros
        frm.main(17)
        frm.ShowDialog()
        recorrer_botones_color()
    End Sub

    Private Sub Button18_Click(sender As Object, e As EventArgs) Handles Button18.Click
        Dim frm As New Frm_ingresar_paros
        frm.main(18)
        frm.ShowDialog()
        recorrer_botones_color()
    End Sub

    Private Sub Button19_Click(sender As Object, e As EventArgs) Handles Button19.Click
        Dim frm As New Frm_ingresar_paros
        frm.main(19)
        frm.ShowDialog()
        recorrer_botones_color()
    End Sub

    Private Sub Button20_Click(sender As Object, e As EventArgs) Handles Button20.Click
        Dim frm As New Frm_ingresar_paros
        frm.main(20)
        frm.ShowDialog()
        recorrer_botones_color()
    End Sub

    Private Sub Button21_Click(sender As Object, e As EventArgs) Handles Button21.Click
        Dim frm As New Frm_ingresar_paros
        frm.main(21)
        frm.ShowDialog()
        recorrer_botones_color()
    End Sub

    Private Sub Button22_Click(sender As Object, e As EventArgs) Handles Button22.Click
        Dim frm As New Frm_ingresar_paros
        frm.main(22)
        frm.ShowDialog()
        recorrer_botones_color()
    End Sub

    Private Sub Button23_Click(sender As Object, e As EventArgs) Handles Button23.Click
        Dim frm As New Frm_ingresar_paros
        frm.main(23)
        frm.ShowDialog()
        recorrer_botones_color()
    End Sub

    Private Sub Button24_Click(sender As Object, e As EventArgs) Handles Button24.Click
        Dim frm As New Frm_ingresar_paros
        frm.main(24)
        frm.ShowDialog()
        recorrer_botones_color()
    End Sub

    Private Sub Button25_Click(sender As Object, e As EventArgs) Handles Button25.Click
        Dim frm As New Frm_ingresar_paros
        frm.main(25)
        frm.ShowDialog()
        recorrer_botones_color()
    End Sub

    Private Sub frm_paros_galv_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        recorrer_botones_color()
    End Sub
End Class