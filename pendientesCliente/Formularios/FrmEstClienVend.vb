Imports System.Configuration
Imports logicaNegocios
Imports accesoDatos
Imports System.IO
Imports Microsoft.Office.Interop
Public Class FrmEstClienVend
    Private objEstClienVendLn As EstClienVendLn
    Private objOperacionesForm As OperacionesFormularios = New OperacionesFormularios

    Private Sub FrmEstClienVend_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        objEstClienVendLn = New EstClienVendLn
        centrarEnPantalla()
        imgProcesar.Visible = False
        lblClienMov.Text = "Clientes con movimiento " & Now.Year - 1 & "-" & Now.Year
    End Sub

    Private Sub centrarEnPantalla()
        Me.Left = (Screen.PrimaryScreen.WorkingArea.Width - Me.Width) / 2
        Me.Top = (Screen.PrimaryScreen.WorkingArea.Height - Me.Height) / 2
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


    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        imgProcesar.Visible = True
        Application.DoEvents()
        dtgEstClietVend.DataSource = objEstClienVendLn.listarEstClient
        sumarColumnas()
        formatoNegrita()
        colorCeldas()
        dtgEstClietVend.Rows(0).Frozen = True
        dtgEstClietVend.Rows(1).Frozen = True
        nombreColumnasFecha()

        imgProcesar.Visible = False
    End Sub
    Public Sub sumarColumnas()
        Dim sum As Double = 0
        For i = 2 To dtgEstClietVend.ColumnCount - 1
            For j = 0 To dtgEstClietVend.RowCount - 2
                sum = sum + dtgEstClietVend.Item(i, j).Value
            Next
            dtgEstClietVend.Item(i, dtgEstClietVend.RowCount - 1).Value = sum
            sum = 0
        Next
    End Sub

    Public Sub formatoNegrita()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        dtgEstClietVend.Rows(dtgEstClietVend.RowCount - 1).DefaultCellStyle = DataGridViewCellStyle1
    End Sub
    Public Sub colorCeldas()
        For i = 0 To 6
            For j = 0 To dtgEstClietVend.RowCount - 1
                dtgEstClietVend.Item(i, j).Style.BackColor = System.Drawing.Color.SkyBlue
            Next

        Next
        For i = 7 To 11
            For j = 0 To dtgEstClietVend.RowCount - 1
                dtgEstClietVend.Item(i, j).Style.BackColor = System.Drawing.Color.Yellow
            Next

        Next
        For i = 12 To 13
            For j = 0 To dtgEstClietVend.RowCount - 1
                dtgEstClietVend.Item(i, j).Style.BackColor = System.Drawing.Color.NavajoWhite
            Next
        Next
        For i = 14 To 15
            For j = 0 To dtgEstClietVend.RowCount - 1
                dtgEstClietVend.Item(i, j).Style.BackColor = System.Drawing.Color.LightGreen
            Next
        Next
    End Sub
    Private Sub dtgEstClietVend_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgEstClietVend.CellDoubleClick

        Dim vendedor As Integer
       
        If (e.RowIndex < 0 Or e.RowIndex = dtgEstClietVend.RowCount - 1) Then
            MessageBox.Show("Click en item invalido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            vendedor = dtgEstClietVend(0, e.RowIndex).Value
        End If


        Select Case e.ColumnIndex
            Case 2
                dtgResultClient.DataSource = objEstClienVendLn.listarClientesCategoria("select vendedor,nit,nombres,ciudad,condicion,bloqueo,cupo_credito,fecha_creacion from terceros where vendedor=" & vendedor & "")
            Case 3
                dtgResultClient.DataSource = objEstClienVendLn.listarClientesCategoria("select vendedor,nit,nombres,ciudad,condicion,bloqueo,cupo_credito,fecha_creacion from terceros where  vendedor=" & vendedor & " and bloqueo=0")
            Case 4
                dtgResultClient.DataSource = objEstClienVendLn.listarClientesCategoria("select vendedor,nit,nombres,ciudad,condicion,bloqueo,cupo_credito,fecha_creacion from terceros where  vendedor=" & vendedor & " and bloqueo=1")
            Case 5
                dtgResultClient.DataSource = objEstClienVendLn.listarClientesCategoria("select vendedor,nit,nombres,ciudad,condicion,bloqueo,cupo_credito,fecha_creacion from terceros where  vendedor=" & vendedor & " and bloqueo=2")
            Case 6
                dtgResultClient.DataSource = objEstClienVendLn.listarClientesCategoria("select vendedor,nit,nombres,ciudad,condicion,bloqueo,cupo_credito,fecha_creacion from terceros where  vendedor=" & vendedor & " and bloqueo=3")
            Case 7
                dtgResultClient.DataSource = objEstClienVendLn.listarMovTotales("select vendedor,nit,nombres,ciudad,condicion,bloqueo,cupo_credito,fecha_creacion from terceros where  vendedor=" & vendedor & "  and nit  in (select nit from documentos  where  vendedor=" & vendedor & "  and sw =1 ")
            Case 8
                dtgResultClient.DataSource = objEstClienVendLn.listarMovTotales("select vendedor,nit,nombres,ciudad,condicion,bloqueo,cupo_credito,fecha_creacion from terceros where  vendedor=" & vendedor & " and bloqueo=0 and nit in (select nit from documentos  where  vendedor=" & vendedor & " and sw =1")
            Case 9
                dtgResultClient.DataSource = objEstClienVendLn.listarMovTotales("select vendedor,nit,nombres,ciudad,condicion,bloqueo,cupo_credito,fecha_creacion from terceros where  vendedor=" & vendedor & " and bloqueo=1 and nit in (select nit from documentos  where  vendedor=" & vendedor & " and sw =1")
            Case 10
                dtgResultClient.DataSource = objEstClienVendLn.listarMovTotales("select vendedor,nit,nombres,ciudad,condicion,bloqueo,cupo_credito,fecha_creacion from terceros where  vendedor=" & vendedor & " and bloqueo=2 and nit in (select nit from documentos  where  vendedor=" & vendedor & " and sw =1")
            Case 11
                dtgResultClient.DataSource = objEstClienVendLn.listarMovTotales("select vendedor,nit,nombres,ciudad,condicion,bloqueo,cupo_credito,fecha_creacion from terceros where  vendedor=" & vendedor & " and bloqueo=3 and nit in (select nit from documentos  where  vendedor=" & vendedor & " and sw =1")
            Case 12
                dtgResultClient.DataSource = objEstClienVendLn.listarAtendFecIni(vendedor)
            Case 13
                dtgResultClient.DataSource = objEstClienVendLn.listarAtendFecFin(vendedor)
            Case 14
                dtgResultClient.DataSource = objEstClienVendLn.listarNuevosFecini(vendedor)
            Case 15
                dtgResultClient.DataSource = objEstClienVendLn.listarNuevosFecFin(vendedor)

        End Select
    End Sub
    Private Sub dtgResultClient_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgResultClient.CellDoubleClick
        Dim cliente As Integer
        If (e.RowIndex < 0 Or e.RowIndex = dtgResultClient.RowCount - 1) Then
            MessageBox.Show("Click en item invalido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            cliente = dtgResultClient(1, e.RowIndex).Value
            frmPendientes.Show()
            frmPendientes.cargarInfoClient(cliente)
            frmPendientes.Activate()
        End If

    End Sub
    Private Sub dtgResultClient_CellFormatting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dtgResultClient.CellFormatting
        Dim var As Integer = 0

        If (dtgResultClient.RowCount Mod 2 = 1) Then
            var = 1
        End If
        If e.RowIndex Mod 2 = var Then
            e.CellStyle.BackColor = Color.Gainsboro
        End If
    End Sub
    Public Sub nombreColumnasFecha()
        Dim mes As Double = Now.Month
        Dim año As Double = Now.Year
        Dim fechaIni As Date
        Dim fechaFin As Date
        Dim fechaIni2 As Date
        Dim fechaFin2 As Date
        fechaIni = DateAdd("m", -12, Now.Year & "-" & Now.Month & "-01")
        fechaFin = DateAdd("m", -7, Now.Year & "-" & Now.Month & "-01")
        fechaIni2 = DateAdd("m", -6, Now.Year & "-" & Now.Month & "-01")
        fechaFin2 = DateAdd("m", -1, Now.Year & "-" & Now.Month & "-01")
        dtgEstClietVend.Columns(12).HeaderText = nombreMeses(fechaIni.Month) & " " & fechaIni.Year & " - " & nombreMeses(fechaFin.Month) & " " & fechaFin.Year
        dtgEstClietVend.Columns(14).HeaderText = nombreMeses(fechaIni.Month) & " " & fechaIni.Year & " - " & nombreMeses(fechaFin.Month) & " " & fechaFin.Year
        dtgEstClietVend.Columns(13).HeaderText = nombreMeses(fechaIni2.Month) & " " & fechaFin.Year & " - " & nombreMeses(fechaFin2.Month) & " " & fechaFin2.Year
        dtgEstClietVend.Columns(15).HeaderText = nombreMeses(fechaIni2.Month) & " " & fechaFin.Year & " - " & nombreMeses(fechaFin2.Month) & " " & fechaFin2.Year
        dtgEstClietVend.Columns(2).HeaderText = "Total client"
        dtgEstClietVend.Columns(3).HeaderText = "Total act"
        dtgEstClietVend.Columns(4).HeaderText = "Total inact"
        dtgEstClietVend.Columns(5).HeaderText = "Total Bloq"
        dtgEstClietVend.Columns(6).HeaderText = "Total No usar"
        dtgEstClietVend.Columns(7).HeaderText = "Mov totales"
        dtgEstClietVend.Columns(8).HeaderText = "Mov act"
        dtgEstClietVend.Columns(9).HeaderText = "Mov inact"
        dtgEstClietVend.Columns(10).HeaderText = "Mov bloq"
        dtgEstClietVend.Columns(11).HeaderText = "Mov no usar"


    End Sub

    Public Function nombreMeses(ByVal num As Integer) As String
        Dim s As String = ""
        Select Case num
            Case 1
                Return "Ene"
            Case 2
                Return "feb"
            Case 3
                Return "Mar"
            Case 4
                Return "Abr"
            Case 5
                Return "may"
            Case 6
                Return "Jun"
            Case 7
                Return "Jul"
            Case 8
                Return "Ago"
            Case 9
                Return "Sep"
            Case 10
                Return "Oct"
            Case 11
                Return "Nov"
            Case 12
                Return "Dic"
        End Select
        Return s
    End Function
    Private Sub PrincipalToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrincipalToolStripMenuItem1.Click
        objOperacionesForm.ExportarDatosExcel(dtgEstClietVend, "Estado clientes")
    End Sub

    Private Sub DetalleToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DetalleToolStripMenuItem.Click
        objOperacionesForm.ExportarDatosExcel(dtgResultClient, "Detalle clientes")
    End Sub
End Class