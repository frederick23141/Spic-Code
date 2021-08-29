Imports logicaNegocios
Imports accesoDatos
Imports entidadNegocios
Imports System.Data.SqlClient
Public Class Frm_pesar_cargar_rollo
    Dim Codigo_f As String
    Dim codigo__prima As String
    Private peso As String = ""
    Dim orden As Integer
    Dim numero_bobina As Integer
    Private numero_transaccion As Double
    Private objOpsimpesLn As New Op_simpesLn
    Private obj_Ing_prodLn As New Ing_prodLn
    Dim peso_devanador As String
    Dim nit_usuarios As Integer
    Dim nomb_operario As String
    Dim id_cliente_a As Integer
    Dim centro As String = "5200"
    Dim noconforme As String = ""
    Dim objTraslado_bodLn As New traslado_bodLn
    Dim obj_gestion_materia_primaLn As New Gestion_materia_primaLn
    Dim calibre As String = ""
    Dim result As MsgBoxResult
    Private objOrdenProdLn As New OrdenProdLn
    Dim Cmd As New SqlCommand
    Public Sub main(ByVal bobina As Integer, ByVal producto_f As String, ByVal mat_p As String, ByVal nro_orden As String, ByVal nom_usua As String, ByVal nit_usuario As Integer, ByVal port As Integer, ByVal id_cliente As Integer, ByVal calibre As String)
        numero_bobina = bobina
        Codigo_f = producto_f
        codigo__prima = mat_p
        orden = nro_orden
        nit_usuarios = nit_usuario
        If nit_usuarios = 0 Then
            Me.Close()
        End If
        nomb_operario = nom_usua
        lbl_bobina.Text = numero_bobina
        id_cliente_a = id_cliente
        Dim sql_peso_devanador As String = "select P_devanador from D_Bobina_Devanador where nro_bobina=" & numero_bobina & ""
        Dim sql_descripcion As String = "select descripcion from referencias where ref_anulada='n' and capa is not null AND codigo='" & Codigo_f & "'"
        Dim descripcion As String
        peso_devanador = objOpsimpesLn.consultValorTodo(sql_peso_devanador, "PRODUCCION")
        descripcion = objOpsimpesLn.consultValorTodo(sql_descripcion, "CORSAN")
        Lbldevanador.Text = peso_devanador
        lbl_desc_producto.Text = descripcion
        lblnomb_panel.Text = nom_usua
        lbl_calibre.Text = calibre
        If peso_devanador = "" Or peso_devanador = "0" Then
            GroupBox_devanador.BackColor = Color.Red
            btn_p_devanador.Visible = True
            Btn_borrar_Devanador.Visible = False
            flecha_rollo.Visible = False
        Else
            GroupBox_devanador.BackColor = Color.GreenYellow
            flecha_devanador.Visible = False
            GroupBox_rollo.Visible = True
            flecha_rollo.Visible = True
            btn_p_devanador.Visible = False
            Btn_borrar_Devanador.Visible = True
        End If
        If port = 1 Then
            SerialPort1.Open()
        Else
            SerialPort2.Open()
        End If
        cargar_datasource()
        Panel_cargar.Visible = False
        Group_defecto.Visible = False
        Timer1.Enabled = True
        lbl_codigo_m.Text = Codigo_f
        lbl_orden.Text = orden
        Me.calibre = calibre
    End Sub
    Private Sub Frm_seleccion_accion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)
        HelpProvider1.SetHelpString(btn_p_devanador, "Este boton abrira una venta para pesar el devanador")
        HelpProvider2.SetHelpString(btn_cargar_rollo, "Este boton abrira una venta para pesar el rollo")
    End Sub
    Private Sub cargar_datasource()
        Dim dt As New DataTable
        Dim row As DataRow
        Dim Sql As String
        dt = New DataTable
        Sql = "SELECT d.Id_defecto,d.D_defecto " &
                        " FROM J_desperdicios_defecto d , J_desperdicio_def_centro c " & _
                            "WHERE d.id_defecto = c.id_defecto AND c.centro =" & centro
        dt = objOpsimpesLn.listar_datatable(Sql, "PRODUCCION")
        row = dt.NewRow
        row("Id_defecto") = 0
        row("D_defecto") = "TODO"
        dt.Rows.Add(row)
        cbo_defecto.DataSource = dt
        cbo_defecto.ValueMember = "Id_defecto"
        cbo_defecto.DisplayMember = "D_defecto"
        cbo_defecto.SelectedValue = 0
    End Sub
    Private Sub guardar_peso_devanador()
        Using New Centered_MessageBox(Me)
            Dim mypeso() As Char = {"?", "", ".", "*", "=", "¿", "'"}
            Dim rpeso As String = capturarPeso()
            Dim peso As String = rpeso.Trim(mypeso)
            Dim sql As String
            If peso = "" Then
                peso = "0"
            End If
            sql = "update D_Bobina_Devanador set P_devanador=" & peso & " where nro_bobina=" & numero_bobina
            obj_Ing_prodLn.consultar_valor(sql, "PRODUCCION")
            MessageBox.Show("El peso del devanador ha sido guardado", "Peso del devanador guardado", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End Using
    End Sub
    Private Sub guardar_transaccion_rollo(ByVal desp_nc As String)
        Dim resp_transaccion As Boolean = False
        Dim tipo As String = ""
        Dim mypeso() As Char = {"?", "", ".", "*", "=", "¿", "'", "-"}
        Dim rpeso As String = capturarPeso()
        Dim dFec As Date = Now
        Dim bodega As String = objTraslado_bodLn.obtenerBodegaXcodigo(Codigo_f)
        Dim listTransaccion_corsan, listransaccion As New List(Of Object)
        Dim capa As String
        Dim peso As String = rpeso.Trim(mypeso)
        Dim pesonoc As String = rpeso.Trim(mypeso)
        Dim descripcion As String
        Dim nombre_cliente As String
        Dim consecutivo As String
        Dim consecutivod As Integer
        Dim dts As New galvanizadoEn
        Dim func As New galvanizadoAd
        Dim dt As New DataTable
        Dim sqlguardar As String = ""
        Dim sql_nombre_cliente As String = "SELECT descripcion from J_destino_galv where id=" & id_cliente_a & ""
        Dim sql_nombre_capa As String = "SELECT capa from referencias where capa is not null AND codigo='" & Codigo_f & "'"
        Dim sql_descripcion As String = "SELECT descripcion from referencias where ref_anulada='n' and capa is not null AND codigo='" & Codigo_f & "'"
        Dim sql_Consecutivo As String = "SELECT  MAX (consecutivo_rollo) FROM D_rollo_galvanizado_f where nro_orden=" & orden & ""
        Dim sql_tolerancias As String = "SELECT rollo, porc_tolerancia, rango_superior FROM J_galv_tolerancia"
        Dim sql_codigos As String = "SELECT codigo from D_val_galv_ref"
        Dim dt_tolerancias As DataTable = objOpsimpesLn.listar_datatable(sql_tolerancias, "PRODUCCION")
        Dim dt_codigos_val As DataTable = objOpsimpesLn.listar_datatable(sql_codigos, "PRODUCCION")
        Dim s_fecha As Date = Now
        Dim diferencia As Double = 0
        Dim rango_cumpli As Boolean = True
        Dim validar_rango As Boolean = True
        Dim val_25_kilos As Boolean = False
        noconforme = desp_nc
        For i = 0 To dt_codigos_val.Rows.Count - 1
            If lbl_codigo_m.Text.ToUpper = dt_codigos_val.Rows(i).Item("codigo").ToString.ToUpper Then
                val_25_kilos = True
            End If
        Next
        If bodega = 3 And noconforme = "" Then
            tipo = "EPPT"
            For i = 0 To dt_tolerancias.Rows.Count - 1
                Dim calc As Double
                If peso >= dt_tolerancias.Rows(i).Item("rollo") - (dt_tolerancias.Rows(i).Item("rollo") * (dt_tolerancias.Rows(i).Item("porc_tolerancia") / 100)) And peso <= dt_tolerancias.Rows(i).Item("rango_superior") Then
                    rango_cumpli = False
                    If dt_tolerancias.Rows(i).Item("rollo") = 25 And val_25_kilos = True Then
                        calc = dt_tolerancias.Rows(i).Item("rollo") - (dt_tolerancias.Rows(i).Item("rollo") * (dt_tolerancias.Rows(i).Item("porc_tolerancia") / 100)) + 0.4
                        If peso > calc And Convert.ToDouble(peso) <= dt_tolerancias.Rows(i).Item("rango_superior") Then
                            MessageBox.Show("Peso fuera del rango máximo establecido " & Convert.ToDouble(dt_tolerancias.Rows(i).Item("rollo") * ((dt_tolerancias.Rows(i).Item("porc_tolerancia") / 100) + 1)) & " , por lo tanto no se hara el registro", "Peso fuera de rango", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            validar_rango = False
                        End If
                    ElseIf dt_tolerancias.Rows(i).Item("rollo") <> 25 And val_25_kilos = False Then
                        calc = dt_tolerancias.Rows(i).Item("rollo") - (dt_tolerancias.Rows(i).Item("rollo") * (dt_tolerancias.Rows(i).Item("porc_tolerancia") / 100)) + 0.6
                        If peso > calc And Convert.ToDouble(peso) <= dt_tolerancias.Rows(i).Item("rango_superior") Then
                            MessageBox.Show("Peso fuera del rango máximo establecido " & Convert.ToDouble(dt_tolerancias.Rows(i).Item("rollo") * ((dt_tolerancias.Rows(i).Item("porc_tolerancia") / 100) + 1)) & " , por lo tanto no se hara el registro", "Peso fuera de rango", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            validar_rango = False
                        End If
                    Else
                        MessageBox.Show("Se esta intentando registrar una referencia de 25 kilos con un peso diferente.", "Peso fuera de rango", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        validar_rango = False
                    End If
                    diferencia = (Convert.ToDouble(peso)) - dt_tolerancias.Rows(i).Item("rollo")
                    peso = dt_tolerancias.Rows(i).Item("rollo")
                End If
            Next
        ElseIf bodega = 2 And noconforme = "" Then
            tipo = "EPPP"
            rango_cumpli = False
        End If
        If noconforme <> "" Then
            rango_cumpli = False
            validar_rango = True
        End If
        nombre_cliente = objOpsimpesLn.consultValorTodo(sql_nombre_cliente, "PRODUCCION")
        capa = objOpsimpesLn.consultValorTodo(sql_nombre_capa, "CORSAN")
        descripcion = objOpsimpesLn.consultValorTodo(sql_descripcion, "CORSAN")
        consecutivo = objOpsimpesLn.consultValorTodo(sql_Consecutivo, "PRODUCCION")
        If consecutivo = "" Then
            consecutivo = "0"
        End If
        consecutivod = CInt(consecutivo) + 1
        If peso_devanador = "" Then
            peso_devanador = "0"
        End If
        If peso = "" Then
            peso = "0"
        End If
        If pesonoc = "" Then
            pesonoc = "0"
        End If
        If peso >= peso_devanador Then
            peso = peso - peso_devanador
        End If
        Dim convertir_peso As Double = CDbl(peso)
        Dim convertir_peso2 As Double = CDbl(pesonoc)
        dt.Columns.Add("codigo")
        dt.Columns.Add("cantidad")
        dt.Rows.Add()
        dt.Rows(dt.Rows.Count - 1).Item("codigo") = Codigo_f
        dt.Rows(dt.Rows.Count - 1).Item("cantidad") = peso
        bodega = "2"
        tipo = "EPPP"
        If validar_rango = True Then
            If rango_cumpli = False Then
                If convertir_peso <> 0.0 Or convertir_peso2 <> 0.0 Then
                    If noconforme = "" Then
                        listTransaccion_corsan.AddRange(transaccion(dt, tipo, nit_usuarios, bodega, orden, consecutivod))
                        If obj_Ing_prodLn.ExecuteSqlTransaction(listTransaccion_corsan, "CORSAN") Then
                            sqlguardar = "INSERT INTO D_rollo_galvanizado_f " &
                                      "(nro_orden,consecutivo_rollo,nit_operario,bobina,peso,fecha_hora,capa,tipo_trans,diferencia) " &
                                          "VALUES " &
                                                  "(" & orden & "," & consecutivod & "," & nit_usuarios & "," & numero_bobina & "," & convertir_peso & ", GETDATE() ,'" & capa & "','" & tipo & "'," & diferencia & ")"
                            obj_Ing_prodLn.consultar_valor(sqlguardar, "PRODUCCION")

                            sqlguardar = "UPDATE D_rollo_galvanizado_f set trans_galv=" & numero_transaccion & " where nro_orden=" & orden & " and consecutivo_rollo=" & consecutivod & ""
                            objOpsimpesLn.consultValorTodo(sqlguardar, "PRODUCCION")

                            MessageBox.Show("rollo registrado correctamente", "Guardando registros", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            imprimirTiquete(nombre_cliente, consecutivod, Codigo_f, codigo__prima, peso, numero_bobina, capa, s_fecha, descripcion)
                        Else
                            MessageBox.Show("rollo no fue registrado", "Guardando registros", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    Else
                        'Dim modelo As String
                        dt.Rows(dt.Rows.Count - 1).Item("cantidad") = convertir_peso2
                        'bodega = 2
                        'If desp_nc = "NC" Then
                        '    tipo = "EIPP"
                        '    modelo = "03"

                        'Else
                        '    tipo = "SAI2"
                        '    modelo = "02"

                        'End If
                        'listransaccion.AddRange(transaccion_eipp_sai(dt, tipo, bodega, modelo, nit_usuarios))

                        sqlguardar = "INSERT INTO D_rollo_galvanizado_f " &
                                    "(nro_orden,consecutivo_rollo,nit_operario,bobina,peso,fecha_hora,capa,no_conforme,diferencia) " &
                                        "VALUES " &
                                                "(" & orden & "," & consecutivod & "," & nit_usuarios & "," & numero_bobina & "," & convertir_peso2 & ", GETDATE() ,'" & capa & "','" & noconforme & "'," & diferencia & ")"
                        obj_Ing_prodLn.consultar_valor(sqlguardar, "PRODUCCION")
                        'obj_Ing_prodLn.ExecuteSqlTransaction(listransaccion, "CORSAN")
                        sqlguardar = "UPDATE D_rollo_galvanizado_f set trans_galv=" & numero_transaccion & " where nro_orden=" & orden & " and consecutivo_rollo=" & consecutivod & ""
                        objOpsimpesLn.consultValorTodo(sqlguardar, "PRODUCCION")
                        MessageBox.Show("rollo no conforme registrado correctamente", "Guardando registros", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Dim result As DialogResult
                        result = MessageBox.Show("Desea generar tiquete para el no conforme?", "Generar tiquete", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                        If result = vbYes Then
                            imprimirTiquete(nombre_cliente, consecutivo, Codigo_f, codigo__prima, peso, numero_bobina, capa, s_fecha, descripcion)
                        End If
                    End If
                Else
                    MessageBox.Show("El peso no puede ser 0", "Guardando registros", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Else
                MessageBox.Show("Peso no acorde con los rollos de galvanizado", "Peso no acorde", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            MessageBox.Show("Peso fuera del rango de pesos establecido (25 - 50 - 75 - 100)", "Peso fuera de rango", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        noconforme = ""
    End Sub
    Private Sub imprimirTiquete(ByVal nombre_cliente As String, ByVal consecutivo As Integer, ByVal codigor As String, ByVal m_prima As String, ByVal peso As String, ByVal bobina As Integer, ByVal capa As String, ByVal fecha As Date, ByVal descripcion As String)
        Dim proc As New Process
        Dim s_fec As String = fecha.Year & "-" & fecha.Month & "-" & fecha.Day & " " & fecha.Hour & ":" & fecha.Minute & ""
        modificarPlantilla(nombre_cliente, consecutivo, codigor, m_prima, peso, bobina, capa, s_fec, descripcion)
        If noconforme = "" Then
            proc.StartInfo.FileName = Environment.CurrentDirectory & "\plantillaGalvanizadoImp.txt"
        Else
            proc.StartInfo.FileName = Environment.CurrentDirectory & "\tiquetechatarrafuncional.txt"
        End If
        proc.StartInfo.Verb = "Print"
        proc.StartInfo.CreateNoWindow = False
        proc.Start()
    End Sub
    Private Sub modificarPlantilla(ByVal nom_cliente As String, ByVal consecutivo As Integer, ByVal codigor As String, ByVal m_prima As String, ByVal peso As String, ByVal bobina As Integer, ByVal capa As String, ByVal fechar As String, ByVal descripcion As String)
        Dim fic As String
        Dim nuevoFic As String
        If noconforme = "" Then
            fic = Environment.CurrentDirectory & "\plantillaGalvanizado.txt"
            nuevoFic = Environment.CurrentDirectory & "\plantillaGalvanizadoImp.txt"
        Else
            fic = Environment.CurrentDirectory & "\tiquetechatarradiseño.txt"
            nuevoFic = Environment.CurrentDirectory & "\tiquetechatarrafuncional.txt"
        End If
        Dim sw As New System.IO.StreamWriter(nuevoFic)
        Dim texto As String
        Dim sr As New System.IO.StreamReader(fic)
        Dim codOrden As String = codigor
        texto = sr.ReadToEnd()
        If noconforme = "" Then
            texto = Replace(texto, "@cliente", nom_cliente)
            texto = Replace(texto, "@codigo", codigor)
            texto = Replace(texto, "@descripcion", descripcion)
            texto = Replace(texto, "@operario", nomb_operario)
            texto = Replace(texto, "@peso", peso & " (Kg)")
            texto = Replace(texto, "@consecutivo", orden & "-" & consecutivo)
            texto = Replace(texto, "@bobina", bobina)
            texto = Replace(texto, "@fecha", fechar)
            texto = Replace(texto, "@capa", capa)
            texto = Replace(texto, "@materia_prima", m_prima)
            texto = Replace(texto, "@calibre", calibre)
            texto = Replace(texto, "@barras", orden & "-" & consecutivo)
        Else
            texto = Replace(texto, "@Operario", nomb_operario)
            texto = Replace(texto, "@Descripcion", "CHATARRA")
            texto = Replace(texto, "@Peso", peso & " (Kg)")
            texto = Replace(texto, "@Bobina", bobina)
            texto = Replace(texto, "@FECHA", fechar)
            texto = Replace(texto, "@Nit", "OPERARIO")
            texto = Replace(texto, "@Prod", codigor)
            texto = Replace(texto, "@Planta", "GALVANIZADO")
            texto = Replace(texto, "@MAT", m_prima)
        End If
        sr.Close()
        sw.WriteLine(texto)
        sw.Close()

    End Sub
    Private Sub guardar_desperdicio(ByVal desp_nc As String)
        Dim mypeso() As Char = {"?", "", ".", "*", "=", "¿", "'", "-"}
        Dim rpeso As String = capturarPeso()
        Dim peso As String = rpeso.Trim(mypeso)
        Dim listSql As New List(Of Object)
        Dim tipo As Integer = 0
        Dim causal As Integer = 0
        Dim defecto As Integer = 0

        Dim operario As String = nit_usuarios
        Dim fecha As String = ""
        If (Now.Hour >= 0 And Now.Hour <= 5) Then
            fecha = objOpsimpesLn.cambiarFormatoFecha((Now.AddDays(-1)).Date)
        Else
            fecha = objOpsimpesLn.cambiarFormatoFecha(Now.Date)
        End If
        If peso_devanador = "" Then
            peso_devanador = "0"
        End If
        If peso = "" Then
            peso = "0"
        End If
        tipo = 8
        causal = 1
        defecto = cbo_defecto.SelectedValue
        Dim kilos As Double = CDbl(peso)

        listSql.AddRange(sql_ing_desperdicios(fecha, operario, kilos, tipo, causal, defecto))
        If (objOpsimpesLn.ExecuteSqlTransactionTodo(listSql, "PRODUCCION")) Then
            guardar_transaccion_rollo(desp_nc)
            cbo_defecto.SelectedValue = 0
            Group_defecto.Visible = False
        End If
    End Sub
    Private Function sql_ing_desperdicios(ByVal fecha As String, ByVal nit As Double, ByVal kilos As Double, ByVal tipo As Integer, ByVal causal As Integer, ByVal defecto As Integer)
        Dim listSql As New List(Of Object)
        Dim id_existente As Integer = 0
        Dim sql_descripcion As String = "select descripcion from referencias where ref_anulada='n' and capa is not null AND codigo='" & Codigo_f & "'"
        Dim descripcion As String = objOpsimpesLn.consultValorTodo(sql_descripcion, "CORSAN")
        Dim observaciones As String = numero_bobina & "-" & descripcion
        Dim destino As Integer = 1 ' para que todo lo lleve a Contenerdor Metalicos 
        Dim bobina As String = lbl_bobina.Text
        listSql.AddRange(obj_Ing_prodLn.guardar_desperdicio(fecha, nit, centro, kilos, tipo, causal, defecto, observaciones, id_existente, destino, bobina))
        Return listSql
    End Function
    Private Function transaccion(ByVal datacodigo As DataTable, ByVal tipo As String, ByVal usuario_g As String, ByVal bodega As Integer, ByVal orden As Integer, ByVal consecutivo As Integer) As List(Of Object)
        Dim listSql As New List(Of Object)
        Dim dFec As Date = Now
        Dim usuario As String = usuario_g
        Dim modelo As String = "01"
        Dim notas As String = "SPIC fecha:" & Now & " usuario:" & usuario
        numero_transaccion = objOrdenProdLn.mover_consecutivo(tipo)
        listSql = objTraslado_bodLn.listaTransaccionDatable(numero_transaccion, datacodigo, bodega, dFec, notas, usuario, tipo, modelo)
        Return listSql
    End Function
    Private Function capturarPeso() As String
        Dim pesoFinal As String = ""
        Dim primerIgual As Boolean = False
        For i = 0 To txt_peso.TextLength - 1
            If (txt_peso.Text(i) = "=" Or primerIgual = True) Then
                If (primerIgual = False) Then
                    i += 1
                    primerIgual = True
                End If
                If (txt_peso.Text(i) <> "=") Then
                    If (txt_peso.Text(i) <> "-") Then
                        If (txt_peso.Text(i) <> " ") Then
                            If (txt_peso.Text(i) = "0") Then
                                If (pesoFinal.Length > 0) Then
                                    pesoFinal += txt_peso.Text(i)
                                End If
                            Else
                                pesoFinal += txt_peso.Text(i)
                            End If
                        End If
                    End If
                Else
                    i = txt_peso.TextLength
                End If
            End If
        Next
        If (pesoFinal = "") Then
            Dim primerNumeroNoCero As Boolean = False
            For i = 0 To txt_peso.Text.Length - 1
                If ((txt_peso.Text(i) <> "0" And txt_peso.Text(i) <> " ") Or primerNumeroNoCero = True) Then
                    primerNumeroNoCero = True
                    pesoFinal += txt_peso.Text(i)
                End If
            Next

        End If
        Return pesoFinal
    End Function
    Private Function validarcargaderollo() As Boolean
        Using New Centered_MessageBox(Me)
            If txt_peso.Text <> "" Then
                Return True
            Else
                MessageBox.Show("peso vacio", "peso no asignado", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Using
        Return False
    End Function
    Private Function transaccion_eipp_sai(ByVal datacodigo As DataTable, ByVal tipo As String, ByVal bodega As Integer, ByVal modelo As String, ByVal usuario As String) As List(Of Object)
        Dim listSql As New List(Of Object)
        Dim dFec As Date = Now
        Dim notas As String = "SPIC fecha:" & Now & " usuario:" & usuario
        numero_transaccion = objOrdenProdLn.mover_consecutivo(tipo)
        listSql = objTraslado_bodLn.listaTransaccionDatable(numero_transaccion, datacodigo, bodega, dFec, notas, usuario, tipo, modelo)
        Return listSql
    End Function
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If (txt_peso.TextLength >= 30) Then
            txt_peso.Text = peso
        End If
        If SerialPort1.IsOpen Then
            peso = SerialPort1.ReadExisting
            txt_peso.Text += peso
        ElseIf SerialPort2.IsOpen Then
            peso = SerialPort2.ReadExisting
            txt_peso.Text += peso
        End If
    End Sub
    Private Sub btn_cargar_rollo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cargar_rollo.Click
        Panel_cargar.Visible = True
    End Sub

    Private Sub btn_p_devanador_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_p_devanador.Click
        Dim frm_galva As New FrmOrdenProdGalv
        If My.Computer.Network.IsAvailable Then
            If validarcargaderollo() Then
                guardar_peso_devanador()
                GroupBox_devanador.BackColor = Color.GreenYellow
            End If
        Else
            MessageBox.Show("El computador no esta conectado a la red", "No Conectado", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End If
        Me.Close()
        frm_galva.recorrer_botones_color()
    End Sub
    Private Sub Frm_pesar_cargar_rollo_D_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Timer1.Enabled = False
        If SerialPort1.IsOpen Then
            SerialPort1.Close()
        ElseIf SerialPort2.IsOpen Then
            SerialPort2.Close()
        End If
    End Sub

    Private Sub Btn_borrar_Devanador_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_borrar_Devanador.Click
        Dim sql As String
        Dim frm_galva As New FrmOrdenProdGalv
        Dim peso As String = "0"
        Dim result As DialogResult
        result = MessageBox.Show("desea borrar el devanador?", "Guardando registros", MessageBoxButtons.YesNo, MessageBoxIcon.Error)
        If result = vbYes Then
            sql = "update D_Bobina_Devanador set P_devanador=" & peso & " where nro_bobina=" & numero_bobina
            obj_Ing_prodLn.consultar_valor(sql, "PRODUCCION")
            MessageBox.Show("El peso del devanador ha sido Borrado", "Peso del devanador ha sido borrado", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
            frm_galva.recorrer_botones_color()
        End If
    End Sub

    Private Sub btn_cargar_rollo_N_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cargar_rollo_N.Click
        Group_defecto.Visible = True
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Group_defecto.Visible = False
    End Sub
    Private Sub btn_ok_defecto_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ok_defecto.Click
        If My.Computer.Network.IsAvailable Then
            If validarcargaderollo() Then
                If cbo_defecto.SelectedValue <> 0 Then
                    Dim tipo_desp_nc As String
                    nit_usuarios = InputBox("Ingresar nro de cedula:", "Ingreso de cedula")
                    nomb_operario = objOpsimpesLn.consultValorTodo("select nombres from V_nom_personal_Activo_con_maquila where  nit in (select nit from control.dbo.D_empleados_sin_salida) and nit=" & nit_usuarios & "", "CORSAN")
                    If nomb_operario <> "" Then
                        result = MessageBox.Show("Desea registrar un desperdicio o un no conforme?1.si-no conforme,2.no-desperdicio,", "Registro de nc o desp", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                        If result = MsgBoxResult.Yes Then
                            tipo_desp_nc = "NC"
                        Else
                            tipo_desp_nc = "DE"
                        End If

                        guardar_desperdicio(tipo_desp_nc)
                        noconforme = ""
                        Me.Close()
                    Else
                        MessageBox.Show("Operario ingresado no existe", "Operario ingresado no existe.", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                Else
                    MessageBox.Show("Seleccione tipo de defecto", "Seleccione tipo de defecto", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End If
        Else
            MessageBox.Show("El computador no esta conectado a la red", "No Conectado", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End If
    End Sub
    Private Sub btncargar_panel_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncargar_panel.Click
        Dim result As DialogResult
        result = MessageBox.Show("Desea pesar el rollo?", "Pesar rollo", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
        If result = vbYes Then
            If My.Computer.Network.IsAvailable Then
                If validarcargaderollo() Then
                    guardar_transaccion_rollo("")
                End If
                Me.Close()
            Else
                MessageBox.Show("El computador no esta conectado a la red", "No Conectado", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Close()
            End If
        Else
            Me.Close()
        End If
    End Sub
    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Panel_cargar.Visible = False
    End Sub
End Class