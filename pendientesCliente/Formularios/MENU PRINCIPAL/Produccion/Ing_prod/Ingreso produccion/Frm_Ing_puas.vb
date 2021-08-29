Imports System.Configuration
Imports logicaNegocios
Imports entidadNegocios
Imports System.IO
Imports Microsoft.Office.Interop
#Disable Warning BC40056 ' El espacio de nombres o el tipo especificado en el 'System.Data.SqlServerCe' Imports no contienen ningún miembro público o no se encuentran. Asegúrese de que el espacio de nombres o el tipo se hayan definido y de que contengan al menos un miembro público. Asegúrese de que el nombre del elemento importado no use ningún alias.
Imports System.Data.SqlServerCe
#Enable Warning BC40056 ' El espacio de nombres o el tipo especificado en el 'System.Data.SqlServerCe' Imports no contienen ningún miembro público o no se encuentran. Asegúrese de que el espacio de nombres o el tipo se hayan definido y de que contengan al menos un miembro público. Asegúrese de que el nombre del elemento importado no use ningún alias.
Public Class Frm_Ing_puas
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
    Private Sub Frm_Ing_puas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim sql As String = "select Codigo,Descripcion from J_turnos  "
        Dim col As New DataColumn
        cbo_fecha.Value = Now.AddDays(-1)
        cbo_turno.DataSource = obj_Ing_prodLn.listar_datatable(sql, "PRODUCCION")
        cbo_turno.ValueMember = "Codigo"
        cbo_turno.DisplayMember = "Descripcion"
        cbo_turno.Text = "Seleccione"

        sql = "Select nit,nombres  from V_nom_personal_Activo_con_maquila WHERE centro = 6400 ORDER BY nombres "
        cbo_operario.DataSource = obj_Ing_prodLn.listar_datatable(sql, "CORSAN")
        cbo_operario.ValueMember = "nit"
        cbo_operario.DisplayMember = "nombres"
        cbo_operario.Text = "Seleccione"

        sql = "SELECT id,descripcion FROM J_prod_puas_tipo "
        cbo_tipo_puas.DataSource = obj_Ing_prodLn.listar_datatable(sql, "PRODUCCION")
        cbo_tipo_puas.ValueMember = "id"
        cbo_tipo_puas.DisplayMember = "descripcion"
        cbo_tipo_puas.Text = "Seleccione"
        cargar_cbo_dtg()
        dtg_planilla.Columns("txt_hodometro").DefaultCellStyle.Format = "N1"
        carga_comp = True
    End Sub
    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If (cbo_operario.Text <> "Seleccione" And cbo_turno.Text <> "Seleccione" And cbo_tipo_puas.Text <> "Seleccione") Then
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
        cargar_cbo_dtg()
    End Sub
    Private Sub cargar_cbo_dtg()
        Dim sql As String = ""
        Dim col As New DataColumn
        Dim dt As DataTable
        Dim row As DataRow
        sql = "select  codigoM,nombre   from j_Maquinas where TipoMaquina =4 AND activa = 1 "
        dt = obj_Ing_prodLn.listar_datatable(sql, "PRODUCCION")
        row = dt.NewRow
        row("codigoM") = 0
        row("nombre") = ""
        dt.Rows.Add(row)
        cbo_maquina.DataSource = dt
        cbo_maquina.ValueMember = "codigoM"
        cbo_maquina.DisplayMember = "nombre"


        sql = "select  id_ref,descripcion   from J_referencias where tipo = 4 "
        dt = obj_Ing_prodLn.listar_datatable(sql, "PRODUCCION")
        row = dt.NewRow
        row("id_ref") = 0
        row("descripcion") = ""
        dt.Rows.Add(row)
        'cbo_producto.DataSource = dt
        'cbo_producto.ValueMember = "id_ref"
        'cbo_producto.DisplayMember = "descripcion"

        For i = 0 To 6
            dtg_planilla.Rows.Add()
        Next
    End Sub
    Private Sub guardar()
        Dim numero As Double = 0
        Dim listSql As New List(Of Object)
        Dim dt_codigos_valores As New DataTable
        dt_codigos_valores.Columns.Add("codigo")
        dt_codigos_valores.Columns.Add("cantidad")
        Dim codigo As String = ""
        Dim tipo As Integer = cbo_tipo_puas.SelectedValue
        Dim resp As Boolean = False
        Dim fecha As String = obj_Op_simpesLn.cambiarFormatoFecha(cbo_fecha.Value.Date)
        Dim turno As Integer = cbo_turno.SelectedValue
        'Se  le suman los paros antiguos para que cada registro quede con su tiempo sin just individual
        Dim t_sin_just As Double = 0
        Dim k_esperado As Double = 0
        Dim kil_prod As Double = 0
        Dim royo_prod As Double = 0
        Dim royo_esp As Double = 0
        Dim maquina As Integer = 0
        Dim referencia As String = ""
        Dim h_trab As Double = 0
        Dim paro1 As Integer = 0
        Dim paro2 As Integer = 0
        Dim paro3 As Integer = 0
        Dim paro4 As Integer = 0
        Dim paro5 As Integer = 0
        Dim paro6 As Integer = 0
        Dim paro7 As Integer = 0
        Dim paro8 As Integer = 0
        Dim paro9 As Integer = 0
        Dim paro10 As Integer = 0
        Dim paro11 As Integer = 0
        Dim paro12 As Integer = 0
        Dim sql_total As String = ""
        Dim sql_gral As String = "INSERT INTO J_prod_puas (fecha, nit, turno,tipo,numero_transaccion,horas_prog, horas_trab,referencia,kilos_prod,kilos_esp,roy_esp,roy_prod,t_sin_just, maquina,paro1, paro3, paro4, paro5, paro6, paro7, paro8, paro9,paro11,paro12,paro13) " & _
                                               "VALUES('" & fecha & "'," & operario & " , " & turno & "," & tipo & ","
        If (verificar_planilla(dtg_planilla)) Then

            For i = 0 To dtg_planilla.RowCount - 1
                codigo = dtg_planilla.Item(colCodigo.Name, i).Value
                royo_prod = dtg_planilla.Item("txt_cant", i).Value
                maquina = dtg_planilla.Item("cbo_maquina", i).Value
                referencia = dtg_planilla("cbo_producto", i).Value
                kil_prod = dtg_planilla.Item("txt_kilos", i).Value
                If (maquina <> 0 And referencia <> Nothing And kil_prod <> 0 And royo_prod <> 0) Then
                    dt_codigos_valores.Rows.Add()
                    dt_codigos_valores.Rows(dt_codigos_valores.Rows.Count - 1).Item("codigo") = codigo
                    dt_codigos_valores.Rows(dt_codigos_valores.Rows.Count - 1).Item("cantidad") = royo_prod
                End If
            Next
            numero = ingProdDms(dt_codigos_valores)
            royo_prod = 0
            maquina = 0
            referencia = ""
            kil_prod = 0
            If numero <> 0 Then
                sql_gral &= numero & ","
                For i = 0 To dtg_planilla.RowCount - 1
                    codigo = dtg_planilla.Item(colCodigo.Name, i).Value
                    royo_prod = dtg_planilla.Item("txt_cant", i).Value
                    maquina = dtg_planilla.Item("cbo_maquina", i).Value
                    'h_trab = (dtg_planilla.Item("txt_uni_fin", i).Value - dtg_planilla.Item("txt_un_ini", i).Value)
                    referencia = dtg_planilla("cbo_producto", i).Value
                    kil_prod = dtg_planilla.Item("txt_kilos", i).Value
                    k_esperado = dtg_planilla.Item("txt_esp_kil", i).Value

                    royo_esp = dtg_planilla.Item("txt_esp_royos", i).Value
                    h_trab = dtg_planilla.Item("txt_hodometro", i).Value
                    t_sin_just = calc_t_sin_just(i, h_trab)
                    If (maquina <> 0 And referencia <> Nothing And kil_prod <> 0 And royo_prod <> 0) Then
                        dt_codigos_valores.Rows.Add()
                        dt_codigos_valores.Rows(dt_codigos_valores.Rows.Count - 1).Item("codigo") = codigo
                        dt_codigos_valores.Rows(dt_codigos_valores.Rows.Count - 1).Item("cantidad") = royo_prod
                        sql_total = sql_gral & h_prog & "," & h_trab & "," & referencia & "," & kil_prod & "," & k_esperado & ", " & royo_esp & "," & royo_prod & "," & t_sin_just & "," & maquina & "," & _
                                            add_paros(i, dtg_planilla)
                        listSql.Add(sql_total)
                        dtg_planilla.Rows(i).DefaultCellStyle.BackColor = Color.Green
                    End If
                Next
                resp = obj_Ing_prodLn.ExecuteSqlTransaction(listSql, "PRODUCCION")
            End If
            If (resp) Then
                MessageBox.Show("Su planilla fue ingresada en forma exitosa! ", "Correcto!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                limpiar()
            Else
                MessageBox.Show("Error al ingresar la planilla a la base de datos,verifique que todos los datos esten correctos ò comuniquese con el administrador del sistema! ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            MessageBox.Show("Verifique que los datos de todos los registros de maquina sean correctos! ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub
    Public Function calc_t_sin_just(ByVal indice As Integer, ByVal h_trab As Double) As Double
        Dim resp As Double = 0
        Dim sw As Boolean = False
        Dim paros As Double = 0
        For i = 0 To dtg_planilla.ColumnCount - 1
            If (dtg_planilla.Columns(i).Name = "txt_p1") Then
                sw = True
            End If
            If (sw) Then
                paros += dtg_planilla.Item(i, indice).Value
            End If
        Next
        resp = (h_prog * 60) - (h_trab * 60) - (paros) - 20
        Return resp
    End Function
    Public Function verificar_planilla(ByVal dtg As DataGridView) As Boolean
        Dim resp As Boolean = True
        Dim maquina As Integer = 0
        Dim cant As Double = 0
        Dim horometro As Double = 0
        ' h_trab = (dtg_planilla.Item("txt_uni_fin", i).Value - dtg_planilla.Item("txt_un_ini", i).Value)
        Dim referencia As String = ""
        For i = 0 To dtg_planilla.RowCount - 1
            maquina = dtg_planilla.Item("cbo_maquina", i).Value
            referencia = dtg_planilla("cbo_producto", i).Value
            cant = dtg_planilla("txt_cant", i).Value
            horometro = dtg_planilla(txt_hodometro.Name, i).Value
            If (maquina <> 0 Or referencia <> Nothing Or cant <> 0 Or dtg_planilla(colCodigo.Name, i).Value <> "" Or horometro <> 0) Then
                If Not (maquina <> 0 And referencia <> Nothing And cant <> 0 And dtg_planilla(colCodigo.Name, i).Value <> "" Or horometro <> 0) Then
                    If (dtg_planilla(colCodigo.Name, i).Value <> "") Then
                        If Not (obj_Op_simpesLn.validarCodigo(dtg_planilla(colCodigo.Name, i).Value)) Then
                            MessageBox.Show("Codigo de producto incorrecto en la fila # " & i + 1 & " ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            resp = False
                            i = dtg_planilla.RowCount - 1
                        End If
                    Else
                        MessageBox.Show("Se debe ingresar un código de producto ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        resp = False
                        i = dtg_planilla.RowCount - 1
                    End If
                    resp = False
                    i = dtg_planilla.RowCount - 1
                End If
            End If
        Next
        Return resp
    End Function
    Private Function paros_ant() As Double
        Dim tiem_ant As Double = 0
        Dim fec As String = cbo_fecha.Value.Date
        Dim sql As String = "SELECT SUM (paro1 )+SUM (paro2 )+SUM (paro3 )+SUM (paro4 )+SUM (paro5 )+SUM (paro6 )+SUM (paro7 )+ " & _
                                    "SUM(paro8) + SUM(paro9) + SUM(paro10) " & _
                                            "FROM J_prod_puntilleria " & _
                                                 "WHERE nit = " & operario & " AND fecha = '" & fec & "'"
        tiem_ant = obj_Ing_prodLn.consultar_valor(sql, "PRODUCCION")
        Return tiem_ant
    End Function
    Public Function calcular_kilos(ByVal ref As Integer, ByVal horas As Double, ByVal maquina As Integer) As Double
        Dim resp As Double = 0
        Dim cantidad As Double = 0
        Dim sql As String = "SELECT  SUM ([u_x_kg]) FROM J_referencias WHERE id_ref = " & ref
        Dim u_x_kg As Double = obj_Ing_prodLn.consultar_valor(sql, "PRODUCCION")
        sql = "SELECT  vel_actual FROM J_maquinas WHERE codigoM = " & maquina
        Dim velocidad As Double = obj_Ing_prodLn.consultar_valor(sql, "PRODUCCION")
        cantidad = (horas * 60) * velocidad
        resp = (cantidad) / u_x_kg
        Return resp
    End Function
    Public Function sumar_paros(ByVal indice As Integer, ByVal dtg As DataGridView) As Double
        Dim sum As Double = 0
        For i = dtg.Columns("txt_p1").Index To dtg.ColumnCount - 1
            If (dtg.Item(i, indice).Value <> "") Then
                sum = sum + dtg.Item(i, indice).Value
            End If
        Next
        Return sum
    End Function
    Public Function add_paros(ByVal indice As Integer, ByVal dtg As DataGridView) As String
        Dim sql As String = ""
        Dim paro1 As Integer = 0
        Dim paro3 As Integer = 0
        Dim paro4 As Integer = 0
        Dim paro5 As Integer = 0
        Dim paro6 As Integer = 0
        Dim paro7 As Integer = 0
        Dim paro8 As Integer = 0
        Dim paro9 As Integer = 0
        Dim paro11 As Integer = 0
        Dim paro12 As Integer = 0
        Dim paro13 As Integer = 0
        Dim num As String = ""

        For i = dtg.Columns("txt_p1").Index To dtg.ColumnCount - 1
            If (dtg.Columns(i).HeaderText.ToString).Length > 2 Then
                num = Convert.ToInt16(dtg.Columns(i).HeaderText(1).ToString) & (dtg.Columns(i).HeaderText(2).ToString)
            Else
                num = (dtg.Columns(i).HeaderText(1).ToString)
            End If

            Select Case num
                Case 1
                    If Not IsDBNull(dtg.Item(i, indice).Value) Then
                        If (dtg.Item(i, indice).Value <> "") Then
                            paro1 = dtg.Item(i, indice).Value
                        End If
                    End If
                Case 3
                    If Not IsDBNull(dtg.Item(i, indice).Value) Then
                        If (dtg.Item(i, indice).Value <> "") Then
                            paro3 = dtg.Item(i, indice).Value
                        End If
                    End If
                Case 4
                    If Not IsDBNull(dtg.Item(i, indice).Value) Then
                        If (dtg.Item(i, indice).Value <> "") Then
                            paro4 = dtg.Item(i, indice).Value
                        End If
                    End If
                Case 5
                    If Not IsDBNull(dtg.Item(i, indice).Value) Then
                        If (dtg.Item(i, indice).Value <> "") Then
                            paro5 = dtg.Item(i, indice).Value
                        End If
                    End If
                Case 6
                    If Not IsDBNull(dtg.Item(i, indice).Value) Then
                        If (dtg.Item(i, indice).Value <> "") Then
                            paro6 = dtg.Item(i, indice).Value
                        End If
                    End If
                Case 7
                    If Not IsDBNull(dtg.Item(i, indice).Value) Then
                        If (dtg.Item(i, indice).Value <> "") Then
                            paro7 = dtg.Item(i, indice).Value
                        End If
                    End If
                Case 8
                    If Not IsDBNull(dtg.Item(i, indice).Value) Then
                        If (dtg.Item(i, indice).Value <> "") Then
                            paro8 = dtg.Item(i, indice).Value
                        End If
                    End If
                Case 9
                    If Not IsDBNull(dtg.Item(i, indice).Value) Then
                        If (dtg.Item(i, indice).Value <> "") Then
                            paro9 = dtg.Item(i, indice).Value
                        End If
                    End If
                Case 11
                    If Not IsDBNull(dtg.Item(i, indice).Value) Then
                        If (dtg.Item(i, indice).Value <> "") Then
                            paro11 = dtg.Item(i, indice).Value
                        End If
                    End If
                Case 12
                    If Not IsDBNull(dtg.Item(i, indice).Value) Then
                        If (dtg.Item(i, indice).Value <> "") Then
                            paro12 = dtg.Item(i, indice).Value
                        End If
                    End If
                Case 13
                    If Not IsDBNull(dtg.Item(i, indice).Value) Then
                        If (dtg.Item(i, indice).Value <> "") Then
                            paro13 = dtg.Item(i, indice).Value
                        End If
                    End If

            End Select
        Next
        sql = paro1 & " , " & paro3 & " , " & paro4 & " , " & paro5 & " , " & paro6 & " , " & paro7 & " , " & paro8 & " , " & paro9 & " ,  " & paro11 & "," & paro12 & "," & paro13 & ")"
        Return sql
    End Function

    Private Sub cbo_turno_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_turno.SelectedIndexChanged
        If (carga_comp) Then
            If (cbo_turno.Text <> "Seleccione") Then
                Dim horas As String = obj_Ing_prodLn.consultar_valor("SELECT Horas FROM J_turnos WHERE Codigo = " & cbo_turno.SelectedValue, "PRODUCCION")
                h_prog = Convert.ToInt16(horas)
                cambio_h_prog()

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
        Frm_consultar_puas.Show()
    End Sub
    Private Sub dtg_planilla_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtg_planilla.CellValueChanged
        If (carga_comp) Then
            Dim col As String = dtg_planilla.Columns(e.ColumnIndex).Name
            Dim id_ref As Int64 = 0
            Dim prod As Integer = 0
            Dim fila As Integer = e.RowIndex
            Dim u_x_kil As Double = 0
            Dim cant As Integer = 0
            Dim restar As Boolean = False
            Dim h_trab As Double = 0
            Dim txt As String = ""
            If (col = "txt_hodometro") Then
                txt = dtg_planilla.Item("txt_hodometro", fila).Value
                For i = 0 To txt.Length - 1
                    If (txt(i) = "-") Then
                        restar = True
                    End If
                Next
                If (restar) Then
                    h_trab = restar_txtbox(dtg_planilla.Item("txt_hodometro", fila).Value)
                Else
                    If IsNumeric(dtg_planilla.Item("txt_hodometro", fila).Value) Then
                        h_trab = dtg_planilla.Item("txt_hodometro", fila).Value
                    End If
                End If
                If (h_trab > 12 Or h_trab > h_prog) Then
                    dtg_planilla.Item("txt_hodometro", fila).Style.BackColor = Color.Red
                Else
                    dtg_planilla.Item("txt_hodometro", fila).Style.BackColor = Color.Gainsboro
                End If
                dtg_planilla.Item("txt_hodometro", fila).Value = h_trab
            End If
            If (col = "cbo_producto" Or col = "txt_cant" Or col = "txt_hodometro") Then
                If (dtg_planilla.Item("txt_cant", e.RowIndex).Value <> "" And dtg_planilla.Item("cbo_producto", e.RowIndex).Value <> "" And dtg_planilla.Item("txt_hodometro", e.RowIndex).Value <> 0) Then
                    id_ref = 1
                    calcular_royo_esp(dtg_planilla.Item(colCodigo.Name, e.RowIndex).Value, fila)
                    u_x_kil = cargar_u_x_kil(dtg_planilla.Item(colCodigo.Name, e.RowIndex).Value)
                    cant = dtg_planilla.Item("txt_cant", e.RowIndex).Value
                    dtg_planilla.Item("txt_kilos", fila).Value = u_x_kil * cant
                    dtg_planilla.Item("txt_esp_kil", fila).Value = dtg_planilla.Item("txt_esp_royos", fila).Value * u_x_kil
                    calc_T_sin_just(fila)
                End If
            End If
            If (col = "txt_p1" Or col = "txt_p3" Or col = "txt_p4" Or col = "txt_p5" Or col = "txt_p6" Or col = "txt_p7" Or col = "txt_p8" Or col = "txt_p9" Or col = "txt_p10" Or col = "txt_p11" Or col = "txt_p12" Or col = "txt_p13") Then
                txt = dtg_planilla.Item("txt_hodometro", fila).Value
                For i = 0 To txt.Length - 1
                    If (txt(i) = "-") Then
                        restar = True
                    End If
                Next
                If Not (restar) Then
                    If (txt <> "") Then
                        calc_t_sin_just(fila)
                    End If
                End If
            End If
            If (col = "txt_porc") Then
                If (dtg_planilla.Item("txt_porc", fila).Value >= 100) Then
                    dtg_planilla.Item("txt_porc", fila).Style.BackColor = Color.Red
                Else
                    dtg_planilla.Item("txt_porc", fila).Style.BackColor = Color.Gainsboro
                End If
            End If
        End If
    End Sub
    Private Sub cacular_efic(ByVal prod As Integer, ByVal esp As Double, ByVal fila As Integer)
        dtg_planilla.Item("txt_porc", fila).Value = (prod / esp) * 100
    End Sub
    Private Sub calcular_royo_esp(ByVal id_ref As String, ByVal fila As Integer)
        Dim royo_esp As Double = 0
        Dim u_x_kil As Double = 0
        Dim uni_x_turno As Integer = 0
        Dim sql As String = ""
        Dim prod As Integer = 0
        sql = "SELECT conversion FROM referencias WHERE codigo='" & id_ref & "'"
        If (dtg_planilla.Item("cbo_maquina", fila).Value = 5001 Or dtg_planilla.Item("cbo_maquina", fila).Value = 5002) Then
            uni_x_turno = obj_Ing_prodLn.espRoyosBerg(id_ref)
        Else
            uni_x_turno = obj_Ing_prodLn.consultar_valor(sql, "CORSAN")
        End If

        royo_esp = (h_prog * uni_x_turno) / 8
        dtg_planilla.Item("txt_esp_royos", fila).Value = royo_esp
        prod = dtg_planilla.Item("txt_cant", fila).Value
        u_x_kil = cargar_u_x_kil(dtg_planilla.Item(colCodigo.Name, fila).Value)
        dtg_planilla.Item("txt_esp_kil", fila).Value = dtg_planilla.Item("txt_esp_royos", fila).Value * u_x_kil
        cacular_efic(prod, royo_esp, fila)
    End Sub
    Public Sub cambio_h_prog()
        For i = 0 To dtg_planilla.RowCount - 1
            If (dtg_planilla.Item("cbo_producto", i).Value <> "" And dtg_planilla.Item("txt_cant", i).Value <> 0) Then
                Dim id_ref As Int64 = dtg_planilla.Item("cbo_producto", i).Value
                calcular_royo_esp(id_ref, i)
                calc_T_sin_just(i)
                If (IsNumeric(dtg_planilla.Item("txt_hodometro", i).Value)) Then
                    If (dtg_planilla.Item("txt_hodometro", i).Value > h_prog) Then
                        dtg_planilla.Item("txt_hodometro", i).Style.BackColor = Color.Red
                    Else
                        dtg_planilla.Item("txt_hodometro", i).Style.BackColor = Color.Gainsboro
                    End If
                End If
            End If
        Next
    End Sub
    Private Sub chk_todos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_todos.CheckedChanged
        If (chk_todos.Checked = True) Then
            Dim sql As String = "Select nit,nombres   from V_nom_personal_Activo_con_maquila WHERE centro not in (4200) ORDER BY nombres "
            cbo_operario.DataSource = obj_Ing_prodLn.listar_datatable(sql, "CORSAN")
            cbo_operario.ValueMember = "nit"
            cbo_operario.DisplayMember = "nombres"
            cbo_operario.Text = "Seleccione"
        Else
            Dim sql As String = "Select nit,nombres  from V_nom_personal_Activo_con_maquila WHERE centro = 6400 ORDER BY nombres"
            cbo_operario.DataSource = obj_Ing_prodLn.listar_datatable(sql, "CORSAN")
            cbo_operario.ValueMember = "nit"
            cbo_operario.DisplayMember = "nombres"
            cbo_operario.Text = "Seleccione"
        End If
    End Sub
    Private Function cargar_u_x_kil(ByVal codigo As String) As Integer
        Dim sql As String = "SELECT conversion FROM referencias WHERE codigo='" & codigo & "'"
        Dim u_x_kil As Integer = obj_Ing_prodLn.consultar_valor(sql, "CORSAN")
        Return u_x_kil
    End Function
    Private Function restar_txtbox(ByVal text As String) As Double
        Dim total As Double
        Dim val As String = ""
        Dim sw As Boolean = False
        Dim restar As Boolean = False
        For i = 0 To text.Length - 1
            If (text(i) = "-") Then
                restar = True
            End If
        Next
        If restar Then
            If Not text = "" Then
                For i = 0 To text.Length - 1
                    If (text(i) = "-") Then
                        If (sw = False) Then
                            total = Convert.ToDouble(val)
                        Else
                            total -= Convert.ToDouble(val)
                        End If
                        val = ""
                        sw = True
                    Else
                        val &= text(i)
                    End If
                Next
                If (val = "") Then
                    val = 0
                End If
                total -= Convert.ToDouble(val)
            End If
        Else
            total = text
        End If
        If (total < 0) Then
            MessageBox.Show("El horometro no puede ser negativo", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
            total = 0
        End If
        Return total
    End Function
    Private Sub calc_T_sin_just(ByVal fila As Integer)
        Dim paros As Double = 0
        Dim t_sin_just As Double = 0
        Dim h_trab As Double = dtg_planilla.Item("txt_hodometro", fila).Value
        paros = sumar_paros(fila, dtg_planilla)
        t_sin_just = ((h_prog - h_trab) * 60) - (paros) - 20
        If (t_sin_just < 0 And IsNumeric(dtg_planilla.Item("txt_t_sin_just", fila).Value)) Then
            dtg_planilla.Item("txt_t_sin_just", fila).Style.BackColor = Color.Red
        Else
            dtg_planilla.Item("txt_t_sin_just", fila).Style.BackColor = Color.Gainsboro
        End If
        dtg_planilla.Item("txt_t_sin_just", fila).Value = t_sin_just
    End Sub
    Private Sub dtg_planillaCellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtg_planilla.CellClick
        Dim fila As Integer = e.RowIndex
        Dim col As String = dtg_planilla.Columns(e.ColumnIndex).Name
        If (col = "btn_borrar") Then
            dtg_planilla.Rows.RemoveAt(e.RowIndex)
        ElseIf (col = col_add.Name) Then
            dtg_planilla.Rows.Add()
        ElseIf (col = colCodigo.Name Or col = colDescCodigo.Name) Then
            txtDesc.Text = ""
            txtCodigo.Text = ""
            groupCodigo.Visible = True
            txtDesc.Focus()
            filaSelect = e.RowIndex
        End If
    End Sub

    Private Sub btnCerrarEditResp_Click(sender As Object, e As EventArgs) Handles btnCerrarEditResp.Click
        groupCodigo.Visible = False
        dtgCodigo.DataSource = Nothing
    End Sub


    Private Sub dtgCodigo_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgCodigo.CellClick
        If (e.RowIndex >= 0) Then
            Dim codigo As String = dtgCodigo.Item("codigo", e.RowIndex).Value
            Dim descripcion As String = dtgCodigo.Item("descripcion", e.RowIndex).Value
            dtg_planilla.Item(colCodigo.Name, filaSelect).Value = codigo
            dtg_planilla.Item(colDescCodigo.Name, filaSelect).Value = descripcion
            dtg_planilla.Item(cbo_producto.Name, filaSelect).Value = descripcion
            btnCerrarEditResp.PerformClick()
        End If
    End Sub
    Private Sub txtDesc_TextChanged(sender As Object, e As EventArgs) Handles txtDesc.TextChanged
        If (txtDesc.Text.Length > 1) Then
            cargarCodigos("", txtDesc.Text)
        End If
    End Sub


    Private Sub cargarCodigos(ByVal codigo As String, ByVal descripcion As String)
        Dim where_sql As String = ""
        If (codigo <> "") Then
            where_sql &= " codigo like '" & codigo & "%' "
        ElseIf (descripcion <> "") Then
            where_sql &= " descripcion like '%" & descripcion & "%'"
        End If
        Dim sql As String = "SELECT codigo,descripcion FROM referencias WHERE ref_anulada ='N' AND codigo like'33P%' AND " & where_sql & ""
        dtgCodigo.DataSource = obj_Op_simpesLn.listar_datatable(sql, "CORSAN")
    End Sub

    Private Function ingProdDms(ByVal dt As DataTable) As Double
        Dim tipo As String = "EPPT"
        Dim bodega As String = 3
        Dim dFec As Date = Now
        Dim usuario As String = objUsurioEn.nombre
        Dim notas As String = "SPIC fecha:" & Now & " usuario:" & usuario
        Dim numero As Double
        Dim modelo As String = "01"
        numero = objTraslado_bodLn.transaccionDatable(dt, bodega, dFec, notas, usuario, tipo, modelo)
        If (numero <> 0) Then
            MessageBox.Show("Transacción realizada con exito," & tipo & " NÚMERO : " & numero & " ", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Error al realizar la transacción,NO SE INGRESO LA PRODUCCIÓN , comuniquese con el administrador del sistema! ", "NO SE INGRESO LA PRODUCCIÓN ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        Return numero
    End Function
    Private Sub txtCodigo_TextChanged(sender As Object, e As EventArgs) Handles txtCodigo.TextChanged
        If (txtCodigo.Text.Length > 1) Then
            cargarCodigos(txtCodigo.Text, "")
        End If
    End Sub

 
End Class