Imports entidadNegocios
Imports logicaNegocios

Public Class obj_val_punt
    Dim obj_gestion_materia_primaLn As New Gestion_materia_primaLn
    Private objOpsimpesLn As New Op_simpesLn
    Private obj_Ing_prodLn As New Ing_prodLn

    Public Function validar_no_conforme(ByVal consecutivo As String) As Boolean
        Dim resp As Boolean = True
        Dim numero_orden As String = obj_gestion_materia_primaLn.extraerDatoCodigoBarrasPuntilleria("oden_produccion", consecutivo)
        Dim id_rollo As String = obj_gestion_materia_primaLn.extraerDatoCodigoBarrasPuntilleria("id_rollo", consecutivo)
        If numero_orden <> "" And id_rollo <> "" Then
            Dim sql As String = "SELECT no_conforme FROM J_orden_prod_punt_producto WHERE nro_orden =" & numero_orden & " AND consecutivo_rollo = " & id_rollo
            Dim id As String = objOpsimpesLn.consultValorTodo(sql, "PRODUCCION")
            If id <> "" Then
                resp = False
            End If
        End If
        Return resp
    End Function

    Public Function validarCodigoBarrasPuntilleria(ByVal consecutivo As String) As Boolean
        Dim resp As Boolean = False
        Dim consecutivo_materia_prima As String = obj_gestion_materia_primaLn.extraerDatoCodigoBarrasPuntilleria("orden_produccion", consecutivo)
        Dim id_rollo As String = obj_gestion_materia_primaLn.extraerDatoCodigoBarrasPuntilleria("id_rollo", consecutivo)
        If consecutivo_materia_prima <> "" And id_rollo <> "" Then
            Dim sql As String = "select nro_orden from J_orden_prod_punt_producto WHERE nro_orden =" & consecutivo_materia_prima & " AND consecutivo_rollo = " & id_rollo
            Dim id As String = objOpsimpesLn.consultValorTodo(sql, "PRODUCCION")
            If id <> "" Then
                resp = True
            End If
        End If
        If resp = False Then
            MessageBox.Show("Intenete leerlo nuevamente", "Problemas con el tiquete", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        Return resp
    End Function

    Public Function validarTransaccionEmpaque(ByVal consecutivo As String) As Boolean
        Dim resp As Boolean = False
        Dim oden_produccion As String = obj_gestion_materia_primaLn.extraerDatoCodigoBarrasPuntilleria("orden_produccion", consecutivo)
        Dim id_rollo As String = obj_gestion_materia_primaLn.extraerDatoCodigoBarrasPuntilleria("id_rollo", consecutivo)
        Dim sqlTransaccion = "Select sppp FROM J_orden_prod_punt_producto  WHERE  nro_orden =" & oden_produccion & " And consecutivo_rollo = " & id_rollo
        If (objOpsimpesLn.consultValorTodo(sqlTransaccion, "PRODUCCION") <> "") Then
            MessageBox.Show("El producto ya fue enviado para Empaque.", "Producto ya enviado para empaque", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            resp = True
        End If
        Return resp
    End Function

    Public Function validarProductoAnulado(ByVal consecutivo As String) As Boolean
        Dim resp As Boolean = True
        Dim numero_orden As String = obj_gestion_materia_primaLn.extraerDatoCodigoBarrasPuntilleria("oden_produccion", consecutivo)
        Dim id_rollo As String = obj_gestion_materia_primaLn.extraerDatoCodigoBarrasPuntilleria("id_rollo", consecutivo)
        If numero_orden <> "" And id_rollo <> "" Then
            Dim sql As String = "SELECT nro_orden FROM J_orden_prod_punt_producto WHERE anular IS NOT NULL AND nro_orden =" & numero_orden & " AND consecutivo_rollo = " & id_rollo
            Dim id As String = objOpsimpesLn.consultValorTodo(sql, "PRODUCCION")
            If id <> "" Then
                resp = False
            End If
        End If
        Return resp
    End Function

    Public Function validarProductoTamboreado(ByVal consecutivo As String) As Boolean
        Dim resp As Boolean = False
        Dim numero_orden As String = obj_gestion_materia_primaLn.extraerDatoCodigoBarrasPuntilleria("oden_produccion", consecutivo)
        Dim id_rollo As String = obj_gestion_materia_primaLn.extraerDatoCodigoBarrasPuntilleria("id_rollo", consecutivo)
        If numero_orden <> "" And id_rollo <> "" Then
            Dim sql As String = "SELECT nro_orden FROM J_orden_prod_punt_producto WHERE tamboreado IS NOT NULL AND nro_orden =" & numero_orden & " AND consecutivo_rollo = " & id_rollo
            Dim id As String = objOpsimpesLn.consultValorTodo(sql, "PRODUCCION")
            If id <> "" Then
                resp = True
            End If
        End If
        Return resp
    End Function

    Public Function validar_empaque(ByVal consecutivo As String, ByVal ref As String)
        Dim resp As Boolean = False
        Dim numero_orden As String = obj_gestion_materia_primaLn.extraerDatoCodigoBarrasPuntilleria("oden_produccion", consecutivo)
        Dim id_rollo As String = obj_gestion_materia_primaLn.extraerDatoCodigoBarrasPuntilleria("id_rollo", consecutivo)

        Dim sql As String = "SELECT clase FROM J_orden_prod_punt_refs_clase WHERE REF = '" & ref.Trim & "'"
        Dim clase As Integer = obj_Ing_prodLn.consultar_valor(sql, "PRODUCCION")


        If clase = 1 Then
            sql = "select tamboreado from J_orden_prod_punt_producto where nro_orden = " & numero_orden & " and consecutivo_rollo = " & id_rollo
            Dim val As String = objOpsimpesLn.consultValorTodo(sql, "PRODUCCION")
            If val.Trim = "S" Then
                resp = True
            Else
                MessageBox.Show("El contenedor debe ser tamboreado", "Producto sin Tamborear", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If

        If clase = 2 Then
            sql = "select tamboreado from J_orden_prod_punt_producto where nro_orden = " & numero_orden & " and consecutivo_rollo = " & id_rollo
            Dim tam As String = objOpsimpesLn.consultValorTodo(sql, "PRODUCCION")
            sql = "select hornos from J_orden_prod_punt_producto where nro_orden = " & numero_orden & " and consecutivo_rollo = " & id_rollo
            Dim hor As String = objOpsimpesLn.consultValorTodo(sql, "PRODUCCION")
            If tam.Trim = "S" And hor = "S" Then
                resp = False
            Else
                If tam.Trim = "S" Then
                    MessageBox.Show("El contenedor debe ser llevado a Hornos.", "Producto sin llevar a Hornos", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    MessageBox.Show("El contenedor debe ser tamboreado", "Producto sin Tamborear", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End If
        End If

        If clase = 3 Then
            sql = "select tamboreado from J_orden_prod_punt_producto where nro_orden = " & numero_orden & " and consecutivo_rollo = " & id_rollo
            Dim tam As String = objOpsimpesLn.consultValorTodo(sql, "PRODUCCION")
            sql = "select hornos from J_orden_prod_punt_producto where nro_orden = " & numero_orden & " and consecutivo_rollo = " & id_rollo
            Dim hor As String = objOpsimpesLn.consultValorTodo(sql, "PRODUCCION")
            If tam.Trim = "S" And hor = "B" Then
                resp = False
            Else
                If tam.Trim = "S" Then
                    MessageBox.Show("El contenedor debe ser llevado a Hornos.", "Producto sin llevar a Hornos", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    MessageBox.Show("El contenedor debe ser tamboreado", "Producto sin Tamborear", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End If
        End If
        If clase = 4 Or clase = 0 Then
            resp = True
        End If
        If resp = False Then
            If clase = 2 Or clase = 3 Then
                MessageBox.Show("El contenedor Fue enviado a Hornos.", "Producto en Hornos", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
        Return resp
    End Function

    Public Function validar_clas_tambores(ByVal consecutivo As String, ByVal ref As String)
        Dim resp As Boolean = False
        Dim numero_orden As String = obj_gestion_materia_primaLn.extraerDatoCodigoBarrasPuntilleria("oden_produccion", consecutivo)
        Dim id_rollo As String = obj_gestion_materia_primaLn.extraerDatoCodigoBarrasPuntilleria("id_rollo", consecutivo)

        Dim sql As String = "SELECT clase FROM J_orden_prod_punt_refs_clase WHERE REF = '" & ref.Trim & "'"
        Dim clase As Integer = obj_Ing_prodLn.consultar_valor(sql, "PRODUCCION")

        If clase = 1 Or clase = 2 Or clase = 3 Then
            sql = "select tamboreado from J_orden_prod_punt_producto where nro_orden = " & numero_orden & " and consecutivo_rollo = " & id_rollo
            Dim val As String = objOpsimpesLn.consultValorTodo(sql, "PRODUCCION")
            If val.Trim = "S" Then
                MessageBox.Show("El contenedor ya esta tamboreado", "Producto sin Tamborear", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                resp = True
            End If
        End If
        If clase = 4 Or clase = 0 Then
            MessageBox.Show("Esta referencia no debe ser Tamboreada.", "Referencia invalida.", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Return resp
    End Function
    Public Function validar_horno(ByVal consecutivo As String, ByVal ref As String)
        Dim resp As Boolean = False
        Dim numero_orden As String = obj_gestion_materia_primaLn.extraerDatoCodigoBarrasPuntilleria("oden_produccion", consecutivo)
        Dim id_rollo As String = obj_gestion_materia_primaLn.extraerDatoCodigoBarrasPuntilleria("id_rollo", consecutivo)
        Dim sql As String = "SELECT clase FROM J_orden_prod_punt_refs_clase WHERE REF = '" & ref.Trim & "'"
        Dim clase As Integer = obj_Ing_prodLn.consultar_valor(sql, "PRODUCCION")
        If clase = 2 Or clase = 3 Then
            sql = "select tamboreado from J_orden_prod_punt_producto where nro_orden = " & numero_orden & " and consecutivo_rollo = " & id_rollo
            Dim val As String = objOpsimpesLn.consultValorTodo(sql, "PRODUCCION")
            If val = "S" Then
                sql = "select hornos from J_orden_prod_punt_producto where nro_orden = " & numero_orden & " and consecutivo_rollo = " & id_rollo
                Dim hor As String = objOpsimpesLn.consultValorTodo(sql, "PRODUCCION")
                If hor = "" Then
                    resp = True
                Else
                    MessageBox.Show("Este producto ya fue enviado a Hornos.", "Referencia invalida.", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                MessageBox.Show("Este producto debe de ser tamboreado.", "Referencia invalida.", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
        If resp = False Then
            If clase = 1 Or clase = 4 Then
                MessageBox.Show("Esta referencia no debe ser Enviada a Hornos.", "Referencia invalida.", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
        Return resp
    End Function
    Public Function validar_codigos_bodega_8(ByVal codigo As String)
        Dim resp As Boolean = False
        Dim cod_punt As String
        Dim sql As String = "select codigo from referencias_Puntilleria where codigo='" & codigo & "' "
        cod_punt = objOpsimpesLn.consultValorTodo(sql, "CORSAN")
        If cod_punt <> "" Then
            resp = True
        End If
        Return resp
    End Function
End Class