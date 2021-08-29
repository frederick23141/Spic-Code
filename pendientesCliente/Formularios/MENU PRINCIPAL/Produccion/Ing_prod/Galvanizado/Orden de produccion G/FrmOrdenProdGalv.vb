Imports logicaNegocios
Imports accesoDatos
Imports entidadNegocios
Imports System.Data.SqlClient
Public Class FrmOrdenProdGalv
    Dim pcodigo As String
    Private objOpsimpesLn As New Op_simpesLn
    Private obj_Ing_prodLn As New Ing_prodLn
    Private consecutivoPpal As Double = 1
    Private numero_transaccion As Double
    Dim cargaComp As Boolean = False
    Dim usuario As UsuarioEn
    Dim puerto_serial As Integer
    Private estadoTurno As Boolean = False
    Private peso As String = ""
    Dim permiso As String = ""
    Dim nro_bobina As Integer
    Dim peso_devanador As String
    Dim objTraslado_bodLn As New traslado_bodLn
    Dim obj_gestion_materia_primaLn As New Gestion_materia_primaLn
    Private objOrdenProdLn As New OrdenProdLn
    Private objOpSimplesLn As New Op_simpesLn
    Dim dtTerceros As DataTable
    Private objOperacionesDb As New OperacionesDb
    Dim materia_prima As String
    Public Sub main(ByVal usuario As UsuarioEn)
        Me.usuario = usuario
        If (usuario.permiso.Trim = "TREFILACION") Then
            GB_cargar_rollo.Enabled = False
            GB_orden_produccion.Enabled = False
            col_oculto.Visible = False
            TblPpal.SelectedTab = Tbl_seleccion_orden
            tbl_consulta_orden_prod_g.Parent = Nothing
            btnregistrar_materia_prima.Visible = False
            Timer1.Enabled = True
            cargar_mensaje()
            txt_mensaje.ReadOnly = False
        ElseIf usuario.permiso.Trim = "PRODUCCION" Then
            GB_cargar_rollo.Enabled = False
            GB_orden_produccion.Enabled = False
            col_oculto.Visible = False
            TblPpal.SelectedTab = Tbl_seleccion_orden
            tbl_consulta_orden_prod_g.Parent = Nothing
            tbl_orden_prod_g.Parent = Nothing
            btnTrabajar.Visible = False
            Timer1.Enabled = True
            txt_mensaje.ReadOnly = False
            cargar_mensaje()
        Else
            btnTrabajar.Visible = False
            GB_orden_produccion.Enabled = True
            TblPpal.SelectedTab = tbl_orden_prod_g
        End If
        cargaComp = True
        recorrer_botones_color()
        actualizarConsecutivoPpal(0)
    End Sub
    Private Sub FrmOrdenProdGalv_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargarDataSourse()
        puerto_serial = 1
        cargaComp = True
        TblPpal.SelectedTab = Tbl_seleccion_orden
        recorrer_botones_color()
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

        sql = "select *  from referencias where codigo like '22B%' AND ref_anulada = 'N'  "
        dt = New DataTable
        dt = obj_Ing_prodLn.listar_datatable(sql, "CORSAN")
        row = dt.NewRow
        row("codigo") = "Seleccione"
        dt.Rows.Add(row)
        cboOrigen.DataSource = dt
        cboOrigen.ValueMember = "codigo"
        cboOrigen.DisplayMember = "codigo"
        cboOrigen.Text = "Seleccione"
        cboOrigen.SelectedValue = 0

        sql = "select id,descripcion from J_destino_galv"
        dt = obj_Ing_prodLn.listar_datatable(sql, "PRODUCCION")
        row = dt.NewRow
        row("id") = 0
        row("descripcion") = "Seleccione"
        dt.Rows.Add(row)
        cboCliente.DataSource = dt
        cboCliente.ValueMember = "id"
        cboCliente.DisplayMember = "descripcion"
        cboCliente.SelectedValue = 0

        sql = "SELECT nit,nombres FROM V_nom_personal_Activo_con_maquila WHERE   nit in (select nit from control.dbo.D_empleados_sin_salida) and centro_planta = 5200  order by nombres"
        dt = obj_Ing_prodLn.listar_datatable(sql, "CORSAN")
        row = dt.NewRow
        row("nit") = 0
        row("nombres") = "Seleccione"
        dt.Rows.Add(row)
        cboOperariosG.DataSource = dt
        cboOperariosG.ValueMember = "nit"
        cboOperariosG.DisplayMember = "nombres"
        cboOperariosG.Text = "Seleccione"

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


    End Sub

    'Guardar infromacion en la tabla en una lista para despues guardar en la base de datos
    Private Function guardarConsol() As List(Of Object)
        Dim lisSql As New List(Of Object)
        Dim resp As Boolean = False
        Dim sql As String = ""
        Dim sqlGuardar As String = ""

        Dim prod_final As String = txtProdFinal.Text
        Dim nit As String = cboCliente.SelectedValue
        Dim nombre_cliente As String = cboCliente.Text
        Dim cant_prog As String = txtCantProg.Text
        Dim origen As String = cboOrigen.SelectedValue
        Dim tipoCliente As Integer = 0
        Dim mes As Integer = cbo_fec_orden.Value.Month
        Dim ano As Integer = cbo_fec_orden.Value.Year
        Dim notas As String = txtnota.Text
        Dim notas_auditoria As String = ""
        Dim calibre As String = txtCalibre.Text.Trim
        Dim fecha As String = objOpSimplesLn.cambiarFormatoFecha(cbo_fec_orden.Value)

        If consecutivoPpal = 0 Then
            notas_auditoria = "Creo:" & usuario.usuario & Now
            sql = "SELECT  MAX (consecutivo_orden_G) FROM D_orden_pro_galv_enc"
            actualizarConsecutivoPpal(obj_Ing_prodLn.consultar_valor(sql, "PRODUCCION") + 1)
            sqlGuardar = "INSERT INTO D_orden_pro_galv_enc " &
                            "(consecutivo_orden_G,nit_cliente,origen_galv,cant_prog,final_galv,nota,notas_auditoria,mes,ano,tipoCliente,Nombre_cliente,calibre,fecha_creacion) " &
                                "VALUES " &
                                        "('" & consecutivoPpal & "' , '" & nit & "', '" & origen & "' ,'" & cant_prog & "','" & prod_final & "' ,'" & notas & "','" & notas_auditoria & "'," & mes & " ," & ano & "," & tipoCliente & ",'" & nombre_cliente & "','" & calibre & "','" & fecha & "')"
            lisSql.Add(sqlGuardar)
        Else
            notas_auditoria = " - Modifico:" & usuario.usuario & Now
            sql = "UPDATE D_orden_pro_galv_enc SET " &
                   "nit_cliente =  " & nit &
                    ",origen_galv =  '" & origen & "'" &
                    ",cant_prog =  " & cant_prog &
                ",final_galv = '" & prod_final & "'" &
                    ",nota =  '" & notas & "' " &
                    ",notas_auditoria = (SELECT CASE WHEN notas_auditoria is null THEN '" & notas_auditoria & "' ELSE notas_auditoria + '" & notas_auditoria & "' END)" &
                    ",mes = '" & mes & "'" &
                ",ano =  '" & ano & "'" &
                 ",tipoCliente =  " & tipoCliente &
                 ",calibre = '" & calibre & "' " &
                " WHERE consecutivo_orden_G=" & consecutivoPpal
            lisSql.Add(sql)
        End If
        Return lisSql
    End Function
    'validar que se ingrese toda la informacion a la orden
    Private Function validarEncabezado() As Boolean
        If cargaComp = True Then
            If (cboCliente.Text <> "Seleccione") Then
                If (cboOrigen.Text <> "" And cboOrigen.Text <> "SELECCIONE") Then
                    If (txtCantProg.Text <> "") Then
                        If (txtCantProg.Text > 0) Then
                            If (txtProdFinal.Text <> "") Then
                                If (objOpsimpesLn.validarCodigo(txtProdFinal.Text)) Then
                                    If (objOpsimpesLn.validarCodigoEstado(txtProdFinal.Text)) Then
                                        'If (cboAñoProg.Text <> "Seleccione") Then
                                        '    If (cboAñoProg.Text <> "Seleccione") Then
                                        If (txtCalibre.Text.Trim <> "") Then
                                            If IsNumeric(txtCalibre.Text.Trim) Then
                                                Return True
                                            Else
                                                MessageBox.Show("Ingrese un calibre valido", "Calibre no valido", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                            End If
                                        Else
                                            MessageBox.Show("Ingrese un calibre", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                        End If
                                        '    Else
                                        '        MessageBox.Show("Ingrese un Mes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                        '    End If
                                        'Else
                                        '    MessageBox.Show("Ingrese un Año", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                        'End If
                                    Else
                                        MessageBox.Show("La referencia que se ingreso no esta activa", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    End If
                                Else
                                    MessageBox.Show("La referencia que se ingreso no existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                End If
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
                    MessageBox.Show("Seleccione un codigo  de materia prima origen", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                MessageBox.Show("Seleccione un cliente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
        Return False
    End Function
    'Nuevo(): ESTE METODO SIRVE PARA LIMPIAR LOS CAMPOS
    Private Sub nuevo()

        txtProdFinal.Text = ""
        txtCantProg.Text = ""
        cboOrigen.Text = "Seleccione"
        cboCliente.Text = "Seleccione"
        'cboMesProg.SelectedValue = Now.Month
        'cboAñoProg.Text = Now.Year
        txtnota.Text = ""
        txtCalibre.Text = ""
    End Sub
    ''metodo qu actualiza el consecutivo principal
    Private Sub actualizarConsecutivoPpal(ByVal consecutivo As String)
        consecutivoPpal = consecutivo
    End Sub

    'recibe un codigo y se los asigna a un textbox
    Public Sub d_codigo(ByVal codigo As String)
        pcodigo = codigo
        txtProdFinal.Text = pcodigo
    End Sub
    'carga la consulta de las ordenes de produccion existentes
    Private Sub cargarAdminProd(ByVal consecutivo As String)
        Dim fecIni As String = cboFechaIni.Value.ToString("yyyy-MM-dd")
        Dim fecFin As String = cboFechaFin.Value.ToString("yyyy-MM-dd")
        Dim cont_C As Integer = 0
        Dim cont_S As Integer = 0
        Dim porce_cum As Double
        Dim WhereCliExt As String = ""
        Dim WhereFec As String = ""
        If (cargaComp) Then
            If fecFin = fecIni Then
                WhereFec = " WHERE year(fecha_creacion) = " & CInt(cboFechaIni.Value.Year) & " and month(fecha_creacion)= " & CInt(cboFechaIni.Value.Month) & " and day(fecha_creacion)=" & CInt(cboFechaIni.Value.Day) & ""
            Else
                WhereFec = " WHERE fecha_creacion >='" & fecIni & "' and fecha_creacion <='" & fecFin & "'"
            End If
            If (consecutivo <> "") Then
                WhereFec += " AND consecutivo_orden_G =" & consecutivo & ""
            End If
        End If
        Dim sql As String = "SELECT consecutivo_orden_G,Nombre_cliente,origen_galv,cant_prog,(select sum(peso) from D_rollo_galvanizado_f where nro_orden=consecutivo_orden_G and anular is null and no_conforme is null ) as cant_lleva,final_galv,nota,notas_auditoria,fecha_creacion,notas_liquidacion,oculto FROM D_orden_pro_galv_enc" & WhereFec & WhereCliExt
        dtg_consulta.DataSource = obj_Ing_prodLn.listar_datatable(sql, "PRODUCCION")
        calcuPorcen()

        dtg_consulta.Columns("final_galv").DefaultCellStyle = formatoNegrita()
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
            If Mid(Row.Cells("final_galv").Value, 1, 2) = "22" Then
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
        pintartotal()
        dtg_consulta.AutoResizeColumns()
    End Sub
    Public Sub pintartotal()
        If dtg_consulta.Rows.Count > 0 Then
            dtg_consulta.Rows(dtg_consulta.Rows.Count - 1).DefaultCellStyle.BackColor = Color.Salmon
            dtg_consulta.Rows(dtg_consulta.Rows.Count - 1).DefaultCellStyle.Font = New Font(dtg_consulta.CurrentCell.InheritedStyle.Font, FontStyle.Bold)
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
                dt.Rows(dt.Rows.Count - 1).Item("origen_galv") = "TOTAL"
                dt.Rows(dt.Rows.Count - 1).Item("cant_prog") = cant_prog
                dt.Rows(dt.Rows.Count - 1).Item("cant_lleva") = kilos
                Exit For
            End If
            indice += 1
        Next
        Return dt
    End Function
    'carga la consulta sobre las ordenes de produccion disponibles para trabajar
    Private Sub cargarPlanOperario()
        If Not (estadoTurno) Then

            cboAnoConsulta.DataSource = Nothing
            Dim ano As Integer = cboAnoConsulta.Text
            Dim mes As Integer = cboMesConsulta.SelectedValue
            Dim sql As String = "SELECT orden.consecutivo_orden_G As num_orden,orden.calibre,orden.final_galv As prod_final,orden.Nombre_cliente,(SELECT CASE " &
                                       "WHEN orden.mes = 1 " &
                                        "THEN 'Enero' " &
                                       "WHEN orden.mes = 2 " &
                                        "THEN 'Febrero' " &
                                       "WHEN orden.mes = 3 " &
                                        "THEN 'Marzo' " &
                                       "WHEN orden.mes = 4 " &
                                        "THEN 'Abril' " &
                                       "WHEN orden.mes = 5 " &
                                        "THEN 'Mayo' " &
                                       "WHEN orden.mes = 6 " &
                                        "THEN 'Junio' " &
                                       "WHEN orden.mes = 7 " &
                                        "THEN 'Julio' " &
                                       "WHEN orden.mes = 8 " &
                                        "THEN 'Agosto' " &
                                       "WHEN orden.mes = 9 " &
                                        "THEN 'Septiembre' " &
                                       "WHEN orden.mes = 10 " &
                                        "THEN 'Octubre' " &
                                       "WHEN orden.mes = 11 " &
                                        "THEN 'Noviembre' " &
                                       "WHEN orden.mes = 12 " &
                                        "THEN 'Diciembre' " &
                                       "END)As mes,orden.ano as año,orden.origen_galv As alambre_brillante, orden.cant_prog as Cantidad,orden.fecha_creacion " &
                                                 "FROM D_orden_pro_galv_enc orden" &
                                            " WHERE orden.oculto=0 or orden.oculto is null AND orden.mes = " & mes & " AND orden.ano = " & ano &
                                                    " ORDER BY prod_final ASC "
            dtgOperario.DataSource = objOpsimpesLn.listar_datatable(sql, "PRODUCCION")
            For Each Row As DataGridViewRow In dtgOperario.Rows
                If Mid(Row.Cells("prod_final").Value, 1, 2) = "22" Then
                    Row.DefaultCellStyle.BackColor = Color.GreenYellow
                End If
            Next
            dtgOperario.Columns("prod_final").DefaultCellStyle = formatoNegrita()
            dtgOperario.Columns("alambre_brillante").DefaultCellStyle = formatoNegrita()
            dtgOperario.Columns("calibre").DefaultCellStyle = formatoNegrita()
            dtgOperario.Columns("Nombre_cliente").DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0)
            dtgOperario.Columns("num_orden").Visible = False
            'pintar_operarios()
            dtgOperario.Columns("fecha_creacion").Visible = False
        End If
    End Sub
    'Public Sub pintar_operarios()
    '    Dim fecha As String = CDate(Now)
    '    Dim fecha_hora As String = objOpSimplesLn.cambiarFormatoFecha(Now)
    '    fecha_hora = CDate(fecha_hora & " 00:01:00")
    '    Dim fecha_6 As String = objOpSimplesLn.cambiarFormatoFecha(Now)
    '    fecha_6 = CDate(fecha_6 & " 05:45:00")
    '    Dim fecha_5_m As String = objOpSimplesLn.cambiarFormatoFecha(Now.AddDays(1))
    '    fecha_5_m = CDate(fecha_5_m & " 05:45:00")
    '    If CDate(fecha) >= CDate(fecha_6) And CDate(fecha) <= CDate(fecha_5_m) Then
    '        For Each Row As DataGridViewRow In dtgOperario.Rows
    '            fecha_hora = CDate(fecha_hora).AddDays(1)
    '            If CDate(fecha) >= CDate(fecha_hora) Then
    '                fecha_hora = CDate(fecha_hora).AddDays(-1)
    '                If Not IsDBNull(Row.Cells("fecha_creacion").Value) Then
    '                    If Row.Cells("fecha_creacion").Value = fecha_hora Then
    '                        Row.DefaultCellStyle.BackColor = Color.GreenYellow
    '                    Else
    '                        Row.DefaultCellStyle.BackColor = Color.LightCoral
    '                    End If
    '                Else
    '                    Row.DefaultCellStyle.BackColor = Color.LightCoral
    '                End If
    '            Else
    '                fecha_hora = objOpSimplesLn.cambiarFormatoFecha(Now)
    '                fecha_hora = fecha_hora & " 00:00:00"
    '                If Not IsDBNull(Row.Cells("fecha_creacion").Value) Then
    '                    If Row.Cells("fecha_creacion").Value = CDate(fecha_hora) Then
    '                        Row.DefaultCellStyle.BackColor = Color.GreenYellow
    '                    Else
    '                        Row.DefaultCellStyle.BackColor = Color.LightCoral
    '                    End If
    '                Else
    '                    Row.DefaultCellStyle.BackColor = Color.LightCoral
    '                End If
    '            End If
    '            If Row.Cells("prod_final").Value.Contains("33G") Then
    '                Row.DefaultCellStyle.BackColor = Color.GreenYellow
    '            End If
    '        Next
    '    End If
    'End Sub
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
    Private Sub cargarRollos()
        If Not (estadoTurno) Then
            Dim fecha As String = objOpsimpesLn.cambiarFormatoFecha(DateTime.Now)
            Dim value As Object = cboOperariosG.SelectedValue
            If (TypeOf value Is DataRowView) Then Return
            Dim nit As Integer = CInt(value)
            Dim sql_rollo As String = "select orden.final_galv,rollo.peso,rollo.bobina,rollo.nro_orden,rollo.consecutivo_rollo,rollo.anular,rollo.trans_galv,rollo.tipo_trans from D_rollo_galvanizado_f rollo, D_orden_pro_galv_enc orden where no_conforme is null and fecha_hora >='" & fecha & "' and rollo.nit_operario=" & nit & " and rollo.nro_orden = orden.consecutivo_orden_G order by fecha_hora desc"
            dtgRollos.DataSource = objOpsimpesLn.listar_datatable(sql_rollo, "PRODUCCION")
            Me.dtgRollos.Columns("anular").Visible = False
            Me.dtgRollos.Columns("trans_galv").Visible = False
            Me.dtgRollos.Columns("tipo_trans").Visible = False
            For Each Row As DataGridViewRow In dtgRollos.Rows
                If IsDBNull(Row.Cells("anular").Value) = False Then
                    Row.DefaultCellStyle.BackColor = Color.Red
                End If
            Next
        End If
    End Sub

    Public Function formatoNegrita() As DataGridViewCellStyle
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold)
        Return DataGridViewCellStyle1
    End Function
    Private Sub dtg_consulta_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtg_consulta.CellContentClick
        Dim col As String = dtg_consulta.Columns(e.ColumnIndex).Name
        If (col = btnVerDetalle.Name) Then
            actualizarConsecutivoPpal(dtg_consulta.Item("consecutivo_orden_G", dtg_consulta.CurrentCell.RowIndex).Value)
            cargarDatos()
            TblPpal.SelectedTab = tbl_orden_prod_g
        ElseIf (col = col_oculto.Name) Then
            Dim sql As String
            Dim bloqueo As String
            sql = "select oculto from D_orden_pro_galv_enc WHERE consecutivo_orden_G = " & dtg_consulta.Item("consecutivo_orden_G", dtg_consulta.CurrentCell.RowIndex).Value & ""
            bloqueo = objOpsimpesLn.consultValorTodo(sql, "PRODUCCION")
            If bloqueo = "" Then
                If (MessageBox.Show("Esta seguro que desea liquidar y ocultar la orden.Ya no se puede trabajar una orden liquidada, tenga en cuenta que si oculta una Orden no se vera en los computadores de GALVANIZADO", "ocultar Orden?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) = 6) Then
                    If (MessageBox.Show("Desea agregar nota de liquidación", "Nota al liquidar?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) = 6) Then
                        Dim frm As New frm_Bloquear_ordenes
                        frm.main(dtg_consulta.Item("consecutivo_orden_G", dtg_consulta.CurrentCell.RowIndex).Value, "G")
                        frm.ShowDialog()
                    End If
                    Dim estado As Integer
                    Dim accion As String = "Liquido"
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
                    Dim consecutivo As Integer = dtg_consulta.Item("consecutivo_orden_G", dtg_consulta.CurrentCell.RowIndex).Value
                    Dim nombre_usuario As String = usuario.usuario
                    sql = "UPDATE D_orden_pro_galv_enc SET oculto = " & estado & ",bloqueo=" & estado & ",notas_auditoria +=  '" & accion & " " & nombre_usuario & " " & Now.Date & "' WHERE consecutivo_orden_G = " & consecutivo
                    If (objOpsimpesLn.ejecutar(sql, "PRODUCCION")) Then
                        MessageBox.Show("La orden se " & accion & " en forma exitosa!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("Error al " & accion & " la orden, comuniquese con el administrador del sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                    cargaComp = True
                End If
            Else
                MessageBox.Show("Una orden liquidada no se puede desbloquear", "Orden Liquidada", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        ElseIf (col = col_duplicar.Name) Then
                Dim frm As New frm_Duplicar
            frm.main(dtg_consulta.Item("consecutivo_orden_G", e.RowIndex).Value, usuario.usuario, dtg_consulta.Item("final_galv", e.RowIndex).Value, dtg_consulta.Item("origen_galv", e.RowIndex).Value, "G")
            frm.Show()
            cargarAdminProd(txtConsulNumOrd.Text)
        End If
    End Sub

    Private Sub cargarDatos()
        Dim sql As String = "SELECT final_galv,cant_prog,nit_cliente,origen_galv,fecha_creacion,nota,calibre " &
                              "FROM D_orden_pro_galv_enc WHERE consecutivo_orden_G = " & consecutivoPpal
        Dim lista As New List(Of Object)
        Dim tam As Integer = 7
        lista = obj_Ing_prodLn.listaForm(consecutivoPpal, tam, sql)
        If (lista.Count > 0) Then

            txtProdFinal.Text = lista(0)
            txtCantProg.Text = lista(1)
            cboCliente.SelectedValue = lista(2)
            cboOrigen.SelectedValue = lista(3)
            If Not IsDBNull(lista(4)) Then
                cbo_fec_orden.Value = lista(4)
            End If
            If Not IsDBNull(lista(5)) Then
                txtnota.Text = lista(5)
            End If
            If Not IsDBNull(lista(6)) Then
                txtCalibre.Text = lista(6)
            End If
        End If
    End Sub
    Private Sub borrar_orden()
        Dim borrar As String
        borrar = "delete from D_orden_pro_galv_enc where consecutivo_orden_G=" & consecutivoPpal & ""
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

    Private Sub dtgOperario_CellContentClick_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgOperario.CellContentClick
        Dim col As String = dtgOperario.Columns(e.ColumnIndex).Name
        Dim fila As Integer = e.RowIndex
        Dim codigo_materia_prima As String
        Dim nit_usuario As Integer = cboOperariosG.SelectedValue
        Dim modelo As String = "01"
        Dim bodega_origen As Integer = 11
        If (fila >= 0) Then
            If (col = "btnregistrar_materia_prima") Then
                If dtgOperario.Rows(fila).DefaultCellStyle.BackColor <> Color.LightCoral Then
                    codigo_materia_prima = dtgOperario.Item("alambre_brillante", fila).Value()
                    Dim frm As New Frm_transacion_bodega_G
                    frm.Main(codigo_materia_prima, nit_usuario, bodega_origen, modelo)
                    frm.ShowDialog()
                Else
                    MessageBox.Show("No se puede trabajar ordenes que esten en color rojo! ", "Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            ElseIf (col = "btnTrabajar") Then
                If cboOperariosG.Text <> "Seleccione" Then
                    If dtgOperario.Rows(fila).DefaultCellStyle.BackColor <> Color.LightCoral Then
                        If Not (estadoTurno) Then
                            actualizarConsecutivoPpal(dtgOperario.Item("num_orden", fila).Value)
                            lblorden.Text = dtgOperario.Item("num_orden", fila).Value
                            lblproducto.Text = dtgOperario.Item("prod_final", fila).Value
                            lbloperarios.Text = cboOperariosG.Text
                            materia_prima = dtgOperario.Item("alambre_brillante", fila).Value
                            cargarDatos()
                            TblPpal.SelectedTab = tbl_orden_prod_g
                            recorrer_botones_color()
                            GB_cargar_rollo.Enabled = True
                            Button1.Enabled = True
                            Button2.Enabled = True
                            Button3.Enabled = True
                            Button4.Enabled = True
                            Button5.Enabled = True
                            Button6.Enabled = True
                            Button7.Enabled = True
                            Button8.Enabled = True
                            Button9.Enabled = True
                            Button10.Enabled = True
                            Button11.Enabled = True
                            Button12.Enabled = True
                            Button13.Enabled = True
                            Button14.Enabled = True
                            Button15.Enabled = True
                            Button16.Enabled = True
                            Button17.Enabled = True
                            Button18.Enabled = True
                            Button19.Enabled = True
                            Button20.Enabled = True
                            Button21.Enabled = True
                            Button22.Enabled = True
                            Button23.Enabled = True
                            Button24.Enabled = True
                            Button25.Enabled = True
                            'pintar_operarios()
                            dtgOperario.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Red
                        Else
                            MessageBox.Show("No se a terminado con el turno anterior,verifique el boton terminar planilla de la pestaña 'PRODUCCIÓN OPERARIO'! ", "Verifique!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If
                    Else
                        MessageBox.Show("No se puede trabajar ordenes que esten en color rojo! ", "Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                Else
                        MessageBox.Show("Seleccione un operario por favor 'Selección de OPERARIO'! ", "Verifique!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End If
        End If
    End Sub
    Public Sub obtener_pesodevanador(ByVal pesodev As String)
        peso_devanador = pesodev
    End Sub
    Public Sub recorrer_botones_color()
        Dim peso_d As String
        Dim sql As String = "select P_devanador from D_Bobina_Devanador where nro_bobina= "
        Dim sql_total As String = ""
        For i As Integer = 1 To 25
            sql_total = sql & i
            peso_d = objOpsimpesLn.consultValorTodo(sql_total, "PRODUCCION")
            If Button1.Text = i Then
                If peso_d = "" Or peso_d = "0" Then
                    Button1.BackColor = Color.Red
                Else
                    Button1.BackColor = Color.GreenYellow
                End If
            End If
            If Button2.Text = i Then
                If peso_d = "" Or peso_d = "0" Then
                    Button2.BackColor = Color.Red
                Else
                    Button2.BackColor = Color.GreenYellow
                End If
            End If
            If Button3.Text = i Then
                If peso_d = "" Or peso_d = "0" Then
                    Button3.BackColor = Color.Red
                Else
                    Button3.BackColor = Color.GreenYellow
                End If
            End If
            If Button4.Text = i Then
                If peso_d = "" Or peso_d = "0" Then
                    Button4.BackColor = Color.Red
                Else
                    Button4.BackColor = Color.GreenYellow
                End If
            End If
            If Button5.Text = i Then
                If peso_d = "" Or peso_d = "0" Then
                    Button5.BackColor = Color.Red
                Else
                    Button5.BackColor = Color.GreenYellow
                End If
            End If
            If Button6.Text = i Then
                If peso_d = "" Or peso_d = "0" Then
                    Button6.BackColor = Color.Red
                Else
                    Button6.BackColor = Color.GreenYellow
                End If
            End If
            If Button7.Text = i Then
                If peso_d = "" Or peso_d = "0" Then
                    Button7.BackColor = Color.Red
                Else
                    Button7.BackColor = Color.GreenYellow
                End If
            End If
            If Button8.Text = i Then
                If peso_d = "" Or peso_d = "0" Then
                    Button8.BackColor = Color.Red
                Else
                    Button8.BackColor = Color.GreenYellow
                End If
            End If
            If Button9.Text = i Then
                If peso_d = "" Or peso_d = "0" Then
                    Button9.BackColor = Color.Red
                Else
                    Button9.BackColor = Color.GreenYellow
                End If
            End If
            If Button10.Text = i Then
                If peso_d = "" Or peso_d = "0" Then
                    Button10.BackColor = Color.Red
                Else
                    Button10.BackColor = Color.GreenYellow
                End If
            End If
            If Button11.Text = i Then
                If peso_d = "" Or peso_d = "0" Then
                    Button11.BackColor = Color.Red
                Else
                    Button11.BackColor = Color.GreenYellow
                End If
            End If
            If Button12.Text = i Then
                If peso_d = "" Or peso_d = "0" Then
                    Button12.BackColor = Color.Red
                Else
                    Button12.BackColor = Color.GreenYellow
                End If
            End If
            If Button13.Text = i Then
                If peso_d = "" Or peso_d = "0" Then
                    Button13.BackColor = Color.Red
                Else
                    Button13.BackColor = Color.GreenYellow
                End If
            End If
            If Button14.Text = i Then
                If peso_d = "" Or peso_d = "0" Then
                    Button14.BackColor = Color.Red
                Else
                    Button14.BackColor = Color.GreenYellow
                End If
            End If
            If Button15.Text = i Then
                If peso_d = "" Or peso_d = "0" Then
                    Button15.BackColor = Color.Red
                Else
                    Button15.BackColor = Color.GreenYellow
                End If
            End If
            If Button16.Text = i Then
                If peso_d = "" Or peso_d = "0" Then
                    Button16.BackColor = Color.Red
                Else
                    Button16.BackColor = Color.GreenYellow
                End If
            End If
            If Button17.Text = i Then
                If peso_d = "" Or peso_d = "0" Then
                    Button17.BackColor = Color.Red
                Else
                    Button17.BackColor = Color.GreenYellow
                End If
            End If
            If Button18.Text = i Then
                If peso_d = "" Or peso_d = "0" Then
                    Button18.BackColor = Color.Red
                Else
                    Button18.BackColor = Color.GreenYellow
                End If
            End If
            If Button19.Text = i Then
                If peso_d = "" Or peso_d = "0" Then
                    Button19.BackColor = Color.Red
                Else
                    Button19.BackColor = Color.GreenYellow
                End If
            End If
            If Button20.Text = i Then
                If peso_d = "" Or peso_d = "0" Then
                    Button20.BackColor = Color.Red
                Else
                    Button20.BackColor = Color.GreenYellow
                End If
            End If
            If Button21.Text = i Then
                If peso_d = "" Or peso_d = "0" Then
                    Button21.BackColor = Color.Red
                Else
                    Button21.BackColor = Color.GreenYellow
                End If
            End If
            If Button22.Text = i Then
                If peso_d = "" Or peso_d = "0" Then
                    Button22.BackColor = Color.Red
                Else
                    Button22.BackColor = Color.GreenYellow
                End If
            End If
            If Button23.Text = i Then
                If peso_d = "" Or peso_d = "0" Then
                    Button23.BackColor = Color.Red
                Else
                    Button23.BackColor = Color.GreenYellow
                End If
            End If
            If Button24.Text = i Then
                If peso_d = "" Or peso_d = "0" Then
                    Button24.BackColor = Color.Red
                Else
                    Button24.BackColor = Color.GreenYellow
                End If
            End If
            If Button25.Text = i Then
                If peso_d = "" Or peso_d = "0" Then
                    Button25.BackColor = Color.Red
                Else
                    Button25.BackColor = Color.GreenYellow
                End If
            End If


        Next

    End Sub
    Private Sub btnBod2_3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBod2_3.Click
        Dim frm As New frm_seleccion_rollos_galv
        frm.main(txtProdFinal.Text, Me)
        frm.ShowDialog()
    End Sub

    Private Sub cboOperariosG_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If cargaComp Then
            cargarPlanOperario()
        End If
    End Sub
    'Estos son las acciones de los botones de las bobinas
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim frm As New Frm_pesar_cargar_rollo
        nro_bobina = 1
        frm.main(nro_bobina, lblproducto.Text, materia_prima, lblorden.Text, lbloperarios.Text, cboOperariosG.SelectedValue, puerto_serial, cboCliente.SelectedValue, txtCalibre.Text)
        frm.ShowDialog()
        cargarRollos()
        TblPpal.SelectedTab = Tbl_seleccion_orden
        recorrer_botones_color()
        cargarPlanOperario()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim frm As New Frm_pesar_cargar_rollo
        nro_bobina = 2
        frm.main(nro_bobina, lblproducto.Text, materia_prima, lblorden.Text, lbloperarios.Text, cboOperariosG.SelectedValue, puerto_serial, cboCliente.SelectedValue, txtCalibre.Text)
        frm.ShowDialog()
        cargarRollos()
        TblPpal.SelectedTab = Tbl_seleccion_orden
        recorrer_botones_color()
        cargarPlanOperario()
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim frm As New Frm_pesar_cargar_rollo
        nro_bobina = 3
        frm.main(nro_bobina, lblproducto.Text, materia_prima, lblorden.Text, lbloperarios.Text, cboOperariosG.SelectedValue, puerto_serial, cboCliente.SelectedValue, txtCalibre.Text)
        frm.ShowDialog()
        cargarRollos()
        TblPpal.SelectedTab = Tbl_seleccion_orden
        recorrer_botones_color()
        cargarPlanOperario()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim frm As New Frm_pesar_cargar_rollo
        nro_bobina = 4
        frm.main(nro_bobina, lblproducto.Text, materia_prima, lblorden.Text, lbloperarios.Text, cboOperariosG.SelectedValue, puerto_serial, cboCliente.SelectedValue, txtCalibre.Text)
        frm.ShowDialog()
        cargarRollos()
        TblPpal.SelectedTab = Tbl_seleccion_orden
        recorrer_botones_color()
        cargarPlanOperario()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim frm As New Frm_pesar_cargar_rollo
        nro_bobina = 5
        frm.main(nro_bobina, lblproducto.Text, materia_prima, lblorden.Text, lbloperarios.Text, cboOperariosG.SelectedValue, puerto_serial, cboCliente.SelectedValue, txtCalibre.Text)
        frm.ShowDialog()
        cargarRollos()
        TblPpal.SelectedTab = Tbl_seleccion_orden
        recorrer_botones_color()
        cargarPlanOperario()
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Dim frm As New Frm_pesar_cargar_rollo
        nro_bobina = 6
        frm.main(nro_bobina, lblproducto.Text, materia_prima, lblorden.Text, lbloperarios.Text, cboOperariosG.SelectedValue, puerto_serial, cboCliente.SelectedValue, txtCalibre.Text)
        frm.ShowDialog()
        cargarRollos()
        TblPpal.SelectedTab = Tbl_seleccion_orden
        recorrer_botones_color()
        cargarPlanOperario()
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Dim frm As New Frm_pesar_cargar_rollo
        nro_bobina = 7
        frm.main(nro_bobina, lblproducto.Text, materia_prima, lblorden.Text, lbloperarios.Text, cboOperariosG.SelectedValue, puerto_serial, cboCliente.SelectedValue, txtCalibre.Text)
        frm.ShowDialog()
        cargarRollos()
        TblPpal.SelectedTab = Tbl_seleccion_orden
        recorrer_botones_color()
        cargarPlanOperario()
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Dim frm As New Frm_pesar_cargar_rollo
        nro_bobina = 8
        frm.main(nro_bobina, lblproducto.Text, materia_prima, lblorden.Text, lbloperarios.Text, cboOperariosG.SelectedValue, puerto_serial, cboCliente.SelectedValue, txtCalibre.Text)
        frm.ShowDialog()
        cargarRollos()
        TblPpal.SelectedTab = Tbl_seleccion_orden
        recorrer_botones_color()
        cargarPlanOperario()
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Dim frm As New Frm_pesar_cargar_rollo
        nro_bobina = 9
        frm.main(nro_bobina, lblproducto.Text, materia_prima, lblorden.Text, lbloperarios.Text, cboOperariosG.SelectedValue, puerto_serial, cboCliente.SelectedValue, txtCalibre.Text)
        frm.ShowDialog()
        cargarRollos()
        TblPpal.SelectedTab = Tbl_seleccion_orden
        recorrer_botones_color()
        cargarPlanOperario()
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        Dim frm As New Frm_pesar_cargar_rollo
        nro_bobina = 10
        frm.main(nro_bobina, lblproducto.Text, materia_prima, lblorden.Text, lbloperarios.Text, cboOperariosG.SelectedValue, puerto_serial, cboCliente.SelectedValue, txtCalibre.Text)
        frm.ShowDialog()
        cargarRollos()
        TblPpal.SelectedTab = Tbl_seleccion_orden
        recorrer_botones_color()
        cargarPlanOperario()
    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        Dim frm As New Frm_pesar_cargar_rollo
        nro_bobina = 11
        frm.main(nro_bobina, lblproducto.Text, materia_prima, lblorden.Text, lbloperarios.Text, cboOperariosG.SelectedValue, puerto_serial, cboCliente.SelectedValue, txtCalibre.Text)
        frm.ShowDialog()
        cargarRollos()
        TblPpal.SelectedTab = Tbl_seleccion_orden
        recorrer_botones_color()
        cargarPlanOperario()
    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        Dim frm As New Frm_pesar_cargar_rollo
        nro_bobina = 12
        frm.main(nro_bobina, lblproducto.Text, materia_prima, lblorden.Text, lbloperarios.Text, cboOperariosG.SelectedValue, puerto_serial, cboCliente.SelectedValue, txtCalibre.Text)
        frm.ShowDialog()
        cargarRollos()
        TblPpal.SelectedTab = Tbl_seleccion_orden
        recorrer_botones_color()
        cargarPlanOperario()
    End Sub

    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        Dim frm As New Frm_pesar_cargar_rollo
        nro_bobina = 13
        frm.main(nro_bobina, lblproducto.Text, materia_prima, lblorden.Text, lbloperarios.Text, cboOperariosG.SelectedValue, puerto_serial, cboCliente.SelectedValue, txtCalibre.Text)
        frm.ShowDialog()
        cargarRollos()
        TblPpal.SelectedTab = Tbl_seleccion_orden
        recorrer_botones_color()
        cargarPlanOperario()
    End Sub

    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
        Dim frm As New Frm_pesar_cargar_rollo
        nro_bobina = 14
        frm.main(nro_bobina, lblproducto.Text, materia_prima, lblorden.Text, lbloperarios.Text, cboOperariosG.SelectedValue, puerto_serial, cboCliente.SelectedValue, txtCalibre.Text)
        frm.ShowDialog()
        cargarRollos()
        TblPpal.SelectedTab = Tbl_seleccion_orden
        recorrer_botones_color()
        cargarPlanOperario()
    End Sub

    Private Sub Button15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button15.Click
        Dim frm As New Frm_pesar_cargar_rollo
        nro_bobina = 15
        frm.main(nro_bobina, lblproducto.Text, materia_prima, lblorden.Text, lbloperarios.Text, cboOperariosG.SelectedValue, puerto_serial, cboCliente.SelectedValue, txtCalibre.Text)
        frm.ShowDialog()
        cargarRollos()
        TblPpal.SelectedTab = Tbl_seleccion_orden
        recorrer_botones_color()
        cargarPlanOperario()
    End Sub

    Private Sub Button16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button16.Click
        Dim frm As New Frm_pesar_cargar_rollo
        nro_bobina = 16
        frm.main(nro_bobina, lblproducto.Text, materia_prima, lblorden.Text, lbloperarios.Text, cboOperariosG.SelectedValue, puerto_serial, cboCliente.SelectedValue, txtCalibre.Text)
        frm.ShowDialog()
        cargarRollos()
        TblPpal.SelectedTab = Tbl_seleccion_orden
        recorrer_botones_color()
        cargarPlanOperario()
    End Sub


    Private Sub Button17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button17.Click
        Dim frm As New Frm_pesar_cargar_rollo
        nro_bobina = 17
        frm.main(nro_bobina, lblproducto.Text, materia_prima, lblorden.Text, lbloperarios.Text, cboOperariosG.SelectedValue, puerto_serial, cboCliente.SelectedValue, txtCalibre.Text)
        frm.ShowDialog()
        cargarRollos()
        TblPpal.SelectedTab = Tbl_seleccion_orden
        recorrer_botones_color()
        cargarPlanOperario()
    End Sub

    Private Sub Button18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button18.Click
        Dim frm As New Frm_pesar_cargar_rollo
        nro_bobina = 18
        frm.main(nro_bobina, lblproducto.Text, materia_prima, lblorden.Text, lbloperarios.Text, cboOperariosG.SelectedValue, puerto_serial, cboCliente.SelectedValue, txtCalibre.Text)
        frm.ShowDialog()
        cargarRollos()
        TblPpal.SelectedTab = Tbl_seleccion_orden
        recorrer_botones_color()
        cargarPlanOperario()
    End Sub

    Private Sub Button19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button19.Click
        Dim frm As New Frm_pesar_cargar_rollo
        nro_bobina = 19
        frm.main(nro_bobina, lblproducto.Text, materia_prima, lblorden.Text, lbloperarios.Text, cboOperariosG.SelectedValue, puerto_serial, cboCliente.SelectedValue, txtCalibre.Text)
        frm.ShowDialog()
        cargarRollos()
        TblPpal.SelectedTab = Tbl_seleccion_orden
        recorrer_botones_color()
        cargarPlanOperario()
    End Sub

    Private Sub Button20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button20.Click
        Dim frm As New Frm_pesar_cargar_rollo
        nro_bobina = 20
        frm.main(nro_bobina, lblproducto.Text, materia_prima, lblorden.Text, lbloperarios.Text, cboOperariosG.SelectedValue, puerto_serial, cboCliente.SelectedValue, txtCalibre.Text)
        frm.ShowDialog()
        cargarRollos()
        TblPpal.SelectedTab = Tbl_seleccion_orden
        recorrer_botones_color()
        cargarPlanOperario()
    End Sub

    Private Sub Button21_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button21.Click
        Dim frm As New Frm_pesar_cargar_rollo
        nro_bobina = 21
        frm.main(nro_bobina, lblproducto.Text, materia_prima, lblorden.Text, lbloperarios.Text, cboOperariosG.SelectedValue, puerto_serial, cboCliente.SelectedValue, txtCalibre.Text)
        frm.ShowDialog()
        cargarRollos()
        TblPpal.SelectedTab = Tbl_seleccion_orden
        recorrer_botones_color()
        cargarPlanOperario()
    End Sub

    Private Sub Button22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button22.Click
        Dim frm As New Frm_pesar_cargar_rollo
        nro_bobina = 22
        frm.main(nro_bobina, lblproducto.Text, materia_prima, lblorden.Text, lbloperarios.Text, cboOperariosG.SelectedValue, puerto_serial, cboCliente.SelectedValue, txtCalibre.Text)
        frm.ShowDialog()
        cargarRollos()
        TblPpal.SelectedTab = Tbl_seleccion_orden
        recorrer_botones_color()
        cargarPlanOperario()
    End Sub

    Private Sub Button23_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button23.Click
        Dim frm As New Frm_pesar_cargar_rollo
        nro_bobina = 23
        frm.main(nro_bobina, lblproducto.Text, materia_prima, lblorden.Text, lbloperarios.Text, cboOperariosG.SelectedValue, puerto_serial, cboCliente.SelectedValue, txtCalibre.Text)
        frm.ShowDialog()
        cargarRollos()
        TblPpal.SelectedTab = Tbl_seleccion_orden
        recorrer_botones_color()
        cargarPlanOperario()
    End Sub

    Private Sub Button24_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button24.Click
        Dim frm As New Frm_pesar_cargar_rollo
        nro_bobina = 24
        frm.main(nro_bobina, lblproducto.Text, materia_prima, lblorden.Text, lbloperarios.Text, cboOperariosG.SelectedValue, puerto_serial, cboCliente.SelectedValue, txtCalibre.Text)
        frm.ShowDialog()
        cargarRollos()
        TblPpal.SelectedTab = Tbl_seleccion_orden
        recorrer_botones_color()
        cargarPlanOperario()
    End Sub

    Private Sub Button25_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button25.Click
        Dim frm As New Frm_pesar_cargar_rollo
        nro_bobina = 25
        frm.main(nro_bobina, lblproducto.Text, materia_prima, lblorden.Text, lbloperarios.Text, cboOperariosG.SelectedValue, puerto_serial, cboCliente.SelectedValue, txtCalibre.Text)
        frm.ShowDialog()
        cargarRollos()
        TblPpal.SelectedTab = Tbl_seleccion_orden
        recorrer_botones_color()
        cargarPlanOperario()
    End Sub

    Private Sub chkpuerto1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkpuerto1.CheckedChanged
        If cargaComp Then
            Dim resul As MsgBoxResult
            If chkpuerto1.Checked = True Then
                resul = MessageBox.Show("Desea cambiar de pesa?", "Cambiar medio para pesar", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                If resul = vbYes Then
                    puerto_serial = 1
                    chkpuerto2.Checked = False
                Else
                    chkpuerto1.Checked = False
                End If
            Else
                chkpuerto2.Checked = True
            End If
        End If
    End Sub

    Private Sub chkpuerto2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkpuerto2.CheckedChanged
        If cargaComp Then
            Dim resul As MsgBoxResult
            If chkpuerto2.Checked = True Then
                resul = MessageBox.Show("Desea cambiar de pesa?", "Cambiar medio para pesar", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                If resul = vbYes Then
                    puerto_serial = 2
                    chkpuerto1.Checked = False
                Else
                    chkpuerto2.Checked = False
                End If
            Else
                chkpuerto1.Checked = True
            End If
        End If

    End Sub
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
                    result = MessageBox.Show("Desea anular el rollo?", "Anular rollo", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                    Dim anular As Integer = 1
                    Dim codigo As String = dtgRollos.Item("final_galv", fila).Value()
                    Dim bodega As String = objTraslado_bodLn.obtenerBodegaXcodigo(codigo)
                    bodega = 2
                    Dim stock As Double = objOpSimplesLn.consultarStock(codigo, bodega)
                    Dim peso As Double = dtgRollos.Item("peso", fila).Value()
                    If result = vbYes Then
                        Dim motivo As String = InputBox("Ingrese motivo de autorización de la transacción", "Ingrese motivo")
                        If motivo <> "" Then
                            If peso <= stock Then
                                motivo &= "-" & Now & "- " & cboOperariosG.SelectedValue
                                orden = dtgRollos.Item("nro_orden", fila).Value()
                                consecutivo = dtgRollos.Item("consecutivo_rollo", fila).Value()
                                Dim numero_trans As Double = dtgRollos.Item("trans_galv", fila).Value()
                                Dim tipo_trans As String = dtgRollos.Item("tipo_trans", fila).Value()
                                Dim listSql As New List(Of Object)
                                listSql.AddRange(objTraslado_bodLn.anularTransaccion(numero_trans, tipo_trans, motivo))
                                If objOpsimpesLn.ExecuteSqlTransaction(listSql) Then
                                    Dim sql As String = "UPDATE D_rollo_galvanizado_f SET anular=" & anular & " where nro_orden=" & orden & " and consecutivo_rollo=" & consecutivo & ""
                                    If (objOpsimpesLn.ejecutar(sql, "PRODUCCION") > 0) Then
                                        cargarRollos()
                                        MessageBox.Show("Rollo anulado", "Anular rollo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    End If
                                End If
                            Else
                                MessageBox.Show("El rollo a elimar supera el stock de la bodega'STOCK BODEGA'! ", "Verifique!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            End If
                        End If
                    End If
                Else
                    MessageBox.Show("El rollo ya ha sido anulado! ", "Anulado!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End If
        End If
    End Sub

    Private Sub cboCliente_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCliente.SelectedIndexChanged
        Dim value As Object = cboCliente.SelectedValue
        If (TypeOf value Is DataRowView) Then Return
        Dim id As Integer = CInt(value)
        If id = 1 Then
            txtProdFinal.Text = "33"
        Else
            txtProdFinal.Text = "22"
        End If

    End Sub

    Private Sub btn_act_mensaje_Click(sender As Object, e As EventArgs) Handles btn_act_mensaje.Click
        Dim sql As String = "UPDATE J_galvanizado_mensaje SET mensaje = '" & txt_mensaje.Text & "'"
        If objOpsimpesLn.ejecutar(sql, "PRODUCCION") > 0 Then
            MessageBox.Show("Mensaje modificado en forma correcta ", "Correcto!", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Error del sistema, comunicarse con el adminstrador", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        cargar_mensaje()
    End Sub
    Private Sub cargar_mensaje()
        Dim sql As String = "SELECT mensaje FROM J_galvanizado_mensaje"
        txt_mensaje.Text = objOpsimpesLn.consultValorTodo(sql, "PRODUCCION")
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

    Private Sub CboOperariosG_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles cboOperariosG.SelectedIndexChanged
        cargarPlanOperario()
        cargarRollos()
    End Sub
    'Se desencadena al dar clic en el boton guardar
    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If (validarEncabezado()) Then
            Dim listaSql As New List(Of Object)
            Dim resp As Boolean = False
            Dim frm As New Frm_salida_materia_prima_G
            listaSql.AddRange(guardarConsol)
            resp = obj_Ing_prodLn.ExecuteSqlTransaction(listaSql, "PRODUCCION")
            If (resp) Then
                Dim solicitante As String = "890900160"
                Dim observaciones As String = "Pedido automatico para galvanizado desde el spic"
                Dim devolver As String = "N"
                frm.guardar_automatico(cboOrigen.Text, txtCantProg.Text, cbo_fec_orden.Value.Month, cbo_fec_orden.Value.Year, solicitante, observaciones, devolver)
                MessageBox.Show("La orden fue guardada de forma exitosa! ", "Correcto!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                actualizarConsecutivoPpal(0)
                nuevo()
            Else
                MessageBox.Show("Error al ingresar El encabezado a la base de datos,verifique que todos los datos esten correctos ò comuniquese con el administrador del sistema!,NO SE GUARDO LA PLANILLA! ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub
    'Ordenes de operario
    Private Sub BtnActOrdenes_Click(sender As Object, e As EventArgs) Handles btnActOrdenes.Click
        If cboOperariosG.Text <> "Seleccione" Then
            cargarPlanOperario()
            cargarRollos()
        Else
            MessageBox.Show("No se ha seleccionado un operario'! ", "Seleccione!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
    Private Sub IngresarParos_Click(sender As Object, e As EventArgs) Handles IngresarParos.Click
        Dim frm As New frm_paros_galv
        frm.Show()
    End Sub
    Private Sub IngresarMantenimientoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IngresarMantenimientoToolStripMenuItem.Click
        Dim frm As New Frm_Mantenimiento_Planta
        frm.Show()
    End Sub
End Class