Imports System.Data.SqlClient
Imports System.Data
Imports entidadNegocios
Public Class ClienteAd
    '****************************************************************************************************************
    'Se crean los parametros para la conexion ***********************************************************************
    '****************************************************************************************************************
    Private conn As New SqlConnection
    Private comando As New SqlCommand
    Private errores As String
    Dim objConexion As New Conexion
    '****************************************************************************************************************
    'Se listan los resultados de la busqueda de el nombre de el cliente**********************************************
    '****************************************************************************************************************
    Public Function listarBusqueda(ByVal cadena As String) As DataTable
        conn = objConexion.abrirConexion
        Dim dt As New DataTable
        Dim DA As New SqlDataAdapter("select nombres,nit from Jjv_Datos_Clientes_completo Where nombres like  '%" & cadena & "%' and vendedor>=1001 and vendedor<=1099 GROUP BY ciudad, nit, nombres ", conn)
        DA.Fill(dt)
        Return dt
    End Function
    '****************************************************************************************************************
    'Se listan los resultados de el Nit de el cliente****************************************************************
    '****************************************************************************************************************
    Public Function listarCliente(ByVal nit As Double) As DataTable
        conn = objConexion.abrirConexion
        Dim dt As New DataTable
        Dim DA As New SqlDataAdapter("SELECT nombres,Promed_Dias_pago,bloqueo,notas,cupo_credito,condicion,vendedor,contacto_1,fecha_creacion,cupo_ant,fecha_modificacion,celular,direccion,ciudad,telefono_1,fax,mail from Jjv_Datos_Clientes_completo where  vendedor >=1001 and vendedor <=1099 and nit=" & nit, conn)
        DA.Fill(dt)
        conn.Close()
        Return dt
    End Function
    Public Function listarClienteTERCEROS(ByVal nit As Double) As DataTable
        conn = objConexion.abrirConexion
        Dim dt As New DataTable
        Dim DA As New SqlDataAdapter("select nombres,bloqueo,notas,cupo_credito,condicion,vendedor,contacto_1,fecha_creacion,cupo_ant,fecha_modificacion,celular,direccion,ciudad,telefono_1,fax,mail   from terceros  where  vendedor >=1001 and vendedor <=1099 and nit=" & nit, conn)
        DA.Fill(dt)
        conn.Close()
        Return dt
    End Function
    '****************************************************************************************************************
    'Devuelve el saldo de un cliente*********************************************************************************
    '****************************************************************************************************************
    Public Function mostrarSaldoCliente(ByVal nit As Double) As String
        Dim resp As String
        Dim saldoTot As Double
        Dim chequeDev As Double
        Dim reader As SqlDataReader
        comando.CommandType = CommandType.Text
        conn = objConexion.abrirConexion
        comando.Connection = conn
        comando.CommandText = "Select Saldo_Tot ,Cheques_Dev  from V_SALDO_TER2 where Nit=" & nit
        reader = comando.ExecuteReader
        While (reader.Read)
            saldoTot = reader(0)
            chequeDev = reader(1)
        End While
        resp = saldoTot & " " & chequeDev
        conn.Close()
        Return resp
    End Function

    '****************************************************************************************************************
    'funcion encargada de verificar si el nit del cliente existe, y devuelve un boolean dependientre el resultado****
    '****************************************************************************************************************

    Public Function existeCliente(ByVal nit As Double) As Boolean
        Dim reader As SqlDataReader
        comando.CommandType = CommandType.Text
        conn = objConexion.abrirConexion
        comando.Connection = conn
        comando.CommandText = "SELECT nit FROM Jjv_Datos_Clientes_completo where nit=" & nit
        reader = comando.ExecuteReader
        While (reader.Read)
            conn.Close()
            Return True
        End While
        Return False
    End Function
    Public Function existeClienteTerceros(ByVal nit As Double) As Boolean
        Dim reader As SqlDataReader
        comando.CommandType = CommandType.Text
        conn = objConexion.abrirConexion
        comando.Connection = conn
        comando.CommandText = "SELECT nit FROM terceros where nit=" & nit
        reader = comando.ExecuteReader
        While (reader.Read)
            conn.Close()
            Return True
        End While
        Return False
    End Function
    '****************************************************************************************************************
    'Detenermina el cupo disponible de el cliente********************************************************************
    '****************************************************************************************************************
    Public Function cupoDisponible(ByVal nit As Double, ByVal PenValTot As Double, ByVal saldo As Double) As Double
        Dim totCupoDisponible As Double
        Dim cupo As Double
        Dim reader As SqlDataReader
        comando.CommandType = CommandType.Text
        conn = objConexion.abrirConexion
        comando.Connection = conn
        comando.CommandText = "SELECT cupo_credito FROM Jjv_Datos_Clientes_completo where nit=" & nit
        reader = comando.ExecuteReader
        While (reader.Read)
            cupo = reader(0) * 1.3
        End While
        conn.Close()
        totCupoDisponible = (cupo - saldo - PenValTot)
        Return totCupoDisponible
    End Function
    'Aun no se usa
    'Metodo que invierte filas por columna de una tabla
    Public Function invertirFilasColumnas(ByVal dtOrigen As DataTable, ByVal le As ArrayList) As DataTable
        Dim dtNueva As New DataTable
        Dim ds As New DataSet
        Dim i, j As Integer

        'Primera columna, sin nombre
        Dim dtCol1 As New DataColumn
        With dtCol1
            .DataType = System.Type.GetType("System.String")
            .ColumnName = " "
            .ReadOnly = False
            .Unique = False
        End With

        With dtNueva
            .Columns.Add(dtCol1)
        End With

        'Creamos las columnas necesarias en función del numero de Entidades que resultante de la consulta (guardadas en el ArrayList)
        For i = 0 To le.Count - 1
            Dim dtCol As New DataColumn
            With dtCol
                .DataType = System.Type.GetType("System.String")
                .ColumnName = le.Item(i).nombre
                .ReadOnly = False
                .Unique = False
            End With

            With dtNueva
                .Columns.Add(dtCol)
            End With
        Next

        Dim dtFila As DataRow

        For i = 1 To dtOrigen.Columns.Count - 1
            dtFila = dtNueva.NewRow()
            dtFila(" ") = dtOrigen.Columns(i).ColumnName
            For j = 0 To le.Count - 1
                dtFila(j + 1) = dtOrigen.Rows(j)(i).ToString
            Next
            dtNueva.Rows.Add(dtFila)
        Next

        Return dtNueva

    End Function
    '****************************************************************************************************************
    'fDevuelve el valor de la mayor venta de un cliente**************************************************************
    '****************************************************************************************************************
    Public Function mayVenta(ByVal nit As Double) As Double
        Dim resultMayVenta As Double = 0
        Dim reader As SqlDataReader
        comando.CommandType = CommandType.Text
        conn = objConexion.abrirConexion
        comando.Connection = conn
        comando.CommandText = "Select valor=max(VALOR_TOTAL) from documentos WHERE SW=1 AND NIT=" & nit & "and fecha >='" & Now.Year - 1 & "-" & Now.Month & "-" & Now.Day & " 00:00:00.000'and vendedor >=1001 and vendedor <=1099"
        reader = comando.ExecuteReader
        While (reader.Read)
            If IsDBNull(reader(0)) Then
            Else
                resultMayVenta = reader(0)
            End If

        End While
        conn.Close()
        Return resultMayVenta
    End Function
    '****************************************************************************************************************
    'devuelve la fecha de la mayor venta de un determinado cliente***************************************************
    '****************************************************************************************************************
    Public Function fechMayVenta(ByVal nit As Double, ByVal valor As Double) As String
        Dim resultMayVenta As String = ""
        Dim reader As SqlDataReader
        comando.CommandType = CommandType.Text
        conn = objConexion.abrirConexion
        comando.Connection = conn
        comando.CommandText = "Select fecha from documentos WHERE SW=1 AND NIT=" & nit & "and fecha >= '01/01/" & Now.Year - 1 & "' and VALOR_TOTAL =" & valor & "and vendedor >=1001 and vendedor <=1099"
        reader = comando.ExecuteReader
        While (reader.Read)
            If IsDBNull(reader(0)) Then
            Else
                resultMayVenta = reader(0)
            End If

        End While
        conn.Close()
        Return resultMayVenta
    End Function
    Public Function nombres(ByVal nit As Double) As String
        Dim reader As SqlDataReader
        Dim resp As String = ""
        comando.CommandType = CommandType.Text
        conn = objConexion.abrirConexion
        comando.Connection = conn
        comando.CommandText = "select nombres from Jjv_Datos_Clientes_completo Where nit = " & nit
        reader = comando.ExecuteReader
        If (reader.Read) Then
            If IsDBNull(reader(0)) Then
            Else
                resp = reader(0)
            End If
        Else
            reader.Close()
            comando.Cancel()
            comando.CommandText = "select nombres   from terceros  where   nit= " & nit
            reader = comando.ExecuteReader
            If (reader.Read) Then
                resp = reader(0)
            End If
        End If
        conn.Close()
        Return resp
    End Function


End Class
