Imports logicaNegocios
Imports entidadNegocios
Public Class Frm_historico_certificados
    Private carga_comp As Boolean = True
    Private objIngProdLn As New Ing_prodLn
    Private objOp_simpesLn As New Op_simpesLn
    Private objOperacionesForm As OperacionesFormularios = New OperacionesFormularios
    Private usuario As New UsuarioEn

    Public Sub Main(ByVal usuario As UsuarioEn)
        Me.usuario = usuario
    End Sub

    Private Sub btn_actualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_actualizar.Click
        cargarConsulta()
    End Sub
    Private Sub cargarConsulta()
        Dim sql As String = "SELECT numero,numero_pedido,fecha,nit,nombres,codigo,descripcion,tot_peso " & _
                                "FROM J_v_certif_calidad "

        Dim whereSql As String = "WHERE  anulado is null "
        Dim orderSql As String = "ORDER BY numero desc"
        If (txt_num_ped.Text <> "") Then
            whereSql &= " AND  numero_pedido like '" & txt_num_ped.Text & "%'"
        ElseIf (txtNit.Text <> "") Then
            whereSql &= " AND  nit like '" & txtNit.Text & "%'"
        ElseIf (txtNombres.Text <> "") Then
            whereSql &= " AND nombres like '%" & txtNombres.Text & "%'"
        ElseIf (txtNumero.Text <> "") Then
            whereSql &= " AND numero like '" & txtNumero.Text & "%'"
        End If
        sql &= whereSql & orderSql
        dtgConsulta.DataSource = objIngProdLn.listar_datatable(sql, "PRODUCCION")
    End Sub

    Private Sub txtNit_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNit.TextChanged
        If (carga_comp And (txtNit.Text.Length > 1 Or txtNit.Text.Length = 0)) Then
            carga_comp = False
            txtNumero.Text = ""
            txtNombres.Text = ""
            txt_num_ped.Text = ""
            carga_comp = True
        End If
    End Sub

    Private Sub txtNombres_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNombres.TextChanged
        If (carga_comp And (txtNombres.Text.Length > 2 Or txtNombres.Text.Length = 0)) Then
            carga_comp = False
            txtNit.Text = ""
            txtNumero.Text = ""
            txt_num_ped.Text = ""
            carga_comp = True
        End If
    End Sub
    Private Sub txtNumero_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNumero.TextChanged
        If (carga_comp And (txtNumero.Text.Length > 0 Or txtNombres.Text.Length = 0)) Then
            carga_comp = False
            txtNit.Text = ""
            txtNombres.Text = ""
            txt_num_ped.Text = ""
            carga_comp = True
        End If
    End Sub
    Private Sub txt_num_ped_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_num_ped.TextChanged
        If (carga_comp And (txt_num_ped.Text.Length > 0 Or txt_num_ped.Text.Length = 0)) Then
            carga_comp = False
            txtNit.Text = ""
            txtNombres.Text = ""
            txtNumero.Text = ""
            carga_comp = True
        End If
    End Sub
    Private Sub btnExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportar.Click
        objOperacionesForm.ExportarDatosExcel(dtgConsulta, "Certificados de calidad")
    End Sub

    Private Sub dtgConsulta_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgConsulta.CellContentClick
        Dim fila As Integer = e.RowIndex
        Dim col As String = dtgConsulta.Columns(e.ColumnIndex).Name
        Dim codigo As String = ""
        Dim resp As Double = 0
        If (fila >= 0) Then
            If (col = "colVer") Then
                cargarCertificado(dtgConsulta.Item("numero", e.RowIndex).Value)
            ElseIf (col = "colDelete") Then
                resp = MessageBox.Show("Esta seguro de eliminar el registro? ", "Eliminar.", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If (resp = 6) Then
                    eliminar(dtgConsulta.Item("numero", e.RowIndex).Value)
                    cargarConsulta()
                End If
            End If
        End If
    End Sub
    Private Sub eliminar(ByVal numero As Double)
        Dim resp As String = InputBox("Ingrese motivo de anulación del certificado!", "ver despachos")
        Dim sql As String = ""
        If (resp <> "") Then
            resp &= " usuario: " & usuario.nombre & " " & Now.Date
            sql = "UPDATE  J_certificado_calidad SET anulado = 1 , motivo_anulacion = '" & resp & "' WHERE numero = " & numero
            If (objOp_simpesLn.ejecutar(sql, "PRODUCCION") > 0) Then
                MessageBox.Show("Registro eliminado en forma correcta", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Eror al eliminar el registro, comuniquese con el administrador del sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub
    Private Sub cargarCertificado(ByVal numero As Double)
        Dim listDetRollos As New List(Of DetalleRollosEn)
        Dim listDetRollos2 As New List(Of DetalleRollosEn)
        Dim objFichaAlambEn As New FichaAlambEn
        Dim listOfListRollos As New List(Of List(Of DetalleRollosEn))
        Dim frm As New FrmReportesFichas()
        listOfListRollos = objIngProdLn.cargarObjRolloCalidad(numero)
        listDetRollos = listOfListRollos(0)
        listDetRollos2 = listOfListRollos(1)
        objFichaAlambEn = objIngProdLn.cargarObjCertCalidad(numero)
        Dim obj_calidad_alambronEn As New Calidad_alambronEn
        Dim dt_calidad_alambron As New DataTable
        dt_calidad_alambron = objOp_simpesLn.listar_datatable("SELECT calidad,carbono,magneso,fosforo_max,azufre_max FROM J_calidad_alambron WHERE calidad = " & objFichaAlambEn.calidad_real, "PRODUCCION")
        For i = 0 To dt_calidad_alambron.Rows.Count - 1
            obj_calidad_alambronEn.calidad = dt_calidad_alambron.Rows(i).Item("calidad")
            obj_calidad_alambronEn.carbono = dt_calidad_alambron.Rows(i).Item("carbono")
            obj_calidad_alambronEn.magneso = dt_calidad_alambron.Rows(i).Item("magneso")
            obj_calidad_alambronEn.fosforo_max = dt_calidad_alambron.Rows(i).Item("fosforo_max")
            obj_calidad_alambronEn.azufre_max = dt_calidad_alambron.Rows(i).Item("azufre_max")
        Next
        frm.Main("Reporte de fichas técnicas", objFichaAlambEn, listDetRollos, listDetRollos2, obj_calidad_alambronEn)
        frm.Show()
    End Sub
    Private Sub btn_ppal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ppal.Click
        FrmPrincipal.Show()
        Me.Close()
        FrmPrincipal.Activate()
    End Sub
    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        FrmLogin.Show()
        FrmPrincipal.Close()
        Me.Close()
    End Sub
End Class