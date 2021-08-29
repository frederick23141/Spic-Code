Imports logicaNegocios
Imports System.Data.SqlClient
Public Class frm_consulta_desp_punt
    Private obj_Ing_prodLn As New Ing_prodLn
    Private Sub frm_consulta_desp_punt_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtg_consulta.DataSource = Nothing
        consultar()
    End Sub
    Private Sub consultar()
        Dim mes As Integer = Now.Month
        Dim ano As Integer = Now.Year

        Dim sql As String = " SELECT id,fecha,nit,nombres,centro,desc_centro,defecto,causal,kilos,tipo,desc_tipo,observaciones,fecha_ingreso,codigo_ref,(select nombre FROM J_maquinas where codigoM=cod_maq) as maquina,turno FROM J_v_desperdicios WHERE anulado IS NULL AND month(fecha) = '" & mes & "' AND year(fecha) = '" & ano & "' AND centro = 2300 ORDER BY nombres"
        Dim dt As DataTable = obj_Ing_prodLn.listar_datatable(sql, "PRODUCCION")

        totalizar(dt)
        dtg_consulta.DataSource = dt
        dtg_consulta.Columns("fecha").DefaultCellStyle.Format = "d"
        dtg_consulta.Columns("kilos").DefaultCellStyle.Format = "N1"
        dtg_consulta.Columns("fecha_ingreso").DefaultCellStyle.Format = "g"
    End Sub
    Private Sub totalizar(ByVal dt_consulta As DataTable)
        Dim sum As Double = 0
        Dim col As String = ""
        dt_consulta.Rows.Add()
        For j = 0 To dt_consulta.Columns.Count - 1
            If (dt_consulta.Columns(j).ColumnName = "kilos" Or dt_consulta.Columns(j).ColumnName = "presupuesto") Then
                For i = 0 To dt_consulta.Rows.Count - 2
                    If IsNumeric(dt_consulta.Rows(i).Item(j)) Then
                        sum += dt_consulta.Rows(i).Item(j)
                    End If
                Next
                dt_consulta.Rows(dt_consulta.Rows.Count - 1).Item(j) = sum
                sum = 0
            End If
        Next
    End Sub
End Class