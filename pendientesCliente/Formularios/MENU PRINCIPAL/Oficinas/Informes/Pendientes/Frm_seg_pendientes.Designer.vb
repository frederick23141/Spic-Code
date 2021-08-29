<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_seg_pendientes
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
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.txt_estado_sin_ruta = New System.Windows.Forms.TextBox()
        Me.imgProc = New System.Windows.Forms.PictureBox()
        Me.groupCliente = New System.Windows.Forms.GroupBox()
        Me.btn_cerrar = New System.Windows.Forms.Button()
        Me.txt_nombres = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtg_clientes = New System.Windows.Forms.DataGridView()
        Me.colOk = New System.Windows.Forms.DataGridViewImageColumn()
        Me.txt_nit = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.group_clasificacion = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dtg_modif_clas = New System.Windows.Forms.DataGridView()
        Me.col_borrar_clas = New System.Windows.Forms.DataGridViewImageColumn()
        Me.col_id_mod_clas = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_desc_mod_clas = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btn_cerrar_clas = New System.Windows.Forms.Button()
        Me.dtg_asignar_clas = New System.Windows.Forms.DataGridView()
        Me.col_ok_clas = New System.Windows.Forms.DataGridViewImageColumn()
        Me.tab1 = New System.Windows.Forms.TabControl()
        Me.tab_pen_con_ruta = New System.Windows.Forms.TabPage()
        Me.dtg_consulta = New System.Windows.Forms.DataGridView()
        Me.col_guardar_con_ruta = New System.Windows.Forms.DataGridViewImageColumn()
        Me.menStripDtg = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.itemMail = New System.Windows.Forms.ToolStripMenuItem()
        Me.itemMasInfo = New System.Windows.Forms.ToolStripMenuItem()
        Me.VerStockToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tab_pen_sin_ruta = New System.Windows.Forms.TabPage()
        Me.dtgSinRuta = New System.Windows.Forms.DataGridView()
        Me.col_guardar_sin_ruta = New System.Windows.Forms.DataGridViewImageColumn()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txt_vend_max = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txt_vend_min = New System.Windows.Forms.TextBox()
        Me.txt_cliente = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtNumero = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txt_codigo = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lbl_mes = New System.Windows.Forms.Label()
        Me.cbo_ruta = New System.Windows.Forms.ComboBox()
        Me.Toolbar1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btn_salir = New System.Windows.Forms.ToolStripButton()
        Me.btn_ppal = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.btn_exportar = New System.Windows.Forms.ToolStripButton()
        Me.btnActualizar = New System.Windows.Forms.ToolStripButton()
        Me.cboCal = New System.Windows.Forms.MonthCalendar()
        Me.btn_cerrar_cal = New System.Windows.Forms.Button()
        CType(Me.imgProc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.groupCliente.SuspendLayout()
        CType(Me.dtg_clientes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.group_clasificacion.SuspendLayout()
        CType(Me.dtg_modif_clas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtg_asignar_clas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tab1.SuspendLayout()
        Me.tab_pen_con_ruta.SuspendLayout()
        CType(Me.dtg_consulta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.menStripDtg.SuspendLayout()
        Me.tab_pen_sin_ruta.SuspendLayout()
        CType(Me.dtgSinRuta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.Toolbar1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txt_estado_sin_ruta
        '
        Me.txt_estado_sin_ruta.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txt_estado_sin_ruta.Location = New System.Drawing.Point(274, 124)
        Me.txt_estado_sin_ruta.Name = "txt_estado_sin_ruta"
        Me.txt_estado_sin_ruta.Size = New System.Drawing.Size(38, 13)
        Me.txt_estado_sin_ruta.TabIndex = 1080
        '
        'imgProc
        '
        Me.imgProc.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.imgProc.Image = Global.Spic.My.Resources.Resources.procesando
        Me.imgProc.Location = New System.Drawing.Point(32, 153)
        Me.imgProc.Name = "imgProc"
        Me.imgProc.Size = New System.Drawing.Size(623, 333)
        Me.imgProc.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgProc.TabIndex = 1076
        Me.imgProc.TabStop = False
        Me.imgProc.Visible = False
        '
        'groupCliente
        '
        Me.groupCliente.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.groupCliente.Controls.Add(Me.btn_cerrar)
        Me.groupCliente.Controls.Add(Me.txt_nombres)
        Me.groupCliente.Controls.Add(Me.Label1)
        Me.groupCliente.Controls.Add(Me.dtg_clientes)
        Me.groupCliente.Controls.Add(Me.txt_nit)
        Me.groupCliente.Controls.Add(Me.Label5)
        Me.groupCliente.Location = New System.Drawing.Point(142, 155)
        Me.groupCliente.Name = "groupCliente"
        Me.groupCliente.Size = New System.Drawing.Size(445, 295)
        Me.groupCliente.TabIndex = 1078
        Me.groupCliente.TabStop = False
        Me.groupCliente.Text = "Buscar cliente"
        Me.groupCliente.Visible = False
        '
        'btn_cerrar
        '
        Me.btn_cerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_cerrar.ForeColor = System.Drawing.Color.Red
        Me.btn_cerrar.Location = New System.Drawing.Point(407, 0)
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
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(155, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 13)
        Me.Label1.TabIndex = 1061
        Me.Label1.Text = "Nombres:"
        '
        'dtg_clientes
        '
        Me.dtg_clientes.AllowUserToAddRows = False
        Me.dtg_clientes.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dtg_clientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dtg_clientes.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dtg_clientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtg_clientes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colOk})
        Me.dtg_clientes.Location = New System.Drawing.Point(12, 56)
        Me.dtg_clientes.Name = "dtg_clientes"
        Me.dtg_clientes.RowHeadersVisible = False
        Me.dtg_clientes.Size = New System.Drawing.Size(420, 225)
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
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(8, 25)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(27, 13)
        Me.Label5.TabIndex = 1059
        Me.Label5.Text = "Nit:"
        '
        'group_clasificacion
        '
        Me.group_clasificacion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.group_clasificacion.Controls.Add(Me.Label6)
        Me.group_clasificacion.Controls.Add(Me.dtg_modif_clas)
        Me.group_clasificacion.Controls.Add(Me.btn_cerrar_clas)
        Me.group_clasificacion.Controls.Add(Me.dtg_asignar_clas)
        Me.group_clasificacion.Location = New System.Drawing.Point(139, 145)
        Me.group_clasificacion.Name = "group_clasificacion"
        Me.group_clasificacion.Size = New System.Drawing.Size(445, 340)
        Me.group_clasificacion.TabIndex = 1079
        Me.group_clasificacion.TabStop = False
        Me.group_clasificacion.Text = "Asignar clasificación"
        Me.group_clasificacion.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(12, 179)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(134, 13)
        Me.Label6.TabIndex = 1081
        Me.Label6.Text = "Modificar clasificación"
        '
        'dtg_modif_clas
        '
        Me.dtg_modif_clas.AllowUserToAddRows = False
        Me.dtg_modif_clas.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dtg_modif_clas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dtg_modif_clas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dtg_modif_clas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtg_modif_clas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.col_borrar_clas, Me.col_id_mod_clas, Me.col_desc_mod_clas})
        Me.dtg_modif_clas.Location = New System.Drawing.Point(15, 195)
        Me.dtg_modif_clas.Name = "dtg_modif_clas"
        Me.dtg_modif_clas.RowHeadersVisible = False
        Me.dtg_modif_clas.Size = New System.Drawing.Size(420, 134)
        Me.dtg_modif_clas.TabIndex = 0
        '
        'col_borrar_clas
        '
        Me.col_borrar_clas.Frozen = True
        Me.col_borrar_clas.HeaderText = ""
        Me.col_borrar_clas.Image = Global.Spic.My.Resources.Resources.x
        Me.col_borrar_clas.Name = "col_borrar_clas"
        Me.col_borrar_clas.Width = 5
        '
        'col_id_mod_clas
        '
        Me.col_id_mod_clas.HeaderText = "id"
        Me.col_id_mod_clas.Name = "col_id_mod_clas"
        Me.col_id_mod_clas.Width = 40
        '
        'col_desc_mod_clas
        '
        Me.col_desc_mod_clas.HeaderText = "Descripción"
        Me.col_desc_mod_clas.Name = "col_desc_mod_clas"
        Me.col_desc_mod_clas.Width = 88
        '
        'btn_cerrar_clas
        '
        Me.btn_cerrar_clas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_cerrar_clas.ForeColor = System.Drawing.Color.Red
        Me.btn_cerrar_clas.Location = New System.Drawing.Point(407, 0)
        Me.btn_cerrar_clas.Name = "btn_cerrar_clas"
        Me.btn_cerrar_clas.Size = New System.Drawing.Size(37, 23)
        Me.btn_cerrar_clas.TabIndex = 1063
        Me.btn_cerrar_clas.Text = "X"
        Me.btn_cerrar_clas.UseVisualStyleBackColor = True
        '
        'dtg_asignar_clas
        '
        Me.dtg_asignar_clas.AllowUserToAddRows = False
        Me.dtg_asignar_clas.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtg_asignar_clas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dtg_asignar_clas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dtg_asignar_clas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtg_asignar_clas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.col_ok_clas})
        Me.dtg_asignar_clas.Location = New System.Drawing.Point(12, 20)
        Me.dtg_asignar_clas.Name = "dtg_asignar_clas"
        Me.dtg_asignar_clas.RowHeadersVisible = False
        Me.dtg_asignar_clas.Size = New System.Drawing.Size(420, 156)
        Me.dtg_asignar_clas.TabIndex = 0
        '
        'col_ok_clas
        '
        Me.col_ok_clas.Frozen = True
        Me.col_ok_clas.HeaderText = ""
        Me.col_ok_clas.Image = Global.Spic.My.Resources.Resources.ok3
        Me.col_ok_clas.Name = "col_ok_clas"
        Me.col_ok_clas.Width = 5
        '
        'tab1
        '
        Me.tab1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tab1.Controls.Add(Me.tab_pen_con_ruta)
        Me.tab1.Controls.Add(Me.tab_pen_sin_ruta)
        Me.tab1.Location = New System.Drawing.Point(11, 120)
        Me.tab1.Name = "tab1"
        Me.tab1.SelectedIndex = 0
        Me.tab1.Size = New System.Drawing.Size(653, 380)
        Me.tab1.TabIndex = 1079
        '
        'tab_pen_con_ruta
        '
        Me.tab_pen_con_ruta.Controls.Add(Me.dtg_consulta)
        Me.tab_pen_con_ruta.Location = New System.Drawing.Point(4, 22)
        Me.tab_pen_con_ruta.Name = "tab_pen_con_ruta"
        Me.tab_pen_con_ruta.Padding = New System.Windows.Forms.Padding(3)
        Me.tab_pen_con_ruta.Size = New System.Drawing.Size(645, 354)
        Me.tab_pen_con_ruta.TabIndex = 0
        Me.tab_pen_con_ruta.Text = "Pendientes por ruta"
        Me.tab_pen_con_ruta.UseVisualStyleBackColor = True
        '
        'dtg_consulta
        '
        Me.dtg_consulta.AllowUserToAddRows = False
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.LightGray
        DataGridViewCellStyle11.NullValue = Nothing
        Me.dtg_consulta.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle11
        Me.dtg_consulta.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtg_consulta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dtg_consulta.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dtg_consulta.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle15.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle15.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtg_consulta.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle15
        Me.dtg_consulta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtg_consulta.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.col_guardar_con_ruta})
        Me.dtg_consulta.ContextMenuStrip = Me.menStripDtg
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle16.Format = "N0"
        DataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtg_consulta.DefaultCellStyle = DataGridViewCellStyle16
        Me.dtg_consulta.Location = New System.Drawing.Point(0, 2)
        Me.dtg_consulta.Name = "dtg_consulta"
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtg_consulta.RowHeadersDefaultCellStyle = DataGridViewCellStyle17
        Me.dtg_consulta.RowHeadersVisible = False
        Me.dtg_consulta.Size = New System.Drawing.Size(649, 350)
        Me.dtg_consulta.TabIndex = 1051
        '
        'col_guardar_con_ruta
        '
        Me.col_guardar_con_ruta.Frozen = True
        Me.col_guardar_con_ruta.HeaderText = ""
        Me.col_guardar_con_ruta.Image = Global.Spic.My.Resources.Resources.save_16
        Me.col_guardar_con_ruta.Name = "col_guardar_con_ruta"
        Me.col_guardar_con_ruta.Width = 5
        '
        'menStripDtg
        '
        Me.menStripDtg.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.menStripDtg.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.itemMail, Me.itemMasInfo, Me.VerStockToolStripMenuItem})
        Me.menStripDtg.Name = "ContextMenuStrip1"
        Me.menStripDtg.Size = New System.Drawing.Size(215, 70)
        '
        'itemMail
        '
        Me.itemMail.Image = Global.Spic.My.Resources.Resources.enviar
        Me.itemMail.Name = "itemMail"
        Me.itemMail.Size = New System.Drawing.Size(214, 22)
        Me.itemMail.Text = "Enviar para autorizaciòn "
        '
        'itemMasInfo
        '
        Me.itemMasInfo.Image = Global.Spic.My.Resources.Resources.buscar7
        Me.itemMasInfo.Name = "itemMasInfo"
        Me.itemMasInfo.Size = New System.Drawing.Size(214, 22)
        Me.itemMasInfo.Text = "Ver mas info"
        '
        'VerStockToolStripMenuItem
        '
        Me.VerStockToolStripMenuItem.Image = Global.Spic.My.Resources.Resources.buscar7
        Me.VerStockToolStripMenuItem.Name = "VerStockToolStripMenuItem"
        Me.VerStockToolStripMenuItem.Size = New System.Drawing.Size(214, 22)
        Me.VerStockToolStripMenuItem.Text = "Ver stock"
        '
        'tab_pen_sin_ruta
        '
        Me.tab_pen_sin_ruta.Controls.Add(Me.dtgSinRuta)
        Me.tab_pen_sin_ruta.Location = New System.Drawing.Point(4, 22)
        Me.tab_pen_sin_ruta.Name = "tab_pen_sin_ruta"
        Me.tab_pen_sin_ruta.Padding = New System.Windows.Forms.Padding(3)
        Me.tab_pen_sin_ruta.Size = New System.Drawing.Size(645, 354)
        Me.tab_pen_sin_ruta.TabIndex = 1
        Me.tab_pen_sin_ruta.Text = "Pendientes sin ruta"
        Me.tab_pen_sin_ruta.UseVisualStyleBackColor = True
        '
        'dtgSinRuta
        '
        Me.dtgSinRuta.AllowUserToAddRows = False
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.LightGray
        DataGridViewCellStyle4.NullValue = Nothing
        Me.dtgSinRuta.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
        Me.dtgSinRuta.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtgSinRuta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dtgSinRuta.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dtgSinRuta.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgSinRuta.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle12
        Me.dtgSinRuta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgSinRuta.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.col_guardar_sin_ruta})
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle13.Format = "N0"
        DataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtgSinRuta.DefaultCellStyle = DataGridViewCellStyle13
        Me.dtgSinRuta.Location = New System.Drawing.Point(0, 1)
        Me.dtgSinRuta.Name = "dtgSinRuta"
        Me.dtgSinRuta.RowHeadersVisible = False
        Me.dtgSinRuta.Size = New System.Drawing.Size(645, 353)
        Me.dtgSinRuta.TabIndex = 1052
        '
        'col_guardar_sin_ruta
        '
        Me.col_guardar_sin_ruta.Frozen = True
        Me.col_guardar_sin_ruta.HeaderText = ""
        Me.col_guardar_sin_ruta.Image = Global.Spic.My.Resources.Resources.save_16
        Me.col_guardar_sin_ruta.Name = "col_guardar_sin_ruta"
        Me.col_guardar_sin_ruta.Width = 5
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txt_vend_max)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txt_vend_min)
        Me.GroupBox1.Location = New System.Drawing.Point(9, 69)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(264, 46)
        Me.GroupBox1.TabIndex = 1077
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Vendedores"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(120, 22)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(10, 13)
        Me.Label7.TabIndex = 1062
        Me.Label7.Text = "-"
        '
        'txt_vend_max
        '
        Me.txt_vend_max.Location = New System.Drawing.Point(190, 19)
        Me.txt_vend_max.Name = "txt_vend_max"
        Me.txt_vend_max.Size = New System.Drawing.Size(63, 20)
        Me.txt_vend_max.TabIndex = 1061
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(5, 22)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(51, 13)
        Me.Label9.TabIndex = 1058
        Me.Label9.Text = "Inferior:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(130, 22)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(58, 13)
        Me.Label8.TabIndex = 1060
        Me.Label8.Text = "Superior:"
        '
        'txt_vend_min
        '
        Me.txt_vend_min.Location = New System.Drawing.Point(57, 19)
        Me.txt_vend_min.Name = "txt_vend_min"
        Me.txt_vend_min.Size = New System.Drawing.Size(63, 20)
        Me.txt_vend_min.TabIndex = 1059
        '
        'txt_cliente
        '
        Me.txt_cliente.BackColor = System.Drawing.Color.White
        Me.txt_cliente.Location = New System.Drawing.Point(334, 85)
        Me.txt_cliente.Name = "txt_cliente"
        Me.txt_cliente.ReadOnly = True
        Me.txt_cliente.Size = New System.Drawing.Size(330, 20)
        Me.txt_cliente.TabIndex = 1075
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(283, 87)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(50, 13)
        Me.Label4.TabIndex = 1074
        Me.Label4.Text = "Cliente:"
        '
        'txtNumero
        '
        Me.txtNumero.Location = New System.Drawing.Point(564, 50)
        Me.txtNumero.Name = "txtNumero"
        Me.txtNumero.Size = New System.Drawing.Size(100, 20)
        Me.txtNumero.TabIndex = 1073
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(508, 52)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 13)
        Me.Label3.TabIndex = 1072
        Me.Label3.Text = "Número:"
        '
        'txt_codigo
        '
        Me.txt_codigo.Location = New System.Drawing.Point(388, 49)
        Me.txt_codigo.Name = "txt_codigo"
        Me.txt_codigo.Size = New System.Drawing.Size(114, 20)
        Me.txt_codigo.TabIndex = 1071
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(337, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 13)
        Me.Label2.TabIndex = 1070
        Me.Label2.Text = "Código:"
        '
        'lbl_mes
        '
        Me.lbl_mes.AutoSize = True
        Me.lbl_mes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_mes.Location = New System.Drawing.Point(6, 51)
        Me.lbl_mes.Name = "lbl_mes"
        Me.lbl_mes.Size = New System.Drawing.Size(38, 13)
        Me.lbl_mes.TabIndex = 1069
        Me.lbl_mes.Text = "Ruta:"
        '
        'cbo_ruta
        '
        Me.cbo_ruta.FormattingEnabled = True
        Me.cbo_ruta.Items.AddRange(New Object() {"Enero ", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"})
        Me.cbo_ruta.Location = New System.Drawing.Point(48, 48)
        Me.cbo_ruta.Name = "cbo_ruta"
        Me.cbo_ruta.Size = New System.Drawing.Size(283, 21)
        Me.cbo_ruta.TabIndex = 1068
        Me.cbo_ruta.Text = "Seleccione"
        '
        'Toolbar1
        '
        Me.Toolbar1.AutoSize = False
        Me.Toolbar1.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.Toolbar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Toolbar1.ImageScalingSize = New System.Drawing.Size(23, 23)
        Me.Toolbar1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator2, Me.btn_salir, Me.btn_ppal, Me.ToolStripSeparator3, Me.btn_exportar, Me.btnActualizar})
        Me.Toolbar1.Location = New System.Drawing.Point(0, 0)
        Me.Toolbar1.Name = "Toolbar1"
        Me.Toolbar1.Size = New System.Drawing.Size(668, 34)
        Me.Toolbar1.TabIndex = 1067
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
        'btn_exportar
        '
        Me.btn_exportar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_exportar.Image = Global.Spic.My.Resources.Resources.excel
        Me.btn_exportar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_exportar.Name = "btn_exportar"
        Me.btn_exportar.Size = New System.Drawing.Size(27, 31)
        Me.btn_exportar.Text = "Graficar"
        Me.btn_exportar.ToolTipText = "Exportar a excel"
        '
        'btnActualizar
        '
        Me.btnActualizar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnActualizar.Image = Global.Spic.My.Resources.Resources.actualizar
        Me.btnActualizar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnActualizar.Name = "btnActualizar"
        Me.btnActualizar.Size = New System.Drawing.Size(27, 31)
        Me.btnActualizar.Text = "Actualizar"
        '
        'cboCal
        '
        Me.cboCal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboCal.Location = New System.Drawing.Point(404, 153)
        Me.cboCal.MaxDate = New Date(2013, 8, 1, 0, 0, 0, 0)
        Me.cboCal.Name = "cboCal"
        Me.cboCal.TabIndex = 1081
        Me.cboCal.Visible = False
        '
        'btn_cerrar_cal
        '
        Me.btn_cerrar_cal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_cerrar_cal.Location = New System.Drawing.Point(445, 114)
        Me.btn_cerrar_cal.Name = "btn_cerrar_cal"
        Me.btn_cerrar_cal.Size = New System.Drawing.Size(105, 23)
        Me.btn_cerrar_cal.TabIndex = 1082
        Me.btn_cerrar_cal.Text = "Ocultar calendario"
        Me.btn_cerrar_cal.UseVisualStyleBackColor = True
        Me.btn_cerrar_cal.Visible = False
        '
        'Frm_seg_pendientes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(668, 512)
        Me.Controls.Add(Me.btn_cerrar_cal)
        Me.Controls.Add(Me.cboCal)
        Me.Controls.Add(Me.group_clasificacion)
        Me.Controls.Add(Me.txt_estado_sin_ruta)
        Me.Controls.Add(Me.imgProc)
        Me.Controls.Add(Me.groupCliente)
        Me.Controls.Add(Me.tab1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txt_cliente)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtNumero)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txt_codigo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lbl_mes)
        Me.Controls.Add(Me.cbo_ruta)
        Me.Controls.Add(Me.Toolbar1)
        Me.Name = "Frm_seg_pendientes"
        Me.Text = "Seguimiento de pendientes"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.imgProc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.groupCliente.ResumeLayout(False)
        Me.groupCliente.PerformLayout()
        CType(Me.dtg_clientes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.group_clasificacion.ResumeLayout(False)
        Me.group_clasificacion.PerformLayout()
        CType(Me.dtg_modif_clas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtg_asignar_clas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tab1.ResumeLayout(False)
        Me.tab_pen_con_ruta.ResumeLayout(False)
        CType(Me.dtg_consulta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.menStripDtg.ResumeLayout(False)
        Me.tab_pen_sin_ruta.ResumeLayout(False)
        CType(Me.dtgSinRuta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Toolbar1.ResumeLayout(False)
        Me.Toolbar1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txt_estado_sin_ruta As System.Windows.Forms.TextBox
    Friend WithEvents imgProc As System.Windows.Forms.PictureBox
    Friend WithEvents groupCliente As System.Windows.Forms.GroupBox
    Friend WithEvents btn_cerrar As System.Windows.Forms.Button
    Friend WithEvents txt_nombres As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtg_clientes As System.Windows.Forms.DataGridView
    Friend WithEvents colOk As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents txt_nit As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tab1 As System.Windows.Forms.TabControl
    Friend WithEvents tab_pen_con_ruta As System.Windows.Forms.TabPage
    Friend WithEvents dtg_consulta As System.Windows.Forms.DataGridView
    Friend WithEvents tab_pen_sin_ruta As System.Windows.Forms.TabPage
    Friend WithEvents dtgSinRuta As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txt_vend_max As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txt_vend_min As System.Windows.Forms.TextBox
    Friend WithEvents txt_cliente As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtNumero As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txt_codigo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lbl_mes As System.Windows.Forms.Label
    Friend WithEvents cbo_ruta As System.Windows.Forms.ComboBox
    Friend WithEvents Toolbar1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btn_salir As System.Windows.Forms.ToolStripButton
    Friend WithEvents btn_ppal As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btn_exportar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnActualizar As System.Windows.Forms.ToolStripButton
    Friend WithEvents group_clasificacion As System.Windows.Forms.GroupBox
    Friend WithEvents btn_cerrar_clas As System.Windows.Forms.Button
    Friend WithEvents dtg_asignar_clas As System.Windows.Forms.DataGridView
    Friend WithEvents col_ok_clas As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dtg_modif_clas As System.Windows.Forms.DataGridView
    Friend WithEvents col_borrar_clas As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents col_id_mod_clas As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col_desc_mod_clas As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cboCal As System.Windows.Forms.MonthCalendar
    Friend WithEvents btn_cerrar_cal As System.Windows.Forms.Button
    Friend WithEvents col_guardar_con_ruta As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents col_guardar_sin_ruta As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents menStripDtg As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents itemMail As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents itemMasInfo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VerStockToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
