Imports entidadNegocios
Imports logicaNegocios

Public Class FrmSeguimientoGrupos


    Dim mes As Integer = 0
    Dim ano As Integer = 0
    Dim usuario_vendedor As Integer
    Dim permiso As String
    Private objUsuarioEn As New UsuarioEn
    Private objIngProdLn As New Ing_prodLn
    Private objOpSimplesLn As New Op_simpesLn
    Private objOperacionesForm As New OperacionesFormularios
    Dim tam As Integer = 0
    Private nom_modulo As String = ""

    'carga de ventana
    Public Sub main(ByVal nom_modulo As String, ByVal permiso As String, ByVal vendedor As String)
        Me.nom_modulo = nom_modulo
        Me.objUsuarioEn = objUsuarioEn
        Me.permiso = permiso
        usuario_vendedor = vendedor
        If Replace(permiso, " ", "") = "VENDEDOR" Then
            cbo_vendedor.Visible = False
            lblVendedor.Visible = False
        End If
    End Sub
    Private Sub FrmSeguimientoGrupos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenarCbo()
        Me.CenterToScreen()
        dtgseguimientogrupos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
    End Sub
    Private Sub btn_consultar_Click(sender As Object, e As EventArgs) Handles btn_consultar.Click

        imgProcesar.Visible = True
        Application.DoEvents()
        mes = cboMes.SelectedIndex + 1
        ano = cboAño.Text
        If validar_Campos() = True Then

            listarGrupos()
        End If
        imgProcesar.Visible = False

    End Sub
    Private Sub llenarCbo()
        'llenar combos de años y meses
        cboAño.Items.Add(Now.Year)
        cboAño.Items.Add(Now.Year - 1)
        cboAño.Items.Add(Now.Year - 2)
        cboAño.Items.Add(Now.Year - 3)
        cboAño.Items.Add(Now.Year - 4)
        cboAño.SelectedIndex = 0
        cboMes.SelectedIndex = Now.Month - 1

        Dim sql As String = "SELECT vendedor,nombre_vendedor" &
                            " From v_vendedores" &
                                " Where bloqueo = 0 And vendedor >= 1001 And vendedor <= 1099 Order By vendedor"
        Dim dt2 As New DataTable
        Dim row As DataRow
        dt2 = New DataTable
        dt2 = objIngProdLn.listar_datatable(sql, "CORSAN")
        row = dt2.NewRow
        row("vendedor") = 0
        row("nombre_vendedor") = "Seleccione"
        dt2.Rows.Add(row)
        cbo_vendedor.DataSource = dt2
        cbo_vendedor.ValueMember = "vendedor"
        cbo_vendedor.DisplayMember = "nombre_vendedor"
        cbo_vendedor.Text = "vendedor"
        cbo_vendedor.SelectedValue = 0

    End Sub

    Private Sub listarGrupos()
        Dim listConsult As New List(Of Object)
        Dim sql As String
        Dim dt As New DataTable
        Dim mat(,) As Object
        Dim id_cors As String = ""
        Dim i As Integer = 0
        Dim vendedor As Integer

        If validar_Campos() Then
            If usuario_vendedor <> 0 And usuario_vendedor <> 1020 Then
                vendedor = usuario_vendedor
            Else
                vendedor = cbo_vendedor.SelectedValue
            End If

            sql = "select Id_cor,vendedor,linea,sum(kilos) as kilos_vendidos,sum(vr_total) as valor_total from Bi_ventas where vendedor=" & vendedor & " and año=" & cboAño.SelectedItem & " and mes=" & cboMes.SelectedIndex + 1 & " group by vendedor,linea,Id_cor"

            dt = objOpSimplesLn.listar_datatable(sql, "CORSAN")
            dtgseguimientogrupos.DataSource = dt

            If dt.Rows.Count <> 0 Then


                sql = "select distinct Id_cor from Bi_ventas where vendedor=" & vendedor & " and año=" & cboAño.SelectedItem & " and mes=" & cboMes.SelectedIndex + 1 & " "
                listConsult = objOpSimplesLn.lista(sql)
                tam = listConsult.Count - 1
                While i <= tam
                    If tam <> i Then
                        id_cors += listConsult(i).ToString
                        id_cors += ","
                    Else
                        id_cors += listConsult(i).ToString
                    End If
                    i += 1
                End While

                sql = "select Id_cor,Ppto_kilos from Bi_PptoV  where vendedor=" & vendedor & " and año=" & cboAño.SelectedItem & " and mes=" & cboMes.SelectedIndex + 1 & " and Id_cor in (" & id_cors & ") ORDER BY GRUPO"
                listConsult = objOpSimplesLn.lista(sql)
                tam = listConsult.Count - 1
                mat = objOpSimplesLn.matriz(sql, tam, 1)
                agregarMatriz(mat, "Ppto_kilos", "Id_cor")

                sql = "select Id_cor,Vr_kilo from Bi_PptoV  where vendedor=" & vendedor & " and año=" & cboAño.SelectedItem & " and mes=" & cboMes.SelectedIndex + 1 & " and Id_cor in (" & id_cors & ") ORDER BY GRUPO"
                listConsult = objOpSimplesLn.lista(sql)
                tam = listConsult.Count - 1
                mat = objOpSimplesLn.matriz(sql, tam, 1)
                agregarMatriz(mat, "Vr_kilo", "Id_cor")

                calcuPorcen()

                With dtgseguimientogrupos
                    .Columns("vendedor").DisplayIndex = 0
                    .Columns("linea").DisplayIndex = 1
                    .Columns("Ppto_kilos").DisplayIndex = 2
                    .Columns("Vr_kilo").DisplayIndex = 3
                    .Columns("kilos_vendidos").DisplayIndex = 4
                    .Columns("valor_total").DisplayIndex = 5
                    .Columns("Ppto_kilos").Visible = True
                    .Columns("Vr_kilo").Visible = True
                    .Columns("Porcen_Cumplido").Visible = True
                    .Columns("Id_cor").Visible = False
                    .Columns("kilos_vendidos").DefaultCellStyle.Format = "0"
                    .Columns("Vr_kilo").DefaultCellStyle.Format = "0"
                    .Columns("valor_total").DefaultCellStyle.Format = "###,###"
                End With
                rellenarCeros()
            Else
                MessageBox.Show("El vendedor no tiene ventas registradas este mes,se mostrara solo el presupuesto y el valor en kilos", "No tiene ventas", MessageBoxButtons.OK, MessageBoxIcon.Information)
                sql = "select linea,Ppto_kilos,Vr_kilo from Bi_PptoV  where vendedor=" & vendedor & " and año=" & cboAño.SelectedItem & " and mes=" & cboMes.SelectedIndex + 1 & " ORDER BY linea"
                dt = objOpSimplesLn.listar_datatable(sql, "CORSAN")
                dtgseguimientogrupos.DataSource = dt
            End If
        End If
    End Sub
    Private Function validar_Campos() As Boolean
        Dim res As Boolean = False
        If usuario_vendedor = 0 Or usuario_vendedor = 1020 Then
            If cbo_vendedor.Text <> "Seleccione" Then
                res = True
            Else
                MessageBox.Show("Seleccionar vendedor en combo box", "Seleccionar vendedor", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        ElseIf usuario_vendedor <> 0 Then
            res = True
        End If
        Return res
    End Function
    Private Sub agregarMatriz(ByVal mat(,) As Object, ByVal columna As String, ByVal columna_vual As String)
        Dim tamaño, tamaño_mat As Integer
        tamaño_mat = UBound(mat)
        tamaño = dtgseguimientogrupos.RowCount()
        For i = 0 To dtgseguimientogrupos.RowCount - 2
            For j = 0 To tamaño_mat
                If dtgseguimientogrupos.Item(columna_vual, i).Value = mat(j, 0) Then
                    dtgseguimientogrupos.Item(columna, i).Value = mat(j, 1)
                End If
            Next
        Next
    End Sub

    'RELLENA CON CERO LOS CAMPOS VACIOS
    Private Sub rellenarCeros()
        For Each row As DataGridViewRow In dtgseguimientogrupos.Rows

            If row.Cells.Item("Ppto_kilos").Value = 0 Then
                row.Cells.Item("Ppto_kilos").Value = 0
            End If
            If row.Cells.Item("Vr_kilo").Value = 0 Then
                row.Cells.Item("Vr_kilo").Value = 0
            End If

            If row.Index = (dtgseguimientogrupos.Rows.Count - 1) Then
                Exit For
            End If
        Next
    End Sub
    'Calcula pcentaje cumplido
    Private Sub calcuPorcen()
        For Each row As DataGridViewRow In dtgseguimientogrupos.Rows
            Dim ppto_kilos As Double = row.Cells.Item("Ppto_kilos").Value
            Dim kilos As Double = row.Cells.Item("kilos_vendidos").Value
            Dim convert As String
            Dim porcentaje As Double
            porcentaje = ((kilos * 100) / ppto_kilos)
            row.DataGridView.Rows(row.Index).DefaultCellStyle.BackColor = Color.Tomato
            If (porcentaje >= 90 And porcentaje <= 300) Then
                row.DataGridView.Rows(row.Index).DefaultCellStyle.BackColor = Color.SpringGreen
            End If
            If (porcentaje < 90 And porcentaje >= 50) Then
                row.DataGridView.Rows(row.Index).DefaultCellStyle.BackColor = Color.PaleGreen
            End If
            If (porcentaje < 50 And porcentaje >= 0) Then
                row.DataGridView.Rows(row.Index).DefaultCellStyle.BackColor = Color.Salmon
            End If

            convert = porcentaje.ToString("0")
            row.Cells.Item("Porcen_Cumplido").Value = convert & " %"
            If row.Index = (dtgseguimientogrupos.Rows.Count - 1) Then
                Exit For
            End If
        Next
    End Sub
End Class