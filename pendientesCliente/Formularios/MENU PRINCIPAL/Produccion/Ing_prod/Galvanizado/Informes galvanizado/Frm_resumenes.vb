Imports logicaNegocios
Imports entidadNegocios
Public Class Frm_resumenes
    Dim objIngresoProdLn As New Ing_prodLn
    Private objOpSimplesLn As New Op_simpesLn
    Private objOperacionesForm As OperacionesFormularios = New OperacionesFormularios
    Private Sub Frm_resumenes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargardatasource()
        cargar_consulta()
    End Sub
    Public Sub cargar_consulta()
        Dgvbobina.DataSource = Nothing
      
        Dim fecIni As String = objOpSimplesLn.cambiarFormatoFecha(cboFechaIni.Value)
        Dim fecFin As String = objOpSimplesLn.cambiarFormatoFecha(cboFechaFin.Value)
        Dim bobina As String = cbobobina.SelectedValue
        Dim dt As New DataTable
        Dim sql As String
        Dim selectd As String = ""
        Dim group As String = "Order by Motor "
        Dim where As String
        where = " where Fecha >= '" & fecIni & "' AND Fecha <= '" & fecFin & "'"

        If chkbobina.Checked = True Then
            selectd = "select Motor,sum(Kilos) as Kilos,sum(TiempoProductivo) as Tiempoproductivo,sum(Paros) as Paros,Sum(Eficiencia) as Eficiencia"
            group = "group by Motor Order by Motor"
        End If
        If selectd = "" Then
            selectd = "SELECT Fecha,Motor,Kilos,TiempoProductivo,Paros,Eficiencia"
        End If
        If bobina <> "" And bobina <> "TODO" And bobina <> "-1" Then
            where += "  AND Motor=" & bobina & ""
        End If
        sql = selectd & " FROM Jjv_plc_resumen_kgs_tiempo" & where & group
        dt = objIngresoProdLn.listar_datatable(sql, "CORSAN")
        Dgvbobina.DataSource = dt
        Exit Sub
    End Sub
    Private Sub cargardatasource()
        Dim sql As String
        Dim dt As New DataTable
        Dim dr As DataRow
        dt = New DataTable
        dt = New DataTable

        sql = "SELECT CONVERT(varchar,nro_bobina) as nro_bobina  FROM D_Bobina_Devanador"
        dt = objOpSimplesLn.listar_datatable(Sql, "PRODUCCION")
        dr = dt.NewRow
        dr("nro_bobina") = -1
        dr("nro_bobina") = "TODO"
        dt.Rows.Add(dr)
        cbobobina.DataSource = dt
        cbobobina.ValueMember = "nro_bobina"
        cbobobina.DisplayMember = "nro_bobina"
        cbobobina.Text = "Seleccione"
        cbobobina.SelectedValue = -1
        cboFechaIni.Value = DateTime.Now
        cboFechaFin.Value = DateTime.Now
       
    End Sub
    Private Sub btnActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActualizar.Click
        cargar_consulta()
    End Sub

    Private Sub cboFechaIni_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFechaIni.ValueChanged
        cargar_consulta()
    End Sub

    Private Sub cboFechaFin_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFechaFin.ValueChanged
        cargar_consulta()
    End Sub
    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        Me.UseWaitCursor = True
        Application.DoEvents()
        objOperacionesForm.exportarExcel(Dgvbobina)
        Me.UseWaitCursor = False
    End Sub
End Class