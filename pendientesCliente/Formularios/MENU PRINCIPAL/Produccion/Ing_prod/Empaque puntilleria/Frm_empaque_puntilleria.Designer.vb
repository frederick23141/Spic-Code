<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_empaque_puntilleria
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_empaque_puntilleria))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
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
        Me.groupCodigo = New System.Windows.Forms.GroupBox()
        Me.btnCerrarEditResp = New System.Windows.Forms.Button()
        Me.txtDesc = New System.Windows.Forms.TextBox()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dtgCodigo = New System.Windows.Forms.DataGridView()
        Me.colOk = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.groupFecha = New System.Windows.Forms.GroupBox()
        Me.btn_ok_fec_hora = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btn_cerrar = New System.Windows.Forms.Button()
        Me.cbo_min = New System.Windows.Forms.ComboBox()
        Me.cboCal = New System.Windows.Forms.MonthCalendar()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbo_hora = New System.Windows.Forms.ComboBox()
        Me.col_add = New System.Windows.Forms.DataGridViewImageColumn()
        Me.btn_borrar = New System.Windows.Forms.DataGridViewImageColumn()
        Me.col_chk_granel = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colCodigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDescCodigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txt_cant_cartones = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txt_hora_ini = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txt_hora_fin = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txt_esp_cartones = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txt_porc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Toolbar1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dtg_planilla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.groupCodigo.SuspendLayout()
        CType(Me.dtgCodigo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.groupFecha.SuspendLayout()
        Me.SuspendLayout()
        '
        'Toolbar1
        '
        Me.Toolbar1.AutoSize = False
        Me.Toolbar1.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.Toolbar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Toolbar1.ImageScalingSize = New System.Drawing.Size(23, 23)
        Me.Toolbar1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator2, Me.ToolStripButton1, Me.ToolStripButton2, Me.ToolStripSeparator3, Me.btnNuevo, Me.btnBuscar, Me.btnGuardar, Me.btnContCambios})
        Me.Toolbar1.Location = New System.Drawing.Point(0, 0)
        Me.Toolbar1.Name = "Toolbar1"
        Me.Toolbar1.Size = New System.Drawing.Size(769, 33)
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
        Me.GroupBox1.Controls.Add(Me.Label28)
        Me.GroupBox1.Controls.Add(Me.chk_todos)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cbo_fecha)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.cbo_turno)
        Me.GroupBox1.Controls.Add(Me.cbo_operario)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 36)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(421, 112)
        Me.GroupBox1.TabIndex = 1026
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Ingreso de datos"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(49, 37)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(37, 13)
        Me.Label28.TabIndex = 1036
        Me.Label28.Text = "Todos"
        '
        'chk_todos
        '
        Me.chk_todos.AutoSize = True
        Me.chk_todos.Location = New System.Drawing.Point(62, 51)
        Me.chk_todos.Name = "chk_todos"
        Me.chk_todos.Size = New System.Drawing.Size(15, 14)
        Me.chk_todos.TabIndex = 1035
        Me.chk_todos.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(40, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 57
        Me.Label1.Text = "Fecha:"
        '
        'cbo_fecha
        '
        Me.cbo_fecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.cbo_fecha.Location = New System.Drawing.Point(86, 17)
        Me.cbo_fecha.Name = "cbo_fecha"
        Me.cbo_fecha.Size = New System.Drawing.Size(332, 20)
        Me.cbo_fecha.TabIndex = 1
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(2, 49)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(59, 13)
        Me.Label8.TabIndex = 117
        Me.Label8.Text = "Operario:"
        '
        'cbo_turno
        '
        Me.cbo_turno.FormattingEnabled = True
        Me.cbo_turno.Location = New System.Drawing.Point(85, 78)
        Me.cbo_turno.Name = "cbo_turno"
        Me.cbo_turno.Size = New System.Drawing.Size(333, 21)
        Me.cbo_turno.TabIndex = 4
        Me.cbo_turno.Text = "Seleccione"
        '
        'cbo_operario
        '
        Me.cbo_operario.FormattingEnabled = True
        Me.cbo_operario.Location = New System.Drawing.Point(85, 48)
        Me.cbo_operario.Name = "cbo_operario"
        Me.cbo_operario.Size = New System.Drawing.Size(333, 21)
        Me.cbo_operario.TabIndex = 2
        Me.cbo_operario.Text = "Seleccione"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(33, 81)
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
        Me.dtg_planilla.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.col_add, Me.btn_borrar, Me.col_chk_granel, Me.colCodigo, Me.colDescCodigo, Me.txt_cant_cartones, Me.txt_hora_ini, Me.txt_hora_fin, Me.txt_esp_cartones, Me.txt_porc})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.Format = "N0"
        DataGridViewCellStyle5.NullValue = Nothing
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtg_planilla.DefaultCellStyle = DataGridViewCellStyle5
        Me.dtg_planilla.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dtg_planilla.Location = New System.Drawing.Point(6, 16)
        Me.dtg_planilla.Name = "dtg_planilla"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtg_planilla.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dtg_planilla.RowHeadersVisible = False
        Me.dtg_planilla.Size = New System.Drawing.Size(746, 272)
        Me.dtg_planilla.TabIndex = 1024
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.dtg_planilla)
        Me.GroupBox2.Location = New System.Drawing.Point(3, 154)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(762, 294)
        Me.GroupBox2.TabIndex = 1028
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Planilla"
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
        Me.groupCodigo.Location = New System.Drawing.Point(126, 226)
        Me.groupCodigo.Name = "groupCodigo"
        Me.groupCodigo.Size = New System.Drawing.Size(555, 206)
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
        Me.btnCerrarEditResp.Location = New System.Drawing.Point(529, 6)
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
        Me.dtgCodigo.Size = New System.Drawing.Size(543, 160)
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
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(424, 132)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(340, 13)
        Me.Label2.TabIndex = 1037
        Me.Label2.Text = "Nota: la hora inicial y final se debe ingresar en formato militar (24 horas)"
        '
        'groupFecha
        '
        Me.groupFecha.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.groupFecha.Controls.Add(Me.btn_ok_fec_hora)
        Me.groupFecha.Controls.Add(Me.Label4)
        Me.groupFecha.Controls.Add(Me.btn_cerrar)
        Me.groupFecha.Controls.Add(Me.cbo_min)
        Me.groupFecha.Controls.Add(Me.cboCal)
        Me.groupFecha.Controls.Add(Me.Label3)
        Me.groupFecha.Controls.Add(Me.cbo_hora)
        Me.groupFecha.Location = New System.Drawing.Point(319, 189)
        Me.groupFecha.Name = "groupFecha"
        Me.groupFecha.Size = New System.Drawing.Size(272, 254)
        Me.groupFecha.TabIndex = 1084
        Me.groupFecha.TabStop = False
        Me.groupFecha.Text = "Seleccione fecha"
        Me.groupFecha.Visible = False
        '
        'btn_ok_fec_hora
        '
        Me.btn_ok_fec_hora.Image = Global.Spic.My.Resources.Resources.ok3
        Me.btn_ok_fec_hora.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_ok_fec_hora.Location = New System.Drawing.Point(104, 221)
        Me.btn_ok_fec_hora.Name = "btn_ok_fec_hora"
        Me.btn_ok_fec_hora.Size = New System.Drawing.Size(75, 23)
        Me.btn_ok_fec_hora.TabIndex = 1089
        Me.btn_ok_fec_hora.Text = "OK"
        Me.btn_ok_fec_hora.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(133, 198)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 13)
        Me.Label4.TabIndex = 1088
        Me.Label4.Text = "Minuto:"
        '
        'btn_cerrar
        '
        Me.btn_cerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_cerrar.ForeColor = System.Drawing.Color.Red
        Me.btn_cerrar.Location = New System.Drawing.Point(235, 0)
        Me.btn_cerrar.Name = "btn_cerrar"
        Me.btn_cerrar.Size = New System.Drawing.Size(37, 23)
        Me.btn_cerrar.TabIndex = 1064
        Me.btn_cerrar.Text = "X"
        Me.btn_cerrar.UseVisualStyleBackColor = True
        '
        'cbo_min
        '
        Me.cbo_min.FormattingEnabled = True
        Me.cbo_min.Items.AddRange(New Object() {"00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "51", "52", "53", "54", "55", "56", "57", "58", "59", "", ""})
        Me.cbo_min.Location = New System.Drawing.Point(186, 195)
        Me.cbo_min.Name = "cbo_min"
        Me.cbo_min.Size = New System.Drawing.Size(74, 21)
        Me.cbo_min.TabIndex = 1087
        Me.cbo_min.Text = "00"
        '
        'cboCal
        '
        Me.cboCal.Location = New System.Drawing.Point(12, 28)
        Me.cboCal.MaxDate = New Date(2100, 8, 1, 0, 0, 0, 0)
        Me.cboCal.Name = "cboCal"
        Me.cboCal.TabIndex = 1057
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(15, 197)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 13)
        Me.Label3.TabIndex = 1086
        Me.Label3.Text = "Hora:"
        '
        'cbo_hora
        '
        Me.cbo_hora.FormattingEnabled = True
        Me.cbo_hora.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24"})
        Me.cbo_hora.Location = New System.Drawing.Point(59, 194)
        Me.cbo_hora.Name = "cbo_hora"
        Me.cbo_hora.Size = New System.Drawing.Size(74, 21)
        Me.cbo_hora.TabIndex = 1085
        Me.cbo_hora.Text = "6"
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
        'col_chk_granel
        '
        Me.col_chk_granel.HeaderText = "granel"
        Me.col_chk_granel.Name = "col_chk_granel"
        Me.col_chk_granel.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.col_chk_granel.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.col_chk_granel.Width = 61
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
        'txt_cant_cartones
        '
        Me.txt_cant_cartones.HeaderText = "Cantidad"
        Me.txt_cant_cartones.Name = "txt_cant_cartones"
        Me.txt_cant_cartones.Width = 74
        '
        'txt_hora_ini
        '
        Me.txt_hora_ini.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.txt_hora_ini.HeaderText = "Hora_ini"
        Me.txt_hora_ini.Name = "txt_hora_ini"
        Me.txt_hora_ini.ReadOnly = True
        Me.txt_hora_ini.Width = 71
        '
        'txt_hora_fin
        '
        Me.txt_hora_fin.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.txt_hora_fin.HeaderText = "Hora_fin"
        Me.txt_hora_fin.Name = "txt_hora_fin"
        Me.txt_hora_fin.ReadOnly = True
        Me.txt_hora_fin.Width = 72
        '
        'txt_esp_cartones
        '
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.Gainsboro
        Me.txt_esp_cartones.DefaultCellStyle = DataGridViewCellStyle3
        Me.txt_esp_cartones.HeaderText = "Esperado"
        Me.txt_esp_cartones.Name = "txt_esp_cartones"
        Me.txt_esp_cartones.ReadOnly = True
        Me.txt_esp_cartones.Width = 77
        '
        'txt_porc
        '
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle4.Format = "N1"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.txt_porc.DefaultCellStyle = DataGridViewCellStyle4
        Me.txt_porc.HeaderText = "% Efic"
        Me.txt_porc.Name = "txt_porc"
        Me.txt_porc.ReadOnly = True
        Me.txt_porc.Width = 61
        '
        'Frm_empaque_puntilleria
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(769, 453)
        Me.Controls.Add(Me.groupFecha)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.groupCodigo)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Toolbar1)
        Me.Name = "Frm_empaque_puntilleria"
        Me.Text = "Empaque de puntilleria"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Toolbar1.ResumeLayout(False)
        Me.Toolbar1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dtg_planilla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.groupCodigo.ResumeLayout(False)
        Me.groupCodigo.PerformLayout()
        CType(Me.dtgCodigo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.groupFecha.ResumeLayout(False)
        Me.groupFecha.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

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
    Friend WithEvents btnContCambios As System.Windows.Forms.ToolStripButton
    Friend WithEvents groupCodigo As System.Windows.Forms.GroupBox
    Friend WithEvents btnCerrarEditResp As System.Windows.Forms.Button
    Friend WithEvents txtDesc As System.Windows.Forms.TextBox
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents dtgCodigo As System.Windows.Forms.DataGridView
    Friend WithEvents colOk As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents groupFecha As System.Windows.Forms.GroupBox
    Friend WithEvents btn_cerrar As System.Windows.Forms.Button
    Friend WithEvents cboCal As System.Windows.Forms.MonthCalendar
    Friend WithEvents btn_ok_fec_hora As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cbo_min As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cbo_hora As System.Windows.Forms.ComboBox
    Friend WithEvents col_add As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents btn_borrar As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents col_chk_granel As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colCodigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDescCodigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txt_cant_cartones As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txt_hora_ini As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txt_hora_fin As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txt_esp_cartones As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txt_porc As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
