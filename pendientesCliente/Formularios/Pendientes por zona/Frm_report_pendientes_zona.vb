Public Class Frm_report_pendientes_zona

    Private Sub Frm_report_pendientes_zona_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'CORSANDataSet4.V_pendientes_por_vendedor' Puede moverla o quitarla según sea necesario.
        Me.V_pendientes_por_vendedorTableAdapter.Fill(Me.CORSANDataSet4.V_pendientes_por_vendedor)

    End Sub
End Class