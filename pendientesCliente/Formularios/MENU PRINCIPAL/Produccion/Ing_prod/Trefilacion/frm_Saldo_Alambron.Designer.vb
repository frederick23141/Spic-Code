<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Saldo_Alambron
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
        Me.gb_Filtro = New ComponentFactory.Krypton.Toolkit.KryptonGroupBox()
        Me.cbo_tref = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        Me.lbl_tref = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.btn_cargar = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.cbo_mes = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        Me.cbo_Ano = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        Me.lbl_mes = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.lbl_ano = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.dtg_Alambron = New ComponentFactory.Krypton.Toolkit.KryptonDataGridView()
        CType(Me.gb_Filtro, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gb_Filtro.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gb_Filtro.Panel.SuspendLayout()
        Me.gb_Filtro.SuspendLayout()
        CType(Me.cbo_tref, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbo_mes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbo_Ano, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtg_Alambron, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gb_Filtro
        '
        Me.gb_Filtro.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.gb_Filtro.Location = New System.Drawing.Point(263, 5)
        Me.gb_Filtro.Name = "gb_Filtro"
        '
        'gb_Filtro.Panel
        '
        Me.gb_Filtro.Panel.Controls.Add(Me.cbo_tref)
        Me.gb_Filtro.Panel.Controls.Add(Me.lbl_tref)
        Me.gb_Filtro.Panel.Controls.Add(Me.btn_cargar)
        Me.gb_Filtro.Panel.Controls.Add(Me.cbo_mes)
        Me.gb_Filtro.Panel.Controls.Add(Me.cbo_Ano)
        Me.gb_Filtro.Panel.Controls.Add(Me.lbl_mes)
        Me.gb_Filtro.Panel.Controls.Add(Me.lbl_ano)
        Me.gb_Filtro.Size = New System.Drawing.Size(280, 179)
        Me.gb_Filtro.TabIndex = 2
        Me.gb_Filtro.Values.Heading = "Selección:"
        '
        'cbo_tref
        '
        Me.cbo_tref.DropDownWidth = 141
        Me.cbo_tref.Location = New System.Drawing.Point(105, 86)
        Me.cbo_tref.Name = "cbo_tref"
        Me.cbo_tref.Size = New System.Drawing.Size(141, 21)
        Me.cbo_tref.TabIndex = 4
        '
        'lbl_tref
        '
        Me.lbl_tref.Location = New System.Drawing.Point(17, 87)
        Me.lbl_tref.Name = "lbl_tref"
        Me.lbl_tref.Size = New System.Drawing.Size(72, 20)
        Me.lbl_tref.TabIndex = 7
        Me.lbl_tref.Values.Text = "Trefiladora:"
        '
        'btn_cargar
        '
        Me.btn_cargar.Location = New System.Drawing.Point(88, 113)
        Me.btn_cargar.Name = "btn_cargar"
        Me.btn_cargar.Size = New System.Drawing.Size(102, 25)
        Me.btn_cargar.TabIndex = 3
        Me.btn_cargar.Values.Text = "Cargar"
        '
        'cbo_mes
        '
        Me.cbo_mes.DropDownWidth = 141
        Me.cbo_mes.Location = New System.Drawing.Point(105, 48)
        Me.cbo_mes.Name = "cbo_mes"
        Me.cbo_mes.Size = New System.Drawing.Size(141, 21)
        Me.cbo_mes.TabIndex = 6
        '
        'cbo_Ano
        '
        Me.cbo_Ano.DropDownWidth = 141
        Me.cbo_Ano.Location = New System.Drawing.Point(105, 11)
        Me.cbo_Ano.Name = "cbo_Ano"
        Me.cbo_Ano.Size = New System.Drawing.Size(141, 21)
        Me.cbo_Ano.TabIndex = 5
        '
        'lbl_mes
        '
        Me.lbl_mes.Location = New System.Drawing.Point(50, 49)
        Me.lbl_mes.Name = "lbl_mes"
        Me.lbl_mes.Size = New System.Drawing.Size(36, 20)
        Me.lbl_mes.TabIndex = 4
        Me.lbl_mes.Values.Text = "Mes:"
        '
        'lbl_ano
        '
        Me.lbl_ano.Location = New System.Drawing.Point(51, 12)
        Me.lbl_ano.Name = "lbl_ano"
        Me.lbl_ano.Size = New System.Drawing.Size(35, 20)
        Me.lbl_ano.TabIndex = 3
        Me.lbl_ano.Values.Text = "Año:"
        '
        'dtg_Alambron
        '
        Me.dtg_Alambron.AllowUserToAddRows = False
        Me.dtg_Alambron.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtg_Alambron.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtg_Alambron.Location = New System.Drawing.Point(12, 190)
        Me.dtg_Alambron.Name = "dtg_Alambron"
        Me.dtg_Alambron.RowHeadersVisible = False
        Me.dtg_Alambron.Size = New System.Drawing.Size(776, 262)
        Me.dtg_Alambron.TabIndex = 3
        '
        'frm_Saldo_Alambron
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 464)
        Me.Controls.Add(Me.dtg_Alambron)
        Me.Controls.Add(Me.gb_Filtro)
        Me.Name = "frm_Saldo_Alambron"
        Me.Text = "Control saldo de alambron"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.gb_Filtro.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gb_Filtro.Panel.ResumeLayout(False)
        Me.gb_Filtro.Panel.PerformLayout()
        CType(Me.gb_Filtro, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gb_Filtro.ResumeLayout(False)
        CType(Me.cbo_tref, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbo_mes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbo_Ano, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtg_Alambron, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents gb_Filtro As ComponentFactory.Krypton.Toolkit.KryptonGroupBox
    Friend WithEvents btn_cargar As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents cbo_mes As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents cbo_Ano As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents lbl_mes As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents lbl_ano As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents dtg_Alambron As ComponentFactory.Krypton.Toolkit.KryptonDataGridView
    Friend WithEvents cbo_tref As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents lbl_tref As ComponentFactory.Krypton.Toolkit.KryptonLabel
End Class
