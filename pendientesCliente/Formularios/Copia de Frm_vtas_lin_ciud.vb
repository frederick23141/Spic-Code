Imports System.Configuration
Imports logicaNegocios
Imports System.IO
Imports Microsoft.Office.Interop
Public Class Frm_vtas_lin_ciud
    Private obj_vtas_lin_ciuLn As New vtas_lin_ciudLn
    Private objOperacionesForm As OperacionesFormularios = New OperacionesFormularios
    Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
        If Not (cbo_dpto.Text = "Seleccione" Or cbo_vend.Text = "Seleccione" Or cbo_linea_prod.Text = "Seleccione" Or cbo_ciudad.Text = "Seleccione" Or cboMesIni.Text = "" Or cboMesFin.Text = "" Or cboAñoFin.Text = "" Or cboAñoIni.Text = "" Or cbo_ciudad.Text = "") Then
            Dim resp As Integer = MessageBox.Show("Desea agrupar informe por codigo de producto? ", "Agrupación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            imgProcesar.Visible = True
            Application.DoEvents()
            Dim mesini As Integer = cboMesIni.SelectedIndex + 1
            Dim añoIni As Integer = cboAñoIni.SelectedItem
            Dim mesFin As Integer = cboMesFin.SelectedIndex + 1
            Dim añoFin As Integer = cboAñoFin.SelectedItem
            Dim dia_fin As Integer = DateSerial(añoFin, mesFin + 1, 0).Day
            Dim fec_ini As String = añoIni & "/" & mesini & "/01"
            Dim fec_max As String = añoFin & "/" & mesFin & "/" & dia_fin
            Dim ven_min As Integer
            Dim ven_max As Integer
            Dim id_cor2 As Integer = cbo_linea_prod.SelectedValue
            Dim ciudad As String = cbo_ciudad.Text
            Dim sql As String
            Dim dpto As Integer = cbo_dpto.SelectedValue
            Dim vr_tot As Double = 0
            Dim cto_tot As Double = 0
            If (cbo_vend.Text = "TODOS") Then
                ven_min = 1001
                ven_max = 1099
            Else
                ven_min = cbo_vend.SelectedValue
                ven_max = cbo_vend.SelectedValue
            End If
            If (resp = 6) Then
                If (cbo_dpto.Text = "TODOS") Then
                    If (cbo_linea_prod.Text = "TODOS") Then
                        sql = "SELECT vtas.ciudad ,vtas.codigo,vtas.descripcion,SUM(vtas.KILOS)As KILOS ,SUM(vtas.Vr_total)as Vr_total ,SUM(vtas.Cto_total) As Cto_total " & _
                                       "FROM Jjv_V_vtas_vend_cliente_ref vtas INNER JOIN referencias ref ON vtas.codigo = ref.codigo, JJV_Grupos_seguimiento seg_idcor,terceros ter  " & _
                                            "WHERE vtas.vendedor >= " & ven_min & " And vtas.vendedor <= " & ven_max & " And fec >= '" & fec_ini & "' And fec < '" & fec_max & "' And seg_idcor.Id_cor = ref.Id_cor  AND ter.nit = vtas.nit AND KILOS <>0  " & _
                                                 "GROUP BY vtas.codigo ,vtas.ciudad ,vtas.descripcion  " & _
                                                                 "ORDER BY vtas.ciudad  "
                    Else
                        sql = "SELECT vtas.ciudad ,vtas.codigo,vtas.descripcion,SUM(vtas.KILOS)As KILOS ,SUM(vtas.Vr_total)as Vr_total ,SUM(vtas.Cto_total) As Cto_total " & _
                                       "FROM Jjv_V_vtas_vend_cliente_ref vtas INNER JOIN referencias ref ON vtas.codigo = ref.codigo, JJV_Grupos_seguimiento seg_idcor,terceros ter  " & _
                                            "WHERE vtas.vendedor >= " & ven_min & " And vtas.vendedor <= " & ven_max & " And fec >= '" & fec_ini & "' And fec < '" & fec_max & "' And seg_idcor.Id_cor = ref.Id_cor and ref.Id_cor = " & id_cor2 & " AND ter.nit = vtas.nit AND KILOS <>0 " & _
                                                 "GROUP BY vtas.codigo ,vtas.ciudad ,vtas.descripcion  " & _
                                                                 "ORDER BY vtas.ciudad  "
                    End If

                Else
                    If (cbo_ciudad.Text = "TODOS") Then
                        sql = "SELECT vtas.ciudad ,vtas.codigo,vtas.descripcion,SUM(vtas.KILOS)As KILOS ,SUM(vtas.Vr_total)as Vr_total ,SUM(vtas.Cto_total) As Cto_total " & _
                                           "FROM Jjv_V_vtas_vend_cliente_ref vtas INNER JOIN referencias ref ON vtas.codigo = ref.codigo, JJV_Grupos_seguimiento seg_idcor,terceros ter ,y_ciudades ciud " & _
                                                "WHERE vtas.vendedor >= " & ven_min & " And vtas.vendedor <= " & ven_max & " And fec >= '" & fec_ini & "' And fec < '" & fec_max & "' And seg_idcor.Id_cor = ref.Id_cor AND ter.nit = vtas.nit and vtas.ciudad = ciud.descripcion and ciud.departamento = " & dpto & " AND KILOS <>0 " & _
                                                 "GROUP BY vtas.codigo ,vtas.ciudad ,vtas.descripcion  " & _
                                                                 "ORDER BY vtas.ciudad  "
                    Else
                        If (cbo_linea_prod.Text = "TODOS") Then
                            sql = "SELECT vtas.ciudad ,vtas.codigo,vtas.descripcion,SUM(vtas.KILOS)As KILOS ,SUM(vtas.Vr_total)as Vr_total ,SUM(vtas.Cto_total)As Cto_total  " & _
                                        "FROM Jjv_V_vtas_vend_cliente_ref vtas INNER JOIN referencias ref ON vtas.codigo = ref.codigo, JJV_Grupos_seguimiento seg_idcor,terceros ter   " & _
                                                "WHERE vtas.vendedor >= " & ven_min & " And vtas.vendedor <= " & ven_max & " And fec >= '" & fec_ini & "' And fec < '" & fec_max & "' And seg_idcor.Id_cor = ref.Id_cor AND ter.nit = vtas.nit AND vtas.ciudad = '" & ciudad & "' AND KILOS  <>0  " & _
                                                    "GROUP BY vtas.codigo ,vtas.ciudad ,vtas.descripcion  " & _
                                                                 "ORDER BY vtas.ciudad  "
                        Else
                            sql = "SELECT vtas.ciudad ,vtas.codigo,vtas.descripcion,SUM(vtas.KILOS)As KILOS ,SUM(vtas.Vr_total)as Vr_total ,SUM(vtas.Cto_total)As Cto_total  " & _
                                           "FROM Jjv_V_vtas_vend_cliente_ref vtas INNER JOIN referencias ref ON vtas.codigo = ref.codigo, JJV_Grupos_seguimiento seg_idcor,terceros ter  " & _
                                                "WHERE vtas.vendedor >= " & ven_min & " And vtas.vendedor <= " & ven_max & " And fec >= '" & fec_ini & "' And fec < '" & fec_max & "' And seg_idcor.Id_cor = ref.Id_cor and ref.Id_cor = " & id_cor2 & " AND ter.nit = vtas.nit AND vtas.ciudad = '" & ciudad & "' AND KILOS <>0 " & _
                                                "GROUP BY vtas.codigo ,vtas.ciudad ,vtas.descripcion  " & _
                                                                 "ORDER BY vtas.ciudad  "
                        End If
                    End If


                End If
            ElseIf (resp = 7) Then
                If (cbo_dpto.Text = "TODOS") Then
                    If (cbo_linea_prod.Text = "TODOS") Then
                        sql = "SELECT vtas.ciudad ,ter.nombres,vtas.nit,vtas.codigo,vtas.descripcion,vtas.KILOS,vtas.Vr_total,vtas.Cto_total,((vtas.Vr_total  - vtas.Cto_total ) /vtas.Vr_total  *100 )AS Porc_util " & _
                                       "FROM Jjv_V_vtas_vend_cliente_ref vtas INNER JOIN referencias ref ON vtas.codigo = ref.codigo, JJV_Grupos_seguimiento seg_idcor,terceros ter  " & _
                                            "WHERE vtas.vendedor >= " & ven_min & " And vtas.vendedor <= " & ven_max & " And fec >= '" & fec_ini & "' And fec < '" & fec_max & "' And seg_idcor.Id_cor = ref.Id_cor  AND ter.nit = vtas.nit AND Cto_total <>0  " & _
                                                "ORDER BY vtas.ciudad ,ter.nombres "
                    Else
                        sql = "SELECT vtas.ciudad ,ter.nombres,vtas.nit,vtas.codigo,vtas.descripcion,vtas.KILOS,vtas.Vr_total,vtas.Cto_total,((vtas.Vr_total  - vtas.Cto_total ) /vtas.Vr_total  *100 )AS Porc_util " & _
                                       "FROM Jjv_V_vtas_vend_cliente_ref vtas INNER JOIN referencias ref ON vtas.codigo = ref.codigo, JJV_Grupos_seguimiento seg_idcor,terceros ter  " & _
                                            "WHERE vtas.vendedor >= " & ven_min & " And vtas.vendedor <= " & ven_max & " And fec >= '" & fec_ini & "' And fec < '" & fec_max & "' And seg_idcor.Id_cor = ref.Id_cor and ref.Id_cor = " & id_cor2 & " AND ter.nit = vtas.nit AND Cto_total <>0 " & _
                                                "ORDER BY vtas.ciudad ,ter.nombres "
                    End If

                Else
                    If (cbo_ciudad.Text = "TODOS") Then
                        sql = "SELECT vtas.ciudad ,ter.nombres,vtas.nit,vtas.codigo,vtas.descripcion,vtas.KILOS,vtas.Vr_total,vtas.Cto_total,((vtas.Vr_total  - vtas.Cto_total ) /vtas.Vr_total  *100 )AS Porc_util " & _
                                           "FROM Jjv_V_vtas_vend_cliente_ref vtas INNER JOIN referencias ref ON vtas.codigo = ref.codigo, JJV_Grupos_seguimiento seg_idcor,terceros ter ,y_ciudades ciud " & _
                                                "WHERE vtas.vendedor >= " & ven_min & " And vtas.vendedor <= " & ven_max & " And fec >= '" & fec_ini & "' And fec < '" & fec_max & "' And seg_idcor.Id_cor = ref.Id_cor AND ter.nit = vtas.nit and vtas.ciudad = ciud.descripcion and ciud.departamento = " & dpto & " AND Cto_total <>0 " & _
                                                "ORDER BY vtas.ciudad ,ter.nombres "
                    Else
                        If (cbo_linea_prod.Text = "TODOS") Then
                            sql = "SELECT vtas.ciudad ,ter.nombres,vtas.nit,vtas.codigo,vtas.descripcion,vtas.KILOS,vtas.Vr_total,vtas.Cto_total,((vtas.Vr_total  - vtas.Cto_total ) /vtas.Vr_total  *100 )AS Porc_util " & _
                                           "FROM Jjv_V_vtas_vend_cliente_ref vtas INNER JOIN referencias ref ON vtas.codigo = ref.codigo, JJV_Grupos_seguimiento seg_idcor,terceros ter  " & _
                                                "WHERE vtas.vendedor >= " & ven_min & " And vtas.vendedor <= " & ven_max & " And fec >= '" & fec_ini & "' And fec < '" & fec_max & "' And seg_idcor.Id_cor = ref.Id_cor AND ter.nit = vtas.nit AND vtas.ciudad = '" & ciudad & "' AND Cto_total <>0 " & _
                                                "ORDER BY vtas.ciudad ,ter.nombres "
                        Else
                            sql = "SELECT vtas.ciudad ,ter.nombres,vtas.nit,vtas.codigo,vtas.descripcion,vtas.KILOS,vtas.Vr_total,vtas.Cto_total,((vtas.Vr_total  - vtas.Cto_total ) /vtas.Vr_total  *100 )AS Porc_util " & _
                                           "FROM Jjv_V_vtas_vend_cliente_ref vtas INNER JOIN referencias ref ON vtas.codigo = ref.codigo, JJV_Grupos_seguimiento seg_idcor,terceros ter  " & _
                                                "WHERE vtas.vendedor >= " & ven_min & " And vtas.vendedor <= " & ven_max & " And fec >= '" & fec_ini & "' And fec < '" & fec_max & "' And seg_idcor.Id_cor = ref.Id_cor and ref.Id_cor = " & id_cor2 & " AND ter.nit = vtas.nit AND vtas.ciudad = '" & ciudad & "' AND Cto_total <>0 " & _
                                                "ORDER BY vtas.ciudad ,ter.nombres "
                        End If
                    End If


                End If
            End If
            vr_tot = sumarColumnas("Vr_total", dtg_consulta)
            cto_tot = sumarColumnas("Cto_total", dtg_consulta)
            dtg_consulta.DataSource = obj_vtas_lin_ciuLn.listar_vtas_lin_ciud(sql)
            txt_cto_tot.Text = vr_tot.ToString("C0")
            txt_vr_total.Text = cto_tot.ToString("C0")
            txt_porc_util.Text = ((vr_tot - cto_tot) / vr_tot * 100).ToString("N1")
            If (resp = 7) Then
                dtg_consulta.Columns("Porc_util").DefaultCellStyle.Format = ("N1")
            End If
            txt_kilos.Text = sumarColumnas("KILOS", dtg_consulta).ToString("N0")
            dtg_consulta.Columns("Cto_total").DefaultCellStyle.Format = ("C0")
            dtg_consulta.Columns("Vr_total").DefaultCellStyle.Format = ("C0")
            dtg_consulta.Columns("KILOS").DefaultCellStyle.Format = ("N0")

            imgProcesar.Visible = False
        Else
            MessageBox.Show("Seleccione todos los criterios de busqueda!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

    Private Sub Frm_vtas_lin_ciud_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ano = Now.Year
        Dim row As DataRow
        Dim dt As New DataTable
        Dim sql As String = "SELECT  departamento,descripcion  " & _
                               "FROM y_departamentos  " & _
                                    "ORDER BY descripcion"
        dt = obj_vtas_lin_ciuLn.listar_cbo(sql)
        row = dt.NewRow
        row("departamento") = 0
        row("descripcion") = "TODOS"
        dt.Rows.Add(row)
        cbo_dpto.DataSource = dt
        cbo_dpto.ValueMember = "departamento"
        cbo_dpto.DisplayMember = "descripcion"
        cbo_dpto.Text = "Seleccione"

        While (ano >= Now.Year - 5)
            cboAñoIni.Items.Add(ano)
            cboAñoFin.Items.Add(ano)
            ano -= 1
        End While

        sql = "SELECT Id_cor,Descripcion   FROM JJV_Grupos_seguimiento ORDER BY id_cor"
        dt = New DataTable
        dt = obj_vtas_lin_ciuLn.listar_cbo(sql)
        row = dt.NewRow
        row("Id_cor") = 0
        row("Descripcion") = "TODOS"
        dt.Rows.Add(row)
        cbo_linea_prod.DataSource = dt
        cbo_linea_prod.ValueMember = "Id_cor"
        cbo_linea_prod.DisplayMember = "Descripcion"
        cbo_linea_prod.Text = "Seleccione"

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
    End Sub

    Private Sub cbo_dpto_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_dpto.SelectedIndexChanged
        Dim dpto_text As String = cbo_dpto.Text
        Dim dpto As String
        Dim sql As String = ""
        Dim row As DataRow
        Dim dt As New DataTable
        If (dpto_text <> "System.Data.DataRowView" And dpto_text <> ".") Then
            dpto = cbo_dpto.SelectedValue
            If (dpto = "todos") Then
                sql = "SELECT  ciudad  ,descripcion " & _
                                    "FROM y_ciudades  " & _
                                         "ORDER BY descripcion "
            Else
                sql = "SELECT  ciudad  ,descripcion " & _
                                    "FROM y_ciudades  " & _
                                          "WHERE departamento = " & dpto & " " & _
                                             "ORDER BY  descripcion "
            End If

            dt = obj_vtas_lin_ciuLn.listar_cbo(sql)
            row = dt.NewRow
            row("ciudad") = 0
            row("descripcion") = "TODOS"
            dt.Rows.Add(row)
            cbo_ciudad.DataSource = dt
            cbo_ciudad.ValueMember = "ciudad"
            cbo_ciudad.DisplayMember = "descripcion"
            cbo_ciudad.Text = "Seleccione"
        End If



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

    Private Sub PrincipalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrincipalToolStripMenuItem.Click
        FrmPrincipal.Show()
        Me.Close()
        FrmPrincipal.Activate()
    End Sub

    Private Sub SalirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalirToolStripMenuItem.Click
        FrmLogin.Show()
        FrmPrincipal.Close()
        Me.Close()
    End Sub

    Private Sub ExportarAExcelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportarAExcelToolStripMenuItem.Click
        objOperacionesForm.ExportarDatosExcel(dtg_consulta, "Ventas - linea de producion  ")
    End Sub


End Class