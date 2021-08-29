Imports entidadNegocios
Imports logicaNegocios
Public Class frm_tiq_manual_rec
    Private objOpSimplesLn As New Op_simpesLn
    Private obj_Ing_prodLn As New Ing_prodLn
    Private Declare Function GetTickCount Lib "kernel32" () As Integer
    Private Sub frm_tiq_manual_rec_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        txt_peso.Text = ""

        'Timer1.Enabled = True
        'SerialPort1.Open()
        Dim dt As New DataTable
        Dim sql As String = "SELECT num,prod_final FROM JB_orden_prod_rec_refs WHERE cod_orden = 1 AND oculto = 0 ORDER BY prod_final"

        dt = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")
        dt.Rows.Add()
        dt.Rows(dt.Rows.Count - 1).Item("num") = 0
        dt.Rows(dt.Rows.Count - 1).Item("prod_final") = "Seleccione"
        cbo_prod_final.DataSource = dt
        cbo_prod_final.ValueMember = "num"
        cbo_prod_final.DisplayMember = "prod_final"
        cbo_prod_final.SelectedValue = 0

        sql = "Select tipo_calidad  from J_tipo_cal_alambre "
        cbo_clase.DataSource = obj_Ing_prodLn.listar_datatable(sql, "PRODUCCION")
        cbo_clase.ValueMember = "tipo_calidad"
        cbo_clase.DisplayMember = "tipo_calidad"
        cbo_clase.Text = "Seleccione"
        cbo_clase.SelectedValue = 0
    End Sub

    Private Sub soloNumero(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If (Char.IsDigit(e.KeyChar) Or e.KeyChar = ".") Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txt_trac_tref_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_trac_tref.KeyPress
        soloNumero(e)
    End Sub

    Private Sub txt_trac_rec_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_trac_rec.KeyPress
        soloNumero(e)
    End Sub

    Private Sub txt_diam_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_diam.KeyPress
        soloNumero(e)
    End Sub

    Private Function validar()
        Dim resp As Boolean = False
        If cbo_prod_final.SelectedValue <> 0 Then
            If cbo_clase.Text <> "" Then
                If txt_colada.Text <> "" Then
                    If txt_diam.Text <> "" Then
                        If txt_trac_rec.Text <> "" Then
                            If txt_trac_tref.Text <> "" Then
                                If txt_peso.Text <> "" Then
                                    If txt_cliente.Text <> "" Then
                                        resp = True
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        End If
        If resp = False Then
            MessageBox.Show("Debe de Digitar todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Return resp
    End Function

    Private Sub btn_imprimir_Click(sender As Object, e As EventArgs) Handles btn_imprimir.Click
        If validar() Then
            guardar()
        End If
    End Sub

    Private Sub limpiar()
        cbo_prod_final.SelectedValue = 0
        txt_diam.Text = ""
    End Sub

    Private Sub guardar()
        Dim sql As String = "select max(id_rollo_rec) from jb_rollos_rec where cod_orden_rec = 1 and id_detalle_rec = 1"
        Dim cons As Integer = obj_Ing_prodLn.consultar_valor(sql, "PRODUCCION") + 1
        Dim peso As Double = Convert.ToDouble(txt_peso.Text)
        Dim tipo As String = ""

        If cbo_prod_final.Text Like "2*" Then
            tipo = "EPPP"
        Else
            tipo = "EPPT"
        End If

        Dim peso_real As Double = peso
        Dim peso_int As Integer = peso

        Dim diferencia As Double = Format(peso_real - peso_int, "#0.0")
        If diferencia < -0.3 Then
            peso_int -= 1
            diferencia = Format(peso_real - peso_int, "#0.0")
        End If
        sql = "insert into JB_rollos_rec (cod_orden_tref,id_detalle_tref,id_rollo_tref,cod_orden_rec,id_detalle_rec,id_rollo_rec,id_prof_final,peso,traccion_tref,traccion_rec,diametro,clase,colada,trans,tipo_trans) values " & _
            "(1,1,1,1,1," & cons & "," & cbo_prod_final.SelectedValue & "," & peso_int & "," & txt_trac_tref.Text & "," & txt_trac_rec.Text & "," & txt_diam.Text & "," & cbo_clase.Text & ",'" & txt_colada.Text & "',1,'" & tipo & "')"
        If objOpSimplesLn.ejecutar(sql, "PRODUCCION") Then
            consultar_datos_impresion(cons)
            limpiar()
        End If
    End Sub
    Private Sub consultar_datos_impresion(ByVal num_rollo As Integer)
        Dim sql As String = "SELECT c.mat_prima,c.prod_final,s.descripcion,p.nombres AS Operario,r.diametro,r.clase,r.colada,r.traccion_tref,r.traccion_rec,r.peso,r.id_rollo_rec,h.nombres AS cliente " & _
                     " FROM JB_rollos_rec r, JB_orden_prod_rec_refs c, JB_orden_prod_rec_detalle d,corsan.dbo.referencias s, corsan.dbo.V_nom_personal_Activo_con_maquila p, CORSAN.dbo.V_nom_personal_Activo_con_maquila h " & _
                     " WHERE (c.prod_final = s.codigo AND r.cod_orden_rec = c.cod_orden AND r.id_prof_final = c.num " & _
                     " AND r.cod_orden_rec = d.cod_orden AND r.id_detalle_rec = d.id_detalle AND d.operario = p.nit AND h.nit = c.cliente) " & _
                     " AND r.cod_orden_rec =1 AND r.id_detalle_rec=1 AND id_rollo_rec=" & num_rollo & " ORDER BY r.id_rollo_rec DESC"
        Dim dt As DataTable = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")
        Dim cliente As String = txt_cliente.Text
        For i = 0 To dt.Rows.Count - 1
            Dim consecutivo_barras As String = "1-1-" & dt.Rows(i).Item("id_rollo_rec")
            Dim destino As String = ""

            If dt.Rows(i).Item("prod_final") Like "2*" Then
                destino = "CLIENTE: Interno"
            Else
                destino = "CLIENTE: Externo"
                If dt.Rows(i).Item("prod_final") <> "33R100142" Or dt.Rows(i).Item("prod_final") <> "33R100142P" Then
                    destino = dt.Rows(i).Item("cliente")
                End If
            End If
            Dim prod_f As String = dt.Rows(i).Item("prod_final")
            imprimirTiquete(dt.Rows(i).Item("descripcion"), dt.Rows(i).Item("Operario"), dt.Rows(i).Item("prod_final"), dt.Rows(i).Item("clase"), dt.Rows(i).Item("diametro"), dt.Rows(i).Item("mat_prima"), dt.Rows(i).Item("colada"), dt.Rows(i).Item("traccion_tref"), dt.Rows(i).Item("traccion_rec"), dt.Rows(i).Item("peso"), Now, consecutivo_barras, cliente)
            Dim retraso As Integer
            retraso = 1800 + GetTickCount
            While retraso >= GetTickCount
                Application.DoEvents()
            End While

            imprimirTiquete(dt.Rows(i).Item("descripcion"), dt.Rows(i).Item("Operario"), dt.Rows(i).Item("prod_final"), dt.Rows(i).Item("clase"), dt.Rows(i).Item("diametro"), dt.Rows(i).Item("mat_prima"), dt.Rows(i).Item("colada"), dt.Rows(i).Item("traccion_tref"), dt.Rows(i).Item("traccion_rec"), dt.Rows(i).Item("peso"), Now, consecutivo_barras, cliente)
            Dim retrasos As Integer
            retrasos = 1800 + GetTickCount
            While retrasos >= GetTickCount
                Application.DoEvents()
            End While
        Next
    End Sub
    Private Sub imprimirTiquete(ByVal nomb_pf As String, ByVal operario As String, ByVal prod_f As String, ByVal clase As String, ByVal diametro As String, ByVal materia_p As String,
                            ByVal colada As String, ByVal traccion As Integer, ByVal traccionr As Integer, ByVal pesoref As Double, ByVal fecha As Date, ByVal consecutivo_barras As String, ByVal destino As String)
        Dim proc As New Process
        modificarPlantilla(nomb_pf, operario, prod_f, clase, diametro, materia_p, colada, traccion, traccionr, pesoref, fecha, consecutivo_barras, destino)
        proc.StartInfo.FileName = Environment.CurrentDirectory & "\plantillaRecocidoImp.txt"
        proc.StartInfo.Verb = "Print"
        proc.StartInfo.CreateNoWindow = False
        proc.Start()
    End Sub

    Private Sub modificarPlantilla(ByVal nomb_pf As String, ByVal operario As String, ByVal prod_f As String, ByVal clase As String, ByVal diametro As String, ByVal materia_p As String,
                                   ByVal colada As String, ByVal traccion As Integer, ByVal traccionr As Integer, ByVal pesoref As Double, ByVal fecha As Date, ByVal consecutivo_barras As String, ByVal destino As String)
        Dim fic As String
        Dim nuevoFic As String
        fic = Environment.CurrentDirectory & "\plantillaRecocido.txt"
        nuevoFic = Environment.CurrentDirectory & "\plantillaRecocidoImp.txt"
        Dim pesoimp As Double = Format(pesoref, "#0.0")
        Dim sw As New System.IO.StreamWriter(nuevoFic)
        Dim texto As String
        Dim sr As New System.IO.StreamReader(fic)
        texto = sr.ReadToEnd()
        texto = Replace(texto, "@alambre", nomb_pf)
        texto = Replace(texto, "@operario", operario)
        texto = Replace(texto, "@ref", prod_f)
        texto = Replace(texto, "@clase", clase)
        texto = Replace(texto, "@diametro", diametro & "(mm)")
        texto = Replace(texto, "@mp", materia_p)
        texto = Replace(texto, "@colada", colada)
        texto = Replace(texto, "@traccionb", traccion)
        texto = Replace(texto, "@traccionr", traccionr)
        texto = Replace(texto, "@peso", pesoimp & "(Kg)")
        texto = Replace(texto, "@fecha", fecha)
        texto = Replace(texto, "@ordenr", consecutivo_barras)
        texto = Replace(texto, "@destino", destino)
        texto = Replace(texto, "@barras", consecutivo_barras)
        sr.Close()
        sw.WriteLine(texto)
        sw.Close()
    End Sub

End Class