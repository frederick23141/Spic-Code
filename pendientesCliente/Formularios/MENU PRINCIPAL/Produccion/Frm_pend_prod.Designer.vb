<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_pend_prod
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
        Me.dtg_pend_prod = New System.Windows.Forms.DataGridView()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.cbo_linea_prod = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbo_planta = New System.Windows.Forms.ComboBox()
        Me.imgProcesar = New System.Windows.Forms.PictureBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.MenùToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrincipalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpcionesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExportarAExcelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.txt_tot_kilos = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txt_tot_cant = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.chk_detalle = New System.Windows.Forms.CheckBox()
        Me.chk_consol = New System.Windows.Forms.CheckBox()
        Me.btnContCambios = New System.Windows.Forms.ToolStripButton()
        CType(Me.dtg_pend_prod, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgProcesar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dtg_pend_prod
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro
        Me.dtg_pend_prod.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dtg_pend_prod.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtg_pend_prod.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dtg_pend_prod.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtg_pend_prod.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dtg_pend_prod.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.Format = "N0"
        DataGridViewCellStyle3.NullValue = "0"
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtg_pend_prod.DefaultCellStyle = DataGridViewCellStyle3
        Me.dtg_pend_prod.Location = New System.Drawing.Point(12, 68)
        Me.dtg_pend_prod.Name = "dtg_pend_prod"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtg_pend_prod.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dtg_pend_prod.RowHeadersVisible = False
        Me.dtg_pend_prod.Size = New System.Drawing.Size(668, 314)
        Me.dtg_pend_prod.TabIndex = 133
        '
        'Label30
        '
        Me.Label30.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(344, 37)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(127, 13)
        Me.Label30.TabIndex = 135
        Me.Label30.Text = "Linea de producciòn:"
        '
        'cbo_linea_prod
        '
        Me.cbo_linea_prod.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbo_linea_prod.FormattingEnabled = True
        Me.cbo_linea_prod.Location = New System.Drawing.Point(479, 34)
        Me.cbo_linea_prod.Name = "cbo_linea_prod"
        Me.cbo_linea_prod.Size = New System.Drawing.Size(200, 21)
        Me.cbo_linea_prod.TabIndex = 134
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(126, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 13)
        Me.Label1.TabIndex = 137
        Me.Label1.Text = "Planta:"
        '
        'cbo_planta
        '
        Me.cbo_planta.FormattingEnabled = True
        Me.cbo_planta.Location = New System.Drawing.Point(180, 34)
        Me.cbo_planta.Name = "cbo_planta"
        Me.cbo_planta.Size = New System.Drawing.Size(158, 21)
        Me.cbo_planta.TabIndex = 136
        '
        'imgProcesar
        '
        Me.imgProcesar.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.imgProcesar.Image = Global.Spic.My.Resources.Resources.procesando
        Me.imgProcesar.Location = New System.Drawing.Point(52, 86)
        Me.imgProcesar.Name = "imgProcesar"
        Me.imgProcesar.Size = New System.Drawing.Size(566, 279)
        Me.imgProcesar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgProcesar.TabIndex = 138
        Me.imgProcesar.TabStop = False
        Me.imgProcesar.Visible = False
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenùToolStripMenuItem, Me.OpcionesToolStripMenuItem, Me.btnContCambios})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(692, 27)
        Me.MenuStrip1.TabIndex = 139
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'MenùToolStripMenuItem
        '
        Me.MenùToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrincipalToolStripMenuItem, Me.SalirToolStripMenuItem})
        Me.MenùToolStripMenuItem.Name = "MenùToolStripMenuItem"
        Me.MenùToolStripMenuItem.Size = New System.Drawing.Size(45, 23)
        Me.MenùToolStripMenuItem.Text = "Menù"
        '
        'PrincipalToolStripMenuItem
        '
        Me.PrincipalToolStripMenuItem.Image = Global.Spic.My.Resources.Resources.ppal3
        Me.PrincipalToolStripMenuItem.Name = "PrincipalToolStripMenuItem"
        Me.PrincipalToolStripMenuItem.Size = New System.Drawing.Size(113, 22)
        Me.PrincipalToolStripMenuItem.Text = "Principal"
        '
        'SalirToolStripMenuItem
        '
        Me.SalirToolStripMenuItem.Image = Global.Spic.My.Resources.Resources.salir
        Me.SalirToolStripMenuItem.Name = "SalirToolStripMenuItem"
        Me.SalirToolStripMenuItem.Size = New System.Drawing.Size(113, 22)
        Me.SalirToolStripMenuItem.Text = "Salir"
        '
        'OpcionesToolStripMenuItem
        '
        Me.OpcionesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExportarAExcelToolStripMenuItem})
        Me.OpcionesToolStripMenuItem.Name = "OpcionesToolStripMenuItem"
        Me.OpcionesToolStripMenuItem.Size = New System.Drawing.Size(63, 23)
        Me.OpcionesToolStripMenuItem.Text = "Opciones"
        '
        'ExportarAExcelToolStripMenuItem
        '
        Me.ExportarAExcelToolStripMenuItem.Image = Global.Spic.My.Resources.Resources.excel
        Me.ExportarAExcelToolStripMenuItem.Name = "ExportarAExcelToolStripMenuItem"
        Me.ExportarAExcelToolStripMenuItem.Size = New System.Drawing.Size(153, 22)
        Me.ExportarAExcelToolStripMenuItem.Text = "Exportar a excel"
        '
        'txt_tot_kilos
        '
        Me.txt_tot_kilos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txt_tot_kilos.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txt_tot_kilos.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txt_tot_kilos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_tot_kilos.Location = New System.Drawing.Point(315, 389)
        Me.txt_tot_kilos.Name = "txt_tot_kilos"
        Me.txt_tot_kilos.ReadOnly = True
        Me.txt_tot_kilos.Size = New System.Drawing.Size(138, 13)
        Me.txt_tot_kilos.TabIndex = 147
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(277, 388)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 14)
        Me.Label2.TabIndex = 146
        Me.Label2.Text = "Kilos:"
        '
        'txt_tot_cant
        '
        Me.txt_tot_cant.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txt_tot_cant.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txt_tot_cant.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txt_tot_cant.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_tot_cant.Location = New System.Drawing.Point(129, 389)
        Me.txt_tot_cant.Name = "txt_tot_cant"
        Me.txt_tot_cant.ReadOnly = True
        Me.txt_tot_cant.Size = New System.Drawing.Size(126, 13)
        Me.txt_tot_cant.TabIndex = 145
        '
        'Label14
        '
        Me.Label14.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(66, 388)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(65, 14)
        Me.Label14.TabIndex = 144
        Me.Label14.Text = "Cantidad:"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(11, 387)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 14)
        Me.Label3.TabIndex = 148
        Me.Label3.Text = "Totales:"
        '
        'chk_detalle
        '
        Me.chk_detalle.AutoSize = True
        Me.chk_detalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_detalle.Location = New System.Drawing.Point(15, 26)
        Me.chk_detalle.Name = "chk_detalle"
        Me.chk_detalle.Size = New System.Drawing.Size(66, 17)
        Me.chk_detalle.TabIndex = 368
        Me.chk_detalle.Text = "Detalle"
        Me.chk_detalle.UseVisualStyleBackColor = True
        '
        'chk_consol
        '
        Me.chk_consol.AutoSize = True
        Me.chk_consol.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_consol.Location = New System.Drawing.Point(15, 44)
        Me.chk_consol.Name = "chk_consol"
        Me.chk_consol.Size = New System.Drawing.Size(95, 17)
        Me.chk_consol.TabIndex = 369
        Me.chk_consol.Text = "Consolidado"
        Me.chk_consol.UseVisualStyleBackColor = True
        '
        'btnContCambios
        '
        Me.btnContCambios.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnContCambios.Image = Global.Spic.My.Resources.Resources.info1
        Me.btnContCambios.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnContCambios.Name = "btnContCambios"
        Me.btnContCambios.Size = New System.Drawing.Size(23, 20)
        Me.btnContCambios.Text = "Control de cambios"
        '
        'Frm_pend_prod
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(692, 406)
        Me.Controls.Add(Me.chk_consol)
        Me.Controls.Add(Me.chk_detalle)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txt_tot_kilos)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txt_tot_cant)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.imgProcesar)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cbo_planta)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.cbo_linea_prod)
        Me.Controls.Add(Me.dtg_pend_prod)
        Me.Name = "Frm_pend_prod"
        Me.Text = "Pendientes"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dtg_pend_prod, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgProcesar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtg_pend_prod As System.Windows.Forms.DataGridView
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents cbo_linea_prod As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbo_planta As System.Windows.Forms.ComboBox
    Friend WithEvents imgProcesar As System.Windows.Forms.PictureBox
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents MenùToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrincipalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SalirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpcionesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExportarAExcelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txt_tot_kilos As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_tot_cant As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents chk_detalle As System.Windows.Forms.CheckBox
    Friend WithEvents chk_consol As System.Windows.Forms.CheckBox
    Friend WithEvents btnContCambios As System.Windows.Forms.ToolStripButton
End Class
