Imports logicaNegocios
Public Class FrmConsultarPptoRec
    Private objAnalisisPresLn As AnalisisPresLn
    Private Sub consultarPres_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        objAnalisisPresLn = New AnalisisPresLn
        Dim año As Double = Now.Year
        For i = 0 To 3
            cboAño.Items.Add(año - 1)

            año += 1
        Next
        Dim vecVend As String() = objAnalisisPresLn.cargarVendedores()
        Dim valor As String
        For i = 0 To vecVend.Length - 1
            If (vecVend(i) <> "" And vecVend(i) <> "Nacionales") Then
                valor = vecVend(i)
                cboVend.Items.Add(valor)
            End If

        Next
        cboVend.Text = "Seleccione"
        ChkPesosVend.Checked = True
        cboMes.SelectedIndex = Now.Month - 1
        cboAño.SelectedIndex = 1


        Me.CenterToScreen()

    End Sub

    Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
        Dim criterio As String
        Dim vendedor As Integer
        If (cboVend.Text <> "Seleccione") Then
            If (chkKilVend.Checked = True Or ChkPesosVend.Checked = True) Then

                Dim fecha As String = cboAño.SelectedItem & "-" & cboMes.SelectedIndex + 1 & "-01"
                If (cboVend.Text = "Todos") Then
                    vendedor = 10011099
                Else
                    vendedor = cboVend.Text
                End If

                If (chkKilVend.Checked = True) Then
                    FrmAnalisisPres.chkKilVend.Checked = True
                    criterio = "Kilos"
                Else
                    FrmAnalisisPres.ChkPesosVend.Checked = True
                    criterio = "Vr_total"
                End If
                FrmAnalisisPres.Show()
                FrmAnalisisPres.mes = cboMes.SelectedIndex + 1
                FrmAnalisisPres.año = cboAño.SelectedItem
                FrmAnalisisPres.ConsultarPres(fecha, vendedor, criterio)
                FrmAnalisisPres.vendDatosGrid = cboVend.Text
                Me.Close()
                Me.Finalize()
            Else
                MsgBox("Discriminacion por Kilos ò pesos")
            End If
        Else
            MsgBox("Seleccione un vendedor")
        End If

    End Sub

    Private Sub ChkPesosVend_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkPesosVend.CheckedChanged
        If ChkPesosVend.Checked = True Then
            chkKilVend.Checked = False
        End If
    End Sub
    Private Sub chkKilVend_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkKilVend.CheckedChanged
        If chkKilVend.Checked = True Then
            ChkPesosVend.Checked = False
        End If
    End Sub
End Class