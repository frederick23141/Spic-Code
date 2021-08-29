Imports System.Data.SqlClient
Imports entidadNegocios
Imports accesoDatos
Imports logicaNegocios
Public Class Frm_generar_marcacion
    'autor david hincapié
    'guarda la entrada y salida de los empleados de la empresa
    Private dt As New DataTable
    Dim Da As New SqlDataAdapter
    Dim Cmd As New SqlCommand
    Dim operacionformato As New Op_simpesLn
    Dim nit As Double
    Dim horae As String
    Dim horas As String
    Dim permiso As String = "S"
    Dim horage, minutoge, horags, minutogs As String
    Dim cnn As New Conexion

    Private Sub Frm_entrada_usuarios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dt As New DataTable
        With Cmd
            .CommandType = CommandType.Text
            .CommandText = "SELECT nit,nombres FROM V_nom_personal_Activo_con_maquila ORDER BY nombres"
            .Connection = cnn.abrirConexion
        End With
        Da.SelectCommand = Cmd
        dt = New DataTable
        Da.Fill(dt)
        With cbo_usuario
            .DisplayMember = "nombres"
            .ValueMember = "nit"
            cbo_usuario.Text = "Seleccione"
            .DataSource = dt
        End With


    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            permiso = "Z"
        Else
            permiso = "C"
        End If
    End Sub
    Private Sub cbo_usuario_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_usuario.SelectedIndexChanged
        nit = cbo_usuario.SelectedValue
    End Sub

    Private Sub btnguardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnguardar.Click
        If cbo_usuario.Text <> "" And cbo_fec_entrada.Text <> "" And cbo_hora_entrada.Text <> "" And cbo_min_entrada.Text <> "" And cbo_fecha_salida.Text <> "" And cbo_hora_salida.Text <> "" And cbo_min_salida.Text <> "" And txtnota.Text <> "" Then
            Try
                Dim dts As New entradausuarioEn
                Dim func As New Entrada_usuarioAd
                Dim fechae As String = operacionformato.cambiarFormatoFecha(cbo_fec_entrada.Value)
                horae = horage & ":" & minutoge & ":00"
                Dim fechas As String = operacionformato.cambiarFormatoFecha(cbo_fecha_salida.Value)
                horas = horags & ":" & minutogs & ":00"
                Dim fecha_horae As String
                Dim fecha_horas As String


                fecha_horae = fechae & " " & horae
                fecha_horas = fechas & " " & horas
                Dim diferencia As Long = DateDiff(DateInterval.Hour, CDate(fecha_horae), CDate(fecha_horas))
                If CDate(fecha_horas) > CDate(fecha_horae) And diferencia <= 18 Then
                    dts.gconsecutivo = func.generar_consecutivo
                    dts.gnit = nit
                    dts.gfecha_entrada = fecha_horae
                    dts.gfecha_salida = fecha_horas
                    dts.gnotas = txtnota.Text
                    dts.gpermiso = permiso
                    If func.insertar(dts) Then
                        MessageBox.Show("empleado registrado correctamente", "Guardando registros", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        limpiar()

                    Else
                        MessageBox.Show("empleado no fue registrado", "Guardando registros", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        limpiar()

                    End If
                Else
                    MessageBox.Show("La fecha de salida debe ser mayor que la de entrada o el intervalo no es menor a 18 horas", "Guardando registros", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Else
            MessageBox.Show("Falta ingresar algunos datos", "Guardando registros", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btncancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancelar.Click
        Me.Close()
    End Sub
    Public Sub limpiar()

        txtnota.Text = ""
        CheckBox1.Checked = False

    End Sub

    Private Sub cbo_hora_entrada_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_hora_entrada.SelectedIndexChanged
        horage = cbo_hora_entrada.SelectedItem
    End Sub

    Private Sub cbo_min_entrada_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_min_entrada.SelectedIndexChanged
        minutoge = cbo_min_entrada.SelectedItem
    End Sub

    Private Sub cbo_hora_salida_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_hora_salida.SelectedIndexChanged
        horags = cbo_hora_salida.SelectedItem
    End Sub

    Private Sub cbo_min_salida_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_min_salida.SelectedIndexChanged
        minutogs = cbo_min_salida.SelectedItem
    End Sub
End Class
