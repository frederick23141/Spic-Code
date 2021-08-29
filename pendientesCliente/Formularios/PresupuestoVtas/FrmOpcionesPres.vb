Imports logicaNegocios
Public Class FrmOpcionesPres
    Private objAnalisisPresLn As AnalisisPresLn
    Private objGenPresLn As New GenerarPresLn


    Private Sub FrmOpcionesPres_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        objAnalisisPresLn = New AnalisisPresLn
        Dim año As Double = Now.Year
        While (año <= Now.Year + 2)
            cboAño.Items.Add(año)

            año += 1
        End While
        chk3M.Checked = True
        Dim vecVend As String() = objAnalisisPresLn.cargarVendedores()

        For i = 0 To vecVend.Length - 1
            If (vecVend(i) <> "") Then
                cboVend.Items.Add(vecVend(i))
            End If
        Next
        cboAño.SelectedIndex = 0
        cboMes.SelectedIndex = Now.Month ' RECORDAR CAMBIAR A Now.Month - 1 
        cboVend.Text = "Seleccione"
        ChkPesosVend.Checked = True
    End Sub


    Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click
        Dim cantMeses As Double
        Dim fechaPpto As String
        Dim año As Double
        Dim mes As String
        Dim criterio As String
        If (cboVend.Text <> "Seleccione") Then

            If (cboAño.SelectedIndex <> -1 And cboMes.SelectedIndex <> -1) Then

                If (chkKilVend.Checked = True Or ChkPesosVend.Checked = True) Then
                    año = Convert.ToDouble(cboAño.Text)
                    mes = cboMes.Text
                    fechaPpto = año & "-" & cboMes.SelectedIndex + 1 & "-01"
                    If CDate(fechaPpto) < CDate(Now.Year & "-" & Now.Month & "-01") Then
                        MsgBox("EL la fecha de el presupuesto debe ser mayor o igual al mes actual")
                    Else
                        If (chk3M.Checked = True) Then
                            cantMeses = 3
                        ElseIf (chk6M.Checked = True) Then
                            cantMeses = 6
                        Else
                            cantMeses = 12
                        End If
                        If (chkKilVend.Checked = True) Then
                            FrmAnalisisPres.chkKilVend.Checked = True
                            criterio = "Kilos"
                        Else
                            FrmAnalisisPres.ChkPesosVend.Checked = True
                            criterio = "Vr_total"
                        End If
                        FrmAnalisisPres.mes = cboMes.SelectedIndex + 1
                        FrmAnalisisPres.año = cboAño.SelectedItem
                        If (objGenPresLn.existePres(fechaPpto, 10011099) = False And cboVend.Text <> "Todos" And cboVend.Text <> "Nacionales") Then
                            Dim iResponce = MessageBox.Show("El presupuesto general de vendedores para el mes " & fechaPpto & "No se a generado esto podra ocacionar que no se muestren los datos de porcentaje general de todos los vendedores. ¿Desea generar presupuesto para todos los vendedores?", "Atención", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                            If (iResponce = 6) Then
                                FrmAnalisisPres.agregarPres("Todos", cantMeses, año, mes, cboMes.SelectedIndex + 1, criterio)
                                FrmAnalisisPres.vendDatosGrid = 10011099
                            Else
                                FrmAnalisisPres.agregarPres(cboVend.Text, cantMeses, año, mes, cboMes.SelectedIndex + 1, criterio)
                                FrmAnalisisPres.vendDatosGrid = cboVend.Text
                            End If
                        Else
                            FrmAnalisisPres.agregarPres(cboVend.Text, cantMeses, año, mes, cboMes.SelectedIndex + 1, criterio)
                            FrmAnalisisPres.vendDatosGrid = cboVend.Text
                        End If

                        

                        Application.DoEvents()
                        Me.Close()
                        Application.DoEvents()
                    End If
                Else
                    MsgBox("Seleccione discriminaciòn por Kilos ò Pesos")
                End If



            Else
                MsgBox("Seleccione la fecha para el  presupuesto")
            End If
        Else
            MsgBox("Seleccione un vendedor")
        End If



    End Sub

    Private Sub chk3M_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk3M.CheckedChanged

        If chk3M.Checked = True Then
            chk12M.Checked = False
            chk6M.Checked = False
        End If
    End Sub

    Private Sub chk6M_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk6M.CheckedChanged
        If chk6M.Checked = True Then
            chk12M.Checked = False
            chk3M.Checked = False
        End If
    End Sub

    Private Sub chk12M_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk12M.CheckedChanged
        If chk12M.Checked = True Then
            chk3M.Checked = False
            chk6M.Checked = False
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