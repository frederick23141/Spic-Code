Imports logicaNegocios
Public Class cboMes
    Private objOpSimplesLn As New Op_simpesLn
    Private objOperacionesForm As New OperacionesFormularios
    Dim dict_Seleccion As New Dictionary(Of String, String)
    Dim ds As String
    Private Sub Frm_ajute_contable_nvb_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargar_cbo()
        cargar_Datagrid()
    End Sub

    Private Sub btnCargar_Click(sender As Object, e As EventArgs) Handles btnCargar.Click
        cargar_Datagrid()
    End Sub
    Private Sub cargar_Datagrid()
        Dim sql As String
        Dim ano As String = cbo_ano.Text
        Dim mes As String = cbo_mes.SelectedValue
        Dim dt As New DataTable
        ds = cbo_ds.Text
        If ds = "Todos" Then
            sql = "select nit,fecha,tipo,numero,valor_total,valor_aplicado from documentos" &
             " where tipo like 'DS%' and sw=32 and anulado=0 and valor_aplicado=0 and year(fecha)=" & ano & " and  month(fecha) = " & mes & ""
        Else
            sql = "select nit,fecha,tipo,numero,valor_total,valor_aplicado from documentos" &
             " where tipo='" & ds & "' and sw=32 and anulado=0 and valor_aplicado=0 and year(fecha)=" & ano & " and  month(fecha) = " & mes & ""
        End If

        dt = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        dtg_contable.DataSource = dt
        dtg_contable.DataSource = totalizar_cartera()
        With dtg_contable
            .Columns("valor_total").DefaultCellStyle.Format = "###,###"
        End With
    End Sub
    Private Sub cargar_cbo()
        Dim sql As String
        Dim dt As DataTable
        Dim row As DataRow
        sql = "SELECT tipo FROM tipo_transacciones WHERE  tipo like 'DS%'"
        dt = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        row = dt.NewRow
        row("tipo") = "Todos"
        dt.Rows.Add(row)
        cbo_ds.DataSource = dt
        cbo_ds.ValueMember = "tipo"
        cbo_ds.DisplayMember = "tipo"
        cbo_ds.SelectedValue = "Todos"

        cbo_mes.DataSource = objOpSimplesLn.returnDtMeses()
        cbo_mes.ValueMember = "numMes"
        cbo_mes.DisplayMember = "nombMes"
        cbo_mes.SelectedValue = Now.Month

        For i = Now.Year - 1 To Now.Year + 1
            cbo_ano.Items.Add(i)
        Next
        cbo_ano.Text = Now.Year
    End Sub
    Private Function totalizar_cartera()
        Dim valor As Double = 0
        Dim valor_Apli As Double = 0
        Dim indice As Integer = 0
        Dim dt As DataTable = DirectCast(dtg_contable.DataSource, DataTable)
        For Each row As DataRow In dt.Rows
            If row.Item("valor_total") >= 0 Then
                valor += row.Item("valor_total")
            End If
            If row.Item("valor_aplicado") >= 0 Then
                valor_Apli += row.Item("valor_aplicado")
            End If
            If indice = (dt.Rows.Count - 1) Then
                dt.Rows.Add()
                dt.Rows(dt.Rows.Count - 1).Item("Tipo") = "TOTAL"
                dt.Rows(dt.Rows.Count - 1).Item("valor_total") = valor
                dt.Rows(dt.Rows.Count - 1).Item("valor_aplicado") = valor_Apli
                Exit For
            End If
            indice += 1
        Next
        Return dt
    End Function
    Public Sub pintartotal()
        If dtg_contable.Rows.Count > 0 Then
            dtg_contable.Rows(dtg_contable.Rows.Count - 1).DefaultCellStyle.Font = New Font(dtg_contable.CurrentCell.InheritedStyle.Font, FontStyle.Bold)
        End If
    End Sub
    Private Sub btn_ajustar_Click(sender As Object, e As EventArgs) Handles btn_ajustar.Click
        If dtg_contable.Rows.Count > 0 Then
            Dim sql As String
            Dim ano As String = cbo_ano.Text
            Dim mes As String = cbo_mes.SelectedValue
            Dim contra As String = InputBox("Ingrese la contraseña")
            Dim ds_Select As String = ""
            ds = cbo_ds.Text
            dict_Seleccion = New Dictionary(Of String, String)
            If contra = "1234" Then
                For Each dr As DataGridViewRow In dtg_contable.SelectedRows
                    dict_Seleccion.Add(dr.Cells("numero").Value.ToString, dr.Cells("tipo").Value.ToString)
                Next
                If dict_Seleccion.Count >= 1 Then
                    For Each kvp As KeyValuePair(Of String, String) In dict_Seleccion
                        If ds_Select = "" Then
                            ds_Select = kvp.Key
                        Else
                            ds_Select += "," & kvp.Key
                        End If
                    Next
                    If ds = "Todos" Then
                        sql = "update documentos set valor_aplicado=valor_total " &
                               " where tipo like 'DS%' and sw=32 and valor_aplicado=0 and year(fecha)=" & ano & " and  month(fecha) = " & mes & ""
                    Else
                        sql = "update documentos set valor_aplicado=valor_total " &
                                " where tipo='" & ds & "' and sw=32 and valor_aplicado=0 and year(fecha)=" & ano & " and  month(fecha) = " & mes & " and numero in (" & ds_Select & ")"
                    End If
                Else
                    If ds = "Todos" Then
                        sql = "update documentos set valor_aplicado=valor_total " &
                                " where tipo like 'DS%' and sw=32 and valor_aplicado=0 and year(fecha)=" & ano & " and  month(fecha) = " & mes & ""
                    Else
                        sql = "update documentos set valor_aplicado=valor_total " &
                                " where tipo='" & ds & "' and sw=32 and valor_aplicado=0 and year(fecha)=" & ano & " and  month(fecha) = " & mes & ""
                    End If
                End If

                objOpSimplesLn.ejecutar(sql, "CORSAN")
                cargar_Datagrid()
                MessageBox.Show("El ajuste se ha realizado", "Ajuste realizado", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                Me.Close()
                MessageBox.Show("Contraseña incorrecta,no puede realizar ajuste", "Ajuste realizado", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            MessageBox.Show("No hay nada para ajustar", "Ajuste no realizado", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Private Sub btn_Excel_Click(sender As Object, e As EventArgs) Handles btn_Excel.Click
        If dtg_contable.RowCount > 0 Then
            objOperacionesForm.ExportarDatosExcel(dtg_contable, "Ajuste contable")
        Else
            MessageBox.Show("No hay nada que exporta", "nada que exportar", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub dtg_contable_SelectionChanged(sender As Object, e As EventArgs) Handles dtg_contable.SelectionChanged
        Dim value As DataGridViewSelectedRowCollection = Me.dtg_contable.SelectedRows
        'Cargar la lista

    End Sub
End Class