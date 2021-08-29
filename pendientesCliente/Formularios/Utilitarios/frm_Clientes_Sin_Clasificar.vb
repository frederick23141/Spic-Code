Public Class frm_Clientes_Sin_Clasificar
    'muestra terceros no clasificados
    Public Sub main(ByVal dt As DataTable)
        dtg_Sin_Clasificar.DataSource = dt
    End Sub
End Class