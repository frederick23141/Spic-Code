<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_consultar_encuesta_cli
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dtgConsulta = New System.Windows.Forms.DataGridView()
        Me.col_ver = New System.Windows.Forms.DataGridViewImageColumn()
        Me.colBorrar = New System.Windows.Forms.DataGridViewImageColumn()
        Me.txtNit = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtNombres = New System.Windows.Forms.TextBox()
        Me.Toolbar1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.btn_consultar = New System.Windows.Forms.ToolStripButton()
        Me.btnExcel = New System.Windows.Forms.ToolStripButton()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboFechaIni = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboFechaFin = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.chk_consol_ciudad = New System.Windows.Forms.CheckBox()
        Me.chk_consol_vend = New System.Windows.Forms.CheckBox()
        Me.chk_consol_pregunta = New System.Windows.Forms.CheckBox()
        Me.img_procesar = New System.Windows.Forms.PictureBox()
        CType(Me.dtgConsulta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Toolbar1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        CType(Me.img_procesar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dtgConsulta
        '
        Me.dtgConsulta.AllowUserToAddRows = False
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dtgConsulta.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.dtgConsulta.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtgConsulta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dtgConsulta.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgConsulta.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dtgConsulta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgConsulta.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.col_ver, Me.colBorrar})
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.Format = "N0"
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtgConsulta.DefaultCellStyle = DataGridViewCellStyle7
        Me.dtgConsulta.Location = New System.Drawing.Point(4, 91)
        Me.dtgConsulta.Name = "dtgConsulta"
        Me.dtgConsulta.ReadOnly = True
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgConsulta.RowHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.dtgConsulta.RowHeadersVisible = False
        Me.dtgConsulta.Size = New System.Drawing.Size(699, 320)
        Me.dtgConsulta.TabIndex = 0
        '
        'col_ver
        '
        Me.col_ver.Frozen = True
        Me.col_ver.HeaderText = ""
        Me.col_ver.Image = Global.Spic.My.Resources.Resources.buscar7
        Me.col_ver.Name = "col_ver"
        Me.col_ver.ReadOnly = True
        Me.col_ver.Width = 5
        '
        'colBorrar
        '
        Me.colBorrar.Frozen = True
        Me.colBorrar.HeaderText = ""
        Me.colBorrar.Image = Global.Spic.My.Resources.Resources.x
        Me.colBorrar.Name = "colBorrar"
        Me.colBorrar.ReadOnly = True
        Me.colBorrar.Width = 5
        '
        'txtNit
        '
        Me.txtNit.Location = New System.Drawing.Point(226, 37)
        Me.txtNit.Name = "txtNit"
        Me.txtNit.Size = New System.Drawing.Size(196, 20)
        Me.txtNit.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(190, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(27, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Nit:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(157, 66)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Nombres:"
        '
        'txtNombres
        '
        Me.txtNombres.Location = New System.Drawing.Point(226, 63)
        Me.txtNombres.Name = "txtNombres"
        Me.txtNombres.Size = New System.Drawing.Size(196, 20)
        Me.txtNombres.TabIndex = 3
        '
        'Toolbar1
        '
        Me.Toolbar1.AutoSize = False
        Me.Toolbar1.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.Toolbar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Toolbar1.ImageScalingSize = New System.Drawing.Size(23, 23)
        Me.Toolbar1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator2, Me.ToolStripButton1, Me.ToolStripButton2, Me.ToolStripSeparator3, Me.btn_consultar, Me.btnExcel})
        Me.Toolbar1.Location = New System.Drawing.Point(0, 0)
        Me.Toolbar1.Name = "Toolbar1"
        Me.Toolbar1.Size = New System.Drawing.Size(706, 28)
        Me.Toolbar1.TabIndex = 1027
        Me.Toolbar1.Text = "ToolStrip1"
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
        'btn_consultar
        '
        Me.btn_consultar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_consultar.Image = Global.Spic.My.Resources.Resources.actualizar
        Me.btn_consultar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_consultar.Name = "btn_consultar"
        Me.btn_consultar.Size = New System.Drawing.Size(27, 25)
        Me.btn_consultar.Text = "Consultar"
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
        'cboFechaIni
        '
        Me.cboFechaIni.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.cboFechaIni.Location = New System.Drawing.Point(53, 14)
        Me.cboFechaIni.MaxDate = New Date(2054, 5, 13, 0, 0, 0, 0)
        Me.cboFechaIni.Name = "cboFechaIni"
        Me.cboFechaIni.Size = New System.Drawing.Size(91, 20)
        Me.cboFechaIni.TabIndex = 1028
        Me.cboFechaIni.Value = New Date(2014, 5, 13, 0, 0, 0, 0)
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
        'cboFechaFin
        '
        Me.cboFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.cboFechaFin.Location = New System.Drawing.Point(53, 36)
        Me.cboFechaFin.MaxDate = New Date(2054, 5, 13, 0, 0, 0, 0)
        Me.cboFechaFin.Name = "cboFechaFin"
        Me.cboFechaFin.Size = New System.Drawing.Size(91, 20)
        Me.cboFechaFin.TabIndex = 1030
        Me.cboFechaFin.Value = New Date(2014, 5, 13, 0, 0, 0, 0)
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboFechaIni)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.cboFechaFin)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(4, 29)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(152, 60)
        Me.GroupBox1.TabIndex = 1035
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Rango de fecha"
        '
        'GroupBox7
        '
        Me.GroupBox7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox7.Controls.Add(Me.chk_consol_pregunta)
        Me.GroupBox7.Controls.Add(Me.chk_consol_ciudad)
        Me.GroupBox7.Controls.Add(Me.chk_consol_vend)
        Me.GroupBox7.Location = New System.Drawing.Point(435, 32)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(179, 50)
        Me.GroupBox7.TabIndex = 1084
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Consolidar"
        '
        'chk_consol_ciudad
        '
        Me.chk_consol_ciudad.AutoSize = True
        Me.chk_consol_ciudad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_consol_ciudad.Location = New System.Drawing.Point(5, 30)
        Me.chk_consol_ciudad.Name = "chk_consol_ciudad"
        Me.chk_consol_ciudad.Size = New System.Drawing.Size(65, 17)
        Me.chk_consol_ciudad.TabIndex = 1044
        Me.chk_consol_ciudad.Text = "Ciudad"
        Me.chk_consol_ciudad.UseVisualStyleBackColor = True
        '
        'chk_consol_vend
        '
        Me.chk_consol_vend.AutoSize = True
        Me.chk_consol_vend.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_consol_vend.Location = New System.Drawing.Point(5, 12)
        Me.chk_consol_vend.Name = "chk_consol_vend"
        Me.chk_consol_vend.Size = New System.Drawing.Size(80, 17)
        Me.chk_consol_vend.TabIndex = 1043
        Me.chk_consol_vend.Text = "Vendedor"
        Me.chk_consol_vend.UseVisualStyleBackColor = True
        '
        'chk_consol_pregunta
        '
        Me.chk_consol_pregunta.AutoSize = True
        Me.chk_consol_pregunta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_consol_pregunta.Location = New System.Drawing.Point(91, 20)
        Me.chk_consol_pregunta.Name = "chk_consol_pregunta"
        Me.chk_consol_pregunta.Size = New System.Drawing.Size(77, 17)
        Me.chk_consol_pregunta.TabIndex = 1045
        Me.chk_consol_pregunta.Text = "Pregunta"
        Me.chk_consol_pregunta.UseVisualStyleBackColor = True
        '
        'img_procesar
        '
        Me.img_procesar.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.img_procesar.Image = Global.Spic.My.Resources.Resources.procesando
        Me.img_procesar.Location = New System.Drawing.Point(4, 91)
        Me.img_procesar.Name = "img_procesar"
        Me.img_procesar.Size = New System.Drawing.Size(702, 320)
        Me.img_procesar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.img_procesar.TabIndex = 1085
        Me.img_procesar.TabStop = False
        Me.img_procesar.Visible = False
        '
        'Frm_consultar_encuesta_cli
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(706, 415)
        Me.Controls.Add(Me.img_procesar)
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Toolbar1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtNombres)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtNit)
        Me.Controls.Add(Me.dtgConsulta)
        Me.Name = "Frm_consultar_encuesta_cli"
        Me.Text = "Consultar evaluación"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dtgConsulta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Toolbar1.ResumeLayout(False)
        Me.Toolbar1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        CType(Me.img_procesar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtgConsulta As System.Windows.Forms.DataGridView
    Friend WithEvents txtNit As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtNombres As System.Windows.Forms.TextBox
    Friend WithEvents Toolbar1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboFechaIni As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboFechaFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents btn_consultar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnExcel As System.Windows.Forms.ToolStripButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents col_ver As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents colBorrar As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents chk_consol_ciudad As System.Windows.Forms.CheckBox
    Friend WithEvents chk_consol_vend As System.Windows.Forms.CheckBox
    Friend WithEvents chk_consol_pregunta As System.Windows.Forms.CheckBox
    Friend WithEvents img_procesar As System.Windows.Forms.PictureBox
End Class
