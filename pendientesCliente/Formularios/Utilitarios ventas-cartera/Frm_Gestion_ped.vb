Imports System.Configuration
Imports logicaNegocios
Imports entidadNegocios
Imports System.IO
Imports Microsoft.Office.Interop
Public Class Frm_Gestion_ped
    Private objOperacionesForm As OperacionesFormularios = New OperacionesFormularios
    Private obj_gestion_ped_Ln As New Gestion_ped_Ln
    Private objUsuarioEn = New UsuarioEn
    Private Sub Main(ByVal objUsuarioEn As UsuarioEn)
        Me.objUsuarioEn = objUsuarioEn
        dtg_ped.DataSource = obj_gestion_ped_Ln.listar_ped()
    End Sub
    Private Sub itemMail_Opening(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles itemMail.Click
        Dim nit As Integer = 0
        Dim nombre As String

        nit = dtg_ped(0, dtg_ped.CurrentCell.RowIndex).Value
        nombre = dtg_ped(11, dtg_ped.CurrentCell.RowIndex).Value
        frmPendientes.Show()
        frmPendientes.cargarInfoClient(nit)
        Application.DoEvents()
        capturarPantalla()
        frmPendientes.Close()
        FrmDatosMail.Show()
        FrmDatosMail.iniciarValores("c:\Informacion.jpg", objUsuarioEn, nombre)
    End Sub
    Private Sub itemMasInfo_Opening(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles itemMasInfo.Click
        Dim nit As Integer
       
        nit = dtg_ped("nit", dtg_ped.CurrentCell.RowIndex).Value
        frmPendientes.Show()
        frmPendientes.cargarInfoClient(nit)
        frmPendientes.Activate()
    End Sub
    Private Sub itemAutorizar_Opening(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles itemAutorizar.Click
        'Dim usuario As String = objUsuarioEn.nombre
        'Dim numeroPed As Integer = 0
        'numeroPed = dtg_ped(1, dtg_ped.CurrentCell.RowIndex).Value
        'FrmAutorizar.Show()
        'FrmAutorizar.inicializarVar(usuario, numeroPed, Str)

    End Sub
    Private Sub capturarPantalla()
        Dim FSize As Size = frmPendientes.Size
        Dim bm As New Bitmap(FSize.Width, FSize.Height)
        Dim gf As Graphics
        Dim screenCap As Image
        gf = Graphics.FromImage(bm)
        gf.CopyFromScreen(0, 0, 0, 0, FSize)
        screenCap = bm
        Dim rutaArchiovo As String = ("c:\Informacion.jpg")
        screenCap.Save(rutaArchiovo)
        bm.Dispose()
    End Sub
    Private Sub SalirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalirToolStripMenuItem.Click
        FrmLogin.Show()
        FrmPrincipal.Close()
        Me.Close()
    End Sub
    Private Sub PrincipalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrincipalToolStripMenuItem.Click
        FrmPrincipal.Show()
        Me.Close()
        FrmPrincipal.Activate()
    End Sub

    Private Sub dtg_ped_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dtg_ped.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            With (Me.dtg_ped)
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                End If
            End With
        End If
    End Sub
    Private Sub BorrarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BorrarToolStripMenuItem.Click
        Dim numero As Double = dtg_ped.Item("numero", dtg_ped.CurrentCell.RowIndex).Value
        Dim iResponce = MessageBox.Show("Esta seguro que desea eliminar el  pedido numero " & numero & " de la lista? ", "Atención", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
        If (iResponce = 6) Then
            If (obj_gestion_ped_Ln.anular_ped(numero) = 1) Then
                Dim row As Integer = dtg_ped.CurrentCell.RowIndex
                dtg_ped.CurrentCell = Nothing
                dtg_ped.Rows(row).Visible = False
                MsgBox("esdcito")
            End If
            
        End If

    End Sub
End Class