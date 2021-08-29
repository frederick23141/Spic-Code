Imports logicaNegocios
Imports Microsoft.VisualBasic.PowerPacks.Printing.Compatibility.VB6
Imports System.Drawing.Printing
Public Class Frm_tiquetes_alambron
    Private objOpSimplsLn As New Op_simpesLn
    Dim carga_comp As Boolean = False
    Dim filaSelect As Integer = 0
    Private Declare Function GetTickCount Lib "kernel32" () As Integer
    Declare Function SetDefaultPrinter Lib "winspool.drv" Alias "SetDefaultPrinterA" (ByVal pszPrinter As String) As Boolean
    Private Sub Frm_tiquetes_alambron_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        dtg_consulta.Rows.Add()
        dtg_consulta.Item(col_modificar.Name, dtg_consulta.Rows.Count - 1).Value = "S"
        cargar_molinos()
        cargar_proveedores()
        cargar_tipo()
        cargar_consult_imp()
        carga_comp = True

    End Sub

    Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
        If validar() Then
            dtg_consulta.CurrentCell = Nothing
            Dim insert As Boolean = False
            Dim listSql As New List(Of Object)
            Dim num_importacion As String = txtNumImportacion.Text
            Dim molino As String = cbo_molino.SelectedValue
            Dim fecha As String = objOpSimplsLn.cambiarFormatoFecha(cbo_fecha.Value)
            Dim nit_proveedor As Double = cbo_provedor.SelectedValue
            Dim tipo As String = cbo_tipo.SelectedValue
            Dim modelo As String = cbo_modelo.SelectedValue
            Dim sql_det_gral As String = ""
            Dim where_update_det As String = ""
            Dim sql_enc As String = ""

            Dim sql_id As String = "SELECT (CASE WHEN MAX (id_det) is null THEN 0 ELSE MAX (id_det)  END) " & _
                                                                                "FROM J_alambron_solicitud_det " & _
                                                                                    "WHERE nit_proveedor =" & nit_proveedor & " AND num_importacion = " & num_importacion
            Dim id_det As Integer = objOpSimplsLn.consultValorTodo(sql_id, "PRODUCCION")
            If Not existe_importacion() Then
                insert = True
            End If
            If insert Then
                sql_enc = "INSERT INTO J_alambron_solicitud_enc " & _
                                       "(numero_importacion, fecha, molino, nit_proveedor, tipo, modelo) " & _
                                           "VALUES (" & num_importacion & ", '" & fecha & "', " & molino & ", " & nit_proveedor & ", '" & tipo & "', '" & modelo & "')"
                listSql.Add(sql_enc)
            End If
            sql_det_gral = "INSERT INTO J_alambron_solicitud_det " & _
                                       "(num_importacion,nit_proveedor, id_det, codigo, costo_kilo, cantidad) " & _
                                           "VALUES(" & num_importacion & " , " & nit_proveedor

            Dim sql_det As String = ""
            For i = 0 To dtg_consulta.RowCount - 1
                If Not IsDBNull(dtg_consulta.Item(colCodigo.Name, i).Value) And Not IsDBNull(dtg_consulta.Item(col_cant.Name, i).Value) And Not IsDBNull(dtg_consulta.Item(col_costo_kilo.Name, i).Value) Then
                    If Not IsNothing(dtg_consulta.Item(colCodigo.Name, i).Value) And Not IsNothing(dtg_consulta.Item(col_cant.Name, i).Value) And Not IsNothing(dtg_consulta.Item(col_costo_kilo.Name, i).Value) Then
                        id_det += 1
                        If dtg_consulta.Item(col_modificar.Name, i).Value = "S" Then
                            sql_det = sql_det_gral & "," & id_det & ",'" & dtg_consulta.Item(colCodigo.Name, i).Value & "'," & dtg_consulta.Item(col_costo_kilo.Name, i).Value & "," & dtg_consulta.Item(col_cant.Name, i).Value & ")"
                            listSql.Add(sql_det)
                            dtg_consulta.Item(col_id_det.Name, i).Value = id_det
                        End If
                    End If
                End If
            Next
            If listSql.Count = 0 Or sql_det = "" Then
                MessageBox.Show("No se selccionaron datos para hacerles modificaciones", "No se modifico", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                If (objOpSimplsLn.ExecuteSqlTransactionTodo(listSql, "PRODUCCION")) Then
                    MessageBox.Show("La solicitud se ingreso en forma correcta!", "Correcto!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    For i = 0 To dtg_consulta.RowCount - 1
                        dtg_consulta.Item(col_modificar.Name, i).Value = "N"
                    Next
                Else
                    MessageBox.Show("Error al ingresar la solicitud, comuniquese con el administrador del sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
     
            bloquear_no_modificables()
        End If
    End Sub
    Private Sub bloquear_campos(ByVal estado As Boolean)
        cbo_provedor.Enabled = estado
        txtNumImportacion.ReadOnly = estado
        cbo_molino.Enabled = estado
        cbo_tipo.Enabled = estado
        cbo_modelo.Enabled = estado
        cbo_fecha.Enabled = estado
    End Sub
    Private Function validar() As Boolean
        If txtNumImportacion.Text <> "" And cbo_molino.Text <> "Seleccione" And cbo_modelo.Text <> "Seleccione" And cbo_tipo.Text <> "Seleccione" And cbo_provedor.Text <> "Seleccione" Then
            If validarDtg() Then
                Return True
            Else
                Return False
            End If
        Else
            MessageBox.Show("Debe ingresar todos los campos requeridos!", "Verifique!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
    End Function
    Private Function existe_importacion() As Boolean
        Dim sql As String = "SELECT numero_importacion FROM J_alambron_solicitud_enc WHERE numero_importacion =" & txtNumImportacion.Text & " AND nit_proveedor =" & cbo_provedor.SelectedValue
        Dim numero As String = objOpSimplsLn.consultValorTodo(sql, "PRODUCCION")
        If numero = "" Then
            Return False
        Else
            Return True
        End If
    End Function
    Private Function existe_importacion_rollos(ByVal id_detalle As Double) As Boolean
        Dim numero As String = objOpSimplsLn.consultValorTodo("SELECT  num_importacion FROM J_alambron_importacion_det_rollos WHERE numero_importacion =" & txtNumImportacion.Text & " AND  id_solicitud_det =" & id_detalle & " AND  nit_proveedor =" & cbo_provedor.SelectedValue, "PRODUCCION")
        If numero = "" Then
            Return False
        Else
            MessageBox.Show("Este número de importacion ya existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return True
        End If
    End Function
    Private Sub cargar_consult_imp()
        Dim dt As New DataTable
        Dim sql As String = "SELECT  CAST(numero_importacion AS varchar(25))As numero_importacion  " & _
                                "FROM J_alambron_solicitud_enc " & _
                                    "WHERE nit_proveedor = " & cbo_consult_prov.SelectedValue

        dt = objOpSimplsLn.listar_datatable(sql, "PRODUCCION")
        dt.Rows.Add()
        dt.Rows(dt.Rows.Count - 1).Item("numero_importacion") = 0
        dt.Rows(dt.Rows.Count - 1).Item("numero_importacion") = "Seleccione"
        cbo_consult_importacion.DataSource = dt
        cbo_consult_importacion.ValueMember = "numero_importacion"
        cbo_consult_importacion.DisplayMember = "numero_importacion"
        cbo_consult_importacion.SelectedValue = "Seleccione"
    End Sub
    Private Sub cargar_molinos()

        Dim sql As String = "SELECT nit,nombres " & _
                                "FROM terceros WHERE nit IN (SELECT nit FROM Jjv_prov_alambron) OR nit IN (999999999) "
        Dim dt As DataTable = objOpSimplsLn.listar_datatable(sql, "CORSAN")
        dt.Rows.Add()
        dt.Rows(dt.Rows.Count - 1).Item("nit") = 0
        dt.Rows(dt.Rows.Count - 1).Item("nombres") = "Seleccione"
        cbo_molino.DataSource = dt
        cbo_molino.ValueMember = "nit"
        cbo_molino.DisplayMember = "nombres"
        cbo_molino.SelectedValue = 0
    End Sub
  
    Private Sub cargar_proveedores()
        Dim sql As String = "SELECT nit,nombres " & _
                                "FROM terceros " & _
                                    "WHERE  concepto_1 IN (07,9) OR nit IN (999999999) " & _
                                        "ORDER BY nombres"
        Dim dt As DataTable = objOpSimplsLn.listar_datatable(sql, "CORSAN")
        dt.Rows.Add()
        dt.Rows(dt.Rows.Count - 1).Item("nit") = 0
        dt.Rows(dt.Rows.Count - 1).Item("nombres") = "Seleccione"
        cbo_provedor.DataSource = dt
        cbo_provedor.ValueMember = "nit"
        cbo_provedor.DisplayMember = "nombres"
        cbo_provedor.SelectedValue = 0

        dt = New DataTable
        sql = "SELECT nit_proveedor As nit, t.nombres FROM J_alambron_solicitud_enc e, CORSAN.dbo.terceros t WHERE t.nit = e.nit_proveedor group by nit_proveedor, t.nombres"
        dt = objOpSimplsLn.listar_datatable(sql, "PRODUCCION")
        dt.Rows.Add()
        dt.Rows(dt.Rows.Count - 1).Item("nit") = 0
        dt.Rows(dt.Rows.Count - 1).Item("nombres") = "Seleccione"
        cbo_consult_prov.DataSource = dt
        cbo_consult_prov.ValueMember = "nit"
        cbo_consult_prov.DisplayMember = "nombres"
        cbo_consult_prov.SelectedValue = 0
    End Sub
    Private Sub cargar_tipo()
        Dim sql As String = "SELECT tipo,tipo + ' - ' + descripcion As descripcion " & _
                           "FROM tipo_transacciones " & _
                               "WHERE tipo IN ('EIMP','CMP1','EAIS')"
        Dim dt As DataTable = objOpSimplsLn.listar_datatable(sql, "CORSAN")
        dt.Rows.Add()
        dt.Rows(dt.Rows.Count - 1).Item("tipo") = 0
        dt.Rows(dt.Rows.Count - 1).Item("descripcion") = "Seleccione"
        cbo_tipo.DataSource = dt
        cbo_tipo.ValueMember = "tipo"
        cbo_tipo.DisplayMember = "descripcion"
        cbo_tipo.SelectedValue = 0
    End Sub
    Private Sub cargar_modelo()
        Dim sql As String = "SELECT CAST( modelo As varchar) As modelo,tipo + ' - ' + modelo + ' - ' + descripcion As descripcion " & _
                                "FROM tipo_transacciones_mod " & _
                                    "WHERE tipo ='" & cbo_tipo.SelectedValue & "'"
        Dim dt As DataTable = objOpSimplsLn.listar_datatable(sql, "CORSAN")
        dt.Rows.Add()
        dt.Rows(dt.Rows.Count - 1).Item("modelo") = 0
        dt.Rows(dt.Rows.Count - 1).Item("descripcion") = "Seleccione"
        cbo_modelo.DataSource = dt
        cbo_modelo.ValueMember = "modelo"
        cbo_modelo.DisplayMember = "descripcion"
        cbo_modelo.SelectedValue = 0
    End Sub

    Private Sub soloNumero(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If (Char.IsDigit(e.KeyChar) Or e.KeyChar = ".") Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtNumImportacion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNumImportacion.KeyPress
        soloNumero(e)
    End Sub

    Private Sub txt_vr_kilo_KeyPress(sender As Object, e As KeyPressEventArgs)
        soloNumero(e)
    End Sub

    Private Function validarDtg() As Boolean
        Dim resp As Boolean = True
        If dtg_consulta.RowCount > 0 Then
            For i = 0 To dtg_consulta.RowCount - 1
                If Not IsDBNull(dtg_consulta.Item(col_cant.Name, i).Value) Or Not IsDBNull(dtg_consulta.Item(colCodigo.Name, i).Value) Or Not IsDBNull(dtg_consulta.Item(col_costo_kilo.Name, i).Value) Then
                    If IsDBNull(dtg_consulta.Item(col_cant.Name, i).Value) Or IsDBNull(dtg_consulta.Item(colCodigo.Name, i).Value) Or IsDBNull(dtg_consulta.Item(col_costo_kilo.Name, i).Value) Then
                        resp = False
                    End If
                End If
            Next
        Else
            resp = False
        End If
        If resp = False Then
            MessageBox.Show("Verifique que los datos de petición de tiquetes esten correctos", "Verifique!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Return resp
    End Function

    Private Sub dtg_consulta_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtg_consulta.CellClick
        If dtg_consulta.Columns(e.ColumnIndex).Name = colBorrar.Name Then
            If dtg_consulta.Item(col_modificar.Name, dtg_consulta.Rows.Count - 1).Value = "N" Then
                MessageBox.Show("No se permite borrar,por que ya se guardo la importación", "No permitido!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                dtg_consulta.Rows.RemoveAt(e.RowIndex)
            End If

        ElseIf dtg_consulta.Columns(e.ColumnIndex).Name = colAdd.Name Then
            dtg_consulta.Rows.Add()
            dtg_consulta.Item(col_modificar.Name, dtg_consulta.Rows.Count - 1).Value = "S"
        ElseIf dtg_consulta.Columns(e.ColumnIndex).Name = col_imprimir.Name Then
            imprimir(e.RowIndex)
        ElseIf (dtg_consulta.Columns(e.ColumnIndex).Name = colCodigo.Name Or dtg_consulta.Columns(e.ColumnIndex).Name = col_desc.Name) Then
            groupCodigo.Visible = True
            txtDesc.Focus()
        End If
        filaSelect = e.RowIndex
    End Sub

    Private Sub cbo_tipo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbo_tipo.SelectedIndexChanged
        If carga_comp Then
            If cbo_tipo.Text <> "Seleccione" Then
                cargar_modelo()
            End If
        End If
    End Sub
    Private Sub imprimir(ByVal fila As Integer)
        If validar() Then
            If existe_importacion() Then
                If validar_Codigo(dtg_consulta.Item(colCodigo.Name, fila).Value) Then
                    Dim copia As Boolean = False
                    Dim resp As Integer = MessageBox.Show("Desea sacar copia por tiquete? ", "Copia?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                    If resp = 6 Then
                        copia = True
                    End If
                    Dim num_importacion As Double = txtNumImportacion.Text
                    Dim molino As String = cbo_molino.Text
                    Dim fecha As String = objOpSimplsLn.cambiarFormatoFecha(cbo_fecha.Value)
                    Dim costo_kilo As Double = 0
                    Dim num_tiquetes As Integer = 0
                    Dim codigo As String = ""
                    Dim descripcion As String = ""
                    Dim id_sol_detalle As Integer = 0
                    Dim nit_proveedor As Double = cbo_provedor.SelectedValue
                    costo_kilo = dtg_consulta.Item(col_costo_kilo.Name, fila).Value
                    codigo = dtg_consulta.Item(colCodigo.Name, fila).Value
                    descripcion = dtg_consulta.Item(col_desc.Name, fila).Value
                    num_tiquetes = dtg_consulta.Item(col_cant.Name, fila).Value
                    id_sol_detalle = dtg_consulta.Item(col_id_det.Name, fila).Value
                    If generarConsecutivos(num_tiquetes, codigo, cbo_fecha.Value, num_importacion, molino, costo_kilo, id_sol_detalle, descripcion, nit_proveedor, copia) Then
                        MessageBox.Show("Los códigos de barra se generaron en forma correcta", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End If
            Else
                MessageBox.Show("Se debe primero guardar la solicitud!", "Guarde solicitud!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        End If
    End Sub

    Private Function generarConsecutivos(ByVal cantidad As Integer, ByVal codigo As String, ByVal fecha As Date, ByVal num_importacion As String, ByVal molino As String, ByVal costo_kilo As Double, ByVal id_solicitud_det As Integer, ByVal descripcion As String, ByVal nit_proveedor As Double, ByVal copia As Boolean) As Boolean
        Dim resp As Boolean = True
        Dim consecutivo As String = nit_proveedor & "-" & num_importacion & "-" & id_solicitud_det & "-"
        Dim sql_plantila_insert As String = ""
        Dim consecutivoTotal As String = ""
        Dim sql_insert As String = "INSERT INTO J_alambron_importacion_det_rollos (limite_consumos,num_importacion,id_solicitud_det,nit_proveedor,numero_rollo) VALUES(2," & num_importacion & "," & id_solicitud_det & "," & nit_proveedor & ","
        Dim sql_insert_total As String = ""
        Dim num_copias As Integer = 0
        Dim ConfiguracionesDeImpresion As New PrinterSettings
        Dim imp_prederteminada As String = ConfiguracionesDeImpresion.PrinterName
        If validar_consecutivo(num_importacion, id_solicitud_det, nit_proveedor) Then
            Dim a = Frm_imprimir_alambron.ShowDialog()
            For i = 1 To cantidad
                consecutivoTotal = consecutivo & i
                sql_insert_total = sql_insert & i & ")"
                If objOpSimplsLn.ejecutar(sql_insert_total, "PRODUCCION") > 0 Then
                    If copia Then
                        num_copias = 1
                    End If
                    For k = 0 To num_copias
                        imprimir_codigos(consecutivoTotal, codigo, fecha, num_importacion, descripcion)
                    Next
                    Dim retraso As Integer
                    retraso = 1800 + GetTickCount
                    While retraso >= GetTickCount
                        Application.DoEvents()
                    End While
                Else
                    MessageBox.Show("Error al generar el consecutivo del rollo número " & i, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Next
            SetDefaultPrinter(imp_prederteminada)
        Else
            resp = False
        End If

        Return resp
    End Function
    Private Function validar_consecutivo(ByVal num_importacion As Double, ByVal id_solicitud_det As Double, nit_proveedor As Double) As Boolean
        Dim resp As Boolean = True
        Dim sql As String = "SELECT numero_rollo FROM J_alambron_importacion_det_rollos " &
                                "WHERE num_importacion = " & num_importacion & " AND id_solicitud_det = " & id_solicitud_det & " AND nit_proveedor=" & nit_proveedor
        If objOpSimplsLn.consultValorTodo(sql, "PRODUCCION") <> "" Then
            MessageBox.Show("Los códigos de barra ya se generarón!", "Códigos ya se generaron", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            resp = False
        End If
        Return resp
    End Function
    Private Function validar_Codigo(ByVal codigo As String)
        Dim resp As Boolean = False
        Dim sql As String = "select codigo from referencias where  codigo='" & codigo & "' and ref_anulada<>'S'"
        If objOpSimplsLn.consultValorTodo(sql, "CORSAN") <> "" Then
            resp = True
        Else
            MessageBox.Show("El codigo esta desactivado o no existe!", "Codigo no existe o desactivado", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Return resp
    End Function
    Private Sub imprimir_codigos(ByVal consecutivo As String, ByVal codigo As String, ByVal fecha As Date, ByVal num_importacion As String, ByVal descripcion As String)
        Dim proc As New Process
        modificarPlantilla(consecutivo, codigo, fecha, num_importacion, descripcion)
        proc.StartInfo.FileName = Environment.CurrentDirectory & "\plantillaAlambronImp.txt"
        proc.StartInfo.Verb = "Print"
        proc.StartInfo.CreateNoWindow = False
        proc.Start()
        '  Esperar(2000)
        ' System.Threading.Thread.Sleep(2000)
    End Sub

    Private Sub modificarPlantilla(ByVal consecutivo As String, ByVal codigo As String, ByVal fecha As Date, ByVal num_importacion As String, ByVal descripcion As String)
        Dim fic As String = Environment.CurrentDirectory & "\plantillaAlambron.txt"
        Dim nuevoFic As String = Environment.CurrentDirectory & "\plantillaAlambronImp.txt"
        Dim sw As New System.IO.StreamWriter(nuevoFic)
        Dim texto As String
        Dim sr As New System.IO.StreamReader(fic)
        Dim molino As String = cbo_molino.Text
        Dim proveedor As String = cbo_provedor.Text
        texto = sr.ReadToEnd()
        texto = Replace(texto, "@codigo", codigo)
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
    Private Function codigoLEtraEspecial(ByVal texto As String) As String
        Dim resp As String = ""
        For i = 0 To texto.Length - 1
            If (texto(i) = "ñ" Or texto(i) = "Ñ") Then
                resp &= "\A5"
            Else
                resp &= texto(i)
            End If
        Next
        Return resp
    End Function


    Private Sub PrintDocument1_PrintPage_1(sender As System.Object, e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim font1 As New Font("Arial", 16, FontStyle.Regular)
        e.Graphics.DrawString("prueba", font1, Brushes.Black, 100, 100)
    End Sub

    Private Sub cbo_consult_importacion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbo_consult_importacion.SelectedIndexChanged
  
    End Sub
    Private Sub consultar()
        If cbo_consult_importacion.SelectedValue <> "Seleccione" And cbo_consult_prov.SelectedValue <> 0 Then
            If carga_comp Then
                dtg_consulta.Rows.Clear()
                If cbo_consult_importacion.Text <> "Seleccione" Then
                    Dim num_importacion As Double = cbo_consult_importacion.SelectedValue
                    Dim nit_proveedor As Double = cbo_consult_prov.SelectedValue
                    Dim sql_enc As String = "SELECT id, numero_importacion, fecha, molino, nit_proveedor, tipo, modelo " & _
                                            "FROM J_alambron_solicitud_enc " & _
                                                "WHERE numero_importacion = " & num_importacion & " AND nit_proveedor = " & cbo_consult_prov.SelectedValue
                    Dim sql_det As String = " SELECT num_importacion, id_det, codigo, costo_kilo, cantidad " & _
                                       "FROM J_alambron_solicitud_det " & _
                                           "WHERE num_importacion = " & num_importacion & " AND nit_proveedor = " & nit_proveedor
                    Dim dt_enc As DataTable = objOpSimplsLn.listar_datatable(sql_enc, "PRODUCCION")
                    Dim dt_det As DataTable = objOpSimplsLn.listar_datatable(sql_det, "PRODUCCION")
                    For i = 0 To dt_enc.Rows.Count - 1
                        txtNumImportacion.Text = dt_enc.Rows(i).Item("numero_importacion")
                        cbo_tipo.SelectedValue = dt_enc.Rows(i).Item("tipo")
                        cbo_modelo.SelectedValue = dt_enc.Rows(i).Item("modelo")
                        cbo_molino.SelectedValue = dt_enc.Rows(i).Item("molino")
                        cbo_fecha.Value = dt_enc.Rows(i).Item("fecha")
                        cbo_provedor.SelectedValue = dt_enc.Rows(i).Item("nit_proveedor")
                    Next
                    For i = 0 To dt_det.Rows.Count - 1
                        dtg_consulta.Rows.Add()
                        dtg_consulta.Item(colCodigo.Name, dtg_consulta.RowCount - 1).Value = dt_det.Rows(i).Item("codigo")
                        dtg_consulta.Item(col_desc.Name, dtg_consulta.RowCount - 1).Value = objOpSimplsLn.getDescripcionCodigo(dt_det.Rows(i).Item("codigo"))
                        dtg_consulta.Item(col_cant.Name, dtg_consulta.RowCount - 1).Value = dt_det.Rows(i).Item("cantidad")
                        dtg_consulta.Item(col_costo_kilo.Name, dtg_consulta.RowCount - 1).Value = dt_det.Rows(i).Item("costo_kilo")
                        dtg_consulta.Item(col_modificar.Name, dtg_consulta.Rows.Count - 1).Value = "N"
                        dtg_consulta.Item(col_id_det.Name, dtg_consulta.Rows.Count - 1).Value = dt_det.Rows(i).Item("id_det")
                    Next
                    dtg_consulta.Columns(col_costo_kilo.Name).DefaultCellStyle.Format = "N2"
                End If
            End If
            bloquear_no_modificables()
        Else
            MessageBox.Show("Seleccione proveedor y número de importación!", "Seleccione", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
    Private Sub bloquear_no_modificables()
        For i = 0 To dtg_consulta.Rows.Count - 1
            If dtg_consulta.Item(col_modificar.Name, i).Value = "N" Then
                dtg_consulta.Rows(i).ReadOnly = False
            End If
        Next
    End Sub
    Private Sub btnCerrarEditResp_Click(sender As Object, e As EventArgs) Handles btnCerrarEditResp.Click
        groupCodigo.Visible = False
        dtgCodigo.DataSource = Nothing
    End Sub

    Private Sub dtgCodigo_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgCodigo.CellClick
        If (e.RowIndex >= 0) Then
            Dim codigo As String = dtgCodigo.Item("codigo", e.RowIndex).Value
            Dim descripcion As String = dtgCodigo.Item("descripcion", e.RowIndex).Value

            
            dtg_consulta.Item(colCodigo.Name, filaSelect).Value = codigo
            dtg_consulta.Item(col_desc.Name, filaSelect).Value = descripcion
            btnCerrarEditResp.PerformClick()
        End If
    End Sub

    Private Sub txtDesc_TextChanged(sender As Object, e As EventArgs) Handles txtDesc.TextChanged
        If (txtDesc.Text.Length > 1) Then
            cargarCodigos("", txtDesc.Text)
        End If
    End Sub

    Private Sub txtCodigo_TextChanged(sender As Object, e As EventArgs) Handles txtCodigo.TextChanged
        If (txtCodigo.Text.Length > 1) Then
            cargarCodigos(txtCodigo.Text, "")
        End If
    End Sub
    Private Sub cargarCodigos(ByVal codigo As String, ByVal descripcion As String)
        Dim where_sql As String = ""
        If (codigo <> "") Then
            where_sql &= " codigo like '" & codigo & "%' "
        ElseIf (descripcion <> "") Then
            where_sql &= " descripcion like '%" & descripcion & "%'"
        End If
        Dim sql As String = "SELECT codigo,descripcion,costo_unitario,generico FROM referencias WHERE " & where_sql & " AND codigo like '1%' AND ref_anulada <>'S'"
        dtgCodigo.DataSource = objOpSimplsLn.listar_datatable(sql, "CORSAN")
    End Sub
    Private Sub cbo_consult_prov_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbo_consult_prov.SelectedIndexChanged
        If carga_comp Then
            If cbo_consult_prov.SelectedValue <> 0 Then
                cargar_consult_imp()
            End If
        End If
    End Sub

    Private Sub cbo_consult_Click(sender As Object, e As EventArgs) Handles btn_consult.Click
        consultar()
    End Sub

    Private Sub btn_nuevo_Click(sender As Object, e As EventArgs) Handles btn_nuevo.Click
        nuevo()
        dtg_consulta.Rows.Clear()
        dtg_consulta.Rows.Add()
        dtg_consulta.Item(col_modificar.Name, dtg_consulta.Rows.Count - 1).Value = "S"
    End Sub
    Private Sub nuevo()
        cbo_consult_importacion.SelectedValue = 0
        cbo_consult_prov.SelectedValue = 0
        cbo_provedor.SelectedValue = 0
        cbo_molino.SelectedValue = 0
        cbo_modelo.SelectedValue = 0
        cbo_tipo.SelectedValue = 0
        txtNumImportacion.Text = ""
    End Sub

    Private Sub groupCodigo_Enter(sender As Object, e As EventArgs) Handles groupCodigo.Enter

    End Sub

    Private Sub cbo_molino_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbo_molino.SelectedIndexChanged

    End Sub
End Class