Imports logicaNegocios
Imports Microsoft.VisualBasic.PowerPacks.Printing.Compatibility.VB6
Imports System.Drawing.Printing
Public Class Frm_generar_tiquetes_terminado
    Private objOpSimplsLn As New Op_simpesLn
    Dim carga_comp As Boolean = False
    Dim filaSelect As Integer = 0
    Private Declare Function GetTickCount Lib "kernel32" () As Integer
    Declare Function SetDefaultPrinter Lib "winspool.drv" Alias "SetDefaultPrinterA" (ByVal pszPrinter As String) As Boolean
    Private objOperacionesForm As OperacionesFormularios = New OperacionesFormularios
    Private Sub soloNumero(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If (Char.IsDigit(e.KeyChar) Or e.KeyChar = ".") Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Function generarTiquetes(ByVal codigo As String, ByVal descripcion As String, ByVal cantidad_empaque As Double, ByVal medida_empaque As String, ByVal cantidad_tiquetes As Integer, ByVal plantilla As String, ByVal plantilla_imp As String, ByVal nombres As String, ByVal ciudad As String, ByVal direccion As String) As Boolean
        Dim resp As Boolean = True
        Dim ConfiguracionesDeImpresion As New PrinterSettings
        Dim imp_prederteminada As String = ConfiguracionesDeImpresion.PrinterName
        Dim a = Frm_imprimir_alambron.ShowDialog()
        For i = 1 To cantidad_tiquetes
            imprimir_codigos(codigo, descripcion, cantidad_empaque, medida_empaque, plantilla, plantilla_imp, nombres, ciudad, direccion)
        Next
        SetDefaultPrinter(imp_prederteminada)
        Return resp
    End Function
    Private Sub imprimir_codigos(ByVal codigo As String, ByVal descripcion As String, ByVal cantidad_empaque As Double, ByVal medida_empaque As String, ByVal plantilla As String, ByVal plantilla_imp As String, ByVal nombres As String, ByVal ciudad As String, ByVal direccion As String)
        Dim proc As New Process
        modificarPlantilla(codigo, descripcion, cantidad_empaque, medida_empaque, plantilla, plantilla_imp, nombres, ciudad, direccion)
        proc.StartInfo.FileName = Environment.CurrentDirectory & "\" & plantilla_imp & ".txt"
        proc.StartInfo.Verb = "Print"
        proc.StartInfo.CreateNoWindow = False
        proc.Start()
    End Sub

    Private Sub modificarPlantilla(ByVal codigo As String, ByVal descripcion As String, ByVal cantidad_empaque As Double, ByVal medida_empaque As String, ByVal plantilla As String, ByVal plantilla_imp As String, ByVal nombres As String, ByVal ciudad As String, ByVal direccion As String)
        Dim fic As String = Environment.CurrentDirectory & "\" & plantilla & ".txt"
        Dim nuevoFic As String = Environment.CurrentDirectory & "\" & plantilla_imp & ".txt"
        Dim sw As New System.IO.StreamWriter(nuevoFic)
        Dim texto As String
        Dim sr As New System.IO.StreamReader(fic)
        texto = sr.ReadToEnd()
        codigo = codigo & "-" & cantidad_empaque
        texto = Replace(texto, "@barras", codigo)
        texto = Replace(texto, "@codigo", codigo)
        texto = Replace(texto, "@descripcion", descripcion)
        texto = Replace(texto, "@cant", cantidad_empaque)
        texto = Replace(texto, "@med", medida_empaque)

        texto = Replace(texto, "@nombres", nombres)
        texto = Replace(texto, "@ciudad", ciudad)
        texto = Replace(texto, "@dir", direccion)
        sr.Close()
        sw.WriteLine(texto)
        sw.Close()
    End Sub
    Private Sub PrintDocument1_PrintPage_1(sender As System.Object, e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim font1 As New Font("Arial", 16, FontStyle.Regular)
        e.Graphics.DrawString("prueba", font1, Brushes.Black, 100, 100)
    End Sub

    Private Sub txt_cant_empaque_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_cant_empaque.KeyPress
        soloNumero(e)
    End Sub

    Private Sub btn_imprimir_Click(sender As Object, e As EventArgs) Handles btn_imprimir.Click
        If cbo_tipo_tiquete.Text <> "SELECCIONE" Then
            Dim estado As Boolean = False
            Select Case cbo_tipo_tiquete.SelectedValue
                Case 1
                    If validar_producto() Then
                        estado = True
                    End If
                Case 2
                    If validar_producto() Then
                        estado = True
                    End If
                Case 4
                    If validar_cliente() And validar_producto() Then
                        estado = True
                    End If
            End Select
            If estado Then
                imprimir_etiquetas()
            End If
        Else
            MessageBox.Show("Seleccione tipo de etiqueta a imprimir", "Seleccione tipo de etiqueta a imprimir", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
    Private Sub imprimir_etiquetas()
        Dim iResponce = MessageBox.Show("Esta seguro que desea imprimir tiquetes para " & cbo_tipo_tiquete.Text & "? ", "Atención", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
        If (iResponce = 6) Then
            Dim estado As Boolean = False
            Dim cantidad As String = InputBox("Ingrese la cantidad de tiquetes a imprimir", "Cantidad")
            Dim codigo As String = txtCodigo.Text
            Dim cant_empaque As String = txt_cant_empaque.Text
            Dim medida As String = cbo_medida.Text
            Dim descripcion As String = txtDesc.Text
            Dim plantilla As String
            Dim plantilla_imp As String = "t_terminado_imp"
            Dim nombres As String = txtNomEtiq.Text
            Dim ciudad As String = txtCiudadEtiq.Text
            Dim direccion As String = txtDirEtiq.Text
            If IsNumeric(cantidad) Then
                Dim int_cantidad As Integer = cantidad
                If (int_cantidad) > 0 Then
                    If cbo_tipo_tiquete.SelectedValue = 1 Then
                        plantilla = "t_terminado_caja"
                        If int_cantidad Mod 2 = 0 Then
                            int_cantidad /= 2
                            estado = True
                        Else
                            MessageBox.Show("El número de tiquetes debe ser par", "El número de tiquetes debe ser par", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If
                    ElseIf cbo_tipo_tiquete.SelectedValue = 2 Then
                        plantilla = "t_terminado_dentro"
                        If int_cantidad Mod 2 = 0 Then
                            int_cantidad /= 2
                            estado = True
                        Else
                            MessageBox.Show("El número de tiquetes debe ser multiplo de 3", "El número de tiquetes debe ser par", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If
                    ElseIf cbo_tipo_tiquete.SelectedValue = 4 Then
                        plantilla = "terminado_cliente_producto"
                        estado = True
                    End If
                    If estado Then
#Disable Warning BC42104 ' La variable 'plantilla' se usa antes de que se le haya asignado un valor. Podría darse una excepción de referencia NULL en tiempo de ejecución.
                        generarTiquetes(codigo, descripcion, cant_empaque, medida, int_cantidad, plantilla, plantilla_imp, nombres, ciudad, direccion)
#Enable Warning BC42104 ' La variable 'plantilla' se usa antes de que se le haya asignado un valor. Podría darse una excepción de referencia NULL en tiempo de ejecución.
                    End If
                Else
                    MessageBox.Show("La cantidad debe ser mayor a 0", "Ingrese cantidad!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                MessageBox.Show("El valor ingresao debe ser númerico", "Cantidad debe ser númerica", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
    End Sub
    Private Function validar_producto() As Boolean
        Dim resp As Boolean = False
        If cbo_medida.Text <> "SELECCIONE" Then
            If txtCodigo.Text <> "" Then
                If txt_cant_empaque.Text <> "" Then
                    If cbo_medida.Text <> "SELECCIONE" Then
                        resp = True
                    Else
                        MessageBox.Show("Seleccione unidad de medida", "Seleccione unidad de medida", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                Else
                    MessageBox.Show("Ingrese cantidad de empaque", "Ingrese cantidad", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                MessageBox.Show("Ingrese código", "Ingrese código", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            MessageBox.Show("Seleccione tipo de tiquete", "Seleccione tipo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Return resp
    End Function
    Private Function validar_cliente() As Boolean
        Dim resp As Boolean = False
        If txtNomEtiq.Text <> "" Then
            If txtCiudadEtiq.Text <> "" Then
                If txtDirEtiq.Text <> "" Then
                    resp = True
                Else
                    MessageBox.Show("Ingrese direccion", "Ingrese direccion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                MessageBox.Show("Ingrese ciudad", "Ingrese ciudad", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            MessageBox.Show("Igrese nombres del cliente", "Igrese nombres del cliente", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Return resp
    End Function
    Private Sub txtCodigo_Click(sender As Object, e As EventArgs) Handles txtCodigo.Click
        Dim frm As New Frm_codigos_terminado
        frm.Main(Me)
        frm.ShowDialog()
    End Sub

    Private Sub txtDesc_Click(sender As Object, e As EventArgs) Handles txtDesc.Click
        Dim frm As New Frm_codigos_terminado
        frm.Main(Me)
        frm.ShowDialog()
    End Sub

    Private Sub cbo_tipo_tiquete_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbo_tipo_tiquete.KeyPress
        e.Handled = False
    End Sub

    Private Sub cbo_medida_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbo_medida.KeyPress
        e.Handled = False
    End Sub

    Private Sub Frm_generar_tiquetes_terminado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cbo_tipo_tiquete.Focus()
        Dim dt As New DataTable
        dt.Columns.Add("id")
        dt.Columns.Add("descripcion")
        dt.Rows.Add()
        dt.Rows(dt.Rows.Count - 1).Item("id") = 0
        dt.Rows(dt.Rows.Count - 1).Item("descripcion") = "SELECCIONE"
        dt.Rows.Add()
        dt.Rows(dt.Rows.Count - 1).Item("id") = 1
        dt.Rows(dt.Rows.Count - 1).Item("descripcion") = "CAJA - MEDIDA(7.3 X 5)"
        dt.Rows.Add()
        dt.Rows(dt.Rows.Count - 1).Item("id") = 2
        dt.Rows(dt.Rows.Count - 1).Item("descripcion") = "PRODUCTO - MEDIDA(5 x 2.5)"
        dt.Rows.Add()
        dt.Rows(dt.Rows.Count - 1).Item("id") = 4
        dt.Rows(dt.Rows.Count - 1).Item("descripcion") = "CLIENTE-PRODUCTO - MEDIDA(10 x 5)"
        cbo_tipo_tiquete.DataSource = dt
        cbo_tipo_tiquete.DisplayMember = "descripcion"
        cbo_tipo_tiquete.ValueMember = "id"
        carga_comp = True
    End Sub

   
    Private Sub cbo_tipo_tiquete_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbo_tipo_tiquete.SelectedIndexChanged
        If carga_comp Then
            Select Case cbo_tipo_tiquete.SelectedValue
                Case 1
                    group_producto.Enabled = True
                    groupCliente.Enabled = False
                Case 2
                    group_producto.Enabled = True
                    groupCliente.Enabled = False
                Case 4
                    group_producto.Enabled = True
                    groupCliente.Enabled = True
            End Select
        End If
    End Sub
    Private Sub txt_nombres_TextChanged(sender As System.Object, e As System.EventArgs) Handles txt_nombres.TextChanged
        If (txt_nombres.Text.Length > 3) Then
            carga_comp = False
            txtNit.Text = ""
            cargar_clientes()
            carga_comp = True
        End If
    End Sub
    Private Sub txtNit_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtNit.TextChanged
        If (txtNit.Text.Length > 3) Then
            carga_comp = False
            txt_nombres.Text = ""
            cargar_clientes()
            carga_comp = True
        End If
    End Sub
    Private Sub cargar_clientes()
        Dim sql As String = "Select nit,nombres,ciudad FROM terceros "
        Dim whereSql As String = "WHERE (concepto_1 like '%3%' or concepto_1 like '%4%' or concepto_1 like '%9%' or  concepto_1 like '%1%') "
        If (txtNit.Text <> "") Then
            whereSql &= "AND nit like '%" & txtNit.Text & "%'"
        ElseIf (txt_nombres.Text <> "") Then
            whereSql &= "AND nombres like '%" & txt_nombres.Text & "%'"
        End If
        sql &= whereSql
        dtg_clientes.DataSource = objOpSimplsLn.listar_datatable(sql, "CORSAN")
    End Sub
    Private Sub dtg_clientes_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtg_clientes.CellContentClick
        If (e.RowIndex >= 0) Then
            If (dtg_clientes.Columns(e.ColumnIndex).Name = colOk.Name) Then
                txtNit.Text = dtg_clientes.Item("nit", e.RowIndex).Value
                dtg_clientes.DataSource = Nothing
                cargar_info_client()
            End If
        End If
    End Sub
    Private Sub cargar_info_client()
        Dim sql As String = "SELECT  nombres,ciudad,direccion FROM terceros WHERE nit =" & txtNit.Text
        Dim dt As DataTable = objOpSimplsLn.listar_datatable(sql, "CORSAN")
        Dim cont_nombres As Integer = 0
        Dim nombre_completo As String = ""
        For i = 0 To dt.Rows.Count - 1
            If Not IsDBNull(dt.Rows(i).Item("nombres")) Then
                txtNomEtiq.Text = dt.Rows(i).Item("nombres")
            End If
            If Not IsDBNull(dt.Rows(i).Item("ciudad")) Then
                txtCiudadEtiq.Text = dt.Rows(i).Item("ciudad")
            End If
            If Not IsDBNull(dt.Rows(i).Item("direccion")) Then
                txtDirEtiq.Text = dt.Rows(i).Item("direccion")
            End If
        Next
    End Sub


End Class