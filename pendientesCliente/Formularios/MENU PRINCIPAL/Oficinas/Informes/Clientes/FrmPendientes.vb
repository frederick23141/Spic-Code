Imports System.Configuration
Imports entidadNegocios
Imports logicaNegocios
Imports System.IO

Imports Microsoft.Office.Interop
Public Class frmPendientes
    Private objUsuarioLn As New UsuarioLn
    Private objClienteLn As ClienteLn
    Private objAnalisisLn As New AnalisisLn
    Private objValidaciones As ValidacionesEn
    Private objOperacionesForm As OperacionesFormularios = New OperacionesFormularios
    Private objOpSimplesLn As New Op_simpesLn
    Public info As String = " "
    Private objUsuarioEn As New UsuarioEn
    Dim vendedor As Double
    Private nom_modulo As String = ""
    Dim vendedores As String = ""
    Public Sub Main(ByVal nom_modulo As String, ByVal permiso As String, ByVal usuario As UsuarioEn, ByVal objUsuarioEn As UsuarioEn)
        Me.nom_modulo = nom_modulo
        If (permiso <> "ADMIN" Or permiso <> "ADMIN_VENTAS") Then
            btnContCambios.Visible = False
        End If
        vendedor = usuario.Vendedor
        If vendedor <> 1020 Then
            vendedores = vendedor
        Else
            vendedores = objUsuarioLn.coordinadorVend(objUsuarioEn.usuario)
        End If
        Me.objUsuarioEn = objUsuarioEn
    End Sub
    Private Sub btnContCambios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnContCambios.Click
        FrmAuditCambios.Show()
        FrmAuditCambios.Main(nom_modulo)
        FrmAuditCambios.WindowState = 2

    End Sub
    '****************************************************************************************************************
    '**** Se llaman a los metodos descritos dentro de frmPendientes_Load cuando se carga el formulario***************
    '****************************************************************************************************************
    Private Sub frmPendientes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.centrarEnPantalla()
        Me.AutoScroll = True
        objClienteLn = New ClienteLn
        objValidaciones = New ValidacionesEn
        '   objOperacionesForm = New OperacionesFormularios
        Me.txtNit.Select()
        'txtNit.Text = " "
        'btnDespachos.Visible = False
        'btn_compromiso.Visible = False
        'Me.Size = Screen.PrimaryScreen.WorkingArea.Size
        Dim año = Now.Year
        While (año >= Now.Year - 5)
            cboAñoIni.Items.Add(año)
            cboAñoFin.Items.Add(año)
            año -= 1
        End While
        Me.WindowState = 2
    End Sub
