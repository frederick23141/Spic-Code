<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_gestionar_procedimientos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_gestionar_procedimientos))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboFechaCreacion = New System.Windows.Forms.DateTimePicker()
        Me.txtNombProc = New System.Windows.Forms.TextBox()
        Me.Toolbar1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnNuevo = New System.Windows.Forms.ToolStripButton()
        Me.btnGuardar = New System.Windows.Forms.ToolStripButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lbl1 = New System.Windows.Forms.Label()
        Me.txtCod = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtVersion = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboElabora = New System.Windows.Forms.ComboBox()
        Me.dtgPasos = New System.Windows.Forms.DataGridView()
        Me.colAdd = New System.Windows.Forms.DataGridViewImageColumn()
        Me.colSolCambio = New System.Windows.Forms.DataGridViewImageColumn()
        Me.colSave = New System.Windows.Forms.DataGridViewImageColumn()
        Me.colDelete = New System.Windows.Forms.DataGridViewImageColumn()
        Me.colId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colNitResponsable = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colNombResponsable = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colActividad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.menStripDtg = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.itemEditResp = New System.Windows.Forms.ToolStripMenuItem()
        Me.lbl2 = New System.Windows.Forms.Label()
        Me.cboRevisa = New System.Windows.Forms.ComboBox()
        Me.lbl3 = New System.Windows.Forms.Label()
        Me.cboAprueba = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboFechaMod = New System.Windows.Forms.DateTimePicker()
        Me.GroupBuscResp = New System.Windows.Forms.GroupBox()
        Me.txtBuscNomb = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dtgConsultResp = New System.Windows.Forms.DataGridView()
        Me.colNitOk = New System.Windows.Forms.DataGridViewImageColumn()
        Me.btnCerrarResp = New System.Windows.Forms.Button()
        Me.groupSolCambio = New System.Windows.Forms.GroupBox()
        Me.btnSolCambio = New System.Windows.Forms.Button()
        Me.txtDescCambio = New System.Windows.Forms.RichTextBox()
        Me.btnCerrarSolCambio = New System.Windows.Forms.Button()
        Me.group_edit_resp = New System.Windows.Forms.GroupBox()
        Me.dtgEditResponsable = New System.Windows.Forms.DataGridView()
        Me.colBorrarResp = New System.Windows.Forms.DataGridViewImageColumn()
        Me.colNitEditResp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colNombEditResp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnCerrarEditResp = New System.Windows.Forms.Button()
        Me.txtObjetivo = New System.Windows.Forms.RichTextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Toolbar1.SuspendLayout()
        CType(Me.dtgPasos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.menStripDtg.SuspendLayout()
        Me.GroupBuscResp.SuspendLayout()
        CType(Me.dtgConsultResp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.groupSolCambio.SuspendLayout()
        Me.group_edit_resp.SuspendLayout()
        CType(Me.dtgEditResponsable, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(2, 70)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(95, 13)
        Me.Label1.TabIndex = 1043
        Me.Label1.Text = "Fecha creación"
        '
        'cboFechaCreacion
        '
        Me.cboFechaCreacion.Location = New System.Drawing.Point(98, 67)
        Me.cboFechaCreacion.Name = "cboFechaCreacion"
        Me.cboFechaCreacion.Size = New System.Drawing.Size(213, 20)
        Me.cboFechaCreacion.TabIndex = 1044
        '
        'txtNombProc
        '
        Me.txtNombProc.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNombProc.Location = New System.Drawing.Point(5, 44)
        Me.txtNombProc.Name = "txtNombProc"
        Me.txtNombProc.Size = New System.Drawing.Size(504, 20)
        Me.txtNombProc.TabIndex = 1047
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
        Me.Toolbar1.Size = New System.Drawing.Size(732, 28)
        Me.Toolbar1.TabIndex = 1048
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
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(2, 28)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(133, 13)
        Me.Label3.TabIndex = 1049
        Me.Label3.Text = "Nombre procedimiento"
        '
        'lbl1
        '
        Me.lbl1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl1.AutoSize = True
        Me.lbl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl1.Location = New System.Drawing.Point(513, 28)
        Me.lbl1.Name = "lbl1"
        Me.lbl1.Size = New System.Drawing.Size(50, 13)
        Me.lbl1.TabIndex = 1051
        Me.lbl1.Text = "Código:"
        '
        'txtCod
        '
        Me.txtCod.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCod.Location = New System.Drawing.Point(515, 44)
        Me.txtCod.Name = "txtCod"
        Me.txtCod.Size = New System.Drawing.Size(105, 20)
        Me.txtCod.TabIndex = 1050
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(623, 28)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 13)
        Me.Label4.TabIndex = 1053
        Me.Label4.Text = "Versión:"
        '
        'txtVersion
        '
        Me.txtVersion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtVersion.Location = New System.Drawing.Point(626, 44)
        Me.txtVersion.Name = "txtVersion"
        Me.txtVersion.Size = New System.Drawing.Size(104, 20)
        Me.txtVersion.TabIndex = 1052
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(-3, 413)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(50, 13)
        Me.Label5.TabIndex = 1054
        Me.Label5.Text = "Elabora"
        '
        'cboElabora
        '
        Me.cboElabora.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cboElabora.FormattingEnabled = True
        Me.cboElabora.Location = New System.Drawing.Point(0, 428)
        Me.cboElabora.Name = "cboElabora"
        Me.cboElabora.Size = New System.Drawing.Size(240, 21)
        Me.cboElabora.TabIndex = 1055
        Me.cboElabora.Text = "Seleccione"
        '
        'dtgPasos
        '
        Me.dtgPasos.AllowUserToAddRows = False
        Me.dtgPasos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtgPasos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dtgPasos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtgPasos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dtgPasos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgPasos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colAdd, Me.colSolCambio, Me.colSave, Me.colDelete, Me.colId, Me.colNitResponsable, Me.colNombResponsable, Me.colActividad})
        Me.dtgPasos.ContextMenuStrip = Me.menStripDtg
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgPasos.DefaultCellStyle = DataGridViewCellStyle2
        Me.dtgPasos.Location = New System.Drawing.Point(5, 91)
        Me.dtgPasos.Name = "dtgPasos"
        Me.dtgPasos.RowHeadersVisible = False
        Me.dtgPasos.Size = New System.Drawing.Size(725, 282)
        Me.dtgPasos.TabIndex = 1060
        '
        'colAdd
        '
        Me.colAdd.HeaderText = ""
        Me.colAdd.Image = Global.Spic.My.Resources.Resources.nuevo
        Me.colAdd.Name = "colAdd"
        Me.colAdd.Width = 5
        '
        'colSolCambio
        '
        Me.colSolCambio.HeaderText = ""
        Me.colSolCambio.Image = Global.Spic.My.Resources.Resources.cambio
        Me.colSolCambio.Name = "colSolCambio"
        Me.colSolCambio.Width = 5
        '
        'colSave
        '
        Me.colSave.HeaderText = ""
        Me.colSave.Image = Global.Spic.My.Resources.Resources.save_16
        Me.colSave.Name = "colSave"
        Me.colSave.Width = 5
        '
        'colDelete
        '
        Me.colDelete.HeaderText = ""
        Me.colDelete.Image = Global.Spic.My.Resources.Resources.x
        Me.colDelete.Name = "colDelete"
        Me.colDelete.Width = 5
        '
        'colId
        '
        Me.colId.HeaderText = "ID"
        Me.colId.Name = "colId"
        Me.colId.ReadOnly = True
        Me.colId.Width = 43
        '
        'colNitResponsable
        '
        Me.colNitResponsable.HeaderText = "nitResponsable"
        Me.colNitResponsable.Name = "colNitResponsable"
        Me.colNitResponsable.Visible = False
        Me.colNitResponsable.Width = 105
        '
        'colNombResponsable
        '
        Me.colNombResponsable.HeaderText = "RESPONSABLE"
        Me.colNombResponsable.Name = "colNombResponsable"
        Me.colNombResponsable.ReadOnly = True
        Me.colNombResponsable.Width = 111
        '
        'colActividad
        '
        Me.colActividad.HeaderText = "ACTIVIDADES CLAVES"
        Me.colActividad.Name = "colActividad"
        Me.colActividad.Width = 147
        '
        'menStripDtg
        '
        Me.menStripDtg.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.menStripDtg.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.itemEditResp})
        Me.menStripDtg.Name = "ContextMenuStrip1"
        Me.menStripDtg.Size = New System.Drawing.Size(186, 26)
        '
        'itemEditResp
        '
        Me.itemEditResp.Image = Global.Spic.My.Resources.Resources.edit
        Me.itemEditResp.Name = "itemEditResp"
        Me.itemEditResp.Size = New System.Drawing.Size(185, 22)
        Me.itemEditResp.Text = "Editar responsables"
        '
        'lbl2
        '
        Me.lbl2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbl2.AutoSize = True
        Me.lbl2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl2.Location = New System.Drawing.Point(243, 413)
        Me.lbl2.Name = "lbl2"
        Me.lbl2.Size = New System.Drawing.Size(46, 13)
        Me.lbl2.TabIndex = 1061
        Me.lbl2.Text = "Revisa"
        '
        'cboRevisa
        '
        Me.cboRevisa.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cboRevisa.FormattingEnabled = True
        Me.cboRevisa.Location = New System.Drawing.Point(246, 428)
        Me.cboRevisa.Name = "cboRevisa"
        Me.cboRevisa.Size = New System.Drawing.Size(240, 21)
        Me.cboRevisa.TabIndex = 1062
        Me.cboRevisa.Text = "Seleccione"
        '
        'lbl3
        '
        Me.lbl3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbl3.AutoSize = True
        Me.lbl3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl3.Location = New System.Drawing.Point(489, 413)
        Me.lbl3.Name = "lbl3"
        Me.lbl3.Size = New System.Drawing.Size(54, 13)
        Me.lbl3.TabIndex = 1063
        Me.lbl3.Text = "Aprueba"
        '
        'cboAprueba
        '
        Me.cboAprueba.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cboAprueba.FormattingEnabled = True
        Me.cboAprueba.Location = New System.Drawing.Point(492, 428)
        Me.cboAprueba.Name = "cboAprueba"
        Me.cboAprueba.Size = New System.Drawing.Size(240, 21)
        Me.cboAprueba.TabIndex = 1064
        Me.cboAprueba.Text = "Seleccione"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(317, 70)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(117, 13)
        Me.Label2.TabIndex = 1065
        Me.Label2.Text = "Fecha mofidicación"
        '
        'cboFechaMod
        '
        Me.cboFechaMod.Location = New System.Drawing.Point(436, 67)
        Me.cboFechaMod.Name = "cboFechaMod"
        Me.cboFechaMod.Size = New System.Drawing.Size(212, 20)
        Me.cboFechaMod.TabIndex = 1066
        '
        'GroupBuscResp
        '
        Me.GroupBuscResp.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBuscResp.Controls.Add(Me.txtBuscNomb)
        Me.GroupBuscResp.Controls.Add(Me.Label6)
        Me.GroupBuscResp.Controls.Add(Me.dtgConsultResp)
        Me.GroupBuscResp.Controls.Add(Me.btnCerrarResp)
        Me.GroupBuscResp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBuscResp.Location = New System.Drawing.Point(105, 132)
        Me.GroupBuscResp.Name = "GroupBuscResp"
        Me.GroupBuscResp.Size = New System.Drawing.Size(523, 237)
        Me.GroupBuscResp.TabIndex = 1067
        Me.GroupBuscResp.TabStop = False
        Me.GroupBuscResp.Text = "Buscar responsable"
        Me.GroupBuscResp.Visible = False
        '
        'txtBuscNomb
        '
        Me.txtBuscNomb.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtBuscNomb.BackColor = System.Drawing.Color.White
        Me.txtBuscNomb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBuscNomb.Location = New System.Drawing.Point(66, 12)
        Me.txtBuscNomb.Name = "txtBuscNomb"
        Me.txtBuscNomb.Size = New System.Drawing.Size(286, 20)
        Me.txtBuscNomb.TabIndex = 1054
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(5, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(60, 13)
        Me.Label6.TabIndex = 1053
        Me.Label6.Text = "Nombres:"
        '
        'dtgConsultResp
        '
        Me.dtgConsultResp.AllowUserToAddRows = False
        Me.dtgConsultResp.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtgConsultResp.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dtgConsultResp.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dtgConsultResp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgConsultResp.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colNitOk})
        Me.dtgConsultResp.Location = New System.Drawing.Point(7, 38)
        Me.dtgConsultResp.Name = "dtgConsultResp"
        Me.dtgConsultResp.RowHeadersVisible = False
        Me.dtgConsultResp.Size = New System.Drawing.Size(510, 191)
        Me.dtgConsultResp.TabIndex = 1
        '
        'colNitOk
        '
        Me.colNitOk.HeaderText = ""
        Me.colNitOk.Image = Global.Spic.My.Resources.Resources.flecha1
        Me.colNitOk.Name = "colNitOk"
        Me.colNitOk.Width = 5
        '
        'btnCerrarResp
        '
        Me.btnCerrarResp.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCerrarResp.ForeColor = System.Drawing.Color.Red
        Me.btnCerrarResp.Location = New System.Drawing.Point(495, 7)
        Me.btnCerrarResp.Name = "btnCerrarResp"
        Me.btnCerrarResp.Size = New System.Drawing.Size(26, 23)
        Me.btnCerrarResp.TabIndex = 0
        Me.btnCerrarResp.Text = "X"
        Me.btnCerrarResp.UseVisualStyleBackColor = True
        '
        'groupSolCambio
        '
        Me.groupSolCambio.Controls.Add(Me.btnSolCambio)
        Me.groupSolCambio.Controls.Add(Me.txtDescCambio)
        Me.groupSolCambio.Controls.Add(Me.btnCerrarSolCambio)
        Me.groupSolCambio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.groupSolCambio.Location = New System.Drawing.Point(125, 132)
        Me.groupSolCambio.Name = "groupSolCambio"
        Me.groupSolCambio.Size = New System.Drawing.Size(523, 237)
        Me.groupSolCambio.TabIndex = 1068
        Me.groupSolCambio.TabStop = False
        Me.groupSolCambio.Text = "Solicitud de cambio"
        Me.groupSolCambio.Visible = False
        '
        'btnSolCambio
        '
        Me.btnSolCambio.Image = Global.Spic.My.Resources.Resources.enviar
        Me.btnSolCambio.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSolCambio.Location = New System.Drawing.Point(6, 17)
        Me.btnSolCambio.Name = "btnSolCambio"
        Me.btnSolCambio.Size = New System.Drawing.Size(79, 23)
        Me.btnSolCambio.TabIndex = 2
        Me.btnSolCambio.Text = "Solicitar"
        Me.btnSolCambio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSolCambio.UseVisualStyleBackColor = True
        '
        'txtDescCambio
        '
        Me.txtDescCambio.Location = New System.Drawing.Point(2, 46)
        Me.txtDescCambio.Name = "txtDescCambio"
        Me.txtDescCambio.Size = New System.Drawing.Size(515, 183)
        Me.txtDescCambio.TabIndex = 1
        Me.txtDescCambio.Text = ""
        '
        'btnCerrarSolCambio
        '
        Me.btnCerrarSolCambio.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCerrarSolCambio.ForeColor = System.Drawing.Color.Red
        Me.btnCerrarSolCambio.Location = New System.Drawing.Point(495, 7)
        Me.btnCerrarSolCambio.Name = "btnCerrarSolCambio"
        Me.btnCerrarSolCambio.Size = New System.Drawing.Size(26, 23)
        Me.btnCerrarSolCambio.TabIndex = 0
        Me.btnCerrarSolCambio.Text = "X"
        Me.btnCerrarSolCambio.UseVisualStyleBackColor = True
        '
        'group_edit_resp
        '
        Me.group_edit_resp.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.group_edit_resp.Controls.Add(Me.dtgEditResponsable)
        Me.group_edit_resp.Controls.Add(Me.btnCerrarEditResp)
        Me.group_edit_resp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.group_edit_resp.Location = New System.Drawing.Point(171, 126)
        Me.group_edit_resp.Name = "group_edit_resp"
        Me.group_edit_resp.Size = New System.Drawing.Size(523, 237)
        Me.group_edit_resp.TabIndex = 1068
        Me.group_edit_resp.TabStop = False
        Me.group_edit_resp.Text = "Editar responsables"
        Me.group_edit_resp.Visible = False
        '
        'dtgEditResponsable
        '
        Me.dtgEditResponsable.AllowUserToAddRows = False
        Me.dtgEditResponsable.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtgEditResponsable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dtgEditResponsable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dtgEditResponsable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgEditResponsable.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colBorrarResp, Me.colNitEditResp, Me.colNombEditResp})
        Me.dtgEditResponsable.Location = New System.Drawing.Point(7, 38)
        Me.dtgEditResponsable.Name = "dtgEditResponsable"
        Me.dtgEditResponsable.RowHeadersVisible = False
        Me.dtgEditResponsable.Size = New System.Drawing.Size(510, 191)
        Me.dtgEditResponsable.TabIndex = 1
        '
        'colBorrarResp
        '
        Me.colBorrarResp.Frozen = True
        Me.colBorrarResp.HeaderText = ""
        Me.colBorrarResp.Image = Global.Spic.My.Resources.Resources.x
        Me.colBorrarResp.Name = "colBorrarResp"
        Me.colBorrarResp.Width = 5
        '
        'colNitEditResp
        '
        Me.colNitEditResp.HeaderText = "nit"
        Me.colNitEditResp.Name = "colNitEditResp"
        Me.colNitEditResp.ReadOnly = True
        Me.colNitEditResp.Width = 46
        '
        'colNombEditResp
        '
        Me.colNombEditResp.HeaderText = "nombres"
        Me.colNombEditResp.Name = "colNombEditResp"
        Me.colNombEditResp.ReadOnly = True
        Me.colNombEditResp.Width = 79
        '
        'btnCerrarEditResp
        '
        Me.btnCerrarEditResp.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCerrarEditResp.ForeColor = System.Drawing.Color.Red
        Me.btnCerrarEditResp.Location = New System.Drawing.Point(495, 7)
        Me.btnCerrarEditResp.Name = "btnCerrarEditResp"
        Me.btnCerrarEditResp.Size = New System.Drawing.Size(26, 23)
        Me.btnCerrarEditResp.TabIndex = 0
        Me.btnCerrarEditResp.Text = "X"
        Me.btnCerrarEditResp.UseVisualStyleBackColor = True
        '
        'txtObjetivo
        '
        Me.txtObjetivo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtObjetivo.Location = New System.Drawing.Point(61, 377)
        Me.txtObjetivo.Name = "txtObjetivo"
        Me.txtObjetivo.Size = New System.Drawing.Size(667, 34)
        Me.txtObjetivo.TabIndex = 1069
        Me.txtObjetivo.Text = ""
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(3, 378)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(58, 13)
        Me.Label7.TabIndex = 1070
        Me.Label7.Text = "Objetivo:"
        '
        'Frm_gestionar_procedimientos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(732, 452)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtObjetivo)
        Me.Controls.Add(Me.group_edit_resp)
        Me.Controls.Add(Me.groupSolCambio)
        Me.Controls.Add(Me.GroupBuscResp)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboFechaMod)
        Me.Controls.Add(Me.lbl3)
        Me.Controls.Add(Me.cboAprueba)
        Me.Controls.Add(Me.lbl2)
        Me.Controls.Add(Me.cboRevisa)
        Me.Controls.Add(Me.dtgPasos)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cboElabora)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtVersion)
        Me.Controls.Add(Me.lbl1)
        Me.Controls.Add(Me.txtCod)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Toolbar1)
        Me.Controls.Add(Me.txtNombProc)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboFechaCreacion)
        Me.Name = "Frm_gestionar_procedimientos"
        Me.Text = "Crear procedimiento"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Toolbar1.ResumeLayout(False)
        Me.Toolbar1.PerformLayout()
        CType(Me.dtgPasos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.menStripDtg.ResumeLayout(False)
        Me.GroupBuscResp.ResumeLayout(False)
        Me.GroupBuscResp.PerformLayout()
        CType(Me.dtgConsultResp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.groupSolCambio.ResumeLayout(False)
        Me.group_edit_resp.ResumeLayout(False)
        CType(Me.dtgEditResponsable, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboFechaCreacion As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtNombProc As System.Windows.Forms.TextBox
    Friend WithEvents Toolbar1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lbl1 As System.Windows.Forms.Label
    Friend WithEvents txtCod As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtVersion As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboElabora As System.Windows.Forms.ComboBox
    Friend WithEvents dtgPasos As System.Windows.Forms.DataGridView
    Friend WithEvents lbl2 As System.Windows.Forms.Label
    Friend WithEvents cboRevisa As System.Windows.Forms.ComboBox
    Friend WithEvents lbl3 As System.Windows.Forms.Label
    Friend WithEvents cboAprueba As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboFechaMod As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBuscResp As System.Windows.Forms.GroupBox
    Friend WithEvents txtBuscNomb As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dtgConsultResp As System.Windows.Forms.DataGridView
    Friend WithEvents colNitOk As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents btnCerrarResp As System.Windows.Forms.Button
    Friend WithEvents colAdd As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents colSolCambio As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents colSave As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents colDelete As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents colId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colNitResponsable As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colNombResponsable As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colActividad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents groupSolCambio As System.Windows.Forms.GroupBox
    Friend WithEvents txtDescCambio As System.Windows.Forms.RichTextBox
    Friend WithEvents btnCerrarSolCambio As System.Windows.Forms.Button
    Friend WithEvents btnSolCambio As System.Windows.Forms.Button
    Friend WithEvents group_edit_resp As System.Windows.Forms.GroupBox
    Friend WithEvents dtgEditResponsable As System.Windows.Forms.DataGridView
    Friend WithEvents btnCerrarEditResp As System.Windows.Forms.Button
    Friend WithEvents colBorrarResp As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents colNitEditResp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colNombEditResp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents menStripDtg As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents itemEditResp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtObjetivo As System.Windows.Forms.RichTextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
End Class
