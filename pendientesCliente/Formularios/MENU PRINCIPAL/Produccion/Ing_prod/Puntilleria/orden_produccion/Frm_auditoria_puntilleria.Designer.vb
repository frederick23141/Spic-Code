<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_auditoria_puntilleria
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.img_procesar = New System.Windows.Forms.PictureBox()
        Me.txt_prod_final = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbo_maquina = New System.Windows.Forms.ComboBox()
        Me.cbo_operario = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txt_ordenProduccion = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtg_auditoria = New System.Windows.Forms.DataGridView()
        Me.Toolbar1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btn_salir = New System.Windows.Forms.ToolStripButton()
        Me.btn_ppal = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnConsultar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton()
        Me.chk_sin_tamb = New System.Windows.Forms.CheckBox()
        Me.chk_tamb = New System.Windows.Forms.CheckBox()
        Me.chk_todo = New System.Windows.Forms.CheckBox()
        Me.chk_env_empaque = New System.Windows.Forms.CheckBox()
        Me.chk_no_conforme = New System.Windows.Forms.CheckBox()
        Me.chk_historial = New System.Windows.Forms.CheckBox()
        Me.chk_hornos = New System.Windows.Forms.CheckBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cbo_min_salida = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cbo_hora_salida = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.cbo_min_entrada = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.cbo_hora_entrada = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cboFechaIni = New System.Windows.Forms.DateTimePicker()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cboFechaFin = New System.Windows.Forms.DateTimePicker()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cbo_grupos = New System.Windows.Forms.ComboBox()
        Me.chk_bod8 = New System.Windows.Forms.CheckBox()
        CType(Me.img_procesar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtg_auditoria, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Toolbar1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'img_procesar
        '
        Me.img_procesar.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.img_procesar.Image = Global.Spic.My.Resources.Resources.procesando
        Me.img_procesar.Location = New System.Drawing.Point(37, 159)
        Me.img_procesar.Name = "img_procesar"
        Me.img_procesar.Size = New System.Drawing.Size(914, 205)
        Me.img_procesar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.img_procesar.TabIndex = 1160
        Me.img_procesar.TabStop = False
        Me.img_procesar.Visible = False
        '
        'txt_prod_final
        '
        Me.txt_prod_final.Location = New System.Drawing.Point(366, 59)
        Me.txt_prod_final.Name = "txt_prod_final"
        Me.txt_prod_final.Size = New System.Drawing.Size(137, 20)
        Me.txt_prod_final.TabIndex = 1159
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(293, 61)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(68, 15)
        Me.Label6.TabIndex = 1158
        Me.Label6.Text = "Producto:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(329, 98)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 15)
        Me.Label3.TabIndex = 1152
        Me.Label3.Text = "Maquina:"
        '
        'cbo_maquina
        '
        Me.cbo_maquina.FormattingEnabled = True
        Me.cbo_maquina.Location = New System.Drawing.Point(402, 96)
        Me.cbo_maquina.Name = "cbo_maquina"
        Me.cbo_maquina.Size = New System.Drawing.Size(83, 21)
        Me.cbo_maquina.TabIndex = 1151
        '
        'cbo_operario
        '
        Me.cbo_operario.FormattingEnabled = True
        Me.cbo_operario.Location = New System.Drawing.Point(85, 99)
        Me.cbo_operario.Name = "cbo_operario"
        Me.cbo_operario.Size = New System.Drawing.Size(227, 21)
        Me.cbo_operario.TabIndex = 1150
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 100)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 15)
        Me.Label2.TabIndex = 1149
        Me.Label2.Text = "Operario:"
        '
        'txt_ordenProduccion
        '
        Me.txt_ordenProduccion.Location = New System.Drawing.Point(161, 60)
        Me.txt_ordenProduccion.Name = "txt_ordenProduccion"
        Me.txt_ordenProduccion.Size = New System.Drawing.Size(126, 20)
        Me.txt_ordenProduccion.TabIndex = 1148
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 64)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(146, 15)
        Me.Label1.TabIndex = 1147
        Me.Label1.Text = "Orden de Produccion:"
        '
        'dtg_auditoria
        '
        Me.dtg_auditoria.AllowUserToAddRows = False
        Me.dtg_auditoria.AllowUserToDeleteRows = False
        Me.dtg_auditoria.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtg_auditoria.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dtg_auditoria.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtg_auditoria.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dtg_auditoria.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtg_auditoria.DefaultCellStyle = DataGridViewCellStyle2
        Me.dtg_auditoria.Location = New System.Drawing.Point(12, 129)
        Me.dtg_auditoria.MultiSelect = False
        Me.dtg_auditoria.Name = "dtg_auditoria"
        Me.dtg_auditoria.ReadOnly = True
        Me.dtg_auditoria.RowHeadersVisible = False
        Me.dtg_auditoria.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtg_auditoria.Size = New System.Drawing.Size(967, 298)
        Me.dtg_auditoria.TabIndex = 1146
        '
        'Toolbar1
        '
        Me.Toolbar1.AutoSize = False
        Me.Toolbar1.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.Toolbar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Toolbar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Toolbar1.ImageScalingSize = New System.Drawing.Size(23, 23)
        Me.Toolbar1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator2, Me.btn_salir, Me.btn_ppal, Me.ToolStripSeparator3, Me.btnConsultar, Me.ToolStripButton3})
        Me.Toolbar1.Location = New System.Drawing.Point(0, 0)
        Me.Toolbar1.Name = "Toolbar1"
        Me.Toolbar1.Size = New System.Drawing.Size(987, 34)
        Me.Toolbar1.TabIndex = 1145
        Me.Toolbar1.Text = "ToolStrip1"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 34)
        '
        'btn_salir
        '
        Me.btn_salir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_salir.Image = Global.Spic.My.Resources.Resources._1349388328_door_in
        Me.btn_salir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_salir.Name = "btn_salir"
        Me.btn_salir.Size = New System.Drawing.Size(27, 31)
        Me.btn_salir.Text = "ToolStripButton1"
        Me.btn_salir.ToolTipText = "Salir"
        '
        'btn_ppal
        '
        Me.btn_ppal.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_ppal.Image = Global.Spic.My.Resources.Resources.ppal3
        Me.btn_ppal.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_ppal.Name = "btn_ppal"
        Me.btn_ppal.Size = New System.Drawing.Size(27, 31)
        Me.btn_ppal.Text = "ToolStripButton2"
        Me.btn_ppal.ToolTipText = "Menú principal"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 34)
        '
        'btnConsultar
        '
        Me.btnConsultar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnConsultar.Image = Global.Spic.My.Resources.Resources.update
        Me.btnConsultar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(27, 31)
        Me.btnConsultar.Text = "Consultar"
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton3.Image = Global.Spic.My.Resources.Resources.excel10
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(27, 31)
        Me.ToolStripButton3.Text = "ToolStripButton3"
        '
        'chk_sin_tamb
        '
        Me.chk_sin_tamb.AutoSize = True
        Me.chk_sin_tamb.BackColor = System.Drawing.Color.LightCoral
        Me.chk_sin_tamb.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_sin_tamb.Location = New System.Drawing.Point(142, 9)
        Me.chk_sin_tamb.Name = "chk_sin_tamb"
        Me.chk_sin_tamb.Size = New System.Drawing.Size(117, 19)
        Me.chk_sin_tamb.TabIndex = 1161
        Me.chk_sin_tamb.Text = "Sin tamborear"
        Me.chk_sin_tamb.UseVisualStyleBackColor = False
        '
        'chk_tamb
        '
        Me.chk_tamb.AutoSize = True
        Me.chk_tamb.BackColor = System.Drawing.Color.Gold
        Me.chk_tamb.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_tamb.Location = New System.Drawing.Point(266, 9)
        Me.chk_tamb.Name = "chk_tamb"
        Me.chk_tamb.Size = New System.Drawing.Size(107, 19)
        Me.chk_tamb.TabIndex = 1162
        Me.chk_tamb.Text = "Tamboreado"
        Me.chk_tamb.UseVisualStyleBackColor = False
        '
        'chk_todo
        '
        Me.chk_todo.AutoSize = True
        Me.chk_todo.BackColor = System.Drawing.Color.DarkTurquoise
        Me.chk_todo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_todo.Location = New System.Drawing.Point(885, 9)
        Me.chk_todo.Name = "chk_todo"
        Me.chk_todo.Size = New System.Drawing.Size(58, 19)
        Me.chk_todo.TabIndex = 1163
        Me.chk_todo.Text = "Todo"
        Me.chk_todo.UseVisualStyleBackColor = False
        '
        'chk_env_empaque
        '
        Me.chk_env_empaque.AutoSize = True
        Me.chk_env_empaque.BackColor = System.Drawing.Color.Violet
        Me.chk_env_empaque.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_env_empaque.Location = New System.Drawing.Point(379, 9)
        Me.chk_env_empaque.Name = "chk_env_empaque"
        Me.chk_env_empaque.Size = New System.Drawing.Size(153, 19)
        Me.chk_env_empaque.TabIndex = 1164
        Me.chk_env_empaque.Text = "Enviado a empaque"
        Me.chk_env_empaque.UseVisualStyleBackColor = False
        '
        'chk_no_conforme
        '
        Me.chk_no_conforme.AutoSize = True
        Me.chk_no_conforme.BackColor = System.Drawing.Color.ForestGreen
        Me.chk_no_conforme.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_no_conforme.Location = New System.Drawing.Point(616, 9)
        Me.chk_no_conforme.Name = "chk_no_conforme"
        Me.chk_no_conforme.Size = New System.Drawing.Size(110, 19)
        Me.chk_no_conforme.TabIndex = 1166
        Me.chk_no_conforme.Text = "No Conforme"
        Me.chk_no_conforme.UseVisualStyleBackColor = False
        '
        'chk_historial
        '
        Me.chk_historial.AutoSize = True
        Me.chk_historial.BackColor = System.Drawing.Color.LightYellow
        Me.chk_historial.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_historial.Location = New System.Drawing.Point(732, 9)
        Me.chk_historial.Name = "chk_historial"
        Me.chk_historial.Size = New System.Drawing.Size(147, 19)
        Me.chk_historial.TabIndex = 1168
        Me.chk_historial.Text = "Historial Rechazos"
        Me.chk_historial.UseVisualStyleBackColor = False
        '
        'chk_hornos
        '
        Me.chk_hornos.AutoSize = True
        Me.chk_hornos.BackColor = System.Drawing.Color.OrangeRed
        Me.chk_hornos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_hornos.Location = New System.Drawing.Point(538, 9)
        Me.chk_hornos.Name = "chk_hornos"
        Me.chk_hornos.Size = New System.Drawing.Size(72, 19)
        Me.chk_hornos.TabIndex = 1169
        Me.chk_hornos.Text = "Hornos"
        Me.chk_hornos.UseVisualStyleBackColor = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(887, 89)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(49, 13)
        Me.Label7.TabIndex = 1218
        Me.Label7.Text = "Minuto:"
        '
        'cbo_min_salida
        '
        Me.cbo_min_salida.FormattingEnabled = True
        Me.cbo_min_salida.Items.AddRange(New Object() {"00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "51", "52", "53", "54", "55", "56", "57", "58", "59", "", ""})
        Me.cbo_min_salida.Location = New System.Drawing.Point(936, 86)
        Me.cbo_min_salida.Name = "cbo_min_salida"
        Me.cbo_min_salida.Size = New System.Drawing.Size(41, 21)
        Me.cbo_min_salida.TabIndex = 1217
        Me.cbo_min_salida.Text = "00"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(755, 90)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(66, 13)
        Me.Label8.TabIndex = 1216
        Me.Label8.Text = "Hora final:"
        '
        'cbo_hora_salida
        '
        Me.cbo_hora_salida.FormattingEnabled = True
        Me.cbo_hora_salida.Items.AddRange(New Object() {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24"})
        Me.cbo_hora_salida.Location = New System.Drawing.Point(846, 86)
        Me.cbo_hora_salida.Name = "cbo_hora_salida"
        Me.cbo_hora_salida.Size = New System.Drawing.Size(38, 21)
        Me.cbo_hora_salida.TabIndex = 1215
        Me.cbo_hora_salida.Text = "6"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(888, 67)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(49, 13)
        Me.Label15.TabIndex = 1214
        Me.Label15.Text = "Minuto:"
        '
        'cbo_min_entrada
        '
        Me.cbo_min_entrada.FormattingEnabled = True
        Me.cbo_min_entrada.Items.AddRange(New Object() {"00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "51", "52", "53", "54", "55", "56", "57", "58", "59", "", ""})
        Me.cbo_min_entrada.Location = New System.Drawing.Point(937, 62)
        Me.cbo_min_entrada.Name = "cbo_min_entrada"
        Me.cbo_min_entrada.Size = New System.Drawing.Size(41, 21)
        Me.cbo_min_entrada.TabIndex = 1213
        Me.cbo_min_entrada.Text = "00"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(755, 66)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(75, 13)
        Me.Label16.TabIndex = 1212
        Me.Label16.Text = "Hora inicial:"
        '
        'cbo_hora_entrada
        '
        Me.cbo_hora_entrada.FormattingEnabled = True
        Me.cbo_hora_entrada.Items.AddRange(New Object() {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24"})
        Me.cbo_hora_entrada.Location = New System.Drawing.Point(847, 62)
        Me.cbo_hora_entrada.Name = "cbo_hora_entrada"
        Me.cbo_hora_entrada.Size = New System.Drawing.Size(38, 21)
        Me.cbo_hora_entrada.TabIndex = 1211
        Me.cbo_hora_entrada.Text = "6"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboFechaIni)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.cboFechaFin)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Location = New System.Drawing.Point(605, 52)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(152, 60)
        Me.GroupBox1.TabIndex = 1210
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Rango de fecha"
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
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(3, 18)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(45, 13)
        Me.Label9.TabIndex = 1029
        Me.Label9.Text = "Inicial:"
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
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(12, 39)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(38, 13)
        Me.Label10.TabIndex = 1031
        Me.Label10.Text = "Final:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(509, 79)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(50, 15)
        Me.Label4.TabIndex = 1220
        Me.Label4.Text = "Grupo:"
        '
        'cbo_grupos
        '
        Me.cbo_grupos.FormattingEnabled = True
        Me.cbo_grupos.Items.AddRange(New Object() {"Grupo A", "Grupo B", "Grupo C", "Grupo D", "Grupo E", "Grupo G"})
        Me.cbo_grupos.Location = New System.Drawing.Point(509, 97)
        Me.cbo_grupos.Name = "cbo_grupos"
        Me.cbo_grupos.Size = New System.Drawing.Size(83, 21)
        Me.cbo_grupos.TabIndex = 1219
        '
        'chk_bod8
        '
        Me.chk_bod8.AutoSize = True
        Me.chk_bod8.BackColor = System.Drawing.Color.Chocolate
        Me.chk_bod8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_bod8.Location = New System.Drawing.Point(949, 9)
        Me.chk_bod8.Name = "chk_bod8"
        Me.chk_bod8.Size = New System.Drawing.Size(63, 19)
        Me.chk_bod8.TabIndex = 1221
        Me.chk_bod8.Text = "Bod 8"
        Me.chk_bod8.UseVisualStyleBackColor = False
        '
        'Frm_auditoria_puntilleria
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(987, 434)
        Me.Controls.Add(Me.chk_bod8)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cbo_grupos)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.cbo_min_salida)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.cbo_hora_salida)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.cbo_min_entrada)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.cbo_hora_entrada)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.chk_hornos)
        Me.Controls.Add(Me.chk_historial)
        Me.Controls.Add(Me.chk_no_conforme)
        Me.Controls.Add(Me.chk_env_empaque)
        Me.Controls.Add(Me.chk_todo)
        Me.Controls.Add(Me.chk_tamb)
        Me.Controls.Add(Me.chk_sin_tamb)
        Me.Controls.Add(Me.img_procesar)
        Me.Controls.Add(Me.txt_prod_final)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cbo_maquina)
        Me.Controls.Add(Me.cbo_operario)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txt_ordenProduccion)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dtg_auditoria)
        Me.Controls.Add(Me.Toolbar1)
        Me.Name = "Frm_auditoria_puntilleria"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Auditoria de Puntilleria"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.img_procesar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtg_auditoria, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Toolbar1.ResumeLayout(False)
        Me.Toolbar1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents img_procesar As PictureBox
    Friend WithEvents txt_prod_final As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents cbo_maquina As ComboBox
    Friend WithEvents cbo_operario As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txt_ordenProduccion As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents dtg_auditoria As DataGridView
    Friend WithEvents Toolbar1 As ToolStrip
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents btn_salir As ToolStripButton
    Friend WithEvents btn_ppal As ToolStripButton
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents btnConsultar As ToolStripButton
    Friend WithEvents chk_sin_tamb As CheckBox
    Friend WithEvents chk_tamb As CheckBox
    Friend WithEvents chk_todo As CheckBox
    Friend WithEvents chk_env_empaque As CheckBox
    Friend WithEvents ToolStripButton3 As ToolStripButton
    Friend WithEvents chk_no_conforme As System.Windows.Forms.CheckBox
    Friend WithEvents chk_historial As System.Windows.Forms.CheckBox
    Friend WithEvents chk_hornos As System.Windows.Forms.CheckBox
    Friend WithEvents Label7 As Label
    Friend WithEvents cbo_min_salida As ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents cbo_hora_salida As ComboBox
    Friend WithEvents Label15 As Label
    Friend WithEvents cbo_min_entrada As ComboBox
    Friend WithEvents Label16 As Label
    Friend WithEvents cbo_hora_entrada As ComboBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents cboFechaIni As DateTimePicker
    Friend WithEvents Label9 As Label
    Friend WithEvents cboFechaFin As DateTimePicker
    Friend WithEvents Label10 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents cbo_grupos As ComboBox
    Friend WithEvents chk_bod8 As CheckBox
End Class
