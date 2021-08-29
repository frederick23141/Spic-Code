Imports logicaNegocios
Imports entidadNegocios
Public Class Frm_tiempo_trabajo_Galv
    Dim objIngresoProdLn As New Ing_prodLn
    Private objOpSimplesLn As New Op_simpesLn
    Private Sub Frm_tiempo_trabajo_Galv_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cboturno1.Text = "1"
        cboturno2.Text = "3"
        cargar_consulta()
    End Sub
    Public Sub cargar_consulta()
        Dgvbobina.DataSource = Nothing
        Dim fecIni As String = objOpSimplesLn.cambiarFormatoFecha(cboFechaIni.Value)
        Dim fecFin As String = objOpSimplesLn.cambiarFormatoFecha(cboFechaFin.Value)
        Dim turn1 As String = Cboturno1.Text
        Dim turn2 As String = cboturno2.Text
        Dim dt As New DataTable
        Dim sql As String
        Dim selectd As String = ""
        Dim group As String = ""
        Dim where As String
        where = " where Fecha >= '" & fecIni & "' AND Fecha <= '" & fecFin & "' And Turno >= '" & turn1 & "' And Turno <= '" & turn2 & "'"

        If chkbobina.Checked = True Then
            selectd = "select Motor,sum(Horometro) as Minutos"
            group = "group by Motor"
        End If
        If selectd = "" Then
            selectd = " select  Motor,Turno,sum(Horometro) as Minutos"
            group = " group by Motor,Turno order by Motor,turno"
        End If
        sql = selectd & " FROM Jjv_plc_horometro" & where & group
        dt = objIngresoProdLn.listar_datatable(sql, "CORSAN")
        Dgvbobina.DataSource = dt
    End Sub

    Private Sub btnActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActualizar.Click
        cargar_consulta()
    End Sub

    Private Sub cboFechaIni_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFechaIni.ValueChanged
        cargar_consulta()
    End Sub

    Private Sub cboFechaFin_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFechaFin.ValueChanged
        cargar_consulta()
    End Sub

    Private Sub Cboturno1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cboturno1.SelectedIndexChanged
        cargar_consulta()
    End Sub

    Private Sub cboturno2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboturno2.SelectedIndexChanged
        cargar_consulta()
    End Sub
End Class