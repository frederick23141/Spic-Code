Imports System.Configuration
Imports logicaNegocios
Imports System.IO
Imports entidadNegocios
Imports Microsoft.Office.Interop
Public Class Frm_vtas_zona
    Private objOperacionesForm As OperacionesFormularios = New OperacionesFormularios
    Private carga_comp As Boolean = False
    Private objOpSimplesLn As New Op_simpesLn
    Private Sub btn_exportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exportar.Click
        objOperacionesForm.ExportarDatosExcel(dtg_consulta, "VENTAS - CIUDAD:" & cbo_ciudad.Text & " - LINEA:" & cbo_linea.Text)
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

    Private Sub Frm_vtas_zona_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim sql As String
        Dim dt As New DataTable
        Dim dr As DataRow
        Dim ano As Integer = Now.Year
        While (ano >= Now.Year - 5)
            cboAñoIni.Items.Add(ano)
            cboAñoFin.Items.Add(ano)
            ano -= 1
        End While
        sql = "SELECT ciudad,descripcion  FROM y_ciudades WHERE pais = 169 ORDER BY descripcion "
        dt = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        dr = dt.NewRow
        dr("ciudad") = 0
        dr("descripcion") = "TODO"
        dt.Rows.Add(dr)
        cbo_ciudad.DataSource = dt
        cbo_ciudad.ValueMember = "ciudad"
        cbo_ciudad.DisplayMember = "descripcion"
        cbo_ciudad.Text = "TODO"

        dt = New DataTable
        sql = "SELECT Id_cor,Descripcion  FROM JJV_Grupos_seguimiento "
        dt = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        dr = dt.NewRow
        dr("Id_cor") = 0
        dr("descripcion") = "TODO"
        dt.Rows.Add(dr)
        cbo_linea.DataSource = dt
        cbo_linea.ValueMember = "Id_cor"
        cbo_linea.DisplayMember = "descripcion"
        cbo_linea.Text = "TODO"

       
    End Sub
    Private Sub cargar_consulta()
        imgProcesar.Visible = True
        Application.DoEvents()
        Dim dt As New DataTable
        Dim dr As DataRow
        Dim mesini As Integer = cboMesIni.SelectedIndex + 1
        Dim añoIni As Integer = cboAñoIni.Text
        Dim mesFin As Integer = cboMesFin.SelectedIndex + 1
        Dim añoFin As Integer = cboAñoFin.Text
        Dim dia_fin As Integer = DateSerial(añoFin, mesFin + 1, 0).Day
        Dim fec_ini As String = añoIni & "/" & mesini & "/01"
        Dim fec_max As String = añoFin & "/" & mesFin & "/" & dia_fin
        Dim sql As String = ""
        Dim selectSql As String = ""
        Dim whereCiudad As String = ""
        Dim whereIdCor As String = ""
        If (cbo_linea.Text <> "TODO") Then
            whereIdCor = "  vtas.id_cor = " & cbo_linea.SelectedValue & " AND "
        End If
        If (cbo_ciudad.Text <> "TODO") Then
            whereCiudad = "  ter.ciudad like '%" & cbo_ciudad.Text & "%' AND "
        End If
        sql = "SELECT vtas.vend_hoy,ter.ciudad,ter.nombres,vtas.nit,SUM (vtas.KILOS) as Kilos,SUM(vtas.Vr_total)As Vr_total,SUM(vtas.Cto_total) as Cto_total,(SELECT CASE WHEN SUM(vtas.Vr_total) = 0 THEN 0 ELSE((SUM(vtas.Vr_total)  - SUM(vtas.Cto_total) ) /SUM(vtas.Vr_total)  *100 )END)AS Porc_util " & _
                         "FROM Jjv_V_vtas_vend_cliente_ref vtas, terceros ter " & _
                                  "WHERE ter.nit = vtas.nit AND " & whereCiudad & " " & whereIdCor & "  vtas.fec >= '" & fec_ini & "' AND vtas.fec<= '" & fec_max & "'" & _
                                      " GROUP BY ter.nombres,vtas.nit,ter.ciudad,vtas.vend_hoy "
        dt = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        dr = dt.NewRow()
        dr("nombres") = "TOTAL"
        dt.Rows.Add(dr)
        dtg_consulta.DataSource = dt

        dtg_consulta.Item("Kilos", dtg_consulta.RowCount - 1).Value = sumarColumnas("Kilos", dtg_consulta)
        dtg_consulta.Item("Vr_total", dtg_consulta.RowCount - 1).Value = sumarColumnas("Vr_total", dtg_consulta)
        dtg_consulta.Item("Cto_total", dtg_consulta.RowCount - 1).Value = sumarColumnas("Cto_total", dtg_consulta)
        dtg_consulta.Item("Porc_util", dtg_consulta.RowCount - 1).Value = sumarColumnas("Porc_util", dtg_consulta)
        dtg_consulta.Columns("Porc_util").DefaultCellStyle.Format = "N2"

        dtg_consulta.Rows(dtg_consulta.RowCount - 1).DefaultCellStyle.ForeColor = Color.Red
        dtg_consulta.Rows(dtg_consulta.RowCount - 1).DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        imgProcesar.Visible = False
    End Sub

    Private Function sumarColumnas(ByVal nomColumna As String, ByVal dtg As DataGridView) As Double
        Dim total As Double = 0
        For i As Integer = 0 To dtg.RowCount - 2
            If Not (IsDBNull(dtg.Item(nomColumna.ToLower, i).Value)) Then
                total = total + CDbl(dtg.Item(nomColumna.ToLower, i).Value)
            End If
        Next
        If (nomColumna = "Porc_util") Then
            total = total / dtg.RowCount - 2
        End If
        Return total
    End Function
    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        If (cboAñoFin.Text <> "" And cboMesFin.Text <> "" And cboAñoIni.Text <> "" And cboMesIni.Text <> "") Then
            cargar_consulta()
        Else
            MessageBox.Show("Seleccione todos los items para generar el informe! ", "Seleccione", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

End Class