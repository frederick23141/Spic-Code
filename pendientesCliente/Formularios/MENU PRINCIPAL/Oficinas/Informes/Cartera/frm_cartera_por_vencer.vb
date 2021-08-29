Imports entidadNegocios
Imports logicaNegocios
Public Class frm_cartera_por_vencer
    Dim mes As Integer = 0
    Dim ano As Integer = 0
    Dim usuario_vendedor As Integer
    Dim permiso As String
    Private objUsuarioEn As New UsuarioEn
    Private objIngProdLn As New Ing_prodLn
    Private objOpSimplesLn As New Op_simpesLn
    Private objOperacionesForm As New OperacionesFormularios
    Dim tam As Integer = 0
    Private nom_modulo As String = ""
    Private Sub frm_cartera_por_vencer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenar_Cbo()
        Me.CenterToScreen()
        dtg_cartera_por_v.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
    End Sub
    Public Sub llenar_Cbo()
        'llenar combos de años y meses
        cboAño.Items.Add(Now.Year)
        cboAño.Items.Add(Now.Year - 1)
        cboAño.Items.Add(Now.Year - 2)
        cboAño.Items.Add(Now.Year - 3)
        cboAño.Items.Add(Now.Year - 4)
        cboAño.SelectedIndex = 0
        cboMes.SelectedIndex = Now.Month - 1

        Dim sql As String = "SELECT vendedor,nombre_vendedor" &
                         " From v_vendedores" &
                             " Where bloqueo = 0 And vendedor >= 1001 And vendedor <= 1099 Order By vendedor"
        Dim dt2 As New DataTable
        Dim row As DataRow
        dt2 = New DataTable
        dt2 = objIngProdLn.listar_datatable(sql, "CORSAN")
        row = dt2.NewRow
        row("vendedor") = 0
        row("nombre_vendedor") = "Seleccione"
        dt2.Rows.Add(row)
        cbo_vendedor.DataSource = dt2
        cbo_vendedor.ValueMember = "vendedor"
        cbo_vendedor.DisplayMember = "nombre_vendedor"
        cbo_vendedor.Text = "vendedor"
        cbo_vendedor.SelectedValue = 0
    End Sub
    Private Sub btn_consultar_Click(sender As Object, e As EventArgs) Handles btn_consultar.Click
        imgProcesar.Visible = True
        Application.DoEvents()
        mes = cboMes.SelectedIndex + 1
        ano = cboAño.Text
        listar_Cartera()
        imgProcesar.Visible = False
    End Sub


    Private Sub listar_Cartera()
        Dim listConsult As New List(Of Object)
        Dim sql As String
        Dim dt As New DataTable
        Dim i As Integer = 0
        Dim vendedor As Integer


        If cbo_vendedor.Text = "Seleccione" Then
            sql = "select numero,tipo,nit,nombres,vendedor,fecha,vencimiento as fecha_vencimiento,DATEADD(day,lead_time, vencimiento) as fecha_vencimiento_dias,notas,valor_total from Bi_cartera_saldo_leadtime where   Sin_Vencer > 0  and dias_vencido < 0  and year(DATEADD(day,lead_time, vencimiento))=" & cboAño.SelectedItem & " and month(DATEADD(day,lead_time, vencimiento))=" & cboMes.SelectedIndex + 1 & " order by numero"
        Else
            vendedor = cbo_vendedor.SelectedValue
            sql = "select numero,tipo,nit,nombres,vendedor,fecha,vencimiento as fecha_vencimiento,DATEADD(day,lead_time, vencimiento) as fecha_vencimiento_dias,notas,valor_total from Bi_cartera_saldo_leadtime where   Sin_Vencer > 0  and dias_vencido < 0 and vendedor=" & vendedor & " and year(DATEADD(day,lead_time, vencimiento))=" & cboAño.SelectedItem & " and month(DATEADD(day,lead_time, vencimiento))=" & cboMes.SelectedIndex + 1 & " order by numero"
        End If
        If ch_unoatrien.Checked = True Then
            If cbo_vendedor.Text = "Seleccione" Then
                sql = "select numero,tipo,nit,nombres,vendedor,fecha,vencimiento as fecha_vencimiento,DATEADD(day,lead_time, vencimiento) as fecha_vencimiento_dias,notas,valor_total from Bi_cartera_saldo_leadtime where de_1_a_30 > 0  order by numero"
            Else
                sql = "select numero,tipo,nit,nombres,vendedor,fecha,vencimiento as fecha_vencimiento,DATEADD(day,lead_time, vencimiento) as fecha_vencimiento_dias,notas,valor_total from Bi_cartera_saldo_leadtime where de_1_a_30 > 0 and vendedor=" & vendedor & " order by numero"
            End If
        End If
        If chk_61.Checked = True Then
            If cbo_vendedor.Text = "Seleccione" Then
                sql = "select numero,tipo,nit,nombres,vendedor,fecha,vencimiento as fecha_vencimiento,DATEADD(day,lead_time, vencimiento) as fecha_vencimiento_dias,notas,valor_total from Bi_cartera_saldo_leadtime where de_31_a_60 > 0 or de_61_a_90>0 or de_91_a_120 >0 or Mas_de_120>0 order by numero"
            Else
                sql = "select numero,tipo,nit,nombres,vendedor,fecha,vencimiento as fecha_vencimiento,DATEADD(day,lead_time, vencimiento) as fecha_vencimiento_dias,notas,valor_total from Bi_cartera_saldo_leadtime where (de_31_a_60 > 0 or de_61_a_90>0 or de_91_a_120 >0 or Mas_de_120>0) AND vendedor=" & vendedor & " order by numero"
            End If
        End If
            dt = objOpSimplesLn.listar_datatable(sql, "CORSAN")
            dtg_cartera_por_v.DataSource = dt
            dtg_cartera_por_v.DataSource = totalizar_cartera()
            With dtg_cartera_por_v
                .Columns("valor_total").DefaultCellStyle.Format = "###,###"
            End With
            pintartotal()
    End Sub
    Private Function totalizar_cartera()
        Dim valor As Double = 0
        Dim indice As Integer = 0
        Dim dt As DataTable = DirectCast(dtg_cartera_por_v.DataSource, DataTable)
        For Each row As DataRow In dt.Rows
            If row.Item("valor_total") >= 0 Then
                valor += row.Item("valor_total")
            End If
            If indice = (dt.Rows.Count - 1) Then
                dt.Rows.Add()
                dt.Rows(dt.Rows.Count - 1).Item("notas") = "TOTAL"
                dt.Rows(dt.Rows.Count - 1).Item("valor_total") = valor
                Exit For
            End If
            indice += 1
        Next
        Return dt
    End Function
    Public Sub pintartotal()
        If dtg_cartera_por_v.Rows.Count > 0 Then
            dtg_cartera_por_v.Rows(dtg_cartera_por_v.Rows.Count - 1).DefaultCellStyle.BackColor = Color.Salmon
            dtg_cartera_por_v.Rows(dtg_cartera_por_v.Rows.Count - 1).DefaultCellStyle.Font = New Font(dtg_cartera_por_v.CurrentCell.InheritedStyle.Font, FontStyle.Bold)
        End If
    End Sub
    Private Sub btnexcel_Click(sender As Object, e As EventArgs) Handles btnexcel.Click
        If dtg_cartera_por_v.RowCount > 0 Then
           objOperacionesForm.ExportarDatosExcel(dtg_cartera_por_v, "Vencimiento de cartera")
        Else
            MessageBox.Show("No hay información que exportar", "Exportar a excel", MessageBoxButtons.OK)
        End If
    End Sub
    Private Sub ch_unoatrien_CheckedChanged(sender As Object, e As EventArgs) Handles ch_unoatrien.CheckedChanged
        If ch_unoatrien.Checked = True Then
            chk_61.Checked = False
        Else
            chk_61.Checked = True
        End If
    End Sub

    Private Sub chk_61_CheckedChanged(sender As Object, e As EventArgs) Handles chk_61.CheckedChanged
        If chk_61.Checked = True Then
            ch_unoatrien.Checked = False
        Else
            ch_unoatrien.Checked = True
        End If
    End Sub
End Class