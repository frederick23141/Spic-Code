Imports logicaNegocios
Public Class Frm_ver_foto
    Private objOpSimplesLn As New Op_simpesLn
    Public Sub MAIN(ByVal nit As Double)
        Dim SW As Boolean = False
        Dim sql As String = "Select (CASE WHEN foto is null THEN '' ELSE 'S' END) From y_personal_contratos Where estado = 'A' AND nit = " & nit
        Dim foto_v As String
        foto_v = objOpSimplesLn.consultValorTodo(sql, "CORSAN")
        If foto_v <> "" Then
            SW = True
        Else
            sql = "Select (CASE WHEN foto is null THEN '' ELSE 'S' END) From CONTROL.dbo.j_personal_maquila Where estado = 'A' AND nit = " & nit
        End If
        If objOpSimplesLn.consultValorTodo(sql, "CORSAN") <> "" Then
            Application.DoEvents()
            Try
                Dim ms As New IO.MemoryStream(objOpSimplesLn.ExtraerImagen(nit))
                PictureBox1.Image = Image.FromStream(ms)
            Catch ex As Exception
                ' MessageBox.Show(ex.Message)
                PictureBox1.Image = Nothing
            End Try
        Else
            Dim ruta As String = Environment.CurrentDirectory & "\sinFoto.gif"
            PictureBox1.Image = System.Drawing.Image.FromFile(ruta)
        End If
    End Sub

End Class