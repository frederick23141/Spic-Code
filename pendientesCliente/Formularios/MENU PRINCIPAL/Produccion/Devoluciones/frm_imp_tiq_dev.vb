Imports logicaNegocios
Imports entidadNegocios
Public Class frm_imp_tiq_dev
    Private objOpSimplesLn As New Op_simpesLn
    Private obj_Ing_prodLn As New Ing_prodLn
    Dim objTraslado_bodLn As New traslado_bodLn
    Private objOrdenProdLn As New OrdenProdLn

    Dim db_produccion As String = objOpSimplesLn.get_nom_db("PRODUCCION") & ".dbo."
    Dim db_corsan As String = objOpSimplesLn.get_nom_db("CORSAN") & ".dbo."

    Dim numero_transaccion As Double
    Dim nombre_alambre As String = ""
    Private Sub frm_imp_tiq_dev_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargar_cbo()
        limpiar()
    End Sub
    Private Sub cargar_cbo()
        Dim sql As String = "SELECT codigo,(codigo+' ('+ descripcion +')') AS ref FROM v_referencias_sto_hoy WHERE bodega = 3 AND stock > 1 AND (codigo like '33B%' OR codigo like '33X%' OR codigo like '33G%' or codigo like '33R%')"
        Dim dt As DataTable = objOpSimplesLn.listar_datatable(sql, "CORSAN")

        dt.Rows.Add()
        dt.Rows(dt.Rows.Count - 1).Item("codigo") = "H"
        dt.Rows(dt.Rows.Count - 1).Item("ref") = "-- Seleccione Referencia --"
        cbo_ref.DataSource = dt
        cbo_ref.ValueMember = "codigo"
        cbo_ref.DisplayMember = "ref"
        cbo_ref.SelectedValue = "H"

        dt = New DataTable
        sql = "Select tipo_calidad,tipo_calidad as tip  from J_tipo_cal_alambre"
        dt = objOpSimplesLn.listar_datatable(sql, "PRODUCCION")
        dt.Rows.Add()
        dt.Rows(dt.Rows.Count - 1).Item("tipo_calidad") = 0
        dt.Rows(dt.Rows.Count - 1).Item("tip") = 0
        cbo_clase.DataSource = dt
        cbo_clase.ValueMember = "tipo_calidad"
        cbo_clase.DisplayMember = "tip"
        cbo_clase.SelectedValue = 0
    End Sub

    Public Sub recibir_cliente(ByVal doc As Integer, ByVal nombre As String)
        lbl_doc_client.Text = doc
        lbl_nom_cliente.Text = nombre
    End Sub

    Private Sub cbo_ref_SelectedValueChanged(sender As Object, e As EventArgs) Handles cbo_ref.SelectionChangeCommitted
        If cbo_ref.SelectedValue <> "H" Then
            Dim pf As String = "22"
            Dim codigo As String = cbo_ref.SelectedValue
            pf &= codigo(2) & codigo(3) & codigo(4) & codigo(5)
            If cbo_ref.SelectedValue Like "3C*" Or cbo_ref.SelectedValue Like "3G*" Then
                pf = "2" & codigo(1)
            End If
            Dim sql As String = "SELECT codigo,(codigo+' ('+ descripcion +')') AS ref FROM Referencias WHERE  Codigo like '" & pf & "%' AND Ref_anulada = 'N' "
            Dim dt As New DataTable
            dt = objOpSimplesLn.listar_datatable(sql, "CORSAN")
            dt.Rows.Add()
            dt.Rows(dt.Rows.Count - 1).Item("codigo") = "H"
            dt.Rows(dt.Rows.Count - 1).Item("ref") = "-- Seleccione Referencia --"
            cbo_ref_pf.DataSource = dt
            cbo_ref_pf.ValueMember = "codigo"
            cbo_ref_pf.DisplayMember = "ref"
            cbo_ref_pf.SelectedValue = "H"

            cbo_ref_pf.Enabled = True
            If cbo_ref.SelectedValue Like "3C*" Or cbo_ref.SelectedValue Like "3G*" Then
                txt_colada.Text = "N/A"
                txt_colada.Enabled = False
                txt_diametro.Text = 0.0
                txt_diametro.Enabled = False
                cbo_clase.SelectedValue = 0
                cbo_clase.Enabled = False
            Else
                txt_colada.Text = ""
                txt_colada.Enabled = True
                txt_diametro.Text = ""
                txt_diametro.Enabled = True
                cbo_clase.SelectedValue = 0
                cbo_clase.Enabled = True
            End If
        Else
            cbo_ref_pf.SelectedValue = "H"
            cbo_ref_pf.Enabled = False
        End If
    End Sub

    Private Sub soloNumero(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If (Char.IsDigit(e.KeyChar) Or e.KeyChar = "." Or e.KeyChar = "-") Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txt_peso_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_peso.KeyPress
        soloNumero(e)
    End Sub

    Private Sub txt_diametro_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_diametro.KeyPress
        soloNumero(e)
    End Sub

    Private Sub txt_fac_cons_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_fac_cons.KeyPress
        soloNumero(e)
    End Sub
    Private Sub limpiar()
        cbo_ref.SelectedValue = "H"
        cbo_ref_pf.SelectedValue = "H"
        cbo_ref_pf.Enabled = False
        txt_peso.Text = ""
        txt_colada.Text = ""
        txt_diametro.Text = ""
        cbo_clase.SelectedValue = 0
        lbl_doc_client.Text = ""
        lbl_nom_cliente.Text = ""
        txt_razon.Text = ""
        txt_fac_cons.Text = ""
        cargar_cbo()

        txt_colada.Enabled = True
        txt_diametro.Enabled = True
        cbo_clase.Enabled = True
    End Sub

    Private Sub btn_imprimir_Click(sender As Object, e As EventArgs) Handles btn_imprimir.Click
        If validar_campos() Then
            If guardar_rollo() Then
                MessageBox.Show("Rollo Registrado con Exito.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                limpiar()
            End If
        Else
            MessageBox.Show("Debe de Llenar todos los campos.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
    Private Function validar_campos()
        Dim resp As Boolean = False
        If cbo_ref.SelectedValue <> "H" Then
            If cbo_ref_pf.SelectedValue <> "H" Then
                If txt_colada.Text <> "" Then
                    If txt_diametro.Text <> "" Then
                        If txt_fac_cons.Text <> "" Then
                            If txt_peso.Text <> "" Then
                                If txt_razon.Text <> "" Then
                                    If lbl_doc_client.Text <> "" Then
                                        If lbl_nom_cliente.Text <> "" Then
                                            If cbo_ref.SelectedValue Like "33B*" Or cbo_ref.SelectedValue Like "33X*" Or cbo_ref.SelectedValue Like "33R*" Or cbo_ref.SelectedValue Like "33G*" Then
                                                If cbo_clase.SelectedValue <> 0 Then
                                                    resp = True
                                                End If
                                            Else
                                                resp = True
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        End If
        Return resp
    End Function
    Private Function generar_cons()
        Dim cons As String = 0
        Dim mes As Integer = Now.Month
        Dim ano As String = Now.Year
        cons = ano(2) & ano(3)
        If mes < 10 Then
            cons &= 0 & Now.Month
        Else
            cons &= Now.Month
        End If
        Return cons
    End Function
    Private Function validar_cc(ByVal cc As String)
        Dim resp As Boolean = False
        Dim sql As String = "select nombres from V_nom_personal_Activo_con_maquila where nit ='" & cc & "'"
        Dim name As String = objOpSimplesLn.consultValorTodo(sql, "CORSAN")
        If name <> "" Then
            resp = True
        Else
            MessageBox.Show("El documento no a sido encontrado.", "Documento no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Return resp
    End Function
    Private Function transaccion(ByVal datacodigo As DataTable, ByVal tipo As String, ByVal bodega As Integer, ByVal modelo As String, ByVal usuario As Integer) As List(Of Object)
        Dim listSql As New List(Of Object)
        Dim dFec As Date = Now
        Dim notas As String = "SPIC fecha:" & Now & " Usuario:" & usuario
        numero_transaccion = objOrdenProdLn.mover_consecutivo(tipo)
        listSql = objTraslado_bodLn.listaTransaccionDatable(numero_transaccion, datacodigo, bodega, dFec, notas, usuario, tipo, modelo)
        Return listSql
    End Function
    Private Function guardar_rollo()
        Dim resp As Boolean = False
        Dim listSql As New List(Of Object)
        Dim dt1 As New DataTable
        Dim dt2 As New DataTable
        Dim sql As String = ""

        Dim fec_rollo As Integer = Convert.ToInt32(generar_cons)
        sql = "SELECT MAX(num_roll) FROM JB_rollos_devoluciones WHERE fec_roll=" & fec_rollo
        Dim num_roll As Integer = obj_Ing_prodLn.consultar_valor(sql, "PRODUCCION") + 1

        Dim stock As Double = objOpSimplesLn.consultarStock(cbo_ref.SelectedValue, 3)
        Dim peso As Double = Convert.ToDouble(txt_peso.Text)

        Dim SIP As Integer = 0
        Dim EIPP As Integer = 0
        Dim bodega As Integer = 0
        If rdb_bodega2.Checked Then
            bodega = 2
        Else
            bodega = 4
        End If

        Dim cc As String = InputBox("INGRESE SU NUMERO DE DOCUMENTO DE IDENTIDAD.", "Documento de identidad.")
        If cc <> "" Then
            If validar_cc(cc) Then
                If bodega = 2 And cbo_ref_pf.SelectedValue Like "3*" Then
                    MessageBox.Show("En Bodega 2 no se puede ingresar material con codigo 3", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    If peso <= stock Then

                        dt1.Columns.Add("codigo")
                        dt1.Columns.Add("cantidad")
                        dt1.Rows.Add()
                        dt1.Rows(dt1.Rows.Count - 1).Item("codigo") = cbo_ref.SelectedValue
                        dt1.Rows(dt1.Rows.Count - 1).Item("cantidad") = peso

                        dt2.Columns.Add("codigo")
                        dt2.Columns.Add("cantidad")
                        dt2.Rows.Add()
                        dt2.Rows(dt2.Rows.Count - 1).Item("codigo") = cbo_ref_pf.SelectedValue
                        dt2.Rows(dt2.Rows.Count - 1).Item("cantidad") = peso

                        listSql.AddRange(transaccion(dt1, "SIP", 3, "01", cc))
                        SIP = numero_transaccion
                        listSql.AddRange(transaccion(dt2, "EIPP", bodega, "01", cc))
                        EIPP = numero_transaccion

                        sql = "INSERT INTO " & db_produccion & "JB_rollos_devoluciones (fec_roll,num_roll,peso,cod_anterio,nuevo_codigo,sip,eipp,nota,fac_cons,cliente,clase,colada,diametro,bodega) VALUES " & _
                                "(" & fec_rollo & "," & num_roll & "," & peso & ",'" & cbo_ref.SelectedValue & "','" & cbo_ref_pf.SelectedValue & "'," & _
                                SIP & "," & EIPP & ",'" & txt_razon.Text & "(" & cc & ")','" & txt_fac_cons.Text & "'," & lbl_doc_client.Text & "," & cbo_clase.Text & ",'" & _
                                txt_colada.Text & "'," & txt_diametro.Text & "," & bodega & ")"
                        listSql.Add(sql)
                        If obj_Ing_prodLn.ExecuteSqlTransaction(listSql, "CORSAN") Then
                            imprimirTiquete(lbl_nom_cliente.Text, peso, cbo_ref_pf.SelectedValue, cbo_ref.SelectedValue, cbo_clase.SelectedValue, txt_diametro.Text, txt_colada.Text, "DEV-" & fec_rollo & "-" & num_roll)
                            MessageBox.Show("El Rollo se Agrego correctamente, por favor revisar el tiquete. ", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            limpiar()
                        End If
                    Else
                        MessageBox.Show("El peso Ingresado no puede sobrepasar el Stock: " & stock & "kg", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                End If
            End If
        End If
        Return resp
    End Function
    Private Sub imprimirTiquete(ByVal cliente As String, ByVal peso As Integer, ByVal ref As String, ByVal alambre As String,
                                   ByVal clase As Integer, ByVal diametro As Double, ByVal colada As String,
                                   ByVal consecutivo As String)
        Dim proc As New Process
        modificarPlantilla(cliente, peso, ref, alambre, clase, diametro, colada, Now, consecutivo)
        proc.StartInfo.FileName = Environment.CurrentDirectory & "\plantillDevIMP.txt"
        proc.StartInfo.Verb = "Print"
        proc.StartInfo.CreateNoWindow = False
        proc.Start()
    End Sub
    Private Sub modificarPlantilla(ByVal cliente As String, ByVal peso As Integer, ByVal ref As String, ByVal alambre As String,
                                   ByVal clase As Integer, ByVal diametro As Double, ByVal colada As String, ByVal fecha As DateTime,
                                   ByVal consecutivo As String)
        Dim fic As String
        Dim nuevoFic As String
        fic = Environment.CurrentDirectory & "\plantillDev.txt"
        nuevoFic = Environment.CurrentDirectory & "\plantillDevIMP.txt"
        Dim sw As New System.IO.StreamWriter(nuevoFic)
        Dim texto As String
        Dim sr As New System.IO.StreamReader(fic)
        texto = sr.ReadToEnd()
        texto = Replace(texto, "@clie", cliente)
        texto = Replace(texto, "@nombre", nombre_alambre)
        texto = Replace(texto, "@peso", peso & "(kg)")
        texto = Replace(texto, "@ref", ref)
        texto = Replace(texto, "@alambre", alambre)
        texto = Replace(texto, "@clase", clase)
        texto = Replace(texto, "@diam", diametro & "(mm)")
        texto = Replace(texto, "@colada", colada)
        texto = Replace(texto, "@peso", peso & "(Kg)")
        texto = Replace(texto, "@fecha", fecha)
        texto = Replace(texto, "@orden", consecutivo)
        texto = Replace(texto, "@barras", consecutivo)
        sr.Close()
        sw.WriteLine(texto)
        sw.Close()
    End Sub
    Private Sub btn_buscar_Click(sender As Object, e As EventArgs) Handles btn_buscar.Click
        frm_buscar_cliente_dev.main()
    End Sub

    Private Sub cbo_ref_pf_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbo_ref_pf.SelectionChangeCommitted
        If cbo_ref_pf.SelectedValue <> "H" Then
            Dim sql As String = "SELECT descripcion FROM referencias WHERE codigo = '" & cbo_ref_pf.SelectedValue & "'"
            nombre_alambre = objOpSimplesLn.consultValorTodo(sql, "CORSAN")
        End If
    End Sub
End Class