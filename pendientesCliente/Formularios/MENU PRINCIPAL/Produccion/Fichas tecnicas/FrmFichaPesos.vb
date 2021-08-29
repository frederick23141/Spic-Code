Imports System.Configuration
Imports logicaNegocios
Imports entidadNegocios
Public Class FrmFichaPesos
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
    Private Sub FrmFichaPesos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargarDataSourse()
        cboProcedencia.SelectedValue = procedencia
        dtgRollos.Rows.Add()
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


        sql = "Select nit,nombres  from V_nom_personal_Activo_con_maquila WHERE nit in (98479325,9760043,98550501,1026135742,1128268007) ORDER BY nombres "
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


        sql = "Select nit,nombres  from V_nom_personal_Activo_con_maquila WHERE nit in (1130677175) ORDER BY nombres "
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
                Dim num_rollo As String = InputBox("Ingrese el número del rollo de la orden de producción", "Ingrese el número del rollo")
                If IsNumeric(num_rollo) Then
                    If existe_rollo(num_rollo) Then
                        cargar_rollo(num_rollo, fila)
                        txtTotPeso.Text = sumarPesos()
                    Else
                        MessageBox.Show("El número de rollo ya fue ingresado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Else
                    MessageBox.Show("Verifique que el dato ingresado en el peso del rollo sea númerico!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

            End If
        End If
    End Sub
    Private Function existe_rollo(ByVal numero As Integer) As Boolean
        Dim resp As Boolean = True
        For i = 0 To dtgRollos.Rows.Count - 1
            If IsNumeric(dtgRollos.Item(ColNumRollo.Name, i).Value) Then
                If dtgRollos.Item(ColNumRollo.Name, i).Value = numero Then
                    resp = False
                End If
            End If
        Next
        Return resp
    End Function
    Private Function sumarPesos() As Integer
        Dim suma As Integer = 0
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
            objFichaAlambEn.rec_real = txt_rec_real.Text
            objFichaAlambEn.proc = cboProcedencia.Text
            objFichaAlambEn.responsable = cboResponsable.Text
            objFichaAlambEn.coordinador = cboCoordinador.Text

            Dim sas As Double = Format(Convert.ToDouble(txtTotPeso.Text), "#0.0")
            objFichaAlambEn.peso = sas
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
                If IsNumeric(dtgRollos.Item(ColPeso.Name, i).Value) Then
                    Dim peso As Double = Format(dtgRollos.Item("ColPeso", i).Value, "#0.0")
                    objDetalleRollosEn.peso = peso
                    objDetalleRollosEn.numRollo = dtgRollos.Item("ColNumRollo", i).Value
                    objDetalleRollosEn.colada = dtgRollos.Item(col_colada.Name, i).Value
                    objDetalleRollosEn.traccion = dtgRollos.Item(col_traccion.Name, i).Value
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
            Dim frm As New FrmReportesFichas()
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
        If (cbo_calidad_real.Text <> "" And cboCoordinador.Text <> "Seleccione" And cboProcedencia.Text <> "Seleccione" And cboResponsable.Text <> "Seleccione") Then
            If IsNumeric(txt_num_pedido.Text) Then
                If (objOpSimplesLn.existeNumeroPedido(txt_num_pedido.Text)) Then
                    If (objOpSimplesLn.validarCodigo(txtMatPrima.Text)) Then
                        If dtgRollos.Rows.Count > 0 Then
                            resp = True
                        Else
                            MessageBox.Show("Ingrese rollos", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

    'Private Sub dtgRollos_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgRollos.CellValueChanged
    '    If (carga_comp) Then
    '        Dim fila As Integer = dtgRollos.CurrentCell.RowIndex
    '        If (dtgRollos.Columns(e.ColumnIndex).Name = "ColPeso") Then
    '            If Not IsNumeric(dtgRollos.Item("ColPeso", fila).Value) Then
    '                MessageBox.Show("Verifique que el dato ingresado en el peso del rollo sea númerico!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '                dtgRollos.Item("ColPeso", fila).Value = ""
    '            Else
    '                txtTotPeso.Text = sumarPesos()
    '                dtgRollos.Rows.Add()
    '                dtgRollos.Item("ColNumRollo", fila + 1).Value = fila + 2
    '            End If
    '        End If
    '    End If

    'End Sub
    Private Sub guardarCertificado(ByVal objFichaAlambEn As FichaAlambEn)
        Dim listSql As New List(Of Object)
        Dim sqlInsertRollo As String = "INSERT INTO J_rollos_certificados (numero_cert,num_rollo,peso,colada,traccion)  VALUES "
        Dim sqlRollos As String = ""
        Dim sqlEncabezado As String = "INSERT INTO J_certificado_calidad " & _
           "(numero,fecha,nit,codigo,recurbrimiento,resistencia,procedencia,mat_prima,colada,calidad,responsable,coordinador,numero_pedido) " & _
        "VALUES " & _
          "(" & objFichaAlambEn.consecutivo & ",'" & objFichaAlambEn.fecha & "'," & objFichaAlambEn.nit & ",'" & objFichaAlambEn.codigo & "','" & objFichaAlambEn.rec_real & "','" & objFichaAlambEn.resistencia_real & "','" & cboProcedencia.SelectedValue & "','" & objFichaAlambEn.mat_prima & "','" & objFichaAlambEn.colada & "'," & objFichaAlambEn.calidad_real & "," & cboResponsable.SelectedValue & "," & cboCoordinador.SelectedValue & "," & objFichaAlambEn.numero & ") "
        listSql.Add(sqlEncabezado)
        For i = 0 To dtgRollos.RowCount - 1
            If IsNumeric(dtgRollos.Item("ColPeso", i).Value) Then
                sqlRollos = sqlInsertRollo & "(" & objFichaAlambEn.consecutivo & "," & dtgRollos.Item("ColNumRollo", i).Value & "," & dtgRollos.Item("ColPeso", i).Value & ",'" & dtgRollos.Item(col_colada.Name, i).Value & "'," & dtgRollos.Item(col_traccion.Name, i).Value & ")"
                listSql.Add(sqlRollos)
            End If
        Next
        If Not (objIngProdLn.ExecuteSqlTransaction(listSql, "PRODUCCION")) Then
            MessageBox.Show("Error al guardar el historico del certificado, comuniquese con el administrador del sistema!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

    Private Sub cargar_orden_produccion()
        Dim orden As String = extraerDatoCodigoBarras("orden", txt_orden_produccion.Text)
        Dim detalle As String = extraerDatoCodigoBarras("detalle", txt_orden_produccion.Text)
        If orden <> "" And detalle <> "" Then
            Dim sql As String = "SELECT origen,cod_alambron,calidad ,prod_final FROM J_orden_prod_tef WHERE consecutivo =" & orden
            Dim dt As DataTable = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")
            If dt.Rows.Count > 0 Then
                For i = 0 To dt.Rows.Count - 1
                    cboProcedencia.SelectedValue = dt.Rows(i).Item("origen")
                    If Not IsDBNull(dt.Rows(i).Item("cod_alambron")) Then
                        txtMatPrima.Text = dt.Rows(i).Item("cod_alambron")
                    Else
                        txtMatPrima.Text = ""
                    End If
                    cbo_calidad_real.SelectedValue = dt.Rows(i).Item("calidad")
                Next
            Else
                MessageBox.Show("Número de orden de produccion no existe", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            MessageBox.Show("Orden de producción incompleta,ingrese todos los datos del consecutivo ######-##-## ", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
    Private Sub cargar_rollo(ByVal num_rollo As Integer, ByVal fila As Integer)
        Dim orden As Double = extraerDatoCodigoBarras("orden", txt_orden_produccion.Text)
        Dim detalle As Double = extraerDatoCodigoBarras("detalle", txt_orden_produccion.Text)
        Dim sql As String = "SELECT peso,colada,traccion FROM J_rollos_tref WHERE cod_orden = " & orden & " AND id_detalle = " & detalle & " AND id_rollo =" & num_rollo
        Dim dt As DataTable = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")
        Dim val1 As String = ""
        Dim val2 As String = ""
        Dim resistencia As String = Trim(txtResis_est.Text)
        Dim contSeparador As Integer = 0
        Dim resistencia_real As Integer = 0
        For i = 0 To resistencia.Length - 1
            If (contSeparador = 0) Then
                If (resistencia(i) <> "-") Then
                    val1 &= resistencia(i)
                End If
            ElseIf (contSeparador = 1) Then
                If (resistencia(i) <> "-") Then
                    val2 &= resistencia(i)
                End If
            End If
            If (resistencia(i) = "-") Then
                contSeparador += 1
            End If
        Next
        If dt.Rows.Count > 0 Then
            For i = 0 To dt.Rows.Count - 1
                If (val1 <> "" And val2 <> "") Then
                    resistencia_real = dt.Rows(i).Item("traccion")
                    If (Convert.ToDouble(resistencia_real) >= Convert.ToDouble(val1) And Convert.ToDouble(resistencia_real) <= Convert.ToDouble(val2)) Then
                        dtgRollos.Rows.Add()
                        fila = dtgRollos.Rows.Count - 1
                        dtgRollos.Item(ColNumRollo.Name, fila).Value = num_rollo
                        dtgRollos.Item(ColPeso.Name, fila).Value = Convert.ToInt32(dt.Rows(i).Item("peso"))
                        'dtgRollos.Item(ColPeso.Name, fila).Value = dt.Rows(i).Item("peso")
                        dtgRollos.Item(col_colada.Name, fila).Value = dt.Rows(i).Item("colada")
                        dtgRollos.Item(col_traccion.Name, fila).Value = dt.Rows(i).Item("traccion")
                    Else
                        MessageBox.Show("La resistencia no esta fuera del rango establecido con la ficha técnica!", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If
            Next
        Else
            MessageBox.Show("Número de rollo no existe", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

    End Sub
    Public Function extraerDatoCodigoBarras(ByVal dato As String, ByVal codigoBarra As String) As String
        Dim numSeparador As Integer = 0
        Dim contSeparador As Integer = 0
        Dim respuesta As String = ""
        Select Case dato
            Case "orden"
                numSeparador = 0
            Case "detalle"
                numSeparador = 1
            Case "rollo"
                numSeparador = 2
        End Select
        For i = 0 To codigoBarra.Length - 1
            If (numSeparador = contSeparador) Then
                If (codigoBarra(i) <> "-") Then
                    respuesta &= codigoBarra(i)
                End If
            End If
            If (codigoBarra(i) = "-") Then
                contSeparador += 1
            End If
        Next
        Return respuesta
    End Function

    Private Sub btn_cargar_orden_Click(sender As Object, e As EventArgs) Handles btn_cargar_orden.Click
        If txt_orden_produccion.Text <> "" Then
            cargar_orden_produccion()
        Else
            MessageBox.Show("Ingrese número de orden de producción", "Ingrese orden de producción", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
End Class