<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_informe_galvanizado
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cbo_min_salida = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cbo_hora_salida = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.cbo_min_entrada = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.chkanular = New System.Windows.Forms.CheckBox()
        Me.chkcodigo = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtcodigo = New System.Windows.Forms.TextBox()
        Me.chkorden = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtNumero = New System.Windows.Forms.TextBox()
        Me.cboOperariosG = New System.Windows.Forms.ComboBox()
        Me.dtgconsulta = New System.Windows.Forms.DataGridView()
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton()
        Me.cbo_hora_entrada = New System.Windows.Forms.ComboBox()
        Me.cboFechaFin = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.chkbobina = New System.Windows.Forms.CheckBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.chkoperador = New System.Windows.Forms.CheckBox()
        Me.cboFechaIni = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnActualizar = New System.Windows.Forms.ToolStripButton()
        Me.cbobobina = New System.Windows.Forms.ComboBox()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.img_procesar = New System.Windows.Forms.PictureBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Toolbar1 = New System.Windows.Forms.ToolStrip()
        Me.chk_noconforme = New System.Windows.Forms.CheckBox()
        Me.chk_desp = New System.Windows.Forms.CheckBox()
        Me.chk_traspu = New System.Windows.Forms.CheckBox()
        Me.chk_Enb2 = New System.Windows.Forms.CheckBox()
        CType(Me.dtgconsulta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.img_procesar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Toolbar1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(288, 69)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(49, 13)
        Me.Label7.TabIndex = 1209
        Me.Label7.Text = "Minuto:"
        '
        'cbo_min_salida
        '
        Me.cbo_min_salida.FormattingEnabled = True
        Me.cbo_min_salida.Items.AddRange(New Object() {"00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "51", "52", "53", "54", "55", "56", "57", "58", "59", "", ""})
        Me.cbo_min_salida.Location = New System.Drawing.Point(337, 66)
        Me.cbo_min_salida.Name = "cbo_min_salida"
        Me.cbo_min_salida.Size = New System.Drawing.Size(41, 21)
        Me.cbo_min_salida.TabIndex = 1208
        Me.cbo_min_salida.Text = "00"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(156, 70)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(66, 13)
        Me.Label8.TabIndex = 1207
        Me.Label8.Text = "Hora final:"
        '
        'cbo_hora_salida
        '
        Me.cbo_hora_salida.FormattingEnabled = True
        Me.cbo_hora_salida.Items.AddRange(New Object() {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24"})
        Me.cbo_hora_salida.Location = New System.Drawing.Point(247, 66)
        Me.cbo_hora_salida.Name = "cbo_hora_salida"
        Me.cbo_hora_salida.Size = New System.Drawing.Size(38, 21)
        Me.cbo_hora_salida.TabIndex = 1206
        Me.cbo_hora_salida.Text = "6"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(289, 47)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(49, 13)
        Me.Label15.TabIndex = 1205
        Me.Label15.Text = "Minuto:"
        '
        'cbo_min_entrada
        '
        Me.cbo_min_entrada.FormattingEnabled = True
        Me.cbo_min_entrada.Items.AddRange(New Object() {"00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "51", "52", "53", "54", "55", "56", "57", "58", "59", "", ""})
        Me.cbo_min_entrada.Location = New System.Drawing.Point(338, 42)
        Me.cbo_min_entrada.Name = "cbo_min_entrada"
        Me.cbo_min_entrada.Size = New System.Drawing.Size(41, 21)
        Me.cbo_min_entrada.TabIndex = 1204
        Me.cbo_min_entrada.Text = "00"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(156, 46)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(75, 13)
        Me.Label16.TabIndex = 1203
        Me.Label16.Text = "Hora inicial:"
        '
        'chkanular
        '
        Me.chkanular.AutoSize = True
        Me.chkanular.Location = New System.Drawing.Point(632, 9)
        Me.chkanular.Name = "chkanular"
        Me.chkanular.Size = New System.Drawing.Size(70, 17)
        Me.chkanular.TabIndex = 1201
        Me.chkanular.Text = "Anulados"
        Me.chkanular.UseVisualStyleBackColor = True
        '
        'chkcodigo
        '
        Me.chkcodigo.AutoSize = True
        Me.chkcodigo.Location = New System.Drawing.Point(515, 9)
        Me.chkcodigo.Name = "chkcodigo"
        Me.chkcodigo.Size = New System.Drawing.Size(117, 17)
        Me.chkcodigo.TabIndex = 1200
        Me.chkcodigo.Text = "Consolidar * codigo"
        Me.chkcodigo.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(889, 51)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(50, 13)
        Me.Label4.TabIndex = 1199
        Me.Label4.Text = "Codigo:"
        '
        'txtcodigo
        '
        Me.txtcodigo.Location = New System.Drawing.Point(892, 67)
        Me.txtcodigo.Name = "txtcodigo"
        Me.txtcodigo.Size = New System.Drawing.Size(117, 20)
        Me.txtcodigo.TabIndex = 1198
        '
        'chkorden
        '
        Me.chkorden.AutoSize = True
        Me.chkorden.Location = New System.Drawing.Point(399, 9)
        Me.chkorden.Name = "chkorden"
        Me.chkorden.Size = New System.Drawing.Size(112, 17)
        Me.chkorden.TabIndex = 1196
        Me.chkorden.Text = "Consolidar * orden"
        Me.chkorden.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(763, 51)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 13)
        Me.Label1.TabIndex = 1187
        Me.Label1.Text = "Orden  Nº:"
        '
        'txtNumero
        '
        Me.txtNumero.Location = New System.Drawing.Point(766, 67)
        Me.txtNumero.Name = "txtNumero"
        Me.txtNumero.Size = New System.Drawing.Size(117, 20)
        Me.txtNumero.TabIndex = 1186
        '
        'cboOperariosG
        '
        Me.cboOperariosG.FormattingEnabled = True
        Me.cboOperariosG.Location = New System.Drawing.Point(414, 66)
        Me.cboOperariosG.Name = "cboOperariosG"
        Me.cboOperariosG.Size = New System.Drawing.Size(202, 21)
        Me.cboOperariosG.TabIndex = 1185
        Me.cboOperariosG.Text = "Seleccione"
        '
        'dtgconsulta
        '
        Me.dtgconsulta.AllowUserToAddRows = False
        Me.dtgconsulta.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtgconsulta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dtgconsulta.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dtgconsulta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgconsulta.Location = New System.Drawing.Point(0, 94)
        Me.dtgconsulta.Name = "dtgconsulta"
        Me.dtgconsulta.ReadOnly = True
        Me.dtgconsulta.RowHeadersVisible = False
        Me.dtgconsulta.Size = New System.Drawing.Size(1059, 201)
        Me.dtgconsulta.TabIndex = 1197
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton3.Image = Global.Spic.My.Resources.Resources.excel10
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(27, 25)
        Me.ToolStripButton3.Text = "ToolStripButton3"
        '
        'cbo_hora_entrada
        '
        Me.cbo_hora_entrada.FormattingEnabled = True
        Me.cbo_hora_entrada.Items.AddRange(New Object() {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24"})
        Me.cbo_hora_entrada.Location = New System.Drawing.Point(248, 42)
        Me.cbo_hora_entrada.Name = "cbo_hora_entrada"
        Me.cbo_hora_entrada.Size = New System.Drawing.Size(38, 21)
        Me.cbo_hora_entrada.TabIndex = 1202
        Me.cbo_hora_entrada.Text = "6"
        '
        'cboFechaFin
        '
        Me.cboFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.cboFechaFin.Location = New System.Drawing.Point(53, 36)
        Me.cboFechaFin.MaxDate = New Date(2054, 5, 13, 0, 0, 0, 0)
        Me.cboFechaFin.Name = "cboFechaFin"
        Me.cboFechaFin.Size = New System.Drawing.Size(91, 20)
        Me.cboFechaFin.TabIndex = 1030
        Me.cboFechaFin.Value = New Date(2016, 6, 1, 15, 46, 45, 0)
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 39)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 13)
        Me.Label3.TabIndex = 1031
        Me.Label3.Text = "Final:"
        '
        'chkbobina
        '
        Me.chkbobina.AutoSize = True
        Me.chkbobina.Location = New System.Drawing.Point(276, 9)
        Me.chkbobina.Name = "chkbobina"
        Me.chkbobina.Size = New System.Drawing.Size(117, 17)
        Me.chkbobina.TabIndex = 1195
        Me.chkbobina.Text = "Consolidar * bobina"
        Me.chkbobina.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(3, 18)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(45, 13)
        Me.Label5.TabIndex = 1029
        Me.Label5.Text = "Inicial:"
        '
        'chkoperador
        '
        Me.chkoperador.AutoSize = True
        Me.chkoperador.Location = New System.Drawing.Point(143, 9)
        Me.chkoperador.Name = "chkoperador"
        Me.chkoperador.Size = New System.Drawing.Size(127, 17)
        Me.chkoperador.TabIndex = 1194
        Me.chkoperador.Text = "Consolidar * operador"
        Me.chkoperador.UseVisualStyleBackColor = True
        '
        'cboFechaIni
        '
        Me.cboFechaIni.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.cboFechaIni.Location = New System.Drawing.Point(53, 14)
        Me.cboFechaIni.MaxDate = New Date(2054, 5, 13, 0, 0, 0, 0)
        Me.cboFechaIni.Name = "cboFechaIni"
        Me.cboFechaIni.Size = New System.Drawing.Size(91, 20)
        Me.cboFechaIni.TabIndex = 1028
        Me.cboFechaIni.Value = New Date(2016, 6, 1, 0, 0, 0, 0)
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboFechaIni)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.cboFechaFin)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 32)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(152, 60)
        Me.GroupBox1.TabIndex = 1193
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Rango de fecha"
        '
        'btnActualizar
        '
        Me.btnActualizar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnActualizar.Image = Global.Spic.My.Resources.Resources.actualizar
        Me.btnActualizar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnActualizar.Name = "btnActualizar"
        Me.btnActualizar.Size = New System.Drawing.Size(27, 25)
        Me.btnActualizar.Text = "Actualizar"
        '
        'cbobobina
        '
        Me.cbobobina.FormattingEnabled = True
        Me.cbobobina.Location = New System.Drawing.Point(632, 66)
        Me.cbobobina.Name = "cbobobina"
        Me.cbobobina.Size = New System.Drawing.Size(121, 21)
        Me.cbobobina.TabIndex = 1192
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton2.Image = Global.Spic.My.Resources.Resources.ppal3
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(27, 25)
        Me.ToolStripButton2.Text = "ToolStripButton2"
        Me.ToolStripButton2.ToolTipText = "Menú principal"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = Global.Spic.My.Resources.Resources._1349388328_door_in
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(27, 25)
        Me.ToolStripButton1.Text = "ToolStripButton1"
        Me.ToolStripButton1.ToolTipText = "Salir"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 28)
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(629, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 13)
        Me.Label2.TabIndex = 1191
        Me.Label2.Text = "Bobina"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 28)
        '
        'img_procesar
        '
        Me.img_procesar.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.img_procesar.Image = Global.Spic.My.Resources.Resources.procesando
        Me.img_procesar.Location = New System.Drawing.Point(21, 98)
        Me.img_procesar.Name = "img_procesar"
        Me.img_procesar.Size = New System.Drawing.Size(1044, 207)
        Me.img_procesar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.img_procesar.TabIndex = 1190
        Me.img_procesar.TabStop = False
        Me.img_procesar.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(415, 49)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(49, 13)
        Me.Label6.TabIndex = 1184
        Me.Label6.Text = "Solicita"
        '
        'Toolbar1
        '
        Me.Toolbar1.AutoSize = False
        Me.Toolbar1.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.Toolbar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Toolbar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Toolbar1.ImageScalingSize = New System.Drawing.Size(23, 23)
        Me.Toolbar1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator2, Me.ToolStripButton1, Me.ToolStripButton2, Me.ToolStripSeparator3, Me.btnActualizar, Me.ToolStripButton3})
        Me.Toolbar1.Location = New System.Drawing.Point(0, 0)
        Me.Toolbar1.Name = "Toolbar1"
        Me.Toolbar1.Size = New System.Drawing.Size(1059, 28)
        Me.Toolbar1.TabIndex = 1183
        Me.Toolbar1.Text = "ToolStrip1"
        '
        'chk_noconforme
        '
        Me.chk_noconforme.AutoSize = True
        Me.chk_noconforme.Location = New System.Drawing.Point(708, 9)
        Me.chk_noconforme.Name = "chk_noconforme"
        Me.chk_noconforme.Size = New System.Drawing.Size(87, 17)
        Me.chk_noconforme.TabIndex = 1210
        Me.chk_noconforme.Text = "No conforme"
        Me.chk_noconforme.UseVisualStyleBackColor = True
        '
        'chk_desp
        '
        Me.chk_desp.AutoSize = True
        Me.chk_desp.Location = New System.Drawing.Point(801, 9)
        Me.chk_desp.Name = "chk_desp"
        Me.chk_desp.Size = New System.Drawing.Size(82, 17)
        Me.chk_desp.TabIndex = 1211
        Me.chk_desp.Text = "Desperdicio"
        Me.chk_desp.UseVisualStyleBackColor = True
        '
        'chk_traspu
        '
        Me.chk_traspu.AutoSize = True
        Me.chk_traspu.Location = New System.Drawing.Point(892, 9)
        Me.chk_traspu.Name = "chk_traspu"
        Me.chk_traspu.Size = New System.Drawing.Size(93, 17)
        Me.chk_traspu.TabIndex = 1212
        Me.chk_traspu.Text = "Traslado puas"
        Me.chk_traspu.UseVisualStyleBackColor = True
        '
        'chk_Enb2
        '
        Me.chk_Enb2.AutoSize = True
        Me.chk_Enb2.Location = New System.Drawing.Point(993, 9)
        Me.chk_Enb2.Name = "chk_Enb2"
        Me.chk_Enb2.Size = New System.Drawing.Size(54, 17)
        Me.chk_Enb2.TabIndex = 1213
        Me.chk_Enb2.Text = "En b2"
        Me.chk_Enb2.UseVisualStyleBackColor = True
        '
        'Frm_informe_galvanizado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1059, 296)
        Me.Controls.Add(Me.chk_Enb2)
        Me.Controls.Add(Me.chk_traspu)
        Me.Controls.Add(Me.chk_desp)
        Me.Controls.Add(Me.chk_noconforme)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.cbo_min_salida)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.cbo_hora_salida)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.cbo_min_entrada)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.chkanular)
        Me.Controls.Add(Me.chkcodigo)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtcodigo)
        Me.Controls.Add(Me.chkorden)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtNumero)
        Me.Controls.Add(Me.cboOperariosG)
        Me.Controls.Add(Me.dtgconsulta)
        Me.Controls.Add(Me.cbo_hora_entrada)
        Me.Controls.Add(Me.chkbobina)
        Me.Controls.Add(Me.chkoperador)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cbobobina)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.img_procesar)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Toolbar1)
        Me.Name = "Frm_informe_galvanizado"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Informe producción de galvanizado"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dtgconsulta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.img_procesar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Toolbar1.ResumeLayout(False)
        Me.Toolbar1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cbo_min_salida As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cbo_hora_salida As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cbo_min_entrada As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents chkanular As System.Windows.Forms.CheckBox
    Friend WithEvents chkcodigo As System.Windows.Forms.CheckBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtcodigo As System.Windows.Forms.TextBox
    Friend WithEvents chkorden As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtNumero As System.Windows.Forms.TextBox
    Friend WithEvents cboOperariosG As System.Windows.Forms.ComboBox
    Friend WithEvents dtgconsulta As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents cbo_hora_entrada As System.Windows.Forms.ComboBox
    Friend WithEvents cboFechaFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents chkbobina As System.Windows.Forms.CheckBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents chkoperador As System.Windows.Forms.CheckBox
    Friend WithEvents cboFechaIni As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnActualizar As System.Windows.Forms.ToolStripButton
    Friend WithEvents cbobobina As System.Windows.Forms.ComboBox
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents img_procesar As System.Windows.Forms.PictureBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Toolbar1 As System.Windows.Forms.ToolStrip
    Friend WithEvents chk_noconforme As System.Windows.Forms.CheckBox
    Friend WithEvents chk_desp As System.Windows.Forms.CheckBox
    Friend WithEvents chk_traspu As CheckBox
    Friend WithEvents chk_Enb2 As CheckBox
End Class
