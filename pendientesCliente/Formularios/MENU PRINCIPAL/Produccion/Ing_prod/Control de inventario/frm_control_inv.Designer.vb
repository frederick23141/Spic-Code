<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_control_inv
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
        Me.tbl_inventario = New System.Windows.Forms.TabControl()
        Me.pag_iniciar = New System.Windows.Forms.TabPage()
        Me.pan_iniciar = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btn_iniciar = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbo_bodega = New System.Windows.Forms.ComboBox()
        Me.pag_rollos = New System.Windows.Forms.TabPage()
        Me.pan_rollos = New System.Windows.Forms.Panel()
        Me.rdb_recocido = New System.Windows.Forms.RadioButton()
        Me.rdb_alambron = New System.Windows.Forms.RadioButton()
        Me.lbl_rollos = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtg_inv = New System.Windows.Forms.DataGridView()
        Me.btn_terminar = New System.Windows.Forms.Button()
        Me.rdb_galv = New System.Windows.Forms.RadioButton()
        Me.rdb_bri = New System.Windows.Forms.RadioButton()
        Me.txt_lector = New System.Windows.Forms.TextBox()
        Me.tbl_inventario.SuspendLayout()
        Me.pag_iniciar.SuspendLayout()
        Me.pan_iniciar.SuspendLayout()
        Me.pag_rollos.SuspendLayout()
        Me.pan_rollos.SuspendLayout()
        CType(Me.dtg_inv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tbl_inventario
        '
        Me.tbl_inventario.Controls.Add(Me.pag_iniciar)
        Me.tbl_inventario.Controls.Add(Me.pag_rollos)
        Me.tbl_inventario.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbl_inventario.Location = New System.Drawing.Point(1, 2)
        Me.tbl_inventario.Name = "tbl_inventario"
        Me.tbl_inventario.SelectedIndex = 0
        Me.tbl_inventario.Size = New System.Drawing.Size(319, 261)
        Me.tbl_inventario.TabIndex = 0
        '
        'pag_iniciar
        '
        Me.pag_iniciar.Controls.Add(Me.pan_iniciar)
        Me.pag_iniciar.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pag_iniciar.Location = New System.Drawing.Point(4, 24)
        Me.pag_iniciar.Name = "pag_iniciar"
        Me.pag_iniciar.Padding = New System.Windows.Forms.Padding(3)
        Me.pag_iniciar.Size = New System.Drawing.Size(311, 233)
        Me.pag_iniciar.TabIndex = 0
        Me.pag_iniciar.Text = "Iniciar"
        Me.pag_iniciar.UseVisualStyleBackColor = True
        '
        'pan_iniciar
        '
        Me.pan_iniciar.Controls.Add(Me.Label1)
        Me.pan_iniciar.Controls.Add(Me.btn_iniciar)
        Me.pan_iniciar.Controls.Add(Me.Label2)
        Me.pan_iniciar.Controls.Add(Me.cbo_bodega)
        Me.pan_iniciar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pan_iniciar.Location = New System.Drawing.Point(3, 3)
        Me.pan_iniciar.Name = "pan_iniciar"
        Me.pan_iniciar.Size = New System.Drawing.Size(305, 227)
        Me.pan_iniciar.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Comic Sans MS", 18.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(14, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(275, 35)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Inventario de Bodegas"
        '
        'btn_iniciar
        '
        Me.btn_iniciar.Enabled = False
        Me.btn_iniciar.Font = New System.Drawing.Font("Comic Sans MS", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_iniciar.Image = Global.Spic.My.Resources.Resources.comienza
        Me.btn_iniciar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_iniciar.Location = New System.Drawing.Point(33, 160)
        Me.btn_iniciar.Name = "btn_iniciar"
        Me.btn_iniciar.Size = New System.Drawing.Size(230, 59)
        Me.btn_iniciar.TabIndex = 3
        Me.btn_iniciar.Text = "Iniciar Inventario"
        Me.btn_iniciar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_iniciar.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Comic Sans MS", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(4, 75)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 21)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Bodega:"
        '
        'cbo_bodega
        '
        Me.cbo_bodega.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_bodega.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_bodega.FormattingEnabled = True
        Me.cbo_bodega.Location = New System.Drawing.Point(3, 99)
        Me.cbo_bodega.Name = "cbo_bodega"
        Me.cbo_bodega.Size = New System.Drawing.Size(299, 26)
        Me.cbo_bodega.TabIndex = 2
        '
        'pag_rollos
        '
        Me.pag_rollos.BackColor = System.Drawing.Color.White
        Me.pag_rollos.Controls.Add(Me.pan_rollos)
        Me.pag_rollos.Location = New System.Drawing.Point(4, 24)
        Me.pag_rollos.Name = "pag_rollos"
        Me.pag_rollos.Padding = New System.Windows.Forms.Padding(3)
        Me.pag_rollos.Size = New System.Drawing.Size(311, 233)
        Me.pag_rollos.TabIndex = 2
        Me.pag_rollos.Text = "Registro de Rollos"
        '
        'pan_rollos
        '
        Me.pan_rollos.Controls.Add(Me.rdb_recocido)
        Me.pan_rollos.Controls.Add(Me.rdb_alambron)
        Me.pan_rollos.Controls.Add(Me.lbl_rollos)
        Me.pan_rollos.Controls.Add(Me.Label3)
        Me.pan_rollos.Controls.Add(Me.dtg_inv)
        Me.pan_rollos.Controls.Add(Me.btn_terminar)
        Me.pan_rollos.Controls.Add(Me.rdb_galv)
        Me.pan_rollos.Controls.Add(Me.rdb_bri)
        Me.pan_rollos.Controls.Add(Me.txt_lector)
        Me.pan_rollos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pan_rollos.Enabled = False
        Me.pan_rollos.Location = New System.Drawing.Point(3, 3)
        Me.pan_rollos.Name = "pan_rollos"
        Me.pan_rollos.Size = New System.Drawing.Size(305, 227)
        Me.pan_rollos.TabIndex = 0
        '
        'rdb_recocido
        '
        Me.rdb_recocido.AutoSize = True
        Me.rdb_recocido.Location = New System.Drawing.Point(202, 3)
        Me.rdb_recocido.Name = "rdb_recocido"
        Me.rdb_recocido.Size = New System.Drawing.Size(50, 19)
        Me.rdb_recocido.TabIndex = 17
        Me.rdb_recocido.TabStop = True
        Me.rdb_recocido.Text = "Reco"
        Me.rdb_recocido.UseVisualStyleBackColor = True
        '
        'rdb_alambron
        '
        Me.rdb_alambron.AutoSize = True
        Me.rdb_alambron.Location = New System.Drawing.Point(146, 3)
        Me.rdb_alambron.Name = "rdb_alambron"
        Me.rdb_alambron.Size = New System.Drawing.Size(50, 19)
        Me.rdb_alambron.TabIndex = 16
        Me.rdb_alambron.TabStop = True
        Me.rdb_alambron.Text = "Alam"
        Me.rdb_alambron.UseVisualStyleBackColor = True
        '
        'lbl_rollos
        '
        Me.lbl_rollos.AutoSize = True
        Me.lbl_rollos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl_rollos.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_rollos.ForeColor = System.Drawing.Color.Red
        Me.lbl_rollos.Location = New System.Drawing.Point(50, 202)
        Me.lbl_rollos.Name = "lbl_rollos"
        Me.lbl_rollos.Size = New System.Drawing.Size(17, 18)
        Me.lbl_rollos.TabIndex = 15
        Me.lbl_rollos.Text = "0"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(4, 205)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 15)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Rollos:"
        '
        'dtg_inv
        '
        Me.dtg_inv.AllowUserToAddRows = False
        Me.dtg_inv.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Silver
        Me.dtg_inv.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dtg_inv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtg_inv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dtg_inv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dtg_inv.BackgroundColor = System.Drawing.Color.White
        Me.dtg_inv.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dtg_inv.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dtg_inv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dtg_inv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtg_inv.DefaultCellStyle = DataGridViewCellStyle2
        Me.dtg_inv.Location = New System.Drawing.Point(3, 57)
        Me.dtg_inv.Name = "dtg_inv"
        Me.dtg_inv.ReadOnly = True
        Me.dtg_inv.RowHeadersVisible = False
        Me.dtg_inv.Size = New System.Drawing.Size(299, 133)
        Me.dtg_inv.TabIndex = 13
        '
        'btn_terminar
        '
        Me.btn_terminar.Font = New System.Drawing.Font("Comic Sans MS", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_terminar.Location = New System.Drawing.Point(90, 196)
        Me.btn_terminar.Name = "btn_terminar"
        Me.btn_terminar.Size = New System.Drawing.Size(215, 30)
        Me.btn_terminar.TabIndex = 12
        Me.btn_terminar.Text = "Terminar"
        Me.btn_terminar.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_terminar.UseVisualStyleBackColor = True
        '
        'rdb_galv
        '
        Me.rdb_galv.AutoSize = True
        Me.rdb_galv.Location = New System.Drawing.Point(86, 3)
        Me.rdb_galv.Name = "rdb_galv"
        Me.rdb_galv.Size = New System.Drawing.Size(54, 19)
        Me.rdb_galv.TabIndex = 11
        Me.rdb_galv.Text = "Galva"
        Me.rdb_galv.UseVisualStyleBackColor = True
        '
        'rdb_bri
        '
        Me.rdb_bri.AutoSize = True
        Me.rdb_bri.Checked = True
        Me.rdb_bri.Location = New System.Drawing.Point(3, 3)
        Me.rdb_bri.Name = "rdb_bri"
        Me.rdb_bri.Size = New System.Drawing.Size(77, 19)
        Me.rdb_bri.TabIndex = 9
        Me.rdb_bri.TabStop = True
        Me.rdb_bri.Text = "Brill/Espe"
        Me.rdb_bri.UseVisualStyleBackColor = True
        '
        'txt_lector
        '
        Me.txt_lector.Location = New System.Drawing.Point(3, 28)
        Me.txt_lector.Name = "txt_lector"
        Me.txt_lector.Size = New System.Drawing.Size(298, 23)
        Me.txt_lector.TabIndex = 8
        '
        'frm_control_inv
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(318, 262)
        Me.Controls.Add(Me.tbl_inventario)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_control_inv"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Control de inventarios"
        Me.tbl_inventario.ResumeLayout(False)
        Me.pag_iniciar.ResumeLayout(False)
        Me.pan_iniciar.ResumeLayout(False)
        Me.pan_iniciar.PerformLayout()
        Me.pag_rollos.ResumeLayout(False)
        Me.pan_rollos.ResumeLayout(False)
        Me.pan_rollos.PerformLayout()
        CType(Me.dtg_inv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tbl_inventario As System.Windows.Forms.TabControl
    Friend WithEvents pag_iniciar As System.Windows.Forms.TabPage
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btn_iniciar As System.Windows.Forms.Button
    Friend WithEvents cbo_bodega As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents pan_iniciar As System.Windows.Forms.Panel
    Friend WithEvents pag_rollos As System.Windows.Forms.TabPage
    Friend WithEvents pan_rollos As System.Windows.Forms.Panel
    Friend WithEvents lbl_rollos As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtg_inv As System.Windows.Forms.DataGridView
    Friend WithEvents btn_terminar As System.Windows.Forms.Button
    Friend WithEvents rdb_galv As System.Windows.Forms.RadioButton
    Friend WithEvents rdb_bri As System.Windows.Forms.RadioButton
    Friend WithEvents txt_lector As System.Windows.Forms.TextBox
    Friend WithEvents rdb_alambron As System.Windows.Forms.RadioButton
    Friend WithEvents rdb_recocido As System.Windows.Forms.RadioButton
End Class
