Imports logicaNegocios
Public Class FrmDvrNcmc
    Private fila As Integer
    Private carga_comp As Boolean = False
    Private objQuejaRecLn As New QuejaRecLn
    Private nit As Double
    Private objOpSimplesLn As New Op_simpesLn
    Public Sub main(ByVal fil As Integer, ByVal doc As Double)
        fila = fil
        nit = doc
        dvrNcmc()
    End Sub
    Private Sub FrmDvrNcmc_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cbo_fecha_ini.Value = Now.AddMonths(-1)
        cbo_fecha_fin.Value = Now.Date
        carga_comp = True
    End Sub

    Private Sub dtg_consulta_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtg_consulta.CellDoubleClick
        FrmQuejaRec.dtgQuejaRec.Item("txtNotaCredito", fila).Value = dtg_consulta.Item("numero", e.RowIndex).Value
        Me.Close()
    End Sub
    Public Sub dvrNcmc()
        If (carga_comp) Then
            Dim strSql As String = "SELECT fecha,sw,tipo,numero,nombres ,ciudad,cupo_credito,condicion,bloqueo,vendedor ,valor_total,notas   " & _
                                               "FROM V_cartera_edades_jjv "
            Dim whereSql As String = "WHERE fecha>='" & objOpSimplesLn.cambiarFormatoFecha(cbo_fecha_ini.Value.Date) & "' AND fecha <='" & objOpSimplesLn.cambiarFormatoFecha(cbo_fecha_fin.Value.Date) & "' AND nit = " & nit & " AND (tipo like '%DVR%' or tipo like '%NCM%')"
            Dim valor As String = ""
            strSql = strSql & whereSql
            dtg_consulta.DataSource = objQuejaRecLn.listar_datatable(strSql)
        End If


    End Sub
    Private Sub cbo_fecha_ini_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_fecha_ini.ValueChanged
        dvrNcmc()
    End Sub

    Private Sub cbo_fecha_fin_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_fecha_fin.ValueChanged
        dvrNcmc()
    End Sub

    Private Sub dtg_consulta_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dtg_consulta.KeyPress
        If (e.KeyChar = Microsoft.VisualBasic.ChrW(13)) Then
            FrmQuejaRec.dtgQuejaRec.Item("txtNotaCredito", fila).Value = dtg_consulta.Item("numero", dtg_consulta.CurrentCell.RowIndex).Value
            Me.Close()
        End If
    End Sub
End Class