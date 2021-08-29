<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_inv_metrologia
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
        Me.dtgMaestro = New System.Windows.Forms.DataGridView()
        Me.btnSave = New System.Windows.Forms.DataGridViewImageColumn()
        Me.btnDelete = New System.Windows.Forms.DataGridViewImageColumn()
        Me.menStripMod = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.itemMod = New System.Windows.Forms.ToolStripMenuItem()
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
        Me.dtg_datos = New System.Windows.Forms.DataGridView()
        Me.col_ok_periodo = New System.Windows.Forms.DataGridViewImageColumn()
        Me.btn_cerrar_novedades = New System.Windows.Forms.Button()
        Me.group_datos = New System.Windows.Forms.GroupBox()
        CType(Me.dtgMaestro, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.menStripMod.SuspendLayout()
        Me.groupFecha.SuspendLayout()
        Me.Toolbar1.SuspendLayout()
        CType(Me.dtg_datos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.group_datos.SuspendLayout()
        Me.SuspendLayout()
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
        Me.dtgMaestro.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.btnSave, Me.btnDelete})
        Me.dtgMaestro.ContextMenuStrip = Me.menStripMod
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
        Me.dtgMaestro.Location = New System.Drawing.Point(12, 31)
        Me.dtgMaestro.Name = "dtgMaestro"
        Me.dtgMaestro.RowHeadersVisible = False
        Me.dtgMaestro.Size = New System.Drawing.Size(705, 356)
        Me.dtgMaestro.TabIndex = 1031
        '
        'btnSave
        '
        Me.btnSave.Frozen = True
        Me.btnSave.HeaderText = ""
        Me.btnSave.Image = Global.Spic.My.Resources.Resources.save_16
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Width = 5
        '
        'btnDelete
        '
        Me.btnDelete.Frozen = True
        Me.btnDelete.HeaderText = ""
        Me.btnDelete.Image = Global.Spic.My.Resources.Resources.x
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Width = 5
        '
        'menStripMod
        '
        Me.menStripMod.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.menStripMod.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.itemMod})
        Me.menStripMod.Name = "ContextMenuStrip1"
        Me.menStripMod.Size = New System.Drawing.Size(127, 26)
        '
        'itemMod
        '
        Me.itemMod.Image = Global.Spic.My.Resources.Resources.edit
        Me.itemMod.Name = "itemMod"
        Me.itemMod.Size = New System.Drawing.Size(126, 22)
        Me.itemMod.Text = "Modificar"
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
        'dtg_datos
        '
        Me.dtg_datos.AllowUserToAddRows = False
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dtg_datos.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
        Me.dtg_datos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtg_datos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dtg_datos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dtg_datos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtg_datos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.col_ok_periodo})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.Format = "N0"
        DataGridViewCellStyle4.NullValue = "0"
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtg_datos.DefaultCellStyle = DataGridViewCellStyle4
        Me.dtg_datos.Location = New System.Drawing.Point(6, 30)
        Me.dtg_datos.Name = "dtg_datos"
        Me.dtg_datos.ReadOnly = True
        Me.dtg_datos.RowHeadersVisible = False
        Me.dtg_datos.Size = New System.Drawing.Size(440, 257)
        Me.dtg_datos.TabIndex = 1087
        '
        'col_ok_periodo
        '
        Me.col_ok_periodo.HeaderText = ""
        Me.col_ok_periodo.Image = Global.Spic.My.Resources.Resources.ok3
        Me.col_ok_periodo.Name = "col_ok_periodo"
        Me.col_ok_periodo.ReadOnly = True
        Me.col_ok_periodo.Width = 5
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
        'group_datos
        '
        Me.group_datos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.group_datos.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.group_datos.Controls.Add(Me.btn_cerrar_novedades)
        Me.group_datos.Controls.Add(Me.dtg_datos)
        Me.group_datos.Location = New System.Drawing.Point(78, 59)
        Me.group_datos.Name = "group_datos"
        Me.group_datos.Size = New System.Drawing.Size(452, 293)
        Me.group_datos.TabIndex = 1100
        Me.group_datos.TabStop = False
        Me.group_datos.Text = "Seleccione"
        Me.group_datos.Visible = False
        '
        'Frm_inv_metrologia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(729, 399)
        Me.Controls.Add(Me.groupFecha)
        Me.Controls.Add(Me.group_datos)
        Me.Controls.Add(Me.Toolbar1)
        Me.Controls.Add(Me.dtgMaestro)
        Me.Name = "Frm_inv_metrologia"
        Me.Text = "Inventarios de metrologia"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dtgMaestro, System.ComponentModel.ISupportInitialize).EndInit()
        Me.menStripMod.ResumeLayout(False)
        Me.groupFecha.ResumeLayout(False)
        Me.Toolbar1.ResumeLayout(False)
        Me.Toolbar1.PerformLayout()
        CType(Me.dtg_datos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.group_datos.ResumeLayout(False)
        Me.ResumeLayout(False)

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
    Friend WithEvents dtg_datos As System.Windows.Forms.DataGridView
    Friend WithEvents col_ok_periodo As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents btn_cerrar_novedades As System.Windows.Forms.Button
    Friend WithEvents group_datos As System.Windows.Forms.GroupBox
    Friend WithEvents menStripMod As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents itemMod As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnSave As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents btnDelete As System.Windows.Forms.DataGridViewImageColumn
End Class
