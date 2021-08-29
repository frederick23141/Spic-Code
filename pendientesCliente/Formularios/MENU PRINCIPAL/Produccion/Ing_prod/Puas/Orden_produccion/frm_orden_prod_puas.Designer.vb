<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_orden_prod_puas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_orden_prod_puas))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.tbl_ppal = New System.Windows.Forms.TabControl()
        Me.pag_crear_orden = New System.Windows.Forms.TabPage()
        Me.GB_orden_produccion = New System.Windows.Forms.GroupBox()
        Me.cbo_fec_orden = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnGuardar = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.txtCantProg = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.cbo_prod_final = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        Me.cbo_map_prima_2 = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        Me.cbo_mat_prima = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        Me.cbo_maquina = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtnota = New System.Windows.Forms.RichTextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.gb_ordenes_c = New System.Windows.Forms.TabPage()
        Me.btnNuevo = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.porcen_header = New ComponentFactory.Krypton.Toolkit.KryptonHeader()
        Me.lbl_cumplidas = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonGroupBox1 = New ComponentFactory.Krypton.Toolkit.KryptonGroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboFechaFin = New ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker()
        Me.cboFechaIni = New ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.txtConsulNumOrd = New System.Windows.Forms.TextBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.dtg_consulta = New System.Windows.Forms.DataGridView()
        Me.btnVerDetalle = New System.Windows.Forms.DataGridViewImageColumn()
        Me.col_oculto = New System.Windows.Forms.DataGridViewImageColumn()
        Me.col_duplicar = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.col_porcen = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tbl_ppal.SuspendLayout()
        Me.pag_crear_orden.SuspendLayout()
        Me.GB_orden_produccion.SuspendLayout()
        CType(Me.cbo_prod_final, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbo_map_prima_2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbo_mat_prima, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbo_maquina, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gb_ordenes_c.SuspendLayout()
        CType(Me.KryptonGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonGroupBox1.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonGroupBox1.Panel.SuspendLayout()
        Me.KryptonGroupBox1.SuspendLayout()
        CType(Me.dtg_consulta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tbl_ppal
        '
        Me.tbl_ppal.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbl_ppal.Controls.Add(Me.pag_crear_orden)
        Me.tbl_ppal.Controls.Add(Me.gb_ordenes_c)
        Me.tbl_ppal.Location = New System.Drawing.Point(2, 3)
        Me.tbl_ppal.Name = "tbl_ppal"
        Me.tbl_ppal.SelectedIndex = 0
        Me.tbl_ppal.Size = New System.Drawing.Size(1028, 489)
        Me.tbl_ppal.TabIndex = 0
        '
        'pag_crear_orden
        '
        Me.pag_crear_orden.Controls.Add(Me.GB_orden_produccion)
        Me.pag_crear_orden.Location = New System.Drawing.Point(4, 22)
        Me.pag_crear_orden.Name = "pag_crear_orden"
        Me.pag_crear_orden.Padding = New System.Windows.Forms.Padding(3)
        Me.pag_crear_orden.Size = New System.Drawing.Size(1020, 463)
        Me.pag_crear_orden.TabIndex = 0
        Me.pag_crear_orden.Text = "Orden de Producción"
        Me.pag_crear_orden.UseVisualStyleBackColor = True
        '
        'GB_orden_produccion
        '
        Me.GB_orden_produccion.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GB_orden_produccion.Controls.Add(Me.cbo_fec_orden)
        Me.GB_orden_produccion.Controls.Add(Me.Label4)
        Me.GB_orden_produccion.Controls.Add(Me.btnGuardar)
        Me.GB_orden_produccion.Controls.Add(Me.txtCantProg)
        Me.GB_orden_produccion.Controls.Add(Me.cbo_prod_final)
        Me.GB_orden_produccion.Controls.Add(Me.cbo_map_prima_2)
        Me.GB_orden_produccion.Controls.Add(Me.cbo_mat_prima)
        Me.GB_orden_produccion.Controls.Add(Me.cbo_maquina)
        Me.GB_orden_produccion.Controls.Add(Me.Label2)
        Me.GB_orden_produccion.Controls.Add(Me.Label21)
        Me.GB_orden_produccion.Controls.Add(Me.Label3)
        Me.GB_orden_produccion.Controls.Add(Me.txtnota)
        Me.GB_orden_produccion.Controls.Add(Me.Label23)
        Me.GB_orden_produccion.Controls.Add(Me.Label31)
        Me.GB_orden_produccion.Controls.Add(Me.Label7)
        Me.GB_orden_produccion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GB_orden_produccion.Location = New System.Drawing.Point(6, 3)
        Me.GB_orden_produccion.Name = "GB_orden_produccion"
        Me.GB_orden_produccion.Size = New System.Drawing.Size(1005, 453)
        Me.GB_orden_produccion.TabIndex = 2124
        Me.GB_orden_produccion.TabStop = False
        Me.GB_orden_produccion.Text = "Generar orden de producción"
        '
        'cbo_fec_orden
        '
        Me.cbo_fec_orden.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cbo_fec_orden.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.cbo_fec_orden.Location = New System.Drawing.Point(500, 341)
        Me.cbo_fec_orden.Name = "cbo_fec_orden"
        Me.cbo_fec_orden.Size = New System.Drawing.Size(118, 22)
        Me.cbo_fec_orden.TabIndex = 2135
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(454, 346)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 13)
        Me.Label4.TabIndex = 2134
        Me.Label4.Text = "Fecha:"
        '
        'btnGuardar
        '
        Me.btnGuardar.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnGuardar.Location = New System.Drawing.Point(457, 12)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(123, 94)
        Me.btnGuardar.StateNormal.Content.Image.ImageV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near
        Me.btnGuardar.TabIndex = 2133
        Me.btnGuardar.Values.Image = Global.Spic.My.Resources.Resources._Save
        Me.btnGuardar.Values.Text = "Guardar"
        '
        'txtCantProg
        '
        Me.txtCantProg.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtCantProg.Location = New System.Drawing.Point(206, 314)
        Me.txtCantProg.Name = "txtCantProg"
        Me.txtCantProg.Size = New System.Drawing.Size(610, 23)
        Me.txtCantProg.TabIndex = 2132
        '
        'cbo_prod_final
        '
        Me.cbo_prod_final.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cbo_prod_final.DropDownWidth = 610
        Me.cbo_prod_final.Location = New System.Drawing.Point(206, 270)
        Me.cbo_prod_final.Name = "cbo_prod_final"
        Me.cbo_prod_final.Size = New System.Drawing.Size(610, 21)
        Me.cbo_prod_final.TabIndex = 2129
        Me.cbo_prod_final.Text = "Seleccione"
        '
        'cbo_map_prima_2
        '
        Me.cbo_map_prima_2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cbo_map_prima_2.DropDownWidth = 610
        Me.cbo_map_prima_2.Location = New System.Drawing.Point(206, 225)
        Me.cbo_map_prima_2.Name = "cbo_map_prima_2"
        Me.cbo_map_prima_2.Size = New System.Drawing.Size(610, 21)
        Me.cbo_map_prima_2.TabIndex = 2128
        Me.cbo_map_prima_2.Text = "Seleccione"
        '
        'cbo_mat_prima
        '
        Me.cbo_mat_prima.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cbo_mat_prima.DropDownWidth = 610
        Me.cbo_mat_prima.Location = New System.Drawing.Point(206, 180)
        Me.cbo_mat_prima.Name = "cbo_mat_prima"
        Me.cbo_mat_prima.Size = New System.Drawing.Size(610, 21)
        Me.cbo_mat_prima.TabIndex = 2127
        Me.cbo_mat_prima.Text = "Seleccione"
        '
        'cbo_maquina
        '
        Me.cbo_maquina.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cbo_maquina.DropDownWidth = 609
        Me.cbo_maquina.Location = New System.Drawing.Point(207, 134)
        Me.cbo_maquina.Name = "cbo_maquina"
        Me.cbo_maquina.Size = New System.Drawing.Size(609, 21)
        Me.cbo_maquina.TabIndex = 2126
        Me.cbo_maquina.Text = "Seleccione"
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(206, 201)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(138, 24)
        Me.Label2.TabIndex = 2124
        Me.Label2.Text = "Materia prima 2"
        '
        'Label21
        '
        Me.Label21.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(204, 290)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(260, 24)
        Me.Label21.TabIndex = 2115
        Me.Label21.Text = "Cant prog(Cantidad de rollos):"
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(6, 378)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 13)
        Me.Label3.TabIndex = 2122
        Me.Label3.Text = "NOTAS:"
        '
        'txtnota
        '
        Me.txtnota.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtnota.Location = New System.Drawing.Point(75, 374)
        Me.txtnota.Name = "txtnota"
        Me.txtnota.Size = New System.Drawing.Size(933, 59)
        Me.txtnota.TabIndex = 2121
        Me.txtnota.Text = ""
        '
        'Label23
        '
        Me.Label23.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(206, 106)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(88, 24)
        Me.Label23.TabIndex = 1179
        Me.Label23.Text = "Maquina:"
        '
        'Label31
        '
        Me.Label31.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(205, 157)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(123, 24)
        Me.Label31.TabIndex = 1184
        Me.Label31.Text = "Materia prima"
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(206, 246)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(171, 24)
        Me.Label7.TabIndex = 2118
        Me.Label7.Text = "Prod final (Código):"
        '
        'gb_ordenes_c
        '
        Me.gb_ordenes_c.Controls.Add(Me.btnNuevo)
        Me.gb_ordenes_c.Controls.Add(Me.Label12)
        Me.gb_ordenes_c.Controls.Add(Me.TextBox1)
        Me.gb_ordenes_c.Controls.Add(Me.porcen_header)
        Me.gb_ordenes_c.Controls.Add(Me.lbl_cumplidas)
        Me.gb_ordenes_c.Controls.Add(Me.KryptonGroupBox1)
        Me.gb_ordenes_c.Controls.Add(Me.TextBox2)
        Me.gb_ordenes_c.Controls.Add(Me.txtConsulNumOrd)
        Me.gb_ordenes_c.Controls.Add(Me.Label33)
        Me.gb_ordenes_c.Controls.Add(Me.dtg_consulta)
        Me.gb_ordenes_c.Location = New System.Drawing.Point(4, 22)
        Me.gb_ordenes_c.Name = "gb_ordenes_c"
        Me.gb_ordenes_c.Padding = New System.Windows.Forms.Padding(3)
        Me.gb_ordenes_c.Size = New System.Drawing.Size(1020, 463)
        Me.gb_ordenes_c.TabIndex = 2
        Me.gb_ordenes_c.Text = "Gestionar ordenes"
        Me.gb_ordenes_c.UseVisualStyleBackColor = True
        '
        'btnNuevo
        '
        Me.btnNuevo.Location = New System.Drawing.Point(886, 15)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(125, 40)
        Me.btnNuevo.TabIndex = 1207
        Me.btnNuevo.Values.Image = Global.Spic.My.Resources.Resources._new
        Me.btnNuevo.Values.Text = "Nueva orden"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(203, 49)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(115, 13)
        Me.Label12.TabIndex = 1206
        Me.Label12.Text = "Planillas completas"
        '
        'TextBox1
        '
        Me.TextBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.TextBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.TextBox1.BackColor = System.Drawing.Color.Red
        Me.TextBox1.Location = New System.Drawing.Point(174, 46)
        Me.TextBox1.MaxLength = 13
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(23, 20)
        Me.TextBox1.TabIndex = 1205
        '
        'porcen_header
        '
        Me.porcen_header.Location = New System.Drawing.Point(638, 15)
        Me.porcen_header.Name = "porcen_header"
        Me.porcen_header.Size = New System.Drawing.Size(102, 36)
        Me.porcen_header.StateNormal.Content.LongText.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.porcen_header.StateNormal.Content.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.porcen_header.TabIndex = 1204
        Me.porcen_header.Values.Description = ""
        Me.porcen_header.Values.Heading = "% Ordenes"
        Me.porcen_header.Values.Image = CType(resources.GetObject("porcen_header.Values.Image"), System.Drawing.Image)
        '
        'lbl_cumplidas
        '
        Me.lbl_cumplidas.Location = New System.Drawing.Point(633, 49)
        Me.lbl_cumplidas.Name = "lbl_cumplidas"
        Me.lbl_cumplidas.Size = New System.Drawing.Size(137, 20)
        Me.lbl_cumplidas.TabIndex = 1203
        Me.lbl_cumplidas.Values.Text = "Nro ordenes cumplidas"
        '
        'KryptonGroupBox1
        '
        Me.KryptonGroupBox1.CaptionOverlap = 0R
        Me.KryptonGroupBox1.Location = New System.Drawing.Point(421, 3)
        Me.KryptonGroupBox1.Name = "KryptonGroupBox1"
        '
        'KryptonGroupBox1.Panel
        '
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.Label5)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.cboFechaFin)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.cboFechaIni)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.Label13)
        Me.KryptonGroupBox1.Size = New System.Drawing.Size(156, 70)
        Me.KryptonGroupBox1.TabIndex = 1202
        Me.KryptonGroupBox1.Values.Heading = "Fechas:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(3, 2)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(45, 13)
        Me.Label5.TabIndex = 1029
        Me.Label5.Text = "Inicial:"
        '
        'cboFechaFin
        '
        Me.cboFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.cboFechaFin.Location = New System.Drawing.Point(50, 23)
        Me.cboFechaFin.Name = "cboFechaFin"
        Me.cboFechaFin.Size = New System.Drawing.Size(101, 21)
        Me.cboFechaFin.TabIndex = 1198
        '
        'cboFechaIni
        '
        Me.cboFechaIni.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.cboFechaIni.Location = New System.Drawing.Point(50, -2)
        Me.cboFechaIni.Name = "cboFechaIni"
        Me.cboFechaIni.Size = New System.Drawing.Size(101, 21)
        Me.cboFechaIni.TabIndex = 1199
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(10, 28)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(38, 13)
        Me.Label13.TabIndex = 1031
        Me.Label13.Text = "Final:"
        '
        'TextBox2
        '
        Me.TextBox2.BackColor = System.Drawing.Color.GreenYellow
        Me.TextBox2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox2.Location = New System.Drawing.Point(1030, 27)
        Me.TextBox2.Multiline = True
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ReadOnly = True
        Me.TextBox2.Size = New System.Drawing.Size(61, 27)
        Me.TextBox2.TabIndex = 1179
        '
        'txtConsulNumOrd
        '
        Me.txtConsulNumOrd.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtConsulNumOrd.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtConsulNumOrd.Location = New System.Drawing.Point(253, 25)
        Me.txtConsulNumOrd.MaxLength = 13
        Me.txtConsulNumOrd.Name = "txtConsulNumOrd"
        Me.txtConsulNumOrd.Size = New System.Drawing.Size(110, 20)
        Me.txtConsulNumOrd.TabIndex = 1178
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.Location = New System.Drawing.Point(107, 28)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(144, 13)
        Me.Label33.TabIndex = 1177
        Me.Label33.Text = "Orden de producción Nº"
        '
        'dtg_consulta
        '
        Me.dtg_consulta.AllowUserToAddRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        Me.dtg_consulta.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dtg_consulta.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtg_consulta.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtg_consulta.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dtg_consulta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtg_consulta.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.btnVerDetalle, Me.col_oculto, Me.col_duplicar, Me.col_porcen})
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
        Me.dtg_consulta.Location = New System.Drawing.Point(7, 77)
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
        Me.dtg_consulta.Size = New System.Drawing.Size(1065, 367)
        Me.dtg_consulta.TabIndex = 1174
        '
        'btnVerDetalle
        '
        Me.btnVerDetalle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.btnVerDetalle.Frozen = True
        Me.btnVerDetalle.HeaderText = "Ver"
        Me.btnVerDetalle.Image = Global.Spic.My.Resources.Resources._1385696481_kghostview
        Me.btnVerDetalle.Name = "btnVerDetalle"
        Me.btnVerDetalle.ReadOnly = True
        Me.btnVerDetalle.Width = 29
        '
        'col_oculto
        '
        Me.col_oculto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.col_oculto.HeaderText = "Oculto"
        Me.col_oculto.Image = Global.Spic.My.Resources.Resources.x
        Me.col_oculto.Name = "col_oculto"
        Me.col_oculto.ReadOnly = True
        Me.col_oculto.Width = 44
        '
        'col_duplicar
        '
        Me.col_duplicar.HeaderText = "Duplicar"
        Me.col_duplicar.Name = "col_duplicar"
        Me.col_duplicar.ReadOnly = True
        Me.col_duplicar.Text = "Duplicar"
        Me.col_duplicar.UseColumnTextForButtonValue = True
        '
        'col_porcen
        '
        Me.col_porcen.HeaderText = "Porc cum kilos%"
        Me.col_porcen.Name = "col_porcen"
        Me.col_porcen.ReadOnly = True
        '
        'frm_orden_prod_puas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1028, 493)
        Me.Controls.Add(Me.tbl_ppal)
        Me.Name = "frm_orden_prod_puas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Orden de producción puas"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.tbl_ppal.ResumeLayout(False)
        Me.pag_crear_orden.ResumeLayout(False)
        Me.GB_orden_produccion.ResumeLayout(False)
        Me.GB_orden_produccion.PerformLayout()
        CType(Me.cbo_prod_final, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbo_map_prima_2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbo_mat_prima, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbo_maquina, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gb_ordenes_c.ResumeLayout(False)
        Me.gb_ordenes_c.PerformLayout()
        CType(Me.KryptonGroupBox1.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox1.Panel.ResumeLayout(False)
        Me.KryptonGroupBox1.Panel.PerformLayout()
        CType(Me.KryptonGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox1.ResumeLayout(False)
        CType(Me.dtg_consulta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tbl_ppal As System.Windows.Forms.TabControl
    Friend WithEvents pag_crear_orden As System.Windows.Forms.TabPage
    Friend WithEvents GB_orden_produccion As System.Windows.Forms.GroupBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtnota As System.Windows.Forms.RichTextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents gb_ordenes_c As System.Windows.Forms.TabPage
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents txtConsulNumOrd As System.Windows.Forms.TextBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents dtg_consulta As System.Windows.Forms.DataGridView
    Friend WithEvents cbo_prod_final As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents cbo_map_prima_2 As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents cbo_mat_prima As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents cbo_maquina As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents txtCantProg As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents btnGuardar As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents cbo_fec_orden As DateTimePicker
    Friend WithEvents Label4 As Label
    Friend WithEvents KryptonGroupBox1 As ComponentFactory.Krypton.Toolkit.KryptonGroupBox
    Friend WithEvents Label5 As Label
    Friend WithEvents cboFechaFin As ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker
    Friend WithEvents cboFechaIni As ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker
    Friend WithEvents Label13 As Label
    Friend WithEvents porcen_header As ComponentFactory.Krypton.Toolkit.KryptonHeader
    Friend WithEvents lbl_cumplidas As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents btnVerDetalle As DataGridViewImageColumn
    Friend WithEvents col_oculto As DataGridViewImageColumn
    Friend WithEvents col_duplicar As DataGridViewButtonColumn
    Friend WithEvents col_porcen As DataGridViewTextBoxColumn
    Friend WithEvents Label12 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents btnNuevo As ComponentFactory.Krypton.Toolkit.KryptonButton
End Class
