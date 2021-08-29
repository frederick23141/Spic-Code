Imports logicaNegocios
Public Class Frm_informe_temporales
    Dim objIngresoProdLn As New Ing_prodLn
    Private obj_Ing_prodLn As New Ing_prodLn
    Private objOperacionesForm As OperacionesFormularios = New OperacionesFormularios
    Dim nit As String
    Private objOpSimplesLn As New Op_simpesLn
    Private Sub Frm_informe_temporales_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim sql As String
        Dim dt As New DataTable
        sql = "select nit,nombres,(select descripcion from corsan.dbo.centros c where centro=j.centro) as centro,(select descripcion from corsan.dbo.y_oficios o where oficio=j.oficio) as oficio,basico_hora,basico_mes,direccion,telefono_1,fecha_ingreso,fecha_final from j_personal_maquila j"
        dt = objIngresoProdLn.listar_datatable(sql, "CONTROL")
        blinding_temporales = New BindingSource()
        blinding_temporales.DataSource = dt
        dtg_temporales.DataSource = blinding_temporales
    End Sub
    Private Sub txt_nombres_TextChanged(sender As Object, e As EventArgs) Handles txt_nombres.TextChanged
        blinding_temporales.Filter = String.Format("nombres LIKE '{0}%'", txt_nombres.Text)
    End Sub
    Private Sub btn_exportar_Click(sender As Object, e As EventArgs) Handles btn_exportar.Click
        objOperacionesForm.ExportarDatosExcel(dtg_temporales, "Temporales")
        objOperacionesForm.ExportarDatosExcel(dtg_temporales, "Temporales")
    End Sub
End Class