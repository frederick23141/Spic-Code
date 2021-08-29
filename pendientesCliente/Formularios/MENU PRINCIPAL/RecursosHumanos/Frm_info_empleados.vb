Imports logicaNegocios
Imports entidadNegocios
Imports System.IO

Public Class Frm_info_empleados
    Private objOpSimplesLn As New Op_simpesLn
    Private carga_comp As Boolean = False
    Private objOperacionesForm As OperacionesFormularios = New OperacionesFormularios
    Dim nit As Double
    Dim centros As String = ""
    Dim usuario As New UsuarioEn
    Public Sub MAIN(ByVal nomb_modulo As String, ByVal usuario As UsuarioEn)
        Me.usuario = usuario
        Dim fecha_menos_1_mes As Date = Now.AddMonths(-1)
        Dim dt As New DataTable
        Dim dr As DataRow
        Dim sql As String
        Dim where_sql As String = ""
        If (usuario.permiso.Trim <> "ADMIN" And usuario.permiso.Trim <> "NOMINA") Then
            Dim nit As Double = usuario.nit
            Dim listCentros As DataTable = objOpSimplesLn.listar_datatable("SELECT centro FROM J_coordinador_centros_costos WHERE nit =" & nit, "PRODUCCION")
            For i = 0 To listCentros.Rows.Count - 1
                centros &= listCentros.Rows(i).Item("centro")
                If (i <> listCentros.Rows.Count - 1) Then
                    centros &= ","
                End If
            Next
        End If
        If centros = "" Then
            centros = "1200,2100,2117,2200,2300,2400,2500,2600,2800,3100,3200,4100,4300,3500,5200,6200,6400"
        End If

        where_sql &= "WHERE centro IN(" & centros & ")"
        sql = "SELECT centro,( CAST (centro AS varchar(25))+ '-' + descripcion )As descripcion " & _
                        "FROM centros " & _
                            where_sql
        dt = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        dr = dt.NewRow
        dr("centro") = 0
        dr("descripcion") = "TODO"
        dt.Rows.Add(dr)
        cbo_centro.DataSource = dt
        cbo_centro.ValueMember = "centro"
        cbo_centro.DisplayMember = "descripcion"
        cbo_centro.SelectedValue = 0
        carga_comp = True
    End Sub
    Private Sub btn_actualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_actualizar.Click
        cargarConsulta()
    End Sub

    Private Sub cargarConsulta()
        Dim sql As String = ""
        Dim selectSql As String = "SELECT centro,nit,nombres,mail,telefono_1,telefono_2,ciudad,direccion ,fecha_nacimiento,fecha_ingreso ,celular,cargo   " & _
             "FROM V_nom_personal_Activo_con_maquila "
        Dim whereSql As String = ""
        Dim where_centro As String = ""
        Dim where_operario As String = ""
        Dim where_turno As String = ""
        If cbo_centro.SelectedValue <> 0 Then
            where_centro = " WHERE centro =" & cbo_centro.SelectedValue
        Else
            If (txtNit.Text <> "") Then
                whereSql = " WHERE nit like '" & txtNit.Text & "%'"
            ElseIf (txtNombres.Text <> "") Then
                whereSql = " WHERE nombres like '%" & txtNombres.Text & "%'"
            End If
            If whereSql = "" Then
                If (usuario.permiso.Trim = "ADMIN" Or usuario.permiso.Trim = "NOMINA") Or usuario.permiso.Trim = "SALUD_OCUPACIONAL" Then
                    where_centro = " WHERE centro  IN(" & centros & ") or centro is null"
                Else
                    where_centro = " WHERE centro  IN(" & centros & ") "
                End If

            Else
                where_centro = " AND  centro IN(" & centros & ") "
            End If

        End If
 
        sql = selectSql & whereSql & where_centro
        dtgConsulta.DataSource = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        dtgConsulta.Columns("fecha_nacimiento").DefaultCellStyle.Format = "d"
        dtgConsulta.Columns("fecha_ingreso").DefaultCellStyle.Format = "d"
    End Sub

    Private Sub txtNit_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNit.TextChanged
        If (carga_comp And (txtNit.Text.Length > 1 Or txtNit.Text.Length = 0)) Then
            carga_comp = False
            txtNombres.Text = ""
            cargarConsulta()
            carga_comp = True
        End If
    End Sub

    Private Sub txtNombres_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNombres.TextChanged
        If (carga_comp And (txtNombres.Text.Length > 2 Or txtNombres.Text.Length = 0)) Then
            carga_comp = False
            txtNit.Text = ""
            cargarConsulta()
            carga_comp = True
        End If
    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        FrmLogin.Show()
        FrmPrincipal.Close()
        Me.Close()
    End Sub

    Private Sub btn_ppal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ppal.Click
        FrmPrincipal.Show()
        Me.Close()
    End Sub

    Private Sub btnExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportar.Click
        objOperacionesForm.ExportarDatosExcel(dtgConsulta, "Información de empleados activos")
    End Sub

    Private Sub dtgConsulta_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgConsulta.CellClick
        If dtgConsulta.Columns(e.ColumnIndex).Name = btn_select_imagen.Name Then
            nit = dtgConsulta.Item("nit", e.RowIndex).Value
            OpenFileDialog1.ShowDialog()
        ElseIf dtgConsulta.Columns(e.ColumnIndex).Name = btn_ver_foto.Name Then
            Frm_ver_foto.Show()
            Frm_ver_foto.Text = dtgConsulta.Item("nombres", e.RowIndex).Value
            Frm_ver_foto.MAIN(dtgConsulta.Item("nit", e.RowIndex).Value)
        End If
    End Sub
    Private Sub guardar_img(ByVal ruta As String, ByVal nit As Double)
        PictureBox1.Image = System.Drawing.Image.FromFile(ruta)
        Dim arrFilename() As String = Split(Text, "\")
        Array.Reverse(arrFilename)
        Dim ms As New MemoryStream
        PictureBox1.Image.Save(ms, PictureBox1.Image.RawFormat)
        Dim arrImage() As Byte = ms.GetBuffer
        If objOpSimplesLn.guardar_imagen(arrImage, nit) Then
            MessageBox.Show("La  foto se guardo en forma correcta", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Error al guardar", "verifique", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    'Sub cargarImagen()
    '    Try
    '        Me.OpenFileDialog1.ShowDialog()
    '        If Me.OpenFileDialog1.FileName <> "" Then
    '            Dim imagen As String = ""
    '            imagen = OpenFileDialog1.FileName
    '            Dim largo As Integer = imagen.Length
    '            Dim imagen2 As String
    '            imagen2 = CStr(Microsoft.VisualBasic.Mid(RTrim(imagen), largo - 2, largo))
    '            If imagen2 <> "gif" And imagen2 <> "bmp" And imagen2 <> "jpg" And imagen2 <> "jpeg" And imagen2 <> "GIF" And imagen2 <> "BMP" And imagen2 <> "JPG" And imagen2 <> "JPEG" Then
    '                imagen2 = CStr(Microsoft.VisualBasic.Mid(RTrim(imagen), largo - 3, largo))
    '                If imagen2 <> "jpeg" And imagen2 <> "JPEG" And imagen2 <> "log1" Then
    '                    MsgBox("Formato no valido") : Exit Sub
    '                    If imagen2 <> "log1" Then Exit Sub
    '                End If

    '            End If
    '        End If
    '    Catch ex As Exception

    '    End Try
    '    PictureBox1.Load(imagen)
    'End Sub
    'Private Sub guardar_imagen()
    '    Dim nombre As String = InputBox("Digite el nombre de la imagen que desea Alamacenar")
    '    Dim myImg As Image 'Objeto Image para guardar la imagen del Picture 
    '    myImg = PictureBox1.Image 'Guardar la imagen del PictureBox en el objeto Image
    '    MsgBox(insertarImagen(nombre, bytesToString(ImagenToBytes(myImg))))
    '    cbListaFotos.Items.Clear()
    '    listaImagenes(cbListaFotos)
    '    PictureBox1.Image = Nothing
    'End Sub

    Private Sub OpenFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk
        Dim ruta As String = OpenFileDialog1.FileName
        guardar_img(ruta, nit)
    End Sub

    Private Sub cbo_centro_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbo_centro.SelectedIndexChanged
        If carga_comp Then
            cargarConsulta()
        End If
    End Sub

End Class