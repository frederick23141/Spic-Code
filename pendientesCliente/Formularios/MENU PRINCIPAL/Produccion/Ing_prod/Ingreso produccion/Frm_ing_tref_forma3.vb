Imports System.Configuration
Imports logicaNegocios
Imports System.IO
Imports Microsoft.Office.Interop
#Disable Warning BC40056 ' El espacio de nombres o el tipo especificado en el 'System.Data.SqlServerCe' Imports no contienen ningún miembro público o no se encuentran. Asegúrese de que el espacio de nombres o el tipo se hayan definido y de que contengan al menos un miembro público. Asegúrese de que el nombre del elemento importado no use ningún alias.
Imports System.Data.SqlServerCe
#Enable Warning BC40056 ' El espacio de nombres o el tipo especificado en el 'System.Data.SqlServerCe' Imports no contienen ningún miembro público o no se encuentran. Asegúrese de que el espacio de nombres o el tipo se hayan definido y de que contengan al menos un miembro público. Asegúrese de que el nombre del elemento importado no use ningún alias.
Public Class Frm_ing_emp_punt
    Public id_modificar As Integer = 0
    Private obj_Ing_prodLn As New Ing_prodLn
    Public carga_comp As Boolean = False
    Public operario As Double = 0
    Private objopSimplesLn As New Op_simpesLn
    Private nom_modulo As String
    Public consec_ppal As Double = 0
    Public consec_det As Double = 0
    Public Sub Main(ByVal nom_modulo As String, ByVal permiso As String)
        Me.nom_modulo = nom_modulo
        If (permiso <> "ADMIN") Then
            btnContCambios.Visible = False
        End If
    End Sub
    Private Sub btnContCambios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnContCambios.Click
        FrmAuditCambios.Show()
        FrmAuditCambios.Main(nom_modulo)
        FrmAuditCambios.WindowState = 2
    End Sub
    Private Sub Frm_prueba_tref3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim sql As String = "select Codigo,Descripcion from J_turnos  "
        Dim dt As DataTable = obj_Ing_prodLn.listar_datatable(sql, "PRODUCCION")
        Dim dr As DataRow = dt.NewRow
        dr("Codigo") = 0
        dr("Descripcion") = "Seleccione"
        dt.Rows.Add(dr)
        cbo_fecha.Value = Now.AddDays(-1)
        cbo_turno.DataSource = dt
        cbo_turno.ValueMember = "Codigo"
        cbo_turno.DisplayMember = "Descripcion"
        cbo_turno.SelectedValue = 0

        sql = "Select nit,nombres  from V_nom_personal_Activo_con_maquila WHERE centro = 2100 ORDER BY nombres "
        dt = New DataTable
        dt = obj_Ing_prodLn.listar_datatable(sql, "CORSAN")
        dr = dt.NewRow
        dr("nit") = 0
        dr("nombres") = "Seleccione"
        dt.Rows.Add(dr)
        cbo_operario.DataSource = dt
        cbo_operario.ValueMember = "nit"
        cbo_operario.DisplayMember = "nombres"
        cbo_operario.SelectedValue = 0
        cargar_cbo_dtg()
        carga_comp = True

    End Sub
    Private Sub cargar_cbo_dtg()
        Dim sql As String = ""
        Dim dt As DataTable
        Dim row As DataRow
        sql = "select  codigoM,nombre   from j_Maquinas where TipoMaquina = 1 AND activa = 1 "
        dt = obj_Ing_prodLn.listar_datatable(sql, "PRODUCCION")
        row = dt.NewRow
        row("codigoM") = 0
        row("nombre") = ""
        dt.Rows.Add(row)
        id_maquina.DataSource = dt
        id_maquina.ValueMember = "codigoM"
        id_maquina.DisplayMember = "nombre"

        sql = "SELECT codigo,descripcion  FROM J_destino_tref "
        cbo_destino.DataSource = obj_Ing_prodLn.listar_datatable(sql, "PRODUCCION")
        cbo_destino.ValueMember = "codigo"
        cbo_destino.DisplayMember = "descripcion"

        For i = 0 To 6
            dtg_planilla.Rows.Add()
        Next

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
        FrmConsTreForma3.Show()
    End Sub
    Private Sub limpiar()
        txtNotas.Text = ""
        txtKilEs.Text = ""
        txtKilPod.Text = ""
        txtMprog.Text = ""
        txtMtrab.Text = ""
        txtTSinJust.Text = ""
        txtEfic.Text = ""
        cbo_operario.Text = "Seleccione"
        cbo_turno.Text = "Seleccione"
        dtg_planilla.Rows.Clear()
        txt_estado_modificar.Text = ""
        id_modificar = 0
        consec_ppal = 0
        consec_det = 0
        cargar_cbo_dtg()
    End Sub
    Private Sub dtg_planilla_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtg_planilla.CellValueChanged
        If (carga_comp) Then
            Dim fila As Integer = e.RowIndex
            Dim col As String = dtg_planilla.Columns(e.ColumnIndex).Name

            If (col = "txt_hora_ini" Or col = "txt_hora_fin") Then
                Dim hIni As Date
                Dim hFin As Date
                Dim m_prog As Double = 0
                If (col = "txt_hora_ini") Then
                    hIni = dtg_planilla.Item("txt_hora_ini", fila).Value
                    If (dtg_planilla.Item("txt_hora_fin", fila).Value <> "") Then
                        hFin = dtg_planilla.Item("txt_hora_fin", fila).Value
                    End If
                Else
                    If (dtg_planilla.Item("txt_hora_ini", fila).Value <> "") Then
                        hIni = dtg_planilla.Item("txt_hora_ini", fila).Value
                    End If
                    hFin = dtg_planilla.Item("txt_hora_fin", fila).Value
                End If
                m_prog = DateDiff(DateInterval.Minute, hIni, hFin)
                dtg_planilla.Item("colMprog", fila).Value = m_prog
                calc_esperada(fila)
                If (dtg_planilla.Item("col_m_trab", fila).Value > m_prog) Then
                    dtg_planilla.Item("col_m_trab", fila).Style.BackColor = Color.Red
                Else
                    dtg_planilla.Item("col_m_trab", fila).Style.BackColor = Color.Gainsboro
                End If
                calc_T_sin_just(fila)
            ElseIf (col = "txt_un_ini" Or col = "txt_uni_fin") Then
                Dim uni_ini As String = ""
                Dim uni_fin As String = ""
                If IsNumeric(dtg_planilla.Item("txt_un_ini", fila).Value) Then
                    uni_ini = dtg_planilla.Item("txt_un_ini", fila).Value
                End If
                If IsNumeric(dtg_planilla.Item("txt_uni_fin", fila).Value) Then
                    uni_fin = dtg_planilla.Item("txt_uni_fin", fila).Value
                End If
                Dim m_trab = obj_Ing_prodLn.calcularHorometro(uni_ini, uni_fin)
                If (m_trab > 12 * 60 Or m_trab < 0 Or m_trab > dtg_planilla.Item("colMprog", fila).Value) Then
                    dtg_planilla.Item("col_m_trab", fila).Style.BackColor = Color.Red
                Else
                    dtg_planilla.Item("col_m_trab", fila).Style.BackColor = Color.Gainsboro
                End If
                dtg_planilla.Item("col_m_trab", fila).Value = m_trab
                calc_T_sin_just(fila)
            ElseIf (col = "txtAlamb" Or col = "txt_repr") Then
                dtg_planilla.Item(col, fila).Value = objopSimplesLn.operacionSumaDtg(dtg_planilla.Item(col, fila).Value)
                Dim alamb As Double = dtg_planilla.Item("txtAlamb", fila).Value
                Dim repr As Double = dtg_planilla.Item("txt_repr", fila).Value
                dtg_planilla.Item("colKilProd", fila).Value = alamb + repr
            ElseIf (col = "colKilProd" Or col = "colKilEsp") Then
                consolidar(fila, col)
                dtg_planilla.Item("col_efic", fila).Value = (dtg_planilla.Item("colKilProd", fila).Value / dtg_planilla.Item("colKilEsp", fila).Value) * 100
            ElseIf (col = "col_efic") Then
                If (dtg_planilla.Item("col_efic", fila).Value > 100 Or dtg_planilla.Item("col_efic", fila).Value < 0) Then
                    dtg_planilla.Item("col_efic", fila).Style.BackColor = Color.Red
                Else
                    dtg_planilla.Item("col_efic", fila).Style.BackColor = Color.Gainsboro
                End If
            ElseIf (col = "txt_p0" Or col = "txt_p1" Or col = "txt_p2" Or col = "txt_p3" Or col = "txt_p4" Or col = "txt_p5" Or col = "txt_p6" Or col = "txt_p7" Or col = "txt_p8" Or col = "txt_p9" Or col = "txt_p10" Or col = "txt_p11" Or col = "txt_p12" Or col = "txt_p13") Then
                dtg_planilla.Item(col, fila).Value = objopSimplesLn.operacionSumaDtg(dtg_planilla.Item(col, fila).Value)
                calc_T_sin_just(fila)
            ElseIf (col = "txt_calibre" Or col = "id_maquina" Or col = "colVel") Then
                If (dtg_planilla.Item("colMprog", fila).Value <> Nothing And dtg_planilla.Item("txt_calibre", fila).Value <> Nothing) Then
                    If (dtg_planilla.Item("colMprog", fila).Value.ToString <> "" And dtg_planilla.Item("txt_calibre", fila).Value.ToString <> "" And dtg_planilla.Item("colVel", fila).Value.ToString <> "") Then
                        calc_esperada(fila)
                    End If
                End If
            End If
            consolidar(fila, col)
        End If

    End Sub

    Private Sub calc_T_sin_just(ByVal fila As Integer)
        Dim paros As Double = 0
        Dim t_sin_just As Double = 0
        paros = sumar_paros(fila, dtg_planilla)
        t_sin_just = ((dtg_planilla.Item("colMprog", fila).Value - dtg_planilla.Item("col_m_trab", fila).Value)) - (paros)
        If (t_sin_just < 0 And IsNumeric(dtg_planilla.Item("col_t_sin_just", fila).Value)) Then
            dtg_planilla.Item("col_t_sin_just", fila).Style.BackColor = Color.Red
        Else
            dtg_planilla.Item("col_t_sin_just", fila).Style.BackColor = Color.Gainsboro
        End If
        dtg_planilla.Item("col_t_sin_just", fila).Value = t_sin_just
    End Sub
    Public Function sumar_paros(ByVal indice As Integer, ByVal dtg As DataGridView) As Double
        Dim sum As Double = 0
        For i = dtg.Columns("txt_p0").Index To dtg.ColumnCount - 1
            If Not (IsNothing(dtg.Item(i, indice).Value)) Then
                If (dtg.Item(i, indice).Value.ToString <> "") Then
                    sum = sum + dtg.Item(i, indice).Value
                End If
            End If
        Next
        Return sum
    End Function
    Public Sub calc_esperada(ByVal fila As Integer)
        If (dtg_planilla.Item("id_maquina", fila).Value <> "0" Or dtg_planilla.Item(col_cod_maquina.Name, fila).Value <> Nothing) Then
            Dim velocidad As Double = dtg_planilla.Item("colVel", fila).Value
            Dim diametro As Double = Convert.ToDouble(dtg_planilla.Item("txt_calibre", fila).Value)
            dtg_planilla.Item("colKilEsp", fila).Value = (((velocidad * (diametro ^ 2)) * 22.2) * ((dtg_planilla.Item("colMprog", fila).Value) / 60))
        End If
    End Sub
    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If (cbo_operario.Text <> "Seleccione" And cbo_turno.Text <> "Seleccione") Then
            guardar()
            '  limpiar()
        Else
            MessageBox.Show("Verifique que todos los items del pedido estem llenos! ", "Campos", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Private Sub dtg_planillaCellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtg_planilla.CellContentClick
        Dim fila As Integer = e.RowIndex
        Dim col As String = dtg_planilla.Columns(e.ColumnIndex).Name
        If (col = "btn_borrar") Then
            dtg_planilla.Rows.RemoveAt(e.RowIndex)
        End If
    End Sub
    Private Sub guardar()
        Dim sql_detele As String = ""
        Dim listSql As New List(Of Object)
        Dim hora_ini As String
        Dim hora_fin As String
        Dim und_ini As Double = 0
        Dim und_fin As Double = 0
        Dim resp As Boolean = 0
        Dim fecha As String = objopSimplesLn.cambiarFormatoFecha(cbo_fecha.Value.Date)
        Dim turno As Integer = cbo_turno.SelectedValue
        Dim maquina As Integer = 0
        Dim calibre As Double = 0
        Dim destino As Double = 0
        Dim min_trab As Double = 0
        Dim min_prog As Double = 0
        Dim kil_esp As Double = 0
        Dim alamb As Double = 0
        Dim rep As Double = 0
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
        Dim paro0 As Integer = 0
        Dim paro11 As Integer = 0
        Dim paro12 As Integer = 0
        Dim paro13 As Integer = 0
        Dim notas As String = txtNotas.Text
        Dim sql_total As String = ""
        Dim velocidad As Double = 0
        Dim sql_gral As String = ""
        If (id_modificar <> 0) Then
            sql_detele = "DELETE FROM J_prod_tref_completo WHERE id = " & id_modificar
            listSql.Add(sql_detele)
            If (consec_ppal <> 0) Then
                sql_gral = "INSERT INTO J_prod_tref_completo " & _
                                   "(consecutivo,id_detalle,nit,fecha,turno,notas,maquina,cod_destino,h_ini,h_fin,diametro,alambron,reproceso,und_ini,und_fin,velocidad,Min_trab " & _
                                   ",paro0,Paro1,paro2,paro3,paro4,paro5,paro6,paro7,paro8,paro9,paro10,paro11,paro12,paro13) " & _
                                        "  VALUES(" & consec_ppal & "," & consec_det & "," & operario & ",'" & fecha & "'," & turno & ",'" & notas & "', "

            Else
                sql_gral = "INSERT INTO J_prod_tref_completo " & _
                                   "(nit,fecha,turno,notas,maquina,cod_destino,h_ini,h_fin,diametro,alambron,reproceso,und_ini,und_fin,velocidad,Min_trab " & _
                                   ",paro0,Paro1,paro2,paro3,paro4,paro5,paro6,paro7,paro8,paro9,paro10,paro11,paro12,paro13) " & _
                                        "  VALUES( " & operario & ",'" & fecha & "'," & turno & ",'" & notas & "', "

            End If
        Else
            sql_gral = "INSERT INTO J_prod_tref_completo " & _
                                   "(nit,fecha,turno,notas,maquina,cod_destino,h_ini,h_fin,diametro,alambron,reproceso,und_ini,und_fin,velocidad,Min_trab " & _
                                   ",paro0,Paro1,paro2,paro3,paro4,paro5,paro6,paro7,paro8,paro9,paro10,paro11,paro12,paro13) " & _
                                        "  VALUES( " & operario & ",'" & fecha & "'," & turno & ",'" & notas & "', "
        End If


        If (verificar_planilla(dtg_planilla)) Then
            For i = 0 To dtg_planilla.RowCount - 1
                If (id_modificar = 0) Then
                    maquina = dtg_planilla.Item("id_maquina", i).Value
                    destino = dtg_planilla("cbo_destino", i).Value
                Else
                    maquina = dtg_planilla.Item(col_cod_maquina.Name, i).Value
                    destino = dtg_planilla.Item(col_cod_destino.Name, i).Value
                End If
                hora_ini = Format(Convert.ToDateTime(dtg_planilla(txt_hora_ini.Name, i).Value), "yyyy-MM-dd HH:mm:ss")
                hora_fin = Format(Convert.ToDateTime(dtg_planilla(txt_hora_fin.Name, i).Value), "yyyy-MM-dd HH:mm:ss")
                velocidad = dtg_planilla.Item(colVel.Name, i).Value
                und_ini = dtg_planilla(txt_un_ini.Name, i).Value
                und_fin = dtg_planilla(txt_uni_fin.Name, i).Value
                calibre = dtg_planilla("txt_calibre", i).Value
                min_trab = dtg_planilla("col_m_trab", i).Value
                min_prog = dtg_planilla("colMprog", i).Value
                alamb = dtg_planilla("txtAlamb", i).Value
                kil_esp = dtg_planilla("colKilEsp", i).Value
                rep = dtg_planilla("txt_repr", i).Value
                paro0 = dtg_planilla("txt_p0", i).Value
                paro1 = dtg_planilla("txt_p1", i).Value
                paro2 = dtg_planilla("txt_p2", i).Value
                paro3 = dtg_planilla("txt_p3", i).Value
                paro4 = dtg_planilla("txt_p4", i).Value
                paro5 = dtg_planilla("txt_p5", i).Value
                paro6 = dtg_planilla("txt_p6", i).Value
                paro7 = dtg_planilla("txt_p7", i).Value
                paro8 = dtg_planilla("txt_p8", i).Value
                paro9 = dtg_planilla("txt_p9", i).Value
                paro10 = dtg_planilla("txt_p10", i).Value
                paro11 = dtg_planilla("txt_p11", i).Value
                paro12 = dtg_planilla("txt_p12", i).Value
                paro13 = dtg_planilla("txt_p13", i).Value
                If ((maquina <> 0 And calibre <> 0 And destino <> 0 And min_trab <> 0)) Then
                    sql_total = sql_gral & maquina & "," & destino & ",'" & hora_ini & "','" & hora_fin & "'," & calibre & "," & alamb & "," & rep & "," & und_ini & "," & und_fin & "," & velocidad & "," & min_trab & "," & _
                        paro0 & "," & paro1 & "," & paro2 & "," & paro3 & "," & paro4 & "," & paro5 & "," & paro6 & "," & paro7 & "," & paro8 & "," & paro9 & "," & paro10 & "," & paro11 & "," & paro12 & "," & paro13 & ")"
                    listSql.Add(sql_total)
                End If
            Next
            If (listSql.Count > 0) Then
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
    Public Function verificar_planilla(ByVal dtg As DataGridView) As Boolean
        Dim resp As Boolean = True
        Dim maquina As Integer = 0
        Dim calibre As Double = 0
        Dim destino As Double = 0
        Dim min_trab As Double = 0
        Dim min_prog As Double = 0
        Dim k_esp As Double = 0
        Dim k_prod As Double = 0
        ' h_trab = (dtg_planilla.Item("txt_uni_fin", i).Value - dtg_planilla.Item("txt_un_ini", i).Value)
        For i = 0 To dtg_planilla.RowCount - 1
            If (dtg_planilla.Item("id_maquina", i).Value <> Nothing Or dtg_planilla("cbo_destino", i).Value <> Nothing Or dtg_planilla("txt_calibre", i).Value <> Nothing) Then
                If (id_modificar = 0) Then
                    maquina = dtg_planilla.Item("id_maquina", i).Value
                    destino = dtg_planilla("cbo_destino", i).Value
                Else
                    maquina = dtg_planilla.Item(col_cod_maquina.Name, i).Value
                    destino = dtg_planilla.Item(col_cod_destino.Name, i).Value
                End If

                calibre = dtg_planilla("txt_calibre", i).Value


                min_trab = dtg_planilla("col_m_trab", i).Value
                min_prog = dtg_planilla("colMprog", i).Value
                k_esp = dtg_planilla("colKilProd", i).Value
                k_prod = dtg_planilla("colKilesp", i).Value
                If ((maquina <> 0 And calibre <> 0 And destino <> 0 And min_trab <> 0)) Then
                    If (maquina = 0 Or calibre = 0 Or destino = 0 Or min_trab = 0 Or min_prog = 0 Or k_esp = 0 Or k_prod = 0) Then
                        resp = False
                        i = dtg_planilla.RowCount - 1
                    End If
                End If
            Else
                'resp = False
                i = dtg_planilla.RowCount - 1
            End If
        Next
        Return resp
    End Function

    Private Sub cbo_operario_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_operario.SelectedIndexChanged
        If (carga_comp) Then
            operario = cbo_operario.SelectedValue
        End If
    End Sub
    Private Sub consolidar(ByVal fila As Integer, ByVal col As String)
        If (col = "colMprog") Then
            If (dtg_planilla.Item(col, fila).Value <> Nothing) Then
                If (dtg_planilla.Item(col, fila).Value.ToString <> "") Then
                    txtMprog.Text = Format(sumarCol("colMprog"), "N0")
                    If (txtMtrab.Text <> "" And txtMprog.Text <> "") Then
                        If (Convert.ToDouble(txtMtrab.Text) >= Convert.ToDouble(txtMprog.Text)) Then
                            txtMprog.BackColor = Color.Red
                            txtMtrab.BackColor = Color.Red
                        Else
                            txtMprog.BackColor = Color.White
                            txtMtrab.BackColor = Color.White
                        End If
                    End If

                End If
            End If
        ElseIf (col = "col_m_trab") Then
            If (dtg_planilla.Item(col, fila).Value <> Nothing) Then
                If (dtg_planilla.Item(col, fila).Value.ToString <> "") Then
                    txtMtrab.Text = Format(sumarCol("col_m_trab"), "N0")
                    If (txtMtrab.Text <> "" And txtMprog.Text <> "") Then
                        If (Convert.ToDouble(txtMtrab.Text) >= Convert.ToDouble(txtMprog.Text)) Then
                            txtMtrab.BackColor = Color.Red
                            txtMprog.BackColor = Color.Red
                        Else
                            txtMtrab.BackColor = Color.White
                            txtMprog.BackColor = Color.White
                        End If
                    End If
                End If
            End If
        ElseIf (col = "colKilProd") Then
            If (dtg_planilla.Item(col, fila).Value <> Nothing) Then
                If (dtg_planilla.Item(col, fila).Value.ToString <> "") Then
                    txtKilPod.Text = Format(sumarCol("colKilProd"), "N0")
                    If (txtKilPod.Text <> "" And txtKilEs.Text <> "") Then
                        If (Convert.ToDouble(txtKilPod.Text) >= Convert.ToDouble(txtKilEs.Text)) Then
                            txtKilPod.BackColor = Color.Red
                            txtKilEs.BackColor = Color.Red
                        Else
                            txtKilPod.BackColor = Color.White
                            txtKilEs.BackColor = Color.White
                        End If
                    End If

                End If
            End If
        ElseIf (col = "colKilEsp") Then
            If (dtg_planilla.Item(col, fila).Value <> Nothing) Then
                If (dtg_planilla.Item(col, fila).Value.ToString <> "") Then
                    If (dtg_planilla.Item(col, fila).Value.ToString <> "") Then
                        txtKilEs.Text = Format(sumarCol("colKilEsp"), "N0")
                        If (txtKilPod.Text <> "" And txtKilEs.Text <> "") Then
                            If (Convert.ToDouble(txtKilPod.Text) >= Convert.ToDouble(txtKilEs.Text)) Then
                                txtKilPod.BackColor = Color.Red
                                txtKilEs.BackColor = Color.Red
                            Else
                                txtKilPod.BackColor = Color.White
                                txtKilEs.BackColor = Color.White
                            End If
                        End If
                    End If

                End If
            End If
        ElseIf (col = "col_t_sin_just") Then
            If (dtg_planilla.Item(col, fila).Value.ToString <> "") Then
                txtTSinJust.Text = Format(sumarCol("col_t_sin_just"), "N0")
                If (Convert.ToDouble(txtTSinJust.Text) <= 0) Then
                    txtTSinJust.BackColor = Color.Red
                Else
                    txtTSinJust.BackColor = Color.White
                End If
            End If
        ElseIf (col = "col_efic") Then
            If (dtg_planilla.Item(col, fila).Value.ToString <> "") Then
                If (txtKilPod.Text <> "" And txtKilEs.Text <> "") Then
                    txtEfic.Text = Format(((Convert.ToDouble(txtKilPod.Text) / Convert.ToDouble(txtKilEs.Text)) * 100), "N1")
                    If (Convert.ToDouble(txtEfic.Text) >= 100) Then
                        txtEfic.BackColor = Color.Red
                    Else
                        txtEfic.BackColor = Color.White
                    End If
                End If
            End If
        End If


    End Sub
    Private Function sumarCol(ByVal col As String) As Double
        Dim sum As Double = 0
        For i = 0 To dtg_planilla.RowCount - 1
            If (dtg_planilla.Item(col, i).Value <> Nothing) Then
                If (dtg_planilla.Item(col, i).Value.ToString <> "") Then
                    sum += dtg_planilla.Item(col, i).Value
                End If
            End If
        Next
        Return sum
    End Function

    Private Sub chk_todos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_todos.CheckedChanged
        Dim sql As String = ""
        If (chk_todos.Checked) Then
            sql = "Select nit,nombres   from V_nom_personal_Activo_con_maquila WHERE centro not in (4200) ORDER BY nombres "
        Else
            sql = "Select nit,nombres   from V_nom_personal_Activo_con_maquila WHERE centro  = 2100 ORDER BY nombres "
        End If
        cbo_operario.DataSource = obj_Ing_prodLn.listar_datatable(sql, "CORSAN")
        cbo_operario.ValueMember = "nit"
        cbo_operario.DisplayMember = "nombres"
        cbo_operario.Text = "Seleccione"
    End Sub

    Private Sub dtg_planilla_DataError(sender As System.Object, e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dtg_planilla.DataError

    End Sub
    Public Sub cargar_resultados_modificacion()
        If Not IsNothing(dtg_planilla.Item(id_maquina.Name, 0).Value) Then
            Dim hIni As Date = dtg_planilla.Item("txt_hora_ini", 0).Value
            Dim hFin As Date = dtg_planilla.Item("txt_hora_fin", 0).Value
            Dim uni_fin As Double = dtg_planilla.Item("txt_uni_fin", 0).Value
            Dim uni_ini As Double = dtg_planilla.Item("txt_un_ini", 0).Value
            Dim alamb As Double = dtg_planilla.Item("txtAlamb", 0).Value
            Dim repr As Double = dtg_planilla.Item("txt_repr", 0).Value
            Dim m_prog As Double = DateDiff(DateInterval.Minute, hIni, hFin)
            Dim m_trab = obj_Ing_prodLn.calcularHorometro(uni_ini, uni_fin)
            dtg_planilla.Item("col_m_trab", 0).Value = m_trab
            dtg_planilla.Item("colMprog", 0).Value = m_prog
            dtg_planilla.Item("colKilProd", 0).Value = alamb + repr
            calc_esperada(0)
            calc_T_sin_just(0)
            dtg_planilla.Item("col_efic", 0).Value = (dtg_planilla.Item("colKilProd", 0).Value / dtg_planilla.Item("colKilEsp", 0).Value) * 100
        End If
    End Sub

End Class
