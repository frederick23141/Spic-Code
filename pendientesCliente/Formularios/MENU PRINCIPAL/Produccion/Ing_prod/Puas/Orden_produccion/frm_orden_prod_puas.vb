Imports logicaNegocios
Imports accesoDatos
Imports entidadNegocios
Public Class frm_orden_prod_puas
    Private obj_Ing_prodLn As New Ing_prodLn
    Private objOpsimpesLn As New Op_simpesLn
    Dim usuario As UsuarioEn
    Dim cargaComp As Boolean = False
    Dim cbo_mat_prima2 As Object
    Dim consecutivoPpal As String
    Public Sub main(ByVal usuario As UsuarioEn)
        Me.usuario = usuario
        If usuario.permiso = "PUAS" Then
            GB_orden_produccion.Visible = False
        End If
        cargaComp = True
    End Sub
    Private Sub frm_orden_prod_puas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargar_cbo_crear_orden()
        cargaComp = True
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
    Public Function formatoNegrita() As DataGridViewCellStyle
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold)
        Return DataGridViewCellStyle1
    End Function
    '------------------------------------------------------------------------------------------------------------------------------------------------------------
    '                                                       CREACION DE ORDEN DE PRODUCCION
    '------------------------------------------------------------------------------------------------------------------------------------------------------------
    Private Sub cargar_cbo_crear_orden()
        Dim dt As New DataTable
        Dim row As DataRow
        Dim sql As String
        sql = "select codigo, codigo + ' - ' + descripcion As descripcion  from referencias where codigo like '22G%' AND ref_anulada = 'N'  "
        dt = New DataTable
        dt = obj_Ing_prodLn.listar_datatable(sql, "CORSAN")
        row = dt.NewRow
        row("codigo") = 0
        row("descripcion") = "Seleccione"
        dt.Rows.Add(row)
        cbo_mat_prima.DataSource = dt
        cbo_mat_prima.ValueMember = "codigo"
        cbo_mat_prima.DisplayMember = "descripcion"
        cbo_mat_prima.SelectedValue = 0

        sql = "select codigo, codigo + ' - ' + descripcion As descripcion  from referencias where codigo like '22G%' AND ref_anulada = 'N'  "
        dt = New DataTable
        dt = obj_Ing_prodLn.listar_datatable(sql, "CORSAN")
        row = dt.NewRow
        row("codigo") = 0
        row("descripcion") = "Seleccione"
        dt.Rows.Add(row)
        cbo_map_prima_2.DataSource = dt
        cbo_map_prima_2.ValueMember = "codigo"
        cbo_map_prima_2.DisplayMember = "descripcion"
        cbo_map_prima_2.SelectedValue = 0


        sql = "select codigo, codigo + ' - ' + descripcion As descripcion from referencias where (codigo like '33P%') AND ref_anulada = 'N'  "
        dt = New DataTable
        dt = obj_Ing_prodLn.listar_datatable(sql, "CORSAN")
        row = dt.NewRow
        row("codigo") = 0
        row("descripcion") = "Seleccione"
        dt.Rows.Add(row)
        cbo_prod_final.DataSource = dt
        cbo_prod_final.ValueMember = "codigo"
        cbo_prod_final.DisplayMember = "descripcion"
        cbo_prod_final.SelectedValue = 0

        dt = New DataTable
        sql = "SELECT m.codigoM,m.Descripción + '      -      ' + s.seccion As nombre FROM J_maquinas m , D_seccion_maquina_puas s WHERE s.maquina = m.codigoM AND m.tipoMAquina = 4 ORDER BY m.codigoM"
        dt = obj_Ing_prodLn.listar_datatable(sql, "PRODUCCION")
        row = dt.NewRow
        row("codigoM") = 0
        row("nombre") = "Seleccione"
        dt.Rows.Add(row)
        cbo_maquina.DataSource = dt
        cbo_maquina.ValueMember = "codigoM"
        cbo_maquina.DisplayMember = "nombre"
        cbo_maquina.SelectedValue = 0

        'cboAñoProg.Text = Now.Year


    End Sub

    Private Sub txtCantProg_KeyPress(sender As Object, e As KeyPressEventArgs)
        soloNumero(e)
    End Sub
    'Validar ingreso de materia prima
    Private Function validar_encabezado()
        Dim resp As Boolean = False
        If (cbo_maquina.SelectedValue <> 0) Then
            If (cbo_mat_prima.Text <> "Seleccione") Then
                If (txtCantProg.Text <> "") Then
                    If IsNumeric(txtCantProg.Text) Then
                        If (txtCantProg.Text > 0) Then
                            If (cbo_prod_final.Text <> "Seleccione") Then
                                If (objOpsimpesLn.validarCodigo(cbo_prod_final.SelectedValue)) Then
                                    If (objOpsimpesLn.validarCodigoEstado(cbo_prod_final.Text)) Then
                                        'If (cboAñoProg.Text <> "Seleccione") Then
                                        '    If (cboMesProg.Text <> "Seleccione") Then
                                        resp = True
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
                        MessageBox.Show("La cantidad programada deber ser numerica", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
        Return resp
    End Function
    Private Sub modificar_Orden()
        Dim resp As Boolean = False
        Dim sql As String = ""
        Dim prod_final As String = cbo_prod_final.SelectedValue
        Dim maquina As Integer = cbo_maquina.SelectedValue
        Dim nom_maq As String = cbo_maquina.Text
        Dim cant_prog As String = txtCantProg.Text
        Dim origen As String = cbo_mat_prima.SelectedValue
        Dim origen_2 As String = cbo_map_prima_2.SelectedValue
        Dim mes As Integer = cbo_fec_orden.Value.Month
        Dim ano As Integer = cbo_fec_orden.Value.Year
        Dim notas As String = txtnota.Text
        Dim notas_auditoria As String = ""
        'notas_auditoria = "Creo:" & usuario.usuario & Now
        notas_auditoria = "Creada : " & Now

        sql = "UPDATE D_orden_prod_puas SET maquina=" & maquina & ",nom_maq='" & nom_maq & "',mat_prim='" & origen & "',mat_prim2='" & origen_2 & "',cant_prog=" & cant_prog & "," & _
            " prod_final='" & prod_final & "',nota='" & notas & "',mes=" & mes & ",ano=" & ano & " where cod_orden=" & consecutivoPpal & ""
        objOpsimpesLn.ejecutar(sql, "PRODUCCION")
        actualizarConsecutivoPpal("")

    End Sub

    Private Function guardar_orden()
        Dim resp As Boolean = False
        Dim sql As String = ""
        Dim consecutivo As Integer = 0
        Dim prod_final As String = cbo_prod_final.SelectedValue
        Dim maquina As Integer = cbo_maquina.SelectedValue
        Dim nom_maq As String = cbo_maquina.Text
        Dim cant_prog As String = txtCantProg.Text
        Dim origen As String = cbo_mat_prima.SelectedValue
        Dim origen_2 As String = cbo_map_prima_2.SelectedValue
        Dim mes As Integer = cbo_fec_orden.Value.Month
        Dim ano As Integer = cbo_fec_orden.Value.Year
        Dim notas As String = txtnota.Text
        Dim notas_auditoria As String = ""
        Dim fecha As String = objOpsimpesLn.cambiarFormatoFecha(cbo_fec_orden.Value)
        'notas_auditoria = "Creo:" & usuario.usuario & Now
        notas_auditoria = "Creada : " & Now
        sql = "SELECT  MAX (cod_orden) FROM D_orden_prod_puas"
        consecutivo = obj_Ing_prodLn.consultar_valor(sql, "PRODUCCION") + 1

        If origen_2 = "0" Then
            sql = "INSERT INTO D_orden_prod_puas " &
                "(cod_orden,maquina,nom_maq,mat_prim,cant_prog,prod_final,nota,notas_auditoria,mes,ano,oculto,fecha_creacion) " &
                    "VALUES " &
                            "(" & consecutivo & " , " & maquina & ",'" & nom_maq & "','" & origen & "'," & cant_prog & ",'" & prod_final & "' ,'" & notas & "','" & notas_auditoria & "'," & mes & " ," & ano & ",'0','" & fecha & "')"

        Else
            sql = "INSERT INTO D_orden_prod_puas " &
                   "(cod_orden,maquina,nom_maq,mat_prim,mat_prim2,cant_prog,prod_final,nota,notas_auditoria,mes,ano,oculto,fecha_creacion) " &
                       "VALUES " &
                               "(" & consecutivo & " , " & maquina & ",'" & nom_maq & "','" & origen & "','" & origen_2 & "' ," & cant_prog & ",'" & prod_final & "' ,'" & notas & "','" & notas_auditoria & "'," & mes & " ," & ano & ",'0','" & fecha & "')"
        End If
     
        If objOpsimpesLn.ejecutar(sql, "PRODUCCION") Then
            resp = True
        End If
        Return resp
    End Function
    Private Sub nuevo()
        cbo_prod_final.SelectedValue = 0
        txtCantProg.Text = ""
        cbo_mat_prima.SelectedValue = 0
        If cbo_map_prima_2.Text <> "SELECCIONE" Then
            cbo_map_prima_2.SelectedValue = 0
        End If
        cbo_maquina.SelectedValue = 0
        cbo_fec_orden.Value = Now
        txtnota.Text = ""
    End Sub

    '------------------------------------------------------------------------------------------------------------------------------------------------------------
    '                                                       TABLA DE ORDENES DE PRODUCCION PARA TRABAJAR
    '------------------------------------------------------------------------------------------------------------------------------------------------------------


    Private Sub cargarAdminProd(ByVal consecutivo As String)
        Dim fecIni As String = cboFechaIni.Value.ToString("yyyy-MM-dd")
        Dim fecFin As String = cboFechaFin.Value.ToString("yyyy-MM-dd")
        Dim WhereCliExt As String = ""
        Dim WhereFec As String = ""
        Dim cont_C As Integer = 0
        Dim cont_S As Integer = 0
        Dim porce_cum As Double
        If (cargaComp) Then
            If fecFin = fecIni Then
                WhereFec = " WHERE year(fecha_creacion) = " & CInt(cboFechaIni.Value.Year) & " and month(fecha_creacion)= " & CInt(cboFechaIni.Value.Month) & " and day(fecha_creacion)=" & CInt(cboFechaIni.Value.Day) & ""
            Else
                WhereFec = " WHERE fecha_creacion >='" & fecIni & "' and fecha_creacion <='" & fecFin & "'"
            End If
            If (consecutivo <> "") Then
                WhereFec += " AND cod_orden =" & consecutivo & ""
            End If
        End If
        Dim sql As String = "SELECT cod_orden,nom_maq,mat_prim,mat_prim2,prod_final,cant_prog,(select count(nro_orden) FROM D_orden_prod_puas_producto where nro_orden=cod_orden) as nro_Rollos_Reg,nota,notas_auditoria,mes,ano,oculto,fecha_creacion,notas_liquidacion FROM D_orden_prod_puas" & WhereFec & WhereCliExt
        dtg_consulta.DataSource = obj_Ing_prodLn.listar_datatable(sql, "PRODUCCION")
        Me.dtg_consulta.Columns("oculto").Visible = False
        For i = 0 To dtg_consulta.RowCount - 1
            If Not (IsDBNull(dtg_consulta.Item("cant_prog", i).Value) Or IsDBNull(dtg_consulta.Item("nro_Rollos_Reg", i).Value)) Then
                If (dtg_consulta.Item("nro_Rollos_Reg", i).Value >= dtg_consulta.Item("cant_prog", i).Value) Then
                    dtg_consulta.Rows(i).DefaultCellStyle.BackColor = Color.Red
                    cont_C = cont_C + 1
                End If
            End If
            If Not IsDBNull(dtg_consulta.Item("oculto", i).Value) Then
                If (dtg_consulta.Item("oculto", i).Value = 1) Then
                    dtg_consulta.Item(col_oculto.Name, i).Value = Spic.My.Resources.ok3
                End If
            End If
            cont_S = cont_S + 1
        Next
        If dtg_consulta.Rows.Count > 0 Then
            porce_cum = (cont_C / cont_S) * 100
            porcen_header.Text = "El % cumplido es de:" & CInt(porce_cum)
        End If
        lbl_cumplidas.Text = "El total de ordenes cumplidas es:" & cont_C & ",de un total de:" & cont_S
        dtg_consulta.DataSource = totalizar_Admin()
        pintartotal()
        dtg_consulta.Columns("fecha_creacion").DefaultCellStyle.Format = "dd/MM/yyyy"
    End Sub
    Public Sub pintartotal()
        If dtg_consulta.Rows.Count > 0 Then
            dtg_consulta.Rows(dtg_consulta.Rows.Count - 1).DefaultCellStyle.BackColor = Color.Salmon
            dtg_consulta.Rows(dtg_consulta.Rows.Count - 1).DefaultCellStyle.Font = New Font(dtg_consulta.CurrentCell.InheritedStyle.Font, FontStyle.Bold)
        End If
    End Sub
    Private Function totalizar_Admin()
        Dim cant_prog As Double = 0
        Dim nro_Rollos As Double = 0
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
            If IsDBNull(row.Item("nro_Rollos_Reg")) = False Then
                If row.Item("nro_Rollos_Reg") > 0 Then
                    nro_Rollos += row.Item("nro_Rollos_Reg")
                End If
            End If

            If indice = (dt.Rows.Count - 1) Then
                dt.Rows.Add()
                dt.Rows(dt.Rows.Count - 1).Item("prod_final") = "TOTAL"
                dt.Rows(dt.Rows.Count - 1).Item("cant_prog") = cant_prog
                dt.Rows(dt.Rows.Count - 1).Item("nro_Rollos_Reg") = nro_Rollos
                Exit For
            End If
            indice += 1
        Next
        Return dt
    End Function
    Private Sub calcuPorcen()
        For Each row As DataGridViewRow In dtg_consulta.Rows
            Dim ppto_kilos As Double = row.Cells.Item("cant_prog").Value
            Dim kilos As Double
            If IsDBNull(row.Cells.Item("kilos").Value) Then
                kilos = 0
            Else
                kilos = row.Cells.Item("kilos").Value
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
    Private Sub dtg_consulta_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtg_consulta.CellContentClick
        Dim col As String = dtg_consulta.Columns(e.ColumnIndex).Name
        If (col = btnVerDetalle.Name) Then
            actualizarConsecutivoPpal(dtg_consulta.Item("cod_orden", dtg_consulta.CurrentCell.RowIndex).Value)
            cargarDatos()
            tbl_ppal.SelectedTab = pag_crear_orden
        ElseIf (col = col_oculto.Name) Then
            Dim sql As String
            Dim bloqueo As String
            sql = "select bloqueo from D_orden_prod_puas WHERE cod_orden = " & dtg_consulta.Item("cod_orden", dtg_consulta.CurrentCell.RowIndex).Value & ""
            bloqueo = objOpsimpesLn.consultValorTodo(sql, "PRODUCCION")
            If bloqueo = "" Then

                Dim estado As Integer
                Dim accion As String = ""

                cargaComp = False

                If (MessageBox.Show("Esta seguro que desea liquidar y ocultar la orden.Ya no se puede trabajar una orden liquidada, tenga en cuenta que si oculta una orden no se vera en los computadores puas", "ocultar orden?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) = 6) Then
                    If Not IsDBNull(dtg_consulta.Item("oculto", e.RowIndex).Value) Then
                        If (dtg_consulta.Item("oculto", e.RowIndex).Value = 0) Then
                            accion = "ocultar"
                            estado = 1
                            dtg_consulta.Item(col, e.RowIndex).Value = Spic.My.Resources.ok3
                            dtg_consulta.Item("oculto", e.RowIndex).Value = estado
                        End If
                    Else
                        accion = "ocultar"
                        estado = 1
                        dtg_consulta.Item(col, e.RowIndex).Value = Spic.My.Resources.ok3
                        dtg_consulta.Item("oculto", e.RowIndex).Value = estado
                    End If
                    Dim consecutivo As Integer = dtg_consulta.Item("cod_orden", dtg_consulta.CurrentCell.RowIndex).Value
                    Dim nombre_usuario As String = usuario.usuario
                    sql = "UPDATE D_orden_prod_puas SET oculto = " & estado & ",bloqueo=" & estado & ",notas_auditoria +=  '" & accion & " " & nombre_usuario & " " & Now.Date & "' WHERE cod_orden = " & consecutivo
                    If (objOpsimpesLn.ejecutar(sql, "PRODUCCION")) Then
                        MessageBox.Show("La orden se " & accion & " en forma exitosa!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
            frm.main(dtg_consulta.Item("cod_orden", e.RowIndex).Value, usuario.usuario, dtg_consulta.Item("prod_final", e.RowIndex).Value, dtg_consulta.Item("mat_prim", e.RowIndex).Value, "PU")
            frm.Show()
            cargarAdminProd(txtConsulNumOrd.Text)
        End If
    End Sub
    Private Sub cargarDatos()
        Dim sql As String = "SELECT cod_orden,maquina,mat_prim,mat_prim2,prod_final,cant_prog,nota,fecha_creacion " &
                              " FROM D_orden_prod_puas WHERE cod_orden = " & consecutivoPpal
        Dim lista As New List(Of Object)
        Dim tam As Integer = 8
        lista = obj_Ing_prodLn.listaForm(consecutivoPpal, tam, sql)
        If (lista.Count > 0) Then
            cbo_maquina.SelectedValue = lista(1)
            cbo_mat_prima.SelectedValue = lista(2)
            If Not IsDBNull(lista(3)) Then
                cbo_map_prima_2.SelectedValue = lista(3)
            End If
            cbo_prod_final.SelectedValue = lista(4)
            txtCantProg.Text = lista(5)
            cbo_fec_orden.Value = lista(7)
            If Not IsDBNull(lista(6)) Then
                txtnota.Text = lista(6)
            End If
        End If
    End Sub
    Private Sub actualizarConsecutivoPpal(ByVal consecutivo As String)
        consecutivoPpal = consecutivo
    End Sub
    Private Sub txtConsulNumOrd_TextChanged(sender As Object, e As EventArgs) Handles txtConsulNumOrd.TextChanged
        If txtConsulNumOrd.Text <> "" Then
            cargarAdminProd(txtConsulNumOrd.Text)
        Else
            MsgBox("Ingrese un numero", vbOK)
        End If
    End Sub

    Private Sub CboMesAdminOrden_SelectedIndexChanged_1(sender As Object, e As EventArgs)
        If cargaComp = True Then
            cargarAdminProd(txtConsulNumOrd.Text)
        End If
    End Sub
    Private Sub CboAnoAdminOrden_SelectedIndexChanged_1(sender As Object, e As EventArgs)
        If cargaComp = True Then
            cargarAdminProd(txtConsulNumOrd.Text)
        End If
    End Sub

    Private Sub BtnGuardar_Click_1(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim frm As New frm_solicitud_mp_puas
        If validar_encabezado() Then
            If consecutivoPpal = "" Then
                If guardar_orden() Then
                    Dim solicitante As String = "890900160"
                    Dim observaciones As String = "Pedido automatico para puas desde el spic"
                    Dim devolver As String = "N"
                    frm.guardar_automatico(cbo_mat_prima.SelectedValue, txtCantProg.Text, cbo_fec_orden.Value.Month, cbo_fec_orden.Value.Year, solicitante, observaciones, devolver)
                    MessageBox.Show("La orden fue guardada de forma exitosa! ", "Correcto!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    nuevo()
                End If
            Else
                modificar_Orden()
                MessageBox.Show("La orden se ha actualizado de forma exitosa! ", "Correcto!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                nuevo()
            End If
        End If
    End Sub

    Private Sub CboFechaIni_ValueChanged(sender As Object, e As EventArgs) Handles cboFechaIni.ValueChanged
        If cargaComp = True Then
            cargarAdminProd(txtConsulNumOrd.Text)
        End If
    End Sub
    Private Sub CboFechaFin_ValueChanged(sender As Object, e As EventArgs) Handles cboFechaFin.ValueChanged
        If cargaComp = True Then
            cargarAdminProd(txtConsulNumOrd.Text)
        End If
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        nuevo()
        tbl_ppal.SelectedTab = pag_crear_orden
    End Sub


End Class