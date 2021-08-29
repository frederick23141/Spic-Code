#Disable Warning BC40056 ' El espacio de nombres o el tipo especificado en el 'System.Data.SqlServerCef' Imports no contienen ningún miembro público o no se encuentran. Asegúrese de que el espacio de nombres o el tipo se hayan definido y de que contengan al menos un miembro público. Asegúrese de que el nombre del elemento importado no use ningún alias.
Imports System.Data.SqlServerCef
#Enable Warning BC40056 ' El espacio de nombres o el tipo especificado en el 'System.Data.SqlServerCef' Imports no contienen ningún miembro público o no se encuentran. Asegúrese de que el espacio de nombres o el tipo se hayan definido y de que contengan al menos un miembro público. Asegúrese de que el nombre del elemento importado no use ningún alias.
#Disable Warning BC40056 ' El espacio de nombres o el tipo especificado en el 'System.Configurationcolim' Imports no contienen ningún miembro público o no se encuentran. Asegúrese de que el espacio de nombres o el tipo se hayan definido y de que contengan al menos un miembro público. Asegúrese de que el nombre del elemento importado no use ningún alias.
Imports System.Configurationcolim
#Enable Warning BC40056 ' El espacio de nombres o el tipo especificado en el 'System.Configurationcolim' Imports no contienen ningún miembro público o no se encuentran. Asegúrese de que el espacio de nombres o el tipo se hayan definido y de que contengan al menos un miembro público. Asegúrese de que el nombre del elemento importado no use ningún alias.
Imports logicaNegocios
Imports entidadNegocios
Imports accesoDatos
Imports System.IO
Imports Microsoft.Office.Interop
Imports System.Data.SqlClient

