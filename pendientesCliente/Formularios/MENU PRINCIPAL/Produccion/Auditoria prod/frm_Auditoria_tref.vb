Imports logicaNegocios

Public Class frm_Auditoria_tref
    Private objOpsimpesLn As New Op_simpesLn
    Dim resp As Boolean = False
    Private Sub Frm_Auditoria_tref_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargar_Cbo()
        cargar_Informe()
        resp = True
    End Sub
    Private Sub cargar_Cbo()
        Dim min As Integer = 2018
        Dim max As Integer = Now.Date.Year
        Dim row As DataRow
        Dim sql As String
        Dim dt As DataTable
        While min <= max
            cbo_ano.Items.Add(min)
            min = min + 1
        End While
        Sql = "select  codigoM,nombre   from j_Maquinas where TipoMaquina = 1 AND activa = 1 "
        dt = New DataTable
        dt = objOpsimpesLn.listar_datatable(sql, "PRODUCCION")
        row = dt.NewRow
        row("codigoM") = 0
        row("nombre") = "Seleccione"
        dt.Rows.Add(row)
        cbo_tref.DataSource = dt
        cbo_tref.ValueMember = "codigoM"
        cbo_tref.DisplayMember = "nombre"
        cbo_tref.SelectedValue = 0
    End Sub
    Private Sub cargar_Informe()
        If resp Then
            If cbo_ano.Text <> "Seleccione" And cbo_mes.Text <> "Seleccione" Then
                Dim sql As String
                Dim ano As String = cbo_ano.Text
                Dim mes As String = cbo_mes.Text
                Dim tref As String = ""
                Dim tref2 As String = ""
                Dim dt As DataTable
                If cbo_tref.Text <> "Seleccione" Then
                    tref = " and e.id_maquina=" & cbo_tref.SelectedValue
                    tref2 = " and p.codigoM=" & cbo_tref.SelectedValue
                End If
                sql = "select p.cod_alambron,(select can_ent from CORSAN.dbo.referencias_Sto where codigo=p.cod_alambron and bodega=2 and ano=" & ano & " and mes=" & mes & ") as cant_ent ,(select can_sal from CORSAN.dbo.referencias_Sto where codigo=p.cod_alambron and bodega=2 and ano=" & ano & " and mes=" & mes & ") as cant_sal,(select ((can_ini+can_ent)-can_sal)  from CORSAN.dbo.referencias_Sto where codigo=p.cod_alambron and bodega=2 and ano=" & ano & " and mes=" & mes & ") as stock, sum(p.peso_real) as peso_matp,(select sum(peso) as  peso from J_orden_prod_tef e join J_det_orden_prod d on e.consecutivo = d.cod_orden join J_rollos_tref j on d.cod_orden=j.cod_orden and d.id_detalle=j.id_detalle where year(e.fecha_creacion)=" & ano & " and month(e.fecha_creacion)=" & mes & "" & tref & " and e.cod_alambron=p.cod_alambron AND d.transaccion_entrada is not null AND J.anulado IS NULL AND J.manuales IS NULL) as peso_prod," &
                " (sum(p.peso_real)-(select sum(peso) as  peso from J_orden_prod_tef e join J_det_orden_prod d on e.consecutivo = d.cod_orden join J_rollos_tref j on d.cod_orden=j.cod_orden and d.id_detalle=j.id_detalle where year(e.fecha_creacion)=" & ano & " and month(e.fecha_creacion)=" & mes & "" & tref & " and e.cod_alambron=p.cod_alambron AND d.transaccion_entrada is not null AND J.anulado IS NULL AND J.manuales IS NULL)) as dif" &
                " from J_tref_cont_mp p  where p.ano=" & ano & " and p.mes=" & mes & "" & tref2 & "  group by p.cod_alambron"

                dt = objOpsimpesLn.listar_datatable(sql, "PRODUCCION")
                dtg_auditoria_tref.DataSource = dt
                dtg_auditoria_tref.DataSource = totalizar_Informe()
                pintartotal()
            Else
                MessageBox.Show("Seleccione un año y un mes", "Seleccionar fecha", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
    End Sub
    Private Function totalizar_Informe()
        Dim cant_mp As Double = 0
        Dim cant_prod As Double = 0
        Dim kilos As Double = 0
        Dim cant_ent As Double = 0
        Dim cant_sal As Double = 0
        Dim stock As Double = 0
        Dim indice As Integer = 0
        Dim dt As DataTable = DirectCast(dtg_auditoria_tref.DataSource, DataTable)
        For Each row As DataRow In dt.Rows
            If row.Item("peso_matp") > 0 Then
                cant_mp += row.Item("peso_matp")
            End If
            If row.Item("peso_prod") > 0 Then
                cant_prod += row.Item("peso_prod")
            End If
            If row.Item("cant_ent") > 0 Then
                cant_ent += row.Item("cant_ent")
            End If
            If row.Item("cant_sal") > 0 Then
                cant_sal += row.Item("cant_sal")
            End If
            If row.Item("stock") > 0 Then
                stock += row.Item("stock")
            End If
            If indice = (dt.Rows.Count - 1) Then
                dt.Rows.Add()
                dt.Rows(dt.Rows.Count - 1).Item("cod_alambron") = "TOTAL"
                dt.Rows(dt.Rows.Count - 1).Item("peso_matp") = cant_mp
                dt.Rows(dt.Rows.Count - 1).Item("peso_prod") = cant_prod
                dt.Rows(dt.Rows.Count - 1).Item("cant_ent") = cant_ent
                dt.Rows(dt.Rows.Count - 1).Item("cant_sal") = cant_sal
                dt.Rows(dt.Rows.Count - 1).Item("stock") = stock
                Exit For
            End If
            indice += 1
        Next
        Return dt
    End Function
    Public Sub pintartotal()
        If dtg_auditoria_tref.Rows.Count > 0 Then
            dtg_auditoria_tref.Rows(dtg_auditoria_tref.Rows.Count - 1).DefaultCellStyle.BackColor = Color.Salmon
            dtg_auditoria_tref.Rows(dtg_auditoria_tref.Rows.Count - 1).DefaultCellStyle.Font = New Font(dtg_auditoria_tref.CurrentCell.InheritedStyle.Font, FontStyle.Bold)
        End If
    End Sub
    Private Sub Txt_cargar_Click(sender As Object, e As EventArgs) Handles txt_cargar.Click
        cargar_Informe()
    End Sub
End Class