Imports System.Configuration
Imports logicaNegocios
Imports entidadNegocios
Imports System.IO
Imports Microsoft.Office.Interop
#Disable Warning BC40056 ' El espacio de nombres o el tipo especificado en el 'System.Data.SqlServerCe' Imports no contienen ningún miembro público o no se encuentran. Asegúrese de que el espacio de nombres o el tipo se hayan definido y de que contengan al menos un miembro público. Asegúrese de que el nombre del elemento importado no use ningún alias.
Imports System.Data.SqlServerCe
#Enable Warning BC40056 ' El espacio de nombres o el tipo especificado en el 'System.Data.SqlServerCe' Imports no contienen ningún miembro público o no se encuentran. Asegúrese de que el espacio de nombres o el tipo se hayan definido y de que contengan al menos un miembro público. Asegúrese de que el nombre del elemento importado no use ningún alias.
Public Class FrmIngVtas
    Private objEnvioCorreoLn As New  EnvCorreoLN 
    Private objUsuarioLn As New UsuarioLn
    Private objOperacionesForm As OperacionesFormularios = New OperacionesFormularios
    Private objOpSimplesLn As New Op_simpesLn
    Private objIngVtaLn As New IngVtasLn
    Private objclienteLn As New ClienteLn
    Private objUsuarioEn As New UsuarioEn
    Private vendedor As Double
    Private usuario_vend As Double
    ' Dim problem_precio_min As String = ""
    Dim cupo_disp As Double = 0
    Public problema As String = ""
    Public problemas_global As String = ""
    Public Estado_guardar = True
    Public modificar As Boolean = False
    Public numeroActualizar As Double = 0
    Public fecha_actualizar As String = ""
    Public aut_actualizar As String = ""
    Public notas_aut_actualizar As String = ""
    Dim condicion As Integer
    Dim lista_precio As String
    Private nom_modulo As String = ""
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
        lblUltimoPedido.Text = "Nùmero pedido : " & ultimo_ped + 1 & ""
        txt_bodega.Text = objUsuarioEn.bodega
        Me.Size = New System.Drawing.Size(640, Screen.PrimaryScreen.WorkingArea.Height)
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
    Private Sub btnDetalle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDetalle.Click
        Dim nit As Double = 0
        Dim resp As String = ""
        If txtNit.Text = "" Then
            resp = InputBox("Ingrese nit para ver detalle del cliente!", "ver despachos")
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
                MessageBox.Show("Acceso denegado para ver la informacion de el cliente = " & nit & "", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtNit.Text = ""
            End If
        End If

    End Sub
    Private Sub txtRef_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRef.TextChanged, txtRef.KeyPress
        Dim strSQL As String
        If txtRef.Text <> "" Then
            strSQL = "SELECT codigo, descripcion " & _
                  "FROM Referencias " & _
                  "WHERE codigo LIKE '" & txtRef.Text & "%' AND ref_anulada ='N' and (codigo like ('1%') or codigo like ('3%') or codigo like ('8%'))"
        Else
            strSQL = "SELECT codigo, descripcion  " & _
                     "FROM Referencias " & _
            "WHERE ref_anulada ='N' and codigo like ('3%')"
        End If
        DtgDetalleRef.DataSource = objIngVtaLn.listarRef(strSQL)
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
            txtVrTot.Text = Format((Convert.ToDouble(txtCant.Text) * Convert.ToDouble(TxtVrUnit.Text)), "C2")
        Else
            txtVrTot.Text = Format(0, "C2")
        End If

    End Sub

    Private Sub txtCant_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCant.TextChanged
        If (txtCant.Text <> "" And TxtVrUnit.Text <> "") Then
            txtVrTot.Text = Format((Convert.ToDouble(txtCant.Text) * Convert.ToDouble(TxtVrUnit.Text)), "C2")
        Else
            txtVrTot.Text = Format(0, "C2")
        End If
    End Sub

    Private Function verificar_chatarra(ByVal codigo As String) As Boolean
        Dim sql As String = "SELECT codigo FROM referencias WHERE codigo like '3H%' OR codigo like '8S%' "
        Dim resp As String = objOpSimplesLn.consultarVal(sql)
        If resp = "" Then
            Return False
        Else
            Return True
        End If
    End Function
    Private Function verificar_cliente_chatarra(ByVal nit As Double) As Boolean
        Dim sql As String = "SELECT nit FROM J_v_clientes_chatarra WHERE nit = " & nit
        Dim resp As String = objOpSimplesLn.consultarVal(sql)
        If resp = "" Then
            Return False
        Else
            Return True
        End If
    End Function
    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
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
            Dim costo_menos_10 As Double = (Precio_unitario) * 0.85
            Dim costo_mas_90 As Double = (Precio_unitario) * 1.9
            For i = 0 To dtgPedido.RowCount - 1
                If (dtgPedido.Item("cod", i).Value = txtCod.Text) Then
                    cod_rep = True
                End If
            Next
            If (cod_rep = False) Then
                If (txtCant.Text <> "" And txtCod.Text <> "" And TxtVrUnit.Text <> "" And txtVrTot.Text <> "") Then
                    Dim cod As String = txtCod.Text
                    If cod.ToUpper Like "3H*" Or cod.ToUpper Like "8S*" Then
                        errores = ingresar_codigo(vr_unit, precioMin)
                    Else
                        If (vr_unit > costo_menos_10) Then
                            If (vr_unit < costo_mas_90) Then
                                errores = ingresar_codigo(vr_unit, precioMin)
                            Else
                                errores = True
                                MessageBox.Show("El precio para esta referencia esta muy por encima del valor unitario, verifique el valor ingresado", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End If

                        Else
                            errores = True
                            MessageBox.Show("El precio para esta referencia esta por debajo del minimo requerido que es " & costo_menos_10 & ", ingrese la referencia nuevamente!", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    End If
                Else
                    errores = True
                    MessageBox.Show("Campos requeridos para esta operaciòn estan vacios", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                errores = True
                MessageBox.Show("El codigo " & txtCod.Text & " ya se encuentra en los items del pedido!", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            If (cod_rep = False) Then
                If (txtCant.Text <> "" And txtCod.Text <> "" And TxtVrUnit.Text <> "" And txtVrTot.Text <> "") Then
                    errores = ingresar_codigo(vr_unit, precioMin)
                Else
                    errores = True
                    MessageBox.Show("Campos requeridos para esta operaciòn estan vacios", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                errores = True
                MessageBox.Show("El codigo " & txtCod.Text & " ya se encuentra en los items del pedido!", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
    Private Function ingresar_codigo(ByVal vr_unit As Double, ByVal precioMin As Double) As Boolean
        Dim errores As Boolean = False
        Dim valTotPedido As Double = 0
        Dim vec(6) As Object
        Dim resp As Integer = 6
        Dim vrTotal As Double = 0
        Dim subTotal As Double = 0
        Dim iva As Double = objOpSimplesLn.getIvaPorc()
        If (vr_unit < precioMin) Then
            resp = MessageBox.Show("Valor unitario esta por debajo de el precio minimo de venta! que es: " & precioMin.ToString("C0") & " Desea ingresarlo para su gestiòn? ", "Còdigo", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
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
                MessageBox.Show("Verifique que todos los items del pedido estem llenos! ", "Campos", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
        Return errores
    End Function
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
                MessageBox.Show("El còdigo " & txtRef.Text & " no existe ò no esta disponible!", "Còdigo", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If

    End Sub
    Private Sub btn_clientes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_clientes.Click
        Frm_clientes.Show()
        Frm_clientes.Main(usuario_vend, Me.Name)
        Frm_clientes.Activate()
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
            Dim sql As String
            Dim vec_datos As Object = objIngVtaLn.infoCliente(nit)
            condicion = vec_datos(6)
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
            vendedor = objclienteLn.getVendedor(nit)
            txt_vend.Text = vendedor
            cupo_disp = Convert.ToDouble(cupo - vr_Pend - cartera)
            If verificar_cliente_chatarra(nit) Then
                cargar_todo_cliente(vec_datos, cupo, vr_Pend)
            Else
                If (objclienteLn.existeUsuarioTERCEROS(nit, vendedores)) Then
                    If (objIngVtaLn.doc_venc_mas_30(nit) = False Or usuario_vend = 1020) Then
                        If Not (vec_datos(1) = 2) Then
                            If ((condicion = 201 Or condicion = 208)) Then
                                If (condicion = 201) Then
                                    If (anticipo <= 0 Or cupo_disp <= 0 And Estado_guardar = False) Then
                                        If objUsuarioEn.permiso.Trim = "VENDEDOR" Then
                                            nuevo()
                                            habilitar(False)
                                            MessageBox.Show("El cliente es de contado y no tiene anticipos, comuniquese con cartera para su gestión", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                            Exit Sub
                                        End If
                                    End If
                                ElseIf (condicion = 208) Then
                                    If (cartVencida > 0) Then
                                        MessageBox.Show("El cliente es de contado y tiene cartera vencida,debe cancelar para ingresar el pedido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                        nuevo()
                                        habilitar(False)
                                        Exit Sub
                                    End If
                                End If
                                If (cupo_disp <= 0) Then
                                    resp_cond = MessageBox.Show("El cliente es de contado y no tiene cupo disponible, el pedido sera ingresado para su gestion, esta deacuerdo ? ", "Atención", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                                    problema = "C"
                                    aut_actualizar = "N"
                                    problemas_global = problema
                                Else
                                    MessageBox.Show("El cliente es de contado y tiene cupo disponible de: " & cupo_disp.ToString("C0") & " ", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                End If
                            End If
                            If (objIngVtaLn.mov_180_dias(nit) = False) Then
                                If Not (objIngVtaLn.esNuevo(nit)) Then
                                    resp_no_mov = MessageBox.Show("El nit   = " & nit & " no a tenido movimiento en los ultimos 180 días,el pedido sera ingresado para su gestion, favor comunicarse con cartera y actualizar los documentos!, esta deacuerdo ? ", "Atención", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                                    problema = "X"
                                    aut_actualizar = "N"
                                    problemas_global += "X"
                                End If
                            End If
                            sql = "Select lista from terceros where nit=" & txtNit.Text & ""
                            lista_precio = objOpSimplesLn.consultValorTodo(sql, "CORSAN")
                            If lista_precio = "" Or (lista_precio <> "1" And lista_precio <> "2" And lista_precio <> "3" And lista_precio <> "4" And lista_precio <> "5" And lista_precio <> "6") Then
                                problema = "L"
                                aut_actualizar = "N"
                                problemas_global += "L"
                                MessageBox.Show("El cliente no tiene lista de precio por lo tanto su pedido se ira  a los no reflejados", "Cliente sin lista de precios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            End If
                            If (resp_no_mov = 6 And resp_cond = 6) Then
                                cargar_todo_cliente(vec_datos, cupo, vr_Pend)
                            Else
                                nuevo()
                            End If
                        Else
                            MessageBox.Show("El cliente se encuentra bloqueado por lo tanto no se le pueden ingresar pedidos.", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            habilitar(False)
                        End If
                    Else
                        MessageBox.Show("El cliente tiene FACTURAS VENCIDAS A MÁS DE 30 DÍAS por lo tanto no se le pueden ingresar pedidos.", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        enviarCorreo(vendedor, vec_datos(0))
                        habilitar(False)
                    End If

                Else
                    MessageBox.Show("El nit   = " & nit & " no existe ó no tiene permisos para ver su información", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    habilitar(False)
                End If
            End If
            ' MessageBox.Show("El nit   = " & nit & " es cliente de contado y no tiene anticipo,por favor comunicarse con cartera!", "Cartera", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            MessageBox.Show("Acceso denegado para ver la informacion de el cliente = " & nit & "", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtNit.Text = ""
            habilitar(False)
        End If
        ' problem_precio_min = ""


    End Sub
    Private Sub cargar_todo_cliente(ByVal vec_datos As Object, ByVal cupo As Double, ByVal vr_Pend As Double)
        txtCupo.Text = cupo.ToString("C0")
        txt_tot_pend.Text = vr_Pend.ToString("C0")
        txt_nombres.Text = vec_datos(0)
        txt_cartera.Text = Convert.ToDouble(vec_datos(2)).ToString("C0")
        txt_cheq_dev.Text = Convert.ToDouble(vec_datos(3)).ToString("C0")
        txtCondicion.Text = condicion
        If (cupo_disp <= 0) Then
            txt_cupo.ForeColor = Color.Red
        Else
            txt_cupo.ForeColor = Color.Black
        End If
        txt_cupo.Text = cupo_disp.ToString("C0")
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
            MessageBox.Show("Ingrese un cliente!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
        soloNumero(e)
        If (e.KeyChar = Microsoft.VisualBasic.ChrW(13)) Then
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
        If (txt_nombres.Text = objclienteLn.nombres(txtNit.Text)) Then
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
                                        aut_actualizar = "N"
                                        problemas_global &= "P"
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
                        If aut_actualizar = "S" Or aut_actualizar = "A" Then
                            problema = ""
                            pro_precio_min = ""
                        End If
                        If ((problema = "" And pro_precio_min = "")) Then
                            If (guardar(problema, "") = True) Then
                                MessageBox.Show("El pedido fue ingresado en forma exitosa!", "Exito!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                nuevo()
                            Else
                                MessageBox.Show("Erroe al insertar!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
                            Dim iResponce = MessageBox.Show("El pedido sera ingresado con problemas de: " & rechazo & "! para su gestiòn esta deacuerdo ? ", "Atención", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                            If (iResponce = 6) Then
                                btn_compromiso.PerformClick()
                            End If
                        End If
                    Else
                        MessageBox.Show("Los campos de notas  no pueden ser ingresados vacios!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Else
                    MessageBox.Show("El pedido esta vacio!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                MessageBox.Show("El campo para la bodega esta vacio!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            MessageBox.Show("La cartera no coinside con el cliente!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub
    Public Sub guardar_con_probl(ByVal compromiso As String)
        If (guardar(problema, compromiso) = True) Then
            MessageBox.Show("El pedido fue ingresado en forma exitosa!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
            nuevo()
            Frm_compromiso.Close()
            Frm_compromiso.Activate()
        Else
            MessageBox.Show("Error al insertar!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub
    Private obj_Ing_prodLn As New Ing_prodLn
    Public Function guardar(ByVal problema As String, ByVal compromiso As String) As Boolean
        Dim listSql As New List(Of Object)
        Dim sql As String = ""
        Dim sw = 1
        Dim band_act As Boolean = False
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
        Dim fecha As String = ""
        Dim precio_min As Double = 0
        Dim sql_insert_aut_enc As String = ""
        Dim sql_insert_aut_dato As String = ""
        'If (vendedor = 1020) Then
        '    vend = objclienteLn.getVendedor(nit)
        'Else
        '    vend = vendedor
        'End If
        sql_insert_aut_enc = ",autorizacion"
        If aut_actualizar = "" Then
            aut_actualizar = "A"
        End If
        sql_insert_aut_dato = ",'" & aut_actualizar & "' "
        If numeroActualizar = 0 Then
            numero = objIngVtaLn.consec_ult_ped + 1
            sql = "UPDATE consecutivos " & _
              "SET siguiente = " & numero & " " & _
              "WHERE tipo = 'ZPE1'"
            listSql.Add(sql)
            fecha = " GETDATE() "
        Else
            sql = "DELETE FROM documentos_ped WHERE numero =" & numeroActualizar
            listSql.Add(sql)
            sql = "DELETE FROM documentos_lin_ped WHERE numero =" & numeroActualizar
            listSql.Add(sql)
            sql = "DELETE FROM JJV_documentos_ped WHERE numero =" & numeroActualizar
            listSql.Add(sql)
            sql = "DELETE FROM JJV_documentos_lin_ped WHERE numero =" & numeroActualizar
            listSql.Add(sql)
            sql = "DELETE FROM documentos_ped_aux WHERE numero =" & numeroActualizar
            listSql.Add(sql)
            numero = numeroActualizar
            fecha = "'" & fecha_actualizar & "'"
            notas_aut_actualizar &= " - mod:" & objUsuarioEn.usuario & "-" & Now.Date
        End If
        vend = vendedor

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
                           vend & "," & fecha & ",'" & condicion & "', " & _
                           dias_validez & ", 0, " & tot_neto & "," & fecha & " ,'" & _
                            strUsuario & "', '" & strPC & "', 100, 0,'A'," & nit & ",'" & notas & "', '" & compromiso & "','" & notaVenta & "','" & nota5 & "','" & problemas_global & "')"
            listSql.Add(sql)

            sql = "INSERT INTO documentos_ped_aux (vendedor,fecha,valor_total,nit,numero)" & _
               "VALUES(" & vend & "," & fecha & "," & tot_neto & "," & nit & "," & numero & ")"
            listSql.Add(sql)

            With dtgPedido
                For i = 0 To .RowCount - 1
                    If IsNumeric(.Item(6, i).Value) Then
                        precio_min = .Item(6, i).Value
                    Else
                        precio_min = 0
                    End If
                    sql = "SELECT cantidad_despachada FROM JJV_documentos_lin_ped  WHERE numero ='" & numero & "'" & _
                            " AND codigo ='" & .Item(1, i).Value & "'"
                    Dim cant_desp As Double = obj_Ing_prodLn.consultar_valor(sql, "CORSAN")

                    sql = "INSERT INTO JJV_documentos_lin_ped " & _
                             "(sw, bodega, numero, codigo, seq, " & _
                             " cantidad, valor_unitario, " & _
                             " cantidad_despachada, porcentaje_iva, porcentaje_descuento, und, cantidad_und, " & _
                             " despacho_virtual, porc_dcto_2, porc_dcto_3,precio_si_costo_cero) " & _
                             "VALUES(" & sw & ", " & bodega & ", " & numero & ", '" & _
                                         .Item(1, i).Value & "', " & i & ", " & _
                                        .Item(3, i).Value & ", " & _
                                         .Item(4, i).Value & "," & cant_desp & ", 19, 0, 'UND', 1, " & _
                                           .Item(3, i).Value & ", 0, 0," & precio_min & ")"
                    listSql.Add(sql)
                Next
            End With
        Else
            'Este compromiso se añade en esta parte por la peticion de colocar de nuevo este campo de notas 2013-04-23
            compromiso = txt_notas_opc.Text
            sql = "INSERT INTO documentos_ped (sw, bodega, " & _
                   "             numero, nit, vendedor,codigo_direccion, fecha, condicion, " & _
                   "             dias_validez, descuento_pie, valor_total, " & _
                   "             fecha_hora, usuario, pc, duracion, anulado, nit2,notas,nota_vta,notas5,notas_aut,Problema" & sql_insert_aut_enc & ") " & _
                   "VALUES(" & sw & ", " & bodega & ", " & _
                               numero & ", " & nit & ", " & _
                               vend & ",0," & fecha & ",'" & condicion & "', " & _
                               dias_validez & ",0, " & tot_neto & ", " & fecha & " ,'" & _
                                 strUsuario & "', '" & strPC & "', 100, 0, " & nit & ",'" & notas & "','" & notaVenta & "','" & nota5 & "','" & notas_aut_actualizar & "','" & problemas_global & "'" & sql_insert_aut_dato & ")"
            listSql.Add(sql)

            sql = "INSERT INTO documentos_ped_aux (vendedor,fecha,valor_total,nit,numero)" & _
                  "VALUES(" & vend & "," & fecha & "," & tot_neto & "," & nit & "," & numero & ")"
            listSql.Add(sql)

            With dtgPedido
                For i = 0 To .RowCount - 1
                    sql = "SELECT cantidad_despachada FROM documentos_lin_ped  WHERE numero ='" & numero & "'" & _
                            " AND codigo ='" & .Item(1, i).Value & "'"
                    Dim cant_desp As Double = obj_Ing_prodLn.consultar_valor(sql, "CORSAN")
                    sql = "INSERT INTO documentos_lin_ped " & _
                             "(sw, bodega, numero, codigo, seq, " & _
                             " cantidad, valor_unitario, " & _
                             " cantidad_despachada, porcentaje_iva, porcentaje_descuento, und, cantidad_und, " & _
                             " despacho_virtual, porc_dcto_2, porc_dcto_3) " & _
                             "VALUES(" & sw & ", " & bodega & ", " & numero & ", '" & _
                                         .Item(1, i).Value & "', " & i & ", " & _
                                        .Item(3, i).Value & ", " & _
                                         .Item(4, i).Value & "," & cant_desp & ", 19, 0, 'UND', 1, " & _
                                           .Item(3, i).Value & ", 0, 0)"
                    listSql.Add(sql)

                Next
            End With
        End If
        resp = objOpSimplesLn.ExecuteSqlTransaction(listSql)
        Return resp
    End Function

    'Private Function actualizar_pedido(ByVal problema As String) As Boolean
    '    Dim listaSql As New List(Of Object)
    '    Dim sql As String = ""
    '    Dim sw = 1
    '    Dim bodega As Integer = Convert.ToInt16(txt_bodega.Text)
    '    Dim nit As Double = Convert.ToDouble(txtNit.Text)
    '    Dim condicion As String = objIngVtaLn.get_condicion(nit)
    '    Dim dias_validez As Integer = 100
    '    Dim tot_neto As Double = Convert.ToDouble(QuitarComasypesos(txt_tot.Text))
    '    Dim strUsuario As String = EliminarEspeciales(My.Computer.Name)
    '    Dim strPC As String = EliminarEspeciales(My.User.Name)
    '    Dim compromiso As String = txt_notas_opc.Text
    '    Dim notas As String = txtNotas.Text
    '    Dim resp As Boolean = False
    '    Dim vend As Integer = 0
    '    'If (vendedor = 1020) Then
    '    '    vend = cbo_vendedores.SelectedValue
    '    'Else
    '    '    vend = vendedor
    '    'End If
    '    vend = vendedor
    '    sql = "DELETE FROM documentos_ped WHERE numero =" & numeroActualizar
    '    listaSql.Add(sql)
    '    sql = "DELETE FROM documentos_lin_ped WHERE numero =" & numeroActualizar
    '    listaSql.Add(sql)
    '    If (problema <> "") Then
    '        If (problema = "B") Then
    '            problema = "B"
    '        End If

    '        sql = "UPDATE JJV_documentos_ped " & _
    '              "SET bodega = " & bodega & ",valor_total = " & tot_neto & ",notas = '" & notas & "',usuario = '" & strUsuario & "',pc = '" & strPC & "',autorizacion ='" & problema & "',notas_aut = '" & compromiso & "' " & _
    '              "WHERE numero = " & numeroActualizar & " and nit = " & nit & " "

    '        listaSql.Add(sql)
    '        sql = "DELETE FROM JJV_documentos_lin_ped WHERE numero = " & numeroActualizar & ""
    '        listaSql.Add(sql)
    '        sql = ""
    '        With dtgPedido
    '            For i = 0 To .RowCount - 1
    '                sql = "INSERT INTO JJV_documentos_lin_ped " & _
    '                         "(sw, bodega, numero, codigo, seq, " & _
    '                         " cantidad, valor_unitario, " & _
    '                         " cantidad_despachada, porcentaje_iva, porcentaje_descuento, und, cantidad_und, " & _
    '                         " despacho_virtual, porc_dcto_2, porc_dcto_3,precio_si_costo_cero) " & _
    '                         "VALUES(" & sw & ", " & bodega & ", " & numeroActualizar & ", '" & _
    '                                     .Item(1, i).Value & "', " & i & ", " & _
    '                                    .Item(3, i).Value & ", " & _
    '                                     .Item(4, i).Value & ", 0, 16, 0, 'UND', 1, " & _
    '                                       .Item(3, i).Value & ", 0, 0," & .Item(6, i).Value & ")"
    '                listaSql.Add(sql)
    '            Next
    '        End With
    '    Else
    '        sql = "UPDATE JJV_documentos_ped SET anulado =  1 where numero = " & numeroActualizar
    '        listaSql.Add(sql)
    '        objIngVtaLn.eliminar("DELETE FROM documentos_lin_ped WHERE numero = " & numeroActualizar)
    '        objIngVtaLn.eliminar("DELETE FROM documentos_lin_ped WHERE numero = " & numeroActualizar)
    '        sql = "INSERT INTO documentos_ped (sw, bodega, " & _
    '               "             numero, nit, vendedor, fecha, condicion, " & _
    '               "             dias_validez, descuento_pie, valor_total, " & _
    '               "             fecha_hora, usuario, pc, duracion, anulado, nit2,notas,notas_aut) " & _
    '               "VALUES(" & sw & ", " & bodega & ", " & _
    '                           numeroActualizar & ", " & nit & ", " & _
    '                           vend & ",GETDATE (),'" & condicion & "', " & _
    '                           dias_validez & ", 0, " & tot_neto & ", GETDATE () ,'" & _
    '                             strUsuario & "', '" & strPC & "', 100, 0, " & nit & ",'" & notas & "', '" & compromiso & "')"
    '        listaSql.Add(sql)
    '        With dtgPedido
    '            For i = 0 To .RowCount - 1
    '                sql = "INSERT INTO documentos_lin_ped " & _
    '                         "(sw, bodega, numero, codigo, seq, " & _
    '                         " cantidad, valor_unitario, " & _
    '                         " cantidad_despachada, porcentaje_iva, porcentaje_descuento, und, cantidad_und, " & _
    '                         " despacho_virtual, porc_dcto_2, porc_dcto_3) " & _
    '                         "VALUES(" & sw & ", " & bodega & ", " & numeroActualizar & ", '" & _
    '                                     .Item(1, i).Value & "', " & i & ", " & _
    '                                    .Item(3, i).Value & ", " & _
    '                                     .Item(4, i).Value & ", 0, 16, 0, 'UND', 1, " & _
    '                                       .Item(3, i).Value & ", 0, 0)"
    '                listaSql.Add(sql)
    '            Next
    '        End With
    '    End If
    '    resp = objOpSimplesLn.ExecuteSqlTransaction(listaSql)
    '    Return resp
    'End Function

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
        lblNroPedido.Text = "Ultimo pedido : " & ultimo_ped & ""
        lblUltimoPedido.Text = "Nùmero pedido : " & ultimo_ped + 1 & ""
        Estado_guardar = True
        problema = ""
        txt_vend.Text = ""
        problemas_global = ""
        condicion = 0
        numeroActualizar = 0
        fecha_actualizar = ""
        aut_actualizar = ""
        notas_aut_actualizar = ""
    End Sub
    Private Sub btn_nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click
        Dim iResponce = MessageBox.Show("Esta seguro que desea ingresar un nuevo pedido?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
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

    Private Sub soloNumero(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If (Char.IsDigit(e.KeyChar) Or e.KeyChar = ".") Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub
End Class

