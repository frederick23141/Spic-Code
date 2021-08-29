Imports System.Configuration
Imports logicaNegocios
Imports System.IO
Imports Microsoft.Office.Interop
#Disable Warning BC40056 ' El espacio de nombres o el tipo especificado en el 'System.Data.SqlServerCe' Imports no contienen ningún miembro público o no se encuentran. Asegúrese de que el espacio de nombres o el tipo se hayan definido y de que contengan al menos un miembro público. Asegúrese de que el nombre del elemento importado no use ningún alias.
Imports System.Data.SqlServerCe
#Enable Warning BC40056 ' El espacio de nombres o el tipo especificado en el 'System.Data.SqlServerCe' Imports no contienen ningún miembro público o no se encuentran. Asegúrese de que el espacio de nombres o el tipo se hayan definido y de que contengan al menos un miembro público. Asegúrese de que el nombre del elemento importado no use ningún alias.
Public Class Frm_consutar_recocido
#Region "Atributos"
    Private obj_Ing_prodLn As New Ing_prodLn
    Private objOpSimplesLn As New Op_simpesLn
    Private objOperacionesForm As New OperacionesFormularios
    Dim carga_completa As Boolean = False
#End Region

#Region "Metodos Del Form"
    Private Sub cargarCombosOperarios(ByVal centro As String)
        If (centro = "2300") Then
            cboPOpera.DataSource = obj_Ing_prodLn.listarOperarios("todos")
        End If
        cboPOpera.ValueMember = "nit"
        cboPOpera.DisplayMember = "nombres"
        cboPOpera.Text = "Seleccione"
        cboPOpera.SelectedValue = 0
    End Sub
    Private Sub cargar()
        Dim strSql As String = "SELECT d.Nro_Orden AS NUM_ORDEN,Rollo As ORDEN,Codigo AS CODIGO,Peso AS PESO,o.KilosPro AS KILOS_PROGRAMADOS,d.Traccion AS TRACCION,NumOrdenPro AS NUM_ORDEN_DE_PRODUCCION_F012,NumRollo AS NUM_ROLLO,Colada AS COLADA,Observaciones AS OBSERVACIONES FROM b_Detalle_Recocido d , b_Orden_Recocido o "
        Dim whereSql As String = "WHERE "
        Dim valor As String = ""
        If (txtOrdenProd.Text <> "") Then
            valor = txtOrdenProd.Text
            whereSql += " d.Nro_Orden like '" & valor & "%' and d.Nro_Orden = o.Nro_Orden GROUP BY d.Nro_Orden,Rollo,Codigo,Peso,o.KilosPro,d.Traccion,NumOrdenPro,NumRollo,Colada,Observaciones"
        End If
        strSql = strSql & whereSql
        dtgDatos.DataSource = objOpSimplesLn.listar_datatable(strSql, "PRODUCCION")
        calcular_totales(dtgDatos)
    End Sub
    Public Sub calcular_totales(ByVal dtg As DataGridView)
        If (dtgDatos.RowCount > 0) Then
            dtgDatos.Item("codigo", dtgDatos.RowCount - 1).Value = "TOTAL"
            dtgDatos.Item("codigo", dtgDatos.RowCount - 1).Style.BackColor = Color.Gainsboro
            dtgDatos.Item("peso", dtgDatos.RowCount - 1).Value = sumarColumna("peso", dtgDatos)
            dtgDatos.Item("peso", dtgDatos.RowCount - 1).Style.BackColor = Color.Gainsboro
        End If
    End Sub
    Private Function sumarColumna(ByVal nomColumna As String, ByVal dtg As DataGridView) As Double
        Dim total As Double = 0
        For i As Integer = 0 To dtg.RowCount - 1
            total = total + CDbl(dtg.Item(nomColumna.ToLower, i).Value)
        Next
        Return total
    End Function
    Private Sub cargar_filtrar()
        Dim fechaIni As String = objOpSimplesLn.cambiarFormatoFecha(dtFechaInicial.Value)
        Dim fechaFin As String = objOpSimplesLn.cambiarFormatoFecha(dtFechaFinal.Value)
        Dim operario As String = Convert.ToString(cboPOpera.SelectedValue)
        Dim codigo As String = txtCodigoo.Text
        Dim strSql As String = "SELECT d.Nro_Orden AS NUM_ORDEN,Rollo As ORDEN,Codigo AS CODIGO,Peso AS PESO,o.KilosPro AS KILOS_PROGRAMADOS,d.Traccion AS TRACCION,NumOrdenPro AS NUM_ORDEN_DE_PRODUCCION_F012,NumRollo AS NUM_ROLLO,Colada AS COLADA,c.nombres As OPERARIO,Observaciones AS OBSERVACIONES FROM b_Detalle_Recocido d , b_Orden_Recocido o,CORSAN.dbo.V_nom_personal_Activo_con_maquila c "
        Dim whereSql As String = " WHERE FechaInicial >='" & fechaIni & "' and FechaInicial <= '" & fechaFin & "' and o.Nro_Orden = d.Nro_Orden and c.nit = o.POpera "
        Dim groupSql As String = "GROUP BY d.Nro_Orden,Rollo,Codigo,Peso,o.KilosPro,d.Traccion,NumOrdenPro,NumRollo,Colada,c.nombres,Observaciones"

        If (codigo <> "" And operario <> "") Then
            whereSql += " and d.codigo like '" & codigo & "%' and o.POpera='" & operario & "'"
            strSql = strSql & whereSql & groupSql
            dtgDatos.DataSource = objOpSimplesLn.listar_datatable(strSql, "PRODUCCION")
            calcular_totales(dtgDatos)
        ElseIf (codigo <> "" And operario = "") Then
            whereSql += " and d.codigo like '" & codigo & "%'"
            strSql = strSql & whereSql & groupSql
            dtgDatos.DataSource = objOpSimplesLn.listar_datatable(strSql, "PRODUCCION")
            calcular_totales(dtgDatos)
        ElseIf (codigo = "" And operario <> "" And chkTodos.Checked = False) Then
            whereSql += " and o.POpera='" & operario & "'"
            strSql = strSql & whereSql & groupSql
            dtgDatos.DataSource = objOpSimplesLn.listar_datatable(strSql, "PRODUCCION")
            calcular_totales(dtgDatos)
        ElseIf (chkTodos.Checked = True) Then
            whereSql = " WHERE o.Nro_Orden = d.Nro_Orden and c.nit = o.POpera "
            strSql = strSql & whereSql & groupSql
            dtgDatos.DataSource = objOpSimplesLn.listar_datatable(strSql, "PRODUCCION")
            calcular_totales(dtgDatos)

        End If
    End Sub
    Private Sub limpiar()
        txtCodigoo.Text = ""
        cboPOpera.Text = ""
        dtFechaFinal.Value = Today.Date
        dtFechaInicial.Value = Now.AddDays(-1)
        chkTodos.Checked = False
        dtFechaInicial.Focus()
    End Sub
    Private Sub cargar_consultaFecha()
        Dim i, f As String
        i = objOpSimplesLn.cambiarFormatoFecha(dtFechaInicial.Value.Date)
        f = objOpSimplesLn.cambiarFormatoFecha(dtFechaFinal.Value.Date)
        Dim strSql As String = "SELECT d.Nro_Orden AS NUM_ORDEN,Rollo As ORDEN,Codigo AS CODIGO,Peso AS PESO,o.KilosPro AS KILOS_PROGRAMADOS,d.Traccion AS TRACCION,NumOrdenPro AS NUM_ORDEN_DE_PRODUCCION_F012,NumRollo AS NUM_ROLLO,Colada AS COLADA,c.nombres As OPERARIO,Observaciones AS OBSERVACIONES FROM b_Detalle_Recocido d , b_Orden_Recocido o,CORSAN.dbo.V_nom_personal_Activo_con_maquila c "
        Dim whereSql As String = " WHERE FechaInicial >='" & i & "' and FechaInicial <= '" & f & "' and o.Nro_Orden = d.Nro_Orden and c.nit = o.POpera "
        Dim groupSql As String = "GROUP BY d.Nro_Orden,Rollo,Codigo,Peso,o.KilosPro,d.Traccion,NumOrdenPro,NumRollo,Colada,c.nombres,Observaciones"
        strSql = strSql & whereSql & groupSql
        dtgDatos.DataSource = objOpSimplesLn.listar_datatable(strSql, "PRODUCCION")
        calcular_totales(dtgDatos)
    End Sub
