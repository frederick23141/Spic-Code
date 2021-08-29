'' FORMULARIO PARA SELECCIONAR LA IMPRESORA ZEBRA CON LA CUAL SE VA A IMPRIMIR
Imports System.Drawing.Printing
Public Class Frm_imprimir_alambron
    Declare Function SetDefaultPrinter Lib "winspool.drv" Alias "SetDefaultPrinterA" (ByVal pszPrinter As String) As Boolean

    Private Sub Frm_imprimir_alambron_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            lstImpresorasInstaladas.Items.Clear()
            For Each Impresora As String In PrinterSettings.InstalledPrinters
                lstImpresorasInstaladas.Items.Add(Impresora)
            Next
        Catch ex As Exception

        End Try
    End Sub


    Private Sub lstImpresorasInstaladas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstImpresorasInstaladas.SelectedIndexChanged
        Try
            If lstImpresorasInstaladas.SelectedItem.ToString <> "" Then
                SetDefaultPrinter(lstImpresorasInstaladas.SelectedItem.ToString)
            End If
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub
End Class