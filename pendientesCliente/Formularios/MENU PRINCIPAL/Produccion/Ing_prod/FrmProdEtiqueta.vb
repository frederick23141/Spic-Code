Imports System.Configuration
Imports logicaNegocios
Imports System.IO
Imports Microsoft.Office.Interop
#Disable Warning BC40056 ' El espacio de nombres o el tipo especificado en el 'System.Data.SqlServerCe' Imports no contienen ningún miembro público o no se encuentran. Asegúrese de que el espacio de nombres o el tipo se hayan definido y de que contengan al menos un miembro público. Asegúrese de que el nombre del elemento importado no use ningún alias.
Imports System.Data.SqlServerCe
#Enable Warning BC40056 ' El espacio de nombres o el tipo especificado en el 'System.Data.SqlServerCe' Imports no contienen ningún miembro público o no se encuentran. Asegúrese de que el espacio de nombres o el tipo se hayan definido y de que contengan al menos un miembro público. Asegúrese de que el nombre del elemento importado no use ningún alias.
Imports System.Drawing.Printing
Public Class FrmProdEtiqueta
    Private WithEvents PrintDoc As New System.Drawing.Printing.PrintDocument ' PrintDocumnet Object used for printing
    Private obj_Ing_prodLn As New Ing_prodLn
    Dim peso As String = ""

    Private Sub FrmProdEtiqueta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        txtPeso.ReadOnly = False
        Timer1.Enabled = True
        SerialPort1.Open()
        cbo_fecha.Value = Now.AddDays(-1)
        Dim sql As String = ""
        sql = "Select nit,nombres  from V_nom_personal_Activo_con_maquila WHERE centro = 2100 ORDER BY nombres "
        cbo_operario.DataSource = obj_Ing_prodLn.listar_datatable(sql, "CORSAN")
        cbo_operario.ValueMember = "nit"
        cbo_operario.DisplayMember = "nombres"
        cbo_operario.Text = "Seleccione"

        sql = "Select tipo_calidad  from J_tipo_cal_alambre "
        cboCalidad.DataSource = obj_Ing_prodLn.listar_datatable(sql, "PRODUCCION")
        cboCalidad.ValueMember = "tipo_calidad"
        cboCalidad.DisplayMember = "tipo_calidad"
        cboCalidad.Text = "Seleccione"

    End Sub
    Private Sub chk_todos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_todos.CheckedChanged
        If (chk_todos.Checked = True) Then
            Dim sql As String = "Select nit,nombres   from V_nom_personal_Activo_con_maquila WHERE centro not in (4200) ORDER BY nombres "
            cbo_operario.DataSource = obj_Ing_prodLn.listar_datatable(sql, "CORSAN")
            cbo_operario.ValueMember = "nit"
            cbo_operario.DisplayMember = "nombres"
            cbo_operario.Text = "Seleccione"
        Else
            Dim sql As String = "Select nit,nombres  from V_nom_personal_Activo_con_maquila WHERE centro = 2100 ORDER BY nombres"
            cbo_operario.DataSource = obj_Ing_prodLn.listar_datatable(sql, "CORSAN")
            cbo_operario.ValueMember = "nit"
            cbo_operario.DisplayMember = "nombres"
            cbo_operario.Text = "Seleccione"
        End If
    End Sub

   
    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        'PrintDocument1.PrinterSettings.PrintFileName
        'PrintDialog1.Document = PrintDocument1
        'PrintDialog1.PrinterSettings.PrintFileName = ("C:\plantilla.txt")
        'PrintDialog1.AllowSomePages = True
        'If PrintDialog1.ShowDialog = DialogResult.OK Then
        '    PrintDocument1.PrinterSettings = PrintDialog1.PrinterSettings
        '    Dim s As String = PrintDialog1.PrinterSettings.PrinterName
        '    PrintDocument1.PrinterSettings.PrintFileName = ("C:\plantilla.txt")
        '    PrintDocument1.Print()
        'End If
       
        
        imprimir()

        'If (cbo_operario.Text <> "Seleccione" And cboCalidad.Text <> "Seleccione" And txtCalibre.Text <> "" And txtPeso.Text <> "") Then
        '    imprimir()
        'Else
        '    MessageBox.Show("Los campos operarios,clase y calibre deben contener información!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        'End If
    End Sub
    Private Sub modificarPlantilla(ByVal operario As String, ByVal clase As String, ByVal calibre As String, ByVal peso As String, ByVal fec As String, ByVal consec As String)
        Const fic As String = "D:\plantilla.txt"
        Dim nuevoFic As String = "D:\nuevo.txt"
        Dim sw As New System.IO.StreamWriter(nuevoFic)
        Dim texto As String
        Dim sr As New System.IO.StreamReader(fic)
        texto = sr.ReadToEnd()
        texto = Replace(texto, "@Operario", operario)
        texto = Replace(texto, "@Clase", clase)
        texto = Replace(texto, "@Calibre", calibre)
        texto = Replace(texto, "@Peso", peso)
        texto = Replace(texto, "@Fecha", fec)
        texto = Replace(texto, "@codigoBarras", consec)

        sr.Close()
        sw.WriteLine(texto)
        sw.Close()

        Console.WriteLine(texto)
    End Sub
    Private Sub txtCalibre_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCalibre.KeyPress
        If (Char.IsDigit(e.KeyChar) Or e.KeyChar = ".") Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If (txtPeso.TextLength >= 15) Then
            txtPeso.Text = peso
        End If
        peso = SerialPort1.ReadExisting
        txtPeso.Text += peso
        'SerialPort1.DiscardInBuffer()C:\Documents and Settings\JORGE.ESCOBAR\Escritorio\pendientesCliente\accesoDatos\DespachoAd.vb
    End Sub
    Private Sub imprimir()
        Dim peso As Double = capturarPeso()
        Dim calibre As Double = txtCalibre.Text
        Dim nitOperario As Double = cbo_operario.SelectedValue
        Dim nombOperario As String = cbo_operario.Text
        Dim fecha As Date = cbo_fecha.Value.Date
        Dim calidad As Integer = cboCalidad.SelectedValue
        Dim consecutivo As String = ""
        Dim sql As String = "INSERT INTO J_rollos_tref (operario,calibre,peso,fecha,calidad)VALUES (" & nitOperario & "," & calibre & "," & peso & ",'" & fecha & "'," & calidad & ")"
        obj_Ing_prodLn.ejecutar(sql, "PRODUCCION")
        consecutivo = obj_Ing_prodLn.consultar_valor("SELECT MAX (id_rollo) FROM J_rollos_tref", "PRODUCCION")
        modificarPlantilla(nombOperario, calidad, calibre, peso, fecha, consecutivo)
        Dim proc As New Process
        proc.StartInfo.FileName = "D:\nuevo.txt"
        proc.StartInfo.Verb = "Print"
        proc.StartInfo.CreateNoWindow = False
        proc.Start()
    End Sub
    Private Function capturarPeso() As Double
        Dim pesoFinal As String = ""
        For i = 1 To txtPeso.TextLength - 1
            If (txtPeso.Text(i) <> "=") Then
                If (txtPeso.Text(i) <> "-") Then
                    pesoFinal += txtPeso.Text(i)
                End If
            Else
                i = txtPeso.TextLength
            End If
        Next
        Return pesoFinal
    End Function
    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim peso As Double = capturarPeso()
        Dim calibre As Double = txtCalibre.Text
        Dim nitOperario As Double = cbo_operario.SelectedValue
        Dim nombOperario As String = cbo_operario.SelectedText
        Dim fecha As Date = cbo_fecha.Value.Date
        Dim calidad As Integer = cboCalidad.SelectedValue
        Dim consecutivo As String = ""
        'Dim sql As String = "INSERT INTO J_rollos_tref (operario,calibre,peso,fecha,calidad)VALUES (" & nitOperario & "," & calibre & "," & peso & ",'" & fecha & "'," & calidad & ")"
        ' obj_Ing_prodLn.ejecutar(Sql, "PRODUCCION")
        'consecutivo = obj_Ing_prodLn.consultar_valor("SELECT MAX (id_rollo) FROM J_rollos_tref", "PRODUCCION")
        'e.PageSettings.PrinterSettings.PrintFileName = ("C:\plantilla.txt")
        Dim drawString As String = infoEtiqueta(nombOperario, calidad, calibre, peso, fecha)
        Dim drawFont As New Font("Arial", 12)
        Dim drawBrush As New SolidBrush(Color.Black)
        Dim x As Single = 75.0F
        Dim y As Single = 75.0F
        Dim width As Single = 100.0F
        Dim height As Single = 25.0F
        Dim drawRect As New RectangleF(x, y, width, height)
        e.Graphics.DrawString(drawString, drawFont, drawBrush, drawRect)
        e.HasMorePages = False
    End Sub
    Private Function infoEtiqueta(ByVal operario As String, ByVal clase As String, ByVal calibre As String, ByVal peso As String, ByVal fec As String) As String
        Dim info As String = "CT~~CD,~CC^~CT~  " & _
                        "^XA~TA000~JSB^LT0^MNW^MTT^PON^PMN^LH0,0^JMA^PR4,4~SD15^JUS^LRN^CI0^XZ " & _
                        "~DG000.GRF,07680,048, " & _
                        ",::::::::::::::::::::::::hH03FOF8,gX01FWF0,gV07FgGFE,gT03FgKFC,gR03FgOF8,gQ0gJFBFMFE0,gO03FPFC0R0F7FNF80,gN07FNFC0X0OFC,gM07FMFC0gH07FMF0,gL07FMFgL01FMF,gK07FLF80gN07FLF0,gJ07FKFE0gQ017FKF80,gI07FKFC0gT0MF0,gH07FKFC0gV05FJFE,gG01FKFC0gX07FJFC0,g01FKFC0h06FJF8,g0LFC0hH0BFJF,Y03FKFhK09FJF0,X01FJFE0hK017FIFC,X0LFhN017FIF80,W03FJF80hN03FIFE0,W0LFhQ07FIF8,V07FJF80hP01FJF,U01FJF80hR01FIFC0,U07FJFhT017FIF0,T01FJFC0hT03FIFC,T07FIFE0hV07FIF,S01FJFC0hV01FIFC0,S03FIFC0hX07FHFE0,S0KFC0hX01FIF8,R03FJFiG07FHFE,R07FIFC0i03FIF,Q01FJFiI0JFC0,Q03FIFC0iH0JFE0,Q0KFiJ01FIF0,P01FJFiK0DFHFC,P03FIF80iJ03FHFE,P07FIF80iJ01FIF,P0KFiM0DFHF80,O03FIFE0iL06FHFC0,O06FIF80iL037FFE0,O0DFIFiN01BFHF0,N01BFHFE0I0FE7FIF80hV05FHF8,N017FHFE0H07FF0FIFC0hV06FHFC,N03FIF8003FHF9BFHFC0hV02FHFE,N06FIFI0JF8DFHFE0hV017FHF,N0DFIFH03FIFC3FHFE0hW0BFHF80,M01BFHFE00FJFC1FHFE0hW05FHF80,M017FHFC01BFIF80DFFE0hW05FHFC0,M037FHF8037FIF803FFE0hW02FHFC0,M02FIF806FJFC01FFE0hX07FFE0,M04FIFH0DFJFC00FFE0hS03F6017FHF0,M05FIFH0BFJFC007FE0I0F83E0P0E0W0680S0407013FHF0,M0DFHFE017FJFC001FE0H0HF8FFE0H07FHFC1FFC001F3FIFI03FC7FHF8007FHFC3FFC011FB80BFHF0,M0BFHFE017FJFC0H0FE007FFCBFF801FIFC7FHFH0HF13FHF801FHF2FHFE00FIFC3FHF81199C0BFHF8,L01BFHFE02FKFC0H07E01FHFCBFFC013FHFCFIF83FF85FHF803FHF97FHFH03FHFC0FHFC319CC05FHF8,L013FHFC02FKF80H01E07FHFCBFHF013FHFDBFHF87FFC3FHFC07FHFCBFHF803FHFE0FHFC00BCE05FHF8,L017FHFC04FKFC0H01E0FIFCBFHF813FHFC7FHFCDFFE0FHFC05FHFE9FHFC03FHFE0FHFE21F0E05FHF8,L017FHFC04FKFC0I041FIFCBFHFC13FHFC7FHFDBFHF07FFC09FHFE1FHFE03FHFE0FIF313CE00FHF8,L017FHFC05FKFC0J037FHFCBFHFE13FHFC7FHFD3FHFC1FFC09FHFE1FHFE03FHFE0FIF0199A00FHF8,L027FHF805FKFC0J02FIFCBFIF13FHFDBFHFD7FIF0FFC05FHFE1FIF03FHFE0FIF8BDBA02FHF8,L027FHF805FKFC0J05FIFCBFIF13FHFEFIFD7FIF83FC07FHFE1FIF03FHFE0FIFH8C7002FHF8,L02FIF805FKFC0J0DFIFCBFIF93FHFE7FHFD3FIFE1FC03FHFE1FIF03FHFE0FIFC3FE402FHF8,L02FIF805FKFC0J09FIFCBFIF93FHFE1FHF8BFJF07C00FHFE5FIF03FHFE0FIF80H0802FHF8,L02FIFC05FKFC0J0BFIFCBFIFD3FIF0BFF85FJFC3C001FFC5FIF83FHFE0FIFC0J02FHF8,L027FHF800FKFC0J0BFIFCBFIFD3FIFH0FC03FJFE1C0H07FC5FIF83FHFE0FIFC0J02FHF8,L027FHF802FKFC0H0103FIFCBFIFD3FIFK01FKFH8H0IF85FIF83FHFE0FIFC0J02FHF8,L017FHFC02FKFC0H0383FIFCBFIFD3FIFL0LFC003FHFC5FIF83FHFE0FIFC0K0IF8,L017FHFC017FJFC0H078BFIFCBFIFD3FIFL03FKFH07FHFC5FIF83FHFE0FIFC0J04FHF8,L017FHFC017FJFC001FCBFIFCBFIFD3FIFK0E1FKF80BFHFC5FIF83FHFE0FIFC0J05FHF8,L013FHFC00BFJF8003FC9FIFCBFIFD3FIFK0F07FJFC17FHFC5FIF03FHFE0FIF80J05FHF8,L01BFHFE005FJFC007FC5FIFCBFIFD3FIFK0FC3FJFE37FHFC5FIF83FHFE0FIFC0J0DFHF8,M0BFHFE006FJFC00FFC5FIFCBFIFD3FIFK0BE0FKF2FIFC5FIF83FHFE0FIFC0J0BFHF8,M0DFHFE0037FIFC037FE2FIFCBFIF93FIFK0BF87FJF2FIFC5FIF83FHFE0FIFC0J0BFHF0,M05FIFH01BFIFC07FFE37FHFCBFIF93FIFK0BFC1FJF2FIFC5FIF83FHFE0FIFC0I013FHF0,M04FIF800FJFC0FHFE1BFHFCBFIF93FIFK0BFF0FJF27FHFC5FIF83FHFE0FIFC0I017FFE0,M02FIF8003FIFC37FFE0DFHFCBFIF13FIFK0BFF87FIF97FHFC5FIF83FHFE0FIFC0I02FHFE0,M037FHFC001FIF87FHFE07FHFCBFIF13FIFK0BFFE1FIF8FIFC5FIF83FHFE0FIFC0I06FHFC0,M017FHFE0H07FHF8FIFE01FHFCBFHFE13FIFK0BFHF0BFHF87FHFC5FIF83FHFE0FIFC0I05FHFC0,M01BFHFE0H01FHFB7FHFE007FFCBFHF813FIFK0BFHF81FHF03FHFC5FIF03FHFE0FIF80I0DFHF80,N0DFIFJ0DFF1FIFE001FFCFIF01FJFK0JFC7FHFH0IFC7FIF8FIFE3FIFC0H01BFHF80,N06FIF80H05BF87FHFE0H03FC1FF8003FIFL0IFE1FFC004FFC1FIF83FHFE0FIFC0H017FHF,N03FIF80I05F83FHFE0I07C0FC0H01FIFL0IFE07E0H027FC07FHFH0JF07FHFC0H02FHFE,N017FHFE0iN05FHFC,N01BFHFE0iN0BFHF8,O0DFIF80iL01FIF0,O06FIF80iL02FHFE0,O03FIFE0iL0JFC0,P0KFiL01BFHF80,P07FIF80iJ037FHF,P037FHFE0iJ06FHFE,P01FJFiK0JFC,Q0KFC0iH03FIF0,Q03FIFE0iH07FHFE0,Q01FJF80i01FIFC0,R07FIFE0i07FIF,R03FJFiG0JFE,S0KFC0hX07FIF8,S03FJFhY0JFE0,S01FJFC0hV07FIFC0,T07FJFhW0KF,T01FJFC0hT07FIFC,U07FIFE0hS01FJF0,U01FJFE0hR07FIFC0,V07FJFC0hP01FJF,W0LFhP01FJF8,W03FJFE0hN0KFE0,X0LF80hL03FJF80,X01FKFhM0KFC,Y03FJFE80hH01FJFE0,g0MFhI0LF80,g01FKFE0h03FJFC,gG01FKFE0gX0LFE0,gH03FKFD0gV0LFE,gI07FKFE0gS01FLF8,gJ07FLFgR03FLF,gK07FLFC0gN0NF8,gL07FMFgL03FMF,gM07FMFE0gG01FNF0,gN07FOFX03FNFC,gO01FQFR03FPF80,gQ0gSFE8,gR01FgOF8,gT03FgKFC,gV07FgGFC,gX01FWF0,hH01FOF8,,:::::::^XA  " & _
                        "^MMT " & _
                        "^PW480 " & _
                         "   ^LL0639 " & _
                          "  ^LS0 " & _
                           " ^FT64,160^XG000.GRF,1,1^FS " & _
                          "  ^FT23,192^A0N,23,24^FH\^FDOperario: ^FS " & _
                         "   ^FT23,268^A0N,28,28^FH\^FDClase:^FS " & _
                            "^FT25,343^A0N,28,28^FH\^FDCalibre:^FS " & _
                           " ^FT29,420^A0N,28,28^FH\^FDPeso:^FS " & _
                            "^FT29,492^A0N,32,28^FH\^FDFecha:^FS " & _
                           " ^FT47,600^A0N,23,24^FB46,1,0,C^FH\^FDPBX:^FS " & _
                           " ^FT131,192^A0N,23,24^FH\^FD" & operario & "^FS " & _
                            "^FT106,268^A0N,28,28^FH\^FD" & clase & "^FS " & _
                            "^FT126,343^A0N,28,28^FH\^FD" & calibre & "^FS " & _
                           " ^FT107,420^A0N,28,28^FH\^FD@" & peso & "^FS " & _
                            "^FT116,487^A0N,28,28^FH\^FD@" & fec & "^FS " & _
                            "^BY2,3,107^FT455,562^BCB,,Y,N " & _
                            "^FD>:@codigoBarras^FS " & _
                            "^FT135,625^A0N,23,24^FH\^FDwww.corsan.com.co^FS" & _
                            "^FT95,600^A0N,23,24^FH\^FD (574)^FS" & _
                            "^FT153,600^A0N,23,24^FH\^FD 444 07 55^FS" & _
                            "^FT260,600^A0N,23,24^FH\^FD fax:^FS" & _
                            "^FT305,600^A0N,23,24^FH\^FD(574)^FS" & _
                            "^FT356,600^A0N,23,24^FH\^FD285 56 60^FS" & _
                            "^PQ1,0,1,Y^XZ " & _
                           " ^XA^ID000.GRF^FS^XZ"
        Return info
    End Function
End Class