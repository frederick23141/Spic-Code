Imports logicaNegocios
Imports entidadNegocios
Public Class Frm_ppto_produccion
    Private obj_op_simplesLn As New Op_simpesLn
    Private obj_Ing_prodLn As New Ing_prodLn
    Private objOperacionesForm As New OperacionesFormularios
    Dim carga_comp As Boolean = False
    Dim usuario As New UsuarioEn
    Public Sub MAIN(ByVal usuario As UsuarioEn)
        Me.usuario = usuario
    End Sub
    Private Sub Frm_ppto_produccion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim año = Now.Year
        While (año >= Now.Year - 5)
            cbo_ano.Items.Add(año)
            año -= 1
        End While
        cbo_ano.Text = Now.Year
        cbo_mes.SelectedIndex = Now.Month - 1
        cargar_dias_habiles_otros()
        cargar_fechas_desc_otros()
        cargar_fechas_desc_otros_o()
        consultar()
        consultar_ppto_area()
        consultar_ppto_detalle()
        consultar_efic_meta()
        consultar_ausentismo()
        consultar_extra()
        carga_comp = True
    End Sub
    Private Sub llenarDtg()
        dtg_presupuesto.DataSource = Nothing
        dtg_presupuesto.Columns.Clear()
        dtg_presupuesto.Columns.Add("id_cor", "id_cor")
        dtg_presupuesto.Columns.Add("linea_de_produccion", "linea_de_produccion")
        dtg_presupuesto.Columns.Add("kilos", "kilos")
        dtg_presupuesto.Columns.Add("cantidad", "cantidad")
        dtg_presupuesto.Columns.Add("conversion", "conversión")
        dtg_presupuesto.Columns.Add("tipo_conversion", "tipo_conversion")
        Dim sql As String = "SELECT id_cor,descripcion As linea_de_produccion ,conversion, tipo_conversion  FROM jjv_grupos_seguimiento WHERE id_cor not in (99,30,28) ORDER BY orden "
        Dim dt_lineas As DataTable = obj_op_simplesLn.listar_datatable(sql, "CORSAN")
        For i = 0 To dt_lineas.Rows.Count - 1
            dtg_presupuesto.Rows.Add()
            dtg_presupuesto.Item("id_cor", i).Value = dt_lineas.Rows(i).Item("id_cor")
            dtg_presupuesto.Item("linea_de_produccion", i).Value = dt_lineas.Rows(i).Item("linea_de_produccion")
            dtg_presupuesto.Item("conversion", i).Value = dt_lineas.Rows(i).Item("conversion")
            dtg_presupuesto.Item("tipo_conversion", i).Value = dt_lineas.Rows(i).Item("tipo_conversion")
            dtg_presupuesto.Item("kilos", i).Value = 0
        Next
        dtg_presupuesto.Rows.Add()
        formatoDtg()
        totalizarDtg()
    End Sub
  
    Private Sub llenarDtg_Detalle()
        dtg_ppto_detalle.DataSource = Nothing
        dtg_ppto_detalle.Columns.Clear()
        dtg_ppto_detalle.Columns.Add("id_item", "id_item")
        dtg_ppto_detalle.Columns.Add("linea_de_produccion", "linea_de_produccion")
        dtg_ppto_detalle.Columns.Add("kilos", "kilos")
        Dim sql As String = "SELECT id_item,descripcion As linea_de_produccion FROM J_ppto_porduccion_item ORDER BY orden "
        Dim dt_lineas As DataTable = obj_op_simplesLn.listar_datatable(sql, "PRODUCCION")
        For i = 0 To dt_lineas.Rows.Count - 1
            dtg_ppto_detalle.Rows.Add()
            dtg_ppto_detalle.Item("id_item", i).Value = dt_lineas.Rows(i).Item("id_item")
            dtg_ppto_detalle.Item("linea_de_produccion", i).Value = dt_lineas.Rows(i).Item("linea_de_produccion")
            dtg_ppto_detalle.Item("kilos", i).Value = 0
        Next
        dtg_ppto_detalle.Rows.Add()
        formatoDtg_detalle()
        totalizarDtg_Detalle()
    End Sub
    Private Sub llenarDtg_efic_meta()
        dtg_efic_meta.DataSource = Nothing
        dtg_efic_meta.Columns.Clear()
        Dim dt As New DataTable
        Dim sql As String = "SELECT centro,descripcion " & _
                                "FROM centros " & _
                                     "WHERE centro IN (2100,2200,2300,2400,2500,2600,2800,3100,3200,3500,4100,5200,6200,6400)"
        dt = obj_Ing_prodLn.listar_datatable(sql, "CORSAN")
        dt.Columns.Add("presupuesto", GetType(Double))
        dt.Rows.Add()
        dtg_efic_meta.DataSource = dt
        formatoDtg_meta()
        totalizarDtg_meta()
    End Sub
    Private Sub llenarDtg_ausentismo()
        dtg_ausentismo.DataSource = Nothing
        dtg_ausentismo.Columns.Clear()
        Dim dt As New DataTable
        Dim sql As String = "SELECT centro,descripcion " & _
                                "FROM centros " & _
                                     "WHERE centro IN (2100,2200,2300,2400,2500,2600,2800,3100,3200,3500,4100,5200,6200,6400)"
        dt = obj_Ing_prodLn.listar_datatable(sql, "CORSAN")
        dt.Columns.Add("presupuesto", GetType(Double))
        dt.Rows.Add()
        dtg_ausentismo.DataSource = dt
        formatoDtg_ausentismo()
        totalizarDtg_ausentismo()
    End Sub
    Private Sub llenarDtg_extra()
        dtg_extra.DataSource = Nothing
        dtg_extra.Columns.Clear()
        Dim dt As New DataTable
        Dim sql As String = "SELECT centro,descripcion " & _
                                "FROM centros " & _
                                     "WHERE centro IN (2100,2200,2300,2400,2500,2600,2800,3100,3200,3500,4100,5200,6200,6400)"
        dt = obj_Ing_prodLn.listar_datatable(sql, "CORSAN")
        dt.Columns.Add("presupuesto", GetType(Double))
        dt.Rows.Add()
        dtg_extra.DataSource = dt
        formatoDtg_extra()
        totalizarDtg_extra()
    End Sub
    Private Sub calcularConversion()
        For i = 0 To dtg_presupuesto.Rows.Count - 2
            If IsNumeric(dtg_presupuesto.Item("conversion", i).Value) And IsNumeric(dtg_presupuesto.Item("conversion", i).Value) Then
                dtg_presupuesto.Item("cantidad", i).Value = dtg_presupuesto.Item("kilos", i).Value / dtg_presupuesto.Item("conversion", i).Value
            Else
                dtg_presupuesto.Item("cantidad", i).Value = dtg_presupuesto.Item("kilos", i).Value
            End If
        Next
    End Sub
    Private Sub guardar()
        dtg_presupuesto.CurrentCell = Nothing
        Dim listSql As New List(Of Object)
        listSql.AddRange(guardar_dias_habil_otros)
        listSql.AddRange(guardar_fechas_desc_otros)
        listSql.AddRange(guardar_fechas_desc_otros_o)
        Dim ano As Integer = cbo_ano.Text
        Dim mes As Integer = cbo_mes.SelectedIndex + 1
        Dim dias_habiles As Double = txtDiasHabil.Text
        Dim dias_adic As Double = txtDiasAdic.Text
        Dim sql_gral As String = "INSERT INTO J_ppto_produccion (ano,mes,notas,dias_habiles,dias_adicionales,id_cor,kilos) VALUES (" & ano & "," & mes & ",' usuario:" & usuario.nombre & "'," & dias_habiles & "," & dias_adic & " "
        Dim sql As String = ""
        Dim sql_delete As String = "DELETE FROM J_ppto_produccion WHERE mes =" & cbo_mes.SelectedIndex + 1 & " AND ano = " & cbo_ano.Text
        Dim sql_ppto_consumo_alambron As String = "INSERT INTO J_ppto_prod_consumo_alambron  (ano,mes,kilos,notas) VALUES (" & ano & "," & mes & "," & txt_ppto_consumo_alambron.Text & " ,' usuario:" & usuario.nombre & "')"
        Dim delete_ppto_consumo_alambron As String = "DELETE FROM J_ppto_prod_consumo_alambron WHERE mes =" & cbo_mes.SelectedIndex + 1 & " AND ano = " & cbo_ano.Text
        Dim sql_ppto_reproceso As String = "INSERT INTO J_ppto_prod_reproceso  (ano,mes,kilos,notas) VALUES (" & ano & "," & mes & "," & txt_ppto_reproceso.Text & " ,' usuario:" & usuario.nombre & "')"
        Dim delete_ppto_reproceso As String = "DELETE FROM J_ppto_prod_reproceso WHERE mes =" & cbo_mes.SelectedIndex + 1 & " AND ano = " & cbo_ano.Text
        listSql.Add(sql_delete)
        listSql.Add(delete_ppto_consumo_alambron)
        listSql.Add(sql_ppto_consumo_alambron)
        listSql.Add(delete_ppto_reproceso)
        listSql.Add(sql_ppto_reproceso)
        For i = 0 To dtg_presupuesto.Rows.Count - 2
            sql = sql_gral & "," & dtg_presupuesto.Item("id_cor", i).Value & "," & dtg_presupuesto.Item("kilos", i).Value & ")"
            listSql.Add(sql)
        Next
        If (obj_Ing_prodLn.ExecuteSqlTransaction(listSql, "PRODUCCION")) Then
            MessageBox.Show("El registro se guardo en forma exitosa!", "Exito!", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Error al ingresar el registro, comuniquese con el area de sistemas", "Verifique!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Private Sub guardar_detalle()
        dtg_ppto_detalle.CurrentCell = Nothing
        Dim listSql As New List(Of Object)
        listSql.AddRange(guardar_dias_habil_otros)
        listSql.AddRange(guardar_fechas_desc_otros)
        listSql.AddRange(guardar_fechas_desc_otros_o)
        Dim ano As Integer = cbo_ano.Text
        Dim mes As Integer = cbo_mes.SelectedIndex + 1
        Dim sql_gral As String = "INSERT INTO J_ppto_produccion_detalle (ano,mes,notas,id_ppto_prod_item,kilos) VALUES (" & ano & "," & mes & ",' usuario:" & usuario.nombre & "' "
        Dim sql As String = ""
        Dim sql_delete As String = "DELETE FROM J_ppto_produccion_detalle WHERE mes =" & cbo_mes.SelectedIndex + 1 & " AND ano = " & cbo_ano.Text
        listSql.Add(sql_delete)
        For i = 0 To dtg_ppto_detalle.Rows.Count - 2
            sql = sql_gral & "," & dtg_ppto_detalle.Item("id_item", i).Value & "," & dtg_ppto_detalle.Item("kilos", i).Value & ")"
            listSql.Add(sql)
        Next
        If (obj_Ing_prodLn.ExecuteSqlTransaction(listSql, "PRODUCCION")) Then
            MessageBox.Show("El registro se guardo en forma exitosa!", "Exito!", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Error al ingresar el registro, comuniquese con el area de sistemas", "Verifique!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub guardar_efic_meta()
        dtg_efic_meta.CurrentCell = Nothing
        Dim listSql As New List(Of Object)
        Dim ano As Integer = cbo_ano.Text
        Dim mes As Integer = cbo_mes.SelectedIndex + 1
        Dim sql_gral As String = "INSERT INTO J_ppto_prod_efic_meta (ano,mes,centro,presupuesto) VALUES (" & ano & "," & mes & " "
        Dim sql As String = ""
        Dim sql_delete As String = "DELETE FROM J_ppto_prod_efic_meta WHERE mes =" & cbo_mes.SelectedIndex + 1 & " AND ano = " & cbo_ano.Text
        listSql.Add(sql_delete)
        For i = 0 To dtg_efic_meta.Rows.Count - 2
            If Not IsNumeric(dtg_efic_meta.Item("presupuesto", i).Value) Then
                dtg_efic_meta.Item("presupuesto", i).Value = 0
            End If
            sql = sql_gral & "," & dtg_efic_meta.Item("centro", i).Value & "," & dtg_efic_meta.Item("presupuesto", i).Value & ")"
            listSql.Add(sql)

        Next
        If (obj_Ing_prodLn.ExecuteSqlTransaction(listSql, "PRODUCCION")) Then
            MessageBox.Show("El registro se guardo en forma exitosa!", "Exito!", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Error al ingresar el registro, comuniquese con el area de sistemas", "Verifique!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Private Sub guardar_ausentismo()
        dtg_ausentismo.CurrentCell = Nothing
        Dim listSql As New List(Of Object)
        Dim ano As Integer = cbo_ano.Text
        Dim mes As Integer = cbo_mes.SelectedIndex + 1
        Dim sql_gral As String = "INSERT INTO J_ppto_prod_ausentismo (ano,mes,centro,presupuesto) VALUES (" & ano & "," & mes & " "
        Dim sql As String = ""
        Dim sql_delete As String = "DELETE FROM J_ppto_prod_ausentismo WHERE mes =" & cbo_mes.SelectedIndex + 1 & " AND ano = " & cbo_ano.Text
        listSql.Add(sql_delete)
        For i = 0 To dtg_ausentismo.Rows.Count - 2
            If Not IsNumeric(dtg_ausentismo.Item("presupuesto", i).Value) Then
                dtg_ausentismo.Item("presupuesto", i).Value = 0
            End If
            sql = sql_gral & "," & dtg_ausentismo.Item("centro", i).Value & "," & dtg_ausentismo.Item("presupuesto", i).Value & ")"
            listSql.Add(sql)

        Next
        If (obj_Ing_prodLn.ExecuteSqlTransaction(listSql, "PRODUCCION")) Then
            MessageBox.Show("El registro se guardo en forma exitosa!", "Exito!", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Error al ingresar el registro, comuniquese con el area de sistemas", "Verifique!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Private Sub guardar_extra()
        dtg_extra.CurrentCell = Nothing
        Dim listSql As New List(Of Object)
        Dim ano As Integer = cbo_ano.Text
        Dim mes As Integer = cbo_mes.SelectedIndex + 1
        Dim sql_gral As String = "INSERT INTO J_ppto_prod_extra (ano,mes,centro,presupuesto) VALUES (" & ano & "," & mes & " "
        Dim sql As String = ""
        Dim sql_delete As String = "DELETE FROM J_ppto_prod_extra WHERE mes =" & cbo_mes.SelectedIndex + 1 & " AND ano = " & cbo_ano.Text
        listSql.Add(sql_delete)
        For i = 0 To dtg_extra.Rows.Count - 2
            If Not IsNumeric(dtg_extra.Item("presupuesto", i).Value) Then
                dtg_extra.Item("presupuesto", i).Value = 0
            End If
            sql = sql_gral & "," & dtg_extra.Item("centro", i).Value & "," & dtg_extra.Item("presupuesto", i).Value & ")"
            listSql.Add(sql)

        Next
        If (obj_Ing_prodLn.ExecuteSqlTransaction(listSql, "PRODUCCION")) Then
            MessageBox.Show("El registro se guardo en forma exitosa!", "Exito!", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Error al ingresar el registro, comuniquese con el area de sistemas", "Verifique!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Private Sub consultar()
        txtDiasHabil.Text = ""
        txtDiasAdic.Text = ""
        dtg_presupuesto.Columns.Clear()
        Dim dt As New DataTable
        Dim sql As String = "SELECT p.id_cor,i.descripcion As linea_de_produccion,p.kilos,p.kilos As cantidad, i.conversion,i.tipo_conversion,dias_habiles,dias_adicionales " & _
                                        "FROM J_ppto_produccion p , CORSAN.dbo.JJV_Grupos_seguimiento  i " & _
                                            "WHERE p.id_cor = i.id_cor AND mes =" & cbo_mes.SelectedIndex + 1 & " AND ano = " & cbo_ano.Text & " " & _
                                                "ORDER BY i.orden"
        dt = obj_Ing_prodLn.listar_datatable(sql, "PRODUCCION")
        dtg_presupuesto.DataSource = dt
        If (dt.Rows.Count > 0) Then
            If Not IsDBNull(dt.Rows(0).Item("dias_habiles")) Then
                txtDiasHabil.Text = dt.Rows(0).Item("dias_habiles")
            End If
            If Not IsDBNull(dt.Rows(0).Item("dias_adicionales")) Then
                txtDiasAdic.Text = dt.Rows(0).Item("dias_adicionales")
            End If
        End If
        dt.Rows.Add()
        formatoDtg()
        calcularConversion()
        totalizarDtg()
        If dt.Rows.Count = 1 Then
            llenarDtg()
        End If
        For j = 0 To dtg_presupuesto.Columns.Count - 1
            If dtg_presupuesto.Columns(j).Name = "dias_habiles" Or dtg_presupuesto.Columns(j).Name = "dias_adicionales" Then
                dtg_presupuesto.Columns(j).Visible = False
            ElseIf (dtg_presupuesto.Columns(j).Name = "cantidad") Then
                dtg_presupuesto.Columns(j).ReadOnly = False
            End If
        Next
        Dim sql_ppto_consumo_alambron As String = "SELECT SUM(kilos) FROM J_ppto_prod_consumo_alambron WHERE mes = " & cbo_mes.SelectedIndex + 1 & " AND ano = " & cbo_ano.Text
        Dim ppto_consumo_alambron As String = obj_op_simplesLn.consultValorTodo(sql_ppto_consumo_alambron, "PRODUCCION")
        If ppto_consumo_alambron = "" Then
            txt_ppto_consumo_alambron.Text = 0
        Else
            txt_ppto_consumo_alambron.Text = ppto_consumo_alambron
        End If
        Dim sql_ppto_reproceso As String = "SELECT SUM(kilos) FROM J_ppto_prod_reproceso WHERE mes = " & cbo_mes.SelectedIndex + 1 & " AND ano = " & cbo_ano.Text
        Dim ppto_reproceso As String = obj_op_simplesLn.consultValorTodo(sql_ppto_reproceso, "PRODUCCION")
        If ppto_reproceso = "" Then
            txt_ppto_reproceso.Text = 0
        Else
            txt_ppto_reproceso.Text = ppto_reproceso
        End If
    End Sub
    Private Sub consultar_ppto_detalle()
        dtg_ppto_detalle.Columns.Clear()
        Dim dt As New DataTable
        Dim sql As String = "SELECT i.id_item ,i.descripcion As linea_de_produccion,d.kilos " & _
                                        "FROM J_ppto_porduccion_item i , J_ppto_produccion_detalle d  " & _
                                            "WHERE i.id_item = d.id_ppto_prod_item AND mes =" & cbo_mes.SelectedIndex + 1 & " AND ano = " & cbo_ano.Text & " " & _
                                                "ORDER BY i.orden"
        dt = obj_Ing_prodLn.listar_datatable(sql, "PRODUCCION")
        dtg_ppto_detalle.DataSource = dt
        dt.Rows.Add()
        formatoDtg_detalle()
        totalizarDtg_detalle()
        If dt.Rows.Count = 1 Then
            llenarDtg_Detalle()
        End If
    End Sub
    Private Sub consultar_efic_meta()
        dtg_efic_meta.Columns.Clear()
        Dim dt As New DataTable
        Dim sql As String = "SELECT c.centro,c.descripcion,presupuesto " & _
                                        "FROM J_ppto_prod_efic_meta p , CORSAN.dbo.centros c " & _
                                            "WHERE p.centro = c.centro AND p.mes =" & cbo_mes.SelectedIndex + 1 & " AND p.ano = " & cbo_ano.Text & " " & _
                                                "ORDER BY c.centro "
        dt = obj_Ing_prodLn.listar_datatable(sql, "PRODUCCION")
        dt.Rows.Add()
        dtg_efic_meta.DataSource = dt
        formatoDtg_meta()
        totalizarDtg_meta()
        If dt.Rows.Count = 1 Then
            llenarDtg_efic_meta()
        End If
    End Sub
    Private Sub consultar_ausentismo()
        dtg_ausentismo.Columns.Clear()
        Dim dt As New DataTable
        Dim sql As String = "SELECT c.centro,c.descripcion,presupuesto " & _
                                        "FROM J_ppto_prod_ausentismo p , CORSAN.dbo.centros c " & _
                                            "WHERE p.centro = c.centro AND p.mes =" & cbo_mes.SelectedIndex + 1 & " AND p.ano = " & cbo_ano.Text & " " & _
                                                "ORDER BY c.centro "
        dt = obj_Ing_prodLn.listar_datatable(sql, "PRODUCCION")
        dt.Rows.Add()
        dtg_ausentismo.DataSource = dt
        formatoDtg_ausentismo()
        totalizarDtg_ausentismo()
        If dt.Rows.Count = 1 Then
            llenarDtg_ausentismo()
        End If
    End Sub
    Private Sub consultar_extra()
        dtg_extra.Columns.Clear()
        Dim dt As New DataTable
        Dim sql As String = "SELECT c.centro,c.descripcion,presupuesto " & _
                                        "FROM J_ppto_prod_extra p , CORSAN.dbo.centros c " & _
                                            "WHERE p.centro = c.centro AND p.mes =" & cbo_mes.SelectedIndex + 1 & " AND p.ano = " & cbo_ano.Text & " " & _
                                                "ORDER BY c.centro "
        dt = obj_Ing_prodLn.listar_datatable(sql, "PRODUCCION")
        dt.Rows.Add()
        dtg_extra.DataSource = dt
        formatoDtg_extra()
        totalizarDtg_extra()
        If dt.Rows.Count = 1 Then
            llenarDtg_extra()
        End If
    End Sub
    Private Function validar() As Boolean
        Dim resp As Boolean = True
        If (txtDiasHabil.Text <> "" And txtDiasAdic.Text <> "") Then
            For i = 0 To dtg_presupuesto.Rows.Count - 1
                If Not IsDBNull(dtg_presupuesto.Item("kilos", i).Value) Then
                    If Not IsNumeric(dtg_presupuesto.Item("kilos", i).Value) Then
                        resp = False
                    End If
                Else
                    dtg_presupuesto.Item("kilos", i).Value = 0
                End If
            Next
        Else
            If (txtDiasHabil.Text = "") Then
                MessageBox.Show("Verifique que los días hábiles sean correctos", "Verifique!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ElseIf (txtDiasAdic.Text = "") Then
                MessageBox.Show("Verifique que los días hábiles adicionales sean correctos", "Verifique!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
            resp = False
        End If
        If txt_ppto_consumo_alambron.Text = "" Then
            MessageBox.Show("Ingrese el presupuesto para el consumo de alambrón", "Verifique!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            resp = False
        End If
        If txt_ppto_reproceso.Text = "" Then
            MessageBox.Show("Ingrese el presupuesto para el reproceso", "Verifique!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            resp = False
        End If
        Return resp
    End Function
    Private Function validar_meta() As Boolean
        Dim resp As Boolean = True
        For i = 0 To dtg_efic_meta.Rows.Count - 1
            If Not IsDBNull(dtg_efic_meta.Item("presupuesto", i).Value) Then
                If Not IsNumeric(dtg_efic_meta.Item("presupuesto", i).Value) Then
                    resp = False
                End If
            Else
                dtg_efic_meta.Item("presupuesto", i).Value = 0
            End If
        Next
        Return resp
    End Function
    Private Function validar_ausentismo() As Boolean
        Dim resp As Boolean = True
        For i = 0 To dtg_ausentismo.Rows.Count - 1
            If Not IsDBNull(dtg_ausentismo.Item("presupuesto", i).Value) Then
                If Not IsNumeric(dtg_ausentismo.Item("presupuesto", i).Value) Then
                    resp = False
                End If
            Else
                dtg_ausentismo.Item("presupuesto", i).Value = 0
            End If
        Next
        Return resp
    End Function
    Private Function validar_extra() As Boolean
        Dim resp As Boolean = True
        For i = 0 To dtg_extra.Rows.Count - 1
            If Not IsDBNull(dtg_extra.Item("presupuesto", i).Value) Then
                If Not IsNumeric(dtg_extra.Item("presupuesto", i).Value) Then
                    resp = False
                End If
            Else
                dtg_extra.Item("presupuesto", i).Value = 0
            End If
        Next
        Return resp
    End Function
    Private Function validar_Detalle() As Boolean
        Dim resp As Boolean = True
        If (txtDiasHabil.Text <> "" And txtDiasAdic.Text <> "") Then
            For i = 0 To dtg_ppto_detalle.Rows.Count - 1
                If Not IsDBNull(dtg_ppto_detalle.Item("kilos", i).Value) Then
                    If Not IsNumeric(dtg_ppto_detalle.Item("kilos", i).Value) Then
                        resp = False
                    End If
                Else
                    dtg_ppto_detalle.Item("kilos", i).Value = 0
                End If
            Next
        End If
        Return resp
    End Function
    Private Function validar_ppto_area() As Boolean
        Dim resp As Boolean = True
        For i = 0 To dtg_ppto_area.Rows.Count - 1
            If Not IsDBNull(dtg_ppto_area.Item("kilos", i).Value) Then
                If Not IsNumeric(dtg_ppto_area.Item("kilos", i).Value) Then
                    resp = False
                Else
                    If dtg_ppto_area.Item("kilos", i).Value > 0 Then
                    Else
                        dtg_ppto_area.Item("kilos", i).Value = 0
                    End If
                End If
            ElseIf Not IsDBNull(dtg_ppto_area.Item("dias_habiles", i).Value) Or Not IsDBNull(dtg_ppto_area.Item("dias_adicionales", i).Value) Then
                If Not IsNumeric(dtg_ppto_area.Item("dias_habiles", i).Value) Or Not IsNumeric(dtg_ppto_area.Item("dias_adicionales", i).Value) Then
                    resp = False
                End If
            End If
        Next
            Return resp
    End Function
    Private Sub btn_guardar_Click(sender As Object, e As EventArgs) Handles btn_guardar.Click
        If txt_dias_adic_otros.Text <> "" And txt_dias_habl_otros.Text <> "" Then
            If tab_ppal.SelectedTab.Name = tab_prod.Name Then
                guardarPpto()
            ElseIf tab_ppal.SelectedTab.Name = tab_area.Name Then
                guardarPptoArea()
            ElseIf tab_ppal.SelectedTab.Name = tab_efic.Name Then
                guardar_meta()
            ElseIf tab_ppal.SelectedTab.Name = tab_ausentismo.Name Then
                guardar_ppto_ausentismo()
            ElseIf tab_ppal.SelectedTab.Name = tab_extra.Name Then
                guardar_ppto_extra()
            Else
                guardarPpto_detalle()
            End If
        Else
            MessageBox.Show("Ingrese los días habiles para otras areas", "Ingrese días habiles!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

    End Sub
    Private Sub guardarPpto()
        dtg_presupuesto.CurrentCell = Nothing
        If (validar()) Then
            Dim sql As String = "SELECT *  FROM J_ppto_produccion WHERE mes =" & cbo_mes.SelectedIndex + 1 & " AND ano = " & cbo_ano.Text
            If (obj_Ing_prodLn.consultValor(sql, "PRODUCCION") = "") Then
                guardar()
            Else
                Dim resp As Integer = 0
                resp = MessageBox.Show("Ya existe presupuesto para: " & cbo_mes.SelectedIndex + 1 & "-" & cbo_ano.Text & " desea sobre-escribirlo? ", "Modificar presupuesto", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If resp = 6 Then
                    guardar()
                Else
                    llenarDtg()
                End If
            End If

        Else
            MessageBox.Show("Verifique que los valores ingresados sean númericos    ", "Verifique!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
    Private Sub guardarPpto_detalle()
        dtg_ppto_detalle.CurrentCell = Nothing
        If (validar_Detalle()) Then
            Dim sql As String = "SELECT *  FROM J_ppto_produccion_detalle WHERE mes =" & cbo_mes.SelectedIndex + 1 & " AND ano = " & cbo_ano.Text
            If (obj_Ing_prodLn.consultValor(sql, "PRODUCCION") = "") Then
                guardar_detalle()
            Else
                Dim resp As Integer = 0
                resp = MessageBox.Show("Ya existe presupuesto para: " & cbo_mes.SelectedIndex + 1 & "-" & cbo_ano.Text & " desea sobre-escribirlo? ", "Modificar presupuesto", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If resp = 6 Then
                    guardar_detalle()
                Else
                    llenarDtg_Detalle()
                End If
            End If

        Else
            MessageBox.Show("Verifique que los valores ingresados sean númericos    ", "Verifique!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
    Private Sub guardar_meta()
        dtg_efic_meta.CurrentCell = Nothing
        If (validar_meta()) Then
            Dim sql As String = "SELECT *  FROM J_ppto_prod_efic_meta WHERE mes =" & cbo_mes.SelectedIndex + 1 & " AND ano = " & cbo_ano.Text
            If (obj_Ing_prodLn.consultValor(sql, "PRODUCCION") = "") Then
                guardar_efic_meta()
            Else
                Dim resp As Integer = 0
                resp = MessageBox.Show("Ya existe presupeusto para: " & cbo_mes.SelectedIndex + 1 & "-" & cbo_ano.Text & " desea sobre-escribirlo? ", "Modificar presupuesto", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If resp = 6 Then
                    guardar_efic_meta()
                Else
                    llenarDtg_efic_meta()
                End If
            End If

        Else
            MessageBox.Show("Verifique que los valores ingresados sean númericos    ", "Verifique!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
    Private Sub guardar_ppto_ausentismo()
        dtg_ausentismo.CurrentCell = Nothing
        If (validar_ausentismo()) Then
            Dim sql As String = "SELECT *  FROM J_ppto_prod_ausentismo WHERE mes =" & cbo_mes.SelectedIndex + 1 & " AND ano = " & cbo_ano.Text
            If (obj_Ing_prodLn.consultValor(sql, "PRODUCCION") = "") Then
                guardar_ausentismo()
            Else
                Dim resp As Integer = 0
                resp = MessageBox.Show("Ya existe presupeusto para: " & cbo_mes.SelectedIndex + 1 & "-" & cbo_ano.Text & " desea sobre-escribirlo? ", "Modificar presupuesto", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If resp = 6 Then
                    guardar_ausentismo()
                Else
                    llenarDtg_ausentismo()
                End If
            End If

        Else
            MessageBox.Show("Verifique que los valores ingresados sean númericos    ", "Verifique!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
    Private Sub guardar_ppto_extra()
        dtg_ausentismo.CurrentCell = Nothing
        If (validar_extra()) Then
            Dim sql As String = "SELECT *  FROM J_ppto_prod_extra WHERE mes =" & cbo_mes.SelectedIndex + 1 & " AND ano = " & cbo_ano.Text
            If (obj_Ing_prodLn.consultValor(sql, "PRODUCCION") = "") Then
                guardar_extra()
            Else
                Dim resp As Integer = 0
                resp = MessageBox.Show("Ya existe presupeusto para: " & cbo_mes.SelectedIndex + 1 & "-" & cbo_ano.Text & " desea sobre-escribirlo? ", "Modificar presupuesto", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If resp = 6 Then
                    guardar_extra()
                Else
                    llenarDtg_extra()
                End If
            End If

        Else
            MessageBox.Show("Verifique que los valores ingresados sean númericos    ", "Verifique!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
    Private Sub guardarPptoArea()
        dtg_ppto_detalle.CurrentCell = Nothing
        If (validar_ppto_area()) Then
            Dim sql As String = "SELECT *  FROM J_ppto_prod_area WHERE mes =" & cbo_mes.SelectedIndex + 1 & " AND ano = " & cbo_ano.Text
            If (obj_Ing_prodLn.consultValor(sql, "PRODUCCION") = "") Then
                guardar_ppto_area()
            Else
                Dim resp As Integer = 0
                resp = MessageBox.Show("Ya existe presupeusto para: " & cbo_mes.SelectedIndex + 1 & "-" & cbo_ano.Text & " desea sobre-escribirlo? ", "Modificar presupuesto", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If resp = 6 Then
                    guardar_ppto_area()
                Else
                    llenarPptoArea()
                End If
            End If

        Else
            MessageBox.Show("Verifique que los valores ingresados sean númericos    ", "Verifique!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
    Private Sub btn_actualizar_Click(sender As Object, e As EventArgs) Handles btn_actualizar.Click
        carga_comp = False
        cargar_dias_habiles_otros()
        cargar_fechas_desc_otros()
        cargar_fechas_desc_otros_o()
        If tab_ppal.SelectedTab.Name = tab_prod.Name Then
            consultar()
        ElseIf tab_ppal.SelectedTab.Name = tab_area.Name Then
            consultar_ppto_area()
        ElseIf tab_ppal.SelectedTab.Name = tab_efic.Name Then
            consultar_efic_meta()
        ElseIf tab_ppal.SelectedTab.Name = tab_ausentismo.Name Then
            consultar_ausentismo()
        ElseIf tab_ppal.SelectedTab.Name = tab_extra.Name Then
            consultar_extra()
        Else
            consultar_ppto_detalle()
        End If
        carga_comp = True
    End Sub
    Private Sub soloNumero(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If (Char.IsDigit(e.KeyChar) Or e.KeyChar = ".") Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub dtg_ppto_detalle_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dtg_ppto_detalle.KeyPress
        soloNumero(e)
    End Sub
    Private Sub txt_dias_adic_otros_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_dias_adic_otros.KeyPress
        soloNumero(e)
    End Sub
    Private Sub txt_dias_habl_otros_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_dias_habl_otros.KeyPress
        soloNumero(e)
    End Sub
    Private Sub btnNuevo_Click(sender As Object, e As EventArgs)
        llenarDtg()
    End Sub
    Private Sub formatoDtg()
        Dim tamano_letra As Single = 9.0!
        For i = 0 To dtg_presupuesto.Columns.Count - 1
            If (dtg_presupuesto.Columns(i).Name = "id_cor") Then
                dtg_presupuesto.Columns(i).Visible = False
            ElseIf (dtg_presupuesto.Columns(i).Name = "linea_de_produccion") Then
                dtg_presupuesto.Columns(i).ReadOnly = True
            ElseIf (dtg_presupuesto.Columns(i).Name = "conversion") Then
                dtg_presupuesto.Columns(i).Visible = False
            ElseIf (dtg_presupuesto.Columns(i).Name = "tipo_conversion") Then
                dtg_presupuesto.Columns(i).ReadOnly = True
            End If
        Next
        dtg_presupuesto.Item("linea_de_produccion", dtg_presupuesto.Rows.Count - 1).Value = "TOTAL"
        dtg_presupuesto.Rows(dtg_presupuesto.Rows.Count - 1).DefaultCellStyle = objOperacionesForm.formatoNegrita(tamano_letra)
        dtg_presupuesto.Columns("linea_de_produccion").SortMode = DataGridViewColumnSortMode.NotSortable
        dtg_presupuesto.Columns("kilos").SortMode = DataGridViewColumnSortMode.NotSortable
        dtg_presupuesto.Rows(dtg_presupuesto.Rows.Count - 1).ReadOnly = True
        dtg_presupuesto.Columns("kilos").DefaultCellStyle.BackColor = Color.GreenYellow
    End Sub
    Private Sub formatoDtg_detalle()
        Dim tamano_letra As Single = 9.0!
        For i = 0 To dtg_ppto_detalle.Columns.Count - 1
            If (dtg_ppto_detalle.Columns(i).Name = "id_item") Then
                dtg_ppto_detalle.Columns(i).Visible = False
            End If
        Next
        dtg_ppto_detalle.Item("linea_de_produccion", dtg_ppto_detalle.Rows.Count - 1).Value = "TOTAL"
        dtg_ppto_detalle.Rows(dtg_ppto_detalle.Rows.Count - 1).DefaultCellStyle = objOperacionesForm.formatoNegrita(tamano_letra)
        dtg_ppto_detalle.Columns("linea_de_produccion").SortMode = DataGridViewColumnSortMode.NotSortable
        dtg_ppto_detalle.Columns("kilos").SortMode = DataGridViewColumnSortMode.NotSortable
        dtg_ppto_detalle.Rows(dtg_ppto_detalle.Rows.Count - 1).ReadOnly = True
        dtg_ppto_detalle.Columns("kilos").DefaultCellStyle.BackColor = Color.GreenYellow
    End Sub
    Private Sub formatoDtg_meta()
        Dim tamano_letra As Single = 9.0!
        dtg_efic_meta.Item("descripcion", dtg_efic_meta.Rows.Count - 1).Value = "TOTAL"
        dtg_efic_meta.Rows(dtg_efic_meta.Rows.Count - 1).DefaultCellStyle = objOperacionesForm.formatoNegrita(tamano_letra)
        dtg_efic_meta.Columns("presupuesto").SortMode = DataGridViewColumnSortMode.NotSortable
        dtg_efic_meta.Columns("presupuesto").DefaultCellStyle.Format = "N1"
        dtg_efic_meta.Columns("centro").ReadOnly = True
        dtg_efic_meta.Columns("descripcion").ReadOnly = True
    End Sub
    Private Sub formatoDtg_ausentismo()
        Dim tamano_letra As Single = 9.0!
        dtg_ausentismo.Item("descripcion", dtg_ausentismo.Rows.Count - 1).Value = "TOTAL"
        dtg_ausentismo.Rows(dtg_ausentismo.Rows.Count - 1).DefaultCellStyle = objOperacionesForm.formatoNegrita(tamano_letra)
        dtg_ausentismo.Columns("presupuesto").SortMode = DataGridViewColumnSortMode.NotSortable
        dtg_ausentismo.Columns("centro").ReadOnly = True
        dtg_ausentismo.Columns("descripcion").ReadOnly = True
    End Sub
    Private Sub formatoDtg_extra()
        Dim tamano_letra As Single = 9.0!
        dtg_extra.Item("descripcion", dtg_extra.Rows.Count - 1).Value = "TOTAL"
        dtg_extra.Rows(dtg_extra.Rows.Count - 1).DefaultCellStyle = objOperacionesForm.formatoNegrita(tamano_letra)
        dtg_extra.Columns("presupuesto").SortMode = DataGridViewColumnSortMode.NotSortable
        dtg_extra.Columns("centro").ReadOnly = True
        dtg_extra.Columns("descripcion").ReadOnly = True
    End Sub
    Private Sub formatoDtgArea()
        Dim tamano_letra As Single = 9.0!
        For i = 0 To dtg_ppto_area.Columns.Count - 1
            If (dtg_ppto_area.Columns(i).Name = "descripcion" Or dtg_ppto_area.Columns(i).Name = "centro") Then
                dtg_ppto_area.Columns(i).ReadOnly = True
            End If
        Next
        dtg_ppto_area.Item("descripcion", dtg_ppto_area.Rows.Count - 1).Value = "TOTAL"
        dtg_ppto_area.Rows(dtg_ppto_area.Rows.Count - 1).DefaultCellStyle = objOperacionesForm.formatoNegrita(tamano_letra)
        dtg_ppto_area.Columns("descripcion").SortMode = DataGridViewColumnSortMode.NotSortable
        dtg_ppto_area.Columns("kilos").SortMode = DataGridViewColumnSortMode.NotSortable
        dtg_ppto_area.Columns("cantidad").SortMode = DataGridViewColumnSortMode.NotSortable
        dtg_ppto_area.Columns("dias_habiles").SortMode = DataGridViewColumnSortMode.NotSortable
        dtg_ppto_area.Columns("dias_adicionales").SortMode = DataGridViewColumnSortMode.NotSortable
        dtg_ppto_area.Rows(dtg_ppto_area.Rows.Count - 1).ReadOnly = True

        'dtg_ppto_area.Columns("kilos").DefaultCellStyle.BackColor = Color.GreenYellow
    End Sub
    Private Sub totalizarDtg()
        Dim sum As Double = 0
        Dim nom_col As String = ""
        For j = 0 To dtg_presupuesto.Columns.Count - 1
            nom_col = dtg_presupuesto.Columns(j).Name
            If (nom_col = "kilos" Or nom_col = "cantidad") Then
                For i = 0 To dtg_presupuesto.Rows.Count - 2
                    If Not IsDBNull(dtg_presupuesto.Item(j, i).Value) Then
                        sum += dtg_presupuesto.Item(j, i).Value
                    End If
                Next
                dtg_presupuesto.Item(j, dtg_presupuesto.Rows.Count - 1).Value = sum
                sum = 0
            End If
        Next
    End Sub
    Private Sub totalizarDtg_Detalle()
        Dim sum As Double = 0
        Dim nom_col As String = ""
        For j = 0 To dtg_ppto_detalle.Columns.Count - 1
            nom_col = dtg_ppto_detalle.Columns(j).Name
            If (nom_col = "kilos") Then
                For i = 0 To dtg_ppto_detalle.Rows.Count - 2
                    If Not IsDBNull(dtg_ppto_detalle.Item(j, i).Value) Then
                        sum += dtg_ppto_detalle.Item(j, i).Value
                    End If
                Next
                dtg_ppto_detalle.Item(j, dtg_ppto_detalle.Rows.Count - 1).Value = sum
                sum = 0
            End If
        Next
    End Sub
    Private Sub totalizarDtg_meta()
        Dim sum As Double = 0
        Dim nom_col As String = ""
        For j = 0 To dtg_efic_meta.Columns.Count - 1
            nom_col = dtg_efic_meta.Columns(j).Name
            If (nom_col = "presupuesto") Then
                For i = 0 To dtg_efic_meta.Rows.Count - 2
                    If Not IsDBNull(dtg_efic_meta.Item(j, i).Value) Then
                        sum += dtg_efic_meta.Item(j, i).Value
                    End If
                Next
                dtg_efic_meta.Item(j, dtg_efic_meta.Rows.Count - 1).Value = sum
                sum = 0
            End If
        Next
    End Sub
    Private Sub totalizarDtg_ausentismo()
        Dim sum As Double = 0
        Dim nom_col As String = ""
        For j = 0 To dtg_ausentismo.Columns.Count - 1
            nom_col = dtg_ausentismo.Columns(j).Name
            If (nom_col = "presupuesto") Then
                For i = 0 To dtg_ausentismo.Rows.Count - 2
                    If Not IsDBNull(dtg_ausentismo.Item(j, i).Value) Then
                        sum += dtg_ausentismo.Item(j, i).Value
                    End If
                Next
                dtg_ausentismo.Item(j, dtg_ausentismo.Rows.Count - 1).Value = sum
                sum = 0
            End If
        Next
    End Sub
    Private Sub totalizarDtg_extra()
        Dim sum As Double = 0
        Dim nom_col As String = ""
        For j = 0 To dtg_extra.Columns.Count - 1
            nom_col = dtg_extra.Columns(j).Name
            If (nom_col = "presupuesto") Then
                For i = 0 To dtg_extra.Rows.Count - 2
                    If Not IsDBNull(dtg_extra.Item(j, i).Value) Then
                        sum += dtg_extra.Item(j, i).Value
                    End If
                Next
                dtg_extra.Item(j, dtg_extra.Rows.Count - 1).Value = sum
                sum = 0
            End If
        Next
    End Sub
    Private Sub totalizarDtgArea()
        Dim sum As Double = 0
        Dim nom_col As String = ""
        For j = 0 To dtg_ppto_area.Columns.Count - 1
            nom_col = dtg_ppto_area.Columns(j).Name
            If nom_col = "kilos" Then
                For i = 0 To dtg_ppto_area.Rows.Count - 2
                    If Not IsDBNull(dtg_ppto_area.Item(j, i).Value) Then
                        sum += dtg_ppto_area.Item(j, i).Value
                    End If
                Next
                dtg_ppto_area.Item(j, dtg_ppto_area.Rows.Count - 1).Value = sum
                sum = 0
            ElseIf nom_col = "cantidad" Then
                For i = 0 To dtg_ppto_area.Rows.Count - 2
                    If Not IsDBNull(dtg_ppto_area.Item(j, i).Value) Then
                        sum += dtg_ppto_area.Item(j, i).Value
                    End If
                Next
                dtg_ppto_area.Item(j, dtg_ppto_area.Rows.Count - 1).Value = sum
                sum = 0
            End If
        Next
    End Sub
    Private Sub dtg_ppto_detalle_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dtg_ppto_detalle.CellValueChanged
        If (e.RowIndex <> dtg_ppto_detalle.Rows.Count - 1) Then
            If (dtg_ppto_detalle.Columns(e.ColumnIndex).Name = "kilos") Then
                If IsNumeric(dtg_ppto_detalle.Item(e.ColumnIndex, e.RowIndex).Value) Then
                    If (carga_comp) Then
                        totalizarDtg_Detalle()
                    End If
                Else
                    carga_comp = False
                    dtg_ppto_detalle.Item(e.ColumnIndex, e.RowIndex).Value = 0
                    MessageBox.Show("Solo se permite el ingreso de valores numericos", "Verifique!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    carga_comp = True
                End If
            End If
        End If
    End Sub
    Private Sub dtg_efic_meta_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dtg_efic_meta.CellValueChanged
        If (e.RowIndex <> dtg_efic_meta.Rows.Count - 1) Then
            If (dtg_efic_meta.Columns(e.ColumnIndex).Name = "presupuesto") Then
                If IsNumeric(dtg_efic_meta.Item(e.ColumnIndex, e.RowIndex).Value) Then
                    If (carga_comp) Then
                        totalizarDtg_meta()
                    End If
                Else
                    carga_comp = False
                    dtg_efic_meta.Item(e.ColumnIndex, e.RowIndex).Value = 0
                    MessageBox.Show("Solo se permite el ingreso de valores numericos", "Verifique!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    carga_comp = True
                End If
            End If
        End If
    End Sub
    Private Sub dtg_ausentismo_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dtg_ausentismo.CellValueChanged
        If (e.RowIndex <> dtg_ausentismo.Rows.Count - 1) Then
            If (dtg_ausentismo.Columns(e.ColumnIndex).Name = "presupuesto") Then
                If IsNumeric(dtg_ausentismo.Item(e.ColumnIndex, e.RowIndex).Value) Then
                    If (carga_comp) Then
                        totalizarDtg_ausentismo()
                    End If
                Else
                    carga_comp = False
                    dtg_ausentismo.Item(e.ColumnIndex, e.RowIndex).Value = 0
                    MessageBox.Show("Solo se permite el ingreso de valores numericos", "Verifique!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    carga_comp = True
                End If
            End If
        End If
    End Sub
    Private Sub dtg_extra_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dtg_extra.CellValueChanged
        If (e.RowIndex <> dtg_extra.Rows.Count - 1) Then
            If (dtg_extra.Columns(e.ColumnIndex).Name = "presupuesto") Then
                If IsNumeric(dtg_extra.Item(e.ColumnIndex, e.RowIndex).Value) Then
                    If (carga_comp) Then
                        totalizarDtg_extra()
                    End If
                Else
                    carga_comp = False
                    dtg_extra.Item(e.ColumnIndex, e.RowIndex).Value = 0
                    MessageBox.Show("Solo se permite el ingreso de valores numericos", "Verifique!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    carga_comp = True
                End If
            End If
        End If
    End Sub
    Private Sub dtg_presupuesto_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dtg_presupuesto.CellValueChanged
        If (e.RowIndex <> dtg_presupuesto.Rows.Count - 1) Then
            If (dtg_presupuesto.Columns(e.ColumnIndex).Name = "kilos") Then
                If IsNumeric(dtg_presupuesto.Item(e.ColumnIndex, e.RowIndex).Value) Then
                    If (carga_comp) Then
                        totalizarDtg()
                        calcularConversion()
                    End If
                Else
                    carga_comp = False
                    dtg_presupuesto.Item(e.ColumnIndex, e.RowIndex).Value = 0
                    MessageBox.Show("Solo se permite el ingreso de valores numericos", "Verifique!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    carga_comp = True
                End If
            End If
        End If
    End Sub
    Private Sub dtg_ppto_area_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dtg_ppto_area.CellValueChanged
        If (e.RowIndex <> dtg_ppto_area.Rows.Count - 1) Then
            If (dtg_ppto_area.Columns(e.ColumnIndex).Name = "kilos") Then
                If IsNumeric(dtg_ppto_area.Item(e.ColumnIndex, e.RowIndex).Value) Then
                    If (carga_comp) Then
                        totalizarDtgArea()
                        conversion_DtgArea()
                    End If
                Else
                    carga_comp = False
                    dtg_ppto_area.Item(e.ColumnIndex, e.RowIndex).Value = 0
                    MessageBox.Show("Solo se permite el ingreso de valores numericos", "Verifique!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    carga_comp = True
                End If
            End If
        End If
    End Sub
    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        objOperacionesForm.ExportarDatosExcel(dtg_ppto_detalle, "Seguimiento presupuesto de producción")
    End Sub



    Private Sub btnNuevo_Click_1(sender As Object, e As EventArgs) Handles btnNuevo.Click
        If tab_ppal.SelectedTab.Name = tab_prod.Name Then
            llenarDtg()
        ElseIf tab_ppal.SelectedTab.Name = tab_area.Name Then
            llenarPptoArea()
        Else
            llenarDtg_Detalle()
        End If
    End Sub

    Private Sub txtDiasHabil_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDiasHabil.KeyPress
        soloNumero(e)
    End Sub

    Private Sub txtDiasAdic_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDiasAdic.KeyPress
        If (e.KeyChar.ToString <> ".") Then
            soloNumero(e)
        End If
    End Sub
    Private Sub cargarPptoArea()

    End Sub
    Private Sub armarDtArea()
        Dim dt As New DataTable
        Dim sql As String = "SELECT centro,descripcion " & _
                                "FROM centros " & _
                                     "WHERE centro IN (2100,2200,2300,2400,2500,2600,2800,5200,6200,6400)"
        dt = obj_Ing_prodLn.listar_datatable(sql, "CORSAN")
    End Sub
    Private Sub llenarPptoArea()
        dtg_ppto_area.DataSource = Nothing
        dtg_ppto_area.Columns.Clear()
        dtg_ppto_area.Columns.Add("centro", "centro")
        dtg_ppto_area.Columns.Add("descripcion", "descripcion")
        dtg_ppto_area.Columns.Add("kilos", "kilos")
        dtg_ppto_area.Columns.Add("cantidad", "cantidad")
        dtg_ppto_area.Columns.Add("dias_habiles", "dias_habiles")
        dtg_ppto_area.Columns.Add("dias_adicionales", "dias_adicionales")
        Dim sql As String = "SELECT centro,descripcion " &
                            "FROM centros " &
                                 "WHERE centro IN (2100,2200,2300,2400,2500,2600,2800,5200,5300,5400,6200,6400)"
        Dim dt_centros As DataTable = obj_op_simplesLn.listar_datatable(sql, "CORSAN")
        For i = 0 To dt_centros.Rows.Count - 1
            dtg_ppto_area.Rows.Add()
            dtg_ppto_area.Item("centro", i).Value = dt_centros.Rows(i).Item("centro")
            dtg_ppto_area.Item("descripcion", i).Value = dt_centros.Rows(i).Item("descripcion")
            dtg_ppto_area.Item("kilos", i).Value = 0
            dtg_ppto_area.Item("cantidad", i).Value = 0
            dtg_ppto_area.Item("dias_habiles", i).Value = 0
            dtg_ppto_area.Item("dias_adicionales", i).Value = 0
        Next
        dtg_ppto_area.Rows.Add()
        formatoDtgArea()
        totalizarDtgArea()

    End Sub
    Private Sub guardar_ppto_area()
        dtg_ppto_area.CurrentCell = Nothing
        Dim listSql As New List(Of Object)
        listSql.AddRange(guardar_dias_habil_otros)
        listSql.AddRange(guardar_fechas_desc_otros)
        listSql.AddRange(guardar_fechas_desc_otros_o)
        Dim ano As Integer = cbo_ano.Text
        Dim mes As Integer = cbo_mes.SelectedIndex + 1
        Dim sql_gral As String = "INSERT INTO J_ppto_prod_area (ano,mes,notas,dias_habiles,dias_adicionales,centro,kilos,cantidad) VALUES (" & ano & "," & mes & ",' usuario:" & usuario.nombre & "'"
        Dim sql As String = ""
        Dim sql_delete As String = "DELETE FROM J_ppto_prod_area WHERE mes =" & cbo_mes.SelectedIndex + 1 & " AND ano = " & cbo_ano.Text
        listSql.Add(sql_delete)
        For i = 0 To dtg_ppto_area.Rows.Count - 2
            sql = sql_gral & "," & dtg_ppto_area.Item("dias_habiles", i).Value & "," & dtg_ppto_area.Item("dias_adicionales", i).Value & "," & dtg_ppto_area.Item("centro", i).Value & "," & dtg_ppto_area.Item("kilos", i).Value & "," & dtg_ppto_area.Item("cantidad", i).Value & ")"
            listSql.Add(sql)
        Next
        If (obj_Ing_prodLn.ExecuteSqlTransaction(listSql, "PRODUCCION")) Then
            MessageBox.Show("El registro se guardo en forma exitosa!", "Exito!", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Error al ingresar el registro, comuniquese con el area de sistemas", "Verifique!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Private Sub consultar_ppto_area()
        dtg_ppto_area.Columns.Clear()
        Dim dt As New DataTable
        Dim sql As String = "SELECT c.centro,c.descripcion,p.kilos,p.cantidad,p.dias_habiles,p.dias_adicionales " &
                                        "FROM J_ppto_prod_area p , CORSAN.dbo.centros  c " &
                                            "WHERE p.centro = c.centro AND mes =" & cbo_mes.SelectedIndex + 1 & " AND ano = " & cbo_ano.Text & " " &
                                                "ORDER BY p.centro "
        dt = obj_Ing_prodLn.listar_datatable(sql, "PRODUCCION")
        dtg_ppto_area.DataSource = dt
        dt.Rows.Add()
        formatoDtgArea()
        conversion_DtgArea()
        totalizarDtgArea()
        If dt.Rows.Count = 1 Then
            llenarPptoArea()
        End If
        For j = 0 To dtg_ppto_area.Columns.Count - 1
            If dtg_ppto_area.Columns(j).Name = "dias_habiles" Or dtg_ppto_area.Columns(j).Name = "dias_adicionales" Then
                dtg_ppto_area.Columns(j).DefaultCellStyle.BackColor = Color.LightSalmon
            ElseIf (dtg_ppto_area.Columns(j).Name = "cantidad") Then
                dtg_ppto_area.Columns(j).ReadOnly = False
            End If
        Next
    End Sub
    Private Sub conversion_DtgArea()
        Dim sum As Integer
        For i = 0 To dtg_ppto_area.Rows.Count - 2
            If dtg_ppto_area.Item("centro", i).Value = 2300 Then
                For j = 0 To dtg_presupuesto.Rows.Count - 2
                    If dtg_presupuesto.Item("id_cor", j).Value = 8 Or dtg_presupuesto.Item("id_cor", j).Value = 9 Or
                       dtg_presupuesto.Item("id_cor", j).Value = 10 Or dtg_presupuesto.Item("id_cor", j).Value = 11 Or
                       dtg_presupuesto.Item("id_cor", j).Value = 12 Or dtg_presupuesto.Item("id_cor", j).Value = 13 Or
                       dtg_presupuesto.Item("id_cor", j).Value = 14 Or dtg_presupuesto.Item("id_cor", j).Value = 15 Or
                       dtg_presupuesto.Item("id_cor", j).Value = 16 Then
                        sum += dtg_presupuesto.Item("cantidad", j).Value
                    End If
                Next
                dtg_ppto_area.Item("cantidad", i).Value = sum
                sum = 0
            ElseIf dtg_ppto_area.Item("centro", i).Value = 6400 Then
                For j = 0 To dtg_presupuesto.Rows.Count - 2
                    If dtg_presupuesto.Item("id_cor", j).Value = 5 Then
                        sum = dtg_presupuesto.Item("cantidad", j).Value
                    End If
                Next
                dtg_ppto_area.Item("cantidad", i).Value = sum
                sum = 0
            ElseIf dtg_ppto_area.Item("centro", i).Value = 2500 Then
                For j = 0 To dtg_presupuesto.Rows.Count - 2
                    If dtg_presupuesto.Item("id_cor", j).Value = 19 Or dtg_presupuesto.Item("id_cor", j).Value = 20 Or
                        dtg_presupuesto.Item("id_cor", j).Value = 21 Or dtg_presupuesto.Item("id_cor", j).Value = 22 Or
                        dtg_presupuesto.Item("id_cor", j).Value = 23 Or dtg_presupuesto.Item("id_cor", j).Value = 24 Then
                        sum += dtg_presupuesto.Item("cantidad", j).Value
                    End If
                Next
                dtg_ppto_area.Item("cantidad", i).Value = sum
                sum = 0
            Else
                dtg_ppto_area.Item("cantidad", i).Value = dtg_ppto_area.Item("kilos", i).Value
            End If
        Next
    End Sub
    Private Sub txt_ppto_consumo_KeyPress(sender As Object, e As KeyPressEventArgs)
        soloNumero(e)
    End Sub

    Private Sub txt_ppto_reproceso_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_ppto_reproceso.KeyPress
        soloNumero(e)
    End Sub
    Private Function guardar_dias_habil_otros() As List(Of Object)
        Dim listSql As New List(Of Object)
        Dim ano As Integer = cbo_ano.Text
        Dim mes As Integer = cbo_mes.SelectedIndex + 1
        Dim dias_habil As Double = txt_dias_habl_otros.Text
        Dim dias_adic As Double = txt_dias_adic_otros.Text
        Dim sql As String = "INSERT INTO J_ppto_prod_dias_hab_otros (ano,mes,dias_habiles,dias_adic) VALUES (" & ano & "," & mes & ",'" & dias_habil & "','" & dias_adic & "')"
        Dim sql_delete As String = "DELETE FROM J_ppto_prod_dias_hab_otros WHERE mes =" & mes & " AND ano = " & ano
        listSql.Add(sql_delete)
        listSql.Add(sql)
        Return listSql
    End Function
    Private Sub cargar_dias_habiles_otros()
        Dim ano As Integer = cbo_ano.Text
        Dim mes As Integer = cbo_mes.SelectedIndex + 1
        Dim sql As String = "SELECT dias_habiles,dias_adic FROM J_ppto_prod_dias_hab_otros WHERE mes =" & mes & " AND ano = " & ano
        Dim dt As DataTable = obj_op_simplesLn.listar_datatable(sql, "PRODUCCION")
        For i = 0 To dt.Rows.Count - 1
            txt_dias_habl_otros.Text = dt.Rows(i).Item("dias_habiles")
            txt_dias_adic_otros.Text = dt.Rows(i).Item("dias_adic")
        Next
    End Sub


    Private Sub dtg_fechas_desc_otros_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtg_fechas_desc_otros.CellClick
        If dtg_fechas_desc_otros.Columns(e.ColumnIndex).Name = col_add_fec.Name Then
            dtg_fechas_desc_otros.Rows.Add()
            cboCal.Visible = True
        ElseIf dtg_fechas_desc_otros.Columns(e.ColumnIndex).Name = col_eliminar_fec.Name Then
            dtg_fechas_desc_otros.CurrentCell = Nothing
            dtg_fechas_desc_otros.Rows.RemoveAt(e.RowIndex)
        End If
    End Sub

    Private Sub cboCal_DateSelected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DateRangeEventArgs) Handles cboCal.DateSelected
        Dim resp As Boolean = True
        For i = 0 To dtg_fechas_desc_otros.RowCount - 1
            If IsDate(dtg_fechas_desc_otros.Item("fecha", i).Value) Then
                If dtg_fechas_desc_otros.Item("fecha", i).Value = cboCal.SelectionEnd.Date Then
                    resp = False
                End If
            End If
        Next
        If resp Then
            dtg_fechas_desc_otros.Item("fecha", dtg_fechas_desc_otros.CurrentCell.RowIndex).Value = (cboCal.SelectionEnd.Date)
        Else
            MessageBox.Show("La fecha seleccionada ya existe", "Verifique!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

        cboCal.Visible = False
    End Sub
    Private Sub cargar_fechas_desc_otros()
        dtg_fechas_desc_otros.DataSource = Nothing
        Dim ano As Integer = cbo_ano.Text
        Dim mes As Integer = cbo_mes.SelectedIndex + 1
        Dim sql As String = "SELECT fecha FROM J_ppto_prod_fec_descanso_otros WHERE mes =" & mes & " AND ano = " & ano
        Dim dt As DataTable = obj_op_simplesLn.listar_datatable(sql, "PRODUCCION")
        For i = 0 To dt.Rows.Count - 1
            dtg_fechas_desc_otros.Rows.Add()
            dtg_fechas_desc_otros.Item("fecha", dtg_fechas_desc_otros.Rows.Count - 1).Value = dt.Rows(i).Item("fecha")
        Next
        dtg_fechas_desc_otros.Columns("fecha").DefaultCellStyle.Format = "d"
        dtg_fechas_desc_otros.Rows.Add()
    End Sub
    Private Sub cargar_fechas_desc_otros_o()
        dtg_fechas_desc_otros.DataSource = Nothing
        Dim ano As Integer = cbo_ano.Text
        Dim mes As Integer = cbo_mes.SelectedIndex + 1
        Dim sql As String = "SELECT fecha FROM J_ppto_prod_vac_planta WHERE mes =" & mes & " AND ano = " & ano
        Dim dt As DataTable = obj_op_simplesLn.listar_datatable(sql, "PRODUCCION")
        For i = 0 To dt.Rows.Count - 1
            DataGridView1.Rows.Add()
            DataGridView1.Item("fecha_o", DataGridView1.Rows.Count - 1).Value = dt.Rows(i).Item("fecha")
        Next
        DataGridView1.Columns("fecha_o").DefaultCellStyle.Format = "d"
        DataGridView1.Rows.Add()
    End Sub
    Private Function guardar_fechas_desc_otros() As List(Of Object)
        Dim listSql As New List(Of Object)
        Dim ano As Integer = cbo_ano.Text
        Dim mes As Integer = cbo_mes.SelectedIndex + 1
        Dim sql As String = "INSERT INTO J_ppto_prod_fec_descanso_otros (ano,mes,fecha) VALUES (" & ano & "," & mes & ","
        Dim sql_total As String = ""
        Dim sql_delete As String = "DELETE FROM J_ppto_prod_fec_descanso_otros WHERE mes =" & mes & " AND ano = " & ano
        listSql.Add(sql_delete)
        For i = 0 To dtg_fechas_desc_otros.RowCount - 1
            If IsDate(dtg_fechas_desc_otros.Item("fecha", i).Value) Then
                sql_total = sql & "'" & obj_op_simplesLn.cambiarFormatoFecha(dtg_fechas_desc_otros.Item("fecha", i).Value) & "')"
                listSql.Add(sql_total)
            End If
        Next
        Return listSql
    End Function
    Private Function guardar_fechas_desc_otros_o() As List(Of Object)
        Dim listSql As New List(Of Object)
        Dim ano As Integer = cbo_ano.Text
        Dim mes As Integer = cbo_mes.SelectedIndex + 1
        Dim sql As String = "INSERT INTO J_ppto_prod_vac_planta (ano,mes,fecha) VALUES (" & ano & "," & mes & ","
        Dim sql_total As String = ""
        Dim sql_delete As String = "DELETE FROM J_ppto_prod_vac_planta WHERE mes =" & mes & " AND ano = " & ano
        listSql.Add(sql_delete)
        For i = 0 To DataGridView1.RowCount - 1
            If IsDate(DataGridView1.Item("fecha_o", i).Value) Then
                sql_total = sql & "'" & obj_op_simplesLn.cambiarFormatoFecha(DataGridView1.Item("fecha_o", i).Value) & "')"
                listSql.Add(sql_total)
            End If
        Next
        Return listSql
    End Function


    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If DataGridView1.Columns(e.ColumnIndex).Name = col_add_fec_o.Name Then
            DataGridView1.Rows.Add()
            MonthCalendar1.Visible = True
        ElseIf DataGridView1.Columns(e.ColumnIndex).Name = col_eliminar_fec_o.Name Then
            DataGridView1.CurrentCell = Nothing
            DataGridView1.Rows.RemoveAt(e.RowIndex)
        End If
    End Sub

    Private Sub MonthCalendar1_DateSelected(sender As Object, e As DateRangeEventArgs) Handles MonthCalendar1.DateSelected
        Dim resp As Boolean = True
        For i = 0 To DataGridView1.RowCount - 1
            If IsDate(DataGridView1.Item("fecha_o", i).Value) Then
                If DataGridView1.Item("fecha_o", i).Value = cboCal.SelectionEnd.Date Then
                    resp = False
                End If
            End If
        Next
        If resp Then
            DataGridView1.Item("fecha_o", DataGridView1.CurrentCell.RowIndex).Value = (MonthCalendar1.SelectionEnd.Date)
        Else
            MessageBox.Show("La fecha seleccionada ya existe", "Verifique!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

        MonthCalendar1.Visible = False
    End Sub
End Class
