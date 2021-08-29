Imports System.Configuration
Imports logicaNegocios
Imports System.IO
Imports Microsoft.Office.Interop
Public Class Frm_vtas_vend_ciud
    Private obj_vtas_lin_ciuLn As New Vtas_vend_ciudLn
    Private objOperacionesForm As OperacionesFormularios = New OperacionesFormularios
    Private carga_comp As Boolean = False
    Private cbo_ciud_comp As Boolean = False

    Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'If Not (cbo_dpto.Text = "Seleccione" Or cbo_vend.Text = "Seleccione" Or cbo_linea_prod.Text = "Seleccione" Or cbo_ciudad.Text = "Seleccione" Or cboMesIni.Text = "" Or cboMesFin.Text = "" Or cboAñoFin.Text = "" Or cboAñoIni.Text = "" Or cbo_ciudad.Text = "") Then
        '    Dim resp As Integer = MessageBox.Show("Desea agrupar informe por codigo de producto? ", "Agrupación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        '    imgProcesar.Visible = True
        '    Application.DoEvents()
        '    Dim mesini As Integer = cboMesIni.SelectedIndex + 1
        '    Dim añoIni As Integer = cboAñoIni.SelectedItem
        '    Dim mesFin As Integer = cboMesFin.SelectedIndex + 1
        '    Dim añoFin As Integer = cboAñoFin.SelectedItem
        '    Dim dia_fin As Integer = DateSerial(añoFin, mesFin + 1, 0).Day
        '    Dim fec_ini As String = añoIni & "/" & mesini & "/01"
        '    Dim fec_max As String = añoFin & "/" & mesFin & "/" & dia_fin
        '    Dim ven_min As Integer
        '    Dim ven_max As Integer
        '    Dim id_cor2 As Integer = cbo_linea_prod.SelectedValue
        '    Dim ciudad As String = cbo_ciudad.Text
        '    Dim sql As String
        '    Dim dpto As Integer = cbo_dpto.SelectedValue
        '    Dim vr_tot As Double = 0
        '    Dim cto_tot As Double = 0
        '    If (cbo_vend.Text = "TODOS") Then
        '        ven_min = 1001
        '        ven_max = 1099
        '    Else
        '        ven_min = cbo_vend.SelectedValue
        '        ven_max = cbo_vend.SelectedValue
        '    End If
        '    If (resp = 6) Then
        '        If (cbo_dpto.Text = "TODOS") Then
        '            If (cbo_linea_prod.Text = "TODOS") Then
        '                sql = "SELECT vtas.ciudad ,vtas.codigo,vtas.descripcion,SUM(vtas.KILOS)As KILOS ,SUM(vtas.Vr_total)as Vr_total ,SUM(vtas.Cto_total) As Cto_total " & _
        '                               "FROM Jjv_V_vtas_vend_cliente_ref vtas INNER JOIN referencias ref ON vtas.codigo = ref.codigo, JJV_Grupos_seguimiento seg_idcor,terceros ter  " & _
        '                                    "WHERE vtas.vendedor >= " & ven_min & " And vtas.vendedor <= " & ven_max & " And fec >= '" & fec_ini & "' And fec < '" & fec_max & "' And seg_idcor.Id_cor = ref.Id_cor  AND ter.nit = vtas.nit AND KILOS <>0  " & _
        '                                         "GROUP BY vtas.codigo ,vtas.ciudad ,vtas.descripcion  " & _
        '                                                         "ORDER BY vtas.ciudad  "
        '            Else
        '                sql = "SELECT vtas.ciudad ,vtas.codigo,vtas.descripcion,SUM(vtas.KILOS)As KILOS ,SUM(vtas.Vr_total)as Vr_total ,SUM(vtas.Cto_total) As Cto_total " & _
        '                               "FROM Jjv_V_vtas_vend_cliente_ref vtas INNER JOIN referencias ref ON vtas.codigo = ref.codigo, JJV_Grupos_seguimiento seg_idcor,terceros ter  " & _
        '                                    "WHERE vtas.vendedor >= " & ven_min & " And vtas.vendedor <= " & ven_max & " And fec >= '" & fec_ini & "' And fec < '" & fec_max & "' And seg_idcor.Id_cor = ref.Id_cor and ref.Id_cor = " & id_cor2 & " AND ter.nit = vtas.nit AND KILOS <>0 " & _
        '                                         "GROUP BY vtas.codigo ,vtas.ciudad ,vtas.descripcion  " & _
        '                                                         "ORDER BY vtas.ciudad  "
        '            End If

        '        Else
        '            If (cbo_ciudad.Text = "TODOS") Then
        '                sql = "SELECT vtas.ciudad ,vtas.codigo,vtas.descripcion,SUM(vtas.KILOS)As KILOS ,SUM(vtas.Vr_total)as Vr_total ,SUM(vtas.Cto_total) As Cto_total " & _
        '                                   "FROM Jjv_V_vtas_vend_cliente_ref vtas INNER JOIN referencias ref ON vtas.codigo = ref.codigo, JJV_Grupos_seguimiento seg_idcor,terceros ter ,y_ciudades ciud " & _
        '                                        "WHERE vtas.vendedor >= " & ven_min & " And vtas.vendedor <= " & ven_max & " And fec >= '" & fec_ini & "' And fec < '" & fec_max & "' And seg_idcor.Id_cor = ref.Id_cor AND ter.nit = vtas.nit and vtas.ciudad = ciud.descripcion and ciud.departamento = " & dpto & " AND KILOS <>0 " & _
        '                                         "GROUP BY vtas.codigo ,vtas.ciudad ,vtas.descripcion  " & _
        '                                                         "ORDER BY vtas.ciudad  "
        '            Else
        '                If (cbo_linea_prod.Text = "TODOS") Then
        '                    sql = "SELECT vtas.ciudad ,vtas.codigo,vtas.descripcion,SUM(vtas.KILOS)As KILOS ,SUM(vtas.Vr_total)as Vr_total ,SUM(vtas.Cto_total)As Cto_total  " & _
        '                                "FROM Jjv_V_vtas_vend_cliente_ref vtas INNER JOIN referencias ref ON vtas.codigo = ref.codigo, JJV_Grupos_seguimiento seg_idcor,terceros ter   " & _
        '                                        "WHERE vtas.vendedor >= " & ven_min & " And vtas.vendedor <= " & ven_max & " And fec >= '" & fec_ini & "' And fec < '" & fec_max & "' And seg_idcor.Id_cor = ref.Id_cor AND ter.nit = vtas.nit AND vtas.ciudad = '" & ciudad & "' AND KILOS  <>0  " & _
        '                                            "GROUP BY vtas.codigo ,vtas.ciudad ,vtas.descripcion  " & _
        '                                                         "ORDER BY vtas.ciudad  "
        '                Else
        '                    sql = "SELECT vtas.ciudad ,vtas.codigo,vtas.descripcion,SUM(vtas.KILOS)As KILOS ,SUM(vtas.Vr_total)as Vr_total ,SUM(vtas.Cto_total)As Cto_total  " & _
        '                                   "FROM Jjv_V_vtas_vend_cliente_ref vtas INNER JOIN referencias ref ON vtas.codigo = ref.codigo, JJV_Grupos_seguimiento seg_idcor,terceros ter  " & _
        '                                        "WHERE vtas.vendedor >= " & ven_min & " And vtas.vendedor <= " & ven_max & " And fec >= '" & fec_ini & "' And fec < '" & fec_max & "' And seg_idcor.Id_cor = ref.Id_cor and ref.Id_cor = " & id_cor2 & " AND ter.nit = vtas.nit AND vtas.ciudad = '" & ciudad & "' AND KILOS <>0 " & _
        '                                        "GROUP BY vtas.codigo ,vtas.ciudad ,vtas.descripcion  " & _
        '                                                         "ORDER BY vtas.ciudad  "
        '                End If
        '            End If


        '        End If
        '    ElseIf (resp = 7) Then
        '        If (cbo_dpto.Text = "TODOS") Then
        '            If (cbo_linea_prod.Text = "TODOS") Then
        '                sql = "SELECT vtas.ciudad ,ter.nombres,vtas.nit,vtas.codigo,vtas.descripcion,vtas.KILOS,vtas.Vr_total,vtas.Cto_total,((vtas.Vr_total  - vtas.Cto_total ) /vtas.Vr_total  *100 )AS Porc_util " & _
        '                               "FROM Jjv_V_vtas_vend_cliente_ref vtas INNER JOIN referencias ref ON vtas.codigo = ref.codigo, JJV_Grupos_seguimiento seg_idcor,terceros ter  " & _
        '                                    "WHERE vtas.vendedor >= " & ven_min & " And vtas.vendedor <= " & ven_max & " And fec >= '" & fec_ini & "' And fec < '" & fec_max & "' And seg_idcor.Id_cor = ref.Id_cor  AND ter.nit = vtas.nit AND Cto_total <>0  " & _
        '                                        "ORDER BY vtas.ciudad ,ter.nombres "
        '            Else
        '                sql = "SELECT vtas.ciudad ,ter.nombres,vtas.nit,vtas.codigo,vtas.descripcion,vtas.KILOS,vtas.Vr_total,vtas.Cto_total,((vtas.Vr_total  - vtas.Cto_total ) /vtas.Vr_total  *100 )AS Porc_util " & _
        '                               "FROM Jjv_V_vtas_vend_cliente_ref vtas INNER JOIN referencias ref ON vtas.codigo = ref.codigo, JJV_Grupos_seguimiento seg_idcor,terceros ter  " & _
        '                                    "WHERE vtas.vendedor >= " & ven_min & " And vtas.vendedor <= " & ven_max & " And fec >= '" & fec_ini & "' And fec < '" & fec_max & "' And seg_idcor.Id_cor = ref.Id_cor and ref.Id_cor = " & id_cor2 & " AND ter.nit = vtas.nit AND Cto_total <>0 " & _
        '                                        "ORDER BY vtas.ciudad ,ter.nombres "
        '            End If

        '        Else
        '            If (cbo_ciudad.Text = "TODOS") Then
        '                sql = "SELECT vtas.ciudad ,ter.nombres,vtas.nit,vtas.codigo,vtas.descripcion,vtas.KILOS,vtas.Vr_total,vtas.Cto_total,((vtas.Vr_total  - vtas.Cto_total ) /vtas.Vr_total  *100 )AS Porc_util " & _
        '                                   "FROM Jjv_V_vtas_vend_cliente_ref vtas INNER JOIN referencias ref ON vtas.codigo = ref.codigo, JJV_Grupos_seguimiento seg_idcor,terceros ter ,y_ciudades ciud " & _
        '                                        "WHERE vtas.vendedor >= " & ven_min & " And vtas.vendedor <= " & ven_max & " And fec >= '" & fec_ini & "' And fec < '" & fec_max & "' And seg_idcor.Id_cor = ref.Id_cor AND ter.nit = vtas.nit and vtas.ciudad = ciud.descripcion and ciud.departamento = " & dpto & " AND Cto_total <>0 " & _
        '                                        "ORDER BY vtas.ciudad ,ter.nombres "
        '            Else
        '                If (cbo_linea_prod.Text = "TODOS") Then
        '                    sql = "SELECT vtas.ciudad ,ter.nombres,vtas.nit,vtas.codigo,vtas.descripcion,vtas.KILOS,vtas.Vr_total,vtas.Cto_total,((vtas.Vr_total  - vtas.Cto_total ) /vtas.Vr_total  *100 )AS Porc_util " & _
        '                                   "FROM Jjv_V_vtas_vend_cliente_ref vtas INNER JOIN referencias ref ON vtas.codigo = ref.codigo, JJV_Grupos_seguimiento seg_idcor,terceros ter  " & _
        '                                        "WHERE vtas.vendedor >= " & ven_min & " And vtas.vendedor <= " & ven_max & " And fec >= '" & fec_ini & "' And fec < '" & fec_max & "' And seg_idcor.Id_cor = ref.Id_cor AND ter.nit = vtas.nit AND vtas.ciudad = '" & ciudad & "' AND Cto_total <>0 " & _
        '                                        "ORDER BY vtas.ciudad ,ter.nombres "
        '                Else
        '                    sql = "SELECT vtas.ciudad ,ter.nombres,vtas.nit,vtas.codigo,vtas.descripcion,vtas.KILOS,vtas.Vr_total,vtas.Cto_total,((vtas.Vr_total  - vtas.Cto_total ) /vtas.Vr_total  *100 )AS Porc_util " & _
        '                                   "FROM Jjv_V_vtas_vend_cliente_ref vtas INNER JOIN referencias ref ON vtas.codigo = ref.codigo, JJV_Grupos_seguimiento seg_idcor,terceros ter  " & _
        '                                        "WHERE vtas.vendedor >= " & ven_min & " And vtas.vendedor <= " & ven_max & " And fec >= '" & fec_ini & "' And fec < '" & fec_max & "' And seg_idcor.Id_cor = ref.Id_cor and ref.Id_cor = " & id_cor2 & " AND ter.nit = vtas.nit AND vtas.ciudad = '" & ciudad & "' AND Cto_total <>0 " & _
        '                                        "ORDER BY vtas.ciudad ,ter.nombres "
        '                End If
        '            End If


        '        End If
        '    End If
        '    vr_tot = sumarColumnas("Vr_total", dtg_consulta)
        '    cto_tot = sumarColumnas("Cto_total", dtg_consulta)
        '    dtg_consulta.DataSource = obj_vtas_lin_ciuLn.listar_vtas_lin_ciud(sql)
        '    txt_cto_tot.Text = vr_tot.ToString("C0")
        '    txt_vr_total.Text = cto_tot.ToString("C0")
        '    txt_porc_util.Text = ((vr_tot - cto_tot) / vr_tot * 100).ToString("N1")
        '    If (resp = 7) Then
        '        dtg_consulta.Columns("Porc_util").DefaultCellStyle.Format = ("N1")
        '    End If
        '    txt_kilos.Text = sumarColumnas("KILOS", dtg_consulta).ToString("N0")
        '    dtg_consulta.Columns("Cto_total").DefaultCellStyle.Format = ("C0")
        '    dtg_consulta.Columns("Vr_total").DefaultCellStyle.Format = ("C0")
        '    dtg_consulta.Columns("KILOS").DefaultCellStyle.Format = ("N0")

        '    imgProcesar.Visible = False
        'Else
        '    MessageBox.Show("Seleccione todos los criterios de busqueda!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End If

    End Sub

    Private Sub Frm_vtas_lin_ciud_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ano = Now.Year
        While (ano >= Now.Year - 5)
            cboAñoIni.Items.Add(ano)
            cboAñoFin.Items.Add(ano)
            ano -= 1
        End While
        Dim row As DataRow
        Dim dt As New DataTable
        Dim sql As String = ""
        sql = "select vendedor,nombre_vendedor FROM v_vendedores WHERE     (vendedor >= 1001) AND (vendedor <= 1099) AND (bloqueo = 0) ORDER BY nombre_vendedor"
        dt = New DataTable
        dt = obj_vtas_lin_ciuLn.listar_cbo(sql)
        row = dt.NewRow
        row("vendedor") = 0
        row("nombre_vendedor") = "TODOS"
        dt.Rows.Add(row)
        cbo_vend.DataSource = dt
        cbo_vend.ValueMember = "vendedor"
        cbo_vend.DisplayMember = "nombre_vendedor"
        cbo_vend.Text = "Seleccione"
        carga_comp = True
    End Sub
    Private Function sumarColumnas(ByVal nomColumna As String, ByVal dtg As DataGridView) As Double
        Dim total As Double = 0
        For i As Integer = 0 To dtg.RowCount - 1
            total = total + CDbl(dtg.Item(nomColumna.ToLower, i).Value)
        Next
        If (nomColumna = "Porc_util") Then
            total = total / dtg.RowCount - 1
        End If
        Return total
    End Function

    Private Sub PrincipalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FrmPrincipal.Show()
        Me.Close()
        FrmPrincipal.Activate()
    End Sub

    Private Sub SalirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FrmLogin.Show()
        FrmPrincipal.Close()
        Me.Close()
    End Sub

    Private Sub ExportarAExcelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        objOperacionesForm.ExportarDatosExcel(dtg_consulta, "Ventas - linea de producion  ")
    End Sub


    Private Sub cbo_vend_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_vend.SelectedIndexChanged
        If (carga_comp) Then
            cbo_ciud_comp = False
            Dim row As DataRow
            Dim dt As New DataTable
            Dim vend As Integer = cbo_vend.SelectedValue
            Dim sql As String = "SELECT ter.ciudad " & _
                                     "FROM terceros ter " & _
                                         "WHERE ter.vendedor = " & vend & "  " & _
                                            "GROUP BY ter.ciudad "
            dt = obj_vtas_lin_ciuLn.listar_cbo(sql)
            row = dt.NewRow
            row("ciudad") = "TODOS"
            dt.Rows.Add(row)
            cbo_ciudad.DataSource = dt
            cbo_ciudad.DisplayMember = "ciudad"
            cbo_ciudad.Text = "Seleccione"
            cbo_ciud_comp = True
        End If


    End Sub
    Private Sub dtg_consulta_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtg_consulta.CellDoubleClick
        If (e.RowIndex >= 0) Then
            Dim mesini As Integer = cboMesIni.SelectedIndex + 1
            Dim añoIni As Integer = cboAñoIni.SelectedItem
            Dim mesFin As Integer = cboMesFin.SelectedIndex + 1
            Dim añoFin As Integer = cboAñoFin.SelectedItem
            Dim dia_fin As Integer = DateSerial(añoFin, mesFin + 1, 0).Day
            Dim fec_ini As String = añoIni & "/" & mesini & "/01"
            Dim fec_max As String = añoFin & "/" & mesFin & "/" & dia_fin
            Dim nit As Double = dtg_consulta.Item("nit", dtg_consulta.CurrentCell.RowIndex).Value
            Dim sql As String = "SELECT ter.nombres,vtas.nit,vtas.codigo,vtas.descripcion,SUM (vtas.KILOS) as Kilos,SUM(vtas.Vr_total)As Vr_total,SUM(vtas.Cto_total) as Cto_total,(SELECT CASE SUM(vtas.Vr_total) WHEN 0 THEN 0 ELSE((SUM(vtas.Vr_total)  - SUM(vtas.Cto_total) ) /SUM(vtas.Vr_total)  *100 )END)AS Porc_util " & _
                                                  "FROM Jjv_V_vtas_vend_cliente_ref vtas, terceros ter " & _
                                                           "WHERE ter.nit = vtas.nit AND vtas.nit = " & nit & " AND vtas.fec >= '" & fec_ini & "' AND vtas.fec<= '" & fec_max & "'" & _
                                                               " GROUP BY ter.nombres,vtas.nit,vtas.codigo,vtas.descripcion"
            dtg_detalle.DataSource = obj_vtas_lin_ciuLn.listar_vtas_lin_ciud(sql)
        End If
    End Sub
    Private Sub btn_exportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exportar.Click
        objOperacionesForm.ExportarDatosExcel(dtg_detalle, "Detalle ventas")
    End Sub

    Private Sub btn_ppal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ppal.Click
        FrmPrincipal.Show()
        Me.Close()
        FrmPrincipal.Activate()
    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        FrmLogin.Show()
        FrmPrincipal.Close()
        Me.Close()
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        If Not (cboAñoFin.Text = "" Or cboMesIni.Text = "" Or cboAñoIni.Text = "" Or cboMesFin.Text = "" Or cbo_ciudad.Text = "" Or cbo_ciudad.Text = "Seleccione" Or cbo_vend.Text = "Seleccione") Then
            Dim mesini As Integer = cboMesIni.SelectedIndex + 1
            Dim añoIni As Integer = cboAñoIni.SelectedItem
            Dim mesFin As Integer = cboMesFin.SelectedIndex + 1
            Dim añoFin As Integer = cboAñoFin.SelectedItem
            Dim dia_fin As Integer = DateSerial(añoFin, mesFin + 1, 0).Day
            Dim fec_ini As String = añoIni & "/" & mesini & "/01"
            Dim fec_max As String = añoFin & "/" & mesFin & "/" & dia_fin
            Dim where_ciud As String = ""
            Dim vend As Integer = cbo_vend.SelectedValue
            If (cbo_ciudad.Text <> "TODOS") Then
                where_ciud = "AND vtas.ciudad = '" & cbo_ciudad.Text & "'"
            End If
            Dim sql As String = "SELECT ter.nombres,vtas.nit,SUM (vtas.KILOS) as Kilos,SUM(vtas.Vr_total)As Vr_total,SUM(vtas.Cto_total) as Cto_total,(SELECT CASE WHEN SUM(vtas.Vr_total) = 0 THEN 0 ELSE((SUM(vtas.Vr_total)  - SUM(vtas.Cto_total) ) /SUM(vtas.Vr_total)  *100 )END)AS Porc_util " & _
                                               "FROM Jjv_V_vtas_vend_cliente_ref vtas, terceros ter " & _
                                                        "WHERE ter.nit = vtas.nit " & where_ciud & "AND vtas.vendedor=" & vend & " AND vtas.fec >= '" & fec_ini & "' AND vtas.fec<= '" & fec_max & "'" & _
                                                            " GROUP BY ter.nombres,vtas.nit"
            dtg_consulta.DataSource = obj_vtas_lin_ciuLn.listar_vtas_lin_ciud(sql)
        Else
            MessageBox.Show("Seleccione todos los items para generar el informe! ", "Seleccione", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub


    Private Sub cbo_ciudad_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_ciudad.SelectedIndexChanged
        If (cbo_ciud_comp And carga_comp And cboAñoFin.Text <> "" Or cboMesIni.Text <> "" Or cboAñoIni.Text <> "" Or cboMesFin.Text <> "") Then
            btnBuscar.PerformClick()
        End If
    End Sub

    Private Sub cboMesIni_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMesIni.SelectedIndexChanged
        If Not (carga_comp = False Or cboAñoFin.Text = "" Or cboMesIni.Text = "" Or cboAñoIni.Text = "" Or cboMesFin.Text = "" Or cbo_ciudad.Text = "" Or cbo_ciudad.Text = "Seleccione" Or cbo_vend.Text = "Seleccione") Then
            btnBuscar.PerformClick()
        End If
    End Sub

    Private Sub cboAñoIni_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAñoIni.SelectedIndexChanged
        If Not (carga_comp = False Or cboAñoFin.Text = "" Or cboMesIni.Text = "" Or cboAñoIni.Text = "" Or cboMesFin.Text = "" Or cbo_ciudad.Text = "" Or cbo_ciudad.Text = "Seleccione" Or cbo_vend.Text = "Seleccione") Then
            btnBuscar.PerformClick()
        End If
    End Sub

    Private Sub cboMesFin_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMesFin.SelectedIndexChanged
        If Not (carga_comp = False Or cboAñoFin.Text = "" Or cboMesIni.Text = "" Or cboAñoIni.Text = "" Or cboMesFin.Text = "" Or cbo_ciudad.Text = "" Or cbo_ciudad.Text = "Seleccione" Or cbo_vend.Text = "Seleccione") Then
            btnBuscar.PerformClick()
        End If
    End Sub

    Private Sub cboAñoFin_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAñoFin.SelectedIndexChanged
        If Not (carga_comp = False Or cboAñoFin.Text = "" Or cboMesIni.Text = "" Or cboAñoIni.Text = "" Or cboMesFin.Text = "" Or cbo_ciudad.Text = "" Or cbo_ciudad.Text = "Seleccione" Or cbo_vend.Text = "Seleccione") Then
            btnBuscar.PerformClick()
        End If
    End Sub
End Class