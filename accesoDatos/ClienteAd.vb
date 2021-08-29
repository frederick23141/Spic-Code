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
    Public Function listarBusqueda(ByVal cadena As String, ByVal vendedores As String) As DataTable
        conn = objConexion.abrirConexion
        Dim dt As New DataTable
        Dim sql As String = ""
        Dim criterioVendedor As String = ""
          If (vendedores <> "") Then
            criterioVendedor = " vendedor in (" & vendedores & ")"
        Else
            criterioVendedor = " vendedor>=1001 and vendedor<=1099 "
        End If
        Dim DA As New SqlDataAdapter("select nombres,nit from terceros Where nombres like  '%" & cadena & "%' and " & criterioVendedor & " ", conn)
        DA.Fill(dt)
        Return dt
    End Function
    '****************************************************************************************************************
    'Se listan los resultados de el Nit de el cliente****************************************************************
    '****************************************************************************************************************
    Public Function listarCliente(ByVal nit As Double) As DataTable
        conn = objConexion.abrirConexion
        Dim dt As New DataTable
        Dim DA As New SqlDataAdapter("SELECT nombres,Region,TipoCliente,(select Promed_Dias_pago from Jjv_Promedio_dias_pago where nit= " & nit & ") as Promed_Dias_pago,bloqueo,fecha_modificacion,notas,cupo_credito,condicion,vendedor,contacto_1,fecha_creacion,cupo_ant,celular,direccion,ciudad,telefono_1,fax,mail FROM jjv_Datos_clientes_todos where  vendedor >=1001 and vendedor <=1099 and nit=" & nit, conn)
        DA.Fill(dt)
        conn.Close()
        Return dt
    End Function
    Public Function listarClienteTERCEROS(ByVal nit As Double) As DataTable
        conn = objConexion.abrirConexion
        Dim dt As New DataTable
        Dim DA As New SqlDataAdapter("select nombres,Region,TipoCliente,bloqueo,notas,cupo_credito,condicion,vendedor,contacto_1,fecha_creacion,cupo_ant,fecha_modificacion,celular,direccion,ciudad,telefono_1,fax,mail   from jjv_Datos_clientes_todos  where  vendedor >=1001 and vendedor <=1099 and nit=" & nit, conn)
        DA.Fill(dt)
        conn.Close()
        Return dt
    End Function
    '****************************************************************************************************************
    'funcion encargada de verificar si el nit del cliente existe, y devuelve un boolean dependientre el resultado****
    '****************************************************************************************************************

    Public Function existeCliente(ByVal nit As Double) As Boolean
        Dim reader As SqlDataReader
        Dim criterioVendedor As String = ""

        comando.CommandType = CommandType.Text
        conn = objConexion.abrirConexion
        comando.Connection = conn

        comando.CommandText = "SELECT nit FROM jjv_Datos_clientes_todos where nit=" & nit
        reader = comando.ExecuteReader
        While (reader.Read)
            conn.Close()
            Return True
        End While
        Return False
    End Function
    Public Function existeUsuarioTERCEROS(ByVal nit As Double, ByVal vendedores As String) As Boolean
        Dim reader As SqlDataReader
        Dim criterioVendedor As String = ""
        If (vendedores <> "") Then
            criterioVendedor = " vendedor in (" & vendedores & ")"
        Else
            criterioVendedor = " vendedor>=1001 and vendedor<=1099 "
        End If
        comando.CommandType = CommandType.Text
        conn = objConexion.abrirConexion
        comando.Connection = conn
        comando.CommandText = "SELECT nit FROM terceros where nit=" & nit & " AND " & criterioVendedor
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
        Dim sql As String = ""
        comando.CommandType = CommandType.Text
        conn = objConexion.abrirConexion
        comando.Connection = conn
        sql = "SELECT cupo_credito,condicion FROM terceros where nit=" & nit
        comando.CommandText = sql
        reader = comando.ExecuteReader
        While (reader.Read)
            If (reader("condicion") = 201 Or reader("condicion") = 208 Or reader("condicion") = 202) Then
                cupo = reader(0)
            Else
                cupo = reader(0)
                If (cupo <> 0) Then
                    If (cupo >= 100000 And cupo <= 20000000) Then
                        cupo = cupo * 1.3
                    ElseIf (cupo >= 21000000 And cupo <= 40000000) Then
                        cupo = cupo * 1.2
                    ElseIf (cupo >= 41000000 And cupo <= 80000000) Then
                        cupo = cupo * 1.1
                    End If
                End If
            End If

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
    Public Function mayVenta(ByVal nit As Double, ByVal fec_fin As String) As Double
        Dim resultMayVenta As Double = 0
        Dim reader As SqlDataReader
        comando.CommandType = CommandType.Text
        conn = objConexion.abrirConexion
        comando.Connection = conn
        Dim sql As String = "Select valor=max(VALOR_TOTAL) from documentos WHERE SW=1 AND NIT=" & nit & "and fecha >='" & fec_fin & " 00:00:00.000'and vendedor >=1001 and vendedor <=1099"
        comando.CommandText = sql
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
        comando.CommandText = "select nombres from jjv_Datos_clientes_todos Where nit = " & nit
        reader = comando.ExecuteReader
        If (reader.Read) Then
            If IsDBNull(reader(0)) Then
            Else
                resp = reader(0)
            End If
        Else
            reader.Close()
            comando.Cancel()
            comando.CommandText = "select nombres from jjv_Datos_clientes_todos  where   nit= " & nit
            reader = comando.ExecuteReader
            If (reader.Read) Then
                resp = reader(0)
            End If
        End If
        conn.Close()
        Return resp
    End Function
    Public Function getVendedor(ByVal nit As Double) As String
        Dim vendedor As Int32 = 0
        Dim reader As SqlDataReader
        comando.CommandType = CommandType.Text
        conn = objConexion.abrirConexion
        comando.Connection = conn
        comando.CommandText = "Select vendedor from terceros WHERE NIT=" & nit
        reader = comando.ExecuteReader
        While (reader.Read)
            If IsDBNull(reader(0)) Then
            Else
                vendedor = reader(0)
            End If

        End While
        conn.Close()
        Return vendedor
    End Function

End Class
