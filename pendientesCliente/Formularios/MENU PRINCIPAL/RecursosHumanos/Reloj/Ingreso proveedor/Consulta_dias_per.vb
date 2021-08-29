Imports logicaNegocios
Public Class Consulta_dias_per
    Dim nit_r As Double
    Dim sql As String
    Dim val As String
    Private objOpSimplesLn As New Op_simpesLn
    Sub main(ByVal nit As Double, ByVal iden As String)
        nit_r = nit
        val = iden
        For i = Now.Year - 1 To Now.Year + 1
            cbo_ano.Items.Add(i)
        Next
        For i = 1 To 12
            cbo_mes.Items.Add(i)
        Next
        cbo_ano.Text = Now.Year
        cbo_mes.Text = Now.Month
        If iden = "N" Then
            lbl_ano.Visible = False
            lbl_mes.Visible = False
            cbo_ano.Visible = False
            cbo_mes.Visible = False
        End If
    End Sub
    Private Sub Consulta_dias_per_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargar_consulta()
    End Sub
    Private Sub cargar_consulta()
        Dim ano As String = cbo_ano.Text
        Dim mes As String = cbo_mes.Text
        Dim dia As String = Now.Day
        If val = "S" Then
            sql = "select c.nombre_Contratista as nombre,c.nombre_Empresa as empresa,d.dia,d.observacion from J_perm_dias_cont d join J_control_contratistas c on d.nit_contra=c.nit_Contratista where d.nit_contra=" & nit_r & "" &
                   "and d.ano=" & ano & " and d.mes=" & mes & ""
        Else
            ano = Now.Year
            mes = Now.Month

            sql = "select c.nombre_Contratista as nombre,c.nombre_Empresa as empresa,d.dia,d.observacion from J_perm_dias_cont d join J_control_contratistas c on d.nit_contra=c.nit_Contratista where d.ano=" & ano & " and d.mes=" & mes & " AND d.dia=" & dia & ""
        End If
        dtg_dias_asigna.DataSource = objOpSimplesLn.listar_datatable(sql, "CONTROL")
    End Sub
    Private Sub btn_consultar_Click(sender As Object, e As EventArgs) Handles btn_consultar.Click
        cargar_consulta()
    End Sub
End Class