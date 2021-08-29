Imports logicaNegocios
Imports System.Speech
Public Class Frm_marcacion
    Private objOpSimplesLn As New Op_simpesLn
    Private objRelojLn As New RelojLn

    Private Sub timFecha_Tick(sender As Object, e As EventArgs) Handles timFecha.Tick
        ponerFechaHora()
    End Sub
    Private Sub ponerFechaHora()
        txt_hora.Text = TimeOfDay
        txtLector.Focus()
    End Sub

    Private Sub Frm_marcacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ponerFechaHora()
        If verificar_conexion_db() Then
            cargarSinSalida()
        End If
    End Sub
    Private Sub txtLector_Enter(sender As Object, e As EventArgs) Handles txtLector.Enter
        txtLector.BackColor = Color.Lime
    End Sub
    Private Sub txtLector_Leave(sender As Object, e As EventArgs) Handles txtLector.Leave
        txtLector.BackColor = Color.Red
    End Sub

    Private Sub btnRegistrar_Click(sender As Object, e As EventArgs) Handles btnRegistrar.Click
        registrarCedula()
    End Sub
    Private Sub txtFecha_Enter(sender As Object, e As EventArgs)
        txtLector.Focus()
    End Sub
    Private Sub txt_hora_Enter(sender As Object, e As EventArgs) Handles txt_hora.Enter
        txtLector.Focus()
    End Sub
    Private Sub txtAdvertencia_Enter(sender As Object, e As EventArgs) Handles txtAdvertencia.Enter
        txtLector.Focus()
    End Sub

    Private Sub registrarCedula()
        Dim codigo_ced As String
        Dim num_nit As String = (InputBox("Ingrese número de cèdula a registrar!", "Ingresar numero de cèdula")).Trim
        If (num_nit <> "0" And IsNumeric(num_nit)) Then
            codigo_ced = (InputBox("POR FAVOR COLOQUE AL FRENTE DEL LECTOR EL CODIGO DE LA CÉDULA PARA SER LEIDO", "Ingresar codigo de cèdula")).Trim
            If (codigo_ced <> "") Then
                Dim sql As String = "UPDATE  y_personal_contratos SET jjv_id  ='" & codigo_ced & "' WHERE nit = " & num_nit & " AND estado IN ('A', 'I', 'V', 'S')"
                If (objOpSimplesLn.ejecutar(sql, "CORSAN") <> 0) Then
                    MessageBox.Show("Su cedula fue registrada con exito", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("El número de cedula " & num_nit & " no coinside con ningun empleado, verifique que este bien digitada ò que no sea un visitante!", "verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                MessageBox.Show("Error al leer el código, intentelo de nuevo!", "verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Else
            MessageBox.Show("El número de cedula esta errado, verifique que no contenta letras ó no este en blanco!", "verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        txtLector.Text = ""
        txtLector.Focus()
    End Sub
    Private Sub txtLector_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtLector.KeyPress
        If (e.KeyChar = Microsoft.VisualBasic.ChrW(13)) Then
            If verificar_conexion_db() Then
                Dim codigo_ced As String = (txtLector.Text).Trim
                If objRelojLn.validar_personal_maquila(codigo_ced) Then
                    gestionarMarcacion_maquila(codigo_ced)
                Else
                    Dim sql As String = "select nit from V_nom_personal_Activo_con_maquila where Jjv_id = '" & codigo_ced & "' and estado='A' "
                    Dim nit As String = objOpSimplesLn.consultValorTodo(sql, "CORSAN")
                    If (nit <> "") Then
                        gestionarMarcacion(nit, "")
                    Else
                        Dim iResponce = MessageBox.Show("Documento errado o usuario no esta activo, verifique  que sea su cedula y no sea personal externo,¿Desea registrar su cédula?", "Atención", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                        If (iResponce = 6) Then
                            registrarCedula()
                        End If
                        txtLector.Text = ""
                    End If
                End If
            End If
        End If
    End Sub

    'Private Sub txtLector_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtLector.KeyPress
    '    If (e.KeyChar = Microsoft.VisualBasic.ChrW(13)) Then
    '        Dim nit As String = (txtLector.Text).Trim
    '        If (nit <> "") Then
    '            gestionarMarcacion(nit)
    '        Else
    '            Dim iResponce = MessageBox.Show("Documento errado, verifique  que sea su cedula y no sea personal externo,¿Desea registrar su cédula?", "Atención", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
    '            If (iResponce = 6) Then
    '                registrarCedula()
    '            End If
    '              txtLector.Text = ""
    '        End If
    '    End If
    'End Sub
    Private Sub gestionarMarcacion_maquila(ByVal cod_cel As String)
        Dim sql_peronsonal_maquila As String = "SELECT nit,nombres FROM J_personal_maquila WHERE cod_barras ='" & cod_cel & "'"
        Dim nit As Double = 0
        Dim nombres As String = ""
        Dim dt As DataTable = objOpSimplesLn.listar_datatable(sql_peronsonal_maquila, "CONTROL")
        nit = dt.Rows(0).Item("nit")
        nombres = dt.Rows(0).Item("nombres")
        Dim entrada As Boolean = False
        Dim salida As Boolean = False
        Dim permiso As String = ""
        Dim listSql As New List(Of Object)
        Dim marcar As Boolean = True
        Dim maquila As String = "S"
        If objRelojLn.esSalida(nit) Then
            Dim horas As Integer = objRelojLn.getHorasTrabajadas(nit)
            If horas <= 0 Then
                lblEstado.Text = "UDTED YA MARCÓ"
                txtLector.Text = ""
                lblNombres.Text = "UDTED YA MARCÓ"
                Exit Sub
            Else
                listSql.Add(objRelojLn.sqlAddSalida(nit, permiso, maquila))
                salida = True
            End If
        Else
            If objRelojLn.getDiffUltSalida(nit) >= 1 Then
                listSql.Add(objRelojLn.sqlAddEntrada(nit, permiso, maquila))
                entrada = True
            Else
                lblEstado.Text = "UDTED YA MARCÓ"
                txtLector.Text = ""
                lblNombres.Text = "UDTED YA MARCÓ"
                Exit Sub
            End If
        End If
        If marcar Then
            If objOpSimplesLn.ExecuteSqlTransactionTodo(listSql, "CONTROL") Then
                Dim audio = CreateObject("SAPI.spvoice")
                Dim texto_escuchar As String = ""
                audio.volume = 100
                audio.rate = 0
                lblNombres.Text = nombres
                cargar_foto(nit)

                If entrada Then
                    lblEstado.Text = "ENTRÓ"
                ElseIf salida Then
                    lblEstado.Text = "SALIÓ"
                End If
                If Now.Hour >= 0 And Now.Hour <= 11 Then
                    texto_escuchar = "buen día,"
                ElseIf Now.Hour > 11 And Now.Hour <= 18 Then
                    texto_escuchar = "buena tarde,"
                ElseIf Now.Hour > 18 And Now.Hour <= 24 Then
                    texto_escuchar = "buena noche,"
                End If
                Application.DoEvents()
                texto_escuchar &= lblNombres.Text
                audio.speak(texto_escuchar)
            Else
                lblEstado.Text = "NO SE INGRESO LA MARCACIÓN, COMUNIQUESE CON EL ADMINISTRADOR EL SISTEMA"
            End If
            cargarSinSalida()
        End If
        txtLector.Text = ""
    End Sub
    Private Sub gestionarMarcacion(ByVal nit As Double, permiso_cedula As String)
        Dim entrada As Boolean = False
        Dim salida As Boolean = False
        Dim permiso As String = ""
        Dim sql, centro As String
        Dim listSql As New List(Of Object)
        Dim marcar As Boolean = True
        If objRelojLn.esSalida(nit) Then
            Dim horas As Integer = objRelojLn.getHorasTrabajadas(nit)
            If horas <= 0 Then
                lblEstado.Text = "UDTED YA MARCÓ"
                txtLector.Text = ""
                lblNombres.Text = "UDTED YA MARCÓ"
                Exit Sub
            Else
                If permiso_cedula <> "C" Then
                    If (horas < 8) Then
                        If (objRelojLn.permisoSalida(nit)) Then
                            permiso = "S"
                        Else
                            permiso = "N"
                        End If
                    Else
                        permiso = "S"
                    End If
                Else
                    permiso = permiso_cedula
                End If
                listSql.Add(objRelojLn.sqlAddSalida(nit, permiso, ""))
                salida = True
            End If
        Else
            If objRelojLn.getDiffUltSalida(nit) >= 1 Then
                listSql.Add(objRelojLn.sqlAddEntrada(nit, permiso_cedula, ""))
                entrada = True
            Else
                lblEstado.Text = "UDTED YA MARCÓ"
                txtLector.Text = ""
                lblNombres.Text = "UDTED YA MARCÓ"
                Exit Sub
            End If
        End If
        sql = "select centro from V_nom_personal_Activo_con_maquila where nit=" & nit & ""
        centro = objOpSimplesLn.consultValorTodo(sql, "CORSAN")
        If centro <> "4100" And centro <> "4200" And centro <> "4300" Then
            If salida Then
                If permiso = "N" Then
                    Dim iResponce = MessageBox.Show("USTED ESTA MARCANDO ANTES DE LAS HORAS MINIMAS DE TRABAJO Y NO TIENE PERMISO,ESTA SEGURO DE SALIR?", "Atención", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                    If (iResponce <> 6) Then
                        marcar = False
                    End If
                End If
            End If
        End If
        If marcar Then
            If objOpSimplesLn.ExecuteSqlTransactionTodo(listSql, "CONTROL") Then
                Dim audio = CreateObject("SAPI.spvoice")
                Dim texto_escuchar As String = ""
                audio.volume = 100
                audio.rate = 0
                If permiso_cedula <> "P" Then
                    lblNombres.Text = objOpSimplesLn.consultarVal("SELECT nombres FROM terceros WHERE nit =" & nit)
                Else
                    lblNombres.Text = objOpSimplesLn.consultValorTodo("SELECT nombre_Contratista FROM J_control_contratistas WHERE nit_Contratista=" & nit & "", "CONTROL")
                End If
                cargar_foto(nit)

                If entrada Then
                    lblEstado.Text = "ENTRÓ"
                ElseIf salida Then
                    If permiso = "N" Then
                        lblEstado.Text = "SALIÓ SIN UN PERMISO ASIGANADO POR EL SUPERVISOR,ESTA MARCACIÓN PODRÍA SER NO PAGADA"
                    Else
                        lblEstado.Text = "SALIÓ"
                    End If
                End If
                If Now.Hour >= 0 And Now.Hour <= 11 Then
                    texto_escuchar = "buen día,"
                ElseIf Now.Hour > 11 And Now.Hour <= 18 Then
                    texto_escuchar = "buena tarde,"
                ElseIf Now.Hour > 18 And Now.Hour <= 24 Then
                    texto_escuchar = "buena noche,"
                End If
                Application.DoEvents()
                texto_escuchar &= lblNombres.Text
                audio.speak(texto_escuchar)
            Else
                lblEstado.Text = "NO SE INGRESO LA MARCACIÓN, COMUNIQUESE CON EL ADMINISTRADOR EL SISTEMA"
            End If
            cargarSinSalida()
        End If
        txtLector.Text = ""
    End Sub
    Private Sub gestionarVisitante(ByVal nit As Double, nombre As String)
        Dim entrada As Boolean = False
        Dim salida As Boolean = False
        Dim permiso As String = ""
#Disable Warning BC42024 ' Variable local sin usar: 'centro'.
#Disable Warning BC42024 ' Variable local sin usar: 'sql'.
        Dim sql, centro As String
#Enable Warning BC42024 ' Variable local sin usar: 'sql'.
#Enable Warning BC42024 ' Variable local sin usar: 'centro'.
        Dim listSql As New List(Of Object)
        Dim marcar As Boolean = True
        If objRelojLn.esSalida(nit) Then
            listSql.Add(objRelojLn.sqlAddSalidaVisit(nit))
            salida = True
            lblEstado.Text = "SALIÓ"
        Else
            listSql.Add(objRelojLn.sqlAddEntradaVisit(nit, nombre))
            entrada = True
            lblEstado.Text = "ENTRO"
        End If
        If objOpSimplesLn.ExecuteSqlTransactionTodo(listSql, "CONTROL") Then

        Else
            MessageBox.Show("Error al marcar", "")
        End If
        cargarSinSalida()
        txtLector.Text = ""
    End Sub
    Private Sub timConexion_Tick(sender As Object, e As EventArgs) Handles timConexion.Tick
        verificar_conexion_db()
    End Sub
    Private Function verificar_conexion_db() As Boolean
        Dim resp As Boolean = False
        If objOpSimplesLn.verificar_conexion() Then
            lblConexion.Text = "Conectado a la red!"
            lblConexion.ForeColor = Color.Green
            txtLector.Enabled = True
            resp = True
        Else
            lblConexion.Text = "Sin conexión a la red,comuniquese con el area de sistemas, o verifique la conexión por cable."
            lblConexion.ForeColor = Color.Red
            txtLector.Enabled = False
            txtAdvertencia.Focus()
            txtLector.Text = ""
        End If
        Return resp
    End Function
    Private Sub cargarSinSalida()
        sonido_marcacion()
        Dim tamano_letra As Single = 7.0!
        Dim sql As String = "SELECT t.nombres ,r.FechaEntrada  " &
                               "FROM r_personal_registros r , CORSAN.dbo.V_nom_personal_Activo_con_maquila  t , CORSAN.dbo.centros  c " &
                                     "WHERE r.nit = t.nit AND t.centro = c.centro AND FechaSalida is null   " &
                                        "ORDER BY YEAR(r.fechaEntrada),MONTH(r.fechaEntrada) ,DAY(r.fechaEntrada),DATEPART (hour,fechaEntrada),t.nombres "
        dtg_consulta.DataSource = objOpSimplesLn.listar_datatable(sql, "CONTROL")
        dtg_consulta.Columns("FechaEntrada").DefaultCellStyle.Format = "g"
        '   dtg_consulta.Columns("descripcion").DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", tamano_letra)
    End Sub
    Sub sonido_marcacion()
        'My.Computer.Audio.Play(Environment.CurrentDirectory & "\tono_marcacion.wav", _
        '    AudioPlayMode.Background)

    End Sub
    Private Sub cargar_foto(ByVal nit As Double)
        Dim sw As Boolean = False
        Dim nit_v As String
        Dim sql As String = "Select (CASE WHEN foto is null THEN '' ELSE 'S' END) From y_personal_contratos Where estado = 'A' AND nit = " & nit
        nit_v = objOpSimplesLn.consultValorTodo(sql, "CORSAN")
        If nit_v <> "" Then
            sw = True
        Else
            sql = "Select (CASE WHEN foto is null THEN '' ELSE 'S' END) From j_personal_maquila Where estado = 'A' AND nit = " & nit
            nit_v = objOpSimplesLn.consultValorTodo(sql, "CONTROL")
        End If
        If nit_v <> "" Then
            Application.DoEvents()
            Try
                Dim ms As New IO.MemoryStream(objOpSimplesLn.ExtraerImagen(nit))
                pic_foto.Image = Image.FromStream(ms)
            Catch ex As Exception
                ' MessageBox.Show(ex.Message)
                pic_foto.Image = Nothing
            End Try
        Else
            Dim ruta As String = Environment.CurrentDirectory & "\sinFoto.gif"
            pic_foto.Image = System.Drawing.Image.FromFile(ruta)
        End If

    End Sub
    Private Sub btn_sin_ced_Click(sender As Object, e As EventArgs) Handles btn_sin_ced.Click
        Dim num_nit As String = (InputBox("Ingrese número de cédula!", "Ingresar numero de cédula")).Trim
        If (num_nit <> "0" And IsNumeric(num_nit)) Then
            If objOpSimplesLn.validarNit(num_nit) Then
                If objRelojLn.validar_permiso_sin_ced(num_nit) Then
                    gestionarMarcacion(num_nit, "Z")
                Else
                    lblNombres.Text = "No tiene permiso para entrar, se marcó mas de una ves en los últimos 6 meses,NO TIENE PERMISO DE INGRESO"
                    lblEstado.Text = "NO INGRESA"
                    MessageBox.Show("No tiene permiso para entrar, se marcó mas de una ves en los últimos 6 meses", "NO TIENE PERMISO DE INGRESO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                MessageBox.Show("El número de cedula esta errado, verifique que no contenta letras ó no este en blanco!", "verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub
    Private Sub btn_reg_maquilas_Click(sender As Object, e As EventArgs) Handles btn_reg_maquilas.Click
        FrmReg_personal_maquila.ShowDialog()
    End Sub
    Private Sub btn_consultar_cont_Click(sender As Object, e As EventArgs) Handles btn_consultar_cont.Click
        Dim frm As New Consulta_dias_per()
        frm.main(0, "N")
        frm.ShowDialog()
    End Sub

    Private Sub btn_marc_cont_Click(sender As Object, e As EventArgs) Handles btn_marc_cont.Click
        Dim num_nit As String = (InputBox("Ingrese número de cédula!", "Ingresar numero de cédula")).Trim

        If (num_nit <> "0" And IsNumeric(num_nit)) Then
            If objOpSimplesLn.validarNitCont(num_nit) Then
                If objOpSimplesLn.validarDiaPerCont(num_nit) Then
                    If objRelojLn.validar_permiso_sin_ced(num_nit) Then
                        gestionarMarcacion(num_nit, "P")
                    Else
                        lblNombres.Text = "No tiene permiso para entrar, se marcó mas de una ves en los últimos 6 meses,NO TIENE PERMISO DE INGRESO"
                        lblEstado.Text = "NO INGRESA"
                        MessageBox.Show("No tiene permiso para entrar, se marcó mas de una ves en los últimos 6 meses", "NO TIENE PERMISO DE INGRESO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                Else
                    MessageBox.Show("No tiene permiso para entrar,no tiene programación para este dia", "NO TIENE PERMISO DE INGRESO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                MessageBox.Show("El número de nit esta errado, verifique que no contenta letras ó no este en blanco!", "verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Private Sub btn_marc_visit_Click(sender As Object, e As EventArgs) Handles btn_marc_visit.Click
        Dim num_nit As String = (InputBox("Ingrese número de cédula!", "Ingresar numero de cédula")).Trim
        Dim nombre As String = (InputBox("Ingrese nombre de visitante!", "Ingresar numero de ")).Trim
        gestionarVisitante(num_nit, nombre)
    End Sub
End Class