<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_consultar_tref
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.dtg_consulta = New System.Windows.Forms.DataGridView()
        Me.menStripDtg = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EliminarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ModificarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Toolbar1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSplitButton1 = New System.Windows.Forms.ToolStripSplitButton()
        Me.ParosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProducciónToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btn_excel = New System.Windows.Forms.ToolStripButton()
        Me.btn_pantallazo = New System.Windows.Forms.ToolStripButton()
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.btn_cerrar_graf = New System.Windows.Forms.Button()
        Me.chk_prod = New System.Windows.Forms.CheckBox()
        Me.chk_paro = New System.Windows.Forms.CheckBox()
        Me.G_grafico = New System.Windows.Forms.GroupBox()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.imgProcesar = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.cbo_fecha_fin = New System.Windows.Forms.DateTimePicker()
        Me.cbo_fecha_ini = New System.Windows.Forms.DateTimePicker()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cbo_maquina = New System.Windows.Forms.ComboBox()
        Me.cbo_operario = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.chk_consol_op = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        CType(Me.dtg_consulta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.menStripDtg.SuspendLayout()
        Me.Toolbar1.SuspendLayout()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.G_grafico.SuspendLayout()
        CType(Me.imgProcesar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dtg_consulta
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro
        Me.dtg_consulta.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dtg_consulta.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtg_consulta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dtg_consulta.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dtg_consulta.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtg_consulta.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dtg_consulta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtg_consulta.ContextMenuStrip = Me.menStripDtg
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.Format = "N0"
        DataGridViewCellStyle3.NullValue = "0"
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtg_consulta.DefaultCellStyle = DataGridViewCellStyle3
        Me.dtg_consulta.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dtg_consulta.Location = New System.Drawing.Point(4, 103)
        Me.dtg_consulta.Name = "dtg_consulta"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtg_consulta.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dtg_consulta.RowHeadersVisible = False
        Me.dtg_consulta.Size = New System.Drawing.Size(733, 366)
        Me.dtg_consulta.TabIndex = 139
        '
        'menStripDtg
        '
        Me.menStripDtg.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.menStripDtg.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EliminarToolStripMenuItem, Me.ModificarToolStripMenuItem})
        Me.menStripDtg.Name = "ContextMenuStrip1"
        Me.menStripDtg.Size = New System.Drawing.Size(153, 70)
        '
        'EliminarToolStripMenuItem
        '
        Me.EliminarToolStripMenuItem.Image = Global.Spic.My.Resources.Resources.x
        Me.EliminarToolStripMenuItem.Name = "EliminarToolStripMenuItem"
        Me.EliminarToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.EliminarToolStripMenuItem.Text = "Eliminar"
        '
        'ModificarToolStripMenuItem
        '
        Me.ModificarToolStripMenuItem.Image = Global.Spic.My.Resources.Resources.update
        Me.ModificarToolStripMenuItem.Name = "ModificarToolStripMenuItem"
        Me.ModificarToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.ModificarToolStripMenuItem.Text = "Modificar"
        '
        'Toolbar1
        '
        Me.Toolbar1.AutoSize = False
        Me.Toolbar1.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.Toolbar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Toolbar1.ImageScalingSize = New System.Drawing.Size(23, 23)
        Me.Toolbar1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator2, Me.ToolStripButton1, Me.ToolStripButton2, Me.ToolStripSeparator3, Me.ToolStripSplitButton1, Me.btn_excel, Me.btn_pantallazo})
        Me.Toolbar1.Location = New System.Drawing.Point(0, 0)
        Me.Toolbar1.Name = "Toolbar1"
        Me.Toolbar1.Size = New System.Drawing.Size(741, 33)
        Me.Toolbar1.TabIndex = 1025
        Me.Toolbar1.Text = "ToolStrip1"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 33)
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = Global.Spic.My.Resources.Resources._1349388328_door_in
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(27, 30)
        Me.ToolStripButton1.Text = "ToolStripButton1"
        Me.ToolStripButton1.ToolTipText = "Salir"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton2.Image = Global.Spic.My.Resources.Resources.ppal3
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(27, 30)
        Me.ToolStripButton2.Text = "ToolStripButton2"
        Me.ToolStripButton2.ToolTipText = "Menú principal"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 33)
        '
        'ToolStripSplitButton1
        '
        Me.ToolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripSplitButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ParosToolStripMenuItem, Me.ProducciónToolStripMenuItem})
        Me.ToolStripSplitButton1.Image = Global.Spic.My.Resources.Resources.grafico10
        Me.ToolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripSplitButton1.Name = "ToolStripSplitButton1"
        Me.ToolStripSplitButton1.Size = New System.Drawing.Size(39, 30)
        Me.ToolStripSplitButton1.Text = "ToolStripSplitButton1"
        '
        'ParosToolStripMenuItem
        '
        Me.ParosToolStripMenuItem.Image = Global.Spic.My.Resources.Resources._stop
        Me.ParosToolStripMenuItem.Name = "ParosToolStripMenuItem"
        Me.ParosToolStripMenuItem.Size = New System.Drawing.Size(126, 22)
        Me.ParosToolStripMenuItem.Text = "Paros"
        '
        'ProducciónToolStripMenuItem
        '
        Me.ProducciónToolStripMenuItem.Image = Global.Spic.My.Resources.Resources.martillo
        Me.ProducciónToolStripMenuItem.Name = "ProducciónToolStripMenuItem"
        Me.ProducciónToolStripMenuItem.Size = New System.Drawing.Size(126, 22)
        Me.ProducciónToolStripMenuItem.Text = "Producción"
        '
        'btn_excel
        '
        Me.btn_excel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_excel.Image = Global.Spic.My.Resources.Resources.excel10
        Me.btn_excel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_excel.Name = "btn_excel"
        Me.btn_excel.Size = New System.Drawing.Size(27, 30)
        Me.btn_excel.Text = "ToolStripButton4"
        Me.btn_excel.ToolTipText = "Enviar a excel"
        '
        'btn_pantallazo
        '
        Me.btn_pantallazo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_pantallazo.Image = Global.Spic.My.Resources.Resources.cam
        Me.btn_pantallazo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_pantallazo.Name = "btn_pantallazo"
        Me.btn_pantallazo.Size = New System.Drawing.Size(27, 30)
        Me.btn_pantallazo.Text = "Capturar pantalla"
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
        Legend1.Name = "Legend1"
        Me.Chart1.Legends.Add(Legend1)
        Me.Chart1.Location = New System.Drawing.Point(4, 103)
        Me.Chart1.Name = "Chart1"
        Series1.ChartArea = "ChartArea1"
        Series1.Legend = "Legend1"
        Series1.Name = "Series1"
        Me.Chart1.Series.Add(Series1)
        Me.Chart1.Size = New System.Drawing.Size(733, 366)
        Me.Chart1.TabIndex = 1038
        Me.Chart1.Text = "Chart1"
        Me.Chart1.Visible = False
        '
        'btn_cerrar_graf
        '
        Me.btn_cerrar_graf.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_cerrar_graf.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_cerrar_graf.ForeColor = System.Drawing.Color.Red
        Me.btn_cerrar_graf.Location = New System.Drawing.Point(717, 78)
        Me.btn_cerrar_graf.Name = "btn_cerrar_graf"
        Me.btn_cerrar_graf.Size = New System.Drawing.Size(20, 23)
        Me.btn_cerrar_graf.TabIndex = 1039
        Me.btn_cerrar_graf.Text = "X"
        Me.btn_cerrar_graf.UseVisualStyleBackColor = True
        Me.btn_cerrar_graf.Visible = False
        '
        'chk_prod
        '
        Me.chk_prod.AutoSize = True
        Me.chk_prod.Checked = True
        Me.chk_prod.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk_prod.Location = New System.Drawing.Point(10, 39)
        Me.chk_prod.Name = "chk_prod"
        Me.chk_prod.Size = New System.Drawing.Size(80, 17)
        Me.chk_prod.TabIndex = 1044
        Me.chk_prod.Text = "Producción"
        Me.chk_prod.UseVisualStyleBackColor = True
        '
        'chk_paro
        '
        Me.chk_paro.AutoSize = True
        Me.chk_paro.Location = New System.Drawing.Point(10, 19)
        Me.chk_paro.Name = "chk_paro"
        Me.chk_paro.Size = New System.Drawing.Size(53, 17)
        Me.chk_paro.TabIndex = 1045
        Me.chk_paro.Text = "Paros"
        Me.chk_paro.UseVisualStyleBackColor = True
        '
        'G_grafico
        '
        Me.G_grafico.Controls.Add(Me.chk_paro)
        Me.G_grafico.Controls.Add(Me.chk_prod)
        Me.G_grafico.Location = New System.Drawing.Point(479, 31)
        Me.G_grafico.Name = "G_grafico"
        Me.G_grafico.Size = New System.Drawing.Size(93, 65)
        Me.G_grafico.TabIndex = 1046
        Me.G_grafico.TabStop = False
        Me.G_grafico.Text = "Graficos"
        Me.G_grafico.Visible = False
        '
        'SaveFileDialog1
        '
        Me.SaveFileDialog1.Filter = """JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif"""
        Me.SaveFileDialog1.Title = "Guardar imagen como"
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.GreenYellow
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox1.Location = New System.Drawing.Point(582, 42)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(18, 13)
        Me.TextBox1.TabIndex = 1048
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(606, 42)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(125, 13)
        Me.Label5.TabIndex = 1047
        Me.Label5.Text = "Campos modificables"
        '
        'imgProcesar
        '
        Me.imgProcesar.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.imgProcesar.Image = Global.Spic.My.Resources.Resources.procesando
        Me.imgProcesar.Location = New System.Drawing.Point(80, 109)
        Me.imgProcesar.Name = "imgProcesar"
        Me.imgProcesar.Size = New System.Drawing.Size(585, 355)
        Me.imgProcesar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgProcesar.TabIndex = 140
        Me.imgProcesar.TabStop = False
        Me.imgProcesar.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(2, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 13)
        Me.Label1.TabIndex = 1048
        Me.Label1.Text = "Fec ini:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(2, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 1050
        Me.Label2.Text = "Fec_fin:"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cbo_fecha_fin)
        Me.GroupBox3.Controls.Add(Me.cbo_fecha_ini)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Location = New System.Drawing.Point(316, 31)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(148, 65)
        Me.GroupBox3.TabIndex = 1044
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Rango de fecha"
        '
        'cbo_fecha_fin
        '
        Me.cbo_fecha_fin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.cbo_fecha_fin.Location = New System.Drawing.Point(58, 40)
        Me.cbo_fecha_fin.Name = "cbo_fecha_fin"
        Me.cbo_fecha_fin.Size = New System.Drawing.Size(86, 20)
        Me.cbo_fecha_fin.TabIndex = 1070
        '
        'cbo_fecha_ini
        '
        Me.cbo_fecha_ini.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.cbo_fecha_ini.Location = New System.Drawing.Point(58, 16)
        Me.cbo_fecha_ini.Name = "cbo_fecha_ini"
        Me.cbo_fecha_ini.Size = New System.Drawing.Size(86, 20)
        Me.cbo_fecha_ini.TabIndex = 1069
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(1, 15)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(59, 13)
        Me.Label8.TabIndex = 1037
        Me.Label8.Text = "Operario:"
        '
        'cbo_maquina
        '
        Me.cbo_maquina.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbo_maquina.FormattingEnabled = True
        Me.cbo_maquina.Location = New System.Drawing.Point(64, 38)
        Me.cbo_maquina.Name = "cbo_maquina"
        Me.cbo_maquina.Size = New System.Drawing.Size(113, 21)
        Me.cbo_maquina.TabIndex = 1043
        Me.cbo_maquina.Text = "Seleccione"
        '
        'cbo_operario
        '
        Me.cbo_operario.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbo_operario.FormattingEnabled = True
        Me.cbo_operario.Location = New System.Drawing.Point(64, 12)
        Me.cbo_operario.Name = "cbo_operario"
        Me.cbo_operario.Size = New System.Drawing.Size(231, 21)
        Me.cbo_operario.TabIndex = 1036
        Me.cbo_operario.Text = "Seleccione"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(3, 42)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 13)
        Me.Label3.TabIndex = 1044
        Me.Label3.Text = "Maquina:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(26, 29)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(14, 13)
        Me.Label4.TabIndex = 1043
        Me.Label4.Text = "ó"
        '
        'chk_consol_op
        '
        Me.chk_consol_op.AutoSize = True
        Me.chk_consol_op.Location = New System.Drawing.Point(183, 40)
        Me.chk_consol_op.Name = "chk_consol_op"
        Me.chk_consol_op.Size = New System.Drawing.Size(116, 17)
        Me.chk_consol_op.TabIndex = 1047
        Me.chk_consol_op.Text = "Consolidar operario"
        Me.chk_consol_op.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chk_consol_op)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.cbo_operario)
        Me.GroupBox1.Controls.Add(Me.cbo_maquina)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Location = New System.Drawing.Point(4, 33)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(301, 64)
        Me.GroupBox1.TabIndex = 1042
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Criterio"
        '
        'Frm_consultar_tref
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(741, 481)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.G_grafico)
        Me.Controls.Add(Me.btn_cerrar_graf)
        Me.Controls.Add(Me.Toolbar1)
        Me.Controls.Add(Me.Chart1)
        Me.Controls.Add(Me.imgProcesar)
        Me.Controls.Add(Me.dtg_consulta)
        Me.Name = "Frm_consultar_tref"
        Me.Text = "Consultas y graficos"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dtg_consulta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.menStripDtg.ResumeLayout(False)
        Me.Toolbar1.ResumeLayout(False)
        Me.Toolbar1.PerformLayout()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.G_grafico.ResumeLayout(False)
        Me.G_grafico.PerformLayout()
        CType(Me.imgProcesar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents imgProcesar As System.Windows.Forms.PictureBox
    Friend WithEvents dtg_consulta As System.Windows.Forms.DataGridView
    Friend WithEvents Toolbar1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btn_excel As System.Windows.Forms.ToolStripButton
    Friend WithEvents Chart1 As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents ToolStripSplitButton1 As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents ParosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ProducciónToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btn_cerrar_graf As System.Windows.Forms.Button
    Friend WithEvents menStripDtg As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents EliminarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents chk_prod As System.Windows.Forms.CheckBox
    Friend WithEvents chk_paro As System.Windows.Forms.CheckBox
    Friend WithEvents G_grafico As System.Windows.Forms.GroupBox
    Friend WithEvents btn_pantallazo As System.Windows.Forms.ToolStripButton
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents ModificarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cbo_maquina As System.Windows.Forms.ComboBox
    Friend WithEvents cbo_operario As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents chk_consol_op As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cbo_fecha_fin As System.Windows.Forms.DateTimePicker
    Friend WithEvents cbo_fecha_ini As System.Windows.Forms.DateTimePicker
End Class
