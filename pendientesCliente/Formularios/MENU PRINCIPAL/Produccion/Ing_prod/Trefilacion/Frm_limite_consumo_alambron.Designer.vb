<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_limite_consumo_alambron
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
        Me.dtg_alambron_bd_2 = New System.Windows.Forms.DataGridView()
        Me.cms_editar = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ModificarLimiteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.bs_alambron = New System.Windows.Forms.BindingSource(Me.components)
        Me.btn_exportar = New System.Windows.Forms.Button()
        Me.txt_consecu = New System.Windows.Forms.TextBox()
        Me.lbl_consecu = New System.Windows.Forms.Label()
        Me.pn_limite_lecturas = New System.Windows.Forms.Panel()
        Me.btn_editar = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.txt_limite_consumo = New System.Windows.Forms.TextBox()
        Me.lbl_limite_consumos = New System.Windows.Forms.Label()
        CType(Me.dtg_alambron_bd_2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cms_editar.SuspendLayout()
        CType(Me.bs_alambron, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pn_limite_lecturas.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dtg_alambron_bd_2
        '
        Me.dtg_alambron_bd_2.AllowUserToAddRows = False
        Me.dtg_alambron_bd_2.AllowUserToDeleteRows = False
        Me.dtg_alambron_bd_2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtg_alambron_bd_2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtg_alambron_bd_2.ContextMenuStrip = Me.cms_editar
        Me.dtg_alambron_bd_2.Location = New System.Drawing.Point(12, 54)
        Me.dtg_alambron_bd_2.Name = "dtg_alambron_bd_2"
        Me.dtg_alambron_bd_2.RowHeadersVisible = False
        Me.dtg_alambron_bd_2.Size = New System.Drawing.Size(738, 405)
        Me.dtg_alambron_bd_2.TabIndex = 0
        '
        'cms_editar
        '
        Me.cms_editar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ModificarLimiteToolStripMenuItem})
        Me.cms_editar.Name = "cms_editar"
        Me.cms_editar.Size = New System.Drawing.Size(159, 26)
        '
        'ModificarLimiteToolStripMenuItem
        '
        Me.ModificarLimiteToolStripMenuItem.Image = Global.Spic.My.Resources.Resources.ok1
        Me.ModificarLimiteToolStripMenuItem.Name = "ModificarLimiteToolStripMenuItem"
        Me.ModificarLimiteToolStripMenuItem.Size = New System.Drawing.Size(158, 22)
        Me.ModificarLimiteToolStripMenuItem.Text = "Modificar limite"
        '
        'btn_exportar
        '
        Me.btn_exportar.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btn_exportar.Image = Global.Spic.My.Resources.Resources.excel10
        Me.btn_exportar.Location = New System.Drawing.Point(200, 12)
        Me.btn_exportar.Name = "btn_exportar"
        Me.btn_exportar.Size = New System.Drawing.Size(97, 36)
        Me.btn_exportar.TabIndex = 8
        Me.btn_exportar.Text = "Exportar"
        Me.btn_exportar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_exportar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.btn_exportar.UseVisualStyleBackColor = True
        '
        'txt_consecu
        '
        Me.txt_consecu.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_consecu.Location = New System.Drawing.Point(442, 21)
        Me.txt_consecu.Name = "txt_consecu"
        Me.txt_consecu.Size = New System.Drawing.Size(141, 20)
        Me.txt_consecu.TabIndex = 7
        '
        'lbl_consecu
        '
        Me.lbl_consecu.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lbl_consecu.AutoSize = True
        Me.lbl_consecu.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_consecu.Location = New System.Drawing.Point(355, 24)
        Me.lbl_consecu.Name = "lbl_consecu"
        Me.lbl_consecu.Size = New System.Drawing.Size(81, 13)
        Me.lbl_consecu.TabIndex = 6
        Me.lbl_consecu.Text = "Consecutivo:"
        '
        'pn_limite_lecturas
        '
        Me.pn_limite_lecturas.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.pn_limite_lecturas.AutoScroll = True
        Me.pn_limite_lecturas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pn_limite_lecturas.Controls.Add(Me.btn_editar)
        Me.pn_limite_lecturas.Controls.Add(Me.PictureBox1)
        Me.pn_limite_lecturas.Controls.Add(Me.txt_limite_consumo)
        Me.pn_limite_lecturas.Controls.Add(Me.lbl_limite_consumos)
        Me.pn_limite_lecturas.Location = New System.Drawing.Point(277, 176)
        Me.pn_limite_lecturas.Name = "pn_limite_lecturas"
        Me.pn_limite_lecturas.Size = New System.Drawing.Size(217, 109)
        Me.pn_limite_lecturas.TabIndex = 9
        '
        'btn_editar
        '
        Me.btn_editar.Location = New System.Drawing.Point(72, 75)
        Me.btn_editar.Name = "btn_editar"
        Me.btn_editar.Size = New System.Drawing.Size(75, 23)
        Me.btn_editar.TabIndex = 3
        Me.btn_editar.Text = "Cambiar"
        Me.btn_editar.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Spic.My.Resources.Resources.delete
        Me.PictureBox1.Location = New System.Drawing.Point(191, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(21, 16)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 2
        Me.PictureBox1.TabStop = False
        '
        'txt_limite_consumo
        '
        Me.txt_limite_consumo.Location = New System.Drawing.Point(58, 49)
        Me.txt_limite_consumo.Name = "txt_limite_consumo"
        Me.txt_limite_consumo.Size = New System.Drawing.Size(100, 20)
        Me.txt_limite_consumo.TabIndex = 1
        '
        'lbl_limite_consumos
        '
        Me.lbl_limite_consumos.AutoSize = True
        Me.lbl_limite_consumos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_limite_consumos.Location = New System.Drawing.Point(34, 23)
        Me.lbl_limite_consumos.Name = "lbl_limite_consumos"
        Me.lbl_limite_consumos.Size = New System.Drawing.Size(149, 13)
        Me.lbl_limite_consumos.TabIndex = 0
        Me.lbl_limite_consumos.Text = "Ingrese limite de lecturas"
        '
        'Frm_limite_consumo_alambron
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(762, 471)
        Me.Controls.Add(Me.pn_limite_lecturas)
        Me.Controls.Add(Me.btn_exportar)
        Me.Controls.Add(Me.txt_consecu)
        Me.Controls.Add(Me.lbl_consecu)
        Me.Controls.Add(Me.dtg_alambron_bd_2)
        Me.Name = "Frm_limite_consumo_alambron"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Limite consumo de alambron"
        CType(Me.dtg_alambron_bd_2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cms_editar.ResumeLayout(False)
        CType(Me.bs_alambron, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pn_limite_lecturas.ResumeLayout(False)
        Me.pn_limite_lecturas.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtg_alambron_bd_2 As System.Windows.Forms.DataGridView
    Friend WithEvents bs_alambron As System.Windows.Forms.BindingSource
    Friend WithEvents btn_exportar As System.Windows.Forms.Button
    Friend WithEvents txt_consecu As System.Windows.Forms.TextBox
    Friend WithEvents lbl_consecu As System.Windows.Forms.Label
    Friend WithEvents cms_editar As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ModificarLimiteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents pn_limite_lecturas As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents txt_limite_consumo As System.Windows.Forms.TextBox
    Friend WithEvents lbl_limite_consumos As System.Windows.Forms.Label
    Friend WithEvents btn_editar As System.Windows.Forms.Button
End Class
