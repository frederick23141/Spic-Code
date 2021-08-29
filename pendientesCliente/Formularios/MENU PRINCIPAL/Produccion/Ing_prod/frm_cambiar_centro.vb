Imports logicaNegocios
Imports accesoDatos
Imports entidadNegocios
Public Class frm_cambiar_centro
    Private obj_Ing_prodLn As New Ing_prodLn
    Dim centros As String = ""
    Private objOpSimplesLn As New Op_simpesLn
    Dim usuario As New UsuarioEn
    Public Sub main(ByVal usuario As UsuarioEn)
        Me.usuario = usuario
        cargar_cbo()
    End Sub
    Private Sub cargar_cbo()
        Dim fecha_menos_1_mes As Date = Now.AddMonths(-1)
        Dim dt As New DataTable
        Dim dr As DataRow
        Dim sql As String
        Dim where_sql As String = ""
        If (usuario.permiso.Trim <> "ADMIN" And usuario.permiso.Trim <> "NOMINA") Then
            Dim nit As Double = usuario.nit
            Dim listCentros As DataTable = objOpSimplesLn.listar_datatable("SELECT centro FROM J_coordinador_centros_costos WHERE nit =" & nit, "PRODUCCION")
            For i = 0 To listCentros.Rows.Count - 1
                centros &= listCentros.Rows(i).Item("centro")
                If (i <> listCentros.Rows.Count - 1) Then
                    centros &= ","
                End If
            Next
        End If
        If centros = "" Then
            centros = "1200,2100,2117,2200,2300,2400,2500,2600,2800,3100,3200,4100,4300,3500,5200,6200,6400"
        End If

        where_sql &= "WHERE centro IN(" & centros & ")"
        sql = "SELECT centro,( CAST (centro AS varchar(25))+ '-' + descripcion )As descripcion " & _
                        "FROM centros " & _
                            where_sql
        dt = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        dr = dt.NewRow
        dr("centro") = 0
        dr("descripcion") = "SELECCIONE"
        dt.Rows.Add(dr)
        cbo_centro.DataSource = dt
        cbo_centro.ValueMember = "centro"
        cbo_centro.DisplayMember = "descripcion"
        cbo_centro.SelectedValue = 0

        sql = "select nit,nombres from V_nom_personal_Activo_con_maquila"
        dt = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        dr = dt.NewRow
        dr("nit") = 0
        dr("nombres") = "SELECCIONE"
        dt.Rows.Add(dr)
        cbo_operario.DataSource = dt
        cbo_operario.ValueMember = "nit"
        cbo_operario.DisplayMember = "nombres"
        cbo_operario.SelectedValue = 0
    End Sub
    Private Function validar_ingreso()
        Dim resp As Boolean = False
        If cbo_centro.Text <> "SELECCIONE" Then
            If cbo_operario.Text <> "SELECCIONE" Then
                resp = True
            Else
                MessageBox.Show("Ingrese el centro", "Seleccione el centro", MessageBoxButtons.OK, MessageBoxIcon.Question)
            End If
        Else
            MessageBox.Show("Ingrese el centro", "Seleccione el centro", MessageBoxButtons.OK, MessageBoxIcon.Question)
        End If
        Return resp
    End Function
    Private Sub btn_mod_Click(sender As Object, e As EventArgs) Handles btn_mod.Click
        If validar_ingreso() Then
            Dim sql, centro As String
            Dim sw As Boolean = False
            sql = "select centro_planta from y_personal_contratos where nit=" & cbo_operario.SelectedValue & ""
            centro = objOpSimplesLn.consultValorTodo(sql, "CORSAN")
            If centro <> "" Then
                sw = True
            End If
            If sw = False Then
                sql = "select centro_planta from J_personal_maquila where nit=" & cbo_operario.SelectedValue & ""
                centro = objOpSimplesLn.consultValorTodo(sql, "CONTROL")
            End If
            If centro = "" Then
                MessageBox.Show("El usuario no existe", "Usuario no existe", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("El centro que tenia es " & centro & "", "Centro del empleado", MessageBoxButtons.OK, MessageBoxIcon.Information)
                If sw = True Then
                    sql = "update y_personal_contratos set centro_planta=" & cbo_centro.SelectedValue & " where nit=" & cbo_operario.SelectedValue & ""
                    objOpSimplesLn.ejecutar(sql, "CORSAN")
                Else
                    sql = "update J_personal_maquila set centro_planta=" & cbo_centro.SelectedValue & " where nit=" & cbo_operario.SelectedValue & ""
                    objOpSimplesLn.ejecutar(sql, "CONTROL")
                End If
                MessageBox.Show("Se ha actualizado el centro de costos de planta", "Centro de costo actualizado", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub
End Class