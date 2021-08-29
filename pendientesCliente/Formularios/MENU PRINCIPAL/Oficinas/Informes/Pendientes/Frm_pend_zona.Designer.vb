<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_pend_zona
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
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle23 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle24 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle25 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle26 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Toolbar1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btn_salir = New System.Windows.Forms.ToolStripButton()
        Me.btn_ppal = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.btn_exportar = New System.Windows.Forms.ToolStripButton()
        Me.btnActualizar = New System.Windows.Forms.ToolStripButton()
        Me.lbl_mes = New System.Windows.Forms.Label()
        Me.cbo_ruta = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txt_codigo = New System.Windows.Forms.TextBox()
        Me.txtNumero = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txt_cliente = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtg_consulta = New System.Windows.Forms.DataGridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txt_vend_max = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txt_vend_min = New System.Windows.Forms.TextBox()
        Me.groupCliente = New System.Windows.Forms.GroupBox()
        Me.btn_cerrar = New System.Windows.Forms.Button()
        Me.txt_nombres = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtg_clientes = New System.Windows.Forms.DataGridView()
        Me.colOk = New System.Windows.Forms.DataGridViewImageColumn()
        Me.txt_nit = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tab1 = New System.Windows.Forms.TabControl()
        Me.tab_pen_con_ruta = New System.Windows.Forms.TabPage()
        Me.tab_pen_sin_ruta = New System.Windows.Forms.TabPage()
        Me.dtgSinRuta = New System.Windows.Forms.DataGridView()
        Me.menStripDtg = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.itemAsignarRuta = New System.Windows.Forms.ToolStripMenuItem()
        Me.txt_estado_sin_ruta = New System.Windows.Forms.TextBox()
        Me.GroupAsignarRuta = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cboRutaAsignar = New System.Windows.Forms.ComboBox()
        Me.btnOkAsignar = New System.Windows.Forms.Button()
        Me.lblInfoCiudad = New System.Windows.Forms.Label()
        Me.imgProc = New System.Windows.Forms.PictureBox()
        Me.btnCerrarAsignar = New System.Windows.Forms.Button()
        Me.Toolbar1.SuspendLayout()
        CType(Me.dtg_consulta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.groupCliente.SuspendLayout()
        CType(Me.dtg_clientes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tab1.SuspendLayout()
        Me.tab_pen_con_ruta.SuspendLayout()
        Me.tab_pen_sin_ruta.SuspendLayout()
        CType(Me.dtgSinRuta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.menStripDtg.SuspendLayout()
        Me.GroupAsignarRuta.SuspendLayout()
        CType(Me.imgProc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.Toolbar1.Size = New System.Drawing.Size(677, 34)
        Me.Toolbar1.TabIndex = 1039
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
        'lbl_mes
        '
        Me.lbl_mes.AutoSize = True
        Me.lbl_mes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_mes.Location = New System.Drawing.Point(6, 41)
        Me.lbl_mes.Name = "lbl_mes"
        Me.lbl_mes.Size = New System.Drawing.Size(38, 13)
        Me.lbl_mes.TabIndex = 1042
        Me.lbl_mes.Text = "Ruta:"
        '
        'cbo_ruta
        '
        Me.cbo_ruta.FormattingEnabled = True
        Me.cbo_ruta.Items.AddRange(New Object() {"Enero ", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"})
        Me.cbo_ruta.Location = New System.Drawing.Point(48, 38)
        Me.cbo_ruta.Name = "cbo_ruta"
        Me.cbo_ruta.Size = New System.Drawing.Size(283, 21)
        Me.cbo_ruta.TabIndex = 1041
        Me.cbo_ruta.Text = "Seleccione"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(337, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 13)
        Me.Label2.TabIndex = 1045
        Me.Label2.Text = "Código:"
        '
        'txt_codigo
        '
        Me.txt_codigo.Location = New System.Drawing.Point(388, 39)
        Me.txt_codigo.Name = "txt_codigo"
        Me.txt_codigo.Size = New System.Drawing.Size(114, 20)
        Me.txt_codigo.TabIndex = 1046
        '
        'txtNumero
        '
        Me.txtNumero.Location = New System.Drawing.Point(564, 40)
        Me.txtNumero.Name = "txtNumero"
        Me.txtNumero.Size = New System.Drawing.Size(100, 20)
        Me.txtNumero.TabIndex = 1048
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(508, 42)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 13)
        Me.Label3.TabIndex = 1047
        Me.Label3.Text = "Número:"
        '
        'txt_cliente
        '
        Me.txt_cliente.BackColor = System.Drawing.Color.White
        Me.txt_cliente.Location = New System.Drawing.Point(334, 75)
        Me.txt_cliente.Name = "txt_cliente"
        Me.txt_cliente.ReadOnly = True
        Me.txt_cliente.Size = New System.Drawing.Size(330, 20)
        Me.txt_cliente.TabIndex = 1050
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(283, 77)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(50, 13)
        Me.Label4.TabIndex = 1049
        Me.Label4.Text = "Cliente:"
        '
        'dtg_consulta
        '
        Me.dtg_consulta.AllowUserToAddRows = False
        DataGridViewCellStyle16.BackColor = System.Drawing.Color.LightGray
        DataGridViewCellStyle16.NullValue = Nothing
        Me.dtg_consulta.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle16
        Me.dtg_consulta.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtg_consulta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dtg_consulta.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dtg_consulta.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle17.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle17.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtg_consulta.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle17
        Me.dtg_consulta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle18.Format = "N0"
        DataGridViewCellStyle18.NullValue = "0"
        DataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtg_consulta.DefaultCellStyle = DataGridViewCellStyle18
        Me.dtg_consulta.Location = New System.Drawing.Point(0, 2)
        Me.dtg_consulta.Name = "dtg_consulta"
        DataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle23.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle23.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle23.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtg_consulta.RowHeadersDefaultCellStyle = DataGridViewCellStyle23
        Me.dtg_consulta.RowHeadersVisible = False
        Me.dtg_consulta.Size = New System.Drawing.Size(649, 350)
        Me.dtg_consulta.TabIndex = 1051
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txt_vend_max)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txt_vend_min)
        Me.GroupBox1.Location = New System.Drawing.Point(9, 59)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(264, 46)
        Me.GroupBox1.TabIndex = 1057
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
        Me.groupCliente.Location = New System.Drawing.Point(142, 145)
        Me.groupCliente.Name = "groupCliente"
        Me.groupCliente.Size = New System.Drawing.Size(445, 295)
        Me.groupCliente.TabIndex = 1058
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
        'tab1
        '
        Me.tab1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tab1.Controls.Add(Me.tab_pen_con_ruta)
        Me.tab1.Controls.Add(Me.tab_pen_sin_ruta)
        Me.tab1.Location = New System.Drawing.Point(11, 110)
        Me.tab1.Name = "tab1"
        Me.tab1.SelectedIndex = 0
        Me.tab1.Size = New System.Drawing.Size(653, 380)
        Me.tab1.TabIndex = 1064
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
        DataGridViewCellStyle24.BackColor = System.Drawing.Color.LightGray
        DataGridViewCellStyle24.NullValue = Nothing
        Me.dtgSinRuta.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle24
        Me.dtgSinRuta.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtgSinRuta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dtgSinRuta.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dtgSinRuta.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle25.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle25.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle25.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle25.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle25.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle25.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgSinRuta.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle25
        Me.dtgSinRuta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgSinRuta.ContextMenuStrip = Me.menStripDtg
        DataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle26.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle26.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle26.Format = "N0"
        DataGridViewCellStyle26.NullValue = "0"
        DataGridViewCellStyle26.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle26.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle26.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtgSinRuta.DefaultCellStyle = DataGridViewCellStyle26
        Me.dtgSinRuta.Location = New System.Drawing.Point(0, 1)
        Me.dtgSinRuta.Name = "dtgSinRuta"
        Me.dtgSinRuta.RowHeadersVisible = False
        Me.dtgSinRuta.Size = New System.Drawing.Size(645, 353)
        Me.dtgSinRuta.TabIndex = 1052
        '
        'menStripDtg
        '
        Me.menStripDtg.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.menStripDtg.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.itemAsignarRuta})
        Me.menStripDtg.Name = "ContextMenuStrip1"
        Me.menStripDtg.Size = New System.Drawing.Size(145, 26)
        '
        'itemAsignarRuta
        '
        Me.itemAsignarRuta.Image = Global.Spic.My.Resources.Resources.ok3
        Me.itemAsignarRuta.Name = "itemAsignarRuta"
        Me.itemAsignarRuta.Size = New System.Drawing.Size(144, 22)
        Me.itemAsignarRuta.Text = "Asignar ruta"
        '
        'txt_estado_sin_ruta
        '
        Me.txt_estado_sin_ruta.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txt_estado_sin_ruta.Location = New System.Drawing.Point(274, 114)
        Me.txt_estado_sin_ruta.Name = "txt_estado_sin_ruta"
        Me.txt_estado_sin_ruta.Size = New System.Drawing.Size(38, 13)
        Me.txt_estado_sin_ruta.TabIndex = 1065
        '
        'GroupAsignarRuta
        '
        Me.GroupAsignarRuta.Controls.Add(Me.btnCerrarAsignar)
        Me.GroupAsignarRuta.Controls.Add(Me.lblInfoCiudad)
        Me.GroupAsignarRuta.Controls.Add(Me.btnOkAsignar)
        Me.GroupAsignarRuta.Controls.Add(Me.Label6)
        Me.GroupAsignarRuta.Controls.Add(Me.cboRutaAsignar)
        Me.GroupAsignarRuta.Location = New System.Drawing.Point(271, 165)
        Me.GroupAsignarRuta.Name = "GroupAsignarRuta"
        Me.GroupAsignarRuta.Size = New System.Drawing.Size(361, 110)
        Me.GroupAsignarRuta.TabIndex = 1066
        Me.GroupAsignarRuta.TabStop = False
        Me.GroupAsignarRuta.Text = "Asignar ruta"
        Me.GroupAsignarRuta.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(17, 47)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(38, 13)
        Me.Label6.TabIndex = 1068
        Me.Label6.Text = "Ruta:"
        '
        'cboRutaAsignar
        '
        Me.cboRutaAsignar.FormattingEnabled = True
        Me.cboRutaAsignar.Location = New System.Drawing.Point(59, 44)
        Me.cboRutaAsignar.Name = "cboRutaAsignar"
        Me.cboRutaAsignar.Size = New System.Drawing.Size(283, 21)
        Me.cboRutaAsignar.TabIndex = 1067
        Me.cboRutaAsignar.Text = "Seleccione"
        '
        'btnOkAsignar
        '
        Me.btnOkAsignar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOkAsignar.Image = Global.Spic.My.Resources.Resources.ok3
        Me.btnOkAsignar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnOkAsignar.Location = New System.Drawing.Point(133, 79)
        Me.btnOkAsignar.Name = "btnOkAsignar"
        Me.btnOkAsignar.Size = New System.Drawing.Size(77, 23)
        Me.btnOkAsignar.TabIndex = 1069
        Me.btnOkAsignar.Text = "Asignar"
        Me.btnOkAsignar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnOkAsignar.UseVisualStyleBackColor = True
        '
        'lblInfoCiudad
        '
        Me.lblInfoCiudad.AutoSize = True
        Me.lblInfoCiudad.Location = New System.Drawing.Point(15, 20)
        Me.lblInfoCiudad.Name = "lblInfoCiudad"
        Me.lblInfoCiudad.Size = New System.Drawing.Size(60, 13)
        Me.lblInfoCiudad.TabIndex = 1070
        Me.lblInfoCiudad.Text = "Info ciudad"
        '
        'imgProc
        '
        Me.imgProc.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.imgProc.Image = Global.Spic.My.Resources.Resources.procesando
        Me.imgProc.Location = New System.Drawing.Point(9, 159)
        Me.imgProc.Name = "imgProc"
        Me.imgProc.Size = New System.Drawing.Size(658, 333)
        Me.imgProc.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgProc.TabIndex = 1052
        Me.imgProc.TabStop = False
        Me.imgProc.Visible = False
        '
        'btnCerrarAsignar
        '
        Me.btnCerrarAsignar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrarAsignar.ForeColor = System.Drawing.Color.Red
        Me.btnCerrarAsignar.Location = New System.Drawing.Point(325, 1)
        Me.btnCerrarAsignar.Name = "btnCerrarAsignar"
        Me.btnCerrarAsignar.Size = New System.Drawing.Size(34, 23)
        Me.btnCerrarAsignar.TabIndex = 1071
        Me.btnCerrarAsignar.Text = "X"
        Me.btnCerrarAsignar.UseVisualStyleBackColor = True
        '
        'Frm_pend_zona
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(677, 502)
        Me.Controls.Add(Me.GroupAsignarRuta)
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
        Me.KeyPreview = True
        Me.Name = "Frm_pend_zona"
        Me.Text = "Pendientes por ruta"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Toolbar1.ResumeLayout(False)
        Me.Toolbar1.PerformLayout()
        CType(Me.dtg_consulta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.groupCliente.ResumeLayout(False)
        Me.groupCliente.PerformLayout()
        CType(Me.dtg_clientes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tab1.ResumeLayout(False)
        Me.tab_pen_con_ruta.ResumeLayout(False)
        Me.tab_pen_sin_ruta.ResumeLayout(False)
        CType(Me.dtgSinRuta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.menStripDtg.ResumeLayout(False)
        Me.GroupAsignarRuta.ResumeLayout(False)
        Me.GroupAsignarRuta.PerformLayout()
        CType(Me.imgProc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Toolbar1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btn_salir As System.Windows.Forms.ToolStripButton
    Friend WithEvents btn_ppal As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btn_exportar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnActualizar As System.Windows.Forms.ToolStripButton
    Friend WithEvents lbl_mes As System.Windows.Forms.Label
    Friend WithEvents cbo_ruta As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_codigo As System.Windows.Forms.TextBox
    Friend WithEvents txtNumero As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txt_cliente As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtg_consulta As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txt_vend_max As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txt_vend_min As System.Windows.Forms.TextBox
    Friend WithEvents groupCliente As System.Windows.Forms.GroupBox
    Friend WithEvents txt_nombres As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtg_clientes As System.Windows.Forms.DataGridView
    Friend WithEvents txt_nit As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents colOk As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents btn_cerrar As System.Windows.Forms.Button
    Friend WithEvents tab1 As System.Windows.Forms.TabControl
    Friend WithEvents tab_pen_con_ruta As System.Windows.Forms.TabPage
    Friend WithEvents tab_pen_sin_ruta As System.Windows.Forms.TabPage
    Friend WithEvents dtgSinRuta As System.Windows.Forms.DataGridView
    Friend WithEvents txt_estado_sin_ruta As System.Windows.Forms.TextBox
    Friend WithEvents menStripDtg As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents itemAsignarRuta As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupAsignarRuta As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboRutaAsignar As System.Windows.Forms.ComboBox
    Friend WithEvents btnOkAsignar As System.Windows.Forms.Button
    Friend WithEvents btnCerrarAsignar As System.Windows.Forms.Button
    Friend WithEvents lblInfoCiudad As System.Windows.Forms.Label
    Friend WithEvents imgProc As System.Windows.Forms.PictureBox
End Class
