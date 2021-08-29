Imports logicaNegocios
Imports entidadNegocios
Public Class Frm_paros_puas
    Private dt As DataTable
    Private objOpSimplesLn As New Op_simpesLn
    Dim dic_CodigoM As New Dictionary(Of String, String)
    Private Sub Frm_paros_puas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargar_Nombres()
        recorrer_botones_color()
    End Sub
    Private Sub cargar_Nombres()
        Dim sql As String
        sql = "SELECT m.codigoM,m.Descripción,s.seccion  FROM J_maquinas m , D_seccion_maquina_puas s WHERE s.maquina = m.codigoM AND m.tipoMAquina = 4 ORDER BY m.codigoM"
        dt = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")
        btnMaq1.Text = dt.Rows(0).Item("Descripción")
        btnMaq2.Text = dt.Rows(1).Item("Descripción")
        btnMaq3.Text = dt.Rows(2).Item("Descripción")
        btnMaq4.Text = dt.Rows(3).Item("Descripción")
        btnMaq5.Text = dt.Rows(4).Item("Descripción")
        btnMaq6.Text = dt.Rows(5).Item("Descripción")
        btnMaq7.Text = dt.Rows(6).Item("Descripción")
        btnMaq8.Text = dt.Rows(7).Item("Descripción")
        btnMaq9.Text = dt.Rows(8).Item("Descripción")
        btnMaq10.Text = dt.Rows(9).Item("Descripción")
        btnMaq11.Text = dt.Rows(10).Item("Descripción")
        btnMaq12.Text = dt.Rows(11).Item("Descripción")
        Dim codigo As Integer
        For Each i In dt.Rows
            codigo = CInt(i.Item("codigoM"))
            dic_CodigoM.Add(codigo, i.Item("Descripción"))
        Next
    End Sub
    Public Sub recorrer_botones_color()
        Dim fecha_fin As String
        Dim sql As String = "select codmaqui from D_paros_puas where codmaqui= "
        Dim sql_total As String = ""
        For Each i In dt.Rows
            sql_total = sql & i.Item("codigoM") & " and h_fin is null"
            fecha_fin = objOpSimplesLn.consultValorTodo(sql_total, "PRODUCCION")
            If btnMaq1.Text = i.Item("Descripción") Then
                If fecha_fin <> "" Then
                    btnMaq1.BackColor = Color.Red
                Else
                    btnMaq1.BackColor = Color.GreenYellow
                End If
            End If
            If btnMaq2.Text = i.Item("Descripción") Then
                If fecha_fin <> "" Then
                    btnMaq2.BackColor = Color.Red
                Else
                    btnMaq2.BackColor = Color.GreenYellow
                End If
            End If
            If btnMaq3.Text = i.Item("Descripción") Then
                If fecha_fin <> "" Then
                    btnMaq3.BackColor = Color.Red
                Else
                    btnMaq3.BackColor = Color.GreenYellow
                End If
            End If
            If btnMaq4.Text = i.Item("Descripción") Then
                If fecha_fin <> "" Then
                    btnMaq4.BackColor = Color.Red
                Else
                    btnMaq4.BackColor = Color.GreenYellow
                End If
            End If
            If btnMaq5.Text = i.Item("Descripción") Then
                If fecha_fin <> "" Then
                    btnMaq5.BackColor = Color.Red
                Else
                    btnMaq5.BackColor = Color.GreenYellow
                End If
            End If
            If btnMaq6.Text = i.Item("Descripción") Then
                If fecha_fin <> "" Then
                    btnMaq6.BackColor = Color.Red
                Else
                    btnMaq6.BackColor = Color.GreenYellow
                End If
            End If
            If btnMaq7.Text = i.Item("Descripción") Then
                If fecha_fin <> "" Then
                    btnMaq7.BackColor = Color.Red
                Else
                    btnMaq7.BackColor = Color.GreenYellow
                End If
            End If
            If btnMaq8.Text = i.Item("Descripción") Then
                If fecha_fin <> "" Then
                    btnMaq8.BackColor = Color.Red
                Else
                    btnMaq8.BackColor = Color.GreenYellow
                End If
            End If
            If btnMaq9.Text = i.Item("Descripción") Then
                If fecha_fin <> "" Then
                    btnMaq9.BackColor = Color.Red
                Else
                    btnMaq9.BackColor = Color.GreenYellow
                End If
            End If
            If btnMaq10.Text = i.Item("Descripción") Then
                If fecha_fin <> "" Then
                    btnMaq10.BackColor = Color.Red
                Else
                    btnMaq10.BackColor = Color.GreenYellow
                End If
            End If
            If btnMaq11.Text = i.Item("Descripción") Then
                If fecha_fin <> "" Then
                    btnMaq11.BackColor = Color.Red
                Else
                    btnMaq11.BackColor = Color.GreenYellow
                End If
            End If
            If btnMaq12.Text = i.Item("Descripción") Then
                If fecha_fin <> "" Then
                    btnMaq12.BackColor = Color.Red
                Else
                    btnMaq12.BackColor = Color.GreenYellow
                End If
            End If
        Next
    End Sub
    Private Sub btnMaq1_Click(sender As Object, e As EventArgs) Handles btnMaq1.Click
        Dim frm As New Frm_ingreso_paros_puas
        Dim myCod = dic_CodigoM.FirstOrDefault(Function(x) x.Value = btnMaq1.Text).Key
        frm.main(myCod)
        frm.ShowDialog()
        recorrer_botones_color()
    End Sub

    Private Sub btnMaq2_Click(sender As Object, e As EventArgs) Handles btnMaq2.Click
        Dim frm As New Frm_ingreso_paros_puas
        Dim myCod = dic_CodigoM.FirstOrDefault(Function(x) x.Value = btnMaq2.Text).Key
        frm.main(myCod)
        frm.ShowDialog()
        recorrer_botones_color()
    End Sub

    Private Sub btnMaq3_Click(sender As Object, e As EventArgs) Handles btnMaq3.Click
        Dim frm As New Frm_ingreso_paros_puas
        Dim myCod = dic_CodigoM.FirstOrDefault(Function(x) x.Value = btnMaq3.Text).Key
        frm.main(myCod)
        frm.ShowDialog()
        recorrer_botones_color()
    End Sub

    Private Sub btnMaq4_Click(sender As Object, e As EventArgs) Handles btnMaq4.Click
        Dim frm As New Frm_ingreso_paros_puas
        Dim myCod = dic_CodigoM.FirstOrDefault(Function(x) x.Value = btnMaq4.Text).Key
        frm.main(myCod)
        frm.ShowDialog()
        recorrer_botones_color()
    End Sub

    Private Sub btnMaq5_Click(sender As Object, e As EventArgs) Handles btnMaq5.Click
        Dim frm As New Frm_ingreso_paros_puas
        Dim myCod = dic_CodigoM.FirstOrDefault(Function(x) x.Value = btnMaq5.Text).Key
        frm.main(myCod)
        frm.ShowDialog()
        recorrer_botones_color()
    End Sub

    Private Sub btnMaq6_Click(sender As Object, e As EventArgs) Handles btnMaq6.Click
        Dim frm As New Frm_ingreso_paros_puas
        Dim myCod = dic_CodigoM.FirstOrDefault(Function(x) x.Value = btnMaq6.Text).Key
        frm.main(myCod)
        frm.ShowDialog()
        recorrer_botones_color()
    End Sub

    Private Sub btnMaq7_Click(sender As Object, e As EventArgs) Handles btnMaq7.Click
        Dim frm As New Frm_ingreso_paros_puas
        Dim myCod = dic_CodigoM.FirstOrDefault(Function(x) x.Value = btnMaq7.Text).Key
        frm.main(myCod)
        frm.ShowDialog()
        recorrer_botones_color()
    End Sub

    Private Sub btnMaq8_Click(sender As Object, e As EventArgs) Handles btnMaq8.Click
        Dim frm As New Frm_ingreso_paros_puas
        Dim myCod = dic_CodigoM.FirstOrDefault(Function(x) x.Value = btnMaq8.Text).Key
        frm.main(myCod)
        frm.ShowDialog()
        recorrer_botones_color()
    End Sub

    Private Sub btnMaq9_Click(sender As Object, e As EventArgs) Handles btnMaq9.Click
        Dim frm As New Frm_ingreso_paros_puas
        Dim myCod = dic_CodigoM.FirstOrDefault(Function(x) x.Value = btnMaq9.Text).Key
        frm.main(myCod)
        frm.ShowDialog()
        recorrer_botones_color()
    End Sub

    Private Sub btnMaq10_Click(sender As Object, e As EventArgs) Handles btnMaq10.Click
        Dim frm As New Frm_ingreso_paros_puas
        Dim myCod = dic_CodigoM.FirstOrDefault(Function(x) x.Value = btnMaq10.Text).Key
        frm.main(myCod)
        frm.ShowDialog()
        recorrer_botones_color()
    End Sub

    Private Sub btnMaq11_Click(sender As Object, e As EventArgs) Handles btnMaq11.Click
        Dim frm As New Frm_ingreso_paros_puas
        Dim myCod = dic_CodigoM.FirstOrDefault(Function(x) x.Value = btnMaq11.Text).Key
        frm.main(myCod)
        frm.ShowDialog()
        recorrer_botones_color()
    End Sub

    Private Sub btnMaq12_Click(sender As Object, e As EventArgs) Handles btnMaq12.Click
        Dim frm As New Frm_ingreso_paros_puas
        Dim myCod = dic_CodigoM.FirstOrDefault(Function(x) x.Value = btnMaq12.Text).Key
        frm.main(myCod)
        frm.ShowDialog()
        recorrer_botones_color()
    End Sub
End Class