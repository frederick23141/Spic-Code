<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_rotacion_personal
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_rotacion_personal))
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.dtgConsulta = New System.Windows.Forms.DataGridView()
        Me.menStripDtg = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.itemDetalle = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
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
        Me.btnGuardar = New System.Windows.Forms.ToolStripButton()
        Me.btn_graficar = New System.Windows.Forms.ToolStripSplitButton()
        Me.PERSONALEXISTENTETOTALToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.INGRESOMESToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RETIROMESToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.img_procesar = New System.Windows.Forms.PictureBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txt_observaciones = New System.Windows.Forms.RichTextBox()
        Me.groupDetalle = New System.Windows.Forms.GroupBox()
        Me.btn_cerrar_graf = New System.Windows.Forms.Button()
        Me.dtgDetalle = New System.Windows.Forms.DataGridView()
        Me.btn_cerrar = New System.Windows.Forms.Button()
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.menuCharlt = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.guardarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        CType(Me.dtgConsulta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.menStripDtg.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Toolbar1.SuspendLayout()
        CType(Me.img_procesar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.groupDetalle.SuspendLayout()
        CType(Me.dtgDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.menuCharlt.SuspendLayout()
        Me.SuspendLayout()
        '
        'dtgConsulta
        '
        Me.dtgConsulta.AllowUserToAddRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dtgConsulta.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dtgConsulta.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtgConsulta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dtgConsulta.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dtgConsulta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgConsulta.ContextMenuStrip = Me.menStripDtg
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.Format = "N0"
        DataGridViewCellStyle2.NullValue = "0"
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtgConsulta.DefaultCellStyle = DataGridViewCellStyle2
        Me.dtgConsulta.Location = New System.Drawing.Point(12, 75)
        Me.dtgConsulta.Name = "dtgConsulta"
        Me.dtgConsulta.ReadOnly = True
        Me.dtgConsulta.RowHeadersVisible = False
        Me.dtgConsulta.Size = New System.Drawing.Size(843, 242)
        Me.dtgConsulta.TabIndex = 1052
        '
        'menStripDtg
        '
        Me.menStripDtg.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.menStripDtg.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.itemDetalle})
        Me.menStripDtg.Name = "ContextMenuStrip1"
        Me.menStripDtg.Size = New System.Drawing.Size(153, 48)
        '
        'itemDetalle
        '
        Me.itemDetalle.Image = Global.Spic.My.Resources.Resources.buscar7
        Me.itemDetalle.Name = "itemDetalle"
        Me.itemDetalle.Size = New System.Drawing.Size(152, 22)
        Me.itemDetalle.Text = "Detalle"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.cboAnoIni)
        Me.GroupBox2.Controls.Add(Me.cboMesFin)
        Me.GroupBox2.Controls.Add(Me.lbl_mes)
        Me.GroupBox2.Controls.Add(Me.Label37)
        Me.GroupBox2.Controls.Add(Me.cboMesIni)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 31)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(484, 38)
        Me.GroupBox2.TabIndex = 1081
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Fecha inicial"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(192, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 13)
        Me.Label1.TabIndex = 1078
        Me.Label1.Text = "Mes final:"
        '
        'cboAnoIni
        '
        Me.cboAnoIni.FormattingEnabled = True
        Me.cboAnoIni.Location = New System.Drawing.Point(398, 13)
        Me.cboAnoIni.Name = "cboAnoIni"
        Me.cboAnoIni.Size = New System.Drawing.Size(79, 21)
        Me.cboAnoIni.TabIndex = 1075
        Me.cboAnoIni.Text = "Seleccione"
        '
        'cboMesFin
        '
        Me.cboMesFin.FormattingEnabled = True
        Me.cboMesFin.Items.AddRange(New Object() {"Enero ", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"})
        Me.cboMesFin.Location = New System.Drawing.Point(256, 14)
        Me.cboMesFin.Name = "cboMesFin"
        Me.cboMesFin.Size = New System.Drawing.Size(106, 21)
        Me.cboMesFin.TabIndex = 1077
        Me.cboMesFin.Text = "Seleccione"
        '
        'lbl_mes
        '
        Me.lbl_mes.AutoSize = True
        Me.lbl_mes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_mes.Location = New System.Drawing.Point(5, 18)
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
        Me.Label37.Location = New System.Drawing.Point(365, 16)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(33, 13)
        Me.Label37.TabIndex = 1076
        Me.Label37.Text = "Año:"
        '
        'cboMesIni
        '
        Me.cboMesIni.FormattingEnabled = True
        Me.cboMesIni.Items.AddRange(New Object() {"Enero ", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"})
        Me.cboMesIni.Location = New System.Drawing.Point(78, 14)
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
        Me.Toolbar1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator2, Me.ToolStripButton1, Me.ToolStripButton2, Me.ToolStripSeparator3, Me.btnGuardar, Me.btnActualizar, Me.btnExcel, Me.btn_graficar})
        Me.Toolbar1.Location = New System.Drawing.Point(0, 0)
        Me.Toolbar1.Name = "Toolbar1"
        Me.Toolbar1.Size = New System.Drawing.Size(863, 28)
        Me.Toolbar1.TabIndex = 1045
        Me.Toolbar1.Text = "ToolStrip1"
        '
        'btnGuardar
        '
        Me.btnGuardar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Padding = New System.Windows.Forms.Padding(0, 0, 8, 0)
        Me.btnGuardar.Size = New System.Drawing.Size(35, 25)
        Me.btnGuardar.Text = "Guardar"
        '
        'btn_graficar
        '
        Me.btn_graficar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_graficar.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PERSONALEXISTENTETOTALToolStripMenuItem, Me.INGRESOMESToolStripMenuItem, Me.RETIROMESToolStripMenuItem})
        Me.btn_graficar.Image = Global.Spic.My.Resources.Resources.est
        Me.btn_graficar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_graficar.Name = "btn_graficar"
        Me.btn_graficar.Size = New System.Drawing.Size(39, 25)
        Me.btn_graficar.Text = "Graficar"
        '
        'PERSONALEXISTENTETOTALToolStripMenuItem
        '
        Me.PERSONALEXISTENTETOTALToolStripMenuItem.Image = Global.Spic.My.Resources.Resources.grafic2
        Me.PERSONALEXISTENTETOTALToolStripMenuItem.Name = "PERSONALEXISTENTETOTALToolStripMenuItem"
        Me.PERSONALEXISTENTETOTALToolStripMenuItem.Size = New System.Drawing.Size(240, 22)
        Me.PERSONALEXISTENTETOTALToolStripMenuItem.Text = "PERSONAL EXISTENTE (TOTAL)"
        '
        'INGRESOMESToolStripMenuItem
        '
        Me.INGRESOMESToolStripMenuItem.Image = Global.Spic.My.Resources.Resources.grafic2
        Me.INGRESOMESToolStripMenuItem.Name = "INGRESOMESToolStripMenuItem"
        Me.INGRESOMESToolStripMenuItem.Size = New System.Drawing.Size(240, 22)
        Me.INGRESOMESToolStripMenuItem.Text = "INGRESO MES"
        '
        'RETIROMESToolStripMenuItem
        '
        Me.RETIROMESToolStripMenuItem.Image = Global.Spic.My.Resources.Resources.grafic2
        Me.RETIROMESToolStripMenuItem.Name = "RETIROMESToolStripMenuItem"
        Me.RETIROMESToolStripMenuItem.Size = New System.Drawing.Size(240, 22)
        Me.RETIROMESToolStripMenuItem.Text = "RETIRO MES"
        '
        'img_procesar
        '
        Me.img_procesar.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.img_procesar.Image = Global.Spic.My.Resources.Resources.procesando
        Me.img_procesar.Location = New System.Drawing.Point(50, 94)
        Me.img_procesar.Name = "img_procesar"
        Me.img_procesar.Size = New System.Drawing.Size(756, 198)
        Me.img_procesar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.img_procesar.TabIndex = 1080
        Me.img_procesar.TabStop = False
        Me.img_procesar.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(613, 50)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(42, 13)
        Me.Label8.TabIndex = 1091
        Me.Label8.Text = "Estable"
        '
        'TextBox3
        '
        Me.TextBox3.BackColor = System.Drawing.Color.Yellow
        Me.TextBox3.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox3.Location = New System.Drawing.Point(585, 50)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.ReadOnly = True
        Me.TextBox3.Size = New System.Drawing.Size(26, 13)
        Me.TextBox3.TabIndex = 1090
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(536, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 13)
        Me.Label2.TabIndex = 1089
        Me.Label2.Text = "Alerta"
        '
        'TextBox2
        '
        Me.TextBox2.BackColor = System.Drawing.Color.Red
        Me.TextBox2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox2.Location = New System.Drawing.Point(508, 49)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ReadOnly = True
        Me.TextBox2.Size = New System.Drawing.Size(26, 13)
        Me.TextBox2.TabIndex = 1088
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.GreenYellow
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox1.Location = New System.Drawing.Point(658, 51)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(29, 13)
        Me.TextBox1.TabIndex = 1087
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(692, 50)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 13)
        Me.Label3.TabIndex = 1092
        Me.Label3.Text = "Bueno"
        '
        'Label4
        '
        Me.Label4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(12, 320)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(158, 13)
        Me.Label4.TabIndex = 1093
        Me.Label4.Text = "Obervaciones de rotación anual"
        '
        'txt_observaciones
        '
        Me.txt_observaciones.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_observaciones.Location = New System.Drawing.Point(12, 337)
        Me.txt_observaciones.Name = "txt_observaciones"
        Me.txt_observaciones.Size = New System.Drawing.Size(843, 76)
        Me.txt_observaciones.TabIndex = 1094
        Me.txt_observaciones.Text = ""
        '
        'groupDetalle
        '
        Me.groupDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.groupDetalle.Controls.Add(Me.btn_cerrar_graf)
        Me.groupDetalle.Controls.Add(Me.dtgDetalle)
        Me.groupDetalle.Location = New System.Drawing.Point(183, 82)
        Me.groupDetalle.Name = "groupDetalle"
        Me.groupDetalle.Size = New System.Drawing.Size(351, 210)
        Me.groupDetalle.TabIndex = 1096
        Me.groupDetalle.TabStop = False
        Me.groupDetalle.Text = "Informción a detalle"
        Me.groupDetalle.Visible = False
        '
        'btn_cerrar_graf
        '
        Me.btn_cerrar_graf.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_cerrar_graf.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_cerrar_graf.ForeColor = System.Drawing.Color.Red
        Me.btn_cerrar_graf.Location = New System.Drawing.Point(327, 1)
        Me.btn_cerrar_graf.Name = "btn_cerrar_graf"
        Me.btn_cerrar_graf.Size = New System.Drawing.Size(20, 23)
        Me.btn_cerrar_graf.TabIndex = 1088
        Me.btn_cerrar_graf.Text = "X"
        Me.btn_cerrar_graf.UseVisualStyleBackColor = True
        '
        'dtgDetalle
        '
        Me.dtgDetalle.AllowUserToAddRows = False
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dtgDetalle.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
        Me.dtgDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtgDetalle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dtgDetalle.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dtgDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.Format = "N0"
        DataGridViewCellStyle4.NullValue = "0"
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtgDetalle.DefaultCellStyle = DataGridViewCellStyle4
        Me.dtgDetalle.Location = New System.Drawing.Point(6, 24)
        Me.dtgDetalle.Name = "dtgDetalle"
        Me.dtgDetalle.ReadOnly = True
        Me.dtgDetalle.RowHeadersVisible = False
        Me.dtgDetalle.Size = New System.Drawing.Size(339, 178)
        Me.dtgDetalle.TabIndex = 1087
        '
        'btn_cerrar
        '
        Me.btn_cerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_cerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_cerrar.ForeColor = System.Drawing.Color.Red
        Me.btn_cerrar.Location = New System.Drawing.Point(835, 49)
        Me.btn_cerrar.Name = "btn_cerrar"
        Me.btn_cerrar.Size = New System.Drawing.Size(20, 23)
        Me.btn_cerrar.TabIndex = 1098
        Me.btn_cerrar.Text = "X"
        Me.btn_cerrar.UseVisualStyleBackColor = True
        Me.btn_cerrar.Visible = False
        '
        'Chart1
        '
        Me.Chart1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Chart1.BackColor = System.Drawing.Color.Silver
        Me.Chart1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom
        Me.Chart1.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash
        ChartArea1.BorderWidth = 100
        ChartArea1.Name = "ChartArea1"
        Me.Chart1.ChartAreas.Add(ChartArea1)
        Me.Chart1.ContextMenuStrip = Me.menuCharlt
        Legend1.Name = "Legend1"
        Me.Chart1.Legends.Add(Legend1)
        Me.Chart1.Location = New System.Drawing.Point(12, 74)
        Me.Chart1.Name = "Chart1"
        Series1.ChartArea = "ChartArea1"
        Series1.Legend = "Legend1"
        Series1.Name = "Series1"
        Me.Chart1.Series.Add(Series1)
        Me.Chart1.Size = New System.Drawing.Size(843, 336)
        Me.Chart1.TabIndex = 1097
        Me.Chart1.Text = "Chart1"
        Me.Chart1.Visible = False
        '
        'menuCharlt
        '
        Me.menuCharlt.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.guardarToolStripMenuItem})
        Me.menuCharlt.Name = "ContextMenuStrip1"
        Me.menuCharlt.Size = New System.Drawing.Size(151, 26)
        '
        'guardarToolStripMenuItem
        '
        Me.guardarToolStripMenuItem.Image = Global.Spic.My.Resources.Resources.save_16
        Me.guardarToolStripMenuItem.Name = "guardarToolStripMenuItem"
        Me.guardarToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
        Me.guardarToolStripMenuItem.Text = "Guardar como"
        '
        'SaveFileDialog1
        '
        Me.SaveFileDialog1.Filter = """JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif"""
        Me.SaveFileDialog1.Title = "Guardar imagen como"
        '
        'Frm_rotacion_personal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(863, 416)
        Me.Controls.Add(Me.btn_cerrar)
        Me.Controls.Add(Me.Chart1)
        Me.Controls.Add(Me.groupDetalle)
        Me.Controls.Add(Me.txt_observaciones)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.img_procesar)
        Me.Controls.Add(Me.dtgConsulta)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Toolbar1)
        Me.Name = "Frm_rotacion_personal"
        Me.Text = "Rotación de personal"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dtgConsulta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.menStripDtg.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.Toolbar1.ResumeLayout(False)
        Me.Toolbar1.PerformLayout()
        CType(Me.img_procesar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.groupDetalle.ResumeLayout(False)
        CType(Me.dtgDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.menuCharlt.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtgConsulta As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
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
    Friend WithEvents img_procesar As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboMesFin As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txt_observaciones As System.Windows.Forms.RichTextBox
    Friend WithEvents btnGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents menStripDtg As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents itemDetalle As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents groupDetalle As System.Windows.Forms.GroupBox
    Friend WithEvents btn_cerrar_graf As System.Windows.Forms.Button
    Friend WithEvents dtgDetalle As System.Windows.Forms.DataGridView
    Friend WithEvents btn_cerrar As System.Windows.Forms.Button
    Friend WithEvents Chart1 As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents btn_graficar As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents PERSONALEXISTENTETOTALToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents INGRESOMESToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RETIROMESToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents menuCharlt As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents guardarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