Public Class DassboardMaquinas

    Private obj_Ing_prodLn As New Ing_prodLn
    Public activas As Integer
    Public paros As Integer
    Public inactivas As Integer


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        LabelTimer.Text -= 1


        If (LabelTimer.Text = "0") Then
            activas = 0
            paros = 0
            inactivas = 0

            ValidarEstados()


            '' RESETEAMOS EL TIEMPO
            LabelTimer.Text = 20
        End If

    End Sub

    Private Sub ValidarEstados()
        ''ACA ACTUALIZAMOS TODOS LAS IMAGENES SEGUN CONDICION EN LA BD          
        Dim sql As String = ""
        Dim estado As String = ""
        Dim sqlParo As String = ""
        Dim estadop As String = ""

        'verificar la maquina1
        sql = "SELECT Estado FROM dbo.J_Maquinas WHERE (codigoM = 2101)"
        estado = obj_Ing_prodLn.listar_Estado(sql, "PRODUCCION")
        sqlParo = "SELECT Paro FROM dbo.J_Maquinas WHERE (codigoM = 2101)"
        estadop = obj_Ing_prodLn.listar_Estado(sqlParo, "PRODUCCION")

        If (estado.Contains("A")) Then
            PictureBoxTf1.Image = My.Resources.led_verde
            PictureBoxTf1.Refresh()
            activas += 1
            labelPM1.Text = ""

        End If
        If (estado.Contains("P")) Then
            PictureBoxTf1.Image = My.Resources.led_naranja
            PictureBoxTf1.Refresh()
            paros += 1
            labelPM1.Text = estadop

        End If
        If (estado.Contains("I")) Then
            PictureBoxTf1.Image = My.Resources.led_rojo
            PictureBoxTf1.Refresh()
            inactivas += 1
            labelPM1.Text = ""
        End If
        PictureBoxTf1.Refresh()

        'verificar la maquina2
        sql = "SELECT Estado FROM dbo.J_Maquinas WHERE (codigoM = 2102)"
        estado = obj_Ing_prodLn.listar_Estado(sql, "PRODUCCION")
        sqlParo = "SELECT Paro FROM dbo.J_Maquinas WHERE (codigoM = 2102)"
        estadop = obj_Ing_prodLn.listar_Estado(sqlParo, "PRODUCCION")
        If (estado.Contains("A")) Then
            PictureBoxTf2.Image = My.Resources.led_verde
            activas += 1
            labelPM2.Text = ""
        End If
        If (estado.Contains("P")) Then
            PictureBoxTf2.Image = My.Resources.led_naranja
            paros += 1
            labelPM2.Text = estadop
        End If
        If (estado.Contains("I")) Then
            PictureBoxTf2.Image = My.Resources.led_rojo
            inactivas += 1
            labelPM2.Text = ""
        End If

        'verificar la maquina3
        sql = "SELECT Estado FROM dbo.J_Maquinas WHERE (codigoM = 2103)"
        estado = obj_Ing_prodLn.listar_Estado(sql, "PRODUCCION")
        sqlParo = "SELECT Paro FROM dbo.J_Maquinas WHERE (codigoM = 2103)"
        estadop = obj_Ing_prodLn.listar_Estado(sqlParo, "PRODUCCION")
        If (estado.Contains("A")) Then
            PictureBoxTf3.Image = My.Resources.led_verde
            activas += 1
            labelPM3.Text = ""
        End If
        If (estado.Contains("P")) Then
            PictureBoxTf3.Image = My.Resources.led_naranja
            paros += 1
            labelPM3.Text = estadop
        End If
        If (estado.Contains("I")) Then
            PictureBoxTf3.Image = My.Resources.led_rojo
            inactivas += 1
            labelPM3.Text = ""
        End If

        'verificar la maquina4
        sql = "SELECT Estado FROM dbo.J_Maquinas WHERE (codigoM = 2104)"
        estado = obj_Ing_prodLn.listar_Estado(sql, "PRODUCCION")
        sqlParo = "SELECT Paro FROM dbo.J_Maquinas WHERE (codigoM = 2104)"
        estadop = obj_Ing_prodLn.listar_Estado(sqlParo, "PRODUCCION")
        If (estado.Contains("A")) Then
            PictureBoxTf4.Image = My.Resources.led_verde
            activas += 1
            labelPM4.Text = ""
        End If
        If (estado.Contains("P")) Then
            PictureBoxTf4.Image = My.Resources.led_naranja
            paros += 1
            labelPM4.Text = estadop
        End If
        If (estado.Contains("I")) Then
            PictureBoxTf4.Image = My.Resources.led_rojo
            inactivas += 1
            labelPM4.Text = ""
        End If

        'verificar la maquina5
        sql = "SELECT Estado FROM dbo.J_Maquinas WHERE (codigoM = 2105)"
        estado = obj_Ing_prodLn.listar_Estado(sql, "PRODUCCION")
        sqlParo = "SELECT Paro FROM dbo.J_Maquinas WHERE (codigoM = 2105)"
        estadop = obj_Ing_prodLn.listar_Estado(sqlParo, "PRODUCCION")
        If (estado.Contains("A")) Then
            PictureBoxTf5.Image = My.Resources.led_verde
            activas += 1
            labelPM5.Text = ""
        End If
        If (estado.Contains("P")) Then
            PictureBoxTf5.Image = My.Resources.led_naranja
            paros += 1
            labelPM5.Text = estadop
        End If
        If (estado.Contains("I")) Then
            PictureBoxTf5.Image = My.Resources.led_rojo
            inactivas += 1
            labelPM5.Text = ""
        End If

        'verificar la maquina6
        sql = "SELECT Estado FROM dbo.J_Maquinas WHERE (codigoM = 2116)"
        estado = obj_Ing_prodLn.listar_Estado(sql, "PRODUCCION")
        sqlParo = "SELECT Paro FROM dbo.J_Maquinas WHERE (codigoM = 2116)"
        estadop = obj_Ing_prodLn.listar_Estado(sqlParo, "PRODUCCION")
        If (estado.Contains("A")) Then
            PictureBoxTf6.Image = My.Resources.led_verde
            activas += 1
            labelPM6.Text = ""
        End If
        If (estado.Contains("P")) Then
            PictureBoxTf6.Image = My.Resources.led_naranja
            paros += 1
            labelPM6.Text = estadop
        End If
        If (estado.Contains("I")) Then
            PictureBoxTf6.Image = My.Resources.led_rojo
            inactivas += 1
            labelPM6.Text = ""
        End If

        'verificar la maquina7
        sql = "SELECT Estado FROM dbo.J_Maquinas WHERE (codigoM = 2118)"
        estado = obj_Ing_prodLn.listar_Estado(sql, "PRODUCCION")
        sqlParo = "SELECT Paro FROM dbo.J_Maquinas WHERE (codigoM = 2118)"
        estadop = obj_Ing_prodLn.listar_Estado(sqlParo, "PRODUCCION")
        If (estado.Contains("A")) Then
            PictureBoxTf7.Image = My.Resources.led_verde
            activas += 1
            labelPM7.Text = ""
        End If
        If (estado.Contains("P")) Then
            PictureBoxTf7.Image = My.Resources.led_naranja
            paros += 1
            labelPM7.Text = estadop
        End If
        If (estado.Contains("I")) Then
            PictureBoxTf7.Image = My.Resources.led_rojo
            inactivas += 1
            labelPM7.Text = ""
        End If

        'verificar la maquina8
        sql = "SELECT Estado FROM dbo.J_Maquinas WHERE (codigoM = 2119)"
        estado = obj_Ing_prodLn.listar_Estado(sql, "PRODUCCION")
        sqlParo = "SELECT Paro FROM dbo.J_Maquinas WHERE (codigoM = 2119)"
        estadop = obj_Ing_prodLn.listar_Estado(sqlParo, "PRODUCCION")
        If (estado.Contains("A")) Then
            PictureBoxTf8.Image = My.Resources.led_verde
            activas += 1
            labelPM8.Text = ""
        End If
        If (estado.Contains("P")) Then
            PictureBoxTf8.Image = My.Resources.led_naranja
            paros += 1
            labelPM8.Text = estadop
        End If
        If (estado.Contains("I")) Then
            PictureBoxTf8.Image = My.Resources.led_rojo
            inactivas += 1
            labelPM8.Text = ""
        End If

        'verificar la maquina9
        sql = "SELECT Estado FROM dbo.J_Maquinas WHERE (codigoM = 2121)"
        estado = obj_Ing_prodLn.listar_Estado(sql, "PRODUCCION")
        sqlParo = "SELECT Paro FROM dbo.J_Maquinas WHERE (codigoM = 2121)"
        estadop = obj_Ing_prodLn.listar_Estado(sqlParo, "PRODUCCION")
        If (estado.Contains("A")) Then
            PictureBoxTf9.Image = My.Resources.led_verde
            activas += 1
            labelPM9.Text = ""
        End If
        If (estado.Contains("P")) Then
            PictureBoxTf9.Image = My.Resources.led_naranja
            paros += 1
            labelPM9.Text = estadop
        End If
        If (estado.Contains("I")) Then
            PictureBoxTf9.Image = My.Resources.led_rojo
            inactivas += 1
            labelPM9.Text = ""
        End If

        LabelActivas.Text = (activas.ToString)
        LabelParos.Text = (paros.ToString)
        LabelInactivas.Text = (inactivas.ToString)
    End Sub

    Private Sub DassboardMaquinas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Start()

        labelPM1.Text = ""
        labelPM2.Text = ""
        labelPM3.Text = ""
        labelPM4.Text = ""
        labelPM5.Text = ""
        labelPM6.Text = ""
        labelPM7.Text = ""
        labelPM8.Text = ""
        labelPM9.Text = ""

    End Sub

End Class