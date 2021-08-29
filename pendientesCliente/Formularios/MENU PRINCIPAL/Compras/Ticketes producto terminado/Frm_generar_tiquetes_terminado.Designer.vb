<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_generar_tiquetes_terminado
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
        Me.Toolbar1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.btn_imprimir = New System.Windows.Forms.ToolStripButton()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.txtDesc = New System.Windows.Forms.TextBox()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txt_cant_empaque = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbo_medida = New System.Windows.Forms.ComboBox()
        Me.cbo_tipo_tiquete = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.groupCliente = New System.Windows.Forms.GroupBox()
        Me.txtDirEtiq = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtNit = New System.Windows.Forms.TextBox()
        Me.txtCiudadEtiq = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txt_nombres = New System.Windows.Forms.TextBox()
        Me.txtNomEtiq = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.dtg_clientes = New System.Windows.Forms.DataGridView()
        Me.colOk = New System.Windows.Forms.DataGridViewImageColumn()
        Me.group_producto = New System.Windows.Forms.GroupBox()
        Me.Toolbar1.SuspendLayout()
        Me.groupCliente.SuspendLayout()
        CType(Me.dtg_clientes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.group_producto.SuspendLayout()
        Me.SuspendLayout()
        '
        'Toolbar1
        '
        Me.Toolbar1.AutoSize = False
        Me.Toolbar1.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.Toolbar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Toolbar1.ImageScalingSize = New System.Drawing.Size(23, 23)
        Me.Toolbar1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator2, Me.ToolStripButton1, Me.ToolStripButton2, Me.ToolStripSeparator3, Me.btn_imprimir})
        Me.Toolbar1.Location = New System.Drawing.Point(0, 0)
        Me.Toolbar1.Name = "Toolbar1"
        Me.Toolbar1.Size = New System.Drawing.Size(628, 28)
        Me.Toolbar1.TabIndex = 1082
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
        'btn_imprimir
        '
        Me.btn_imprimir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_imprimir.Image = Global.Spic.My.Resources.Resources.imp3
        Me.btn_imprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_imprimir.Name = "btn_imprimir"
        Me.btn_imprimir.Size = New System.Drawing.Size(27, 25)
        Me.btn_imprimir.Text = "Imprimir"
        '
        'PrintDocument1
        '
        '
        'PrintDialog1
        '
        Me.PrintDialog1.Document = Me.PrintDocument1
        Me.PrintDialog1.UseEXDialog = True
        '
        'txtDesc
        '
        Me.txtDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDesc.Location = New System.Drawing.Point(132, 76)
        Me.txtDesc.Name = "txtDesc"
        Me.txtDesc.Size = New System.Drawing.Size(301, 26)
        Me.txtDesc.TabIndex = 1044
        '
        'txtCodigo
        '
        Me.txtCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigo.Location = New System.Drawing.Point(132, 44)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.ReadOnly = True
        Me.txtCodigo.Size = New System.Drawing.Size(301, 26)
        Me.txtCodigo.TabIndex = 1043
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(48, 79)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 13)
        Me.Label3.TabIndex = 1042
        Me.Label3.Text = "Descripción:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(76, 47)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(50, 13)
        Me.Label6.TabIndex = 1041
        Me.Label6.Text = "Código:"
        '
        'txt_cant_empaque
        '
        Me.txt_cant_empaque.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_cant_empaque.Location = New System.Drawing.Point(132, 109)
        Me.txt_cant_empaque.Name = "txt_cant_empaque"
        Me.txt_cant_empaque.Size = New System.Drawing.Size(100, 26)
        Me.txt_cant_empaque.TabIndex = 1084
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(5, 112)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(121, 13)
        Me.Label1.TabIndex = 1083
        Me.Label1.Text = "Cantidad contenido:"
        '
        'cbo_medida
        '
        Me.cbo_medida.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_medida.FormattingEnabled = True
        Me.cbo_medida.Items.AddRange(New Object() {"SELECCIONE", "KG", "MILL", "GRUE", "UND"})
        Me.cbo_medida.Location = New System.Drawing.Point(238, 108)
        Me.cbo_medida.Name = "cbo_medida"
        Me.cbo_medida.Size = New System.Drawing.Size(195, 28)
        Me.cbo_medida.TabIndex = 1085
        Me.cbo_medida.Text = "SELECCIONE"
        '
        'cbo_tipo_tiquete
        '
        Me.cbo_tipo_tiquete.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_tipo_tiquete.FormattingEnabled = True
        Me.cbo_tipo_tiquete.Location = New System.Drawing.Point(132, 10)
        Me.cbo_tipo_tiquete.Name = "cbo_tipo_tiquete"
        Me.cbo_tipo_tiquete.Size = New System.Drawing.Size(301, 28)
        Me.cbo_tipo_tiquete.TabIndex = 1086
        Me.cbo_tipo_tiquete.Text = "SELECCIONE"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(29, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(97, 13)
        Me.Label2.TabIndex = 1087
        Me.Label2.Text = "Tipo de tiquete:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(-3, 181)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(630, 13)
        Me.Label4.TabIndex = 1088
        Me.Label4.Text = "_________________________________________________________________________________" & _
    "________"
        '
        'groupCliente
        '
        Me.groupCliente.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.groupCliente.Controls.Add(Me.txtDirEtiq)
        Me.groupCliente.Controls.Add(Me.Label8)
        Me.groupCliente.Controls.Add(Me.txtNit)
        Me.groupCliente.Controls.Add(Me.txtCiudadEtiq)
        Me.groupCliente.Controls.Add(Me.Label5)
        Me.groupCliente.Controls.Add(Me.Label9)
        Me.groupCliente.Controls.Add(Me.txt_nombres)
        Me.groupCliente.Controls.Add(Me.txtNomEtiq)
        Me.groupCliente.Controls.Add(Me.Label12)
        Me.groupCliente.Controls.Add(Me.Label11)
        Me.groupCliente.Controls.Add(Me.dtg_clientes)
        Me.groupCliente.Location = New System.Drawing.Point(4, 202)
        Me.groupCliente.Name = "groupCliente"
        Me.groupCliente.Size = New System.Drawing.Size(612, 215)
        Me.groupCliente.TabIndex = 1090
        Me.groupCliente.TabStop = False
        Me.groupCliente.Text = "Buscar cliente"
        '
        'txtDirEtiq
        '
        Me.txtDirEtiq.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDirEtiq.Location = New System.Drawing.Point(82, 184)
        Me.txtDirEtiq.MaxLength = 33
        Me.txtDirEtiq.Name = "txtDirEtiq"
        Me.txtDirEtiq.Size = New System.Drawing.Size(510, 20)
        Me.txtDirEtiq.TabIndex = 1072
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(11, 187)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(65, 13)
        Me.Label8.TabIndex = 1071
        Me.Label8.Text = "Dirección:"
        '
        'txtNit
        '
        Me.txtNit.Location = New System.Drawing.Point(43, 17)
        Me.txtNit.Name = "txtNit"
        Me.txtNit.Size = New System.Drawing.Size(167, 20)
        Me.txtNit.TabIndex = 1064
        '
        'txtCiudadEtiq
        '
        Me.txtCiudadEtiq.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCiudadEtiq.Location = New System.Drawing.Point(82, 158)
        Me.txtCiudadEtiq.MaxLength = 33
        Me.txtCiudadEtiq.Name = "txtCiudadEtiq"
        Me.txtCiudadEtiq.Size = New System.Drawing.Size(510, 20)
        Me.txtCiudadEtiq.TabIndex = 1070
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(10, 20)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(27, 13)
        Me.Label5.TabIndex = 1063
        Me.Label5.Text = "Nit:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(11, 161)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(50, 13)
        Me.Label9.TabIndex = 1069
        Me.Label9.Text = "Ciudad:"
        '
        'txt_nombres
        '
        Me.txt_nombres.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_nombres.Location = New System.Drawing.Point(273, 19)
        Me.txt_nombres.Name = "txt_nombres"
        Me.txt_nombres.Size = New System.Drawing.Size(319, 20)
        Me.txt_nombres.TabIndex = 1062
        '
        'txtNomEtiq
        '
        Me.txtNomEtiq.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNomEtiq.Location = New System.Drawing.Point(82, 132)
        Me.txtNomEtiq.MaxLength = 30
        Me.txtNomEtiq.Name = "txtNomEtiq"
        Me.txtNomEtiq.Size = New System.Drawing.Size(510, 20)
        Me.txtNomEtiq.TabIndex = 1066
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(211, 21)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(60, 13)
        Me.Label12.TabIndex = 1061
        Me.Label12.Text = "Nombres:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(11, 135)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(60, 13)
        Me.Label11.TabIndex = 1065
        Me.Label11.Text = "Nombres:"
        '
        'dtg_clientes
        '
        Me.dtg_clientes.AllowUserToAddRows = False
        Me.dtg_clientes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtg_clientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dtg_clientes.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtg_clientes.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dtg_clientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtg_clientes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colOk})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtg_clientes.DefaultCellStyle = DataGridViewCellStyle2
        Me.dtg_clientes.Location = New System.Drawing.Point(12, 44)
        Me.dtg_clientes.Name = "dtg_clientes"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtg_clientes.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dtg_clientes.RowHeadersVisible = False
        Me.dtg_clientes.Size = New System.Drawing.Size(580, 85)
        Me.dtg_clientes.TabIndex = 0
        '
        'colOk
        '
        Me.colOk.Frozen = True
        Me.colOk.HeaderText = ""
        Me.colOk.Image = Global.Spic.My.Resources.Resources.ok3
        Me.colOk.Name = "colOk"
        Me.colOk.Width = 5
        '
        'group_producto
        '
        Me.group_producto.Controls.Add(Me.txtCodigo)
        Me.group_producto.Controls.Add(Me.Label6)
        Me.group_producto.Controls.Add(Me.Label3)
        Me.group_producto.Controls.Add(Me.Label2)
        Me.group_producto.Controls.Add(Me.txtDesc)
        Me.group_producto.Controls.Add(Me.cbo_tipo_tiquete)
        Me.group_producto.Controls.Add(Me.Label1)
        Me.group_producto.Controls.Add(Me.cbo_medida)
        Me.group_producto.Controls.Add(Me.txt_cant_empaque)
        Me.group_producto.Location = New System.Drawing.Point(4, 31)
        Me.group_producto.Name = "group_producto"
        Me.group_producto.Size = New System.Drawing.Size(611, 147)
        Me.group_producto.TabIndex = 1092
        Me.group_producto.TabStop = False
        Me.group_producto.Text = "Producto"
        '
        'Frm_generar_tiquetes_terminado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(628, 429)
        Me.Controls.Add(Me.group_producto)
        Me.Controls.Add(Me.groupCliente)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Toolbar1)
        Me.Name = "Frm_generar_tiquetes_terminado"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Imprimir tiquetes para producto terminado"
        Me.Toolbar1.ResumeLayout(False)
        Me.Toolbar1.PerformLayout()
        Me.groupCliente.ResumeLayout(False)
        Me.groupCliente.PerformLayout()
        CType(Me.dtg_clientes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.group_producto.ResumeLayout(False)
        Me.group_producto.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Toolbar1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents txtDesc As System.Windows.Forms.TextBox
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txt_cant_empaque As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbo_medida As System.Windows.Forms.ComboBox
    Friend WithEvents btn_imprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents cbo_tipo_tiquete As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents groupCliente As System.Windows.Forms.GroupBox
    Friend WithEvents txtDirEtiq As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtNit As System.Windows.Forms.TextBox
    Friend WithEvents txtCiudadEtiq As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txt_nombres As System.Windows.Forms.TextBox
    Friend WithEvents txtNomEtiq As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents dtg_clientes As System.Windows.Forms.DataGridView
    Friend WithEvents colOk As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents group_producto As System.Windows.Forms.GroupBox
End Class
