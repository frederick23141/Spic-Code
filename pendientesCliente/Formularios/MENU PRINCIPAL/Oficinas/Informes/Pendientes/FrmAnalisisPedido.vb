Imports System.Configuration
Imports logicaNegocios
Imports entidadNegocios
Imports System.IO
Imports Microsoft.Office.Interop
Imports accesoDatos
Imports System.ComponentModel
Public Class FrmAnalisisPedido
    Private objUsuarioLn As New UsuarioLn
    Private objEnvCorreoLN As New EnvCorreoLN
    Private objLoginLn As New LoginLn
    Private objAnalisisLn As AnalisisLn
    Private objAnalisisEn As AnalisisEn
    Private objOpercionesForm As OperacionesFormularios = New OperacionesFormularios
    Private criterioAux As Double = 0
    Private columaAux As String = "nit"
    Private strDtgSeleccion As String = ""
    Public objUsuarioEn As UsuarioEn
    Private listaAnalisisBueno As List(Of AnalisisEn)
    Private objOp_simpesLn As New Op_simpesLn
    Private nom_modulo As String = ""
    Private objOpSimplesAd As New Op_simplesAd
    Dim val_Strip As String
    Dim sql_strip As String
    Dim vendedores As String
    Dim iva As Double
    Public Sub Main(ByVal nom_modulo As String, ByVal permiso As String, ByVal objUsuarioEn As UsuarioEn)
        Me.nom_modulo = nom_modulo
        Me.objUsuarioEn = objUsuarioEn
        If (permiso <> "ADMIN" Or permiso <> "ADMIN_VENTAS") Then
            btnContCambios.Visible = False
        End If
        If (permiso = "LOGISTICA") Then
            tbl_datos.TabPages.Remove(tbla_no_reflej)
        End If
        sql_strip = "select autped from jjv_usuarios where Usuario='" & objUsuarioEn.usuario & "'"
        val_Strip = objOp_simpesLn.consultarVal(sql_strip)
        If val_Strip <> "" Then
            menStripDtg.Enabled = False
            menStripNoRelej.Enabled = False
        End If
        vendedores = objUsuarioLn.coordinadorVend(objUsuarioEn.usuario)
        iva = objOp_simpesLn.getIvaPorc()
    End Sub
    Private Sub btnContCambios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnContCambios.Click
        FrmAuditCambios.Show()
        FrmAuditCambios.Main(nom_modulo)
        FrmAuditCambios.WindowState = 2
    End Sub
    Private Sub FrmAnalisisPedido_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        objAnalisisLn = New AnalisisLn
        objAnalisisEn = New AnalisisEn
        Me.CenterToScreen()
        Me.AutoScroll = True
        txtMin.Select()
        imgProc.Visible = False
        imgProc2.Visible = False
        imgProc3.Visible = False
        imgProc4.Visible = False
        imgProc5.Visible = False
        tblCupCredit.Parent = Nothing
        tblDocVenc.Parent = Nothing
        TabPage1.Parent = Nothing
        btnModPed.Enabled = False
        AnularPedidoToolStripMenuItem.Enabled = False
        Me.Size = Screen.PrimaryScreen.WorkingArea.Size
        Me.CenterToScreen()
        lblIva.Text = "Iva " & objOp_simpesLn.getIvaPorc() * 100 & " %"
    End Sub
