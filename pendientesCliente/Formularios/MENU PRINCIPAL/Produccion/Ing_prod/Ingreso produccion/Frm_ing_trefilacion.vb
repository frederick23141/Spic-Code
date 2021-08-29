Imports System.Configuration
Imports logicaNegocios
Imports System.IO
Imports Microsoft.Office.Interop
#Disable Warning BC40056 ' El espacio de nombres o el tipo especificado en el 'System.Data.SqlServerCe' Imports no contienen ningún miembro público o no se encuentran. Asegúrese de que el espacio de nombres o el tipo se hayan definido y de que contengan al menos un miembro público. Asegúrese de que el nombre del elemento importado no use ningún alias.
Imports System.Data.SqlServerCe
#Enable Warning BC40056 ' El espacio de nombres o el tipo especificado en el 'System.Data.SqlServerCe' Imports no contienen ningún miembro público o no se encuentran. Asegúrese de que el espacio de nombres o el tipo se hayan definido y de que contengan al menos un miembro público. Asegúrese de que el nombre del elemento importado no use ningún alias.
Public Class Frm_ing_trefilacion

    Private obj_Ing_prodLn As New Ing_prodLn
    Dim h_prog As Integer = 0
    Dim carga_comp As Boolean = False
    Private objOpSimplesLn As New Op_simpesLn
    Private nom_modulo As String
    Public Sub Main(ByVal nom_modulo As String, ByVal permiso As String)
        Me.nom_modulo = nom_modulo
        If (permiso <> "ADMIN") Then
            btnContCambios.Visible = False
        End If
    End Sub
    Private Sub btnContCambios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnContCambios.Click
        FrmAuditCambios.Show()
        FrmAuditCambios.Main(nom_modulo)
        FrmAuditCambios.WindowState = 2
    End Sub
    Public Sub limpiar()
        cbo_operario.Text = "Seleccione"
        txt_h_trab.Text = ""
        txt_alambron.Text = ""
        txt_reproceso.Text = ""
        Dtg_paro.Refresh()
        Chart1.Series.Clear()
        txt_efic.Text = ""
        txt_diametro.Text = ""
        'txt_kil_esperado.Text = ""
        txt_kil_prod.Text = ""
        txt_horometro.Text = ""
        txt_t_sin_just.Text = ""
        For i = 0 To Dtg_paro.Rows.Count - 1
            Dtg_paro.Item("Tiempo", i).Value = 0
        Next
    End Sub
    Private Sub guardar()
        Dim resp As Integer = 0
        Dim fecha As String = cbo_fecha.Value.Date
        Dim operario As Double = cbo_operario.SelectedValue
        Dim maquina As Double = cbo_maquina.SelectedValue
        Dim turno As Integer = cbo_turno.SelectedValue
        Dim h_trab As Double = txt_h_trab.Text
        Dim diametro As Double = txt_diametro.Text
        Dim t_sin_just As Double = Convert.ToInt32(txt_t_sin_just.Text)
        Dim k_esperado As Double = txt_kil_esperado.Text
        Dim alambron As Double = 0
        Dim reproceso As Double = 0
        Dim destino As Int16 = cbo_destino.SelectedValue
        If (txt_alambron.Text <> "") Then
            alambron = txt_alambron.Text
        End If
        If (txt_reproceso.Text <> "") Then
            reproceso = txt_reproceso.Text
        End If
        Dim sql As String = "INSERT INTO J_prod_trefilacion " & _
                                "(fecha, nit, maquina, turno, horas_prog, horas_trab, diametro, alambron, reproceso,kil_esperado,t_sin_just,cod_destino, paro0,paro1, paro2, paro3, paro4, paro5, paro6, paro7, paro8, paro9, paro10, paro11) " & _
                                        "VALUES('" & fecha & "'," & operario & " , " & maquina & "," & turno & "," & h_prog & ", " & h_trab & " ,  " & diametro & " ,  " & alambron & " ,  " & reproceso & "," & k_esperado & "," & t_sin_just & " ," & destino & ", "
        sql = add_paros(sql)
        resp = obj_Ing_prodLn.ejecutar(sql, "PRODUCCION")
        If (resp > 0) Then
            MessageBox.Show("Su planilla fue ingresada en forma exitosa! ", "Correcto!", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Error al ingresar la planilla a la base de datos,verifique que todos los datos esten correctos ò comuniquese con el administrador del sistema! ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Private Sub Frm_ing_trefilacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim sql As String = "select Codigo,Descripcion from J_turnos  "
        Dim dt As DataTable
        Dim col As New DataColumn
        cbo_fecha.Value = Now.AddDays(-1)
        cbo_turno.DataSource = obj_Ing_prodLn.listar_datatable(sql, "PRODUCCION")
        cbo_turno.ValueMember = "Codigo"
        cbo_turno.DisplayMember = "Descripcion"
        cbo_turno.Text = "Seleccione"

        sql = "Select nit,nombres  from V_nom_personal_Activo_con_maquila WHERE centro = 2100 ORDER BY nombres "
        cbo_operario.DataSource = obj_Ing_prodLn.listar_datatable(sql, "CORSAN")
        cbo_operario.ValueMember = "nit"
        cbo_operario.DisplayMember = "nombres"
        cbo_operario.Text = "Seleccione"

        sql = "select  codigoM,nombre   from j_Maquinas where TipoMaquina = 1 AND activa = 1 "
        cbo_maquina.DataSource = obj_Ing_prodLn.listar_datatable(sql, "PRODUCCION")
        cbo_maquina.ValueMember = "codigoM"
        cbo_maquina.DisplayMember = "nombre"
        cbo_maquina.Text = "Seleccione"

        sql = "SELECT id_paro,descripcion  FROM J_tipo_paro "
        dt = obj_Ing_prodLn.listar_datatable(sql, "PRODUCCION")
        col.ColumnName = "Tiempo"
        dt.Columns.Add(col)
        Dtg_paro.DataSource = dt
        txt_horometro.Text = ""
        Dtg_paro.Columns("id_paro").ReadOnly = True
        Dtg_paro.Columns("descripcion").ReadOnly = True

        sql = "SELECT codigo,descripcion  FROM J_destino_tref "
        cbo_destino.DataSource = obj_Ing_prodLn.listar_datatable(sql, "PRODUCCION")
        cbo_destino.ValueMember = "codigo"
        cbo_destino.DisplayMember = "descripcion"
        cbo_destino.Text = "Seleccione"

        carga_comp = True
    End Sub

    Private Function sumar_campo(ByVal text As String) As Double
        Dim total As Double
        Dim val As String = ""
        Dim sw As Boolean = False
        If Not text = "" Then

            For i = 0 To text.Length - 1
                If (text(i) = "+") Then
                    If (sw = False) Then
                        total = Convert.ToDouble(val)
                    Else
                        total += Convert.ToDouble(val)
                    End If
                    val = ""
                    sw = True
                Else
                    val &= text(i)
                End If
            Next
            total += Convert.ToDouble(val)
        End If
        Return total
    End Function
    Private Function restar_txtbox(ByVal text As String) As Double
        Dim total As Double
        Dim val As String = ""
        Dim sw As Boolean = False
        Dim restar As Boolean = False
        For i = 0 To text.Length - 1
            If (text(i) = "-") Then
                restar = True
            End If
        Next
        If restar Then
            If Not text = "" Then
                For i = 0 To text.Length - 1
                    If (text(i) = "-") Then
                        If (sw = False) Then
                            total = Convert.ToDouble(val)
                        Else
                            total -= Convert.ToDouble(val)
                        End If
                        val = ""
                        sw = True
                    Else
                        val &= text(i)
                    End If
                Next
                If (val = "") Then
                    val = 0
                End If
                total -= Convert.ToDouble(val)
            End If
        Else
            total = text
        End If
        Return total
    End Function

    Private Sub btn_sum_reproceso_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_sum_reproceso.Click
        txt_reproceso.Text = sumar_campo(txt_reproceso.Text)
        Dtg_paro.Focus()
    End Sub

    Private Sub btn_limp_rep_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        txt_reproceso.Text = ""
    End Sub

    Private Sub txt_reproceso_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_reproceso.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            If Not (e.KeyChar = Microsoft.VisualBasic.ChrW(43)) Then
                e.Handled = True
            End If
        End If
        If (e.KeyChar = Microsoft.VisualBasic.ChrW(13)) Then
            btn_sum_reproceso.PerformClick()
        End If

    End Sub
    Private Sub txt_alambron_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_alambron.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            If Not (e.KeyChar = Microsoft.VisualBasic.ChrW(43)) Then
                e.Handled = True
            End If
        End If
        If (e.KeyChar = Microsoft.VisualBasic.ChrW(13)) Then
            btn_sum_alamb.PerformClick()
        End If

    End Sub
    Private Sub txt_h_prog_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
        If (e.KeyChar = Microsoft.VisualBasic.ChrW(13)) Then
            txt_h_trab.Focus()
        End If

    End Sub
    Private Sub txt_h_trab_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_h_trab.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            If Not (e.KeyChar = Microsoft.VisualBasic.ChrW(45) Or e.KeyChar = Microsoft.VisualBasic.ChrW(46)) Then
                e.Handled = True
            End If
        End If
        If (e.KeyChar = Microsoft.VisualBasic.ChrW(13)) Then
            btn_rest_h_trab.PerformClick()
            txt_diametro.Focus()
        End If
    End Sub
    Private Sub txt_diametro_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_diametro.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            If Not (e.KeyChar = Microsoft.VisualBasic.ChrW(46)) Then
                e.Handled = True
            End If
        End If
        If (e.KeyChar = Microsoft.VisualBasic.ChrW(13)) Then
            txt_alambron.Focus()
        End If
    End Sub
    Private Sub PrincipalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FrmPrincipal.Show()
        Me.Close()
        FrmPrincipal.Activate()
    End Sub

    Private Sub SalirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FrmLogin.Show()
        FrmPrincipal.Close()
        FrmLogin.Activate()
        Me.Close()
    End Sub
    Public Function sumar_col_grid(ByVal dtg As DataGridView, ByVal col As String) As Double
        Dim suma As Double = 0
        For i = 0 To dtg.RowCount - 1
            If Not IsDBNull(dtg.Item(col, i).Value) Then
                If (dtg.Item(col, i).Value <> "") Then
                    suma = suma + dtg.Item(col, i).Value
                End If
            End If
        Next
        Return suma
    End Function
    Public Function add_paros(ByVal sql As String) As String
        Dim paro0 As Integer = 0
        Dim paro1 As Integer = 0
        Dim paro2 As Integer = 0
        Dim paro3 As Integer = 0
        Dim paro4 As Integer = 0
        Dim paro5 As Integer = 0
        Dim paro6 As Integer = 0
        Dim paro7 As Integer = 0
        Dim paro8 As Integer = 0
        Dim paro9 As Integer = 0
        Dim paro10 As Integer = 0
        Dim paro11 As Integer = 0
        For i = 0 To Dtg_paro.RowCount - 1
            Select Case Dtg_paro.Item("id_paro", i).Value
                Case 0
                    If Not IsDBNull(Dtg_paro.Item("Tiempo", i).Value) Then
                        If (Dtg_paro.Item("Tiempo", i).Value <> "") Then
                            paro0 = Dtg_paro.Item("Tiempo", i).Value
                        End If
                    End If
                Case 1
                    If Not IsDBNull(Dtg_paro.Item("Tiempo", i).Value) Then
                        If (Dtg_paro.Item("Tiempo", i).Value <> "") Then
                            paro1 = Dtg_paro.Item("Tiempo", i).Value
                        End If
                    End If
                Case 2
                    If Not IsDBNull(Dtg_paro.Item("Tiempo", i).Value) Then
                        If (Dtg_paro.Item("Tiempo", i).Value <> "") Then
                            paro2 = Dtg_paro.Item("Tiempo", i).Value
                        End If
                    End If
                Case 3
                    If Not IsDBNull(Dtg_paro.Item("Tiempo", i).Value) Then
                        If (Dtg_paro.Item("Tiempo", i).Value <> "") Then
                            paro3 = Dtg_paro.Item("Tiempo", i).Value
                        End If
                    End If
                Case 4
                    If Not IsDBNull(Dtg_paro.Item("Tiempo", i).Value) Then
                        If (Dtg_paro.Item("Tiempo", i).Value <> "") Then
                            paro4 = Dtg_paro.Item("Tiempo", i).Value
                        End If
                    End If
                Case 5
                    If Not IsDBNull(Dtg_paro.Item("Tiempo", i).Value) Then
                        If (Dtg_paro.Item("Tiempo", i).Value <> "") Then
                            paro5 = Dtg_paro.Item("Tiempo", i).Value
                        End If
                    End If
                Case 6
                    If Not IsDBNull(Dtg_paro.Item("Tiempo", i).Value) Then
                        If (Dtg_paro.Item("Tiempo", i).Value <> "") Then
                            paro6 = Dtg_paro.Item("Tiempo", i).Value
                        End If
                    End If
                Case 7
                    If Not IsDBNull(Dtg_paro.Item("Tiempo", i).Value) Then
                        If (Dtg_paro.Item("Tiempo", i).Value <> "") Then
                            paro7 = Dtg_paro.Item("Tiempo", i).Value
                        End If
                    End If
                Case 8
                    If Not IsDBNull(Dtg_paro.Item("Tiempo", i).Value) Then
                        If (Dtg_paro.Item("Tiempo", i).Value <> "") Then
                            paro8 = Dtg_paro.Item("Tiempo", i).Value
                        End If
                    End If
                Case 9
                    If Not IsDBNull(Dtg_paro.Item("Tiempo", i).Value) Then
                        If (Dtg_paro.Item("Tiempo", i).Value <> "") Then
                            paro9 = Dtg_paro.Item("Tiempo", i).Value
                        End If
                    End If
                Case 10
                    If Not IsDBNull(Dtg_paro.Item("Tiempo", i).Value) Then
                        If (Dtg_paro.Item("Tiempo", i).Value <> "") Then
                            paro10 = Dtg_paro.Item("Tiempo", i).Value
                        End If
                    End If
                Case 11
                    If Not IsDBNull(Dtg_paro.Item("Tiempo", i).Value) Then
                        If (Dtg_paro.Item("Tiempo", i).Value <> "") Then
                            paro11 = Dtg_paro.Item("Tiempo", i).Value
                        End If
                    End If

            End Select
        Next
        sql += paro0 & " , " & paro1 & " , " & paro2 & " , " & paro3 & " , " & paro4 & " , " & paro5 & " , " & paro6 & " , " & paro7 & " , " & paro8 & " , " & paro9 & " , " & paro10 & " , " & paro11 & ")"
        Return sql
    End Function
    Public Function tiempo_tipo_paro(ByVal vec() As Object) As Object()

        For i = 0 To Dtg_paro.RowCount - 1
            Select Case Dtg_paro.Item("id_paro", i).Value
                Case 0
                    vec(22) = Dtg_paro.Item("Tiempo", i).Value
                Case 1
                    vec(11) = Dtg_paro.Item("Tiempo", i).Value
                Case 2
                    vec(12) = Dtg_paro.Item("Tiempo", i).Value
                Case 3
                    vec(13) = Dtg_paro.Item("Tiempo", i).Value
                Case 4
                    vec(14) = Dtg_paro.Item("Tiempo", i).Value
                Case 5
                    vec(15) = Dtg_paro.Item("Tiempo", i).Value
                Case 6
                    vec(16) = Dtg_paro.Item("Tiempo", i).Value
                Case 7
                    vec(17) = Dtg_paro.Item("Tiempo", i).Value
                Case 8
                    vec(18) = Dtg_paro.Item("Tiempo", i).Value
                Case 9
                    vec(19) = Dtg_paro.Item("Tiempo", i).Value
                Case 10
                    vec(20) = Dtg_paro.Item("Tiempo", i).Value
                Case 11
                    vec(21) = Dtg_paro.Item("Tiempo", i).Value

            End Select
        Next
        Return vec
    End Function
    Private Sub cbo_operario_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_operario.SelectedIndexChanged
        If (carga_comp) Then
            txt_t_sin_just.Text = "0"
            Dim fec As String = objOpSimplesLn.cambiarFormatoFecha(cbo_fecha.Value.Date)
            Dim sql As String = "Select SUM (horas_trab ) from J_prod_trefilacion WHERE nit = " & cbo_operario.SelectedValue & " and Fecha = '" & fec & "'"
            If (txt_h_trab.Text <> "") Then
                txt_horometro.Text = ((obj_Ing_prodLn.consultar_valor(sql, "PRODUCCION"))) + Convert.ToDouble(txt_h_trab.Text)
            Else
                txt_horometro.Text = (obj_Ing_prodLn.consultar_valor(sql, "PRODUCCION"))
            End If
            If (h_prog <> 0 And txt_horometro.Text <> "") Then
                tSinJust()
            End If
        End If

    End Sub
    Private Sub cbo_operario_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbo_operario.KeyPress
        e.Handled = True
    End Sub
    Private Sub cbo_fecha_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbo_fecha.KeyPress
        e.Handled = True
    End Sub
    Private Sub cbo_maquina_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbo_maquina.KeyPress
        e.Handled = True
    End Sub
    Private Sub cbo_tipo_paro_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.Handled = True
    End Sub
    Private Sub cbo_turno_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbo_turno.KeyPress
        e.Handled = True
    End Sub

    Private Sub btn_sum_alamb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_sum_alamb.Click
        txt_alambron.Text = sumar_campo(txt_alambron.Text)
        txt_reproceso.Focus()
    End Sub

    Private Sub cbo_maquina_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_maquina.SelectedIndexChanged
        If (carga_comp) Then
            If (cbo_turno.Text <> "Seleccione" And txt_diametro.Text <> "") Then
                Dim sql As String = "SELECT  vel_actual  FROM  J_Maquinas WHERE codigoM  = " & Convert.ToDouble(cbo_maquina.SelectedValue) & ""
                Dim velocidad As Double = obj_Ing_prodLn.consultar_valor(sql, "PRODUCCION")
                Dim diametro As Double = Convert.ToDouble(txt_diametro.Text)
                txt_kil_esperado.Text = Format((((velocidad * (diametro ^ 2)) * 22.2) * h_prog), "N1")
                If (txt_kil_prod.Text <> "" And txt_kil_esperado.Text <> "") Then
                    txt_efic.Text = Format((txt_kil_prod.Text / txt_kil_esperado.Text) * 100, "N1")
                End If
            End If
        End If
    End Sub
    Private Sub txt_kil_prod_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_kil_prod.TextChanged
        If (txt_kil_esperado.Text <> "" And txt_kil_prod.Text <> "") Then
            txt_efic.Text = Format((txt_kil_prod.Text / txt_kil_esperado.Text) * 100, "N1")
            cargar_charlt(txt_kil_esperado.Text, "Kg esperado", txt_kil_prod.Text, "Kg producidos")
        End If
    End Sub

    Private Sub txt_h_trab_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_h_trab.TextChanged
        Dim sw As Boolean = False
        Dim caracter As String = ""
        Dim h_trab As Double = 0
        Dim fec As String = objOpSimplesLn.cambiarFormatoFecha(cbo_fecha.Value.Date)
        Dim texto As String = txt_h_trab.Text
        For i = 0 To texto.Length - 1
            If Not (IsNumeric(texto(i))) Then
                If Not (texto(i) = ".") Then
                    sw = True
                End If
            End If
        Next
        If (txt_h_trab.Text = "") Then
            h_trab = 0
        ElseIf (sw = False) Then
            h_trab = txt_h_trab.Text
            If (h_trab > 12) Then
                txt_h_trab.BackColor = Color.Red
            Else
                txt_h_trab.BackColor = Color.White
            End If
        End If
        If (sw = False) Then
            If (IsNumeric(txt_h_trab.Text) Or h_trab = 0) Then

                Dim sql As String = "Select SUM ( horas_trab ) from [J_prod_trefilacion] WHERE nit = " & cbo_operario.SelectedValue & " and Fecha = '" & fec & "'"
                txt_horometro.Text = ((obj_Ing_prodLn.consultar_valor(sql, "PRODUCCION"))) + Convert.ToDouble(h_trab)
                If (cbo_turno.Text <> "Seleccione") Then
                    tSinJust()
                End If
            Else
                txt_horometro.Text = ""
            End If
        End If


    End Sub

    Private Sub txt_diametro_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_diametro.TextChanged
        If IsNumeric(txt_diametro.Text) Then
            If (cbo_maquina.Text <> "Seleccione") Then
                Dim sql As String = "SELECT  vel_actual  FROM  J_Maquinas WHERE codigoM  = " & Convert.ToDouble(cbo_maquina.SelectedValue) & ""
                Dim velocidad As Double = obj_Ing_prodLn.consultar_valor(sql, "PRODUCCION")
                Dim diametro As Double = Convert.ToDouble(txt_diametro.Text)
                txt_kil_esperado.Text = Format((((velocidad * (diametro ^ 2)) * 22.2) * h_prog), "N1")
            End If
        End If
    End Sub
    Private Sub txt_alambron_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_alambron.TextChanged
        Dim sw As Boolean = False
        Dim caracter As String = ""
        Dim texto As String = txt_alambron.Text
        For i = 0 To texto.Length - 1
            If Not IsNumeric(texto(i)) Then
                sw = True
            End If
        Next
        If (txt_alambron.Text <> "") Then
            If (sw = False) Then
                Dim kil_prod As Double = 0
                If (txt_reproceso.Text <> "") Then
                    kil_prod = Convert.ToDouble(txt_alambron.Text) + Convert.ToDouble(txt_reproceso.Text)
                Else
                    kil_prod = Convert.ToDouble(txt_alambron.Text)
                End If
                txt_kil_prod.Text = kil_prod
            End If
        End If



    End Sub

    Private Sub txt_reproceso_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_reproceso.TextChanged
        Dim sw As Boolean = False
        Dim caracter As String = ""
        Dim texto As String = txt_reproceso.Text
        If (texto <> "") Then
            For i = 0 To texto.Length - 1
                If Not IsNumeric(texto(i)) Then
                    sw = True
                End If
            Next
            If sw = False Then
                Dim kil_prod As Double = 0
                If (txt_alambron.Text <> "") Then
                    kil_prod = Convert.ToDouble(txt_alambron.Text) + Convert.ToDouble(txt_reproceso.Text)
                Else
                    kil_prod = Convert.ToDouble(txt_reproceso.Text)
                End If
                txt_kil_prod.Text = kil_prod
            End If
        End If

    End Sub

    Private Sub Dtg_paro_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dtg_paro.CellContentClick
        'If (e.ColumnIndex = 0 And e.RowIndex <> -1) Then
        '    If (cbo_turno.Text <> "Seleccione" And txt_h_trab.Text <> "") Then
        '        Dim paros As Double = Format(sumar_col_grid(Dtg_paro, "Tiempo"), "N1")
        '        txt_t_sin_just.Text = Format((h_prog * 60) - (txt_horometro.Text * 60) - paros - paros_ant(), "N0")
        '    End If
        '    Dtg_paro.Rows.RemoveAt(e.RowIndex)
        'End If

    End Sub


    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        limpiar()
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If (cbo_maquina.Text <> "Seleccione" And cbo_operario.Text <> "Seleccione" And cbo_turno.Text <> "Seleccione" And txt_h_trab.Text <> "" And txt_diametro.Text <> "" And cbo_destino.Text <> "Seleccione") Then
            guardar()
            limpiar()
        Else
            MessageBox.Show("Verifique que todos los items del pedido estem llenos! ", "Campos", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btnNuevo_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        limpiar()
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        FrmPrincipal.Show()
        Me.Close()
        FrmPrincipal.Activate()
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        FrmLogin.Show()
        FrmPrincipal.Close()
        Me.Close()
    End Sub
    Private Sub chk_todos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_todos.CheckedChanged
        If (chk_todos.Checked = True) Then
            Dim sql As String = "Select nit,nombres   from V_nom_personal_Activo_con_maquila WHERE centro not in (4200) ORDER BY nombres "
            cbo_operario.DataSource = obj_Ing_prodLn.listar_datatable(sql, "CORSAN")
            cbo_operario.ValueMember = "nit"
            cbo_operario.DisplayMember = "nombres"
            cbo_operario.Text = "Seleccione"
        Else
            Dim sql As String = "Select nit,nombres  from V_nom_personal_Activo_con_maquila WHERE centro = 2100 ORDER BY nombres"
            cbo_operario.DataSource = obj_Ing_prodLn.listar_datatable(sql, "CORSAN")
            cbo_operario.ValueMember = "nit"
            cbo_operario.DisplayMember = "nombres"
            cbo_operario.Text = "Seleccione"
        End If
    End Sub
    Public Sub cargar_charlt(ByVal val1 As Double, ByVal nomb1 As String, ByVal val2 As Double, ByVal nomb2 As String)
        Chart1.Titles.Clear()
        Chart1.Series.Clear()
        Chart1.ChartAreas.Clear()
        Chart1.ChartAreas.Add(0)
        Chart1.Series.Add(nomb1)
        Chart1.Series.Add(nomb2)
        Chart1.Series(nomb1).Points.AddXY(0, val1)
        Chart1.Series(nomb2).Points.AddXY(0, val2)
        Chart1.Series(nomb1).MarkerColor = Color.Red
        Chart1.Titles.Add(nomb1 & " - " & nomb2)
        Chart1.Refresh()
        'Chart1.ChartAreas(0).Area3DStyle.Enable3D = True
        'Chart1.ChartAreas(0).Area3DStyle.Rotation = 20
        'Chart1.ChartAreas(0).Area3DStyle.PointDepth = 75
        'Chart1.ChartAreas(0).Area3DStyle.PointGapDepth = 35
    End Sub

    Private Sub txt_kil_esperado_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_kil_esperado.TextChanged
        If (txt_kil_prod.Text <> "" And txt_kil_esperado.Text <> "") Then
            cargar_charlt(txt_kil_esperado.Text, "Kg esperado", txt_kil_prod.Text, "Kg producidos")
        End If
    End Sub

    Private Sub btn_rest_h_trab_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_rest_h_trab.Click
        txt_h_trab.Text = restar_txtbox(txt_h_trab.Text)
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Frm_consultar_tref.Show()
    End Sub

    Private Sub cbo_turno_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_turno.SelectedIndexChanged
        If (carga_comp) Then
            Dim horas As String = ""
            Dim texto As String = cbo_turno.Text
            For i = 0 To texto.Length - 1
                If IsNumeric(texto(i)) Then
                    horas += texto(i)
                End If
            Next
            h_prog = Convert.ToInt16(horas)
            If (cbo_maquina.Text <> "Seleccione" And txt_diametro.Text <> "") Then
                Dim sql As String = "SELECT  vel_actual  FROM  J_Maquinas WHERE codigoM  = " & Convert.ToDouble(cbo_maquina.SelectedValue) & ""
                Dim velocidad As Double = obj_Ing_prodLn.consultar_valor(sql, "PRODUCCION")
                Dim diametro As Double = Convert.ToDouble(txt_diametro.Text)
                txt_kil_esperado.Text = Format((((velocidad * (diametro ^ 2)) * 22.2) * h_prog), "N0")
                If (txt_kil_prod.Text <> "" And txt_kil_esperado.Text <> "") Then
                    txt_efic.Text = Format((txt_kil_prod.Text / txt_kil_esperado.Text) * 100, "N1")
                End If
            End If
            If (txt_horometro.Text <> "") Then
                tSinJust()
            End If
        End If

    End Sub
    Private Function paros_ant() As Double
        Dim tiem_ant As Double = 0
        Dim nit As Double = cbo_operario.SelectedValue
        Dim fec As String = objOpSimplesLn.cambiarFormatoFecha(cbo_fecha.Value.Date)
        Dim sql As String = "SELECT SUM (paro0 )+SUM (paro1 )+SUM (paro2 )+SUM (paro3 )+SUM (paro4 )+SUM (paro5 )+SUM (paro6 )+SUM (paro7 )+ " & _
                                    "SUM(paro8) + SUM(paro9) + SUM(paro10) + SUM(paro11) " & _
                                            "FROM J_prod_trefilacion " & _
                                                 "WHERE nit = " & nit & " AND fecha = '" & fec & "'"
        tiem_ant = obj_Ing_prodLn.consultar_valor(sql, "PRODUCCION")
        Return tiem_ant
    End Function

    Private Sub Dtg_paro_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dtg_paro.CellValueChanged
        If (e.ColumnIndex = 2 And carga_comp) Then
            Dim texto As String = Dtg_paro.Item(e.ColumnIndex, e.RowIndex).Value
            Dim valor As String = ""
            For i = 0 To texto.Length - 1
                If (IsNumeric(texto(i)) Or texto(i) = "+") Then
                    valor += texto(i)
                End If
            Next
            valor = sumar_campo(valor)
            Dtg_paro.Item(e.ColumnIndex, e.RowIndex).Value = valor
            If (h_prog <> 0 And txt_horometro.Text <> "") Then
                tSinJust()
            End If

        End If
    End Sub
    Private Sub txt_horometro_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_horometro.TextChanged
        If (IsNumeric(txt_horometro.Text)) Then
            If (txt_horometro.Text > 12) Then
                txt_horometro.BackColor = Color.Red
            Else
                txt_horometro.BackColor = Color.Gainsboro
            End If
        End If
    End Sub
    Private Sub txt_efic_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_efic.TextChanged
        If (IsNumeric(txt_horometro.Text)) Then
            If (txt_efic.Text <> "") Then
                If (txt_efic.Text > 100) Then
                    txt_efic.BackColor = Color.Red
                Else
                    txt_efic.BackColor = Color.White
                End If
            End If

        End If
    End Sub
    Private Sub tSinJust()
        Dim paros As Double = sumar_col_grid(Dtg_paro, "Tiempo")
        txt_t_sin_just.Text = Format((h_prog * 60) - (txt_horometro.Text * 60) - paros - paros_ant() - 20, "N0")
    End Sub

End Class