Imports logicaNegocios
Imports accesoDatos
Imports entidadNegocios
Public Class frm_informe_dif_tref
    Private objOpsimpesLn As New Op_simpesLn
    Private objOperacionesForm As OperacionesFormularios = New OperacionesFormularios

    Private Sub frm_informe_dif_tref_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For i = Now.Year - 1 To Now.Year + 1
            cbo_ano.Items.Add(i)
        Next
        cbo_ano.Text = Now.Year

        cbo_mes.DataSource = objOpsimpesLn.returnDtMeses()
        cbo_mes.ValueMember = "numMes"
        cbo_mes.DisplayMember = "nombMes"
        cbo_mes.SelectedValue = Now.Month

        rdb_externo.Checked = True
    End Sub


    Private Sub consulta()
        Dim tipo As String = ""
        Dim sql As String = ""
        Dim dt As New DataTable
        If rdb_externo.Checked = True Then
            tipo = "EPPT"
        End If
        If rdb_interno.Checked = True Then
            tipo = "EPPP"
        End If
        If chk_consolidar.Checked = True Then
            sql = "SELECT prod_final,descripcion,sum(peso) as peso,sum(peso_real) as peso_real,Sum(diferencia) as diferencia,(sum(diferencia) / sum(peso)) AS porc,ano,mes FROM JB_v_diferencia_tref " & _
                    "  where ano = '" & cbo_ano.Text & "' AND mes = '" & cbo_mes.SelectedValue & "' AND tipo ='" & tipo & "'" & _
                    " group by prod_final,descripcion,ano,mes order by prod_final"
        Else
            sql = "select  cod_orden, id_detalle, id_rollo,prod_final,descripcion,peso, peso_real,diferencia,transaccion_entrada, tipo,  ano, mes from JB_v_diferencia_tref where tipo = '" & _
                    tipo & "' AND ano = '" & cbo_ano.Text & "' AND mes = '" & cbo_mes.SelectedValue & "'"
        End If
        dt = objOpsimpesLn.listar_datatable(sql, "PRODUCCION")

        totalizar(dt)
        dtg_consulta.DataSource = dt
        dtg_consulta.Columns("peso").DefaultCellStyle.Format = "N1"
        dtg_consulta.Columns("peso_real").DefaultCellStyle.Format = "N1"
        dtg_consulta.Columns("diferencia").DefaultCellStyle.Format = "N1"
        If chk_consolidar.Checked = True Then
            dtg_consulta.Columns("porc").DefaultCellStyle.Format = "N5"
        End If
        dtg_consulta.Rows(dtg_consulta.Rows.Count - 1).DefaultCellStyle = objOperacionesForm.formatoNegrita(9)
    End Sub

    Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
        dtg_consulta.DataSource = Nothing
        consulta()
    End Sub

    Private Function totalizar(ByVal dt As DataTable)
        Dim sum As Double = 0
        dt.Rows.Add()
        For j = 0 To dt.Columns.Count - 1
            If dt.Columns(j).ColumnName = "peso" Or dt.Columns(j).ColumnName = "peso_real" Or dt.Columns(j).ColumnName = "diferencia" Or dt.Columns(j).ColumnName = "porc" Then
                For i = 0 To dt.Rows.Count - 1
                    If Not IsDBNull(dt.Rows(i).Item(j)) Then
                        sum += dt.Rows(i).Item(j)
                    End If
                Next
                dt.Rows(dt.Rows.Count - 1).Item(j) = sum
                sum = 0
            End If
            If dt.Columns(j).ColumnName = "descripcion" Then
                dt.Rows(dt.Rows.Count - 1).Item(j) = "TOTAL"
            End If
        Next
        Return dt
    End Function

    Private Sub btn_excel_Click(sender As Object, e As EventArgs) Handles btn_excel.Click
        Me.UseWaitCursor = True
        Application.DoEvents()
        objOperacionesForm.exportarExcel(dtg_consulta)
        Me.UseWaitCursor = False
    End Sub
End Class