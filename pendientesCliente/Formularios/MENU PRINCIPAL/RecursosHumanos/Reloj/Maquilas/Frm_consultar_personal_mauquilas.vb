Imports System.Configuration
Imports logicaNegocios
Imports entidadNegocios
Imports System.IO
Imports Microsoft.Office.Interop
Public Class Frm_consultar_usu_mauquilas
    Private strSql As String
    Private objLoginLn As New LoginLn
    Private obj_Op_simpesLn As New Op_simpesLn
    Dim nit As Double
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_consulta()
    End Sub

    Public Sub cargar_consulta()
        Dim where_sql As String = ""
        If txtNombres.Text <> "" Then
            where_sql = "WHERE nombres LIKE '%" & txtNombres.Text & "%'"
        End If
        Dim sql As String = "SELECT nit,nombres FROM J_personal_maquila "
        dtgConsulta.DataSource = obj_Op_simpesLn.listar_datatable(sql, "CONTROL")
    End Sub

    Private Sub txtNit_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        txtNombres.Text = ""
        cargar_consulta()
    End Sub
    Private Sub dtgConsulta_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgConsulta.CellClick
        If dtgConsulta.Columns(e.ColumnIndex).Name = btn_select_imagen.Name Then
            nit = dtgConsulta.Item("nit", e.RowIndex).Value
            OpenFileDialog1.ShowDialog()
        ElseIf dtgConsulta.Columns(e.ColumnIndex).Name = btn_ver_foto.Name Then
            Frm_ver_foto.Show()
            Frm_ver_foto.Text = dtgConsulta.Item("nombres", e.RowIndex).Value
            Frm_ver_foto.MAIN(dtgConsulta.Item("nit", e.RowIndex).Value)
        End If
    End Sub
    Private Sub OpenFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk
        Dim ruta As String = OpenFileDialog1.FileName
        guardar_img(ruta, nit)
    End Sub
    Private Sub guardar_img(ByVal ruta As String, ByVal nit As Double)
        PictureBox1.Image = System.Drawing.Image.FromFile(ruta)
        Dim arrFilename() As String = Split(Text, "\")
        Array.Reverse(arrFilename)
        Dim ms As New MemoryStream
        PictureBox1.Image.Save(ms, PictureBox1.Image.RawFormat)
        Dim arrImage() As Byte = ms.GetBuffer
        If obj_Op_simpesLn.guardar_imagen(arrImage, nit) Then
            MessageBox.Show("La  foto se guardo en forma correcta", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Error al guardar", "verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btn_actualizar_Click(sender As Object, e As EventArgs) Handles btn_actualizar.Click
        cargar_consulta()
    End Sub
End Class
