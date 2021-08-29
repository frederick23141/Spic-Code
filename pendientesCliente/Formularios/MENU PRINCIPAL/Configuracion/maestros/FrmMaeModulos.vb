Imports logicaNegocios

Public Class FrmMaeGestMod
    Private objOpSimplesLn As New Op_simpesLn
    Private objIngProdLn As New Ing_prodLn
    Dim dt As New DataTable
    Dim tabla As String = ""
    Dim basedatos As String = ""
    Dim listColumnas As List(Of String)

    Public Sub main(ByVal tabla As String, ByVal nombForm As String, ByVal basedatos As String, ByVal listColumnas As List(Of String))
        Me.tabla = tabla
        Me.basedatos = basedatos
        Me.listColumnas = listColumnas
        Me.Text = "Maestro " & nombForm
        cargarConsulta()
    End Sub
    Private Sub cargarConsulta()
        Dim columnas As String = ""
        For i = 0 To listColumnas.Count - 1
            columnas = columnas & listColumnas(i)
            If Not (i = listColumnas.Count - 1) Then
                columnas = columnas & ","
            End If
        Next
        Dim sql As String = "SELECT " & columnas & " FROM " & tabla & ""
        dt = objOpSimplesLn.crearDataTableVariasCol(sql, basedatos)
        dt.Rows.Add()
        dtgMaestro.DataSource = dt
    End Sub

    Private Sub dtgMaestro_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgMaestro.CellContentClick
        If (e.RowIndex >= 0) Then
            Dim numCol As Integer = e.ColumnIndex
            Dim nombCol As String = dtgMaestro.Columns(numCol).Name
            Dim fila As Integer = e.RowIndex
            Dim listValores As New List(Of String)
            For i = 0 To listColumnas.Count - 1
                listValores.Add(dtgMaestro.Item(listColumnas(i), fila).Value.ToString)
            Next
            If (nombCol = "btnNew" Or nombCol = "btnSave" Or nombCol = "btnDelete") Then
                Select Case nombCol
                    Case "btnNew"
                        nuevo()
                    Case "btnSave"
                        save(listValores)
                    Case "btnDelete"
                        delete(listValores)
                End Select
            End If
        End If
    End Sub
    Private Sub save(ByVal listValores As List(Of String))
        Dim selectExiste As String = ""
        Dim columnas As String = ""
        Dim valores As String = ""
        Dim sql As String
        For i = 0 To listColumnas.Count - 1
            columnas = columnas & listColumnas(i)
            If Not (i = listColumnas.Count - 1) Then
                columnas = columnas & ","
            End If
        Next
        For i = 0 To listValores.Count - 1
            valores += "'" & listValores(i).Trim & "'"
            If Not (i = listValores.Count - 1) Then
                valores = valores & ","
            End If
        Next
        sql = "INSERT INTO " & tabla & " (" & columnas & ") VALUES (" & valores & ")"
        selectExiste = "SELECT * FROM " & tabla & "  WHERE " & listColumnas(0) & " ='" & listValores(0) & "'"
        If (objIngProdLn.consultValor(selectExiste, basedatos) = "") Then
            sql = "INSERT INTO " & tabla & " (" & columnas & ") VALUES (" & valores & ")"
        Else
            sql = modificar(listValores)
        End If
        If (objOpSimplesLn.ejecutar(sql, basedatos) > 0) Then
            MessageBox.Show("El registro se ingreso en forma correcta!", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Error al ingresar el registro,comuniquese con el administrador del sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Private Sub nuevo()
        dt.Rows.Add()
        dtgMaestro.DataSource = dt
    End Sub
    Private Function modificar(ByVal listValores As List(Of String)) As String
        Dim sql As String = "UPDATE " & tabla
        Dim setSql As String = " SET "
        Dim whereSql As String = " WHERE " & listColumnas(0) & " = '" & listValores(0) & "'"
        For i = 1 To listColumnas.Count - 1
            setSql += listColumnas(i) & " = '" & listValores(i) & "'"
            If (i <> listColumnas.Count - 1) Then
                setSql += ","
            End If
        Next
        sql += setSql & whereSql

        Return sql
    End Function
    Private Sub delete(ByVal listValores As List(Of String))
        Dim sql As String = "DELETE FROM " & tabla & " WHERE " & listColumnas(0) & " = '" & listValores(0) & "'"
        If (objOpSimplesLn.ejecutar(sql, basedatos) > 0) Then
            MessageBox.Show("El registro se elimino en forma correcta!", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cargarConsulta()
        Else
            MessageBox.Show("Error al eliminar el registro,comuniquese con el administrador del sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
End Class