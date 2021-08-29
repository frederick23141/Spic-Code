Imports entidadNegocios
Imports logicaNegocios
Public Class frm_aud_mp_tref_rec
    Private objOpSimplesLn As New Op_simpesLn
    Private objOperacionesForm As New OperacionesFormularios
    Private Sub frm_aud_mp_tref_rec_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Private Sub btn_consulta_Click(sender As Object, e As EventArgs) Handles btn_consulta.Click
        cargarConsulta()
    End Sub
    'Carga la informacion de los rollos de recocido para materia prima o consumidos
    Private Sub cargarConsulta()
        Dim sql As String = ""
        Dim where As String = ""
        Dim group As String = ""
        Dim sqlWhere As String = ""
        Dim codigo As String = txtCodigo.Text
        
        If chk_consolidar.Checked Then
            If rdb_bodega.Checked Then
                sql = "SELECT prod_final,descripcion,sum(peso) as Kilos" & _
                       " FROM JB_v_rollos_rec_mp"

            Else
                sql = "SELECT  prod_final,descripcion,sum (peso) as Kilos" & _
                       " FROM JB_v_rollos_rec_mp_consumida"

            End If
        Else
            If rdb_bodega.Checked Then
                sql = "SELECT consecutivo,peso,tipo_trans,trans,prod_final,descripcion,fecha" & _
                       " FROM JB_v_rollos_rec_mp"
            Else
                sql = "SELECT consecutivo,peso,tipo_trans,trans,prod_final,descripcion,fecha_eppp,scae,fecha_scae " & _
                      " FROM JB_v_rollos_rec_mp_consumida "
            End If
        End If
        If codigo <> "" Then
            where = " where prod_final LIKE '%" & codigo & "%' "
        End If
        If chk_consolidar.Checked Then
            group = " GROUP BY prod_final,descripcion"
        End If
        sqlWhere = sql + where + group
        dtg_consulta.DataSource = objOpSimplesLn.listar_datatable(sqlWhere, "PRODUCCION")
        If chk_consolidar.Checked Then
            totalizar()
        End If
    End Sub
    Private Sub totalizar()
        Dim tot As Double
        'crea variable para estilo de texto
        Dim style As New DataGridViewCellStyle()
        style.Font = New Font(dtg_consulta.Font, FontStyle.Bold)

        'Recorre columna de data grid view
        For Each row As DataGridViewRow In dtg_consulta.Rows
            tot += row.Cells("Kilos").Value
        Next

        Dim dt As DataTable = CType(Me.dtg_consulta.DataSource, DataTable)

        ' Creamos una nueva fila y cumplimentamos
        ' los valores de sus campos.
        '
        Dim dr As DataRow = dt.NewRow
        With dr
            .Item("descripcion") = "TOTAL"
            .Item("kilos") = tot
        End With

        ' Añadimos la fila al objeto DataTable.
        '
        dt.Rows.Add(dr)
        dtg_consulta.Rows(dtg_consulta.Rows.Count - 1).DefaultCellStyle = style
        dtg_consulta.Rows(dtg_consulta.Rows.Count - 1).DefaultCellStyle.BackColor = Color.Salmon
 End Sub
    Private Sub btn_excel_Click(sender As Object, e As EventArgs) Handles btn_excel.Click
        If dtg_consulta.RowCount = 0 Then
            MessageBox.Show("No se puede exportar ya que no hay información", "No hay información", MessageBoxButtons.OK)
        Else
            objOperacionesForm.ExportarDatosExcel(dtg_consulta, "Auditoria MP tref-rec")
        End If
    End Sub
    'CARGA CONSULTA Y FILTRA POR CODIGO
    Private Sub txtCodigo_TextChanged(sender As Object, e As EventArgs) Handles txtCodigo.TextChanged
        cargarConsulta()
    End Sub
End Class