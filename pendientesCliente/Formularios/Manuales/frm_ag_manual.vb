Imports logicaNegocios
Imports entidadNegocios

Public Class frm_ag_manual
    Dim num As Integer = 0
    Private objOpSimplesLn As New Op_simpesLn
    Private obj_Ing_prodLn As New Ing_prodLn
    Public Sub MAIN(ByVal numero As Integer)
        Me.Text = "Manual #" & numero
        num = numero
        lbl_archivo.Text = "Examinar"
    End Sub
    Private Sub frm_ag_manual_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim sql As String = "SELECT id,area FROM JB_AREAS_MANUAL"

        Dim dt As DataTable = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        dt.Rows.Add()
        dt.Rows(dt.Rows.Count - 1).Item("id") = 0
        dt.Rows(dt.Rows.Count - 1).Item("area") = "Seleccione Area"
        cbo_area.DataSource = dt
        cbo_area.ValueMember = "id"
        cbo_area.DisplayMember = "area"
        cbo_area.SelectedValue = 0
    End Sub

    Private Sub OpenFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk
        Dim ruta As String = OpenFileDialog1.FileName
        Dim id As String = num
        Dim Destination As String = "\\sst\Dms_con\AQUI PROGRAMA\SPIC\Manuales\" & id & ".pdf"
        System.IO.File.Delete(Destination)
        System.IO.File.Copy(ruta, Destination, True)
        lbl_archivo.Text = Destination
    End Sub

    Private Sub btn_examinar_Click(sender As Object, e As EventArgs) Handles btn_examinar.Click
        OpenFileDialog1.Filter = "PDF (*.pdf)|*.pdf"
        OpenFileDialog1.ShowDialog()
    End Sub

    Private Sub btn_guardar_Click(sender As Object, e As EventArgs) Handles btn_guardar.Click
        If txt_nombre.Text <> "" Then
            If lbl_archivo.Text <> "Examinar" Then
                If cbo_area.SelectedValue <> 0 Then
                    Dim sql As String = "INSERT INTO JB_manuales_dir (id_man,nombre,direccion,area) VALUES (" & num & ",'" & txt_nombre.Text & "','" & lbl_archivo.Text & "'," & cbo_area.SelectedValue & ")"
                    If objOpSimplesLn.ejecutar(sql, "CORSAN") Then
                        MessageBox.Show("El manual se agrego correctamente.", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        frm_manuales_spic.cargar_man()
                        Me.Close()
                    End If
                Else
                    MessageBox.Show("Debe seleccionar un area.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                MessageBox.Show("Debe registrar un archivo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            MessageBox.Show("Debe ingresar un nombre.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
End Class