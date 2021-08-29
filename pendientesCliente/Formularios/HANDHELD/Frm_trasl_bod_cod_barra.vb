Imports logicaNegocios
Imports entidadNegocios
Public Class Frm_trasl_bod_cod_barra
    Dim nit_usuario As String
    Dim objTraslado_bodLn As New traslado_bodLn
    Private obj_Ing_prodLn As New Ing_prodLn
    Private objOpSimplesLn As New Op_simpesLn
    Dim cargaComp As Boolean = False
    Private objEnvCorreoLN As New EnvCorreoLN
    Private objReferenciaEn As New ReferenciaEn
    Private objDetalleRollosEn As New DetalleRollosEn
    Private objOrdenProdLn As New OrdenProdLn
    Private Sub Frm_trasl_bod_cod_barra_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim sql As String = "SELECT J.tipo,T.sw " & _
                              "FROM J_transacciones_handHeld J , tipo_transacciones T " & _
                                    "WHERE T.tipo = J.tipo "
        cboTipo.DataSource = obj_Ing_prodLn.listar_datatable(sql, "CORSAN")
        cboTipo.ValueMember = "sw"
        cboTipo.DisplayMember = "tipo"
        cboTipo.Text = "Seleccione"
        Me.Location.X.Equals(10)
        Me.Location.Y.Equals(10)
        habilitarCampos(False)
        cboTipo.DropDownHeight = 200
        cargaComp = True
    End Sub

    'Private Sub btnRealiTran_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRealiTran.Click
    '    If (validarFrm()) Then
    '        Timer1.Enabled = True

    '        guardar()

    '        Timer1.Enabled = False
    '    End If
    'End Sub
    Private Sub guardar()
        Dim codigoMuestra As String = dtgConsulta.Item(colPeso.Name, 0).Value
        Dim listSql As New List(Of Object)
        Dim stockInsuficiente As Boolean = False
        Dim tipo As String = cboTipo.Text
        Dim numero As Double = objTraslado_bodLn.consultUltNumeroXtipo(tipo) + 1
        Dim notas As String = "SPIC traslado(HandHeld) " & Now & " usuario: " & nit_usuario
        Dim dFec As Date = Now
        Dim bodega As Integer = objTraslado_bodLn.obtenerBodegaXcodigo(codigoMuestra)
        Dim usuario As String = nit_usuario
        Dim swTipo As Integer = cboTipo.SelectedValue
        Dim tot_kilos As Double = sumarKilos()
        Dim tot_valorUnitatio As Double = sumarVrUnitario()
        Dim vrTotal As Double = tot_valorUnitatio * tot_kilos
        Dim sqlEncTransaccion As String = objTraslado_bodLn.armarSqlEncTransaccion(swTipo, tipo, tot_kilos, bodega, usuario, notas, dFec, numero, vrTotal, codigoMuestra)
        listSql.Add(sqlEncTransaccion)
        listSql.AddRange(listaSqlDetTransacciones(swTipo, tipo, usuario, notas, dFec, numero, bodega))
        If (objOpSimplesLn.ExecuteSqlTransaction(listSql)) Then
            Using New Centered_MessageBox(Me)
                MessageBox.Show("Transacción realizada con exito! ", "Extio", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Using
        Else
            MessageBox.Show("Error al realizar la transacción , comuniquese con el administrador del sistema! ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        MsgBox("transaccion numero = " & objTraslado_bodLn.consultUltNumeroXtipo(tipo))
    End Sub
    Private Function listaSqlDetTransacciones(ByVal swTipo As Integer, ByVal tipo As String, ByVal usuario As String, ByVal notas As String, ByVal dFec As Date, ByVal numero As Double, ByVal bodega As Integer) As List(Of Object)
        Dim listSql As New List(Of Object)
        Dim kilos As Double = 0
        Dim codigo As String = ""
        Dim vr_unitario As Double = 0
        Dim costo_unitario As Double = 0
        Dim seq As Integer = 0
        For i = 0 To dtgConsulta.RowCount - 1
            kilos = dtgConsulta.Item(colPeso.Name, i).Value
            codigo = dtgConsulta.Item(colCodigo.Name, i).Value
            'Se hace por 1 ya que se esta registrando cada rollo y no el conjunto
            vr_unitario = dtgConsulta.Item(colVrUnitario.Name, i).Value
            seq = i
            costo_unitario = dtgConsulta.Item(colCostoUnitario.Name, i).Value
            listSql.Add(objTraslado_bodLn.armarSqlDetTransaccion(swTipo, tipo, kilos, usuario, notas, dFec, numero, codigo, seq, vr_unitario, costo_unitario, bodega))
            listSql.Add(objTraslado_bodLn.sqlActUltEntradaUltSalida(swTipo, codigo))
        Next
        Return listSql
    End Function
    Private Function sumarVrUnitario() As Double
        Dim sum As Double = 0
        For i = 0 To dtgConsulta.RowCount - 1
            sum += dtgConsulta.Item(colVrUnitario.Name, i).Value
        Next
        Return sum
    End Function
    Private Function sumarKilos() As Double
        Dim sum As Double = 0
        For i = 0 To dtgConsulta.RowCount - 1
            sum += dtgConsulta.Item(colPeso.Name, i).Value
        Next
        Return sum
    End Function
    Private Sub nuevo()
        cargaComp = False
        cboTipo.Text = "Seleccione"
        imgTipo.Image = Spic.My.Resources._1371750041_14125
        txtDescKilos.Text = ""
        cargaComp = True
    End Sub
    Public Sub addTransaccion(ByVal cod_orden As String, ByVal cod_detalle As String, ByVal num_rollo As String)
        Dim codigo As String = obj_Ing_prodLn.consultar_valor("SELECT prod_final  FROM  J_orden_prod_tef WHERE consecutivo = " & cod_orden, "PRODUCCION")
        objDetalleRollosEn = objOrdenProdLn.return_objDetalleRollosEn(cod_orden, cod_detalle, num_rollo)
        objReferenciaEn = objOpSimplesLn.return_objReferenciaEn(codigo)
        Dim ultFila As Integer = dtgConsulta.RowCount
        Dim bodega As Integer = objTraslado_bodLn.obtenerBodegaXcodigo(codigo)
        Dim stock As Double = objOpSimplesLn.consultarStock(codigo, bodega)
        dtgConsulta.Rows.Add()
        dtgConsulta.Item(colNumeroRollo.Name, ultFila).Value = objDetalleRollosEn.numRollo
        dtgConsulta.Item(colPeso.Name, ultFila).Value = objDetalleRollosEn.peso
        dtgConsulta.Item(colCodigo.Name, ultFila).Value = objReferenciaEn.codigo
        dtgConsulta.Item(colDesc.Name, ultFila).Value = objReferenciaEn.descripcion
        dtgConsulta.Item(colStock.Name, ultFila).Value = stock
        dtgConsulta.Item(colBodega.Name, ultFila).Value = bodega
        dtgConsulta.Item(colVrUnitario.Name, ultFila).Value = objReferenciaEn.valor_unitario
        dtgConsulta.Item(colCostoUnitario.Name, ultFila).Value = objReferenciaEn.costo_unitario
    End Sub
    'Private Function validarFrm() As Boolean
    '    Using New Centered_MessageBox(Me)
    '        If (txtCodigo.Text <> "" And txtKilos.Text <> "" And cboTipo.Text <> "Seleccione") Then
    '            If (obj_Ing_prodLn.existeCodigo(txtCodigo.Text)) Then
    '                If IsNumeric(txtKilos.Text) Then
    '                    If (Convert.ToDouble(txtKilos.Text) > 0) Then
    '                        If (cboTipo.Text <> "Seleccione") Then
    '                            If (obj_Ing_prodLn.existeTipoTransaccion(cboTipo.Text)) Then
    '                                If (txtKilos.Text <= 30000 And txtKilos.Text >= 10) Then
    '                                    Return True
    '                                Else
    '                                    MessageBox.Show("Los kilos estan fuera del limite promedio (menor a 10 ó mayor a 30000)! ", "verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '                                End If
    '                            Else
    '                                MessageBox.Show("No existe el tipo de transacción! ", "verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '                            End If
    '                        Else
    '                            MessageBox.Show("Seleccione un tipo de transacción! ", "verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '                        End If
    '                    Else
    '                        MessageBox.Show("Los kilos no pueden ser negativos ó iguales a (0) ", "verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '                    End If
    '                Else
    '                    MessageBox.Show("Verifique que el campo 'KILOS' sea un número y no contenga letras! ", "verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '                End If
    '            Else
    '                MessageBox.Show("El código ingresado no existe,verifique! ", "verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '            End If
    '        Else
    '            MessageBox.Show("Verifique que todos los campos esten llenos ", "verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        End If
    '    End Using

    '    Return False
    'End Function
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
     
        cboTipo.Enabled = estado
        btnRealiTran.Enabled = estado
        dtgConsulta.Enabled = estado
    End Sub


    Private Sub txtCedula_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCedula.TextChanged
        If (cargaComp And Trim(txtCedula.Text).Length > 4) Then
            Dim nombre As String = objOpSimplesLn.consultarVal("SELECT nombres FROM V_nom_personal_Activo_con_maquila WHERE nit = '" & txtCedula.Text & "'")
            If (nombre <> "") Then
                imgCed.Image = Spic.My.Resources.ok3
                Me.Text = nombre
                habilitarCampos(True)
                dtgConsulta.DataSource = Nothing
                txtCodigoLector.Focus()
                Me.nit_usuario = txtCedula.Text
                nuevo()
            Else
                imgCed.Image = Spic.My.Resources._1371750041_14125
                Me.Text = "Digite su número de cedula"
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

    Private Sub txtKilos_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        soloNumero(e)
    End Sub

    Private Sub enviarCorreoStockInsuf(ByVal numero As String, ByVal codigo As String, ByVal stock As String)
        'probar con returnCorreosModulo
        'Dim destino As String = objOpSimplesLn.returnCorreosModulo()
        Dim destino As String = "jorge.escobar@corsan.com.co"
        Dim texto As String = "La referencia:" & codigo & " tiene un stock de :(" & stock & ")" & vbCrLf & _
                                    " y se solicita una salida por (" & txtDescKilos.Text & ") por lo tanto no hay sotck disponible" & vbCrLf & _
                                    "Operario: " & Me.Text
        Dim titulo As String = "Referencia:" & codigo & " con problemas de stock,numero transaccón: " & numero
        Dim direccion As String = ""
        Dim email As String = objOpSimplesLn.consultarVal("SELECT Mail from jjv_usuarios WHERE usuario ='ADMIN'")
        Dim contra As String = objOpSimplesLn.consultarVal("SELECT Mail_login from jjv_usuarios WHERE usuario ='ADMIN'")
        If Not (objEnvCorreoLN.EnviarCorreo(destino, texto, titulo, direccion, email, contra, False)) Then
            Using New Centered_MessageBox(Me)
                MessageBox.Show("Error al enviar el correo,comuniquese con el administrador del sistema!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Using
        End If
    End Sub

    Private Sub cboTipo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboTipo.KeyPress
        e.KeyChar = ""
    End Sub


    Private Sub txtCodigoLector_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigoLector.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            Dim cod_orden As String = objTraslado_bodLn.extraerDatoCodigoBarras("cod_orden", txtCodigoLector.Text)
            Dim cod_detalle As String = objTraslado_bodLn.extraerDatoCodigoBarras("cod_detalle", txtCodigoLector.Text)
            Dim num_rollo As String = objTraslado_bodLn.extraerDatoCodigoBarras("num_rollo", txtCodigoLector.Text)
            addTransaccion(cod_orden, cod_detalle, num_rollo)
            validarProblemasTransaccion()
        End If
    End Sub

    Private Sub dtgConsulta_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgConsulta.CellContentClick
        Dim fila As String = e.RowIndex
        Dim col As String = dtgConsulta.Columns(e.ColumnIndex).Name
        If (col = colBorrar.Name) Then
            dtgConsulta.Rows.RemoveAt(fila)
        End If
    End Sub
   
    Private Sub txtCodigoLector_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodigoLector.Enter
        txtCodigoLector.BackColor = Color.Green
    End Sub
    Private Sub txtCodigoLector_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodigoLector.Leave
        txtCodigoLector.BackColor = Color.Red
    End Sub
    Private Sub validarProblemasTransaccion()
        Dim stock As Double = 0
        Dim kilos As Double = 0
        Dim codigo As String = ""
        Dim bodega As String = ""
        If (cboTipo.Text <> "Seleccione") Then
            If (cboTipo.SelectedValue = 11) Then
                For i = 0 To dtgConsulta.RowCount - 1
                    codigo = dtgConsulta.Item(colCodigo.Name, i).Value
                    kilos = dtgConsulta.Item(colPeso.Name, i).Value
                    bodega = dtgConsulta.Item(colBodega.Name, i).Value
                    stock = objOpSimplesLn.consultarStock(codigo, bodega)
                    If (kilos > stock) Then
                        dtgConsulta.Item(colProblemasStock.Name, i).Value = "S"
                        dtgConsulta.Rows(i).DefaultCellStyle.BackColor = Color.Red
                    Else
                        dtgConsulta.Item(colProblemasStock.Name, i).Value = "N"
                        dtgConsulta.Rows(i).DefaultCellStyle.BackColor = Color.White
                    End If
                Next
            End If
        End If

    End Sub

    Private Sub btnRealiTran_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRealiTran.Click
        If (cboTipo.Text <> "Seleccione") Then
            guardar()
        End If
    End Sub

    Private Sub Frm_trasl_bod_cod_barra_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        MsgBox("presiono una tecla sobre el frm")
    End Sub
End Class