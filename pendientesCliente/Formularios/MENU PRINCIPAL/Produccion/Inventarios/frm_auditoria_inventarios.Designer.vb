<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_auditoria_inventarios
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
        Me.group_transaccion = New System.Windows.Forms.GroupBox()
        Me.txt_modelo = New System.Windows.Forms.TextBox()
        Me.cbo_bodega = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.btn_guardar_trans = New System.Windows.Forms.Button()
        Me.cbo_tipo = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.group_filtro = New System.Windows.Forms.GroupBox()
        Me.chk_consolidar = New System.Windows.Forms.CheckBox()
        Me.chk_solo_faltantes = New System.Windows.Forms.CheckBox()
        Me.btn_transaccion = New System.Windows.Forms.Button()
        Me.chk_solo_fisico = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txt_inventario = New System.Windows.Forms.TextBox()
        Me.img_cargar = New System.Windows.Forms.PictureBox()
        Me.group_consulta_inv = New System.Windows.Forms.GroupBox()
        Me.btnCerrarPF = New System.Windows.Forms.Button()
        Me.dtg_consulta = New System.Windows.Forms.DataGridView()
        Me.btn_inv = New System.Windows.Forms.DataGridViewImageColumn()
        Me.txt_nomb_consulta_inv = New System.Windows.Forms.TextBox()
        Me.txt_nit_consulta_inv = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtg_auditoria = New System.Windows.Forms.DataGridView()
        Me.Toolbar1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btn_salir = New System.Windows.Forms.ToolStripButton()
        Me.btn_ppal = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnConsultar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton()
        Me.group_transaccion.SuspendLayout()
        Me.group_filtro.SuspendLayout()
        CType(Me.img_cargar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.group_consulta_inv.SuspendLayout()
        CType(Me.dtg_consulta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtg_auditoria, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Toolbar1.SuspendLayout()
        Me.SuspendLayout()
        '
        'group_transaccion
        '
        Me.group_transaccion.Controls.Add(Me.txt_modelo)
        Me.group_transaccion.Controls.Add(Me.cbo_bodega)
        Me.group_transaccion.Controls.Add(Me.Label6)
        Me.group_transaccion.Controls.Add(Me.Label5)
        Me.group_transaccion.Controls.Add(Me.Button2)
        Me.group_transaccion.Controls.Add(Me.btn_guardar_trans)
        Me.group_transaccion.Controls.Add(Me.cbo_tipo)
        Me.group_transaccion.Controls.Add(Me.Label4)
        Me.group_transaccion.Location = New System.Drawing.Point(347, 136)
        Me.group_transaccion.Name = "group_transaccion"
        Me.group_transaccion.Size = New System.Drawing.Size(364, 142)
        Me.group_transaccion.TabIndex = 1199
        Me.group_transaccion.TabStop = False
        Me.group_transaccion.Text = "Realizar Transaccion"
        Me.group_transaccion.Visible = False
        '
        'txt_modelo
        '
        Me.txt_modelo.Location = New System.Drawing.Point(223, 23)
        Me.txt_modelo.Name = "txt_modelo"
        Me.txt_modelo.Size = New System.Drawing.Size(121, 20)
        Me.txt_modelo.TabIndex = 1052
        '
        'cbo_bodega
        '
        Me.cbo_bodega.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_bodega.FormattingEnabled = True
        Me.cbo_bodega.Location = New System.Drawing.Point(51, 59)
        Me.cbo_bodega.Name = "cbo_bodega"
        Me.cbo_bodega.Size = New System.Drawing.Size(293, 21)
        Me.cbo_bodega.TabIndex = 1051
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 62)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(47, 13)
        Me.Label6.TabIndex = 1050
        Me.Label6.Text = "Bodega:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(178, 26)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(45, 13)
        Me.Label5.TabIndex = 1048
        Me.Label5.Text = "Modelo:"
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.Red
        Me.Button2.Location = New System.Drawing.Point(338, 0)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(26, 23)
        Me.Button2.TabIndex = 1047
        Me.Button2.Text = "X"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'btn_guardar_trans
        '
        Me.btn_guardar_trans.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_guardar_trans.Image = Global.Spic.My.Resources.Resources._Save
        Me.btn_guardar_trans.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_guardar_trans.Location = New System.Drawing.Point(128, 99)
        Me.btn_guardar_trans.Name = "btn_guardar_trans"
        Me.btn_guardar_trans.Size = New System.Drawing.Size(101, 33)
        Me.btn_guardar_trans.TabIndex = 2
        Me.btn_guardar_trans.Text = "Guardar"
        Me.btn_guardar_trans.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_guardar_trans.UseVisualStyleBackColor = True
        '
        'cbo_tipo
        '
        Me.cbo_tipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_tipo.FormattingEnabled = True
        Me.cbo_tipo.Location = New System.Drawing.Point(51, 22)
        Me.cbo_tipo.Name = "cbo_tipo"
        Me.cbo_tipo.Size = New System.Drawing.Size(121, 21)
        Me.cbo_tipo.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 25)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(31, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Tipo:"
        '
        'group_filtro
        '
        Me.group_filtro.Controls.Add(Me.chk_consolidar)
        Me.group_filtro.Controls.Add(Me.chk_solo_faltantes)
        Me.group_filtro.Controls.Add(Me.btn_transaccion)
        Me.group_filtro.Controls.Add(Me.chk_solo_fisico)
        Me.group_filtro.Controls.Add(Me.Label1)
        Me.group_filtro.Controls.Add(Me.txt_inventario)
        Me.group_filtro.Location = New System.Drawing.Point(12, 39)
        Me.group_filtro.Name = "group_filtro"
        Me.group_filtro.Size = New System.Drawing.Size(391, 80)
        Me.group_filtro.TabIndex = 1198
        Me.group_filtro.TabStop = False
        Me.group_filtro.Text = "Consulta"
        '
        'chk_consolidar
        '
        Me.chk_consolidar.AutoSize = True
        Me.chk_consolidar.BackColor = System.Drawing.Color.DarkTurquoise
        Me.chk_consolidar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_consolidar.Location = New System.Drawing.Point(6, 19)
        Me.chk_consolidar.Name = "chk_consolidar"
        Me.chk_consolidar.Size = New System.Drawing.Size(156, 19)
        Me.chk_consolidar.TabIndex = 1184
        Me.chk_consolidar.Text = "Consolidar inentario"
        Me.chk_consolidar.UseVisualStyleBackColor = False
        '
        'chk_solo_faltantes
        '
        Me.chk_solo_faltantes.AutoSize = True
        Me.chk_solo_faltantes.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.chk_solo_faltantes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_solo_faltantes.Location = New System.Drawing.Point(171, 19)
        Me.chk_solo_faltantes.Name = "chk_solo_faltantes"
        Me.chk_solo_faltantes.Size = New System.Drawing.Size(114, 19)
        Me.chk_solo_faltantes.TabIndex = 1187
        Me.chk_solo_faltantes.Text = "Solo faltantes"
        Me.chk_solo_faltantes.UseVisualStyleBackColor = False
        '
        'btn_transaccion
        '
        Me.btn_transaccion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_transaccion.Image = Global.Spic.My.Resources.Resources._1448305162_Exchange_Swap_Change_Direction_Arrows
        Me.btn_transaccion.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_transaccion.Location = New System.Drawing.Point(269, 44)
        Me.btn_transaccion.Name = "btn_transaccion"
        Me.btn_transaccion.Size = New System.Drawing.Size(116, 30)
        Me.btn_transaccion.TabIndex = 1190
        Me.btn_transaccion.Text = "Transaccion"
        Me.btn_transaccion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_transaccion.UseVisualStyleBackColor = True
        '
        'chk_solo_fisico
        '
        Me.chk_solo_fisico.AutoSize = True
        Me.chk_solo_fisico.BackColor = System.Drawing.Color.SlateBlue
        Me.chk_solo_fisico.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_solo_fisico.Location = New System.Drawing.Point(291, 19)
        Me.chk_solo_fisico.Name = "chk_solo_fisico"
        Me.chk_solo_fisico.Size = New System.Drawing.Size(93, 19)
        Me.chk_solo_fisico.TabIndex = 1188
        Me.chk_solo_fisico.Text = "Solo fisico"
        Me.chk_solo_fisico.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(7, 51)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 15)
        Me.Label1.TabIndex = 1185
        Me.Label1.Text = "Inventario:"
        '
        'txt_inventario
        '
        Me.txt_inventario.Location = New System.Drawing.Point(87, 50)
        Me.txt_inventario.Name = "txt_inventario"
        Me.txt_inventario.Size = New System.Drawing.Size(137, 20)
        Me.txt_inventario.TabIndex = 1186
        '
        'img_cargar
        '
        Me.img_cargar.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.img_cargar.Image = Global.Spic.My.Resources.Resources.procesando
        Me.img_cargar.Location = New System.Drawing.Point(49, 260)
        Me.img_cargar.Name = "img_cargar"
        Me.img_cargar.Size = New System.Drawing.Size(673, 213)
        Me.img_cargar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.img_cargar.TabIndex = 1197
        Me.img_cargar.TabStop = False
        Me.img_cargar.Visible = False
        '
        'group_consulta_inv
        '
        Me.group_consulta_inv.Controls.Add(Me.btnCerrarPF)
        Me.group_consulta_inv.Controls.Add(Me.dtg_consulta)
        Me.group_consulta_inv.Controls.Add(Me.txt_nomb_consulta_inv)
        Me.group_consulta_inv.Controls.Add(Me.txt_nit_consulta_inv)
        Me.group_consulta_inv.Controls.Add(Me.Label3)
        Me.group_consulta_inv.Controls.Add(Me.Label2)
        Me.group_consulta_inv.Location = New System.Drawing.Point(22, 184)
        Me.group_consulta_inv.Name = "group_consulta_inv"
        Me.group_consulta_inv.Size = New System.Drawing.Size(721, 315)
        Me.group_consulta_inv.TabIndex = 1196
        Me.group_consulta_inv.TabStop = False
        Me.group_consulta_inv.Text = "Consultar Inventarios"
        Me.group_consulta_inv.Visible = False
        '
        'btnCerrarPF
        '
        Me.btnCerrarPF.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCerrarPF.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrarPF.ForeColor = System.Drawing.Color.Red
        Me.btnCerrarPF.Location = New System.Drawing.Point(695, 8)
        Me.btnCerrarPF.Name = "btnCerrarPF"
        Me.btnCerrarPF.Size = New System.Drawing.Size(26, 23)
        Me.btnCerrarPF.TabIndex = 1046
        Me.btnCerrarPF.Text = "X"
        Me.btnCerrarPF.UseVisualStyleBackColor = True
        '
        'dtg_consulta
        '
        Me.dtg_consulta.AllowUserToAddRows = False
        Me.dtg_consulta.AllowUserToDeleteRows = False
        Me.dtg_consulta.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtg_consulta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dtg_consulta.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dtg_consulta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtg_consulta.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.btn_inv})
        Me.dtg_consulta.Location = New System.Drawing.Point(9, 63)
        Me.dtg_consulta.MultiSelect = False
        Me.dtg_consulta.Name = "dtg_consulta"
        Me.dtg_consulta.ReadOnly = True
        Me.dtg_consulta.RowHeadersVisible = False
        Me.dtg_consulta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtg_consulta.Size = New System.Drawing.Size(706, 246)
        Me.dtg_consulta.TabIndex = 4
        '
        'btn_inv
        '
        Me.btn_inv.HeaderText = ""
        Me.btn_inv.Image = Global.Spic.My.Resources.Resources.ico_ok1
        Me.btn_inv.Name = "btn_inv"
        Me.btn_inv.ReadOnly = True
        Me.btn_inv.Width = 5
        '
        'txt_nomb_consulta_inv
        '
        Me.txt_nomb_consulta_inv.Location = New System.Drawing.Point(198, 37)
        Me.txt_nomb_consulta_inv.Name = "txt_nomb_consulta_inv"
        Me.txt_nomb_consulta_inv.Size = New System.Drawing.Size(249, 20)
        Me.txt_nomb_consulta_inv.TabIndex = 3
        '
        'txt_nit_consulta_inv
        '
        Me.txt_nit_consulta_inv.Location = New System.Drawing.Point(39, 37)
        Me.txt_nit_consulta_inv.Name = "txt_nit_consulta_inv"
        Me.txt_nit_consulta_inv.Size = New System.Drawing.Size(100, 20)
        Me.txt_nit_consulta_inv.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(145, 40)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Nombre:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(5, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(28, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "NIT:"
        '
        'dtg_auditoria
        '
        Me.dtg_auditoria.AllowUserToAddRows = False
        Me.dtg_auditoria.AllowUserToDeleteRows = False
        Me.dtg_auditoria.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtg_auditoria.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dtg_auditoria.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtg_auditoria.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dtg_auditoria.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.NullValue = "0"
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtg_auditoria.DefaultCellStyle = DataGridViewCellStyle2
        Me.dtg_auditoria.Location = New System.Drawing.Point(12, 125)
        Me.dtg_auditoria.Name = "dtg_auditoria"
        Me.dtg_auditoria.ReadOnly = True
        Me.dtg_auditoria.RowHeadersVisible = False
        Me.dtg_auditoria.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtg_auditoria.Size = New System.Drawing.Size(746, 483)
        Me.dtg_auditoria.TabIndex = 1195
        '
        'Toolbar1
        '
        Me.Toolbar1.AutoSize = False
        Me.Toolbar1.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.Toolbar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Toolbar1.ImageScalingSize = New System.Drawing.Size(23, 23)
        Me.Toolbar1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator2, Me.btn_salir, Me.btn_ppal, Me.ToolStripSeparator3, Me.btnConsultar, Me.ToolStripButton3})
        Me.Toolbar1.Location = New System.Drawing.Point(0, 0)
        Me.Toolbar1.Name = "Toolbar1"
        Me.Toolbar1.Size = New System.Drawing.Size(770, 34)
        Me.Toolbar1.TabIndex = 1194
        Me.Toolbar1.Text = "ToolStrip1"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 34)
        '
        'btn_salir
        '
        Me.btn_salir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_salir.Image = Global.Spic.My.Resources.Resources._1349388328_door_in
        Me.btn_salir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_salir.Name = "btn_salir"
        Me.btn_salir.Size = New System.Drawing.Size(27, 31)
        Me.btn_salir.Text = "ToolStripButton1"
        Me.btn_salir.ToolTipText = "Salir"
        '
        'btn_ppal
        '
        Me.btn_ppal.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_ppal.Image = Global.Spic.My.Resources.Resources.ppal3
        Me.btn_ppal.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_ppal.Name = "btn_ppal"
        Me.btn_ppal.Size = New System.Drawing.Size(27, 31)
        Me.btn_ppal.Text = "ToolStripButton2"
        Me.btn_ppal.ToolTipText = "Menú principal"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 34)
        '
        'btnConsultar
        '
        Me.btnConsultar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnConsultar.Image = Global.Spic.My.Resources.Resources.update
        Me.btnConsultar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(27, 31)
        Me.btnConsultar.Text = "Consultar"
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton3.Image = Global.Spic.My.Resources.Resources.excel10
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(27, 31)
        Me.ToolStripButton3.Text = "ToolStripButton3"
        '
        'frm_auditoria_inventarios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(770, 620)
        Me.Controls.Add(Me.group_transaccion)
        Me.Controls.Add(Me.group_filtro)
        Me.Controls.Add(Me.img_cargar)
        Me.Controls.Add(Me.group_consulta_inv)
        Me.Controls.Add(Me.dtg_auditoria)
        Me.Controls.Add(Me.Toolbar1)
        Me.Name = "frm_auditoria_inventarios"
        Me.Text = "Auditoria Brillantes"
        Me.group_transaccion.ResumeLayout(False)
        Me.group_transaccion.PerformLayout()
        Me.group_filtro.ResumeLayout(False)
        Me.group_filtro.PerformLayout()
        CType(Me.img_cargar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.group_consulta_inv.ResumeLayout(False)
        Me.group_consulta_inv.PerformLayout()
        CType(Me.dtg_consulta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtg_auditoria, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Toolbar1.ResumeLayout(False)
        Me.Toolbar1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents group_transaccion As System.Windows.Forms.GroupBox
    Friend WithEvents txt_modelo As System.Windows.Forms.TextBox
    Friend WithEvents cbo_bodega As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents btn_guardar_trans As System.Windows.Forms.Button
    Friend WithEvents cbo_tipo As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents group_filtro As System.Windows.Forms.GroupBox
    Friend WithEvents chk_consolidar As System.Windows.Forms.CheckBox
    Friend WithEvents chk_solo_faltantes As System.Windows.Forms.CheckBox
    Friend WithEvents btn_transaccion As System.Windows.Forms.Button
    Friend WithEvents chk_solo_fisico As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_inventario As System.Windows.Forms.TextBox
    Friend WithEvents img_cargar As System.Windows.Forms.PictureBox
    Friend WithEvents group_consulta_inv As System.Windows.Forms.GroupBox
    Friend WithEvents btnCerrarPF As System.Windows.Forms.Button
    Friend WithEvents dtg_consulta As System.Windows.Forms.DataGridView
    Friend WithEvents btn_inv As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents txt_nomb_consulta_inv As System.Windows.Forms.TextBox
    Friend WithEvents txt_nit_consulta_inv As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtg_auditoria As System.Windows.Forms.DataGridView
    Friend WithEvents Toolbar1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btn_salir As System.Windows.Forms.ToolStripButton
    Friend WithEvents btn_ppal As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnConsultar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
End Class
