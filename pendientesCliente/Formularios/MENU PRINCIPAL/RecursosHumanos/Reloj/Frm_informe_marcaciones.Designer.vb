<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_informe_marcaciones
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
        Me.Toolbar1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btn_salir = New System.Windows.Forms.ToolStripButton()
        Me.btn_ppal = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnConsultar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSplitButton1 = New System.Windows.Forms.ToolStripButton()
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
        Me.dtg_consulta = New System.Windows.Forms.DataGridView()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.imgProcesar = New System.Windows.Forms.PictureBox()
        Me.cbo_operario = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.cbo_fecha_fin = New System.Windows.Forms.DateTimePicker()
        Me.cbo_fecha_ini = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.TextBox9 = New System.Windows.Forms.TextBox()
        Me.Toolbar1.SuspendLayout()
        Me.menStrip.SuspendLayout()
        CType(Me.dtg_consulta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgProcesar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Toolbar1
        '
        Me.Toolbar1.AutoSize = False
        Me.Toolbar1.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.Toolbar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Toolbar1.ImageScalingSize = New System.Drawing.Size(23, 23)
        Me.Toolbar1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator2, Me.btn_salir, Me.btn_ppal, Me.ToolStripSeparator3, Me.btnConsultar, Me.ToolStripSplitButton1})
        Me.Toolbar1.Location = New System.Drawing.Point(0, 0)
        Me.Toolbar1.Name = "Toolbar1"
        Me.Toolbar1.Size = New System.Drawing.Size(737, 34)
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
        'btnConsultar
        '
        Me.btnConsultar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnConsultar.Image = Global.Spic.My.Resources.Resources.update
        Me.btnConsultar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(27, 31)
        Me.btnConsultar.Text = "Consultar"
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
        Me.cbo_centro.Location = New System.Drawing.Point(6, 13)
        Me.cbo_centro.Name = "cbo_centro"
        Me.cbo_centro.Size = New System.Drawing.Size(222, 21)
        Me.cbo_centro.TabIndex = 1081
        Me.cbo_centro.Text = "Seleccione"
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
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.Format = "N0"
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtg_consulta.DefaultCellStyle = DataGridViewCellStyle1
        Me.dtg_consulta.Location = New System.Drawing.Point(7, 82)
        Me.dtg_consulta.Name = "dtg_consulta"
        Me.dtg_consulta.RowHeadersVisible = False
        Me.dtg_consulta.Size = New System.Drawing.Size(725, 345)
        Me.dtg_consulta.TabIndex = 1088
        '
        'TextBox3
        '
        Me.TextBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox3.BackColor = System.Drawing.Color.Yellow
        Me.TextBox3.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox3.Location = New System.Drawing.Point(585, 3)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.ReadOnly = True
        Me.TextBox3.Size = New System.Drawing.Size(15, 13)
        Me.TextBox3.TabIndex = 1103
        '
        'Label15
        '
        Me.Label15.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(531, 3)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(55, 13)
        Me.Label15.TabIndex = 1105
        Me.Label15.Text = "Sin salida:"
        '
        'Label17
        '
        Me.Label17.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(258, 2)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(109, 13)
        Me.Label17.TabIndex = 1109
        Me.Label17.Text = "Sin permiso de salida:"
        '
        'TextBox2
        '
        Me.TextBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox2.BackColor = System.Drawing.Color.GreenYellow
        Me.TextBox2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox2.Location = New System.Drawing.Point(370, 2)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ReadOnly = True
        Me.TextBox2.Size = New System.Drawing.Size(13, 13)
        Me.TextBox2.TabIndex = 1108
        '
        'Label21
        '
        Me.Label21.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(395, 3)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(116, 13)
        Me.Label21.TabIndex = 1111
        Me.Label21.Text = "Marcaciones correjidas"
        '
        'TextBox4
        '
        Me.TextBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox4.BackColor = System.Drawing.Color.Red
        Me.TextBox4.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox4.Location = New System.Drawing.Point(512, 2)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.ReadOnly = True
        Me.TextBox4.Size = New System.Drawing.Size(13, 13)
        Me.TextBox4.TabIndex = 1110
        '
        'imgProcesar
        '
        Me.imgProcesar.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.imgProcesar.Image = Global.Spic.My.Resources.Resources.procesando
        Me.imgProcesar.Location = New System.Drawing.Point(70, 140)
        Me.imgProcesar.Name = "imgProcesar"
        Me.imgProcesar.Size = New System.Drawing.Size(596, 188)
        Me.imgProcesar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgProcesar.TabIndex = 1114
        Me.imgProcesar.TabStop = False
        Me.imgProcesar.Visible = False
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
        Me.GroupBox1.Location = New System.Drawing.Point(6, 34)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(231, 40)
        Me.GroupBox1.TabIndex = 1090
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Centro de costos"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cbo_operario)
        Me.GroupBox2.Location = New System.Drawing.Point(240, 33)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(242, 40)
        Me.GroupBox2.TabIndex = 1091
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Operario"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cbo_fecha_fin)
        Me.GroupBox3.Controls.Add(Me.cbo_fecha_ini)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Location = New System.Drawing.Point(485, 33)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(247, 41)
        Me.GroupBox3.TabIndex = 1115
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Rango de fecha ( marcaciones)"
        '
        'cbo_fecha_fin
        '
        Me.cbo_fecha_fin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.cbo_fecha_fin.Location = New System.Drawing.Point(165, 15)
        Me.cbo_fecha_fin.Name = "cbo_fecha_fin"
        Me.cbo_fecha_fin.Size = New System.Drawing.Size(79, 20)
        Me.cbo_fecha_fin.TabIndex = 1068
        '
        'cbo_fecha_ini
        '
        Me.cbo_fecha_ini.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.cbo_fecha_ini.Location = New System.Drawing.Point(44, 16)
        Me.cbo_fecha_ini.Name = "cbo_fecha_ini"
        Me.cbo_fecha_ini.Size = New System.Drawing.Size(82, 20)
        Me.cbo_fecha_ini.TabIndex = 1067
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(131, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 13)
        Me.Label2.TabIndex = 1050
        Me.Label2.Text = "Final"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(4, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 13)
        Me.Label3.TabIndex = 1048
        Me.Label3.Text = "Inicial"
        '
        'Label32
        '
        Me.Label32.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(606, 3)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(82, 13)
        Me.Label32.TabIndex = 1134
        Me.Label32.Text = "Entro a deshora"
        '
        'TextBox9
        '
        Me.TextBox9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox9.BackColor = System.Drawing.Color.Purple
        Me.TextBox9.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox9.Location = New System.Drawing.Point(694, 3)
        Me.TextBox9.Name = "TextBox9"
        Me.TextBox9.ReadOnly = True
        Me.TextBox9.Size = New System.Drawing.Size(13, 13)
        Me.TextBox9.TabIndex = 1133
        '
        'Frm_informe_marcaciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(737, 429)
        Me.Controls.Add(Me.Label32)
        Me.Controls.Add(Me.TextBox9)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.imgProcesar)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.TextBox4)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.Toolbar1)
        Me.Controls.Add(Me.dtg_consulta)
        Me.Name = "Frm_informe_marcaciones"
        Me.Text = "Inconsistencia de marcaciones"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Toolbar1.ResumeLayout(False)
        Me.Toolbar1.PerformLayout()
        Me.menStrip.ResumeLayout(False)
        CType(Me.dtg_consulta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgProcesar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Toolbar1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btn_salir As System.Windows.Forms.ToolStripButton
    Friend WithEvents btn_ppal As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnConsultar As System.Windows.Forms.ToolStripButton
    Friend WithEvents cbo_centro As System.Windows.Forms.ComboBox
    Friend WithEvents menStrip As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents itemMod As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents ToolStripSplitButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents dtg_consulta As System.Windows.Forms.DataGridView
    Friend WithEvents OtorgarPermisoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CompromisoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents DetalleDeNovedadescompromisosYPermisosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents EliminarTurnoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents imgProcesar As System.Windows.Forms.PictureBox
    Friend WithEvents cbo_operario As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents IngresarNovedadToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VerMarcacionesDelPeriodoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cbo_fecha_fin As System.Windows.Forms.DateTimePicker
    Friend WithEvents cbo_fecha_ini As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents TextBox9 As System.Windows.Forms.TextBox
End Class
