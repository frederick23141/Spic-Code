Imports System.Configuration
Imports logicaNegocios
Imports entidadNegocios
Imports System.IO
Imports Microsoft.Office.Interop
#Disable Warning BC40056 ' El espacio de nombres o el tipo especificado en el 'System.Data.SqlServerCe' Imports no contienen ningún miembro público o no se encuentran. Asegúrese de que el espacio de nombres o el tipo se hayan definido y de que contengan al menos un miembro público. Asegúrese de que el nombre del elemento importado no use ningún alias.
Imports System.Data.SqlServerCe
#Enable Warning BC40056 ' El espacio de nombres o el tipo especificado en el 'System.Data.SqlServerCe' Imports no contienen ningún miembro público o no se encuentran. Asegúrese de que el espacio de nombres o el tipo se hayan definido y de que contengan al menos un miembro público. Asegúrese de que el nombre del elemento importado no use ningún alias.
Public Class Frm_ppal_clientes
    Private objUsuarioLn As New UsuarioLn
    Dim ano As Integer = Now.Year - 3
    Private obj_ppal_clientesLn As New Ppal_clientesLn
    Private objOperacionesForm As New OperacionesFormularios
    Private objUsuarioEn As New UsuarioEn
    Private carga_completa As Boolean = False
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
    Private Sub Frm_ppal_clientes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim vendedores As String = objUsuarioLn.coordinadorVend(objUsuarioEn.usuario)
        Dim criterioVendedor As String = ""
        If (vendedores <> "") Then
            criterioVendedor = " vendedor in (" & vendedores & ")"
        Else
            criterioVendedor = " vendedor >= 1001 AND vendedor <= 1099"
        End If
        Dim sql As String = "SELECT vendedor,nombre_vendedor  " & _
                                "FROM v_vendedores " & _
                                    "WHERE " & criterioVendedor & " and bloqueo =0"
        Dim col As New DataColumn
        Dim dt As New DataTable
        Dim dr As DataRow
        While (ano <= Now.Year)
            cbo_ano.Items.Add(ano)
            ano += 1
        End While
        cbo_ano.SelectedIndex = 2
        dt = obj_ppal_clientesLn.listar_datatable(sql)
        dr = dt.NewRow
        dr("vendedor") = 0
        dr("nombre_vendedor") = "TODOS"
        dt.Rows.Add(dr)
        cbo_vendedores.DataSource = dt
        cbo_vendedores.ValueMember = "vendedor"
        cbo_vendedores.DisplayMember = "nombre_vendedor"
        cbo_vendedores.Text = "Seleccione"
        carga_completa = True
    End Sub
    Private Sub cargar_consulta()
        If (carga_completa) Then
            If (cbo_ano.Text <> "" And cbo_vendedores.Text <> "Seleccione" And (chk_porc_utl.Checked = True Or chkKil.Checked = True Or ChkPesos.Checked = True)) Then
                imgProc.Visible = True
                Application.DoEvents()
                Dim dt As New DataTable
                Dim ano As Integer = cbo_ano.Text
                Dim vend_min As Integer = 0
                Dim vend_max As Integer = 0
                Dim criterio As String = ""
                Dim order_sql As String = ""
                If (cbo_vendedores.Text = "TODOS") Then
                    vend_min = 1001
                    vend_max = 1099
                Else
                    vend_min = cbo_vendedores.SelectedValue
                    vend_max = cbo_vendedores.SelectedValue
                End If
                If (chk_porc_utl.Checked = True) Then
                    order_sql = "ORDER BY (SELECT CASE WHEN SUM (vtas.Cto_total )=0 THEN 0 ELSE ((SUM (vtas.Vr_total)-SUM (vtas.Cto_total ))/SUM (vtas.Cto_total )*100)END )desc"
                Else
                    If (chkKil.Checked = True) Then
                        criterio = "Vr_total"
                    ElseIf (ChkPesos.Checked = True) Then
                        criterio = "KILOS"
                    End If
                    order_sql = "ORDER BY SUM (vtas." & criterio & " )desc"
                End If
                Dim sql As String = "SELECT vtas.nit, ter.nombres ,ter.Region,ter.TipoCliente,SUM (vtas.Vr_total)As Vr_total,SUM (vtas.Cto_total )As Cto_total,SUM (vtas.KILOS )As Kilos,(SELECT CASE WHEN SUM (vtas.Cto_total )=0 THEN 0 ELSE ((SUM (vtas.Vr_total)-SUM (vtas.Cto_total ))/SUM (vtas.Cto_total )*100)END )As util " & _
                                         "FROM Jjv_V_vtas_vend_cliente_ref vtas ,Jjv_Datos_Clientes_completo ter " & _
                                                "WHERE(ter.nit = vtas.nit And Year(fec) = " & ano & " And vtas.vendedor >= " & vend_min & " And vtas.vendedor <= " & vend_max & ") " & _
                                                    "GROUP BY vtas.nit, ter.nombres,ter.Region,ter.TipoCliente " & _
                                                        order_sql
                dt = obj_ppal_clientesLn.listar_datatable(sql)
                dt.Rows.Add()
                dtg_consulta.DataSource = dt

                dtg_consulta.Item("nombres", dtg_consulta.RowCount - 1).Value = "TOTAL"
                dtg_consulta.Item("Vr_total", dtg_consulta.RowCount - 1).Value = sumarColumnas("Vr_total")
                dtg_consulta.Item("Cto_total", dtg_consulta.RowCount - 1).Value = sumarColumnas("Cto_total")
                dtg_consulta.Item("Kilos", dtg_consulta.RowCount - 1).Value = sumarColumnas("Kilos")
                dtg_consulta.Item("util", dtg_consulta.RowCount - 1).Value = (dtg_consulta.Item("Vr_total", dtg_consulta.RowCount - 1).Value - dtg_consulta.Item("Cto_total", dtg_consulta.RowCount - 1).Value) / dtg_consulta.Item("Vr_total", dtg_consulta.RowCount - 1).Value * 100
                formatoNegrita()
                imgProc.Visible = False
            End If
        End If
    End Sub
    Public Sub formatoNegrita()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        dtg_consulta.Columns(0).DefaultCellStyle = DataGridViewCellStyle1
        dtg_consulta.Columns(1).DefaultCellStyle = DataGridViewCellStyle1
        dtg_consulta.Rows(dtg_consulta.RowCount - 1).DefaultCellStyle = DataGridViewCellStyle1
    End Sub
    Private Function sumarColumnas(ByVal nomColumna As String) As Double
        Dim total As Double = 0
        For i As Integer = 0 To dtg_consulta.RowCount - 2
            If Not IsDBNull(dtg_consulta.Item(nomColumna.ToLower, i).Value) Then
                total = total + CDbl(dtg_consulta.Item(nomColumna.ToLower, i).Value)
            End If
        Next
        Return total
    End Function
    Private Sub cbo_ano_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_ano.SelectedIndexChanged
        cargar_consulta()
    End Sub

    Private Sub cbo_vendedores_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_vendedores.SelectedIndexChanged
        cargar_consulta()
    End Sub

    Private Sub ChkPesos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkPesos.CheckedChanged
        If (ChkPesos.Checked = True) Then
            chk_porc_utl.Checked = False
            chkKil.Checked = False
        End If
        cargar_consulta()
    End Sub

    Private Sub chkKil_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkKil.CheckedChanged
        If (chkKil.Checked = True) Then
            chk_porc_utl.Checked = False
            ChkPesos.Checked = False
        End If
        cargar_consulta()
    End Sub

    Private Sub chk_porc_utl_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_porc_utl.CheckedChanged
        If (chk_porc_utl.Checked = True) Then
            chkKil.Checked = False
            ChkPesos.Checked = False
        End If
        cargar_consulta()
    End Sub

    Private Sub btn_exportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exportar.Click
        objOperacionesForm.ExportarDatosExcel(dtg_consulta, "Principales clientes")
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
End Class