#Region "Funciones y procedimientos formulario"

    Private Sub listar_valor_menor(ByRef vendedores As String)
        Dim sql As String = ""


        Dim sVendedores As String = ""
        Dim listUsuarios As List(Of Object)
        sql = "SELECT vendedor FROM J_spic_coord_vend WHERE usuario ='" & objUsuarioEn.usuario & "' and vendedor <> 1043"
        listUsuarios = objOpSimplesAd.lista(sql)
        For i = 0 To listUsuarios.Count - 1
            sVendedores &= Convert.ToString(listUsuarios(i))
            If (i <> listUsuarios.Count - 1) Then
                sVendedores += ","
            End If
        Next

        Dim where_sql As String = ""
        If sVendedores <> "" Then
            where_sql = " AND Ptes.vendedor IN (" & sVendedores & ") "
        End If
        'sql = "SELECT distinct  Ptes.vendedor,Ptes.ciudad, Ptes.numero,Ptes.fecha,Ptes.nombres,Ptes.codigo,Ptes.descripcion,ptes.Cant_pedida,ptes.cantidad_despachada,Ptes.Pendiente,Ptes.KilosPendiente,ptes.valor_unitario,Ptes.Valor_total,Ptes.notas ,Ptes.nota_vta,Ptes.notas5 ,ptes.notas_aut,Ptes.nit,Ptes.bloqueo,Ptes.condicion AS Credito,Ptes.autorizacion,ptes.bodega " & _
        ' "FROM V_pendientes_por_vendedor Ptes , terceros cli  " & _
        ' "WHERE Ptes.vr_tot_pedido <= 40000 And cli.nit = ptes.nit " & where_sql & _
        '   "ORDER BY Ptes.vendedor,Ptes.nombres,Ptes.fecha"
        'dtg_val_menor.DataSource = objOp_simpesLn.listar_datatable(sql, "CORSAN")
        ' dtg_val_menor.Columns("fecha").DefaultCellStyle.Format = "d"
        ' dtg_val_menor.Columns("Pendiente").DefaultCellStyle.Format = "N1"
    End Sub
    Private Function sumarColumnas(ByVal nomColumna As String, ByVal dtg As DataGridView) As Double
        Dim total As Double = 0
        For i As Integer = 0 To dtg.RowCount - 1
            total = total + CDbl(dtg.Item(nomColumna.ToLower, i).Value)
        Next
        Return total
    End Function
    Private Sub limpiar()

        dtgCupCred.DataSource = Nothing
        dtgBloq.DataSource = Nothing
        dtgDocVen.DataSource = Nothing
        dtgPenBuenos.DataSource = Nothing
        dtg_no_reflejados.DataSource = Nothing

        txtTotKilosBueno.Text = " "
        txtBueVal.Text = " "
        txtKilBloq.Text = " "
        txtValBloq.Text = " "
        txtKilDoc.Text = " "
        txtValDoc.Text = " "
        txtKilCupo.Text = " "
        txtValCupo.Text = " "
        txtTotKilo.Text = " "
        txtTotVal.Text = " "
        txtValtotbusq.Text = " "
        txt_val_no_reflej.Text = 0
    End Sub
    '*******************************************************************************************
    'Busca un dato en el grid y lo pinta de un color diferente**********************************
    '*******************************************************************************************
    Private Sub buscarColumnas(ByVal criterio As Double, ByVal col As String)
        Dim dtg As DataGridView = dtgPenBuenos
        Dim j As Integer = 0
        Dim sw As Boolean = False
        Dim sum As Double = 0
        Dim iva As Double = objOp_simpesLn.getIvaPorc()
        tbl_datos.SelectedTab = tblPenBuenos
        For i = 0 To 4
            Select Case i
                Case 1
                    dtg = dtgBloq
                    tbl_datos.SelectedTab = tblBloq
                Case 2
                    dtg = dtgDocVen
                    tbl_datos.SelectedTab = tblDocVenc
                Case 3
                    dtg = dtgCupCred
                    tbl_datos.SelectedTab = tblCupCredit
                Case 4
                    dtg = dtg_no_reflejados
                    tbl_datos.SelectedTab = tbla_no_reflej
            End Select
            For j = 0 To dtg.RowCount - 1
                If (dtg.Item(col, j).Value = criterio) Then
                    dtg.Rows(j).DefaultCellStyle.BackColor = Color.Red
                    sum = sum + dtg.Item("vr_total".ToLower, j).Value
                    sw = True
                    i = 4
                End If
            Next
            txtValtotbusq.Text = Format(sum * (iva + 1), "###,###,###")
        Next
        If sw = False Then
            MessageBox.Show("Nùmero de pedido no encontrado, Verifique!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub
    Private Sub buscarNitNoReflej(ByVal nit As Double)
        For i = 0 To dtg_no_reflejados.RowCount - 1
            If (dtg_no_reflejados.Item("nit", i).Value = nit) Then
                dtg_no_reflejados.Rows(i).DefaultCellStyle.BackColor = Color.Red
                criterioAux = nit
            End If
        Next
    End Sub

    '**********************************************************************************************************
    'Permite pintar de blanco las celdas que anteriormente fueron pintadas de un color diferente en la busqueda
    '**********************************************************************************************************
    Private Sub limpiarColumnas()
        Dim dtg As DataGridView = dtgPenBuenos
        Dim j As Integer = 0
        Dim sum As Double = 0
        For i = 0 To 4
            Select Case i
                Case 1
                    dtg = dtgBloq
                Case 2
                    dtg = dtgDocVen
                Case 3
                    dtg = dtgCupCred
                Case 4
                    dtg = dtg_no_reflejados
            End Select
            For j = 0 To dtg.RowCount - 1
                If (dtg.Rows(j).DefaultCellStyle.BackColor = Color.Red) Then
                    dtg.Rows(j).DefaultCellStyle.BackColor = Color.Gainsboro
                    i = 4
                End If
            Next
        Next

    End Sub
    Public Sub sumarValPed(ByVal nit As Integer)
        Dim dtg As DataGridView = dtgPenBuenos
        Dim iva As Double = objOp_simpesLn.getIvaPorc()
        Dim suma As Double = 0
        Dim j As Integer = 0
        Dim sw As Boolean = False
        Try
            While j <= 4 And sw = False
                Dim i As Integer = 0
                While i <= dtg.RowCount - 1
                    If (dtg.Item("Numero".ToLower, i).Value) = nit Then
                        suma = suma + dtg.Item("vr_total".ToLower, i).Value
                        sw = True
                    End If
                    i = i + 1
                End While
                j = j + 1
                Select Case j
                    Case 1
                        dtg = dtgBloq
                    Case 2
                        dtg = dtgDocVen
                    Case 3
                        dtg = dtgCupCred
                End Select
            End While
            If sw = False Then

            End If
            txtValtotbusq.Text = Format(suma * (iva + 1), "###,###,###")
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub
    Public Sub sumarValPedNoReflej(ByVal numero As Integer)
        Dim j As Integer = 0
        Dim sw As Boolean = False
        Dim suma As Double = 0
        Dim iva As Double = objOp_simpesLn.getIvaPorc()
        Try
            For i = 0 To dtg_no_reflejados.RowCount - 1
                If (dtg_no_reflejados.Item("numero", i).Value = numero) Then
                    suma += (dtg_no_reflejados.Item("valor_unitario", i).Value) * (dtg_no_reflejados.Item("cantidad", i).Value)
                End If
            Next

            txtValtotbusq.Text = Format(suma * (iva + 1), "###,###,###")
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub

#End Region

#Region "Controles del formulario"
    Private Sub btnBuscarPedido_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarPedido.Click
        If (txtCriterio.Text = "") Then
            MessageBox.Show("Ingrese un numero de pedido!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            limpiarColumnas()
            If (txtCriterio.Text <> "") Then
                txtValtotbusq.Text = ""
                buscarColumnas(Convert.ToDouble(txtCriterio.Text), "Numero")
            End If
        End If
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        limpiar()
        If (txtMin.Text <> "" And txtMax.Text <> "") Then
            If (txtMin.Text < 1001 Or txtMin.Text > 1099 Or txtMax.Text < 1001 Or txtMax.Text > 1099) Then
                MessageBox.Show("El rango de el vendedor debe estar entre 1001 y 1099", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                imgProc.Visible = True
                imgProc2.Visible = True
                imgProc3.Visible = True
                imgProc4.Visible = True
                imgProc5.Visible = True
                Application.DoEvents()
                '  cargartodo()
                gestionar_pendietes()
                imgProc.Visible = False
                imgProc2.Visible = False
                imgProc3.Visible = False
                imgProc4.Visible = False
                imgProc5.Visible = False
                ' pintarPrecioMin_Rnt()
            End If
        Else
            MessageBox.Show("Criterio de busqueda vacio", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    '*******************************************************************************************
    'Controles tool strip menu******************************************************************
    '*******************************************************************************************
    Private Sub GestiònClientesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmPendientes.Show()
        Me.Close()
        frmPendientes.Activate()
    End Sub

    Private Sub AcumuladoVentasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FrmAcumVenClien.Show()
        Me.Close()
        FrmAcumVenClien.Activate()
    End Sub

    Private Sub PrincipalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FrmPrincipal.Show()
        FrmPrincipal.Activate()
        Me.Close()
    End Sub
    Private Sub txtMin_TextChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMin.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            btnBuscar.PerformClick()
        End If
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub
    Private Sub txtMax_TextChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMax.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            btnBuscar.PerformClick()
        End If
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub
    Private Sub txtCriterio_TextChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCriterio.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            btnBuscarPedido.PerformClick()
        End If
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

    End Sub
    Private Sub txt_busq_nit_TextChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            btnBuscarPedido.PerformClick()
        End If
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

    End Sub
    Private Sub dtgPenBuenos_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dtgPenBuenos.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            strDtgSeleccion = "buenos"
            With (Me.dtgPenBuenos)
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                End If
            End With
        End If
    End Sub
    Private Sub dtg_val_menorDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dtg_val_menor.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            strDtgSeleccion = "dtg_val_menor"
            With (Me.dtg_val_menor)
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                End If
            End With
        End If
    End Sub
    Private Sub dtgBloq_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dtgBloq.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            strDtgSeleccion = "bloq"
            With (Me.dtgBloq)
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                End If
            End With
        End If
    End Sub
    Private Sub dtgDocVen_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dtgDocVen.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            strDtgSeleccion = "venc"
            With (Me.dtgDocVen)
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                End If
            End With
        End If
    End Sub
    Private Sub dtgCupCred_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dtgCupCred.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            strDtgSeleccion = "cupo"
            With (Me.dtgCupCred)
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                End If
            End With
        End If
    End Sub
    Private Sub dtg_no_reflejados_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dtg_no_reflejados.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            strDtgSeleccion = "no_reflej"
            With (Me.dtg_no_reflejados)
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                End If
            End With
        End If
    End Sub
    Private Sub itemMail_Opening(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles itemMail.Click
        Dim nit As Integer = 0
        Dim dtg As DataGridView = Nothing
        Select Case strDtgSeleccion
            Case "buenos"
                dtg = dtgPenBuenos
            Case "bloq"
                dtg = dtgBloq
            Case "venc"
                dtg = dtgDocVen
            Case "cupo"
                dtg = dtgCupCred
            Case "no_reflej"
                dtg = dtg_no_reflejados
        End Select
        Dim nombre As String
        nit = dtg(0, dtg.CurrentCell.RowIndex).Value
        nombre = dtg("nombres", dtg.CurrentCell.RowIndex).Value
        FrmDatosMail.Show()
        frmPendientes.Show()
        frmPendientes.cargarInfoClient(nit)
        Application.DoEvents()
        FrmDatosMail.capturarPantalla()
        frmPendientes.Close()
        FrmDatosMail.iniciarValores(Environment.CurrentDirectory & "\informacion.jpg", objUsuarioEn, nombre)
        FrmDatosMail.Activate()
    End Sub
    Private Sub itemMasInfo_Opening(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles itemMasInfo.Click
        Dim nit As Integer
        Dim dtg As DataGridView = Nothing
        Select Case strDtgSeleccion
            Case "buenos"
                dtg = dtgPenBuenos
            Case "bloq"
                dtg = dtgBloq
            Case "venc"
                dtg = dtgDocVen
            Case "cupo"
                dtg = dtgCupCred
            Case "no_reflej"
                dtg = dtg_no_reflejados
            Case "dtg_val_menor"
                dtg = dtg_val_menor
        End Select
        nit = dtg("nit", dtg.CurrentCell.RowIndex).Value
        frmPendientes.Show()
        frmPendientes.cargarInfoClient(nit)
        frmPendientes.Activate()
    End Sub
    Private Sub itemAutorizar_Opening(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles itemAutorizar.Click
        Dim usuario As String = objUsuarioEn.nombre
        Dim dtg As DataGridView = Nothing
        Dim numeroPed As Integer = 0
        Dim vendedor As Integer = 0
        Dim nombre_cliente As String = ""
        Select Case strDtgSeleccion
            Case "buenos"
                dtg = dtgPenBuenos
            Case "bloq"
                dtg = dtgBloq
            Case "venc"
                dtg = dtgDocVen
            Case "cupo"
                dtg = dtgCupCred
        End Select
        numeroPed = dtg(1, dtg.CurrentCell.RowIndex).Value
        vendedor = dtg("vendedor", dtg.CurrentCell.RowIndex).Value
        nombre_cliente = dtg("nombres", dtg.CurrentCell.RowIndex).Value
        FrmAutorizar.Show()
        FrmAutorizar.inicializarVar(numeroPed, strDtgSeleccion, vendedor, objUsuarioEn, nombre_cliente)
        FrmAutorizar.Activate()
    End Sub
#End Region

    Public Sub insertarEnGrid()
        Dim numero As Integer = 0
        Dim dtg As DataGridView = Nothing
        objAnalisisEn = New AnalisisEn
        Select Case strDtgSeleccion
            Case "buenos"
                dtg = dtgPenBuenos
            Case "bloq"
                dtg = dtgBloq
            Case "venc"
                dtg = dtgDocVen
            Case "cupo"
                dtg = dtgCupCred
            Case "no_reflej"
                dtg = dtg_no_reflejados

        End Select
        numero = dtg("numero", dtg.CurrentCell.RowIndex).Value
        Dim cm As CurrencyManager = CType(BindingContext(dtg.DataSource), CurrencyManager)
        cm.SuspendBinding()
        For i = 0 To dtg.RowCount - 1
            If (dtg.Item("Numero".ToLower, i).Value) = numero Then
                'dtg(2, i).Value = "S"
                'objAnalisisEn.fechaA = dtg(3, i).Value
                'objAnalisisEn.codigo = dtg(4, i).Value
                'objAnalisisEn.descripcionA = dtg(5, i).Value
                'objAnalisisEn.pendienteA = dtg(6, i).Value
                'objAnalisisEn.kilos = dtg(7, i).Value
                'objAnalisisEn.vr_total = dtg(8, i).Value
                'objAnalisisEn.notasA = dtg(15, i).Value
                'objAnalisisEn.vendedorA = dtg(9, i).Value
                'objAnalisisEn.ciudadaA = dtg(10, i).Value
                'objAnalisisEn.nit = dtg(0, i).Value
                'objAnalisisEn.nombresA = dtg(11, i).Value
                'objAnalisisEn.promDiasA = dtg(12, i).Value
                'objAnalisisEn.bloqueoA = dtg(13, i).Value
                'objAnalisisEn.creditoA = dtg(14, i).Value
                'objAnalisisEn.Numero = numero
                'objAnalisisEn.aut = "S"

                ' listaAnalisisBueno.Add(objAnalisisEn)
                dtg.CurrentCell = Nothing
                dtg.Rows(i).Visible = False

            End If
        Next
        dtgPenBuenos.DataSource = Nothing
        dtgPenBuenos.DataSource = listaAnalisisBueno
    End Sub
    Private Sub BorrarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BorrarToolStripMenuItem.Click
        Dim numero As Double = dtg_no_reflejados.Item("numero", dtg_no_reflejados.CurrentCell.RowIndex).Value
        Dim vendedor As Double = dtg_no_reflejados.Item("vendedor", dtg_no_reflejados.CurrentCell.RowIndex).Value
        Dim nombre_cliente As String = dtg_no_reflejados.Item("nombres", dtg_no_reflejados.CurrentCell.RowIndex).Value
        If (consularEstadoNR(numero)) Then
            dtg_no_reflejados.Rows.RemoveAt(dtg_no_reflejados.CurrentCell.RowIndex)
            MessageBox.Show("Este pedido fue autorizado o anulado previamente, porfavor actualice la consulta!", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            Dim iResponce = MessageBox.Show("Esta seguro que desea eliminar el  pedido numero " & numero & " de la lista? ", "Atención", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
            If (iResponce = 6) Then
                Dim argumento As String = InputBox("ingrese motivo de la anulaciòn del pedido")
                If (argumento <> "") Then
                    If (objAnalisisLn.anular_no_reflej(numero) = 1) Then
                        Dim mailDestino As String = ""
                        If (vendedor = 1020) Then
                            mailDestino = "andrea.gonzalez@corsan.com.co"
                        Else
                            mailDestino = objLoginLn.obtenerEmail(vendedor)
                        End If
                        Dim mailEnvia As String = objUsuarioEn.Email
                        Dim mailEnviaPass As String = objUsuarioEn.EmailClave
                        Dim nomUsuario As String = objUsuarioEn.nombresCompleto
                        Dim contenido As String = ""
                        Dim notas As String = argumento & "       Gestionado por: " & nomUsuario & "  Fecha:" & Now.Date
                        Dim titulo As String = "Pedido numero " & numero & " del cliente " & nombre_cliente & " ha sido anulado!"
                        objEnvCorreoLN.EnviarCorreo(mailDestino, notas, titulo, "", mailEnvia, mailEnviaPass, False)
                        dtg_no_reflejados.CurrentCell = Nothing
                        For i = 0 To dtg_no_reflejados.RowCount - 1
                            If (dtg_no_reflejados.Item("numero", i).Value = numero) Then

                                dtg_no_reflejados.Rows(i).Visible = False
                                ' dtg_no_reflejados.Rows.RemoveAt(i)
                            End If
                        Next
                        MessageBox.Show("El pedido se elimino en forma correcta!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                Else
                    MessageBox.Show("Se debe ingresar un motivo de anulaciòn!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

            End If
        End If
    End Sub

    Private Sub masInfoMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles masInfoMenuItem3.Click
        Dim nit As Integer
        Dim dtg As DataGridView = dtg_no_reflejados
        nit = dtg("nit", dtg.CurrentCell.RowIndex).Value
        frmPendientes.Show()
        frmPendientes.cargarInfoClient(nit)
        frmPendientes.Activate()
    End Sub

    Private Sub autoMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles autoMenuItem2.Click
        Dim usuario As String = objUsuarioEn.nombre
        Dim dtg As DataGridView = dtg_no_reflejados
        Dim vendedor As Integer = 0
        Dim numeroPed As Integer = 0
        Dim nombre_cliente As String = ""
        Dim anulado As String = 0
        strDtgSeleccion = "no_reflej"
        numeroPed = dtg("numero", dtg.CurrentCell.RowIndex).Value
        vendedor = dtg("vendedor", dtg.CurrentCell.RowIndex).Value
        nombre_cliente = dtg("nombres", dtg.CurrentCell.RowIndex).Value
        If (consularEstadoNR(numeroPed)) Then
            dtg_no_reflejados.Rows.RemoveAt(dtg_no_reflejados.CurrentCell.RowIndex)
            MessageBox.Show("Este pedido fue autorizado o anulado previamente, porfavor actualice la consulta!", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            FrmAutorizar.Show()
            FrmAutorizar.inicializarVar(numeroPed, strDtgSeleccion, vendedor, objUsuarioEn, nombre_cliente)
            FrmAutorizar.Activate()
        End If

    End Sub
    Private Function consularEstadoNR(ByVal numPed As String) As Boolean
        Dim sql As String = "SELECT anulado  FROM  jjv_documentos_ped WHERE numero = " & numPed
        Dim resp As Boolean = 0
        resp = objOp_simpesLn.consultarVal(sql)
        Return resp
    End Function
    Private Sub enviarMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles enviarMenuItem1.Click
        Dim nit As Integer = 0
        Dim dtg As DataGridView = dtg_no_reflejados
        Dim nombre As String
        nit = dtg("nit", dtg.CurrentCell.RowIndex).Value
        nombre = dtg("nombres", dtg.CurrentCell.RowIndex).Value
        FrmDatosMail.Show()
        frmPendientes.Show()
        frmPendientes.cargarInfoClient(nit)
        Application.DoEvents()
        'capturarPantalla()
        FrmDatosMail.capturarPantalla()
        frmPendientes.Close()
        FrmDatosMail.iniciarValores("\informacion.jpg", objUsuarioEn, nombre)
        FrmDatosMail.Activate()
    End Sub

    Private Sub dtg_no_reflejados_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtg_no_reflejados.CellContentClick
        If (e.RowIndex = -1) Then
            pintarPrecioMin_Rnt()
        Else
            sumarValPedNoReflej(dtg_no_reflejados.Item("numero", e.RowIndex).Value)
        End If
    End Sub
    Private Sub VerStockToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VerStockToolStripMenuItem.Click
        Dim dtg As DataGridView = Nothing
        Select Case strDtgSeleccion
            Case "buenos"
                dtg = dtgPenBuenos
            Case "bloq"
                dtg = dtgBloq
            Case "venc"
                dtg = dtgDocVen
            Case "cupo"
                dtg = dtgCupCred
            Case "no_reflej"
                dtg = dtg_no_reflejados
        End Select
        Dim codigo As String = dtg.Item("codigo", dtg.CurrentCell.RowIndex).Value
        MessageBox.Show(objAnalisisLn.consultarStock(codigo) & vbCrLf & "Pendientes = " & objAnalisisLn.consultarCantPend(codigo), "Stock", MessageBoxButtons.OK)
    End Sub
    Private Sub pintarPrecioMin_Rnt()
        For i = 0 To dtg_no_reflejados.RowCount - 1
            If Not IsDBNull(dtg_no_reflejados.Item("p_min", i).Value) Then
                If (dtg_no_reflejados.Item("p_min", i).Value > 0) Then
                    dtg_no_reflejados.Rows(i).DefaultCellStyle.BackColor = Color.LemonChiffon
                End If
            End If
            If Not IsDBNull(dtg_no_reflejados.Item("Rnt", i).Value) Then
                If (dtg_no_reflejados.Item("Rnt", i).Value < 15) Then
                    dtg_no_reflejados.Rows(i).DefaultCellStyle.BackColor = Color.LemonChiffon
                ElseIf (dtg_no_reflejados.Item("Rnt", i).Value > 40) Then
                    dtg_no_reflejados.Rows(i).DefaultCellStyle.BackColor = Color.LemonChiffon
                End If
            End If
        Next

    End Sub

    Private Sub tbl_datos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbl_datos.SelectedIndexChanged
        If tbl_datos.SelectedIndex = 4 Then
            pintarPrecioMin_Rnt()
        End If
    End Sub


    Private Sub dtg_no_reflejados_DoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dtg_no_reflejados.DoubleClick
        strDtgSeleccion = "no_reflej"
        With (Me.dtg_no_reflejados)
            Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
            If Hitest.Type = DataGridViewHitTestType.Cell Then
                .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                menStripNoRelej.Show(e.X, e.Y + 210)
            End If
        End With
    End Sub



    Private Sub tool_exp_buen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tool_exp_buen.Click
        objOpercionesForm.ExportarDatosExcel(dtgPenBuenos, "Pendientes buenos")
    End Sub

    Private Sub tool_exp_bloq_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tool_exp_bloq.Click
        objOpercionesForm.ExportarDatosExcel(dtgBloq, "Pendientes bloqueados")
    End Sub

    Private Sub tool_exp_venc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tool_exp_venc.Click
        objOpercionesForm.ExportarDatosExcel(dtgDocVen, "Con documentos vencidos")
    End Sub

    Private Sub tool_exp_cupo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tool_exp_cupo.Click
        objOpercionesForm.ExportarDatosExcel(dtgCupCred, "Sin cupo de credito")
    End Sub

    Private Sub tool_exp_noRef_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tool_exp_noRef.Click
        objOpercionesForm.ExportarDatosExcel(dtg_no_reflejados, "Pedidos no reflejados")
    End Sub
    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        FrmPrincipal.Show()
        FrmPrincipal.Activate()
        Me.Close()
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        FrmLogin.Show()
        FrmPrincipal.Close()
        FrmLogin.Activate()
        Me.Close()
    End Sub


    Private Sub dtg_no_reflejados_ColumnHeaderMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dtg_no_reflejados.ColumnHeaderMouseClick
        If (e.RowIndex = -1) Then
            pintarPrecioMin_Rnt()
        Else
            sumarValPedNoReflej(dtg_no_reflejados.Item("numero", e.RowIndex).Value)
        End If
    End Sub

    Private Sub CambiarNotaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CambiarNotaToolStripMenuItem.Click
        Dim dtg As DataGridView = Nothing
        Select Case strDtgSeleccion
            Case "buenos"
                dtg = dtgPenBuenos
            Case "bloq"
                dtg = dtgBloq
            Case "venc"
                dtg = dtgDocVen
            Case "cupo"
                dtg = dtgCupCred
            Case "no_reflej"
                dtg = dtg_no_reflejados
        End Select
        Dim nombCol As String = dtg.Columns(dtg.CurrentCell.ColumnIndex).Name
        If (nombCol = "notas_aut" Or nombCol = "notas_prod" Or nombCol = "notas_venta" Or nombCol = "notas" Or nombCol = "nota_vta" Or nombCol = "notasProd") Then
            Dim numeroPed As Double = dtg.Item("Numero", dtg.CurrentCell.RowIndex).Value
            Dim valor As String = ""
            If Not (IsDBNull(dtg.Item(nombCol, dtg.CurrentCell.RowIndex).Value)) Then
                If ((dtg.Item(nombCol, dtg.CurrentCell.RowIndex).Value) <> "") Then
                    valor = dtg.Item(nombCol, dtg.CurrentCell.RowIndex).Value.ToString
                End If
            End If
            Dim sql As String = ""
            valor = InputBox("Modifique la nota, luego presione aceptar", "Modificar", valor)
            If (valor <> "") Then
                Dim nomColDb As String = ""
                Select Case nombCol
                    Case "notas_prod"
                        nomColDb = "notas5"
                    Case "notas_venta"
                        nomColDb = "nota_vta"
                    Case "notas"
                        nomColDb = "notas"
                    Case "notas"
                        nomColDb = "notas"
                    Case "nota_vta"
                        nomColDb = "nota_vta"
                    Case "notasProd"
                        nomColDb = "notas5"
                End Select
                sql = "UPDATE documentos_ped SET " & nomColDb & " =  '" & valor & "' where numero = " & numeroPed
                If (objAnalisisLn.ejecutar(sql) >= 1) Then
                    dtg.Item(nombCol, dtg.CurrentCell.RowIndex).Value = valor
                    MessageBox.Show("Item modificado en forma exitosa!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Erorr al modificar,comuniquese con el administrador del sistema!", "erorr", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If

        Else
            MessageBox.Show("Seleccione un campo de notas a modificar!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btnModPed_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModPed.Click
        Dim dtg As DataGridView = Nothing
        Select Case strDtgSeleccion
            Case "buenos"
                dtg = dtgPenBuenos
            Case "bloq"
                dtg = dtgBloq
            Case "venc"
                dtg = dtgDocVen
            Case "cupo"
                dtg = dtgCupCred
            Case "no_reflej"
                dtg = dtg_no_reflejados
        End Select

        Dim vec(6) As Object
        Dim numero As Double = dtg.Item("Numero", dtg.CurrentCell.RowIndex).Value
        Dim sub_tot As Double = 0
        Dim vr_iva As Double = 0
        Dim vr_tot As Double = 0
        Dim iva As Double = objOp_simpesLn.getIvaPorc()
        FrmIngVtas.Show()
        FrmIngVtas.Main("nod_ing_vtas", objUsuarioEn)
        FrmIngVtas.nuevo()
        FrmIngVtas.Estado_guardar = False
        FrmIngVtas.lblNroPedido.Visible = False
        FrmIngVtas.lblUltimoPedido.Text = numero
        FrmIngVtas.txt_nombres.Text = dtg.Item("nombres", dtg.CurrentCell.RowIndex).Value
        FrmIngVtas.txtNit.Text = dtg.Item("nit", dtg.CurrentCell.RowIndex).Value
        FrmIngVtas.txtRef.Focus()
        FrmIngVtas.cargar_info_client(dtg.Item("nit", dtg.CurrentCell.RowIndex).Value)
        For i = 0 To dtg.RowCount - 1
            If (dtg.Item("Numero", i).Value = numero) Then
                vec(0) = "Borrar"
                vec(1) = dtg.Item("codigo", i).Value
                vec(2) = dtg.Item("descripcion", i).Value
                vec(3) = dtg.Item("Cant_pedida", i).Value
                vec(4) = dtg.Item("valor_unitario", i).Value
                vec(5) = Convert.ToDouble(vec(4) * vec(3))
                FrmIngVtas.dtgPedido.Rows.Add(vec)
                If Not IsDBNull(dtg.Item("notas", i).Value) Then
                    FrmIngVtas.txtNotas.Text = dtg.Item("notas", i).Value
                End If
                If Not IsDBNull(dtg.Item("nota_vta", i).Value) Then
                    FrmIngVtas.txt_notas_opc.Text = dtg.Item("nota_vta", i).Value
                End If
                If Not IsDBNull(dtg.Item("notas_prod", i).Value) Then
                    FrmIngVtas.txtNota5.Text = dtg.Item("notas_prod", i).Value
                End If
                sub_tot += vec(5)
                'FrmIngVtas.cbo_vendedores.SelectedValue = dtg_pend.Item("vendedor", i).Value
                FrmIngVtas.txt_vend.Text = dtg.Item("vendedor", i).Value
                FrmIngVtas.txt_bodega.Text = dtg.Item("bodega", i).Value
            End If
        Next
        vr_iva = sub_tot * iva
        vr_tot = sub_tot + vr_iva
        FrmIngVtas.txtSubtot.Text = Format(sub_tot, "C0")
        FrmIngVtas.txt_vr_iva.Text = Format(vr_iva, "C0")
        FrmIngVtas.txt_tot.Text = Format(vr_tot, "C0")
        FrmIngVtas.numeroActualizar = numero
        Dim dFec As Date = Convert.ToDateTime(dtg.Item("fecha", dtg.CurrentCell.RowIndex).Value)
        FrmIngVtas.fecha_actualizar = Format(dFec, "yyyy-M-d H:mm:ss")
        If Not IsDBNull(dtg.Item("aut", dtg.CurrentCell.RowIndex).Value) Then
            FrmIngVtas.aut_actualizar = dtg.Item("aut", dtg.CurrentCell.RowIndex).Value
        End If
        If Not IsDBNull(dtg.Item("notas_aut", dtg.CurrentCell.RowIndex).Value) Then
            FrmIngVtas.notas_aut_actualizar = dtg.Item("notas_aut", dtg.CurrentCell.RowIndex).Value
        End If
    End Sub

    Private Sub btnAyuda_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAyuda.Click
        Dim proc As New Process
        proc.StartInfo.FileName = Environment.CurrentDirectory & "\manuales\manualAnalisisPed.pdf"
        proc.StartInfo.Verb = "Open"
        proc.Start()
    End Sub

    Private Sub dtg_no_reflejados_DoubleClick(sender As Object, e As EventArgs) Handles dtg_no_reflejados.DoubleClick

    End Sub
    Private Sub AnularPedidoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AnularPedidoToolStripMenuItem.Click
        Dim dtg As DataGridView = Nothing
        Select Case strDtgSeleccion
            Case "buenos"
                dtg = dtgPenBuenos
            Case "bloq"
                dtg = dtgBloq
            Case "venc"
                dtg = dtgDocVen
            Case "cupo"
                dtg = dtgCupCred
            Case "dtg_val_menor"
                dtg = dtg_val_menor
        End Select
        Dim motivo As String = InputBox("ingrese motivo de la anulación del pedido")
        If (motivo <> "") Then
            Dim numero As Double = dtg.Item("Numero", dtg.CurrentCell.RowIndex).Value
            Dim listSql As New List(Of Object)
            Dim sql As String = "UPDATE documentos_ped SET anulado = 1 , notas += '-Anulado: " & motivo & " - " & objUsuarioEn.usuario & " " & Now & " '  WHERE numero = " & numero
            listSql.Add(sql)
            sql = "DELETE FROM documentos_lin_ped WHERE numero = " & numero
            listSql.Add(sql)
            If objOp_simpesLn.ExecuteSqlTransactionTodo(listSql, "CORSAN") Then
                MessageBox.Show("Pedido anulado en forma correcta", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                dtg.CurrentCell = Nothing
                For i = 0 To dtg.RowCount - 1
                    If (dtg.Item("Numero", i).Value = numero) Then
                        dtg.Rows(i).Visible = False
                    End If
                Next
            Else
                MessageBox.Show("El pedido no fue anulado, comuniquese con el area de sistemas", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            MessageBox.Show("Ingrese motivo de anulación del pedido", "Ingrese motivo de anulación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
    Private Sub gestionar_pendietes()
        Dim permiso As String = objUsuarioEn.permiso
        Dim criterioVendedor As String = ""
        Dim min As Integer = txtMin.Text
        Dim max As Integer = txtMax.Text
        criterioVendedor = " Ptes.vendedor>=" & min & " and Ptes.vendedor<=" & max & " "
        If (vendedores <> "") Then
            criterioVendedor &= " AND Ptes.vendedor in(" & vendedores & ") "
        End If
        Dim sql As String = "SELECT  distinct Ptes.nit, Ptes.numero,Ptes.autorizacion As aut,Ptes.fecha,Ptes.Problema,Ptes.codigo,Ptes. descripcion,Ptes.Pendiente,Ptes.KilosPendiente As kilos,ptes.valor_unitario,ptes.bodega,Ptes.Valor_total AS vr_total,Ptes.vendedor,Ptes.ciudad,Ptes.nombres,Ptes.bloqueo,Ptes.condicion AS Credito,Ptes.notas,Ptes.nota_vta,Ptes.nota_prod AS notas_coord,Ptes.notas5 As notas_prod,ptes.notas_aut,Cant_pedida, (SELECT CASE WHEN (SELECT nit FROM  V_Doc_Vencidos where nit = ptes.nit and Dias_Vencido >10 GROUP BY nit) IS NULL THEN 'N' ELSE 'S' END)As doc_venc " &
                                            " FROM V_pendientes_por_vendedor Ptes " & _
                                                    "WHERE " & criterioVendedor & "" & _
                                                            "ORDER BY Ptes.nit,Ptes.numero"
        Dim dt As DataTable = objOp_simpesLn.listar_datatable(sql, "CORSAN")
        Dim dt_buenos As New DataTable
        Dim dt_bloqueados As New DataTable
        'Dim dt_doc_venc As New DataTable
        'Dim dt_cupo As New DataTable
        For j = 0 To dt.Columns.Count - 1
            dt_buenos.Columns.Add(dt.Columns(j).ColumnName, dt.Columns(j).DataType)
            dt_bloqueados.Columns.Add(dt.Columns(j).ColumnName, dt.Columns(j).DataType)
            'dt_doc_venc.Columns.Add(dt.Columns(j).ColumnName, dt.Columns(j).DataType)
            'dt_cupo.Columns.Add(dt.Columns(j).ColumnName, dt.Columns(j).DataType)
        Next
        For i = 0 To dt.Rows.Count - 1
            'If (dt.Rows(i).Item("bloqueo") <> 0) Then
            'dt_bloqueados.ImportRow(dt.Rows(i))
            'Else
            If Not IsDBNull(dt.Rows(i).Item("aut")) Then
                If (dt.Rows(i).Item("aut") = "S" Or dt.Rows(i).Item("aut") = "A") Then
                    dt_buenos.ImportRow(dt.Rows(i))
                    'ElseIf (dt.Rows(i).Item("doc_venc") = "S") Then
                    'dt_doc_venc.ImportRow(dt.Rows(i))
                    'ElseIf Not (verificar_cupo(dt.Rows(i).Item("nit"))) Then
                    'dt_cupo.ImportRow(dt.Rows(i))
                Else
                    dt_bloqueados.ImportRow(dt.Rows(i))
                End If
                'ElseIf (dt.Rows(i).Item("doc_venc") = "S") Then
                ' dt_doc_venc.ImportRow(dt.Rows(i))
                'ElseIf Not (verificar_cupo(dt.Rows(i).Item("nit"))) Then
                ' dt_cupo.ImportRow(dt.Rows(i))
            Else
                dt_buenos.ImportRow(dt.Rows(i))
            End If
            'End If
        Next
        dtgPenBuenos.DataSource = dt_buenos
        dtgBloq.DataSource = dt_bloqueados
        'dtgDocVen.DataSource = dt_doc_venc
        'dtgCupCred.DataSource = dt_cupo
        dtg_no_reflejados.DataSource = objAnalisisLn.listar_No_Reflej(permiso)
        listar_valor_menor(vendedores)
        formato()
    End Sub
    Private Sub formartoDtg(ByRef dtg As DataGridView)

    End Sub
    Private Function verificar_cupo(ByVal nit As Double) As Boolean
        Dim sql_cartera As String = "SELECT (SUM (saldo)) As cupo_menos_cartera " & _
                                "FROM V_cartera_edades_jjv " & _
                                 "WHERE nit = " & nit & " "
        Dim cartera As String = objOp_simpesLn.consultarVal(sql_cartera)
        Dim sql_cupo As String = "SELECT cupo_credito " & _
                              "FROM terceros " & _
                               "WHERE nit = " & nit & " "
        Dim cupo As String = objOp_simpesLn.consultarVal(sql_cupo)

        Dim int_cartera As Double = 0
        Dim int_vr_pendientes As Double = objAnalisisLn.vr_total_pend(nit, iva)
        Dim int_cupo As Double = 0
        If IsNumeric(cartera) Then
            int_cartera = cartera
        End If
        If IsNumeric(cupo) Then
            int_cupo = cupo
        End If
        Dim total As Double = int_cupo - int_cartera - int_vr_pendientes
        If total >= 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    Private Sub formato()
        dtg_no_reflejados.Columns("bodega").HeaderText = "Bod"
        dtg_no_reflejados.Columns("autorizacion").HeaderText = "Aut"
        dtg_no_reflejados.Columns("fecha").DefaultCellStyle.Format = "d"
        dtgPenBuenos.Columns("fecha").DefaultCellStyle.Format = "d"
        dtgBloq.Columns("fecha").DefaultCellStyle.Format = "d"
        ' dtgDocVen.Columns("fecha").DefaultCellStyle.Format = "d"
        '  dtgCupCred.Columns("fecha").DefaultCellStyle.Format = "d"
        txtTotKilosBueno.Text = Format(sumarColumnas("kilos", dtgPenBuenos), "###,###,###")
        txtBueVal.Text = Format(sumarColumnas("vr_total", dtgPenBuenos), "###,###,###")
        txtKilBloq.Text = Format(sumarColumnas("kilos", dtgBloq), "###,###,###")
        txtValBloq.Text = Format(sumarColumnas("vr_total", dtgBloq), "###,###,###")
        'txtKilDoc.Text = Format(sumarColumnas("kilos", dtgDocVen), "###,###,###")
        ' txtValDoc.Text = Format(sumarColumnas("vr_total", dtgDocVen), "###,###,###")
        'txtKilCupo.Text = Format(sumarColumnas("kilos", dtgCupCred), "###,###,###")
        'txtValCupo.Text = Format(sumarColumnas("vr_total", dtgCupCred), "###,###,###")
        txt_val_no_reflej.Text = Format(objAnalisisLn.sum_no_reflej(txtMin.Text, txtMax.Text, iva), "###,###,###")
        If (txtKilBloq.Text = "" And txtValBloq.Text = "") Then
            txtKilBloq.Text = 0
            txtValBloq.Text = 0
        End If
        'If (txtValCupo.Text = "" And txtKilCupo.Text = "") Then
        '    txtKilCupo.Text = 0
        '    txtValCupo.Text = 0
        'End If
        If (txtBueVal.Text = "") Then
            txtBueVal.Text = 0
            txtTotKilosBueno.Text = 0
        End If
        'If (txtKilDoc.Text = "") Then
        '    txtKilDoc.Text = 0
        '    txtValDoc.Text = 0
        'End If
        If (txt_val_no_reflej.Text = "") Then
            txt_val_no_reflej.Text = "0"
        End If
        txtTotKilo.Text = Format(Convert.ToDouble(txtKilBloq.Text) + Convert.ToDouble(txtTotKilosBueno.Text))
        txtTotVal.Text = Format(Convert.ToDouble(txtValBloq.Text) + Convert.ToDouble(txtBueVal.Text) + txt_val_no_reflej.Text, "C0")

        ' + Convert.ToDouble(txtKilCupo.Text) + Convert.ToDouble(txtTotKilosBueno.Text) + Convert.ToDouble(txtKilDoc.Text), "###,###,###")
        ' + Convert.ToDouble(txtValCupo.Text) + Convert.ToDouble(txtValDoc.Text) + Convert.ToDouble(txtBueVal.Text) + txt_val_no_reflej.Text, "C0")
    End Sub
End Class