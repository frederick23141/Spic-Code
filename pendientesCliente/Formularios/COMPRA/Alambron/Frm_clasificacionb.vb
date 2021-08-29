Imports logicaNegocios
Imports entidadNegocios
Imports Spic
Imports System.Data.SqlClient
''esta ventana es convocada por la ventana anterior cuando se le da click derecho a un resgistro del datagridview
''y despues cuando se abra el menu le da click en cambiar linea de produccion y se abrira esta ventana, donde podras 
''cambiar la linea de produccion del producto que seleccionaste al dar click derecho
Public Class Frm_clasificacionb
    Private dt As New DataTable
    Dim Da As New SqlDataAdapter
    Dim Cmd As New SqlCommand
    Dim codigop As String
    Private objOpSimplesLn As New Op_simpesLn
    Private Sub practica1b_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar()
    End Sub 'Funcionalidad del boton cambiar
    Private Sub cargar()
        Dim sql As String
        Dim dt As New DataTable
        Dim dr As DataRow
        dt = New DataTable

        sql = "SELECT id_cor,Descripcion FROM JJV_Grupos_seguimiento"
        dt = objOpSimplesLn.listar_datatable(sql, "CORSAN")
        dr = dt.NewRow
        dr("id_cor") = 0
        dr("Descripcion") = "Seleccione"
        dt.Rows.Add(dr)
        cbdescripcion.DataSource = dt
        cbdescripcion.ValueMember = "id_cor"
        cbdescripcion.DisplayMember = "Descripcion"
        cbdescripcion.Text = "Seleccione"
    End Sub
    Private Sub btncambiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncambiar.Click
        Dim result As DialogResult
        Dim sql As String
        result = MessageBox.Show("Realmente desea editar los datos del Producto?", "modificando registro", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
        If result = DialogResult.OK Then
            If cbdescripcion.Text <> "" Then
                sql = "update referencias set id_cor = " & cbdescripcion.SelectedValue & "   where codigo='" & codigop & "'"
                objOpSimplesLn.consultValorTodo(sql, "CORSAN")
                MessageBox.Show("producto modificado correctamente", "Modificando registros", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
            Else
                MessageBox.Show("Falta ingresar algunos datos", "Modificando registros", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Public Function guardarcodigo(ByVal codigo As String)
        codigop = codigo
        Return codigop
    End Function
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancelar.Click
        Me.Close()
    End Sub
End Class