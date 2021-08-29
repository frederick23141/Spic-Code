Imports logicaNegocios
Imports entidadNegocios
Public Class Frm_consultar_proc
    Private objOpSimplesLn As New Op_simpesLn
    Private objIngresoProdLn As New Ing_prodLn
    Private objOperacionesForm As OperacionesFormularios = New OperacionesFormularios
    Dim nomb_modulo As String
    Dim permiso As String
    Dim usuario As New UsuarioEn
    Private carga_comp As Boolean = False
    Private cargo As String
    Public Sub Main(ByVal usuario As UsuarioEn, ByVal nomb_modulo As String)
        permiso = usuario.permiso.Trim
        Me.nomb_modulo = nomb_modulo
        Me.usuario = usuario
        Me.cargo = usuario.cargo
        carga_comp = True
        cargarConsulta()
        If (permiso.Trim <> "ADMIN" And permiso <> "SALUD_OCUPACIONAL") Then
            dtgConsulta.Columns(colBorrar.Name).Visible = False
        End If
    End Sub


    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        FrmPrincipal.Show()
        Me.Close()
        FrmPrincipal.Activate()
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        FrmLogin.Show()
        FrmPrincipal.Close()
        Me.Close()
    End Sub

    Private Sub txtnombret_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtnombre.TextChanged
        If (txtnombre.Text <> "") Then
            If (txtnombre.Text.Length >= 3) Then
                cargarConsulta()
            End If
        End If
    End Sub
    Private Sub cargarConsulta()
        Dim sql As String = ""
        Dim nomb As String = txtnombre.Text
        Dim selectSql As String = "  SELECT DISTINCT C.id_proc, C.nombre, C.codigo, C.vers, C.fecha_creacion, C.fecha_modificacion, C.quien_modif, C.notas_modif " & _
                                  "FROM C_procedimientos C, C_resp_paso_procedimiento R "
        Dim whereSql As String = "WHERE C.nombre like '%" & nomb & "%' AND C.id_proc = R.id_proc "
        If (permiso.Trim <> "ADMIN" And permiso <> "SALUD_OCUPACIONAL" And cargo <> "" And permiso <> "VENDEDOR_ESP" And permiso <> "DIR_PRODUCCION") Then
            whereSql &= "AND R.responsable = " & cargo
        End If

        sql = selectSql & whereSql
        dtgConsulta.DataSource = objIngresoProdLn.listar_datatable(sql, "PRODUCCION")
    End Sub
    Private Sub btn_consultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_consultar.Click
        cargarConsulta()
    End Sub

    Private Sub dtgConsulta_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgConsulta.CellContentClick
        Dim col As String = dtgConsulta.Columns(e.ColumnIndex).Name
        Dim id_proc As Integer = 0
        id_proc = dtgConsulta.Item("id_proc", e.RowIndex).Value
        If (col = col_ver.Name) Then
            Dim frm As New Frm_gestionar_procedimientos
            frm.Show()
            frm.Main(usuario, id_proc, nomb_modulo)
            frm.cargar_por_consulta(id_proc)
        ElseIf (col = colBorrar.Name) Then
            Dim resp As Integer = MessageBox.Show("Esta seguro que desea eliminar este prodecimiento? ", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If (resp = 6) Then
                Dim listSql As New List(Of Object)
                Dim sql As String
                sql = "DELETE FROM C_procedimientos WHERE id_proc =" & id_proc
                listSql.Add(sql)
                sql = "DELETE  C_procedimientos_lin WHERE id_proc= " & id_proc
                listSql.Add(sql)
                If (objIngresoProdLn.ExecuteSqlTransaction(listSql, "PRODUCCION")) Then
                    cargarConsulta()
                    MessageBox.Show("El registro se elimino en forma correcta! ", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Error al elimino el registro, verifique que la celda no este en blanco! ", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

            End If
        ElseIf (col = colPdf.Name) Then
            cargarReporte(id_proc, e.RowIndex)
        End If
    End Sub
 
    Private Sub cargarReporte(ByVal id As Double, ByVal fila As Integer)
        Dim listProcEnc As New List(Of Procedimiento_encEn)
        Dim listProcDet As New List(Of Procedimiento_detEn)
        listProcEnc = llenarListProcEnc(id)
        listProcDet = llenarListProcDet(id)
        Dim frm As New FrmReporteProc()
        frm.Main("Procedimiento", listProcEnc, listProcDet)
        frm.Show()
    End Sub
    Private Function llenarListProcEnc(ByVal id_enc As String) As List(Of Procedimiento_encEn)
        Dim sql As String = "SELECT id_proc,nombre,codigo,vers,fecha_creacion,fecha_modificacion,(SELECT descripcion FROM C_cargos_corsan  WHERE id = elabora ) As elabora,(SELECT descripcion FROM C_cargos_corsan  WHERE id = revisa ) As revisa,(SELECT descripcion FROM C_cargos_corsan  WHERE id = aprueba ) As aprueba,objetivo " & _
                                "FROM C_procedimientos " & _
                                    "WHERE id_proc =" & id_enc
        Dim dt As New DataTable
        Dim objProcEnc As New Procedimiento_encEn
        Dim list As New List(Of Procedimiento_encEn)
        dt = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")
        For i = 0 To dt.Rows.Count - 1
            objProcEnc.aprueba = dt.Rows(i).Item("aprueba")
            objProcEnc.codigo = dt.Rows(i).Item("codigo")
            objProcEnc.elabora = dt.Rows(i).Item("elabora")
            objProcEnc.fecha = dt.Rows(i).Item("fecha_creacion")
            objProcEnc.fecha_modificacion = dt.Rows(i).Item("fecha_modificacion")
            objProcEnc.nombre = dt.Rows(i).Item("nombre")
            objProcEnc.objetivo = dt.Rows(i).Item("objetivo")
            objProcEnc.revisa = dt.Rows(i).Item("revisa")
            objProcEnc.version = "Versión " & dt.Rows(i).Item("vers")
        Next
        list.Add(objProcEnc)

        Return list
    End Function
    Private Function llenarListProcDet(ByVal id_enc As String) As List(Of Procedimiento_detEn)
        Dim sqlProcLin As String = "SELECT id_proc,id_subproc ,descripcion  FROM C_procedimientos_lin  WHERE id_proc =" & id_enc
        Dim sqlRespPaso As String = " "
        Dim dt As New DataTable
        Dim dtRespPaso As New DataTable
        Dim objProcDet As New Procedimiento_detEn
        Dim list As New List(Of Procedimiento_detEn)
        dt = objOpSimplesLn.listar_datatable(sqlProcLin, "PRODUCCION")
        For i = 0 To dt.Rows.Count - 1
            objProcDet.descripcion = dt.Rows(i).Item("descripcion")
            objProcDet.id_subproc = dt.Rows(i).Item("id_subproc")
            sqlRespPaso = "SELECT P.id_proc,P.id_subproc,P.responsable,C.descripcion  FROM C_resp_paso_procedimiento P,C_cargos_corsan C WHERE C.id = P.responsable AND P.id_proc = " & id_enc & " AND id_subproc = " & dt.Rows(i).Item("id_subproc")
            dtRespPaso = objOpSimplesLn.listar_datatable(sqlRespPaso, "PRODUCCION")
            For j = 0 To dtRespPaso.Rows.Count - 1
                objProcDet.responsable &= dtRespPaso.Rows(j).Item("descripcion").ToString.Trim
                If (j <> dtRespPaso.Rows.Count - 1) Then
                    objProcDet.responsable &= " -"
                End If
            Next
            list.Add(objProcDet)
            objProcDet = New Procedimiento_detEn
        Next


        Return list
    End Function
End Class