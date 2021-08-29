Imports logicaNegocios
Imports Microsoft.VisualBasic.PowerPacks.Printing.Compatibility.VB6
Imports System.Drawing.Printing
Public Class Frm_consultar_inventario_fisico
    Private objOperacionesForm As New OperacionesFormularios
    Private objOpSimplsLn As New Op_simpesLn
    Dim carga_comp As Boolean = False
    Dim fila_select As Integer = 0
    Private Sub cargar_consulta()
        Dim tamano_letra As Single = 8.0!
        Dim sql As String = "SELECT e.id,t.nit,t.nombres,e.fecha,e.codigo,e.bodega,e.fecha_terminado " & _
                                "FROM J_inventario_enc e  , CORSAN.dbo.terceros t " & _
                                    "WHERE e.nit = t.nit"
        Dim dt As DataTable = objOpSimplsLn.listar_datatable(sql, "PRODUCCION")
        dtg_consulta.DataSource = dt
        dtg_consulta.Columns("fecha_terminado").DefaultCellStyle.Format = "dd/MM/yyyy H:mm"
        dtg_consulta.Columns("fecha").DefaultCellStyle.Format = "dd/MM/yyyy H:mm"
    End Sub

    Private Sub btn_consultar_Click(sender As Object, e As EventArgs) Handles btn_consultar.Click
        cargar_consulta()
    End Sub
  
    Private Sub soloNumero(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If (Char.IsDigit(e.KeyChar) Or e.KeyChar = ".") Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub Frm_consultar_inventario_fisico_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cbo_fecha_ini.Value = Now.AddDays(-Now.Day + 1)
        cbo_fecha_fin.Value = Now
    End Sub

    Private Sub dtg_consulta_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtg_consulta.CellContentClick
        If e.RowIndex >= 0 Then
            tab_ppal.SelectedTab = tab_detalle
            If dtg_consulta.Columns(e.ColumnIndex).Name = col_ver.Name Then
                Dim tamano_letra As Single = 7.5!
                Dim id As Integer = dtg_consulta.Item("id", e.RowIndex).Value
                Dim sql As String = "SELECT d.codigo,r.descripcion,d.stock,d.fisico ,(d.stock-d.fisico) As diferencia,(r.costo_unitario*(d.stock-d.fisico))  As costo_dif,(r.valor_unitario *(d.stock-d.fisico)) As vr_dif  " & _
                               "FROM J_inventario_det d , CORSAN.dbo.referencias r " & _
                                   "WHERE r.codigo = d.codigo AND d.id = " & id & " " & _
                                       "ORDER BY d.codigo"
                Dim dt As DataTable = objOpSimplsLn.listar_datatable(sql, "PRODUCCION")
                totalizarDt(dt)
                dtg_detalle.DataSource = dt
                dtg_detalle.Columns("codigo").DefaultCellStyle = objOperacionesForm.formatoNegrita(tamano_letra)
                dtg_detalle.Columns("diferencia").DefaultCellStyle = objOperacionesForm.formatoNegrita(tamano_letra)
                dtg_detalle.Columns("diferencia").DefaultCellStyle.Format = "N2"
                dtg_detalle.Columns("fisico").DefaultCellStyle.Format = "N2"
                dtg_detalle.Columns("stock").DefaultCellStyle.Format = "N2"
                dtg_detalle.Columns("costo_dif").DefaultCellStyle.Format = "N0"
                dtg_detalle.Columns("vr_dif").DefaultCellStyle.Format = "N0"
                dtg_detalle.Rows(dtg_detalle.Rows.Count - 1).DefaultCellStyle = objOperacionesForm.formatoNegrita(tamano_letra)
                For i = 0 To dtg_detalle.Rows.Count - 1
                    Select Case dtg_detalle.Item("diferencia", i).Value
                        Case Is < 0
                            dtg_detalle.Item("diferencia", i).Style.BackColor = Color.Red
                        Case Is > 0
                            dtg_detalle.Item("diferencia", i).Style.BackColor = Color.Yellow
                    End Select
                Next
            End If
            fila_select = e.RowIndex
        End If
    End Sub
    Private Function totalizarDt(ByRef dt As DataTable) As DataTable
        Dim sum As Double = 0
        dt.Rows.Add()
        For j = 0 To dt.Columns.Count - 1
            If (dt.Columns(j).ColumnName = "costo_dif" Or dt.Columns(j).ColumnName = "vr_dif" Or dt.Columns(j).ColumnName = "stock" Or dt.Columns(j).ColumnName = "fisico" Or dt.Columns(j).ColumnName = "diferencia") Then
                For i = 0 To dt.Rows.Count - 2
                    If Not IsDBNull(dt.Rows(i).Item(j)) Then
                        sum += dt.Rows(i).Item(j)
                    End If
                Next
                dt.Rows(dt.Rows.Count - 1).Item(j) = sum
                sum = 0
            End If
        Next
        Return dt
    End Function
    Private Sub btn_excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_excel.Click
        objOperacionesForm.ExportarDatosExcel(dtg_detalle, "Tipo :" & dtg_consulta.Item("codigo", fila_select).Value & " Fecha corte: " & dtg_consulta.Item("fecha", fila_select).Value)
    End Sub
End Class