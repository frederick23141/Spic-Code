Imports logicaNegocios
Public Class Frm_informe_paros_puas
    Private obj_Ing_prodLn As New Ing_prodLn
    Private objOperacionesForm As New OperacionesFormularios
    Private Sub Frm_informe_paros_puas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargar_cbo()
    End Sub
    Private Sub cargar_cbo()
        Dim sql As String
        Dim dt As DataTable
        Dim row As DataRow
        sql = "SELECT m.codigoM,m.Descripción  As nombre FROM J_maquinas m , D_seccion_maquina_puas s WHERE s.maquina = m.codigoM AND m.tipoMAquina = 4 ORDER BY m.codigoM"
        dt = obj_Ing_prodLn.listar_datatable(sql, "PRODUCCION")
        row = dt.NewRow
        row("codigoM") = 0
        row("nombre") = "Seleccione"
        dt.Rows.Add(row)
        cbo_maquina.DataSource = dt
        cbo_maquina.ValueMember = "codigoM"
        cbo_maquina.DisplayMember = "nombre"
        cbo_maquina.SelectedValue = 0

        cbo_Ano.Items.Add(Now.Year)
        cbo_Ano.Items.Add(Now.Year - 1)
        cbo_Ano.Items.Add(Now.Year - 2)
        cbo_Ano.Items.Add(Now.Year - 3)
        cbo_Ano.Items.Add(Now.Year - 4)
        cbo_Ano.SelectedIndex = 0
        Cbo_Mes.SelectedIndex = Now.Month - 1
    End Sub

    Private Sub btn_carga_Click(sender As Object, e As EventArgs) Handles btn_carga.Click
        Dim ano As String = cbo_Ano.Text
        Dim mes As String = Cbo_Mes.Text
        Dim maq_Puas As String = cbo_maquina.Text
        Dim sql As String = ""
        If mes <> "Seleccione" And maq_Puas <> "Seleccione" And maq_Puas <> "" Then
            sql = "select (SELECT Descripción FROM J_maquinas where codigoM=codmaqui) as maquina_puas, CASE num_paro when 1 then 'Enredo' when 2 then 'Daño mecanico' when 3 then 'Daño electrico' when 4 then 'Ausencia de operario' when 5 then 'Falta alambre' when 6 then 'Cambio referencia' " &
                  " when 7 then 'Aseo maquina' when 8 then 'Ajuste de maquina' when 9 then 'Reviente' when 10 then 'Capacitación' when 11 then 'Alimentación' when 12 then 'Mantenimiento preventivo'  END AS Paro_descrip , h_ini, h_fin, minutos from D_paros_puas" &
                  "  where year(h_fin)=" & ano & " and month(h_fin)=" & mes & " and codmaqui=" & cbo_maquina.SelectedValue & " order by h_fin"
        ElseIf mes <> "Seleccione" And maq_Puas = "Seleccione" Then
            sql = "select (SELECT Descripción FROM J_maquinas where codigoM=codmaqui) as maquina_puas, CASE num_paro when 1 then 'Enredo' when 2 then 'Daño mecanico' when 3 then 'Daño electrico' when 4 then 'Ausencia de operario' when 5 then 'Falta alambre' when 6 then 'Cambio referencia' " &
                  " when 7 then 'Aseo maquina' when 8 then 'Ajuste de maquina' when 9 then 'Reviente' when 10 then 'Capacitación' when 11 then 'Alimentación' when 12 then 'Mantenimiento preventivo'  END AS Paro_descrip , h_ini, h_fin, minutos from D_paros_puas" &
                  " where year(h_fin)=" & ano & " and month(h_fin)=" & mes & " order by h_fin"
        ElseIf (mes = "Seleccione" And maq_Puas = "Seleccione") Or (mes = "" And maq_Puas = "") Then
            sql = "select (SELECT Descripción FROM J_maquinas where codigoM=codmaqui) as maquina_puas, CASE num_paro when 1 then 'Enredo' when 2 then 'Daño mecanico' when 3 then 'Daño electrico' when 4 then 'Ausencia de operario' when 5 then 'Falta alambre' when 6 then 'Cambio referencia' " &
                  " when 7 then 'Aseo maquina' when 8 then 'Ajuste de maquina' when 9 then 'Reviente' when 10 then 'Capacitación' when 11 then 'Alimentación' when 12 then 'Mantenimiento preventivo'  END AS Paro_descrip , h_ini, h_fin, minutos from D_paros_puas" &
                   " where year(h_fin)=" & ano & " order by h_fin"
        End If
        dtg_paros.DataSource = obj_Ing_prodLn.listar_datatable(sql, "PRODUCCION")
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
    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        If dtg_paros.RowCount > 0 Then
            objOperacionesForm.ExportarDatosExcel(dtg_paros, "Informe de paros")
        Else
            MessageBox.Show("No hay información que exportar", "Exportar a excel", MessageBoxButtons.OK)
        End If
    End Sub
End Class