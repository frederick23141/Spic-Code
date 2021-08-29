Imports logicaNegocios
Imports System.Data.SqlClient
Public Class Frm_desperdicios
    Private obj_op_simplesLn As New Op_simpesLn
    Private obj_Ing_prodLn As New Ing_prodLn
    Private objOperacionesForm As New OperacionesFormularios
    Dim carga_comp As Boolean = False
    Private dt_consulta As New DataTable
    Dim id_exixtente As Integer = 0
    Dim fila_select As Integer
    Dim dt_tipos As DataTable
    Private Sub Frm_fecha_entrega_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dt As New DataTable
        Dim dr As DataRow
        Dim sql As String
        Dim where_sql As String = ""
        where_sql &= "WHERE centro IN(1100,1200,2100,2117,2200,2300,2400,2500,2600,2800,3100,3200,3500,4100,4200,4300,5200,6200,6400)"
        sql = "SELECT centro,( CAST (centro AS varchar(25))+ '-' + descripcion )As descripcion " & _
                        "FROM centros " & _
                            where_sql
        dt = obj_op_simplesLn.listar_datatable(sql, "CORSAN")
        dr = dt.NewRow
        dr("centro") = 0
        dr("descripcion") = "TODO"
        dt.Rows.Add(dr)
        cbo_centro.DataSource = dt
        cbo_centro.ValueMember = "centro"
        cbo_centro.DisplayMember = "descripcion"
        cbo_centro.SelectedValue = 0

        dt = New DataTable
        sql = "SELECT centro,( CAST (centro AS varchar(25))+ '-' + descripcion )As descripcion " & _
                    "FROM centros " & _
                        where_sql
        dt = obj_op_simplesLn.listar_datatable(sql, "CORSAN")
        dr = dt.NewRow
        dr("centro") = 0
        dr("descripcion") = "TODO"
        dt.Rows.Add(dr)
        cbo_centro_resu.DataSource = dt
        cbo_centro_resu.ValueMember = "centro"
        cbo_centro_resu.DisplayMember = "descripcion"
        cbo_centro_resu.SelectedValue = 2100

        dt = New DataTable
        where_sql = "WHERE centro IN(1100,1200,2100,2117,2200,2300,2400,2500,2600,2800,3100,3200,3500,4100,4200,4300,5200,6200,6400)"
        sql = "SELECT centro,( CAST (centro AS varchar(25))+ '-' + descripcion )As descripcion " & _
                        "FROM centros " & _
                            where_sql
        dt = obj_op_simplesLn.listar_datatable(sql, "CORSAN")
        dr = dt.NewRow
        dr("centro") = 0
        dr("descripcion") = "TODO"
        dt.Rows.Add(dr)
        cbo_centro_consult.DataSource = dt
        cbo_centro_consult.ValueMember = "centro"
        cbo_centro_consult.DisplayMember = "descripcion"
        cbo_centro_consult.SelectedValue = 0

        dt = New DataTable
        sql = "Select nit,nombres  from V_nom_personal_Activo_con_maquila WHERE centro not in ( 4200,4300) ORDER BY nombres "
        dt = obj_op_simplesLn.listar_datatable(sql, "CORSAN")
        dr = dt.NewRow
        dr("nit") = 890900160
        dr("nombres") = "TODO"
        dt.Rows.Add(dr)
        cbo_operario.DataSource = dt
        cbo_operario.ValueMember = "nit"
        cbo_operario.DisplayMember = "nombres"
        cbo_operario.SelectedValue = 890900160

        dt = New DataTable
        sql = "Select nit,nombres  from V_nom_personal_Activo_con_maquila WHERE centro not in ( 4200,4300) ORDER BY nombres "
        dt = obj_op_simplesLn.listar_datatable(sql, "CORSAN")
        dr = dt.NewRow
        dr("nit") = 0
        dr("nombres") = "TODO"
        dt.Rows.Add(dr)
        cbo_operario2.DataSource = dt
        cbo_operario2.ValueMember = "nit"
        cbo_operario2.DisplayMember = "nombres"
        cbo_operario2.SelectedValue = 0

        dt = New DataTable
        sql = "Select codigoM,nombre from j_maquinas "
        dt = obj_op_simplesLn.listar_datatable(sql, "PRODUCCION")
        dr = dt.NewRow
        dr("codigoM") = 0
        dr("nombre") = "TODO"
        dt.Rows.Add(dr)
        cbo_maquina.DataSource = dt
        cbo_maquina.ValueMember = "codigoM"
        cbo_maquina.DisplayMember = "nombre"
        cbo_maquina.SelectedValue = 0

        dt = New DataTable
        sql = "SELECT id,descripcion  FROM J_desperdicio_tipo "
        dt = obj_op_simplesLn.listar_datatable(sql, "PRODUCCION")
        dr = dt.NewRow
        dr("id") = 0
        dr("descripcion") = "TODO"
        dt.Rows.Add(dr)
        cboTipoDesperdicio.DataSource = dt
        cboTipoDesperdicio.ValueMember = "id"
        cboTipoDesperdicio.DisplayMember = "descripcion"
        cboTipoDesperdicio.SelectedValue = 0

        dt = New DataTable
        sql = "Select nit,nombres  from V_nom_personal_Activo_con_maquila WHERE centro = 6400 ORDER BY nombres "
        dt = obj_op_simplesLn.listar_datatable(sql, "CORSAN")
        dr = dt.NewRow
        dr("nit") = 0
        dr("nombres") = "TODO"
        dt.Rows.Add(dr)
        cbo_operario_consult.DataSource = dt
        cbo_operario_consult.ValueMember = "nit"
        cbo_operario_consult.DisplayMember = "nombres"
        cbo_operario_consult.SelectedValue = 0

        dt = New DataTable
        sql = "SELECT Id_causal,D_causal  FROM J_desperdicios_causal"
        dt = obj_op_simplesLn.listar_datatable(sql, "PRODUCCION")
        dr = dt.NewRow
        dr("Id_causal") = 0
        dr("D_causal") = "TODO"
        dt.Rows.Add(dr)
        cbo_causal.DataSource = dt
        cbo_causal.ValueMember = "Id_causal"
        cbo_causal.DisplayMember = "D_causal"
        cbo_causal.SelectedValue = 0

        dt = New DataTable
        sql = "SELECT Id_defecto,D_defecto FROM J_desperdicios_defecto ORDER BY D_defecto"
        dt = obj_op_simplesLn.listar_datatable(sql, "PRODUCCION")
        dr = dt.NewRow
        dr("Id_defecto") = 0
        dr("D_defecto") = "TODO"
        dt.Rows.Add(dr)
        cbo_defecto.DataSource = dt
        cbo_defecto.ValueMember = "Id_defecto"
        cbo_defecto.DisplayMember = "D_defecto"
        cbo_defecto.SelectedValue = 0

        dt = New DataTable
        sql = "SELECT id,descripcion FROM J_desperdicio_destino ORDER BY descripcion"
        dt = obj_op_simplesLn.listar_datatable(sql, "PRODUCCION")
        dr = dt.NewRow
        dr("id") = 0
        dr("descripcion") = "Seleccione"
        dt.Rows.Add(dr)
        cbo_destino.DataSource = dt
        cbo_destino.ValueMember = "id"
        cbo_destino.DisplayMember = "descripcion"
        cbo_destino.SelectedValue = 0

        dt = New DataTable
        sql = "SELECT id,descripcion FROM J_desperdicio_destino ORDER BY descripcion"
        dt = obj_op_simplesLn.listar_datatable(sql, "PRODUCCION")
        dr = dt.NewRow
        dr("id") = 0
        dr("descripcion") = "TODO"
        dt.Rows.Add(dr)
        cbo_destino_consulta.DataSource = dt
        cbo_destino_consulta.ValueMember = "id"
        cbo_destino_consulta.DisplayMember = "descripcion"
        cbo_destino_consulta.SelectedValue = 0

        sql = "SELECT s.id As tipo,s.descripcion,c.D_causal FROM j_desperdicio_tipo s, J_desperdicios_causal c	WHERE s.causal = c.Id_causal"
        dt_tipos = obj_op_simplesLn.listar_datatable(sql, "PRODUCCION")
        dt_tipos.Columns.Add("presupuesto", GetType(Double))
        Dim año = Now.Year
        While (año >= Now.Year - 5)
            cbo_ano.Items.Add(año)
            cboAnoConsulta.Items.Add(año)
            año -= 1
        End While
        cbo_ano.Text = Now.Year
        cboAnoConsulta.Text = Now.Year
        cbo_mes.SelectedIndex = Now.Month - 1
        consultar_ppto()
        cargar_resumen()
    End Sub
    Private Sub guardar()
        If (validar()) Then
            Dim fecha As String = obj_op_simplesLn.cambiarFormatoFecha(cbo_fecha.Value)
            Dim nit As Double = cbo_operario.SelectedValue
            Dim centro As Double = cbo_centro.SelectedValue
            Dim kilos As Double = txtKilos.Text
            Dim tipo As Integer = cboTipoDesperdicio.SelectedValue
            Dim causal As Integer = cbo_causal.SelectedValue
            Dim defecto As Integer = cbo_defecto.SelectedValue
            Dim destino As Integer = cbo_destino.SelectedValue
            Dim id As Double = 0
            Dim observaciones As String = txt_observaciones.Text
            'Maquina 001 para diferenciar que se ingreso por este modulo
            Dim listSql As List(Of Object) = obj_Ing_prodLn.guardar_desperdicio(fecha, nit, centro, kilos, tipo, causal, defecto, observaciones, id_exixtente, destino, "001")
            If (obj_Ing_prodLn.ExecuteSqlTransaction(listSql, "PRODUCCION")) Then
                MessageBox.Show("El registro se guardo en forma exitosa!", "Exito!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                nuevo()
            Else
                MessageBox.Show("Error al ingresar el registro, comuniquese con el area de sistemas", "Verifique!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub
    Private Sub nuevo()
        carga_comp = False
        id_exixtente = 0
        lbl_modificando.Text = ""
        cbo_operario.SelectedValue = 890900160
        cbo_centro.SelectedValue = 0
        cboTipoDesperdicio.SelectedValue = 0
        txtKilos.Text = ""
        txt_observaciones.Text = ""
        carga_comp = True
    End Sub

    Private Function validar() As Boolean
        tab_ppal.SelectedTab = tab_ingreso
        If (cbo_defecto.SelectedValue <> 0) Then
            If (cbo_causal.SelectedValue <> 0) Then
                If (cbo_centro.SelectedValue <> 0) Then
                    If (cboTipoDesperdicio.SelectedValue <> 0) Then
                        If IsNumeric(txtKilos.Text) Then
                            If (cbo_destino.SelectedValue <> 0) Then
                                If txt_observaciones.Text <> "" Then
                                    Return True
                                Else
                                    MessageBox.Show("Ingrese observación!", "Verifique!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                End If
                            Else
                                MessageBox.Show("Seleccione destino", "Verifique!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End If
                        Else
                            MessageBox.Show("Ingrese kilos correctos!", "Verifique!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    Else
                        MessageBox.Show("Seleccione un tipo de desperdicio", "Verifique!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Else
                    MessageBox.Show("Seleccione un centro de costos", "Verifique!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                MessageBox.Show("Seleccione un causal", "Verifique!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            MessageBox.Show("Seleccione un defecto", "Verifique!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        Return False
    End Function
    Private Sub btn_guardar_Click(sender As System.Object, e As System.EventArgs) Handles btn_guardar.Click
        If tab_ppal.SelectedTab.Name = tab_ppto.Name Then
            guardarPpto()
        Else
            guardar()
        End If

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
    Private Sub txtKilos_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtKilos.KeyPress
        soloNumero(e)
    End Sub

    Private Sub btn_actualizar_Click(sender As System.Object, e As System.EventArgs) Handles btn_actualizar.Click
        Dim tamano_letra As Single = 9.0!
        dtg_consulta.DataSource = Nothing
        img_procesar.Visible = True
        Application.DoEvents()
        If (chk_consol_centro.Checked Or chk_consol_operario.Checked Or chk_consol_ano.Checked Or chk_consol_mes.Checked Or chkConsolTipo.Checked Or chk_defecto.Checked Or chk_destino.Checked) Then
            dtg_consulta.Columns(col_modificar.Name).Visible = False
            consolidar()
        Else
            dtg_consulta.Columns(col_modificar.Name).Visible = True
            cargar_detalle()
        End If
        consolidar2()
        dtg_consulta.Rows(dtg_consulta.Rows.Count - 1).DefaultCellStyle = objOperacionesForm.formatoNegrita(tamano_letra)
        consultar_ppto()
        img_procesar.Visible = False
    End Sub
    Private Sub cargar_detalle()
        Dim fec_ini As String = obj_op_simplesLn.cambiarFormatoFecha(cbo_fecha_ini.Value)
        Dim fec_fin As String = obj_op_simplesLn.cambiarFormatoFecha(cbo_fecha_fin.Value)
        Dim sql As String = ""
        Dim selectSql As String
        If cbo_centro_consult.SelectedValue = 2100 Then
            selectSql = "SELECT id,fecha,nit,nombres,(select nombre from j_maquinas where codigoM=cod_maq) as maquina,centro,desc_centro,defecto,causal,kilos,tipo,desc_tipo,observaciones,fecha_ingreso FROM J_v_desperdicios "
        Else
            selectSql = "SELECT id,fecha,nit,nombres,cod_maq as maquina,centro,desc_centro,defecto,causal,kilos,tipo,desc_tipo,observaciones,fecha_ingreso FROM J_v_desperdicios "
        End If

        Dim whereSql As String = "WHERE anulado IS NULL AND  fecha BETWEEN '" & fec_ini & "' AND '" & fec_fin & "' "
        If (cbo_operario_consult.SelectedValue <> 0) Then
            whereSql &= "AND nit = " & cbo_operario_consult.SelectedValue & " "
        End If
        If (cbo_centro_consult.SelectedValue <> 0) Then
            whereSql &= "AND centro = " & cbo_centro_consult.SelectedValue & " "
        End If
        If (cbo_destino_consulta.SelectedValue <> 0) Then
            whereSql &= "AND destino = " & cbo_destino_consulta.SelectedValue & " "
        End If
        sql = selectSql & whereSql
        dt_consulta = obj_Ing_prodLn.listar_datatable(sql, "PRODUCCION")
        totalizar()
        dtg_consulta.DataSource = dt_consulta
        dtg_consulta.Columns("fecha").DefaultCellStyle.Format = "d"
        dtg_consulta.Columns("kilos").DefaultCellStyle.Format = "N1"
        dtg_consulta.Columns("fecha_ingreso").DefaultCellStyle.Format = "g"
    End Sub
    Private Function anular(ByVal id As Double) As Boolean
        Dim respuesta As Integer = MessageBox.Show("Esta seguro que desea borrar el registro", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        Dim resp As Boolean = False
        If (respuesta = 6) Then
            Dim sql As String = "UPDATE J_desperdicios SET anulado = 1 WHERE id = " & id & " "
            If (obj_op_simplesLn.ejecutar(sql, "PRODUCCION")) Then
                resp = True
            Else
                resp = False
            End If
        Else
            MessageBox.Show("Ingrese motivo de anulación", "Verifique!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        Return resp
    End Function
    Private Sub dtg_consulta_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtg_consulta.CellClick
        If (e.RowIndex >= 0) Then
            Dim col As String = dtg_consulta.Columns(e.ColumnIndex).Name
            If (col = col_borrar.Name) Then
                Dim id As Double = dtg_consulta.Item("id", e.RowIndex).Value
                If (anular(id)) Then
                    MessageBox.Show("El registro se borro en forma exitosa!", "Exito!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    dtg_consulta.CurrentCell = Nothing
                    dtg_consulta.Rows(e.RowIndex).Visible = False
                Else
                    MessageBox.Show("Error al borrar el registro, comuniquese con el area de sistemas", "Verifique!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            ElseIf (col = col_modificar.Name) Then
                carga_comp = False
                lbl_modificando.Text = "Modificando id:" & dtg_consulta.Item("id", e.RowIndex).Value
                id_exixtente = dtg_consulta.Item("id", e.RowIndex).Value
                tab_ppal.SelectedTab = tab_ingreso
                cbo_operario.SelectedValue = dtg_consulta.Item("nit", e.RowIndex).Value
                cbo_centro.SelectedValue = dtg_consulta.Item("centro", e.RowIndex).Value
                cbo_causal.SelectedValue = dtg_consulta.Item("id_causal", e.RowIndex).Value
                cbo_defecto.SelectedValue = dtg_consulta.Item("id_defecto", e.RowIndex).Value
                cbo_fecha.Value = dtg_consulta.Item("fecha", e.RowIndex).Value
                txtKilos.Text = dtg_consulta.Item("kilos", e.RowIndex).Value
                cboTipoDesperdicio.SelectedValue = dtg_consulta.Item("tipo", e.RowIndex).Value
                carga_comp = True
            End If
        End If
    End Sub

    Private Sub btn_excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_excel.Click
        objOperacionesForm.ExportarDatosExcel(dtg_consulta, "Informe de desperdicios")
    End Sub


    Private Sub consolidar()
        Dim poner_ppto As Boolean = False
        Dim fec_ini As String = obj_op_simplesLn.cambiarFormatoFecha(cbo_fecha_ini.Value)
        Dim fec_fin As String = obj_op_simplesLn.cambiarFormatoFecha(cbo_fecha_fin.Value)
        Dim sql As String = ""
        Dim selectSql As String = "SELECT "
        Dim fromSql As String = " FROM J_v_desperdicios  "
        Dim whereSql As String = " WHERE anulado IS NULL AND fecha >= '" & fec_ini & "' AND fecha <= '" & fec_fin & "' "
        Dim groupSql As String = ""
        If (chk_consol_ano.Checked) Then
            poner_ppto = False
            If selectSql <> "SELECT " Then
                selectSql &= ","
            End If
            selectSql &= "YEAR(fecha) As año"
            If (groupSql = "") Then
                groupSql = " GROUP BY "
            Else
                groupSql &= ","
            End If
            groupSql &= "YEAR(fecha)"
        End If
        If (chk_consol_mes.Checked) Then
            poner_ppto = False
            If selectSql <> "SELECT " Then
                selectSql &= ","
            End If
            If (groupSql = "") Then
                groupSql = " GROUP BY "
            Else
                groupSql &= ","
            End If
            selectSql &= "MONTH(fecha) As mes"
            groupSql &= "MONTH(fecha)"
        End If
        If (chk_consol_centro.Checked) Then
            poner_ppto = True
            If selectSql <> "SELECT " Then
                selectSql &= ","
            End If
            If (groupSql = "") Then
                groupSql = " GROUP BY "
            Else
                groupSql &= ","
            End If
            selectSql &= "centro,desc_centro"
            groupSql &= "centro,desc_centro"
        End If
        If (chk_consol_operario.Checked) Then
            poner_ppto = False
            If selectSql <> "SELECT " Then
                selectSql &= ","
            End If
            If (groupSql = "") Then
                groupSql = " GROUP BY "
            Else
                groupSql &= ","
            End If
            selectSql &= "nit,nombres"
            groupSql &= "nit,nombres"
        End If
        If (chkConsolTipo.Checked) Then
            poner_ppto = False
            If selectSql <> "SELECT " Then
                selectSql &= ","
            End If
            If (groupSql = "") Then
                groupSql = " GROUP BY "
            Else
                groupSql &= ","
            End If
            selectSql &= "desc_tipo"
            groupSql &= "desc_tipo"
        End If
        If (chk_defecto.Checked) Then
            poner_ppto = False
            If selectSql <> "SELECT " Then
                selectSql &= ","
            End If
            If (groupSql = "") Then
                groupSql = " GROUP BY "
            Else
                groupSql &= ","
            End If
            selectSql &= "defecto"
            groupSql &= "defecto"
        End If
        If (chk_destino.Checked) Then
            poner_ppto = False
            If selectSql <> "SELECT " Then
                selectSql &= ","
            End If
            If (groupSql = "") Then
                groupSql = " GROUP BY "
            Else
                groupSql &= ","
            End If
            selectSql &= "destino"
            groupSql &= "destino"
        End If
        selectSql &= ",SUM(kilos)As kilos "
        If poner_ppto Then
            selectSql &= ",AVG(presupuesto) As presupuesto "
        End If
        If (cbo_operario_consult.SelectedValue <> 0) Then
            whereSql &= "AND nit = " & cbo_operario_consult.SelectedValue & " "
        End If
        If (cbo_centro_consult.SelectedValue <> 0) Then
            whereSql &= "AND centro = " & cbo_centro_consult.SelectedValue & " "
        End If
        If (cbo_destino_consulta.SelectedValue <> 0) Then
            whereSql &= "AND centro = " & cbo_destino_consulta.SelectedValue & " "
        End If
        sql = selectSql & fromSql & whereSql & groupSql
        dt_consulta = obj_Ing_prodLn.listar_datatable(sql, "PRODUCCION")
        totalizar()
        If poner_ppto Then
            dt_consulta.Columns.Add("cump", GetType(Double))
            calcular_cump(dt_consulta)
        End If
        dtg_consulta.DataSource = dt_consulta
        dtg_consulta.Columns("kilos").DefaultCellStyle.Format = "N1"
        If poner_ppto Then
            dtg_consulta.Columns("cump").DefaultCellStyle.Format = "N1"
        End If

    End Sub
    Private Sub calcular_cump(ByRef dt As DataTable)
        For i = 0 To dt.Rows.Count - 1
            If IsNumeric(dt.Rows(i).Item("kilos")) And IsNumeric(dt.Rows(i).Item("presupuesto")) Then
                If dt.Rows(i).Item("presupuesto") > 0 Then
                    dt.Rows(i).Item("cump") = (dt.Rows(i).Item("kilos") / dt.Rows(i).Item("presupuesto")) * 100
                End If
            End If
        Next
    End Sub
    Private Sub consolidar2()
        Dim fec_ini As String = obj_op_simplesLn.cambiarFormatoFecha(cbo_fecha_inic.Value)
        Dim fec_fin As String = obj_op_simplesLn.cambiarFormatoFecha(cbo_fecha_final.Value)
        Dim operador As String = cbo_operario2.SelectedValue
        Dim maquina As String = cbo_maquina.SelectedValue
        Dim sql As String = ""
        Dim selectSql As String = "SELECT id,nit,fecha,maquina,nombres,alambron,reproceso,amarres,no_conforme,tran_no_confor,tran_amarres"
        Dim fromSql As String = " FROM J_v_desperdicio_no_conform_amarres"
        Dim whereSql As String = " WHERE fecha  BETWEEN  '" & fec_ini & "' AND '" & fec_fin & "'"
        Dim groupSql As String = ""


        If (operador <> 0) Then
            whereSql &= "and nit = " & operador & " "
        End If
        If (maquina <> 0) Then
            whereSql &= "and codigoM= '" & maquina & "' "
        End If

        If (chk_operador.Checked) Then
            If groupSql = "" Then
                groupSql = " GROUP BY "
            Else
                groupSql &= ","

            End If
            selectSql = "SELECT nit,nombres,SUM(alambron) as totalalambron,sum(reproceso) as totalreproceso,sum(amarres) as totalamarres,sum(no_conforme)as totalnoconforme,sum(alambron+reproceso) as totalproduccion,(select CASE WHEN (sum(alambron+reproceso) =0)THEN 0 ELSE((sum(no_conforme)/sum(alambron+reproceso)) * 100) END) as porcentaje"
            groupSql &= "nit,nombres"
        End If

        If (chk_maquina.Checked) Then
            If groupSql = "" Then
                groupSql = " GROUP BY "
            Else
                groupSql &= ","
            End If
            selectSql = "SELECT codigoM,maquina,SUM(alambron) as totalalambron,sum(reproceso) as totalreproceso,sum(amarres) as totalamarres,sum(no_conforme)as totalnoconforme,sum(alambron+reproceso) as totalproduccion,(select CASE WHEN (sum(alambron+reproceso) =0)THEN 0 ELSE((sum(no_conforme)/sum(alambron+reproceso)) * 100) END)  as porcentaje "
            groupSql &= "codigoM,maquina"
        End If
        If (chk_maquina_ope.Checked) Then
            If groupSql = "" Then
                groupSql = " GROUP BY "
            Else
                groupSql &= ","
            End If
            selectSql = "SELECT nit,nombres,codigoM,maquina,SUM(alambron) as totalalambron,sum(reproceso) as totalreproceso,sum(amarres) as totalamarres,sum(no_conforme)as totalnoconforme,sum(alambron+reproceso) as totalproduccion,(select CASE WHEN (sum(alambron+reproceso) =0)THEN 0 ELSE((sum(no_conforme)/sum(alambron+reproceso)) * 100) END)  as porcentaje "
            groupSql &= "codigoM,maquina,nit,nombres ORDER BY maquina"
        End If

        sql = selectSql & fromSql & whereSql & groupSql

        dt_consulta = obj_Ing_prodLn.listar_datatable(sql, "PRODUCCION")

        dtg_consulta2.DataSource = dt_consulta
        If chk_operador.Checked = False And chk_maquina.Checked = False And chk_maquina_ope.Checked = False Then
            dtg_consulta2.Columns("fecha").DefaultCellStyle.Format = "d"
        End If
        If chk_operador.Checked Or chk_maquina.Checked Then
            dtg_consulta2.Columns("porcentaje").DefaultCellStyle.Format = "N2"

        End If

    End Sub
    Private Sub totalizar()
        Dim sum As Double = 0
        Dim col As String = ""
        dt_consulta.Rows.Add()
        For j = 0 To dt_consulta.Columns.Count - 1
            If (dt_consulta.Columns(j).ColumnName = "kilos" Or dt_consulta.Columns(j).ColumnName = "presupuesto") Then
                For i = 0 To dt_consulta.Rows.Count - 2
                    If IsNumeric(dt_consulta.Rows(i).Item(j)) Then
                        sum += dt_consulta.Rows(i).Item(j)
                    End If
                Next
                dt_consulta.Rows(dt_consulta.Rows.Count - 1).Item(j) = sum
                sum = 0
            End If
        Next
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

    Private Sub chk_operador_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_operador.CheckedChanged
        If (chk_operador.Checked) Then
            chk_maquina.Checked = False
            chk_maquina_ope.Checked = False
        End If
    End Sub

    Private Sub chk_maquina_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_maquina.CheckedChanged
        If (chk_maquina.Checked) Then
            chk_operador.Checked = False
            chk_maquina_ope.Checked = False
        End If
    End Sub
    Private Sub guardarPpto()
        dtg_presupuesto.CurrentCell = Nothing
        If (validar_ppto()) Then
            Dim sql As String = "SELECT *  FROM J_desperdicios_ppto WHERE mes =" & cbo_mes.SelectedIndex + 1 & " AND ano = " & cbo_ano.Text
            If (obj_Ing_prodLn.consultValor(sql, "PRODUCCION") = "") Then
                guardar_presupuesto_total()
            Else
                Dim resp As Integer = 0
                resp = MessageBox.Show("Ya existe presupeusto para: " & cbo_mes.SelectedIndex + 1 & "-" & cbo_ano.Text & " desea sobre-escribirlo? ", "Modificar presupuesto", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If resp = 6 Then
                    guardar_presupuesto_total()
                Else
                    llenarDtg_ppto()
                End If
            End If

        Else
            MessageBox.Show("Verifique que los valores ingresados sean númericos    ", "Verifique!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
    Private Function validar_ppto() As Boolean
        Dim resp As Boolean = True
        For i = 0 To dtg_presupuesto.Rows.Count - 1
            If Not IsDBNull(dtg_presupuesto.Item("presupuesto", i).Value) Then
                If Not IsNumeric(dtg_presupuesto.Item("presupuesto", i).Value) Then
                    resp = False
                End If
            Else
                dtg_presupuesto.Item("presupuesto", i).Value = 0
            End If
        Next

        Return resp
    End Function
    Private Sub llenarDtg_ppto()
        dtg_presupuesto.DataSource = Nothing
        Dim dt As New DataTable
        Dim sql As String = "SELECT centro,descripcion " & _
                                 "FROM centros " & _
                                    "WHERE centro IN(1100,1200,2100,2117,2200,2300,2400,2500,2600,2800,3100,3200,3500,4100,4200,4300,5200,6200,6400)"
        dt = obj_op_simplesLn.listar_datatable(sql, "CORSAN")
        dt.Columns.Add("presupuesto", GetType(Double))
        dt.Columns.Add("detalle", GetType(Double))
        For i = 0 To dt.Rows.Count - 1
            dt.Rows(i).Item("detalle") = 0
        Next
        dtg_presupuesto.DataSource = dt
        formatoDtg_ppto()
    End Sub
    Private Sub formatoDtg_ppto()
        Dim tamano_letra As Single = 9.0!
        For i = 0 To dtg_presupuesto.Columns.Count - 1
            If (dtg_presupuesto.Columns(i).Name = "centro") Then
                dtg_presupuesto.Columns(i).ReadOnly = True
            ElseIf (dtg_presupuesto.Columns(i).Name = "descripcion") Then
                dtg_presupuesto.Columns(i).ReadOnly = True
            ElseIf (dtg_presupuesto.Columns(i).Name = "detalle") Then
                dtg_presupuesto.Columns(i).ReadOnly = True
            ElseIf (dtg_presupuesto.Columns(i).Name = "presupuesto") Then
                dtg_presupuesto.Columns(i).ReadOnly = False
            End If
        Next
        dtg_presupuesto.Columns("presupuesto").SortMode = DataGridViewColumnSortMode.NotSortable
        dtg_presupuesto.Columns("presupuesto").DefaultCellStyle.BackColor = Color.GreenYellow
    End Sub
    Private Sub guardar_presupuesto_total()
        dtg_presupuesto.CurrentCell = Nothing
        Dim listSql As New List(Of Object)
        Dim ano As Integer = cbo_ano.Text
        Dim mes As Integer = cbo_mes.SelectedIndex + 1
        Dim sql_gral As String = "INSERT INTO J_desperdicios_ppto (ano,mes,centro,ppto) VALUES (" & ano & "," & mes & " "
        Dim sql As String = ""
        Dim sql_delete As String = "DELETE FROM J_desperdicios_ppto WHERE tipo is null AND mes =" & cbo_mes.SelectedIndex + 1 & " AND ano = " & cbo_ano.Text & " "
        listSql.Add(sql_delete)
        For i = 0 To dtg_presupuesto.Rows.Count - 2
            If dtg_presupuesto.Item("detalle", i).Value < 1 Then
                sql = sql_gral & "," & dtg_presupuesto.Item("centro", i).Value & "," & dtg_presupuesto.Item("presupuesto", i).Value & ")"
                listSql.Add(sql)
            End If
        Next
        If (obj_Ing_prodLn.ExecuteSqlTransaction(listSql, "PRODUCCION")) Then
            MessageBox.Show("El registro se guardo en forma exitosa!", "Exito!", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Error al ingresar el registro, comuniquese con el area de sistemas", "Verifique!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Private Sub btn_guardar_detalle_Click(sender As Object, e As EventArgs) Handles btn_guardar_detalle.Click
        dtgDetalle.CurrentCell = Nothing
        Dim centro As Integer = dtg_presupuesto.Item("centro", fila_select).Value
        Dim listSql As New List(Of Object)
        Dim ano As Integer = cbo_ano.Text
        Dim mes As Integer = cbo_mes.SelectedIndex + 1
        Dim sql_gral As String = "INSERT INTO J_desperdicios_ppto (ano,mes,tipo,centro,ppto) VALUES (" & ano & "," & mes & " "
        Dim sql As String = ""
        Dim sql_delete As String = "DELETE FROM J_desperdicios_ppto WHERE mes =" & cbo_mes.SelectedIndex + 1 & " AND ano = " & cbo_ano.Text & " AND centro = " & centro
        Dim total As Double = 0
        listSql.Add(sql_delete)
        For i = 0 To dtgDetalle.Rows.Count - 1
            If IsNumeric(dtgDetalle.Item("presupuesto", i).Value) Then
                If dtgDetalle.Item("presupuesto", i).Value > 0 Then
                    sql = sql_gral & "," & dtgDetalle.Item("tipo", i).Value & "," & centro & "," & dtgDetalle.Item("presupuesto", i).Value & ")"
                    listSql.Add(sql)
                    total += dtgDetalle.Item("presupuesto", i).Value
                End If
            End If
        Next
        If (obj_Ing_prodLn.ExecuteSqlTransaction(listSql, "PRODUCCION")) Then
            MessageBox.Show("El registro se guardo en forma exitosa!", "Exito!", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Error al ingresar el registro, comuniquese con el area de sistemas", "Verifique!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        If total > 0 Then
            dtg_presupuesto.Item("detalle", fila_select).Value = 2
            dtg_presupuesto.Item("presupuesto", fila_select).ReadOnly = True
        Else
            dtg_presupuesto.Item("presupuesto", fila_select).ReadOnly = False
            dtg_presupuesto.Item("detalle", fila_select).Value = 0
        End If
        dtg_presupuesto.Item("presupuesto", fila_select).Value = total
        groupDetalle.Visible = False
    End Sub
    Private Sub dtg_presupuesto_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dtg_presupuesto.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            With (Me.dtg_presupuesto)
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                End If
            End With
            fila_select = (dtg_presupuesto.CurrentCell.RowIndex)
        End If
    End Sub

    Private Sub itemDetalle_Click(sender As Object, e As EventArgs) Handles itemDetalle.Click
        If fila_select >= 0 Then
            If IsNumeric(dtg_presupuesto.Item("centro", fila_select).Value) Then
                groupDetalle.Visible = True
                llenar_tipos()
            End If
        End If
    End Sub
    Private Sub llenar_tipos()
        dtgDetalle.DataSource = Nothing
        dtgDetalle.DataSource = dt_tipos
        For i = 0 To dtgDetalle.Rows.Count - 1
            dtgDetalle.Item("presupuesto", i).Value = 0
        Next
        cargar_detalle()
        dtgDetalle.Columns("presupuesto").ReadOnly = False
        dtgDetalle.Columns("tipo").ReadOnly = False
        dtgDetalle.Columns("descripcion").ReadOnly = False
    End Sub
    Private Sub dtg_presupuesto_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dtg_presupuesto.CellValueChanged
        If (e.RowIndex <> dtg_presupuesto.Rows.Count - 1) Then
            If (dtg_presupuesto.Columns(e.ColumnIndex).Name = "presupuesto") Then
                If IsNumeric(dtg_presupuesto.Item(e.ColumnIndex, e.RowIndex).Value) Then
                    If (carga_comp) Then
                        ' totalizarDtg()
                    End If
                Else
                    carga_comp = False
                    dtg_presupuesto.Item(e.ColumnIndex, e.RowIndex).Value = 0
                    MessageBox.Show("Solo se permite el ingreso de valores numericos", "Verifique!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    carga_comp = True
                End If
            End If
        End If
    End Sub
    Private Sub consultar_ppto()
        dtg_presupuesto.Columns.Clear()
        Dim dt As New DataTable
        Dim ano As Integer = cbo_ano.Text
        Dim mes As Integer = cbo_mes.SelectedIndex + 1
        Dim sql As String = "SELECT c.centro,c.descripcion ,SUM( p.ppto) As presupuesto, COUNT(tipo) As detalle " & _
                             "FROM  CORSAN.dbo.centros c , J_desperdicios_ppto p " & _
                                "WHERE c.centro = p.centro AND p.mes = " & mes & "  AND p.ano = " & ano & " " & _
                                    "GROUP BY c.centro,c.descripcion "
        dt = obj_Ing_prodLn.listar_datatable(sql, "PRODUCCION")
        dtg_presupuesto.DataSource = dt
        formatoDtg_ppto()
        If dt.Rows.Count = 0 Then
            llenarDtg_ppto()
        Else
            For i = 0 To dtg_presupuesto.Rows.Count - 1
                If IsNumeric(dtg_presupuesto.Item("detalle", i).Value) Then
                    If dtg_presupuesto.Item("detalle", i).Value > 1 Then
                        dtg_presupuesto.Item("detalle", i).ReadOnly = True
                    End If
                Else
                    dtg_presupuesto.Item("detalle", i).Value = 1
                End If
            Next
        End If
    End Sub
    Private Sub cargar_resumen()
        Dim dt As New DataTable
        dt.Columns.Add("Criterio")
        dt.Columns.Add("Enero")
        dt.Columns.Add("Febrero")
        dt.Columns.Add("Marzo")
        dt.Columns.Add("Abril")
        dt.Columns.Add("Mayo")
        dt.Columns.Add("Junio")
        dt.Columns.Add("Julio")
        dt.Columns.Add("Agosto")
        dt.Columns.Add("Septiembre")
        dt.Columns.Add("Octubre")
        dt.Columns.Add("Noviembre")
        dt.Columns.Add("Diciembre")
        Dim Renglon As DataRow = dt.NewRow()
        Renglon("Criterio") = "FABRICADO TOTAL (kg)"
        dt.Rows.Add(Renglon)
        Renglon = dt.NewRow()
        Renglon("Criterio") = "CHATARRA (Kg)"
        dt.Rows.Add(Renglon)
        Renglon = dt.NewRow()
        Renglon("Criterio") = "PRODUCCIÓN - AMARRES Y CHATARRA"
        dt.Rows.Add(Renglon)
        Renglon = dt.NewRow()
        Renglon("Criterio") = "% CHATARRA VS FABRICADO"
        dt.Rows.Add(Renglon)
        Renglon = dt.NewRow()
        Renglon("Criterio") = "Meta"
        dt.Rows.Add(Renglon)
        dt = llenar_prod(dt)
        dt = llenar_chatarra(dt)
        dt = restar_chatarra(dt)
        dt = porcentaje_chatarra(dt)
        dtg_resumen.DataSource = dt
        formato_Miles()
    End Sub
    Private Function llenar_Prod(ByVal dt As DataTable)
        Dim centro As String = cbo_centro_resu.SelectedValue
        Dim sql_consulta As String
        Dim ano As String = Now.Year
        Dim mes As String = Now.Month
        Dim codigo As String = ""
        Dim kilos As String
        Dim kilos_convert As Double
        Select Case centro
            Case "2100"
                codigo = "AND (codigo like '33X%' or codigo like '22X%' or codigo like '33B%' or codigo like '22B%') AND tipo IN ('EPPT','EPPP')"
            Case "2300"
                codigo = " AND (codigo like '2CC%' or codigo like '2GR%' or codigo like '2CA%' or codigo like '2CK%' or codigo like '2CM%') AND descripcion NOT like '%electrosoldado%' AND tipo IN ('EPPP') "
            Case "5200"
                codigo = " AND (codigo like '33G%' or codigo like '22G%') AND tipo IN ('EPPT','EPPP') "
            Case "6400"
                codigo = " AND (codigo like '33G%' or codigo like '22G%') AND tipo IN ('EPPT','EPPP') "
            Case Else
                MessageBox.Show("El centro de costos seleccionado no esta diseñado para este informe", "Centro de costos no diseñado para este informe", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Function
        End Select
        For i As Integer = 1 To 12
            sql_consulta = "SELECT SUM(kilos) " & _
                    "FROM J_transacciones_kilos   " & _
                           "WHERE  ano =" & ano & " AND mes =" & i & "" & codigo & ""
            kilos = obj_op_simplesLn.consultValorTodo(sql_consulta, "CORSAN")
            If kilos = "" Then
                kilos = "0"
            End If
            kilos_convert = CDbl(kilos)
            For j = 0 To dt.Columns.Count - 1
                For r = 0 To dt.Rows.Count - 5
                    If i = 1 Then
                        dt.Rows(r).Item("Enero") = kilos_convert
                    End If
                    If i = 2 Then
                        dt.Rows(r).Item("Febrero") = kilos_convert
                    End If
                    If i = 3 Then
                        dt.Rows(r).Item("Marzo") = kilos_convert
                    End If
                    If i = 4 Then
                        dt.Rows(r).Item("Abril") = kilos_convert
                    End If
                    If i = 5 Then
                        dt.Rows(r).Item("Mayo") = kilos_convert
                    End If
                    If i = 6 Then
                        dt.Rows(r).Item("Junio") = kilos_convert
                    End If
                    If i = 7 Then
                        dt.Rows(r).Item("Julio") = kilos_convert
                    End If
                    If i = 8 Then
                        dt.Rows(r).Item("Agosto") = kilos_convert
                    End If
                    If i = 9 Then
                        dt.Rows(r).Item("Septiembre") = kilos_convert
                    End If
                    If i = 10 Then
                        dt.Rows(r).Item("Octubre") = kilos_convert
                    End If
                    If i = 11 Then
                        dt.Rows(r).Item("Noviembre") = kilos_convert

                    End If
                    If i = 12 Then
                        dt.Rows(r).Item("Diciembre") = kilos_convert
                    End If
                Next
            Next
        Next
        Return dt
#Disable Warning BC42105 ' La función 'llenar_Prod' no devuelve un valor en todas las rutas de acceso de código. Puede producirse una excepción de referencia NULL en tiempo de ejecución cuando se use el resultado.
    End Function
#Enable Warning BC42105 ' La función 'llenar_Prod' no devuelve un valor en todas las rutas de acceso de código. Puede producirse una excepción de referencia NULL en tiempo de ejecución cuando se use el resultado.
    Private Function llenar_chatarra(ByVal dt As DataTable)
        Dim centro As String = cbo_centro_resu.SelectedValue
        Dim sql_consulta As String
        Dim ano As String = Now.Year
        Dim mes As String = Now.Month
        Dim centros As String = ""
        Dim kilos As String
        Dim kilos_convert As Double
        Select Case centro
            Case "2100"
                centros = " AND centro=2100"
            Case "2300"
                centros = " AND centro=2300"
            Case "5200"
                centros = " AND centro=5200"
            Case "6400"
                centros = " AND centro=6400"
            Case Else
                MessageBox.Show("El centro de costos seleccionado no esta diseñado para este informe", "Centro de costos no diseñado para este informe", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Function
        End Select
        For i As Integer = 1 To 12
            sql_consulta = "SELECT SUM(kilos) " & _
                    " FROM J_v_desperdicios   " & _
                           "WHERE  year(fecha) =" & ano & " AND month(fecha) =" & i & "" & centros & ""
            kilos = obj_op_simplesLn.consultValorTodo(sql_consulta, "PRODUCCION")
            If kilos = "" Then
                kilos = "0"
            End If
            kilos_convert = CDbl(kilos)
            For j = 0 To dt.Columns.Count - 1
                For r = 1 To dt.Rows.Count - 4
                    If i = 1 Then
                        dt.Rows(r).Item("Enero") = kilos_convert
                    End If
                    If i = 2 Then
                        dt.Rows(r).Item("Febrero") = kilos_convert
                    End If
                    If i = 3 Then
                        dt.Rows(r).Item("Marzo") = kilos_convert
                    End If
                    If i = 4 Then
                        dt.Rows(r).Item("Abril") = kilos_convert
                    End If
                    If i = 5 Then
                        dt.Rows(r).Item("Mayo") = kilos_convert
                    End If
                    If i = 6 Then
                        dt.Rows(r).Item("Junio") = kilos_convert
                    End If
                    If i = 7 Then
                        dt.Rows(r).Item("Julio") = kilos_convert
                    End If
                    If i = 8 Then
                        dt.Rows(r).Item("Agosto") = kilos_convert
                    End If
                    If i = 9 Then
                        dt.Rows(r).Item("Septiembre") = kilos_convert
                    End If
                    If i = 10 Then
                        dt.Rows(r).Item("Octubre") = kilos_convert
                    End If
                    If i = 11 Then
                        dt.Rows(r).Item("Noviembre") = kilos_convert

                    End If
                    If i = 12 Then
                        dt.Rows(r).Item("Diciembre") = kilos_convert
                    End If
                Next
            Next
        Next
        Return dt
#Disable Warning BC42105 ' La función 'llenar_chatarra' no devuelve un valor en todas las rutas de acceso de código. Puede producirse una excepción de referencia NULL en tiempo de ejecución cuando se use el resultado.
    End Function
#Enable Warning BC42105 ' La función 'llenar_chatarra' no devuelve un valor en todas las rutas de acceso de código. Puede producirse una excepción de referencia NULL en tiempo de ejecución cuando se use el resultado.
    Private Function restar_chatarra(ByVal dt As DataTable)
        Dim fil_prod As DataRow = dt.Rows(0)
        Dim fil_chat As DataRow = dt.Rows(1)
        For i As Integer = 1 To 12
            For j = 0 To dt.Columns.Count - 1
                For r = 2 To dt.Rows.Count - 3
                    If i = 1 Then
                        dt.Rows(r).Item("Enero") = CDbl(fil_prod("Enero").ToString()) - CDbl(fil_chat("Enero").ToString())
                    End If
                    If i = 2 Then
                        dt.Rows(r).Item("Febrero") = CDbl(fil_prod("Febrero").ToString()) - CDbl(fil_chat("Febrero").ToString())
                    End If
                    If i = 3 Then
                        dt.Rows(r).Item("Marzo") = CDbl(fil_prod("Marzo").ToString()) - CDbl(fil_chat("Marzo").ToString())
                    End If
                    If i = 4 Then
                        dt.Rows(r).Item("Abril") = CDbl(fil_prod("Abril").ToString()) - CDbl(fil_chat("Abril").ToString())
                    End If
                    If i = 5 Then
                        dt.Rows(r).Item("Mayo") = CDbl(fil_prod("Mayo").ToString()) - CDbl(fil_chat("Mayo").ToString())
                    End If
                    If i = 6 Then
                        dt.Rows(r).Item("Junio") = CDbl(fil_prod("Junio").ToString()) - CDbl(fil_chat("Junio").ToString())
                    End If
                    If i = 7 Then
                        dt.Rows(r).Item("Julio") = CDbl(fil_prod("Julio").ToString()) - CDbl(fil_chat("Julio").ToString())
                    End If
                    If i = 8 Then
                        dt.Rows(r).Item("Agosto") = CDbl(fil_prod("Agosto").ToString()) - CDbl(fil_chat("Agosto").ToString())
                    End If
                    If i = 9 Then
                        dt.Rows(r).Item("Septiembre") = CDbl(fil_prod("Septiembre").ToString()) - CDbl(fil_chat("Septiembre").ToString())
                    End If
                    If i = 10 Then
                        dt.Rows(r).Item("Octubre") = CDbl(fil_prod("Octubre").ToString()) - CDbl(fil_chat("Octubre").ToString())
                    End If
                    If i = 11 Then
                        dt.Rows(r).Item("Noviembre") = CDbl(fil_prod("Noviembre").ToString()) - CDbl(fil_chat("Noviembre").ToString())

                    End If
                    If i = 12 Then
                        dt.Rows(r).Item("Diciembre") = CDbl(fil_prod("Diciembre").ToString()) - CDbl(fil_chat("Diciembre").ToString())
                    End If
                Next
            Next
        Next
        Return dt
    End Function
    Private Function porcentaje_chatarra(ByVal dt As DataTable)
        Dim fil_prod As DataRow = dt.Rows(0)
        Dim fil_chat As DataRow = dt.Rows(1)
        For i As Integer = 1 To 12
            For j = 0 To dt.Columns.Count - 1
                For r = 3 To dt.Rows.Count - 2
                    If i = 1 Then
                        dt.Rows(r).Item("Enero") = (CDbl(fil_chat("Enero").ToString()) * 100) / CDbl(fil_prod("Enero").ToString())
                    End If
                    If i = 2 Then
                        dt.Rows(r).Item("Febrero") = (CDbl(fil_chat("Febrero").ToString()) * 100) / CDbl(fil_prod("Febrero").ToString())
                    End If
                    If i = 3 Then
                        dt.Rows(r).Item("Marzo") = (CDbl(fil_chat("Marzo").ToString()) * 100) / CDbl(fil_prod("Marzo").ToString())
                    End If
                    If i = 4 Then
                        dt.Rows(r).Item("Abril") = (CDbl(fil_chat("Abril").ToString()) * 100) / CDbl(fil_prod("Abril").ToString())
                    End If
                    If i = 5 Then
                        dt.Rows(r).Item("Mayo") = (CDbl(fil_chat("Mayo").ToString()) * 100) / CDbl(fil_prod("Mayo").ToString())
                    End If
                    If i = 6 Then
                        dt.Rows(r).Item("Junio") = (CDbl(fil_chat("Junio").ToString()) * 100) / CDbl(fil_prod("Junio").ToString())
                    End If
                    If i = 7 Then
                        dt.Rows(r).Item("Julio") = (CDbl(fil_chat("Julio").ToString()) * 100) / CDbl(fil_prod("Julio").ToString())
                    End If
                    If i = 8 Then
                        dt.Rows(r).Item("Agosto") = (CDbl(fil_chat("Agosto").ToString()) * 100) / CDbl(fil_prod("Agosto").ToString())
                    End If
                    If i = 9 Then
                        dt.Rows(r).Item("Septiembre") = (CDbl(fil_chat("Septiembre").ToString()) * 100) / CDbl(fil_prod("Septiembre").ToString())
                    End If
                    If i = 10 Then
                        dt.Rows(r).Item("Octubre") = (CDbl(fil_chat("Octubre").ToString()) * 100) / CDbl(fil_prod("Octubre").ToString())
                    End If
                    If i = 11 Then
                        dt.Rows(r).Item("Noviembre") = (CDbl(fil_chat("Noviembre").ToString()) * 100) / CDbl(fil_prod("Noviembre").ToString())
                    End If
                    If i = 12 Then
                        dt.Rows(r).Item("Diciembre") = (CDbl(fil_chat("Diciembre").ToString()) * 100) / CDbl(fil_prod("Diciembre").ToString())
                    End If
                Next
            Next
        Next
        Return dt
    End Function
    Private Sub formato_Miles()
        For i = 0 To dtg_resumen.Rows.Count - 4
            For j = 1 To dtg_resumen.ColumnCount - 1
                If IsNumeric(dtg_resumen.Rows(i).Cells(j).Value) Then
                    dtg_resumen.Rows(i).Cells(j).Style.Format = "###,###"
                End If
            Next
        Next
    End Sub
    Private Function validar_resumen()
        Dim resp As Boolean = False
        If cbo_centro_resu.Text <> "Seleccione" Then
            If cboAnoConsulta.Text <> "Seleccione" Then
            Else
                MessageBox.Show("Seleccionar año de resumen", "Seleccionar año", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Else
            MessageBox.Show("Seleccionar centro de resumen", "Seleccionar centro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
#Disable Warning BC42105 ' La función 'validar_resumen' no devuelve un valor en todas las rutas de acceso de código. Puede producirse una excepción de referencia NULL en tiempo de ejecución cuando se use el resultado.
    End Function
#Enable Warning BC42105 ' La función 'validar_resumen' no devuelve un valor en todas las rutas de acceso de código. Puede producirse una excepción de referencia NULL en tiempo de ejecución cuando se use el resultado.
    Private Sub btn_cerrar_det_Click(sender As Object, e As EventArgs) Handles btn_cerrar_det.Click
        groupDetalle.Visible = False
    End Sub
    Private Sub chk_maquina_ope_CheckedChanged(sender As Object, e As EventArgs) Handles chk_maquina_ope.CheckedChanged
        If (chk_maquina_ope.Checked) Then
            chk_operador.Checked = False
            chk_maquina.Checked = False
        End If
    End Sub

    Private Sub btn_Cargar_Resumen_Click(sender As Object, e As EventArgs) Handles btn_Cargar_Resumen.Click
        cargar_resumen()
    End Sub
End Class