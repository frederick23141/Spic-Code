Imports logicaNegocios
Imports Microsoft.VisualBasic.PowerPacks.Printing.Compatibility.VB6
Imports System.Drawing.Printing
Public Class Frm_consultar_separe
    Private objOperacionesForm As New OperacionesFormularios
    Private objOpSimplsLn As New Op_simpesLn
    Dim carga_comp As Boolean = False
    Private Sub cargar_consulta()
        If txt_num_separe.Text <> "" And txt_numero.Text <> "" Then
            Dim tamano_letra As Single = 8.0!
            Dim sql As String = "SELECT e.fecha As fecha_separe,p.nombres,p.codigo,p.descripcion , p.Pendiente  ,d.cantidad AS cargado , d.cantidad * p.conversion As kilos ,d.cajas " & _
                                    "FROM J_terminado_planilla_separe e  , J_terminado_planilla_separe_det d , CORSAN.dbo.V_pendientes_por_vendedor p " & _
                                        "WHERE e.id_planilla = d.id_planilla AND e.num_ped = d.num_ped AND e.num_ped = p.numero AND d.codigo = p.codigo AND e.fecha_terminado IS NOT NULL AND e.id_planilla = " & txt_num_separe.Text & " AND p.numero=" & txt_numero.Text
            Dim dt As DataTable = objOpSimplsLn.listar_datatable(sql, "PRODUCCION")
            dtgCodigo.DataSource = dt
            dtgCodigo.Columns("kilos").DefaultCellStyle = objOperacionesForm.formatoNegrita(tamano_letra)
            dtgCodigo.Columns("fecha_separe").DefaultCellStyle.Format = "d"
        Else
            MessageBox.Show("Ingrese número de pedido y separe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

    End Sub

    Private Sub btn_consultar_Click(sender As Object, e As EventArgs) Handles btn_consultar.Click
        If txt_numero.Text <> "" Then
            cargar_consulta()
        End If
    End Sub
    Private Sub txt_numero_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_numero.KeyPress
        soloNumero(e)
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            cargar_consulta()
        End If
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

    Private Sub txt_num_separe_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_num_separe.KeyPress
        soloNumero(e)
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            cargar_consulta()
        End If
    End Sub
End Class