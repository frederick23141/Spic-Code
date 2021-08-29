<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSegVendAct
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSegVendAct))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.Toolbar1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btn_salir = New System.Windows.Forms.ToolStripButton()
        Me.btn_ppal = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.btn_exportar = New System.Windows.Forms.ToolStripSplitButton()
        Me.btn_export_seg = New System.Windows.Forms.ToolStripMenuItem()
        Me.btn_export_dtalle = New System.Windows.Forms.ToolStripMenuItem()
        Me.btn_consultas = New System.Windows.Forms.ToolStripSplitButton()
        Me.SeguimientoPresupeustoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AnticiposToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnRefNoClas = New System.Windows.Forms.ToolStripButton()
        Me.btnContCambios = New System.Windows.Forms.ToolStripButton()
        Me.btnConfigPermisos = New System.Windows.Forms.ToolStripButton()
        Me.imgProcesar = New System.Windows.Forms.PictureBox()
        Me.dtgSegVend = New System.Windows.Forms.DataGridView()
        Me.Vendedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Ventas = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Pres_Ventas = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Pend = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.No_reflej = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Rec = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAnt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Pres_rec = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Dev = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.chequesDev = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_debe_llevar_vtas = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_porc_hoy_vtas = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.porCumVtas = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_debe_llevar_rec = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_porc_hoy_rec = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.porCumRec = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.porDev = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Por_util = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.menStripDtg = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.itemMasInfo = New System.Windows.Forms.ToolStripMenuItem()
        Me.itemGrafic = New System.Windows.Forms.ToolStripMenuItem()
        Me.VentasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RecaudosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.dtgDetalle = New System.Windows.Forms.DataGridView()
        Me.txtPendRec = New System.Windows.Forms.TextBox()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.txtPendVtas = New System.Windows.Forms.TextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.chk_inter = New System.Windows.Forms.CheckBox()
        Me.ChkPesos = New System.Windows.Forms.CheckBox()
        Me.chkKil = New System.Windows.Forms.CheckBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.btnConsultar = New System.Windows.Forms.Button()
        Me.cboMes = New System.Windows.Forms.ComboBox()
        Me.cboAño = New System.Windows.Forms.ComboBox()
        Me.groupPermisos = New System.Windows.Forms.GroupBox()
        Me.btnQuitarCol = New System.Windows.Forms.Button()
        Me.btnAddColumna = New System.Windows.Forms.Button()
        Me.listColumnas = New System.Windows.Forms.ListBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.listPermisosUsuario = New System.Windows.Forms.ListBox()
        Me.listaTipoUsu = New System.Windows.Forms.ListBox()
        Me.btnOcultPermisos = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.lbl_dias_habiles = New System.Windows.Forms.Label()
        Me.lbl_dias_trab = New System.Windows.Forms.Label()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Toolbar1.SuspendLayout()
        CType(Me.imgProcesar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtgSegVend, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.menStripDtg.SuspendLayout()
        CType(Me.dtgDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.groupPermisos.SuspendLayout()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Toolbar1
        '
        Me.Toolbar1.AutoSize = False
        Me.Toolbar1.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.Toolbar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Toolbar1.ImageScalingSize = New System.Drawing.Size(23, 23)
        Me.Toolbar1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator2, Me.btn_salir, Me.btn_ppal, Me.ToolStripSeparator3, Me.btn_exportar, Me.btn_consultas, Me.btnRefNoClas, Me.btnContCambios, Me.btnConfigPermisos})
        Me.Toolbar1.Location = New System.Drawing.Point(0, 0)
        Me.Toolbar1.Name = "Toolbar1"
        Me.Toolbar1.Size = New System.Drawing.Size(779, 24)
        Me.Toolbar1.TabIndex = 1028
        Me.Toolbar1.Text = "ToolStrip1"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 24)
        '
        'btn_salir
        '
        Me.btn_salir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_salir.Image = Global.Spic.My.Resources.Resources._1349388328_door_in
        Me.btn_salir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_salir.Name = "btn_salir"
        Me.btn_salir.Size = New System.Drawing.Size(27, 21)
        Me.btn_salir.Text = "ToolStripButton1"
        Me.btn_salir.ToolTipText = "Salir"
        '
        'btn_ppal
        '
        Me.btn_ppal.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_ppal.Image = Global.Spic.My.Resources.Resources.ppal3
        Me.btn_ppal.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_ppal.Name = "btn_ppal"
        Me.btn_ppal.Size = New System.Drawing.Size(27, 21)
        Me.btn_ppal.Text = "ToolStripButton2"
        Me.btn_ppal.ToolTipText = "Menú principal"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 24)
        '
        'btn_exportar
        '
        Me.btn_exportar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_exportar.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btn_export_seg, Me.btn_export_dtalle})
        Me.btn_exportar.Image = Global.Spic.My.Resources.Resources.excel
        Me.btn_exportar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_exportar.Name = "btn_exportar"
        Me.btn_exportar.Size = New System.Drawing.Size(39, 21)
        Me.btn_exportar.Text = "Graficar"
        Me.btn_exportar.ToolTipText = "Exportar a excel"
        '
        'btn_export_seg
        '
        Me.btn_export_seg.AutoSize = False
        Me.btn_export_seg.Image = Global.Spic.My.Resources.Resources.excel
        Me.btn_export_seg.Name = "btn_export_seg"
        Me.btn_export_seg.Size = New System.Drawing.Size(159, 30)
        Me.btn_export_seg.Text = "Seguimiento"
        '
        'btn_export_dtalle
        '
        Me.btn_export_dtalle.Image = Global.Spic.My.Resources.Resources.excel
        Me.btn_export_dtalle.Name = "btn_export_dtalle"
        Me.btn_export_dtalle.Size = New System.Drawing.Size(141, 22)
        Me.btn_export_dtalle.Text = "Detalle"
        '
        'btn_consultas
        '
        Me.btn_consultas.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_consultas.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SeguimientoPresupeustoToolStripMenuItem, Me.AnticiposToolStripMenuItem1})
        Me.btn_consultas.Image = Global.Spic.My.Resources.Resources.busc
        Me.btn_consultas.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_consultas.Name = "btn_consultas"
        Me.btn_consultas.Size = New System.Drawing.Size(39, 21)
        Me.btn_consultas.Text = "Consultas"
        '
        'SeguimientoPresupeustoToolStripMenuItem
        '
        Me.SeguimientoPresupeustoToolStripMenuItem.Image = Global.Spic.My.Resources.Resources.money4
        Me.SeguimientoPresupeustoToolStripMenuItem.Name = "SeguimientoPresupeustoToolStripMenuItem"
        Me.SeguimientoPresupeustoToolStripMenuItem.Size = New System.Drawing.Size(209, 22)
        Me.SeguimientoPresupeustoToolStripMenuItem.Text = "Seguimiento presupeusto"
        '
        'AnticiposToolStripMenuItem1
        '
        Me.AnticiposToolStripMenuItem1.Image = Global.Spic.My.Resources.Resources.money4
        Me.AnticiposToolStripMenuItem1.Name = "AnticiposToolStripMenuItem1"
        Me.AnticiposToolStripMenuItem1.Size = New System.Drawing.Size(209, 22)
        Me.AnticiposToolStripMenuItem1.Text = "Anticipos"
        '
        'btnRefNoClas
        '
        Me.btnRefNoClas.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnRefNoClas.Image = CType(resources.GetObject("btnRefNoClas.Image"), System.Drawing.Image)
        Me.btnRefNoClas.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnRefNoClas.Name = "btnRefNoClas"
        Me.btnRefNoClas.Size = New System.Drawing.Size(27, 21)
        Me.btnRefNoClas.Text = "Referencias no clasificadas"
        '
        'btnContCambios
        '
        Me.btnContCambios.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnContCambios.Image = Global.Spic.My.Resources.Resources.info1
        Me.btnContCambios.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnContCambios.Name = "btnContCambios"
        Me.btnContCambios.Size = New System.Drawing.Size(27, 21)
        Me.btnContCambios.Text = "Control de cambios"
        '
        'btnConfigPermisos
        '
        Me.btnConfigPermisos.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnConfigPermisos.Image = Global.Spic.My.Resources.Resources.tool
        Me.btnConfigPermisos.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnConfigPermisos.Name = "btnConfigPermisos"
        Me.btnConfigPermisos.Size = New System.Drawing.Size(27, 21)
        Me.btnConfigPermisos.Text = "Configurar permisos"
        '
        'imgProcesar
        '
        Me.imgProcesar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.imgProcesar.Image = Global.Spic.My.Resources.Resources.procesando
        Me.imgProcesar.Location = New System.Drawing.Point(143, 135)
        Me.imgProcesar.Name = "imgProcesar"
        Me.imgProcesar.Size = New System.Drawing.Size(512, 298)
        Me.imgProcesar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgProcesar.TabIndex = 1030
        Me.imgProcesar.TabStop = False
        '
        'dtgSegVend
        '
        Me.dtgSegVend.AllowUserToAddRows = False
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        Me.dtgSegVend.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dtgSegVend.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtgSegVend.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dtgSegVend.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dtgSegVend.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgSegVend.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dtgSegVend.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgSegVend.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Vendedor, Me.Ventas, Me.Pres_Ventas, Me.Pend, Me.No_reflej, Me.Rec, Me.colAnt, Me.Pres_rec, Me.Dev, Me.chequesDev, Me.col_debe_llevar_vtas, Me.col_porc_hoy_vtas, Me.porCumVtas, Me.col_debe_llevar_rec, Me.col_porc_hoy_rec, Me.porCumRec, Me.porDev, Me.Por_util})
        Me.dtgSegVend.ContextMenuStrip = Me.menStripDtg
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!)
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle11.Format = "N0"
        DataGridViewCellStyle11.NullValue = "0"
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtgSegVend.DefaultCellStyle = DataGridViewCellStyle11
        Me.dtgSegVend.Location = New System.Drawing.Point(2, 46)
        Me.dtgSegVend.Name = "dtgSegVend"
        Me.dtgSegVend.ReadOnly = True
        Me.dtgSegVend.RowHeadersVisible = False
        Me.dtgSegVend.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtgSegVend.Size = New System.Drawing.Size(776, 427)
        Me.dtgSegVend.TabIndex = 1037
        '
        'Vendedor
        '
        Me.Vendedor.Frozen = True
        Me.Vendedor.HeaderText = "Vend"
        Me.Vendedor.Name = "Vendedor"
        Me.Vendedor.ReadOnly = True
        Me.Vendedor.Width = 57
        '
        'Ventas
        '
        Me.Ventas.HeaderText = "Ventas"
        Me.Ventas.Name = "Ventas"
        Me.Ventas.ReadOnly = True
        Me.Ventas.Width = 65
        '
        'Pres_Ventas
        '
        Me.Pres_Ventas.HeaderText = "Pres_Ventas"
        Me.Pres_Ventas.Name = "Pres_Ventas"
        Me.Pres_Ventas.ReadOnly = True
        Me.Pres_Ventas.Width = 92
        '
        'Pend
        '
        Me.Pend.HeaderText = "Pend"
        Me.Pend.Name = "Pend"
        Me.Pend.ReadOnly = True
        Me.Pend.Width = 57
        '
        'No_reflej
        '
        Me.No_reflej.HeaderText = "No_reflej"
        Me.No_reflej.Name = "No_reflej"
        Me.No_reflej.ReadOnly = True
        Me.No_reflej.Width = 73
        '
        'Rec
        '
        Me.Rec.HeaderText = "Rec"
        Me.Rec.Name = "Rec"
        Me.Rec.ReadOnly = True
        Me.Rec.Width = 50
        '
        'colAnt
        '
        Me.colAnt.HeaderText = "Anticipos"
        Me.colAnt.Name = "colAnt"
        Me.colAnt.ReadOnly = True
        Me.colAnt.Width = 74
        '
        'Pres_rec
        '
        Me.Pres_rec.HeaderText = "Pres_rec"
        Me.Pres_rec.Name = "Pres_rec"
        Me.Pres_rec.ReadOnly = True
        Me.Pres_rec.Width = 73
        '
        'Dev
        '
        Me.Dev.HeaderText = "Dev"
        Me.Dev.Name = "Dev"
        Me.Dev.ReadOnly = True
        Me.Dev.Width = 52
        '
        'chequesDev
        '
        Me.chequesDev.HeaderText = "chequesDev"
        Me.chequesDev.Name = "chequesDev"
        Me.chequesDev.ReadOnly = True
        Me.chequesDev.Width = 92
        '
        'col_debe_llevar_vtas
        '
        DataGridViewCellStyle3.Format = "N0"
        Me.col_debe_llevar_vtas.DefaultCellStyle = DataGridViewCellStyle3
        Me.col_debe_llevar_vtas.HeaderText = "debe_llevar_vtas"
        Me.col_debe_llevar_vtas.Name = "col_debe_llevar_vtas"
        Me.col_debe_llevar_vtas.ReadOnly = True
        Me.col_debe_llevar_vtas.Width = 113
        '
        'col_porc_hoy_vtas
        '
        DataGridViewCellStyle4.Format = "N2"
        DataGridViewCellStyle4.NullValue = "0"
        Me.col_porc_hoy_vtas.DefaultCellStyle = DataGridViewCellStyle4
        Me.col_porc_hoy_vtas.HeaderText = "%hoyVtas"
        Me.col_porc_hoy_vtas.Name = "col_porc_hoy_vtas"
        Me.col_porc_hoy_vtas.ReadOnly = True
        Me.col_porc_hoy_vtas.Width = 79
        '
        'porCumVtas
        '
        DataGridViewCellStyle5.Format = "N2"
        Me.porCumVtas.DefaultCellStyle = DataGridViewCellStyle5
        Me.porCumVtas.HeaderText = "%Cvtas"
        Me.porCumVtas.Name = "porCumVtas"
        Me.porCumVtas.ReadOnly = True
        Me.porCumVtas.Width = 68
        '
        'col_debe_llevar_rec
        '
        DataGridViewCellStyle6.Format = "N0"
        Me.col_debe_llevar_rec.DefaultCellStyle = DataGridViewCellStyle6
        Me.col_debe_llevar_rec.HeaderText = "debe_llevar_rec"
        Me.col_debe_llevar_rec.Name = "col_debe_llevar_rec"
        Me.col_debe_llevar_rec.ReadOnly = True
        Me.col_debe_llevar_rec.Width = 107
        '
        'col_porc_hoy_rec
        '
        DataGridViewCellStyle7.Format = "N2"
        DataGridViewCellStyle7.NullValue = "0"
        Me.col_porc_hoy_rec.DefaultCellStyle = DataGridViewCellStyle7
        Me.col_porc_hoy_rec.HeaderText = "%hoyRec"
        Me.col_porc_hoy_rec.Name = "col_porc_hoy_rec"
        Me.col_porc_hoy_rec.ReadOnly = True
        Me.col_porc_hoy_rec.Width = 76
        '
        'porCumRec
        '
        DataGridViewCellStyle8.Format = "N2"
        Me.porCumRec.DefaultCellStyle = DataGridViewCellStyle8
        Me.porCumRec.HeaderText = "%C_rec"
        Me.porCumRec.Name = "porCumRec"
        Me.porCumRec.ReadOnly = True
        Me.porCumRec.Width = 68
        '
        'porDev
        '
        DataGridViewCellStyle9.Format = "N2"
        Me.porDev.DefaultCellStyle = DataGridViewCellStyle9
        Me.porDev.HeaderText = "%Dev"
        Me.porDev.Name = "porDev"
        Me.porDev.ReadOnly = True
        Me.porDev.Width = 61
        '
        'Por_util
        '
        DataGridViewCellStyle10.Format = "N2"
        Me.Por_util.DefaultCellStyle = DataGridViewCellStyle10
        Me.Por_util.HeaderText = "%util"
        Me.Por_util.Name = "Por_util"
        Me.Por_util.ReadOnly = True
        Me.Por_util.Width = 54
        '
        'menStripDtg
        '
        Me.menStripDtg.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.menStripDtg.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.itemMasInfo, Me.itemGrafic})
        Me.menStripDtg.Name = "ContextMenuStrip1"
        Me.menStripDtg.Size = New System.Drawing.Size(136, 48)
        '
        'itemMasInfo
        '
        Me.itemMasInfo.Image = Global.Spic.My.Resources.Resources.buscar7
        Me.itemMasInfo.Name = "itemMasInfo"
        Me.itemMasInfo.Size = New System.Drawing.Size(135, 22)
        Me.itemMasInfo.Text = "Ver detalle"
        '
        'itemGrafic
        '
        Me.itemGrafic.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.VentasToolStripMenuItem, Me.RecaudosToolStripMenuItem})
        Me.itemGrafic.Image = Global.Spic.My.Resources.Resources.grafic2
        Me.itemGrafic.Name = "itemGrafic"
        Me.itemGrafic.Size = New System.Drawing.Size(135, 22)
        Me.itemGrafic.Text = "Graficar"
        '
        'VentasToolStripMenuItem
        '
        Me.VentasToolStripMenuItem.Image = Global.Spic.My.Resources.Resources.est
        Me.VentasToolStripMenuItem.Name = "VentasToolStripMenuItem"
        Me.VentasToolStripMenuItem.Size = New System.Drawing.Size(129, 22)
        Me.VentasToolStripMenuItem.Text = "Ventas"
        '
        'RecaudosToolStripMenuItem
        '
        Me.RecaudosToolStripMenuItem.Image = Global.Spic.My.Resources.Resources.est
        Me.RecaudosToolStripMenuItem.Name = "RecaudosToolStripMenuItem"
        Me.RecaudosToolStripMenuItem.Size = New System.Drawing.Size(129, 22)
        Me.RecaudosToolStripMenuItem.Text = "Recaudos"
        '
        'dtgDetalle
        '
        DataGridViewCellStyle12.BackColor = System.Drawing.Color.LightGray
        DataGridViewCellStyle12.NullValue = Nothing
        Me.dtgDetalle.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle12
        Me.dtgDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtgDetalle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dtgDetalle.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dtgDetalle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle13.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle13.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle13.Format = "N0"
        DataGridViewCellStyle13.NullValue = Nothing
        DataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgDetalle.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle13
        Me.dtgDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.25!)
        DataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle14.Format = "N0"
        DataGridViewCellStyle14.NullValue = Nothing
        DataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtgDetalle.DefaultCellStyle = DataGridViewCellStyle14
        Me.dtgDetalle.Location = New System.Drawing.Point(2, 475)
        Me.dtgDetalle.Name = "dtgDetalle"
        Me.dtgDetalle.ReadOnly = True
        Me.dtgDetalle.RowHeadersVisible = False
        Me.dtgDetalle.Size = New System.Drawing.Size(775, 64)
        Me.dtgDetalle.TabIndex = 1035
        '
        'txtPendRec
        '
        Me.txtPendRec.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPendRec.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.txtPendRec.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPendRec.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPendRec.Location = New System.Drawing.Point(612, 364)
        Me.txtPendRec.Name = "txtPendRec"
        Me.txtPendRec.Size = New System.Drawing.Size(0, 20)
        Me.txtPendRec.TabIndex = 1034
        Me.txtPendRec.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtPendRec.Visible = False
        '
        'TextBox4
        '
        Me.TextBox4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox4.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.TextBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox4.Location = New System.Drawing.Point(510, 364)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(0, 20)
        Me.TextBox4.TabIndex = 1033
        Me.TextBox4.Text = "Pendientes Rec"
        Me.TextBox4.Visible = False
        '
        'txtPendVtas
        '
        Me.txtPendVtas.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPendVtas.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.txtPendVtas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPendVtas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPendVtas.Location = New System.Drawing.Point(318, 364)
        Me.txtPendVtas.Name = "txtPendVtas"
        Me.txtPendVtas.Size = New System.Drawing.Size(0, 20)
        Me.txtPendVtas.TabIndex = 1032
        Me.txtPendVtas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtPendVtas.Visible = False
        '
        'TextBox1
        '
        Me.TextBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox1.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(219, 364)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(0, 20)
        Me.TextBox1.TabIndex = 1031
        Me.TextBox1.Text = "Pendientes Vtas"
        Me.TextBox1.Visible = False
        '
        'chk_inter
        '
        Me.chk_inter.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chk_inter.AutoSize = True
        Me.chk_inter.BackColor = System.Drawing.Color.Transparent
        Me.chk_inter.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_inter.Location = New System.Drawing.Point(327, 28)
        Me.chk_inter.Name = "chk_inter"
        Me.chk_inter.Size = New System.Drawing.Size(117, 17)
        Me.chk_inter.TabIndex = 124
        Me.chk_inter.Text = "Incluir internacional"
        Me.chk_inter.UseVisualStyleBackColor = False
        Me.chk_inter.Visible = False
        '
        'ChkPesos
        '
        Me.ChkPesos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChkPesos.AutoSize = True
        Me.ChkPesos.BackColor = System.Drawing.Color.Transparent
        Me.ChkPesos.Checked = True
        Me.ChkPesos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkPesos.Location = New System.Drawing.Point(230, 28)
        Me.ChkPesos.Name = "ChkPesos"
        Me.ChkPesos.Size = New System.Drawing.Size(55, 17)
        Me.ChkPesos.TabIndex = 123
        Me.ChkPesos.Text = "Pesos"
        Me.ChkPesos.UseVisualStyleBackColor = False
        '
        'chkKil
        '
        Me.chkKil.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkKil.AutoSize = True
        Me.chkKil.BackColor = System.Drawing.Color.Transparent
        Me.chkKil.Location = New System.Drawing.Point(282, 28)
        Me.chkKil.Name = "chkKil"
        Me.chkKil.Size = New System.Drawing.Size(48, 17)
        Me.chkKil.TabIndex = 122
        Me.chkKil.Text = "Kilos"
        Me.chkKil.UseVisualStyleBackColor = False
        '
        'Label37
        '
        Me.Label37.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label37.AutoSize = True
        Me.Label37.BackColor = System.Drawing.Color.Transparent
        Me.Label37.Location = New System.Drawing.Point(117, 27)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(29, 13)
        Me.Label37.TabIndex = 44
        Me.Label37.Text = "Año:"
        '
        'Label30
        '
        Me.Label30.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label30.AutoSize = True
        Me.Label30.BackColor = System.Drawing.Color.Transparent
        Me.Label30.Location = New System.Drawing.Point(3, 27)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(30, 13)
        Me.Label30.TabIndex = 41
        Me.Label30.Text = "Mes:"
        '
        'btnConsultar
        '
        Me.btnConsultar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConsultar.Image = Global.Spic.My.Resources.Resources.buscar7
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConsultar.Location = New System.Drawing.Point(459, 23)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(80, 23)
        Me.btnConsultar.TabIndex = 121
        Me.btnConsultar.Text = "Consultar"
        Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'cboMes
        '
        Me.cboMes.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMes.FormattingEnabled = True
        Me.cboMes.Items.AddRange(New Object() {"Enero ", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"})
        Me.cboMes.Location = New System.Drawing.Point(35, 25)
        Me.cboMes.Name = "cboMes"
        Me.cboMes.Size = New System.Drawing.Size(80, 20)
        Me.cboMes.TabIndex = 34
        '
        'cboAño
        '
        Me.cboAño.FormattingEnabled = True
        Me.cboAño.Location = New System.Drawing.Point(148, 24)
        Me.cboAño.Name = "cboAño"
        Me.cboAño.Size = New System.Drawing.Size(72, 21)
        Me.cboAño.TabIndex = 35
        '
        'groupPermisos
        '
        Me.groupPermisos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.groupPermisos.Controls.Add(Me.btnQuitarCol)
        Me.groupPermisos.Controls.Add(Me.btnAddColumna)
        Me.groupPermisos.Controls.Add(Me.listColumnas)
        Me.groupPermisos.Controls.Add(Me.Label6)
        Me.groupPermisos.Controls.Add(Me.Label7)
        Me.groupPermisos.Controls.Add(Me.listPermisosUsuario)
        Me.groupPermisos.Controls.Add(Me.listaTipoUsu)
        Me.groupPermisos.Controls.Add(Me.btnOcultPermisos)
        Me.groupPermisos.Controls.Add(Me.Label8)
        Me.groupPermisos.Location = New System.Drawing.Point(111, 55)
        Me.groupPermisos.Name = "groupPermisos"
        Me.groupPermisos.Size = New System.Drawing.Size(622, 444)
        Me.groupPermisos.TabIndex = 1088
        Me.groupPermisos.TabStop = False
        Me.groupPermisos.Text = "Configurar permisos"
        Me.groupPermisos.Visible = False
        '
        'btnQuitarCol
        '
        Me.btnQuitarCol.Image = Global.Spic.My.Resources.Resources._1371750041_14125
        Me.btnQuitarCol.Location = New System.Drawing.Point(368, 233)
        Me.btnQuitarCol.Name = "btnQuitarCol"
        Me.btnQuitarCol.Size = New System.Drawing.Size(37, 26)
        Me.btnQuitarCol.TabIndex = 1070
        Me.btnQuitarCol.UseVisualStyleBackColor = True
        '
        'btnAddColumna
        '
        Me.btnAddColumna.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddColumna.Location = New System.Drawing.Point(369, 201)
        Me.btnAddColumna.Name = "btnAddColumna"
        Me.btnAddColumna.Size = New System.Drawing.Size(37, 26)
        Me.btnAddColumna.TabIndex = 1069
        Me.btnAddColumna.Text = "<<"
        Me.btnAddColumna.UseVisualStyleBackColor = True
        '
        'listColumnas
        '
        Me.listColumnas.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.listColumnas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.listColumnas.FormattingEnabled = True
        Me.listColumnas.ItemHeight = 16
        Me.listColumnas.Location = New System.Drawing.Point(412, 39)
        Me.listColumnas.Name = "listColumnas"
        Me.listColumnas.Size = New System.Drawing.Size(180, 388)
        Me.listColumnas.TabIndex = 1068
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(189, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(123, 13)
        Me.Label6.TabIndex = 1067
        Me.Label6.Text = "Permisos del usuario"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(9, 16)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(95, 13)
        Me.Label7.TabIndex = 1066
        Me.Label7.Text = "Tipo de usuario"
        '
        'listPermisosUsuario
        '
        Me.listPermisosUsuario.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.listPermisosUsuario.FormattingEnabled = True
        Me.listPermisosUsuario.Items.AddRange(New Object() {""})
        Me.listPermisosUsuario.Location = New System.Drawing.Point(190, 39)
        Me.listPermisosUsuario.Name = "listPermisosUsuario"
        Me.listPermisosUsuario.Size = New System.Drawing.Size(172, 394)
        Me.listPermisosUsuario.TabIndex = 1065
        '
        'listaTipoUsu
        '
        Me.listaTipoUsu.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.listaTipoUsu.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.listaTipoUsu.FormattingEnabled = True
        Me.listaTipoUsu.ItemHeight = 16
        Me.listaTipoUsu.Location = New System.Drawing.Point(9, 39)
        Me.listaTipoUsu.Name = "listaTipoUsu"
        Me.listaTipoUsu.Size = New System.Drawing.Size(175, 388)
        Me.listaTipoUsu.TabIndex = 1064
        '
        'btnOcultPermisos
        '
        Me.btnOcultPermisos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOcultPermisos.ForeColor = System.Drawing.Color.Red
        Me.btnOcultPermisos.Location = New System.Drawing.Point(584, 0)
        Me.btnOcultPermisos.Name = "btnOcultPermisos"
        Me.btnOcultPermisos.Size = New System.Drawing.Size(37, 23)
        Me.btnOcultPermisos.TabIndex = 1063
        Me.btnOcultPermisos.Text = "X"
        Me.btnOcultPermisos.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(409, 16)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(73, 13)
        Me.Label8.TabIndex = 1071
        Me.Label8.Text = "Información"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(737, 4)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 13)
        Me.Label3.TabIndex = 1098
        Me.Label3.Text = "Bueno"
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(646, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 13)
        Me.Label1.TabIndex = 1097
        Me.Label1.Text = "Estable"
        '
        'TextBox3
        '
        Me.TextBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox3.BackColor = System.Drawing.Color.Yellow
        Me.TextBox3.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox3.Location = New System.Drawing.Point(606, 4)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.ReadOnly = True
        Me.TextBox3.Size = New System.Drawing.Size(37, 13)
        Me.TextBox3.TabIndex = 1096
        Me.TextBox3.Text = "95 - 99"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(557, 4)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 13)
        Me.Label2.TabIndex = 1095
        Me.Label2.Text = "Alerta"
        '
        'TextBox2
        '
        Me.TextBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox2.BackColor = System.Drawing.Color.Red
        Me.TextBox2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox2.Location = New System.Drawing.Point(508, 4)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ReadOnly = True
        Me.TextBox2.Size = New System.Drawing.Size(51, 13)
        Me.TextBox2.TabIndex = 1094
        Me.TextBox2.Text = "Menos 95"
        '
        'TextBox5
        '
        Me.TextBox5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox5.BackColor = System.Drawing.Color.GreenYellow
        Me.TextBox5.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox5.Location = New System.Drawing.Point(693, 4)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.ReadOnly = True
        Me.TextBox5.Size = New System.Drawing.Size(44, 13)
        Me.TextBox5.TabIndex = 1093
        Me.TextBox5.Text = "Más 100"
        '
        'lbl_dias_habiles
        '
        Me.lbl_dias_habiles.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_dias_habiles.AutoSize = True
        Me.lbl_dias_habiles.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_dias_habiles.Location = New System.Drawing.Point(267, 4)
        Me.lbl_dias_habiles.Name = "lbl_dias_habiles"
        Me.lbl_dias_habiles.Size = New System.Drawing.Size(69, 13)
        Me.lbl_dias_habiles.TabIndex = 1099
        Me.lbl_dias_habiles.Text = "Días habiles:"
        '
        'lbl_dias_trab
        '
        Me.lbl_dias_trab.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_dias_trab.AutoSize = True
        Me.lbl_dias_trab.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_dias_trab.Location = New System.Drawing.Point(374, 4)
        Me.lbl_dias_trab.Name = "lbl_dias_trab"
        Me.lbl_dias_trab.Size = New System.Drawing.Size(85, 13)
        Me.lbl_dias_trab.TabIndex = 1100
        Me.lbl_dias_trab.Text = "Días trabajados:"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.LinkColor = System.Drawing.Color.Red
        Me.LinkLabel1.Location = New System.Drawing.Point(557, 27)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(115, 13)
        Me.LinkLabel1.TabIndex = 1105
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Productos sin clasificar"
        '
        'Chart1
        '
        Me.Chart1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Chart1.BackColor = System.Drawing.Color.Silver
        Me.Chart1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom
        Me.Chart1.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash
        ChartArea1.BorderWidth = 100
        ChartArea1.Name = "ChartArea1"
        Me.Chart1.ChartAreas.Add(ChartArea1)
        Legend1.Name = "Legend1"
        Me.Chart1.Legends.Add(Legend1)
        Me.Chart1.Location = New System.Drawing.Point(21, 87)
        Me.Chart1.Name = "Chart1"
        Series1.ChartArea = "ChartArea1"
        Series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
        Series1.Legend = "Legend1"
        Series1.Name = "Series1"
        Me.Chart1.Series.Add(Series1)
        Me.Chart1.Size = New System.Drawing.Size(736, 366)
        Me.Chart1.TabIndex = 1107
        Me.Chart1.Text = "Chart1"
        Me.Chart1.Visible = False
        '
        'FrmSegVendAct
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(779, 541)
        Me.Controls.Add(Me.groupPermisos)
        Me.Controls.Add(Me.Chart1)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.btnConsultar)
        Me.Controls.Add(Me.chk_inter)
        Me.Controls.Add(Me.chkKil)
        Me.Controls.Add(Me.ChkPesos)
        Me.Controls.Add(Me.lbl_dias_trab)
        Me.Controls.Add(Me.Label37)
        Me.Controls.Add(Me.cboAño)
        Me.Controls.Add(Me.lbl_dias_habiles)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.cboMes)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.imgProcesar)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dtgSegVend)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox5)
        Me.Controls.Add(Me.dtgDetalle)
        Me.Controls.Add(Me.txtPendRec)
        Me.Controls.Add(Me.TextBox4)
        Me.Controls.Add(Me.txtPendVtas)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Toolbar1)
        Me.Name = "FrmSegVendAct"
        Me.Text = "Seguimiento vendedores"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Toolbar1.ResumeLayout(False)
        Me.Toolbar1.PerformLayout()
        CType(Me.imgProcesar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtgSegVend, System.ComponentModel.ISupportInitialize).EndInit()
        Me.menStripDtg.ResumeLayout(False)
        CType(Me.dtgDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.groupPermisos.ResumeLayout(False)
        Me.groupPermisos.PerformLayout()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Toolbar1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btn_salir As System.Windows.Forms.ToolStripButton
    Friend WithEvents btn_ppal As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btn_exportar As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents btn_export_seg As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btn_export_dtalle As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btn_consultas As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents SeguimientoPresupeustoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AnticiposToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents imgProcesar As System.Windows.Forms.PictureBox
    Friend WithEvents dtgSegVend As System.Windows.Forms.DataGridView
    Friend WithEvents dtgDetalle As System.Windows.Forms.DataGridView
    Friend WithEvents txtPendRec As System.Windows.Forms.TextBox
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents txtPendVtas As System.Windows.Forms.TextBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents chk_inter As System.Windows.Forms.CheckBox
    Friend WithEvents ChkPesos As System.Windows.Forms.CheckBox
    Friend WithEvents chkKil As System.Windows.Forms.CheckBox
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents btnConsultar As System.Windows.Forms.Button
    Friend WithEvents cboMes As System.Windows.Forms.ComboBox
    Friend WithEvents cboAño As System.Windows.Forms.ComboBox
    Friend WithEvents btnRefNoClas As System.Windows.Forms.ToolStripButton
    Friend WithEvents menStripDtg As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents itemMasInfo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnContCambios As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnConfigPermisos As System.Windows.Forms.ToolStripButton
    Friend WithEvents groupPermisos As System.Windows.Forms.GroupBox
    Friend WithEvents btnQuitarCol As System.Windows.Forms.Button
    Friend WithEvents btnAddColumna As System.Windows.Forms.Button
    Friend WithEvents listColumnas As System.Windows.Forms.ListBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents listPermisosUsuario As System.Windows.Forms.ListBox
    Friend WithEvents listaTipoUsu As System.Windows.Forms.ListBox
    Friend WithEvents btnOcultPermisos As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents Vendedor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Ventas As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Pres_Ventas As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Pend As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents No_reflej As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Rec As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAnt As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Pres_rec As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Dev As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chequesDev As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col_debe_llevar_vtas As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col_porc_hoy_vtas As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents porCumVtas As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col_debe_llevar_rec As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col_porc_hoy_rec As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents porCumRec As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents porDev As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Por_util As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lbl_dias_habiles As System.Windows.Forms.Label
    Friend WithEvents lbl_dias_trab As System.Windows.Forms.Label
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents itemGrafic As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VentasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RecaudosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Chart1 As System.Windows.Forms.DataVisualization.Charting.Chart
End Class
