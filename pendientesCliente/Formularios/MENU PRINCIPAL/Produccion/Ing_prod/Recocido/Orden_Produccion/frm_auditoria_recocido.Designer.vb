<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_auditoria_recocido
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.dtg_consulta = New System.Windows.Forms.DataGridView()
        Me.Toolbar1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btn_salir = New System.Windows.Forms.ToolStripButton()
        Me.btn_ppal = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnConsultar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton()
        Me.rdb_sin_r = New System.Windows.Forms.RadioButton()
        Me.rdb_rec = New System.Windows.Forms.RadioButton()
        Me.rdb_term = New System.Windows.Forms.RadioButton()
        Me.chk_consolidar = New System.Windows.Forms.CheckBox()
        Me.lbl_codigo = New System.Windows.Forms.Label()
        Me.txt_codigo = New System.Windows.Forms.TextBox()
        Me.rdb_proc = New System.Windows.Forms.RadioButton()
        Me.cbo_fecha_in = New System.Windows.Forms.DateTimePicker()
        Me.cbo_fecha_fin = New System.Windows.Forms.DateTimePicker()
        Me.rdb_noconforme = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbo_horno = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        Me.rdb_reco = New System.Windows.Forms.RadioButton()
        Me.Panel1.SuspendLayout()
        CType(Me.dtg_consulta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Toolbar1.SuspendLayout()
        CType(Me.cbo_horno, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.dtg_consulta)
        Me.Panel1.Location = New System.Drawing.Point(12, 113)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(861, 277)
        Me.Panel1.TabIndex = 0
        '
        'dtg_consulta
        '
        Me.dtg_consulta.AllowUserToAddRows = False
        Me.dtg_consulta.AllowUserToDeleteRows = False
        Me.dtg_consulta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dtg_consulta.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dtg_consulta.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dtg_consulta.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.dtg_consulta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.Format = "N1"
        DataGridViewCellStyle1.NullValue = Nothing
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtg_consulta.DefaultCellStyle = DataGridViewCellStyle1
        Me.dtg_consulta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtg_consulta.Location = New System.Drawing.Point(0, 0)
        Me.dtg_consulta.MultiSelect = False
        Me.dtg_consulta.Name = "dtg_consulta"
        Me.dtg_consulta.ReadOnly = True
        Me.dtg_consulta.RowHeadersVisible = False
        Me.dtg_consulta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtg_consulta.Size = New System.Drawing.Size(861, 277)
        Me.dtg_consulta.TabIndex = 0
        '
        'Toolbar1
        '
        Me.Toolbar1.AutoSize = False
        Me.Toolbar1.BackColor = System.Drawing.SystemColors.Control
        Me.Toolbar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Toolbar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Toolbar1.ImageScalingSize = New System.Drawing.Size(23, 23)
        Me.Toolbar1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator2, Me.btn_salir, Me.btn_ppal, Me.ToolStripSeparator3, Me.btnConsultar, Me.ToolStripButton3})
        Me.Toolbar1.Location = New System.Drawing.Point(0, 0)
        Me.Toolbar1.Name = "Toolbar1"
        Me.Toolbar1.Size = New System.Drawing.Size(885, 34)
        Me.Toolbar1.TabIndex = 1146
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
        'rdb_sin_r
        '
        Me.rdb_sin_r.AutoSize = True
        Me.rdb_sin_r.BackColor = System.Drawing.Color.Orchid
        Me.rdb_sin_r.Checked = True
        Me.rdb_sin_r.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdb_sin_r.Location = New System.Drawing.Point(12, 37)
        Me.rdb_sin_r.Name = "rdb_sin_r"
        Me.rdb_sin_r.Size = New System.Drawing.Size(125, 24)
        Me.rdb_sin_r.TabIndex = 1147
        Me.rdb_sin_r.TabStop = True
        Me.rdb_sin_r.Text = "Sin Recocer"
        Me.rdb_sin_r.UseVisualStyleBackColor = False
        '
        'rdb_rec
        '
        Me.rdb_rec.AutoSize = True
        Me.rdb_rec.BackColor = System.Drawing.Color.Gold
        Me.rdb_rec.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdb_rec.Location = New System.Drawing.Point(271, 37)
        Me.rdb_rec.Name = "rdb_rec"
        Me.rdb_rec.Size = New System.Drawing.Size(95, 24)
        Me.rdb_rec.TabIndex = 1148
        Me.rdb_rec.Text = "Cargado"
        Me.rdb_rec.UseVisualStyleBackColor = False
        '
        'rdb_term
        '
        Me.rdb_term.AutoSize = True
        Me.rdb_term.BackColor = System.Drawing.Color.Green
        Me.rdb_term.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdb_term.Location = New System.Drawing.Point(472, 38)
        Me.rdb_term.Name = "rdb_term"
        Me.rdb_term.Size = New System.Drawing.Size(111, 24)
        Me.rdb_term.TabIndex = 1149
        Me.rdb_term.Text = "Terminado"
        Me.rdb_term.UseVisualStyleBackColor = False
        '
        'chk_consolidar
        '
        Me.chk_consolidar.AutoSize = True
        Me.chk_consolidar.BackColor = System.Drawing.Color.Transparent
        Me.chk_consolidar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_consolidar.Location = New System.Drawing.Point(167, 4)
        Me.chk_consolidar.Name = "chk_consolidar"
        Me.chk_consolidar.Size = New System.Drawing.Size(113, 24)
        Me.chk_consolidar.TabIndex = 1150
        Me.chk_consolidar.Text = "Consolidar"
        Me.chk_consolidar.UseVisualStyleBackColor = False
        '
        'lbl_codigo
        '
        Me.lbl_codigo.AutoSize = True
        Me.lbl_codigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_codigo.Location = New System.Drawing.Point(12, 81)
        Me.lbl_codigo.Name = "lbl_codigo"
        Me.lbl_codigo.Size = New System.Drawing.Size(70, 20)
        Me.lbl_codigo.TabIndex = 1151
        Me.lbl_codigo.Text = "Codigo:"
        '
        'txt_codigo
        '
        Me.txt_codigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_codigo.Location = New System.Drawing.Point(88, 75)
        Me.txt_codigo.Name = "txt_codigo"
        Me.txt_codigo.Size = New System.Drawing.Size(151, 26)
        Me.txt_codigo.TabIndex = 1152
        '
        'rdb_proc
        '
        Me.rdb_proc.AutoSize = True
        Me.rdb_proc.BackColor = System.Drawing.Color.Aqua
        Me.rdb_proc.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdb_proc.Location = New System.Drawing.Point(372, 38)
        Me.rdb_proc.Name = "rdb_proc"
        Me.rdb_proc.Size = New System.Drawing.Size(92, 24)
        Me.rdb_proc.TabIndex = 1153
        Me.rdb_proc.Text = "Proceso"
        Me.rdb_proc.UseVisualStyleBackColor = False
        '
        'cbo_fecha_in
        '
        Me.cbo_fecha_in.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.cbo_fecha_in.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.cbo_fecha_in.Location = New System.Drawing.Point(724, 37)
        Me.cbo_fecha_in.Name = "cbo_fecha_in"
        Me.cbo_fecha_in.Size = New System.Drawing.Size(130, 26)
        Me.cbo_fecha_in.TabIndex = 1154
        '
        'cbo_fecha_fin
        '
        Me.cbo_fecha_fin.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.cbo_fecha_fin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.cbo_fecha_fin.Location = New System.Drawing.Point(724, 73)
        Me.cbo_fecha_fin.Name = "cbo_fecha_fin"
        Me.cbo_fecha_fin.Size = New System.Drawing.Size(130, 26)
        Me.cbo_fecha_fin.TabIndex = 1155
        '
        'rdb_noconforme
        '
        Me.rdb_noconforme.AutoSize = True
        Me.rdb_noconforme.BackColor = System.Drawing.Color.Red
        Me.rdb_noconforme.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdb_noconforme.Location = New System.Drawing.Point(591, 38)
        Me.rdb_noconforme.Name = "rdb_noconforme"
        Me.rdb_noconforme.Size = New System.Drawing.Size(129, 24)
        Me.rdb_noconforme.TabIndex = 1156
        Me.rdb_noconforme.Text = "No conforme"
        Me.rdb_noconforme.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(268, 78)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 18)
        Me.Label1.TabIndex = 1157
        Me.Label1.Text = "Horno:"
        '
        'cbo_horno
        '
        Me.cbo_horno.DropDownWidth = 141
        Me.cbo_horno.Location = New System.Drawing.Point(328, 78)
        Me.cbo_horno.Name = "cbo_horno"
        Me.cbo_horno.Size = New System.Drawing.Size(141, 21)
        Me.cbo_horno.TabIndex = 1158
        '
        'rdb_reco
        '
        Me.rdb_reco.AutoSize = True
        Me.rdb_reco.BackColor = System.Drawing.Color.DarkOrange
        Me.rdb_reco.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdb_reco.Location = New System.Drawing.Point(143, 36)
        Me.rdb_reco.Name = "rdb_reco"
        Me.rdb_reco.Size = New System.Drawing.Size(122, 24)
        Me.rdb_reco.TabIndex = 1159
        Me.rdb_reco.Text = "Recociendo"
        Me.rdb_reco.UseVisualStyleBackColor = False
        '
        'frm_auditoria_recocido
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(885, 391)
        Me.Controls.Add(Me.rdb_reco)
        Me.Controls.Add(Me.cbo_horno)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.rdb_noconforme)
        Me.Controls.Add(Me.cbo_fecha_fin)
        Me.Controls.Add(Me.cbo_fecha_in)
        Me.Controls.Add(Me.rdb_proc)
        Me.Controls.Add(Me.txt_codigo)
        Me.Controls.Add(Me.lbl_codigo)
        Me.Controls.Add(Me.chk_consolidar)
        Me.Controls.Add(Me.rdb_term)
        Me.Controls.Add(Me.rdb_rec)
        Me.Controls.Add(Me.rdb_sin_r)
        Me.Controls.Add(Me.Toolbar1)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frm_auditoria_recocido"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Auditoria de recocido"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        CType(Me.dtg_consulta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Toolbar1.ResumeLayout(False)
        Me.Toolbar1.PerformLayout()
        CType(Me.cbo_horno, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents dtg_consulta As System.Windows.Forms.DataGridView
    Friend WithEvents Toolbar1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btn_salir As System.Windows.Forms.ToolStripButton
    Friend WithEvents btn_ppal As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnConsultar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents rdb_sin_r As System.Windows.Forms.RadioButton
    Friend WithEvents rdb_rec As System.Windows.Forms.RadioButton
    Friend WithEvents rdb_term As System.Windows.Forms.RadioButton
    Friend WithEvents chk_consolidar As System.Windows.Forms.CheckBox
    Friend WithEvents lbl_codigo As System.Windows.Forms.Label
    Friend WithEvents txt_codigo As System.Windows.Forms.TextBox
    Friend WithEvents rdb_proc As System.Windows.Forms.RadioButton
    Friend WithEvents cbo_fecha_in As System.Windows.Forms.DateTimePicker
    Friend WithEvents cbo_fecha_fin As System.Windows.Forms.DateTimePicker
    Friend WithEvents rdb_noconforme As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As Label
    Friend WithEvents cbo_horno As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents rdb_reco As RadioButton
End Class
