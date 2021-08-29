Imports System.Configuration
Imports logicaNegocios
Imports entidadNegocios
Imports System.IO
Imports Microsoft.Office.Interop
Public Class frmCarteraIngVtas
    Private objUsuarioLn As New UsuarioLn
    Public vendedor As Integer
    Private objIngVtaLn As New IngVtasLn
    Public strSql As String = ""
    Private usuario As New UsuarioEn
    Private objOperacionesForm As OperacionesFormularios = New OperacionesFormularios
    Private obj_op_simplesLn As New Op_simpesLn
    Private carga_comp As Boolean = False
    Public Sub Main(ByVal vend As Integer, ByVal usuario As UsuarioEn)
        Me.usuario = usuario
        vendedor = vend
        Dim row As DataRow
        Dim dt As New DataTable
        Dim sql As String = ""
        Dim vendedores As String = objUsuarioLn.coordinadorVend(usuario.usuario)
        Dim db As String = "CORSAN"
        Dim criterioVendedor As String = ""
        Dim sql_condicion As String = "SELECT condicion FROM condiciones_pago "
        dt = obj_op_simplesLn.listar_datatable(sql_condicion, "CORSAN")
        row = dt.NewRow
        row("condicion") = "TODOS"
        dt.Rows.Add(row)
        cboCondicion.DataSource = dt
        cboCondicion.ValueMember = "condicion"
        cboCondicion.DisplayMember = "condicion"
        cboCondicion.SelectedValue = "TODOS"
        If (vend <> 1020) Then
            cbo_vend.Visible = False
            lblVend.Visible = False
            cartera()
        Else
            dt = New DataTable
            If (vendedores <> "") Then
                criterioVendedor = " vendedor in (" & vendedores & ")"
            Else
                criterioVendedor = " vendedor >= 1001 AND vendedor <= 1099"
            End If

            sql = "SELECT CAST(vendedor AS varchar(25))As vendedor  FROM v_vendedores where " & criterioVendedor & "  AND bloqueo =0 "
            dt = obj_op_simplesLn.listar_datatable(sql, db)
            row = dt.NewRow
            row("vendedor") = "TODOS"
            dt.Rows.Add(row)
            cbo_vend.DataSource = dt
            cbo_vend.ValueMember = "vendedor"
            cbo_vend.DisplayMember = "vendedor"
            cbo_vend.SelectedValue = "TODOS"

        End If
        carga_comp = True
    End Sub
    Private Sub frmCarteraIngVtas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CenterToScreen()
    End Sub
    Public Sub cartera()
        imgProc.Visible = True
        Application.DoEvents()
        Dim vendedores As String = objUsuarioLn.coordinadorVend(usuario.usuario)
        Dim whereCond As String = ""
        If (cboCondicion.Text <> "TODOS") Then
            whereCond = " And condicion = " & cboCondicion.SelectedValue & " "
        End If
        If (vendedor = 1020) Then
            Dim criterioVendedor As String = ""
            If (txtNit.Text = "" And txtNombres.Text = "") Then
                If (cbo_vend.Text <> "TODOS") Then
                    criterioVendedor = " AND vendedor in (" & cbo_vend.SelectedValue & ")"
                End If
            End If
            If (criterioVendedor = "") Then
                If (vendedores <> "") Then
                    criterioVendedor = " AND vendedor in (" & vendedores & ")"
                Else
                    criterioVendedor = " AND vendedor >= 1001 AND vendedor <= 1099"
                End If
            End If
            If txtNit.Text <> "" And txtNombres.Text <> "" Then

                strSql = "SELECT Tipo, Numero,vendedor,ciudad,nombres,Nit,condicion, Fecha, Vencimiento, Valor_Total, Valor_Aplicado, Saldo, Dias_Vencido, Sin_Vencer, de_1_a_30, de_31_a_60, de_61_a_90, de_91_a_120, Mas_de_120 ,(SELECT nota FROM j_notas_cartera n WHERE c.numero = n.numero AND c.tipo = n.tipo  )aS nota_cartera " & _
                         "FROM V_cartera_edades_jjv c " & _
                         "WHERE nit LIKE '" & txtNit.Text & "%' AND " & _
                         "      nombres LIKE '%" & txtNombres.Text & "%'  " & _
                         " " & criterioVendedor & " and  saldo <> 0 " & whereCond & _
                         "ORDER BY nombres"
            ElseIf txtNit.Text = "" And txtNombres.Text <> "" Then

                strSql = "SELECT Tipo, Numero,vendedor,ciudad,nombres,Nit,condicion, Fecha, Vencimiento, Valor_Total, Valor_Aplicado, Saldo, Dias_Vencido, Sin_Vencer, de_1_a_30, de_31_a_60, de_61_a_90, de_91_a_120, Mas_de_120 ,(SELECT nota FROM j_notas_cartera n WHERE c.numero = n.numero AND c.tipo = n.tipo  )aS nota_cartera " & _
                         "FROM V_cartera_edades_jjv c " & _
                         "WHERE nombres LIKE '%" & txtNombres.Text & "%'  " & _
                         "  " & criterioVendedor & " and  saldo <> 0 " & whereCond & _
                         "ORDER BY nombres"

            ElseIf txtNit.Text <> "" And txtNombres.Text = "" Then

                strSql = "SELECT Tipo, Numero,vendedor,ciudad,nombres,Nit,condicion, Fecha, Vencimiento, Valor_Total, Valor_Aplicado, Saldo, Dias_Vencido, Sin_Vencer, de_1_a_30, de_31_a_60, de_61_a_90, de_91_a_120, Mas_de_120 ,(SELECT nota FROM j_notas_cartera n WHERE c.numero = n.numero AND c.tipo = n.tipo  )aS nota_cartera " & _
                         "FROM V_cartera_edades_jjv c " & _
                         "WHERE nit LIKE '" & txtNit.Text & "%'  " & _
                         " " & criterioVendedor & " and  saldo <> 0 " & whereCond & _
                         "ORDER BY nombres"
            ElseIf txtNit.Text = "" And txtNombres.Text = "" Then

                strSql = "SELECT Tipo, Numero,vendedor,ciudad,nombres,Nit,condicion, Fecha, Vencimiento, Valor_Total, Valor_Aplicado, Saldo, Dias_Vencido, Sin_Vencer, de_1_a_30, de_31_a_60, de_61_a_90, de_91_a_120, Mas_de_120 ,(SELECT nota FROM j_notas_cartera n WHERE c.numero = n.numero AND c.tipo = n.tipo  )aS nota_cartera " & _
                          "FROM V_cartera_edades_jjv c " & _
                          "WHERE  saldo <> 0  " & whereCond & criterioVendedor & " " & _
                          "ORDER BY nombres"
            End If
        Else
            If txtNit.Text <> "" And txtNombres.Text <> "" Then

                strSql = "SELECT Tipo, Numero,vendedor,ciudad,nombres,Nit,condicion, Fecha, Vencimiento, Valor_Total, Valor_Aplicado, Saldo, Dias_Vencido, Sin_Vencer, de_1_a_30, de_31_a_60, de_61_a_90, de_91_a_120, Mas_de_120 ,(SELECT nota FROM j_notas_cartera n WHERE c.numero = n.numero AND c.tipo = n.tipo  )aS nota_cartera " & _
                         "FROM V_cartera_edades_jjv c " & _
                         "WHERE nit LIKE '" & txtNit.Text & "%' AND " & _
                         "      nombres LIKE '%" & txtNombres.Text & "%' AND saldo <> 0 " & whereCond & "AND " & _
                         "      vendedor = " & vendedor & "" & _
                         "ORDER BY nombres"

            ElseIf txtNit.Text = "" And txtNombres.Text = "" Then

                strSql = "SELECT Tipo, Numero,vendedor,ciudad,nombres,Nit,condicion, Fecha, Vencimiento, Valor_Total, Valor_Aplicado, Saldo, Dias_Vencido, Sin_Vencer, de_1_a_30, de_31_a_60, de_61_a_90, de_91_a_120, Mas_de_120 ,(SELECT nota FROM j_notas_cartera n WHERE c.numero = n.numero AND c.tipo = n.tipo  )aS nota_cartera " & _
                         "FROM V_cartera_edades_jjv c " & _
                         "WHERE vendedor = " & vendedor & " AND  saldo <> 0 " & whereCond & _
                         "ORDER BY nombres"

            ElseIf txtNit.Text = "" And txtNombres.Text <> "" Then
                strSql = "SELECT Tipo, Numero,vendedor,ciudad,nombres,Nit,condicion, Fecha, Vencimiento, Valor_Total, Valor_Aplicado, Saldo, Dias_Vencido, Sin_Vencer, de_1_a_30, de_31_a_60, de_61_a_90, de_91_a_120, Mas_de_120 ,(SELECT nota FROM j_notas_cartera n WHERE c.numero = n.numero AND c.tipo = n.tipo  )aS nota_cartera " & _
                         "FROM V_cartera_edades_jjv c " & _
                         "WHERE nombres LIKE '%" & txtNombres.Text & "%' AND saldo <> 0 " & whereCond & " AND " & _
                         "      vendedor = " & vendedor & " " & _
                         "ORDER BY nombres"

            ElseIf txtNit.Text <> "" And txtNombres.Text = "" Then

                strSql = "SELECT Tipo, Numero,vendedor,ciudad,nombres,Nit,condicion, Fecha, Vencimiento, Valor_Total, Valor_Aplicado, Saldo, Dias_Vencido, Sin_Vencer, de_1_a_30, de_31_a_60, de_61_a_90, de_91_a_120, Mas_de_120 ,(SELECT nota FROM j_notas_cartera n WHERE c.numero = n.numero AND c.tipo = n.tipo  )aS nota_cartera " & _
                         "FROM V_cartera_edades_jjv c " & _
                         "WHERE nit LIKE '" & txtNit.Text & "%' AND saldo <> 0  " & whereCond & " AND" & _
                         "      vendedor = " & vendedor & "" & _
                         "ORDER BY nombres"
            End If
        End If
        If (strSql <> "") Then
            dtg_cartera.DataSource = objIngVtaLn.listarDatos(strSql)
            txt_vr_tot.Text = sumarColumna(dtg_cartera, "Valor_Total").ToString("C0")
            txt_saldo.Text = sumarColumna(dtg_cartera, "Saldo").ToString("C0")
            txt_sin_venc.Text = sumarColumna(dtg_cartera, "Sin_Vencer").ToString("C0")
            txt_1_30.Text = sumarColumna(dtg_cartera, "de_1_a_30").ToString("C0")
            txt_31_60.Text = sumarColumna(dtg_cartera, "de_31_a_60").ToString("C0")
            txt_61_90.Text = sumarColumna(dtg_cartera, "de_61_a_90").ToString("C0")
            txt_91_120.Text = sumarColumna(dtg_cartera, "de_91_a_120").ToString("C0")
            mas_120.Text = sumarColumna(dtg_cartera, "Mas_de_120").ToString("C0")
            dtg_cartera.Columns("Vencimiento").DefaultCellStyle.Format = "d"
            dtg_cartera.Columns("Fecha").DefaultCellStyle.Format = "d"
            For i = 0 To dtg_cartera.Columns.Count - 1
                If (dtg_cartera.Columns(i).Name <> "nota_cartera") Then
                    dtg_cartera.Columns(i).ReadOnly = True
                End If
            Next
            If (usuario.permiso = "VENDEDOR") Then
                dtg_cartera.Columns("nota_cartera").Visible = True
            End If
        End If
        imgProc.Visible = False
    End Sub

    Private Sub txtNit_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNit.TextChanged
        If (carga_comp) Then
            If (txtNit.Text.Length > 3) Then
                txtNombres.Text = ""
                carga_comp = False
                cbo_vend.Text = "Seleccione"
                carga_comp = True
            End If
        End If
    End Sub

    Private Sub txtNombres_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNombres.TextChanged
        If (carga_comp) Then
            If (txtNombres.Text.Length > 3) Then
                txtNit.Text = ""
                carga_comp = False
                cbo_vend.Text = "Seleccione"
                carga_comp = True
            End If
        End If
    End Sub

    Private Sub dtg_cartera_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtg_cartera.CellDoubleClick
        If (e.RowIndex <> -1) Then
            FrmIngVtas.Show()
            FrmIngVtas.txt_nombres.Text = dtg_cartera.Item("nombres", e.RowIndex).Value
            FrmIngVtas.txtNit.Text = dtg_cartera.Item("Nit", e.RowIndex).Value
            FrmIngVtas.txtRef.Focus()
            FrmIngVtas.cargar_info_client(dtg_cartera.Item("Nit", e.RowIndex).Value)
            Me.Close()
        End If

    End Sub
    Public Function sumarColumna(ByVal dtg As DataGridView, ByVal col As String) As Double
        Dim sum As Double = 0
        For i = 0 To dtg.RowCount - 1
            sum = sum + dtg.Item(col, i).Value
        Next
        Return sum
    End Function

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        FrmLogin.Show()
        FrmPrincipal.Close()
        Me.Close()
    End Sub

    Private Sub btn_ppal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ppal.Click
        FrmPrincipal.Show()
        Me.Close()
    End Sub

    Private Sub btn_exportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exportar.Click
        objOperacionesForm.ExportarDatosExcel(dtg_cartera, "Cartera")
    End Sub

    Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
        cartera()
    End Sub

    Private Sub cbo_vend_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_vend.SelectedIndexChanged
        If (carga_comp) Then
            carga_comp = False
            txtNit.Text = ""
            txtNombres.Text = ""
            carga_comp = True
        End If
    End Sub

    Private Sub dtg_cartera_CellValueChanged(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtg_cartera.CellValueChanged
        Dim col As String = dtg_cartera.Columns(e.ColumnIndex).Name
        If (col = "nota_cartera") Then
            If Not IsDBNull(dtg_cartera.Item("nota_cartera", e.RowIndex).Value) Then
                If (dtg_cartera.Item("nota_cartera", e.RowIndex).Value <> "") Then
                    Dim numero As Integer = dtg_cartera.Item("numero", e.RowIndex).Value
                    Dim tipo As String = dtg_cartera.Item("tipo", e.RowIndex).Value
                    Dim nota As String = dtg_cartera.Item("nota_cartera", e.RowIndex).Value
                    Dim listSql As New List(Of Object)
                    Dim insertSql As String = "INSERT INTO j_notas_cartera (numero,tipo,nota) VALUES (" & numero & ",'" & tipo & "','" & nota & "') "
                    Dim deleteSql As String = "DELETE FROM j_notas_cartera WHERE numero =" & numero & " AND tipo = '" & tipo & "'"
                    listSql.Add(deleteSql)
                    listSql.Add(insertSql)
                    If (obj_op_simplesLn.ExecuteSqlTransaction(listSql)) Then
                        MessageBox.Show("La nota se ingreso en forma correcta", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("Error al ingresar la nota, comuniquese con el adminstrador del sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Else
                    MessageBox.Show("Este campo no puede ser ingresado vacio", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                MessageBox.Show("Solo se puede modificar el campo nota_cartera! ", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub
End Class