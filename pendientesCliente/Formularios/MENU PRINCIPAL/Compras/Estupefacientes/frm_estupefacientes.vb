Imports accesoDatos
'ventana hecha por david hincapie tapias
Public Class frm_estupefacientes
    Private dt As New DataTable
    Private Sub frm_estupefacientes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        mostrar1()
        mostrar2()
        For Each fila As DataGridViewRow In Dtg_i_estupefacientes_e_s.Rows
            If fila.Cells("codigo").Value = "50702001" Then
                If fila.Cells("entradas").Value >= 9000 Or fila.Cells("salidas").Value >= 9000 Or fila.Cells("stock").Value >= 9000 Then
                    fila.DefaultCellStyle.BackColor = Color.Red

                End If
            End If
            If fila.Cells("codigo").Value = "50702004" Then
                If fila.Cells("entradas").Value >= 25 Or fila.Cells("salidas").Value >= 25 Or fila.Cells("stock").Value >= 25 Then
                    fila.DefaultCellStyle.BackColor = Color.Yellow
                End If
            End If

        Next
    End Sub
    Private Sub mostrar1()
        Try
            Dim func As New Op_simplesAd
            dt = func.mostrar_estupefa_e_s
            If dt.Rows.Count <> 0 Then
                Dtg_i_estupefacientes_e_s.DataSource = dt
            Else
                Dtg_i_estupefacientes_e_s.DataSource = Nothing
                Dtg_i_estupefacientes_e_s.ColumnHeadersVisible = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Private Sub mostrar2()
        Try
            Dim func As New Op_simplesAd
            dt = func.mostrar_estupefa_informacion
            If dt.Rows.Count <> 0 Then
                dtg_infor_estupefacientes.DataSource = dt
            Else
                dtg_infor_estupefacientes.DataSource = Nothing
                dtg_infor_estupefacientes.ColumnHeadersVisible = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub


End Class