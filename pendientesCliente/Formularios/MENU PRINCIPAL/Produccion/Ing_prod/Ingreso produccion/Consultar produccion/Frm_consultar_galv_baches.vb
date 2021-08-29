Imports logicaNegocios
Public Class frm_consultar_galv_baches
    Private objOperacionesForm As New OperacionesFormularios
    Private obj_Ing_prodLn As New Ing_prodLn
    Public seccion As String
    Private obj_Sum As New Op_simpesLn
    Dim carga_completa As Boolean = False

    Public Sub cargar_consulta(ByVal sec As String)
        Try
            seccion = sec
            If sec = 213 Then
                Me.Text = "Tratamientos Térmicos"
            End If
            carga_completa = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub cargar_consultaFecha(ByVal FechaIni As String, ByVal FechaFin As String)
        Try
            Dim tamano_letra As Single = 9.0!
            Dim dt As New DataTable
            Dim select_sqlFecha As String = ""
            select_sqlFecha = "SELECT [Seguimiento tornillos].Fecha, Medidas.Nombre As Medida, Operarios.Nombres As Operario, Maquinas.Nombre As Seccion, [Seguimiento tornillos].Cantidad FROM prgproduccion.dbo.Maquinas Maquinas, prgproduccion.dbo.Medidas Medidas, CORSAN.dbo.V_nom_personal_Activo_con_maquila Operarios, prgproduccion.dbo.[Seguimiento tornillos] [Seguimiento tornillos] WHERE [Seguimiento tornillos].Medida = Medidas.Codigo AND [Seguimiento tornillos].Maquina = Maquinas.Codigo AND Operarios.nit = [Seguimiento tornillos].Operario and [Seguimiento tornillos].Maquina = '" & seccion & "' and Fecha>='" & FechaIni & "' and Fecha <='" & FechaFin & "' "
            If (cboOperario.SelectedValue <> 0) Then
                select_sqlFecha += " AND operarios.nit = '" & cboOperario.SelectedValue.ToString() & "' order by Fecha desc"
            ElseIf (chkTodos.Checked = True) Then
                cboOperario.Text = "Seleccione"
                select_sqlFecha += " order by Fecha desc"
            Else
                select_sqlFecha += " order by Fecha desc"
            End If
            carga_completa = True
            dt = obj_Ing_prodLn.listar_datatable(select_sqlFecha, "PRODUCCION")
            dt = totalizar(dt)
            dtgConsultarMante.DataSource = dt
            dtgConsultarMante.Rows(dtgConsultarMante.Rows.Count - 1).DefaultCellStyle = objOperacionesForm.formatoNegrita(tamano_letra)
            dtgConsultarMante.Columns("Fecha").DefaultCellStyle.Format = "d"
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Function totalizar(ByRef dt As DataTable) As DataTable
        dt.Rows.Add()
        Dim sum As Double = 0
        For j = 0 To dt.Columns.Count - 1
            If (dt.Columns(j).ColumnName = "Cantidad") Then
                For i = 0 To dt.Rows.Count - 2
                    If Not IsDBNull(dt.Rows(i).Item(j)) Then
                        sum += dt.Rows(i).Item(j)
                    End If
                Next
                dt.Rows(dt.Rows.Count - 1).Item(j) = sum
                sum = 0
            End If
        Next
        Return dt
    End Function
    Private Sub Frm_consultar_galvanizado_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtFecFin.Value = Now.AddDays(-1)
        dtFecIni.Value = Now.AddDays(-1)
        Dim sql As String = "select nit,Nombres from V_nom_personal_Activo_con_maquila WHERE centro IN (2800,6200) ORDER BY  nombres"
        Dim dt As DataTable = obj_Ing_prodLn.listar_datatable(sql, "CORSAN")
        dt.Rows.Add()
        dt.Rows(dt.Rows.Count - 1).Item("nit") = 0
        dt.Rows(dt.Rows.Count - 1).Item("Nombres") = "TODOS"
        cboOperario.DataSource = dt
        cboOperario.ValueMember = "nit"
        cboOperario.DisplayMember = "Nombres"
        cboOperario.SelectedValue = 0
        carga_completa = True
    End Sub

    Private Sub btn_excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_excel.Click
        objOperacionesForm.ExportarDatosExcel(dtgConsultarMante, "Galvanizado")
    End Sub

    Private Sub btnActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActualizar.Click
        Try
            Dim Fini, Ffin As Date
            Fini = dtFecIni.Value
            Ffin = dtFecFin.Value
            If (Fini > Ffin) Then
                MsgBox("Fecha Inicial Mayor A La Fecha Final, Cambie La Fecha Incial")
            Else
                cargar_consultaFecha(obj_Sum.cambiarFormatoFecha(Fini), obj_Sum.cambiarFormatoFecha(Ffin))
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

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

    Private Sub dtFecIni_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtFecIni.ValueChanged
        Try
            If (carga_completa) Then
                Dim Fini, Ffin As Date
                Fini = dtFecIni.Value.Date
                Ffin = dtFecFin.Value.Date
                If (Fini > Ffin) Then
                    MsgBox("Fecha Inicial Mayor A La Fecha Final, Cambie La Fecha Incial")
                    dtFecIni.Focus()
                Else
                    cargar_consultaFecha(obj_Sum.cambiarFormatoFecha(Fini), obj_Sum.cambiarFormatoFecha(Ffin))
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub dtFecFin_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtFecFin.ValueChanged
        Try
            If (carga_completa) Then
                Dim Fini, Ffin As Date
                Fini = dtFecIni.Value.Date
                Ffin = dtFecFin.Value.Date
                If (Fini > Ffin) Then
                    MsgBox("Fecha Inicial Mayor A La Fecha Final, Cambie La Fecha Incial")
                    dtFecIni.Focus()
                Else
                    cargar_consultaFecha(obj_Sum.cambiarFormatoFecha(Fini), obj_Sum.cambiarFormatoFecha(Ffin))
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

 

    Private Sub chk_todos_CheckedChanged(sender As Object, e As EventArgs) Handles chkTodos.CheckedChanged
        Dim sql As String = ""
        If (chkTodos.Checked = True) Then
            sql = "Select nit,nombres   from V_nom_personal_Activo_con_maquila WHERE centro not in (4200) ORDER BY nombres "
        Else
            sql = "Select nit,nombres  from V_nom_personal_Activo_con_maquila WHERE centro in (2800,6200) ORDER BY nombres"
        End If
        Dim dt As DataTable = obj_Ing_prodLn.listar_datatable(sql, "CORSAN")
        dt.Rows.Add()
        dt.Rows(dt.Rows.Count - 1).Item("nit") = 0
        dt.Rows(dt.Rows.Count - 1).Item("nombres") = "TODOS"
        cboOperario.DataSource = dt
        cboOperario.ValueMember = "nit"
        cboOperario.DisplayMember = "nombres"
        cboOperario.SelectedValue = 0
    End Sub
End Class