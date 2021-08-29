<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_entradas_salidas_ref
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
        Me.Toolbar1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnActualizar = New System.Windows.Forms.ToolStripButton()
        Me.btnExcel = New System.Windows.Forms.ToolStripButton()
        Me.cbo_bodega = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txt_codigo = New System.Windows.Forms.TextBox()
        Me.dtgConsulta = New System.Windows.Forms.DataGridView()
        Me.img_procesar = New System.Windows.Forms.PictureBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lbl_mes = New System.Windows.Forms.Label()
        Me.cbo_mes = New System.Windows.Forms.ComboBox()
        Me.cbo_ano = New System.Windows.Forms.ComboBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.chk_consol_linea = New System.Windows.Forms.CheckBox()
        Me.GroupBox9 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.chkLinea = New System.Windows.Forms.CheckedListBox()
        Me.chk_agrup_bod = New System.Windows.Forms.CheckBox()
        Me.txtDesc = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chk_fil_ult_movimiento = New System.Windows.Forms.CheckBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cbo_fecha_fin_fil = New System.Windows.Forms.DateTimePicker()
        Me.cbo_fecha_ini_fil = New System.Windows.Forms.DateTimePicker()
        Me.tab_ppal = New System.Windows.Forms.TabControl()
        Me.tab_ent_sal_stock = New System.Windows.Forms.TabPage()
        Me.tab_trasablidad = New System.Windows.Forms.TabPage()
        Me.chk_det_tras = New System.Windows.Forms.CheckBox()
        Me.dtg_trasabilidad = New System.Windows.Forms.DataGridView()
        Me.chk_ocultar_vacios = New ComponentFactory.Krypton.Toolkit.KryptonCheckBox()
        Me.chk_inactivas = New ComponentFactory.Krypton.Toolkit.KryptonCheckBox()
        Me.chk_costos = New ComponentFactory.Krypton.Toolkit.KryptonCheckBox()
        Me.Toolbar1.SuspendLayout()
        CType(Me.dtgConsulta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.img_procesar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox9.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.tab_ppal.SuspendLayout()
        Me.tab_ent_sal_stock.SuspendLayout()
        Me.tab_trasablidad.SuspendLayout()
        CType(Me.dtg_trasabilidad, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Toolbar1
        '
        Me.Toolbar1.AutoSize = False
        Me.Toolbar1.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.Toolbar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Toolbar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Toolbar1.ImageScalingSize = New System.Drawing.Size(23, 23)
        Me.Toolbar1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator2, Me.ToolStripButton1, Me.ToolStripButton2, Me.ToolStripSeparator3, Me.btnActualizar, Me.btnExcel})
        Me.Toolbar1.Location = New System.Drawing.Point(0, 0)
        Me.Toolbar1.Name = "Toolbar1"
        Me.Toolbar1.Size = New System.Drawing.Size(746, 28)
        Me.Toolbar1.TabIndex = 1045
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
        'btnActualizar
        '
        Me.btnActualizar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnActualizar.Image = Global.Spic.My.Resources.Resources.actualizar
        Me.btnActualizar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnActualizar.Name = "btnActualizar"
        Me.btnActualizar.Size = New System.Drawing.Size(27, 25)
        Me.btnActualizar.Text = "Actualizar"
        '
        'btnExcel
        '
        Me.btnExcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnExcel.Image = Global.Spic.My.Resources.Resources.excel
        Me.btnExcel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnExcel.Name = "btnExcel"
        Me.btnExcel.Size = New System.Drawing.Size(27, 25)
        Me.btnExcel.Text = "Exportar a excel"
        '
        'cbo_bodega
        '
        Me.cbo_bodega.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbo_bodega.FormattingEnabled = True
        Me.cbo_bodega.Location = New System.Drawing.Point(581, 105)
        Me.cbo_bodega.Name = "cbo_bodega"
        Me.cbo_bodega.Size = New System.Drawing.Size(159, 21)
        Me.cbo_bodega.TabIndex = 1046
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(578, 92)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 13)
        Me.Label1.TabIndex = 1047
        Me.Label1.Text = "Bodega:"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(580, 131)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 13)
        Me.Label2.TabIndex = 1048
        Me.Label2.Text = "Código:"
        '
        'txt_codigo
        '
        Me.txt_codigo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_codigo.Location = New System.Drawing.Point(623, 128)
        Me.txt_codigo.Name = "txt_codigo"
        Me.txt_codigo.Size = New System.Drawing.Size(116, 20)
        Me.txt_codigo.TabIndex = 1049
        Me.txt_codigo.Text = "3"
        '
        'dtgConsulta
        '
        Me.dtgConsulta.AllowUserToAddRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dtgConsulta.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dtgConsulta.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtgConsulta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dtgConsulta.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
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
        Me.dtgConsulta.Location = New System.Drawing.Point(3, 3)
        Me.dtgConsulta.Name = "dtgConsulta"
        Me.dtgConsulta.ReadOnly = True
        Me.dtgConsulta.RowHeadersVisible = False
        Me.dtgConsulta.Size = New System.Drawing.Size(566, 420)
        Me.dtgConsulta.TabIndex = 1052
        '
        'img_procesar
        '
        Me.img_procesar.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.img_procesar.Image = Global.Spic.My.Resources.Resources.procesando
        Me.img_procesar.Location = New System.Drawing.Point(12, 157)
        Me.img_procesar.Name = "img_procesar"
        Me.img_procesar.Size = New System.Drawing.Size(528, 265)
        Me.img_procesar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.img_procesar.TabIndex = 1080
        Me.img_procesar.TabStop = False
        Me.img_procesar.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.lbl_mes)
        Me.GroupBox2.Controls.Add(Me.cbo_mes)
        Me.GroupBox2.Location = New System.Drawing.Point(574, 116)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(167, 65)
        Me.GroupBox2.TabIndex = 1081
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Fecha "
        '
        'lbl_mes
        '
        Me.lbl_mes.AutoSize = True
        Me.lbl_mes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_mes.Location = New System.Drawing.Point(5, 18)
        Me.lbl_mes.Name = "lbl_mes"
        Me.lbl_mes.Size = New System.Drawing.Size(34, 13)
        Me.lbl_mes.TabIndex = 1078
        Me.lbl_mes.Text = "Mes:"
        '
        'cbo_mes
        '
        Me.cbo_mes.FormattingEnabled = True
        Me.cbo_mes.Items.AddRange(New Object() {"Enero ", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"})
        Me.cbo_mes.Location = New System.Drawing.Point(39, 14)
        Me.cbo_mes.Name = "cbo_mes"
        Me.cbo_mes.Size = New System.Drawing.Size(119, 21)
        Me.cbo_mes.TabIndex = 1077
        Me.cbo_mes.Text = "Seleccione"
        '
        'cbo_ano
        '
        Me.cbo_ano.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbo_ano.FormattingEnabled = True
        Me.cbo_ano.Location = New System.Drawing.Point(617, 210)
        Me.cbo_ano.Name = "cbo_ano"
        Me.cbo_ano.Size = New System.Drawing.Size(119, 21)
        Me.cbo_ano.TabIndex = 1075
        Me.cbo_ano.Text = "Seleccione"
        '
        'Label37
        '
        Me.Label37.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label37.AutoSize = True
        Me.Label37.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.Location = New System.Drawing.Point(584, 210)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(33, 13)
        Me.Label37.TabIndex = 1076
        Me.Label37.Text = "Año:"
        '
        'chk_consol_linea
        '
        Me.chk_consol_linea.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chk_consol_linea.AutoSize = True
        Me.chk_consol_linea.Location = New System.Drawing.Point(579, 3)
        Me.chk_consol_linea.Name = "chk_consol_linea"
        Me.chk_consol_linea.Size = New System.Drawing.Size(171, 17)
        Me.chk_consol_linea.TabIndex = 1082
        Me.chk_consol_linea.Text = "Consolidar linea de producción"
        Me.chk_consol_linea.UseVisualStyleBackColor = True
        '
        'GroupBox9
        '
        Me.GroupBox9.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox9.Controls.Add(Me.Label3)
        Me.GroupBox9.Controls.Add(Me.chkLinea)
        Me.GroupBox9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox9.Location = New System.Drawing.Point(574, 347)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Size = New System.Drawing.Size(163, 129)
        Me.GroupBox9.TabIndex = 1083
        Me.GroupBox9.TabStop = False
        Me.GroupBox9.Text = "Linea de producción"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(3, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(154, 12)
        Me.Label3.TabIndex = 1080
        Me.Label3.Text = "Solo aplica para código: 2,3,7"
        '
        'chkLinea
        '
        Me.chkLinea.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkLinea.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkLinea.FormattingEnabled = True
        Me.chkLinea.Location = New System.Drawing.Point(5, 31)
        Me.chkLinea.Name = "chkLinea"
        Me.chkLinea.Size = New System.Drawing.Size(156, 95)
        Me.chkLinea.TabIndex = 1051
        '
        'chk_agrup_bod
        '
        Me.chk_agrup_bod.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chk_agrup_bod.AutoSize = True
        Me.chk_agrup_bod.Location = New System.Drawing.Point(580, 22)
        Me.chk_agrup_bod.Name = "chk_agrup_bod"
        Me.chk_agrup_bod.Size = New System.Drawing.Size(120, 17)
        Me.chk_agrup_bod.TabIndex = 1084
        Me.chk_agrup_bod.Text = "Agrupar por bodega"
        Me.chk_agrup_bod.UseVisualStyleBackColor = True
        '
        'txtDesc
        '
        Me.txtDesc.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDesc.Location = New System.Drawing.Point(620, 96)
        Me.txtDesc.Name = "txtDesc"
        Me.txtDesc.Size = New System.Drawing.Size(116, 20)
        Me.txtDesc.TabIndex = 1086
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(585, 99)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(35, 13)
        Me.Label5.TabIndex = 1085
        Me.Label5.Text = "Desc:"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.LinkColor = System.Drawing.Color.Red
        Me.LinkLabel1.Location = New System.Drawing.Point(140, 9)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(115, 13)
        Me.LinkLabel1.TabIndex = 1105
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Productos sin clasificar"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.chk_fil_ult_movimiento)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.cbo_fecha_fin_fil)
        Me.GroupBox1.Controls.Add(Me.cbo_fecha_ini_fil)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(574, 182)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(158, 114)
        Me.GroupBox1.TabIndex = 1107
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Fecha ultimo moviento"
        '
        'chk_fil_ult_movimiento
        '
        Me.chk_fil_ult_movimiento.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chk_fil_ult_movimiento.AutoSize = True
        Me.chk_fil_ult_movimiento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_fil_ult_movimiento.Location = New System.Drawing.Point(7, 15)
        Me.chk_fil_ult_movimiento.Name = "chk_fil_ult_movimiento"
        Me.chk_fil_ult_movimiento.Size = New System.Drawing.Size(137, 17)
        Me.chk_fil_ult_movimiento.TabIndex = 1107
        Me.chk_fil_ult_movimiento.Text = "Filtrar último movimiento"
        Me.chk_fil_ult_movimiento.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(6, 70)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(110, 13)
        Me.Label6.TabIndex = 1109
        Me.Label6.Text = "Última salida menor a "
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(6, 33)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(119, 13)
        Me.Label4.TabIndex = 1107
        Me.Label4.Text = "Última entrada menor a "
        '
        'cbo_fecha_fin_fil
        '
        Me.cbo_fecha_fin_fil.Enabled = False
        Me.cbo_fecha_fin_fil.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.cbo_fecha_fin_fil.Location = New System.Drawing.Point(7, 88)
        Me.cbo_fecha_fin_fil.Name = "cbo_fecha_fin_fil"
        Me.cbo_fecha_fin_fil.Size = New System.Drawing.Size(146, 20)
        Me.cbo_fecha_fin_fil.TabIndex = 1108
        '
        'cbo_fecha_ini_fil
        '
        Me.cbo_fecha_ini_fil.Enabled = False
        Me.cbo_fecha_ini_fil.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.cbo_fecha_ini_fil.Location = New System.Drawing.Point(5, 47)
        Me.cbo_fecha_ini_fil.Name = "cbo_fecha_ini_fil"
        Me.cbo_fecha_ini_fil.Size = New System.Drawing.Size(148, 20)
        Me.cbo_fecha_ini_fil.TabIndex = 1107
        '
        'tab_ppal
        '
        Me.tab_ppal.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tab_ppal.Controls.Add(Me.tab_ent_sal_stock)
        Me.tab_ppal.Controls.Add(Me.tab_trasablidad)
        Me.tab_ppal.Location = New System.Drawing.Point(0, 32)
        Me.tab_ppal.Name = "tab_ppal"
        Me.tab_ppal.SelectedIndex = 0
        Me.tab_ppal.Size = New System.Drawing.Size(746, 452)
        Me.tab_ppal.TabIndex = 1108
        '
        'tab_ent_sal_stock
        '
        Me.tab_ent_sal_stock.Controls.Add(Me.dtgConsulta)
        Me.tab_ent_sal_stock.Controls.Add(Me.GroupBox1)
        Me.tab_ent_sal_stock.Controls.Add(Me.GroupBox2)
        Me.tab_ent_sal_stock.Controls.Add(Me.chk_consol_linea)
        Me.tab_ent_sal_stock.Controls.Add(Me.chk_agrup_bod)
        Me.tab_ent_sal_stock.Controls.Add(Me.txtDesc)
        Me.tab_ent_sal_stock.Controls.Add(Me.Label5)
        Me.tab_ent_sal_stock.Location = New System.Drawing.Point(4, 22)
        Me.tab_ent_sal_stock.Name = "tab_ent_sal_stock"
        Me.tab_ent_sal_stock.Padding = New System.Windows.Forms.Padding(3)
        Me.tab_ent_sal_stock.Size = New System.Drawing.Size(738, 426)
        Me.tab_ent_sal_stock.TabIndex = 0
        Me.tab_ent_sal_stock.Text = "Entradas - Salidas - Stock"
        Me.tab_ent_sal_stock.UseVisualStyleBackColor = True
        '
        'tab_trasablidad
        '
        Me.tab_trasablidad.Controls.Add(Me.chk_det_tras)
        Me.tab_trasablidad.Controls.Add(Me.dtg_trasabilidad)
        Me.tab_trasablidad.Location = New System.Drawing.Point(4, 22)
        Me.tab_trasablidad.Name = "tab_trasablidad"
        Me.tab_trasablidad.Padding = New System.Windows.Forms.Padding(3)
        Me.tab_trasablidad.Size = New System.Drawing.Size(738, 426)
        Me.tab_trasablidad.TabIndex = 1
        Me.tab_trasablidad.Text = "Trasabilidad de referencias"
        Me.tab_trasablidad.UseVisualStyleBackColor = True
        '
        'chk_det_tras
        '
        Me.chk_det_tras.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chk_det_tras.AutoSize = True
        Me.chk_det_tras.Location = New System.Drawing.Point(576, 6)
        Me.chk_det_tras.Name = "chk_det_tras"
        Me.chk_det_tras.Size = New System.Drawing.Size(95, 17)
        Me.chk_det_tras.TabIndex = 1091
        Me.chk_det_tras.Text = "Mostrar detalle"
        Me.chk_det_tras.UseVisualStyleBackColor = True
        '
        'dtg_trasabilidad
        '
        Me.dtg_trasabilidad.AllowUserToAddRows = False
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        Me.dtg_trasabilidad.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
        Me.dtg_trasabilidad.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtg_trasabilidad.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dtg_trasabilidad.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dtg_trasabilidad.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.Format = "N0"
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtg_trasabilidad.DefaultCellStyle = DataGridViewCellStyle4
        Me.dtg_trasabilidad.Location = New System.Drawing.Point(3, 3)
        Me.dtg_trasabilidad.Name = "dtg_trasabilidad"
        Me.dtg_trasabilidad.ReadOnly = True
        Me.dtg_trasabilidad.RowHeadersVisible = False
        Me.dtg_trasabilidad.Size = New System.Drawing.Size(566, 420)
        Me.dtg_trasabilidad.TabIndex = 1053
        '
        'chk_ocultar_vacios
        '
        Me.chk_ocultar_vacios.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chk_ocultar_vacios.Location = New System.Drawing.Point(487, 2)
        Me.chk_ocultar_vacios.Name = "chk_ocultar_vacios"
        Me.chk_ocultar_vacios.Size = New System.Drawing.Size(151, 20)
        Me.chk_ocultar_vacios.TabIndex = 1109
        Me.chk_ocultar_vacios.Values.Text = "Ocultar sin movimiento"
        '
        'chk_inactivas
        '
        Me.chk_inactivas.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chk_inactivas.Location = New System.Drawing.Point(343, 2)
        Me.chk_inactivas.Name = "chk_inactivas"
        Me.chk_inactivas.Size = New System.Drawing.Size(136, 20)
        Me.chk_inactivas.TabIndex = 1110
        Me.chk_inactivas.Values.Text = "No mostrar inactivas"
        '
        'chk_costos
        '
        Me.chk_costos.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chk_costos.Location = New System.Drawing.Point(641, 2)
        Me.chk_costos.Name = "chk_costos"
        Me.chk_costos.Size = New System.Drawing.Size(104, 20)
        Me.chk_costos.TabIndex = 1111
        Me.chk_costos.Values.Text = "Mostrar costos"
        '
        'Frm_entradas_salidas_ref
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(746, 488)
        Me.Controls.Add(Me.chk_costos)
        Me.Controls.Add(Me.chk_inactivas)
        Me.Controls.Add(Me.chk_ocultar_vacios)
        Me.Controls.Add(Me.cbo_ano)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label37)
        Me.Controls.Add(Me.cbo_bodega)
        Me.Controls.Add(Me.txt_codigo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.GroupBox9)
        Me.Controls.Add(Me.img_procesar)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.Toolbar1)
        Me.Controls.Add(Me.tab_ppal)
        Me.Name = "Frm_entradas_salidas_ref"
        Me.Text = "Entradas-salidas-inventarios"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Toolbar1.ResumeLayout(False)
        Me.Toolbar1.PerformLayout()
        CType(Me.dtgConsulta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.img_procesar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox9.ResumeLayout(False)
        Me.GroupBox9.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.tab_ppal.ResumeLayout(False)
        Me.tab_ent_sal_stock.ResumeLayout(False)
        Me.tab_ent_sal_stock.PerformLayout()
        Me.tab_trasablidad.ResumeLayout(False)
        Me.tab_trasablidad.PerformLayout()
        CType(Me.dtg_trasabilidad, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Toolbar1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnActualizar As System.Windows.Forms.ToolStripButton
    Friend WithEvents cbo_bodega As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_codigo As System.Windows.Forms.TextBox
    Friend WithEvents dtgConsulta As System.Windows.Forms.DataGridView
    Friend WithEvents img_procesar As System.Windows.Forms.PictureBox
    Friend WithEvents btnExcel As System.Windows.Forms.ToolStripButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cbo_ano As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_mes As System.Windows.Forms.Label
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents cbo_mes As System.Windows.Forms.ComboBox
    Friend WithEvents chk_consol_linea As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox9 As System.Windows.Forms.GroupBox
    Friend WithEvents chkLinea As System.Windows.Forms.CheckedListBox
    Friend WithEvents chk_agrup_bod As System.Windows.Forms.CheckBox
    Friend WithEvents txtDesc As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents chk_fil_ult_movimiento As System.Windows.Forms.CheckBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cbo_fecha_fin_fil As System.Windows.Forms.DateTimePicker
    Friend WithEvents cbo_fecha_ini_fil As System.Windows.Forms.DateTimePicker
    Friend WithEvents tab_ppal As TabControl
    Friend WithEvents tab_ent_sal_stock As TabPage
    Friend WithEvents tab_trasablidad As TabPage
    Friend WithEvents chk_det_tras As CheckBox
    Friend WithEvents dtg_trasabilidad As DataGridView
    Friend WithEvents chk_ocultar_vacios As ComponentFactory.Krypton.Toolkit.KryptonCheckBox
    Friend WithEvents chk_inactivas As ComponentFactory.Krypton.Toolkit.KryptonCheckBox
    Friend WithEvents chk_costos As ComponentFactory.Krypton.Toolkit.KryptonCheckBox
End Class
