<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_chatarra_tref
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
        Me.KryptonBreadCrumbItem1 = New ComponentFactory.Krypton.Toolkit.KryptonBreadCrumbItem()
        Me.KryptonBreadCrumbItem2 = New ComponentFactory.Krypton.Toolkit.KryptonBreadCrumbItem()
        Me.KryptonBreadCrumbItem3 = New ComponentFactory.Krypton.Toolkit.KryptonBreadCrumbItem()
        Me.KryptonBreadCrumbItem5 = New ComponentFactory.Krypton.Toolkit.KryptonBreadCrumbItem()
        Me.KryptonBreadCrumbItem4 = New ComponentFactory.Krypton.Toolkit.KryptonBreadCrumbItem()
        Me.caption_Tref = New ComponentFactory.Krypton.Toolkit.KryptonGroupBox()
        Me.btnagregar = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.txt_Kilos = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.cbo_defecto = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        Me.KryptonLabel2 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonLabel1 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.dtg_chatarra = New ComponentFactory.Krypton.Toolkit.KryptonDataGridView()
        Me.KryptonManager1 = New ComponentFactory.Krypton.Toolkit.KryptonManager(Me.components)
        CType(Me.caption_Tref, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.caption_Tref.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.caption_Tref.Panel.SuspendLayout()
        Me.caption_Tref.SuspendLayout()
        CType(Me.cbo_defecto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtg_chatarra, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'KryptonBreadCrumbItem1
        '
        Me.KryptonBreadCrumbItem1.Items.AddRange(New ComponentFactory.Krypton.Toolkit.KryptonBreadCrumbItem() {Me.KryptonBreadCrumbItem2})
        Me.KryptonBreadCrumbItem1.ShortText = "numero 1"
        '
        'KryptonBreadCrumbItem2
        '
        Me.KryptonBreadCrumbItem2.Items.AddRange(New ComponentFactory.Krypton.Toolkit.KryptonBreadCrumbItem() {Me.KryptonBreadCrumbItem3})
        Me.KryptonBreadCrumbItem2.ShortText = "item a"
        '
        'KryptonBreadCrumbItem3
        '
        Me.KryptonBreadCrumbItem3.ShortText = "hijo a"
        '
        'KryptonBreadCrumbItem5
        '
        Me.KryptonBreadCrumbItem5.ShortText = "numero 2"
        '
        'KryptonBreadCrumbItem4
        '
        Me.KryptonBreadCrumbItem4.ShortText = "ListItem"
        '
        'caption_Tref
        '
        Me.caption_Tref.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.caption_Tref.Location = New System.Drawing.Point(29, 12)
        Me.caption_Tref.Name = "caption_Tref"
        '
        'caption_Tref.Panel
        '
        Me.caption_Tref.Panel.Controls.Add(Me.btnagregar)
        Me.caption_Tref.Panel.Controls.Add(Me.txt_Kilos)
        Me.caption_Tref.Panel.Controls.Add(Me.cbo_defecto)
        Me.caption_Tref.Panel.Controls.Add(Me.KryptonLabel2)
        Me.caption_Tref.Panel.Controls.Add(Me.KryptonLabel1)
        Me.caption_Tref.Size = New System.Drawing.Size(737, 151)
        Me.caption_Tref.TabIndex = 0
        Me.caption_Tref.Values.Heading = "Ingresar chatarra"
        '
        'btnagregar
        '
        Me.btnagregar.Location = New System.Drawing.Point(335, 86)
        Me.btnagregar.Name = "btnagregar"
        Me.btnagregar.Size = New System.Drawing.Size(90, 25)
        Me.btnagregar.TabIndex = 4
        Me.btnagregar.Values.Text = "Agregar"
        '
        'txt_Kilos
        '
        Me.txt_Kilos.Location = New System.Drawing.Point(310, 48)
        Me.txt_Kilos.Name = "txt_Kilos"
        Me.txt_Kilos.Size = New System.Drawing.Size(164, 23)
        Me.txt_Kilos.TabIndex = 3
        '
        'cbo_defecto
        '
        Me.cbo_defecto.DropDownWidth = 164
        Me.cbo_defecto.Location = New System.Drawing.Point(310, 11)
        Me.cbo_defecto.Name = "cbo_defecto"
        Me.cbo_defecto.Size = New System.Drawing.Size(164, 21)
        Me.cbo_defecto.TabIndex = 2
        Me.cbo_defecto.Text = "Seleccione"
        '
        'KryptonLabel2
        '
        Me.KryptonLabel2.Location = New System.Drawing.Point(265, 49)
        Me.KryptonLabel2.Name = "KryptonLabel2"
        Me.KryptonLabel2.Size = New System.Drawing.Size(39, 20)
        Me.KryptonLabel2.TabIndex = 1
        Me.KryptonLabel2.Values.Text = "Kilos:"
        '
        'KryptonLabel1
        '
        Me.KryptonLabel1.Location = New System.Drawing.Point(248, 11)
        Me.KryptonLabel1.Name = "KryptonLabel1"
        Me.KryptonLabel1.Size = New System.Drawing.Size(56, 20)
        Me.KryptonLabel1.TabIndex = 0
        Me.KryptonLabel1.Values.Text = "Defecto:"
        '
        'dtg_chatarra
        '
        Me.dtg_chatarra.AllowUserToAddRows = False
        Me.dtg_chatarra.AllowUserToDeleteRows = False
        Me.dtg_chatarra.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtg_chatarra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtg_chatarra.Location = New System.Drawing.Point(12, 169)
        Me.dtg_chatarra.Name = "dtg_chatarra"
        Me.dtg_chatarra.ReadOnly = True
        Me.dtg_chatarra.RowHeadersVisible = False
        Me.dtg_chatarra.Size = New System.Drawing.Size(776, 315)
        Me.dtg_chatarra.TabIndex = 1
        '
        'KryptonManager1
        '
        Me.KryptonManager1.GlobalPaletteMode = ComponentFactory.Krypton.Toolkit.PaletteModeManager.Office2010Silver
        '
        'frm_chatarra_tref
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 496)
        Me.Controls.Add(Me.dtg_chatarra)
        Me.Controls.Add(Me.caption_Tref)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_chatarra_tref"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Modulo de chatarra de trefilación"
        CType(Me.caption_Tref.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.caption_Tref.Panel.ResumeLayout(False)
        Me.caption_Tref.Panel.PerformLayout()
        CType(Me.caption_Tref, System.ComponentModel.ISupportInitialize).EndInit()
        Me.caption_Tref.ResumeLayout(False)
        CType(Me.cbo_defecto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtg_chatarra, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents KryptonBreadCrumbItem1 As ComponentFactory.Krypton.Toolkit.KryptonBreadCrumbItem
    Friend WithEvents KryptonBreadCrumbItem2 As ComponentFactory.Krypton.Toolkit.KryptonBreadCrumbItem
    Friend WithEvents KryptonBreadCrumbItem3 As ComponentFactory.Krypton.Toolkit.KryptonBreadCrumbItem
    Friend WithEvents KryptonBreadCrumbItem5 As ComponentFactory.Krypton.Toolkit.KryptonBreadCrumbItem
    Friend WithEvents KryptonBreadCrumbItem4 As ComponentFactory.Krypton.Toolkit.KryptonBreadCrumbItem
    Friend WithEvents caption_Tref As ComponentFactory.Krypton.Toolkit.KryptonGroupBox
    Friend WithEvents KryptonLabel2 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel1 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents dtg_chatarra As ComponentFactory.Krypton.Toolkit.KryptonDataGridView
    Friend WithEvents txt_Kilos As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents cbo_defecto As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents btnagregar As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents KryptonManager1 As ComponentFactory.Krypton.Toolkit.KryptonManager
End Class
