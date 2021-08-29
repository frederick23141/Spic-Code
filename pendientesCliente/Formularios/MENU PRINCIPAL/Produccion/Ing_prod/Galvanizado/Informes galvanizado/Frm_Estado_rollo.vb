Imports logicaNegocios
Imports entidadNegocios
Public Class Frm_Estado_de_rollo
    Dim objIngresoProdLn As New Ing_prodLn
    Private objOperacionesForm As OperacionesFormularios = New OperacionesFormularios
    Private Sub Frm_Estado_de_rollo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        chkbodega11.Checked = True
    End Sub
    Public Sub cargarconsulta(ByVal code As String)
        dtgconsulta.DataSource = Nothing
        Dim dt As New DataTable
        Dim codigo As String = code
        Dim sql As String
        Dim where As String
        Dim from As String = "  FROM J_rollos_tref  R , J_orden_prod_tef O,J_det_orden_prod D"
        Dim selectt As String
        Dim groupby As String = ""
        Dim dt_galv As New DataTable
        If chkbodega2.Checked = True Then
            selectt = "SELECT R.cod_orden,R.id_detalle,R.id_rollo,R.peso,O.prod_final As codigo,D.fecha_prod,R.traslado,R.saga,R.destino,R.scla"
            where = " WHERE O.consecutivo = D.cod_orden And R.id_detalle = D.id_detalle And R.cod_orden = O.consecutivo And R.traslado Is NULL And R.saga Is NULL"
        ElseIf chkbodega11.Checked = True Then
            selectt = "SELECT R.cod_orden,R.id_detalle,R.id_rollo,R.peso,O.prod_final As codigo,D.fecha_prod,R.traslado,R.saga,R.destino,R.scla"
            where = " WHERE O.consecutivo = D.cod_orden And R.id_detalle = D.id_detalle And R.cod_orden = O.consecutivo And R.traslado IS not NULL And R.saga Is NULL AND R.destino='G'"
        ElseIf chkbodega11c.Checked = True Then
            selectt = "SELECT R.cod_orden,R.id_detalle,R.id_rollo,R.peso,O.prod_final As codigo,D.fecha_prod,R.traslado,R.saga,R.destino,R.scla"
            where = " WHERE O.consecutivo = D.cod_orden And R.id_detalle = D.id_detalle And R.cod_orden = O.consecutivo And R.traslado IS not NULL And R.saga Is not NULL"
        ElseIf chk_b12.Checked = True Then
            Dim select_gavl As String = ""
            Dim where_galv As String = "WHERE R.nro_orden = E.consecutivo_orden_G AND R.traslado IS NOT NULL and R.destino = 'P' and R.saga is null "
            If codigo <> "" Then
                where_galv &= " And  E.final_galv  LIKE'%" & code & "%'"
            End If
            If chkcodigo.Checked = True Then
                select_gavl = "SELECT E.final_galv As codigo ,SUM( R.peso) As peso  " &
                            "FROM D_rollo_galvanizado_f R , D_orden_pro_galv_enc E " &
                                where_galv &
                                    "GROUP BY E.final_galv"
            Else
                select_gavl = "SELECT R.nro_orden,R.fecha_hora ,R.consecutivo_rollo , E.final_galv As codigo , R.peso, R.destino, R.fecha_hora,R.traslado " &
                                            "FROM D_rollo_galvanizado_f R , D_orden_pro_galv_enc E " &
                                                  where_galv
            End If
            dt_galv = objIngresoProdLn.listar_datatable(select_gavl, "PRODUCCION")
            selectt = "SELECT R.cod_orden,R.id_detalle,R.id_rollo,R.peso,O.prod_final As codigo,D.fecha_prod,R.traslado,R.saga,R.destino,R.scla"
            where = " WHERE O.consecutivo = D.cod_orden And R.id_detalle = D.id_detalle And R.cod_orden = O.consecutivo And R.traslado IS not NULL And R.scla Is  NULL AND R.destino = 'P' "
        End If
        If codigo <> "" Then
#Disable Warning BC42104 ' La variable 'where' se usa antes de que se le haya asignado un valor. Podría darse una excepción de referencia NULL en tiempo de ejecución.
            where &= " And O.prod_final LIKE'%" & code & "%'"
#Enable Warning BC42104 ' La variable 'where' se usa antes de que se le haya asignado un valor. Podría darse una excepción de referencia NULL en tiempo de ejecución.
        End If
        If chkcodigo.Checked = True Then
            selectt = " select O.prod_final As codigo,SUM(R.peso) as peso"
            groupby = " group by O.prod_final"
        End If
#Disable Warning BC42104 ' La variable 'selectt' se usa antes de que se le haya asignado un valor. Podría darse una excepción de referencia NULL en tiempo de ejecución.
        sql = selectt & from & where & groupby
