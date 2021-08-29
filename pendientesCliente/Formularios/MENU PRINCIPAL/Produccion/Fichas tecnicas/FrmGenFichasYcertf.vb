Imports System.Configuration
Imports logicaNegocios
Imports entidadNegocios
Imports System.IO
Imports Microsoft.Office.Interop
Public Class FrmGenFichasYcertf
    Private objOperacionesForm As OperacionesFormularios = New OperacionesFormularios
    Private objOpSimplesLn As New Op_simpesLn
    Private objIngProdLn As New Ing_prodLn
    Private carga_comp As Boolean = False


    Private Sub FrmClientesRefUltAno_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        carga_comp = True
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

    Private Sub btn_exportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exportar.Click
        objOperacionesForm.ExportarDatosExcel(dtg_consulta, "Anticipos")
    End Sub
    Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
        If (carga_comp) Then
            consultar()
        End If
    End Sub
    Private Sub consultar()
        Dim sql As String = ""
        Dim selectSql As String = "SELECT * FROM  J_v_clientes_alambres_ult_ano "
        Dim whereSql As String
        If txtNit.Text <> "" Or txtNombres.Text <> "" Or txtCodigo.Text <> "" Or txtDescripcion.Text <> "" Then
            whereSql = "WHERE "
        End If
        ' Dim sql As String = "SELECT t.nit,nombres,codigo,descripcion  FROM TERCEROS t , referencias r WHERE t.nit = 890800450 AND r.codigo = '33R100508'"
        If (txtNit.Text <> "") Then
#Disable Warning BC42104 ' La variable 'whereSql' se usa antes de que se le haya asignado un valor. Podría darse una excepción de referencia NULL en tiempo de ejecución.
            whereSql &= "nit like '%" & txtNit.Text & "%' "
