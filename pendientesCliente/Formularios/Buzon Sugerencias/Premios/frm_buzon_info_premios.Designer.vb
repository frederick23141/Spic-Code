<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_buzon_info_premios
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
        Me.dtg_premios = New System.Windows.Forms.DataGridView()
        Me.col_guardar = New System.Windows.Forms.DataGridViewImageColumn()
        Me.dtg_sol_premios = New System.Windows.Forms.DataGridView()
        Me.col_entregar = New System.Windows.Forms.DataGridViewImageColumn()
        Me.btn_consultar = New System.Windows.Forms.Button()
        Me.chk_entregados = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txt_empleado = New System.Windows.Forms.TextBox()
        Me.btn_exportar = New System.Windows.Forms.Button()
        Me.tbl_ = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.group_detall = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.dtg_historial = New System.Windows.Forms.DataGridView()
        Me.txt_emp_punt = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btn_cons_puntos = New System.Windows.Forms.Button()
        Me.cbo_ano = New System.Windows.Forms.ComboBox()
        Me.cbo_mes = New System.Windows.Forms.ComboBox()
        Me.chk_fil_fecha = New System.Windows.Forms.CheckBox()
        Me.dtg_puntos_operarios = New System.Windows.Forms.DataGridView()
        Me.men_emp = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.bt_ms_ver_detalle = New System.Windows.Forms.ToolStripMenuItem()
        Me.AumentarPor1ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PorImpactoDeIdeaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PorImpactoALosObjetivosEstrategicosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AhorroDe10000010000000ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AhorroDe110000010000000ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AhorroMayorA10000000ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OtrosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReduccionDePuntosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EnviarHistorialDePuntosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.dtg_premios, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtg_sol_premios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbl_.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.group_detall.SuspendLayout()
        CType(Me.dtg_historial, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtg_puntos_operarios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.men_emp.SuspendLayout()
        Me.SuspendLayout()
        '
        'dtg_premios
        '
        Me.dtg_premios.AllowUserToAddRows = False
        Me.dtg_premios.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        Me.dtg_premios.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dtg_premios.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtg_premios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dtg_premios.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dtg_premios.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.dtg_premios.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dtg_premios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtg_premios.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.col_guardar})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ScrollBar
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtg_premios.DefaultCellStyle = DataGridViewCellStyle2
        Me.dtg_premios.Location = New System.Drawing.Point(597, 59)
        Me.dtg_premios.Name = "dtg_premios"
        Me.dtg_premios.RowHeadersVisible = False
        Me.dtg_premios.Size = New System.Drawing.Size(385, 372)
        Me.dtg_premios.TabIndex = 0
        '
        'col_guardar
        '
        Me.col_guardar.HeaderText = "G"
        Me.col_guardar.Image = Global.Spic.My.Resources.Resources.save_16
        Me.col_guardar.Name = "col_guardar"
        Me.col_guardar.Width = 21
        '
        'dtg_sol_premios
        '
        Me.dtg_sol_premios.AllowUserToAddRows = False
        Me.dtg_sol_premios.AllowUserToDeleteRows = False
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        Me.dtg_sol_premios.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
        Me.dtg_sol_premios.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtg_sol_premios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dtg_sol_premios.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dtg_sol_premios.BackgroundColor = System.Drawing.Color.White
        Me.dtg_sol_premios.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dtg_sol_premios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtg_sol_premios.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.col_entregar})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.ScrollBar
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtg_sol_premios.DefaultCellStyle = DataGridViewCellStyle4
        Me.dtg_sol_premios.Location = New System.Drawing.Point(5, 59)
        Me.dtg_sol_premios.Name = "dtg_sol_premios"
        Me.dtg_sol_premios.ReadOnly = True
        Me.dtg_sol_premios.RowHeadersVisible = False
        Me.dtg_sol_premios.Size = New System.Drawing.Size(586, 372)
        Me.dtg_sol_premios.TabIndex = 1
        '
        'col_entregar
        '
        Me.col_entregar.HeaderText = "Entregar"
        Me.col_entregar.Image = Global.Spic.My.Resources.Resources.box2
        Me.col_entregar.Name = "col_entregar"
        Me.col_entregar.ReadOnly = True
        Me.col_entregar.Width = 53
        '
        'btn_consultar
        '
        Me.btn_consultar.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_consultar.Image = Global.Spic.My.Resources.Resources._1385696481_kghostview
        Me.btn_consultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_consultar.Location = New System.Drawing.Point(6, 3)
        Me.btn_consultar.Name = "btn_consultar"
        Me.btn_consultar.Size = New System.Drawing.Size(154, 50)
        Me.btn_consultar.TabIndex = 2
        Me.btn_consultar.Text = "CONSULTAR"
        Me.btn_consultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_consultar.UseVisualStyleBackColor = True
        '
        'chk_entregados
        '
        Me.chk_entregados.AutoSize = True
        Me.chk_entregados.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_entregados.Location = New System.Drawing.Point(166, 6)
        Me.chk_entregados.Name = "chk_entregados"
        Me.chk_entregados.Size = New System.Drawing.Size(90, 17)
        Me.chk_entregados.TabIndex = 3
        Me.chk_entregados.Text = "Entregados"
        Me.chk_entregados.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(168, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Empleado:"
        '
        'txt_empleado
        '
        Me.txt_empleado.Location = New System.Drawing.Point(240, 33)
        Me.txt_empleado.Name = "txt_empleado"
        Me.txt_empleado.Size = New System.Drawing.Size(121, 20)
        Me.txt_empleado.TabIndex = 5
        '
        'btn_exportar
        '
        Me.btn_exportar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_exportar.Image = Global.Spic.My.Resources.Resources.Export_excel
        Me.btn_exportar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_exportar.Location = New System.Drawing.Point(367, 6)
        Me.btn_exportar.Name = "btn_exportar"
        Me.btn_exportar.Size = New System.Drawing.Size(111, 50)
        Me.btn_exportar.TabIndex = 8
        Me.btn_exportar.Text = "Exportar"
        Me.btn_exportar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_exportar.UseVisualStyleBackColor = True
        '
        'tbl_
        '
        Me.tbl_.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbl_.Controls.Add(Me.TabPage1)
        Me.tbl_.Controls.Add(Me.TabPage2)
        Me.tbl_.Location = New System.Drawing.Point(3, 7)
        Me.tbl_.Name = "tbl_"
        Me.tbl_.SelectedIndex = 0
        Me.tbl_.Size = New System.Drawing.Size(996, 463)
        Me.tbl_.TabIndex = 9
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.dtg_sol_premios)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.btn_exportar)
        Me.TabPage1.Controls.Add(Me.dtg_premios)
        Me.TabPage1.Controls.Add(Me.txt_empleado)
        Me.TabPage1.Controls.Add(Me.btn_consultar)
        Me.TabPage1.Controls.Add(Me.chk_entregados)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(988, 437)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Listado de premios."
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(594, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 18)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Premios:"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.group_detall)
        Me.TabPage2.Controls.Add(Me.txt_emp_punt)
        Me.TabPage2.Controls.Add(Me.Label3)
        Me.TabPage2.Controls.Add(Me.btn_cons_puntos)
        Me.TabPage2.Controls.Add(Me.cbo_ano)
        Me.TabPage2.Controls.Add(Me.cbo_mes)
        Me.TabPage2.Controls.Add(Me.chk_fil_fecha)
        Me.TabPage2.Controls.Add(Me.dtg_puntos_operarios)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(988, 437)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Listado de Puntos"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'group_detall
        '
        Me.group_detall.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.group_detall.Controls.Add(Me.Button1)
        Me.group_detall.Controls.Add(Me.dtg_historial)
        Me.group_detall.Location = New System.Drawing.Point(36, 45)
        Me.group_detall.Name = "group_detall"
        Me.group_detall.Size = New System.Drawing.Size(843, 357)
        Me.group_detall.TabIndex = 8
        Me.group_detall.TabStop = False
        Me.group_detall.Text = "Historial de cambios de:"
        Me.group_detall.Visible = False
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Image = Global.Spic.My.Resources.Resources._1371749741_32447
        Me.Button1.Location = New System.Drawing.Point(808, 0)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(35, 39)
        Me.Button1.TabIndex = 1
        Me.Button1.UseVisualStyleBackColor = True
        '
        'dtg_historial
        '
        Me.dtg_historial.AllowUserToAddRows = False
        Me.dtg_historial.AllowUserToDeleteRows = False
        Me.dtg_historial.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtg_historial.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dtg_historial.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dtg_historial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtg_historial.Location = New System.Drawing.Point(6, 45)
        Me.dtg_historial.Name = "dtg_historial"
        Me.dtg_historial.ReadOnly = True
        Me.dtg_historial.Size = New System.Drawing.Size(831, 306)
        Me.dtg_historial.TabIndex = 0
        '
        'txt_emp_punt
        '
        Me.txt_emp_punt.Location = New System.Drawing.Point(248, 30)
        Me.txt_emp_punt.Name = "txt_emp_punt"
        Me.txt_emp_punt.Size = New System.Drawing.Size(136, 20)
        Me.txt_emp_punt.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(245, 10)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 15)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Empleado:"
        '
        'btn_cons_puntos
        '
        Me.btn_cons_puntos.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_cons_puntos.Image = Global.Spic.My.Resources.Resources._1385696481_kghostview
        Me.btn_cons_puntos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_cons_puntos.Location = New System.Drawing.Point(507, 9)
        Me.btn_cons_puntos.Name = "btn_cons_puntos"
        Me.btn_cons_puntos.Size = New System.Drawing.Size(154, 50)
        Me.btn_cons_puntos.TabIndex = 5
        Me.btn_cons_puntos.Text = "CONSULTAR"
        Me.btn_cons_puntos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_cons_puntos.UseVisualStyleBackColor = True
        '
        'cbo_ano
        '
        Me.cbo_ano.FormattingEnabled = True
        Me.cbo_ano.Location = New System.Drawing.Point(114, 29)
        Me.cbo_ano.Name = "cbo_ano"
        Me.cbo_ano.Size = New System.Drawing.Size(96, 21)
        Me.cbo_ano.TabIndex = 4
        '
        'cbo_mes
        '
        Me.cbo_mes.FormattingEnabled = True
        Me.cbo_mes.Location = New System.Drawing.Point(6, 29)
        Me.cbo_mes.Name = "cbo_mes"
        Me.cbo_mes.Size = New System.Drawing.Size(102, 21)
        Me.cbo_mes.TabIndex = 3
        '
        'chk_fil_fecha
        '
        Me.chk_fil_fecha.AutoSize = True
        Me.chk_fil_fecha.Checked = True
        Me.chk_fil_fecha.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk_fil_fecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_fil_fecha.Location = New System.Drawing.Point(6, 6)
        Me.chk_fil_fecha.Name = "chk_fil_fecha"
        Me.chk_fil_fecha.Size = New System.Drawing.Size(132, 19)
        Me.chk_fil_fecha.TabIndex = 1
        Me.chk_fil_fecha.Text = "Filtrar por Fecha"
        Me.chk_fil_fecha.UseVisualStyleBackColor = True
        '
        'dtg_puntos_operarios
        '
        Me.dtg_puntos_operarios.AllowUserToAddRows = False
        Me.dtg_puntos_operarios.AllowUserToDeleteRows = False
        Me.dtg_puntos_operarios.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtg_puntos_operarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dtg_puntos_operarios.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dtg_puntos_operarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtg_puntos_operarios.ContextMenuStrip = Me.men_emp
        Me.dtg_puntos_operarios.Location = New System.Drawing.Point(3, 65)
        Me.dtg_puntos_operarios.Name = "dtg_puntos_operarios"
        Me.dtg_puntos_operarios.ReadOnly = True
        Me.dtg_puntos_operarios.Size = New System.Drawing.Size(976, 366)
        Me.dtg_puntos_operarios.TabIndex = 0
        '
        'men_emp
        '
        Me.men_emp.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.bt_ms_ver_detalle, Me.AumentarPor1ToolStripMenuItem, Me.ReduccionDePuntosToolStripMenuItem, Me.EnviarHistorialDePuntosToolStripMenuItem})
        Me.men_emp.Name = "men_emp"
        Me.men_emp.Size = New System.Drawing.Size(210, 92)
        '
        'bt_ms_ver_detalle
        '
        Me.bt_ms_ver_detalle.Image = Global.Spic.My.Resources.Resources.Consultar
        Me.bt_ms_ver_detalle.Name = "bt_ms_ver_detalle"
        Me.bt_ms_ver_detalle.Size = New System.Drawing.Size(209, 22)
        Me.bt_ms_ver_detalle.Text = "Ver Detalles del Empleado"
        '
        'AumentarPor1ToolStripMenuItem
        '
        Me.AumentarPor1ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PorImpactoDeIdeaToolStripMenuItem, Me.PorImpactoALosObjetivosEstrategicosToolStripMenuItem, Me.OtrosToolStripMenuItem})
        Me.AumentarPor1ToolStripMenuItem.Image = Global.Spic.My.Resources.Resources.caja_fuerte
        Me.AumentarPor1ToolStripMenuItem.Name = "AumentarPor1ToolStripMenuItem"
        Me.AumentarPor1ToolStripMenuItem.Size = New System.Drawing.Size(209, 22)
        Me.AumentarPor1ToolStripMenuItem.Text = "Aumento de Puntos"
        '
        'PorImpactoDeIdeaToolStripMenuItem
        '
        Me.PorImpactoDeIdeaToolStripMenuItem.Image = Global.Spic.My.Resources.Resources.calendario
        Me.PorImpactoDeIdeaToolStripMenuItem.Name = "PorImpactoDeIdeaToolStripMenuItem"
        Me.PorImpactoDeIdeaToolStripMenuItem.Size = New System.Drawing.Size(184, 22)
        Me.PorImpactoDeIdeaToolStripMenuItem.Text = "Por Idea Cotidiana"
        '
        'PorImpactoALosObjetivosEstrategicosToolStripMenuItem
        '
        Me.PorImpactoALosObjetivosEstrategicosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AhorroDe10000010000000ToolStripMenuItem, Me.AhorroDe110000010000000ToolStripMenuItem, Me.AhorroMayorA10000000ToolStripMenuItem})
        Me.PorImpactoALosObjetivosEstrategicosToolStripMenuItem.Image = Global.Spic.My.Resources.Resources.cambiar
        Me.PorImpactoALosObjetivosEstrategicosToolStripMenuItem.Name = "PorImpactoALosObjetivosEstrategicosToolStripMenuItem"
        Me.PorImpactoALosObjetivosEstrategicosToolStripMenuItem.Size = New System.Drawing.Size(184, 22)
        Me.PorImpactoALosObjetivosEstrategicosToolStripMenuItem.Text = "Por Mejora Continua"
        '
        'AhorroDe10000010000000ToolStripMenuItem
        '
        Me.AhorroDe10000010000000ToolStripMenuItem.Image = Global.Spic.My.Resources.Resources.notas
        Me.AhorroDe10000010000000ToolStripMenuItem.Name = "AhorroDe10000010000000ToolStripMenuItem"
        Me.AhorroDe10000010000000ToolStripMenuItem.Size = New System.Drawing.Size(255, 22)
        Me.AhorroDe10000010000000ToolStripMenuItem.Text = "Ahorro de $100.000 - $ 1.000.000"
        '
        'AhorroDe110000010000000ToolStripMenuItem
        '
        Me.AhorroDe110000010000000ToolStripMenuItem.Image = Global.Spic.My.Resources.Resources.notas__1_
        Me.AhorroDe110000010000000ToolStripMenuItem.Name = "AhorroDe110000010000000ToolStripMenuItem"
        Me.AhorroDe110000010000000ToolStripMenuItem.Size = New System.Drawing.Size(255, 22)
        Me.AhorroDe110000010000000ToolStripMenuItem.Text = "Ahorro de $1.100.000 - $10.000.000"
        '
        'AhorroMayorA10000000ToolStripMenuItem
        '
        Me.AhorroMayorA10000000ToolStripMenuItem.Image = Global.Spic.My.Resources.Resources.tarjeta_de_credito
        Me.AhorroMayorA10000000ToolStripMenuItem.Name = "AhorroMayorA10000000ToolStripMenuItem"
        Me.AhorroMayorA10000000ToolStripMenuItem.Size = New System.Drawing.Size(255, 22)
        Me.AhorroMayorA10000000ToolStripMenuItem.Text = "Ahorro mayor a $10.000.000"
        '
        'OtrosToolStripMenuItem
        '
        Me.OtrosToolStripMenuItem.Image = Global.Spic.My.Resources.Resources.herramientas_de_reparacion
        Me.OtrosToolStripMenuItem.Name = "OtrosToolStripMenuItem"
        Me.OtrosToolStripMenuItem.Size = New System.Drawing.Size(184, 22)
        Me.OtrosToolStripMenuItem.Text = "Otros"
        '
        'ReduccionDePuntosToolStripMenuItem
        '
        Me.ReduccionDePuntosToolStripMenuItem.Image = Global.Spic.My.Resources.Resources.settings_gears__1_
        Me.ReduccionDePuntosToolStripMenuItem.Name = "ReduccionDePuntosToolStripMenuItem"
        Me.ReduccionDePuntosToolStripMenuItem.Size = New System.Drawing.Size(209, 22)
        Me.ReduccionDePuntosToolStripMenuItem.Text = "Reduccion de Puntos"
        '
        'EnviarHistorialDePuntosToolStripMenuItem
        '
        Me.EnviarHistorialDePuntosToolStripMenuItem.Image = Global.Spic.My.Resources.Resources.add1
        Me.EnviarHistorialDePuntosToolStripMenuItem.Name = "EnviarHistorialDePuntosToolStripMenuItem"
        Me.EnviarHistorialDePuntosToolStripMenuItem.Size = New System.Drawing.Size(209, 22)
        Me.EnviarHistorialDePuntosToolStripMenuItem.Text = "Enviar Historial de Puntos"
        '
        'frm_buzon_info_premios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1001, 472)
        Me.Controls.Add(Me.tbl_)
        Me.Name = "frm_buzon_info_premios"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Informe de Premios"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dtg_premios, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtg_sol_premios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbl_.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.group_detall.ResumeLayout(False)
        CType(Me.dtg_historial, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtg_puntos_operarios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.men_emp.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dtg_premios As System.Windows.Forms.DataGridView
    Friend WithEvents dtg_sol_premios As System.Windows.Forms.DataGridView
    Friend WithEvents col_guardar As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents btn_consultar As System.Windows.Forms.Button
    Friend WithEvents chk_entregados As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_empleado As System.Windows.Forms.TextBox
    Friend WithEvents col_entregar As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents btn_exportar As System.Windows.Forms.Button
    Friend WithEvents tbl_ As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtg_puntos_operarios As System.Windows.Forms.DataGridView
    Friend WithEvents btn_cons_puntos As System.Windows.Forms.Button
    Friend WithEvents cbo_ano As System.Windows.Forms.ComboBox
    Friend WithEvents cbo_mes As System.Windows.Forms.ComboBox
    Friend WithEvents chk_fil_fecha As System.Windows.Forms.CheckBox
    Friend WithEvents txt_emp_punt As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents group_detall As System.Windows.Forms.GroupBox
    Friend WithEvents dtg_historial As System.Windows.Forms.DataGridView
    Friend WithEvents men_emp As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents bt_ms_ver_detalle As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents AumentarPor1ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReduccionDePuntosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EnviarHistorialDePuntosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PorImpactoDeIdeaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PorImpactoALosObjetivosEstrategicosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OtrosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AhorroDe10000010000000ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AhorroDe110000010000000ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AhorroMayorA10000000ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
