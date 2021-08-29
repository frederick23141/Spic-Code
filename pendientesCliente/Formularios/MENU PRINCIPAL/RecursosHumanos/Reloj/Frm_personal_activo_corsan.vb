Imports logicaNegocios
Imports System.Speech
Public Class Frm_personal_activo_corsan
    Private objOpSimplesLn As New Op_simpesLn
    Private objRelojLn As New RelojLn
    Private Sub cargarSinSalida()
        Dim tamano_letra As Single = 7.0!
        Dim sql As String = "SELECT t.nombres ,r.FechaEntrada  " & _
                               "FROM r_personal_registros r , CORSAN.dbo.V_nom_personal_Activo_con_maquila  t , CORSAN.dbo.centros  c " & _
                                     "WHERE r.nit = t.nit AND t.centro = c.centro AND FechaSalida is null   " & _
                                        "ORDER BY YEAR(r.fechaEntrada),MONTH(r.fechaEntrada) ,DAY(r.fechaEntrada),DATEPART (hour,fechaEntrada),t.nombres "
        dtg_consulta.DataSource = objOpSimplesLn.listar_datatable(sql, "CONTROL")
        dtg_consulta.Columns("FechaEntrada").DefaultCellStyle.Format = "g"
        lbl_corsan.Text &= CStr(dtg_consulta.RowCount)
        '   dtg_consulta.Columns("descripcion").DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", tamano_letra)
    End Sub
    Private Sub Frm_personal_activo_corsan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarSinSalida()
    End Sub
End Class