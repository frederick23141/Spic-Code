Imports logicaNegocios

Public Class Frm_consultar_pulim
    Private fecIni As String = ""
    Private fecFin As String = ""
    Private objOpSimplesLn As New Op_simpesLn
    Private objIngPulimientoLn As New Ing_pulimientoLn
    Private obj_Ing_prodLn As New Ing_prodLn
    Private cargaComp As Boolean = False
    Private objOperacionesForm As New OperacionesFormularios
    Private Sub Frm_consultar_pulim_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cbo_fecha_ini.Value = Now.AddDays(-1)
        cbo_fecha_fin.Value = Now.AddDays(-1)
        fecIni = objOpSimplesLn.cambiarFormatoFecha(cbo_fecha_ini.Value)
        fecFin = objOpSimplesLn.cambiarFormatoFecha(cbo_fecha_fin.Value)
        cargarOperarios()
        cargarMaquinas()
        cbo_operario.SelectedValue = 0
        cbo_maquina.SelectedValue = 0
        cargarConsulta()
        cargaComp = True
    End Sub
    Private Sub cargarMaquinas()
        Dim dt As New DataTable
        Dim dr As DataRow
        dt = obj_Ing_prodLn.listarMaquinas("2,3")
        dr = dt.NewRow
        dr("codigoM") = 0
        dr("nombre") = "TODO"
        dt.Rows.Add(dr)
        cbo_maquina.DataSource = dt
        cbo_maquina.ValueMember = "codigoM"
        cbo_maquina.DisplayMember = "nombre"
        cbo_maquina.Text = "Seleccione"
    End Sub
    Private Sub cargarOperarios()
        Dim dt As New DataTable
        Dim dr As DataRow
        dt = obj_Ing_prodLn.listarOperarios(2300)
        dr = dt.NewRow
        dr("nit") = 0
        dr("nombres") = "TODO"
        dt.Rows.Add(dr)
        cbo_operario.DataSource = dt
        cbo_operario.ValueMember = "nit"
        cbo_operario.DisplayMember = "nombres"
        cbo_operario.Text = "Seleccione"
    End Sub
    Private Sub cargarConsulta()
        Dim operario As String = cbo_operario.SelectedValue
        Dim maquina As String = cbo_maquina.SelectedValue
        Dim tipo As New List(Of Object)
        Dim dt As New DataTable
        If (chk_consol_op.Checked = False And chkConsolMaq.Checked = False And chkConsolTurno.Checked = False And chkReferencia.Checked = False) Then
            dt = objIngPulimientoLn.consultarInforme(operario, maquina, fecIni, fecFin)
        Else
            If (chk_consol_op.Checked) Then
                tipo.Add("operario")
            End If
            If (chkConsolMaq.Checked) Then
                tipo.Add("maquina")
            End If
            If (chkConsolTurno.Checked) Then
                tipo.Add("turno")
            End If
            If (chkReferencia.Checked) Then
                tipo.Add("referencia")
            End If
            dt = objIngPulimientoLn.consolidarConsulta(tipo, operario, maquina, fecIni, fecFin)
        End If
        dt.Rows.Add()
        dtg_consulta.DataSource = dt
        eficiencias()
        totalisarGrid()
        If (chk_consol_op.Checked = False And chkConsolMaq.Checked = False And chkConsolTurno.Checked = False And chkReferencia.Checked = False) Then
            dtg_consulta.Columns("fecha").DefaultCellStyle.Format = "d"
        End If
     
    End Sub
    Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
        If (cargaComp) Then
            cargarConsulta()
        End If
    End Sub
    Private Sub cbo_operario_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_operario.SelectedIndexChanged
        If (cargaComp) Then
            cargarConsulta()
        End If
    End Sub
    Private Sub eficiencias()
        If (chk_consol_op.Checked = False And chkConsolMaq.Checked = False And chkConsolTurno.Checked = False And chkReferencia.Checked = False) Then
            Dim turno As Integer = 0
            Dim swEntro As Boolean = False
            Dim esperadaTurno As Double = 0
            Dim prodTurno As Double = 0
            Dim idAnt As Double = 0
            Dim efic As Double = 0
            For i = 0 To dtg_consulta.RowCount - 2
                If (idAnt <> dtg_consulta.Item("id", i).Value) Then
                    turno = dtg_consulta.Item("codTurno", i).Value
                    esperadaTurno = objIngPulimientoLn.kilEsperados(turno)
                    prodTurno = sumarProdPlanilla(dtg_consulta.Item("id", i).Value)
                    efic = objIngPulimientoLn.calcEficiencia(prodTurno, esperadaTurno)
                    idAnt = dtg_consulta.Item("id", i).Value
                End If
                dtg_consulta.Item("colEfic", i).Value = efic
            Next
        End If
    End Sub
    Private Function sumarProdPlanilla(ByVal idPlanilla As String) As Double
        Dim sum As Double = 0
        For i = 0 To dtg_consulta.RowCount - 2
            If (dtg_consulta.Item("id", i).Value = idPlanilla) Then
                sum += dtg_consulta.Item("kilos", i).Value
            ElseIf (sum <> 0) Then
                i = dtg_consulta.RowCount - 1
            End If
        Next
        Return sum
    End Function
    Private Sub cbo_maquina_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_maquina.SelectedIndexChanged
        If (cargaComp) Then
            cargarConsulta()
        End If
    End Sub

    Private Sub cbo_fecha_ini_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_fecha_ini.ValueChanged
        If (cargaComp) Then
            fecIni = objOpSimplesLn.cambiarFormatoFecha(cbo_fecha_ini.Value)
            cargarConsulta()
        End If
    End Sub

    Private Sub cbo_fecha_fin_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_fecha_fin.ValueChanged
        If (cargaComp) Then
            fecFin = objOpSimplesLn.cambiarFormatoFecha(cbo_fecha_fin.Value)
            cargarConsulta()
        End If
    End Sub

    Private Sub chkConsolTurno_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkConsolTurno.CheckedChanged
        If (cargaComp) Then
            cargarConsulta()
        End If
    End Sub

    Private Sub chk_consol_op_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_consol_op.CheckedChanged
        If (cargaComp) Then
            cargarConsulta()
        End If
    End Sub

    Private Sub chkConsolMaq_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkConsolMaq.CheckedChanged
        If (cargaComp) Then
            cargarConsulta()
        End If
    End Sub
    Private Sub totalisarGrid()
        Dim sum As Double = 0
        dtg_consulta.Rows(dtg_consulta.RowCount - 1).DefaultCellStyle.BackColor = Color.Red
        For i = 0 To dtg_consulta.RowCount - 2
            sum += dtg_consulta.Item("kilos", i).Value
        Next
        dtg_consulta.Item("kilos", dtg_consulta.RowCount - 1).Value = sum
    End Sub
    Private Sub chkReferencia_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkReferencia.CheckedChanged
        If (cargaComp) Then
            cargarConsulta()
        End If
    End Sub
    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        FrmPrincipal.Show()
        Me.Close()
        FrmPrincipal.Activate()
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        FrmLogin.Show()
        FrmPrincipal.Close()
        Me.Close()
    End Sub
    Private Sub btn_excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_excel.Click
        objOperacionesForm.ExportarDatosExcel(dtg_consulta, "Pulimiento(tambores)")
    End Sub

End Class

