<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmGestRef
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
        Me.dtgInformacion = New System.Windows.Forms.DataGridView()
        Me.btnEditar = New System.Windows.Forms.DataGridViewImageColumn()
        Me.cboLinea = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.Toolbar1 = New System.Windows.Forms.ToolStrip()
        Me.btnActualizar = New System.Windows.Forms.ToolStripButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboFecIni = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboFecFin = New System.Windows.Forms.DateTimePicker()
        Me.imgProc = New System.Windows.Forms.PictureBox()
        CType(Me.dtgInformacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Toolbar1.SuspendLayout()
        CType(Me.imgProc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dtgInformacion
        '
        Me.dtgInformacion.AllowUserToAddRows = False
        Me.dtgInformacion.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro
        Me.dtgInformacion.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dtgInformacion.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtgInformacion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.dtgInformacion.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dtgInformacion.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dtgInformacion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgInformacion.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dtgInformacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgInformacion.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.btnEditar, Me.cboLinea})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.Format = "N0"
        DataGridViewCellStyle3.NullValue = Nothing
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtgInformacion.DefaultCellStyle = DataGridViewCellStyle3
        Me.dtgInformacion.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dtgInformacion.Location = New System.Drawing.Point(12, 34)
        Me.dtgInformacion.Name = "dtgInformacion"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgInformacion.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dtgInformacion.RowHeadersVisible = False
        Me.dtgInformacion.Size = New System.Drawing.Size(478, 410)
        Me.dtgInformacion.TabIndex = 1106
        '
        'btnEditar
        '
        Me.btnEditar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.btnEditar.HeaderText = ""
        Me.btnEditar.Image = Global.Spic.My.Resources.Resources.edit
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Width = 5
        '
        'cboLinea
        '
        Me.cboLinea.HeaderText = "Linea de produccón"
        Me.cboLinea.Name = "cboLinea"
        Me.cboLinea.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.cboLinea.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.cboLinea.Width = 116
        '
        'Toolbar1
        '
        Me.Toolbar1.AutoSize = False
        Me.Toolbar1.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.Toolbar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Toolbar1.ImageScalingSize = New System.Drawing.Size(23, 23)
        Me.Toolbar1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnActualizar})
        Me.Toolbar1.Location = New System.Drawing.Point(0, 0)
        Me.Toolbar1.Name = "Toolbar1"
        Me.Toolbar1.Size = New System.Drawing.Size(502, 33)
        Me.Toolbar1.TabIndex = 1107
        Me.Toolbar1.Text = "ToolStrip1"
        '
        'btnActualizar
        '
        Me.btnActualizar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnActualizar.Image = Global.Spic.My.Resources.Resources.actualizar
        Me.btnActualizar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnActualizar.Name = "btnActualizar"
        Me.btnActualizar.Size = New System.Drawing.Size(27, 30)
        Me.btnActualizar.Text = "ToolStripButton1"
        Me.btnActualizar.ToolTipText = "Actualizar consulta"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(50, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 13)
        Me.Label1.TabIndex = 1109
        Me.Label1.Text = "Fecha ini:"
        '
        'cboFecIni
        '
        Me.cboFecIni.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.cboFecIni.Location = New System.Drawing.Point(119, 8)
        Me.cboFecIni.Name = "cboFecIni"
        Me.cboFecIni.Size = New System.Drawing.Size(87, 20)
        Me.cboFecIni.TabIndex = 1108
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(216, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 13)
        Me.Label2.TabIndex = 1111
        Me.Label2.Text = "Fecha fin:"
        '
        'cboFecFin
        '
        Me.cboFecFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.cboFecFin.Location = New System.Drawing.Point(285, 8)
        Me.cboFecFin.Name = "cboFecFin"
        Me.cboFecFin.Size = New System.Drawing.Size(87, 20)
        Me.cboFecFin.TabIndex = 1110
        '
        'imgProc
        '
        Me.imgProc.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.imgProc.Image = Global.Spic.My.Resources.Resources.procesando
        Me.imgProc.Location = New System.Drawing.Point(12, 34)
        Me.imgProc.Name = "imgProc"
        Me.imgProc.Size = New System.Drawing.Size(478, 410)
        Me.imgProc.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgProc.TabIndex = 1112
        Me.imgProc.TabStop = False
        Me.imgProc.Visible = False
        '
        'FrmGestRef
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(502, 456)
        Me.Controls.Add(Me.imgProc)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboFecFin)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboFecIni)
        Me.Controls.Add(Me.Toolbar1)
        Me.Controls.Add(Me.dtgInformacion)
        Me.Name = "FrmGestRef"
        Me.Text = "Gestionar lineas de producción"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dtgInformacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Toolbar1.ResumeLayout(False)
        Me.Toolbar1.PerformLayout()
        CType(Me.imgProc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtgInformacion As System.Windows.Forms.DataGridView
    Friend WithEvents btnEditar As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents cboLinea As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents Toolbar1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnActualizar As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboFecIni As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboFecFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents imgProc As System.Windows.Forms.PictureBox
End Class
