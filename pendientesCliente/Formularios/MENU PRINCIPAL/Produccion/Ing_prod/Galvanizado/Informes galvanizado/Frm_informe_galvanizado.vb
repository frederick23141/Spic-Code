Imports logicaNegocios
Imports entidadNegocios
Public Class Frm_informe_galvanizado
    Private objOpSimplesLn As New Op_simpesLn
    Dim objIngresoProdLn As New Ing_prodLn
    Private obj_Ing_prodLn As New Ing_prodLn
    Dim carga_comp As Boolean = False
    Dim usuario As UsuarioEn
    Private objOperacionesForm As OperacionesFormularios = New OperacionesFormularios
    Dim horage, minutoge, horags, minutogs As String
    Private Sub informe_galvanizado_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_cbo()
        cboFechaIni.Value = Today
        cboFechaFin.Value = Today
        carga_comp = True
    End Sub
    Private Sub cargar_cbo()
        Dim sql As String
        Dim dt As New DataTable
        Dim dr As DataRow
        dt = New DataTable

        sql = "SELECT nit,nombres FROM V_nom_personal_Activo_con_maquila WHERE centro = 5200  order by nombres"
        dt = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        dr = dt.NewRow
        dr("nit") = 0
        dr("nombres") = "Seleccione"
        dt.Rows.Add(dr)
        cboOperariosG.DataSource = dt
        cboOperariosG.ValueMember = "nit"
        cboOperariosG.DisplayMember = "nombres"
        cboOperariosG.Text = "Seleccione"

        dt = New DataTable
        sql = "SELECT CONVERT(varchar,nro_bobina) as nro_bobina  FROM D_Bobina_Devanador"
        dt = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")
        dr = dt.NewRow
        dr("nro_bobina") = -1
        dr("nro_bobina") = "TODO"
        dt.Rows.Add(dr)
        cbobobina.DataSource = dt
        cbobobina.ValueMember = "nro_bobina"
        cbobobina.DisplayMember = "nro_bobina"
        cbobobina.Text = "Seleccione"
        cbobobina.SelectedValue = -1
    End Sub
    Private Sub cargarAdminProd(ByVal orden As String, ByVal codigo As String)
        dtgconsulta.DataSource = Nothing
        Dim tamano_letra As Single = 9.0!
        Dim operador As Integer = cboOperariosG.SelectedValue
        Dim horae As String
        Dim horas As String
        Dim bobina As String = cbobobina.SelectedValue
        Dim fecIni As String = objOpSimplesLn.cambiarFormatoFecha(cboFechaIni.Value)
        Dim fecFin As String = objOpSimplesLn.cambiarFormatoFecha(cboFechaFin.Value)
        horae = horage & ":" & minutoge & ":00"
        horas = horags & ":" & minutogs & ":00"
        If horas = "24:00:00" Then
            horas = "23:59:59"
        End If
        If horas = "24:00:00" Then
            horae = "23:59:59"
        End If
        Dim fecha_horae As String
        Dim fecha_horas As String
        fecha_horae = fecIni & " " & horae
        fecha_horas = fecFin & " " & horas
        Dim WhereCliExt As String = " and R.anular is null"
        Dim WhereFec As String = " where R.nro_orden = S.consecutivo_orden_G And ref.codigo = S.final_galv and ter.nit=R.nit_operario AND R.fecha_hora >= '" & fecha_horae & "' AND  R.fecha_hora  <= '" & fecha_horas & "' and R.no_conforme is null "
        Dim selectD As String = "SELECT"
        Dim groupby As String = " group by"
        Dim orderby As String = ""
        Dim dt As New DataTable
        Dim contar_select As Integer
        If (carga_comp) Then
            If chkoperador.Checked = True Then
                contar_select = Len(selectD)
                If contar_select > 6 Then
                    selectD &= " ,R.nit_operario"
                    groupby &= " ,R.nit_operario"
                Else
                    selectD &= " R.nit_operario"
                    groupby &= " R.nit_operario"
                End If
            End If
            If chkbobina.Checked = True Then
                contar_select = Len(selectD)
                If contar_select > 6 Then
                    selectD &= " ,R.bobina"
                    groupby &= " ,R.bobina"
                Else
                    selectD &= " R.bobina"
                    groupby &= " R.bobina"
                End If
            End If
            If chkorden.Checked = True Then
                contar_select = Len(selectD)
                If contar_select > 6 Then
                    selectD &= " ,R.nro_orden"
                    groupby &= " ,R.nro_orden"
                Else
                    selectD &= " R.nro_orden"
                    groupby &= " R.nro_orden"
                End If
            End If
            If chkcodigo.Checked = True Then
                contar_select = Len(selectD)
                If contar_select > 6 Then
                    selectD &= " ,S.final_galv,ref.descripcion"
                    groupby &= " ,S.final_galv,ref.descripcion"
                Else
                    selectD &= " S.final_galv,ref.descripcion"
                    groupby &= " S.final_galv,ref.descripcion"
                End If

            End If
            If chkanular.Checked = True Then
                WhereCliExt = " and R.anular = 1"
            End If
            If chk_noconforme.Checked = True Then
                WhereFec = " where R.nro_orden = S.consecutivo_orden_G And ref.codigo = S.final_galv and ter.nit=R.nit_operario AND R.fecha_hora >= '" & fecha_horae & "' AND  R.fecha_hora  <= '" & fecha_horas & "'"
                WhereCliExt = " and (R.no_conforme ='S' OR R.no_conforme ='NC')"
            End If
            If chk_desp.Checked = True Then
                WhereFec = " where R.nro_orden = S.consecutivo_orden_G And ref.codigo = S.final_galv and ter.nit=R.nit_operario AND R.fecha_hora >= '" & fecha_horae & "' AND  R.fecha_hora  <= '" & fecha_horas & "'"
                WhereCliExt = " and R.no_conforme ='DE'"
            End If
            If chk_traspu.Checked = True Then
                WhereFec = " where R.nro_orden = S.consecutivo_orden_G And ref.codigo = S.final_galv and ter.nit=R.nit_operario AND R.fecha_hora >= '" & fecha_horae & "' AND  R.fecha_hora  <= '" & fecha_horas & "'"
                WhereCliExt = " and R.traslado is not null  and R.destino='A' "
            End If
            If chk_Enb2.Checked = True Then
                WhereFec = " where R.nro_orden = S.consecutivo_orden_G And ref.codigo = S.final_galv and ter.nit=R.nit_operario AND R.fecha_hora >= '" & fecha_horae & "' AND  R.fecha_hora  <= '" & fecha_horas & "'"
                WhereCliExt = " and R.traslado is null  and R.destino is null and R.no_conforme is null and anular is null and saga is null and spu is null"
            End If
            If bobina = "" Or bobina = "TODO" Or bobina = "-1" Then
                    If operador <> 0 Then
                        WhereFec &= " AND R.nit_operario =" & operador & " "
                    End If
                Else
                    WhereFec += " AND R.bobina=" & bobina & ""
                    If operador <> 0 Then
                        WhereFec &= " AND R.nit_operario =" & operador & ""
                    End If
                End If
                If (orden <> "") Then
                    WhereFec &= " AND R.nro_orden =" & orden & ""
                End If
                If (codigo <> "") Then
                    WhereFec &= " AND S.final_galv LIKE'%" & codigo & "%'"
                End If
                contar_select = Len(selectD)
                If contar_select > 6 Then
                    selectD &= " ,sum(R.peso)as total_pesado"
                End If
            End If
            contar_select = Len(selectD)
        If contar_select = 6 Then
            selectD = "SELECT R.fecha_hora,R.trans_galv,R.tipo_trans,R.nro_orden,R.consecutivo_rollo as nro_rollo,S.final_galv,ref.descripcion,R.peso,R.bobina,R.capa,ter.nombres,R.diferencia"
            orderby = " order by R.fecha_hora "
        End If
        If groupby = " group by" Then
            groupby = ""
        End If
        Dim sql As String = selectD & " FROM D_rollo_galvanizado_f R, D_orden_pro_galv_enc S,CORSAN.dbo.referencias ref,CORSAN.dbo.V_nom_personal_Activo_con_maquila ter  " & WhereFec & WhereCliExt & orderby & groupby
        dt = obj_Ing_prodLn.listar_datatable(sql, "PRODUCCION")
        dt.Rows.Add()
        totalizarDt(dt)
        dtgconsulta.DataSource = dt
        For j = 0 To dtgconsulta.ColumnCount - 1
            If dtgconsulta.Columns(j).Name = "peso" Or dtgconsulta.Columns(j).Name = "total_pesado" Or dtgconsulta.Columns(j).Name = "diferencia" Then
                dtgconsulta.Columns(j).DefaultCellStyle.Format = "N1"
            End If
        Next
        dtgconsulta.Rows(dtgconsulta.RowCount - 1).DefaultCellStyle = objOperacionesForm.formatoNegrita(tamano_letra)
    End Sub
    Private Sub totalizarDt(ByRef dt As DataTable)
        Dim sum As Double = 0
        If dt.Columns.Count > 0 Then
            For j = 0 To dt.Columns.Count - 1
                If (dt.Columns(j).ColumnName = "peso" Or dt.Columns(j).ColumnName = "diferencia" Or dt.Columns(j).ColumnName = "total_pesado") Then
                    For i = 0 To dt.Rows.Count - 2
                        If Not IsDBNull(dt.Rows(i).Item(j)) Then
                            sum += dt.Rows(i).Item(j)
                        End If
                    Next
                    dt.Rows(dt.Rows.Count - 1).Item(j) = sum
                    sum = 0
                End If
            Next
        End If
    End Sub
    Private Sub btnActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActualizar.Click
        cargarAdminProd(txtNumero.Text, txtcodigo.Text)
    End Sub
    Private Sub txtNumero_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNumero.TextChanged
        cargarAdminProd(txtNumero.Text, txtcodigo.Text)
    End Sub

    Private Sub cboOperariosG_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboOperariosG.SelectedIndexChanged
        If (carga_comp) Then
            cargarAdminProd(txtNumero.Text, txtcodigo.Text)
        End If
    End Sub

    Private Sub cbobobina_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbobobina.SelectedIndexChanged
        If (carga_comp) Then
            cargarAdminProd(txtNumero.Text, txtcodigo.Text)
        End If
    End Sub
    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        Me.UseWaitCursor = True
        Application.DoEvents()
        objOperacionesForm.exportarExcel(dtgconsulta)
        Me.UseWaitCursor = False
    End Sub

    Private Sub txtcodigo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcodigo.TextChanged
        cargarAdminProd(txtNumero.Text, txtcodigo.Text)
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Me.Close()
    End Sub

    Private Sub cbo_hora_entrada_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_hora_entrada.SelectedIndexChanged
        horage = cbo_hora_entrada.SelectedItem
    End Sub

    Private Sub cbo_min_entrada_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_min_entrada.SelectedIndexChanged
        minutoge = cbo_min_entrada.SelectedItem
    End Sub

    Private Sub cbo_hora_salida_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_hora_salida.SelectedIndexChanged
        horags = cbo_hora_salida.SelectedItem
    End Sub

    Private Sub cbo_min_salida_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_min_salida.SelectedIndexChanged
        minutogs = cbo_min_salida.SelectedItem
    End Sub
End Class