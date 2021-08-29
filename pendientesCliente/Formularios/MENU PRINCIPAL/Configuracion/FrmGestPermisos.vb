Imports logicaNegocios


Public Class FrmGestPermisos
    Private objOpSimplesLn As New Op_simpesLn
    Private permiso As String = ""
    Private moduloArbol As String
    Public Sub main(ByVal arbol As TreeView)
        ' Me.arbolModulos = arbol
    End Sub

    Private Sub FrmGestPermisos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim sql As String = "SELECT descripcion  FROM J_spic_permiso "
        cargarLista(listaTipoUsu, sql)
    End Sub
    Private Sub cargarLista(ByVal lista As ListBox, ByVal sql As String)
        lista.Items.Clear()
        Dim list As New List(Of Object)
        list = objOpSimplesLn.lista(sql)
        For i = 0 To list.Count - 1
            lista.Items.Add(list(i))
        Next
    End Sub

    Private Sub listPermisosUsuario_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles listaTipoUsu.SelectedIndexChanged
        permiso = listaTipoUsu.SelectedItem
        Dim sql As String = "SELECT modulo FROM J_spic_per_mod   WHERE permiso = '" & permiso & "' "
        cargarLista(listPermisosUsuario, sql)
    End Sub
   
    Private Sub btnAddmodulo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddmodulo.Click
        addModulo()
    End Sub

    Private Sub btnQuitarMod_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuitarMod.Click
        Dim modulo As String = listPermisosUsuario.SelectedItem
        Dim indexMod As Integer = 0
        Dim resp As Integer = 0
        Dim sql As String = ""
        If (modulo <> "" And permiso <> "") Then
            resp = MessageBox.Show("Esta seguro de quitar este permiso? ", "Quitar", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
            If (resp = 6) Then
                sql = "DELETE FROM J_spic_per_mod WHERE modulo ='" & modulo & "' AND permiso = '" & permiso & "'"
                If (objOpSimplesLn.ejecutar(sql, "CORSAN") > 0) Then
                    indexMod = listPermisosUsuario.SelectedIndex
                    listPermisosUsuario.Items.Remove(listPermisosUsuario.Items(indexMod))
                Else
                    MsgBox("Error al eliminar")
                End If
            End If
        Else
            MsgBox("Seleccione permiso y módulo a eliminar")
        End If
    End Sub
    Private Sub addModulo()
        If (permiso <> "") Then
            Dim sql As String = "INSERT INTO J_spic_per_mod (modulo,permiso) VALUES ('" & moduloArbol & "','" & permiso & "')"
            If (objOpSimplesLn.consultarVal("SELECT modulo FROM J_spic_per_mod WHERE modulo = '" & moduloArbol & "' AND permiso = '" & permiso & "'") <> "") Then
                MessageBox.Show("El módulo ya fue asignado para este permiso")
            ElseIf (objOpSimplesLn.ejecutar(sql, "CORSAN")) Then
                listPermisosUsuario.Items.Add(moduloArbol)
            Else
                MsgBox("Error al otorgar el permiso")
            End If
        Else
            MessageBox.Show("Seleccione tipo de permiso para asignar funcionalidad", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
    Private Sub TreeView1_AfterSelect_1(sender As Object, e As TreeViewEventArgs) Handles TreeView1.AfterSelect
        moduloArbol = e.Node.Name
    End Sub
End Class