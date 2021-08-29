<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmIngVotacion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmIngVotacion))
        Me.dtgVoto = New System.Windows.Forms.DataGridView()
        Me.chkVoto = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.txtPuntos = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.label1 = New System.Windows.Forms.Label()
        Me.txtNit = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtNombres = New System.Windows.Forms.TextBox()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnSalir1 = New System.Windows.Forms.ToolStripButton()
        Me.btnPpal = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnNuevo1 = New System.Windows.Forms.ToolStripButton()
        Me.btnVotar1 = New System.Windows.Forms.ToolStripButton()
        Me.imgInstruct = New System.Windows.Forms.PictureBox()
        Me.btn_salir = New System.Windows.Forms.ToolStripButton()
        Me.btn_ppal = New System.Windows.Forms.ToolStripButton()
        Me.btnNuevo = New System.Windows.Forms.ToolStripButton()
        Me.btnVotar = New System.Windows.Forms.ToolStripButton()
        Me.btnContCambios = New System.Windows.Forms.ToolStripButton()
        CType(Me.dtgVoto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.imgInstruct, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dtgVoto
        '
        Me.dtgVoto.AllowUserToAddRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro
        Me.dtgVoto.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dtgVoto.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtgVoto.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dtgVoto.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgVoto.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dtgVoto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgVoto.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.chkVoto, Me.txtPuntos})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtgVoto.DefaultCellStyle = DataGridViewCellStyle3
        Me.dtgVoto.Location = New System.Drawing.Point(426, 83)
        Me.dtgVoto.Name = "dtgVoto"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgVoto.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dtgVoto.RowHeadersVisible = False
        Me.dtgVoto.Size = New System.Drawing.Size(381, 450)
        Me.dtgVoto.TabIndex = 0
        '
        'chkVoto
        '
        Me.chkVoto.HeaderText = "Voto"
        Me.chkVoto.Name = "chkVoto"
        Me.chkVoto.Width = 46
        '
        'txtPuntos
        '
        Me.txtPuntos.HeaderText = "Puntos"
        Me.txtPuntos.Name = "txtPuntos"
        Me.txtPuntos.Width = 80
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label1.Location = New System.Drawing.Point(426, 48)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(50, 13)
        Me.label1.TabIndex = 2
        Me.label1.Text = "Cédula:"
        '
        'txtNit
        '
        Me.txtNit.Location = New System.Drawing.Point(496, 45)
        Me.txtNit.Name = "txtNit"
        Me.txtNit.Size = New System.Drawing.Size(98, 20)
        Me.txtNit.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(426, 67)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Nombres:"
        '
        'txtNombres
        '
        Me.txtNombres.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNombres.BackColor = System.Drawing.SystemColors.Window
        Me.txtNombres.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtNombres.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombres.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtNombres.Location = New System.Drawing.Point(496, 67)
        Me.txtNombres.Name = "txtNombres"
        Me.txtNombres.ReadOnly = True
        Me.txtNombres.Size = New System.Drawing.Size(311, 13)
        Me.txtNombres.TabIndex = 49
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 37)
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 37)
        '
        'ToolStrip1
        '
        Me.ToolStrip1.AutoSize = False
        Me.ToolStrip1.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.ToolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(23, 23)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator1, Me.btnSalir1, Me.btnPpal, Me.ToolStripSeparator4, Me.btnNuevo1, Me.btnVotar1, Me.btnContCambios})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(811, 33)
        Me.ToolStrip1.TabIndex = 1032
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 33)
        '
        'btnSalir1
        '
        Me.btnSalir1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnSalir1.Image = Global.Spic.My.Resources.Resources._1349388328_door_in
        Me.btnSalir1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSalir1.Name = "btnSalir1"
        Me.btnSalir1.Size = New System.Drawing.Size(27, 30)
        Me.btnSalir1.Text = "ToolStripButton1"
        Me.btnSalir1.ToolTipText = "Salir"
        '
        'btnPpal
        '
        Me.btnPpal.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnPpal.Image = Global.Spic.My.Resources.Resources.ppal3
        Me.btnPpal.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnPpal.Name = "btnPpal"
        Me.btnPpal.Size = New System.Drawing.Size(27, 30)
        Me.btnPpal.Text = "ToolStripButton2"
        Me.btnPpal.ToolTipText = "Menú principal"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 33)
        '
        'btnNuevo1
        '
        Me.btnNuevo1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnNuevo1.Image = CType(resources.GetObject("btnNuevo1.Image"), System.Drawing.Image)
        Me.btnNuevo1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnNuevo1.Name = "btnNuevo1"
        Me.btnNuevo1.Padding = New System.Windows.Forms.Padding(0, 0, 8, 0)
        Me.btnNuevo1.Size = New System.Drawing.Size(35, 30)
        Me.btnNuevo1.Text = "Nuevo"
        '
        'btnVotar1
        '
        Me.btnVotar1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnVotar1.Image = Global.Spic.My.Resources.Resources.acept1
        Me.btnVotar1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnVotar1.Name = "btnVotar1"
        Me.btnVotar1.Padding = New System.Windows.Forms.Padding(0, 0, 8, 0)
        Me.btnVotar1.Size = New System.Drawing.Size(35, 30)
        Me.btnVotar1.Text = "Votar"
        '
        'imgInstruct
        '
        Me.imgInstruct.Image = Global.Spic.My.Resources.Resources.instrucPlanta
        Me.imgInstruct.Location = New System.Drawing.Point(6, 45)
        Me.imgInstruct.Name = "imgInstruct"
        Me.imgInstruct.Size = New System.Drawing.Size(414, 488)
        Me.imgInstruct.TabIndex = 1030
        Me.imgInstruct.TabStop = False
        '
        'btn_salir
        '
        Me.btn_salir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_salir.Image = Global.Spic.My.Resources.Resources._1349388328_door_in
        Me.btn_salir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_salir.Name = "btn_salir"
        Me.btn_salir.Size = New System.Drawing.Size(27, 34)
        Me.btn_salir.Text = "ToolStripButton1"
        Me.btn_salir.ToolTipText = "Salir"
        '
        'btn_ppal
        '
        Me.btn_ppal.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_ppal.Image = Global.Spic.My.Resources.Resources.ppal3
        Me.btn_ppal.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_ppal.Name = "btn_ppal"
        Me.btn_ppal.Size = New System.Drawing.Size(27, 34)
        Me.btn_ppal.Text = "ToolStripButton2"
        Me.btn_ppal.ToolTipText = "Menú principal"
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
        'btnVotar
        '
        Me.btnVotar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnVotar.Image = Global.Spic.My.Resources.Resources.acept
        Me.btnVotar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnVotar.Name = "btnVotar"
        Me.btnVotar.Padding = New System.Windows.Forms.Padding(0, 0, 8, 0)
        Me.btnVotar.Size = New System.Drawing.Size(35, 34)
        Me.btnVotar.Text = "Votar"
        '
        'btnContCambios
        '
        Me.btnContCambios.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnContCambios.Image = Global.Spic.My.Resources.Resources.info1
        Me.btnContCambios.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnContCambios.Name = "btnContCambios"
        Me.btnContCambios.Size = New System.Drawing.Size(27, 30)
        Me.btnContCambios.Text = "Control de cambios"
        '
        'FrmIngVotacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(811, 535)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.imgInstruct)
        Me.Controls.Add(Me.txtNombres)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtNit)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.dtgVoto)
        Me.Name = "FrmIngVotacion"
        Me.Text = "Votaciones"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dtgVoto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.imgInstruct, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtgVoto As System.Windows.Forms.DataGridView
    Friend WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents txtNit As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtNombres As System.Windows.Forms.TextBox
    Friend WithEvents chkVoto As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents txtPuntos As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btn_salir As System.Windows.Forms.ToolStripButton
    Friend WithEvents btn_ppal As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnVotar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents imgInstruct As System.Windows.Forms.PictureBox
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnSalir1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnPpal As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnNuevo1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnVotar1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnContCambios As System.Windows.Forms.ToolStripButton
End Class
