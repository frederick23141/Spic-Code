Imports logicaNegocios
Public Class Frm_informe_paros_galv
    Private objOpsimpesLn As New Op_simpesLn
    Private objOperacionesForm As OperacionesFormularios = New OperacionesFormularios
    Private Sub Frm_informe_paros_galv_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargar_cbo()
    End Sub
    Private Sub cargar_cbo()
        'llenar combos de años y meses
        cboAño.Items.Add(Now.Year)
        cboAño.Items.Add(Now.Year - 1)
        cboAño.Items.Add(Now.Year - 2)
        cboAño.Items.Add(Now.Year - 3)
        cboAño.Items.Add(Now.Year - 4)
        cboAño.SelectedIndex = 0
        cboMes.SelectedIndex = Now.Month - 1
        cbo_bobina.SelectedValue = 0
        cbo_bobina.SelectedText = "Seleccione"
    End Sub
    Private Sub btn_cargar_Click(sender As Object, e As EventArgs) Handles btn_cargar.Click
        cargar_paros()
    End Sub
    Private Sub cargar_paros()
        Dim ano As String = cboAño.Text
        Dim mes As String = cboMes.Text
        Dim bobina As String = cbo_bobina.Text
        Dim sql As String = ""
        If mes <> "Seleccione" And bobina <> "Seleccione" And bobina <> "" Then
            sql = "select bobina, CASE num_paro when 1 then 'Enredo en devanador' when 2 then 'Enredo en bobina' when 3 then 'Reviente en horno' when 4 then 'Reviente en bobina' when 5 then 'Daño mecanico' when 6 then 'Daño electrico' " &
                  " when 7 then 'Cambio de referencia' when 8 then 'Ausencia de operario' when 9 then 'Grumos' END AS Paro_descrip" &
                  ", h_ini, h_fin, minutos from D_paros_galv where year(h_fin)=" & ano & " and month(h_fin)=" & mes & " and bobina=" & bobina & " order by h_fin"
        ElseIf mes <> "Seleccione" And bobina = "Seleccione" Then
            sql = "select bobina, CASE num_paro when 1 then 'Enredo en devanador' when 2 then 'Enredo en bobina' when 3 then 'Reviente en horno' when 4 then 'Reviente en bobina' when 5 then 'Daño mecanico' when 6 then 'Daño electrico' " &
                  " when 7 then 'Cambio de referencia' when 8 then 'Ausencia de operario' when 9 then 'Grumos' END AS Paro_descrip" &
                  ", h_ini, h_fin, minutos from D_paros_galv where year(h_fin)=" & ano & " and month(h_fin)=" & mes & " order by h_fin"
        ElseIf (mes = "Seleccione" And bobina = "Seleccione") Or (mes = "" And bobina = "") Then
            sql = "select bobina, CASE num_paro when 1 then 'Enredo en devanador' when 2 then 'Enredo en bobina' when 3 then 'Reviente en horno' when 4 then 'Reviente en bobina' when 5 then 'Daño mecanico' when 6 then 'Daño electrico'" &
                   " when 7 then 'Cambio de referencia' when 8 then 'Ausencia de operario' when 9 then 'Grumos' END AS Paro_descrip" &
                   ", h_ini, h_fin, minutos from D_paros_galv where year(h_fin)=" & ano & " order by h_fin"
        End If
        dtg_paros.DataSource = objOpsimpesLn.listar_datatable(sql, "PRODUCCION")
        dtg_paros.DataSource = totalizar_paros()
    End Sub
    Private Function totalizar_paros()
        Dim valor As Double = 0
        Dim indice As Integer = 0
        Dim dt As DataTable = DirectCast(dtg_paros.DataSource, DataTable)
        For Each row As DataRow In dt.Rows
            If row.Item("minutos") >= 0 Then
                valor += row.Item("minutos")
            End If
            If indice = (dt.Rows.Count - 1) Then
                dt.Rows.Add()
                dt.Rows(dt.Rows.Count - 1).Item("minutos") = valor
                Exit For
            End If
            indice += 1
        Next
        Return dt
    End Function

    Private Sub btnexcel_Click(sender As Object, e As EventArgs) Handles btnexcel.Click
        If dtg_paros.RowCount > 0 Then
            objOperacionesForm.ExportarDatosExcel(dtg_paros, "Informe de paros")
        Else
            MessageBox.Show("No hay información que exportar", "Exportar a excel", MessageBoxButtons.OK)
        End If
    End Sub
End Class