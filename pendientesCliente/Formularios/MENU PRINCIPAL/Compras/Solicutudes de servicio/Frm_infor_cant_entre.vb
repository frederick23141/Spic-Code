Imports logicaNegocios
Imports entidadNegocios
Imports accesoDatos
Public Class Frm_infor_cant_entre
    Private objOpSimplesLn As New Op_simpesLn
    Private objOperacionesForm As New OperacionesFormularios
    Private Sub Frm_infor_cant_entre_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargar_Consulta()
    End Sub
    Private Sub cargar_Consulta()
        Dim sql As String
        Dim dt As DataTable
        Dim fecIni As String = objOpSimplesLn.cambiarFormatoFecha(cboFechaIni.Value)
        Dim fecFin As String = objOpSimplesLn.cambiarFormatoFecha(cboFechaFin.Value)
        sql = "select e.numero,e.fecha_solicitud,d.descripcion_solicitante as referencia,d.cantidad_aut,d.entregado as cantidad_regresada,(d.cantidad_aut-d.entregado) as cant_falt " &
            " from J_solicitud_compra_enc e join J_solicitud_compra_det d on e.numero=d.numero" &
             " where e.fecha_solicitud >= '" & fecIni & "' and e.fecha_solicitud <= '" & fecFin & "' and (d.descripcion_solicitante like '2c%' or d.descripcion_solicitante like '2t%'  or d.descripcion_solicitante like '2g%')"
        dt = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")
        dtg_cantidad.DataSource = dt
        dtg_cantidad.DataSource = totalizar_cartera()
        pintartotal()
    End Sub
    Private Function totalizar_cartera()
        Dim autorizada As Double = 0
        Dim entregada As Double = 0
        Dim diferencia As Double
        Dim indice As Integer = 0

        Dim dt As DataTable = DirectCast(dtg_cantidad.DataSource, DataTable)
        For Each row As DataRow In dt.Rows
            If row.Item("cantidad_aut") >= 0 Then
                autorizada += row.Item("cantidad_aut")
            End If
            If row.Item("cantidad_regresada") >= 0 Then
                entregada += row.Item("cantidad_regresada")
            End If
            If row.Item("cant_falt") >= 0 Then
                diferencia += row.Item("cant_falt")
            End If
            If indice = (dt.Rows.Count - 1) Then
                dt.Rows.Add()
                dt.Rows(dt.Rows.Count - 1).Item("referencia") = "TOTAL"
                dt.Rows(dt.Rows.Count - 1).Item("cantidad_aut") = autorizada
                dt.Rows(dt.Rows.Count - 1).Item("cantidad_regresada") = entregada
                dt.Rows(dt.Rows.Count - 1).Item("cant_falt") = diferencia
                Exit For
            End If
            indice += 1
        Next
        Return dt
    End Function
    Public Sub pintartotal()
        If dtg_cantidad.Rows.Count > 0 Then
            dtg_cantidad.Rows(dtg_cantidad.Rows.Count - 1).DefaultCellStyle.BackColor = Color.Salmon
            dtg_cantidad.Rows(dtg_cantidad.Rows.Count - 1).DefaultCellStyle.Font = New Font(dtg_cantidad.CurrentCell.InheritedStyle.Font, FontStyle.Bold)
        End If
    End Sub
    Private Sub btn_cargar_Click(sender As Object, e As EventArgs) Handles btn_cargar.Click
        cargar_Consulta()
    End Sub
    Private Sub btnexcel_Click(sender As Object, e As EventArgs) Handles btnexcel.Click
        If dtg_cantidad.RowCount > 0 Then
            objOperacionesForm.ExportarDatosExcel(dtg_cantidad, "cant autorizada vs cant entregada ")
        Else
            MessageBox.Show("No hay información que exportar", "Exportar a excel", MessageBoxButtons.OK)
        End If
    End Sub
End Class