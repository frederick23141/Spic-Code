<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_programacion_turnos
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Toolbar1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btn_salir = New System.Windows.Forms.ToolStripButton()
        Me.btn_ppal = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnConsol = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSplitButton1 = New System.Windows.Forms.ToolStripButton()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.cbo_periodo = New System.Windows.Forms.ComboBox()
        Me.menStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.itemMod = New System.Windows.Forms.ToolStripMenuItem()
        Me.IngresarNovedadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OtorgarPermisoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CompromisoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DetalleDeNovedadescompromisosYPermisosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VerMarcacionesDelPeriodoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EliminarTurnoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.cbo_centro = New System.Windows.Forms.ComboBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.groupTurno = New System.Windows.Forms.GroupBox()
        Me.btn_cerrar_graf = New System.Windows.Forms.Button()
        Me.dtgTurno = New System.Windows.Forms.DataGridView()
        Me.col_ok = New System.Windows.Forms.DataGridViewImageColumn()
        Me.dtg_consulta = New System.Windows.Forms.DataGridView()
        Me.group_novedad = New System.Windows.Forms.GroupBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtValNov = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.cbo_fec_novedad = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txt_horas_novedad = New System.Windows.Forms.TextBox()
        Me.btn_ok_novedad = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txt_concepto = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txt_desc_novedad = New System.Windows.Forms.TextBox()
        Me.txt_observaciones_novedad = New System.Windows.Forms.RichTextBox()
        Me.btn_cerrar_novedades = New System.Windows.Forms.Button()
        Me.dtg_novedad = New System.Windows.Forms.DataGridView()
        Me.col_add_novedad = New System.Windows.Forms.DataGridViewImageColumn()
        Me.group_permiso = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cbo_min = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cbo_hora = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboFechaPer = New System.Windows.Forms.DateTimePicker()
        Me.btn_ok_permiso = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txt_observacion_permiso = New System.Windows.Forms.RichTextBox()
        Me.btn_cerrar_permiso = New System.Windows.Forms.Button()
        Me.group_compromiso = New System.Windows.Forms.GroupBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.dtgCompromisos = New System.Windows.Forms.DataGridView()
        Me.colBorrar = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txt_horas_compromiso = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cbo_min_compromiso = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cbo_hora_compromiso = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cbo_fec_compromiso = New System.Windows.Forms.DateTimePicker()
        Me.btn_ok_compromiso = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txt_observaciones_compromiso = New System.Windows.Forms.RichTextBox()
        Me.btn_cerrar_compromiso = New System.Windows.Forms.Button()
        Me.chk_comp_nocturno = New System.Windows.Forms.CheckBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.lbl_horas_laborales = New System.Windows.Forms.Label()
        Me.lbl_tot_horas = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.group_detalle = New System.Windows.Forms.GroupBox()
        Me.btn_cerrar_detalle = New System.Windows.Forms.Button()
        Me.dtg_detalle = New System.Windows.Forms.DataGridView()
        Me.lblFest = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.imgProcesar = New System.Windows.Forms.PictureBox()
        Me.group_motivo_extras = New System.Windows.Forms.GroupBox()
        Me.btn_cerrar_mot_extras = New System.Windows.Forms.Button()
        Me.dtg_mot_extras = New System.Windows.Forms.DataGridView()
        Me.DataGridViewImageColumn1 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.cbo_operario = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.group_detalle_marcaciones = New System.Windows.Forms.GroupBox()
        Me.btn_cerrar_det_marcaciones = New System.Windows.Forms.Button()
        Me.dtg_detalle_marcaciones = New System.Windows.Forms.DataGridView()
        Me.chk_temporales = New System.Windows.Forms.CheckBox()
        Me.Toolbar1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.menStrip.SuspendLayout()
        Me.groupTurno.SuspendLayout()
        CType(Me.dtgTurno, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtg_consulta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.group_novedad.SuspendLayout()
        CType(Me.dtg_novedad, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.group_permiso.SuspendLayout()
        Me.group_compromiso.SuspendLayout()
        CType(Me.dtgCompromisos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.group_detalle.SuspendLayout()
        CType(Me.dtg_detalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgProcesar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.group_motivo_extras.SuspendLayout()
        CType(Me.dtg_mot_extras, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.group_detalle_marcaciones.SuspendLayout()
        CType(Me.dtg_detalle_marcaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Toolbar1
        '
        Me.Toolbar1.AutoSize = False
        Me.Toolbar1.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.Toolbar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Toolbar1.ImageScalingSize = New System.Drawing.Size(23, 23)
        Me.Toolbar1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator2, Me.btn_salir, Me.btn_ppal, Me.ToolStripSeparator3, Me.btnConsol, Me.ToolStripSplitButton1})
        Me.Toolbar1.Location = New System.Drawing.Point(0, 0)
        Me.Toolbar1.Name = "Toolbar1"
        Me.Toolbar1.Size = New System.Drawing.Size(894, 34)
        Me.Toolbar1.TabIndex = 1068
        Me.Toolbar1.Text = "ToolStrip1"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 34)
        '
        'btn_salir
        '
        Me.btn_salir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_salir.Image = Global.Spic.My.Resources.Resources._1349388328_door_in
        Me.btn_salir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_salir.Name = "btn_salir"
        Me.btn_salir.Size = New System.Drawing.Size(27, 31)
        Me.btn_salir.Text = "ToolStripButton1"
        Me.btn_salir.ToolTipText = "Salir"
        '
        'btn_ppal
        '
        Me.btn_ppal.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_ppal.Image = Global.Spic.My.Resources.Resources.ppal3
        Me.btn_ppal.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_ppal.Name = "btn_ppal"
        Me.btn_ppal.Size = New System.Drawing.Size(27, 31)
        Me.btn_ppal.Text = "ToolStripButton2"
        Me.btn_ppal.ToolTipText = "Menú principal"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 34)
        '
        'btnConsol
        '
        Me.btnConsol.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnConsol.Image = Global.Spic.My.Resources.Resources.update
        Me.btnConsol.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnConsol.Name = "btnConsol"
        Me.btnConsol.Size = New System.Drawing.Size(27, 31)
        Me.btnConsol.Text = "Actualizar consulta"
        '
        'ToolStripSplitButton1
        '
        Me.ToolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripSplitButton1.Image = Global.Spic.My.Resources.Resources.excel
        Me.ToolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripSplitButton1.Name = "ToolStripSplitButton1"
        Me.ToolStripSplitButton1.Size = New System.Drawing.Size(27, 31)
        Me.ToolStripSplitButton1.Text = "Exportar a excel"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cbo_periodo)
        Me.GroupBox3.Location = New System.Drawing.Point(6, 35)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(195, 40)
        Me.GroupBox3.TabIndex = 1072
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Seleccione periodo"
        '
        'cbo_periodo
        '
        Me.cbo_periodo.FormattingEnabled = True
        Me.cbo_periodo.Items.AddRange(New Object() {"Enero ", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"})
        Me.cbo_periodo.Location = New System.Drawing.Point(6, 13)
        Me.cbo_periodo.Name = "cbo_periodo"
        Me.cbo_periodo.Size = New System.Drawing.Size(188, 21)
        Me.cbo_periodo.TabIndex = 1089
        Me.cbo_periodo.Text = "Seleccione"
        '
        'menStrip
        '
        Me.menStrip.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.menStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.itemMod, Me.IngresarNovedadToolStripMenuItem, Me.OtorgarPermisoToolStripMenuItem, Me.CompromisoToolStripMenuItem, Me.DetalleDeNovedadescompromisosYPermisosToolStripMenuItem, Me.VerMarcacionesDelPeriodoToolStripMenuItem, Me.EliminarTurnoToolStripMenuItem})
        Me.menStrip.Name = "ContextMenuStrip1"
        Me.menStrip.Size = New System.Drawing.Size(343, 158)
        '
        'itemMod
        '
        Me.itemMod.Image = Global.Spic.My.Resources.Resources.edit
        Me.itemMod.Name = "itemMod"
        Me.itemMod.Size = New System.Drawing.Size(342, 22)
        Me.itemMod.Text = "Asignar turno"
        '
        'IngresarNovedadToolStripMenuItem
        '
        Me.IngresarNovedadToolStripMenuItem.Image = Global.Spic.My.Resources.Resources.mas
        Me.IngresarNovedadToolStripMenuItem.Name = "IngresarNovedadToolStripMenuItem"
        Me.IngresarNovedadToolStripMenuItem.Size = New System.Drawing.Size(342, 22)
        Me.IngresarNovedadToolStripMenuItem.Text = "Ingresar novedad"
        '
        'OtorgarPermisoToolStripMenuItem
        '
        Me.OtorgarPermisoToolStripMenuItem.Image = Global.Spic.My.Resources.Resources.nuevo
        Me.OtorgarPermisoToolStripMenuItem.Name = "OtorgarPermisoToolStripMenuItem"
        Me.OtorgarPermisoToolStripMenuItem.Size = New System.Drawing.Size(342, 22)
        Me.OtorgarPermisoToolStripMenuItem.Text = "Otorgar permiso"
        '
        'CompromisoToolStripMenuItem
        '
        Me.CompromisoToolStripMenuItem.Image = Global.Spic.My.Resources.Resources._1385694500_document_add
        Me.CompromisoToolStripMenuItem.Name = "CompromisoToolStripMenuItem"
        Me.CompromisoToolStripMenuItem.Size = New System.Drawing.Size(342, 22)
        Me.CompromisoToolStripMenuItem.Text = "Compromisos"
        '
        'DetalleDeNovedadescompromisosYPermisosToolStripMenuItem
        '
        Me.DetalleDeNovedadescompromisosYPermisosToolStripMenuItem.Image = Global.Spic.My.Resources.Resources.buscar7
        Me.DetalleDeNovedadescompromisosYPermisosToolStripMenuItem.Name = "DetalleDeNovedadescompromisosYPermisosToolStripMenuItem"
        Me.DetalleDeNovedadescompromisosYPermisosToolStripMenuItem.Size = New System.Drawing.Size(342, 22)
        Me.DetalleDeNovedadescompromisosYPermisosToolStripMenuItem.Text = "Detalle de novedades-compromisos y permisos"
        '
        'VerMarcacionesDelPeriodoToolStripMenuItem
        '
        Me.VerMarcacionesDelPeriodoToolStripMenuItem.Image = Global.Spic.My.Resources.Resources.buscar7
        Me.VerMarcacionesDelPeriodoToolStripMenuItem.Name = "VerMarcacionesDelPeriodoToolStripMenuItem"
        Me.VerMarcacionesDelPeriodoToolStripMenuItem.Size = New System.Drawing.Size(342, 22)
        Me.VerMarcacionesDelPeriodoToolStripMenuItem.Text = "Ver marcaciones del periodo"
        '
        'EliminarTurnoToolStripMenuItem
        '
        Me.EliminarTurnoToolStripMenuItem.Image = Global.Spic.My.Resources.Resources.x
        Me.EliminarTurnoToolStripMenuItem.Name = "EliminarTurnoToolStripMenuItem"
        Me.EliminarTurnoToolStripMenuItem.Size = New System.Drawing.Size(342, 22)
        Me.EliminarTurnoToolStripMenuItem.Text = "Eliminar turno"
        '
        'cbo_centro
        '
        Me.cbo_centro.FormattingEnabled = True
        Me.cbo_centro.Items.AddRange(New Object() {"Enero ", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"})
        Me.cbo_centro.Location = New System.Drawing.Point(6, 13)
        Me.cbo_centro.Name = "cbo_centro"
        Me.cbo_centro.Size = New System.Drawing.Size(277, 21)
        Me.cbo_centro.TabIndex = 1081
        Me.cbo_centro.Text = "Seleccione"
        '
        'groupTurno
        '
        Me.groupTurno.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.groupTurno.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.groupTurno.Controls.Add(Me.btn_cerrar_graf)
        Me.groupTurno.Controls.Add(Me.dtgTurno)
        Me.groupTurno.Location = New System.Drawing.Point(87, 142)
        Me.groupTurno.Name = "groupTurno"
        Me.groupTurno.Size = New System.Drawing.Size(567, 257)
        Me.groupTurno.TabIndex = 1087
        Me.groupTurno.TabStop = False
        Me.groupTurno.Text = "Seleccione turno"
        Me.groupTurno.Visible = False
        '
        'btn_cerrar_graf
        '
        Me.btn_cerrar_graf.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_cerrar_graf.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_cerrar_graf.ForeColor = System.Drawing.Color.Red
        Me.btn_cerrar_graf.Location = New System.Drawing.Point(543, 1)
        Me.btn_cerrar_graf.Name = "btn_cerrar_graf"
        Me.btn_cerrar_graf.Size = New System.Drawing.Size(20, 23)
        Me.btn_cerrar_graf.TabIndex = 1088
        Me.btn_cerrar_graf.Text = "X"
        Me.btn_cerrar_graf.UseVisualStyleBackColor = True
        '
        'dtgTurno
        '
        Me.dtgTurno.AllowUserToAddRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dtgTurno.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dtgTurno.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtgTurno.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dtgTurno.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dtgTurno.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgTurno.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.col_ok})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.Format = "N0"
        DataGridViewCellStyle2.NullValue = "0"
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtgTurno.DefaultCellStyle = DataGridViewCellStyle2
        Me.dtgTurno.Location = New System.Drawing.Point(6, 24)
        Me.dtgTurno.Name = "dtgTurno"
        Me.dtgTurno.ReadOnly = True
        Me.dtgTurno.RowHeadersVisible = False
        Me.dtgTurno.Size = New System.Drawing.Size(555, 225)
        Me.dtgTurno.TabIndex = 1087
        '
        'col_ok
        '
        Me.col_ok.Frozen = True
        Me.col_ok.HeaderText = ""
        Me.col_ok.Image = Global.Spic.My.Resources.Resources.ok3
        Me.col_ok.Name = "col_ok"
        Me.col_ok.ReadOnly = True
        Me.col_ok.Visible = False
        Me.col_ok.Width = 5
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
        Me.dtg_consulta.ContextMenuStrip = Me.menStrip
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.Format = "N0"
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtg_consulta.DefaultCellStyle = DataGridViewCellStyle3
        Me.dtg_consulta.Location = New System.Drawing.Point(7, 82)
        Me.dtg_consulta.Name = "dtg_consulta"
        Me.dtg_consulta.RowHeadersVisible = False
        Me.dtg_consulta.Size = New System.Drawing.Size(875, 308)
        Me.dtg_consulta.TabIndex = 1088
        '
        'group_novedad
        '
        Me.group_novedad.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.group_novedad.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.group_novedad.Controls.Add(Me.Label22)
        Me.group_novedad.Controls.Add(Me.txtValNov)
        Me.group_novedad.Controls.Add(Me.Label20)
        Me.group_novedad.Controls.Add(Me.cbo_fec_novedad)
        Me.group_novedad.Controls.Add(Me.Label4)
        Me.group_novedad.Controls.Add(Me.txt_horas_novedad)
        Me.group_novedad.Controls.Add(Me.btn_ok_novedad)
        Me.group_novedad.Controls.Add(Me.Label3)
        Me.group_novedad.Controls.Add(Me.Label2)
        Me.group_novedad.Controls.Add(Me.txt_concepto)
        Me.group_novedad.Controls.Add(Me.Label1)
        Me.group_novedad.Controls.Add(Me.txt_desc_novedad)
        Me.group_novedad.Controls.Add(Me.txt_observaciones_novedad)
        Me.group_novedad.Controls.Add(Me.btn_cerrar_novedades)
        Me.group_novedad.Controls.Add(Me.dtg_novedad)
        Me.group_novedad.Location = New System.Drawing.Point(132, 98)
        Me.group_novedad.Name = "group_novedad"
        Me.group_novedad.Size = New System.Drawing.Size(578, 293)
        Me.group_novedad.TabIndex = 1089
        Me.group_novedad.TabStop = False
        Me.group_novedad.Text = "Seleccione novedad"
        Me.group_novedad.Visible = False
        '
        'Label22
        '
        Me.Label22.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(463, 148)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(52, 13)
        Me.Label22.TabIndex = 1101
        Me.Label22.Text = "VALOR:"
        '
        'txtValNov
        '
        Me.txtValNov.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtValNov.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtValNov.ForeColor = System.Drawing.Color.Red
        Me.txtValNov.Location = New System.Drawing.Point(516, 144)
        Me.txtValNov.Name = "txtValNov"
        Me.txtValNov.Size = New System.Drawing.Size(57, 21)
        Me.txtValNov.TabIndex = 1100
        '
        'Label20
        '
        Me.Label20.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(7, 144)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(46, 13)
        Me.Label20.TabIndex = 1098
        Me.Label20.Text = "Fecha:"
        '
        'cbo_fec_novedad
        '
        Me.cbo_fec_novedad.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cbo_fec_novedad.Enabled = False
        Me.cbo_fec_novedad.Location = New System.Drawing.Point(53, 142)
        Me.cbo_fec_novedad.Name = "cbo_fec_novedad"
        Me.cbo_fec_novedad.Size = New System.Drawing.Size(213, 20)
        Me.cbo_fec_novedad.TabIndex = 1099
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(461, 174)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(54, 13)
        Me.Label4.TabIndex = 1097
        Me.Label4.Text = "HORAS:"
        '
        'txt_horas_novedad
        '
        Me.txt_horas_novedad.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txt_horas_novedad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_horas_novedad.ForeColor = System.Drawing.Color.Red
        Me.txt_horas_novedad.Location = New System.Drawing.Point(516, 171)
        Me.txt_horas_novedad.Name = "txt_horas_novedad"
        Me.txt_horas_novedad.Size = New System.Drawing.Size(56, 21)
        Me.txt_horas_novedad.TabIndex = 1096
        '
        'btn_ok_novedad
        '
        Me.btn_ok_novedad.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_ok_novedad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ok_novedad.ForeColor = System.Drawing.Color.Black
        Me.btn_ok_novedad.Image = Global.Spic.My.Resources.Resources.ok3
        Me.btn_ok_novedad.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_ok_novedad.Location = New System.Drawing.Point(176, 268)
        Me.btn_ok_novedad.Name = "btn_ok_novedad"
        Me.btn_ok_novedad.Size = New System.Drawing.Size(83, 23)
        Me.btn_ok_novedad.TabIndex = 1095
        Me.btn_ok_novedad.Text = "Terminar"
        Me.btn_ok_novedad.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_ok_novedad.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 191)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 13)
        Me.Label3.TabIndex = 1094
        Me.Label3.Text = "Observaciones"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(1, 173)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 1093
        Me.Label2.Text = "Concepto"
        '
        'txt_concepto
        '
        Me.txt_concepto.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txt_concepto.Location = New System.Drawing.Point(54, 170)
        Me.txt_concepto.Name = "txt_concepto"
        Me.txt_concepto.ReadOnly = True
        Me.txt_concepto.Size = New System.Drawing.Size(39, 20)
        Me.txt_concepto.TabIndex = 1092
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(98, 174)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 1091
        Me.Label1.Text = "Novedad"
        '
        'txt_desc_novedad
        '
        Me.txt_desc_novedad.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txt_desc_novedad.Location = New System.Drawing.Point(151, 171)
        Me.txt_desc_novedad.Name = "txt_desc_novedad"
        Me.txt_desc_novedad.ReadOnly = True
        Me.txt_desc_novedad.Size = New System.Drawing.Size(274, 20)
        Me.txt_desc_novedad.TabIndex = 1090
        '
        'txt_observaciones_novedad
        '
        Me.txt_observaciones_novedad.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_observaciones_novedad.Location = New System.Drawing.Point(6, 209)
        Me.txt_observaciones_novedad.Name = "txt_observaciones_novedad"
        Me.txt_observaciones_novedad.Size = New System.Drawing.Size(566, 57)
        Me.txt_observaciones_novedad.TabIndex = 1089
        Me.txt_observaciones_novedad.Text = ""
        '
        'btn_cerrar_novedades
        '
        Me.btn_cerrar_novedades.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_cerrar_novedades.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_cerrar_novedades.ForeColor = System.Drawing.Color.Red
        Me.btn_cerrar_novedades.Location = New System.Drawing.Point(554, 1)
        Me.btn_cerrar_novedades.Name = "btn_cerrar_novedades"
        Me.btn_cerrar_novedades.Size = New System.Drawing.Size(20, 23)
        Me.btn_cerrar_novedades.TabIndex = 1088
        Me.btn_cerrar_novedades.Text = "X"
        Me.btn_cerrar_novedades.UseVisualStyleBackColor = True
        '
        'dtg_novedad
        '
        Me.dtg_novedad.AllowUserToAddRows = False
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dtg_novedad.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
        Me.dtg_novedad.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtg_novedad.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dtg_novedad.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dtg_novedad.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtg_novedad.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.col_add_novedad})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.Format = "N0"
        DataGridViewCellStyle5.NullValue = "0"
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtg_novedad.DefaultCellStyle = DataGridViewCellStyle5
        Me.dtg_novedad.Location = New System.Drawing.Point(6, 24)
        Me.dtg_novedad.Name = "dtg_novedad"
        Me.dtg_novedad.ReadOnly = True
        Me.dtg_novedad.RowHeadersVisible = False
        Me.dtg_novedad.Size = New System.Drawing.Size(566, 112)
        Me.dtg_novedad.TabIndex = 1087
        '
        'col_add_novedad
        '
        Me.col_add_novedad.HeaderText = ""
        Me.col_add_novedad.Image = Global.Spic.My.Resources.Resources.mas
        Me.col_add_novedad.Name = "col_add_novedad"
        Me.col_add_novedad.ReadOnly = True
        Me.col_add_novedad.Width = 5
        '
        'group_permiso
        '
        Me.group_permiso.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.group_permiso.Controls.Add(Me.Label7)
        Me.group_permiso.Controls.Add(Me.cbo_min)
        Me.group_permiso.Controls.Add(Me.Label8)
        Me.group_permiso.Controls.Add(Me.cbo_hora)
        Me.group_permiso.Controls.Add(Me.Label5)
        Me.group_permiso.Controls.Add(Me.cboFechaPer)
        Me.group_permiso.Controls.Add(Me.btn_ok_permiso)
        Me.group_permiso.Controls.Add(Me.Label6)
        Me.group_permiso.Controls.Add(Me.txt_observacion_permiso)
        Me.group_permiso.Controls.Add(Me.btn_cerrar_permiso)
        Me.group_permiso.Location = New System.Drawing.Point(268, 104)
        Me.group_permiso.Name = "group_permiso"
        Me.group_permiso.Size = New System.Drawing.Size(329, 215)
        Me.group_permiso.TabIndex = 1090
        Me.group_permiso.TabStop = False
        Me.group_permiso.Text = "Ingrese detalles del permiso"
        Me.group_permiso.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(159, 57)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(49, 13)
        Me.Label7.TabIndex = 1101
        Me.Label7.Text = "Minuto:"
        '
        'cbo_min
        '
        Me.cbo_min.FormattingEnabled = True
        Me.cbo_min.Items.AddRange(New Object() {"00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "51", "52", "53", "54", "55", "56", "57", "58", "59", "", ""})
        Me.cbo_min.Location = New System.Drawing.Point(212, 54)
        Me.cbo_min.Name = "cbo_min"
        Me.cbo_min.Size = New System.Drawing.Size(80, 21)
        Me.cbo_min.TabIndex = 1100
        Me.cbo_min.Text = "00"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(-1, 57)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(75, 13)
        Me.Label8.TabIndex = 1099
        Me.Label8.Text = "Hora militar:"
        '
        'cbo_hora
        '
        Me.cbo_hora.FormattingEnabled = True
        Me.cbo_hora.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24"})
        Me.cbo_hora.Location = New System.Drawing.Point(79, 54)
        Me.cbo_hora.Name = "cbo_hora"
        Me.cbo_hora.Size = New System.Drawing.Size(74, 21)
        Me.cbo_hora.TabIndex = 1098
        Me.cbo_hora.Text = "6"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(27, 28)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(46, 13)
        Me.Label5.TabIndex = 1096
        Me.Label5.Text = "Fecha:"
        '
        'cboFechaPer
        '
        Me.cboFechaPer.Location = New System.Drawing.Point(79, 26)
        Me.cboFechaPer.Name = "cboFechaPer"
        Me.cboFechaPer.Size = New System.Drawing.Size(213, 20)
        Me.cboFechaPer.TabIndex = 1097
        '
        'btn_ok_permiso
        '
        Me.btn_ok_permiso.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_ok_permiso.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ok_permiso.ForeColor = System.Drawing.Color.Black
        Me.btn_ok_permiso.Image = Global.Spic.My.Resources.Resources.ok3
        Me.btn_ok_permiso.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_ok_permiso.Location = New System.Drawing.Point(115, 189)
        Me.btn_ok_permiso.Name = "btn_ok_permiso"
        Me.btn_ok_permiso.Size = New System.Drawing.Size(83, 23)
        Me.btn_ok_permiso.TabIndex = 1095
        Me.btn_ok_permiso.Text = "Terminar"
        Me.btn_ok_permiso.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_ok_permiso.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(3, 88)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(78, 13)
        Me.Label6.TabIndex = 1094
        Me.Label6.Text = "Observaciones"
        '
        'txt_observacion_permiso
        '
        Me.txt_observacion_permiso.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_observacion_permiso.Location = New System.Drawing.Point(6, 104)
        Me.txt_observacion_permiso.Name = "txt_observacion_permiso"
        Me.txt_observacion_permiso.Size = New System.Drawing.Size(317, 82)
        Me.txt_observacion_permiso.TabIndex = 1089
        Me.txt_observacion_permiso.Text = ""
        '
        'btn_cerrar_permiso
        '
        Me.btn_cerrar_permiso.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_cerrar_permiso.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_cerrar_permiso.ForeColor = System.Drawing.Color.Red
        Me.btn_cerrar_permiso.Location = New System.Drawing.Point(305, 1)
        Me.btn_cerrar_permiso.Name = "btn_cerrar_permiso"
        Me.btn_cerrar_permiso.Size = New System.Drawing.Size(20, 23)
        Me.btn_cerrar_permiso.TabIndex = 1088
        Me.btn_cerrar_permiso.Text = "X"
        Me.btn_cerrar_permiso.UseVisualStyleBackColor = True
        '
        'group_compromiso
        '
        Me.group_compromiso.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.group_compromiso.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.group_compromiso.Controls.Add(Me.Label14)
        Me.group_compromiso.Controls.Add(Me.dtgCompromisos)
        Me.group_compromiso.Controls.Add(Me.Label13)
        Me.group_compromiso.Controls.Add(Me.txt_horas_compromiso)
        Me.group_compromiso.Controls.Add(Me.Label9)
        Me.group_compromiso.Controls.Add(Me.cbo_min_compromiso)
        Me.group_compromiso.Controls.Add(Me.Label10)
        Me.group_compromiso.Controls.Add(Me.cbo_hora_compromiso)
        Me.group_compromiso.Controls.Add(Me.Label11)
        Me.group_compromiso.Controls.Add(Me.cbo_fec_compromiso)
        Me.group_compromiso.Controls.Add(Me.btn_ok_compromiso)
        Me.group_compromiso.Controls.Add(Me.Label12)
        Me.group_compromiso.Controls.Add(Me.txt_observaciones_compromiso)
        Me.group_compromiso.Controls.Add(Me.btn_cerrar_compromiso)
        Me.group_compromiso.Controls.Add(Me.chk_comp_nocturno)
        Me.group_compromiso.Location = New System.Drawing.Point(163, 81)
        Me.group_compromiso.Name = "group_compromiso"
        Me.group_compromiso.Size = New System.Drawing.Size(682, 290)
        Me.group_compromiso.TabIndex = 1102
        Me.group_compromiso.TabStop = False
        Me.group_compromiso.Text = "Ingrese detalles del compromiso"
        Me.group_compromiso.Visible = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(6, 14)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(146, 13)
        Me.Label14.TabIndex = 1104
        Me.Label14.Text = "Compromisos pendientes"
        '
        'dtgCompromisos
        '
        Me.dtgCompromisos.AllowUserToAddRows = False
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dtgCompromisos.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle6
        Me.dtgCompromisos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtgCompromisos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dtgCompromisos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dtgCompromisos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgCompromisos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colBorrar})
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.Format = "N0"
        DataGridViewCellStyle7.NullValue = "0"
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtgCompromisos.DefaultCellStyle = DataGridViewCellStyle7
        Me.dtgCompromisos.Location = New System.Drawing.Point(6, 29)
        Me.dtgCompromisos.Name = "dtgCompromisos"
        Me.dtgCompromisos.ReadOnly = True
        Me.dtgCompromisos.RowHeadersVisible = False
        Me.dtgCompromisos.Size = New System.Drawing.Size(671, 257)
        Me.dtgCompromisos.TabIndex = 1098
        '
        'colBorrar
        '
        Me.colBorrar.HeaderText = ""
        Me.colBorrar.Image = Global.Spic.My.Resources.Resources.x
        Me.colBorrar.Name = "colBorrar"
        Me.colBorrar.ReadOnly = True
        Me.colBorrar.Width = 5
        '
        'Label13
        '
        Me.Label13.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(0, 164)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(54, 13)
        Me.Label13.TabIndex = 1103
        Me.Label13.Text = "HORAS:"
        '
        'txt_horas_compromiso
        '
        Me.txt_horas_compromiso.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txt_horas_compromiso.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_horas_compromiso.ForeColor = System.Drawing.Color.Red
        Me.txt_horas_compromiso.Location = New System.Drawing.Point(54, 160)
        Me.txt_horas_compromiso.Name = "txt_horas_compromiso"
        Me.txt_horas_compromiso.Size = New System.Drawing.Size(62, 21)
        Me.txt_horas_compromiso.TabIndex = 1102
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(385, 138)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(49, 13)
        Me.Label9.TabIndex = 1101
        Me.Label9.Text = "Minuto:"
        '
        'cbo_min_compromiso
        '
        Me.cbo_min_compromiso.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cbo_min_compromiso.FormattingEnabled = True
        Me.cbo_min_compromiso.Items.AddRange(New Object() {"00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "51", "52", "53", "54", "55", "56", "57", "58", "59", "", ""})
        Me.cbo_min_compromiso.Location = New System.Drawing.Point(434, 135)
        Me.cbo_min_compromiso.Name = "cbo_min_compromiso"
        Me.cbo_min_compromiso.Size = New System.Drawing.Size(41, 21)
        Me.cbo_min_compromiso.TabIndex = 1100
        Me.cbo_min_compromiso.Text = "00"
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(268, 136)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(75, 13)
        Me.Label10.TabIndex = 1099
        Me.Label10.Text = "Hora militar:"
        '
        'cbo_hora_compromiso
        '
        Me.cbo_hora_compromiso.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cbo_hora_compromiso.FormattingEnabled = True
        Me.cbo_hora_compromiso.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24"})
        Me.cbo_hora_compromiso.Location = New System.Drawing.Point(344, 134)
        Me.cbo_hora_compromiso.Name = "cbo_hora_compromiso"
        Me.cbo_hora_compromiso.Size = New System.Drawing.Size(38, 21)
        Me.cbo_hora_compromiso.TabIndex = 1098
        Me.cbo_hora_compromiso.Text = "6"
        '
        'Label11
        '
        Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(5, 136)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(46, 13)
        Me.Label11.TabIndex = 1096
        Me.Label11.Text = "Fecha:"
        '
        'cbo_fec_compromiso
        '
        Me.cbo_fec_compromiso.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cbo_fec_compromiso.Location = New System.Drawing.Point(54, 134)
        Me.cbo_fec_compromiso.Name = "cbo_fec_compromiso"
        Me.cbo_fec_compromiso.Size = New System.Drawing.Size(213, 20)
        Me.cbo_fec_compromiso.TabIndex = 1097
        '
        'btn_ok_compromiso
        '
        Me.btn_ok_compromiso.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_ok_compromiso.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ok_compromiso.ForeColor = System.Drawing.Color.Black
        Me.btn_ok_compromiso.Image = Global.Spic.My.Resources.Resources.ok3
        Me.btn_ok_compromiso.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_ok_compromiso.Location = New System.Drawing.Point(198, 263)
        Me.btn_ok_compromiso.Name = "btn_ok_compromiso"
        Me.btn_ok_compromiso.Size = New System.Drawing.Size(83, 23)
        Me.btn_ok_compromiso.TabIndex = 1095
        Me.btn_ok_compromiso.Text = "Terminar"
        Me.btn_ok_compromiso.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_ok_compromiso.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(3, 181)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(78, 13)
        Me.Label12.TabIndex = 1094
        Me.Label12.Text = "Observaciones"
        '
        'txt_observaciones_compromiso
        '
        Me.txt_observaciones_compromiso.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_observaciones_compromiso.Location = New System.Drawing.Point(6, 198)
        Me.txt_observaciones_compromiso.Name = "txt_observaciones_compromiso"
        Me.txt_observaciones_compromiso.Size = New System.Drawing.Size(670, 62)
        Me.txt_observaciones_compromiso.TabIndex = 1089
        Me.txt_observaciones_compromiso.Text = ""
        '
        'btn_cerrar_compromiso
        '
        Me.btn_cerrar_compromiso.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_cerrar_compromiso.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_cerrar_compromiso.ForeColor = System.Drawing.Color.Red
        Me.btn_cerrar_compromiso.Location = New System.Drawing.Point(658, 1)
        Me.btn_cerrar_compromiso.Name = "btn_cerrar_compromiso"
        Me.btn_cerrar_compromiso.Size = New System.Drawing.Size(20, 23)
        Me.btn_cerrar_compromiso.TabIndex = 1088
        Me.btn_cerrar_compromiso.Text = "X"
        Me.btn_cerrar_compromiso.UseVisualStyleBackColor = True
        '
        'chk_comp_nocturno
        '
        Me.chk_comp_nocturno.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chk_comp_nocturno.AutoSize = True
        Me.chk_comp_nocturno.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_comp_nocturno.Location = New System.Drawing.Point(124, 163)
        Me.chk_comp_nocturno.Name = "chk_comp_nocturno"
        Me.chk_comp_nocturno.Size = New System.Drawing.Size(235, 17)
        Me.chk_comp_nocturno.TabIndex = 1106
        Me.chk_comp_nocturno.Text = "Descontar a horas extras nocturnas?"
        Me.chk_comp_nocturno.UseVisualStyleBackColor = True
        '
        'TextBox3
        '
        Me.TextBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox3.BackColor = System.Drawing.Color.Yellow
        Me.TextBox3.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox3.Location = New System.Drawing.Point(720, 19)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.ReadOnly = True
        Me.TextBox3.Size = New System.Drawing.Size(15, 13)
        Me.TextBox3.TabIndex = 1103
        '
        'Label15
        '
        Me.Label15.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(646, 18)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(76, 13)
        Me.Label15.TabIndex = 1105
        Me.Label15.Text = "Deben tiempo:"
        '
        'Label16
        '
        Me.Label16.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(479, 16)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(104, 13)
        Me.Label16.TabIndex = 1107
        Me.Label16.Text = "Domingos y festivos:"
        '
        'TextBox1
        '
        Me.TextBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox1.BackColor = System.Drawing.Color.LightBlue
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox1.Location = New System.Drawing.Point(584, 18)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(14, 13)
        Me.TextBox1.TabIndex = 1106
        '
        'Label17
        '
        Me.Label17.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(515, 2)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(66, 13)
        Me.Label17.TabIndex = 1109
        Me.Label17.Text = "Vacaciones:"
        '
        'TextBox2
        '
        Me.TextBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox2.BackColor = System.Drawing.Color.GreenYellow
        Me.TextBox2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox2.Location = New System.Drawing.Point(584, 2)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ReadOnly = True
        Me.TextBox2.Size = New System.Drawing.Size(13, 13)
        Me.TextBox2.TabIndex = 1108
        '
        'lbl_horas_laborales
        '
        Me.lbl_horas_laborales.AutoSize = True
        Me.lbl_horas_laborales.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_horas_laborales.Location = New System.Drawing.Point(210, 16)
        Me.lbl_horas_laborales.Name = "lbl_horas_laborales"
        Me.lbl_horas_laborales.Size = New System.Drawing.Size(24, 13)
        Me.lbl_horas_laborales.TabIndex = 1108
        Me.lbl_horas_laborales.Text = "lab"
        '
        'lbl_tot_horas
        '
        Me.lbl_tot_horas.AutoSize = True
        Me.lbl_tot_horas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_tot_horas.Location = New System.Drawing.Point(301, 5)
        Me.lbl_tot_horas.Name = "lbl_tot_horas"
        Me.lbl_tot_horas.Size = New System.Drawing.Size(22, 13)
        Me.lbl_tot_horas.TabIndex = 1107
        Me.lbl_tot_horas.Text = "tot"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(128, 16)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(83, 13)
        Me.Label18.TabIndex = 1106
        Me.Label18.Text = "Horas laborales:"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(233, 4)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(72, 13)
        Me.Label19.TabIndex = 1105
        Me.Label19.Text = "Horas totales:"
        '
        'Label21
        '
        Me.Label21.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(651, 2)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(69, 13)
        Me.Label21.TabIndex = 1111
        Me.Label21.Text = "Incapacidad:"
        '
        'TextBox4
        '
        Me.TextBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox4.BackColor = System.Drawing.Color.Red
        Me.TextBox4.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox4.Location = New System.Drawing.Point(722, 2)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.ReadOnly = True
        Me.TextBox4.Size = New System.Drawing.Size(13, 13)
        Me.TextBox4.TabIndex = 1110
        '
        'group_detalle
        '
        Me.group_detalle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.group_detalle.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.group_detalle.Controls.Add(Me.btn_cerrar_detalle)
        Me.group_detalle.Controls.Add(Me.dtg_detalle)
        Me.group_detalle.Location = New System.Drawing.Point(38, 105)
        Me.group_detalle.Name = "group_detalle"
        Me.group_detalle.Size = New System.Drawing.Size(578, 293)
        Me.group_detalle.TabIndex = 1100
        Me.group_detalle.TabStop = False
        Me.group_detalle.Text = "Detalle de novedades - compromisos - permisos"
        Me.group_detalle.Visible = False
        '
        'btn_cerrar_detalle
        '
        Me.btn_cerrar_detalle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_cerrar_detalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_cerrar_detalle.ForeColor = System.Drawing.Color.Red
        Me.btn_cerrar_detalle.Location = New System.Drawing.Point(554, 1)
        Me.btn_cerrar_detalle.Name = "btn_cerrar_detalle"
        Me.btn_cerrar_detalle.Size = New System.Drawing.Size(20, 23)
        Me.btn_cerrar_detalle.TabIndex = 1088
        Me.btn_cerrar_detalle.Text = "X"
        Me.btn_cerrar_detalle.UseVisualStyleBackColor = True
        '
        'dtg_detalle
        '
        Me.dtg_detalle.AllowUserToAddRows = False
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dtg_detalle.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle8
        Me.dtg_detalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtg_detalle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dtg_detalle.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dtg_detalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle9.Format = "N0"
        DataGridViewCellStyle9.NullValue = "0"
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtg_detalle.DefaultCellStyle = DataGridViewCellStyle9
        Me.dtg_detalle.Location = New System.Drawing.Point(6, 24)
        Me.dtg_detalle.Name = "dtg_detalle"
        Me.dtg_detalle.ReadOnly = True
        Me.dtg_detalle.RowHeadersVisible = False
        Me.dtg_detalle.Size = New System.Drawing.Size(566, 259)
        Me.dtg_detalle.TabIndex = 1087
        '
        'lblFest
        '
        Me.lblFest.AutoSize = True
        Me.lblFest.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFest.Location = New System.Drawing.Point(207, 3)
        Me.lblFest.Name = "lblFest"
        Me.lblFest.Size = New System.Drawing.Size(28, 13)
        Me.lblFest.TabIndex = 1113
        Me.lblFest.Text = "fest"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(133, 2)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(77, 13)
        Me.Label23.TabIndex = 1112
        Me.Label23.Text = "Horas festivas:"
        '
        'imgProcesar
        '
        Me.imgProcesar.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.imgProcesar.Image = Global.Spic.My.Resources.Resources.procesando
        Me.imgProcesar.Location = New System.Drawing.Point(70, 140)
        Me.imgProcesar.Name = "imgProcesar"
        Me.imgProcesar.Size = New System.Drawing.Size(753, 188)
        Me.imgProcesar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgProcesar.TabIndex = 1114
        Me.imgProcesar.TabStop = False
        Me.imgProcesar.Visible = False
        '
        'group_motivo_extras
        '
        Me.group_motivo_extras.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.group_motivo_extras.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.group_motivo_extras.Controls.Add(Me.btn_cerrar_mot_extras)
        Me.group_motivo_extras.Controls.Add(Me.dtg_mot_extras)
        Me.group_motivo_extras.Location = New System.Drawing.Point(285, 116)
        Me.group_motivo_extras.Name = "group_motivo_extras"
        Me.group_motivo_extras.Size = New System.Drawing.Size(440, 216)
        Me.group_motivo_extras.TabIndex = 1115
        Me.group_motivo_extras.TabStop = False
        Me.group_motivo_extras.Text = "Seleccione motivo"
        Me.group_motivo_extras.Visible = False
        '
        'btn_cerrar_mot_extras
        '
        Me.btn_cerrar_mot_extras.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_cerrar_mot_extras.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_cerrar_mot_extras.ForeColor = System.Drawing.Color.Red
        Me.btn_cerrar_mot_extras.Location = New System.Drawing.Point(416, 1)
        Me.btn_cerrar_mot_extras.Name = "btn_cerrar_mot_extras"
        Me.btn_cerrar_mot_extras.Size = New System.Drawing.Size(20, 23)
        Me.btn_cerrar_mot_extras.TabIndex = 1088
        Me.btn_cerrar_mot_extras.Text = "X"
        Me.btn_cerrar_mot_extras.UseVisualStyleBackColor = True
        '
        'dtg_mot_extras
        '
        Me.dtg_mot_extras.AllowUserToAddRows = False
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dtg_mot_extras.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle10
        Me.dtg_mot_extras.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtg_mot_extras.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dtg_mot_extras.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dtg_mot_extras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtg_mot_extras.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewImageColumn1})
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle11.Format = "N0"
        DataGridViewCellStyle11.NullValue = "0"
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtg_mot_extras.DefaultCellStyle = DataGridViewCellStyle11
        Me.dtg_mot_extras.Location = New System.Drawing.Point(6, 24)
        Me.dtg_mot_extras.Name = "dtg_mot_extras"
        Me.dtg_mot_extras.ReadOnly = True
        Me.dtg_mot_extras.RowHeadersVisible = False
        Me.dtg_mot_extras.Size = New System.Drawing.Size(428, 184)
        Me.dtg_mot_extras.TabIndex = 1087
        '
        'DataGridViewImageColumn1
        '
        Me.DataGridViewImageColumn1.Frozen = True
        Me.DataGridViewImageColumn1.HeaderText = ""
        Me.DataGridViewImageColumn1.Image = Global.Spic.My.Resources.Resources.ok3
        Me.DataGridViewImageColumn1.Name = "DataGridViewImageColumn1"
        Me.DataGridViewImageColumn1.ReadOnly = True
        Me.DataGridViewImageColumn1.Visible = False
        Me.DataGridViewImageColumn1.Width = 5
        '
        'cbo_operario
        '
        Me.cbo_operario.FormattingEnabled = True
        Me.cbo_operario.Location = New System.Drawing.Point(6, 13)
        Me.cbo_operario.Name = "cbo_operario"
        Me.cbo_operario.Size = New System.Drawing.Size(233, 21)
        Me.cbo_operario.TabIndex = 1116
        Me.cbo_operario.Text = "Seleccione"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cbo_centro)
        Me.GroupBox1.Location = New System.Drawing.Point(203, 34)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(285, 40)
        Me.GroupBox1.TabIndex = 1090
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Centro de costos"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cbo_operario)
        Me.GroupBox2.Location = New System.Drawing.Point(490, 33)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(242, 40)
        Me.GroupBox2.TabIndex = 1091
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Operario"
        '
        'group_detalle_marcaciones
        '
        Me.group_detalle_marcaciones.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.group_detalle_marcaciones.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.group_detalle_marcaciones.Controls.Add(Me.btn_cerrar_det_marcaciones)
        Me.group_detalle_marcaciones.Controls.Add(Me.dtg_detalle_marcaciones)
        Me.group_detalle_marcaciones.Location = New System.Drawing.Point(104, 153)
        Me.group_detalle_marcaciones.Name = "group_detalle_marcaciones"
        Me.group_detalle_marcaciones.Size = New System.Drawing.Size(735, 240)
        Me.group_detalle_marcaciones.TabIndex = 1101
        Me.group_detalle_marcaciones.TabStop = False
        Me.group_detalle_marcaciones.Text = "Detalle de marcaciones"
        Me.group_detalle_marcaciones.Visible = False
        '
        'btn_cerrar_det_marcaciones
        '
        Me.btn_cerrar_det_marcaciones.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_cerrar_det_marcaciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_cerrar_det_marcaciones.ForeColor = System.Drawing.Color.Red
        Me.btn_cerrar_det_marcaciones.Location = New System.Drawing.Point(711, 1)
        Me.btn_cerrar_det_marcaciones.Name = "btn_cerrar_det_marcaciones"
        Me.btn_cerrar_det_marcaciones.Size = New System.Drawing.Size(20, 23)
        Me.btn_cerrar_det_marcaciones.TabIndex = 1088
        Me.btn_cerrar_det_marcaciones.Text = "X"
        Me.btn_cerrar_det_marcaciones.UseVisualStyleBackColor = True
        '
        'dtg_detalle_marcaciones
        '
        Me.dtg_detalle_marcaciones.AllowUserToAddRows = False
        DataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dtg_detalle_marcaciones.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle12
        Me.dtg_detalle_marcaciones.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtg_detalle_marcaciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dtg_detalle_marcaciones.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dtg_detalle_marcaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle13.Format = "N0"
        DataGridViewCellStyle13.NullValue = "0"
        DataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtg_detalle_marcaciones.DefaultCellStyle = DataGridViewCellStyle13
        Me.dtg_detalle_marcaciones.Location = New System.Drawing.Point(6, 24)
        Me.dtg_detalle_marcaciones.Name = "dtg_detalle_marcaciones"
        Me.dtg_detalle_marcaciones.ReadOnly = True
        Me.dtg_detalle_marcaciones.RowHeadersVisible = False
        Me.dtg_detalle_marcaciones.Size = New System.Drawing.Size(723, 206)
        Me.dtg_detalle_marcaciones.TabIndex = 1087
        '
        'chk_temporales
        '
        Me.chk_temporales.AutoSize = True
        Me.chk_temporales.Location = New System.Drawing.Point(738, 47)
        Me.chk_temporales.Name = "chk_temporales"
        Me.chk_temporales.Size = New System.Drawing.Size(128, 17)
        Me.chk_temporales.TabIndex = 1116
        Me.chk_temporales.Text = "Programar temporales"
        Me.chk_temporales.UseVisualStyleBackColor = True
        '
        'Frm_programacion_turnos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(894, 429)
        Me.Controls.Add(Me.chk_temporales)
        Me.Controls.Add(Me.group_compromiso)
        Me.Controls.Add(Me.group_novedad)
        Me.Controls.Add(Me.group_motivo_extras)
        Me.Controls.Add(Me.imgProcesar)
        Me.Controls.Add(Me.group_detalle_marcaciones)
        Me.Controls.Add(Me.groupTurno)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lblFest)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.group_permiso)
        Me.Controls.Add(Me.group_detalle)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.TextBox4)
        Me.Controls.Add(Me.lbl_horas_laborales)
        Me.Controls.Add(Me.lbl_tot_horas)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.Toolbar1)
        Me.Controls.Add(Me.dtg_consulta)
        Me.Name = "Frm_programacion_turnos"
        Me.Text = "Presupuesto de tiempos"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Toolbar1.ResumeLayout(False)
        Me.Toolbar1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.menStrip.ResumeLayout(False)
        Me.groupTurno.ResumeLayout(False)
        CType(Me.dtgTurno, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtg_consulta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.group_novedad.ResumeLayout(False)
        Me.group_novedad.PerformLayout()
        CType(Me.dtg_novedad, System.ComponentModel.ISupportInitialize).EndInit()
        Me.group_permiso.ResumeLayout(False)
        Me.group_permiso.PerformLayout()
        Me.group_compromiso.ResumeLayout(False)
        Me.group_compromiso.PerformLayout()
        CType(Me.dtgCompromisos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.group_detalle.ResumeLayout(False)
        CType(Me.dtg_detalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgProcesar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.group_motivo_extras.ResumeLayout(False)
        CType(Me.dtg_mot_extras, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.group_detalle_marcaciones.ResumeLayout(False)
        CType(Me.dtg_detalle_marcaciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Toolbar1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btn_salir As System.Windows.Forms.ToolStripButton
    Friend WithEvents btn_ppal As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnConsol As System.Windows.Forms.ToolStripButton
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cbo_centro As System.Windows.Forms.ComboBox
    Friend WithEvents menStrip As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents itemMod As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents ToolStripSplitButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents groupTurno As System.Windows.Forms.GroupBox
    Friend WithEvents btn_cerrar_graf As System.Windows.Forms.Button
    Friend WithEvents dtgTurno As System.Windows.Forms.DataGridView
    Friend WithEvents col_ok As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents dtg_consulta As System.Windows.Forms.DataGridView
    Friend WithEvents cbo_periodo As System.Windows.Forms.ComboBox
    Friend WithEvents group_novedad As System.Windows.Forms.GroupBox
    Friend WithEvents btn_cerrar_novedades As System.Windows.Forms.Button
    Friend WithEvents dtg_novedad As System.Windows.Forms.DataGridView
    Friend WithEvents OtorgarPermisoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txt_observaciones_novedad As System.Windows.Forms.RichTextBox
    Friend WithEvents col_add_novedad As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_desc_novedad As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_concepto As System.Windows.Forms.TextBox
    Friend WithEvents btn_ok_novedad As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txt_horas_novedad As System.Windows.Forms.TextBox
    Friend WithEvents group_permiso As System.Windows.Forms.GroupBox
    Friend WithEvents btn_ok_permiso As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txt_observacion_permiso As System.Windows.Forms.RichTextBox
    Friend WithEvents btn_cerrar_permiso As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboFechaPer As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cbo_min As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cbo_hora As System.Windows.Forms.ComboBox
    Friend WithEvents CompromisoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents group_compromiso As System.Windows.Forms.GroupBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cbo_min_compromiso As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cbo_hora_compromiso As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cbo_fec_compromiso As System.Windows.Forms.DateTimePicker
    Friend WithEvents btn_ok_compromiso As System.Windows.Forms.Button
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txt_observaciones_compromiso As System.Windows.Forms.RichTextBox
    Friend WithEvents btn_cerrar_compromiso As System.Windows.Forms.Button
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txt_horas_compromiso As System.Windows.Forms.TextBox
    Friend WithEvents dtgCompromisos As System.Windows.Forms.DataGridView
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents lbl_horas_laborales As System.Windows.Forms.Label
    Friend WithEvents lbl_tot_horas As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents cbo_fec_novedad As System.Windows.Forms.DateTimePicker
    Friend WithEvents DetalleDeNovedadescompromisosYPermisosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents group_detalle As System.Windows.Forms.GroupBox
    Friend WithEvents btn_cerrar_detalle As System.Windows.Forms.Button
    Friend WithEvents dtg_detalle As System.Windows.Forms.DataGridView
    Friend WithEvents EliminarTurnoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblFest As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txtValNov As System.Windows.Forms.TextBox
    Friend WithEvents imgProcesar As System.Windows.Forms.PictureBox
    Friend WithEvents group_motivo_extras As System.Windows.Forms.GroupBox
    Friend WithEvents btn_cerrar_mot_extras As System.Windows.Forms.Button
    Friend WithEvents dtg_mot_extras As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewImageColumn1 As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents cbo_operario As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents IngresarNovedadToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VerMarcacionesDelPeriodoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents group_detalle_marcaciones As System.Windows.Forms.GroupBox
    Friend WithEvents btn_cerrar_det_marcaciones As System.Windows.Forms.Button
    Friend WithEvents dtg_detalle_marcaciones As System.Windows.Forms.DataGridView
    Friend WithEvents chk_comp_nocturno As System.Windows.Forms.CheckBox
    Friend WithEvents colBorrar As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents chk_temporales As System.Windows.Forms.CheckBox
End Class
