Imports logicaNegocios
Imports System.IO
Imports Microsoft.Office.Interop
Imports entidadNegocios
Imports accesoDatos

Public Class FrmSegVendAct
    Private objUsuarioLn As New UsuarioLn
    Private objOpSimplesLn As New Op_simpesLn
    Private objUsuarioEn As New UsuarioEn
    Private mes As Integer = 0
    Private ano As Integer = 0
    Dim usuario_vendedor As Integer
    Private objOperacionesForm As OperacionesFormularios = New OperacionesFormularios
    Private objNuevLn As New SegVendLn
    Private obj_anticipoLn As New anticipoLn
    Private nom_modulo As String = ""
    Private columnaArbol As String
    Private permiso As String = ""
    Private dt_columnas_permiso As New DataTable


    Public Sub Main(ByVal nom_modulo As String, ByVal objUsuarioEn As UsuarioEn)
        Me.nom_modulo = nom_modulo
        Me.objUsuarioEn = objUsuarioEn
        Me.permiso = objUsuarioEn.permiso.Trim
        If (permiso <> "ADMIN") Then
            btnContCambios.Visible = False
            btnConfigPermisos.Visible = False
        Else
            Dim sql As String = "SELECT descripcion  FROM J_spic_permiso "
            cargarLista(listaTipoUsu, sql)
            cargar_columnas_permisos()
        End If
        usuario_vendedor = objUsuarioEn.Vendedor
        If (usuario_vendedor = 1020) Then
            chk_inter.Visible = True
        End If
        If (usuario_vendedor = 1047) Then
            btn_consultas.Visible = False
            btnRefNoClas.Visible = False
        End If
        Dim sql_columnas As String = "SELECT columna " & _
                                       "FROM J_spic_per_columna_seguimiento " & _
                                           "WHERE permiso = '" & permiso & "' "
        dt_columnas_permiso = objOpSimplesLn.listar_datatable(sql_columnas, "CORSAN")
    End Sub
    Private Sub cargarLista(ByVal lista As ListBox, ByVal sql As String)
        lista.Items.Clear()
        Dim list As New List(Of Object)
        list = objOpSimplesLn.lista(sql)
        For i = 0 To list.Count - 1
            lista.Items.Add(list(i))
        Next
    End Sub
    Private Sub cargar_columnas_permisos()
        listColumnas.Items.Add("Vendedor")
        listColumnas.Items.Add("Ventas")
        listColumnas.Items.Add("Pres_Ventas")
        listColumnas.Items.Add("Pend")
        listColumnas.Items.Add("No_reflej")
        listColumnas.Items.Add("Rec")
        listColumnas.Items.Add("colAnt")
        listColumnas.Items.Add("Pres_rec")
        listColumnas.Items.Add("Dev")
        listColumnas.Items.Add("chequesDev")
        listColumnas.Items.Add("porCumVtas")
        listColumnas.Items.Add("porCumRec")
        listColumnas.Items.Add("porDev")
        listColumnas.Items.Add("Por_util")
        listColumnas.Items.Add("col_debe_llevar_vtas")
        listColumnas.Items.Add("col_porc_hoy_vtas")
        listColumnas.Items.Add("col_debe_llevar_rec")
        listColumnas.Items.Add("col_porc_hoy_rec")

    End Sub
    Private Sub btnContCambios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnContCambios.Click
        FrmAuditCambios.Show()
        FrmAuditCambios.Main(nom_modulo)
        FrmAuditCambios.WindowState = 2
    End Sub
    Private Sub FrmSegVendAct_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cboAño.Items.Add(Now.Year)
        cboAño.Items.Add(Now.Year - 1)
        cboAño.SelectedIndex = 0
        cboMes.SelectedIndex = Now.Month - 1
        Me.CenterToScreen()
        imgProcesar.Visible = False
        labelcontar()
        terceros_No_Clasificados()
    End Sub
    'trae el total de registros de una consulta
    Public Sub labelcontar()
        Dim i As Integer
        Dim a As New ClasificacionAd
        i = a.contarregistros
        LinkLabel1.Text = "Productos sin clasificar:" & i
        If i = 0 Then
            LinkLabel1.LinkColor = Color.Green
        Else
            LinkLabel1.LinkColor = Color.Red
        End If
    End Sub
    Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
        imgProcesar.Visible = True
        Application.DoEvents()
        dtgSegVend.Rows.Clear()
        mes = cboMes.SelectedIndex + 1
        ano = cboAño.Text
        Dim criterio As String
        If (chkKil.Checked = True) Then
            criterio = "kilos"
        Else
            criterio = "vr_total"
        End If
        listarSeg(criterio)
        imgProcesar.Visible = False
    End Sub
    Private Sub listarSeg(ByVal criterio As String)
        Dim vendedores As String = objUsuarioLn.coordinadorVend(objUsuarioEn.usuario)
        Dim listVend As New List(Of Object)
        Dim vendMin As Integer = 0
        Dim vendMax As Integer = 0
        Dim mat(,) As Object
        Dim tam As Integer = 0
        Dim sql As String = ""
        Dim sqlVend As String = ""
        Dim inter As Boolean = chk_inter.Checked
        Dim criterioVendedor As String = ""
        Dim criterioVendNit As String = ""
        Dim dias_trabajados As Double = 0
        Dim fec_fin As String = objOpSimplesLn.cambiarFormatoFecha(DateSerial(ano, mes + 1, 1 - 1))
        Dim dias_habiles As Double = objOpSimplesLn.calcDiasHabilesVentas(ano & "-" & mes & "-01", fec_fin)
        dias_habiles -= objOpSimplesLn.cant_festivos_mes(mes, ano)
        If (usuario_vendedor = 1020) Then
            vendMax = 1095
            vendMin = 1001
            If (vendedores <> "") Then
                criterioVendedor = "vendedor in (" & vendedores & ")"
                criterioVendNit = "nit in (" & vendedores & ")"
            Else
                vendMin = 1001
                If (inter) Then
                    vendMax = 1099
                Else
                    vendMax = 1095
                End If
                criterioVendedor = "vendedor >= " & vendMin & " AND vendedor <= " & vendMax & ""
                criterioVendNit = "nit >= " & vendMin & " AND nit <= " & vendMax & ""
            End If
            sqlVend = "SELECT  vendedor " & _
                             "FROM v_vendedores " & _
                                "WHERE " & criterioVendedor & " AND bloqueo = 0  ORDER BY vendedor"
            listVend = objOpSimplesLn.lista(sqlVend)
            If (vendedores <> "") Then
                criterioVendedor = "vendedor in ("
                For i = 0 To listVend.Count - 1
                    criterioVendedor &= listVend(i)
                    If (i <> listVend.Count - 1) Then
                        criterioVendedor &= ","
                    End If
                Next
                criterioVendedor &= ") "
            End If
        Else
            listVend.Add(usuario_vendedor)
            vendMin = usuario_vendedor
            vendMax = usuario_vendedor
            criterioVendedor = "vendedor >= " & vendMin & " AND vendedor <= " & vendMax & " "
            criterioVendNit = "nit >= " & vendMin & " AND nit <= " & vendMax & ""
        End If
        tam = listVend.Count - 1
        For i = 0 To tam
            dtgSegVend.Rows.Add()
            dtgSegVend.Item("Vendedor", i).Value = listVend(i)
        Next


        dtgSegVend.Rows.Add()
        dtgSegVend.Item("Vendedor", dtgSegVend.RowCount - 1).Value = "TOTAL"

        sql = "SELECT vtas.vendedor, SUM (vtas." & criterio & " )AS ventas " & _
                    "FROM Jjv_V_vtas_vend_cliente_ref vtas " & _
                        "WHERE (Month(vtas.fec) = " & mes & " And Year(vtas.fec) = " & ano & " AND " & criterioVendedor & " ) " & _
                          "GROUP BY vtas.vendedor"
        mat = objOpSimplesLn.matriz(sql, tam, 1)
        agregarMatriz(mat, "Ventas")
        sql = "select vendedor,SUM (Vr_total )As ppto " & _
                                "from Jjv_Ppto_mes " & _
                                    "where(Month(Fecha_ppto) = " & mes & " And Year(Fecha_ppto) = " & ano & " AND " & criterioVendedor & ") " & _
                                        "group by Vendedor "
        mat = objOpSimplesLn.matriz(sql, tam, 1)
        agregarMatriz(mat, "Pres_Ventas")
        mat = objOpSimplesLn.matriz(sql, tam, 1)
        sql = "SELECT vendedor,SUM (" & criterio & " ) " & _
                "FROM j_v_pend_vend   " & _
                  "WHERE  " & criterioVendedor & " " & _
                         "GROUP BY vendedor"
        mat = objOpSimplesLn.matriz(sql, tam, 1)
        agregarMatriz(mat, "Pend")
        sql = "SELECT vendedor,SUM (valor_total ) " & _
                  "FROM J_v_pend_noreflejados " & _
                   "WHERE  anulado = 0 AND (" & criterioVendedor & ") " & _
                        "GROUP BY vendedor"
        mat = objOpSimplesLn.matriz(sql, tam, 1)
        agregarMatriz(mat, "No_reflej")
        'Arreglo temporal recaudos
        Dim UltimoDiaDelMes As Date
        UltimoDiaDelMes = DateSerial(ano, mes + 1, 0)
        sql = "SELECT vendedor ,SUM (Total_rec) " &
                    "FROM Jjv_Recaudos_consol " &
                        "WHERE(fecha >='" & ano & "-" & mes & "-01 00:00:00' and fecha <='" & ano & "-" & mes & "-" & UltimoDiaDelMes.Day & " 00:00:00'  AND (" & criterioVendedor & ")) " &
                     "GROUP BY vendedor"
        mat = objOpSimplesLn.matriz(sql, tam, 1)
        agregarMatriz(mat, "Rec")
        sql = "SELECT nit, SUM (Ppto_total ) " & _
                              "FROM Jjv_ppto_vtas_recaudos_consol ppto " & _
                               "WHERE(mes = " & mes & " And año = " & ano & " AND (" & criterioVendNit & ")) " & _
                                   "GROUP BY nit "
        mat = objOpSimplesLn.matriz(sql, tam, 1)
        agregarMatriz(mat, "Pres_rec")

        sql = "SELECT vendedor,SUM(" & criterio & " ) " & _
                        "FROM Jjv_V_vtas_vend_cliente_ref  " & _
                        "WHERE(Month(fec) = " & mes & " And Year(fec) = " & ano & " And sw = 2 AND (" & criterioVendedor & ")) " & _
                     "GROUP BY vendedor "
        mat = objOpSimplesLn.matriz(sql, tam, 1)
        agregarMatriz(mat, "Dev")

        sql = "SELECT vendedor,SUM (valor_total) " & _
                          "FROM documentos " & _
                            "WHERE tipo IN ('NDCH') AND MONTH (fecha )= " & mes & " and YEAR (fecha )= " & ano & " AND (" & criterioVendedor & ") " & _
                             "GROUP BY vendedor "
        mat = objOpSimplesLn.matriz(sql, tam, 1)
        agregarMatriz(mat, "chequesDev")

        'anticipos
        sql = "SELECT vendedor ,SUM (valor_total)-SUM (valor_aplicado) as saldo " & _
                                                "FROM documentos " & _
                                                        "WHERE nit= nit AND sw Like '5' AND  (" & criterioVendedor & ") AND tipo IN ('RCR1','RCO1','RCEX') AND  MONTH(fecha)=" & mes & " AND  YEAR(fecha)=" & ano & " AND(valor_total > valor_aplicado or (iva_fletes <0   AND valor_total=valor_aplicado)) " & _
                                                                "group by vendedor"
        mat = objOpSimplesLn.matriz(sql, tam, 1)
        agregarMatriz(mat, "colAnt")


        sql = " SELECT vendedor,SUM (Cto_total) as Cto_total,SUM (Vr_total ) as Vr_total " & _
                    "FROM Jjv_V_vtas_vend_cliente_ref  " & _
                        "WHERE(Month(fec) = " & mes & " And Year(fec) = " & ano & ") AND (" & criterioVendedor & ") " & _
                          "group by vendedor  "
        mat = objOpSimplesLn.matriz(sql, tam, 2)
        porc_util(mat)

        eliminarInactivos()
        'If (objUsuarioEn.usuario = "ventas14" Or objUsuarioEn.usuario = "JESUSAL") Then
        '    ocultarPorCoordinador(objUsuarioEn.usuario)
        'End If
        pintarCeldas()

        sumar_col_grid("Ventas")
        sumar_col_grid("Pres_Ventas")
        sumar_col_grid("Pend")
        sumar_col_grid("No_reflej")
        sumar_col_grid("Rec")
        sumar_col_grid("Pres_rec")
        sumar_col_grid("Dev")
        sumar_col_grid("chequesDev")
        sumar_col_grid("colAnt")
        restarChequesDev()
        sumarAnticipos()
        calcPorcCumpl("Ventas", "Pres_Ventas", "porCumVtas")
        calcPorcCumpl("Rec", "Pres_rec", "porCumRec")
        calcPorcCumpl("Dev", "Ventas", "porDev")

        porUtilGral(criterioVendedor)
        If (objUsuarioEn.usuario = "JESUSAL") Then
            dtgSegVend.Columns("Por_util").Visible = False
        End If
        If (objUsuarioEn.permiso.Trim <> "ADMIN") Then
            If (objUsuarioEn.permiso.Trim <> "COOR_VTAS" And objUsuarioEn.permiso.Trim <> "ADMIN_VTAS") Then
                dtgSegVend.Columns("Por_util").Visible = False
            End If
        Else
            'calc_comisiones()
        End If
        If (mes <> Now.Month) Then
            dias_trabajados = dias_habiles
        Else
            dias_trabajados = objOpSimplesLn.calcDiasHabilesVentas(ano & "-" & mes & "-01", ano & "-" & mes & "-" & Now.Day)
            dias_trabajados -= objOpSimplesLn.cant_festivos(Now.Day, mes, ano)
        End If
        calcular_ppto_a_hoy(dias_trabajados, dias_habiles, "Ventas", "Pres_Ventas", "col_debe_llevar_vtas", "col_porc_hoy_vtas")
        calcular_ppto_a_hoy(dias_trabajados, dias_habiles, "Rec", "Pres_rec", "col_debe_llevar_rec", "col_porc_hoy_rec")

        sumar_col_grid("col_debe_llevar_vtas")
        sumar_col_grid("col_debe_llevar_rec")
        calcPorcCumpl("Rec", "col_debe_llevar_rec", "col_porc_hoy_rec")
        calcPorcCumpl("Ventas", "col_debe_llevar_vtas", "col_porc_hoy_vtas")
        lbl_dias_habiles.Text = "Días habiles: " & dias_habiles
        lbl_dias_trab.Text = "Días trabajados: " & dias_trabajados

        validarColPermiso()
        alertas()
        nomb_vendedores()
    End Sub
    Private Sub calcular_ppto_a_hoy(ByVal dias_trabajados As Double, ByVal dias_habiles As Double, nom_col_cantidad As String, nom_col_ppto As String, nom_col_debe_llevar As String, nom_col_porc As String)
        Dim ppto As Double = 0
        Dim ppto_por_dia As Double = 0
        For i = 0 To dtgSegVend.Rows.Count - 2
            If Not IsDBNull(dtgSegVend.Item(nom_col_ppto, i).Value) Then
                ppto = dtgSegVend.Item(nom_col_ppto, i).Value
                ppto_por_dia = ppto / dias_habiles
                dtgSegVend.Item(nom_col_debe_llevar, i).Value = ppto_por_dia * dias_trabajados
                If Not IsDBNull(dtgSegVend.Item(nom_col_cantidad, i).Value) Then
                    dtgSegVend.Item(nom_col_porc, i).Value = (dtgSegVend.Item(nom_col_cantidad, i).Value / dtgSegVend.Item(nom_col_debe_llevar, i).Value) * 100
                End If
            End If
        Next
    End Sub
    Private Sub nomb_vendedores()
        Dim sql_nomb_vendedores As String = "SELECT nit,nombres FROM terceros WHERE nit >=1001 and nit <=1099"
        Dim dt_nom_vendedores As DataTable = objOpSimplesLn.listar_datatable(sql_nomb_vendedores, "CORSAN")
        For j = 0 To dtgSegVend.Columns.Count - 1
            If dtgSegVend.Columns(j).Name = "Vendedor" Then
                For i = 0 To dtgSegVend.Rows.Count - 2
                    If Not IsDBNull(dtgSegVend.Item(j, i).Value) Then
                        For k = 0 To dt_nom_vendedores.Rows.Count - 1
                            If dtgSegVend.Item(j, i).Value = dt_nom_vendedores.Rows(k).Item("nit") Then
                                For z = 0 To dtgSegVend.Columns.Count - 1
                                    dtgSegVend.Item(z, i).ToolTipText = dt_nom_vendedores.Rows(k).Item("nombres")
                                Next
                                k = dt_nom_vendedores.Rows.Count - 1
                            End If
                        Next
                    End If
                Next
                j = dtgSegVend.Columns.Count - 1
            End If

        Next
    End Sub
    Private Sub alertas()
        Dim alerta As Double = 0
        For j = 1 To dtgSegVend.Columns.Count - 1
            If dtgSegVend.Columns(j).Name = "porCumVtas" Or dtgSegVend.Columns(j).Name = "porCumRec" Or dtgSegVend.Columns(j).Name = "col_porc_hoy_vtas" Or dtgSegVend.Columns(j).Name = "col_porc_hoy_rec" Then
                For i = 0 To dtgSegVend.Rows.Count - 1
                    If Not IsDBNull(dtgSegVend.Item(j, i).Value) Then
                        If (dtgSegVend.Item(j, i).Value) >= 100 Then
                            dtgSegVend.Item(j, i).Style.BackColor = Color.GreenYellow
                        ElseIf (dtgSegVend.Item(j, i).Value >= 95 And dtgSegVend.Item(j, i).Value < 100) Then
                            dtgSegVend.Item(j, i).Style.BackColor = Color.Yellow
                        Else
                            dtgSegVend.Item(j, i).Style.BackColor = Color.Red
                        End If
                    End If
                Next
            End If

        Next
    End Sub
    Private Sub validarColPermiso()
        Dim permiso As Boolean = False
        For i = 0 To dtgSegVend.Columns.Count - 1
            For j = 0 To dt_columnas_permiso.Rows.Count - 1
                If (dtgSegVend.Columns(i).Name = dt_columnas_permiso.Rows(j).Item("columna")) Then
                    permiso = True
                End If
            Next
            If (permiso = False) Then
                eliminarColumna(dtgSegVend.Columns(i).Name)
            End If
            permiso = False
        Next

    End Sub
    Private Sub eliminarColumna(ByVal col As String)
        For i = 0 To dtgSegVend.Columns.Count - 1
            If (dtgSegVend.Columns(i).Name = col) Then
                dtgSegVend.Columns(i).Visible = False
            End If
        Next
    End Sub
    Private Sub porUtilGral(ByVal criterioVendedor As String)
        Dim sql As String = " SELECT SUM (Cto_total) as Cto_total " & _
                    "FROM Jjv_V_vtas_vend_cliente_ref  " & _
                        "WHERE(Month(fec) = " & mes & " And Year(fec) = " & ano & ") AND (" & criterioVendedor & ") "
        Dim ctoTot As Double = 0
        If (objOpSimplesLn.consultarVal(sql).ToString <> "") Then
            ctoTot = objOpSimplesLn.consultarVal(sql)
        End If

        Dim vr_tot As Double = dtgSegVend.Item("Ventas", dtgSegVend.RowCount - 1).Value
        Dim porcUtil As Double = (vr_tot - ctoTot) / vr_tot * 100
        dtgSegVend.Item("Por_util", dtgSegVend.RowCount - 1).Value = porcUtil

    End Sub
    Private Sub ocultarPorCoordinador(ByVal usuario As String)
        If (usuario = "JESUSAL") Then
            For i = 0 To dtgSegVend.RowCount - 2
                If (dtgSegVend.Item("Vendedor", i).Value = 1020 Or dtgSegVend.Item("Vendedor", i).Value = 1024 Or dtgSegVend.Item("Vendedor", i).Value = 1035 Or dtgSegVend.Item("Vendedor", i).Value = 1032) Then
                    dtgSegVend.Rows(i).Visible = False
                End If
            Next
        Else
            For i = 0 To dtgSegVend.RowCount - 2
                If (dtgSegVend.Item("Vendedor", i).RowIndex <> dtgSegVend.RowCount - 1) Then
                    If (dtgSegVend.Item("Vendedor", i).Value <> 1034 Or dtgSegVend.Item("Vendedor", i).Value <> 1037 Or dtgSegVend.Item("Vendedor", i).Value <> 1038 Or dtgSegVend.Item("Vendedor", i).Value <> 1036 Or dtgSegVend.Item("Vendedor", i).Value <> 1032 Or dtgSegVend.Item("Vendedor", i).Value <> 1010) Then
                        dtgSegVend.Rows(i).Visible = False
                    End If
                End If
            Next
        End If

    End Sub
    Private Sub restarChequesDev()
        For i = 0 To dtgSegVend.RowCount - 1
            dtgSegVend.Item("Rec", i).Value = dtgSegVend.Item("Rec", i).Value - dtgSegVend.Item("chequesDev", i).Value
        Next
    End Sub
    Private Sub agregarMatriz(ByVal mat(,) As Object, ByVal columna As String)
        For i = 0 To dtgSegVend.RowCount - 2
            For j = 0 To dtgSegVend.RowCount - 2
                If (dtgSegVend.Item("Vendedor", i).Value = mat(j, 0)) Then
                    dtgSegVend.Item(columna, i).Value = mat(j, 1)
                    j = dtgSegVend.RowCount - 2
                End If
            Next
        Next
    End Sub
    Private Sub calcPorcCumpl(ByVal col1 As String, ByVal col2 As String, ByVal colDestino As String)
        For i = 0 To dtgSegVend.RowCount - 1
            If Not IsDBNull(dtgSegVend.Item(col2, i).Value) Then
                If (dtgSegVend.Item(col2, i).Value <> 0) Then
                    dtgSegVend.Item(colDestino, i).Value = (dtgSegVend.Item(col1, i).Value * 100) / dtgSegVend.Item(col2, i).Value
                End If
            End If
        Next
    End Sub
    Public Sub porc_util(ByVal mat(,) As Object)
        Dim p_util As Double = 0
        Dim cto_tot As Double = 0
        Dim vr_tot As Double = 0
        For i = 0 To dtgSegVend.RowCount - 2
            For j = 0 To dtgSegVend.RowCount - 2
                If (dtgSegVend.Item("Vendedor", i).Value = mat(j, 0)) Then
                    If dtgSegVend.Item("Vendedor", i).Value <> "1043" Then
                        cto_tot = mat(j, 1)
                        vr_tot = mat(j, 2)
                        p_util = (vr_tot - cto_tot) / (vr_tot) * 100
                        dtgSegVend.Item("Por_util", i).Value = p_util
                    End If
                End If
            Next

        Next

    End Sub
    Private Sub eliminarInactivos()
        For i = 0 To dtgSegVend.RowCount - 2
            If IsDBNull(dtgSegVend.Item("Pres_Ventas", i).Value) Then
                dtgSegVend.Rows(i).Visible = False
            ElseIf (dtgSegVend.Item("Ventas", i).Value = 0 And dtgSegVend.Item("Pres_Ventas", i).Value = 0 And dtgSegVend.Item("Rec", i).Value = 0 And dtgSegVend.Item("Pend", i).Value = 0 And dtgSegVend.Item("Pres_rec", i).Value = 0) Then
                dtgSegVend.Rows(i).Visible = False
            End If
        Next
    End Sub
    Public Sub sumar_col_grid(ByVal col As String)
        Dim suma As Double = 0
        For i = 0 To dtgSegVend.RowCount - 2
            If Not IsDBNull(dtgSegVend.Item(col, i).Value) Then
                suma = suma + dtgSegVend.Item(col, i).Value
            End If
        Next
        dtgSegVend.Item(col, dtgSegVend.RowCount - 1).Value = suma
    End Sub


    Public Function sumar_col_detalle(ByVal col As String) As Double
        Dim suma As Double = 0
        For i = 0 To dtgDetalle.RowCount - 1
            If Not IsDBNull(dtgDetalle.Item(col, i).Value) Then
                If dtgDetalle.Item("Descripcion", i).Value <> "CHATARRA" And dtgDetalle.Item("Descripcion", i).Value <> "OTROS" Then
                    suma = suma + dtgDetalle.Item(col, i).Value
                End If
            End If
        Next
        If (col = "Porc_util" Or col = "porc_util") Then
            If IsNumeric(dtgDetalle.Item("Valor_tot", dtgDetalle.RowCount - 1).Value) Then
                If IsNumeric(dtgDetalle.Item("Cto_total", dtgDetalle.RowCount - 1).Value) Then
                    suma = ((dtgDetalle.Item("Valor_tot", dtgDetalle.RowCount - 1).Value - dtgDetalle.Item("Cto_total", dtgDetalle.RowCount - 1).Value) / (dtgDetalle.Item("Valor_tot", dtgDetalle.RowCount - 1).Value)) * 100
                End If
            End If
        ElseIf col = "porCumVtas" Or col = "porCumRec" Or col = "porDev" Then
            suma = suma / dtgDetalle.RowCount - 1
        End If
        Return suma
    End Function
    Private Sub dtgSegVend_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgSegVend.CellDoubleClick
        cargarDetalle(e.ColumnIndex, e.RowIndex)
    End Sub
    Private Sub cargarDetalle(ByVal col As Integer, ByVal fila As Integer)
        Dim tamano_letra As Single = 8.0!
        Dim estado As Boolean = False
        Dim iResponce As Integer
        Dim sql As String = ""
        Dim whereVendedor As String = ""
        If (col > 0 And col <= 9) Then
            If (fila <> -1) Then
                If (usuario_vendedor = 1020 And objUsuarioEn.nombre <> "JESUS ALFONSO RIOS") Then
                    estado = True
                End If
                If (fila = dtgSegVend.RowCount - 1) Then
                    If (usuario_vendedor = 1020) Then
                        If (objUsuarioEn.permiso.Trim <> "ADMIN") Then
                            whereVendedor = "" & objUsuarioLn.coordinadorVend(objUsuarioEn.usuario) & ""
                        Else
                            whereVendedor = ""
                        End If
                    Else
                        whereVendedor = "" & usuario_vendedor & ""
                    End If
                Else
                    whereVendedor = "(" & dtgSegVend.Item("Vendedor", fila).Value & ")"
                End If



                Select Case dtgSegVend.Columns(col).Name
                    Case "Ventas"
                        iResponce = MessageBox.Show("Desea ver el detalle por linea de producciòn? ", "Atención", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                        imgProcesar.Visible = True
                        Cursor = Cursors.AppStarting
                        Application.DoEvents()
                        If (iResponce = 6) Then
                            dtgDetalle.DataSource = objNuevLn.Detalle_consol_vtas_idCor(mes, ano, whereVendedor, objUsuarioEn)
                            dtgDetalle.Columns("Porc_util").Visible = estado
                            dtgDetalle.Columns("Porc_util").DefaultCellStyle.Format = "N2"
                            dtgDetalle.Item("Descripcion", dtgDetalle.RowCount - 1).Value = "TOTAL"
                            dtgDetalle.Item("kilos", dtgDetalle.RowCount - 1).Value = sumar_col_detalle("kilos")
                            dtgDetalle.Item("Cantidad", dtgDetalle.RowCount - 1).Value = sumar_col_detalle("Cantidad")
                            dtgDetalle.Item("Valor_tot", dtgDetalle.RowCount - 1).Value = sumar_col_detalle("Valor_tot")
                            dtgDetalle.Item("Cto_total", dtgDetalle.RowCount - 1).Value = sumar_col_detalle("Cto_total")
                            dtgDetalle.Item("Porc_util", dtgDetalle.RowCount - 1).Value = sumar_col_detalle("Porc_util")
                        Else
                            dtgDetalle.DataSource = objNuevLn.DetalleVentasVend(mes, ano, whereVendedor, objUsuarioEn)
                            dtgDetalle.Columns("porc_util").Visible = estado
                            dtgDetalle.Columns("cto_kilo").Visible = estado
                            dtgDetalle.Columns("fec").DefaultCellStyle.Format = "d"
                            dtgDetalle.Item("nit", dtgDetalle.RowCount - 1).Value = "TOTAL"
                            dtgDetalle.Item("cantidad", dtgDetalle.RowCount - 1).Value = sumar_col_detalle("cantidad")
                            dtgDetalle.Item("Kilos", dtgDetalle.RowCount - 1).Value = sumar_col_detalle("Kilos")
                            dtgDetalle.Item("cto_kilo", dtgDetalle.RowCount - 1).Value = sumar_col_detalle("cto_kilo")
                            dtgDetalle.Item("Valor_tot", dtgDetalle.RowCount - 1).Value = sumar_col_detalle("Valor_tot")
                            dtgDetalle.Item("Cto_total", dtgDetalle.RowCount - 1).Value = sumar_col_detalle("Cto_total")
                            dtgDetalle.Item("porc_util", dtgDetalle.RowCount - 1).Value = sumar_col_detalle("porc_util")
                            dtgDetalle.Item("vr_kilo", dtgDetalle.RowCount - 1).Value = sumar_col_detalle("vr_kilo")
                            ',nit,nombres,ciudad,condicion, cantidad,Kilos,(Vr_total/Kilos) as vr_kilo,(Cto_total/Kilos) as cto_kilo,Vr_total,(Vr_total/Kilos-Cto_total/Kilos)/(Vr_total/Kilos)*100 as porc_util
                        End If

                        imgProcesar.Visible = False
                        Cursor = Cursors.Default
                    Case "Pres_Ventas"
                        dtgDetalle.DataSource = objNuevLn.DetaPptoVtas(mes, ano, whereVendedor)
                        dtgDetalle.Columns("Porc_util").Visible = estado
                        dtgDetalle.Columns("cto_kilo").Visible = estado
                        dtgDetalle.Columns("Cto_total").Visible = estado
                        dtgDetalle.Columns("Fec_modificacion").DefaultCellStyle.Format = "d"
                        dtgDetalle.Item("vendedor", dtgDetalle.RowCount - 1).Value = "TOTAL"
                        dtgDetalle.Item("ppto_kilos", dtgDetalle.RowCount - 1).Value = sumar_col_detalle("ppto_kilos")
                        dtgDetalle.Item("Vr_kilo", dtgDetalle.RowCount - 1).Value = sumar_col_detalle("Vr_kilo")
                        dtgDetalle.Item("Vr_total", dtgDetalle.RowCount - 1).Value = sumar_col_detalle("Vr_total")
                        dtgDetalle.Item("Cto_kilo", dtgDetalle.RowCount - 1).Value = sumar_col_detalle("Cto_kilo")
                        dtgDetalle.Item("Porc_util", dtgDetalle.RowCount - 1).Value = sumar_col_detalle("Porc_util")
                        dtgDetalle.Item("Cto_total", dtgDetalle.RowCount - 1).Value = sumar_col_detalle("Cto_total")
                    Case "Pend"
                        iResponce = MessageBox.Show("Desea ver el detalle por linea de producciòn? ", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                        If (iResponce = 6) Then
                            dtgDetalle.DataSource = objNuevLn.Detalle_consol_pend_idCor(whereVendedor, objUsuarioEn)
                            dtgDetalle.Item("Descripcion", dtgDetalle.RowCount - 1).Value = "TOTAL"
                            dtgDetalle.Item("kilos", dtgDetalle.RowCount - 1).Value = sumar_col_detalle("kilos")
                            dtgDetalle.Item("Cantidad", dtgDetalle.RowCount - 1).Value = sumar_col_detalle("Cantidad")
                            dtgDetalle.Item("Valor_tot", dtgDetalle.RowCount - 1).Value = sumar_col_detalle("Valor_tot")
                            dtgDetalle.Item("costo_total", dtgDetalle.RowCount - 1).Value = sumar_col_detalle("costo_total")
                            dtgDetalle.Item("margen", dtgDetalle.RowCount - 1).Value = ((sumar_col_detalle("Valor_tot") - sumar_col_detalle("costo_total")) / sumar_col_detalle("Valor_tot") * 100)
                        ElseIf (iResponce = 7) Then
                            dtgDetalle.DataSource = objNuevLn.DetallePend(whereVendedor, objUsuarioEn)
                            dtgDetalle.Columns("fecha").DefaultCellStyle.Format = "d"
                            dtgDetalle.Item("vendedor", dtgDetalle.RowCount - 1).Value = "TOTAL"
                            dtgDetalle.Item("Valor_total", dtgDetalle.RowCount - 1).Value = sumar_col_detalle("Valor_total")
                            dtgDetalle.Item("cant_Pedida", dtgDetalle.RowCount - 1).Value = sumar_col_detalle("cant_Pedida")
                            dtgDetalle.Item("pendiente", dtgDetalle.RowCount - 1).Value = sumar_col_detalle("pendiente")
                            dtgDetalle.Item("Kilos", dtgDetalle.RowCount - 1).Value = sumar_col_detalle("Kilos")
                            dtgDetalle.Item("Por_util", dtgDetalle.RowCount - 1).Value = sumar_col_detalle("Por_util")
                            dtgDetalle.Item("valor_unitario", dtgDetalle.RowCount - 1).Value = sumar_col_detalle("valor_unitario")
                            dtgDetalle.Item("Cto_Kilo", dtgDetalle.RowCount - 1).Value = sumar_col_detalle("Cto_Kilo")
                            'Valor_total,cant_Pedida as Cant, kilosPendiente as Kilos, (costo_total/cant_Pedida )as Cto_Kilo,valor_unitario,(valor_unitario-(costo_total/cant_Pedida ))/(valor_unitario)*100 as Por_util,descripcion , bloqueo,condicion,cupo_credito
                        End If
                    Case "No_reflej"
                        dtgDetalle.DataSource = objNuevLn.Detalle_no_reflej(whereVendedor, objUsuarioEn)
                        dtgDetalle.Columns("fecha").DefaultCellStyle.Format = "d"
                        dtgDetalle.Item("bodega", dtgDetalle.RowCount - 1).Value = "TOTAL"
                        dtgDetalle.Item("valor_tot", dtgDetalle.RowCount - 1).Value = sumar_col_detalle("valor_tot")

                    Case "Rec"
                        dtgDetalle.DataSource = objNuevLn.DetalleRec(mes, ano, whereVendedor, objUsuarioEn)
                        dtgDetalle.Columns("fecha").DefaultCellStyle.Format = "d"
                        dtgDetalle.Item("vendedor", dtgDetalle.RowCount - 1).Value = "TOTAL"
                        dtgDetalle.Item("VALOR", dtgDetalle.RowCount - 1).Value = sumar_col_detalle("VALOR")
                        dtgDetalle.Item("DESCUENTO", dtgDetalle.RowCount - 1).Value = sumar_col_detalle("DESCUENTO")
                        dtgDetalle.Item("Total_rec", dtgDetalle.RowCount - 1).Value = sumar_col_detalle("Total_rec")
                        'Rec.vendedor,Rec.ciudad,ter.nit  ,Rec.nombres ,Rec.tipo,Rec.tipo_aplica,Rec.VALOR,Rec.DESCUENTO,Rec.Total_rec,Rec.fecha  
                    Case "Pres_rec"
                        dtgDetalle.DataSource = objNuevLn.DetallePptoRec(mes, ano, whereVendedor)
                        dtgDetalle.Columns("Fecha_mod_ppto_rec").DefaultCellStyle.Format = "d"
                        dtgDetalle.Item("nit", dtgDetalle.RowCount - 1).Value = "TOTAL"
                        dtgDetalle.Item("Ppto_vtas", dtgDetalle.RowCount - 1).Value = sumar_col_detalle("Ppto_vtas")
                        dtgDetalle.Item("Ppto_Calculado", dtgDetalle.RowCount - 1).Value = sumar_col_detalle("Ppto_Calculado")
                        dtgDetalle.Item("Ppto_client_contado", dtgDetalle.RowCount - 1).Value = sumar_col_detalle("Ppto_client_contado")
                        dtgDetalle.Item("Ppto_total", dtgDetalle.RowCount - 1).Value = sumar_col_detalle("Ppto_total")
                        dtgDetalle.Item("TotClientCont", dtgDetalle.RowCount - 1).Value = sumar_col_detalle("TotClientCont")
                        'nit,ano,Mes,Ppto_vtas ,Ppto_Calculado,Fecha_mod_ppto_rec,Ppto_client_contado,Ppto_total,TotClientCont
                    Case "Dev"
                        dtgDetalle.DataSource = objNuevLn.DetalleDev(mes, ano, whereVendedor, objUsuarioEn)
                        dtgDetalle.Columns("Cto_total").Visible = estado
                        dtgDetalle.Item("vendedor", dtgDetalle.RowCount - 1).Value = "TOTAL"
                        dtgDetalle.Item("cantidad", dtgDetalle.RowCount - 1).Value = sumar_col_detalle("cantidad")
                        dtgDetalle.Item("Kilos", dtgDetalle.RowCount - 1).Value = sumar_col_detalle("Kilos")
                        dtgDetalle.Item("Cto_total", dtgDetalle.RowCount - 1).Value = sumar_col_detalle("Cto_total")
                        dtgDetalle.Item("Vr_total", dtgDetalle.RowCount - 1).Value = sumar_col_detalle("Vr_total")
                        ' vendedor,nit,nombres,ciudad,condicion, cantidad,Kilos,Cto_total,Vr_total
                    Case "chequesDev"
                        If (whereVendedor <> "") Then
                            whereVendedor = "doc.vendedor in (" & whereVendedor & ") "
                        Else
                            whereVendedor = "doc.vendedor>=1001 AND doc.vendedor <=1099"
                        End If
                        sql = "SELECT ter.vendedor,doc.tipo,doc.numero,doc.nit,ter.nombres ,fecha,doc.valor_total,doc.notas  " & _
                                          "FROM documentos  doc, terceros ter  " & _
                                          "WHERE doc.tipo IN ('NDCH') AND MONTH (doc.fecha )= " & mes & " and YEAR (doc.fecha )= " & ano & " AND  " & whereVendedor & " AND ter.nit = doc.nit "
                        dtgDetalle.DataSource = objOpSimplesLn.listar_datatable(sql, "CORSAN")
                        dtgDetalle.Item("nombres", dtgDetalle.RowCount - 1).Value = "TOTAL"
                        dtgDetalle.Item("valor_total", dtgDetalle.RowCount - 1).Value = sumar_col_detalle("valor_total")
                        dtgDetalle.Columns("fecha").DefaultCellStyle.Format = "d"
                    Case "colAnt"
                        If (whereVendedor <> "") Then
                            whereVendedor = "doc.vendedor in (" & whereVendedor & ") "
                        Else
                            whereVendedor = "doc.vendedor>=1001 AND doc.vendedor <=1099"
                        End If
                        sql = "SELECT ter.nit,ter.nombres,ter.condicion,ter.bloqueo,doc.fecha,doc.vendedor,doc.tipo, doc.valor_total As vrTotal,doc.valor_aplicado As vrAplicado,(doc.valor_total - doc.valor_aplicado ) as Saldo " & _
                                       "FROM documentos doc ,terceros ter " & _
                                        "WHERE ter.nit= doc.nit AND doc.sw Like '5' AND  " & whereVendedor & " AND doc.tipo IN ('RCR1','RCO1','RCEX') AND  YEAR(doc.fecha)=" & ano & " AND  MONTH(doc.fecha)=" & mes & " AND(doc.valor_total>doc.valor_aplicado or (doc.iva_fletes <0   AND doc.valor_total=doc.valor_aplicado))  "
                        dtgDetalle.DataSource = objOpSimplesLn.listar_datatable(sql, "CORSAN")
                        dtgDetalle.Item("nombres", dtgDetalle.RowCount - 1).Value = "TOTAL"
                        dtgDetalle.Item("vrTotal", dtgDetalle.RowCount - 1).Value = sumar_col_detalle("vrTotal")
                        dtgDetalle.Item("vrAplicado", dtgDetalle.RowCount - 1).Value = sumar_col_detalle("vrAplicado")
                        dtgDetalle.Item("Saldo", dtgDetalle.RowCount - 1).Value = sumar_col_detalle("Saldo")
                        dtgDetalle.Columns("fecha").DefaultCellStyle.Format = "d"
                End Select
                dtgDetalle.Rows(dtgDetalle.RowCount - 1).DefaultCellStyle = objOperacionesForm.formatoNegrita(tamano_letra)
                If objUsuarioEn.permiso.Trim <> "ADMIN" Then
                    For i = 0 To dtgDetalle.Columns.Count - 1
                        If dtgDetalle.Columns(i).Name = "Por_util" Or dtgDetalle.Columns(i).Name = "porc_util" Or dtgDetalle.Columns(i).Name = "Porc_util" Or dtgDetalle.Columns(i).Name = "Cto_Kilo" Or dtgDetalle.Columns(i).Name = "Cto_total" Or dtgDetalle.Columns(i).Name = "cto_kilo" Then
                            dtgDetalle.Columns(i).Visible = False
                        End If
                    Next
                End If
            End If

        End If
    End Sub
    Private Sub pintarCeldas()
        Dim tamano_letra As Single = 7.5!
        For i = 0 To dtgSegVend.RowCount - 1
            If (i Mod 2 = 0) Then
                dtgSegVend.Rows(i).DefaultCellStyle.BackColor = Color.LightGray
            End If
        Next
        dtgSegVend.Rows(dtgSegVend.RowCount - 1).DefaultCellStyle = objOperacionesForm.formatoNegrita(tamano_letra)
    End Sub
    Public Sub formatoNegrita()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        dtgSegVend.Columns(0).DefaultCellStyle = DataGridViewCellStyle1
        dtgSegVend.Rows(dtgSegVend.RowCount - 1).DefaultCellStyle.ForeColor = Color.Blue
    End Sub
    Private Sub btn_ppal_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ppal.Click
        FrmPrincipal.Show()
        Me.Close()
        FrmPrincipal.Activate()
    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        FrmLogin.Show()
        FrmPrincipal.Close()
        FrmLogin.Activate()
        Me.Close()
    End Sub
    Private Sub ChkPesosVend_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkPesos.CheckedChanged
        If ChkPesos.Checked = True Then
            chkKil.Checked = False
        End If
    End Sub
    Private Sub chkKilVend_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkKil.CheckedChanged
        If chkKil.Checked = True Then
            ChkPesos.Checked = False
        End If
    End Sub
    Private Sub btn_export_seg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_export_seg.Click
        objOperacionesForm.ExportarDatosExcel(dtgSegVend, "Seguimiento vendedores")
    End Sub

    Private Sub btn_export_dtalle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_export_dtalle.Click
        objOperacionesForm.ExportarDatosExcel(dtgDetalle, "detalle Seguimiento vendedores")
    End Sub

    Private Sub SeguimientoPresupeustoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SeguimientoPresupeustoToolStripMenuItem.Click
        Frm_dtalle_seg_ppto.Show()
        Frm_dtalle_seg_ppto.Main(objUsuarioEn.Vendedor, "nod_seg_ppto", objUsuarioEn.permiso, objUsuarioEn)
        Frm_dtalle_seg_ppto.Activate()
    End Sub
    Private Sub AnticiposToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AnticiposToolStripMenuItem1.Click
        Frm_anticipo.Show()
        Frm_anticipo.Main(usuario_vendedor, "nod_anticipos", objUsuarioEn.permiso)
        Frm_anticipo.Activate()
    End Sub
    Private Sub PrincipalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FrmPrincipal.Show()
        Me.Close()
        FrmPrincipal.Activate()
    End Sub

    Private Sub SalirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FrmLogin.Show()
        FrmLogin.Activate()
        FrmPrincipal.Close()
        Me.Close()
    End Sub

    Private Sub btnRefNoClas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefNoClas.Click
        FrmGestRef.Show()
        FrmGestRef.Activate()
    End Sub
    Private Sub sumarAnticipos()
        For i = 0 To dtgSegVend.RowCount - 1
            dtgSegVend.Item("Rec", i).Value += dtgSegVend.Item("colAnt", i).Value
        Next
    End Sub
    Private Sub dtgSegVend_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dtgSegVend.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            With (Me.dtgSegVend)
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                End If
            End With
            If (dtgSegVend.CurrentCell.ColumnIndex >= 1 And dtgSegVend.CurrentCell.ColumnIndex <= 9) Then
                menStripDtg.Enabled = True
            Else
                menStripDtg.Enabled = False
            End If
        End If
    End Sub
    Private Sub itemMasInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles itemMasInfo.Click
        cargarDetalle(dtgSegVend.CurrentCell.ColumnIndex, dtgSegVend.CurrentCell.RowIndex)
    End Sub
    'Private Sub calc_comisiones()
    '    Dim valor As Double = 0
    '    Dim vendedor As Integer = 0
    '    Dim sql As String = ""
    '    Dim dt As DataTable
    '    Dim val_item As Double
    '    Dim tipo As Integer = 0
    '    Dim cump_vtas As Double = 0
    '    Dim cump_rec As Double = 0
    '    Dim porc_comision As Double = 0
    '    For i = 0 To dtgSegVend.RowCount - 2
    '        If (dtgSegVend.Rows(i).Visible = True) Then
    '            vendedor = dtgSegVend.Item("Vendedor", i).Value
    '            sql = "SELECT d.cump_vtas,d.cump_rec,d.porc_comision,c.tipo  " & _
    '                 "FROM J_reglas_comisiones c , J_reglas_comisiones_det d " & _
    '                                "WHERE c.numero = d.numero And c.anulado Is null And vendedor = " & vendedor & " " & _
    '                   "ORDER BY d.porc_comision "
    '            dt = New DataTable
    '            dt = objOpSimplesLn.listar_datatable(sql, "CORSAN")
    '            If (dt.Rows.Count > 0) Then
    '                For j = 0 To dt.Rows.Count - 1
    '                    tipo = dt.Rows(j).Item("tipo")
    '                    cump_vtas = dt.Rows(j).Item("cump_vtas")
    '                    cump_rec = dt.Rows(j).Item("cump_rec")
    '                    porc_comision = dt.Rows(j).Item("porc_comision") / 100
    '                    If (dtgSegVend.Item("porCumVtas", i).Value >= cump_vtas And dtgSegVend.Item("porCumRec", i).Value >= cump_rec) Then
    '                        If (tipo = 1) Then
    '                            val_item = dtgSegVend.Item(Ventas.Name, i).Value
    '                        Else
    '                            val_item = dtgSegVend.Item(Rec.Name, i).Value
    '                        End If
    '                        valor = val_item * porc_comision
    '                        dtgSegVend.Item(col_comision.Name, i).Style.BackColor = Color.Green
    '                    Else
    '                        valor = 0
    '                    End If
    '                Next

    '            Else
    '                valor = 0
    '            End If

    '            dtgSegVend.Item(col_comision.Name, i).Value = valor
    '            valor = 0
    '        End If
    '    Next

    'End Sub
    Private Sub listPermisosUsuario_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles listaTipoUsu.SelectedIndexChanged
        permiso = listaTipoUsu.SelectedItem
        Dim sql As String = "SELECT columna FROM J_spic_per_columna_seguimiento   WHERE permiso = '" & permiso & "'"
        cargarLista(listPermisosUsuario, sql)
    End Sub
    Private Sub btnAddColumna_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddColumna.Click
        addColumna()
    End Sub
    Private Sub addColumna()
        If (permiso <> "") Then
            Dim sql As String = "INSERT INTO J_spic_per_columna_seguimiento (columna,permiso) VALUES ('" & columnaArbol & "','" & permiso & "')"
            If (objOpSimplesLn.consultarVal("SELECT columna FROM J_spic_per_columna_seguimiento WHERE columna = '" & columnaArbol & "' AND permiso = '" & permiso & "'") <> "") Then
                MessageBox.Show("LA columna ya fue asignado para este permiso")
            ElseIf (objOpSimplesLn.ejecutar(sql, "CORSAN")) Then
                listPermisosUsuario.Items.Add(columnaArbol)
            Else
                MsgBox("Error al otorgar el permiso")
            End If
        Else
            MessageBox.Show("Seleccione tipo de permiso para asignar funcionalidad", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
    Private Sub btnQuitarcol_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuitarCol.Click
        Dim Columna As String = listPermisosUsuario.SelectedItem
        Dim indexMod As Integer = 0
        Dim resp As Integer = 0
        Dim sql As String = ""
        If (Columna <> "" And permiso <> "") Then
            resp = MessageBox.Show("Esta seguro de quitar este permiso? ", "Quitar", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
            If (resp = 6) Then
                sql = "DELETE FROM J_spic_per_columna_seguimiento WHERE columna ='" & Columna & "' AND permiso = '" & permiso & "'"
                If (objOpSimplesLn.ejecutar(sql, "CORSAN") > 0) Then
                    indexMod = listPermisosUsuario.SelectedIndex
                    listPermisosUsuario.Items.Remove(listPermisosUsuario.Items(indexMod))
                Else
                    MsgBox("Error al eliminar")
                End If
            End If
        Else
            MsgBox("Seleccione permiso y columna a eliminar")
        End If
    End Sub
    Private Sub listColumnas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles listColumnas.SelectedIndexChanged
        columnaArbol = listColumnas.SelectedItem
        addColumna()
    End Sub
    Private Sub btnConfigPermisos_Click(sender As Object, e As EventArgs) Handles btnConfigPermisos.Click
        groupPermisos.Visible = True
    End Sub

    Private Sub btnOcultPermisos_Click(sender As Object, e As EventArgs) Handles btnOcultPermisos.Click
        groupPermisos.Visible = False
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Frm_clasificacion.ShowDialog()
    End Sub

    Private Sub VentasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VentasToolStripMenuItem.Click
        Dim whereVendedor As String = ""
        Dim titulo As String = ""
        Dim fila As Integer = dtgSegVend.CurrentCell.RowIndex
        If (fila = dtgSegVend.RowCount - 1) Then
            titulo = "Compañia"
            If (usuario_vendedor = 1020) Then
                If (objUsuarioEn.permiso.Trim = "COOR_VTAS") Then
                    whereVendedor = "" & objUsuarioLn.coordinadorVend(objUsuarioEn.usuario) & ""
                Else
                    whereVendedor = ""
                End If
            Else
                titulo = dtgSegVend.Item("Vendedor", fila).ToolTipText
                whereVendedor = "" & usuario_vendedor & ""
            End If
        Else
            titulo = dtgSegVend.Item("Vendedor", fila).ToolTipText
            whereVendedor = "(" & dtgSegVend.Item("Vendedor", fila).Value & ")"
        End If
        Dim dt As DataTable = get_dt_ventas_dia(whereVendedor)
        graficar(dt, "Ventas - " & titulo)
    End Sub

    Private Sub RecaudosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RecaudosToolStripMenuItem.Click
        Dim whereVendedor As String = ""
        Dim fila As Integer = dtgSegVend.CurrentCell.RowIndex
        Dim titulo As String = ""
        If (fila = dtgSegVend.RowCount - 1) Then
            If (usuario_vendedor = 1020) Then
                titulo = "Compañia"
                If (objUsuarioEn.permiso.Trim = "COOR_VTAS") Then
                    whereVendedor = "" & objUsuarioLn.coordinadorVend(objUsuarioEn.usuario) & ""
                Else
                    whereVendedor = ""
                End If
            Else
                titulo = dtgSegVend.Item("Vendedor", fila).ToolTipText
                whereVendedor = "" & usuario_vendedor & ""
            End If
        Else
            titulo = dtgSegVend.Item("Vendedor", fila).ToolTipText
            whereVendedor = "(" & dtgSegVend.Item("Vendedor", fila).Value & ")"
        End If
        Dim dt As DataTable = get_dt_recaudos_dia(whereVendedor)
        graficar(dt, "Recaudos - " & titulo)
    End Sub
    Public Sub graficar(ByRef dt As DataTable, ByVal titulo As String)
        Chart1.Visible = True
        Chart1.Titles.Clear()
        Chart1.Series.Clear()
        Chart1.ChartAreas.Clear()
        Chart1.ChartAreas.Add(0)
        Chart1.Series.Add(titulo)
        Dim valor As Integer = 0
        Dim cant As Integer = 0
        Dim fecha As Date
        For i = 0 To dt.Rows.Count - 1
            If IsDate(dt.Rows(i).Item("fecha")) Then
                fecha = dt.Rows(i).Item("fecha")
                If IsNumeric(dt.Rows(i).Item("valor_total")) Then
                    If (dt.Rows(i).Item("valor_total")) > 0 Then
                        valor = dt.Rows(i).Item("valor_total")
                        Chart1.Series(titulo).Points.AddXY(fecha, valor)
                        Chart1.Series(titulo).Points(cant).ToolTip = WeekdayName(Weekday(objOpSimplesLn.cambiarFormatoFecha(fecha)) - 1) & "," & fecha
                        Chart1.Series(titulo).Points(cant).LabelFormat = "N0"
                        cant += 1
                    End If
                End If
            End If
        Next

        Chart1.Series(titulo).ChartType = DataVisualization.Charting.SeriesChartType.Line
        Chart1.Series(titulo).IsValueShownAsLabel = True
        Chart1.ChartAreas(0).AxisX.Title = "Días"
        Chart1.ChartAreas(0).AxisY.Title = titulo
        Chart1.Refresh()
    End Sub
    Private Function get_dt_ventas_dia(ByVal where_vendedor As String) As DataTable
        Dim dt As New DataTable
        If (where_vendedor <> "") Then
            where_vendedor = "vendedor in (" & where_vendedor & ") "
        Else
            where_vendedor = "vendedor>=1001 AND vendedor <=1099"
        End If
        Dim sql As String = "SELECT fec As fecha,SUM(Vr_total ) As valor_total " & _
                                "FROM Jjv_V_vtas_vend_cliente_ref " & _
                                    "WHERE Month(fec) = " & mes & " And Year(fec) = " & ano & " AND " & where_vendedor & _
                                        "GROUP BY fec " & _
                                            "ORDER BY fec "
        dt = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        Return dt
    End Function
    Private Function get_dt_recaudos_dia(ByVal where_vendedor As String) As DataTable
        Dim dt As New DataTable
        If (where_vendedor <> "") Then
            where_vendedor = "vendedor in (" & where_vendedor & ") "
        Else
            where_vendedor = "vendedor>=1001 AND vendedor <=1099"
        End If
        Dim sql As String = "SELECT fecha ,SUM(Total_rec ) As valor_total  " & _
                                "FROM Jjv_Recaudos_consol " & _
                                "WHERE Month(fecha) = " & mes & "  And Year(fecha) = " & ano & " AND " & where_vendedor & _
                                    "GROUP BY fecha " & _
                                        "ORDER BY fecha "
        dt = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        Return dt
    End Function

    Private Sub btn_cerrar_grafico_Click(sender As Object, e As EventArgs)
        Chart1.Visible = False
    End Sub
    'Mostrar terceros no clasificados
    Private Sub terceros_No_Clasificados()
        Dim sql As String = "WITH CTE AS ( select nit from terceros where concepto_2 is null and nit in (select distinct nit from documentos where sw in (1,2) and tipo='FACT' AND fecha >= '2016-06-01 00:00:00.000') " & _
        "union all select nit from terceros where concepto_3 is null and nit in (select distinct nit from documentos where sw in (1,2) and tipo='FACT' AND fecha >= '2016-06-01 00:00:00.000') " & _
        "union all select nit from terceros where concepto_4 is null and nit in (select distinct nit from documentos where sw in (1,2) and tipo='FACT' AND fecha >= '2016-06-01 00:00:00.000') ) " & _
        "select distinct count(nit) from cte "
        Dim valor As String = objOpSimplesLn.consultValorTodo(sql, "CORSAN")
        Dim dt As New DataTable
        Dim formu As New frm_Clientes_Sin_Clasificar
        Dim result = MessageBox.Show("El nro de terceros sin clasificar es:" & valor & ",desea verlos?", "Terceros sin clasificar", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
        If result = DialogResult.Yes Then
            sql = "WITH CTE AS ( select nit,nombres,ciudad,direccion,mail,vendedor from terceros where concepto_2 is null and nit in (select distinct nit from documentos where sw in (1,2) and tipo='FACT' AND fecha >= '2016-06-01 00:00:00.000') " & _
                   "union all select nit,nombres,ciudad,direccion,mail,vendedor from terceros where concepto_3 is null and nit in (select distinct nit from documentos where sw in (1,2) and tipo='FACT' AND fecha >= '2016-06-01 00:00:00.000') " & _
                   "union all select nit,nombres,ciudad,direccion,mail,vendedor from terceros where concepto_4 is null and nit in (select distinct nit from documentos where sw in (1,2) and tipo='FACT' AND fecha >= '2016-06-01 00:00:00.000') ) " & _
                   "select nit,nombres,ciudad,direccion,mail,vendedor from cte "
            dt = objOpSimplesLn.listar_datatable(sql, "CORSAN")
            formu.Show()
            formu.main(dt)
        End If
    End Sub

End Class