Imports System.Configuration
Imports logicaNegocios
Imports entidadNegocios
Imports System.IO
Imports Microsoft.Office.Interop
Public Class Frm_clientes
    Public vendedor As Integer
    Private objIngVtaLn As New IngVtasLn
    Public strSql As String = ""
    Dim frmName As String

    Public Sub Main(ByVal vend As Integer, ByVal frmName As String)
        Me.frmName = frmName
        vendedor = vend
        clientes()
        txtNombres.Focus()
    End Sub

    Private Sub Frm_clientes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CenterToScreen()
    End Sub


    Public Sub clientes()
        If (vendedor = 1020) Then

            If txtNit.Text <> "" And txtNombres.Text <> "" Then

                strSql = "SELECT nit, nombres,Region,TipoCliente,direccion, telefono_1, contacto_1, vendedor " & _
                         "FROM jjv_Datos_clientes_todos " & _
                         "WHERE nit LIKE '" & txtNit.Text & "%' AND " & _
                         "      nombres LIKE '%" & txtNombres.Text & "%' AND " & _
                         "WHERE vendedor >=1001 and vendedor<=1099 " & _
                         "ORDER BY nombres"
            ElseIf txtNit.Text = "" And txtNombres.Text <> "" Then

                strSql = "SELECT nit, nombres,Region,TipoCliente,direccion, telefono_1, contacto_1, vendedor " & _
                         "FROM jjv_Datos_clientes_todos " & _
                         "WHERE nombres LIKE '%" & txtNombres.Text & "%' AND " & _
                         " vendedor >=1001 and vendedor<=1099 " & _
                         "ORDER BY nombres"

            ElseIf txtNit.Text <> "" And txtNombres.Text = "" Then

                strSql = "SELECT nit, nombres,Region,TipoCliente,direccion, telefono_1, contacto_1, vendedor " & _
                         "FROM jjv_Datos_clientes_todos " & _
                         "WHERE nit LIKE '" & txtNit.Text & "%' AND " & _
                         "vendedor >=1001 and vendedor<=1099 " & _
                         "ORDER BY nombres"
            End If
        Else
            If txtNit.Text <> "" And txtNombres.Text <> "" Then

                strSql = "SELECT nit, nombres,Region,TipoCliente,direccion, telefono_1, contacto_1, vendedor " & _
                         "FROM jjv_Datos_clientes_todos " & _
                         "WHERE nit LIKE '" & txtNit.Text & "%' AND " & _
                         "      nombres LIKE '%" & txtNombres.Text & "%' AND " & _
                         "      vendedor = " & vendedor & "" & _
                         "ORDER BY nombres"

            ElseIf txtNit.Text = "" And txtNombres.Text = "" Then

                strSql = "SELECT nit, nombres,Region,TipoCliente,direccion, telefono_1, contacto_1, vendedor " & _
                         "FROM jjv_Datos_clientes_todos " & _
                         "WHERE vendedor = " & vendedor & "" & _
                         "ORDER BY nombres"

            ElseIf txtNit.Text = "" And txtNombres.Text <> "" Then

                strSql = "SELECT nit, nombres,Region,TipoCliente,direccion, telefono_1, contacto_1, vendedor " & _
                         "FROM jjv_Datos_clientes_todos " & _
                         "WHERE nombres LIKE '%" & txtNombres.Text & "%' AND " & _
                         "      vendedor = " & vendedor & "" & _
                         "ORDER BY nombres"

            ElseIf txtNit.Text <> "" And txtNombres.Text = "" Then

                strSql = "SELECT nit, nombres,Region,TipoCliente,direccion, telefono_1, contacto_1, vendedor " & _
                         "FROM jjv_Datos_clientes_todos " & _
                         "WHERE nit LIKE '" & txtNit.Text & "%' AND " & _
                         "      vendedor = " & vendedor & "" & _
                         "ORDER BY nombres"
            End If
        End If
        If (strSql <> "") Then
            dtg_clientes.DataSource = objIngVtaLn.listarDatos(strSql)
        End If
    End Sub

    Private Sub txtNit_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNit.TextChanged
        txtNombres.Text = ""
        If (txtNit.Text.Length > 2) Then
            clientes()
        End If
    End Sub
    Private Sub txtNit_keyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNit.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
        If (e.KeyChar = Microsoft.VisualBasic.ChrW(13) And txtNit.Text <> "") Then
            cargar_info()
        End If
    End Sub

    Private Sub txtNombres_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNombres.TextChanged
        txtNit.Text = ""
        If (txtNombres.Text.Length > 2) Then
            clientes()
        End If
    End Sub

    Private Sub dtg_clientes_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtg_clientes.CellDoubleClick
        cargar_info()
    End Sub
    Private Sub cargar_info()
        If (dtg_clientes.RowCount > 0) Then
            If (frmNAme = "FrmIngVtas") Then
                FrmIngVtas.Show()
                FrmIngVtas.txt_nombres.Text = dtg_clientes.Item(1, dtg_clientes.CurrentCell.RowIndex).Value
                FrmIngVtas.txtNit.Text = dtg_clientes.Item(0, dtg_clientes.CurrentCell.RowIndex).Value
                FrmIngVtas.txtRef.Focus()
                FrmIngVtas.cargar_info_client(dtg_clientes.Item(0, dtg_clientes.CurrentCell.RowIndex).Value)
                Me.Close()
            ElseIf (frmNAme = "FrmIngVtasMovil") Then
                FrmIngVtasMovil.Show()
                FrmIngVtasMovil.txt_nombres.Text = dtg_clientes.Item(1, dtg_clientes.CurrentCell.RowIndex).Value
                FrmIngVtasMovil.txtNit.Text = dtg_clientes.Item(0, dtg_clientes.CurrentCell.RowIndex).Value
                FrmIngVtasMovil.txtRef.Focus()
                FrmIngVtasMovil.cargar_info_client(dtg_clientes.Item(0, dtg_clientes.CurrentCell.RowIndex).Value)
                Me.Close()
            End If
          
        End If
    End Sub
    Private Sub btn_ok_Click(sender As Object, e As EventArgs) Handles btn_ok.Click
        cargar_info()
    End Sub

    Private Sub txtNombres_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNombres.KeyPress
        If (e.KeyChar = Microsoft.VisualBasic.ChrW(13) And txtNit.Text <> "") Then
            cargar_info()
        End If
    End Sub

    Private Sub txtNombres_Enter(sender As Object, e As EventArgs) Handles txtNombres.Enter
        txtNombres.BackColor = Color.Lime
    End Sub

    Private Sub txtNit_Leave(sender As Object, e As EventArgs) Handles txtNit.Leave
        txtNit.BackColor = Color.White
    End Sub

    Private Sub txtNit_Enter(sender As Object, e As EventArgs) Handles txtNit.Enter
        txtNit.BackColor = Color.Lime
    End Sub

    Private Sub txtNombres_Leave(sender As Object, e As EventArgs) Handles txtNombres.Leave
        txtNombres.BackColor = Color.White
    End Sub
End Class