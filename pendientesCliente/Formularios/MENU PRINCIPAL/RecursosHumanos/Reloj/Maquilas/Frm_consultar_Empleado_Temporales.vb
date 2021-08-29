Imports logicaNegocios

Public Class Frm_consultar_Empleado_Temporales
    Dim objIngresoProdLn As New Ing_prodLn
    Private obj_Ing_prodLn As New Ing_prodLn
    Dim nit As String
    Private objOpSimplesLn As New Op_simpesLn
    Public frm As FrmReg_personal_maquila
    Private Sub Frm_consultar_Empleado_Temporales_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargar_temporales()
        cargar_Cbo()
        TabControl1.SelectedTab = TabPage2
    End Sub
    Public Sub main(ByVal frm As FrmReg_personal_maquila)
        Me.frm = frm
    End Sub
    Private Sub cargar_temporales()
        Dim sql As String
        Dim dt As New DataTable
        sql = "select nit,nombres,direccion,telefono_1,centro,oficio,planta,basico_hora,basico_mes from J_personal_maquila"
        dt = objIngresoProdLn.listar_datatable(sql, "CONTROL")
        blinding_temporales = New BindingSource()
        blinding_temporales.DataSource = dt
        dtg_temporales.DataSource = blinding_temporales
    End Sub
    Private Sub txt_nombres_TextChanged(sender As Object, e As EventArgs) Handles txt_nombres.TextChanged
        blinding_temporales.Filter = String.Format("nombres LIKE '{0}%'", txt_nombres.Text)
    End Sub
    Private Sub dtg_temporales_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtg_temporales.CellContentClick
        Dim fila As Integer = e.RowIndex
        Dim col As String = dtg_temporales.Columns(e.ColumnIndex).Name
        If (fila >= 0) Then
            If (col = "nit") Then
                txt_nit.Text = dtg_temporales.Item("nit", fila).Value()
                txt_nombre.Text = dtg_temporales.Item("nombres", fila).Value()
                If IsDBNull(dtg_temporales.Item("direccion", fila).Value()) = False Then
                    txt_direccion.Text = dtg_temporales.Item("direccion", fila).Value()
                End If
                If IsDBNull(dtg_temporales.Item("telefono_1", fila).Value()) = False Then
                    txt_telefono.Text = dtg_temporales.Item("telefono_1", fila).Value()
                End If
                If IsDBNull(dtg_temporales.Item("centro", fila).Value()) = False Then
                    cbo_centro_costos.SelectedValue = dtg_temporales.Item("centro", fila).Value()
                End If
                If IsDBNull(dtg_temporales.Item("oficio", fila).Value()) = False Then
                    cbo_oficio.SelectedValue = dtg_temporales.Item("oficio", fila).Value()
                End If
                If IsDBNull(dtg_temporales.Item("planta", fila).Value()) = False Then
                    cbo_planta.SelectedValue = dtg_temporales.Item("planta", fila).Value()
                End If
                If IsDBNull(dtg_temporales.Item("basico_hora", fila).Value()) = False Then
                    txtbasico.Text = dtg_temporales.Item("basico_hora", fila).Value()
                End If
                If IsDBNull(dtg_temporales.Item("basico_mes", fila).Value()) = False Then
                    txt_bmes.Text = dtg_temporales.Item("basico_mes", fila).Value()
                End If
                TabControl1.SelectedTab = TabPage1
            End If
        End If
    End Sub
    Private Sub cargar_Cbo()
        Dim dt As New DataTable
        Dim dr As DataRow
        Dim sql As String
        sql = "SELECT centro,( CAST (centro AS varchar(25))+ '-' + descripcion )As descripcion " & _
                        "FROM centros where centro in (1200,2100,2117,2200,2300,2400,2500,2600,2800,3100,3200,4100,4500,3500,5200,6200,6400,4200,4100,4300)"
        dt = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        dr = dt.NewRow
        dr("centro") = 0
        dr("descripcion") = "TODO"
        dt.Rows.Add(dr)
        cbo_centro_costos.DataSource = dt
        cbo_centro_costos.ValueMember = "centro"
        cbo_centro_costos.DisplayMember = "descripcion"
        cbo_centro_costos.SelectedValue = 0

        sql = "SELECT oficio,( CAST (oficio AS varchar(25))+ '-' + descripcion )As descripcion " & _
                  "FROM y_oficios "
        dt = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        dr = dt.NewRow
        dr("oficio") = 0
        dr("descripcion") = "TODO"
        dt.Rows.Add(dr)
        cbo_oficio.DataSource = dt
        cbo_oficio.ValueMember = "oficio"
        cbo_oficio.DisplayMember = "descripcion"
        cbo_oficio.SelectedValue = 0


        sql = "SELECT planta,( CAST (planta AS varchar(25))+ '-' + descripcion )As descripcion " & _
                  "FROM y_plantas "
        dt = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        dr = dt.NewRow
        dr("planta") = 0
        dr("descripcion") = "TODO"
        dt.Rows.Add(dr)
        cbo_planta.DataSource = dt
        cbo_planta.ValueMember = "planta"
        cbo_planta.DisplayMember = "descripcion"
        cbo_planta.SelectedValue = 0

        sql = "SELECT turno,( CAST (turno AS varchar(25))+ '-' + descripcion )As descripcion " & _
          "FROM y_turnos "
        dt = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        dr = dt.NewRow
        dr("turno") = 0
        dr("descripcion") = "TODO"
        dt.Rows.Add(dr)
        cbo_turno.DataSource = dt
        cbo_turno.ValueMember = "turno"
        cbo_turno.DisplayMember = "descripcion"
        cbo_turno.SelectedValue = 0

    End Sub
    Private Sub txt_guardar_Click(sender As Object, e As EventArgs) Handles txt_guardar.Click
        If validar_temporal() Then
            Dim nit As String = txt_nit.Text
            Dim centro As String = cbo_centro_costos.SelectedValue
            Dim oficio As String = cbo_oficio.SelectedValue
            Dim planta As String = cbo_planta.SelectedValue
            Dim turno As String = cbo_turno.SelectedValue
            Dim direccion As String = txt_direccion.Text
            Dim telefono As String = txt_telefono.Text
            Dim fecha_ingreso As String = dtp_fecha.Value.ToString("yyyy/MM/dd")
            If telefono = "" Then
                telefono = "0"
            End If
            Dim sql As String = "update J_personal_maquila set centro=" & centro & ",oficio=" & oficio & ",planta=" & planta & " ,basico_hora=" & txtbasico.Text & ",basico_mes=" & txt_bmes.Text & ",turno=" & turno & ",contrato=1,direccion='" & direccion & "',telefono_1=" & telefono & ",fecha_ingreso='" & fecha_ingreso & "',nombres='" & txt_nombre.Text & "' where nit=" & nit & ""
            'Tambien sirve para ejecutar 
            obj_Ing_prodLn.consultar_valor(sql, "CONTROL")
            MessageBox.Show("Temporal modificado correctamente", "Temporal modificado", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
    Private Function validar_temporal()
        Dim resp As Boolean = False
        If txt_nit.Text <> "" Then
            If cbo_centro_costos.Text <> "TODO" Then
                If cbo_oficio.Text <> "TODO" Then
                    If cbo_planta.Text <> "TODO" Then
                        If txtbasico.Text <> "" And IsNumeric(txtbasico.Text) Then
                            If txt_bmes.Text <> "" And IsNumeric(txtbasico.Text) Then
                                If cbo_turno.Text <> "TODO" Then
                                    resp = True
                                Else
                                    MessageBox.Show("Seleccione un turno", "No ha ingresado basico", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                End If
                            Else
                                MessageBox.Show("Ingrese un valor numerico para el basico de mes", "No ha ingresado basico", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            End If
                        Else
                            MessageBox.Show("Ingrese un valor numerico para el basico de hora", "No ha ingresado basico", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If
                    Else
                        MessageBox.Show("Seleccione una planta", "No ha seleccionado una planta", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                Else

                    MessageBox.Show("Seleccione un oficio", "No ha seleccionado un oficio", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                MessageBox.Show("Seleccione un centro de costos", "No ha seleccionado centro de costos", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            MessageBox.Show("Ingrese la cedula", "No hay cedula", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Return resp
    End Function
    Private Sub txt_bmes_TextChanged(sender As Object, e As EventArgs) Handles txt_bmes.TextChanged
        Dim salario_hora As Integer
        If txt_bmes.Text.Length >= 6 Then
            salario_hora = ((txt_bmes.Text) / 240)
        End If
        txtbasico.Text = salario_hora
    End Sub
End Class