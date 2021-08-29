<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_seguimiento_alambre
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
        Me.Toolbar1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btn_salir = New System.Windows.Forms.ToolStripButton()
        Me.btn_ppal = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnConsultar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chk_noconforme = New System.Windows.Forms.RadioButton()
        Me.chk_puas = New System.Windows.Forms.RadioButton()
        Me.chk_bod2 = New System.Windows.Forms.RadioButton()
        Me.chk_bod11 = New System.Windows.Forms.RadioButton()
        Me.chk_bod12 = New System.Windows.Forms.RadioButton()
        Me.chk_bod13 = New System.Windows.Forms.RadioButton()
        Me.txt_codigo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtg_alambre = New System.Windows.Forms.DataGridView()
        Me.col_tiq = New System.Windows.Forms.DataGridViewImageColumn()
        Me.img_procesar = New System.Windows.Forms.PictureBox()
        Me.chk_consolidar = New System.Windows.Forms.CheckBox()
        Me.Toolbar1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dtg_alambre, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.img_procesar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Toolbar1
        '
        Me.Toolbar1.AutoSize = False
        Me.Toolbar1.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.Toolbar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Toolbar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Toolbar1.ImageScalingSize = New System.Drawing.Size(23, 23)
        Me.Toolbar1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator2, Me.btn_salir, Me.btn_ppal, Me.ToolStripSeparator3, Me.btnConsultar, Me.ToolStripButton3})
        Me.Toolbar1.Location = New System.Drawing.Point(0, 0)
        Me.Toolbar1.Name = "Toolbar1"
        Me.Toolbar1.Size = New System.Drawing.Size(964, 34)
        Me.Toolbar1.TabIndex = 1195
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
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chk_noconforme)
        Me.GroupBox1.Controls.Add(Me.chk_puas)
        Me.GroupBox1.Controls.Add(Me.chk_bod2)
        Me.GroupBox1.Controls.Add(Me.chk_bod11)
        Me.GroupBox1.Controls.Add(Me.chk_bod12)
        Me.GroupBox1.Controls.Add(Me.chk_bod13)
        Me.GroupBox1.Controls.Add(Me.txt_codigo)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 37)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(941, 69)
        Me.GroupBox1.TabIndex = 1196
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filtro"
        '
        'chk_noconforme
        '
        Me.chk_noconforme.AutoSize = True
        Me.chk_noconforme.BackColor = System.Drawing.Color.Turquoise
        Me.chk_noconforme.Location = New System.Drawing.Point(612, 30)
        Me.chk_noconforme.Name = "chk_noconforme"
        Me.chk_noconforme.Size = New System.Drawing.Size(119, 20)
        Me.chk_noconforme.TabIndex = 1202
        Me.chk_noconforme.Text = "Bodega 2-NC"
        Me.chk_noconforme.UseVisualStyleBackColor = False
        '
        'chk_puas
        '
        Me.chk_puas.AutoSize = True
        Me.chk_puas.BackColor = System.Drawing.Color.DarkGray
        Me.chk_puas.Location = New System.Drawing.Point(476, 30)
        Me.chk_puas.Name = "chk_puas"
        Me.chk_puas.Size = New System.Drawing.Size(127, 20)
        Me.chk_puas.TabIndex = 1201
        Me.chk_puas.Text = "Bodega 14-PU"
        Me.chk_puas.UseVisualStyleBackColor = False
        '
        'chk_bod2
        '
        Me.chk_bod2.AutoSize = True
        Me.chk_bod2.BackColor = System.Drawing.Color.LimeGreen
        Me.chk_bod2.Checked = True
        Me.chk_bod2.Location = New System.Drawing.Point(8, 29)
        Me.chk_bod2.Name = "chk_bod2"
        Me.chk_bod2.Size = New System.Drawing.Size(93, 20)
        Me.chk_bod2.TabIndex = 10
        Me.chk_bod2.TabStop = True
        Me.chk_bod2.Text = "Bodega 2"
        Me.chk_bod2.UseVisualStyleBackColor = False
        '
        'chk_bod11
        '
        Me.chk_bod11.AutoSize = True
        Me.chk_bod11.BackColor = System.Drawing.Color.Violet
        Me.chk_bod11.Location = New System.Drawing.Point(107, 29)
        Me.chk_bod11.Name = "chk_bod11"
        Me.chk_bod11.Size = New System.Drawing.Size(117, 20)
        Me.chk_bod11.TabIndex = 1198
        Me.chk_bod11.Text = "Bodega 11-G"
        Me.chk_bod11.UseVisualStyleBackColor = False
        '
        'chk_bod12
        '
        Me.chk_bod12.AutoSize = True
        Me.chk_bod12.BackColor = System.Drawing.Color.Gold
        Me.chk_bod12.Location = New System.Drawing.Point(230, 29)
        Me.chk_bod12.Name = "chk_bod12"
        Me.chk_bod12.Size = New System.Drawing.Size(116, 20)
        Me.chk_bod12.TabIndex = 1199
        Me.chk_bod12.Text = "Bodega 12-P"
        Me.chk_bod12.UseVisualStyleBackColor = False
        '
        'chk_bod13
        '
        Me.chk_bod13.AutoSize = True
        Me.chk_bod13.BackColor = System.Drawing.Color.Tomato
        Me.chk_bod13.Location = New System.Drawing.Point(353, 30)
        Me.chk_bod13.Name = "chk_bod13"
        Me.chk_bod13.Size = New System.Drawing.Size(117, 20)
        Me.chk_bod13.TabIndex = 1200
        Me.chk_bod13.Text = "Bodega 13-R"
        Me.chk_bod13.UseVisualStyleBackColor = False
        '
        'txt_codigo
        '
        Me.txt_codigo.Location = New System.Drawing.Point(813, 29)
        Me.txt_codigo.Name = "txt_codigo"
        Me.txt_codigo.Size = New System.Drawing.Size(118, 22)
        Me.txt_codigo.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(745, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 16)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Codigo:"
        '
        'dtg_alambre
        '
        Me.dtg_alambre.AllowUserToAddRows = False
        Me.dtg_alambre.AllowUserToDeleteRows = False
        Me.dtg_alambre.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtg_alambre.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dtg_alambre.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dtg_alambre.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtg_alambre.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.col_tiq})
        Me.dtg_alambre.Location = New System.Drawing.Point(12, 123)
        Me.dtg_alambre.Name = "dtg_alambre"
        Me.dtg_alambre.ReadOnly = True
        Me.dtg_alambre.RowHeadersVisible = False
        Me.dtg_alambre.Size = New System.Drawing.Size(940, 280)
        Me.dtg_alambre.TabIndex = 1197
        '
        'col_tiq
        '
        Me.col_tiq.HeaderText = "Tiquete"
        Me.col_tiq.Image = Global.Spic.My.Resources.Resources.ficha
        Me.col_tiq.Name = "col_tiq"
        Me.col_tiq.ReadOnly = True
        Me.col_tiq.Width = 49
        '
        'img_procesar
        '
        Me.img_procesar.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.img_procesar.Image = Global.Spic.My.Resources.Resources.procesando
        Me.img_procesar.Location = New System.Drawing.Point(25, 153)
        Me.img_procesar.Name = "img_procesar"
        Me.img_procesar.Size = New System.Drawing.Size(913, 205)
        Me.img_procesar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.img_procesar.TabIndex = 1198
        Me.img_procesar.TabStop = False
        Me.img_procesar.Visible = False
        '
        'chk_consolidar
        '
        Me.chk_consolidar.AutoSize = True
        Me.chk_consolidar.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.chk_consolidar.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_consolidar.Location = New System.Drawing.Point(171, 12)
        Me.chk_consolidar.Name = "chk_consolidar"
        Me.chk_consolidar.Size = New System.Drawing.Size(161, 28)
        Me.chk_consolidar.TabIndex = 1199
        Me.chk_consolidar.Text = "CONSOLIDAR"
        Me.chk_consolidar.UseVisualStyleBackColor = False
        '
        'frm_seguimiento_alambre
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(964, 404)
        Me.Controls.Add(Me.chk_consolidar)
        Me.Controls.Add(Me.img_procesar)
        Me.Controls.Add(Me.dtg_alambre)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Toolbar1)
        Me.Name = "frm_seguimiento_alambre"
        Me.Text = "Seguimiento de alambre"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Toolbar1.ResumeLayout(False)
        Me.Toolbar1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dtg_alambre, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.img_procesar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Toolbar1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btn_salir As System.Windows.Forms.ToolStripButton
    Friend WithEvents btn_ppal As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnConsultar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_codigo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtg_alambre As System.Windows.Forms.DataGridView
    Friend WithEvents chk_bod2 As System.Windows.Forms.RadioButton
    Friend WithEvents chk_bod11 As System.Windows.Forms.RadioButton
    Friend WithEvents chk_bod12 As System.Windows.Forms.RadioButton
    Friend WithEvents chk_bod13 As System.Windows.Forms.RadioButton
    Friend WithEvents img_procesar As System.Windows.Forms.PictureBox
    Friend WithEvents chk_consolidar As System.Windows.Forms.CheckBox
    Friend WithEvents col_tiq As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents chk_puas As System.Windows.Forms.RadioButton
    Friend WithEvents chk_noconforme As System.Windows.Forms.RadioButton
End Class
