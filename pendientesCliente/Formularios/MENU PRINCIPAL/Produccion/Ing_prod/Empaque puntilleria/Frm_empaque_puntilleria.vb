Imports System.Configuration
Imports logicaNegocios
Imports entidadNegocios
Imports System.IO
Imports Microsoft.Office.Interop
#Disable Warning BC40056 ' El espacio de nombres o el tipo especificado en el 'System.Data.SqlServerCe' Imports no contienen ningún miembro público o no se encuentran. Asegúrese de que el espacio de nombres o el tipo se hayan definido y de que contengan al menos un miembro público. Asegúrese de que el nombre del elemento importado no use ningún alias.
Imports System.Data.SqlServerCe
#Enable Warning BC40056 ' El espacio de nombres o el tipo especificado en el 'System.Data.SqlServerCe' Imports no contienen ningún miembro público o no se encuentran. Asegúrese de que el espacio de nombres o el tipo se hayan definido y de que contengan al menos un miembro público. Asegúrese de que el nombre del elemento importado no use ningún alias.
Public Class Frm_empaque_puntilleria
    Private obj_Ing_prodLn As New Ing_prodLn
    Private objTraslado_bodLn As New traslado_bodLn
    Private obj_Op_simpesLn As New Op_simpesLn
    Private carga_comp As Boolean = False
    Private h_prog As Double = 0
    Private operario As Double = 0
    Private nom_modulo As String
    Private objOrdenProdLn As New OrdenProdLn
    Private objUsurioEn As New UsuarioEn
    Dim filaSelect As Integer = 0
    Dim colSelect As Integer = 0
    Dim numero_transaccion As Double
    Public Sub Main(ByVal nom_modulo As String, ByVal usuario As UsuarioEn)
        Me.objUsurioEn = usuario
        Me.nom_modulo = nom_modulo
        If (usuario.permiso <> "ADMIN") Then
            btnContCambios.Visible = False
        End If
    End Sub
    Private Sub btnContCambios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnContCambios.Click
        FrmAuditCambios.Show()
        FrmAuditCambios.Main(nom_modulo)
        FrmAuditCambios.WindowState = 2
    End Sub
    Private Sub Frm_empaque_puntilleria_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim sql As String = "select Codigo,Descripcion from J_turnos  "
        Dim col As New DataColumn
        Dim dt As New DataTable

        cbo_fecha.Value = Now.AddDays(-1)
        cbo_turno.DataSource = obj_Ing_prodLn.listar_datatable(sql, "PRODUCCION")
        cbo_turno.ValueMember = "Codigo"
        cbo_turno.DisplayMember = "Descripcion"
        cbo_turno.Text = "Seleccione"

        cargar_operarios()
        For i = 0 To 6
            dtg_planilla.Rows.Add()
        Next
        carga_comp = True
    End Sub
    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If (cbo_operario.SelectedValue <> 0 And cbo_turno.Text <> "Seleccione") Then
            guardar()
            ' limpiar()
        Else
            MessageBox.Show("Seleccione todos los campos requeridos! ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Private Sub limpiar()
        cbo_operario.Text = "Seleccione"
        cbo_turno.Text = "Seleccione"
        dtg_planilla.Rows.Clear()
        For i = 0 To 6
            dtg_planilla.Rows.Add()
        Next
    End Sub
   
    Private Sub guardar()
        dtg_planilla.CurrentCell = Nothing
        Dim fec_hora_ini As String = ""
        Dim fec_hora_fin As String = ""
        Dim nit As Double = cbo_operario.SelectedValue
        Dim listSql As New List(Of Object)
        Dim dt_codigos_valores As New DataTable
        dt_codigos_valores.Columns.Add("codigo")
        dt_codigos_valores.Columns.Add("cantidad")
        Dim codigo As String = ""
        Dim resp_transaccion As Boolean = False
        Dim resp_efic As Boolean = False
        Dim fecha As String = obj_Op_simpesLn.cambiarFormatoFecha(cbo_fecha.Value.Date)
        Dim turno As Integer = cbo_turno.SelectedValue
        Dim h_trab As Double = 0
        Dim cant As Double = 0
        Dim granel As Integer = 0
        Dim id_empaque As Integer = obj_Ing_prodLn.consultar_valor("SELECT (SELECT CASE WHEN MAX (id_empaque) is null THEN 1 ELSE (MAX (id_empaque)+1) END )As id_empaque FROM J_ing_emp_punt_enc ", "PRODUCCION")
        Dim sql_enc As String = ""
        Dim sql_det As String = ""
        Dim sql_gral_det As String = ""
        sql_gral_det = "INSERT INTO J_ing_emp_punt_det (id_empaque, id_detalle, codigo,cartones,granel,hora_ini,hora_fin) " & _
                                                  "VALUES( " & id_empaque & ""
        If (verificar_planilla(dtg_planilla)) Then
            For i = 0 To dtg_planilla.RowCount - 1
                codigo = dtg_planilla.Item(colCodigo.Name, i).Value
                cant = dtg_planilla.Item(txt_cant_cartones.Name, i).Value
                If (codigo <> "" And cant <> 0) Then
                    dt_codigos_valores.Rows.Add()
                    dt_codigos_valores.Rows(dt_codigos_valores.Rows.Count - 1).Item("codigo") = codigo
                    dt_codigos_valores.Rows(dt_codigos_valores.Rows.Count - 1).Item("cantidad") = cant
                End If
            Next
            'se toman los script que hacen la transacción
            resp_transaccion = obj_Ing_prodLn.ExecuteSqlTransaction(ingProdDms(dt_codigos_valores), "CORSAN")
            sql_enc = "INSERT INTO J_ing_emp_punt_enc (id_empaque, nit, fecha, fecha_transaccion,num_transaccion,turno) " & _
                                                     "VALUES( " & id_empaque & ", " & nit & ",'" & fecha & "',GETDATE(), " & numero_transaccion & ", " & turno & ")"
            listSql.Add(sql_enc)
            For i = 0 To dtg_planilla.RowCount - 1
                codigo = dtg_planilla.Item(colCodigo.Name, i).Value
                granel = dtg_planilla.Item(col_chk_granel.Name, i).Value
                cant = dtg_planilla.Item(txt_cant_cartones.Name, i).Value
                fec_hora_ini = dtg_planilla.Item(txt_hora_ini.Name, i).Value
                fec_hora_fin = dtg_planilla.Item(txt_hora_fin.Name, i).Value
                If (codigo <> "" And cant <> 0 And fec_hora_ini <> "" And fec_hora_fin <> "") Then
                    dt_codigos_valores.Rows.Add()
                    dt_codigos_valores.Rows(dt_codigos_valores.Rows.Count - 1).Item("codigo") = codigo
                    dt_codigos_valores.Rows(dt_codigos_valores.Rows.Count - 1).Item("cantidad") = cant
                    sql_det = sql_gral_det & "," & i & ",'" & codigo & "'," & cant & "," & granel & ",'" & fec_hora_ini & "','" & fec_hora_fin & "')"
                    listSql.Add(sql_det)
                    dtg_planilla.Rows(i).DefaultCellStyle.BackColor = Color.Green
                End If
            Next
            resp_efic = obj_Ing_prodLn.ExecuteSqlTransaction(listSql, "PRODUCCION")
            If (resp_transaccion) Then
                MessageBox.Show("Transacción realizada en forma exitosa,número : " & numero_transaccion & " tipo = EDEP ", "Correcto!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                If (resp_efic) Then
                    MessageBox.Show("Eficiencia ingresada en forma exitosa", "Correcto!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    limpiar()
                Else
                    MessageBox.Show("Error al ingresar la eficiencia,verifique que todos los datos esten correctos ò comuniquese con el administrador del sistema! ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

            Else
                MessageBox.Show("Error al realizar la transacción,verifique que todos los datos esten correctos ò comuniquese con el administrador del sistema! ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            MessageBox.Show("Verifique que los datos de todos los registros de empaque sean correctos! ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub
    Public Function verificar_planilla(ByVal dtg As DataGridView) As Boolean
        Dim resp As Boolean = True
        Dim cant As Double = 0
        Dim codigo As String = ""
        Dim hora_ini As String = ""
        Dim hora_fin As String = ""
        For i = 0 To dtg_planilla.RowCount - 1
            codigo = dtg_planilla(colCodigo.Name, i).Value
            cant = dtg_planilla(txt_cant_cartones.Name, i).Value
            hora_ini = dtg_planilla.Item(txt_hora_ini.Name, i).Value
            hora_fin = dtg_planilla.Item(txt_hora_fin.Name, i).Value
            If (codigo <> "" Or cant <> 0 Or hora_ini <> "" Or hora_fin <> "") Then
                If (cant <> 0 And codigo <> "" And hora_ini <> "" And hora_fin <> "") Then
                    If IsDate(hora_ini) Then
                        If IsDate(hora_fin) Then
                            If (codigo <> "") Then
                                If Not (obj_Op_simpesLn.validarCodigo(codigo)) Then
                                    MessageBox.Show("Codigo de producto incorrecto en la fila # " & i + 1 & " ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    resp = False
                                    i = dtg_planilla.RowCount - 1
                                End If
                            Else
                                MessageBox.Show("Se debe ingresar un código de producto ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                resp = False
                                i = dtg_planilla.RowCount - 1
                            End If
                        Else
                            resp = False
                            i = dtg_planilla.RowCount - 1
                        End If
                    Else
                        resp = False
                        i = dtg_planilla.RowCount - 1
                    End If
                Else
                    resp = False
                    i = dtg_planilla.RowCount - 1
                End If
            End If
        Next
        If dtg_planilla.RowCount = 0 Then
            resp = False
        End If
        Return resp
    End Function

    Private Sub cbo_turno_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_turno.SelectedIndexChanged
        If (carga_comp) Then
            If (cbo_turno.Text <> "Seleccione") Then
                Dim horas As String = obj_Ing_prodLn.consultar_valor("SELECT Horas FROM J_turnos WHERE Codigo = " & cbo_turno.SelectedValue, "PRODUCCION")
                h_prog = Convert.ToInt16(horas)
            End If
        End If
    End Sub

    Private Sub cbo_operario_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_operario.SelectedIndexChanged
        If (cbo_operario.Text <> "Seleccione" And cbo_operario.Text <> "System.Data.DataRowView" And (cbo_operario.SelectedValue).ToString <> "System.Data.DataRowView") Then
            operario = cbo_operario.SelectedValue
        End If
    End Sub
    Public Sub limpiar_fila(ByVal fila As Integer, ByVal dtg As DataGridView)
        For i = 0 To dtg.ColumnCount - 1
            dtg(i, fila).Value = ""
        Next
    End Sub
    Private Sub btnNuevo_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        limpiar()
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

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Frm_consultar_empaque_punt.Show()
    End Sub
    Private Sub cacular_efic(ByVal prod As Integer, ByVal esp As Double, ByVal fila As Integer)
        dtg_planilla.Item("txt_porc", fila).Value = (prod / esp) * 100
    End Sub

    Private Sub chk_todos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_todos.CheckedChanged
        cargar_operarios()
    End Sub
    Private Sub cargar_operarios()
        Dim sql As String = ""
        If (chk_todos.Checked = True) Then
            sql = "Select nit,nombres   from V_nom_personal_Activo_con_maquila WHERE centro not in (4200) ORDER BY nombres "
        Else
            sql = "Select nit,nombres  from V_nom_personal_Activo_con_maquila WHERE centro = 2400 ORDER BY nombres"
        End If
        Dim dt As DataTable = obj_Ing_prodLn.listar_datatable(sql, "CORSAN")
        dt.Rows.Add()
        dt.Rows(dt.Rows.Count - 1).Item("nit") = 900029909
        dt.Rows(dt.Rows.Count - 1).Item("nombres") = "EMPAQUES Y CONTENIDOS S.A"
        dt.Rows.Add()
        dt.Rows(dt.Rows.Count - 1).Item("nit") = 811001365
        dt.Rows(dt.Rows.Count - 1).Item("nombres") = "COLPACK  S.A.S"
        dt.Rows.Add()
        dt.Rows(dt.Rows.Count - 1).Item("nit") = 900338739
        dt.Rows(dt.Rows.Count - 1).Item("nombres") = "DECORMAQUILAS S.A.S"
        dt.Rows.Add()
        dt.Rows(dt.Rows.Count - 1).Item("nit") = 890900160
        dt.Rows(dt.Rows.Count - 1).Item("nombres") = "INDUSTRIAS METALICAS CORSAN S.A."
        dt.Rows.Add()
        dt.Rows(dt.Rows.Count - 1).Item("nit") = 900505976
        dt.Rows(dt.Rows.Count - 1).Item("nombres") = "APL SERVICIOS"
        dt.Rows.Add()
        dt.Rows(dt.Rows.Count - 1).Item("nit") = 32512279
        dt.Rows(dt.Rows.Count - 1).Item("nombres") = "ACCESORIOS Y PRODUCTOS A Y P"
        dt.Rows.Add()
        dt.Rows(dt.Rows.Count - 1).Item("nit") = 0
        dt.Rows(dt.Rows.Count - 1).Item("nombres") = "Seleccione"
        cbo_operario.DataSource = dt
        cbo_operario.ValueMember = "nit"
        cbo_operario.DisplayMember = "nombres"
        cbo_operario.SelectedValue = 0
    End Sub
    Private Sub dtg_planillaCellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtg_planilla.CellClick
        Dim fila As Integer = e.RowIndex
        Dim col As String = dtg_planilla.Columns(e.ColumnIndex).Name
        If (col = "btn_borrar") Then
            dtg_planilla.Rows.RemoveAt(e.RowIndex)
        ElseIf (col = colCodigo.Name Or col = colDescCodigo.Name) Then
            txtDesc.Text = ""
            txtCodigo.Text = ""
            groupCodigo.Visible = True
            txtCodigo.Focus()
            filaSelect = e.RowIndex
        ElseIf (col = col_add.Name) Then
            carga_comp = False
            dtg_planilla.Rows.Add()
            carga_comp = True
        ElseIf (col = txt_hora_ini.Name Or col = txt_hora_fin.Name) Then
            filaSelect = e.RowIndex
            colSelect = e.ColumnIndex
            groupFecha.Visible = True
        End If
    End Sub

    Private Sub btnCerrarEditResp_Click(sender As Object, e As EventArgs) Handles btnCerrarEditResp.Click
        groupCodigo.Visible = False
        dtgCodigo.DataSource = Nothing
    End Sub


    Private Sub dtgCodigo_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgCodigo.CellClick
        If (e.RowIndex >= 0) Then
            cargar_cod_seleccionado()
        End If
    End Sub
    Private Sub cargar_cod_seleccionado()
        If Not IsNothing(dtgCodigo.CurrentCell) Then
            Dim codigo As String = dtgCodigo.Item("codigo", dtgCodigo.CurrentCell.RowIndex).Value
            Dim descripcion As String = dtgCodigo.Item("descripcion", dtgCodigo.CurrentCell.RowIndex).Value
            dtg_planilla.Item(colCodigo.Name, filaSelect).Value = codigo
            dtg_planilla.Item(colDescCodigo.Name, filaSelect).Value = descripcion
            btnCerrarEditResp.PerformClick()
        End If
    End Sub
    Private Sub txtDesc_TextChanged(sender As Object, e As EventArgs) Handles txtDesc.TextChanged
        cargarCodigos(txtCodigo.Text, txtDesc.Text)
    End Sub
    Private Sub cargarCodigos(ByVal codigo As String, ByVal descripcion As String)
        Dim where_sql As String = ""
        If (codigo <> "") Then
            where_sql &= " codigo like '" & codigo & "%' "
        ElseIf (descripcion <> "") Then
            where_sql &= " descripcion like '%" & descripcion & "%'"
        End If
        Dim sql As String = "SELECT codigo,descripcion FROM referencias WHERE ref_anulada ='N' AND (codigo like'3c%' or codigo like'3g%' or codigo like'3PT%') AND " & where_sql & ""
        dtgCodigo.DataSource = obj_Op_simpesLn.listar_datatable(sql, "CORSAN")
    End Sub

    Private Function ingProdDms(ByVal dt As DataTable) As List(Of Object)
        Dim tipo As String = "EDEP"
        Dim bodega As String = 3
        Dim dFec As Date = Now
        Dim usuario As String = objUsurioEn.nombre
        Dim notas As String = "SPIC fecha:" & Now & " usuario:" & usuario
        numero_transaccion = objOrdenProdLn.mover_consecutivo(tipo)
        Return objTraslado_bodLn.listaTransaccionDatable(numero_transaccion, dt, bodega, dFec, notas, usuario, tipo, "01")
    End Function
    Private Sub txtCodigo_TextChanged(sender As Object, e As EventArgs) Handles txtCodigo.TextChanged
        If (txtCodigo.Text.Length > 1) Then
            cargarCodigos(txtCodigo.Text, "")
        End If
    End Sub

    Private Sub dtg_planilla_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dtg_planilla.CellValueChanged
        If (carga_comp) Then
            Dim col As String = dtg_planilla.Columns(e.ColumnIndex).Name
            Dim cant_cartones As Integer = 0
            Dim cant_cartones_esp As Double = 0
            Dim fila As Integer = e.RowIndex
            Dim min_trab As Double = 0
            Dim correcto As Boolean = True
            If (col = txt_cant_cartones.Name Or col = txt_esp_cartones.Name) Then
                If IsNumeric(dtg_planilla.Item(txt_esp_cartones.Name, fila).Value) And IsNumeric(dtg_planilla.Item(txt_cant_cartones.Name, fila).Value) Then
                    carga_comp = False
                    calc_efic(fila)
                End If
            ElseIf (col = txt_hora_ini.Name Or col = txt_hora_fin.Name) Then
                If (col = txt_hora_ini.Name) Then
                    If Not IsDate(dtg_planilla.Item(txt_hora_ini.Name, fila).Value) Then
                        dtg_planilla.Item(txt_hora_ini.Name, fila).Value = ""
                        MessageBox.Show("El dato ingresado no es una hora valida ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Else
                    If Not IsDate(dtg_planilla.Item(txt_hora_fin.Name, fila).Value) Then
                        MessageBox.Show("El dato ingresado no es una hora valida ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        dtg_planilla.Item(txt_hora_fin.Name, fila).Value = ""
                    End If
                End If
                If IsDate(dtg_planilla.Item(txt_hora_ini.Name, fila).Value) And IsDate(dtg_planilla.Item(txt_hora_fin.Name, fila).Value) Then
                    min_trab = DateDiff(DateInterval.Minute, dtg_planilla.Item(txt_hora_ini.Name, fila).Value, dtg_planilla.Item(txt_hora_fin.Name, fila).Value)
                    If validar_tiempo_laborado() Then
                        calc_esperada(fila)
                    Else
                        dtg_planilla.Item(txt_hora_fin.Name, fila).Value = ""
                    End If
                End If
            End If
            carga_comp = True
        End If
    End Sub
    Private Function validar_tiempo_laborado() As Boolean
        Dim min_trab As Double = 0
        Dim resp As Boolean = True
        For i = 0 To dtg_planilla.Rows.Count - 1
            If IsDate(dtg_planilla.Item(txt_hora_ini.Name, i).Value) And IsDate(dtg_planilla.Item(txt_hora_fin.Name, i).Value) Then
                If (DateDiff(DateInterval.Minute, dtg_planilla.Item(txt_hora_ini.Name, i).Value, dtg_planilla.Item(txt_hora_fin.Name, i).Value) < 0) Then
                    MessageBox.Show("El tiempo laborado no puede ser negativo, verifique la que la hora inicial no sea mayor a la final ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    resp = False
                Else
                    min_trab += DateDiff(DateInterval.Minute, dtg_planilla.Item(txt_hora_ini.Name, i).Value, dtg_planilla.Item(txt_hora_fin.Name, i).Value)
                End If

            End If
        Next
        If min_trab > 720 Then
            MessageBox.Show("La suma de tiempo trabajado es mayor a 12 horas ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            resp = False
        End If
        Return resp
    End Function
    Public Sub calc_esperada(ByVal fila As Integer)
        Dim min_trab As Double = DateDiff(DateInterval.Minute, dtg_planilla.Item(txt_hora_ini.Name, fila).Value, dtg_planilla.Item(txt_hora_fin.Name, fila).Value)
        Dim esp_8_horas As Double = 41
        Dim esp As Double = (esp_8_horas * min_trab) / 480
        dtg_planilla.Item(txt_esp_cartones.Name, fila).Value = esp
    End Sub
    Public Sub calc_efic(ByVal fila As Integer)
        Dim esp As Double = dtg_planilla.Item(txt_esp_cartones.Name, fila).Value
        Dim prod As Double = dtg_planilla.Item(txt_cant_cartones.Name, fila).Value
        dtg_planilla.Item(txt_porc.Name, fila).Value = (prod / esp) * 100

    End Sub

    Private Sub txtCodigo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCodigo.KeyPress
        If (e.KeyChar = Microsoft.VisualBasic.ChrW(13)) Then
            cargar_cod_seleccionado()
        End If
    End Sub

    Private Sub txtDesc_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDesc.KeyPress
        If (e.KeyChar = Microsoft.VisualBasic.ChrW(13)) Then
            cargar_cod_seleccionado()
        End If
    End Sub


    Private Sub btn_cerrar_Click(sender As Object, e As EventArgs) Handles btn_cerrar.Click
        groupFecha.Visible = False
    End Sub

    Private Sub btn_ok_fec_hora_Click(sender As Object, e As EventArgs) Handles btn_ok_fec_hora.Click
        groupFecha.Visible = False
        Dim fec_hora As String = obj_Op_simpesLn.cambiarFormatoFecha(cboCal.SelectionEnd.Date) & " " & cbo_hora.Text & ":" & cbo_min.Text & ":00"
        dtg_planilla.Item(colSelect, filaSelect).Value = fec_hora
    End Sub

End Class