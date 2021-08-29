Imports System.Data.SqlClient
Imports System.Data
Imports entidadNegocios
Public Class carteraAd
    '****************************************************************************************************************
    'Se crean los parametros para la conexion ***********************************************************************
    '****************************************************************************************************************
    Private conn As New SqlConnection
    Private comando As New SqlCommand
    Dim objConexion As New Conexion
    '****************************************************************************************************************
    'Se Listan los datos de la cartera ***********************************************************************
    '****************************************************************************************************************
    Public Function listarCartera(ByVal nit As Double) As DataTable
        conn = objConexion.abrirConexion
        Dim dt As New DataTable
        Dim DA As New SqlDataAdapter("SELECT Tipo, Numero, Fecha, Vencimiento, Valor_Total, Valor_Aplicado, Saldo, Dias_Vencido, Sin_Vencer, de_1_a_30, de_31_a_60, de_61_a_90, de_91_a_120, Mas_de_120  FROM V_cartera_edades_jjv where nit=" & nit & " and saldo <> 0 ORDER BY fecha DESC", conn)
        DA.Fill(dt)
        conn.Close()
        Return dt
    End Function
    '****************************************************************************************************************
    'Funcion encargada se sumar los valores totales******************************************************************
    '****************************************************************************************************************
    Public Function sumarValorTot(ByVal nit As Double) As Double
        Dim suma As Double
        Dim reader As SqlDataReader
        conn = objConexion.abrirConexion
        comando.Connection = conn
        comando.CommandType = CommandType.Text
        comando.CommandText = ("SELECT  ROUND(SUM(Valor_Total) , 0 ) FROM V_cartera_edades_jjv  where nit=" & nit & "and saldo <> 0")
        reader = comando.ExecuteReader
        While reader.Read
            If IsDBNull(reader(0)) Then
            Else
                suma = reader(0)
            End If

        End While
        conn.Close()
        Return suma
    End Function
    '****************************************************************************************************************
    'Funcion encargada se sumar los valores aplicados****************************************************************
    '****************************************************************************************************************
    Public Function sumarValorAplicado(ByVal nit As Double) As Double
        Dim suma As Double
        Dim reader As SqlDataReader
        conn = objConexion.abrirConexion
        comando.Connection = conn
        comando.CommandType = CommandType.Text
        comando.CommandText = ("SELECT  ROUND(SUM(Valor_Aplicado),0) FROM V_cartera_edades_jjv where nit=" & nit & "and saldo <> 0")
        reader = comando.ExecuteReader
        While reader.Read
            If IsDBNull(reader(0)) Then
            Else
                suma = reader(0)
            End If
        End While
        conn.Close()
        Return suma
    End Function
    '****************************************************************************************************************
    'Funcion encargada se sumar los saldos***************************************************************************
    '****************************************************************************************************************
    Public Function sumarSaldo(ByVal nit As Double) As Double
        Dim suma As Double
        Dim reader As SqlDataReader
        conn = objConexion.abrirConexion
        comando.Connection = conn
        comando.CommandType = CommandType.Text
        comando.CommandText = ("SELECT  ROUND(SUM(Saldo),0) FROM V_cartera_edades_jjv where nit=" & nit & "and saldo <> 0")
        reader = comando.ExecuteReader
        While reader.Read
            If IsDBNull(reader(0)) Then
            Else
                suma = reader(0)
            End If
        End While
        conn.Close()
        Return suma
    End Function
    '****************************************************************************************************************
    'Funcion encargada se sumar El campo sin vencer******************************************************************
    '****************************************************************************************************************
    Public Function sumarSinVencer(ByVal nit As Double) As Double
        Dim suma As Double
        Dim reader As SqlDataReader
        conn = objConexion.abrirConexion
        comando.Connection = conn
        comando.CommandType = CommandType.Text
        comando.CommandText = ("SELECT  ROUND(SUM(Sin_Vencer),0) FROM V_cartera_edades_jjv where nit=" & nit & "and saldo <> 0")
        reader = comando.ExecuteReader
        While reader.Read
            If IsDBNull(reader(0)) Then
            Else
                suma = reader(0)
            End If
        End While
        conn.Close()
        Return suma
    End Function
    '****************************************************************************************************************
    'Funcion encargada se sumar los valores de el campo de_1_a_30****************************************************
    '****************************************************************************************************************
    Public Function sumar1a30(ByVal nit As Double) As Double
        Dim suma As Double
        Dim reader As SqlDataReader
        conn = objConexion.abrirConexion
        comando.Connection = conn
        comando.CommandType = CommandType.Text
        comando.CommandText = ("SELECT  ROUND(SUM(de_1_a_30),0) FROM V_cartera_edades_jjv where nit=" & nit & "and saldo <> 0")
        reader = comando.ExecuteReader
        While reader.Read
            If IsDBNull(reader(0)) Then
            Else
                suma = reader(0)
            End If
        End While
        conn.Close()
        Return suma
    End Function
    '****************************************************************************************************************
    'Funcion encargada se sumar los valores de el campo de_31_a_60****************************************************
    '****************************************************************************************************************
    Public Function sumar31a60(ByVal nit As Double) As Double
        Dim suma As Double
        Dim reader As SqlDataReader
        conn = objConexion.abrirConexion
        comando.Connection = conn
        comando.CommandType = CommandType.Text
        comando.CommandText = ("SELECT  ROUND(SUM(de_31_a_60),0) FROM V_cartera_edades_jjv where nit=" & nit & "and saldo <> 0")
        reader = comando.ExecuteReader
        While reader.Read
            If IsDBNull(reader(0)) Then
            Else
                suma = reader(0)
            End If
        End While
        conn.Close()
        Return suma
    End Function
    '****************************************************************************************************************
    'Funcion encargada se sumar los valores de el campo de_61_a_90****************************************************
    '****************************************************************************************************************
    Public Function sumar61a91(ByVal nit As Double) As Double
        Dim suma As Double
        Dim reader As SqlDataReader
        conn = objConexion.abrirConexion
        comando.Connection = conn
        comando.CommandType = CommandType.Text
        comando.CommandText = ("SELECT  ROUND(SUM(de_61_a_90),0) FROM V_cartera_edades_jjv where nit=" & nit & "and saldo <> 0")
        reader = comando.ExecuteReader
        While reader.Read
            If IsDBNull(reader(0)) Then
            Else
                suma = reader(0)
            End If
        End While
        conn.Close()
        Return suma
    End Function
    '****************************************************************************************************************
    'Funcion encargada se sumar los valores de el campo de_91_a_120****************************************************
    '****************************************************************************************************************
    Public Function sumar91a120(ByVal nit As Double) As Double
        Dim suma As Double
        Dim reader As SqlDataReader
        conn = objConexion.abrirConexion
        comando.Connection = conn
        comando.CommandType = CommandType.Text
        comando.CommandText = ("SELECT  ROUND(SUM(de_91_a_120),0) FROM V_cartera_edades_jjv where nit=" & nit & "and saldo <> 0")
        reader = comando.ExecuteReader
        While reader.Read
            If IsDBNull(reader(0)) Then
            Else
                suma = reader(0)
            End If
        End While
        conn.Close()
        Return suma
    End Function
    '****************************************************************************************************************
    'Funcion encargada se sumar los valores de campo  Mas_de_120*****************************************************
    '****************************************************************************************************************
    Public Function sumarMas120(ByVal nit As Double) As Double
        Dim suma As Double
        Dim reader As SqlDataReader
        conn = objConexion.abrirConexion
        comando.Connection = conn
        comando.CommandType = CommandType.Text
        comando.CommandText = ("SELECT  ROUND(SUM(Mas_de_120),0) FROM V_cartera_edades_jjv where nit=" & nit & "and saldo <> 0")
        reader = comando.ExecuteReader
        While reader.Read
            If IsDBNull(reader(0)) Then
            Else
                suma = reader(0)
            End If
        End While
        conn.Close()
        Return suma
    End Function
    


End Class