#End Region

#Region "Eventos"
    Private Sub Frm_consutar_recocido_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtFechaInicial.Value = Now.AddDays(-1)
        dtFechaInicial.Focus()
        cargarCombosOperarios("2300")
        carga_completa = True
    End Sub
    Private Sub txtOrdenProd_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOrdenProd.TextChanged
        If (txtOrdenProd.Text.Length >= 1) Then
            cargar()
        End If
    End Sub
    Private Sub txtCodigoo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodigoo.TextChanged
        Dim fechaIni As String = objOpSimplesLn.cambiarFormatoFecha(dtFechaInicial.Value)
        Dim fechaFin As String = objOpSimplesLn.cambiarFormatoFecha(dtFechaFinal.Value)
        If (fechaIni >= fechaFin) Then
            MessageBox.Show("Verifique fecha incial tiene que ser menor a la fecha final", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            If (txtCodigoo.Text <> "") Then
                chkTodos.Checked = False
                cargar_filtrar()
            End If
        End If
    End Sub
    Private Sub cboPOpera_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPOpera.SelectedIndexChanged
        If (carga_completa) Then
            Dim fechaIni As String = objOpSimplesLn.cambiarFormatoFecha(dtFechaInicial.Value)
            Dim fechaFin As String = objOpSimplesLn.cambiarFormatoFecha(dtFechaFinal.Value)
            If (fechaIni >= fechaFin) Then
                MessageBox.Show("Verifique fecha incial tiene que ser menor a la fecha final", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
                dtFechaInicial.Focus()
                limpiar()
            Else
                chkTodos.Checked = False
                cargar_filtrar()
            End If
        End If
    End Sub
    Private Sub chkTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTodos.CheckedChanged
        If (chkTodos.Checked = True) Then
            txtCodigoo.Text = ""
            txtOrdenProd.Text = ""
            cboPOpera.Text = ""
            cboPOpera.Text = ""
            cargar_filtrar()
        End If
    End Sub
    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        limpiar()
    End Sub
    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        FrmPrincipal.Show()
        Me.Close()
        FrmPrincipal.Activate()
    End Sub
    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        FrmLogin.Show()
        FrmPrincipal.Close()
        Frm_Solicitud_Correccion.Close()
        Me.Close()
    End Sub
    Private Sub btn_excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_excel.Click
        objOperacionesForm.ExportarDatosExcel(dtgDatos, "Recocido")
    End Sub
#End Region

    Private Sub dtFechaInicial_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtFechaInicial.ValueChanged
        Try
            If (carga_completa) Then
                Dim Fini, Ffin As Date
                Fini = objOpSimplesLn.cambiarFormatoFecha(dtFechaInicial.Value.Date)
                Ffin = objOpSimplesLn.cambiarFormatoFecha(dtFechaFinal.Value.Date)
                If (Fini > Ffin) Then
                    MsgBox("Fecha Inicial Mayor A La Fecha Final, Cambie La Fecha Incial")
                Else
                    cargar_consultaFecha()
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Private Sub dtFechaFinal_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtFechaFinal.ValueChanged
        Try
            If (carga_completa) Then
                Dim Fini, Ffin As Date
                Fini = objOpSimplesLn.cambiarFormatoFecha(dtFechaInicial.Value.Date)
                Ffin = objOpSimplesLn.cambiarFormatoFecha(dtFechaFinal.Value.Date)

                If (Fini > Ffin) Then
                    MsgBox("Fecha Inicial Mayor A La Fecha Final, Cambie La Fecha Incial")
                Else
                    cargar_consultaFecha()
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class