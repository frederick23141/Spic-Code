Imports logicaNegocios
Public Class frm_anular_rollo_puas
    Private objOpsimpesLn As New Op_simpesLn
    Dim nit As String
    Dim cod_maquina As String
    Dim codM1, codM2 As String
    Dim objTraslado_bodLn As New traslado_bodLn
    Public Sub main(ByVal nit_o As String, ByVal cod_maq As String, ByVal mp1 As String, ByVal mp2 As String)
        nit = nit_o
        cod_maquina = cod_maq
        codM1 = mp1
        codM2 = mp2
    End Sub
    Private Sub cargarRollos()
        Dim s_fec_ini As String = Now.Year & "-" & Now.Month & "-" & Now.Day & ""
        Dim fecha As String = objOpsimpesLn.cambiarFormatoFecha(DateTime.Now)
        Dim fec_c, fec_inicial, fec_final, turno As String
        fec_c = "" & System.DateTime.Now.Hour & ":" & System.DateTime.Now.Minute & ""

        If CDate(fec_c) >= "6:00" And CDate(fec_c) <= "14:00" Then
            turno = "1"
        ElseIf CDate(fec_c) >= "14:00" And CDate(fec_c) <= "22:00" Then
            turno = "2"
        ElseIf CDate(fec_c) >= "22:00" And CDate(fec_c) <= "6:00" Then
            turno = "3"
        End If
#Disable Warning BC42104 ' La variable 'turno' se usa antes de que se le haya asignado un valor. Podría darse una excepción de referencia NULL en tiempo de ejecución.
        If turno = "1" Then
#Enable Warning BC42104 ' La variable 'turno' se usa antes de que se le haya asignado un valor. Podría darse una excepción de referencia NULL en tiempo de ejecución.
            fec_inicial = "6:00"
            fec_final = "14:00"
        ElseIf turno = "2" Then
            fec_inicial = "14:00"
            fec_final = "22:00"
        Else
            fec_inicial = "14:00"
            fec_final = "22:00"
        End If
        Dim sql_rollo As String = "select orden.prod_final,rollo.peso_real,rollo.maquina,rollo.nro_orden,rollo.consecutivo_rollo,rollo.anular,rollo.trans_puas,rollo.tipo_trans from D_orden_prod_puas_producto rollo, D_orden_prod_puas orden where rollo.no_conforme is null and rollo.fecha_hora >='" & fecha & "' and rollo.nit_operario=" & nit & " and rollo.nro_orden = orden.cod_orden order by rollo.fecha_hora desc"
        dtgRollos.DataSource = objOpsimpesLn.listar_datatable(sql_rollo, "PRODUCCION")
        Me.dtgRollos.Columns("anular").Visible = False
        Me.dtgRollos.Columns("trans_puas").Visible = False
        Me.dtgRollos.Columns("tipo_trans").Visible = False
        For Each Row As DataGridViewRow In dtgRollos.Rows
            If IsDBNull(Row.Cells("anular").Value) = False Then
                Row.DefaultCellStyle.BackColor = Color.Red
            End If
        Next
    End Sub
    Private Sub frm_anular_rollo_puas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarRollos()
    End Sub
    Private Sub dtgRollos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgRollos.CellClick
        Dim col As String = dtgRollos.Columns(e.ColumnIndex).Name
        Dim fila As Integer = e.RowIndex
        If fila >= 0 Then
            Dim rollo_anulado As Boolean = IsDBNull(dtgRollos.Item("anular", fila).Value())
            Dim orden As Integer
            Dim consecutivo As Integer
            Dim result As MsgBoxResult
            If (col = "btnanular") Then
                If rollo_anulado = True Then
                    result = MessageBox.Show("Desea anular el rollo?", "Anular rollo", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                    Dim anular As Integer = 1
                    Dim codigo As String = dtgRollos.Item("prod_final", fila).Value()
                    Dim bodega As String = objTraslado_bodLn.obtenerBodegaXcodigo(codigo)
                    bodega = 2
                    Dim stock As Double = objOpsimpesLn.consultarStock(codigo, bodega)
                    Dim peso As Double = 1
                    'dtgRollos.Item("peso_real", fila).Value()
                    If result = vbYes Then
                        Dim motivo As String = InputBox("Ingrese motivo de autorización de la transacción", "Ingrese motivo")
                        If motivo <> "" Then
                            If peso <= stock Then
                                motivo &= "-" & Now & "- " & nit
                                orden = dtgRollos.Item("nro_orden", fila).Value()
                                consecutivo = dtgRollos.Item("consecutivo_rollo", fila).Value()
                                Dim numero_trans As Double = dtgRollos.Item("trans_puas", fila).Value()
                                Dim tipo_trans As String = dtgRollos.Item("tipo_trans", fila).Value()
                                Dim listSql As New List(Of Object)
                                listSql.AddRange(objTraslado_bodLn.anularTransaccionPuas(numero_trans, tipo_trans, motivo))
                                If objOpsimpesLn.ExecuteSqlTransaction(listSql) Then
                                    Dim sql As String = "UPDATE D_orden_prod_puas_producto SET anular=" & anular & " where nro_orden=" & orden & " and consecutivo_rollo=" & consecutivo & ""
                                    If (objOpsimpesLn.ejecutar(sql, "PRODUCCION") > 0) Then
                                        'reintegrar_Descuento(peso)
                                        cargarRollos()
                                        MessageBox.Show("Rollo anulado", "Anular rollo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    End If
                                End If
                            Else
                                MessageBox.Show("El rollo a elimar supera el stock de la bodega'STOCK BODEGA'! ", "Verifique!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            End If
                        End If
                    End If
                Else
                    MessageBox.Show("El rollo ya ha sido anulado! ", "Anulado!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End If
        End If
    End Sub
    Private Sub reintegrar_Descuento(ByVal peso As Double)
        Dim resp_Mp_D As Boolean = False
        Dim sql As String
        If codM1 <> codM2 Then
            resp_Mp_D = True
        End If
        If resp_Mp_D = False Then
            sql = "UPDATE D_orden_prod_puas_cont_mp_prod SET  peso_lleva +=" & peso & " where codigo='" & codM1 & "'"
            objOpsimpesLn.ejecutar(sql, "PRODUCCION")
        Else
            sql = "UPDATE D_orden_prod_puas_cont_mp_prod SET  peso_lleva +=" & calcular_consumo_doble(peso, codM1) & " where codigo='" & codM1 & "'"
            objOpsimpesLn.ejecutar(sql, "PRODUCCION")
            sql = "UPDATE D_orden_prod_puas_cont_mp_prod SET  peso_lleva +=" & calcular_consumo_doble(peso, codM2) & " where codigo='" & codM2 & "'"
            objOpsimpesLn.ejecutar(sql, "PRODUCCION")
        End If
    End Sub
    Private Function calcular_consumo_doble(ByVal peso As String, ByVal codigo As String)
        Dim peso_matp1, peso_matp2 As Double
        peso_matp1 = ((peso * 80.15) / 100)
        peso_matp2 = ((peso * 19.85) / 100)
        If codigo = "22G110246" Or codigo = "22G110200" Then
            Return peso_matp1
        Else
            Return peso_matp2
        End If
    End Function
End Class