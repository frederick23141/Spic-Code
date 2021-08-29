Imports logicaNegocios
Imports entidadNegocios
Public Class frm_planilla_inspeccion
    Private objOpsimpesLn As New Op_simpesLn
    Dim nro_o As Integer
    Dim nro_r As String
    Dim registrado_r As Boolean
    Dim peso_r As String
    Public Sub main(ByVal nro_orden As Integer, ByVal registrado As Boolean, ByVal peso As String)
        nro_o = nro_orden
        registrado_r = registrado
        peso_r = peso
    End Sub
    Private Sub btn_planilla_Click(sender As Object, e As EventArgs) Handles btn_planilla.Click
        Dim conformado As String = "N"
        Dim longitud As String = "N"
        Dim simetria As String = "N"
        Dim sql As String
        If chk_conformado.Checked = True Then
            conformado = "S"
        End If
        If chk_longitud.Checked = True Then
            longitud = "S"
        End If
        If chk_simetria.Checked = True Then
            simetria = "S"
        End If
        If txt_empate.Text <> "" And IsNumeric(txt_empate.Text) Then
            If txt_torsion.Value > 0 Then
                If IsNumeric(peso_r) Then
                    If registrado_r = True Then
                        sql = "select max(consecutivo_rollo)+1 from D_orden_prod_puas_producto where nro_orden=" & nro_o & ""
                        nro_r = objOpsimpesLn.consultValorTodo(sql, "PRODUCCION")
                        sql = "INSERT INTO D_orden_prod_puas_inspeccion (nro_orden_puas,nro_rollo,peso,conformado,longitud,simetria,torsion,empates)" & _
                              " VALUES(" & nro_o & "," & nro_r & "," & peso_r & ",'" & conformado & "','" & longitud & "','" & simetria & "'," & txt_torsion.Value & "," & txt_empate.Text & ")"
                        objOpsimpesLn.ejecutar(sql, "PRODUCCION")
                        MessageBox.Show("Planilla ingresada con exito", "Planilla ingresada", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("Primero registra el rollo, despues la plinilla de inspección", "Peso numerico", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.Close()
                    End If
                Else
                    MessageBox.Show("El peso debe ser numerico", "Peso numerico", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Else
                MessageBox.Show("Ingrese la torsión mayor a 0", "Ingresar torsión", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Else
            MessageBox.Show("Ingrese el empate", "Ingresar empate", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
End Class