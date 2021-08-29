Imports logicaNegocios
Imports Microsoft.VisualBasic.PowerPacks.Printing.Compatibility.VB6
Public Class Frm_formato_stiker
    Private objOpSimplsLn As New Op_simpesLn
    Dim carga_comp As Boolean = False
    Private Sub Frm_formato_stiker_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        carga_comp = True
    End Sub
    Private Sub txt_nombres_TextChanged(sender As System.Object, e As System.EventArgs) Handles txt_nombres.TextChanged
        If (txt_nombres.Text.Length > 3) Then
            carga_comp = False
            txtNit.Text = ""
            cargar_clientes()
            carga_comp = True
        End If
    End Sub
    Private Sub txtNit_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtNit.TextChanged
        If (txtNit.Text.Length > 3) Then
            carga_comp = False
            txt_nombres.Text = ""
            cargar_clientes()
            carga_comp = True
        End If
    End Sub
    Private Sub cargar_clientes()
        Dim sql As String = "Select nit,nombres,ciudad FROM terceros "
        Dim whereSql As String = "WHERE (concepto_1 like '%3%' or concepto_1 like '%4%' or concepto_1 like '%9%' or  concepto_1 like '%1%') "
        If (txtNit.Text <> "") Then
            whereSql &= "AND nit like '%" & txtNit.Text & "%'"
        ElseIf (txt_nombres.Text <> "") Then
            whereSql &= "AND nombres like '%" & txt_nombres.Text & "%'"
        End If
        sql &= whereSql
        dtg_clientes.DataSource = objOpSimplsLn.listar_datatable(sql, "CORSAN")
    End Sub
    Private Sub dtg_clientes_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtg_clientes.CellContentClick
        If (e.RowIndex >= 0) Then
            If (dtg_clientes.Columns(e.ColumnIndex).Name = colOk.Name) Then
                txtNit.Text = dtg_clientes.Item("nit", e.RowIndex).Value
                dtg_clientes.DataSource = Nothing
                nuevo()
                cargar_info_client()
            End If
        End If
    End Sub
    Private Sub cargar_info_client()
        Dim sql As String = "SELECT  nombres,ciudad,direccion FROM terceros WHERE nit =" & txtNit.Text
        Dim dt As DataTable = objOpSimplsLn.listar_datatable(sql, "CORSAN")
        Dim cont_nombres As Integer = 0
        Dim nombre_completo As String = ""
        For i = 0 To dt.Rows.Count - 1
            If Not IsDBNull(dt.Rows(i).Item("nombres")) Then
                nombre_completo = dt.Rows(i).Item("nombres")
                For j = 0 To nombre_completo.Length - 1
                    If (nombre_completo(j) = " ") Then
                        cont_nombres += 1
                    End If
                    If (cont_nombres > 2) Then
                        txtApEtiq.Text &= nombre_completo(j)
                    Else
                        txtNomEtiq.Text &= nombre_completo(j)
                    End If
                Next
            End If
            If Not IsDBNull(dt.Rows(i).Item("ciudad")) Then
                txtCiudadEtiq.Text = dt.Rows(i).Item("ciudad")
            End If
            If Not IsDBNull(dt.Rows(i).Item("direccion")) Then
                txtDirEtiq.Text = dt.Rows(i).Item("direccion")
            End If
        Next
    End Sub

    Private Sub btnImprimir_Click(sender As System.Object, e As System.EventArgs) Handles btnImprimir.Click
        Dim num_copias As String = InputBox("Ingrese cantidad de copias", "Cantidad")
        If IsNumeric(num_copias) Then
            imprimir(num_copias)
        Else
            MessageBox.Show("El valor ingresado debe ser númerico!", "Ingrese un valor númerico!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub imprimir(ByVal num_copias As Integer)
        Dim proc As New Process
        modificarPlantilla()
        For i = 1 To num_copias
            proc.StartInfo.FileName = Environment.CurrentDirectory & "\plantStikerImp.txt"
            proc.StartInfo.Verb = "Print"
            proc.StartInfo.CreateNoWindow = False
            proc.Start()
        Next

    End Sub
    Private Sub modificarPlantilla()
        Dim fic As String = Environment.CurrentDirectory & "\plantStiker.txt"
        Dim nuevoFic As String = Environment.CurrentDirectory & "\plantStikerImp.txt"
        Dim sw As New System.IO.StreamWriter(nuevoFic)
        Dim texto As String
        Dim sr As New System.IO.StreamReader(fic)

        Dim nombre As String = codigoLEtraEspecial(txtNomEtiq.Text)
        Dim apellido As String = codigoLEtraEspecial(txtApEtiq.Text)
        Dim ciudad As String = codigoLEtraEspecial(txtCiudadEtiq.Text)
        Dim direccion As String = codigoLEtraEspecial(txtDirEtiq.Text)
        Dim desc_dir As String = codigoLEtraEspecial(txtIndicEtiq.Text)

        texto = sr.ReadToEnd()
        texto = Replace(texto, "@nombres", nombre)
        texto = Replace(texto, "@apellidos", apellido)
        texto = Replace(texto, "@ciudad", ciudad)
        texto = Replace(texto, "@direccion", direccion)
        texto = Replace(texto, "@desc_dir", desc_dir)


        sr.Close()
        sw.WriteLine(texto)
        sw.Close()

    End Sub
    Private Function codigoLEtraEspecial(ByVal texto As String) As String
        Dim resp As String = ""
        For i = 0 To texto.Length - 1
            If (texto(i) = "ñ" Or texto(i) = "Ñ") Then
                resp &= "\A5"
            Else
                resp &= texto(i)
            End If
        Next
        Return resp
    End Function
    Private Sub nuevo()
        txtNomEtiq.Text = ""
        txtApEtiq.Text = ""
        txtCiudadEtiq.Text = ""
        txtDirEtiq.Text = ""
        txtIndicEtiq.Text = ""
    End Sub




    Private Sub PrintDocument1_PrintPage_1(sender As System.Object, e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim font1 As New Font("Arial", 16, FontStyle.Regular)
        e.Graphics.DrawString("prueba", font1, Brushes.Black, 100, 100)
    End Sub



    
End Class