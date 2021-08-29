Imports logicaNegocios
Imports entidadNegocios
Public Class Frm_seg_pendientes
    Private objOperacionesForm As OperacionesFormularios = New OperacionesFormularios
    Private objOpSimplesLn As New Op_simpesLn
    Dim nit As String = ""
    Dim carga_comp As Boolean = False
    Dim pais As String
    Dim ciudad As String
    Dim departamento As String
    Dim dtg_select As String
    Dim fila_select As Integer
    Private objUsuarioLn As New UsuarioLn
    Dim usuario As UsuarioEn
    Dim dt_consulta As New DataTable
    Dim dt_consulta_sin_ruta As New DataTable
    Public Sub Main(ByVal objUsuario As UsuarioEn)
        Me.usuario = objUsuario
        Dim permiso As String = objUsuario.permiso.Trim
        If Not (permiso = "SAC" Or permiso = "ADMIN" Or permiso = "FACILITADOR") Then
            dtg_consulta.Columns(col_guardar_con_ruta.Name).Visible = False
            dtgSinRuta.Columns(col_guardar_sin_ruta.Name).Visible = False
        End If
    End Sub
    Private Sub Frm_seg_pendientes_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim sql As String = "SELECT  id, clasificacion FROM J_seg_pend_clasificaciones"
        dtg_asignar_clas.DataSource = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        cargar_cbo()
        cboCal.MaxDate = Now.AddYears(+1).Date
        cboCal.MinDate = Now.AddDays(-1)
        carga_comp = True
    End Sub

    Private Sub cargar_consulta()
        imgProc.Visible = True
        dt_consulta = New DataTable
        dt_consulta_sin_ruta = New DataTable
        Application.DoEvents()
        Dim sql As String = ""
        Dim criterio_vend As String = ""
        Dim vendedores As String = objUsuarioLn.coordinadorVend(usuario.usuario)
        If (vendedores = "") Then
            criterio_vend = "p.vendedor >=1001 and p.vendedor <= 1099 "
        Else
            criterio_vend = "p.vendedor in (" & vendedores & ") "
        End If
        Dim selectSql As String = "SELECT      p.vendedor AS vend, p.numero,p.ciudad, p.codigo, p.descripcion, p.nombres, p.Cant_pedida, p.cantidad_despachada, p.Pendiente,p.fecha,p.nit, " & _
                                                  "p.valor_unitario, p.Valor_total,p.notas, p.nota_vta, p.notas5, p.fec_compromiso,z.descripcion AS ruta,p.adicional As Observaciones " & _
                                "FROM dbo.V_pendientes_por_vendedor AS p INNER JOIN " & _
                                                      "dbo.y_ciudades AS c ON p.y_ciudad = c.ciudad AND p.y_dpto = c.departamento AND p.y_pais = c.pais INNER JOIN " & _
                                                      "dbo.J_zona_ciudad AS z ON c.zona = z.codigo "

        Dim whereSql As String = "WHERE "
        Dim orderSql As String = "ORDER BY p.vendedor "
        If (cbo_ruta.Text.Trim <> "Seleccione" And cbo_ruta.Text.Trim <> "TODO") Then
            whereSql &= "c.zona =" & cbo_ruta.SelectedValue & " AND "
        ElseIf (txt_vend_max.Text <> "" And txt_vend_min.Text <> "") Then
            whereSql &= "p.vendedor >=" & txt_vend_min.Text.Trim & " AND p.vendedor <=" & txt_vend_max.Text.Trim & " AND "
        ElseIf (txtNumero.Text <> "") Then
            whereSql &= "p.numero like '" & txtNumero.Text & "%' AND "
        ElseIf (nit <> "") Then
            whereSql &= "p.nit = " & nit & " AND "
        Else
            whereSql = "AND "
        End If
        If (txt_codigo.Text <> "") Then
            whereSql &= "p.codigo  like '" & txt_codigo.Text.Trim & "%' AND "
        End If
        whereSql &= criterio_vend
        sql = selectSql & whereSql & orderSql

        dt_consulta = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        dt_consulta.Columns.Add("id_clasificaciones")
        dt_consulta.Columns.Add("desc_clasificaciones")

        sql = "SELECT p.vendedor as vend,p.numero,p.fecha,p.ciudad,p.nit,p.nombres,p.codigo,p.descripcion," & _
                    "p.Cant_pedida, p.cantidad_despachada, p.valor_unitario, p.Pendiente,  p.Valor_total, p.autorizacion," & _
                    "p.autoriz_texto, p.nota_vta, p.notas_aut, p.notas5 , p.fec_compromiso,p.adicional As Observaciones " & _
            "FROM V_pendientes_por_vendedor p  ,y_ciudades c ,y_departamentos d , y_paises y " & _
            "WHERE p.y_ciudad = c.ciudad And p.y_dpto = c.departamento And p.y_pais = c.pais And c.zona Is null " & _
                            "AND c.pais = y.pais AND c.departamento = d.departamento AND " & criterio_vend
    
        dt_consulta_sin_ruta = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        dt_consulta_sin_ruta.Columns.Add("id_clasificaciones")
        dt_consulta_sin_ruta.Columns.Add("desc_clasificaciones_sin")

        cargar_clasificacion(criterio_vend)


        dtg_consulta.DataSource = dt_consulta
        dtgSinRuta.DataSource = dt_consulta_sin_ruta
        dtg_consulta.Columns("fecha").DefaultCellStyle.Format = "d"
        dtgSinRuta.Columns("fecha").DefaultCellStyle.Format = "d"
        tab_pen_sin_ruta.Text = "Pendientes sin ruta (" & dtgSinRuta.RowCount & " 'items')"
        If (dtgSinRuta.RowCount > 0) Then
            txt_estado_sin_ruta.BackColor = Color.Red
        Else
            txt_estado_sin_ruta.BackColor = Color.Green
        End If
        tab1.SelectedTab = tab_pen_con_ruta

        dtg_consulta.Columns("id_clasificaciones").Visible = False
        dtgSinRuta.Columns("id_clasificaciones").Visible = False
        dtg_consulta.Columns("Observaciones").ReadOnly = False
        dtgSinRuta.Columns("Observaciones").ReadOnly = False
        dtg_consulta.Columns("desc_clasificaciones").HeaderCell.Style.BackColor = Color.Green
        dtgSinRuta.Columns("desc_clasificaciones_sin").HeaderCell.Style.BackColor = Color.Green

        For i = 0 To 5
            dtgSinRuta.Columns(i).Frozen = True
            dtg_consulta.Columns(i).Frozen = True
        Next
        For i = 0 To dtg_consulta.Rows.Count - 1
            If Not IsDBNull(dtg_consulta.Item("fec_compromiso", i).Value) Then
                If (dtg_consulta.Item("fec_compromiso", i).Value = Now.Date) Then
                    dtg_consulta.Rows(i).DefaultCellStyle.BackColor = Color.Red
                End If
            End If
        Next
        For i = 0 To dtgSinRuta.Rows.Count - 1
            If Not IsDBNull(dtgSinRuta.Item("fec_compromiso", i).Value) Then
                If (dtgSinRuta.Item("fec_compromiso", i).Value = Now.Date) Then
                    dtgSinRuta.Rows(i).DefaultCellStyle.BackColor = Color.Red
                End If
            End If
         
        Next
        dtg_consulta.Columns("fec_compromiso").DefaultCellStyle.Format = "d"
        dtgSinRuta.Columns("fec_compromiso").DefaultCellStyle.Format = "d"
        imgProc.Visible = False
    End Sub
    Private Sub cargar_clasificacion(ByVal criterio_vend As String)
        Dim sql As String = "SELECT d.codigo ,p.numero,p.adicional,c.clasificacion As desc_clasificacion,c.id As id_clas  " & _
                                 "FROM J_seg_pend_clasificaciones c, J_seg_pend_item_clasificacion_det d,documentos_lin_ped p  " & _
                                  "WHERE c.id = d.clasificacion AND p.numero = d.numero AND p.codigo = d.codigo  "
        Dim dt As DataTable = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        If dt.Rows.Count > 0 Then
            For i = 0 To dt_consulta.Rows.Count - 1
                For j = 0 To dt.Rows.Count - 1
                    If (dt.Rows(j).Item("numero") = dt_consulta.Rows(i).Item("numero")) Then
                        If (dt.Rows(j).Item("codigo") = dt_consulta.Rows(i).Item("codigo")) Then
                            dt_consulta.Rows(i).Item("desc_clasificaciones") &= "-" & dt.Rows(j).Item("desc_clasificacion")
                            dt_consulta.Rows(i).Item("id_clasificaciones") &= "-" & dt.Rows(j).Item("id_clas")
                        End If
                    End If
                Next
            Next
        End If
        If dt.Rows.Count > 0 Then
            For i = 0 To dt_consulta_sin_ruta.Rows.Count - 1
                For j = 0 To dt.Rows.Count - 1
                    If (dt.Rows(j).Item("numero") = dt_consulta_sin_ruta.Rows(i).Item("numero")) Then
                        If (dt.Rows(j).Item("codigo") = dt_consulta_sin_ruta.Rows(i).Item("codigo")) Then
                            dt_consulta_sin_ruta.Rows(i).Item("desc_clasificaciones_sin") &= "-" & dt.Rows(j).Item("desc_clasificacion")
                            dt_consulta_sin_ruta.Rows(i).Item("id_clasificaciones") &= "-" & dt.Rows(j).Item("id_clas")
                        End If
                    End If
                Next
            Next
        End If

    End Sub
    Private Sub btn_exportar_Click(sender As System.Object, e As System.EventArgs) Handles btn_exportar.Click
        objOperacionesForm.ExportarDatosExcel(dtg_consulta, "Pendientes por zona")
    End Sub

    Private Sub btn_ppal_Click(sender As System.Object, e As System.EventArgs) Handles btn_ppal.Click
        FrmPrincipal.Show()
        Me.Close()
        FrmPrincipal.Activate()
    End Sub

    Private Sub btn_salir_Click(sender As System.Object, e As System.EventArgs) Handles btn_salir.Click
        FrmLogin.Show()
        FrmPrincipal.Close()
        FrmLogin.Activate()
        Me.Close()
    End Sub
    Private Sub cargar_cbo()
        Dim sql As String
        Dim dt As New DataTable
        Dim dr As DataRow

        sql = "SELECT codigo,descripcion  FROM J_zona_ciudad ORDER BY descripcion"
        dt = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        dr = dt.NewRow
        dr("codigo") = 0
        dr("descripcion") = "TODO"
        dt.Rows.Add(dr)
        cbo_ruta.DataSource = dt
        cbo_ruta.ValueMember = "codigo"
        cbo_ruta.DisplayMember = "descripcion"
        cbo_ruta.Text = "Seleccione"

    End Sub

    Private Sub btnActualizar_Click(sender As System.Object, e As System.EventArgs) Handles btnActualizar.Click
        If (cbo_ruta.Text <> "Seleccione" Or txt_codigo.Text <> "" Or txt_codigo.Text <> "" Or (txt_vend_max.Text <> "" And txt_vend_min.Text <> "") Or txtNumero.Text <> "" Or nit <> "") Then
            cargar_consulta()
        Else
            MessageBox.Show("Seleccione al menos 1 item a consultar!", "Correcto!", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
    Private Sub cargar_clientes()
        Dim sql As String = "Select nit,nombres,ciudad FROM terceros "
        Dim whereSql As String = "WHERE (concepto_1 like '%3%' or concepto_1 like '%4%' or concepto_1 like '%9%') "
        If (txt_nit.Text <> "") Then
            whereSql &= " AND nit like '" & txt_nit.Text & "%'"
        ElseIf (txt_nombres.Text <> "") Then
            whereSql &= "AND nombres like '%" & txt_nombres.Text & "%'"
        End If
        sql &= whereSql
        dtg_clientes.DataSource = objOpSimplesLn.listar_datatable(sql, "CORSAN")
    End Sub
    Private Sub txt_nombres_TextChanged(sender As System.Object, e As System.EventArgs) Handles txt_nombres.TextChanged
        carga_comp = False
        txt_nit.Text = ""
        carga_comp = True
        If (carga_comp And txt_nombres.Text.Length > 3) Then
            cargar_clientes()
        End If
    End Sub

    Private Sub txt_nit_TextChanged(sender As System.Object, e As System.EventArgs) Handles txt_nit.TextChanged
        carga_comp = False
        txt_nombres.Text = ""
        carga_comp = True
        If (carga_comp And txt_nit.Text.Length > 2) Then
            cargar_clientes()
        End If
    End Sub

    Private Sub dtg_clientes_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtg_clientes.CellContentClick
        If (e.RowIndex >= 0) Then
            If (dtg_clientes.Columns(e.ColumnIndex).Name = colOk.Name) Then
                carga_comp = False
                cbo_ruta.Text = "Seleccione"
                txt_codigo.Text = ""
                txtNumero.Text = ""
                txt_vend_min.Text = ""
                txt_vend_max.Text = ""
                txt_cliente.Text = ""
                txt_cliente.Text = ""
                nit = ""
                nit = dtg_clientes.Item("nit", e.RowIndex).Value
                txt_cliente.Text = dtg_clientes.Item("nombres", e.RowIndex).Value
                groupCliente.Visible = False
                dtg_clientes.DataSource = Nothing
                txt_nit.Text = ""
                txt_nombres.Text = ""
                carga_comp = True
                cargar_consulta()
            End If
        End If
    End Sub

    Private Sub cbo_ruta_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbo_ruta.SelectedIndexChanged
        If (carga_comp) Then
            carga_comp = False
            txtNumero.Text = ""
            txt_vend_min.Text = ""
            txt_vend_max.Text = ""
            txt_cliente.Text = ""
            nit = ""
            carga_comp = True
        End If
    End Sub

    Private Sub txtNumero_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtNumero.TextChanged
        If (carga_comp) Then
            carga_comp = False
            cbo_ruta.Text = "Seleccione"
            txt_vend_min.Text = ""
            txt_vend_max.Text = ""
            txt_cliente.Text = ""
            txt_cliente.Text = ""
            nit = ""
            carga_comp = True
        End If
    End Sub

    Private Sub txt_vend_min_TextChanged(sender As System.Object, e As System.EventArgs) Handles txt_vend_min.TextChanged
        If (carga_comp) Then
            carga_comp = False
            cbo_ruta.Text = "Seleccione"
            txtNumero.Text = ""
            txt_cliente.Text = ""
            nit = ""
            txt_cliente.Text = ""
            carga_comp = True
        End If
    End Sub

    Private Sub txt_vend_max_TextChanged(sender As System.Object, e As System.EventArgs) Handles txt_vend_max.TextChanged
        If (carga_comp) Then
            carga_comp = False
            cbo_ruta.Text = "Seleccione"
            txtNumero.Text = ""
            txt_cliente.Text = ""
            nit = ""
            txt_cliente.Text = ""
            carga_comp = True
        End If
    End Sub

    Private Sub txt_vend_max_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txt_vend_max.KeyPress
        soloNumero(e)
    End Sub

    Private Sub txt_vend_min_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txt_vend_min.KeyPress
        soloNumero(e)
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

    Private Sub txt_nit_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txt_nit.KeyPress
        soloNumero(e)
    End Sub

    Private Sub txtNumero_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumero.KeyPress
        soloNumero(e)
    End Sub

    Private Sub Frm_pend_zona_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = 116 Then
            cargar_consulta()
        ElseIf (e.KeyCode = 13) Then
            If (groupCliente.Visible = True) Then
                If (dtg_clientes.RowCount >= 1) Then
                    carga_comp = False
                    cbo_ruta.Text = "Seleccione"
                    txt_codigo.Text = ""
                    txtNumero.Text = ""
                    txt_vend_min.Text = ""
                    txt_vend_max.Text = ""
                    txt_cliente.Text = ""
                    txt_cliente.Text = ""
                    nit = ""
                    nit = dtg_clientes.Item("nit", 0).Value
                    txt_cliente.Text = dtg_clientes.Item("nombres", 0).Value
                    groupCliente.Visible = False
                    dtg_clientes.DataSource = Nothing
                    txt_nit.Text = ""
                    txt_nombres.Text = ""
                    carga_comp = True
                    cargar_consulta()
                End If
            End If

        End If
    End Sub

    Private Sub txt_cliente_MouseClick(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles txt_cliente.MouseClick
        groupCliente.Visible = True
        txt_nombres.Focus()
    End Sub

    Private Sub btn_cerrar_Click(sender As System.Object, e As System.EventArgs) Handles btn_cerrar.Click
        carga_comp = False
        txt_nit.Text = ""
        txt_nombres.Text = ""
        dtg_clientes.DataSource = Nothing
        groupCliente.Visible = False
        carga_comp = True
    End Sub
    Private Sub dtgSinRuta_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dtgSinRuta.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            With (Me.dtgSinRuta)
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                End If
            End With
        End If
    End Sub


    Private Sub dtg_asignar_clas_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtg_asignar_clas.CellClick
        If e.RowIndex >= 0 Then
            Dim id As String = dtg_asignar_clas.Item("id", e.RowIndex).Value
            Dim desc As String = dtg_asignar_clas.Item("clasificacion", e.RowIndex).Value
            Dim clasificaciones As String = ""
            Dim existe As Boolean = False
            If (dtg_select = dtgSinRuta.Name) Then
                If Not IsDBNull(dtgSinRuta.Item("id_clasificaciones", fila_select).Value) Then
                    clasificaciones = dtgSinRuta.Item("id_clasificaciones", fila_select).Value
                    For i = 0 To clasificaciones.Length - 1
                        If (clasificaciones(i) <> "-") Then
                            If (clasificaciones(i) = id) Then
                                MessageBox.Show("Esta claficación ya existe!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                existe = True
                            End If
                        End If
                    Next
                End If
                If Not existe Then
                    dtgSinRuta.Item("id_clasificaciones", fila_select).Value &= "-" & id
                    dtgSinRuta.Item("desc_clasificaciones_sin", fila_select).Value &= "-" & desc

                    dtg_modif_clas.Item("col_id_mod_clas", dtg_modif_clas.Rows.Count - 1).Value = id
                    dtg_modif_clas.Item("col_desc_mod_clas", dtg_modif_clas.Rows.Count - 1).Value = desc
                End If
            ElseIf (dtg_select = dtg_consulta.Name) Then
                If Not IsDBNull(dtg_consulta.Item("id_clasificaciones", fila_select).Value) Then
                    clasificaciones = dtg_consulta.Item("id_clasificaciones", fila_select).Value
                    For i = 0 To clasificaciones.Length - 1
                        If (clasificaciones(i) <> "-") Then
                            If (clasificaciones(i) = id) Then
                                MessageBox.Show("Esta claficación ya existe!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                existe = True
                            End If
                        End If
                    Next
                End If
                If Not existe Then
                    dtg_consulta.Item("id_clasificaciones", fila_select).Value &= "-" & id
                    dtg_consulta.Item("desc_clasificaciones", fila_select).Value &= "-" & desc

                    dtg_modif_clas.Rows.Add()
                    dtg_modif_clas.Item("col_id_mod_clas", dtg_modif_clas.Rows.Count - 1).Value = id
                    dtg_modif_clas.Item("col_desc_mod_clas", dtg_modif_clas.Rows.Count - 1).Value = desc
                End If
            End If
        End If
    End Sub

    Private Sub dtg_consulta_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles dtg_consulta.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            With (Me.dtg_consulta)
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                End If
            End With
        End If
    End Sub

 
    Private Sub dtg_consulta_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtg_consulta.CellClick
        Dim col As String = dtg_consulta.Columns(e.ColumnIndex).Name
        If (e.RowIndex >= 0) Then
            Dim clasificaciones As String = ""
            If Not IsDBNull(dtg_consulta.Item("id_clasificaciones", e.RowIndex).Value) Then
                clasificaciones = dtg_consulta.Item("id_clasificaciones", e.RowIndex).Value
            End If
            If (col = col_guardar_con_ruta.Name) Then
                Dim numero As Integer = dtg_consulta.Item("numero", e.RowIndex).Value
                Dim codigo As String = dtg_consulta.Item("codigo", e.RowIndex).Value
                Dim notas As String = ""
                Dim nit As Double = dtg_consulta.Item("nit", e.RowIndex).Value
                Dim fec_compromiso As String = ""
                If Not IsDBNull(dtg_consulta.Item("fec_compromiso", e.RowIndex).Value) Then
                    fec_compromiso = objOpSimplesLn.cambiarFormatoFecha(dtg_consulta.Item("fec_compromiso", e.RowIndex).Value)
                End If
                If Not IsDBNull(dtg_consulta.Item("Observaciones", e.RowIndex).Value) Then
                    notas = dtg_consulta.Item("Observaciones", e.RowIndex).Value
                End If
                guardar(clasificaciones, numero, notas, codigo, nit, fec_compromiso)
               
            ElseIf (col = "desc_clasificaciones") Then
                For i = 0 To clasificaciones.Length - 1
                    If (clasificaciones(i) <> "-") Then
                        dtg_modif_clas.Rows.Add()
                        dtg_modif_clas.Item(col_id_mod_clas.Name, dtg_modif_clas.Rows.Count - 1).Value = clasificaciones(i)
                        dtg_modif_clas.Item(col_desc_mod_clas.Name, dtg_modif_clas.Rows.Count - 1).Value = objOpSimplesLn.consultarVal("SELECT  clasificacion FROM J_seg_pend_clasificaciones WHERE id =  " & clasificaciones(i))
                    End If
                Next

                dtg_select = dtg_consulta.Name
                fila_select = e.RowIndex
                group_clasificacion.Visible = True
            ElseIf (col = "fec_compromiso") Then
                dtg_select = dtg_consulta.Name
                fila_select = e.RowIndex
                cboCal.Visible = True
                btn_cerrar_cal.Visible = True
            End If
            limpiarColor()
            dtg_consulta.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.LightSkyBlue
        End If
    End Sub
    Private Sub limpiarColor()
        For i = 0 To dtg_consulta.Rows.Count - 1
            If (i Mod 2 = 0) Then
                dtg_consulta.Rows(i).DefaultCellStyle.BackColor = Color.Gainsboro
            Else
                dtg_consulta.Rows(i).DefaultCellStyle.BackColor = Color.White
            End If
        Next
        For i = 0 To dtgSinRuta.Rows.Count - 1
            If (i Mod 2 = 0) Then
                dtgSinRuta.Rows(i).DefaultCellStyle.BackColor = Color.Gainsboro
            Else
                dtgSinRuta.Rows(i).DefaultCellStyle.BackColor = Color.White
            End If
        Next
    End Sub
    Private Sub guardar(ByVal clasificaciones As String, ByVal numero As Integer, ByVal notas As String, ByVal codigo As String, ByVal nit As Double, ByVal fec_compromiso As String)
        Dim listSql As New List(Of Object)
        Dim sql As String = ""
        Dim dt As New DataTable
        Dim sql_consulta As String = ""
        Dim insert_compromiso As String = ""
        If (fec_compromiso <> "") Then
            insert_compromiso = ",fec_compromiso = '" & fec_compromiso & "'"
        End If
        sql = "DELETE FROM  J_seg_pend_item_clasificacion_det WHERE numero = " & numero & " AND codigo = '" & codigo & "' "
        listSql.Add(sql)
        sql = "DELETE FROM  J_seg_pend_item_clasificacion_det WHERE numero = " & numero & " AND (clasificacion in (3,5)) "
        listSql.Add(sql)
        sql = "DELETE FROM  J_seg_pend_item_clasificacion_det WHERE codigo = '" & codigo & "' AND (clasificacion in (1)) "
        listSql.Add(sql)
        sql = "UPDATE documentos_lin_ped SET adicional = '" & notas & "'" & insert_compromiso & " WHERE numero = " & numero & " AND codigo = '" & codigo & "' "
        listSql.Add(sql)
        If (objOpSimplesLn.ExecuteSqlTransaction(listSql)) Then
            listSql = New List(Of Object)
            For i = 0 To clasificaciones.Length - 1
                If (clasificaciones(i) <> "-") Then
                    If (clasificaciones(i) = "3" Or clasificaciones(i) = "5") Then
                        dt = New DataTable
                        sql_consulta = "SELECT numero,codigo FROM V_pendientes_por_vendedor WHERE nit = " & nit & " AND numero not in (SELECT numero FROM J_seg_pend_item_clasificacion_det WHERE  clasificacion  = " & clasificaciones(i) & " )"
                        dt = objOpSimplesLn.listar_datatable(sql_consulta, "CORSAN")
                        For j = 0 To dt.Rows.Count - 1
                            sql = "INSERT INTO J_seg_pend_item_clasificacion_det (numero,codigo,clasificacion) VALUES (" & dt.Rows(j).Item("numero") & ",'" & dt.Rows(j).Item("codigo") & "'," & clasificaciones(i) & ") "
                            listSql.Add(sql)
                        Next
                    ElseIf (clasificaciones(i) = "1") Then
                        dt = New DataTable
                        sql_consulta = "SELECT numero,codigo FROM V_pendientes_por_vendedor WHERE codigo = '" & codigo & "' AND numero not in (SELECT numero FROM J_seg_pend_item_clasificacion_det WHERE  clasificacion  = " & clasificaciones(i) & " AND codigo = '" & codigo & "' )"
                        dt = objOpSimplesLn.listar_datatable(sql_consulta, "CORSAN")
                        For j = 0 To dt.Rows.Count - 1
                            sql = "INSERT INTO J_seg_pend_item_clasificacion_det (numero,codigo,clasificacion) VALUES (" & dt.Rows(j).Item("numero") & ",'" & dt.Rows(j).Item("codigo") & "'," & clasificaciones(i) & ") "
                            listSql.Add(sql)
                        Next
                    Else

                        sql = "INSERT INTO J_seg_pend_item_clasificacion_det (numero,codigo,clasificacion) VALUES (" & numero & ",'" & codigo & "'," & clasificaciones(i) & ") "
                        listSql.Add(sql)
                    End If
                End If
            Next
        Else
            MessageBox.Show("Error al actualizar(borrar) el registro, comuniquese con el area de sistemas", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        If (objOpSimplesLn.ExecuteSqlTransaction(listSql)) Then
            MessageBox.Show("El registro se actualizo en forma correcta", "Correcto!", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Error al actualizar el registro, comuniquese con el area de sistemas", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Private Sub dtgSinRuta_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgSinRuta.CellClick
        Dim col As String = dtgSinRuta.Columns(e.ColumnIndex).Name
        If (e.RowIndex >= 0) Then
            Dim clasificaciones As String = ""
            If Not IsDBNull(dtgSinRuta.Item("id_clasificaciones", e.RowIndex).Value) Then
                clasificaciones = dtgSinRuta.Item("id_clasificaciones", e.RowIndex).Value
            End If
            If (col = col_guardar_sin_ruta.Name) Then
                Dim numero As Integer = dtgSinRuta.Item("numero", e.RowIndex).Value
                Dim listSql As New List(Of Object)
                Dim sql As String = ""
                Dim notas As String = ""
                Dim codigo As String = dtgSinRuta.Item("codigo", e.RowIndex).Value
                Dim nit As Double = dtgSinRuta.Item("nit", e.RowIndex).Value
                Dim fec_compromiso As String = ""
                If Not IsDBNull(dtgSinRuta.Item("fec_compromiso", e.RowIndex).Value) Then
                    fec_compromiso = objOpSimplesLn.cambiarFormatoFecha(dtgSinRuta.Item("fec_compromiso", e.RowIndex).Value)
                End If
                If Not IsDBNull(dtgSinRuta.Item("Observaciones", e.RowIndex).Value) Then
                    notas = dtgSinRuta.Item("Observaciones", e.RowIndex).Value
                End If
                guardar(clasificaciones, numero, notas, codigo, nit, fec_compromiso)
            ElseIf (col = "desc_clasificaciones_sin") Then
                For i = 0 To clasificaciones.Length - 1
                    If (clasificaciones(i) <> "-") Then
                        dtg_modif_clas.Rows.Add()
                        dtg_modif_clas.Item(col_id_mod_clas.Name, dtg_modif_clas.Rows.Count - 1).Value = clasificaciones(i)
                        dtg_modif_clas.Item(col_desc_mod_clas.Name, dtg_modif_clas.Rows.Count - 1).Value = objOpSimplesLn.consultarVal("SELECT  clasificacion FROM J_seg_pend_clasificaciones WHERE id =  " & clasificaciones(i))
                    End If
                Next
                dtg_select = dtgSinRuta.Name
                fila_select = e.RowIndex
                group_clasificacion.Visible = True
            ElseIf (col = "fec_compromiso") Then
                dtg_select = dtgSinRuta.Name
                fila_select = e.RowIndex
                cboCal.Visible = True
                btn_cerrar_cal.Visible = True
            End If
            limpiarColor()
            dtgSinRuta.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.LightSkyBlue
        End If
    End Sub

    Private Sub btn_cerrar_clas_Click(sender As System.Object, e As System.EventArgs) Handles btn_cerrar_clas.Click
        dtg_modif_clas.Rows.Clear()
        group_clasificacion.Visible = False
        group_clasificacion.Visible = False
        dtg_select = ""
        fila_select = 0
    End Sub

    Private Sub dtg_modif_clas_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtg_modif_clas.CellClick
        If (e.RowIndex >= 0) Then
            Dim col As String = dtg_modif_clas.Columns(e.ColumnIndex).Name
            If (col = col_borrar_clas.Name) Then
                dtg_modif_clas.Rows.RemoveAt(e.RowIndex)
                Dim id As String = ""
                Dim desc As String = ""
                If (dtg_select = dtgSinRuta.Name) Then
                    dtgSinRuta.Item("id_clasificaciones", fila_select).Value = ""
                    dtgSinRuta.Item("desc_clasificaciones_sin", fila_select).Value = ""
                ElseIf (dtg_select = dtg_consulta.Name) Then
                    dtg_consulta.Item("id_clasificaciones", fila_select).Value = ""
                    dtg_consulta.Item("desc_clasificaciones", fila_select).Value = ""
                End If
                For i = 0 To dtg_modif_clas.RowCount - 1
                    id = dtg_modif_clas.Item(col_id_mod_clas.Name, i).Value
                    desc = dtg_modif_clas.Item(col_desc_mod_clas.Name, i).Value
                    If (dtg_select = dtgSinRuta.Name) Then
                        dtgSinRuta.Item("id_clasificaciones", fila_select).Value &= "-" & id
                        dtgSinRuta.Item("desc_clasificaciones_sin", fila_select).Value &= "-" & desc
                    ElseIf (dtg_select = dtg_consulta.Name) Then
                        dtg_consulta.Item("id_clasificaciones", fila_select).Value &= "-" & id
                        dtg_consulta.Item("desc_clasificaciones", fila_select).Value &= "-" & desc
                    End If
                Next
            End If
        End If
    End Sub
    Private Sub cboCal_DateSelected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DateRangeEventArgs) Handles cboCal.DateSelected
        If (dtg_select = dtgSinRuta.Name) Then
            dtgSinRuta.Item("fec_compromiso", fila_select).Value = cboCal.SelectionEnd.Date
        ElseIf (dtg_select = dtg_consulta.Name) Then
            dtg_consulta.Item("fec_compromiso", fila_select).Value = cboCal.SelectionEnd.Date
        End If
        cboCal.Visible = False
        btn_cerrar_cal.Visible = False
    End Sub

    Private Sub btn_cerrar_cal_Click(sender As System.Object, e As System.EventArgs) Handles btn_cerrar_cal.Click
        cboCal.Visible = False
        btn_cerrar_cal.Visible = False
    End Sub

    Private Sub VerStockToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles VerStockToolStripMenuItem.Click
        Dim codigo As String = dtg_consulta.Item("codigo", dtg_consulta.CurrentCell.RowIndex).Value
        MessageBox.Show("Bod3:" & objOpSimplesLn.consultarStock(codigo, 3) & vbCrLf & "Bod7:" & objOpSimplesLn.consultarStock(codigo, 7) & vbCrLf & "Pend bod3= " & objOpSimplesLn.consultarCantPend(codigo, 3) & vbCrLf & "Pend bod7= " & objOpSimplesLn.consultarCantPend(codigo, 7), "Stock", MessageBoxButtons.OK)
    End Sub
    Private Sub itemMasInfo_Opening(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles itemMasInfo.Click
        Dim nit As Integer
        nit = dtg_consulta("nit", dtg_consulta.CurrentCell.RowIndex).Value
        frmPendientes.Show()
        frmPendientes.cargarInfoClient(nit)
        frmPendientes.Activate()
    End Sub
    Private Sub dtgPenBuenos_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dtg_consulta.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            With (Me.dtg_consulta)
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                End If
            End With
        End If
    End Sub

    Private Sub itemMail_Click(sender As System.Object, e As System.EventArgs)
        Dim nit As Integer = 0
        Dim nombre As String
        nit = dtg_consulta("nit", dtg_consulta.CurrentCell.RowIndex).Value
        nombre = dtg_consulta("nombres", dtg_consulta.CurrentCell.RowIndex).Value
        FrmDatosMail.Show()
        frmPendientes.Show()
        frmPendientes.cargarInfoClient(nit)
        Application.DoEvents()
        FrmDatosMail.capturarPantalla()
        frmPendientes.Close()
        FrmDatosMail.iniciarValores(Environment.CurrentDirectory & "\informacion.jpg", usuario, nombre)
        FrmDatosMail.Activate()
    End Sub
End Class