<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Estado_de_rollo
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
        Me.chkbodega11c = New System.Windows.Forms.CheckBox()
        Me.chkbodega11 = New System.Windows.Forms.CheckBox()
        Me.chkbodega2 = New System.Windows.Forms.CheckBox()
        Me.Toolbar1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnActualizar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton()
        Me.img_procesar = New System.Windows.Forms.PictureBox()
        Me.dtgconsulta = New System.Windows.Forms.DataGridView()
        Me.chkcodigo = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtNumero = New System.Windows.Forms.TextBox()
        Me.chk_b12 = New System.Windows.Forms.CheckBox()
        Me.Toolbar1.SuspendLayout()
        CType(Me.img_procesar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtgconsulta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'chkbodega11c
        '
        Me.chkbodega11c.AutoSize = True
        Me.chkbodega11c.BackColor = System.Drawing.Color.LightSteelBlue
        Me.chkbodega11c.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkbodega11c.Location = New System.Drawing.Point(222, 33)
        Me.chkbodega11c.Name = "chkbodega11c"
        Me.chkbodega11c.Size = New System.Drawing.Size(158, 17)
        Me.chkbodega11c.TabIndex = 1179
        Me.chkbodega11c.Text = "Bodega 11-Consumidos"
        Me.chkbodega11c.UseVisualStyleBackColor = False
        '
        'chkbodega11
        '
        Me.chkbodega11.AutoSize = True
        Me.chkbodega11.BackColor = System.Drawing.Color.Green
        Me.chkbodega11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkbodega11.Location = New System.Drawing.Point(88, 33)
        Me.chkbodega11.Name = "chkbodega11"
        Me.chkbodega11.Size = New System.Drawing.Size(125, 17)
        Me.chkbodega11.TabIndex = 1178
        Me.chkbodega11.Text = "Bodega 11 (Galv)"
        Me.chkbodega11.UseVisualStyleBackColor = False
        '
        'chkbodega2
        '
        Me.chkbodega2.AutoSize = True
        Me.chkbodega2.BackColor = System.Drawing.Color.MediumPurple
        Me.chkbodega2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkbodega2.Location = New System.Drawing.Point(3, 33)
        Me.chkbodega2.Name = "chkbodega2"
        Me.chkbodega2.Size = New System.Drawing.Size(80, 17)
        Me.chkbodega2.TabIndex = 1177
        Me.chkbodega2.Text = "Bodega 2"
        Me.chkbodega2.UseVisualStyleBackColor = False
        '
        'Toolbar1
        '
        Me.Toolbar1.AutoSize = False
        Me.Toolbar1.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.Toolbar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Toolbar1.ImageScalingSize = New System.Drawing.Size(23, 23)
        Me.Toolbar1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator2, Me.ToolStripButton1, Me.ToolStripButton2, Me.ToolStripSeparator3, Me.btnActualizar, Me.ToolStripButton3})
        Me.Toolbar1.Location = New System.Drawing.Point(0, 0)
        Me.Toolbar1.Name = "Toolbar1"
        Me.Toolbar1.Size = New System.Drawing.Size(703, 28)
        Me.Toolbar1.TabIndex = 1176
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
        'btnActualizar
        '
        Me.btnActualizar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnActualizar.Image = Global.Spic.My.Resources.Resources.actualizar
        Me.btnActualizar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnActualizar.Name = "btnActualizar"
        Me.btnActualizar.Size = New System.Drawing.Size(27, 25)
        Me.btnActualizar.Text = "Actualizar"
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton3.Image = Global.Spic.My.Resources.Resources.excel10
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(27, 25)
        Me.ToolStripButton3.Text = "ToolStripButton3"
        '
        'img_procesar
        '
        Me.img_procesar.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.img_procesar.Image = Global.Spic.My.Resources.Resources.procesando
        Me.img_procesar.Location = New System.Drawing.Point(16, 78)
        Me.img_procesar.Name = "img_procesar"
        Me.img_procesar.Size = New System.Drawing.Size(647, 188)
        Me.img_procesar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.img_procesar.TabIndex = 1174
        Me.img_procesar.TabStop = False
        Me.img_procesar.Visible = False
        '
        'dtgconsulta
        '
        Me.dtgconsulta.AllowUserToAddRows = False
        Me.dtgconsulta.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtgconsulta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dtgconsulta.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dtgconsulta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgconsulta.Location = New System.Drawing.Point(-5, 56)
        Me.dtgconsulta.Name = "dtgconsulta"
        Me.dtgconsulta.ReadOnly = True
        Me.dtgconsulta.RowHeadersVisible = False
        Me.dtgconsulta.Size = New System.Drawing.Size(714, 237)
        Me.dtgconsulta.TabIndex = 1175
        '
        'chkcodigo
        '
        Me.chkcodigo.AutoSize = True
        Me.chkcodigo.Location = New System.Drawing.Point(179, 10)
        Me.chkcodigo.Name = "chkcodigo"
        Me.chkcodigo.Size = New System.Drawing.Size(117, 17)
        Me.chkcodigo.TabIndex = 1203
        Me.chkcodigo.Text = "Consolidar * codigo"
        Me.chkcodigo.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(518, 34)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 13)
        Me.Label2.TabIndex = 1202
        Me.Label2.Text = "Codigo:"
        '
        'txtNumero
        '
        Me.txtNumero.Location = New System.Drawing.Point(569, 30)
        Me.txtNumero.Name = "txtNumero"
        Me.txtNumero.Size = New System.Drawing.Size(117, 20)
        Me.txtNumero.TabIndex = 1204
        '
        'chk_b12
        '
        Me.chk_b12.AutoSize = True
        Me.chk_b12.BackColor = System.Drawing.Color.DarkOrange
        Me.chk_b12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_b12.Location = New System.Drawing.Point(395, 34)
        Me.chk_b12.Name = "chk_b12"
        Me.chk_b12.Size = New System.Drawing.Size(121, 17)
        Me.chk_b12.TabIndex = 1205
        Me.chk_b12.Text = "Bodega 12(Punt)"
        Me.chk_b12.UseVisualStyleBackColor = False
        '
        'Frm_Estado_de_rollo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(703, 296)
        Me.Controls.Add(Me.chk_b12)
        Me.Controls.Add(Me.txtNumero)
        Me.Controls.Add(Me.chkcodigo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.chkbodega11c)
        Me.Controls.Add(Me.chkbodega11)
        Me.Controls.Add(Me.chkbodega2)
        Me.Controls.Add(Me.Toolbar1)
        Me.Controls.Add(Me.img_procesar)
        Me.Controls.Add(Me.dtgconsulta)
        Me.Name = "Frm_Estado_de_rollo"
        Me.Text = "Estado de rollos galvanizado"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Toolbar1.ResumeLayout(False)
        Me.Toolbar1.PerformLayout()
        CType(Me.img_procesar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtgconsulta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents chkbodega11c As System.Windows.Forms.CheckBox
    Friend WithEvents chkbodega11 As System.Windows.Forms.CheckBox
    Friend WithEvents chkbodega2 As System.Windows.Forms.CheckBox
    Friend WithEvents Toolbar1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnActualizar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents img_procesar As System.Windows.Forms.PictureBox
    Friend WithEvents dtgconsulta As System.Windows.Forms.DataGridView
    Friend WithEvents chkcodigo As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtNumero As System.Windows.Forms.TextBox
    Friend WithEvents chk_b12 As CheckBox
End Class
