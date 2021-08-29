Imports accesoDatos
Imports entidadNegocios
Imports logicaNegocios
Public Class Frm_informe_nov_pendientes
    Private objOpSimplesLn As New Op_simpesLn
    Private objOperacionesForm As OperacionesFormularios = New OperacionesFormularios
    Dim centros As String = ""
    Dim centros_c, operarios, periodo As Integer
    Private dt As New DataTable
    Dim usuario As New UsuarioEn
    Public Sub MAIN(ByVal usuario As UsuarioEn)
        Me.usuario = usuario
        If (usuario.permiso.Trim <> "ADMIN" And usuario.permiso.Trim <> "NOMINA") Then
            Dim nit As Double = usuario.nit
            Dim listCentros As DataTable = objOpSimplesLn.listar_datatable("SELECT centro FROM J_coordinador_centros_costos WHERE nit =" & nit, "PRODUCCION")
            For i = 0 To listCentros.Rows.Count - 1
                centros &= listCentros.Rows(i).Item("centro")
                If (i <> listCentros.Rows.Count - 1) Then
                    centros &= ","
                End If
            Next
        End If
        If centros = "" Then
            centros = "1200,2100,2117,2200,2300,2400,2500,2600,2800,3100,3200,4100,3500,5200,6200,6400, 4200,4100,4300"
        End If
        cargarCbo()
        cargar_periodos()
        cargar_operarios(0)
    End Sub
    Public Sub mostrar_consulta()
        Try
            Dim func As New Op_simplesAd
            dt = func.mostrar_Sautorizar()
            If dt.Rows.Count <> 0 Then
                dtgMaestro.DataSource = dt
                dtgMaestro.ColumnHeadersVisible = True

            Else
                dtgMaestro.DataSource = Nothing
                dtgMaestro.ColumnHeadersVisible = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub cargarCbo()
        Dim dt As New DataTable
        Dim dr As DataRow
        Dim sql As String
        Dim where_sql As String = ""
        If (centros <> "") Then
            where_sql &= "WHERE CENTRO IN (" & centros & ") "
        Else
            where_sql &= "WHERE centro IN(1100,1200,2100,2117,2200,2300,2400,2500,2600,2800,3100,3200,3500,4100,4200,4300,5200,6200,6400, 4200,4100,4300)"
        End If
        sql = "SELECT centro,( CAST (centro AS varchar(25))+ '-' + descripcion )As descripcion " & _
                        "FROM centros " & _
                            where_sql
        dt = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        dr = dt.NewRow
        dr("centro") = 0
        dr("descripcion") = "TODO"
        dt.Rows.Add(dr)
        cbo_centro.DataSource = dt
        cbo_centro.ValueMember = "centro"
        cbo_centro.DisplayMember = "descripcion"
        cbo_centro.SelectedValue = 0
    End Sub
    Private Sub cargar_operarios(ByVal centro As Integer)
        Dim sql As String
        Dim dt As DataTable
        Dim row As DataRow
        Dim whereCentro As String = "WHERE"
        If centro = 0 Then
            whereCentro &= " centro IN(1200,2100,2117,2200,2300,2400,2500,2600,2800,3100,3200,3500,5200,6200,6400, 4200,4100,4300)"
        Else
            whereCentro &= " centro  =" & centro
        End If
        sql = "Select nit,nombres  from V_nom_personal_Activo_con_maquila " & whereCentro & " ORDER BY nombres "
        dt = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        row = dt.NewRow
        row("nit") = 0
        row("nombres") = "TODOS"
        dt.Rows.Add(row)
        cbo_operario.DataSource = dt
        cbo_operario.ValueMember = "nit"
        cbo_operario.DisplayMember = "nombres"
        cbo_operario.SelectedValue = 0
    End Sub
    Private Sub cargar_periodos()
        Dim sql As String
        Dim dt As DataTable
        Dim row As DataRow
        Dim fecha_menos_1_mes As Date = Now.AddMonths(-5)
        sql = "SELECT  idPeriodo ,'Periodo:' + CAST( (periodo  )As varchar ) +' - ' +CAST( YEAR (fecha_inicial )As varchar ) + '-' + CAST( MONTH (fecha_inicial )As varchar ) + '-' + CAST( DAY (fecha_inicial )As varchar ) " &
                         "+ ' - ' +  CAST( YEAR (fecha_final  )As varchar ) + '-' + CAST( MONTH (fecha_final )As varchar ) + '-' + CAST( DAY (fecha_final )As varchar ) As descripcion,fecha_inicial,fecha_final " &
                         "FROM y_periodos_control " &
                             "WHERE dateDiff (day,fecha_inicial,fecha_final )>5 AND ((ano = " & Now.Year & " And mes <= " & Now.Month & ")) "
        dt = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        row = dt.NewRow
        row("idPeriodo") = 0
        row("descripcion") = "TODOS"
        dt.Rows.Add(row)
        cbo_periodo.DataSource = dt
        cbo_periodo.ValueMember = "idPeriodo"
        cbo_periodo.DisplayMember = "descripcion"
        cbo_periodo.SelectedValue = 0
        For i = 0 To dt.Rows.Count - 2
            If Now.Date >= dt.Rows(i).Item("fecha_inicial") And Now.Date <= dt.Rows(i).Item("fecha_final") Then
                cbo_periodo.SelectedValue = dt.Rows(i).Item("idPeriodo")
                i = dt.Rows.Count - 1
            End If
        Next
    End Sub
    Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
        mostrar_consulta()
        centros_c = cbo_centro.SelectedValue
        operarios = cbo_operario.SelectedValue
        periodo = cbo_periodo.SelectedValue
        Dim ds As New DataSet
        Dim estados As String = ""
        ds.Tables.Add(dt.Copy)

        Dim dv As New DataView(ds.Tables(0))
        If centros <> "" Then
            dv.RowFilter = " centro IN (" & centros & ") "
        End If
        If centros_c <> 0 Then
            If dv.RowFilter = "" Then
                dv.RowFilter += " centro = " & Trim(centros_c) & " "
            Else
                dv.RowFilter += " AND centro = " & Trim(centros_c) & " "
            End If

        End If

        If operarios <> 0 Then
            If dv.RowFilter = "" Then
                dv.RowFilter = " nit = " & Trim(operarios) & " "

            Else
                dv.RowFilter += "and nit = " & Trim(operarios) & " "
            End If

        End If
        If periodo <> 0 Then
            If dv.RowFilter = "" Then
                dv.RowFilter = " idperiodo = " & Trim(periodo) & " "
            Else
                dv.RowFilter += "and idperiodo = " & Trim(periodo) & " "
            End If

        End If

        If chk_pendientes.Checked = True Then
            If estados = "" Then
                estados += "'N'"
            Else
                estados += ",'N'"
            End If
        End If
        If chk_autorizadas.Checked = True Then
            If estados = "" Then
                estados += "'S'"
            Else
                estados += ",'S'"
            End If
        End If
        If chk_rechazadas.Checked = True Then
            If estados = "" Then
                estados += "'R'"
            Else
                estados += ",'R'"
            End If
        End If
        If estados <> "" Then
            dv.RowFilter += " AND autorizado IN( " & estados & " )"
        End If
        dtgMaestro.DataSource = dv
        Me.dtgMaestro.Columns("fecha_inicial").DefaultCellStyle.Format = "d"
        Me.dtgMaestro.Columns("fecha_final").DefaultCellStyle.Format = "d"
        pintar()
    End Sub

    Private Sub ToolStripSplitButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripSplitButton1.Click
        objOperacionesForm.ExportarDatosExcel(dtgMaestro, "Novedades pendientes")
    End Sub
    Private Sub pintar()
        For i = 0 To dtgMaestro.RowCount - 1
            If dtgMaestro.Item("autorizado", i).Value = "N" Then
                dtgMaestro.Rows(i).DefaultCellStyle.BackColor = Color.Red
            ElseIf dtgMaestro.Item("autorizado", i).Value = "S" Then
                dtgMaestro.Rows(i).DefaultCellStyle.BackColor = Color.GreenYellow
            ElseIf dtgMaestro.Item("autorizado", i).Value = "R" Then
                dtgMaestro.Rows(i).DefaultCellStyle.BackColor = Color.LightGray
            End If
        Next
    End Sub
End Class