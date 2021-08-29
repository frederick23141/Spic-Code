<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmIngVtas
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
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmIngVtas))
        Me.txtNit = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btn_clientes = New System.Windows.Forms.Button()
        Me.txt_nombres = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblN = New System.Windows.Forms.Label()
        Me.txt_estado = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtCondicion = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txt_tot_pend = New System.Windows.Forms.TextBox()
        Me.txtCupo = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txt_cheq_dev = New System.Windows.Forms.TextBox()
        Me.txt_cupo = New System.Windows.Forms.TextBox()
        Me.txt_cartera = New System.Windows.Forms.TextBox()
        Me.btnDetalle = New System.Windows.Forms.Button()
        Me.lbl_cupo = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.txtVrTot = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtCant = New System.Windows.Forms.TextBox()
        Me.txtDesc = New System.Windows.Forms.TextBox()
        Me.TxtVrUnit = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtCod = New System.Windows.Forms.TextBox()
        Me.lblReferencia = New System.Windows.Forms.Label()
        Me.txtRef = New System.Windows.Forms.TextBox()
        Me.DtgDetalleRef = New System.Windows.Forms.DataGridView()
        Me.dtgPedido = New System.Windows.Forms.DataGridView()
        Me.btnEliminar = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.cod = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.desc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cant = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.vrUnit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colVrTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.p_min = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtNotas = New System.Windows.Forms.TextBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.lblUltimoPedido = New System.Windows.Forms.Label()
        Me.lblNroPedido = New System.Windows.Forms.Label()
        Me.txt_bodega = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lblVI = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtSubtot = New System.Windows.Forms.TextBox()
        Me.txt_tot = New System.Windows.Forms.TextBox()
        Me.txt_vr_iva = New System.Windows.Forms.TextBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.txt_notas_opc = New System.Windows.Forms.TextBox()
        Me.btn_nuevo = New System.Windows.Forms.Button()
        Me.btn_guardar = New System.Windows.Forms.Button()
        Me.btn_compromiso = New System.Windows.Forms.Button()
        Me.JjvusuariosBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.CORSANDataSet1 = New Spic.CORSANDataSet1()
        Me.CORSANDataSet = New Spic.CORSANDataSet()
        Me.CORSANDataSetBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Jjv_usuariosTableAdapter = New Spic.CORSANDataSet1TableAdapters.Jjv_usuariosTableAdapter()
        Me.btn_mod = New System.Windows.Forms.Button()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txt_vend = New System.Windows.Forms.TextBox()
        Me.Toolbar1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btn_salir = New System.Windows.Forms.ToolStripButton()
        Me.btn_ppal = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnNuevo = New System.Windows.Forms.ToolStripButton()
        Me.btnGuardar = New System.Windows.Forms.ToolStripButton()
        Me.btn_consultas = New System.Windows.Forms.ToolStripSplitButton()
        Me.tool_desp = New System.Windows.Forms.ToolStripMenuItem()
        Me.tool_seg = New System.Windows.Forms.ToolStripMenuItem()
        Me.tool_cartera = New System.Windows.Forms.ToolStripMenuItem()
        Me.tool_pend = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnAyuda = New System.Windows.Forms.ToolStripButton()
        Me.btnContCambios = New System.Windows.Forms.ToolStripButton()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.txtNota5 = New System.Windows.Forms.TextBox()
        Me.imgProc = New System.Windows.Forms.PictureBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.DtgDetalleRef, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtgPedido, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        CType(Me.JjvusuariosBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CORSANDataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CORSANDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CORSANDataSetBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Toolbar1.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        CType(Me.imgProc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtNit
        '
        Me.txtNit.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNit.Location = New System.Drawing.Point(47, 17)
        Me.txtNit.MaxLength = 32
        Me.txtNit.Name = "txtNit"
        Me.txtNit.Size = New System.Drawing.Size(175, 21)
        Me.txtNit.TabIndex = 34
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.btn_clientes)
        Me.GroupBox1.Controls.Add(Me.txt_nombres)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.lblN)
        Me.GroupBox1.Controls.Add(Me.txtNit)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 45)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(658, 41)
        Me.GroupBox1.TabIndex = 36
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos cliente"
        '
        'btn_clientes
        '
        Me.btn_clientes.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_clientes.BackgroundImage = Global.Spic.My.Resources.Resources.mas1
        Me.btn_clientes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn_clientes.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_clientes.ForeColor = System.Drawing.Color.Red
        Me.btn_clientes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_clientes.Location = New System.Drawing.Point(611, 12)
        Me.btn_clientes.Name = "btn_clientes"
        Me.btn_clientes.Size = New System.Drawing.Size(25, 25)
        Me.btn_clientes.TabIndex = 42
        '
        'txt_nombres
        '
        Me.txt_nombres.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_nombres.BackColor = System.Drawing.SystemColors.Window
        Me.txt_nombres.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txt_nombres.Location = New System.Drawing.Point(319, 18)
        Me.txt_nombres.Name = "txt_nombres"
        Me.txt_nombres.ReadOnly = True
        Me.txt_nombres.Size = New System.Drawing.Size(270, 14)
        Me.txt_nombres.TabIndex = 41
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(14, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(27, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nit:"
        '
        'lblN
        '
        Me.lblN.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblN.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblN.Location = New System.Drawing.Point(252, 18)
        Me.lblN.Name = "lblN"
        Me.lblN.Size = New System.Drawing.Size(61, 14)
        Me.lblN.TabIndex = 40
        Me.lblN.Text = "Nombres:"
        '
        'txt_estado
        '
        Me.txt_estado.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_estado.BackColor = System.Drawing.SystemColors.Window
        Me.txt_estado.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txt_estado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_estado.Location = New System.Drawing.Point(418, 18)
        Me.txt_estado.Name = "txt_estado"
        Me.txt_estado.ReadOnly = True
        Me.txt_estado.Size = New System.Drawing.Size(81, 13)
        Me.txt_estado.TabIndex = 1
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.Label17)
        Me.GroupBox2.Controls.Add(Me.txtCondicion)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.txt_tot_pend)
        Me.GroupBox2.Controls.Add(Me.txtCupo)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.txt_cheq_dev)
        Me.GroupBox2.Controls.Add(Me.txt_cupo)
        Me.GroupBox2.Controls.Add(Me.txt_cartera)
        Me.GroupBox2.Controls.Add(Me.btnDetalle)
        Me.GroupBox2.Controls.Add(Me.lbl_cupo)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.txt_estado)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(12, 86)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(658, 68)
        Me.GroupBox2.TabIndex = 43
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Estado Financiero"
        '
        'Label17
        '
        Me.Label17.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(508, 19)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(67, 13)
        Me.Label17.TabIndex = 54
        Me.Label17.Text = "Condición:"
        '
        'txtCondicion
        '
        Me.txtCondicion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCondicion.BackColor = System.Drawing.SystemColors.Window
        Me.txtCondicion.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtCondicion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCondicion.Location = New System.Drawing.Point(578, 21)
        Me.txtCondicion.Name = "txtCondicion"
        Me.txtCondicion.ReadOnly = True
        Me.txtCondicion.Size = New System.Drawing.Size(68, 13)
        Me.txtCondicion.TabIndex = 55
        '
        'Label15
        '
        Me.Label15.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(368, 46)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(97, 13)
        Me.Label15.TabIndex = 52
        Me.Label15.Text = "Tot Pendientes:"
        '
        'txt_tot_pend
        '
        Me.txt_tot_pend.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_tot_pend.BackColor = System.Drawing.SystemColors.Window
        Me.txt_tot_pend.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txt_tot_pend.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_tot_pend.Location = New System.Drawing.Point(469, 48)
        Me.txt_tot_pend.Name = "txt_tot_pend"
        Me.txt_tot_pend.ReadOnly = True
        Me.txt_tot_pend.Size = New System.Drawing.Size(104, 13)
        Me.txt_tot_pend.TabIndex = 53
        '
        'txtCupo
        '
        Me.txtCupo.BackColor = System.Drawing.SystemColors.Window
        Me.txtCupo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtCupo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCupo.Location = New System.Drawing.Point(64, 20)
        Me.txtCupo.Name = "txtCupo"
        Me.txtCupo.ReadOnly = True
        Me.txtCupo.Size = New System.Drawing.Size(96, 13)
        Me.txtCupo.TabIndex = 51
        '
        'Label14
        '
        Me.Label14.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(9, 20)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(61, 14)
        Me.Label14.TabIndex = 50
        Me.Label14.Text = "Cupo:"
        '
        'txt_cheq_dev
        '
        Me.txt_cheq_dev.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_cheq_dev.BackColor = System.Drawing.SystemColors.Window
        Me.txt_cheq_dev.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txt_cheq_dev.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_cheq_dev.Location = New System.Drawing.Point(267, 48)
        Me.txt_cheq_dev.Name = "txt_cheq_dev"
        Me.txt_cheq_dev.ReadOnly = True
        Me.txt_cheq_dev.Size = New System.Drawing.Size(98, 13)
        Me.txt_cheq_dev.TabIndex = 49
        '
        'txt_cupo
        '
        Me.txt_cupo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_cupo.BackColor = System.Drawing.SystemColors.Window
        Me.txt_cupo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txt_cupo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_cupo.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txt_cupo.Location = New System.Drawing.Point(267, 18)
        Me.txt_cupo.Name = "txt_cupo"
        Me.txt_cupo.ReadOnly = True
        Me.txt_cupo.Size = New System.Drawing.Size(98, 13)
        Me.txt_cupo.TabIndex = 48
        '
        'txt_cartera
        '
        Me.txt_cartera.BackColor = System.Drawing.SystemColors.Window
        Me.txt_cartera.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txt_cartera.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_cartera.Location = New System.Drawing.Point(64, 47)
        Me.txt_cartera.Name = "txt_cartera"
        Me.txt_cartera.ReadOnly = True
        Me.txt_cartera.Size = New System.Drawing.Size(95, 13)
        Me.txt_cartera.TabIndex = 47
        '
        'btnDetalle
        '
        Me.btnDetalle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDetalle.Image = Global.Spic.My.Resources.Resources.buscar7
        Me.btnDetalle.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnDetalle.Location = New System.Drawing.Point(584, 40)
        Me.btnDetalle.Name = "btnDetalle"
        Me.btnDetalle.Size = New System.Drawing.Size(67, 23)
        Me.btnDetalle.TabIndex = 33
        Me.btnDetalle.Text = "Detalle"
        Me.btnDetalle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDetalle.UseVisualStyleBackColor = True
        '
        'lbl_cupo
        '
        Me.lbl_cupo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_cupo.AutoSize = True
        Me.lbl_cupo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_cupo.Location = New System.Drawing.Point(164, 18)
        Me.lbl_cupo.Name = "lbl_cupo"
        Me.lbl_cupo.Size = New System.Drawing.Size(101, 13)
        Me.lbl_cupo.TabIndex = 43
        Me.lbl_cupo.Text = "Cupo disponible:"
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(368, 17)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(50, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Estado:"
        '
        'Label8
        '
        Me.Label8.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(8, 44)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(72, 17)
        Me.Label8.TabIndex = 44
        Me.Label8.Text = "Cartera:"
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(165, 47)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(99, 13)
        Me.Label6.TabIndex = 40
        Me.Label6.Text = "Cheq devueltos:"
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.btnAgregar)
        Me.GroupBox3.Controls.Add(Me.txtVrTot)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.txtCant)
        Me.GroupBox3.Controls.Add(Me.txtDesc)
        Me.GroupBox3.Controls.Add(Me.TxtVrUnit)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.txtCod)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(12, 253)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(658, 66)
        Me.GroupBox3.TabIndex = 50
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Ingresar producto"
        '
        'btnAgregar
        '
        Me.btnAgregar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAgregar.Enabled = False
        Me.btnAgregar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregar.Image = Global.Spic.My.Resources.Resources.carrito__1_
        Me.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAgregar.Location = New System.Drawing.Point(578, 33)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(74, 23)
        Me.btnAgregar.TabIndex = 1002
        Me.btnAgregar.Text = "Agregar"
        Me.btnAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'txtVrTot
        '
        Me.txtVrTot.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtVrTot.BackColor = System.Drawing.SystemColors.Window
        Me.txtVrTot.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtVrTot.Enabled = False
        Me.txtVrTot.Location = New System.Drawing.Point(410, 38)
        Me.txtVrTot.Name = "txtVrTot"
        Me.txtVrTot.ReadOnly = True
        Me.txtVrTot.Size = New System.Drawing.Size(163, 14)
        Me.txtVrTot.TabIndex = 51
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Red
        Me.Label10.Location = New System.Drawing.Point(413, 19)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(60, 13)
        Me.Label10.TabIndex = 50
        Me.Label10.Text = "Vr Total"
        '
        'txtCant
        '
        Me.txtCant.Enabled = False
        Me.txtCant.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCant.Location = New System.Drawing.Point(253, 35)
        Me.txtCant.MaxLength = 32
        Me.txtCant.Name = "txtCant"
        Me.txtCant.Size = New System.Drawing.Size(56, 21)
        Me.txtCant.TabIndex = 100
        '
        'txtDesc
        '
        Me.txtDesc.BackColor = System.Drawing.SystemColors.Window
        Me.txtDesc.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtDesc.Enabled = False
        Me.txtDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDesc.Location = New System.Drawing.Point(88, 38)
        Me.txtDesc.Name = "txtDesc"
        Me.txtDesc.ReadOnly = True
        Me.txtDesc.Size = New System.Drawing.Size(159, 13)
        Me.txtDesc.TabIndex = 48
        '
        'TxtVrUnit
        '
        Me.TxtVrUnit.Enabled = False
        Me.TxtVrUnit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtVrUnit.Location = New System.Drawing.Point(315, 35)
        Me.TxtVrUnit.MaxLength = 32
        Me.TxtVrUnit.Name = "TxtVrUnit"
        Me.TxtVrUnit.Size = New System.Drawing.Size(91, 21)
        Me.TxtVrUnit.TabIndex = 101
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(86, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 13)
        Me.Label2.TabIndex = 43
        Me.Label2.Text = "Descripción"
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(314, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 13)
        Me.Label3.TabIndex = 44
        Me.Label3.Text = "Vr unitario"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(6, 19)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(50, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Código:"
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(251, 19)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(57, 13)
        Me.Label9.TabIndex = 40
        Me.Label9.Text = "Cant "
        '
        'txtCod
        '
        Me.txtCod.BackColor = System.Drawing.SystemColors.Window
        Me.txtCod.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtCod.Enabled = False
        Me.txtCod.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCod.Location = New System.Drawing.Point(9, 38)
        Me.txtCod.Name = "txtCod"
        Me.txtCod.ReadOnly = True
        Me.txtCod.Size = New System.Drawing.Size(71, 13)
        Me.txtCod.TabIndex = 1
        '
        'lblReferencia
        '
        Me.lblReferencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReferencia.Location = New System.Drawing.Point(12, 159)
        Me.lblReferencia.Name = "lblReferencia"
        Me.lblReferencia.Size = New System.Drawing.Size(114, 23)
        Me.lblReferencia.TabIndex = 52
        Me.lblReferencia.Text = "Código referencia:"
        '
        'txtRef
        '
        Me.txtRef.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtRef.Enabled = False
        Me.txtRef.Location = New System.Drawing.Point(127, 157)
        Me.txtRef.MaxLength = 32
        Me.txtRef.Name = "txtRef"
        Me.txtRef.Size = New System.Drawing.Size(185, 20)
        Me.txtRef.TabIndex = 103
        '
        'DtgDetalleRef
        '
        Me.DtgDetalleRef.AllowUserToAddRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro
        Me.DtgDetalleRef.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DtgDetalleRef.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DtgDetalleRef.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DtgDetalleRef.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DtgDetalleRef.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DtgDetalleRef.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DtgDetalleRef.Location = New System.Drawing.Point(15, 180)
        Me.DtgDetalleRef.Name = "DtgDetalleRef"
        Me.DtgDetalleRef.Size = New System.Drawing.Size(532, 72)
        Me.DtgDetalleRef.TabIndex = 53
        '
        'dtgPedido
        '
        Me.dtgPedido.AllowUserToAddRows = False
        Me.dtgPedido.AllowUserToOrderColumns = True
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.Gainsboro
        Me.dtgPedido.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
        Me.dtgPedido.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtgPedido.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dtgPedido.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgPedido.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dtgPedido.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgPedido.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.btnEliminar, Me.cod, Me.desc, Me.cant, Me.vrUnit, Me.colVrTotal, Me.p_min})
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.Format = "N0"
        DataGridViewCellStyle8.NullValue = Nothing
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtgPedido.DefaultCellStyle = DataGridViewCellStyle8
        Me.dtgPedido.Enabled = False
        Me.dtgPedido.Location = New System.Drawing.Point(15, 344)
        Me.dtgPedido.Name = "dtgPedido"
        Me.dtgPedido.ReadOnly = True
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgPedido.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.dtgPedido.RowHeadersVisible = False
        Me.dtgPedido.Size = New System.Drawing.Size(655, 121)
        Me.dtgPedido.TabIndex = 54
        '
        'btnEliminar
        '
        Me.btnEliminar.HeaderText = "Borrar"
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.ReadOnly = True
        Me.btnEliminar.Width = 41
        '
        'cod
        '
        Me.cod.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.cod.HeaderText = "Còdigo"
        Me.cod.Name = "cod"
        Me.cod.ReadOnly = True
        Me.cod.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.cod.Width = 65
        '
        'desc
        '
        Me.desc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.desc.HeaderText = "Descripciòn"
        Me.desc.Name = "desc"
        Me.desc.ReadOnly = True
        Me.desc.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.desc.Width = 88
        '
        'cant
        '
        Me.cant.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle5.Format = "N0"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.cant.DefaultCellStyle = DataGridViewCellStyle5
        Me.cant.HeaderText = "Cantidad"
        Me.cant.Name = "cant"
        Me.cant.ReadOnly = True
        Me.cant.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.cant.Width = 74
        '
        'vrUnit
        '
        Me.vrUnit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle6.Format = "C2"
        DataGridViewCellStyle6.NullValue = Nothing
        Me.vrUnit.DefaultCellStyle = DataGridViewCellStyle6
        Me.vrUnit.HeaderText = "Vr unitario"
        Me.vrUnit.Name = "vrUnit"
        Me.vrUnit.ReadOnly = True
        Me.vrUnit.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.vrUnit.Width = 79
        '
        'colVrTotal
        '
        Me.colVrTotal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle7.Format = "C2"
        DataGridViewCellStyle7.NullValue = Nothing
        Me.colVrTotal.DefaultCellStyle = DataGridViewCellStyle7
        Me.colVrTotal.HeaderText = "Valor total"
        Me.colVrTotal.Name = "colVrTotal"
        Me.colVrTotal.ReadOnly = True
        Me.colVrTotal.Width = 79
        '
        'p_min
        '
        Me.p_min.HeaderText = "p_min"
        Me.p_min.Name = "p_min"
        Me.p_min.ReadOnly = True
        Me.p_min.Width = 60
        '
        'txtNotas
        '
        Me.txtNotas.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNotas.Enabled = False
        Me.txtNotas.Location = New System.Drawing.Point(7, 15)
        Me.txtNotas.MaxLength = 250
        Me.txtNotas.Multiline = True
        Me.txtNotas.Name = "txtNotas"
        Me.txtNotas.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtNotas.Size = New System.Drawing.Size(642, 22)
        Me.txtNotas.TabIndex = 49
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.txtNotas)
        Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(15, 469)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(655, 42)
        Me.GroupBox4.TabIndex = 104
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Despachos (SALEN EN LA FACTURA,SOLO: ORDEN DE COMPRA, FECHA DE ENTREGA, DIRECCIÓN" & _
    " ETC!)"
        '
        'lblUltimoPedido
        '
        Me.lblUltimoPedido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblUltimoPedido.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUltimoPedido.ForeColor = System.Drawing.Color.Red
        Me.lblUltimoPedido.Location = New System.Drawing.Point(158, 29)
        Me.lblUltimoPedido.Name = "lblUltimoPedido"
        Me.lblUltimoPedido.Size = New System.Drawing.Size(196, 19)
        Me.lblUltimoPedido.TabIndex = 106
        Me.lblUltimoPedido.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblNroPedido
        '
        Me.lblNroPedido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblNroPedido.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNroPedido.ForeColor = System.Drawing.Color.Red
        Me.lblNroPedido.Location = New System.Drawing.Point(357, 29)
        Me.lblNroPedido.Name = "lblNroPedido"
        Me.lblNroPedido.Size = New System.Drawing.Size(189, 19)
        Me.lblNroPedido.TabIndex = 105
        Me.lblNroPedido.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txt_bodega
        '
        Me.txt_bodega.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_bodega.Location = New System.Drawing.Point(607, 29)
        Me.txt_bodega.Name = "txt_bodega"
        Me.txt_bodega.ReadOnly = True
        Me.txt_bodega.Size = New System.Drawing.Size(25, 20)
        Me.txt_bodega.TabIndex = 107
        Me.txt_bodega.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(553, 32)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(54, 13)
        Me.Label11.TabIndex = 1003
        Me.Label11.Text = "Bodega:"
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(442, 325)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(72, 20)
        Me.Label12.TabIndex = 1010
        Me.Label12.Text = "Total:"
        '
        'lblVI
        '
        Me.lblVI.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVI.Location = New System.Drawing.Point(231, 326)
        Me.lblVI.Name = "lblVI"
        Me.lblVI.Size = New System.Drawing.Size(72, 20)
        Me.lblVI.TabIndex = 1008
        Me.lblVI.Text = "Valor Iva:"
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(14, 326)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(72, 20)
        Me.Label13.TabIndex = 1006
        Me.Label13.Text = "Subtotal:"
        '
        'txtSubtot
        '
        Me.txtSubtot.BackColor = System.Drawing.SystemColors.Window
        Me.txtSubtot.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtSubtot.Location = New System.Drawing.Point(70, 326)
        Me.txtSubtot.Name = "txtSubtot"
        Me.txtSubtot.ReadOnly = True
        Me.txtSubtot.Size = New System.Drawing.Size(143, 13)
        Me.txtSubtot.TabIndex = 1011
        Me.txtSubtot.Text = "0"
        '
        'txt_tot
        '
        Me.txt_tot.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_tot.BackColor = System.Drawing.SystemColors.Window
        Me.txt_tot.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txt_tot.Location = New System.Drawing.Point(481, 326)
        Me.txt_tot.Name = "txt_tot"
        Me.txt_tot.ReadOnly = True
        Me.txt_tot.Size = New System.Drawing.Size(189, 13)
        Me.txt_tot.TabIndex = 1012
        Me.txt_tot.Text = "0"
        '
        'txt_vr_iva
        '
        Me.txt_vr_iva.BackColor = System.Drawing.SystemColors.Window
        Me.txt_vr_iva.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txt_vr_iva.Location = New System.Drawing.Point(293, 326)
        Me.txt_vr_iva.Name = "txt_vr_iva"
        Me.txt_vr_iva.ReadOnly = True
        Me.txt_vr_iva.Size = New System.Drawing.Size(143, 13)
        Me.txt_vr_iva.TabIndex = 1013
        Me.txt_vr_iva.Text = "0"
        '
        'GroupBox5
        '
        Me.GroupBox5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox5.Controls.Add(Me.txt_notas_opc)
        Me.GroupBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.ForeColor = System.Drawing.Color.Red
        Me.GroupBox5.Location = New System.Drawing.Point(12, 515)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(660, 42)
        Me.GroupBox5.TabIndex = 105
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "VENTAS (notas para servicio al cliente, diferentes a dirección y tipo de empaque)" & _
    ""
        '
        'txt_notas_opc
        '
        Me.txt_notas_opc.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_notas_opc.Enabled = False
        Me.txt_notas_opc.Location = New System.Drawing.Point(7, 15)
        Me.txt_notas_opc.MaxLength = 250
        Me.txt_notas_opc.Multiline = True
        Me.txt_notas_opc.Name = "txt_notas_opc"
        Me.txt_notas_opc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txt_notas_opc.Size = New System.Drawing.Size(647, 21)
        Me.txt_notas_opc.TabIndex = 49
        '
        'btn_nuevo
        '
        Me.btn_nuevo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_nuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_nuevo.Image = Global.Spic.My.Resources.Resources.nuevo
        Me.btn_nuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_nuevo.Location = New System.Drawing.Point(563, 182)
        Me.btn_nuevo.Name = "btn_nuevo"
        Me.btn_nuevo.Size = New System.Drawing.Size(82, 23)
        Me.btn_nuevo.TabIndex = 1014
        Me.btn_nuevo.Text = "  Nuevo"
        Me.btn_nuevo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_nuevo.UseVisualStyleBackColor = True
        '
        'btn_guardar
        '
        Me.btn_guardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_guardar.Enabled = False
        Me.btn_guardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_guardar.Image = CType(resources.GetObject("btn_guardar.Image"), System.Drawing.Image)
        Me.btn_guardar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_guardar.Location = New System.Drawing.Point(563, 156)
        Me.btn_guardar.Name = "btn_guardar"
        Me.btn_guardar.Size = New System.Drawing.Size(82, 23)
        Me.btn_guardar.TabIndex = 1005
        Me.btn_guardar.Text = "Guardar"
        Me.btn_guardar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_guardar.UseVisualStyleBackColor = True
        '
        'btn_compromiso
        '
        Me.btn_compromiso.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_compromiso.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_compromiso.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_compromiso.Location = New System.Drawing.Point(563, 234)
        Me.btn_compromiso.Name = "btn_compromiso"
        Me.btn_compromiso.Size = New System.Drawing.Size(82, 23)
        Me.btn_compromiso.TabIndex = 1015
        Me.btn_compromiso.Text = "Compromiso"
        Me.btn_compromiso.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_compromiso.UseVisualStyleBackColor = True
        '
        'JjvusuariosBindingSource
        '
        Me.JjvusuariosBindingSource.DataMember = "Jjv_usuarios"
        Me.JjvusuariosBindingSource.DataSource = Me.CORSANDataSet1
        '
        'CORSANDataSet1
        '
        Me.CORSANDataSet1.DataSetName = "CORSANDataSet1"
        Me.CORSANDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'CORSANDataSet
        '
        Me.CORSANDataSet1.DataSetName = "CORSANDataSet1"
        Me.CORSANDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'CORSANDataSetBindingSource
        '
        Me.CORSANDataSetBindingSource.DataSource = Me.CORSANDataSet
        Me.CORSANDataSetBindingSource.Position = 0
        '
        'Jjv_usuariosTableAdapter
        '
        Me.Jjv_usuariosTableAdapter.ClearBeforeFill = True
        '
        'btn_mod
        '
        Me.btn_mod.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_mod.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_mod.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_mod.Location = New System.Drawing.Point(563, 208)
        Me.btn_mod.Name = "btn_mod"
        Me.btn_mod.Size = New System.Drawing.Size(82, 23)
        Me.btn_mod.TabIndex = 1017
        Me.btn_mod.Text = "Consultar"
        Me.btn_mod.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_mod.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(9, 31)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(65, 13)
        Me.Label16.TabIndex = 1003
        Me.Label16.Text = "Vendedor:"
        '
        'txt_vend
        '
        Me.txt_vend.BackColor = System.Drawing.SystemColors.Window
        Me.txt_vend.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txt_vend.Enabled = False
        Me.txt_vend.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_vend.Location = New System.Drawing.Point(87, 32)
        Me.txt_vend.Name = "txt_vend"
        Me.txt_vend.ReadOnly = True
        Me.txt_vend.Size = New System.Drawing.Size(61, 13)
        Me.txt_vend.TabIndex = 1004
        '
        'Toolbar1
        '
        Me.Toolbar1.AutoSize = False
        Me.Toolbar1.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.Toolbar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Toolbar1.ImageScalingSize = New System.Drawing.Size(23, 23)
        Me.Toolbar1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator2, Me.btn_salir, Me.btn_ppal, Me.ToolStripSeparator3, Me.btnNuevo, Me.btnGuardar, Me.btn_consultas, Me.btnAyuda, Me.btnContCambios})
        Me.Toolbar1.Location = New System.Drawing.Point(0, 0)
        Me.Toolbar1.Name = "Toolbar1"
        Me.Toolbar1.Size = New System.Drawing.Size(682, 29)
        Me.Toolbar1.TabIndex = 1028
        Me.Toolbar1.Text = "ToolStrip1"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 29)
        '
        'btn_salir
        '
        Me.btn_salir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_salir.Image = CType(resources.GetObject("btn_salir.Image"), System.Drawing.Image)
        Me.btn_salir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_salir.Name = "btn_salir"
        Me.btn_salir.Size = New System.Drawing.Size(27, 26)
        Me.btn_salir.Text = "ToolStripButton1"
        Me.btn_salir.ToolTipText = "Salir"
        '
        'btn_ppal
        '
        Me.btn_ppal.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_ppal.Image = CType(resources.GetObject("btn_ppal.Image"), System.Drawing.Image)
        Me.btn_ppal.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_ppal.Name = "btn_ppal"
        Me.btn_ppal.Size = New System.Drawing.Size(27, 26)
        Me.btn_ppal.Text = "ToolStripButton2"
        Me.btn_ppal.ToolTipText = "Menú principal"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 29)
        '
        'btnNuevo
        '
        Me.btnNuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnNuevo.Image = CType(resources.GetObject("btnNuevo.Image"), System.Drawing.Image)
        Me.btnNuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Padding = New System.Windows.Forms.Padding(0, 0, 8, 0)
        Me.btnNuevo.Size = New System.Drawing.Size(35, 26)
        Me.btnNuevo.Text = "Nuevo"
        '
        'btnGuardar
        '
        Me.btnGuardar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Padding = New System.Windows.Forms.Padding(0, 0, 8, 0)
        Me.btnGuardar.Size = New System.Drawing.Size(35, 26)
        Me.btnGuardar.Text = "Guardar"
        '
        'btn_consultas
        '
        Me.btn_consultas.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_consultas.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tool_desp, Me.tool_seg, Me.tool_cartera, Me.tool_pend})
        Me.btn_consultas.Image = Global.Spic.My.Resources.Resources.busc
        Me.btn_consultas.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_consultas.Name = "btn_consultas"
        Me.btn_consultas.Size = New System.Drawing.Size(39, 26)
        Me.btn_consultas.Text = "Consultas"
        '
        'tool_desp
        '
        Me.tool_desp.Image = Global.Spic.My.Resources.Resources.car
        Me.tool_desp.Name = "tool_desp"
        Me.tool_desp.Size = New System.Drawing.Size(141, 22)
        Me.tool_desp.Text = "Despachos"
        Me.tool_desp.ToolTipText = "Despachos"
        '
        'tool_seg
        '
        Me.tool_seg.Image = Global.Spic.My.Resources.Resources.grafic2
        Me.tool_seg.Name = "tool_seg"
        Me.tool_seg.Size = New System.Drawing.Size(141, 22)
        Me.tool_seg.Text = "Seguimiento"
        '
        'tool_cartera
        '
        Me.tool_cartera.Image = Global.Spic.My.Resources.Resources.money4
        Me.tool_cartera.Name = "tool_cartera"
        Me.tool_cartera.Size = New System.Drawing.Size(141, 22)
        Me.tool_cartera.Text = "Cartera"
        Me.tool_cartera.ToolTipText = "Cartera"
        '
        'tool_pend
        '
        Me.tool_pend.Image = Global.Spic.My.Resources.Resources.pend
        Me.tool_pend.Name = "tool_pend"
        Me.tool_pend.Size = New System.Drawing.Size(141, 22)
        Me.tool_pend.Text = "Pendientes"
        Me.tool_pend.ToolTipText = "Pendientes"
        '
        'btnAyuda
        '
        Me.btnAyuda.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnAyuda.Image = Global.Spic.My.Resources.Resources.Help2
        Me.btnAyuda.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnAyuda.Name = "btnAyuda"
        Me.btnAyuda.Size = New System.Drawing.Size(27, 26)
        Me.btnAyuda.Text = "Ayuda"
        '
        'btnContCambios
        '
        Me.btnContCambios.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnContCambios.Image = Global.Spic.My.Resources.Resources.info1
        Me.btnContCambios.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnContCambios.Name = "btnContCambios"
        Me.btnContCambios.Size = New System.Drawing.Size(27, 26)
        Me.btnContCambios.Text = "Control de cambios"
        '
        'GroupBox6
        '
        Me.GroupBox6.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox6.Controls.Add(Me.txtNota5)
        Me.GroupBox6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox6.ForeColor = System.Drawing.Color.Red
        Me.GroupBox6.Location = New System.Drawing.Point(12, 563)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(660, 42)
        Me.GroupBox6.TabIndex = 106
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "PRODUCCIÓN(TIPO EMPAQUE, URGENCIA, PRIORIDAD ENTRE OTROS)"
        '
        'txtNota5
        '
        Me.txtNota5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNota5.Enabled = False
        Me.txtNota5.Location = New System.Drawing.Point(7, 15)
        Me.txtNota5.MaxLength = 250
        Me.txtNota5.Multiline = True
        Me.txtNota5.Name = "txtNota5"
        Me.txtNota5.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtNota5.Size = New System.Drawing.Size(647, 21)
        Me.txtNota5.TabIndex = 49
        '
        'imgProc
        '
        Me.imgProc.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.imgProc.Image = Global.Spic.My.Resources.Resources.procesando
        Me.imgProc.Location = New System.Drawing.Point(29, 244)
        Me.imgProc.Name = "imgProc"
        Me.imgProc.Size = New System.Drawing.Size(613, 328)
        Me.imgProc.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgProc.TabIndex = 1052
        Me.imgProc.TabStop = False
        Me.imgProc.Visible = False
        '
        'FrmIngVtas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(682, 614)
        Me.Controls.Add(Me.imgProc)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.Toolbar1)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.txt_vend)
        Me.Controls.Add(Me.btn_mod)
        Me.Controls.Add(Me.btn_compromiso)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.btn_nuevo)
        Me.Controls.Add(Me.txt_vr_iva)
        Me.Controls.Add(Me.lblNroPedido)
        Me.Controls.Add(Me.txt_tot)
        Me.Controls.Add(Me.txtSubtot)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.lblVI)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.btn_guardar)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txt_bodega)
        Me.Controls.Add(Me.lblUltimoPedido)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.dtgPedido)
        Me.Controls.Add(Me.DtgDetalleRef)
        Me.Controls.Add(Me.lblReferencia)
        Me.Controls.Add(Me.txtRef)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "FrmIngVtas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Ingreso de ventas"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.DtgDetalleRef, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtgPedido, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        CType(Me.JjvusuariosBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CORSANDataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CORSANDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CORSANDataSetBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Toolbar1.ResumeLayout(False)
        Me.Toolbar1.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        CType(Me.imgProc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnDetalle As System.Windows.Forms.Button
    Friend WithEvents txtNit As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblN As System.Windows.Forms.Label
    Friend WithEvents txt_estado As System.Windows.Forms.TextBox
    Friend WithEvents btn_clientes As System.Windows.Forms.Button
    Friend WithEvents txt_nombres As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_cupo As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txt_cartera As System.Windows.Forms.TextBox
    Friend WithEvents txt_cheq_dev As System.Windows.Forms.TextBox
    Friend WithEvents txt_cupo As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txtVrTot As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtCant As System.Windows.Forms.TextBox
    Friend WithEvents txtDesc As System.Windows.Forms.TextBox
    Friend WithEvents TxtVrUnit As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtCod As System.Windows.Forms.TextBox
    Friend WithEvents lblReferencia As System.Windows.Forms.Label
    Friend WithEvents txtRef As System.Windows.Forms.TextBox
    Friend WithEvents DtgDetalleRef As System.Windows.Forms.DataGridView
    Friend WithEvents dtgPedido As System.Windows.Forms.DataGridView
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents txtNotas As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents lblUltimoPedido As System.Windows.Forms.Label
    Friend WithEvents lblNroPedido As System.Windows.Forms.Label
    Friend WithEvents txt_bodega As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents btn_guardar As System.Windows.Forms.Button
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents lblVI As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtSubtot As System.Windows.Forms.TextBox
    Friend WithEvents txt_tot As System.Windows.Forms.TextBox
    Friend WithEvents txt_vr_iva As System.Windows.Forms.TextBox
    Friend WithEvents btn_nuevo As System.Windows.Forms.Button
    Friend WithEvents txtCupo As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txt_tot_pend As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_notas_opc As System.Windows.Forms.TextBox
    Friend WithEvents btn_compromiso As System.Windows.Forms.Button
    Friend WithEvents CORSANDataSetBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CORSANDataSet As Spic.CORSANDataSet
    Friend WithEvents CORSANDataSet1 As Spic.CORSANDataSet1
    Friend WithEvents JjvusuariosBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Jjv_usuariosTableAdapter As Spic.CORSANDataSet1TableAdapters.Jjv_usuariosTableAdapter
    Friend WithEvents btn_mod As System.Windows.Forms.Button
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txt_vend As System.Windows.Forms.TextBox
    Friend WithEvents Toolbar1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btn_salir As System.Windows.Forms.ToolStripButton
    Friend WithEvents btn_ppal As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btn_consultas As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents tool_desp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tool_seg As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tool_cartera As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tool_pend As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents txtNota5 As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtCondicion As System.Windows.Forms.TextBox
    Friend WithEvents btnAyuda As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnContCambios As System.Windows.Forms.ToolStripButton
    Friend WithEvents imgProc As System.Windows.Forms.PictureBox
    Friend WithEvents btnEliminar As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents cod As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents desc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cant As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents vrUnit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colVrTotal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents p_min As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
