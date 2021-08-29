Imports logicaNegocios
Public Class Frm_reglas_comisiones
    Private objOpSimplesLn As New Op_simpesLn
    Dim usuario As String
    Dim numero As Integer = 0
    Dim fila_select As Integer = 0
    Dim carga_comp As Boolean = False
    Public Sub main(ByVal usuario As String)
        carga_comp = True
        Me.usuario = usuario
        Dim dt As New DataTable
        Dim dr As DataRow
        Dim sql As String = "SELECT  id,regla FROM J_reglas_tipo_cumplimiento WHERE regla not like '%ventas%'"
        dtg_tipo_cumplimiento.DataSource = objOpSimplesLn.listar_datatable(sql, "CORSAN")

        sql = "SELECT CAST(vendedor AS varchar(25))As vendedor FROM v_vendedores WHERE vendedor >=1001 AND vendedor <=1099 AND bloqueo = 0  ORDER BY vendedor "
        dt = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        dr = dt.NewRow
        dr("vendedor") = "Seleccione"
        dt.Rows.Add(dr)
        cbo_vend.DataSource = dt
        cbo_vend.DisplayMember = "vendedor"
        cbo_vend.ValueMember = "vendedor"
        cbo_vend.SelectedValue = "Seleccione"

        dt = New DataTable
        sql = "SELECT usuario,nombres FROM jjv_usuarios WHERE cargo in(42,41)  ORDER BY nombres "
        dt = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        dr = dt.NewRow
        dr("nombres") = "Seleccione"
        dr("usuario") = "Seleccione"
        dt.Rows.Add(dr)
        cbo_coordinador.DataSource = dt
        cbo_coordinador.DisplayMember = "nombres"
        cbo_coordinador.ValueMember = "usuario"
        cbo_coordinador.SelectedValue = "Seleccione"

        dt = New DataTable
        sql = "SELECT usuario,nombres FROM jjv_usuarios WHERE cargo IN(17,78)  ORDER BY nombres "
        dt = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        dr = dt.NewRow
        dr("nombres") = "Seleccione"
        dr("usuario") = "Seleccione"
        dt.Rows.Add(dr)
        cbo_dir.DataSource = dt
        cbo_dir.DisplayMember = "nombres"
        cbo_dir.ValueMember = "usuario"
        cbo_dir.SelectedValue = "Seleccione"

        dt = New DataTable
        sql = "SELECT tipo FROM J_reglas_comisiones_tipo_cumpl"
        dt = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        cbo_tipo_cumpl_cor.DataSource = dt
        cbo_tipo_cumpl_cor.DisplayMember = "tipo"
        cbo_tipo_cumpl_cor.ValueMember = "tipo"

        dt = New DataTable
        dt = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        cbo_tipo_cumpl_dir.DataSource = dt
        cbo_tipo_cumpl_dir.DisplayMember = "tipo"
        cbo_tipo_cumpl_dir.ValueMember = "tipo"


        dtg_reglas_vtas.Rows.Add()
        dtg_rec_vendedores.Rows.Add()
        dtg_reglas_dir.Rows.Add()
        dtg_reglas_coor.Rows.Add()


        consultar()

    End Sub
    Private Sub Frm_comisiones_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        tab_reglas.SelectedTab = tab_coor
        tab_reglas.SelectedTab = tab_dir
        tab_reglas.SelectedTab = tab_vendedores
        dtg_reglas_coor.AutoGenerateColumns = False
    End Sub
    Private Sub guardar_vendedor()
        cbo_vend.Focus()
        If (validar_vend()) Then
            If (cbo_vend.Text <> "Seleccione") Then
                dtg_reglas_vtas.CurrentCell = Nothing
                Dim listSql As New List(Of Object)
                Dim sql As String = ""
                Dim vendedor As Integer = cbo_vend.SelectedValue
                Dim mensaje As String = ""
                Dim sqlVendedor As String = "SELECT usuario FROM J_reglas_comisiones WHERE usuario ='" & vendedor & "' AND anulado is null"
                If (numero <> 0) Then
                    sql = "DELETE FROM J_reglas_comisiones_det_recaudos WHERE numero = " & numero
                    listSql.Add(sql)
                    sql = "DELETE FROM J_reglas_comisiones_det_vtas WHERE numero = " & numero
                    listSql.Add(sql)
                    sql = "DELETE FROM J_reglas_comisiones WHERE numero = " & numero
                    listSql.Add(sql)
                Else
                    If (objOpSimplesLn.consultarVal(sqlVendedor) = "") Then
                        Dim sNumero As String = objOpSimplesLn.consultarVal("SELECT MAX (numero)+1 FROM J_reglas_comisiones")
                        If (sNumero = "") Then
                            numero = 1
                        Else
                            numero = sNumero
                        End If
                    Else
                        MessageBox.Show("Ya existe una regla para este vendedor,busque lo en la parte de abajo y modifique la regla.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                End If

                sql = "INSERT INTO J_reglas_comisiones(numero,usuario,tipo) " & _
                                        "VALUES(" & numero & "," & vendedor & "," & 1 & ")"
                listSql.Add(sql)

                For i = 0 To dtg_rec_vendedores.RowCount - 1
                    If (dtg_rec_vendedores.Rows(i).Visible = True) Then
                        sql = "INSERT INTO J_reglas_comisiones_det_recaudos(numero,detalle,id_tipo_cumpl,porc_pagar) " & _
                                                            "VALUES(" & numero & "," & i & "," & dtg_rec_vendedores.Item(col_id_tipo_rec.Name, i).Value & "," & dtg_rec_vendedores.Item(col_porc_rec.Name, i).Value & ")"
                        listSql.Add(sql)
                    End If
                Next
                Dim todo As String = ""
                For i = 0 To dtg_reglas_vtas.RowCount - 1
                    If (dtg_reglas_vtas.Rows(i).Visible = True) Then
                        If (dtg_reglas_vtas.Item(col_todo.Name, i).Value) Then
                            todo = "S"
                        Else
                            todo = "N"
                        End If
                        sql = "INSERT INTO J_reglas_comisiones_det_vtas (numero,detalle,porc_cump,porc_pagar,sobre_codigo,menos_codigo,todo) VALUES " & _
                               "(" & numero & "," & i & "," & dtg_reglas_vtas(col_porc_cumpl_vtas.Name, i).Value & "," & dtg_reglas_vtas(col_porc_pagar_vtas.Name, i).Value & ",'" & dtg_reglas_vtas(col_cod_a_pagar_vtas.Name, i).Value & "','" & dtg_reglas_vtas(col_cod_menos_vtas.Name, i).Value & "','" & todo & "')"
                        listSql.Add(sql)
                    End If
                Next
                mensaje = "creo"

                If (objOpSimplesLn.ExecuteSqlTransaction(listSql)) Then
                    MessageBox.Show("La regla se " & mensaje & " en forma correcta", "Correcto!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    nuevo_vend()
                    consultar()
                Else
                    MessageBox.Show("Error al crear la regla, comuniquese con el area de sistemas", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                MessageBox.Show("Seleccione un vendedor", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        End If
    End Sub
    Private Sub guardar_coor()
        cbo_coordinador.Focus()
        If (validar_coor()) Then
            If (cbo_coordinador.Text <> "Seleccione") Then
                Dim listSql As New List(Of Object)
                Dim sql As String = ""
                Dim usuario As String = cbo_coordinador.SelectedValue
                Dim mensaje As String = ""
                Dim sqlVendedor As String = "SELECT usuario FROM J_reglas_comisiones WHERE usuario ='" & usuario & "' AND anulado is null"
                If (numero <> 0) Then
                    sql = "DELETE FROM J_reglas_comisiones_det_coor WHERE numero = " & numero
                    listSql.Add(sql)
                    sql = "DELETE FROM J_reglas_comisiones WHERE numero = " & numero
                    listSql.Add(sql)
                Else
                    If (objOpSimplesLn.consultarVal(sqlVendedor) = "") Then
                        Dim sNumero As String = objOpSimplesLn.consultarVal("SELECT MAX (numero)+1 FROM J_reglas_comisiones")
                        If (sNumero = "") Then
                            numero = 1
                        Else
                            numero = sNumero
                        End If
                    Else
                        MessageBox.Show("Ya existe una regla para este usuario,busque lo en la parte de abajo y modifique la regla.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                End If
                sql = "INSERT INTO J_reglas_comisiones(numero,usuario,tipo) " & _
                                            "VALUES(" & numero & ",'" & usuario & "'," & 2 & ")"
                listSql.Add(sql)

                For i = 0 To dtg_reglas_coor.RowCount - 1
                    If (dtg_reglas_coor.Rows(i).Visible = True) Then
                        sql = "INSERT INTO J_reglas_comisiones_det_coor(numero,detalle,id_tipo_cumplimiento,porc_cump,monto_pagar) " & _
                              "VALUES(" & numero & "," & i & ",'" & dtg_reglas_coor.Item(cbo_tipo_cumpl_cor.Name, i).Value & "'," & dtg_reglas_coor.Item(col_porc_cump_coor.Name, i).Value & "," & dtg_reglas_coor.Item(col_monto_coor.Name, i).Value & ")"
                        listSql.Add(sql)
                    End If
                Next
                mensaje = "creo"


                If (objOpSimplesLn.ExecuteSqlTransaction(listSql)) Then
                    MessageBox.Show("La regla se " & mensaje & " en forma correcta", "Correcto!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    nuevo_coor()
                    consultar()
                Else
                    MessageBox.Show("Error al crear la regla, comuniquese con el area de sistemas", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                MessageBox.Show("Seleccione un coordinador", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        End If
    End Sub
    Private Sub guardar_dir()
        cbo_dir.Focus()
        If (validar_dir()) Then
            If (cbo_dir.Text <> "Seleccione") Then
                Dim listSql As New List(Of Object)
                Dim sql As String = ""
                Dim usuario As String = cbo_dir.SelectedValue
                Dim mensaje As String = ""
                Dim sqlVendedor As String = "SELECT usuario FROM J_reglas_comisiones WHERE usuario ='" & usuario & "' AND anulado is null"
                If (numero <> 0) Then
                    sql = "DELETE FROM J_reglas_comisiones_det_dir WHERE numero = " & numero
                    listSql.Add(sql)
                    sql = "DELETE FROM J_reglas_comisiones WHERE numero = " & numero
                    listSql.Add(sql)
                Else
                    If (objOpSimplesLn.consultarVal(sqlVendedor) = "") Then
                        Dim sNumero As String = objOpSimplesLn.consultarVal("SELECT MAX (numero)+1 FROM J_reglas_comisiones")
                        If (sNumero = "") Then
                            numero = 1
                        Else
                            numero = sNumero
                        End If
                    Else
                        MessageBox.Show("Ya existe una regla para este usuario,busque lo en la parte de abajo y modifique la regla.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                End If
                sql = "INSERT INTO J_reglas_comisiones(numero,usuario,tipo) " & _
                                            "VALUES(" & numero & ",'" & usuario & "'," & 3 & ")"
                listSql.Add(sql)

                For i = 0 To dtg_reglas_dir.RowCount - 1
                    If (dtg_reglas_dir.Rows(i).Visible = True) Then
                        sql = "INSERT INTO J_reglas_comisiones_det_dir(numero,detalle,id_tipo_cumplimiento,porc_cump,monto_pagar) " & _
                                 "VALUES(" & numero & "," & i & ",'" & dtg_reglas_dir.Item(cbo_tipo_cumpl_dir.Name, i).Value & "'," & dtg_reglas_dir.Item(col_cumpl_dir.Name, i).Value & "," & dtg_reglas_dir.Item(col_monto_pagar_dir.Name, i).Value & ")"
                        listSql.Add(sql)
                    End If
                Next
                mensaje = "creo"

                If (objOpSimplesLn.ExecuteSqlTransaction(listSql)) Then
                    MessageBox.Show("La regla se " & mensaje & " en forma correcta", "Correcto!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    nuevo_dir()
                    consultar()
                Else
                    MessageBox.Show("Error al crear la regla, comuniquese con el area de sistemas", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

            Else
                MessageBox.Show("Seleccione un director", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If

    End Sub
    Private Function validar_vend() As Boolean
        Dim resp As Boolean = True
        Dim mensaje As String = "Verifique las reglas que se marcaron con rojo,correjirlas"
        For i = 0 To dtg_reglas_vtas.RowCount - 1
            If (Not IsNothing(dtg_reglas_vtas(col_porc_cumpl_vtas.Name, i).Value) And Not IsNothing(dtg_reglas_vtas(col_porc_pagar_vtas.Name, i).Value)) Then
                If (dtg_reglas_vtas(col_porc_cumpl_vtas.Name, i).Value.ToString <> "" Or dtg_reglas_vtas(col_porc_pagar_vtas.Name, i).Value.ToString <> "") Then
                    If (dtg_reglas_vtas(col_cod_a_pagar_vtas.Name, i).Value <> "" Or dtg_reglas_vtas(col_cod_menos_vtas.Name, i).Value <> "" Or (dtg_reglas_vtas(col_todo.Name, i).Value = True)) Then
                        If (dtg_reglas_vtas(col_porc_cumpl_vtas.Name, i).Value.ToString <> "" And dtg_reglas_vtas(col_porc_pagar_vtas.Name, i).Value.ToString <> "") Then
                            dtg_reglas_vtas.Rows(i).DefaultCellStyle.BackColor = Color.White
                        Else
                            resp = False
                            dtg_reglas_vtas.Rows(i).DefaultCellStyle.BackColor = Color.Red
                            i = dtg_reglas_vtas.RowCount - 1
                            mensaje = "Verifique que todos los campos que se encuentran en rojo esten diligenciados en forma correcta"
                        End If
                    Else
                        resp = False
                        dtg_reglas_vtas.Rows(i).DefaultCellStyle.BackColor = Color.Red
                        i = dtg_reglas_vtas.RowCount - 1
                        mensaje = "Seleccione el código para pagar la comisión,verifique las reglas en color rojo"
                    End If
                Else
                    resp = False
                    dtg_reglas_vtas.Rows(i).DefaultCellStyle.BackColor = Color.Red
                    i = dtg_reglas_vtas.RowCount - 1
                    mensaje = "Verifique las columnas en rojo de las reglas de ventas"
                End If
            ElseIf (IsNothing(dtg_reglas_vtas(col_porc_cumpl_vtas.Name, i).Value) And IsNothing(dtg_reglas_vtas(col_porc_pagar_vtas.Name, i).Value)) Then
                dtg_reglas_vtas.Rows(i).Visible = False
            Else
                resp = False
                dtg_reglas_vtas.Rows(i).DefaultCellStyle.BackColor = Color.Red
                i = dtg_reglas_vtas.RowCount - 1
                mensaje = "Verifique las columnas en rojo de las reglas de ventas"

            End If
        Next
        If (resp) Then
            For i = 0 To dtg_rec_vendedores.RowCount - 1
                If (Not IsNothing(dtg_rec_vendedores(col_id_tipo_rec.Name, i).Value) And Not IsNothing(dtg_rec_vendedores(col_porc_rec.Name, i).Value)) Then
                    If (dtg_rec_vendedores(col_id_tipo_rec.Name, i).Value.ToString <> "" Or dtg_rec_vendedores(col_porc_rec.Name, i).Value.ToString <> "") Then
                        If (dtg_rec_vendedores(col_id_tipo_rec.Name, i).Value.ToString <> "" And dtg_rec_vendedores(col_porc_rec.Name, i).Value.ToString <> "") Then
                            dtg_rec_vendedores.Rows(i).DefaultCellStyle.BackColor = Color.White
                        Else
                            resp = False
                            dtg_rec_vendedores.Rows(i).DefaultCellStyle.BackColor = Color.Red
                            i = dtg_rec_vendedores.RowCount - 1
                            mensaje = "Seleccione todos los items de la regla,verifique las reglas en color rojo"
                        End If
                    Else
                        resp = False
                        dtg_rec_vendedores.Rows(i).DefaultCellStyle.BackColor = Color.Red
                        i = dtg_reglas_vtas.RowCount - 1
                        mensaje = "Verifique las columnas en rojo de las reglas de ventas"
                    End If
                ElseIf (IsNothing(dtg_rec_vendedores(col_id_tipo_rec.Name, i).Value) And IsNothing(dtg_rec_vendedores(col_porc_rec.Name, i).Value)) Then
                    dtg_rec_vendedores.Rows(i).Visible = False
                Else
                    resp = False
                    dtg_rec_vendedores.Rows(i).DefaultCellStyle.BackColor = Color.Red
                    i = dtg_rec_vendedores.RowCount - 1
                    mensaje = "Seleccione todos los items de la regla,verifique las reglas en color rojo"
                End If
            Next
        End If
        If Not (resp) Then
            MessageBox.Show(mensaje, "correjir!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        Return resp
    End Function
    Private Function validar_dir()
        Dim resp As Boolean = True
        Dim mensaje As String = "Verifique las reglas que se marcaron con rojo,correjirlas"
        For i = 0 To dtg_reglas_dir.RowCount - 1
            If Not IsNothing(dtg_reglas_dir(col_cumpl_dir.Name, i).Value) And Not IsNothing(dtg_reglas_dir(cbo_tipo_cumpl_dir.Name, i).Value) And Not IsNothing(dtg_reglas_dir(col_monto_pagar_dir.Name, i).Value) Then
                If (dtg_reglas_dir(col_cumpl_dir.Name, i).Value.ToString <> "" Or dtg_reglas_dir(cbo_tipo_cumpl_dir.Name, i).Value.ToString <> "" Or dtg_reglas_dir(col_monto_pagar_dir.Name, i).Value.ToString <> "") Then
                    If (dtg_reglas_dir(col_cumpl_dir.Name, i).Value.ToString <> "" And dtg_reglas_dir(cbo_tipo_cumpl_dir.Name, i).Value.ToString <> "" And dtg_reglas_dir(col_monto_pagar_dir.Name, i).Value.ToString <> "") Then
                        dtg_reglas_dir.Rows(i).DefaultCellStyle.BackColor = Color.White
                    Else
                        resp = False
                        i = dtg_reglas_dir.RowCount - 1
                        dtg_reglas_dir.Rows(i).DefaultCellStyle.BackColor = Color.Red
                        mensaje = "Seleccione todos los items de la regla,verifique las reglas en color rojo"
                    End If
                Else
                    resp = False
                    dtg_reglas_dir.Rows(i).DefaultCellStyle.BackColor = Color.Red
                    i = dtg_reglas_dir.RowCount - 1
                    mensaje = "Verifique las columnas en rojo de las reglas de ventas"
                End If

            ElseIf IsNothing(dtg_reglas_dir(col_cumpl_dir.Name, i).Value) And IsNothing(dtg_reglas_dir(cbo_tipo_cumpl_dir.Name, i).Value) And IsNothing(dtg_reglas_dir(col_monto_pagar_dir.Name, i).Value) Then
                dtg_reglas_dir.Rows(i).Visible = False
            Else
                resp = False
                dtg_reglas_dir.Rows(i).DefaultCellStyle.BackColor = Color.Red
                i = dtg_reglas_dir.RowCount - 1
                mensaje = "Verifique las columnas en rojo de las reglas de ventas"
            End If

        Next
        If Not (resp) Then
            MessageBox.Show(mensaje, "correjir!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        Return resp
    End Function
    Private Function validar_coor()
        Dim resp As Boolean = True
        Dim mensaje As String = "Verifique las reglas que se marcaron con rojo,correjirlas"
        For i = 0 To dtg_reglas_coor.RowCount - 1
            If (Not IsNothing(dtg_reglas_coor(col_porc_cump_coor.Name, i).Value) And Not IsNothing(dtg_reglas_coor(cbo_tipo_cumpl_cor.Name, i).Value) And Not IsNothing(dtg_reglas_coor(col_monto_coor.Name, i).Value)) Then
                If (dtg_reglas_coor(col_porc_cump_coor.Name, i).Value.ToString <> "" Or dtg_reglas_coor(cbo_tipo_cumpl_cor.Name, i).Value.ToString <> "" Or dtg_reglas_coor(col_monto_coor.Name, i).Value.ToString <> "") Then
                    If (dtg_reglas_coor(col_porc_cump_coor.Name, i).Value.ToString <> "" And dtg_reglas_coor(cbo_tipo_cumpl_cor.Name, i).Value.ToString <> "" And dtg_reglas_coor(col_monto_coor.Name, i).Value.ToString <> "") Then
                        dtg_reglas_coor.Rows(i).DefaultCellStyle.BackColor = Color.White
                    Else
                        resp = False
                        dtg_reglas_coor.Rows(i).DefaultCellStyle.BackColor = Color.Red
                        i = dtg_reglas_coor.RowCount - 1
                        mensaje = "Seleccione todos los items de la regla,verifique las reglas en color rojo"
                    End If
                Else
                    resp = False
                    i = dtg_reglas_coor.RowCount - 1
                    mensaje = "Verifique las columnas en rojo de las reglas de ventas"
                    dtg_reglas_coor.Rows(i).DefaultCellStyle.BackColor = Color.Red
                End If
            ElseIf (IsNothing(dtg_reglas_coor(col_porc_cump_coor.Name, i).Value) And IsNothing(dtg_reglas_coor(cbo_tipo_cumpl_cor.Name, i).Value) And IsNothing(dtg_reglas_coor(col_monto_coor.Name, i).Value)) Then
                dtg_reglas_coor.Rows(i).Visible = False
            Else
                resp = False
                dtg_reglas_coor.Rows(i).DefaultCellStyle.BackColor = Color.Red
                i = dtg_reglas_coor.RowCount - 1
                mensaje = "Verifique las columnas en rojo de las reglas de ventas"
            End If

        Next
        If Not (resp) Then
            MessageBox.Show(mensaje, "correjir!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        Return resp
    End Function
    Private Sub btn_guardar_Click(sender As System.Object, e As System.EventArgs) Handles btn_guardar.Click
        dtg_consulta.Focus()
        Select Case tab_reglas.SelectedTab.Name
            Case tab_vendedores.Name
                guardar_vendedor()
            Case tab_coor.Name
                guardar_coor()
            Case tab_dir.Name
                guardar_dir()
            
        End Select
    End Sub

    Private Sub cargar_datos(ByVal fila As Integer, ByVal tipo As Integer)
        numero = dtg_consulta.Item("numero", fila).Value
        Dim dt As New DataTable
        Select Case tipo
            Case 1
                cbo_vend.Enabled = False
                tab_reglas.SelectedTab = tab_vendedores
                dtg_reglas_vtas.Rows.Clear()
                dtg_rec_vendedores.Rows.Clear()
                Dim sql_rec As String = "SELECT r.id_tipo_cumpl,t.regla,r.porc_pagar FROM J_reglas_comisiones_det_recaudos r,J_reglas_tipo_cumplimiento t  WHERE t.id = r.id_tipo_cumpl AND  numero = " & numero
                Dim sql_vtas As String = "SELECT porc_cump,porc_pagar,sobre_codigo,menos_codigo,todo FROM J_reglas_comisiones_det_vtas   WHERE  numero = " & numero

                dt = objOpSimplesLn.listar_datatable(sql_vtas, "CORSAN")
                For i = 0 To dt.Rows.Count - 1
                    dtg_reglas_vtas.Rows.Add()
                    dtg_reglas_vtas.Item(col_porc_cumpl_vtas.Name, i).Value = dt.Rows(i).Item("porc_cump")
                    dtg_reglas_vtas.Item(col_porc_pagar_vtas.Name, i).Value = dt.Rows(i).Item("porc_pagar")
                    dtg_reglas_vtas.Item(col_cod_a_pagar_vtas.Name, i).Value = dt.Rows(i).Item("sobre_codigo")
                    dtg_reglas_vtas.Item(col_cod_menos_vtas.Name, i).Value = dt.Rows(i).Item("menos_codigo")
                    If (dt.Rows(i).Item("todo") = "S") Then
                        dtg_reglas_vtas.Item(col_todo.Name, i).Value = True
                    End If
                Next
                dtg_reglas_vtas.Rows.Add()
                dt = New DataTable
                dt = objOpSimplesLn.listar_datatable(sql_rec, "CORSAN")
                dtg_rec_vendedores.Rows.Clear()
                For i = 0 To dt.Rows.Count - 1
                    dtg_rec_vendedores.Rows.Add()
                    dtg_rec_vendedores.Item(col_id_tipo_rec.Name, i).Value = dt.Rows(i).Item("id_tipo_cumpl")
                    dtg_rec_vendedores.Item(col_desc_tipo_rec.Name, i).Value = dt.Rows(i).Item("regla")
                    dtg_rec_vendedores.Item(col_porc_rec.Name, i).Value = dt.Rows(i).Item("porc_pagar")
                Next
                dtg_rec_vendedores.Rows.Add()
                cbo_vend.SelectedValue = dtg_consulta.Item("usuario", fila).Value
                tab_reglas.SelectedTab = tab_vendedores
            Case 2
                cbo_coordinador.Enabled = False
                tab_reglas.SelectedTab = tab_coor
                dtg_reglas_coor.Rows.Clear()
                Dim sql As String = "SELECT id_tipo_cumplimiento,porc_cump,monto_pagar FROM J_reglas_comisiones_det_coor WHERE numero = " & numero
                dt = objOpSimplesLn.listar_datatable(sql, "CORSAN")
                For i = 0 To dt.Rows.Count - 1
                    dtg_reglas_coor.Rows.Add()

                    dtg_reglas_coor.Item(cbo_tipo_cumpl_cor.Name, i).Value = dt.Rows(i).Item("id_tipo_cumplimiento")
                    dtg_reglas_coor.Item(col_porc_cump_coor.Name, i).Value = dt.Rows(i).Item("porc_cump")
                    dtg_reglas_coor.Item(col_monto_coor.Name, i).Value = dt.Rows(i).Item("monto_pagar")
                Next
                dtg_reglas_coor.Rows.Add()
                cbo_coordinador.SelectedValue = dtg_consulta.Item("usuario", fila).Value
                tab_reglas.SelectedTab = tab_coor
            Case 3
                cbo_dir.Enabled = False
                tab_reglas.SelectedTab = tab_dir
                dtg_reglas_dir.Rows.Clear()
                Dim sql As String = "SELECT id_tipo_cumplimiento,porc_cump,monto_pagar FROM J_reglas_comisiones_det_dir WHERE numero = " & numero
                dt = objOpSimplesLn.listar_datatable(sql, "CORSAN")
                'Dim objda  As SqlDataAdapter(my_strsql, cn)

                'objda.Fill(pr_objds, "Pasaje")
                For i = 0 To dt.Rows.Count - 1

                    dtg_reglas_dir.Rows.Add()
                    dtg_reglas_dir.Item(cbo_tipo_cumpl_dir.Name, i).Value = dt.Rows(i).Item("id_tipo_cumplimiento")
                    dtg_reglas_dir.Item(col_cumpl_dir.Name, i).Value = dt.Rows(i).Item("porc_cump")
                    dtg_reglas_dir.Item(col_monto_pagar_dir.Name, i).Value = dt.Rows(i).Item("monto_pagar")
                Next
                dtg_reglas_dir.Rows.Add()
                cbo_dir.SelectedValue = dtg_consulta.Item("usuario", fila).Value
                tab_reglas.SelectedTab = tab_dir
        End Select
    End Sub
    Private Sub consultar()
        Dim sql As String = "SELECT r.numero,r.usuario,u.nombres,r.tipo FROM J_reglas_comisiones r , jjv_usuarios u WHERE u.usuario = r.usuario AND anulado is null"
        dtg_consulta.DataSource = objOpSimplesLn.listar_datatable(sql, "CORSAN")
    End Sub
    Private Sub btnActualizar_Click(sender As System.Object, e As System.EventArgs) Handles btnActualizar.Click
        consultar()
        Select Case tab_reglas.SelectedTab.Name
            Case tab_vendedores.Name
                nuevo_vend()
            Case tab_coor.Name
                nuevo_coor()
            Case tab_dir.Name
                nuevo_dir()
        End Select
    End Sub
    Private Sub nuevo_coor()
        limpiarColorDtg()
        numero = 0
        cbo_coordinador.SelectedValue = "Seleccione"
        dtg_reglas_coor.Rows.Clear()
        dtg_reglas_coor.Rows.Add()
        cbo_coordinador.Enabled = True
    End Sub
    Private Sub nuevo_dir()
        limpiarColorDtg()
        numero = 0
        cbo_vend.SelectedValue = "Seleccione"
        dtg_reglas_dir.Rows.Clear()
        dtg_reglas_dir.Rows.Add()
        cbo_dir.Enabled = True
    End Sub
    Private Sub nuevo_vend()
        limpiarColorDtg()
        numero = 0
        cbo_vend.SelectedValue = "Seleccione"
        dtg_rec_vendedores.Rows.Clear()
        dtg_rec_vendedores.Rows.Add()
        dtg_reglas_vtas.Rows.Clear()
        dtg_reglas_vtas.Rows.Add()
        cbo_vend.Enabled = True
    End Sub
    Private Sub limpiarColorDtg()
        For i = 0 To dtg_consulta.RowCount - 1
            If (dtg_consulta.Rows(i).DefaultCellStyle.BackColor = Color.Green) Then
                dtg_consulta.Rows(i).DefaultCellStyle.BackColor = Color.White
            End If
        Next
    End Sub
    Private Sub btn_nuevo_Click(sender As System.Object, e As System.EventArgs) Handles btn_nuevo.Click
        Select Case tab_reglas.SelectedTab.Name
            Case tab_vendedores.Name
                nuevo_vend()
            Case tab_coor.Name
                nuevo_coor()
            Case tab_dir.Name
                nuevo_dir()
        End Select

    End Sub

    Private Sub btn_Cerrar_Click(sender As System.Object, e As System.EventArgs) Handles btn_Cerrar.Click
        group_tipo.Visible = False
    End Sub



    Private Sub dtg_reglas_vtas_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtg_reglas_vtas.CellClick
        If (e.RowIndex >= 0) Then
            Dim col As String = dtg_reglas_vtas.Columns(e.ColumnIndex).Name
            If (col = col_eliminar_vtas.Name) Then
                dtg_reglas_vtas.Rows.RemoveAt(e.RowIndex)
                If (dtg_reglas_vtas.RowCount = 0) Then
                    dtg_reglas_vtas.Rows.Add()
                End If
            ElseIf (col = btn_add_vtas.Name) Then
                dtg_reglas_vtas.Rows.Add()
            End If
        End If
    End Sub

    Private Sub dtg_tipo_cumplimiento_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtg_tipo_cumplimiento.CellClick
        If (e.RowIndex >= 0) Then
            dtg_rec_vendedores.Item(col_desc_tipo_rec.Name, fila_select).Value = dtg_tipo_cumplimiento.Item("regla", e.RowIndex).Value
            dtg_rec_vendedores.Item(col_id_tipo_rec.Name, fila_select).Value = dtg_tipo_cumplimiento.Item("id", e.RowIndex).Value
            group_tipo.Visible = False
        End If
    End Sub

 

    Private Sub dtg_reglas_coor_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtg_reglas_coor.CellClick

        If (e.RowIndex >= 0) Then
            Dim col As String = dtg_reglas_coor.Columns(e.ColumnIndex).Name
            If (col = col_borrar_coor.Name) Then
                dtg_reglas_coor.Rows.RemoveAt(e.RowIndex)
                If (dtg_reglas_coor.RowCount = 0) Then
                    dtg_reglas_coor.Rows.Add()
                End If
            ElseIf (col = col_add_coor.Name) Then
                dtg_reglas_coor.Rows.Add()
            End If
        End If
    End Sub

    Private Sub dtg_reglas_dir_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtg_reglas_dir.CellClick
        If (e.RowIndex >= 0) Then
            Dim col As String = dtg_reglas_dir.Columns(e.ColumnIndex).Name
            If (col = col_borrar_dir.Name) Then
                dtg_reglas_dir.Rows.RemoveAt(e.RowIndex)
                If (dtg_reglas_dir.RowCount = 0) Then
                    dtg_reglas_dir.Rows.Add()
                End If
            ElseIf (col = col_add_dir.Name) Then
                dtg_reglas_dir.Rows.Add()
            ElseIf (col = col_desc_tipo_rec.Name) Then
                group_tipo.Visible = True
                fila_select = e.RowIndex
            End If
        End If
    End Sub


    Private Sub dtg_consulta_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtg_consulta.CellClick
        If (e.RowIndex >= 0) Then
            carga_comp = False
            Dim col As String = dtg_consulta.Columns(e.ColumnIndex).Name
            Dim numero As Integer = dtg_consulta.Item("numero", e.RowIndex).Value
            If (col = col_editar_consult_vend.Name) Then
                Dim tipo As Integer = dtg_consulta.Item("tipo", e.RowIndex).Value
                limpiarColorDtg()
                dtg_consulta.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Green
                cargar_datos(e.RowIndex, tipo)
                cargar_datos(e.RowIndex, tipo)
            ElseIf (col = col_eliminar_consult_vend.Name) Then
                Dim motivo As String = InputBox("Ingrese motivo de la anulación.", "Motivo")
                If (motivo <> "") Then
                    motivo &= "-" & usuario & "-" & Now.Date
                    Dim sql As String = "UPDATE j_reglas_comisiones SET anulado = 1,motivo = '" & motivo & "' WHERE numero =" & numero
                    If (objOpSimplesLn.ejecutar(sql, "CORSAN") > 0) Then
                        MessageBox.Show("La regla se elimino en forma correcta", "Correcto!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        consultar()
                        nuevo_coor()
                        nuevo_dir()
                        nuevo_vend()
                    Else
                        MessageBox.Show("Error al eliminar la regla, comuniquese con el area de sistemas", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Else
                    MessageBox.Show("Ingrese un motivo para la anulación de la regla", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

            End If
        End If
        carga_comp = True
    End Sub

    Private Sub tab_reglas_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles tab_reglas.SelectedIndexChanged
        nuevo_coor()
        nuevo_dir()
        nuevo_vend()
    End Sub

    Private Sub dtg_rec_vendedores_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtg_rec_vendedores.CellClick
        If (e.RowIndex >= 0) Then
            Dim col As String = dtg_rec_vendedores.Columns(e.ColumnIndex).Name
            If (col = col_borrar_rec.Name) Then
                dtg_rec_vendedores.Rows.RemoveAt(e.RowIndex)
                If (dtg_rec_vendedores.RowCount = 0) Then
                    dtg_rec_vendedores.Rows.Add()
                End If
            ElseIf (col = col_add_rec.Name) Then
                dtg_rec_vendedores.Rows.Add()
            ElseIf (col = col_desc_tipo_rec.Name) Then
                group_tipo.Visible = True
                fila_select = e.RowIndex
            End If

        End If
    End Sub

    Private Sub dtg_reglas_vtas_CellValueChanged(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtg_reglas_vtas.CellValueChanged
        If (carga_comp) Then
            dtg_reglas_vtas.CurrentCell = Nothing
            Dim col As String = dtg_reglas_vtas.Columns(e.ColumnIndex).Name
            If (col = col_todo.Name) Then
                If (dtg_reglas_vtas.Item(col_todo.Name, e.RowIndex).Value) Then
                    carga_comp = False
                    dtg_reglas_vtas.Item(col_cod_a_pagar_vtas.Name, e.RowIndex).Value = ""
                    dtg_reglas_vtas.Item(col_cod_menos_vtas.Name, e.RowIndex).Value = ""
                    carga_comp = True
                End If
            ElseIf (col = col_cod_a_pagar_vtas.Name) Then
                carga_comp = False
                dtg_reglas_vtas.Item(col_todo.Name, e.RowIndex).Value = False
                dtg_reglas_vtas.Item(col_cod_menos_vtas.Name, e.RowIndex).Value = ""
                carga_comp = True
            ElseIf (col = col_cod_menos_vtas.Name) Then
                carga_comp = False
                dtg_reglas_vtas.Item(col_todo.Name, e.RowIndex).Value = False
                dtg_reglas_vtas.Item(col_cod_a_pagar_vtas.Name, e.RowIndex).Value = ""
                carga_comp = True
            End If
        End If
    
    End Sub

    Private Sub dtg_reglas_vtas_DataError(sender As System.Object, e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dtg_reglas_vtas.DataError

    End Sub

    Private Sub dtg_reglas_coor_DataError(sender As System.Object, e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dtg_reglas_coor.DataError

    End Sub

    Private Sub dtg_reglas_dir_DataError(sender As System.Object, e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dtg_reglas_dir.DataError

    End Sub
End Class