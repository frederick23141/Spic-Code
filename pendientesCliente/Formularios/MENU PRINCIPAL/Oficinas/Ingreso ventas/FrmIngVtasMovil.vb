Imports System.Configuration
Imports logicaNegocios
Imports entidadNegocios
Imports System.IO
Imports Microsoft.Office.Interop
#Disable Warning BC40056 ' El espacio de nombres o el tipo especificado en el 'System.Data.SqlServerCe' Imports no contienen ningún miembro público o no se encuentran. Asegúrese de que el espacio de nombres o el tipo se hayan definido y de que contengan al menos un miembro público. Asegúrese de que el nombre del elemento importado no use ningún alias.
Imports System.Data.SqlServerCe
#Enable Warning BC40056 ' El espacio de nombres o el tipo especificado en el 'System.Data.SqlServerCe' Imports no contienen ningún miembro público o no se encuentran. Asegúrese de que el espacio de nombres o el tipo se hayan definido y de que contengan al menos un miembro público. Asegúrese de que el nombre del elemento importado no use ningún alias.
Public Class FrmIngVtasMovil
    Private objClienteLn As New ClienteLn
    Private objEnvioCorreoLn As New EnvCorreoLN
    Private objUsuarioLn As New UsuarioLn
    Private objOperacionesForm As OperacionesFormularios = New OperacionesFormularios
    Private objOpSimplesLn As New Op_simpesLn
    Private objIngVtaLn As New IngVtasLn
    Private objUsuarioEn As New UsuarioEn
    Private vendedor As Double
    Private usuario_vend As Double
    ' Dim problem_precio_min As String = ""
    Dim cupo_disp As Double = 0
    Public problema As String = ""
    Public problemas_global As String = ""
    Public Estado_guardar = True
    Public modificar As Boolean = False
    Public numeroActualizar As Double
    Dim condicion As Integer
    Private nom_modulo As String = ""
    Dim tab_busc_cliente As String = ""
    Public aut_actualizar As String = ""
    Dim lista_precio As String
    Private objSegVendLn As New SegVendLn
    Public Sub Main(ByVal nom_modulo As String, ByVal objUsuarioEn As UsuarioEn)
        Me.nom_modulo = nom_modulo
        Me.objUsuarioEn = objUsuarioEn
        If (objUsuarioEn.permiso.Trim <> "ADMIN") Then
            btnContCambios.Visible = False
            If (objUsuarioEn.permiso.Trim = "VENDEDOR") Then
                lbl_cupo.Visible = False
                txt_cupo.Visible = False
            End If
        End If
        Me.Jjv_usuariosTableAdapter.Fill(Me.CORSANDataSet1.Jjv_usuarios)
        Dim ultimo_ped As Integer = objIngVtaLn.consec_ult_ped
        vendedor = objUsuarioEn.Vendedor
        usuario_vend = objUsuarioEn.Vendedor
        lblNroPedido.Text = "Ultimo pedido : " & ultimo_ped & ""
        txt_bodega.Text = objUsuarioEn.bodega
        Me.Size = New System.Drawing.Size(640, Screen.PrimaryScreen.WorkingArea.Height)
        Dim ano = Now.Year
        While (ano >= Now.Year - 5)
            cboAñoIni.Items.Add(ano)
            cboAñoFin.Items.Add(ano)
            ano -= 1
        End While
        cboAñoIni.SelectedItem = Now.Year
        cboAñoFin.SelectedItem = Now.Year
        cboMesIni.SelectedIndex = Now.Month - 1
        cboMesFin.SelectedIndex = Now.Month - 1

        cboAño.Items.Add(Now.Year)
        cboAño.Items.Add(Now.Year - 1)
        cboAño.SelectedIndex = 0
        cboMes.SelectedIndex = Now.Month - 1
    End Sub
    Private Sub btnContCambios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnContCambios.Click
        FrmAuditCambios.Show()
        FrmAuditCambios.Main(nom_modulo)
        FrmAuditCambios.WindowState = 2
    End Sub
   
    Private Sub txtNit_TextChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNit.KeyPress

        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
        If (e.KeyChar = Microsoft.VisualBasic.ChrW(13) And txtNit.Text <> "") Then
            Dim nit As Double = txtNit.Text
            nuevo()
            cargar_info_client(nit)

        End If

    End Sub
    Private Sub btnDetalle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim nit As Double = 0
        Dim resp As String = ""
        If txtNit.Text = "" Then
            Using New posicionar_messagebox(Me)
                resp = InputBox("Ingrese nit para ver detalle del cliente!", "ver despachos")
            End Using
            If (resp <> "") Then
                nit = resp
            End If
        Else
            nit = txtNit.Text
        End If
        If nit <> 0 Then
            If (usuario_vend = 1020 Or objIngVtaLn.clientDisponible(nit, vendedor)) Then
                frmPendientes.Show()
                frmPendientes.cargarInfoClient(nit)
                frmPendientes.Activate()
            Else
                Using New posicionar_messagebox(Me)
                    MessageBox.Show("Acceso denegado para ver la informacion de el cliente = " & nit & "", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Using
                txtNit.Text = ""
            End If
        End If

    End Sub
    Private Sub txtRef_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRef.TextChanged, txtRef.KeyPress
        If (txtRef.Text.Length > 4) Then
            Dim strSQL As String
            If txtRef.Text <> "" Then
                strSQL = "SELECT codigo, descripcion " & _
                      "FROM Referencias " & _
                      "WHERE codigo LIKE '" & txtRef.Text & "%' AND ref_anulada ='N' and codigo like ('3%')"
            Else
                strSQL = "SELECT codigo, descripcion  " & _
                         "FROM Referencias " & _
                "WHERE ref_anulada ='N' and codigo like ('3%')"
            End If
            DtgDetalleRef.DataSource = objIngVtaLn.listarRef(strSQL)
        End If
    End Sub
    Private Sub DtgDetalleRef_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DtgDetalleRef.CellDoubleClick
        txtCod.Text = DtgDetalleRef.Item(0, e.RowIndex).Value
        txtDesc.Text = DtgDetalleRef.Item(1, e.RowIndex).Value
        txtCant.Text = 0
        TxtVrUnit.Text = 0
        txtVrTot.Text = 0
        txtCant.Focus()
    End Sub

    Private Sub TxtVrUnit_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtVrUnit.TextChanged
        If (txtCant.Text <> "" And TxtVrUnit.Text <> "") Then
            txtVrTot.Text = Format((Convert.ToDouble(txtCant.Text) * Convert.ToDouble(TxtVrUnit.Text)), "C0")
        Else
            txtVrTot.Text = Format(0, "C0")
        End If
    End Sub

    Private Sub txtCant_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCant.TextChanged
        If (txtCant.Text <> "" And TxtVrUnit.Text <> "") Then
            txtVrTot.Text = Format((Convert.ToDouble(txtCant.Text) * Convert.ToDouble(TxtVrUnit.Text)), "C0")
        Else
            txtVrTot.Text = Format(0, "C0")
        End If
    End Sub



    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        Dim valTotPedido As Double = 0
        Dim errores As Boolean = False
        Dim cod_rep As Boolean = False
        Dim Precio_unitario As Double = 0
        Dim vr_unit As Double = Convert.ToDouble(TxtVrUnit.Text)
        Dim precioMin As Double
        If lista_precio <> "" Then
            Precio_unitario = objIngVtaLn.precio_lista(txtCod.Text, lista_precio)
        End If
        If Precio_unitario > 0 Then
            precioMin = Precio_unitario 'OJO ACA USTED ESTA HACIENDO MISMO EL PRECIO MINIMO
            'Dim costo_menos_10 As Double = (precioMin * 0.88) * 0.9
            'Dim costo_mas_40 As Double = (precioMin * 0.88) * 1.5
            Dim costo_menos_10 As Double = (Precio_unitario) * 0.9
            Dim costo_mas_90 As Double = (Precio_unitario) * 1.9
            For i = 0 To dtgPedido.RowCount - 1
                If (dtgPedido.Item("cod", i).Value = txtCod.Text) Then
                    cod_rep = True
                End If
            Next
            If (cod_rep = False) Then
                If (txtCant.Text <> "" And txtCod.Text <> "" And TxtVrUnit.Text <> "" And txtVrTot.Text <> "") Then
                    If (vr_unit > costo_menos_10) Then
                        If (vr_unit < costo_mas_90) Then
                            Dim vec(6) As Object
                            Dim resp As Integer = 6
                            Dim vrTotal As Double = 0
                            Dim subTotal As Double = 0
                            Dim iva As Double = objOpSimplesLn.getIvaPorc()
                            If (vr_unit < precioMin) Then
                                Using New posicionar_messagebox(Me)
                                    resp = MessageBox.Show("Valor unitario esta por debajo de el precio minimo de venta! que es: " & precioMin.ToString("C0") & " Desea ingresarlo para su gestiòn? ", "Còdigo", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                                End Using
                                If (resp = 6) Then
                                    'problem_precio_min = "P"
                                    vec(6) = Convert.ToDouble(precioMin)
                                End If
                            Else
                                vec(6) = 0
                            End If
                            If (resp = 6) Then
                                If (txtCod.Text <> "" And txtDesc.Text <> "" And txtCant.Text > 0 And TxtVrUnit.Text > 0 And txtVrTot.Text > 0) Then
                                    vrTotal = (Convert.ToDouble(txtCant.Text) * Convert.ToDouble(TxtVrUnit.Text))
                                    vec(0) = "Borrar"
                                    vec(1) = txtCod.Text
                                    vec(2) = txtDesc.Text
                                    vec(3) = Convert.ToDouble(txtCant.Text)
                                    vec(4) = Convert.ToDouble(TxtVrUnit.Text)
                                    vec(5) = vrTotal
                                    dtgPedido.Rows.Add(vec)
                                    valTotPedido = (sumarValorPedido())
                                    txtSubtot.Text = (valTotPedido).ToString("C0")
                                    txt_vr_iva.Text = (valTotPedido * iva).ToString("C0")
                                    txt_tot.Text = (valTotPedido * (iva + 1)).ToString("C0")
                                Else
                                    errores = True
                                    Using New posicionar_messagebox(Me)
                                        MessageBox.Show("Verifique que todos los items del pedido estem llenos! ", "Campos", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    End Using
                                End If
                            End If
                        Else
                            errores = True
                            Using New posicionar_messagebox(Me)
                                MessageBox.Show("El precio para esta referencia esta muy por encima del valor unitario, verifique el valor ingresado", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End Using
                        End If

                    Else
                        errores = True
                        Using New posicionar_messagebox(Me)
                            MessageBox.Show("El precio para esta referencia esta por debajo del minimo requerido que es " & costo_menos_10 & ", ingrese la referencia nuevamente!", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Using
                    End If


                Else
                    errores = True
                    Using New posicionar_messagebox(Me)
                        MessageBox.Show("Campos requeridos para esta operaciòn estan vacios", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Using
                End If
            Else
                errores = True
                Using New posicionar_messagebox(Me)
                    MessageBox.Show("El codigo " & txtCod.Text & " ya se encuentra en los items del pedido!", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Using
            End If
        Else
            precioMin = Precio_unitario / 0.88 'OJO ACA USTED ESTA HACIENDO MISMO EL PRECIO MINIMO
            'Dim costo_menos_10 As Double = (precioMin * 0.88) * 0.9
            'Dim costo_mas_40 As Double = (precioMin * 0.88) * 1.5
            Dim costo_menos_10 As Double = (Precio_unitario) * 0.9
            Dim costo_mas_90 As Double = (Precio_unitario) * 1.9
            For i = 0 To dtgPedido.RowCount - 1
                If (dtgPedido.Item("cod", i).Value = txtCod.Text) Then
                    cod_rep = True
                End If
            Next
            If (cod_rep = False) Then
                If (txtCant.Text <> "" And txtCod.Text <> "" And TxtVrUnit.Text <> "" And txtVrTot.Text <> "") Then
                    Dim vec(6) As Object
                    Dim resp As Integer = 6
                    Dim vrTotal As Double = 0
                    Dim subTotal As Double = 0
                    Dim iva As Double = objOpSimplesLn.getIvaPorc()
                    If (vr_unit < precioMin) Then
                        Using New posicionar_messagebox(Me)
                            resp = MessageBox.Show("Valor unitario esta por debajo de el precio minimo de venta! que es: " & precioMin.ToString("C0") & " Desea ingresarlo para su gestiòn? ", "Còdigo", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                        End Using
                        If (resp = 6) Then
                            'problem_precio_min = "P"
                            vec(6) = Convert.ToDouble(precioMin)
                        End If
                    Else
                        vec(6) = 0
                    End If
                    If (resp = 6) Then
                        If (txtCod.Text <> "" And txtDesc.Text <> "" And txtCant.Text > 0 And TxtVrUnit.Text > 0 And txtVrTot.Text > 0) Then
                            vrTotal = (Convert.ToDouble(txtCant.Text) * Convert.ToDouble(TxtVrUnit.Text))
                            vec(0) = "Borrar"
                            vec(1) = txtCod.Text
                            vec(2) = txtDesc.Text
                            vec(3) = Convert.ToDouble(txtCant.Text)
                            vec(4) = Convert.ToDouble(TxtVrUnit.Text)
                            vec(5) = vrTotal
                            dtgPedido.Rows.Add(vec)
                            valTotPedido = (sumarValorPedido())
                            txtSubtot.Text = (valTotPedido).ToString("C0")
                            txt_vr_iva.Text = (valTotPedido * iva).ToString("C0")
                            txt_tot.Text = (valTotPedido * (iva + 1)).ToString("C0")
                        Else
                            errores = True
                            Using New posicionar_messagebox(Me)
                                MessageBox.Show("Verifique que todos los items del pedido estem llenos! ", "Campos", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End Using
                        End If
                    End If
                Else
                    errores = True
                    Using New posicionar_messagebox(Me)
                        MessageBox.Show("Campos requeridos para esta operaciòn estan vacios", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Using
                End If
            Else
                errores = True
                Using New posicionar_messagebox(Me)
                    MessageBox.Show("El codigo " & txtCod.Text & " ya se encuentra en los items del pedido!", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Using
            End If
                End If
                If Not (errores) Then
                    errores = False
                    txtRef.Focus()
                    txtCod.Text = ""
                    txtDesc.Text = ""
                    txtCant.Text = ""
                    TxtVrUnit.Text = ""
                    txtVrTot.Text = ""
                    txtRef.Text = ""
                End If
    End Sub
    Private Function sumarValorPedido() As Double
        Dim tot As Double = 0
        For i = 0 To dtgPedido.RowCount - 1
            tot += dtgPedido.Item("colVrTotal", i).Value
        Next
        Return tot
    End Function
    Private Function sumarColGrid(ByVal col As String) As Double
        Dim sum As Double = 0
        For i = 0 To dtgPedido.RowCount - 1
            If Not IsNothing(dtgPedido.Item(col, i).Value) Then
                sum += dtgPedido.Item(col, i).Value
            End If
        Next
        Return sum
    End Function
    Private Sub dtgPedido_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgPedido.CellContentClick
        If (e.ColumnIndex = 0 And e.RowIndex <> -1) Then
            Dim vrTotPedido As Double = 0
            Dim iva As Double = objOpSimplesLn.getIvaPorc()
            dtgPedido.Rows.RemoveAt(e.RowIndex)
            vrTotPedido = sumarValorPedido()
            txt_tot.Text = (vrTotPedido * (iva + 1)).ToString("C0")
            txt_vr_iva.Text = (vrTotPedido * iva).ToString("C0")
            txtSubtot.Text = (vrTotPedido).ToString("C0")
        End If
    End Sub

    Private Sub txtRef_TextChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRef.KeyPress
        Dim desc As String
        Dim ref As String = ""
        If Char.IsPunctuation(e.KeyChar) Then
            e.Handled = True
        End If
        If (e.KeyChar = Microsoft.VisualBasic.ChrW(13) And txtRef.Text <> "") Then
            If (DtgDetalleRef.RowCount > 0) Then
                ref = DtgDetalleRef.Item(0, 0).Value
                desc = objIngVtaLn.descProd(ref)
                txtCod.Text = ref
                txtDesc.Text = desc
                txtCant.Text = 0
                TxtVrUnit.Text = 0
                txtVrTot.Text = 0
                txtCant.Focus()
            Else
                Using New posicionar_messagebox(Me)
                    MessageBox.Show("El còdigo " & txtRef.Text & " no existe ò no esta disponible!", "Còdigo", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Using
            End If
        End If

    End Sub
    Private Sub btn_clientes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_clientes.Click
        tab_busc_cliente = tab_ing_ped.Name
        groupCliente.Visible = True
        txtNomBuscCliente.Focus()
    End Sub
    Private Sub txt_nombres_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txt_nombres.MouseClick
        btn_clientes.PerformClick()
    End Sub
    Public Sub cargar_info_client(ByVal nit As Double)
        nuevo()
        txtNit.Text = nit
        If (usuario_vend = 1020 Or objIngVtaLn.clientDisponible(nit, vendedor)) Then
            Dim vendedores As String = objUsuarioLn.coordinadorVend(objUsuarioEn.usuario)
            habilitar(True)
            Dim vec_datos As Object = objIngVtaLn.infoCliente(nit)
            condicion = vec_datos(6)
            Dim sql As String
            Dim cartVencida As Double = vec_datos(7)
            Dim cupo As Double = vec_datos(5)
            Dim cartera As Double = vec_datos(2)
            Dim anticipo As Double = valorAnticipo(nit)
            Dim iva As Double = objOpSimplesLn.getIvaPorc()
            If (condicion = 208 Or condicion = 202) Then
                cupo = vec_datos(5)
            ElseIf (condicion = 201) Then
                cupo = 0
            Else
                If (cupo <> 0) Then
                    If (cupo >= 100000 And cupo <= 20000000) Then
                        cupo = cupo * 1.3
                    ElseIf (cupo >= 21000000 And cupo <= 40000000) Then
                        cupo = cupo * 1.2
                    ElseIf (cupo >= 41000000 And cupo <= 80000000) Then
                        cupo = cupo * 1.1
                    End If
                End If
            End If
            Dim vr_Pend As Double = vec_datos(4) * (iva + 1)
            Dim resp_no_mov As Integer = 6
            Dim resp_cond As Integer = 6
            vendedor = objClienteLn.getVendedor(nit)
            txt_vend.Text = vendedor
            cupo_disp = Convert.ToDouble(cupo - vr_Pend - cartera)
            If (objClienteLn.existeUsuarioTERCEROS(nit, vendedores)) Then
                If Not (objIngVtaLn.doc_venc_mas_30(nit)) Then
                    If Not (vec_datos(1) = 2) Then
                        If ((condicion = 201 Or condicion = 208)) Then
                            If (condicion = 201) Then
                                If (anticipo <= 0 Or cupo_disp <= 0) Then
                                    nuevo()
                                    habilitar(False)
                                    Using New posicionar_messagebox(Me)
                                        MessageBox.Show("El cliente es de contado y no tiene anticipos, comuniquese con cartera para su gestión", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                    End Using
                                    cargar_informes_cliente(nit)
                                    Exit Sub
                                End If
                            ElseIf (condicion = 208) Then
                                If (cartVencida > 0) Then
                                    Using New posicionar_messagebox(Me)
                                        MessageBox.Show("El cliente es de contado y tiene cartera vencida,debe cancelar para ingresar el pedido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                    End Using
                                    nuevo()
                                    cargar_informes_cliente(nit)
                                    habilitar(False)
                                    Exit Sub
                                End If
                            End If
                            If (cupo_disp <= 0) Then
                                Using New posicionar_messagebox(Me)
                                    resp_cond = MessageBox.Show("El cliente es de contado y no tiene cupo disponible, el pedido sera ingresado para su gestion, esta deacuerdo ? ", "Atención", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                                End Using
                                problema = "X"
                                aut_actualizar = "N"
                                problemas_global = problema
                            Else
                                Using New posicionar_messagebox(Me)
                                    MessageBox.Show("El cliente es de contado y tiene cupo disponible de: " & cupo_disp.ToString("C0") & " ", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                End Using
                            End If
                        End If
                        If (objIngVtaLn.mov_180_dias(nit) = False) Then
                            If Not (objIngVtaLn.esNuevo(nit)) Then
                                Using New posicionar_messagebox(Me)
                                    resp_no_mov = MessageBox.Show("El nit   = " & nit & " no a tenido movimiento en los ultimos 180 días,el pedido sera ingresado para su gestion, favor comunicarse con cartera y actualizar los documentos!, esta deacuerdo ? ", "Atención", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                                End Using
                                problema = "X"
                                aut_actualizar = "N"
                                problemas_global += "X"
                            End If
                        End If
                        Sql = "Select lista from terceros where nit=" & txtNit.Text & ""
                        lista_precio = objOpSimplesLn.consultValorTodo(Sql, "CORSAN")
                        If lista_precio = "" Or (lista_precio <> "1" And lista_precio <> "2" And lista_precio <> "3" And lista_precio <> "4" And lista_precio <> "5" And lista_precio <> "6") Then
                            problema = "L"
                            aut_actualizar = "N"
                            problemas_global += "L"
                            MessageBox.Show("El cliente no tiene lista de precio por lo tanto su pedido se ira  a los no reflejados", "Cliente sin lista de precios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                        If (resp_no_mov = 6 And resp_cond = 6) Then
                            txtCupo.Text = cupo.ToString("C0")
                            txt_tot_pend.Text = vr_Pend.ToString("C0")
                            txt_nombres.Text = vec_datos(0)
                            txt_cartera.Text = Convert.ToDouble(vec_datos(2)).ToString("C0")
                            txt_cheq_dev.Text = Convert.ToDouble(vec_datos(3)).ToString("C0")
                            txtCondicion.Text = condicion
                            If (cupo_disp <= 0) Then
                                txt_cupo.ForeColor = Color.Red
                                txtCupoDisResumen.ForeColor = Color.Red
                            Else
                                txt_cupo.ForeColor = Color.Black
                                txtCupoDisResumen.ForeColor = Color.Black
                            End If
                            txt_cupo.Text = cupo_disp.ToString("C0")
                            txtCupoDisResumen.Text = cupo_disp.ToString("C0")
                            Select Case vec_datos(1)
                                Case 0
                                    txt_estado.Text = "Activo"
                                Case 1
                                    txt_estado.Text = "Inactivo"
                                Case 2
                                    txt_estado.Text = "Bloqueado"
                                Case 3
                                    txt_estado.Text = "No usar"
                            End Select
                            txtRef.Focus()
                            cargar_informes_cliente(nit)
                        Else
                            nuevo()
                        End If
                    Else
                        Using New posicionar_messagebox(Me)
                            MessageBox.Show("El cliente se encuentra bloqueado por lo tanto no se le pueden ingresar pedidos.", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Using
                        cargar_informes_cliente(nit)
                        habilitar(False)
                    End If
                Else
                    Using New posicionar_messagebox(Me)
                        MessageBox.Show("El cliente tiene FACTURAS VENCIDAS A MÁS DE 30 DÍAS por lo tanto no se le pueden ingresar pedidos.", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Using
                    enviarCorreo(vendedor, vec_datos(0))
                    cargar_informes_cliente(nit)
                    habilitar(False)
                End If

            Else
                Using New posicionar_messagebox(Me)
                    MessageBox.Show("El nit   = " & nit & " no existe ó no tiene permisos para ver su información", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Using
                habilitar(False)
            End If

            ' MessageBox.Show("El nit   = " & nit & " es cliente de contado y no tiene anticipo,por favor comunicarse con cartera!", "Cartera", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            Using New posicionar_messagebox(Me)
                MessageBox.Show("Acceso denegado para ver la informacion de el cliente = " & nit & "", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Using
            txtNit.Text = ""
            habilitar(False)
        End If
        ' problem_precio_min = ""


    End Sub
    Private Sub cargar_informes_cliente(ByVal nit As Double)
        txtNitPendientes.Text = nit
        txtNitCartera.Text = nit
        txtNitFact.Text = nit
        txtNombCartera.Text = txt_nombres.Text
        txtNombresPend.Text = txt_nombres.Text
        txtNombFact.Text = txt_nombres.Text
        listarPend(nit)
        listarFacturacion(nit)
        listarCartera(nit)
        listarAnticipos(nit)
    End Sub
    Private Sub enviarCorreo(ByVal vendedor As String, ByVal nombres As String)
        imgProc.Visible = True
        Application.DoEvents()
        Dim direccion As String = ""
        Dim texto As String = "El vendedor " & vendedor & " intento ingresar un pedido al cliente " & nombres & " con facturación vendcida a mas"
        Dim titulo As String = "Cliente con factura vencida a más de 30 días"
        Dim destino As String = objOpSimplesLn.consultarVal("SELECT u.Mail from jjv_usuarios u, J_spic_coord_vend c WHERE u.Autorizacion ='COOR_VTAS' AND u.usuario = c.usuario AND c.vendedor = " & vendedor & "")
        If (destino <> "") Then
            Dim email As String = objOpSimplesLn.consultarVal("SELECT Mail from jjv_usuarios WHERE usuario ='ADMIN'")
            Dim contra As String = objOpSimplesLn.consultarVal("SELECT Mail_login from jjv_usuarios WHERE usuario ='ADMIN'")
            If Not (objEnvioCorreoLn.EnviarCorreo(destino, texto, titulo, direccion, email, contra, False)) Then
                Using New Centered_MessageBox(Me)
                    MessageBox.Show("Error al enviar el correo,comuniquese con el administrador del sistema!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End Using
            End If
        End If
        imgProc.Visible = False
    End Sub
    Private Function valorAnticipo(ByVal nit As String) As Double
        Dim resp As Boolean = False
        Dim sql As String = "SELECT SUM (saldo ) FROM V_cartera_edades_jjv cart WHERE cart.saldo <0 AND cart.valor_aplicado =0 AND cart.nit = " & nit
        Dim anticipo As String = objOpSimplesLn.consultarVal(sql)
        If (anticipo = "") Then
            anticipo = 0
        End If
        Return Convert.ToDouble(anticipo * -1)
    End Function
    Private Sub btnDespachos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If txtNit.Text = "" Then
            Using New posicionar_messagebox(Me)
                MessageBox.Show("Ingrese un cliente!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Using
        Else

            frmDespacho.Show()
            frmDespacho.Main(txtNit.Text, vendedor)
            frmDespacho.Activate()
        End If
    End Sub
    Private Sub txtCant_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCant.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
        If (e.KeyChar = Microsoft.VisualBasic.ChrW(13)) Then
            TxtVrUnit.Focus()
        End If
    End Sub
    Private Sub TxtVrUnit_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtVrUnit.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
        If (e.KeyChar = Microsoft.VisualBasic.ChrW(13)) Then
            btnAgregar.Focus()
            btnAgregar.PerformClick()
        End If
    End Sub
    Public Function QuitarComasypesos(ByVal strNumero As String) As String

        Dim I As Integer
        Dim iLen As Integer
        Dim SW As Integer = 0
        Dim strAux As String
        Dim strChar As String
        strAux = ""

        iLen = Len(strNumero)
        If (iLen > 1) Then
            For I = 2 To iLen

                strChar = Mid(strNumero, I, 1)

                If strChar <> "," Then
                    If (strChar = ".") Then
                        SW = 1
                    Else
                        If (strChar = "(" Or strChar = ")" Or strChar = "$") Then
                            SW = 1
                        End If
                    End If
                    If SW = 0 Then
                        strAux = strAux & strChar
                    End If
                End If
            Next
        Else
            strAux = "0"
        End If

        QuitarComasypesos = strAux

    End Function
    Function quitarEspeciales(ByVal s As String)
        Dim Filtro As String = "{}[]!#$%&/()=?¡'¿|*+¨´:.;,<>"
        Dim I As Integer
        For I = 1 To Len(Filtro)
            s = Replace(s, Mid(Filtro, I, 1), "")
        Next
        quitarEspeciales = s
    End Function
    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click
        If (txt_nombres.Text = objClienteLn.nombres(txtNit.Text)) Then
            If (txt_bodega.Text <> "") Then
                If (dtgPedido.RowCount > 0) Then
                    If (txtNotas.Text <> "" And txt_notas_opc.Text <> "" And txtNota5.Text <> "") Then
                        Dim rechazo As String = ""
                        Dim cupo As Double = cupo_disp
                        Dim total As Double = Convert.ToDouble(QuitarComasypesos(txt_tot.Text))
                        Dim bloqueo As Integer = objIngVtaLn.cons_bloqueo(txtNit.Text)
                        Dim pro_precio_min As String = ""
                        Dim correo As String = ""
                        Dim fax As String = ""
                        If (condicion = 202) Then
                            fax = objOpSimplesLn.consultarVal("SELECT fax FROM terceros where nit = " & txtNit.Text)
                            If (fax <> "") Then
                                txtNotas.Text += " - Facturar y enviar por fax"
                            Else
                                correo = objOpSimplesLn.consultarVal("SELECT mail FROM terceros where nit = " & txtNit.Text)
                                txtNotas.Text += " - Facturar y enviar por correo electronico: " & correo
                            End If
                        ElseIf (condicion = 201) Then
                            txtNotas.Text += "  - Pago anticipado"
                        End If

                        If Not (problema = "X") Then
                            If (objIngVtaLn.doc_ven(txtNit.Text) <> "") Then
                                problema = "V"
                                aut_actualizar = "N"
                                problemas_global &= problema
                            End If
                            If (problema = "P") Then problema = ""
                            For i = 0 To dtgPedido.RowCount - 1
                                If (dtgPedido.Item("p_min", i).Value <> 0) Then
                                    If (pro_precio_min = "") Then
                                        problemas_global &= "P"
                                        aut_actualizar = "N"
                                    End If
                                    pro_precio_min = "P"
                                End If
                            Next
                            If (bloqueo <> 0) Then
                                problema = "B"
                                aut_actualizar = "N"
                                problemas_global &= problema
                            End If
                            If (cupo - total) < 0 Then
                                problema = "C"
                                aut_actualizar = "N"
                                problemas_global &= problema
                            End If
                        Else
                            If (problema = "X") Then
                                If (cupo - total) >= 0 Then
                                    If (objIngVtaLn.doc_ven(txtNit.Text) <> "") Then
                                        problema = "V"
                                        aut_actualizar = "N"
                                        problemas_global &= problema
                                    End If
                                    If (problema = "P") Then problema = ""
                                    For i = 0 To dtgPedido.RowCount - 1
                                        If (dtgPedido.Item("p_min", i).Value <> 0) Then
                                            pro_precio_min = "P"
                                            aut_actualizar = "N"
                                            problemas_global &= pro_precio_min
                                        End If
                                    Next
                                    If (bloqueo <> 0) Then
                                        problema = "B"
                                        aut_actualizar = "N"
                                        problemas_global &= problema
                                    End If
                                End If
                            End If
                        End If
                        If (problema = "" And pro_precio_min = "") Then
                            If (Estado_guardar) Then
                                If (guardar(problema, "") = True) Then
                                    Using New posicionar_messagebox(Me)
                                        MessageBox.Show("El pedido fue ingresado en forma exitosa!", "Exito!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    End Using
                                    nuevo()
                                Else
                                    Using New posicionar_messagebox(Me)
                                        MessageBox.Show("Erroe al insertar!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    End Using
                                End If
                            Else
                                If (actualizar_pedido(problema) = 1) Then
                                    Using New posicionar_messagebox(Me)
                                        MessageBox.Show("El pedido fue actualizado en forma exitosa!", "Exito!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    End Using
                                    nuevo()
                                Else
                                    Using New posicionar_messagebox(Me)
                                        MessageBox.Show("Error al actuzalizar!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    End Using
                                End If
                            End If

                        Else
                            If (problema = "X") Then
                                aut_actualizar = "N"
                                rechazo = "INACTIVIDAD POR 180 DÍAS"
                            End If
                            If (problema = "C") Then
                                aut_actualizar = "N"
                                rechazo = "CUPO CREDITO"
                            End If
                            If (problema = "V") Then
                                aut_actualizar = "N"
                                rechazo = "FACTURACIÓN VENCIDA"
                            End If
                            If (problema = "B") Then
                                aut_actualizar = "N"
                                rechazo = "BLOQUEO"
                            End If
                            If (pro_precio_min <> "") Then
                                rechazo += " Precio minimo de venta"
                                If (problema = "") Then
                                    problema = pro_precio_min
                                End If
                            End If
                            Dim iResponce As String = ""
                            Using New posicionar_messagebox(Me)
                                iResponce = MessageBox.Show("El pedido sera ingresado con problemas de: " & rechazo & "! para su gestiòn esta deacuerdo ? ", "Atención", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                            End Using
                            If (iResponce = 6) Then
                                btn_compromiso.PerformClick()
                            End If
                        End If
                    Else
                        Using New posicionar_messagebox(Me)
                            MessageBox.Show("Los campos de notas  no pueden ser ingresados vacios!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Using
                    End If
                Else
                    Using New posicionar_messagebox(Me)
                        MessageBox.Show("El pedido esta vacio!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Using
                End If
            Else
                Using New posicionar_messagebox(Me)
                    MessageBox.Show("El campo para la bodega esta vacio!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Using
            End If
        Else
            Using New posicionar_messagebox(Me)
                MessageBox.Show("La cartera no coinside con el cliente!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Using
        End If

    End Sub
    Public Sub guardar_con_probl(ByVal compromiso As String)
        If (Estado_guardar) Then
            If (guardar(problema, compromiso) = True) Then
                Using New posicionar_messagebox(Me)
                    MessageBox.Show("El pedido fue ingresado en forma exitosa!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End Using
                nuevo()
                Frm_compromiso.Close()
                Frm_compromiso.Activate()
            Else
                Using New posicionar_messagebox(Me)
                    MessageBox.Show("Error al insertar!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Using
            End If
        Else
            If (actualizar_pedido(problema) = 1) Then
                Using New posicionar_messagebox(Me)
                    MessageBox.Show("El pedido fue actualizado en forma exitosa!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End Using
                nuevo()
                Frm_compromiso.Close()
            Else
                Using New posicionar_messagebox(Me)
                    MessageBox.Show("Error al actualizar!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Using
            End If
        End If

    End Sub
    Public Function guardar(ByVal problema As String, ByVal compromiso As String) As Boolean
        Dim listSql As New List(Of Object)
        Dim sql As String = ""
        Dim sw = 1
        Dim bodega As Integer = Convert.ToInt16(txt_bodega.Text)
        Dim numero As Double = objIngVtaLn.consec_ult_ped + 1
        Dim nit As Double = Convert.ToDouble(txtNit.Text)
        Dim condicion As String = objIngVtaLn.get_condicion(nit)
        Dim dias_validez As Integer = 100
        Dim tot_neto As Double = Convert.ToDouble(QuitarComasypesos(txt_tot.Text))
        Dim strUsuario As String = objUsuarioEn.usuario
        Dim strPC As String = EliminarEspeciales(My.Computer.Name)
        ' Dim compromiso As String = txt_compromiso.Text
        Dim notas As String = txtNotas.Text
        Dim resp As Boolean = False
        Dim vend As Integer = 0
        Dim notaVenta As String = txt_notas_opc.Text
        Dim nota5 As String = txtNota5.Text
        'If (vendedor = 1020) Then
        '    vend = objclienteLn.getVendedor(nit)
        'Else
        '    vend = vendedor
        'End If
        If aut_actualizar = "" Then
            aut_actualizar = "A"
        End If
        Dim sql_fecha As String = "SELECT GETDATE()"
        Dim fechar As Date = Convert.ToDateTime(objOpSimplesLn.consultValorTodo(sql_fecha, "CORSAN"))
        Dim fecha As String

        fecha = Format(fechar, "yyyy-M-d H:mm:ss")

        vend = vendedor

        objIngVtaLn.update("UPDATE consecutivos " & _
                  "SET siguiente = " & numero & " " & _
                  "WHERE tipo = 'ZPE1'")

        If (problema <> "") Then
            If (problema = "B") Then
                problema = "B"
            End If
            notaVenta &= "Problemas = " & problemas_global
            sql = "INSERT INTO JJV_documentos_ped (sw, bodega, " & _
               "             numero, nit, vendedor, fecha, condicion, " & _
               "             dias_validez, descuento_pie, valor_total, " & _
               "             fecha_hora, usuario, pc, duracion, anulado, autorizacion, nit2,notas,notas_aut,nota_vta,notas5,Problema) " & _
               "VALUES(" & sw & ", " & bodega & ", " & _
                           numero & ", " & nit & ", " & _
                           vend & ",GETDATE (),'" & condicion & "', " & _
                           dias_validez & ", 0, " & tot_neto & ", GETDATE () ,'" & _
                            strUsuario & "', '" & strPC & "', 100, 0,'A', " & nit & ",'" & notas & "', '" & compromiso & "','" & notaVenta & "','" & nota5 & "','" & problemas_global & "' )"
            listSql.Add(sql)

            sql = "INSERT INTO documentos_ped_aux (vendedor,fecha,valor_total,nit,numero)" & _
              "VALUES(" & vend & ",'" & fecha & "'," & tot_neto & "," & nit & "," & numero & ")"
            listSql.Add(sql)

            With dtgPedido
                For i = 0 To .RowCount - 1
                    sql = "INSERT INTO JJV_documentos_lin_ped " & _
                             "(sw, bodega, numero, codigo, seq, " & _
                             " cantidad, valor_unitario, " & _
                             " cantidad_despachada, porcentaje_iva, porcentaje_descuento, und, cantidad_und, " & _
                             " despacho_virtual, porc_dcto_2, porc_dcto_3,precio_si_costo_cero) " & _
                             "VALUES(" & sw & ", " & bodega & ", " & numero & ", '" & _
                                         .Item(1, i).Value & "', " & i & ", " & _
                                        .Item(3, i).Value & ", " & _
                                         .Item(4, i).Value & ", 0, 19, 0, 'UND', 1, " & _
                                           .Item(3, i).Value & ", 0, 0," & .Item(6, i).Value & ")"
                    listSql.Add(sql)
                Next
            End With
        Else
            'Este compromiso se añade en esta parte por la peticion de colocar de nuevo este campo de notas 2013-04-23
            compromiso = txt_notas_opc.Text
            sql = "INSERT INTO documentos_ped (sw, bodega, " & _
                   "             numero, nit, vendedor,codigo_direccion,fecha, condicion, " & _
                   "             dias_validez, descuento_pie, valor_total, " & _
                   "             fecha_hora, usuario, pc, duracion, anulado, nit2,notas,nota_vta,notas5,autorizacion) " & _
                   "VALUES(" & sw & ", " & bodega & ", " & _
                               numero & ", " & nit & ", " & _
                               vend & ",0,GETDATE (),'" & condicion & "', " & _
                               dias_validez & ", 0, " & tot_neto & ", GETDATE () ,'" & _
                                 strUsuario & "', '" & strPC & "', 100, 0, " & nit & ",'" & notas & "','" & notaVenta & "','" & nota5 & "','A')"
            listSql.Add(sql)

            sql = "INSERT INTO documentos_ped_aux (vendedor,fecha,valor_total,nit,numero)" & _
            "VALUES(" & vend & ",'" & fecha & "'," & tot_neto & "," & nit & "," & numero & ")"
            listSql.Add(sql)

            With dtgPedido
                For i = 0 To .RowCount - 1
                    sql = "INSERT INTO documentos_lin_ped " & _
                             "(sw, bodega, numero, codigo, seq, " & _
                             " cantidad, valor_unitario, " & _
                             " cantidad_despachada, porcentaje_iva, porcentaje_descuento, und, cantidad_und, " & _
                             " despacho_virtual, porc_dcto_2, porc_dcto_3) " & _
                             "VALUES(" & sw & ", " & bodega & ", " & numero & ", '" & _
                                         .Item(1, i).Value & "', " & i & ", " & _
                                        .Item(3, i).Value & ", " & _
                                         .Item(4, i).Value & ", 0, 19, 0, 'UND', 1, " & _
                                           .Item(3, i).Value & ", 0, 0)"
                    listSql.Add(sql)
                Next
            End With
        End If
        resp = objOpSimplesLn.ExecuteSqlTransaction(listSql)
        Return resp

    End Function

    Private Function actualizar_pedido(ByVal problema As String) As Boolean
        Dim listaSql As New List(Of Object)
        Dim sql As String = ""
        Dim sw = 1
        Dim bodega As Integer = Convert.ToInt16(txt_bodega.Text)
        Dim nit As Double = Convert.ToDouble(txtNit.Text)
        Dim condicion As String = objIngVtaLn.get_condicion(nit)
        Dim dias_validez As Integer = 100
        Dim tot_neto As Double = Convert.ToDouble(QuitarComasypesos(txt_tot.Text))
        Dim strUsuario As String = EliminarEspeciales(My.Computer.Name)
        Dim strPC As String = EliminarEspeciales(My.User.Name)
        Dim compromiso As String = txt_notas_opc.Text
        Dim notas As String = txtNotas.Text
        Dim resp As Boolean = False
        Dim vend As Integer = 0
        'If (vendedor = 1020) Then
        '    vend = cbo_vendedores.SelectedValue
        'Else
        '    vend = vendedor
        'End If
        vend = vendedor
        sql = "DELETE FROM documentos_ped WHERE numero =" & numeroActualizar
        listaSql.Add(sql)
        sql = "DELETE FROM documentos_lin_ped WHERE numero =" & numeroActualizar
        listaSql.Add(sql)
        If (problema <> "") Then
            If (problema = "B") Then
                problema = "B"
            End If

            sql = "UPDATE JJV_documentos_ped " & _
                  "SET bodega = " & bodega & ",valor_total = " & tot_neto & ",notas = '" & notas & "',usuario = '" & strUsuario & "',pc = '" & strPC & "',autorizacion ='" & problema & "',notas_aut = '" & compromiso & "' " & _
                  "WHERE numero = " & numeroActualizar & " and nit = " & nit & " "

            listaSql.Add(sql)
            sql = "DELETE FROM JJV_documentos_lin_ped WHERE numero = " & numeroActualizar & ""
            listaSql.Add(sql)
            sql = ""
            With dtgPedido
                For i = 0 To .RowCount - 1
                    sql = "INSERT INTO JJV_documentos_lin_ped " & _
                             "(sw, bodega, numero, codigo, seq, " & _
                             " cantidad, valor_unitario, " & _
                             " cantidad_despachada, porcentaje_iva, porcentaje_descuento, und, cantidad_und, " & _
                             " despacho_virtual, porc_dcto_2, porc_dcto_3,precio_si_costo_cero) " & _
                             "VALUES(" & sw & ", " & bodega & ", " & numeroActualizar & ", '" & _
                                         .Item(1, i).Value & "', " & i & ", " & _
                                        .Item(3, i).Value & ", " & _
                                         .Item(4, i).Value & ", 0, 19, 0, 'UND', 1, " & _
                                           .Item(3, i).Value & ", 0, 0," & .Item(6, i).Value & ")"
                    listaSql.Add(sql)
                Next
            End With
        Else
            sql = "UPDATE JJV_documentos_ped SET anulado =  1 where numero = " & numeroActualizar
            listaSql.Add(sql)
            objIngVtaLn.eliminar("DELETE FROM documentos_lin_ped WHERE numero = " & numeroActualizar)
            objIngVtaLn.eliminar("DELETE FROM documentos_lin_ped WHERE numero = " & numeroActualizar)
            sql = "INSERT INTO documentos_ped (sw, bodega, " & _
                   "             numero, nit, vendedor, fecha, condicion, " & _
                   "             dias_validez, descuento_pie, valor_total, " & _
                   "             fecha_hora, usuario, pc, duracion, anulado, nit2,notas,notas_aut) " & _
                   "VALUES(" & sw & ", " & bodega & ", " & _
                               numeroActualizar & ", " & nit & ", " & _
                               vend & ",GETDATE (),'" & condicion & "', " & _
                               dias_validez & ", 0, " & tot_neto & ", GETDATE () ,'" & _
                                 strUsuario & "', '" & strPC & "', 100, 0, " & nit & ",'" & notas & "', '" & compromiso & "')"
            listaSql.Add(sql)
            With dtgPedido
                For i = 0 To .RowCount - 1
                    sql = "INSERT INTO documentos_lin_ped " & _
                             "(sw, bodega, numero, codigo, seq, " & _
                             " cantidad, valor_unitario, " & _
                             " cantidad_despachada, porcentaje_iva, porcentaje_descuento, und, cantidad_und, " & _
                             " despacho_virtual, porc_dcto_2, porc_dcto_3) " & _
                             "VALUES(" & sw & ", " & bodega & ", " & numeroActualizar & ", '" & _
                                         .Item(1, i).Value & "', " & i & ", " & _
                                        .Item(3, i).Value & ", " & _
                                         .Item(4, i).Value & ", 0, 19, 0, 'UND', 1, " & _
                                           .Item(3, i).Value & ", 0, 0)"
                    listaSql.Add(sql)
                Next
            End With
        End If
        resp = objOpSimplesLn.ExecuteSqlTransaction(listaSql)
        Return resp
    End Function

    Public Sub habilitar(ByVal estado As Boolean)
        txtRef.Enabled = estado
        tool_desp.Visible = estado
        btn_guardar.Enabled = estado
        txtCant.Enabled = estado
        TxtVrUnit.Enabled = estado
        btnAgregar.Enabled = estado
        dtgPedido.Enabled = estado
        txtNotas.Enabled = estado
        txtCod.Enabled = estado
        txtDesc.Enabled = estado
        txtVrTot.Enabled = estado
        btnDetalle.Enabled = estado
        txt_notas_opc.Enabled = estado
        txtNota5.Enabled = estado
    End Sub
    Public Sub nuevo()
        txtCondicion.Text = ""
        txt_cartera.Text = ""
        txt_cheq_dev.Text = ""
        txt_cupo.Text = ""
        txtCupoDisResumen.Text = ""
        txt_estado.Text = ""
        txt_nombres.Text = ""
        txt_tot.Text = ""
        txt_vr_iva.Text = ""
        txtCant.Text = ""
        txtCod.Text = ""
        txtDesc.Text = ""
        txtNit.Text = ""
        txtNotas.Text = ""
        txtRef.Text = ""
        TxtVrUnit.Text = ""
        txtVrTot.Text = ""
        txtSubtot.Text = ""
        ' problem_precio_min = ""
        txtCupo.Text = ""
        txt_notas_opc.Text = ""
        txtNota5.Text = ""
        txt_tot_pend.Text = ""
        DtgDetalleRef.DataSource = Nothing
        For i As Integer = dtgPedido.Rows.Count - 1 To 0 Step -1

            ' Si es la fila de nuevos registros, pasamos al siguiente índice
            ' 
            If (dtgPedido.Rows(i).IsNewRow) Then Continue For

            Me.dtgPedido.Rows.RemoveAt(i)

        Next
        habilitar(False)
        Dim ultimo_ped As Integer = objIngVtaLn.consec_ult_ped
        lblNroPedido.Visible = True
        lblNroPedido.Text = "Último pedido : " & ultimo_ped & ""
        Estado_guardar = True
        problema = ""
        txt_vend.Text = ""
        problemas_global = ""
        condicion = 0
    End Sub
    Private Sub btn_nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click
        Dim iResponce As String = ""
        Using New posicionar_messagebox(Me)
            iResponce = MessageBox.Show("Esta seguro que desea ingresar un nuevo pedido?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        End Using
        If (iResponce = 6) Then
            nuevo()
        End If
    End Sub
    Function EliminarEspeciales(ByVal s As String) As String
        Dim Filtro As String = "{}[]!#$%&/()=?¡'¿|\*+¨´:.;,<>"
        Dim I As Integer
        For I = 1 To Len(Filtro)
            s = Replace(s, Mid(Filtro, I, 1), "")
        Next
        EliminarEspeciales = s
    End Function
    Private Sub GuardarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        btn_guardar.PerformClick()
    End Sub

    Private Sub NuevoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        btn_nuevo.PerformClick()
    End Sub
    Private Sub centrarEnPantalla()
        'Me.Left = (Screen.PrimaryScreen.WorkingArea.Width - Me.Width) / 2
        Me.Top = (Screen.PrimaryScreen.WorkingArea.Height - Me.Height) / 2
    End Sub

    Private Sub btn_compromiso_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_compromiso.Click
        If (txtNit.Text <> "") Then
            Frm_compromiso.Show()
            Frm_compromiso.Main(vendedor, txtNit.Text, Me.Name)
            Frm_compromiso.Activate()
        End If

    End Sub
    Private Sub btn_mod_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_mod.Click
        Frm_ptes_problem.Show()
        Frm_ptes_problem.Main(vendedor, objUsuarioEn.usuario)
        Frm_ptes_problem.Activate()
    End Sub


    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        FrmLogin.Show()
        FrmPrincipal.Close()
        FrmLogin.Activate()
        Me.Close()
    End Sub

    Private Sub btn_ppal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ppal.Click
        FrmPrincipal.Show()
        Me.Close()
        FrmPrincipal.Activate()
    End Sub

    Private Sub tool_desp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tool_desp.Click
        Dim nit As Double = 0
        Dim resp As String
        If txtNit.Text = "" Then
            resp = InputBox("Ingrese nit para ver los despachos!", "ver despachos")
            If resp <> "" Then
                nit = resp
            End If
            'MessageBox.Show("El campo nit esta vacio!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            nit = txtNit.Text
        End If
        If nit <> 0 Then
            frmDespacho.Show()
            frmDespacho.Main(nit, vendedor)
            frmDespacho.Activate()
        End If
    End Sub
    Private Sub tool_seg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tool_seg.Click
        FrmSegVendAct.Show()
        FrmSegVendAct.Main("nod_ing_vtas", objUsuarioEn)
        FrmSegVendAct.Activate()
    End Sub
    Private Sub tool_cartera_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tool_cartera.Click
        frmCarteraIngVtas.Show()
        frmCarteraIngVtas.Main(vendedor, objUsuarioEn)
        frmCarteraIngVtas.Activate()
    End Sub
    Private Sub tool_pend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tool_pend.Click
        Frm_info_pendientes.Show()
        Frm_info_pendientes.Main(objUsuarioEn.Vendedor, objUsuarioEn.usuario)
        Frm_info_pendientes.Activate()
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        btn_guardar.PerformClick()
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        btn_nuevo.PerformClick()
    End Sub


    Private Sub btnAyuda_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAyuda.Click
        Dim proc As New Process
        proc.StartInfo.FileName = Environment.CurrentDirectory & "\manuales\manualIngVtas.pdf"
        proc.StartInfo.Verb = "Open"
        proc.Start()
    End Sub




    Private Sub txtNit_Enter(sender As Object, e As EventArgs) Handles txtNit.Enter
        txtNit.BackColor = Color.Lime
    End Sub
    Private Sub txtNit_Leave(sender As Object, e As EventArgs) Handles txtNit.Leave
        txtNit.BackColor = Color.White
    End Sub
    Private Sub txtRef_Enter(sender As Object, e As EventArgs) Handles txtRef.Enter
        txtRef.BackColor = Color.Lime
    End Sub
    Private Sub txtRef_Leave(sender As Object, e As EventArgs) Handles txtRef.Leave
        txtRef.BackColor = Color.White
    End Sub

    Private Sub TxtVrUnit_Enter(sender As Object, e As EventArgs) Handles TxtVrUnit.Enter
        TxtVrUnit.BackColor = Color.Lime
    End Sub
    Private Sub TxtVrUnit_Leave(sender As Object, e As EventArgs) Handles TxtVrUnit.Leave
        TxtVrUnit.BackColor = Color.White
    End Sub
    Private Sub txtCant_Enter(sender As Object, e As EventArgs) Handles txtCant.Enter
        txtCant.BackColor = Color.Lime
    End Sub
    Private Sub txtCant_Leave(sender As Object, e As EventArgs) Handles txtCant.Leave
        txtCant.BackColor = Color.White
    End Sub

    Private Sub txtNotas_Enter(sender As Object, e As EventArgs) Handles txtNotas.Enter
        txtNotas.BackColor = Color.Lime
    End Sub

    Private Sub txt_notas_opc_Enter(sender As Object, e As EventArgs) Handles txt_notas_opc.Enter
        txt_notas_opc.BackColor = Color.Lime
    End Sub

    Private Sub txtNota5_Enter(sender As Object, e As EventArgs) Handles txtNota5.Enter
        txtNota5.BackColor = Color.Lime
    End Sub

    Private Sub txtNotas_Leave(sender As Object, e As EventArgs) Handles txtNotas.Leave
        txtNotas.BackColor = Color.White
    End Sub

    Private Sub txt_notas_opc_Leave(sender As Object, e As EventArgs) Handles txt_notas_opc.Leave
        txt_notas_opc.BackColor = Color.White
    End Sub

    Private Sub txtNota5_Leave(sender As Object, e As EventArgs) Handles txtNota5.Leave
        txtNota5.BackColor = Color.White
    End Sub

    Private Sub btnAgregar_Enter(sender As Object, e As EventArgs) Handles btnAgregar.Enter
        btnAgregar.BackColor = Color.Lime
    End Sub

    Private Sub btnAgregar_Leave(sender As Object, e As EventArgs) Handles btnAgregar.Leave
        btnAgregar.BackColor = btn_mod.BackColor
    End Sub
    Private Sub btn_guardar_Enter(sender As Object, e As EventArgs) Handles btn_guardar.Enter
        btn_guardar.BackColor = Color.Lime
    End Sub

    Private Sub btn_guardar_Leave(sender As Object, e As EventArgs) Handles btn_guardar.Leave
        btn_guardar.BackColor = btn_mod.BackColor
    End Sub

    Private Sub txtNotas_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNotas.KeyPress
        If (e.KeyChar = Microsoft.VisualBasic.ChrW(13)) Then
            txtNotas.Text = txtNotas.Text.Replace(vbCrLf, " ")
            txt_notas_opc.Focus()
        End If
    End Sub

    Private Sub txt_notas_opc_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_notas_opc.KeyPress
        If (e.KeyChar = Microsoft.VisualBasic.ChrW(13)) Then
            txt_notas_opc.Text = txt_notas_opc.Text.Replace(vbCrLf, " ")
            txtNota5.Focus()
        End If
    End Sub
    Private Sub txtNombAnticipos_Leave(sender As Object, e As EventArgs) Handles txtNombAnticipos.Leave
        txtNombAnticipos.BackColor = Color.White
    End Sub

    Private Sub txtNombAnticipos_Enter(sender As Object, e As EventArgs) Handles txtNombAnticipos.Enter
        txtNombAnticipos.BackColor = Color.Lime
    End Sub

    Private Sub txtNitAnticipos_Enter(sender As Object, e As EventArgs) Handles txtNitAnticipos.Enter
        txtNitAnticipos.BackColor = Color.Lime
    End Sub

    Private Sub txtNitAnticipos_Leave(sender As Object, e As EventArgs) Handles txtNitAnticipos.Leave
        txtNitAnticipos.BackColor = Color.White
    End Sub
    Private Sub txtNitPendientes_Enter(sender As Object, e As EventArgs) Handles txtNitPendientes.Enter
        txtNitPendientes.BackColor = Color.Lime
    End Sub

    Private Sub txtNombresPend_Enter(sender As Object, e As EventArgs) Handles txtNombresPend.Enter
        txtNombresPend.BackColor = Color.Lime
    End Sub

    Private Sub btn_consult_pend_Enter(sender As Object, e As EventArgs) Handles btn_consult_pend.Enter
        btn_consult_pend.BackColor = Color.Lime
    End Sub

    Private Sub txtNitCartera_Enter(sender As Object, e As EventArgs) Handles txtNitCartera.Enter
        txtNitCartera.BackColor = Color.Lime
    End Sub

    Private Sub txtNombCartera_Leave(sender As Object, e As EventArgs) Handles txtNombCartera.Leave
        txtNombCartera.BackColor = Color.White
    End Sub

    Private Sub btn_consult_cartera_Enter(sender As Object, e As EventArgs) Handles btn_consult_cartera.Enter
        btn_consult_cartera.BackColor = Color.Lime
    End Sub

    Private Sub txtNitFact_Enter(sender As Object, e As EventArgs) Handles txtNitFact.Enter
        txtNitFact.BackColor = Color.Lime
    End Sub

    Private Sub txtNitFact_Leave(sender As Object, e As EventArgs) Handles txtNitFact.Leave
        txtNitFact.BackColor = Color.White
    End Sub

    Private Sub txtCodigoFact_Enter(sender As Object, e As EventArgs) Handles txtCodigoFact.Enter
        txtCodigoFact.BackColor = Color.Lime
    End Sub

    Private Sub txtCodigoFact_Leave(sender As Object, e As EventArgs) Handles txtCodigoFact.Leave
        txtCodigoFact.BackColor = Color.White
    End Sub
    Private Sub txtNombFact_Enter(sender As Object, e As EventArgs) Handles txtNombFact.Enter
        txtNombFact.BackColor = Color.Lime
    End Sub

    Private Sub txtNombFact_Leave(sender As Object, e As EventArgs) Handles txtNombFact.Leave
        txtNombFact.BackColor = Color.White
    End Sub

    Private Sub btnConsultAnticipos_fact_Enter(sender As Object, e As EventArgs) Handles btnConsultAnticipos.Enter
        btnConsultAnticipos.BackColor = Color.Lime
    End Sub

    Private Sub btnConsultAnticipos_Leave(sender As Object, e As EventArgs) Handles btnConsultAnticipos.Leave
        btnConsultAnticipos.BackColor = btn_mod.BackColor
    End Sub
    Private Sub btn_consult_fact_Enter(sender As Object, e As EventArgs) Handles btn_consult_fact.Enter
        btn_consult_fact.BackColor = Color.Lime
    End Sub

    Private Sub btn_consult_fact_Leave(sender As Object, e As EventArgs) Handles btn_consult_fact.Leave
        btn_consult_fact.BackColor = btn_mod.BackColor
    End Sub

    Private Sub btn_consult_cartera_Leave(sender As Object, e As EventArgs) Handles btn_consult_cartera.Leave
        btn_consult_cartera.BackColor = btn_mod.BackColor
    End Sub

    Private Sub btn_consult_pend_Leave(sender As Object, e As EventArgs) Handles btn_consult_pend.Leave
        btn_consult_pend.BackColor = btn_mod.BackColor
    End Sub
    Private Sub cboAño_Enter(sender As Object, e As EventArgs) Handles cboAño.Enter
        cboAño.BackColor = Color.Lime
    End Sub
    Private Sub cboAño_Leave(sender As Object, e As EventArgs) Handles cboAño.Leave
        cboAño.BackColor = Color.White
    End Sub
    Private Sub cboMes_Enter(sender As Object, e As EventArgs) Handles cboMes.Enter
        cboMes.BackColor = Color.Lime
    End Sub
    Private Sub cboMes_Leave(sender As Object, e As EventArgs) Handles cboMes.Leave
        cboMes.BackColor = Color.White
    End Sub
    Private Sub chk_inter_Enter(sender As Object, e As EventArgs) Handles chk_inter.Enter
        chk_inter.BackColor = Color.Lime
    End Sub
    Private Sub chk_inter_Leave(sender As Object, e As EventArgs) Handles chk_inter.Leave
        chk_inter.BackColor = Color.White
    End Sub
    Private Sub chkKil_Enter(sender As Object, e As EventArgs) Handles chkKil.Enter
        chkKil.BackColor = Color.Lime
    End Sub
    Private Sub chkKil_Leave(sender As Object, e As EventArgs) Handles chkKil.Leave
        chkKil.BackColor = Color.White
    End Sub
    Private Sub ChkPesos_Enter(sender As Object, e As EventArgs) Handles ChkPesos.Enter
        ChkPesos.BackColor = Color.Lime
    End Sub
    Private Sub ChkPesos_Leave(sender As Object, e As EventArgs) Handles ChkPesos.Leave
        ChkPesos.BackColor = Color.White
    End Sub
    Private Sub btnConsultaSeg_Enter(sender As Object, e As EventArgs) Handles btnConsultaSeg.Enter
        btnConsultaSeg.BackColor = Color.Lime
    End Sub
    Private Sub btnConsultaSeg_Leave(sender As Object, e As EventArgs) Handles btnConsultaSeg.Leave
        btnConsultaSeg.BackColor = Color.White
    End Sub
    Private Sub btn_consult_pend_Click(sender As Object, e As EventArgs) Handles btn_consult_pend.Click
        If (txtNitPendientes.Text <> "") Then
            Dim nit As Double = txtNitPendientes.Text
            If (usuario_vend = 1020 Or objIngVtaLn.clientDisponible(nit, vendedor)) Then
                listarPend(nit)
            Else
                Using New posicionar_messagebox(Me)
                    MessageBox.Show("Acceso denegado para ver la informacion de el cliente = " & nit & "", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Using
                txtNitPendientes.Text = ""
            End If
        Else
            Using New posicionar_messagebox(Me)
                MessageBox.Show("Debe ingresar un nit", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Using
        End If
    End Sub

    Private Sub btn_consult_cartera_Click(sender As Object, e As EventArgs) Handles btn_consult_cartera.Click
        If (txtNitCartera.Text <> "") Then
            Dim nit As Double = txtNitCartera.Text
            If (usuario_vend = 1020 Or objIngVtaLn.clientDisponible(nit, vendedor)) Then
                listarCartera(nit)
            Else
                Using New posicionar_messagebox(Me)
                    MessageBox.Show("Acceso denegado para ver la informacion de el cliente = " & nit & "", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Using
                txtNitCartera.Text = ""
            End If
        Else
            Using New posicionar_messagebox(Me)
                MessageBox.Show("Debe ingresar un nit", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Using
        End If
    End Sub

    Private Sub btn_consult_fact_Click(sender As Object, e As EventArgs) Handles btn_consult_fact.Click
        If (txtNitFact.Text <> "") Then
            Dim nit As Double = txtNitFact.Text
            If (usuario_vend = 1020 Or objIngVtaLn.clientDisponible(nit, vendedor)) Then
                listarFacturacion(nit)
            Else
                Using New posicionar_messagebox(Me)
                    MessageBox.Show("Acceso denegado para ver la informacion de el cliente = " & nit & "", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End Using
                txtNitFact.Text = ""
            End If
        Else
            Using New posicionar_messagebox(Me)
                MessageBox.Show("Debe ingresar un nit", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Using
        End If

    End Sub
    Private Sub listarPend(ByVal nit As Double)
        imgProc.Visible = True
        Application.DoEvents()
        dtg_pend.DataSource = objClienteLn.listarPendientes(nit)
        dtg_pend.Columns("fecha").DefaultCellStyle.Format = "d"
        imgProc.Visible = False
    End Sub
    Private Sub listarCartera(ByVal nit As Double)
        imgProc.Visible = True
        Application.DoEvents()
        dtg_cartera.DataSource = objClienteLn.listarCartera(nit)
        dtg_cartera.Columns("fecha").DefaultCellStyle.Format = "d"
        dtg_cartera.Columns("Vencimiento").DefaultCellStyle.Format = "d"
        imgProc.Visible = False
    End Sub
    Private Sub listarFacturacion(ByVal nit As Double)
        imgProc.Visible = True
        Application.DoEvents()
        Dim mesini As Integer = cboMesIni.SelectedIndex + 1
        Dim añoIni As Integer = cboAñoIni.SelectedItem
        Dim mesFin As Integer = cboMesFin.SelectedIndex + 1
        Dim añoFin As Integer = cboAñoFin.SelectedItem
        Dim codigo As String = txtCodigoFact.Text
        dtgFact.DataSource = objClienteLn.listarFactura(nit, mesini, añoIni, mesFin, añoFin, codigo)
        dtgFact.Columns("fec").DefaultCellStyle.Format = "d"
        imgProc.Visible = False
    End Sub
    Private Sub listarAnticipos(ByVal nit As String)
        imgProc.Visible = True
        Application.DoEvents()
        Dim whereVend As String = ""
        Dim vendedores As String = ""
        If (usuario_vend = 1020) Then
            vendedores = objUsuarioLn.coordinadorVend(objUsuarioEn.usuario)
            If (vendedores = "") Then
                whereVend = " doc.vendedor >= 1001 AND doc.vendedor <= 1099 "
            Else
                whereVend = "doc.vendedor IN (" & vendedores & ") "
            End If
        Else
            whereVend = "doc.vendedor = " & usuario_vend & " "
        End If
        Dim sql As String = "SELECT doc.vendedor ,doc.sw,doc.tipo,doc.numero,doc.nit,ter.nombres,ter.condicion,YEAR(doc.fecha) AS 'AÑO',MONTH(doc.fecha) AS 'MES',doc.fecha,doc.valor_total,doc.valor_aplicado,(doc.valor_total - doc.valor_aplicado ) as Saldo,(SELECT SUM (pend.Vr_total )FROM J_v_pend_vend pend WHERE pend.nit = doc.nit )As Pendientes " & _
                                    "FROM documentos doc ,terceros ter  " & _
                                            "WHERE ter.nit= doc.nit AND doc.sw Like '5' AND  " & whereVend & " AND doc.nit like'%" & nit & "%'  AND doc.tipo IN ('RCR1','RCO1','RCEX')  AND (doc.valor_total - doc.valor_aplicado )>1 AND(doc.valor_total>doc.valor_aplicado or (doc.iva_fletes <0   AND doc.valor_total=doc.valor_aplicado) )  " & _
                                                    "ORDER BY doc.vendedor  "
        dtgAnticipos.DataSource = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        dtgAnticipos.Columns("fecha").DefaultCellStyle.Format = "d"
        imgProc.Visible = False
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
    Private Sub txtNitPendientes_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNitPendientes.KeyPress
        soloNumero(e)
    End Sub

    Private Sub txtNitCartera_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNitCartera.KeyPress
        soloNumero(e)
    End Sub

    Private Sub txtNitFact_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNitFact.KeyPress
        soloNumero(e)
    End Sub
    Private Sub txtNitAnticipos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNitAnticipos.KeyPress
        soloNumero(e)
    End Sub
    Public Sub clientes()
        Dim sql As String = ""
        Dim selectSql As String = "SELECT nit, nombres,Region,TipoCliente, direccion, telefono_1, contacto_1, vendedor FROM jjv_Datos_clientes_todos "
        Dim whereSql As String = "WHERE "
        Dim whereVend As String = ""
        Dim vendedores As String = ""
        If (usuario_vend = 1020) Then
            vendedores = objUsuarioLn.coordinadorVend(objUsuarioEn.usuario)
            If (vendedores = "") Then
                whereVend = " vendedor >= 1001 AND vendedor <= 1099 "
            Else
                whereVend = "vendedor IN (" & vendedores & ") "
            End If
        Else
            whereVend = "vendedor = " & usuario_vend & " "
        End If
        whereSql &= whereVend
        If (txtNitBuscCliente.Text <> "") Then
            whereSql &= "AND nit =" & txtNitBuscCliente.Text
        ElseIf (txtNomBuscCliente.Text <> "") Then
            whereSql &= "AND nombres like'%" & txtNomBuscCliente.Text & "%'"
        End If
        sql = selectSql & whereSql
        dtg_clientes.DataSource = objOpSimplesLn.listar_datatable(sql, "CORSAN")
    End Sub
    Private Sub txtNitBuscCliente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNitBuscCliente.TextChanged
        txtNomBuscCliente.Text = ""
        If (txtNitBuscCliente.Text.Length > 2) Then
            clientes()
        End If
    End Sub
    Private Sub txtNitBuscCliente_keyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNitBuscCliente.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
        If (e.KeyChar = Microsoft.VisualBasic.ChrW(13) And txtNit.Text <> "") Then
            cargar_info()
        End If
    End Sub
    Private Sub txtNomBuscCliente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNomBuscCliente.TextChanged
        txtNitBuscCliente.Text = ""
        If (txtNomBuscCliente.Text.Length > 3) Then
            clientes()
        End If
    End Sub
    Private Sub txtNomBuscCliente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNomBuscCliente.KeyPress
        If (e.KeyChar = Microsoft.VisualBasic.ChrW(13)) Then
            cargar_info()
        End If
    End Sub
    Private Sub cargar_info()
        If (dtg_clientes.RowCount > 0) Then
            Dim nit As String = dtg_clientes.Item("nit", dtg_clientes.CurrentCell.RowIndex).Value
            Dim nombres As String = dtg_clientes.Item("nombres", dtg_clientes.CurrentCell.RowIndex).Value
            Select Case tab_busc_cliente
                Case tab_ing_ped.Name
                    txt_nombres.Text = nombres
                    txtNit.Text = nit
                    txtRef.Focus()
                    cargar_info_client(nit)
                Case tab_pend.Name
                    txtNombresPend.Text = nombres
                    txtNitPendientes.Text = nit
                    listarPend(nit)
                Case tab_cartera.Name
                    txtNombCartera.Text = nombres
                    txtNitCartera.Text = nit
                    listarCartera(nit)
                Case tab_fact.Name
                    txtNombFact.Text = nombres
                    txtNitFact.Text = nit
                    listarFacturacion(nit)
                Case tab_anticipos.Name
                    txtNombAnticipos.Text = nombres
                    txtNitAnticipos.Text = nit
                    listarAnticipos(nit)
            End Select
            btnCerrarBuscCliente.PerformClick()
        End If
    End Sub
    Private Sub txtNomBuscCliente_Enter(sender As Object, e As EventArgs) Handles txtNomBuscCliente.Enter
        txtNomBuscCliente.BackColor = Color.Lime
    End Sub

    Private Sub txtNitBuscCliente_Leave(sender As Object, e As EventArgs) Handles txtNitBuscCliente.Leave
        txtNitBuscCliente.BackColor = Color.White
    End Sub

    Private Sub txtNitBuscCliente_Enter(sender As Object, e As EventArgs) Handles txtNitBuscCliente.Enter
        txtNitBuscCliente.BackColor = Color.Lime
    End Sub

    Private Sub txtNomBuscCliente_Leave(sender As Object, e As EventArgs) Handles txtNomBuscCliente.Leave
        txtNomBuscCliente.BackColor = Color.White
    End Sub
    Private Sub btnCerrarBuscCliente_Click(sender As Object, e As EventArgs) Handles btnCerrarBuscCliente.Click
        groupCliente.Visible = False
        dtg_clientes.DataSource = Nothing
        txtNitBuscCliente.Text = ""
        txtNomBuscCliente.Text = ""
    End Sub

    Private Sub txtNombresPend_MouseClick(sender As Object, e As MouseEventArgs) Handles txtNombresPend.MouseClick
        tab_busc_cliente = tab_pend.Name
        groupCliente.Visible = True
        txtNomBuscCliente.Focus()
    End Sub
    Private Sub txtNombCartera_MouseClick(sender As Object, e As MouseEventArgs) Handles txtNombCartera.MouseClick
        tab_busc_cliente = tab_cartera.Name
        groupCliente.Visible = True
        txtNomBuscCliente.Focus()
    End Sub
    Private Sub txtNombFact_MouseClick(sender As Object, e As MouseEventArgs) Handles txtNombFact.MouseClick
        tab_busc_cliente = tab_fact.Name
        groupCliente.Visible = True
        txtNomBuscCliente.Focus()
    End Sub
    Private Sub txtNombAnticipos_MouseClick(sender As Object, e As MouseEventArgs) Handles txtNombAnticipos.MouseClick
        tab_busc_cliente = tab_anticipos.Name
        groupCliente.Visible = True
        txtNomBuscCliente.Focus()
    End Sub

    Private Sub dtg_clientes_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtg_clientes.CellContentClick
        cargar_info()
    End Sub

    Private Sub btnConsultAnticipos_Click(sender As Object, e As EventArgs) Handles btnConsultAnticipos.Click
        Dim nit As String = ""
        If (txtNitAnticipos.Text <> "") Then
            nit = txtNitAnticipos.Text
        End If
        If nit <> "" Then
            If (usuario_vend = 1020 Or objIngVtaLn.clientDisponible(nit, vendedor)) Then
                listarAnticipos(nit)
            Else
                Using New posicionar_messagebox(Me)
                    MessageBox.Show("Acceso denegado para ver la informacion de el cliente = " & nit & "", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End Using
                txtNitFact.Text = ""
            End If
        Else
            listarAnticipos(nit)
        End If

    End Sub

    Private Sub btn_ok_Click(sender As Object, e As EventArgs) Handles btn_ok.Click
        cargar_info()
    End Sub

    Private Sub btnConsultaSeg_Click(sender As Object, e As EventArgs) Handles btnConsultaSeg.Click
        dtgSegVend.CurrentCell = Nothing
        imgProc.Visible = True
        Application.DoEvents()
        Dim criterio As String
        Dim vendedores As String = objUsuarioLn.coordinadorVend(objUsuarioEn.usuario)
        Dim mes As Integer = cboMes.SelectedIndex + 1
        Dim ano As Integer = cboAño.Text
        If (chkKil.Checked = True) Then
            criterio = "kilos"
        Else
            criterio = "vr_total"
        End If
        dtgSegVend.DataSource = objSegVendLn.listarSeg(criterio, usuario_vend, chk_inter.Checked, vendedores, mes, ano)
        dtgSegVend.Rows(dtgSegVend.RowCount - 1).DefaultCellStyle.BackColor = Color.Red
        If (objUsuarioEn.usuario = "JESUSAL") Then
            dtgSegVend.Columns("Por_util").Visible = False
        End If
        If (objUsuarioEn.permiso.Trim <> "ADMIN") Then
            If (objUsuarioEn.permiso.Trim <> "COOR_VTAS") Then
                dtgSegVend.Columns("Por_util").Visible = False
                dtgSegVend.Columns("Costo").Visible = False
            End If
        End If
        dtgSegVend.Columns("Valor_total").Visible = False
        dtgSegVend.Columns("Costo").Visible = False
        dtgSegVend.Columns("porCumVtas").DefaultCellStyle.Format = "N2"
        dtgSegVend.Columns("porCumRec").DefaultCellStyle.Format = "N2"
        dtgSegVend.Columns("porDev").DefaultCellStyle.Format = "N2"
        dtgSegVend.Columns("Por_util").DefaultCellStyle.Format = "N2"
        dtgSegVend.Columns("Vendedor").HeaderText = "Vend"
        dtgSegVend.Columns("porCumVtas").HeaderText = "%Vtas"
        dtgSegVend.Columns("porCumRec").HeaderText = "%Rec"
        dtgSegVend.Columns("porDev").HeaderText = "%Dev"
        dtgSegVend.Columns("Por_util").HeaderText = "%util"
        imgProc.Visible = False
        alertas()
        nomb_vendedores()
    End Sub
    Private Sub nomb_vendedores()
        Dim sql_nomb_vendedores As String = "SELECT nit,nombres FROM terceros WHERE nit >=1001 and nit <=1099"
        Dim dt_nom_vendedores As DataTable = objOpSimplesLn.listar_datatable(sql_nomb_vendedores, "CORSAN")
        For j = 0 To dtgSegVend.Columns.Count - 1
            If dtgSegVend.Columns(j).Name = "Vendedor" Then
                For i = 0 To dtgSegVend.Rows.Count - 2
                    If Not IsDBNull(dtgSegVend.Item(j, i).Value) Then
                        For k = 0 To dt_nom_vendedores.Rows.Count - 1
                            If dtgSegVend.Item(j, i).Value = dt_nom_vendedores.Rows(k).Item("nit") Then
                                For z = 0 To dtgSegVend.Columns.Count - 1
                                    dtgSegVend.Item(z, i).ToolTipText = dt_nom_vendedores.Rows(k).Item("nombres")
                                Next
                                k = dt_nom_vendedores.Rows.Count - 1
                            End If
                        Next
                    End If
                Next
                j = dtgSegVend.Columns.Count - 1
            End If

        Next
    End Sub
    Private Sub alertas()
        Dim alerta As Double = 0
        For j = 1 To dtgSegVend.Columns.Count - 1
            If dtgSegVend.Columns(j).Name = "porCumVtas" Or dtgSegVend.Columns(j).Name = "porCumRec" Then
                For i = 0 To dtgSegVend.Rows.Count - 1
                    If Not IsDBNull(dtgSegVend.Item(j, i).Value) Then
                        If (dtgSegVend.Item(j, i).Value) >= 100 Then
                            dtgSegVend.Item(j, i).Style.BackColor = Color.GreenYellow
                        ElseIf (dtgSegVend.Item(j, i).Value >= 95 And dtgSegVend.Item(j, i).Value < 100) Then
                            dtgSegVend.Item(j, i).Style.BackColor = Color.Yellow
                        Else
                            dtgSegVend.Item(j, i).Style.BackColor = Color.Red
                        End If
                    End If
                Next
            End If

        Next
    End Sub
    Private Sub ChkPesosVend_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkPesos.CheckedChanged
        If ChkPesos.Checked = True Then
            chkKil.Checked = False
        End If
    End Sub
    Private Sub chkKilVend_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkKil.CheckedChanged
        If chkKil.Checked = True Then
            ChkPesos.Checked = False
        End If
    End Sub
End Class

