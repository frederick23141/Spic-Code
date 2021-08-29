Imports logicaNegocios
Imports entidadNegocios
Public Class Frm_correria
    Private objUsuarioLn As New UsuarioLn
    Private obj_op_simplesLn As New Op_simpesLn
    Private carga_compl As Boolean = False
    Private objOperacionesForm = New OperacionesFormularios
    Private objUsuarioEn As New UsuarioEn
    Dim nomb_vendedor As String = ""
    Private nom_modulo As String
    Public Sub Main(ByVal nom_modulo As String, ByVal permiso As String, ByVal objUsuarioEn As UsuarioEn)
        Me.nom_modulo = nom_modulo
        If (permiso <> "ADMIN") Then
            btnContCambios.Visible = False
        End If
        Me.objUsuarioEn = objUsuarioEn
    End Sub
    Private Sub btnContCambios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnContCambios.Click
        FrmAuditCambios.Show()
        FrmAuditCambios.Main(nom_modulo)
        FrmAuditCambios.WindowState = 2
    End Sub
    Private Sub Frm_correria_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim vendedores As String = objUsuarioLn.coordinadorVend(objUsuarioEn.usuario)
        Dim sql As String = ""
        Dim db As String = "CORSAN"
        Dim criterioVendedor As String = ""
        If (vendedores <> "") Then
            criterioVendedor = " vendedor in (" & vendedores & ")"
        Else
            criterioVendedor = " vendedor >= 1001 AND vendedor <= 1099"
        End If
        sql = "SELECT vendedor,nombre_vendedor  FROM v_vendedores where " & criterioVendedor & "  AND bloqueo =0 "
        cbo_vend.DataSource = obj_op_simplesLn.listar_datatable(sql, db)
        cbo_vend.ValueMember = "vendedor"
        cbo_vend.DisplayMember = "nombre_vendedor"
        cbo_vend.Text = "Seleccione"
        carga_compl = True
    End Sub

    Private Sub cbo_vend_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_vend.SelectedIndexChanged
        If (carga_compl) Then
            chk_ciudades.Items.Clear()
            Dim vend As Integer = cbo_vend.SelectedValue
            Dim sql As String = "SELECT ter.ciudad " & _
                                     "FROM terceros ter " & _
                                         "WHERE ter.vendedor = " & vend & "  " & _
                                            "GROUP BY ter.ciudad "
            Dim lista As New List(Of Object)
            lista = obj_op_simplesLn.lista(sql)
            For i As Integer = 0 To lista.Count - 1 Step 1
                chk_ciudades.Items.Add(lista(i))
            Next
        End If
    End Sub
    Public Sub cargar_consulta()
        imgProc.Visible = True
        Application.DoEvents()
        Dim where_ciud As String = "AND("
        Dim sql As String = ""
        Dim dt As DataTable
        Dim col As DataColumn
        Dim num_meses As Integer
        If (chk3M.Checked) Then
            num_meses = 2
        ElseIf (chk6M.Checked) Then
            num_meses = 6
        ElseIf (chk12M.Checked) Then
            num_meses = 12
        End If
        Dim fec As Date = DateAdd("m", -num_meses, Now.Year & "-" & Now.Month & "-" & Now.Day)
        Dim sFec As String = obj_op_simplesLn.cambiarFormatoFecha(fec)
        For i As Integer = 0 To chk_ciudades.CheckedItems.Count - 1
            If (i = 0) Then
                If (i = chk_ciudades.CheckedItems.Count - 1) Then
                    where_ciud += "ter.ciudad like '%" & chk_ciudades.CheckedItems(i).ToString & "%' )"
                Else
                    where_ciud += "ter.ciudad like '%" & chk_ciudades.CheckedItems(i).ToString & "%' "
                End If
            ElseIf (i = chk_ciudades.CheckedItems.Count - 1) Then
                where_ciud += "OR ter.ciudad like '%" & chk_ciudades.CheckedItems(i).ToString & "%')"

            Else
                where_ciud += "OR ter.ciudad like '%" & chk_ciudades.CheckedItems(i).ToString & "%'"
            End If
        Next
        'sql = "SELECT  ter.ciudad ,doc.nit,ter.nombres ,SUM (doc.Vr_total  )/" & num_meses & " As Prom_vtas , SUM(doc.Vr_total) As Ventas " & _
        '                         "FROM Jjv_V_vtas_vend_cliente_ref  doc ,terceros ter " & _
        '                              "WHERE doc.vendedor = " & cbo_vend.SelectedValue & " AND  doc.fec  >='" & fec & "' and ter.nit = doc.nit  " & where_ciud & _
        '                                   "GROUP by ter.nombres ,doc.nit ,ter.ciudad ,ter.cupo_credito ,ter.condicion ,ter.bloqueo  " & _
        '                                        "ORDER BY  ter.ciudad "
        sql = "SELECT  ter.ciudad ,doc.nit,ter.nombres ,SUM (doc.Vr_total  )/" & num_meses & " As Prom_vtas , " & _
                       "(select SUM (Vr_total ) from Jjv_V_vtas_vend_cliente_ref  where vendedor = " & cbo_vend.SelectedValue & "  and MONTH (fec )= " & Now.Month & " and YEAR (fec)=" & Now.Year & " and nit = doc.nit  )As Ventas, " & _
                       "(select SUM (rec.Total_rec) from Jjv_Recaudos_consol rec where rec.vendedor = " & cbo_vend.SelectedValue & " and MONTH (rec.fecha ) = " & Now.Month & " and YEAR (rec.fecha )=" & Now.Year & " and rec.nit = doc.nit ) As Recaudos " & _
                           "FROM Jjv_V_vtas_vend_cliente_ref  doc ,terceros ter  " & _
                            "WHERE doc.vendedor = " & cbo_vend.SelectedValue & " AND  doc.fec  >='" & sFec & "' and ter.nit = doc.nit    " & where_ciud & _
                             "GROUP by ter.nombres ,doc.nit ,ter.ciudad ,ter.cupo_credito ,ter.condicion ,ter.bloqueo   " & _
                              "ORDER BY  ter.ciudad "
        dt = obj_op_simplesLn.listar_datatable(sql, "CORSAN")
        col = New DataColumn
        col.ColumnName = "Ppto_vtas"
        dt.Columns.Add(col)
        col = New DataColumn
        col.ColumnName = "Ppto_rec"
        dt.Columns.Add(col)
        col = New DataColumn
        col.ColumnName = "Observaciones"
        dt.Columns.Add(col)
        dtg_consulta.DataSource = dt
        nomb_vendedor = cbo_vend.Text
        imgProc.Visible = False
    End Sub
    Private Sub btn_exportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exportar.Click
        objOperacionesForm.ExportarDatosExcel(dtg_consulta, "Correria " & nomb_vendedor)
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

    Private Sub chk3M_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk3M.CheckedChanged

        If chk3M.Checked = True Then
            chk12M.Checked = False
            chk6M.Checked = False
        End If
    End Sub

    Private Sub chk6M_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk6M.CheckedChanged
        If chk6M.Checked = True Then
            chk12M.Checked = False
            chk3M.Checked = False
        End If
    End Sub

    Private Sub chk12M_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk12M.CheckedChanged
        If (carga_compl) Then
            If chk12M.Checked = True Then
                chk3M.Checked = False
                chk6M.Checked = False
            End If
        End If
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        If (cbo_vend.Text <> "Seleccione" And chk_ciudades.CheckedItems.Count <> 0) Then
            cargar_consulta()
        Else
            MessageBox.Show("Seleccione items para generar la correria! ", "Seleccione", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub


End Class