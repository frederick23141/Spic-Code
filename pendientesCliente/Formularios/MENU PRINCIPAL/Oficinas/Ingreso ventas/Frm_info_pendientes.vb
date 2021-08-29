Imports System.Configuration
Imports logicaNegocios
Imports entidadNegocios
Imports System.IO
Imports Microsoft.Office.Interop
Public Class Frm_info_pendientes
    Private objUsuarioLn As New UsuarioLn
    Public vendedor As Integer
    Private objIngVtaLn As New IngVtasLn
    Public strSql As String = ""
    Private usuario As String
    Public Sub Main(ByVal vend As Integer, ByVal usuario As String)
        Me.usuario = usuario
        Dim min As Integer = vend
        Dim max As Integer = vend
        vendedor = vend
        info_ptes()
        If (vend = 1020) Then
            min = 1001
            max = 1099
        End If
        txt_vrtot_prob.Text = objIngVtaLn.vr_total_problem(min, max).ToString("C0")
    End Sub
    Private Sub Frm_info_pendientes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CenterToScreen()
    End Sub
    Public Sub info_ptes()
        Dim vendedores As String = objUsuarioLn.coordinadorVend(usuario)
        If (vendedor = 1020) Then
            Dim criterioVendedor As String = ""
            If (vendedores <> "") Then
                criterioVendedor = " vendedor in (" & vendedores & ")"
            Else
                criterioVendedor = " vendedor >= 1001 AND vendedor <= 1099"
            End If
            If txtNit.Text <> "" And txtNombres.Text <> "" Then

                strSql = "SELECT distinct nit,nombres,codigo As código,fecha, numero As número,  descripcion as descripción , valor_unitario, Cant_pedida, cantidad_despachada, Pendiente,  KilosPendiente, Valor_total, notas, autoriz_texto, autorizacion, usuario " & _
                         "FROM V_pendientes_por_vendedor " & _
                         "WHERE nit LIKE '" & txtNit.Text & "%' AND " & _
                         "      nombres LIKE '%" & txtNombres.Text & _
                         " " & criterioVendedor & " " & _
                         "ORDER BY nombres"

            ElseIf txtNit.Text = "" And txtNombres.Text <> "" Then

                strSql = "SELECT distinct nit,nombres,codigo as código,fecha, numero as número,  descripcion as descripción, valor_unitario, Cant_pedida, cantidad_despachada, Pendiente,  KilosPendiente, Valor_total, notas, autoriz_texto, autorizacion, usuario " & _
                         "FROM V_pendientes_por_vendedor " & _
                         "WHERE nombres LIKE '%" & txtNombres.Text & "%' AND " & _
                         " " & criterioVendedor & " " & _
                         "ORDER BY nombres"


            ElseIf txtNit.Text <> "" And txtNombres.Text = "" Then

                strSql = "SELECT distinct nit,nombres,codigo as código,fecha, numero as número,  descripcion as descripción, valor_unitario, Cant_pedida, cantidad_despachada, Pendiente,  KilosPendiente, Valor_total, notas, autoriz_texto, autorizacion, usuario " & _
                         "FROM V_pendientes_por_vendedor " & _
                         "WHERE nit LIKE '" & txtNit.Text & "%' AND " & _
                         " " & criterioVendedor & " " & _
                         "ORDER BY nombres"

            End If
        Else
            If txtNit.Text <> "" And txtNombres.Text <> "" Then

                strSql = "SELECT distinct nit,nombres,codigo as código,fecha, numero as número,  descripcion as descripción, valor_unitario, Cant_pedida, cantidad_despachada, Pendiente,  KilosPendiente, Valor_total, notas, autoriz_texto, autorizacion, usuario " & _
                         "FROM V_pendientes_por_vendedor " & _
                         "WHERE nit LIKE '" & txtNit.Text & "%' AND " & _
                         "      nombres LIKE '%" & txtNombres.Text & "%' AND " & _
                         "      vendedor = " & vendedor & " " & _
                         "ORDER BY nombres"


            ElseIf txtNit.Text = "" And txtNombres.Text = "" Then

                strSql = "SELECT distinct nit,nombres,codigo as código,fecha, numero as número,  descripcion as descripción, valor_unitario, Cant_pedida, cantidad_despachada, Pendiente,  KilosPendiente, Valor_total, notas, autoriz_texto, autorizacion, usuario " & _
                         "FROM V_pendientes_por_vendedor " & _
                         "WHERE vendedor = " & vendedor & " " & _
                         "ORDER BY nombres"


            ElseIf txtNit.Text = "" And txtNombres.Text <> "" Then

                strSql = "SELECT distinct nit,nombres,codigo as código,fecha, numero as número,  descripcion as descripción, valor_unitario, Cant_pedida, cantidad_despachada, Pendiente,  KilosPendiente, Valor_total, notas, autoriz_texto, autorizacion, usuario " & _
                         "FROM V_pendientes_por_vendedor " & _
                         "WHERE nombres LIKE '%" & txtNombres.Text & "%' AND " & _
                         "      vendedor = " & vendedor & " "


            ElseIf txtNit.Text <> "" And txtNombres.Text = "" Then

                strSql = "SELECT distinct nit,nombres,codigo as código,fecha, numero as número,  descripcion as descripción, valor_unitario, Cant_pedida, cantidad_despachada, Pendiente,  KilosPendiente, Valor_total, notas, autoriz_texto, autorizacion, usuario " & _
                         "FROM V_pendientes_por_vendedor " & _
                         "WHERE nit LIKE '" & txtNit.Text & "%' AND " & _
                         "      vendedor = " & vendedor & " " & _
                         "ORDER BY nombres"

            End If
        End If
        If (strSql <> "") Then
            dtg_pend.DataSource = objIngVtaLn.listarDatos(strSql)
            txt_vr_unit.Text = sumarColumna(dtg_pend, "valor_unitario").ToString("C0")
            txt_vr_tot.Text = sumarColumna(dtg_pend, "Valor_total").ToString("C0")
            txt_cant_ped.Text = sumarColumna(dtg_pend, "Cant_pedida").ToString("N1")
            txt_cant_desp.Text = sumarColumna(dtg_pend, "cantidad_despachada").ToString("N1")
            txt_pend.Text = sumarColumna(dtg_pend, "Pendiente").ToString("N1")
            txt_kilos_pend.Text = sumarColumna(dtg_pend, "KilosPendiente").ToString("N1")
            dtg_pend.Columns("fecha").DefaultCellStyle.Format = "d"
        End If

    End Sub

    Private Sub txtNit_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNit.TextChanged
        txtNombres.Text = ""
        info_ptes()
    End Sub
    Private Sub txtNit_keyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNit.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtNombres_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNombres.TextChanged
        txtNit.Text = ""
        info_ptes()
    End Sub

    Private Sub dtg_pend_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtg_pend.CellDoubleClick
        If (e.RowIndex <> -1) Then
            FrmIngVtas.Show()
            FrmIngVtas.txt_nombres.Text = dtg_pend.Item("nombres", e.RowIndex).Value
            FrmIngVtas.txtNit.Text = dtg_pend.Item("nit", e.RowIndex).Value
            FrmIngVtas.txtRef.Focus()
            FrmIngVtas.cargar_info_client(dtg_pend.Item("Nit", e.RowIndex).Value)
            Me.Close()
        End If

    End Sub
    Public Function sumarColumna(ByVal dtg As DataGridView, ByVal col As String) As Double
        Dim sum As Double = 0
        For i = 0 To dtg.RowCount - 1
            sum = sum + dtg.Item(col, i).Value
        Next
        Return sum
    End Function

    Private Sub btn_ped_prob_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ped_prob.Click
        Frm_ptes_problem.Show()
        Frm_ptes_problem.Main(vendedor, usuario)
    End Sub
End Class
