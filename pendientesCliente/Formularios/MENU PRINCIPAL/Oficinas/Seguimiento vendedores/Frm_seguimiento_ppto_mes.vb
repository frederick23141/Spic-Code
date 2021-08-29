Imports logicaNegocios
Imports entidadNegocios
Public Class Frm_seguimiento_ppto_mes
    Private objUsuarioLn As New UsuarioLn
    Private objOpSimplesLn As New Op_simpesLn
    Private objIngresoProdLn As New Ing_prodLn
    Private objOperacionesForm As OperacionesFormularios = New OperacionesFormularios
    Private carga_comp As Boolean = False
    Private objUsuarioEn As New UsuarioEn
    Dim vendedores_gral As String
    Public Sub Main(ByVal objUsuarioEn As UsuarioEn)
        Me.objUsuarioEn = objUsuarioEn
        Me.vendedores_gral = objUsuarioLn.coordinadorVend(objUsuarioEn.usuario)
        cboFechaIni.Value = Now.AddMonths(-Now.Month + 1)
        cboFechaIni.Value = cboFechaIni.Value.AddDays(-Now.Day + 1)
        cboFechaFin.Value = Now.AddDays(-Now.Day + 1)
        cargar_vendedores()
    End Sub
  
    Private Sub cargar_vendedores()
        Dim whereVend As String = ""
        If (vendedores_gral <> "") Then
            whereVend = "AND vendedor in(" & vendedores_gral & ")"
        Else
            whereVend = "AND vendedor >= 1001 and vendedor <= 1099"
        End If
        Dim sql_vendedores As String = "SELECT vendedor " & _
                                      "FROM Jjv_V_vtas_vend_cliente_ref  " & _
                                          "WHERE YEAR(fec) >= 2010 " & whereVend & " " & _
                                          "GROUP BY vendedor"
        Dim dt_vendedores As New DataTable
        dt_vendedores = objOpSimplesLn.listar_datatable(sql_vendedores, "CORSAN")
        For i = 0 To dt_vendedores.Rows.Count - 1
            If (i = 0) Then
                ChkListvendedores.Items.Add("TODOS")
            End If
            ChkListvendedores.Items.Add(dt_vendedores.Rows(i).Item("vendedor"))
        Next
    End Sub
    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        FrmPrincipal.Show()
        Me.Close()
        FrmPrincipal.Activate()
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        FrmLogin.Show()
        FrmPrincipal.Close()
        Me.Close()
    End Sub

    Private Sub cargarConsulta()
        Dim fecIni As String = objOpSimplesLn.cambiarFormatoFecha(cboFechaIni.Value)
        Dim fecFin As String = objOpSimplesLn.cambiarFormatoFecha(cboFechaFin.Value)
        Dim sql As String = ""
        Dim whereSql As String = "WHERE fecha >= '" & fecIni & "' AND fecha<= '" & fecFin & "' "
        Dim orderSql As String = "ORDER BY fecha "
        Dim groupSql As String = ""
        Dim dt As New DataTable
        Dim vendedores As String = ""
        Dim whereVend As String = ""
        Dim whereVendNit As String = ""


        For i = 0 To ChkListvendedores.CheckedItems.Count - 1
            If (ChkListvendedores.CheckedItems(i).ToString = "TODOS") Then
                i = ChkListvendedores.CheckedItems.Count - 1
                vendedores = vendedores_gral
            Else
                If (i = 0) Then
                    vendedores &= "(" & ChkListvendedores.CheckedItems(i).ToString & ""
                Else
                    vendedores &= "," & ChkListvendedores.CheckedItems(i).ToString & ""
                End If
                If (i = ChkListvendedores.CheckedItems.Count - 1) Then
                    vendedores &= ") "
                End If
            End If
        Next
        If (vendedores = "") Then
            whereVend = ""
        Else
            whereVend = " AND vendedor IN  " & vendedores & " "
            whereVendNit = " And Nit IN " & vendedores & " "
        End If

        Dim sql_vtas As String = "SELECT v.vendedor, MONTH(v.fec) AS mes,CAST(YEAR(v.fec) AS varchar(25))+ '-' + CAST(MONTH(v.fec) AS varchar(25))As mes_ ,YEAR(v.fec) AS ano, SUM (v.Vr_total)As ventas " & _
                                 "FROM Jjv_V_vtas_vend_cliente_ref v  " & _
                                  "WHERE v.fec>= '" & fecIni & "' AND v.fec<= '" & fecFin & "' " & whereVend & " " & _
                                   "GROUP BY v.vendedor,MONTH (v.fec),YEAR (v.fec) " & _
                                    "ORDER BY YEAR(v.fec), MONTH(v.fec) "
        Dim sql_rec As String = "SELECT v.vendedor, MONTH(v.fecha ) AS mes ,YEAR(v.fecha) AS ano, SUM (v.Total_rec )As recaudos,CAST(YEAR(v.fecha) AS varchar(25))+ '-' + CAST(MONTH(v.fecha) AS varchar(25))As mes_ " & _
                                 "FROM Jjv_Recaudos_consol v   " & _
                                    "WHERE(v.fecha >= '" & fecIni & "' AND v.fecha <= '" & fecFin & "' " & whereVend & "  ) " & _
                                        "GROUP BY v.vendedor,MONTH (v.fecha),YEAR (v.fecha)  " & _
                                        "ORDER BY YEAR(v.fecha), MONTH(v.fecha)"
        Dim sql_ppto_rec As String = "SELECT Nit As vendedor , SUM(Ppto_total )As Vr_total, mes ,(año)As ano " & _
                                            "FROM Jjv_ppto_vtas_recaudos_consol " & _
                                        "WHERE((año >= " & cboFechaIni.Value.Year & " AND año <= " & cboFechaFin.Value.Year & " )" & whereVendNit & ") " & _
                                                "GROUP BY  Nit,mes,año " & _
                                                    "ORDER BY año,mes"
        Dim sql_ppto_vtas As String = "SELECT vendedor , SUM(Vr_total)As Vr_total,MONTH (Fecha_ppto )  As mes ,YEAR (Fecha_ppto )As ano " & _
                                    "FROM Jjv_Ppto_mes  " & _
                                        "WHERE Fecha_ppto>='" & fecIni & "' AND Fecha_ppto<='" & fecFin & "' " & whereVend & "  " & _
                                             "GROUP BY  vendedor,MONTH (Fecha_ppto ),YEAR (Fecha_ppto )  " & _
                                                "ORDER BY MONTH (Fecha_ppto ),YEAR (Fecha_ppto ) "

        Dim dt_efic As DataTable = objOpSimplesLn.listar_datatable(sql_vtas, "CORSAN")
        Dim dt_ppto_vtas As DataTable = objOpSimplesLn.listar_datatable(sql_ppto_vtas, "CORSAN")
        Dim dt_rec As DataTable = objOpSimplesLn.listar_datatable(sql_rec, "CORSAN")
        Dim dt_ppto_rec As DataTable = objOpSimplesLn.listar_datatable(sql_ppto_rec, "CORSAN")
        dt_efic.Columns.Add("ppto_vtas", GetType(Double))
        dt_efic.Columns.Add("efic_vtas", GetType(Double))
        dt_efic.Columns.Add("recaudos", GetType(Double))
        dt_efic.Columns.Add("ppto_rec", GetType(Double))
        dt_efic.Columns.Add("efic_rec", GetType(Double))

        For i = 0 To dt_efic.Rows.Count - 1
            For j = 0 To dt_ppto_vtas.Rows.Count - 1
                If (dt_efic.Rows(i).Item("mes") = dt_ppto_vtas.Rows(j).Item("mes") And dt_efic.Rows(i).Item("ano") = dt_ppto_vtas.Rows(j).Item("ano") And dt_efic.Rows(i).Item("vendedor") = dt_ppto_vtas.Rows(j).Item("vendedor")) Then
                    dt_efic.Rows(i).Item("ppto_vtas") = dt_ppto_vtas.Rows(j).Item("Vr_total")
                    If Not IsDBNull(dt_ppto_vtas.Rows(j).Item("Vr_total")) Then
                        dt_efic.Rows(i).Item("efic_vtas") = (dt_efic.Rows(i).Item("ventas") / dt_ppto_vtas.Rows(j).Item("Vr_total")) * 100
                    End If
                    j = dt_ppto_vtas.Rows.Count - 1
                End If
            Next
            For k = 0 To dt_rec.Rows.Count - 1
                If (dt_efic.Rows(i).Item("mes") = dt_rec.Rows(k).Item("mes") And dt_efic.Rows(i).Item("ano") = dt_rec.Rows(k).Item("ano") And dt_efic.Rows(i).Item("vendedor") = dt_rec.Rows(k).Item("vendedor")) Then
                    dt_efic.Rows(i).Item("recaudos") = dt_rec.Rows(k).Item("recaudos")
                    k = dt_rec.Rows.Count - 1
                End If
            Next
            For z = 0 To dt_ppto_rec.Rows.Count - 1
                If Not IsDBNull(dt_ppto_rec.Rows(z).Item("vendedor")) Then
                    If (dt_efic.Rows(i).Item("mes") = dt_ppto_rec.Rows(z).Item("mes") And dt_efic.Rows(i).Item("ano") = dt_ppto_rec.Rows(z).Item("ano") And dt_efic.Rows(i).Item("vendedor") = dt_ppto_rec.Rows(z).Item("vendedor")) Then
                        dt_efic.Rows(i).Item("ppto_rec") = dt_ppto_rec.Rows(z).Item("Vr_total")
                        If Not IsDBNull(dt_ppto_rec.Rows(z).Item("Vr_total")) Then
                            If Not IsDBNull(dt_efic.Rows(i).Item("recaudos")) Then
                                dt_efic.Rows(i).Item("efic_rec") = (dt_efic.Rows(i).Item("recaudos") / dt_ppto_rec.Rows(z).Item("Vr_total")) * 100
                            End If
                        End If
                        z = dt_ppto_rec.Rows.Count - 1
                    End If
                End If
            Next
        Next


        For i = 0 To dt_ppto_vtas.Rows.Count - 1
            For j = 0 To dt_efic.Rows.Count - 1
                If (dt_efic.Rows(j).Item("mes") = dt_ppto_vtas.Rows(i).Item("mes") And dt_efic.Rows(j).Item("ano") = dt_ppto_vtas.Rows(i).Item("ano") And dt_efic.Rows(j).Item("vendedor") = dt_ppto_vtas.Rows(i).Item("vendedor")) Then
                    dt_efic.Rows(j).Item("ppto_vtas") = dt_ppto_vtas.Rows(i).Item("Vr_total")
                    If Not IsDBNull(dt_ppto_vtas.Rows(i).Item("Vr_total")) Then
                        dt_efic.Rows(j).Item("efic_vtas") = (dt_efic.Rows(j).Item("ventas") / dt_ppto_vtas.Rows(i).Item("Vr_total")) * 100
                    End If

                End If
            Next

        Next
        If (dt_ppto_vtas.Rows.Count - 1 <> 0) Then
            dt_efic.Rows.Add()
            Dim sum_vtas As Double = 0
            Dim sum_ppto_vtas As Double = 0
            Dim sum_rec As Double = 0
            Dim sum_ppto_rec As Double = 0
            For i = 0 To dt_efic.Rows.Count - 1
                If Not IsDBNull(dt_efic.Rows(i).Item("ppto_vtas")) Then
                    sum_ppto_vtas += dt_efic.Rows(i).Item("ppto_vtas")
                End If
                If Not IsDBNull(dt_efic.Rows(i).Item("ventas")) Then
                    sum_vtas += dt_efic.Rows(i).Item("ventas")
                End If
                If Not IsDBNull(dt_efic.Rows(i).Item("ppto_rec")) Then
                    sum_ppto_rec += dt_efic.Rows(i).Item("ppto_rec")
                End If
                If Not IsDBNull(dt_efic.Rows(i).Item("recaudos")) Then
                    sum_rec += dt_efic.Rows(i).Item("recaudos")
                End If
            Next
           
            dt_efic.Rows(dt_efic.Rows.Count - 1).Item("ppto_vtas") = sum_ppto_vtas
            dt_efic.Rows(dt_efic.Rows.Count - 1).Item("ventas") = sum_vtas
            dt_efic.Rows(dt_efic.Rows.Count - 1).Item("ppto_rec") = sum_ppto_rec
            dt_efic.Rows(dt_efic.Rows.Count - 1).Item("recaudos") = sum_rec
            dt_efic.Rows(dt_efic.Rows.Count - 1).Item("efic_vtas") = (sum_vtas / sum_ppto_vtas) * 100
            dt_efic.Rows(dt_efic.Rows.Count - 1).Item("efic_rec") = (sum_rec / sum_ppto_rec) * 100
        End If
        dtgConsulta.DataSource = dt_efic
        dtgConsulta.Rows(dtgConsulta.Rows.Count - 1).DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!, System.Drawing.FontStyle.Bold)
        dtgConsulta.Columns("efic_vtas").DefaultCellStyle.Format = "N2"
        dtgConsulta.Columns("efic_rec").DefaultCellStyle.Format = "N2"
        dtgConsulta.Columns("mes_").Frozen = True
        dtgConsulta.Columns("mes").Visible = False
        dtgConsulta.Columns("ano").Visible = False
        objOperacionesForm.alertas(dtgConsulta)
    End Sub
    Private Sub btn_consultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_consultar.Click
        img_procesar.Visible = True
        Application.DoEvents()
        If (ChkListvendedores.CheckedItems.Count > 0) Then
            cargarConsulta()
        Else
            MessageBox.Show("Seleccione al menos un vendedor", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        img_procesar.Visible = False
    End Sub
    Private Sub btnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Click
        objOperacionesForm.ExportarDatosExcel(dtgConsulta, "Encuestas")
    End Sub

End Class