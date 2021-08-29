Imports logicaNegocios
Imports System.Data.SqlClient
Public Class Frm_meta_ambiental
    Private obj_op_simplesLn As New Op_simpesLn
    Private Sub Frm_meta_ambiental_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargar_Cbo()
    End Sub
    Private Sub cargar_Cbo()
        Dim dt As New DataTable
        Dim dr As DataRow
        Dim sql As String
        Dim where_sql As String = ""
        where_sql &= "WHERE centro IN(1100,1200,2100,2117,2200,2300,2400,2500,2600,2800,3100,3200,3500,4100,4200,4300,5200,6200,6400)"

        dt = New DataTable
        sql = "SELECT centro,( CAST (centro AS varchar(25))+ '-' + descripcion )As descripcion " & _
                    "FROM centros " & _
                        where_sql
        dt = obj_op_simplesLn.listar_datatable(sql, "CORSAN")
        dr = dt.NewRow
        dr("centro") = 0
        dr("descripcion") = "Seleccione"
        dt.Rows.Add(dr)
        cbo_centro.DataSource = dt
        cbo_centro.ValueMember = "centro"
        cbo_centro.DisplayMember = "descripcion"
        cbo_centro.SelectedValue = 0
    End Sub
    Private Function validad_Entrada()
        Dim resp As Boolean = False
        If txt_meta.Text <> "" And IsNumeric(txt_meta.Text) Then
            If cbo_centro.Text <> "Seleccione" Then
                resp = True
            Else
                MessageBox.Show("Seleccione el centro de costo", "Seleccione el centro de costos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Else
            MessageBox.Show("Ingrese la meta correctamente", "Ingrese la meta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
        Return resp
    End Function
    Private Sub btn_guardar_Click(sender As Object, e As EventArgs) Handles btn_guardar.Click
        If validad_Entrada() Then
            Dim meta As String = txt_meta.Text
            Dim centro As String = cbo_centro.SelectedValue
            Dim ano As Integer = CInt(month_Calender_year.SelectionRange.Start.ToString("yyyy"))
            Dim mes As Integer = CInt(month_Calender_year.SelectionRange.Start.ToString("MM"))
            Dim sql As String = "SELECT id_meta FROM D_meta_centro_Costos where ano=" & ano & " and mes=" & mes & ""
            Dim val As String = obj_op_simplesLn.consultValorTodo(sql, "PRODUCCION")
            If val = "" Then
                sql = " INSERT INTO D_meta_centro_Costos (meta,mes,ano,centro) values (" & meta & "," & mes & "," & ano & "," & centro & ")"
                MessageBox.Show("Se ha insertado la meta", "Insertar la meta", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                sql = " UPDATE D_meta_centro_Costos SET meta=" & meta & ",mes=" & mes & ",ano=" & ano & ",centro=" & centro & " where ano=" & ano & " and mes=" & mes & ""
                MessageBox.Show("Se ha actualizado la meta", "Insertar la meta", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            obj_op_simplesLn.ejecutar(sql, "PRODUCCION")
        End If
    End Sub
End Class