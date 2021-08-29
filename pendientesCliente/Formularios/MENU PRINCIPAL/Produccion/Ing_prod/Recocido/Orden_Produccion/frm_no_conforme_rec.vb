Imports logicaNegocios
Imports accesoDatos
Imports entidadNegocios
Public Class frm_no_conforme_rec
    Private obj_Ing_prodLn As New Ing_prodLn
    Private objOpsimpesLn As New Op_simpesLn
    Private objOrdenProdLn As New OrdenProdLn
    Dim objTraslado_bodLn As New traslado_bodLn
    Dim peso As String
    Dim peso_c As String
    Dim numero_transaccion As Double

    Private Sub frm_no_conforme_rec_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargar_cbo()
        SerialPort1.Open()
        Timer1.Enabled = True
    End Sub
    Private Sub cargar_cbo()
        Dim dt As New DataTable
        Dim row As DataRow
        Dim sql As String
        sql = "select d.num, r.codigo from JB_orden_prod_rec_refs d  join corsan.dbo.referencias r on d.prod_final=r.codigo where r.ref_anulada = 'N' AND d.cod_orden=0 ORDER BY NUM"
        dt = New DataTable
        dt = obj_Ing_prodLn.listar_datatable(sql, "PRODUCCION")
        row = dt.NewRow
        row("num") = 0
        row("codigo") = "Seleccione"
        dt.Rows.Add(row)
        cbo_codigo.DataSource = dt
        cbo_codigo.ValueMember = "num"
        cbo_codigo.DisplayMember = "codigo"
        cbo_codigo.SelectedValue = 0
    End Sub
    Private Function validar_campos()
        Dim resp As Boolean = False
        If cbo_codigo.Text <> "Seleccione" Then
            If IsNumeric(txt_traccion.Text) And txt_traccion.Text <> "" Then
                If IsNumeric(txt_colada.Text) And txt_colada.Text <> "" Then
                    If IsNumeric(txt_diametro.Text) And txt_diametro.Text <> "" Then
                        If IsNumeric(txt_calidad.Text) And txt_calidad.Text <> "" Then
                            resp = True
                        Else
                            MessageBox.Show("El campo de calidad debe tener algun valor y debe ser numerico", "Ingresar calidad", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        End If
                    Else
                        MessageBox.Show("El campo de diametro debe tener algun valor y debe ser numerico", "Ingresar diametro", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    End If
                Else
                    MessageBox.Show("El campo de colada debe tener algun valor y debe ser numerico", "Ingresar colada", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If
            Else
                MessageBox.Show("El campo de tracción debe tener algun valor y debe ser numerico", "Ingresar tracción", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
        Else
            MessageBox.Show("Debe seleccionar una referencia", "Seleccione referencia", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
        Return resp
    End Function
    Private Sub btn_generar_noconforme_Click(sender As Object, e As EventArgs) Handles btn_generar_noconforme.Click
        If validar_campos() Then
            generar_trans_tiquete()
        End If
    End Sub
    Private Sub generar_trans_tiquete()
        Dim listransaccion As New List(Of Object)
        Dim codigo As String = cbo_codigo.Text
        Dim traccion As Integer = txt_traccion.Text
        Dim diametro As Integer = txt_diametro.Text
        Dim calidad As Integer = txt_calidad.Text
        Dim colada As String = txt_colada.Text
        Dim mypeso() As Char = {"?", "", ".", "*", "=", "¿", "'", "-", "S", "T", "G", ",", "+", "k", "g", "U", "Kg", """"}
        Dim peso As String = peso_c
        Dim orden_recocido As String = "0"
        Dim detalle_recocido As String = "0"
        Dim sql As String = "select max(id_rollo_rec) from JB_rollos_rec where cod_orden_rec=0 and  id_detalle_rec=0"
        Dim obt_ult_consu As String = objOpsimpesLn.consultValorTodo(sql, "PRODUCCION")
        If obt_ult_consu = "" Then
            obt_ult_consu = "0"
        End If
        Dim ult_conse As Integer = CInt(obt_ult_consu) + 1
        Dim cod_orden_tref As String = "0"
        Dim id_detalle_tref As String = "0"
        Dim tipo As String = "EIPP"
        Dim bodega As String = 2
        Dim modelo As String = "03"
        Dim dt As New DataTable

        dt.Columns.Add("codigo")
        dt.Columns.Add("cantidad")
        dt.Rows.Add()
        dt.Rows(dt.Rows.Count - 1).Item("codigo") = codigo
        dt.Rows(dt.Rows.Count - 1).Item("cantidad") = peso

        listransaccion.AddRange(transaccion_eipp(dt, tipo, bodega, modelo, "8909001601"))
        Dim trans_eipp As String = numero_transaccion

        sql = "INSERT INTO JB_rollos_rec (cod_orden_tref,id_detalle_tref,id_rollo_tref,cod_orden_rec,id_detalle_rec,id_rollo_rec,id_prof_final,peso,traccion_rec,traccion_tref,colada,diametro,clase,no_conforme,eipp) VALUES (" & _
           cod_orden_tref & "," & id_detalle_tref & "," & ult_conse & "," & orden_recocido & "," & detalle_recocido & "," & ult_conse & "," & cbo_codigo.SelectedValue & "" & _
           "," & peso & ",0," & traccion & ",'" & colada & "'," & diametro & "," & calidad & ",'S'," & trans_eipp & ")"

        If obj_Ing_prodLn.ExecuteSqlTransaction(listransaccion, "CORSAN") Then
            If objOpsimpesLn.ejecutar(sql, "PRODUCCION") Then
                consultar_datos_impresion(orden_recocido, detalle_recocido, ult_conse, "8909001601", codigo, traccion, diametro, calidad, colada)
            Else
                MessageBox.Show("Fallo al guardar el rollo", "Seleccione referencia", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            MessageBox.Show("Fallo al realizar la transaccion", "Seleccione referencia", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim peso As String = ""
        If (txt_peso.TextLength >= 23) Then
            txt_peso.Text = peso
        End If
        If SerialPort1.IsOpen Then
            peso = SerialPort1.ReadExisting
        End If
        txt_peso.Text += peso
        capturarPeso()
        SoloNumeros(txt_peso.Text)
    End Sub
    Private Function capturarPeso() As String
        Dim pesoFinal As String = ""
        Dim primerIgual As Boolean = False
        For i = 0 To txt_peso.TextLength - 1
            If (txt_peso.Text(i) = "+" Or primerIgual = True) Then
                If (primerIgual = False) Then
                    i += 1
                    primerIgual = True
                End If
                If (txt_peso.Text(i) <> "+") Then
                    If (txt_peso.Text(i) <> " ") Then
                        If (txt_peso.Text(i) = "0") Then
                            If (pesoFinal.Length > 0) Then
                                pesoFinal += txt_peso.Text(i)
                            End If
                        Else
                            If (txt_peso.Text(i) <> "k") Then
                                If (txt_peso.Text(i) <> "g") Then
                                    If (txt_peso.Text(i) <> "S") Then
                                        If (txt_peso.Text(i) <> "T") Then
                                            If (txt_peso.Text(i) <> ",") Then
                                                If (txt_peso.Text(i) <> "G") Then
                                                    If (txt_peso.Text(i) <> "S") Then
                                                        If (txt_peso.Text(i) <> ",") Then
                                                            If (txt_peso.Text(i) <> "+") Then
                                                                pesoFinal += txt_peso.Text(i)
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
        If IsNumeric(pesoFinal) Then
            If pesoFinal > 0 Then
                peso_c = pesoFinal
            Else
                peso_c = ""
            End If
        Else
            peso_c = ""
        End If
        Return pesoFinal
    End Function
    Private Function transaccion_eipp(ByVal datacodigo As DataTable, ByVal tipo As String, ByVal bodega As Integer, ByVal modelo As String, ByVal usuario As String) As List(Of Object)
        Dim listSql As New List(Of Object)
        Dim dFec As Date = Now
        Dim notas As String = "SPIC fecha:" & Now & " usuario:" & usuario
        numero_transaccion = objOrdenProdLn.mover_consecutivo(tipo)
        listSql = objTraslado_bodLn.listaTransaccionDatable(numero_transaccion, datacodigo, bodega, dFec, notas, usuario, tipo, modelo)
        Return listSql
    End Function
    Public Sub consultar_datos_impresion(ByVal cod_orden As Integer, ByVal id_detalle As Integer, ByVal id_rollo As Integer, ByVal operario As String, ByVal codigo As String, ByVal traccion As String, ByVal diametro As String, ByVal calidad As String, ByVal colada As String)
        Dim consecutivo_barras As String = cod_orden & "-" & id_detalle & "-" & id_rollo
        Dim destino As String = "NO CONFORME"
        Dim sql As String
        sql = "Select descripcion from referencias where codigo='" & codigo & "'"
        Dim descripcion As String = objOpsimpesLn.consultValorTodo(sql, "CORSAN")
        imprimirTiquete(descripcion, operario, codigo, calidad, diametro, codigo, colada, traccion, traccion, peso, Now, consecutivo_barras, destino & "")
    End Sub
     Public Function SoloNumeros(ByVal strCadena As String) As Object
        Dim SoloNumero As String = ""
        Dim index As Integer
        For index = 1 To Len(strCadena)
            If (Mid$(strCadena, index, 1) Like "#") Or (Mid$(strCadena, index, 1) Like ".") Then
                SoloNumero = SoloNumero & Mid$(strCadena, index, 1)
            End If
        Next
        peso_c = SoloNumero
        Return SoloNumero
    End Function
    Private Sub imprimirTiquete(ByVal nomb_pf As String, ByVal operario As String, ByVal prod_f As String, ByVal clase As String, ByVal diametro As String, ByVal materia_p As String,
                            ByVal colada As String, ByVal traccion As Integer, ByVal traccionr As Integer, ByVal pesoref As Double, ByVal fecha As Date, ByVal consecutivo_barras As String, ByVal destino As String)
        Dim proc As New Process
        modificarPlantilla(nomb_pf, operario, prod_f, clase, diametro, materia_p, colada, traccion, traccionr, pesoref, fecha, consecutivo_barras, destino)
        proc.StartInfo.FileName = Environment.CurrentDirectory & "\plantillaRecocidoImp.txt"
        proc.StartInfo.Verb = "Print"
        proc.StartInfo.CreateNoWindow = False
        proc.Start()
    End Sub
    Private Sub modificarPlantilla(ByVal nomb_pf As String, ByVal operario As String, ByVal prod_f As String, ByVal clase As String, ByVal diametro As String, ByVal materia_p As String,
                               ByVal colada As String, ByVal traccion As Integer, ByVal traccionr As Integer, ByVal pesoref As Double, ByVal fecha As Date, ByVal consecutivo_barras As String, ByVal destino As String)
        Dim fic As String
        Dim nuevoFic As String
        fic = Environment.CurrentDirectory & "\plantillaRecocido.txt"
        nuevoFic = Environment.CurrentDirectory & "\plantillaRecocidoImp.txt"
        Dim pesoimp As Double = Format(peso_c, "#0.0")
        Dim sw As New System.IO.StreamWriter(nuevoFic)
        Dim texto As String
        Dim sr As New System.IO.StreamReader(fic)
        texto = sr.ReadToEnd()
        texto = Replace(texto, "@alambre", nomb_pf)
        texto = Replace(texto, "@operario", operario)
        texto = Replace(texto, "@ref", prod_f)
        texto = Replace(texto, "@clase", clase)
        texto = Replace(texto, "@diametro", diametro & "(mm)")
        texto = Replace(texto, "@mp", materia_p)
        texto = Replace(texto, "@colada", colada)
        texto = Replace(texto, "@traccionb", traccion)
        texto = Replace(texto, "@traccionr", traccionr)
        texto = Replace(texto, "@peso", pesoimp & "(Kg)")
        texto = Replace(texto, "@fecha", fecha)
        texto = Replace(texto, "@ordenr", consecutivo_barras)
        texto = Replace(texto, "@destino", destino)
        texto = Replace(texto, "@barras", consecutivo_barras)
        sr.Close()
        sw.WriteLine(texto)
        sw.Close()
    End Sub
End Class