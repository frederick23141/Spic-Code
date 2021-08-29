Imports System.Configuration
Imports logicaNegocios
Imports entidadNegocios
Public Class FrmFichaPesosManual
    Private objOpSimplesLn As New Op_simpesLn
    Private objIngProdLn As New Ing_prodLn
    Dim procedencia As String
    Dim carga_comp As Boolean = False
    Public Sub Main(ByVal nit As String, ByVal nombres As String, ByVal codigo As String, ByVal desc As String, ByVal resistencia As String, ByVal procedencia As String, ByVal calidad As String, ByVal rec As String)
        txtNit.Text = nit
        txtNombres.Text = nombres
        txtCodigo.Text = codigo
        txtDescripcion.Text = desc
        txtResis_est.Text = resistencia
        Me.procedencia = procedencia
        txtCalidad_est.Text = calidad
        If (rec = "0") Then
            txt_rec_real.Text = "N/A"
            txtRec_est.Text = "N/A"
            txt_rec_real.Enabled = False
        Else
            txtRec_est.Text = rec
        End If
    End Sub
    Private Sub FrmFichaPesosManual_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargarDataSourse()
        cboProcedencia.SelectedValue = procedencia
        dtgRollos.Rows.Add()
        dtgRollos.Item("ColNumRollo", 0).Value = 1
        carga_comp = True
    End Sub
    Private Sub cargarDataSourse()
        Dim sql As String = "SELECT Codigo,Descripcion FROM J_turnos WHERE codigo in (1,2,3)  "
        Dim dt As New DataTable
        Dim row As DataRow
        sql = "Select nit,nombres  from Jjv_prov_alambron  "
        dt = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        row = dt.NewRow
        row("nit") = 0
        row("nombres") = "Seleccione"
        dt.Rows.Add(row)
        cboProcedencia.DataSource = dt
        cboProcedencia.ValueMember = "nit"
        cboProcedencia.DisplayMember = "nombres"
        cboProcedencia.Text = "Seleccione"
        cboProcedencia.SelectedValue = 0

        sql = "Select nit,nombres  from V_nom_personal_Activo_con_maquila WHERE nit in (98479325,9760043,98550501,1026135742,1128268007,1017175837) ORDER BY nombres "
        dt = New DataTable
        dt = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        row = dt.NewRow
        row("nit") = 0
        row("nombres") = "Seleccione"
        dt.Rows.Add(row)
        cboCoordinador.DataSource = dt
        cboCoordinador.ValueMember = "nit"
        cboCoordinador.DisplayMember = "nombres"
        cboCoordinador.Text = "Seleccione"
        cboCoordinador.SelectedValue = 0
        'cargamos el nombre de la persona responsable con este id
        sql = "Select nit,nombres  from V_nom_personal_Activo_con_maquila WHERE nit in (1130677175, 15518552) ORDER BY nombres "
        dt = New DataTable
        dt = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        row = dt.NewRow
        row("nit") = 0
        row("nombres") = "Seleccione"
        dt.Rows.Add(row)
        cboResponsable.DataSource = dt
        cboResponsable.ValueMember = "nit"
        cboResponsable.DisplayMember = "nombres"
        cboResponsable.Text = "Seleccione"
        cboResponsable.SelectedValue = 0

        sql = "Select tipo_calidad  from J_tipo_cal_alambre "
        cbo_calidad_real.DataSource = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")
        cbo_calidad_real.ValueMember = "tipo_calidad"
        cbo_calidad_real.DisplayMember = "tipo_calidad"
        cbo_calidad_real.Text = "Seleccione"
        cbo_calidad_real.SelectedValue = 0
    End Sub
    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        FrmLogin.Show()
        FrmPrincipal.Close()
        Me.Close()
    End Sub

    Private Sub btn_ppal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ppal.Click
        FrmPrincipal.Show()
        Me.Close()
    End Sub

    Private Sub dtgRollosCellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgRollos.CellContentClick
        Dim fila As Integer = e.RowIndex
        Dim col As String = dtgRollos.Columns(e.ColumnIndex).Name
        If (fila >= 0) Then
            If (col = "colEliminar") Then
                dtgRollos.Rows.RemoveAt(e.RowIndex)
                txtTotPeso.Text = sumarPesos()
            ElseIf (col = "colAdd") Then
                If Not IsNumeric(dtgRollos.Item("ColPeso", e.RowIndex).Value) Then
                    MessageBox.Show("Verifique que el dato ingresado en el peso del rollo sea númerico!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    dtgRollos.Item("ColPeso", e.RowIndex).Value = ""
                Else
                    txtTotPeso.Text = sumarPesos()
                    dtgRollos.Rows.Add()
                    dtgRollos.Item("ColNumRollo", e.RowIndex + 1).Value = e.RowIndex + 2
                End If

            End If
        End If
    End Sub
    Private Function sumarPesos() As Double
        Dim suma As Double = 0
        For i = 0 To dtgRollos.RowCount - 1
            If IsNumeric(dtgRollos.Item("ColPeso", i).Value) Then
                If (dtgRollos.Item("ColPeso", i).Value.ToString <> "") Then
                    suma += dtgRollos.Item("ColPeso", i).Value
                End If
            End If
        Next
        Return suma
    End Function

    Private Sub btnGenReporte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenReporte.Click
        If (validarFrm()) Then
            dtgRollos.CurrentCell = Nothing
            Dim listDetRollos As New List(Of DetalleRollosEn)
            Dim listDetRollos2 As New List(Of DetalleRollosEn)
            Dim objFichaAlambEn As New FichaAlambEn
            Dim objDetalleRollosEn As New DetalleRollosEn
            Dim obj_calidad_alambronEn As New Calidad_alambronEn
            Dim dt_calidad_alambron As New DataTable
            dt_calidad_alambron = objOpSimplesLn.listar_datatable("SELECT calidad,carbono,magneso,fosforo_max,azufre_max FROM J_calidad_alambron WHERE calidad = " & cbo_calidad_real.Text, "PRODUCCION")
            objIngProdLn.ejecutar("UPDATE J_consec_fichas SET numero = (SELECT MAX (numero)+1 FROM J_consec_fichas)", "PRODUCCION")
            objFichaAlambEn.consecutivo = objIngProdLn.consultar_valor("SELECT MAX (numero) FROM J_consec_fichas ", "PRODUCCION")
            objFichaAlambEn.fecha = objOpSimplesLn.cambiarFormatoFecha(Now.Date)
            objFichaAlambEn.nit = txtNit.Text
            objFichaAlambEn.nombres = txtNombres.Text
            objFichaAlambEn.codigo = txtCodigo.Text
            objFichaAlambEn.descripcion = txtDescripcion.Text
            objFichaAlambEn.resistencia_real = txt_resis_real.Text
            objFichaAlambEn.rec_real = txt_rec_real.Text
            objFichaAlambEn.proc = cboProcedencia.Text
            objFichaAlambEn.colada = txtColada.Text
            objFichaAlambEn.responsable = cboResponsable.Text
            objFichaAlambEn.coordinador = cboCoordinador.Text
            objFichaAlambEn.peso = txtTotPeso.Text
            objFichaAlambEn.mat_prima = txtMatPrima.Text
            objFichaAlambEn.calidad_real = cbo_calidad_real.Text
            objFichaAlambEn.numero = txt_num_pedido.Text

            objFichaAlambEn.calidad_est = txtCalidad_est.Text
            objFichaAlambEn.rec_est = txtRec_est.Text
            objFichaAlambEn.resistencia_est = txtResis_est.Text
            txtTotPeso.Text = sumarPesos()
            objFichaAlambEn.total_peso = txtTotPeso.Text
            objFichaAlambEn.desc_mat_prima = objIngProdLn.consultar_valor("SELECT descripcion FROM referencias WHERE codigo = '" & txtMatPrima.Text & "'", "CORSAN")

            For i = 0 To dtgRollos.RowCount - 1
                If (dtgRollos.Item("ColPeso", i).Value <> "") Then
                    objDetalleRollosEn.peso = dtgRollos.Item("ColPeso", i).Value
                    objDetalleRollosEn.numRollo = dtgRollos.Item("ColNumRollo", i).Value
                    If (i < 18) Then
                        listDetRollos.Add(objDetalleRollosEn)
                    Else
                        listDetRollos2.Add(objDetalleRollosEn)
                    End If
                    objDetalleRollosEn = New DetalleRollosEn
                End If
            Next
            For i = 0 To dt_calidad_alambron.Rows.Count - 1
                obj_calidad_alambronEn.calidad = dt_calidad_alambron.Rows(i).Item("calidad")
                obj_calidad_alambronEn.carbono = dt_calidad_alambron.Rows(i).Item("carbono")
                obj_calidad_alambronEn.magneso = dt_calidad_alambron.Rows(i).Item("magneso")
                obj_calidad_alambronEn.fosforo_max = dt_calidad_alambron.Rows(i).Item("fosforo_max")
                obj_calidad_alambronEn.azufre_max = dt_calidad_alambron.Rows(i).Item("azufre_max")
            Next
            Dim frm As New FrmReportesManual()
            frm.Main("Reporte de fichas técnicas", objFichaAlambEn, listDetRollos, listDetRollos2, obj_calidad_alambronEn)
            frm.Show()
            guardarCertificado(objFichaAlambEn)
        Else
            MessageBox.Show("Error al generar el reporte , verifique que todos los campos esten debidamente diligenciados!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Private Function validarFrm() As Boolean
        Dim resp As Boolean = False
        Dim sw As Boolean = False
        Dim val1 As String = ""
        Dim val2 As String = ""
        Dim resistencia As String = ""
        If (cbo_calidad_real.Text <> "" And txt_resis_real.Text <> "" And txtColada.Text <> "" And cboCoordinador.Text <> "Seleccione" And cboProcedencia.Text <> "Seleccione" And cboResponsable.Text <> "Seleccione") Then
            If IsNumeric(txt_num_pedido.Text) Then
                If (objOpSimplesLn.existeNumeroPedido(txt_num_pedido.Text)) Then
                    If (objOpSimplesLn.validarCodigo(txtMatPrima.Text)) Then
                        resistencia = Trim(txtResis_est.Text)
                        If IsNumeric(txt_resis_real.Text) Then
                            For i = 0 To resistencia.Length - 1
                                If (resistencia(i) <> "-" And sw = False) Then
                                    val1 &= resistencia(i)
                                Else
                                    sw = True
                                    If (resistencia(i) <> "-") Then
                                        val2 &= resistencia(i)
                                    End If
                                End If
                            Next
                            If (val1 <> "" And val2 <> "") Then
                                If (Convert.ToDouble(txt_resis_real.Text) >= Convert.ToDouble(val1) And Convert.ToDouble(txt_resis_real.Text) <= Convert.ToDouble(val2)) Then
                                    resp = True
                                Else
                                    MessageBox.Show("La resistencia no esta fuera del rango establecido con la ficha técnica!", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                End If
                            End If
                        Else
                            MessageBox.Show("El valor ingresado para la resistencia debe ser númerico!", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    Else
                        MessageBox.Show("El codigo " & txtMatPrima.Text & " ingresado para la materia prima, no exsiste verifique!,NO SE GUARDO LA PLANILLA!", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Else
                    MessageBox.Show("El número de pedido ingresado no existe", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                MessageBox.Show("Ingrese el número de pedido!", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
        Return resp
    End Function

    Private Sub dtgRollos_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dtgRollos.KeyPress
        'If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
        '    Dim fila As Integer = dtgRollos.CurrentCell.RowIndex
        '    If Not IsNumeric(dtgRollos.Item("ColPeso", fila).Value) Then
        '        MessageBox.Show("Verifique que el dato ingresado en el peso del rollo sea númerico!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '        dtgRollos.Item("ColPeso", fila).Value = ""
        '    Else
        '        txtTotPeso.Text = sumarPesos()
        '        dtgRollos.Rows.Add()
        '        dtgRollos.Item("ColNumRollo", fila + 1).Value = fila + 2
        '    End If
        'End If
    End Sub

    Private Sub dtgRollos_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgRollos.CellValueChanged
        If (carga_comp) Then
            Dim fila As Integer = dtgRollos.CurrentCell.RowIndex
            If (dtgRollos.Columns(e.ColumnIndex).Name = "ColPeso") Then
                If Not IsNumeric(dtgRollos.Item("ColPeso", fila).Value) Then
                    MessageBox.Show("Verifique que el dato ingresado en el peso del rollo sea númerico!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    dtgRollos.Item("ColPeso", fila).Value = ""
                Else
                    txtTotPeso.Text = sumarPesos()
                    dtgRollos.Rows.Add()
                    dtgRollos.Item("ColNumRollo", fila + 1).Value = fila + 2
                End If
            End If
        End If

    End Sub
    Private Sub guardarCertificado(ByVal objFichaAlambEn As FichaAlambEn)
        Dim listSql As New List(Of Object)
        Dim sqlInsertRollo As String = "INSERT INTO J_rollos_certificados (numero_cert,num_rollo,peso)  VALUES "
        Dim sqlRollos As String = ""
        Dim sqlEncabezado As String = "INSERT INTO J_certificado_calidad " & _
           "(numero,fecha,nit,codigo,recurbrimiento,resistencia,procedencia,mat_prima,colada,calidad,responsable,coordinador,numero_pedido) " & _
        "VALUES " & _
          "(" & objFichaAlambEn.consecutivo & ",'" & objFichaAlambEn.fecha & "'," & objFichaAlambEn.nit & ",'" & objFichaAlambEn.codigo & "','" & objFichaAlambEn.rec_real & "','" & objFichaAlambEn.resistencia_real & "','" & cboProcedencia.SelectedValue & "','" & objFichaAlambEn.mat_prima & "','" & objFichaAlambEn.colada & "'," & objFichaAlambEn.calidad_real & "," & cboResponsable.SelectedValue & "," & cboCoordinador.SelectedValue & "," & objFichaAlambEn.numero & ") "
        listSql.Add(sqlEncabezado)
        For i = 0 To dtgRollos.RowCount - 1
            If IsNumeric(dtgRollos.Item("ColPeso", i).Value) Then
                sqlRollos = sqlInsertRollo & "(" & objFichaAlambEn.consecutivo & "," & dtgRollos.Item("ColNumRollo", i).Value & "," & dtgRollos.Item("ColPeso", i).Value & ")"
                listSql.Add(sqlRollos)
            End If
        Next
        If Not (objIngProdLn.ExecuteSqlTransaction(listSql, "PRODUCCION")) Then
            MessageBox.Show("Error al guardar el historico del certificado, comuniquese con el administrador del sistema!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

    Private Sub cboResponsable_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboResponsable.SelectedIndexChanged

    End Sub
End Class