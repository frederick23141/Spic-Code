Imports logicaNegocios
Imports entidadNegocios
Public Class frm_vista_personal_activo
    Private objOpSimplesLn As New Op_simpesLn
    Private objOperacionesForm As OperacionesFormularios = New OperacionesFormularios

    Private Sub consultar_datos()
        Dim tamano_letra As Single = 9.0
        Dim sql As String = "SELECT c.centro,v.descripcion " & _
                                " FROM jjv_consol_empleados_activos_retirados c, centros v " & _
                                    " WHERE c.centro = v.centro GROUP BY c.centro,v.descripcion ORDER BY c.centro"
        Dim dt As DataTable = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        consultar(dt)
        totalizar_dt(dt)
        dtg_consulta.DataSource = dt
        formato(dt)
        dtg_consulta.Rows(dtg_consulta.Rows.Count - 1).DefaultCellStyle = objOperacionesForm.formatoNegrita(tamano_letra)
    End Sub
    Private Function formato(ByVal dt As DataTable)
        For i = 0 To dtg_consulta.ColumnCount - 1
            Dim mes As String = dt.Columns(i).ColumnName
            If mes.Trim Like "enero*" Or mes.Trim Like "febrero*" Or mes.Trim Like "marzo*" Or mes.Trim Like "abril*" Or mes.Trim Like "mayo*" Or mes.Trim Like "junio*" Or mes.Trim Like "julio*" Or mes.Trim Like "agosto*" Or mes.Trim Like "septiembre*" Or mes.Trim Like "octubre*" Or mes.Trim Like "noviembre*" Or mes.Trim Like "diciembre*" Then
                dtg_consulta.Columns(mes.Trim).DefaultCellStyle.Format = "N0"
                dtg_consulta.Columns(mes.Trim).DefaultCellStyle.NullValue = "0"
            End If
        Next
        Return dt
    End Function
    Private Sub frm_vista_personal_activo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For i = Now.Year - 3 To Now.Year + 3
            cbo_an_f.Items.Add(i)
            cbo_an_in.Items.Add(i)
        Next
        cbo_an_f.Text = Now.Year
        cbo_an_in.Text = Now.Year
    End Sub
    Private Function totalizar_dt(ByVal dt As DataTable)
        Dim sum As Double = 0
        dt.Rows.Add()
        For j = 0 To dt.Columns.Count - 1
            Dim mes As String = dt.Columns(j).ColumnName
            If mes.Trim Like "enero*" Or mes.Trim Like "febrero*" Or mes.Trim Like "marzo*" Or mes.Trim Like "abril*" Or mes.Trim Like "mayo*" Or mes.Trim Like "junio*" Or mes.Trim Like "julio*" Or mes.Trim Like "agosto*" Or mes.Trim Like "septiembre*" Or mes.Trim Like "octubre*" Or mes.Trim Like "noviembre*" Or mes.Trim Like "diciembre*" Then
                For i = 0 To dt.Rows.Count - 1
                    If Not IsDBNull(dt.Rows(i).Item(j)) Then
                        sum += dt.Rows(i).Item(j)
                    End If
                Next
                dt.Rows(dt.Rows.Count - 1).Item(j) = sum
                sum = 0
            End If
            If dt.Columns(j).ColumnName = "descripcion" Then
                For i = 0 To dt.Rows.Count - 1
                    If IsDBNull(dt.Rows(i).Item(j)) Then
                        dt.Rows(dt.Rows.Count - 1).Item(j) = "TOTAL"
                    End If
                Next
            End If
        Next
        Return dt
    End Function

    Private Function consultar(ByVal dt As DataTable)
        Dim m As Integer = 1
        Dim x As Integer = cbo_an_in.Text
        Dim y As Integer = cbo_an_f.Text
        Dim dt2 As New DataTable
        Dim sql As String = ""
        For i = x To y
            Dim mes As String = consultar_mes(m)
            dt.Columns.Add(mes & "_" & i, GetType(Integer))
            dt2 = New DataTable
            sql = "SELECT CENTRO,COUNT(NIT) AS mes " & _
                        " FROM jjv_consol_empleados_activos_retirados " & _
                            " WHERE ANO = " & i & " AND MES = " & m & _
                            " GROUP BY ANO,MES,CENTRO"
            dt2 = objOpSimplesLn.listar_datatable(sql, "CORSAN")
            Dim das As String = mes & "_" & i
            For w = 0 To dt2.Rows.Count - 1
                For j = 0 To dt.Rows.Count - 1
                    Dim var1 As String = ""
                    Dim var2 As String = ""
                    If IsDBNull(dt.Rows(j).Item("centro")) Then
                        var2 = ""
                    Else
                        var2 = dt.Rows(j).Item("centro")
                    End If
                    If IsDBNull(dt2.Rows(w).Item("CENTRO")) Then
                        var1 = ""
                    Else
                        var1 = dt2.Rows(w).Item("CENTRO")
                    End If

                    If var1.Trim = var2.Trim Then
                        dt.Rows(j).Item(das) = dt2.Rows(w).Item("mes")
                    End If
                Next
            Next
            m += 1
            While m <> 1
                mes = consultar_mes(m)
                dt.Columns.Add(mes & "_" & i, GetType(Integer))
                dt2 = New DataTable
                sql = "SELECT CENTRO,COUNT(NIT) AS mes " & _
                        " FROM jjv_consol_empleados_activos_retirados " & _
                        " WHERE ANO = " & i & " AND MES = " & m & _
                        " GROUP BY ANO,MES,CENTRO"
                dt2 = objOpSimplesLn.listar_datatable(sql, "CORSAN")
                das = mes & "_" & i
                For w = 0 To dt2.Rows.Count - 1
                    For j = 0 To dt.Rows.Count - 1
                        Dim var1 As String = ""
                        Dim var2 As String = ""
                        If IsDBNull(dt.Rows(j).Item("centro")) Then
                            var2 = ""
                        Else
                            var2 = dt.Rows(j).Item("centro")
                        End If
                        If IsDBNull(dt2.Rows(w).Item("CENTRO")) Then
                            var1 = ""
                        Else
                            var1 = dt2.Rows(w).Item("CENTRO")
                        End If

                        If var1.Trim = var2.Trim Then
                            dt.Rows(j).Item(das) = dt2.Rows(w).Item("mes")
                        End If
                    Next
                Next
                m += 1
                If m > 12 Then
                    m = 1
                End If
            End While
            m = 1
        Next
        Return dt
    End Function
    Private Function consultar_mes(ByVal m As Integer)
        Dim mes As String = ""
        If m = 1 Then
            mes = "enero"
        ElseIf m = 2 Then
            mes = "febrero"
        ElseIf m = 3 Then
            mes = "marzo"
        ElseIf m = 4 Then
            mes = "abril"
        ElseIf m = 5 Then
            mes = "mayo"
        ElseIf m = 6 Then
            mes = "junio"
        ElseIf m = 7 Then
            mes = "julio"
        ElseIf m = 8 Then
            mes = "agosto"
        ElseIf m = 9 Then
            mes = "septiembre"
        ElseIf m = 10 Then
            mes = "octubre"
        ElseIf m = 11 Then
            mes = "noviembre"
        ElseIf m = 12 Then
            mes = "diciembre"
        End If
        Return mes
    End Function

    Private Sub btn_consultar_Click(sender As Object, e As EventArgs) Handles btn_consultar.Click
        Dim ano_in As Integer = cbo_an_in.Text
        Dim ano_fin As Integer = cbo_an_f.Text
        dtg_consulta.DataSource = Nothing
        If ano_in <= ano_fin Then
            consultar_datos()
        Else
            MessageBox.Show("la fecha inicial no debe ser mayor a la final.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub btn_ex_Click(sender As Object, e As EventArgs) Handles btn_ex.Click
        Me.UseWaitCursor = True
        Application.DoEvents()
        objOperacionesForm.exportarExcel(dtg_consulta)
        Me.UseWaitCursor = False
    End Sub
End Class