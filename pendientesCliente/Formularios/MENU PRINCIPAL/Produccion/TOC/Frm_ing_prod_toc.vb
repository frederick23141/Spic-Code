Imports System.Configuration
Imports logicaNegocios
Imports System.IO
Imports Microsoft.Office.Interop
#Disable Warning BC40056 ' El espacio de nombres o el tipo especificado en el 'System.Data.SqlServerCe' Imports no contienen ningún miembro público o no se encuentran. Asegúrese de que el espacio de nombres o el tipo se hayan definido y de que contengan al menos un miembro público. Asegúrese de que el nombre del elemento importado no use ningún alias.
Imports System.Data.SqlServerCe
#Enable Warning BC40056 ' El espacio de nombres o el tipo especificado en el 'System.Data.SqlServerCe' Imports no contienen ningún miembro público o no se encuentran. Asegúrese de que el espacio de nombres o el tipo se hayan definido y de que contengan al menos un miembro público. Asegúrese de que el nombre del elemento importado no use ningún alias.
Public Class Frm_ing_prod_toc
    Private obj_Ing_prodLn As New Ing_prodLn
    Private obj_tocLn As New TocLn
    Dim carga_comp As Boolean = False
    Private Sub Frm_toc_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        cargar_cbo_dtg()

        carga_comp = True
    End Sub
    Private Sub cargar_cbo_dtg()
        Dim sql As String = ""
        Dim col As New DataColumn
        Dim dt As DataTable
        Dim row As DataRow
        sql = "select  codigo,descripcion   from j_tipo_rest "
        dt = obj_Ing_prodLn.listar_datatable(sql, "PRODUCCION")
        row = dt.NewRow
        row("codigo") = 0
        row("descripcion") = ""
        dt.Rows.Add(row)
        cbo_tipo_rest.DataSource = dt
        cbo_tipo_rest.ValueMember = "codigo"
        cbo_tipo_rest.DisplayMember = "descripcion"
    End Sub
    Private Sub dtg_datos_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtg_datos.CellValueChanged
        Dim col As String = dtg_datos.Columns(e.ColumnIndex).Name
        If (col = "txt_cod") Then
            Dim codigo As String = dtg_datos.Item(col, e.RowIndex).Value
            Dim descripcion As String = obj_Ing_prodLn.consultar_valor("SELECT descripcion FROM CORSAN.dbo.referencias WHERE codigo = '" & codigo & "'", "PRODUCCION")
            If (descripcion = "") Then
                MessageBox.Show("El codigo " & codigo & " no existe!", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                dtg_datos.Item("txt_desc", e.RowIndex).Value = descripcion
            End If

        End If
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If (guardar()) Then
            MessageBox.Show("Producto(s) ingresados con exito!", "Ingreso en forma correcta", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("asegurese que la todos los datos esten correctamente dirigenciados", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Public Function verificar_dtg(ByVal dtg As DataGridView) As Boolean
        Dim resp As Boolean = False
        For i = 0 To dtg_datos.RowCount - 1
            If (dtg_datos.Item("txt_cod", i).Value <> 0) Then
                resp = False
            End If
        Next
        Return resp
    End Function
    Public Function guardar() As Boolean

        Dim resp As Boolean = False
        Dim mat(1, dtg_datos.RowCount - 2)
        Dim sql_insert As String = "INSERT INTO J_toc (codigo, tipo, ud_a_kg, cod_mat_prima, fp) VAlUES ( "
        Dim sql As String = ""
        Dim filas As Integer = 0
        For i = 0 To dtg_datos.RowCount - 1
            If (dtg_datos.Item("txt_cod", i).Value <> "" And dtg_datos.Item("cbo_tipo_rest", i).Value <> "") Then
                sql = sql_insert
                sql += "'" & dtg_datos.Item("txt_cod", i).Value & "',"
                sql += "'" & dtg_datos.Item("cbo_tipo_rest", i).Value & "',"
                If (dtg_datos.Item("txt_udAkg", i).Value = "") Then
                    sql += 0 & ","
                Else
                    sql += dtg_datos.Item("txt_udAkg", i).Value & ","
                End If
                sql += "'" & dtg_datos.Item("txt_Ref_AlaB_E", i).Value & "',"
                If (dtg_datos.Item("txt_fp", i).Value = "") Then
                    sql += 0 & ")"
                Else
                    sql += dtg_datos.Item("txt_fp", i).Value & ")"
                End If
                filas += 1
                mat(1, i) = sql
            End If
        Next
        obj_tocLn.ExecuteSqlTransaction(mat, filas)
        Return (resp)
    End Function
End Class