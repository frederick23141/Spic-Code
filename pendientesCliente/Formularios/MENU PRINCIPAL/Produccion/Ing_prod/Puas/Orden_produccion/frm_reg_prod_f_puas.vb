Imports System.ComponentModel
Imports logicaNegocios

Public Class frm_reg_prod_f_puas
    Private obj_Ing_prodLn As New Ing_prodLn
    Private objOpsimpesLn As New Op_simpesLn
    Private nit As Double
    Dim numero_transaccion As Double
    Dim frm As frm_control_orden_puas
    Private mat_pri, mat_prima2 As String
    Private objOrdenProdLn As New OrdenProdLn
    Private objOpSimplesLn As New Op_simpesLn
    Dim objTraslado_bodLn As New traslado_bodLn
    Private peso As String = ""
    Dim causal As String
    Dim sFechaTransaccion As String = ""
    Dim centro As String = "6400"
    Dim registrado As Boolean = False
    Dim refe As String
    Dim maquin As String
    Dim cod_maq As String

    Public Sub main(ByVal ref As String, ByVal orden As Integer, ByVal nit_r As Double, ByVal matp As String, ByVal matp2 As String, ByVal maquina As String, ByVal codmq As String, ByVal frm As frm_control_orden_puas)
        Me.Text = ref & "-" & lbl_nombre.Text
        lbl_ref.Text = ref
        nit = nit_r
        maquin = maquina
        cod_maq = codmq
        Me.frm = frm
        mat_pri = matp
        mat_prima2 = matp2
        lbl_orden.Text = orden
        refe = ref
    End Sub
    Private Sub frm_reg_prod_f_puas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargar_datasource()
        lbl_nombre.Text = objOpsimpesLn.consultValorTodo("SELECT descripcion FROM referencias WHERE codigo='" & refe & "'", "CORSAN")
        txt_peso.Text = peso_Factor_Conversion()
        SerialPort1.Open()
        Timer1.Enabled = Enabled
    End Sub
    Private Sub cargar_datasource()
        Dim dt As New DataTable
        Dim row As DataRow
        Dim Sql As String
        dt = New DataTable
        Sql = "SELECT nit,nombres FROM V_nom_personal_Activo_con_maquila WHERE centro_planta in (2300,6400)  order by nombres"
        dt = obj_Ing_prodLn.listar_datatable(Sql, "CORSAN")
        row = dt.NewRow
        row("nit") = 0
        row("nombres") = "Seleccione"
        dt.Rows.Add(row)
        cbo_operario.DataSource = dt
        cbo_operario.ValueMember = "nit"
        cbo_operario.DisplayMember = "nombres"
        cbo_operario.SelectedValue = nit
        cbo_operario.Enabled = False


        cargar_Defectos(centro)

        Sql = "select Id_causal,D_causal from J_desperdicios_causal"
        dt = objOpsimpesLn.listar_datatable(Sql, "PRODUCCION")
        row = dt.NewRow
        row("Id_causal") = 0
        row("D_causal") = "TODO"
        dt.Rows.Add(row)
        cbo_causal.DataSource = dt
        cbo_causal.ValueMember = "Id_causal"
        cbo_causal.DisplayMember = "D_causal"
        cbo_causal.SelectedValue = 0



    End Sub
    Private Sub cargar_Defectos(ByVal centro_P As String)
        Dim dt As New DataTable
        Dim row As DataRow
        Dim Sql As String

        Sql = "SELECT d.Id_defecto,d.D_defecto " &
                        " FROM J_desperdicios_defecto d , J_desperdicio_def_centro c " &
                            "WHERE d.id_defecto = c.id_defecto AND c.centro =" & centro_P
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
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If (txt_indicador.TextLength >= 30) Then
            txt_indicador.Text = peso
        End If
        If SerialPort1.IsOpen Then
            peso = SerialPort1.ReadExisting
        End If
        txt_indicador.Text += peso
        capturarPeso()
    End Sub
    Private Function capturarPeso() As String
        Dim pesoFinal As String = ""
        Dim primerIgual As Boolean = False
        For i = 0 To txt_indicador.TextLength - 1
            If (txt_indicador.Text(i) = "+" Or primerIgual = True) Then
                If (primerIgual = False) Then
                    i += 1
                    primerIgual = True
                End If
                If (txt_indicador.Text(i) <> "+") Then
                    If (txt_indicador.Text(i) <> " ") Then
                        If (txt_indicador.Text(i) = "0") Then
                            If (pesoFinal.Length > 0) Then
                                pesoFinal += txt_indicador.Text(i)
                            End If
                        Else
                            If (txt_indicador.Text(i) <> "k") Then
                                If (txt_indicador.Text(i) <> "g") Then
                                    If (txt_indicador.Text(i) <> "S") Then
                                        If (txt_indicador.Text(i) <> "T") Then
                                            If (txt_indicador.Text(i) <> ",") Then
                                                If (txt_indicador.Text(i) <> "G") Then
                                                    If (txt_indicador.Text(i) <> "S") Then
                                                        If (txt_indicador.Text(i) <> ",") Then
                                                            If (txt_indicador.Text(i) <> "+") Then
                                                                If (txt_indicador.Text(i) <> "U") Then
                                                                    pesoFinal += txt_indicador.Text(i)
                                                                End If
                                                            End If
                                                        End If
                                                    End If
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                Else
                    i = txt_indicador.TextLength
                End If
            End If
        Next
        If (pesoFinal = "") Then
            Dim primerNumeroNoCero As Boolean = False
            For i = 0 To txt_indicador.Text.Length - 1
                If ((txt_indicador.Text(i) <> "0" And txt_indicador.Text(i) <> " ") Or primerNumeroNoCero = True) Then
                    primerNumeroNoCero = True
                    pesoFinal += txt_indicador.Text(i)
                End If
            Next
        End If
        If IsNumeric(pesoFinal) Then
            If pesoFinal > 0 Then
                txt_Peso_R.Text = pesoFinal
            Else
                txt_Peso_R.Text = ""
            End If
        Else
            txt_Peso_R.Text = ""
        End If
        Return pesoFinal
    End Function
    Private Sub btn_tiq_Click(sender As Object, e As EventArgs) Handles btn_tiq.Click
        If cbo_operario.SelectedValue <> 0 Then
            If IsNumeric(txt_peso.Text) Then
                reg_tiq(cbo_operario.SelectedValue, txt_peso.Text, lbl_ref.Text, lbl_orden.Text, mat_pri, mat_prima2)
            Else
                MessageBox.Show("El campo peso debe ser numerico", "Debe ser numerico", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Else
            MessageBox.Show("No hay un operario seleccionado", "Operario sin seleccionar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub
    Private Sub reg_tiq(ByVal operario As String, ByVal peso As Double, ByVal ref As String, ByVal orden As Integer, ByVal mat_prima As String, ByVal mat_prima2 As String)
        If validar_carga_rollo() Then
            'If guardar_trans_mp(txt_peso.Text) = True Then
            'If descontar_materia_prima(mat_pri, mat_prima2, txt_peso.Text) Then
            guardar_producto("")
            frm.cargar_dtg_mp()
            frm.cargar_producto(lbl_orden.Text)
            'End If
            'End If
            Me.Close()
        End If
    End Sub
    Private Function guardar_trans_mp(ByVal peso_p As Double) As Boolean
        Dim listSql As New List(Of Object)
        Dim peso As Double = 0
        Dim stock As Double = 0
        Dim costo_unit As Double
        Dim lleva As Double
        Dim resp As Boolean = False
        Dim sql As String = "Select peso_lleva from D_orden_prod_puas_cont_mp_prod where codigo='" & mat_pri & "'"
        lleva = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")

        Dim dt As New DataTable
        dt.Columns.Add("codigo")
        dt.Columns.Add("cantidad")
        dt.Rows.Add()
        dt.Rows(dt.Rows.Count - 1).Item("codigo") = mat_pri
        dt.Rows(dt.Rows.Count - 1).Item("cantidad") = peso

        For i = 0 To dt.Rows.Count - 1
            costo_unit = objOrdenProdLn.consultCostoUnit(dt.Rows(i).Item("codigo"))
        Next
        stock = Format((objOpSimplesLn.consultarStock(mat_pri, 2)), "#0.0")
        peso = Format((peso_p), "#0.0")

        If lleva >= peso Then
            If peso <= stock Then
                If mat_pri = "22G110246" And mat_prima2 = "22G110200" Then
                    listSql.AddRange(consumo_puas(mat_pri, calcular_consumo_doble(peso_p, mat_pri), "SPU", costo_unit))
                    listSql.AddRange(consumo_puas(mat_prima2, calcular_consumo_doble(peso_p, mat_prima2), "SPU", costo_unit))
                ElseIf mat_pri = "22G110200" And mat_prima2 = "22G110246" Then
                    listSql.AddRange(consumo_puas(mat_pri, calcular_consumo_doble(peso_p, mat_pri), "SPU", costo_unit))
                    listSql.AddRange(consumo_puas(mat_prima2, calcular_consumo_doble(peso_p, mat_prima2), "SPU", costo_unit))
                ElseIf mat_pri = "22G110155" And mat_prima2 = "22G110200" Then
                    listSql.AddRange(consumo_puas(mat_pri, calcular_consumo_doble(peso_p, mat_pri), "SPU", costo_unit))
                    listSql.AddRange(consumo_puas(mat_prima2, calcular_consumo_doble(peso_p, mat_prima2), "SPU", costo_unit))
                ElseIf mat_pri = "22G110200" And mat_prima2 = "22G110155" Then
                    listSql.AddRange(consumo_puas(mat_pri, calcular_consumo_doble(peso_p, mat_pri), "SPU", costo_unit))
                    listSql.AddRange(consumo_puas(mat_prima2, calcular_consumo_doble(peso_p, mat_prima2), "SPU", costo_unit))
                ElseIf mat_pri = "22G110150" And mat_prima2 = "22G110200" Then
                    listSql.AddRange(consumo_puas(mat_pri, calcular_consumo_doble(peso_p, mat_pri), "SPU", costo_unit))
                    listSql.AddRange(consumo_puas(mat_prima2, calcular_consumo_doble(peso_p, mat_prima2), "SPU", costo_unit))
                ElseIf mat_pri = "22G110200" And mat_prima2 = "22G110150" Then
                    listSql.AddRange(consumo_puas(mat_pri, calcular_consumo_doble(peso_p, mat_pri), "SPU", costo_unit))
                    listSql.AddRange(consumo_puas(mat_prima2, calcular_consumo_doble(peso_p, mat_prima2), "SPU", costo_unit))
                Else
                    listSql.AddRange(consumo_puas(mat_pri, peso, "SPU", costo_unit))
                End If
                If obj_Ing_prodLn.ExecuteSqlTransaction(listSql, "CORSAN") Then
                    resp = True
                End If
            Else
                MessageBox.Show("No hay stock en la orden,se debe leer mas MP.", "Más materia prima", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            MessageBox.Show("No hay suficiente Materia prima asignada para consumir.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        Return resp
    End Function
    Private Function guardar_trans_Desp(ByVal peso_p As Double) As Boolean
        Dim listSql As New List(Of Object)
        Dim peso As Double = 0
        Dim stock As Double = 0
        Dim costo_unit As Double
        Dim lleva As Double
        Dim resp As Boolean = False
        Dim sql As String = "Select peso_lleva from D_orden_prod_puas_cont_mp_prod where codigo='" & mat_pri & "'"
        lleva = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")

        Dim dt As New DataTable
        dt.Columns.Add("codigo")
        dt.Columns.Add("cantidad")
        dt.Rows.Add()
        dt.Rows(dt.Rows.Count - 1).Item("codigo") = mat_pri
        dt.Rows(dt.Rows.Count - 1).Item("cantidad") = peso

        For i = 0 To dt.Rows.Count - 1
            costo_unit = objOrdenProdLn.consultCostoUnit(dt.Rows(i).Item("codigo"))
        Next
        stock = Format((objOpSimplesLn.consultarStock(mat_pri, 2)), "#0.0")
        peso = Format((peso_p), "#0.0")

        If lleva >= peso Then
            If peso <= stock Then
                If mat_pri = "22G110246" And mat_prima2 = "22G110200" Then
                    listSql.AddRange(consumo_Desp(mat_pri, calcular_consumo_doble(peso_p, mat_pri), "SAI2", costo_unit))
                    listSql.AddRange(consumo_Desp(mat_prima2, calcular_consumo_doble(peso_p, mat_prima2), "SAI2", costo_unit))
                ElseIf mat_pri = "22G110200" And mat_prima2 = "22G110246" Then
                    listSql.AddRange(consumo_Desp(mat_pri, calcular_consumo_doble(peso_p, mat_pri), "SAI2", costo_unit))
                    listSql.AddRange(consumo_Desp(mat_prima2, calcular_consumo_doble(peso_p, mat_prima2), "SAI2", costo_unit))
                ElseIf mat_pri = "22G110155" And mat_prima2 = "22G110200" Then
                    listSql.AddRange(consumo_puas(mat_pri, calcular_consumo_doble(peso_p, mat_pri), "SAI2", costo_unit))
                    listSql.AddRange(consumo_puas(mat_prima2, calcular_consumo_doble(peso_p, mat_prima2), "SAI2", costo_unit))
                ElseIf mat_pri = "22G110200" And mat_prima2 = "22G110155" Then
                    listSql.AddRange(consumo_puas(mat_pri, calcular_consumo_doble(peso_p, mat_pri), "SAI2", costo_unit))
                    listSql.AddRange(consumo_puas(mat_prima2, calcular_consumo_doble(peso_p, mat_prima2), "SAI2", costo_unit))
                ElseIf mat_pri = "22G110150" And mat_prima2 = "22G110200" Then
                    listSql.AddRange(consumo_puas(mat_pri, calcular_consumo_doble(peso_p, mat_pri), "SAI2", costo_unit))
                    listSql.AddRange(consumo_puas(mat_prima2, calcular_consumo_doble(peso_p, mat_prima2), "SAI2", costo_unit))
                ElseIf mat_pri = "22G110200" And mat_prima2 = "22G110150" Then
                    listSql.AddRange(consumo_puas(mat_pri, calcular_consumo_doble(peso_p, mat_pri), "SAI2", costo_unit))
                    listSql.AddRange(consumo_puas(mat_prima2, calcular_consumo_doble(peso_p, mat_prima2), "SAI2", costo_unit))
                Else
                    listSql.AddRange(consumo_Desp(mat_pri, peso, "SAI2", costo_unit))
                End If
                If obj_Ing_prodLn.ExecuteSqlTransaction(listSql, "CORSAN") Then
                    resp = True
                End If
            Else
                MessageBox.Show("No hay stock en la orden,se debe leer mas MP.", "Más materia prima", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            MessageBox.Show("No hay suficiente Materia prima asignada para consumir.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        Return resp
    End Function
    Private Sub guardar_producto(ByVal conforme As String)
        Dim orden As Integer = CInt(lbl_orden.Text)
        Dim dt As New DataTable
        Dim consecu_rollo, sumconse As Integer
        Dim sql As String = "select max(consecutivo_rollo) from D_orden_prod_puas_producto where nro_orden=" & orden & ""
        Dim valor As String = objOpSimplesLn.consultValorTodo(sql, "PRODUCCION")
        If valor = "" Then
            sumconse = 1
        Else
            sumconse = CInt(valor) + 1
        End If
        consecu_rollo = sumconse
        Dim fecha_actual As String = "" & System.DateTime.Now.Day & "-" & System.DateTime.Now.Month & "-" & System.DateTime.Now.Year & " " & System.DateTime.Now.Hour & ":" & System.DateTime.Now.Minute & ":" & System.DateTime.Now.Second & ""
        Dim peso As Double = CDbl(txt_peso.Text)
        Dim diferencia As Double = 0
        Dim listTransaccion_puas As New List(Of Object)
        Dim tipo_trans As String
        Dim noconforme As String = conforme
        Dim bodega As String = objTraslado_bodLn.obtenerBodegaXcodigo(lbl_ref.Text)
        If bodega = "3" Then
            tipo_trans = "EPPT"
        ElseIf bodega = "2" Then
            tipo_trans = "EPPP"
        End If
        bodega = 2
        tipo_trans = "EPPP"
        Dim peso_prom As String = txt_Peso_R.Text
        Dim pesoreal As Double
        pesoreal = peso
        peso = 1
        If peso_prom <> "Peso" Then
            If IsNumeric(peso_prom) Then
                diferencia = peso_prom - pesoreal
                If diferencia < 0 Then
                    diferencia = diferencia * -1
                End If
            Else
                peso_prom = 0
            End If
        Else
            peso_prom = 0
        End If
        If noconforme <> "S" Then
#Disable Warning BC42104 ' La variable 'tipo_trans' se usa antes de que se le haya asignado un valor. Podría darse una excepción de referencia NULL en tiempo de ejecución.
            listTransaccion_puas.AddRange(transaccion(peso, lbl_ref.Text, tipo_trans, nit, bodega, orden, consecu_rollo))
#Enable Warning BC42104 ' La variable 'tipo_trans' se usa antes de que se le haya asignado un valor. Podría darse una excepción de referencia NULL en tiempo de ejecución.
            If obj_Ing_prodLn.ExecuteSqlTransaction(listTransaccion_puas, "CORSAN") Then
                sql = "INSERT INTO D_orden_prod_puas_producto " &
                          "(nro_orden,consecutivo_rollo,nit_operario,peso_real,peso_prom,diferencia,fecha_hora,maquina,tipo_trans,trans_puas) " &
                              "VALUES " &
                                      "(" & orden & "," & consecu_rollo & "," & nit & "," & pesoreal & "," & peso_prom & "," & diferencia & ",GETDATE() ,'" & maquin & "','" & tipo_trans & "'," & numero_transaccion & ")"
                obj_Ing_prodLn.ejecutar(sql, "PRODUCCION")
                registrado = True
                MessageBox.Show("rollo registrado correctamente", "Guardando registros", MessageBoxButtons.OK, MessageBoxIcon.Information)
                imprimirTiquete(consecu_rollo, noconforme)
                Me.Close()
            Else
                MessageBox.Show("rollo no fue registrado", "Guardando registros", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            peso = txt_Peso_R.Text
            tipo_trans = "EIPP"
            bodega = 4
            If mat_pri = "22G110246" And mat_prima2 = "22G110200" Then
                listTransaccion_puas.AddRange(transaccion(calcular_consumo_doble(peso, mat_pri), mat_pri, tipo_trans, nit, bodega, orden, consecu_rollo))
                listTransaccion_puas.AddRange(transaccion(calcular_consumo_doble(peso, mat_prima2), mat_pri, tipo_trans, nit, bodega, orden, consecu_rollo))
            ElseIf mat_pri = "22G110200" And mat_prima2 = "22G110246" Then
                listTransaccion_puas.AddRange(transaccion(calcular_consumo_doble(peso, mat_pri), mat_pri, tipo_trans, nit, bodega, orden, consecu_rollo))
                listTransaccion_puas.AddRange(transaccion(calcular_consumo_doble(peso, mat_prima2), mat_pri, tipo_trans, nit, bodega, orden, consecu_rollo))
            ElseIf mat_pri = "22G110155" And mat_prima2 = "22G110200" Then
                listTransaccion_puas.AddRange(transaccion(calcular_consumo_doble(peso, mat_pri), mat_pri, tipo_trans, nit, bodega, orden, consecu_rollo))
                listTransaccion_puas.AddRange(transaccion(calcular_consumo_doble(peso, mat_prima2), mat_pri, tipo_trans, nit, bodega, orden, consecu_rollo))
            ElseIf mat_pri = "22G110200" And mat_prima2 = "22G110155" Then
                listTransaccion_puas.AddRange(transaccion(calcular_consumo_doble(peso, mat_pri), mat_pri, tipo_trans, nit, bodega, orden, consecu_rollo))
                listTransaccion_puas.AddRange(transaccion(calcular_consumo_doble(peso, mat_prima2), mat_pri, tipo_trans, nit, bodega, orden, consecu_rollo))
            ElseIf mat_pri = "22G110150" And mat_prima2 = "22G110200" Then
                listTransaccion_puas.AddRange(transaccion(calcular_consumo_doble(peso, mat_pri), mat_pri, tipo_trans, nit, bodega, orden, consecu_rollo))
                listTransaccion_puas.AddRange(transaccion(calcular_consumo_doble(peso, mat_prima2), mat_pri, tipo_trans, nit, bodega, orden, consecu_rollo))
            ElseIf mat_pri = "22G110200" And mat_prima2 = "22G110150" Then
                listTransaccion_puas.AddRange(transaccion(calcular_consumo_doble(peso, mat_pri), mat_pri, tipo_trans, nit, bodega, orden, consecu_rollo))
                listTransaccion_puas.AddRange(transaccion(calcular_consumo_doble(peso, mat_prima2), mat_pri, tipo_trans, nit, bodega, orden, consecu_rollo))
            Else
                listTransaccion_puas.AddRange(transaccion(peso, mat_pri, tipo_trans, nit, bodega, orden, consecu_rollo))
            End If
            If obj_Ing_prodLn.ExecuteSqlTransaction(listTransaccion_puas, "CORSAN") Then
                sql = "INSERT INTO D_orden_prod_puas_producto " &
                       "(nro_orden,consecutivo_rollo,no_conforme,nit_operario,peso_real,peso_prom,diferencia,fecha_hora,maquina,tipo_trans,trans_puas) " &
                           "VALUES " &
                                   "(" & orden & "," & consecu_rollo & ",'" & noconforme & "'," & nit & "," & pesoreal & "," & peso_prom & "," & diferencia & ", GETDATE() ,'" & maquin & "','" & tipo_trans & "'," & numero_transaccion & ")"
                obj_Ing_prodLn.ejecutar(sql, "PRODUCCION")
                MessageBox.Show("rollo no conforme registrado correctamente", "Guardando registros", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Dim result As DialogResult
                result = MessageBox.Show("Desea generar tiquete para el no conforme?", "Generar tiquete", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                If result = vbYes Then
                    imprimirTiquete(consecu_rollo, noconforme)
                End If
            Else
                MessageBox.Show("No conforme no registrado", "Registrando no conforme", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Me.Close()
        End If
    End Sub
    Private Sub imprimirTiquete(ByVal consecu_rollo As Integer, ByVal noconforme As String)
        Dim proc As New Process
        Dim s_fec As String = Now.Year & "-" & Now.Month & "-" & Now.Day & ""
        Dim fec_c, turno As String
        fec_c = "" & System.DateTime.Now.Hour & ":" & System.DateTime.Now.Minute & ""

        If CDate(fec_c) >= "6:00" And CDate(fec_c) <= "14:00" Then
            turno = "1"
        ElseIf CDate(fec_c) >= "14:00" And CDate(fec_c) <= "22:00" Then
            turno = "2"
        ElseIf CDate(fec_c) >= "22:00" And CDate(fec_c) <= "6:00" Then
            turno = "3"
        End If
#Disable Warning BC42104 ' La variable 'turno' se usa antes de que se le haya asignado un valor. Podría darse una excepción de referencia NULL en tiempo de ejecución.
        modificarPlantilla(consecu_rollo, noconforme, s_fec, turno)
#Enable Warning BC42104 ' La variable 'turno' se usa antes de que se le haya asignado un valor. Podría darse una excepción de referencia NULL en tiempo de ejecución.
        If noconforme <> "S" Then
            proc.StartInfo.FileName = Environment.CurrentDirectory & "\diseñopuasfuncional.txt"
        Else
            proc.StartInfo.FileName = Environment.CurrentDirectory & "\diseñopuasfuncional.txt"
        End If
        proc.StartInfo.Verb = "Print"
        proc.StartInfo.CreateNoWindow = False
        proc.Start()
    End Sub
    'Obtiene el factor de conversión del producto final para realizar la transaccion
    Private Function peso_Factor_Conversion()
        Dim Sql As String = "select conversion from referencias where codigo='" & lbl_ref.Text & "'"
        peso = objOpsimpesLn.consultValorTodo(Sql, "CORSAN")
        Return peso
    End Function
    Private Sub modificarPlantilla(ByVal conse As Integer, ByVal noconforme As String, ByVal fecha As String, ByVal turno As String)
        Dim fic As String
        Dim nuevoFic As String
        fic = Environment.CurrentDirectory & "\diseñopuas.txt"
        nuevoFic = Environment.CurrentDirectory & "\diseñopuasfuncional.txt"

        Dim sw As New System.IO.StreamWriter(nuevoFic)
        Dim texto As String
        Dim sr As New System.IO.StreamReader(fic)
        texto = sr.ReadToEnd()

        texto = Replace(texto, "@fecha", fecha)
        texto = Replace(texto, "@turno", "T:" & turno)
        texto = Replace(texto, "@orden", lbl_orden.Text & "-" & conse)
        texto = Replace(texto, "@barras", lbl_orden.Text & "-" & conse)

        'Else
        '    texto = Replace(texto, "@Operario", nomb_operario)
        '    texto = Replace(texto, "@Descripcion", "CHATARRA")
        '    texto = Replace(texto, "@Peso", peso & " (Kg)")
        '    texto = Replace(texto, "@Bobina", bobina)
        '    texto = Replace(texto, "@FECHA", fechar)
        '    texto = Replace(texto, "@Nit", "OPERARIO")
        '    texto = Replace(texto, "@Prod", codigor)
        '    texto = Replace(texto, "@Planta", "GALVANIZADO")
        '    texto = Replace(texto, "@MAT", m_prima)
        sr.Close()
        sw.WriteLine(texto)
        sw.Close()

    End Sub
    Private Function validar_carga_rollo() As Boolean
        Using New Centered_MessageBox(Me)
            If txt_peso.Text <> "" Then
                Return True
            Else
                MessageBox.Show("Campo peso vacio", "Peso no ingresado", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Using
        Return False
    End Function
    Private Function transaccion(ByVal PESO As Double, ByVal codigo As String, ByVal tipo As String, ByVal usuario_g As String, ByVal bodega As Integer, ByVal orden As Integer, ByVal consecutivo As Integer) As List(Of Object)
        Dim listSql As New List(Of Object)
        Dim dFec As Date = Now
        Dim usuario As String = usuario_g
        Dim fecha_hora As String
        Dim modelo As String = "01"
        Dim notas As String = "SPIC fecha:" & Now & " usuario:" & usuario
        If Len(usuario) > 10 Then
            notas = "SPIC fecha:" & Now & " usuario:Extranjero"
        End If
        If (objOrdenProdLn.insertarProxMes(codigo)) Then
            dFec = dFec.AddMonths(1)
            fecha_hora = "" & System.DateTime.Now.Month + 1 & "-" & "01" & "-" & System.DateTime.Now.Year & " " & System.DateTime.Now.Hour & ":" & System.DateTime.Now.Minute & ":" & System.DateTime.Now.Second & ""
            sFechaTransaccion = dFec.Year & "-" & dFec.Month & "-01"
        Else
            fecha_hora = "" & System.DateTime.Now.Month & "-" & System.DateTime.Now.Day & "-" & System.DateTime.Now.Year & " " & System.DateTime.Now.Hour & ":" & System.DateTime.Now.Minute & ":" & System.DateTime.Now.Second & ""
            sFechaTransaccion = dFec.Year & "-" & dFec.Month & "-" & dFec.Day
        End If
        numero_transaccion = objOrdenProdLn.mover_consecutivo(tipo)
        listSql = objOrdenProdLn.ingProdDms(PESO, codigo, bodega, dFec, notas, usuario, 0, 0, "G", numero_transaccion, tipo, sFechaTransaccion, fecha_hora)
        Return listSql
    End Function
    Private Function consumo_puas(ByVal codigo As String, ByVal cantidad As Double, ByVal tipo As String, ByVal costo_unit As Double) As List(Of Object)
        Dim listSql As New List(Of Object)
        Dim dFec As Date = Now
        Dim usuario As String = nit
        Dim notas As String = "SPIC fecha:" & Now & " usuario:" & usuario
        If Len(usuario) > 10 Then
            notas = "SPIC fecha:" & Now & " usuario:Extranjero"
        End If
        numero_transaccion = objOrdenProdLn.mover_consecutivo(tipo)
        listSql = objTraslado_bodLn.transaccion_Puas(cantidad, codigo, 2, dFec, notas, usuario, tipo, costo_unit, numero_transaccion)
        Return listSql
    End Function
    Private Function consumo_Desp(ByVal codigo As String, ByVal cantidad As Double, ByVal tipo As String, ByVal costo_unit As Double) As List(Of Object)
        Dim listSql As New List(Of Object)
        Dim dFec As Date = Now
        Dim usuario As String = nit
        Dim notas As String = "SPIC fecha:" & Now & " usuario:" & usuario
        If Len(usuario) > 10 Then
            notas = "SPIC fecha:" & Now & " usuario:Extranjero"
        End If
        numero_transaccion = objOrdenProdLn.mover_consecutivo(tipo)
        listSql = objTraslado_bodLn.transaccion_Desp(cantidad, codigo, 2, dFec, notas, usuario, tipo, costo_unit, numero_transaccion)
        Return listSql
    End Function
    Private Function calcular_consumo_doble(ByVal peso As String, ByVal codigo As String)
        Dim peso_matp1, peso_matp2 As Double
        peso_matp1 = ((peso * 80.15) / 100)
        peso_matp2 = ((peso * 19.85) / 100)
        If codigo = "22G110246" Or codigo = "22G110200" Then
            Return peso_matp1
        Else
            Return peso_matp2
        End If
    End Function

    Private Function validarcargaderollo() As Boolean
        Using New Centered_MessageBox(Me)
            If txt_peso.Text <> "" And IsNumeric(txt_peso.Text) Then
                Return True
            Else
                MessageBox.Show("peso vacio", "peso no asignado", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Using
        Return False
    End Function
    'Private Function validar_materia_prima_doble()
    '    Dim sw As Boolean = True
    '    Dim sql = "select e.final_galv from  D_orden_pro_galv_enc e join D_rollo_galvanizado_f d on e.consecutivo_orden_G=d.nro_orden where spu=" & lbl_orden.Text & " and e.final_galv='22G110246'"
    '    Dim val As String
    '    val = objOpsimpesLn.consultValorTodo(sql, "PRODUCCION")
    '    If val = "" Then
    '        sw = False
    '    End If
    '    sql = "select e.final_galv from  D_orden_pro_galv_enc e join D_rollo_galvanizado_f d on e.consecutivo_orden_G=d.nro_orden where spu=" & lbl_orden.Text & " and e.final_galv='22G110200'"
    '    val = objOpsimpesLn.consultValorTodo(sql, "PRODUCCION")
    '    If val = "" Then
    '        sw = False
    '    End If
    '    Return sw
    'End Function
    Private Sub guardar_desperdicio(ByVal no_conforme As String, ByVal peso_r As String)
        Dim mypeso() As Char = {"?", "", ".", "*", "=", "¿", "'", "-"}
        Dim rpeso As String = peso_r
        Dim peso As String = rpeso.Trim(mypeso)
        Dim listSql As New List(Of Object)
        Dim tipo As Integer = 0
        Dim causal As Integer = 0
        Dim defecto As Integer = 0
        Dim operario As String = nit
        Dim fecha As String = ""
        If (Now.Hour >= 0 And Now.Hour <= 5) Then
            fecha = objOpsimpesLn.cambiarFormatoFecha((Now.AddDays(-1)).Date)
        Else
            fecha = objOpsimpesLn.cambiarFormatoFecha(Now.Date)
        End If
        If peso = "" Then
            peso = "0"
        End If
        tipo = 6
        causal = cbo_causal.SelectedValue
        defecto = cbo_defecto.SelectedValue
        Dim kilos As Double = CDbl(peso)

        listSql.AddRange(sql_ing_desperdicios(fecha, operario, kilos, tipo, causal, defecto))
        If (objOpsimpesLn.ExecuteSqlTransactionTodo(listSql, "PRODUCCION")) Then
            cbo_defecto.SelectedValue = 0
            pn_desperdicios.Visible = False
        End If
    End Sub
    Private Function sql_ing_desperdicios(ByVal fecha As String, ByVal nit As Double, ByVal kilos As Double, ByVal tipo As Integer, ByVal causal As Integer, ByVal defecto As Integer)
        Dim listSql As New List(Of Object)
        Dim id_existente As Integer = 0
        Dim sql_descripcion As String = "select descripcion from referencias where ref_anulada='n' and capa is not null AND codigo='" & lbl_ref.Text & "'"
        Dim descripcion As String = objOpsimpesLn.consultValorTodo(sql_descripcion, "CORSAN")
        Dim observaciones As String = maquin & "-" & descripcion
        Dim destino As Integer = 1 ' para que todo lo lleve a Contenerdor Metalicos 
        listSql.AddRange(obj_Ing_prodLn.guardar_desperdicio(fecha, nit, centro, kilos, tipo, causal, defecto, observaciones, id_existente, destino, maquin))
        Return listSql
    End Function
    Private Sub btn_noconforme_Click(sender As Object, e As EventArgs) Handles btn_noconforme.Click
        Dim result As MsgBoxResult
        result = MessageBox.Show("Desea registrar este rollo como no conforme?", "Registrar como no conforme", MessageBoxButtons.YesNo, MessageBoxIcon.Error)
        If result = MsgBoxResult.Yes Then
            Dim orden As String = lbl_orden.Text
            If validar_carga_rollo() Then
                'If guardar_trans_mp(txt_Peso_R.Text) = True Then
                'If descontar_materia_prima(mat_pri, mat_prima2, txt_Peso_R.Text) Then
                guardar_producto("S")
                frm.cargar_dtg_mp()
                frm.cargar_producto(lbl_orden.Text)
                'End If
                Me.Close()
                'End If
            End If
        Else
        End If
    End Sub
    Private Sub btnchatarra_Click(sender As Object, e As EventArgs) Handles btnchatarra.Click
        pn_causal.Visible = True
    End Sub
    Private Sub btn_cerrar_chat_Click(sender As Object, e As EventArgs) Handles btn_cerrar_chat.Click
        pn_desperdicios.Visible = False
    End Sub
    Private Sub btn_cerrar2_Click(sender As Object, e As EventArgs) Handles btn_cerrar2.Click
        pn_causal.Visible = False
    End Sub
    Private Sub btn_ok_causal_Click(sender As Object, e As EventArgs) Handles btn_ok_causal.Click
        If cbo_causal.Text <> "TODO" Then
            causal = cbo_causal.SelectedValue
            Dim result As MsgBoxResult
            result = MessageBox.Show("Es chatarra de producto final:Si,chatarra de materia prima:No", "Selección", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
            If result = vbYes Then
                centro = 6400
                cargar_Defectos(centro)
            Else
                centro = 5200
                cargar_Defectos(centro)
            End If
            pn_desperdicios.Visible = True
            pn_causal.Visible = False
        Else
            MessageBox.Show("Seleccione un causal para el no conforme o desperdicio", "Seleccionar causal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
    Private Sub btn_chatarra_Click(sender As Object, e As EventArgs) Handles btn_chatarra.Click
        If My.Computer.Network.IsAvailable Then
            If validarcargaderollo() Then
                If cbo_defecto.SelectedValue <> 0 Then
                    Dim result As MsgBoxResult
                    If centro = "5200" Then
                        result = MessageBox.Show("La chatarra es de solo una referencia Si o No?", "Selección", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                        If result = vbNo Then
                            Dim referenciasql As String
                            Dim refdes, refdes2 As String
                            referenciasql = "SELECT descripcion from referencias WHERE codigo='" & mat_pri & "'"
                            refdes = objOpsimpesLn.consultValorTodo(referenciasql, "CORSAN")
                            referenciasql = "SELECT descripcion from referencias WHERE codigo='" & mat_prima2 & "'"
                            refdes2 = objOpsimpesLn.consultValorTodo(referenciasql, "CORSAN")
                            result = MessageBox.Show("La chatarra es de " & refdes & ":Si o " & refdes2 & ":No", "Selección", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                            If result = vbYes Then
                                mat_prima2 = mat_pri
                            Else
                                mat_pri = mat_prima2
                            End If
                        End If
                    End If

                    'If guardar_trans_Desp(txt_Peso_R.Text) = True Then
                    'If descontar_materia_prima(mat_pri, mat_prima2, txt_Peso_R.Text) Then
                    Dim noconforme As String
                    noconforme = "S"
                    guardar_desperdicio(noconforme, txt_Peso_R.Text)
                    noconforme = ""
                    MessageBox.Show("El desperdicio fue registrado", "Desperdicio registrado", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Close()
                    'End If
                    'End If
                Else
                    MessageBox.Show("Seleccione tipo de defecto", "Seleccione tipo de defecto", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End If
        Else
            MessageBox.Show("El computador no esta conectado a la red", "No Conectado", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End If
    End Sub
    Private Function descontar_materia_prima(ByVal codigo As String, ByVal codigo2 As String, ByVal peso As Double) As Double
        Dim resp As Boolean = False
        Dim resp_Mp_D As Boolean = False
        Dim sql As String = "Select peso_lleva from D_orden_prod_puas_cont_mp_prod where codigo='" & codigo & "'"
        Dim val As String = objOpsimpesLn.consultValorTodo(sql, "PRODUCCION")
        Dim val2 As String = ""
        If codigo <> codigo2 Then
            resp_Mp_D = True
            sql = "select peso_lleva from D_orden_prod_puas_cont_mp_prod where codigo='" & codigo2 & "'"
            val2 = objOpsimpesLn.consultValorTodo(sql, "PRODUCCION")
        End If
        Dim peso_lleva As Double
        If resp_Mp_D = False Then
            If val <> "" Then
                peso_lleva = CDbl(val)
                If peso <= peso_lleva Then
                    sql = "UPDATE D_orden_prod_puas_cont_mp_prod SET  peso_lleva -=" & peso & " where codigo='" & codigo & "'"
                    objOpsimpesLn.ejecutar(sql, "PRODUCCION")
                    resp = True
                Else
                    MessageBox.Show("El control del stock no puede quedar negativo", "Control no puede quedar negativo", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    resp = False
                End If
            Else
                resp = False
                MessageBox.Show("No hay materia prima disponible", "Sin materia prima disponible", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            If val <> "" And val2 <> "" Then
                Dim peso_lleva2 As Double
                Dim pesomp1, pesomp2 As Double
                peso_lleva = CDbl(val)
                peso_lleva2 = CDbl(val2)
                pesomp1 = calcular_consumo_doble(peso, codigo)
                pesomp2 = calcular_consumo_doble(peso, codigo2)
                If (pesomp1 <= peso_lleva) And (pesomp2 <= peso_lleva2) Then
                    sql = "UPDATE D_orden_prod_puas_cont_mp_prod SET  peso_lleva -=" & pesomp1 & " where codigo='" & codigo & "'"
                    objOpsimpesLn.ejecutar(sql, "PRODUCCION")
                    sql = "UPDATE D_orden_prod_puas_cont_mp_prod SET  peso_lleva -=" & pesomp2 & " where codigo='" & codigo2 & "'"
                    objOpsimpesLn.ejecutar(sql, "PRODUCCION")
                    resp = True
                Else
                    MessageBox.Show("El control del stock no puede quedar negativo", "Control no puede quedar negativo", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    resp = False
                End If
            Else
                resp = False
                MessageBox.Show("No hay materia prima disponible", "Sin materia prima disponible", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
        Return resp
    End Function
    Private Sub tool_planilla_Click(sender As Object, e As EventArgs) Handles tool_planilla.Click
        Dim frm As New frm_planilla_inspeccion
        frm.main(lbl_orden.Text, registrado, txt_peso.Text)
        frm.Show()
    End Sub
    Private Sub frm_reg_prod_f_puas_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        SerialPort1.Close()
    End Sub
End Class