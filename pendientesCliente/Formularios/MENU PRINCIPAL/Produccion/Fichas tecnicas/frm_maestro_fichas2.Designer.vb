<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_maestro_fichas2
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
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Toolbar1 = New System.Windows.Forms.ToolStrip()
        Me.btnNuevo = New System.Windows.Forms.ToolStripButton()
        Me.btn_consultar = New System.Windows.Forms.ToolStripButton()
        Me.btn_excel = New System.Windows.Forms.ToolStripButton()
        Me.dtg_fichas = New System.Windows.Forms.DataGridView()
        Me.btnDelete = New System.Windows.Forms.DataGridViewImageColumn()
        Me.btnEdit = New System.Windows.Forms.DataGridViewImageColumn()
        Me.group_filtro = New System.Windows.Forms.GroupBox()
        Me.btn_buscar_cliente_fil = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txt_cliente_fil = New System.Windows.Forms.TextBox()
        Me.txt_codigo_fil = New System.Windows.Forms.TextBox()
        Me.group_ficha = New System.Windows.Forms.GroupBox()
        Me.btn_cancelar = New System.Windows.Forms.Button()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txt_nota = New System.Windows.Forms.TextBox()
        Me.btn_buscar_cliente = New System.Windows.Forms.Button()
        Me.btn_guardar = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtCliente = New System.Windows.Forms.TextBox()
        Me.txtCal = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cboOrigen = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtRec = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtResis = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.groupCliente = New System.Windows.Forms.GroupBox()
        Me.btn_cerrar = New System.Windows.Forms.Button()
        Me.txt_nombres = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.dtg_clientes = New System.Windows.Forms.DataGridView()
        Me.colOk = New System.Windows.Forms.DataGridViewImageColumn()
        Me.txt_nit = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtDiametro = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Toolbar1.SuspendLayout()
        CType(Me.dtg_fichas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.group_filtro.SuspendLayout()
        Me.group_ficha.SuspendLayout()
        Me.groupCliente.SuspendLayout()
        CType(Me.dtg_clientes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Toolbar1
        '
        Me.Toolbar1.AutoSize = False
        Me.Toolbar1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Toolbar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Toolbar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Toolbar1.ImageScalingSize = New System.Drawing.Size(23, 23)
        Me.Toolbar1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnNuevo, Me.btn_consultar, Me.btn_excel})
        Me.Toolbar1.Location = New System.Drawing.Point(0, 0)
        Me.Toolbar1.Name = "Toolbar1"
        Me.Toolbar1.Size = New System.Drawing.Size(817, 30)
        Me.Toolbar1.TabIndex = 1044
        Me.Toolbar1.Text = "ToolStrip1"
        '
        'btnNuevo
        '
        Me.btnNuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnNuevo.Image = Global.Spic.My.Resources.Resources.nuevo
        Me.btnNuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(27, 27)
        Me.btnNuevo.Text = "Nuevo"
        '
        'btn_consultar
        '
        Me.btn_consultar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_consultar.Image = Global.Spic.My.Resources.Resources.update
        Me.btn_consultar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_consultar.Name = "btn_consultar"
        Me.btn_consultar.Size = New System.Drawing.Size(27, 27)
        Me.btn_consultar.Text = "Modificar"
        '
        'btn_excel
        '
        Me.btn_excel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_excel.Image = Global.Spic.My.Resources.Resources.excel10
        Me.btn_excel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_excel.Name = "btn_excel"
        Me.btn_excel.Size = New System.Drawing.Size(27, 27)
        Me.btn_excel.Text = "ToolStripButton1"
        '
        'dtg_fichas
        '
        Me.dtg_fichas.AllowUserToAddRows = False
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.Silver
        Me.dtg_fichas.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle6
        Me.dtg_fichas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtg_fichas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dtg_fichas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dtg_fichas.BackgroundColor = System.Drawing.SystemColors.ControlLight
        Me.dtg_fichas.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dtg_fichas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dtg_fichas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtg_fichas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.btnDelete, Me.btnEdit})
        Me.dtg_fichas.Location = New System.Drawing.Point(12, 91)
        Me.dtg_fichas.MultiSelect = False
        Me.dtg_fichas.Name = "dtg_fichas"
        Me.dtg_fichas.ReadOnly = True
        Me.dtg_fichas.RowHeadersVisible = False
        Me.dtg_fichas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtg_fichas.Size = New System.Drawing.Size(497, 530)
        Me.dtg_fichas.TabIndex = 1045
        '
        'btnDelete
        '
        Me.btnDelete.Frozen = True
        Me.btnDelete.HeaderText = ""
        Me.btnDelete.Image = Global.Spic.My.Resources.Resources.x
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.ReadOnly = True
        Me.btnDelete.Width = 5
        '
        'btnEdit
        '
        Me.btnEdit.Frozen = True
        Me.btnEdit.HeaderText = ""
        Me.btnEdit.Image = Global.Spic.My.Resources.Resources.edit
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.ReadOnly = True
        Me.btnEdit.Width = 5
        '
        'group_filtro
        '
        Me.group_filtro.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.group_filtro.Controls.Add(Me.btn_buscar_cliente_fil)
        Me.group_filtro.Controls.Add(Me.Label2)
        Me.group_filtro.Controls.Add(Me.Label1)
        Me.group_filtro.Controls.Add(Me.txt_cliente_fil)
        Me.group_filtro.Controls.Add(Me.txt_codigo_fil)
        Me.group_filtro.Location = New System.Drawing.Point(220, 33)
        Me.group_filtro.Name = "group_filtro"
        Me.group_filtro.Size = New System.Drawing.Size(408, 52)
        Me.group_filtro.TabIndex = 1046
        Me.group_filtro.TabStop = False
        Me.group_filtro.Text = "Filtro"
        '
        'btn_buscar_cliente_fil
        '
        Me.btn_buscar_cliente_fil.Image = Global.Spic.My.Resources.Resources._1385696421_search
        Me.btn_buscar_cliente_fil.Location = New System.Drawing.Point(365, 13)
        Me.btn_buscar_cliente_fil.Name = "btn_buscar_cliente_fil"
        Me.btn_buscar_cliente_fil.Size = New System.Drawing.Size(32, 32)
        Me.btn_buscar_cliente_fil.TabIndex = 1047
        Me.btn_buscar_cliente_fil.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(189, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 16)
        Me.Label2.TabIndex = 1048
        Me.Label2.Text = "Cliente:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(10, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 16)
        Me.Label1.TabIndex = 1047
        Me.Label1.Text = "Codigo:"
        '
        'txt_cliente_fil
        '
        Me.txt_cliente_fil.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txt_cliente_fil.Enabled = False
        Me.txt_cliente_fil.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_cliente_fil.Location = New System.Drawing.Point(253, 22)
        Me.txt_cliente_fil.Name = "txt_cliente_fil"
        Me.txt_cliente_fil.Size = New System.Drawing.Size(106, 15)
        Me.txt_cliente_fil.TabIndex = 1
        '
        'txt_codigo_fil
        '
        Me.txt_codigo_fil.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txt_codigo_fil.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_codigo_fil.Location = New System.Drawing.Point(73, 22)
        Me.txt_codigo_fil.Name = "txt_codigo_fil"
        Me.txt_codigo_fil.Size = New System.Drawing.Size(100, 15)
        Me.txt_codigo_fil.TabIndex = 0
        '
        'group_ficha
        '
        Me.group_ficha.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.group_ficha.Controls.Add(Me.Label14)
        Me.group_ficha.Controls.Add(Me.txtDiametro)
        Me.group_ficha.Controls.Add(Me.Label18)
        Me.group_ficha.Controls.Add(Me.btn_cancelar)
        Me.group_ficha.Controls.Add(Me.Label19)
        Me.group_ficha.Controls.Add(Me.Label17)
        Me.group_ficha.Controls.Add(Me.Label16)
        Me.group_ficha.Controls.Add(Me.Label15)
        Me.group_ficha.Controls.Add(Me.Label13)
        Me.group_ficha.Controls.Add(Me.Label12)
        Me.group_ficha.Controls.Add(Me.Label9)
        Me.group_ficha.Controls.Add(Me.txt_nota)
        Me.group_ficha.Controls.Add(Me.btn_buscar_cliente)
        Me.group_ficha.Controls.Add(Me.btn_guardar)
        Me.group_ficha.Controls.Add(Me.Label8)
        Me.group_ficha.Controls.Add(Me.txtCliente)
        Me.group_ficha.Controls.Add(Me.txtCal)
        Me.group_ficha.Controls.Add(Me.Label7)
        Me.group_ficha.Controls.Add(Me.cboOrigen)
        Me.group_ficha.Controls.Add(Me.Label6)
        Me.group_ficha.Controls.Add(Me.txtRec)
        Me.group_ficha.Controls.Add(Me.Label5)
        Me.group_ficha.Controls.Add(Me.txtResis)
        Me.group_ficha.Controls.Add(Me.Label4)
        Me.group_ficha.Controls.Add(Me.txtCodigo)
        Me.group_ficha.Controls.Add(Me.Label3)
        Me.group_ficha.Enabled = False
        Me.group_ficha.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.group_ficha.Location = New System.Drawing.Point(515, 91)
        Me.group_ficha.Name = "group_ficha"
        Me.group_ficha.Size = New System.Drawing.Size(290, 530)
        Me.group_ficha.TabIndex = 1047
        Me.group_ficha.TabStop = False
        Me.group_ficha.Text = "Informacion Ficha Tecnica"
        '
        'btn_cancelar
        '
        Me.btn_cancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_cancelar.Image = Global.Spic.My.Resources.Resources._1371749741_32447
        Me.btn_cancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_cancelar.Location = New System.Drawing.Point(13, 485)
        Me.btn_cancelar.Name = "btn_cancelar"
        Me.btn_cancelar.Size = New System.Drawing.Size(115, 39)
        Me.btn_cancelar.TabIndex = 1072
        Me.btn_cancelar.Text = "Cancelar"
        Me.btn_cancelar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_cancelar.UseVisualStyleBackColor = True
        '
        'Label19
        '
        Me.Label19.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, CType((System.Drawing.FontStyle.Italic Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.Red
        Me.Label19.Location = New System.Drawing.Point(10, 454)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(256, 15)
        Me.Label19.TabIndex = 1071
        Me.Label19.Text = "Los campos marcados con * son obligatorios."
        Me.Label19.Visible = False
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Red
        Me.Label17.Location = New System.Drawing.Point(79, 310)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(15, 18)
        Me.Label17.TabIndex = 1069
        Me.Label17.Text = "*"
        Me.Label17.Visible = False
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Red
        Me.Label16.Location = New System.Drawing.Point(79, 255)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(15, 18)
        Me.Label16.TabIndex = 1068
        Me.Label16.Text = "*"
        Me.Label16.Visible = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Red
        Me.Label15.Location = New System.Drawing.Point(113, 200)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(15, 18)
        Me.Label15.TabIndex = 1067
        Me.Label15.Text = "*"
        Me.Label15.Visible = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Red
        Me.Label13.Location = New System.Drawing.Point(113, 65)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(15, 18)
        Me.Label13.TabIndex = 1065
        Me.Label13.Text = "*"
        Me.Label13.Visible = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Red
        Me.Label12.Location = New System.Drawing.Point(79, 23)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(15, 18)
        Me.Label12.TabIndex = 1064
        Me.Label12.Text = "*"
        Me.Label12.Visible = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(10, 358)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(49, 18)
        Me.Label9.TabIndex = 1063
        Me.Label9.Text = "Nota:"
        '
        'txt_nota
        '
        Me.txt_nota.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_nota.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txt_nota.Location = New System.Drawing.Point(11, 379)
        Me.txt_nota.Multiline = True
        Me.txt_nota.Name = "txt_nota"
        Me.txt_nota.Size = New System.Drawing.Size(269, 72)
        Me.txt_nota.TabIndex = 1062
        '
        'btn_buscar_cliente
        '
        Me.btn_buscar_cliente.Image = Global.Spic.My.Resources.Resources._1385696421_search
        Me.btn_buscar_cliente.Location = New System.Drawing.Point(252, 325)
        Me.btn_buscar_cliente.Name = "btn_buscar_cliente"
        Me.btn_buscar_cliente.Size = New System.Drawing.Size(32, 32)
        Me.btn_buscar_cliente.TabIndex = 1061
        Me.btn_buscar_cliente.UseVisualStyleBackColor = True
        '
        'btn_guardar
        '
        Me.btn_guardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_guardar.Image = Global.Spic.My.Resources.Resources._Save
        Me.btn_guardar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_guardar.Location = New System.Drawing.Point(169, 485)
        Me.btn_guardar.Name = "btn_guardar"
        Me.btn_guardar.Size = New System.Drawing.Size(111, 39)
        Me.btn_guardar.TabIndex = 1060
        Me.btn_guardar.Text = "Guardar"
        Me.btn_guardar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_guardar.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(8, 310)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(65, 18)
        Me.Label8.TabIndex = 1059
        Me.Label8.Text = "Cliente:"
        '
        'txtCliente
        '
        Me.txtCliente.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtCliente.Enabled = False
        Me.txtCliente.Location = New System.Drawing.Point(9, 331)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.Size = New System.Drawing.Size(242, 17)
        Me.txtCliente.TabIndex = 1058
        '
        'txtCal
        '
        Me.txtCal.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtCal.Location = New System.Drawing.Point(6, 282)
        Me.txtCal.Name = "txtCal"
        Me.txtCal.Size = New System.Drawing.Size(274, 17)
        Me.txtCal.TabIndex = 1057
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 255)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(69, 18)
        Me.Label7.TabIndex = 1056
        Me.Label7.Text = "Calidad:"
        '
        'cboOrigen
        '
        Me.cboOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboOrigen.FormattingEnabled = True
        Me.cboOrigen.Location = New System.Drawing.Point(6, 221)
        Me.cboOrigen.Name = "cboOrigen"
        Me.cboOrigen.Size = New System.Drawing.Size(274, 26)
        Me.cboOrigen.TabIndex = 1055
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 200)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(107, 18)
        Me.Label6.TabIndex = 1054
        Me.Label6.Text = "Procedencia:"
        '
        'txtRec
        '
        Me.txtRec.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtRec.Location = New System.Drawing.Point(6, 176)
        Me.txtRec.Name = "txtRec"
        Me.txtRec.Size = New System.Drawing.Size(274, 17)
        Me.txtRec.TabIndex = 1053
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 150)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(122, 18)
        Me.Label5.TabIndex = 1052
        Me.Label5.Text = "Recubrimiento:"
        '
        'txtResis
        '
        Me.txtResis.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtResis.Location = New System.Drawing.Point(6, 86)
        Me.txtResis.Name = "txtResis"
        Me.txtResis.Size = New System.Drawing.Size(274, 17)
        Me.txtResis.TabIndex = 1051
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 65)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(101, 18)
        Me.Label4.TabIndex = 1050
        Me.Label4.Text = "Resistencia:"
        '
        'txtCodigo
        '
        Me.txtCodigo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtCodigo.Location = New System.Drawing.Point(6, 42)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(274, 17)
        Me.txtCodigo.TabIndex = 1049
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 18)
        Me.Label3.TabIndex = 1048
        Me.Label3.Text = "Código:"
        '
        'groupCliente
        '
        Me.groupCliente.BackColor = System.Drawing.SystemColors.ControlDark
        Me.groupCliente.Controls.Add(Me.btn_cerrar)
        Me.groupCliente.Controls.Add(Me.txt_nombres)
        Me.groupCliente.Controls.Add(Me.Label10)
        Me.groupCliente.Controls.Add(Me.dtg_clientes)
        Me.groupCliente.Controls.Add(Me.txt_nit)
        Me.groupCliente.Controls.Add(Me.Label11)
        Me.groupCliente.Location = New System.Drawing.Point(159, 84)
        Me.groupCliente.Name = "groupCliente"
        Me.groupCliente.Size = New System.Drawing.Size(622, 351)
        Me.groupCliente.TabIndex = 1082
        Me.groupCliente.TabStop = False
        Me.groupCliente.Text = "Buscar cliente"
        Me.groupCliente.Visible = False
        '
        'btn_cerrar
        '
        Me.btn_cerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_cerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_cerrar.ForeColor = System.Drawing.Color.Red
        Me.btn_cerrar.Location = New System.Drawing.Point(583, 4)
        Me.btn_cerrar.Name = "btn_cerrar"
        Me.btn_cerrar.Size = New System.Drawing.Size(37, 23)
        Me.btn_cerrar.TabIndex = 1063
        Me.btn_cerrar.Text = "X"
        Me.btn_cerrar.UseVisualStyleBackColor = True
        '
        'txt_nombres
        '
        Me.txt_nombres.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txt_nombres.Location = New System.Drawing.Point(227, 26)
        Me.txt_nombres.Name = "txt_nombres"
        Me.txt_nombres.Size = New System.Drawing.Size(215, 13)
        Me.txt_nombres.TabIndex = 1062
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(165, 27)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(60, 13)
        Me.Label10.TabIndex = 1061
        Me.Label10.Text = "Nombres:"
        '
        'dtg_clientes
        '
        Me.dtg_clientes.AllowUserToAddRows = False
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dtg_clientes.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle7
        Me.dtg_clientes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtg_clientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dtg_clientes.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dtg_clientes.BackgroundColor = System.Drawing.SystemColors.ControlDark
        Me.dtg_clientes.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dtg_clientes.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtg_clientes.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.dtg_clientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtg_clientes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colOk})
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtg_clientes.DefaultCellStyle = DataGridViewCellStyle9
        Me.dtg_clientes.Location = New System.Drawing.Point(11, 60)
        Me.dtg_clientes.Name = "dtg_clientes"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtg_clientes.RowHeadersDefaultCellStyle = DataGridViewCellStyle10
        Me.dtg_clientes.RowHeadersVisible = False
        Me.dtg_clientes.Size = New System.Drawing.Size(597, 281)
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
        Me.txt_nit.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txt_nit.Location = New System.Drawing.Point(41, 25)
        Me.txt_nit.Name = "txt_nit"
        Me.txt_nit.Size = New System.Drawing.Size(114, 13)
        Me.txt_nit.TabIndex = 1060
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(8, 25)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(27, 13)
        Me.Label11.TabIndex = 1059
        Me.Label11.Text = "Nit:"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Red
        Me.Label14.Location = New System.Drawing.Point(115, 103)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(15, 18)
        Me.Label14.TabIndex = 1075
        Me.Label14.Text = "*"
        Me.Label14.Visible = False
        '
        'txtDiametro
        '
        Me.txtDiametro.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtDiametro.Location = New System.Drawing.Point(8, 129)
        Me.txtDiametro.Name = "txtDiametro"
        Me.txtDiametro.Size = New System.Drawing.Size(274, 17)
        Me.txtDiametro.TabIndex = 1074
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(8, 103)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(82, 18)
        Me.Label18.TabIndex = 1073
        Me.Label18.Text = "Diametro:"
        '
        'frm_maestro_fichas2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ClientSize = New System.Drawing.Size(817, 633)
        Me.Controls.Add(Me.groupCliente)
        Me.Controls.Add(Me.group_ficha)
        Me.Controls.Add(Me.group_filtro)
        Me.Controls.Add(Me.dtg_fichas)
        Me.Controls.Add(Me.Toolbar1)
        Me.Name = "frm_maestro_fichas2"
        Me.Text = "Maestro de Fichas Tecnicas"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Toolbar1.ResumeLayout(False)
        Me.Toolbar1.PerformLayout()
        CType(Me.dtg_fichas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.group_filtro.ResumeLayout(False)
        Me.group_filtro.PerformLayout()
        Me.group_ficha.ResumeLayout(False)
        Me.group_ficha.PerformLayout()
        Me.groupCliente.ResumeLayout(False)
        Me.groupCliente.PerformLayout()
        CType(Me.dtg_clientes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Toolbar1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents btn_consultar As System.Windows.Forms.ToolStripButton
    Friend WithEvents dtg_fichas As System.Windows.Forms.DataGridView
    Friend WithEvents btnDelete As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents btnEdit As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents group_filtro As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_cliente_fil As System.Windows.Forms.TextBox
    Friend WithEvents txt_codigo_fil As System.Windows.Forms.TextBox
    Friend WithEvents btn_buscar_cliente_fil As System.Windows.Forms.Button
    Friend WithEvents group_ficha As System.Windows.Forms.GroupBox
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtResis As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtRec As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboOrigen As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtCal As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btn_guardar As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtCliente As System.Windows.Forms.TextBox
    Friend WithEvents btn_buscar_cliente As System.Windows.Forms.Button
    Friend WithEvents btn_excel As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txt_nota As System.Windows.Forms.TextBox
    Friend WithEvents groupCliente As System.Windows.Forms.GroupBox
    Friend WithEvents btn_cerrar As System.Windows.Forms.Button
    Friend WithEvents txt_nombres As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents dtg_clientes As System.Windows.Forms.DataGridView
    Friend WithEvents colOk As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents txt_nit As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents btn_cancelar As System.Windows.Forms.Button
    Friend WithEvents Label14 As Label
    Friend WithEvents txtDiametro As TextBox
    Friend WithEvents Label18 As Label
End Class
