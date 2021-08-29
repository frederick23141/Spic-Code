Imports entidadNegocios
Imports logicaNegocios
Public Class frm_buzon_red_premios
    Private objOpSimplesLn As New Op_simpesLn
    Private obj_Ing_prodLn As New Ing_prodLn
    Private obj_correoLn As New EnvCorreoLN

    Dim p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, p16, p17, p18, p19, p20, p21, p22, p23, p24, p25, puntos As Integer
    Public Sub main(ByVal nombre As String, ByVal doc As Integer, ByVal puntos As Integer)
        lbl_documento.Text = doc
        lbl_nombre.Text = nombre
        Me.Text = "Listado de Premios disponibles para: " & nombre
        consultar_puntos()
    End Sub

    Private Sub consultar_puntos()
        Dim sql As String = "SELECT puntos FROM JB_buzon_sugerencias_puntos WHERE doc = " & lbl_documento.Text
        Dim punt As Integer = obj_Ing_prodLn.consultar_valor(sql, "CORSAN")
        lbl_puntos.Text = punt
        puntos = punt
        dar_valores()
    End Sub
    Private Sub dar_valores()
        Dim sql As String = "SELECT valor_puntos FROM JB_buzon_premios WHERE id = 1"
        p1 = obj_Ing_prodLn.consultar_valor(sql, "CORSAN")
        sql = "SELECT valor_puntos FROM JB_buzon_premios WHERE id = 2"
        p2 = obj_Ing_prodLn.consultar_valor(sql, "CORSAN")
        sql = "SELECT valor_puntos FROM JB_buzon_premios WHERE id = 3"
        p3 = obj_Ing_prodLn.consultar_valor(sql, "CORSAN")
        sql = "SELECT valor_puntos FROM JB_buzon_premios WHERE id = 4"
        p4 = obj_Ing_prodLn.consultar_valor(sql, "CORSAN")
        sql = "SELECT valor_puntos FROM JB_buzon_premios WHERE id = 5"
        p5 = obj_Ing_prodLn.consultar_valor(sql, "CORSAN")
        sql = "SELECT valor_puntos FROM JB_buzon_premios WHERE id = 6"
        p6 = obj_Ing_prodLn.consultar_valor(sql, "CORSAN")
        sql = "SELECT valor_puntos FROM JB_buzon_premios WHERE id = 7"
        p7 = obj_Ing_prodLn.consultar_valor(sql, "CORSAN")
        sql = "SELECT valor_puntos FROM JB_buzon_premios WHERE id = 8"
        p8 = obj_Ing_prodLn.consultar_valor(sql, "CORSAN")
        sql = "SELECT valor_puntos FROM JB_buzon_premios WHERE id = 9"
        p9 = obj_Ing_prodLn.consultar_valor(sql, "CORSAN")
        sql = "SELECT valor_puntos FROM JB_buzon_premios WHERE id = 10"
        p10 = obj_Ing_prodLn.consultar_valor(sql, "CORSAN")
        sql = "SELECT valor_puntos FROM JB_buzon_premios WHERE id = 11"
        p11 = obj_Ing_prodLn.consultar_valor(sql, "CORSAN")
        sql = "SELECT valor_puntos FROM JB_buzon_premios WHERE id = 12"
        p12 = obj_Ing_prodLn.consultar_valor(sql, "CORSAN")
        sql = "SELECT valor_puntos FROM JB_buzon_premios WHERE id = 13"
        p13 = obj_Ing_prodLn.consultar_valor(sql, "CORSAN")
        sql = "SELECT valor_puntos FROM JB_buzon_premios WHERE id = 14"
        p14 = obj_Ing_prodLn.consultar_valor(sql, "CORSAN")
        sql = "SELECT valor_puntos FROM JB_buzon_premios WHERE id = 15"
        p15 = obj_Ing_prodLn.consultar_valor(sql, "CORSAN")
        sql = "SELECT valor_puntos FROM JB_buzon_premios WHERE id = 16"
        p16 = obj_Ing_prodLn.consultar_valor(sql, "CORSAN")
        sql = "SELECT valor_puntos FROM JB_buzon_premios WHERE id = 17"
        p17 = obj_Ing_prodLn.consultar_valor(sql, "CORSAN")
        sql = "SELECT valor_puntos FROM JB_buzon_premios WHERE id = 18"
        p18 = obj_Ing_prodLn.consultar_valor(sql, "CORSAN")
        sql = "SELECT valor_puntos FROM JB_buzon_premios WHERE id = 19"
        p19 = obj_Ing_prodLn.consultar_valor(sql, "CORSAN")
        sql = "SELECT valor_puntos FROM JB_buzon_premios WHERE id = 20"
        p20 = obj_Ing_prodLn.consultar_valor(sql, "CORSAN")
        sql = "SELECT valor_puntos FROM JB_buzon_premios WHERE id = 21"
        p21 = obj_Ing_prodLn.consultar_valor(sql, "CORSAN")
        sql = "SELECT valor_puntos FROM JB_buzon_premios WHERE id = 22"
        p22 = obj_Ing_prodLn.consultar_valor(sql, "CORSAN")
        sql = "SELECT valor_puntos FROM JB_buzon_premios WHERE id = 23"
        p23 = obj_Ing_prodLn.consultar_valor(sql, "CORSAN")
        sql = "SELECT valor_puntos FROM JB_buzon_premios WHERE id = 24"
        p24 = obj_Ing_prodLn.consultar_valor(sql, "CORSAN")
        sql = "SELECT valor_puntos FROM JB_buzon_premios WHERE id = 25"
        p25 = obj_Ing_prodLn.consultar_valor(sql, "CORSAN")

        dar_nombres_botones()
        ocultar()
    End Sub
    Private Sub ocultar()
        If puntos >= p1 Then
            btn_p1.Enabled = True
        Else
            btn_p1.Enabled = False
        End If
        If puntos >= p2 Then
            btn_p2.Enabled = True
        Else
            btn_p2.Enabled = False
        End If
        If puntos >= p3 Then
            btn_p3.Enabled = True
        Else
            btn_p3.Enabled = False
        End If
        If puntos >= p4 Then
            btn_p4.Enabled = True
        Else
            btn_p4.Enabled = False
        End If
        If puntos >= p5 Then
            btn_p5.Enabled = True
        Else
            btn_p5.Enabled = False
        End If
        If puntos >= p6 Then
            btn_p6.Enabled = True
        Else
            btn_p6.Enabled = False
        End If
        If puntos >= p7 Then
            btn_p7.Enabled = True
        Else
            btn_p7.Enabled = False
        End If
        If puntos >= p8 Then
            btn_p8.Enabled = True
        Else
            btn_p8.Enabled = False
        End If
        If puntos >= p9 Then
            btn_p9.Enabled = True
        Else
            btn_p9.Enabled = False
        End If
        If puntos >= p10 Then
            btn_p10.Enabled = True
        Else
            btn_p10.Enabled = False
        End If
        If puntos >= p11 Then
            btn_p11.Enabled = True
        Else
            btn_p11.Enabled = False
        End If
        If puntos >= p12 Then
            btn_p12.Enabled = True
        Else
            btn_p12.Enabled = False
        End If
        If puntos >= p13 Then
            btn_p13.Enabled = True
        Else
            btn_p13.Enabled = False
        End If
        If puntos >= p14 Then
            btn_p14.Enabled = True
        Else
            btn_p14.Enabled = False
        End If
        If puntos >= p15 Then
            btn_p15.Enabled = True
        Else
            btn_p15.Enabled = False
        End If
        If puntos >= p16 Then
            btn_p16.Enabled = True
        Else
            btn_p16.Enabled = False
        End If
        If puntos >= p17 Then
            btn_p17.Enabled = True
        Else
            btn_p17.Enabled = False
        End If
        If puntos >= p18 Then
            btn_p18.Enabled = True
        Else
            btn_p18.Enabled = False
        End If
        If puntos >= p19 Then
            btn_p19.Enabled = True
        Else
            btn_p19.Enabled = False
        End If
        If puntos >= p20 Then
            btn_p20.Enabled = True
        Else
            btn_p20.Enabled = False
        End If
        If puntos >= p21 Then
            btn_p21.Enabled = True
        Else
            btn_p21.Enabled = False
        End If
        If puntos >= p22 Then
            btn_p22.Enabled = True
        Else
            btn_p22.Enabled = False
        End If
        If puntos >= p23 Then
            btn_p23.Enabled = True
        Else
            btn_p23.Enabled = False
        End If
        If puntos >= p24 Then
            btn_p24.Enabled = True
        Else
            btn_p24.Enabled = False
        End If
        If puntos >= p25 Then
            btn_p25.Enabled = True
        Else
            btn_p25.Enabled = False
        End If
    End Sub
    Private Sub dar_nombres_botones()
        btn_p1.Text = "LICUADORA OSTER (" & p1 & ")"
        btn_p2.Text = "OLLA ARROCERA 1.8 LITROS OSTER (" & p2 & ")"
        btn_p3.Text = "JUEGO DE SARTENES (" & p3 & ")"
        btn_p4.Text = "VAJILLA (" & p4 & ")"
        btn_p5.Text = "JUEGO DE OLLAS 5 PIEZAS(" & p5 & ")"
        btn_p6.Text = "CASCO PARA MOTOS (" & p6 & ")"
        btn_p7.Text = "SANDUCHERA (" & p7 & ")"
        btn_p8.Text = "ACOLCHADO (" & p8 & ")"
        btn_p9.Text = "JUEGO DE SABANAS (" & p9 & ")"
        btn_p10.Text = "SET CUCHILLOS (" & p10 & ")"
        btn_p11.Text = "PLANCHA DE ROPA (" & p11 & ")"
        btn_p12.Text = "PLANCHA DE CABELLO (" & p12 & ")"
        btn_p13.Text = "SECADOR DE CABELLO (" & p13 & ")"
        btn_p14.Text = "JUEGO DE CUBIERTOS (" & p14 & ")"
        btn_p15.Text = "KIT DE HERRAMIENTAS (" & p15 & ")"
        btn_p16.Text = "CORTINA (" & p16 & ")"
        btn_p17.Text = "BONO EXITO $20.000  (" & p17 & ")"
        btn_p18.Text = "BONO ÉXITO $40.000 (" & p18 & ")"
        btn_p19.Text = "BONO EXITO $50.000 (" & p19 & ")"
        btn_p20.Text = "BONO EXITO $60.000 (" & p20 & ")"
        btn_p21.Text = "BONO EXITO $80.000 (" & p21 & ")"
        btn_p22.Text = "BONO EXITO $100.000 (" & p22 & ")"
        btn_p23.Text = "BONO EXITO $200.000 (" & p23 & ")"
        btn_p24.Text = "4 HORAS LABORALES (" & p24 & ")"
        btn_p25.Text = "1 DIA DE DESCANSO (" & p25 & ")"
    End Sub

    ''metodo para redimir los puntos 
    Private Sub red_prem(ByVal valor As Integer, ByVal doc As Integer, ByVal prem As Integer)
        Dim resp As Integer = MessageBox.Show("¿Desea Cambiar Sus Puntos?", "Cambiar Puntos", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
        If resp = 6 Then
            Dim listSql As New List(Of Object)
            Dim punt_tot As Integer = lbl_puntos.Text
            punt_tot -= valor
            Dim sql As String = "UPDATE JB_buzon_sugerencias_puntos SET puntos=" & punt_tot & " WHERE doc =" & doc
            listSql.Add(sql)
            sql = "SELECT MAX(id) FROM JB_buzon_solicitud_premios"
            Dim id As Integer = obj_Ing_prodLn.consultar_valor(sql, "CORSAN") + 1
            sql = "INSERT INTO JB_buzon_solicitud_premios (id,doc,premio,fecha_solicitud,valor) VALUES (" & id & "," & lbl_documento.Text & "," & prem & ",GETDATE()," & valor & ")"
            listSql.Add(sql)


            sql = "INSERT INTO JB_buzon_historial_puntos (doc,fec,cant,razon) VALUES (" &
                       doc & ",getdate()," & valor * -1 & ",'SOLICITUD DE PREMIO: " & prem & "')"
            listSql.Add(sql)
            If obj_Ing_prodLn.ExecuteSqlTransaction(listSql, "CORSAN") Then
                MessageBox.Show("Su premio sera cargado en el sistema, recuerde reclamarlo a final de mes con la persona encargada de recursos humanos.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'Me.Close()
                enviar_correo(prem)
                consultar_puntos()
            End If
        End If
    End Sub

    ''metodo que se encarga de enviar el correo al encargado con la peticion de redimir el premio
    Private Sub enviar_correo(ByVal premio As Integer)
        Dim sql As String = "SELECT mail,Mail_login  FROM Jjv_usuarios WHERE usuario = 'ADMIN'"
        Dim dt_admin As DataTable = objOpSimplesLn.listar_datatable(sql, "CORSAN")

        sql = "SELECT NOMBRE FROM JB_buzon_premios WHERE id =" & premio
        Dim mail As String = "calidad@corsan.com.co"
        Dim PREM As String = objOpSimplesLn.consultValorTodo(sql, "CORSAN")
        Dim asunto As String = "Peticion de Premio"
        Dim cuerpo As String = "HAY UNA PETICION DE PREMIO" & vbCrLf & _
                                "" & vbCrLf & _
                                "Quien Solicita: " & lbl_nombre.Text & vbCrLf & _
                                "Premio: " & premio & "-" & PREM & vbCrLf & _
                                "Documento: " & lbl_documento.Text & vbCrLf & _
                                "Fecha: " & Now & vbCrLf & _
                                "POR FAVOR REVISAR EL SPIC."

        Dim mailEnvia As String = dt_admin.Rows(0).Item("mail")
        Dim mailEnviaPass As String = dt_admin.Rows(0).Item("Mail_login")
        obj_correoLn.EnviarCorreo(mail.Trim, cuerpo, asunto, "", mailEnvia, mailEnviaPass, False)
        mail = "faysury.rios@corsan.com.co"
        obj_correoLn.EnviarCorreo(mail.Trim, cuerpo, asunto, "", mailEnvia, mailEnviaPass, False)
    End Sub


    ''botones encargados de redimir los premios
    Private Sub btn_p1_Click(sender As Object, e As EventArgs) Handles btn_p1.Click
        red_prem(p1, lbl_documento.Text, 1)
    End Sub
    Private Sub btn_p2_Click(sender As Object, e As EventArgs) Handles btn_p2.Click
        red_prem(p2, lbl_documento.Text, 2)
    End Sub
    Private Sub btn_p3_Click(sender As Object, e As EventArgs) Handles btn_p3.Click
        red_prem(p3, lbl_documento.Text, 3)
    End Sub
    Private Sub btn_p4_Click(sender As Object, e As EventArgs) Handles btn_p4.Click
        red_prem(p4, lbl_documento.Text, 4)
    End Sub
    Private Sub btn_p5_Click(sender As Object, e As EventArgs) Handles btn_p5.Click
        red_prem(p5, lbl_documento.Text, 5)
    End Sub
    Private Sub btn_p6_Click(sender As Object, e As EventArgs) Handles btn_p6.Click
        red_prem(p6, lbl_documento.Text, 6)
    End Sub
    Private Sub btn_p7_Click(sender As Object, e As EventArgs) Handles btn_p7.Click
        red_prem(p7, lbl_documento.Text, 7)
    End Sub
    Private Sub btn_p8_Click(sender As Object, e As EventArgs) Handles btn_p8.Click
        red_prem(p8, lbl_documento.Text, 8)
    End Sub
    Private Sub btn_p9_Click(sender As Object, e As EventArgs) Handles btn_p9.Click
        red_prem(p9, lbl_documento.Text, 9)
    End Sub
    Private Sub btn_p10_Click(sender As Object, e As EventArgs) Handles btn_p10.Click
        red_prem(p10, lbl_documento.Text, 10)
    End Sub
    Private Sub btn_p11_Click(sender As Object, e As EventArgs) Handles btn_p11.Click
        red_prem(p11, lbl_documento.Text, 11)
    End Sub
    Private Sub btn_p12_Click(sender As Object, e As EventArgs) Handles btn_p12.Click
        red_prem(p12, lbl_documento.Text, 12)
    End Sub
    Private Sub btn_p13_Click(sender As Object, e As EventArgs) Handles btn_p13.Click
        red_prem(p13, lbl_documento.Text, 13)
    End Sub
    Private Sub btn_p14_Click(sender As Object, e As EventArgs) Handles btn_p14.Click
        red_prem(p14, lbl_documento.Text, 14)
    End Sub
    Private Sub btn_p15_Click(sender As Object, e As EventArgs) Handles btn_p15.Click
        red_prem(p15, lbl_documento.Text, 15)
    End Sub
    Private Sub btn_p16_Click(sender As Object, e As EventArgs) Handles btn_p16.Click
        red_prem(p16, lbl_documento.Text, 16)
    End Sub
    Private Sub btn_p17_Click(sender As Object, e As EventArgs) Handles btn_p17.Click
        red_prem(p17, lbl_documento.Text, 17)
    End Sub
    Private Sub btn_p18_Click(sender As Object, e As EventArgs) Handles btn_p18.Click
        red_prem(p18, lbl_documento.Text, 18)
    End Sub
    Private Sub btn_p19_Click(sender As Object, e As EventArgs) Handles btn_p19.Click
        red_prem(p19, lbl_documento.Text, 19)
    End Sub
    Private Sub btn_p20_Click(sender As Object, e As EventArgs) Handles btn_p20.Click
        red_prem(p20, lbl_documento.Text, 20)
    End Sub
    Private Sub btn_p21_Click(sender As Object, e As EventArgs) Handles btn_p21.Click
        red_prem(p21, lbl_documento.Text, 21)
    End Sub
    Private Sub btn_p22_Click(sender As Object, e As EventArgs) Handles btn_p22.Click
        red_prem(p22, lbl_documento.Text, 22)
    End Sub
    Private Sub btn_p23_Click(sender As Object, e As EventArgs) Handles btn_p23.Click
        red_prem(p23, lbl_documento.Text, 23)
    End Sub
    Private Sub btn_p24_Click(sender As Object, e As EventArgs) Handles btn_p24.Click
        red_prem(p24, lbl_documento.Text, 24)
    End Sub
    Private Sub btn_p25_Click(sender As Object, e As EventArgs) Handles btn_p25.Click
        red_prem(p25, lbl_documento.Text, 25)
    End Sub

    Private Sub frm_buzon_red_premios_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        frm_buzon.Show()
    End Sub
End Class