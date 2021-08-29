<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Auditoria_tref
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
        Me.dtg_auditoria_tref = New System.Windows.Forms.DataGridView()
        Me.KryptonBreadCrumbItem2 = New ComponentFactory.Krypton.Toolkit.KryptonBreadCrumbItem()
        Me.KryptonBreadCrumbItem3 = New ComponentFactory.Krypton.Toolkit.KryptonBreadCrumbItem()
        Me.KryptonBreadCrumbItem4 = New ComponentFactory.Krypton.Toolkit.KryptonBreadCrumbItem()
        Me.txt_cargar = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.cbo_ano = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        Me.KryptonLabel1 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.cbo_mes = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        Me.KryptonLabel2 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.cbo_tref = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        Me.KryptonLabel3 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        CType(Me.dtg_auditoria_tref, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbo_ano, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbo_mes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbo_tref, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dtg_auditoria_tref
        '
        Me.dtg_auditoria_tref.AllowUserToAddRows = False
        Me.dtg_auditoria_tref.AllowUserToDeleteRows = False
        Me.dtg_auditoria_tref.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtg_auditoria_tref.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtg_auditoria_tref.Location = New System.Drawing.Point(12, 67)
        Me.dtg_auditoria_tref.Name = "dtg_auditoria_tref"
        Me.dtg_auditoria_tref.RowHeadersVisible = False
        Me.dtg_auditoria_tref.Size = New System.Drawing.Size(784, 371)
        Me.dtg_auditoria_tref.TabIndex = 0
        '
        'KryptonBreadCrumbItem2
        '
        Me.KryptonBreadCrumbItem2.ShortText = "Produccion"
        '
        'KryptonBreadCrumbItem3
        '
        Me.KryptonBreadCrumbItem3.ShortText = "ListItem"
        '
        'KryptonBreadCrumbItem4
        '
        Me.KryptonBreadCrumbItem4.ShortText = "ListItem"
        '
        'txt_cargar
        '
        Me.txt_cargar.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_cargar.Location = New System.Drawing.Point(334, 8)
        Me.txt_cargar.Name = "txt_cargar"
        Me.txt_cargar.Size = New System.Drawing.Size(96, 25)
        Me.txt_cargar.TabIndex = 1
        Me.txt_cargar.Values.Text = "Cargar"
        '
        'cbo_ano
        '
        Me.cbo_ano.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cbo_ano.DropDownWidth = 101
        Me.cbo_ano.Location = New System.Drawing.Point(227, 11)
        Me.cbo_ano.Name = "cbo_ano"
        Me.cbo_ano.Size = New System.Drawing.Size(101, 21)
        Me.cbo_ano.TabIndex = 2
        Me.cbo_ano.Text = "Seleccione"
        '
        'KryptonLabel1
        '
        Me.KryptonLabel1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.KryptonLabel1.Location = New System.Drawing.Point(186, 12)
        Me.KryptonLabel1.Name = "KryptonLabel1"
        Me.KryptonLabel1.Size = New System.Drawing.Size(35, 20)
        Me.KryptonLabel1.TabIndex = 3
        Me.KryptonLabel1.Values.Text = "Ano:"
        '
        'cbo_mes
        '
        Me.cbo_mes.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cbo_mes.DropDownWidth = 121
        Me.cbo_mes.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12"})
        Me.cbo_mes.Location = New System.Drawing.Point(478, 12)
        Me.cbo_mes.Name = "cbo_mes"
        Me.cbo_mes.Size = New System.Drawing.Size(72, 21)
        Me.cbo_mes.TabIndex = 4
        Me.cbo_mes.Text = "Seleccione"
        '
        'KryptonLabel2
        '
        Me.KryptonLabel2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.KryptonLabel2.Location = New System.Drawing.Point(436, 12)
        Me.KryptonLabel2.Name = "KryptonLabel2"
        Me.KryptonLabel2.Size = New System.Drawing.Size(36, 20)
        Me.KryptonLabel2.TabIndex = 5
        Me.KryptonLabel2.Values.Text = "Mes:"
        '
        'cbo_tref
        '
        Me.cbo_tref.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cbo_tref.DropDownWidth = 148
        Me.cbo_tref.Location = New System.Drawing.Point(366, 40)
        Me.cbo_tref.Name = "cbo_tref"
        Me.cbo_tref.Size = New System.Drawing.Size(148, 21)
        Me.cbo_tref.TabIndex = 6
        Me.cbo_tref.Text = "Todas"
        '
        'KryptonLabel3
        '
        Me.KryptonLabel3.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.KryptonLabel3.Location = New System.Drawing.Point(288, 41)
        Me.KryptonLabel3.Name = "KryptonLabel3"
        Me.KryptonLabel3.Size = New System.Drawing.Size(72, 20)
        Me.KryptonLabel3.TabIndex = 7
        Me.KryptonLabel3.Values.Text = "Trefiladora:"
        '
        'frm_Auditoria_tref
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.KryptonLabel3)
        Me.Controls.Add(Me.cbo_tref)
        Me.Controls.Add(Me.KryptonLabel2)
        Me.Controls.Add(Me.cbo_mes)
        Me.Controls.Add(Me.KryptonLabel1)
        Me.Controls.Add(Me.cbo_ano)
        Me.Controls.Add(Me.txt_cargar)
        Me.Controls.Add(Me.dtg_auditoria_tref)
        Me.Name = "frm_Auditoria_tref"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Auditoria de trefilación "
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dtg_auditoria_tref, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbo_ano, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbo_mes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbo_tref, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dtg_auditoria_tref As DataGridView
    Friend WithEvents KryptonBreadCrumbItem2 As ComponentFactory.Krypton.Toolkit.KryptonBreadCrumbItem
    Friend WithEvents KryptonBreadCrumbItem3 As ComponentFactory.Krypton.Toolkit.KryptonBreadCrumbItem
    Friend WithEvents KryptonBreadCrumbItem4 As ComponentFactory.Krypton.Toolkit.KryptonBreadCrumbItem
    Friend WithEvents txt_cargar As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents cbo_ano As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents KryptonLabel1 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents cbo_mes As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents KryptonLabel2 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents cbo_tref As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents KryptonLabel3 As ComponentFactory.Krypton.Toolkit.KryptonLabel
End Class
