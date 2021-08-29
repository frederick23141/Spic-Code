Imports System.Configuration
Imports logicaNegocios
Imports System.IO
Imports Microsoft.Office.Interop
#Disable Warning BC40056 ' El espacio de nombres o el tipo especificado en el 'System.Data.SqlServerCe' Imports no contienen ningún miembro público o no se encuentran. Asegúrese de que el espacio de nombres o el tipo se hayan definido y de que contengan al menos un miembro público. Asegúrese de que el nombre del elemento importado no use ningún alias.
Imports System.Data.SqlServerCe
#Enable Warning BC40056 ' El espacio de nombres o el tipo especificado en el 'System.Data.SqlServerCe' Imports no contienen ningún miembro público o no se encuentran. Asegúrese de que el espacio de nombres o el tipo se hayan definido y de que contengan al menos un miembro público. Asegúrese de que el nombre del elemento importado no use ningún alias.
Public Class FrmIngProdPulimiento
    Private objOpSimplesLn As New Op_simpesLn
    Private obj_Ing_prodLn As New Ing_prodLn
    Private objIngPulimientoLn As New Ing_pulimientoLn
    Private cargaComp As Boolean = False
    Private esperadaTurno As Double = 0
    Private prodTurno As Double = 0
    Private nom_modulo As String
    Public Sub Main(ByVal nom_modulo As String, ByVal permiso As String)
        Me.nom_modulo = nom_modulo
        If (permiso <> "ADMIN") Then
            btnContCambios.Visible = False
        End If
    End Sub
    Private Sub btnContCambios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnContCambios.Click
        FrmAuditCambios.Show()
        FrmAuditCambios.Main(nom_modulo)
        FrmAuditCambios.WindowState = 2
    End Sub
    Private Sub Ing_prod_pulimiento_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargarOperarios(2300)
        cbo_fecha.Value = Now.AddDays(-1)
        cbo_turno.DataSource = obj_Ing_prodLn.listarTurnos()
        cbo_turno.ValueMember = "Codigo"
        cbo_turno.DisplayMember = "Descripcion"
        cbo_turno.Text = "Seleccione"
        cargarDtg()
        cargaComp = True
    End Sub

    Private Sub chk_todos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_todos.CheckedChanged
        If (chk_todos.Checked = True) Then
            cargarOperarios("todos")
        Else
            cargarOperarios(2300)
        End If

    End Sub
    Private Sub cargarOperarios(ByVal centro As String)
        If (centro = "2300") Then
            cbo_operario.DataSource = obj_Ing_prodLn.listarOperarios(2300)
        Else
            cbo_operario.DataSource = obj_Ing_prodLn.listarOperarios("todos")
        End If
        cbo_operario.ValueMember = "nit"
        cbo_operario.DisplayMember = "nombres"
        cbo_operario.Text = "Seleccione"
    End Sub
    Private Sub cargarDtg()
        Dim dt As New DataTable
        dt = obj_Ing_prodLn.listarMaquinas("2,3")
        Dim row As DataRow
        row = dt.NewRow
        row("codigoM") = 0
        row("nombre") = ""
        dt.Rows.Add(row)
        cboMaquinaT1.DataSource = dt
        cboMaquinaT1.ValueMember = "codigoM"
        cboMaquinaT1.DisplayMember = "nombre"
        cboMaquinaT2.DataSource = dt
        cboMaquinaT2.ValueMember = "codigoM"
        cboMaquinaT2.DisplayMember = "nombre"
        cboMaquinaT3.DataSource = dt
        cboMaquinaT3.ValueMember = "codigoM"
        cboMaquinaT3.DisplayMember = "nombre"
        cboMaquinaT4.DataSource = dt
        cboMaquinaT4.ValueMember = "codigoM"
        cboMaquinaT4.DisplayMember = "nombre"

        dt = New DataTable
        dt = obj_Ing_prodLn.listarReferencias("2,3")
        row = dt.NewRow
        row("id_ref") = 0
        row("descripcion") = ""
        dt.Rows.Add(row)
        cboRefT1.DataSource = dt
        cboRefT1.ValueMember = "id_ref"
        cboRefT1.DisplayMember = "descripcion"
        cboRefT2.DataSource = dt
        cboRefT2.ValueMember = "id_ref"
        cboRefT2.DisplayMember = "descripcion"
        cboRefT3.DataSource = dt
        cboRefT3.ValueMember = "id_ref"
        cboRefT3.DisplayMember = "descripcion"
        cboReft4.DataSource = dt
        cboReft4.ValueMember = "id_ref"
        cboReft4.DisplayMember = "descripcion"

        dt = New DataTable
        dt = obj_Ing_prodLn.listarContenedores()
        row = dt.NewRow
        row("codigo") = 0
        row("descripcion") = ""
        dt.Rows.Add(row)
        cboContT1.DataSource = dt
        cboContT1.ValueMember = "codigo"
        cboContT1.DisplayMember = "descripcion"
        cboContT2.DataSource = dt
        cboContT2.ValueMember = "codigo"
        cboContT2.DisplayMember = "descripcion"
        cboContT3.DataSource = dt
        cboContT3.ValueMember = "codigo"
        cboContT3.DisplayMember = "descripcion"
        cboContT4.DataSource = dt
        cboContT4.ValueMember = "codigo"
        cboContT4.DisplayMember = "descripcion"
        addColumnas()
    End Sub
    Private Sub addColumnas()
        dtgTamb1.Rows.Clear()
        dtgTamb2.Rows.Clear()
        dtgTamb3.Rows.Clear()
        dtgTamb4.Rows.Clear()
        For i = 0 To 9
            dtgTamb1.Rows.Add()
            dtgTamb2.Rows.Add()
            dtgTamb3.Rows.Add()
            dtgTamb4.Rows.Add()
        Next
    End Sub
    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        nuevo()
    End Sub
    Private Sub nuevo()
        addColumnas()
        cbo_operario.Text = "Seleccione"
        cbo_turno.Text = "Seleccione"
        txtEsperada.Text = ""
        txtProducida.Text = ""
        txtEfic.Text = ""
        esperadaTurno = 0
        prodTurno = 0
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If (validarFormulario()) Then
            If (guardar()) Then
                MessageBox.Show("Planilla ingresada en forma exitosa! ", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                nuevo()
            Else
                MessageBox.Show("Verifique que los tambores esten correctamente diligenciado ó comuniquese con el administrador del sistema! ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            MessageBox.Show("Verifique que los tambores esten correctamente diligenciados,se marcaran con rojo Y/O naranja! ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub
    Private Function guardar() As Boolean
        Dim idPulimiento As Int64 = objIngPulimientoLn.genIdPulimiento
        Dim operario As String = cbo_operario.SelectedValue
        Dim turno As String = cbo_turno.SelectedValue
        Dim fec As String = objOpSimplesLn.cambiarFormatoFecha(cbo_fecha.Value)
        Dim sqlPpal As String = objIngPulimientoLn.sqlInsertPpal(idPulimiento, operario, turno, fec)
        Dim listSql As New List(Of Object)
        listSql.Add(sqlPpal)
        listSql.AddRange(sqlTambor(dtgTamb1, 1, idPulimiento))
        listSql.AddRange(sqlTambor(dtgTamb2, 2, idPulimiento))
        listSql.AddRange(sqlTambor(dtgTamb3, 3, idPulimiento))
        listSql.AddRange(sqlTambor(dtgTamb4, 4, idPulimiento))
        If (objIngPulimientoLn.guardarTodo(listSql)) Then
            Return True
        Else
            Return False
        End If
    End Function
    Private Function sqlTambor(ByVal dtg As DataGridView, ByVal numTambor As Integer, ByVal idPulimiento As String) As List(Of Object)
        Dim sqlTotal As String = "INSERT INTO J_prod_pulimiento_det ( tambor, pulimiento, maquina, referencia ,contenedor, kilos) VALUES "
        Dim sqlUnit As String = ""
        Dim listSql As New List(Of Object)
        For i = 0 To dtg.RowCount - 1
            If (dtg.Item(1, i).Value <> Nothing) Then
                sqlUnit = sqlTotal & "(" & numTambor & "," & idPulimiento
                For j = 1 To dtg.ColumnCount - 1
                    sqlUnit += " , " & dtg.Item(j, i).Value
                Next
                sqlUnit += ")"
                listSql.Add(sqlUnit)
            End If
        Next
        Return listSql
    End Function
    Private Function validarPks(ByVal dtg As DataGridView, ByVal numTambor As Integer) As Boolean
        For i = 0 To dtg.RowCount - 1
            If (dtg.Item("cboMaquinaT" & numTambor, i).Value <> Nothing) Then
                For j = i + 1 To dtg.RowCount - 1
                    If (dtg.Item("cboMaquinaT" & numTambor, i).Value = dtg.Item("cboMaquinaT" & numTambor, j).Value) Then
                        For k = j To dtg.RowCount - 1
                            If (dtg.Item("cboReft" & numTambor, i).Value = dtg.Item("cboReft" & numTambor, k).Value) Then
                                dtg.Rows(i).DefaultCellStyle.BackColor = Color.DarkOrange
                                dtg.Rows(k).DefaultCellStyle.BackColor = Color.DarkOrange
                                Return False
                            Else
                                dtg.Rows(i).DefaultCellStyle.BackColor = Color.White
                                dtg.Rows(k).DefaultCellStyle.BackColor = Color.White
                            End If
                        Next

                    End If
                Next
            End If
        Next
        Return True
    End Function
    Private Function validarFormulario() As Boolean
        If (cbo_operario.Text <> "Seleccione" And cbo_turno.Text <> "Seleccione") Then
            If (validarDtg(dtgTamb1)) Then
                If (validarDtg(dtgTamb2)) Then
                    If (validarDtg(dtgTamb3)) Then
                        If (validarDtg(dtgTamb4)) Then
                            If (validarPks(dtgTamb1, 1)) Then
                                If (validarPks(dtgTamb2, 2)) Then
                                    If (validarPks(dtgTamb3, 3)) Then
                                        If (validarPks(dtgTamb4, 4)) Then
                                            Return True
                                        End If
                                    End If
                                End If
                            End If
                        Else
                            tblPpal.SelectedTab = tblTamb4
                        End If
                    Else
                        tblPpal.SelectedTab = tblTamb3
                    End If
                Else
                    tblPpal.SelectedTab = tblTamb2
                End If
            Else
                tblPpal.SelectedTab = tblTamb1
            End If
        End If
        Return False
    End Function
    Private Function validarDtg(ByVal dtg As DataGridView) As Boolean
        Dim sw As Boolean = False
        For i = 0 To dtg.RowCount - 1
            For j = 1 To dtg.ColumnCount - 1
                If (dtg.Item(j, i).Value = Nothing) Then
                    If (validarFilaVacia(i, dtg) = False) Then
                        dtg.Rows(i).DefaultCellStyle.BackColor = Color.Red
                        Return False
                    End If
                Else
                    dtg.Rows(i).DefaultCellStyle.BackColor = Color.White
                End If
            Next
        Next
        Return True
    End Function
    Private Function validarFilaVacia(ByVal fila As Integer, ByVal dtg As DataGridView) As Boolean
        For i = 1 To dtg.ColumnCount - 1
            If (dtg.Item(i, fila).Value <> Nothing) Then
                Return False
            End If
        Next
        Return True
    End Function

    Private Sub dtgTamb1_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgTamb1.CellValueChanged
        Dim col As String = dtgTamb1.Columns(e.ColumnIndex).Name
        If (col = "colPesoT1") Then
            If Not (objIngPulimientoLn.validarNumero(dtgTamb1.Item(e.ColumnIndex, e.RowIndex).Value)) Then
                MessageBox.Show("Verifique que el valor para el peso no sea alfanumerico ", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
                dtgTamb1.Item("colPesoT1", e.RowIndex).Value = ""
            ElseIf (dtgTamb1.Item("colPesoT1", e.RowIndex).Value <> "") Then
                prodTurno += dtgTamb1.Item("colPesoT1", e.RowIndex).Value
                eficiencias()
            End If
        ElseIf (col = "cboMaquinaT1" Or col = "cboRefT1" Or col = "cboContT1") Then
            dtgTamb1.Item("colPesoT1", e.RowIndex).Value = "400"
        End If
    End Sub
    Private Sub dtgTamb2_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgTamb2.CellValueChanged
        Dim col As String = dtgTamb2.Columns(e.ColumnIndex).Name
        If (dtgTamb2.Columns(e.ColumnIndex).Name = "colPesoT2") Then
            If Not (objIngPulimientoLn.validarNumero(dtgTamb2.Item(e.ColumnIndex, e.RowIndex).Value)) Then
                MessageBox.Show("Verifique que el valor para el peso no sea alfanumerico ", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
                dtgTamb2.Item("colPesoT2", e.RowIndex).Value = ""
            Else
                prodTurno += dtgTamb2.Item("colPesoT2", e.RowIndex).Value
                eficiencias()
            End If
        ElseIf (col = "cboMaquinaT2" Or col = "cboRefT2" Or col = "cboContT2") Then
            dtgTamb2.Item("colPesoT2", e.RowIndex).Value = "400"

        End If
    End Sub
    Private Sub dtgTamb3_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgTamb3.CellValueChanged
        Dim col As String = dtgTamb3.Columns(e.ColumnIndex).Name
        If (dtgTamb3.Columns(e.ColumnIndex).Name = "colPesoT3") Then
            If Not (objIngPulimientoLn.validarNumero(dtgTamb3.Item(e.ColumnIndex, e.RowIndex).Value)) Then
                MessageBox.Show("Verifique que el valor para el peso no sea alfanumerico ", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
                dtgTamb3.Item("colPesoT3", e.RowIndex).Value = ""
            Else
                prodTurno += dtgTamb3.Item("colPesoT3", e.RowIndex).Value
                eficiencias()
            End If
        ElseIf (col = "cboMaquinaT3" Or col = "cboRefT3" Or col = "cboContT3") Then
            dtgTamb3.Item("colPesoT3", e.RowIndex).Value = "400"

        End If
    End Sub
    Private Sub dtgTamb4_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgTamb4.CellValueChanged
        Dim col As String = dtgTamb4.Columns(e.ColumnIndex).Name
        If (dtgTamb4.Columns(e.ColumnIndex).Name = "colPesoT4") Then
            If Not (objIngPulimientoLn.validarNumero(dtgTamb4.Item(e.ColumnIndex, e.RowIndex).Value)) Then
                MessageBox.Show("Verifique que el valor para el peso no sea alfanumerico ", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
                dtgTamb4.Item("colPesoT4", e.RowIndex).Value = ""
            Else
                prodTurno += dtgTamb4.Item("colPesoT4", e.RowIndex).Value
                eficiencias()
            End If
        ElseIf (col = "cboMaquinaT4" Or col = "cboRefT4" Or col = "cboContT4") Then
            dtgTamb4.Item("colPesoT4", e.RowIndex).Value = "400"
        End If
    End Sub

    Private Sub dtgTamb1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgTamb1.CellContentClick
        If (dtgTamb1.Columns(e.ColumnIndex).Name = "colBorrar1") Then
            If (dtgTamb1.Item("colPesoT1", e.RowIndex).Value.ToString <> "") Then
                prodTurno -= dtgTamb1.Item("colPesoT1", e.RowIndex).Value
                eficiencias()
            End If
            dtgTamb1.Rows.RemoveAt(e.RowIndex)
            dtgTamb1.Rows.Add()
        End If
    End Sub
    Private Sub dtgTamb2_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgTamb2.CellContentClick
        If (dtgTamb2.Columns(e.ColumnIndex).Name = "colBorrar2") Then
            If (dtgTamb2.Item("colPesoT2", e.RowIndex).Value.ToString <> "") Then
                prodTurno -= dtgTamb2.Item("colPesoT2", e.RowIndex).Value
                eficiencias()
            End If
            dtgTamb2.Rows.RemoveAt(e.RowIndex)
            dtgTamb2.Rows.Add()
        End If
    End Sub
    Private Sub dtgTamb3_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgTamb3.CellContentClick
        If (dtgTamb3.Columns(e.ColumnIndex).Name = "colBorrar3") Then
            If (dtgTamb3.Item("colPesoT3", e.RowIndex).Value.ToString <> "") Then
                prodTurno -= dtgTamb3.Item("colPesoT3", e.RowIndex).Value
                eficiencias()
            End If
            dtgTamb3.Rows.RemoveAt(e.RowIndex)
            dtgTamb3.Rows.Add()
        End If
    End Sub
    Private Sub dtgTamb4_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgTamb4.CellContentClick
        If (dtgTamb4.Columns(e.ColumnIndex).Name = "colBorrar4") Then
            If (dtgTamb4.Item("colPesoT4", e.RowIndex).Value.ToString <> "") Then
                prodTurno -= dtgTamb4.Item("colPesoT4", e.RowIndex).Value
                eficiencias()
            End If
            dtgTamb4.Rows.RemoveAt(e.RowIndex)
            dtgTamb4.Rows.Add()
        End If
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Frm_consultar_pulim.Show()
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

    Private Sub cbo_turno_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_turno.SelectedIndexChanged
        If (cargaComp) Then
            esperadaTurno = objIngPulimientoLn.kilEsperados(cbo_turno.SelectedValue)
            txtEsperada.Text = Format(esperadaTurno, "N0")
            eficiencias()
        End If
    End Sub
    Private Sub eficiencias()
        txtProducida.Text = Format(prodTurno, "N0")
        txtEfic.Text = Format(objIngPulimientoLn.calcEficiencia(prodTurno, esperadaTurno), "N1")
    End Sub
End Class