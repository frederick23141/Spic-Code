Imports System.Data.SqlClient
Imports System.Data
Imports entidadNegocios
Public Class Dtalle_seg_ppto_ad
    Private objConexion As New Conexion
    Private obj_opSimplesAd As New Op_simplesAd
    Public Function listarBusqueda_(ByVal min As Integer, ByVal max As Integer, ByVal fec_ini As String, ByVal fec_fin As String, ByVal criterio As String, ByVal vendedores As String) As DataTable
        Dim dt As New DataTable
        Dim dr As DataRow
        Dim tipo_vend As String = ""
        Dim list_vend As New List(Of Integer)
        dt.Columns.Add("Descripciòn")
        dt.Columns.Add(New DataColumn("Ppto_Vtas", GetType(Long)))
        dt.Columns.Add(New DataColumn("Pendientes", GetType(Long)))

        If (min = max) Then
            tipo_vend = min
        ElseIf (min = 1001 And max = 1095) Then
            tipo_vend = "Nacionales"
        ElseIf (min = 1001 And max = 1099) Then
            tipo_vend = "Todos"
        End If
        dt.Columns.Add(New DataColumn(tipo_vend, GetType(Long)))
        dt.Columns.Add(New DataColumn("x_cumplir", GetType(Long)))
        For i = 1 To 99
            Select Case i
                Case 1
                    dr = dt.NewRow
                    dr("Descripciòn") = "AL BRILL"
                    dr("Ppto_Vtas") = ppto_vtas_idcor(i, fec_ini, fec_fin, min, max, criterio)
                    dr("Pendientes") = pendientes_todos(fec_ini, fec_fin, i, min, max, criterio, False)
                    dr(tipo_vend) = tot_vtas(fec_ini, fec_fin, min, max, i, criterio, False)
                    dr("x_cumplir") = (dr("Ppto_Vtas") - dr("Pendientes") - dr(tipo_vend))
                    If Not (dr("x_cumplir") = 0) Then
                        dt.Rows.Add(dr)
                    End If
                Case 2
                    dr = dt.NewRow
                    dr("Descripciòn") = "AL RECO"
                    dr("Ppto_Vtas") = ppto_vtas_idcor(i, fec_ini, fec_fin, min, max, criterio)
                    dr("Pendientes") = pendientes_todos(fec_ini, fec_fin, i, min, max, criterio, False)
                    dr(tipo_vend) = tot_vtas(fec_ini, fec_fin, min, max, i, criterio, False)
                    dr("x_cumplir") = dr("Ppto_Vtas") - dr("Pendientes") - dr(tipo_vend)
                    If Not (dr("x_cumplir") = 0) Then
                        dt.Rows.Add(dr)
                    End If
                Case 3
                    dr = dt.NewRow
                    dr("Descripciòn") = "AL ESPE"
                    dr("Ppto_Vtas") = ppto_vtas_idcor(i, fec_ini, fec_fin, min, max, criterio)
                    dr("Pendientes") = pendientes_todos(fec_ini, fec_fin, i, min, max, criterio, False)
                    dr(tipo_vend) = tot_vtas(fec_ini, fec_fin, min, max, i, criterio, False)
                    dr("x_cumplir") = dr("Ppto_Vtas") - dr("Pendientes") - dr(tipo_vend)
                    If Not (dr("x_cumplir") = 0) Then
                        dt.Rows.Add(dr)
                    End If
                Case 4
                    dr = dt.NewRow
                    dr("Descripciòn") = "VARILLAS"
                    dr("Ppto_Vtas") = ppto_vtas_idcor(i, fec_ini, fec_fin, min, max, criterio)
                    dr("Pendientes") = pendientes_todos(fec_ini, fec_fin, i, min, max, criterio, False)
                    dr(tipo_vend) = tot_vtas(fec_ini, fec_fin, min, max, i, criterio, False)
                    dr("x_cumplir") = dr("Ppto_Vtas") - dr("Pendientes") - dr(tipo_vend)
                    If Not (dr("x_cumplir") = 0) Then
                        dt.Rows.Add(dr)
                    End If
                Case 5
                    dr = dt.NewRow
                    dr("Descripciòn") = "AL PUAS"
                    dr("Ppto_Vtas") = ppto_vtas_idcor(i, fec_ini, fec_fin, min, max, criterio)
                    dr("Pendientes") = pendientes_todos(fec_ini, fec_fin, i, min, max, criterio, False)
                    dr(tipo_vend) = tot_vtas(fec_ini, fec_fin, min, max, i, criterio, False)
                    dr("x_cumplir") = dr("Ppto_Vtas") - dr("Pendientes") - dr(tipo_vend)
                    If Not (dr("x_cumplir") = 0) Then
                        dt.Rows.Add(dr)
                    End If
                Case 6
                    dr = dt.NewRow
                    dr("Descripciòn") = "AL GALV"
                    dr("Ppto_Vtas") = ppto_vtas_idcor(i, fec_ini, fec_fin, min, max, criterio)
                    dr("Pendientes") = pendientes_todos(fec_ini, fec_fin, i, min, max, criterio, False)
                    dr(tipo_vend) = tot_vtas(fec_ini, fec_fin, min, max, i, criterio, False)
                    dr("x_cumplir") = dr("Ppto_Vtas") - dr("Pendientes") - dr(tipo_vend)
                    If Not (dr("x_cumplir") = 0) Then
                        dt.Rows.Add(dr)
                    End If
                Case 7
                    dr = dt.NewRow
                    dr("Descripciòn") = "C.ELECTRICA"
                    dr("Ppto_Vtas") = ppto_vtas_idcor(i, fec_ini, fec_fin, min, max, criterio)
                    dr("Pendientes") = pendientes_todos(fec_ini, fec_fin, i, min, max, criterio, False)
                    dr(tipo_vend) = tot_vtas(fec_ini, fec_fin, min, max, i, criterio, False)
                    dr("x_cumplir") = dr("Ppto_Vtas") - dr("Pendientes") - dr(tipo_vend)
                    If Not (dr("x_cumplir") = 0) Then
                        dt.Rows.Add(dr)
                    End If
                Case 8
                    dr = dt.NewRow
                    dr("Descripciòn") = "C.C 350-700"
                    dr("Ppto_Vtas") = ppto_vtas_idcor(i, fec_ini, fec_fin, min, max, criterio)
                    dr("Pendientes") = pendientes_todos(fec_ini, fec_fin, i, min, max, criterio, False)
                    dr(tipo_vend) = tot_vtas(fec_ini, fec_fin, min, max, i, criterio, False)
                    dr("x_cumplir") = dr("Ppto_Vtas") - dr("Pendientes") - dr(tipo_vend)
                    If Not (dr("x_cumplir") = 0) Then
                        dt.Rows.Add(dr)
                    End If
                Case 9
                    dr = dt.NewRow
                    dr("Descripciòn") = "C.C 400-800"
                    dr("Ppto_Vtas") = ppto_vtas_idcor(i, fec_ini, fec_fin, min, max, criterio)
                    dr("Pendientes") = pendientes_todos(fec_ini, fec_fin, i, min, max, criterio, False)
                    dr(tipo_vend) = tot_vtas(fec_ini, fec_fin, min, max, i, criterio, False)
                    dr("x_cumplir") = dr("Ppto_Vtas") - dr("Pendientes") - dr(tipo_vend)
                    If Not (dr("x_cumplir") = 0) Then
                        dt.Rows.Add(dr)
                    End If
                Case 10
                    dr = dt.NewRow
                    dr("Descripciòn") = "C.C 500-1000"
                    dr("Ppto_Vtas") = ppto_vtas_idcor(i, fec_ini, fec_fin, min, max, criterio)
                    dr("Pendientes") = pendientes_todos(fec_ini, fec_fin, i, min, max, criterio, False)
                    dr(tipo_vend) = tot_vtas(fec_ini, fec_fin, min, max, i, criterio, False)
                    dr("x_cumplir") = dr("Ppto_Vtas") - dr("Pendientes") - dr(tipo_vend)
                    If Not (dr("x_cumplir") = 0) Then
                        dt.Rows.Add(dr)
                    End If
                Case 11
                    dr = dt.NewRow
                    dr("Descripciòn") = "CL GRANEL"
                    dr("Ppto_Vtas") = ppto_vtas_idcor(i, fec_ini, fec_fin, min, max, criterio)
                    dr("Pendientes") = pendientes_todos(fec_ini, fec_fin, i, min, max, criterio, False)
                    dr(tipo_vend) = tot_vtas(fec_ini, fec_fin, min, max, i, criterio, False)
                    dr("x_cumplir") = dr("Ppto_Vtas") - dr("Pendientes") - dr(tipo_vend)
                    If Not (dr("x_cumplir") = 0) Then
                        dt.Rows.Add(dr)
                    End If
                Case 12
                    dr = dt.NewRow
                    dr("Descripciòn") = "CL VARETA"
                    dr("Ppto_Vtas") = ppto_vtas_idcor(i, fec_ini, fec_fin, min, max, criterio)
                    dr("Pendientes") = pendientes_todos(fec_ini, fec_fin, i, min, max, criterio, False)
                    dr(tipo_vend) = tot_vtas(fec_ini, fec_fin, min, max, i, criterio, False)
                    dr("x_cumplir") = dr("Ppto_Vtas") - dr("Pendientes") - dr(tipo_vend)
                    If Not (dr("x_cumplir") = 0) Then
                        dt.Rows.Add(dr)
                    End If
                Case 13
                    dr = dt.NewRow
                    dr("Descripciòn") = "CL ZINC"
                    dr("Ppto_Vtas") = ppto_vtas_idcor(i, fec_ini, fec_fin, min, max, criterio)
                    dr("Pendientes") = pendientes_todos(fec_ini, fec_fin, i, min, max, criterio, False)
                    dr(tipo_vend) = tot_vtas(fec_ini, fec_fin, min, max, i, criterio, False)
                    dr("x_cumplir") = dr("Ppto_Vtas") - dr("Pendientes") - dr(tipo_vend)
                    If Not (dr("x_cumplir") = 0) Then
                        dt.Rows.Add(dr)
                    End If
                Case 14
                    dr = dt.NewRow
                    dr("Descripciòn") = "HEL Y ANULA"
                    dr("Ppto_Vtas") = ppto_vtas_idcor(i, fec_ini, fec_fin, min, max, criterio)
                    dr("Pendientes") = pendientes_todos(fec_ini, fec_fin, i, min, max, criterio, False)
                    dr(tipo_vend) = tot_vtas(fec_ini, fec_fin, min, max, i, criterio, False)
                    dr("x_cumplir") = dr("Ppto_Vtas") - dr("Pendientes") - dr(tipo_vend)
                    If Not (dr("x_cumplir") = 0) Then
                        dt.Rows.Add(dr)
                    End If
                Case 15
                    dr = dt.NewRow
                    dr("Descripciòn") = "CL ELECTRO"
                    dr("Ppto_Vtas") = ppto_vtas_idcor(i, fec_ini, fec_fin, min, max, criterio)
                    dr("Pendientes") = pendientes_todos(fec_ini, fec_fin, i, min, max, criterio, False)
                    dr(tipo_vend) = tot_vtas(fec_ini, fec_fin, min, max, i, criterio, False)
                    dr("x_cumplir") = dr("Ppto_Vtas") - dr("Pendientes") - dr(tipo_vend)
                    If Not (dr("x_cumplir") = 0) Then
                        dt.Rows.Add(dr)
                    End If
                Case 16
                    dr = dt.NewRow
                    dr("Descripciòn") = "CL ACERO"
                    dr("Ppto_Vtas") = ppto_vtas_idcor(i, fec_ini, fec_fin, min, max, criterio)
                    dr("Pendientes") = pendientes_todos(fec_ini, fec_fin, i, min, max, criterio, False)
                    dr(tipo_vend) = tot_vtas(fec_ini, fec_fin, min, max, i, criterio, False)
                    dr("x_cumplir") = dr("Ppto_Vtas") - dr("Pendientes") - dr(tipo_vend)
                    If Not (dr("x_cumplir") = 0) Then
                        dt.Rows.Add(dr)
                    End If
                Case 17
                    dr = dt.NewRow
                    dr("Descripciòn") = "GRAPAS"
                    dr("Ppto_Vtas") = ppto_vtas_idcor(i, fec_ini, fec_fin, min, max, criterio)
                    dr("Pendientes") = pendientes_todos(fec_ini, fec_fin, i, min, max, criterio, False)
                    dr(tipo_vend) = tot_vtas(fec_ini, fec_fin, min, max, i, criterio, False)
                    dr("x_cumplir") = dr("Ppto_Vtas") - dr("Pendientes") - dr(tipo_vend)
                    If Not (dr("x_cumplir") = 0) Then
                        dt.Rows.Add(dr)
                    End If
                Case 18
                    dr = dt.NewRow
                    dr("Descripciòn") = "CL HERRAR"
                    dr("Ppto_Vtas") = ppto_vtas_idcor(i, fec_ini, fec_fin, min, max, criterio)
                    dr("Pendientes") = pendientes_todos(fec_ini, fec_fin, i, min, max, criterio, False)
                    dr(tipo_vend) = tot_vtas(fec_ini, fec_fin, min, max, i, criterio, False)
                    dr("x_cumplir") = dr("Ppto_Vtas") - dr("Pendientes") - dr(tipo_vend)
                    If Not (dr("x_cumplir") = 0) Then
                        dt.Rows.Add(dr)
                    End If
                Case 19
                    dr = dt.NewRow
                    dr("Descripciòn") = "TR ESTUFA"
                    dr("Ppto_Vtas") = ppto_vtas_idcor(i, fec_ini, fec_fin, min, max, criterio)
                    dr("Pendientes") = pendientes_todos(fec_ini, fec_fin, i, min, max, criterio, False)
                    dr(tipo_vend) = tot_vtas(fec_ini, fec_fin, min, max, i, criterio, False)
                    dr("x_cumplir") = dr("Ppto_Vtas") - dr("Pendientes") - dr(tipo_vend)
                    If Not (dr("x_cumplir") = 0) Then
                        dt.Rows.Add(dr)
                    End If
                Case 20
                    dr = dt.NewRow
                    dr("Descripciòn") = "TR LAMINA"
                    dr("Ppto_Vtas") = ppto_vtas_idcor(i, fec_ini, fec_fin, min, max, criterio)
                    dr("Pendientes") = pendientes_todos(fec_ini, fec_fin, i, min, max, criterio, False)
                    dr(tipo_vend) = tot_vtas(fec_ini, fec_fin, min, max, i, criterio, False)
                    dr("x_cumplir") = dr("Ppto_Vtas") - dr("Pendientes") - dr(tipo_vend)
                    If Not (dr("x_cumplir") = 0) Then
                        dt.Rows.Add(dr)
                    End If
                Case 21
                    dr = dt.NewRow
                    dr("Descripciòn") = "TR MADERA"
                    dr("Ppto_Vtas") = ppto_vtas_idcor(i, fec_ini, fec_fin, min, max, criterio)
                    dr("Pendientes") = pendientes_todos(fec_ini, fec_fin, i, min, max, criterio, False)
                    dr(tipo_vend) = tot_vtas(fec_ini, fec_fin, min, max, i, criterio, False)
                    dr("x_cumplir") = dr("Ppto_Vtas") - dr("Pendientes") - dr(tipo_vend)
                    If Not (dr("x_cumplir") = 0) Then
                        dt.Rows.Add(dr)
                    End If
                Case 22
                    dr = dt.NewRow
                    dr("Descripciòn") = "TR AGLOM"
                    dr("Ppto_Vtas") = ppto_vtas_idcor(i, fec_ini, fec_fin, min, max, criterio)
                    dr("Pendientes") = pendientes_todos(fec_ini, fec_fin, i, min, max, criterio, False)
                    dr(tipo_vend) = tot_vtas(fec_ini, fec_fin, min, max, i, criterio, False)
                    dr("x_cumplir") = dr("Ppto_Vtas") - dr("Pendientes") - dr(tipo_vend)
                    If Not (dr("x_cumplir") = 0) Then
                        dt.Rows.Add(dr)
                    End If
                Case 23
                    dr = dt.NewRow
                    dr("Descripciòn") = "TR CHAZO"
                    dr("Ppto_Vtas") = ppto_vtas_idcor(i, fec_ini, fec_fin, min, max, criterio)
                    dr("Pendientes") = pendientes_todos(fec_ini, fec_fin, i, min, max, criterio, False)
                    dr(tipo_vend) = tot_vtas(fec_ini, fec_fin, min, max, i, criterio, False)
                    dr("x_cumplir") = dr("Ppto_Vtas") - dr("Pendientes") - dr(tipo_vend)
                    If Not (dr("x_cumplir") = 0) Then
                        dt.Rows.Add(dr)
                    End If
                Case 24
                    dr = dt.NewRow
                    dr("Descripciòn") = "REMACHES"
                    dr("Ppto_Vtas") = ppto_vtas_idcor(i, fec_ini, fec_fin, min, max, criterio)
                    dr("Pendientes") = pendientes_todos(fec_ini, fec_fin, i, min, max, criterio, False)
                    dr(tipo_vend) = tot_vtas(fec_ini, fec_fin, min, max, i, criterio, False)
                    dr("x_cumplir") = dr("Ppto_Vtas") - dr("Pendientes") - dr(tipo_vend)
                    If Not (dr("x_cumplir") = 0) Then
                        dt.Rows.Add(dr)
                    End If
                Case 25
                    dr = dt.NewRow
                    dr("Descripciòn") = "CARRIAJE"
                    dr("Ppto_Vtas") = ppto_vtas_idcor(i, fec_ini, fec_fin, min, max, criterio)
                    dr("Pendientes") = pendientes_todos(fec_ini, fec_fin, i, min, max, criterio, False)
                    dr(tipo_vend) = tot_vtas(fec_ini, fec_fin, min, max, i, criterio, False)
                    dr("x_cumplir") = dr("Ppto_Vtas") - dr("Pendientes") - dr(tipo_vend)
                    If Not (dr("x_cumplir") = 0) Then
                        dt.Rows.Add(dr)
                    End If
                Case 26
                    dr = dt.NewRow
                    dr("Descripciòn") = "TR DRIWALL"
                    dr("Ppto_Vtas") = ppto_vtas_idcor(i, fec_ini, fec_fin, min, max, criterio)
                    dr("Pendientes") = pendientes_todos(fec_ini, fec_fin, i, min, max, criterio, False)
                    dr(tipo_vend) = tot_vtas(fec_ini, fec_fin, min, max, i, criterio, False)
                    dr("x_cumplir") = dr("Ppto_Vtas") - dr("Pendientes") - dr(tipo_vend)
                    If Not (dr("x_cumplir") = 0) Then
                        dt.Rows.Add(dr)
                    End If
                Case 27
                    dr = dt.NewRow
                    dr("Descripciòn") = "ARANDELA"
                    dr("Ppto_Vtas") = ppto_vtas_idcor(i, fec_ini, fec_fin, min, max, criterio)
                    dr("Pendientes") = pendientes_todos(fec_ini, fec_fin, i, min, max, criterio, False)
                    dr(tipo_vend) = tot_vtas(fec_ini, fec_fin, min, max, i, criterio, False)
                    dr("x_cumplir") = dr("Ppto_Vtas") - dr("Pendientes") - dr(tipo_vend)
                    If Not (dr("x_cumplir") = 0) Then
                        dt.Rows.Add(dr)
                    End If
                Case 28
                    dr = dt.NewRow
                    dr("Descripciòn") = "CHATARRA"
                    dr("Ppto_Vtas") = ppto_vtas_idcor(i, fec_ini, fec_fin, min, max, criterio)
                    dr("Pendientes") = pendientes_todos(fec_ini, fec_fin, i, min, max, criterio, False)
                    dr(tipo_vend) = tot_vtas(fec_ini, fec_fin, min, max, i, criterio, False)
                    If (dr("Pendientes") <> 0 Or dr(tipo_vend) <> 0) Then
                        dt.Rows.Add(dr)
                    End If
                Case 29
                    dr = dt.NewRow
                    dr("Descripciòn") = "POSTES-CERCA"
                    dr("Ppto_Vtas") = ppto_vtas_idcor(i, fec_ini, fec_fin, min, max, criterio)
                    dr("Pendientes") = pendientes_todos(fec_ini, fec_fin, i, min, max, criterio, False)
                    dr(tipo_vend) = tot_vtas(fec_ini, fec_fin, min, max, i, criterio, False)
                    If (dr("Pendientes") <> 0 Or dr(tipo_vend) <> 0) Then
                        dt.Rows.Add(dr)
                    End If
                Case 30
                    dr = dt.NewRow
                    dr("Descripciòn") = "OTROS"
                    dr("Ppto_Vtas") = ppto_vtas_idcor(i, fec_ini, fec_fin, min, max, criterio)
                    dr("Pendientes") = pendientes_todos(fec_ini, fec_fin, i, min, max, criterio, False)
                    dr(tipo_vend) = tot_vtas(fec_ini, fec_fin, min, max, i, criterio, False)
                    If (dr("Pendientes") <> 0 Or dr(tipo_vend) <> 0) Then
                        dt.Rows.Add(dr)
                    End If
                Case 31
                    dr = dt.NewRow
                    dr("Descripciòn") = "CADENAS"
                    dr("Ppto_Vtas") = ppto_vtas_idcor(i, fec_ini, fec_fin, min, max, criterio)
                    dr("Pendientes") = pendientes_todos(fec_ini, fec_fin, i, min, max, criterio, False)
                    dr(tipo_vend) = tot_vtas(fec_ini, fec_fin, min, max, i, criterio, False)
                    If (dr("Pendientes") <> 0 Or dr(tipo_vend) <> 0) Then
                        dt.Rows.Add(dr)
                    End If
                Case 90
                    dr = dt.NewRow
                    dr("Descripciòn") = "CLAVO COMUN SOLO BODEGA 2"
                    dr("Ppto_Vtas") = ppto_vtas_idcor(i, fec_ini, fec_fin, min, max, criterio)
                    dr("Pendientes") = pendientes_todos(fec_ini, fec_fin, i, min, max, criterio, False)
                    dr(tipo_vend) = tot_vtas(fec_ini, fec_fin, min, max, i, criterio, False)
                    If (dr("Pendientes") <> 0 Or dr(tipo_vend) <> 0) Then
                        dt.Rows.Add(dr)
                    End If
                Case 99
                    dr = dt.NewRow
                    dr("Descripciòn") = "SIN CLASIFICAR"
                    dr("Ppto_Vtas") = ppto_vtas_idcor(i, fec_ini, fec_fin, min, max, criterio)
                    dr("Pendientes") = pendientes_todos(fec_ini, fec_fin, i, min, max, criterio, False)
                    dr(tipo_vend) = tot_vtas(fec_ini, fec_fin, min, max, i, criterio, False)
                    If (dr("Pendientes") <> 0 Or dr(tipo_vend) <> 0) Then
                        dt.Rows.Add(dr)
                    End If
            End Select
        Next
        dr = dt.NewRow
        dr("Descripciòn") = "TOTAL"
        dt.Rows.Add(dr)

        dt.AcceptChanges()

        Return dt

    End Function
    Public Function listarBusqueda(ByVal min As Integer, ByVal max As Integer, ByVal fec_ini As String, ByVal fec_fin As String, ByVal criterio As String, ByVal vendedores As String, ByVal grupo As Boolean, ByVal linea As Boolean) As DataTable
        Dim dt As New DataTable
        Dim dr As DataRow
        Dim tipo_vend As String = ""
        Dim list_vend As New List(Of Integer)
        If grupo Then
            dt.Columns.Add("Grupo")
        End If
        If linea Then
            dt.Columns.Add("Descripciòn")
        End If
        dt.Columns.Add(New DataColumn("Ppto_Vtas", GetType(Long)))
        dt.Columns.Add(New DataColumn("Pendientes", GetType(Long)))

        If (min = max) Then
            tipo_vend = min
        ElseIf (min = 1001 And max = 1095) Then
            tipo_vend = "Nacionales"
        ElseIf (min = 1001 And max = 1099) Then
            tipo_vend = "Todos"
        End If
        dt.Columns.Add(New DataColumn(tipo_vend, GetType(Long)))
        dt.Columns.Add(New DataColumn("x_cumplir", GetType(Long)))
        Dim sql_linea As String = ""

        If grupo And linea = False Then
            sql_linea = "SELECT j.id, j.descripcion As desc_grupo " & _
                          "FROM J_grupo_producto  j  "
        Else
            sql_linea = "SELECT  j.descripcion As desc_grupo ,i.id_cor , i.descripcion " & _
                            "FROM jjv_grupos_seguimiento i, J_grupo_producto  j  " & _
                                "WHERE i.id_grupo_producto = j.id " & _
                                    "ORDER BY i.orden"
        End If

        Dim dt_linea As DataTable = obj_opSimplesAd.listar_datatable(sql_linea, "CORSAN")
        For i = 0 To dt_linea.Rows.Count - 1
            dr = dt.NewRow
            If grupo Then
                dr("Grupo") = dt_linea.Rows(i).Item("desc_grupo")
                If linea = False Then
                    dr("Ppto_Vtas") = ppto_vtas_grupo(dt_linea.Rows(i).Item("id"), fec_ini, fec_fin, min, max, criterio)
                    dr("Pendientes") = pendientes_todos_grupo(fec_ini, fec_fin, dt_linea.Rows(i).Item("id"), min, max, criterio, False)
                    dr(tipo_vend) = tot_vtas_grupo(fec_ini, fec_fin, min, max, dt_linea.Rows(i).Item("id"), criterio, False)
                End If
            End If
            If linea Then
                dr("Descripciòn") = dt_linea.Rows(i).Item("descripcion")
                dr("Ppto_Vtas") = ppto_vtas_idcor(dt_linea.Rows(i).Item("id_cor"), fec_ini, fec_fin, min, max, criterio)
                dr("Pendientes") = pendientes_todos(fec_ini, fec_fin, dt_linea.Rows(i).Item("id_cor"), min, max, criterio, False)
                dr(tipo_vend) = tot_vtas(fec_ini, fec_fin, min, max, dt_linea.Rows(i).Item("id_cor"), criterio, False)
            End If
            dr("x_cumplir") = (dr("Ppto_Vtas") - dr("Pendientes") - dr(tipo_vend))
           dt.Rows.Add(dr)
        Next
        dr = dt.NewRow
        'dr("Descripciòn") = "TOTAL"
        dt.Rows.Add(dr)
        dt.AcceptChanges()
        Return dt
    End Function
    Public Function listar_vendedores(ByVal vendedores As String) As List(Of Integer)
        Dim reader As SqlDataReader
        Dim list_vend As New List(Of Integer)
        Dim k As Double = 0
        Dim comando As New SqlCommand
        Dim conn As New SqlConnection
        Dim criterioVendedor As String = ""
        If (vendedores <> "") Then
            criterioVendedor = " vendedor in (" & vendedores & ")"
        Else
            criterioVendedor = " vendedor>=1001 and vendedor<=1099 "
        End If
        comando.CommandType = CommandType.Text
        conn = objConexion.abrirConexion
        comando.Connection = conn
        comando.CommandText = ("select vendedor FROM v_vendedores WHERE     " & criterioVendedor & " AND (bloqueo = 0) ORDER BY vendedor")
        reader = comando.ExecuteReader
        While (reader.Read)
            If IsDBNull(reader(0)) Then
            Else
                list_vend.Add(reader("vendedor"))
                k = k + 1
            End If
        End While
        conn.Close()
        Return list_vend
    End Function
    Private Function ppto_vtas_idcor(ByVal id_cor As Integer, ByVal fec_ini As String, ByVal fec_fin As String, ByVal min As Integer, ByVal max As Integer, ByVal criterio As String) As Double
        Dim comando1 As New SqlCommand
        Dim resp As Double = 0
        Dim reader As SqlDataReader
        Dim sql As String = ""
        Dim conn As New SqlConnection
        If (criterio = "kilos") Then
            criterio = "Ppto_kilos"
        Else
            criterio = "Vr_total"
        End If
        comando1.CommandType = CommandType.Text
        conn = objConexion.abrirConexion
        comando1.Connection = conn
        comando1.Parameters.Add("@id_cor", SqlDbType.VarChar).Value = id_cor
        comando1.Parameters.Add("@min", SqlDbType.VarChar).Value = min
        comando1.Parameters.Add("@max", SqlDbType.VarChar).Value = max
        comando1.Parameters.Add("@fec_ini", SqlDbType.Text).Value = fec_ini
        comando1.Parameters.Add("@fec_fin", SqlDbType.Text).Value = fec_fin
        sql = "select SUM (" & criterio & ") from Jjv_Ppto_mes where Id_cor=" & id_cor & " and Fecha_ppto >='" & fec_ini & "' and Fecha_ppto <='" & fec_fin & "' and Vendedor <> 10011099 and Vendedor >= " & min & " and Vendedor <= " & max & " "
        comando1.CommandText = (sql)
        reader = comando1.ExecuteReader
        If (reader.Read) Then
            If IsDBNull(reader(0)) Then
            Else
                resp = reader(0)
            End If
        End If
        Return resp
        conn.Close()
    End Function
    Private Function ppto_vtas_grupo(ByVal grupo As Integer, ByVal fec_ini As String, ByVal fec_fin As String, ByVal min As Integer, ByVal max As Integer, ByVal criterio As String) As Double
        Dim comando1 As New SqlCommand
        Dim resp As Double = 0
        Dim reader As SqlDataReader
        Dim sql As String = ""
        Dim conn As New SqlConnection
        If (criterio = "kilos") Then
            criterio = "Ppto_kilos"
        Else
            criterio = "Vr_total"
        End If
        comando1.CommandType = CommandType.Text
        conn = objConexion.abrirConexion
        comando1.Connection = conn
        comando1.Parameters.Add("@grupo", SqlDbType.VarChar).Value = grupo
        comando1.Parameters.Add("@min", SqlDbType.VarChar).Value = min
        comando1.Parameters.Add("@max", SqlDbType.VarChar).Value = max
        comando1.Parameters.Add("@fec_ini", SqlDbType.Text).Value = fec_ini
        comando1.Parameters.Add("@fec_fin", SqlDbType.Text).Value = fec_fin
        sql = "select SUM (" & criterio & ") from Jjv_Ppto_mes p ,jjv_grupos_seguimiento g, J_grupo_producto j  " & _
                    "WHERE p.Id_cor = g.id_cor AND j.id = g.id_grupo_producto  AND  j.id=" & grupo & " and Fecha_ppto >='" & fec_ini & "' and Fecha_ppto <='" & fec_fin & "' and Vendedor <> 10011099 and Vendedor >= " & min & " and Vendedor <= " & max & " "
        comando1.CommandText = (sql)
        reader = comando1.ExecuteReader
        If (reader.Read) Then
            If Not IsDBNull(reader(0)) Then
                resp = reader(0)
            End If
        End If
        Return resp
        conn.Close()
    End Function
    Private Function pendientes_todos(ByVal fec_ini As String, ByVal fec_fin As String, ByVal id_cor As Integer, ByVal min As Integer, ByVal max As Integer, ByVal criterio As String, ByVal no_clasf As Boolean) As Double
        Dim comando1 As New SqlCommand
        Dim resp As Double = 0
        Dim reader As SqlDataReader
        Dim sql As String = ""
        Dim conn As New SqlConnection
        comando1.CommandType = CommandType.Text
        If (criterio = "kilos") Then
            criterio = "KilosPendiente"
        Else
            criterio = "Valor_total"
        End If
        conn = objConexion.abrirConexion
        comando1.Connection = conn
        If (no_clasf) Then
            sql = "SELECT distinct codigo,fecha, numero, " & criterio & " " & _
                       "FROM V_pendientes_por_vendedor " & _
                               "WHERE Valor_total >0 and Vendedor >= " & min & " and Vendedor <= " & max & " and  Id_cor is null "
        Else
            sql = "SELECT distinct codigo,fecha, numero, " & criterio & " " & _
                       "FROM V_pendientes_por_vendedor " & _
                               "WHERE Valor_total >0 and Vendedor >= " & min & " and Vendedor <= " & max & " and  Id_cor =" & id_cor & ""
        End If

        comando1.CommandText = (sql)
        reader = comando1.ExecuteReader
        While (reader.Read)
            If IsDBNull(reader(3)) Then
            Else
                resp += reader(3)
            End If
        End While
        conn.Close()
        Return resp

    End Function
    Private Function pendientes_todos_grupo(ByVal fec_ini As String, ByVal fec_fin As String, ByVal grupo As Integer, ByVal min As Integer, ByVal max As Integer, ByVal criterio As String, ByVal no_clasf As Boolean) As Double
        Dim comando1 As New SqlCommand
        Dim resp As Double = 0
        Dim reader As SqlDataReader
        Dim sql As String = ""
        Dim conn As New SqlConnection
        comando1.CommandType = CommandType.Text
        If (criterio = "kilos") Then
            criterio = "KilosPendiente"
        Else
            criterio = "Valor_total"
        End If
        conn = objConexion.abrirConexion
        comando1.Connection = conn
        sql = "SELECT distinct codigo,fecha, numero, " & criterio & " " & _
                       "FROM V_pendientes_por_vendedor p , jjv_grupos_Seguimiento g, J_grupo_producto j " & _
                               "WHERE p.id_cor = g.id_cor AND g.id_grupo_producto = j.id AND Valor_total >0 and Vendedor >= " & min & " and Vendedor <= " & max & " and  j.id =" & grupo & ""
        comando1.CommandText = (sql)
        reader = comando1.ExecuteReader
        While (reader.Read)
            If Not IsDBNull(reader(3)) Then
                resp += reader(3)
            End If
        End While
        conn.Close()
        Return resp

    End Function
    Private Function tot_vtas(ByVal fec_ini As String, ByVal fec_fin As String, ByVal min As Integer, ByVal max As Integer, ByVal id_cor As Integer, ByVal criterio As String, ByVal no_clasif As Boolean) As Double
        Dim comando1 As New SqlCommand
        Dim resp As Double = 0
        Dim reader As SqlDataReader
        Dim sql As String = ""
        Dim conn As New SqlConnection
        comando1.CommandType = CommandType.Text
        If (criterio = "kilos") Then
            criterio = "KILOS"
        Else
            criterio = "Vr_total"
        End If
        If (no_clasif) Then
            sql = "Select Sum (" & criterio & ") " & _
                        "from Jjv_V_vtas_vend_cliente_ref " & _
                            "where vendedor > = " & min & " and vendedor <= " & max & " and Id_cor is null and fec >='" & fec_ini & "' and Fec <='" & fec_fin & "'"
        Else
            sql = "Select Sum (" & criterio & ") " & _
                        "from Jjv_V_vtas_vend_cliente_ref " & _
                            "where vendedor > = " & min & " and vendedor <= " & max & " and Id_cor = " & id_cor & " and fec >='" & fec_ini & "' and Fec <='" & fec_fin & "'"
        End If
        conn = objConexion.abrirConexion
        comando1.Connection = conn
        comando1.CommandText = (sql)
        reader = comando1.ExecuteReader
        While (reader.Read)
            If IsDBNull(reader(0)) Then
            Else
                resp += reader(0)
            End If
        End While
        Return resp
        conn.Close()
    End Function
    Private Function tot_vtas_grupo(ByVal fec_ini As String, ByVal fec_fin As String, ByVal min As Integer, ByVal max As Integer, ByVal grupo As Integer, ByVal criterio As String, ByVal no_clasif As Boolean) As Double
        Dim comando1 As New SqlCommand
        Dim resp As Double = 0
        Dim reader As SqlDataReader
        Dim sql As String = ""
        Dim conn As New SqlConnection
        comando1.CommandType = CommandType.Text
        If (criterio = "kilos") Then
            criterio = "KILOS"
        Else
            criterio = "Vr_total"
        End If
        sql = "Select Sum (" & criterio & ") " & _
                        "from Jjv_V_vtas_vend_cliente_ref " & _
                            "where vendedor > = " & min & " and vendedor <= " & max & " and id_grupo_producto = " & grupo & " and fec >='" & fec_ini & "' and Fec <='" & fec_fin & "'"

        conn = objConexion.abrirConexion
        comando1.Connection = conn
        comando1.CommandText = (sql)
        reader = comando1.ExecuteReader
        While (reader.Read)
            If IsDBNull(reader(0)) Then
            Else
                resp += reader(0)
            End If
        End While
        Return resp
        conn.Close()
    End Function
End Class
