Imports logicaNegocios
Imports entidadNegocios
Public Class frm_chatarra_tref
    Private centro As String
    Private cod_or, id_de, per As String
    Private objOpsimpesLn As New Op_simpesLn

    Sub main(ByVal cod_orden As String, ByVal id_detalle As String, ByVal permiso As String)
        cod_or = cod_orden
        id_de = id_detalle
        per = permiso
        If per <> "OPERARIOS" Then
            cbo_defecto.Enabled = False
            txt_Kilos.Enabled = False
            btnagregar.Enabled = False
        End If
    End Sub

    Private Sub Frm_chatarra_tref_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim sql As String
        Dim dt As New DataTable
        Dim row As DataRow
        sql = "SELECT d.Id_defecto,d.D_defecto " &
                        " FROM J_desperdicios_defecto d , J_desperdicio_def_centro c " &
                            "WHERE d.id_defecto = c.id_defecto AND c.centro =2100 AND d.id_defecto not in (46)"
        dt = objOpsimpesLn.listar_datatable(sql, "PRODUCCION")
        row = dt.NewRow
        row("Id_defecto") = 0
        row("D_defecto") = "Seleccione"
        dt.Rows.Add(row)
        cbo_defecto.DataSource = dt
        cbo_defecto.ValueMember = "Id_defecto"
        cbo_defecto.DisplayMember = "D_defecto"
        cbo_defecto.SelectedValue = 0
        cargar_chatarra()
    End Sub
    Private Sub cargar_chatarra()
        Dim sql As String
        If per <> "OPERARIOS" Then
            sql = "select id_orden, id_det, id_chat, defecto, kilos from J_control_chatarra_tref " &
              " where id_orden=" & cod_or & ""
        Else
            sql = "select id_orden, id_det, id_chat, defecto, kilos from J_control_chatarra_tref " &
                          " where id_orden=" & cod_or & " and id_det=" & id_de & ""
        End If
        dtg_chatarra.DataSource = objOpsimpesLn.listar_datatable(sql, "PRODUCCION")
        dtg_chatarra.AutoResizeColumns()
        dtg_chatarra.DataSource = totalizar_Admin()
    End Sub
    Private Function totalizar_Admin()
        Dim cant_prog As Double = 0
        Dim kilos As Double = 0
#Disable Warning BC42024 ' Variable local sin usar: 'costo_prod'.
        Dim costo_prod As Double
#Enable Warning BC42024 ' Variable local sin usar: 'costo_prod'.
#Disable Warning BC42024 ' Variable local sin usar: 'costo_prog'.
        Dim costo_prog As Double
#Enable Warning BC42024 ' Variable local sin usar: 'costo_prog'.
#Disable Warning BC42024 ' Variable local sin usar: 'costo_variacion'.
        Dim costo_variacion As Double
#Enable Warning BC42024 ' Variable local sin usar: 'costo_variacion'.
        Dim indice As Integer = 0
        Dim dt As DataTable = DirectCast(dtg_chatarra.DataSource, DataTable)
        For Each row As DataRow In dt.Rows
            If IsDBNull(row.Item("kilos")) = False Then
                If row.Item("kilos") > 0 Then
                    kilos += row.Item("kilos")
                End If
            End If
            If indice = (dt.Rows.Count - 1) Then
                dt.Rows.Add()
                dt.Rows(dt.Rows.Count - 1).Item("defecto") = "TOTAL"
                dt.Rows(dt.Rows.Count - 1).Item("kilos") = kilos

                Exit For
            End If
            indice += 1
        Next
        Return dt
    End Function
    Private Function validar_entrada()
        Dim resp As Boolean = False
        If cbo_defecto.Text <> "Seleccione" Then
            If txt_Kilos.Text <> "" Then
                If IsNumeric(txt_Kilos.Text) Then
                    resp = True
                Else
                    MessageBox.Show("Los kilos deben ser numericos", "Ingresar kilos", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                MessageBox.Show("Debe Ingresar los kilos", "Ingresar kilos", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            MessageBox.Show("Debe seleccionar un defecto para ingresar", "Seleccionar defecto", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Return resp
    End Function
    Private Sub Btnagregar_Click(sender As Object, e As EventArgs) Handles btnagregar.Click
        If validar_entrada() Then
#Disable Warning BC42024 ' Variable local sin usar: 'dt'.
            Dim dt As DataTable
#Enable Warning BC42024 ' Variable local sin usar: 'dt'.
            Dim sql As String
            sql = "Select id_chat from J_control_chatarra_tref where id_orden=" & cod_or & " and id_det=" & id_de & ""
            Dim id_chat As String = objOpsimpesLn.consultValorTodo(sql, "PRODUCCION")
            If id_chat = "" Then
                id_chat = "1"
            Else
                id_chat = (id_chat + 1)
            End If
            sql = "INSERT INTO J_control_chatarra_tref (id_orden,id_det,id_chat,id_defecto,defecto,kilos)" &
                " VALUES (" & cod_or & "," & id_de & "," & id_chat & "," & cbo_defecto.SelectedValue & ",'" & cbo_defecto.Text & "'," & txt_Kilos.Text & ")"
            objOpsimpesLn.ejecutar(sql, "PRODUCCION")
            MessageBox.Show("La chatarra registrada correctamente", "Chatarra registrada", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cargar_chatarra()
        End If
    End Sub
End Class