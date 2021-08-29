Imports logicaNegocios


Public Class Frm_permisos_evaluaciones
    Private objOpSimplesLn As New Op_simpesLn
    Private usuario As String = ""
    Private tipo_evaluacion_arbol As String
    Public Sub main(ByVal arbol As TreeView)
        ' Me.arbolModulos = arbol
    End Sub

    Private Sub FrmGestPermisos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim sql As String = "SELECT ( usuario + '-' + nombres ) As usuario FROM Jjv_usuarios "
        cargarLista(listaUsuarios, sql)
        sql = "SELECT (CAST (id AS varchar(25)) + '-' + descripcion )As tipo_evaluacion  FROM J_eval_tipo"
        cargarLista(lista_evaluaciones, sql)
    End Sub
    Private Sub cargarLista(ByVal lista As ListBox, ByVal sql As String)
        lista.Items.Clear()
        Dim list As New List(Of Object)
        list = objOpSimplesLn.lista(sql)
        For i = 0 To list.Count - 1
            lista.Items.Add(list(i))
        Next
    End Sub
    Private Sub listPermisosUsuario_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles listaUsuarios.SelectedIndexChanged
        Dim cadena As String = listaUsuarios.SelectedItem
        usuario = ""
        For i = 0 To cadena.Length - 1
            If (cadena(i) <> "-") Then
                usuario &= cadena(i)
            Else
                i = cadena.Length - 1
            End If
        Next
        Dim sql As String = "SELECT (CAST (t.id AS varchar(25)) + '-' + t.descripcion )As descripcion FROM J_eval_permisos p , J_eval_tipo t WHERE t.id = p.id_tipo_eval AND id_usuario = '" & usuario & "' "
        cargarLista(listPermisosUsuario, sql)
    End Sub

    Private Sub btnAddmodulo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddmodulo.Click
        addModulo()
    End Sub

    Private Sub btnQuitarMod_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuitarMod.Click
        Dim tipo_eval As String = separarIdTipoEval(listPermisosUsuario.SelectedItem)
        Dim indexMod As Integer = 0
        Dim resp As Integer = 0
        Dim sql As String = ""
        If (tipo_eval <> "" And usuario <> "") Then
            resp = MessageBox.Show("Esta seguro de quitar este permiso? ", "Quitar", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
            If (resp = 6) Then
                sql = "DELETE FROM J_eval_permisos WHERE id_tipo_eval ='" & tipo_eval & "' AND id_usuario = '" & usuario & "'"
                If (objOpSimplesLn.ejecutar(sql, "CORSAN") > 0) Then
                    indexMod = listPermisosUsuario.SelectedIndex
                    listPermisosUsuario.Items.Remove(listPermisosUsuario.Items(indexMod))
                Else
                    MsgBox("Error al eliminar")
                End If
            End If
        Else            MsgBox("Seleccione permiso y usuario a eliminar")
        End If
    End Sub
    Private Sub addModulo()
        If (usuario <> "") Then
            Dim sql As String = "INSERT INTO J_eval_permisos (id_tipo_eval,id_usuario) VALUES ('" & tipo_evaluacion_arbol & "','" & usuario & "')"
            If (objOpSimplesLn.consultarVal("SELECT id_permiso FROM J_eval_permisos WHERE id_tipo_eval = '" & tipo_evaluacion_arbol & "' AND id_usuario = '" & usuario & "'") <> "") Then
                MessageBox.Show("Esta evaluación  ya fue asignada para este usuario")
            ElseIf (objOpSimplesLn.ejecutar(sql, "CORSAN")) Then
                listPermisosUsuario.Items.Add(lista_evaluaciones.SelectedItem)
            Else
                MsgBox("Error al otorgar el permiso")
            End If
        Else
            MessageBox.Show("Seleccione tipo de permiso para asignar funcionalidad", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
    'Private Sub TreeView1_NodeMouseDoubleClick_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles TreeView1.MouseClick
    '    addModulo()

    Private Sub lista_evaluaciones_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lista_evaluaciones.SelectedIndexChanged
        Dim cadena As String = lista_evaluaciones.SelectedItem
        tipo_evaluacion_arbol = separarIdTipoEval(cadena)
    End Sub
    Private Function separarIdTipoEval(ByVal cadena As String) As String
        Dim id_tipo_eval As String = ""
        For i = 0 To cadena.Length - 1
            If (cadena(i) <> "-") Then
                id_tipo_eval &= cadena(i)
            Else
                i = cadena.Length - 1
            End If
        Next
        Return id_tipo_eval
    End Function
End Class