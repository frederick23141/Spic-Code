Imports logicaNegocios
Imports System.Windows.Forms.DataVisualization.Charting
Public Class Frm_Consultar_Mante
    Private objOperacionesForm As New OperacionesFormularios
    Private obj_Ing_prodLn As New Ing_prodLn
    Dim carga_completa As Boolean = False
    Private Sub Frm_Consultar_Mante_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim sql As String
        Dim col As New DataColumn
        Dim dt As New DataTable
        sql = "select codigoM,Nombre from J_Maquinas where Activa=1"
        cboMaquina.DataSource = obj_Ing_prodLn.listar_datatable(sql, "PRODUCCION")
        cboMaquina.ValueMember = "codigoM"
        cboMaquina.DisplayMember = "Nombre"
        cboMaquina.Text = "Seleccione"

        sql = "select id_Seccion,nombre from b_Seccion ORDER BY nombre "
        cboSeccion.DataSource = obj_Ing_prodLn.listar_datatable(sql, "PRODUCCION")
        cboSeccion.ValueMember = "id_Seccion"
        cboSeccion.DisplayMember = "nombre"
        cboSeccion.Text = "Seleccione"
        carga_completa = True
    End Sub

    Private Sub cboSeccion_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSeccion.SelectedIndexChanged
        If (carga_completa) Then
            cargar_consulta()
        End If
    End Sub

    Public Sub cargar_consulta()
        Try

            Dim fec_ini As Date = cboFecha_Inicial.Value.Date
            Dim fec_fin As Date = cboFecha_Final.Value.Date
            If (fec_ini < fec_fin) Then
                Dim Maquina As String = Convert.ToString(cboMaquina.SelectedValue)
                Dim Seccion As String = Convert.ToString(cboSeccion.SelectedValue)
                Dim select_sql As String = ""
                Dim from_sql As String = ""
                Dim where_sql As String = ""
                Dim where_sql_fec As String = " AND so.fechaIngresada>= '" & fec_ini & "' AND so.fechaIngresada<= '" & fec_fin & "' "
                Dim group_sql As String = ""
                Dim sql As String = ""
                chkTodosSeccion.Checked = False
                If (cboMaquina.Text <> "Seleccione" And cboSeccion.Text = "Seleccione") Then
                    select_sql = "select so.id_Solicitud As Consecutivo,so.fechaIngresada AS Fecha_Ingresada,se.nombre As Nombre_Seccion,ma.Nombre As Nombre_Maquina,solicitante As Solicitante, q_Resive As Quien_Resibe, q_Realiza As Quien_Realiza,so.fecha_IniciarTra As Fecha_Iniciar_Trabajo,so.descripcion As Descripcion_Problema,so.problema As Problema_Encontrado,so.causas As Causas,so.solucion As Solucion,rep.descripcion As Repuestos_Utilizados,so.nota As Nota,so.fecha_Entrega As Fecha_Entrega, q_Recibe_Satisfaccion As Resibe_a_Satisfaccion,so.costos As Costos"
                    from_sql = " from b_Rep_Solicitud repS, b_Repuestos rep, b_Seccion se, b_Solicitud_Correcion so, J_Maquinas ma, corsan.dbo.V_nom_personal_Activo_con_maquila per"
                    where_sql = " where se.id_Seccion = so.seccion and so.maquina = ma.codigoM and so.maquina = '" & Maquina & "' and repS.id_Respuesto= so.id_Solicitud and repS.id_Solicitud = rep.id_Repuesto"
                    group_sql = " group by so.id_Solicitud,so.fechaIngresada,solicitante, q_Resive, q_Realiza,so.fecha_IniciarTra,so.descripcion,so.problema,so.causas,so.solucion,so.nota,so.fecha_Entrega, q_Recibe_Satisfaccion,so.costos,se.nombre,ma.Nombre,rep.descripcion"
                ElseIf (cboSeccion.Text <> "Seleccione" And cboMaquina.Text = "Seleccione") Then
                    select_sql = "select so.id_Solicitud As Consecutivo,so.fechaIngresada AS Fecha_Ingresada,se.nombre As Nombre_Seccion,ma.Nombre As Nombre_Maquina,solicitante As Solicitante, q_Resive As Quien_Resibe, q_Realiza As Quien_Realiza,so.fecha_IniciarTra As Fecha_Iniciar_Trabajo,so.descripcion As Descripcion_Problema,so.problema As Problema_Encontrado,so.causas As Causas,so.solucion As Solucion,rep.descripcion As Repuestos_Utilizados,so.nota As Nota,so.fecha_Entrega As Fecha_Entrega, q_Recibe_Satisfaccion As Resibe_a_Satisfaccion,so.costos As Costos"
                    from_sql = " from b_Rep_Solicitud repS, b_Repuestos rep, b_Seccion se, b_Solicitud_Correcion so, J_Maquinas ma, corsan.dbo.V_nom_personal_Activo_con_maquila per"
                    where_sql = " where se.id_Seccion = so.seccion and se.id_Seccion = '" & Seccion & "' and so.maquina = ma.codigoM  and repS.id_Respuesto= so.id_Solicitud and repS.id_Solicitud = rep.id_Repuesto "
                    group_sql = "group by so.id_Solicitud,so.fechaIngresada,solicitante, q_Resive, q_Realiza,so.fecha_IniciarTra,so.descripcion,so.problema,so.causas,so.solucion,so.nota,so.fecha_Entrega, q_Recibe_Satisfaccion,so.costos,se.nombre,ma.Nombre,rep.descripcion"
                ElseIf (cboMaquina.Text <> "Seleccione" And cboSeccion.Text <> "Seleccione") Then
                    select_sql = "select so.id_Solicitud As Consecutivo,so.fechaIngresada AS Fecha_Ingresada,se.nombre As Nombre_Seccion,ma.Nombre As Nombre_Maquina,solicitante As Solicitante, q_Resive As Quien_Resibe, q_Realiza As Quien_Realiza,so.fecha_IniciarTra As Fecha_Iniciar_Trabajo,so.descripcion As Descripcion_Problema,so.problema As Problema_Encontrado,so.causas As Causas,so.solucion As Solucion,rep.descripcion As Repuestos_Utilizados,so.nota As Nota,so.fecha_Entrega As Fecha_Entrega, q_Recibe_Satisfaccion As Resibe_a_Satisfaccion,so.costos As Costos"
                    from_sql = " from b_Rep_Solicitud repS, b_Repuestos rep, b_Seccion se, b_Solicitud_Correcion so, J_Maquinas ma, corsan.dbo.V_nom_personal_Activo_con_maquila per"
                    where_sql = " where se.id_Seccion = so.seccion and se.id_Seccion = '" & Seccion & "' and so.maquina = ma.codigoM and so.maquina = '" & Maquina & "' and repS.id_Respuesto= so.id_Solicitud and repS.id_Solicitud = rep.id_Repuesto "
                    group_sql = "group by so.id_Solicitud,so.fechaIngresada,solicitante, q_Resive, q_Realiza,so.fecha_IniciarTra,so.descripcion,so.problema,so.causas,so.solucion,so.nota,so.fecha_Entrega, q_Recibe_Satisfaccion,so.costos,se.nombre,ma.Nombre,rep.descripcion"
                Else
                    chkTodosSeccion.Checked = False
                    MsgBox("Seleccione una maquina ó una seccion porfavor")
                End If
                sql = select_sql & from_sql & where_sql & where_sql_fec & group_sql
                dtgConsultarMante.DataSource = obj_Ing_prodLn.listar_datatable(sql, "PRODUCCION")
            ElseIf (fec_ini > fec_fin) Then
                MsgBox("Fecha inicial tiene que ser menor a la fecha final")
                cboMaquina.Text = "Seleccione"
                cboSeccion.Text = "Seleccione"
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub cboMaquina_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMaquina.SelectedIndexChanged
        If (carga_completa) Then
            cargar_consulta()
        End If
    End Sub

    Private Sub btn_excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_excel.Click
        objOperacionesForm.ExportarDatosExcel(dtgConsultarMante, "Solicitud De Correccion")
    End Sub

    Private Sub chkTodosSeccion_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTodosSeccion.CheckedChanged
        Try

            If (chkTodosSeccion.Checked = True) Then
                Dim fec_ini As Date = cboFecha_Inicial.Value.Date
                Dim fec_fin As Date = cboFecha_Final.Value.Date
                If (fec_ini < fec_fin) Then

                    cboMaquina.Text = "Seleccione"
                    cboSeccion.Text = "Seleccione"
                    Dim select_sql As String = ""
                    Dim from_sql As String = ""
                    Dim where_sql As String = ""
                    Dim where_sql_fec As String = " AND so.fechaIngresada>= '" & fec_ini & "' AND so.fechaIngresada<= '" & fec_fin & "' "
                    Dim group_sql As String = ""
                    Dim sql As String = ""
                    select_sql = "select so.id_Solicitud As Consecutivo,so.fechaIngresada AS Fecha_Ingresada,se.nombre As Nombre_Seccion,ma.Nombre As Nombre_Maquina,solicitante As Solicitante, q_Resive As Quien_Resibe, q_Realiza As Quien_Realiza,so.fecha_IniciarTra As Fecha_Iniciar_Trabajo,so.descripcion As Descripcion_Problema,so.problema As Problema_Encontrado,so.causas As Causas,so.solucion As Solucion,rep.descripcion As Repuestos_Utilizados,so.nota As Nota,so.fecha_Entrega As Fecha_Entrega, q_Recibe_Satisfaccion As Resibe_a_Satisfaccion,so.costos As Costos"
                    from_sql = " from b_Rep_Solicitud repS, b_Repuestos rep, b_Seccion se, b_Solicitud_Correcion so, J_Maquinas ma, corsan.dbo.V_nom_personal_Activo_con_maquila per"
                    where_sql = " where se.id_Seccion = so.seccion and so.maquina = ma.codigoM  and repS.id_Respuesto= so.id_Solicitud and repS.id_Solicitud = rep.id_Repuesto"
                    group_sql = " group by so.id_Solicitud,so.fechaIngresada,solicitante, q_Resive, q_Realiza,so.fecha_IniciarTra,so.descripcion,so.problema,so.causas,so.solucion,so.nota,so.fecha_Entrega, q_Recibe_Satisfaccion,so.costos,se.nombre,ma.Nombre,rep.descripcion"
                    sql = select_sql & from_sql & where_sql & where_sql_fec & group_sql
                    dtgConsultarMante.DataSource = obj_Ing_prodLn.listar_datatable(sql, "PRODUCCION")
                    'ElseIf (chkTodosSeccion.Checked = False) Then
                    '    cargar_consulta()
                Else
                    MsgBox("Fecha inicial tiene que ser menor a la fecha final.")
                    chkTodosSeccion.Checked = False
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
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

End Class