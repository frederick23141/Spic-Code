Imports System.Configuration
Imports logicaNegocios
Imports entidadNegocios
Imports System.IO
Imports Microsoft.Office.Interop
Public Class Frm_compromiso
    Private vendedor As Integer
    Private motivo_no_Vta As String
    Private objIngVtasLn As New IngVtasLn
    Dim nomb_frm As String
    Public Sub Main(ByVal vend As Integer, ByVal nit As Integer, ByVal nomb_frm As String)
        Me.nomb_frm = nomb_frm
        vendedor = vend
        txt_nit.Text = nit
    End Sub
    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click
        If (txtCompromiso.Text <> "") Then
            If (guardar() >= 1) Then
                MessageBox.Show("El compromiso se guardo en forma exitosa!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
                If (nomb_frm = FrmIngVtas.Name) Then
                    FrmIngVtas.guardar_con_probl(txtCompromiso.Text)
                ElseIf (nomb_frm = FrmIngVtasMovil.Name) Then
                    FrmIngVtasMovil.guardar_con_probl(txtCompromiso.Text)
                End If
                nuevo()
            End If
        Else
            Using New posicionar_messagebox(Me)
                MessageBox.Show("El campo compromiso es obligatorio!", "Verifique!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Using
        End If

    End Sub
    Public Function guardar() As Integer
        Dim pedido As Double = 0
        Dim Factura As Double = 0
        Dim nit As Double = txt_nit.Text
        Dim tipo As String = ""
        Dim fecha As String = txt_fec.Value.Date.Year & "-" & txt_fec.Value.Date.Month & "-" & txt_fec.Value.Date.Day
        Dim sql As String = ""
        Dim compromiso As String = txtCompromiso.Text
        Dim solucion As String = cbo_cumplio.Text
        Dim efectiva As String = 0
        Dim responsable As String = txt_resp.Text
        Dim fecha_mod As String = Now.Date.Year & "-" & Now.Date.Month & "-" & Now.Date.Day
        Dim usuario As String = My.Computer.Name
        Dim Resp As Integer = 0
        Dim exixte As Boolean = True
        Dim consecutivo As Double = 0
        If (txt_cons.Text <> "") Then
            consecutivo = txt_cons.Text
        End If
        'If txt_ped.Text <> "" Then
        '    pedido = txt_ped.Text
        '    If (txt_ped.Text <> "") Then
        '        If (objIngVtasLn.existePedido(nit, pedido)) Then
        '            exixte = True
        '        Else
        '            MessageBox.Show("El pedido numero: " & pedido & " para el nit " & nit & " no existe!", "Verifique!", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '        End If
        '    End If

        'End If
        'If txt_fact.Text <> "" Then
        '    Factura = txt_fact.Text
        '    If Not (objIngVtasLn.existeFact(txt_nit.Text, Factura)) Then
        '        MessageBox.Show("El documento numero: " & Factura & " para el nit " & nit & " no existe!", "Verifique!", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    Else
        '        exixte = True
        '    End If
        'End If
        If (exixte) Then
            If (objIngVtasLn.existeConsecutivo(consecutivo)) Then
                sql = "UPDATE Jjv_compromisos  SET solucion  =  '" & cbo_cumplio.Text & "' where consecutivo  = " & consecutivo
            Else
                sql = "INSERT INTO Jjv_compromisos(fecha,vendedor,nit,compromiso,solucion,tipo,pedido,Factura,efectiva,responsable,fecha_mod,usuario,motivo_no_Vta) " & _
                                 "VALUES ('" & fecha & "' ," & vendedor & "," & nit & ",'" & compromiso & "','" & solucion & "','" & tipo & "'," & pedido & "," & Factura & "," & efectiva & ",'" & responsable & "','" & fecha_mod & "','" & usuario & "','" & motivo_no_Vta & "')"
            End If
            Resp = objIngVtasLn.insertar(sql)
        End If
        Return Resp
    End Function

    Private Sub cbo_vta_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If (cbo_cumplio.Text = "NO") Then
            motivo_no_Vta = InputBox("ingrese motivo de la no venta!")
            If (motivo_no_Vta = "") Then
                cbo_cumplio.Text = "SI"
            End If
        End If
    End Sub

    Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
        Frm_ver_compromisos.Show()
        Frm_ver_compromisos.Main(vendedor)
    End Sub

    Private Sub btnActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)


    End Sub

    Private Sub btn_nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click
        nuevo()
    End Sub
    Public Sub nuevo()
        txt_fec.Text = ""
        txt_nit.Text = ""
        txt_resp.Text = ""
        txt_ped.Text = ""
        txt_fact.Text = ""
        cbo_cumplio.Text = ""
        txtCompromiso.Text = ""
        txt_ped.Enabled = True
        txt_nit.Enabled = True
        txt_fact.Enabled = True
        txt_cons.Text = ""
    End Sub

    Private Sub Frm_compromiso_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'CORSANDataSet.tipo_transacciones' Puede moverla o quitarla según sea necesario.

    End Sub
    Private Sub txt_nit_TextChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_nit.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
        'If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
        '    btnBuscarNit.PerformClick()
        'End If
    End Sub
    Private Sub txt_fact_TextChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_fact.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
        'If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
        '    btnBuscarNit.PerformClick()
        'End If
    End Sub
    Private Sub txt_ped_TextChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_ped.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
        'If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
        '    btnBuscarNit.PerformClick()
        'End If
    End Sub
    Private Sub txtCompromiso_Enter(sender As Object, e As EventArgs) Handles txtCompromiso.Enter
        txtCompromiso.BackColor = Color.Lime
    End Sub
    Private Sub txtCompromiso_Leave(sender As Object, e As EventArgs) Handles txtCompromiso.Leave
        txtCompromiso.BackColor = Color.White
    End Sub
    Private Sub btn_guardar_Enter(sender As Object, e As EventArgs) Handles btn_guardar.Enter
        btn_guardar.BackColor = Color.Lime
    End Sub
    Private Sub btn_guardar_Leave(sender As Object, e As EventArgs) Handles btn_guardar.Leave
        btn_guardar.BackColor = Color.White
    End Sub
    Private Sub btn_nuevo_Enter(sender As Object, e As EventArgs) Handles btn_nuevo.Enter
        btn_nuevo.BackColor = Color.Lime
    End Sub
    Private Sub btn_nuevo_Leave(sender As Object, e As EventArgs) Handles btn_nuevo.Leave
        btn_nuevo.BackColor = Color.White
    End Sub
    Private Sub btnConsultar_Enter(sender As Object, e As EventArgs) Handles btnConsultar.Enter
        btnConsultar.BackColor = Color.Lime
    End Sub
    Private Sub btnConsultar_Leave(sender As Object, e As EventArgs) Handles btnConsultar.Leave
        btnConsultar.BackColor = Color.White
    End Sub
End Class