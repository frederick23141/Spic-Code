Imports logicaNegocios
Public Class FrmVerificaPrecio
    Private objOpSimpesLn As New Op_simpesLn
    Private objOperacionesForm As New OperacionesFormularios
    Private objOpSimples As New Op_simpesLn
    Private nom_modulo As String
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
    Private Sub btnActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActualizar.Click
        If (txtCodigo.Text <> "" And txtPrecio.Text <> "") Then
            Dim cod As String = txtCodigo.Text
            Dim precio As Double = txtPrecio.Text
            Dim sql As String = "SELECT pend.fecha,pend.vendedor,pend.numero,pend.codigo,pend.descripcion,pend.valor_unitario,pend.nit , pend.nombres ,pend.Cant_pedida,pend.cantidad_despachada,KilosPendiente ,pend.notas,pend.nota_vta,pend.notas_aut,pend.notas5 " & _
                                     "FROM V_pendientes_por_vendedor pend " & _
                                         "WHERE codigo like '%" & cod & "%' and pend.valor_unitario <= " & precio & " "
            dtgBuenos.DataSource = objOpSimpesLn.listar_datatable(sql, "CORSAN")
            sql = "SELECT ped.fecha,ped.vendedor,pend.numero,pend.codigo,ref.descripcion,pend.valor_unitario,ped.nit , ter.nombres ,pend.cantidad ,pend.cantidad_despachada ,ped.notas,ped.nota_vta,ped.notas_aut,ped.notas5 " & _
                     "FROM JJV_documentos_lin_ped pend , JJV_documentos_ped ped,terceros ter  , referencias ref " & _
                        "WHERE ter.nit = ped.nit AND ref.codigo = pend.codigo AND  pend.numero = ped.numero AND  pend.codigo like '%" & cod & "%' and pend.valor_unitario <= " & precio & " AND ped.anulado=0 "
            dtgNoref.DataSource = objOpSimpesLn.listar_datatable(sql, "CORSAN")


        End If
    End Sub
    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        FrmPrincipal.Show()
        Me.Close()
        FrmPrincipal.Activate()
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        FrmLogin.Show()
        FrmPrincipal.Close()
        Me.Close()
    End Sub

    Private Sub BuenosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BuenosToolStripMenuItem.Click
        objOperacionesForm.ExportarDatosExcel(dtgBuenos, "Buenos")
    End Sub

    Private Sub NoReflejadosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NoReflejadosToolStripMenuItem.Click
        objOperacionesForm.ExportarDatosExcel(dtgNoref, "No reflejados")
    End Sub

   
End Class