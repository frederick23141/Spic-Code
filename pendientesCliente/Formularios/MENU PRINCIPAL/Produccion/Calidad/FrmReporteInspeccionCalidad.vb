Imports logicaNegocios

Public Class FrmReporteInspeccionCalidad


    Public obj_Ing_prodLn As New Ing_prodLn
    Public dtg_consulta As Object

    Private Sub eneroToolStripButton_Click(sender As Object, e As EventArgs) Handles ToolStripButtonDiciembre.Click
        Try
            Me.F_V_CalidadTableAdapter2.Diciembre8(Me.DATASETCALIDAD.F_V_Calidad)
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub Consultar_maquina_9ToolStripButton_Click(sender As Object, e As EventArgs)
        Try
            Me.F_V_CalidadTableAdapter2.consultar_maquina_9(Me.DATASETCALIDAD.F_V_Calidad)
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub FebreroToolStripButton_Click(sender As Object, e As EventArgs)
        Try
            Me.F_V_CalidadTableAdapter2.Marzo8(Me.DATASETCALIDAD.F_V_Calidad)
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButtonEnero.Click
        Try
            Me.F_V_CalidadTableAdapter2.Enero8(Me.DATASETCALIDAD.F_V_Calidad)
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ToolStripButton11_Click(sender As Object, e As EventArgs) Handles ToolStripButtonFebrero.Click
        Try
            Me.F_V_CalidadTableAdapter2.Febrero8(Me.DATASETCALIDAD.F_V_Calidad)
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ToolStripButton10_Click(sender As Object, e As EventArgs) Handles ToolStripButtonMarzo.Click
        Try
            Me.F_V_CalidadTableAdapter2.Marzo8(Me.DATASETCALIDAD.F_V_Calidad)
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ToolStripButton9_Click(sender As Object, e As EventArgs) Handles ToolStripButtonAbril.Click
        Try
            Me.F_V_CalidadTableAdapter2.Abril8(Me.DATASETCALIDAD.F_V_Calidad)
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ToolStripButton8_Click(sender As Object, e As EventArgs) Handles ToolStripButtonMayo.Click
        Try
            Me.F_V_CalidadTableAdapter2.Mayo8(Me.DATASETCALIDAD.F_V_Calidad)
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ToolStripButton7_Click(sender As Object, e As EventArgs) Handles ToolStripButtonJunio.Click
        Try
            Me.F_V_CalidadTableAdapter2.Junio8(Me.DATASETCALIDAD.F_V_Calidad)
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ToolStripButton6_Click(sender As Object, e As EventArgs) Handles ToolStripButtonJulio.Click
        Try
            Me.F_V_CalidadTableAdapter2.Julio8(Me.DATASETCALIDAD.F_V_Calidad)
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButtonAgosto.Click
        Try
            Me.F_V_CalidadTableAdapter2.Agosto8(Me.DATASETCALIDAD.F_V_Calidad)
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButtonSeptiembre.Click
        Try
            Me.F_V_CalidadTableAdapter2.Septiembre8(Me.DATASETCALIDAD.F_V_Calidad)
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButtonOctubre.Click
        Try
            Me.F_V_CalidadTableAdapter2.Octubre8(Me.DATASETCALIDAD.F_V_Calidad)
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButtonNoviembre.Click
        Try
            Me.F_V_CalidadTableAdapter2.Noviembre8(Me.DATASETCALIDAD.F_V_Calidad)
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ToolStripButton1_Click_1(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        llenarExcel(DataGridView1)

    End Sub
End Class