<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_ing_recocido
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_ing_recocido))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dtpHoraIncio = New System.Windows.Forms.DateTimePicker()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.dtpHoraFin = New System.Windows.Forms.DateTimePicker()
        Me.txtTiempo = New System.Windows.Forms.TextBox()
        Me.txtSostenimientos = New System.Windows.Forms.TextBox()
        Me.cboPOpera = New System.Windows.Forms.ComboBox()
        Me.cboPDescarga = New System.Windows.Forms.ComboBox()
        Me.cboPCarga = New System.Windows.Forms.ComboBox()
        Me.txtTraccion = New System.Windows.Forms.TextBox()
        Me.txtKilosPro = New System.Windows.Forms.TextBox()
        Me.txtTemperatura = New System.Windows.Forms.TextBox()
        Me.txtCodigos = New System.Windows.Forms.TextBox()
        Me.txtBase = New System.Windows.Forms.TextBox()
        Me.dtFechaActual = New System.Windows.Forms.DateTimePicker()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtgDetalles = New System.Windows.Forms.DataGridView()
        Me.AGREGAR = New System.Windows.Forms.DataGridViewImageColumn()
        Me.ROLLO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODIGO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PESO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TRACCION = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NUM_ORDEN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NUM_ROLLO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COLADA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OBSERVACIONES = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtNumOrdenRec = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Toolbar1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnNuevo = New System.Windows.Forms.ToolStripButton()
        Me.btnBuscar = New System.Windows.Forms.ToolStripButton()
        Me.btnGuardar = New System.Windows.Forms.ToolStripButton()
        Me.btnContCambios = New System.Windows.Forms.ToolStripButton()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtgDetalles, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Toolbar1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dtpHoraIncio)
        Me.GroupBox1.Controls.Add(Me.PictureBox1)
        Me.GroupBox1.Controls.Add(Me.dtpHoraFin)
        Me.GroupBox1.Controls.Add(Me.txtTiempo)
        Me.GroupBox1.Controls.Add(Me.txtSostenimientos)
        Me.GroupBox1.Controls.Add(Me.cboPOpera)
        Me.GroupBox1.Controls.Add(Me.cboPDescarga)
        Me.GroupBox1.Controls.Add(Me.cboPCarga)
        Me.GroupBox1.Controls.Add(Me.txtTraccion)
        Me.GroupBox1.Controls.Add(Me.txtKilosPro)
        Me.GroupBox1.Controls.Add(Me.txtTemperatura)
        Me.GroupBox1.Controls.Add(Me.txtCodigos)
        Me.GroupBox1.Controls.Add(Me.txtBase)
        Me.GroupBox1.Controls.Add(Me.dtFechaActual)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(0, 36)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(799, 175)
        Me.GroupBox1.TabIndex = 1064
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos De La Orden"
        '
        'dtpHoraIncio
        '
        Me.dtpHoraIncio.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtpHoraIncio.Location = New System.Drawing.Point(123, 83)
        Me.dtpHoraIncio.Name = "dtpHoraIncio"
        Me.dtpHoraIncio.Size = New System.Drawing.Size(174, 20)
        Me.dtpHoraIncio.TabIndex = 1071
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Spic.My.Resources.Resources.buscar7
        Me.PictureBox1.Location = New System.Drawing.Point(527, 22)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(24, 22)
        Me.PictureBox1.TabIndex = 1070
        Me.PictureBox1.TabStop = False
        '
        'dtpHoraFin
        '
        Me.dtpHoraFin.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtpHoraFin.Location = New System.Drawing.Point(123, 114)
        Me.dtpHoraFin.Name = "dtpHoraFin"
        Me.dtpHoraFin.Size = New System.Drawing.Size(174, 20)
        Me.dtpHoraFin.TabIndex = 1069
        '
        'txtTiempo
        '
        Me.txtTiempo.Location = New System.Drawing.Point(123, 145)
        Me.txtTiempo.Name = "txtTiempo"
        Me.txtTiempo.Size = New System.Drawing.Size(100, 20)
        Me.txtTiempo.TabIndex = 9
        '
        'txtSostenimientos
        '
        Me.txtSostenimientos.Location = New System.Drawing.Point(410, 52)
        Me.txtSostenimientos.Name = "txtSostenimientos"
        Me.txtSostenimientos.Size = New System.Drawing.Size(111, 20)
        Me.txtSostenimientos.TabIndex = 4
        '
        'cboPOpera
        '
        Me.cboPOpera.FormattingEnabled = True
        Me.cboPOpera.Location = New System.Drawing.Point(410, 115)
        Me.cboPOpera.Name = "cboPOpera"
        Me.cboPOpera.Size = New System.Drawing.Size(259, 21)
        Me.cboPOpera.TabIndex = 10
        '
        'cboPDescarga
        '
        Me.cboPDescarga.FormattingEnabled = True
        Me.cboPDescarga.Location = New System.Drawing.Point(410, 147)
        Me.cboPDescarga.Name = "cboPDescarga"
        Me.cboPDescarga.Size = New System.Drawing.Size(259, 21)
        Me.cboPDescarga.TabIndex = 11
        '
        'cboPCarga
        '
        Me.cboPCarga.FormattingEnabled = True
        Me.cboPCarga.Location = New System.Drawing.Point(410, 83)
        Me.cboPCarga.Name = "cboPCarga"
        Me.cboPCarga.Size = New System.Drawing.Size(259, 21)
        Me.cboPCarga.TabIndex = 7
        '
        'txtTraccion
        '
        Me.txtTraccion.Location = New System.Drawing.Point(688, 111)
        Me.txtTraccion.Name = "txtTraccion"
        Me.txtTraccion.Size = New System.Drawing.Size(100, 20)
        Me.txtTraccion.TabIndex = 8
        '
        'txtKilosPro
        '
        Me.txtKilosPro.Location = New System.Drawing.Point(688, 53)
        Me.txtKilosPro.Name = "txtKilosPro"
        Me.txtKilosPro.Size = New System.Drawing.Size(100, 20)
        Me.txtKilosPro.TabIndex = 2
        '
        'txtTemperatura
        '
        Me.txtTemperatura.Location = New System.Drawing.Point(606, 53)
        Me.txtTemperatura.Name = "txtTemperatura"
        Me.txtTemperatura.Size = New System.Drawing.Size(63, 20)
        Me.txtTemperatura.TabIndex = 5
        '
        'txtCodigos
        '
        Me.txtCodigos.Location = New System.Drawing.Point(410, 22)
        Me.txtCodigos.Name = "txtCodigos"
        Me.txtCodigos.Size = New System.Drawing.Size(111, 20)
        Me.txtCodigos.TabIndex = 1
        '
        'txtBase
        '
        Me.txtBase.Location = New System.Drawing.Point(123, 53)
        Me.txtBase.Name = "txtBase"
        Me.txtBase.Size = New System.Drawing.Size(51, 20)
        Me.txtBase.TabIndex = 3
        '
        'dtFechaActual
        '
        Me.dtFechaActual.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFechaActual.Location = New System.Drawing.Point(123, 21)
        Me.dtFechaActual.Name = "dtFechaActual"
        Me.dtFechaActual.Size = New System.Drawing.Size(172, 20)
        Me.dtFechaActual.TabIndex = 0
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(342, 25)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(68, 13)
        Me.Label13.TabIndex = 1068
        Me.Label13.Text = "Codigo(s): "
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(312, 87)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(98, 13)
        Me.Label12.TabIndex = 1067
        Me.Label12.Text = "Persona Carga: "
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(291, 149)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(119, 13)
        Me.Label11.TabIndex = 1066
        Me.Label11.Text = "Persona Descarga: "
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(526, 56)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(86, 13)
        Me.Label10.TabIndex = 1065
        Me.Label10.Text = "T° Recocido: "
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(80, 56)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(43, 13)
        Me.Label9.TabIndex = 1064
        Me.Label9.Text = "Base: "
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(14, 87)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(109, 13)
        Me.Label8.TabIndex = 1063
        Me.Label8.Text = "Hora Inicio Ciclo: "
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(28, 118)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(95, 13)
        Me.Label7.TabIndex = 1062
        Me.Label7.Text = "Hora Fin Ciclo: "
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(2, 149)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(121, 13)
        Me.Label6.TabIndex = 1061
        Me.Label6.Text = "Tiempo Descargue: "
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(316, 56)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(94, 13)
        Me.Label5.TabIndex = 1060
        Me.Label5.Text = "Sostenimiento: "
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(311, 118)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(99, 13)
        Me.Label4.TabIndex = 1059
        Me.Label4.Text = "Persona Opera: "
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(685, 25)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(107, 13)
        Me.Label3.TabIndex = 1058
        Me.Label3.Text = "Kg Programados: "
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(680, 87)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 13)
        Me.Label2.TabIndex = 1057
        Me.Label2.Text = "Tracción KG/MM: "
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(33, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(90, 13)
        Me.Label1.TabIndex = 1056
        Me.Label1.Text = "Fecha Actual: "
        '
        'dtgDetalles
        '
        Me.dtgDetalles.AllowUserToAddRows = False
        Me.dtgDetalles.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        Me.dtgDetalles.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dtgDetalles.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtgDetalles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dtgDetalles.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgDetalles.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dtgDetalles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgDetalles.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.AGREGAR, Me.ROLLO, Me.CODIGO, Me.PESO, Me.TRACCION, Me.NUM_ORDEN, Me.NUM_ROLLO, Me.COLADA, Me.OBSERVACIONES})
        Me.dtgDetalles.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dtgDetalles.Location = New System.Drawing.Point(0, 217)
        Me.dtgDetalles.Name = "dtgDetalles"
        Me.dtgDetalles.RowHeadersVisible = False
        Me.dtgDetalles.Size = New System.Drawing.Size(799, 168)
        Me.dtgDetalles.TabIndex = 1061
        '
        'AGREGAR
        '
        Me.AGREGAR.HeaderText = ""
        Me.AGREGAR.Image = Global.Spic.My.Resources.Resources._1379531393_radio_button_on
        Me.AGREGAR.Name = "AGREGAR"
        Me.AGREGAR.Width = 5
        '
        'ROLLO
        '
        Me.ROLLO.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.ROLLO.HeaderText = "ROLLO"
        Me.ROLLO.Name = "ROLLO"
        Me.ROLLO.Width = 50
        '
        'CODIGO
        '
        Me.CODIGO.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.CODIGO.HeaderText = "CODIGO"
        Me.CODIGO.Name = "CODIGO"
        Me.CODIGO.Width = 80
        '
        'PESO
        '
        Me.PESO.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.PESO.HeaderText = "PESO"
        Me.PESO.Name = "PESO"
        Me.PESO.Width = 50
        '
        'TRACCION
        '
        Me.TRACCION.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.TRACCION.HeaderText = "TRACCIÓN"
        Me.TRACCION.Name = "TRACCION"
        Me.TRACCION.Width = 70
        '
        'NUM_ORDEN
        '
        Me.NUM_ORDEN.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.NUM_ORDEN.HeaderText = "N° ORDEN DE PRDUCCION (F-012)"
        Me.NUM_ORDEN.Name = "NUM_ORDEN"
        Me.NUM_ORDEN.Width = 150
        '
        'NUM_ROLLO
        '
        Me.NUM_ROLLO.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.NUM_ROLLO.HeaderText = "N° DE ROLLO EN LA ORDEN"
        Me.NUM_ROLLO.Name = "NUM_ROLLO"
        Me.NUM_ROLLO.Width = 150
        '
        'COLADA
        '
        Me.COLADA.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.COLADA.HeaderText = "COLADA"
        Me.COLADA.Name = "COLADA"
        Me.COLADA.Width = 80
        '
        'OBSERVACIONES
        '
        Me.OBSERVACIONES.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.OBSERVACIONES.HeaderText = "OBSERVACIONES"
        Me.OBSERVACIONES.Name = "OBSERVACIONES"
        Me.OBSERVACIONES.Width = 300
        '
        'txtNumOrdenRec
        '
        Me.txtNumOrdenRec.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNumOrdenRec.Location = New System.Drawing.Point(410, 16)
        Me.txtNumOrdenRec.Name = "txtNumOrdenRec"
        Me.txtNumOrdenRec.Size = New System.Drawing.Size(124, 20)
        Me.txtNumOrdenRec.TabIndex = 1060
        '
        'Label14
        '
        Me.Label14.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(321, 20)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(89, 13)
        Me.Label14.TabIndex = 1063
        Me.Label14.Text = "RECOCIDO N°"
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
        Me.Toolbar1.Size = New System.Drawing.Size(799, 33)
        Me.Toolbar1.TabIndex = 1062
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
        'Frm_ing_recocido
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(799, 386)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dtgDetalles)
        Me.Controls.Add(Me.txtNumOrdenRec)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Toolbar1)
        Me.Name = "Frm_ing_recocido"
        Me.Text = "Ingreso recocido"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtgDetalles, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Toolbar1.ResumeLayout(False)
        Me.Toolbar1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dtpHoraIncio As System.Windows.Forms.DateTimePicker
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents dtpHoraFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtTiempo As System.Windows.Forms.TextBox
    Friend WithEvents txtSostenimientos As System.Windows.Forms.TextBox
    Friend WithEvents cboPOpera As System.Windows.Forms.ComboBox
    Friend WithEvents cboPDescarga As System.Windows.Forms.ComboBox
    Friend WithEvents cboPCarga As System.Windows.Forms.ComboBox
    Friend WithEvents txtTraccion As System.Windows.Forms.TextBox
    Friend WithEvents txtKilosPro As System.Windows.Forms.TextBox
    Friend WithEvents txtTemperatura As System.Windows.Forms.TextBox
    Friend WithEvents txtCodigos As System.Windows.Forms.TextBox
    Friend WithEvents txtBase As System.Windows.Forms.TextBox
    Friend WithEvents dtFechaActual As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtgDetalles As System.Windows.Forms.DataGridView
    Friend WithEvents AGREGAR As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents ROLLO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODIGO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PESO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TRACCION As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NUM_ORDEN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NUM_ROLLO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COLADA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OBSERVACIONES As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtNumOrdenRec As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Toolbar1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnBuscar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnContCambios As System.Windows.Forms.ToolStripButton
End Class
