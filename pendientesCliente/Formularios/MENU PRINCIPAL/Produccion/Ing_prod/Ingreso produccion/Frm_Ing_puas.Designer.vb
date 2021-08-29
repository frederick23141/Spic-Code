<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Ing_puas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Ing_puas))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Toolbar1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnNuevo = New System.Windows.Forms.ToolStripButton()
        Me.btnBuscar = New System.Windows.Forms.ToolStripButton()
        Me.btnGuardar = New System.Windows.Forms.ToolStripButton()
        Me.btnContCambios = New System.Windows.Forms.ToolStripButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cbo_tipo_puas = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.chk_todos = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbo_fecha = New System.Windows.Forms.DateTimePicker()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cbo_turno = New System.Windows.Forms.ComboBox()
        Me.cbo_operario = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dtg_planilla = New System.Windows.Forms.DataGridView()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.groupCodigo = New System.Windows.Forms.GroupBox()
        Me.btnCerrarEditResp = New System.Windows.Forms.Button()
        Me.txtDesc = New System.Windows.Forms.TextBox()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dtgCodigo = New System.Windows.Forms.DataGridView()
        Me.colOk = New System.Windows.Forms.DataGridViewImageColumn()
        Me.col_add = New System.Windows.Forms.DataGridViewImageColumn()
        Me.btn_borrar = New System.Windows.Forms.DataGridViewImageColumn()
        Me.cbo_maquina = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.cbo_producto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCodigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDescCodigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txt_cant = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txt_hodometro = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txt_kilos = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txt_esp_royos = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txt_esp_kil = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txt_porc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txt_t_sin_just = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txt_p1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txt_p3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txt_p4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txt_p5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txt_p6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txt_p7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txt_p8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txt_p9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txt_p11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txt_p12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txt_p13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Toolbar1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dtg_planilla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.groupCodigo.SuspendLayout()
        CType(Me.dtgCodigo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Toolbar1
        '
        Me.Toolbar1.AutoSize = False
        Me.Toolbar1.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.Toolbar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Toolbar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Toolbar1.ImageScalingSize = New System.Drawing.Size(23, 23)
        Me.Toolbar1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator2, Me.ToolStripButton1, Me.ToolStripButton2, Me.ToolStripSeparator3, Me.btnNuevo, Me.btnBuscar, Me.btnGuardar, Me.btnContCambios})
        Me.Toolbar1.Location = New System.Drawing.Point(0, 0)
        Me.Toolbar1.Name = "Toolbar1"
        Me.Toolbar1.Size = New System.Drawing.Size(780, 33)
        Me.Toolbar1.TabIndex = 1025
        Me.Toolbar1.Text = "ToolStrip1"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 33)
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = Global.Spic.My.Resources.Resources._1349388328_door_in
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(27, 30)
        Me.ToolStripButton1.Text = "ToolStripButton1"
        Me.ToolStripButton1.ToolTipText = "Salir"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton2.Image = Global.Spic.My.Resources.Resources.ppal3
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(27, 30)
        Me.ToolStripButton2.Text = "ToolStripButton2"
        Me.ToolStripButton2.ToolTipText = "Menú principal"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 33)
        '
        'btnNuevo
        '
        Me.btnNuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnNuevo.Image = CType(resources.GetObject("btnNuevo.Image"), System.Drawing.Image)
        Me.btnNuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Padding = New System.Windows.Forms.Padding(0, 0, 8, 0)
        Me.btnNuevo.Size = New System.Drawing.Size(35, 30)
        Me.btnNuevo.Text = "Nuevo"
        '
        'btnBuscar
        '
        Me.btnBuscar.AutoSize = False
        Me.btnBuscar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(35, 39)
        Me.btnBuscar.ToolTipText = "Consultar"
        '
        'btnGuardar
        '
        Me.btnGuardar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Padding = New System.Windows.Forms.Padding(0, 0, 8, 0)
        Me.btnGuardar.Size = New System.Drawing.Size(35, 30)
        Me.btnGuardar.Text = "Guardar"
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
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cbo_tipo_puas)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label28)
        Me.GroupBox1.Controls.Add(Me.chk_todos)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cbo_fecha)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.cbo_turno)
        Me.GroupBox1.Controls.Add(Me.cbo_operario)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 36)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(441, 149)
        Me.GroupBox1.TabIndex = 1026
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Ingreso de datos"
        '
        'cbo_tipo_puas
        '
        Me.cbo_tipo_puas.FormattingEnabled = True
        Me.cbo_tipo_puas.Location = New System.Drawing.Point(86, 24)
        Me.cbo_tipo_puas.Name = "cbo_tipo_puas"
        Me.cbo_tipo_puas.Size = New System.Drawing.Size(348, 21)
        Me.cbo_tipo_puas.TabIndex = 1039
        Me.cbo_tipo_puas.Text = "Seleccione"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(1, 27)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(85, 13)
        Me.Label2.TabIndex = 1038
        Me.Label2.Text = "Tipo de púas:"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(49, 80)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(37, 13)
        Me.Label28.TabIndex = 1036
        Me.Label28.Text = "Todos"
        '
        'chk_todos
        '
        Me.chk_todos.AutoSize = True
        Me.chk_todos.Location = New System.Drawing.Point(62, 94)
        Me.chk_todos.Name = "chk_todos"
        Me.chk_todos.Size = New System.Drawing.Size(15, 14)
        Me.chk_todos.TabIndex = 1035
        Me.chk_todos.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(40, 66)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 57
        Me.Label1.Text = "Fecha:"
        '
        'cbo_fecha
        '
        Me.cbo_fecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.cbo_fecha.Location = New System.Drawing.Point(86, 60)
        Me.cbo_fecha.Name = "cbo_fecha"
        Me.cbo_fecha.Size = New System.Drawing.Size(347, 20)
        Me.cbo_fecha.TabIndex = 1
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(2, 92)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(59, 13)
        Me.Label8.TabIndex = 117
        Me.Label8.Text = "Operario:"
        '
        'cbo_turno
        '
        Me.cbo_turno.FormattingEnabled = True
        Me.cbo_turno.Location = New System.Drawing.Point(85, 121)
        Me.cbo_turno.Name = "cbo_turno"
        Me.cbo_turno.Size = New System.Drawing.Size(348, 21)
        Me.cbo_turno.TabIndex = 4
        Me.cbo_turno.Text = "Seleccione"
        '
        'cbo_operario
        '
        Me.cbo_operario.FormattingEnabled = True
        Me.cbo_operario.Location = New System.Drawing.Point(85, 91)
        Me.cbo_operario.Name = "cbo_operario"
        Me.cbo_operario.Size = New System.Drawing.Size(348, 21)
        Me.cbo_operario.TabIndex = 2
        Me.cbo_operario.Text = "Seleccione"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(33, 124)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(44, 13)
        Me.Label5.TabIndex = 120
        Me.Label5.Text = "Turno:"
        '
        'dtg_planilla
        '
        Me.dtg_planilla.AllowUserToAddRows = False
        Me.dtg_planilla.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro
        Me.dtg_planilla.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dtg_planilla.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtg_planilla.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader
        Me.dtg_planilla.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dtg_planilla.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dtg_planilla.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtg_planilla.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dtg_planilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtg_planilla.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.col_add, Me.btn_borrar, Me.cbo_maquina, Me.cbo_producto, Me.colCodigo, Me.colDescCodigo, Me.txt_cant, Me.txt_hodometro, Me.txt_kilos, Me.txt_esp_royos, Me.txt_esp_kil, Me.txt_porc, Me.txt_t_sin_just, Me.txt_p1, Me.txt_p3, Me.txt_p4, Me.txt_p5, Me.txt_p6, Me.txt_p7, Me.txt_p8, Me.txt_p9, Me.txt_p11, Me.txt_p12, Me.txt_p13})
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.Format = "N0"
        DataGridViewCellStyle8.NullValue = Nothing
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtg_planilla.DefaultCellStyle = DataGridViewCellStyle8
        Me.dtg_planilla.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dtg_planilla.Location = New System.Drawing.Point(4, 16)
        Me.dtg_planilla.Name = "dtg_planilla"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtg_planilla.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.dtg_planilla.RowHeadersVisible = False
        Me.dtg_planilla.Size = New System.Drawing.Size(742, 237)
        Me.dtg_planilla.TabIndex = 1024
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.dtg_planilla)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 189)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(756, 259)
        Me.GroupBox2.TabIndex = 1028
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Planilla"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = Global.Spic.My.Resources.Resources.puas1
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.Image = Global.Spic.My.Resources.Resources.puas2
        Me.PictureBox1.Location = New System.Drawing.Point(464, 42)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(304, 143)
        Me.PictureBox1.TabIndex = 1038
        Me.PictureBox1.TabStop = False
        '
        'groupCodigo
        '
        Me.groupCodigo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.groupCodigo.Controls.Add(Me.btnCerrarEditResp)
        Me.groupCodigo.Controls.Add(Me.txtDesc)
        Me.groupCodigo.Controls.Add(Me.txtCodigo)
        Me.groupCodigo.Controls.Add(Me.Label6)
        Me.groupCodigo.Controls.Add(Me.Label7)
        Me.groupCodigo.Controls.Add(Me.dtgCodigo)
        Me.groupCodigo.Location = New System.Drawing.Point(126, 217)
        Me.groupCodigo.Name = "groupCodigo"
        Me.groupCodigo.Size = New System.Drawing.Size(566, 206)
        Me.groupCodigo.TabIndex = 1055
        Me.groupCodigo.TabStop = False
        Me.groupCodigo.Text = "Códigos"
        Me.groupCodigo.Visible = False
        '
        'btnCerrarEditResp
        '
        Me.btnCerrarEditResp.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCerrarEditResp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrarEditResp.ForeColor = System.Drawing.Color.Red
        Me.btnCerrarEditResp.Location = New System.Drawing.Point(540, 6)
        Me.btnCerrarEditResp.Name = "btnCerrarEditResp"
        Me.btnCerrarEditResp.Size = New System.Drawing.Size(26, 23)
        Me.btnCerrarEditResp.TabIndex = 1045
        Me.btnCerrarEditResp.Text = "X"
        Me.btnCerrarEditResp.UseVisualStyleBackColor = True
        '
        'txtDesc
        '
        Me.txtDesc.Location = New System.Drawing.Point(309, 13)
        Me.txtDesc.Name = "txtDesc"
        Me.txtDesc.Size = New System.Drawing.Size(216, 20)
        Me.txtDesc.TabIndex = 1044
        '
        'txtCodigo
        '
        Me.txtCodigo.Location = New System.Drawing.Point(62, 13)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(157, 20)
        Me.txtCodigo.TabIndex = 1043
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(225, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(78, 13)
        Me.Label6.TabIndex = 1042
        Me.Label6.Text = "Descripción:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(6, 16)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(50, 13)
        Me.Label7.TabIndex = 1041
        Me.Label7.Text = "Código:"
        '
        'dtgCodigo
        '
        Me.dtgCodigo.AllowUserToAddRows = False
        Me.dtgCodigo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtgCodigo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dtgCodigo.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dtgCodigo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgCodigo.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colOk})
        Me.dtgCodigo.Location = New System.Drawing.Point(6, 40)
        Me.dtgCodigo.Name = "dtgCodigo"
        Me.dtgCodigo.ReadOnly = True
        Me.dtgCodigo.RowHeadersVisible = False
        Me.dtgCodigo.Size = New System.Drawing.Size(554, 160)
        Me.dtgCodigo.TabIndex = 0
        '
        'colOk
        '
        Me.colOk.Frozen = True
        Me.colOk.HeaderText = ""
        Me.colOk.Image = Global.Spic.My.Resources.Resources.ok3
        Me.colOk.Name = "colOk"
        Me.colOk.ReadOnly = True
        Me.colOk.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colOk.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colOk.Width = 19
        '
        'col_add
        '
        Me.col_add.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.col_add.HeaderText = ""
        Me.col_add.Image = Global.Spic.My.Resources.Resources.nuevo
        Me.col_add.Name = "col_add"
        Me.col_add.Width = 5
        '
        'btn_borrar
        '
        Me.btn_borrar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.btn_borrar.HeaderText = ""
        Me.btn_borrar.Image = Global.Spic.My.Resources.Resources._1371750041_14125
        Me.btn_borrar.Name = "btn_borrar"
        Me.btn_borrar.Width = 5
        '
        'cbo_maquina
        '
        Me.cbo_maquina.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.cbo_maquina.HeaderText = "Maquina"
        Me.cbo_maquina.Name = "cbo_maquina"
        Me.cbo_maquina.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.cbo_maquina.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.cbo_maquina.Width = 94
        '
        'cbo_producto
        '
        Me.cbo_producto.FillWeight = 200.0!
        Me.cbo_producto.HeaderText = "Ref producto"
        Me.cbo_producto.Name = "cbo_producto"
        Me.cbo_producto.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.cbo_producto.Width = 94
        '
        'colCodigo
        '
        Me.colCodigo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colCodigo.HeaderText = "Código"
        Me.colCodigo.Name = "colCodigo"
        Me.colCodigo.ReadOnly = True
        Me.colCodigo.Width = 65
        '
        'colDescCodigo
        '
        Me.colDescCodigo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colDescCodigo.HeaderText = "Descripción"
        Me.colDescCodigo.Name = "colDescCodigo"
        Me.colDescCodigo.ReadOnly = True
        Me.colDescCodigo.Width = 88
        '
        'txt_cant
        '
        Me.txt_cant.HeaderText = "Cantidad"
        Me.txt_cant.Name = "txt_cant"
        Me.txt_cant.Width = 74
        '
        'txt_hodometro
        '
        Me.txt_hodometro.HeaderText = "Horometro"
        Me.txt_hodometro.Name = "txt_hodometro"
        Me.txt_hodometro.Width = 81
        '
        'txt_kilos
        '
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.Gainsboro
        Me.txt_kilos.DefaultCellStyle = DataGridViewCellStyle3
        Me.txt_kilos.HeaderText = "Peso(kg)"
        Me.txt_kilos.Name = "txt_kilos"
        Me.txt_kilos.ReadOnly = True
        Me.txt_kilos.Width = 74
        '
        'txt_esp_royos
        '
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle4.Format = "N0"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.txt_esp_royos.DefaultCellStyle = DataGridViewCellStyle4
        Me.txt_esp_royos.HeaderText = "Esp_royos"
        Me.txt_esp_royos.Name = "txt_esp_royos"
        Me.txt_esp_royos.ReadOnly = True
        Me.txt_esp_royos.Width = 81
        '
        'txt_esp_kil
        '
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.Gainsboro
        Me.txt_esp_kil.DefaultCellStyle = DataGridViewCellStyle5
        Me.txt_esp_kil.HeaderText = "Esp_kil"
        Me.txt_esp_kil.Name = "txt_esp_kil"
        Me.txt_esp_kil.ReadOnly = True
        Me.txt_esp_kil.Width = 66
        '
        'txt_porc
        '
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle6.Format = "N1"
        DataGridViewCellStyle6.NullValue = Nothing
        Me.txt_porc.DefaultCellStyle = DataGridViewCellStyle6
        Me.txt_porc.HeaderText = "% efic"
        Me.txt_porc.Name = "txt_porc"
        Me.txt_porc.ReadOnly = True
        Me.txt_porc.Width = 60
        '
        'txt_t_sin_just
        '
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle7.Format = "N0"
        DataGridViewCellStyle7.NullValue = Nothing
        Me.txt_t_sin_just.DefaultCellStyle = DataGridViewCellStyle7
        Me.txt_t_sin_just.HeaderText = "T_Sin _Just"
        Me.txt_t_sin_just.Name = "txt_t_sin_just"
        Me.txt_t_sin_just.Width = 88
        '
        'txt_p1
        '
        Me.txt_p1.HeaderText = "P1"
        Me.txt_p1.Name = "txt_p1"
        Me.txt_p1.Width = 45
        '
        'txt_p3
        '
        Me.txt_p3.HeaderText = "P3"
        Me.txt_p3.Name = "txt_p3"
        Me.txt_p3.Width = 45
        '
        'txt_p4
        '
        Me.txt_p4.HeaderText = "P4"
        Me.txt_p4.Name = "txt_p4"
        Me.txt_p4.Width = 45
        '
        'txt_p5
        '
        Me.txt_p5.HeaderText = "P5"
        Me.txt_p5.Name = "txt_p5"
        Me.txt_p5.Width = 45
        '
        'txt_p6
        '
        Me.txt_p6.HeaderText = "P6"
        Me.txt_p6.Name = "txt_p6"
        Me.txt_p6.Width = 45
        '
        'txt_p7
        '
        Me.txt_p7.HeaderText = "P7"
        Me.txt_p7.Name = "txt_p7"
        Me.txt_p7.Width = 45
        '
        'txt_p8
        '
        Me.txt_p8.HeaderText = "P8"
        Me.txt_p8.Name = "txt_p8"
        Me.txt_p8.Width = 45
        '
        'txt_p9
        '
        Me.txt_p9.HeaderText = "P9"
        Me.txt_p9.Name = "txt_p9"
        Me.txt_p9.Width = 45
        '
        'txt_p11
        '
        Me.txt_p11.HeaderText = "P11"
        Me.txt_p11.Name = "txt_p11"
        Me.txt_p11.Width = 51
        '
        'txt_p12
        '
        Me.txt_p12.HeaderText = "P12"
        Me.txt_p12.Name = "txt_p12"
        Me.txt_p12.Width = 51
        '
        'txt_p13
        '
        Me.txt_p13.HeaderText = "P13"
        Me.txt_p13.Name = "txt_p13"
        Me.txt_p13.Width = 51
        '
        'Frm_Ing_puas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(780, 453)
        Me.Controls.Add(Me.groupCodigo)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Toolbar1)
        Me.Name = "Frm_Ing_puas"
        Me.Text = "Púas"
        Me.Toolbar1.ResumeLayout(False)
        Me.Toolbar1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dtg_planilla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.groupCodigo.ResumeLayout(False)
        Me.groupCodigo.PerformLayout()
        CType(Me.dtgCodigo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Toolbar1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnBuscar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents chk_todos As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbo_fecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cbo_turno As System.Windows.Forms.ComboBox
    Friend WithEvents cbo_operario As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dtg_planilla As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents btnContCambios As System.Windows.Forms.ToolStripButton
    Friend WithEvents cbo_tipo_puas As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents groupCodigo As System.Windows.Forms.GroupBox
    Friend WithEvents btnCerrarEditResp As System.Windows.Forms.Button
    Friend WithEvents txtDesc As System.Windows.Forms.TextBox
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents dtgCodigo As System.Windows.Forms.DataGridView
    Friend WithEvents colOk As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents col_add As DataGridViewImageColumn
    Friend WithEvents btn_borrar As DataGridViewImageColumn
    Friend WithEvents cbo_maquina As DataGridViewComboBoxColumn
    Friend WithEvents cbo_producto As DataGridViewTextBoxColumn
    Friend WithEvents colCodigo As DataGridViewTextBoxColumn
    Friend WithEvents colDescCodigo As DataGridViewTextBoxColumn
    Friend WithEvents txt_cant As DataGridViewTextBoxColumn
    Friend WithEvents txt_hodometro As DataGridViewTextBoxColumn
    Friend WithEvents txt_kilos As DataGridViewTextBoxColumn
    Friend WithEvents txt_esp_royos As DataGridViewTextBoxColumn
    Friend WithEvents txt_esp_kil As DataGridViewTextBoxColumn
    Friend WithEvents txt_porc As DataGridViewTextBoxColumn
    Friend WithEvents txt_t_sin_just As DataGridViewTextBoxColumn
    Friend WithEvents txt_p1 As DataGridViewTextBoxColumn
    Friend WithEvents txt_p3 As DataGridViewTextBoxColumn
    Friend WithEvents txt_p4 As DataGridViewTextBoxColumn
    Friend WithEvents txt_p5 As DataGridViewTextBoxColumn
    Friend WithEvents txt_p6 As DataGridViewTextBoxColumn
    Friend WithEvents txt_p7 As DataGridViewTextBoxColumn
    Friend WithEvents txt_p8 As DataGridViewTextBoxColumn
    Friend WithEvents txt_p9 As DataGridViewTextBoxColumn
    Friend WithEvents txt_p11 As DataGridViewTextBoxColumn
    Friend WithEvents txt_p12 As DataGridViewTextBoxColumn
    Friend WithEvents txt_p13 As DataGridViewTextBoxColumn
End Class