#Region "Funciones y procedimientos formulario"
    '****************************************************************************************************************
    'Metodo que recibe el nit de un registro y con este llama a los diferentes metodos encargados de hacer las -
    'consultas y asi se cargan los datos en los grids y se hacen las operaciones de las cajas de texto***************
    '****************************************************************************************************************
    Public Sub cargarTodo(ByVal nit As Double)
        limpiar()

        dtgFactura.DataSource = objClienteLn.listar_may_vta(nit)
        txtTotValTot.Text = Format(sumar_col_grid(dtgFactura, "Vr_total"), "###,###,###")
        txtTotKilos.Text = Format(sumar_col_grid(dtgFactura, "Kilos"), "###,###,###")

        dtgPendientes.DataSource = objClienteLn.listarPendientes(nit)
        dtgCartera.DataSource = objClienteLn.listarCartera(nit)
        dtgPendientes.Columns("fecha").DefaultCellStyle.Format = "d"
        '*************Sumar Datos Cartera***********************
        txtValTot.Text = Format(objClienteLn.sumValorTotalCartera(nit), "###,###,###")
        txtValAplica.Text = Format(objClienteLn.sumValAplicado(nit), "###,###,###")
        txtSaldo.Text = Format(objClienteLn.sumSaldo(nit), "###,###,###")
        txtSinVencer.Text = Format(objClienteLn.sumSinVencer(nit), "###,###,###")
        Dim S1a30 As Double = objClienteLn.sum1a30(nit)
        Dim S31a60 As Double = objClienteLn.sum31a60(nit)
        Dim S61a91 As Double = objClienteLn.sum61a91(nit)
        Dim S91a120 As Double = objClienteLn.sum91a120(nit)
        Dim Smas120 As Double = objClienteLn.sumMas120(nit)
        Dim condicion As String = ""
        txt1a30.Text = Format(S1a30, "###,###,###")
        txt31a60.Text = Format(S31a60, "###,###,###")
        txt61a91.Text = Format(S61a91, "###,###,###")
        txt91a120.Text = Format(S91a120, "###,###,###")
        txtMas120.Text = Format(Smas120, "###,###,###")
        txtTotDias.Text = Format((S1a30 + S31a60 + S61a91 + S91a120), "###,###,###")
        txtPenValtot.Text = Format(objClienteLn.sumPenValTot(nit), "###,###,###")
        txtPenKilos.Text = Format(objClienteLn.sumPenKilos(nit), "###,###,###")
        txtMayVen.Text = Format(objClienteLn.mayVenta(nit), "###,###,###")

        txt_cheq_dev.Text = Format(objClienteLn.sumar_cheq_dev(nit), "###,###,###")

        dtgFactura.Columns("fec").DefaultCellStyle.Format = "d"
        dtgCartera.Columns("Fecha").DefaultCellStyle.Format = "d"
        dtgCartera.Columns("Vencimiento").DefaultCellStyle.Format = "d"
        If (txtMayVen.Text.ToString = "") Then
        Else
            lblFecMayVen.Text = objClienteLn.fechMayVenta(nit, txtMayVen.Text.ToString)
        End If


        Dim cupoPenValtot As Double = 0
        Dim cupoSaldo As Double = 0
        If (txtPenValtot.Text = "") Then
        Else
            cupoPenValtot = Convert.ToDouble(txtPenValtot.Text)
        End If
        If (txtSaldo.Text = "") Then
        Else
            cupoSaldo = Convert.ToDouble(txtSaldo.Text)
        End If
        Dim sql As String = "SELECT condicion FROM terceros WHERE nit = " & nit

        condicion = objOpSimplesLn.consultarVal(sql)
        If (condicion = 201) Then
            If (txtPenValtot.Text <> "") Then
                Dim pendientes As Double = Convert.ToDouble(txtPenValtot.Text)
                txtCupDisponible.Text = Format((cupoSaldo * -1) - pendientes, "###,###,###")
            Else
                txtCupDisponible.Text = cupoSaldo
            End If
        Else
            txtCupDisponible.Text = Format(objClienteLn.cupoDisponible(nit, cupoPenValtot, cupoSaldo), "###,###,###")
        End If
        btnDespachos.Visible = True
        btn_compromiso.Visible = True
        'es para la informacion de impresion pero esta generarndo error cuando se carga el formulario desde otro para buscar un nit   'info = "Nit: " & txtNit.Text & " " & "Nombre: " & dtgResultCliente.CurrentRow.Cells("nombres").Value
    End Sub
    Public Function sumar_col_grid(ByVal dtg As DataGridView, ByVal col As String) As Double
        Dim suma As Double = 0
        For i = 0 To dtg.RowCount - 1
            suma = suma + dtg.Item(col, i).Value
        Next
        Return suma
    End Function

    '****************************************************************************************************************
    'Se limpian todos los campos de el formulario********************************************************************
    '****************************************************************************************************************
    Public Sub limpiar()
        dtgCartera.DataSource = Nothing
        dtgFactura.DataSource = Nothing
        dtgPendientes.DataSource = Nothing
        txtNombreC.Text = ""
        txtSaldo.Text = ""
        txtSinVencer.Text = ""
        txtTotKilos.Text = ""
        txtTotValTot.Text = ""
        txtValAplica.Text = ""
        txtValTot.Text = ""
        txt1a30.Text = ""
        txt31a60.Text = ""
        txt61a91.Text = ""
        txt91a120.Text = ""
        txtMas120.Text = ""
        txtTotDias.Text = ""
        txtPenKilos.Text = ""
        txtPenValtot.Text = ""
        txtPenValtot.Text = "0"
        txtSaldo.Text = "0"
        txtCupDisponible.Text = ""
        txtMayVen.Text = ""
        txt_cheq_dev.Text = ""
        cboAñoIni.SelectionStart = 0
        cboAñoFin.SelectionStart = 0
        cboMesFin.SelectedIndex = -1
        cboMesIni.SelectedIndex = -1
        btnDespachos.Visible = False
        btn_compromiso.Visible = False
        lblFecMayVen.Text = ""
    End Sub


    '****************************************************************************************************************
    '*' posición x.y del formulario: centrado en la pantalla*********************************************************
    '****************************************************************************************************************
    Private Sub centrarEnPantalla()
        Me.Left = (Screen.PrimaryScreen.WorkingArea.Width - Me.Width) / 2
        Me.Top = (Screen.PrimaryScreen.WorkingArea.Height - Me.Height) / 2
    End Sub
    '*****************************************************************************************************************
    '****Ajusta los grid y sus columnas cuando para mostrar los datos de el cliente***********************************
    '*****************************************************************************************************************
#End Region

