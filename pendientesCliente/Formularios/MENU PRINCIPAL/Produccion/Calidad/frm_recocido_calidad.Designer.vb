<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_recocido_calidad
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_recocido_calidad))
        Me.tbl_calidad_rec = New System.Windows.Forms.TabControl()
        Me.p_orden_prod = New System.Windows.Forms.TabPage()
        Me.GroupClientes = New System.Windows.Forms.GroupBox()
        Me.Label68 = New System.Windows.Forms.Label()
        Me.Label67 = New System.Windows.Forms.Label()
        Me.txtClienteB = New System.Windows.Forms.TextBox()
        Me.txtnitB = New System.Windows.Forms.TextBox()
        Me.btn_cerrar_clientes = New System.Windows.Forms.Button()
        Me.dgt_cliente = New System.Windows.Forms.DataGridView()
        Me.brnSelectCli = New System.Windows.Forms.DataGridViewImageColumn()
        Me.dtg_orden_prod = New System.Windows.Forms.DataGridView()
        Me.col_ver = New System.Windows.Forms.DataGridViewImageColumn()
        Me.group_filtro = New System.Windows.Forms.GroupBox()
        Me.btn_consultar = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txt_cliente = New System.Windows.Forms.TextBox()
        Me.txt_codigo = New System.Windows.Forms.TextBox()
        Me.txt_orden = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.cbo_ano_filtro = New System.Windows.Forms.ComboBox()
        Me.cbo_mes_filtro = New System.Windows.Forms.ComboBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.p_detalle = New System.Windows.Forms.TabPage()
        Me.group_no_conforme = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Btn_registrar_rollo_nc = New System.Windows.Forms.Button()
        Me.lbl_peso = New System.Windows.Forms.Label()
        Me.lbl_codigo = New System.Windows.Forms.Label()
        Me.lbl_nombre = New System.Windows.Forms.Label()
        Me.txt_lecto = New System.Windows.Forms.TextBox()
        Me.txt_nota = New System.Windows.Forms.TextBox()
        Me.cbo_defecto = New System.Windows.Forms.ComboBox()
        Me.cbo_operario = New System.Windows.Forms.ComboBox()
        Me.lbl_detalle = New System.Windows.Forms.Label()
        Me.Label90 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txt_cantidad = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txt_nombre_prod = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txt_prod_final = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txt_nombre_cliente = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txt_consecutivo = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.group_opciones = New System.Windows.Forms.GroupBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btn_registrar_rollo = New System.Windows.Forms.Button()
        Me.btn_bache_conforme = New System.Windows.Forms.Button()
        Me.dtg_rollo_orden = New System.Windows.Forms.DataGridView()
        Me.dtg_detall_orden = New System.Windows.Forms.DataGridView()
        Me.col_rollos = New System.Windows.Forms.DataGridViewImageColumn()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.btn_excel = New System.Windows.Forms.Button()
        Me.btn_consultar_nC = New System.Windows.Forms.Button()
        Me.dtg_consulta = New System.Windows.Forms.DataGridView()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cbo_ano_op = New System.Windows.Forms.ComboBox()
        Me.cbo_mes_op = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.tbl_calidad_rec.SuspendLayout()
        Me.p_orden_prod.SuspendLayout()
        Me.GroupClientes.SuspendLayout()
        CType(Me.dgt_cliente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtg_orden_prod, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.group_filtro.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.p_detalle.SuspendLayout()
        Me.group_no_conforme.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.group_opciones.SuspendLayout()
        CType(Me.dtg_rollo_orden, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtg_detall_orden, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage1.SuspendLayout()
        CType(Me.dtg_consulta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'tbl_calidad_rec
        '
        Me.tbl_calidad_rec.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbl_calidad_rec.Controls.Add(Me.p_orden_prod)
        Me.tbl_calidad_rec.Controls.Add(Me.p_detalle)
        Me.tbl_calidad_rec.Controls.Add(Me.TabPage1)
        Me.tbl_calidad_rec.Location = New System.Drawing.Point(0, 1)
        Me.tbl_calidad_rec.Name = "tbl_calidad_rec"
        Me.tbl_calidad_rec.SelectedIndex = 0
        Me.tbl_calidad_rec.Size = New System.Drawing.Size(705, 578)
        Me.tbl_calidad_rec.TabIndex = 0
        '
        'p_orden_prod
        '
        Me.p_orden_prod.Controls.Add(Me.GroupClientes)
        Me.p_orden_prod.Controls.Add(Me.dtg_orden_prod)
        Me.p_orden_prod.Controls.Add(Me.group_filtro)
        Me.p_orden_prod.Location = New System.Drawing.Point(4, 22)
        Me.p_orden_prod.Name = "p_orden_prod"
        Me.p_orden_prod.Padding = New System.Windows.Forms.Padding(3)
        Me.p_orden_prod.Size = New System.Drawing.Size(697, 552)
        Me.p_orden_prod.TabIndex = 1
        Me.p_orden_prod.Text = "Ordenes de Produccion"
        Me.p_orden_prod.UseVisualStyleBackColor = True
        '
        'GroupClientes
        '
        Me.GroupClientes.BackColor = System.Drawing.SystemColors.Control
        Me.GroupClientes.Controls.Add(Me.Label68)
        Me.GroupClientes.Controls.Add(Me.Label67)
        Me.GroupClientes.Controls.Add(Me.txtClienteB)
        Me.GroupClientes.Controls.Add(Me.txtnitB)
        Me.GroupClientes.Controls.Add(Me.btn_cerrar_clientes)
        Me.GroupClientes.Controls.Add(Me.dgt_cliente)
        Me.GroupClientes.Location = New System.Drawing.Point(15, 144)
        Me.GroupClientes.Name = "GroupClientes"
        Me.GroupClientes.Size = New System.Drawing.Size(667, 264)
        Me.GroupClientes.TabIndex = 2142
        Me.GroupClientes.TabStop = False
        Me.GroupClientes.Text = "Clientes"
        Me.GroupClientes.Visible = False
        '
        'Label68
        '
        Me.Label68.AutoSize = True
        Me.Label68.Location = New System.Drawing.Point(188, 21)
        Me.Label68.Name = "Label68"
        Me.Label68.Size = New System.Drawing.Size(42, 13)
        Me.Label68.TabIndex = 1193
        Me.Label68.Text = "Cliente:"
        '
        'Label67
        '
        Me.Label67.AutoSize = True
        Me.Label67.Location = New System.Drawing.Point(18, 24)
        Me.Label67.Name = "Label67"
        Me.Label67.Size = New System.Drawing.Size(28, 13)
        Me.Label67.TabIndex = 1192
        Me.Label67.Text = "NIT:"
        '
        'txtClienteB
        '
        Me.txtClienteB.Location = New System.Drawing.Point(241, 18)
        Me.txtClienteB.Name = "txtClienteB"
        Me.txtClienteB.Size = New System.Drawing.Size(215, 20)
        Me.txtClienteB.TabIndex = 1191
        '
        'txtnitB
        '
        Me.txtnitB.Location = New System.Drawing.Point(69, 21)
        Me.txtnitB.Name = "txtnitB"
        Me.txtnitB.Size = New System.Drawing.Size(100, 20)
        Me.txtnitB.TabIndex = 1190
        '
        'btn_cerrar_clientes
        '
        Me.btn_cerrar_clientes.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_cerrar_clientes.ForeColor = System.Drawing.Color.Red
        Me.btn_cerrar_clientes.Location = New System.Drawing.Point(635, 7)
        Me.btn_cerrar_clientes.Name = "btn_cerrar_clientes"
        Me.btn_cerrar_clientes.Size = New System.Drawing.Size(26, 23)
        Me.btn_cerrar_clientes.TabIndex = 1189
        Me.btn_cerrar_clientes.Text = "X"
        Me.btn_cerrar_clientes.UseVisualStyleBackColor = True
        '
        'dgt_cliente
        '
        Me.dgt_cliente.AllowUserToAddRows = False
        Me.dgt_cliente.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgt_cliente.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgt_cliente.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgt_cliente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgt_cliente.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.brnSelectCli})
        Me.dgt_cliente.Location = New System.Drawing.Point(6, 46)
        Me.dgt_cliente.Name = "dgt_cliente"
        Me.dgt_cliente.ReadOnly = True
        Me.dgt_cliente.RowHeadersVisible = False
        Me.dgt_cliente.Size = New System.Drawing.Size(650, 211)
        Me.dgt_cliente.TabIndex = 0
        '
        'brnSelectCli
        '
        Me.brnSelectCli.Frozen = True
        Me.brnSelectCli.HeaderText = ""
        Me.brnSelectCli.Image = Global.Spic.My.Resources.Resources.ok3
        Me.brnSelectCli.Name = "brnSelectCli"
        Me.brnSelectCli.ReadOnly = True
        Me.brnSelectCli.Width = 5
        '
        'dtg_orden_prod
        '
        Me.dtg_orden_prod.AllowUserToAddRows = False
        Me.dtg_orden_prod.AllowUserToDeleteRows = False
        Me.dtg_orden_prod.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtg_orden_prod.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dtg_orden_prod.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dtg_orden_prod.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtg_orden_prod.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.col_ver})
        Me.dtg_orden_prod.Location = New System.Drawing.Point(8, 107)
        Me.dtg_orden_prod.Name = "dtg_orden_prod"
        Me.dtg_orden_prod.ReadOnly = True
        Me.dtg_orden_prod.RowHeadersVisible = False
        Me.dtg_orden_prod.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtg_orden_prod.Size = New System.Drawing.Size(680, 439)
        Me.dtg_orden_prod.TabIndex = 1
        '
        'col_ver
        '
        Me.col_ver.HeaderText = ""
        Me.col_ver.Image = CType(resources.GetObject("col_ver.Image"), System.Drawing.Image)
        Me.col_ver.Name = "col_ver"
        Me.col_ver.ReadOnly = True
        Me.col_ver.Width = 5
        '
        'group_filtro
        '
        Me.group_filtro.Controls.Add(Me.btn_consultar)
        Me.group_filtro.Controls.Add(Me.Label3)
        Me.group_filtro.Controls.Add(Me.txt_cliente)
        Me.group_filtro.Controls.Add(Me.txt_codigo)
        Me.group_filtro.Controls.Add(Me.txt_orden)
        Me.group_filtro.Controls.Add(Me.Label2)
        Me.group_filtro.Controls.Add(Me.Label1)
        Me.group_filtro.Controls.Add(Me.GroupBox3)
        Me.group_filtro.Location = New System.Drawing.Point(8, 6)
        Me.group_filtro.Name = "group_filtro"
        Me.group_filtro.Size = New System.Drawing.Size(504, 95)
        Me.group_filtro.TabIndex = 0
        Me.group_filtro.TabStop = False
        Me.group_filtro.Text = "Filtro"
        '
        'btn_consultar
        '
        Me.btn_consultar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_consultar.Image = Global.Spic.My.Resources.Resources.update
        Me.btn_consultar.Location = New System.Drawing.Point(395, 21)
        Me.btn_consultar.Name = "btn_consultar"
        Me.btn_consultar.Size = New System.Drawing.Size(91, 57)
        Me.btn_consultar.TabIndex = 17
        Me.btn_consultar.Text = "Consultar"
        Me.btn_consultar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_consultar.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 71)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 13)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Cliente:"
        '
        'txt_cliente
        '
        Me.txt_cliente.Location = New System.Drawing.Point(55, 68)
        Me.txt_cliente.Name = "txt_cliente"
        Me.txt_cliente.Size = New System.Drawing.Size(151, 20)
        Me.txt_cliente.TabIndex = 15
        '
        'txt_codigo
        '
        Me.txt_codigo.Location = New System.Drawing.Point(55, 42)
        Me.txt_codigo.Name = "txt_codigo"
        Me.txt_codigo.Size = New System.Drawing.Size(151, 20)
        Me.txt_codigo.TabIndex = 13
        '
        'txt_orden
        '
        Me.txt_orden.Location = New System.Drawing.Point(106, 16)
        Me.txt_orden.Name = "txt_orden"
        Me.txt_orden.Size = New System.Drawing.Size(100, 20)
        Me.txt_orden.TabIndex = 12
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 13)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Codigo:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(94, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Numero de Orden:"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cbo_ano_filtro)
        Me.GroupBox3.Controls.Add(Me.cbo_mes_filtro)
        Me.GroupBox3.Controls.Add(Me.Label19)
        Me.GroupBox3.Controls.Add(Me.Label18)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(212, 7)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(167, 81)
        Me.GroupBox3.TabIndex = 9
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Fecha"
        '
        'cbo_ano_filtro
        '
        Me.cbo_ano_filtro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_ano_filtro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_ano_filtro.FormattingEnabled = True
        Me.cbo_ano_filtro.Location = New System.Drawing.Point(51, 50)
        Me.cbo_ano_filtro.Name = "cbo_ano_filtro"
        Me.cbo_ano_filtro.Size = New System.Drawing.Size(110, 21)
        Me.cbo_ano_filtro.TabIndex = 3
        '
        'cbo_mes_filtro
        '
        Me.cbo_mes_filtro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_mes_filtro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_mes_filtro.FormattingEnabled = True
        Me.cbo_mes_filtro.Location = New System.Drawing.Point(50, 17)
        Me.cbo_mes_filtro.Name = "cbo_mes_filtro"
        Me.cbo_mes_filtro.Size = New System.Drawing.Size(111, 21)
        Me.cbo_mes_filtro.TabIndex = 2
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(10, 51)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(35, 15)
        Me.Label19.TabIndex = 1
        Me.Label19.Text = "Año:"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(6, 17)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(38, 15)
        Me.Label18.TabIndex = 0
        Me.Label18.Text = "Mes:"
        '
        'p_detalle
        '
        Me.p_detalle.Controls.Add(Me.group_no_conforme)
        Me.p_detalle.Controls.Add(Me.lbl_detalle)
        Me.p_detalle.Controls.Add(Me.Label90)
        Me.p_detalle.Controls.Add(Me.GroupBox1)
        Me.p_detalle.Controls.Add(Me.group_opciones)
        Me.p_detalle.Controls.Add(Me.dtg_rollo_orden)
        Me.p_detalle.Controls.Add(Me.dtg_detall_orden)
        Me.p_detalle.Location = New System.Drawing.Point(4, 22)
        Me.p_detalle.Name = "p_detalle"
        Me.p_detalle.Padding = New System.Windows.Forms.Padding(3)
        Me.p_detalle.Size = New System.Drawing.Size(697, 552)
        Me.p_detalle.TabIndex = 2
        Me.p_detalle.Text = "Detalles"
        Me.p_detalle.UseVisualStyleBackColor = True
        '
        'group_no_conforme
        '
        Me.group_no_conforme.Controls.Add(Me.Button1)
        Me.group_no_conforme.Controls.Add(Me.Label14)
        Me.group_no_conforme.Controls.Add(Me.Label13)
        Me.group_no_conforme.Controls.Add(Me.Label12)
        Me.group_no_conforme.Controls.Add(Me.Btn_registrar_rollo_nc)
        Me.group_no_conforme.Controls.Add(Me.lbl_peso)
        Me.group_no_conforme.Controls.Add(Me.lbl_codigo)
        Me.group_no_conforme.Controls.Add(Me.lbl_nombre)
        Me.group_no_conforme.Controls.Add(Me.txt_lecto)
        Me.group_no_conforme.Controls.Add(Me.txt_nota)
        Me.group_no_conforme.Controls.Add(Me.cbo_defecto)
        Me.group_no_conforme.Controls.Add(Me.cbo_operario)
        Me.group_no_conforme.Location = New System.Drawing.Point(179, 174)
        Me.group_no_conforme.Name = "group_no_conforme"
        Me.group_no_conforme.Size = New System.Drawing.Size(367, 324)
        Me.group_no_conforme.TabIndex = 6
        Me.group_no_conforme.TabStop = False
        Me.group_no_conforme.Text = "Registrar Rollo No Conforme"
        Me.group_no_conforme.Visible = False
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.ForeColor = System.Drawing.Color.Red
        Me.Button1.Location = New System.Drawing.Point(341, 0)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(26, 23)
        Me.Button1.TabIndex = 1190
        Me.Button1.Text = "X"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(13, 160)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(33, 13)
        Me.Label14.TabIndex = 10
        Me.Label14.Text = "Nota:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(40, 135)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(48, 13)
        Me.Label13.TabIndex = 9
        Me.Label13.Text = "Defecto:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(40, 108)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(50, 13)
        Me.Label12.TabIndex = 8
        Me.Label12.Text = "Operario:"
        '
        'Btn_registrar_rollo_nc
        '
        Me.Btn_registrar_rollo_nc.Enabled = False
        Me.Btn_registrar_rollo_nc.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_registrar_rollo_nc.Location = New System.Drawing.Point(117, 285)
        Me.Btn_registrar_rollo_nc.Name = "Btn_registrar_rollo_nc"
        Me.Btn_registrar_rollo_nc.Size = New System.Drawing.Size(145, 33)
        Me.Btn_registrar_rollo_nc.TabIndex = 7
        Me.Btn_registrar_rollo_nc.Text = "Registrar Rollo"
        Me.Btn_registrar_rollo_nc.UseVisualStyleBackColor = True
        '
        'lbl_peso
        '
        Me.lbl_peso.AutoSize = True
        Me.lbl_peso.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl_peso.Location = New System.Drawing.Point(154, 87)
        Me.lbl_peso.Name = "lbl_peso"
        Me.lbl_peso.Size = New System.Drawing.Size(47, 15)
        Me.lbl_peso.TabIndex = 6
        Me.lbl_peso.Text = "Label14"
        '
        'lbl_codigo
        '
        Me.lbl_codigo.AutoSize = True
        Me.lbl_codigo.Location = New System.Drawing.Point(13, 89)
        Me.lbl_codigo.Name = "lbl_codigo"
        Me.lbl_codigo.Size = New System.Drawing.Size(45, 13)
        Me.lbl_codigo.TabIndex = 5
        Me.lbl_codigo.Text = "Label13"
        '
        'lbl_nombre
        '
        Me.lbl_nombre.AutoSize = True
        Me.lbl_nombre.Location = New System.Drawing.Point(13, 67)
        Me.lbl_nombre.Name = "lbl_nombre"
        Me.lbl_nombre.Size = New System.Drawing.Size(45, 13)
        Me.lbl_nombre.TabIndex = 4
        Me.lbl_nombre.Text = "Label12"
        '
        'txt_lecto
        '
        Me.txt_lecto.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_lecto.Location = New System.Drawing.Point(14, 35)
        Me.txt_lecto.Name = "txt_lecto"
        Me.txt_lecto.Size = New System.Drawing.Size(338, 29)
        Me.txt_lecto.TabIndex = 3
        '
        'txt_nota
        '
        Me.txt_nota.Enabled = False
        Me.txt_nota.Location = New System.Drawing.Point(16, 176)
        Me.txt_nota.Multiline = True
        Me.txt_nota.Name = "txt_nota"
        Me.txt_nota.Size = New System.Drawing.Size(336, 103)
        Me.txt_nota.TabIndex = 2
        '
        'cbo_defecto
        '
        Me.cbo_defecto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_defecto.Enabled = False
        Me.cbo_defecto.FormattingEnabled = True
        Me.cbo_defecto.Location = New System.Drawing.Point(96, 132)
        Me.cbo_defecto.Name = "cbo_defecto"
        Me.cbo_defecto.Size = New System.Drawing.Size(166, 21)
        Me.cbo_defecto.TabIndex = 1
        '
        'cbo_operario
        '
        Me.cbo_operario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_operario.Enabled = False
        Me.cbo_operario.FormattingEnabled = True
        Me.cbo_operario.Location = New System.Drawing.Point(96, 105)
        Me.cbo_operario.Name = "cbo_operario"
        Me.cbo_operario.Size = New System.Drawing.Size(214, 21)
        Me.cbo_operario.TabIndex = 0
        '
        'lbl_detalle
        '
        Me.lbl_detalle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_detalle.AutoSize = True
        Me.lbl_detalle.BackColor = System.Drawing.Color.DarkTurquoise
        Me.lbl_detalle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl_detalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_detalle.Location = New System.Drawing.Point(584, 146)
        Me.lbl_detalle.Name = "lbl_detalle"
        Me.lbl_detalle.Size = New System.Drawing.Size(52, 20)
        Me.lbl_detalle.TabIndex = 5
        Me.lbl_detalle.Text = "detalle"
        '
        'Label90
        '
        Me.Label90.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label90.AutoSize = True
        Me.Label90.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label90.Location = New System.Drawing.Point(443, 148)
        Me.Label90.Name = "Label90"
        Me.Label90.Size = New System.Drawing.Size(148, 18)
        Me.Label90.TabIndex = 4
        Me.Label90.Text = "Rollos del detalle: "
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.GroupBox1.Controls.Add(Me.txt_cantidad)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txt_nombre_prod)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txt_prod_final)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txt_nombre_cliente)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txt_consecutivo)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Enabled = False
        Me.GroupBox1.Location = New System.Drawing.Point(6, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(682, 62)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        '
        'txt_cantidad
        '
        Me.txt_cantidad.BackColor = System.Drawing.Color.Orange
        Me.txt_cantidad.Enabled = False
        Me.txt_cantidad.Location = New System.Drawing.Point(630, 32)
        Me.txt_cantidad.Name = "txt_cantidad"
        Me.txt_cantidad.Size = New System.Drawing.Size(46, 20)
        Me.txt_cantidad.TabIndex = 13
        Me.txt_cantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(627, 16)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(49, 13)
        Me.Label8.TabIndex = 12
        Me.Label8.Text = "Cantidad"
        '
        'txt_nombre_prod
        '
        Me.txt_nombre_prod.BackColor = System.Drawing.Color.Orange
        Me.txt_nombre_prod.Enabled = False
        Me.txt_nombre_prod.Location = New System.Drawing.Point(425, 32)
        Me.txt_nombre_prod.Name = "txt_nombre_prod"
        Me.txt_nombre_prod.Size = New System.Drawing.Size(199, 20)
        Me.txt_nombre_prod.TabIndex = 11
        Me.txt_nombre_prod.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(467, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(90, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Nombre Producto"
        '
        'txt_prod_final
        '
        Me.txt_prod_final.BackColor = System.Drawing.Color.Orange
        Me.txt_prod_final.Enabled = False
        Me.txt_prod_final.Location = New System.Drawing.Point(323, 32)
        Me.txt_prod_final.Name = "txt_prod_final"
        Me.txt_prod_final.Size = New System.Drawing.Size(96, 20)
        Me.txt_prod_final.TabIndex = 9
        Me.txt_prod_final.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(335, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Producto final"
        '
        'txt_nombre_cliente
        '
        Me.txt_nombre_cliente.BackColor = System.Drawing.Color.Orange
        Me.txt_nombre_cliente.Enabled = False
        Me.txt_nombre_cliente.Location = New System.Drawing.Point(78, 32)
        Me.txt_nombre_cliente.Name = "txt_nombre_cliente"
        Me.txt_nombre_cliente.Size = New System.Drawing.Size(239, 20)
        Me.txt_nombre_cliente.TabIndex = 7
        Me.txt_nombre_cliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(170, 16)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(39, 13)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Cliente"
        '
        'txt_consecutivo
        '
        Me.txt_consecutivo.BackColor = System.Drawing.Color.Orange
        Me.txt_consecutivo.Enabled = False
        Me.txt_consecutivo.Location = New System.Drawing.Point(6, 32)
        Me.txt_consecutivo.Name = "txt_consecutivo"
        Me.txt_consecutivo.Size = New System.Drawing.Size(66, 20)
        Me.txt_consecutivo.TabIndex = 1
        Me.txt_consecutivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(66, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Consecutivo"
        '
        'group_opciones
        '
        Me.group_opciones.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.group_opciones.Controls.Add(Me.Label11)
        Me.group_opciones.Controls.Add(Me.Label10)
        Me.group_opciones.Controls.Add(Me.Label9)
        Me.group_opciones.Controls.Add(Me.btn_registrar_rollo)
        Me.group_opciones.Controls.Add(Me.btn_bache_conforme)
        Me.group_opciones.Enabled = False
        Me.group_opciones.Location = New System.Drawing.Point(6, 64)
        Me.group_opciones.Name = "group_opciones"
        Me.group_opciones.Size = New System.Drawing.Size(682, 68)
        Me.group_opciones.TabIndex = 2
        Me.group_opciones.TabStop = False
        '
        'Label11
        '
        Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.LimeGreen
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label11.Location = New System.Drawing.Point(570, 12)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(91, 15)
        Me.Label11.TabIndex = 4
        Me.Label11.Text = "Rollos Conformes"
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Red
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label10.Location = New System.Drawing.Point(570, 30)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(108, 15)
        Me.Label10.TabIndex = 3
        Me.Label10.Text = "Rollos No Conformes"
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.White
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label9.Location = New System.Drawing.Point(571, 48)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(95, 15)
        Me.Label9.TabIndex = 2
        Me.Label9.Text = "Rollos Sin Revisar"
        '
        'btn_registrar_rollo
        '
        Me.btn_registrar_rollo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_registrar_rollo.Enabled = False
        Me.btn_registrar_rollo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_registrar_rollo.Image = Global.Spic.My.Resources.Resources.settings_gears__1_
        Me.btn_registrar_rollo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_registrar_rollo.Location = New System.Drawing.Point(397, 18)
        Me.btn_registrar_rollo.Name = "btn_registrar_rollo"
        Me.btn_registrar_rollo.Size = New System.Drawing.Size(170, 43)
        Me.btn_registrar_rollo.TabIndex = 1
        Me.btn_registrar_rollo.Text = "Registrar Por Rollo"
        Me.btn_registrar_rollo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_registrar_rollo.UseVisualStyleBackColor = True
        '
        'btn_bache_conforme
        '
        Me.btn_bache_conforme.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_bache_conforme.Enabled = False
        Me.btn_bache_conforme.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_bache_conforme.Image = Global.Spic.My.Resources.Resources.cilindr2
        Me.btn_bache_conforme.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_bache_conforme.Location = New System.Drawing.Point(171, 18)
        Me.btn_bache_conforme.Name = "btn_bache_conforme"
        Me.btn_bache_conforme.Size = New System.Drawing.Size(220, 43)
        Me.btn_bache_conforme.TabIndex = 0
        Me.btn_bache_conforme.Text = "Registrar Bache Conforme"
        Me.btn_bache_conforme.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_bache_conforme.UseVisualStyleBackColor = True
        '
        'dtg_rollo_orden
        '
        Me.dtg_rollo_orden.AllowUserToAddRows = False
        Me.dtg_rollo_orden.AllowUserToDeleteRows = False
        Me.dtg_rollo_orden.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtg_rollo_orden.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dtg_rollo_orden.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dtg_rollo_orden.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtg_rollo_orden.Enabled = False
        Me.dtg_rollo_orden.Location = New System.Drawing.Point(385, 174)
        Me.dtg_rollo_orden.MultiSelect = False
        Me.dtg_rollo_orden.Name = "dtg_rollo_orden"
        Me.dtg_rollo_orden.ReadOnly = True
        Me.dtg_rollo_orden.RowHeadersVisible = False
        Me.dtg_rollo_orden.Size = New System.Drawing.Size(303, 372)
        Me.dtg_rollo_orden.TabIndex = 1
        '
        'dtg_detall_orden
        '
        Me.dtg_detall_orden.AllowUserToAddRows = False
        Me.dtg_detall_orden.AllowUserToDeleteRows = False
        Me.dtg_detall_orden.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtg_detall_orden.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dtg_detall_orden.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dtg_detall_orden.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtg_detall_orden.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.col_rollos})
        Me.dtg_detall_orden.Enabled = False
        Me.dtg_detall_orden.Location = New System.Drawing.Point(6, 138)
        Me.dtg_detall_orden.MultiSelect = False
        Me.dtg_detall_orden.Name = "dtg_detall_orden"
        Me.dtg_detall_orden.ReadOnly = True
        Me.dtg_detall_orden.RowHeadersVisible = False
        Me.dtg_detall_orden.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtg_detall_orden.Size = New System.Drawing.Size(373, 408)
        Me.dtg_detall_orden.TabIndex = 0
        '
        'col_rollos
        '
        Me.col_rollos.HeaderText = ""
        Me.col_rollos.Image = Global.Spic.My.Resources.Resources._1385696481_kghostview
        Me.col_rollos.Name = "col_rollos"
        Me.col_rollos.ReadOnly = True
        Me.col_rollos.Width = 5
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.GroupBox2)
        Me.TabPage1.Controls.Add(Me.btn_excel)
        Me.TabPage1.Controls.Add(Me.btn_consultar_nC)
        Me.TabPage1.Controls.Add(Me.dtg_consulta)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(697, 552)
        Me.TabPage1.TabIndex = 3
        Me.TabPage1.Text = "Informe Recocido "
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'btn_excel
        '
        Me.btn_excel.Image = Global.Spic.My.Resources.Resources.excel10
        Me.btn_excel.Location = New System.Drawing.Point(0, 0)
        Me.btn_excel.Name = "btn_excel"
        Me.btn_excel.Size = New System.Drawing.Size(40, 42)
        Me.btn_excel.TabIndex = 2
        Me.btn_excel.UseVisualStyleBackColor = True
        '
        'btn_consultar_nC
        '
        Me.btn_consultar_nC.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_consultar_nC.Image = Global.Spic.My.Resources.Resources.ficha
        Me.btn_consultar_nC.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_consultar_nC.Location = New System.Drawing.Point(258, 23)
        Me.btn_consultar_nC.Name = "btn_consultar_nC"
        Me.btn_consultar_nC.Size = New System.Drawing.Size(123, 56)
        Me.btn_consultar_nC.TabIndex = 1
        Me.btn_consultar_nC.Text = "Consultar"
        Me.btn_consultar_nC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_consultar_nC.UseVisualStyleBackColor = True
        '
        'dtg_consulta
        '
        Me.dtg_consulta.AllowUserToAddRows = False
        Me.dtg_consulta.AllowUserToDeleteRows = False
        Me.dtg_consulta.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtg_consulta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dtg_consulta.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dtg_consulta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtg_consulta.Location = New System.Drawing.Point(6, 93)
        Me.dtg_consulta.Name = "dtg_consulta"
        Me.dtg_consulta.ReadOnly = True
        Me.dtg_consulta.RowHeadersVisible = False
        Me.dtg_consulta.Size = New System.Drawing.Size(685, 453)
        Me.dtg_consulta.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cbo_ano_op)
        Me.GroupBox2.Controls.Add(Me.cbo_mes_op)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(46, 6)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(206, 81)
        Me.GroupBox2.TabIndex = 10
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Fecha Orden de Produccion "
        '
        'cbo_ano_op
        '
        Me.cbo_ano_op.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_ano_op.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_ano_op.FormattingEnabled = True
        Me.cbo_ano_op.Location = New System.Drawing.Point(51, 50)
        Me.cbo_ano_op.Name = "cbo_ano_op"
        Me.cbo_ano_op.Size = New System.Drawing.Size(110, 21)
        Me.cbo_ano_op.TabIndex = 3
        '
        'cbo_mes_op
        '
        Me.cbo_mes_op.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_mes_op.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_mes_op.FormattingEnabled = True
        Me.cbo_mes_op.Location = New System.Drawing.Point(50, 17)
        Me.cbo_mes_op.Name = "cbo_mes_op"
        Me.cbo_mes_op.Size = New System.Drawing.Size(111, 21)
        Me.cbo_mes_op.TabIndex = 2
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(10, 51)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(35, 15)
        Me.Label15.TabIndex = 1
        Me.Label15.Text = "Año:"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(6, 17)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(38, 15)
        Me.Label16.TabIndex = 0
        Me.Label16.Text = "Mes:"
        '
        'frm_recocido_calidad
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(704, 583)
        Me.Controls.Add(Me.tbl_calidad_rec)
        Me.Name = "frm_recocido_calidad"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Calidad - Recocido"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.tbl_calidad_rec.ResumeLayout(False)
        Me.p_orden_prod.ResumeLayout(False)
        Me.GroupClientes.ResumeLayout(False)
        Me.GroupClientes.PerformLayout()
        CType(Me.dgt_cliente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtg_orden_prod, System.ComponentModel.ISupportInitialize).EndInit()
        Me.group_filtro.ResumeLayout(False)
        Me.group_filtro.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.p_detalle.ResumeLayout(False)
        Me.p_detalle.PerformLayout()
        Me.group_no_conforme.ResumeLayout(False)
        Me.group_no_conforme.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.group_opciones.ResumeLayout(False)
        Me.group_opciones.PerformLayout()
        CType(Me.dtg_rollo_orden, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtg_detall_orden, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage1.ResumeLayout(False)
        CType(Me.dtg_consulta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tbl_calidad_rec As System.Windows.Forms.TabControl
    Friend WithEvents p_orden_prod As System.Windows.Forms.TabPage
    Friend WithEvents dtg_orden_prod As System.Windows.Forms.DataGridView
    Friend WithEvents group_filtro As System.Windows.Forms.GroupBox
    Friend WithEvents p_detalle As System.Windows.Forms.TabPage
    Friend WithEvents dtg_rollo_orden As System.Windows.Forms.DataGridView
    Friend WithEvents dtg_detall_orden As System.Windows.Forms.DataGridView
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txt_cliente As System.Windows.Forms.TextBox
    Friend WithEvents txt_codigo As System.Windows.Forms.TextBox
    Friend WithEvents txt_orden As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cbo_ano_filtro As System.Windows.Forms.ComboBox
    Friend WithEvents cbo_mes_filtro As System.Windows.Forms.ComboBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents btn_consultar As System.Windows.Forms.Button
    Friend WithEvents col_ver As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents GroupClientes As System.Windows.Forms.GroupBox
    Friend WithEvents Label68 As System.Windows.Forms.Label
    Friend WithEvents Label67 As System.Windows.Forms.Label
    Friend WithEvents txtClienteB As System.Windows.Forms.TextBox
    Friend WithEvents txtnitB As System.Windows.Forms.TextBox
    Friend WithEvents btn_cerrar_clientes As System.Windows.Forms.Button
    Friend WithEvents dgt_cliente As System.Windows.Forms.DataGridView
    Friend WithEvents brnSelectCli As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents group_opciones As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_consecutivo As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txt_cantidad As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txt_nombre_prod As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txt_prod_final As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txt_nombre_cliente As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lbl_detalle As System.Windows.Forms.Label
    Friend WithEvents Label90 As System.Windows.Forms.Label
    Friend WithEvents col_rollos As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents btn_registrar_rollo As System.Windows.Forms.Button
    Friend WithEvents btn_bache_conforme As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents btn_excel As System.Windows.Forms.Button
    Friend WithEvents btn_consultar_nC As System.Windows.Forms.Button
    Friend WithEvents dtg_consulta As System.Windows.Forms.DataGridView
    Friend WithEvents group_no_conforme As System.Windows.Forms.GroupBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Btn_registrar_rollo_nc As System.Windows.Forms.Button
    Friend WithEvents lbl_peso As System.Windows.Forms.Label
    Friend WithEvents lbl_codigo As System.Windows.Forms.Label
    Friend WithEvents lbl_nombre As System.Windows.Forms.Label
    Friend WithEvents txt_lecto As System.Windows.Forms.TextBox
    Friend WithEvents txt_nota As System.Windows.Forms.TextBox
    Friend WithEvents cbo_defecto As System.Windows.Forms.ComboBox
    Friend WithEvents cbo_operario As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cbo_ano_op As System.Windows.Forms.ComboBox
    Friend WithEvents cbo_mes_op As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
End Class
