<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_consultar_empaque_punt
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
        Me.dtg_consulta = New System.Windows.Forms.DataGridView()
        Me.menStripDtg = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EliminarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Toolbar1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.btn_excel = New System.Windows.Forms.ToolStripButton()
        Me.btn_actualizar = New System.Windows.Forms.ToolStripButton()
        Me.cbo_operario = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txt_transaccion = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.chk_consol_op = New System.Windows.Forms.CheckBox()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.chk_fec_transaccion = New System.Windows.Forms.CheckBox()
        Me.cbo_fecha_fin = New System.Windows.Forms.DateTimePicker()
        Me.cbo_fecha_ini = New System.Windows.Forms.DateTimePicker()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.imgProcesar = New System.Windows.Forms.PictureBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.chk_turno = New System.Windows.Forms.CheckBox()
        Me.chk_consol_dia = New System.Windows.Forms.CheckBox()
        Me.chk_consol_ref = New System.Windows.Forms.CheckBox()
        Me.chk_granel = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.chk_excluir_empaques_contenidos = New System.Windows.Forms.CheckBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lbl_emp_contenidos = New System.Windows.Forms.Label()
        Me.lbl_prom_dia = New System.Windows.Forms.Label()
        Me.lbl_tot_cartones = New System.Windows.Forms.Label()
        Me.lbl_colpack = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.chk_excluir_grapa = New System.Windows.Forms.CheckBox()
        Me.chk_excluir_arandela = New System.Windows.Forms.CheckBox()
        Me.lbl_apl = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lbl_decor = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        CType(Me.dtg_consulta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.menStripDtg.SuspendLayout()
        Me.Toolbar1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.imgProcesar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'dtg_consulta
        '
        Me.dtg_consulta.AllowUserToAddRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro
        Me.dtg_consulta.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dtg_consulta.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtg_consulta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dtg_consulta.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dtg_consulta.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtg_consulta.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dtg_consulta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtg_consulta.ContextMenuStrip = Me.menStripDtg
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.Format = "N0"
        DataGridViewCellStyle3.NullValue = "0"
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtg_consulta.DefaultCellStyle = DataGridViewCellStyle3
        Me.dtg_consulta.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dtg_consulta.Location = New System.Drawing.Point(12, 109)
        Me.dtg_consulta.Name = "dtg_consulta"
        Me.dtg_consulta.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtg_consulta.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dtg_consulta.RowHeadersVisible = False
        Me.dtg_consulta.Size = New System.Drawing.Size(680, 360)
        Me.dtg_consulta.TabIndex = 139
        '
        'menStripDtg
        '
        Me.menStripDtg.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.menStripDtg.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EliminarToolStripMenuItem})
        Me.menStripDtg.Name = "ContextMenuStrip1"
        Me.menStripDtg.Size = New System.Drawing.Size(120, 26)
        '
        'EliminarToolStripMenuItem
        '
        Me.EliminarToolStripMenuItem.Image = Global.Spic.My.Resources.Resources.x
        Me.EliminarToolStripMenuItem.Name = "EliminarToolStripMenuItem"
        Me.EliminarToolStripMenuItem.Size = New System.Drawing.Size(119, 22)
        Me.EliminarToolStripMenuItem.Text = "Eliminar"
        '
        'Toolbar1
        '
        Me.Toolbar1.AutoSize = False
        Me.Toolbar1.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.Toolbar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Toolbar1.ImageScalingSize = New System.Drawing.Size(23, 23)
        Me.Toolbar1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator2, Me.ToolStripButton1, Me.ToolStripButton2, Me.ToolStripSeparator3, Me.btn_excel, Me.btn_actualizar})
        Me.Toolbar1.Location = New System.Drawing.Point(0, 0)
        Me.Toolbar1.Name = "Toolbar1"
        Me.Toolbar1.Size = New System.Drawing.Size(704, 33)
        Me.Toolbar1.TabIndex = 1025
        Me.Toolbar1.Text = "ToolStrip1"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 33)
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = Global.Spic.My.Resources.Resources._1349388328_door_in
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(27, 30)
        Me.ToolStripButton1.Text = "ToolStripButton1"
        Me.ToolStripButton1.ToolTipText = "Salir"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton2.Image = Global.Spic.My.Resources.Resources.ppal3
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(27, 30)
        Me.ToolStripButton2.Text = "ToolStripButton2"
        Me.ToolStripButton2.ToolTipText = "Menú principal"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 33)
        '
        'btn_excel
        '
        Me.btn_excel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_excel.Image = Global.Spic.My.Resources.Resources.icon_excel
        Me.btn_excel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_excel.Name = "btn_excel"
        Me.btn_excel.Size = New System.Drawing.Size(27, 30)
        Me.btn_excel.Text = "ToolStripButton4"
        Me.btn_excel.ToolTipText = "Enviar a excel"
        '
        'btn_actualizar
        '
        Me.btn_actualizar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_actualizar.Image = Global.Spic.My.Resources.Resources.actualizar
        Me.btn_actualizar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_actualizar.Name = "btn_actualizar"
        Me.btn_actualizar.Size = New System.Drawing.Size(27, 30)
        Me.btn_actualizar.Text = "Actualizar"
        '
        'cbo_operario
        '
        Me.cbo_operario.FormattingEnabled = True
        Me.cbo_operario.Location = New System.Drawing.Point(62, 16)
        Me.cbo_operario.Name = "cbo_operario"
        Me.cbo_operario.Size = New System.Drawing.Size(249, 21)
        Me.cbo_operario.TabIndex = 1036
        Me.cbo_operario.Text = "Seleccione"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txt_transaccion)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.cbo_operario)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 28)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(317, 72)
        Me.GroupBox1.TabIndex = 1042
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filtrar"
        '
        'txt_transaccion
        '
        Me.txt_transaccion.Location = New System.Drawing.Point(84, 45)
        Me.txt_transaccion.Name = "txt_transaccion"
        Me.txt_transaccion.Size = New System.Drawing.Size(227, 20)
        Me.txt_transaccion.TabIndex = 1053
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(2, 49)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(81, 13)
        Me.Label4.TabIndex = 1052
        Me.Label4.Text = "Transacción:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(3, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 13)
        Me.Label3.TabIndex = 1051
        Me.Label3.Text = "Operario:"
        '
        'chk_consol_op
        '
        Me.chk_consol_op.AutoSize = True
        Me.chk_consol_op.Location = New System.Drawing.Point(4, 14)
        Me.chk_consol_op.Name = "chk_consol_op"
        Me.chk_consol_op.Size = New System.Drawing.Size(66, 17)
        Me.chk_consol_op.TabIndex = 1046
        Me.chk_consol_op.Text = "Operario"
        Me.chk_consol_op.UseVisualStyleBackColor = True
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(159, 30)
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.chk_fec_transaccion)
        Me.GroupBox3.Controls.Add(Me.cbo_fecha_fin)
        Me.GroupBox3.Controls.Add(Me.cbo_fecha_ini)
        Me.GroupBox3.Location = New System.Drawing.Point(322, 28)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(117, 77)
        Me.GroupBox3.TabIndex = 1047
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Rango de fecha"
        '
        'chk_fec_transaccion
        '
        Me.chk_fec_transaccion.AutoSize = True
        Me.chk_fec_transaccion.Location = New System.Drawing.Point(7, 12)
        Me.chk_fec_transaccion.Name = "chk_fec_transaccion"
        Me.chk_fec_transaccion.Size = New System.Drawing.Size(114, 17)
        Me.chk_fec_transaccion.TabIndex = 1050
        Me.chk_fec_transaccion.Text = "Fecha transacción"
        Me.chk_fec_transaccion.UseVisualStyleBackColor = True
        '
        'cbo_fecha_fin
        '
        Me.cbo_fecha_fin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.cbo_fecha_fin.Location = New System.Drawing.Point(7, 52)
        Me.cbo_fecha_fin.Name = "cbo_fecha_fin"
        Me.cbo_fecha_fin.Size = New System.Drawing.Size(85, 20)
        Me.cbo_fecha_fin.TabIndex = 1049
        '
        'cbo_fecha_ini
        '
        Me.cbo_fecha_ini.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.cbo_fecha_ini.Location = New System.Drawing.Point(7, 30)
        Me.cbo_fecha_ini.Name = "cbo_fecha_ini"
        Me.cbo_fecha_ini.Size = New System.Drawing.Size(85, 20)
        Me.cbo_fecha_ini.TabIndex = 1047
        '
        'SaveFileDialog1
        '
        Me.SaveFileDialog1.Filter = """JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif"""
        Me.SaveFileDialog1.Title = "Guardar imagen como"
        '
        'imgProcesar
        '
        Me.imgProcesar.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.imgProcesar.Image = Global.Spic.My.Resources.Resources.procesando
        Me.imgProcesar.Location = New System.Drawing.Point(80, 140)
        Me.imgProcesar.Name = "imgProcesar"
        Me.imgProcesar.Size = New System.Drawing.Size(548, 324)
        Me.imgProcesar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgProcesar.TabIndex = 140
        Me.imgProcesar.TabStop = False
        Me.imgProcesar.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.chk_turno)
        Me.GroupBox2.Controls.Add(Me.chk_consol_dia)
        Me.GroupBox2.Controls.Add(Me.chk_consol_ref)
        Me.GroupBox2.Controls.Add(Me.chk_consol_op)
        Me.GroupBox2.Location = New System.Drawing.Point(439, 28)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(83, 75)
        Me.GroupBox2.TabIndex = 1049
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Consolidar"
        '
        'chk_turno
        '
        Me.chk_turno.AutoSize = True
        Me.chk_turno.Location = New System.Drawing.Point(4, 56)
        Me.chk_turno.Name = "chk_turno"
        Me.chk_turno.Size = New System.Drawing.Size(54, 17)
        Me.chk_turno.TabIndex = 1049
        Me.chk_turno.Text = "Turno"
        Me.chk_turno.UseVisualStyleBackColor = True
        '
        'chk_consol_dia
        '
        Me.chk_consol_dia.AutoSize = True
        Me.chk_consol_dia.Location = New System.Drawing.Point(4, 42)
        Me.chk_consol_dia.Name = "chk_consol_dia"
        Me.chk_consol_dia.Size = New System.Drawing.Size(44, 17)
        Me.chk_consol_dia.TabIndex = 1048
        Me.chk_consol_dia.Text = "Día"
        Me.chk_consol_dia.UseVisualStyleBackColor = True
        '
        'chk_consol_ref
        '
        Me.chk_consol_ref.AutoSize = True
        Me.chk_consol_ref.Location = New System.Drawing.Point(4, 28)
        Me.chk_consol_ref.Name = "chk_consol_ref"
        Me.chk_consol_ref.Size = New System.Drawing.Size(78, 17)
        Me.chk_consol_ref.TabIndex = 1047
        Me.chk_consol_ref.Text = "Referencia"
        Me.chk_consol_ref.UseVisualStyleBackColor = True
        '
        'chk_granel
        '
        Me.chk_granel.AutoSize = True
        Me.chk_granel.Checked = True
        Me.chk_granel.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk_granel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_granel.Location = New System.Drawing.Point(140, 10)
        Me.chk_granel.Name = "chk_granel"
        Me.chk_granel.Size = New System.Drawing.Size(114, 17)
        Me.chk_granel.TabIndex = 1050
        Me.chk_granel.Text = "Excluir a granel"
        Me.chk_granel.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(570, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 13)
        Me.Label1.TabIndex = 1051
        Me.Label1.Text = "Total cartones:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(528, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(120, 13)
        Me.Label2.TabIndex = 1052
        Me.Label2.Text = "Promedio día empaque:"
        '
        'chk_excluir_empaques_contenidos
        '
        Me.chk_excluir_empaques_contenidos.AutoSize = True
        Me.chk_excluir_empaques_contenidos.Checked = True
        Me.chk_excluir_empaques_contenidos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk_excluir_empaques_contenidos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_excluir_empaques_contenidos.Location = New System.Drawing.Point(481, 10)
        Me.chk_excluir_empaques_contenidos.Name = "chk_excluir_empaques_contenidos"
        Me.chk_excluir_empaques_contenidos.Size = New System.Drawing.Size(173, 17)
        Me.chk_excluir_empaques_contenidos.TabIndex = 1053
        Me.chk_excluir_empaques_contenidos.Text = "Excluir empresas externas"
        Me.chk_excluir_empaques_contenidos.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(526, 54)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(123, 13)
        Me.Label5.TabIndex = 1054
        Me.Label5.Text = "Empaques y contenidos:"
        '
        'lbl_emp_contenidos
        '
        Me.lbl_emp_contenidos.AutoSize = True
        Me.lbl_emp_contenidos.Location = New System.Drawing.Point(649, 54)
        Me.lbl_emp_contenidos.Name = "lbl_emp_contenidos"
        Me.lbl_emp_contenidos.Size = New System.Drawing.Size(57, 13)
        Me.lbl_emp_contenidos.TabIndex = 1057
        Me.lbl_emp_contenidos.Text = "Empaques"
        '
        'lbl_prom_dia
        '
        Me.lbl_prom_dia.AutoSize = True
        Me.lbl_prom_dia.Location = New System.Drawing.Point(649, 41)
        Me.lbl_prom_dia.Name = "lbl_prom_dia"
        Me.lbl_prom_dia.Size = New System.Drawing.Size(51, 13)
        Me.lbl_prom_dia.TabIndex = 1056
        Me.lbl_prom_dia.Text = "Promedio"
        '
        'lbl_tot_cartones
        '
        Me.lbl_tot_cartones.AutoSize = True
        Me.lbl_tot_cartones.Location = New System.Drawing.Point(649, 28)
        Me.lbl_tot_cartones.Name = "lbl_tot_cartones"
        Me.lbl_tot_cartones.Size = New System.Drawing.Size(31, 13)
        Me.lbl_tot_cartones.TabIndex = 1055
        Me.lbl_tot_cartones.Text = "Total"
        '
        'lbl_colpack
        '
        Me.lbl_colpack.AutoSize = True
        Me.lbl_colpack.Location = New System.Drawing.Point(649, 66)
        Me.lbl_colpack.Name = "lbl_colpack"
        Me.lbl_colpack.Size = New System.Drawing.Size(46, 13)
        Me.lbl_colpack.TabIndex = 1059
        Me.lbl_colpack.Text = "Colpack"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(576, 66)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(74, 13)
        Me.Label7.TabIndex = 1058
        Me.Label7.Text = "Colpack s.a.s:"
        '
        'chk_excluir_grapa
        '
        Me.chk_excluir_grapa.AutoSize = True
        Me.chk_excluir_grapa.Checked = True
        Me.chk_excluir_grapa.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk_excluir_grapa.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_excluir_grapa.Location = New System.Drawing.Point(253, 10)
        Me.chk_excluir_grapa.Name = "chk_excluir_grapa"
        Me.chk_excluir_grapa.Size = New System.Drawing.Size(102, 17)
        Me.chk_excluir_grapa.TabIndex = 1060
        Me.chk_excluir_grapa.Text = "Excluir Grapa"
        Me.chk_excluir_grapa.UseVisualStyleBackColor = True
        '
        'chk_excluir_arandela
        '
        Me.chk_excluir_arandela.AutoSize = True
        Me.chk_excluir_arandela.Checked = True
        Me.chk_excluir_arandela.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk_excluir_arandela.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_excluir_arandela.Location = New System.Drawing.Point(357, 10)
        Me.chk_excluir_arandela.Name = "chk_excluir_arandela"
        Me.chk_excluir_arandela.Size = New System.Drawing.Size(118, 17)
        Me.chk_excluir_arandela.TabIndex = 1061
        Me.chk_excluir_arandela.Text = "Excluir Arandela"
        Me.chk_excluir_arandela.UseVisualStyleBackColor = True
        '
        'lbl_apl
        '
        Me.lbl_apl.AutoSize = True
        Me.lbl_apl.Location = New System.Drawing.Point(648, 80)
        Me.lbl_apl.Name = "lbl_apl"
        Me.lbl_apl.Size = New System.Drawing.Size(22, 13)
        Me.lbl_apl.TabIndex = 1063
        Me.lbl_apl.Text = "Apl"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(580, 80)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(69, 13)
        Me.Label8.TabIndex = 1062
        Me.Label8.Text = "Apl servicios:"
        '
        'lbl_decor
        '
        Me.lbl_decor.AutoSize = True
        Me.lbl_decor.Location = New System.Drawing.Point(649, 93)
        Me.lbl_decor.Name = "lbl_decor"
        Me.lbl_decor.Size = New System.Drawing.Size(34, 13)
        Me.lbl_decor.TabIndex = 1065
        Me.lbl_decor.Text = "decor"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(543, 93)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(105, 13)
        Me.Label9.TabIndex = 1064
        Me.Label9.Text = "Decormaquilas s.a.s:"
        '
        'Frm_consultar_empaque_punt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(704, 481)
        Me.Controls.Add(Me.lbl_decor)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.lbl_apl)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.chk_excluir_arandela)
        Me.Controls.Add(Me.chk_excluir_grapa)
        Me.Controls.Add(Me.lbl_colpack)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.lbl_emp_contenidos)
        Me.Controls.Add(Me.lbl_prom_dia)
        Me.Controls.Add(Me.lbl_tot_cartones)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.chk_excluir_empaques_contenidos)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.chk_granel)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Toolbar1)
        Me.Controls.Add(Me.imgProcesar)
        Me.Controls.Add(Me.dtg_consulta)
        Me.Name = "Frm_consultar_empaque_punt"
        Me.Text = "Consultar empaque puntilleria"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dtg_consulta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.menStripDtg.ResumeLayout(False)
        Me.Toolbar1.ResumeLayout(False)
        Me.Toolbar1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.imgProcesar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents imgProcesar As System.Windows.Forms.PictureBox
    Friend WithEvents dtg_consulta As System.Windows.Forms.DataGridView
    Friend WithEvents Toolbar1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btn_excel As System.Windows.Forms.ToolStripButton
    Friend WithEvents cbo_operario As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents menStripDtg As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents EliminarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cbo_fecha_fin As System.Windows.Forms.DateTimePicker
    Friend WithEvents cbo_fecha_ini As System.Windows.Forms.DateTimePicker
    Friend WithEvents chk_consol_op As System.Windows.Forms.CheckBox
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents chk_consol_ref As System.Windows.Forms.CheckBox
    Friend WithEvents btn_actualizar As System.Windows.Forms.ToolStripButton
    Friend WithEvents chk_consol_dia As System.Windows.Forms.CheckBox
    Friend WithEvents txt_transaccion As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents chk_turno As System.Windows.Forms.CheckBox
    Friend WithEvents chk_granel As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents chk_excluir_empaques_contenidos As System.Windows.Forms.CheckBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lbl_emp_contenidos As System.Windows.Forms.Label
    Friend WithEvents lbl_prom_dia As System.Windows.Forms.Label
    Friend WithEvents lbl_tot_cartones As System.Windows.Forms.Label
    Friend WithEvents lbl_colpack As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents chk_excluir_grapa As System.Windows.Forms.CheckBox
    Friend WithEvents chk_excluir_arandela As System.Windows.Forms.CheckBox
    Friend WithEvents lbl_apl As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents chk_fec_transaccion As System.Windows.Forms.CheckBox
    Friend WithEvents lbl_decor As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
End Class
