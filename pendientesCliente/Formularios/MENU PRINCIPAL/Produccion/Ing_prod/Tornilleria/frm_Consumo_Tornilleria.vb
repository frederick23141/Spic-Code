Imports logicaNegocios
Public Class frm_Consumo_Tornilleria
    Private objOpsimpesLn As New Op_simpesLn
    Dim numero_transaccion As Double
    Dim objTraslado_bodLn As New traslado_bodLn
    Private objOrdenProdLn As New OrdenProdLn
    Private obj_Ing_prodLn As New Ing_prodLn

    Private Sub cargar_cbo()
        Dim sql As String
        Dim dt As New DataTable
        Dim row As DataRow
        sql = "SELECT codigo from referencias_tornilleria"
        dt = objOpsimpesLn.listar_datatable(sql, "CORSAN")
        row = dt.NewRow
        row("codigo") = 0
        row("codigo") = "Seleccione"
        dt.Rows.Add(row)

        cbo_Referencia_Final.DataSource = dt
        cbo_Referencia_Final.ValueMember = "codigo"
        cbo_Referencia_Final.DisplayMember = "codigo"
        cbo_Referencia_Final.SelectedValue = 0
    End Sub
    Private Sub btn_Realizar_Trans_Click(sender As Object, e As EventArgs) Handles btn_Realizar_Trans.Click
        If validar_campos() Then
            Dim peso As String = txt_kilos.Text
            Dim listSql As New List(Of Object)
            Dim codigo_prod As String = cbo_Referencia_Final.Text
            Dim cod_mp As String = "2R" & codigo_prod.Substring(2)
            Dim sql As String = ""
            Dim dt As New DataTable
            dt.Columns.Add("codigo")
            dt.Columns.Add("cantidad")
            dt.Rows.Add()
            dt.Rows(dt.Rows.Count - 1).Item("codigo") = ""
            dt.Rows(dt.Rows.Count - 1).Item("cantidad") = peso
            listSql.AddRange(transaccion_consumo(dt, "STP", 2, 1))
            listSql.AddRange(transaccion_consumo(dt, "EAI2", 2, 1))
            If obj_Ing_prodLn.ExecuteSqlTransaction(listSql, "CORSAN") Then
                MessageBox.Show("Transacción realizada", "Transacción realizada", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("No se hicieron las transacciones", "Transacción no realizada", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
    End Sub
    Private Function validar_campos()
        Dim resp As Boolean = False
        If cbo_Referencia_Final.Text <> "Seleccione" And cbo_Referencia_Final.Text <> "" Then
            If txt_kilos.Text <> "" Then
                If CInt(txt_kilos.Text) > 0 Then
                    resp = True
                Else
                    MessageBox.Show("Debe ser mayor 0 los kilos", "Ingresar codigos", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                MessageBox.Show("Se debe ser ingresar los kilos", "Ingresar codigos", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            MessageBox.Show("No se ha seleccionado referencia", "Seleccionar referencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Return resp
    End Function
    Private Function transaccion_consumo(ByVal datacodigo As DataTable, ByVal tipo As String, ByVal bodega As Integer, ByVal modelo As String) As List(Of Object)
        Dim listSql As New List(Of Object)
        Dim dFec As Date = Now
        Dim notas As String = "SPIC fecha:" & Now
        numero_transaccion = objOrdenProdLn.mover_consecutivo(tipo)
        listSql = objTraslado_bodLn.listaTransaccionDatable(numero_transaccion, datacodigo, bodega, dFec, notas, "tornilleria", tipo, modelo)
        Return listSql
    End Function
    Private Function transaccion_entrada(ByVal datacodigo As DataTable, ByVal tipo As String, ByVal bodega As Integer, ByVal modelo As String) As List(Of Object)
        Dim listSql As New List(Of Object)
        Dim dFec As Date = Now
        Dim notas As String = "SPIC fecha:" & Now
        numero_transaccion = objOrdenProdLn.mover_consecutivo(tipo)
        listSql = objTraslado_bodLn.listaTransaccionDatable(numero_transaccion, datacodigo, bodega, dFec, notas, "tornilleria", tipo, modelo)
        Return listSql
    End Function
    Private Sub frm_Consumo_Tornilleria_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargar_cbo()
    End Sub
End Class