Imports System.Configuration
Imports logicaNegocios
Imports System.IO
Imports Microsoft.Office.Interop
#Disable Warning BC40056 ' El espacio de nombres o el tipo especificado en el 'System.Data.SqlServerCe' Imports no contienen ningún miembro público o no se encuentran. Asegúrese de que el espacio de nombres o el tipo se hayan definido y de que contengan al menos un miembro público. Asegúrese de que el nombre del elemento importado no use ningún alias.
Imports System.Data.SqlServerCe
#Enable Warning BC40056 ' El espacio de nombres o el tipo especificado en el 'System.Data.SqlServerCe' Imports no contienen ningún miembro público o no se encuentran. Asegúrese de que el espacio de nombres o el tipo se hayan definido y de que contengan al menos un miembro público. Asegúrese de que el nombre del elemento importado no use ningún alias.
Public Class Frm_Solicitud_Correccion
    Private obj_Ing_prodLn As New Ing_prodLn
    Private obj_Sol As New SolicitudCorrecionLn
    Private obj_Sum As New Op_simpesLn
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
    Private Sub Frm_Solicitud_Correccion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.txtDescripcion.Focus()
        Me.AutoScroll = True
        Dim sql As String
        Dim col As New DataColumn
        cboFechaEntrega.Value = Now.AddDays(-1)
        cboFechaHora.Value = Now.AddDays(-1)
        cboFechaIniciar.Value = Now.AddDays(-1)
        sql = "select codigoM,Nombre from J_Maquinas where Activa=1"
        cboMaquina.DataSource = obj_Ing_prodLn.listar_datatable(sql, "PRODUCCION")
        cboMaquina.ValueMember = "codigoM"
        cboMaquina.DisplayMember = "Nombre"
        cboMaquina.Text = "Seleccione"

        sql = "select id_Seccion,nombre from b_Seccion ORDER BY nombre "
        cboSeccion.DataSource = obj_Ing_prodLn.listar_datatable(sql, "PRODUCCION")
        cboSeccion.ValueMember = "id_Seccion"
        cboSeccion.DisplayMember = "nombre"
        cboSeccion.Text = "Seleccione"

        sql = "select nit,nombres FROM V_nom_personal_Activo_con_maquila where centro not in (4200) order by nombres"
        cboQReaSol.DataSource = obj_Ing_prodLn.listar_datatable(sql, "CORSAN")
        cboQReaSol.ValueMember = "nit"
        cboQReaSol.DisplayMember = "nombres"
        cboQReaSol.Text = "Seleccione"

        sql = "select nit,nombres FROM V_nom_personal_Activo_con_maquila where centro not in (4200) order by nombres"
        cboQResSatisfaccion.DataSource = obj_Ing_prodLn.listar_datatable(sql, "CORSAN")
        cboQResSatisfaccion.ValueMember = "nit"
        cboQResSatisfaccion.DisplayMember = "nombres"
        cboQResSatisfaccion.Text = "Seleccione"

        sql = "select nit,nombres FROM V_nom_personal_Activo_con_maquila where centro not in (4200) order by nombres"
        cboQResSol.DataSource = obj_Ing_prodLn.listar_datatable(sql, "CORSAN")
        cboQResSol.ValueMember = "nit"
        cboQResSol.DisplayMember = "nombres"
        cboQResSol.Text = "Seleccione"

        sql = "select nit,nombres FROM V_nom_personal_Activo_con_maquila where centro not in (4200) order by nombres"
        cboQuienSolicita.DataSource = obj_Ing_prodLn.listar_datatable(sql, "CORSAN")
        cboQuienSolicita.ValueMember = "nit"
        cboQuienSolicita.DisplayMember = "nombres"
        cboQuienSolicita.Text = "Seleccione"
        dtgRepuestos.Rows.Clear()
        cargar_cbo_dtg()
        '  dtgRepuestos.Rows.Add()

    End Sub
    Private Sub cargar_cbo_dtg()

        Dim sql As String = ""
        Dim dt As DataTable
        Dim row As DataRow
        sql = "select id_Repuesto,descripcion from b_Repuestos"
        dt = obj_Ing_prodLn.listar_datatable(sql, "PRODUCCION")
        row = dt.NewRow
        'row("descripcion") = "Seleccione"
        dt.Rows.Add(row)
        cboRepuesto.DataSource = dt
        cboRepuesto.ValueMember = "id_Repuesto"
        cboRepuesto.DisplayMember = "descripcion"
        'For i = 0 To 2
        '    dtgRepuestos.Rows.Add()
        'Next
    End Sub
    Private Sub limpiar()
        cboMaquina.Text = "Seleccione"
        cboSeccion.Text = "Seleccione"
        cboFechaEntrega.Text = Date.Today
        cboFechaHora.Text = Date.Today
        cboFechaIniciar.Text = Date.Today
        cboQReaSol.Text = "Seleccione"
        cboQResSatisfaccion.Text = "Seleccione"
        cboQResSol.Text = "Seleccione"
        cboQuienSolicita.Text = "Seleccione"
        dtgRepuestos.Rows.Clear()
        txtCausas.Text = ""
        txtCosto.Text = ""
        txtDescripcion.Text = ""
        txtNota.Text = ""
        txtProblemaEnc.Text = ""
        txtSolucion.Text = ""
    End Sub
    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        FrmLogin.Show()
        FrmPrincipal.Close()
        Me.Close()
    End Sub
    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        FrmPrincipal.Show()
        Me.Close()
        FrmPrincipal.Activate()
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        limpiar()
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        guardar()
    End Sub
    Private Sub guardar()
        Dim idSolicitud As Integer = Convert.ToInt32(obj_Sol.CrearId())
        Dim uni_ini As String = 0
        Dim uni_fin As String = 0
        Dim resp As Integer = 0
        Try
            Dim costos As Double = Convert.ToDouble(txtCosto.Text)
            If (cboSeccion.Text <> "Seleccione" And cboMaquina.Text <> "Seleccione" And cboQReaSol.Text <> "Seleccione" And cboQResSatisfaccion.Text <> "Seleccione" And cboQResSol.Text <> "Seleccione" And cboQuienSolicita.Text <> "Seleccione" And txtDescripcion.Text <> Nothing And txtCausas.Text <> Nothing And txtSolucion.Text <> Nothing And txtNota.Text <> Nothing And txtCosto.Text <> Nothing) Then
                Dim fechaHora As String = obj_Sum.cambiarFormatoFecha(cboFechaHora.Value.Date)
                Dim fechaIniciar As String = obj_Sum.cambiarFormatoFecha(cboFechaIniciar.Value.Date)
                Dim fechaEntrega As String = obj_Sum.cambiarFormatoFecha(cboFechaEntrega.Value.Date)
                Dim Seccion As String = cboSeccion.SelectedValue
                Dim Maquina As String = cboMaquina.SelectedValue
                Dim q_Res_Sol As String = cboQResSol.Text
                Dim q_Rea_Sol As String = cboQReaSol.Text
                Dim q_Sol As String = cboQuienSolicita.Text
                Dim q_Res_Sat As String = cboQResSatisfaccion.Text
                Dim descripcion As String = txtDescripcion.Text
                Dim problema As String = txtProblemaEnc.Text
                Dim causas As String = txtCausas.Text
                Dim solucion As String = txtSolucion.Text
                Dim nota As String = txtNota.Text
                Dim repuestos As String = ""
                Dim sql_t As String = ""
                Dim listSql As New List(Of Object)
                Dim sql As String = "INSERT INTO b_Solicitud_Correcion(id_Solicitud,fechaIngresada,seccion,maquina,solicitante,q_Resive,q_Realiza,fecha_IniciarTra,descripcion,problema,causas,solucion,nota,fecha_Entrega,q_Recibe_Satisfaccion,costos) " & _
                                                        "VALUES(" & idSolicitud & ",'" & fechaHora & "','" & Seccion & "','" & Maquina & "','" & q_Sol & "','" & q_Res_Sol & "','" & q_Rea_Sol & "','" & fechaIniciar & "','" & descripcion & "','" & problema & "','" & causas & "','" & solucion & "','" & nota & "','" & fechaEntrega & "','" & q_Res_Sat & "'," & costos & ")"
                listSql.Add(sql)
                listSql.AddRange(retornarRepuestos(idSolicitud))
                If (obj_Sol.guardarTodo(listSql)) Then
                    MessageBox.Show("Su planilla fue ingresada en forma exitosa! ", "Correcto!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("No puede ingresar dos repuestos iguales! ", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)

                End If
            Else
                MessageBox.Show("Revise si algun campo esta vacio ó no ha seleccionado alguna opcion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Function retornarRepuestos(ByVal idSolicitud As Integer) As List(Of Object)
        Dim listSql As New List(Of Object)
        Dim sqlPpal As String = "INSERT INTO b_rep_solicitud (id_Respuesto, id_Solicitud) VALUES ('" & idSolicitud & "','"
        Dim sqlUnit As String = ""
        For i = 0 To dtgRepuestos.RowCount - 1
            If (dtgRepuestos.Item("cboRepuesto", i).Value <> Nothing) Then
                sqlUnit = sqlPpal + Convert.ToString(dtgRepuestos.Item("cboRepuesto", i).Value) & "')"
                listSql.Add(sqlUnit)
            End If

        Next
        Return listSql
    End Function


    Private Sub dtgRepuestos_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgRepuestos.CellContentClick
        Dim fila As Integer = e.RowIndex
        Dim col As String = dtgRepuestos.Columns(e.ColumnIndex).Name
        Try

            If (col = "btnEliminar") Then
                dtgRepuestos.Rows.RemoveAt(e.RowIndex)
            ElseIf (col = "cboRepuesto") Then
                If (repuestoRepetido(dtgRepuestos.Item("cboRepuesto", e.RowIndex).Value, e.RowIndex)) Then
                    MsgBox("repetido")
                Else
                    dtgRepuestos.Rows.Add()
                End If
            End If

        Catch ex As Exception
            MsgBox("No puede eliminar una fila vacia")
        End Try
    End Sub
    Private Function repuestoRepetido(ByVal repuesto As String, ByVal fila As Integer) As Boolean
        For i = 0 To dtgRepuestos.RowCount - 1
            If (dtgRepuestos.Item("cboRepuesto", i).Value = repuesto And i <> fila) Then
                Return True
            End If
        Next
        Return False
    End Function
    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Frm_Consultar_Mante.Show()
    End Sub


    Private Sub dtgRepuestos_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgRepuestos.CellValueChanged
        Dim col As String = dtgRepuestos.Columns(e.ColumnIndex).Name
        If (col = "cboRepuesto") Then
            If (repuestoRepetido(dtgRepuestos.Item("cboRepuesto", e.RowIndex).Value, e.RowIndex)) Then
                MsgBox("repetido")
                dtgRepuestos.Rows.RemoveAt(e.RowIndex)
            End If
        End If
    End Sub
End Class