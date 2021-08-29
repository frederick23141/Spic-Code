<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmInvMetrologia
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
        Me.dtgMaestro = New System.Windows.Forms.DataGridView()
        Me.btnSave = New System.Windows.Forms.DataGridViewImageColumn()
        Me.btnDelete = New System.Windows.Forms.DataGridViewImageColumn()
        Me.groupFecha = New System.Windows.Forms.GroupBox()
        Me.btn_cerrar = New System.Windows.Forms.Button()
        Me.cboCal = New System.Windows.Forms.MonthCalendar()
        Me.Toolbar1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btn_salir = New System.Windows.Forms.ToolStripButton()
        Me.btn_ppal = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.btn_actualizar = New System.Windows.Forms.ToolStripButton()
        Me.btn_excel = New System.Windows.Forms.ToolStripButton()
        Me.cbo_ano_consulta = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cbo_mes_consulta = New System.Windows.Forms.ComboBox()
        Me.group_periodos = New System.Windows.Forms.GroupBox()
        Me.cbo_mes_periodo = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cbo_ano_periodo = New System.Windows.Forms.ComboBox()
        Me.btn_cerrar_novedades = New System.Windows.Forms.Button()
        Me.dtg_periodos = New System.Windows.Forms.DataGridView()
        Me.col_ok_periodo = New System.Windows.Forms.DataGridViewImageColumn()
        CType(Me.dtgMaestro, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.groupFecha.SuspendLayout()
        Me.Toolbar1.SuspendLayout()
        Me.group_periodos.SuspendLayout()
        CType(Me.dtg_periodos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dtgMaestro
        '
        Me.dtgMaestro.AllowUserToAddRows = False
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dtgMaestro.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.dtgMaestro.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtgMaestro.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dtgMaestro.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dtgMaestro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgMaestro.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.btnSave, Me.btnDelete})
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.Format = "N0"
        DataGridViewCellStyle6.NullValue = Nothing
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtgMaestro.DefaultCellStyle = DataGridViewCellStyle6
        Me.dtgMaestro.Location = New System.Drawing.Point(12, 60)
        Me.dtgMaestro.Name = "dtgMaestro"
        Me.dtgMaestro.ReadOnly = True
        Me.dtgMaestro.RowHeadersVisible = False
        Me.dtgMaestro.Size = New System.Drawing.Size(705, 327)
        Me.dtgMaestro.TabIndex = 1031
        '
        'btnSave
        '
        Me.btnSave.Frozen = True
        Me.btnSave.HeaderText = ""
        Me.btnSave.Image = Global.Spic.My.Resources.Resources.save_16
        Me.btnSave.Name = "btnSave"
        Me.btnSave.ReadOnly = True
        Me.btnSave.Width = 5
        '
        'btnDelete
        '
        Me.btnDelete.Frozen = True
        Me.btnDelete.HeaderText = ""
        Me.btnDelete.Image = Global.Spic.My.Resources.Resources.x
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.ReadOnly = True
        Me.btnDelete.Width = 5
        '
        'groupFecha
        '
        Me.groupFecha.Controls.Add(Me.btn_cerrar)
        Me.groupFecha.Controls.Add(Me.cboCal)
        Me.groupFecha.Location = New System.Drawing.Point(390, 119)
        Me.groupFecha.Name = "groupFecha"
        Me.groupFecha.Size = New System.Drawing.Size(272, 202)
        Me.groupFecha.TabIndex = 1084
        Me.groupFecha.TabStop = False
        Me.groupFecha.Text = "Seleccione fecha"
        Me.groupFecha.Visible = False
        '
        'btn_cerrar
        '
        Me.btn_cerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_cerrar.ForeColor = System.Drawing.Color.Red
        Me.btn_cerrar.Location = New System.Drawing.Point(235, 0)
        Me.btn_cerrar.Name = "btn_cerrar"
        Me.btn_cerrar.Size = New System.Drawing.Size(37, 23)
        Me.btn_cerrar.TabIndex = 1064
        Me.btn_cerrar.Text = "X"
        Me.btn_cerrar.UseVisualStyleBackColor = True
        '
        'cboCal
        '
        Me.cboCal.Location = New System.Drawing.Point(12, 28)
        Me.cboCal.MaxDate = New Date(2100, 8, 1, 0, 0, 0, 0)
        Me.cboCal.Name = "cboCal"
        Me.cboCal.TabIndex = 1057
        '
        'Toolbar1
        '
        Me.Toolbar1.AutoSize = False
        Me.Toolbar1.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.Toolbar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Toolbar1.ImageScalingSize = New System.Drawing.Size(23, 23)
        Me.Toolbar1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator2, Me.btn_salir, Me.btn_ppal, Me.ToolStripSeparator3, Me.btn_actualizar, Me.btn_excel})
        Me.Toolbar1.Location = New System.Drawing.Point(0, 0)
        Me.Toolbar1.Name = "Toolbar1"
        Me.Toolbar1.Size = New System.Drawing.Size(729, 28)
        Me.Toolbar1.TabIndex = 1086
        Me.Toolbar1.Text = "ToolStrip1"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 28)
        '
        'btn_salir
        '
        Me.btn_salir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_salir.Image = Global.Spic.My.Resources.Resources._1349388328_door_in
        Me.btn_salir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_salir.Name = "btn_salir"
        Me.btn_salir.Size = New System.Drawing.Size(27, 25)
        Me.btn_salir.Text = "ToolStripButton1"
        Me.btn_salir.ToolTipText = "Salir"
        '
        'btn_ppal
        '
        Me.btn_ppal.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_ppal.Image = Global.Spic.My.Resources.Resources.ppal3
        Me.btn_ppal.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_ppal.Name = "btn_ppal"
        Me.btn_ppal.Size = New System.Drawing.Size(27, 25)
        Me.btn_ppal.Text = "ToolStripButton2"
        Me.btn_ppal.ToolTipText = "Menú principal"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 28)
        '
        'btn_actualizar
        '
        Me.btn_actualizar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_actualizar.Image = Global.Spic.My.Resources.Resources.actualizar
        Me.btn_actualizar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_actualizar.Name = "btn_actualizar"
        Me.btn_actualizar.Size = New System.Drawing.Size(27, 25)
        Me.btn_actualizar.Text = "Actualizar  datos"
        '
        'btn_excel
        '
        Me.btn_excel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_excel.Image = Global.Spic.My.Resources.Resources.icon_excel
        Me.btn_excel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_excel.Name = "btn_excel"
        Me.btn_excel.Size = New System.Drawing.Size(27, 25)
        Me.btn_excel.Text = "ToolStripButton4"
        Me.btn_excel.ToolTipText = "Enviar a excel"
        '
        'cbo_ano_consulta
        '
        Me.cbo_ano_consulta.FormattingEnabled = True
        Me.cbo_ano_consulta.Location = New System.Drawing.Point(41, 33)
        Me.cbo_ano_consulta.Name = "cbo_ano_consulta"
        Me.cbo_ano_consulta.Size = New System.Drawing.Size(86, 21)
        Me.cbo_ano_consulta.TabIndex = 1080
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 36)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(26, 13)
        Me.Label4.TabIndex = 1080
        Me.Label4.Text = "Año"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(135, 37)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(27, 13)
        Me.Label5.TabIndex = 1080
        Me.Label5.Text = "Mes"
        '
        'cbo_mes_consulta
        '
        Me.cbo_mes_consulta.FormattingEnabled = True
        Me.cbo_mes_consulta.Items.AddRange(New Object() {"Enero ", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"})
        Me.cbo_mes_consulta.Location = New System.Drawing.Point(168, 33)
        Me.cbo_mes_consulta.Name = "cbo_mes_consulta"
        Me.cbo_mes_consulta.Size = New System.Drawing.Size(135, 21)
        Me.cbo_mes_consulta.TabIndex = 1080
        '
        'group_periodos
        '
        Me.group_periodos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.group_periodos.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.group_periodos.Controls.Add(Me.cbo_mes_periodo)
        Me.group_periodos.Controls.Add(Me.Label6)
        Me.group_periodos.Controls.Add(Me.Label7)
        Me.group_periodos.Controls.Add(Me.cbo_ano_periodo)
        Me.group_periodos.Controls.Add(Me.btn_cerrar_novedades)
        Me.group_periodos.Controls.Add(Me.dtg_periodos)
        Me.group_periodos.Location = New System.Drawing.Point(78, 59)
        Me.group_periodos.Name = "group_periodos"
        Me.group_periodos.Size = New System.Drawing.Size(452, 293)
        Me.group_periodos.TabIndex = 1100
        Me.group_periodos.TabStop = False
        Me.group_periodos.Text = "Periodos de nómina"
        Me.group_periodos.Visible = False
        '
        'cbo_mes_periodo
        '
        Me.cbo_mes_periodo.FormattingEnabled = True
        Me.cbo_mes_periodo.Items.AddRange(New Object() {"Enero ", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"})
        Me.cbo_mes_periodo.Location = New System.Drawing.Point(171, 19)
        Me.cbo_mes_periodo.Name = "cbo_mes_periodo"
        Me.cbo_mes_periodo.Size = New System.Drawing.Size(135, 21)
        Me.cbo_mes_periodo.TabIndex = 1089
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(138, 23)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(27, 13)
        Me.Label6.TabIndex = 1090
        Me.Label6.Text = "Mes"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 22)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(26, 13)
        Me.Label7.TabIndex = 1091
        Me.Label7.Text = "Año"
        '
        'cbo_ano_periodo
        '
        Me.cbo_ano_periodo.FormattingEnabled = True
        Me.cbo_ano_periodo.Location = New System.Drawing.Point(44, 19)
        Me.cbo_ano_periodo.Name = "cbo_ano_periodo"
        Me.cbo_ano_periodo.Size = New System.Drawing.Size(86, 21)
        Me.cbo_ano_periodo.TabIndex = 1092
        '
        'btn_cerrar_novedades
        '
        Me.btn_cerrar_novedades.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_cerrar_novedades.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_cerrar_novedades.ForeColor = System.Drawing.Color.Red
        Me.btn_cerrar_novedades.Location = New System.Drawing.Point(428, 1)
        Me.btn_cerrar_novedades.Name = "btn_cerrar_novedades"
        Me.btn_cerrar_novedades.Size = New System.Drawing.Size(20, 23)
        Me.btn_cerrar_novedades.TabIndex = 1088
        Me.btn_cerrar_novedades.Text = "X"
        Me.btn_cerrar_novedades.UseVisualStyleBackColor = True
        '
        'dtg_periodos
        '
        Me.dtg_periodos.AllowUserToAddRows = False
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dtg_periodos.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle7
        Me.dtg_periodos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtg_periodos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dtg_periodos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dtg_periodos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtg_periodos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.col_ok_periodo})
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.Format = "N0"
        DataGridViewCellStyle8.NullValue = "0"
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtg_periodos.DefaultCellStyle = DataGridViewCellStyle8
        Me.dtg_periodos.Location = New System.Drawing.Point(6, 52)
        Me.dtg_periodos.Name = "dtg_periodos"
        Me.dtg_periodos.ReadOnly = True
        Me.dtg_periodos.RowHeadersVisible = False
        Me.dtg_periodos.Size = New System.Drawing.Size(440, 235)
        Me.dtg_periodos.TabIndex = 1087
        '
        'col_ok_periodo
        '
        Me.col_ok_periodo.HeaderText = ""
        Me.col_ok_periodo.Image = Global.Spic.My.Resources.Resources.ok3
        Me.col_ok_periodo.Name = "col_ok_periodo"
        Me.col_ok_periodo.ReadOnly = True
        Me.col_ok_periodo.Width = 5
        '
        'FrmMaePeriodos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(729, 399)
        Me.Controls.Add(Me.groupFecha)
        Me.Controls.Add(Me.group_periodos)
        Me.Controls.Add(Me.cbo_mes_consulta)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cbo_ano_consulta)
        Me.Controls.Add(Me.Toolbar1)
        Me.Controls.Add(Me.dtgMaestro)
        Me.Name = "FrmMaePeriodos"
        Me.Text = "Maestro periodo cortes de novedades"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dtgMaestro, System.ComponentModel.ISupportInitialize).EndInit()
        Me.groupFecha.ResumeLayout(False)
        Me.Toolbar1.ResumeLayout(False)
        Me.Toolbar1.PerformLayout()
        Me.group_periodos.ResumeLayout(False)
        Me.group_periodos.PerformLayout()
        CType(Me.dtg_periodos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtgMaestro As System.Windows.Forms.DataGridView
    Friend WithEvents groupFecha As System.Windows.Forms.GroupBox
    Friend WithEvents btn_cerrar As System.Windows.Forms.Button
    Friend WithEvents cboCal As System.Windows.Forms.MonthCalendar
    Friend WithEvents Toolbar1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btn_salir As System.Windows.Forms.ToolStripButton
    Friend WithEvents btn_ppal As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btn_actualizar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btn_excel As System.Windows.Forms.ToolStripButton
    Friend WithEvents cbo_ano_consulta As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cbo_mes_consulta As System.Windows.Forms.ComboBox
    Friend WithEvents btnSave As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents btnDelete As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents group_periodos As System.Windows.Forms.GroupBox
    Friend WithEvents cbo_mes_periodo As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cbo_ano_periodo As System.Windows.Forms.ComboBox
    Friend WithEvents btn_cerrar_novedades As System.Windows.Forms.Button
    Friend WithEvents dtg_periodos As System.Windows.Forms.DataGridView
    Friend WithEvents col_ok_periodo As System.Windows.Forms.DataGridViewImageColumn
End Class
