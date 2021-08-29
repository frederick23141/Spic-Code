Imports logicaNegocios
Public Class frm_codigo_vel_tref
    Private objOpSimplesLn As New Op_simpesLn

    Private Sub Frm_codigo_vel_tref_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargar_codigos()
        cargar_cbo()

    End Sub
    Private Sub cargar_cbo()
        Dim dt As New DataTable
        Dim row As DataRow
        Dim sql As String
        sql = "select  codigoM,nombre   from j_Maquinas where TipoMaquina = 1 AND activa = 1 "
        dt = New DataTable
        dt = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")
        row = dt.NewRow
        row("codigoM") = 0
        row("nombre") = "Seleccione"
        dt.Rows.Add(row)
        cbo_tref.DataSource = dt
        cbo_tref.ValueMember = "codigoM"
        cbo_tref.DisplayMember = "nombre"
        cbo_tref.SelectedValue = 0


    End Sub
    Private Sub cargar_codigos()
        Dim sql As String
        sql = "select id_maq_vel,codigo,id_tref,velocidad from J_control_vel_maq"
        bd_cod_vel = New BindingSource()
        bd_cod_vel.DataSource = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        dtg_codigos_val.DataSource = bd_cod_vel
    End Sub
    Private Sub Btn_guardar_Click(sender As Object, e As EventArgs) Handles btn_guardar.Click
        If validar() Then
            Dim sql As String
            Dim codigo As String = txtcod.Text
            Dim cod_tref As String = cbo_tref.SelectedValue()
            Dim vel As String = txtvel.Text
            sql = "insert into J_control_vel_maq (codigo,id_tref,velocidad) values('" & codigo & "'," & cod_tref & "," & vel & ")"
            objOpSimplesLn.ejecutar(sql, "CORSAN")
            MessageBox.Show("El codigo a sido guardado", "Codigo guardado", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cargar_codigos()
        End If
    End Sub
    Private Function validar()
        Dim resp As Boolean = False
        If txtcod.Text <> "" Then
            If txtvel.Text <> "" And IsNumeric(txtvel.Text) Then
                If cbo_tref.Text <> "Seleccione" Then
                    resp = True
                Else
                    MessageBox.Show("No se ha seleccionado la trefiladora", "Trefiladora no ha sido seleccionada", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                MessageBox.Show("El campo velocidad esta vacio o no es valido", "Campo codigo no valido", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            MessageBox.Show("El campo codigo esta vacio", "Campo codigo no valido", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        Return resp
    End Function
    Private Function validar_mod()
        Dim resp As Boolean = False
        If txtvel_mod.Text <> "" And IsNumeric(txtvel_mod.Text) Then

            resp = True

        Else
            MessageBox.Show("El campo velocidad esta vacio o no es valido", "Campo codigo no valido", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Return resp
    End Function
    Private Sub Txtcodigo_TextChanged(sender As Object, e As EventArgs) Handles txtcodigo.TextChanged
        bd_cod_vel.Filter = String.Format("codigo LIKE '{0}%'", txtcodigo.Text)
    End Sub
    Private Sub Btn_codigo_Click(sender As Object, e As EventArgs) Handles btn_codigo.Click
        cargar_codigos()
    End Sub
    Private Sub Btn_modificar_Click(sender As Object, e As EventArgs) Handles btn_modificar.Click
        If validar_mod() Then
            Dim sql As String
            Dim codigo As String = dtg_codigos_val.Item("codigo", dtg_codigos_val.CurrentCell.RowIndex).Value
            Dim id_tref As String = dtg_codigos_val.Item("id_tref", dtg_codigos_val.CurrentCell.RowIndex).Value
            Dim vel As String = txtvel_mod.Text
            sql = "update J_control_vel_maq set velocidad=" & vel & " where codigo='" & codigo & "' and id_tref=" & id_tref & ""
            objOpSimplesLn.ejecutar(sql, "CORSAN")
            MessageBox.Show("El codigo a sido modificado", "Codigo guardado", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cargar_codigos()
            pn_modificar.Visible = False
        End If
    End Sub
    Private Sub ModificarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ModificarToolStripMenuItem.Click
        pn_modificar.Visible = True
    End Sub
End Class