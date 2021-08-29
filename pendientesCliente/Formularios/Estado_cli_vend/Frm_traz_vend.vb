Imports System.Configuration
Imports logicaNegocios
Imports entidadNegocios
Imports System.IO
Imports Microsoft.Office.Interop
Public Class frmCarteraIngVtas
    Public vendedor As Integer
    Private objIngVtaLn As New IngVtasLn
    Public strSql As String = ""

    Public Sub Main(ByVal vend As Integer)
        vendedor = vend
        cartera()
    End Sub

    Private Sub frmCarteraIngVtas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CenterToScreen()
    End Sub
    Public Sub cartera()
        If (vendedor = 1020) Then

            If txtNit.Text <> "" And txtNombres.Text <> "" Then

                strSql = "SELECT Tipo, Numero,nombres,Nit, Fecha, Vencimiento, Valor_Total, Valor_Aplicado, Saldo, Dias_Vencido, Sin_Vencer, de_1_a_30, de_31_a_60, de_61_a_90, de_91_a_120, Mas_de_120 " & _
                         "FROM V_cartera_edades_jjv " & _
                         "WHERE nit LIKE '" & txtNit.Text & "%' AND " & _
                         "      nombres LIKE '%" & txtNombres.Text & "%' AND " & _
                         " vendedor >=1001 and vendedor<=1099 and  saldo <> 0 " & _
                         "ORDER BY nombres"
            ElseIf txtNit.Text = "" And txtNombres.Text <> "" Then

                strSql = "SELECT Tipo, Numero,nombres,Nit, Fecha, Vencimiento, Valor_Total, Valor_Aplicado, Saldo, Dias_Vencido, Sin_Vencer, de_1_a_30, de_31_a_60, de_61_a_90, de_91_a_120, Mas_de_120 " & _
                         "FROM V_cartera_edades_jjv " & _
                         "WHERE nombres LIKE '%" & txtNombres.Text & "%' AND " & _
                         " vendedor >=1001 and vendedor<=1099 and  saldo <> 0 " & _
                         "ORDER BY nombres"

            ElseIf txtNit.Text <> "" And txtNombres.Text = "" Then

                strSql = "SELECT Tipo, Numero,nombres,Nit, Fecha, Vencimiento, Valor_Total, Valor_Aplicado, Saldo, Dias_Vencido, Sin_Vencer, de_1_a_30, de_31_a_60, de_61_a_90, de_91_a_120, Mas_de_120 " & _
                         "FROM V_cartera_edades_jjv " & _
                         "WHERE nit LIKE '" & txtNit.Text & "%' AND " & _
                         "vendedor >=1001 and vendedor<=1099 and  saldo <> 0 " & _
                         "ORDER BY nombres"
            End If
        Else
            If txtNit.Text <> "" And txtNombres.Text <> "" Then

                strSql = "SELECT Tipo, Numero,nombres,Nit, Fecha, Vencimiento, Valor_Total, Valor_Aplicado, Saldo, Dias_Vencido, Sin_Vencer, de_1_a_30, de_31_a_60, de_61_a_90, de_91_a_120, Mas_de_120 " & _
                         "FROM V_cartera_edades_jjv " & _
                         "WHERE nit LIKE '" & txtNit.Text & "%' AND " & _
                         "      nombres LIKE '%" & txtNombres.Text & "%' AND saldo <> 0 AND " & _
                         "      vendedor = " & vendedor & "" & _
                         "ORDER BY nombres"

            ElseIf txtNit.Text = "" And txtNombres.Text = "" Then

                strSql = "SELECT Tipo, Numero,nombres,Nit, Fecha, Vencimiento, Valor_Total, Valor_Aplicado, Saldo, Dias_Vencido, Sin_Vencer, de_1_a_30, de_31_a_60, de_61_a_90, de_91_a_120, Mas_de_120 " & _
                         "FROM V_cartera_edades_jjv " & _
                         "WHERE vendedor = " & vendedor & " AND  saldo <> 0 " & _
                         "ORDER BY nombres"

            ElseIf txtNit.Text = "" And txtNombres.Text <> "" Then

                strSql = "SELECT Tipo, Numero,nombres,Nit, Fecha, Vencimiento, Valor_Total, Valor_Aplicado, Saldo, Dias_Vencido, Sin_Vencer, de_1_a_30, de_31_a_60, de_61_a_90, de_91_a_120, Mas_de_120 " & _
                         "FROM V_cartera_edades_jjv " & _
                         "WHERE nombres LIKE '%" & txtNombres.Text & "%' AND saldo <> 0 AND " & _
                         "      vendedor = " & vendedor & " " & _
                         "ORDER BY nombres"

            ElseIf txtNit.Text <> "" And txtNombres.Text = "" Then

                strSql = "SELECT Tipo, Numero,nombres,Nit, Fecha, Vencimiento, Valor_Total, Valor_Aplicado, Saldo, Dias_Vencido, Sin_Vencer, de_1_a_30, de_31_a_60, de_61_a_90, de_91_a_120, Mas_de_120 " & _
                         "FROM V_cartera_edades_jjv " & _
                         "WHERE nit LIKE '" & txtNit.Text & "%' AND saldo <> 0 AND " & _
                         "      vendedor = " & vendedor & "" & _
                         "ORDER BY nombres"
            End If
        End If
        If (strSql <> "") Then
            dtg_cartera.DataSource = objIngVtaLn.listarDatos(strSql)
            txt_vr_tot.Text = sumarColumna(dtg_cartera, "Valor_Total").ToString("C0")
            txt_saldo.Text = sumarColumna(dtg_cartera, "Saldo").ToString("C0")
            txt_sin_venc.Text = sumarColumna(dtg_cartera, "Sin_Vencer").ToString("C0")
            txt_1_30.Text = sumarColumna(dtg_cartera, "de_1_a_30").ToString("C0")
            txt_31_60.Text = sumarColumna(dtg_cartera, "de_31_a_60").ToString("C0")
            txt_61_90.Text = sumarColumna(dtg_cartera, "de_61_a_90").ToString("C0")
            txt_91_120.Text = sumarColumna(dtg_cartera, "de_91_a_120").ToString("C0")
            mas_120.Text = sumarColumna(dtg_cartera, "Mas_de_120").ToString("C0")
            dtg_cartera.Columns("Vencimiento").DefaultCellStyle.Format = "d"
            dtg_cartera.Columns("Fecha").DefaultCellStyle.Format = "d"
        End If

    End Sub

    Private Sub txtNit_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNit.TextChanged
        txtNombres.Text = ""
        cartera()
    End Sub

    Private Sub txtNombres_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNombres.TextChanged
        txtNit.Text = ""
        cartera()
    End Sub

    Private Sub dtg_cartera_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtg_cartera.CellDoubleClick
        If (e.RowIndex <> -1) Then
            FrmIngVtas.Show()
            FrmIngVtas.txt_nombres.Text = dtg_cartera.Item("nombres", e.RowIndex).Value
            FrmIngVtas.txtNit.Text = dtg_cartera.Item("Nit", e.RowIndex).Value
            FrmIngVtas.txtRef.Focus()
            FrmIngVtas.cargar_info_client(dtg_cartera.Item("Nit", e.RowIndex).Value)
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
End Class