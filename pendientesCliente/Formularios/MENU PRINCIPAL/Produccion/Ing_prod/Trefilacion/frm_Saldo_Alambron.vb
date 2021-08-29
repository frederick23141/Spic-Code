Imports logicaNegocios
Public Class frm_Saldo_Alambron
    Private obj_Ing_prodLn As New Ing_prodLn
    Private Sub frm_Saldo_Alambron_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargar_Cbo()
    End Sub
    Private Sub cargar_Cbo()
        Dim sql As String = "select codigoM,Nombre from J_Maquinas where codigoM between  2101 and 2121 "
        Dim dt As New DataTable
        Dim row As DataRow
        Dim mes As Integer = 1
        Dim ano As Integer
        For ano = Now.Year - 4 To Now.Year
            cbo_Ano.Items.Add(ano)
        Next
        For mes = 1 To 12
            cbo_mes.Items.Add(mes)
        Next

        dt = obj_Ing_prodLn.listar_datatable(sql, "PRODUCCION")
        row = dt.NewRow
        row("codigoM") = 0
        row("Nombre") = "Seleccione"
        dt.Rows.Add(row)
        cbo_tref.DataSource = dt
        cbo_tref.ValueMember = "codigoM"
        cbo_tref.DisplayMember = "Nombre"
        cbo_tref.SelectedValue = 0
    End Sub
    Private Function validar_campo()
        Dim resp As Boolean = False
        Dim val_Ano As String = cbo_Ano.Text
        Dim val_Mes As String = cbo_mes.Text
        If val_Ano <> "" Then
            If val_Mes <> "" Then
                resp = True
            Else
                MessageBox.Show("Seleccione el Mes")
            End If
        Else
            MessageBox.Show("Seleccione el Año")
        End If
        Return resp
    End Function
    Private Sub cargar_Saldo()
        Dim sql_Saldo As String
        sql_Saldo = ""
        If validar_campo() Then
            Dim ano As String = cbo_Ano.Text
            Dim mes As String = cbo_mes.Text

            If cbo_tref.Text = "Seleccione" Then
                sql_Saldo = "select mp.peso_real,mp.peso_lleva,mp.cod_alambron,ma.nombre from J_tref_cont_mp mp join J_Maquinas ma on mp.codigoM=ma.codigoM " &
                            "where mp.ano=" & ano & " and  mp.mes=" & mes & ""
            Else
                sql_Saldo = "select mp.peso_real,mp.peso_lleva,mp.cod_alambron,ma.nombre from J_tref_cont_mp mp join J_Maquinas ma on mp.codigoM=ma.codigoM " &
                            "where mp.ano=" & ano & " and  mp.mes=" & mes & " and mp.codigoM=" & cbo_tref.SelectedValue & ""
            End If
            dtg_Alambron.DataSource = obj_Ing_prodLn.listar_datatable(sql_Saldo, "PRODUCCION")
        End If
    End Sub
    Private Sub btn_cargar_Click(sender As Object, e As EventArgs) Handles btn_cargar.Click
        cargar_Saldo()
    End Sub
End Class