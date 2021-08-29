<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_ing_galv
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_ing_galv))
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.txt_h_trab = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbo_fecha = New System.Windows.Forms.DateTimePicker()
        Me.cbo_turno = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.dtg_planilla = New System.Windows.Forms.DataGridView()
        Me.Toolbar1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnBuscar = New System.Windows.Forms.ToolStripButton()
        Me.btnGuardar = New System.Windows.Forms.ToolStripButton()
        Me.btnContCambios = New System.Windows.Forms.ToolStripButton()
        Me.btn_borrar = New System.Windows.Forms.DataGridViewImageColumn()
        Me.colAdd = New System.Windows.Forms.DataGridViewImageColumn()
        Me.cbo_destino = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.cbo_tipo = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.cbo_calibre = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.txt_kilos = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txt_mm = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txt_p1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txt_p2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txt_p3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txt_p4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txt_p5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txt_p6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txt_p7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txt_p8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txt_p9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dtg_planilla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Toolbar1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.PictureBox1)
        Me.GroupBox1.Controls.Add(Me.txt_h_trab)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cbo_fecha)
        Me.GroupBox1.Controls.Add(Me.cbo_turno)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 38)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(689, 218)
        Me.GroupBox1.TabIndex = 1032
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Ingreso de datos"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = Global.Spic.My.Resources.Resources.cod_paros1
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.Image = Global.Spic.My.Resources.Resources.paros_galv
        Me.PictureBox1.Location = New System.Drawing.Point(268, 8)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(152, 203)
        Me.PictureBox1.TabIndex = 1060
        Me.PictureBox1.TabStop = False
        '
        'txt_h_trab
        '
        Me.txt_h_trab.Location = New System.Drawing.Point(95, 192)
        Me.txt_h_trab.Name = "txt_h_trab"
        Me.txt_h_trab.Size = New System.Drawing.Size(149, 20)
        Me.txt_h_trab.TabIndex = 1059
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(14, 195)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(83, 13)
        Me.Label3.TabIndex = 1058
        Me.Label3.Text = "H-trabajadas:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(10, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 57
        Me.Label1.Text = "Fecha:"
        '
        'cbo_fecha
        '
        Me.cbo_fecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.cbo_fecha.Location = New System.Drawing.Point(96, 21)
        Me.cbo_fecha.Name = "cbo_fecha"
        Me.cbo_fecha.Size = New System.Drawing.Size(149, 20)
        Me.cbo_fecha.TabIndex = 1
        '
        'cbo_turno
        '
        Me.cbo_turno.FormattingEnabled = True
        Me.cbo_turno.Location = New System.Drawing.Point(96, 111)
        Me.cbo_turno.Name = "cbo_turno"
        Me.cbo_turno.Size = New System.Drawing.Size(150, 21)
        Me.cbo_turno.TabIndex = 4
        Me.cbo_turno.Text = "Seleccione"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(14, 114)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(44, 13)
        Me.Label5.TabIndex = 120
        Me.Label5.Text = "Turno:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.dtg_planilla)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 263)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(689, 198)
        Me.GroupBox2.TabIndex = 1034
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Planilla"
        '
        'dtg_planilla
        '
        Me.dtg_planilla.AllowUserToAddRows = False
        Me.dtg_planilla.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro
        Me.dtg_planilla.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dtg_planilla.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtg_planilla.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dtg_planilla.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dtg_planilla.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dtg_planilla.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtg_planilla.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dtg_planilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtg_planilla.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.btn_borrar, Me.colAdd, Me.cbo_destino, Me.cbo_tipo, Me.cbo_calibre, Me.txt_kilos, Me.txt_mm, Me.txt_p1, Me.txt_p2, Me.txt_p3, Me.txt_p4, Me.txt_p5, Me.txt_p6, Me.txt_p7, Me.txt_p8, Me.txt_p9})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.Format = "N0"
        DataGridViewCellStyle4.NullValue = Nothing
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtg_planilla.DefaultCellStyle = DataGridViewCellStyle4
        Me.dtg_planilla.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dtg_planilla.Location = New System.Drawing.Point(6, 16)
        Me.dtg_planilla.Name = "dtg_planilla"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtg_planilla.RowHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dtg_planilla.RowHeadersVisible = False
        Me.dtg_planilla.Size = New System.Drawing.Size(677, 176)
        Me.dtg_planilla.TabIndex = 1024
        '
        'Toolbar1
        '
        Me.Toolbar1.AutoSize = False
        Me.Toolbar1.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.Toolbar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Toolbar1.ImageScalingSize = New System.Drawing.Size(23, 23)
        Me.Toolbar1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator2, Me.ToolStripButton1, Me.ToolStripButton2, Me.ToolStripSeparator3, Me.btnBuscar, Me.btnGuardar, Me.btnContCambios})
        Me.Toolbar1.Location = New System.Drawing.Point(0, 0)
        Me.Toolbar1.Name = "Toolbar1"
        Me.Toolbar1.Size = New System.Drawing.Size(720, 33)
        Me.Toolbar1.TabIndex = 1033
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
        'btnBuscar
        '
        Me.btnBuscar.AutoSize = False
        Me.btnBuscar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(35, 39)
        Me.btnBuscar.ToolTipText = "Consultar"
        '
        'btnGuardar
        '
        Me.btnGuardar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Padding = New System.Windows.Forms.Padding(0, 0, 8, 0)
        Me.btnGuardar.Size = New System.Drawing.Size(35, 30)
        Me.btnGuardar.Text = "Guardar"
        '
        'btnContCambios
        '
        Me.btnContCambios.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnContCambios.Image = Global.Spic.My.Resources.Resources.info1
        Me.btnContCambios.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnContCambios.Name = "btnContCambios"
        Me.btnContCambios.Size = New System.Drawing.Size(27, 30)
        Me.btnContCambios.Text = "Control de cambios"
        '
        'btn_borrar
        '
        Me.btn_borrar.HeaderText = ""
        Me.btn_borrar.Image = Global.Spic.My.Resources.Resources._1371750041_14125
        Me.btn_borrar.Name = "btn_borrar"
        Me.btn_borrar.Width = 5
        '
        'colAdd
        '
        Me.colAdd.HeaderText = ""
        Me.colAdd.Image = Global.Spic.My.Resources.Resources.nuevo
        Me.colAdd.Name = "colAdd"
        Me.colAdd.Width = 5
        '
        'cbo_destino
        '
        Me.cbo_destino.HeaderText = "Destino"
        Me.cbo_destino.Name = "cbo_destino"
        Me.cbo_destino.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.cbo_destino.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.cbo_destino.Width = 68
        '
        'cbo_tipo
        '
        Me.cbo_tipo.HeaderText = "Tipo producto"
        Me.cbo_tipo.Name = "cbo_tipo"
        Me.cbo_tipo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.cbo_tipo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.cbo_tipo.Width = 98
        '
        'cbo_calibre
        '
        Me.cbo_calibre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.cbo_calibre.HeaderText = "Bwg"
        Me.cbo_calibre.Name = "cbo_calibre"
        Me.cbo_calibre.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.cbo_calibre.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.cbo_calibre.Width = 53
        '
        'txt_kilos
        '
        Me.txt_kilos.HeaderText = "kilos"
        Me.txt_kilos.Name = "txt_kilos"
        Me.txt_kilos.Width = 53
        '
        'txt_mm
        '
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.Silver
        Me.txt_mm.DefaultCellStyle = DataGridViewCellStyle3
        Me.txt_mm.HeaderText = "mm"
        Me.txt_mm.Name = "txt_mm"
        Me.txt_mm.ReadOnly = True
        Me.txt_mm.Width = 48
        '
        'txt_p1
        '
        Me.txt_p1.HeaderText = "P1"
        Me.txt_p1.Name = "txt_p1"
        Me.txt_p1.Width = 45
        '
        'txt_p2
        '
        Me.txt_p2.HeaderText = "P2"
        Me.txt_p2.Name = "txt_p2"
        Me.txt_p2.Width = 45
        '
        'txt_p3
        '
        Me.txt_p3.HeaderText = "P3"
        Me.txt_p3.Name = "txt_p3"
        Me.txt_p3.Width = 45
        '
        'txt_p4
        '
        Me.txt_p4.HeaderText = "P4"
        Me.txt_p4.Name = "txt_p4"
        Me.txt_p4.Width = 45
        '
        'txt_p5
        '
        Me.txt_p5.HeaderText = "P5"
        Me.txt_p5.Name = "txt_p5"
        Me.txt_p5.Width = 45
        '
        'txt_p6
        '
        Me.txt_p6.HeaderText = "P6"
        Me.txt_p6.Name = "txt_p6"
        Me.txt_p6.Width = 45
        '
        'txt_p7
        '
        Me.txt_p7.HeaderText = "P7"
        Me.txt_p7.Name = "txt_p7"
        Me.txt_p7.Width = 45
        '
        'txt_p8
        '
        Me.txt_p8.HeaderText = "P8"
        Me.txt_p8.Name = "txt_p8"
        Me.txt_p8.Width = 45
        '
        'txt_p9
        '
        Me.txt_p9.HeaderText = "P9"
        Me.txt_p9.Name = "txt_p9"
        Me.txt_p9.Width = 45
        '
        'Frm_ing_galv
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(720, 462)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Toolbar1)
        Me.Name = "Frm_ing_galv"
        Me.Text = "Frm_ing_galv"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.dtg_planilla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Toolbar1.ResumeLayout(False)
        Me.Toolbar1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_h_trab As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbo_fecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents cbo_turno As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents dtg_planilla As System.Windows.Forms.DataGridView
    Friend WithEvents Toolbar1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnBuscar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents btnContCambios As System.Windows.Forms.ToolStripButton
    Friend WithEvents btn_borrar As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents colAdd As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents cbo_destino As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents cbo_tipo As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents cbo_calibre As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents txt_kilos As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txt_mm As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txt_p1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txt_p2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txt_p3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txt_p4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txt_p5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txt_p6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txt_p7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txt_p8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txt_p9 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
