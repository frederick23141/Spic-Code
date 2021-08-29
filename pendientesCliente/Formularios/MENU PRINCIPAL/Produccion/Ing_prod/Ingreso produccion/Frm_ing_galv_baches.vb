
Imports System.Configuration
Imports logicaNegocios
Imports System.IO
Imports Microsoft.Office.Interop
#Disable Warning BC40056 ' El espacio de nombres o el tipo especificado en el 'System.Data.SqlServerCe' Imports no contienen ningún miembro público o no se encuentran. Asegúrese de que el espacio de nombres o el tipo se hayan definido y de que contengan al menos un miembro público. Asegúrese de que el nombre del elemento importado no use ningún alias.
Imports System.Data.SqlServerCe
#Enable Warning BC40056 ' El espacio de nombres o el tipo especificado en el 'System.Data.SqlServerCe' Imports no contienen ningún miembro público o no se encuentran. Asegúrese de que el espacio de nombres o el tipo se hayan definido y de que contengan al menos un miembro público. Asegúrese de que el nombre del elemento importado no use ningún alias.
Public Class FRM_ing_galv_baches
    Private obj_Ing_prodLn As New Ing_prodLn
    Private obj_Gal As New Galv_bachesLn
    Private obj_Sum As New Op_simpesLn
    Private objOperacionesForm As New OperacionesFormularios
    Public sec As String
    Dim carga_completa As Boolean = False
    Dim lista As New List(Of Object)
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
    Public Sub LlenarInicial(ByVal Id_Seccion As String, ByVal Nombre As String)
        Me.Text = Nombre
        Dim sql As String
        Dim Año As String
        Dim Mes As String
        Año = DateTime.Now().Year
        Mes = DateTime.Now().Month

        'Llena los combos iniciales
        Try

            sql = "SELECT Codigo, Nombre FROM Medidas WHERE Codigo IN (SELECT Medida FROM MedidasMaquina WHERE Maquina = '" & Id_Seccion & "') ORDER BY Codigo"
            cboGrupo.DataSource = obj_Ing_prodLn.listar_datatable(sql, "PRODUCCION")
            cboGrupo.ValueMember = "Codigo"
            cboGrupo.DisplayMember = "Nombre"
            cboGrupo.Text = "Seleccione"
            sql = "select nit,Nombres from V_nom_personal_Activo_con_maquila WHERE centro IN (2800,6200) ORDER BY  nombres"
            cboOperario.DataSource = obj_Ing_prodLn.listar_datatable(sql, "CORSAN")
            cboOperario.ValueMember = "nit"
            cboOperario.DisplayMember = "Nombres"
            cboOperario.Text = "Seleccione"
            sql = "SELECT Codigo,Descripcion FROM turnos"
            cboTurno.DataSource = obj_Ing_prodLn.listar_datatable(sql, "PRODUCCION")
            cboTurno.ValueMember = "Codigo"
            cboTurno.DisplayMember = "Descripcion"
            cboTurno.Text = "Seleccione"


            'Llena los label iniciales 
            sql = "SELECT LimiteInferior FROM Maquinas WHERE Codigo = '" & Id_Seccion & "'"
            lblLimInf.Text = obj_Ing_prodLn.consultar_valor(sql, "PRODUCCION")
            sql = "SELECT LimiteSuperior FROM Maquinas WHERE Codigo = '" & Id_Seccion & "'"
            lblLimSup.Text = obj_Ing_prodLn.consultar_valor(sql, "PRODUCCION")
            sql = "SELECT SUM(Cantidad) AS Canti FROM [Seguimiento tornillos] WHERE Maquina = '" & Id_Seccion & "' AND YEAR(Fecha) =  '" & Año & "' AND MONTH(Fecha) = '" & Mes & "'"
            lblProdSeccion.Text = obj_Ing_prodLn.consultar_valor(sql, "PRODUCCION")
            sql = "SELECT SUM(Paros) AS Total FROM [Seguimiento tornillos] WHERE Maquina = '" & Id_Seccion & "' AND YEAR(Fecha) = '" & Año & "' AND Month(Fecha) ='" & Mes & "' "
            lblParosAcum.Text = obj_Ing_prodLn.consultar_valor(sql, "PRODUCCION")
            sql = "SELECT SUM(TiempoProductivo) AS Canti FROM [Seguimiento tornillos] WHERE Maquina = '" & Id_Seccion & "' AND YEAR(Fecha) = '" & Año & "' AND  MONTH(Fecha) = '" & Mes & "'"
            lblTiempoPro.Text = obj_Ing_prodLn.consultar_valor(sql, "PRODUCCION")
            If (Id_Seccion = "139" Or Id_Seccion = "140" Or Id_Seccion = "141" Or Id_Seccion = "175") Then
                lblNom.Text = "Leva"
                cboLeva.Text = "Seleccione"
                cboLeva.Items.Add("Leva 4")
                cboLeva.Items.Add("Leva 6")
                cboLeva.Items.Add("Leva 8")
                cboLeva.Items.Add("Leva 10")
            ElseIf (Id_Seccion = "155" Or Id_Seccion = "156" Or Id_Seccion = "157" Or Id_Seccion = "182" Or Id_Seccion = "213" Or Id_Seccion = "214") Then
                lblNom.Text = "Carga"
                txtTotalParos.Visible = True
                Label25.Visible = True
                'se crea el table para llenar el combobox de carga o leva manualmente , estos valores son siempre los mismos
                Dim dt As DataTable = New DataTable("Tabla")
                dt.Columns.Add("Codigo")
                dt.Columns.Add("Descripcion")
                Dim dr As DataRow
                dr = dt.NewRow()
                dr("Codigo") = "0"
                dr("Descripcion") = "Seleccione"
                dt.Rows.Add(dr)
                dr = dt.NewRow()
                dr("Codigo") = "1"
                dr("Descripcion") = "Carga 6"
                dt.Rows.Add(dr)
                dr = dt.NewRow()
                dr("Codigo") = "42"
                dr("Descripcion") = "Carga 7"
                dt.Rows.Add(dr)
                dr = dt.NewRow()
                dr("Codigo") = "72"
                dr("Descripcion") = "Carga 15"
                dt.Rows.Add(dr)
                dr = dt.NewRow()
                dr("Codigo") = "80"
                dr("Descripcion") = "Carga 20"
                dt.Rows.Add(dr)
                cboLeva.DataSource = dt
                cboLeva.ValueMember = "Codigo"
                cboLeva.DisplayMember = "Descripcion"
            Else
                cboLeva.Visible = False
            End If
            sec = Id_Seccion
            carga_completa = True

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub Limpiar()
        dtFechaActual.Text = Date.Today
        cboGrupo.Text = "Seleccione"
        cboLeva.Text = "Seleccione"
        cboOperario.Text = "Seleccione"
        cboTurno.Text = "Seleccione"
        txtKilos.Text = ""
        txtTotalParos.Text = ""
        txtTotalProd.Text = ""
        lblProdGrupo.Text = "0"
        lblParosAcum.Text = "0"
        lblTiempoPro.Text = "0"
    End Sub

    Private Sub guardar()
        Try
            If (cboOperario.Text <> "Seleccione" And cboTurno.Text <> "Seleccione" And cboGrupo.Text <> "Seleccione" And txtKilos.Text <> "") Then
                Dim ObtenerKilosStandar As Integer
                Dim dHoras As Integer
                Dim sql As String
                Dim KilosStan As Integer = cboLeva.SelectedValue
                Dim id_Gal As Integer = Convert.ToInt32(obj_Gal.CrearId())
                Dim Fecha As String = obj_Sum.cambiarFormatoFecha(dtFechaActual.Value.Date)
                Dim Hora As String = "__:__"
                Dim Operario As Integer = cboOperario.SelectedValue
                Dim Turno As Integer = cboTurno.SelectedValue
                Dim Maquina As Integer = sec
                Dim Medida As Integer = cboGrupo.SelectedValue
                Dim Cantidad As Integer = Convert.ToInt32(txtKilos.Text)
                If (Cantidad < 0) Then
                    MessageBox.Show("Error No Puede Ingresar Una Cantidad Negativa! ", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    'si el operario selecciono una opicion del combobox carga o leva entonces
                    If (KilosStan <> 0) Then
                        sql = "SELECT Horas FROM Turnos WHERE Codigo = '" & Turno & "'"
                        dHoras = obj_Ing_prodLn.consultar_valor(sql, "PRODUCCION")
                        ObtenerKilosStandar = KilosStan * (((dHoras * 60) - Val(txtTotalParos.Text)) / 60)
                    End If
                    Dim LimiteInf As Integer = Convert.ToInt32(lblLimInf.Text)
                    Dim LimiteSup As Integer = Convert.ToInt32(lblLimSup.Text)
                    Dim Paros As Integer = Convert.ToInt32(lblParosAcum.Text)
                    Dim HorasTrabajadas As Integer = obj_Ing_prodLn.consultar_valor("select Horas from Turnos where Codigo ='" & Turno & "'", "PRODUCCION")
                    Dim sqlPri = "INSERT INTO [Seguimiento tornillos] " & _
                                 "([Id],[Fecha],[Hora],[Operario],[Turno],[Maquina],[Medida],[Cantidad],[LimiteInferior],[LimiteSuperior],[Paros],[ConsumoAlambron],[HorasTrabajadas],[KilosStandar],[NroTamboreadas],[TiempoProductivo])" & _
                                  "VALUES(" & id_Gal & ",'" & Fecha & "','" & Hora & "'," & Operario & "," & Turno & "," & Maquina & "," & Medida & "," & Cantidad & "," & LimiteInf & "," & LimiteSup & "," & Paros & ",''," & HorasTrabajadas & ","
                    'si no selecciono nada en el combo carga o leva se le añade a la intruccion sql el valor de nulo
                    If (KilosStan = 0) Then
                        sqlPri += "null,null,null)"
                    Else
                        sqlPri += ObtenerKilosStandar & ",null,null)"
                    End If
                    If (obj_Gal.Ejecutar(sqlPri, "PRODUCCION")) Then
                        MessageBox.Show("Grabado Exitosamente! ", "Correcto!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Dim vec(10) As Object
                        vec(1) = id_Gal
                        vec(2) = Fecha
                        vec(3) = Operario
                        vec(4) = cboTurno.Text
                        vec(5) = sec
                        vec(6) = cboGrupo.Text
                        vec(7) = Cantidad
                        vec(8) = HorasTrabajadas
                        vec(9) = ObtenerKilosStandar
                        dtgVer.Rows.Add(vec)
                    Else
                        MessageBox.Show("Error Al Grabar Consulte Con El Administrador! ", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If
            Else
                MsgBox("Falta Campos Por Llenar Por Favor Revise Nuevamente")
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cboGrupo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboGrupo.SelectedIndexChanged
        Dim sql As String
        Dim Año As String
        Dim Mes As String
        Año = DateTime.Now().Year
        Mes = DateTime.Now().Month
        Dim medida As String

        Try
            If (carga_completa) Then
                GroupBox2.Text = cboGrupo.Text
                If (sec = "180" Or sec = "181" Or sec = "213") Then
                    medida = cboGrupo.SelectedValue
                    sql = "SELECT SUM(Cantidad) AS Canti FROM [Seguimiento tornillos] WHERE Maquina =  '" & sec & "'  AND Medida =  '" & medida & "' AND YEAR(Fecha) =  '" & Año & "'  AND MONTH(Fecha) = '" & Mes & "'"
                    lblProdGrupo.Text = obj_Ing_prodLn.consultar_valor(sql, "PRODUCCION")
                Else
                    lblProdGrupo.Text = "0"
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        guardar()
    End Sub

    Private Sub dtgVer_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgVer.CellContentClick
        Dim id As String
        Dim fila As Integer = e.RowIndex
        Dim col As String = dtgVer.Columns(e.ColumnIndex).Name
        Dim sql As String
        Try
            If (col = "btnEliminar") Then
                id = dtgVer.Item("Id", e.RowIndex).Value()
                sql = "DELETE FROM [Seguimiento tornillos] " & _
                             "WHERE Id = " & id & ""
                If (obj_Gal.Ejecutar(sql, "PRODUCCION")) Then
                    MessageBox.Show("Eliminado Exitosamente! ", "Correcto!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    dtgVer.Rows.RemoveAt(e.RowIndex)
                Else
                    MessageBox.Show("Error Al Eliminar Consulte Con El Administrador! ", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If

        Catch ex As Exception
            MsgBox("No Puede Eliminar Una Fila Vacia")
        End Try
    End Sub

    Private Sub btn_excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        objOperacionesForm.ExportarDatosExcel(dtgVer, "Galvanizado")
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        Limpiar()
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

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        frm_consultar_galv_baches.Show()
        frm_consultar_galv_baches.cargar_consulta(sec)
    End Sub
    Private Sub Btn_transaccionar_Click(sender As Object, e As EventArgs) Handles btn_transaccionar.Click
        Dim contrasena As String = InputBox("Ingrese la contraseña del modulo")
        If contrasena.ToUpper = "TORNILLERIA123" Then
            Dim frm As New frm_Ing_Tornilleria_Trans
            frm.Show()
        Else
            MessageBox.Show("Ingrese la contraseña correcta", "Contraseña incorrecta", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
    Private Sub cargar()
        Dim strSql As String = " select Nombres from Operarios "
        Dim whereSql As String = ""
        Dim valor As String = ""
        If (cboOperario.Text <> "") Then
            valor = cboOperario.Text
            whereSql += "WHERE Nombres like('" & valor & "%') order by Nombres"
        End If
        strSql = strSql & whereSql
        cboOperario.DataSource = obj_Ing_prodLn.listar_datatable(strSql, "PRODUCCION")
    End Sub

    Private Sub Presionando(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If (cboOperario.Text.Length >= 0) Then
            cargar()
        End If
    End Sub

    Private Sub chk_todos_CheckedChanged(sender As Object, e As EventArgs) Handles chkTodos.CheckedChanged
        Dim sql As String = ""
        If (chkTodos.Checked = True) Then
            sql = "Select nit,nombres   from V_nom_personal_Activo_con_maquila WHERE centro not in (4200) ORDER BY nombres "
        Else
            sql = "Select nit,nombres  from V_nom_personal_Activo_con_maquila WHERE centro in (2800,6200) ORDER BY nombres"
          
        End If
        cboOperario.DataSource = obj_Ing_prodLn.listar_datatable(sql, "CORSAN")
        cboOperario.ValueMember = "nit"
        cboOperario.DisplayMember = "nombres"
        cboOperario.Text = "Seleccione"
    End Sub

End Class