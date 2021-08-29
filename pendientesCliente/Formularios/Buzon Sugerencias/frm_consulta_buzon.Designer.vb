<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_consulta_buzon
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
        Me.cbo_area = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtg_buzon = New System.Windows.Forms.DataGridView()
        Me.ms_opciones = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.TransferirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AprobarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DenegarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PonerEnEjecucionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CerrarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btn_consultar = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chk_cerrado = New System.Windows.Forms.CheckBox()
        Me.chk_ejecucion = New System.Windows.Forms.CheckBox()
        Me.chk_denegado = New System.Windows.Forms.CheckBox()
        Me.chk_aprobado = New System.Windows.Forms.CheckBox()
        Me.chk_enviado = New System.Windows.Forms.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.chk_sugerencia = New System.Windows.Forms.CheckBox()
        Me.chk_mejora = New System.Windows.Forms.CheckBox()
        Me.chk_correctiva = New System.Windows.Forms.CheckBox()
        Me.chk_preventiva = New System.Windows.Forms.CheckBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.chk_no = New System.Windows.Forms.CheckBox()
        Me.chk_si = New System.Windows.Forms.CheckBox()
        Me.btn_exportar = New System.Windows.Forms.Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.rdb_denegado = New System.Windows.Forms.RadioButton()
        Me.rdb_cierre = New System.Windows.Forms.RadioButton()
        Me.rdb_ejecucion = New System.Windows.Forms.RadioButton()
        Me.rdb_aprobacion = New System.Windows.Forms.RadioButton()
        Me.rdb_envio = New System.Windows.Forms.RadioButton()
        Me.rdb_ninguno = New System.Windows.Forms.RadioButton()
        Me.cbo_fec_ini = New System.Windows.Forms.DateTimePicker()
        Me.cbo_fec_fin = New System.Windows.Forms.DateTimePicker()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txt_consecutivo = New System.Windows.Forms.TextBox()
        Me.SugerenciaEjecutadaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.dtg_buzon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ms_opciones.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cbo_area
        '
        Me.cbo_area.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.cbo_area.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_area.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cbo_area.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_area.FormattingEnabled = True
        Me.cbo_area.Location = New System.Drawing.Point(47, 29)
        Me.cbo_area.Name = "cbo_area"
        Me.cbo_area.Size = New System.Drawing.Size(359, 24)
        Me.cbo_area.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(2, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Area:"
        '
        'dtg_buzon
        '
        Me.dtg_buzon.AllowUserToAddRows = False
        Me.dtg_buzon.AllowUserToDeleteRows = False
        Me.dtg_buzon.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtg_buzon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dtg_buzon.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dtg_buzon.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.dtg_buzon.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dtg_buzon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtg_buzon.ContextMenuStrip = Me.ms_opciones
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.Desktop
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtg_buzon.DefaultCellStyle = DataGridViewCellStyle1
        Me.dtg_buzon.Location = New System.Drawing.Point(0, 173)
        Me.dtg_buzon.Name = "dtg_buzon"
        Me.dtg_buzon.ReadOnly = True
        Me.dtg_buzon.RowHeadersVisible = False
        Me.dtg_buzon.Size = New System.Drawing.Size(931, 291)
        Me.dtg_buzon.TabIndex = 2
        '
        'ms_opciones
        '
        Me.ms_opciones.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ms_opciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TransferirToolStripMenuItem, Me.AprobarToolStripMenuItem, Me.DenegarToolStripMenuItem, Me.PonerEnEjecucionToolStripMenuItem, Me.SugerenciaEjecutadaToolStripMenuItem, Me.CerrarToolStripMenuItem})
        Me.ms_opciones.Name = "ms_opciones"
        Me.ms_opciones.Size = New System.Drawing.Size(197, 158)
        Me.ms_opciones.Text = "Opciones de Sugerencias"
        '
        'TransferirToolStripMenuItem
        '
        Me.TransferirToolStripMenuItem.Image = Global.Spic.My.Resources.Resources.transferir_buz
        Me.TransferirToolStripMenuItem.Name = "TransferirToolStripMenuItem"
        Me.TransferirToolStripMenuItem.Size = New System.Drawing.Size(196, 22)
        Me.TransferirToolStripMenuItem.Text = "Transferir Sugerencia"
        '
        'AprobarToolStripMenuItem
        '
        Me.AprobarToolStripMenuItem.Image = Global.Spic.My.Resources.Resources.aprobar_buz
        Me.AprobarToolStripMenuItem.Name = "AprobarToolStripMenuItem"
        Me.AprobarToolStripMenuItem.Size = New System.Drawing.Size(196, 22)
        Me.AprobarToolStripMenuItem.Text = "Aprobar Sugerencia"
        '
        'DenegarToolStripMenuItem
        '
        Me.DenegarToolStripMenuItem.Image = Global.Spic.My.Resources.Resources.cancelar_buz
        Me.DenegarToolStripMenuItem.Name = "DenegarToolStripMenuItem"
        Me.DenegarToolStripMenuItem.Size = New System.Drawing.Size(196, 22)
        Me.DenegarToolStripMenuItem.Text = "Denegar Sugerencia"
        '
        'PonerEnEjecucionToolStripMenuItem
        '
        Me.PonerEnEjecucionToolStripMenuItem.Image = Global.Spic.My.Resources.Resources.enlaces_de_ejecutivo
        Me.PonerEnEjecucionToolStripMenuItem.Name = "PonerEnEjecucionToolStripMenuItem"
        Me.PonerEnEjecucionToolStripMenuItem.Size = New System.Drawing.Size(196, 22)
        Me.PonerEnEjecucionToolStripMenuItem.Text = "Poner en ejecucion"
        '
        'CerrarToolStripMenuItem
        '
        Me.CerrarToolStripMenuItem.Image = Global.Spic.My.Resources.Resources.candado_cerrado
        Me.CerrarToolStripMenuItem.Name = "CerrarToolStripMenuItem"
        Me.CerrarToolStripMenuItem.Size = New System.Drawing.Size(196, 22)
        Me.CerrarToolStripMenuItem.Text = "Cerrar sugerencia"
        '
        'btn_consultar
        '
        Me.btn_consultar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_consultar.Image = Global.Spic.My.Resources.Resources.Consultar
        Me.btn_consultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_consultar.Location = New System.Drawing.Point(680, 4)
        Me.btn_consultar.Name = "btn_consultar"
        Me.btn_consultar.Size = New System.Drawing.Size(112, 50)
        Me.btn_consultar.TabIndex = 3
        Me.btn_consultar.Text = "Consultar"
        Me.btn_consultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_consultar.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chk_cerrado)
        Me.GroupBox1.Controls.Add(Me.chk_ejecucion)
        Me.GroupBox1.Controls.Add(Me.chk_denegado)
        Me.GroupBox1.Controls.Add(Me.chk_aprobado)
        Me.GroupBox1.Controls.Add(Me.chk_enviado)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(5, 60)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(496, 48)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "ESTADOS"
        '
        'chk_cerrado
        '
        Me.chk_cerrado.AutoSize = True
        Me.chk_cerrado.BackColor = System.Drawing.Color.LightGray
        Me.chk_cerrado.Location = New System.Drawing.Point(396, 22)
        Me.chk_cerrado.Name = "chk_cerrado"
        Me.chk_cerrado.Size = New System.Drawing.Size(83, 20)
        Me.chk_cerrado.TabIndex = 5
        Me.chk_cerrado.Text = "Cerrado"
        Me.chk_cerrado.UseVisualStyleBackColor = False
        '
        'chk_ejecucion
        '
        Me.chk_ejecucion.AutoSize = True
        Me.chk_ejecucion.BackColor = System.Drawing.Color.Khaki
        Me.chk_ejecucion.Location = New System.Drawing.Point(295, 22)
        Me.chk_ejecucion.Name = "chk_ejecucion"
        Me.chk_ejecucion.Size = New System.Drawing.Size(95, 20)
        Me.chk_ejecucion.TabIndex = 3
        Me.chk_ejecucion.Text = "Ejecucion"
        Me.chk_ejecucion.UseVisualStyleBackColor = False
        '
        'chk_denegado
        '
        Me.chk_denegado.AutoSize = True
        Me.chk_denegado.BackColor = System.Drawing.Color.PeachPuff
        Me.chk_denegado.Location = New System.Drawing.Point(189, 21)
        Me.chk_denegado.Name = "chk_denegado"
        Me.chk_denegado.Size = New System.Drawing.Size(100, 20)
        Me.chk_denegado.TabIndex = 2
        Me.chk_denegado.Text = "Denegado"
        Me.chk_denegado.UseVisualStyleBackColor = False
        '
        'chk_aprobado
        '
        Me.chk_aprobado.AutoSize = True
        Me.chk_aprobado.BackColor = System.Drawing.Color.PaleGreen
        Me.chk_aprobado.Location = New System.Drawing.Point(87, 21)
        Me.chk_aprobado.Name = "chk_aprobado"
        Me.chk_aprobado.Size = New System.Drawing.Size(96, 20)
        Me.chk_aprobado.TabIndex = 1
        Me.chk_aprobado.Text = "Aprobado"
        Me.chk_aprobado.UseVisualStyleBackColor = False
        '
        'chk_enviado
        '
        Me.chk_enviado.AutoSize = True
        Me.chk_enviado.Location = New System.Drawing.Point(6, 22)
        Me.chk_enviado.Name = "chk_enviado"
        Me.chk_enviado.Size = New System.Drawing.Size(84, 20)
        Me.chk_enviado.TabIndex = 0
        Me.chk_enviado.Text = "Enviado"
        Me.chk_enviado.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.chk_sugerencia)
        Me.GroupBox2.Controls.Add(Me.chk_mejora)
        Me.GroupBox2.Controls.Add(Me.chk_correctiva)
        Me.GroupBox2.Controls.Add(Me.chk_preventiva)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(507, 60)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(403, 48)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "TIPO DE ACCION"
        '
        'chk_sugerencia
        '
        Me.chk_sugerencia.AutoSize = True
        Me.chk_sugerencia.BackColor = System.Drawing.SystemColors.Window
        Me.chk_sugerencia.Location = New System.Drawing.Point(291, 21)
        Me.chk_sugerencia.Name = "chk_sugerencia"
        Me.chk_sugerencia.Size = New System.Drawing.Size(106, 20)
        Me.chk_sugerencia.TabIndex = 3
        Me.chk_sugerencia.Text = "Sugerencia"
        Me.chk_sugerencia.UseVisualStyleBackColor = False
        '
        'chk_mejora
        '
        Me.chk_mejora.AutoSize = True
        Me.chk_mejora.BackColor = System.Drawing.SystemColors.Window
        Me.chk_mejora.Location = New System.Drawing.Point(217, 22)
        Me.chk_mejora.Name = "chk_mejora"
        Me.chk_mejora.Size = New System.Drawing.Size(75, 20)
        Me.chk_mejora.TabIndex = 2
        Me.chk_mejora.Text = "Mejora"
        Me.chk_mejora.UseVisualStyleBackColor = False
        '
        'chk_correctiva
        '
        Me.chk_correctiva.AutoSize = True
        Me.chk_correctiva.BackColor = System.Drawing.SystemColors.Window
        Me.chk_correctiva.Location = New System.Drawing.Point(113, 21)
        Me.chk_correctiva.Name = "chk_correctiva"
        Me.chk_correctiva.Size = New System.Drawing.Size(98, 20)
        Me.chk_correctiva.TabIndex = 1
        Me.chk_correctiva.Text = "Correctiva"
        Me.chk_correctiva.UseVisualStyleBackColor = False
        '
        'chk_preventiva
        '
        Me.chk_preventiva.AutoSize = True
        Me.chk_preventiva.BackColor = System.Drawing.SystemColors.Window
        Me.chk_preventiva.Location = New System.Drawing.Point(6, 22)
        Me.chk_preventiva.Name = "chk_preventiva"
        Me.chk_preventiva.Size = New System.Drawing.Size(101, 20)
        Me.chk_preventiva.TabIndex = 0
        Me.chk_preventiva.Text = "Preventiva"
        Me.chk_preventiva.UseVisualStyleBackColor = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.chk_no)
        Me.GroupBox3.Controls.Add(Me.chk_si)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(412, 12)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(106, 39)
        Me.GroupBox3.TabIndex = 6
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "INVERSION"
        '
        'chk_no
        '
        Me.chk_no.AutoSize = True
        Me.chk_no.BackColor = System.Drawing.SystemColors.Window
        Me.chk_no.Location = New System.Drawing.Point(53, 17)
        Me.chk_no.Name = "chk_no"
        Me.chk_no.Size = New System.Drawing.Size(49, 20)
        Me.chk_no.TabIndex = 1
        Me.chk_no.Text = "NO"
        Me.chk_no.UseVisualStyleBackColor = False
        '
        'chk_si
        '
        Me.chk_si.AutoSize = True
        Me.chk_si.BackColor = System.Drawing.SystemColors.Window
        Me.chk_si.Location = New System.Drawing.Point(6, 17)
        Me.chk_si.Name = "chk_si"
        Me.chk_si.Size = New System.Drawing.Size(41, 20)
        Me.chk_si.TabIndex = 0
        Me.chk_si.Text = "SI"
        Me.chk_si.UseVisualStyleBackColor = False
        '
        'btn_exportar
        '
        Me.btn_exportar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_exportar.Image = Global.Spic.My.Resources.Resources.Export_excel
        Me.btn_exportar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_exportar.Location = New System.Drawing.Point(798, 4)
        Me.btn_exportar.Name = "btn_exportar"
        Me.btn_exportar.Size = New System.Drawing.Size(112, 50)
        Me.btn_exportar.TabIndex = 7
        Me.btn_exportar.Text = "Exportar"
        Me.btn_exportar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_exportar.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.rdb_denegado)
        Me.GroupBox4.Controls.Add(Me.rdb_cierre)
        Me.GroupBox4.Controls.Add(Me.rdb_ejecucion)
        Me.GroupBox4.Controls.Add(Me.rdb_aprobacion)
        Me.GroupBox4.Controls.Add(Me.rdb_envio)
        Me.GroupBox4.Controls.Add(Me.rdb_ninguno)
        Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(5, 114)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(669, 44)
        Me.GroupBox4.TabIndex = 8
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "FILTRO POR FECHAS"
        '
        'rdb_denegado
        '
        Me.rdb_denegado.AutoSize = True
        Me.rdb_denegado.Location = New System.Drawing.Point(540, 19)
        Me.rdb_denegado.Name = "rdb_denegado"
        Me.rdb_denegado.Size = New System.Drawing.Size(122, 17)
        Me.rdb_denegado.TabIndex = 5
        Me.rdb_denegado.Text = "Fecha Denegado"
        Me.rdb_denegado.UseVisualStyleBackColor = True
        '
        'rdb_cierre
        '
        Me.rdb_cierre.AutoSize = True
        Me.rdb_cierre.Location = New System.Drawing.Point(439, 19)
        Me.rdb_cierre.Name = "rdb_cierre"
        Me.rdb_cierre.Size = New System.Drawing.Size(97, 17)
        Me.rdb_cierre.TabIndex = 4
        Me.rdb_cierre.Text = "Fecha Cierre"
        Me.rdb_cierre.UseVisualStyleBackColor = True
        '
        'rdb_ejecucion
        '
        Me.rdb_ejecucion.AutoSize = True
        Me.rdb_ejecucion.Location = New System.Drawing.Point(313, 19)
        Me.rdb_ejecucion.Name = "rdb_ejecucion"
        Me.rdb_ejecucion.Size = New System.Drawing.Size(120, 17)
        Me.rdb_ejecucion.TabIndex = 3
        Me.rdb_ejecucion.Text = "Fecha Ejecucion"
        Me.rdb_ejecucion.UseVisualStyleBackColor = True
        '
        'rdb_aprobacion
        '
        Me.rdb_aprobacion.AutoSize = True
        Me.rdb_aprobacion.Location = New System.Drawing.Point(187, 19)
        Me.rdb_aprobacion.Name = "rdb_aprobacion"
        Me.rdb_aprobacion.Size = New System.Drawing.Size(128, 17)
        Me.rdb_aprobacion.TabIndex = 2
        Me.rdb_aprobacion.Text = "Fecha Aprobacion"
        Me.rdb_aprobacion.UseVisualStyleBackColor = True
        '
        'rdb_envio
        '
        Me.rdb_envio.AutoSize = True
        Me.rdb_envio.Location = New System.Drawing.Point(85, 19)
        Me.rdb_envio.Name = "rdb_envio"
        Me.rdb_envio.Size = New System.Drawing.Size(96, 17)
        Me.rdb_envio.TabIndex = 1
        Me.rdb_envio.Text = "Fecha Envio"
        Me.rdb_envio.UseVisualStyleBackColor = True
        '
        'rdb_ninguno
        '
        Me.rdb_ninguno.AutoSize = True
        Me.rdb_ninguno.Checked = True
        Me.rdb_ninguno.Location = New System.Drawing.Point(7, 19)
        Me.rdb_ninguno.Name = "rdb_ninguno"
        Me.rdb_ninguno.Size = New System.Drawing.Size(72, 17)
        Me.rdb_ninguno.TabIndex = 0
        Me.rdb_ninguno.TabStop = True
        Me.rdb_ninguno.Text = "Ninguna"
        Me.rdb_ninguno.UseVisualStyleBackColor = True
        '
        'cbo_fec_ini
        '
        Me.cbo_fec_ini.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.cbo_fec_ini.Location = New System.Drawing.Point(67, 3)
        Me.cbo_fec_ini.Name = "cbo_fec_ini"
        Me.cbo_fec_ini.Size = New System.Drawing.Size(98, 20)
        Me.cbo_fec_ini.TabIndex = 1
        '
        'cbo_fec_fin
        '
        Me.cbo_fec_fin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.cbo_fec_fin.Location = New System.Drawing.Point(67, 29)
        Me.cbo_fec_fin.Name = "cbo_fec_fin"
        Me.cbo_fec_fin.Size = New System.Drawing.Size(98, 20)
        Me.cbo_fec_fin.TabIndex = 9
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.cbo_fec_ini)
        Me.Panel1.Controls.Add(Me.cbo_fec_fin)
        Me.Panel1.Location = New System.Drawing.Point(738, 114)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(172, 53)
        Me.Panel1.TabIndex = 10
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(3, 33)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 16)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Hasta:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(3, 7)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 16)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Desde:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(524, 4)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(97, 16)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Consecutivo:"
        '
        'txt_consecutivo
        '
        Me.txt_consecutivo.Location = New System.Drawing.Point(527, 23)
        Me.txt_consecutivo.Name = "txt_consecutivo"
        Me.txt_consecutivo.Size = New System.Drawing.Size(147, 20)
        Me.txt_consecutivo.TabIndex = 12
        '
        'SugerenciaEjecutadaToolStripMenuItem
        '
        Me.SugerenciaEjecutadaToolStripMenuItem.Image = Global.Spic.My.Resources.Resources.ficha
        Me.SugerenciaEjecutadaToolStripMenuItem.Name = "SugerenciaEjecutadaToolStripMenuItem"
        Me.SugerenciaEjecutadaToolStripMenuItem.Size = New System.Drawing.Size(196, 22)
        Me.SugerenciaEjecutadaToolStripMenuItem.Text = "Sugerencia Ejecutada"
        '
        'frm_consulta_buzon
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(930, 465)
        Me.Controls.Add(Me.txt_consecutivo)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.btn_exportar)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btn_consultar)
        Me.Controls.Add(Me.dtg_buzon)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cbo_area)
        Me.Name = "frm_consulta_buzon"
        Me.Text = "Consulta Buzon de Sugerencias"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dtg_buzon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ms_opciones.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cbo_area As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtg_buzon As System.Windows.Forms.DataGridView
    Friend WithEvents btn_consultar As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents chk_cerrado As System.Windows.Forms.CheckBox
    Friend WithEvents chk_ejecucion As System.Windows.Forms.CheckBox
    Friend WithEvents chk_denegado As System.Windows.Forms.CheckBox
    Friend WithEvents chk_aprobado As System.Windows.Forms.CheckBox
    Friend WithEvents chk_enviado As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents chk_sugerencia As System.Windows.Forms.CheckBox
    Friend WithEvents chk_mejora As System.Windows.Forms.CheckBox
    Friend WithEvents chk_correctiva As System.Windows.Forms.CheckBox
    Friend WithEvents chk_preventiva As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents chk_no As System.Windows.Forms.CheckBox
    Friend WithEvents chk_si As System.Windows.Forms.CheckBox
    Friend WithEvents btn_exportar As System.Windows.Forms.Button
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents rdb_denegado As System.Windows.Forms.RadioButton
    Friend WithEvents rdb_cierre As System.Windows.Forms.RadioButton
    Friend WithEvents rdb_ejecucion As System.Windows.Forms.RadioButton
    Friend WithEvents rdb_aprobacion As System.Windows.Forms.RadioButton
    Friend WithEvents rdb_envio As System.Windows.Forms.RadioButton
    Friend WithEvents rdb_ninguno As System.Windows.Forms.RadioButton
    Friend WithEvents cbo_fec_ini As System.Windows.Forms.DateTimePicker
    Friend WithEvents cbo_fec_fin As System.Windows.Forms.DateTimePicker
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ms_opciones As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents TransferirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AprobarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DenegarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CerrarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PonerEnEjecucionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txt_consecutivo As System.Windows.Forms.TextBox
    Friend WithEvents SugerenciaEjecutadaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
