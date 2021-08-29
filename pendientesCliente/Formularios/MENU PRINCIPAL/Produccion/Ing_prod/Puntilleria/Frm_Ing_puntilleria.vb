Imports System.Configuration
Imports logicaNegocios
Imports System.IO
Imports Microsoft.Office.Interop
#Disable Warning BC40056 ' El espacio de nombres o el tipo especificado en el 'System.Data.SqlServerCe' Imports no contienen ningún miembro público o no se encuentran. Asegúrese de que el espacio de nombres o el tipo se hayan definido y de que contengan al menos un miembro público. Asegúrese de que el nombre del elemento importado no use ningún alias.
Imports System.Data.SqlServerCe
#Enable Warning BC40056 ' El espacio de nombres o el tipo especificado en el 'System.Data.SqlServerCe' Imports no contienen ningún miembro público o no se encuentran. Asegúrese de que el espacio de nombres o el tipo se hayan definido y de que contengan al menos un miembro público. Asegúrese de que el nombre del elemento importado no use ningún alias.
Public Class Frm_Ing_puntilleria
    Private obj_Ing_prodLn As New Ing_prodLn
    Private carga_comp As Boolean = False
    Private h_prog As Double = 0
    Private operario As Double = 0
    Private nom_modulo As String
    Private obj_opSimplesLn As New Op_simpesLn
    Private nit, turno As String
    Public Sub Main(ByVal nit As String)
        Me.nit = nit
        cbo_operario.SelectedValue = nit
        btnContCambios.Visible = False
    End Sub
    Private Sub btnContCambios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnContCambios.Click
        FrmAuditCambios.Show()
        FrmAuditCambios.Main(nom_modulo)
        FrmAuditCambios.WindowState = 2
    End Sub
    Private Sub Ing_puntilleria_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim sql As String = "select Codigo,Descripcion from J_turnos  "
        Dim col As New DataColumn
        cbo_fecha.Value = Now.AddDays(-1)
        cbo_turno.DataSource = obj_Ing_prodLn.listar_datatable(Sql, "PRODUCCION")
        cbo_turno.ValueMember = "Codigo"
        cbo_turno.DisplayMember = "Descripcion"
        cbo_turno.Text = "Seleccione"




        sql = "Select nit,nombres  from V_nom_personal_Activo_con_maquila WHERE (centro_planta in (2300,6400) or centro_planta is null) ORDER BY nombres "
        cbo_operario.DataSource = obj_Ing_prodLn.listar_datatable(Sql, "CORSAN")
        cbo_operario.ValueMember = "nit"
        cbo_operario.DisplayMember = "nombres"
        cbo_operario.Text = "Seleccione"
        cbo_operario.SelectedValue = nit
        cargar_cbo_dtg()
        carga_comp = True
    End Sub
    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If (cbo_operario.Text <> "Seleccione" And turno <> "") Then
            guardar()
            ' limpiar()
        Else
            MessageBox.Show("Seleccione todos los campos requeridos! ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Private Sub limpiar()
        txt_observaciones.Text = ""
        cbo_operario.Text = "Seleccione"
        cbo_turno.Text = "Seleccione"
        dtg_planilla.Rows.Clear()
        cargar_cbo_dtg()
    End Sub
    Private Sub cargar_cbo_dtg()
        Dim sql As String = ""
        Dim dt As DataTable
        Dim row As DataRow
        sql = "select  codigoM,nombre   from j_Maquinas where TipoMaquina in (2,3) AND activa = 1 "
        dt = obj_Ing_prodLn.listar_datatable(sql, "PRODUCCION")
        row = dt.NewRow
        row("codigoM") = 0
        row("nombre") = ""
        dt.Rows.Add(row)
        id_maquina.DataSource = dt
        id_maquina.ValueMember = "codigoM"
        id_maquina.DisplayMember = "nombre"

        sql = "select  id_ref,descripcion   from J_referencias where tipo in (2,3) "
        dt = obj_Ing_prodLn.listar_datatable(sql, "PRODUCCION")
        row = dt.NewRow
        row("id_ref") = 0
        row("descripcion") = ""
        dt.Rows.Add(row)
        id_producto.DataSource = dt
        id_producto.ValueMember = "id_ref"
        id_producto.DisplayMember = "descripcion"

        For i = 0 To 7
            dtg_planilla.Rows.Add()
        Next
        cargar_maquinas()
    End Sub
    Private Sub cargar_maquinas()
        Dim fec_c As String
        Dim horae As String
        Dim horas As String
        Dim fecIni As String = obj_opSimplesLn.cambiarFormatoFecha(Now)
        Dim fecFin As String = obj_opSimplesLn.cambiarFormatoFecha(Now)
        Dim fecune, fecuns As String
        Dim dt As DataTable
        turno = ""
        fec_c = "" & System.DateTime.Now.Hour & ":" & System.DateTime.Now.Minute & ""

        If CDate(fec_c) >= "6:00" And CDate(fec_c) <= "14:00" Then
            turno = "1"
        ElseIf CDate(fec_c) >= "14:00" And CDate(fec_c) <= "22:00" Then
            turno = "2"
        ElseIf CDate(fec_c) >= "22:00" And CDate(fec_c) <= "6:000" Then
            turno = "3"
        End If
        cbo_turno.Text = turno
        turno = turno
        If turno = 1 Then
            horae = "06:00:00"
            horas = "14:00:00"
        ElseIf turno = 2 Then
            horae = "14:01:00"
            horas = "22:00:00"
        Else
            horae = "14:01:00"
            horas = "22:00:00"
        End If
        fecune = fecIni & " " & horae
        fecuns = fecFin & " " & horas
        horas = ""
        Dim texto As String = cbo_turno.Text
        For i = 0 To texto.Length - 1
            If IsNumeric(texto(i)) Then
                horas += texto(i)
            End If
        Next
        h_prog = Convert.ToInt16(horas)
        cambio_h_prog()
        Dim sql As String = "SELECT  e.maquina,e.prod_final FROM J_orden_prod_punt_producto p ,J_orden_prod_punt_enc e , CORSAN.dbo.referencias r , CORSAN.dbo.V_nom_personal_Activo_con_maquila  t , j_maquinas m WHERE p.nro_orden = e.consecutivo AND r.codigo = e.prod_final AND t.nit = p.nit_operario AND m.codigoM = e.maquina AND p.anular IS NULL AND no_conforme IS  NULL AND fecha_hora >= '" & fecune & "' AND fecha_hora <= '" & fecuns & "' AND nit_operario = " & nit & ""
        dt = obj_opSimplesLn.listar_datatable(sql, "PRODUCCION")
        For i = 0 To dt.Rows.Count - 1
            dtg_planilla.Item("id_maquina", i).Value = dt.Rows(i).Item("maquina")
        Next
    End Sub
    Private Sub guardar()
        Dim uni_ini As String = 0
        Dim uni_fin As String = 0
        Dim resp As Integer = 0
        Dim fecha As String = obj_opSimplesLn.cambiarFormatoFecha(cbo_fecha.Value.Date)
        Dim turno As Integer = cbo_turno.SelectedValue
        Dim h_trab As Double = 0
        'Se  le suman los paros antiguos para que cada registro quede con su tiempo sin just individual
        Dim t_sin_just As Double = 0
        Dim k_esperado As Double = 0
        Dim kil_prod As Double = 0
        Dim maquina As Integer = 0
        Dim referencia As String = ""
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
        Dim observaciones As String = txt_observaciones.Text
        Dim sql_gral As String = "INSERT INTO J_prod_puntilleria (fecha, nit, turno,observaciones,horas_prog, horas_trab,referencia,kilos_prod,kil_esperado,t_sin_just, maquina, paro1, paro2, paro3, paro4, paro5, paro6, paro7, paro8, paro9, paro10,paro11,paro12, paro13, paro14, paro15, paro16, paro17, paro18, paro19, paro20,paro21,paro22,paro23) " &
                                               "VALUES('" & fecha & "'," & operario & " , " & turno & ",'" & observaciones & "',"
        If (verificar_planilla(dtg_planilla)) Then
            For i = 0 To dtg_planilla.RowCount - 1
                uni_ini = dtg_planilla.Item("txt_un_ini", i).Value
                uni_fin = dtg_planilla.Item("txt_uni_fin", i).Value
                maquina = dtg_planilla.Item("id_maquina", i).Value
                referencia = dtg_planilla("id_producto", i).Value
                If (maquina <> 0 And referencia <> Nothing And uni_ini <> "" And uni_fin <> "") Then
                    h_trab = (dtg_planilla.Item("txt_uni_fin", i).Value - dtg_planilla.Item("txt_un_ini", i).Value)
                    kil_prod = calcular_kilos(referencia, h_trab, maquina)
                    k_esperado = calcular_kilos(referencia, h_prog, maquina)
                    t_sin_just = (h_prog * 60) - (h_trab * 60) - (sumar_paros(i, dtg_planilla)) - 20
                    sql_total = sql_gral & h_prog & "," & h_trab & "," & referencia & "," & kil_prod & "," & k_esperado & "," & t_sin_just & "," & maquina & "," &
                          add_paros(i, dtg_planilla)
                    resp += obj_Ing_prodLn.ejecutar(sql_total, "PRODUCCION")
                    If (resp > 0) Then
                        dtg_planilla.Rows(i).DefaultCellStyle.BackColor = Color.Green
                    Else
                        i = dtg_planilla.RowCount - 1
                        resp = 0
                    End If
                End If
            Next
            If (resp > 0) Then
                MessageBox.Show("Su planilla fue ingresada en forma exitosa! ", "Correcto!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                limpiar()
            Else
                MessageBox.Show("Error al ingresar la planilla a la base de datos,verifique que todos los datos esten correctos ò comuniquese con el administrador del sistema! ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            MessageBox.Show("Verifique que los datos de todos los registros de maquina sean correctos! ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

    Public Function verificar_planilla(ByVal dtg As DataGridView) As Boolean
        Dim resp As Boolean = True
        Dim maquina As Integer = 0
        Dim uni_ini As Double = 0
        Dim uni_fin As Double = 0
        ' h_trab = (dtg_planilla.Item("txt_uni_fin", i).Value - dtg_planilla.Item("txt_un_ini", i).Value)
        Dim referencia As String = ""
        For i = 0 To dtg_planilla.RowCount - 1
            maquina = dtg_planilla.Item("id_maquina", i).Value
            referencia = dtg_planilla("id_producto", i).Value
            uni_ini = dtg_planilla.Item("txt_un_ini", i).Value
            uni_fin = dtg_planilla.Item("txt_uni_fin", i).Value
            dtg_planilla.Rows(i).DefaultCellStyle.BackColor = Color.Red
            If (uni_ini > uni_fin) Then
                MessageBox.Show("El horometro no puede ser negativo! ", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
                dtg_planilla.Item("txt_uni_fin", i).Value = 0
                dtg_planilla.Item("txt_un_ini", i).Value = 0
                resp = False
                i = dtg_planilla.RowCount - 1
            ElseIf (maquina <> 0 Or referencia <> Nothing Or uni_ini <> Nothing Or uni_fin <> Nothing) Then
                If Not (maquina <> 0 And referencia <> Nothing And uni_ini <> 0 And uni_fin <> 0) Then
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
        Dim paro13 As Integer = 0
        Dim paro14 As Integer = 0
        Dim paro15 As Integer = 0
        Dim paro16 As Integer = 0
        Dim paro17 As Integer = 0
        Dim paro18 As Integer = 0
        Dim paro19 As Integer = 0
        Dim paro20 As Integer = 0
        Dim paro21 As Integer = 0
        Dim paro22 As Integer = 0
        Dim paro23 As Integer = 0
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
                Case 2
                    If Not IsDBNull(dtg.Item(i, indice).Value) Then
                        If (dtg.Item(i, indice).Value <> "") Then
                            paro2 = dtg.Item(i, indice).Value
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
                Case 10
                    If Not IsDBNull(dtg.Item(i, indice).Value) Then
                        If (dtg.Item(i, indice).Value <> "") Then
                            paro10 = dtg.Item(i, indice).Value
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
                Case 14
                    If Not IsDBNull(dtg.Item(i, indice).Value) Then
                        If (dtg.Item(i, indice).Value <> "") Then
                            paro14 = dtg.Item(i, indice).Value
                        End If
                    End If
                Case 15
                    If Not IsDBNull(dtg.Item(i, indice).Value) Then
                        If (dtg.Item(i, indice).Value <> "") Then
                            paro15 = dtg.Item(i, indice).Value
                        End If
                    End If
                Case 16
                    If Not IsDBNull(dtg.Item(i, indice).Value) Then
                        If (dtg.Item(i, indice).Value <> "") Then
                            paro16 = dtg.Item(i, indice).Value
                        End If
                    End If
                Case 17
                    If Not IsDBNull(dtg.Item(i, indice).Value) Then
                        If (dtg.Item(i, indice).Value <> "") Then
                            paro17 = dtg.Item(i, indice).Value
                        End If
                    End If
                Case 18
                    If Not IsDBNull(dtg.Item(i, indice).Value) Then
                        If (dtg.Item(i, indice).Value <> "") Then
                            paro18 = dtg.Item(i, indice).Value
                        End If
                    End If
                Case 19
                    If Not IsDBNull(dtg.Item(i, indice).Value) Then
                        If (dtg.Item(i, indice).Value <> "") Then
                            paro19 = dtg.Item(i, indice).Value
                        End If
                    End If
                Case 20
                    If Not IsDBNull(dtg.Item(i, indice).Value) Then
                        If (dtg.Item(i, indice).Value <> "") Then
                            paro20 = dtg.Item(i, indice).Value
                        End If
                    End If
                Case 21
                    If Not IsDBNull(dtg.Item(i, indice).Value) Then
                        If (dtg.Item(i, indice).Value <> "") Then
                            paro21 = dtg.Item(i, indice).Value
                        End If
                    End If
                Case 22
                    If Not IsDBNull(dtg.Item(i, indice).Value) Then
                        If (dtg.Item(i, indice).Value <> "") Then
                            paro22 = dtg.Item(i, indice).Value
                        End If
                    End If
                Case 23
                    If Not IsDBNull(dtg.Item(i, indice).Value) Then
                        If (dtg.Item(i, indice).Value <> "") Then
                            paro23 = dtg.Item(i, indice).Value
                        End If
                    End If
            End Select
        Next
        sql = paro1 & " , " & paro2 & " , " & paro3 & " , " & paro4 & " , " & paro5 & " , " & paro6 & " , " & paro7 & " , " & paro8 & " , " & paro9 & " , " & paro10 & " , " & paro11 & "," & paro12 & ", " & paro13 & " , " & paro14 & " , " & paro15 & " , " & paro16 & " , " & paro17 & " , " & paro18 & " , " & paro19 & " , " & paro20 & " , " & paro21 & "," & paro22 & "," & paro23 & " )"
        Return sql
    End Function

    Private Sub cbo_turno_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_turno.SelectedIndexChanged
        If (cbo_turno.Text <> "Seleccione" And cbo_turno.Text <> "System.Data.DataRowView" And (cbo_turno.SelectedValue).ToString <> "System.Data.DataRowView") Then
            Dim horas As String = ""
            Dim texto As String = cbo_turno.Text
            For i = 0 To texto.Length - 1
                If IsNumeric(texto(i)) Then
                    horas += texto(i)
                End If
            Next
            h_prog = Convert.ToInt16(horas)
            cambio_h_prog()
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

 
    Private Sub chk_todos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_todos.CheckedChanged
        If (chk_todos.Checked = True) Then
            Dim sql As String = "Select nit,nombres   from V_nom_personal_Activo_con_maquila WHERE centro not in (4200) ORDER BY nombres "
            cbo_operario.DataSource = obj_Ing_prodLn.listar_datatable(sql, "CORSAN")
            cbo_operario.ValueMember = "nit"
            cbo_operario.DisplayMember = "nombres"
            cbo_operario.Text = "Seleccione"
        Else
            Dim sql As String = "Select nit,nombres  from V_nom_personal_Activo_con_maquila WHERE centro = 2300 ORDER BY nombres"
            cbo_operario.DataSource = obj_Ing_prodLn.listar_datatable(sql, "CORSAN")
            cbo_operario.ValueMember = "nit"
            cbo_operario.DisplayMember = "nombres"
            cbo_operario.Text = "Seleccione"
        End If
    End Sub
    Private Sub dtg_planilla_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtg_planilla.CellValueChanged
        If (carga_comp) Then
            Dim fila As Integer = e.RowIndex
            Dim col As String = dtg_planilla.Columns(e.ColumnIndex).Name
            If (col = "txt_un_ini" Or col = "txt_uni_fin") Then
                Dim uni_ini As Double = 0
                Dim uni_fin As Double = 0
                If (dtg_planilla.Item("txt_un_ini", fila).Value <> "") Then
                    uni_ini = dtg_planilla.Item("txt_un_ini", fila).Value
                End If
                If (dtg_planilla.Item("txt_uni_fin", fila).Value <> "") Then
                    uni_fin = dtg_planilla.Item("txt_uni_fin", fila).Value
                End If
                Dim h_trab = (uni_fin - uni_ini)
                If h_trab < 0 Then
                    dtg_planilla.Item("txt_h_trab", fila).Style.BackColor = Color.Red
                Else
                    dtg_planilla.Item("txt_h_trab", fila).Style.BackColor = Color.White
                End If
                If (h_trab > 12 Or h_trab > h_prog) Then
                    dtg_planilla.Item("txt_h_trab", fila).Style.BackColor = Color.Red
                Else
                    dtg_planilla.Item("txt_h_trab", fila).Style.BackColor = Color.Gainsboro
                End If
                dtg_planilla.Item("txt_h_trab", fila).Value = h_trab
                dtg_planilla.Item("txt_min_trab", fila).Value = h_trab * 60
            ElseIf (col = "txt_t_sin_just") Then
                If (dtg_planilla.Item("txt_t_sin_just", fila).Value < 0) Then
                    dtg_planilla.Item("txt_t_sin_just", fila).Style.BackColor = Color.Red
                Else
                    dtg_planilla.Item("txt_t_sin_just", fila).Style.BackColor = Color.Gainsboro
                End If
            ElseIf (col = "txt_efic") Then
                If (dtg_planilla.Item("txt_efic", fila).Value >= 100) Then
                    dtg_planilla.Item("txt_efic", fila).Style.BackColor = Color.Red
                Else
                    dtg_planilla.Item("txt_efic", fila).Style.BackColor = Color.Gainsboro
                End If
            ElseIf (col = "txt_p1" Or col = "txt_p2" Or col = "txt_p3" Or col = "txt_p4" Or col = "txt_p5" Or col = "txt_p6" Or col = "txt_p7" Or col = "txt_p8" Or col = "txt_p9" Or col = "txt_p10" Or col = "txt_p11" Or col = "txt_p12" Or col = "txt_p13" Or col = "txt_p14" Or col = "txt_p15" Or col = "txt_p16" Or col = "txt_p17" Or col = "txt_p18" Or col = "txt_p19" Or col = "txt_p20" Or col = "txt_p21" Or col = "txt_p22" Or col = "txt_p23" Or col = "txt_h_trab") Then
                calc_T_sin_just(fila)
            End If
        End If
    End Sub
    Public Sub cambio_h_prog()
        For i = 0 To dtg_planilla.RowCount - 1
            If (dtg_planilla.Item("id_maquina", i).Value <> 0 And dtg_planilla.Item("id_producto", i).Value <> 0) Then
                calc_T_sin_just(i)
                If ((dtg_planilla.Item("txt_uni_fin", i).Value - dtg_planilla.Item("txt_un_ini", i).Value) > h_prog) Then
                    dtg_planilla.Item("txt_h_trab", i).Style.BackColor = Color.Red
                Else
                    dtg_planilla.Item("txt_h_trab", i).Style.BackColor = Color.Gainsboro
                End If
            End If
        Next
    End Sub
    Private Sub calc_T_sin_just(ByVal fila As Integer)
        Dim paros As Double = 0
        Dim t_sin_just As Double = 0
        Dim h_trab As Double = (dtg_planilla.Item("txt_uni_fin", fila).Value - dtg_planilla.Item("txt_un_ini", fila).Value)
        paros = sumar_paros(fila, dtg_planilla)
        t_sin_just = ((h_prog - h_trab) * 60) - (paros) - 20
        If (t_sin_just < 0) Then
            dtg_planilla.Item("txt_t_sin_just", fila).Style.BackColor = Color.Red
        Else
            dtg_planilla.Item("txt_t_sin_just", fila).Style.BackColor = Color.Gainsboro
        End If
        dtg_planilla.Item("txt_t_sin_just", fila).Value = t_sin_just
    End Sub
    Private Sub dtg_planillaCellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtg_planilla.CellContentClick
        Dim fila As Integer = e.RowIndex
        Dim col As String = dtg_planilla.Columns(e.ColumnIndex).Name
        If (col = "btn_borrar") Then
            dtg_planilla.Rows.RemoveAt(e.RowIndex)
        ElseIf (col = txt_p4.Name) Then

        End If
    End Sub

    Private Sub ConsultaForma1ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConsultaForma1ToolStripMenuItem.Click
        Frm_consultar_punt.Show()
        Frm_consultar_punt.Activate()
    End Sub

    Private Sub ConsultaForma2ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FrmConsultar_punt2.Show()
        FrmConsultar_punt2.Activate()
    End Sub



    Private Sub llenarDtgParo4()
        dtgParo4.Rows.Add()
        dtgParo4.Item(col_cod_paro.Name, 0).Value = 0
        dtgParo4.Item(col_desc_paro.Name, 0).Value = "trinquete reventado"

        dtgParo4.Rows.Add()
        dtgParo4.Item(col_cod_paro.Name, 0).Value = 0
        dtgParo4.Item(col_desc_paro.Name, 0).Value = "trinquete reventado"

        dtgParo4.Rows.Add()
        dtgParo4.Item(col_cod_paro.Name, 0).Value = 0
        dtgParo4.Item(col_desc_paro.Name, 0).Value = "trinquete reventado"

        dtgParo4.Rows.Add()
        dtgParo4.Item(col_cod_paro.Name, 0).Value = 0
        dtgParo4.Item(col_desc_paro.Name, 0).Value = "trinquete reventado"

        dtgParo4.Rows.Add()
        dtgParo4.Item(col_cod_paro.Name, 0).Value = 0
        dtgParo4.Item(col_desc_paro.Name, 0).Value = "trinquete reventado"

        dtgParo4.Rows.Add()
        dtgParo4.Item(col_cod_paro.Name, 0).Value = 0
        dtgParo4.Item(col_desc_paro.Name, 0).Value = "trinquete reventado"

        dtgParo4.Rows.Add()
        dtgParo4.Item(col_cod_paro.Name, 0).Value = 0
        dtgParo4.Item(col_desc_paro.Name, 0).Value = "trinquete reventado"

        dtgParo4.Rows.Add()
        dtgParo4.Item(col_cod_paro.Name, 0).Value = 0
        dtgParo4.Item(col_desc_paro.Name, 0).Value = "trinquete reventado"

        dtgParo4.Rows.Add()
        dtgParo4.Item(col_cod_paro.Name, 0).Value = 0
        dtgParo4.Item(col_desc_paro.Name, 0).Value = "trinquete reventado"

        dtgParo4.Rows.Add()
        dtgParo4.Item(col_cod_paro.Name, 0).Value = 0
        dtgParo4.Item(col_desc_paro.Name, 0).Value = "trinquete reventado"

        dtgParo4.Rows.Add()
        dtgParo4.Item(col_cod_paro.Name, 0).Value = 0
        dtgParo4.Item(col_desc_paro.Name, 0).Value = "trinquete reventado"

        dtgParo4.Rows.Add()
        dtgParo4.Item(col_cod_paro.Name, 0).Value = 0
        dtgParo4.Item(col_desc_paro.Name, 0).Value = "trinquete reventado"

        dtgParo4.Rows.Add()
        dtgParo4.Item(col_cod_paro.Name, 0).Value = 0
        dtgParo4.Item(col_desc_paro.Name, 0).Value = "trinquete reventado"

        dtgParo4.Rows.Add()
        dtgParo4.Item(col_cod_paro.Name, 0).Value = 0
        dtgParo4.Item(col_desc_paro.Name, 0).Value = "trinquete reventado"

        dtgParo4.Rows.Add()
        dtgParo4.Item(col_cod_paro.Name, 0).Value = 0
        dtgParo4.Item(col_desc_paro.Name, 0).Value = "trinquete reventado"

        dtgParo4.Rows.Add()
        dtgParo4.Item(col_cod_paro.Name, 0).Value = 0
        dtgParo4.Item(col_desc_paro.Name, 0).Value = "trinquete reventado"

        dtgParo4.Rows.Add()
        dtgParo4.Item(col_cod_paro.Name, 0).Value = 0
        dtgParo4.Item(col_desc_paro.Name, 0).Value = "trinquete reventado"

        dtgParo4.Rows.Add()
        dtgParo4.Item(col_cod_paro.Name, 0).Value = 0
        dtgParo4.Item(col_desc_paro.Name, 0).Value = "trinquete reventado"

    End Sub
End Class