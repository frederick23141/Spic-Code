Imports logicaNegocios
Imports entidadNegocios
Public Class Frm_traslados_bodega
    Dim nit_usuario As String
    Dim objTraslado_bodLn As New traslado_bodLn
    Private obj_Ing_prodLn As New Ing_prodLn
    Private objOpSimplesLn As New Op_simpesLn
    Dim cargaComp As Boolean = False
    Private objEnvCorreoLN As New EnvCorreoLN
    Private nomb_modulo As String
    Private objOrdenProdLn As New OrdenProdLn

    Dim dtTransacciones As New DataTable
    Public Sub Main(ByVal nomb_modulo As String)
        Me.nomb_modulo = nomb_modulo
    End Sub
    Private Sub Frm_traslados_bodega_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim sql As String = "SELECT J.tipo,T.sw " & _
                              "FROM J_transacciones_handHeld J , tipo_transacciones T " & _
                                    "WHERE T.tipo = J.tipo "
        dtTransacciones = obj_Ing_prodLn.listar_datatable(sql, "CORSAN")
        cboTipo.DataSource = dtTransacciones
        cboTipo.ValueMember = "sw"
        cboTipo.DisplayMember = "tipo"
        cboTipo.Text = "Seleccione"
        Me.Location.X.Equals(10)
        Me.Location.Y.Equals(10)
        habilitarCampos(False)
        txtMensKilos.Text = ""
        cboTipo.DropDownHeight = 200
        cargaComp = True
    End Sub
    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If (validarFrm()) Then
            imgCarga.Visible = True
            Application.DoEvents()
            guardar()
            imgCarga.Visible = False
            Application.DoEvents()
        End If
    End Sub
    Private Sub guardar()
        Dim stockInsuficiente As Boolean = False
        Dim tipo As String = cboTipo.Text
        Dim notas As String = "SPIC traslado(HandHeld) " & Now & " usuario: " & nit_usuario
        Dim kilos As Double = Convert.ToDouble(txtKilos.Text)
        Dim codigo As String = Trim(txtCodigo.Text)
        Dim bodega As String = objTraslado_bodLn.obtenerBodegaXcodigo(codigo)
        Dim dFec As Date = Now
        Dim usuario As String = nit_usuario
        Dim stock As Double = objOpSimplesLn.consultarStock(txtCodigo.Text, bodega)
        If (cboTipo.SelectedValue = 11) Then
            If (kilos > stock) Then
                stockInsuficiente = True
                txtMensKilos.Text = "SOTCK insuficiente"
                imgKilos.Image = Spic.My.Resources._1371750041_14125
                objTraslado_bodLn.guardarTranStockInsuficiente(codigo, kilos, tipo, txtCedula.Text)
                addTransaccion(bodega, tipo, stockInsuficiente, 0, 0)
                nuevo()
                Using New Centered_MessageBox(Me)
                    imgCarga.Visible = False
                    'MessageBox.Show("No hay stock para realizar la salida, " & vbCrLf & "Favor notificar a su coordinador  " & vbCrLf & "para darle solución a este inconveniente," & vbCrLf & "la transacción quedara marcada con ROJO", "STOCK INSUFICIENTE", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    MessageBox.Show("Transacción realizada con exito! ", "Extio", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    imgCarga.Visible = True
                End Using
            Else
                realizarTransaccion(kilos, codigo, bodega, dFec, notas, usuario, tipo, stockInsuficiente)
            End If
        ElseIf (cboTipo.SelectedValue = 12) Then
            realizarTransaccion(kilos, codigo, bodega, dFec, notas, usuario, tipo, stockInsuficiente)
        End If
    End Sub
    Private Sub realizarTransaccion(ByVal kilos As Double, ByVal codigo As String, ByVal bodega As Integer, ByVal dFec As Date, ByVal notas As String, ByVal usuario As String, ByVal tipo As String, ByVal stockInsuficiente As Boolean)
        Dim dt As New DataTable
        dt = objTraslado_bodLn.trasladoBodega(kilos, codigo, bodega, dFec, notas, usuario, tipo)
        Dim numero As Double = dt.Rows(0).Item("numero")
        Dim seq As Integer = dt.Rows(0).Item("seq")
        If (numero <> 0) Then
            Using New Centered_MessageBox(Me)
                imgCarga.Visible = False
                MessageBox.Show("Transacción realizada con exito! ", "Extio", MessageBoxButtons.OK, MessageBoxIcon.Information)
                imgCarga.Visible = True
            End Using
            addTransaccion(bodega, tipo, stockInsuficiente, numero, seq)
            txtCodigo.Focus()
            nuevo()
        Else
            Using New Centered_MessageBox(Me)
                imgCarga.Visible = False
                MessageBox.Show("Error al realizar la transacción , comuniquese con el administrador del sistema! ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                imgCarga.Visible = True
            End Using
        End If
    End Sub
    Private Sub nuevo()
        cargaComp = False
        txtCodigo.Text = ""
        txtKilos.Text = ""
        txtDesc.Text = ""
        cboTipo.Text = "Seleccione"
        txtMensKilos.Text = ""
        imgCod.Image = Spic.My.Resources._1371750041_14125
        imgKilos.Image = Spic.My.Resources._1371750041_14125
        imgTipo.Image = Spic.My.Resources._1371750041_14125
        txtStock.Text = ""
        txtDescKilos.Text = ""
        cargaComp = True
    End Sub
    Public Sub addTransaccion(ByVal bodega As Integer, ByVal tipo As String, ByVal stockInsuficiente As Boolean, ByVal numero As Double, ByVal seq As Double)
        Dim ultFila As Integer = dtgConsulta.RowCount

       
        dtgConsulta.Rows.Add()
        Dim i As Integer = dtgConsulta.RowCount - 1
        While (i >= 1)
            dtgConsulta.Item(colAnulado.Name, i).Value = dtgConsulta.Item(colAnulado.Name, i - 1).Value
            dtgConsulta.Item("colCodigo", i).Value = dtgConsulta.Item("colCodigo", i - 1).Value
            dtgConsulta.Item("colDesc", i).Value = dtgConsulta.Item("colDesc", i - 1).Value
            dtgConsulta.Item("colBod", i).Value = dtgConsulta.Item("colBod", i - 1).Value
            dtgConsulta.Item("colKilos", i).Value = dtgConsulta.Item("colKilos", i - 1).Value
            dtgConsulta.Item("colNumero", i).Value = dtgConsulta.Item("colNumero", i - 1).Value
            dtgConsulta.Item("colTipo", i).Value = dtgConsulta.Item("colTipo", i - 1).Value
            dtgConsulta.Item(colSeq.Name, i).Value = dtgConsulta.Item(colSeq.Name, i - 1).Value
            dtgConsulta.Item(col_stock_insuf.Name, i).Value = dtgConsulta.Item(col_stock_insuf.Name, i - 1).Value
            dtgConsulta.Rows(i).DefaultCellStyle.ForeColor = dtgConsulta.Rows(i - 1).DefaultCellStyle.ForeColor
            dtgConsulta.Rows(i).DefaultCellStyle.BackColor = dtgConsulta.Rows(i - 1).DefaultCellStyle.BackColor
            'If (dtgConsulta.Rows(i - 1).DefaultCellStyle.BackColor = Color.Purple Or dtgConsulta.Rows(i - 1).DefaultCellStyle.BackColor = Color.Blue Or dtgConsulta.Item(colAnulado.Name, i - 1).Value = 1) Then
            '    dtgConsulta.Rows(i - 1).DefaultCellStyle.ForeColor = Color.White
            'Else
            '    dtgConsulta.Rows(i - 1).DefaultCellStyle.ForeColor = Color.Black
            'End If
            i -= 1
        End While
        'dtgConsulta.Item("colTipo", 0).Style.BackColor = cboTipo.SelectedItem.
        If (stockInsuficiente) Then
            numero = objTraslado_bodLn.consultUltStockInsuficiente(tipo)
            dtgConsulta.Item(col_stock_insuf.Name, i).Value = 1
        Else
            dtgConsulta.Item(col_stock_insuf.Name, i).Value = 0
        End If
        dtgConsulta.Item("colCodigo", 0).Value = txtCodigo.Text
        dtgConsulta.Item("colDesc", 0).Value = txtDesc.Text
        dtgConsulta.Item("colBod", 0).Value = bodega
        dtgConsulta.Item("colKilos", 0).Value = txtKilos.Text
        dtgConsulta.Item("colNumero", 0).Value = numero
        dtgConsulta.Item("colTipo", 0).Value = tipo
        dtgConsulta.Item(colSeq.Name, 0).Value = seq
        dtgConsulta.Item(colAnulado.Name, 0).Value = 0
        dtgConsulta.Rows(0).DefaultCellStyle.BackColor = colorTransaccion(cboTipo.SelectedIndex, "color")
        If (dtgConsulta.Rows(0).DefaultCellStyle.BackColor = Color.Purple Or dtgConsulta.Rows(0).DefaultCellStyle.BackColor = Color.Blue) Then
            dtgConsulta.Rows(0).DefaultCellStyle.ForeColor = Color.White
        Else
            dtgConsulta.Rows(0).DefaultCellStyle.ForeColor = Color.Black
        End If
        If (stockInsuficiente) Then
            ' dtgConsulta.Rows(ultFila).DefaultCellStyle.BackColor = Color.Red
            Dim texto As String = "La referencia:" & txtCodigo.Text & " tiene un stock de :(" & txtStock.Text & ")" & vbCrLf & _
                              " y se solicita una salida por (" & txtDescKilos.Text & ") por lo tanto no hay sotck disponible" & vbCrLf & _
                              "Operario: " & Me.Text
            Dim titulo As String = "Referencia:" & txtCodigo.Text & " con problemas de stock,número transaccón: " & numero
            enviarCorreo(texto, titulo)
        End If
    End Sub
    Private Function validarFrm() As Boolean
        Using New Centered_MessageBox(Me)
            If (txtCodigo.Text <> "") Then
                If (txtKilos.Text <> "") Then
                    If (cboTipo.Text <> "Seleccione") Then
                        If (obj_Ing_prodLn.existeCodigo(txtCodigo.Text)) Then
                            If IsNumeric(txtKilos.Text) Then
                                If (Convert.ToDouble(txtKilos.Text) > 0) Then
                                    If (cboTipo.Text <> "Seleccione") Then
                                        If (obj_Ing_prodLn.existeTipoTransaccion(cboTipo.Text)) Then
                                            If (txtKilos.Text <= 2000 And txtKilos.Text >= 25) Then
                                                Return True
                                            Else
                                                MessageBox.Show("Los kilos estan fuera del limite promedio (menor a 25 ó mayor a 2000)! ", "verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                            End If
                                        Else
                                            MessageBox.Show("No existe el tipo de transacción! ", "verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                        End If
                                    Else
                                        MessageBox.Show("Seleccione un tipo de transacción! ", "verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    End If
                                Else
                                    MessageBox.Show("Los kilos no pueden ser negativos ó iguales a (0) ", "verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                End If
                            Else
                                MessageBox.Show("Verifique que el campo 'KILOS' sea un número y no contenga letras! ", "verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End If
                        Else
                            MessageBox.Show("El código ingresado no existe,verifique! ", "verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    Else
                        MessageBox.Show("Falta el TIPO de transacción", "verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Else
                    MessageBox.Show("Faltan los kilos ", "verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
                Else
                    MessageBox.Show("Falta el CÓDIGO ", "verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
        End Using

        Return False
    End Function

    Private Sub txtCodigo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodigo.TextChanged
        If (cargaComp) Then
            If (txtCodigo.Text.Length > 6) Then
                txtDesc.Text = obj_Ing_prodLn.descCodigo(txtCodigo.Text)
            Else
                imgCod.Image = Spic.My.Resources._1371750041_14125
                txtDesc.Text = ""
            End If
            If (txtDesc.Text = "" Or txtDesc.Text = "0") Then
                imgCod.Image = Spic.My.Resources._1371750041_14125
            ElseIf (txtCodigo.Text <> "") Then
                Dim bodega As Integer = objTraslado_bodLn.obtenerBodegaXcodigo(txtCodigo.Text)
                imgCod.Image = Spic.My.Resources.ok3
                txtKilos.Focus()
                txtStock.Text = objOpSimplesLn.consultarStock(txtCodigo.Text, bodega).ToString("N0")
            End If
        End If
    End Sub
    Private Sub cboTipo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipo.TextChanged
        If (cargaComp And Trim(cboTipo.Text).Length > 2) Then
            If (obj_Ing_prodLn.existeTipoTransaccion(cboTipo.Text)) Then
                imgTipo.Image = Spic.My.Resources.ok3
            Else
                imgTipo.Image = Spic.My.Resources._1371750041_14125
            End If
        End If
    End Sub
    Private Sub habilitarCampos(ByVal estado As Boolean)
        txtCodigo.Enabled = estado
        txtKilos.Enabled = estado
        cboTipo.Enabled = estado
        btnGuardar.Enabled = estado
        dtgConsulta.Enabled = estado
    End Sub


    Private Sub txtCedula_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCedula.TextChanged
        If (cargaComp) Then
            If (Trim(txtCedula.Text).Length > 4) Then
                Dim nombre As String = objOpSimplesLn.consultarVal("SELECT nombres FROM V_nom_personal_Activo_con_maquila WHERE nit = '" & txtCedula.Text & "'")
                If (nombre <> "") Then
                    imgCed.Image = Spic.My.Resources.ok3
                    Me.Text = nombre
                    habilitarCampos(True)
                    dtgConsulta.DataSource = Nothing
                    txtCodigo.Focus()
                    Me.nit_usuario = txtCedula.Text
                    dtgConsulta.Rows.Clear()
                    nuevo()
                Else
                    imgCed.Image = Spic.My.Resources._1371750041_14125
                    Me.Text = "Digite su cédula"
                    habilitarCampos(False)
                End If
            Else
                imgCed.Image = Spic.My.Resources._1371750041_14125
                Me.Text = "Digite su cédula"
                habilitarCampos(False)
            End If

        End If
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

    Private Sub txtCedula_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCedula.KeyPress
        soloNumero(e)
    End Sub

    Private Sub txtKilos_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtKilos.KeyPress
        soloNumero(e)
    End Sub

    Private Sub txtKilos_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtKilos.TextChanged
        If (txtKilos.Text <> "") Then
            If (txtKilos.Text > 1) Then
                If IsNumeric(txtKilos.Text) Then
                    txtDescKilos.Text = Convert.ToDouble(txtKilos.Text).ToString("N0")
                    If (txtKilos.Text > 2000) Then
                        imgKilos.Image = Spic.My.Resources.estable
                        txtMensKilos.Text = "La cantidad es muy alta, no debe ser mayor a 2.000 kilos"
                    ElseIf (txtKilos.Text < 25) Then
                        imgKilos.Image = Spic.My.Resources.estable
                        txtMensKilos.Text = "La cantidad es muy, baja no debe ser menor a 25 kilos"
                    Else
                        imgKilos.Image = Spic.My.Resources.ok3
                        txtMensKilos.Text = ""
                    End If
                End If
            End If
        Else
            txtDescKilos.Text = ""
        End If
    End Sub
    Private Sub enviarCorreo(ByVal texto As String, ByVal titulo As String)
        If (nomb_modulo = "") Then
            nomb_modulo = "nod_tras_bod_hand"
        End If
        Dim destino As String = objOpSimplesLn.returnCorreosModulo(nomb_modulo)
        Dim direccion As String = ""
        Dim email As String = objOpSimplesLn.consultarVal("SELECT Mail from jjv_usuarios WHERE usuario ='ADMIN'")
        Dim contra As String = objOpSimplesLn.consultarVal("SELECT Mail_login from jjv_usuarios WHERE usuario ='ADMIN'")
        If (destino = "" Or email = "" Or contra = "") Then
            Using New Centered_MessageBox(Me)
                '  MessageBox.Show("Error al enviar el correo,comuniquese con el administrador del sistema!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Using
        Else
            If Not (objEnvCorreoLN.EnviarCorreo(destino, texto, titulo, direccion, email, contra, False)) Then
                Using New Centered_MessageBox(Me)
                  '  MessageBox.Show("Error al enviar el correo,comuniquese con el administrador del sistema!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End Using
            End If
        End If
    End Sub

    Private Sub cboTipo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboTipo.KeyPress
        e.KeyChar = ""
    End Sub

 
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        imgCarga.Visible = True
    End Sub
    Private Sub cboTipo_DrawItem(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles cboTipo.DrawItem

        Select Case e.Index
            Case 0
                e.Graphics.FillRectangle(colorTransaccion(e.Index, "brush"), e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height)
                e.Graphics.DrawString(dtTransacciones.Rows(e.Index).Item("tipo"), e.Font, New SolidBrush(Color.Black), e.Bounds)
            Case 1
                e.Graphics.FillRectangle(colorTransaccion(e.Index, "brush"), e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height)
                e.Graphics.DrawString(dtTransacciones.Rows(e.Index).Item("tipo"), e.Font, New SolidBrush(Color.Black), e.Bounds)
            Case 2
                e.Graphics.FillRectangle(colorTransaccion(e.Index, "brush"), e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height)
                e.Graphics.DrawString(dtTransacciones.Rows(e.Index).Item("tipo"), e.Font, New SolidBrush(Color.White), e.Bounds)
            Case 3
                e.Graphics.FillRectangle(colorTransaccion(e.Index, "brush"), e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height)
                e.Graphics.DrawString(dtTransacciones.Rows(e.Index).Item("tipo"), e.Font, New SolidBrush(Color.Black), e.Bounds)
            Case 4
                e.Graphics.FillRectangle(colorTransaccion(e.Index, "brush"), e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height)
                e.Graphics.DrawString(dtTransacciones.Rows(e.Index).Item("tipo"), e.Font, New SolidBrush(Color.Black), e.Bounds)
            Case 5
                e.Graphics.FillRectangle(colorTransaccion(e.Index, "brush"), e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height)
                e.Graphics.DrawString(dtTransacciones.Rows(e.Index).Item("tipo"), e.Font, New SolidBrush(Color.Black), e.Bounds)
            Case 6
                e.Graphics.FillRectangle(colorTransaccion(e.Index, "brush"), e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height)
                e.Graphics.DrawString(dtTransacciones.Rows(e.Index).Item("tipo"), e.Font, New SolidBrush(Color.White), e.Bounds)
            Case 7
                e.Graphics.FillRectangle(colorTransaccion(e.Index, "brush"), e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height)
                e.Graphics.DrawString(dtTransacciones.Rows(e.Index).Item("tipo"), e.Font, New SolidBrush(Color.Black), e.Bounds)
            Case 8
                e.Graphics.FillRectangle(colorTransaccion(e.Index, "brush"), e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height)
                e.Graphics.DrawString(dtTransacciones.Rows(e.Index).Item("tipo"), e.Font, New SolidBrush(Color.Black), e.Bounds)
            Case 9
                e.Graphics.FillRectangle(colorTransaccion(e.Index, "brush"), e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height)
                e.Graphics.DrawString(dtTransacciones.Rows(e.Index).Item("tipo"), e.Font, New SolidBrush(Color.Black), e.Bounds)
        End Select

    End Sub
    Private Function colorTransaccion(ByVal posicion As Integer, ByVal tipoColor As String) As Object
        Dim color As Color = color.White
        Dim brush As Object = Brushes.White
        Select Case dtTransacciones.Rows(posicion).Item("tipo")
            Case "EPPP"
                'rosado
                color = color.Gray
                brush = Brushes.Gray
            Case "SAV"
                'rosado
                color = color.Blue
                brush = Brushes.Blue
            Case "SAR"
                'Rojo
                color = color.Red
                brush = Brushes.Red
            Case "SCAE"
                'Azul
                color = color.Green
                brush = Brushes.Green
            Case "SCAL"
                'naranja
                color = color.Yellow
                brush = Brushes.Yellow
            Case "SCLA"
                'Verde
                color = color.Lime
                brush = Brushes.Lime
            Case "SREC"
                'amarillo
                color = color.Purple
                brush = Brushes.Purple
            Case ""

            Case ""

        End Select
        If (tipoColor = "color") Then
            Return color
        Else
            Return brush
        End If
    End Function

    Private Sub cboTipo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipo.SelectedIndexChanged
        If (cargaComp) Then
            Dim color As Color = colorTransaccion(cboTipo.SelectedIndex, "color")
            If (color = color.Purple Or color = color.Blue) Then
                cboTipo.ForeColor = color.White
            Else
                cboTipo.ForeColor = color.Black
            End If
            cboTipo.BackColor = color
            txtCodigo.Focus()
        End If
    End Sub

  
    Private Sub dtgConsulta_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgConsulta.CellContentClick
        If (e.RowIndex >= 0) Then
            If (dtgConsulta.Columns(e.ColumnIndex).Name = colAnular.Name) Then
                If (dtgConsulta.Item(colAnulado.Name, e.RowIndex).Value = 0) Then
                    imgCarga.Visible = True
                    Application.DoEvents()
                    Dim correcto As Boolean = False
                    Dim codigo As String = dtgConsulta.Item(colCodigo.Name, e.RowIndex).Value
                    Dim texto As String = ""
                    Dim titulo As String = ""
                    Dim motivo As String = ""
                    Dim tipo As String = dtgConsulta.Item(colTipo.Name, e.RowIndex).Value
                    Dim kilos As Double = dtgConsulta.Item(colKilos.Name, e.RowIndex).Value
                    Dim numero As Integer = dtgConsulta.Item(colNumero.Name, e.RowIndex).Value
                    motivo = InputBox("Ingrese motivo de la anulación del transacción: " & vbCrLf & vbCrLf & _
                                        "Código: " & codigo & vbCrLf & _
                                        "Tipo: " & tipo & vbCrLf & _
                                        "Kilos:" & kilos, "Motivo", "", -5, 100)
                    If (motivo <> "") Then
                        If (dtgConsulta.Item(col_stock_insuf.Name, e.RowIndex).Value = 0) Then

                            Dim seq As Integer = dtgConsulta.Item(colSeq.Name, e.RowIndex).Value
                            texto = "Número " & numero & " , Seq = " & seq
                            If Not (objOrdenProdLn.insertarProxMes(codigo)) Then
                                motivo &= "- usuario:" & txtCedula.Text
                                Dim sqlConsulta As String = "SELECT valor_unitario,costo_unitario,sw,fec,id  " & _
                                                     "FROM documentos_lin  " & _
                                               "WHERE numero = " & numero & " AND seq = " & seq & " and tipo = '" & tipo & "'"
                                Dim dt As New DataTable
                                dt = objOpSimplesLn.listar_datatable(sqlConsulta, "CORSAN")
                                Dim id As Double = dt.Rows(0).Item("id")
                                Dim bodega As String = dtgConsulta.Item(colBod.Name, e.RowIndex).Value
                                Dim stock As Double = objOpSimplesLn.consultarStock(codigo, bodega)
                                Dim vr_unitario As Double = dt.Rows(0).Item("valor_unitario")
                                Dim costo_unitario As Double = dt.Rows(0).Item("costo_unitario")
                                Dim sw As Integer = dt.Rows(0).Item("sw")
                                Dim fec As Date = dt.Rows(0).Item("fec")
                                If (cboTipo.SelectedValue = 11) Then
                                    If (kilos > stock) Then
                                        titulo = "Se requeria anular una transacción, pero no hay stock disponible "
                                        texto &= vbCrLf & "No hay stock disponible para la anuación de esta entrada "
                                        enviarCorreo(texto, titulo)
                                        Using New Centered_MessageBox(Me)
                                            MessageBox.Show("El movimiento no fue anulado,ya que no hay stock disponible!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                        End Using
                                    Else
                                        ' correcto = objTraslado_bodLn.anularTransaccion(numero, tipo, motivo, kilos, vr_unitario, costo_unitario, codigo, sw, fec, bodega, id)
                                    End If
                                Else
                                    ' correcto = objTraslado_bodLn.anularTransaccion(numero, tipo, motivo, kilos, vr_unitario, costo_unitario, codigo, sw, fec, bodega, id)
                                End If
                            Else
                                titulo = "Se requeria anular una transacción, pero ya se hizo cierre de mes "
                                texto &= vbCrLf & "Se requiere la anulación de este movimiento por DMS "
                                enviarCorreo(texto, titulo)
                                Using New Centered_MessageBox(Me)
                                    MessageBox.Show("Se ya se a hecho cierre de mes, por lo tanto la transacción no fue anulada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                End Using
                            End If
                            texto &= vbCrLf & motivo
                        Else
                            texto = vbCrLf & "TRANSACCIONES SIN STOCK" & vbCrLf & _
                                        "Motivo:" & motivo & vbCrLf & _
                                        "Transacción número: " & numero & vbCrLf & _
                                        "Código:" & codigo & vbCrLf & _
                                        "Tipo:" & tipo & vbCrLf & _
                                        "Cantidad:" & kilos
                            motivo &= "(Hand-Held)-usr:" & txtCedula.Text & " " & Now
                            correcto = objTraslado_bodLn.anularTransaccionSinStock(numero, motivo)
                            dtgConsulta.Item(colDesc.Name, e.RowIndex).Value = "ANULADO"
                            dtgConsulta.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Black
                            dtgConsulta.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.White
                            dtgConsulta.Item(colAnulado.Name, e.RowIndex).Value = 1
                        End If
                    Else
                        Using New Centered_MessageBox(Me)
                            MessageBox.Show("Se debe ingresar un motivo para la anulación del movimiento!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Using
                    End If
                    If (correcto) Then
                        titulo = "Movimiento anulado en forma exitosa "
                        enviarCorreo(texto, titulo)
                        Using New Centered_MessageBox(Me)
                            MessageBox.Show("Movimiento anulado en forma exitosa!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End Using
                        dtgConsulta.Item(colDesc.Name, e.RowIndex).Value = "ANULADO"
                        dtgConsulta.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Black
                        dtgConsulta.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.White
                        dtgConsulta.Item(colAnulado.Name, e.RowIndex).Value = 1
                    End If
                    imgCarga.Visible = False
                End If

            End If
        End If
    End Sub

  
    Private Sub imgCarga_Click(sender As Object, e As EventArgs) Handles imgCarga.Click
        imgCarga.Visible = False
    End Sub
End Class