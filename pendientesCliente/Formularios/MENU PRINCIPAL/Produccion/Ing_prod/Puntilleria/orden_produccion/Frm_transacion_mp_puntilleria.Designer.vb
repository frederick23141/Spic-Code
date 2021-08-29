<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_transacion_mp_puntilleria
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.tab_ppal = New System.Windows.Forms.TabControl()
        Me.tab_ped = New System.Windows.Forms.TabPage()
        Me.btn_actulizar = New System.Windows.Forms.Button()
        Me.btn_salir_pedido = New System.Windows.Forms.Button()
        Me.dtg_pedido = New System.Windows.Forms.DataGridView()
        Me.colVer = New System.Windows.Forms.DataGridViewImageColumn()
        Me.tab_transaccion = New System.Windows.Forms.TabPage()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtgConsulta = New System.Windows.Forms.DataGridView()
        Me.colConsecutivo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_tipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_num_transaccion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCodigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPeso = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_id_det = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colNumRollo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_estado_muestra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_nit_prov = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtKilos = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.imgTipo = New System.Windows.Forms.PictureBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboTipo = New System.Windows.Forms.ComboBox()
        Me.lblDescipcion = New System.Windows.Forms.Label()
        Me.lblCodigo = New System.Windows.Forms.Label()
        Me.lbl_movimientos = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtCodigoLector = New System.Windows.Forms.TextBox()
        Me.btn_salir = New System.Windows.Forms.Button()
        Me.tab_ppal.SuspendLayout()
        Me.tab_ped.SuspendLayout()
        CType(Me.dtg_pedido, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tab_transaccion.SuspendLayout()
        CType(Me.dtgConsulta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.imgTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'tab_ppal
        '
        Me.tab_ppal.Controls.Add(Me.tab_ped)
        Me.tab_ppal.Controls.Add(Me.tab_transaccion)
        Me.tab_ppal.Location = New System.Drawing.Point(1, 1)
        Me.tab_ppal.Name = "tab_ppal"
        Me.tab_ppal.SelectedIndex = 0
        Me.tab_ppal.Size = New System.Drawing.Size(314, 297)
        Me.tab_ppal.TabIndex = 1093
        '
        'tab_ped
        '
        Me.tab_ped.Controls.Add(Me.btn_actulizar)
        Me.tab_ped.Controls.Add(Me.btn_salir_pedido)
        Me.tab_ped.Controls.Add(Me.dtg_pedido)
        Me.tab_ped.Location = New System.Drawing.Point(4, 22)
        Me.tab_ped.Name = "tab_ped"
        Me.tab_ped.Padding = New System.Windows.Forms.Padding(3)
        Me.tab_ped.Size = New System.Drawing.Size(306, 271)
        Me.tab_ped.TabIndex = 1
        Me.tab_ped.Text = "PEDIDO"
        Me.tab_ped.UseVisualStyleBackColor = True
        '
        'btn_actulizar
        '
        Me.btn_actulizar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_actulizar.Image = Global.Spic.My.Resources.Resources.actualizar
        Me.btn_actulizar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_actulizar.Location = New System.Drawing.Point(3, 2)
        Me.btn_actulizar.Name = "btn_actulizar"
        Me.btn_actulizar.Size = New System.Drawing.Size(214, 27)
        Me.btn_actulizar.TabIndex = 1084
        Me.btn_actulizar.Text = "Actualizar consulta"
        Me.btn_actulizar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_actulizar.UseVisualStyleBackColor = True
        '
        'btn_salir_pedido
        '
        Me.btn_salir_pedido.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_salir_pedido.Image = Global.Spic.My.Resources.Resources._1349388831_door_in
        Me.btn_salir_pedido.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_salir_pedido.Location = New System.Drawing.Point(237, 0)
        Me.btn_salir_pedido.Name = "btn_salir_pedido"
        Me.btn_salir_pedido.Size = New System.Drawing.Size(63, 30)
        Me.btn_salir_pedido.TabIndex = 1083
        Me.btn_salir_pedido.Text = "Salir "
        Me.btn_salir_pedido.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_salir_pedido.UseVisualStyleBackColor = True
        '
        'dtg_pedido
        '
        Me.dtg_pedido.AllowUserToAddRows = False
        Me.dtg_pedido.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtg_pedido.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dtg_pedido.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtg_pedido.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dtg_pedido.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtg_pedido.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colVer})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.Format = "N0"
        DataGridViewCellStyle2.NullValue = "0"
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtg_pedido.DefaultCellStyle = DataGridViewCellStyle2
        Me.dtg_pedido.Location = New System.Drawing.Point(0, 30)
        Me.dtg_pedido.Name = "dtg_pedido"
        Me.dtg_pedido.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtg_pedido.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dtg_pedido.RowHeadersVisible = False
        Me.dtg_pedido.Size = New System.Drawing.Size(306, 240)
        Me.dtg_pedido.TabIndex = 1046
        '
        'colVer
        '
        Me.colVer.Frozen = True
        Me.colVer.Image = Global.Spic.My.Resources.Resources.buscar7
        Me.colVer.Name = "colVer"
        Me.colVer.ReadOnly = True
        Me.colVer.Width = 43
        '
        'tab_transaccion
        '
        Me.tab_transaccion.Controls.Add(Me.Label1)
        Me.tab_transaccion.Controls.Add(Me.dtgConsulta)
        Me.tab_transaccion.Controls.Add(Me.txtKilos)
        Me.tab_transaccion.Controls.Add(Me.GroupBox1)
        Me.tab_transaccion.Controls.Add(Me.lblDescipcion)
        Me.tab_transaccion.Controls.Add(Me.lblCodigo)
        Me.tab_transaccion.Controls.Add(Me.lbl_movimientos)
        Me.tab_transaccion.Controls.Add(Me.GroupBox2)
        Me.tab_transaccion.Controls.Add(Me.btn_salir)
        Me.tab_transaccion.Location = New System.Drawing.Point(4, 22)
        Me.tab_transaccion.Name = "tab_transaccion"
        Me.tab_transaccion.Padding = New System.Windows.Forms.Padding(3)
        Me.tab_transaccion.Size = New System.Drawing.Size(306, 271)
        Me.tab_transaccion.TabIndex = 0
        Me.tab_transaccion.Text = "TRANSACCIÓN"
        Me.tab_transaccion.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(176, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(99, 16)
        Me.Label1.TabIndex = 1084
        Me.Label1.Text = "Movimientos:"
        '
        'dtgConsulta
        '
        Me.dtgConsulta.AllowUserToAddRows = False
        Me.dtgConsulta.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtgConsulta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dtgConsulta.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.Format = "N1"
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgConsulta.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dtgConsulta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgConsulta.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colConsecutivo, Me.col_tipo, Me.col_num_transaccion, Me.colCodigo, Me.colPeso, Me.col_id_det, Me.colNumRollo, Me.col_estado_muestra, Me.col_nit_prov})
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.Format = "N0"
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtgConsulta.DefaultCellStyle = DataGridViewCellStyle6
        Me.dtgConsulta.Enabled = False
        Me.dtgConsulta.Location = New System.Drawing.Point(-1, 115)
        Me.dtgConsulta.Name = "dtgConsulta"
        Me.dtgConsulta.ReadOnly = True
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgConsulta.RowHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dtgConsulta.RowHeadersVisible = False
        Me.dtgConsulta.Size = New System.Drawing.Size(314, 151)
        Me.dtgConsulta.TabIndex = 1080
        '
        'colConsecutivo
        '
        Me.colConsecutivo.HeaderText = "#"
        Me.colConsecutivo.Name = "colConsecutivo"
        Me.colConsecutivo.ReadOnly = True
        Me.colConsecutivo.Width = 39
        '
        'col_tipo
        '
        Me.col_tipo.HeaderText = "tipo"
        Me.col_tipo.Name = "col_tipo"
        Me.col_tipo.ReadOnly = True
        Me.col_tipo.Width = 49
        '
        'col_num_transaccion
        '
        Me.col_num_transaccion.HeaderText = "Núm_tran"
        Me.col_num_transaccion.Name = "col_num_transaccion"
        Me.col_num_transaccion.ReadOnly = True
        Me.col_num_transaccion.Width = 78
        '
        'colCodigo
        '
        Me.colCodigo.HeaderText = "Código"
        Me.colCodigo.Name = "colCodigo"
        Me.colCodigo.ReadOnly = True
        Me.colCodigo.Width = 65
        '
        'colPeso
        '
        DataGridViewCellStyle5.Format = "N0"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.colPeso.DefaultCellStyle = DataGridViewCellStyle5
        Me.colPeso.HeaderText = "Peso"
        Me.colPeso.Name = "colPeso"
        Me.colPeso.ReadOnly = True
        Me.colPeso.Width = 56
        '
        'col_id_det
        '
        Me.col_id_det.HeaderText = "Detalle"
        Me.col_id_det.Name = "col_id_det"
        Me.col_id_det.ReadOnly = True
        Me.col_id_det.Width = 65
        '
        'colNumRollo
        '
        Me.colNumRollo.HeaderText = "Num_rollo"
        Me.colNumRollo.Name = "colNumRollo"
        Me.colNumRollo.ReadOnly = True
        Me.colNumRollo.Width = 79
        '
        'col_estado_muestra
        '
        Me.col_estado_muestra.HeaderText = "estado_muestra"
        Me.col_estado_muestra.Name = "col_estado_muestra"
        Me.col_estado_muestra.ReadOnly = True
        Me.col_estado_muestra.Visible = False
        Me.col_estado_muestra.Width = 107
        '
        'col_nit_prov
        '
        Me.col_nit_prov.HeaderText = "nit_proveeddor"
        Me.col_nit_prov.Name = "col_nit_prov"
        Me.col_nit_prov.ReadOnly = True
        Me.col_nit_prov.Visible = False
        Me.col_nit_prov.Width = 103
        '
        'txtKilos
        '
        Me.txtKilos.Enabled = False
        Me.txtKilos.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtKilos.Location = New System.Drawing.Point(179, 22)
        Me.txtKilos.MaxLength = 4
        Me.txtKilos.Name = "txtKilos"
        Me.txtKilos.ReadOnly = True
        Me.txtKilos.Size = New System.Drawing.Size(64, 26)
        Me.txtKilos.TabIndex = 1063
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.btnGuardar)
        Me.GroupBox1.Controls.Add(Me.imgTipo)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.cboTipo)
        Me.GroupBox1.Location = New System.Drawing.Point(0, 67)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(306, 46)
        Me.GroupBox1.TabIndex = 1072
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos de la transacción"
        '
        'btnGuardar
        '
        Me.btnGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardar.Image = Global.Spic.My.Resources.Resources.ok3
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGuardar.Location = New System.Drawing.Point(184, 12)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(121, 30)
        Me.btnGuardar.TabIndex = 0
        Me.btnGuardar.Text = "Transacción"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'imgTipo
        '
        Me.imgTipo.Image = Global.Spic.My.Resources.Resources._1371750041_14125
        Me.imgTipo.Location = New System.Drawing.Point(160, 18)
        Me.imgTipo.Name = "imgTipo"
        Me.imgTipo.Size = New System.Drawing.Size(15, 17)
        Me.imgTipo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgTipo.TabIndex = 1067
        Me.imgTipo.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(-1, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(36, 13)
        Me.Label4.TabIndex = 1061
        Me.Label4.Text = "Tipo:"
        '
        'cboTipo
        '
        Me.cboTipo.AutoCompleteCustomSource.AddRange(New String() {"1", "2", "3", "7"})
        Me.cboTipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTipo.FormattingEnabled = True
        Me.cboTipo.Items.AddRange(New Object() {""})
        Me.cboTipo.Location = New System.Drawing.Point(35, 13)
        Me.cboTipo.Name = "cboTipo"
        Me.cboTipo.Size = New System.Drawing.Size(112, 28)
        Me.cboTipo.TabIndex = 1062
        Me.cboTipo.Text = "Seleccione"
        '
        'lblDescipcion
        '
        Me.lblDescipcion.AutoSize = True
        Me.lblDescipcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescipcion.Location = New System.Drawing.Point(125, 51)
        Me.lblDescipcion.Name = "lblDescipcion"
        Me.lblDescipcion.Size = New System.Drawing.Size(70, 13)
        Me.lblDescipcion.TabIndex = 1079
        Me.lblDescipcion.Text = "lblDescipcion"
        '
        'lblCodigo
        '
        Me.lblCodigo.AutoSize = True
        Me.lblCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodigo.Location = New System.Drawing.Point(0, 49)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(75, 16)
        Me.lblCodigo.TabIndex = 1078
        Me.lblCodigo.Text = "lblCodigo"
        '
        'lbl_movimientos
        '
        Me.lbl_movimientos.AutoSize = True
        Me.lbl_movimientos.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_movimientos.ForeColor = System.Drawing.Color.Red
        Me.lbl_movimientos.Location = New System.Drawing.Point(285, 2)
        Me.lbl_movimientos.Name = "lbl_movimientos"
        Me.lbl_movimientos.Size = New System.Drawing.Size(19, 20)
        Me.lbl_movimientos.TabIndex = 1083
        Me.lbl_movimientos.Text = "0"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtCodigoLector)
        Me.GroupBox2.Location = New System.Drawing.Point(-4, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(180, 45)
        Me.GroupBox2.TabIndex = 1074
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Lector Hand-Held"
        '
        'txtCodigoLector
        '
        Me.txtCodigoLector.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigoLector.Location = New System.Drawing.Point(5, 14)
        Me.txtCodigoLector.Name = "txtCodigoLector"
        Me.txtCodigoLector.Size = New System.Drawing.Size(169, 24)
        Me.txtCodigoLector.TabIndex = 1074
        '
        'btn_salir
        '
        Me.btn_salir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_salir.Image = Global.Spic.My.Resources.Resources._1349388831_door_in
        Me.btn_salir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_salir.Location = New System.Drawing.Point(243, 21)
        Me.btn_salir.Name = "btn_salir"
        Me.btn_salir.Size = New System.Drawing.Size(63, 27)
        Me.btn_salir.TabIndex = 1082
        Me.btn_salir.Text = "Salir "
        Me.btn_salir.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_salir.UseVisualStyleBackColor = True
        '
        'Frm_transacion_mp_puntilleria
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(317, 298)
        Me.ControlBox = False
        Me.Controls.Add(Me.tab_ppal)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_transacion_mp_puntilleria"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Transaccion de materia prima de 2 a 12 G"
        Me.tab_ppal.ResumeLayout(False)
        Me.tab_ped.ResumeLayout(False)
        CType(Me.dtg_pedido, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tab_transaccion.ResumeLayout(False)
        Me.tab_transaccion.PerformLayout()
        CType(Me.dtgConsulta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.imgTipo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tab_ppal As System.Windows.Forms.TabControl
    Friend WithEvents tab_ped As System.Windows.Forms.TabPage
    Friend WithEvents btn_actulizar As System.Windows.Forms.Button
    Friend WithEvents btn_salir_pedido As System.Windows.Forms.Button
    Friend WithEvents dtg_pedido As System.Windows.Forms.DataGridView
    Friend WithEvents colVer As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents tab_transaccion As System.Windows.Forms.TabPage
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtgConsulta As System.Windows.Forms.DataGridView
    Friend WithEvents txtKilos As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents imgTipo As System.Windows.Forms.PictureBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboTipo As System.Windows.Forms.ComboBox
    Friend WithEvents lblDescipcion As System.Windows.Forms.Label
    Friend WithEvents lblCodigo As System.Windows.Forms.Label
    Friend WithEvents lbl_movimientos As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtCodigoLector As System.Windows.Forms.TextBox
    Friend WithEvents btn_salir As System.Windows.Forms.Button
    Friend WithEvents colConsecutivo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col_tipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col_num_transaccion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCodigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPeso As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col_id_det As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colNumRollo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col_estado_muestra As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col_nit_prov As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
