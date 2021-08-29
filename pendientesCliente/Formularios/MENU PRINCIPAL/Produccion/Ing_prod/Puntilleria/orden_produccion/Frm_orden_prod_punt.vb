Imports logicaNegocios
Imports accesoDatos
Imports entidadNegocios
Imports System.Data.SqlClient
Public Class Frm_orden_prod_punt
    Private obj_op_simplesLn As New Op_simpesLn
    Dim pcodigo As String
    Private objOpsimpesLn As New Op_simpesLn
    Private obj_Ing_prodLn As New Ing_prodLn
    Private consecutivoPpal As Double = 1
    Private numero_transaccion As Double
    Dim cargaComp As Boolean = False
    Dim usuario As UsuarioEn
    Private peso As String = ""
    Dim permiso As String = ""
    Dim resp_des As Boolean = False
    Dim nro_bobina As Integer
    Dim objTraslado_bodLn As New traslado_bodLn
    Dim obj_gestion_materia_primaLn As New Gestion_materia_primaLn
    Private objOrdenProdLn As New OrdenProdLn
    Private objOpSimplesLn As New Op_simpesLn
    Dim dtTerceros As DataTable
    Private objOperacionesDb As New OperacionesDb
    Dim materia_prima As String
    Public Sub main(ByVal usuario As UsuarioEn)
        Me.usuario = usuario
        If usuario.usuario.Trim <> "puntilleria" Then
            If usuario.permiso.Trim = "ADMIN" Or usuario.permiso.Trim = "CALIDAD" Then
                btnTrabajar.Visible = True
                If usuario.permiso.Trim = "CALIDAD" Then
                    If usuario.usuario.Trim <> "elizabeth.franco" Then
                        TblPpal.SelectedTab = Tbl_seleccion_orden
                        btnGuardar.Enabled = False
                        col_oculto.Visible = False
                        tbl_consulta_orden_prod_g.Parent = Nothing
                        tbl_orden_prod_g.Parent = Nothing

                        btn_tambores.Visible = False
                        btn_empaque.Visible = False
                        btn_generar_desperdicio.Visible = False
                    End If
                End If
            Else
                btnTrabajar.Visible = False
            End If
            btnregistrar_materia_prima.Visible = False
        Else
            TblPpal.SelectedTab = Tbl_seleccion_orden
            btnGuardar.Enabled = False
            col_oculto.Visible = False
            tbl_consulta_orden_prod_g.Parent = Nothing
            tbl_orden_prod_g.Parent = Nothing
            chk_no_conforme.Visible = False
            btn_no_conforme.Visible = False
            btn_chatarra.Visible = False
        End If
        cargaComp = True
        actualizarConsecutivoPpal(0)
    End Sub
    Private Sub FrmOrdenProdGalv_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargarDataSourse()
        Dim sql As String = "SELECT T.tipo,T.sw " &
                     "FROM  tipo_transacciones T " &
                           "WHERE T.tipo = 'SCLA' "
        cboTipo.DataSource = obj_Ing_prodLn.listar_datatable(sql, "CORSAN")
        cboTipo.ValueMember = "sw"
        cboTipo.DisplayMember = "tipo"
        cboTipo.SelectedIndex = 0

        sql = "SELECT id,CAST(peso As varchar ) As peso FROM J_orden_prod_punt_peso_cont "
        Dim dt As DataTable = objOpsimpesLn.listar_datatable(sql, "PRODUCCION")
        dt.Rows.Add()
        dt.Rows(dt.Rows.Count - 1).Item("peso") = "Seleccione"
        dt.Rows(dt.Rows.Count - 1).Item("id") = 0
        cbo_peso_contenedor.DataSource = dt
        cbo_peso_contenedor.DisplayMember = "peso"
        cbo_peso_contenedor.ValueMember = "peso"
        cbo_peso_contenedor.SelectedValue = "Seleccione"
        cargaComp = True
        TblPpal.SelectedTab = Tbl_seleccion_orden
    End Sub
    'Metodos que carga cada uno de los combo box
    Private Sub cargarDataSourse()

        Dim dt As New DataTable
        Dim row As DataRow
        Dim sql As String

        For i = Now.Year - 1 To Now.Year + 1
            cboAnoConsulta.Items.Add(i)
            'cboAñoProg.Items.Add(i)
            'cboAnoAdminOrden.Items.Add(i)
        Next
        'cboAñoProg.Text = Now.Year
        cboAnoConsulta.Text = Now.Year
        'cboAnoAdminOrden.Text = Now.Year
        dt = New DataTable
        sql = "select codigo, codigo + ' - ' + descripcion As descripcion  from referencias where codigo like '22%' AND ref_anulada = 'N'  "
        dt = obj_Ing_prodLn.listar_datatable(sql, "CORSAN")
        row = dt.NewRow
        row("codigo") = 0
        row("descripcion") = "Seleccione"
        dt.Rows.Add(row)
        cbo_mat_prima.DataSource = dt
        cbo_mat_prima.ValueMember = "codigo"
        cbo_mat_prima.DisplayMember = "descripcion"
        cbo_mat_prima.SelectedValue = 0

        dt = New DataTable
        sql = "select codigo, codigo + ' - ' + descripcion As descripcion from referencias where (codigo like '2CC%' or codigo like '2GR%' or codigo like '2CA%') AND ref_anulada = 'N'  "

        dt = obj_Ing_prodLn.listar_datatable(sql, "CORSAN")
        row = dt.NewRow
        row("codigo") = 0
        row("descripcion") = "Seleccione"
        dt.Rows.Add(row)
        cbo_prod_final.DataSource = dt
        cbo_prod_final.ValueMember = "codigo"
        cbo_prod_final.DisplayMember = "descripcion"
        cbo_prod_final.SelectedValue = 0

        'dt = New DataTable
        'sql = "SELECT nit,nombres FROM V_nom_personal_Activo_con_maquila WHERE centro in (2300,6400)  order by nombres"
        'dt = obj_Ing_prodLn.listar_datatable(sql, "CORSAN")
        'row = dt.NewRow
        'row("nit") = 0
        'row("nombres") = "Seleccione"
        'dt.Rows.Add(row)
        'cboOperariosG.DataSource = dt
        'cboOperariosG.ValueMember = "nit"
        'cboOperariosG.DisplayMember = "nombres"
        'cboOperariosG.SelectedValue = 0

        dt = New DataTable
        sql = "SELECT nit,nombres FROM V_nom_personal_Activo_con_maquila WHERE  nit in (select nit from control.dbo.D_empleados_sin_salida) and centro_planta in (2300)   order by nombres"
        dt = obj_Ing_prodLn.listar_datatable(sql, "CORSAN")
        row = dt.NewRow
        row("nit") = 0
        row("nombres") = "Seleccione"
        dt.Rows.Add(row)
        cbo_operario_desperdicio.DataSource = dt
        cbo_operario_desperdicio.ValueMember = "nit"
        cbo_operario_desperdicio.DisplayMember = "nombres"
        cbo_operario_desperdicio.SelectedValue = 0

        dt = New DataTable
        sql = "SELECT m.codigoM,m.nombre + '      -      ' + s.seccion As nombre FROM J_maquinas m , J_seccion_maquina_punt s WHERE s.maquina = m.codigoM AND m.tipoMAquina = 2"
        dt = obj_Ing_prodLn.listar_datatable(sql, "PRODUCCION")
        row = dt.NewRow
        row("codigoM") = 0
        row("nombre") = "Seleccione"
        dt.Rows.Add(row)
        cbo_maquina_des.DataSource = dt
        cbo_maquina_des.ValueMember = "codigoM"
        cbo_maquina_des.DisplayMember = "nombre"
        cbo_maquina_des.SelectedValue = 0

        dt = New DataTable
        sql = "SELECT Id_defecto,D_defecto FROM J_desperdicios_defecto WHERE Id_defecto IN(15,24,14,11,13,12,23,18,48,49,50) ORDER BY D_defecto"
        dt = obj_Ing_prodLn.listar_datatable(sql, "PRODUCCION")
        row = dt.NewRow
        row("Id_defecto") = 0
        row("D_defecto") = "Seleccione"
        dt.Rows.Add(row)
        cbo_defecto_repro.DataSource = dt
        cbo_defecto_repro.ValueMember = "Id_defecto"
        cbo_defecto_repro.DisplayMember = "D_defecto"
        cbo_defecto_repro.SelectedValue = 0

        dt = New DataTable
        sql = "SELECT Id_defecto,D_defecto FROM J_desperdicios_defecto WHERE Id_defecto IN(15,24,14,11,13,12,23,18,48,49,50) ORDER BY D_defecto"
        dt = obj_Ing_prodLn.listar_datatable(sql, "PRODUCCION")
        row = dt.NewRow
        row("Id_defecto") = 0
        row("D_defecto") = "Seleccione"
        dt.Rows.Add(row)
        cbo_defecto_desperdicio.DataSource = dt
        cbo_defecto_desperdicio.ValueMember = "Id_defecto"
        cbo_defecto_desperdicio.DisplayMember = "D_defecto"
        cbo_defecto_desperdicio.SelectedValue = 0

        dt = New DataTable
        sql = "SELECT nit,nombres FROM V_nom_personal_Activo_con_maquila WHERE  nit in (select nit from control.dbo.D_empleados_sin_salida) and (centro_planta = 2300 or centro_planta is null)  order by nombres"
        dt = obj_Ing_prodLn.listar_datatable(sql, "CORSAN")
        row = dt.NewRow
        row("nit") = 0
        row("nombres") = "Seleccione"
        dt.Rows.Add(row)
        cbo_operario_2.DataSource = dt
        cbo_operario_2.ValueMember = "nit"
        cbo_operario_2.DisplayMember = "nombres"
        cbo_operario_2.SelectedValue = 0


        'cboMesProg.DataSource = objOpsimpesLn.returnDtMeses()
        'cboMesProg.ValueMember = "numMes"
        'cboMesProg.DisplayMember = "nombMes"
        'cboMesProg.SelectedValue = Now.Month
        cboMesConsulta.DataSource = objOpsimpesLn.returnDtMeses()
        cboMesConsulta.ValueMember = "numMes"
        cboMesConsulta.DisplayMember = "nombMes"
        cboMesConsulta.SelectedValue = Now.Month
        'cboMesAdminOrden.DataSource = objOpsimpesLn.returnDtMeses()
        'cboMesAdminOrden.ValueMember = "numMes"
        'cboMesAdminOrden.DisplayMember = "nombMes"
        'cboMesAdminOrden.SelectedValue = Now.Month

        dt = New DataTable
        sql = "SELECT m.codigoM,m.nombre + '      -      ' + s.seccion As nombre FROM J_maquinas m , J_seccion_maquina_punt s WHERE s.maquina = m.codigoM AND m.tipoMAquina = 2"
        dt = obj_Ing_prodLn.listar_datatable(sql, "PRODUCCION")
        row = dt.NewRow
        row("codigoM") = 0
        row("nombre") = "Seleccione"
        dt.Rows.Add(row)
        cbo_maquina.DataSource = dt
        cbo_maquina.ValueMember = "codigoM"
        cbo_maquina.DisplayMember = "nombre"
        cbo_maquina.SelectedValue = 0

        dt = New DataTable
        sql = "select codigo,concat(codigo,' ',descripcion) as descripcion from referencias where (codigo like '2CC%' or codigo like '2GR%' or codigo like '2CA%') AND ref_anulada = 'N'  "
        dt = obj_Ing_prodLn.listar_datatable(sql, "CORSAN")
        row = dt.NewRow
        row("codigo") = 0
        row("descripcion") = "Seleccione"
        dt.Rows.Add(row)
        cbo_referencia_desp.DataSource = dt
        cbo_referencia_desp.ValueMember = "codigo"
        cbo_referencia_desp.DisplayMember = "descripcion"
        cbo_referencia_desp.SelectedValue = 0
    End Sub

    'Guardar infromacion en la tabla en una lista para despues guardar en la base de datos
    Private Function guardarConsol() As List(Of Object)
        Dim lisSql As New List(Of Object)
        Dim resp As Boolean = False
        Dim sql As String = ""
        Dim sqlGuardar As String = ""

        Dim prod_final As String = cbo_prod_final.SelectedValue
        Dim maquina As Integer = cbo_maquina.SelectedValue
        Dim cant_prog As String = txtCantProg.Text
        Dim origen As String = cbo_mat_prima.SelectedValue
        Dim mes As Integer = cbo_fec_orden.Value.Month
        Dim ano As Integer = cbo_fec_orden.Value.Year
        Dim notas As String = txtnota.Text
        Dim notas_auditoria As String = ""
        Dim fecha As String = objOpSimplesLn.cambiarFormatoFecha(cbo_fec_orden.Value)

        If consecutivoPpal = 0 Then
            notas_auditoria = "Creo:" & usuario.usuario & Now
            sql = "SELECT  MAX (consecutivo) FROM J_orden_prod_punt_enc"
            actualizarConsecutivoPpal(obj_Ing_prodLn.consultar_valor(sql, "PRODUCCION") + 1)
            sqlGuardar = "INSERT INTO J_orden_prod_punt_enc " &
                            "(consecutivo,maquina,origen,cant_prog,prod_final,nota,notas_auditoria,mes,ano,fecha_creacion) " &
                                "VALUES " &
                                        "(" & consecutivoPpal & " , " & maquina & ", '" & origen & "' ," & cant_prog & ",'" & prod_final & "' ,'" & notas & "','" & notas_auditoria & "'," & mes & " ," & ano & ",'" & fecha & "')"
            lisSql.Add(sqlGuardar)
        Else
            notas_auditoria = " - Modifico:" & usuario.usuario & Now
            sql = "UPDATE J_orden_prod_punt_enc SET " &
                 "origen =  '" & origen & "'" &
                    ",cant_prog =  " & cant_prog &
                ",prod_final = '" & prod_final & "'" &
                  ",maquina =  '" & maquina & "'" &
                    ",nota =  '" & notas & "' " &
                    ",notas_auditoria = (SELECT CASE WHEN notas_auditoria is null THEN '" & notas_auditoria & "' ELSE notas_auditoria + '" & notas_auditoria & "' END)" &
                    ",mes = '" & mes & "'" &
                ",ano =  '" & ano & "'" &
                " WHERE consecutivo=" & consecutivoPpal
            lisSql.Add(sql)
        End If
        Return lisSql
    End Function
    'validar que se ingrese toda la informacion a la orden
    Private Function validarEncabezado() As Boolean
        If (cbo_maquina.SelectedValue <> 0) Then
            If (cbo_mat_prima.SelectedValue <> "Seleccione") Then
                If (txtCantProg.Text <> "") Then
                    If (txtCantProg.Text > 0) Then
                        If (cbo_prod_final.SelectedValue <> "Seleccione") Then
                            'If (cboAñoProg.Text <> "Seleccione") Then
                            '    If (cboAñoProg.Text <> "Seleccione") Then
                            Return True
                            '    Else
                            '        MessageBox.Show("Ingrese un Mes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            '    End If
                            'Else
                            '    MessageBox.Show("Ingrese un Año", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            'End If
                        Else
                            MessageBox.Show("Ingrese un producto final", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    Else
                        MessageBox.Show("La cantidad programada no puede ser = 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Else
                    MessageBox.Show("Ingrese una cantidad programada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

            Else
                MessageBox.Show("Seleccione un codigo  de alambron de origen", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            MessageBox.Show("Seleccione una maquina", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        Return False
    End Function
    'se desencadena al dar click al boton guardar
    Private Sub btnGuardar_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If (validarEncabezado()) Then
            Dim listaSql As New List(Of Object)
            Dim resp As Boolean = False
            Dim frm As New Frm_solicitud_mp_puntilleria
            listaSql.AddRange(guardarConsol())
            resp = obj_Ing_prodLn.ExecuteSqlTransaction(listaSql, "PRODUCCION")
            If (resp) Then
                Dim solicitante As String = "890900160"
                Dim observaciones As String = "Pedido automatico para puntilleria desde el spic"
                Dim devolver As String = "N"
                frm.guardar_automatico(cbo_mat_prima.SelectedValue, txtCantProg.Text, cbo_fec_orden.Value.Month, cbo_fec_orden.Value.Year, solicitante, observaciones, devolver)
                MessageBox.Show("La orden fue guardada de forma exitosa! ", "Correcto!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                actualizarConsecutivoPpal(0)
                nuevo()
            Else
                MessageBox.Show("Error al ingresar El encabezado a la base de datos,verifique que todos los datos esten correctos ò comuniquese con el administrador del sistema!,NO SE GUARDO LA PLANILLA! ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub


    'Nuevo(): ESTE METODO SIRVE PARA LIMPIAR LOS CAMPOS

    Private Sub nuevo()

        cbo_prod_final.SelectedValue = 0
        txtCantProg.Text = ""
        cbo_mat_prima.SelectedValue = 0
        cbo_maquina.SelectedValue = 0
        'cboMesProg.SelectedValue = Now.Month
        'cboAñoProg.Text = Now.Year
        txtnota.Text = ""
    End Sub
    ''metodo qu actualiza el consecutivo principal
    Private Sub actualizarConsecutivoPpal(ByVal consecutivo As String)
        consecutivoPpal = consecutivo
    End Sub

    'recibe un codigo y se los asigna a un textbox
    Public Sub d_codigo(ByVal codigo As String)
        pcodigo = codigo
        cbo_prod_final.SelectedValue = pcodigo
    End Sub
    'carga la consulta de las ordenes de produccion existentes
    Private Sub cargarAdminProd(ByVal consecutivo As String)
        Dim fecIni As String = cboFechaIni.Value.ToString("yyyy-MM-dd")
        Dim fecFin As String = cboFechaFin.Value.ToString("yyyy-MM-dd")
        Dim WhereFec As String = ""
        Dim cont_C As Integer = 0
        Dim cont_S As Integer = 0
        Dim porce_cum As Double

        If fecFin = fecIni Then
            WhereFec = " and year(e.fecha_creacion) = " & CInt(cboFechaIni.Value.Year) & " and month(e.fecha_creacion)= " & CInt(cboFechaIni.Value.Month) & " and day(e.fecha_creacion)=" & CInt(cboFechaIni.Value.Day) & ""
        Else
            WhereFec = " and e.fecha_creacion >='" & fecIni & "' and e.fecha_creacion <='" & fecFin & "'"
        End If
        If (consecutivo <> "N/A") Then
            WhereFec += " AND consecutivo like '" & consecutivo & "%' "
        End If
        Dim sql As String = "SELECT e.consecutivo,s.seccion,m.nombre As maquina,e.origen,e.cant_prog,(select SUM(PESO) from J_orden_prod_punt_producto WHERE nro_orden=e.consecutivo AND no_conforme IS NULL and anular is null) as cant_lleva,e.prod_final,r.descripcion,e.nota,e.notas_auditoria,e.mes,e.ano,e.fecha_creacion,e.oculto,e.notas_liquidacion" &
                                " FROM J_orden_prod_punt_enc e, CORSAN.dbo.referencias r , j_maquinas m , J_seccion_maquina_punt s " &
                                    "WHERE s.maquina =  m.codigoM  AND m.codigoM = e.maquina AND e.prod_final = r.codigo  " & WhereFec
        dtg_consulta.DataSource = obj_Ing_prodLn.listar_datatable(sql, "PRODUCCION")
        dtg_consulta.Columns("prod_final").DefaultCellStyle = formatoNegrita()
        dtg_consulta.Columns("fecha_creacion").DefaultCellStyle.Format = "dd/MM/yyyy"
        Me.dtg_consulta.Columns("oculto").Visible = False
        For i = 0 To dtg_consulta.RowCount - 1
            If Not IsDBNull(dtg_consulta.Item("oculto", i).Value) Then
                If (dtg_consulta.Item("oculto", i).Value = 1) Then
                    dtg_consulta.Item(col_oculto.Name, i).Value = Spic.My.Resources.ok3
                End If
            End If
            If Not (IsDBNull(dtg_consulta.Item("cant_prog", i).Value) Or IsDBNull(dtg_consulta.Item("cant_lleva", i).Value)) Then
                If (dtg_consulta.Item("cant_lleva", i).Value >= dtg_consulta.Item("cant_prog", i).Value) Then
                    dtg_consulta.Rows(i).DefaultCellStyle.BackColor = Color.Red
                    cont_C = cont_C + 1
                End If
            End If
            cont_S = cont_S + 1
        Next
        For Each Row As DataGridViewRow In dtg_consulta.Rows
            If Mid(Row.Cells("prod_final").Value, 1, 2) = "22" Then
                Row.DefaultCellStyle.BackColor = Color.GreenYellow
            End If
        Next
        If dtg_consulta.Rows.Count > 0 Then
            porce_cum = (cont_C / cont_S) * 100
            porcen_header.Text = "El % cumplido es de:" & CInt(porce_cum)
        End If
        lbl_cumplidas.Text = "El total de ordenes cumplidas es:" & cont_C & ",de un total de:" & cont_S
        dtg_consulta.DataSource = totalizar_Admin()
        calcuPorcen()
        pintarTotalAdmin()
        dtg_consulta.AutoResizeColumns()
    End Sub
    'carga la consulta sobre las ordenes de produccion disponibles para trabajar
    Private Sub cargarPlanOperario()
        Dim ano As Integer = cboAnoConsulta.Text
        Dim mes As Integer = cboMesConsulta.SelectedValue
        Dim sql As String = "SELECT orden.consecutivo As num_orden,s.seccion,m.nombre As maquina,orden.prod_final As prod_final,r.descripcion,orden.origen As Materia_prima,(SELECT k.descripcion FROM CORSAN.dbo.referencias k WHERE  k.codigo = orden.origen)As desc_mp, orden.cant_prog as Cantidad,(SELECT (SELECT CASE WHEN (SUM(peso)IS NULL) THEN 0 ELSE SUM(peso) END) FROM J_orden_prod_punt_producto p WHERE p.nro_orden = orden.consecutivo) As Lleva ,(orden.cant_prog - (SELECT (SELECT CASE WHEN (SUM(peso)IS NULL) THEN 0 ELSE SUM(peso) END) FROM J_orden_prod_punt_producto p WHERE p.nro_orden = orden.consecutivo))As pendiente,orden.fecha_creacion " &
                                             ",orden.maquina AS mq FROM J_orden_prod_punt_enc orden ,CORSAN.dbo.referencias r , j_maquinas m ,J_seccion_maquina_punt s " &
                                        " WHERE s.maquina =  m.codigoM  AND m.codigoM = orden.maquina AND r.codigo = orden.prod_final AND (orden.oculto=0 or orden.oculto is null) AND orden.mes = " & mes & " AND orden.ano = " & ano &
                                                " ORDER BY s.seccion,orden.consecutivo  "
        dtgOperario.DataSource = objOpsimpesLn.listar_datatable(sql, "PRODUCCION")
        dtgOperario.Columns("prod_final").DefaultCellStyle = formatoNegrita()
        dtgOperario.Columns("Materia_prima").DefaultCellStyle = formatoNegrita()
        dtgOperario.Columns("pendiente").DefaultCellStyle = formatoNegrita()
        dtgOperario.Columns("maquina").DefaultCellStyle = formatoNegrita()
        dtgOperario.Columns("seccion").DefaultCellStyle = formatoNegrita()
        dtgOperario.Columns("mq").Visible = False
        dtgOperario.Columns("num_orden").HeaderText = "#"
        For i = 0 To dtgOperario.RowCount - 1
            Select Case dtgOperario.Item("seccion", i).Value
                Case "Sección A"
                    dtgOperario.Item("seccion", i).Style.BackColor = Color.Silver
                Case "Sección B"
                    dtgOperario.Item("seccion", i).Style.BackColor = Color.OrangeRed
                Case "Sección C"
                    dtgOperario.Item("seccion", i).Style.BackColor = Color.Gold
                Case "Sección D"
                    dtgOperario.Item("seccion", i).Style.BackColor = Color.LightGreen
                Case "Sección E"
                    dtgOperario.Item("seccion", i).Style.BackColor = Color.LightSeaGreen
                Case "Sección F"
                    dtgOperario.Item("seccion", i).Style.BackColor = Color.Violet
                Case "Sección G"
                    dtgOperario.Item("seccion", i).Style.BackColor = Color.Thistle
            End Select
        Next
        'pintar_operarios()
        dtgOperario.DataSource = totalizar_oper()
        pintartotal()
        dtgOperario.Columns("fecha_creacion").Visible = False
    End Sub
    Private Sub calcuPorcen()
        For Each row As DataGridViewRow In dtg_consulta.Rows
            Dim ppto_kilos As Double = row.Cells.Item("cant_prog").Value
            Dim kilos As Double
            If IsDBNull(row.Cells.Item("cant_lleva").Value) Then
                kilos = 0
            Else
                kilos = row.Cells.Item("cant_lleva").Value
            End If
            Dim convert As String
            Dim porcentaje As Double

            porcentaje = ((kilos * 100) / ppto_kilos)
            'row.DataGridView.Rows(row.Index).DefaultCellStyle.BackColor = Color.Tomato
            'If (porcentaje >= 90 And porcentaje <= 300) Then
            '    row.DataGridView.Rows(row.Index).DefaultCellStyle.BackColor = Color.SpringGreen
            'End If
            'If (porcentaje < 90 And porcentaje >= 50) Then
            '    row.DataGridView.Rows(row.Index).DefaultCellStyle.BackColor = Color.PaleGreen
            'End If
            'If (porcentaje < 50 And porcentaje >= 0) Then
            '    row.DataGridView.Rows(row.Index).DefaultCellStyle.BackColor = Color.Salmon
            'End If
            convert = porcentaje.ToString("0")
            row.Cells.Item("col_porcen").Value = convert & " %"
            If row.Index = (dtg_consulta.Rows.Count - 1) Then
                Exit For
            End If
        Next
    End Sub
    Public Sub pintarTotalAdmin()
        If dtg_consulta.Rows.Count > 0 Then
            dtg_consulta.Rows(dtg_consulta.Rows.Count - 1).DefaultCellStyle.BackColor = Color.Salmon
            dtg_consulta.Rows(dtg_consulta.Rows.Count - 1).DefaultCellStyle.Font = New Font(dtg_consulta.CurrentCell.InheritedStyle.Font, FontStyle.Bold)
        End If
    End Sub
    Public Sub pintar_operarios()
        Dim fecha As String = CDate(Now)
        Dim fecha_hora As String = objOpSimplesLn.cambiarFormatoFecha(Now)
        fecha_hora = CDate(fecha_hora & " 00:01:00")
        Dim fecha_6 As String = objOpSimplesLn.cambiarFormatoFecha(Now)
        fecha_6 = CDate(fecha_6 & " 05:45:00")
        Dim fecha_5_m As String = objOpSimplesLn.cambiarFormatoFecha(Now.AddDays(1))
        fecha_5_m = CDate(fecha_5_m & " 05:45:00")
        If CDate(fecha) >= CDate(fecha_6) And CDate(fecha) <= CDate(fecha_5_m) Then
            For Each Row As DataGridViewRow In dtgOperario.Rows
                fecha_hora = CDate(fecha_hora).AddDays(1)
                If CDate(fecha) >= CDate(fecha_hora) Then
                    fecha_hora = CDate(fecha_hora).AddDays(-1)
                    If Not IsDBNull(Row.Cells("fecha_creacion").Value) Then
                        If Row.Cells("fecha_creacion").Value = fecha_hora Then
                            Row.DefaultCellStyle.BackColor = Color.GreenYellow
                        Else
                            Row.DefaultCellStyle.BackColor = Color.LightCoral
                        End If
                    Else
                        Row.DefaultCellStyle.BackColor = Color.LightCoral
                    End If
                Else
                    fecha_hora = objOpSimplesLn.cambiarFormatoFecha(Now)
                    fecha_hora = fecha_hora & " 00:00:00"
                    If Not IsDBNull(Row.Cells("fecha_creacion").Value) Then
                        If Row.Cells("fecha_creacion").Value = CDate(fecha_hora) Then
                            Row.DefaultCellStyle.BackColor = Color.GreenYellow
                        Else
                            Row.DefaultCellStyle.BackColor = Color.LightCoral
                        End If
                    Else
                        Row.DefaultCellStyle.BackColor = Color.LightCoral
                    End If
                End If

                If IsDBNull(Row.Cells("prod_final").Value) = False Then
                    If Row.Cells("prod_final").Value.Contains("33B") Or Row.Cells("prod_final").Value.Contains("33X") Or Row.Cells("prod_final").Value.Contains("33R") Then
                        Row.DefaultCellStyle.BackColor = Color.GreenYellow
                    End If
                End If
            Next
        End If
    End Sub
    Private Function totalizar_Admin()
        Dim cant_prog As Double = 0
        Dim kilos As Double = 0
#Disable Warning BC42024 ' Variable local sin usar: 'costo_prod'.
        Dim costo_prod As Double
#Enable Warning BC42024 ' Variable local sin usar: 'costo_prod'.
#Disable Warning BC42024 ' Variable local sin usar: 'costo_prog'.
        Dim costo_prog As Double
#Enable Warning BC42024 ' Variable local sin usar: 'costo_prog'.
#Disable Warning BC42024 ' Variable local sin usar: 'costo_variacion'.
        Dim costo_variacion As Double
#Enable Warning BC42024 ' Variable local sin usar: 'costo_variacion'.
        Dim indice As Integer = 0
        Dim dt As DataTable = DirectCast(dtg_consulta.DataSource, DataTable)
        For Each row As DataRow In dt.Rows
            If row.Item("cant_prog") > 0 Then
                cant_prog += row.Item("cant_prog")
            End If
            If IsDBNull(row.Item("cant_lleva")) = False Then
                If row.Item("cant_lleva") > 0 Then
                    kilos += row.Item("cant_lleva")
                End If
            End If

            If indice = (dt.Rows.Count - 1) Then
                dt.Rows.Add()
                dt.Rows(dt.Rows.Count - 1).Item("maquina") = "TOTAL"
                dt.Rows(dt.Rows.Count - 1).Item("cant_prog") = cant_prog
                dt.Rows(dt.Rows.Count - 1).Item("cant_lleva") = kilos
                Exit For
            End If
            indice += 1
        Next
        Return dt
    End Function
    Private Function totalizar_oper()
        Dim cant_prog As Double = 0
        Dim lleva As Double = 0
        Dim pendiente As Double
        Dim indice As Integer = 0
        Dim dt As DataTable = DirectCast(dtgOperario.DataSource, DataTable)
        For Each row As DataRow In dt.Rows
            If row.Item("Cantidad") > 0 Then
                cant_prog += row.Item("Cantidad")
            End If
            If IsDBNull(row.Item("Lleva")) = False Then
                If row.Item("Lleva") > 0 Then
                    lleva += row.Item("Lleva")
                End If
            End If
            If IsDBNull(row.Item("pendiente")) = False Then
                If row.Item("pendiente") > 0 Then
                    pendiente += row.Item("pendiente")
                End If
            End If


            If indice = (dt.Rows.Count - 1) Then
                dt.Rows.Add()
                dt.Rows(dt.Rows.Count - 1).Item("maquina") = "TOTAL"
                dt.Rows(dt.Rows.Count - 1).Item("Cantidad") = cant_prog
                dt.Rows(dt.Rows.Count - 1).Item("Lleva") = lleva
                dt.Rows(dt.Rows.Count - 1).Item("pendiente") = pendiente
                Exit For
            End If
            indice += 1
        Next
        Return dt
    End Function
    Public Sub pintartotal()
        If dtg_consulta.Rows.Count > 0 Then
            dtg_consulta.Rows(dtg_consulta.Rows.Count - 1).DefaultCellStyle.BackColor = Color.Salmon
            dtg_consulta.Rows(dtg_consulta.Rows.Count - 1).DefaultCellStyle.Font = New Font(dtg_consulta.CurrentCell.InheritedStyle.Font, FontStyle.Bold)
        End If
    End Sub
    Private Sub cargarRollos()
        Dim fecha As String = objOpsimpesLn.cambiarFormatoFecha(DateTime.Now)
        'fecha = "2017-6-1"
        Dim sql As String = "SELECT orden.prod_final,p.peso,p.nro_orden,p.consecutivo_rollo,p.anular,p.trans,p.tipo_trans " &
                                            "FROM J_orden_prod_punt_producto p, J_orden_prod_punt_enc orden " &
                                                "WHERE no_conforme is null and fecha_hora >='" & fecha & "' and p.nro_orden = orden.consecutivo " &
                                                    "ORDER BY fecha_hora desc"
        dtgRollos.DataSource = objOpsimpesLn.listar_datatable(sql, "PRODUCCION")
        Me.dtgRollos.Columns("anular").Visible = False
        Me.dtgRollos.Columns("trans").Visible = False
        Me.dtgRollos.Columns("tipo_trans").Visible = False
        For Each Row As DataGridViewRow In dtgRollos.Rows
            If IsDBNull(Row.Cells("anular").Value) = False Then
                Row.DefaultCellStyle.BackColor = Color.Red
            End If
        Next
    End Sub

    Public Function formatoNegrita() As DataGridViewCellStyle
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold)
        Return DataGridViewCellStyle1
    End Function
    Private Sub dtg_consulta_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtg_consulta.CellContentClick
        Dim col As String = dtg_consulta.Columns(e.ColumnIndex).Name
        If (col = btnVerDetalle.Name) Then
            actualizarConsecutivoPpal(dtg_consulta.Item("consecutivo", dtg_consulta.CurrentCell.RowIndex).Value)
            cargarDatos()
            TblPpal.SelectedTab = tbl_orden_prod_g
        ElseIf (col = col_oculto.Name) Then
            Dim sql As String
            Dim bloqueo As String
            sql = "select oculto from J_orden_prod_punt_enc WHERE consecutivo = " & dtg_consulta.Item("consecutivo", dtg_consulta.CurrentCell.RowIndex).Value & ""
            bloqueo = objOpsimpesLn.consultValorTodo(sql, "PRODUCCION")
            If bloqueo = "" Then
                If (MessageBox.Show("Esta seguro que desea liquidar y ocultar la orden.Ya no se puede trabajar una orden liquidada, tenga en cuenta que si oculta una Orden no se vera en los computadores de Puntilleria", "ocultar Orden?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) = 6) Then
                    If (MessageBox.Show("Desea agregar nota de liquidación", "Nota al liquidar?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) = 6) Then
                        Dim frm As New frm_Bloquear_ordenes
                        frm.main(dtg_consulta.Item("consecutivo", dtg_consulta.CurrentCell.RowIndex).Value, "P")
                        frm.ShowDialog()
                    End If
                    Dim estado As Integer
                    Dim accion As String = ""
                    cargaComp = False

                    If Not IsDBNull(dtg_consulta.Item("oculto", e.RowIndex).Value) Then
                        If (dtg_consulta.Item("oculto", e.RowIndex).Value = 0) Then
                            estado = 1
                            dtg_consulta.Item(col, e.RowIndex).Value = Spic.My.Resources.ok3
                            dtg_consulta.Item("oculto", e.RowIndex).Value = estado
                        End If
                    Else
                        estado = 1
                        dtg_consulta.Item(col, e.RowIndex).Value = Spic.My.Resources.ok3
                        dtg_consulta.Item("oculto", e.RowIndex).Value = estado
                    End If
                    Dim consecutivo As Integer = dtg_consulta.Item("consecutivo", dtg_consulta.CurrentCell.RowIndex).Value
                    Dim nombre_usuario As String = usuario.usuario
                    sql = "UPDATE J_orden_prod_punt_enc SET oculto = " & estado & ",bloqueo= " & estado & ",notas_auditoria +=  '" & accion & " " & nombre_usuario & " " & Now.Date & "' WHERE consecutivo = " & consecutivo
                    If (objOpsimpesLn.ejecutar(sql, "PRODUCCION")) Then
                        MessageBox.Show("El rollo se " & accion & " en forma exitosa!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("Error al " & accion & " el rollo, comuniquese con el administrador del sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                    cargaComp = True
                End If
            Else
                MessageBox.Show("Una orden liquidada no se puede desbloquear", "Orden Liquidada", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        ElseIf (col = col_duplicar.Name) Then
            Dim frm As New frm_Duplicar
            frm.main(dtg_consulta.Item("consecutivo", e.RowIndex).Value, usuario.usuario, dtg_consulta.Item("prod_final", e.RowIndex).Value, dtg_consulta.Item("origen", e.RowIndex).Value, "P")
            frm.Show()
            cargarAdminProd(txtConsulNumOrd.Text)
        End If
    End Sub

    Private Sub cargarDatos()
        Dim sql As String = "SELECT prod_final,cant_prog,origen,mes,ano,nota,maquina " &
                              "FROM J_orden_prod_punt_enc WHERE consecutivo = " & consecutivoPpal
        Dim dt As DataTable = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")
        Dim tam As Integer = 7
        For i = 0 To dt.Rows.Count - 1
            cbo_maquina.SelectedValue = dt.Rows(i).Item("maquina")
            cbo_prod_final.SelectedValue = dt.Rows(i).Item("prod_final")
            txtCantProg.Text = dt.Rows(i).Item("cant_prog")
            cbo_mat_prima.SelectedValue = dt.Rows(i).Item("origen")
            'cboMesProg.SelectedValue = dt.Rows(i).Item("mes")
            'cboAñoProg.Text = dt.Rows(i).Item("ano")
            If Not IsDBNull(dt.Rows(i).Item("nota")) Then
                txtnota.Text = dt.Rows(i).Item("nota")
            End If
        Next
    End Sub
    Private Sub borrar_orden()
        Dim borrar As String
        borrar = "delete from J_orden_prod_punt_enc where consecutivo=" & consecutivoPpal & ""
        objOpsimpesLn.consultValorTodo(borrar, "PRODUCCION")
    End Sub

    Private Sub txtConsulNumOrd_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtConsulNumOrd.TextChanged
        If txtConsulNumOrd.Text <> "" Then
            cargarAdminProd(txtConsulNumOrd.Text)
        Else
            MsgBox("Ingrese un numero", vbOK)
        End If
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        actualizarConsecutivoPpal(0)
        nuevo()
        TblPpal.SelectedTab = tbl_orden_prod_g
    End Sub
    Private Sub cboMesConsulta_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If (cargaComp) Then
            cargarPlanOperario()
        End If
    End Sub
    Private Sub cboAnoConsulta_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If (cargaComp) Then
            cargarPlanOperario()
        End If
    End Sub
    Private Sub cboOperariosTurno_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If (cargaComp) Then
            cargarPlanOperario()
        End If
    End Sub

    Private Sub btnActOrdenes_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActOrdenes.Click
        cargarPlanOperario()
        cargarRollos()
    End Sub
    Private Sub dtgOperario_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgOperario.CellContentClick
        Dim col As String = dtgOperario.Columns(e.ColumnIndex).Name
        Dim fila As Integer = e.RowIndex
        If (fila >= 0) Then
            materia_prima = dtgOperario.Item("Materia_prima", fila).Value
            Dim num_orden_val As String = dtgOperario.Item("num_orden", fila).Value
            Dim sql As String = "select mes from J_orden_prod_punt_enc where consecutivo=" & num_orden_val & ""
            Dim val_mes_orden As Integer = CInt(objOpsimpesLn.consultValorTodo(sql, "PRODUCCION"))
            Dim val_mes_actual As Integer = Now.Month
            If val_mes_orden = val_mes_actual Then
                If (col = btnregistrar_materia_prima.Name) Then
                    If dtgOperario.Rows(fila).DefaultCellStyle.BackColor <> Color.LightCoral Then
                        TblPpal.Enabled = False
                        group_consumo.Enabled = True
                        group_consumo.Visible = True
                        txtCodigoLector.Focus()
                    Else
                        MessageBox.Show("No se puede trabajar ordenes que esten en color rojo! ", "Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                ElseIf (col = btnTrabajar.Name) Then
                    If dtgOperario.Rows(fila).DefaultCellStyle.BackColor <> Color.LightCoral Then
                        Gorup_desperdicio.Visible = True
                        desactivar()
                        nuevo_desperdicio()
                        If validar_tiempo_maquina(dtgOperario.Item("mq", fila).Value) Then
                            If resp_des Then
                                Gorup_desperdicio.Visible = False
                                activar()
                                lbl_doc_operario.Text = InputBox("Ingrese su numero de Documento.", "Ingrese motivo")
                                sql = "SELECT nombres FROM V_nom_personal_Activo_con_maquila WHERE  nit in (select nit from control.dbo.D_empleados_sin_salida) and (centro_planta in (2300,6400,2400) or centro_planta is null) and nit = '" & lbl_doc_operario.Text & "'"
                                lbl_nombre_operario.Text = objOpsimpesLn.consultValorTodo(sql, "CORSAN")
                                If lbl_nombre_operario.Text <> "" Then
                                    mqb = dtgOperario.Item("mq", fila).Value
                                    TblPpal.Enabled = False
                                    mostrar_group_registro()
                                    lblCodigoRegistro.Text = dtgOperario.Item("prod_final", fila).Value
                                    lblDescRegistro.Text = dtgOperario.Item("descripcion", fila).Value
                                    lbl_num_orden.Text = dtgOperario.Item("num_orden", fila).Value
                                    lblMaquina.Text = dtgOperario.Item("maquina", fila).Value
                                Else
                                    'MessageBox.Show("Ingrese un numero de documento Valido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                End If
                            Else
                                'MessageBox.Show("Primero debe ingresar el desperdicio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            End If
                        End If
                    Else
                        MessageBox.Show("No se puede trabajar ordenes que esten en color rojo! ", "Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                End If
            Else
                MessageBox.Show("No se puede trabajar ordenes de otro mes! ", "Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
    End Sub
    Dim mqb As Integer = 0
    Private Function validar_tiempo_maquina(ByVal maquina As Integer)
        Dim resp As Boolean = False
        Dim sql As String = "SELECT fec FROM JB_tiempos_mq_puntilleria WHERE mq=" & maquina
        Dim fecha_val As DateTime = Now.Year & "/" & Now.Month & "/" & Now.Day & " " & Now.Hour & ":" & Now.Minute & ":" & Now.Second
        Dim fecha_fin As DateTime = obj_Ing_prodLn.consultar_valor(sql, "PRODUCCION")
        If fecha_val >= fecha_fin Then
            resp = True
        Else
            MessageBox.Show("Podra registrar otro contenedor el dia:" & fecha_fin, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Return resp
    End Function

    Private Sub cboOperariosG_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If cargaComp Then
            cargarPlanOperario()
        End If
    End Sub

    'Private Sub chkpuerto1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkpuerto1.CheckedChanged
    '    If cargaComp Then
    '        Dim resul As MsgBoxResult
    '        If chkpuerto1.Checked = True Then
    '            resul = MessageBox.Show("Desea cambiar de pesa?", "Cambiar medio para pesar", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
    '            If resul = vbYes Then
    '                puerto_serial = 1
    '                chkpuerto2.Checked = False
    '            Else
    '                chkpuerto1.Checked = False
    '            End If
    '        Else
    '            chkpuerto2.Checked = True
    '        End If
    '    End If
    'End Sub

    Private Sub dtgRollos_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgRollos.CellClick
        Dim col As String = dtgRollos.Columns(e.ColumnIndex).Name
        Dim fila As Integer = e.RowIndex
        If fila >= 0 Then
            Dim rollo_anulado As Boolean = IsDBNull(dtgRollos.Item("anular", fila).Value())
            Dim orden As Integer
            Dim consecutivo As Integer
            Dim result As MsgBoxResult
            If (col = "btnanular") Then
                If rollo_anulado = True Then
                    result = MessageBox.Show("Desea anular la producción?", "Anular producción", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                    Dim anular As Integer = 1
                    Dim codigo As String = dtgRollos.Item("prod_final", fila).Value()
                    Dim bodega As String = objTraslado_bodLn.obtenerBodegaXcodigo(codigo)
                    Dim stock As Double = objOpSimplesLn.consultarStock(codigo, bodega)
                    Dim peso As Double = dtgRollos.Item("peso", fila).Value()
                    If result = vbYes Then
                        Dim motivo As String = InputBox("Ingrese motivo de anulación de la producción", "Ingrese motivo")
                        If motivo <> "" Then
                            If peso <= stock Then
                                motivo &= "-" & Now & "- " & lbl_doc_operario.Text
                                orden = dtgRollos.Item("nro_orden", fila).Value()
                                consecutivo = dtgRollos.Item("consecutivo_rollo", fila).Value()
                                Dim cod_barras As String = orden & "-" & consecutivo
                                If validarTransaccionEmpaque(cod_barras) Then
                                    Dim numero_trans As Double = dtgRollos.Item("trans", fila).Value()
                                    Dim tipo_trans As String = dtgRollos.Item("tipo_trans", fila).Value()
                                    Dim listSql As New List(Of Object)
                                    listSql.AddRange(objTraslado_bodLn.anularTransaccion(numero_trans, tipo_trans, motivo))
                                    If objOpsimpesLn.ExecuteSqlTransaction(listSql) Then
                                        Dim sql As String = "UPDATE J_orden_prod_punt_producto SET notas = '" & motivo & " - " & Now.Date & "' , anular=" & anular & " where nro_orden=" & orden & " and consecutivo_rollo=" & consecutivo & ""
                                        If (objOpsimpesLn.ejecutar(sql, "PRODUCCION") > 0) Then
                                            cargarRollos()
                                            MessageBox.Show("Producto anulado en forma correcta", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                            sql = "SELECT maquina FROM J_orden_prod_punt_enc WHERE consecutivo = " & orden
                                            Dim maq As Integer = obj_Ing_prodLn.consultar_valor(sql, "PRODUCCION")
                                            sql = "UPDATE JB_tiempos_mq_puntilleria SET fec = GETDATE() WHERE mq=" & maq
                                            obj_Ing_prodLn.ejecutar(sql, "PRODUCCION")
                                        End If
                                    End If
                                End If
                            Else
                                MessageBox.Show("El producto a eliminar supera el stock en la bodega! ", "No hay stock", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            End If
                        End If
                    End If
                Else
                    MessageBox.Show("El producto ya ha sido anulado! ", "Anulado!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End If
        End If
    End Sub
    Private Function validarTransaccionEmpaque(ByVal consecutivo As String) As Boolean
        Dim resp As Boolean = False
        Dim oden_produccion As String = obj_gestion_materia_primaLn.extraerDatoCodigoBarrasPuntilleria("orden_produccion", consecutivo)
        Dim id_rollo As String = obj_gestion_materia_primaLn.extraerDatoCodigoBarrasPuntilleria("id_rollo", consecutivo)
        Dim sqlTransaccion = "Select sppp FROM J_orden_prod_punt_producto  WHERE  nro_orden =" & oden_produccion & " And consecutivo_rollo = " & id_rollo
        If (objOperacionesDb.consultValor(sqlTransaccion, "PRODUCCION") <> "") Then
            MessageBox.Show("El producto ya fue enviado para empaque", "Producto ya enviado para empaque", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            resp = True
        End If
        Return resp
    End Function
    Private Sub btn_transaccion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_transaccion_consumo.Click
        If (validarTransaccion()) Then
            Application.DoEvents()
            realizar_transaccion_consumo()
            Application.DoEvents()
        End If
    End Sub

    Private Function validarTransaccion() As Boolean
        Using New Centered_MessageBox(Me)
            If (lblCodigo.Text <> "") Then
                If (txtKilos.Text <> "") Then
                    If (cboTipo.Text <> "Seleccione") Then
                        If (obj_Ing_prodLn.existeCodigo(lblCodigo.Text)) Then
                            If IsNumeric(txtKilos.Text) Then
                                If (Convert.ToDouble(txtKilos.Text) > 0) Then
                                    If (obj_Ing_prodLn.existeTipoTransaccion(cboTipo.Text)) Then
                                        If txtCodigoLector.Text <> "" Then
                                            If lblCodigo.Text.ToUpper Like "22G*" Then
                                                If validarCodigoBarrasGalv(txtCodigoLector.Text) Then
                                                    Return True
                                                Else
                                                    MessageBox.Show("El código de barras no se encuentra asignado", "Código de barras no asignado", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                                End If
                                            Else
                                                If validarCodigoBarras(txtCodigoLector.Text) Then
                                                    Return True
                                                Else
                                                    MessageBox.Show("El código de barras no se encuentra asignado", "Código de barras no asignado", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                                End If
                                            End If
                                        Else
                                            MessageBox.Show("No se leyo ningun código de barras", "verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                        End If
                                    Else
                                        MessageBox.Show("No existe el tipo de transacción! ", "verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    End If
                                Else
                                    MessageBox.Show("Los kilos no pueden ser negativos ó iguales a (0) ", "verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                End If

                            Else
                                MessageBox.Show("Verifique que el campo 'KILOS' sea un número y no contenga letras! ", "verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End If
                        Else
                            MessageBox.Show("El código ingresado no existe,verifique! ", "verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    Else
                        MessageBox.Show("Falta el TIPO de transacción", "verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Else
                    MessageBox.Show("Faltan los kilos ", "verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                MessageBox.Show("Falta el CÓDIGO ", "verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Using
        Return False
    End Function
    Private Function validarCodigoBarras(ByVal consecutivo As String) As Boolean
        Dim resp As Boolean = False
        Dim consecutivo_materia_prima As String = obj_gestion_materia_primaLn.extraerDatoCodigoBarras("num_consecutivo", consecutivo)
        Dim id_detalle As String = obj_gestion_materia_primaLn.extraerDatoCodigoBarras("detalle", consecutivo)
        Dim id_rollo As String = obj_gestion_materia_primaLn.extraerDatoCodigoBarras("id_rollo", consecutivo)
        If consecutivo_materia_prima <> "" And id_rollo <> "" And id_detalle <> "" Then
            Dim sql As String = "select consecutivo from J_rollos_tref WHERE cod_orden =" & consecutivo_materia_prima & " AND id_detalle = " & id_detalle & " AND id_rollo = " & id_rollo
            Dim id As String = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")
            If id <> "" Then
                resp = True
            End If
        End If
        If resp = False Then
            Using New Centered_MessageBox(Me)
                MessageBox.Show("Intenete leerlo nuevamente", "Problemas con el tiquete", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Using

        End If
        Return resp
    End Function
    Private Function validarCodigoBarrasGalv(ByVal consecutivo As String) As Boolean
        Dim resp As Boolean = False
        Dim nro_orden As String = obj_gestion_materia_primaLn.extraerDatoCodigoBarrasGalvanizado("nro_orden", consecutivo)
        Dim id_rollo As String = obj_gestion_materia_primaLn.extraerDatoCodigoBarrasGalvanizado("id_rollo", consecutivo)
        If nro_orden <> "" And id_rollo <> "" Then
            Dim sql As String = "SELECT nro_orden FROM D_rollo_galvanizado_f WHERE nro_orden =" & nro_orden & " AND consecutivo_rollo = " & id_rollo
            Dim id As String = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")
            If id <> "" Then
                resp = True
            End If
        End If
        If resp = False Then
            Using New Centered_MessageBox(Me)
                MessageBox.Show("Intenete leerlo nuevamente", "Problemas con el tiquete", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Using

        End If
        Return resp
    End Function
    Private Function validarProductoTamboreado(ByVal consecutivo As String) As Boolean
        Dim resp As Boolean = False
        Dim numero_orden As String = obj_gestion_materia_primaLn.extraerDatoCodigoBarrasPuntilleria("oden_produccion", consecutivo)
        Dim id_rollo As String = obj_gestion_materia_primaLn.extraerDatoCodigoBarrasPuntilleria("id_rollo", consecutivo)
        If numero_orden <> "" And id_rollo <> "" Then
            Dim sql As String = "SELECT nro_orden FROM J_orden_prod_punt_producto WHERE tamboreado IS NOT NULL AND nro_orden =" & numero_orden & " AND consecutivo_rollo = " & id_rollo
            Dim id As String = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")
            If id <> "" Then
                resp = True
            End If
        End If
        Return resp
    End Function
    Private Function validarProductoAnulado(ByVal consecutivo As String) As Boolean
        Dim resp As Boolean = True
        Dim numero_orden As String = obj_gestion_materia_primaLn.extraerDatoCodigoBarrasPuntilleria("oden_produccion", consecutivo)
        Dim id_rollo As String = obj_gestion_materia_primaLn.extraerDatoCodigoBarrasPuntilleria("id_rollo", consecutivo)
        If numero_orden <> "" And id_rollo <> "" Then
            Dim sql As String = "SELECT nro_orden FROM J_orden_prod_punt_producto WHERE anular IS NOT NULL AND nro_orden =" & numero_orden & " AND consecutivo_rollo = " & id_rollo
            Dim id As String = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")
            If id <> "" Then
                resp = False
            End If
        End If
        Return resp
    End Function
    Private Function validar_no_conforme(ByVal consecutivo As String) As Boolean
        Dim resp As Boolean = True
        Dim numero_orden As String = obj_gestion_materia_primaLn.extraerDatoCodigoBarrasPuntilleria("oden_produccion", consecutivo)
        Dim id_rollo As String = obj_gestion_materia_primaLn.extraerDatoCodigoBarrasPuntilleria("id_rollo", consecutivo)

        If numero_orden <> "" And id_rollo <> "" Then
            Dim sql As String = "SELECT no_conforme FROM J_orden_prod_punt_producto WHERE nro_orden =" & numero_orden & " AND consecutivo_rollo = " & id_rollo
            Dim id As String = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")
            If id <> "" Then
                resp = False
            End If
        End If

        Return resp
    End Function
    Private Function validarCodigoBarrasPuntilleria(ByVal consecutivo As String) As Boolean
        Dim resp As Boolean = False
        Dim consecutivo_materia_prima As String = obj_gestion_materia_primaLn.extraerDatoCodigoBarrasPuntilleria("orden_produccion", consecutivo)
        Dim id_rollo As String = obj_gestion_materia_primaLn.extraerDatoCodigoBarrasPuntilleria("id_rollo", consecutivo)
        If consecutivo_materia_prima <> "" And id_rollo <> "" Then
            Dim sql As String = "select nro_orden from J_orden_prod_punt_producto WHERE nro_orden =" & consecutivo_materia_prima & " AND consecutivo_rollo = " & id_rollo
            Dim id As String = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")
            If id <> "" Then
                resp = True
            End If
        End If
        If resp = False Then
            Using New Centered_MessageBox(Me)
                MessageBox.Show("Intenete leerlo nuevamente", "Problemas con el tiquete", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Using
        End If
        Return resp
    End Function
    Private Sub realizar_transaccion_consumo()
        Using New Centered_MessageBox(Me)
            Dim resp_transaccion As Boolean = False
            Dim tipo As String = cboTipo.Text
            Dim notas As String = "SPIC traslado(HandHeld) "
            Dim peso As Double = Convert.ToDouble(txtKilos.Text)
            Dim codigo As String = Trim(lblCodigo.Text)
            Dim bodega As String = 12
            Dim dFec As Date = Now
            Dim consecutivo As String = txtCodigoLector.Text
            Dim listTransaccion_corsan As New List(Of Object)
            Dim sql As String
            Dim dt As New DataTable
            Dim modelo As String = "01"
            dt.Columns.Add("codigo")
            dt.Columns.Add("cantidad")
            dt.Rows.Add()
            dt.Rows(dt.Rows.Count - 1).Item("codigo") = codigo
            dt.Rows(dt.Rows.Count - 1).Item("cantidad") = peso
            Dim stock As Double = objOpSimplesLn.consultarStock(codigo, bodega)
            If peso <= stock Then
                listTransaccion_corsan.AddRange(transaccion(dt, tipo, bodega, modelo))
                If materia_prima.ToUpper Like "22G*" Then
                    Dim nro_orden As String = obj_gestion_materia_primaLn.extraerDatoCodigoBarrasGalvanizado("nro_orden", consecutivo)
                    Dim id_rollo As String = obj_gestion_materia_primaLn.extraerDatoCodigoBarrasGalvanizado("id_rollo", consecutivo)
                    sql = "update D_rollo_galvanizado_f set saga=" & numero_transaccion & " where  nro_orden =" & nro_orden & "  AND consecutivo_rollo =" & id_rollo
                Else
                    Dim consecutivo_materia_prima As String = obj_gestion_materia_primaLn.extraerDatoCodigoBarras("num_consecutivo", consecutivo)
                    Dim id_detalle As String = obj_gestion_materia_primaLn.extraerDatoCodigoBarras("detalle", consecutivo)
                    Dim id_rollo As String = obj_gestion_materia_primaLn.extraerDatoCodigoBarras("id_rollo", consecutivo)
                    sql = "update J_rollos_tref set scla=" & numero_transaccion & " where  id_detalle =" & id_detalle & "  AND id_rollo =" & id_rollo & " and cod_orden=" & consecutivo_materia_prima & ""
                End If
                If obj_Ing_prodLn.ExecuteSqlTransaction(listTransaccion_corsan, "CORSAN") Then
                    objOperacionesDb.ejecutar(sql, "PRODUCCION")
                End If
                MessageBox.Show("El rollo ha sido gastado del inventario", "Rollo gastado", MessageBoxButtons.OK, MessageBoxIcon.Information)
                group_consumo.Visible = False
                TblPpal.Enabled = True
                leer_nuevo()
            Else
                Using New Centered_MessageBox(Me)
                    MessageBox.Show("No hay stock disponible", "Sin stock", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End Using
            End If
        End Using
    End Sub
    Private Function transaccion(ByVal datacodigo As DataTable, ByVal tipo As String, ByVal bodega As Integer, ByVal modelo As String) As List(Of Object)
        Dim listSql As New List(Of Object)
        Dim dFec As Date = Now
        Dim usuario As String = lbl_doc_operario.Text
        Dim notas As String = "SPIC fecha:" & Now & " usuario:" & usuario
        numero_transaccion = objOrdenProdLn.mover_consecutivo(tipo)
        listSql = objTraslado_bodLn.listaTransaccionDatable(numero_transaccion, datacodigo, bodega, dFec, notas, usuario, tipo, modelo)
        Return listSql
    End Function
    Private Function transaccion_no_conforme(ByVal codigo As String, ByVal bodega_org As String, ByVal bodega_destino As String, ByVal cantidad As Double, ByVal tipo As String, ByVal modelo As String, ByVal costo_kilo As Double) As List(Of Object)
        Dim listSql As New List(Of Object)
        Dim dFec As Date = Now
        Dim usuario As String = lbl_doc_operario.Text
        Dim notas As String = "SPIC fecha:" & Now & " usuario:" & usuario
        numero_transaccion = objOrdenProdLn.mover_consecutivo(tipo)
        listSql = objTraslado_bodLn.listaTransaccionDatable_traslado_bodega(numero_transaccion, codigo, bodega_org, bodega_destino, dFec, notas, usuario, cantidad, tipo, modelo, costo_kilo)
        Return listSql
    End Function
    Private Sub cboTipo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipo.SelectedIndexChanged
        If (cargaComp) Then
            btnGuardar.Focus()
        End If
    End Sub
    Private Sub cboTipo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboTipo.KeyPress
        e.KeyChar = ""
    End Sub
    Private Sub cboTipo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTipo.TextChanged
        If (cargaComp And Trim(cboTipo.Text).Length > 2) Then
            If (obj_Ing_prodLn.existeTipoTransaccion(cboTipo.Text)) Then
                imgTipo.Image = Spic.My.Resources.ok3
            Else
                imgTipo.Image = Spic.My.Resources._1371750041_14125
            End If
        End If
    End Sub
    Private Sub btn_cerrar_consumo_Click(sender As Object, e As EventArgs) Handles btn_cerrar_consumo.Click
        TblPpal.Enabled = True
        group_consumo.Visible = False
        leer_nuevo()
    End Sub
    Private Sub leer_nuevo()
        cargaComp = False
        lblCodigo.Text = "LEA CÓDIGO"
        lblDescipcion.Text = "LEA CÓDIGO"
        txtCodigoLector.Text = ""
        txtCodigoLector.ForeColor = Color.DarkGray
        txtCodigoLector.Focus()
        cargaComp = True
    End Sub

    Private Sub btnGuardar_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGuardar.Enter
        txtCodigoLector.BackColor = Color.Green
    End Sub
    Private Sub txtCodigoLector_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodigoLector.Leave
        txtCodigoLector.BackColor = Color.Red
    End Sub

    Private Sub txtCodigoLector_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodigoLector.Enter
        txtCodigoLector.BackColor = Color.Green
        txtCodigoLector.Text = ""
    End Sub

    Private Sub txtCodigoLector_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigoLector.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            txtCodigoLector.Text = Replace(txtCodigoLector.Text, "'", "-")
            Dim consecutivo As String = txtCodigoLector.Text
            If materia_prima.ToUpper Like "22G*" Then
                If validarCodigoBarrasGalv(consecutivo) Then
                    If validarTrasladoGalv(consecutivo) Then
                        Dim nro_orden As String = obj_gestion_materia_primaLn.extraerDatoCodigoBarrasGalvanizado("nro_orden", consecutivo)
                        Dim id_rollo As String = obj_gestion_materia_primaLn.extraerDatoCodigoBarrasGalvanizado("id_rollo", consecutivo)
                        Dim sql_codigo As String = "select e.final_galv " &
                                                     "FROM D_rollo_galvanizado_f r , D_orden_pro_galv_enc e " &
                                                            "WHERE e.consecutivo_orden_G = r.nro_orden AND r.nro_orden=" & nro_orden & " AND r.consecutivo_rollo =" & id_rollo
                        Dim sql_peso As String = "select r.peso " &
                                                     "FROM D_rollo_galvanizado_f r , D_orden_pro_galv_enc e " &
                                                            "WHERE e.consecutivo_orden_G = r.nro_orden AND r.nro_orden=" & nro_orden & " AND r.consecutivo_rollo =" & id_rollo
                        Dim peso As String = objOpSimplesLn.consultValorTodo(sql_peso, "PRODUCCION")
                        Dim codigo As String = objOpSimplesLn.consultValorTodo(sql_codigo, "PRODUCCION")
                        codigo = codigo.ToUpper
                        materia_prima = materia_prima.ToUpper
                        If codigo = materia_prima Then
                            Dim stock As Double = objOpSimplesLn.consultarStock(codigo, 12)
                            If peso <= stock Then
                                lblCodigo.Text = codigo
                                lblDescipcion.Text = objOpSimplesLn.getDescripcionCodigo(codigo)
                                txtKilos.Text = peso
                                txtCodigoLector.ForeColor = Color.Black
                            Else
                                Using New Centered_MessageBox(Me)
                                    MessageBox.Show("No hay stock disponible", "Sin stock", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                End Using
                            End If
                        Else
                            Using New Centered_MessageBox(Me)
                                MessageBox.Show("El código de alambre no pertenece a la orden", "Código no pertenece a la orden", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End Using
                            leer_nuevo()
                        End If
                    Else
                        leer_nuevo()
                    End If
                End If
            Else
                If validarCodigoBarras(consecutivo) Then
                    If validarTraslado(consecutivo) Then
                        Dim consecutivo_materia_prima As String = obj_gestion_materia_primaLn.extraerDatoCodigoBarras("num_consecutivo", consecutivo)
                        Dim id_detalle As String = obj_gestion_materia_primaLn.extraerDatoCodigoBarras("detalle", consecutivo)
                        Dim id_rollo As String = obj_gestion_materia_primaLn.extraerDatoCodigoBarras("id_rollo", consecutivo)
                        Dim sql_codigo As String = "select O.prod_final " &
                                                        "FROM J_orden_prod_tef O join J_rollos_tref R on R.cod_orden=O.consecutivo " &
                                                               "WHERE O.consecutivo =" & consecutivo_materia_prima & " AND R.id_detalle =" & id_detalle & "  AND R.id_rollo =" & id_rollo & ""
                        Dim sql_peso As String = "SELECT R.peso FROM J_orden_prod_tef O join J_rollos_tref R on R.cod_orden=O.consecutivo" &
                                           " WHERE peso IS NOT NULL AND O.consecutivo =" & consecutivo_materia_prima & " AND R.id_detalle = " & id_detalle & " AND R.id_rollo=" & id_rollo & ""
                        Dim peso As Double = objOpSimplesLn.consultValorTodo(sql_peso, "PRODUCCION")
                        Dim codigo As String = objOpSimplesLn.consultValorTodo(sql_codigo, "PRODUCCION")
                        codigo = codigo.ToUpper
                        materia_prima = materia_prima.ToUpper
                        If codigo = materia_prima Then
                            Dim stock As Double = objOpSimplesLn.consultarStock(codigo, 12)
                            If peso <= stock Then
                                lblCodigo.Text = codigo
                                lblDescipcion.Text = objOpSimplesLn.getDescripcionCodigo(codigo)
                                txtKilos.Text = peso
                                txtCodigoLector.ForeColor = Color.Black
                            Else
                                Using New Centered_MessageBox(Me)
                                    MessageBox.Show("No hay stock disponible", "Sin stock", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                End Using
                            End If
                        Else
                            Using New Centered_MessageBox(Me)
                                MessageBox.Show("El código de alambre no pertenece a la orden", "Código no pertenece a la orden", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End Using
                            leer_nuevo()
                        End If
                    Else
                        leer_nuevo()
                    End If
                End If
            End If
        ElseIf e.KeyChar = "." Then
            e.KeyChar = "-"
        End If

    End Sub
    Private Function validarTraslado(ByVal consecutivo As String) As Boolean
        Dim resp As Boolean = False
        Dim consecutivo_materia_prima As String = obj_gestion_materia_primaLn.extraerDatoCodigoBarras("num_consecutivo", consecutivo)
        Dim id_detalle As String = obj_gestion_materia_primaLn.extraerDatoCodigoBarras("detalle", consecutivo)
        Dim id_rollo As String = obj_gestion_materia_primaLn.extraerDatoCodigoBarras("id_rollo", consecutivo)
        Dim sqlTraslado = "SELECT traslado FROM J_rollos_tref  WHERE  cod_orden =" & consecutivo_materia_prima & " AND id_detalle = " & id_detalle & " AND id_rollo = " & id_rollo
        Dim sql_consult_scla As String
        Dim sql_consult_destino As String
        Dim result_scla As String
        Dim result_destino As String
        'cambiar el cosltarvalorprueba
        If (objOperacionesDb.consultValor(sqlTraslado, "PRODUCCION") <> "") Then
            sql_consult_scla = "SELECT scla " &
                                           "FROM J_rollos_tref " &
                                                   "WHERE  id_detalle =" & id_detalle & "  AND id_rollo =" & id_rollo & "and cod_orden=" & consecutivo_materia_prima & ""
            sql_consult_destino = "SELECT destino " &
                               "FROM J_rollos_tref " &
                                       "WHERE  id_detalle =" & id_detalle & "  AND id_rollo =" & id_rollo & "and cod_orden=" & consecutivo_materia_prima & ""
            result_scla = objOpSimplesLn.consultValorTodo(sql_consult_scla, "PRODUCCION")
            result_destino = objOpSimplesLn.consultValorTodo(sql_consult_destino, "PRODUCCION")
            If result_scla = "" Then
                If result_destino = "P" Then
                    resp = True
                ElseIf result_destino = "G" Then
                    MessageBox.Show("El rollo pertenece a los inentarios de GALVANIZADO, no consumirlo hasta no gestionar", "NO GASTAR", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                ElseIf result_destino = "" Then
                    MessageBox.Show("El rollo no pertenece a PUNTILLERIA", "NO GASTAR", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    resp = True
                End If
            Else
                MessageBox.Show("El rollo ya esta consumido", "Rollo ya gastado", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            MessageBox.Show("El rollo no a sido entregado por trefilación", "Rollo no a sido trasladado", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Return resp
    End Function
    Private Function validarTrasladoGalv(ByVal consecutivo As String) As Boolean
        Dim resp As Boolean = False
        Dim nro_orden As String = obj_gestion_materia_primaLn.extraerDatoCodigoBarrasGalvanizado("nro_orden", consecutivo)
        Dim id_rollo As String = obj_gestion_materia_primaLn.extraerDatoCodigoBarrasGalvanizado("id_rollo", consecutivo)
        Dim sqlTraslado = "SELECT traslado FROM D_rollo_galvanizado_f  WHERE  nro_orden =" & nro_orden & " AND consecutivo_rollo = " & id_rollo
        Dim sql_consult_saga As String
        Dim sql_consult_destino As String
        Dim result_saga As String
        Dim result_destino As String
        'cambiar el cosltarvalorprueba
        If (objOperacionesDb.consultValor(sqlTraslado, "PRODUCCION") <> "") Then
            sql_consult_saga = "SELECT saga " &
                                           "FROM D_rollo_galvanizado_f " &
                                                   "WHERE  nro_orden =" & nro_orden & " And consecutivo_rollo = " & id_rollo
            sql_consult_destino = "Select destino " &
                               "FROM D_rollo_galvanizado_f " &
                                       "WHERE  nro_orden =" & nro_orden & " And consecutivo_rollo = " & id_rollo
            result_saga = objOpSimplesLn.consultValorTodo(sql_consult_saga, "PRODUCCION")
            result_destino = objOpSimplesLn.consultValorTodo(sql_consult_destino, "PRODUCCION")
            If result_saga = "" Then
                If result_destino = "P" Then
                    resp = True
                ElseIf result_destino = "" Then
                    MessageBox.Show("El rollo no pertenece a PUNTILLERIA", "NO GASTAR", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    resp = True
                End If
            Else
                MessageBox.Show("El rollo ya esta consumido", "Rollo ya gastado", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            MessageBox.Show("El rollo no a sido entregado por GALVANIZADO", "Rollo no a sido entregado", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Return resp
    End Function

    Private Sub btn_registrar_Click(sender As Object, e As EventArgs) Handles btn_registrar.MouseUp
        If cbo_peso_contenedor.SelectedValue <> 0 Then
            If lbl_doc_operario.Text <> "" And lbl_nombre_operario.Text <> "" Then
                If IsNumeric(txt_peso_registro.Text) Then
                    If Convert.ToDouble(txt_peso_registro.Text > 0) Then
                        btn_registrar.Enabled = False
                        guardar_transaccion_producto()
                        cargarRollos()
                        resp_des = False
                        chk_no_conforme.Checked = False
                    Else
                        MessageBox.Show("El peso de la producción no puede ser negativo,verifique el peso en el indicador", "El peso de la producción no puede ser negativo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                Else
                    MessageBox.Show("Problemas con el indicador, comuniquese con metroligía o sistemas", "Problemas con el indicador", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                MessageBox.Show("Seleccione al menos un operario", "Seleccione operario", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            MessageBox.Show("Seleccione el peso del contenedor", "Seleccione contenedor", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        btn_registrar.Enabled = True
    End Sub

    Private Sub btn_cerrar_registrar_Click(sender As Object, e As EventArgs) Handles btn_cerrar_registrar.Click
        ocultar_group_registro()
    End Sub
    'Private Function capturarPeso() As String
    '    Dim pesoFinal As String = ""
    '    Dim primerIgual As Boolean = False
    '    For i = 0 To txt_indicador.TextLength - 1
    '        If (txt_indicador.Text(i) = "+" Or primerIgual = True) Then
    '            If (primerIgual = False) Then
    '                i += 1
    '                primerIgual = True
    '            End If
    '            If (txt_indicador.Text(i) <> "+") Then
    '                If (txt_indicador.Text(i) <> " ") Then
    '                    If (txt_indicador.Text(i) = "0") Then
    '                        If (pesoFinal.Length > 0) Then
    '                            pesoFinal += txt_indicador.Text(i)
    '                        End If
    '                    Else
    '                        If (txt_indicador.Text(i) <> "k") Then
    '                            If (txt_indicador.Text(i) <> "g") Then
    '                                If (txt_indicador.Text(i) <> "S") Then
    '                                    If (txt_indicador.Text(i) <> "T") Then
    '                                        If (txt_indicador.Text(i) <> ",") Then
    '                                            If (txt_indicador.Text(i) <> "G") Then
    '                                                If (txt_indicador.Text(i) <> "S") Then
    '                                                    If (txt_indicador.Text(i) <> ",") Then
    '                                                        If (txt_indicador.Text(i) <> "+") Then
    '                                                            pesoFinal += txt_indicador.Text(i)
    '                                                        End If

    '                                                    End If
    '                                                End If
    '                                            End If
    '                                        End If
    '                                    End If
    '                                End If
    '                            End If
    '                        End If
    '                    End If
    '                End If
    '            Else
    '                i = txt_indicador.TextLength
    '            End If
    '        End If
    '    Next
    '    If (pesoFinal = "") Then
    '        Dim primerNumeroNoCero As Boolean = False
    '        For i = 0 To txt_indicador.Text.Length - 1
    '            If ((txt_indicador.Text(i) <> "0" And txt_indicador.Text(i) <> " ") Or primerNumeroNoCero = True) Then
    '                primerNumeroNoCero = True
    '                pesoFinal += txt_indicador.Text(i)
    '            End If
    '        Next

    '    End If
    '    If IsNumeric(pesoFinal) Then
    '        If pesoFinal > 0 Then
    '            If cbo_peso_contenedor.SelectedValue <> "Seleccione" Then
    '                pesoFinal -= cbo_peso_contenedor.SelectedValue
    '            End If
    '            txt_peso_registro.Text = pesoFinal
    '        Else
    '            txt_peso_registro.Text = ""
    '        End If
    '    Else
    '        txt_peso_registro.Text = ""
    '    End If
    '    Return pesoFinal
    'End Function


    Private Function capturarPeso() As String
        Dim pesoFinal As String = ""
        Dim primerIgual As Boolean = False
        For i = 0 To txt_indicador.TextLength - 1
            If (txt_indicador.Text(i) = "=" Or primerIgual = True) Then
                If (primerIgual = False) Then
                    i += 1
                    primerIgual = True
                End If
                If (txt_indicador.Text(i) <> "=") Then
                    If (txt_indicador.Text(i) <> "-") Then
                        If (txt_indicador.Text(i) <> " ") Then
                            If (txt_indicador.Text(i) = "0") Then
                                If (pesoFinal.Length > 0) Then
                                    pesoFinal += txt_indicador.Text(i)
                                End If
                            Else
                                pesoFinal += txt_indicador.Text(i)
                            End If
                        End If
                    End If
                Else
                    i = txt_indicador.TextLength
                End If
            End If
        Next
        If (pesoFinal = "") Then
            Dim primerNumeroNoCero As Boolean = False
            For i = 0 To txt_indicador.Text.Length - 1
                If ((txt_indicador.Text(i) <> "0" And txt_indicador.Text(i) <> " ") Or primerNumeroNoCero = True) Then
                    primerNumeroNoCero = True
                    pesoFinal += txt_indicador.Text(i)
                End If
            Next

        End If
        If IsNumeric(pesoFinal) Then
            If pesoFinal > 0 Then
                If cbo_peso_contenedor.SelectedValue <> "Seleccione" Then
                    pesoFinal -= cbo_peso_contenedor.SelectedValue
                End If
                txt_peso_registro.Text = pesoFinal
            Else
                txt_peso_registro.Text = ""
            End If
        Else
            txt_peso_registro.Text = ""
        End If
        Return pesoFinal
    End Function

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If (txt_indicador.TextLength >= 30) Then
            txt_indicador.Text = peso
        End If
        If SerialPort1.IsOpen Then
            peso = SerialPort1.ReadExisting
        End If
        txt_indicador.Text += peso
        capturarPeso()
    End Sub
    Private Sub ocultar_group_registro()
        nuevo_registro()
        TblPpal.Enabled = True
        group_registro.Visible = False
        Timer1.Enabled = False
        SerialPort1.Close()
        lbl_doc_operario.Text = ""
        lbl_nombre_operario.Text = ""
    End Sub
    Private Sub mostrar_group_registro()
        txt_indicador.Text = ""
        txt_peso_registro.Text = ""
        group_registro.Visible = True
        Timer1.Enabled = True
        SerialPort1.Open()
    End Sub
    Private Sub nuevo_registro()

        cbo_operario_2.SelectedValue = 0
        cbo_peso_contenedor.SelectedValue = 0
    End Sub
    Private Sub guardar_transaccion_producto()
        Dim orden As Double = lbl_num_orden.Text
        Dim resp_transaccion As Boolean = False
        Dim tipo As String = "EPPP"
        Dim dFec As Date = Now
        Dim bodega As String = objTraslado_bodLn.obtenerBodegaXcodigo(lblCodigoRegistro.Text)
        Dim listTransaccion_corsan As New List(Of Object)
        Dim pes As Double = Convert.ToDouble(txt_peso_registro.Text)
        Dim peso_fin As Double = Format(pes, "#0.0")
        Dim codigo As String = lblCodigoRegistro.Text
        Dim descripcion As String
        Dim consecutivo_rollo As String
        Dim dt As New DataTable
        Dim sqlguardar As String = ""
        Dim sql_descripcion As String = "Select descripcion from referencias where  codigo='" & codigo & "'"
        Dim sql_Consecutivo As String = "SELECT  MAX (consecutivo_rollo) + 1 FROM J_orden_prod_punt_producto WHERE nro_orden=" & orden & ""
        Dim s_fecha As Date = Now
        Dim peso_contenedor As Double = cbo_peso_contenedor.SelectedValue
        Dim maquina As String = lblMaquina.Text
        Dim modelo As String = "01"
        Dim consecutivo_barras As String = ""
        ''NUEVAS VARIABLES
        Dim fec_c As String
        fec_c = "" & System.DateTime.Now.Hour & ":" & System.DateTime.Now.Minute & ""

        descripcion = objOpsimpesLn.consultValorTodo(sql_descripcion, "CORSAN")
        consecutivo_rollo = objOpsimpesLn.consultValorTodo(sql_Consecutivo, "PRODUCCION")
        If consecutivo_rollo = "" Then
            consecutivo_rollo = "1"
        End If
        dt.Columns.Add("codigo")
        dt.Columns.Add("cantidad")
        dt.Rows.Add()
        dt.Rows(dt.Rows.Count - 1).Item("codigo") = codigo
        dt.Rows(dt.Rows.Count - 1).Item("cantidad") = peso_fin
        consecutivo_barras = orden & "-" & consecutivo_rollo
        listTransaccion_corsan.AddRange(transaccion(dt, tipo, bodega, modelo))
        Dim bodega_org As String = bodega
        Dim costUnit As Double = objOrdenProdLn.consultCostoUnit(codigo)
        If chk_no_conforme.Checked Then
            tipo = "TRB1"
            modelo = "20"
            bodega = 4
            listTransaccion_corsan.AddRange(transaccion_no_conforme(codigo, bodega_org, bodega, peso_fin, tipo, modelo, costUnit))
        End If
        If obj_Ing_prodLn.ExecuteSqlTransaction(listTransaccion_corsan, "CORSAN") Then
            tipo = "EPPP"
            Dim sqlMaxNumero As String = "Select Case When (MAX (siguiente)) Is null Then 0 Else MAX (siguiente) End  FROM consecutivos WHERE  tipo = '" & tipo & "'"
            Dim numero_eppp As Double = objOpsimpesLn.consultarVal(sqlMaxNumero)
            If chk_no_conforme.Checked Then
                sqlguardar = "INSERT INTO J_orden_prod_punt_producto " &
                       "(nro_orden,consecutivo_rollo,nit_operario,nit_operario2,peso,fecha_hora,no_conforme,trans,tipo_trans,tras_no_conforme) " &
                           "VALUES " &
                                   "(" & orden & "," & consecutivo_rollo & "," & lbl_doc_operario.Text & "," & cbo_operario_2.SelectedValue & "," & peso_fin & ", GETDATE(),'S'," & numero_eppp & " ,'" & tipo & "', " & numero_transaccion & ")"
            Else
                sqlguardar = "INSERT INTO J_orden_prod_punt_producto " &
                        "(nro_orden,consecutivo_rollo,nit_operario,nit_operario2,peso,fecha_hora,trans,tipo_trans) " &
                            "VALUES " &
                                    "(" & orden & "," & consecutivo_rollo & "," & lbl_doc_operario.Text & "," & cbo_operario_2.SelectedValue & "," & peso_fin & ", GETDATE()," & numero_eppp & " ,'" & tipo & "')"
            End If
            If obj_Ing_prodLn.ejecutar(sqlguardar, "PRODUCCION") <> 0 Then
                If chk_no_conforme.Checked = False Then
                    Dim sql_gral As String = "INSERT INTO J_prod_puntilleria (fecha, nit, turno,observaciones,horas_prog, horas_trab,referencia,kilos_prod,kil_esperado,t_sin_just, maquina, paro1, paro2, paro3, paro4, paro5, paro6, paro7, paro8, paro9, paro10,paro11,paro12, paro13, paro14, paro15, paro16, paro17, paro18, paro19, paro20,paro21,paro22,paro23) "
                    '"VALUES(GETDATE()," & lbl_doc_operario.Text & " , " & turno & ",'" & observaciones & "',"
                End If
                MessageBox.Show("rollo registrado correctamente", "Guardando registros", MessageBoxButtons.OK, MessageBoxIcon.Information)

                Dim tiem As Integer = obj_Ing_prodLn.consultar_valor("SELECT tiemp FROM JB_tiempos_punt", "PRODUCCION")
                Dim sql As String = "UPDATE JB_tiempos_mq_puntilleria SET FEC = DATEADD(HH," & tiem & ",getdate()) WHERE mq=" & mqb
                obj_Ing_prodLn.ejecutar(sql, "PRODUCCION")
            Else
                MessageBox.Show("Problemas con el registro,comunicarse con el adminstrador del sistema", "Error al guardar el registro de producción", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            imprimirTiquete(lbl_nombre_operario.Text, cbo_operario_2.Text, codigo, descripcion, consecutivo_barras, Now, peso_contenedor, maquina, peso_fin)
            ocultar_group_registro()
        Else
            MessageBox.Show("rollo no fue registrado", "Guardando registros", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Private Sub guardar_transaccion_producto_no_conforme()

    End Sub
    Private Sub imprimirTiquete(ByVal operario As String, ByVal operario2 As String, ByVal codigo As String, ByVal desc_producto As String, ByVal consecutivo_barras As String, ByVal fecha As Date, ByVal contenedor As String, ByVal maquina As String, ByVal peso_tiquete As Double)
        Dim proc As New Process
        Dim s_fec As String = fecha.Year & "-" & fecha.Month & "-" & fecha.Day & " " & fecha.Hour & ":" & fecha.Minute & ""
        modificarPlantilla(operario, operario2, codigo, desc_producto, consecutivo_barras, s_fec, contenedor, maquina, peso_tiquete)
        proc.StartInfo.FileName = Environment.CurrentDirectory & "\plantillaPuntilleriaImp.txt"

        proc.StartInfo.Verb = "Print"
        proc.StartInfo.CreateNoWindow = False
        proc.Start()
    End Sub
    Private Sub modificarPlantilla(ByVal operario As String, ByVal operario2 As String, ByVal codigo As String, ByVal desc_producto As String, ByVal consecutivo_barras As String, ByVal fecha As String, ByVal contenedor As String, ByVal maquina As String, ByVal peso_tiquete As Double)
        Dim fic As String
        Dim nuevoFic As String
        fic = Environment.CurrentDirectory & "\plantillaPuntilleria.txt"
        nuevoFic = Environment.CurrentDirectory & "\plantillaPuntilleriaImp.txt"

        Dim sw As New System.IO.StreamWriter(nuevoFic)
        Dim texto As String
        Dim sr As New System.IO.StreamReader(fic)
        texto = sr.ReadToEnd()

        texto = Replace(texto, "@operario1", operario)
        texto = Replace(texto, "@operario2", operario2)
        texto = Replace(texto, "@codigo", codigo)
        texto = Replace(texto, "@descripcion", desc_producto)
        texto = Replace(texto, "@consecutivo", consecutivo_barras)
        texto = Replace(texto, "@fecha", fecha)
        texto = Replace(texto, "@contenedor", contenedor)
        texto = Replace(texto, "@peso", peso_tiquete & " (Kg)")
        texto = Replace(texto, "@maquina", maquina)
        texto = Replace(texto, "@barras", consecutivo_barras)
        sr.Close()
        sw.WriteLine(texto)
        sw.Close()

    End Sub

    Private Sub btn_empaque_Click(sender As Object, e As EventArgs) Handles btn_empaque.Click
        frm_orden_prod_punti_empaque.ShowDialog()
    End Sub

    Private Sub btn_tambores_Click(sender As Object, e As EventArgs) Handles btn_tambores.Click
        frm_orden_prod_punt_tambores.ShowDialog()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Gorup_desperdicio.Visible = False
        activar()
    End Sub

    Private Sub btn_generar_desperdicio_Click(sender As Object, e As EventArgs) Handles btn_generar_desperdicio.Click
        Gorup_desperdicio.Visible = True
        desactivar()
        nuevo_desperdicio()
    End Sub

    Private Sub btn_guardar_desperdicio_Click(sender As Object, e As EventArgs) Handles btn_guardar_desperdicio.Click
        If cbo_operario_desperdicio.Text <> "" Then
            If cbo_defecto_desperdicio.Text <> "" Then
                If txt_kilos_desperdicio.Text <> "" Then
                    If txt_observacion_desperdicio.Text <> "" Then
                        If cbo_maquina_des.Text <> "" Then
                            If cbo_referencia_desp.Text <> "" Then
                                If cbo_turno.Text <> "" Then
                                    generar_desperdicio()
                                Else
                                    MessageBox.Show("Seleccionar la turno.", "Verifique!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                End If
                            Else
                                MessageBox.Show("Seleccionar la referencia.", "Verifique!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End If
                        Else
                            MessageBox.Show("Seleccionar la maquina.", "Verifique!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    Else
                        MessageBox.Show("Debe de escribir una observacion.", "Verifique!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Else
                    MessageBox.Show("Debe de escribir la cantidad de kilos.", "Verifique!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                MessageBox.Show("Debe seleccionar un defecto.", "Verifique!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            MessageBox.Show("Debe seleccionar un operario.", "Verifique!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub generar_desperdicio()
        Dim fecha As String = obj_op_simplesLn.cambiarFormatoFecha(Now)
        Dim nit As Double = cbo_operario_desperdicio.SelectedValue
        Dim centro As Double = 2300
        Dim kilos As Double = txt_kilos_desperdicio.Text
        Dim tipo As Integer = 3
        Dim causal As Integer = 1
        Dim defecto As Integer = cbo_defecto_desperdicio.SelectedValue
        Dim destino As Integer = 1
        Dim id_exixtente As Double = 0
        Dim observaciones As String = txt_observacion_desperdicio.Text
        Dim turno As String = cbo_turno.Text
        Dim codigo_ref As String = cbo_referencia_desp.SelectedValue
        Dim cod_maquina As String = cbo_maquina_des.SelectedValue

        Dim listSql As List(Of Object) = obj_Ing_prodLn.guardar_desperdicio_nuevo(fecha, nit, centro, kilos, tipo, causal, defecto, observaciones, id_exixtente, destino, turno, codigo_ref, cod_maquina)

        If kilos >= 0 Then
            If (obj_Ing_prodLn.ExecuteSqlTransaction(listSql, "PRODUCCION")) Then
                resp_des = True
                MessageBox.Show("El registro se guardo en forma exitosa!", "Exito!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                nuevo_desperdicio()
            Else
                MessageBox.Show("Error al ingresar el registro, comuniquese con el area de sistemas", "Verifique!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            resp_des = True
            MessageBox.Show("El registro se guardo en forma exitosa!", "Exito!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            nuevo_desperdicio()
        End If


    End Sub
    Private Sub nuevo_desperdicio()
        cbo_defecto_desperdicio.SelectedValue = 0
        cbo_operario_desperdicio.SelectedValue = 0
        cbo_referencia_desp.SelectedValue = 0
        cbo_maquina_des.SelectedValue = 0
        cbo_turno.SelectedValue = 0
        txt_kilos_desperdicio.Text = ""
        txt_observacion_desperdicio.Text = ""
    End Sub

    Private Sub chk_no_conforme_CheckedChanged(sender As Object, e As EventArgs) Handles chk_no_conforme.CheckedChanged
        If chk_no_conforme.Checked Then
            group_registro.BackColor = Color.OrangeRed
        Else
            group_registro.BackColor = Color.WhiteSmoke
        End If
    End Sub

    Private Sub TextBox1_Enter(sender As Object, e As EventArgs) Handles txt_lect_no_conforme.Enter
        txt_lect_no_conforme.BackColor = Color.Green
        txt_lect_no_conforme.Text = ""
    End Sub

    Private Sub TextBox1_Leave(sender As Object, e As EventArgs) Handles txt_lect_no_conforme.Leave
        txt_lect_no_conforme.BackColor = Color.Red
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_lect_no_conforme.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            txt_lect_no_conforme.Text = Replace(txt_lect_no_conforme.Text, "'", "-")
            Dim sql As String = ""
            Dim sppp As String = ""
            Dim pesos As Double = 0
            Dim numero_orden As String = obj_gestion_materia_primaLn.extraerDatoCodigoBarrasPuntilleria("oden_produccion", txt_lect_no_conforme.Text)
            Dim id_rollo As String = obj_gestion_materia_primaLn.extraerDatoCodigoBarrasPuntilleria("id_rollo", txt_lect_no_conforme.Text)
            If txt_lect_no_conforme.Text <> "" Then
                If validar_no_conforme(txt_lect_no_conforme.Text) Then
                    sql = "SELECT anular FROM J_orden_prod_punt_producto WHERE nro_orden = " & numero_orden & " AND consecutivo_rollo = " & id_rollo
                    Dim anulado As String = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")
                    If anulado = "" Then
                        sql = "SELECT sppp FROM J_orden_prod_punt_producto WHERE nro_orden = " & numero_orden & " AND consecutivo_rollo = " & id_rollo
                        sppp = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")
                        If sppp <> "" Then
                            txt_peso_no_conforme.Enabled = True
                            btn_tiquete_no_conforme.Enabled = True

                            sql = "SELECT peso FROM J_orden_prod_punt_producto WHERE nro_orden = " & numero_orden & " AND consecutivo_rollo = " & id_rollo
                            txt_peso_no_conforme.Text = CDbl(objOpSimplesLn.consultValorTodo(sql, "PRODUCCION"))
                        Else
                            sppp = ""
                            sql = "SELECT peso FROM J_orden_prod_punt_producto WHERE nro_orden = " & numero_orden & " AND consecutivo_rollo = " & id_rollo
                            sppp = CDbl(objOpSimplesLn.consultValorTodo(sql, "PRODUCCION"))
                            If sppp <> "" Then
                                pesos = sppp
                            End If
                            If pesos > 0 Then
                                generar_no_conforme(numero_orden, id_rollo)
                            Else
                                MessageBox.Show("El producto no existe, por favor verifique. ", "verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End If
                        End If
                    Else
                        MessageBox.Show("El producto no esta marcado como anulado. ", "verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        txt_lect_no_conforme.Text = ""
                    End If

                Else
                    MessageBox.Show("El producto ya a sido ingresado como no conforme. ", "verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    txt_lect_no_conforme.Text = ""
                End If
            Else
                MessageBox.Show("El Campo esta vacio. ", "verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub
    Private Sub generar_no_conforme(ByVal numero_orden As String, ByVal id_rollo As String)
        Dim sql As String = ""

        Dim tipo As String = "TRB1"
        Dim bodega As String = 4
        Dim listTransaccion_corsan As New List(Of Object)
        Dim listSql As New List(Of Object)
        Dim modelo As String = "20"
        Dim bodega_org As String = 2
        Dim peso_fin As String = ""
        Dim pesos_fin As Double = 0

        Dim dt As New DataTable
        sql = "SELECT peso FROM J_orden_prod_punt_producto WHERE nro_orden = " & numero_orden & " AND consecutivo_rollo = " & id_rollo
        peso_fin = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")
        If peso_fin <> "" Then
            pesos_fin = CDbl(peso_fin)
        End If
        sql = "SELECT prod_final FROM J_orden_prod_punt_enc WHERE consecutivo = " & numero_orden
        Dim codigo As String = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")

        dt.Columns.Add("codigo")
        dt.Columns.Add("cantidad")
        dt.Rows.Add()
        dt.Rows(dt.Rows.Count - 1).Item("codigo") = codigo
        dt.Rows(dt.Rows.Count - 1).Item("cantidad") = peso_fin


        Dim costUnit As Double = objOrdenProdLn.consultCostoUnit(codigo)
        Dim stock As Double = objOpsimpesLn.consultarStock(codigo, bodega_org)

        If stock >= pesos_fin Then

            listTransaccion_corsan.AddRange(transaccion_no_conforme(codigo, bodega_org, bodega, pesos_fin, tipo, modelo, costUnit))
            If obj_Ing_prodLn.ExecuteSqlTransaction(listTransaccion_corsan, "CORSAN") Then
                sql = "UPDATE J_orden_prod_punt_producto SET tras_no_conforme= " & numero_transaccion & " ,no_conforme = 'S' WHERE nro_orden = " & numero_orden & " AND consecutivo_rollo = " & id_rollo
                listSql.Add(sql)

                If obj_Ing_prodLn.ExecuteSqlTransaction(listSql, "PRODUCCION") Then
                    MessageBox.Show("El producto se registro como no conforme. ", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txt_lect_no_conforme.Text = ""
                    Gorup_no_conforme.Visible = False
                    txt_peso_no_conforme.Enabled = False
                    btn_tiquete_no_conforme.Enabled = False
                    activar()
                End If
            End If
        Else
            MessageBox.Show("No hay stock disponible", "Sin stock", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub generar_no_conforme_empaque()
        Dim sql As String = ""

        Dim numero_orden As String = obj_gestion_materia_primaLn.extraerDatoCodigoBarrasPuntilleria("oden_produccion", txt_lect_no_conforme.Text)
        Dim id_rollo As String = obj_gestion_materia_primaLn.extraerDatoCodigoBarrasPuntilleria("id_rollo", txt_lect_no_conforme.Text)

        Dim tipo As String = "EIPP"
        Dim bodega As String = 4
        Dim listTransaccion_corsan As New List(Of Object)
        Dim listSql As New List(Of Object)
        Dim modelo As String = "03"
        sql = "SELECT  nit_operario, nit_operario2, fecha_hora, trans, anular, tipo_trans, sppp, tamboreado, notas, peso " &
                                " FROM J_orden_prod_punt_producto " &
                                    " WHERE nro_orden =" & numero_orden & " AND consecutivo_rollo = " & id_rollo
        Dim dt_emp As DataTable = objOpsimpesLn.listar_datatable(sql, "PRODUCCION")

        sql = "SELECT peso FROM J_orden_prod_punt_producto WHERE nro_orden = " & numero_orden & " AND consecutivo_rollo = " & id_rollo
        Dim val_peso As Double = CDbl(objOpSimplesLn.consultValorTodo(sql, "PRODUCCION"))

        If txt_peso_no_conforme.Text > val_peso Then
            MessageBox.Show("El peso no puede ser mayor al ya especificado. ", "verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else

            Dim nit_operario As String = ""
            Dim nit_operario2 As String = ""
            Dim fecha_hora As DateTime
            Dim trans As String = "NULL"
            Dim anular As String = "NULL"
            Dim tipo_trans As String = "NULL"
            Dim sppp As String = "NULL"
            Dim tamboreado As String = "NULL"
            Dim notas As String = ""
            Dim fecha As String = ""
            Dim peso_val As String = ""

            For i = 0 To dt_emp.Rows.Count - 1
                peso_val = Format(dt_emp.Rows(i).Item("peso"), "#0.0")
                nit_operario = dt_emp.Rows(i).Item("nit_operario")
                nit_operario2 = dt_emp.Rows(i).Item("nit_operario2")
                fecha_hora = dt_emp.Rows(i).Item("fecha_hora")
                fecha = fecha_hora.Year & "-" & fecha_hora.Month & "-" & fecha_hora.Day & " " & fecha_hora.Hour & ":" & fecha_hora.Minute & ":" & fecha_hora.Second
                If Not IsDBNull(dt_emp.Rows(i).Item("trans")) Then
                    trans = dt_emp.Rows(i).Item("trans")
                End If
                If Not IsDBNull(dt_emp.Rows(i).Item("anular")) Then
                    anular = dt_emp.Rows(i).Item("anular")
                End If
                If Not IsDBNull(dt_emp.Rows(i).Item("tipo_trans")) Then
                    tipo_trans = "'" & dt_emp.Rows(i).Item("tipo_trans") & "'"
                End If
                If Not IsDBNull(dt_emp.Rows(i).Item("sppp")) Then
                    sppp = "'" & dt_emp.Rows(i).Item("sppp") & "'"
                End If
                If Not IsDBNull(dt_emp.Rows(i).Item("tamboreado")) Then
                    tamboreado = "'" & dt_emp.Rows(i).Item("tamboreado") & "'"
                End If
                If Not IsDBNull(dt_emp.Rows(i).Item("notas")) Then
                    notas = dt_emp.Rows(i).Item("notas")
                End If
            Next
            notas &= "proviene de:" & numero_orden & "-" & id_rollo & ";"

            sql = "SELECT  MAX (consecutivo_rollo) + 1 FROM J_orden_prod_punt_producto WHERE nro_orden=" & numero_orden & ""
            Dim id_rollo_nuevo As String = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")
            Dim peso_fin As Double = CDbl(txt_peso_no_conforme.Text)
            If peso_fin <= peso_val Then
                Dim dt As New DataTable
                sql = "SELECT prod_final FROM J_orden_prod_punt_enc WHERE consecutivo = " & numero_orden
                Dim codigo As String = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")

                dt.Columns.Add("codigo")
                dt.Columns.Add("cantidad")
                dt.Rows.Add()
                dt.Rows(dt.Rows.Count - 1).Item("codigo") = codigo
                dt.Rows(dt.Rows.Count - 1).Item("cantidad") = peso_fin

                Dim bodega_org As String = bodega
                Dim costUnit As Double = objOrdenProdLn.consultCostoUnit(codigo)


                listTransaccion_corsan.AddRange(transaccion(dt, tipo, bodega, modelo))
                Dim trans_eipp As String = numero_transaccion

                If obj_Ing_prodLn.ExecuteSqlTransaction(listTransaccion_corsan, "CORSAN") Then
                    sql = "UPDATE J_orden_prod_punt_producto SET tras_no_conforme= " & trans_eipp & ",no_conforme = 'S', anular = 1 WHERE nro_orden = " & numero_orden & " AND consecutivo_rollo = " & id_rollo
                    listSql.Add(sql)
                    tipo = "EIPP"
                    sql = "INSERT INTO J_orden_prod_punt_producto " &
                           "(nro_orden,consecutivo_rollo,nit_operario,nit_operario2,peso,fecha_hora,trans,tipo_trans,anular,sppp,tamboreado,notas,no_conforme,tras_no_conforme) " &
                               "VALUES " &
                                       "(" & numero_orden & "," & id_rollo_nuevo & "," & nit_operario & "," & nit_operario2 & "," & peso_fin & ",'" & fecha & "'," & trans_eipp & " ,'" & tipo & "'," & anular & ", " & sppp & ", " & tamboreado & ",'" & notas & "','S'," & trans_eipp & ")"
                    listSql.Add(sql)
                    If obj_Ing_prodLn.ExecuteSqlTransaction(listSql, "PRODUCCION") Then
                        MessageBox.Show("El producto se registro como no conforme. ", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        txt_lect_no_conforme.Text = ""
                        txt_peso_no_conforme.Enabled = False
                        btn_tiquete_no_conforme.Enabled = False
                        txt_peso_no_conforme.Text = ""
                        txt_lect_no_conforme.Focus()
                    End If
                    Dim fila As Integer = numero_orden
                    Dim peso_contenedor As Integer = 0

                    sql = "Select descripcion from referencias where  codigo='" & codigo & "'"
                    Dim descripcion As String = objOpSimplesLn.consultValorTodo(sql, "CORSAN")

                    sql = "SELECT m.Nombre FROM J_orden_prod_punt_enc s, J_Maquinas m WHERE (s.maquina = m.codigoM) AND consecutivo = " & numero_orden
                    Dim maquina As String = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")
                    sql = "SELECT nombres FROM V_nom_personal_Activo_con_maquila WHERE nit = " & nit_operario
                    Dim oper1 As String = objOpSimplesLn.consultValorTodo(sql, "CORSAN")
                    sql = "SELECT nombres FROM V_nom_personal_Activo_con_maquila WHERE nit = " & nit_operario2
                    Dim oper2 As String = objOpSimplesLn.consultValorTodo(sql, "CORSAN")

                    imprimirTiquete(oper1, oper2, codigo, descripcion, numero_orden & "-" & id_rollo_nuevo, fecha_hora, peso_contenedor, maquina, peso_fin)

                End If
            Else
                MessageBox.Show("El peso no puede ser mayor. ", "verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End If
        End If
    End Sub
    Private Sub activar()
        btn_no_conforme.Enabled = True
        btn_generar_desperdicio.Enabled = True
        btn_empaque.Enabled = True
        btn_tambores.Enabled = True
        btnActOrdenes.Enabled = True
        cboMesConsulta.Enabled = True
        cboAnoConsulta.Enabled = True
        btn_chatarra.Enabled = True
        dtgOperario.Enabled = True
        dtgRollos.Enabled = True
    End Sub
    Private Sub desactivar()
        btn_no_conforme.Enabled = False
        btn_generar_desperdicio.Enabled = False
        btn_empaque.Enabled = False
        btn_tambores.Enabled = False
        btnActOrdenes.Enabled = False
        cboMesConsulta.Enabled = False
        cboAnoConsulta.Enabled = False
        btn_chatarra.Enabled = False
        dtgOperario.Enabled = False
        dtgRollos.Enabled = False
    End Sub

    Private Sub btn_no_conforme_Click(sender As Object, e As EventArgs) Handles btn_no_conforme.Click
        Gorup_no_conforme.Visible = True
        txt_lect_no_conforme.Text = ""
        txt_lect_no_conforme.Focus()
        desactivar()
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Gorup_no_conforme.Visible = False
        txt_peso_no_conforme.Enabled = False
        btn_tiquete_no_conforme.Enabled = False
        txt_peso_no_conforme.Text = ""
        activar()
    End Sub


    Private Sub btn_tiquete_no_conforme_Click(sender As Object, e As EventArgs) Handles btn_tiquete_no_conforme.Click
        If txt_peso_no_conforme.Text <> "" Then
            generar_no_conforme_empaque()
        Else
            MessageBox.Show("Debe Ingresar un peso. ", "verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub txt_lector_reproceso_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_lector_reproceso.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            txt_lector_reproceso.Text = Replace(txt_lector_reproceso.Text, "'", "-")

            Dim sql As String = ""
            Dim no_conforme As String = ""
            Dim anulado As String = ""
            Dim sip As String = ""

            Dim numero_orden As String = obj_gestion_materia_primaLn.extraerDatoCodigoBarrasPuntilleria("oden_produccion", txt_lector_reproceso.Text)
            Dim id_rollo As String = obj_gestion_materia_primaLn.extraerDatoCodigoBarrasPuntilleria("id_rollo", txt_lector_reproceso.Text)

            sql = "SELECT anular FROM J_orden_prod_punt_producto WHERE nro_orden = " & numero_orden & " AND consecutivo_rollo = " & id_rollo
            anulado = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")

            sql = "SELECT no_conforme FROM J_orden_prod_punt_producto WHERE nro_orden = " & numero_orden & " AND consecutivo_rollo = " & id_rollo
            no_conforme = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")

            sql = "SELECT sip FROM J_orden_prod_punt_producto WHERE nro_orden = " & numero_orden & " AND consecutivo_rollo = " & id_rollo
            sip = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")

            If no_conforme <> "" Then
                If anulado = "" Then
                    If sip = "" Then
                        txt_peso_reproceso.Enabled = True
                        txt_peso_desperdicio.Enabled = True
                        btn_transaccion_reproceso.Enabled = True
                        cbo_defecto_repro.Enabled = True

                        sql = "SELECT peso FROM J_orden_prod_punt_producto WHERE nro_orden = " & numero_orden & " AND consecutivo_rollo = " & id_rollo
                        lbl_peso.Text = CDbl(objOpSimplesLn.consultValorTodo(sql, "PRODUCCION"))

                        txt_peso_reproceso.Text = "0"
                        txt_peso_desperdicio.Text = "0"
                    Else
                        MessageBox.Show("Este tiquete ya ha sido reprocesado. ", "verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        txt_lector_reproceso.Text = ""
                    End If
                Else
                    MessageBox.Show("El producto esta marcado como anulado. ", "verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    txt_lector_reproceso.Text = ""
                End If
            Else
                MessageBox.Show("El producto no esta marcado como no conforme. ", "verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txt_lector_reproceso.Text = ""
            End If
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        group_chatarra.Visible = False
        txt_peso_reproceso.Enabled = False
        txt_peso_desperdicio.Enabled = False
        btn_transaccion_reproceso.Enabled = False
        cbo_defecto_repro.Enabled = False
        txt_peso_reproceso.Text = ""
        txt_peso_desperdicio.Text = ""
        activar()
    End Sub

    Private Sub txt_lector_reproceso_Enter(sender As Object, e As EventArgs) Handles txt_lector_reproceso.Enter
        txt_lector_reproceso.BackColor = Color.Green
        txt_lector_reproceso.Text = ""
    End Sub

    Private Sub txt_lector_reproceso_Leave(sender As Object, e As EventArgs) Handles txt_lector_reproceso.Leave
        txt_lector_reproceso.BackColor = Color.Red
    End Sub

    Private Sub btn_chatarra_Click(sender As Object, e As EventArgs) Handles btn_chatarra.Click
        group_chatarra.Visible = True
        txt_lector_reproceso.Text = ""
        txt_lector_reproceso.Focus()
        lbl_peso.Text = "0"
        desactivar()
    End Sub

    Private Sub btn_transaccion_reproceso_Click(sender As Object, e As EventArgs) Handles btn_transaccion_reproceso.Click
        Dim peso_rep As Double = 0
        Dim peso_desp As Double = 0
        Dim peso_tot As Double = 0
        If txt_peso_reproceso.Text <> "" And txt_peso_desperdicio.Text <> "" Then
            peso_rep = CDbl(txt_peso_reproceso.Text)
            peso_desp = CDbl(txt_peso_desperdicio.Text)
            peso_tot = CDbl(peso_rep + peso_desp)
            If peso_tot = lbl_peso.Text Then
                If cbo_defecto_repro.SelectedValue <> 0 Then
                    transaccion_reproceso(peso_rep, peso_desp)
                Else
                    MessageBox.Show("debe seleccionar un defecto. ", "verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                MessageBox.Show("La cantidad ingresada es mayor al peso de el contenedor. ", "verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            MessageBox.Show("Debe ingresar un peso mayor o igual a '0'. ", "verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Private Sub transaccion_reproceso(ByVal peso_rep As Double, ByVal peso_desp As Double)
        Dim numero_orden As String = obj_gestion_materia_primaLn.extraerDatoCodigoBarrasPuntilleria("oden_produccion", txt_lector_reproceso.Text)
        Dim id_rollo As String = obj_gestion_materia_primaLn.extraerDatoCodigoBarrasPuntilleria("id_rollo", txt_lector_reproceso.Text)
        Dim sql As String = ""
        Dim dt_rep As New DataTable
        Dim trans_rep As String = "0"
        Dim dt_desp As New DataTable
        Dim trans_desp As String = "0"

        Dim tipo As String = "SIP"
        Dim bodega As String = 4
        Dim modelo As String = "02"

        Dim listTransaccion_corsan As New List(Of Object)
        Dim listSql As New List(Of Object)

        sql = "SELECT prod_final FROM J_orden_prod_punt_enc WHERE consecutivo = " & numero_orden
        Dim codigo As String = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")

        Dim pesos As Double = peso_rep + peso_desp
        Dim stocks As Double = objOpsimpesLn.consultarStock(codigo, bodega)

        If stocks >= pesos Then
            If peso_rep > 0 Then
                dt_rep.Columns.Add("codigo")
                dt_rep.Columns.Add("cantidad")
                dt_rep.Rows.Add()
                dt_rep.Rows(dt_rep.Rows.Count - 1).Item("codigo") = codigo
                dt_rep.Rows(dt_rep.Rows.Count - 1).Item("cantidad") = peso_rep

                listTransaccion_corsan.AddRange(transaccion(dt_rep, tipo, bodega, modelo))
                trans_rep = "Trans rep:" & numero_transaccion & ";"
            End If

            If peso_desp > 0 Then
                tipo = "SAI2"
                modelo = "02"

                dt_desp.Columns.Add("codigo")
                dt_desp.Columns.Add("cantidad")
                dt_desp.Rows.Add()
                dt_desp.Rows(dt_desp.Rows.Count - 1).Item("codigo") = codigo
                dt_desp.Rows(dt_desp.Rows.Count - 1).Item("cantidad") = peso_desp

                listTransaccion_corsan.AddRange(transaccion(dt_desp, tipo, bodega, modelo))
                trans_desp = numero_transaccion
                generar_desp_no_conforme(peso_desp, codigo, numero_orden, id_rollo)
            End If
            Dim notas As String = trans_rep & trans_desp
            If obj_Ing_prodLn.ExecuteSqlTransaction(listTransaccion_corsan, "CORSAN") Then
                sql = "UPDATE J_orden_prod_punt_producto SET anular= 1,sip=" & trans_desp & ",sai=" & trans_desp & " WHERE nro_orden = " & numero_orden & " AND consecutivo_rollo = " & id_rollo
                listSql.Add(sql)
                sql = "INSERT INTO j_defectos_puntilla (nro_orden,consecutivo_rollo,defecto) " &
                            "VALUES (" & numero_orden & "," & id_rollo & "," & cbo_defecto_repro.SelectedValue & ")"
                listSql.Add(sql)
                If obj_Ing_prodLn.ExecuteSqlTransaction(listSql, "PRODUCCION") Then
                    MessageBox.Show("El proceso se realizo correctamente. ", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txt_lector_reproceso.Text = ""
                    lbl_peso.Text = "0"
                    txt_peso_reproceso.Text = "0"
                    txt_peso_desperdicio.Text = "0"
                    cbo_defecto_repro.SelectedValue = 0

                    txt_peso_reproceso.Enabled = False
                    txt_peso_desperdicio.Enabled = False
                    cbo_defecto_repro.Enabled = False
                    txt_lector_reproceso.Focus()
                Else
                    MessageBox.Show("Error al registrar el no conforme", "Error al registrar no conforme", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                MessageBox.Show("Error de transacción", "Error en transacción", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            MessageBox.Show("No hay stock disponible", "Sin stock", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
    Private Function traslado_bodega(ByVal codigo As String, ByVal cantidad As Double, ByVal tipo As String, ByVal costo_unit As Double, ByVal nit_usuario As String) As List(Of Object)
        Dim listSql As New List(Of Object)
        Dim dFec As Date = Now
        Dim usuario As String = nit_usuario
        Dim notas As String = "SPIC fecha:" & Now & " usuario:" & usuario
        Dim bod_origen As Integer = 2
        Dim bod_destino As Integer = 8
        numero_transaccion = objOrdenProdLn.mover_consecutivo(tipo)
        listSql = objTraslado_bodLn.listaTransaccionDatable_traslado_bodega(numero_transaccion, codigo, bod_origen, bod_destino, dFec, notas, usuario, cantidad, tipo, "29", costo_unit)
        Return listSql
    End Function
    Private Sub generar_desp_no_conforme(ByVal peso_desp As Double, ByVal codigo As String, ByVal numero_orden As String, ByVal id_rollo As String)
        Dim sql As String = "SELECT nit_operario FROM J_orden_prod_punt_producto WHERE  nro_orden =" & numero_orden & " AND consecutivo_rollo = " & id_rollo
        Dim operario1 As Integer = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")
        sql = "SELECT nit_operario2 FROM J_orden_prod_punt_producto WHERE  nro_orden =" & numero_orden & " AND consecutivo_rollo = " & id_rollo
        Dim operario2 As Integer = 0
        operario2 = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")

        Dim fecha As String = obj_op_simplesLn.cambiarFormatoFecha(Now)
        Dim nit As Double = 0
        Dim centro As Double = 2300
        Dim kilos As Double = peso_desp
        Dim tipo As Integer = 3
        Dim causal As Integer = 1
        Dim defecto As Integer = cbo_defecto_repro.SelectedValue
        Dim destino As Integer = 1
        Dim id_exixtente As Double = 0
        Dim observaciones As String = codigo & ";Consecutivo:" & numero_orden & "-" & id_rollo

        If operario2 <> 0 Then
            nit = operario2
            kilos = peso_desp / 2
            Dim listSql2 As List(Of Object) = obj_Ing_prodLn.guardar_desperdicio(fecha, nit, centro, kilos, tipo, causal, defecto, observaciones, id_exixtente, destino, mqb)
            obj_Ing_prodLn.ExecuteSqlTransaction(listSql2, "PRODUCCION")
        End If

        nit = operario1
        Dim listSql1 As List(Of Object) = obj_Ing_prodLn.guardar_desperdicio(fecha, nit, centro, kilos, tipo, causal, defecto, observaciones, id_exixtente, destino, mqb)
        obj_Ing_prodLn.ExecuteSqlTransaction(listSql1, "PRODUCCION")
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

    Private Sub txt_peso_reproceso_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_peso_reproceso.KeyPress
        soloNumero(e)
    End Sub

    Private Sub txt_peso_desperdicio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_peso_desperdicio.KeyPress
        soloNumero(e)
    End Sub

    Private Sub txt_peso_no_conforme_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_peso_no_conforme.KeyPress
        soloNumero(e)
    End Sub

    Private Sub txt_kilos_desperdicio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_kilos_desperdicio.KeyPress
        soloNumero(e)
    End Sub
    Private Sub txt_peso_reproceso_TextChanged(sender As Object, e As EventArgs) Handles txt_peso_reproceso.TextChanged
        If txt_peso_reproceso.Text.Length > 0 Then
            txt_peso_desperdicio.Text = lbl_peso.Text - txt_peso_reproceso.Text
        End If
    End Sub

    Private Sub btn_hornos_Click(sender As Object, e As EventArgs) Handles btn_hornos.Click
        frm_orden_prod_punt_hornos.ShowDialog()
    End Sub

    Private Sub btn_consultar_desp_Click(sender As Object, e As EventArgs) Handles btn_consultar_desp.Click
        frm_consulta_desp_punt.ShowDialog()
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        cboMesConsulta.SelectedValue = Now.Month
        cargarPlanOperario()
        cargarRollos()
    End Sub

    Private Sub CboFechaIni_ValueChanged(sender As Object, e As EventArgs) Handles cboFechaIni.ValueChanged
        If (cargaComp) Then
            cargarAdminProd(txtConsulNumOrd.Text)
        End If
    End Sub
    Private Sub CboFechaFin_ValueChanged(sender As Object, e As EventArgs) Handles cboFechaFin.ValueChanged
        If (cargaComp) Then
            cargarAdminProd(txtConsulNumOrd.Text)
        End If
    End Sub

    'Nueva horometro de puntilleria

    Private Sub IngreseHorometroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IngreseHorometroToolStripMenuItem.Click
        Dim nit As String = InputBox("Ingresar cedula")
        Dim sql As String = "select nit from V_nom_personal_Activo_con_maquila where nit in (select nit from control.dbo.D_empleados_sin_salida) and (centro_planta in (2300,6400) or centro_planta is null) and nit ='" & nit & "'"
        Dim nit_val As String = objOpsimpesLn.consultValorTodo(sql, "CORSAN")
        If nit_val <> "" Then
            Dim frm As New Frm_Ing_puntilleria
            frm.Main(nit_val)
            frm.Show()
        Else
            MessageBox.Show("Nit invalido", "Nit invalido", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
    Private Sub IngreseAGalvanizarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IngreseAGalvanizarToolStripMenuItem.Click
        Dim nit As String = InputBox("Ingresar cedula")
        Dim sql As String = "select nit from V_nom_personal_Activo_con_maquila where nit in (select nit from control.dbo.D_empleados_sin_salida) and (centro_planta in (2300,6400,2400) or centro_planta is null) and nit ='" & nit & "'"
        Dim nit_val As String = objOpsimpesLn.consultValorTodo(sql, "CORSAN")
        If nit_val <> "" Then
            Dim frm As New Frm_orden_prod_punt_galva
            frm.Show()
        Else
            MessageBox.Show("Nit invalido", "Nit invalido", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
    Private Sub SolicitudDeMantenimientoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SolicitudDeMantenimientoToolStripMenuItem.Click
        Dim frm As New Frm_Mantenimiento_Planta
        frm.Show()
    End Sub

End Class