Imports logicaNegocios
Imports entidadNegocios
Public Class Frm_informe_marcaciones
    Private objOperacionesForm As OperacionesFormularios = New OperacionesFormularios
    Private objOpSimplesLn As New Op_simpesLn
    Private objRelojLn As New RelojLn
    Private nomb_modulo As String
    Dim centros As String = ""
    Dim usuario As New UsuarioEn
    Dim carga_comp As Boolean = False
    Dim fec_ini As Date
    Dim fec_fin As Date

    Public Sub MAIN(ByVal nomb_modulo As String, ByVal usuario As UsuarioEn)
        Me.usuario = usuario
        Dim dt As New DataTable
        Dim listCentros As New DataTable
        Dim sql As String = ""
        If (usuario.permiso.Trim <> "ADMIN" And usuario.permiso.Trim <> "NOMINA") Then
            Dim nit As Double = usuario.nit
            listCentros = objOpSimplesLn.listar_datatable("SELECT centro FROM J_coordinador_centros_costos WHERE nit =" & nit, "PRODUCCION")
            For i = 0 To listCentros.Rows.Count - 1
                centros &= listCentros.Rows(i).Item("centro")
                If (i <> listCentros.Rows.Count - 1) Then
                    centros &= ","
                End If
            Next
        End If
        If centros = "" Then
            centros = "1200,2100,2117,2200,2300,2400,2500,2600,2800,3100,3200,3500,5200,6200,6400, 4200,4100,4300"
        End If
        dt = New DataTable
        Dim dr As DataRow
        Dim where_sql As String = ""
        where_sql &= "WHERE centro IN(1200,2100,2200,2300,2400,2500,2600,2800,3100,3200,3500,5200,6200,6400, 4200,4100,4300)"
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
        cargar_operarios(0)
        cbo_fecha_ini.Value = Now.AddDays(-Now.Day + 1)
        cbo_fecha_fin.Value = Now.AddDays(-1)
        carga_comp = True
    End Sub

    Private Sub btnConsol_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
        dtg_consulta.CurrentCell = Nothing
        imgProcesar.Visible = True
        Application.DoEvents()
        dtg_consulta.DataSource = Nothing
        cargar_datos()
        imgProcesar.Visible = False
    End Sub
    Private Sub cargar_datos()
        dtg_consulta.DataSource = Nothing
        Dim sFec_ini As String = objOpSimplesLn.cambiarFormatoFecha(cbo_fecha_ini.Value)
        Dim sFec_fin As String = objOpSimplesLn.cambiarFormatoFecha(cbo_fecha_fin.Value)
        Dim sql As String = "SELECT r.consecutivo,t.nit,t.nombres,c.centro,c.descripcion ,r.FechaEntrada , r.FechaSalida ,(DATEDIFF (hour,FechaEntrada,FechaSalida ))As horas,r.permiso ,r.notas " & _
                                "FROM r_personal_registros r , CORSAN.dbo.V_nom_personal_Activo_con_maquila  t , CORSAN.dbo.centros  c " & _
                                   "WHERE r.nit = t.nit AND t.centro = c.centro AND  ((r.permiso <> 'S' AND r.permiso <> '') OR FechaSalida is null) AND CAST(r.FechaEntrada AS date )  Between '" & sFec_ini & "' AND '" & sFec_fin & " 23:59:59' "
        Dim dt_sin_permiso As DataTable = objOpSimplesLn.listar_datatable(sql, "CONTROL")
        sql = "SELECT r.consecutivo,t.nit,t.nombres,c.centro,c.descripcion ,r.FechaEntrada , r.FechaSalida ,(DATEDIFF (hour,FechaEntrada,FechaSalida ))As horas,r.permiso ,r.notas " & _
                "FROM r_personal_registros r , CORSAN.dbo.V_nom_personal_Activo_con_maquila  t , CORSAN.dbo.centros  c  " & _
                    "WHERE r.nit = t.nit AND t.centro = c.centro  AND CAST(r.FechaEntrada AS date )  Between '" & sFec_ini & "' AND '" & sFec_fin & " 23:59:59' " & _
                        "AND ((CAST(r.fechaEntrada As time) > '05:50:00' AND CAST(r.fechaEntrada As time) < '06:30:00' )  " & _
                        "OR (CAST(r.fechaEntrada As time) > '13:50:00' AND CAST(r.fechaEntrada As time) < '14:30:00')  " & _
                        "OR (CAST(r.fechaEntrada As time) > '21:50:00' AND CAST(r.fechaEntrada As time) < '22:30:00'))"
        Dim dt As DataTable = objOpSimplesLn.listar_datatable(sql, "CONTROL")
        For i = 0 To dt_sin_permiso.Rows.Count - 1
            dt.Rows.Add()
            For j = 0 To dt.Columns.Count - 1
                dt.Rows(dt.Rows.Count - 1).Item(j) = dt_sin_permiso.Rows(i).Item(j)
            Next
        Next
        Dim view As DataView = New DataView(dt)
        view.Sort = "nombres,FechaEntrada"
        dtg_consulta.DataSource = view
        dtg_consulta.Columns("FechaEntrada").DefaultCellStyle.Format = "g"
        dtg_consulta.Columns("FechaSalida").DefaultCellStyle.Format = "g"
        pintar_dtg()
    End Sub
    Private Sub pintar_dtg()
        Dim nom_dia_hoy As String = WeekdayName(Weekday(Now), True, 1) & Now.Day & "-" & MonthName(Now.Month)
        Dim nit As Double = 0
        For i = 0 To dtg_consulta.Rows.Count - 1
            If IsDBNull(dtg_consulta.Item("FechaSalida", i).Value) Then
                dtg_consulta.Item("nit", i).Style.BackColor = Color.Yellow
                dtg_consulta.Item("nombres", i).Style.BackColor = Color.Yellow
                dtg_consulta.Item("permiso", i).Style.BackColor = Color.Yellow
            ElseIf Not IsDBNull(dtg_consulta.Item("permiso", i).Value) Then
                If (dtg_consulta.Item("permiso", i).Value = "N") Then
                    dtg_consulta.Item("nit", i).Style.BackColor = Color.GreenYellow
                    dtg_consulta.Item("nombres", i).Style.BackColor = Color.GreenYellow
                    dtg_consulta.Item("permiso", i).Style.BackColor = Color.GreenYellow
                ElseIf (dtg_consulta.Item("permiso", i).Value = "C") Then
                    dtg_consulta.Item("nit", i).Style.BackColor = Color.Red
                    dtg_consulta.Item("nombres", i).Style.BackColor = Color.Red
                    dtg_consulta.Item("permiso", i).Style.BackColor = Color.Red
                End If
            End If
            If Not IsDBNull(dtg_consulta.Item("FechaEntrada", i).Value) And Not IsDBNull(dtg_consulta.Item("FechaSalida", i).Value) Then
                dtg_consulta.Item("nit", i).Style.BackColor = Color.Purple
                dtg_consulta.Item("nombres", i).Style.BackColor = Color.Purple
                dtg_consulta.Item("FechaEntrada", i).Style.BackColor = Color.Purple
                dtg_consulta.Item("nit", i).Style.ForeColor = Color.White
                dtg_consulta.Item("nombres", i).Style.ForeColor = Color.White
                dtg_consulta.Item("FechaEntrada", i).Style.ForeColor = Color.White
            End If
        Next
    End Sub
  
    Private Sub dtg_consulta_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dtg_consulta.DataError

    End Sub

 

    Private Sub cbo_centro_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbo_centro.SelectedIndexChanged
        If carga_comp Then
            cargar_operarios(cbo_centro.SelectedValue)
        End If
    End Sub
    Private Sub cargar_operarios(ByVal centro As Integer)
        Dim sql As String
        Dim dt As DataTable
        Dim row As DataRow
        Dim whereCentro As String = "WHERE"
        If centro = 0 Then
            whereCentro &= " centro IN(" & centros & ")"
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

    Private Sub ToolStripSplitButton1_Click(sender As Object, e As EventArgs) Handles ToolStripSplitButton1.Click
        objOperacionesForm.ExportarDatosExcel(dtg_consulta, "Marcaciones")
    End Sub
End Class