#Enable Warning BC42104 ' La variable 'whereSql' se usa antes de que se le haya asignado un valor. Podría darse una excepción de referencia NULL en tiempo de ejecución.
        ElseIf (txtNombres.Text <> "") Then
            whereSql &= "nombres like '%" & txtNombres.Text & "%' "
        ElseIf (txtCodigo.Text <> "") Then
            whereSql &= "codigo like '%" & txtCodigo.Text & "%' "
        ElseIf (txtDescripcion.Text <> "") Then
            whereSql &= "descripcion like '%" & txtDescripcion.Text & "%' "
        End If
        sql = selectSql & whereSql
        dtg_consulta.DataSource = objOpSimplesLn.listar_datatable(sql, "CORSAN")
    End Sub

    Private Sub txtNit_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNit.TextChanged
        carga_comp = False
        If (txtNit.Text.Length > 2) Then
            txtNombres.Text = ""
            txtCodigo.Text = ""
            txtDescripcion.Text = ""
            consultar()
        End If
        carga_comp = True
    End Sub

    Private Sub txtNombres_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNombres.TextChanged
        carga_comp = False
        If (txtNombres.Text.Length > 5) Then
            txtNit.Text = ""
            txtCodigo.Text = ""
            txtDescripcion.Text = ""
            consultar()
        End If
        carga_comp = True
    End Sub


    Private Sub txtCodigo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodigo.TextChanged
        carga_comp = False
        If (txtCodigo.Text.Length > 4) Then
            txtNit.Text = ""
            txtNombres.Text = ""
            txtDescripcion.Text = ""
            consultar()
        End If
        carga_comp = True
    End Sub

    Private Sub txtDescripcion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDescripcion.TextChanged
        carga_comp = False
        If (txtDescripcion.Text.Length > 4) Then
            txtNit.Text = ""
            txtNombres.Text = ""
            txtCodigo.Text = ""
            consultar()
        End If
        carga_comp = True
    End Sub

    Private Sub dtg_consulta_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtg_consulta.CellContentClick
        Dim fila As Integer = e.RowIndex
        Dim col As String = dtg_consulta.Columns(e.ColumnIndex).Name
        Dim codigo As String = ""
        If (fila >= 0) Then
            If (col = "colGenFicha") Then
                'codigo = dtg_consulta.Item("codigo", fila).Value
                'Dim ruta As String = Environment.CurrentDirectory & "\fichas\" & codigo & ".doc"
                'Dim nombCliente As String = dtg_consulta.Item("nombres", fila).Value
                'Dim descripcion As String = dtg_consulta.Item("descripcion", fila).Value
                'modificarArchivoWord(ruta, "@nombre", nombCliente)
                'modificarArchivoWord(ruta, "@descripcion", descripcion)
                '' Process.Start(ruta)
                genCertificado()
            End If
        End If

    End Sub

    Private Sub modificarArchivoWord(ByVal ruta As String, ByVal busqueda As String, ByVal reemplazo As String)
        Const wdReplaceAll = 2
        Dim objWord As Object
        Dim objDoc As Object
        Dim objSelection As Object

        objWord = CreateObject("Word.Application")
        objWord.Visible = False

        objDoc = objWord.Documents.Open(ruta)
        objSelection = objWord.Selection

        objSelection.Find.Text = busqueda
        objSelection.Find.Forward = True
        objSelection.Find.MatchWholeWord = True

        objSelection.Find.Replacement.Text = reemplazo
        objSelection.Find.Execute(, , , , , , , , , , wdReplaceAll)
    End Sub
    Private Sub dtg_consulta_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dtg_consulta.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            With (Me.dtg_consulta)
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                End If
            End With
        End If
    End Sub

    Private Sub btnCertCalidad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCertCalidad.Click
        genCertificado()
    End Sub
    Private Sub genCertificado()
        Dim fila As Integer = dtg_consulta.CurrentCell.RowIndex
        If (fila >= 0) Then
            If (objIngProdLn.existeFichaTecnica(dtg_consulta.Item("codigo", fila).Value)) Then
                Dim nit As String = dtg_consulta.Item("nit", fila).Value
                Dim nombres As String = dtg_consulta.Item("nombres", fila).Value
                Dim codigo As String = dtg_consulta.Item("codigo", fila).Value
                Dim resistencia As String
                Dim procedencia As String
                Dim calidad As String
                Dim rec As String
                If objIngProdLn.existeFichaTecnica_nit(codigo, nit) Then
                    resistencia = objIngProdLn.consultar_valor("SELECT resistencia FROM J_referencia_ficha_tec WHERE codigo = '" & codigo & "' and nit=" & nit & "", "PRODUCCION")
                    procedencia = objIngProdLn.consultar_valor("SELECT procedencia FROM J_referencia_ficha_tec WHERE codigo = '" & codigo & "' and nit=" & nit & "", "PRODUCCION")
                    calidad = objIngProdLn.consultar_valor("SELECT calidad FROM J_referencia_ficha_tec WHERE codigo = '" & codigo & "' and nit=" & nit & "", "PRODUCCION")
                    rec = objIngProdLn.consultar_valor("SELECT recubrimiento FROM J_referencia_ficha_tec WHERE codigo = '" & codigo & "' and nit=" & nit & "", "PRODUCCION")
                Else
                    resistencia = objIngProdLn.consultar_valor("SELECT resistencia FROM J_referencia_ficha_tec WHERE codigo = '" & codigo & "'", "PRODUCCION")
                    procedencia = objIngProdLn.consultar_valor("SELECT procedencia FROM J_referencia_ficha_tec WHERE codigo = '" & codigo & "'", "PRODUCCION")
                    calidad = objIngProdLn.consultar_valor("SELECT calidad FROM J_referencia_ficha_tec WHERE codigo = '" & codigo & "'", "PRODUCCION")
                    rec = objIngProdLn.consultar_valor("SELECT recubrimiento FROM J_referencia_ficha_tec WHERE codigo = '" & codigo & "'", "PRODUCCION")
                End If
                Dim descripcion As String = dtg_consulta.Item("descripcion", fila).Value
                Dim resp As Integer = MessageBox.Show("Desea generar el certificado automatico?", "Certificado automatico", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                If resp = 6 Then
                    FrmFichaPesos.Main(nit, nombres, codigo, descripcion, resistencia, procedencia, calidad, rec)
                    FrmFichaPesos.Show()
                    FrmFichaPesos.Activate()
                Else
                    FrmFichaPesosManual.Main(nit, nombres, codigo, descripcion, resistencia, procedencia, calidad, rec)
                    FrmFichaPesosManual.Show()
                    FrmFichaPesosManual.Activate()
                End If

            Else
                MessageBox.Show("No se encontro ficha técnica para este producto,por lo tanto no se puede generar el certificado,comuniquese con el area de calidad !", "No hay ficha técnica", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

End Class