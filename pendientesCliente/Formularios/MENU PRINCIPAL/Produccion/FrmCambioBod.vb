Imports logicaNegocios

Public Class FrmCambioBod
    Private objOpSimplesLn As New Op_simpesLn
    Private cargaComp As Boolean = False
    Private nom_modulo As String
    Public Sub Main(ByVal nom_modulo As String, ByVal permiso As String)
        Me.nom_modulo = nom_modulo
        If (permiso <> "ADMIN") Then
            btnContCambios.Visible = False
        End If
    End Sub
    Private Sub btnContCambios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnContCambios.Click
        FrmAuditCambios.Show()
        FrmAuditCambios.Main(nom_modulo)
        FrmAuditCambios.WindowState = 2
    End Sub
    Private Sub FrmCambioBod_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim sqlVend As String = "SELECT vendedor,nombre_vendedor  FROM v_vendedores WHERE vendedor >= 1001 AND vendedor <= 1099 AND bloqueo =0 "
        Dim sqlCiudad As String = "SELECT  ciudad  ,descripcion " & _
                                "FROM y_ciudades  " & _
                                     "ORDER BY descripcion "
        cbo_ciudad.DataSource = cargarCbo(sqlCiudad, "ciudad", "descripcion")
        cbo_ciudad.ValueMember = "ciudad"
        cbo_ciudad.DisplayMember = "descripcion"
        cbo_ciudad.Text = "TODOS"
        cbo_vend.DataSource = cargarCbo(sqlVend, "vendedor", "nombre_vendedor")
        cbo_vend.ValueMember = "vendedor"
        cbo_vend.DisplayMember = "nombre_vendedor"
        cbo_vend.Text = "TODOS"
        cargaComp = True
    End Sub
    
    Private Sub cargarConsulta()
        Dim selectSql As String = "SELECT doc.bodega,pend.vendedor,pend.numero,ter.ciudad,pend.fecha,pend.nit,pend.nombres,SUM (pend.valor_unitario )As vr_unit,SUM (pend.Cant_pedida )As cant_ped , SUM (pend.kilos )As kilos , SUM (pend.Vr_total )As vr_total "
        Dim fromSql As String = "FROM J_v_pend_vend pend , documentos_ped doc,terceros ter "
        Dim whereSql As String = "WHERE doc.numero = pend.numero AND ter.nit = doc.nit "
        Dim groupSql As String = "GROUP BY doc.bodega,pend.numero,pend.fecha,pend.fecha,pend.nit,pend.nombres,pend.vendedor,ter.ciudad "
        Dim sql As String = ""
        If (cbo_ciudad.Text <> "TODOS") Then
            whereSql += " AND ter.ciudad like'%" & cbo_ciudad.Text & "%' "
        End If
        If (cbo_vend.Text <> "TODOS") Then
            whereSql += " AND pend.vendedor = " & cbo_vend.SelectedValue & " "
        End If
        If (txtNit.Text <> "") Then
            whereSql += " AND pend.nit like '%" & txtNit.Text & "%'"
        ElseIf (txtNombres.Text <> "") Then
            whereSql += " AND pend.nombres like '%" & txtNombres.Text & "%'"
        ElseIf (txtNumero.Text <> "") Then
            whereSql += " AND pend.numero like '%" & txtNumero.Text & "%'"
        End If
        sql = selectSql & fromSql & whereSql & groupSql
        dtg_consulta.DataSource = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        dtg_consulta.Columns("fecha").DefaultCellStyle.Format = "d"
        dtg_consulta.Columns("bodega").HeaderCell.Style.BackColor = Color.GreenYellow
        dtg_consulta.Columns("bodega").HeaderCell.Style.ForeColor = Color.Black
        bloquearCeldas()
    End Sub

    Private Sub dtg_consulta_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtg_consulta.CellContentClick
        Dim col As String = dtg_consulta.Columns(e.ColumnIndex).Name
        Dim fila As Integer = e.RowIndex
        Dim numero As Double = 0
        Dim bod As Integer = 0
        If (col = "colGuardar") Then
            bod = dtg_consulta.Item("bodega", fila).Value
            numero = dtg_consulta.Item("numero", fila).Value
            If (bod = 3 Or bod = 7) Then
                If (cambiarBodega(bod, numero)) Then
                    MessageBox.Show("La bodega fue actualizada en forma exitosa!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Error al actualizar la bodega, comuniquese con el administrador del sistema!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                MessageBox.Show("La bodega debe estar entre (3-7)", "Verifique!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

        End If
    End Sub
    Private Function cambiarBodega(ByVal bod As Integer, ByVal numero As Double) As Boolean
        Dim list As New List(Of Object)
        list.Add("UPDATE documentos_lin_ped SET bodega = " & bod & " WHERE numero = " & numero & "")
        list.Add("UPDATE documentos_ped SET bodega = " & bod & " WHERE numero = " & numero & "")
        Return (objOpSimplesLn.ExecuteSqlTransaction(list))
    End Function

    Private Sub txtNumero_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNumero.TextChanged
        If (txtNumero.Text.Length > 3) Then
            cargarConsulta()
        End If
        txtNit.Text = ""
        txtNombres.Text = ""
    End Sub

    Private Sub txtNit_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNit.TextChanged
        If (txtNit.Text.Length > 2) Then
            cargarConsulta()
        End If
        txtNombres.Text = ""
        txtNumero.Text = ""
    End Sub

    Private Sub txtNombres_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNombres.TextChanged
        If (txtNombres.Text.Length > 2) Then
            cargarConsulta()
        End If
        txtNumero.Text = ""
        txtNit.Text = ""
    End Sub


    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        FrmLogin.Show()
        FrmPrincipal.Close()
        FrmLogin.Activate()
        Me.Close()
    End Sub

    Private Sub btnPpal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPpal.Click
        FrmPrincipal.Show()
        FrmPrincipal.Activate()
        Me.Close()
    End Sub

    Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
        cargarConsulta()
    End Sub
    Private Sub bloquearCeldas()
        For i = 2 To dtg_consulta.ColumnCount - 1
            dtg_consulta.Columns(i).ReadOnly = True
        Next
    End Sub
    Private Function cargarCbo(ByVal sql As String, ByVal campoId As String, ByVal campoDesc As String) As DataTable
        Dim row As DataRow
        Dim dt As New DataTable
        dt = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        row = dt.NewRow
        row(campoId) = 0
        row(campoDesc) = "TODOS"
        dt.Rows.Add(row)
        Return (dt)
    End Function

    Private Sub cbo_vend_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_vend.SelectedIndexChanged
        If (cargaComp) Then
            cargaComp = False
            Dim sqlCiudad As String = "SELECT  ciud.ciudad,ciud.descripcion " & _
                              "FROM y_ciudades ciud,terceros ter  " & _
                                   "WHERE ter.ciudad = ciud.descripcion AND ter.vendedor =" & cbo_vend.SelectedValue & _
                                   " GROUP BY ciud.ciudad,ciud.descripcion" & _
                                      " ORDER BY ciud.descripcion "
            cbo_ciudad.DataSource = cargarCbo(sqlCiudad, "ciudad", "descripcion")
            cbo_ciudad.ValueMember = "ciudad"
            cbo_ciudad.DisplayMember = "descripcion"
            cbo_ciudad.Text = "TODOS"
            cargarConsulta()
            cargaComp = True
        End If
    End Sub

    Private Sub cbo_ciudad_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_ciudad.SelectedIndexChanged
        If (cargaComp) Then
            cargarConsulta()
        End If
    End Sub
End Class
