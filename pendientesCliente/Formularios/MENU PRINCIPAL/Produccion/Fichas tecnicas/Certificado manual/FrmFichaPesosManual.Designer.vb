﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmFichaPesosManual
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
        Me.Toolbar1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btn_salir = New System.Windows.Forms.ToolStripButton()
        Me.btn_ppal = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnGenReporte = New System.Windows.Forms.ToolStripButton()
        Me.txt_num_pedido = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.txtCalidad_est = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtResis_est = New System.Windows.Forms.TextBox()
        Me.txtRec_est = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.txtTotPeso = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.dtgRollos = New System.Windows.Forms.DataGridView()
        Me.colEliminar = New System.Windows.Forms.DataGridViewImageColumn()
        Me.colAdd = New System.Windows.Forms.DataGridViewImageColumn()
        Me.ColNumRollo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColPeso = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.cbo_calidad_real = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txt_rec_real = New System.Windows.Forms.TextBox()
        Me.txt_resis_real = New System.Windows.Forms.TextBox()
        Me.txtMatPrima = New System.Windows.Forms.TextBox()
        Me.cboProcedencia = New System.Windows.Forms.ComboBox()
        Me.txtColada = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.txtNit = New System.Windows.Forms.TextBox()
        Me.lblNit = New System.Windows.Forms.Label()
        Me.txtNombres = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboResponsable = New System.Windows.Forms.ComboBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.cboCoordinador = New System.Windows.Forms.ComboBox()
        Me.groupBox5 = New System.Windows.Forms.GroupBox()
        Me.Toolbar1.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.dtgRollos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.groupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'Toolbar1
        '
        Me.Toolbar1.AutoSize = False
        Me.Toolbar1.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.Toolbar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Toolbar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Toolbar1.ImageScalingSize = New System.Drawing.Size(23, 23)
        Me.Toolbar1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator2, Me.btn_salir, Me.btn_ppal, Me.ToolStripSeparator3, Me.btnGenReporte})
        Me.Toolbar1.Location = New System.Drawing.Point(0, 0)
        Me.Toolbar1.Name = "Toolbar1"
        Me.Toolbar1.Size = New System.Drawing.Size(679, 30)
        Me.Toolbar1.TabIndex = 1030
        Me.Toolbar1.Text = "ToolStrip1"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 30)
        '
        'btn_salir
        '
        Me.btn_salir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_salir.Image = Global.Spic.My.Resources.Resources._1349388328_door_in
        Me.btn_salir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_salir.Name = "btn_salir"
        Me.btn_salir.Size = New System.Drawing.Size(27, 27)
        Me.btn_salir.Text = "ToolStripButton1"
        Me.btn_salir.ToolTipText = "Salir"
        '
        'btn_ppal
        '
        Me.btn_ppal.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_ppal.Image = Global.Spic.My.Resources.Resources.ppal3
        Me.btn_ppal.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_ppal.Name = "btn_ppal"
        Me.btn_ppal.Size = New System.Drawing.Size(27, 27)
        Me.btn_ppal.Text = "ToolStripButton2"
        Me.btn_ppal.ToolTipText = "Menú principal"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 30)
        '
        'btnGenReporte
        '
        Me.btnGenReporte.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnGenReporte.Image = Global.Spic.My.Resources.Resources.ficha
        Me.btnGenReporte.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnGenReporte.Name = "btnGenReporte"
        Me.btnGenReporte.Size = New System.Drawing.Size(27, 27)
        Me.btnGenReporte.Text = "Generar ficha"
        '
        'txt_num_pedido
        '
        Me.txt_num_pedido.Location = New System.Drawing.Point(123, 115)
        Me.txt_num_pedido.MaxLength = 13
        Me.txt_num_pedido.Name = "txt_num_pedido"
        Me.txt_num_pedido.Size = New System.Drawing.Size(110, 20)
        Me.txt_num_pedido.TabIndex = 1061
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Red
        Me.Label12.Location = New System.Drawing.Point(10, 118)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(144, 15)
        Me.Label12.TabIndex = 1060
        Me.Label12.Text = "Número de pedido:"
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.txtCalidad_est)
        Me.GroupBox6.Controls.Add(Me.Label11)
        Me.GroupBox6.Controls.Add(Me.Label13)
        Me.GroupBox6.Controls.Add(Me.Label15)
        Me.GroupBox6.Controls.Add(Me.txtResis_est)
        Me.GroupBox6.Controls.Add(Me.txtRec_est)
        Me.GroupBox6.Location = New System.Drawing.Point(236, 112)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(224, 223)
        Me.GroupBox6.TabIndex = 1056
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Valores dados por ficha (Estandar)"
        '
        'txtCalidad_est
        '
        Me.txtCalidad_est.BackColor = System.Drawing.Color.LightGray
        Me.txtCalidad_est.Location = New System.Drawing.Point(139, 158)
        Me.txtCalidad_est.MaxLength = 13
        Me.txtCalidad_est.Name = "txtCalidad_est"
        Me.txtCalidad_est.ReadOnly = True
        Me.txtCalidad_est.Size = New System.Drawing.Size(79, 20)
        Me.txtCalidad_est.TabIndex = 1042
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(80, 164)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(59, 15)
        Me.Label11.TabIndex = 1043
        Me.Label11.Text = "Calidad:"
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(0, 49)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(139, 15)
        Me.Label13.TabIndex = 1031
        Me.Label13.Text = "Resistencia (kgf/mm2)"
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(0, 111)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(138, 15)
        Me.Label15.TabIndex = 1035
        Me.Label15.Text = "Recubrimiento (g/mm2)"
        '
        'txtResis_est
        '
        Me.txtResis_est.BackColor = System.Drawing.Color.LightGray
        Me.txtResis_est.Location = New System.Drawing.Point(139, 46)
        Me.txtResis_est.MaxLength = 13
        Me.txtResis_est.Name = "txtResis_est"
        Me.txtResis_est.ReadOnly = True
        Me.txtResis_est.Size = New System.Drawing.Size(79, 20)
        Me.txtResis_est.TabIndex = 1032
        '
        'txtRec_est
        '
        Me.txtRec_est.BackColor = System.Drawing.Color.LightGray
        Me.txtRec_est.Location = New System.Drawing.Point(139, 106)
        Me.txtRec_est.MaxLength = 13
        Me.txtRec_est.Name = "txtRec_est"
        Me.txtRec_est.ReadOnly = True
        Me.txtRec_est.Size = New System.Drawing.Size(79, 20)
        Me.txtRec_est.TabIndex = 1036
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtTotPeso)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.dtgRollos)
        Me.GroupBox3.Location = New System.Drawing.Point(461, 112)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(206, 213)
        Me.GroupBox3.TabIndex = 1057
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Cantidades rollos"
        '
        'txtTotPeso
        '
        Me.txtTotPeso.BackColor = System.Drawing.Color.White
        Me.txtTotPeso.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtTotPeso.Location = New System.Drawing.Point(80, 192)
        Me.txtTotPeso.MaxLength = 13
        Me.txtTotPeso.Name = "txtTotPeso"
        Me.txtTotPeso.ReadOnly = True
        Me.txtTotPeso.Size = New System.Drawing.Size(93, 13)
        Me.txtTotPeso.TabIndex = 1042
        Me.txtTotPeso.Text = "0"
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(7, 191)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(88, 15)
        Me.Label9.TabIndex = 1041
        Me.Label9.Text = "Total peso:"
        '
        'dtgRollos
        '
        Me.dtgRollos.AllowUserToAddRows = False
        Me.dtgRollos.AllowUserToDeleteRows = False
        Me.dtgRollos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgRollos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dtgRollos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgRollos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colEliminar, Me.colAdd, Me.ColNumRollo, Me.ColPeso})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtgRollos.DefaultCellStyle = DataGridViewCellStyle2
        Me.dtgRollos.Location = New System.Drawing.Point(7, 15)
        Me.dtgRollos.Name = "dtgRollos"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgRollos.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dtgRollos.RowHeadersVisible = False
        Me.dtgRollos.Size = New System.Drawing.Size(193, 171)
        Me.dtgRollos.TabIndex = 0
        '
        'colEliminar
        '
        Me.colEliminar.HeaderText = ""
        Me.colEliminar.Image = Global.Spic.My.Resources.Resources._1371750041_14125
        Me.colEliminar.Name = "colEliminar"
        Me.colEliminar.Width = 30
        '
        'colAdd
        '
        Me.colAdd.HeaderText = "Add"
        Me.colAdd.Image = Global.Spic.My.Resources.Resources.mas
        Me.colAdd.Name = "colAdd"
        Me.colAdd.ReadOnly = True
        Me.colAdd.Width = 30
        '
        'ColNumRollo
        '
        Me.ColNumRollo.HeaderText = "Número"
        Me.ColNumRollo.Name = "ColNumRollo"
        Me.ColNumRollo.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ColNumRollo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColNumRollo.Width = 50
        '
        'ColPeso
        '
        Me.ColPeso.HeaderText = "Peso"
        Me.ColPeso.Name = "ColPeso"
        Me.ColPeso.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ColPeso.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColPeso.Width = 65
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.cbo_calidad_real)
        Me.GroupBox7.Controls.Add(Me.Label10)
        Me.GroupBox7.Controls.Add(Me.txt_rec_real)
        Me.GroupBox7.Controls.Add(Me.txt_resis_real)
        Me.GroupBox7.Controls.Add(Me.txtMatPrima)
        Me.GroupBox7.Controls.Add(Me.cboProcedencia)
        Me.GroupBox7.Controls.Add(Me.txtColada)
        Me.GroupBox7.Controls.Add(Me.Label8)
        Me.GroupBox7.Controls.Add(Me.Label4)
        Me.GroupBox7.Controls.Add(Me.Label5)
        Me.GroupBox7.Controls.Add(Me.Label6)
        Me.GroupBox7.Controls.Add(Me.Label7)
        Me.GroupBox7.Location = New System.Drawing.Point(4, 139)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(229, 197)
        Me.GroupBox7.TabIndex = 1055
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Propiedades mecánicas"
        '
        'cbo_calidad_real
        '
        Me.cbo_calidad_real.FormattingEnabled = True
        Me.cbo_calidad_real.Location = New System.Drawing.Point(87, 169)
        Me.cbo_calidad_real.Name = "cbo_calidad_real"
        Me.cbo_calidad_real.Size = New System.Drawing.Size(137, 21)
        Me.cbo_calidad_real.TabIndex = 1047
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(2, 173)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(88, 15)
        Me.Label10.TabIndex = 1046
        Me.Label10.Text = "Calidad:"
        '
        'txt_rec_real
        '
        Me.txt_rec_real.Location = New System.Drawing.Point(144, 45)
        Me.txt_rec_real.MaxLength = 13
        Me.txt_rec_real.Name = "txt_rec_real"
        Me.txt_rec_real.Size = New System.Drawing.Size(79, 20)
        Me.txt_rec_real.TabIndex = 1045
        '
        'txt_resis_real
        '
        Me.txt_resis_real.Location = New System.Drawing.Point(144, 17)
        Me.txt_resis_real.MaxLength = 13
        Me.txt_resis_real.Name = "txt_resis_real"
        Me.txt_resis_real.Size = New System.Drawing.Size(79, 20)
        Me.txt_resis_real.TabIndex = 1044
        '
        'txtMatPrima
        '
        Me.txtMatPrima.AutoCompleteCustomSource.AddRange(New String() {"0060", "1101F0550", "1101F0800", "11A1A0550", "11A1A0635", "11A1A0650", "11A1A0800", "11A1A0950", "11A1B0550", "11A1B0600", "11A1B0800", "11A1D0550", "11A1D0635", "11A1D0650", "11A1D0800", "11A1D0950", "11A1G0550", "11A1M05.50", "11A1M0550", "11A1M05650", "11A2G0550", "11AA0550", "11AA0650", "11AB0550", "11AD0650", "11AM05650", "11C1A0550", "11C1A0635", "11C1B0550", "11C1B08/00", "11C1B0800", "11C1B0900", "11C1D0650", "11C1E0550", "11C1L0550", "11D1A0127", "11D1A0550", "11D1A0600", "11D1A0635", "11D1A0650", "11D1A0800", "11D1A0900", "11D1A1000", "11D1B0130", "11D1B0550", "11D1B0600", "11D1B0635", "11D1B0700", "11D1B0800", "11D1B0900", "11D1B0952", "11D1B1000", "11D1D0550", "11D1D0600", "11D1D0635", "11D1D0650", "11D1D0800", "11D1D0900", "11D1D1000", "11D1E0550", "11D1E0900", "11D1G0550", "11F1A0550", "11F1A0635", "11F1A0800", "11F1A0952", "11F1B0550", "11F1B0635", "11F1B0800", "11F1B0952", "11F1D0550", "11F1D0635", "11F1E0550", "11F1M0550", "11F1Q0550", "11F2G0550", "11G1A0550", "11G1A0900", "11G1A1100", "11G1B0550", "11G1B0630", "11G1B0635", "11G1B0800", "11G1D0630", "11G1D0800", "11G1D0900", "11G1G0550", "11G1L0550", "11G1N0900", "11G1N1100", "11G1N1200", "11G1N1300", "11G1N13000", "11G2G0550", "11G2G0900", "11H1B0550", "11H1B0800", "11H1B0900", "11H1D0650", "11I1A0635", "11I1B0550", "11I1B0800", "11I1D0700", "11I1D0800", "11I1D0950", "11I1D0952", "11I1G0550", "11I1L0550", "11I1Q0550", "11I2G0550", "11J1A0550", "11J1A0580", "11J1A0600", "11J1A0650", "11J1A0800", "11J1A0900", "11J1B0550", "11J1B0600", "11J1B0650", "11J1B0800", "11J1B0900", "11J1B1000", "11J1D0550", "11J1D0650", "11M2C068", "11O1A0550", "11O1A0635", "11O1A0800", "11O1A0900", "11O1A1000", "11O1B0550", "11O1B0635", "11O1B0800", "11O1D0635", "11O1D0650", "11O1D0700", "11O1D0800", "11O1E0900", "11O1G0550", "11O1L0550", "11O1M0650", "11O1M0800", "11O1M0900", "11O1N0650", "11O1N0800", "11O1N0900", "11O1Q0550", "11O1Q0800", "11O2H0550", "11P0000NC", "11P000NC", "11P1A0127", "11P1A0130", "11P1A0550", "11P1A0635", "11P1A0650", "11P1A0800", "11P1A0913", "11P1A0952", "11P1B0127", "11P1B0130", "11P1B0550", "11P1B0635", "11P1B0800", "11P1B0850", "11P1B0900", "11P1B0913", "11P1B0952", "11P1B1070", "11P1B1270", "11P1B1300", "11P1D0550", "11P1D0635", "11P1D0800", "11P1D0850", "11P1D0900", "11P1D0913", "11P1D0952", "11P1E0550", "11P1E0635", "11P1E0800", "11P1E0900", "11P1E0913", "11P1E0952", "11P1F0550", "11P1F0635", "11P1F0800", "11P1F0913", "11P1F0952", "11P1G0550", "11P1H2952", "11P1K0550", "11P1M0550", "11P1Q0550", "11P1Q0800", "11P1Q0913", "11P2G0450", "11P2G0550", "11P2I0240", "11P2I0245", "11R1A0550", "11R1B0900", "11S1B0550", "11S1B0635", "11S1B0800", "11S1B0952", "11S1D0550", "11S1D0635", "11S1E0800", "11S1G0550", "11S1K0550", "11S2G0550", "11S3K0550", "11T1B0550", "11T1B0635", "11T1B0800", "11T1B0950", "11T1E0635", "11T1Q0550", "11T1Q0635", "11T2G0550", "11T3J0550", "123100277", "12G110150", "12G110156", "12G110165", "12G110174", "12G110190", "12G110213", "12G110238", "12G110240", "12G110259", "12G110320", "12G110340", "12G110376", "12G110420", "12G130125", "12G130165", "12G130192", "12G130213", "12G130275", "12G130277", "12G130370", "12G130377", "12S100277", "12S100377", "12S4B0376", "12Z100213", "12Z100277", "12Z100377", "13B100126", "13B100150", "13B100165", "13B100170", "13B100180", "13B100185", "13B100201", "13B100208", "13B100213", "13B100275", "13B100277", "13B100304", "13B100377", "13B100559", "13C300213G", "13C300250G", "13P13G0156", "13P13G0156G", "13P13G10259I", "13P13G11213I", "13P13G1213", "13P13G1213I", "13P13G13259", "13P13G13259I", "13P13G14213", "13P13G14213I", "13P13G15213", "13P13G15213I", "13P13G17213", "13P13G17213I", "13P13G4213I", "13P13G5259I", "13P13G7259", "13P13G7259I", "13P13G7260I", "13P1CG0165I", "13P1G0165", "13P1G0165G", "13P1G0165P", "13P1G3165", "13P1G3165P", "13P1G8259I", "13R100125", "13Z1B0258", "13Z1B0259", "13Z1B0283", "13Z1B0328", "13Z1B0335", "13Z1B0363", "13Z1B0365", "13Z1B0378", "13Z1B0383", "13Z1B0438", "13Z1B0439", "13Z1B0440", "14C300213G", "14C300250G", "1CCD167NS", "1CCF147NS", "1CCG25PIAC", "1CCH09ZGI", "1CCH127NS", "1CCH25PIAC", "1CCJ25PIA", "1CCJ25PIAC", "1CCJ25PIH", "1CCK09ZGI", "1CCK117NS", "1CCK25PIAC", "1CCL097NS", "1CCL11PIIC", "1CCM087NS", "1CCM11PIOC", "1CCN067NS", "1CCP057NS", "1CHGES7NC", "1CHHES7NC", "1CHIES7NS", "1MHE26090A", "1MHE26120A", "1MHE26150A", "1MHE26180A", "1NJ4000NS", "1NJ4001NS", "1NJ4002NS", "1NJ4003NS", "1TD506ZNSF", "1TD706ZNSF", "1TDB06ZNSF", "1TDB08ZNSF", "1TDC06ZNSF", "1TDD06ZNS", "1TDD06ZNSF", "1TDD07ZNSF", "1TDD08ZNSF", "1TDD10ZNSF", "1TDE06ZNSF", "1TDE07ZNSF", "1TDE08ZNSF", "1TDF06ZNSF", "1TDF07ZNSF", "1TDF08ZNS", "1TDF08ZNSF", "1TDH06ZNSF", "1TDH08ZNSF", "1TDJ06ZNSF", "1TDK08ZNSF", "1TDK10ZNSF", "1TDL08ZNSF", "1TDW06ZNS", "1TDW06ZNSF", "1TDW07ZNSF", "1TDX06ZNSF", "1UC255TGS", "1UH256TGS", "21C100213", "22B0000NC", "22B100110", "22B100115", "22B100122", "22B100123", "22B100125", "22B100125E", "22B100128", "22B100130", "22B100133", "22B100134", "22B100135", "22B100136", "22B100140", "22B100142", "22B100142E", "22B100145", "22B100147", "22B100148", "22B100150", "22B100152", "22B100156", "22B100158", "22B100165", "22B100168", "22B100170", "22B100172", "22B100177", "22B100180", "22B100185", "22B100190", "22B100195", "22B100200", "22B100201", "22B100204", "22B100206", "22B100208", "22B100213", "22B100220", "22B100225", "22B100230", "22B100232", "22B100233", "22B100240", "22B100246", "22B100248", "22B100250", "22B100256", "22B100260", "22B100266", "22B100269", "22B100270", "22B100275", "22B100277", "22B100277C", "22B100278", "22B100282", "22B100285", "22B100290", "22B100297", "22B100300", "22B100304", "22B100304C", "22B100306", "22B100307", "22B100313", "22B100317", "22B100320", "22B100324", "22B100328", "22B100330", "22B100332", "22B100342", "22B100348", "22B100350", "22B100358", "22B100365", "22B100375", "22B100377", "22B100377C", "22B100379", "22B100380", "22B100390", "22B100395", "22B100396", "22B100400", "22B100409", "22B100420", "22B100425", "22B100428", "22B100430", "22B100440", "22B100450", "22B100456", "22B100464", "22B100474", "22B100480", "22B100486", "22B100490", "22B100500", "22B100505", "22B100508", "22B100513", "22B100516", "22B100520", "22B100526", "22B100530", "22B100534", "22B100540", "22B100548", "22B100550", "22B100556", "22B100559", "22B100559C", "22B100570", "22B100580", "22B100586", "22B100594", "22B100600", "22B100614", "22B100620", "22B100635", "22B100648", "22B100650", "22B100657", "22B100658", "22B100665", "22B100670", "22B100700", "22B100720", "22B100736", "22B100750", "22B100764", "22B100780", "22B100790", "22B100794", "22B100810", "22B100820", "22B100835", "22B100838", "22B100840", "22B100850", "22B100864", "22B100885", "22B100895", "22B100900", "22B100915", "22B100940", "22B100950", "22B101000", "22B101015", "22B101017", "22B101060", "22B101084", "22B101200", "22B101207", "22B101285", "22B110210", "22B110220", "22B110248", "22B110332", "22B110342", "22B110420", "22B110428", "22B110456", "22B110500", "22B110505", "22B110516", "22B110520", "22B110556", "22B110580", "22B110600", "22B110630", "22B110635", "22B110711", "22B110736", "22B1Q0220", "22B1Q0228", "22B1Q0240", "22B1Q0250", "22B1Q0258", "22B1Q0266", "22B1Q0275", "22B1Q0279", "22B1Q0282", "22B1Q0288", "22B1Q0301", "22B1Q0311", "22B1Q0314", "22B1Q0317", "22B1Q0325", "22B1Q0328", "22B1Q0350", "22B1Q0358", "22B1Q0375", "22B1Q0380", "22B1Q0386", "22B1Q0391", "22B1Q0400", "22B1Q0408", "22B1Q0424", "22B1Q0428", "22B1Q0442", "22B1Q0450", "22B1Q0464", "22B1Q0470", "22B1Q0486", "22B1Q0496", "22B1Q0512", "22B1Q0518", "22B1Q0554", "22B1Q0556", "22B1Q0580", "22B1Q0586", "22B1Q0590", "22B1Q0600", "22B1Q0636", "22B1Q0736", "22B200196", "22B200211", "22B200232", "22B200234", "22B200246", "22B200259", "22B200300", "22B200340", "22B200342", "22B200348", "22B200350", "22B200358", "22B200377", "22B200400", "22B200420", "22B200438", "22B200464", "22B200515", "22B300196", "22B300211", "22B300259", "22B300300", "22C300213GE", "22C300250GE", "22G110150", "22G110165", "22G110185", "22G110190", "22G110192", "22G110200", "22G110206", "22G110211", "22G110225", "22G110240", "22G110246", "22G110259", "22G110300", "22G110320", "22G110340", "22G110376", "22G110376G", "22G130125", "22G130125K", "22G130183", "22G130211", "22G130270", "22G130275", "22G130275G", "22G130277", "22G130340", "22G130370", "22G130377", "22P1G0165", "22R0000NC", "22R100110", "22R100115", "22R100125", "22R100125E", "22R100130", "22R100134", "22R100136", "22R100140", "22R100142", "22R100142E", "22R100148", "22R100150", "22R100156", "22R100158", "22R100168", "22R100180", "22R100185", "22R100190", "22R100201", "22R100206", "22R100208", "22R100225", "22R100230", "22R100240", "22R100248", "22R100250", "22R100260", "22R100266", "22R100275", "22R100282", "22R100285", "22R100290", "22R100300", "22R100306", "22R100307", "22R100313", "22R100317", "22R100320", "22R100324", "22R100328", "22R100330", "22R100332", "22R100350", "22R100358", "22R100365", "22R100375", "22R100377", "22R100390", "22R100400", "22R100409", "22R100420", "22R100425", "22R100428", "22R100430", "22R100440", "22R100450", "22R100456", "22R100464", "22R100474", "22R100480", "22R100486", "22R100500", "22R100508", "22R100516", "22R100526", "22R100530", "22R100548", "22R100556", "22R100559", "22R100570", "22R100580", "22R100586", "22R100594", "22R100600", "22R100620", "22R100650", "22R100665", "22R100670", "22R100700", "22R100720", "22R100736", "22R100750", "22R100764", "22R100780", "22R100810", "22R100820", "22R100838", "22R100850", "22R100885", "22R100895", "22R100900", "22R100915", "22R100940", "22R100950", "22R101000", "22R101015", "22R101060", "22R101084", "22R101200", "22R101285", "22R110210", "22R110220", "22R110248", "22R110332", "22R110342", "22R110420", "22R110428", "22R110456", "22R110500", "22R110516", "22R110520", "22R110556", "22R110580", "22R110600", "22R110635", "22R110736", "22R1Q0200", "22R1Q0220", "22R1Q0228", "22R1Q0240", "22R1Q0250", "22R1Q0258", "22R1Q0266", "22R1Q0275", "22R1Q0279", "22R1Q0282", "22R1Q0288", "22R1Q0301", "22R1Q0311", "22R1Q0314", "22R1Q0325", "22R1Q0328", "22R1Q0350", "22R1Q0358", "22R1Q0380", "22R1Q0386", "22R1Q0391", "22R1Q0400", "22R1Q0408", "22R1Q0424", "22R1Q0428", "22R1Q0442", "22R1Q0450", "22R1Q0464", "22R1Q0470", "22R1Q0486", "22R1Q0496", "22R1Q0512", "22R1Q0554", "22R1Q0556", "22R1Q0580", "22R1Q0586", "22R1Q0600", "22R1Q0636", "22R1Q0736", "22R200232", "22R200300", "22R200340", "22R200348", "22R200350", "22R200358", "22R200377", "22R200400", "22R200420", "22R200438", "22R200464", "22R200515", "22R300259", "22X100110", "22X100125", "22X100142", "22X100150", "22X100158", "22X100180", "22X100185", "22X100190", "22X100200", "22X100206", "22X100221", "22X100228", "22X100231", "22X100232", "22X100235", "22X100240", "22X100254", "22X100258", "22X100261", "22X100266", "22X100267", "22X100268", "22X100270", "22X100275", "22X100278", "22X100280", "22X100281", "22X100288", "22X100290", "22X100295", "22X100298", "22X100300", "22X100308", "22X100312", "22X100317", "22X100326", "22X100328", "22X100330", "22X100331", "22X100332", "22X100335", "22X100337", "22X100342", "22X100343", "22X100350", "22X100352", "22X100353", "22X100363", "22X100375", "22X100378", "22X100380", "22X100381", "22X100385", "22X100394", "22X100399", "22X100400", "22X100401", "22X100403", "22X100404", "22X100405", "22X100418", "22X100419", "22X100420", "22X100424", "22X100434", "22X100438", "22X100447", "22X100452", "22X100453", "22X100455", "22X100468", "22X100470", "22X100474", "22X100493", "22X100508", "22X100518", "22X100520", "22X100524", "22X100529", "22X100530", "22X100533", "22X100534", "22X100536", "22X100538", "22X100540", "22X100550", "22X100557", "22X100560", "22X100564", "22X100580", "22X100594", "22X100595", "22X100601", "22X100610", "22X100614", "22X100620", "22X100624", "22X100628", "22X100630", "22X100633", "22X100660", "22X100667", "22X100670", "22X100678", "22X100681", "22X100683", "22X100686", "22X100690", "22X100694", "22X100711", "22X100750", "22X100760", "22X100775", "22X100788", "22X100810", "22X100820", "22X100828", "22X100832", "22X100840", "22X100858", "22X100861", "22X100867", "22X100953", "22X101017", "22X101048", "22X101207", "22X1Q0188", "22X1Q0206", "22X1Q0207", "22X1Q0228", "22X1Q0230", "22X1Q0233", "22X1Q0238", "22X1Q0243", "22X1Q0253", "22X1Q0258", "22X1Q0259", "22X1Q0268", "22X1Q0275", "22X1Q0278", "22X1Q0279", "22X1Q0282", "22X1Q0295", "22X1Q0308", "22X1Q0309", "22X1Q0318", "22X1Q0328", "22X1Q0332", "22X1Q0335", "22X1Q0337", "22X1Q0353", "22X1Q0354", "22X1Q0356", "22X1Q0363", "22X1Q0378", "22X1Q0401", "22X1Q0408", "22X1Q0438", "22X1Q0440", "22X1Q0455", "22X1Q0518", "22X200150", "22X200160", "22X200180", "22X200200", "22X200250", "22X200260", "22X200270", "22X200300", "22X200340", "22X200343", "22X200350", "22X200400", "22X200420", "22X200430", "269303", "2C000000S", "2CA00010S", "2CA00020S", "2CA00030S", "2CA00050S", "2CA00060S", "2CA40RNS", "2CA9201PS", "2CAB151NS", "2CAB15NS", "2CAB201PS", "2CAD12ANS", "2CAD151NS", "2CAD15NS", "2CAD201PS", "2CAD251PS", "2CAD255PS", "2CAD302PS", "2CAD303PS", "2CAD30ANS", "2CAD35ANR", "2CAE251PS", "2CAF12ANS", "2CAF251PS", "2CAF301PS", "2CAF305PS", "2CAF30ANS", "2CAF352PS", "2CAF353PS", "2CAF35ANR", "2CAF401NS", "2CAF40RNS", "2CAH301NS", "2CAH301PS", "2CAH305GS", "2CAH30ANS", "2CAH351NS", "2CAH353NS", "2CAH35ANR", "2CAH35ANS", "2CAH401NS", "2CAH403NS", "2CAH40RNS", "2CAH432PS", "2CAH433GS", "2CAK301PS", "2CAK305NS", "2CAK30ANR", "2CAK350NS", "2CAK350PS", "2CAK401NS", "2CAK403NS", "2CAK40RNS", "2CAK432PS", "2CAK433GS", "2CAK43ANR", "2CAL351PS", "2CAL401NS", "2CAL403NS", "2CAL40ANR", "2CAL40RNS", "2CAL432PS", "2CAL433PS", "2CAL43ANR", "2CAM351NS", "2CAM401NS", "2CAM40ANR", "2CAM431NS", "2CAM432PS", "2CAM433NS", "2CAM43ANR", "2CAN351NS", "2CAN403NS", "2CAN40ANR", "2CAN40RNS", "2CAN432GS", "2CAN433GS", "2CAN433NS", "2CAN43ANR", "2CC0000GS", "2CC0000JS", "2CC00060S", "2CC00070S", "2CC00080S", "2CC00090S", "2CC000H0S", "2CC7187GS", "2CC7187NS", "2CC9000NS", "2CC9100NS", "2CCB177JS", "2CCB177NS", "2CCB186NS", "2CCD167GS", "2CCD167JS", "2CCD167NS", "2CCD176JS", "2CCD176NS", "2CCD178GS", "2CCE117NS", "2CCE147NS", "2CCE157JS", "2CCE157NS", "2CCE176JS", "2CCE176NS", "2CCF097JS", "2CCF117NS", "2CCF127NS", "2CCF146JS", "2CCF146NS", "2CCF147GS", "2CCF147JS", "2CCF147NS", "2CCF166GS", "2CCF166NS", "2CCF169NS", "2CCF207NS", "2CCFA47NS", "2CCH057NS", "2CCH081NS", "2CCH087NS", "2CCH117NS", "2CCH11HNS", "2CCH127GS", "2CCH127JS", "2CCH127NS", "2CCH12HNS", "2CCH146NS", "2CCH25XIS", "2CCHB097NS", "2CCHB09HGS", "2CCHB09HNS", "2CCJ117NS", "2CCJ11HNS", "2CCJ11YNS", "2CCJ127NS", "2CCJ257NS", "2CCJ25XIH", "2CCJ25XIS", "2CCK097NS", "2CCK09HNS", "2CCK09ZGI", "2CCK10HNS", "2CCK117GS", "2CCK117HS", "2CCK117JS", "2CCK117NS", "2CCK11HNS", "2CCK11YNS", "2CCK126NS", "2CCK257NS", "2CCK25HNS", "2CCL087NS", "2CCL08HNS", "2CCL097GS", "2CCL097JS", "2CCL097NS", "2CCL107NS", "2CCL10HNS", "2CCL10YNS", "2CCL558JS", "2CCL558NS", "2CCM087GS", "2CCM087JS", "2CCM087NS", "2CCM08NS", "2CCM101NS", "2CCM558NS", "2CCN067GS", "2CCN067JS", "2CCN067NS", "2CCN40TNS", "2CCN558GS", "2CCN558JS", "2CCN558NS", "2CCO067NS", "2CCO558NS", "2CCP057JS", "2CCP057NS", "2CCP558GS", "2CCP558NS", "2CCQ047JS", "2CCQ047NS", "2CCQ558GS", "2CCQ558NS", "2CHGES7NC", "2CHHES7NC", "2CHIES7NS", "2CK00090S", "2CMD273NS", "2CMF273NS", "2CMS273NS", "2CQB000NS", "2CQK107NS", "2CQL097NS", "2CT9117JS", "2CT9117NS", "2CTB117JS", "2CTB117NS", "2CVP05VGS", "2GG716GGR", "2GG716GGS", "2GR00000S", "2GRB12GGS", "2GRB12GNS", "2GRD09GGS", "2GRD09GNS", "2GRD12GGS", "2GRD12GNS", "2GRE09GGS", "2GRE09GNS", "2NJ4000NS", "2PT000000S", "2RA603ZNS", "2RA604ZNS", "2RA703ZNS", "2RA706ZNS", "2RA707ZNS", "2RA903ZNS", "2RA905ZNS", "2RA906QNS", "2RA906ZNS", "2RA907ZNS", "2RA908ZNS", "2RAB05ZNS", "2RAB06ZNS", "2RAB07ZNS", "2RAB09ZNS", "2RAB10QNS", "2RAD05ZNS", "2RAD06ZNS", "2RAD10ZNS", "2RAE10ZNS", "2RAF10QNS", "2RAF10ZNS", "2RAH10ZNS", "2RAX03ZNS", "2RAX07ZNS", "2RC08QNS", "2RCD08QNS", "2RCE07ZNS", "2RCF07ZNS", "2RCH07ZNS", "2RCJ07ZNS", "2RCL07ZNS", "2RCM07ZNS", "2RCU06ZNS", "2RCV06ZNS", "2RCW07ZNS", "2RE1509NS", "2RE150BNS", "2RE150DNS", "2RE150LNS", "2RE150RNS", "2RE152BNS", "2RE153DNS", "2RE15ORNS", "2RE350BNS", "2RE350CNS", "2RE350DNS", "2RE350RNS", "2RE350WNS", "2RE350ZNS", "2RE352BNS", "2RE352DNS", "2RE352RNS", "2RE352WNS", "2RE352XNS", "2RE353BNS", "2RE353DNS", "2RE353XNS", "2RE354BNS", "2RE354LNS", "2RE354RNS", "2RE354WNS", "2RE354XNS", "2RE450RNS", "2RE450WNS", "2RE452BNS", "2RE452RNS", "2RE452WNS", "2RE452XNS", "2RE453DNS", "2RE453ONS", "2RE453UNS", "2RE453XNS", "2RE4540NS", "2RE454BNS", "2RE454RGS", "2RE454RNS", "2RE454WNS", "2RE550LNS", "2RE550MNS", "2RE550RNS", "2RE550WNS", "2RE550ZNS", "2RE551RNS", "2RE552FNS", "2RE552LNS", "2RE552RNS", "2RE552WNS", "2RE552XNS", "2RE552ZNS", "2RE553LNS", "2RE553RNS", "2RE554FNS", "2RE554LNS", "2RE554RNS", "2RE554WNS", "2RE554XNS", "2RE554ZNS", "2RE555LNS", "2RE555RNS", "2RE555XNS", "2RE650RNS", "2RE650WNS", "2RE750BNS", "2RE750FNS", "2RE750LNS", "2RE750RNS", "2RE750WNS", "2RE750XNS", "2RE750ZNS", "2RE751JNS", "2RE751LNS", "2RE751ONS", "2RE751RNS", "2RE751WNS", "2RE752BNS", "2RE752ENS", "2RE752FNS", "2RE752LNS", "2RE752RNS", "2RE752WNS", "2RE752XNS", "2RE752ZNS", "2RE753LNS", "2RE753RNS", "2RE753WNS", "2RE754FNS", "2RE754LNS", "2RE754RNS", "2RE754WNS", "2RE754XNS", "2RE754ZNS", "2RE7550NS", "2RE755LNS", "2RE755RNS", "2RE755SNS", "2RE755WNS", "2RE755XNS", "2RE755ZNS", "2RE950BNS", "2RE950LNS", "2RE950RNR", "2RE950RNS", "2RE950ZNS", "2RE951LNS", "2RE951RNS", "2RE952ENS", "2RE952FNS", "2RE952QNS", "2RE952RNS", "2RE952WNS", "2RE952ZNS", "2RE953LNS", "2RE953RNS", "2RE953XNS", "2RE953ZNS", "2RE954FNS", "2RE954LNS", "2RE954RNS", "2RE954WNS", "2RE954XNS", "2RE954ZNS", "2RE955FNS", "2RE955LNS", "2RE955RNS", "2RE955WNS", "2RE955XNS", "2REA50BNS", "2REA50RNS", "2REB50BNS", "2REB50DNS", "2REB50LNS", "2REB50RNS", "2REB50WNS", "2REB50ZNS", "2REB51LNS", "2REB51RNS", "2REB52FNS", "2REB52LGS", "2REB52RNR", "2REB52RNS", "2REB52WNS", "2REB52XNS", "2REB52ZNS", "2REB53DNS", "2REB53LNS", "2REB53RNS", "2REB53WNS", "2reb53Xns", "2REB54FNS", "2REB54LNS", "2REB54NNS", "2REB54RNS", "2REB54WNS", "2REB54XNS", "2REB54ZNS", "2REB55BNS", "2REB55FNS", "2REB55LNS", "2REB55NNS", "2REB55PNS", "2REB55RNR", "2REB55RNS", "2REB55WNS", "2REB55XNS", "2REB55ZNS", "2REB5ORNS", "2REC50LGS", "2REC50LNS", "2REC50RNS", "2REC52WNS", "2REC53LNS", "2REC53RNS", "2REC54LNS", "2REC54ZNS", "2REC55LNS", "2REC55RNS", "2RED50LNS", "2RED50RNS", "2RED50WNS", "2RED50XNS", "2RED50ZNS", "2RED51LNS", "2RED51RNS", "2RED51WNS", "2RED52FNS", "2RED52LNS", "2RED52QNS", "2RED52RNR", "2RED52RNS", "2RED52WNS", "2RED52XNS", "2RED52ZNS", "2RED53LNS", "2RED53RNS", "2RED53WNS", "2RED53XNS", "2RED54FNS", "2RED54LNS", "2RED54NNS", "2RED54RNS", "2RED54WNS", "2RED54XNS", "2RED54ZNS", "2RED55FNS", "2RED55LNS", "2RED55NNS", "2RED55QNS", "2RED55RNR", "2RED55RNS", "2RED55SNS", "2RED55WNS", "2RED55XNS", "2RED55ZNS", "2REE50LNS", "2REE50RNS", "2REE50WNS", "2REE50XNS", "2REE51RNS", "2REE51WNS", "2REE51XNS", "2REE52LNS", "2REE52RNS", "2REE52WNS", "2REE52XNS", "2REE52ZNS", "2REE53LNS", "2REE53RNS", "2REE53XNS", "2REE54FNS", "2REE54LNS", "2REE54MNS", "2REE54NNS", "2REE54QNS", "2REE54RNS", "2REE54WNS", "2REE54ZNS", "2REE55FNS", "2REE55LNS", "2REE55RNS", "2REE55SNS", "2REE55WNS", "2REE55XNS", "2REE55ZNS", "2REE5ORNS", "2REF50LNS", "2REF50RNS", "2REF50WNS", "2REF50XNS", "2REF50ZNS", "2REF51RNS", "2REF51WNS", "2REF52QNS", "2REF52RNS", "2REF52WNS", "2REF52XNS", "2REF52ZNS", "2REF53LNS", "2REF53RNS", "2REF54FNS", "2REF54LNS", "2REF54QNS", "2REF54RNS", "2REF54WNS", "2REF54XNS", "2REF54ZNS", "2REF55FNS", "2REF55LNS", "2REF55RNS", "2REF55SNS", "2REF55WNS", "2REF55XNS", "2REF55ZNS", "2REG50WNS", "2REG52PNS", "2REG52RNS", "2REG54NNS", "2REG54RNS", "2REG54ZNS", "2REG55RNS", "2REG55SNS", "2REH50LNS", "2REH50RNS", "2REH50WNS", "2REH50XNS", "2REH50ZNS", "2REH51LNS", "2REH51RNS", "2REH52NNS", "2REH52PNS", "2REH52RNS", "2REH52WNS", "2REH52XNS", "2REH53LNS", "2REH53RNS", "2REH53WNS", "2REH53XNS", "2REH54FNS", "2REH54LNS", "2REH54NNS", "2REH54RNS", "2REH54SNS", "2REH54WNS", "2REH54XNS", "2REH54ZNS", "2REH55FNS", "2REH55LNS", "2REH55PNS", "2REH55RNS", "2REH55SNS", "2REH55WNS", "2REH55XNS", "2REH55ZNS", "2REH5ORNS", "2REJ54ZNS", "2REK52RNS", "2REK52WNS", "2REK54FNS", "2REK54LNS", "2REK54RNS", "2REK54WNS", "2REK54XNS", "2REK54ZNS", "2REK55FNS", "2REK55RNS", "2REK55WNS", "2REK55XNS", "2REL52RNS", "2REL52WNS", "2REL54FNS", "2REL54LNS", "2REL54RNS", "2REL54WNS", "2REL54ZNS", "2REL55FNS", "2REL55RNS", "2REL55WNS", "2REL55XNS", "2REM52RNS", "2REM52WNS", "2REM54LNS", "2REM54RNS", "2REM54WNS", "2REM55RNS", "2REM55WNS", "2REN54FNS", "2REN54LNS", "2REN54RNS", "2REN54WNS", "2REN55RNS", "2REN55WNS", "2REU51RNS", "2REV50RNS", "2REW55SNS", "2REX50RNS", "2REZ54QNS", "2REZ54ZNS", "2REZ55SNS", "2RHF06ZNS", "2RJB55GNS", "2RJB56GNS", "2RJD55GNS", "2RJD56GNS", "2RJE55GNS", "2RJE56GNS", "2RJF55GNS", "2RJF56GNS", "2RJH55GNS", "2RJH56GNS", "2RJJ56GNS", "2RJK55GNS", "2RJK56GNS", "2RJL55GNS", "2RJL56GNS", "2RJM55GNS", "2RJM56GNS", "2RJN55GNS", "2RJN56GNS", "2RL00PP5S", "2RL00PQ5S", "2RL00PZ5S", "2RL304PNS", "2RL304QNS", "2RL306PNS", "2RL306QNS", "2RL306UNS", "2RL406QNS", "2RL504PNS", "2RL504QNS", "2RL504ZNS", "2RL506PGS", "2RL506PNS", "2RL506QNS", "2RL506WNS", "2RL506ZNS", "2RL508PNS", "2RL508QNS", "2RL508UNS", "2RL508ZNS", "2RL510PNS", "2RL510QNS", "2RL604QNS", "2RL704PNS", "2RL704QNS", "2RL704UNS", "2RL704ZNS", "2RL706PNS", "2RL706QNS", "2RL706ZNS", "2RL708FNS", "2RL708PNS", "2RL708QNS", "2RL708UNS", "2RL708XNS", "2RL708ZNS", "2RL710PNS", "2RL710QNS", "2RL710UNS", "2RL710ZNS", "2RL712PNS", "2RL712QNS", "2RL7O6QNS", "2RL904PNS", "2RL904QNS", "2RL904ZNS", "2RL906FNS", "2RL906PNS", "2RL906QNS", "2RL906ZNS", "2RL908PNS", "2RL908QNS", "2RL908UNS", "2RL908XNS", "2RL908ZNS", "2RL910PNS", "2RL910QNS", "2RL910ZNS", "2RL91OQNS", "2RLB04PNS", "2RLB04QNS", "2RLB04ZNS", "2RLB06PNS", "2RLB06QNS", "2RLB06UNS", "2RLB06ZNS", "2RLB08FNS", "2RLB08PNS", "2RLB08QNS", "2RLB08UNS", "2RLB08XNS", "2RLB08ZNS", "2RLB10PNS", "2RLB10QNS", "2RLB10UNS", "2RLB10ZNS", "2RLB12PNS", "2RLB12QNS", "2RLB12ZNS", "2RLB14PNS", "2RLB14QNS", "2RLB1OPNS", "2RLBO6PNS", "2RLBO6QNS", "2RLBO8PNS", "2RLC06PNS", "2RLC06QNS", "2RLC06ZNS", "2RLC08PNS", "2RLC08QNS", "2RLC08ZNS", "2RLC10PNS", "2RLC12PNS", "2RLD04PNS", "2RLD04QNS", "2RLD06PNS", "2RLD06QNS", "2RLD06UNS", "2RLD06ZNS", "2RLD08FNS", "2RLD08PNS", "2RLD08QNS", "2RLD08UNS", "2RLD08XNS", "2RLD08ZNS", "2RLD10PNS", "2RLD10QNS", "2RLD10UNS", "2RLD10ZNS", "2RLD12PNS", "2RLD12QNS", "2RLD12UNS", "2RLD12ZNS", "2RLD14PNS", "2RLD14QNS", "2RLD14ZNS", "2RLD1OPNS", "2RLDO4PNS", "2RLDO6PNS", "2RLDO8PNS", "2RLE06PNS", "2RLE06QNS", "2RLE06XNS", "2RLE06ZNS", "2RLE08FNS", "2RLE08PNS", "2RLE08QNS", "2RLE08UNS", "2RLE08XNS", "2RLE08ZNS", "2RLE10PNS", "2RLE10QNS", "2RLE10UNS", "2RLE10ZNS", "2RLE12PNS", "2RLE12QNS", "2RLE12ZNS", "2RLE14PNS", "2RLE14ZNS", "2RLF06PNS", "2RLF06QNS", "2RLF06UNS", "2RLF06ZNS", "2RLF08FNS", "2RLF08PNS", "2RLF08QNS", "2RLF08UNS", "2RLF08ZNS", "2RLF10PNS", "2RLF10QGS", "2RLF10QNS", "2RLF10UNS", "2RLF10ZNS", "2RLF12PNS", "2RLF12QNS", "2RLF12UNS", "2RLF12ZNS", "2RLF14PNS", "2RLF14QNS", "2RLF14ZNS", "2RLF1OPNS", "2RLFO8PNS", "2RLG04QNS", "2RLH06PNS", "2RLH06QNS", "2RLH06ZNS", "2RLH08PNS", "2RLH08QNS", "2RLH08ZNS", "2RLH10PNS", "2RLH10QNS", "2RLH10UNS", "2RLH10ZNS", "2RLH12PNS", "2RLH12QNS", "2RLH12ZNS", "2RLH14PNS", "2RLH14QNS", "2RLH14ZNS", "2RLK08QNS", "2RLK10ZNS", "2RLK12QNS", "2RLK14QNS", "2RLL08QNS", "2RLL10ZNS", "2RLL12QNS", "2RLM904FNS", "2RLV08PNS", "2RM607ZNS", "2RM703FNS", "2RM703ZNS", "2RM704FNS", "2RM704ZNS", "2RM705FNS", "2RM705ZNS", "2RM706FNS", "2RM706ZNS", "2RM903FNS", "2RM903ZNS", "2RM904FNS", "2RM904ZNS", "2RM905FNS", "2RM905ZNS", "2RM906FNS", "2RM9O3FNS", "2RM9O5FNS", "2RMB03FNS", "2RMB04FNS", "2RMB05FNS", "2RMB05ZNS", "2RMB06FNS", "2RMB06ZNS", "2RMB07FNS", "2RMB07ZNS", "2RMB08FNS", "2RMB08ZNS", "2RMB09FNS", "2RMB10FNS", "2RMB1OFNS", "2RMBO3FNS", "2RMBO4FNS", "2RMC06FNS", "2RMC07FNS", "2RMC07ZNS", "2RMC08FNS", "2RMC08ZNS", "2RMD03FNS", "2RMD04FNS", "2RMD05FNS", "2RMD06FNS", "2RMD06ZNS", "2RMD07FNS", "2RMD07ZNS", "2RMD08FNS", "2RMD08ZNS", "2RMD09FNS", "2RMD09ZNS", "2RMD10FNS", "2RMD10ZNS", "2RMD1OFNS", "2RMDO4FNS", "2RMDO5FNS", "2RMDO6FNS", "2RMDO9FNS", "2RME06FNS", "2RME07FNS", "2RME07PNS", "2RME08FNS", "2RME08ZNS", "2RME09FNS", "2RME10FNS", "2RME10ZNS", "2RMF06FNS", "2RMF07FNS", "2RMF08FNS", "2RMF08ZNS", "2RMF09FNS", "2RMF09ZNS", "2RMF10FNS", "2RMF10ZNS", "2RMFO8FNS", "2RMG07ZNS", "2RMH07FNS", "2RMH08FNS", "2RMH08ZNS", "2RMH09FNS", "2RMH09ZNS", "2RMH10FNS", "2RMH10ZNS", "2RMH1OFNS", "2TA603ZNS", "2TA603ZTS", "2TA604ZNS", "2TA604ZTS", "2TA703ZNS", "2TA703ZTS", "2TA705ZTS", "2TA706ZNR", "2TA706ZNS", "2TA706ZTS", "2TA707ZNS", "2TA707ZTS", "2TA708QNS", "2TA903ZNS", "2TA903ZTS", "2TA905ZNS", "2TA905ZTS", "2TA906QNS", "2TA906ZGS", "2TA906ZNS", "2TA906ZTS", "2TA908ZNS", "2TA910QGS", "2TAB05ZNS", "2TAB05ZTS", "2TAB06ZGS", "2TAB06ZNS", "2TAB06ZTS", "2TAB07ZNS", "2TAB07ZTS", "2TAB08ZNS", "2TAB08ZTS", "2TAB09ZNS", "2TAB10QNS", "2TAD05ZNS", "2TAD06QNS", "2TAD06ZGS", "2TAD06ZNS", "2TAD06ZTS", "2TAD10ZNS", "2TAD10ZTS", "2TAE08ZTS", "2TAE10ZNS", "2TAE10ZTS", "2TAF08ZTS", "2TAF10QNS", "2TAF10ZNS", "2TAH10QTS", "2TAH10ZNS", "2TAH10ZTS", "2TAX03ZNS", "2TAX03ZTS", "2TAX07ZGS", "2TAX07ZNS", "2TAX07ZTS", "2TCD08PGS", "2TCD08PNS", "2TCD08QGS", "2TCD08QNS", "2TCE07ZGS", "2TCE07ZNS", "2TCF07ZGS", "2TCF07ZNS", "2TCH07ZGS", "2TCH07ZNS", "2TCJ07ZGS", "2TCJ07ZNS", "2TCL07ZGS", "2TCL07ZNS", "2TCM07ZGS", "2TCM07ZNS", "2TCU06ZGS", "2TCU06ZNS", "2TCV06ZGS", "2TCV06ZNS", "2TCW07ZGS", "2TCW07ZNS", "2TD506ZNSF", "2TD706ZGSF", "2TD706ZNSF", "2TD906ZGSF", "2TD906ZNSF", "2TDB06ZGSF", "2TDB06ZNSF", "2TDB06ZPSF", "2TDB08ZNSF", "2TDC06ZNSF", "2TDD06ZGSF", "2TDD06ZNS", "2TDD06ZNSF", "2TDD06ZPSF", "2TDD06ZTSF", "2TDD07ZNSF", "2TDD08ZNSF", "2TDD10ZNSF", "2TDE06ZGSF", "2TDE06ZNSF", "2TDE06ZPSF", "2TDE06ZTSF", "2TDE07ZGSF", "2TDE07ZNSF", "2TDE08ZGSF", "2TDE08ZNSF", "2TDE08ZTSF", "2TDF06ZGSF", "2TDF06ZNSF", "2TDF06ZTSF", "2TDF07ZNSF", "2TDF08ZNS", "2TDF08ZNSF", "2TDH06ZGSF", "2TDH06ZNSF", "2TDH06ZPSF", "2TDH06ZTSF", "2TDH08ZGSF", "2TDH08ZNSF", "2TDH08ZTSF", "2TDJ06ZGSF", "2TDJ06ZNSF", "2TDJ06ZTSF", "2TDK08ZGSF", "2TDK08ZNSF", "2TDK08ZTSF", "2TDK10ZNSF", "2TDL08ZGSF", "2TDL08ZNSF", "2TDL08ZTSF", "2TDW06ZGSF", "2TDW06ZNS", "2TDW06ZNSF", "2TDW06ZPSF", "2TDW06ZTSF", "2TDW07ZNSF", "2TDX06ZGSF", "2TDX06ZNSF", "2TE010000", "2TE11RNO", "2TE150BGS", "2TE150BNS", "2TE150BTS", "2TE150DGS", "2TE150DNS", "2TE150DTS", "2TE150LNS", "2TE150MNS", "2TE150MTS", "2TE150RGS", "2TE150RNS", "2TE150RTS", "2TE150WGS", "2TE150WNS", "2TE150WTS", "2TE152BGS", "2TE152BNS", "2TE152BTS", "2TE153DNS", "2TE153DTS", "2TE2542NS", "2TE254ZNS", "2TE350BGS", "2TE350BNS", "2TE350BTS", "2TE350CGS", "2TE350CNS", "2TE350CTS", "2TE350DGS", "2TE350DNS", "2TE350DTS", "2TE350ENS", "2TE350ETS", "2TE350LNS", "2TE350MGS", "2TE350MNS", "2TE350MTS", "2TE350OGS", "2TE350ONS", "2TE350PNS", "2TE350RGS", "2TE350RNS", "2TE350RTS", "2TE350WGS", "2TE350WNS", "2TE350WTS", "2TE350XGS", "2TE350ZGS", "2TE350ZNS", "2TE351BNS", "2TE351BTS", "2TE352BGS", "2TE352BNS", "2TE352BTS", "2TE352CNS", "2TE352CTS", "2TE352DGS", "2TE352DNS", "2TE352DTS", "2TE352LGS", "2TE352LNS", "2TE352RGS", "2TE352RNS", "2TE352RTS", "2TE352WGS", "2TE352WNS", "2TE352WTS", "2TE352XGS", "2TE352XNS", "2TE353BNS", "2TE353BTS", "2TE353DNS", "2TE353DTS", "2TE353ONS", "2TE353OTS", "2TE353XNS", "2TE354BGS", "2TE354BNS", "2TE354BTS", "2TE354LGS", "2TE354LNS", "2TE354LTS", "2TE354RGS", "2TE354RNS", "2TE354RTS", "2TE354WGS", "2TE354WNS", "2TE354XGS", "2TE354XNS", "2TE450BGS", "2TE450BTS", "2TE450ETS", "2TE450MNS", "2TE450MTS", "2TE450RGS", "2TE450RNS", "2TE450RTS", "2TE450WGS", "2TE450WNS", "2TE450WTS", "2TE452BNS", "2TE452MNS", "2TE452MTS", "2TE452RGS", "2TE452RNS", "2TE452RTS", "2TE452WGS", "2TE452WNS", "2TE452XGS", "2TE452XNS", "2TE453DGS", "2TE453DNS", "2TE453DTS", "2TE453UNS", "2TE453XGS", "2TE453XNS", "2TE4540GS", "2TE4540NS", "2TE4540TS", "2TE454BGS", "2TE454BNS", "2TE454BTS", "2TE454KGS", "2TE454KNS", "2TE454KTS", "2TE454RGS", "2TE454RNS", "2TE454RTS", "2TE454WGS", "2TE454WNS", "2TE454WTS", "2TE550BNS", "2TE550BTS", "2TE550DNS", "2TE550DTS", "2TE550LGS", "2TE550LNS", "2TE550MGS", "2TE550MLS", "2TE550MNS", "2TE550MTS", "2TE550RGS", "2TE550RNS", "2TE550RTS", "2TE550WGS", "2TE550WNS", "2TE550WTS", "2TE550XGS", "2TE550XNS", "2TE550ZGS", "2TE550ZGSV", "2TE550ZNS", "2TE550ZNSV", "2TE551RGS", "2TE551RNS", "2TE551RTS", "2TE552ENS", "2TE552FGS", "2TE552FNS", "2TE552LGS", "2TE552LNS", "2TE552LTS", "2TE552RGS", "2TE552RNS", "2TE552RTS", "2TE552WGS", "2TE552WNS", "2TE552WTS", "2TE552XGS", "2TE552XNS", "2TE552ZGS", "2TE552ZNS", "2TE553LGS", "2TE553LNS", "2TE553RGS", "2TE553RNS", "2TE553RTS", "2TE553WGS", "2TE553WNS", "2TE553XGS", "2TE553XNS", "2TE553ZGS", "2TE554FGS", "2TE554FNS", "2TE554LGS", "2TE554LNS", "2TE554LTS", "2TE554RGS", "2TE554RNS", "2TE554RTS", "2TE554WGS", "2TE554WNS", "2TE554WPS", "2TE554WTS", "2TE554XGS", "2TE554XNS", "2TE554XTS", "2TE554ZGS", "2TE554ZNS", "2TE555FNS", "2TE555LNS", "2TE555RGS", "2TE555RNS", "2TE555RTS", "2TE555WGS", "2TE555WNS", "2TE555XGS", "2TE555XNS", "2TE650RGS", "2TE650RNS", "2TE650RTS", "2TE650WNS", "2TE650WTS", "2TE6540NS", "2TE654ENS", "2TE654PNS", "2TE750BGS", "2TE750BNS", "2TE750BTS", "2TE750LGS", "2TE750LNS", "2TE750RGS", "2TE750RNS", "2TE750RTS", "2TE750WGS", "2TE750WNS", "2TE750WTS", "2TE750XGS", "2TE750XNS", "2TE750ZGS", "2TE750ZNS", "2TE751JGS", "2TE751JNS", "2TE751LGS", "2TE751LNS", "2TE751OGS", "2TE751ONS", "2TE751OTR", "2TE751RNS", "2TE751RTS", "2TE751WGS", "2TE751WNS", "2TE752BGS", "2TE752BNS", "2TE752BTS", "2TE752ENS", "2TE752ETS", "2TE752FGS", "2TE752FNS", "2TE752LGS", "2TE752LNS", "2TE752LTS", "2TE752MGS", "2TE752MNS", "2TE752RGS", "2TE752RNS", "2TE752RPS", "2TE752RTS", "2TE752WGS", "2TE752WNS", "2TE752WTS", "2TE752XGS", "2TE752XNS", "2TE752XTS", "2TE752ZGS", "2TE752ZNS", "2TE752ZPS", "2TE753LGS", "2TE753LNS", "2TE753RGS", "2TE753RNS", "2TE753WGS", "2TE753WNS", "2TE753XGS", "2TE753XNS", "2TE753ZGS", "2TE754AGS", "2TE754BNS", "2TE754BTS", "2TE754EPS", "2TE754FGS", "2TE754FNS", "2TE754FTS", "2TE754LGS", "2TE754LNS", "2TE754LTS", "2TE754MNS", "2TE754NGS", "2TE754NNS", "2TE754RGS", "2TE754RNS", "2TE754RTS", "2TE754WGS", "2TE754WNS", "2TE754WTS", "2TE754XGS", "2TE754XNS", "2TE754XPS", "2TE754XTS", "2TE754ZGS", "2TE754ZGSV", "2TE754ZNS", "2TE754ZPS", "2TE754ZTS", "2TE7550NS", "2TE7550TS", "2TE7553GS", "2TE755EGS", "2TE755FGS", "2TE755FNS", "2TE755LGS", "2TE755LNS", "2TE755LPS", "2TE755LTS", "2TE755MGS", "2TE755ONS", "2TE755RGS", "2TE755RNS", "2TE755RTS", "2TE755VGS", "2TE755WGS", "2TE755WNS", "2TE755WPS", "2TE755WTS", "2TE755XGS", "2TE755XNS", "2TE755XPS", "2TE755XTS", "2TE755ZGS", "2TE755ZNS", "2TE755ZPS", "2TE855FLS", "2TE855RGS", "2TE855RNS", "2TE950BGS", "2TE950BNS", "2TE950BTS", "2TE950LGS", "2TE950LNS", "2TE950RGS", "2TE950RNS", "2TE950RTS", "2TE950WGS", "2TE950WNS", "2TE950WTS", "2TE950XGS", "2TE950XNS", "2TE950ZGS", "2TE950ZNS", "2TE951LNS", "2TE951LTS", "2TE951RGS", "2TE951RNS", "2TE951WGS", "2TE952EGS", "2TE952ENS", "2TE952ETS", "2TE952FNS", "2TE952LGS", "2TE952QGS", "2TE952QNS", "2TE952RGS", "2TE952RNS", "2TE952RTS", "2TE952WGS", "2TE952WNS", "2TE952XGS", "2TE952ZGS", "2TE952ZNS", "2TE953LGS", "2TE953LNS", "2TE953RGS", "2TE953RNS", "2TE953WGS", "2TE953WNS", "2TE953XGS", "2TE953XNS", "2TE953ZGS", "2TE953ZNS", "2TE954FGS", "2TE954FNS", "2TE954LGS", "2TE954LNS", "2TE954MNS", "2TE954RGS", "2TE954RNS", "2TE954RTS", "2TE954WGS", "2TE954WNS", "2TE954WTS", "2TE954XGS", "2TE954XNS", "2TE954ZGS", "2TE954ZNS", "2TE954ZPS", "2TE955FNS", "2TE955LGS", "2TE955LNS", "2TE955RGS", "2TE955RNS", "2TE955WGS", "2TE955WNS", "2TE955XGS", "2TE955XNS", "2TE955XPS", "2TE955ZGS", "2TE955ZNS", "2TEA50BNS", "2TEA50BTS", "2TEA50RNS", "2TEA50RTS", "2TEA51BNS", "2TEA51BTS", "2TEA51RNS", "2TEB50BNS", "2TEB50BTS", "2TEB50LGS", "2TEB50LNS", "2TEB50QTS", "2TEB50RGS", "2TEB50RNS", "2TEB50RTS", "2TEB50WGS", "2TEB50WNS", "2TEB50WTS", "2TEB50XGS", "2TEB50XNS", "2TEB50ZGS", "2TEB50ZNS", "2TEB51FGS", "2TEB51FNS", "2TEB51LGS", "2TEB51LNS", "2TEB51RNS", "2TEB52FGS", "2TEB52FNS", "2TEB52LGS", "2TEB52LNS", "2TEB52LTS", "2TEB52MGS", "2TEB52MNS", "2TEB52OTS", "2TEB52QTS", "2TEB52RGS", "2TEB52RNS", "2TEB52RTS", "2TEB52WGS", "2TEB52WNS", "2TEB52WTS", "2TEB52XGS", "2TEB52XNS", "2TEB52ZGS", "2TEB52ZNS", "2TEB52ZPS", "2TEB53DNS", "2TEB53DTS", "2TEB53LGS", "2TEB53LNS", "2TEB53LTS", "2TEB53RGS", "2TEB53RNS", "2TEB53RTS", "2TEB53WGS", "2TEB53WNS", "2TEB53XGS", "2TEB53XNS", "2TEB53ZGS", "2TEB54FGS", "2TEB54FNS", "2TEB54LGS", "2TEB54LNS", "2TEB54MNS", "2TEB54NGS", "2TEB54NNS", "2TEB54RGS", "2TEB54RNS", "2TEB54RPS", "2TEB54RTS", "2TEB54SGS", "2TEB54SNS", "2TEB54WGS", "2TEB54WNS", "2TEB54XGS", "2TEB54XNS", "2TEB54XTS", "2TEB54ZGS", "2TEB54ZNS", "2TEB54ZTS", "2TEB55FGS", "2TEB55FNS", "2TEB55LGS", "2TEB55LNS", "2TEB55NGS", "2TEB55NNS", "2TEB55QGS", "2TEB55RGS", "2TEB55RNS", "2TEB55SGS", "2TEB55SNS", "2TEB55WGS", "2TEB55WNS", "2TEB55XGS", "2TEB55XNS", "2TEB55ZGS", "2TEB55ZNS", "2TEC50LGS", "2TEC50LNS", "2TEC50RGS", "2TEC50RNS", "2TEC50RTS", "2TEC51RNS", "2TEC52RGS", "2TEC52RNS", "2TEC52WGS", "2TEC52WNS", "2TEC52XGS", "2TEC53LNS", "2TEC53RGS", "2TEC53RNS", "2TEC53ZGS", "2TEC54LGS", "2TEC54LNS", "2TEC54RGS", "2TEC54RNS", "2TEC54WGS", "2TEC54ZGS", "2TEC54ZNS", "2TEC55LGS", "2TEC55LNS", "2TEC55RGS", "2TEC55RNS", "2TEC55ZGS", "2TED50BTS", "2TED50LGS", "2TED50LNS", "2TED50RGS", "2TED50RNS", "2TED50RTS", "2TED50WGS", "2TED50WNS", "2TED50WTS", "2TED50XGS", "2TED50XNS", "2TED50ZGS", "2TED50ZNS", "2TED51JGS", "2TED51JNS", "2TED51LGS", "2TED51LNS", "2TED51PGS", "2TED51RGS", "2TED51RNS", "2TED51RTS", "2TED51WGS", "2TED51WNS", "2TED52FGS", "2TED52FNS", "2TED52LGS", "2TED52LNS", "2TED52MGS", "2TED52QGS", "2TED52QNS", "2TED52RGS", "2TED52RNS", "2TED52RTS", "2TED52WGS", "2TED52WNS", "2TED52XGS", "2TED52XNS", "2TED52ZGS", "2TED52ZNS", "2TED53LGS", "2TED53LNS", "2TED53RGS", "2TED53RNS", "2TED53RTS", "2TED53WGS", "2TED53WNS", "2TED53XGS", "2TED53XNS", "2TED53ZGS", "2TED540NS", "2TED54FGS", "2TED54FNS", "2TED54GNS", "2TED54LGS", "2TED54LNS", "2TED54LTS", "2TED54NGS", "2TED54NNS", "2TED54NTS", "2TED54QGS", "2TED54RGS", "2TED54RNS", "2TED54RPS", "2TED54RTS", "2TED54SGS", "2TED54SNS", "2TED54WGS", "2TED54WNS", "2TED54XGS", "2TED54XNS", "2TED54YGS", "2TED54ZGS", "2TED54ZNS", "2TED55FGS", "2TED55FNS", "2TED55LGS", "2TED55LNS", "2TED55NNS", "2TED55RGS", "2TED55RNS", "2TED55SGS", "2TED55SNS", "2TED55WGS", "2TED55WNS", "2TED55XGS", "2TED55XNS", "2TED55ZGS", "2TED55ZNS", "2TEE50LGS", "2TEE50LNS", "2TEE50RGS", "2TEE50RNS", "2TEE50RTS", "2TEE50WGS", "2TEE50WNS", "2TEE50XGS", "2TEE50XNS", "2TEE50ZGS", "2TEE50ZNS", "2TEE51RGS", "2TEE51RNS", "2TEE51WGS", "2TEE51WNS", "2TEE51XGS", "2TEE51XNS", "2TEE52LGR", "2TEE52LGS", "2TEE52LNS", "2TEE52OGS", "2TEE52QGS", "2TEE52RGS", "2TEE52RNS", "2TEE52WGS", "2TEE52WNS", "2TEE52XGS", "2TEE52XNS", "2TEE52ZGS", "2TEE52ZNS", "2TEE53LGS", "2TEE53LNS", "2TEE53RGS", "2TEE53RNS", "2TEE53WGS", "2TEE53WNS", "2TEE53XGS", "2TEE53XNS", "2TEE53ZGS", "2TEE54BNS", "2TEE54FGS", "2TEE54FNS", "2TEE54LGS", "2TEE54LNS", "2TEE54MNS", "2TEE54NGS", "2TEE54NNS", "2TEE54QNS", "2TEE54RGS", "2TEE54RNS", "2TEE54WGS", "2TEE54WNS", "2TEE54XGS", "2TEE54ZGS", "2TEE54ZNS", "2TEE55FGS", "2TEE55FNS", "2TEE55LGS", "2TEE55LNS", "2TEE55RGS", "2TEE55RNS", "2TEE55SGS", "2TEE55SNS", "2TEE55WGS", "2TEE55WNS", "2TEE55XGS", "2TEE55XNS", "2TEE55ZGS", "2TEE55ZNS", "2TEF50LGS", "2TEF50LNS", "2TEF50RGS", "2TEF50RNS", "2TEF50RTS", "2TEF50WGS", "2TEF50WNS", "2TEF50XGS", "2TEF50XNS", "2TEF50ZGS", "2TEF50ZNS", "2TEF51LGS", "2TEF51RGS", "2TEF51RNS", "2TEF51WGS", "2TEF51WNS", "2TEF52FNS", "2TEF52MGS", "2TEF52MNS", "2TEF52QGS", "2TEF52RGS", "2TEF52RNS", "2TEF52RTS", "2TEF52WGS", "2TEF52WNS", "2TEF52XGS", "2TEF52XNS", "2TEF52ZGS", "2TEF52ZNS", "2TEF53FGS", "2TEF53FNS", "2TEF53LGS", "2TEF53LNS", "2TEF53RGS", "2TEF53RNS", "2TEF53WGS", "2TEF53WNS", "2TEF53XGS", "2TEF53XNS", "2TEF53ZGS", "2TEF54FGS", "2TEF54FNS", "2TEF54LGS", "2TEF54LNS", "2TEF54NGS", "2TEF54NNS", "2TEF54QNS", "2TEF54RGS", "2TEF54RNS", "2TEF54WGS", "2TEF54WNS", "2TEF54XGS", "2TEF54XNS", "2TEF54ZGS", "2TEF54ZNS", "2TEF55FGS", "2TEF55FNS", "2TEF55LGS", "2TEF55LNS", "2TEF55RGS", "2TEF55RNS", "2TEF55SGS", "2TEF55SNS", "2TEF55WGS", "2TEF55WNS", "2TEF55XGS", "2TEF55XNS", "2TEF55ZGS", "2TEF55ZNS", "2TEG50RNS", "2TEG50RTS", "2TEG52PGS", "2TEG52PNS", "2TEG52RGS", "2TEG52RNS", "2TEG53RNS", "2TEG53RTS", "2TEG54FGS", "2TEG54FNS", "2TEG54NGS", "2TEG54NNS", "2TEG54RGS", "2TEG54RNS", "2TEG54SGS", "2TEG54SNS", "2TEG54ZGS", "2TEG54ZGSV", "2TEG54ZNS", "2TEG54ZNSV", "2TEG55FGS", "2TEG55RGS", "2TEG55SGS", "2TEG55SNS", "2TEG55ZGS", "2TEH50LGS", "2TEH50LNS", "2TEH50RGS", "2TEH50RNS", "2TEH50RTS", "2TEH50WGS", "2TEH50WNS", "2TEH50XGS", "2TEH50XNS", "2TEH50ZGS", "2TEH50ZNS", "2TEH51LGS", "2TEH51LNS", "2TEH51RGS", "2TEH51RNS", "2TEH52FGS", "2TEH52FNS", "2TEH52NGS", "2TEH52NNS", "2TEH52PGS", "2TEH52PNS", "2TEH52RGS", "2TEH52RNS", "2TEH52SGS", "2TEH52WGS", "2TEH52WNS", "2TEH52ZGS", "2TEH52ZNS", "2TEH53LGS", "2TEH53LNS", "2TEH53RGS", "2TEH53RNS", "2TEH53WGS", "2TEH53WNS", "2TEH53XGS", "2TEH53XNS", "2TEH53ZGS", "2TEH54FGS", "2TEH54FNS", "2TEH54LGS", "2TEH54LNS", "2TEH54NGS", "2TEH54NNS", "2TEH54RGS", "2TEH54RNS", "2TEH54RTS", "2TEH54SGS", "2TEH54SNS", "2TEH54WGS", "2TEH54WNS", "2TEH54XGS", "2TEH54XNS", "2TEH54ZGS", "2TEH54ZGSV", "2TEH54ZNS", "2TEH54ZNSV", "2TEH55FGS", "2TEH55FNS", "2TEH55LGS", "2TEH55LNS", "2TEH55NNS", "2TEH55RGS", "2TEH55RNS", "2TEH55SGS", "2TEH55SNS", "2TEH55WGS", "2TEH55WNS", "2TEH55XGS", "2TEH55XNS", "2TEH55ZGS", "2TEH55ZNS", "2TEJ54ZGS", "2TEJ54ZGSV", "2TEJ54ZNS", "2TEJ54ZNSV", "2TEK50RGS", "2TEK52RGS", "2TEK52RNS", "2TEK52WGS", "2TEK52WNS", "2TEK52ZGS", "2TEK53XNS", "2TEK54FNS", "2TEK54LGS", "2TEK54LNS", "2TEK54RGS", "2TEK54RNS", "2TEK54WGS", "2TEK54WNS", "2TEK54XGS", "2TEK54XNS", "2TEK54ZGS", "2TEK54ZNS", "2TEK55FNS", "2TEK55RGS", "2TEK55RNS", "2TEK55WGS", "2TEK55WNS", "2TEK55XGS", "2TEK55XNS", "2TEK55ZGS", "2TEK55ZNS", "2TEL52RGS", "2TEL52RNS", "2TEL52WGS", "2TEL52WNS", "2TEL52ZGS", "2TEL54FNS", "2TEL54LGS", "2TEL54LNS", "2TEL54RGS", "2TEL54RNS", "2TEL54WGS", "2TEL54WNS", "2TEL54XGS", "2TEL54XNS", "2TEL54ZGS", "2TEL54ZNS", "2TEL55FNS", "2TEL55NNS", "2TEL55RGS", "2TEL55RNS", "2TEL55WGS", "2TEL55WNS", "2TEL55XGS", "2TEL55XNS", "2TEL55ZGS", "2TEM52RGS", "2TEM52RNS", "2TEM52WGS", "2TEM52WNS", "2TEM54LGS", "2TEM54LNS", "2TEM54RGS", "2TEM54RNS", "2TEM54WGS", "2TEM54WNS", "2TEM55RGS", "2TEM55RNS", "2TEM55WGS", "2TEM55WNS", "2TEM55XGS", "2TEM55XNS", "2TEN54FNS", "2TEN54LGS", "2TEN54LNS", "2TEN54RGS", "2TEN54RNS", "2TEN54WGS", "2TEN54WNS", "2TEN54XGS", "2TEN54XNS", "2TEN54ZNS", "2TEN55RGS", "2TEN55RNS", "2TEN55WGS", "2TEN55WNS", "2TET50RTS", "2TEU51RNS", "2TEU51RTS", "2TEV50RNS"})
        Me.txtMatPrima.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtMatPrima.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtMatPrima.Location = New System.Drawing.Point(87, 109)
        Me.txtMatPrima.MaxLength = 13
        Me.txtMatPrima.Name = "txtMatPrima"
        Me.txtMatPrima.Size = New System.Drawing.Size(137, 20)
        Me.txtMatPrima.TabIndex = 1037
        '
        'cboProcedencia
        '
        Me.cboProcedencia.FormattingEnabled = True
        Me.cboProcedencia.Location = New System.Drawing.Point(87, 74)
        Me.cboProcedencia.Name = "cboProcedencia"
        Me.cboProcedencia.Size = New System.Drawing.Size(137, 21)
        Me.cboProcedencia.TabIndex = 1041
        '
        'txtColada
        '
        Me.txtColada.Location = New System.Drawing.Point(87, 142)
        Me.txtColada.MaxLength = 13
        Me.txtColada.Name = "txtColada"
        Me.txtColada.Size = New System.Drawing.Size(137, 20)
        Me.txtColada.TabIndex = 1038
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(0, 145)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(88, 15)
        Me.Label8.TabIndex = 1039
        Me.Label8.Text = "Colada:"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(0, 20)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(144, 15)
        Me.Label4.TabIndex = 1031
        Me.Label4.Text = "Resistencia (kgf/mm2)"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(0, 77)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(88, 15)
        Me.Label5.TabIndex = 1033
        Me.Label5.Text = "Procedencia:"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(0, 48)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(144, 15)
        Me.Label6.TabIndex = 1035
        Me.Label6.Text = "Recubrimiento (g/mm2)"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(0, 114)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(88, 15)
        Me.Label7.TabIndex = 1037
        Me.Label7.Text = "Materia prima:"
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.txtNit)
        Me.GroupBox8.Controls.Add(Me.lblNit)
        Me.GroupBox8.Controls.Add(Me.txtNombres)
        Me.GroupBox8.Controls.Add(Me.Label1)
        Me.GroupBox8.Controls.Add(Me.txtCodigo)
        Me.GroupBox8.Controls.Add(Me.Label3)
        Me.GroupBox8.Controls.Add(Me.txtDescripcion)
        Me.GroupBox8.Controls.Add(Me.Label2)
        Me.GroupBox8.Location = New System.Drawing.Point(4, 33)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(663, 73)
        Me.GroupBox8.TabIndex = 1054
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "Información ficha"
        '
        'txtNit
        '
        Me.txtNit.BackColor = System.Drawing.Color.White
        Me.txtNit.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtNit.Location = New System.Drawing.Point(66, 18)
        Me.txtNit.MaxLength = 13
        Me.txtNit.Name = "txtNit"
        Me.txtNit.ReadOnly = True
        Me.txtNit.Size = New System.Drawing.Size(163, 13)
        Me.txtNit.TabIndex = 1032
        '
        'lblNit
        '
        Me.lblNit.BackColor = System.Drawing.Color.Transparent
        Me.lblNit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNit.Location = New System.Drawing.Point(9, 18)
        Me.lblNit.Name = "lblNit"
        Me.lblNit.Size = New System.Drawing.Size(27, 15)
        Me.lblNit.TabIndex = 1031
        Me.lblNit.Text = "Nit:"
        '
        'txtNombres
        '
        Me.txtNombres.BackColor = System.Drawing.Color.White
        Me.txtNombres.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtNombres.Location = New System.Drawing.Point(318, 18)
        Me.txtNombres.MaxLength = 13
        Me.txtNombres.Name = "txtNombres"
        Me.txtNombres.ReadOnly = True
        Me.txtNombres.Size = New System.Drawing.Size(334, 13)
        Me.txtNombres.TabIndex = 1034
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(239, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 15)
        Me.Label1.TabIndex = 1033
        Me.Label1.Text = "Nombres:"
        '
        'txtCodigo
        '
        Me.txtCodigo.BackColor = System.Drawing.Color.White
        Me.txtCodigo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtCodigo.Location = New System.Drawing.Point(66, 44)
        Me.txtCodigo.MaxLength = 13
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.ReadOnly = True
        Me.txtCodigo.Size = New System.Drawing.Size(163, 13)
        Me.txtCodigo.TabIndex = 1036
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(9, 44)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 15)
        Me.Label3.TabIndex = 1035
        Me.Label3.Text = "Código:"
        '
        'txtDescripcion
        '
        Me.txtDescripcion.BackColor = System.Drawing.Color.White
        Me.txtDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtDescripcion.Location = New System.Drawing.Point(318, 44)
        Me.txtDescripcion.MaxLength = 13
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.ReadOnly = True
        Me.txtDescripcion.Size = New System.Drawing.Size(334, 13)
        Me.txtDescripcion.TabIndex = 1038
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(239, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 15)
        Me.Label2.TabIndex = 1037
        Me.Label2.Text = "Descripción:"
        '
        'cboResponsable
        '
        Me.cboResponsable.FormattingEnabled = True
        Me.cboResponsable.Location = New System.Drawing.Point(16, 14)
        Me.cboResponsable.Name = "cboResponsable"
        Me.cboResponsable.Size = New System.Drawing.Size(303, 21)
        Me.cboResponsable.TabIndex = 0
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.cboResponsable)
        Me.GroupBox4.Location = New System.Drawing.Point(4, 341)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(335, 39)
        Me.GroupBox4.TabIndex = 1050
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Responsable"
        '
        'cboCoordinador
        '
        Me.cboCoordinador.FormattingEnabled = True
        Me.cboCoordinador.Location = New System.Drawing.Point(6, 14)
        Me.cboCoordinador.Name = "cboCoordinador"
        Me.cboCoordinador.Size = New System.Drawing.Size(299, 21)
        Me.cboCoordinador.TabIndex = 0
        '
        'groupBox5
        '
        Me.groupBox5.Controls.Add(Me.cboCoordinador)
        Me.groupBox5.Location = New System.Drawing.Point(345, 341)
        Me.groupBox5.Name = "groupBox5"
        Me.groupBox5.Size = New System.Drawing.Size(322, 39)
        Me.groupBox5.TabIndex = 1051
        Me.groupBox5.TabStop = False
        Me.groupBox5.Text = "Coordinador"
        '
        'FrmFichaPesosManual
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(679, 389)
        Me.Controls.Add(Me.txt_num_pedido)
        Me.Controls.Add(Me.groupBox5)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.Toolbar1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox8)
        Me.Controls.Add(Me.GroupBox7)
        Me.Name = "FrmFichaPesosManual"
        Me.Text = "Relación peso-rollos"
        Me.Toolbar1.ResumeLayout(False)
        Me.Toolbar1.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.dtgRollos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.groupBox5.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Toolbar1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btn_salir As System.Windows.Forms.ToolStripButton
    Friend WithEvents btn_ppal As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnGenReporte As System.Windows.Forms.ToolStripButton
    Friend WithEvents txt_num_pedido As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents txtCalidad_est As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtResis_est As System.Windows.Forms.TextBox
    Friend WithEvents txtRec_est As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txtTotPeso As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents dtgRollos As System.Windows.Forms.DataGridView
    Friend WithEvents colEliminar As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents colAdd As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents ColNumRollo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColPeso As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents cbo_calidad_real As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txt_rec_real As System.Windows.Forms.TextBox
    Friend WithEvents txt_resis_real As System.Windows.Forms.TextBox
    Friend WithEvents txtMatPrima As System.Windows.Forms.TextBox
    Friend WithEvents cboProcedencia As System.Windows.Forms.ComboBox
    Friend WithEvents txtColada As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents txtNit As System.Windows.Forms.TextBox
    Friend WithEvents lblNit As System.Windows.Forms.Label
    Friend WithEvents txtNombres As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboResponsable As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents cboCoordinador As System.Windows.Forms.ComboBox
    Friend WithEvents groupBox5 As System.Windows.Forms.GroupBox
End Class
