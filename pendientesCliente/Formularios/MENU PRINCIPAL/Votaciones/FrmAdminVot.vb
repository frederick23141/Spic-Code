Imports System.Configuration
Imports logicaNegocios
Imports System.IO
Imports Microsoft.Office.Interop
#Disable Warning BC40056 ' El espacio de nombres o el tipo especificado en el 'System.Data.SqlServerCe' Imports no contienen ningún miembro público o no se encuentran. Asegúrese de que el espacio de nombres o el tipo se hayan definido y de que contengan al menos un miembro público. Asegúrese de que el nombre del elemento importado no use ningún alias.
Imports System.Data.SqlServerCe
#Enable Warning BC40056 ' El espacio de nombres o el tipo especificado en el 'System.Data.SqlServerCe' Imports no contienen ningún miembro público o no se encuentran. Asegúrese de que el espacio de nombres o el tipo se hayan definido y de que contengan al menos un miembro público. Asegúrese de que el nombre del elemento importado no use ningún alias.
Imports System.IO.Ports

Public Class FrmAdminVot
    Dim WithEvents puertoSerial As New SerialPort
    Private objVotacionesLn As New VotacionesLn
    Dim peso As String = ""
    Dim ant As String = ""

    Private Sub Btn_act_operarios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_act_operarios.Click
        Dim iResponce = MessageBox.Show("Se cargaran todos los empleados actualmente activos en la empresa y los botos quedaran en cero de nuevo. esta deacuerdo? ", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If (iResponce = 6) Then
            If (objVotacionesLn.formatearVotaciones()) Then
                MessageBox.Show("Las votaciones fueron reiniciadas en forma correcta! ", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Error en el aplicativo, comuniquese con el administridor del sistema! ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim pesoFinal As String = ""
        For i = 1 To RichTextBox1.TextLength - 1
            If (RichTextBox1.Text(i) <> "=") Then
                If (RichTextBox1.Text(i) <> "-") Then
                    pesoFinal += RichTextBox1.Text(i)
                End If
            Else
                i = RichTextBox1.TextLength
            End If
        Next
        MsgBox(pesoFinal)
    End Sub



    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If (RichTextBox1.TextLength >= 15) Then
            RichTextBox1.Text = peso
        End If
        peso = SerialPort1.ReadExisting
        RichTextBox1.Text += peso
        'SerialPort1.DiscardInBuffer()C:\Documents and Settings\JORGE.ESCOBAR\Escritorio\pendientesCliente\accesoDatos\DespachoAd.vb
    End Sub

    Private Sub FrmAdminVot_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Timer1.Enabled = True
        SerialPort1.Open()
    End Sub
End Class