<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmReg_personal_maquila
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmReg_personal_maquila))
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txt_nombres = New System.Windows.Forms.TextBox()
        Me.Toolbar1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnNuevo = New System.Windows.Forms.ToolStripButton()
        Me.btnGuardar = New System.Windows.Forms.ToolStripButton()
        Me.btn_consultar = New System.Windows.Forms.ToolStripButton()
        Me.btn_eliminar = New System.Windows.Forms.ToolStripButton()
        Me.btn_button = New System.Windows.Forms.ToolStripButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.pn_fec_ret = New System.Windows.Forms.Panel()
        Me.btn_delete = New System.Windows.Forms.Button()
        Me.dtp_fec_ret = New System.Windows.Forms.DateTimePicker()
        Me.lbl_fec_ret = New System.Windows.Forms.Label()
        Me.txt_cod_lector = New System.Windows.Forms.RichTextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.txtNit = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tsb_temporal = New System.Windows.Forms.ToolStripButton()
        Me.Toolbar1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.pn_fec_ret.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(15, 77)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(169, 13)
        Me.Label10.TabIndex = 36
        Me.Label10.Text = "Código de barras documento"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(15, 23)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(120, 13)
        Me.Label11.TabIndex = 38
        Me.Label11.Text = "Nombres y apellidos"
        '
        'txt_nombres
        '
        Me.txt_nombres.Location = New System.Drawing.Point(158, 22)
        Me.txt_nombres.MaxLength = 30
        Me.txt_nombres.Name = "txt_nombres"
        Me.txt_nombres.Size = New System.Drawing.Size(188, 20)
        Me.txt_nombres.TabIndex = 1
        '
        'Toolbar1
        '
        Me.Toolbar1.AutoSize = False
        Me.Toolbar1.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.Toolbar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Toolbar1.ImageScalingSize = New System.Drawing.Size(23, 23)
        Me.Toolbar1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator2, Me.btnNuevo, Me.btnGuardar, Me.btn_consultar, Me.btn_eliminar, Me.btn_button, Me.tsb_temporal})
        Me.Toolbar1.Location = New System.Drawing.Point(0, 0)
        Me.Toolbar1.Name = "Toolbar1"
        Me.Toolbar1.Size = New System.Drawing.Size(391, 37)
        Me.Toolbar1.TabIndex = 1029
        Me.Toolbar1.Text = "ToolStrip1"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 37)
        '
        'btnNuevo
        '
        Me.btnNuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnNuevo.Image = CType(resources.GetObject("btnNuevo.Image"), System.Drawing.Image)
        Me.btnNuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Padding = New System.Windows.Forms.Padding(0, 0, 8, 0)
        Me.btnNuevo.Size = New System.Drawing.Size(35, 34)
        Me.btnNuevo.Text = "Nuevo"
        '
        'btnGuardar
        '
        Me.btnGuardar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Padding = New System.Windows.Forms.Padding(0, 0, 8, 0)
        Me.btnGuardar.Size = New System.Drawing.Size(35, 34)
        Me.btnGuardar.Text = "Guardar"
        '
        'btn_consultar
        '
        Me.btn_consultar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_consultar.Image = Global.Spic.My.Resources.Resources.busc2
        Me.btn_consultar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_consultar.Name = "btn_consultar"
        Me.btn_consultar.Size = New System.Drawing.Size(27, 34)
        Me.btn_consultar.Text = "Consultar"
        '
        'btn_eliminar
        '
        Me.btn_eliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_eliminar.Image = Global.Spic.My.Resources.Resources.delete
        Me.btn_eliminar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_eliminar.Name = "btn_eliminar"
        Me.btn_eliminar.Size = New System.Drawing.Size(27, 34)
        Me.btn_eliminar.Text = "Eliminar"
        '
        'btn_button
        '
        Me.btn_button.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_button.Image = Global.Spic.My.Resources.Resources.buscar7
        Me.btn_button.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_button.Name = "btn_button"
        Me.btn_button.Size = New System.Drawing.Size(27, 34)
        Me.btn_button.Text = "Buscar temporales"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.pn_fec_ret)
        Me.GroupBox1.Controls.Add(Me.txt_cod_lector)
        Me.GroupBox1.Controls.Add(Me.Label23)
        Me.GroupBox1.Controls.Add(Me.txtNit)
        Me.GroupBox1.Controls.Add(Me.Label24)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txt_nombres)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 45)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(366, 207)
        Me.GroupBox1.TabIndex = 1030
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Información"
        '
        'pn_fec_ret
        '
        Me.pn_fec_ret.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pn_fec_ret.Controls.Add(Me.btn_delete)
        Me.pn_fec_ret.Controls.Add(Me.dtp_fec_ret)
        Me.pn_fec_ret.Controls.Add(Me.lbl_fec_ret)
        Me.pn_fec_ret.Location = New System.Drawing.Point(9, 80)
        Me.pn_fec_ret.Name = "pn_fec_ret"
        Me.pn_fec_ret.Size = New System.Drawing.Size(337, 112)
        Me.pn_fec_ret.TabIndex = 1031
        Me.pn_fec_ret.Visible = False
        '
        'btn_delete
        '
        Me.btn_delete.Location = New System.Drawing.Point(123, 78)
        Me.btn_delete.Name = "btn_delete"
        Me.btn_delete.Size = New System.Drawing.Size(75, 23)
        Me.btn_delete.TabIndex = 1031
        Me.btn_delete.Text = "Eliminar"
        Me.btn_delete.UseVisualStyleBackColor = True
        '
        'dtp_fec_ret
        '
        Me.dtp_fec_ret.Location = New System.Drawing.Point(111, 48)
        Me.dtp_fec_ret.Name = "dtp_fec_ret"
        Me.dtp_fec_ret.Size = New System.Drawing.Size(200, 20)
        Me.dtp_fec_ret.TabIndex = 1
        '
        'lbl_fec_ret
        '
        Me.lbl_fec_ret.AutoSize = True
        Me.lbl_fec_ret.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_fec_ret.Location = New System.Drawing.Point(23, 49)
        Me.lbl_fec_ret.Name = "lbl_fec_ret"
        Me.lbl_fec_ret.Size = New System.Drawing.Size(78, 16)
        Me.lbl_fec_ret.TabIndex = 0
        Me.lbl_fec_ret.Text = "Fec retiro:"
        '
        'txt_cod_lector
        '
        Me.txt_cod_lector.Location = New System.Drawing.Point(7, 96)
        Me.txt_cod_lector.Name = "txt_cod_lector"
        Me.txt_cod_lector.Size = New System.Drawing.Size(339, 96)
        Me.txt_cod_lector.TabIndex = 56
        Me.txt_cod_lector.Text = ""
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.Red
        Me.Label23.Location = New System.Drawing.Point(6, 51)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(12, 13)
        Me.Label23.TabIndex = 55
        Me.Label23.Text = "*"
        '
        'txtNit
        '
        Me.txtNit.Location = New System.Drawing.Point(158, 48)
        Me.txtNit.MaxLength = 30
        Me.txtNit.Name = "txtNit"
        Me.txtNit.Size = New System.Drawing.Size(188, 20)
        Me.txtNit.TabIndex = 54
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(15, 49)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(28, 13)
        Me.Label24.TabIndex = 53
        Me.Label24.Text = "NIT"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.Red
        Me.Label19.Location = New System.Drawing.Point(5, 79)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(12, 13)
        Me.Label19.TabIndex = 49
        Me.Label19.Text = "*"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Red
        Me.Label5.Location = New System.Drawing.Point(6, 26)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(12, 13)
        Me.Label5.TabIndex = 39
        Me.Label5.Text = "*"
        '
        'tsb_temporal
        '
        Me.tsb_temporal.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsb_temporal.Image = Global.Spic.My.Resources.Resources.todo
        Me.tsb_temporal.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsb_temporal.Name = "tsb_temporal"
        Me.tsb_temporal.Size = New System.Drawing.Size(27, 34)
        Me.tsb_temporal.Text = "Crear temporal"
        '
        'FrmReg_personal_maquila
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(391, 348)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Toolbar1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmReg_personal_maquila"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Gestionar personal maquilas"
        Me.Toolbar1.ResumeLayout(False)
        Me.Toolbar1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.pn_fec_ret.ResumeLayout(False)
        Me.pn_fec_ret.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txt_nombres As System.Windows.Forms.TextBox
    Friend WithEvents Toolbar1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btn_consultar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btn_eliminar As System.Windows.Forms.ToolStripButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txtNit As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents txt_cod_lector As System.Windows.Forms.RichTextBox
    Friend WithEvents btn_button As System.Windows.Forms.ToolStripButton
    Friend WithEvents pn_fec_ret As System.Windows.Forms.Panel
    Friend WithEvents dtp_fec_ret As System.Windows.Forms.DateTimePicker
    Friend WithEvents lbl_fec_ret As System.Windows.Forms.Label
    Friend WithEvents btn_delete As System.Windows.Forms.Button
    Friend WithEvents tsb_temporal As System.Windows.Forms.ToolStripButton
End Class
