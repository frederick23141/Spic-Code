Imports logicaNegocios
Imports entidadNegocios
Public Class Frm_Reporte_produccion
    Dim objIngresoProdLn As New Ing_prodLn
    Private objOpSimplesLn As New Op_simpesLn
    Private objOperacionesForm As OperacionesFormularios = New OperacionesFormularios

    Private Sub Reporte_produccion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cboturno1.Text = "1"
        cboturno2.Text = "3"
        cargar_datasource()
    End Sub
    Public Sub cargar_datasource()
        Dim sql As String
        Dim dt As New DataTable
        Dim dr As DataRow
        dt = New DataTable

        sql = "SELECT CONVERT(varchar,Calibre) as Calibre  FROM Jjv_plc_produccion GROUP BY Calibre"
        dt = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        dr = dt.NewRow
        dt.Rows.Add(dr)
        dr("Calibre") = -1
        dr("Calibre") = "TODO"
        cbocalibre.DataSource = dt
        cbocalibre.ValueMember = "Calibre"
        cbocalibre.DisplayMember = "Calibre"
        cbocalibre.Text = "Seleccione"
        cbocalibre.SelectedValue = -1


        dt = New DataTable
        sql = "SELECT CONVERT(varchar,nro_bobina) as nro_bobina  FROM D_Bobina_Devanador"
        dt = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")
        dr = dt.NewRow
        dr("nro_bobina") = -1
        dr("nro_bobina") = "TODO"
        dt.Rows.Add(dr)
        cbobobina.DataSource = dt
        cbobobina.ValueMember = "nro_bobina"
        cbobobina.DisplayMember = "nro_bobina"
        cbobobina.Text = "Seleccione"
        cbobobina.SelectedValue = -1


    End Sub
    Public Sub cargar_consulta()
        Dgvbobina.DataSource = Nothing
        Dim fecIni As String = objOpSimplesLn.cambiarFormatoFecha(cboFechaIni.Value)
        Dim fecFin As String = objOpSimplesLn.cambiarFormatoFecha(cboFechaFin.Value)
        Dim calibre As String = cbocalibre.SelectedValue
        Dim turno1 As String = Cboturno1.Text
        Dim turno2 As String = cboturno2.Text
        Dim bobina As String = cbobobina.SelectedValue
        Dim dt As New DataTable
        Dim sql As String
        Dim selectd As String = ""
        Dim group As String = " group by Motor,Calibre,Turno ORDER BY Motor asc"
        Dim where As String
        where = " where Fecha >= '" & fecIni & "' AND Fecha <= '" & fecFin & "'"

        If chkcalibre.Checked = True Then
            selectd = "select Calibre,sum(Kilos) as kilos"
            group = "group by Calibre"
        End If
        If chkbobina.Checked = True Then
            selectd = "select Motor,sum(Kilos) as kilos"
            group = "group by Motor"
        End If
        If calibre <> "" And calibre <> "TODO" And calibre <> "-1" Then
            where += " AND Calibre=" & calibre & ""
        End If
        If Cboturno1.Text <> "" And cboturno2.Text <> "" Then
            where += " And turno >= '" & turno1 & "' And turno <= '" & turno2 & "'"
        End If
        If bobina <> "" And bobina <> "TODO" And bobina <> "-1" Then
            where += "  AND Motor=" & bobina & ""
        End If
        If selectd = "" Then
            selectd = "SELECT Motor,Calibre,Turno,sum(Kilos) as kilos"
        End If
        sql = selectd & " FROM Jjv_plc_produccion" & where & group
        dt = objIngresoProdLn.listar_datatable(sql, "CORSAN")
        Dgvbobina.DataSource = dt
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

    Private Sub Cboturno1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cboturno1.SelectedIndexChanged
        cargar_consulta()
    End Sub

    Private Sub cboturno2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboturno2.SelectedIndexChanged
        cargar_consulta()
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkbobina.CheckedChanged
        If chkbobina.Checked = True Then
            chkcalibre.Checked = False
        End If
    End Sub

    Private Sub chkcalibre_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkcalibre.CheckedChanged
        If chkcalibre.Checked = True Then
            chkbobina.Checked = False
        End If
    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        Me.UseWaitCursor = True
        Application.DoEvents()
        objOperacionesForm.exportarExcel(Dgvbobina)
        Me.UseWaitCursor = False
    End Sub
End Class