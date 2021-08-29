Imports logicaNegocios
Public Class FrmTransacManualDmsSpic
    Private objOpSimplesLn As New Op_simpesLn
    Private objOrdenProdLn As New OrdenProdLn
    Private objIngProdLn As New Ing_prodLn
    Dim carga_comp As Boolean = False
    Private Sub FrmTransacManualDmsSpic_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cboCodOrden.DataSource = cargarCbo("SELECT consecutivo FROM J_orden_prod_tef ORDER BY consecutivo")
        cboCodOrden.DisplayMember = "consecutivo"
        cboCodOrden.ValueMember = "consecutivo"
        cboCodOrden.Text = "Seleccione"
        carga_comp = True
    End Sub
    Private Function cargarCbo(ByVal sql As String) As DataTable
        Dim dt As New DataTable
        dt = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")
        Return (dt)
    End Function
    Private Sub cargarCodigosDetalle(ByVal codOrden As String)
        Dim sql As String = ""
        sql = "SELECT id_detalle FROM  J_det_orden_prod WHERE cod_orden = " & codOrden & " ORDER BY id_detalle"
        cboDetalleOrden.DataSource = cargarCbo(sql)
        cboDetalleOrden.DisplayMember = "id_detalle"
        cboDetalleOrden.ValueMember = "id_detalle"
        cboDetalleOrden.Text = "Seleccione"
    End Sub

    Private Sub cboCodOrden_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCodOrden.SelectedIndexChanged
        If (carga_comp) Then
            If (cboCodOrden.SelectedValue.ToString <> "Seleccione") Then
                cargarCodigosDetalle(cboCodOrden.SelectedValue)
                cboDetalleOrden.Focus()
            End If
        End If
    End Sub

    Private Sub txtKilos_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtKilos.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub cboDetalleOrden_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDetalleOrden.SelectedIndexChanged
        txtKilos.Focus()
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If (validarFrm()) Then
            Dim kilos As Double = Convert.ToDouble(txtKilos.Text)
            Dim cod_orden As String = cboCodOrden.SelectedValue
            Dim cod_detalle As String = cboDetalleOrden.SelectedValue
            If (ingProdDms(kilos, cod_orden, cod_detalle) >= 1) Then
                MessageBox.Show("Producción ingresada a DMS en forma exitosa! ", "Exito!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                If (GuardarRollo(kilos, cod_orden, cod_detalle) >= 1) Then
                    MessageBox.Show("Producción ingresada a SPIC en forma exitosa! ", "Exito!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    listarUltTransaccion()
                    nuevo()
                Else
                    MessageBox.Show("Problemas al ingresar la producción a SPIC, comuniquese con el administrador del sistema! ", "Verifique!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                MessageBox.Show("Problemas al ingresar la producción a DMS, comuniquese con el administrador del sistema! ", "Verifique!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
           

        End If
    End Sub
    Private Function ingProdDms(ByVal kilos As Double, ByVal cod_orden As String, ByVal cod_detalle As String) As Integer
        Dim operario As String = objIngProdLn.consultar_valor("SELECT operario FROM J_det_orden_prod WHERE cod_orden = " & cod_orden & " AND id_detalle = " & cod_detalle, "PRODUCCION")
        Dim codigo As String = objIngProdLn.consultar_valor("SELECT prod_final FROM J_orden_prod_tef WHERE consecutivo = " & cod_orden, "PRODUCCION")
        Dim bodega As String = "2"
        Dim dFec As Date = Now
        Dim fecha_hora As String
        Dim notas As String = "SPIC fecha:" & Now & " operario: " & operario
        Dim usuario As String = My.Computer.Name
        Dim tipo_tran_prod As String
        Dim pc As String = My.Computer.Name
        Dim sFechaTransaccion As String = ""
        Dim num_tran_prod As Double = objOrdenProdLn.mover_consecutivo(codigo)
        If (objOrdenProdLn.insertarProxMes(codigo)) Then
            dFec = dFec.AddMonths(1)
            fecha_hora = "" & System.DateTime.Now.Month + 1 & "-" & "01" & "-" & System.DateTime.Now.Year & " " & System.DateTime.Now.Hour & ":" & System.DateTime.Now.Minute & ":" & System.DateTime.Now.Second & ""
            sFechaTransaccion = dFec.Year & "-" & dFec.Month & "-01"
        Else
            fecha_hora = "" & System.DateTime.Now.Month & "-" & System.DateTime.Now.Day & "-" & System.DateTime.Now.Year & " " & System.DateTime.Now.Hour & ":" & System.DateTime.Now.Minute & ":" & System.DateTime.Now.Second & ""
            sFechaTransaccion = dFec.Year & "-" & dFec.Month & "-" & dFec.Day
        End If
        If (bodega = 2) Then
            tipo_tran_prod = "EPPP"
        Else
            tipo_tran_prod = "EPPT"
        End If
        If objOpSimplesLn.ExecuteSqlTransaction(objOrdenProdLn.ingProdDms(kilos, codigo, bodega, dFec, notas, usuario, cod_detalle, cod_orden, "", num_tran_prod, tipo_tran_prod, sFechaTransaccion, fecha_hora)) Then
            Dim sql_ing_auditoria As String = "INSERT INTO J_transac_spic_dms (numero,tipo,fecha,usuario,pc,cantidad,notas,id_detalle,cod_orden) " & _
                            "VALUES(" & num_tran_prod & ",'" & tipo_tran_prod & "','" & objOpSimplesLn.cambiarFormatoFecha(dFec) & "','" & usuario & "','" & pc & "'," & kilos & ",'" & notas & "'," & 1 & "," & 1 & ")"
            If objOpSimplesLn.ejecutar(sql_ing_auditoria, "PRODUCCION") = 0 Then
                MessageBox.Show("Error al ingresar la auditoria, no cierre la planilla y comuniquese con sistemas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return True
        Else
            Return False
        End If
    End Function
    Private Function GuardarRollo(ByVal kilos, ByVal cod_orden, ByVal cod_detalle) As Integer
        Dim sqlNumRollo As String = "SELECT MAX (id_rollo) FROM J_rollos_tref WHERE cod_orden = " & cod_orden & " AND id_detalle = " & cod_detalle
        Dim numRollo As String = objIngProdLn.consultar_valor(sqlNumRollo, "PRODUCCION")
        numRollo += 1
        Dim sql As String = "INSERT INTO J_rollos_tref (cod_orden,id_rollo,id_detalle,peso) VALUES (" & cod_orden & "," & numRollo & "," & cod_detalle & "," & kilos & ")"
        Return objOpSimplesLn.ejecutar(sql, "PRODUCCION")
    End Function
    Private Function validarFrm() As Boolean
        Dim resp As String = False
        If (txtKilos.Text = "" Or cboCodOrden.Text <> "Seleccione" Or cboDetalleOrden.Text <> "Seleccione") Then
            If (objOrdenProdLn.existePlanilla(cboCodOrden.SelectedValue, cboDetalleOrden.SelectedValue)) Then
                resp = True
            Else
                MessageBox.Show("La orden de producción no se encuentra en la base de datos! ", "Verifique!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            MessageBox.Show("Todos los campos son obligatorios! ", "Verifique!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        Return resp
    End Function
    Private Sub listarUltTransaccion()
        Dim sql As String = "SELECT TOP 1 sw,tipo,numero,codigo,fec,nit,cantidad,bodega,adicional " & _
                                    "FROM documentos_lin  " & _
                                             "WHERE  tipo = 'EPPP' " & _
                                      "ORDER BY numero DESC"
        dtg_consulta.DataSource = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        dtg_consulta.Columns("fec").DefaultCellStyle.Format = "d"
    End Sub
    Private Sub nuevo()
        cboCodOrden.Text = "Seleccione"
        cboDetalleOrden.Text = "Seleccione"
        txtKilos.Text = ""
    End Sub
End Class