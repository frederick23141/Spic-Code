Imports logicaNegocios
Public Class Frm_graficar_evaluaciones
    Private objOpSimplesLn As New Op_simpesLn
    Dim objIngresoProdLn As New Ing_prodLn
    Private objOperacionesForm As OperacionesFormularios = New OperacionesFormularios
    Private carga_comp As Boolean = False
    Private Sub Frm_graficar_evaluaciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cboFechaIni.Value = Now.AddMonths(-3)
        cboFechaFin.Value = Now
        cargar_cbo()

        carga_comp = True
    End Sub
    Private Sub graficar()
        If (carga_comp) Then
            If (cboProveedor.Text <> "Seleccione") Then
                graficarProveedores()
            ElseIf (cboCategoria.Text <> "Seleccione") Then
                graficarCategorias()
            End If
        End If
    End Sub

    Private Sub graficarProveedores()
        Dim sql As String = ""
        Dim fecIni As String = objOpSimplesLn.cambiarFormatoFecha(cboFechaIni.Value)
        Dim fecFin As String = objOpSimplesLn.cambiarFormatoFecha(cboFechaFin.Value)
        Dim whereSql As String = "WHERE PC.categoria = CP.id AND PC.nit = T.nit AND T.nit = E.proveedor AND E.fecha >='" & fecIni & "' AND E.fecha <='" & fecFin & "' "
        Dim groupSql As String = ""
        Dim nombX As String = ""
        Dim nombY As String = ""
        If (cboProveedor.Text <> "TODO") Then
            sql = "SELECT E.fecha,AVG(E.puntos) As prom_calificacion " & _
                 "FROM C_proveedor_categoria PC, C_eval_proveedor E ,CORSAN.dbo.terceros T,C_categorias_proveedores CP  "
            whereSql &= "AND E.proveedor =" & cboProveedor.SelectedValue & " "
            groupSql = "GROUP BY E.fecha "
            nombX = "fecha"
            nombY = "Promedio calificación"
            sql &= whereSql & groupSql
            generarGraficoLinea(sql, cboProveedor.Text, cboProveedor.Text)
        Else
            sql = "SELECT T.nombres,AVG(E.puntos)  As prom_calificacion " & _
                 "FROM C_proveedor_categoria PC, C_eval_proveedor E ,CORSAN.dbo.terceros T,C_categorias_proveedores CP "
            groupSql = "GROUP BY T.nombres "
            nombX = "Proveedor"
            nombY = "Promedio calificación"
            sql &= whereSql & groupSql
            generarGraficoBarras(sql, nombX, nombY)
        End If

    End Sub
    Private Sub graficarCategorias()
        Dim sql As String = ""
        Dim fecIni As String = objOpSimplesLn.cambiarFormatoFecha(cboFechaIni.Value)
        Dim fecFin As String = objOpSimplesLn.cambiarFormatoFecha(cboFechaFin.Value)
        Dim whereSql As String = "WHERE PC.categoria = CP.id AND PC.nit = E.proveedor AND  E.fecha >='" & fecIni & "' AND E.fecha <='" & fecFin & "' "
        Dim groupSql As String = ""
        Dim nombX As String = ""
        Dim nombY As String = ""
        If (cboCategoria.Text <> "TODO") Then
            sql = "SELECT E.fecha,AVG(E.puntos)  As prom_calificacion " & _
                 "FROM C_proveedor_categoria PC, C_categorias_proveedores CP,C_eval_proveedor E "
            whereSql &= "AND CP.id =" & cboCategoria.SelectedValue & " "
            groupSql = "GROUP BY E.fecha "
            nombX = "fecha"
            nombY = "Promedio calificación"
            sql &= whereSql & groupSql
            generarGraficoLinea(sql, cboCategoria.Text, cboCategoria.Text)
        Else
            sql = "SELECT CP.descripcion,AVG(E.puntos) As prom_calificacion  " & _
                 "FROM  C_proveedor_categoria PC, C_eval_proveedor E ,C_categorias_proveedores CP  "
            groupSql = "GROUP BY CP.descripcion "
            nombX = "Categoria"
            nombY = "Promedio calificación"
            sql &= whereSql & groupSql
            generarGraficoBarras(sql, nombX, nombY)
        End If

    End Sub
    Private Sub generarGraficoBarras(ByVal sql As String, ByVal nombX As String, ByVal nombY As String)
        Dim listaOflistas As New List(Of Object)
        Dim lista As New List(Of Object)
        listaOflistas = objOpSimplesLn.listaOfListas(sql, "PRODUCCION", 1)
        Chart1.Titles.Clear()
        Chart1.Series.Clear()
        Chart1.ChartAreas.Clear()
        Chart1.ChartAreas.Add(0)
        For j = 0 To listaOflistas.Count - 1
            lista = listaOflistas(j)

            Chart1.Series.Add(lista(0))
            Chart1.Series(lista(0)).Points.AddXY("", lista(1))
            Chart1.Series(lista(0)).IsValueShownAsLabel = True
            Chart1.Series(lista(0))("PointWidth") = "1.5"
            Chart1.Series(lista(0)).ToolTip = lista(0)
        Next
        Chart1.ChartAreas(0).AxisX.Title = nombX
        Chart1.ChartAreas(0).AxisY.Title = nombY
        Chart1.ChartAreas(0).Area3DStyle.Enable3D = False
    End Sub
    Private Sub generarGraficoLinea(ByVal sql As String, ByVal nomb_serie As String, ByVal nombX As String)
        Dim listaOflistas As New List(Of Object)
        Dim lista As New List(Of Object)
        listaOflistas = objOpSimplesLn.listaOfListas(sql, "PRODUCCION", 1)
        Chart1.Titles.Clear()
        Chart1.Series.Clear()
        Chart1.ChartAreas.Clear()
        Chart1.ChartAreas.Add(0)
        Chart1.Series.Add(nomb_serie)
        For j = 0 To listaOflistas.Count - 1
            lista = listaOflistas(j)
            Chart1.Series(nomb_serie).Points.AddXY(lista(0), lista(1))
        Next
        Chart1.Series(nomb_serie).ChartType = DataVisualization.Charting.SeriesChartType.Line
        Chart1.ChartAreas(0).AxisX.Title = nombX
        Chart1.ChartAreas(0).AxisY.Title = "Calificación"
        Chart1.Refresh()
    End Sub
    Private Sub cargar_cbo()
        Dim sql As String
        Dim dt As New DataTable
        Dim dr As DataRow
        sql = "SELECT T.nit,T.nombres   FROM corsan.dbo.terceros T , C_proveedor_categoria C WHERE C.nit = T.nit ORDER BY T.nombres "
        dt = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")
        dr = dt.NewRow
        dr("nit") = 0
        dr("nombres") = "TODO"
        dt.Rows.Add(dr)
        cboProveedor.DataSource = dt
        cboProveedor.ValueMember = "nit"
        cboProveedor.DisplayMember = "nombres"
        cboProveedor.Text = "Seleccione"

        dt = New DataTable
        sql = "SELECT id,descripcion   FROM C_categorias_proveedores "
        dt = objIngresoProdLn.listar_datatable(sql, "PRODUCCION")
        dr = dt.NewRow
        dr("id") = 0
        dr("descripcion") = "TODO"
        dt.Rows.Add(dr)

        cboCategoria.DataSource = dt
        cboCategoria.ValueMember = "id"
        cboCategoria.DisplayMember = "descripcion"
        cboCategoria.Text = "Seleccione"
        carga_comp = True
    End Sub

    Private Sub cboFechaIni_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFechaIni.ValueChanged
        If (carga_comp) Then
            graficar()
        End If
    End Sub

    Private Sub cboProveedor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboProveedor.SelectedIndexChanged
        If (carga_comp) Then
            carga_comp = False
            cboCategoria.Text = "Seleccione"
            carga_comp = True
            graficar()
        End If

    End Sub

    Private Sub cboCategoria_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCategoria.SelectedIndexChanged
        If (carga_comp) Then
            carga_comp = False
            cboProveedor.Text = "Seleccione"
            carga_comp = True
            graficar()
        End If
    End Sub

    Private Sub cboFechaFin_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFechaFin.ValueChanged
        If (carga_comp) Then
            graficar()
        End If
    End Sub

    Private Sub guardarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles guardarToolStripMenuItem.Click
        SaveFileDialog1.ShowDialog()
    End Sub
    Private Sub SaveFileDialog1_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles SaveFileDialog1.FileOk
        Dim ruta As String = SaveFileDialog1.FileName
        Chart1.SaveImage(ruta, System.Drawing.Imaging.ImageFormat.Png)
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

    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click
        If (cboProveedor.Text <> "Seleccione" And cboProveedor.Text <> "TODOS") Then
            If (txtObservaciones.Text <> "") Then
                guardarTendencia()
            Else
                MessageBox.Show("El campo observaciones es obligatorio", "Verifique!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            MessageBox.Show("Solo se permite guardar tendencia por proveedor especifico", "no permitido!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
    Private Sub guardarTendencia()
        Dim insertoCorrecto As Boolean = False
        Dim observaciones As String = txtObservaciones.Text
        Dim fecIni As String = objOpSimplesLn.cambiarFormatoFecha(cboFechaIni.Value)
        Dim fecFin As String = objOpSimplesLn.cambiarFormatoFecha(cboFechaFin.Value)
        Dim nit As String = cboProveedor.SelectedValue
        Dim sql As String = "INSERT INTO C_analisis_tend " & _
                                "(fecha_tend,nit,fecha_ini,fecha_fin,notas) " & _
                        "VALUES (GETDATE ()," & nit & ",'" & fecIni & "','" & fecFin & "','" & observaciones & "')"
        insertoCorrecto = objIngresoProdLn.ejecutar(sql, "PRODUCCION")
        If (insertoCorrecto) Then
            MessageBox.Show("La tendencia fue guardada en forma exitosa! ", "Correcto!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtObservaciones.Text = ""
        Else
            MessageBox.Show("Error al guardar la tendencia comuniquese con el administrador del sistema ", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Public Sub cargarGrafico(ByVal id As Integer)
        carga_comp = False
        Dim sql As String = " SELECT  nit,fecha_ini,fecha_fin,notas " & _
                                     "FROM C_analisis_tend "
        Dim dt As New DataTable
        dt = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")
        For i = 0 To dt.Rows.Count - 1
            cboProveedor.SelectedValue = dt.Rows(i).Item("nit")
            cboCategoria.Text = "Seleccione"
            txtObservaciones.Text = dt.Rows(i).Item("notas")
            cboFechaIni.Value = dt.Rows(i).Item("fecha_ini")
            cboFechaFin.Value = dt.Rows(i).Item("fecha_fin")
        Next
        carga_comp = True
        graficar()
    End Sub
End Class