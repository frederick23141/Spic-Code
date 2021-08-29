Imports System.Configuration
Imports entidadNegocios
Imports logicaNegocios
Public Class frmDespacho
    Private objClienteLn As New ClienteLn
    Public vendedor As Integer
    Private objIngVtaLn As New IngVtasLn
    Private objOpSimplesLn As New Op_simpesLn
    Public strSql As String = ""
    Private cargaComp As Boolean = False
    Private objOperacionesForm As New OperacionesFormularios
    '****************************************************************************************************************
    '**** Se llaman a los metodos descritos dentro de frmPendientes_Load cuando se carga el formulario***************
    '****************************************************************************************************************
    Public Sub Main(ByVal nitC As Double, ByVal vend As Int32)
        date_fec.MaxDate = Now.Date
        date_fec.Value = Now.AddMonths(-1).ToShortDateString
        Dim sFec As String = objOpSimplesLn.cambiarFormatoFecha(Now.AddMonths(-1))
        If (nitC <> 0) Then
            txtNit.Text = nitC
        End If
        Dim min As Integer = vend
        Dim max As Integer = vend
        vendedor = vend
        If (vend = 1020) Then
            min = 1001
            max = 1099
        End If
        cargarGrid(sFec)
        cargaComp = True
    End Sub
    ''****************************************************************************************************************
    'Procedimiento encargado de cargar el grid de los despachos llamando el metido listarDespacho por medio de el ****
    'objeto de la clase clienteLn*************************************************************************************
    '*****************************************************************************************************************
    Private Sub cargarGrid(ByVal fecha As String)
        If (vendedor = 1020) Then

            If txtNit.Text = "" And txtNombres.Text <> "" Then

                strSql = "SELECT ter.nombres ,fac.nit, pedido,   fec, codigo, descripcion, cantidad, Kilos, valor_unitario, Vr_total, fac.notas " & _
                                "FROM Jjv_V_vtas_vend_cliente_ref fac ,terceros ter  " & _
                                   "WHERE  fec >= '" & fecha & "'and ter.nit = fac.nit AND ter.nombres like '%" & txtNombres.Text & "%' "


            ElseIf txtNit.Text <> "" And txtNombres.Text = "" Then

                strSql = "SELECT ter.nombres ,fac.nit, pedido,   fec, codigo, descripcion, cantidad, Kilos, valor_unitario, Vr_total, fac.notas " & _
                               "FROM Jjv_V_vtas_vend_cliente_ref fac ,terceros ter  " & _
                                  "WHERE  fec >= '" & fecha & "'and ter.nit = fac.nit AND fac.nit like '" & txtNit.Text & "%' "

            End If
        Else
            If txtNit.Text = "" And txtNombres.Text = "" Then

                strSql = "SELECT ter.nombres ,fac.nit, pedido,   fec, codigo, descripcion, cantidad, Kilos, valor_unitario, Vr_total, fac.notas " & _
                               "FROM Jjv_V_vtas_vend_cliente_ref fac ,terceros ter  " & _
                                  "WHERE fac.vendedor = " & vendedor & " and fec >= '" & fecha & "'and ter.nit = fac.nit "


            ElseIf txtNit.Text = "" And txtNombres.Text <> "" Then

                strSql = "SELECT ter.nombres ,fac.nit, pedido,   fec, codigo, descripcion, cantidad, Kilos, valor_unitario, Vr_total, fac.notas " & _
                               "FROM Jjv_V_vtas_vend_cliente_ref fac ,terceros ter  " & _
                                  "WHERE fac.vendedor = " & vendedor & " and fec >= '" & fecha & "'and ter.nit = fac.nit AND ter.nombres like '%" & txtNombres.Text & "%' "


            ElseIf txtNit.Text <> "" And txtNombres.Text = "" Then

                strSql = "SELECT ter.nombres ,fac.nit, pedido,   fec, codigo, descripcion, cantidad, Kilos, valor_unitario, Vr_total, fac.notas " & _
                               "FROM Jjv_V_vtas_vend_cliente_ref fac ,terceros ter  " & _
                                  "WHERE fac.vendedor = " & vendedor & " and fec >= '" & fecha & "'and ter.nit = fac.nit AND fac.nit like '" & txtNit.Text & "%' "

            End If
        End If
        If (strSql <> "") Then
            Dim dt As DataTable = objIngVtaLn.listarDatos(strSql)
            Dim tamano_letra As Single = 8.0!
            dt.Rows.Add()
            dtgDespacho.DataSource = dt
            totalizar_dt(dt)
            dtgDespacho.Columns("fec").DefaultCellStyle.Format = "d"
            dtgDespacho.Rows(dtgDespacho.RowCount - 1).DefaultCellStyle = objOperacionesForm.formatoNegrita(tamano_letra)
        End If

    End Sub
    Private Sub totalizar_dt(ByRef dt As DataTable)
        Dim sum As Double = 0
        For j = 0 To dt.Columns.Count - 1
            If dt.Columns(j).ColumnName = "cantidad" Or dt.Columns(j).ColumnName = "Kilos" Or dt.Columns(j).ColumnName = "valor_unitario" Or dt.Columns(j).ColumnName = "Vr_total" Then
                For i = 0 To dt.Rows.Count - 1
                    If Not IsDBNull(dt.Rows(i).Item(j)) Then
                        sum += dt.Rows(i).Item(j)
                    End If
                Next
                dt.Rows(dt.Rows.Count - 1).Item(j) = sum
                sum = 0
            End If
        Next
    End Sub
    Private Sub btn_buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar.Click
        Dim fec As Date = date_fec.Value
        cargarGrid(fec)
    End Sub

    Private Sub txtNit_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNit.TextChanged
        If (cargaComp) Then
            If txtNit.Text.Length > 3 Then
                Dim fec As String = objOpSimplesLn.cambiarFormatoFecha(date_fec.Value)
                cargarGrid(fec)
                txtNombres.Text = ""
            End If
        End If
    End Sub
    Private Sub txtNit_keyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNit.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtNombres_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNombres.TextChanged
        If (cargaComp) Then
            If txtNombres.Text.Length > 3 Then
                Dim fec As String = objOpSimplesLn.cambiarFormatoFecha(date_fec.Value)
                cargarGrid(fec)
                txtNit.Text = ""
            End If

        End If

    End Sub

End Class