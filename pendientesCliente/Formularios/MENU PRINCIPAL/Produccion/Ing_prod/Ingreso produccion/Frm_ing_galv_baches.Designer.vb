<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_ing_galv_baches
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FRM_ing_galv_baches))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Toolbar1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnNuevo = New System.Windows.Forms.ToolStripButton()
        Me.btnBuscar = New System.Windows.Forms.ToolStripButton()
        Me.btnGuardar = New System.Windows.Forms.ToolStripButton()
        Me.btnContCambios = New System.Windows.Forms.ToolStripButton()
        Me.btn_transaccionar = New System.Windows.Forms.ToolStripButton()
        Me.dtgVer = New System.Windows.Forms.DataGridView()
        Me.btnEliminar = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Operario = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Turno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Seccion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Grupo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Kilo_Prod = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Horas_Trabajadas = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.STANDAR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cboOperario = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.chkTodos = New System.Windows.Forms.CheckBox()
        Me.lblNom = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.txtTotalProd = New System.Windows.Forms.TextBox()
        Me.txtTotalParos = New System.Windows.Forms.TextBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lblLimSup = New System.Windows.Forms.Label()
        Me.lblLimInf = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lblProdGrupo = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.lblProdSeccion = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.lblParosAcum = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.lblTiempoPro = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtKilos = New System.Windows.Forms.TextBox()
        Me.cboTurno = New System.Windows.Forms.ComboBox()
        Me.cboGrupo = New System.Windows.Forms.ComboBox()
        Me.cboLeva = New System.Windows.Forms.ComboBox()
        Me.dtFechaActual = New System.Windows.Forms.DateTimePicker()
        Me.Toolbar1.SuspendLayout()
        CType(Me.dtgVer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Toolbar1
        '
        Me.Toolbar1.AutoSize = False
        Me.Toolbar1.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.Toolbar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Toolbar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Toolbar1.ImageScalingSize = New System.Drawing.Size(23, 23)
        Me.Toolbar1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator2, Me.ToolStripButton1, Me.ToolStripButton2, Me.ToolStripSeparator3, Me.btnNuevo, Me.btnBuscar, Me.btnGuardar, Me.btnContCambios, Me.btn_transaccionar})
        Me.Toolbar1.Location = New System.Drawing.Point(0, 0)
        Me.Toolbar1.Name = "Toolbar1"
        Me.Toolbar1.Size = New System.Drawing.Size(693, 33)
        Me.Toolbar1.TabIndex = 1033
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
        'btn_transaccionar
        '
        Me.btn_transaccionar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_transaccionar.Image = Global.Spic.My.Resources.Resources.box2
        Me.btn_transaccionar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_transaccionar.Name = "btn_transaccionar"
        Me.btn_transaccionar.Size = New System.Drawing.Size(27, 30)
        Me.btn_transaccionar.Text = "Realizar transacciones"
        '
        'dtgVer
        '
        Me.dtgVer.AllowDrop = True
        Me.dtgVer.AllowUserToAddRows = False
        Me.dtgVer.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        Me.dtgVer.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dtgVer.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtgVer.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dtgVer.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dtgVer.BackgroundColor = System.Drawing.SystemColors.ControlDark
        Me.dtgVer.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgVer.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dtgVer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgVer.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.btnEliminar, Me.Id, Me.Fecha, Me.Operario, Me.Turno, Me.Seccion, Me.Grupo, Me.Kilo_Prod, Me.Horas_Trabajadas, Me.STANDAR})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtgVer.DefaultCellStyle = DataGridViewCellStyle3
        Me.dtgVer.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dtgVer.GridColor = System.Drawing.SystemColors.ButtonShadow
        Me.dtgVer.Location = New System.Drawing.Point(2, 205)
        Me.dtgVer.Name = "dtgVer"
        Me.dtgVer.ReadOnly = True
        Me.dtgVer.RowHeadersVisible = False
        Me.dtgVer.Size = New System.Drawing.Size(691, 172)
        Me.dtgVer.TabIndex = 1032
        '
        'btnEliminar
        '
        Me.btnEliminar.HeaderText = ""
        Me.btnEliminar.Image = Global.Spic.My.Resources.Resources._1371749741_32447
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.ReadOnly = True
        Me.btnEliminar.Width = 5
        '
        'Id
        '
        Me.Id.HeaderText = "Id"
        Me.Id.Name = "Id"
        Me.Id.ReadOnly = True
        Me.Id.Width = 41
        '
        'Fecha
        '
        Me.Fecha.HeaderText = "Fecha"
        Me.Fecha.Name = "Fecha"
        Me.Fecha.ReadOnly = True
        Me.Fecha.Width = 62
        '
        'Operario
        '
        Me.Operario.HeaderText = "Operario"
        Me.Operario.Name = "Operario"
        Me.Operario.ReadOnly = True
        Me.Operario.Width = 72
        '
        'Turno
        '
        Me.Turno.HeaderText = "Turno"
        Me.Turno.Name = "Turno"
        Me.Turno.ReadOnly = True
        Me.Turno.Width = 60
        '
        'Seccion
        '
        Me.Seccion.HeaderText = "Seccion"
        Me.Seccion.Name = "Seccion"
        Me.Seccion.ReadOnly = True
        Me.Seccion.Width = 71
        '
        'Grupo
        '
        Me.Grupo.HeaderText = "Grupo"
        Me.Grupo.Name = "Grupo"
        Me.Grupo.ReadOnly = True
        Me.Grupo.Width = 61
        '
        'Kilo_Prod
        '
        Me.Kilo_Prod.HeaderText = "Kilo Producido"
        Me.Kilo_Prod.Name = "Kilo_Prod"
        Me.Kilo_Prod.ReadOnly = True
        Me.Kilo_Prod.Width = 92
        '
        'Horas_Trabajadas
        '
        Me.Horas_Trabajadas.HeaderText = "Horas Trabajadas"
        Me.Horas_Trabajadas.Name = "Horas_Trabajadas"
        Me.Horas_Trabajadas.ReadOnly = True
        Me.Horas_Trabajadas.Width = 106
        '
        'STANDAR
        '
        Me.STANDAR.HeaderText = "Kilos Standar"
        Me.STANDAR.Name = "STANDAR"
        Me.STANDAR.ReadOnly = True
        Me.STANDAR.Width = 87
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboOperario)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.chkTodos)
        Me.GroupBox1.Controls.Add(Me.lblNom)
        Me.GroupBox1.Controls.Add(Me.Label24)
        Me.GroupBox1.Controls.Add(Me.Label25)
        Me.GroupBox1.Controls.Add(Me.txtTotalProd)
        Me.GroupBox1.Controls.Add(Me.txtTotalParos)
        Me.GroupBox1.Controls.Add(Me.GroupBox4)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtKilos)
        Me.GroupBox1.Controls.Add(Me.cboTurno)
        Me.GroupBox1.Controls.Add(Me.cboGrupo)
        Me.GroupBox1.Controls.Add(Me.cboLeva)
        Me.GroupBox1.Controls.Add(Me.dtFechaActual)
        Me.GroupBox1.Location = New System.Drawing.Point(2, 34)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(691, 165)
        Me.GroupBox1.TabIndex = 1031
        Me.GroupBox1.TabStop = False
        '
        'cboOperario
        '
        Me.cboOperario.FormattingEnabled = True
        Me.cboOperario.Items.AddRange(New Object() {"Enero ", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"})
        Me.cboOperario.Location = New System.Drawing.Point(363, 13)
        Me.cboOperario.Name = "cboOperario"
        Me.cboOperario.Size = New System.Drawing.Size(283, 21)
        Me.cboOperario.TabIndex = 1069
        Me.cboOperario.Text = "Seleccione"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(320, 3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 13)
        Me.Label2.TabIndex = 29
        Me.Label2.Text = "Todos"
        '
        'chkTodos
        '
        Me.chkTodos.AutoSize = True
        Me.chkTodos.Location = New System.Drawing.Point(332, 19)
        Me.chkTodos.Name = "chkTodos"
        Me.chkTodos.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkTodos.Size = New System.Drawing.Size(15, 14)
        Me.chkTodos.TabIndex = 28
        Me.chkTodos.UseVisualStyleBackColor = True
        '
        'lblNom
        '
        Me.lblNom.AutoSize = True
        Me.lblNom.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNom.Location = New System.Drawing.Point(3, 70)
        Me.lblNom.Name = "lblNom"
        Me.lblNom.Size = New System.Drawing.Size(0, 13)
        Me.lblNom.TabIndex = 25
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(537, 71)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(84, 13)
        Me.Label24.TabIndex = 24
        Me.Label24.Text = "Total Produc:"
        Me.Label24.Visible = False
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(429, 71)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(43, 13)
        Me.Label25.TabIndex = 23
        Me.Label25.Text = "Paros:"
        Me.Label25.Visible = False
        '
        'txtTotalProd
        '
        Me.txtTotalProd.Location = New System.Drawing.Point(623, 67)
        Me.txtTotalProd.Name = "txtTotalProd"
        Me.txtTotalProd.Size = New System.Drawing.Size(62, 20)
        Me.txtTotalProd.TabIndex = 22
        Me.txtTotalProd.Visible = False
        '
        'txtTotalParos
        '
        Me.txtTotalParos.Location = New System.Drawing.Point(473, 67)
        Me.txtTotalParos.Name = "txtTotalParos"
        Me.txtTotalParos.Size = New System.Drawing.Size(62, 20)
        Me.txtTotalParos.TabIndex = 21
        Me.txtTotalParos.Visible = False
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.Label13)
        Me.GroupBox4.Controls.Add(Me.lblLimSup)
        Me.GroupBox4.Controls.Add(Me.lblLimInf)
        Me.GroupBox4.Controls.Add(Me.Label10)
        Me.GroupBox4.Location = New System.Drawing.Point(445, 87)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(240, 68)
        Me.GroupBox4.TabIndex = 20
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Capacidad Maxima"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(8, 39)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(91, 13)
        Me.Label13.TabIndex = 3
        Me.Label13.Text = "Limite Superior"
        '
        'lblLimSup
        '
        Me.lblLimSup.BackColor = System.Drawing.Color.Gainsboro
        Me.lblLimSup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLimSup.Location = New System.Drawing.Point(99, 39)
        Me.lblLimSup.Name = "lblLimSup"
        Me.lblLimSup.Size = New System.Drawing.Size(85, 15)
        Me.lblLimSup.TabIndex = 2
        Me.lblLimSup.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblLimInf
        '
        Me.lblLimInf.BackColor = System.Drawing.Color.Gainsboro
        Me.lblLimInf.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLimInf.Location = New System.Drawing.Point(99, 16)
        Me.lblLimInf.Name = "lblLimInf"
        Me.lblLimInf.Size = New System.Drawing.Size(85, 15)
        Me.lblLimInf.TabIndex = 1
        Me.lblLimInf.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(12, 16)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(84, 13)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Limite Inferior"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lblProdGrupo)
        Me.GroupBox2.Controls.Add(Me.Label22)
        Me.GroupBox2.Controls.Add(Me.lblProdSeccion)
        Me.GroupBox2.Controls.Add(Me.Label20)
        Me.GroupBox2.Controls.Add(Me.Label17)
        Me.GroupBox2.Controls.Add(Me.lblParosAcum)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.lblTiempoPro)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 88)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(433, 67)
        Me.GroupBox2.TabIndex = 18
        Me.GroupBox2.TabStop = False
        '
        'lblProdGrupo
        '
        Me.lblProdGrupo.BackColor = System.Drawing.Color.Gainsboro
        Me.lblProdGrupo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblProdGrupo.Location = New System.Drawing.Point(100, 38)
        Me.lblProdGrupo.Name = "lblProdGrupo"
        Me.lblProdGrupo.Size = New System.Drawing.Size(78, 15)
        Me.lblProdGrupo.TabIndex = 10
        Me.lblProdGrupo.Text = " "
        Me.lblProdGrupo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(97, 14)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(81, 13)
        Me.Label22.TabIndex = 9
        Me.Label22.Text = "Prod x Grupo"
        '
        'lblProdSeccion
        '
        Me.lblProdSeccion.BackColor = System.Drawing.Color.Gainsboro
        Me.lblProdSeccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblProdSeccion.Location = New System.Drawing.Point(7, 38)
        Me.lblProdSeccion.Name = "lblProdSeccion"
        Me.lblProdSeccion.Size = New System.Drawing.Size(77, 15)
        Me.lblProdSeccion.TabIndex = 8
        Me.lblProdSeccion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(4, 14)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(83, 13)
        Me.Label20.TabIndex = 7
        Me.Label20.Text = "Prod Sección"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(307, 14)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(113, 13)
        Me.Label17.TabIndex = 4
        Me.Label17.Text = "Tiempo Productivo"
        '
        'lblParosAcum
        '
        Me.lblParosAcum.BackColor = System.Drawing.Color.Gainsboro
        Me.lblParosAcum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblParosAcum.Location = New System.Drawing.Point(194, 38)
        Me.lblParosAcum.Name = "lblParosAcum"
        Me.lblParosAcum.Size = New System.Drawing.Size(103, 15)
        Me.lblParosAcum.TabIndex = 3
        Me.lblParosAcum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(191, 14)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(111, 13)
        Me.Label15.TabIndex = 2
        Me.Label15.Text = "Paros Acumulados"
        '
        'lblTiempoPro
        '
        Me.lblTiempoPro.BackColor = System.Drawing.Color.Gainsboro
        Me.lblTiempoPro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTiempoPro.Location = New System.Drawing.Point(307, 38)
        Me.lblTiempoPro.Name = "lblTiempoPro"
        Me.lblTiempoPro.Size = New System.Drawing.Size(112, 15)
        Me.lblTiempoPro.TabIndex = 1
        Me.lblTiempoPro.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(268, 70)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(38, 13)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Kilos:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(268, 44)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(44, 13)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Turno:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(268, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(59, 13)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Operario:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(3, 42)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 13)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Grupo:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(49, 75)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(0, 13)
        Me.Label3.TabIndex = 10
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Fecha:"
        '
        'txtKilos
        '
        Me.txtKilos.Location = New System.Drawing.Point(363, 67)
        Me.txtKilos.Name = "txtKilos"
        Me.txtKilos.Size = New System.Drawing.Size(62, 20)
        Me.txtKilos.TabIndex = 6
        '
        'cboTurno
        '
        Me.cboTurno.FormattingEnabled = True
        Me.cboTurno.Location = New System.Drawing.Point(363, 39)
        Me.cboTurno.Name = "cboTurno"
        Me.cboTurno.Size = New System.Drawing.Size(322, 21)
        Me.cboTurno.TabIndex = 5
        '
        'cboGrupo
        '
        Me.cboGrupo.FormattingEnabled = True
        Me.cboGrupo.Location = New System.Drawing.Point(50, 39)
        Me.cboGrupo.Name = "cboGrupo"
        Me.cboGrupo.Size = New System.Drawing.Size(200, 21)
        Me.cboGrupo.TabIndex = 3
        '
        'cboLeva
        '
        Me.cboLeva.FormattingEnabled = True
        Me.cboLeva.Location = New System.Drawing.Point(50, 66)
        Me.cboLeva.Name = "cboLeva"
        Me.cboLeva.Size = New System.Drawing.Size(200, 21)
        Me.cboLeva.TabIndex = 2
        '
        'dtFechaActual
        '
        Me.dtFechaActual.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFechaActual.Location = New System.Drawing.Point(50, 13)
        Me.dtFechaActual.Name = "dtFechaActual"
        Me.dtFechaActual.Size = New System.Drawing.Size(200, 20)
        Me.dtFechaActual.TabIndex = 0
        '
        'FRM_ing_galv_baches
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(693, 378)
        Me.Controls.Add(Me.Toolbar1)
        Me.Controls.Add(Me.dtgVer)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "FRM_ing_galv_baches"
        Me.Text = "Galvanizado por baches"
        Me.Toolbar1.ResumeLayout(False)
        Me.Toolbar1.PerformLayout()
        CType(Me.dtgVer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
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
    Friend WithEvents dtgVer As System.Windows.Forms.DataGridView
    Friend WithEvents btnEliminar As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Operario As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Turno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Seccion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Grupo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Kilo_Prod As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Horas_Trabajadas As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents STANDAR As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblNom As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents txtTotalProd As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalParos As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents lblLimSup As System.Windows.Forms.Label
    Friend WithEvents lblLimInf As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lblProdGrupo As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents lblProdSeccion As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents lblParosAcum As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents lblTiempoPro As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtKilos As System.Windows.Forms.TextBox
    Friend WithEvents cboTurno As System.Windows.Forms.ComboBox
    Friend WithEvents cboGrupo As System.Windows.Forms.ComboBox
    Friend WithEvents cboLeva As System.Windows.Forms.ComboBox
    Friend WithEvents dtFechaActual As System.Windows.Forms.DateTimePicker
    Friend WithEvents chkTodos As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnContCambios As System.Windows.Forms.ToolStripButton
    Friend WithEvents cboOperario As System.Windows.Forms.ComboBox
    Friend WithEvents btn_transaccionar As ToolStripButton
End Class
