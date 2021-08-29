Imports System.Configuration
Imports logicaNegocios
Imports entidadNegocios
Imports System.IO
Imports Microsoft.Office.Interop
Public Class Frm_dtalle_seg_ppto
    Private objUsuarioLn As New UsuarioLn
    Private objOperacionesForm As OperacionesFormularios = New OperacionesFormularios
    Private obj_Dtalle_seg_ppto_Ln As New Dtalle_seg_ppto_Ln
    Private objUsuarioEn As New UsuarioEn
    Public vendedor As Integer
    Private nom_modulo As String = ""
    Dim vendedores As String = ""
    Private Sub Frm_dtalle_seg_ppto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim vendedores As String = objUsuarioLn.coordinadorVend(objUsuarioEn.usuario)
        Dim ano = Now.Year
        Dim list_vend As New List(Of Integer)
        list_vend = obj_Dtalle_seg_ppto_Ln.listar_vendedores(vendedores)
        For indice As Integer = 0 To list_vend.Count - 1 Step 1
            cbo_vend.Items.Add(list_vend(indice))
        Next
        cbo_vend.Items.Add("Nacionales")
        cbo_vend.Items.Add("Todos")
        cbo_vend.Text = ("Todos")
        Dim año = Now.Year
        While (ano >= Now.Year - 5)
            cboAñoIni.Items.Add(ano)
            cboAñoFin.Items.Add(ano)
            ano -= 1
        End While
        cboAñoIni.SelectedIndex = 0
        cboAñoFin.SelectedIndex = 0
        cboMesIni.SelectedIndex = Now.Month - 1
        cboMesFin.SelectedIndex = Now.Month - 1

    End Sub
    Public Sub Main(ByVal vend As Integer, ByVal nom_modulo As String, ByVal permiso As String, ByVal objUsuarioEn As UsuarioEn)
        Me.nom_modulo = nom_modulo
        vendedor = vend
        If (vendedor <> 1020) Then
            cbo_vend.Text = vendedor
            cbo_vend.Visible = False
        End If
        If (permiso <> "ADMIN") Then
            btnContCambios.Visible = False
        End If
        Me.objUsuarioEn = objUsuarioEn
        vendedores = objUsuarioLn.coordinadorVend(objUsuarioEn.usuario)
    End Sub
    Private Sub btnContCambios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnContCambios.Click
        FrmAuditCambios.Show()
        FrmAuditCambios.Main(nom_modulo)
        FrmAuditCambios.WindowState = 2
        Me.WindowState = 1
    End Sub
    Private Sub btn_consultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_consultar.Click
        Dim mesini As Integer = cboMesIni.SelectedIndex + 1
        Dim añoIni As Integer = cboAñoIni.SelectedItem
        Dim mesFin As Integer = cboMesFin.SelectedIndex + 1
        Dim añoFin As Integer = cboAñoFin.SelectedItem
        Dim dia_fin As Integer = DateSerial(añoFin, mesFin + 1, 0).Day
        Dim fec_ini As String = añoIni & "/" & mesini & "/01"
        Dim fec_max As String = añoFin & "/" & mesFin & "/" & dia_fin
        Dim criterio As String = ""
        Dim min As Integer
        Dim max As Integer
        If (chkKilos.Checked = True Or chkPesos.Checked = True) Then
            If (cbo_vend.Text <> "Seleccione") Then
                If (cboAñoFin.SelectedIndex <> -1 And cboAñoIni.SelectedIndex <> -1 And cboMesFin.SelectedIndex <> -1 And cboAñoIni.SelectedIndex <> -1) Then
                    If (chkKilos.Checked = True) Then
                        criterio = "kilos"
                    Else
                        criterio = "pesos"
                    End If
                    If (cbo_vend.Text = "Todos") Then
                        min = 1001
                        max = 1099
                    Else
                        If (cbo_vend.Text = "Nacionales") Then
                            min = 1001
                            max = 1095
                        Else
                            min = cbo_vend.Text
                            max = cbo_vend.Text
                        End If
                    End If
                    cargar_todo(min, max, fec_ini, fec_max, criterio)
                Else
                    MessageBox.Show("Seleccione un rango de fecha valido!", "Seleccione", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                MessageBox.Show("Seleccione un vendedor!", "Seleccione", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            MessageBox.Show("Seleccione un criterio de busqueda! 'kilos- pesos' ", "Seleccione", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Public Sub cargar_todo(ByVal min As Integer, ByVal max As Integer, ByVal fec_ini As String, ByVal fec_fin As String, ByVal criterio As String)
        imgProcesar.Visible = True
        Application.DoEvents()
        dtgDetalle.DataSource = Nothing
        dtgDetalle.DataSource = obj_Dtalle_seg_ppto_Ln.listarBusqueda(min, max, fec_ini, fec_fin, criterio, vendedores, chk_grupo_produccion.Checked, chk_linea.Checked)
        If (criterio = "pesos") Then
            dtgDetalle.DefaultCellStyle.Format = "C0"
        Else
            dtgDetalle.DefaultCellStyle.Format = "N0"
        End If
        sumarColumnas()
        formatoNegrita()
        imgProcesar.Visible = False

    End Sub
    Public Sub sumarColumnas()
        Dim sum As Double = 0
        For i = 1 To dtgDetalle.ColumnCount - 1
            For j = 0 To dtgDetalle.RowCount - 2
                If IsNumeric(dtgDetalle.Item(i, j).Value) Then
                    sum = sum + dtgDetalle.Item(i, j).Value
                End If

            Next
            dtgDetalle.Item(i, dtgDetalle.RowCount - 1).Value = sum
            sum = 0
        Next
    End Sub
    Public Sub formatoNegrita()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        dtgDetalle.Rows(dtgDetalle.RowCount - 1).DefaultCellStyle = DataGridViewCellStyle1
    End Sub

    Private Sub ChkPesosVend_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPesos.CheckedChanged
        If chkPesos.Checked = True Then
            chkKilos.Checked = False
        End If
    End Sub
    Private Sub chkKilVend_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkKilos.CheckedChanged
        If chkKilos.Checked = True Then
            chkPesos.Checked = False
        End If
    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        FrmLogin.Show()
        FrmPrincipal.Close()
        Me.Close()
    End Sub

    Private Sub btn_ppal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ppal.Click
        FrmPrincipal.Show()
        Me.Close()
    End Sub

    Private Sub btn_exportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exportar.Click
        objOperacionesForm.ExportarDatosExcel(dtgDetalle, "Detalle presupuesto")
    End Sub
End Class