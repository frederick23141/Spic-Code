<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_reloj
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim ChartArea2 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend2 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series2 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dtgConsulta = New System.Windows.Forms.DataGridView()
        Me.menStripDtg = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.itemDetalle = New System.Windows.Forms.ToolStripMenuItem()
        Me.DetalleDeIncapacidadesAñoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GraficarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboAnoIni = New System.Windows.Forms.ComboBox()
        Me.cboMesFin = New System.Windows.Forms.ComboBox()
        Me.lbl_mes = New System.Windows.Forms.Label()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.cboMesIni = New System.Windows.Forms.ComboBox()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnActualizar = New System.Windows.Forms.ToolStripButton()
        Me.btnExcel = New System.Windows.Forms.ToolStripButton()
        Me.Toolbar1 = New System.Windows.Forms.ToolStrip()
        Me.cboCentro = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.chkDetalle = New System.Windows.Forms.CheckBox()
        Me.img_procesar = New System.Windows.Forms.PictureBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chkAusent = New System.Windows.Forms.CheckBox()
        Me.chkExtra = New System.Windows.Forms.CheckBox()
        Me.chkOrd = New System.Windows.Forms.CheckBox()
        Me.groupDetalle = New System.Windows.Forms.GroupBox()
        Me.btn_cerrar_graf = New System.Windows.Forms.Button()
        Me.dtgDetalle = New System.Windows.Forms.DataGridView()
        Me.menStipDetalle = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.btn_cerrar_grafico = New System.Windows.Forms.Button()
        Me.group_detalle_concepto = New System.Windows.Forms.GroupBox()
        Me.btn_cerrar_det_concepto = New System.Windows.Forms.Button()
        Me.dtg_detalle_concepto = New System.Windows.Forms.DataGridView()
        CType(Me.dtgConsulta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.menStripDtg.SuspendLayout()
        Me.Toolbar1.SuspendLayout()
        CType(Me.img_procesar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.groupDetalle.SuspendLayout()
        CType(Me.dtgDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.menStipDetalle.SuspendLayout()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.group_detalle_concepto.SuspendLayout()
        CType(Me.dtg_detalle_concepto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dtgConsulta
        '
        Me.dtgConsulta.AllowUserToAddRows = False
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dtgConsulta.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle7
        Me.dtgConsulta.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtgConsulta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dtgConsulta.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dtgConsulta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgConsulta.ContextMenuStrip = Me.menStripDtg
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.Format = "N0"
        DataGridViewCellStyle8.NullValue = "0"
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtgConsulta.DefaultCellStyle = DataGridViewCellStyle8
        Me.dtgConsulta.Location = New System.Drawing.Point(12, 110)
        Me.dtgConsulta.Name = "dtgConsulta"
        Me.dtgConsulta.ReadOnly = True
        Me.dtgConsulta.RowHeadersVisible = False
        Me.dtgConsulta.Size = New System.Drawing.Size(843, 365)
        Me.dtgConsulta.TabIndex = 1052
        '
        'menStripDtg
        '
        Me.menStripDtg.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.menStripDtg.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.itemDetalle, Me.DetalleDeIncapacidadesAñoToolStripMenuItem, Me.GraficarToolStripMenuItem})
        Me.menStripDtg.Name = "ContextMenuStrip1"
        Me.menStripDtg.Size = New System.Drawing.Size(239, 70)
        '
        'itemDetalle
        '
        Me.itemDetalle.Image = Global.Spic.My.Resources.Resources.buscar7
        Me.itemDetalle.Name = "itemDetalle"
        Me.itemDetalle.Size = New System.Drawing.Size(238, 22)
        Me.itemDetalle.Text = "Detalle"
        '
        'DetalleDeIncapacidadesAñoToolStripMenuItem
        '
        Me.DetalleDeIncapacidadesAñoToolStripMenuItem.Image = Global.Spic.My.Resources.Resources.buscar7
        Me.DetalleDeIncapacidadesAñoToolStripMenuItem.Name = "DetalleDeIncapacidadesAñoToolStripMenuItem"
        Me.DetalleDeIncapacidadesAñoToolStripMenuItem.Size = New System.Drawing.Size(238, 22)
        Me.DetalleDeIncapacidadesAñoToolStripMenuItem.Text = "Detalle de incapacidades año"
        '
        'GraficarToolStripMenuItem
        '
        Me.GraficarToolStripMenuItem.Image = Global.Spic.My.Resources.Resources.est
        Me.GraficarToolStripMenuItem.Name = "GraficarToolStripMenuItem"
        Me.GraficarToolStripMenuItem.Size = New System.Drawing.Size(238, 22)
        Me.GraficarToolStripMenuItem.Text = "Graficar"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(463, 47)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 13)
        Me.Label1.TabIndex = 1078
        Me.Label1.Text = "Mes final:"
        '
        'cboAnoIni
        '
        Me.cboAnoIni.FormattingEnabled = True
        Me.cboAnoIni.Location = New System.Drawing.Point(669, 42)
        Me.cboAnoIni.Name = "cboAnoIni"
        Me.cboAnoIni.Size = New System.Drawing.Size(79, 21)
        Me.cboAnoIni.TabIndex = 1075
        Me.cboAnoIni.Text = "Seleccione"
        '
        'cboMesFin
        '
        Me.cboMesFin.FormattingEnabled = True
        Me.cboMesFin.Items.AddRange(New Object() {"Enero ", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"})
        Me.cboMesFin.Location = New System.Drawing.Point(527, 43)
        Me.cboMesFin.Name = "cboMesFin"
        Me.cboMesFin.Size = New System.Drawing.Size(106, 21)
        Me.cboMesFin.TabIndex = 1077
        Me.cboMesFin.Text = "Seleccione"
        '
        'lbl_mes
        '
        Me.lbl_mes.AutoSize = True
        Me.lbl_mes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_mes.Location = New System.Drawing.Point(276, 47)
        Me.lbl_mes.Name = "lbl_mes"
        Me.lbl_mes.Size = New System.Drawing.Size(71, 13)
        Me.lbl_mes.TabIndex = 1078
        Me.lbl_mes.Text = "Mes inicial:"
        '
        'Label37
        '
        Me.Label37.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label37.AutoSize = True
        Me.Label37.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.Location = New System.Drawing.Point(636, 45)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(33, 13)
        Me.Label37.TabIndex = 1076
        Me.Label37.Text = "Año:"
        '
        'cboMesIni
        '
        Me.cboMesIni.FormattingEnabled = True
        Me.cboMesIni.Items.AddRange(New Object() {"Enero ", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"})
        Me.cboMesIni.Location = New System.Drawing.Point(349, 43)
        Me.cboMesIni.Name = "cboMesIni"
        Me.cboMesIni.Size = New System.Drawing.Size(106, 21)
        Me.cboMesIni.TabIndex = 1077
        Me.cboMesIni.Text = "Seleccione"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 28)
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
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 28)
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
        'btnExcel
        '
        Me.btnExcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnExcel.Image = Global.Spic.My.Resources.Resources.excel
        Me.btnExcel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnExcel.Name = "btnExcel"
        Me.btnExcel.Size = New System.Drawing.Size(27, 25)
        Me.btnExcel.Text = "Exportar a excel"
        '
        'Toolbar1
        '
        Me.Toolbar1.AutoSize = False
        Me.Toolbar1.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.Toolbar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Toolbar1.ImageScalingSize = New System.Drawing.Size(23, 23)
        Me.Toolbar1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator2, Me.ToolStripButton1, Me.ToolStripButton2, Me.ToolStripSeparator3, Me.btnActualizar, Me.btnExcel})
        Me.Toolbar1.Location = New System.Drawing.Point(0, 0)
        Me.Toolbar1.Name = "Toolbar1"
        Me.Toolbar1.Size = New System.Drawing.Size(863, 28)
        Me.Toolbar1.TabIndex = 1045
        Me.Toolbar1.Text = "ToolStrip1"
        '
        'cboCentro
        '
        Me.cboCentro.FormattingEnabled = True
        Me.cboCentro.Location = New System.Drawing.Point(7, 42)
        Me.cboCentro.Name = "cboCentro"
        Me.cboCentro.Size = New System.Drawing.Size(258, 21)
        Me.cboCentro.TabIndex = 1084
        Me.cboCentro.Text = "Seleccione"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(5, 27)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(87, 13)
        Me.Label4.TabIndex = 1083
        Me.Label4.Text = "Centro de costos"
        '
        'chkDetalle
        '
        Me.chkDetalle.AutoSize = True
        Me.chkDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkDetalle.Location = New System.Drawing.Point(145, 8)
        Me.chkDetalle.Name = "chkDetalle"
        Me.chkDetalle.Size = New System.Drawing.Size(105, 17)
        Me.chkDetalle.TabIndex = 1085
        Me.chkDetalle.Text = "Ver en detalle"
        Me.chkDetalle.UseVisualStyleBackColor = True
        '
        'img_procesar
        '
        Me.img_procesar.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.img_procesar.Image = Global.Spic.My.Resources.Resources.procesando
        Me.img_procesar.Location = New System.Drawing.Point(50, 146)
        Me.img_procesar.Name = "img_procesar"
        Me.img_procesar.Size = New System.Drawing.Size(756, 270)
        Me.img_procesar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.img_procesar.TabIndex = 1080
        Me.img_procesar.TabStop = False
        Me.img_procesar.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkAusent)
        Me.GroupBox1.Controls.Add(Me.chkExtra)
        Me.GroupBox1.Controls.Add(Me.chkOrd)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 68)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(257, 33)
        Me.GroupBox1.TabIndex = 1082
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Trasabilidad"
        '
        'chkAusent
        '
        Me.chkAusent.AutoSize = True
        Me.chkAusent.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAusent.Location = New System.Drawing.Point(163, 15)
        Me.chkAusent.Name = "chkAusent"
        Me.chkAusent.Size = New System.Drawing.Size(89, 17)
        Me.chkAusent.TabIndex = 1087
        Me.chkAusent.Text = "T.ausentismo"
        Me.chkAusent.UseVisualStyleBackColor = True
        '
        'chkExtra
        '
        Me.chkExtra.AutoSize = True
        Me.chkExtra.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkExtra.Location = New System.Drawing.Point(93, 15)
        Me.chkExtra.Name = "chkExtra"
        Me.chkExtra.Size = New System.Drawing.Size(59, 17)
        Me.chkExtra.TabIndex = 1087
        Me.chkExtra.Text = "T.extra"
        Me.chkExtra.UseVisualStyleBackColor = True
        '
        'chkOrd
        '
        Me.chkOrd.AutoSize = True
        Me.chkOrd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkOrd.Location = New System.Drawing.Point(6, 17)
        Me.chkOrd.Name = "chkOrd"
        Me.chkOrd.Size = New System.Drawing.Size(76, 17)
        Me.chkOrd.TabIndex = 1086
        Me.chkOrd.Text = "T.ordinario"
        Me.chkOrd.UseVisualStyleBackColor = True
        '
        'groupDetalle
        '
        Me.groupDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.groupDetalle.Controls.Add(Me.btn_cerrar_graf)
        Me.groupDetalle.Controls.Add(Me.dtgDetalle)
        Me.groupDetalle.Location = New System.Drawing.Point(287, 124)
        Me.groupDetalle.Name = "groupDetalle"
        Me.groupDetalle.Size = New System.Drawing.Size(496, 253)
        Me.groupDetalle.TabIndex = 1086
        Me.groupDetalle.TabStop = False
        Me.groupDetalle.Text = "Informción a detalle"
        Me.groupDetalle.Visible = False
        '
        'btn_cerrar_graf
        '
        Me.btn_cerrar_graf.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_cerrar_graf.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_cerrar_graf.ForeColor = System.Drawing.Color.Red
        Me.btn_cerrar_graf.Location = New System.Drawing.Point(472, 1)
        Me.btn_cerrar_graf.Name = "btn_cerrar_graf"
        Me.btn_cerrar_graf.Size = New System.Drawing.Size(20, 23)
        Me.btn_cerrar_graf.TabIndex = 1088
        Me.btn_cerrar_graf.Text = "X"
        Me.btn_cerrar_graf.UseVisualStyleBackColor = True
        '
        'dtgDetalle
        '
        Me.dtgDetalle.AllowUserToAddRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dtgDetalle.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dtgDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtgDetalle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dtgDetalle.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dtgDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgDetalle.ContextMenuStrip = Me.menStipDetalle
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.Format = "N0"
        DataGridViewCellStyle2.NullValue = "0"
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtgDetalle.DefaultCellStyle = DataGridViewCellStyle2
        Me.dtgDetalle.Location = New System.Drawing.Point(6, 24)
        Me.dtgDetalle.Name = "dtgDetalle"
        Me.dtgDetalle.ReadOnly = True
        Me.dtgDetalle.RowHeadersVisible = False
        Me.dtgDetalle.Size = New System.Drawing.Size(484, 221)
        Me.dtgDetalle.TabIndex = 1087
        '
        'menStipDetalle
        '
        Me.menStipDetalle.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.menStipDetalle.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1})
        Me.menStipDetalle.Name = "ContextMenuStrip1"
        Me.menStipDetalle.Size = New System.Drawing.Size(115, 26)
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Image = Global.Spic.My.Resources.Resources.buscar7
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(114, 22)
        Me.ToolStripMenuItem1.Text = "Detalle"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(384, 85)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(42, 13)
        Me.Label8.TabIndex = 1091
        Me.Label8.Text = "Estable"
        '
        'TextBox3
        '
        Me.TextBox3.BackColor = System.Drawing.Color.Yellow
        Me.TextBox3.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox3.Location = New System.Drawing.Point(356, 85)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.ReadOnly = True
        Me.TextBox3.Size = New System.Drawing.Size(26, 13)
        Me.TextBox3.TabIndex = 1090
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(307, 84)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 13)
        Me.Label2.TabIndex = 1089
        Me.Label2.Text = "Alerta"
        '
        'TextBox2
        '
        Me.TextBox2.BackColor = System.Drawing.Color.Red
        Me.TextBox2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox2.Location = New System.Drawing.Point(279, 84)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ReadOnly = True
        Me.TextBox2.Size = New System.Drawing.Size(26, 13)
        Me.TextBox2.TabIndex = 1088
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.GreenYellow
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox1.Location = New System.Drawing.Point(429, 86)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(29, 13)
        Me.TextBox1.TabIndex = 1087
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(463, 85)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 13)
        Me.Label3.TabIndex = 1092
        Me.Label3.Text = "Bueno"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(276, 28)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(84, 13)
        Me.Label5.TabIndex = 1094
        Me.Label5.Text = "Rango de fecha"
        '
        'Chart1
        '
        Me.Chart1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Chart1.BackColor = System.Drawing.Color.Silver
        Me.Chart1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom
        Me.Chart1.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash
        ChartArea2.BorderWidth = 100
        ChartArea2.Name = "ChartArea1"
        Me.Chart1.ChartAreas.Add(ChartArea2)
        Legend2.Name = "Legend1"
        Me.Chart1.Legends.Add(Legend2)
        Me.Chart1.Location = New System.Drawing.Point(70, 110)
        Me.Chart1.Name = "Chart1"
        Series2.ChartArea = "ChartArea1"
        Series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
        Series2.Legend = "Legend1"
        Series2.Name = "Series1"
        Me.Chart1.Series.Add(Series2)
        Me.Chart1.Size = New System.Drawing.Size(736, 366)
        Me.Chart1.TabIndex = 1106
        Me.Chart1.Text = "Chart1"
        Me.Chart1.Visible = False
        '
        'btn_cerrar_grafico
        '
        Me.btn_cerrar_grafico.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_cerrar_grafico.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_cerrar_grafico.ForeColor = System.Drawing.Color.Red
        Me.btn_cerrar_grafico.Location = New System.Drawing.Point(777, 113)
        Me.btn_cerrar_grafico.Name = "btn_cerrar_grafico"
        Me.btn_cerrar_grafico.Size = New System.Drawing.Size(22, 20)
        Me.btn_cerrar_grafico.TabIndex = 1107
        Me.btn_cerrar_grafico.Text = "X"
        Me.btn_cerrar_grafico.UseVisualStyleBackColor = True
        Me.btn_cerrar_grafico.Visible = False
        '
        'group_detalle_concepto
        '
        Me.group_detalle_concepto.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.group_detalle_concepto.Controls.Add(Me.btn_cerrar_det_concepto)
        Me.group_detalle_concepto.Controls.Add(Me.dtg_detalle_concepto)
        Me.group_detalle_concepto.Location = New System.Drawing.Point(137, 148)
        Me.group_detalle_concepto.Name = "group_detalle_concepto"
        Me.group_detalle_concepto.Size = New System.Drawing.Size(590, 253)
        Me.group_detalle_concepto.TabIndex = 1089
        Me.group_detalle_concepto.TabStop = False
        Me.group_detalle_concepto.Text = "Informción a detalle por concepto"
        Me.group_detalle_concepto.Visible = False
        '
        'btn_cerrar_det_concepto
        '
        Me.btn_cerrar_det_concepto.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_cerrar_det_concepto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_cerrar_det_concepto.ForeColor = System.Drawing.Color.Red
        Me.btn_cerrar_det_concepto.Location = New System.Drawing.Point(566, 1)
        Me.btn_cerrar_det_concepto.Name = "btn_cerrar_det_concepto"
        Me.btn_cerrar_det_concepto.Size = New System.Drawing.Size(20, 23)
        Me.btn_cerrar_det_concepto.TabIndex = 1088
        Me.btn_cerrar_det_concepto.Text = "X"
        Me.btn_cerrar_det_concepto.UseVisualStyleBackColor = True
        '
        'dtg_detalle_concepto
        '
        Me.dtg_detalle_concepto.AllowUserToAddRows = False
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dtg_detalle_concepto.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
        Me.dtg_detalle_concepto.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtg_detalle_concepto.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dtg_detalle_concepto.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dtg_detalle_concepto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.Format = "N0"
        DataGridViewCellStyle4.NullValue = "0"
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtg_detalle_concepto.DefaultCellStyle = DataGridViewCellStyle4
        Me.dtg_detalle_concepto.Location = New System.Drawing.Point(6, 24)
        Me.dtg_detalle_concepto.Name = "dtg_detalle_concepto"
        Me.dtg_detalle_concepto.ReadOnly = True
        Me.dtg_detalle_concepto.RowHeadersVisible = False
        Me.dtg_detalle_concepto.Size = New System.Drawing.Size(578, 221)
        Me.dtg_detalle_concepto.TabIndex = 1087
        '
        'Frm_reloj
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(863, 488)
        Me.Controls.Add(Me.groupDetalle)
        Me.Controls.Add(Me.group_detalle_concepto)
        Me.Controls.Add(Me.btn_cerrar_grafico)
        Me.Controls.Add(Me.Chart1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboAnoIni)
        Me.Controls.Add(Me.cboMesFin)
        Me.Controls.Add(Me.lbl_mes)
        Me.Controls.Add(Me.Label37)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cboMesIni)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.img_procesar)
        Me.Controls.Add(Me.chkDetalle)
        Me.Controls.Add(Me.dtgConsulta)
        Me.Controls.Add(Me.cboCentro)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Toolbar1)
        Me.Name = "Frm_reloj"
        Me.Text = "Tiempos laborados"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dtgConsulta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.menStripDtg.ResumeLayout(False)
        Me.Toolbar1.ResumeLayout(False)
        Me.Toolbar1.PerformLayout()
        CType(Me.img_procesar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.groupDetalle.ResumeLayout(False)
        CType(Me.dtgDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.menStipDetalle.ResumeLayout(False)
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.group_detalle_concepto.ResumeLayout(False)
        CType(Me.dtg_detalle_concepto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtgConsulta As System.Windows.Forms.DataGridView
    Friend WithEvents cboAnoIni As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_mes As System.Windows.Forms.Label
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents cboMesIni As System.Windows.Forms.ComboBox
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnActualizar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnExcel As System.Windows.Forms.ToolStripButton
    Friend WithEvents Toolbar1 As System.Windows.Forms.ToolStrip
    Friend WithEvents cboCentro As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents chkDetalle As System.Windows.Forms.CheckBox
    Friend WithEvents img_procesar As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents chkAusent As System.Windows.Forms.CheckBox
    Friend WithEvents chkExtra As System.Windows.Forms.CheckBox
    Friend WithEvents chkOrd As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboMesFin As System.Windows.Forms.ComboBox
    Friend WithEvents groupDetalle As System.Windows.Forms.GroupBox
    Friend WithEvents dtgDetalle As System.Windows.Forms.DataGridView
    Friend WithEvents menStripDtg As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents itemDetalle As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btn_cerrar_graf As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GraficarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Chart1 As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents btn_cerrar_grafico As System.Windows.Forms.Button
    Friend WithEvents DetalleDeIncapacidadesAñoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menStipDetalle As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents group_detalle_concepto As System.Windows.Forms.GroupBox
    Friend WithEvents btn_cerrar_det_concepto As System.Windows.Forms.Button
    Friend WithEvents dtg_detalle_concepto As System.Windows.Forms.DataGridView
End Class
