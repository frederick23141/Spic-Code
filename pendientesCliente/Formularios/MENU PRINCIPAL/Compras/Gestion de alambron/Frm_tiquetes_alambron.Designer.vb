<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_tiquetes_alambron
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cbo_modelo = New System.Windows.Forms.ComboBox()
        Me.txtNumImportacion = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbo_provedor = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cbo_tipo = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cbo_molino = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cbo_fecha = New System.Windows.Forms.DateTimePicker()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Toolbar1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnGuardar = New System.Windows.Forms.ToolStripButton()
        Me.btn_nuevo = New System.Windows.Forms.ToolStripButton()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dtg_consulta = New System.Windows.Forms.DataGridView()
        Me.col_id_det = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_imprimir = New System.Windows.Forms.DataGridViewImageColumn()
        Me.colBorrar = New System.Windows.Forms.DataGridViewImageColumn()
        Me.colAdd = New System.Windows.Forms.DataGridViewImageColumn()
        Me.colCodigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_desc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_costo_kilo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_cant = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_modificar = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cbo_consult_importacion = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.groupCodigo = New System.Windows.Forms.GroupBox()
        Me.btnCerrarEditResp = New System.Windows.Forms.Button()
        Me.txtDesc = New System.Windows.Forms.TextBox()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dtgCodigo = New System.Windows.Forms.DataGridView()
        Me.colOk = New System.Windows.Forms.DataGridViewImageColumn()
        Me.cbo_consult_prov = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btn_consult = New System.Windows.Forms.Button()
        Me.GroupBox2.SuspendLayout()
        Me.Toolbar1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dtg_consulta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.groupCodigo.SuspendLayout()
        CType(Me.dtgCodigo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.cbo_modelo)
        Me.GroupBox2.Controls.Add(Me.txtNumImportacion)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.groupCodigo)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.cbo_provedor)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.cbo_tipo)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.cbo_molino)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.cbo_fecha)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 92)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(599, 177)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Datos de compra de alambrón"
        '
        'cbo_modelo
        '
        Me.cbo_modelo.FormattingEnabled = True
        Me.cbo_modelo.Location = New System.Drawing.Point(135, 121)
        Me.cbo_modelo.Name = "cbo_modelo"
        Me.cbo_modelo.Size = New System.Drawing.Size(455, 21)
        Me.cbo_modelo.TabIndex = 1085
        Me.cbo_modelo.Text = "Seleccione"
        '
        'txtNumImportacion
        '
        Me.txtNumImportacion.BackColor = System.Drawing.Color.Lime
        Me.txtNumImportacion.Location = New System.Drawing.Point(135, 41)
        Me.txtNumImportacion.MaxLength = 33
        Me.txtNumImportacion.Name = "txtNumImportacion"
        Me.txtNumImportacion.Size = New System.Drawing.Size(455, 20)
        Me.txtNumImportacion.TabIndex = 1070
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(11, 44)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(123, 13)
        Me.Label4.TabIndex = 1069
        Me.Label4.Text = "Número importación:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(11, 121)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 13)
        Me.Label1.TabIndex = 1086
        Me.Label1.Text = "Modelo:"
        '
        'cbo_provedor
        '
        Me.cbo_provedor.FormattingEnabled = True
        Me.cbo_provedor.Location = New System.Drawing.Point(135, 14)
        Me.cbo_provedor.Name = "cbo_provedor"
        Me.cbo_provedor.Size = New System.Drawing.Size(455, 21)
        Me.cbo_provedor.TabIndex = 1083
        Me.cbo_provedor.Text = "Seleccione"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(11, 14)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(69, 13)
        Me.Label8.TabIndex = 1084
        Me.Label8.Text = "Proveedor:"
        '
        'cbo_tipo
        '
        Me.cbo_tipo.FormattingEnabled = True
        Me.cbo_tipo.Location = New System.Drawing.Point(135, 94)
        Me.cbo_tipo.Name = "cbo_tipo"
        Me.cbo_tipo.Size = New System.Drawing.Size(455, 21)
        Me.cbo_tipo.TabIndex = 1079
        Me.cbo_tipo.Text = "Seleccione"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(11, 94)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(124, 13)
        Me.Label5.TabIndex = 1080
        Me.Label5.Text = "Tipo de transacción:"
        '
        'cbo_molino
        '
        Me.cbo_molino.FormattingEnabled = True
        Me.cbo_molino.Location = New System.Drawing.Point(135, 67)
        Me.cbo_molino.Name = "cbo_molino"
        Me.cbo_molino.Size = New System.Drawing.Size(455, 21)
        Me.cbo_molino.TabIndex = 1046
        Me.cbo_molino.Text = "Seleccione"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(11, 70)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(52, 13)
        Me.Label10.TabIndex = 1078
        Me.Label10.Text = "Molino :"
        '
        'cbo_fecha
        '
        Me.cbo_fecha.Location = New System.Drawing.Point(135, 148)
        Me.cbo_fecha.Name = "cbo_fecha"
        Me.cbo_fecha.Size = New System.Drawing.Size(200, 20)
        Me.cbo_fecha.TabIndex = 1077
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(11, 154)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(46, 13)
        Me.Label7.TabIndex = 1076
        Me.Label7.Text = "Fecha:"
        '
        'Toolbar1
        '
        Me.Toolbar1.AutoSize = False
        Me.Toolbar1.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.Toolbar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Toolbar1.ImageScalingSize = New System.Drawing.Size(23, 23)
        Me.Toolbar1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator2, Me.ToolStripButton1, Me.ToolStripButton2, Me.ToolStripSeparator3, Me.btnGuardar, Me.btn_nuevo})
        Me.Toolbar1.Location = New System.Drawing.Point(0, 0)
        Me.Toolbar1.Name = "Toolbar1"
        Me.Toolbar1.Size = New System.Drawing.Size(623, 28)
        Me.Toolbar1.TabIndex = 1082
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
        'btnGuardar
        '
        Me.btnGuardar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnGuardar.Image = Global.Spic.My.Resources.Resources.save_16
        Me.btnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(27, 25)
        Me.btnGuardar.Text = "Guardar"
        '
        'btn_nuevo
        '
        Me.btn_nuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_nuevo.Image = Global.Spic.My.Resources.Resources.nuevo
        Me.btn_nuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_nuevo.Name = "btn_nuevo"
        Me.btn_nuevo.Size = New System.Drawing.Size(27, 25)
        Me.btn_nuevo.Text = "Nuevo"
        '
        'PrintDocument1
        '
        '
        'PrintDialog1
        '
        Me.PrintDialog1.Document = Me.PrintDocument1
        Me.PrintDialog1.UseEXDialog = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.dtg_consulta)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 278)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(599, 155)
        Me.GroupBox1.TabIndex = 1087
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Petición de tiquetes"
        '
        'dtg_consulta
        '
        Me.dtg_consulta.AllowUserToAddRows = False
        Me.dtg_consulta.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtg_consulta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dtg_consulta.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dtg_consulta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtg_consulta.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.col_id_det, Me.col_imprimir, Me.colBorrar, Me.colAdd, Me.colCodigo, Me.col_desc, Me.col_costo_kilo, Me.col_cant, Me.col_modificar})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.Format = "N0"
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtg_consulta.DefaultCellStyle = DataGridViewCellStyle2
        Me.dtg_consulta.Location = New System.Drawing.Point(6, 19)
        Me.dtg_consulta.Name = "dtg_consulta"
        Me.dtg_consulta.RowHeadersVisible = False
        Me.dtg_consulta.Size = New System.Drawing.Size(587, 130)
        Me.dtg_consulta.TabIndex = 1089
        '
        'col_id_det
        '
        Me.col_id_det.HeaderText = "id_det"
        Me.col_id_det.Name = "col_id_det"
        Me.col_id_det.ReadOnly = True
        Me.col_id_det.Width = 61
        '
        'col_imprimir
        '
        Me.col_imprimir.HeaderText = ""
        Me.col_imprimir.Image = Global.Spic.My.Resources.Resources.imp3
        Me.col_imprimir.Name = "col_imprimir"
        Me.col_imprimir.Width = 5
        '
        'colBorrar
        '
        Me.colBorrar.HeaderText = ""
        Me.colBorrar.Image = Global.Spic.My.Resources.Resources.x
        Me.colBorrar.Name = "colBorrar"
        Me.colBorrar.Width = 5
        '
        'colAdd
        '
        Me.colAdd.HeaderText = ""
        Me.colAdd.Image = Global.Spic.My.Resources.Resources.nuevo
        Me.colAdd.Name = "colAdd"
        Me.colAdd.Width = 5
        '
        'colCodigo
        '
        Me.colCodigo.HeaderText = "Código"
        Me.colCodigo.Name = "colCodigo"
        Me.colCodigo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colCodigo.Width = 65
        '
        'col_desc
        '
        Me.col_desc.HeaderText = "Descripción"
        Me.col_desc.Name = "col_desc"
        Me.col_desc.Width = 88
        '
        'col_costo_kilo
        '
        Me.col_costo_kilo.HeaderText = "Costo_kilo"
        Me.col_costo_kilo.Name = "col_costo_kilo"
        Me.col_costo_kilo.Width = 81
        '
        'col_cant
        '
        Me.col_cant.HeaderText = "Cantidad"
        Me.col_cant.Name = "col_cant"
        Me.col_cant.Width = 74
        '
        'col_modificar
        '
        Me.col_modificar.HeaderText = "modificable"
        Me.col_modificar.Name = "col_modificar"
        Me.col_modificar.ReadOnly = True
        Me.col_modificar.Visible = False
        Me.col_modificar.Width = 85
        '
        'cbo_consult_importacion
        '
        Me.cbo_consult_importacion.FormattingEnabled = True
        Me.cbo_consult_importacion.Location = New System.Drawing.Point(203, 65)
        Me.cbo_consult_importacion.Name = "cbo_consult_importacion"
        Me.cbo_consult_importacion.Size = New System.Drawing.Size(327, 21)
        Me.cbo_consult_importacion.TabIndex = 1087
        Me.cbo_consult_importacion.Text = "Seleccione"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(23, 67)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(178, 13)
        Me.Label2.TabIndex = 1088
        Me.Label2.Text = "Consultar numero importación:"
        '
        'groupCodigo
        '
        Me.groupCodigo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.groupCodigo.Controls.Add(Me.btnCerrarEditResp)
        Me.groupCodigo.Controls.Add(Me.txtDesc)
        Me.groupCodigo.Controls.Add(Me.txtCodigo)
        Me.groupCodigo.Controls.Add(Me.Label3)
        Me.groupCodigo.Controls.Add(Me.Label6)
        Me.groupCodigo.Controls.Add(Me.dtgCodigo)
        Me.groupCodigo.Location = New System.Drawing.Point(33, 121)
        Me.groupCodigo.Name = "groupCodigo"
        Me.groupCodigo.Size = New System.Drawing.Size(566, 247)
        Me.groupCodigo.TabIndex = 1090
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
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(6, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(50, 13)
        Me.Label6.TabIndex = 1041
        Me.Label6.Text = "Código:"
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
        'cbo_consult_prov
        '
        Me.cbo_consult_prov.FormattingEnabled = True
        Me.cbo_consult_prov.Location = New System.Drawing.Point(203, 38)
        Me.cbo_consult_prov.Name = "cbo_consult_prov"
        Me.cbo_consult_prov.Size = New System.Drawing.Size(327, 21)
        Me.cbo_consult_prov.TabIndex = 1087
        Me.cbo_consult_prov.Text = "Seleccione"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(129, 41)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(69, 13)
        Me.Label9.TabIndex = 1088
        Me.Label9.Text = "Proveedor:"
        '
        'btn_consult
        '
        Me.btn_consult.Image = Global.Spic.My.Resources.Resources.buscar7
        Me.btn_consult.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_consult.Location = New System.Drawing.Point(536, 50)
        Me.btn_consult.Name = "btn_consult"
        Me.btn_consult.Size = New System.Drawing.Size(75, 23)
        Me.btn_consult.TabIndex = 1091
        Me.btn_consult.Text = "Consultar"
        Me.btn_consult.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_consult.UseVisualStyleBackColor = True
        '
        'Frm_tiquetes_alambron
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(623, 438)
        Me.Controls.Add(Me.btn_consult)
        Me.Controls.Add(Me.cbo_consult_prov)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.cbo_consult_importacion)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Toolbar1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Name = "Frm_tiquetes_alambron"
        Me.Text = "Solicitud de tiquetes de alambrón"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.Toolbar1.ResumeLayout(False)
        Me.Toolbar1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dtg_consulta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.groupCodigo.ResumeLayout(False)
        Me.groupCodigo.PerformLayout()
        CType(Me.dtgCodigo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtNumImportacion As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Toolbar1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents cbo_fecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cbo_molino As System.Windows.Forms.ComboBox
    Friend WithEvents cbo_tipo As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cbo_provedor As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cbo_modelo As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dtg_consulta As System.Windows.Forms.DataGridView
    Friend WithEvents cbo_consult_importacion As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents groupCodigo As System.Windows.Forms.GroupBox
    Friend WithEvents btnCerrarEditResp As System.Windows.Forms.Button
    Friend WithEvents txtDesc As System.Windows.Forms.TextBox
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dtgCodigo As System.Windows.Forms.DataGridView
    Friend WithEvents colOk As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents cbo_consult_prov As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents btn_consult As System.Windows.Forms.Button
    Friend WithEvents btn_nuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents col_id_det As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col_imprimir As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents colBorrar As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents colAdd As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents colCodigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col_desc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col_costo_kilo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col_cant As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col_modificar As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
