<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_planilla_separe
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_planilla_separe))
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtCodigoLector = New System.Windows.Forms.TextBox()
        Me.dtgItems = New System.Windows.Forms.DataGridView()
        Me.tab_ppal = New System.Windows.Forms.TabControl()
        Me.tab_ped = New System.Windows.Forms.TabPage()
        Me.imgCed = New System.Windows.Forms.PictureBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txt_num_ped = New System.Windows.Forms.TextBox()
        Me.txt_nombres = New System.Windows.Forms.TextBox()
        Me.dtg_pedido = New System.Windows.Forms.DataGridView()
        Me.colVer = New System.Windows.Forms.DataGridViewImageColumn()
        Me.tab_transaccion = New System.Windows.Forms.TabPage()
        Me.btn_terminar = New System.Windows.Forms.Button()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dtgItems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tab_ppal.SuspendLayout()
        Me.tab_ped.SuspendLayout()
        CType(Me.imgCed, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtg_pedido, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tab_transaccion.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtCodigoLector)
        Me.GroupBox2.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(297, 45)
        Me.GroupBox2.TabIndex = 1074
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Lector Hand-Held"
        '
        'txtCodigoLector
        '
        Me.txtCodigoLector.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigoLector.Location = New System.Drawing.Point(5, 14)
        Me.txtCodigoLector.Name = "txtCodigoLector"
        Me.txtCodigoLector.Size = New System.Drawing.Size(292, 24)
        Me.txtCodigoLector.TabIndex = 1074
        '
        'dtgItems
        '
        Me.dtgItems.AllowUserToAddRows = False
        Me.dtgItems.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtgItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dtgItems.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.Format = "N1"
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgItems.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dtgItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.Format = "N0"
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtgItems.DefaultCellStyle = DataGridViewCellStyle2
        Me.dtgItems.Location = New System.Drawing.Point(-1, 54)
        Me.dtgItems.Name = "dtgItems"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgItems.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dtgItems.RowHeadersVisible = False
        Me.dtgItems.Size = New System.Drawing.Size(308, 152)
        Me.dtgItems.TabIndex = 1080
        '
        'tab_ppal
        '
        Me.tab_ppal.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tab_ppal.Controls.Add(Me.tab_ped)
        Me.tab_ppal.Controls.Add(Me.tab_transaccion)
        Me.tab_ppal.Location = New System.Drawing.Point(1, 0)
        Me.tab_ppal.Name = "tab_ppal"
        Me.tab_ppal.SelectedIndex = 0
        Me.tab_ppal.Size = New System.Drawing.Size(316, 264)
        Me.tab_ppal.TabIndex = 1085
        '
        'tab_ped
        '
        Me.tab_ped.Controls.Add(Me.imgCed)
        Me.tab_ped.Controls.Add(Me.Label5)
        Me.tab_ped.Controls.Add(Me.txt_num_ped)
        Me.tab_ped.Controls.Add(Me.txt_nombres)
        Me.tab_ped.Controls.Add(Me.dtg_pedido)
        Me.tab_ped.Location = New System.Drawing.Point(4, 22)
        Me.tab_ped.Name = "tab_ped"
        Me.tab_ped.Padding = New System.Windows.Forms.Padding(3)
        Me.tab_ped.Size = New System.Drawing.Size(308, 259)
        Me.tab_ped.TabIndex = 1
        Me.tab_ped.Text = "PEDIDO"
        Me.tab_ped.UseVisualStyleBackColor = True
        '
        'imgCed
        '
        Me.imgCed.Image = Global.Spic.My.Resources.Resources._1371750041_14125
        Me.imgCed.Location = New System.Drawing.Point(277, 6)
        Me.imgCed.Name = "imgCed"
        Me.imgCed.Size = New System.Drawing.Size(23, 22)
        Me.imgCed.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgCed.TabIndex = 1086
        Me.imgCed.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(2, 6)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(109, 20)
        Me.Label5.TabIndex = 1088
        Me.Label5.Text = "Núm pedido:"
        '
        'txt_num_ped
        '
        Me.txt_num_ped.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_num_ped.ForeColor = System.Drawing.Color.Black
        Me.txt_num_ped.Location = New System.Drawing.Point(114, 5)
        Me.txt_num_ped.Name = "txt_num_ped"
        Me.txt_num_ped.Size = New System.Drawing.Size(160, 22)
        Me.txt_num_ped.TabIndex = 1087
        '
        'txt_nombres
        '
        Me.txt_nombres.Enabled = False
        Me.txt_nombres.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_nombres.Location = New System.Drawing.Point(4, 33)
        Me.txt_nombres.MaxLength = 4
        Me.txt_nombres.Name = "txt_nombres"
        Me.txt_nombres.ReadOnly = True
        Me.txt_nombres.Size = New System.Drawing.Size(298, 21)
        Me.txt_nombres.TabIndex = 1085
        '
        'dtg_pedido
        '
        Me.dtg_pedido.AllowUserToAddRows = False
        Me.dtg_pedido.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtg_pedido.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dtg_pedido.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtg_pedido.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dtg_pedido.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtg_pedido.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colVer})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.Format = "N0"
        DataGridViewCellStyle5.NullValue = "0"
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtg_pedido.DefaultCellStyle = DataGridViewCellStyle5
        Me.dtg_pedido.Location = New System.Drawing.Point(1, 60)
        Me.dtg_pedido.Name = "dtg_pedido"
        Me.dtg_pedido.ReadOnly = True
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtg_pedido.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dtg_pedido.RowHeadersVisible = False
        Me.dtg_pedido.Size = New System.Drawing.Size(305, 196)
        Me.dtg_pedido.TabIndex = 1046
        '
        'colVer
        '
        Me.colVer.Frozen = True
        Me.colVer.HeaderText = ""
        Me.colVer.Image = Global.Spic.My.Resources.Resources.buscar7
        Me.colVer.Name = "colVer"
        Me.colVer.ReadOnly = True
        Me.colVer.Width = 5
        '
        'tab_transaccion
        '
        Me.tab_transaccion.Controls.Add(Me.btn_terminar)
        Me.tab_transaccion.Controls.Add(Me.dtgItems)
        Me.tab_transaccion.Controls.Add(Me.GroupBox2)
        Me.tab_transaccion.Location = New System.Drawing.Point(4, 22)
        Me.tab_transaccion.Name = "tab_transaccion"
        Me.tab_transaccion.Padding = New System.Windows.Forms.Padding(3)
        Me.tab_transaccion.Size = New System.Drawing.Size(308, 238)
        Me.tab_transaccion.TabIndex = 0
        Me.tab_transaccion.Text = "TRANSACCIÓN"
        Me.tab_transaccion.UseVisualStyleBackColor = True
        '
        'btn_terminar
        '
        Me.btn_terminar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_terminar.Image = Global.Spic.My.Resources.Resources.ok3
        Me.btn_terminar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_terminar.Location = New System.Drawing.Point(1, 209)
        Me.btn_terminar.Name = "btn_terminar"
        Me.btn_terminar.Size = New System.Drawing.Size(300, 27)
        Me.btn_terminar.TabIndex = 1085
        Me.btn_terminar.Text = "Terminar"
        Me.btn_terminar.UseVisualStyleBackColor = True
        '
        'Frm_planilla_separe
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(318, 262)
        Me.Controls.Add(Me.tab_ppal)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_planilla_separe"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Cargue terminado"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.dtgItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tab_ppal.ResumeLayout(False)
        Me.tab_ped.ResumeLayout(False)
        Me.tab_ped.PerformLayout()
        CType(Me.imgCed, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtg_pedido, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tab_transaccion.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtCodigoLector As System.Windows.Forms.TextBox
    Friend WithEvents dtgItems As System.Windows.Forms.DataGridView
    Friend WithEvents tab_ppal As System.Windows.Forms.TabControl
    Friend WithEvents tab_ped As System.Windows.Forms.TabPage
    Friend WithEvents tab_transaccion As System.Windows.Forms.TabPage
    Friend WithEvents dtg_pedido As System.Windows.Forms.DataGridView
    Friend WithEvents colVer As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents txt_nombres As System.Windows.Forms.TextBox
    Friend WithEvents imgCed As System.Windows.Forms.PictureBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txt_num_ped As System.Windows.Forms.TextBox
    Friend WithEvents btn_terminar As System.Windows.Forms.Button
End Class
