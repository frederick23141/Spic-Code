<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_control_inv_aud
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dtg_inv = New System.Windows.Forms.DataGridView()
        Me.col_ver = New System.Windows.Forms.DataGridViewImageColumn()
        Me.col_tras = New System.Windows.Forms.DataGridViewImageColumn()
        Me.dtg_fisico = New System.Windows.Forms.DataGridView()
        Me.dtg_sistema = New System.Windows.Forms.DataGridView()
        Me.dtg_consolidado = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Toolbar1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSplitButton1 = New System.Windows.Forms.ToolStripSplitButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.FisicoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SistemaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConsolidadoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.dtg_inv, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtg_fisico, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtg_sistema, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtg_consolidado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Toolbar1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dtg_inv
        '
        Me.dtg_inv.AllowUserToAddRows = False
        Me.dtg_inv.AllowUserToDeleteRows = False
        Me.dtg_inv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dtg_inv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dtg_inv.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dtg_inv.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dtg_inv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtg_inv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.col_ver, Me.col_tras})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtg_inv.DefaultCellStyle = DataGridViewCellStyle1
        Me.dtg_inv.Location = New System.Drawing.Point(12, 51)
        Me.dtg_inv.MultiSelect = False
        Me.dtg_inv.Name = "dtg_inv"
        Me.dtg_inv.ReadOnly = True
        Me.dtg_inv.RowHeadersVisible = False
        Me.dtg_inv.Size = New System.Drawing.Size(466, 286)
        Me.dtg_inv.TabIndex = 0
        '
        'col_ver
        '
        Me.col_ver.Frozen = True
        Me.col_ver.HeaderText = ""
        Me.col_ver.Image = Global.Spic.My.Resources.Resources._1385696481_kghostview
        Me.col_ver.Name = "col_ver"
        Me.col_ver.ReadOnly = True
        Me.col_ver.Width = 5
        '
        'col_tras
        '
        Me.col_tras.Frozen = True
        Me.col_tras.HeaderText = ""
        Me.col_tras.Image = Global.Spic.My.Resources.Resources._1448305162_Exchange_Swap_Change_Direction_Arrows
        Me.col_tras.Name = "col_tras"
        Me.col_tras.ReadOnly = True
        Me.col_tras.Width = 5
        '
        'dtg_fisico
        '
        Me.dtg_fisico.AllowUserToAddRows = False
        Me.dtg_fisico.AllowUserToDeleteRows = False
        Me.dtg_fisico.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dtg_fisico.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dtg_fisico.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dtg_fisico.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dtg_fisico.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dtg_fisico.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.dtg_fisico.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.LimeGreen
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtg_fisico.DefaultCellStyle = DataGridViewCellStyle2
        Me.dtg_fisico.Location = New System.Drawing.Point(484, 51)
        Me.dtg_fisico.MultiSelect = False
        Me.dtg_fisico.Name = "dtg_fisico"
        Me.dtg_fisico.ReadOnly = True
        Me.dtg_fisico.RowHeadersVisible = False
        Me.dtg_fisico.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtg_fisico.Size = New System.Drawing.Size(424, 421)
        Me.dtg_fisico.TabIndex = 1
        '
        'dtg_sistema
        '
        Me.dtg_sistema.AllowUserToAddRows = False
        Me.dtg_sistema.AllowUserToDeleteRows = False
        Me.dtg_sistema.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtg_sistema.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dtg_sistema.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dtg_sistema.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dtg_sistema.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dtg_sistema.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.dtg_sistema.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.OrangeRed
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtg_sistema.DefaultCellStyle = DataGridViewCellStyle3
        Me.dtg_sistema.Location = New System.Drawing.Point(603, 51)
        Me.dtg_sistema.MultiSelect = False
        Me.dtg_sistema.Name = "dtg_sistema"
        Me.dtg_sistema.ReadOnly = True
        Me.dtg_sistema.RowHeadersVisible = False
        Me.dtg_sistema.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtg_sistema.Size = New System.Drawing.Size(424, 421)
        Me.dtg_sistema.TabIndex = 2
        '
        'dtg_consolidado
        '
        Me.dtg_consolidado.AllowUserToAddRows = False
        Me.dtg_consolidado.AllowUserToDeleteRows = False
        Me.dtg_consolidado.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dtg_consolidado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dtg_consolidado.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dtg_consolidado.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dtg_consolidado.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dtg_consolidado.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.dtg_consolidado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.Violet
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtg_consolidado.DefaultCellStyle = DataGridViewCellStyle4
        Me.dtg_consolidado.Location = New System.Drawing.Point(12, 343)
        Me.dtg_consolidado.MultiSelect = False
        Me.dtg_consolidado.Name = "dtg_consolidado"
        Me.dtg_consolidado.ReadOnly = True
        Me.dtg_consolidado.RowHeadersVisible = False
        Me.dtg_consolidado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtg_consolidado.Size = New System.Drawing.Size(466, 129)
        Me.dtg_consolidado.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(481, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Fisico:"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(600, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Sistema"
        '
        'Toolbar1
        '
        Me.Toolbar1.AutoSize = False
        Me.Toolbar1.BackColor = System.Drawing.SystemColors.Control
        Me.Toolbar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Toolbar1.ImageScalingSize = New System.Drawing.Size(23, 23)
        Me.Toolbar1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSplitButton1})
        Me.Toolbar1.Location = New System.Drawing.Point(0, 0)
        Me.Toolbar1.Name = "Toolbar1"
        Me.Toolbar1.Size = New System.Drawing.Size(1028, 34)
        Me.Toolbar1.TabIndex = 1147
        Me.Toolbar1.Text = "ToolStrip1"
        '
        'ToolStripSplitButton1
        '
        Me.ToolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripSplitButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator1, Me.FisicoToolStripMenuItem, Me.SistemaToolStripMenuItem, Me.ConsolidadoToolStripMenuItem})
        Me.ToolStripSplitButton1.Image = Global.Spic.My.Resources.Resources.excel10
        Me.ToolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripSplitButton1.Name = "ToolStripSplitButton1"
        Me.ToolStripSplitButton1.Size = New System.Drawing.Size(39, 31)
        Me.ToolStripSplitButton1.Text = "ToolStripSplitButton1"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(138, 6)
        '
        'FisicoToolStripMenuItem
        '
        Me.FisicoToolStripMenuItem.Image = Global.Spic.My.Resources.Resources.excel10
        Me.FisicoToolStripMenuItem.Name = "FisicoToolStripMenuItem"
        Me.FisicoToolStripMenuItem.Size = New System.Drawing.Size(141, 22)
        Me.FisicoToolStripMenuItem.Text = "Fisico"
        '
        'SistemaToolStripMenuItem
        '
        Me.SistemaToolStripMenuItem.Image = Global.Spic.My.Resources.Resources.excel10
        Me.SistemaToolStripMenuItem.Name = "SistemaToolStripMenuItem"
        Me.SistemaToolStripMenuItem.Size = New System.Drawing.Size(141, 22)
        Me.SistemaToolStripMenuItem.Text = "Sistema"
        '
        'ConsolidadoToolStripMenuItem
        '
        Me.ConsolidadoToolStripMenuItem.Image = Global.Spic.My.Resources.Resources.excel10
        Me.ConsolidadoToolStripMenuItem.Name = "ConsolidadoToolStripMenuItem"
        Me.ConsolidadoToolStripMenuItem.Size = New System.Drawing.Size(141, 22)
        Me.ConsolidadoToolStripMenuItem.Text = "Consolidado"
        '
        'frm_control_inv_aud
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1028, 484)
        Me.Controls.Add(Me.Toolbar1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dtg_consolidado)
        Me.Controls.Add(Me.dtg_sistema)
        Me.Controls.Add(Me.dtg_fisico)
        Me.Controls.Add(Me.dtg_inv)
        Me.Name = "frm_control_inv_aud"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consulta de control de inventarios"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dtg_inv, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtg_fisico, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtg_sistema, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtg_consolidado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Toolbar1.ResumeLayout(False)
        Me.Toolbar1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtg_inv As System.Windows.Forms.DataGridView
    Friend WithEvents col_ver As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents col_tras As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents dtg_fisico As System.Windows.Forms.DataGridView
    Friend WithEvents dtg_sistema As System.Windows.Forms.DataGridView
    Friend WithEvents dtg_consolidado As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Toolbar1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSplitButton1 As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents FisicoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SistemaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConsolidadoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