#Region "controles formulario"
    '****************************************************************************************************************
    '********** Evento que se produce cuando se presina el boton btnBuscarNit (buscar nit) '*************************
    '****************************************************************************************************************
    Private Sub btnBuscarNit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarNit.Click
        If (txtNit.Text <> "") Then
            buscarNit()
        Else
            MessageBox.Show("Ingrese un NIT ")
        End If
    End Sub
    Private Sub buscarNit()
        Dim nit As Double = txtNit.Text
        If (objClienteLn.existeUsuarioTERCEROS(nit, vendedores)) Then
            If (objClienteLn.existeUsuario(nit)) Then
                dtgResultCliente.DataSource = objClienteLn.listarDatosCliente(nit)
                dtgResultCliente.Columns("fecha_modificacion").DefaultCellStyle.Format = "d"
                dtgResultCliente.Columns("fecha_creacion").DefaultCellStyle.Format = "d"
                cargarTodo(nit)
            Else

                MessageBox.Show("el cliente no tiene promedio dias de pago, debido a que no a cancelado su primer factura!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
                dtgResultCliente.DataSource = objClienteLn.listarDatosClienteTERCEROS(nit)
                cargarTodo(nit)
            End If
        Else
            MessageBox.Show("nit: " & nit & " no existe ó no se tiene permiso para ver su información!", "Pendientes")
            dtgResultCliente.DataSource = Nothing
            limpiar()
        End If
    End Sub
    '****************************************************************************************************************
    '***********Evento que se produce cuando se da click en una celda del grid resultCliente sirve para cargar*******
    '*************** los datos con el Nit que tenga el registo en la celda ******************************************
    '****************************************************************************************************************
    Private Sub dtgResultCliente_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgResultCliente.CellDoubleClick
        If (e.ColumnIndex = 0) Then
            Dim nit As Double = dtgResultCliente.CurrentRow.Cells("nit").Value
            txtNit.Text = nit
            dtgResultCliente.DataSource = objClienteLn.listarDatosCliente(nit)
            cargarTodo(nit)
        End If

    End Sub
    '****************************************************************************************************************
    '********** Este metodo permite bloquear las teclas diferentes a numeros '***************************************
    '****************************************************************************************************************
    Private Sub txtNit_TextChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNit.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            btnBuscarNit.PerformClick()
        End If
    End Sub
    '****************************************************************************************************************
    '** se produce cuando se cambia de item en el combox se utliza para validar que primero se seleccione el mes
    '** y tambien si se tiene seleccionado en año para que se cargen los datos**************************************
    '****************************************************************************************************************
    Private Sub cboAñoFin_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAñoFin.SelectedIndexChanged
        Dim mesini As Integer = cboMesIni.SelectedIndex + 1
        Dim añoIni As Integer = cboAñoIni.SelectedItem
        Dim mesFin As Integer = cboMesFin.SelectedIndex + 1
        Dim añoFin As Integer = cboAñoFin.SelectedItem
        If (cboAñoFin.SelectedItem <> 0) Then
            If (cboAñoFin.SelectedIndex <> -1) Then
                If (txtNit.Text = " ") Then
                    MessageBox.Show("Debe ingresar un  NIT", "Pendientes")
                Else
                    dtgFactura.DataSource = objClienteLn.listarFactura(txtNit.Text, mesini, añoIni, mesFin, añoFin, "")
                    txtTotValTot.Text = objClienteLn.sumValorTotal(txtNit.Text, mesini, añoIni, mesFin, añoFin)
                    txtTotKilos.Text = objClienteLn.sumTotKilos(txtNit.Text, mesini, añoIni, mesFin, añoFin)
                End If
            End If

        End If
    End Sub
    '*****************************************************************************************************************
    'Controles del strip menù*****************************************************************************************
    '*****************************************************************************************************************
    Private Sub AnalisisPedidoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        FrmAnalisisPedido.Show()
        Me.Close()
        FrmAnalisisPedido.Activate()
    End Sub
    Private Sub AcumuladoVentasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FrmAcumVenClien.Show()
        Me.Close()
        FrmAcumVenClien.Activate()
    End Sub

#End Region

    '************************funcion para cuando este formulario desde otro para cargar los dastos de un determinado cliente
    Public Sub cargarInfoClient(ByVal nit As Integer)
        'dtgResultCliente.DataSource = objClienteLn.listarDatosCliente(nit)
        'cargarTodo(nit)
        txtNit.Text = nit
        btnBuscarNit.PerformClick()
    End Sub

    'dtg_no_reflejados.Columns("fec").DefaultCellStyle.Format = "d"

    Private Sub dtgPenBuenos_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dtgPendientes.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            With (Me.dtgPendientes)
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                End If
            End With
        End If
    End Sub
    Private Sub VerStockToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VerStockToolStripMenuItem.Click
        Dim codigo As String = dtgPendientes.Item("codigo", dtgPendientes.CurrentCell.RowIndex).Value
        MessageBox.Show(objAnalisisLn.consultarStock(codigo), "Stock", MessageBoxButtons.OK)
    End Sub

    Private Sub Btn_cheq_dev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_cheq_dev.Click
        If (txtNit.Text <> "") Then
            Dim dFec As Date = Now.AddMonths(-6)
            Dim fec As String = objOpSimplesLn.cambiarFormatoFecha(dFec)
            Dim datos As DataTable = objClienteLn.listar_cheq_dev(txtNit.Text, fec)
            Frm_cheq_dev.Show()
            Frm_cheq_dev.main(datos)
            Frm_cheq_dev.Activate()
        Else
            MessageBox.Show("Seleccione un cliente", "Seleccione", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub
    Private Sub ToolStripButton2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        FrmPrincipal.Show()
        Me.Close()
        FrmPrincipal.Activate()
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        FrmLogin.Show()
        FrmPrincipal.Close()
        FrmLogin.Activate()
        Me.Close()
    End Sub

    Private Sub men_info_client_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles men_info_client.Click
        objOperacionesForm.ExportarDatosExcel(dtgResultCliente, "Datos cliente")
    End Sub

    Private Sub PendientesToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PendientesToolStripMenuItem2.Click
        objOperacionesForm.ExportarDatosExcel(dtgPendientes, "Pendientes")
    End Sub

    Private Sub CarteraToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CarteraToolStripMenuItem2.Click
        objOperacionesForm.ExportarDatosExcel(dtgCartera, "Cartera")
    End Sub

    Private Sub FacturaciónToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FacturaciónToolStripMenuItem.Click
        objOperacionesForm.ExportarDatosExcel(dtgFactura, "Facturaciòn mes actual")
    End Sub

    Private Sub InfoClienteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InfoClienteToolStripMenuItem.Click
        objOperacionesForm.Print_DataGridView(dtgResultCliente, "DATOS" & "       " & info)
    End Sub

    Private Sub PendientesToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PendientesToolStripMenuItem3.Click
        objOperacionesForm.Print_DataGridView(dtgPendientes, "PENDIENTES" & "       " & info)
    End Sub

    Private Sub CarteraToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CarteraToolStripMenuItem3.Click
        objOperacionesForm.Print_DataGridView(dtgCartera, "CARTERA" & "       " & info)
    End Sub

    Private Sub FacturaciónToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FacturaciónToolStripMenuItem1.Click
        objOperacionesForm.Print_DataGridView(dtgFactura, "FACTURACIÒN MES ACTUAL" & "       " & info)
    End Sub

    Private Sub btnDespachos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDespachos.Click
        If txtNit.Text = "" Then
            MessageBox.Show("Ingrese un NIT ", "Pendientes")
        Else
            'Me.Hide()
            frmDespacho.Show()
            frmDespacho.Main(txtNit.Text, vendedor)
            frmDespacho.Activate()
        End If
    End Sub

    Private Sub btn_compromiso_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_compromiso.Click
        If (txtNit.Text <> "") Then
            Frm_ver_compromisos.Show()
            Frm_ver_compromisos.comp_cliente(txtNit.Text)
            Frm_ver_compromisos.Activate()
        End If
    End Sub


    Private Sub btnOcultarDtgConsulta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOcultarDtgConsulta.Click
        dtgConsulta.Visible = False
        dtgConsulta.DataSource = Nothing
        txtNombreC.Text = ""
        btnOcultarDtgConsulta.Visible = False
    End Sub

    Private Sub txtNombreC_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNombreC.TextChanged, txtNombreC.KeyPress
        If (txtNombreC.Text.Length > 3) Then
            btnOcultarDtgConsulta.Visible = True
            dtgConsulta.Visible = True
            Dim where_vend As String = ""
            If vendedores <> "" Then
                where_vend = "AND vendedor IN (" & vendedores & ")"
            End If
            dtgConsulta.DataSource = objOpSimplesLn.listar_datatable("SELECT nit,nombres,ciudad FROM terceros WHERE nombres like '%" & txtNombreC.Text & "%' " & where_vend & " ", "CORSAN")
        End If
    End Sub
    Private Sub dtgConsulta_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgConsulta.CellContentClick
        Dim col As String = dtgConsulta.Columns(e.ColumnIndex).Name
        Dim fila As Integer = e.RowIndex
        If (fila >= 0) Then
            If (col = colCargar.Name) Then
                txtNit.Text = dtgConsulta.Item("nit", fila).Value
                buscarNit()
                dtgConsulta.Visible = False
                btnOcultarDtgConsulta.Visible = False
            End If
        End If
    End Sub

    Private Sub dtgConsulta_CellMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dtgConsulta.CellMouseDoubleClick
        txtNit.Text = dtgConsulta.Item("nit", e.RowIndex).Value
        buscarNit()
        btnOcultarDtgConsulta.Visible = True
        dtgConsulta.Visible = False
    End Sub


End Class
