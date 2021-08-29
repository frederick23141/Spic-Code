#Disable Warning BC40056 ' El espacio de nombres o el tipo especificado en el 'System.Configurationcolim' Imports no contienen ningún miembro público o no se encuentran. Asegúrese de que el espacio de nombres o el tipo se hayan definido y de que contengan al menos un miembro público. Asegúrese de que el nombre del elemento importado no use ningún alias.
Imports System.Configurationcolim
#Enable Warning BC40056 ' El espacio de nombres o el tipo especificado en el 'System.Configurationcolim' Imports no contienen ningún miembro público o no se encuentran. Asegúrese de que el espacio de nombres o el tipo se hayan definido y de que contengan al menos un miembro público. Asegúrese de que el nombre del elemento importado no use ningún alias.
Imports logicaNegocios
Imports entidadNegocios
Imports System.IO
Imports Microsoft.Office.Interop
#Disable Warning BC40056 ' El espacio de nombres o el tipo especificado en el 'System.Data.SqlServerCef' Imports no contienen ningún miembro público o no se encuentran. Asegúrese de que el espacio de nombres o el tipo se hayan definido y de que contengan al menos un miembro público. Asegúrese de que el nombre del elemento importado no use ningún alias.
Imports System.Data.SqlServerCef
#Enable Warning BC40056 ' El espacio de nombres o el tipo especificado en el 'System.Data.SqlServerCef' Imports no contienen ningún miembro público o no se encuentran. Asegúrese de que el espacio de nombres o el tipo se hayan definido y de que contengan al menos un miembro público. Asegúrese de que el nombre del elemento importado no use ningún alias.
Imports System.Globalization.CultureInfo

Public Class FrmOrdenProdTef
    Private peso As String = ""
    Dim permiso As String = ""
    Private objOpSimplesLn As New Op_simpesLn
    Private obj_correoLn As New EnvCorreoLN
    Private obj_Ing_prodLn As New Ing_prodLn
    Private objOrdenProdLn As New OrdenProdLn
    Private objOpsimpesLn As New Op_simpesLn
    Private objOperacionesForm As OperacionesFormularios = New OperacionesFormularios
    Private estadoTurno As Boolean = False
    Private consecutivoPpal As Double = 1
    Private consecutivoDet As Double = 0
    Dim orden_existe As String
    Dim usuario As String = ""
    Dim dtTerceros As DataTable
    Dim cargaComp As Boolean = False
    Dim horaIniParo As Date
    Private idioma As String = ""
    Dim contAlertPlanInspAl As Integer
    Private objTraslado_bodLn As New traslado_bodLn
    Private num_tran_amarres As Double = 0
    Private num_tran_no_conforme As Double = 0
    Private num_tran_prod As Double = 0
    Dim fecha_transaccion As String = ""
    Dim sFechaTransaccion As String = ""
    Dim obj_gestion_alambronLn As New Gestion_alambronLn
    Dim add_rollo_mp_directo As Boolean = False
    Dim centro As String = "2100"
    Dim nit_usuario As String
    Dim dt As New DataTable
    'Variables para generar orden prod de recocido
    Dim inicio_ficha As Integer = 0
    Dim mat_prima_rec As String = ""
    Dim val As Integer = 0
    Dim val_timer As String
    Dim orden_tiq_rec As Integer = 0
    'variable para limitar el nro de rollos
    Dim limite As Integer
    Dim num_pedido As Double = 0
    Dim sw_trabajo As Boolean
    Dim frm As New Frm_alerta_bd
    Private Declare Function GetTickCount Lib "kernel32" () As Integer
    Public Sub main(ByVal usuario As String, ByVal permiso As String, ByVal nit As String)
        Me.usuario = usuario
        Me.permiso = permiso.Trim
        Me.nit_usuario = nit

        If (usuario = "operario") Then
            btn_ficha_tcnica.Enabled = False
            ContextMenuStrip2.Enabled = False
            dtgProduccion.Columns(col_notas_audit.Name).Visible = False
            TblPpal.TabPages.Remove(tblAdminProd)
            dtgOperario.Visible = True
            dtg_consulta.Visible = False
            ' Timer1.Enabled = True
            '  SerialPort1.Open()
            cboNumPasos.Enabled = False
            btnGuardar.Enabled = False
            txtProdFinal.Enabled = False
            txtDiaMin.Enabled = False
            txtDiamMAx.Enabled = False
            txtCantProg.Enabled = False
            txtDiametro.Enabled = False
            txt_cod_alambron.Enabled = False
            cboOrigen.Enabled = False
            txtMatPrima.Enabled = False
            cboCliente.Enabled = False
            cboCalidad.Enabled = False
            txtCantPendOrden.Enabled = False
            txtConsulNumOrd.Enabled = False
            cboFechaFin.Enabled = False
            cboFechaIni.Enabled = False
            cbo_maquina.Enabled = False
            txtNotas.Enabled = False
            btnBod1.Enabled = False
            btnBod2_3.Enabled = False
            TblPpal.SelectedTab = tblOrdenesOperario
            dtgPlanAsociadas.Columns(colEliminar.Name).Visible = False
            btnBod1.Enabled = False
            btnBod2_3.Enabled = False
            cbo_fec_orden.Enabled = False
            btn_cliente.Enabled = False
            btnBod2_3.Enabled = False
            txtProdFinal.Enabled = False
            btn_b1_2.Enabled = False
            cboCliente.Enabled = False
            btnBod2_3.Enabled = False
            btn_cliente.Enabled = False
            txtProdFinal.Enabled = False
            timer_act_oper.Enabled = True
        ElseIf permiso = "AUXILIAR" Then
            ContextMenuStrip2.Enabled = False
            dtgPlanInsp.ReadOnly = True
            dtg_Inp_Calidad.ReadOnly = True
            timRefescar.Enabled = True
            dtgOperario.Visible = True
            dtg_consulta.Visible = True
            '  Timer1.Enabled = True
            cboNumPasos.Enabled = True
            btnGuardar.Enabled = True
            txtProdFinal.Enabled = True
            txtDiaMin.Enabled = True
            txtDiamMAx.Enabled = True
            txtCantProg.Enabled = True
            txtDiametro.Enabled = True
            txt_cod_alambron.Enabled = True
            cboOrigen.Enabled = True
            cboCliente.Enabled = True
            txtMatPrima.Enabled = True
            cboCalidad.Enabled = True
            txtCantPendOrden.Enabled = True
            txtCantProg.Enabled = True
            txtConsulNumOrd.Enabled = True
            cboFechaFin.Enabled = True
            cboFechaIni.Enabled = True
            cbo_maquina.Enabled = True
            txtNotas.Enabled = True
            btnBod1.Enabled = True
            btnBod2_3.Enabled = True
            dtgOperario.Visible = False
            dtg_consulta.Visible = True
            '  Timer1.Enabled = False
            '  SerialPort1.Close()
            TblPpal.SelectedTab = tblAdminProd
            btnBod1.Enabled = True
            btnBod2_3.Enabled = True
            btnIniciaPara.Enabled = False
            txtHorometroIni.ReadOnly = True
            txtHorometroFin.ReadOnly = True
            txt_amarres.ReadOnly = True
            btnBod2_3.Enabled = False
            txtProdFinal.Enabled = True
            CerrarTurnoToolStripMenuItem.Visible = True
            TblPpal.TabPages.Remove(tblOrdenesOperario)
        Else
            ContextMenuStrip2.Enabled = True
            dtgPlanInsp.ReadOnly = True
            dtg_Inp_Calidad.ReadOnly = True
            timRefescar.Enabled = True
            dtgOperario.Visible = True
            dtg_consulta.Visible = True
            '  Timer1.Enabled = True
            cboNumPasos.Enabled = True
            btnGuardar.Enabled = True
            txtProdFinal.Enabled = True
            txtDiaMin.Enabled = True
            txtDiamMAx.Enabled = True
            txtCantProg.Enabled = True
            txtDiametro.Enabled = True
            txt_cod_alambron.Enabled = True
            cboOrigen.Enabled = True
            cboCliente.Enabled = False
            txtMatPrima.Enabled = True
            cboCalidad.Enabled = True
            txtCantPendOrden.Enabled = True
            txtConsulNumOrd.Enabled = True
            cboFechaIni.Enabled = True
            cboFechaFin.Enabled = True
            cbo_maquina.Enabled = True
            txtNotas.Enabled = True
            btnBod1.Enabled = True
            btnBod2_3.Enabled = True
            dtgOperario.Visible = False
            dtg_consulta.Visible = True
            '  Timer1.Enabled = False
            '  SerialPort1.Close()
            TblPpal.SelectedTab = tblAdminProd
            btnBod1.Enabled = True
            btnBod2_3.Enabled = True
            btnIniciaPara.Enabled = False
            txtHorometroIni.ReadOnly = True
            txtHorometroFin.ReadOnly = True
            txt_amarres.ReadOnly = True
            btnBod2_3.Enabled = False
            txtProdFinal.Enabled = False
            TblPpal.TabPages.Remove(tblOrdenesOperario)
        End If
        If (Me.permiso = "ADMIN" Or Me.permiso = "COOR_PROD" Or Me.permiso = "TREFILACION" Or Me.permiso = "DIR_PRODUCCION") Then
            CerrarTurnoToolStripMenuItem.Visible = True
            CerrarForzadoToolStripMenuItem.Visible = True
            If Me.permiso <> "ADMIN" Then
                colEliminar.Visible = False
            End If
        Else
            dtgProduccion.Columns(colRollo.Name).ReadOnly = True
            dtgProduccion.Columns(colKg.Name).ReadOnly = True
            txtCantTurno.ReadOnly = False
        End If
        cargaComp = True
    End Sub

    Private Sub FrmOrdenProdTef_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        idioma = CurrentCulture.ToString
        dtgProduccion.Rows.Add()
        dtgProduccion.Item("colRollo", 0).Value = 1
        cargarDataSourse()
        Group_ficha_tecnica.Visible = False
        dtgParo.Columns("ColHini").ReadOnly = True
        dtgParo.Columns("ColHfin").ReadOnly = True
        dtgParo.Columns("colTotal").ReadOnly = True
        TblPpal.TabPages.Remove(tblPlanInsp)
    End Sub
    Private Sub cargarAdminProd(ByVal consecutivo As String)
        Dim fecIni As String = cboFechaIni.Value.ToString("yyyy-MM-dd")
        Dim fecFin As String = cboFechaFin.Value.ToString("yyyy-MM-dd")
        Dim WhereFec As String = ""
        Dim WhereCliExt As String = ""
        Dim whereMaquina As String = ""
        Dim whereOculto As String = ""
        Dim dt As New DataTable
        Dim cont_C As Integer = 0
        Dim cont_S As Integer = 0
        Dim porce_cum As Double
        If (chkClietExt.Checked) Then
            WhereCliExt = " AND tipoCliente = 0"
        End If
        'para validar que solo cuando se cambia la fecha del combo se filtre por esta no cuando cargue el frm
        If (cargaComp) Then
            If fecFin = fecIni Then
                WhereFec = "WHERE year(fecha_terminacion) = " & CInt(cboFechaIni.Value.Year) & " and month(fecha_terminacion)= " & CInt(cboFechaIni.Value.Month) & " and day(fecha_terminacion)=" & CInt(cboFechaIni.Value.Day) & ""
            Else
                WhereFec = "WHERE fecha_terminacion >='" & fecIni & "' and fecha_terminacion <='" & fecFin & "'"
            End If
            If (consecutivo <> "N/A") Then
                WhereFec += " AND consecutivo like '" & consecutivo & "%' "
            End If
        End If
        If (cboMaquinaFiltro.Text <> "Seleccione") Then
            whereMaquina = " AND orden.id_maquina = " & cboMaquinaFiltro.SelectedValue
        End If
        If chkocultos.Checked = True Then
            whereOculto = "AND oculto <> 1"
        End If
        Dim sql As String

        sql = "SELECT (SELECT COUNT (*) FROM J_det_orden_prod WHERE cod_orden = orden.consecutivo  AND cerrado is null  )As planillas_abiertas,orden.maquina,orden.consecutivo As número ,orden.prod_final,(SELECT CASE " &
                                   "WHEN orden.mes = 1  " &
                                    "THEN 'Enero'  " &
                                   "WHEN orden.mes = 2  " &
                                    "THEN 'Febrero'  " &
                                   "WHEN orden.mes = 3  " &
                                    "THEN 'Marzo'  " &
                                   "WHEN orden.mes = 4  " &
                                    "THEN 'Abril'  " &
                                   "WHEN orden.mes = 5  " &
                                    "THEN 'Mayo'  " &
                                   "WHEN orden.mes = 6  " &
                                    "THEN 'Junio'  " &
                                   "WHEN orden.mes = 7  " &
                                    "THEN 'Julio'  " &
                                   "WHEN orden.mes = 8  " &
                                    "THEN 'Agosto'  " &
                                   "WHEN orden.mes = 9  " &
                                    "THEN 'Septiembre'  " &
                                   "WHEN orden.mes = 10  " &
                                    "THEN 'Octubre'  " &
                                   "WHEN orden.mes = 11  " &
                                    "THEN 'Noviembre'  " &
                                   "WHEN orden.mes = 12  " &
                                    "THEN 'Diciembre'  " &
                                   "END)As mes,orden.ano as año,orden.fecha_creacion,orden.fecha_terminacion,orden.cant_prog,orden.kilos,orden.costo_estandar_prog,orden.costo_estandar_prod," &
                                    "((orden.costo_estandar_prog-isnull(orden.costo_estandar_prod,0)) - ((orden.cant_prog-isnull(orden.kilos,0)) * (select costo_mat_prima from j_orden_prod_tef where consecutivo=orden.consecutivo))) as costo_variacion" &
                                        ",orden.nombres As cliente,orden.origenDesc As origen,orden.calidad,orden.diametro,orden.materia_prima,orden.turno,orden.numPasos,(select velocidad from CORSAN.dbo.J_control_vel_maq where id_tref=orden.id_maquina and codigo=orden.prod_final) as vel_esp,orden.notas,orden.notas_liquidacion,orden.oculto  " &
                                        "FROM J_v_ordenes_prod orden " & WhereFec & WhereCliExt & whereMaquina & whereOculto & " order by número asc"

        dt = obj_Ing_prodLn.listar_datatable(sql, "PRODUCCION")

        dtg_consulta.DataSource = dt

        If (usuario <> "operario") Then
            dtg_consulta.Columns("oculto").Visible = False
            dtg_consulta.Columns("prod_final").DefaultCellStyle = formatoNegrita()
            dtg_consulta.Columns("fecha_creacion").DefaultCellStyle.Format = "dd/MM/yyyy"
            dtg_consulta.Columns("fecha_terminacion").DefaultCellStyle.Format = "dd/MM/yyyy"
        End If
        For i = 0 To dtg_consulta.RowCount - 1
            If Not (IsDBNull(dtg_consulta.Item("cant_prog", i).Value) Or IsDBNull(dtg_consulta.Item("kilos", i).Value)) Then
                If (dtg_consulta.Item("kilos", i).Value >= dtg_consulta.Item("cant_prog", i).Value) Then
                    dtg_consulta.Rows(i).DefaultCellStyle.BackColor = Color.Red
                    cont_C = cont_C + 1
                End If
            End If
            If Not IsDBNull(dtg_consulta.Item("oculto", i).Value) Then
                If (dtg_consulta.Item("oculto", i).Value = 1) Then
                    dtg_consulta.Item(col_oculto.Name, i).Value = Spic.My.Resources.ok3
                End If
            End If
            cont_S = cont_S + 1
        Next
        If dtg_consulta.Rows.Count > 0 Then
            porce_cum = (cont_C / cont_S) * 100
            porcen_header.Text = "El % cumplido es de:" & CInt(porce_cum)
        End If
        lbl_cumplidas.Text = "El total de ordenes cumplidas es:" & cont_C & ",de un total de:" & cont_S
        dtg_consulta.DataSource = totalizar_Admin()
        calcuPorcen()
        pintartotal()
        dtg_consulta.AutoResizeColumns()
    End Sub

    Private Function totalizar_Admin()
        Dim cant_prog As Double = 0
        Dim kilos As Double = 0
        Dim costo_prod As Double
        Dim costo_prog As Double
        Dim costo_variacion As Double
        Dim indice As Integer = 0
        Dim dt As DataTable = DirectCast(dtg_consulta.DataSource, DataTable)
        For Each row As DataRow In dt.Rows
            If row.Item("cant_prog") > 0 Then
                cant_prog += row.Item("cant_prog")
            End If
            If IsDBNull(row.Item("kilos")) = False Then
                If row.Item("kilos") > 0 Then
                    kilos += row.Item("kilos")
                End If
            End If
            If IsDBNull(row.Item("costo_estandar_prog")) = False Then
                If row.Item("costo_estandar_prog") > 0 Then
                    costo_prog += row.Item("costo_estandar_prog")
                End If
            End If
            If IsDBNull(row.Item("costo_estandar_prod")) = False Then
                If row.Item("costo_estandar_prod") > 0 Then
                    costo_prod += row.Item("costo_estandar_prod")
                End If
            End If
            If IsDBNull(row.Item("costo_variacion")) = False Then
                If row.Item("costo_variacion") > 0 Then
                    costo_variacion += row.Item("costo_variacion")
                End If
            End If
            If indice = (dt.Rows.Count - 1) Then
                dt.Rows.Add()
                dt.Rows(dt.Rows.Count - 1).Item("maquina") = "TOTAL"
                dt.Rows(dt.Rows.Count - 1).Item("cant_prog") = cant_prog
                dt.Rows(dt.Rows.Count - 1).Item("kilos") = kilos
                dt.Rows(dt.Rows.Count - 1).Item("costo_estandar_prog") = costo_prog
                dt.Rows(dt.Rows.Count - 1).Item("costo_estandar_prod") = costo_prod
                dt.Rows(dt.Rows.Count - 1).Item("costo_variacion") = costo_variacion
                Exit For
            End If
            indice += 1
        Next
        Return dt
    End Function
    Public Sub pintartotal()
        If dtg_consulta.Rows.Count > 0 Then
            dtg_consulta.Rows(dtg_consulta.Rows.Count - 1).DefaultCellStyle.BackColor = Color.Salmon
            dtg_consulta.Rows(dtg_consulta.Rows.Count - 1).DefaultCellStyle.Font = New Font(dtg_consulta.CurrentCell.InheritedStyle.Font, FontStyle.Bold)
        End If
    End Sub
    Private Sub calcuPorcen()
        For Each row As DataGridViewRow In dtg_consulta.Rows
            Dim ppto_kilos As Double = row.Cells.Item("cant_prog").Value
            Dim kilos As Double
            If IsDBNull(row.Cells.Item("kilos").Value) Then
                kilos = 0
            Else
                kilos = row.Cells.Item("kilos").Value
            End If
            Dim convert As String
            Dim porcentaje As Double

            porcentaje = ((kilos * 100) / ppto_kilos)
            'row.DataGridView.Rows(row.Index).DefaultCellStyle.BackColor = Color.Tomato
            'If (porcentaje >= 90 And porcentaje <= 300) Then
            '    row.DataGridView.Rows(row.Index).DefaultCellStyle.BackColor = Color.SpringGreen
            'End If
            'If (porcentaje < 90 And porcentaje >= 50) Then
            '    row.DataGridView.Rows(row.Index).DefaultCellStyle.BackColor = Color.PaleGreen
            'End If
            'If (porcentaje < 50 And porcentaje >= 0) Then
            '    row.DataGridView.Rows(row.Index).DefaultCellStyle.BackColor = Color.Salmon
            'End If
            convert = porcentaje.ToString("0")
            row.Cells.Item("col_porcen").Value = convert & " %"
            If row.Index = (dtg_consulta.Rows.Count - 1) Then
                Exit For
            End If
        Next
    End Sub
    Private Sub permiso_aux()
        If permiso = "AUXILIAR" Then
            cbo_maquina.Enabled = True
            cboCliente.Enabled = True
            cboOrigen.Enabled = True
            cboCalidad.Enabled = True
            txtCantProg.Enabled = True
            txtProdFinal.Enabled = True
            btn_cliente.Enabled = True
        End If
    End Sub
    Private Sub cargarDatos()
        cbo_operario.SelectedValue = 0
        cboAuxiliar.SelectedValue = 0
        Dim sql As String = "SELECT prod_final,diam_min,diam_max,cant_prog,diametro,nit,origen,materia_prima,trac_ini,trac_fin,numPasos,calidad,tipoCliente,id_maquina,mes,ano,notas,cod_alambron,fecha_creacion " &
                              "FROM J_v_ordenes_prod WHERE consecutivo = " & consecutivoPpal
        Dim lista As New List(Of Object)
        Dim tam As Integer = 19
        lista = obj_Ing_prodLn.listaForm(consecutivoPpal, tam, sql)
        If (lista.Count > 0) Then
            If (lista(12) = 1) Then
                chkInterno.Checked = True
            Else
                chkInterno.Checked = False
            End If
            txtProdFinal.Text = lista(0)
            txtDiaMin.Text = lista(1)
            txtDiamMAx.Text = lista(2)
            txtCantProg.Text = lista(3)
            txtDiametro.Text = lista(4)
            cboCliente.SelectedValue = lista(5)
            cboOrigen.SelectedValue = lista(6)
            txtMatPrima.Text = lista(7)
            txtTracMin.Text = lista(8)
            txtTracMax.Text = lista(9)
            cboCalidad.Text = lista(11)
            cbo_maquina.SelectedValue = lista(13)
            cboNumPasos.Text = lista(10)
            If IsDBNull(lista(18)) = False Then
                cbo_fec_orden.Value = lista(18)
            End If
            If Not IsDBNull(lista(16)) Then
                txtNotas.Text = lista(16)
            End If
            If Not IsDBNull(lista(17)) Then
                txt_cod_alambron.Text = lista(17)
            Else
                txt_cod_alambron.Text = 0
            End If
            ActCantPend()
        End If
    End Sub
    Private Sub cargarDtgAsociado(ByVal criterio As String)
        Dim whereSql As String = "WHERE anulado is null AND  turno.Codigo = prod.id_turno AND  prod.operario = ter.nit And prod.cod_orden = " & consecutivoPpal
        Dim sql As String = ""
        If (criterio <> "TODOS") Then
            whereSql = whereSql & " AND prod.id_detalle = " & Me.consecutivoDet
        End If
        sql = "SELECT prod.id_detalle As #,turno.descripcion As turno, " &
                    "(SELECT CASE " &
                      "WHEN DATEPART(dw,prod.fecha_prod ) = 1 " &
                       "then 'Domingo' " &
                      "WHEN DATEPART(dw,fecha_prod ) = 2  " &
                       "then 'Lunes'  " &
                      "WHEN DATEPART(dw,fecha_prod ) = 3 " &
                      " Then 'Martes' " &
                      "WHEN DATEPART(dw,fecha_prod ) = 4 " &
                       "then 'Miercoles' " &
                      "WHEN DATEPART(dw,fecha_prod ) = 5 " &
                       "then 'Jueves' " &
                     " WHEN DATEPART(dw,fecha_prod ) = 6 " &
                    "   then 'Viernes' " &
                      "WHEN DATEPART(dw,fecha_prod ) = 7 " &
                       "then 'Sabado' " &
                    "END) as día,  " &
                        "(SELECT SUM (peso) FROM J_rollos_tref rollo WHERE rollo.anulado  is null AND rollo.manuales is null  AND rollo.id_detalle = prod.id_detalle AND rollo.cod_orden = " & consecutivoPpal & "  )As kilos, " &
                                        "prod.velocidad AS vel,prod.fecha_prod AS fecha,ter.nombres As operario,ter.nit,(SELECT nombres FROM CORSAN.dbo.V_nom_personal_Activo_con_maquila ter WHERE nit = prod.auxiliar )As Auxiliar,prod.cerrado " &
               "FROM J_det_orden_prod prod,CORSAN.dbo.V_nom_personal_Activo_con_maquila_Todos ter, J_turnos turno " &
                     whereSql &
                          "  GROUP BY prod.id_detalle,ter.nombres,turno.descripcion,prod.fecha_prod,prod.velocidad ,prod.fecha_prod,prod.auxiliar,prod.cerrado,ter.nit " &
                                    "ORDER BY id_detalle desc"
        dtgPlanAsociadas.DataSource = obj_Ing_prodLn.listar_datatable(sql, "PRODUCCION")
        dtgPlanAsociadas.Columns("#").DefaultCellStyle.Format = "N0"
        dtgPlanAsociadas.Columns("kilos").DefaultCellStyle.Format = "N0"
        dtgPlanAsociadas.Columns("fecha").DefaultCellStyle.Format = "d"
        dtgPlanAsociadas.Columns("#").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        dtgPlanAsociadas.Columns("#").Width = 30
        dtgPlanAsociadas.Columns("vel").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        dtgPlanAsociadas.Columns("vel").Width = 25
        dtgPlanAsociadas.Columns("kilos").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        dtgPlanAsociadas.Columns("kilos").Width = 50
        dtgPlanAsociadas.Columns("turno").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        dtgPlanAsociadas.Columns("turno").Width = 60
        dtgPlanAsociadas.Columns("cerrado").Visible = False
        dtgPlanAsociadas.Columns("nit").Visible = False
        pintarPlanNoCerradas()
    End Sub

    Private Function verificarPlanillaTerminada(ByVal cod_orden As Double, ByVal id_detalle As Integer) As Boolean
        Dim sql As String = "SELECT * FROM J_det_orden_prod  WHERE cod_orden = " & cod_orden & " AND id_detalle =" & id_detalle & "  AND cerrado is not null"
        If obj_Ing_prodLn.consultValor(sql, "PRODUCCION") = "" Then
            Return True
        Else
            Return True
        End If
    End Function
    Private Sub cargarHileras()
        cargaComp = False
        For i = 0 To dtgDiametros.RowCount - 1
            For j = 0 To 3
                dtgDiametros.Item("colCamHil" & j + 1, i).Value = ""
            Next
        Next
        Dim sql As String = "SELECT numPaso,cambio1,cambio2,cambio3,cambio4 " &
                                "FROM J_cambio_hilera  " &
                          "WHERE cod_det = " & consecutivoDet & "AND cod_orden=" & consecutivoPpal
        Dim listPpal As New List(Of Object)
        Dim list As New List(Of Object)
        Dim numPaso As Integer = 0
        listPpal = objOpsimpesLn.listaOfListas(sql, "PRODUCCION", 4)
        limpiarDtgDiam()
        For i = 0 To listPpal.Count - 1
            list = New List(Of Object)
            list = listPpal(i)
            If (list.Count - 1 <> 0) Then
                For j = 0 To list.Count - 2
                    If (list(j + 1).ToString <> "") Then
                        dtgDiametros.Item("colCamHil" & j + 1, list(0) - 1).Value = list(j + 1)
                        calc_poc_reduccion(list(0) - 1, dtgDiametros.Columns("colCamHil" & j + 1).Index)
                    End If
                Next
            End If
        Next

        cargaComp = True
    End Sub
    Private Sub limpiarDtgDiam()
        For i = 0 To 3
            For j = 0 To dtgDiametros.RowCount - 1
                dtgDiametros.Item("col_porc_c" & i + 1, j).Value = ""
            Next
        Next
    End Sub
    Private Sub nuevo()
        dtgProduccion.DataSource = Nothing
        dtgDiametros.DataSource = Nothing
        dtgParo.DataSource = Nothing
        dtgPlanInsp.DataSource = Nothing
        dtg_Inp_Calidad.DataSource = Nothing
        txtProdFinal.Text = ""
        txtDiaMin.Text = ""
        txtDiamMAx.Text = ""
        txtCantProg.Text = ""
        txtDiametro.Text = ""
        txt_cod_alambron.Text = ""
        cboOrigen.Text = "Seleccione"
        cboCliente.Text = "Seleccione"
        txtMatPrima.Text = ""
        txtTracMin.Text = ""
        txtTracMax.Text = ""
        cboNumPasos.Text = "Seleccione"
        cboCalidad.Text = "Seleccione"
        cbo_maquina.Text = "Seleccione"
        txtCantPendOp.Text = ""
        txtCantPendOrden.Text = ""
        txtHoraIni.Text = ""
        txtHoraFin.Text = ""
        txtHorometroIni.Text = ""
        txtHorometroFin.Text = ""
        txt_amarres.Text = ""
        txt_no_conforme.Text = ""
        txtNumRollos.Text = ""
        txtCantTurno.Text = ""
        txtCantPendOp.Text = ""
        btnIniciaPara.Enabled = False
        cboVel.SelectedValue = "Seleccione"
        If (usuario <> "operario") Then
            bloquearPlanPpal(True)
        End If
        cboCliente.Enabled = False
        'Variables para la orden de Recocido
        mat_prima_rec = ""
        val = 0
        orden_tiq_rec = 0
    End Sub
    'Planilla del operario
    Private Sub cargarTblProdOp(ByVal idConsecDet As Double)
        colCod.ReadOnly = False
        dtgProduccion.Rows.Clear()
        contAlertPlanInspAl = 0
        actualizarConsecutivoDet(idConsecDet)
        dtgProduccion.Rows.Clear()
        txtHorometroIni.Text = ""
        txtHorometroIni.Text = ""
        txtHoraIni.Text = ""
        txtHoraFin.Text = ""
        txtCantTurno.Text = "0"
        txtCantPendOp.Text = "0"
        txt_link_lector_mp2.Text = ""
        Dim sql As String = "SELECT R.id_rollo,R.peso,R.colada,R.traccion,R.numOrdPdnMp,R.numRolloPdn,O.diam_min,R.anulado,R.motivo,R.fecha_hora,R.no_conforme  " &
                          "FROM J_rollos_tref  R , J_orden_prod_tef O " &
                              "WHERE R.manuales is null  AND R.cod_orden = O.consecutivo  AND R.id_detalle = " & consecutivoDet & " AND R.cod_orden= " & consecutivoPpal & " ORDER BY R.id_rollo"
        Dim cantCol As Integer = 10
        Dim listPpal As New List(Of Object)
        Dim listDtg As New List(Of Object)
        Dim listPlanilla As New List(Of Object)
        listPpal = objOpsimpesLn.listaOfListas(sql, "PRODUCCION", cantCol)
        For i = 0 To listPpal.Count - 1
            listDtg = New List(Of Object)
            listDtg = listPpal(i)
            If (listDtg.Count - 1 <> 0) Then
                txt_amarres.Enabled = True
                txt_no_conforme.Enabled = True
                dtgProduccion.Rows.Add()
                dtgProduccion.Item("colRollo", i).Value = listDtg(0)
                dtgProduccion.Item("colKg", i).Value = listDtg(1)
                dtgProduccion.Item("colColada", i).Value = listDtg(2)
                dtgProduccion.Item("colTraccion", i).Value = listDtg(3)
                dtgProduccion.Item("colOrdenPDN", i).Value = listDtg(4)
                dtgProduccion.Item("colNroRolloF", i).Value = listDtg(5)
                dtgProduccion.Item(colCalibre.Name, i).Value = listDtg(6)
                If Not IsDBNull(listDtg(8)) Then
                    dtgProduccion.Item(col_notas_audit.Name, i).Value = listDtg(8)
                End If
                If Not IsDBNull(listDtg(9)) Then
                    dtgProduccion.Item("col_fecha_horas", i).Value = listDtg(9)
                End If
                If Not IsDBNull(listDtg(7)) Then
                    If (listDtg(7) = "1") Then
                        dtgProduccion.Item(colAnulado.Name, i).Value = listDtg(7)
                        dtgProduccion.Rows(i).DefaultCellStyle.BackColor = Color.Red
                        dtgProduccion.Item("colColada", i).Value = "ANULADO"

                    Else
                        dtgProduccion.Item(colAnulado.Name, i).Value = ""
                    End If
                Else
                    dtgProduccion.Item(colAnulado.Name, i).Value = ""
                End If
                If Not IsDBNull(listDtg(10)) Then
                    If (listDtg(10) = "S") Then
                        dtgProduccion.Item(col_no_conforme.Name, i).Value = listDtg(10)
                        dtgProduccion.Rows(i).DefaultCellStyle.BackColor = Color.Yellow
                        dtgProduccion.Item("colColada", i).Value = "No conforme"

                    Else
                        dtgProduccion.Item(col_no_conforme.Name, i).Value = ""
                    End If
                Else
                    dtgProduccion.Item(col_no_conforme.Name, i).Value = ""
                End If
                dtgProduccion.Item("colImprimir", i).Value = My.Resources.ok3
                dtgProduccion.Item("txtGuardado", i).Value = 1
                habilitar_lectorMp()
            End If
        Next

        dtgProduccion.Rows.Add()
        If (dtgProduccion.RowCount > 1) Then
            dtgProduccion.Item("colRollo", dtgProduccion.RowCount - 1).Value = dtgProduccion.Item("colRollo", dtgProduccion.RowCount - 2).Value + 1
            If (dtgProduccion.Item(colAnulado.Name, dtgProduccion.RowCount - 2).Value <> "1" And dtgProduccion.Item(col_no_conforme.Name, dtgProduccion.RowCount - 2).Value <> "S") Then
                copiarDatosRollo(dtgProduccion.RowCount - 2)
            End If
        Else
            dtgProduccion.Item("colRollo", 0).Value = 1
        End If

        sql = "SELECT hIni,Hfin,operario,fecha_prod,id_turno,velocidad,notas,auxiliar,horometroIni,HorometroFin,amarres,desperdicio " &
                "FROM J_det_orden_prod  " &
                     "WHERE id_detalle = " & idConsecDet & " AND cod_orden=" & consecutivoPpal
        listPlanilla = objOpsimpesLn.listaBasesDatos(sql, "PRODUCCION", 11)
        If (listPlanilla.Count > 0) Then
            habilitar_lectorMp()
            txt_amarres.Enabled = True
            txt_no_conforme.Enabled = True
            If (IsDBNull(listPlanilla(0))) Then
                txtHoraIni.Text = 0
            Else

                txtHoraIni.Text = listPlanilla(0).ToString
                estadoTurno = True
                btnIniciaPara.Image = Spic.My.Resources._stop
                btnIniciaPara.Text = "Terminar planilla"
                dtgParo.Enabled = True
                dtgProduccion.Enabled = True
            End If
            If (IsDBNull(listPlanilla(1))) Then
                txtHoraFin.Text = 0
            Else
                txtHoraFin.Text = listPlanilla(1).ToString
                estadoTurno = False
                btnIniciaPara.Image = Spic.My.Resources.comienza
                btnIniciaPara.Text = "Iniciar planilla"
                dtgParo.Enabled = False
                dtgProduccion.Enabled = False
            End If
            If (usuario = "operario") Then
                cboVel.Enabled = True
                If (txtHoraFin.Text = "0" And txtHoraIni.Text = "0") Then
                    estadoTurno = False
                    btnIniciaPara.Image = Spic.My.Resources.comienza
                    btnIniciaPara.Text = "Iniciar planilla"
                    dtgParo.Enabled = False
                    dtgProduccion.Enabled = False
                    dtgProduccion.Columns("col_fecha_horas").ReadOnly = False
                    dtgProduccion.Columns("col_fecha_horas").Visible = False
                End If
                dtgProduccion.Columns("col_fecha_horas").Visible = False
            Else
                dtgProduccion.Columns("colImprimir").Visible = False
                dtgProduccion.Columns("btnAnular").Visible = False
                dtgProduccion.Columns("btn_no_conforme").Visible = False
                dtgProduccion.Columns("colVer").Visible = False
                dtgProduccion.Columns("colLimpiar").Visible = False
                dtgParo.Columns("btnInicioFin").Visible = False
                dtgParo.Columns("btnBorrar").Visible = False
                dtgParo.Columns("colAdd").Visible = False
                dtgParo.Enabled = True
                dtgProduccion.Enabled = True
            End If
            cbo_operario.SelectedValue = listPlanilla(2)
            If (listPlanilla(5).ToString = "") Then
                cboVel.SelectedValue = "Seleccione"
            Else
                cboVel.Enabled = True
                cboVel.Text = Format(listPlanilla(5), "##,##0.00")
                cboVel.Enabled = False
            End If

            txtNotas.Text = listPlanilla(6)
            txtNotasOperarios.Text = listPlanilla(6)
            cboAuxiliar.SelectedValue = listPlanilla(7)
            cboTurno.SelectedValue = listPlanilla(4)
            If (IsDBNull(listPlanilla(8))) Then
                txtHorometroIni.Text = "0"
            Else
                txtHorometroIni.Text = listPlanilla(8)
            End If
            If (IsDBNull(listPlanilla(9))) Then
                txtHorometroFin.Text = "0"
            Else
                txtHorometroFin.Text = listPlanilla(9)
            End If
            If (IsDBNull(listPlanilla(10))) Then
                txt_amarres.Text = "0"
            Else
                txt_amarres.Text = listPlanilla(10)
            End If
            If (IsDBNull(listPlanilla(11))) Then
                txt_no_conforme.Text = "0"
            Else
                txt_no_conforme.Text = listPlanilla(11)
            End If
        End If

        txtCantTurno.Text = sumarProdTotal().ToString("N1")
        cargarHileras()
        CargarParos(idConsecDet)
        contarRollos()
        consultarEstadoMaq()
        'cargarPlanInsp()
        cargarPlanInspCal()
        listar_rollos_alamrbon()
        actualizar_mp()
        Me.Text += " " & cbo_operario.Text
        Me.Text = " " & cbo_maquina.Text & "-" & Me.Text
    End Sub
    Private Sub CargarParos(ByVal consecDet As String)
        dtgParo.Rows.Clear()
        For i = 0 To 11
            dtgParo.Rows.Add()
        Next
        Dim list As New List(Of Object)
        Dim numCol As Integer = 12
        Dim j As Integer = 0
        Dim sql As String = "SELECT paro0,paro1,paro2,paro3,paro4,paro5,paro6,paro7,paro8,paro9,paro10,paro11,paro12 " &
                            "FROM J_det_orden_prod  " &
                      "WHERE cod_orden = " & consecutivoPpal & " AND  id_detalle = " & consecDet & " AND (paro0 is not null or paro1 is not null or  paro2 is not null or  paro3 is not null or  paro4 is not null  or  paro5 is not null or  paro6 is not null or  paro7 is not null or  paro8 is not null or  paro9 is not null or  paro10 is not null or  paro11 is not null or  paro12 is not null )"

        list = obj_Ing_prodLn.listaRegistro(sql, "PRODUCCION", numCol)
        For i = 0 To list.Count - 1
            If Not (IsDBNull(list(i)) Or list(i).ToString = "0") Then
                ComboCell_Select(j, dtgParo.Columns("colCod").Index, dtgParo, i + 1) 'Se coloca i+1 por que i es el numero real del paro e i+1 en el combox es el index de ese paro
                dtgParo.Item("colTotal", j).Value = list(i)
                dtgParo.Item("btnInicioFin", j).Value = My.Resources.Candado
                dtgParo.Item("colCod", j).ReadOnly = True
                dtgParo.Item("btnInicioFin", j).ReadOnly = True
                j += 1
            End If
        Next
    End Sub
    Private Sub ComboCell_Select(ByVal dgvRow As Integer,
                              ByVal dgvCol As Int16,
                              ByRef DGV As DataGridView,
                              ByRef nComboBoxRow As Int16)

        Try
            Dim CBox As DataGridViewComboBoxCell = CType(DGV.Rows(dgvRow).Cells(dgvCol), DataGridViewComboBoxCell)
            Dim CCol As DataGridViewComboBoxColumn = CType(DGV.Columns(dgvCol), DataGridViewComboBoxColumn)

            CBox.Value = CCol.Items(nComboBoxRow)
            DGV.UpdateCellValue(dgvCol, dgvRow)

            'MessageBox.Show("New value in the combo box = " + CBox.Value.ToString)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Function sumarProdTotal() As Double
        Dim sum As Double = 0
        For i = 0 To dtgProduccion.RowCount - 2
            If (dtgProduccion.Item("colKg", i).Value.ToString <> "" And dtgProduccion.Item(colAnulado.Name, i).Value.ToString = "") Then
                sum += dtgProduccion.Item("colKg", i).Value
            End If
        Next
        Return sum
    End Function
    Private Function sumarProdTotal_d() As Double
        Dim sum As Double = 0
        Dim sql As String = "SELECT sum(peso) as peso FROM J_ROLLOS_TREF  WHERE cod_orden = " & cod_orden_sum & " and id_detalle = " & id_detalle_sum & " and anulado is null and manuales is null  and peso>0"
        sum = obj_Ing_prodLn.consultar_valor(sql, "PRODUCCION")
        Return sum
    End Function
    Private Sub cargarDataSourse()
        Dim sql As String = "SELECT Codigo,Descripcion FROM J_turnos WHERE codigo in (1,2,3)  "
        Dim dt As New DataTable
        Dim row As DataRow
        dt = obj_Ing_prodLn.listar_datatable(sql, "PRODUCCION")
        row = dt.NewRow
        row("Codigo") = 0
        row("Descripcion") = "Seleccione"
        dt.Rows.Add(row)
        cboTurno.DataSource = dt
        cboTurno.ValueMember = "Codigo"
        cboTurno.DisplayMember = "Descripcion"
        cboTurno.SelectedValue = 0

        sql = "Select nit,nombres  from V_nom_personal_Activo_con_maquila WHERE  nit in (select nit from control.dbo.D_empleados_sin_salida) and centro_planta IN( 2100 ,200) ORDER BY nombres "

        dt = New DataTable
        dt = obj_Ing_prodLn.listar_datatable(sql, "CORSAN")
        row = dt.NewRow
        row("nit") = 0
        row("nombres") = "Seleccione"
        dt.Rows.Add(row)
        cboAuxiliar.DataSource = dt
        cboAuxiliar.ValueMember = "nit"
        cboAuxiliar.DisplayMember = "nombres"
        cboAuxiliar.Text = "Seleccione"
        cboAuxiliar.SelectedValue = 0

        sql = "Select nit,nombres  from V_nom_personal_Activo_con_maquila WHERE nit in (select nit from control.dbo.D_empleados_sin_salida) and (centro_planta IN( 2100 ,200) or centro_planta is null) ORDER BY nombres"

        dt = New DataTable
        dt = obj_Ing_prodLn.listar_datatable(sql, "CORSAN")
        row = dt.NewRow
        row("nit") = 0
        row("nombres") = "Seleccione"
        dt.Rows.Add(row)
        cbo_operario.DataSource = dt
        cbo_operario.ValueMember = "nit"
        cbo_operario.DisplayMember = "nombres"
        cbo_operario.Text = "Seleccione"
        cbo_operario.SelectedValue = 0

        sql = "Select nit,nombres  from V_nom_personal_Activo_con_maquila WHERE nit in (select nit from control.dbo.D_empleados_sin_salida) and  centro_planta IN( 2100 ,200) ORDER BY nombres"
        dt = New DataTable
        dt = obj_Ing_prodLn.listar_datatable(sql, "CORSAN")
        row = dt.NewRow
        row("nit") = 0
        row("nombres") = "Seleccione"
        dt.Rows.Add(row)
        cboOperariosTurno.DataSource = dt
        cboOperariosTurno.ValueMember = "nit"
        cboOperariosTurno.DisplayMember = "nombres"
        cboOperariosTurno.Text = "Seleccione"
        cboOperariosTurno.SelectedValue = 0

        sql = "SELECT nit, nombres FROM terceros WHERE vendedor >=1001 AND vendedor <= 1099 ORDER BY nombres "
        dtTerceros = New DataTable
        dtTerceros = obj_Ing_prodLn.listar_datatable(sql, "CORSAN")
        row = dtTerceros.NewRow
        row("nit") = 0
        row("nombres") = "Seleccione"
        dtTerceros.Rows.Add(row)
        cboCliente.DataSource = dtTerceros
        cboCliente.ValueMember = "nit"
        cboCliente.DisplayMember = "nombres"
        cboCliente.Text = "Seleccione"
        cboCliente.SelectedValue = 0

        sql = "Select nit,nombres  from Jjv_prov_alambron  "
        dt = New DataTable
        dt = obj_Ing_prodLn.listar_datatable(sql, "CORSAN")
        row = dt.NewRow
        row("nit") = 0
        row("nombres") = "Seleccione"
        dt.Rows.Add(row)
        cboOrigen.DataSource = dt
        cboOrigen.ValueMember = "nit"
        cboOrigen.DisplayMember = "nombres"
        cboOrigen.Text = "Seleccione"
        cboOrigen.SelectedValue = 0

        sql = "select  codigoM,nombre   from j_Maquinas where TipoMaquina = 1 AND activa = 1 "
        dt = New DataTable
        dt = obj_Ing_prodLn.listar_datatable(sql, "PRODUCCION")
        row = dt.NewRow
        row("codigoM") = 0
        row("nombre") = "Seleccione"
        dt.Rows.Add(row)
        cbo_maquina.DataSource = dt
        cbo_maquina.ValueMember = "codigoM"
        cbo_maquina.DisplayMember = "nombre"
        cbo_maquina.Text = "Seleccione"
        cbo_maquina.SelectedValue = 0

        sql = "select  codigoM,nombre   from j_Maquinas where TipoMaquina = 1 AND activa = 1 "
        dt = New DataTable
        dt = obj_Ing_prodLn.listar_datatable(sql, "PRODUCCION")
        row = dt.NewRow
        row("codigoM") = 0
        row("nombre") = "Seleccione"
        dt.Rows.Add(row)
        cboMaquinaFiltro.DataSource = dt
        cboMaquinaFiltro.ValueMember = "codigoM"
        cboMaquinaFiltro.DisplayMember = "nombre"
        cboMaquinaFiltro.Text = "Seleccione"
        cboMaquinaFiltro.SelectedValue = 0


        sql = "select  codigoM,nombre   from j_Maquinas where TipoMaquina = 1 AND activa = 1 "
        dt = New DataTable
        dt = obj_Ing_prodLn.listar_datatable(sql, "PRODUCCION")
        row = dt.NewRow
        row("codigoM") = 0
        row("nombre") = "Seleccione"
        dt.Rows.Add(row)
        cboMaquinaConsulta.DataSource = dt
        cboMaquinaConsulta.ValueMember = "codigoM"
        cboMaquinaConsulta.DisplayMember = "nombre"
        cboMaquinaConsulta.SelectedValue = 0

        sql = "Select tipo_calidad from J_tipo_cal_alambre "

        cboCalidad.DataSource = obj_Ing_prodLn.listar_datatable(sql, "PRODUCCION")
        cboCalidad.ValueMember = "tipo_calidad"
        cboCalidad.DisplayMember = "tipo_calidad"
        cboCalidad.Text = "Seleccione"
        cboCalidad.SelectedValue = 0

        For i = 0 To 9
            dtgParo.Rows.Add()
        Next
        cboMesConsulta.DataSource = objOpsimpesLn.returnDtMeses()
        cboMesConsulta.ValueMember = "numMes"
        cboMesConsulta.DisplayMember = "nombMes"
        cboMesConsulta.SelectedValue = Now.Month

        For i = Now.Year - 1 To Now.Year + 1
            cboAnoConsulta.Items.Add(i)
        Next
        cboAnoConsulta.Text = Now.Year
        dt = New DataTable
        sql = "SELECT d.Id_defecto,d.D_defecto " &
                        " FROM J_desperdicios_defecto d , J_desperdicio_def_centro c " &
                            "WHERE d.id_defecto = c.id_defecto AND c.centro =" & centro
        dt = objOpsimpesLn.listar_datatable(sql, "PRODUCCION")
        row = dt.NewRow
        row("Id_defecto") = 0
        row("D_defecto") = "TODO"
        dt.Rows.Add(row)
        cbo_defecto.DataSource = dt
        cbo_defecto.ValueMember = "Id_defecto"
        cbo_defecto.DisplayMember = "D_defecto"
        cbo_defecto.SelectedValue = 0
        cboFechaIni.Value = Today
        cboFechaFin.Value = Today
    End Sub
    Private Sub actualizar_operarios()
        Dim sql As String
        Dim value As Double = cboOperariosTurno.SelectedValue
        Dim dt As New DataTable
        Dim row As DataRow
        sql = "Select nit,nombres  from V_nom_personal_Activo_con_maquila WHERE nit in (select nit from control.dbo.D_empleados_sin_salida) and (centro_planta IN( 2100 ,200) or centro_planta is null) ORDER BY nombres"
        dt = New DataTable
        dt = obj_Ing_prodLn.listar_datatable(sql, "CORSAN")
        row = dt.NewRow
        row("nit") = 0
        row("nombres") = "Seleccione"
        dt.Rows.Add(row)
        cboOperariosTurno.DataSource = dt
        cboOperariosTurno.ValueMember = "nit"
        cboOperariosTurno.DisplayMember = "nombres"
        cboOperariosTurno.Text = "Seleccione"
        cboOperariosTurno.SelectedValue = value

        value = cbo_operario.SelectedValue
        sql = "Select nit,nombres  from V_nom_personal_Activo_con_maquila WHERE nit in (select nit from control.dbo.D_empleados_sin_salida) and (centro_planta IN( 2100 ,200) or centro_planta is null) ORDER BY nombres"

        dt = New DataTable
        dt = obj_Ing_prodLn.listar_datatable(sql, "CORSAN")
        row = dt.NewRow
        row("nit") = 0
        row("nombres") = "Seleccione"
        dt.Rows.Add(row)
        cbo_operario.DataSource = dt
        cbo_operario.ValueMember = "nit"
        cbo_operario.DisplayMember = "nombres"
        cbo_operario.Text = "Seleccione"
        cbo_operario.SelectedValue = value

        value = cboAuxiliar.SelectedValue
        sql = "Select nit,nombres  from V_nom_personal_Activo_con_maquila WHERE  nit in (select nit from control.dbo.D_empleados_sin_salida) and centro_planta IN( 2100 ,200) ORDER BY nombres "

        dt = New DataTable
        dt = obj_Ing_prodLn.listar_datatable(sql, "CORSAN")
        row = dt.NewRow
        row("nit") = 0
        row("nombres") = "Seleccione"
        dt.Rows.Add(row)
        cboAuxiliar.DataSource = dt
        cboAuxiliar.ValueMember = "nit"
        cboAuxiliar.DisplayMember = "nombres"
        cboAuxiliar.Text = "Seleccione"
        cboAuxiliar.SelectedValue = value
    End Sub
    Private Sub imprimirTiquete(ByVal peso As String, ByVal numRollo As Integer, ByVal calibre As String, ByVal calidad As Double, ByVal nombOperario As String, ByVal fecha As String, ByVal producto As String, ByVal destino As String, ByVal colada As String, ByVal cod_mat_prima As String, ByVal traccion As String)
        Dim proc As New Process
        'If producto.ToUpper = "22B100142" Then
        '    producto = "33R100142"
        '    destino = "Externo"
        'ElseIf producto.ToUpper = "22B100125" Then
        '    producto = "33R100142P"
        '    destino = "Externo"
        'End If

        If producto.ToUpper = "22B100142" Or producto.ToUpper = "22B100125" Then
            modificarPlantillaCons(peso, fecha, producto, numRollo)
        Else
            modificarPlantilla(nombOperario, calidad, calibre, peso, fecha, producto, numRollo, destino, colada, cod_mat_prima, traccion)
        End If
        'modificarPlantilla(nombOperario, calidad, calibre, peso, fecha, producto, numRollo, destino, colada, cod_mat_prima, traccion)
        proc.StartInfo.FileName = Environment.CurrentDirectory & "\nuevaPlantilla.txt"
        proc.StartInfo.Verb = "Print"
        proc.StartInfo.CreateNoWindow = False
        proc.Start()
    End Sub
    'guardar rollo
    Private Sub GuardarRollo(ByVal peso As String, ByVal numRollo As Integer, ByVal colada As String, ByVal numOrdenPdn As String, ByVal numRolloPdn As String, ByVal traccion As String)

        Dim peso_real As Double = peso
        Dim peso_int As Integer = peso

        Dim diferencia As Double = Format(peso_real - peso_int, "#0.0")
        If diferencia < -0.3 Then
            peso_int -= 1
            diferencia = Format(peso_real - peso_int, "#0.0")
        End If
        Dim sql As String = "INSERT INTO J_rollos_tref (cod_orden,id_rollo,id_detalle,peso,colada,numOrdPdnMp,numRolloPdn,traccion,diferencia,fecha_hora) VALUES (" & consecutivoPpal & "," & numRollo & "," & consecutivoDet & "," & peso_int & ",'" & colada & "','" & numOrdenPdn & "','" & numRolloPdn & "','" & traccion & "'," & diferencia & ",GETDATE())"
        obj_Ing_prodLn.ejecutar(sql, "PRODUCCION")
    End Sub
    Private Function consultar_rollo(ByVal numero_rollo As Integer)
        Dim sql As String
        Dim val As String
        Dim resp As Boolean = True
        sql = "select peso from j_rollos_tref where cod_orden=" & consecutivoPpal & " and id_detalle=" & consecutivoDet & " and id_rollo=" & numero_rollo & ""
        val = objOpsimpesLn.consultValorTodo(sql, "PRODUCCION")
        If val = "" Then
            resp = False
        End If
        Return resp
    End Function
    Private Function capturarPeso_indicador2() As String
        Dim pesoFinal As String = ""
        Dim primerIgual As Boolean = False
        For i = 0 To txtPeso.TextLength - 1
            If (txtPeso.Text(i) = "+" Or primerIgual = True) Then
                If (primerIgual = False) Then
                    i += 1
                    primerIgual = True
                End If
                If (txtPeso.Text(i) <> "+") Then
                    If (txtPeso.Text(i) <> " ") Then
                        If (txtPeso.Text(i) = "0") Then
                            If (pesoFinal.Length > 0) Then
                                pesoFinal += txtPeso.Text(i)
                            End If
                        Else
                            If (txtPeso.Text(i) <> "k") Then
                                If (txtPeso.Text(i) <> "g") Then
                                    If (txtPeso.Text(i) <> "S") Then
                                        If (txtPeso.Text(i) <> "T") Then
                                            If (txtPeso.Text(i) <> ",") Then
                                                If (txtPeso.Text(i) <> "G") Then
                                                    If (txtPeso.Text(i) <> "S") Then
                                                        If (txtPeso.Text(i) <> ",") Then
                                                            If (txtPeso.Text(i) <> "+") Then
                                                                If (txtPeso.Text(i) <> "U") Then
                                                                    If (txtPeso.Text(i) <> "N") Then
                                                                        pesoFinal += txtPeso.Text(i)
                                                                    End If
                                                                End If
                                                            End If
                                                        End If
                                                    End If
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                Else
                    i = txtPeso.TextLength
                End If
            End If
        Next

        If (pesoFinal = "") Then
            Dim primerNumeroNoCero As Boolean = False
            For i = 0 To txtPeso.Text.Length - 1
                If ((txtPeso.Text(i) <> "0" And txtPeso.Text(i) <> " ") Or primerNumeroNoCero = True) Then
                    primerNumeroNoCero = True
                    pesoFinal += txtPeso.Text(i)
                End If
            Next
        End If


        'If (pesoFinal = "") Then
        '    Dim primerNumeroNoCero As Boolean = False
        '    txtNotasOperarios.Text &= "pero en =0"
        '    For i = 0 To txtPeso.Text.Length - 1
        '        If ((txtPeso.Text(i) <> "0" And txtPeso.Text(i) <> " ") Or primerNumeroNoCero = True) Then
        '            primerNumeroNoCero = True
        '            pesoFinal += txtPeso.Text(i)
        '        End If
        '    Next
        '    If Not IsNumeric(pesoFinal) Then
        '        txtNotasOperarios.Text &= "el peso final era vacio ahora no es numerico"
        '    End If
        '    If (txtProdFinal.Text.Length < 3) Then
        '        txtNotasOperarios.Text &= "caracteres menores a 3"
        '        pesoFinal = 1
        '    End If
        'End If

        If IsNumeric(pesoFinal) Then
            If pesoFinal > 0 Then
                txtPeso.Text = pesoFinal
            Else
                txtPeso.Text = ""
            End If
        Else
            txtPeso.Text = ""
        End If
        Return pesoFinal.Trim
    End Function
    Private Function capturarPeso() As String
        Dim pesoFinal As String = ""
        Dim primerIgual As Boolean = False
        For i = 0 To txtPeso.TextLength - 1
            If (txtPeso.Text(i) = "=" Or primerIgual = True) Then
                If (primerIgual = False) Then
                    i += 1
                    primerIgual = True
                End If
                If (txtPeso.Text(i) <> "=") Then
                    If (txtPeso.Text(i) <> "-") Then
                        If (txtPeso.Text(i) <> " ") Then
                            If (txtPeso.Text(i) <> ",") Then
                                If (txtPeso.Text(i) = "0") Then
                                    If (pesoFinal.Length > 0) Then
                                        pesoFinal += txtPeso.Text(i)
                                    End If
                                Else
                                    pesoFinal += txtPeso.Text(i)
                                End If
                            End If
                        End If
                    End If
                Else
                    i = txtPeso.TextLength
                End If
            End If
        Next
        If (pesoFinal = "") Then
            Dim primerNumeroNoCero As Boolean = False
            txtNotasOperarios.Text &= "pero en =0"
            For i = 0 To txtPeso.Text.Length - 1
                If ((txtPeso.Text(i) <> "0" And txtPeso.Text(i) <> " ") Or primerNumeroNoCero = True) Then
                    primerNumeroNoCero = True
                    pesoFinal += txtPeso.Text(i)
                End If
            Next
            If Not IsNumeric(pesoFinal) Then
                txtNotasOperarios.Text &= "el peso final era vacio ahora no es numerico"
            End If
            If (txtProdFinal.Text.Length < 3) Then
                txtNotasOperarios.Text &= "caracteres menores a 3"
                pesoFinal = 1
            End If
        End If
        Return pesoFinal
    End Function

    Private Sub modificarPlantillaCons(ByVal peso As String, ByVal fec As String, ByVal producto As String, ByVal numRollo As Integer)
        Dim fic As String = Environment.CurrentDirectory & "\plantillaconst.txt"
        Dim nuevoFic As String = Environment.CurrentDirectory & "\nuevaPlantilla.txt"
        Dim sw As New System.IO.StreamWriter(nuevoFic)
        Dim texto As String
        Dim sr As New System.IO.StreamReader(fic)
        Dim codOrden As String = consecutivoPpal & "-" & consecutivoDet & "-" & numRollo
        texto = sr.ReadToEnd()
        texto = Replace(texto, "@Peso", peso & " (Kg)")
        texto = Replace(texto, "@Fecha", fec)
        texto = Replace(texto, "@Orden", codOrden)
        texto = Replace(texto, "@CodigoBarras", codOrden)
        texto = Replace(texto, "@Ref", producto)
        sr.Close()
        sw.WriteLine(texto)
        sw.Close()

    End Sub

    Private Sub modificarPlantilla(ByVal operario As String, ByVal clase As String, ByVal calibre As String, ByVal peso As String, ByVal fec As String, ByVal producto As String, ByVal numRollo As Integer, ByVal destino As String, ByVal colada As String, ByVal cod_mat_prima As String, ByVal traccion As String)
        Dim fic As String = Environment.CurrentDirectory & "\plantilla.txt"
        Dim nuevoFic As String = Environment.CurrentDirectory & "\nuevaPlantilla.txt"
        Dim sw As New System.IO.StreamWriter(nuevoFic)
        Dim texto As String
        Dim sr As New System.IO.StreamReader(fic)
        Dim codOrden As String = consecutivoPpal & "-" & consecutivoDet & "-" & numRollo
        texto = sr.ReadToEnd()
        texto = Replace(texto, "@Operario", operario)
        texto = Replace(texto, "@Clase", clase)
        texto = Replace(texto, "@Calibre", calibre)
        texto = Replace(texto, "@Peso", peso & " (Kg)")
        texto = Replace(texto, "@Fecha", fec)
        texto = Replace(texto, "@Orden", codOrden)
        texto = Replace(texto, "@CodigoBarras", codOrden)
        texto = Replace(texto, "@Ref", producto)
        texto = Replace(texto, "@destino", destino)
        texto = Replace(texto, "@colada", colada)
        texto = Replace(texto, "@matPrima", cod_mat_prima)
        texto = Replace(texto, "@traccion", traccion)

        sr.Close()
        sw.WriteLine(texto)
        sw.Close()

    End Sub

    Private Sub chkTodosAux_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTodosAux.CheckedChanged
        If (chkTodosAux.Checked) Then
            cargarTodosOperarios2(cboAuxiliar, True)
        Else
            cargarTodosOperarios2(cboAuxiliar, False)
        End If
    End Sub

    Private Sub cargarTodosOperarios(ByVal cbo As ComponentFactory.Krypton.Toolkit.KryptonComboBox, ByVal estado As Boolean)
        If (estado) Then
            Dim sql As String = "Select nit,nombres   from V_nom_personal_Activo_con_maquila WHERE nit in (select nit from control.dbo.D_empleados_sin_salida) and centro_planta not in (4200) ORDER BY nombres "
            cbo.DataSource = obj_Ing_prodLn.listar_datatable(sql, "CORSAN")
            cbo.ValueMember = "nit"
            cbo.DisplayMember = "nombres"
            cbo.Text = "Seleccione"
        Else
            Dim sql As String = "Select nit,nombres  from V_nom_personal_Activo_con_maquila WHERE nit in (select nit from control.dbo.D_empleados_sin_salida) and centro_planta IN( 2100 ,200) ORDER BY nombres"
            cbo.DataSource = obj_Ing_prodLn.listar_datatable(sql, "CORSAN")
            cbo.ValueMember = "nit"
            cbo.DisplayMember = "nombres"
            cbo.Text = "Seleccione"
        End If
    End Sub
    ''PROVISIONAL PARA AUXILIARES
    Private Sub cargarTodosOperarios2(ByVal cbo As ComboBox, ByVal estado As Boolean)
        If (estado) Then
            Dim sql As String = "Select nit,nombres   from V_nom_personal_Activo_con_maquila WHERE nit in (select nit from control.dbo.D_empleados_sin_salida) and centro_planta not in (4200) ORDER BY nombres "
            cbo.DataSource = obj_Ing_prodLn.listar_datatable(sql, "CORSAN")
            cbo.ValueMember = "nit"
            cbo.DisplayMember = "nombres"
            cbo.Text = "Seleccione"
        Else
            Dim sql As String = "Select nit,nombres  from V_nom_personal_Activo_con_maquila WHERE nit in (select nit from control.dbo.D_empleados_sin_salida) and centro_planta IN( 2100 ,200) ORDER BY nombres"
            cbo.DataSource = obj_Ing_prodLn.listar_datatable(sql, "CORSAN")
            cbo.ValueMember = "nit"
            cbo.DisplayMember = "nombres"
            cbo.Text = "Seleccione"
        End If
    End Sub
    Private Sub btnIniciaPara_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIniciaPara.Click
        Dim sqlm As String = ""
        Dim maquina As String = ""
        sqlm = "SELECT id_maquina FROM dbo.J_orden_prod_tef WHERE (consecutivo = " & consecutivoPpal & ")"
        maquina = obj_Ing_prodLn.listar_Estado(sqlm, "PRODUCCION")
        If (estadoTurno = False) Then
            cboAuxiliar.SelectedValue = 0
            cboTurno.SelectedValue = 0
            cboVel.Text = "Seleccione"

            'If txtMatPrima.Text.Contains("22B") Then
            '    Dim formu As New Frm_lec_brillante
            '    formu.main(consecutivoPpal, consecutivoDet, nit_usuario, "S")
            '    formu.ShowDialog()
            'End If
            'If txtMatPrima.Text.Contains("22R") Then
            '    group_lector_mp.Visible = True
            '    txt_lector_mp.Text = ""
            '    groupDatosDetPlanilla.Visible = False
            '    txt_lector_mp.Focus()
            '    add_rollo_mp_directo = True
            '    TblPpal.Enabled = False
            'End If
            groupDatosDetPlanilla.Visible = True
        Else
            ''VALIDAR SI HAY RED
            If My.Computer.Network.IsAvailable() Then
                ''maquina 1
                If (maquina.Contains("2101")) Then
                    Dim update_estado_M As String = CInt(objOpSimplesLn.modificar_estadoM(maquina, "PRODUCCION"))
                End If
                ''maquina 2
                If (maquina.Contains("2102")) Then
                    Dim update_estado_M As String = CInt(objOpSimplesLn.modificar_estadoM(maquina, "PRODUCCION"))
                End If
                ''maquina 3
                If (maquina.Contains("2103")) Then
                    Dim update_estado_M As String = CInt(objOpSimplesLn.modificar_estadoM(maquina, "PRODUCCION"))
                End If
                ''maquina 4
                If (maquina.Contains("2104")) Then
                    Dim update_estado_M As String = CInt(objOpSimplesLn.modificar_estadoM(maquina, "PRODUCCION"))
                End If
                ''maquina 5
                If (maquina.Contains("2105")) Then
                    Dim update_estado_M As String = CInt(objOpSimplesLn.modificar_estadoM(maquina, "PRODUCCION"))
                End If
                ''maquina 6
                If (maquina.Contains("2116")) Then
                    Dim update_estado_M As String = CInt(objOpSimplesLn.modificar_estadoM(maquina, "PRODUCCION"))
                End If
                ''maquina 7
                If (maquina.Contains("2118")) Then
                    Dim update_estado_M As String = CInt(objOpSimplesLn.modificar_estadoM(maquina, "PRODUCCION"))
                End If
                ''maquina 8
                If (maquina.Contains("2119")) Then
                    Dim update_estado_M As String = CInt(objOpSimplesLn.modificar_estadoM(maquina, "PRODUCCION"))
                End If
                ''maquina 9
                If (maquina.Contains("2121")) Then
                    Dim update_estado_M As String = CInt(objOpSimplesLn.modificar_estadoM(maquina, "PRODUCCION"))
                End If
                iniciarTerminarPlanilla()
            Else
                MessageBox.Show("Mientras la pc no este conectada a una red no se puede ni abrir ni cerrar una planilla.", "No hay red", MessageBoxButtons.OK)
            End If
        End If
    End Sub
    Dim cod_orden_sum As Integer = 0
    Dim id_detalle_sum As Integer = 0
    Private Sub iniciarTerminarPlanilla()
        Dim list As New List(Of Object)
        Dim resp As Boolean = False
        Dim respTemrinar As String = ""
        Dim respValHoro As String = ""
        Dim sql_planilla As String = ""
        Dim val_planilla As String = ""
        Dim obtener_val As String = "" 'validacion nueva'
        Dim sql_val As String = "" 'validacion nueva'
        Dim pesoreco As Double = 0 'validacion nueva'
        Dim pesoalam As Double = 0 'validacion nueva'
        Dim pesotot As Double = 0 'validacion nueva'
        Dim pesobrilla As Double = 0 'validacion nueva'
        habilitar_lectorMp()
        Dim sqlm As String = ""
        Dim maquina As String = ""
        sqlm = "SELECT id_maquina FROM dbo.J_orden_prod_tef WHERE (consecutivo = " & consecutivoPpal & ")"
        maquina = obj_Ing_prodLn.listar_Estado(sqlm, "PRODUCCION")
        If (estadoTurno = False) Then
            ''*******************************************
            
#Disable Warning BC42303 ' El comentario XML no puede aparecer en un método o una propiedad. Se omitirá el comentario XML.
'''PRUEBA DE PONER MAQUINA EN ACTIVA FUNCIONAL

            ''maquina 1
            If (maquina.Contains("2101")) Then
#Enable Warning BC42303 ' El comentario XML no puede aparecer en un método o una propiedad. Se omitirá el comentario XML.
                Dim update_estado_M As String = CInt(objOpSimplesLn.modificar_estadoM(maquina, "PRODUCCION"))
            End If
            ''maquina 2
            If (maquina.Contains("2102")) Then
                Dim update_estado_M As String = CInt(objOpSimplesLn.modificar_estadoM(maquina, "PRODUCCION"))
            End If
            ''maquina 3
            If (maquina.Contains("2103")) Then
                Dim update_estado_M As String = CInt(objOpSimplesLn.modificar_estadoM(maquina, "PRODUCCION"))
            End If
            ''maquina 4
            If (maquina.Contains("2104")) Then
                Dim update_estado_M As String = CInt(objOpSimplesLn.modificar_estadoM(maquina, "PRODUCCION"))
            End If
            ''maquina 5
            If (maquina.Contains("2105")) Then
                Dim update_estado_M As String = CInt(objOpSimplesLn.modificar_estadoM(maquina, "PRODUCCION"))
            End If
            ''maquina 6
            If (maquina.Contains("2116")) Then
                Dim update_estado_M As String = CInt(objOpSimplesLn.modificar_estadoM(maquina, "PRODUCCION"))
            End If
            ''maquina 7
            If (maquina.Contains("2118")) Then
                Dim update_estado_M As String = CInt(objOpSimplesLn.modificar_estadoM(maquina, "PRODUCCION"))
            End If
            ''maquina 8
            If (maquina.Contains("2119")) Then
                Dim update_estado_M As String = CInt(objOpSimplesLn.modificar_estadoM(maquina, "PRODUCCION"))
            End If
            ''maquina 9
            If (maquina.Contains("2121")) Then
                Dim update_estado_M As String = CInt(objOpSimplesLn.modificar_estadoM(maquina, "PRODUCCION"))
            End If

            
#Disable Warning BC42303 ' El comentario XML no puede aparecer en un método o una propiedad. Se omitirá el comentario XML.
'''**********************************************************************************************************''



            Dim sql_validar_pla As String = "SELECT SUM (peso) FROM J_rollos_tref rollo where rollo.cod_orden =" & consecutivoPpal & " and anulado  is null and manuales is null and no_conforme is null"
#Enable Warning BC42303 ' El comentario XML no puede aparecer en un método o una propiedad. Se omitirá el comentario XML.
            Dim peso_orden As String = objOpsimpesLn.consultValorTodo(sql_validar_pla, "PRODUCCION")
            If peso_orden = "" Then
                peso_orden = "0"
            End If
            Dim convert_peso_orden As Double = CDbl(peso_orden)
            Dim peso_progra As Double = CDbl(txtCantProg.Text)
            Dim sql_tipo_cliente As String = "select tipoCliente from J_orden_prod_tef where consecutivo=" & consecutivoPpal & ""
            Dim tipo_cliente As Integer = CInt(objOpSimplesLn.consultValorTodo(sql_tipo_cliente, "PRODUCCION"))
            If tipo_cliente = 0 Then
                If convert_peso_orden <= peso_progra Then
                    Dim sql As String = "SELECT cod_orden FROM J_det_orden_prod WHERE cerrado =1 AND id_detalle =" & consecutivoDet & " AND cod_orden=" & consecutivoPpal
                    If (obj_Ing_prodLn.consultar_valor(sql, "PRODUCCION") <> "") Then
                        cboVel.Enabled = True
                        txt_amarres.Enabled = True
                        txt_no_conforme.Enabled = True
                        Dim fec_hora_ini As String = Format(Now, "yyyy/MM/dd HH:mm:ss")
                        Dim prod_f_trb As String = txtProdFinal.Text
                        contAlertPlanInspAl = 0
                        timAlertLlenarPlanInsp.Enabled = True
                        btnIniciaPara.Image = Spic.My.Resources._stop
                        btnIniciaPara.Text = "Terminar planilla"
                        txtHoraIni.Text = Format(Now, "hh:mm:ss")
                        txtHoraFin.Text = ""
                        ActCantPend()
                        dtgParo.Enabled = True
                        dtgProduccion.Enabled = True
                        obj_Ing_prodLn.ejecutar(updateTurno(txtHoraIni.Text, estadoTurno), "PRODUCCION")
                        obj_Ing_prodLn.ejecutar(objOrdenProdLn.updateFecHoraTurno(fec_hora_ini, estadoTurno, consecutivoDet, consecutivoPpal), "PRODUCCION")
                        estadoTurno = True
                        updateEstadoMaqAct("Activa")
                        actualizar_mp()
                        'If consecutivoDet > 1 Then
                        '    cargar_Horometro()
                        'End If
                        lbl_mat.Text = obj_Ing_prodLn.consultar_valor(sql_val, "PRODUCCION")
                        'If prod_f_trb.ToUpper Like "22B100142*" Or prod_f_trb.ToUpper Like "22B100125*" Then
                        '    'validar_trefilas8y9()
                        '    'validar_tref8y9()
                        'End If
                        If chkInterno.Checked = False Then
                            If My.Computer.Network.Ping("www.google.com", 3000) Then
                                enviarCorreoInicioPlanilla(consecutivoPpal, consecutivoDet)
                            Else
                                MessageBox.Show("No hay internet por lo tanto no se enviara el correo.", "Enviar correo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            End If
                        End If

                    Else
                        MessageBox.Show("Esta planilla asignada al operario " & cbo_operario.Text & " se encuentra finalizada por lo tanto no se puede trabajar sobre ella! ", "Verifique!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                Else
                    MessageBox.Show("Se ha cumplido con la cantidad programada de la orden de produccion no se puede crear planillas", "Cantidad programada completa", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Close()
                End If
            Else
                Dim sql As String = "SELECT cod_orden FROM J_det_orden_prod WHERE cerrado =1 AND id_detalle =" & consecutivoDet & " AND cod_orden=" & consecutivoDet
                If (obj_Ing_prodLn.consultar_valor(sql, "PRODUCCION") <> "") Then
                    cboVel.Enabled = True
                    txt_amarres.Enabled = True
                    txt_no_conforme.Enabled = True
                    Dim fec_hora_ini As String = Format(Now, "yyyy/MM/dd HH:mm:ss")
                    Dim prod_f_trb As String = txtProdFinal.Text
                    contAlertPlanInspAl = 0
                    timAlertLlenarPlanInsp.Enabled = True
                    btnIniciaPara.Image = Spic.My.Resources._stop
                    btnIniciaPara.Text = "Terminar planilla"
                    txtHoraIni.Text = Format(Now, "hh:mm:ss")
                    txtHoraFin.Text = ""
                    ActCantPend()
                    dtgParo.Enabled = True
                    dtgProduccion.Enabled = True
                    obj_Ing_prodLn.ejecutar(updateTurno(txtHoraIni.Text, estadoTurno), "PRODUCCION")
                    obj_Ing_prodLn.ejecutar(objOrdenProdLn.updateFecHoraTurno(fec_hora_ini, estadoTurno, consecutivoDet, consecutivoPpal), "PRODUCCION")
                    estadoTurno = True
                    updateEstadoMaqAct("Activa")
                    actualizar_mp()
                    'If consecutivoDet > 1 Then
                    '    cargar_Horometro()
                    'End If
                    'If prod_f_trb.ToUpper Like "22B100142*" Or prod_f_trb.ToUpper Like "22B100125*" Then
                    '    validar_trefilas8y9()
                    '    'validar_tref8y9()
                    'End If
                    If chkInterno.Checked = False Then
                        If My.Computer.Network.Ping("www.google.com", 3000) Then
                            enviarCorreoInicioPlanilla(consecutivoPpal, consecutivoDet)
                        Else
                            MessageBox.Show("No hay internet por lo tanto no se enviara el correo.", "Enviar correo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    End If
                Else
                    MessageBox.Show("Esta planilla asignada al operario " & cbo_operario.Text & " se encuentra finalizada por lo tanto no se puede trabajar sobre ella! ", "Verifique!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End If
        Else
            'Validar ingreso de planilla
            If validar_Ingreso_Calidad() Then
                If txtMatPrima.Text.Contains("22B") Or txtMatPrima.Text.Contains("22R") Or txtMatPrima.Text.Contains("22X") Then
                    If (cboVel.SelectedValue <> "Seleccione") Then
                        sql_planilla = "select transaccion_entrada from J_det_orden_prod WHERE cod_orden=" & consecutivoPpal & " and id_detalle=" & consecutivoDet & ""
                        val_planilla = objOpsimpesLn.consultValorTodo(sql_planilla, "PRODUCCION")
                        If val_planilla = "" Then
                            respTemrinar = MessageBox.Show("Al terminar la planilla y no se podra seguir modificando, esta seguro de que culmino su planilla? ", "Terminar planilla?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                            If My.Computer.Network.Ping("10.10.10.246", 2000) Then
                                Dim consulta As String = "SELECT top(1) session_id FROM sys.dm_exec_requests WHERE blocking_session_id <> 0"
                                Dim bloqueo As String = objOpsimpesLn.consultValorTodo(consulta, "CORSAN")
                                If bloqueo = "" Then
                                    If (respTemrinar = "6") Then
                                        contAlertPlanInspAl = 0
                                        timAlertLlenarPlanInsp.Enabled = False
                                        respValHoro = objOrdenProdLn.validarHorometro(txtHorometroIni.Text, txtHorometroFin.Text)
                                        Dim amarres As String = txt_amarres.Text
                                        Dim desperdicio As String = txt_no_conforme.Text
                                        If (amarres <> "") Then
                                            If (desperdicio <> "") Then
                                                If (respValHoro = "") Then
                                                    Dim fec_hora_fin As String = Format(Now, "yyyy/MM/dd HH:mm:ss")
                                                    btnIniciaPara.Image = Spic.My.Resources.comienza
                                                    btnIniciaPara.Text = "Iniciar planilla"
                                                    txtHoraFin.Text = Format(Now, "hh:mm:ss")
                                                    dtgParo.Enabled = False
                                                    dtgProduccion.Enabled = False
                                                    cboVel.Enabled = False
                                                    txt_amarres.Enabled = False
                                                    txt_no_conforme.Enabled = False
                                                    TblPpal.SelectedTab = tblOrdenesOperario
                                                    cod_orden_sum = consecutivoPpal
                                                    id_detalle_sum = consecutivoDet
                                                    If ingProdDms() Then
                                                        list.Add(updateTurno(txtHoraFin.Text, estadoTurno))
                                                        list.Add(objOrdenProdLn.updateFecHoraTurno(fec_hora_fin, estadoTurno, consecutivoDet, consecutivoPpal))
                                                        list.Add("UPDATE  J_det_orden_prod SET cerrado = 1 WHERE id_detalle =" & consecutivoDet & " AND cod_orden =" & consecutivoPpal)
                                                        list.Add(sqlUpdateNotas)
                                                        list.Add(updateEstadoMaq("Turno inactivo"))
                                                        obj_Ing_prodLn.ExecuteSqlTransaction(list, "PRODUCCION")
                                                        list.Clear()
                                                        obj_Ing_prodLn.ExecuteSqlTransaction(guardarDetalle, "PRODUCCION")
                                                        estadoTurno = False
                                                        terminarParoAbierto()
                                                        list.Add(objOrdenProdLn.updateTransaccionesOrden(num_tran_prod, consecutivoDet, consecutivoPpal))
                                                        resp = obj_Ing_prodLn.ExecuteSqlTransaction(list, "PRODUCCION")
                                                        ingProdEfic()
                                                        'auto_programar_ordenes()
                                                        If (resp) Then
                                                            Dim prod_f_trb As String = txtProdFinal.Text
                                                            If prod_f_trb.ToUpper Like "22B100142*" Or prod_f_trb.ToUpper Like "22B100125*" Then
                                                                trans_trb(consecutivoPpal, consecutivoDet)
                                                                imprimir_Tiquete_lote_tref_8y9()
                                                                cargar_rollos_reg()
                                                                'guardar_nrorollos_estado()
                                                            End If
                                                            If My.Computer.Network.Ping("www.google.com", 3000) Then
                                                                enviarCorreoFinPlanilla(consecutivoPpal, consecutivoDet)
                                                            Else
                                                                MessageBox.Show("No hay internet por lo tanto no se enviara el correo de fin de planilla.", "Enviar correo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                                            End If
                                                            MessageBox.Show("Su turno fue finalizado en forma exitosa! ", "Correcto!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                                            'ACTUALIZAR ESTADO DE LA MAQUINA A INACTIVA FUNCIONAL

                                                            ''maquina 1
                                                            If (maquina.Contains("2101")) Then
                                                                Dim update_estado_M As String = CInt(objOpSimplesLn.modificar_estadoMI(maquina, "PRODUCCION"))
                                                            End If
                                                            ''maquina 2
                                                            If (maquina.Contains("2102")) Then
                                                                Dim update_estado_M As String = CInt(objOpSimplesLn.modificar_estadoMI(maquina, "PRODUCCION"))
                                                            End If
                                                            ''maquina 3
                                                            If (maquina.Contains("2103")) Then
                                                                Dim update_estado_M As String = CInt(objOpSimplesLn.modificar_estadoMI(maquina, "PRODUCCION"))
                                                            End If
                                                            ''maquina 4
                                                            If (maquina.Contains("2104")) Then
                                                                Dim update_estado_M As String = CInt(objOpSimplesLn.modificar_estadoMI(maquina, "PRODUCCION"))
                                                            End If
                                                            ''maquina 5
                                                            If (maquina.Contains("2105")) Then
                                                                Dim update_estado_M As String = CInt(objOpSimplesLn.modificar_estadoMI(maquina, "PRODUCCION"))
                                                            End If
                                                            ''maquina 6
                                                            If (maquina.Contains("2116")) Then
                                                                Dim update_estado_M As String = CInt(objOpSimplesLn.modificar_estadoMI(maquina, "PRODUCCION"))
                                                            End If
                                                            ''maquina 7
                                                            If (maquina.Contains("2118")) Then
                                                                Dim update_estado_M As String = CInt(objOpSimplesLn.modificar_estadoMI(maquina, "PRODUCCION"))
                                                            End If
                                                            ''maquina 8
                                                            If (maquina.Contains("2119")) Then
                                                                Dim update_estado_M As String = CInt(objOpSimplesLn.modificar_estadoMI(maquina, "PRODUCCION"))
                                                            End If
                                                            ''maquina 9
                                                            If (maquina.Contains("2121")) Then
                                                                Dim update_estado_M As String = CInt(objOpSimplesLn.modificar_estadoMI(maquina, "PRODUCCION"))
                                                            End If

                                                            
#Disable Warning BC42303 ' El comentario XML no puede aparecer en un método o una propiedad. Se omitirá el comentario XML.
'''**********************************************************************************************************''

                                                            nuevo()
#Enable Warning BC42303 ' El comentario XML no puede aparecer en un método o una propiedad. Se omitirá el comentario XML.
                                                            cargarPlanOperario()
                                                            habilitar_lectorMp()
                                                        Else
                                                            MessageBox.Show("Error al cerrar su turno,comuniquese con el administrador del sistema! ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                                        End If
                                                    Else
                                                        enviarCorreoErrorEppp(consecutivoPpal, consecutivoDet)
                                                        MessageBox.Show("Error al cerrar su turno,comuniquese con el administrador del sistema! ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                                    End If
                                                Else
                                                    MessageBox.Show("Error : " & respValHoro & " ,corrija la inconsistencia y presione de nuevo el boton terminar planilla!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                                End If
                                            Else
                                                MessageBox.Show("Ingrese cantidad en kilos de desperdicio", "Ingrese desperdicio", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                            End If
                                        Else
                                            MessageBox.Show("Ingrese cantidad en kilos de amarres", "Ingrese amarres", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                        End If
                                    End If
                                Else
                                    MessageBox.Show("Planilla no se puede cerrar por bloqueo en base de datos", "Bloqueo en base de datos", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                End If
                            Else
                                MessageBox.Show("No se puede cerrar planilla hasta que haya conexión con la base de datos", "No Conectado", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Me.Close()
                            End If
                        Else
                            MessageBox.Show("Esta planilla ya se ha cerrado", "Planilla cerrada", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Me.Close()
                        End If
                    Else
                        MessageBox.Show("Seleccione la velocidad actual de la maquina!", "Velocidad", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                Else
                    sql_val = "SELECT sum(d.peso) FROM J_alambron_importacion_det_rollos d INNER JOIN  J_orden_prod_rollo_mp o on o.id_rollo_mp = d.id" &
                              " WHERE o.cod_orden = " & consecutivoPpal & " And o.id_detalle = " & consecutivoDet & ""
                    obtener_val = objOpSimplesLn.consultValorTodo(sql_val, "PRODUCCION")
                    If obtener_val = "" Then
                        pesoalam = 0
                    Else
                        pesoalam = CDbl(obtener_val)
                    End If
                    sql_val = "SELECT sum(b.peso) FROM JB_orden_prod_tref_mp_rec r INNER JOIN JB_rollos_rec b " &
                              " on r.cod_rec=b.cod_orden_rec and r.det_rec=b.id_detalle_rec and r.roll_rec=b.id_rollo_rec" &
                              " WHERE r.cod_orden = " & consecutivoPpal & " And r.id_detalle = " & consecutivoDet & ""
                    obtener_val = objOpSimplesLn.consultValorTodo(sql_val, "PRODUCCION")
                    If obtener_val = "" Then
                        pesoreco = 0
                    Else
                        pesoreco = CDbl(obtener_val)
                    End If
                    pesotot = pesoalam + pesoreco
                    'cambio alambron
                    sql_val = "SELECT peso_lleva FROM J_tref_cont_mp WHERE codigoM= " & cbo_maquina.SelectedValue & " and ano=" & cbo_fec_orden.Value.Year & " and mes=" & cbo_fec_orden.Value.Month & " and cod_alambron='" & txtMatPrima.Text & "'"
                    pesotot = objOpsimpesLn.consultValorTodo(sql_val, "PRODUCCION")
                    sql_val = "SELECT sum(peso) FROM J_rollos_tref" &
                              " where cod_orden = " & consecutivoPpal & " And id_detalle = " & consecutivoDet & " And anulado Is null And manuales Is null"
                    obtener_val = objOpSimplesLn.consultValorTodo(sql_val, "PRODUCCION")
                    If obtener_val = "" Then
                        pesobrilla = 0
                    Else
                        pesobrilla = CDbl(obtener_val)
                    End If
                    If pesobrilla <= pesotot Then
                        If (cboVel.SelectedValue <> "Seleccione") Then
                            sql_planilla = "select transaccion_entrada from J_det_orden_prod WHERE cod_orden=" & consecutivoPpal & " and id_detalle=" & consecutivoDet & ""
                            val_planilla = objOpsimpesLn.consultValorTodo(sql_planilla, "PRODUCCION")
                            If val_planilla = "" Then
                                respTemrinar = MessageBox.Show("Al terminar la planilla y no se podra seguir modificando, esta seguro de que culmino su planilla? ", "Terminar planilla?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                                If My.Computer.Network.Ping("10.10.10.246", 2000) Then
                                    Dim consulta As String = "SELECT top(1) session_id FROM sys.dm_exec_requests WHERE blocking_session_id <> 0"
                                    Dim bloqueo As String = objOpsimpesLn.consultValorTodo(consulta, "CORSAN")
                                    If bloqueo = "" Then
                                        If (respTemrinar = "6") Then
                                            contAlertPlanInspAl = 0
                                            timAlertLlenarPlanInsp.Enabled = False
                                            respValHoro = objOrdenProdLn.validarHorometro(txtHorometroIni.Text, txtHorometroFin.Text)
                                            Dim amarres As String = txt_amarres.Text
                                            Dim desperdicio As String = txt_no_conforme.Text
                                            If (amarres <> "") Then
                                                If (desperdicio <> "") Then
                                                    If (respValHoro = "") Then
                                                        Dim fec_hora_fin As String = Format(Now, "yyyy/MM/dd HH:mm:ss")
                                                        btnIniciaPara.Image = Spic.My.Resources.comienza
                                                        btnIniciaPara.Text = "Iniciar planilla"
                                                        txtHoraFin.Text = Format(Now, "hh:mm:ss")
                                                        dtgParo.Enabled = False
                                                        dtgProduccion.Enabled = False
                                                        cboVel.Enabled = False
                                                        txt_amarres.Enabled = False
                                                        txt_no_conforme.Enabled = False
                                                        TblPpal.SelectedTab = tblOrdenesOperario
                                                        cod_orden_sum = consecutivoPpal
                                                        id_detalle_sum = consecutivoDet
                                                        If ingProdDms() Then
                                                            list.Add(updateTurno(txtHoraFin.Text, estadoTurno))
                                                            list.Add(objOrdenProdLn.updateFecHoraTurno(fec_hora_fin, estadoTurno, consecutivoDet, consecutivoPpal))
                                                            list.Add("UPDATE  J_det_orden_prod SET cerrado = 1 WHERE id_detalle =" & consecutivoDet & " AND cod_orden =" & consecutivoPpal)
                                                            list.Add(sqlUpdateNotas)
                                                            list.Add(updateEstadoMaq("Turno inactivo"))
                                                            obj_Ing_prodLn.ExecuteSqlTransaction(list, "PRODUCCION")
                                                            list.Clear()
                                                            obj_Ing_prodLn.ExecuteSqlTransaction(guardarDetalle, "PRODUCCION")
                                                            estadoTurno = False
                                                            terminarParoAbierto()
                                                            list.Add(objOrdenProdLn.updateTransaccionesOrden(num_tran_prod, consecutivoDet, consecutivoPpal))
                                                            resp = obj_Ing_prodLn.ExecuteSqlTransaction(list, "PRODUCCION")
                                                            ingProdEfic()
                                                            'auto_programar_ordenes()
                                                            If (resp) Then
                                                                Dim prod_f_trb As String = txtProdFinal.Text
                                                                If prod_f_trb.ToUpper Like "22B100142*" Or prod_f_trb.ToUpper Like "22B100125*" Then
                                                                    trans_trb(consecutivoPpal, consecutivoDet)
                                                                    imprimir_Tiquete_lote_tref_8y9()
                                                                    cargar_rollos_reg()
                                                                    'guardar_nrorollos_estado()
                                                                End If
                                                                If My.Computer.Network.Ping("www.google.com", 3000) Then
                                                                    enviarCorreoFinPlanilla(consecutivoPpal, consecutivoDet)
                                                                Else
                                                                    MessageBox.Show("No hay internet por lo tanto no se enviara el correo de fin de planilla.", "Enviar correo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                                                End If
                                                                MessageBox.Show("Su turno fue finalizado en forma exitosa! ", "Correcto!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                                                nuevo()
                                                                cargarPlanOperario()
                                                                habilitar_lectorMp()
                                                            Else
                                                                MessageBox.Show("Error al cerrar su turno,comuniquese con el administrador del sistema! ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                                            End If
                                                        Else
                                                            enviarCorreoErrorEppp(consecutivoPpal, consecutivoDet)
                                                            MessageBox.Show("Error al cerrar su turno,comuniquese con el administrador del sistema! ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                                        End If
                                                    Else
                                                        MessageBox.Show("Error : " & respValHoro & " ,corrija la inconsistencia y presione de nuevo el boton terminar planilla!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                                    End If
                                                Else
                                                    MessageBox.Show("Ingrese cantidad en kilos de desperdicio", "Ingrese desperdicio", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                                End If
                                            Else
                                                MessageBox.Show("Ingrese cantidad en kilos de amarres", "Ingrese amarres", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                            End If
                                        End If
                                    Else
                                        MessageBox.Show("Planilla no se puede cerrar por bloqueo en base de datos", "Bloqueo en base de datos", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                    End If
                                Else
                                    MessageBox.Show("Sin conexion a base de datos", "No Conectado", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    Me.Close()
                                End If
                            Else
                                MessageBox.Show("Esta planilla ya se ha cerrado", "Planilla cerrada", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                Me.Close()
                            End If
                        Else
                            MessageBox.Show("Seleccione la velocidad actual de la maquina!", "Velocidad", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If
                    Else
                        MessageBox.Show("Esta planilla No se puede cerrar, ya que se ha producido una cantidad total mayor a la materia prima.Se debe leer mas materia prima", "Planilla no se puede cerrar", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                End If
            Else
                MessageBox.Show("Esta planilla No se puede cerrar, ya que no se ha llenado la planiilla de calidad", "Planilla no se puede cerrar", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
    End Sub

    Public Sub trans_trb(ByVal cod_orden As Integer, ByVal id_detalle As Integer)
        Dim dt As New DataTable
        Dim dt2 As New DataTable
        Dim codigo As String = ""
        Dim peso As Double = 0
        Dim costo_unit As Double = 0
        Dim listSql As New List(Of Object)
        Dim db_produccion As String = objOpSimplesLn.get_nom_db("PRODUCCION") & ".dbo."
        Dim sql As String
        'dt = objOpsimpesLn.listar_datatable(sql, "PRODUCCION")
        'For i = 0 To dt.Rows.Count - 1
        '    codigo = dt.Rows(i).Item("codigo")
        '    peso = Format(dt.Rows(i).Item("cantidad"), "#0.0")
        '    costo_unit = objOrdenProdLn.consultCostoUnit(dt.Rows(i).Item("codigo"))
        'Next
        'Dim stock As Double = Format(objOpSimplesLn.consultarStock(codigo, 2), "#0.0")
        'If peso <= stock Then
        'listSql.AddRange(traslado_bodega(codigo, peso, "TRB1", costo_unit))
        sql = "SELECT id_rollo FROM j_rollos_tref  WHERE COD_ORDEN = " & cod_orden & " AND id_detalle = " & id_detalle & " AND anulado is null and manuales is null"
        dt2 = objOpsimpesLn.listar_datatable(sql, "PRODUCCION")
        For i = 0 To dt2.Rows.Count - 1
            sql = "UPDATE " & db_produccion & "J_rollos_tref SET destino = 'R', traslado=1  where  id_detalle =" & id_detalle & "  AND id_rollo =" & dt2.Rows(i).Item("id_rollo") & "and cod_orden=" & cod_orden
            listSql.Add(sql)
        Next
        If obj_Ing_prodLn.ExecuteSqlTransaction(listSql, "CORSAN") Then
        Else
            MessageBox.Show("Error al poner los rollos como disponibles para recocido")
        End If
        'Else
        '    enviarCorreoErrorTrasRec(cod_orden, id_detalle, peso, stock)
        'End If
    End Sub

    Private Sub enviarCorreoErrorTrasRec(ByVal cod_orden As String, ByVal id_detalle As Integer, ByVal peso As Double, ByVal stock As Double)
        Dim sql As String = "SELECT mail,Mail_login  FROM Jjv_usuarios WHERE usuario = 'ADMIN'"
        Dim dt_admin As DataTable = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        Dim mail As String = "david.hincapie@corsan.com.co"
        Dim asunto As String = "Error en el traslado automatico a recocido."
        Dim cuerpo As String = "ERROR AL HACER EL TRASLADO." & vbCrLf &
                                "-Orden numero:" & cod_orden & vbCrLf &
                                "-N° de planilla: " & id_detalle & vbCrLf &
                                "-Cantidad: " & peso & vbCrLf &
                                "-Stock: " & stock & vbCrLf &
                                "-Fecha: " & Now
        Dim mailEnvia As String = dt_admin.Rows(0).Item("mail")
        Dim mailEnviaPass As String = dt_admin.Rows(0).Item("Mausuarioil_login")
        obj_correoLn.EnviarCorreo(mail.Trim, cuerpo, asunto, "", mailEnvia, mailEnviaPass, False)
        mail = "isabel.gomez@corsan.com.co"
        obj_correoLn.EnviarCorreo(mail.Trim, cuerpo, asunto, "", mailEnvia, mailEnviaPass, False)
        mail = "david.hincapie@corsan.com.co"
        obj_correoLn.EnviarCorreo(mail.Trim, cuerpo, asunto, "", mailEnvia, mailEnviaPass, False)
    End Sub
    Private Function traslado_bodega(ByVal codigo As String, ByVal cantidad As Double, ByVal tipo As String, ByVal costo_unit As Double) As List(Of Object)
        Dim listSql As New List(Of Object)
        Dim dFec As Date = Now
        Dim usuario As String = Me.usuario
        Dim notas As String = "SPIC fecha:" & Now & " usuario:" & usuario
        numero_transaccion = objOrdenProdLn.mover_consecutivo(tipo)
        listSql = objTraslado_bodLn.listaTransaccionDatable_traslado_bodega(numero_transaccion, codigo, 2, 13, dFec, notas, usuario, cantidad, tipo, "23", costo_unit)
        Return listSql
    End Function
    Private Function cerrarTurnoDesdeCoordinador()
        Dim list As New List(Of Object)
        Dim resp As Boolean = False
        Dim fec_hora_fin As String = Format(Now, "yyyy/MM/dd HH:mm:ss")
        btnIniciaPara.Image = Spic.My.Resources.comienza
        btnIniciaPara.Text = "Iniciar planilla"
        txtHoraFin.Text = Format(Now, "hh:mm:ss")
        list.Add(updateTurno(txtHoraFin.Text, estadoTurno))
        list.Add(objOrdenProdLn.updateFecHoraTurno(fec_hora_fin, estadoTurno, consecutivoDet, consecutivoPpal))
        'list.AddRange(guardarDetalle)
        list.Add("UPDATE  J_det_orden_prod SET cerrado = 1 WHERE id_detalle =" & consecutivoDet & " AND cod_orden =" & consecutivoPpal)
        txtNotasOperarios.Text &= "-Turno cerrado desde admin_prod"
        list.Add(sqlUpdateNotas)
        list.Add(updateEstadoMaq("Turno inactivo"))
        resp = obj_Ing_prodLn.ExecuteSqlTransaction(list, "PRODUCCION")
        Return resp
    End Function
    'Validar inicio de planillas de referencias 22b100142 y 22b100125
    Private Sub validar_trefilas8y9()
        Dim sql As String
        Dim resta_limite As Integer
        sql = "Select falta from J_val_8y9 where id_tref=" & cboMaquinaConsulta.SelectedValue & " AND codigo='" & txtProdFinal.Text.ToUpper & "'"
        resta_limite = CInt(objOpSimplesLn.consultValorTodo(sql, "PRODUCCION"))
        If resta_limite < 60 Then
            MessageBox.Show("Debe terminar con el lote anterior al cual le faltaron:" & resta_limite & " Rollos", "Continua con planilla(lote anterior)", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
    Private Sub validar_tref8y9()
        Dim sql As String
        Dim prod_f_trb As String = txtProdFinal.Text
        Dim val_exi_planilla_ant As String
        Dim lote As String
        Dim limite_local As Integer
        Dim dt, dt_orden As DataTable
        If consecutivoDet > 1 Then
            val_exi_planilla_ant = "select lote_completo,nro_lote,limite_lote,nro_rollos,id_detalle from J_det_orden_prod where cod_orden=" & consecutivoPpal & " and id_detalle=" & consecutivoDet - 1
            dt = objOpSimplesLn.listar_datatable(val_exi_planilla_ant, "PRODUCCION")
        End If
        If consecutivoDet = 1 Then
            If Now.Day = 1 Then
                Dim cod_orden_u, id_detalle_u As String
                If Now.Month = 1 Then
                    sql = "select top(1) d.cod_orden AS ultima_o,d.id_detalle as ultimo_d,max(transaccion_entrada) as transaccion_entrada from J_orden_prod_tef j inner join J_det_orden_prod d on j.consecutivo=d.cod_orden where j.prod_final='" & txtProdFinal.Text & "' and j.ano=" & Now.Year - 1 & " and j.mes=" & 12 & " and j.id_maquina=" & cbo_maquina.SelectedValue & " group by cod_orden,id_detalle order by transaccion_entrada DESC"
                Else
                    sql = "select top(1) d.cod_orden AS ultima_o,d.id_detalle as ultimo_d,max(transaccion_entrada) as transaccion_entrada from J_orden_prod_tef j inner join J_det_orden_prod d on j.consecutivo=d.cod_orden where j.prod_final='" & txtProdFinal.Text & "' and j.ano=" & Now.Year & " and j.mes=" & Now.Month - 1 & " and j.id_maquina=" & cbo_maquina.SelectedValue & " group by cod_orden,id_detalle order by transaccion_entrada DESC"
                End If
                dt_orden = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")
                cod_orden_u = dt_orden.Rows(0).Item("ultima_o")
                id_detalle_u = dt_orden.Rows(0).Item("ultimo_d")
                val_exi_planilla_ant = "select lote_completo,nro_lote,limite_lote,nro_rollos,id_detalle from J_det_orden_prod where cod_orden=" & cod_orden_u & " and id_detalle=" & id_detalle_u
                dt_orden = objOpSimplesLn.listar_datatable(val_exi_planilla_ant, "PRODUCCION")
                If dt_orden.Rows(0).Item("lote_completo") = "S" Then
                    limite = obj_Ing_prodLn.consultar_valor("select limite from j_det_tref_limit", "PRODUCCION")
                    sql = "update J_det_orden_prod set limite_lote=" & limite & " where cod_orden=" & consecutivoPpal & " and id_detalle=" & consecutivoDet
                    obj_Ing_prodLn.ejecutar(sql, "PRODUCCION")
                Else
                    limite_local = dt_orden.Rows(0).Item("limite_lote")
                    limite = (limite_local - dt_orden.Rows(0).Item("nro_rollos"))
                    sql = "update J_det_orden_prod set limite_lote=" & limite & " where cod_orden=" & consecutivoPpal & " and id_detalle=" & consecutivoDet
                    obj_Ing_prodLn.ejecutar(sql, "PRODUCCION")
                    MessageBox.Show("Debe terminar con el lote del mes anterior al cual le faltaron:" & limite & " Rollos", "Continua con planilla(lote anterior)", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Else
                limite = obj_Ing_prodLn.consultar_valor("select limite from j_det_tref_limit", "PRODUCCION")
                sql = "update J_det_orden_prod set limite_lote=" & limite & " where cod_orden=" & consecutivoPpal & " and id_detalle=" & consecutivoDet
                obj_Ing_prodLn.ejecutar(sql, "PRODUCCION")
            End If
            lote = 1
            sql = "update J_det_orden_prod set nro_lote=" & lote & " where cod_orden=" & consecutivoPpal & " and id_detalle=" & consecutivoDet
            obj_Ing_prodLn.ejecutar(sql, "PRODUCCION")
        Else
#Disable Warning BC42104 ' La variable 'dt' se usa antes de que se le haya asignado un valor. Podría darse una excepción de referencia NULL en tiempo de ejecución.
            If Not IsDBNull(dt.Rows(0).Item("limite_lote")) Then
#Enable Warning BC42104 ' La variable 'dt' se usa antes de que se le haya asignado un valor. Podría darse una excepción de referencia NULL en tiempo de ejecución.
                If dt.Rows(0).Item("lote_completo") = "S" Then
                    lote = (dt.Rows(0).Item("nro_lote")) + 1
                    sql = "update J_det_orden_prod set nro_lote=" & lote & " where cod_orden=" & consecutivoPpal & " and id_detalle=" & consecutivoDet
                    obj_Ing_prodLn.ejecutar(sql, "PRODUCCION")
                    limite = obj_Ing_prodLn.consultar_valor("select limite from j_det_tref_limit", "PRODUCCION")
                    sql = "update J_det_orden_prod set limite_lote=" & limite & " where cod_orden=" & consecutivoPpal & " and id_detalle=" & consecutivoDet
                    obj_Ing_prodLn.ejecutar(sql, "PRODUCCION")
                Else
                    lote = (dt.Rows(0).Item("nro_lote"))
                    sql = "update J_det_orden_prod set nro_lote=" & lote & " where cod_orden=" & consecutivoPpal & " and id_detalle=" & consecutivoDet
                    obj_Ing_prodLn.ejecutar(sql, "PRODUCCION")
                    limite_local = dt.Rows(0).Item("limite_lote")
                    limite = (limite_local - dt.Rows(0).Item("nro_rollos"))
                    sql = "update J_det_orden_prod set limite_lote=" & limite & " where cod_orden=" & consecutivoPpal & " and id_detalle=" & consecutivoDet
                    obj_Ing_prodLn.ejecutar(sql, "PRODUCCION")
                    MessageBox.Show("Debe terminar con el lote anterior al cual le faltaron:" & limite & " Rollos", "Continua con planilla(lote anterior)", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Else
                lote = 1
                sql = "update J_det_orden_prod set nro_lote=" & lote & " where cod_orden=" & consecutivoPpal & " and id_detalle=" & consecutivoDet
                obj_Ing_prodLn.ejecutar(sql, "PRODUCCION")
                limite = obj_Ing_prodLn.consultar_valor("select limite from j_det_tref_limit", "PRODUCCION")
                sql = "update J_det_orden_prod set limite_lote=" & limite & " where cod_orden=" & consecutivoPpal & " and id_detalle=" & consecutivoDet
                obj_Ing_prodLn.ejecutar(sql, "PRODUCCION")
            End If
        End If
    End Sub

    Private Function updateEstadoMaq(ByVal estado As String)
        Dim sql As String = "UPDATE  J_det_orden_prod SET estadoMaq ='" & estado & "' WHERE cod_orden = " & consecutivoPpal & " and id_detalle = " & consecutivoDet
        Return sql
    End Function
    Private Sub updateEstadoMaqAct(ByVal estado As String)
        Dim sql As String = "UPDATE  J_det_orden_prod SET estadoMaq ='" & estado & "' WHERE cod_orden = " & consecutivoPpal & " and id_detalle = " & consecutivoDet
        objOpsimpesLn.ejecutar(sql, "PRODUCCION")
    End Sub
    Private Function sqlUpdateNotas() As String
        Dim sql As String = "UPDATE J_det_orden_prod SET notas = '" & txtNotasOperarios.Text & "' WHERE cod_orden = " & consecutivoPpal & " and id_detalle = " & consecutivoDet & ""
        Return sql
    End Function
    Private Function updateTurno(ByVal hora As String, ByVal estadoTurno As Boolean) As String
        Dim sql As String = ""
        Dim tipo As String = ""
        If (estadoTurno = False) Then
            tipo = "hIni"
        Else
            tipo = "hFin"
        End If
        sql = "UPDATE  J_det_orden_prod SET " & tipo & " = '" & hora & "' WHERE id_detalle =" & consecutivoDet & " AND cod_orden =" & consecutivoPpal
        Return sql
    End Function
    Private Sub cerrarPlanilla()
        Dim sql As String = ""
    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If (txtPeso.TextLength >= 30) Then
            txtPeso.Text = peso
        End If
        peso = SerialPort1.ReadExisting()
        'SerialPort1.ReadExisting()
        dtgProduccion.Item("colKg", dtgProduccion.RowCount - 1).Value = peso
        txtPeso.Text += peso
    End Sub
    Private Function guardarConsol() As List(Of Object)
        Dim lisSql As New List(Of Object)
        Dim resp As Boolean = False
        Dim sql As String = ""
        Dim sqlGuardar As String = ""

        Dim prod_final As String = txtProdFinal.Text
        Dim materia_prima As String = txtMatPrima.Text.ToUpper
        Dim sql_prod As String
        sql_prod = "select costo_unitario from referencias where codigo='" & prod_final & "'"
        Dim costo_ref As String = objOpsimpesLn.consultValorTodo(sql_prod, "CORSAN")
        sql_prod = "select Promedio from v_promedio where codigo='" & materia_prima & "' and ano=" & Now.Year & " and mes=" & Now.Month & ""
        Dim costo_alam As String
        costo_alam = objOpsimpesLn.consultValorTodo(sql_prod, "CORSAN")
        Dim nit As String = cboCliente.SelectedValue
        Dim trac_ini As String = txtTracMin.Text
        Dim trac_fin As String = txtTracMax.Text
        Dim diam_min As String = txtDiaMin.Text
        Dim diam_max As String = txtDiamMAx.Text
        Dim cant_prog As String = txtCantProg.Text
        Dim diametro As String = txtDiametro.Text
        Dim cod_alambron As String = txt_cod_alambron.Text
        Dim numPasos As Integer = cboNumPasos.Text
        Dim origen As String = cboOrigen.SelectedValue
        Dim calidad As Integer = cboCalidad.SelectedValue
        Dim tipoCliente As Integer = 0
        Dim maquina As String = cbo_maquina.SelectedValue
        Dim mes As Integer = cbo_fec_orden.Value.Month
        Dim ano As Integer = cbo_fec_orden.Value.Year
        Dim notas_auditoria As String = ""
        Dim notas As String = txtNotas.Text
        Dim fecha As String = objOpSimplesLn.cambiarFormatoFecha(cbo_fec_orden.Value)
        fecha = fecha & " 00:00:00"
        If (chkInterno.Checked) Then
            tipoCliente = 1
        End If
        If (orden_existe = "") Then
            notas_auditoria = "Creo:" & usuario & Now
            sql = "SELECT  MAX (consecutivo) FROM J_orden_prod_tef"
            actualizarConsecutivoPpal(obj_Ing_prodLn.consultar_valor(sql, "PRODUCCION") + 1)
            sqlGuardar = "INSERT INTO J_orden_prod_tef " &
                            "(consecutivo,prod_final,diam_min,diam_max,cant_prog,diametro,origen,materia_prima,trac_ini,trac_fin,nit,numPasos,calidad,tipoCliente,id_maquina,mes,ano,notas_auditoria,notas,oculto,cod_alambron,fecha_creacion,fecha_terminacion,costo_prod_final,costo_mat_prima,num_ped) " &
                                "VALUES " &
                                        "( " & consecutivoPpal & ", '" & prod_final & "' ," & diam_min & "," & diam_max & " ," & cant_prog & " ," & diametro & " ," & origen & " ,'" & materia_prima & "'," & trac_ini & "," & trac_fin & "," & nit & "," & numPasos & "," & calidad & "," & tipoCliente & ",'" & maquina & "'," & mes & "," & ano & ",'" & notas_auditoria & "','" & notas & "',0,'" & cod_alambron & "','" & fecha & "','" & fecha & "'," & costo_ref & "," & costo_alam & "," & num_pedido & ")"
            mat_prima_rec = prod_final
            val = 0
            lisSql.Add(sqlGuardar)

        Else
            If usuario = "ADMIN" Or permiso = "COOR_PROD" Or permiso = "DIR_PRODUCCION" Then
                val = 1
                notas_auditoria = " - Modifico:" & usuario & Now
                sql = "UPDATE J_orden_prod_tef SET " &
                       "prod_final =  '" & prod_final & "'" &
                        ",diam_min =  " & diam_min &
                        ",diam_max =  " & diam_max &
                    ",cant_prog = " & cant_prog &
                        ",diametro =  " & diametro &
                        ",origen =  " & origen &
                        ",materia_prima = '" & materia_prima & "'" &
                    ",trac_ini =  " & trac_ini &
                    " ,trac_fin =  " & trac_fin &
                    ",numPasos = " & numPasos &
                      ",calidad =  " & calidad &
                        ",nit = " & nit &
                            ",tipoCliente = " & tipoCliente &
                            ",id_maquina = '" & maquina & "'" &
                            ",mes = '" & mes & "'" &
                            ",ano = '" & ano & "'" &
                            ",notas_auditoria = (SELECT CASE WHEN notas_auditoria is null THEN '" & notas_auditoria & "' ELSE notas_auditoria + '" & notas_auditoria & "' END)" &
                            ",notas = '" & notas & "' " &
                            ",cod_alambron = '" & cod_alambron & "' " &
                            ",num_ped = " & num_pedido & " " &
                             " WHERE consecutivo=" & consecutivoPpal

                lisSql.Add(sql)
            ElseIf permiso = "AUXILIAR" Then
                sql = "UPDATE J_orden_prod_tef SET " &
                      "prod_final =  '" & prod_final & "'" &
                       ",diam_min =  " & diam_min &
                       ",diam_max =  " & diam_max &
                   ",cant_prog = " & cant_prog &
                       ",diametro =  " & diametro &
                       ",origen =  " & origen &
                       ",materia_prima = '" & materia_prima & "'" &
                   ",trac_ini =  " & trac_ini &
                   " ,trac_fin =  " & trac_fin &
                   ",numPasos = " & numPasos &
                     ",calidad =  " & calidad &
                       ",nit = " & nit &
                           ",tipoCliente = " & tipoCliente &
                           ",id_maquina = '" & maquina & "'" &
                           ",mes = '" & mes & "'" &
                           ",ano = '" & ano & "'" &
                           ",notas_auditoria = (SELECT CASE WHEN notas_auditoria is null THEN '" & notas_auditoria & "' ELSE notas_auditoria + '" & notas_auditoria & "' END)" &
                           ",notas = '" & notas & "' " &
                           ",cod_alambron = '" & cod_alambron & "' " &
                           ",num_ped = " & num_pedido & " " &
                           " WHERE consecutivo=" & consecutivoPpal
                lisSql.Add(sql)
            Else
                MessageBox.Show("El usuario no puede modificar una orden de produccion")
            End If
        End If
        Return lisSql
    End Function
    'Procedimiento para automatizar creacion de ordenes en trefilación
    Private Sub auto_programar_ordenes()
        Dim sql As String
        Dim val_abiertas As String
        sql = "select cod_orden from J_det_orden_prod where cod_orden=" & consecutivoPpal & " and cerrado is null"
        val_abiertas = objOpsimpesLn.consultValorTodo(sql, "PRODUCCION")
        If val_abiertas = "" Then
            Dim fecha As String = objOpsimpesLn.cambiarFormatoFecha(Now)
            Dim ano As Integer = Now.Year
            Dim mes As Integer = Now.Month
            Dim cant_prog As String = txtCantProg.Text
            Dim cant_prod As String = sumarProdTotal()
            Dim cant_falta As Double = CDbl(cant_prog) - CDbl(cant_prod)
            If cant_falta > 0 Then
                Dim sql_prod As String
                sql_prod = "select costo_unitario from referencias where codigo='" & txtProdFinal.Text & "'"
                Dim costo_ref As String = objOpsimpesLn.consultValorTodo(sql_prod, "CORSAN")
                sql_prod = "select Promedio from v_promedio where codigo='" & txtMatPrima.Text & "' and ano=" & Now.Year & " and mes=" & Now.Month & ""
                Dim costo_alam As String = "2000"
                'objOpsimpesLn.consultValorTodo(sql_prod, "CORSAN")
                sql = "SELECT  MAX (consecutivo)+1 FROM J_orden_prod_tef"
                Dim new_cod_orden As String = objOpsimpesLn.consultValorTodo(sql, "PRODUCCION")
                sql = " INSERT INTO  J_orden_prod_tef (consecutivo, prod_final, diam_min, diam_max, cant_prog, diametro, origen, materia_prima, trac_ini, trac_fin, numPasos, calidad, nit, tipoCliente, fecha_prog, id_maquina, mes, ano,fecha_creacion,cod_alambron,notas_auditoria,costo_prod_final,costo_mat_prima,oculto,num_ped)" &
                  " SELECT '" & new_cod_orden & "', prod_final, diam_min, diam_max," & cant_falta & ", diametro, origen, materia_prima, trac_ini, trac_fin, numPasos, calidad, nit, tipoCliente, fecha_prog, id_maquina, '" & mes & "', '" & ano & "','" & fecha & "',cod_alambron,notas_auditoria," & costo_ref & ", " & costo_alam & ",0,num_ped  FROM  J_orden_prod_tef where consecutivo=" & consecutivoPpal & ""
                objOpSimplesLn.ejecutar(sql, "PRODUCCION")
            End If
        End If
    End Sub
    Private Sub armarSql(ByVal listCol As List(Of Object))
        Dim selectSql As String = ""
    End Sub
    Private Function guardarDetalle() As List(Of Object)
        Dim lisSql As New List(Of Object)
        Dim operario As String = cboOperariosTurno.SelectedValue
        Dim auxiliar As String = cboAuxiliar.SelectedValue
        Dim fec As String = ""
        Dim fec_c, turno As String
        fec_c = "" & System.DateTime.Now.Hour & ":" & System.DateTime.Now.Minute & ""
        If CDate(fec_c) >= "05:50" And CDate(fec_c) <= "13:49" Then
            turno = "1"
        ElseIf CDate(fec_c) >= "13:50" And CDate(fec_c) <= "21:49" Then
            turno = "2"
        ElseIf CDate(fec_c) >= "21:50" Or CDate(fec_c) <= "5:49" Then
            turno = "3"
        End If
        Dim resp As Boolean = False
        Dim sql As String = ""
        Dim maquina As String = cbo_maquina.SelectedValue
        Dim notas As String
        Dim fecha As String = CDate(Now)
        Dim fec_hora_ini As String = objOpSimplesLn.cambiarFormatoFecha(Now)
        fec_hora_ini = CDate(fec_hora_ini & " 00:01:00")
        Dim fecha_hora_fin As String = objOpSimplesLn.cambiarFormatoFecha(Now)
        fecha_hora_fin = CDate(fecha_hora_fin & " 05:45:00")

        If (CDate(fec_hora_ini) <= CDate(fecha) And CDate(fecha) <= CDate(fecha_hora_fin)) Then
            fec = objOpsimpesLn.cambiarFormatoFecha((Now.AddDays(-1)).Date)
        Else
            fec = objOpsimpesLn.cambiarFormatoFecha(Now.Date)
        End If
#Disable Warning BC42104 ' La variable 'turno' se usa antes de que se le haya asignado un valor. Podría darse una excepción de referencia NULL en tiempo de ejecución.
        If (turno = 0) Then
#Enable Warning BC42104 ' La variable 'turno' se usa antes de que se le haya asignado un valor. Podría darse una excepción de referencia NULL en tiempo de ejecución.
            turno = "null"
        End If
        If (maquina = 0) Then
            maquina = "null"
        End If
        notas = "N/A"
        txtNotasOperarios.Text = "N/A"
        Dim sqlConsec = ""
        If (consecutivoDet = 0) Then
            sqlConsec = "SELECT MAX (id_detalle) FROM J_det_orden_prod WHERE cod_orden =" & consecutivoPpal
            actualizarConsecutivoDet((obj_Ing_prodLn.consultar_valor(sqlConsec, "PRODUCCION")) + 1)
            sql = "INSERT INTO J_det_orden_prod " &
                                "(id_detalle,operario,cod_orden,fecha_prod,id_turno,notas,auxiliar) " &
                                    "VALUES " &
                           "(" & consecutivoDet & "," & operario & "," & consecutivoPpal & ",'" & fec & "'," & turno & ", '" & notas & "'," & auxiliar & ")"
            If turno <> "" Then
                lisSql.AddRange(objOrdenProdLn.crearPlanInsp(usuario, consecutivoPpal, consecutivoDet, turno))
                If txtProdFinal.Text.ToUpper() = "22B100142" Then
                    lisSql.AddRange(objOrdenProdLn.crearPlanInspCal142(usuario, consecutivoPpal, consecutivoDet, turno))
                Else
                    lisSql.AddRange(objOrdenProdLn.crearPlanInspCal(usuario, consecutivoPpal, consecutivoDet, turno))
                End If
            End If

        Else
                sql = "ThenUPDATE J_det_orden_prod SET " &
                       "notas = '" & notas & "'" &
                    " WHERE id_detalle =" & consecutivoDet & "AND cod_orden=" & consecutivoPpal
        End If
                lisSql.Add(sql)
        Return lisSql
    End Function
    Private Function guardarParo(ByVal fila As Integer) As Integer
        Dim sql As String = ""
        Dim numParo As Integer = dtgParo.Item("colCod", fila).Value
        Dim paro As String
        paro = CStr(numParo)
        Dim valor As Double = 0
        Dim resp As Integer = 0
        valor = dtgParo.Item("colTotal", fila).Value
        sql = "UPDATE J_det_orden_prod SET paro" & numParo & " = (CASE WHEN paro" & numParo & " is null  THEN " & valor & " ELSE paro" & numParo & " +" & valor & " END ) WHERE cod_orden = " & consecutivoPpal & " AND id_detalle = " & consecutivoDet & ""
        Return resp = obj_Ing_prodLn.ejecutar(sql, "PRODUCCION")



        Dim sqlm As String = ""
        Dim maquina As String = ""
        sqlm = "SELECT id_maquina FROM dbo.J_orden_prod_tef WHERE (consecutivo = " & consecutivoPpal & ")"
        maquina = obj_Ing_prodLn.listar_Estado(sqlm, "PRODUCCION")

        ''maquina 1
        If (maquina.Contains("2101")) Then
            Dim update_estado_M As String = CInt(objOpSimplesLn.modificar_estadoMP(maquina, "PRODUCCION"))
            Dim update_estado_M_P As String = CInt(objOpSimplesLn.modificar_estadoMPN(maquina, paro, "PRODUCCION"))
        End If
        ''maquina 2
        If (maquina.Contains("2102")) Then
            Dim update_estado_M As String = CInt(objOpSimplesLn.modificar_estadoMP(maquina, "PRODUCCION"))
            Dim update_estado_M_P As String = CInt(objOpSimplesLn.modificar_estadoMPN(maquina, paro, "PRODUCCION"))
        End If
        ''maquina 3
        If (maquina.Contains("2103")) Then
            Dim update_estado_M As String = CInt(objOpSimplesLn.modificar_estadoMP(maquina, "PRODUCCION"))
            Dim update_estado_M_P As String = CInt(objOpSimplesLn.modificar_estadoMPN(maquina, paro, "PRODUCCION"))
            MessageBox.Show("Bienvenido Usuario: " + paro,
                        "paro registrado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information)
        End If
        ''maquina 4
        If (maquina.Contains("2104")) Then
            Dim update_estado_M As String = CInt(objOpSimplesLn.modificar_estadoMP(maquina, "PRODUCCION"))
            Dim update_estado_M_P As String = CInt(objOpSimplesLn.modificar_estadoMPN(maquina, paro, "PRODUCCION"))
        End If
        ''maquina 5
        If (maquina.Contains("2105")) Then
            Dim update_estado_M As String = CInt(objOpSimplesLn.modificar_estadoMP(maquina, "PRODUCCION"))
            Dim update_estado_M_P As String = CInt(objOpSimplesLn.modificar_estadoMPN(maquina, paro, "PRODUCCION"))
        End If
        ''maquina 6
        If (maquina.Contains("2116")) Then
            Dim update_estado_M As String = CInt(objOpSimplesLn.modificar_estadoMP(maquina, "PRODUCCION"))
            Dim update_estado_M_P As String = CInt(objOpSimplesLn.modificar_estadoMPN(maquina, paro, "PRODUCCION"))
        End If
        ''maquina 7
        If (maquina.Contains("2118")) Then
            Dim update_estado_M As String = CInt(objOpSimplesLn.modificar_estadoMP(maquina, "PRODUCCION"))
            Dim update_estado_M_P As String = CInt(objOpSimplesLn.modificar_estadoMPN(maquina, paro, "PRODUCCION"))
        End If
        ''maquina 8
        If (maquina.Contains("2119")) Then
            Dim update_estado_M As String = CInt(objOpSimplesLn.modificar_estadoMP(maquina, "PRODUCCION"))
            Dim update_estado_M_P As String = CInt(objOpSimplesLn.modificar_estadoMPN(maquina, paro, "PRODUCCION"))
        End If
        ''maquina 9
        If (maquina.Contains("2121")) Then
            Dim update_estado_M As String = CInt(objOpSimplesLn.modificar_estadoMP(maquina, "PRODUCCION"))
            Dim update_estado_M_P As String = CInt(objOpSimplesLn.modificar_estadoMPN(maquina, paro, "PRODUCCION"))
        End If



    End Function
    Private Function guardarCambHileras(ByVal fila As Integer, ByVal col As Integer) As Boolean
        Dim lista As New List(Of Object)
        Dim colDb As String = ""
        Dim numPaso As Integer = 0
        Dim valor As String = 0
        Dim sqlConsulta As String = ""
        Select Case dtgDiametros.Columns(col).Name
            Case "colCamHil1"
                colDb = "cambio1"
            Case "colCamHil2"
                colDb = "cambio2"
            Case "colCamHil3"
                colDb = "cambio3"
            Case "colCamHil4"
                colDb = "cambio4"
        End Select
        Dim sqlInsert As String = "INSERT INTO J_cambio_hilera " &
                             "(cod_orden,cod_det,numPaso," & colDb & ") " &
                            "VALUES "
        Dim sqlUpdate As String = "UPDATE J_cambio_hilera SET "
        Dim sql As String = ""
        Dim resp As String = ""
        valor = dtgDiametros.Item(col, fila).Value
        numPaso = dtgDiametros.Item("colPaso", fila).Value
        sqlConsulta = "SELECT cod_orden FROM J_cambio_hilera WHERE numPaso = " & numPaso & " AND cod_orden = " & consecutivoPpal & " AND cod_det = " & consecutivoDet
        resp = obj_Ing_prodLn.consultar_valor(sqlConsulta, "PRODUCCION")
        If (resp = "0") Then
            sql = sqlInsert & "(" & consecutivoPpal & "," & consecutivoDet & "," & numPaso & "," & valor & ")"
        Else
            sql = sqlUpdate & " " & colDb & " = " & valor & " WHERE numPaso =" & numPaso & " AND cod_orden=" & consecutivoPpal & " AND cod_det=" & consecutivoDet
        End If
        lista.Add(sql)

        Return obj_Ing_prodLn.ExecuteSqlTransaction(lista, "PRODUCCION")
    End Function
    Private Function sumarCol(ByVal col As String, ByVal dtg As DataGridView) As Double
        Dim sum As Double = 0
        For i = 0 To dtg.RowCount - 1
            If Not (IsDBNull(dtg.Item(col, i).Value)) Then
                sum += dtg.Item(col, i).Value
            End If
        Next
        Return sum
    End Function
    Private Function existeUsuarioTurno() As Boolean
        Dim fec As String = objOpsimpesLn.cambiarFormatoFecha(Now.Date)
        Dim sql As String = "SELECT operario  FROM J_det_orden_prod WHERE cod_orden = " & consecutivoPpal & " AND operario = " & cbo_operario.SelectedValue & " AND fecha_prod = '" & fec & "' AND anulado is null "
        Dim resp As String = obj_Ing_prodLn.consultar_valor(sql, "PRODUCCION")
        If (resp = "0") Then
            Return False
        Else
            Return True
        End If
    End Function
    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If (validarEncabezado()) Then
            Dim listaSql As New List(Of Object)
            Dim sql As String
            Dim contar As Integer = 0
            Dim resp As Boolean = False
            Dim mes As String = cbo_fec_orden.Value.Month
            Dim ano As String = cbo_fec_orden.Value.Year
            Dim cont_rec As Boolean = txtMatPrima.Text.Contains("22R")
            Dim cont_brilla As Boolean = txtMatPrima.Text.Contains("22B")
            orden_existe = ordenRepetida()
            listaSql.AddRange(guardarConsol)
            num_pedido = 0
            sql = " select count(cod_orden) from J_det_orden_prod where cod_orden=" & consecutivoPpal & ""
            contar = objOpsimpesLn.consultValorTodo(sql, "PRODUCCION")
            If permiso = "AUXILIAR" Then
                If contar = 0 Then
                    resp = obj_Ing_prodLn.ExecuteSqlTransaction(listaSql, "PRODUCCION")
                Else
                    resp = False
                End If
            Else
                resp = obj_Ing_prodLn.ExecuteSqlTransaction(listaSql, "PRODUCCION")
            End If
            If (resp) Then
                If cont_rec Then
                    Dim frm As New frm_solicitud_trefscae
                    frm.guardar_automatico(txtMatPrima.Text, txtCantProg.Text, mes, ano)
                End If
                If cont_brilla Then
                    Dim frm As New frm_solicitud_trefscal
                    frm.guardar_automatico(txtMatPrima.Text, txtCantProg.Text, mes, ano)
                End If
                MessageBox.Show("El encabezado de la planilla fue actualizado en forma exitosa! ", "Correcto!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                cargarAdminProd(txtConsulNumOrd.Text)
                actualizarConsecutivoPpal(0)
                actualizarConsecutivoDet(0)
                nuevo()
                dtgDiametros.Rows.Clear()
                dtgParo.DataSource = Nothing
                dtgPlanAsociadas.DataSource = Nothing
                TblPpal.SelectedTab = tblOrdenProd
            Else
                MessageBox.Show("Error al ingresar El encabezado a la base de datos o la orden que esta tratando de modificar ya se ha trabajado,verifique que todos los datos esten correctos ò comuniquese con el administrador del sistema!,NO SE GUARDO LA PLANILLA! ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub
    'Pone como horometro inicial el horometro final de la planilla anterior
    'Private Sub cargar_Horometro()
    '    Dim sql As String
    '    Dim hor_final As String
    '    sql = "select HorometroFin from J_det_orden_prod where cod_orden=" & consecutivoPpal & " and id_detalle=" & consecutivoDet - 1
    '    hor_final = objOpsimpesLn.consultValorTodo(sql, "PRODUCCION")
    '    If hor_final = "" Then
    '        hor_final = "0"
    '    End If
    '    txtHoraIni.Text = hor_final
    '    txtHoraIni.Enabled = False
    'End Sub
    Private Function ordenRepetida() As String
        Dim sql As String = "Select consecutivo  " &
                             "FROM J_orden_prod_tef WHERE consecutivo = " & consecutivoPpal & ""
        Return obj_Ing_prodLn.consultValor(sql, "PRODUCCION")
    End Function
    Private Function validarBodegaConCliente(ByVal codigo As String) As Boolean
        If (chkInterno.Checked) Then
            If (txtProdFinal.Text(0) = "2") Then
                Return True
            End If
        Else
            If (txtProdFinal.Text(0) = "3") Then
                Return True
            End If
        End If
        Return False
    End Function
    Private Function validarEncabezado() As Boolean
        If (cbo_maquina.Text <> "Seleccione") Then
            If (txtDiametro.Text <> "") Then
                If IsNumeric(txtDiametro.Text) Then
                    If (txtDiametro.Text < 20) Then
                        If (txt_cod_alambron.Text <> "") Then
                            If (objOpsimpesLn.validarCodigo(txt_cod_alambron.Text)) Then
                                If (cboCalidad.Text <> "Seleccione") Then
                                    If (cboCliente.Text <> "Seleccione") Then
                                        If (cboOrigen.Text <> "Seleccione") Then
                                            If (txtMatPrima.Text <> "") Then
                                                If (objOpsimpesLn.validarCodigo(txtMatPrima.Text)) Then
                                                    If (txtDiaMin.Text <> "") Then
                                                        If IsNumeric(txtDiaMin.Text) Then
                                                            If IsNumeric(txtDiamMAx.Text) Then
                                                                If (txtDiamMAx.Text <> "") Then
                                                                    If (Convert.ToDouble(txtDiaMin.Text) < 20 And Convert.ToDouble(txtDiamMAx.Text) < 20) Then
                                                                        If (Convert.ToDouble(txtDiamMAx.Text) >= Convert.ToDouble(txtDiaMin.Text)) Then
                                                                            If (txtTracMin.Text <> "") Then
                                                                                If (txtTracMax.Text <> "") Then
                                                                                    If (Convert.ToDouble(txtTracMax.Text) >= Convert.ToDouble(txtTracMin.Text)) Then
                                                                                        If (txtCantProg.Text <> "") Then
                                                                                            If (txtCantProg.Text > 0) Then
                                                                                                If (txtProdFinal.Text <> "") Then
                                                                                                    If (objOpsimpesLn.validarCodigo(txtProdFinal.Text)) Then
                                                                                                        If (objOpsimpesLn.validarCodigoEstado(txtProdFinal.Text)) Then
                                                                                                            If (validarBodegaConCliente(txtProdFinal.Text)) Then
                                                                                                                If (cboNumPasos.Text <> "Seleccione") Then

                                                                                                                    Return True

                                                                                                                Else
                                                                                                                    MessageBox.Show("Seleccione número de pasos", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                                                                                                End If
                                                                                                            Else
                                                                                                                MessageBox.Show("El cliente no corresponde con la bodega del producto final seleccionado,La planilla no se creo", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                                                                                            End If
                                                                                                        Else
                                                                                                            MessageBox.Show("El codigo " & txtProdFinal.Text & " ingresado para el producto final no esta activo!,NO SE GUARDO LA PLANILLA!", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                                                                                        End If
                                                                                                    Else
                                                                                                        MessageBox.Show("El codigo " & txtProdFinal.Text & " ingresado para el producto final no existe verifique!,NO SE GUARDO LA PLANILLA!", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                                                                                    End If
                                                                                                Else
                                                                                                    MessageBox.Show("Ingrese un producto final", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                                                                                End If
                                                                                            Else
                                                                                                MessageBox.Show("La cantidad programada no puede ser = 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                                                                            End If
                                                                                        Else
                                                                                            MessageBox.Show("Ingrese una cantidad programada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                                                                        End If
                                                                                    Else
                                                                                        MessageBox.Show("La tracción minima no puede ser mayor a la tracción maxima", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                                                                    End If
                                                                                Else
                                                                                    MessageBox.Show("Ingrese una tracción maxima", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                                                                End If
                                                                            Else
                                                                                MessageBox.Show("Ingrese una tracción minima", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                                                            End If
                                                                        Else
                                                                            MessageBox.Show("El diametro minimo no puede ser mayor al diametro maximo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                                                        End If
                                                                    Else
                                                                        MessageBox.Show("Verifique que el valor del diametro minimo y maximo sean correctos (punto Decimal)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                                                    End If
                                                                Else
                                                                    MessageBox.Show("Ingrese un diametro maximo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                                                End If
                                                            Else
                                                                MessageBox.Show("El diametro maximo debe ser númerico(verifique que solo tenga un punto Decimal)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                                            End If
                                                        Else
                                                            MessageBox.Show("El diametro minimo debe ser númerico(verifique que solo tenga un punto Decimal)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                                        End If
                                                    Else
                                                        MessageBox.Show("Ingrese un diametro minimo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                                    End If
                                                Else
                                                    MessageBox.Show("El codigo " & txtMatPrima.Text & " ingresado para la materia prima no exsiste verifique!,NO SE GUARDO LA PLANILLA!", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                                End If
                                            Else
                                                MessageBox.Show("Ingrese una materia prima", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                            End If
                                        Else
                                            MessageBox.Show("Seleccione un origen del alambron", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                        End If
                                    Else
                                        MessageBox.Show("Seleccione una cliente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    End If
                                Else
                                    MessageBox.Show("Seleccione una calidad", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                End If
                            Else
                                MessageBox.Show("El código de alambrón no existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End If
                        Else
                            MessageBox.Show("Ingrese código del alambrón!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    Else
                        MessageBox.Show("Verifique que el diametro la materia prima sea correcto (revise el punto Decimal)!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Else
                    MessageBox.Show("El diametro del alambron debe ser númerico (verifique que solo tenga un punto Decimal)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                MessageBox.Show("Debe seleccionar el diametro del alambron!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            MessageBox.Show("Debe seleccionar la maquina!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        Return False
    End Function
    Private Sub dtgParoCellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgParo.CellContentClick
        Dim fila As Integer = e.RowIndex
        Dim col As String = dtgParo.Columns(e.ColumnIndex).Name
        Dim sqlm As String = ""
        Dim maquina As String = ""
        sqlm = "SELECT id_maquina FROM dbo.J_orden_prod_tef WHERE (consecutivo = " & consecutivoPpal & ")"
        maquina = obj_Ing_prodLn.listar_Estado(sqlm, "PRODUCCION")
        If (fila >= 0) Then
            If (col = "btnBorrar") Then
                dtgParo.Rows.RemoveAt(e.RowIndex)
                imgTparo.Visible = False
            ElseIf (col = "btnInicioFin") Then
                If (dtgParo.Item("colCod", fila).Value <> Nothing) Then

                    If (dtgParo.Item("ColHini", fila).Value <> Nothing And dtgParo.Item("ColHfin", fila).Value = Nothing) Then
                        terminarParoAbierto()
                        colCod.ReadOnly = False
                    ElseIf (dtgParo.Item("ColHfin", fila).Value = Nothing) Then
                        If (imgTparo.Visible = False) Then
                            imgTparo.Visible = True
                            horaIniParo = Now
                            dtgParo.Item("ColHini", fila).Value = Format(Now, "HH:mm")
                            dtgParo.Item("btnInicioFin", fila).Value = My.Resources.stopParo
                            updateEstadoMaqAct("En paro")
#Disable Warning BC42303 ' El comentario XML no puede aparecer en un método o una propiedad. Se omitirá el comentario XML.
                            ''' PONER MAQUINA EN PARO
                            '''  ''maquina 1
                            If (maquina.Contains("2101")) Then
#Enable Warning BC42303 ' El comentario XML no puede aparecer en un método o una propiedad. Se omitirá el comentario XML.
                                Dim update_estado_M As String = CInt(objOpSimplesLn.modificar_estadoMP(maquina, "PRODUCCION"))
                                Dim update_estado_M_P As String = CInt(objOpSimplesLn.modificar_estadoMPN(maquina, dtgParo.Item("colCod", fila).Value, "PRODUCCION"))
                            End If
                            ''maquina 2
                            If (maquina.Contains("2102")) Then
                                Dim update_estado_M As String = CInt(objOpSimplesLn.modificar_estadoMP(maquina, "PRODUCCION"))
                                Dim update_estado_M_P As String = CInt(objOpSimplesLn.modificar_estadoMPN(maquina, dtgParo.Item("colCod", fila).Value, "PRODUCCION"))
                            End If
                            ''maquina 3
                            If (maquina.Contains("2103")) Then
                                Dim update_estado_M As String = CInt(objOpSimplesLn.modificar_estadoMP(maquina, "PRODUCCION"))
                                Dim update_estado_M_P As String = CInt(objOpSimplesLn.modificar_estadoMPN(maquina, dtgParo.Item("colCod", fila).Value, "PRODUCCION"))
                            End If
                            ''maquina 4
                            If (maquina.Contains("2104")) Then
                                Dim update_estado_M As String = CInt(objOpSimplesLn.modificar_estadoMP(maquina, "PRODUCCION"))
                                Dim update_estado_M_P As String = CInt(objOpSimplesLn.modificar_estadoMPN(maquina, dtgParo.Item("colCod", fila).Value, "PRODUCCION"))
                            End If
                            ''maquina 5
                            If (maquina.Contains("2105")) Then
                                Dim update_estado_M As String = CInt(objOpSimplesLn.modificar_estadoMP(maquina, "PRODUCCION"))
                                Dim update_estado_M_P As String = CInt(objOpSimplesLn.modificar_estadoMPN(maquina, dtgParo.Item("colCod", fila).Value, "PRODUCCION"))
                            End If
                            ''maquina 6
                            If (maquina.Contains("2116")) Then
                                Dim update_estado_M As String = CInt(objOpSimplesLn.modificar_estadoMP(maquina, "PRODUCCION"))
                                Dim update_estado_M_P As String = CInt(objOpSimplesLn.modificar_estadoMPN(maquina, dtgParo.Item("colCod", fila).Value, "PRODUCCION"))
                            End If
                            ''maquina 7
                            If (maquina.Contains("2118")) Then
                                Dim update_estado_M As String = CInt(objOpSimplesLn.modificar_estadoMP(maquina, "PRODUCCION"))
                                Dim update_estado_M_P As String = CInt(objOpSimplesLn.modificar_estadoMPN(maquina, dtgParo.Item("colCod", fila).Value, "PRODUCCION"))
                            End If
                            ''maquina 8
                            If (maquina.Contains("2119")) Then
                                Dim update_estado_M As String = CInt(objOpSimplesLn.modificar_estadoMP(maquina, "PRODUCCION"))
                                Dim update_estado_M_P As String = CInt(objOpSimplesLn.modificar_estadoMPN(maquina, dtgParo.Item("colCod", fila).Value, "PRODUCCION"))
                            End If
                            ''maquina 9
                            If (maquina.Contains("2121")) Then
                                Dim update_estado_M As String = CInt(objOpSimplesLn.modificar_estadoMP(maquina, "PRODUCCION"))
                                Dim update_estado_M_P As String = CInt(objOpSimplesLn.modificar_estadoMPN(maquina, dtgParo.Item("colCod", fila).Value, "PRODUCCION"))
                            End If

                            
#Disable Warning BC42303 ' El comentario XML no puede aparecer en un método o una propiedad. Se omitirá el comentario XML.
''' 



                            If dtgParo.Item("colCod", fila).Value = 6 Or dtgParo.Item("colCod", fila).Value = 7 Or dtgParo.Item("colCod", fila).Value = 13 Then
#Enable Warning BC42303 ' El comentario XML no puede aparecer en un método o una propiedad. Se omitirá el comentario XML.
                                If My.Computer.Network.Ping("www.google.com", 3000) Then
                                    enviarCorreoParo(consecutivoPpal, consecutivoDet, dtgParo.Item("colCod", fila).Value)
                                Else
                                    MessageBox.Show("No hay internet por lo tanto no se enviara el correo.", "Enviar correo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                End If

                            End If
                            colCod.ReadOnly = True
                        Else
                            MessageBox.Show("Actualmente la maquina se encuentra en paro! ", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    End If

                Else
                    MessageBox.Show("Primero se debe ingresar el código del paro! ", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            ElseIf (col = "colAdd") Then
                dtgParo.Rows.Add()
            End If
        End If
    End Sub
    Private Sub cboNumPasos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboNumPasos.SelectedIndexChanged
        If (txtDiametro.Text <> "" And txtDiaMin.Text <> "" And txtDiamMAx.Text <> "") Then
            cargaComp = False
            Dim pasos As Integer = 0
            Dim diametro As String = 0
            Dim diamMin As String = 0
            Dim diamMax As String = 0
            dtgDiametros.Rows.Clear()
            If (cboNumPasos.Text <> "Seleccione") Then
                pasos = Convert.ToInt16(cboNumPasos.Text)
                For i = 0 To pasos - 1
                    dtgDiametros.Rows.Add()
                    dtgDiametros.Item("colPaso", i).Value = i + 1
                    dtgDiametros.Item("colLub", i).Value = "Sodico-Calcico"
                Next
                diametro = txtDiametro.Text
                diamMin = txtDiaMin.Text
                diamMax = txtDiamMAx.Text
                diametroHilera(pasos, diametro, diamMin, diamMax)
                dtgDiametros.Columns("colCalReal").DefaultCellStyle.Format = "n2"
                dtgDiametros.Columns("colDiamHilPres").DefaultCellStyle.Format = "##. ##%"
            End If
            cargaComp = True
        Else
            cboNumPasos.Text = ""
            MessageBox.Show("Los campos DIAMETRO, DIAMETRO MIN Y DAMETRO MAX son requeridos! ", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
    Private Sub diametroHilera(ByVal pasos As Integer, ByVal sDiametro As String, ByVal sDiamMin As String, ByVal sDiamMax As String)
        Dim diamMin As Double
        Dim diamMax As Double
        Dim diametro As Double
        'If (idioma = "es-CO") Then
        '    sDiametro = Replace(sDiametro, ".", ",")
        '    sDiamMin = Replace(sDiamMin, ".", ",")
        '    sDiamMax = Replace(sDiamMax, ".", ",")
        'End If
        diametro = Convert.ToDouble(sDiametro)
        diamMin = Convert.ToDouble(sDiamMin)
        diamMax = Convert.ToDouble(sDiamMax)

        Dim amplitudPend As Double = 0
        Dim porcRed As Double = 0
        Dim redMedia As Double = (1 - Math.Exp(-2 * Math.Log(diamMin / diamMax) / pasos))
        'Dim redMedia As Double = 0.35
        Dim resFinal As Double = (redMedia / (pasos)) / amplitudPend
        Dim correccion As Double = 0

        Select Case pasos
            Case 3
                amplitudPend = 20
                correccion = 20
                porcRed = (1 - (diamMin / diametro) ^ 2)
                redMedia = (1 - Math.Exp(-2 * Math.Log(diametro / diamMin) / pasos))
                resFinal = (redMedia / (pasos)) / amplitudPend

                dtgDiametros.Item("colA", 1).Value = 1
                dtgDiametros.Item("colA", 0).Value = 2
                dtgDiametros.Item("colA", 2).Value = 3

                dtgDiametros.Item("colDiamHilPres", 1).Value = redMedia
                dtgDiametros.Item("colDiamHilPres", 0).Value = resFinal + (dtgDiametros.Item("colA", 1).Value * redMedia)
                dtgDiametros.Item("colDiamHilPres", 2).Value = redMedia

                dtgDiametros.Item("colCalReal", 0).Value = ((diametro ^ 2) * (1 - dtgDiametros.Item("colDiamHilPres", 0).Value)) ^ (1 / 2)
                dtgDiametros.Item("colCalReal", 1).Value = ((dtgDiametros.Item("colCalReal", 0).Value ^ 2) * (1 - redMedia)) ^ (1 / 2)
                dtgDiametros.Item("colCalReal", 2).Value = ((dtgDiametros.Item("colCalReal", 1).Value ^ 2) * (1 - dtgDiametros.Item("colDiamHilPres", 2).Value)) ^ (1 / 2)


            Case 4
                correccion = 2
                amplitudPend = 10
                porcRed = (1 - (diamMin / diametro) ^ 2)
                redMedia = (1 - Math.Exp(-2 * Math.Log(diametro / diamMin) / pasos))
                resFinal = (redMedia / (pasos)) / amplitudPend
                dtgDiametros.Item("colA", 0).Value = 0
                dtgDiametros.Item("colA", 1).Value = 1
                dtgDiametros.Item("colA", 2).Value = 2
                dtgDiametros.Item("colA", 3).Value = 3

                dtgDiametros.Item("colDiamHilPres", 2).Value = redMedia
                dtgDiametros.Item("colDiamHilPres", 0).Value = redMedia + (resFinal * dtgDiametros.Item("colA", 2).Value)
                dtgDiametros.Item("colDiamHilPres", 1).Value = redMedia + (dtgDiametros.Item("colA", 1).Value * resFinal)
                dtgDiametros.Item("colDiamHilPres", 3).Value = redMedia - ((1 + (dtgDiametros.Item("colA", 1).Value * correccion)) * (resFinal * dtgDiametros.Item("colA", 1).Value)) '0.270926227


                dtgDiametros.Item("colCalReal", 0).Value = ((diametro ^ 2) * (1 - dtgDiametros.Item("colDiamHilPres", 0).Value)) ^ (1 / 2)

                dtgDiametros.Item("colCalReal", 1).Value = ((dtgDiametros.Item("colCalReal", 0).Value ^ 2) * (1 - dtgDiametros.Item("colDiamHilPres", 1).Value)) ^ (1 / 2)

                dtgDiametros.Item("colCalReal", 2).Value = ((dtgDiametros.Item("colCalReal", 1).Value ^ 2) * (1 - dtgDiametros.Item("colDiamHilPres", 2).Value)) ^ (1 / 2)

                dtgDiametros.Item("colCalReal", 3).Value = ((dtgDiametros.Item("colCalReal", 2).Value ^ 2) * (1 - dtgDiametros.Item("colDiamHilPres", 3).Value)) ^ (1 / 2)


            Case 5
                correccion = 0
                amplitudPend = 20
                porcRed = (1 - (diamMin / diametro) ^ 2)
                redMedia = (1 - Math.Exp(-2 * Math.Log(diametro / diamMin) / pasos))
                resFinal = (redMedia / (pasos)) / amplitudPend

                dtgDiametros.Item("colA", 0).Value = 1
                dtgDiametros.Item("colA", 1).Value = 2
                dtgDiametros.Item("colA", 2).Value = 3
                dtgDiametros.Item("colA", 3).Value = 4
                dtgDiametros.Item("colA", 4).Value = 5

                dtgDiametros.Item("colDiamHilPres", 2).Value = redMedia
                dtgDiametros.Item("colDiamHilPres", 0).Value = redMedia + (resFinal * dtgDiametros.Item("colA", 1).Value)
                dtgDiametros.Item("colDiamHilPres", 1).Value = redMedia + (dtgDiametros.Item("colA", 0).Value * resFinal)
                dtgDiametros.Item("colDiamHilPres", 3).Value = redMedia - ((1 + (dtgDiametros.Item("colA", 0).Value * correccion)) * (resFinal * dtgDiametros.Item("colA", 0).Value))
                dtgDiametros.Item("colDiamHilPres", 4).Value = redMedia - ((1 + (dtgDiametros.Item("colA", 1).Value * correccion)) * (resFinal * dtgDiametros.Item("colA", 1).Value))


                dtgDiametros.Item("colCalReal", 0).Value = ((diametro ^ 2) * (1 - dtgDiametros.Item("colDiamHilPres", 0).Value)) ^ (1 / 2)
                dtgDiametros.Item("colCalReal", 1).Value = ((dtgDiametros.Item("colCalReal", 0).Value ^ 2) * (1 - dtgDiametros.Item("colDiamHilPres", 1).Value)) ^ (1 / 2)
                dtgDiametros.Item("colCalReal", 2).Value = ((dtgDiametros.Item("colCalReal", 1).Value ^ 2) * (1 - dtgDiametros.Item("colDiamHilPres", 2).Value)) ^ (1 / 2)
                dtgDiametros.Item("colCalReal", 3).Value = ((dtgDiametros.Item("colCalReal", 2).Value ^ 2) * (1 - dtgDiametros.Item("colDiamHilPres", 3).Value)) ^ (1 / 2)
                dtgDiametros.Item("colCalReal", 4).Value = ((dtgDiametros.Item("colCalReal", 3).Value ^ 2) * (1 - dtgDiametros.Item("colDiamHilPres", 4).Value)) ^ (1 / 2)

            Case 6
                amplitudPend = 20
                correccion = 0.6
                porcRed = (1 - (diamMin / diametro) ^ 2)
                redMedia = (1 - Math.Exp(-2 * Math.Log(diametro / diamMin) / pasos))
                resFinal = (redMedia / (pasos)) / amplitudPend

                dtgDiametros.Item("colA", 0).Value = 0
                dtgDiametros.Item("colA", 1).Value = 1
                dtgDiametros.Item("colA", 2).Value = 2
                dtgDiametros.Item("colA", 3).Value = 3
                dtgDiametros.Item("colA", 4).Value = 4
                dtgDiametros.Item("colA", 5).Value = 5

                dtgDiametros.Item("colDiamHilPres", 3).Value = redMedia
                dtgDiametros.Item("colDiamHilPres", 0).Value = redMedia + (resFinal * dtgDiametros.Item("colA", 3).Value)
                dtgDiametros.Item("colDiamHilPres", 1).Value = redMedia + (resFinal * dtgDiametros.Item("colA", 2).Value)
                dtgDiametros.Item("colDiamHilPres", 2).Value = redMedia + (dtgDiametros.Item("colA", 1).Value * resFinal)
                dtgDiametros.Item("colDiamHilPres", 4).Value = redMedia - ((1 + (dtgDiametros.Item("colA", 1).Value * correccion)) * (resFinal * dtgDiametros.Item("colA", 1).Value))
                dtgDiametros.Item("colDiamHilPres", 5).Value = redMedia - ((1 + (dtgDiametros.Item("colA", 2).Value * correccion)) * (resFinal * dtgDiametros.Item("colA", 2).Value))

                dtgDiametros.Item("colCalReal", 0).Value = ((diametro ^ 2) * (1 - dtgDiametros.Item("colDiamHilPres", 0).Value)) ^ (1 / 2)
                dtgDiametros.Item("colCalReal", 1).Value = ((dtgDiametros.Item("colCalReal", 0).Value ^ 2) * (1 - dtgDiametros.Item("colDiamHilPres", 1).Value)) ^ (1 / 2)
                dtgDiametros.Item("colCalReal", 2).Value = ((dtgDiametros.Item("colCalReal", 1).Value ^ 2) * (1 - dtgDiametros.Item("colDiamHilPres", 2).Value)) ^ (1 / 2)
                dtgDiametros.Item("colCalReal", 3).Value = ((dtgDiametros.Item("colCalReal", 2).Value ^ 2) * (1 - dtgDiametros.Item("colDiamHilPres", 3).Value)) ^ (1 / 2)
                dtgDiametros.Item("colCalReal", 4).Value = ((dtgDiametros.Item("colCalReal", 3).Value ^ 2) * (1 - dtgDiametros.Item("colDiamHilPres", 4).Value)) ^ (1 / 2)
                dtgDiametros.Item("colCalReal", 5).Value = ((dtgDiametros.Item("colCalReal", 4).Value ^ 2) * (1 - dtgDiametros.Item("colDiamHilPres", 5).Value)) ^ (1 / 2)

            Case 7
                amplitudPend = 20
                correccion = 0.02
                porcRed = (1 - (diamMin / diametro) ^ 2)
                redMedia = (1 - Math.Exp(-2 * Math.Log(diametro / diamMin) / pasos))
                resFinal = (redMedia / (pasos)) / amplitudPend

                dtgDiametros.Item("colA", 0).Value = 1
                dtgDiametros.Item("colA", 1).Value = 2
                dtgDiametros.Item("colA", 2).Value = 3
                dtgDiametros.Item("colA", 3).Value = 4
                dtgDiametros.Item("colA", 4).Value = 5
                dtgDiametros.Item("colA", 5).Value = 6
                dtgDiametros.Item("colA", 6).Value = 7

                dtgDiametros.Item("colDiamHilPres", 3).Value = redMedia
                dtgDiametros.Item("colDiamHilPres", 0).Value = redMedia + (resFinal * dtgDiametros.Item("colA", 2).Value)
                dtgDiametros.Item("colDiamHilPres", 1).Value = redMedia + (resFinal * dtgDiametros.Item("colA", 1).Value)
                dtgDiametros.Item("colDiamHilPres", 2).Value = redMedia + (dtgDiametros.Item("colA", 0).Value * resFinal)
                dtgDiametros.Item("colDiamHilPres", 4).Value = redMedia - ((1 + (dtgDiametros.Item("colA", 0).Value * correccion)) * (resFinal * dtgDiametros.Item("colA", 0).Value))
                dtgDiametros.Item("colDiamHilPres", 5).Value = redMedia - ((1 + (dtgDiametros.Item("colA", 1).Value * correccion)) * (resFinal * dtgDiametros.Item("colA", 1).Value))
                dtgDiametros.Item("colDiamHilPres", 6).Value = redMedia - ((1 + (dtgDiametros.Item("colA", 2).Value * correccion)) * (resFinal * dtgDiametros.Item("colA", 2).Value))


                dtgDiametros.Item("colCalReal", 0).Value = ((diametro ^ 2) * (1 - dtgDiametros.Item("colDiamHilPres", 0).Value)) ^ (1 / 2)
                dtgDiametros.Item("colCalReal", 1).Value = ((dtgDiametros.Item("colCalReal", 0).Value ^ 2) * (1 - dtgDiametros.Item("colDiamHilPres", 1).Value)) ^ (1 / 2)
                dtgDiametros.Item("colCalReal", 2).Value = ((dtgDiametros.Item("colCalReal", 1).Value ^ 2) * (1 - dtgDiametros.Item("colDiamHilPres", 2).Value)) ^ (1 / 2)
                dtgDiametros.Item("colCalReal", 3).Value = ((dtgDiametros.Item("colCalReal", 2).Value ^ 2) * (1 - dtgDiametros.Item("colDiamHilPres", 3).Value)) ^ (1 / 2)
                dtgDiametros.Item("colCalReal", 4).Value = ((dtgDiametros.Item("colCalReal", 3).Value ^ 2) * (1 - dtgDiametros.Item("colDiamHilPres", 4).Value)) ^ (1 / 2)
                dtgDiametros.Item("colCalReal", 5).Value = ((dtgDiametros.Item("colCalReal", 4).Value ^ 2) * (1 - dtgDiametros.Item("colDiamHilPres", 5).Value)) ^ (1 / 2)
                dtgDiametros.Item("colCalReal", 6).Value = ((dtgDiametros.Item("colCalReal", 5).Value ^ 2) * (1 - dtgDiametros.Item("colDiamHilPres", 6).Value)) ^ (1 / 2)


            Case 8
                amplitudPend = 50
                correccion = 0.3
                porcRed = (1 - (diamMin / diametro) ^ 2)
                redMedia = (1 - Math.Exp(-2 * Math.Log(diametro / diamMin) / pasos))
                resFinal = (redMedia / (pasos)) / amplitudPend

                dtgDiametros.Item("colA", 0).Value = 1
                dtgDiametros.Item("colA", 1).Value = 2
                dtgDiametros.Item("colA", 2).Value = 3
                dtgDiametros.Item("colA", 3).Value = 4
                dtgDiametros.Item("colA", 4).Value = 5
                dtgDiametros.Item("colA", 5).Value = 6
                dtgDiametros.Item("colA", 6).Value = 7
                dtgDiametros.Item("colA", 7).Value = 8

                dtgDiametros.Item("colDiamHilPres", 4).Value = redMedia
                dtgDiametros.Item("colDiamHilPres", 0).Value = redMedia + (resFinal * dtgDiametros.Item("colA", 3).Value)
                dtgDiametros.Item("colDiamHilPres", 1).Value = redMedia + (resFinal * dtgDiametros.Item("colA", 2).Value)
                dtgDiametros.Item("colDiamHilPres", 2).Value = redMedia + (resFinal * dtgDiametros.Item("colA", 1).Value)
                dtgDiametros.Item("colDiamHilPres", 3).Value = redMedia + (dtgDiametros.Item("colA", 0).Value * resFinal)
                dtgDiametros.Item("colDiamHilPres", 5).Value = redMedia - ((1 + (dtgDiametros.Item("colA", 0).Value * correccion)) * (resFinal * dtgDiametros.Item("colA", 0).Value))
                dtgDiametros.Item("colDiamHilPres", 6).Value = redMedia - ((1 + (dtgDiametros.Item("colA", 1).Value * correccion)) * (resFinal * dtgDiametros.Item("colA", 1).Value))
                dtgDiametros.Item("colDiamHilPres", 7).Value = redMedia - ((1 + (dtgDiametros.Item("colA", 2).Value * correccion)) * (resFinal * dtgDiametros.Item("colA", 2).Value))


                dtgDiametros.Item("colCalReal", 0).Value = ((diametro ^ 2) * (1 - dtgDiametros.Item("colDiamHilPres", 0).Value)) ^ (1 / 2)
                dtgDiametros.Item("colCalReal", 1).Value = ((dtgDiametros.Item("colCalReal", 0).Value ^ 2) * (1 - dtgDiametros.Item("colDiamHilPres", 1).Value)) ^ (1 / 2)
                dtgDiametros.Item("colCalReal", 2).Value = ((dtgDiametros.Item("colCalReal", 1).Value ^ 2) * (1 - dtgDiametros.Item("colDiamHilPres", 2).Value)) ^ (1 / 2)
                dtgDiametros.Item("colCalReal", 3).Value = ((dtgDiametros.Item("colCalReal", 2).Value ^ 2) * (1 - dtgDiametros.Item("colDiamHilPres", 3).Value)) ^ (1 / 2)
                dtgDiametros.Item("colCalReal", 4).Value = ((dtgDiametros.Item("colCalReal", 3).Value ^ 2) * (1 - dtgDiametros.Item("colDiamHilPres", 4).Value)) ^ (1 / 2)
                dtgDiametros.Item("colCalReal", 5).Value = ((dtgDiametros.Item("colCalReal", 4).Value ^ 2) * (1 - dtgDiametros.Item("colDiamHilPres", 5).Value)) ^ (1 / 2)
                dtgDiametros.Item("colCalReal", 6).Value = ((dtgDiametros.Item("colCalReal", 5).Value ^ 2) * (1 - dtgDiametros.Item("colDiamHilPres", 6).Value)) ^ (1 / 2)
                dtgDiametros.Item("colCalReal", 7).Value = ((dtgDiametros.Item("colCalReal", 6).Value ^ 2) * (1 - dtgDiametros.Item("colDiamHilPres", 7).Value)) ^ (1 / 2)


            Case 9
                amplitudPend = 10
                correccion = 0.1
                porcRed = (1 - (diamMin / diametro) ^ 2)
                redMedia = (1 - Math.Exp(-2 * Math.Log(diametro / diamMin) / pasos))
                resFinal = (redMedia / (pasos)) / amplitudPend
                dtgDiametros.Item("colA", 0).Value = 1
                dtgDiametros.Item("colA", 1).Value = 2
                dtgDiametros.Item("colA", 2).Value = 3
                dtgDiametros.Item("colA", 3).Value = 4
                dtgDiametros.Item("colA", 4).Value = 5
                dtgDiametros.Item("colA", 5).Value = 6
                dtgDiametros.Item("colA", 6).Value = 7
                dtgDiametros.Item("colA", 7).Value = 8
                dtgDiametros.Item("colA", 8).Value = 9

                dtgDiametros.Item("colDiamHilPres", 4).Value = redMedia
                dtgDiametros.Item("colDiamHilPres", 0).Value = redMedia + (resFinal * dtgDiametros.Item("colA", 3).Value)
                dtgDiametros.Item("colDiamHilPres", 1).Value = redMedia + (resFinal * dtgDiametros.Item("colA", 2).Value)
                dtgDiametros.Item("colDiamHilPres", 2).Value = redMedia + (dtgDiametros.Item("colA", 1).Value * resFinal)
                dtgDiametros.Item("colDiamHilPres", 3).Value = redMedia + (dtgDiametros.Item("colA", 0).Value * resFinal)
                dtgDiametros.Item("colDiamHilPres", 5).Value = redMedia - ((1 + (dtgDiametros.Item("colA", 0).Value * correccion)) * (resFinal * dtgDiametros.Item("colA", 0).Value))
                dtgDiametros.Item("colDiamHilPres", 6).Value = redMedia - ((1 + (dtgDiametros.Item("colA", 1).Value * correccion)) * (resFinal * dtgDiametros.Item("colA", 1).Value))
                dtgDiametros.Item("colDiamHilPres", 7).Value = redMedia - ((1 + (dtgDiametros.Item("colA", 2).Value * correccion)) * (resFinal * dtgDiametros.Item("colA", 2).Value))
                dtgDiametros.Item("colDiamHilPres", 8).Value = redMedia - ((1 + (dtgDiametros.Item("colA", 3).Value * correccion)) * (resFinal * dtgDiametros.Item("colA", 3).Value))


                dtgDiametros.Item("colCalReal", 0).Value = ((diametro ^ 2) * (1 - dtgDiametros.Item("colDiamHilPres", 0).Value)) ^ (1 / 2)
                dtgDiametros.Item("colCalReal", 1).Value = ((dtgDiametros.Item("colCalReal", 0).Value ^ 2) * (1 - dtgDiametros.Item("colDiamHilPres", 1).Value)) ^ (1 / 2)
                dtgDiametros.Item("colCalReal", 2).Value = ((dtgDiametros.Item("colCalReal", 1).Value ^ 2) * (1 - dtgDiametros.Item("colDiamHilPres", 2).Value)) ^ (1 / 2)
                dtgDiametros.Item("colCalReal", 3).Value = ((dtgDiametros.Item("colCalReal", 2).Value ^ 2) * (1 - dtgDiametros.Item("colDiamHilPres", 3).Value)) ^ (1 / 2)
                dtgDiametros.Item("colCalReal", 4).Value = ((dtgDiametros.Item("colCalReal", 3).Value ^ 2) * (1 - dtgDiametros.Item("colDiamHilPres", 4).Value)) ^ (1 / 2)
                dtgDiametros.Item("colCalReal", 5).Value = ((dtgDiametros.Item("colCalReal", 4).Value ^ 2) * (1 - dtgDiametros.Item("colDiamHilPres", 5).Value)) ^ (1 / 2)
                dtgDiametros.Item("colCalReal", 6).Value = ((dtgDiametros.Item("colCalReal", 5).Value ^ 2) * (1 - dtgDiametros.Item("colDiamHilPres", 6).Value)) ^ (1 / 2)
                dtgDiametros.Item("colCalReal", 7).Value = ((dtgDiametros.Item("colCalReal", 6).Value ^ 2) * (1 - dtgDiametros.Item("colDiamHilPres", 7).Value)) ^ (1 / 2)
                dtgDiametros.Item("colCalReal", 8).Value = ((dtgDiametros.Item("colCalReal", 7).Value ^ 2) * (1 - dtgDiametros.Item("colDiamHilPres", 8).Value)) ^ (1 / 2)

            Case 10
                dtgDiametros.Item("colA", 0).Value = 1
                dtgDiametros.Item("colA", 1).Value = 2
                dtgDiametros.Item("colA", 2).Value = 3
                dtgDiametros.Item("colA", 3).Value = 4
                dtgDiametros.Item("colA", 4).Value = 5
                dtgDiametros.Item("colA", 5).Value = 6
                dtgDiametros.Item("colA", 6).Value = 7
                dtgDiametros.Item("colA", 7).Value = 8
                dtgDiametros.Item("colA", 8).Value = 9
                dtgDiametros.Item("colA", 9).Value = 10
                'si es la trefiladora 7 ay calibre 1.42
                If (cbo_maquina.SelectedValue = "2118" And diamMin = "1.42") Then
                    dtgDiametros.Item("colCalReal", 0).Value = 4.73
                    dtgDiametros.Item("colCalReal", 1).Value = 4.08
                    dtgDiametros.Item("colCalReal", 2).Value = 3.53
                    dtgDiametros.Item("colCalReal", 3).Value = 3.06
                    dtgDiametros.Item("colCalReal", 4).Value = 2.67
                    dtgDiametros.Item("colCalReal", 5).Value = 2.33
                    dtgDiametros.Item("colCalReal", 6).Value = 2.04
                    dtgDiametros.Item("colCalReal", 7).Value = "1.79"
                    dtgDiametros.Item("colCalReal", 8).Value = "1.58"
                    dtgDiametros.Item("colCalReal", 9).Value = "1.4"

                    dtgDiametros.Item("colDiamHilPres", 0).Value = ((diametro * diametro) / ((dtgDiametros.Item("colCalReal", 0).Value * dtgDiametros.Item("colCalReal", 0).Value))) - 1
                    dtgDiametros.Item("colDiamHilPres", 1).Value = ((dtgDiametros.Item("colCalReal", 0).Value * dtgDiametros.Item("colCalReal", 0).Value) / ((dtgDiametros.Item("colCalReal", 1).Value * dtgDiametros.Item("colCalReal", 1).Value))) - 1
                    dtgDiametros.Item("colDiamHilPres", 2).Value = ((dtgDiametros.Item("colCalReal", 1).Value * dtgDiametros.Item("colCalReal", 1).Value) / ((dtgDiametros.Item("colCalReal", 2).Value * dtgDiametros.Item("colCalReal", 2).Value))) - 1
                    dtgDiametros.Item("colDiamHilPres", 3).Value = ((dtgDiametros.Item("colCalReal", 2).Value * dtgDiametros.Item("colCalReal", 2).Value) / ((dtgDiametros.Item("colCalReal", 3).Value * dtgDiametros.Item("colCalReal", 3).Value))) - 1
                    dtgDiametros.Item("colDiamHilPres", 4).Value = ((dtgDiametros.Item("colCalReal", 3).Value * dtgDiametros.Item("colCalReal", 3).Value) / ((dtgDiametros.Item("colCalReal", 4).Value * dtgDiametros.Item("colCalReal", 4).Value))) - 1
                    dtgDiametros.Item("colDiamHilPres", 5).Value = ((dtgDiametros.Item("colCalReal", 4).Value * dtgDiametros.Item("colCalReal", 4).Value) / ((dtgDiametros.Item("colCalReal", 5).Value * dtgDiametros.Item("colCalReal", 5).Value))) - 1
                    dtgDiametros.Item("colDiamHilPres", 6).Value = ((dtgDiametros.Item("colCalReal", 5).Value * dtgDiametros.Item("colCalReal", 5).Value) / ((dtgDiametros.Item("colCalReal", 6).Value * dtgDiametros.Item("colCalReal", 6).Value))) - 1
                    dtgDiametros.Item("colDiamHilPres", 7).Value = ((dtgDiametros.Item("colCalReal", 6).Value * dtgDiametros.Item("colCalReal", 6).Value) / ((dtgDiametros.Item("colCalReal", 7).Value * dtgDiametros.Item("colCalReal", 7).Value))) - 1
                    dtgDiametros.Item("colDiamHilPres", 8).Value = ((dtgDiametros.Item("colCalReal", 7).Value * dtgDiametros.Item("colCalReal", 7).Value) / ((dtgDiametros.Item("colCalReal", 8).Value * dtgDiametros.Item("colCalReal", 8).Value))) - 1
                    dtgDiametros.Item("colDiamHilPres", 9).Value = ((dtgDiametros.Item("colCalReal", 8).Value * dtgDiametros.Item("colCalReal", 8).Value) / ((dtgDiametros.Item("colCalReal", 9).Value * dtgDiametros.Item("colCalReal", 9).Value))) - 1
                    Exit Sub
                Else
                    amplitudPend = 5
                    correccion = 0.02
                    porcRed = (1 - (diamMin / diametro) ^ 2)
                    redMedia = (1 - Math.Exp(-2 * Math.Log(diametro / diamMin) / pasos))
                    resFinal = (redMedia / (pasos)) / amplitudPend



                    dtgDiametros.Item("colDiamHilPres", 5).Value = (redMedia + (redMedia - (dtgDiametros.Item("colA", 0).Value * resFinal))) / 2
                    dtgDiametros.Item("colDiamHilPres", 4).Value = (redMedia + (redMedia + (dtgDiametros.Item("colA", 0).Value * resFinal))) / 2
                    dtgDiametros.Item("colDiamHilPres", 6).Value = dtgDiametros.Item("colDiamHilPres", 5).Value - ((1 + (dtgDiametros.Item("colA", 0).Value * correccion)) * (resFinal * dtgDiametros.Item("colA", 0).Value))
                    dtgDiametros.Item("colDiamHilPres", 7).Value = dtgDiametros.Item("colDiamHilPres", 5).Value - ((1 + (dtgDiametros.Item("colA", 1).Value * correccion)) * (resFinal * dtgDiametros.Item("colA", 1).Value))
                    dtgDiametros.Item("colDiamHilPres", 8).Value = dtgDiametros.Item("colDiamHilPres", 5).Value - ((1 + (dtgDiametros.Item("colA", 2).Value * correccion)) * (resFinal * dtgDiametros.Item("colA", 2).Value))
                    dtgDiametros.Item("colDiamHilPres", 9).Value = dtgDiametros.Item("colDiamHilPres", 5).Value - ((1 + (dtgDiametros.Item("colA", 3).Value * correccion)) * (resFinal * dtgDiametros.Item("colA", 3).Value))
                    dtgDiametros.Item("colDiamHilPres", 3).Value = dtgDiametros.Item("colDiamHilPres", 4).Value + resFinal
                    dtgDiametros.Item("colDiamHilPres", 2).Value = dtgDiametros.Item("colDiamHilPres", 3).Value + resFinal
                    dtgDiametros.Item("colDiamHilPres", 1).Value = dtgDiametros.Item("colDiamHilPres", 2).Value + resFinal
                    dtgDiametros.Item("colDiamHilPres", 0).Value = dtgDiametros.Item("colDiamHilPres", 1).Value + resFinal

                    dtgDiametros.Item("colCalReal", 0).Value = ((diametro ^ 2) * (1 - dtgDiametros.Item("colDiamHilPres", 0).Value)) ^ (1 / 2)
                    dtgDiametros.Item("colCalReal", 1).Value = ((dtgDiametros.Item("colCalReal", 0).Value ^ 2) * (1 - dtgDiametros.Item("colDiamHilPres", 1).Value)) ^ (1 / 2)
                    dtgDiametros.Item("colCalReal", 2).Value = ((dtgDiametros.Item("colCalReal", 1).Value ^ 2) * (1 - dtgDiametros.Item("colDiamHilPres", 2).Value)) ^ (1 / 2)
                    dtgDiametros.Item("colCalReal", 3).Value = ((dtgDiametros.Item("colCalReal", 2).Value ^ 2) * (1 - dtgDiametros.Item("colDiamHilPres", 3).Value)) ^ (1 / 2)
                    dtgDiametros.Item("colCalReal", 4).Value = ((dtgDiametros.Item("colCalReal", 3).Value ^ 2) * (1 - dtgDiametros.Item("colDiamHilPres", 4).Value)) ^ (1 / 2)
                    dtgDiametros.Item("colCalReal", 5).Value = ((dtgDiametros.Item("colCalReal", 4).Value ^ 2) * (1 - dtgDiametros.Item("colDiamHilPres", 5).Value)) ^ (1 / 2)
                    dtgDiametros.Item("colCalReal", 6).Value = ((dtgDiametros.Item("colCalReal", 5).Value ^ 2) * (1 - dtgDiametros.Item("colDiamHilPres", 6).Value)) ^ (1 / 2)
                    dtgDiametros.Item("colCalReal", 7).Value = ((dtgDiametros.Item("colCalReal", 6).Value ^ 2) * (1 - dtgDiametros.Item("colDiamHilPres", 7).Value)) ^ (1 / 2)
                    dtgDiametros.Item("colCalReal", 8).Value = ((dtgDiametros.Item("colCalReal", 7).Value ^ 2) * (1 - dtgDiametros.Item("colDiamHilPres", 8).Value)) ^ (1 / 2)
                    dtgDiametros.Item("colCalReal", 9).Value = ((dtgDiametros.Item("colCalReal", 8).Value ^ 2) * (1 - dtgDiametros.Item("colDiamHilPres", 9).Value)) ^ (1 / 2)

                End If


        End Select

    End Sub
    Private Sub dtgProduccionCellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgProduccion.CellContentClick
        Dim fila As Integer = e.RowIndex
        Dim col As String = dtgProduccion.Columns(e.ColumnIndex).Name
        Dim resp As Integer = 0
        Dim motivo As String = ""
        If (fila >= 0) Then
            If (col = "btnAnular") Then
                If (fila <> dtgProduccion.RowCount - 1) Then
                    resp = MessageBox.Show("Esta seguro de eliminar este rollo? ", "Eliminar rollo?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                    If (resp = 6) Then
                        motivo = InputBox("Ingrese el motivo de la eliminar del rollo, luego presione aceptar", "Motivo")
                        If (motivo <> "") Then
                            motivo &= " " & Now.Date & " " & cbo_operario.SelectedValue
                            If (obj_Ing_prodLn.ejecutar("UPDATE J_rollos_tref SET anulado = 1 , motivo = '" & motivo & "' WHERE id_rollo= " & dtgProduccion.Item("colRollo", fila).Value & " AND  cod_orden = " & consecutivoPpal & " AND id_detalle = " & consecutivoDet & " ", "PRODUCCION") > 0) Then
                                Dim sql As String
                                Dim cod_tref As String = cbo_maquina.SelectedValue
                                Dim producto As String = txtProdFinal.Text
                                dtgProduccion.Item(colAnulado.Name, e.RowIndex).Value = "1"
                                dtgProduccion.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Red
                                dtgProduccion.Item(colCalibre.Name, e.RowIndex).Value = "ANULADO"
                                dtgProduccion.Item(colTraccion.Name, e.RowIndex).Value = "ANULADO"
                                dtgProduccion.Item(colColada.Name, e.RowIndex).Value = "ANULADO"
                                If String.Equals(producto, "22B100142") = False And String.Equals(producto, "22B100125") = False Then
                                    sql = "UPDATE J_det_orden_prod SET falta=+1 where id_tref=" & cod_tref & " and codigo='" & producto & "'"
                                    objOpsimpesLn.ejecutar(Sql, "PRODUCCION")
                                End If

                                txtCantTurno.Text = sumarProdTotal().ToString("N1")
                                MessageBox.Show("El rollo se elimino en forma correcta!", "Exito!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Else
                                MessageBox.Show("No se anulo el rollo, comuniquese con el administrador del sistema!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End If
                        Else
                            MessageBox.Show("No se elimino el rollo, ingrese un motivo de eliminación!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If

                    End If

                End If
                contarRollos()
                'IMPRESION DE ROLLOS
            ElseIf (col = "btn_no_conforme") Then
                If (fila <> dtgProduccion.RowCount - 1) Then
                    resp = MessageBox.Show("Esta seguro de clasificar como NC este rollo? ", "Eliminar rollo?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                    If (resp = 6) Then
                        motivo = InputBox("Ingrese el motivo de NC del rollo, luego presione aceptar", "Motivo")
                        If (motivo <> "") Then
                            motivo &= " " & Now.Date & " " & cbo_operario.SelectedValue
                            If (obj_Ing_prodLn.ejecutar("UPDATE J_rollos_tref SET no_conforme = 'S' , motivo = '" & motivo & "' WHERE id_rollo= " & dtgProduccion.Item("colRollo", fila).Value & " AND  cod_orden = " & consecutivoPpal & " AND id_detalle = " & consecutivoDet & " ", "PRODUCCION") > 0) Then
#Disable Warning BC42024 ' Variable local sin usar: 'sql'.
                                Dim sql As String
#Enable Warning BC42024 ' Variable local sin usar: 'sql'.
                                Dim cod_tref As String = cbo_maquina.SelectedValue
                                Dim producto As String = txtProdFinal.Text
                                Dim kilos As Double = txt_no_conforme.Text
                                Dim listSql As New List(Of Object)
                                Dim listSqlChat As New List(Of Object)
                                Dim tipo As Integer = 0
                                Dim causal As Integer = 0
                                Dim sql_oper As String = "select operario from j_det_orden_prod where cod_orden=" & consecutivoPpal & " and id_detalle=" & consecutivoDet & ""
                                Dim operario As String = objOpsimpesLn.consultValorTodo(sql_oper, "PRODUCCION")
                                Dim fecha As String = ""
                                Dim defecto As Integer
#Disable Warning BC42024 ' Variable local sin usar: 'row'.
                                Dim row As DataRow
#Enable Warning BC42024 ' Variable local sin usar: 'row'.
                                Dim frm As New frm_defectos
                                dtgProduccion.Item(col_no_conforme.Name, e.RowIndex).Value = "S"
                                dtgProduccion.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Yellow
                                dtgProduccion.Item(colCalibre.Name, e.RowIndex).Value = "NC"
                                dtgProduccion.Item(colColada.Name, e.RowIndex).Value = "NC"
                                frm.ShowDialog()
                                defecto = frm.recibir_defecto()
                                objOpsimpesLn.ExecuteSqlTransactionTodo(sql_ing_desperdicios(fecha, operario, dtgProduccion.Item(col_no_conforme.Name, e.RowIndex).Value, tipo, causal, defecto), "PRODUCCION")
                                txtCantTurno.Text = sumarProdTotal().ToString("N1")
                                MessageBox.Show("El rollo se modifico en forma correcta!", "Exito!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Else
                                MessageBox.Show("No se modifico el rollo, comuniquese con el administrador del sistema!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End If
                        Else
                            MessageBox.Show("No se modifico el rollo, ingrese un motivo de eliminación!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If

                    End If
                End If
                contarRollos()
                'IMPRESION DE ROLLOS
            ElseIf (col = "colImprimir") Then
                Dim sql_planilla As String
                Dim val_planilla As String
                Dim cant_rollos As String = txtNumRollos.Text
                Dim prod_f_trb As String = txtProdFinal.Text
                sql_planilla = "select transaccion_entrada from J_det_orden_prod WHERE cod_orden=" & consecutivoPpal & " and id_detalle=" & consecutivoDet & ""
                val_planilla = objOpsimpesLn.consultValorTodo(sql_planilla, "PRODUCCION")
                If val_planilla = "" Then
                    cant_rollos = txtNumRollos.Text
                    'If prod_f_trb.ToUpper Like "22B100142*" Or prod_f_trb.ToUpper Like "22B100125*" Then
                    '    Dim validar_limite, valor_planilla As String
                    '    validar_limite = "SELECT falta FROM J_val_8y9 where id_tref=" & cboMaquinaConsulta.SelectedValue & " AND codigo='" & txtProdFinal.Text.ToUpper & "'"
                    '    valor_planilla = objOpsimpesLn.consultValorTodo(validar_limite, "PRODUCCION")
                    '    If CDbl(cant_rollos) < CDbl(valor_planilla) Then
                    '        'Valida si las planillas de esas referencias cumplen el limite
                    '    Else
                    '        MessageBox.Show("Ya no se puede registrar mas rollos en esta planilla", "Ha llegado al limite", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    '        Exit Sub
                    '    End If
                    'End If
                    Dim sql_validar_pla As String = "SELECT SUM (peso) FROM J_rollos_tref rollo where rollo.cod_orden =" & consecutivoPpal & " and anulado  is null and manuales is null and no_conforme is null"
                    Dim peso_orden As String = objOpsimpesLn.consultValorTodo(sql_validar_pla, "PRODUCCION")
                    If peso_orden = "" Then
                        peso_orden = "0"
                    End If
                    Dim convert_peso_orden As Double = CDbl(peso_orden)
                    Dim peso_progra As Double = CDbl(txtCantProg.Text)
                    Dim sql_tipo_cliente As String = "select tipoCliente from J_orden_prod_tef where consecutivo=" & consecutivoPpal & ""
                    Dim tipo_cliente As Integer = CInt(objOpSimplesLn.consultValorTodo(sql_tipo_cliente, "PRODUCCION"))

                    If tipo_cliente = 0 Then
                        If convert_peso_orden <= peso_progra Then
                            If cbo_maquina.SelectedValue = 2116 Or cbo_maquina.SelectedValue = 2101 Or cbo_maquina.SelectedValue = 2103 Or cbo_maquina.SelectedValue = 2102 Or cbo_maquina.SelectedValue = 2105 Or cbo_maquina.SelectedValue = 2104 Or cbo_maquina.SelectedValue = 2121 Then
                                eventro_imprimir(fila, capturarPeso_indicador2())
                            Else
                                eventro_imprimir(fila, capturarPeso())
                            End If
                        Else
                            MessageBox.Show("Se ha cumplido con la cantidad programada de la orden de produccion se debe cerrar la planilla", "Cerrar la planilla", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            enviarCorreoFinPlanillaEspe(consecutivoPpal, consecutivoDet)
                            btnIniciaPara.PerformClick()
                        End If
                    Else
                        If cbo_maquina.SelectedValue = 2116 Or cbo_maquina.SelectedValue = 2101 Or cbo_maquina.SelectedValue = 2103 Or cbo_maquina.SelectedValue = 2102 Or cbo_maquina.SelectedValue = 2105 Or cbo_maquina.SelectedValue = 2104 Or cbo_maquina.SelectedValue = 2121 Then
                            eventro_imprimir(fila, capturarPeso_indicador2())
                        Else
                            eventro_imprimir(fila, capturarPeso())
                        End If
                    End If
                Else
                    MessageBox.Show("No se puede registrar rollos por que la planilla ha sido cerrada", "Planilla cerrada", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Close()
                End If
            ElseIf (col = "colLimpiar") Then
                resp = MessageBox.Show("Esta seguro que desea ocultar los rollos?", "ocultar rollo?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                If (resp = 6) Then
                    If (dtgProduccion.RowCount > 2) Then
                        For i = 0 To dtgProduccion.RowCount - 3
                            dtgProduccion.Rows(i).Visible = False
                        Next
                    End If
                End If
            ElseIf (col = "colVer") Then
                For i = 0 To dtgProduccion.RowCount - 1
                    dtgProduccion.Rows(i).Visible = True
                Next
            End If
        End If
    End Sub
    'Impeimir tiquetes
    Function dejarNumerosPuntos(cadenaTexto As String) As String
        Const listaNumeros = "0123456789."
        Dim cadenaTemporal As String
        Dim i As Integer

        cadenaTexto = Trim$(cadenaTexto)
        If Len(cadenaTexto) = 0 Then
            Exit Function
        End If

        cadenaTemporal = ""

        For i = 1 To Len(cadenaTexto)
            If InStr(listaNumeros, Mid$(cadenaTexto, i, 1)) Then
                cadenaTemporal = cadenaTemporal + Mid$(cadenaTexto, i, 1)
            End If
        Next
        dejarNumerosPuntos = cadenaTemporal
#Disable Warning BC42105 ' La función 'dejarNumerosPuntos' no devuelve un valor en todas las rutas de acceso de código. Puede producirse una excepción de referencia NULL en tiempo de ejecución cuando se use el resultado.
    End Function
#Enable Warning BC42105 ' La función 'dejarNumerosPuntos' no devuelve un valor en todas las rutas de acceso de código. Puede producirse una excepción de referencia NULL en tiempo de ejecución cuando se use el resultado.
    'Validar que se haya llenado la planilla de calidad
    Private Function validar_Ingreso_Calidad()
        Dim resp As Boolean = False
        For Each Row As DataGridViewRow In dtg_Inp_Calidad.Rows
            If Not IsDBNull(Row.Cells("diametro").Value) Then
                If Row.Cells("diametro").Value <> "" Then
                    resp = True
                    Exit For
                End If
            End If
        Next
        Return resp
    End Function
    Private Sub eventro_imprimir(ByVal fila As Integer, ByVal cadPeso As String)
        Dim cod_mat_prima As String = txtMatPrima.Text
        Dim mypeso() As Char = {"?", "", " ", "*", "=", "¿", "´´", "-", "U", "S", "G", "N", "T", "+", "k", "g", "''", """"}
        Dim calibre As Double = txtDiaMin.Text
        Dim nitOperario As Double = cbo_operario.SelectedValue
        Dim nombOperario As String = cbo_operario.Text
        Dim Fecha As String = objOpsimpesLn.cambiarFormatoFecha(Now.Date)
        Dim calidad As Integer = cboCalidad.SelectedValue
        Dim producto As String = txtProdFinal.Text
        Dim cod_tref As String = cbo_maquina.SelectedValue
        Dim peso As String = 0
        Dim rolloNum As Integer = dtgProduccion.Item("colRollo", fila).Value
        Dim colada As String = dtgProduccion.Item("colColada", fila).Value
        Dim numOrdenPdn As String = dtgProduccion.Item("colOrdenPDN", fila).Value
        Dim numRolloPdn As String = dtgProduccion.Item("colNroRolloF", fila).Value
        Dim traccion As String = dtgProduccion.Item("colTraccion", fila).Value
        Dim destinoDesc As String = cboCliente.Text
        Dim validar_peso_p As Double = sumarProdTotal()
#Disable Warning BC42024 ' Variable local sin usar: 'sql'.
        Dim sql As String
#Enable Warning BC42024 ' Variable local sin usar: 'sql'.

        If (dtgProduccion.Item("txtGuardado", fila).Value = 0) Then
            If (colada <> "") Then
                If (traccion <> "") Then
                    If (cadPeso <= 10) Then
                        If cbo_maquina.SelectedValue = 2121 Or cbo_maquina.SelectedValue = 2101 Or cbo_maquina.SelectedValue = 2116 Then
                            cadPeso = (capturarPeso_indicador2())
                            cadPeso = (capturarPeso_indicador2())
                            cadPeso = (capturarPeso_indicador2())
                            If (cadPeso <= 10) Then
                                cadPeso = (capturarPeso_indicador2())
                            End If
                        Else
                            cadPeso = (capturarPeso())
                            cadPeso = (capturarPeso())
                            cadPeso = (capturarPeso())
                            If (cadPeso <= 10) Then
                                cadPeso = (capturarPeso())
                            End If
                        End If
                    End If
                    peso = cadPeso
                    If peso <= 2000 Then
                        If IsNumeric(peso) Then
                            Dim resp As Boolean = True
                            If String.Equals(producto, "22B100142") = True Or String.Equals(producto, "22B100125") = True Then
                                If CInt(peso) <> 25 Then
                                    resp = False
                                End If
                            End If
                            If resp = True Then
                                GuardarRollo(peso, rolloNum, colada, numOrdenPdn, numRolloPdn, traccion)
                                If consultar_rollo(rolloNum) Then
                                    Dim peso_real As Double = peso
                                    Dim peso_int As Integer = peso
                                    Dim diferencia As Double = Format(peso_real - peso_int, "#0.0")
                                    If diferencia < -0.3 Then
                                        peso_int -= 1
                                        diferencia = Format(peso_real - peso_int, "#0.0")
                                    End If
                                    peso = peso_int
                                    dtgProduccion.Item("txtGuardado", fila).Value = 1
                                    dtgProduccion.Item(colAnulado.Name, fila).Value = ""
                                    dtgProduccion.Item(col_no_conforme.Name, fila).Value = ""
                                    dtgProduccion.Item("colImprimir", fila).Value = My.Resources.ok3
                                    dtgProduccion.Item("colKg", fila).Value = peso
                                    dtgProduccion.Item(colCalibre.Name, fila).Value = calibre
                                    dtgProduccion.Rows.Add()
                                    txtCantTurno.Text = sumarProdTotal().ToString("N1")
                                    ActCantPend()

                                    dtgProduccion.Item("colRollo", fila + 1).Value += dtgProduccion.Item("colRollo", fila).Value + 1
                                    If (fila = dtgProduccion.RowCount - 2) Then
                                        copiarDatosRollo(fila)
                                    End If
                                    Fecha = Now
                                    Dim peso_d As Integer = peso
                                    If String.Equals(producto, "22B100142") = False And String.Equals(producto, "22B100125") = False Then
                                        imprimirTiquete(peso_d, rolloNum, calibre, calidad, nombOperario, Fecha, producto, destinoDesc, colada, cod_mat_prima, traccion)
                                        'sql = "UPDATE J_det_orden_prod SET falta=-1 where id_tref=" & cod_tref & " and codigo='" & producto & "'"
                                        'objOpsimpesLn.ejecutar(sql, "PRODUCCION")
                                    End If
                                    contarRollos()
                                    'cargarTblProdOp(consecutivoDet)
                                    ActCantPend()
                                Else
                                    MessageBox.Show("El rollo no se ingreso correctamente se debe volver a imprimir.", "Volver a imprimir rollo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                    Exit Sub
                                End If
                            Else
                                MessageBox.Show("los rollos de las referencias 22b100124 y 22b100125 debene pesar 25 kilos .", "Volver a pesar rollo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                Exit Sub
                            End If
                        Else
                            MessageBox.Show("Error en el peso,hay probables problemas con el indicador", "Problemas con el peso!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Exit Sub
                        End If
                    Else
                        MessageBox.Show("El rollo exedió el máximo permitido que es 2.000 verifique el peso", "Verifique el peso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    End If
                Else
                    MessageBox.Show("Para imprimir el rollo de debe ingresar la tracción  ", "INGRESE TRACCIÓN!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
            Else
                MessageBox.Show("Para imprimir el rollo de debe ingresar la colada ", "INGRESE COLADA!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Else
            peso = dtgProduccion.Item("colKg", fila).Value
            Dim peso_d As Integer = peso
            Fecha = Now
            If cbo_maquina.SelectedValue <> 2121 And cbo_maquina.SelectedValue <> 2119 Then
                If producto.ToUpper Like "22B100142*" Or producto.ToUpper Like "22B100125*" Then
                    imprimirTiquete(peso_d, rolloNum, calibre, calidad, nombOperario, Fecha & "(COPIA)", producto, destinoDesc, colada, cod_mat_prima, traccion)
                Else
                    imprimirTiquete(peso_d, rolloNum, calibre & "(COPIA)", calidad, nombOperario, Fecha, producto, destinoDesc, colada, cod_mat_prima, traccion)
                End If
            End If
            contarRollos()
        End If
    End Sub
    'IMPRIME AL CERRAR LA PLANILLA DE LA TREF 8 Y 9 EL TIQUETE DEL LOTE QUE SE HA TRABAJADO CON SUS RESPECTIVA INFORMACIÓN
    Private Sub imprimir_Tiquete_lote_tref_8y9()
        Dim proc As New Process
        Dim fic As String = Environment.CurrentDirectory & "\plantillalote.txt"
        Dim nuevoFic As String = Environment.CurrentDirectory & "\plantillaloteimp.txt"
        Dim sw As New System.IO.StreamWriter(nuevoFic)
        Dim texto As String
        Dim sr As New System.IO.StreamReader(fic)
        Dim codOrden As String = consecutivoPpal & "-" & consecutivoDet
        Dim ref As String = txtProdFinal.Text
        Dim operario As String = cbo_operario.Text
        Dim fec As String = Now
        texto = sr.ReadToEnd()
        texto = Replace(texto, "@operario", operario)
        texto = Replace(texto, "@peso", txtCantTurno.Text & " (Kg)")
        texto = Replace(texto, "@fechah", fec)
        texto = Replace(texto, "@orden", codOrden)
        texto = Replace(texto, "@Barras", codOrden)
        texto = Replace(texto, "@cant", txtNumRollos.Text)
        texto = Replace(texto, "@ref", ref)
        sr.Close()
        sw.WriteLine(texto)
        sw.Close()
        proc.StartInfo.FileName = Environment.CurrentDirectory & "\plantillaloteimp.txt"
        proc.StartInfo.Verb = "Print"
        proc.StartInfo.CreateNoWindow = False
        proc.Start()
    End Sub
    ''Guarda el nro de rollos de la planilla y tambien guarda si el limite de la planilla se cumplio al 100 %
    Private Sub restar_val8y9()
        Dim sql As String
        Dim resta_limite As Integer
        'sql = "UPDATE J_val_8y9 set falta-=" & txtNumRollos.Text & " where id_tref=" & cbo_maquina.SelectedValue & " AND codigo='" & txtProdFinal.Text.ToUpper & "'"
        'obj_Ing_prodLn.ejecutar(sql, "PRODUCCION")
        sql = "Select falta from J_val_8y9 where id_tref=" & cbo_maquina.SelectedValue & " AND codigo='" & txtProdFinal.Text.ToUpper & "'"
        resta_limite = CInt(objOpSimplesLn.consultValorTodo(sql, "PRODUCCION"))
        If resta_limite = 0 Then
            sql = "UPDATE J_val_8y9 set falta=60 where id_tref=" & cbo_maquina.SelectedValue & " AND codigo='" & txtProdFinal.Text.ToUpper & "'"
            obj_Ing_prodLn.ejecutar(sql, "PRODUCCION")
        End If
    End Sub
    'CARGAR EL TOTAL DE ROLLOS TRABAJADOS EN EL DETALLLE DE LA PLANILLA PARA EL CONTROL DE RECOCIDO
    Private Sub cargar_rollos_reg()
        Dim sql As String
        sql = "UPDATE J_det_orden_prod set nro_rollos=" & txtNumRollos.Text & " where cod_orden=" & consecutivoPpal & " AND id_detalle=" & consecutivoDet & ""
        obj_Ing_prodLn.ejecutar(sql, "PRODUCCION")
    End Sub
    Private Sub guardar_nrorollos_estado()
        Dim lim_local As String
        Dim resta_limite As Integer
        Dim cantidad_rollos As Integer = txtNumRollos.Text
        Dim sql As String
        sql = "select limite_lote from  J_det_orden_prod  where cod_orden=" & consecutivoPpal & " and id_detalle=" & consecutivoDet & ""
        lim_local = obj_Ing_prodLn.consultar_valor(sql, "PRODUCCION")
        resta_limite = lim_local - cantidad_rollos
        If resta_limite = 0 Then
            sql = "update J_det_orden_prod set lote_completo='S' where cod_orden=" & consecutivoPpal & " and id_detalle=" & consecutivoDet
            obj_Ing_prodLn.ejecutar(sql, "PRODUCCION")
            sql = "update J_det_orden_prod set nro_rollos=" & cantidad_rollos & " where cod_orden=" & consecutivoPpal & " and id_detalle=" & consecutivoDet
            obj_Ing_prodLn.ejecutar(sql, "PRODUCCION")
        Else
            sql = "update J_det_orden_prod set lote_completo='N' where cod_orden=" & consecutivoPpal & " and id_detalle=" & consecutivoDet
            obj_Ing_prodLn.ejecutar(sql, "PRODUCCION")
            sql = "update J_det_orden_prod set nro_rollos=" & cantidad_rollos & " where cod_orden=" & consecutivoPpal & " and id_detalle=" & consecutivoDet
            obj_Ing_prodLn.ejecutar(sql, "PRODUCCION")
        End If
    End Sub
    Private Sub actualizar_limite(ByVal limite_p As Integer)
        limite = limite_p
    End Sub
    Private Sub contarRollos()
        Dim cont As Double = 0
        For i = 0 To dtgProduccion.RowCount - 1
            If (dtgProduccion.Item("txtGuardado", i).Value = 1 And dtgProduccion.Item(colAnulado.Name, i).Value <> "1") Then
                cont += 1
            End If
        Next
        txtNumRollos.Text = cont
    End Sub
    Private Sub copiarDatosRollo(ByVal fila As Integer)
        dtgProduccion.Item("colTraccion", fila + 1).Value = dtgProduccion.Item("colTraccion", fila).Value
        dtgProduccion.Item("colColada", fila + 1).Value = dtgProduccion.Item("colColada", fila).Value
        dtgProduccion.Item("colOrdenPDN", fila + 1).Value = dtgProduccion.Item("colOrdenPDN", fila).Value
        dtgProduccion.Item("colNroRolloF", fila + 1).Value = dtgProduccion.Item("colNroRolloF", fila).Value
    End Sub
    Private Sub dtg_consulta_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dtg_consulta.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            With (Me.dtg_consulta)
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                End If
            End With
        End If
    End Sub
    Private Sub AgregarConsecutivoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        actualizarConsecutivoPpal(dtg_consulta.Item("número", dtg_consulta.CurrentCell.RowIndex).Value)
    End Sub
    Private Sub actualizar_mp()
        Dim sql_val As String
        If cboMaquinaConsulta.Text <> "Seleccione" Or cboMaquinaFiltro.Text <> "Seleccione" Then
            If cboMaquinaConsulta.Text <> "Seleccione" Then
                If cboMaquinaConsulta.Text <> "" Then
                    sql_val = "SELECT peso_lleva FROM J_tref_cont_mp WHERE codigoM= " & cboMaquinaConsulta.SelectedValue & " and ano=" & cbo_fec_orden.Value.Year & " and mes=" & cbo_fec_orden.Value.Month & " and cod_alambron='" & txtMatPrima.Text & "'"
                End If
            Else
                If cboMaquinaFiltro.Text <> "" Then
                    sql_val = "SELECT peso_lleva FROM J_tref_cont_mp WHERE codigoM= " & cboMaquinaFiltro.SelectedValue & " and ano=" & cbo_fec_orden.Value.Year & " and mes=" & cbo_fec_orden.Value.Month & " and cod_alambron='" & txtMatPrima.Text & "'"
                End If
            End If
#Disable Warning BC42104 ' La variable 'sql_val' se usa antes de que se le haya asignado un valor. Podría darse una excepción de referencia NULL en tiempo de ejecución.
            If sql_val <> "" Then
#Enable Warning BC42104 ' La variable 'sql_val' se usa antes de que se le haya asignado un valor. Podría darse una excepción de referencia NULL en tiempo de ejecución.
                lbl_mat.Text = obj_Ing_prodLn.consultar_valor(sql_val, "PRODUCCION")
            End If

        End If
    End Sub
    Private Sub bloquearPlanPpal(ByVal estado As Boolean)
        cboNumPasos.Enabled = estado
        txtProdFinal.Enabled = estado
        txtDiaMin.Enabled = estado
        txtDiamMAx.Enabled = estado
        txtCantProg.Enabled = estado
        txtDiametro.Enabled = estado
        txt_cod_alambron.Enabled = estado
        cboOrigen.Enabled = estado
        cboCliente.Enabled = estado
        txtMatPrima.Enabled = estado
        txtTracMin.Enabled = estado
        txtTracMax.Enabled = estado
        cboCalidad.Enabled = estado
        txtCantPendOrden.Enabled = estado
        txtConsulNumOrd.Enabled = estado
        cbo_maquina.Enabled = estado
        txtNotas.Enabled = True
        btnGuardar.Enabled = True
    End Sub
    Private Sub VerDetalleToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VerDetalleToolStripMenuItem.Click
        actualizarConsecutivoPpal(dtg_consulta.Item("número", dtg_consulta.CurrentCell.RowIndex).Value)
        actualizarConsecutivoDet(0)
        cargarDatos()
        cargarDtgAsociado("TODOS")
        TblPpal.SelectedTab = tblOrdenProd
        dtgPlanInsp.DataSource = Nothing
        dtg_Inp_Calidad.DataSource = Nothing
    End Sub
    Private Sub ActCantPend()
        Dim und As Double = 0
        Dim kilosProg As Double = 0
        Dim sql As String = "SELECT SUM (rollo.peso ) FROM J_rollos_tref rollo WHERE rollo.anulado  is null AND rollo.manuales is null AND rollo.no_conforme is null and rollo.cod_orden = " & consecutivoPpal
        Dim kilosAnt As Double = obj_Ing_prodLn.consultar_valor(sql, "PRODUCCION")
        'If (txtCantTurno.Text <> "") Then
        '    und = txtCantTurno.Text
        'End If
        If (txtCantProg.Text <> "") Then
            kilosProg = txtCantProg.Text
        End If
        Dim total As Long = kilosProg - kilosAnt
        txtCantPendOrden.Text = total
        txtCantPendOp.Text = total
    End Sub

    Private Sub itemDetalle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles itemDetalle.Click
        Dim fila As Integer = dtgPlanAsociadas.CurrentCell.RowIndex
        If (fila >= 0) Then
            cargarTblProdOp(dtgPlanAsociadas.Item("#", fila).Value)
            TblPpal.SelectedTab = tblProdOp
            'cargarPlanInsp()
            cargarPlanInspCal()
        End If
    End Sub
    Private Sub dtgPlanAsociadas_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dtgPlanAsociadas.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            With (Me.dtgPlanAsociadas)
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                End If
            End With
        End If
        If (dtgPlanAsociadas.RowCount > 0) Then
            If (dtgPlanAsociadas.CurrentCell.RowIndex >= 0) Then
                cargarTblProdOp(dtgPlanAsociadas.Item("#", dtgPlanAsociadas.CurrentCell.RowIndex).Value)
                'cargarPlanInsp()
                cargarPlanInspCal()
                ActCantPend()
                If IsDBNull(dtgPlanAsociadas.Item("cerrado", dtgPlanAsociadas.CurrentCell.RowIndex).Value) Then
                    CerrarTurnoToolStripMenuItem.Enabled = True
                    CerrarForzadoToolStripMenuItem.Enabled = True
                Else
                    CerrarTurnoToolStripMenuItem.Enabled = False
                    CerrarForzadoToolStripMenuItem.Enabled = False
                End If
            End If
        Else
            CerrarTurnoToolStripMenuItem.Enabled = False
            CerrarForzadoToolStripMenuItem.Enabled = False
        End If
    End Sub

    Private Sub txtConsulNumOrd_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtConsulNumOrd.TextChanged
        If txtConsulNumOrd.Text.Length > 4 Then
            cargarAdminProd(txtConsulNumOrd.Text)
        End If
    End Sub

    Private Sub chkInterno_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkInterno.CheckedChanged
        Dim sql As String = ""
        Dim dt As New DataTable
        Dim row As DataRow
        If (chkInterno.Checked) Then
            sql = "select codigo,descripcion from J_destino_tref"
            dt = obj_Ing_prodLn.listar_datatable(sql, "PRODUCCION")
            dt.Rows(0).Delete()
            row = dt.NewRow
            row("Codigo") = 0
            row("Descripcion") = "Seleccione"
            dt.Rows.Add(row)
            cboCliente.DataSource = dt
            cboCliente.ValueMember = "codigo"
            cboCliente.DisplayMember = "descripcion"
            cboCliente.SelectedValue = 0
            btn_cliente.Enabled = False
            txtTracMax.Text = ""
            txtTracMin.Text = ""
            txtProdFinal.Text = ""
            If (usuario <> "operario") Then
                cboCliente.Enabled = True
                btnBod2_3.Enabled = True
            End If
        Else
            cboCliente.DataSource = dtTerceros
            cboCliente.ValueMember = "nit"
            cboCliente.DisplayMember = "nombres"
            cboCliente.Text = "Seleccione"
            cboCliente.SelectedValue = 0
            cboCliente.Enabled = False
            btn_cliente.Enabled = True
            btnBod2_3.Enabled = False
            txtProdFinal.Enabled = False
            txtTracMax.Text = ""
            txtTracMin.Text = ""
        End If
    End Sub
    Private Sub actualizarConsecutivoPpal(ByVal consecutivo As String)
        Dim titulo As String = "ORDEN DE PRODUCCIÓN DE TREFILADO Nº " & cbo_maquina.SelectedText.ToUpper
        consecutivoPpal = consecutivo
        orden_tiq_rec = consecutivo
        'Para que no muestre la ficha tecnica
        inicio_ficha = 0
        Me.Text = titulo & consecutivoPpal
    End Sub
    Private Sub actualizarConsecutivoDet(ByVal consecutivo As String)
        Dim titulo As String = "ORDEN DE PRODUCCIÓN DE TREFILADO Nº " & cbo_maquina.SelectedText.ToUpper
        Dim operario As String = ""
        consecutivoDet = consecutivo
        Me.Text = titulo & consecutivoPpal & " Consecutivo:" & consecutivoDet
    End Sub
    Private Sub dtgOperarioCellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgOperario.CellContentClick
        Dim fila As Integer = e.RowIndex
        Dim col As String = dtgOperario.Columns(e.ColumnIndex).Name
        If (fila >= 0) Then
            If dtgOperario.Rows(fila).DefaultCellStyle.BackColor <> Color.LightCoral Then
                If (col = "btnTrabajar") Then
                    If Not (estadoTurno) Then
                        btnIniciaPara.Enabled = True
                        actualizarConsecutivoPpal(dtgOperario.Item("num_orden", fila).Value)
                        actualizarConsecutivoDet(objOrdenProdLn.consecutivo_planilla_abierta_hoy(cboOperariosTurno.SelectedValue, consecutivoPpal))
                        cargarDatos()
                        cargarDtgAsociado("OPERARIO")
                        cargarTblProdOp(consecutivoDet)
                        seleccion_Planilla_Ingreso()
                        ActCantPend()
                        For i = 0 To dtgOperario.RowCount - 1
                            If (dtgOperario.Rows(i).DefaultCellStyle.BackColor = Color.Red And i <> e.RowIndex) Then
                                dtgOperario.Rows(i).DefaultCellStyle.BackColor = Color.White
                            End If
                        Next
                        TblPpal.SelectedTab = tblOrdenProd
                        cbo_operario.SelectedValue = cboOperariosTurno.SelectedValue
                        actualizar_mp()
                        habilitar_lectorMp()
                        pintar_operarios()
                        dtgOperario.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Red
                    Else
                        MessageBox.Show("No se a terminado con el turno anterior,verifique el boton terminar planilla de la pestaña 'PRODUCCIÓN OPERARIO'! ", "Verifique!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        cboOperariosTurno.SelectedValue = cbo_operario.SelectedValue
                        TblPpal.SelectedTab = tblProdOp
                    End If
                End If
            Else
                MessageBox.Show("No se puede trabajar ordenes que esten en color rojo! ", "Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
    End Sub
    Private Sub cargarPlanOperario()
        If Not (estadoTurno) Then
            If (cboOperariosTurno.Text <> "Seleccione") Then
                If (cboMaquinaConsulta.Text <> "Seleccione") Then
                    Dim ano As Integer = cboAnoConsulta.Text
                    Dim mes As Integer = cboMesConsulta.SelectedValue
                    Dim sql As String = "SELECT orden.prod_final As código, orden.diam_min As diametro,Vista.nombres As destino,maq.Nombre As maquina,orden.fecha_creacion,orden.fecha_terminacion,(SELECT CASE " &
                                               "WHEN orden.mes = 1 " &
                                                "THEN 'Enero' " &
                                               "WHEN orden.mes = 2 " &
                                                "THEN 'Febrero' " &
                                               "WHEN orden.mes = 3 " &
                                                "THEN 'Marzo' " &
                                               "WHEN orden.mes = 4 " &
                                                "THEN 'Abril' " &
                                               "WHEN orden.mes = 5 " &
                                                "THEN 'Mayo' " &
                                               "WHEN orden.mes = 6 " &
                                                "THEN 'Junio' " &
                                               "WHEN orden.mes = 7 " &
                                                "THEN 'Julio' " &
                                               "WHEN orden.mes = 8 " &
                                                "THEN 'Agosto' " &
                                               "WHEN orden.mes = 9 " &
                                                "THEN 'Septiembre' " &
                                               "WHEN orden.mes = 10 " &
                                                "THEN 'Octubre' " &
                                               "WHEN orden.mes = 11 " &
                                                "THEN 'Noviembre' " &
                                               "WHEN orden.mes = 12 " &
                                                "THEN 'Diciembre' " &
                                               "END)As mes,orden.ano as año,orden.consecutivo As num_orden,orden.notas,(SELECT CASE WHEN vista.kilos is null then 0 else vista.kilos end) as kilos,(select velocidad from CORSAN.dbo.J_control_vel_maq where id_tref=orden.id_maquina and codigo=orden.prod_final) as vel_esp,vista.cant_prog,(vista.cant_prog-(SELECT CASE WHEN vista.kilos is null then 0 else vista.kilos end)) as faltaKg " &
                                                         "FROM J_orden_prod_tef orden,J_maquinas maq,J_v_ordenes_prod Vista " &
                                                    "WHERE Vista.consecutivo = orden.consecutivo AND maq.codigoM = orden.id_maquina AND (orden.oculto is null or orden.oculto = '0') AND year(orden.fecha_creacion) = " & ano & " AND month(orden.fecha_creacion) = " & mes & " AND orden.id_maquina = " & cboMaquinaConsulta.SelectedValue &
                                                            "ORDER BY orden.consecutivo  ASC "
                    dtgOperario.DataSource = objOpsimpesLn.listar_datatable(sql, "PRODUCCION")
                    pintar_operarios()
                    dtgOperario.Columns("fecha_creacion").Visible = False
                    dtgOperario.Columns("fecha_terminacion").Visible = False
                    dtgOperario.Columns("kilos").Visible = False
                    dtgOperario.Columns("cant_prog").Visible = False
                    dtgOperario.Columns("código").DefaultCellStyle = formatoNegrita()
                    evitar_Ordenar()
                Else
                    MessageBox.Show("Para cargar sus planillas por favor seleccione la maquina en la que actualmente se encuentra laborando! ", "Verifique!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End If
        Else
            If sw_trabajo = True Then
                MessageBox.Show("No se a terminado con la planilla anterior,verifique el boton terminar planilla de la pestaña 'PRODUCCIÓN OPERARIO'! ", "Verifique!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboOperariosTurno.SelectedValue = cbo_operario.SelectedValue
                TblPpal.SelectedTab = tblProdOp
            End If
        End If
    End Sub

    Public Sub pintar_operarios()
        Dim fecha_horas As String = obtenerHoraMinuto(Now)
        Dim fecha As String = CDate(Now)
        Dim fecha_hora As String = objOpSimplesLn.cambiarFormatoFecha(Now)
        For Each Row As DataGridViewRow In dtgOperario.Rows
            If Row.Cells("cant_prog").Value > Row.Cells("kilos").Value Then
                Row.DefaultCellStyle.BackColor = Color.GreenYellow
            Else
                If Not IsDBNull(Row.Cells("fecha_terminacion").Value) Then
                    If Row.Cells("fecha_terminacion").Value = fecha_hora Then
                        Row.DefaultCellStyle.BackColor = Color.GreenYellow
                    Else
                        Row.DefaultCellStyle.BackColor = Color.LightCoral
                    End If
                Else
                    Row.DefaultCellStyle.BackColor = Color.LightCoral
                End If
            End If
            'If Row.Cells("código").Value.Contains("33B") Or Row.Cells("código").Value.Contains("33X") Or Row.Cells("código").Value.Contains("33R") Then
            '    Row.DefaultCellStyle.BackColor = Color.GreenYellow
            'End If
        Next
    End Sub
    Function obtenerHoraMinuto(ByVal fecha As Date) As String

        Dim horaMinuto As String = "00:00"
        Dim hora As String = "00"
        Dim minuto As String = "00"

        If Len(Trim(Str(fecha.Hour))) = 1 Then
            hora = "0" & fecha.Hour
        Else
            hora = fecha.Hour
        End If

        If Len(Trim(Str(fecha.Minute))) = 1 Then
            minuto = "0" & fecha.Minute
        Else
            minuto = fecha.Minute
        End If

        horaMinuto = hora & ":" & minuto

        obtenerHoraMinuto = horaMinuto

    End Function
    Public Function formatoNegrita() As DataGridViewCellStyle
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold)
        Return DataGridViewCellStyle1
    End Function

    Private Sub CboOperariosTurno_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles cboOperariosTurno.SelectedIndexChanged
        If (cargaComp) Then
            cargarPlanOperario()
        End If
    End Sub

    Private Sub dtgPlanAsociadas_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgPlanAsociadas.CellContentClick
        Dim fila As Integer = e.RowIndex
        Dim col As String = dtgPlanAsociadas.Columns(e.ColumnIndex).Name
        Dim motivo As String = ""
        Dim prod_f_trb As String = txtProdFinal.Text
        If (fila >= 0) Then
            If (col = "colEliminar") Then
                Dim resp As Integer = MessageBox.Show("Esta seguro que desea eliminar esta planilla consecutiva? ", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If (resp = 6) Then
                    motivo = InputBox("Ingrese el motivo de la anulación del consecutivo, luego presione aceptar", "Motivo")
                    If (motivo <> "") Then
                        motivo &= " - Usuario:" & usuario & "-" & Now
                        If (objOrdenProdLn.eliminarConsecutivo(consecutivoPpal, dtgPlanAsociadas.Item("#", fila).Value, motivo)) Then
                            If (verificarPlanillaTerminada(consecutivoPpal, dtgPlanAsociadas.Item("#", fila).Value)) Then
                                enviarCorreoAnulacionPlanilla(consecutivoPpal, dtgPlanAsociadas.Item("#", fila).Value, motivo)
                            End If
                            dtgPlanAsociadas.Rows.RemoveAt(e.RowIndex)
                            MessageBox.Show("El consecutivo y la eficiencia  fueron eliminados con exito! ", "Correcto!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Else
                            MessageBox.Show("Error al eliminar el consecutivo,comuniquese con el administrador del sistema! ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    Else
                        MessageBox.Show("Para anular el consecutivo es obligatorio el motivo! ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If

                End If
            Else
                Dim sql As String
                cargarTblProdOp(dtgPlanAsociadas.Item("#", fila).Value)
                ActCantPend()
                TblPpal.SelectedTab = tblProdOp
                'cargarPlanInsp()
                cargarPlanInspCal()
                'Cargar limite de planillas de referencias 125 y 124
                If prod_f_trb.ToUpper Like "22B100142*" Or prod_f_trb.ToUpper Like "22B100125*" Then
                    Dim lim_local As String
                    sql = "select limite_lote from  J_det_orden_prod  where cod_orden=" & consecutivoPpal & " and id_detalle=" & consecutivoDet & ""
                    lim_local = obj_Ing_prodLn.consultar_valor(sql, "PRODUCCION")
                    If lim_local <> "0" Then
                        actualizar_limite(CInt(lim_local))
                    End If
                End If
                actualizar_mp()
            End If
        End If
    End Sub
    Declare Function SendMessage Lib "user32" Alias "SendMessageA" (ByVal hwnd As Integer, ByVal wMsg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer

    Private Sub enviarCorreoAnulacionPlanilla(ByVal cod_orden As Double, ByVal id_detalle As Integer, ByVal motivo As String)
        Dim sql_admin As String = "SELECT mail,Mail_login  FROM Jjv_usuarios WHERE usuario = 'ADMIN' "
        Dim dt_admin As DataTable = objOpsimpesLn.listar_datatable(sql_admin, "CORSAN")
        Dim mail As String = objOpsimpesLn.returnCorreosModulo("nodOrdenProd")
        Dim asunto As String = "SMPP "
        Dim sql_fec_transaccion As String = "SELECT fec_hora_fin FROM J_det_orden_prod  WHERE cod_orden = " & cod_orden & " AND id_detalle =" & id_detalle & " "
        Dim fecha_transaccion As String = obj_Ing_prodLn.consultValor(sql_fec_transaccion, "PRODUCCION")
        Dim cuerpo As String = "Número de la orden : " & cod_orden & " - detalle : " & id_detalle & vbCrLf &
                                "Motivo: " & motivo & vbCrLf &
                                "Fecha: " & fecha_transaccion
        Dim mailEnvia As String = dt_admin.Rows(0).Item("mail")
        Dim mailEnviaPass As String = dt_admin.Rows(0).Item("Mail_login")
        obj_correoLn.EnviarCorreo(mail, cuerpo, asunto, "", mailEnvia, mailEnviaPass, False)
    End Sub
    Private Sub enviarCorreoSmppSinStock(ByVal cod_orden As Double, ByVal id_detalle As Integer, ByVal cantidad As Double)
        Dim sql_admin As String = "SELECT mail,Mail_login  FROM Jjv_usuarios WHERE usuario = 'ADMIN' "
        Dim dt_admin As DataTable = objOpsimpesLn.listar_datatable(sql_admin, "CORSAN")
        Dim mail As String
        Dim asunto As String = "SMPP sin stock"
        Dim cuerpo As String = "Número de la orden : " & cod_orden & " - detalle : " & id_detalle & vbCrLf &
                               "Cantidad : " & cantidad & " " & vbCrLf &
                               "Fecha: " & Now
        Dim mailEnvia As String = dt_admin.Rows(0).Item("mail")
        Dim mailEnviaPass As String = dt_admin.Rows(0).Item("Mail_login")
        mail = "david.hincapie@corsan.com.co"
        obj_correoLn.EnviarCorreo(mail, cuerpo, asunto, "", mailEnvia, mailEnviaPass, False)
        mail = "isabel.gomez@corsan.com.co"
        obj_correoLn.EnviarCorreo(mail, cuerpo, asunto, "", mailEnvia, mailEnviaPass, False)
        mail = "contabilidad@corsan.com.co"
        obj_correoLn.EnviarCorreo(mail, cuerpo, asunto, "", mailEnvia, mailEnviaPass, False)
        mail = "hugo.zapata@corsan.com.co"
        obj_correoLn.EnviarCorreo(mail, cuerpo, asunto, "", mailEnvia, mailEnviaPass, False)
    End Sub
    Private Sub enviarCorreoInicioPlanilla(ByVal cod_orden As Double, ByVal id_detalle As Integer)
        Dim sql_admin As String = "SELECT mail,Mail_login  FROM Jjv_usuarios WHERE usuario = 'ADMIN' "
        Dim dt_admin As DataTable = objOpsimpesLn.listar_datatable(sql_admin, "CORSAN")
        Dim mail As String = "diego.vargas@corsan.com.co"
        Dim maquina As String = cbo_maquina.Text
        Dim codigo As String = txtProdFinal.Text
        Dim cliente As String = cboCliente.Text
        Dim asunto As String = "Planilla para " & cliente & " , código:" & codigo & "; comenzó"
        Dim cuerpo As String = "Número de la orden : " & cod_orden & " - detalle : " & id_detalle & vbCrLf &
                                "Maquina : " & maquina & " " & vbCrLf &
                               "Cliente : " & cliente & " " & vbCrLf &
                               "Código : " & codigo & " " & vbCrLf &
                                                           "Fecha: " & Now
        Dim mailEnvia As String = dt_admin.Rows(0).Item("mail")
        Dim mailEnviaPass As String = dt_admin.Rows(0).Item("Mail_login")

        If txtProdFinal.Text.Contains("33") Then
            obj_correoLn.EnviarCorreo(mail, cuerpo, asunto, "", mailEnvia, mailEnviaPass, False)
            mail = "calidad.producto@corsan.com.co"
            obj_correoLn.EnviarCorreo(mail, cuerpo, asunto, "", mailEnvia, mailEnviaPass, False)
            mail = "serviciocliente@corsan.com.co"
            obj_correoLn.EnviarCorreo(mail, cuerpo, asunto, "", mailEnvia, mailEnviaPass, False)
            mail = "practicantes.calidad@corsan.com.co"
            obj_correoLn.EnviarCorreo(mail, cuerpo, asunto, "", mailEnvia, mailEnviaPass, False)
        End If

    End Sub
    Private Sub enviarCorreoFinPlanilla(ByVal cod_orden As Double, ByVal id_detalle As Integer)
        Dim sql_admin As String = "SELECT mail,Mail_login  FROM Jjv_usuarios WHERE usuario = 'ADMIN' "
        Dim dt_admin As DataTable = objOpsimpesLn.listar_datatable(sql_admin, "CORSAN")
        Dim mail As String = "diego.vargas@corsan.com.co"
        Dim maquina As String = cbo_maquina.Text
        Dim codigo As String = txtProdFinal.Text
        Dim cliente As String = cboCliente.Text
        Dim asunto As String = "Planilla para " & cliente & " , código:" & codigo & "; Finalizo"
        Dim cuerpo As String = "Número de la orden : " & cod_orden & " - detalle : " & id_detalle & vbCrLf &
                                "Maquina : " & maquina & " " & vbCrLf &
                               "Cliente : " & cliente & " " & vbCrLf &
                               "Código : " & codigo & " " & vbCrLf &
                               "Cantidad(kg): " & txtCantTurno.Text & vbCrLf &
                                                           "Fecha: " & Now
        Dim mailEnvia As String = dt_admin.Rows(0).Item("mail")
        Dim mailEnviaPass As String = dt_admin.Rows(0).Item("Mail_login")
        If txtProdFinal.Text.Contains("33") Then
            obj_correoLn.EnviarCorreo(mail, cuerpo, asunto, "", mailEnvia, mailEnviaPass, False)
            mail = "calidad.producto@corsan.com.co"
            obj_correoLn.EnviarCorreo(mail, cuerpo, asunto, "", mailEnvia, mailEnviaPass, False)
            mail = "serviciocliente@corsan.com.co"
            obj_correoLn.EnviarCorreo(mail, cuerpo, asunto, "", mailEnvia, mailEnviaPass, False)
            mail = "practicantes.calidad@corsan.com.co"
            obj_correoLn.EnviarCorreo(mail, cuerpo, asunto, "", mailEnvia, mailEnviaPass, False)
            mail = "hugo.zapata@corsan.com.co"
            obj_correoLn.EnviarCorreo(mail, cuerpo, asunto, "", mailEnvia, mailEnviaPass, False)
        End If
    End Sub
    Private Sub enviarCorreoErrorEppp(ByVal cod_orden As Double, ByVal id_detalle As Integer)
        Dim sql_admin As String = "SELECT mail,Mail_login  FROM Jjv_usuarios WHERE usuario = 'ADMIN' "
        Dim dt_admin As DataTable = objOpsimpesLn.listar_datatable(sql_admin, "CORSAN")
        Dim mail As String = "isabel.gomez@corsan.com.co"
        Dim maquina As String = cbo_maquina.Text
        Dim codigo As String = txtProdFinal.Text
        Dim cliente As String = cboCliente.Text
        Dim asunto As String = "Error En la EPPP de la Planilla para " & cliente & " , código:" & codigo & "; Finalizo"
        Dim cuerpo As String = "Número de la orden : " & cod_orden & " - detalle : " & id_detalle & vbCrLf &
                                "Maquina : " & maquina & " " & vbCrLf &
                               "Cliente : " & cliente & " " & vbCrLf &
                               "Código : " & codigo & " " & vbCrLf &
                               "Cantidad(kg): " & txtCantTurno.Text & vbCrLf &
                                                           "Fecha: " & Now
        Dim mailEnvia As String = dt_admin.Rows(0).Item("mail")
        Dim mailEnviaPass As String = dt_admin.Rows(0).Item("Mail_login")
        obj_correoLn.EnviarCorreo(mail, cuerpo, asunto, "", mailEnvia, mailEnviaPass, False)
        mail = "david.hincapie@corsan.com.co"
        obj_correoLn.EnviarCorreo(mail, cuerpo, asunto, "", mailEnvia, mailEnviaPass, False)
    End Sub
    Private Sub enviarCorreoFinPlanillaEspe(ByVal cod_orden As Double, ByVal id_detalle As Integer)
        Dim sql_admin As String = "SELECT mail,Mail_login  FROM Jjv_usuarios WHERE usuario = 'ADMIN' "
        Dim dt_admin As DataTable = objOpsimpesLn.listar_datatable(sql_admin, "CORSAN")
        Dim mail As String = "hector.echeverri@corsan.com.co"
        Dim maquina As String = cbo_maquina.Text
        Dim codigo As String = txtProdFinal.Text
        Dim cliente As String = cboCliente.Text
        Dim asunto As String = "Se ha terminado la orden para " & cliente & " , código:" & codigo & "; Finalizo con"
        Dim cuerpo As String = " el Número de la orden : " & cod_orden & " - detalle : " & id_detalle & vbCrLf &
                                "Maquina : " & maquina & " " & vbCrLf &
                               "Cliente : " & cliente & " " & vbCrLf &
                               "Código : " & codigo & " " & vbCrLf &
                               "Cantidad(kg): " & txtCantTurno.Text & vbCrLf &
                                                           "Fecha: " & Now
        Dim mailEnvia As String = dt_admin.Rows(0).Item("mail")
        Dim mailEnviaPass As String = dt_admin.Rows(0).Item("Mail_login")
        obj_correoLn.EnviarCorreo(mail, cuerpo, asunto, "", mailEnvia, mailEnviaPass, False)
        mail = "serviciocliente@corsan.com.co"
        obj_correoLn.EnviarCorreo(mail, cuerpo, asunto, "", mailEnvia, mailEnviaPass, False)
    End Sub
    Private Sub enviarCorreoErrorSCAE(ByVal cod_orden As Double, ByVal id_detalle As Integer, ByVal id_rollo As Integer, ByVal scaeb As Integer)
        Dim sql_admin As String = "SELECT mail,Mail_login  FROM Jjv_usuarios WHERE usuario = 'ADMIN' "
        Dim dt_admin As DataTable = objOpsimpesLn.listar_datatable(sql_admin, "CORSAN")
        Dim mail As String = "julian.bayer@corsan.com.co"
        Dim asunto As String = "Error SCAE"
        Dim cuerpo As String = "Error al realizar un SCAE" & vbCrLf &
                               "Orden: " & consecutivoPpal & " " & vbCrLf &
                               "Planilla: " & consecutivoDet & vbCrLf &
                               "Consecutivo:" & cod_orden & "-" & id_detalle & "-" & id_rollo & vbCrLf &
                               "SCAE: " & scaeb & vbCrLf &
                               "Fecha: " & Now
        Dim mailEnvia As String = dt_admin.Rows(0).Item("mail")
        Dim mailEnviaPass As String = dt_admin.Rows(0).Item("Mail_login")
        obj_correoLn.EnviarCorreo(mail, cuerpo, asunto, "", mailEnvia, mailEnviaPass, False)
        mail = "juan.paniagua@corsan.com.co"
        obj_correoLn.EnviarCorreo(mail, cuerpo, asunto, "", mailEnvia, mailEnviaPass, False)
        mail = "david.hincapie@corsan.com.co"
        obj_correoLn.EnviarCorreo(mail, cuerpo, asunto, "", mailEnvia, mailEnviaPass, False)
    End Sub
    Private Sub dtgDiametros_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgDiametros.CellValueChanged
        If (e.RowIndex >= 0 And cargaComp) Then
            Dim nomb_col As String = dtgDiametros.Columns(e.ColumnIndex).Name
            If (nomb_col = "colCamHil1" Or nomb_col = "colCamHil2" Or nomb_col = "colCamHil3" Or nomb_col = "colCamHil4") Then
                If (dtgDiametros.Item(e.ColumnIndex, e.RowIndex).Value.ToString <> "") Then
                    If (dtgDiametros.Item(e.ColumnIndex, e.RowIndex).Value < 1 Or dtgDiametros.Item(e.ColumnIndex, e.RowIndex).Value > 10) Then
                        MessageBox.Show("El diametro debe estar entre 1 y 10, verifique que el número tenga el (.) punto decimal", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        dtgDiametros.Item(e.ColumnIndex, e.RowIndex).Value = ""
                    Else
                        calc_poc_reduccion(e.RowIndex, e.ColumnIndex)
                        If Not (guardarCambHileras(e.RowIndex, e.ColumnIndex)) Then
                            MessageBox.Show("Error al guardar los cambios de hilera, comuniquese el administrador del sistema ó verifique que solo se ingresaron números! ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub btnBod1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBod1.Click
        FrmCodBodebas.Show()
        FrmCodBodebas.Activate()
        FrmCodBodebas.main("1", "MP")
    End Sub
    Private Sub btn_b1_2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_b1_2.Click
        FrmCodBodebas.Show()
        FrmCodBodebas.Activate()
        FrmCodBodebas.main("1", "AL")
    End Sub
    Private Sub btnBod2_3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBod2_3.Click
        FrmCodBodebas.Show()
        FrmCodBodebas.Activate()
        FrmCodBodebas.main("2,3", "PF")
        txtTracMax.Text = ""
        txtTracMin.Text = ""
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
    Private Sub txtDiametro_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        soloNumero(e)
    End Sub
    Private Sub txt_diam_alambron_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        soloNumero(e)
    End Sub
    Private Sub txtDiaMin_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDiaMin.KeyPress
        soloNumero(e)
    End Sub

    Private Sub txtDiamMAx_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDiamMAx.KeyPress
        soloNumero(e)
    End Sub

    Private Sub txtTracMin_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTracMin.KeyPress
        soloNumero(e)
    End Sub

    Private Sub txtTracMax_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTracMax.KeyPress
        soloNumero(e)
    End Sub
    Private Sub btnActOrdenes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        cargarPlanOperario()
    End Sub
    Private Sub dtg_consulta_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtg_consulta.CellContentClick
        Dim col As String = dtg_consulta.Columns(e.ColumnIndex).Name
        If (col = btnVerDetalle.Name) Then
            actualizarConsecutivoPpal(dtg_consulta.Item("número", dtg_consulta.CurrentCell.RowIndex).Value)
            actualizarConsecutivoDet(0)
            cargarDatos()
            cargarDtgAsociado("TODOS")
            permiso_aux()
            TblPpal.SelectedTab = tblOrdenProd
            dtgPlanInsp.DataSource = Nothing
            dtg_Inp_Calidad.DataSource = Nothing
            pintarPlanNoCerradas()
            actualizar_mp()
        ElseIf (col = col_oculto.Name) Then
            Dim sql As String
            Dim bloqueo As String
            sql = "select oculto from J_orden_prod_tef WHERE consecutivo = " & dtg_consulta.Item("número", dtg_consulta.CurrentCell.RowIndex).Value & ""
            bloqueo = objOpsimpesLn.consultValorTodo(sql, "PRODUCCION")
            If bloqueo = "0" Or bloqueo = "" Then
                If (MessageBox.Show("Esta seguro que desea liquidar y ocultar la orden.Ya no se puede trabajar una orden liquidada, tenga en cuenta que si oculta una orden no se vera en los computadores de las trefiladoras", "ocultar orden?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) = 6) Then
                    If (MessageBox.Show("Desea agregar nota de liquidación", "Nota al liquidar?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) = 6) Then
                        Dim frm As New frm_Bloquear_ordenes
                        frm.main(dtg_consulta.Item("número", dtg_consulta.CurrentCell.RowIndex).Value, "T")
                        frm.ShowDialog()
                    End If
                    Dim estado As Integer = 1
                    Dim accion As String = "Liquido"
                    cargaComp = False
                    If Not IsDBNull(dtg_consulta.Item("oculto", e.RowIndex).Value) Then
                        If (dtg_consulta.Item("oculto", e.RowIndex).Value = 0) Then
                            estado = 1
                            dtg_consulta.Item(col, e.RowIndex).Value = Spic.My.Resources.ok3
                            dtg_consulta.Item("oculto", e.RowIndex).Value = estado
                        End If
                    Else
                        estado = 1
                        dtg_consulta.Item(col, e.RowIndex).Value = Spic.My.Resources.ok3
                        dtg_consulta.Item("oculto", e.RowIndex).Value = estado
                    End If
                    sql = "UPDATE J_orden_prod_tef SET oculto = " & estado & ",bloqueo=" & estado & ",notas_auditoria +=  '" & accion & " " & usuario & " " & Now.Date & "' WHERE consecutivo = " & dtg_consulta.Item("número", dtg_consulta.CurrentCell.RowIndex).Value
                    If (objOpsimpesLn.ejecutar(sql, "PRODUCCION")) Then
                        MessageBox.Show("La orden se liquido en forma exitosa!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("Error al liquidar la orden, comuniquese con el administrador del sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                    cargaComp = True
                End If
            Else
                MessageBox.Show("Una orden liquidada no se puede desbloquear", "Orden Liquidada", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        ElseIf (col = col_duplicar.Name) Then
            Dim frm As New frm_Duplicar
            frm.main(dtg_consulta.Item("número", e.RowIndex).Value, usuario, dtg_consulta.Item("prod_final", e.RowIndex).Value, dtg_consulta.Item("materia_prima", e.RowIndex).Value, "T")
            frm.Show()
            cargarAdminProd(txtConsulNumOrd.Text)
        ElseIf (col = colChatarra.Name) Then
            Dim frm As New frm_chatarra_tref
            frm.main(dtg_consulta.Item("número", dtg_consulta.CurrentCell.RowIndex).Value, consecutivoDet, permiso)
            frm.ShowDialog()
        End If
    End Sub
    Private Sub pintarPlanNoCerradas()
        For i = 0 To dtgPlanAsociadas.RowCount - 1
            If IsDBNull(dtgPlanAsociadas.Item("cerrado", i).Value) Then
                dtgPlanAsociadas.Rows(i).DefaultCellStyle.BackColor = Color.Red
            End If
        Next
    End Sub

    Private Sub consultarEstadoMaq()
        Dim estado As String = obj_Ing_prodLn.consultar_valor("SELECT estadoMaq FROM J_det_orden_prod WHERE id_detalle =" & consecutivoDet & " AND cod_orden=" & consecutivoPpal, "PRODUCCION")
        If (estado = "0") Then
            estado = "Turno inactivo"
        End If
    End Sub

    Private Sub timRefescar_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timRefescar.Tick
        If (consecutivoPpal <> 1) Then
            cargarDtgAsociado("TODOS")
            If (consecutivoDet <> 0 And txtHoraFin.Text = "0" And txtHoraFin.Text <> "0") Then
                cargarTblProdOp(consecutivoDet)
            End If
            actualizar_mp()
        End If
    End Sub
    Private Function ingProdDms() As Boolean
        num_tran_amarres = 0
        num_tran_no_conforme = 0
        Dim val_kilos As Double = Convert.ToDouble(sumarProdTotal_d)
        Dim kilos As Double = Format(val_kilos, "#0.0")
        Dim codigo As String = txtProdFinal.Text
        Dim bodega As String = "2"
        Dim dFec As Date = Now
        Dim sql As String
        Dim fecha_hora As String
        Dim sFecha_hora As String = ""
        Dim notas As String = "SPIC  " & cbo_maquina.Text & " fecha:" & Now & " orden:" & consecutivoPpal & "-" & consecutivoDet
        Dim usuario As String = cboOperariosTurno.SelectedValue
        Dim mp As String = "" 'Dice si la materia prima es alambron o reproceso
        Dim listSql As New List(Of Object)
        Dim pc As String = My.Computer.Name
        Dim transaccion_smpp As Double = 0
        Dim cod_alambron As String = txtMatPrima.Text.ToUpper
        Dim bodega_alambron As Double = 2
        Dim valor_promedio As Double = 0
        Dim stock_alambron_b2 As Double = objOpsimpesLn.consultarStock(cod_alambron, bodega_alambron)
        If Not cod_alambron.Contains("22R") And Not cod_alambron.Contains("22X") Then
            Dim sql_valor_promedio As String = "SELECT Promedio  from v_referencias_cos  where codigo = '" & cod_alambron & "' and mes= " & Month(Now.Date) & " and ano = " & Year(Now.Date) & ""
            valor_promedio = objOpsimpesLn.consultarVal(sql_valor_promedio)
        End If
        If kilos > 0 Then
            If (objOrdenProdLn.insertarProxMes(codigo)) Then
                dFec = dFec.AddMonths(1)
                sFecha_hora = dFec.Year & "-" & dFec.Month & "-01"
                sFechaTransaccion = dFec.Year & "-" & dFec.Month & "-01"
                fecha_hora = "" & System.DateTime.Now.Month + 1 & "-" & "01" & "-" & System.DateTime.Now.Year & " " & System.DateTime.Now.Hour & ":" & System.DateTime.Now.Minute & ":" & System.DateTime.Now.Second & ""
            Else
                sFecha_hora = Format(Now, "yyyy/MM/dd HH:mm:ss")
                fecha_hora = "" & System.DateTime.Now.Month & "-" & System.DateTime.Now.Day & "-" & System.DateTime.Now.Year & " " & System.DateTime.Now.Hour & ":" & System.DateTime.Now.Minute & ":" & System.DateTime.Now.Second & ""
                sFechaTransaccion = dFec.Year & "-" & dFec.Month & "-" & dFec.Day
            End If
            num_tran_prod = objOrdenProdLn.mover_consecutivo("EPPP")
            Dim amarres As Double = Convert.ToDouble(txt_amarres.Text)
            Dim no_conforme As Double = Convert.ToDouble(txt_no_conforme.Text)
            'If amarres > 0 Then
            '    'Dim tipo_transaccion_amarres As String = "EDPV"
            '    'num_tran_amarres = objOrdenProdLn.mover_consecutivo(tipo_transaccion_amarres)
            '    ' Dim codigo_amarres As String = "3H0000008"
            '    '  Dim bodega_amarres As Double = "3"
            '    ' Dim sql_valor_promedio_amarres As String = "SELECT Promedio  from v_referencias_cos  where codigo = '" & codigo_amarres & "' and mes= " & Month(Now.Date) & " and ano = " & Year(Now.Date) & ""
            '    'Dim valor_promedio_amarres As Double = objOpsimpesLn.consultarVal(sql_valor_promedio_amarres)
            '    'listSql.AddRange(objTraslado_bodLn.transaccion_alambron_b2(amarres, codigo_amarres, bodega_amarres, dFec, notas, usuario, tipo_transaccion_amarres, valor_promedio_amarres, num_tran_amarres))
            'End If
            'If no_conforme > 0 Then
            'Dim tipo_transaccion_no_conforme As String = "EDPV"
            'num_tran_no_conforme = objOrdenProdLn.mover_consecutivo(tipo_transaccion_no_conforme)
            'Dim codigo_no_conforme As String = "3H0000007"
            'Dim bodega_no_conforme As Double = "3"
            'Dim sql_valor_promedio_no_conforme As String = "SELECT Promedio  from v_referencias_cos  where codigo = '" & codigo_no_conforme & "' and mes= " & Month(Now.Date) & " and ano = " & Year(Now.Date) & ""
            'Dim valor_promedio_no_conforme As Double = objOpsimpesLn.consultarVal(sql_valor_promedio_no_conforme)
            'listSql.AddRange(objTraslado_bodLn.transaccion_alambron_b2(no_conforme, codigo_no_conforme, bodega_no_conforme, dFec, notas, usuario, tipo_transaccion_no_conforme, valor_promedio_no_conforme, num_tran_no_conforme))
            'End If
            listSql.AddRange(objOrdenProdLn.ingProdDms(kilos, codigo, bodega, dFec, notas, usuario, consecutivoDet, consecutivoPpal, mp, num_tran_prod, "EPPP", sFechaTransaccion, sFecha_hora))
            If Not txtMatPrima.Text.Contains("22B") And Not txtMatPrima.Text.Contains("22R") And Not txtMatPrima.Text.Contains("22X") Then
                If kilos > stock_alambron_b2 Then
                    transaccion_smpp = 1
                    enviarCorreoSmppSinStock(consecutivoPpal, consecutivoDet, kilos)
                    MessageBox.Show("No se puede cerrar planilla sin stock", "Cerrar planilla sin stock", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.Close()
                Else
                    transaccion_smpp = objOrdenProdLn.mover_consecutivo("SMPP")
                    listSql.AddRange(objTraslado_bodLn.transaccion_alambron_b2(kilos, cod_alambron, 2, dFec, notas, usuario, "SMPP", valor_promedio, transaccion_smpp))
                End If
            End If

            Dim sql_ing_auditoria As String = "INSERT INTO J_transac_spic_dms (numero,tipo,fecha,usuario,pc,cantidad,notas,id_detalle,cod_orden) " &
                                "VALUES(" & num_tran_prod & ",'" & "EPPP" & "','" & objOpsimpesLn.cambiarFormatoFecha(dFec) & "','" & usuario & "','" & pc & "'," & kilos & ",'" & notas & "'," & consecutivoDet & "," & consecutivoPpal & ")"
            If objOpsimpesLn.ejecutar(sql_ing_auditoria, "PRODUCCION") = 0 Then
                MessageBox.Show("Error al ingresar la auditoria, no cierre la planilla y comuniquese con sistemas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            If objOpsimpesLn.ExecuteSqlTransaction(listSql) Then
                If cboMaquinaConsulta.Text <> "Seleccione" Then
                    sql = "UPDATE J_tref_cont_mp SET peso_lleva-=" & kilos & " WHERE codigoM= " & cboMaquinaConsulta.SelectedValue & " and ano=" & cbo_fec_orden.Value.Year & " and mes=" & cbo_fec_orden.Value.Month & " and cod_alambron='" & txtMatPrima.Text & "'"
                Else
                    sql = "UPDATE J_tref_cont_mp SET peso_lleva-=" & kilos & " WHERE codigoM= " & cboMaquinaFiltro.SelectedValue & " and ano=" & cbo_fec_orden.Value.Year & " and mes=" & cbo_fec_orden.Value.Month & " and cod_alambron='" & txtMatPrima.Text & "'"
                End If
                objOpSimplesLn.ejecutar(sql, "PRODUCCION")
                actualizar_mp()
                Return True
            Else
                Return False
            End If
        Else
            objOpsimpesLn.ejecutar(objOrdenProdLn.updateTransaccionesOrden(0, consecutivoDet, consecutivoPpal), "PRODUCCION")
            Return True
        End If
    End Function
    Private Function ingProdDmsForzo() As Boolean
        num_tran_amarres = 0
        num_tran_no_conforme = 0
        Dim val_kilos As Double = Convert.ToDouble(sumarProdTotal_d)
        Dim kilos As Double = Format(val_kilos, "#0.0")
        Dim codigo As String = txtProdFinal.Text
        Dim bodega As String = "2"
        Dim dFec As Date = Now
        Dim sql As String
        Dim fecha_hora As String
        Dim sFecha_hora As String = ""
        Dim notas As String = "SPIC  " & cbo_maquina.Text & " fecha:" & Now & " orden:" & consecutivoPpal & "-" & consecutivoDet
        Dim usuario As String = cboOperariosTurno.SelectedValue
        Dim mp As String = "" 'Dice si la materia prima es alambron o reproceso
        Dim listSql As New List(Of Object)
        Dim pc As String = My.Computer.Name
        Dim transaccion_smpp As Double = 0
        Dim cod_alambron As String = txtMatPrima.Text
        Dim bodega_alambron As Double = 2
        Dim stock_alambron_b2 As Double = objOpsimpesLn.consultarStock(cod_alambron, bodega_alambron)
        Dim sql_valor_promedio As String = "SELECT Promedio  from v_referencias_cos  where codigo = '" & cod_alambron & "' and mes= " & Month(Now.Date) & " and ano = " & Year(Now.Date) & ""
        Dim valor_promedio As Double = objOpsimpesLn.consultarVal(sql_valor_promedio)
        If kilos > 0 Then
            If (objOrdenProdLn.insertarProxMes(codigo)) Then
                dFec = dFec.AddMonths(1)
                sFecha_hora = dFec.Year & "-" & dFec.Month & "-01"
                sFechaTransaccion = dFec.Year & "-" & dFec.Month & "-01"
                fecha_hora = "" & System.DateTime.Now.Month + 1 & "-" & "01" & "-" & System.DateTime.Now.Year & " " & System.DateTime.Now.Hour & ":" & System.DateTime.Now.Minute & ":" & System.DateTime.Now.Second & ""
            Else
                sFecha_hora = Format(Now, "yyyy/MM/dd HH:mm:ss")
                fecha_hora = "" & System.DateTime.Now.Month & "-" & System.DateTime.Now.Day & "-" & System.DateTime.Now.Year & " " & System.DateTime.Now.Hour & ":" & System.DateTime.Now.Minute & ":" & System.DateTime.Now.Second & ""
                sFechaTransaccion = dFec.Year & "-" & dFec.Month & "-" & dFec.Day
            End If
            num_tran_prod = objOrdenProdLn.mover_consecutivo("EPPP")
            Dim amarres As Double = Convert.ToDouble(txt_amarres.Text)
            Dim no_conforme As Double = Convert.ToDouble(txt_no_conforme.Text)
            'If amarres > 0 Then
            '    'Dim tipo_transaccion_amarres As String = "EDPV"
            '    'num_tran_amarres = objOrdenProdLn.mover_consecutivo(tipo_transaccion_amarres)
            '    ' Dim codigo_amarres As String = "3H0000008"
            '    '  Dim bodega_amarres As Double = "3"
            '    ' Dim sql_valor_promedio_amarres As String = "SELECT Promedio  from v_referencias_cos  where codigo = '" & codigo_amarres & "' and mes= " & Month(Now.Date) & " and ano = " & Year(Now.Date) & ""
            '    'Dim valor_promedio_amarres As Double = objOpsimpesLn.consultarVal(sql_valor_promedio_amarres)
            '    'listSql.AddRange(objTraslado_bodLn.transaccion_alambron_b2(amarres, codigo_amarres, bodega_amarres, dFec, notas, usuario, tipo_transaccion_amarres, valor_promedio_amarres, num_tran_amarres))
            'End If
            'If no_conforme > 0 Then
            'Dim tipo_transaccion_no_conforme As String = "EDPV"
            'num_tran_no_conforme = objOrdenProdLn.mover_consecutivo(tipo_transaccion_no_conforme)
            'Dim codigo_no_conforme As String = "3H0000007"
            'Dim bodega_no_conforme As Double = "3"
            'Dim sql_valor_promedio_no_conforme As String = "SELECT Promedio  from v_referencias_cos  where codigo = '" & codigo_no_conforme & "' and mes= " & Month(Now.Date) & " and ano = " & Year(Now.Date) & ""
            'Dim valor_promedio_no_conforme As Double = objOpsimpesLn.consultarVal(sql_valor_promedio_no_conforme)
            'listSql.AddRange(objTraslado_bodLn.transaccion_alambron_b2(no_conforme, codigo_no_conforme, bodega_no_conforme, dFec, notas, usuario, tipo_transaccion_no_conforme, valor_promedio_no_conforme, num_tran_no_conforme))
            'End If
            listSql.AddRange(objOrdenProdLn.ingProdDms(kilos, codigo, bodega, dFec, notas, usuario, consecutivoDet, consecutivoPpal, mp, num_tran_prod, "EPPP", sFechaTransaccion, sFecha_hora))
            If Not txtMatPrima.Text.Contains("22B") And Not txtMatPrima.Text.Contains("22R") And Not txtMatPrima.Text.Contains("22X") Then
                kilos = CInt(lbl_mat.Text)
                If kilos > stock_alambron_b2 Then
                    transaccion_smpp = 1
                    enviarCorreoSmppSinStock(consecutivoPpal, consecutivoDet, kilos)
                    MessageBox.Show("No se puede cerrar planilla sin stock", "Cerrar planilla sin stock", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.Close()
                Else
                    transaccion_smpp = objOrdenProdLn.mover_consecutivo("SMPP")
                    listSql.AddRange(objTraslado_bodLn.transaccion_alambron_b2(kilos, cod_alambron, 2, dFec, notas, usuario, "SMPP", valor_promedio, transaccion_smpp))
                End If
            End If
            kilos = CInt(txtCantTurno.Text)
            Dim sql_ing_auditoria As String = "INSERT INTO J_transac_spic_dms (numero,tipo,fecha,usuario,pc,cantidad,notas,id_detalle,cod_orden) " &
                                "VALUES(" & num_tran_prod & ",'" & "EPPP" & "','" & objOpsimpesLn.cambiarFormatoFecha(dFec) & "','" & usuario & "','" & pc & "'," & kilos & ",'" & notas & "'," & consecutivoDet & "," & consecutivoPpal & ")"
            If objOpsimpesLn.ejecutar(sql_ing_auditoria, "PRODUCCION") = 0 Then
                MessageBox.Show("Error al ingresar la auditoria, no cierre la planilla y comuniquese con sistemas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            If objOpsimpesLn.ExecuteSqlTransaction(listSql) Then
                kilos = CInt(lbl_mat.Text)
                If cboMaquinaConsulta.Text <> "Seleccione" Then
                    sql = "UPDATE J_tref_cont_mp SET peso_lleva-=" & kilos & " WHERE codigoM= " & cboMaquinaConsulta.SelectedValue & " and ano=" & cbo_fec_orden.Value.Year & " and mes=" & cbo_fec_orden.Value.Month & " and cod_alambron='" & txtMatPrima.Text & "'"
                Else
                    sql = "UPDATE J_tref_cont_mp SET peso_lleva-=" & kilos & " WHERE codigoM= " & cboMaquinaFiltro.SelectedValue & " and ano=" & cbo_fec_orden.Value.Year & " and mes=" & cbo_fec_orden.Value.Month & " and cod_alambron='" & txtMatPrima.Text & "'"
                End If
                objOpSimplesLn.ejecutar(sql, "PRODUCCION")
                actualizar_mp()
                Return True
            Else
                Return False
            End If
        Else
            objOpsimpesLn.ejecutar(objOrdenProdLn.updateTransaccionesOrden(0, consecutivoDet, consecutivoPpal), "PRODUCCION")
            Return True
        End If
    End Function
    Private Sub txtHorometroIni_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtHorometroIni.TextChanged
        If (txtHorometroIni.Text.Count >= 2 And IsNumeric(txtHorometroIni.Text)) Then
            Dim valor As Double = txtHorometroIni.Text
            Dim horometro As String = "HorometroIni"
            If (objOrdenProdLn.updateHorometro(valor, horometro, consecutivoDet, consecutivoPpal) = 0) Then
                MsgBox("Error al ingresar el horometro, cominicarse con el administrador del sistema y continuar su trabajo normalmente!")
            End If
        End If
    End Sub

    Private Sub txtHorometroFin_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtHorometroFin.TextChanged
        If (txtHorometroFin.Text.Count >= 2 And IsNumeric(txtHorometroFin.Text)) Then
            Dim valor As Double = txtHorometroFin.Text
            Dim horometro As String = "HorometroFin"
            If (objOrdenProdLn.updateHorometro(valor, horometro, consecutivoDet, consecutivoPpal) = 0) Then
                MsgBox("Error al ingresar el horometro, cominicarse con el administrador del sistema y continuar su trabajo normalmente!")
            End If
        End If

    End Sub
    Private Sub txt_amarres_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_amarres.TextChanged
        If (txt_amarres.Text.Count >= 0 And IsNumeric(txt_amarres.Text)) Then
            Dim valor As Double = txt_amarres.Text
            If valor <= 150 Then
                Dim sql As String
                sql = "UPDATE J_det_orden_prod SET amarres +=" & valor & "  WHERE  id_detalle =" & consecutivoDet & " AND cod_orden =" & consecutivoPpal
                If (objOpsimpesLn.ejecutar(sql, "PRODUCCION") = 0) Then
                    MsgBox("Error al ingresar los amarres, cominicarse con el administrador del sistema y continuar su trabajo normalmente!")
                End If
            Else
                MessageBox.Show("Excedio el máximo de kilos de amarres ", "Máximo excedido", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txt_amarres.Text = 0
            End If
        End If
    End Sub
    Private Sub txt_no_conforme_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_no_conforme.TextChanged
        If (txt_no_conforme.Text.Count >= 0 And IsNumeric(txt_no_conforme.Text)) Then
            Dim valor As Double = txt_no_conforme.Text
            If valor <= 150 Then
                Dim sql As String = "UPDATE J_det_orden_prod SET desperdicio =" & valor & "  WHERE  id_detalle =" & consecutivoDet & " AND cod_orden =" & consecutivoPpal
                If (objOpsimpesLn.ejecutar(sql, "PRODUCCION") = 0) Then
                    MsgBox("Error al ingresar el desperdicio, cominicarse con el administrador del sistema y continuar su trabajo normalmente!")
                End If
            Else
                MessageBox.Show("Excedio el máximo de kilos de desperdicio ", "Máximo excedido", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txt_no_conforme.Text = 0
            End If
        End If
    End Sub
    Private Sub txtHorometroFin_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtHorometroFin.KeyPress
        soloNumero(e)
    End Sub
    Private Sub txtHorometroIni_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtHorometroIni.KeyPress
        soloNumero(e)
    End Sub
    Private Sub ingProdEfic()
        Dim respValHoro As String = objOrdenProdLn.validarHorometro(txtHorometroIni.Text, txtHorometroFin.Text)
        Dim velocidad As Double = cboVel.SelectedValue
        Dim operario As String = obj_Ing_prodLn.consultar_valor("SELECT operario FROM J_det_orden_prod  WHERE cod_orden = " & consecutivoPpal & " AND id_detalle = " & consecutivoDet & "", "PRODUCCION")
        If operario = "" Then
            operario = "0"
        End If
        Dim fecha As String = ""
        Dim resp As Boolean = False
        If (Now.Hour >= 0 And Now.Hour <= 5) Then
            fecha = objOpsimpesLn.cambiarFormatoFecha((Now.AddDays(-1)).Date)
        Else
            fecha = objOpsimpesLn.cambiarFormatoFecha(Now.Date)
        End If
        Dim turno As Integer = cboTurno.SelectedValue
        Dim maquina As Integer = cbo_maquina.SelectedValue
        Dim calibre As Double = txtDiaMin.Text
        Dim destino As Double = cboCliente.SelectedValue
        Dim fec_hora_ini As Date = obj_Ing_prodLn.consultar_valor("SELECT  fec_hora_ini FROM J_det_orden_prod  WHERE cod_orden = " & consecutivoPpal & " AND id_detalle = " & consecutivoDet & "", "PRODUCCION")
        Dim fec_hora_fin As Date = obj_Ing_prodLn.consultar_valor("SELECT  fec_hora_fin FROM J_det_orden_prod  WHERE cod_orden = " & consecutivoPpal & " AND id_detalle = " & consecutivoDet & "", "PRODUCCION")
        Dim hora_ini As String = Format(fec_hora_ini, "HH:mm:ss")
        Dim hora_fin As String = Format(fec_hora_fin, "HH:mm:ss")
        Dim sFec_hora_ini As String = Format(fec_hora_ini, "yyyy-MM-dd HH:mm:ss")
        Dim sFec_hora_fin As String = Format(fec_hora_fin, "yyyy-MM-dd HH:mm:ss")
        Dim min_prog As Double = DateDiff(DateInterval.Minute, fec_hora_ini, fec_hora_fin)
        If Not (chkInterno.Checked) Then
            destino = 1
        End If
        Dim notas As String = txtNotas.Text

        'Dim horaIni As Date = Now.ToShortTimeString
        'Dim horaFin As Date = Now.ToShortTimeString
        'horaIni = horaFin.AddHours(-3)
        'respValHoro = DateDiff(DateInterval.Minute, horaFin, horaIni)
        ''If (horaIni > horaFin) Then
        ''    horaFin = horaFin.AddHours(12)
        ''End If
        'If (respValHoro < 0) Then
        '    respValHoro *= -1
        'End If
        Dim min_trab As Double = obj_Ing_prodLn.calcularHorometro(txtHorometroIni.Text, txtHorometroFin.Text)
        Dim kil_esp As Double = objOrdenProdLn.calcEsperada(velocidad, calibre, min_prog)
        Dim alamb As Double = 0
        Dim rep As Double = 0
        Dim paro1 As Integer = 0
        Dim paro2 As Integer = 0
        Dim paro3 As Integer = 0
        Dim paro4 As Integer = 0
        Dim paro5 As Integer = 0
        Dim paro6 As Integer = 0
        Dim paro7 As Integer = 0
        Dim paro8 As Integer = 0
        Dim paro9 As Integer = 0
        Dim paro10 As Integer = 0
        Dim paro0 As Integer = 0
        Dim paro11 As Integer = 0
        Dim paro12 As Integer = 0
        Dim paro13 As Integer = 0
        Dim tiempoParo As Integer = 0
        If (esReproceso()) Then
            rep = sumarProdTotal()
        Else
            alamb = sumarProdTotal()
        End If
        For i = 0 To dtgParo.RowCount - 1
            If Not IsNothing(dtgParo.Item("colTotal", i).Value) Then
                If (dtgParo.Item("colTotal", i).Value.ToString <> "") Then
                    tiempoParo = dtgParo.Item("colTotal", i).Value
                    Select Case dtgParo.Item("colCod", i).Value
                        Case 0
                            paro0 += tiempoParo
                        Case 1
                            paro1 += tiempoParo
                        Case 2
                            paro2 += tiempoParo
                        Case 3
                            paro3 += tiempoParo
                        Case 4
                            paro4 += tiempoParo
                        Case 5
                            paro5 += tiempoParo
                        Case 6
                            paro6 += tiempoParo
                        Case 7
                            paro7 += tiempoParo
                        Case 8
                            paro8 += tiempoParo
                        Case 9
                            paro9 += tiempoParo
                        Case 10
                            paro10 += tiempoParo
                        Case 11
                            paro11 += tiempoParo
                        Case 12
                            paro12 += tiempoParo
                        Case 13
                            paro13 += tiempoParo
                    End Select
                End If
            End If
        Next
        Dim sql As String = "INSERT INTO J_prod_tref_completo " &
                                   "(nit,fecha,turno,notas,maquina,cod_destino,h_ini,h_fin,diametro,alambron,reproceso,und_ini,und_fin,velocidad,Min_trab " &
                                   ",paro0,Paro1,paro2,paro3,paro4,paro5,paro6,paro7,paro8,paro9,paro10,paro11,paro12,paro13,consecutivo,id_detalle,fec_transaccion,tran_prod,tran_amarres,tran_no_confor) " &
                                        "  VALUES( " & operario & ",'" & fecha & "'," & turno & ",'" & notas & "'," & maquina & "," & destino & ",'" & sFec_hora_ini & "','" & sFec_hora_fin & "'," & calibre & "," & alamb & "," & rep & "," & txtHorometroIni.Text & "," & txtHorometroFin.Text & "," & velocidad & "," & min_trab & "," &
                                        paro0 & "," & paro1 & "," & paro2 & "," & paro3 & "," & paro4 & "," & paro5 & "," & paro6 & "," & paro7 & "," & paro8 & "," &
                                     paro9 & "," & paro10 & "," & paro11 & "," & paro12 & "," & paro13 & "," & consecutivoPpal & " ," & consecutivoDet & ",'" & sFechaTransaccion & "'," & num_tran_prod & "," & num_tran_amarres & "," & num_tran_no_conforme & ")"
        Dim listSql As New List(Of Object)
        listSql.Add(sql)
        Dim tipo As Integer = 0
        Dim causal As Integer = 0
        Dim defecto As Integer = 0

        If IsNumeric(txt_no_conforme.Text) Then
            ingreso_Defectos()
        End If
        If IsNumeric(txt_amarres.Text) Then
            If txt_amarres.Text > 0 Then
                tipo = 1
                causal = 3
                defecto = 38
                listSql.AddRange(sql_ing_desperdicios(fecha, operario, txt_amarres.Text, tipo, causal, defecto))
            End If
        End If
        resp = obj_Ing_prodLn.ExecuteSqlTransaction(listSql, "PRODUCCION")

        If resp Then
        Else
            MessageBox.Show("No se ingreso correctamente los indicadores", "Ingreso de indicadores", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Private Function sql_ing_desperdicios(ByVal fecha As String, ByVal nit As Double, ByVal kilos As Double, ByVal tipo As Integer, ByVal causal As Integer, ByVal defecto As Integer)
        Dim listSql As New List(Of Object)
        Dim id_existente As Integer = 0
        Dim observaciones As String = consecutivoPpal & "-" & consecutivoDet
        Dim destino As Integer = 1 ' para que todo lo lleve a Contenerdor Metalicos 
        Dim maquina As String = cbo_maquina.SelectedValue
        listSql.AddRange(obj_Ing_prodLn.guardar_desperdicio(fecha, nit, centro, kilos, tipo, causal, defecto, observaciones, id_existente, destino, maquina))
        Return listSql
    End Function
    Private Function esReproceso() As Boolean
        Dim materia_prima As String = txtMatPrima.Text.Trim
        If (materia_prima <> "") Then
            If materia_prima(0) = "2" Then
                Return True
            End If
        End If
        'For i = 0 To dtgProduccion.RowCount - 1
        '    If (dtgProduccion.Item("colOrdenPDN", i).Value <> "") Then
        '        Return True
        '    End If
        'Next
        Return False
    End Function
    Private Sub terminarParoAbierto()
        Dim sqlm As String = ""
        Dim maquina As String = ""
        sqlm = "SELECT id_maquina FROM dbo.J_orden_prod_tef WHERE (consecutivo = " & consecutivoPpal & ")"
        maquina = obj_Ing_prodLn.listar_Estado(sqlm, "PRODUCCION")
        Dim totParo As Double = 0
        For fila = 0 To dtgParo.RowCount - 1
            If (dtgParo.Item("ColHini", fila).Value <> "") Then
                If (dtgParo.Item("colHfin", fila).Value = "") Then
                    dtgParo.Item("ColHfin", fila).Value = Format(Now, "HH:mm")
                    imgTparo.Visible = False
                    totParo = DateDiff(DateInterval.Minute, horaIniParo, Now)
                    If (totParo < 0) Then
                        totParo *= -1
                    End If
                    objOrdenProdLn.guardarDetParo(consecutivoPpal, consecutivoDet, dtgParo.Item("colCod", fila).Value, dtgParo.Item("ColHini", fila).Value, dtgParo.Item("ColHfin", fila).Value, totParo)
                    dtgParo.Item("colTotal", fila).Value = totParo
                    dtgParo.Item("btnInicioFin", fila).Value = My.Resources.Candado
                    dtgParo.Item("colCod", fila).ReadOnly = True
                    dtgParo.Item("btnInicioFin", fila).ReadOnly = True
                    guardarParo(fila)
                    updateEstadoMaqAct("Activa")
                    ''maquina 1
                    If (maquina.Contains("2101")) Then
                        Dim update_estado_M As String = CInt(objOpSimplesLn.modificar_estadoM(maquina, "PRODUCCION"))
                    End If
                    ''maquina 2
                    If (maquina.Contains("2102")) Then
                        Dim update_estado_M As String = CInt(objOpSimplesLn.modificar_estadoM(maquina, "PRODUCCION"))
                    End If
                    ''maquina 3
                    If (maquina.Contains("2103")) Then
                        Dim update_estado_M As String = CInt(objOpSimplesLn.modificar_estadoM(maquina, "PRODUCCION"))
                    End If
                    ''maquina 4
                    If (maquina.Contains("2104")) Then
                        Dim update_estado_M As String = CInt(objOpSimplesLn.modificar_estadoM(maquina, "PRODUCCION"))
                    End If
                    ''maquina 5
                    If (maquina.Contains("2105")) Then
                        Dim update_estado_M As String = CInt(objOpSimplesLn.modificar_estadoM(maquina, "PRODUCCION"))
                    End If
                    ''maquina 6
                    If (maquina.Contains("2116")) Then
                        Dim update_estado_M As String = CInt(objOpSimplesLn.modificar_estadoM(maquina, "PRODUCCION"))
                    End If
                    ''maquina 7
                    If (maquina.Contains("2118")) Then
                        Dim update_estado_M As String = CInt(objOpSimplesLn.modificar_estadoM(maquina, "PRODUCCION"))
                    End If
                    ''maquina 8
                    If (maquina.Contains("2119")) Then
                        Dim update_estado_M As String = CInt(objOpSimplesLn.modificar_estadoM(maquina, "PRODUCCION"))
                    End If
                    ''maquina 9
                    If (maquina.Contains("2121")) Then
                        Dim update_estado_M As String = CInt(objOpSimplesLn.modificar_estadoM(maquina, "PRODUCCION"))
                    End If
                End If
            End If
        Next
    End Sub

    Private Sub chkClietExt_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkClietExt.CheckedChanged
        cargarAdminProd("N/A")
    End Sub

    Private Sub cargarPlanInsp()
        dtgPlanInsp.DataSource = objOrdenProdLn.cargarPlanInsp(consecutivoPpal, consecutivoDet)
        dtgPlanInsp.Columns("cod_detalle").Visible = False
        dtgPlanInsp.Columns("cod_orden").Visible = False
        dtgPlanInsp.Columns("id_hora").Visible = False
        dtgPlanInsp.Columns("hora").ReadOnly = True
    End Sub
    Private Sub cargarPlanInspCal()
        dtg_Inp_Calidad.DataSource = objOrdenProdLn.cargarPlanInspCal(consecutivoPpal, consecutivoDet)
        dtg_Inp_Calidad.Columns("cod_detalle").Visible = False
        dtg_Inp_Calidad.Columns("cod_orden").Visible = False
        dtg_Inp_Calidad.Columns("id_hora").Visible = False
        dtg_Inp_Calidad.Columns("hora").ReadOnly = True
        dtg_Inp_Calidad.AutoResizeColumns()
    End Sub
    Private Sub dtgPlanInsp_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgPlanInsp.CellValueChanged
        Dim col As String = dtgPlanInsp.Columns(e.ColumnIndex).Name
        Dim sql As String = ""
        Dim valor As String = ""
        Dim cod_orden As String = ""
        Dim cod_detalle As String = ""
        Dim id_hora As String = ""
        Dim validar As Boolean = True
        If (col <> "hora") Then
            valor = dtgPlanInsp.Item(col, e.RowIndex).Value.ToString
            If (valor <> "") Then
                If (col = "diametro" Or col = "resistencia" Or col = "peso") Then
                    If (IsNumeric(valor)) Then
                        validar = True
                    Else
                        validar = False
                        dtgPlanInsp.Item(col, e.RowIndex).Value = ""
                        MessageBox.Show("Verifique que el valor ingresado sea númerico", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If
            End If

            If (validar) Then
                cod_orden = dtgPlanInsp.Item("cod_orden", e.RowIndex).Value
                cod_detalle = dtgPlanInsp.Item("cod_detalle", e.RowIndex).Value
                id_hora = dtgPlanInsp.Item("id_hora", e.RowIndex).Value
                sql = "UPDATE J_plan_insp SET " & col & " = '" & valor & "' WHERE cod_orden = " & cod_orden & " AND cod_detalle = " & cod_detalle & " AND id_hora = " & id_hora
                objOpsimpesLn.ejecutar(sql, "PRODUCCION")
            End If
        End If
    End Sub
    Private Sub timAlertLlenarPlanInsp_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timAlertLlenarPlanInsp.Tick
        If Not (validarPlanInsp(contAlertPlanInspAl)) Then
            MessageBox.Show("Recuerde llenar la planilla de inspección de alambre, ubicada en la pestaña anterior!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        contAlertPlanInspAl += 1
        If (contAlertPlanInspAl = 4) Then
            timAlertLlenarPlanInsp.Enabled = False
        End If
    End Sub
    Private Function validarPlanInsp(ByVal fila As Integer) As Boolean
        If Not IsNothing(dtgPlanInsp.DataSource) Then
            If (dtgPlanInsp.Item("diametro", fila).Value.ToString <> "" Or dtgPlanInsp.Item("resistencia", fila).Value.ToString <> "" Or dtgPlanInsp.Item("peso", fila).Value.ToString <> "") Then
                Return True
            Else
                Return False
            End If
        Else
            Return True
        End If
    End Function
    Private Sub chk_camb_prog_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_camb_prog.CheckedChanged
        If (chk_camb_prog.Checked) Then
            graficarHileras("colDiamHilPres")
            chk_cambio1.Checked = False
            chk_cambio2.Checked = False
            chk_cambio3.Checked = False
            chk_cambio4.Checked = False
        End If

    End Sub
    Private Sub graficarHileras(ByVal columna As String)
        Dim valor As Double = 0
        Chart1.Titles.Clear()
        Chart1.Series.Clear()
        Chart1.ChartAreas.Clear()
        Chart1.ChartAreas.Add(0)
        Chart1.Series.Add("Cambio_de_hileras")
        For i = 0 To (dtgDiametros.RowCount - 1)
            If (dtgDiametros.Item(columna, i).Value.ToString <> "") Then
                valor = dtgDiametros.Item(columna, i).Value * 100
            Else
                valor = 0
            End If
            Chart1.Series("Cambio_de_hileras").Points.AddXY(i + 1, valor)
        Next
        Chart1.Series("Cambio_de_hileras").ChartType = DataVisualization.Charting.SeriesChartType.Line
        Chart1.ChartAreas(0).AxisX.Title = "Número de paso"
        Chart1.ChartAreas(0).AxisY.Title = "Porcentaje de reducción"
        Chart1.Refresh()
    End Sub

    Private Sub chk_cambio1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_cambio1.CheckedChanged
        If (chk_cambio1.Checked) Then
            graficarHileras("col_porc_c1")
            chk_camb_prog.Checked = False
            chk_cambio2.Checked = False
            chk_cambio3.Checked = False
            chk_cambio4.Checked = False
        End If

    End Sub

    Private Sub chk_cambio2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_cambio2.CheckedChanged
        If (chk_cambio2.Checked) Then
            graficarHileras("col_porc_c2")
            chk_camb_prog.Checked = False
            chk_cambio1.Checked = False
            chk_cambio3.Checked = False
            chk_cambio4.Checked = False
        End If
    End Sub

    Private Sub chk_cambio3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_cambio3.CheckedChanged
        If (chk_cambio3.Checked) Then
            graficarHileras("col_porc_c3")
            chk_camb_prog.Checked = False
            chk_cambio1.Checked = False
            chk_cambio2.Checked = False
            chk_cambio4.Checked = False
        End If
    End Sub

    Private Sub chk_cambio4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_cambio4.CheckedChanged
        If (chk_cambio4.Checked) Then
            graficarHileras("col_porc_c4")
            chk_camb_prog.Checked = False
            chk_cambio1.Checked = False
            chk_cambio2.Checked = False
            chk_cambio3.Checked = False
        End If
    End Sub
    Private Sub calc_poc_reduccion(ByVal paso As Integer, ByVal col As Integer)
        Dim diametro As Double = txtDiametro.Text
        Dim nomb_col As String = dtgDiametros.Columns(col).Name
        Dim nomb_col_porc As String = ""
        Select Case nomb_col
            Case "colCamHil1"
                nomb_col_porc = "col_porc_c1"
            Case ("colCamHil2")
                nomb_col_porc = "col_porc_c2"
            Case "colCamHil3"
                nomb_col_porc = "col_porc_c3"
            Case "colCamHil4"
                nomb_col_porc = "col_porc_c4"
        End Select
        If (dtgDiametros.Item("colPaso", paso).Value = 1) Then
            If Not IsDBNull(dtgDiametros.Item(col, paso).Value) Then
                dtgDiametros.Item(nomb_col_porc, paso).Value = ((diametro ^ 2) / (dtgDiametros.Item(col, paso).Value ^ 2)) - 1
            End If
        Else
            If Not IsDBNull(dtgDiametros.Item(col, paso - 1).Value) And Not IsDBNull(dtgDiametros.Item(col, paso).Value) Then
                If (dtgDiametros.Item(col, paso - 1).Value.ToString <> "") Then
                    dtgDiametros.Item(nomb_col_porc, paso).Value = ((dtgDiametros.Item(col, paso - 1).Value ^ 2) / (dtgDiametros.Item(col, paso).Value ^ 2)) - 1
                End If
            End If
        End If
    End Sub

    Private Sub btnOkDatos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOkDatos.Click
        If (cboAuxiliar.Text <> "Seleccione") Then
            If (cboTurno.Text <> "Seleccione") Then
                If esReproceso() Then
                    If validar_planilla_abierta() Then
                        If (crearPlanillaConsecutiva()) Then
                            iniciarTerminarPlanilla()
                            groupDatosDetPlanilla.Visible = False
                            'cargarPlanInsp()
                            cargarPlanInspCal()
                        Else
                            MessageBox.Show("Error al crear la planilla, comuniquese con el administrador del sistema y realice esta planilla manual!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    Else
                        MessageBox.Show("por favor cerrar la planilla anterior!", "Planilla anterior sin cerrar", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Else
                    If txt_link_lector_mp2.Text <> "" Then
                        Dim consecutivo As String = txt_link_lector_mp2.Text
                        Dim nit_proveedor As String = obj_gestion_alambronLn.extraerDatoCodigoBarras("proveedor", consecutivo)
                        Dim num_importacion As String = obj_gestion_alambronLn.extraerDatoCodigoBarras("num_importacion", consecutivo)
                        Dim detalle As String = obj_gestion_alambronLn.extraerDatoCodigoBarras("detalle", consecutivo)
                        Dim num_rollo As String = obj_gestion_alambronLn.extraerDatoCodigoBarras("num_rollo", consecutivo)
                        Dim sql As String = "SELECT id FROM J_alambron_importacion_det_rollos WHERE num_importacion =" & num_importacion & " AND nit_proveedor =" & nit_proveedor & "  AND id_solicitud_det =" & detalle & " AND numero_rollo =" & num_rollo
                        Dim id_rollo_mp As Double = objOpsimpesLn.consultValorTodo(sql, "PRODUCCION")
                        If validar_consumo_alambron(id_rollo_mp, num_importacion, nit_proveedor, detalle) Then
                            If validar_planilla_abierta() Then
                                If (crearPlanillaConsecutiva()) Then
                                    iniciarTerminarPlanilla()
                                    groupDatosDetPlanilla.Visible = False
                                    'cargarPlanInsp()
                                    cargarPlanInspCal()
                                    evento_cargar_rollo_mp()
                                    habilitar_lectorMp()
                                Else
                                    MessageBox.Show("Error al crear la planilla, comuniquese con el administrador del sistema y realice esta planilla manual!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                End If
                            Else
                                MessageBox.Show("Por favor cierre la planilla anterior!", "Planilla anterior no cerrada", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End If
                        Else
                            MessageBox.Show("EL rollo ha sido consumido ya dos veces o mas", "rollo consumido dos veces", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            MessageBox.Show("Leer un rollo diferente", "Leer rollo diferente", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    Else
                        MessageBox.Show("Debe ingresar un código de barras para materia prima", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If
            Else
                MessageBox.Show("Seleccione un turno para comenzar la planilla", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            MessageBox.Show("Seleccione un auxiliar para comenzar la planilla", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Private Function crearPlanillaConsecutiva() As Boolean
        Dim resp As Boolean = False
        Dim listaSql As New List(Of Object)
        If (objOrdenProdLn.planillaNoTrbajada(consecutivoPpal, consecutivoDet)) Then
            listaSql = New List(Of Object)
            listaSql.AddRange(guardarDetalle)
            resp = obj_Ing_prodLn.ExecuteSqlTransaction(listaSql, "PRODUCCION")
            If (resp) Then
                MessageBox.Show("La planilla se creo correctamente,¡BUEN TURNO! ", "Correcto!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ' cargarAdminProd(txtConsulNumOrd.Text)
            Else
                MessageBox.Show("Error al ingresar el consecutivo a la base de datos,verifique que todos los datos esten correctos ò comuniquese con el administrador del sistema!,NO SE GUARDO LA PLANILLA! ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            MessageBox.Show("Esta planilla no se puede moficicar debido a que  ya fue trabajada! ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        Return resp
    End Function

    Private Sub cboMesAdminOrden_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If (cargaComp) Then
            cargarAdminProd(txtConsulNumOrd.Text)
        End If
    End Sub

    Private Sub cboAnoAdminOrden_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If (cargaComp) Then
            cargarAdminProd(txtConsulNumOrd.Text)
        End If
    End Sub

    Private Sub txtCantProg_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCantProg.KeyPress
        soloNumero(e)
    End Sub
    Private Sub CboMaquinaConsulta_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles cboMaquinaConsulta.SelectedIndexChanged
        If (cargaComp) Then
            If (cboMaquinaConsulta.Text <> "Seleccione") Then
                cargar_cbo_vel(cboMaquinaConsulta.SelectedValue)
            End If
            cargarPlanOperario()
        End If
    End Sub

    Private Sub cboMesConsulta_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If (cargaComp) Then
            cargarPlanOperario()
        End If
    End Sub

    Private Sub cboAnoConsulta_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If (cargaComp) Then
            cargarPlanOperario()
        End If
    End Sub
    Private Sub btnCerrarGroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrarGroup.Click
        groupDatosDetPlanilla.Visible = False
    End Sub

    Private Sub FrmOrdenProdTef_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If (usuario = "operario") Then
            terminarParoAbierto()
        End If
    End Sub
    Private Sub bloquearTeclas(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.Handled = False
    End Sub
    Private Sub cboAuxiliar_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboVel.KeyPress, cboTurno.KeyPress, cboAuxiliar.KeyPress
        e.Handled = True
    End Sub

    Private Sub CerrarTurnoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CerrarTurnoToolStripMenuItem.Click
        If My.Computer.Network.Ping("10.10.10.246", 2000) Then
            Dim consulta As String = "SELECT top(1) session_id FROM sys.dm_exec_requests WHERE blocking_session_id <> 0"
            Dim bloqueo As String = objOpsimpesLn.consultValorTodo(consulta, "CORSAN")
            If bloqueo = "" Then
                If cboMaquinaFiltro.Text <> "Seleccione" Then
                    Dim obtener_val As String = "" 'validacion nueva'
                    Dim sql_val As String = "" 'validacion nueva'
                    Dim pesoreco As Double = 0 'validacion nueva'
                    Dim pesoalam As Double = 0 'validacion nueva'
                    Dim pesotot As Double = 0 'validacion nueva'
                    Dim pesobrilla As Double = 0 'validacion nueva'
                    Dim resp As Boolean = False
                    If Not txtMatPrima.Text.Contains("22B") And Not txtMatPrima.Text.Contains("22R") And Not txtMatPrima.Text.Contains("22X") Then
                        sql_val = "SELECT peso_lleva FROM J_tref_cont_mp WHERE codigoM= " & cbo_maquina.SelectedValue & " and ano=" & cboFechaIni.Value.Year & " and mes=" & cboFechaIni.Value.Month & " and cod_alambron='" & txtMatPrima.Text & "'"
                        pesotot = objOpsimpesLn.consultValorTodo(sql_val, "PRODUCCION")
                        sql_val = "SELECT sum(peso) FROM J_rollos_tref" &
                                  " where cod_orden = " & consecutivoPpal & " And id_detalle = " & consecutivoDet & " And anulado Is null And manuales Is null And no_conforme Is null"
                        obtener_val = objOpSimplesLn.consultValorTodo(sql_val, "PRODUCCION")
                        If obtener_val = "" Then
                            pesobrilla = 0
                        Else
                            pesobrilla = CDbl(obtener_val)
                        End If
                        If pesobrilla <= pesotot Then
                            resp = True
                        End If
                    Else
                        resp = True
                    End If
                    If resp Then
                        Dim sql_planilla As String
                        Dim val_planilla As String
                        sql_planilla = "select transaccion_entrada from J_det_orden_prod WHERE cod_orden=" & consecutivoPpal & " and id_detalle=" & consecutivoDet & ""
                        val_planilla = objOpsimpesLn.consultValorTodo(sql_planilla, "PRODUCCION")
                        If val_planilla = "" Then
                            cod_orden_sum = consecutivoPpal
                            id_detalle_sum = consecutivoDet
                            If (ingProdDms()) Then
                                Dim sql As String
                                cargaComp = False
                                cboOperariosTurno.SelectedValue = dtgPlanAsociadas.Item("nit", dtgPlanAsociadas.CurrentCell.RowIndex).Value
                                If cerrarTurnoDesdeCoordinador() Then
                                    sql = objOrdenProdLn.updateTransaccionesOrden(num_tran_prod, consecutivoDet, consecutivoPpal)
                                    objOpSimplesLn.ejecutar(sql, "PRODUCCION")
                                    Dim prod_f_trb As String = txtProdFinal.Text
                                    If prod_f_trb.ToUpper Like "22B100142*" Or prod_f_trb.ToUpper Like "22B100125*" Then
                                        If txtNumRollos.Text <> "0" Then
                                            trans_trb(consecutivoPpal, consecutivoDet)
                                            imprimir_Tiquete_lote_tref_8y9()
                                            cargar_rollos_reg()
                                            'restar_val8y9()
                                        End If
                                        'guardar_nrorollos_estado()
                                    End If
                                    ingProdEfic()
                                    MessageBox.Show("La planilla se cerro en forma correcta y la producción se ingreso en forma exitosa ! ", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    cargarDtgAsociado("TODOS")
                                    cargaComp = True
                                Else
                                    enviarCorreoErrorEppp(consecutivoPpal, consecutivoDet)
                                    MessageBox.Show("Error al realizar la transaccion, no realizo la transaccion y comuniquese con sistemas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                End If
                            Else
                                MessageBox.Show("Error al cerrar la planilla, comuniquese con el administrador del sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End If
                        Else
                            MessageBox.Show("No se puede registrar rollos por que la planilla ha sido cerrada", "Planilla cerrada", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    Else
                        MessageBox.Show("Esta planilla No se puede cerrar, ya que se ha producido una cantidad total mayor a la materia prima.Se debe leer mas materia prima", "Planilla no se puede cerrar", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                Else
                    MessageBox.Show("Debe seleccionar la maquina a la que pertenece la orden", "Dar doble clic primero", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                MessageBox.Show("Bloque en base de datos,No se puede cerrar planilla", "No se debe cerrar planilla", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            MessageBox.Show("No hay conexion a la base de datos", "No hay conexion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
    Private Sub txtHorometroIni_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtHorometroIni.KeyDown
        Clipboard.Clear()
    End Sub

    Private Sub txtHorometroFin_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtHorometroFin.KeyDown
        Clipboard.Clear()
    End Sub
    Private Sub cargar_cbo_vel(ByVal maquina As Integer)
        cargaComp = False
        Dim dt As New DataTable
        Dim dr As DataRow
        Dim sql = "SELECT CAST(velocidad AS varchar(25))As velocidad  FROM J_vel_tref WHERE maquina =  " & maquina
        dt = obj_Ing_prodLn.listar_datatable(sql, "PRODUCCION")
        dr = dt.NewRow
        dr("velocidad") = "Seleccione"
        dt.Rows.Add(dr)
        cboVel.DataSource = dt
        cboVel.ValueMember = "velocidad"
        cboVel.DisplayMember = "velocidad"
        cboVel.SelectedValue = "Seleccione"
        cargaComp = True
    End Sub

    Private Sub cboVel_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVel.SelectedIndexChanged
        If (cargaComp) Then
            If (cboVel.SelectedValue <> "Seleccione") Then
                Dim sql As String = "UPDATE J_det_orden_prod SET velocidad = " & cboVel.SelectedValue & " WHERE cod_orden = " & consecutivoPpal & " AND id_detalle =" & consecutivoDet
                objOpsimpesLn.ejecutar(sql, "PRODUCCION")
            End If
        End If
    End Sub

    Private Sub dtgProduccion_MouseEnter(ByVal sender As Object, ByVal e As EventArgs) Handles dtgProduccion.MouseEnter
        If (usuario = "operario") Then
            Try
                SerialPort1.Open()
                Timer1.Enabled = True
            Catch ex As Exception
                MessageBox.Show("PROBLEMAS CON EL CABLE QUE VA DEL INDICADOR AL PC,REVISE EL CABLE LUEGO APAGUE Y PRENDA EL COMPUTADOR" & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub
    Private Sub dtgProduccion_MouseLeave(ByVal sender As Object, ByVal e As EventArgs) Handles dtgProduccion.MouseLeave
        If (usuario = "operario") Then
            Try
                SerialPort1.Close()
                Timer1.Enabled = False
            Catch ex As Exception
                MessageBox.Show("PROBLEMAS CON EL CABLE QUE VA DEL INDICADOR AL PC,REVISE EL CABLE LUEGO APAGUE Y PRENDA EL COMPUTADOR" & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub


    Private Sub txt_amarres_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txt_amarres.KeyPress
        soloNumero(e)
    End Sub

    Private Sub txt_desperdicio_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txt_no_conforme.KeyPress
        soloNumero(e)
    End Sub

    Private Sub txt_lector_mp_Enter(ByVal sender As Object, ByVal e As EventArgs) Handles txt_lector_mp.Enter
        txt_lector_mp.BackColor = Color.Green
    End Sub

    Private Sub txt_lector_mp_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles txt_lector_mp.Leave
        txt_lector_mp.BackColor = Color.Red
    End Sub

    Private Sub btn_cerrar_cod_mp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_cerrar_cod_mp.Click
        group_lector_mp.Visible = False
        txt_lector_mp.Text = ""
        TblPpal.Enabled = True
    End Sub

    Private Sub btn_ok_lector_mp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_ok_lector_mp.Click
        txt_lector_mp.Text = txt_lector_mp.Text.Trim
        txt_lector_mp.Text = Replace(txt_lector_mp.Text, "'", "-")
        Dim mat_p As String = txtMatPrima.Text.Trim
        If txt_lector_mp.Text = "00000" Then
            txt_link_lector_mp2.Text = txt_lector_mp.Text
        Else
            If esReproceso() Then
                If add_rollo_mp_directo Then
                    If mat_p.ToUpper Like "22R*" Then
                        val_scal(txt_lector_mp.Text)
                    Else
                        gestionarTiqueteReproceso(txt_lector_mp.Text)
                    End If
                Else
                    If validarCodigoBarrasReproceso(txt_lector_mp.Text) Then
                        txt_link_lector_mp2.Text = txt_lector_mp.Text
                    End If
                End If
            Else
                If add_rollo_mp_directo Then
                    evento_cargar_rollo_mp()
                Else
                    If validar_codigo_barras() Then
                        txt_link_lector_mp2.Text = txt_lector_mp.Text
                    End If
                End If
            End If
        End If
        group_lector_mp.Visible = False
        TblPpal.Enabled = True
    End Sub

    Private Sub cargar_codigo_mp(ByVal id_rollo_mp As Double, ByVal num_importacion As Double, ByVal nit_proveedor As Double, ByVal detalle As Double)
        Dim list_sql As New List(Of Object)
        Dim sqlval_con As String
        Dim nroconsu As String
        Dim consumidos As Integer
        Dim cod_alambron As String = txtMatPrima.Text
        Dim sql_val As String
        Dim val_alambron As String
        sql_val = "SELECT id_mat_prima FROM J_tref_cont_mp WHERE codigoM= " & cboMaquinaConsulta.SelectedValue & " and ano=" & cbo_fec_orden.Value.Year & " and mes=" & cbo_fec_orden.Value.Month & " and cod_alambron='" & cod_alambron & "'"
        val_alambron = obj_Ing_prodLn.consultar_valor(sql_val, "PRODUCCION")
        If val_alambron = "" Or val_alambron = "0" Then
            Dim sum_lleva As Integer
            If Now.Month = 1 Then
                sql_val = "SELECT peso_lleva FROM J_tref_cont_mp WHERE codigoM= " & cboMaquinaConsulta.SelectedValue & " and ano=" & cbo_fec_orden.Value.Year - 1 & " and mes=12 and cod_alambron='" & cod_alambron & "'"
                val_alambron = obj_Ing_prodLn.consultar_valor(sql_val, "PRODUCCION")
            Else
                sql_val = "SELECT peso_lleva FROM J_tref_cont_mp WHERE codigoM= " & cboMaquinaConsulta.SelectedValue & " and ano=" & cbo_fec_orden.Value.Year & " and mes=" & cbo_fec_orden.Value.Month - 1 & " and cod_alambron='" & cod_alambron & "'"
                val_alambron = obj_Ing_prodLn.consultar_valor(sql_val, "PRODUCCION")
            End If
            sum_lleva = CInt(val_alambron)
            sql_val = "INSERT INTO J_tref_cont_mp (codigoM,peso_real,peso_lleva,ano,mes,cod_alambron) values (" & cboMaquinaConsulta.SelectedValue & "," & sum_lleva & "," & sum_lleva & "," & cbo_fec_orden.Value.Year & "," & cbo_fec_orden.Value.Month & ",'" & cod_alambron & "')"
            objOpSimplesLn.ejecutar(sql_val, "PRODUCCION")
        End If
        list_sql.Add(sql_asignar_rollo_mp_a_orden(id_rollo_mp))
        If validar_smpp_b2(id_rollo_mp) Then
            Dim num_transaccion_smpp_b2 As Double = transaccion_smpp_b2(id_rollo_mp, num_importacion, nit_proveedor, detalle)
            'Dim sql As String = "UPDATE J_alambron_importacion_det_rollos SET smpp_b2 =" & num_transaccion_smpp_b2 & " WHERE id =" & id_rollo_mp
            'list_sql.Add(sql)
        End If
        If Not objOpsimpesLn.ExecuteSqlTransactionTodo(list_sql, "PRODUCCION") Then
            MessageBox.Show("Error al asignar el rollo la orden de producción", "Error al asignar el rollo", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            sqlval_con = "select nro_consumos from J_alambron_importacion_det_rollos where id=" & id_rollo_mp & " and nit_proveedor=" & nit_proveedor & " and num_importacion=" & num_importacion & "" &
                         " and id_solicitud_det=" & detalle & ""
            nroconsu = objOpsimpesLn.consultValorTodo(sqlval_con, "PRODUCCION")
            If nroconsu = "" Then
                consumidos = 1
            Else
                consumidos = CInt(nroconsu) + 1
            End If
            sqlval_con = "update J_alambron_importacion_det_rollos set nro_consumos=" & consumidos & "where id=" & id_rollo_mp & " and nit_proveedor=" & nit_proveedor & " and num_importacion=" & num_importacion & "" &
                         " and id_solicitud_det=" & detalle & ""
            obj_Ing_prodLn.ejecutar(sqlval_con, "PRODUCCION")
            MessageBox.Show("El rollo de materia prima se agrego a la orden de producción en forma correcta", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
    'activa la carga de materia prima de la planilla
    Private Sub evento_cargar_rollo_mp()
        Dim consecutivo As String = txt_lector_mp.Text
        If (consecutivo = "00000") Then
            If (obj_Ing_prodLn.ejecutar(sql_asignar_rollo_mp_a_orden(txt_lector_mp.Text), "PRODUCCION")) Then
                MessageBox.Show("El tiquete único se asigno con exito", "correcto", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Intenete leerlo nuevamente", "Problemas con el tiquete", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            If (validar_codigo_barras()) Then
                Dim nit_proveedor As String = obj_gestion_alambronLn.extraerDatoCodigoBarras("proveedor", consecutivo)
                Dim num_importacion As String = obj_gestion_alambronLn.extraerDatoCodigoBarras("num_importacion", consecutivo)
                Dim detalle As String = obj_gestion_alambronLn.extraerDatoCodigoBarras("detalle", consecutivo)
                Dim num_rollo As String = obj_gestion_alambronLn.extraerDatoCodigoBarras("num_rollo", consecutivo)
                Dim sql As String = "SELECT id FROM J_alambron_importacion_det_rollos WHERE num_importacion =" & num_importacion & " AND nit_proveedor =" & nit_proveedor & "  AND id_solicitud_det =" & detalle & " AND numero_rollo =" & num_rollo
                Dim id_rollo_mp As Double = objOpsimpesLn.consultValorTodo(sql, "PRODUCCION")
                If validar_consumo_alambron(id_rollo_mp, num_importacion, nit_proveedor, detalle) Then
                    cargar_codigo_mp(id_rollo_mp, num_importacion, nit_proveedor, detalle)
                Else
                    MessageBox.Show("EL rollo ha sido consumido el maximo de veces posible", "Rollo ha sido consumido el maximo de veces posibles", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    MessageBox.Show("Leer un rollo diferente", "Leer rollo diferente", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
        End If
        listar_rollos_alamrbon()
    End Sub
    Private Function validar_consumo_alambron(ByVal id_rollo_mp As Double, ByVal num_importacion As Double, ByVal nit_proveedor As Double, ByVal detalle As Double) As Boolean
        Dim sqlval_con, sql_limite As String
        Dim resp As Boolean = True
        Dim consumos, limite As String
        Dim prod_f_trb As String = txtProdFinal.Text
        sql_limite = "select limite_consumos from J_alambron_importacion_det_rollos where id=" & id_rollo_mp & ""
        limite = obj_Ing_prodLn.consultar_valor(sql_limite, "PRODUCCION")
        sqlval_con = "select nro_consumos from J_alambron_importacion_det_rollos where id=" & id_rollo_mp & ""
        consumos = obj_Ing_prodLn.consultar_valor(sqlval_con, "PRODUCCION")
        If consumos > limite Then
            resp = False
        End If
        Return resp
    End Function
    Private Function validar_codigo_barras() As Boolean
        Dim respuesta As Boolean = False
        Dim consecutivo As String = txt_lector_mp.Text
        If validarCodigoBarras(consecutivo) Then
            Dim nit_proveedor As String = obj_gestion_alambronLn.extraerDatoCodigoBarras("proveedor", consecutivo)
            Dim num_importacion As String = obj_gestion_alambronLn.extraerDatoCodigoBarras("num_importacion", consecutivo)
            Dim detalle As String = obj_gestion_alambronLn.extraerDatoCodigoBarras("detalle", consecutivo)
            Dim num_rollo As String = obj_gestion_alambronLn.extraerDatoCodigoBarras("num_rollo", consecutivo)
            If validarRolloConTraslado(num_importacion, num_rollo, nit_proveedor, detalle) Then
                Dim sql As String = "SELECT codigo FROM J_alambron_solicitud_det WHERE num_importacion =" & num_importacion & " AND nit_proveedor =" & nit_proveedor & "  AND id_det =" & detalle
                Dim codigo As String = objOpsimpesLn.consultValorTodo(sql, "PRODUCCION")
                If codigo.ToUpper = txtMatPrima.Text.ToUpper Then
                    sql = "SELECT peso FROM J_alambron_importacion_det_rollos WHERE num_importacion =" & num_importacion & " AND nit_proveedor =" & nit_proveedor & "  AND id_solicitud_det =" & detalle & " AND numero_rollo =" & num_rollo
                    Dim peso As Double = objOpsimpesLn.consultValorTodo(sql, "PRODUCCION")
                    sql = "SELECT id FROM J_alambron_importacion_det_rollos WHERE num_importacion =" & num_importacion & " AND nit_proveedor =" & nit_proveedor & "  AND id_solicitud_det =" & detalle & " AND numero_rollo =" & num_rollo
                    Dim id_rollo_mp As Double = objOpsimpesLn.consultValorTodo(sql, "PRODUCCION")
                    If validar_rollo_mp_orden(id_rollo_mp) Then
                        respuesta = True
                    Else
                        MessageBox.Show("Este rollo ya fue asignado a esta orden de produccion", "Rollo ya asiganado", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Else
                    MessageBox.Show("El código de alambrón no pertenece al pedido", "Código no pertenece al pedido", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                If nit_proveedor = 999999999 Then
                    Dim resp As Integer
                    Using New Centered_MessageBox(Me)
                        resp = MessageBox.Show("Desea desactivar este tiquete único? ", "Desactivar?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                    End Using
                    If resp = 6 Then
                        Using New Centered_MessageBox(Me)
                            Dim sql_detele_rollo As String = "DELETE FROM  J_alambron_importacion_det_rollos " &
                                                                    " WHERE num_importacion =" & num_importacion & " AND numero_rollo = " & num_rollo & " AND nit_proveedor=" & nit_proveedor & " AND id_solicitud_det =" & detalle
                            If objOpsimpesLn.ejecutar(sql_detele_rollo, "PRODUCCION") > 0 Then
                                MessageBox.Show("El rollo se desactivo en forma correcta!", "Rollo desactivado", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Else
                                MessageBox.Show("Error al desactivar el rollo!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End If
                        End Using
                    End If
                Else
                    Using New Centered_MessageBox(Me)
                        MessageBox.Show("El rollo no a sido entregado a trefilación,solicitar entrega al almacén", "Rollo no entregado", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Using
                End If
            End If
        End If
        group_lector_mp.Visible = False
        Return respuesta
    End Function
    'este metodo sirve para sacar el numero de la orden de produccion que se esta trabajando,
    'para poder validar la materia prima.
    Private Function sacar_cons()
        Dim cons As String = Me.Text
        Dim orden As String = ""
        For i = 0 To cons.Length - 1
            If cons(i) = "º" Then
                For k = i To cons.Length - 1
                    If cons(k) <> " " Then
                        If IsNumeric(cons(k)) Then
                            If cons(k - 1) <> ":" Then
                                orden &= cons(k)
                            End If
                        End If
                    End If
                Next
            End If
        Next
        Return orden
    End Function
    Private Sub txt_lector_mp_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_lector_mp.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            txt_lector_mp.Text = txt_lector_mp.Text.Trim
            txt_lector_mp.Text = Replace(txt_lector_mp.Text, "'", "-")
            Dim mat_p As String = txtMatPrima.Text.Trim

            If txt_lector_mp.Text = "00000" Then
                txt_link_lector_mp2.Text = txt_lector_mp.Text
            Else
                If esReproceso() Then
                    If add_rollo_mp_directo Then
                        If mat_p.ToUpper Like "22R*" Then
                            val_scal(txt_lector_mp.Text)
                        Else
                            gestionarTiqueteReproceso(txt_lector_mp.Text)
                        End If
                    Else
                        If validarCodigoBarrasReproceso(txt_lector_mp.Text) Then
                            txt_link_lector_mp2.Text = txt_lector_mp.Text
                        End If
                    End If
                Else
                    If add_rollo_mp_directo Then
                        evento_cargar_rollo_mp()
                    Else
                        If validar_codigo_barras() Then
                            txt_link_lector_mp2.Text = txt_lector_mp.Text
                        End If
                    End If
                End If
            End If
            group_lector_mp.Visible = False
            TblPpal.Enabled = True
            '    End If
            'End If
        ElseIf (e.KeyChar = Microsoft.VisualBasic.ChrW(32)) Then
            e.Handled = False
        End If
    End Sub
    'TRANSACCION DE SCAL PARA CONSUMO DE ALAMBRE RECOCIDO, EN LAS TREFILADORAS PARA UN REPROSESO
    Private Sub val_scal(ByVal consecutivo As String)
        Dim cod_orden As String = extraerDatoCodigoBarrasReproceso("cod_orden", consecutivo)
        Dim cod_detalle As String = extraerDatoCodigoBarrasReproceso("cod_detalle", consecutivo)
        Dim num_rollo As String = extraerDatoCodigoBarrasReproceso("num_rollo", consecutivo)
        Dim mat_p As String = txtMatPrima.Text.Trim
        Dim sql As String = "SELECT s.prod_final FROM JB_rollos_rec r, JB_orden_prod_rec_refs s " &
                                " WHERE (r.id_prof_final = s.num AND r.cod_orden_rec = s.cod_orden) " &
                                    " AND r.cod_orden_rec =" & cod_orden & " AND r.id_rollo_rec = " & num_rollo & " AND r.id_detalle_rec = " & cod_detalle
        Dim val As String = objOpsimpesLn.consultValorTodo(sql, "PRODUCCION")
        If val <> "" Then
            sql = "SELECT r.tipo_trans FROM JB_rollos_rec r, JB_orden_prod_rec_refs s " &
                                " WHERE (r.id_prof_final = s.num AND r.cod_orden_rec = s.cod_orden) " &
                                    " AND r.cod_orden_rec =" & cod_orden & " AND r.id_rollo_rec = " & num_rollo & " AND r.id_detalle_rec = " & cod_detalle
            val = objOpsimpesLn.consultValorTodo(sql, "PRODUCCION")
            If val = "EPPP" Then
                sql = "SELECT r.scae FROM JB_rollos_rec r, JB_orden_prod_rec_refs s " &
                                " WHERE (r.id_prof_final = s.num AND r.cod_orden_rec = s.cod_orden) " &
                                    " AND r.cod_orden_rec =" & cod_orden & " AND r.id_rollo_rec = " & num_rollo & " AND r.id_detalle_rec = " & cod_detalle
                val = objOpsimpesLn.consultValorTodo(sql, "PRODUCCION")
                If val = "" Then
                    Dim stock As Integer = objOpSimplesLn.consultarStock(mat_p, 2)
                    sql = "SELECT r.peso FROM JB_rollos_rec r, JB_orden_prod_rec_refs s " &
                                " WHERE (r.id_prof_final = s.num AND r.cod_orden_rec = s.cod_orden) " &
                                    " AND r.cod_orden_rec =" & cod_orden & " AND r.id_rollo_rec = " & num_rollo & " AND r.id_detalle_rec = " & cod_detalle
                    Dim peso As Integer = obj_Ing_prodLn.consultar_valor(sql, "PRODUCCION")
                    If peso <= stock Then
                        trans_scal(cod_orden, cod_detalle, num_rollo)
                    Else
                        MessageBox.Show("No hay STOCK disponible.", "Problemas con el tiquete", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Else
                    MessageBox.Show("El rolloya a sido consumido.", "Problemas con el tiquete", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                MessageBox.Show("El rollo no esta disponible.", "Problemas con el tiquete", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            MessageBox.Show("Por Favor lea el Tiquete nuevamente.", "Problemas con el tiquete", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Private Sub trans_scal(ByVal cod_orden As Integer, ByVal id_detalle As Integer, ByVal id_rollo As Integer)
        Dim listSql As New List(Of Object)
        Dim listSql2 As New List(Of Object)
        Dim db_produccion As String = objOpSimplesLn.get_nom_db("PRODUCCION") & ".dbo."
        Dim sql As String = "SELECT s.prod_final AS codigo,r.peso AS cantidad FROM JB_rollos_rec r, JB_orden_prod_rec_refs s " &
                                " WHERE (r.id_prof_final = s.num AND r.cod_orden_rec = s.cod_orden) " &
                                    " AND r.cod_orden_rec =" & cod_orden & " AND r.id_rollo_rec = " & id_rollo & " AND r.id_detalle_rec = " & id_detalle
        Dim dt As DataTable = objOpsimpesLn.listar_datatable(sql, "PRODUCCION")
        listSql.AddRange(transaccion(dt, "SCAE", 2, "01", cbo_operario.SelectedValue))
        sql = "UPDATE JB_rollos_rec SET scae =" & numero_transaccion & " WHERE cod_orden_rec =" & cod_orden & " AND id_rollo_rec = " & id_rollo & " AND id_detalle_rec = " & id_detalle
        listSql2.Add(sql)
        sql = "INSERT INTO JB_orden_prod_tref_mp_rec (cod_orden,id_detalle,cod_rec,det_rec,roll_rec) VALUES (" &
                consecutivoPpal & "," & consecutivoDet & "," & cod_orden & "," & id_detalle & "," & id_rollo & ")"
        listSql2.Add(sql)
        If obj_Ing_prodLn.ExecuteSqlTransaction(listSql, "CORSAN") Then
            If obj_Ing_prodLn.ExecuteSqlTransaction(listSql2, "PRODUCCION") Then
                MessageBox.Show("El rollo se Registro correctamente.", "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                listar_rollos_alamrbon()
            Else
                enviarCorreoErrorSCAE(cod_orden, id_detalle, id_rollo, numero_transaccion)
            End If
        Else
            MessageBox.Show("Error al agregar el rollo a la orden, informarle al coordinador o auxiliar.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            enviarCorreoErrorSCAE(cod_orden, id_detalle, id_rollo, numero_transaccion)
        End If
    End Sub
    Dim numero_transaccion As Integer = 0
    Private Function transaccion(ByVal datacodigo As DataTable, ByVal tipo As String, ByVal bodega As Integer, ByVal modelo As String, ByVal op As String) As List(Of Object)
        Dim listSql As New List(Of Object)
        Dim dFec As Date = Now
        Dim usuario As String = op
        Dim notas As String = "SPIC fecha:" & Now & " usuario:" & usuario
        numero_transaccion = objOrdenProdLn.mover_consecutivo(tipo)
        listSql = objTraslado_bodLn.listaTransaccionDatable(numero_transaccion, datacodigo, bodega, dFec, notas, usuario, tipo, modelo)
        Return listSql
    End Function
    '-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    Public Function extraerDatoCodigoBarrasReproceso(ByVal dato As String, ByVal codigoBarra As String) As String
        Dim numSeparador As Integer = 0
        Dim contSeparador As Integer = 0
        Dim respuesta As String = ""
        Select Case dato
            Case "cod_orden"
                numSeparador = 0
            Case "cod_detalle"
                numSeparador = 1
            Case "num_rollo"
                numSeparador = 2
        End Select
        For i = 0 To codigoBarra.Length - 1
            If (numSeparador = contSeparador) Then
                If (codigoBarra(i) <> "-") Then
                    respuesta &= codigoBarra(i)
                End If
            End If
            If (codigoBarra(i) = "-") Then
                contSeparador += 1
            End If
        Next
        Return respuesta
    End Function
    Private Function validarCodigoBarras(ByVal consecutivo As String) As Boolean
        Dim resp As Boolean = False
        Dim nit_proveedor As String = obj_gestion_alambronLn.extraerDatoCodigoBarras("proveedor", consecutivo)
        Dim num_importacion As String = obj_gestion_alambronLn.extraerDatoCodigoBarras("num_importacion", consecutivo)
        Dim id_detalle As String = obj_gestion_alambronLn.extraerDatoCodigoBarras("detalle", consecutivo)
        Dim numero_rollo As String = obj_gestion_alambronLn.extraerDatoCodigoBarras("num_rollo", consecutivo)
        If num_importacion <> "" And numero_rollo <> "" And id_detalle <> "" And nit_proveedor <> "" Then
            Dim sql As String = "SELECT id FROM J_alambron_importacion_det_rollos WHERE num_importacion =" & num_importacion & " AND numero_rollo = " & numero_rollo & " AND nit_proveedor = " & nit_proveedor & " AND id_solicitud_det = " & id_detalle
            Dim id As String = objOpsimpesLn.consultValorTodo(sql, "PRODUCCION")
            If id <> "" Then
                resp = True
            End If
        End If
        If resp = False Then
            Using New Centered_MessageBox(Me)
                MessageBox.Show("Intenete leerlo nuevamente", "Problemas con el tiquete", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Using
        End If
        Return resp
    End Function
    Private Function validarCodigoBarrasReproceso(ByVal consecutivo As String) As Boolean
        Dim resp As Boolean = False
        Dim mat_p As String = txtMatPrima.Text.Trim
        Dim cod_orden As String = extraerDatoCodigoBarrasReproceso("cod_orden", consecutivo)
        Dim cod_detalle As String = extraerDatoCodigoBarrasReproceso("cod_detalle", consecutivo)
        Dim num_rollo As String = extraerDatoCodigoBarrasReproceso("num_rollo", consecutivo)
        If cod_orden <> "" And cod_detalle <> "" And num_rollo <> "" Then
            Dim sql As String = ""
            sql = "SELECT id_rollo FROM J_rollos_tref WHERE cod_orden =" & cod_orden & " AND id_rollo = " & num_rollo & " AND id_detalle = " & cod_detalle
            Dim id_rollo As String = objOpsimpesLn.consultValorTodo(sql, "PRODUCCION")
            If id_rollo <> "" Then
                resp = True
            End If
        End If
        If resp = False Then
            Using New Centered_MessageBox(Me)
                MessageBox.Show("Intenete leerlo nuevamente", "Problemas con el tiquete", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Using
        End If
        Return resp
    End Function
    Private Sub gestionarTiqueteReproceso(ByVal consecutivo As String)
        Dim resp As Boolean = False

        Dim cod_orden As String = extraerDatoCodigoBarrasReproceso("cod_orden", consecutivo)
        Dim cod_detalle As String = extraerDatoCodigoBarrasReproceso("cod_detalle", consecutivo)
        Dim num_rollo As String = extraerDatoCodigoBarrasReproceso("num_rollo", consecutivo)
        If cod_orden <> "" And cod_detalle <> "" And num_rollo <> "" Then
            Dim sql As String = ""
            sql = "SELECT consecutivo FROM J_rollos_tref WHERE cod_orden =" & cod_orden & " AND id_rollo = " & num_rollo & " AND id_detalle = " & cod_detalle
            Dim consecutivo_rollo As String = objOpsimpesLn.consultValorTodo(sql, "PRODUCCION")
            If consecutivo_rollo <> "" Then
                Dim sql_codigo As String = ""
                sql_codigo = "select prod_final from J_orden_prod_tef where consecutivo = " & cod_orden
                Dim codigo As String = objOpsimpesLn.consultValorTodo(sql_codigo, "PRODUCCION")
                If codigo.ToUpper = txtMatPrima.Text.ToUpper Then
                    If validar_rollo_mp_orden(consecutivo_rollo) Then
                        If (obj_Ing_prodLn.ejecutar(sql_asignar_rollo_mp_a_orden(consecutivo_rollo), "PRODUCCION")) Then
                            resp = True
                            MessageBox.Show("El rollo de reproceso se asigno en forma correcta", "correcto", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Else
                            MessageBox.Show("Intenete leerlo nuevamente", "Problemas con el tiquete", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    Else
                        MessageBox.Show("Este rollo ya fue asignado a esta orden de produccion", "Rollo ya asiganado", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Else
                    MessageBox.Show("El código de alambrón no pertenece al pedido", "Código no pertenece al pedido", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        End If
        If resp = False Then
            Using New Centered_MessageBox(Me)
                MessageBox.Show("Intenete leerlo nuevamente", "Problemas con el tiquete", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Using
        Else
            listar_rollos_alamrbon()
        End If
    End Sub

    Private Function validarRolloConTraslado(ByVal num_importacion As Double, ByVal num_rollo As Double, ByVal nit_proveedor As Double, ByVal id_detalle As Integer) As Boolean
        Dim resp As Boolean = False
        Dim sql As String = "SELECT num_importacion FROM J_alambron_importacion_det_rollos " &
                                    " WHERE num_transaccion_salida IS NOT NULL AND num_importacion =" & num_importacion & " AND numero_rollo = " & num_rollo & " AND nit_proveedor=" & nit_proveedor & " AND id_solicitud_det =" & id_detalle
        Dim id As String = objOpsimpesLn.consultValorTodo(sql, "PRODUCCION")
        If id <> "" Then
            resp = True
        End If
        Return resp
    End Function

    Private Sub txt_link_lector_mp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles txt_link_lector_mp.Click
        'If txtMatPrima.Text.Contains("22B") Then
        '    Dim formu As New Frm_lec_brillante
        '    formu.main(consecutivoPpal, consecutivoDet, nit_usuario, "i")
        '    formu.ShowDialog()
        'Else
        If Not txtMatPrima.Text.Contains("22B") And Not txtMatPrima.Text.Contains("22R") And Not txtMatPrima.Text.Contains("22X") Then
            group_lector_mp.Visible = True
            txt_lector_mp.Text = ""
            groupDatosDetPlanilla.Visible = False
            txt_lector_mp.Focus()
            add_rollo_mp_directo = True
            TblPpal.Enabled = False
        End If
        'End If
    End Sub
    Private Sub txt_link_lector_mp2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles txt_link_lector_mp2.Click
        group_lector_mp.Visible = True
        txt_lector_mp.Text = ""
        ' groupDatosDetPlanilla.Visible = False
        txt_lector_mp.Focus()
        add_rollo_mp_directo = False
        TblPpal.Enabled = False
    End Sub
    Private Function validar_rollo_mp_orden(ByVal id_rollo_mp As Double) As Boolean
        Dim sql As String = "SELECT id_rollo_mp FROM J_orden_prod_rollo_mp WHERE cod_orden =" & consecutivoPpal & " AND id_detalle=" & consecutivoDet & " AND id_rollo_mp=" & id_rollo_mp & " "
        If objOpsimpesLn.consultValorTodo(sql, "PRODUCCION") <> "" Then
            Return False
        Else
            Return True
        End If
    End Function
    Private Function sql_asignar_rollo_mp_a_orden(ByVal id_rollo_mp As Double) As String
        Dim sql As String = "INSERT INTO J_orden_prod_rollo_mp  (cod_orden,id_detalle,id_rollo_mp) VALUES (" & consecutivoPpal & "," & consecutivoDet & "," & id_rollo_mp & ") "
        Return sql
    End Function
    Private Function validar_smpp_b2(ByVal id_rollo_mp As Double) As Boolean
        Dim sql As String = "SELECT id FROM J_alambron_importacion_det_rollos WHERE id =" & id_rollo_mp & " AND smpp_b2 IS NOT NULL "
        If objOpsimpesLn.consultValorTodo(sql, "PRODUCCION") <> "" Then
            Return False
        Else
            Return True
        End If
    End Function
    Private Function transaccion_smpp_b2(ByVal id_rollo_mp As Double, ByVal num_importacion As Double, ByVal nit_proveedor As Double, ByVal detalle As Double) As Double
        Dim listSql As New List(Of Object)
        Dim dFec As Date = Now
        Dim notas As String = "SPIC  " & cbo_maquina.Text & " fecha:" & Now & " orden:" & consecutivoPpal & "-" & consecutivoDet
        Dim bod_tran_alambron As Double = 2
        Dim tipo_transaccion_alambron As String = "SMPP"
        Dim num_transaccion As Double = 0
        Dim sql_codigo_rollo_mp As String = "SELECT codigo FROM J_alambron_solicitud_det WHERE num_importacion =" & num_importacion & " AND nit_proveedor =" & nit_proveedor & "  AND id_det =" & detalle
        Dim sql_val As String
        Dim cod_alambron As String = txtMatPrima.Text
        Dim bodega_alambron As Double = 2
        Dim stock_alambron_b2 As Double = objOpsimpesLn.consultarStock(cod_alambron, bodega_alambron)
        Dim sql_valor_promedio As String = "SELECT Promedio  from v_referencias_cos  where codigo = '" & cod_alambron & "' and mes= " & Month(Now.Date) & " and ano = " & Year(Now.Date) & ""
        Dim valor_promedio As Double = objOpsimpesLn.consultarVal(sql_valor_promedio)
        Dim sql_kilos_rollo_mp As String = "SELECT peso FROM J_alambron_importacion_det_rollos WHERE id =" & id_rollo_mp
        Dim peso As Double = objOpsimpesLn.consultValorTodo(sql_kilos_rollo_mp, "PRODUCCION")
        If peso > stock_alambron_b2 Then
            num_transaccion = 1
            enviarCorreoSmppSinStock(consecutivoPpal, consecutivoDet, peso)
        End If
        Dim db_produccion As String = objOpSimplesLn.get_nom_db("PRODUCCION") & ".dbo."
        Dim sql As String = "UPDATE " & db_produccion & "J_alambron_importacion_det_rollos SET smpp_b2 =1,fecha_consumo=GETDATE() WHERE id =" & id_rollo_mp
        listSql.Add(sql)
        sql_val = "UPDATE J_tref_cont_mp SET peso_real+=" & peso & ",peso_lleva+= " & peso & " WHERE codigoM= " & cboMaquinaConsulta.SelectedValue & " and ano=" & cbo_fec_orden.Value.Year & " and mes=" & cbo_fec_orden.Value.Month & " and cod_alambron='" & cod_alambron & "'"
        objOpSimplesLn.ejecutar(sql_val, "PRODUCCION")
        actualizar_mp()
        If Not objOpsimpesLn.ExecuteSqlTransactionTodo(listSql, "CORSAN") Then
            enviarCorreoErrorSPPP(num_transaccion, id_rollo_mp, consecutivoPpal, consecutivoDet)
            MessageBox.Show("Error al realizar la tansaccion de materia prima (SMPP)", "No se realizo la SMPP de materia prima", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        Return num_transaccion
    End Function

    Private Sub enviarCorreoErrorSPPP(ByVal num_trans As String, ByVal id_rollo As String, ByVal cod_orden As String, ByVal id_detalle As String)
        Dim sql As String = "SELECT mail,Mail_login  FROM Jjv_usuarios WHERE usuario = 'ADMIN'"
        Dim dt_admin As DataTable = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        Dim mail As String = "david.hincapie@corsan.com.co"
        Dim asunto As String = "Error en el consumo de alambron"
        sql = "select (convert(varchar,nit_proveedor) + '-' + convert(varchar,num_importacion) + '-' + convert(varchar,id_solicitud_det) + '-' + CONVERT(varchar,numero_rollo)) " &
                " AS consecutivo from J_alambron_importacion_det_rollos where id = " & id_rollo
        Dim consecutivo As String = objOpsimpesLn.consultValorTodo(sql, "PRODUCCION")
        Dim cuerpo As String = "ERROR AL HACER EL CONSUMO DE ALAMBRON" & vbCrLf &
                                "-Orden numero:" & cod_orden & vbCrLf &
                                "-N° de planilla: " & id_detalle & vbCrLf &
                                "Numero de Transaccion (SMPP): " & num_trans & vbCrLf &
                                "Consecutivo Rollo: " & consecutivo & vbCrLf &
                                "Maquina:" & cbo_maquina.Text & vbCrLf &
                                "Fecha: " & Now
        Dim mailEnvia As String = dt_admin.Rows(0).Item("mail")
        Dim mailEnviaPass As String = dt_admin.Rows(0).Item("Mail_login")
        obj_correoLn.EnviarCorreo(mail.Trim, cuerpo, asunto, "", mailEnvia, mailEnviaPass, False)
        mail = "isabel.gomez@corsan.com.co"
        obj_correoLn.EnviarCorreo(mail.Trim, cuerpo, asunto, "", mailEnvia, mailEnviaPass, False)
        mail = "contabilidad@corsan.com.co"
        obj_correoLn.EnviarCorreo(mail.Trim, cuerpo, asunto, "", mailEnvia, mailEnviaPass, False)
    End Sub

    Private Sub enviarCorreoParo(ByVal cod_orden As String, ByVal id_detalle As String, ByVal id_paro As Integer)
        Dim sql As String = "SELECT mail,Mail_login  FROM Jjv_usuarios WHERE usuario = 'ADMIN'"
        Dim dt_admin As DataTable = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        Dim mail As String = "hugo.zapata@corsan.com.co"
        Dim asunto As String = "Suceso en trefiladora"

        Dim cuerpo As String

        Dim daño As String
        If id_paro = 6 Then
            daño = " Daño electrico"
        ElseIf id_paro = 7 Then
            daño = " Daño mecanico"
        Else
            daño = " Mantenimiento programado"
        End If

        cuerpo = "Situación en una trefiladora" & vbCrLf &
                                "-Orden numero:" & cod_orden & vbCrLf &
                                "-N° de planilla: " & id_detalle & vbCrLf &
                                "SUCESO: " & daño & vbCrLf &
                                "MAQUINA:" & cbo_maquina.Text & vbCrLf &
                                "Fecha: " & Now

        Dim mailEnvia As String = dt_admin.Rows(0).Item("mail")
        Dim mailEnviaPass As String = dt_admin.Rows(0).Item("Mail_login")
        obj_correoLn.EnviarCorreo(mail.Trim, cuerpo, asunto, "", mailEnvia, mailEnviaPass, False)
        mail = "calidad@corsan.com.co"
        obj_correoLn.EnviarCorreo(mail.Trim, cuerpo, asunto, "", mailEnvia, mailEnviaPass, False)
    End Sub

    Private Sub listar_rollos_alamrbon()
        Dim sql As String = ""
        If esReproceso() Then
            sql = "SELECT CAST (d.cod_orden  as varchar) + '-' + CAST (d.id_detalle  as varchar) + '-' + CAST (d.id_rollo  as varchar) As rollo_reproceso " &
                   "FROM J_rollos_tref  d , J_orden_prod_rollo_mp o " &
                       "WHERE o.id_rollo_mp = d.consecutivo And o.cod_orden = " & consecutivoPpal & " And o.id_detalle = " & consecutivoDet & " " &
                           "ORDER BY d.id_rollo "
        Else
            sql = "SELECT CAST (d.nit_proveedor as varchar) + '-' + CAST (d.num_importacion as varchar) + '-' + CAST (d.id_solicitud_det as varchar) + '-' + CAST (d.numero_rollo as varchar) As rollo_alambron " &
                             "FROM J_alambron_importacion_det_rollos d , J_orden_prod_rollo_mp o " &
                               " WHERE o.id_rollo_mp = d.id AND o.cod_orden = " & consecutivoPpal & " AND o.id_detalle=" & consecutivoDet & " " &
                                     "ORDER BY d.id "
        End If
        dtg_rollos_alamrbon.DataSource = objOpsimpesLn.listar_datatable(sql, "PRODUCCION")
        If esReproceso() Then
            If txtMatPrima.Text.Contains("22B") Then
                sql = "SELECT (convert(varchar,cod_bri)+'-'+convert(varchar, id_bri)+'-'+convert(varchar, rollo_bri)) as consecutivo " &
                      " FROM JB_orden_prod_tref_mp_bri WHERE cod_orden = " & consecutivoPpal & " AND id_detalle = " & consecutivoDet
                dtg_mp_rec.DataSource = objOpsimpesLn.listar_datatable(sql, "PRODUCCION")
                GroupBox11.Text = "Rollos de brillante"
            Else

                sql = "SELECT (convert(varchar,cod_rec)+'-'+convert(varchar, det_rec)+'-'+convert(varchar, roll_rec)) as consecutivo " &
                        " FROM JB_orden_prod_tref_mp_rec WHERE cod_orden = " & consecutivoPpal & " AND id_detalle = " & consecutivoDet
                dtg_mp_rec.DataSource = objOpsimpesLn.listar_datatable(sql, "PRODUCCION")
                GroupBox11.Text = "Rollos de recocido"
            End If

        End If
    End Sub
    Private Sub seleccion_Planilla_Ingreso()
        Dim codigo_Trab As String = txtProdFinal.Text
        If codigo_Trab.ToUpper = "22B100142" Then
            img_ing_plan.Image = Spic.My.Resources.Resources.Ingresar_planilla_calidad_actualizacion
        Else
            img_ing_plan.Visible = False
        End If
    End Sub
    Private Sub habilitar_lectorMp()
        Dim mat_p As String = txtMatPrima.Text.Trim
        If esReproceso() Then
            If mat_p.ToUpper Like "22R*" Then
                txt_link_lector_mp.Enabled = True
                txt_link_lector_mp2.Enabled = False
            Else
                txt_link_lector_mp.Enabled = True
                txt_link_lector_mp2.Enabled = False
            End If
        Else
            If estadoTurno = True Then
                txt_link_lector_mp.Enabled = True
            Else
                txt_link_lector_mp.Enabled = False
            End If
            txt_link_lector_mp2.Enabled = True
        End If
    End Sub

    Private Sub chk_todo_op_turno_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chk_todo_op_turno.CheckedChanged
        If (chk_todo_op_turno.Checked) Then
            cargarTodosOperarios(cboOperariosTurno, True)
        Else
            cargarTodosOperarios(cboOperariosTurno, False)
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        Group_defecto.Visible = False
        TblPpal.Enabled = True
    End Sub
    'Ingresa la chatarra al sistema
    Private Sub ingreso_Defectos()
        If IsNumeric(txt_amarres.Text) Then
            If txt_no_conforme.Text > 0 Then
                Dim kilos As Double = txt_no_conforme.Text
                Dim listSql As New List(Of Object)
                Dim listSqlChat As New List(Of Object)
                Dim tipo As Integer = 0
                Dim causal As Integer = 0
                Dim defecto As Integer = 0
                Dim sql_oper As String = "select operario from j_det_orden_prod where cod_orden=" & consecutivoPpal & " and id_detalle=" & consecutivoDet & ""
                Dim operario As String = objOpsimpesLn.consultValorTodo(sql_oper, "PRODUCCION")
                Dim fecha As String = ""
                Dim row As DataRow
                If (Now.Hour >= 0 And Now.Hour <= 5) Then
                    fecha = objOpsimpesLn.cambiarFormatoFecha((Now.AddDays(-1)).Date)
                Else
                    fecha = objOpsimpesLn.cambiarFormatoFecha(Now.Date)
                End If
                tipo = 8
                causal = 1
                defecto = cbo_defecto.SelectedValue
                dt = seleccionar_chatarra()
                If dt.Rows.Count > 0 Then
                    For Each row In dt.Rows
                        objOpsimpesLn.ExecuteSqlTransactionTodo(sql_ing_desperdicios(fecha, operario, row.Item("kilos"), tipo, causal, row.Item("id_defecto")), "PRODUCCION")
                    Next
                End If
            Else
                'MessageBox.Show("Ingrese los kilos de material no conforme", "Ingrese kilos", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

        Else
            'MessageBox.Show("Ingrese los kilos de material no conforme", "Ingrese kilos", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

    End Sub
    Private Function seleccionar_chatarra()
        Dim num_orden As String
        Dim id_Detalle As String
        Dim sql As String
        Dim dt As DataTable
        num_orden = consecutivoPpal
        id_Detalle = consecutivoDet
        sql = "select id_defecto,kilos from J_control_chatarra_tref where id_orden=" & num_orden & " and id_det=" & id_Detalle & ""
        dt = objOpsimpesLn.listar_datatable(sql, "PRODUCCION")
        Return dt
    End Function
    Private Sub txt_no_conforme_Click(ByVal sender As Object, ByVal e As EventArgs) Handles txt_no_conforme.Click
        Dim sql As String
        Dim frm As New frm_chatarra_tref
        Dim peso_chat As String
        frm.main(consecutivoPpal, consecutivoDet, "OPERARIOS")
        frm.ShowDialog()
        sql = "select sum(kilos) as kilos from J_control_chatarra_tref where id_orden=" & consecutivoPpal & " and id_det=" & consecutivoDet & ""
        peso_chat = objOpsimpesLn.consultValorTodo(sql, "PRODUCCION")
        If peso_chat = "" Then
            peso_chat = "0"
        End If
        txt_no_conforme.Text = peso_chat
        'TblPpal.Enabled = False
        'Group_defecto.Visible = True
    End Sub
    Private Sub txt_kilos_causal_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txt_kilos_causal.KeyPress
        soloNumero(e)
    End Sub

    Private Sub dtgProduccion_CellValueChanged(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dtgProduccion.CellValueChanged
        If cargaComp And (usuario = "operario") Then
            If dtgProduccion.Columns(e.ColumnIndex).Name = colTraccion.Name Then
                If IsNumeric(dtgProduccion.Item(e.ColumnIndex, e.RowIndex).Value) Then
                    Dim valor As Double = dtgProduccion.Item(e.ColumnIndex, e.RowIndex).Value
                    If valor < txtTracMin.Text Or valor > txtTracMax.Text Then
                        cargaComp = False
                        MessageBox.Show("La tracción ingresada debe estar entre " & txtTracMin.Text.Trim & " Y " & txtTracMax.Text.Trim & ",El rollo no sera registrado", "La tracción esta fuera del rango de la ficha técnica", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        dtgProduccion.Item(e.ColumnIndex, e.RowIndex).Value = ""
                        cargaComp = True
                    End If
                Else
                    cargaComp = False
                    MessageBox.Show("El valor ingresado debe ser númerico", "Ingrese un valor númerico", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    dtgProduccion.Item(e.ColumnIndex, e.RowIndex).Value = ""
                    cargaComp = True
                End If
            End If
        End If
    End Sub
    Private Sub dtgProduccion_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dtgProduccion.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            With (Me.dtgProduccion)
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                End If
            End With
        End If
    End Sub

    Private Sub tool_copia_Click(ByVal sender As Object, ByVal e As EventArgs) Handles tool_copia.Click
        If IsNumeric(dtgProduccion.Item(colKg.Name, dtgProduccion.CurrentCell.RowIndex).Value) Then
            Dim peso As Double = dtgProduccion.Item(colKg.Name, dtgProduccion.CurrentCell.RowIndex).Value
            Dim rolloNum As Double = dtgProduccion.Item(colRollo.Name, dtgProduccion.CurrentCell.RowIndex).Value
            Dim calibre As Double = dtgProduccion.Item(colCalibre.Name, dtgProduccion.CurrentCell.RowIndex).Value
            Dim colada As String = dtgProduccion.Item("colColada", dtgProduccion.CurrentCell.RowIndex).Value
            Dim traccion As String = dtgProduccion.Item("colTraccion", dtgProduccion.CurrentCell.RowIndex).Value
            Dim calidad As Integer = cboCalidad.SelectedValue
            Dim producto As String = txtProdFinal.Text
            Dim nombOperario As String = cbo_operario.Text
            Dim Fecha As String = objOpsimpesLn.cambiarFormatoFecha(Now.Date)
            Dim destinoDesc As String = cboCliente.Text
            Dim cod_mat_prima As String = txtMatPrima.Text
            imprimirTiquete(peso, rolloNum, calibre, calidad, nombOperario, Fecha, producto, destinoDesc, colada, cod_mat_prima, traccion)
        Else
            MessageBox.Show("Columna no valida", "Columna invalida", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
    Private Sub tool_gen_tiq_Click(ByVal sender As Object, ByVal e As EventArgs) Handles tool_gen_tiq.Click
        group_rollo_manual.Visible = False
        Dim sql As String
        Dim nombre_opera As String
        Dim nit As String
        sql = "select ter.nombres from J_det_orden_prod prod,CORSAN.dbo.V_nom_personal_Activo_con_maquila ter where ter.nit = prod.operario and prod.cod_orden=" & consecutivoPpal & " and prod.id_detalle=" & consecutivoDet & ""
        nombre_opera = obj_Ing_prodLn.consultar_valor(sql, "PRODUCCION")
        sql = "select ter.nit from J_det_orden_prod prod,CORSAN.dbo.V_nom_personal_Activo_con_maquila ter where ter.nit = prod.operario and prod.cod_orden=" & consecutivoPpal & " and prod.id_detalle=" & consecutivoDet & ""
        nit = obj_Ing_prodLn.consultar_valor(sql, "PRODUCCION")
        Dim formu As New frm_generar_tiquete
        formu.main(consecutivoPpal, consecutivoDet, nombre_opera, nit)
        formu.Show()
    End Sub
    Private Sub btn_cerrar_manual_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_cerrar_manual.Click
        group_rollo_manual.Visible = False
    End Sub
    Private Sub btn_ok_manual_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_ok_manual.Click
        If IsNumeric(txt_peso_manual.Text) Then
            If IsNumeric(txt_traccion_manual.Text) Then
                If IsNumeric(txt_cal_manual.Text) Then
                    If (txt_col_manual.Text <> "") Then
                        ingresar_rollo_manual()
                    Else
                        MessageBox.Show("Ingrese colada valida", "colada invalida", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        txt_col_manual.Text = ""
                    End If
                Else
                    MessageBox.Show("Ingrese calibre valido", "calibre invalido", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txt_cal_manual.Text = ""
                End If
            Else
                MessageBox.Show("Ingrese tracción valida", "tracción invalida", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txt_traccion_manual.Text = ""
            End If
        Else
            MessageBox.Show("Ingrese peso valido", "peso invalido", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txt_peso_manual.Text = ""
        End If
    End Sub
    Private Sub limpiar_rollo_manual()
        txt_peso_manual.Text = ""
        txt_traccion_manual.Text = ""
        txt_cal_manual.Text = ""
        txt_col_manual.Text = ""
    End Sub
    Private Sub ingresar_rollo_manual()
        Dim fila As Integer = dtgProduccion.Rows.Count - 1
        Dim peso As Double = txt_peso_manual.Text
        Dim traccion As Double = txt_traccion_manual.Text
        Dim calibre As Double = txt_cal_manual.Text
        Dim colada As String = txt_col_manual.Text
        If IsNumeric(dtgProduccion.Item(colKg.Name, fila).Value) Then
            dtgProduccion.Rows.Add()
            fila = dtgProduccion.Rows.Count - 1
        End If
        If fila > 0 Then
            If IsNumeric(dtgProduccion.Item("colRollo", fila - 1).Value) Then
                dtgProduccion.Item("colRollo", fila).Value += 1
            End If
        Else
            dtgProduccion.Item("colRollo", fila).Value = 1
        End If
        dtgProduccion.Item(colKg.Name, fila).Value = peso
        dtgProduccion.Item(colColada.Name, fila).Value = colada
        dtgProduccion.Item(colOrdenPDN.Name, fila).Value = ""
        dtgProduccion.Item(colNroRolloF.Name, fila).Value = ""
        dtgProduccion.Item(colTraccion.Name, fila).Value = traccion
        dtgProduccion.Item(colCalibre.Name, fila).Value = traccion
        dtgProduccion.Item(colTraccion.Name, fila).Value = traccion
        dtgProduccion.Item(col_notas_audit.Name, fila).Value = "impresion manual"
        eventro_imprimir(fila, peso)
        group_rollo_manual.Visible = False
    End Sub
    Private Sub txt_peso_manual_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txt_peso_manual.KeyPress
        soloNumero(e)
    End Sub
    Private Sub txt_cal_manual_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txt_cal_manual.KeyPress
        soloNumero(e)
    End Sub

    Private Sub txt_traccion_manual_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txt_traccion_manual.KeyPress
        soloNumero(e)
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cerrar_ficha.Click
        Group_ficha_tecnica.Visible = False
        TblPpal.Enabled = True

    End Sub
    Private Sub btn_ficha_tcnica_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ficha_tcnica.Click
        If (txtProdFinal.Text <> "") Then
            cargarConsulta()
        Else
            MessageBox.Show("Para cargar la ficha tecnica se debe ingresar el producto final", "Producto final", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
    Private Sub cargarConsulta()
        Dim sql As String = "SELECT t.nombres,j.codigo,j.resistencia,j.diametro,j.procedencia,j.calidad,j.recubrimiento" &
                                        " FROM J_referencia_ficha_tec j INNER JOIN CORSAN.dbo.terceros t ON j.nit = t.nit " &
                                            "WHERE j.codigo = '" & txtProdFinal.Text & "'"
        dt = objOpsimpesLn.crearDataTableVariasCol(sql, "PRODUCCION")
        If dt.Rows.Count > 0 Then
            Group_ficha_tecnica.Visible = True
            dtgFichas.DataSource = dt
        End If
    End Sub

    Private Sub cargarCliente()
        Dim sql As String = "SELECT nit,numero,nombres,codigo,descripcion ,Cant_pedida,Pendiente " &
                                    "FROM J_v_pendientes_por_vendedor_id_cor " &
                                    "WHERE (codigo like '33X%' OR  codigo like '33B%')"
        GroupClientes.Visible = True
        dt = objOpsimpesLn.crearDataTableVariasCol(sql, "CORSAN")
        dgt_cliente.DataSource = dt
    End Sub

    Private Sub dtgFichas_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgFichas.CellContentClick
        Dim obj_gestion_materia_primaLn As New Gestion_materia_primaLn
        Dim fila As Integer = e.RowIndex
        Dim col As String = dtgFichas.Columns(e.ColumnIndex).Name
        If (fila >= 0) Then
            If (col = "btnSeleccion") Then
                txtTracMin.Text = obj_gestion_materia_primaLn.extraerMinMax("min", dtgFichas.Item("resistencia", fila).Value)
                txtTracMax.Text = obj_gestion_materia_primaLn.extraerMinMax("max", dtgFichas.Item("resistencia", fila).Value)
                txtDiaMin.Text = obj_gestion_materia_primaLn.extraerMinMax("min", dtgFichas.Item("diametro", fila).Value)
                txtDiamMAx.Text = obj_gestion_materia_primaLn.extraerMinMax("max", dtgFichas.Item("diametro", fila).Value)
                Group_ficha_tecnica.Visible = False
            End If
        End If

    End Sub

    Private Sub btn_cliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cliente.Click
        cargarCliente()
        txtTracMax.Text = ""
        txtTracMin.Text = ""
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cerrar_clientes.Click
        GroupClientes.Visible = False
        TblPpal.Enabled = True
    End Sub

    Private Sub dgt_cliente_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgt_cliente.CellContentClick
        Dim fila As Integer = e.RowIndex
        Dim col As String = dgt_cliente.Columns(e.ColumnIndex).Name
        If (fila >= 0) Then
            If (col = "brnSelectCli") Then
                cboCliente.SelectedValue = dgt_cliente.Item("nit", fila).Value
                txtProdFinal.Text = dgt_cliente.Item("codigo", fila).Value
                num_pedido = dgt_cliente.Item("numero", fila).Value
                GroupClientes.Visible = False
            End If
        End If
    End Sub

    Private Sub filtro(ByVal nit As String, ByVal nombre As String)
        Dim where_sql As String = ""
        If (nit <> "") Then
            where_sql &= " nit like '%" & nit & "%' "
        ElseIf (nombre <> "") Then
            where_sql &= " nombres like '%" & nombre & "%'"
        End If
        Dim sql As String = "SELECT numero,nit,nombres,codigo,descripcion ,Cant_pedida,Pendiente " &
                                    "FROM J_v_pendientes_por_vendedor_id_cor " &
                                    "WHERE " & where_sql & " AND (codigo like '33X%' OR  codigo like '33B%')"
        dgt_cliente.DataSource = objOpsimpesLn.listar_datatable(sql, "CORSAN")
    End Sub
    Private Sub evitar_Ordenar()
        Dim i As Integer

        For i = 0 To dtgOperario.Columns.Count - 1

            dtgOperario.Columns.Item(i).SortMode = DataGridViewColumnSortMode.Programmatic

        Next i
    End Sub
    Private Sub txtnitB_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtnitB.TextChanged
        If (txtnitB.Text.Length > 2) Then
            filtro(txtnitB.Text, "")
        End If
    End Sub

    Private Sub txtClienteB_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtClienteB.TextChanged
        If (txtClienteB.Text.Length > 2) Then
            filtro("", txtClienteB.Text)
        End If
    End Sub

    Private Sub chkocultos_CheckedChanged(sender As Object, e As EventArgs) Handles chkocultos.CheckedChanged
        cargarAdminProd(txtConsulNumOrd.Text)
    End Sub
    Private Sub btnexcel_Click1(sender As Object, e As EventArgs)
        If dtg_consulta.RowCount > 0 Then
            dtg_consulta.Columns("col_oculto").Visible = False
            dtg_consulta.Columns("btnVerDetalle").Visible = False
            dtg_consulta.Columns("planillas_abiertas").Visible = False
            dtg_consulta.Columns("maquina").Visible = False
            dtg_consulta.Columns("mes").Visible = False
            dtg_consulta.Columns("año").Visible = False
            dtg_consulta.Columns("calidad").Visible = False
            dtg_consulta.Columns("diametro").Visible = False
            dtg_consulta.Columns("numPasos").Visible = False
            dtg_consulta.Columns("col_duplicar").Visible = False
            dtg_consulta.Columns("fecha_creacion").Visible = False
            dtg_consulta.Columns("fecha_terminacion").Visible = False
            dtg_consulta.Columns("notas_liquidacion").Visible = False
            dtg_consulta.Columns("costo_estandar_prog").Visible = False
            dtg_consulta.Columns("costo_estandar_prod").Visible = False
            dtg_consulta.Columns("costo_variacion").Visible = False
            dtg_consulta.Columns("vel_esp").Visible = False
            dtg_consulta.Columns("col_porcen").Visible = False
            objOperacionesForm.ExportarDatosExcel(dtg_consulta, "Ordenes de producción trefilación")
            dtg_consulta.Columns("col_oculto").Visible = True
            dtg_consulta.Columns("btnVerDetalle").Visible = True
            dtg_consulta.Columns("planillas_abiertas").Visible = True
            dtg_consulta.Columns("maquina").Visible = True
            dtg_consulta.Columns("mes").Visible = True
            dtg_consulta.Columns("año").Visible = True
            dtg_consulta.Columns("calidad").Visible = True
            dtg_consulta.Columns("diametro").Visible = True
            dtg_consulta.Columns("numPasos").Visible = True
            dtg_consulta.Columns("col_duplicar").Visible = True
            dtg_consulta.Columns("fecha_creacion").Visible = True
            dtg_consulta.Columns("fecha_terminacion").Visible = True
            dtg_consulta.Columns("notas_liquidacion").Visible = True
            dtg_consulta.Columns("costo_estandar_prog").Visible = True
            dtg_consulta.Columns("costo_estandar_prod").Visible = True
            dtg_consulta.Columns("costo_variacion").Visible = True
            dtg_consulta.Columns("vel_esp").Visible = True
            dtg_consulta.Columns("col_porcen").Visible = True
        Else
            MessageBox.Show("No hay información que exportar", "Exportar a excel", MessageBoxButtons.OK)
        End If
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles btn_consultar_mpc.Click
        Dim frm_matp_tref As New Frm_materia_prima_tref
        frm_matp_tref.Show()
    End Sub
    Private Sub txtProdFinal_TextChanged(sender As Object, e As EventArgs) Handles txtProdFinal.TextChanged
        If txtProdFinal.Text.Length > 5 And inicio_ficha > 0 Then
            cargarConsulta()
        End If
        inicio_ficha = 1
    End Sub
    Private Sub timer_ping_bd_Tick(sender As Object, e As EventArgs) Handles timer_ping_bd.Tick
        If My.Computer.Network.IsAvailable() Then
            If val_timer = "1" Then
                timRefescar.Enabled = True
                val_timer = ""
                frm.Close()
            End If
            If My.Computer.Network.Ping("10.10.10.246", 5000) Then
                If val_timer = "1" Then
                    timRefescar.Enabled = True
                    val_timer = ""
                    frm.Close()
                End If
            Else
                If val_timer <> "1" Then
                    If validar_formu() Then
                        val_timer = "1"
                        timRefescar.Enabled = False
                        frm.ShowDialog()
                    End If
                End If
            End If
        Else
            If val_timer <> "1" Then
                If validar_formu() Then
                    val_timer = "1"
                    timRefescar.Enabled = False
                    frm.ShowDialog()
                End If
            End If
        End If
    End Sub
    Private Function validar_formu()
        Dim resp As Boolean = True
        For Each f As Form In Application.OpenForms
            If f.Name = frm.Name Then
                resp = False
            End If
        Next
        Return resp
    End Function
    Private Function validar_planilla_abierta()
        'Validar cierre de planilla anterior
        Dim sql_planilla As String = "select max(id_Detalle) from J_det_orden_prod where cod_orden=" & consecutivoPpal & " and anulado is null"
        Dim ultima_planilla = objOpsimpesLn.consultValorTodo(sql_planilla, "PRODUCCION")
        If ultima_planilla = "" Then
            ultima_planilla = "0"
        End If
        Dim sql_cierre_ant As String = "select transaccion_entrada from J_det_orden_prod WHERE cod_orden=" & consecutivoPpal & " and id_Detalle=( " & ultima_planilla & ")"
        Dim val_cierre_ant As String = objOpsimpesLn.consultValorTodo(sql_cierre_ant, "PRODUCCION")
        Dim resp_cierre As Boolean = False
        If ultima_planilla >= 1 Then
            If val_cierre_ant <> "" Then
                resp_cierre = True
            Else
                resp_cierre = False
            End If
        Else
            resp_cierre = True
        End If
        Return resp_cierre
    End Function
    Private Sub timer_act_oper_Tick(sender As Object, e As EventArgs) Handles timer_act_oper.Tick
        sw_trabajo = False
        actualizar_operarios()
        sw_trabajo = True
    End Sub
    Private Sub CboFechaFin_ValueChanged_1(sender As Object, e As EventArgs) Handles cboFechaFin.ValueChanged
        If (cargaComp) Then
            cargarAdminProd(txtConsulNumOrd.Text)
        End If
    End Sub
    Private Sub CboFechaIni_ValueChanged_1(sender As Object, e As EventArgs) Handles cboFechaIni.ValueChanged
        If (cargaComp) Then
            cargarAdminProd(txtConsulNumOrd.Text)
        End If
    End Sub
    Private Sub CboAnoConsulta_SelectedIndexChanged_2(sender As Object, e As EventArgs) Handles cboAnoConsulta.SelectedIndexChanged
        If (cargaComp) Then
            cargarPlanOperario()
        End If
    End Sub

    Private Sub CboMesConsulta_SelectedIndexChanged_2(sender As Object, e As EventArgs) Handles cboMesConsulta.SelectedIndexChanged
        If (cargaComp) Then
            cargarPlanOperario()
        End If
    End Sub
    Private Sub BtnActOrdenes_Click_1(sender As Object, e As EventArgs) Handles btnActOrdenes.Click
        cargarPlanOperario()
    End Sub
    Private Sub dtg_consulta_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dtg_consulta.CellFormatting
        If e.ColumnIndex = Me.dtg_consulta.Columns("costo_variacion").Index _
        AndAlso (e.Value IsNot Nothing) Then
            With Me.dtg_consulta.Rows(e.RowIndex).Cells(e.ColumnIndex)
                .ToolTipText = "(costo estandar prog - costo estandar prod)-((cantidad prog - catidad prod) * costo materia prima)"
            End With
        End If
    End Sub
    Private Sub CboMaquinaFiltro_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles cboMaquinaFiltro.SelectedIndexChanged
        If (cargaComp) Then
            cargarAdminProd(txtConsulNumOrd.Text)
        End If
    End Sub
    Private Sub dtg_Inp_Calidad_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dtg_Inp_Calidad.CellValueChanged
        Dim col As String = dtg_Inp_Calidad.Columns(e.ColumnIndex).Name
        Dim sql As String = ""
        Dim valor As String = ""
        Dim cod_orden As String = ""
        Dim cod_detalle As String = ""
        Dim id_hora As String = ""
        Dim validar As Boolean = True
        If (col <> "hora") Then
            valor = dtg_Inp_Calidad.Item(col, e.RowIndex).Value.ToString
            If (valor <> "") Then
                If (col = "diametro" Or col = "resistencia" Or col = "peso" Or col = "circularidad") Then
                    If (IsNumeric(valor)) Then
                        validar = True
                    Else
                        validar = False
                        dtg_Inp_Calidad.Item(col, e.RowIndex).Value = ""
                        MessageBox.Show("Verifique que el valor ingresado sea númerico", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If
            End If

            If (validar) Then
                cod_orden = dtg_Inp_Calidad.Item("cod_orden", e.RowIndex).Value
                cod_detalle = dtg_Inp_Calidad.Item("cod_detalle", e.RowIndex).Value
                id_hora = dtg_Inp_Calidad.Item("id_hora", e.RowIndex).Value
                sql = "UPDATE J_plan_insp_cal SET " & col & " = '" & valor & "' WHERE cod_orden = " & cod_orden & " AND cod_detalle = " & cod_detalle & " AND id_hora = " & id_hora
                objOpsimpesLn.ejecutar(sql, "PRODUCCION")
            End If
        End If
    End Sub
    Private Sub Cbo_turno_ini_SelectedIndexChanged(sender As Object, e As EventArgs)
        If (cargaComp) Then
            cargarAdminProd(txtConsulNumOrd.Text)
        End If
    End Sub
    Private Sub Cbo_turno_fin_SelectedIndexChanged(sender As Object, e As EventArgs)
        If (cargaComp) Then
            cargarAdminProd(txtConsulNumOrd.Text)
        End If
    End Sub

    Private Sub IngresarMantenimientoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IngresarMantenimientoToolStripMenuItem.Click
        Dim frm As New Frm_Mantenimiento_Planta
        frm.Show()
    End Sub

    Private Sub CerrarForzadoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CerrarForzadoToolStripMenuItem.Click
        Dim result As MsgBoxResult
        result = MessageBox.Show("Deseas realizar un cierre forzado?", "Cierre forzado", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = vbYes Then
            If My.Computer.Network.Ping("10.10.10.246", 2000) Then
                Dim consulta As String = "SELECT top(1) session_id FROM sys.dm_exec_requests WHERE blocking_session_id <> 0"
                Dim bloqueo As String = objOpsimpesLn.consultValorTodo(consulta, "CORSAN")
                If bloqueo = "" Then
                    If cboMaquinaFiltro.Text <> "Seleccione" Then
                        Dim obtener_val As String = "" 'validacion nueva'
                        Dim sql_val As String = "" 'validacion nueva'
                        Dim pesoreco As Double = 0 'validacion nueva'
                        Dim pesoalam As Double = 0 'validacion nueva'
                        Dim pesotot As Double = 0 'validacion nueva'
                        Dim pesobrilla As Double = 0 'validacion nueva'
                        Dim resp As Boolean = False
                        resp = True
                        If resp Then
                            Dim sql_planilla As String
                            Dim val_planilla As String
                            sql_planilla = "select transaccion_entrada from J_det_orden_prod WHERE cod_orden=" & consecutivoPpal & " and id_detalle=" & consecutivoDet & ""
                            val_planilla = objOpsimpesLn.consultValorTodo(sql_planilla, "PRODUCCION")
                            If val_planilla = "" Then
                                cod_orden_sum = consecutivoPpal
                                id_detalle_sum = consecutivoDet
                                If (ingProdDmsForzo()) Then
                                    Dim sql As String
                                    cargaComp = False
                                    cboOperariosTurno.SelectedValue = dtgPlanAsociadas.Item("nit", dtgPlanAsociadas.CurrentCell.RowIndex).Value
                                    If cerrarTurnoDesdeCoordinador() Then
                                        sql = objOrdenProdLn.updateTransaccionesOrden(num_tran_prod, consecutivoDet, consecutivoPpal)
                                        objOpSimplesLn.ejecutar(sql, "PRODUCCION")
                                        Dim prod_f_trb As String = txtProdFinal.Text
                                        If prod_f_trb.ToUpper Like "22B100142*" Or prod_f_trb.ToUpper Like "22B100125*" Then
                                            If txtNumRollos.Text <> "0" Then
                                                trans_trb(consecutivoPpal, consecutivoDet)
                                                imprimir_Tiquete_lote_tref_8y9()
                                                restar_val8y9()
                                            End If
                                            'guardar_nrorollos_estado()
                                        End If
                                        ingProdEfic()
                                        MessageBox.Show("La planilla se cerro en forma correcta y la producción se ingreso en forma exitosa ! ", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                        cargarDtgAsociado("TODOS")
                                        cargaComp = True
                                    Else
                                        enviarCorreoErrorEppp(consecutivoPpal, consecutivoDet)
                                        MessageBox.Show("Error al realizar la transaccion, no realizo la transaccion y comuniquese con sistemas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    End If
                                Else
                                    MessageBox.Show("Error al cerrar la planilla, comuniquese con el administrador del sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                End If
                            Else
                                MessageBox.Show("No se puede registrar rollos por que la planilla ha sido cerrada", "Planilla cerrada", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            End If
                        Else
                            MessageBox.Show("Esta planilla No se puede cerrar, ya que se ha producido una cantidad total mayor a la materia prima.Se debe leer mas materia prima", "Planilla no se puede cerrar", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If
                    Else
                        MessageBox.Show("Debe seleccionar la maquina a la que pertenece la orden", "Dar doble clic primero", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                Else
                    MessageBox.Show("Bloque en base de datos,No se puede cerrar planilla", "No se debe cerrar planilla", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                MessageBox.Show("No hay conexion con la base de datos", "No hay conexion con la base de datos", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
    End Sub

    Private Sub btnexcel_Click(sender As Object, e As EventArgs) Handles btnexcel.Click
        If dtg_consulta.RowCount > 0 Then
            dtg_consulta.Columns("col_oculto").Visible = False
            dtg_consulta.Columns("btnVerDetalle").Visible = False
            dtg_consulta.Columns("planillas_abiertas").Visible = False
            dtg_consulta.Columns("maquina").Visible = False
            dtg_consulta.Columns("mes").Visible = False
            dtg_consulta.Columns("año").Visible = False
            dtg_consulta.Columns("calidad").Visible = False
            dtg_consulta.Columns("diametro").Visible = False
            dtg_consulta.Columns("numPasos").Visible = False
            dtg_consulta.Columns("col_duplicar").Visible = False
            dtg_consulta.Columns("fecha_creacion").Visible = False
            dtg_consulta.Columns("fecha_terminacion").Visible = False
            dtg_consulta.Columns("notas_liquidacion").Visible = False
            dtg_consulta.Columns("costo_estandar_prog").Visible = False
            dtg_consulta.Columns("costo_estandar_prod").Visible = False
            dtg_consulta.Columns("costo_variacion").Visible = False
            dtg_consulta.Columns("vel_esp").Visible = False
            dtg_consulta.Columns("col_porcen").Visible = False
            objOperacionesForm.ExportarDatosExcel(dtg_consulta, "Ordenes de producción trefilación")
            dtg_consulta.Columns("col_oculto").Visible = True
            dtg_consulta.Columns("btnVerDetalle").Visible = True
            dtg_consulta.Columns("planillas_abiertas").Visible = True
            dtg_consulta.Columns("maquina").Visible = True
            dtg_consulta.Columns("mes").Visible = True
            dtg_consulta.Columns("año").Visible = True
            dtg_consulta.Columns("calidad").Visible = True
            dtg_consulta.Columns("diametro").Visible = True
            dtg_consulta.Columns("numPasos").Visible = True
            dtg_consulta.Columns("col_duplicar").Visible = True
            dtg_consulta.Columns("fecha_creacion").Visible = True
            dtg_consulta.Columns("fecha_terminacion").Visible = True
            dtg_consulta.Columns("notas_liquidacion").Visible = True
            dtg_consulta.Columns("costo_estandar_prog").Visible = True
            dtg_consulta.Columns("costo_estandar_prod").Visible = True
            dtg_consulta.Columns("costo_variacion").Visible = True
            dtg_consulta.Columns("vel_esp").Visible = True
            dtg_consulta.Columns("col_porcen").Visible = True
        Else
            MessageBox.Show("No hay información que exportar", "Exportar a excel", MessageBoxButtons.OK)
        End If
    End Sub

    Private Sub btnNuevo2_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        actualizarConsecutivoPpal(0)
        actualizarConsecutivoDet(0)
        nuevo()
        dtgDiametros.Rows.Clear()
        dtgParo.DataSource = Nothing
        dtgPlanAsociadas.DataSource = Nothing
        TblPpal.SelectedTab = tblOrdenProd
    End Sub

    Private Sub dtg_Inp_Calidad_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtg_Inp_Calidad.CellContentClick

    End Sub

    Private Sub dtgPlanInsp_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgPlanInsp.CellContentClick

    End Sub

    Private Sub KryptonGroupBox1_Paint(sender As Object, e As PaintEventArgs) Handles KryptonGroupBox1.Paint

    End Sub
End Class