Imports System.IO
Imports System.Collections.Generic
Imports Microsoft.Office.Interop
Imports logicaNegocios

Public Class OperacionesFormularios
    Dim objOpSimplesLn As New Op_simpesLn
    Public Sub ExportarDatosExcel(ByVal DataGridView1 As DataGridView, ByVal titulo As String)
        If DataGridView1.RowCount > 1 Then
            Dim m_Excel As New Excel.Application
            m_Excel.Cursor = Excel.XlMousePointer.xlWait
            m_Excel.Visible = True
            Dim objLibroExcel As Excel.Workbook = m_Excel.Workbooks.Add
            Dim objHojaExcel As Excel.Worksheet = objLibroExcel.Worksheets(1)
            With objHojaExcel
                .Visible = Excel.XlSheetVisibility.xlSheetVisible
                .Activate()
                'Encabezado  
                .Range("A1:L1").Merge()
                .Range("A1:L1").Value = "CORSAN"
                .Range("A1:L1").Font.Bold = True
                .Range("A1:L1").Font.Size = 15
                'Copete  
16:             .Range("A2:L2").Merge()
17:             .Range("A2:L2").Value = titulo
18:             .Range("A2:L2").Font.Bold = True
19:             .Range("A2:L2").Font.Size = 12
20:
21:             Const primeraLetra As Char = "A"
22:             Const primerNumero As Short = 3
23:             Dim Letra As Char, UltimaLetra As Char
24:             Dim Numero As Integer, UltimoNumero As Integer
25:             Dim cod_letra As Byte = Asc(primeraLetra) - 1
26:             Dim sepDec As String = Application.CurrentCulture.NumberFormat.NumberDecimalSeparator
27:             Dim sepMil As String = Application.CurrentCulture.NumberFormat.NumberGroupSeparator
28:             'Establecer formatos de las columnas de la hija de cálculo  
29:             Dim strColumna As String = ""
30:             Dim LetraIzq As String = ""
31:             Dim cod_LetraIzq As Byte = Asc(primeraLetra) - 1
32:             Letra = primeraLetra
33:             Numero = primerNumero
34:             Dim objCelda As Excel.Range
35:             For Each c As DataGridViewColumn In DataGridView1.Columns
36:                 If c.Visible Then
37:                     If Letra = "Z" Then
38:                         Letra = primeraLetra
39:                         cod_letra = Asc(primeraLetra)
40:                         cod_LetraIzq += 1
41:                         LetraIzq = Chr(cod_LetraIzq)
42:                     Else
43:                         cod_letra += 1
44:                         Letra = Chr(cod_letra)
45:                     End If
46:                     strColumna = LetraIzq + Letra + Numero.ToString
47:                     objCelda = .Range(strColumna, Type.Missing)
48:                     objCelda.Value = c.HeaderText
49:                     objCelda.EntireColumn.Font.Size = 8
50:                     'objCelda.EntireColumn.NumberFormat = c.DefaultCellStyle.Format  
51:                     If c.ValueType Is GetType(Decimal) OrElse c.ValueType Is GetType(Double) Then
52:                         objCelda.EntireColumn.NumberFormat = "#" + sepMil + "0" + sepDec + "00"
53:                     End If
54:                 End If
55:             Next
56:
57:             Dim objRangoEncab As Excel.Range = .Range(primeraLetra + Numero.ToString, LetraIzq + Letra + Numero.ToString)
58:             objRangoEncab.BorderAround(1, Excel.XlBorderWeight.xlMedium)
59:             UltimaLetra = Letra
60:             Dim UltimaLetraIzq As String = LetraIzq
61:
62:             'CARGA DE DATOS  
63:             Dim i As Integer = Numero + 1
64:
65:             For Each reg As DataGridViewRow In DataGridView1.Rows
66:                 LetraIzq = ""
67:                 cod_LetraIzq = Asc(primeraLetra) - 1
68:                 Letra = primeraLetra
69:                 cod_letra = Asc(primeraLetra) - 1
70:                 For Each c As DataGridViewColumn In DataGridView1.Columns
71:                     If c.Visible Then
72:                         If Letra = "Z" Then
73:                             Letra = primeraLetra
74:                             cod_letra = Asc(primeraLetra)
75:                             cod_LetraIzq += 1
76:                             LetraIzq = Chr(cod_LetraIzq)
77:                         Else
78:                             cod_letra += 1
79:                             Letra = Chr(cod_letra)
80:                         End If
81:                         strColumna = LetraIzq + Letra
82:                         ' acá debería realizarse la carga  
83:                         .Cells(i, strColumna) = IIf(IsDBNull(reg.ToString), "", reg.Cells(c.Index).Value)
84:                         '.Cells(i, strColumna) = IIf(IsDBNull(reg.(c.DataPropertyName)), c.DefaultCellStyle.NullValue, reg(c.DataPropertyName))  
85:                         '.Range(strColumna + i, strColumna + i).In()  
86:
87:                     End If
88:                 Next
89:                 Dim objRangoReg As Excel.Range = .Range(primeraLetra + i.ToString, strColumna + i.ToString)
90:                 objRangoReg.Rows.BorderAround()
91:                 objRangoReg.Select()
92:                 i += 1
93:             Next
94:             UltimoNumero = i
95:
96:             'Dibujar las líneas de las columnas  
                LetraIzq = ""
                cod_LetraIzq = Asc("A")
                cod_letra = Asc(primeraLetra)
                Letra = primeraLetra
                For Each c As DataGridViewColumn In DataGridView1.Columns
                    If c.Visible Then
                        objCelda = .Range(LetraIzq + Letra + primerNumero.ToString, LetraIzq + Letra + (UltimoNumero - 1).ToString)
                        objCelda.BorderAround()
                        If Letra = "Z" Then
                            Letra = primeraLetra
                            cod_letra = Asc(primeraLetra)
                            LetraIzq = Chr(cod_LetraIzq)
                            cod_LetraIzq += 1
                        Else
                            cod_letra += 1
                            Letra = Chr(cod_letra)
                        End If
                    End If
                Next

                'Dibujar el border exterior grueso  
                Dim objRango As Excel.Range = .Range(primeraLetra + primerNumero.ToString, UltimaLetraIzq + UltimaLetra + (UltimoNumero - 1).ToString)
                objRango.Select()
                objRango.Columns.AutoFit()
                objRango.Columns.BorderAround(1, Excel.XlBorderWeight.xlMedium)
            End With
            m_Excel.Cursor = Excel.XlMousePointer.xlDefault
        Else
            MessageBox.Show("No hay nada para exportar", "Nada para exportar", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
    Public Sub ExportarDatosExcel_eval(ByVal DataGridView1 As DataGridView, ByVal titulo As String, ByVal evaluado As String, ByVal evaluador As String, ByVal ante As String, ByVal ned As String, ByVal calificacion As String, ByVal obser As String)
        If DataGridView1.RowCount > 1 Then
            Dim m_Excel As New Excel.Application
            m_Excel.Cursor = Excel.XlMousePointer.xlWait
            m_Excel.Visible = True
            Dim objLibroExcel As Excel.Workbook = m_Excel.Workbooks.Add
            Dim objHojaExcel As Excel.Worksheet = objLibroExcel.Worksheets(1)
            With objHojaExcel
                .Visible = Excel.XlSheetVisibility.xlSheetVisible
                .Activate()
                'Encabezado  
                .Range("A1:B1").Merge()
                .Range("A1:B1").Value = "CORSAN"
                .Range("A1:B1").Font.Bold = True
                .Range("A1:B1").Font.Size = 15

                'Copete  
                .Range("A2:B2").Merge()
                .Range("A2:B2").Value = "Tipo Evaluacion: " & titulo
                .Range("A2:B2").Font.Bold = True
                .Range("A2:B2").Font.Size = 12

                'Evaluado  
                .Range("A3:B3").Merge()
                .Range("A3:B3").Value = "Evaluado: " & evaluado
                .Range("A3:B3").Font.Bold = True
                .Range("A3:B3").Font.Size = 11

                'Evaluador  
                .Range("A4:B4").Merge()
                .Range("A4:B4").Value = "Evaluador: " & evaluador
                .Range("A4:B4").Font.Bold = False
                .Range("A4:B4").Font.Size = 11

                'ANTIGUEDAD  
                .Range("A5:B5").Merge()
                .Range("A5:B5").Value = "Antigüedad: " & ante
                .Range("A5:B5").Font.Bold = False
                .Range("A5:B5").Font.Size = 11

                'nivel educativo
                .Range("A6:B6").Merge()
                .Range("A6:B6").Value = "Nivel educativo: " & ned
                .Range("A6:B6").Font.Bold = False
                .Range("A6:B6").Font.Size = 11

                'Calificacion
                .Range("A7:B7").Merge()
                .Range("A7:B7").Value = "Calificacion: " & calificacion
                .Range("A7:B7").Font.Bold = False
                .Range("A7:B7").Font.Size = 11

21:             Const primeraLetra As Char = "A"
22:             Const primerNumero As Short = 8
23:             Dim Letra As Char, UltimaLetra As Char
24:             Dim Numero As Integer, UltimoNumero As Integer
25:             Dim cod_letra As Byte = Asc(primeraLetra) - 1
26:             Dim sepDec As String = Application.CurrentCulture.NumberFormat.NumberDecimalSeparator
27:             Dim sepMil As String = Application.CurrentCulture.NumberFormat.NumberGroupSeparator
28:             'Establecer formatos de las columnas de la hija de cálculo  
29:             Dim strColumna As String = ""
30:             Dim LetraIzq As String = ""
31:             Dim cod_LetraIzq As Byte = Asc(primeraLetra) - 1
32:             Letra = primeraLetra
33:             Numero = primerNumero
34:             Dim objCelda As Excel.Range
35:             For Each c As DataGridViewColumn In DataGridView1.Columns
36:                 If c.Visible Then
37:                     If Letra = "Z" Then
38:                         Letra = primeraLetra
39:                         cod_letra = Asc(primeraLetra)
40:                         cod_LetraIzq += 1
41:                         LetraIzq = Chr(cod_LetraIzq)
42:                     Else
43:                         cod_letra += 1
44:                         Letra = Chr(cod_letra)
45:                     End If
46:                     strColumna = LetraIzq + Letra + Numero.ToString
47:                     objCelda = .Range(strColumna, Type.Missing)
48:                     objCelda.Value = c.HeaderText
49:                     objCelda.EntireColumn.Font.Size = 8
50:                     'objCelda.EntireColumn.NumberFormat = c.DefaultCellStyle.Format  
51:                     If c.ValueType Is GetType(Decimal) OrElse c.ValueType Is GetType(Double) Then
52:                         objCelda.EntireColumn.NumberFormat = "#" + sepMil + "0" + sepDec + "00"
53:                     End If
54:                 End If
55:             Next
56:
57:             Dim objRangoEncab As Excel.Range = .Range(primeraLetra + Numero.ToString, LetraIzq + Letra + Numero.ToString)
58:             objRangoEncab.BorderAround(1, Excel.XlBorderWeight.xlMedium)
59:             UltimaLetra = Letra
60:             Dim UltimaLetraIzq As String = LetraIzq
61:
62:             'CARGA DE DATOS  
63:             Dim i As Integer = Numero + 1
64:
65:             For Each reg As DataGridViewRow In DataGridView1.Rows
66:                 LetraIzq = ""
67:                 cod_LetraIzq = Asc(primeraLetra) - 1
68:                 Letra = primeraLetra
69:                 cod_letra = Asc(primeraLetra) - 1
70:                 For Each c As DataGridViewColumn In DataGridView1.Columns
71:                     If c.Visible Then
72:                         If Letra = "Z" Then
73:                             Letra = primeraLetra
74:                             cod_letra = Asc(primeraLetra)
75:                             cod_LetraIzq += 1
76:                             LetraIzq = Chr(cod_LetraIzq)
77:                         Else
78:                             cod_letra += 1
79:                             Letra = Chr(cod_letra)
80:                         End If
81:                         strColumna = LetraIzq + Letra
82:                         ' acá debería realizarse la carga  
83:                         .Cells(i, strColumna) = IIf(IsDBNull(reg.ToString), "", reg.Cells(c.Index).Value)
84:                         '.Cells(i, strColumna) = IIf(IsDBNull(reg.(c.DataPropertyName)), c.DefaultCellStyle.NullValue, reg(c.DataPropertyName))  
85:                         '.Range(strColumna + i, strColumna + i).In()  
86:
87:                     End If
88:                 Next
89:                 Dim objRangoReg As Excel.Range = .Range(primeraLetra + i.ToString, strColumna + i.ToString)
90:                 objRangoReg.Rows.BorderAround()
91:                 objRangoReg.Select()
92:                 i += 1
93:             Next
94:             UltimoNumero = i
95:
96:             'Dibujar las líneas de las columnas  
                LetraIzq = ""
                cod_LetraIzq = Asc("A")
                cod_letra = Asc(primeraLetra)
                Letra = primeraLetra
                For Each c As DataGridViewColumn In DataGridView1.Columns
                    If c.Visible Then
                        objCelda = .Range(LetraIzq + Letra + primerNumero.ToString, LetraIzq + Letra + (UltimoNumero - 1).ToString)
                        objCelda.BorderAround()
                        If Letra = "Z" Then
                            Letra = primeraLetra
                            cod_letra = Asc(primeraLetra)
                            LetraIzq = Chr(cod_LetraIzq)
                            cod_LetraIzq += 1
                        Else
                            cod_letra += 1
                            Letra = Chr(cod_letra)
                        End If
                    End If
                Next

                'Dibujar el border exterior grueso  
                Dim objRango As Excel.Range = .Range(primeraLetra + primerNumero.ToString, UltimaLetraIzq + UltimaLetra + (UltimoNumero - 1).ToString)
                objRango.Select()
                objRango.Columns.AutoFit()
                objRango.Columns.BorderAround(1, Excel.XlBorderWeight.xlMedium)

                i = UltimoNumero + 1
                .Range("A" & i & ":A" & i).Merge()
                .Range("A" & i & ":A" & i).Value = "Observaciones:"
                .Range("A" & i & ":A" & i).Font.Bold = False
                .Range("A" & i & ":A" & i).Font.Size = 11

                .Range("B" & i & ":B" & i).Merge()
                .Range("B" & i & ":B" & i).Value = obser
                .Range("B" & i & ":B" & i).Font.Bold = False
                .Range("B" & i & ":B" & i).Font.Size = 11

                'Calificacion
                i = UltimoNumero + 3
                .Range("A" & i & ":A" & i).Merge()
                .Range("A" & i & ":A" & i).Value = "Exelente = 5"
                .Range("A" & i & ":A" & i).Font.Bold = False
                .Range("A" & i & ":A" & i).Font.Size = 11
                i += 1
                .Range("A" & i & ":A" & i).Merge()
                .Range("A" & i & ":A" & i).Value = "Bueno = 4"
                .Range("A" & i & ":A" & i).Font.Bold = False
                .Range("A" & i & ":A" & i).Font.Size = 11
                i += 1
                .Range("A" & i & ":A" & i).Merge()
                .Range("A" & i & ":A" & i).Value = "Regular = 3"
                .Range("A" & i & ":A" & i).Font.Bold = False
                .Range("A" & i & ":A" & i).Font.Size = 11
                i += 1
                .Range("A" & i & ":A" & i).Merge()
                .Range("A" & i & ":A" & i).Value = "Malo = 2"
                .Range("A" & i & ":A" & i).Font.Bold = False
                .Range("A" & i & ":A" & i).Font.Size = 11
                i += 1
                .Range("A" & i & ":A" & i).Merge()
                .Range("A" & i & ":A" & i).Value = "Deficiente = 1"
                .Range("A" & i & ":A" & i).Font.Bold = False
                .Range("A" & i & ":A" & i).Font.Size = 11

                i = UltimoNumero + 3
                .Range("B" & i & ":B" & i).Merge()
                .Range("B" & i & ":B" & i).Value = "Retiro de la compañia = (1 - 1.9)"
                .Range("B" & i & ":B" & i).Font.Bold = False
                .Range("B" & i & ":B" & i).Font.Size = 11
                i += 1
                .Range("B" & i & ":B" & i).Merge()
                .Range("B" & i & ":B" & i).Value = "Evaluacion exaustiva de mejoramiento (2 meses) = (2 - 2.9)"
                .Range("B" & i & ":B" & i).Font.Bold = False
                .Range("B" & i & ":B" & i).Font.Size = 11
                i += 1
                .Range("B" & i & ":B" & i).Merge()
                .Range("B" & i & ":B" & i).Value = "Plan de mejoramiento con enfafsis (evalucación al año) = (3 - 3.9)"
                .Range("B" & i & ":B" & i).Font.Bold = False
                .Range("B" & i & ":B" & i).Font.Size = 11
                i += 1
                .Range("B" & i & ":B" & i).Merge()
                .Range("B" & i & ":B" & i).Value = "Se evalua cada dos años = (4 - 5)"
                .Range("B" & i & ":B" & i).Font.Bold = False
                .Range("B" & i & ":B" & i).Font.Size = 11
            End With
            m_Excel.Cursor = Excel.XlMousePointer.xlDefault
        Else
            MessageBox.Show("No hay nada para exportar", "Nada para exportar", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private StrFormat As StringFormat         ' Holds content of a TextBox Cell to write by DrawString
    Private StrFormatComboBox As StringFormat ' Holds content of a Boolean Cell to write by DrawImage
    Private CellButton As Button          ' Holds the Contents of Button Cell
    Private CellCheckBox As CheckBox      ' Holds the Contents of CheckBox Cell
    Private CellComboBox As ComboBox      ' Holds the Contents of ComboBox Cell

    Private TotalWidth As Int16           ' Summation of Columns widths
    Private RowPos As Int16               ' Position of currently printing row 
    Private NewPage As Boolean            ' Indicates if a new page reached 
    Private PageNo As Int16               ' Number of pages to print 
    Private ColumnLefts As New ArrayList  ' Left Coordinate of Columns
    Private ColumnWidths As New ArrayList ' Width of Columns
    Private ColumnTypes As New ArrayList  ' DataType of Columns
    Private CellHeight As Int16           ' Height of DataGrid Cell
    Private RowsPerPage As Int16          ' Number of Rows per Page 
    Private WithEvents PrintDoc As New System.Drawing.Printing.PrintDocument ' PrintDocumnet Object used for printing

    Private PrintTitle As String = ""               ' Header of pages
    Private dgv As DataGridView                     ' Holds DataGrid Object to print its contents
    Private SelectedColumns As New List(Of String)  ' The Columns Selected by user to print.
    Private AvailableColumns As New List(Of String) ' All Columns avaiable in DataGrid   
    Private PrintAllRows As Boolean = True          ' True = print all rows,  False = print selected rows    
    Private FitToPageWidth As Boolean = True        ' True = Fits selected columns to page width ,  False = Print columns as showed    
    Private HeaderHeight As Int16 = 0

    Public Sub Print_DataGridView(ByVal dgv1 As DataGridView, ByVal info As String)
        Dim ppvw As PrintPreviewDialog
        Try
            ' Getting DataGridView object to print
            dgv = dgv1

            ' Getting all Coulmns Names in the DataGridView
            AvailableColumns.Clear()
            For Each c As DataGridViewColumn In dgv.Columns
                If Not c.Visible Then Continue For
                AvailableColumns.Add(c.HeaderText)
            Next

            ' Showing the PrintOption Form
            Dim dlg As New PrintOptions(AvailableColumns, info)
            If dlg.ShowDialog() <> DialogResult.OK Then Exit Sub

            ' Saving some printing attributes
            PrintTitle = dlg.PrintTitle
            PrintAllRows = dlg.PrintAllRows
            FitToPageWidth = dlg.FitToPageWidth
            SelectedColumns = dlg.GetSelectedColumns

            RowsPerPage = 0
            ppvw = New PrintPreviewDialog
            ppvw.Document = PrintDoc

            ' Showing the Print Preview Page
            If ppvw.ShowDialog() <> DialogResult.OK Then Exit Sub
            ' Printing the Documnet
            PrintDoc.Print()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally

        End Try
    End Sub

    Private Sub PrintDoc_BeginPrint(ByVal sender As Object, _
                ByVal e As System.Drawing.Printing.PrintEventArgs) Handles PrintDoc.BeginPrint
        Try
            ' Formatting the Content of Text Cells to print
            StrFormat = New StringFormat
            StrFormat.Alignment = StringAlignment.Near
            StrFormat.LineAlignment = StringAlignment.Center
            StrFormat.Trimming = StringTrimming.EllipsisCharacter

            ' Formatting the Content of Combo Cells to print
            StrFormatComboBox = New StringFormat
            StrFormatComboBox.LineAlignment = StringAlignment.Center
            StrFormatComboBox.FormatFlags = StringFormatFlags.NoWrap
            StrFormatComboBox.Trimming = StringTrimming.EllipsisCharacter

            ColumnLefts.Clear()
            ColumnWidths.Clear()
            ColumnTypes.Clear()
            CellHeight = 0
            RowsPerPage = 0

            ' For various column types
            CellButton = New Button
            CellCheckBox = New CheckBox
            CellComboBox = New ComboBox

            TotalWidth = 0
            For Each GridCol As DataGridViewColumn In dgv.Columns
                If Not GridCol.Visible Then Continue For
                If Not SelectedColumns.Contains(GridCol.HeaderText) Then Continue For
                TotalWidth += GridCol.Width
            Next
            PageNo = 1
            NewPage = True
            RowPos = 0
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally

        End Try
    End Sub

    Private Sub PrintDoc_PrintPage(ByVal sender As Object, _
            ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDoc.PrintPage

        Dim tmpWidth As Int16, i As Int16
        Dim tmpTop As Int16 = e.MarginBounds.Top
        Dim tmpLeft As Int16 = e.MarginBounds.Left

        Try
            ' Before starting first page, it saves Width & Height of Headers and CoulmnType
            If PageNo = 1 Then
                For Each GridCol As DataGridViewColumn In dgv.Columns
                    If Not GridCol.Visible Then Continue For
                    If Not SelectedColumns.Contains(GridCol.HeaderText) Then
                        Continue For
                    End If

                    ' Detemining whether the columns are fitted to page or not.
                    If FitToPageWidth Then
                        tmpWidth = CType(Math.Floor(GridCol.Width / TotalWidth * _
                                   TotalWidth * (e.MarginBounds.Width / TotalWidth)), Int16)
                    Else
                        tmpWidth = GridCol.Width
                    End If
                    HeaderHeight = e.Graphics.MeasureString(GridCol.HeaderText, _
                                   GridCol.InheritedStyle.Font, tmpWidth).Height + 11

                    ColumnLefts.Add(tmpLeft)
                    ColumnWidths.Add(tmpWidth)
                    ColumnTypes.Add(GridCol.GetType)
                    tmpLeft += tmpWidth
                Next
            End If

            ' Printing Current Page, Row by Row
            Do While RowPos <= dgv.Rows.Count - 1
                Dim GridRow As DataGridViewRow = dgv.Rows(RowPos)
                If GridRow.IsNewRow OrElse (Not PrintAllRows AndAlso Not GridRow.Selected) Then
                    RowPos += 1 : Continue Do
                End If

                CellHeight = GridRow.Height

                If tmpTop + CellHeight >= e.MarginBounds.Height + e.MarginBounds.Top Then
                    DrawFooter(e, RowsPerPage)
                    NewPage = True
                    PageNo += 1
                    e.HasMorePages = True
                    Exit Sub
                Else
                    If NewPage Then
                        ' Draw Header
                        e.Graphics.DrawString(PrintTitle, New Font(dgv.Font, FontStyle.Bold), _
                                Brushes.Black, e.MarginBounds.Left, e.MarginBounds.Top - _
                        e.Graphics.MeasureString(PrintTitle, New Font(dgv.Font, _
                                FontStyle.Bold), e.MarginBounds.Width).Height - 13)

                        Dim s As String = Now.ToLongDateString + " " + Now.ToShortTimeString

                        e.Graphics.DrawString(s, New Font(dgv.Font, FontStyle.Bold), _
                           Brushes.Black, e.MarginBounds.Left + (e.MarginBounds.Width - _
                           e.Graphics.MeasureString(s, New Font(dgv.Font, FontStyle.Bold), _
                           e.MarginBounds.Width).Width), e.MarginBounds.Top - _
                           e.Graphics.MeasureString(PrintTitle, _
                           New Font(New Font(dgv.Font, FontStyle.Bold), FontStyle.Bold), _
                           e.MarginBounds.Width).Height - 13)

                        ' Draw Columns
                        tmpTop = e.MarginBounds.Top
                        i = 0
                        For Each GridCol As DataGridViewColumn In dgv.Columns
                            If Not GridCol.Visible Then Continue For
                            If Not SelectedColumns.Contains(GridCol.HeaderText) Then
                                Continue For
                            End If

                            e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightGray), _
                                    New Rectangle(ColumnLefts(i), tmpTop, ColumnWidths(i), HeaderHeight))

                            e.Graphics.DrawRectangle(Pens.Black, New Rectangle(ColumnLefts(i), _
                                    tmpTop, ColumnWidths(i), HeaderHeight))

                            e.Graphics.DrawString(GridCol.HeaderText, GridCol.InheritedStyle.Font, _
                                    New SolidBrush(GridCol.InheritedStyle.ForeColor), _
                                    New RectangleF(ColumnLefts(i), tmpTop, ColumnWidths(i), _
                                    HeaderHeight), StrFormat)
                            i += 1
                        Next
                        NewPage = False

                        tmpTop += HeaderHeight
                    End If

                    i = 0
                    For Each Cel As DataGridViewCell In GridRow.Cells
                        If Not Cel.OwningColumn.Visible Then Continue For
                        If Not SelectedColumns.Contains(Cel.OwningColumn.HeaderText) Then
                            Continue For
                        End If

                        ' For the TextBox Column
                        If ColumnTypes(i) Is GetType(DataGridViewTextBoxColumn) OrElse _
                           ColumnTypes(i) Is GetType(DataGridViewLinkColumn) Then

                            e.Graphics.DrawString(Cel.Value.ToString, Cel.InheritedStyle.Font, _
                                    New SolidBrush(Cel.InheritedStyle.ForeColor), _
                                    New RectangleF(ColumnLefts(i), tmpTop, ColumnWidths(i), _
                                    CellHeight), StrFormat)

                            ' For the Button Column
                        ElseIf ColumnTypes(i) Is GetType(DataGridViewButtonColumn) Then

                            CellButton.Text = Cel.Value.ToString
                            CellButton.Size = New Size(ColumnWidths(i), CellHeight)
                            Dim bmp As New Bitmap(CellButton.Width, CellButton.Height)
                            CellButton.DrawToBitmap(bmp, New Rectangle(0, 0, _
                                    bmp.Width, bmp.Height))
                            e.Graphics.DrawImage(bmp, New Point(ColumnLefts(i), tmpTop))

                            ' For the CheckBox Column
                        ElseIf ColumnTypes(i) Is GetType(DataGridViewCheckBoxColumn) Then

                            CellCheckBox.Size = New Size(14, 14)
                            CellCheckBox.Checked = CType(Cel.Value, Boolean)
                            Dim bmp As New Bitmap(ColumnWidths(i), CellHeight)
                            Dim tmpGraphics As Graphics = Graphics.FromImage(bmp)
                            tmpGraphics.FillRectangle(Brushes.White, New Rectangle(0, 0, _
                                    bmp.Width, bmp.Height))
                            CellCheckBox.DrawToBitmap(bmp, New Rectangle(CType((bmp.Width - _
                                    CellCheckBox.Width) / 2, Int32), CType((bmp.Height - _
                                    CellCheckBox.Height) / 2, Int32), CellCheckBox.Width, _
                                    CellCheckBox.Height))
                            e.Graphics.DrawImage(bmp, New Point(ColumnLefts(i), tmpTop))

                            ' For the ComboBox Column
                        ElseIf ColumnTypes(i) Is GetType(DataGridViewComboBoxColumn) Then

                            CellComboBox.Size = New Size(ColumnWidths(i), CellHeight)
                            Dim bmp As New Bitmap(CellComboBox.Width, CellComboBox.Height)
                            CellComboBox.DrawToBitmap(bmp, New Rectangle(0, 0, _
                                    bmp.Width, bmp.Height))
                            e.Graphics.DrawImage(bmp, New Point(ColumnLefts(i), tmpTop))
                            e.Graphics.DrawString(Cel.Value.ToString, Cel.InheritedStyle.Font, _
                                    New SolidBrush(Cel.InheritedStyle.ForeColor), _
                                    New RectangleF(ColumnLefts(i) + 1, tmpTop, ColumnWidths(i) _
                                    - 16, CellHeight), StrFormatComboBox)

                            ' For the Image Column
                        ElseIf ColumnTypes(i) Is GetType(DataGridViewImageColumn) Then

                            Dim CelSize As Rectangle = New Rectangle(ColumnLefts(i), _
                                    tmpTop, ColumnWidths(i), CellHeight)
                            Dim ImgSize As Size = CType(Cel.FormattedValue, Image).Size
                            e.Graphics.DrawImage(Cel.FormattedValue, New Rectangle(ColumnLefts(i) _
                                    + CType(((CelSize.Width - ImgSize.Width) / 2), Int32), _
                                    tmpTop + CType(((CelSize.Height - ImgSize.Height) / 2),  _
                                    Int32), CType(Cel.FormattedValue, Image).Width, CType(Cel.FormattedValue,  _
                                    Image).Height))

                        End If

                        ' Drawing Cells Borders 
                        e.Graphics.DrawRectangle(Pens.Black, New Rectangle(ColumnLefts(i), _
                                tmpTop, ColumnWidths(i), CellHeight))

                        i += 1

                    Next
                    tmpTop += CellHeight

                End If

                RowPos += 1
                ' For the first page it calculates Rows per Page
                If PageNo = 1 Then
                    RowsPerPage += 1
                End If
            Loop

            If RowsPerPage = 0 Then Exit Sub

            ' Write Footer (Page Number)
            DrawFooter(e, RowsPerPage)

            e.HasMorePages = False
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally

        End Try

    End Sub

    Private Sub DrawFooter(ByVal e As System.Drawing.Printing.PrintPageEventArgs, ByVal RowsPerPage As Int32)
        Dim cnt As Integer

        ' Detemining rows number to print
        If PrintAllRows Then
            If dgv.Rows(dgv.Rows.Count - 1).IsNewRow Then
                ' When the DataGridView doesn't allow adding rows
                cnt = dgv.Rows.Count - 2
            Else
                ' When the DataGridView allows adding rows
                cnt = dgv.Rows.Count - 1
            End If
        Else
            cnt = dgv.SelectedRows.Count
        End If

        ' Writing the Page Number on the Bottom of Page
        Dim PageNum As String = PageNo.ToString + " de " + _
                    Math.Ceiling(cnt / RowsPerPage).ToString
        e.Graphics.DrawString(PageNum, dgv.Font, Brushes.Black, _
                    e.MarginBounds.Left + (e.MarginBounds.Width - _
                    e.Graphics.MeasureString(PageNum, dgv.Font, _
                    e.MarginBounds.Width).Width) / 2, e.MarginBounds.Top + _
                    e.MarginBounds.Height + 31)

    End Sub
    Public Function formatoNegrita(ByVal tamano_letra As Single) As DataGridViewCellStyle
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", tamano_letra, System.Drawing.FontStyle.Bold)
        Return DataGridViewCellStyle1
    End Function
    Public Sub exportarExcel(ByVal dtg As DataGridView)
        If dtg.RowCount > 1 Then
            'Creamos las variables
            Dim exApp As New Microsoft.Office.Interop.Excel.Application
            Dim exLibro As Microsoft.Office.Interop.Excel.Workbook
            Dim exHoja As Microsoft.Office.Interop.Excel.Worksheet
            Try
                'Añadimos el Libro al programa, y la hoja al libro
                exLibro = exApp.Workbooks.Add
                exHoja = exLibro.Worksheets.Add()
                '¿Cuantas columnas y cuantas filas?
                Dim NCol As Integer = dtg.ColumnCount
                Dim NRow As Integer = dtg.RowCount
                'Aquí recorremos todas las filas, y por cada fila todas las columnas y vamos escribiendo.
                For i As Integer = 1 To NCol
                    exHoja.Cells.Item(1, i) = dtg.Columns(i - 1).Name.ToString
                Next
                For Fila As Integer = 0 To NRow - 1
                    For Col As Integer = 0 To NCol - 1
                        exHoja.Cells.Item(Fila + 2, Col + 1) = dtg.Rows(Fila).Cells(Col).Value
                    Next
                Next
                'Titulo en negrita, Alineado al centro y que el tamaño de la columna se ajuste al texto
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
            End Try
        Else
            MessageBox.Show("No hay nada que exportar", "Nada para exportar", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
    Public Function return_color_mas_bien(ByVal valor As Integer) As System.Drawing.Color
        If valor >= 90 And valor <= 100 Then
            Return Color.Green
        ElseIf valor >= 80 And valor < 90 Then
            Return Color.OliveDrab
        ElseIf valor >= 70 And valor < 80 Then
            Return Color.YellowGreen
        ElseIf valor >= 60 And valor < 70 Then
            Return Color.Yellow
        ElseIf valor >= 50 And valor < 60 Then
            Return Color.Orange
        ElseIf valor >= 40 And valor < 50 Then
            Return Color.DarkOrange
        ElseIf valor >= 30 And valor < 40 Then
            Return Color.LightSalmon
        ElseIf valor >= 20 And valor < 30 Then
            Return Color.Coral
        ElseIf valor >= 10 And valor < 20 Then
            Return Color.OrangeRed
        ElseIf valor >= 0 And valor < 10 Then
            Return Color.Red
        End If
    End Function
    Public Function return_color_menos_bien(ByVal valor As Integer) As System.Drawing.Color
        If valor >= 90 And valor <= 100 Then
            Return Color.Red
        ElseIf valor >= 80 And valor < 90 Then
            Return Color.OrangeRed
        ElseIf valor >= 70 And valor < 80 Then
            Return Color.Coral
        ElseIf valor >= 60 And valor < 70 Then
            Return Color.LightSalmon
        ElseIf valor >= 50 And valor < 60 Then
            Return Color.DarkOrange
        ElseIf valor >= 40 And valor < 50 Then
            Return Color.Orange
        ElseIf valor >= 30 And valor < 40 Then
            Return Color.Yellow
        ElseIf valor >= 20 And valor < 30 Then
            Return Color.YellowGreen
        ElseIf valor >= 10 And valor < 20 Then
            Return Color.OliveDrab
        ElseIf valor >= 0 And valor < 10 Then
            Return Color.Green
        End If

    End Function
    Public Sub alertas(ByRef dtg As DataGridView)
        Dim alerta As Double = 0
        For j = 1 To dtg.Columns.Count - 1
            If objOpSimplesLn.buscarTexto(dtg.Columns(j).Name, "%") Or objOpSimplesLn.buscarTexto(dtg.Columns(j).Name, "por") Or objOpSimplesLn.buscarTexto(dtg.Columns(j).Name, "efic") Then
                For i = 0 To dtg.Rows.Count - 1
                    If Not IsDBNull(dtg.Item(j, i).Value) Then
                        If (dtg.Item(j, i).Value) >= 100 Then
                            dtg.Item(j, i).Style.BackColor = Color.GreenYellow
                        ElseIf (dtg.Item(j, i).Value >= 95 And dtg.Item(j, i).Value < 100) Then
                            dtg.Item(j, i).Style.BackColor = Color.Yellow
                        Else
                            dtg.Item(j, i).Style.BackColor = Color.Red
                        End If
                    End If
                Next
            End If

        Next
    End Sub
End Class
