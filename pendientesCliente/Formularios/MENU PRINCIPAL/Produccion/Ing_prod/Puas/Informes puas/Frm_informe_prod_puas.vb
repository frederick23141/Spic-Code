Imports logicaNegocios
Imports entidadNegocios
Public Class Frm_informe_prod_puas
    Private objOpSimplesLn As New Op_simpesLn
    Dim objIngresoProdLn As New Ing_prodLn
    Private obj_Ing_prodLn As New Ing_prodLn
    Dim carga_comp As Boolean = False
    Dim usuario As UsuarioEn
    Private objOperacionesForm As OperacionesFormularios = New OperacionesFormularios
    Dim horage, minutoge, horags, minutogs As String
    Private Sub Frm_informe_prod_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

        sql = "SELECT nit,nombres FROM V_nom_personal_Activo_con_maquila WHERE centro = 6400  order by nombres"
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
        sql = "SELECT m.codigoM,m.Descripción  FROM J_maquinas m , D_seccion_maquina_puas s WHERE s.maquina = m.codigoM AND m.tipoMAquina = 4 ORDER BY m.codigoM"
        dt = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")
        dr = dt.NewRow
        dr("codigoM") = -1
        dr("Descripción") = "TODO"
        dt.Rows.Add(dr)
        cbomaquina.DataSource = dt
        cbomaquina.ValueMember = "codigoM"
        cbomaquina.DisplayMember = "Descripción"
        cbomaquina.Text = "Seleccione"
        cbomaquina.SelectedValue = -1
    End Sub
    Private Sub cargarAdminProd(ByVal orden As String, ByVal codigo As String)
        dtgconsulta.DataSource = Nothing
        Dim tamano_letra As Single = 9.0!
        Dim operador As Integer = cboOperariosG.SelectedValue
        Dim horae As String
        Dim horas As String
        Dim maquina As String = cbomaquina.SelectedValue
        Dim desMaquina As String = cbomaquina.Text
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
        Dim WhereFec As String = " where R.nro_orden = S.cod_orden And ref.codigo = S.prod_final and ter.nit=R.nit_operario AND R.fecha_hora >= '" & fecha_horae & "' AND  R.fecha_hora  <= '" & fecha_horas & "' and R.no_conforme is null "
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
            If chkmaquina.Checked = True Then
                contar_select = Len(selectD)
                If contar_select > 6 Then
                    selectD &= " ,R.maquina"
                    groupby &= " ,R.maquina"
                Else
                    selectD &= " R.maquina"
                    groupby &= " R.maquina"
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
                    selectD &= " ,S.prod_final,ref.descripcion"
                    groupby &= " ,S.prod_final,ref.descripcion"
                Else
                    selectD &= " S.prod_final,ref.descripcion"
                    groupby &= " S.prod_final,ref.descripcion"
                End If

            End If
            If chkanular.Checked = True Then
                WhereCliExt = " and R.anular = 1"
            End If
            If chk_noconforme.Checked = True Then
                WhereFec = " where R.nro_orden = S.cod_orden And ref.codigo = S.prod_final and ter.nit=R.nit_operario AND R.fecha_hora >= '" & fecha_horae & "' AND  R.fecha_hora  <= '" & fecha_horas & "'"
                WhereCliExt = " and R.no_conforme ='S'"
            End If
            If maquina = "" Or maquina = "-1" Then
                If operador <> 0 Then
                    WhereFec &= " AND R.nit_operario =" & operador & " "
                End If
            Else
                WhereFec += " AND R.maquina='" & desMaquina & "'"
                If operador <> 0 Then
                    WhereFec &= " AND R.nit_operario =" & operador & ""
                End If
            End If
            If (orden <> "") Then
                WhereFec &= " AND R.nro_orden =" & orden & ""
            End If
            If (codigo <> "") Then
                WhereFec &= " AND S.prod_final LIKE'%" & codigo & "%'"
            End If
            contar_select = Len(selectD)
            If contar_select > 6 Then
                selectD &= " ,count(R.nro_orden)as nro_rollos"
            End If
        End If
        contar_select = Len(selectD)
        If contar_select = 6 Then
            selectD = "SELECT R.fecha_hora,R.trans_puas,R.tipo_trans,R.nro_orden,R.consecutivo_rollo as nro_rollo,S.prod_final,ref.descripcion,R.peso_real,R.peso_prom as peso_factor,R.diferencia,R.maquina,ter.nombres"
            orderby = " order by R.fecha_hora "
        End If
        If groupby = " group by" Then
            groupby = ""
        End If
        Dim sql As String = selectD & " FROM D_orden_prod_puas_producto R, D_orden_prod_puas S,CORSAN.dbo.referencias ref,CORSAN.dbo.V_nom_personal_Activo_con_maquila ter  " & WhereFec & WhereCliExt & orderby & groupby
        dt = obj_Ing_prodLn.listar_datatable(sql, "PRODUCCION")
        dt.Rows.Add()
        totalizarDt(dt)
        dtgconsulta.DataSource = dt
        For j = 0 To dtgconsulta.ColumnCount - 1
            If dtgconsulta.Columns(j).Name = "peso_real" Or dtgconsulta.Columns(j).Name = "peso_factor" Or dtgconsulta.Columns(j).Name = "diferencia" Then
                dtgconsulta.Columns(j).DefaultCellStyle.Format = "N1"
            End If
        Next
        dtgconsulta.Rows(dtgconsulta.RowCount - 1).DefaultCellStyle = objOperacionesForm.formatoNegrita(tamano_letra)
    End Sub
    Private Sub totalizarDt(ByRef dt As DataTable)
        Dim sum As Double = 0
        If dt.Columns.Count > 0 Then
            For j = 0 To dt.Columns.Count - 1
                If (dt.Columns(j).ColumnName = "peso_real" Or dt.Columns(j).ColumnName = "peso_factor" Or dt.Columns(j).ColumnName = "diferencia" Or dt.Columns(j).ColumnName = "nro_rollos") Then
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

    Private Sub cbobobina_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbomaquina.SelectedIndexChanged
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