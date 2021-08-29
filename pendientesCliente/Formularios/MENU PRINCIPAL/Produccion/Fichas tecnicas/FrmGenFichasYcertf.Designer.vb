<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmGenFichasYcertf
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.groupbox1 = New System.Windows.Forms.GroupBox()
        Me.lblNombres = New System.Windows.Forms.Label()
        Me.lblNit = New System.Windows.Forms.Label()
        Me.txtNit = New System.Windows.Forms.TextBox()
        Me.txtNombres = New System.Windows.Forms.TextBox()
        Me.Toolbar1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btn_salir = New System.Windows.Forms.ToolStripButton()
        Me.btn_ppal = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.btn_exportar = New System.Windows.Forms.ToolStripButton()
        Me.btnConsultar = New System.Windows.Forms.ToolStripButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.dtg_consulta = New System.Windows.Forms.DataGridView()
        Me.colGenFicha = New System.Windows.Forms.DataGridViewImageColumn()
        Me.menStripDtg = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.btnCertCalidad = New System.Windows.Forms.ToolStripMenuItem()
        Me.groupbox1.SuspendLayout()
        Me.Toolbar1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dtg_consulta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.menStripDtg.SuspendLayout()
        Me.SuspendLayout()
        '
        'groupbox1
        '
        Me.groupbox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.groupbox1.Controls.Add(Me.lblNombres)
        Me.groupbox1.Controls.Add(Me.lblNit)
        Me.groupbox1.Controls.Add(Me.txtNit)
        Me.groupbox1.Controls.Add(Me.txtNombres)
        Me.groupbox1.Location = New System.Drawing.Point(2, 30)
        Me.groupbox1.Name = "groupbox1"
        Me.groupbox1.Size = New System.Drawing.Size(376, 47)
        Me.groupbox1.TabIndex = 50
        Me.groupbox1.TabStop = False
        Me.groupbox1.Text = "Filtrar cliente"
        '
        'lblNombres
        '
        Me.lblNombres.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombres.Location = New System.Drawing.Point(148, 20)
        Me.lblNombres.Name = "lblNombres"
        Me.lblNombres.Size = New System.Drawing.Size(62, 17)
        Me.lblNombres.TabIndex = 15
        Me.lblNombres.Text = "Nombres:"
        '
        'lblNit
        '
        Me.lblNit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNit.Location = New System.Drawing.Point(6, 19)
        Me.lblNit.Name = "lblNit"
        Me.lblNit.Size = New System.Drawing.Size(27, 15)
        Me.lblNit.TabIndex = 13
        Me.lblNit.Text = "Nit:"
        '
        'txtNit
        '
        Me.txtNit.Location = New System.Drawing.Point(33, 17)
        Me.txtNit.MaxLength = 13
        Me.txtNit.Name = "txtNit"
        Me.txtNit.Size = New System.Drawing.Size(111, 20)
        Me.txtNit.TabIndex = 14
        '
        'txtNombres
        '
        Me.txtNombres.Location = New System.Drawing.Point(210, 17)
        Me.txtNombres.MaxLength = 40
        Me.txtNombres.Name = "txtNombres"
        Me.txtNombres.Size = New System.Drawing.Size(160, 20)
        Me.txtNombres.TabIndex = 16
        '
        'Toolbar1
        '
        Me.Toolbar1.AutoSize = False
        Me.Toolbar1.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.Toolbar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Toolbar1.ImageScalingSize = New System.Drawing.Size(23, 23)
        Me.Toolbar1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator2, Me.btn_salir, Me.btn_ppal, Me.ToolStripSeparator3, Me.btn_exportar, Me.btnConsultar})
        Me.Toolbar1.Location = New System.Drawing.Point(0, 0)
        Me.Toolbar1.Name = "Toolbar1"
        Me.Toolbar1.Size = New System.Drawing.Size(805, 30)
        Me.Toolbar1.TabIndex = 1030
        Me.Toolbar1.Text = "ToolStrip1"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 30)
        '
        'btn_salir
        '
        Me.btn_salir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_salir.Image = Global.Spic.My.Resources.Resources._1349388328_door_in
        Me.btn_salir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_salir.Name = "btn_salir"
        Me.btn_salir.Size = New System.Drawing.Size(27, 27)
        Me.btn_salir.Text = "ToolStripButton1"
        Me.btn_salir.ToolTipText = "Salir"
        '
        'btn_ppal
        '
        Me.btn_ppal.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_ppal.Image = Global.Spic.My.Resources.Resources.ppal3
        Me.btn_ppal.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_ppal.Name = "btn_ppal"
        Me.btn_ppal.Size = New System.Drawing.Size(27, 27)
        Me.btn_ppal.Text = "ToolStripButton2"
        Me.btn_ppal.ToolTipText = "Menú principal"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 30)
        '
        'btn_exportar
        '
        Me.btn_exportar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_exportar.Image = Global.Spic.My.Resources.Resources.excel
        Me.btn_exportar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_exportar.Name = "btn_exportar"
        Me.btn_exportar.Size = New System.Drawing.Size(27, 27)
        Me.btn_exportar.Text = "Exportar Excel"
        Me.btn_exportar.ToolTipText = "Exportar a excel"
        '
        'btnConsultar
        '
        Me.btnConsultar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnConsultar.Image = Global.Spic.My.Resources.Resources.actualizar
        Me.btnConsultar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(27, 27)
        Me.btnConsultar.Text = "ToolStripButton3"
        Me.btnConsultar.ToolTipText = "Consultar"
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.txtCodigo)
        Me.GroupBox2.Controls.Add(Me.txtDescripcion)
        Me.GroupBox2.Location = New System.Drawing.Point(384, 30)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(417, 47)
        Me.GroupBox2.TabIndex = 51
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Filtrar referencia"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(169, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 17)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Descripción:"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 15)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Código:"
        '
        'txtCodigo
        '
        Me.txtCodigo.Location = New System.Drawing.Point(59, 17)
        Me.txtCodigo.MaxLength = 13
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(108, 20)
        Me.txtCodigo.TabIndex = 14
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Location = New System.Drawing.Point(251, 16)
        Me.txtDescripcion.MaxLength = 40
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(156, 20)
        Me.txtDescripcion.TabIndex = 16
        '
        'dtg_consulta
        '
        Me.dtg_consulta.AllowUserToAddRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro
        Me.dtg_consulta.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dtg_consulta.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtg_consulta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dtg_consulta.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Format = "N0"
        DataGridViewCellStyle2.NullValue = Nothing
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtg_consulta.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dtg_consulta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtg_consulta.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colGenFicha})
        Me.dtg_consulta.ContextMenuStrip = Me.menStripDtg
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.Format = "N0"
        DataGridViewCellStyle3.NullValue = Nothing
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtg_consulta.DefaultCellStyle = DataGridViewCellStyle3
        Me.dtg_consulta.Location = New System.Drawing.Point(3, 82)
        Me.dtg_consulta.Name = "dtg_consulta"
        Me.dtg_consulta.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtg_consulta.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dtg_consulta.RowHeadersVisible = False
        Me.dtg_consulta.Size = New System.Drawing.Size(799, 418)
        Me.dtg_consulta.TabIndex = 1031
        '
        'colGenFicha
        '
        Me.colGenFicha.Frozen = True
        Me.colGenFicha.HeaderText = "Ficha técnica"
        Me.colGenFicha.Image = Global.Spic.My.Resources.Resources.ficha
        Me.colGenFicha.Name = "colGenFicha"
        Me.colGenFicha.ReadOnly = True
        Me.colGenFicha.Width = 77
        '
        'menStripDtg
        '
        Me.menStripDtg.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.menStripDtg.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnCertCalidad})
        Me.menStripDtg.Name = "ContextMenuStrip1"
        Me.menStripDtg.Size = New System.Drawing.Size(196, 26)
        '
        'btnCertCalidad
        '
        Me.btnCertCalidad.Image = Global.Spic.My.Resources.Resources.ficha
        Me.btnCertCalidad.Name = "btnCertCalidad"
        Me.btnCertCalidad.Size = New System.Drawing.Size(195, 22)
        Me.btnCertCalidad.Text = "Certificado de calidad"
        '
        'FrmGenFichasYcertf
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(805, 505)
        Me.Controls.Add(Me.dtg_consulta)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Toolbar1)
        Me.Controls.Add(Me.groupbox1)
        Me.Name = "FrmGenFichasYcertf"
        Me.Text = "Generación de fichas y certificados de calidad"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.groupbox1.ResumeLayout(False)
        Me.groupbox1.PerformLayout()
        Me.Toolbar1.ResumeLayout(False)
        Me.Toolbar1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.dtg_consulta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.menStripDtg.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents groupbox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblNombres As System.Windows.Forms.Label
    Friend WithEvents lblNit As System.Windows.Forms.Label
    Friend WithEvents txtNit As System.Windows.Forms.TextBox
    Friend WithEvents txtNombres As System.Windows.Forms.TextBox
    Friend WithEvents Toolbar1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btn_salir As System.Windows.Forms.ToolStripButton
    Friend WithEvents btn_ppal As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btn_exportar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnConsultar As System.Windows.Forms.ToolStripButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents dtg_consulta As System.Windows.Forms.DataGridView
    Friend WithEvents colGenFicha As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents menStripDtg As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents btnCertCalidad As System.Windows.Forms.ToolStripMenuItem
End Class
