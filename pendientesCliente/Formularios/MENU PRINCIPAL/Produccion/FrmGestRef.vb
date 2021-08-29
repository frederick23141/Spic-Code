Imports logicaNegocios
Public Class FrmGestRef
    Private objOpsimpesLn As New Op_simpesLn
    Private obj_Ing_prodLn As New Ing_prodLn
    Private Sub FrmGestRef_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cboFecIni.Value = Now.AddYears(-1)
        cboFecFin.Value = Now
        cargarGrid()
        cargarCboDtg()
    End Sub
    Private Sub cargarGrid()
        imgProc.Visible = True
        Application.DoEvents()
        Dim list As New List(Of Object)
        Dim sql As String = ""
        Dim dt As New DataTable
        Dim listPpal As New List(Of Object)
        Dim dr As DataRow
        Dim fecIni As String = objOpsimpesLn.cambiarFormatoFecha(cboFecIni.Value)
        Dim fecFin As String = objOpsimpesLn.cambiarFormatoFecha(cboFecFin.Value)
        sql = "SELECT codigo,descripcion , SUM (pend.Valor_total )As valorTotal,SUM (KilosPendiente )As kilos  FROM V_pendientes_por_vendedor pend WHERE( pend.Id_cor is null OR pend.Id_cor = 99 ) AND pend.fecha>= '" & fecIni & "' AND pend.fecha<='" & fecFin & "' GROUP BY codigo,descripcion  "
        dt = objOpsimpesLn.listar_datatable(sql, "CORSAN")
        listPpal = objOpsimpesLn.listaOfListas("SELECT codigo,descripcion,SUM(Vtas.Vr_total)As valorTotal,SUM (vtas.KILOS )As kilos  FROM V_vtas_vendedor_cliente_referencia vtas  WHERE (vtas.Id_cor is null OR vtas.Id_cor = 99 ) AND fec>= '" & fecIni & "' AND fec<='" & fecFin & "'  GROUP BY codigo,descripcion ", "CORSAN", 3)
        For i = 0 To listPpal.Count - 1
            list = listPpal(i)
            If list.Count > 0 Then
                dr = dt.NewRow
                dr("codigo") = list(0)
                dr("descripcion") = list(1)
                dr("valorTotal") = list(2)
                dr("kilos") = list(3)
                dt.Rows.Add(dr)
            End If
        Next
        dtgInformacion.DataSource = dt
        imgProc.Visible = False
    End Sub
    Private Sub cargarCboDtg()
        Dim sql As String = ""
        Dim col As New DataColumn
        Dim dt As DataTable
        sql = "SELECT Id_cor,Descripcion  FROM JJV_Grupos_seguimiento "
        dt = obj_Ing_prodLn.listar_datatable(sql, "CORSAN")
        cboLinea.DataSource = dt
        cboLinea.ValueMember = "Id_cor"
        cboLinea.DisplayMember = "Descripcion"
    End Sub

    Private Sub dtgInformacion_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgInformacion.CellContentClick
        Dim fila As Integer = e.RowIndex
        Dim col As String = dtgInformacion.Columns(e.ColumnIndex).Name
        Dim codigo As String = ""
        Dim linea As Integer = 0
        Dim sql As String = ""
        If (fila >= 0) Then
            If (col = "btnEditar") Then
                If Not (dtgInformacion.Item("cboLinea", fila).Value = Nothing) Then
                    codigo = dtgInformacion.Item("codigo", fila).Value
                    linea = dtgInformacion.Item("cboLinea", fila).Value
                    Dim resp As Integer = MessageBox.Show("Esta seguro que desea al codigo " & codigo & " a la linea de producción ?", "Modificar", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    If (resp = 6) Then
                        sql = "UPDATE referencias SET Id_cor  = " & linea & " WHERE codigo = '" & codigo & "'"
                        resp = objOpsimpesLn.ejecutar(sql, "CORSAN")
                        If (resp > 0) Then
                            dtgInformacion.Rows.RemoveAt(e.RowIndex)
                            MessageBox.Show("El código de modifico en forma exitosa ", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Else
                            MessageBox.Show("Error al moficar el código, comuniquese con el administrador del sistema! ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    End If
                Else
                    MessageBox.Show("Seleccione una linea de producción! ", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End If
        End If
    End Sub

    Private Sub btnActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActualizar.Click
        cargarGrid()
    End Sub


    Private Sub cboFecIni_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFecIni.ValueChanged
        cargarGrid()
    End Sub

    Private Sub cboFecFin_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFecFin.ValueChanged
        cargarGrid()
    End Sub
End Class