#Enable Warning BC42104 ' La variable 'selectt' se usa antes de que se le haya asignado un valor. Podría darse una excepción de referencia NULL en tiempo de ejecución.
        dt = objIngresoProdLn.listar_datatable(sql, "PRODUCCION")
        For i = 0 To dt_galv.Rows.Count - 1
            dt.Rows.Add()
            dt.Rows(dt.Rows.Count - 1).Item("codigo") = dt_galv.Rows(i).Item("codigo")
            dt.Rows(dt.Rows.Count - 1).Item("peso") = dt_galv.Rows(i).Item("peso")
            If chkcodigo.Checked = False Then
                dt.Rows(dt.Rows.Count - 1).Item("cod_orden") = dt_galv.Rows(i).Item("nro_orden")
                dt.Rows(dt.Rows.Count - 1).Item("id_rollo") = dt_galv.Rows(i).Item("consecutivo_rollo")
                dt.Rows(dt.Rows.Count - 1).Item("destino") = dt_galv.Rows(i).Item("destino")
                dt.Rows(dt.Rows.Count - 1).Item("fecha_prod") = dt_galv.Rows(i).Item("fecha_hora")
                dt.Rows(dt.Rows.Count - 1).Item("traslado") = dt_galv.Rows(i).Item("traslado")
            End If
        Next
        dt.Rows.Add()
        totalizarDt(dt)
        dtgconsulta.DataSource = dt
        dtgconsulta.Columns("peso").DefaultCellStyle.Format = "n0"

        'For Each Row As DataGridViewRow In dtgconsulta.Rows
        '    If IsDBNull(Row.Cells("traslado").Value) = True And IsDBNull(Row.Cells("saga").Value) = True Then
        '        Row.DefaultCellStyle.BackColor = Color.MediumPurple
        '    End If
        '    If IsDBNull(Row.Cells("traslado").Value) = False And IsDBNull(Row.Cells("saga").Value) = True Then
        '        Row.DefaultCellStyle.BackColor = Color.LimeGreen
        '    End If
        '    If IsDBNull(Row.Cells("saga").Value) = False Then
        '        Row.DefaultCellStyle.BackColor = Color.LightSteelBlue
        '    End If
        '    If IsDBNull(Row.Cells("destino").Value) = False Then
        '        If IsDBNull(Row.Cells("scla").Value) And Row.Cells("destino").Value = "P" Then
        '            Row.DefaultCellStyle.BackColor = Color.DarkOrange
        '        End If
        '    End If
        'Next

    End Sub
    Private Sub btnActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActualizar.Click
        cargarconsulta(txtNumero.Text)
    End Sub
    Private Sub totalizarDt(ByRef dt As DataTable)
        Dim sum As Double = 0
        For j = 1 To dt.Columns.Count - 1
            If dt.Columns(j).ColumnName = "peso" Then
                For i = 0 To dt.Rows.Count - 1
                    If Not IsDBNull(dt.Rows(i).Item(j)) Then
                        If IsNumeric(dt.Rows(i).Item(j)) Then
                            sum += dt.Rows(i).Item(j)
                        End If
                    End If
                Next
                dt.Rows(dt.Rows.Count - 1).Item(j) = sum
                sum = 0
            End If
        Next
    End Sub
    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        Me.UseWaitCursor = True
        Application.DoEvents()
        objOperacionesForm.exportarExcel(dtgconsulta)
        Me.UseWaitCursor = False
    End Sub

    Private Sub chkbodega2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkbodega2.CheckedChanged
        If chkbodega2.Checked = True Then
            chkbodega11.Checked = False
            chk_b12.Checked = False
            chkbodega11c.Checked = False
        End If
    End Sub
    Private Sub chkbodega11_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkbodega11.CheckedChanged
        If chkbodega11.Checked = True Then
            chkbodega2.Checked = False
            chkbodega11c.Checked = False
            chk_b12.Checked = False
        End If
    End Sub
    Private Sub chkbodega11c_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkbodega11c.CheckedChanged
        If chkbodega11c.Checked = True Then
            chkbodega2.Checked = False
            chkbodega11.Checked = False
            chk_b12.Checked = False
        End If
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Me.Close()
    End Sub

    Private Sub txtNumero_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNumero.TextChanged
        cargarconsulta(txtNumero.Text)
    End Sub

    Private Sub chk_b12_CheckedChanged(sender As Object, e As EventArgs) Handles chk_b12.CheckedChanged
        If chk_b12.Checked = True Then
            chkbodega2.Checked = False
            chkbodega11.Checked = False
            chkbodega11c.Checked = False
        End If
    End Sub
End Class