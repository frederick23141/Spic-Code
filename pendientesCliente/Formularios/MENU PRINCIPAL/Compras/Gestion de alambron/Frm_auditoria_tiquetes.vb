Imports logicaNegocios
Imports entidadNegocios
Imports accesoDatos
Public Class Frm_auditoria_tiquetes
    Private objOperacionesForm As OperacionesFormularios = New OperacionesFormularios
    Private objOpSimplesLn As New Op_simpesLn
    Private objRelojLn As New RelojLn
    Private nomb_modulo As String
    Dim centros As String = ""
    Dim usuario As New UsuarioEn
    Dim carga_comp As Boolean = False
    Dim fec_ini As Date
    Dim fec_fin As Date
    Dim nit_proveedor, pnit_proveedor As String
    Dim n_importacion, pn_importacion, n_rollo, pn_rollo, id_solicitud, pid_solicitud As Integer
    Dim filaSelect_consulta As Integer = 0
    Private Sub Frm_auditoria_tiquetes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargar_proveedores()
    End Sub
    Public Sub Main(ByVal id_cargue As Double, ByVal usuario As UsuarioEn)
        Me.usuario = usuario
        If id_cargue <> "0" Then
            cargar_datos(id_cargue)
        End If
        carga_comp = True
        If usuario.permiso.Trim <> "ADMIN" Then
            EliminarRegistroToolStripMenuItem.Enabled = False
        End If
    End Sub
    Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
        dtg_consulta.CurrentCell = Nothing
        imgProcesar.Visible = True
        Application.DoEvents()
        dtg_consulta.DataSource = Nothing
        cargar_datos(0)
        imgProcesar.Visible = False
    End Sub
    Private Sub cargar_datos(ByVal id_cargue As String)
        Dim tamano_letra As Single = 9.0!
        dtg_consulta.DataSource = Nothing
        Dim sql As String = "SELECT (SELECT CASE WHEN r.num_transaccion is null THEN e.fecha  ELSE (SELECT fecha FROM CORSAN.dbo.documentos WHERE numero = r.num_transaccion AND tipo = e.tipo ) END ) As fecha,t.nombres,e.nit_proveedor, e.numero_importacion As n_import, d.id_det,r.numero_rollo,d.codigo,d.costo_kilo  ,r.peso,r.fecha_consumo ,(r.peso * d.costo_kilo) As costo_total,e.tipo,r.num_transaccion,r.num_transaccion_salida As salida,r.smpp_b2,r.tipo_salida,(select t.nombres FROM J_alambron_requisicion re , CORSAN.dbo.terceros t  WHERE re.nit = t.nit AND re.id = r.id_requisicion ) As operario,r.id_requisicion,e.molino  " &
                                    "FROM J_alambron_importacion_det_rollos r , J_alambron_solicitud_det d , J_alambron_solicitud_enc e , CORSAN.dbo.terceros t " &
                                        "WHERE t.nit = e.nit_proveedor AND d.num_importacion = e.numero_importacion AND r.nit_proveedor = d.nit_proveedor AND r.num_importacion = d.num_importacion AND d.nit_proveedor = e.nit_proveedor AND r.id_solicitud_det  = d.id_det "
        Dim whereSql As String = ""
        If txtCodigo.Text <> "" Then
            whereSql &= " AND d.codigo like '" & txtCodigo.Text & "%'"
        ElseIf cbo_consult_prov.SelectedValue <> 0 Then
            whereSql &= " AND e.nit_proveedor  = " & cbo_consult_prov.SelectedValue & ""
            If cbo_consult_importacion.SelectedValue <> "Seleccione" Then
                whereSql &= " AND e.numero_importacion  = " & cbo_consult_importacion.SelectedValue & ""
            End If
        ElseIf id_cargue <> 0 Then
            whereSql &= " AND r.id_requisicion = " & id_cargue & " "
        End If
        If Not chk_todo.Checked Then
            If chk_tran_entrada.Checked Then
                whereSql &= " AND r.peso is not null AND num_transaccion is not null AND r.num_transaccion_salida is null  "
            End If
            If chk_tiq_unico.Checked Then
                whereSql &= " AND e.nit_proveedor = 999999999 "
            End If
            If chk_ent_salida.Checked Then
                whereSql &= " AND r.num_transaccion_salida is not null AND smpp_b2 is null  "
            End If
            If chk_sin_entrada.Checked Then
                whereSql &= " AND num_transaccion is null "
            End If
            If chk_consum_trefila.Checked Then
                whereSql &= " AND smpp_b2 is not null "
            End If
        End If
        sql &= whereSql
        Dim dt As DataTable = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")
        Dim sum As Double = 0
        dt.Rows.Add()
        For j = 0 To dt.Columns.Count - 1
            If dt.Columns(j).ColumnName = "peso" Or dt.Columns(j).ColumnName = "costo_total" Or dt.Columns(j).ColumnName = "costo_kilo" Then
                For i = 0 To dt.Rows.Count - 1
                    If Not IsDBNull(dt.Rows(i).Item(j)) Then
                        sum += dt.Rows(i).Item(j)
                    End If
                Next
                dt.Rows(dt.Rows.Count - 1).Item(j) = sum
                sum = 0
            End If
        Next
        dtg_consulta.DataSource = dt
        dtg_consulta.CurrentCell = Nothing
        dtg_consulta.Columns("fecha").DefaultCellStyle.Format = "d"
        dtg_consulta.Columns("fecha_consumo").DefaultCellStyle.Format = "d"
        dtg_consulta.Rows(dtg_consulta.Rows.Count - 1).DefaultCellStyle = objOperacionesForm.formatoNegrita(tamano_letra)
        dtg_consulta.Columns("codigo").DefaultCellStyle = objOperacionesForm.formatoNegrita(tamano_letra)
        dtg_consulta.Columns("num_transaccion").DefaultCellStyle = objOperacionesForm.formatoNegrita(tamano_letra)
        dtg_consulta.Columns("molino").Visible = False
        pintar_dtg()
    End Sub
    Private Sub pintar_dtg()
        For i = 0 To dtg_consulta.Rows.Count - 2
            If Not IsDBNull(dtg_consulta.Item("peso", i).Value) And Not IsDBNull(dtg_consulta.Item("num_transaccion", i).Value) Then
               If Not IsDBNull(dtg_consulta.Item("smpp_b2", i).Value) Then
                    dtg_consulta.Rows(i).DefaultCellStyle.BackColor = Color.Silver
                ElseIf Not IsDBNull(dtg_consulta.Item("salida", i).Value) Then
                    dtg_consulta.Rows(i).DefaultCellStyle.BackColor = Color.Purple
                    dtg_consulta.Rows(i).DefaultCellStyle.ForeColor = Color.White
                Else
                    dtg_consulta.Rows(i).DefaultCellStyle.BackColor = Color.FromArgb(237, 242, 133)
                End If
            ElseIf dtg_consulta.Item("nit_proveedor", i).Value = 999999999 Then
                If Not IsDBNull(dtg_consulta.Item("peso", i).Value) Then
                    dtg_consulta.Rows(i).DefaultCellStyle.BackColor = Color.Yellow
                Else
                    dtg_consulta.Rows(i).Visible = False
                End If
            Else
                dtg_consulta.Rows(i).DefaultCellStyle.BackColor = Color.FromArgb(143, 56, 77)
                dtg_consulta.Rows(i).DefaultCellStyle.ForeColor = Color.White
            End If
        Next
    End Sub



    Private Sub ToolStripSplitButton1_Click(sender As Object, e As EventArgs) Handles ToolStripSplitButton1.Click
        objOperacionesForm.ExportarDatosExcel(dtg_consulta, "Auditoria de entrada de alambrón")
    End Sub
    Private Sub cbo_consult_prov_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbo_consult_prov.SelectedIndexChanged
        If carga_comp Then
            If cbo_consult_prov.SelectedValue <> 0 Then
                cargar_consult_imp()
            End If
        End If
    End Sub
    Private Sub cargar_consult_imp()
        Dim dt As New DataTable
        Dim sql As String = "SELECT  CAST(numero_importacion AS varchar(25))As numero_importacion  " & _
                                "FROM J_alambron_solicitud_enc " & _
                                    "WHERE nit_proveedor = " & cbo_consult_prov.SelectedValue

        dt = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")
        dt.Rows.Add()
        dt.Rows(dt.Rows.Count - 1).Item("numero_importacion") = 0
        dt.Rows(dt.Rows.Count - 1).Item("numero_importacion") = "Seleccione"
        cbo_consult_importacion.DataSource = dt
        cbo_consult_importacion.ValueMember = "numero_importacion"
        cbo_consult_importacion.DisplayMember = "numero_importacion"
        cbo_consult_importacion.SelectedValue = "Seleccione"
    End Sub
    Private Sub cargar_proveedores()
        Dim sql As String = "SELECT nit_proveedor As nit, t.nombres FROM J_alambron_solicitud_enc e, CORSAN.dbo.terceros t WHERE t.nit = e.nit_proveedor group by nit_proveedor, t.nombres"
        Dim dt As DataTable = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")
        dt.Rows.Add()
        dt.Rows(dt.Rows.Count - 1).Item("nit") = 0
        dt.Rows(dt.Rows.Count - 1).Item("nombres") = "Seleccione"
        cbo_consult_prov.DataSource = dt
        cbo_consult_prov.ValueMember = "nit"
        cbo_consult_prov.DisplayMember = "nombres"
        cbo_consult_prov.SelectedValue = 0
    End Sub


    Private Sub itemCopia_Click(ByVal sender As Object, ByVal e As EventArgs)
        imprimir_codigos()
    End Sub
    Private Sub imprimir_codigos()
        Dim nit_proveedor As Double = dtg_consulta.Item("nit_proveedor", filaSelect_consulta).Value
        Dim num_importacion As Double = dtg_consulta.Item("n_import", filaSelect_consulta).Value
        Dim id_solicitud_det As Double = dtg_consulta.Item("id_det", filaSelect_consulta).Value
        Dim num_rollo As Double = dtg_consulta.Item("numero_rollo", filaSelect_consulta).Value
        Dim codigo As String = dtg_consulta.Item("codigo", filaSelect_consulta).Value
        Dim fecha As String = dtg_consulta.Item("fecha", filaSelect_consulta).Value
        Dim consecutivo As String = nit_proveedor & "-" & num_importacion & "-" & id_solicitud_det & "-" & num_rollo
        Dim nit_molino As String = dtg_consulta.Item("molino", filaSelect_consulta).Value
        Dim nom_proveedor As String = dtg_consulta.Item("nombres", filaSelect_consulta).Value
        Dim nom_molino As String = objOpSimplesLn.consultarVal("SELECT nombres FROM terceros WHERE nit =" & nit_molino)
        Dim descripcion As String = objOpSimplesLn.consultarVal("SELECT descripcion FROM referencias WHERE codigo ='" & codigo & "'")
        Dim proc As New Process
        modificarPlantilla(consecutivo, codigo, fecha, num_importacion, descripcion, nom_molino, nit_proveedor)
        proc.StartInfo.FileName = Environment.CurrentDirectory & "\plantillaAlambronImp.txt"
        proc.StartInfo.Verb = "Print"
        proc.StartInfo.CreateNoWindow = False
        proc.Start()
    End Sub

    Private Sub modificarPlantilla(ByVal consecutivo As String, ByVal codigo As String, ByVal fecha As Date, ByVal num_importacion As String, ByVal descripcion As String, ByVal molino As String, ByVal proveedor As String)
        Dim fic As String = Environment.CurrentDirectory & "\plantillaAlambron.txt"
        Dim nuevoFic As String = Environment.CurrentDirectory & "\plantillaAlambronImp.txt"
        Dim sw As New System.IO.StreamWriter(nuevoFic)
        Dim texto As String
        Dim sr As New System.IO.StreamReader(fic)
        texto = sr.ReadToEnd()
        texto = Replace(texto, "@codigo", codigo & " (COPIA)")
        texto = Replace(texto, "@descripcion", descripcion)
        texto = Replace(texto, "@consecutivo", consecutivo)
        texto = Replace(texto, "@importacion", num_importacion)
        texto = Replace(texto, "@proveedor", proveedor)
        texto = Replace(texto, "@molino", molino)
        texto = Replace(texto, "@fecha", fecha)
        texto = Replace(texto, "@barras", consecutivo)
        sr.Close()
        sw.WriteLine(texto)
        sw.Close()

    End Sub
    Private Sub dtg_consulta_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dtg_consulta.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            If dtg_consulta.Rows.Count > 0 Then
                menStrip.Enabled = True

                With (Me.dtg_consulta)
                    Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)


                    If Hitest.Type = DataGridViewHitTestType.Cell Then
                        .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                        nit_proveedor = Me.dtg_consulta("nit_proveedor", Me.dtg_consulta.CurrentRow.Index).Value
                        n_importacion = Me.dtg_consulta("n_import", Me.dtg_consulta.CurrentRow.Index).Value
                        id_solicitud = Me.dtg_consulta("id_det", Me.dtg_consulta.CurrentRow.Index).Value
                        n_rollo = Me.dtg_consulta("numero_rollo", Me.dtg_consulta.CurrentRow.Index).Value
                        guardarnit(nit_proveedor)
                        guardarimportacion(n_importacion)
                        guardarsolicitud(id_solicitud)
                        guardarrollo(n_rollo)
                        If IsDBNull(Me.dtg_consulta("peso", Me.dtg_consulta.CurrentRow.Index).Value) Or IsDBNull(Me.dtg_consulta("costo_total", Me.dtg_consulta.CurrentRow.Index).Value) Then
                            If usuario.permiso.Trim = "ADMIN" Then
                                EliminarRegistroToolStripMenuItem.Enabled = True
                            End If
                        Else
                            EliminarRegistroToolStripMenuItem.Enabled = False
                        End If
                    End If
                End With
                filaSelect_consulta = dtg_consulta.CurrentCell.RowIndex
            End If
        End If
    End Sub
    ''Estos metodos guardar en las variables globales la infromacion del registro donde se pare,y si es valido  lo permite borrar
    Public Function guardarnit(ByVal rnit As String)
        pnit_proveedor = rnit
        Return pnit_proveedor
    End Function
    Public Function guardarimportacion(ByVal rimportacion As Integer)
        pn_importacion = rimportacion
        Return pn_importacion
    End Function
    Public Function guardarsolicitud(ByVal rsolicitud As Integer)
        pid_solicitud = rsolicitud
        Return pid_solicitud
    End Function
    Public Function guardarrollo(ByVal rrollo As Integer)
        pn_rollo = rrollo
        Return pn_rollo
    End Function

    Private Sub chk_tran_entrada_CheckedChanged(sender As Object, e As EventArgs) Handles chk_tran_entrada.CheckedChanged
        If chk_tran_entrada.Checked And carga_comp Then
            carga_comp = False
            chk_sin_entrada.Checked = False
            chk_tiq_unico.Checked = False
            chk_ent_salida.Checked = False
            chk_todo.Checked = False
            chk_consum_trefila.Checked = False
            carga_comp = True
        End If
    End Sub

    Private Sub chk_sin_entrada_CheckedChanged(sender As Object, e As EventArgs) Handles chk_sin_entrada.CheckedChanged
        If chk_sin_entrada.Checked And carga_comp Then
            carga_comp = False
            chk_tran_entrada.Checked = False
            chk_tiq_unico.Checked = False
            chk_ent_salida.Checked = False
            chk_todo.Checked = False
            chk_consum_trefila.Checked = False
            carga_comp = True
        End If
    End Sub

    Private Sub chk_tiq_unico_CheckedChanged(sender As Object, e As EventArgs) Handles chk_tiq_unico.CheckedChanged
        If chk_tiq_unico.Checked And carga_comp Then
            carga_comp = False
            chk_tran_entrada.Checked = False
            chk_sin_entrada.Checked = False
            chk_ent_salida.Checked = False
            chk_todo.Checked = False
            chk_consum_trefila.Checked = False
            carga_comp = True
        End If
    End Sub

    Private Sub chk_ent_salida_CheckedChanged(sender As Object, e As EventArgs) Handles chk_ent_salida.CheckedChanged
        If chk_ent_salida.Checked And carga_comp Then
            carga_comp = False
            chk_tran_entrada.Checked = False
            chk_sin_entrada.Checked = False
            chk_tiq_unico.Checked = False
            chk_consum_trefila.Checked = False
            chk_todo.Checked = False
            carga_comp = True
        End If
    End Sub

    Private Sub chk_todo_CheckedChanged(sender As Object, e As EventArgs) Handles chk_todo.CheckedChanged
        chk_tran_entrada.Checked = False
        chk_sin_entrada.Checked = False
        chk_tiq_unico.Checked = False
        chk_ent_salida.Checked = False
        chk_consum_trefila.Checked = False
    End Sub

    Private Sub itemCopia_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles itemCopia.Click
        imprimir_codigos()
    End Sub

    Private Sub EliminarRegistroToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim result As DialogResult
        result = MessageBox.Show("Realmente desea eliminar los productos seleccionados", "Eliminar registros", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
        If result = DialogResult.OK Then
            Try
                Dim func As New Op_simplesAd
                If func.eliminar_alambron_sinasignar(pnit_proveedor, pn_importacion, pn_rollo, pid_solicitud) Then

                Else
                    MessageBox.Show("Producto no fue eliminado", "Eliminar registros", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
                cargar_datos(0)

            Catch ex As Exception
                MsgBox(ex.Message)

            End Try
        Else
            MessageBox.Show("Cancelando eliminacion de registros", "Eliminar registros", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If
        cargar_datos(0)
        imgProcesar.Visible = True
        Application.DoEvents()
        imgProcesar.Visible = False
    End Sub



    Private Sub chk_consum_trefila_CheckedChanged(sender As Object, e As EventArgs) Handles chk_consum_trefila.CheckedChanged
        If chk_consum_trefila.Checked And carga_comp Then
            carga_comp = False
            chk_tran_entrada.Checked = False
            chk_sin_entrada.Checked = False
            chk_tiq_unico.Checked = False
            chk_todo.Checked = False
            chk_ent_salida.Checked = False
            carga_comp = True
        End If
    End Sub

    Private Sub EliminarRegistroToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EliminarRegistroToolStripMenuItem.Click
        Dim result As DialogResult
        result = MessageBox.Show("Realmente desea eliminar los productos seleccionados", "Eliminar registros", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
        If result = DialogResult.OK Then
            Try
                Dim func As New Op_simplesAd
                If func.eliminar_alambron_sinasignar(pnit_proveedor, pn_importacion, pn_rollo, pid_solicitud) Then

                Else
                    MessageBox.Show("Registro no fue eliminado", "Eliminar registros", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
                cargar_datos(0)

            Catch ex As Exception
                MsgBox(ex.Message)

            End Try
        Else
            MessageBox.Show("Cancelando eliminacion de registros", "Eliminar registros", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If
        cargar_datos(0)
        imgProcesar.Visible = True
        Application.DoEvents()
        imgProcesar.Visible = False
    End Sub
    Private Sub VerPlanillaDeCargueToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VerPlanillaDeCargueToolStripMenuItem.Click
        Dim id_cargue As Double = dtg_consulta("id_requisicion", Me.dtg_consulta.CurrentRow.Index).Value
        Dim frm As New Frm_planillas_cargue
        frm.Show()
        frm.MAIN(id_cargue, usuario)
    End Sub

End Class