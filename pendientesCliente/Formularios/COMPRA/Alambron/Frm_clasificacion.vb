Imports logicaNegocios
Imports entidadNegocios
Imports System.Data.SqlClient

'Este fomulario aparece una tabla con una consulta hecha  por medio de un procedimiento
'y te permite buscar un registro por medio de la linea de produccion y del campo codigo,ademas te permite cambiar la linea de produccion del producto
Public Class Frm_clasificacion
    Private dt As New DataTable
    Dim Da As New SqlDataAdapter
    Dim Cmd As New SqlCommand
    Dim codigo As String
    Dim codigoG As String
    Private objOpSimplesLn As New Op_simpesLn
    Private Sub practica1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        mostrar2()
        cargar()
    End Sub
    Private Sub cargar()
        Dim dt As New DataTable
        dt = New DataTable
    End Sub
    'Muestra los productos sin clasificar en el datagridview
    Private Sub mostrar2()
      Dim sql As String = "select r.codigo,g.Descripcion as linea_produccion,r.descripcion from referencias r , JJV_Grupos_seguimiento g where r.id_cor = g.id_cor and ( r.codigo like '3%' or r.codigo like '2%') and r.Id_cor = 99"
        dt = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        datalistado.DataSource = dt
    End Sub

    Private Sub datalistado_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles datalistado.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then

            ' Si se ha pulsado el botón derecho del ratón,
            ' seleccionamos la fila completa del control
            ' DataGridView.
            '
            With datalistado
                Dim hti As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)

                ' Obtenemos la parte del control a las que
                ' pertenecen las coordenadas.
                '
                If hti.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = _
                    .Rows(hti.RowIndex).Cells(hti.ColumnIndex)
                    codigo = Me.datalistado("codigo", Me.datalistado.CurrentRow.Index).Value

                    Me.datalistado.ContextMenuStrip = Me.ContextMenuStrip1

                End If

            End With
        End If

    End Sub
    'abre el formulario para cambiar la linea del producto, y actualiza el numero de productos sin clasificar
    Private Sub CambiarDescripcionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CambiarDescripcionToolStripMenuItem.Click
        Frm_clasificacionb.guardarcodigo(codigo)
        Frm_clasificacionb.ShowDialog()
        Frm_seg_ppto_produccion.labelcontar()
        Frm_entradas_salidas_ref.labelcontar()
        Frm_entradas_salidas_diarias.labelcontar()
        FrmSegVendAct.labelcontar()
        mostrar2()
    End Sub
    Private Sub Txtcodigo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        mostrar2()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        mostrar2()
    End Sub
End Class