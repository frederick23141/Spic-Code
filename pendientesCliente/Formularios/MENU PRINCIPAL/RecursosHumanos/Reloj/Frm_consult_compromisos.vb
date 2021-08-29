Imports accesoDatos
Imports logicaNegocios
Imports entidadNegocios
Public Class Frm_consult_compromisos
    'AUTOR DAvid hincapie
    Private objOpSimplesLn As New Op_simpesLn
    Dim centros As String = ""
    Dim centros_c, operarios As Integer
    Private dt As New DataTable
    Private objOperacionesForm As OperacionesFormularios = New OperacionesFormularios
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
            centros = "1200,2100,2117,2200,2300,2400,2500,2600,2800,3100,3200,4100,4200,4300,4500,3500,5200,6200,6400"
        End If
              cargarCbo()
        cargar_operarios(0)
    End Sub
    Public Sub mostrar_compromisos()
        Try
            Dim func As New Op_simplesAd
            dt = func.mostrar_compromiso
            If dt.Rows.Count <> 0 Then
                dtg_consulta.DataSource = dt
                dtg_consulta.ColumnHeadersVisible = True

            Else
                dtg_consulta.DataSource = Nothing
                dtg_consulta.ColumnHeadersVisible = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ToolStripSplitButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripSplitButton1.Click
        objOperacionesForm.ExportarDatosExcel(dtg_consulta, "Compromisos")
    End Sub
    Private Sub cargarCbo()
        Dim dt As New DataTable
        Dim dr As DataRow
        Dim sql As String
        Dim where_sql As String = ""
        If (centros <> "") Then
            where_sql &= "WHERE CENTRO IN (" & centros & " )"
        Else
            where_sql &= "WHERE centro IN(1100,1200,2100,2117,2200,2300,2400,2500,2600,2800,3100,3200,3500,4100,4200,4300,5200,6200,6400)"
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
            whereCentro &= " centro IN(1200,2100,2117,2200,2300,2400,2500,2600,2800,3100,3200,3500,4100,4200,4300,5200,6200,6400)"
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

    Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
        mostrar_compromisos()
        centros_c = cbo_centro.SelectedValue
        operarios = cbo_operario.SelectedValue
        Dim ds As New DataSet
        ds.Tables.Add(dt.Copy)

        Dim dv As New DataView(ds.Tables(0))

        dv.RowFilter = " activo = 'True' "
        If centros <> "" Then
            dv.RowFilter += " AND centro IN (" & centros & ") "
        End If
        If centros_c <> 0 Then
            dv.RowFilter += " AND centro = " & Trim(centros_c) & " "
        End If
        If operarios <> 0 Then
            dv.RowFilter += " AND Nit_Trabajador = " & Trim(operarios) & " "
        End If
        If chcompromiso.Checked = False Then
            dv.RowFilter += " and Horas > 0  "
        End If

        If dv.Count <> 0 Then

            dtg_consulta.DataSource = dv
        Else

            dtg_consulta.DataSource = Nothing
        End If
    End Sub


End Class