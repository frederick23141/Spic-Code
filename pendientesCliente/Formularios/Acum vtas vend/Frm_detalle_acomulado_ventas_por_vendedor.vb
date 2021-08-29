Imports System.Configuration
Imports logicaNegocios
Imports System.IO
Public Class Frm_detalle_acomulado_ventas_por_vendedor
    Private objOperacionesForm As OperacionesFormularios = New OperacionesFormularios
    Private objAcumVtasVendLn As New AcumVtasVendLn
    Dim vend As Integer = 0

    ''obtenemos los datos del vendedor. ventas 
    Public Sub Main(ByVal vendedor As Integer, ByVal fec_ini As String, ByVal fec_fin As String, ByVal id_cor As Integer)
        Dim sql As String = "SELECT vtas.codigo,vtas.descripcion,SUM (vtas.Vr_total )As vr_total ,SUM (vtas.KILOS) As Kilos " &
                                "FROM Jjv_V_vtas_vend_cliente_ref vtas  " &
                                    "WHERE vtas.vendedor = " & vendedor & " AND vtas.fec >='" & fec_ini & "' AND vtas.fec <='" & fec_fin & "' AND vtas.Id_cor= " & id_cor & " " &
                                         "GROUP BY vtas.codigo,vtas.descripcion "
        vend = vendedor
        dtg_detalle.DataSource = objAcumVtasVendLn.listar_detalle(sql)
        sumar_col_grid(dtg_detalle)
        negrita(dtg_detalle)
    End Sub

    ''boton para regresar al home. cerrando esta instancia
    Private Sub ToolStripButton2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FrmPrincipal.Show()
        Me.Close()
        FrmPrincipal.Activate()
    End Sub

    ''boton para regresar al login. cerrando esta instancia
    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        FrmLogin.Show()
        FrmPrincipal.Close()
        FrmLogin.Activate()
        Me.Close()
    End Sub

    ''boton para exportar a excel
    Private Sub btn_exportar_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exportar.ButtonClick
        objOperacionesForm.ExportarDatosExcel(dtg_detalle, "Detalle")
    End Sub


    ''public sumar_col_grid lo usamos para sumar las columnas del datagrid
    Public Sub sumar_col_grid(ByVal dtg As DataGridView)
        Dim suma As Double = 0
        dtg.Item("codigo", dtg.RowCount - 1).Value = "TOTAL"
        For j = 2 To dtg.ColumnCount - 1
            For i = 0 To dtg.RowCount - 1
                If Not IsDBNull(dtg.Item(j, i).Value) Then
                    suma = suma + dtg.Item(j, i).Value
                End If
            Next
            dtg.Item(j, dtg.RowCount - 1).Value = suma
            suma = 0
        Next
    End Sub

    '' private sub negrita lo usamos para cambiar el formato de la letra a negrita del datagridviewcellstyle1 
    Private Sub negrita(ByVal dtg As DataGridView)
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        dtg.Columns(0).DefaultCellStyle = DataGridViewCellStyle1
        dtg.Rows(dtg.RowCount - 1).DefaultCellStyle = DataGridViewCellStyle1
    End Sub
End Class