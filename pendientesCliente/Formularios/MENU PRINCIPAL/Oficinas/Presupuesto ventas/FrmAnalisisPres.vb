Imports System.Configuration
Imports logicaNegocios
Imports System.IO
Imports Microsoft.Office.Interop
Imports System.Windows.Forms.DataVisualization.Charting
Public Class FrmAnalisisPres
    Private objAnalisisPresLn As AnalisisPresLn
    Private objGenerarPresLn As GenerarPresLn
    Private objOperacionesForm As OperacionesFormularios = New OperacionesFormularios
    Public mes As String
    Public año As String
    Public vendDatosGrid As String
    Private nom_modulo As String = ""
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
    Private Sub FrmAnalisisPres_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        objAnalisisPresLn = New AnalisisPresLn
        objGenerarPresLn = New GenerarPresLn
        ChkPesosVend.Checked = True
        Dim vecVend As String() = objAnalisisPresLn.cargarVendedores()
        Dim valor As String
        For i = 0 To vecVend.Length - 1
            If (vecVend(i) <> "") Then
                valor = vecVend(i)
                cboVend.Items.Add(valor)
            End If
        Next
        cboVend.Text = "Seleccione"
        btnGuardar.Enabled = False
        btnCerrarPres.Enabled = False
        imgProcesar.Visible = False

    End Sub
    Public Sub cargarPres(ByVal nit, ByVal criterio)
        dtgAnalisisPres.DataSource = objGenerarPresLn.listarGenerarPres(nit, criterio)
        PintarColums()
        nombreColumnasPres(dtgAnalisisPres)
    End Sub
    Public Sub nombreColumnasPres(ByVal dtg As DataGridView)
        Dim mes As Double = Now.Month
        Dim año As Double = Now.Year
        Dim nombreMes As String = ""
        For i = 16 To dtgAnalisisPres.ColumnCount - 1
            If mes = 0 Then
                mes = 12
                año = año - 1
            End If
            nombreMes = MonthName(mes, True)
            If (dtg.Columns(i).HeaderText <> "Total" And dtg.Columns(i).HeaderText <> "Promedio") Then
                dtg.Columns(i).HeaderText = (nombreMes & " " & año)
                mes = mes - 1
            End If
           
        Next
    End Sub
    Private Sub dtgAnalisisPres_CellFormatting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dtgAnalisisPres.CellFormatting
        Dim var As Integer = 0
        If (dtgAnalisisPres.RowCount Mod 2 = 1) Then
            var = 1
        End If
        If e.RowIndex Mod 2 = var Then
            e.CellStyle.BackColor = Color.Gainsboro
        End If
    End Sub
    Private Sub PintarColums()
        For i = 0 To dtgAnalisisPres.ColumnCount - 1
            Me.dtgAnalisisPres.Item(i, 27).Style.BackColor = System.Drawing.Color.Red
        Next
    End Sub

    Private Sub PrincipalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrincipalToolStripMenuItem.Click
        FrmPrincipal.Show()
        Me.Close()
        FrmPrincipal.Activate()
    End Sub

    Private Sub SalirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalirToolStripMenuItem.Click
        FrmLogin.Show()
        FrmPrincipal.Close()
        Me.Close()
    End Sub

    Private Sub ExportarAExcelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportarAExcelToolStripMenuItem.Click
        objOperacionesForm.ExportarDatosExcel(dtgAnalisisPres, "Analisis presupuesto " & "Vendedor = " & lblNomVend.Text)
    End Sub

    Private Sub btnBuscarVend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarVend.Click
        Dim criterio As String
        Dim nit As String = cboVend.Text
        If (nit = "Seleccione") Then
            MessageBox.Show("Seleccione un vendedor", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            If (chkKilVend.Checked = True) Then
                criterio = "kilos"
            Else
                criterio = "Vr_total"
            End If
            imgProcesar.Visible = True
            dtgAnalisisPres.Visible = True
            Application.DoEvents()
            If (nit = "Todos") Then
                llenarGridPresTodos(1001, 1099, criterio)
                lblNomVend.Text = "Todos"
                costos_prom(1001, 1099)
            ElseIf (nit = "Nacionales") Then
                llenarGridPresTodos(1001, 1095, criterio)
                lblNomVend.Text = "Nacionales"
                costos_prom(1001, 1095)
            End If
            If (nit <> "Seleccione" And nit <> "Nacionales" And nit <> "Todos") Then
                cargarPres(nit, criterio)
                lblNomVend.Text = objGenerarPresLn.nombreVendedor(cboVend.Text)
                vendDatosGrid = nit
                costos_prom(nit, nit)
            End If

            dtgAnalisisPres.Columns(0).Frozen = True
            btnConsultarPres.Visible = True
            btnGenPres.Visible = True
            dtgAnalisisPres.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            dtgAnalisisPres.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
            imgProcesar.Visible = False
            dtgAnalisisPres.Columns(1).Visible = False
            dtgAnalisisPres.Columns(2).Visible = False
            dtgAnalisisPres.Columns(3).Visible = False
            dtgAnalisisPres.Columns(4).Visible = False
            dtgAnalisisPres.Columns(5).Visible = False
            dtgAnalisisPres.Columns(6).Visible = False
            dtgAnalisisPres.Columns(7).Visible = False
            dtgAnalisisPres.Columns(8).Visible = False
            dtgAnalisisPres.Columns(9).Visible = False
            dtgAnalisisPres.Columns(10).Visible = False
            dtgAnalisisPres.Columns(11).Visible = False
            dtgAnalisisPres.Columns(12).Visible = False
            dtgAnalisisPres.Columns(13).Visible = False
            dtgAnalisisPres.Columns(14).Visible = False
            dtgAnalisisPres.Columns(15).Visible = False
            sumFilasAnPres()
            sumarTotPres()
        End If
    End Sub

    Public Sub costos_prom(ByVal vend_min As Integer, ByVal vend_max As Integer)
        Dim fecIni As String = DateAdd("m", -12, Now.Year & "-" & Now.Month & "-01")
        Dim fecFin As String = Now.Year & "-" & Now.Month & "-01"
        Dim cto_tot As Double = objGenerarPresLn.sumar("Select SUM (Cto_total )  from Jjv_V_vtas_vend_cliente_ref where vendedor> = " & vend_min & " and vendedor <=" & vend_max & "and fec >='" & fecIni & "' and fec <'" & fecFin & "'")
        Dim kilos As Double = objGenerarPresLn.sumar("Select SUM (KILOS )  from Jjv_V_vtas_vend_cliente_ref where vendedor> = " & vend_min & " and vendedor <=" & vend_max & "and fec >='" & fecIni & "' and fec <'" & fecFin & "'")
        Dim vr_tot As Double = objGenerarPresLn.sumar("Select SUM (Vr_total )  from Jjv_V_vtas_vend_cliente_ref where vendedor> = " & vend_min & " and vendedor <=" & vend_max & "and fec >='" & fecIni & "' and fec <'" & fecFin & "'")
        Dim cto_kilo As Double = 0
        txt_ctoTot_Kilos.Text = Format((cto_tot / kilos), "###,###,###")
        txt_ctokil_vrKil.Text = Format((vr_tot / kilos), "###,###,###")
    End Sub

    Private Sub btnGenPres_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenPres.Click
        FrmOpcionesPres.Show()
    End Sub


    Public Sub agregarPres(ByVal vendedor As String, ByVal cantMeses As Double, ByVal año As Double, ByVal mes As String, ByVal mesNumero As Integer, ByVal criterio As String)
        Dim vendMin As Integer
        Dim vendMax As Integer
        Dim cien As Double = 0
        Dim uni As Double = 0

        vendDatosGrid = vendedor
        lblNomVend.Text = vendedor
        cboVend.Text = vendedor
        btnBuscarVend.PerformClick()
        imgProcesar.Visible = True
        Application.DoEvents()
        If (vendedor = "Todos") Then
            vendMin = 1001
            vendMax = 1099
            objGenerarPresLn.GenerarPresupuestoTodos(vendMin, vendMax, año & "-" & mesNumero & "-01", cantMeses)
        ElseIf (vendedor = "Nacionales") Then
            vendMin = 1001
            vendMax = 1095
            objGenerarPresLn.GenerarPresupuestoTodos(vendMin, vendMax, año & "-" & mesNumero & "-01", cantMeses)

        End If
        If (vendedor <> "Seleccione" And vendedor <> "Nacionales" And vendedor <> "Todos") Then
            Dim nit As Double = Convert.ToDouble(vendedor)
            vendMin = nit
            vendMax = nit
        End If
        Dim vecPresKil() As Double = objGenerarPresLn.promPresTodos(vendMin, vendMax, "kilos", cantMeses)
        Dim vecPresVrTot() As Double = objGenerarPresLn.promPresTodos(vendMin, vendMax, "Vr_total", cantMeses)
        Dim vecCto_total() As Double = objGenerarPresLn.promPresTodos(vendMin, vendMax, "Cto_total", cantMeses)
        Dim diasHabil As Integer = objGenerarPresLn.consultDiasHabil(año, mesNumero)
        Dim MatPresTodos(26, 2) As Object
        MatPresTodos = objGenerarPresLn.consulPttoTodos(año & "-" & mesNumero & "-01")
        Dim vecStock As Double()
        vecStock = objGenerarPresLn.consultStock
        For i = 0 To 26
            For j = 0 To 1
                dtgAnalisisPres.Item(4, i).Value = vecStock(i)
                dtgAnalisisPres.Item(j + 2, i).Value = MatPresTodos(i, j)
            Next
        Next
        For i = 1 To 27
            dtgAnalisisPres.Item(1, i - 1).Value = año & "-" & mesNumero & "- 01"
            dtgAnalisisPres.Item(5, i - 1).Value = vecPresKil(i)
            dtgAnalisisPres.Item(6, i - 1).Value = vecPresVrTot(i)
            dtgAnalisisPres.Item(7, i - 1).Value = vecCto_total(i)
            If (dtgAnalisisPres.Item(6, i - 1).Value <> 0 And dtgAnalisisPres.Item(5, i - 1).Value <> 0) Then
                dtgAnalisisPres.Item(8, i - 1).Value = (dtgAnalisisPres.Item(6, i - 1).Value / dtgAnalisisPres.Item(5, i - 1).Value)
            End If
            If (dtgAnalisisPres.Item(7, i - 1).Value <> 0 And dtgAnalisisPres.Item(5, i - 1).Value <> 0) Then
                dtgAnalisisPres.Item(9, i - 1).Value = (dtgAnalisisPres.Item(7, i - 1).Value / dtgAnalisisPres.Item(5, i - 1).Value)
            End If
            If (dtgAnalisisPres.Item(8, i - 1).Value <> 0 And dtgAnalisisPres.Item(9, i - 1).Value <> 0) Then
                dtgAnalisisPres.Item(10, i - 1).Value = ((dtgAnalisisPres.Item(8, i - 1).Value - (dtgAnalisisPres.Item(9, i - 1).Value)) / (dtgAnalisisPres.Item(8, i - 1).Value) * 100)
            End If
            dtgAnalisisPres.Item(11, i - 1).Value = Now.Date
            dtgAnalisisPres.Item(12, i - 1).Value = diasHabil

        Next
        'MessageBox.Show("Presupuesto para los vendedores " & vendMin & " Hasta " & vendMax & " Se genero de forma correcta! ", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)

        imgProcesar.Visible = False
        btnGuardar.Enabled = True
        btnCerrarPres.Enabled = True
        ' dtgAnalisisPres.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        Me.dtgAnalisisPres.Columns("Vr_total").DefaultCellStyle.Format = "c0"
        Me.dtgAnalisisPres.Columns("Cto_total").DefaultCellStyle.Format = "c0"
        Me.dtgAnalisisPres.Columns("Vr_kilo").DefaultCellStyle.Format = "c0"
        Me.dtgAnalisisPres.Columns("Cto_kilo").DefaultCellStyle.Format = "c0"
        Me.dtgAnalisisPres.Columns("Ppto_Kilos").DefaultCellStyle.Format = "##,##0"
        Me.dtgAnalisisPres.Columns(10).DefaultCellStyle.Format = "##,##0.#"
        Me.dtgAnalisisPres.Columns(13).DefaultCellStyle.Format = "##,##0.#"
        Me.dtgAnalisisPres.Columns(14).DefaultCellStyle.Format = "##,##0.#"
        dtgAnalisisPres.Columns(15).DefaultCellStyle.Format = "##,##0.#"

        dtgAnalisisPres.Columns(1).Visible = True
        dtgAnalisisPres.Columns(2).Visible = True
        dtgAnalisisPres.Columns(3).Visible = True
        dtgAnalisisPres.Columns(4).Visible = True
        dtgAnalisisPres.Columns(5).Visible = True
        dtgAnalisisPres.Columns(6).Visible = True
        dtgAnalisisPres.Columns(7).Visible = True
        dtgAnalisisPres.Columns(8).Visible = True
        dtgAnalisisPres.Columns(9).Visible = True
        dtgAnalisisPres.Columns(10).Visible = True
        dtgAnalisisPres.Columns(11).Visible = True
        dtgAnalisisPres.Columns(12).Visible = True
        dtgAnalisisPres.Columns(13).Visible = True
        dtgAnalisisPres.Columns(14).Visible = True
        dtgAnalisisPres.Columns(15).Visible = True
        'dtgAnalisisPres.Columns("Total").Visible = False
        'dtgAnalisisPres.Columns("Promedio").Visible = False
        dtgAnalisisPres.Columns(10).HeaderText = ("%_Util")
        dtgAnalisisPres.Columns(12).HeaderText = ("D_Hab")

        sumarTotPres()
        calcularProcVta()
        calculaPorcVtaGral(cantMeses)
        If (vendedor = "Todos" Or vendedor = "Nacionales") Then
            dtgAnalisisPres.Columns(15).Visible = False
            'btnGuardar.PerformClick()
            vendedor = 10011099
        End If
        calculaPorcCumplimiento(criterio)
        Dim a As Double = (dtgAnalisisPres.Item("Total", dtgAnalisisPres.RowCount - 1).Value / dtgAnalisisPres.Item("Vr_kilo", dtgAnalisisPres.RowCount - 1).Value)
        cargarPptoGral()
        formatoPres()
        txt_ctoTot_Kilos.Text = Format(a, "###,###,###")
    End Sub
    Private Sub dtgAnalisisPres_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgAnalisisPres.CellDoubleClick
        Dim Valor As String
        Dim resp As String = ""
        Dim fecha As Date
        Dim resta As Integer = 0
        Dim vendMin As Integer
        Dim venMax As Integer
        Dim fec As String
        Dim diferencia As Double = 0
        fec = dtgAnalisisPres.Item("Fecha", 1).Value
        If (objGenerarPresLn.consultarCerrado(fec)) Then
            MessageBox.Show("El presupuesto para la fecha " & fec & " esta cerrrado por lo tanto no puede ser modificado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            If (e.ColumnIndex >= 16 And e.RowIndex > -1) Then
                resta = e.ColumnIndex - 16
                fecha = DateAdd("m", -resta, Now.Year & "-" & Now.Month & "-01")
                FrmDetalleVtaMes.Show()
                FrmDetalleVtaMes.cargarGrid(objAnalisisPresLn.cargarConsultaVtasMes(vendMin, venMax, fecha.Month, fecha.Year, e.RowIndex + 1))
            End If

            If (e.RowIndex = -1 Or e.RowIndex = dtgAnalisisPres.RowCount - 1) Then
            Else

                Select Case e.ColumnIndex
                    Case 5
                        If dtgAnalisisPres(5, e.RowIndex).Value <> 0 Then
                            Valor = CInt(dtgAnalisisPres(5, e.RowIndex).Value)
                            resp = InputBox("Ingrese nuevo valor:", "Modificar presupuesto", Valor)
                            If (resp <> "") Then

                                dtgAnalisisPres.Item(6, e.RowIndex).Value = dtgAnalisisPres.Item(8, e.RowIndex).Value * resp
                                dtgAnalisisPres.Item(7, e.RowIndex).Value = dtgAnalisisPres.Item(9, e.RowIndex).Value * resp
                                dtgAnalisisPres.Item(8, e.RowIndex).Value = dtgAnalisisPres.Item(6, e.RowIndex).Value / dtgAnalisisPres.Item(5, e.RowIndex).Value
                                dtgAnalisisPres.Item(9, e.RowIndex).Value = dtgAnalisisPres.Item(7, e.RowIndex).Value / resp
                                dtgAnalisisPres.Item(5, e.RowIndex).Selected = False
                                calcularProcVta()
                                'Para mover al mismo tiempo el presupuesto gereral en uin grid no visible
                                diferencia = dtgAnalisisPres.Item(5, e.RowIndex).Value - resp
                                dtgPptoGeneral.Item(5, e.RowIndex).Value = dtgPptoGeneral.Item(5, e.RowIndex).Value - diferencia
                                dtgPptoGeneral.Item(6, e.RowIndex).Value = dtgPptoGeneral.Item(8, e.RowIndex).Value * dtgPptoGeneral.Item(5, e.RowIndex).Value
                                dtgPptoGeneral.Item(7, e.RowIndex).Value = dtgPptoGeneral.Item(9, e.RowIndex).Value * dtgPptoGeneral.Item(5, e.RowIndex).Value
                                dtgPptoGeneral.Item(8, e.RowIndex).Value = dtgPptoGeneral.Item(6, e.RowIndex).Value / dtgPptoGeneral.Item(5, e.RowIndex).Value
                                dtgPptoGeneral.Item(9, e.RowIndex).Value = dtgPptoGeneral.Item(7, e.RowIndex).Value / dtgPptoGeneral.Item(5, e.RowIndex).Value
                                dtgAnalisisPres.Item(2, e.RowIndex).Value = dtgPptoGeneral.Item(5, e.RowIndex).Value
                                dtgAnalisisPres.Item(3, e.RowIndex).Value = dtgPptoGeneral.Item(6, e.RowIndex).Value
                                dtgAnalisisPres.Item(5, e.RowIndex).Value = resp
                            End If
                        End If
                    Case 8
                        If dtgAnalisisPres(8, e.RowIndex).Value <> 0 Then
                            Valor = CInt(dtgAnalisisPres(8, e.RowIndex).Value)
                            resp = InputBox("Ingrese nuevo valor:", "Modificar presupuesto", Valor)
                            If (resp <> "") Then

                                dtgAnalisisPres.Item(10, e.RowIndex).Value = (resp - (dtgAnalisisPres.Item(9, e.RowIndex).Value)) / resp * 100
                                dtgAnalisisPres.Item(6, e.RowIndex).Value = resp * dtgAnalisisPres.Item(5, e.RowIndex).Value
                                dtgAnalisisPres.Item(10, e.RowIndex).Selected = False
                                calcularProcVta()

                                'Para mover al mismo tiempo el presupuesto gereral en uin grid no visible
                                diferencia = dtgAnalisisPres.Item(8, e.RowIndex).Value - resp
                                dtgPptoGeneral.Item(8, e.RowIndex).Value = dtgPptoGeneral.Item(8, e.RowIndex).Value - diferencia
                                dtgPptoGeneral.Item(10, e.RowIndex).Value = (resp - (dtgPptoGeneral.Item(9, e.RowIndex).Value)) / dtgPptoGeneral.Item(8, e.RowIndex).Value * 100
                                dtgPptoGeneral.Item(6, e.RowIndex).Value = resp * dtgPptoGeneral.Item(5, e.RowIndex).Value

                                dtgAnalisisPres.Item(2, e.RowIndex).Value = dtgPptoGeneral.Item(5, e.RowIndex).Value
                                dtgAnalisisPres.Item(3, e.RowIndex).Value = dtgPptoGeneral.Item(6, e.RowIndex).Value
                                dtgAnalisisPres(8, e.RowIndex).Value = resp
                            End If
                        End If
                    Case 10
                        If dtgAnalisisPres(10, e.RowIndex).Value <> 0 Then
                            Valor = CInt(dtgAnalisisPres(10, e.RowIndex).Value)
                            resp = InputBox("Ingrese nuevo valor:", "Modificar presupuesto", Valor)
                            If (resp <> "") Then
                                dtgAnalisisPres.Item(8, e.RowIndex).Value = (resp * dtgAnalisisPres.Item(8, e.RowIndex).Value) / dtgAnalisisPres(10, e.RowIndex).Value
                                dtgAnalisisPres.Item(6, e.RowIndex).Value = dtgAnalisisPres.Item(5, e.RowIndex).Value * dtgAnalisisPres.Item(8, e.RowIndex).Value
                                dtgAnalisisPres.Item(7, e.RowIndex).Value = dtgAnalisisPres.Item(9, e.RowIndex).Value * dtgAnalisisPres.Item(5, e.RowIndex).Value
                                dtgAnalisisPres(10, e.RowIndex).Selected = False
                                calcularProcVta()
                                'Para mover al mismo tiempo el presupuesto gereral en uin grid no visible
                                diferencia = dtgAnalisisPres.Item(8, e.RowIndex).Value - resp
                                dtgPptoGeneral.Item(8, e.RowIndex).Value = dtgPptoGeneral.Item(5, e.RowIndex).Value - diferencia
                                dtgPptoGeneral.Item(8, e.RowIndex).Value = (dtgPptoGeneral.Item(10, e.RowIndex).Value * dtgPptoGeneral.Item(8, e.RowIndex).Value) / dtgPptoGeneral(10, e.RowIndex).Value
                                dtgPptoGeneral.Item(6, e.RowIndex).Value = dtgPptoGeneral.Item(5, e.RowIndex).Value * dtgPptoGeneral.Item(8, e.RowIndex).Value
                                dtgPptoGeneral.Item(7, e.RowIndex).Value = dtgPptoGeneral.Item(9, e.RowIndex).Value * dtgPptoGeneral.Item(5, e.RowIndex).Value


                                dtgAnalisisPres.Item(2, e.RowIndex).Value = dtgPptoGeneral.Item(5, e.RowIndex).Value
                                dtgAnalisisPres.Item(3, e.RowIndex).Value = dtgPptoGeneral.Item(6, e.RowIndex).Value
                                dtgAnalisisPres(10, e.RowIndex).Value = resp
                            End If
                        End If
                    Case 12
                        If dtgAnalisisPres(12, e.RowIndex).Value <> 0 Then
                            Valor = CInt(dtgAnalisisPres(12, e.RowIndex).Value)
                            resp = InputBox("Ingrese nuevo valor:", "Modificar presupuesto", Valor)
                            If (resp <> "") Then
                                For i = 1 To 27
                                    dtgAnalisisPres(12, i - 1).Value = resp
                                    calcularProcVta()
                                Next
                            End If
                        End If
                End Select
            End If
            sumarTotPres()
            resp = ""
        End If
    End Sub
    Public Sub ingresarModPres(ByVal val As Double, ByVal columna As Integer, ByVal fila As Integer)
        For i = 1 To 27
            For j = 1 To 27
                If (i - 1 = fila) And j = columna Then
                    dtgAnalisisPres.Item(j - 1, i - 1).Value = Now.Date
                End If
            Next
        Next
    End Sub
    Private Sub btnGuardar_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Dim nit As String = vendDatosGrid
        If (nit = "Todos") Then
            nit = 10011099
        ElseIf (nit = "Nacionales") Then
            nit = 10011090
        End If
        If (nit = 10011099) Then
            guardarPpto(dtgPptoGeneral, 10011099)
        Else
            guardarPpto(dtgAnalisisPres, nit)
            guardarPpto(dtgPptoGeneral, 10011099)
        End If

    End Sub
    Private Sub btnConsultarPres_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultarPres.Click
        FrmConsultarPptoRec.Show()
    End Sub
    Public Sub ConsultarPres(ByVal fecha As String, ByVal vendedor As Integer, ByVal criterio As String)
        lblNomVend.Text = objGenerarPresLn.nombreVendedor(vendedor)
        cboVend.Text = vendedor
        Dim MatPres(27, 8) As Object
        Dim MatPresTodos(27, 2) As Object
        MatPresTodos = objGenerarPresLn.consulPttoTodos(fecha)
        Dim vecStock As Double()
        vecStock = objGenerarPresLn.consultStock

        MatPres = objGenerarPresLn.consultarPres(fecha, vendedor)
        'Para verificar que no hayan presupeusto repetidos para el mismo vend-prod-fecha

        If (MatPres(0, 0) = -1) Then

        Else
            btnBuscarVend.PerformClick()
            For i = 0 To 27
                dtgAnalisisPres.Item(1, i).Value = MatPres(i, 1)
                For j = 2 To 9
                    dtgAnalisisPres.Item(j + 3, i).Value = MatPres(i, j)

                Next

            Next
            For i = 0 To 26
                For j = 0 To 1
                    dtgAnalisisPres.Item(4, i).Value = vecStock(i)
                    dtgAnalisisPres.Item(j + 2, i).Value = MatPresTodos(i, j)
                Next
            Next
            Me.dtgAnalisisPres.Columns("Vr_total").DefaultCellStyle.Format = "c0"
            Me.dtgAnalisisPres.Columns("Vr_kilo").DefaultCellStyle.Format = "c0"
            Me.dtgAnalisisPres.Columns("Cto_kilo").DefaultCellStyle.Format = "c0"
            Me.dtgAnalisisPres.Columns(14).DefaultCellStyle.Format = "##,##0.#"
            dtgAnalisisPres.Columns(15).DefaultCellStyle.Format = "##,##0.#"

            dtgAnalisisPres.Columns(1).Visible = True
            dtgAnalisisPres.Columns(2).Visible = True
            dtgAnalisisPres.Columns(3).Visible = True
            dtgAnalisisPres.Columns(4).Visible = True
            dtgAnalisisPres.Columns(5).Visible = True
            dtgAnalisisPres.Columns(6).Visible = True
            dtgAnalisisPres.Columns(7).Visible = True
            dtgAnalisisPres.Columns(8).Visible = True
            dtgAnalisisPres.Columns(9).Visible = True
            dtgAnalisisPres.Columns(10).Visible = True
            dtgAnalisisPres.Columns(11).Visible = True
            dtgAnalisisPres.Columns(12).Visible = True
            dtgAnalisisPres.Columns(13).Visible = True
            dtgAnalisisPres.Columns(14).Visible = True
            dtgAnalisisPres.Columns(15).Visible = True

            btnGuardar.Enabled = True
            btnCerrarPres.Enabled = True
            sumarTotPres()
            calcularProcVta()
            calculaPorcVtaGral(3)
            calculaPorcCumplimiento(criterio)
            dtgAnalisisPres.Columns(10).HeaderText = ("%_Util")
            dtgAnalisisPres.Columns(12).HeaderText = ("D_Hab")
            cargarPptoGral()
            formatoPres()
        End If
    End Sub
    Public Sub sumarTotPres()
        Dim suma As Double = 0
        Dim sumaProm As Double = 0
        Dim cont As Integer = 0
        For j = 2 To dtgAnalisisPres.ColumnCount - 1
            If (j <> 12 And j <> 11 And j <> 10) Then
                For i = 1 To 27
                    suma = suma + dtgAnalisisPres.Item(j, i - 1).Value
                Next

                dtgAnalisisPres.Item(j, 27).Value = suma
                suma = 0
            End If
        Next
        For i = 0 To 26
            If dtgAnalisisPres.Item(10, i).Value <> 0 Then
                sumaProm = sumaProm + dtgAnalisisPres.Item(10, i).Value
                cont += 1
            End If
        Next
        dtgAnalisisPres.Item(10, 27).Value = sumaProm / cont
        dtgAnalisisPres.Item(1, 27).Value = dtgAnalisisPres.Item(1, 26).Value
        dtgAnalisisPres.Item(11, 27).Value = dtgAnalisisPres.Item(11, 26).Value
        dtgAnalisisPres.Item(12, 27).Value = dtgAnalisisPres.Item(12, 26).Value

    End Sub
    Public Sub sumarTotAnalisis(ByVal dtg As DataGridView)
        Dim suma As Double = 0
        For j = 1 To dtg.ColumnCount - 1

            For i = 1 To 27
                suma = suma + dtg.Item(j, i - 1).Value
            Next
            dtg.Item(j, 27).Value = suma
            suma = 0
        Next
        dtg.Rows(dtg.RowCount - 1).DefaultCellStyle.BackColor = Color.Red
    End Sub
    Private Sub ChkPesosVend_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkPesosVend.CheckedChanged
        If ChkPesosVend.Checked = True Then
            chkKilVend.Checked = False
        End If
    End Sub
    Private Sub chkKilVend_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkKilVend.CheckedChanged
        If chkKilVend.Checked = True Then
            ChkPesosVend.Checked = False
        End If
    End Sub
    Private Sub calcularProcVta()
        Dim cien As Double = 0
        Dim uni As Double = 0
        For i = 0 To dtgAnalisisPres.RowCount - 1
            For j = 0 To dtgAnalisisPres.ColumnCount - 1

                cien = dtgAnalisisPres(6, 27).Value
                uni = dtgAnalisisPres(6, i).Value
                dtgAnalisisPres(13, i).Value = (100 * uni) / cien
            Next
        Next
        dtgAnalisisPres(13, 27).Value = 100
        dtgAnalisisPres.Columns(13).HeaderText = ("%_Part")
    End Sub
    Private Sub calculaPorcVtaGral(ByVal cantMeses As Integer)
        '   Dim vecValTotTodosIdcor() As Double = objGenerarPresLn.valTotTodosIdCor(cantMeses)
        Dim cien As Double = 0
        Dim uni As Double = 0
        For i = 0 To dtgAnalisisPres.RowCount - 2
            cien = dtgAnalisisPres(2, i).Value
            If (cien > 0) Then
                uni = dtgAnalisisPres(5, i).Value
                dtgAnalisisPres(14, i).Value = (100 * uni) / cien
            End If
        Next
        dtgAnalisisPres.Columns(14).HeaderText = ("%_Gral")
    End Sub
    Private Sub calculaPorcCumplimiento(ByVal criterio As String)
        Dim columna As Integer = 5
        dtgAnalisisPres.Columns(15).Visible = True

        If (criterio = "Vr_total") Then
            columna = 6
        End If
        Dim cien As Double = 0
        Dim uni As Double = 0
        For i = 0 To dtgAnalisisPres.RowCount - 2
            cien = dtgAnalisisPres(columna, i).Value
            uni = dtgAnalisisPres(16, i).Value
            If (cien > 0) Then
                dtgAnalisisPres(15, i).Value = (100 * uni) / cien
            End If
        Next
        dtgAnalisisPres.Columns(15).HeaderText = ("%_Cumpl")
    End Sub
    Public Sub llenarGridPresTodos(ByVal min, ByVal max, ByVal criterio)
        dtgAnalisisPres.DataSource = objGenerarPresLn.listarGenerarPresTodos(min, max, criterio)
        PintarColums()
        nombreColumnasPres(dtgAnalisisPres)
    End Sub

    Private Sub btnCerrarPres_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrarPres.Click
        Dim iResponce = MessageBox.Show("Tenga en cuenta que al cerrar el presupuesto no lo podra volver a modificarlo, Esta seguro de cerrar el presupuesto? ", "Atención", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
        If (iResponce = 6) Then
            cerrarPres()
        End If
    End Sub

    Public Sub cerrarPres()
        Dim fec As String
        fec = dtgAnalisisPres.Item("Fecha", 1).Value
        objGenerarPresLn.cerrarPres(fec)
        MessageBox.Show("El Presupuesto para la fecha " & fec & " Se cerro en forma correcta!", "Exito!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    End Sub
    Private Sub cargarPptoGral()
        Dim fec As String = dtgAnalisisPres.Item("Fecha", 1).Value
        dtgPptoGeneral.DataSource = objGenerarPresLn.listarPresGeneral(fec)
    End Sub
    Private Sub guardarPpto(ByVal dtg As DataGridView, ByVal nit As Integer)
        Dim fechaPpto As String = año & "-" & mes & "-01"
        Dim vendedor As Double
        Dim id_cor As Double
        Dim ppto_kilos As Double
        Dim vr_tot As Double
        Dim vr_kilo As Double
        Dim cto_tot As Double
        Dim porc_util As Double
        Dim dias_habiles As Double
        Dim cto_kilo As Double

        If CDate(fechaPpto) < CDate(Now.Year & "-" & Now.Month & "-01") Then
            MessageBox.Show("EL la fecha de el presupuesto debe ser manor o igual al mes actual", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            If (objGenerarPresLn.existePres(fechaPpto, nit)) Then
                Dim iResponce = MsgBox("El presupuesto para el mes " & fechaPpto & "de el vendedor: " & nit & " ya existe! desea actuaizarlo?", vbYesNo, "Actualizar")
                If (iResponce = 6) Then
                    objGenerarPresLn.eliminarPres(fechaPpto, nit)
                    For i = 1 To 27
                        vendedor = nit
                        id_cor = i
                        ppto_kilos = dtg.Item(5, i - 1).Value
                        vr_tot = dtg.Item(6, i - 1).Value
                        cto_tot = dtg.Item(7, i - 1).Value
                        vr_kilo = dtg.Item(8, i - 1).Value
                        cto_kilo = dtg.Item(9, i - 1).Value
                        porc_util = dtg.Item(10, i - 1).Value
                        dias_habiles = dtg.Item(12, i - 1).Value

                        objGenerarPresLn.insertarPres(fechaPpto, nit, id_cor, ppto_kilos, vr_tot, vr_kilo, cto_kilo, porc_util, dias_habiles, cto_tot)
                    Next
                    MessageBox.Show("El presupuesto se actualizo en forma correcta!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Else
                For i = 1 To 27
                    vendedor = nit
                    id_cor = i
                    ppto_kilos = dtg.Item(5, i - 1).Value
                    vr_tot = dtg.Item(6, i - 1).Value
                    cto_tot = dtg.Item(7, i - 1).Value
                    vr_kilo = dtg.Item(8, i - 1).Value
                    cto_kilo = dtg.Item(9, i - 1).Value
                    porc_util = dtg.Item(10, i - 1).Value
                    dias_habiles = dtg.Item(12, i - 1).Value

                    objGenerarPresLn.insertarPres(fechaPpto, nit, id_cor, ppto_kilos, vr_tot, vr_kilo, cto_kilo, porc_util, dias_habiles, cto_tot)
                Next
                If (nit <> 10011099 And nit <> 10011090) Then
                    MessageBox.Show("El presupuesto se guardo en forma correcta!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
        End If
        dtg.Columns(1).Visible = True
        dtg.Columns(2).Visible = True
        dtg.Columns(3).Visible = True
        dtg.Columns(4).Visible = True
        dtg.Columns(5).Visible = True
        dtg.Columns(6).Visible = True
        dtg.Columns(7).Visible = True
        dtg.Columns(8).Visible = True
        dtg.Columns(9).Visible = True
        dtg.Columns(10).Visible = True
        dtg.Columns(11).Visible = True
        dtg.Columns(12).Visible = True
        dtg.Columns(13).Visible = True
        dtg.Columns(14).Visible = True
        dtg.Columns(15).Visible = True
        lblNomVend.Text = nit
        cboVend.Text = nit
    End Sub
    Public Sub formatoPres()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        dtgAnalisisPres.Columns(5).DefaultCellStyle = DataGridViewCellStyle1
        dtgAnalisisPres.Columns(8).DefaultCellStyle = DataGridViewCellStyle1
        dtgAnalisisPres.Columns(10).DefaultCellStyle = DataGridViewCellStyle1
        dtgAnalisisPres.Columns(10).DefaultCellStyle.Format = "N0"
        dtgAnalisisPres.Columns(5).DefaultCellStyle.Format = "N0"
        dtgAnalisisPres.Columns(8).DefaultCellStyle.Format = "N0"
        dtgAnalisisPres.Columns(10).DefaultCellStyle.Format = "N0"
        dtgAnalisisPres.Columns(13).DefaultCellStyle.Format = "N0"
    End Sub
    Public Sub sumFilasAnPres()
        Dim sum As Double = 0
        For i = 0 To dtgAnalisisPres.RowCount - 2
            For j = 19 To dtgAnalisisPres.ColumnCount - 1
                sum += dtgAnalisisPres.Item(j, i).Value
            Next
            dtgAnalisisPres.Item("Total", i).Value = sum
            dtgAnalisisPres.Item("Promedio", i).Value = sum / 12
            sum = 0
        Next
    End Sub

End Class

