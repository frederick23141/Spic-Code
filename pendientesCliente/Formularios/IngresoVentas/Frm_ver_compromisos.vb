Imports System.Configuration
Imports logicaNegocios
Imports entidadNegocios
Imports System.IO
Imports Microsoft.Office.Interop
Public Class Frm_ver_compromisos
    Public vendedor As Integer
    Private objIngVtaLn As New IngVtasLn
    Public strSql As String = ""

    Public Sub Main(ByVal vend As Integer)
        vendedor = vend
        compromisos()
    End Sub

    Private Sub Frm_ver_compromisos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CenterToScreen()
    End Sub


    Public Sub compromisos()
        If (vendedor = 1020) Then

            If txtNit.Text = "" Then

                strSql = "SELECT consecutivo as id, fecha,vendedor,nit,compromiso,solucion,pedido,Factura,estado,responsable,fecha_mod,usuario,motivo_no_Vta  " & _
                        " FROM Jjv_compromisos " & _
                         "WHERE vendedor >=1001 and vendedor<=1099 "

            ElseIf txtNit.Text <> "" Then

                strSql = "SELECT consecutivo as id, fecha,vendedor,nit,compromiso,solucion,pedido,Factura,estado,responsable,fecha_mod,usuario,motivo_no_Vta  " & _
                        " FROM Jjv_compromisos " & _
                         "WHERE nit LIKE '" & txtNit.Text & "%' AND " & _
                         "vendedor >=1001 and vendedor<=1099 "
            End If
        Else
            If txtNit.Text = "" Then

                strSql = "SELECT consecutivo as id, fecha,vendedor,nit,compromiso,solucion,pedido,Factura,estado,responsable,fecha_mod,usuario,motivo_no_Vta  " & _
                        " FROM Jjv_compromisos " & _
                         "WHERE vendedor = " & vendedor

            ElseIf txtNit.Text <> "" Then

                strSql = "SELECT consecutivo as id, fecha,vendedor,nit,compromiso,solucion,pedido,Factura,estado,responsable,fecha_mod,usuario,motivo_no_Vta  " & _
                        " FROM Jjv_compromisos " & _
                         "WHERE nit LIKE '" & txtNit.Text & "%' " & _
                         "AND  vendedor = " & vendedor
            End If
        End If
        If (strSql <> "") Then
            dtg_compromisos.DataSource = objIngVtaLn.listarDatos(strSql)
        End If
    End Sub

    Private Sub txtNit_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNit.TextChanged
        compromisos()
    End Sub

    Private Sub dtg_compromisos_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtg_compromisos.CellDoubleClick
        Frm_compromiso.Show()
        Frm_compromiso.txt_fec.Text = dtg_compromisos.Item("fecha", e.RowIndex).Value
        Frm_compromiso.txt_nit.Text = dtg_compromisos.Item("nit", e.RowIndex).Value
        Frm_compromiso.txt_ped.Text = dtg_compromisos.Item("pedido", e.RowIndex).Value
        Frm_compromiso.txt_fact.Text = dtg_compromisos.Item("Factura", e.RowIndex).Value
        Frm_compromiso.txtCompromiso.Text = dtg_compromisos.Item("compromiso", e.RowIndex).Value
        Frm_compromiso.cbo_cumplio.Text = dtg_compromisos.Item("solucion", e.RowIndex).Value
        Frm_compromiso.txt_resp.Text = dtg_compromisos.Item("responsable", e.RowIndex).Value
        Frm_compromiso.txt_cons.Text = dtg_compromisos.Item("id", e.RowIndex).Value

        Frm_compromiso.txt_ped.Enabled = False
        Frm_compromiso.txt_nit.Enabled = False
        Frm_compromiso.txt_fact.Enabled = False
        Me.Close()
    End Sub
    Public Sub comp_cliente(ByVal nit As Double)
        Dim strSql As String = "SELECT fecha,vendedor,nit,compromiso,solucion,tipo,pedido,Factura,estado,efectiva,responsable,fecha_mod,usuario,motivo_no_Vta " & _
                        " FROM Jjv_compromisos " & _
                         "WHERE nit = " & nit & ""
        dtg_compromisos.DataSource = objIngVtaLn.listarDatos(strSql)
        dtg_compromisos.Columns("efectiva").DefaultCellStyle.Format = "C0"
    End Sub
End Class