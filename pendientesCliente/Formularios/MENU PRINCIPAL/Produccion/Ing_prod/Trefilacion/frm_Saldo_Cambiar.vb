Imports logicaNegocios
Public Class frm_Saldo_Cambiar
    Private obj_Ing_prodLn As New Ing_prodLn
    Private Sub frm_Saldo_Cambiar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'AsaldoDataSet.J_tref_cont_mp' Puede moverla o quitarla según sea necesario.
        Me.J_tref_cont_mpTableAdapter.Fill(Me.AsaldoDataSet.J_tref_cont_mp)
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
    Private Sub BindingNavigatorEditItem_Click(sender As Object, e As EventArgs) Handles BindingNavigatorEditItem.Click
        Try
            Me.Validate()
            Me.JtrefcontmpBindingSource.EndEdit()
            Me.J_tref_cont_mpTableAdapter.Update(Me.AsaldoDataSet)
            MessageBox.Show("Información actualizada")
        Catch ex As Exception

        End Try
    End Sub
    Private Sub btn_cargar_Click(sender As Object, e As EventArgs) Handles btn_cargar.Click
        Me.J_tref_cont_mpTableAdapter.Fill(Me.AsaldoDataSet.J_tref_cont_mp)
        If cbo_tref.Text <> "Seleccione" Then
            Me.JtrefcontmpBindingSource.Filter = "ano = " & cbo_Ano.Text & " and mes=" & cbo_mes.Text & " and codigoM=" & cbo_tref.SelectedValue
        Else
            If cbo_Ano.Text <> "" And cbo_mes.Text <> "" Then
                Me.JtrefcontmpBindingSource.Filter = "ano = " & cbo_Ano.Text & " and mes=" & cbo_mes.Text
            Else
                MessageBox.Show("Ingrese el Año y el mes", "Falta año o mes")
            End If
        End If
    End Sub
End Class