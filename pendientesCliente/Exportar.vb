Module Exportar

    Function llenarExcel(ByVal ElGrid As DataGridView) As Boolean

        'Creamos las variables

        ElGrid.Columns(0).Name = "fecha_prod"
        ElGrid.Columns(1).Name = "Hora"
        ElGrid.Columns(2).Name = "Cod_detalle"
        ElGrid.Columns(3).Name = "Numero_orden"
        ElGrid.Columns(4).Name = "Cliente"
        ElGrid.Columns(5).Name = "Maquina"
        ElGrid.Columns(6).Name = "Producto_Final"
        ElGrid.Columns(7).Name = "Operario"
        ElGrid.Columns(8).Name = "Cantidad_Programada"
        ElGrid.Columns(9).Name = "Calidad"
        ElGrid.Columns(10).Name = "Materia_prima"
        ElGrid.Columns(11).Name = "Diametro"
        ElGrid.Columns(12).Name = "Circularidad"
        ElGrid.Columns(13).Name = "Peso"
        ElGrid.Columns(14).Name = "Apariencia"
        ElGrid.Columns(15).Name = "Resistencia"
        ElGrid.Columns(16).Name = "Cash"
        ElGrid.Columns(17).Name = "Elice"


        Dim exApp As New Microsoft.Office.Interop.Excel.Application

        Dim exLibro As Microsoft.Office.Interop.Excel.Workbook

        Dim exHoja As Microsoft.Office.Interop.Excel.Worksheet

        Try

            'Añadimos el Libro al programa, y la hoja al libro

            exLibro = exApp.Workbooks.Add

            exHoja = exLibro.Worksheets.Add()

            ' ¿Cuantas columnas y cuantas filas?

            Dim NCol As Integer = ElGrid.ColumnCount

            Dim NRow As Integer = ElGrid.RowCount

            'Aqui recorremos todas las filas, y por cada fila todas las columnas

            'y vamos escribiendo.

            For i As Integer = 1 To NCol

                exHoja.Cells.Item(1, i) = ElGrid.Columns(i - 1).Name.ToString

            Next

            For Fila As Integer = 0 To NRow - 1

                For Col As Integer = 0 To NCol - 1

                    exHoja.Cells.Item(Fila + 2, Col + 1) = ElGrid.Item(Col, Fila).Value

                Next

            Next

            'Titulo en negrita, Alineado al centro y que el tamaño de la columna

            'se ajuste al texto

            exHoja.Rows.Item(1).Font.Bold = 1

            exHoja.Rows.Item(1).HorizontalAlignment = 3

            exHoja.Columns.AutoFit()

            'Aplicación visible

            exApp.Application.Visible = True

            exHoja = Nothing

            exLibro = Nothing

            exApp = Nothing

        Catch ex As Exception

            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al exportar a Excel")

            Return False

        End Try

        Return True

    End Function

End Module
