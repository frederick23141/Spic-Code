Imports System.Configuration
Imports logicaNegocios
Imports entidadNegocios
Imports System.IO
Imports Microsoft.Office.Interop
Public Class Frm_ptes_problem
    Dim objOpSimplesLn As New Op_simpesLn
    Private objUsuarioLn As New UsuarioLn
    Public vendedor As Integer
    Private objIngVtaLn As New IngVtasLn
    Public strSql As String = ""
    Dim usuario As String


    Public Sub Main(ByVal vend As Integer, ByVal usuario As String)
        Dim vendedores As String = objUsuarioLn.coordinadorVend(usuario)
        Me.usuario = usuario
        vendedor = vend
        Dim sql As String = ""
        Dim criterioVendedor As String = ""
        If (vendedores <> "") Then
            criterioVendedor = " ped.vendedor in (" & vendedores & ")"
        Else
            criterioVendedor = " ped.vendedor >= 1001 AND ped.vendedor <= 1099"
        End If
        If (vendedor = 1020) Then
            sql = "SELECT lin.bodega,ped.autorizacion,lin.precio_si_costo_cero AS p_min,ped.nit,ped.vendedor,lin.numero,ter.nombres,ter.ciudad ,lin.codigo,ref.descripcion , lin.valor_unitario,ped.fecha ,lin.cantidad,ped.notas,ped.notas_aut   " & _
                                 "FROM jjv_documentos_lin_ped lin, jjv_documentos_ped ped ,referencias ref , terceros ter " & _
                                      "WHERE lin.numero = ped.numero and ref.codigo = lin.codigo and ped.anulado =0 and ped.nit= ter.nit AND " & criterioVendedor & "" & _
                                            " ORDER BY lin.numero "
            dtg_pend.DataSource = objIngVtaLn.listar_ptes_problema(sql)
        Else
            sql = "SELECT lin.bodega,ped.autorizacion,lin.precio_si_costo_cero AS p_min,ped.nit,ped.vendedor,lin.numero,ter.nombres,ter.ciudad ,lin.codigo,ref.descripcion , lin.valor_unitario,ped.fecha ,lin.cantidad,ped.notas,ped.notas_aut  " & _
                            "FROM jjv_documentos_lin_ped lin, jjv_documentos_ped ped ,referencias ref , terceros ter " & _
                                        "WHERE lin.numero = ped.numero And ref.codigo = lin.codigo And ped.anulado = 0 And ped.nit = ter.nit And ped.vendedor = " & vendedor & " AND  " & criterioVendedor & "" & _
                                                    " ORDER BY lin.numero"
            dtg_pend.DataSource = objIngVtaLn.listar_ptes_problema(sql)
        End If
        dtg_pend.Columns("fecha").DefaultCellStyle.Format = "d"
        '  dtg_pend.Columns("fecha_hora").DefaultCellStyle.Format = "d"
    End Sub
    Private Sub dtg_pend_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtg_pend.CellDoubleClick
        If (e.RowIndex <> -1) Then
            Dim vec(6) As Object
            Dim numero As Double = dtg_pend.Item("numero", e.RowIndex).Value
            Dim sub_tot As Double = 0
            Dim vr_iva As Double = 0
            Dim vr_tot As Double = 0
            Dim iva As Double = objOpSimplesLn.getIvaPorc()
            FrmIngVtas.Show()
            FrmIngVtas.nuevo()
            FrmIngVtas.Estado_guardar = False
            FrmIngVtas.lblNroPedido.Visible = False
            FrmIngVtas.lblUltimoPedido.Text = numero
            FrmIngVtas.txt_nombres.Text = dtg_pend.Item("nombres", e.RowIndex).Value
            FrmIngVtas.txtNit.Text = dtg_pend.Item("Nit", e.RowIndex).Value
            FrmIngVtas.txtRef.Focus()
            FrmIngVtas.cargar_info_client(dtg_pend.Item("Nit", e.RowIndex).Value)
            For i = 0 To dtg_pend.RowCount - 1
                If (dtg_pend.Item("numero", i).Value = numero) Then
                    vec(0) = "Borrar"
                    vec(1) = dtg_pend.Item("codigo", i).Value
                    vec(2) = dtg_pend.Item("descripcion", i).Value
                    vec(3) = dtg_pend.Item("cantidad", i).Value
                    vec(4) = dtg_pend.Item("valor_unitario", i).Value
                    vec(5) = Convert.ToDouble(vec(4) * vec(3))
                    vec(6) = dtg_pend.Item("p_min", i).Value
                    FrmIngVtas.dtgPedido.Rows.Add(vec)
                    FrmIngVtas.txtNotas.Text = dtg_pend.Item("notas", i).Value
                    FrmIngVtas.txt_notas_opc.Text = dtg_pend.Item("notas_aut", i).Value
                    sub_tot += vec(5)
                    'FrmIngVtas.cbo_vendedores.SelectedValue = dtg_pend.Item("vendedor", i).Value
                    FrmIngVtas.txt_vend.Text = dtg_pend.Item("vendedor", i).Value
                    FrmIngVtas.txt_bodega.Text = dtg_pend.Item("bodega", i).Value
                End If
            Next
            vr_iva = sub_tot * iva
            vr_tot = sub_tot + vr_iva
            FrmIngVtas.txtSubtot.Text = Format(sub_tot, "C0")
            FrmIngVtas.txt_vr_iva.Text = Format(vr_iva, "C0")
            FrmIngVtas.txt_tot.Text = Format(vr_tot, "C0")
            FrmIngVtas.numeroActualizar = numero
            ' Me.Close()

        End If

    End Sub


End Class