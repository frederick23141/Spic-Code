Imports logicaNegocios
Public Class Frm_Trazabilidad_clientes_atendidos
    Dim dtPpal As New DataTable
    Private objOpSimplesLn As New Op_simpesLn
    Private cargaComp As Boolean = False
    Private objOperacionesForm As New OperacionesFormularios

    Private Sub Frm_Trazabilidad_clientes_atendidos_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        cbo_fecha_ini.Value = Now.AddYears(-1)
        cbo_fecha_fin.Value = Now
    End Sub

    Private Sub btn_actualizar_Click(sender As System.Object, e As System.EventArgs) Handles btn_actualizar.Click
        imgProcesar.Visible = True
        Application.DoEvents()
        cargar_consulta()
        imgProcesar.Visible = False
    End Sub
    Private Sub cargar_consulta()
        dtPpal = New DataTable
        Dim dt_vendedores As New DataTable
        Dim dt_datos_meses As New DataTable
        Dim fecIni As String = objOpSimplesLn.cambiarFormatoFecha(cbo_fecha_ini.Value)
        Dim fecfin As String = objOpSimplesLn.cambiarFormatoFecha(cbo_fecha_fin.Value)

        Dim nom_col As String = ""
        Dim mes_ant As Integer = 0
        Dim ano_ant As Integer = 0
        Dim nombMes As String = ""
        Dim primero As Boolean = True
        Dim sql_ppal As String = "SELECT vendedor ,MONTH (fec )As mes,YEAR (fec )As ano,COUNT ( distinct nit)cantidad " & _
                        "FROM Jjv_V_vtas_vend_cliente_ref " & _
                  "WHERE vendedor >= 1001 and vendedor <= 1099 AND  fec >= '" & fecIni & "' AND fec <= '" & fecfin & "' " & _
                   "GROUP BY vendedor ,MONTH (fec ),YEAR (fec) " & _
                    "ORDER BY YEAR (fec), MONTH (fec )"

        Dim sql_vendedores As String = "SELECT vendedor " & _
                        "FROM Jjv_V_vtas_vend_cliente_ref " & _
                  "WHERE vendedor >= 1001 and vendedor <= 1099 AND  fec >= '" & fecIni & "' AND fec <= '" & fecfin & "' " & _
                   "GROUP BY vendedor  " & _
                    "ORDER BY vendedor"
        dt_datos_meses = objOpSimplesLn.listar_datatable(sql_ppal, "CORSAN")
        dtPpal.Columns.Add("Vend")
        dt_vendedores = objOpSimplesLn.listar_datatable(sql_vendedores, "CORSAN")
        For i = 0 To dt_vendedores.Rows.Count - 1
            dtPpal.Rows.Add()
            dtPpal.Rows(dtPpal.Rows.Count - 1).Item("Vend") = dt_vendedores.Rows(i).Item("vendedor")
        Next
        dtPpal.Rows.Add()
        dtPpal.Rows(dtPpal.Rows.Count - 1).Item("Vend") = "mes-ano"
        For i = 0 To dt_datos_meses.Rows.Count - 1
            nombMes = MonthName(dt_datos_meses.Rows(i).Item("mes"), True).ToUpper & "-" & dt_datos_meses.Rows(i).Item("ano")
            If (primero) Then
                mes_ant = dt_datos_meses.Rows(i).Item("mes")
                ano_ant = dt_datos_meses.Rows(i).Item("ano")
                dtPpal.Columns.Add(nombMes)
                dtPpal.Rows(numFila("mes-ano")).Item(nombMes) = dt_datos_meses.Rows(i).Item("mes") & "-" & dt_datos_meses.Rows(i).Item("ano")
                primero = False
            End If
            If (mes_ant <> dt_datos_meses.Rows(i).Item("mes") Or ano_ant <> dt_datos_meses.Rows(i).Item("ano")) Then
                dtPpal.Columns.Add(nombMes)
                dtPpal.Rows(numFila("mes-ano")).Item(nombMes) = dt_datos_meses.Rows(i).Item("mes") & "-" & dt_datos_meses.Rows(i).Item("ano")
            End If
            dtPpal.Rows(numFila(dt_datos_meses.Rows(i).Item("vendedor"))).Item(nombMes) = dt_datos_meses.Rows(i).Item("cantidad")

            mes_ant = dt_datos_meses.Rows(i).Item("mes")
            ano_ant = dt_datos_meses.Rows(i).Item("ano")
        Next
        dtPpal.Rows.Add()
        dtPpal.Rows(dtPpal.Rows.Count - 1).Item("Vend") = "TOTAL"
        totalizarDt()
        dtg_consulta.DataSource = dtPpal
        dtg_consulta.Rows(numFila("mes-ano")).Visible = False
        dtg_consulta.Rows(dtPpal.Rows.Count - 1).DefaultCellStyle.BackColor = Color.Red
        dtg_consulta.Rows(dtPpal.Rows.Count - 1).DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        dtg_consulta.Columns(0).DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.25!, System.Drawing.FontStyle.Bold)
        dtg_consulta.Columns(0).Frozen = True
        cargaComp = True
    End Sub
    Private Sub totalizarDt()
        Dim sum As Double = 0
        For j = 1 To dtPpal.Columns.Count - 1
            For i = 0 To dtPpal.Rows.Count - 1
                If Not IsDBNull(dtPpal.Rows(i).Item(j)) Then
                    If IsNumeric(dtPpal.Rows(i).Item(j)) Then
                        sum += dtPpal.Rows(i).Item(j)
                    End If
                End If
            Next
            dtPpal.Rows(dtPpal.Rows.Count - 1).Item(j) = sum
            sum = 0
        Next
    End Sub
    Private Function numFila(ByVal vendedor As String) As Integer
        For i = 0 To dtPpal.Rows.Count - 1
            If (dtPpal.Rows(i).Item("Vend") = vendedor) Then
                Return i
            End If
        Next
        Return 0
    End Function
    Private Sub detalle_clientes(ByVal vendedor As String, ByVal mes As Integer, ByVal ano As Integer)
        Dim where_vend As String = ""
        If (vendedor <> "TOTAL") Then
            where_vend = " vendedor = " & vendedor
        Else
            where_vend = "vendedor >= 1001 and vendedor <= 1099"
        End If
        Dim sql As String = "SELECT vendedor,nit,nombres,ciudad,condicion,SUM(valor_unitario * CANTIDAD )As vr_total,SUM(kilos )As Kilos,SUM(costo_unitario  * CANTIDAD )As Costo_total " & _
                                            "FROM Jjv_V_vtas_vend_cliente_ref  " & _
                                            "WHERE " & where_vend & " And Year(fec) = " & ano & "  AND MONTH (fec) = " & mes & " " & _
                                       "GROUP BY vendedor,nit,nombres,ciudad,condicion "
        Dim dt As DataTable = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        Dim sum As Double = 0
        dt.Rows.Add()
        dt.Rows(dt.Rows.Count - 1).Item("nombres") = "TOTAL"
        For j = 0 To dt.Columns.Count - 1
            If (dt.Columns(j).ColumnName = "vr_total" Or dt.Columns(j).ColumnName = "Costo_total" Or dt.Columns(j).ColumnName = "Kilos") Then
                For i = 0 To dt.Rows.Count - 2
                    sum += dt.Rows(i).Item(j)
                Next
                dt.Rows(dt.Rows.Count - 1).Item(j) = sum
                sum = 0
            End If
        Next
       
        dtgResultClient.DataSource = dt
        dtgResultClient.Rows(dtgResultClient.Rows.Count - 1).DefaultCellStyle.BackColor = Color.Red
        dtgResultClient.Rows(dtgResultClient.Rows.Count - 1).DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
    End Sub

    Private Sub itemDetalle_Click(sender As System.Object, e As System.EventArgs) Handles itemDetalle.Click
        Dim vendedor As String = dtg_consulta("Vend", dtg_consulta.CurrentCell.RowIndex).Value
        Dim cad_mes_ano As String = dtg_consulta(dtg_consulta.CurrentCell.ColumnIndex, numFila("mes-ano")).Value
        Dim ano As String = ""
        Dim mes As String = ""
        Dim sw As Boolean = False
        For i = 0 To cad_mes_ano.Length - 1
            If (cad_mes_ano(i) <> "-" And sw = False) Then
                mes &= cad_mes_ano(i)
            Else
                sw = True
                If cad_mes_ano(i) <> "-" Then
                    ano &= cad_mes_ano(i)
                End If
            End If

        Next
        detalle_clientes(vendedor, mes, ano)
    End Sub
    Private Sub dtg_consulta_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dtg_consulta.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            With (Me.dtg_consulta)
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                End If
            End With
        End If
    End Sub
End Class