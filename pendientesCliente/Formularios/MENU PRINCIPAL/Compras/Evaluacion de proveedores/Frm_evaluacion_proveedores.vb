Imports logicaNegocios
Public Class Frm_evaluacion_proveedores
    Private objOpSimplesLn As New Op_simpesLn
    Dim carga_comp As Boolean = False
    Dim objIngresoProdLn As New Ing_prodLn
    Dim id_evaluacion_existente As Integer = 0
    Private Sub Frm_evaluacion_proveedores_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cboFecha.Value = Now
        cargarGridEvaluacion()
        cargarGridClasificacion()
        pintarDtg()
        formatoNegrita()
        dtgEvaluacion.Rows(dtgEvaluacion.RowCount - 1).ReadOnly = True
        carga_comp = True
    End Sub
    Private Sub cargarGridEvaluacion()
        Dim sql As String = "SELECT F.factor As FACTOR ,F.id_factor,C.id_criterio,C.criterio As CRITERIO,C.valor As PUNTAJE_MÁXIMO " & _
                             "FROM C_factor F,C_criterios C " & _
                                    "WHERE F.id_factor = C.id_factor "
        Dim dt As New DataTable
        dt = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")
        dt.Columns.Add("PUNTAJE")
        dt.Rows.Add()
        dtgEvaluacion.DataSource = dt
        dtgEvaluacion.Item("CRITERIO", dtgEvaluacion.RowCount - 1).Value = "TOTAL"
        dtgEvaluacion.Columns("id_criterio").Visible = False
        dtgEvaluacion.Columns("id_factor").Visible = False
        dtgEvaluacion.Columns("FACTOR").ReadOnly = True
        dtgEvaluacion.Columns("CRITERIO").ReadOnly = True
        cargar_cbo()
    End Sub
    Private Sub cargar_cbo()
        Dim sql As String
        Dim dt As New DataTable
        Dim dr As DataRow
        sql = "SELECT T.nit,T.nombres   FROM corsan.dbo.terceros T , C_proveedor_categoria C WHERE C.nit = T.nit ORDER BY T.nombres "
        dt = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")
        dr = dt.NewRow
        dr("nit") = 0
        dr("nombres") = "Seleccione"
        dt.Rows.Add(dr)
        cboProveedor.DataSource = dt
        cboProveedor.ValueMember = "nit"
        cboProveedor.DisplayMember = "nombres"
        cboProveedor.SelectedValue = 0
    End Sub
    Private Sub cargarGridClasificacion()
        Dim sql As String = "SELECT     puntaje, descripcion As descripción, clasificacion As calificación " & _
                                  "FROM C_clasificacion "
        Dim dt As New DataTable
        dt = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")
        dt.Columns.Add("calificación_real")
        dtg_clasifiacion.DataSource = dt
    End Sub
    Private Sub pintarDtg()
        Dim pintura As New System.Drawing.Color
        Dim ant As Integer = 0
        pintura = Color.Gainsboro
        For i = 0 To dtgEvaluacion.RowCount - 2
            If (dtgEvaluacion.Item("FACTOR", i).Value = dtgEvaluacion.Item("FACTOR", ant).Value) Then
                dtgEvaluacion.Rows(i).DefaultCellStyle.BackColor = pintura
            Else
                If (pintura = Color.Gainsboro) Then
                    pintura = Color.White
                Else
                    pintura = Color.Gainsboro
                End If
                dtgEvaluacion.Rows(i).DefaultCellStyle.BackColor = pintura
            End If
            ant = i
        Next
    End Sub
    Public Sub formatoNegrita()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        dtgEvaluacion.Columns(0).DefaultCellStyle = DataGridViewCellStyle1
        dtgEvaluacion.Rows(dtgEvaluacion.RowCount - 1).DefaultCellStyle = DataGridViewCellStyle1
        dtg_clasifiacion.Columns(0).DefaultCellStyle = DataGridViewCellStyle1
    End Sub

    Private Sub cboProveedor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboProveedor.SelectedIndexChanged
        If (carga_comp) Then
            Dim nit As Double = cboProveedor.SelectedValue
            Dim sql As String = "SELECT nomb_contacto FROM C_proveedor_categoria WHERE nit = " & nit
            txtContacto.Text = objIngresoProdLn.consultar_valor(sql, "PRODUCCION")
            If (id_evaluacion_existente <> 0) Then
                Dim fecha_eval As String = objOpSimplesLn.cambiarFormatoFecha(objIngresoProdLn.consultar_valor("SELECT fecha FROM C_eval_proveedor WHERE id = " & id_evaluacion_existente, "PRODUCCION"))
                sql = "SELECT SUM (valor) from  C_eval_puntaje WHERE id_evaluacion = (SELECT TOP(1)id FROM C_eval_proveedor WHERE proveedor = " & cboProveedor.SelectedValue & " AND id <> " & id_evaluacion_existente & " AND fecha <'" & fecha_eval & "'   ORDER BY fecha desc)"
                txtPuntajePerAnt.Text = objIngresoProdLn.consultar_valor(sql, "PRODUCCION")
            Else
                txtPuntajePerAnt.Text = objIngresoProdLn.consultar_valor("SELECT SUM (valor) from  C_eval_puntaje WHERE id_evaluacion = (SELECT TOP(1)id FROM C_eval_proveedor WHERE  proveedor = " & cboProveedor.SelectedValue & "   ORDER BY fecha desc)", "PRODUCCION")
            End If

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

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        dtgEvaluacion.CurrentCell = Nothing
        If (validarEvaluacion()) Then
            Dim proveedor As String = cboProveedor.SelectedValue
            Dim fecha As String = objOpSimplesLn.cambiarFormatoFecha(cboFecha.Value)
            Dim observaciones As String = txtNotas.Text
            Dim id_evaluacion As String = ""
            Dim puntos As Integer = txtPuntajeObtenido.Text

            If (id_evaluacion_existente <> 0) Then
                id_evaluacion = 0
                moficicar(proveedor, fecha, observaciones, id_evaluacion_existente, puntos)
            Else
                id_evaluacion = objIngresoProdLn.consultar_valor("SELECT MAX (id) + 1 FROM C_eval_proveedor", "PRODUCCION")
                If (id_evaluacion = 0) Then
                    id_evaluacion = 1
                End If
                guardar(proveedor, fecha, observaciones, id_evaluacion, puntos)
            End If
        End If

    End Sub
    Private Sub moficicar(ByVal proveedor As String, ByVal fecha As String, ByVal observaciones As String, ByVal id_evaluacion As Integer, ByVal puntos As Integer)
        Dim listSql As New List(Of Object)
        Dim moficoCorrecto As Boolean = False
        Dim sqlEncEvaluacion As String = ""
        sqlEncEvaluacion = "UPDATE C_eval_proveedor SET proveedor = " & proveedor & ",fecha = '" & fecha & "',observaciones = '" & observaciones & "',puntos = " & puntos & " " & _
                                "WHERE id = " & id_evaluacion
        listSql.Add(sqlEncEvaluacion)
        For i = 0 To dtgEvaluacion.RowCount - 2
            If (dtgEvaluacion.Item("PUNTAJE", i).Value.ToString <> "") Then
                listSql.Add(sqlResultadoEval_factor_update(i, id_evaluacion))
            End If
        Next
        moficoCorrecto = objIngresoProdLn.ExecuteSqlTransaction(listSql, "PRODUCCION")
        If (moficoCorrecto) Then
            MessageBox.Show("La evaluación fue modificada en forma exitosa! ", "Correcto!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            nuevo()
        Else
            MessageBox.Show("Error al modificar la evaluación comuniquese con el administrador del sistema ", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Private Sub guardar(ByVal proveedor As String, ByVal fecha As String, ByVal observaciones As String, ByVal id_evaluacion As Integer, ByVal puntos As Integer)
        Dim insertoCorrecto As Boolean = False
        Dim listSql As New List(Of Object)
        Dim sqlEncEvaluacion As String = ""
        If (id_evaluacion = "0") Then
            id_evaluacion = 1
        End If
        sqlEncEvaluacion = "INSERT INTO C_eval_proveedor (id,proveedor,fecha,observaciones,puntos) " & _
                                        "VALUES (" & id_evaluacion & "," & proveedor & ",'" & fecha & "','" & observaciones & "'," & puntos & ")"
        listSql.Add(sqlEncEvaluacion)
        For i = 0 To dtgEvaluacion.RowCount - 2
            If (dtgEvaluacion.Item("PUNTAJE", i).Value.ToString <> "") Then
                listSql.Add(sqlResultadoEval_factor_insert(i, id_evaluacion))
            End If
        Next
        insertoCorrecto = objIngresoProdLn.ExecuteSqlTransaction(listSql, "PRODUCCION")
        If (insertoCorrecto) Then
            MessageBox.Show("La evaluación fue guardada en forma exitosa! ", "Correcto!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            nuevo()
        Else
            MessageBox.Show("Error al guardar la evaluación comuniquese con el administrador del sistema ", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Function validarEvaluacion() As Boolean
        Dim resp As Boolean = False
        If (cboProveedor.Text <> "Seleccione") Then
            If (txtNotas.Text <> "") Then
                If (validarCalificacionesLlenas()) Then
                    resp = True
                Else
                    resp = False
                    MessageBox.Show("Verifique que todos los puntajes esten correctamente diligenciados ", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                resp = False
                MessageBox.Show("Se debe diligenciar el campo observaciones", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            resp = False
            MessageBox.Show("Seleccione un proveedor", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        Return resp
    End Function
    Private Function sqlResultadoEval_factor_insert(ByVal fila As Integer, ByVal id_evaluacion As Integer) As String
        Dim sql As String = ""
        Dim calificacion As Integer = dtgEvaluacion.Item("PUNTAJE", fila).Value
        Dim id_factor As Integer = dtgEvaluacion.Item("id_factor", fila).Value
        sql = "INSERT INTO C_eval_puntaje (id_factor,id_evaluacion,valor) VALUES (" & id_factor & "," & id_evaluacion & "," & calificacion & ")"
        Return sql
    End Function
    Private Function sqlResultadoEval_factor_update(ByVal fila As Integer, ByVal id_evaluacion As Integer) As String
        Dim sql As String = ""
        Dim calificacion As Integer = dtgEvaluacion.Item("PUNTAJE", fila).Value
        Dim id_factor As Integer = dtgEvaluacion.Item("id_factor", fila).Value
        sql = "UPDATE C_eval_puntaje SET valor = " & calificacion & " WHERE id_factor = " & id_factor & " AND id_evaluacion =  " & id_evaluacion
        Return sql
    End Function

    Private Sub dtgEvaluacion_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgEvaluacion.CellValueChanged
        If (carga_comp) Then
            Dim col As String = dtgEvaluacion.Columns(e.ColumnIndex).Name
            Dim fila As Integer = e.RowIndex
            Dim puntaje As Integer = 0
            Dim puntajeMax As Integer = 0
            If (col = "PUNTAJE") Then
                If (validarCalifiaciónPorFactor(fila)) Then
                    If (dtgEvaluacion.Item("PUNTAJE", e.RowIndex).Value.ToString <> "") Then
                        puntaje = dtgEvaluacion.Item("PUNTAJE", e.RowIndex).Value
                        puntajeMax = dtgEvaluacion.Item("PUNTAJE_MÁXIMO", e.RowIndex).Value

                        If (puntaje > puntajeMax) Then
                            MessageBox.Show("El puntaje esta por ensima de el máximo establesido", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            carga_comp = False
                            dtgEvaluacion.Item("PUNTAJE", e.RowIndex).Value = ""
                            carga_comp = True
                        Else
                            totalGeneralGrid()
                            calificacionGeneral()
                        End If
                    End If
                Else
                    MessageBox.Show("Este factor ya esta calificado", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    carga_comp = False
                    dtgEvaluacion.Item("PUNTAJE", e.RowIndex).Value = ""
                    carga_comp = True
                End If

            End If
        End If
    End Sub
    Private Function validarCalifiaciónPorFactor(ByVal fila As Integer) As Boolean
        Dim factor As String = dtgEvaluacion.Item("FACTOR", fila).Value
        Dim cont_valores As Integer = 0
        For i = 0 To dtgEvaluacion.RowCount - 2
            If (dtgEvaluacion.Item("FACTOR", i).Value = factor) Then
                If (dtgEvaluacion.Item("PUNTAJE", i).Value.ToString <> "") Then
                    cont_valores += 1
                End If
            End If
        Next
        If (cont_valores > 1) Then
            Return False
        Else
            Return True
        End If
    End Function
    Private Sub totalGeneralGrid()
        Dim sum As Integer = 0
        For i = 0 To dtgEvaluacion.RowCount - 2
            If Not IsDBNull(dtgEvaluacion.Item("PUNTAJE", i).Value) Then
                If (dtgEvaluacion.Item("PUNTAJE", i).Value.ToString <> "") Then
                    sum += dtgEvaluacion.Item("PUNTAJE", i).Value
                End If
            End If
        Next
        carga_comp = False
        dtgEvaluacion.Item("PUNTAJE", dtgEvaluacion.RowCount - 1).Value = sum
        txtPuntajeObtenido.Text = sum
        carga_comp = True
    End Sub
    Private Sub calificacionGeneral()
        Dim puntaje As Integer = 0
        If (txtPuntajeObtenido.Text <> "") Then
            puntaje = txtPuntajeObtenido.Text
            dtg_clasifiacion.Item("calificación_real", 0).Value = ""
            dtg_clasifiacion.Item("calificación_real", 1).Value = ""
            dtg_clasifiacion.Item("calificación_real", 2).Value = ""
            dtg_clasifiacion.Item("calificación_real", 3).Value = ""
            If (puntaje >= 15 And puntaje <= 35) Then
                dtg_clasifiacion.Item("calificación_real", 0).Value = "Deficiente"
            ElseIf (puntaje >= 36 And puntaje <= 60) Then
                dtg_clasifiacion.Item("calificación_real", 1).Value = "Regular"
            ElseIf (puntaje >= 61 And puntaje <= 85) Then
                dtg_clasifiacion.Item("calificación_real", 2).Value = "Bueno"
            ElseIf (puntaje >= 86 And puntaje <= 100) Then
                dtg_clasifiacion.Item("calificación_real", 3).Value = "Excelente"
            End If
        End If
    End Sub
    Private Function validarCalificacionesLlenas() As Boolean
        Dim factorAnt As String = dtgEvaluacion.Item("FACTOR", 0).Value
        Dim cont_factor As Integer = 1
        Dim cont_cal As Integer = 0
        Dim sw As Boolean = True
        For i = 0 To dtgEvaluacion.RowCount - 2
            If (factorAnt <> dtgEvaluacion.Item("FACTOR", i).Value And sw) Then
                cont_factor += 1
                factorAnt = dtgEvaluacion.Item("FACTOR", i).Value
                sw = False
            Else
                sw = True
            End If
            If (dtgEvaluacion.Item("PUNTAJE", i).Value.ToString <> "") Then
                cont_cal += 1
            End If
        Next
        If (cont_factor = cont_cal) Then
            Return True
        Else
            Return False
        End If
    End Function
    Private Sub dtgEvaluacion_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dtgEvaluacion.KeyPress
        soloNumero(e)
    End Sub
    Private Sub soloNumero(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If (Char.IsDigit(e.KeyChar) Or e.KeyChar = ".") Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        nuevo()
    End Sub
    Private Sub nuevo()
        carga_comp = False
        id_evaluacion_existente = 0
        cboProveedor.SelectedValue = 0
        txtContacto.Text = ""
        txtNotas.Text = ""
        txtPuntajeObtenido.Text = ""
        txtPuntajePerAnt.Text = ""
        For i = 0 To dtg_clasifiacion.RowCount - 1
            dtg_clasifiacion.Item("calificación_real", i).Value = ""
        Next
        For i = 0 To dtgEvaluacion.RowCount - 1
            dtgEvaluacion.Item("PUNTAJE", i).Value = ""
        Next
        carga_comp = True
    End Sub
    Public Sub cargarPorConsulta(ByVal id_evaluacion As Integer)
        nuevo()
        Dim sql As String = "SELECT E.id,E.fecha ,E.proveedor,E.observaciones " & _
                                "FROM C_eval_proveedor E " & _
                                    "WHERE E.id =" & id_evaluacion
        Dim lista As New List(Of Object)
        lista = objIngresoProdLn.listaValores(sql, "PRODUCCION", 3)
        id_evaluacion_existente = lista(0)
        cboFecha.Value = lista(1)
        cboProveedor.SelectedValue = lista(2)
        txtNotas.Text = lista(3)
        carga_comp = False
        lista = New List(Of Object)
        sql = "SELECT valor  FROM C_eval_puntaje WHERE id_evaluacion = " & id_evaluacion & " ORDER BY id_factor "
        lista = objIngresoProdLn.listaValores(sql, "PRODUCCION", 0)

        Dim factorAnt As String = ""
        Dim sw As Boolean = True
        Dim iLista As Integer = 0
        For i = 0 To dtgEvaluacion.RowCount - 2
            If (factorAnt <> dtgEvaluacion.Item("FACTOR", i).Value And sw) Then
                factorAnt = dtgEvaluacion.Item("FACTOR", i).Value
                sw = False
                dtgEvaluacion.Item("PUNTAJE", i).Value = lista(iLista)
                iLista += 1
            Else
                sw = True
            End If
        Next
        totalGeneralGrid()
        calificacionGeneral()
        carga_comp = True
    End Sub

  
End Class