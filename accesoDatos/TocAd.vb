Imports System.Data.SqlClient
Imports System.Data
Imports entidadNegocios
Imports System.Data.SqlServerCe
Public Class TocAd
    Public Function toc_detallado() As DataTable
        Dim conn As New SqlConnection
        Dim reader As SqlDataReader
        Dim comando As New SqlCommand
        Dim objConexion As New Conexion
        Dim dmax As Double = 0
        Dim uAkg As Double = 0
        Dim z1 As Double = 0
        Dim amo_kg As Double = 0
        Dim invDisp As Double = 0
        Dim fp As Double = 0
        Dim pend As Double = 0
        Dim amo As Double = 0
        Dim drep As Double = 0
        Dim dt As New DataTable
        Dim dr As DataRow
        Dim codigo As String = ""
        Dim fec As Date = Now.AddYears(-2)
        Dim sql As String = "SELECT codigo,descripcion,ud_a_Kg,fp,cod_mat_prima " & _
                                "FROM j_v_toc"
        Dim sql_valor As String = ""
        dt = construir_table(dt)
        conn = objConexion.abrirConexion_prod
        comando.Connection = conn
        comando.CommandType = CommandType.Text
        comando.CommandText = (sql)
        reader = comando.ExecuteReader
        While reader.Read
            If Not IsDBNull(reader(0)) Then
                dr = dt.NewRow
                codigo = reader("codigo")
                dr("Codigo") = codigo
                dr("Descripcion") = reader("descripcion")
                If Not IsDBNull(reader("ud_a_Kg")) Then
                    uAkg = reader("ud_a_Kg")
                Else
                    uAkg = 0
                End If

                dr("Ud_a_Kg") = uAkg
                If Not IsDBNull(reader("fp")) Then
                    fp = reader("fp")
                End If

                dr("Fp") = fp
                dr("Ref_AlaB-E") = reader("cod_mat_prima")
                sql_valor = "SELECT SUM ( vtas.Kilos ) " & _
                                 "FROM Jjv_V_vtas_vend_cliente_ref vtas  " & _
                                     "WHERE vtas.fec >='" & fec & "' AND vtas.codigo = '" & codigo & "'"
                dr("Total") = Convert.ToDouble(consultar_valor(sql_valor))
                sql_valor = "select AVG (nro_dias ) from V_Relacion_Fecha_ped_Fecha_Desp where codigo = '" & codigo & "'and nro_dias >0"
                drep = consultar_valor(sql_valor)
                dr("Drep") = drep
                sql_valor = "select MAX ( vtas.Kilos )   from Jjv_V_vtas_vend_cliente_ref vtas WHERE fec >='" & fec & "' AND codigo = '" & codigo & "'"
                dmax = Convert.ToDouble(consultar_valor(sql_valor))
                dr("Dmax") = dmax
                amo = (dmax * (drep + (drep * fp)))
                dr("Amo") = amo
                amo_kg = amo * uAkg
                dr("Amo_kg") = amo_kg
                z1 = amo / 3
                dr("Z1") = z1
                dr("Z1_kg") = amo_kg / 3
                dr("Z2") = z1 * 2
                dr("Z2_kg") = (amo_kg / 3) * 2
                dr("Z3") = z1 * 3
                dr("Z3_kg") = (amo_kg / 3) * 3
                sql_valor = "select SUM(KilosPendiente)  FROM  V_pendientes_por_vendedor  where codigo = '" & codigo & "'"
                pend = Convert.ToDouble(consultar_valor(sql_valor))
                dr("Pend") = pend
                dr("Pend_kg") = pend * uAkg
                dt.Rows.Add(dr)
            End If
        End While
        conn.Close()

        Return dt
    End Function
    Private Function construir_table(ByVal dt As DataTable) As DataTable
        dt.Columns.Add("Codigo")
        dt.Columns.Add("Descripcion")
        dt.Columns.Add("Total", GetType(Int64))
        dt.Columns.Add("Ud_a_Kg", GetType(Double))
        dt.Columns.Add("Drep", GetType(Int64))
        dt.Columns.Add("Dmax", GetType(Int64))
        dt.Columns.Add("Fp", GetType(Int64))
        dt.Columns.Add("Amo", GetType(Int64))
        dt.Columns.Add("Amo_kg", GetType(Int64))
        dt.Columns.Add("Z1", GetType(Int64))
        dt.Columns.Add("Z1_kg", GetType(Int64))
        dt.Columns.Add("Z2", GetType(Int64))
        dt.Columns.Add("Z2_kg", GetType(Int64))
        dt.Columns.Add("Z3", GetType(Int64))
        dt.Columns.Add("Z3_kg", GetType(Int64))
        dt.Columns.Add("Inv_p", GetType(Int64))
        dt.Columns.Add("Inv_p_kg", GetType(Int64))
        dt.Columns.Add("Ref_AlaB-E")
        dt.Columns.Add("Inv_AlaB-E", GetType(Int64))
        dt.Columns.Add("Pend", GetType(Int64))
        dt.Columns.Add("Pend_kg", GetType(Int64))
        dt.Columns.Add("Inv_Disp_Kg", GetType(Int64))
        dt.Columns.Add("Inv_ud", GetType(Int64))
        dt.Columns.Add("%", GetType(Int64))
        'dt.Columns.Add("Inv_p_kg", GetType(Int64))
        'dt.Columns.Add("Amo_kg", GetType(Int64))
        dt.Columns.Add("Amo_ud", GetType(Int64))
        dt.Columns.Add("Exceso", GetType(Int64))
        dt.Columns.Add("Exceso_ud", GetType(Int64))



        Return dt
    End Function

    Public Function consultar_valor(ByVal sql As String) As String
        Dim conn As New SqlConnection
        Dim objConexion As New Conexion
        Dim comando As New SqlCommand
        conn = objConexion.abrirConexion
        Dim resp As String = 0
        Dim reader As SqlDataReader
        comando.Connection = conn
        comando.CommandType = CommandType.Text
        comando.CommandText = (sql)
        reader = comando.ExecuteReader
        If reader.Read Then
            If IsDBNull(reader(0)) Then
            Else
                resp = reader(0)
            End If
        End If
        conn.Close()
        Return resp
    End Function
    Public Function ExecuteSqlTransaction(ByVal mat(,) As Object, ByVal filas As Integer) As Boolean
        Dim conn As New SqlConnection
        Dim resp As Boolean = False
        Dim objConexion As New Conexion
        Dim comando As New SqlCommand
        conn = objConexion.abrirConexion_prod
        Dim transaction As SqlTransaction
        Dim sql As String = ""
        ' Start a local transaction
        transaction = conn.BeginTransaction("SampleTransaction")

        ' Must assign both transaction object and connection 
        ' to Command object for a pending local transaction.
        comando.Connection = conn
        comando.Transaction = transaction
        Try
            'comando.CommandText = _
            '  "Insert into Region (RegionID, RegionDescription) VALUES (100, 'Description')"
            'comando.ExecuteNonQuery()
            '' Attempt to commit the transaction.
            For i = 0 To filas - 1
                sql = mat(1, i)
                comando.CommandText = sql
                comando.ExecuteNonQuery()
            Next
            transaction.Commit()
            resp = True
        Catch ex As Exception
            Console.WriteLine("Commit Exception Type: {0}", ex.GetType())
            Console.WriteLine("  Message: {0}", ex.Message)

            ' Attempt to roll back the transaction. 
            Try
                transaction.Rollback()

            Catch ex2 As Exception
                ' This catch block will handle any errors that may have occurred 
                ' on the server that would cause the rollback to fail, such as 
                ' a closed connection.
                Console.WriteLine("Rollback Exception Type: {0}", ex2.GetType())
                Console.WriteLine("  Message: {0}", ex2.Message)
            End Try
        End Try
        Return resp
    End Function
End Class

