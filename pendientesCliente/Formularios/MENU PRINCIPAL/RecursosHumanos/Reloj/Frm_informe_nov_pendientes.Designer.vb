<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_informe_nov_pendientes
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
        Me.Toolbar1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btn_salir = New System.Windows.Forms.ToolStripButton()
        Me.btn_ppal = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnConsultar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSplitButton1 = New System.Windows.Forms.ToolStripButton()
        Me.groupbox = New System.Windows.Forms.GroupBox()
        Me.cbo_periodo = New System.Windows.Forms.ComboBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cbo_operario = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cbo_centro = New System.Windows.Forms.ComboBox()
        Me.chk_pendientes = New System.Windows.Forms.CheckBox()
        Me.dtgMaestro = New System.Windows.Forms.DataGridView()
        Me.chk_autorizadas = New System.Windows.Forms.CheckBox()
        Me.chk_rechazadas = New System.Windows.Forms.CheckBox()
        Me.Toolbar1.SuspendLayout()
        Me.groupbox.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dtgMaestro, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Toolbar1
        '
        Me.Toolbar1.AutoSize = False
        Me.Toolbar1.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.Toolbar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Toolbar1.ImageScalingSize = New System.Drawing.Size(23, 23)
        Me.Toolbar1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator2, Me.btn_salir, Me.btn_ppal, Me.ToolStripSeparator3, Me.btnConsultar, Me.ToolStripSplitButton1})
        Me.Toolbar1.Location = New System.Drawing.Point(0, 0)
        Me.Toolbar1.Name = "Toolbar1"
        Me.Toolbar1.Size = New System.Drawing.Size(706, 31)
        Me.Toolbar1.TabIndex = 1120
        Me.Toolbar1.Text = "ToolStrip1"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 31)
        '
        'btn_salir
        '
        Me.btn_salir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_salir.Image = Global.Spic.My.Resources.Resources._1349388328_door_in
        Me.btn_salir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_salir.Name = "btn_salir"
        Me.btn_salir.Size = New System.Drawing.Size(27, 28)
        Me.btn_salir.Text = "ToolStripButton1"
        Me.btn_salir.ToolTipText = "Salir"
        '
        'btn_ppal
        '
        Me.btn_ppal.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_ppal.Image = Global.Spic.My.Resources.Resources.ppal3
        Me.btn_ppal.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_ppal.Name = "btn_ppal"
        Me.btn_ppal.Size = New System.Drawing.Size(27, 28)
        Me.btn_ppal.Text = "ToolStripButton2"
        Me.btn_ppal.ToolTipText = "Menú principal"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 31)
        '
        'btnConsultar
        '
        Me.btnConsultar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnConsultar.Image = Global.Spic.My.Resources.Resources.update
        Me.btnConsultar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(27, 28)
        Me.btnConsultar.Text = "Consultar"
        '
        'ToolStripSplitButton1
        '
        Me.ToolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripSplitButton1.Image = Global.Spic.My.Resources.Resources.excel
        Me.ToolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripSplitButton1.Name = "ToolStripSplitButton1"
        Me.ToolStripSplitButton1.Size = New System.Drawing.Size(27, 28)
        Me.ToolStripSplitButton1.Text = "Exportar a excel"
        '
        'groupbox
        '
        Me.groupbox.Controls.Add(Me.cbo_periodo)
        Me.groupbox.Location = New System.Drawing.Point(0, 37)
        Me.groupbox.Name = "groupbox"
        Me.groupbox.Size = New System.Drawing.Size(180, 40)
        Me.groupbox.TabIndex = 1123
        Me.groupbox.TabStop = False
        Me.groupbox.Text = "Periodo"
        '
        'cbo_periodo
        '
        Me.cbo_periodo.FormattingEnabled = True
        Me.cbo_periodo.Location = New System.Drawing.Point(6, 13)
        Me.cbo_periodo.Name = "cbo_periodo"
        Me.cbo_periodo.Size = New System.Drawing.Size(168, 21)
        Me.cbo_periodo.TabIndex = 1116
        Me.cbo_periodo.Text = "Seleccione"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cbo_operario)
        Me.GroupBox2.Location = New System.Drawing.Point(355, 37)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(242, 40)
        Me.GroupBox2.TabIndex = 1122
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Operario"
        '
        'cbo_operario
        '
        Me.cbo_operario.FormattingEnabled = True
        Me.cbo_operario.Location = New System.Drawing.Point(6, 13)
        Me.cbo_operario.Name = "cbo_operario"
        Me.cbo_operario.Size = New System.Drawing.Size(233, 21)
        Me.cbo_operario.TabIndex = 1116
        Me.cbo_operario.Text = "Seleccione"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cbo_centro)
        Me.GroupBox1.Location = New System.Drawing.Point(183, 37)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(168, 40)
        Me.GroupBox1.TabIndex = 1121
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Centro de costos"
        '
        'cbo_centro
        '
        Me.cbo_centro.FormattingEnabled = True
        Me.cbo_centro.Location = New System.Drawing.Point(6, 13)
        Me.cbo_centro.Name = "cbo_centro"
        Me.cbo_centro.Size = New System.Drawing.Size(156, 21)
        Me.cbo_centro.TabIndex = 1081
        Me.cbo_centro.Text = "Seleccione"
        '
        'chk_pendientes
        '
        Me.chk_pendientes.AutoSize = True
        Me.chk_pendientes.BackColor = System.Drawing.Color.Red
        Me.chk_pendientes.Checked = True
        Me.chk_pendientes.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk_pendientes.Location = New System.Drawing.Point(600, 34)
        Me.chk_pendientes.Name = "chk_pendientes"
        Me.chk_pendientes.Size = New System.Drawing.Size(79, 17)
        Me.chk_pendientes.TabIndex = 1124
        Me.chk_pendientes.Text = "Pendientes"
        Me.chk_pendientes.UseVisualStyleBackColor = False
        '
        'dtgMaestro
        '
        Me.dtgMaestro.AllowUserToAddRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dtgMaestro.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dtgMaestro.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtgMaestro.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dtgMaestro.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dtgMaestro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.Format = "N0"
        DataGridViewCellStyle2.NullValue = Nothing
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtgMaestro.DefaultCellStyle = DataGridViewCellStyle2
        Me.dtgMaestro.Location = New System.Drawing.Point(0, 83)
        Me.dtgMaestro.Name = "dtgMaestro"
        Me.dtgMaestro.ReadOnly = True
        Me.dtgMaestro.RowHeadersVisible = False
        Me.dtgMaestro.Size = New System.Drawing.Size(706, 362)
        Me.dtgMaestro.TabIndex = 1125
        '
        'chk_autorizadas
        '
        Me.chk_autorizadas.AutoSize = True
        Me.chk_autorizadas.BackColor = System.Drawing.Color.Lime
        Me.chk_autorizadas.Checked = True
        Me.chk_autorizadas.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk_autorizadas.Location = New System.Drawing.Point(600, 49)
        Me.chk_autorizadas.Name = "chk_autorizadas"
        Me.chk_autorizadas.Size = New System.Drawing.Size(81, 17)
        Me.chk_autorizadas.TabIndex = 1126
        Me.chk_autorizadas.Text = "Autorizadas"
        Me.chk_autorizadas.UseVisualStyleBackColor = False
        '
        'chk_rechazadas
        '
        Me.chk_rechazadas.AutoSize = True
        Me.chk_rechazadas.BackColor = System.Drawing.Color.Silver
        Me.chk_rechazadas.Checked = True
        Me.chk_rechazadas.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk_rechazadas.Location = New System.Drawing.Point(600, 64)
        Me.chk_rechazadas.Name = "chk_rechazadas"
        Me.chk_rechazadas.Size = New System.Drawing.Size(86, 17)
        Me.chk_rechazadas.TabIndex = 1127
        Me.chk_rechazadas.Text = "Rechazadas"
        Me.chk_rechazadas.UseVisualStyleBackColor = False
        '
        'Frm_informe_nov_pendientes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(706, 446)
        Me.Controls.Add(Me.chk_rechazadas)
        Me.Controls.Add(Me.chk_autorizadas)
        Me.Controls.Add(Me.dtgMaestro)
        Me.Controls.Add(Me.chk_pendientes)
        Me.Controls.Add(Me.groupbox)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Toolbar1)
        Me.Name = "Frm_informe_nov_pendientes"
        Me.Text = "Informe de novedades pendientes"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Toolbar1.ResumeLayout(False)
        Me.Toolbar1.PerformLayout()
        Me.groupbox.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dtgMaestro, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Toolbar1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btn_salir As System.Windows.Forms.ToolStripButton
    Friend WithEvents btn_ppal As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnConsultar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSplitButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents groupbox As System.Windows.Forms.GroupBox
    Friend WithEvents cbo_periodo As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cbo_operario As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cbo_centro As System.Windows.Forms.ComboBox
    Friend WithEvents chk_pendientes As System.Windows.Forms.CheckBox
    Friend WithEvents dtgMaestro As System.Windows.Forms.DataGridView
    Friend WithEvents chk_autorizadas As System.Windows.Forms.CheckBox
    Friend WithEvents chk_rechazadas As System.Windows.Forms.CheckBox
End Class
