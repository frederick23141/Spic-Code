Imports System.Configuration
Imports logicaNegocios
Imports System.IO
Imports Microsoft.Office.Interop
#Disable Warning BC40056 ' El espacio de nombres o el tipo especificado en el 'System.Data.SqlServerCe' Imports no contienen ningún miembro público o no se encuentran. Asegúrese de que el espacio de nombres o el tipo se hayan definido y de que contengan al menos un miembro público. Asegúrese de que el nombre del elemento importado no use ningún alias.
Imports System.Data.SqlServerCe
#Enable Warning BC40056 ' El espacio de nombres o el tipo especificado en el 'System.Data.SqlServerCe' Imports no contienen ningún miembro público o no se encuentran. Asegúrese de que el espacio de nombres o el tipo se hayan definido y de que contengan al menos un miembro público. Asegúrese de que el nombre del elemento importado no use ningún alias.

Public Class Frm_ing_recocido
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

#Region "Atributos"
    Private objOpSimplesLn As New Op_simpesLn
    Private obj_Ing_prodLn As New Ing_prodLn
    Private objRecocidoLn As New RecocidoAlambreLn
    Private cargaComp As Boolean = False
    Private objOpsimpesLn As New Op_simpesLn
#End Region

#Region "Metodos Del Form"
    Private Function validarFilaVacia(ByVal fila As Integer, ByVal dtg As DataGridView) As Boolean
        For i = 1 To dtg.ColumnCount - 1
            If (dtg.Item(i, fila).Value <> Nothing) Then
                Return False
            End If
        Next
        Return True
    End Function
    Private Function validarDtg(ByVal dtg As DataGridView) As Boolean
        Dim sw As Boolean = False
        For i = 0 To dtg.RowCount - 1
            For j = 1 To dtg.ColumnCount - 1
                If (dtg.Item(j, i).Value = Nothing) Then
                    If (validarFilaVacia(i, dtg) = True) Then
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
    Private Sub limpiar()
        txtNumOrdenRec.Text = ""
        dtFechaActual.Value = Date.Today
        txtCodigos.Text = ""
        txtKilosPro.Text = ""
        txtSostenimientos.Text = ""
        txtTemperatura.Text = ""
        txtTiempo.Text = ""
        cboPCarga.Text = "Seleccione"
        cboPDescarga.Text = "Seleccione"
        cboPOpera.Text = "Seleccione"
        txtTraccion.Text = ""
        txtBase.Text = ""
        Dim HoraInicio As String = ""
        Dim HoraFinal As String = ""
        dtgDetalles.Rows.Clear()
        dtgDetalles.Rows.Add()
    End Sub
    Private Function guardar() As Boolean
        Try
            If (verificar_campos()) Then
                Dim Cod_Orden As String = txtNumOrdenRec.Text
                Dim FechaIncial As String = objOpSimplesLn.cambiarFormatoFecha(dtFechaActual.Value)
                Dim Codigo As String = txtCodigos.Text
                Dim KilosProg As Integer = Convert.ToInt32(txtKilosPro.Text)
                Dim Sostenimiento As String = txtSostenimientos.Text
                Dim Temperatura As String = txtTemperatura.Text
                Dim TiempoDes As String = txtTiempo.Text
                Dim PCarga As String = cboPCarga.SelectedValue
                Dim PDescarga As String = cboPDescarga.SelectedValue
                Dim POpera As String = cboPOpera.SelectedValue
                Dim Traccion As String = txtTraccion.Text
                Dim Base As String = txtBase.Text
                Dim HoraInicio As String = dtpHoraIncio.Value
                Dim HoraFinal As String = dtpHoraFin.Value
                If (HoraInicio >= HoraFinal) Then
                    MessageBox.Show("Verifique Hora Inicial Tiene Que Ser Menor A La Fecha Final", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                End If
                Dim sql As String = objRecocidoLn.sqlInsertPpal(Cod_Orden, FechaIncial, Codigo, KilosProg, Base, Sostenimiento, Temperatura, HoraInicio, HoraFinal, PCarga, POpera, PDescarga, Traccion, TiempoDes)
                Dim listSql As New List(Of Object)
                listSql.Add(sql)
                listSql.AddRange(Detalle(dtgDetalles, Cod_Orden))
                If (objRecocidoLn.guardarTodo(listSql)) Then
                    Return True
                Else
                    Return False
                End If
            Else
                Return False
            End If

        Catch ex As Exception
            MsgBox("Ingreso De Datos Erroneos " & ex.Message)
            Return False
        End Try
    End Function
    Private Function Detalle(ByVal dtg As DataGridView, ByVal Cod_Orden As String) As List(Of Object)
        '(Nro_Orden,Codigo,Rollo,Peso,Traccion,NumOrdenPro,NumRollo,Colada,Observaciones)
        Dim sqlTotal As String = "INSERT INTO b_Detalle_Recocido VALUES"
        Dim sqlUnit As String = ""
        Dim listSql As New List(Of Object)
        For i = 0 To dtg.RowCount - 1
            Dim Rollo As String = dtg.Item("ROLLO", i).Value
            Dim Codigo As String = dtg.Item("CODIGO", i).Value
            Dim Peso As String = dtg.Item("PESO", i).Value
            Dim Traccion As String = dtg.Item("TRACCION", i).Value
            Dim NumOrdPro As String = dtg.Item("NUM_ORDEN", i).Value
            Dim NumRollo As String = dtg.Item("NUM_ROLLO", i).Value
            Dim Colada As String = dtg.Item("COLADA", i).Value
            Dim Observaciones As String = dtg.Item("OBSERVACIONES", i).Value
            If (Rollo <> Nothing And Codigo <> Nothing And Peso <> Nothing And Traccion <> Nothing And NumOrdPro <> Nothing And NumRollo <> Nothing And Colada <> Nothing) Then
                sqlUnit = sqlTotal & "('" & Cod_Orden & "','" & Codigo & "','" & Rollo & "','" & Peso & "','" & Traccion & "','" & NumOrdPro & "','" & NumRollo & "','" & Colada & "','" & Observaciones & "')"
                listSql.Add(sqlUnit)
            End If
        Next
        Return listSql
    End Function
    Private Sub cargarCombosOperarios(ByVal centro As String)
        If (centro = "2300") Then
            cboPCarga.DataSource = obj_Ing_prodLn.listarOperarios("todos")
            cboPDescarga.DataSource = obj_Ing_prodLn.listarOperarios("todos")
            cboPOpera.DataSource = obj_Ing_prodLn.listarOperarios("todos")
        End If
        cboPCarga.ValueMember = "nit"
        cboPCarga.DisplayMember = "nombres"
        cboPCarga.Text = "Seleccione"

        cboPDescarga.ValueMember = "nit"
        cboPDescarga.DisplayMember = "nombres"
        cboPDescarga.Text = "Seleccione"

        cboPOpera.ValueMember = "nit"
        cboPOpera.DisplayMember = "nombres"
        cboPOpera.Text = "Seleccione"
    End Sub
    Public Function verificar_planilla(ByVal dtg As DataGridView) As Boolean
        Dim resp As Boolean = True
        Dim referencia As String = ""
        For i = 0 To dtgDetalles.RowCount - 1
            Dim Rollo As String = dtg.Item("ROLLO", i).Value
            Dim Codigo As String = dtg.Item("CODIGO", i).Value
            Dim Peso As String = dtg.Item("PESO", i).Value
            Dim Traccion As String = dtg.Item("TRACCION", i).Value
            Dim NumOrdPro As String = dtg.Item("NUM_ORDEN", i).Value
            Dim NumRollo As String = dtg.Item("NUM_ROLLO", i).Value
            Dim Colada As String = dtg.Item("COLADA", i).Value

            If (Rollo = Nothing Or Codigo = Nothing Or Peso = Nothing Or Traccion = Nothing Or NumOrdPro = Nothing Or NumRollo = Nothing Or Colada = Nothing) Then
                resp = False
                i = dtgDetalles.RowCount - 1
            End If
        Next
        Return resp
    End Function
    Public Function verificar_campos()
        Dim KilosProg As Integer = 0
        Dim Cod_Orden As String = txtNumOrdenRec.Text
        Dim FechaIncial As String = objOpSimplesLn.cambiarFormatoFecha(dtFechaActual.Value)
        Dim Codigo As String = txtCodigos.Text
        If Not (objOpsimpesLn.validarCodigo(txtCodigos.Text)) Then
            MessageBox.Show("Codigo no existe !!!.Si tiene alguna duda dirijase al boton de lupa para estar mas seguro sobre el codigo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If
        If (objRecocidoLn.validarNumero(txtKilosPro.Text)) Then
            KilosProg = Convert.ToInt32(txtKilosPro.Text)
        Else
            MsgBox("El valor de los kilos tiene que ser numerico")
            Return False
        End If
        Dim Sostenimiento As String = txtSostenimientos.Text
        Dim Temperatura As String = txtTemperatura.Text
        Dim TiempoDes As String = txtTiempo.Text
        Dim PCarga As String = cboPCarga.SelectedValue
        Dim PDescarga As String = cboPDescarga.SelectedValue
        Dim POpera As String = cboPOpera.SelectedValue
        Dim Traccion As String = txtTraccion.Text
        Dim Base As String = txtBase.Text
        Dim HoraInicio As String = ""
        Dim HoraFinal As String = ""
        If (Cod_Orden = Nothing Or Codigo = Nothing Or Sostenimiento = Nothing Or KilosProg = Nothing Or Temperatura = Nothing Or Traccion = Nothing Or PCarga = Nothing Or PCarga = "Seleccione" Or PDescarga = Nothing Or PDescarga = "Seleccione" Or POpera = Nothing Or POpera = "Seleccione") Then
            Return False
        Else
            Return True
        End If
    End Function
#End Region

#Region "Eventos"
    Private Sub Frm_ing_recocido_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtgDetalles.Rows.Add()
        cargarCombosOperarios(2300)
    End Sub
    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If Not (verificar_planilla(dtgDetalles)) Then
            MessageBox.Show("La Planilla Del Detalle No Puede Estar Vacia", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            If (guardar()) Then
                MessageBox.Show("Orden De Producción Grabada Con Exitó ", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information)
                limpiar()
            Else
                MessageBox.Show("Verifique Nuevamente Datos Erroneos", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub
    Private Sub dtgDetalles_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgDetalles.CellValueChanged
        If (dtgDetalles.Columns(e.ColumnIndex).Name = "PESO") Then
            If Not (objRecocidoLn.validarNumero(dtgDetalles.Item(e.ColumnIndex, e.RowIndex).Value)) Then
                MessageBox.Show("Verifique Que El Valor Para El Peso No Sea Alfanumerico ", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
        If (dtgDetalles.Columns(e.ColumnIndex).Name = "CODIGO") Then
            If Not (objOpsimpesLn.validarCodigo(txtCodigos.Text)) Then
                MessageBox.Show("Codigo No Existe o Lo Ha Digitado Mal ", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub
    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        limpiar()
        txtNumOrdenRec.Focus()
    End Sub
    Private Sub dtgDetalles_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgDetalles.CellContentClick
        Dim col As String = dtgDetalles.Columns(e.ColumnIndex).Name
        Try
            If (col = "AGREGAR") Then
                If (verificar_planilla(dtgDetalles)) Then
                    dtgDetalles.Rows.Add()
                Else
                    MessageBox.Show("Para agregar una nueva linea debe tener todos los campos llenos(exepto el campo observaciones) ", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        Catch ex As Exception
            MsgBox("Error Al Agregar " & ex.Message)
        End Try
    End Sub
    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        FrmCodBodebas.Show()
        FrmCodBodebas.Activate()
        FrmCodBodebas.main("2", "REC")
    End Sub
    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Frm_consutar_recocido.Show()
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
#End Region

End Class