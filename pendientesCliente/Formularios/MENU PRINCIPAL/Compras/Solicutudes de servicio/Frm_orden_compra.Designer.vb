<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Frm_orden_compra
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_orden_compra))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Toolbar1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnNuevo = New System.Windows.Forms.ToolStripButton()
        Me.btnGuardar = New System.Windows.Forms.ToolStripButton()
        Me.btn_codigos = New System.Windows.Forms.ToolStripButton()
        Me.tsb_Bodega8 = New System.Windows.Forms.ToolStripButton()
        Me.cboQuienSolicita = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cboFechaSol = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboFechaEsp = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtObservaciones = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.groupDatosSol = New System.Windows.Forms.GroupBox()
        Me.cboCentro = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.groupDatosProv = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtValTot = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboRecive = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboFecRecepcion = New System.Windows.Forms.DateTimePicker()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cboautoriza = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cboResponsable = New System.Windows.Forms.ComboBox()
        Me.imgProc = New System.Windows.Forms.PictureBox()
        Me.chk_ped_realizado = New System.Windows.Forms.CheckBox()
        Me.txtObserAlmacen = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.dtgSolicitud = New System.Windows.Forms.DataGridView()
        Me.colNuevo = New System.Windows.Forms.DataGridViewImageColumn()
        Me.colBorrar = New System.Windows.Forms.DataGridViewImageColumn()
        Me.ColNumDet = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDesc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Id_proveedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCant = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colProveedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colMedida = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colCantAut = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_cant_entregada = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPrecio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cbocuenta = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.btnfinalizar = New System.Windows.Forms.Button()
        Me.txtnumerofac = New System.Windows.Forms.TextBox()
        Me.lblfactura = New System.Windows.Forms.Label()
        Me.chk_contabilizado = New System.Windows.Forms.CheckBox()
        Me.compras_Tip = New System.Windows.Forms.ToolTip(Me.components)
        Me.p_cerrar = New System.Windows.Forms.Panel()
        Me.txt_buscar = New System.Windows.Forms.TextBox()
        Me.lbl_codigo = New System.Windows.Forms.Label()
        Me.dtg_codigo = New System.Windows.Forms.DataGridView()
        Me.Pb_cerrar = New System.Windows.Forms.PictureBox()
        Me.bs_cod = New System.Windows.Forms.BindingSource(Me.components)
        Me.btn_Transaccion_Salida = New System.Windows.Forms.Button()
        Me.chk_no_recurrente = New System.Windows.Forms.CheckBox()
        Me.chk_proceso = New System.Windows.Forms.CheckBox()
        Me.Toolbar1.SuspendLayout()
        Me.groupDatosSol.SuspendLayout()
        Me.groupDatosProv.SuspendLayout()
        CType(Me.imgProc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtgSolicitud, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.p_cerrar.SuspendLayout()
        CType(Me.dtg_codigo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Pb_cerrar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bs_cod, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Toolbar1
        '
        Me.Toolbar1.AutoSize = False
        Me.Toolbar1.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.Toolbar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Toolbar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Toolbar1.ImageScalingSize = New System.Drawing.Size(23, 23)
        Me.Toolbar1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator2, Me.ToolStripButton1, Me.ToolStripButton2, Me.ToolStripSeparator3, Me.btnNuevo, Me.btnGuardar, Me.btn_codigos, Me.tsb_Bodega8})
        Me.Toolbar1.Location = New System.Drawing.Point(0, 0)
        Me.Toolbar1.Name = "Toolbar1"
        Me.Toolbar1.Size = New System.Drawing.Size(1132, 28)
        Me.Toolbar1.TabIndex = 1028
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
        'btnNuevo
        '
        Me.btnNuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnNuevo.Image = CType(resources.GetObject("btnNuevo.Image"), System.Drawing.Image)
        Me.btnNuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Padding = New System.Windows.Forms.Padding(0, 0, 8, 0)
        Me.btnNuevo.Size = New System.Drawing.Size(35, 25)
        Me.btnNuevo.Text = "Nuevo"
        '
        'btnGuardar
        '
        Me.btnGuardar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnGuardar.Image = Global.Spic.My.Resources.Resources.save_16
        Me.btnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(27, 25)
        Me.btnGuardar.Text = "Guardar"
        '
        'btn_codigos
        '
        Me.btn_codigos.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_codigos.Image = Global.Spic.My.Resources.Resources.busc
        Me.btn_codigos.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_codigos.Name = "btn_codigos"
        Me.btn_codigos.Size = New System.Drawing.Size(27, 25)
        Me.btn_codigos.Text = "Codigos para registrar"
        '
        'tsb_Bodega8
        '
        Me.tsb_Bodega8.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsb_Bodega8.Image = Global.Spic.My.Resources.Resources.nuevo
        Me.tsb_Bodega8.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsb_Bodega8.Name = "tsb_Bodega8"
        Me.tsb_Bodega8.Size = New System.Drawing.Size(27, 25)
        Me.tsb_Bodega8.Text = "ToolStripButton3"
        Me.tsb_Bodega8.ToolTipText = "Inventario bodega 8"
        '
        'cboQuienSolicita
        '
        Me.cboQuienSolicita.FormattingEnabled = True
        Me.cboQuienSolicita.Location = New System.Drawing.Point(9, 63)
        Me.cboQuienSolicita.Name = "cboQuienSolicita"
        Me.cboQuienSolicita.Size = New System.Drawing.Size(246, 21)
        Me.cboQuienSolicita.TabIndex = 1030
        Me.cboQuienSolicita.Text = "Seleccione"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(6, 47)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(84, 13)
        Me.Label6.TabIndex = 1029
        Me.Label6.Text = "Quien solicita"
        '
        'cboFechaSol
        '
        Me.cboFechaSol.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.cboFechaSol.Location = New System.Drawing.Point(69, 14)
        Me.cboFechaSol.Name = "cboFechaSol"
        Me.cboFechaSol.Size = New System.Drawing.Size(96, 20)
        Me.cboFechaSol.TabIndex = 1040
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 13)
        Me.Label1.TabIndex = 1039
        Me.Label1.Text = "Solcitud:"
        '
        'cboFechaEsp
        '
        Me.cboFechaEsp.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.cboFechaEsp.Location = New System.Drawing.Point(221, 13)
        Me.cboFechaEsp.Name = "cboFechaEsp"
        Me.cboFechaEsp.Size = New System.Drawing.Size(105, 20)
        Me.cboFechaEsp.TabIndex = 1042
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(166, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 13)
        Me.Label2.TabIndex = 1041
        Me.Label2.Text = "Espera:"
        '
        'txtObservaciones
        '
        Me.txtObservaciones.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtObservaciones.BackColor = System.Drawing.Color.White
        Me.txtObservaciones.Location = New System.Drawing.Point(3, 327)
        Me.txtObservaciones.Multiline = True
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.Size = New System.Drawing.Size(395, 77)
        Me.txtObservaciones.TabIndex = 1045
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(-1, 312)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(190, 13)
        Me.Label10.TabIndex = 1044
        Me.Label10.Text = "Observaciones orden de compra"
        '
        'groupDatosSol
        '
        Me.groupDatosSol.Controls.Add(Me.cboCentro)
        Me.groupDatosSol.Controls.Add(Me.Label8)
        Me.groupDatosSol.Controls.Add(Me.Label1)
        Me.groupDatosSol.Controls.Add(Me.Label6)
        Me.groupDatosSol.Controls.Add(Me.cboQuienSolicita)
        Me.groupDatosSol.Controls.Add(Me.cboFechaSol)
        Me.groupDatosSol.Controls.Add(Me.cboFechaEsp)
        Me.groupDatosSol.Controls.Add(Me.Label2)
        Me.groupDatosSol.Location = New System.Drawing.Point(3, 24)
        Me.groupDatosSol.Name = "groupDatosSol"
        Me.groupDatosSol.Size = New System.Drawing.Size(329, 94)
        Me.groupDatosSol.TabIndex = 1046
        Me.groupDatosSol.TabStop = False
        Me.groupDatosSol.Text = "Datos de solicitud"
        '
        'cboCentro
        '
        Me.cboCentro.FormattingEnabled = True
        Me.cboCentro.Location = New System.Drawing.Point(257, 62)
        Me.cboCentro.Name = "cboCentro"
        Me.cboCentro.Size = New System.Drawing.Size(70, 21)
        Me.cboCentro.TabIndex = 1055
        Me.cboCentro.Text = "Seleccione"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(254, 48)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(60, 13)
        Me.Label8.TabIndex = 1051
        Me.Label8.Text = "Centro C."
        '
        'groupDatosProv
        '
        Me.groupDatosProv.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.groupDatosProv.Controls.Add(Me.Label3)
        Me.groupDatosProv.Controls.Add(Me.txtValTot)
        Me.groupDatosProv.Controls.Add(Me.Label5)
        Me.groupDatosProv.Controls.Add(Me.cboRecive)
        Me.groupDatosProv.Controls.Add(Me.Label4)
        Me.groupDatosProv.Controls.Add(Me.cboFecRecepcion)
        Me.groupDatosProv.Location = New System.Drawing.Point(335, 24)
        Me.groupDatosProv.Name = "groupDatosProv"
        Me.groupDatosProv.Size = New System.Drawing.Size(795, 97)
        Me.groupDatosProv.TabIndex = 1049
        Me.groupDatosProv.TabStop = False
        Me.groupDatosProv.Text = "Datos de proveedor"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(549, 73)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(132, 13)
        Me.Label3.TabIndex = 1056
        Me.Label3.Text = "Valor total autorizado:"
        '
        'txtValTot
        '
        Me.txtValTot.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtValTot.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtValTot.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtValTot.ForeColor = System.Drawing.Color.Red
        Me.txtValTot.Location = New System.Drawing.Point(685, 69)
        Me.txtValTot.Name = "txtValTot"
        Me.txtValTot.ReadOnly = True
        Me.txtValTot.Size = New System.Drawing.Size(100, 21)
        Me.txtValTot.TabIndex = 1045
        Me.txtValTot.Text = "0"
        Me.txtValTot.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(4, 14)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(79, 13)
        Me.Label5.TabIndex = 1043
        Me.Label5.Text = "Quien recibe"
        '
        'cboRecive
        '
        Me.cboRecive.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboRecive.FormattingEnabled = True
        Me.cboRecive.Location = New System.Drawing.Point(7, 31)
        Me.cboRecive.Name = "cboRecive"
        Me.cboRecive.Size = New System.Drawing.Size(775, 21)
        Me.cboRecive.TabIndex = 1044
        Me.cboRecive.Text = "Seleccione"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(5, 53)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(120, 13)
        Me.Label4.TabIndex = 1043
        Me.Label4.Text = "Fecha de recepción"
        '
        'cboFecRecepcion
        '
        Me.cboFecRecepcion.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.cboFecRecepcion.Location = New System.Drawing.Point(8, 68)
        Me.cboFecRecepcion.Name = "cboFecRecepcion"
        Me.cboFecRecepcion.Size = New System.Drawing.Size(117, 20)
        Me.cboFecRecepcion.TabIndex = 1044
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(406, 411)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(57, 13)
        Me.Label7.TabIndex = 1043
        Me.Label7.Text = "Autoriza:"
        '
        'cboautoriza
        '
        Me.cboautoriza.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboautoriza.FormattingEnabled = True
        Me.cboautoriza.Location = New System.Drawing.Point(469, 408)
        Me.cboautoriza.Name = "cboautoriza"
        Me.cboautoriza.Size = New System.Drawing.Size(660, 21)
        Me.cboautoriza.TabIndex = 1044
        Me.cboautoriza.Text = "Seleccione"
        '
        'Label11
        '
        Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(0, 411)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(84, 13)
        Me.Label11.TabIndex = 1048
        Me.Label11.Text = "Responsable:"
        '
        'cboResponsable
        '
        Me.cboResponsable.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cboResponsable.BackColor = System.Drawing.Color.Snow
        Me.cboResponsable.FormattingEnabled = True
        Me.cboResponsable.Location = New System.Drawing.Point(84, 408)
        Me.cboResponsable.Name = "cboResponsable"
        Me.cboResponsable.Size = New System.Drawing.Size(314, 21)
        Me.cboResponsable.TabIndex = 1047
        '
        'imgProc
        '
        Me.imgProc.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.imgProc.Image = Global.Spic.My.Resources.Resources.procesando
        Me.imgProc.Location = New System.Drawing.Point(100, 143)
        Me.imgProc.Name = "imgProc"
        Me.imgProc.Size = New System.Drawing.Size(961, 275)
        Me.imgProc.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgProc.TabIndex = 1053
        Me.imgProc.TabStop = False
        Me.imgProc.Visible = False
        '
        'chk_ped_realizado
        '
        Me.chk_ped_realizado.AutoSize = True
        Me.chk_ped_realizado.Enabled = False
        Me.chk_ped_realizado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_ped_realizado.Location = New System.Drawing.Point(336, 3)
        Me.chk_ped_realizado.Name = "chk_ped_realizado"
        Me.chk_ped_realizado.Size = New System.Drawing.Size(135, 19)
        Me.chk_ped_realizado.TabIndex = 1054
        Me.chk_ped_realizado.Text = "Pedido realizado"
        Me.chk_ped_realizado.UseVisualStyleBackColor = True
        '
        'txtObserAlmacen
        '
        Me.txtObserAlmacen.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtObserAlmacen.BackColor = System.Drawing.Color.White
        Me.txtObserAlmacen.Location = New System.Drawing.Point(404, 327)
        Me.txtObserAlmacen.Multiline = True
        Me.txtObserAlmacen.Name = "txtObserAlmacen"
        Me.txtObserAlmacen.ReadOnly = True
        Me.txtObserAlmacen.Size = New System.Drawing.Size(716, 77)
        Me.txtObserAlmacen.TabIndex = 1056
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(400, 312)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(163, 13)
        Me.Label9.TabIndex = 1055
        Me.Label9.Text = "Observaciones del almacen"
        '
        'dtgSolicitud
        '
        Me.dtgSolicitud.AllowUserToAddRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dtgSolicitud.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dtgSolicitud.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtgSolicitud.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgSolicitud.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colNuevo, Me.colBorrar, Me.ColNumDet, Me.colDesc, Me.Id_proveedor, Me.colCant, Me.colProveedor, Me.colMedida, Me.colCantAut, Me.col_cant_entregada, Me.colPrecio, Me.cbocuenta})
        Me.dtgSolicitud.Location = New System.Drawing.Point(0, 124)
        Me.dtgSolicitud.Name = "dtgSolicitud"
        Me.dtgSolicitud.RowHeadersVisible = False
        Me.dtgSolicitud.Size = New System.Drawing.Size(1132, 185)
        Me.dtgSolicitud.TabIndex = 1057
        Me.compras_Tip.SetToolTip(Me.dtgSolicitud, "czccxzczxczc")
        '
        'colNuevo
        '
        Me.colNuevo.Frozen = True
        Me.colNuevo.HeaderText = ""
        Me.colNuevo.Image = Global.Spic.My.Resources.Resources.nuevo
        Me.colNuevo.Name = "colNuevo"
        '
        'colBorrar
        '
        Me.colBorrar.Frozen = True
        Me.colBorrar.HeaderText = ""
        Me.colBorrar.Image = Global.Spic.My.Resources.Resources.x
        Me.colBorrar.Name = "colBorrar"
        Me.colBorrar.Width = 20
        '
        'ColNumDet
        '
        Me.ColNumDet.Frozen = True
        Me.ColNumDet.HeaderText = "numDet"
        Me.ColNumDet.Name = "ColNumDet"
        Me.ColNumDet.Visible = False
        '
        'colDesc
        '
        Me.colDesc.Frozen = True
        Me.colDesc.HeaderText = "Descripción"
        Me.colDesc.Name = "colDesc"
        Me.colDesc.ToolTipText = resources.GetString("colDesc.ToolTipText")
        Me.colDesc.Width = 250
        '
        'Id_proveedor
        '
        Me.Id_proveedor.Frozen = True
        Me.Id_proveedor.HeaderText = "Id_proveedor"
        Me.Id_proveedor.Name = "Id_proveedor"
        Me.Id_proveedor.Visible = False
        '
        'colCant
        '
        Me.colCant.Frozen = True
        Me.colCant.HeaderText = "Cantidad"
        Me.colCant.Name = "colCant"
        Me.colCant.Width = 65
        '
        'colProveedor
        '
        Me.colProveedor.Frozen = True
        Me.colProveedor.HeaderText = "Proveedor"
        Me.colProveedor.Name = "colProveedor"
        Me.colProveedor.Width = 200
        '
        'colMedida
        '
        Me.colMedida.HeaderText = "Medida"
        Me.colMedida.Items.AddRange(New Object() {"Litros", "Kilos", "Unidades", "Metros"})
        Me.colMedida.Name = "colMedida"
        Me.colMedida.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colMedida.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'colCantAut
        '
        Me.colCantAut.HeaderText = "Cantidad autorizada"
        Me.colCantAut.Name = "colCantAut"
        Me.colCantAut.Width = 65
        '
        'col_cant_entregada
        '
        Me.col_cant_entregada.HeaderText = "Cantidad entregada"
        Me.col_cant_entregada.Name = "col_cant_entregada"
        '
        'colPrecio
        '
        DataGridViewCellStyle2.Format = "N0"
        Me.colPrecio.DefaultCellStyle = DataGridViewCellStyle2
        Me.colPrecio.HeaderText = "Precio unitario"
        Me.colPrecio.Name = "colPrecio"
        '
        'cbocuenta
        '
        Me.cbocuenta.HeaderText = "Cuenta"
        Me.cbocuenta.Name = "cbocuenta"
        Me.cbocuenta.Width = 300
        '
        'btnfinalizar
        '
        Me.btnfinalizar.BackColor = System.Drawing.Color.GreenYellow
        Me.btnfinalizar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnfinalizar.Location = New System.Drawing.Point(657, -1)
        Me.btnfinalizar.Name = "btnfinalizar"
        Me.btnfinalizar.Size = New System.Drawing.Size(117, 27)
        Me.btnfinalizar.TabIndex = 1059
        Me.btnfinalizar.Text = "Finalizar pedido"
        Me.btnfinalizar.UseVisualStyleBackColor = False
        '
        'txtnumerofac
        '
        Me.txtnumerofac.Location = New System.Drawing.Point(550, 3)
        Me.txtnumerofac.Name = "txtnumerofac"
        Me.txtnumerofac.Size = New System.Drawing.Size(100, 20)
        Me.txtnumerofac.TabIndex = 1063
        '
        'lblfactura
        '
        Me.lblfactura.AutoSize = True
        Me.lblfactura.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblfactura.Location = New System.Drawing.Point(477, 6)
        Me.lblfactura.Name = "lblfactura"
        Me.lblfactura.Size = New System.Drawing.Size(69, 13)
        Me.lblfactura.TabIndex = 1062
        Me.lblfactura.Text = "nro factura"
        '
        'chk_contabilizado
        '
        Me.chk_contabilizado.AutoSize = True
        Me.chk_contabilizado.BackColor = System.Drawing.Color.LightGray
        Me.chk_contabilizado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_contabilizado.Location = New System.Drawing.Point(219, 3)
        Me.chk_contabilizado.Name = "chk_contabilizado"
        Me.chk_contabilizado.Size = New System.Drawing.Size(114, 19)
        Me.chk_contabilizado.TabIndex = 1064
        Me.chk_contabilizado.Text = "Contabilizado"
        Me.chk_contabilizado.UseVisualStyleBackColor = False
        '
        'p_cerrar
        '
        Me.p_cerrar.Controls.Add(Me.txt_buscar)
        Me.p_cerrar.Controls.Add(Me.lbl_codigo)
        Me.p_cerrar.Controls.Add(Me.dtg_codigo)
        Me.p_cerrar.Controls.Add(Me.Pb_cerrar)
        Me.p_cerrar.Location = New System.Drawing.Point(100, 124)
        Me.p_cerrar.Name = "p_cerrar"
        Me.p_cerrar.Size = New System.Drawing.Size(503, 284)
        Me.p_cerrar.TabIndex = 1065
        Me.p_cerrar.Visible = False
        '
        'txt_buscar
        '
        Me.txt_buscar.Location = New System.Drawing.Point(235, 5)
        Me.txt_buscar.Name = "txt_buscar"
        Me.txt_buscar.Size = New System.Drawing.Size(100, 20)
        Me.txt_buscar.TabIndex = 3
        '
        'lbl_codigo
        '
        Me.lbl_codigo.AutoSize = True
        Me.lbl_codigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_codigo.Location = New System.Drawing.Point(177, 10)
        Me.lbl_codigo.Name = "lbl_codigo"
        Me.lbl_codigo.Size = New System.Drawing.Size(50, 13)
        Me.lbl_codigo.TabIndex = 2
        Me.lbl_codigo.Text = "Buscar:"
        '
        'dtg_codigo
        '
        Me.dtg_codigo.AllowUserToAddRows = False
        Me.dtg_codigo.AllowUserToDeleteRows = False
        Me.dtg_codigo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtg_codigo.Location = New System.Drawing.Point(14, 29)
        Me.dtg_codigo.Name = "dtg_codigo"
        Me.dtg_codigo.RowHeadersVisible = False
        Me.dtg_codigo.Size = New System.Drawing.Size(486, 237)
        Me.dtg_codigo.TabIndex = 1
        '
        'Pb_cerrar
        '
        Me.Pb_cerrar.Image = Global.Spic.My.Resources.Resources.x
        Me.Pb_cerrar.Location = New System.Drawing.Point(482, 3)
        Me.Pb_cerrar.Name = "Pb_cerrar"
        Me.Pb_cerrar.Size = New System.Drawing.Size(18, 20)
        Me.Pb_cerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Pb_cerrar.TabIndex = 0
        Me.Pb_cerrar.TabStop = False
        '
        'btn_Transaccion_Salida
        '
        Me.btn_Transaccion_Salida.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btn_Transaccion_Salida.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Transaccion_Salida.Location = New System.Drawing.Point(784, 0)
        Me.btn_Transaccion_Salida.Name = "btn_Transaccion_Salida"
        Me.btn_Transaccion_Salida.Size = New System.Drawing.Size(118, 26)
        Me.btn_Transaccion_Salida.TabIndex = 1066
        Me.btn_Transaccion_Salida.Text = "Finalizar salida"
        Me.btn_Transaccion_Salida.UseVisualStyleBackColor = False
        Me.btn_Transaccion_Salida.Visible = False
        '
        'chk_no_recurrente
        '
        Me.chk_no_recurrente.AutoSize = True
        Me.chk_no_recurrente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_no_recurrente.Location = New System.Drawing.Point(917, 4)
        Me.chk_no_recurrente.Name = "chk_no_recurrente"
        Me.chk_no_recurrente.Size = New System.Drawing.Size(104, 17)
        Me.chk_no_recurrente.TabIndex = 1068
        Me.chk_no_recurrente.Text = "No recurrente"
        Me.chk_no_recurrente.UseVisualStyleBackColor = True
        '
        'chk_proceso
        '
        Me.chk_proceso.AutoSize = True
        Me.chk_proceso.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_proceso.Location = New System.Drawing.Point(1032, 4)
        Me.chk_proceso.Name = "chk_proceso"
        Me.chk_proceso.Size = New System.Drawing.Size(72, 17)
        Me.chk_proceso.TabIndex = 1069
        Me.chk_proceso.Text = "Proceso"
        Me.chk_proceso.UseVisualStyleBackColor = True
        '
        'Frm_orden_compra
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1132, 433)
        Me.Controls.Add(Me.chk_proceso)
        Me.Controls.Add(Me.chk_no_recurrente)
        Me.Controls.Add(Me.btn_Transaccion_Salida)
        Me.Controls.Add(Me.p_cerrar)
        Me.Controls.Add(Me.chk_contabilizado)
        Me.Controls.Add(Me.txtnumerofac)
        Me.Controls.Add(Me.lblfactura)
        Me.Controls.Add(Me.btnfinalizar)
        Me.Controls.Add(Me.imgProc)
        Me.Controls.Add(Me.txtObserAlmacen)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.chk_ped_realizado)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.cboautoriza)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.groupDatosProv)
        Me.Controls.Add(Me.cboResponsable)
        Me.Controls.Add(Me.groupDatosSol)
        Me.Controls.Add(Me.txtObservaciones)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Toolbar1)
        Me.Controls.Add(Me.dtgSolicitud)
        Me.Name = "Frm_orden_compra"
        Me.Text = "Orden de compra"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Toolbar1.ResumeLayout(False)
        Me.Toolbar1.PerformLayout()
        Me.groupDatosSol.ResumeLayout(False)
        Me.groupDatosSol.PerformLayout()
        Me.groupDatosProv.ResumeLayout(False)
        Me.groupDatosProv.PerformLayout()
        CType(Me.imgProc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtgSolicitud, System.ComponentModel.ISupportInitialize).EndInit()
        Me.p_cerrar.ResumeLayout(False)
        Me.p_cerrar.PerformLayout()
        CType(Me.dtg_codigo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Pb_cerrar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bs_cod, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Toolbar1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents cboQuienSolicita As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboFechaSol As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboFechaEsp As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents groupDatosSol As System.Windows.Forms.GroupBox
    Friend WithEvents groupDatosProv As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboFecRecepcion As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboRecive As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cboautoriza As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cboResponsable As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cboCentro As System.Windows.Forms.ComboBox
    Friend WithEvents imgProc As System.Windows.Forms.PictureBox
    Friend WithEvents chk_ped_realizado As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtValTot As System.Windows.Forms.TextBox
    Friend WithEvents txtObserAlmacen As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents dtgSolicitud As System.Windows.Forms.DataGridView
    Friend WithEvents btnfinalizar As System.Windows.Forms.Button
    Friend WithEvents txtnumerofac As System.Windows.Forms.TextBox
    Friend WithEvents lblfactura As System.Windows.Forms.Label
    Friend WithEvents chk_contabilizado As System.Windows.Forms.CheckBox
    Friend WithEvents colNuevo As DataGridViewImageColumn
    Friend WithEvents colBorrar As DataGridViewImageColumn
    Friend WithEvents ColNumDet As DataGridViewTextBoxColumn
    Friend WithEvents colDesc As DataGridViewTextBoxColumn
    Friend WithEvents Id_proveedor As DataGridViewTextBoxColumn
    Friend WithEvents colCant As DataGridViewTextBoxColumn
    Friend WithEvents colProveedor As DataGridViewTextBoxColumn
    Friend WithEvents colMedida As DataGridViewComboBoxColumn
    Friend WithEvents colCantAut As DataGridViewTextBoxColumn
    Friend WithEvents col_cant_entregada As DataGridViewTextBoxColumn
    Friend WithEvents colPrecio As DataGridViewTextBoxColumn
    Friend WithEvents cbocuenta As DataGridViewComboBoxColumn
    Friend WithEvents compras_Tip As ToolTip
    Friend WithEvents btn_codigos As ToolStripButton
    Friend WithEvents p_cerrar As Panel
    Friend WithEvents dtg_codigo As DataGridView
    Friend WithEvents Pb_cerrar As PictureBox
    Friend WithEvents txt_buscar As TextBox
    Friend WithEvents lbl_codigo As Label
    Friend WithEvents bs_cod As BindingSource
    Friend WithEvents tsb_Bodega8 As ToolStripButton
    Friend WithEvents btn_Transaccion_Salida As Button
    Friend WithEvents chk_no_recurrente As CheckBox
    Friend WithEvents chk_proceso As CheckBox
End Class
