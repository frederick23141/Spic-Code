<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmConsTreForma3
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim ChartArea2 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend2 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series2 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.Toolbar1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSplitButton1 = New System.Windows.Forms.ToolStripSplitButton()
        Me.ParosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btn_excel = New System.Windows.Forms.ToolStripButton()
        Me.btn_actualizar = New System.Windows.Forms.ToolStripButton()
        Me.tsb_Exportar = New System.Windows.Forms.ToolStripButton()
        Me.dtg_consulta = New System.Windows.Forms.DataGridView()
        Me.btnElim = New System.Windows.Forms.DataGridViewImageColumn()
        Me.menStripDtg = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.itemMod = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.cbo_turno_fin = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cbo_fecha_fin = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbo_fecha_ini = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.G_consol = New System.Windows.Forms.GroupBox()
        Me.chkConsolOp = New System.Windows.Forms.CheckBox()
        Me.chkConsolMaq = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.chk_todos = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbo_operario = New System.Windows.Forms.ComboBox()
        Me.cbo_maquina = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btn_cerrar_graf = New System.Windows.Forms.Button()
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.menuCharlt = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.guardarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.imgProcesar = New System.Windows.Forms.PictureBox()
        Me.cbo_turno_ini = New System.Windows.Forms.ComboBox()
        Me.chk_porc_paros = New System.Windows.Forms.CheckBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.chk_fec_orden = New System.Windows.Forms.CheckBox()
        Me.chk_produccion = New System.Windows.Forms.CheckBox()
        Me.chk_transaccion = New System.Windows.Forms.CheckBox()
        Me.Toolbar1.SuspendLayout()
        CType(Me.dtg_consulta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.menStripDtg.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.G_consol.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.menuCharlt.SuspendLayout()
        CType(Me.imgProcesar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Toolbar1
        '
        Me.Toolbar1.AutoSize = False
        Me.Toolbar1.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.Toolbar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Toolbar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Toolbar1.ImageScalingSize = New System.Drawing.Size(23, 23)
        Me.Toolbar1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator2, Me.ToolStripButton1, Me.ToolStripButton2, Me.ToolStripSeparator3, Me.ToolStripSplitButton1, Me.btn_excel, Me.btn_actualizar, Me.tsb_Exportar})
        Me.Toolbar1.Location = New System.Drawing.Point(0, 0)
        Me.Toolbar1.Name = "Toolbar1"
        Me.Toolbar1.Size = New System.Drawing.Size(843, 33)
        Me.Toolbar1.TabIndex = 1026
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
        Me.ToolStripSplitButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ParosToolStripMenuItem})
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
        Me.ParosToolStripMenuItem.Size = New System.Drawing.Size(110, 30)
        Me.ParosToolStripMenuItem.Text = "Paros"
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
        'btn_actualizar
        '
        Me.btn_actualizar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_actualizar.Image = Global.Spic.My.Resources.Resources.actualizar
        Me.btn_actualizar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_actualizar.Name = "btn_actualizar"
        Me.btn_actualizar.Size = New System.Drawing.Size(27, 30)
        Me.btn_actualizar.Text = "Actualizar"
        '
        'tsb_Exportar
        '
        Me.tsb_Exportar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsb_Exportar.Image = Global.Spic.My.Resources.Resources.grafic
        Me.tsb_Exportar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsb_Exportar.Name = "tsb_Exportar"
        Me.tsb_Exportar.Size = New System.Drawing.Size(27, 30)
        Me.tsb_Exportar.Text = "ToolStripButton3"
        Me.tsb_Exportar.ToolTipText = "Exportar grafico"
        '
        'dtg_consulta
        '
        Me.dtg_consulta.AllowUserToAddRows = False
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.Gainsboro
        Me.dtg_consulta.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.dtg_consulta.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtg_consulta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dtg_consulta.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dtg_consulta.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtg_consulta.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dtg_consulta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtg_consulta.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.btnElim})
        Me.dtg_consulta.ContextMenuStrip = Me.menStripDtg
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtg_consulta.DefaultCellStyle = DataGridViewCellStyle7
        Me.dtg_consulta.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dtg_consulta.Location = New System.Drawing.Point(3, 111)
        Me.dtg_consulta.Name = "dtg_consulta"
        Me.dtg_consulta.ReadOnly = True
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtg_consulta.RowHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.dtg_consulta.RowHeadersVisible = False
        Me.dtg_consulta.Size = New System.Drawing.Size(838, 333)
        Me.dtg_consulta.TabIndex = 1027
        '
        'btnElim
        '
        Me.btnElim.Frozen = True
        Me.btnElim.HeaderText = ""
        Me.btnElim.Image = Global.Spic.My.Resources.Resources._1371750041_14125
        Me.btnElim.Name = "btnElim"
        Me.btnElim.ReadOnly = True
        Me.btnElim.ToolTipText = "Eliminar"
        Me.btnElim.Width = 5
        '
        'menStripDtg
        '
        Me.menStripDtg.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.menStripDtg.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.itemMod})
        Me.menStripDtg.Name = "ContextMenuStrip1"
        Me.menStripDtg.Size = New System.Drawing.Size(127, 26)
        '
        'itemMod
        '
        Me.itemMod.Image = Global.Spic.My.Resources.Resources.actualizar
        Me.itemMod.Name = "itemMod"
        Me.itemMod.Size = New System.Drawing.Size(126, 22)
        Me.itemMod.Text = "Modificar"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cbo_turno_fin)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.cbo_fecha_fin)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.cbo_fecha_ini)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Location = New System.Drawing.Point(99, 36)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(263, 65)
        Me.GroupBox3.TabIndex = 1046
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Rango de fecha"
        '
        'cbo_turno_fin
        '
        Me.cbo_turno_fin.FormattingEnabled = True
        Me.cbo_turno_fin.Items.AddRange(New Object() {"Seleccione", "1", "2", "3"})
        Me.cbo_turno_fin.Location = New System.Drawing.Point(183, 38)
        Me.cbo_turno_fin.Name = "cbo_turno_fin"
        Me.cbo_turno_fin.Size = New System.Drawing.Size(76, 21)
        Me.cbo_turno_fin.TabIndex = 1064
        Me.cbo_turno_fin.Text = "Seleccione"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(142, 41)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(40, 13)
        Me.Label5.TabIndex = 1051
        Me.Label5.Text = "Turno"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(142, 18)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 13)
        Me.Label4.TabIndex = 1047
        Me.Label4.Text = "Turno"
        '
        'cbo_fecha_fin
        '
        Me.cbo_fecha_fin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.cbo_fecha_fin.Location = New System.Drawing.Point(57, 39)
        Me.cbo_fecha_fin.Name = "cbo_fecha_fin"
        Me.cbo_fecha_fin.Size = New System.Drawing.Size(85, 20)
        Me.cbo_fecha_fin.TabIndex = 1049
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
        'cbo_fecha_ini
        '
        Me.cbo_fecha_ini.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.cbo_fecha_ini.Location = New System.Drawing.Point(57, 15)
        Me.cbo_fecha_ini.Name = "cbo_fecha_ini"
        Me.cbo_fecha_ini.Size = New System.Drawing.Size(85, 20)
        Me.cbo_fecha_ini.TabIndex = 1047
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
        'G_consol
        '
        Me.G_consol.Controls.Add(Me.chkConsolOp)
        Me.G_consol.Controls.Add(Me.chkConsolMaq)
        Me.G_consol.Location = New System.Drawing.Point(402, 0)
        Me.G_consol.Name = "G_consol"
        Me.G_consol.Size = New System.Drawing.Size(144, 32)
        Me.G_consol.TabIndex = 1059
        Me.G_consol.TabStop = False
        Me.G_consol.Text = "Consolidar"
        '
        'chkConsolOp
        '
        Me.chkConsolOp.AutoSize = True
        Me.chkConsolOp.Location = New System.Drawing.Point(6, 14)
        Me.chkConsolOp.Name = "chkConsolOp"
        Me.chkConsolOp.Size = New System.Drawing.Size(66, 17)
        Me.chkConsolOp.TabIndex = 1045
        Me.chkConsolOp.Text = "Operario"
        Me.chkConsolOp.UseVisualStyleBackColor = True
        '
        'chkConsolMaq
        '
        Me.chkConsolMaq.AutoSize = True
        Me.chkConsolMaq.Location = New System.Drawing.Point(74, 14)
        Me.chkConsolMaq.Name = "chkConsolMaq"
        Me.chkConsolMaq.Size = New System.Drawing.Size(67, 17)
        Me.chkConsolMaq.TabIndex = 1044
        Me.chkConsolMaq.Text = "Maquina"
        Me.chkConsolMaq.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label28)
        Me.GroupBox1.Controls.Add(Me.chk_todos)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.cbo_operario)
        Me.GroupBox1.Controls.Add(Me.cbo_maquina)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Location = New System.Drawing.Point(363, 35)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(329, 66)
        Me.GroupBox1.TabIndex = 1060
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Criterio"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(52, 0)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(37, 13)
        Me.Label28.TabIndex = 1046
        Me.Label28.Text = "Todos"
        '
        'chk_todos
        '
        Me.chk_todos.AutoSize = True
        Me.chk_todos.Location = New System.Drawing.Point(65, 15)
        Me.chk_todos.Name = "chk_todos"
        Me.chk_todos.Size = New System.Drawing.Size(15, 14)
        Me.chk_todos.TabIndex = 1045
        Me.chk_todos.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(6, 40)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 13)
        Me.Label3.TabIndex = 1044
        Me.Label3.Text = "Maquina:"
        '
        'cbo_operario
        '
        Me.cbo_operario.FormattingEnabled = True
        Me.cbo_operario.Location = New System.Drawing.Point(85, 12)
        Me.cbo_operario.Name = "cbo_operario"
        Me.cbo_operario.Size = New System.Drawing.Size(238, 21)
        Me.cbo_operario.TabIndex = 1036
        Me.cbo_operario.Text = "Seleccione"
        '
        'cbo_maquina
        '
        Me.cbo_maquina.FormattingEnabled = True
        Me.cbo_maquina.Location = New System.Drawing.Point(85, 37)
        Me.cbo_maquina.Name = "cbo_maquina"
        Me.cbo_maquina.Size = New System.Drawing.Size(238, 21)
        Me.cbo_maquina.TabIndex = 1043
        Me.cbo_maquina.Text = "Seleccione"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(5, 15)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(59, 13)
        Me.Label8.TabIndex = 1037
        Me.Label8.Text = "Operario:"
        '
        'btn_cerrar_graf
        '
        Me.btn_cerrar_graf.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_cerrar_graf.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_cerrar_graf.ForeColor = System.Drawing.Color.Red
        Me.btn_cerrar_graf.Location = New System.Drawing.Point(823, 108)
        Me.btn_cerrar_graf.Name = "btn_cerrar_graf"
        Me.btn_cerrar_graf.Size = New System.Drawing.Size(20, 23)
        Me.btn_cerrar_graf.TabIndex = 1062
        Me.btn_cerrar_graf.Text = "X"
        Me.btn_cerrar_graf.UseVisualStyleBackColor = True
        Me.btn_cerrar_graf.Visible = False
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
        Me.Chart1.ContextMenuStrip = Me.menuCharlt
        Legend2.Name = "Legend1"
        Me.Chart1.Legends.Add(Legend2)
        Me.Chart1.Location = New System.Drawing.Point(23, 126)
        Me.Chart1.Name = "Chart1"
        Series2.ChartArea = "ChartArea1"
        Series2.Legend = "Legend1"
        Series2.Name = "Series1"
        Me.Chart1.Series.Add(Series2)
        Me.Chart1.Size = New System.Drawing.Size(838, 324)
        Me.Chart1.TabIndex = 1061
        Me.Chart1.Text = "Fecha turno"
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
        'imgProcesar
        '
        Me.imgProcesar.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.imgProcesar.Image = Global.Spic.My.Resources.Resources.procesando
        Me.imgProcesar.Location = New System.Drawing.Point(35, 126)
        Me.imgProcesar.Name = "imgProcesar"
        Me.imgProcesar.Size = New System.Drawing.Size(768, 316)
        Me.imgProcesar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgProcesar.TabIndex = 1063
        Me.imgProcesar.TabStop = False
        Me.imgProcesar.Visible = False
        '
        'cbo_turno_ini
        '
        Me.cbo_turno_ini.FormattingEnabled = True
        Me.cbo_turno_ini.Items.AddRange(New Object() {"Seleccione", "1", "2", "3"})
        Me.cbo_turno_ini.Location = New System.Drawing.Point(284, 50)
        Me.cbo_turno_ini.Name = "cbo_turno_ini"
        Me.cbo_turno_ini.Size = New System.Drawing.Size(75, 21)
        Me.cbo_turno_ini.TabIndex = 1047
        Me.cbo_turno_ini.Text = "Seleccione"
        '
        'chk_porc_paros
        '
        Me.chk_porc_paros.AutoSize = True
        Me.chk_porc_paros.Location = New System.Drawing.Point(681, 12)
        Me.chk_porc_paros.Name = "chk_porc_paros"
        Me.chk_porc_paros.Size = New System.Drawing.Size(121, 17)
        Me.chk_porc_paros.TabIndex = 1046
        Me.chk_porc_paros.Text = "Porcentaje de paros"
        Me.chk_porc_paros.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(236, 9)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(150, 13)
        Me.Label6.TabIndex = 1065
        Me.Label6.Text = "Eficiencia con planilla anulada"
        '
        'TextBox3
        '
        Me.TextBox3.BackColor = System.Drawing.Color.Red
        Me.TextBox3.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox3.Location = New System.Drawing.Point(208, 9)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.ReadOnly = True
        Me.TextBox3.Size = New System.Drawing.Size(26, 13)
        Me.TextBox3.TabIndex = 1064
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.chk_fec_orden)
        Me.GroupBox4.Controls.Add(Me.chk_produccion)
        Me.GroupBox4.Controls.Add(Me.chk_transaccion)
        Me.GroupBox4.Location = New System.Drawing.Point(0, 36)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(93, 73)
        Me.GroupBox4.TabIndex = 1060
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Filtar tipo fecha"
        '
        'chk_fec_orden
        '
        Me.chk_fec_orden.AutoSize = True
        Me.chk_fec_orden.Location = New System.Drawing.Point(6, 50)
        Me.chk_fec_orden.Name = "chk_fec_orden"
        Me.chk_fec_orden.Size = New System.Drawing.Size(86, 17)
        Me.chk_fec_orden.TabIndex = 1044
        Me.chk_fec_orden.Text = "Fecha orden"
        Me.chk_fec_orden.UseVisualStyleBackColor = True
        '
        'chk_produccion
        '
        Me.chk_produccion.AutoSize = True
        Me.chk_produccion.Checked = True
        Me.chk_produccion.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk_produccion.Location = New System.Drawing.Point(6, 17)
        Me.chk_produccion.Name = "chk_produccion"
        Me.chk_produccion.Size = New System.Drawing.Size(80, 17)
        Me.chk_produccion.TabIndex = 1045
        Me.chk_produccion.Text = "Producción"
        Me.chk_produccion.UseVisualStyleBackColor = True
        '
        'chk_transaccion
        '
        Me.chk_transaccion.AutoSize = True
        Me.chk_transaccion.Location = New System.Drawing.Point(6, 34)
        Me.chk_transaccion.Name = "chk_transaccion"
        Me.chk_transaccion.Size = New System.Drawing.Size(85, 17)
        Me.chk_transaccion.TabIndex = 1044
        Me.chk_transaccion.Text = "Transacción"
        Me.chk_transaccion.UseVisualStyleBackColor = True
        '
        'FrmConsTreForma3
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(843, 445)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.btn_cerrar_graf)
        Me.Controls.Add(Me.G_consol)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.chk_porc_paros)
        Me.Controls.Add(Me.cbo_turno_ini)
        Me.Controls.Add(Me.imgProcesar)
        Me.Controls.Add(Me.Chart1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.Toolbar1)
        Me.Controls.Add(Me.dtg_consulta)
        Me.Name = "FrmConsTreForma3"
        Me.Text = "Consultar trefilación (Forma 3)"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Toolbar1.ResumeLayout(False)
        Me.Toolbar1.PerformLayout()
        CType(Me.dtg_consulta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.menStripDtg.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.G_consol.ResumeLayout(False)
        Me.G_consol.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.menuCharlt.ResumeLayout(False)
        CType(Me.imgProcesar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Toolbar1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSplitButton1 As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents ParosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btn_excel As System.Windows.Forms.ToolStripButton
    Friend WithEvents dtg_consulta As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cbo_fecha_fin As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbo_fecha_ini As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents G_consol As System.Windows.Forms.GroupBox
    Friend WithEvents chkConsolOp As System.Windows.Forms.CheckBox
    Friend WithEvents chkConsolMaq As System.Windows.Forms.CheckBox
    Friend WithEvents btnElim As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cbo_operario As System.Windows.Forms.ComboBox
    Friend WithEvents cbo_maquina As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btn_cerrar_graf As System.Windows.Forms.Button
    Friend WithEvents Chart1 As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents menuCharlt As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents guardarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents chk_todos As System.Windows.Forms.CheckBox
    Friend WithEvents menStripDtg As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents itemMod As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents imgProcesar As System.Windows.Forms.PictureBox
    Friend WithEvents cbo_turno_fin As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cbo_turno_ini As System.Windows.Forms.ComboBox
    Friend WithEvents btn_actualizar As System.Windows.Forms.ToolStripButton
    Friend WithEvents chk_porc_paros As System.Windows.Forms.CheckBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents chk_produccion As System.Windows.Forms.CheckBox
    Friend WithEvents chk_transaccion As System.Windows.Forms.CheckBox
    Friend WithEvents chk_fec_orden As CheckBox
    Friend WithEvents tsb_Exportar As ToolStripButton
End Class
