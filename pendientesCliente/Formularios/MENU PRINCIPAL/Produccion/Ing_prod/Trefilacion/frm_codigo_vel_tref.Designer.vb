<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_codigo_vel_tref
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.dtg_codigos_val = New ComponentFactory.Krypton.Toolkit.KryptonDataGridView()
        Me.txtcodigo = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.KryptonHeader1 = New ComponentFactory.Krypton.Toolkit.KryptonHeader()
        Me.btn_codigo = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.KryptonPalette1 = New ComponentFactory.Krypton.Toolkit.KryptonPalette(Me.components)
        Me.KryptonGroupBox1 = New ComponentFactory.Krypton.Toolkit.KryptonGroupBox()
        Me.cbo_tref = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        Me.KryptonLabel3 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.btn_guardar = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.txtvel = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.txtcod = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.KryptonLabel2 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonLabel1 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonSeparator1 = New ComponentFactory.Krypton.Toolkit.KryptonSeparator()
        Me.bd_cod_vel = New System.Windows.Forms.BindingSource(Me.components)
        Me.pn_modificar = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.btn_modificar = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.txtvel_mod = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.KryptonLabel5 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonContextMenuItems1 = New ComponentFactory.Krypton.Toolkit.KryptonContextMenuItems()
        Me.KryptonContextMenuItem1 = New ComponentFactory.Krypton.Toolkit.KryptonContextMenuItem()
        Me.mn_modificar = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ModificarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.dtg_codigos_val, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonGroupBox1.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonGroupBox1.Panel.SuspendLayout()
        Me.KryptonGroupBox1.SuspendLayout()
        CType(Me.cbo_tref, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonSeparator1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bd_cod_vel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pn_modificar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pn_modificar.SuspendLayout()
        Me.mn_modificar.SuspendLayout()
        Me.SuspendLayout()
        '
        'dtg_codigos_val
        '
        Me.dtg_codigos_val.AccessibleRole = System.Windows.Forms.AccessibleRole.Grip
        Me.dtg_codigos_val.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtg_codigos_val.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtg_codigos_val.ContextMenuStrip = Me.mn_modificar
        Me.dtg_codigos_val.Location = New System.Drawing.Point(12, 265)
        Me.dtg_codigos_val.Name = "dtg_codigos_val"
        Me.dtg_codigos_val.RowHeadersVisible = False
        Me.dtg_codigos_val.Size = New System.Drawing.Size(776, 219)
        Me.dtg_codigos_val.TabIndex = 7
        '
        'txtcodigo
        '
        Me.txtcodigo.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtcodigo.Location = New System.Drawing.Point(284, 240)
        Me.txtcodigo.Name = "txtcodigo"
        Me.txtcodigo.Size = New System.Drawing.Size(109, 23)
        Me.txtcodigo.TabIndex = 10
        '
        'KryptonHeader1
        '
        Me.KryptonHeader1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.KryptonHeader1.Location = New System.Drawing.Point(309, 8)
        Me.KryptonHeader1.Name = "KryptonHeader1"
        Me.KryptonHeader1.Size = New System.Drawing.Size(189, 31)
        Me.KryptonHeader1.TabIndex = 9
        Me.KryptonHeader1.Values.Description = ""
        Me.KryptonHeader1.Values.Heading = "Velocidad codigos"
        '
        'btn_codigo
        '
        Me.btn_codigo.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btn_codigo.Location = New System.Drawing.Point(420, 239)
        Me.btn_codigo.Name = "btn_codigo"
        Me.btn_codigo.Size = New System.Drawing.Size(90, 25)
        Me.btn_codigo.TabIndex = 8
        Me.btn_codigo.Values.Text = "Cargar"
        '
        'KryptonPalette1
        '
        Me.KryptonPalette1.BasePaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Silver
        '
        'KryptonGroupBox1
        '
        Me.KryptonGroupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.KryptonGroupBox1.Location = New System.Drawing.Point(263, 43)
        Me.KryptonGroupBox1.Name = "KryptonGroupBox1"
        '
        'KryptonGroupBox1.Panel
        '
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.cbo_tref)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.KryptonLabel3)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.btn_guardar)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.txtvel)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.txtcod)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.KryptonLabel2)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.KryptonLabel1)
        Me.KryptonGroupBox1.Size = New System.Drawing.Size(275, 174)
        Me.KryptonGroupBox1.TabIndex = 11
        Me.KryptonGroupBox1.Values.Heading = "Crear codigo"
        '
        'cbo_tref
        '
        Me.cbo_tref.DropDownWidth = 100
        Me.cbo_tref.Location = New System.Drawing.Point(133, 60)
        Me.cbo_tref.Name = "cbo_tref"
        Me.cbo_tref.Size = New System.Drawing.Size(100, 21)
        Me.cbo_tref.TabIndex = 6
        Me.cbo_tref.UseWaitCursor = True
        '
        'KryptonLabel3
        '
        Me.KryptonLabel3.Location = New System.Drawing.Point(54, 59)
        Me.KryptonLabel3.Name = "KryptonLabel3"
        Me.KryptonLabel3.Size = New System.Drawing.Size(72, 20)
        Me.KryptonLabel3.TabIndex = 5
        Me.KryptonLabel3.Values.Text = "Trefiladora:"
        '
        'btn_guardar
        '
        Me.btn_guardar.Location = New System.Drawing.Point(96, 121)
        Me.btn_guardar.Name = "btn_guardar"
        Me.btn_guardar.Size = New System.Drawing.Size(90, 25)
        Me.btn_guardar.TabIndex = 4
        Me.btn_guardar.Values.Text = "Guardar"
        '
        'txtvel
        '
        Me.txtvel.Location = New System.Drawing.Point(133, 90)
        Me.txtvel.Name = "txtvel"
        Me.txtvel.Size = New System.Drawing.Size(100, 23)
        Me.txtvel.TabIndex = 3
        '
        'txtcod
        '
        Me.txtcod.Location = New System.Drawing.Point(133, 20)
        Me.txtcod.Name = "txtcod"
        Me.txtcod.Size = New System.Drawing.Size(100, 23)
        Me.txtcod.TabIndex = 2
        '
        'KryptonLabel2
        '
        Me.KryptonLabel2.Location = New System.Drawing.Point(59, 90)
        Me.KryptonLabel2.Name = "KryptonLabel2"
        Me.KryptonLabel2.Size = New System.Drawing.Size(67, 20)
        Me.KryptonLabel2.TabIndex = 1
        Me.KryptonLabel2.Values.Text = "Velocidad:"
        '
        'KryptonLabel1
        '
        Me.KryptonLabel1.Location = New System.Drawing.Point(71, 23)
        Me.KryptonLabel1.Name = "KryptonLabel1"
        Me.KryptonLabel1.Size = New System.Drawing.Size(53, 20)
        Me.KryptonLabel1.TabIndex = 0
        Me.KryptonLabel1.Values.Text = "Codigo:"
        '
        'KryptonSeparator1
        '
        Me.KryptonSeparator1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.KryptonSeparator1.Location = New System.Drawing.Point(-1, 225)
        Me.KryptonSeparator1.Name = "KryptonSeparator1"
        Me.KryptonSeparator1.Size = New System.Drawing.Size(800, 10)
        Me.KryptonSeparator1.TabIndex = 12
        '
        'pn_modificar
        '
        Me.pn_modificar.Controls.Add(Me.btn_modificar)
        Me.pn_modificar.Controls.Add(Me.txtvel_mod)
        Me.pn_modificar.Controls.Add(Me.KryptonLabel5)
        Me.pn_modificar.Location = New System.Drawing.Point(284, 290)
        Me.pn_modificar.Name = "pn_modificar"
        Me.pn_modificar.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Blue
        Me.pn_modificar.Size = New System.Drawing.Size(226, 87)
        Me.pn_modificar.TabIndex = 13
        Me.pn_modificar.Visible = False
        '
        'btn_modificar
        '
        Me.btn_modificar.Location = New System.Drawing.Point(83, 48)
        Me.btn_modificar.Name = "btn_modificar"
        Me.btn_modificar.Size = New System.Drawing.Size(90, 25)
        Me.btn_modificar.TabIndex = 13
        Me.btn_modificar.Values.Text = "Modificar"
        '
        'txtvel_mod
        '
        Me.txtvel_mod.Location = New System.Drawing.Point(109, 19)
        Me.txtvel_mod.Name = "txtvel_mod"
        Me.txtvel_mod.Size = New System.Drawing.Size(100, 23)
        Me.txtvel_mod.TabIndex = 10
        '
        'KryptonLabel5
        '
        Me.KryptonLabel5.Location = New System.Drawing.Point(35, 19)
        Me.KryptonLabel5.Name = "KryptonLabel5"
        Me.KryptonLabel5.Size = New System.Drawing.Size(67, 20)
        Me.KryptonLabel5.TabIndex = 8
        Me.KryptonLabel5.Values.Text = "Velocidad:"
        '
        'KryptonContextMenuItems1
        '
        Me.KryptonContextMenuItems1.Items.AddRange(New ComponentFactory.Krypton.Toolkit.KryptonContextMenuItemBase() {Me.KryptonContextMenuItem1})
        '
        'KryptonContextMenuItem1
        '
        Me.KryptonContextMenuItem1.Text = "Menu Item"
        '
        'mn_modificar
        '
        Me.mn_modificar.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.mn_modificar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ModificarToolStripMenuItem})
        Me.mn_modificar.Name = "ContextMenuStrip1"
        Me.mn_modificar.Size = New System.Drawing.Size(126, 26)
        '
        'ModificarToolStripMenuItem
        '
        Me.ModificarToolStripMenuItem.Image = Global.Spic.My.Resources.Resources.aprobar_buz
        Me.ModificarToolStripMenuItem.Name = "ModificarToolStripMenuItem"
        Me.ModificarToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.ModificarToolStripMenuItem.Text = "Modificar"
        '
        'frm_codigo_vel_tref
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 488)
        Me.Controls.Add(Me.pn_modificar)
        Me.Controls.Add(Me.KryptonSeparator1)
        Me.Controls.Add(Me.KryptonGroupBox1)
        Me.Controls.Add(Me.dtg_codigos_val)
        Me.Controls.Add(Me.txtcodigo)
        Me.Controls.Add(Me.KryptonHeader1)
        Me.Controls.Add(Me.btn_codigo)
        Me.Name = "frm_codigo_vel_tref"
        Me.Text = "Velocidades codigos"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dtg_codigos_val, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonGroupBox1.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox1.Panel.ResumeLayout(False)
        Me.KryptonGroupBox1.Panel.PerformLayout()
        CType(Me.KryptonGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox1.ResumeLayout(False)
        CType(Me.cbo_tref, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonSeparator1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bd_cod_vel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pn_modificar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pn_modificar.ResumeLayout(False)
        Me.pn_modificar.PerformLayout()
        Me.mn_modificar.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtg_codigos_val As ComponentFactory.Krypton.Toolkit.KryptonDataGridView
    Friend WithEvents txtcodigo As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents KryptonHeader1 As ComponentFactory.Krypton.Toolkit.KryptonHeader
    Friend WithEvents btn_codigo As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents KryptonPalette1 As ComponentFactory.Krypton.Toolkit.KryptonPalette
    Friend WithEvents KryptonGroupBox1 As ComponentFactory.Krypton.Toolkit.KryptonGroupBox
    Friend WithEvents btn_guardar As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents txtvel As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents txtcod As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents KryptonLabel2 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel1 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonSeparator1 As ComponentFactory.Krypton.Toolkit.KryptonSeparator
    Friend WithEvents KryptonLabel3 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents cbo_tref As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents bd_cod_vel As BindingSource
    Friend WithEvents pn_modificar As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents btn_modificar As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents txtvel_mod As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents KryptonLabel5 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonContextMenuItems1 As ComponentFactory.Krypton.Toolkit.KryptonContextMenuItems
    Friend WithEvents KryptonContextMenuItem1 As ComponentFactory.Krypton.Toolkit.KryptonContextMenuItem
    Friend WithEvents mn_modificar As ContextMenuStrip
    Friend WithEvents ModificarToolStripMenuItem As ToolStripMenuItem
End Class
