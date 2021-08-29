<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAnalisisPres
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAnalisisPres))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.MenùToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrincipalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpcionesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExportarAExcelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.dtgAnalisisPres = New System.Windows.Forms.DataGridView()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cboVend = New System.Windows.Forms.ComboBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.ChkPesosVend = New System.Windows.Forms.CheckBox()
        Me.chkKilVend = New System.Windows.Forms.CheckBox()
        Me.btnBuscarVend = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnGenPres = New System.Windows.Forms.Button()
        Me.btnConsultarPres = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.lblNomVend = New System.Windows.Forms.Label()
        Me.dtgPptoGeneral = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txt_ctoTot_Kilos = New System.Windows.Forms.TextBox()
        Me.txt_ctokil_vrKil = New System.Windows.Forms.TextBox()
        Me.ctokil_vrKil = New System.Windows.Forms.Label()
        Me.imgProcesar = New System.Windows.Forms.PictureBox()
        Me.btnCerrarPres = New System.Windows.Forms.Button()
        Me.btnContCambios = New System.Windows.Forms.ToolStripButton()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.dtgAnalisisPres, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dtgPptoGeneral, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgProcesar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenùToolStripMenuItem, Me.OpcionesToolStripMenuItem, Me.btnContCambios})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1012, 27)
        Me.MenuStrip1.TabIndex = 33
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
        'dtgAnalisisPres
        '
        Me.dtgAnalisisPres.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtgAnalisisPres.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dtgAnalisisPres.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        Me.dtgAnalisisPres.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.Format = "N0"
        DataGridViewCellStyle1.NullValue = Nothing
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtgAnalisisPres.DefaultCellStyle = DataGridViewCellStyle1
        Me.dtgAnalisisPres.Location = New System.Drawing.Point(12, 94)
        Me.dtgAnalisisPres.Name = "dtgAnalisisPres"
        Me.dtgAnalisisPres.RowHeadersVisible = False
        Me.dtgAnalisisPres.Size = New System.Drawing.Size(988, 611)
        Me.dtgAnalisisPres.TabIndex = 34
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(61, 4)
        '
        'cboVend
        '
        Me.cboVend.FormattingEnabled = True
        Me.cboVend.Location = New System.Drawing.Point(7, 17)
        Me.cboVend.Name = "cboVend"
        Me.cboVend.Size = New System.Drawing.Size(99, 21)
        Me.cboVend.TabIndex = 35
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.ChkPesosVend)
        Me.GroupBox2.Controls.Add(Me.chkKilVend)
        Me.GroupBox2.Controls.Add(Me.btnBuscarVend)
        Me.GroupBox2.Controls.Add(Me.cboVend)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(87, 23)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(260, 50)
        Me.GroupBox2.TabIndex = 36
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Analizar vendedor"
        '
        'ChkPesosVend
        '
        Me.ChkPesosVend.AutoSize = True
        Me.ChkPesosVend.Location = New System.Drawing.Point(114, 11)
        Me.ChkPesosVend.Name = "ChkPesosVend"
        Me.ChkPesosVend.Size = New System.Drawing.Size(60, 17)
        Me.ChkPesosVend.TabIndex = 40
        Me.ChkPesosVend.Text = "Pesos"
        Me.ChkPesosVend.UseVisualStyleBackColor = True
        '
        'chkKilVend
        '
        Me.chkKilVend.AutoSize = True
        Me.chkKilVend.Location = New System.Drawing.Point(114, 28)
        Me.chkKilVend.Name = "chkKilVend"
        Me.chkKilVend.Size = New System.Drawing.Size(53, 17)
        Me.chkKilVend.TabIndex = 39
        Me.chkKilVend.Text = "Kilos"
        Me.chkKilVend.UseVisualStyleBackColor = True
        '
        'btnBuscarVend
        '
        Me.btnBuscarVend.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btnBuscarVend.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.btnBuscarVend.Image = Global.Spic.My.Resources.Resources.buscar7
        Me.btnBuscarVend.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscarVend.Location = New System.Drawing.Point(173, 14)
        Me.btnBuscarVend.Name = "btnBuscarVend"
        Me.btnBuscarVend.Size = New System.Drawing.Size(75, 25)
        Me.btnBuscarVend.TabIndex = 36
        Me.btnBuscarVend.Text = "Buscar"
        Me.btnBuscarVend.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ToolTip1.SetToolTip(Me.btnBuscarVend, "Cargar ventas de los ultimos 12 meses")
        Me.btnBuscarVend.UseVisualStyleBackColor = False
        '
        'btnGenPres
        '
        Me.btnGenPres.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenPres.Image = Global.Spic.My.Resources.Resources.mas
        Me.btnGenPres.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGenPres.Location = New System.Drawing.Point(587, 33)
        Me.btnGenPres.Name = "btnGenPres"
        Me.btnGenPres.Size = New System.Drawing.Size(157, 23)
        Me.btnGenPres.TabIndex = 37
        Me.btnGenPres.Text = "Generar presupuesto"
        Me.btnGenPres.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ToolTip1.SetToolTip(Me.btnGenPres, "Opciones para generar presupuesto")
        Me.btnGenPres.UseVisualStyleBackColor = True
        '
        'btnConsultarPres
        '
        Me.btnConsultarPres.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConsultarPres.Image = Global.Spic.My.Resources.Resources.buscar7
        Me.btnConsultarPres.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConsultarPres.Location = New System.Drawing.Point(587, 58)
        Me.btnConsultarPres.Name = "btnConsultarPres"
        Me.btnConsultarPres.Size = New System.Drawing.Size(157, 23)
        Me.btnConsultarPres.TabIndex = 39
        Me.btnConsultarPres.Text = "Consultar presupuesto"
        Me.btnConsultarPres.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ToolTip1.SetToolTip(Me.btnConsultarPres, "Consultar presupuesto para el vendedor seleccionado")
        Me.btnConsultarPres.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.BackColor = System.Drawing.Color.Transparent
        Me.btnGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnGuardar.Image = Global.Spic.My.Resources.Resources.save_16
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGuardar.Location = New System.Drawing.Point(750, 59)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(157, 22)
        Me.btnGuardar.TabIndex = 38
        Me.btnGuardar.Text = "Guardar Presupuesto"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ToolTip1.SetToolTip(Me.btnGuardar, "Guardar presupuesto")
        Me.btnGuardar.UseVisualStyleBackColor = False
        '
        'lblNomVend
        '
        Me.lblNomVend.AutoSize = True
        Me.lblNomVend.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNomVend.Location = New System.Drawing.Point(97, 76)
        Me.lblNomVend.Name = "lblNomVend"
        Me.lblNomVend.Size = New System.Drawing.Size(0, 13)
        Me.lblNomVend.TabIndex = 41
        '
        'dtgPptoGeneral
        '
        Me.dtgPptoGeneral.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dtgPptoGeneral.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dtgPptoGeneral.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.Format = "N0"
        DataGridViewCellStyle2.NullValue = Nothing
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtgPptoGeneral.DefaultCellStyle = DataGridViewCellStyle2
        Me.dtgPptoGeneral.Location = New System.Drawing.Point(173, 569)
        Me.dtgPptoGeneral.Name = "dtgPptoGeneral"
        Me.dtgPptoGeneral.Size = New System.Drawing.Size(669, 136)
        Me.dtgPptoGeneral.TabIndex = 46
        Me.dtgPptoGeneral.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(371, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 13)
        Me.Label1.TabIndex = 47
        Me.Label1.Text = "Cto kil_prom:"
        '
        'txt_ctoTot_Kilos
        '
        Me.txt_ctoTot_Kilos.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.txt_ctoTot_Kilos.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txt_ctoTot_Kilos.Location = New System.Drawing.Point(458, 36)
        Me.txt_ctoTot_Kilos.Name = "txt_ctoTot_Kilos"
        Me.txt_ctoTot_Kilos.Size = New System.Drawing.Size(100, 13)
        Me.txt_ctoTot_Kilos.TabIndex = 48
        Me.txt_ctoTot_Kilos.Text = "0"
        '
        'txt_ctokil_vrKil
        '
        Me.txt_ctokil_vrKil.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.txt_ctokil_vrKil.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txt_ctokil_vrKil.Location = New System.Drawing.Point(458, 60)
        Me.txt_ctokil_vrKil.Name = "txt_ctokil_vrKil"
        Me.txt_ctokil_vrKil.Size = New System.Drawing.Size(100, 13)
        Me.txt_ctokil_vrKil.TabIndex = 50
        Me.txt_ctokil_vrKil.Text = "0"
        '
        'ctokil_vrKil
        '
        Me.ctokil_vrKil.AutoSize = True
        Me.ctokil_vrKil.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ctokil_vrKil.Location = New System.Drawing.Point(371, 58)
        Me.ctokil_vrKil.Name = "ctokil_vrKil"
        Me.ctokil_vrKil.Size = New System.Drawing.Size(77, 13)
        Me.ctokil_vrKil.TabIndex = 49
        Me.ctokil_vrKil.Text = "Vr_kil_prom:"
        '
        'imgProcesar
        '
        Me.imgProcesar.Image = Global.Spic.My.Resources.Resources.procesando
        Me.imgProcesar.Location = New System.Drawing.Point(202, 227)
        Me.imgProcesar.Name = "imgProcesar"
        Me.imgProcesar.Size = New System.Drawing.Size(608, 336)
        Me.imgProcesar.TabIndex = 43
        Me.imgProcesar.TabStop = False
        '
        'btnCerrarPres
        '
        Me.btnCerrarPres.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrarPres.Image = Global.Spic.My.Resources.Resources.Candado
        Me.btnCerrarPres.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCerrarPres.Location = New System.Drawing.Point(750, 33)
        Me.btnCerrarPres.Name = "btnCerrarPres"
        Me.btnCerrarPres.Size = New System.Drawing.Size(157, 23)
        Me.btnCerrarPres.TabIndex = 45
        Me.btnCerrarPres.Text = "Cerrar Presupuesto"
        Me.btnCerrarPres.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCerrarPres.UseVisualStyleBackColor = True
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
        'FrmAnalisisPres
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1012, 711)
        Me.Controls.Add(Me.txt_ctokil_vrKil)
        Me.Controls.Add(Me.ctokil_vrKil)
        Me.Controls.Add(Me.txt_ctoTot_Kilos)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dtgPptoGeneral)
        Me.Controls.Add(Me.imgProcesar)
        Me.Controls.Add(Me.lblNomVend)
        Me.Controls.Add(Me.btnCerrarPres)
        Me.Controls.Add(Me.btnGenPres)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.btnConsultarPres)
        Me.Controls.Add(Me.dtgAnalisisPres)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.btnGuardar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmAnalisisPres"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Analisis presupuesto"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.dtgAnalisisPres, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.dtgPptoGeneral, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgProcesar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents MenùToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrincipalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SalirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpcionesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExportarAExcelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dtgAnalisisPres As System.Windows.Forms.DataGridView
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cboVend As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnBuscarVend As System.Windows.Forms.Button
    Friend WithEvents ChkPesosVend As System.Windows.Forms.CheckBox
    Friend WithEvents chkKilVend As System.Windows.Forms.CheckBox
    Friend WithEvents btnGenPres As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents btnConsultarPres As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents lblNomVend As System.Windows.Forms.Label
    Friend WithEvents imgProcesar As System.Windows.Forms.PictureBox
    Friend WithEvents btnCerrarPres As System.Windows.Forms.Button
    Friend WithEvents dtgPptoGeneral As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_ctoTot_Kilos As System.Windows.Forms.TextBox
    Friend WithEvents txt_ctokil_vrKil As System.Windows.Forms.TextBox
    Friend WithEvents ctokil_vrKil As System.Windows.Forms.Label
    Friend WithEvents btnContCambios As System.Windows.Forms.ToolStripButton
End Class
