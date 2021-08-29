<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_cargue_traslado
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_cargue_traslado))
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtCodigoLector = New System.Windows.Forms.TextBox()
        Me.dtgConsulta = New System.Windows.Forms.DataGridView()
        Me.btn_salir = New System.Windows.Forms.Button()
        Me.lbl_movimientos = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tab_ppal = New System.Windows.Forms.TabControl()
        Me.tab_ped = New System.Windows.Forms.TabPage()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txt_placa = New System.Windows.Forms.TextBox()
        Me.imgCed = New System.Windows.Forms.PictureBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txt_nit = New System.Windows.Forms.TextBox()
        Me.txt_nombres = New System.Windows.Forms.TextBox()
        Me.btn_salir_pedido = New System.Windows.Forms.Button()
        Me.dtg_pedido = New System.Windows.Forms.DataGridView()
        Me.colVer = New System.Windows.Forms.DataGridViewImageColumn()
        Me.tab_transaccion = New System.Windows.Forms.TabPage()
        Me.btn_terminar = New System.Windows.Forms.Button()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.dtg_codigos_cargados = New System.Windows.Forms.DataGridView()
        Me.col_cod_cargado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_lote_cargado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_consecutivo_cargado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dtgConsulta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tab_ppal.SuspendLayout()
        Me.tab_ped.SuspendLayout()
        CType(Me.imgCed, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtg_pedido, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tab_transaccion.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dtg_codigos_cargados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        'dtgConsulta
        '
        Me.dtgConsulta.AllowUserToAddRows = False
        Me.dtgConsulta.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtgConsulta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dtgConsulta.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.Format = "N1"
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgConsulta.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dtgConsulta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.Format = "N0"
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtgConsulta.DefaultCellStyle = DataGridViewCellStyle2
        Me.dtgConsulta.Enabled = False
        Me.dtgConsulta.Location = New System.Drawing.Point(3, 54)
        Me.dtgConsulta.Name = "dtgConsulta"
        Me.dtgConsulta.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgConsulta.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dtgConsulta.RowHeadersVisible = False
        Me.dtgConsulta.Size = New System.Drawing.Size(300, 185)
        Me.dtgConsulta.TabIndex = 1080
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
        'lbl_movimientos
        '
        Me.lbl_movimientos.AutoSize = True
        Me.lbl_movimientos.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_movimientos.ForeColor = System.Drawing.Color.Red
        Me.lbl_movimientos.Location = New System.Drawing.Point(179, 17)
        Me.lbl_movimientos.Name = "lbl_movimientos"
        Me.lbl_movimientos.Size = New System.Drawing.Size(36, 37)
        Me.lbl_movimientos.TabIndex = 1083
        Me.lbl_movimientos.Text = "0"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(176, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(95, 16)
        Me.Label1.TabIndex = 1084
        Me.Label1.Text = "Movimientos"
        '
        'tab_ppal
        '
        Me.tab_ppal.Controls.Add(Me.tab_ped)
        Me.tab_ppal.Controls.Add(Me.tab_transaccion)
        Me.tab_ppal.Controls.Add(Me.TabPage1)
        Me.tab_ppal.Location = New System.Drawing.Point(2, 0)
        Me.tab_ppal.Name = "tab_ppal"
        Me.tab_ppal.SelectedIndex = 0
        Me.tab_ppal.Size = New System.Drawing.Size(314, 297)
        Me.tab_ppal.TabIndex = 1085
        '
        'tab_ped
        '
        Me.tab_ped.Controls.Add(Me.Label2)
        Me.tab_ped.Controls.Add(Me.txt_placa)
        Me.tab_ped.Controls.Add(Me.imgCed)
        Me.tab_ped.Controls.Add(Me.Label5)
        Me.tab_ped.Controls.Add(Me.txt_nit)
        Me.tab_ped.Controls.Add(Me.txt_nombres)
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
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(2, 6)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(128, 20)
        Me.Label2.TabIndex = 1090
        Me.Label2.Text = "Placa vehiculo:"
        '
        'txt_placa
        '
        Me.txt_placa.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_placa.ForeColor = System.Drawing.Color.Black
        Me.txt_placa.Location = New System.Drawing.Point(136, 5)
        Me.txt_placa.Name = "txt_placa"
        Me.txt_placa.Size = New System.Drawing.Size(100, 22)
        Me.txt_placa.TabIndex = 1089
        '
        'imgCed
        '
        Me.imgCed.Image = Global.Spic.My.Resources.Resources._1371750041_14125
        Me.imgCed.Location = New System.Drawing.Point(277, 32)
        Me.imgCed.Name = "imgCed"
        Me.imgCed.Size = New System.Drawing.Size(23, 22)
        Me.imgCed.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgCed.TabIndex = 1086
        Me.imgCed.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(2, 32)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(36, 20)
        Me.Label5.TabIndex = 1088
        Me.Label5.Text = "Nit:"
        '
        'txt_nit
        '
        Me.txt_nit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_nit.ForeColor = System.Drawing.Color.Black
        Me.txt_nit.Location = New System.Drawing.Point(39, 31)
        Me.txt_nit.Name = "txt_nit"
        Me.txt_nit.Size = New System.Drawing.Size(232, 22)
        Me.txt_nit.TabIndex = 1087
        '
        'txt_nombres
        '
        Me.txt_nombres.Enabled = False
        Me.txt_nombres.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_nombres.Location = New System.Drawing.Point(6, 56)
        Me.txt_nombres.MaxLength = 4
        Me.txt_nombres.Name = "txt_nombres"
        Me.txt_nombres.ReadOnly = True
        Me.txt_nombres.Size = New System.Drawing.Size(294, 21)
        Me.txt_nombres.TabIndex = 1085
        '
        'btn_salir_pedido
        '
        Me.btn_salir_pedido.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_salir_pedido.Image = Global.Spic.My.Resources.Resources._1349388831_door_in
        Me.btn_salir_pedido.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_salir_pedido.Location = New System.Drawing.Point(242, 0)
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
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtg_pedido.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dtg_pedido.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtg_pedido.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colVer})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.Format = "N0"
        DataGridViewCellStyle5.NullValue = "0"
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtg_pedido.DefaultCellStyle = DataGridViewCellStyle5
        Me.dtg_pedido.Location = New System.Drawing.Point(0, 80)
        Me.dtg_pedido.Name = "dtg_pedido"
        Me.dtg_pedido.ReadOnly = True
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtg_pedido.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dtg_pedido.RowHeadersVisible = False
        Me.dtg_pedido.Size = New System.Drawing.Size(300, 187)
        Me.dtg_pedido.TabIndex = 1046
        '
        'colVer
        '
        Me.colVer.Frozen = True
        Me.colVer.HeaderText = ""
        Me.colVer.Image = Global.Spic.My.Resources.Resources.buscar7
        Me.colVer.Name = "colVer"
        Me.colVer.ReadOnly = True
        Me.colVer.Width = 5
        '
        'tab_transaccion
        '
        Me.tab_transaccion.Controls.Add(Me.btn_terminar)
        Me.tab_transaccion.Controls.Add(Me.Label1)
        Me.tab_transaccion.Controls.Add(Me.dtgConsulta)
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
        'btn_terminar
        '
        Me.btn_terminar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_terminar.Image = Global.Spic.My.Resources.Resources.ok3
        Me.btn_terminar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_terminar.Location = New System.Drawing.Point(3, 241)
        Me.btn_terminar.Name = "btn_terminar"
        Me.btn_terminar.Size = New System.Drawing.Size(300, 27)
        Me.btn_terminar.TabIndex = 1085
        Me.btn_terminar.Text = "Terminar"
        Me.btn_terminar.UseVisualStyleBackColor = True
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.dtg_codigos_cargados)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(306, 271)
        Me.TabPage1.TabIndex = 2
        Me.TabPage1.Text = "Códigos cargados"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'dtg_codigos_cargados
        '
        Me.dtg_codigos_cargados.AllowUserToAddRows = False
        Me.dtg_codigos_cargados.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtg_codigos_cargados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dtg_codigos_cargados.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.Format = "N1"
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtg_codigos_cargados.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dtg_codigos_cargados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtg_codigos_cargados.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.col_cod_cargado, Me.col_lote_cargado, Me.col_consecutivo_cargado})
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.Format = "N0"
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtg_codigos_cargados.DefaultCellStyle = DataGridViewCellStyle8
        Me.dtg_codigos_cargados.Enabled = False
        Me.dtg_codigos_cargados.Location = New System.Drawing.Point(3, 0)
        Me.dtg_codigos_cargados.Name = "dtg_codigos_cargados"
        Me.dtg_codigos_cargados.ReadOnly = True
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtg_codigos_cargados.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.dtg_codigos_cargados.RowHeadersVisible = False
        Me.dtg_codigos_cargados.Size = New System.Drawing.Size(303, 275)
        Me.dtg_codigos_cargados.TabIndex = 1081
        '
        'col_cod_cargado
        '
        Me.col_cod_cargado.HeaderText = "Código"
        Me.col_cod_cargado.Name = "col_cod_cargado"
        Me.col_cod_cargado.ReadOnly = True
        Me.col_cod_cargado.Width = 65
        '
        'col_lote_cargado
        '
        Me.col_lote_cargado.HeaderText = "Lote"
        Me.col_lote_cargado.Name = "col_lote_cargado"
        Me.col_lote_cargado.ReadOnly = True
        Me.col_lote_cargado.Width = 53
        '
        'col_consecutivo_cargado
        '
        Me.col_consecutivo_cargado.HeaderText = "Consecutivo"
        Me.col_consecutivo_cargado.Name = "col_consecutivo_cargado"
        Me.col_consecutivo_cargado.ReadOnly = True
        Me.col_consecutivo_cargado.Width = 91
        '
        'Frm_cargue_traslado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(318, 295)
        Me.ControlBox = False
        Me.Controls.Add(Me.tab_ppal)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_cargue_traslado"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Cargue temrminado"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.dtgConsulta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tab_ppal.ResumeLayout(False)
        Me.tab_ped.ResumeLayout(False)
        Me.tab_ped.PerformLayout()
        CType(Me.imgCed, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtg_pedido, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tab_transaccion.ResumeLayout(False)
        Me.tab_transaccion.PerformLayout()
        Me.TabPage1.ResumeLayout(False)
        CType(Me.dtg_codigos_cargados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtCodigoLector As System.Windows.Forms.TextBox
    Friend WithEvents dtgConsulta As System.Windows.Forms.DataGridView
    Friend WithEvents btn_salir As System.Windows.Forms.Button
    Friend WithEvents lbl_movimientos As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tab_ppal As System.Windows.Forms.TabControl
    Friend WithEvents tab_ped As System.Windows.Forms.TabPage
    Friend WithEvents tab_transaccion As System.Windows.Forms.TabPage
    Friend WithEvents dtg_pedido As System.Windows.Forms.DataGridView
    Friend WithEvents colVer As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents btn_salir_pedido As System.Windows.Forms.Button
    Friend WithEvents txt_nombres As System.Windows.Forms.TextBox
    Friend WithEvents imgCed As System.Windows.Forms.PictureBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txt_nit As System.Windows.Forms.TextBox
    Friend WithEvents btn_terminar As System.Windows.Forms.Button
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents dtg_codigos_cargados As System.Windows.Forms.DataGridView
    Friend WithEvents col_cod_cargado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col_lote_cargado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col_consecutivo_cargado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_placa As System.Windows.Forms.TextBox
End Class
