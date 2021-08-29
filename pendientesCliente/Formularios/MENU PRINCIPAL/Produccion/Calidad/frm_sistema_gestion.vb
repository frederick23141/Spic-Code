Public Class frm_sistema_gestion

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'My.Computer.FileSystem.CopyFile("C:\Users\julian.bayer\Desktop\Documentos\Formato Carnet.docx", "\\sst\Dms_con\AQUI PROGRAMA\Documentos\Formato Carnet.docx")


        'My.Computer.FileSystem.OpenTextFieldParser("C:\Users\julian.bayer\Desktop\Documentos\INFORME ALAMBRE GALVANIZADO C-18 IMPORTACION.PDF")


        'My.Application.Info.DirectoryPath & "\Ayuda.pdf"
        Process.Start("\\sst\Dms_con\AQUI PROGRAMA\Documentos\Formato Carnet.docx")
    End Sub


    Private Sub Inicio_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F1 Then

            Dim DebugRuta As String = My.Application.Info.DirectoryPath & "\Ayuda.pdf"


            Process.Start(DebugRuta)

        End If

    End Sub
End Class