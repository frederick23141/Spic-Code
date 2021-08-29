Imports logicaNegocios
Imports entidadNegocios
Public Class frm_generar_tiquete
    Dim obj_Ing_prodLn As New Ing_prodLn
    Dim objOpsimpesLn As New Op_simpesLn
    Dim objTraslado_bodLn As New traslado_bodLn
    Private objOrdenProdLn As New OrdenProdLn
    Dim sql As String
    Dim val As String
    Dim nro_orden As Integer
    Dim nro_plan As Integer
    Dim numero_transaccion As Double
    Dim nomb_oper As String
    Dim nit_operario As String
    Dim nc As String
    Dim result As MsgBoxResult
    Public Sub main(ByVal nro_ordenn As Integer, ByVal id_planilla As Integer, ByVal nomb_oeprario As String, ByVal nit As String)
        If nro_orden = 0 And id_planilla = 0 Then
            txt_nro_orden.Enabled = True
            txt_nro_plani.Enabled = True
        End If
        nro_orden = nro_ordenn
        nro_plan = id_planilla
        txt_nro_orden.Text = nro_orden
        txt_nro_plani.Text = nro_plan
        nomb_oper = nomb_oeprario
        nit_operario = nit
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim listransaccion As New List(Of Object)
        Dim Fecha As String = objOpsimpesLn.cambiarFormatoFecha(Now.Date)
        Dim producto As String
        Dim cod_mat_prima As String
        Dim calidad As String
        Dim destinoDesc As String
        Dim result As MsgBoxResult
        result = MessageBox.Show("Tipo de tiquete a imprimir:Tiquete unico responda:si o Tiquete de lote:responda:no?", "Impresión de tiquete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If result = vbYes Then
            If validar_campos_rollo() Then
                Dim peso As Double = txt_peso.Text
                Dim traccion As Double = txt_tracc.Text
                Dim calibre As Double = txt_calibre.Text
                Dim colada As String = txtcolada.Text
                Dim tipo As String = "EIPP"
                Dim bodega As String = 2
                Dim modelo As String = "03"
                Dim dt As New DataTable
                nro_orden = CInt(txt_nro_orden.Text)
                nro_plan = CInt(txt_nro_plani.Text)
                sql = "select max(id_rollo)+1 from J_rollos_tref where cod_orden = " & nro_orden & " and id_detalle =" & nro_plan & ""
                val = obj_Ing_prodLn.consultar_valor(sql, "PRODUCCION")
                If CInt(val) > "0" Then
                    result = MessageBox.Show("Deseas registrar un rollo manual o un no conforme 1-Si:No conforme 2-No:Manual?", "Tiquete manual o no conforme", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                    sql = "select materia_prima from J_orden_prod_tef where consecutivo=" & nro_orden & ""
                    cod_mat_prima = obj_Ing_prodLn.consultar_valor(sql, "PRODUCCION")
                    sql = "select calidad from J_orden_prod_tef where consecutivo=" & nro_orden & ""
                    calidad = obj_Ing_prodLn.consultar_valor(sql, "PRODUCCION")
                    ''sql = "select d.descripcion from J_orden_prod_tef t, J_destino_tref d where t.tipoCliente=d.codigo and consecutivo=" & nro_orden & ""
                    destinoDesc = txt_clientes.Text
                    sql = "select prod_final from J_orden_prod_tef where consecutivo=" & nro_orden & ""
                    producto = obj_Ing_prodLn.consultar_valor(sql, "PRODUCCION")
                    If result = vbYes Then
                        GuardarRollo(peso, CInt(val), colada, "", "", traccion)
                        dt.Columns.Add("codigo")
                        dt.Columns.Add("cantidad")
                        dt.Rows.Add()
                        dt.Rows(dt.Rows.Count - 1).Item("codigo") = producto
                        dt.Rows(dt.Rows.Count - 1).Item("cantidad") = peso
                        listransaccion.AddRange(transaccion_eipp(dt, tipo, bodega, modelo, nit_operario))
                        Dim trans_eipp As String = numero_transaccion
                        sql = "update J_rollos_tref set no_conforme=" & trans_eipp & " where cod_orden=" & nro_orden & " and id_detalle=" & nro_plan & " and id_rollo=" & val & ""
                        obj_Ing_prodLn.ejecutar(sql, "PRODUCCION")
                        obj_Ing_prodLn.ExecuteSqlTransaction(listransaccion, "CORSAN")
                        imprimirTiquete(peso, CInt(val), calibre, calidad, nomb_oper, Fecha, producto, destinoDesc, colada, cod_mat_prima, traccion)
                        nc = "S"
                        MessageBox.Show("Rollo no conforme a sido registrado.", "orden no existe", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        sql = "update J_rollos_tref set manuales='S' where cod_orden=" & nro_orden & " and id_detalle=" & nro_plan & " and id_rollo=" & val & ""
                        obj_Ing_prodLn.ejecutar(sql, "PRODUCCION")
                        GuardarRollo(peso, CInt(val), colada, "", "", traccion)
                        imprimirTiquete(peso, CInt(val), calibre, calidad, nomb_oper, Fecha, producto, destinoDesc, colada, cod_mat_prima, traccion)
                    End If
                    nuevo()
                Else
                    MessageBox.Show("orden de produccion no existe,no es posible registrar rollo", "orden no existe", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
                nc = ""

            Else
                MessageBox.Show("orden de produccion no existe,no es posible registrar rollo", "orden no existe", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            If validar_campos_orden() Then
                nro_orden = CInt(txt_nro_orden.Text)
                nro_plan = CInt(txt_nro_plani.Text)
                sql = "select prod_final from J_orden_prod_tef where consecutivo=" & nro_orden & ""
                producto = obj_Ing_prodLn.consultar_valor(sql, "PRODUCCION")
                If producto.ToUpper = "22B100142" Or producto.ToUpper = "22B100125" Then
                    Dim operario As String
                    sql = "select operario from J_det_orden_prod where cod_orden=" & nro_orden & " and id_detalle=" & nro_plan & ""
                    operario = obj_Ing_prodLn.consultar_valor(sql, "PRODUCCION")
                    If operario <> "" Then
                        Dim nro_rollos As String
                        Dim peso As String
                        sql = "select count(id_rollo) as nro_rollos from j_rollos_Tref where cod_orden=" & nro_orden & " and id_detalle=" & nro_plan & " and anulado is null and manuales is null"
                        nro_rollos = obj_Ing_prodLn.consultar_valor(sql, "PRODUCCION")
                        sql = "select sum(peso) as peso from j_rollos_Tref where cod_orden=" & nro_orden & " and id_detalle=" & nro_plan & " and anulado is null and manuales is null"
                        peso = obj_Ing_prodLn.consultar_valor(sql, "PRODUCCION")
                        imprimir_Tiquete_lote_tref_8y9(nro_orden, nro_plan, operario, producto, nro_rollos, peso)
                    End If
                Else
                    MessageBox.Show("orden de produccion no existe o no es de los codigos permitidos,no es posible registrar rollo", "orden no existe", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End If
        End If
    End Sub
    Private Function validar_campos_rollo()
        Dim resp As Boolean = False
        If IsNumeric(txt_nro_orden.Text) Then
            If IsNumeric(txt_nro_plani.Text) Then
                If IsNumeric(txt_peso.Text) Then
                    If IsNumeric(txt_calibre.Text) Then
                        If txtcolada.Text <> "" Then
                            If txt_clientes.Text <> "" Then
                                resp = True
                            Else
                                MessageBox.Show("Destino no ingresado", "Destino no correcto", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            End If
                        Else
                            MessageBox.Show("La colada ingresada no es correcta", "colada no correcta", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If
                    Else
                        MessageBox.Show("El calibre ingresado no es correcto", "calibre no correcto", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                Else
                    MessageBox.Show("El peso ingresado no es correcto", "peso no correcto", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                MessageBox.Show("Se debe ingresar el nro de la planilla", "nro de planilla", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            MessageBox.Show("Se debe ingresar el nro de la orden", "nro de orden", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Return resp
    End Function
    Private Function validar_campos_orden()
        Dim resp As Boolean = False
        If IsNumeric(txt_nro_orden.Text) Then
            If IsNumeric(txt_nro_plani.Text) Then
                resp = True
            Else
                MessageBox.Show("Se debe ingresar el nro de la planilla", "nro de planilla", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            MessageBox.Show("Se debe ingresar el nro de la orden", "nro de orden", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Return resp
    End Function
    Private Sub GuardarRollo(ByVal peso As String, ByVal numRollo As Integer, ByVal colada As String, ByVal numOrdenPdn As String, ByVal numRolloPdn As String, ByVal traccion As String)

        Dim peso_real As Double = peso
        Dim peso_int As Integer = peso

        Dim diferencia As Double = Format(peso_real - peso_int, "#0.0")
        If diferencia < -0.3 Then
            peso_int -= 1
            diferencia = Format(peso_real - peso_int, "#0.0")
        End If
        Dim sql As String = "INSERT INTO J_rollos_tref (cod_orden,id_rollo,id_detalle,peso,colada,numOrdPdnMp,numRolloPdn,traccion,diferencia,manuales) VALUES (" & nro_orden & "," & numRollo & "," & nro_plan & "," & peso_int & ",'" & colada & "','" & numOrdenPdn & "','" & numRolloPdn & "','" & traccion & "'," & diferencia & ",'S')"
        obj_Ing_prodLn.ejecutar(sql, "PRODUCCION")
    End Sub

    Private Sub imprimirTiquete(ByVal peso As String, ByVal numRollo As Integer, ByVal calibre As String, ByVal calidad As Double, ByVal nombOperario As String, ByVal fecha As String, ByVal producto As String, ByVal destino As String, ByVal colada As String, ByVal cod_mat_prima As String, ByVal traccion As String)
        Dim proc As New Process
        'If producto.ToUpper = "22B100142" Then
        '    producto = "33R100142"
        '    destino = "Externo"
        'ElseIf producto.ToUpper = "22B100125" Then
        '    producto = "33R100142P"
        '    destino = "Externo"
        'End If
        If nc = "S" Then
            If producto.ToUpper = "22B100142" Or producto.ToUpper = "22B100125" Then
                modificarPlantillaCons(peso, fecha, producto & " -NC", numRollo)
            Else
                modificarPlantilla(nombOperario, calidad, calibre, peso, fecha, producto, numRollo, "NO CONFORME", colada, cod_mat_prima, traccion)
            End If
        Else
            If producto.ToUpper = "22B100142" Or producto.ToUpper = "22B100125" Then
                modificarPlantillaCons(peso, fecha, producto, numRollo)
            Else
                modificarPlantilla(nombOperario, calidad, calibre, peso, fecha, producto, numRollo, destino, colada, cod_mat_prima, traccion)
            End If
        End If
  
        'modificarPlantilla(nombOperario, calidad, calibre, peso, fecha, producto, numRollo, destino, colada, cod_mat_prima, traccion)
        proc.StartInfo.FileName = Environment.CurrentDirectory & "\nuevaPlantilla.txt"
        proc.StartInfo.Verb = "Print"
        proc.StartInfo.CreateNoWindow = False
        proc.Start()
    End Sub
    Private Sub modificarPlantilla(ByVal operario As String, ByVal clase As String, ByVal calibre As String, ByVal peso As String, ByVal fec As String, ByVal producto As String, ByVal numRollo As Integer, ByVal destino As String, ByVal colada As String, ByVal cod_mat_prima As String, ByVal traccion As String)
        Dim fic As String = Environment.CurrentDirectory & "\plantilla.txt"
        Dim nuevoFic As String = Environment.CurrentDirectory & "\nuevaPlantilla.txt"
        Dim sw As New System.IO.StreamWriter(nuevoFic)
        Dim texto As String
        Dim sr As New System.IO.StreamReader(fic)
        Dim codOrden As String = nro_orden & "-" & nro_plan & "-" & numRollo
        texto = sr.ReadToEnd()
        texto = Replace(texto, "@Operario", operario)
        texto = Replace(texto, "@Clase", clase)
        texto = Replace(texto, "@Calibre", calibre)
        texto = Replace(texto, "@Peso", peso & " (Kg)")
        texto = Replace(texto, "@Fecha", fec)
        texto = Replace(texto, "@Orden", codOrden)
        texto = Replace(texto, "@CodigoBarras", codOrden)
        texto = Replace(texto, "@Ref", producto)
        texto = Replace(texto, "@destino", destino)
        texto = Replace(texto, "@colada", colada)
        texto = Replace(texto, "@matPrima", cod_mat_prima)
        texto = Replace(texto, "@traccion", traccion)

        sr.Close()
        sw.WriteLine(texto)
        sw.Close()

    End Sub
    Private Sub modificarPlantillaCons(ByVal peso As String, ByVal fec As String, ByVal producto As String, ByVal numRollo As Integer)
        Dim fic As String = Environment.CurrentDirectory & "\plantillaconst.txt"
        Dim nuevoFic As String = Environment.CurrentDirectory & "\nuevaPlantilla.txt"
        Dim sw As New System.IO.StreamWriter(nuevoFic)
        Dim texto As String
        Dim sr As New System.IO.StreamReader(fic)
        Dim codOrden As String = nro_orden & "-" & nro_plan & "-" & numRollo
        texto = sr.ReadToEnd()
        texto = Replace(texto, "@Peso", peso & " (Kg)")
        texto = Replace(texto, "@Fecha", fec)
        texto = Replace(texto, "@Orden", codOrden)
        texto = Replace(texto, "@CodigoBarras", codOrden)
        texto = Replace(texto, "@Ref", producto)
        sr.Close()
        sw.WriteLine(texto)
        sw.Close()

    End Sub
    Private Function transaccion_eipp(ByVal datacodigo As DataTable, ByVal tipo As String, ByVal bodega As Integer, ByVal modelo As String, ByVal usuario As String) As List(Of Object)
        Dim listSql As New List(Of Object)
        Dim dFec As Date = Now
        Dim notas As String = "SPIC fecha:" & Now & " usuario:" & usuario
        numero_transaccion = objOrdenProdLn.mover_consecutivo(tipo)
        listSql = objTraslado_bodLn.listaTransaccionDatable(numero_transaccion, datacodigo, bodega, dFec, notas, usuario, tipo, modelo)
        Return listSql
    End Function
    Private Sub imprimir_Tiquete_lote_tref_8y9(ByVal cod_orden As String, ByVal id_detalle As String,
     ByVal operario As String, ByVal producto As String, ByVal nro_rollos As String, ByVal peso As String)
        Dim proc As New Process
        Dim fic As String = Environment.CurrentDirectory & "\plantillalote.txt"
        Dim nuevoFic As String = Environment.CurrentDirectory & "\plantillaloteimp.txt"
        Dim sw As New System.IO.StreamWriter(nuevoFic)
        Dim texto As String
        Dim sr As New System.IO.StreamReader(fic)
        Dim codOrden As String = cod_orden & "-" & id_detalle
        Dim ref As String = producto

        Dim fec As String = Now

        texto = sr.ReadToEnd()
        texto = Replace(texto, "@operario", operario)
        texto = Replace(texto, "@peso", peso & " (Kg)")
        texto = Replace(texto, "@fechah", fec)
        texto = Replace(texto, "@orden", codOrden)
        texto = Replace(texto, "@Barras", codOrden)
        texto = Replace(texto, "@cant", nro_rollos)
        texto = Replace(texto, "@ref", ref)

        sr.Close()
        sw.WriteLine(texto)
        sw.Close()

        proc.StartInfo.FileName = Environment.CurrentDirectory & "\plantillaloteimp.txt"
        proc.StartInfo.Verb = "Print"
        proc.StartInfo.CreateNoWindow = False
        proc.Start()
    End Sub
    Private Sub nuevo()
        txt_peso.Text = ""
        txt_tracc.Text = ""
        txt_calibre.Text = ""
        txtcolada.Text = ""
    End Sub
End Class