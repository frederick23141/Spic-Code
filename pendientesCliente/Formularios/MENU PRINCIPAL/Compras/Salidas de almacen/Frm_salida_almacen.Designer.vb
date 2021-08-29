<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_salida_almacen
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_salida_almacen))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Toolbar1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnNuevo = New System.Windows.Forms.ToolStripButton()
        Me.btnGuardar = New System.Windows.Forms.ToolStripButton()
        Me.cboQuienSolicita = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dtgSolicitud = New System.Windows.Forms.DataGridView()
        Me.txtObservaciones = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.groupDatosSol = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cboEntrega = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cboAprueba = New System.Windows.Forms.ComboBox()
        Me.imgProc = New System.Windows.Forms.PictureBox()
        Me.groupCodigo = New System.Windows.Forms.GroupBox()
        Me.btnCerrarEditResp = New System.Windows.Forms.Button()
        Me.txtDesc = New System.Windows.Forms.TextBox()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtgCodigo = New System.Windows.Forms.DataGridView()
        Me.colOk = New System.Windows.Forms.DataGridViewImageColumn()
        Me.btn_transaccion = New System.Windows.Forms.Button()
        Me.group_transaccion = New System.Windows.Forms.GroupBox()
        Me.Modelo = New System.Windows.Forms.Label()
        Me.cbo_modelo = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cbo_bodega = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cbo_tipo = New System.Windows.Forms.ComboBox()
        Me.cboFechaSol = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.colNuevo = New System.Windows.Forms.DataGridViewImageColumn()
        Me.colBorrar = New System.Windows.Forms.DataGridViewImageColumn()
        Me.cboCentro = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.ColNumDet = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCodigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDesc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCant = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colStock_b1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colStock_b5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCosto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colMedida = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_cant_entregada = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Toolbar1.SuspendLayout()
        CType(Me.dtgSolicitud, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.groupDatosSol.SuspendLayout()
        CType(Me.imgProc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.groupCodigo.SuspendLayout()
        CType(Me.dtgCodigo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.group_transaccion.SuspendLayout()
        Me.SuspendLayout()
        '
        'Toolbar1
        '
        Me.Toolbar1.AutoSize = False
        Me.Toolbar1.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.Toolbar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Toolbar1.ImageScalingSize = New System.Drawing.Size(23, 23)
        Me.Toolbar1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator2, Me.ToolStripButton1, Me.ToolStripButton2, Me.ToolStripSeparator3, Me.btnNuevo, Me.btnGuardar})
        Me.Toolbar1.Location = New System.Drawing.Point(0, 0)
        Me.Toolbar1.Name = "Toolbar1"
        Me.Toolbar1.Size = New System.Drawing.Size(790, 28)
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
        'cboQuienSolicita
        '
        Me.cboQuienSolicita.FormattingEnabled = True
        Me.cboQuienSolicita.Location = New System.Drawing.Point(9, 68)
        Me.cboQuienSolicita.Name = "cboQuienSolicita"
        Me.cboQuienSolicita.Size = New System.Drawing.Size(312, 21)
        Me.cboQuienSolicita.TabIndex = 1030
        Me.cboQuienSolicita.Text = "Seleccione"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(6, 52)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(84, 13)
        Me.Label6.TabIndex = 1029
        Me.Label6.Text = "Quien solicita"
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
        Me.dtgSolicitud.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colNuevo, Me.colBorrar, Me.cboCentro, Me.ColNumDet, Me.colCodigo, Me.colDesc, Me.colCant, Me.colStock_b1, Me.colStock_b5, Me.colCosto, Me.colMedida, Me.col_cant_entregada})
        Me.dtgSolicitud.Location = New System.Drawing.Point(2, 124)
        Me.dtgSolicitud.Name = "dtgSolicitud"
        Me.dtgSolicitud.RowHeadersVisible = False
        Me.dtgSolicitud.Size = New System.Drawing.Size(786, 187)
        Me.dtgSolicitud.TabIndex = 1043
        '
        'txtObservaciones
        '
        Me.txtObservaciones.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtObservaciones.BackColor = System.Drawing.Color.White
        Me.txtObservaciones.Location = New System.Drawing.Point(3, 327)
        Me.txtObservaciones.Multiline = True
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.Size = New System.Drawing.Size(785, 77)
        Me.txtObservaciones.TabIndex = 1045
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(-1, 312)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(251, 13)
        Me.Label10.TabIndex = 1044
        Me.Label10.Text = "Observaciones orden de salida de almacén"
        '
        'groupDatosSol
        '
        Me.groupDatosSol.Controls.Add(Me.Label1)
        Me.groupDatosSol.Controls.Add(Me.Label6)
        Me.groupDatosSol.Controls.Add(Me.cboQuienSolicita)
        Me.groupDatosSol.Controls.Add(Me.cboFechaSol)
        Me.groupDatosSol.Location = New System.Drawing.Point(3, 24)
        Me.groupDatosSol.Name = "groupDatosSol"
        Me.groupDatosSol.Size = New System.Drawing.Size(327, 94)
        Me.groupDatosSol.TabIndex = 1046
        Me.groupDatosSol.TabStop = False
        Me.groupDatosSol.Text = "Datos de solicitud"
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(384, 411)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(55, 13)
        Me.Label7.TabIndex = 1043
        Me.Label7.Text = "Entrega:"
        '
        'cboEntrega
        '
        Me.cboEntrega.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cboEntrega.FormattingEnabled = True
        Me.cboEntrega.Location = New System.Drawing.Point(440, 408)
        Me.cboEntrega.Name = "cboEntrega"
        Me.cboEntrega.Size = New System.Drawing.Size(348, 21)
        Me.cboEntrega.TabIndex = 1044
        Me.cboEntrega.Text = "Seleccione"
        '
        'Label11
        '
        Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(0, 411)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(65, 13)
        Me.Label11.TabIndex = 1048
        Me.Label11.Text = "Aprobado:"
        '
        'cboAprueba
        '
        Me.cboAprueba.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cboAprueba.BackColor = System.Drawing.Color.Snow
        Me.cboAprueba.FormattingEnabled = True
        Me.cboAprueba.Location = New System.Drawing.Point(65, 408)
        Me.cboAprueba.Name = "cboAprueba"
        Me.cboAprueba.Size = New System.Drawing.Size(314, 21)
        Me.cboAprueba.TabIndex = 1047
        '
        'imgProc
        '
        Me.imgProc.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.imgProc.Image = Global.Spic.My.Resources.Resources.procesando
        Me.imgProc.Location = New System.Drawing.Point(271, 188)
        Me.imgProc.Name = "imgProc"
        Me.imgProc.Size = New System.Drawing.Size(177, 102)
        Me.imgProc.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgProc.TabIndex = 1053
        Me.imgProc.TabStop = False
        Me.imgProc.Visible = False
        '
        'groupCodigo
        '
        Me.groupCodigo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.groupCodigo.Controls.Add(Me.btnCerrarEditResp)
        Me.groupCodigo.Controls.Add(Me.txtDesc)
        Me.groupCodigo.Controls.Add(Me.txtCodigo)
        Me.groupCodigo.Controls.Add(Me.Label3)
        Me.groupCodigo.Controls.Add(Me.Label2)
        Me.groupCodigo.Controls.Add(Me.dtgCodigo)
        Me.groupCodigo.Location = New System.Drawing.Point(2, 157)
        Me.groupCodigo.Name = "groupCodigo"
        Me.groupCodigo.Size = New System.Drawing.Size(566, 247)
        Me.groupCodigo.TabIndex = 1054
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
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(225, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 13)
        Me.Label3.TabIndex = 1042
        Me.Label3.Text = "Descripción:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 13)
        Me.Label2.TabIndex = 1041
        Me.Label2.Text = "Código:"
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
        Me.dtgCodigo.Size = New System.Drawing.Size(554, 201)
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
        'btn_transaccion
        '
        Me.btn_transaccion.BackColor = System.Drawing.Color.GreenYellow
        Me.btn_transaccion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_transaccion.Image = Global.Spic.My.Resources.Resources.ok3
        Me.btn_transaccion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_transaccion.Location = New System.Drawing.Point(164, 54)
        Me.btn_transaccion.Name = "btn_transaccion"
        Me.btn_transaccion.Size = New System.Drawing.Size(278, 37)
        Me.btn_transaccion.TabIndex = 1056
        Me.btn_transaccion.Text = "Realizar transacción"
        Me.btn_transaccion.UseVisualStyleBackColor = False
        '
        'group_transaccion
        '
        Me.group_transaccion.Controls.Add(Me.btn_transaccion)
        Me.group_transaccion.Controls.Add(Me.Modelo)
        Me.group_transaccion.Controls.Add(Me.cbo_modelo)
        Me.group_transaccion.Controls.Add(Me.Label4)
        Me.group_transaccion.Controls.Add(Me.cbo_bodega)
        Me.group_transaccion.Controls.Add(Me.Label8)
        Me.group_transaccion.Controls.Add(Me.cbo_tipo)
        Me.group_transaccion.Location = New System.Drawing.Point(336, 24)
        Me.group_transaccion.Name = "group_transaccion"
        Me.group_transaccion.Size = New System.Drawing.Size(455, 94)
        Me.group_transaccion.TabIndex = 1047
        Me.group_transaccion.TabStop = False
        Me.group_transaccion.Text = "Realizar transacción"
        '
        'Modelo
        '
        Me.Modelo.AutoSize = True
        Me.Modelo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Modelo.Location = New System.Drawing.Point(164, 13)
        Me.Modelo.Name = "Modelo"
        Me.Modelo.Size = New System.Drawing.Size(48, 13)
        Me.Modelo.TabIndex = 1033
        Me.Modelo.Text = "Modelo"
        '
        'cbo_modelo
        '
        Me.cbo_modelo.FormattingEnabled = True
        Me.cbo_modelo.Location = New System.Drawing.Point(164, 29)
        Me.cbo_modelo.Name = "cbo_modelo"
        Me.cbo_modelo.Size = New System.Drawing.Size(278, 21)
        Me.cbo_modelo.TabIndex = 1034
        Me.cbo_modelo.Text = "Seleccione"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(9, 52)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(50, 13)
        Me.Label4.TabIndex = 1031
        Me.Label4.Text = "Bodega"
        '
        'cbo_bodega
        '
        Me.cbo_bodega.FormattingEnabled = True
        Me.cbo_bodega.Items.AddRange(New Object() {"1", "5", "9"})
        Me.cbo_bodega.Location = New System.Drawing.Point(9, 68)
        Me.cbo_bodega.Name = "cbo_bodega"
        Me.cbo_bodega.Size = New System.Drawing.Size(143, 21)
        Me.cbo_bodega.TabIndex = 1032
        Me.cbo_bodega.Text = "Seleccione"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(6, 13)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(32, 13)
        Me.Label8.TabIndex = 1029
        Me.Label8.Text = "Tipo"
        '
        'cbo_tipo
        '
        Me.cbo_tipo.FormattingEnabled = True
        Me.cbo_tipo.Location = New System.Drawing.Point(6, 29)
        Me.cbo_tipo.Name = "cbo_tipo"
        Me.cbo_tipo.Size = New System.Drawing.Size(143, 21)
        Me.cbo_tipo.TabIndex = 1030
        Me.cbo_tipo.Text = "Seleccione"
        '
        'cboFechaSol
        '
        Me.cboFechaSol.Enabled = False
        Me.cboFechaSol.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.cboFechaSol.Location = New System.Drawing.Point(9, 30)
        Me.cboFechaSol.Name = "cboFechaSol"
        Me.cboFechaSol.Size = New System.Drawing.Size(163, 20)
        Me.cboFechaSol.TabIndex = 1040
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(90, 13)
        Me.Label1.TabIndex = 1039
        Me.Label1.Text = "Fecha solcitud"
        '
        'colNuevo
        '
        Me.colNuevo.Frozen = True
        Me.colNuevo.HeaderText = ""
        Me.colNuevo.Image = Global.Spic.My.Resources.Resources.nuevo
        Me.colNuevo.Name = "colNuevo"
        Me.colNuevo.Width = 20
        '
        'colBorrar
        '
        Me.colBorrar.Frozen = True
        Me.colBorrar.HeaderText = ""
        Me.colBorrar.Image = Global.Spic.My.Resources.Resources.x
        Me.colBorrar.Name = "colBorrar"
        Me.colBorrar.Width = 20
        '
        'cboCentro
        '
        Me.cboCentro.Frozen = True
        Me.cboCentro.HeaderText = "Centro"
        Me.cboCentro.Name = "cboCentro"
        '
        'ColNumDet
        '
        Me.ColNumDet.HeaderText = "numDet"
        Me.ColNumDet.Name = "ColNumDet"
        Me.ColNumDet.Visible = False
        '
        'colCodigo
        '
        Me.colCodigo.HeaderText = "Código"
        Me.colCodigo.Name = "colCodigo"
        Me.colCodigo.ReadOnly = True
        '
        'colDesc
        '
        Me.colDesc.HeaderText = "Descripción"
        Me.colDesc.Name = "colDesc"
        Me.colDesc.ReadOnly = True
        Me.colDesc.Width = 250
        '
        'colCant
        '
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Maroon
        Me.colCant.DefaultCellStyle = DataGridViewCellStyle2
        Me.colCant.HeaderText = "Cantidad"
        Me.colCant.Name = "colCant"
        Me.colCant.Width = 65
        '
        'colStock_b1
        '
        Me.colStock_b1.HeaderText = "Stock_B1"
        Me.colStock_b1.Name = "colStock_b1"
        Me.colStock_b1.ReadOnly = True
        '
        'colStock_b5
        '
        Me.colStock_b5.HeaderText = "Stock_B5"
        Me.colStock_b5.Name = "colStock_b5"
        '
        'colCosto
        '
        DataGridViewCellStyle3.Format = "N0"
        Me.colCosto.DefaultCellStyle = DataGridViewCellStyle3
        Me.colCosto.HeaderText = "Costo_unitario"
        Me.colCosto.Name = "colCosto"
        Me.colCosto.ReadOnly = True
        '
        'colMedida
        '
        Me.colMedida.HeaderText = "Medida"
        Me.colMedida.Name = "colMedida"
        Me.colMedida.ReadOnly = True
        Me.colMedida.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'col_cant_entregada
        '
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Green
        Me.col_cant_entregada.DefaultCellStyle = DataGridViewCellStyle4
        Me.col_cant_entregada.HeaderText = "Cantidad entregada"
        Me.col_cant_entregada.Name = "col_cant_entregada"
        '
        'Frm_salida_almacen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(790, 433)
        Me.Controls.Add(Me.group_transaccion)
        Me.Controls.Add(Me.groupCodigo)
        Me.Controls.Add(Me.imgProc)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.cboEntrega)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.cboAprueba)
        Me.Controls.Add(Me.groupDatosSol)
        Me.Controls.Add(Me.txtObservaciones)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.dtgSolicitud)
        Me.Controls.Add(Me.Toolbar1)
        Me.Name = "Frm_salida_almacen"
        Me.Text = "Salida de almacén"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Toolbar1.ResumeLayout(False)
        Me.Toolbar1.PerformLayout()
        CType(Me.dtgSolicitud, System.ComponentModel.ISupportInitialize).EndInit()
        Me.groupDatosSol.ResumeLayout(False)
        Me.groupDatosSol.PerformLayout()
        CType(Me.imgProc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.groupCodigo.ResumeLayout(False)
        Me.groupCodigo.PerformLayout()
        CType(Me.dtgCodigo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.group_transaccion.ResumeLayout(False)
        Me.group_transaccion.PerformLayout()
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
    Friend WithEvents dtgSolicitud As System.Windows.Forms.DataGridView
    Friend WithEvents txtObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents groupDatosSol As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cboEntrega As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cboAprueba As System.Windows.Forms.ComboBox
    Friend WithEvents imgProc As System.Windows.Forms.PictureBox
    Friend WithEvents groupCodigo As System.Windows.Forms.GroupBox
    Friend WithEvents dtgCodigo As System.Windows.Forms.DataGridView
    Friend WithEvents txtDesc As System.Windows.Forms.TextBox
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnCerrarEditResp As System.Windows.Forms.Button
    Friend WithEvents colOk As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents btn_transaccion As System.Windows.Forms.Button
    Friend WithEvents group_transaccion As System.Windows.Forms.GroupBox
    Friend WithEvents Modelo As System.Windows.Forms.Label
    Friend WithEvents cbo_modelo As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cbo_bodega As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cbo_tipo As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboFechaSol As System.Windows.Forms.DateTimePicker
    Friend WithEvents colNuevo As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents colBorrar As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents cboCentro As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents ColNumDet As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCodigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDesc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCant As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colStock_b1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colStock_b5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCosto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colMedida As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col_cant_entregada As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
