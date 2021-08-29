Imports logicaNegocios
Public Class Frm_ingreso_paros_puas
    Private codMaq
    Private objOpsimpesLn As New Op_simpesLn
    Public Sub main(ByVal codMaq As Integer)
        Me.codMaq = codMaq
    End Sub
    Private Sub Frm_ingreso_paros_puas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim num_paro, nomb_paro As String
        nomb_paro = ""
        cbo_paro.Text = "Seleccione"
        Dim sql As String = "select num_paro from D_paros_puas where codmaqui= " & codMaq & " and h_fin is null"
        num_paro = objOpsimpesLn.consultValorTodo(sql, "PRODUCCION")
        If num_paro <> "" Then
            btn_iniciar_paro.Enabled = False
            cbo_paro.Enabled = False
            Select Case num_paro
                Case 1
                    nomb_paro = "Enredo"
                Case 2
                    nomb_paro = "Daño mecanico"
                Case 3
                    nomb_paro = "Daño electrico"
                Case 4
                    nomb_paro = "Ausencia operario"
                Case 5
                    nomb_paro = "Falta alambre"
                Case 6
                    nomb_paro = "Cambio referencia"
                Case 7
                    nomb_paro = "Aseo máquina"
                Case 8
                    nomb_paro = "Ajuste máquina"
                Case 9
                    nomb_paro = "Reviente"
                Case 10
                    nomb_paro = "Capacitación"
                Case 11
                    nomb_paro = "Alimentación"
                Case 12
                    nomb_paro = "Mantenimiento preventivo"
                Case Else
                    MessageBox.Show("El paro que se ingreso no existe", "Paro no existe", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Select
            lbl_Nomb_Paros.Text = "El paro actual es de:" & nomb_paro
            lbl_Nomb_Paros.Visible = True
        Else
            btn_detener_paro.Enabled = False
            lbl_Nomb_Paros.Visible = False
        End If
    End Sub
    Private Sub btn_iniciar_paro_Click(sender As Object, e As EventArgs) Handles btn_iniciar_paro.Click
        Dim paro As String = cbo_paro.Text
        Dim fecha_hora As String = DateTime.Now.ToString("HH:mm tt")
        If paro <> "Seleccione" Then
            Dim sql As String = "INSERT INTO D_paros_puas (codmaqui,num_paro,h_ini) " &
               " VALUES (" & codMaq & "," & paro & ",GETDATE())"
            objOpsimpesLn.ejecutar(sql, "PRODUCCION")
            MessageBox.Show("El paro ha sido iniciado", "Paro iniciado", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        Else
            MessageBox.Show("Seleccione un paro adecuado", "No se ha seleccionado paro", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub btn_detener_paro_Click(sender As Object, e As EventArgs) Handles btn_detener_paro.Click
        Dim fecha_ini As String
        Dim fecha_fin As String
        Dim fecha_ini_c As Date
        Dim fecha_fin_c As Date
        Dim minutos As Integer
        Dim sql As String = "select h_ini from D_paros_puas where codmaqui= " & codMaq & " and h_fin is null"
        fecha_ini = objOpsimpesLn.consultValorTodo(sql, "PRODUCCION")
        sql = "select getdate()"
        fecha_fin = objOpsimpesLn.consultValorTodo(sql, "PRODUCCION")
        fecha_ini_c = CDate(fecha_ini)
        fecha_fin_c = CDate(fecha_fin)
        minutos = DateDiff(DateInterval.Minute, fecha_ini_c, fecha_fin_c)
        sql = "UPDATE D_paros_puas SET h_fin=getdate(),minutos=" & minutos & " where codmaqui= " & codMaq & " and h_fin is null"
        objOpsimpesLn.ejecutar(sql, "PRODUCCION")
        MessageBox.Show("El paro ha sido detenido", "Paro detenido", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
    End Sub


End Class