<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_cambio_cliente_vendedor
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_cambio_cliente_vendedor))
        Me.imgProcesar = New System.Windows.Forms.PictureBox()
        Me.groupCliente = New System.Windows.Forms.GroupBox()
        Me.btn_cerrar = New System.Windows.Forms.Button()
        Me.txt_nombres = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dtg_clientes = New System.Windows.Forms.DataGridView()
        Me.colOk = New System.Windows.Forms.DataGridViewImageColumn()
        Me.txt_nit = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.group_vendedores = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtDest = New System.Windows.Forms.TextBox()
        Me.txtOrg = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btn_buscar_cliente = New System.Windows.Forms.Button()
        Me.txtCliente = New System.Windows.Forms.TextBox()
        Me.cbo_vend_dest = New System.Windows.Forms.ComboBox()
        Me.cbo_vend_origen = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.group_accion = New System.Windows.Forms.GroupBox()
        Me.chk_clientes = New System.Windows.Forms.CheckBox()
        Me.chk_cartera = New System.Windows.Forms.CheckBox()
        Me.chk_pendientes = New System.Windows.Forms.CheckBox()
        Me.Toolbar1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btn_salir = New System.Windows.Forms.ToolStripButton()
        Me.btn_ppal = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnNuevo = New System.Windows.Forms.ToolStripButton()
        Me.btn_actualizar = New System.Windows.Forms.ToolStripButton()
        Me.dtg_clientes_ven_org = New System.Windows.Forms.DataGridView()
        CType(Me.imgProcesar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.groupCliente.SuspendLayout()
        CType(Me.dtg_clientes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.group_vendedores.SuspendLayout()
        Me.group_accion.SuspendLayout()
        Me.Toolbar1.SuspendLayout()
        CType(Me.dtg_clientes_ven_org, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'imgProcesar
        '
        Me.imgProcesar.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.imgProcesar.Image = Global.Spic.My.Resources.Resources.procesando
        Me.imgProcesar.Location = New System.Drawing.Point(42, 195)
        Me.imgProcesar.Name = "imgProcesar"
        Me.imgProcesar.Size = New System.Drawing.Size(621, 316)
        Me.imgProcesar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgProcesar.TabIndex = 1089
        Me.imgProcesar.TabStop = False
        Me.imgProcesar.Visible = False
        '
        'groupCliente
        '
        Me.groupCliente.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.groupCliente.Controls.Add(Me.btn_cerrar)
        Me.groupCliente.Controls.Add(Me.txt_nombres)
        Me.groupCliente.Controls.Add(Me.Label6)
        Me.groupCliente.Controls.Add(Me.dtg_clientes)
        Me.groupCliente.Controls.Add(Me.txt_nit)
        Me.groupCliente.Controls.Add(Me.Label7)
        Me.groupCliente.Location = New System.Drawing.Point(35, 147)
        Me.groupCliente.Name = "groupCliente"
        Me.groupCliente.Size = New System.Drawing.Size(638, 440)
        Me.groupCliente.TabIndex = 1088
        Me.groupCliente.TabStop = False
        Me.groupCliente.Text = "Buscar cliente"
        Me.groupCliente.Visible = False
        '
        'btn_cerrar
        '
        Me.btn_cerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_cerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_cerrar.ForeColor = System.Drawing.Color.Red
        Me.btn_cerrar.Location = New System.Drawing.Point(600, 0)
        Me.btn_cerrar.Name = "btn_cerrar"
        Me.btn_cerrar.Size = New System.Drawing.Size(37, 23)
        Me.btn_cerrar.TabIndex = 1063
        Me.btn_cerrar.Text = "X"
        Me.btn_cerrar.UseVisualStyleBackColor = True
        '
        'txt_nombres
        '
        Me.txt_nombres.Location = New System.Drawing.Point(217, 23)
        Me.txt_nombres.Name = "txt_nombres"
        Me.txt_nombres.Size = New System.Drawing.Size(215, 20)
        Me.txt_nombres.TabIndex = 1062
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(155, 25)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(60, 13)
        Me.Label6.TabIndex = 1061
        Me.Label6.Text = "Nombres:"
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
        Me.dtg_clientes.Location = New System.Drawing.Point(12, 56)
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
        Me.dtg_clientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtg_clientes.Size = New System.Drawing.Size(613, 370)
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
        'txt_nit
        '
        Me.txt_nit.Location = New System.Drawing.Point(36, 22)
        Me.txt_nit.Name = "txt_nit"
        Me.txt_nit.Size = New System.Drawing.Size(114, 20)
        Me.txt_nit.TabIndex = 1060
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(8, 25)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(27, 13)
        Me.Label7.TabIndex = 1059
        Me.Label7.Text = "Nit:"
        '
        'group_vendedores
        '
        Me.group_vendedores.Controls.Add(Me.Label5)
        Me.group_vendedores.Controls.Add(Me.Label4)
        Me.group_vendedores.Controls.Add(Me.txtDest)
        Me.group_vendedores.Controls.Add(Me.txtOrg)
        Me.group_vendedores.Controls.Add(Me.Label3)
        Me.group_vendedores.Controls.Add(Me.btn_buscar_cliente)
        Me.group_vendedores.Controls.Add(Me.txtCliente)
        Me.group_vendedores.Controls.Add(Me.cbo_vend_dest)
        Me.group_vendedores.Controls.Add(Me.cbo_vend_origen)
        Me.group_vendedores.Controls.Add(Me.Label2)
        Me.group_vendedores.Controls.Add(Me.Label1)
        Me.group_vendedores.Location = New System.Drawing.Point(12, 39)
        Me.group_vendedores.Name = "group_vendedores"
        Me.group_vendedores.Size = New System.Drawing.Size(523, 83)
        Me.group_vendedores.TabIndex = 1087
        Me.group_vendedores.TabStop = False
        Me.group_vendedores.Text = "Vendedores"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(357, 58)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(27, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Org:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(436, 58)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(32, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Dest:"
        '
        'txtDest
        '
        Me.txtDest.Enabled = False
        Me.txtDest.Location = New System.Drawing.Point(472, 55)
        Me.txtDest.Name = "txtDest"
        Me.txtDest.Size = New System.Drawing.Size(40, 20)
        Me.txtDest.TabIndex = 8
        '
        'txtOrg
        '
        Me.txtOrg.Enabled = False
        Me.txtOrg.Location = New System.Drawing.Point(390, 55)
        Me.txtOrg.Name = "txtOrg"
        Me.txtOrg.Size = New System.Drawing.Size(40, 20)
        Me.txtOrg.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(356, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(28, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "NIT:"
        '
        'btn_buscar_cliente
        '
        Me.btn_buscar_cliente.Image = Global.Spic.My.Resources.Resources.buscar7
        Me.btn_buscar_cliente.Location = New System.Drawing.Point(486, 16)
        Me.btn_buscar_cliente.Name = "btn_buscar_cliente"
        Me.btn_buscar_cliente.Size = New System.Drawing.Size(28, 23)
        Me.btn_buscar_cliente.TabIndex = 5
        Me.btn_buscar_cliente.UseVisualStyleBackColor = True
        '
        'txtCliente
        '
        Me.txtCliente.Enabled = False
        Me.txtCliente.Location = New System.Drawing.Point(390, 16)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.Size = New System.Drawing.Size(90, 20)
        Me.txtCliente.TabIndex = 4
        '
        'cbo_vend_dest
        '
        Me.cbo_vend_dest.Enabled = False
        Me.cbo_vend_dest.FormattingEnabled = True
        Me.cbo_vend_dest.Location = New System.Drawing.Point(116, 55)
        Me.cbo_vend_dest.Name = "cbo_vend_dest"
        Me.cbo_vend_dest.Size = New System.Drawing.Size(234, 21)
        Me.cbo_vend_dest.TabIndex = 3
        '
        'cbo_vend_origen
        '
        Me.cbo_vend_origen.FormattingEnabled = True
        Me.cbo_vend_origen.Location = New System.Drawing.Point(117, 17)
        Me.cbo_vend_origen.Name = "cbo_vend_origen"
        Me.cbo_vend_origen.Size = New System.Drawing.Size(233, 21)
        Me.cbo_vend_origen.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 60)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(104, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Venedor de Destino:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(105, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Vendedor de Origen:"
        '
        'group_accion
        '
        Me.group_accion.Controls.Add(Me.chk_clientes)
        Me.group_accion.Controls.Add(Me.chk_cartera)
        Me.group_accion.Controls.Add(Me.chk_pendientes)
        Me.group_accion.Enabled = False
        Me.group_accion.Location = New System.Drawing.Point(571, 39)
        Me.group_accion.Name = "group_accion"
        Me.group_accion.Size = New System.Drawing.Size(80, 83)
        Me.group_accion.TabIndex = 1086
        Me.group_accion.TabStop = False
        Me.group_accion.Text = "Acciones"
        '
        'chk_clientes
        '
        Me.chk_clientes.AutoSize = True
        Me.chk_clientes.BackColor = System.Drawing.SystemColors.Control
        Me.chk_clientes.Checked = True
        Me.chk_clientes.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk_clientes.Location = New System.Drawing.Point(0, 16)
        Me.chk_clientes.Name = "chk_clientes"
        Me.chk_clientes.Size = New System.Drawing.Size(63, 17)
        Me.chk_clientes.TabIndex = 1031
        Me.chk_clientes.Text = "Clientes"
        Me.chk_clientes.UseVisualStyleBackColor = False
        '
        'chk_cartera
        '
        Me.chk_cartera.AutoSize = True
        Me.chk_cartera.BackColor = System.Drawing.SystemColors.Control
        Me.chk_cartera.Checked = True
        Me.chk_cartera.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk_cartera.Location = New System.Drawing.Point(0, 60)
        Me.chk_cartera.Name = "chk_cartera"
        Me.chk_cartera.Size = New System.Drawing.Size(60, 17)
        Me.chk_cartera.TabIndex = 1033
        Me.chk_cartera.Text = "Cartera"
        Me.chk_cartera.UseVisualStyleBackColor = False
        '
        'chk_pendientes
        '
        Me.chk_pendientes.AutoSize = True
        Me.chk_pendientes.BackColor = System.Drawing.SystemColors.Control
        Me.chk_pendientes.Checked = True
        Me.chk_pendientes.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk_pendientes.Location = New System.Drawing.Point(0, 39)
        Me.chk_pendientes.Name = "chk_pendientes"
        Me.chk_pendientes.Size = New System.Drawing.Size(79, 17)
        Me.chk_pendientes.TabIndex = 1032
        Me.chk_pendientes.Text = "Pendientes"
        Me.chk_pendientes.UseVisualStyleBackColor = False
        '
        'Toolbar1
        '
        Me.Toolbar1.AutoSize = False
        Me.Toolbar1.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.Toolbar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Toolbar1.ImageScalingSize = New System.Drawing.Size(23, 23)
        Me.Toolbar1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator2, Me.btn_salir, Me.btn_ppal, Me.ToolStripSeparator3, Me.btnNuevo, Me.btn_actualizar})
        Me.Toolbar1.Location = New System.Drawing.Point(0, 0)
        Me.Toolbar1.Name = "Toolbar1"
        Me.Toolbar1.Size = New System.Drawing.Size(697, 30)
        Me.Toolbar1.TabIndex = 1085
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
        'btnNuevo
        '
        Me.btnNuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnNuevo.Image = CType(resources.GetObject("btnNuevo.Image"), System.Drawing.Image)
        Me.btnNuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Padding = New System.Windows.Forms.Padding(0, 0, 8, 0)
        Me.btnNuevo.Size = New System.Drawing.Size(35, 27)
        Me.btnNuevo.Text = "Nuevo"
        '
        'btn_actualizar
        '
        Me.btn_actualizar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_actualizar.Image = Global.Spic.My.Resources.Resources.actualizar
        Me.btn_actualizar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_actualizar.Name = "btn_actualizar"
        Me.btn_actualizar.Size = New System.Drawing.Size(27, 27)
        Me.btn_actualizar.Text = "Actualizar"
        '
        'dtg_clientes_ven_org
        '
        Me.dtg_clientes_ven_org.AllowUserToAddRows = False
        Me.dtg_clientes_ven_org.AllowUserToDeleteRows = False
        Me.dtg_clientes_ven_org.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtg_clientes_ven_org.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dtg_clientes_ven_org.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dtg_clientes_ven_org.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtg_clientes_ven_org.Location = New System.Drawing.Point(12, 128)
        Me.dtg_clientes_ven_org.MultiSelect = False
        Me.dtg_clientes_ven_org.Name = "dtg_clientes_ven_org"
        Me.dtg_clientes_ven_org.ReadOnly = True
        Me.dtg_clientes_ven_org.RowHeadersVisible = False
        Me.dtg_clientes_ven_org.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtg_clientes_ven_org.Size = New System.Drawing.Size(673, 471)
        Me.dtg_clientes_ven_org.TabIndex = 1084
        '
        'Frm_cambio_cliente_vendedor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(697, 605)
        Me.Controls.Add(Me.imgProcesar)
        Me.Controls.Add(Me.groupCliente)
        Me.Controls.Add(Me.group_vendedores)
        Me.Controls.Add(Me.group_accion)
        Me.Controls.Add(Me.Toolbar1)
        Me.Controls.Add(Me.dtg_clientes_ven_org)
        Me.Name = "Frm_cambio_cliente_vendedor"
        Me.Text = "Cambio de Clientes-Vendedor"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.imgProcesar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.groupCliente.ResumeLayout(False)
        Me.groupCliente.PerformLayout()
        CType(Me.dtg_clientes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.group_vendedores.ResumeLayout(False)
        Me.group_vendedores.PerformLayout()
        Me.group_accion.ResumeLayout(False)
        Me.group_accion.PerformLayout()
        Me.Toolbar1.ResumeLayout(False)
        Me.Toolbar1.PerformLayout()
        CType(Me.dtg_clientes_ven_org, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents imgProcesar As PictureBox
    Friend WithEvents groupCliente As GroupBox
    Friend WithEvents btn_cerrar As Button
    Friend WithEvents txt_nombres As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents dtg_clientes As DataGridView
    Friend WithEvents colOk As DataGridViewImageColumn
    Friend WithEvents txt_nit As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents group_vendedores As GroupBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtDest As TextBox
    Friend WithEvents txtOrg As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents btn_buscar_cliente As Button
    Friend WithEvents txtCliente As TextBox
    Friend WithEvents cbo_vend_dest As ComboBox
    Friend WithEvents cbo_vend_origen As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents group_accion As GroupBox
    Friend WithEvents chk_clientes As CheckBox
    Friend WithEvents chk_cartera As CheckBox
    Friend WithEvents chk_pendientes As CheckBox
    Friend WithEvents Toolbar1 As ToolStrip
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents btn_salir As ToolStripButton
    Friend WithEvents btn_ppal As ToolStripButton
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents btnNuevo As ToolStripButton
    Friend WithEvents btn_actualizar As ToolStripButton
    Friend WithEvents dtg_clientes_ven_org As DataGridView
End Class
