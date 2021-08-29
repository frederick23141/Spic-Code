<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class cboMes
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
        Me.dtg_contable = New ComponentFactory.Krypton.Toolkit.KryptonDataGridView()
        Me.btnCargar = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.btn_Excel = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.btn_ajustar = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.cbo_ds = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        Me.KryptonLabel1 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.cbo_mes = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        Me.KryptonLabel2 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonLabel3 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.cbo_ano = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        CType(Me.dtg_contable, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbo_ds, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbo_mes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbo_ano, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dtg_contable
        '
        Me.dtg_contable.AllowUserToAddRows = False
        Me.dtg_contable.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtg_contable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtg_contable.Location = New System.Drawing.Point(12, 66)
        Me.dtg_contable.Name = "dtg_contable"
        Me.dtg_contable.RowHeadersVisible = False
        Me.dtg_contable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtg_contable.Size = New System.Drawing.Size(776, 372)
        Me.dtg_contable.TabIndex = 0
        '
        'btnCargar
        '
        Me.btnCargar.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnCargar.Location = New System.Drawing.Point(265, 30)
        Me.btnCargar.Name = "btnCargar"
        Me.btnCargar.Size = New System.Drawing.Size(137, 25)
        Me.btnCargar.TabIndex = 1
        Me.btnCargar.Values.Text = "Cargar"
        '
        'btn_Excel
        '
        Me.btn_Excel.Location = New System.Drawing.Point(12, 12)
        Me.btn_Excel.Name = "btn_Excel"
        Me.btn_Excel.Size = New System.Drawing.Size(47, 43)
        Me.btn_Excel.TabIndex = 2
        Me.btn_Excel.Values.Image = Global.Spic.My.Resources.Resources.excel10
        Me.btn_Excel.Values.Text = ""
        '
        'btn_ajustar
        '
        Me.btn_ajustar.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btn_ajustar.Location = New System.Drawing.Point(418, 30)
        Me.btn_ajustar.Name = "btn_ajustar"
        Me.btn_ajustar.Size = New System.Drawing.Size(126, 25)
        Me.btn_ajustar.TabIndex = 3
        Me.btn_ajustar.Values.Text = "Ajustar"
        '
        'cbo_ds
        '
        Me.cbo_ds.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cbo_ds.DropDownWidth = 121
        Me.cbo_ds.Location = New System.Drawing.Point(522, 3)
        Me.cbo_ds.Name = "cbo_ds"
        Me.cbo_ds.Size = New System.Drawing.Size(121, 21)
        Me.cbo_ds.TabIndex = 4
        Me.cbo_ds.Text = "Seleccione"
        '
        'KryptonLabel1
        '
        Me.KryptonLabel1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.KryptonLabel1.Location = New System.Drawing.Point(489, 4)
        Me.KryptonLabel1.Name = "KryptonLabel1"
        Me.KryptonLabel1.Size = New System.Drawing.Size(27, 20)
        Me.KryptonLabel1.TabIndex = 5
        Me.KryptonLabel1.Values.Text = "Ds:"
        '
        'cbo_mes
        '
        Me.cbo_mes.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cbo_mes.DropDownWidth = 84
        Me.cbo_mes.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12"})
        Me.cbo_mes.Location = New System.Drawing.Point(384, 2)
        Me.cbo_mes.Name = "cbo_mes"
        Me.cbo_mes.Size = New System.Drawing.Size(84, 21)
        Me.cbo_mes.TabIndex = 6
        '
        'KryptonLabel2
        '
        Me.KryptonLabel2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.KryptonLabel2.Location = New System.Drawing.Point(342, 3)
        Me.KryptonLabel2.Name = "KryptonLabel2"
        Me.KryptonLabel2.Size = New System.Drawing.Size(36, 20)
        Me.KryptonLabel2.TabIndex = 7
        Me.KryptonLabel2.Values.Text = "Mes:"
        '
        'KryptonLabel3
        '
        Me.KryptonLabel3.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.KryptonLabel3.Location = New System.Drawing.Point(188, 4)
        Me.KryptonLabel3.Name = "KryptonLabel3"
        Me.KryptonLabel3.Size = New System.Drawing.Size(33, 20)
        Me.KryptonLabel3.TabIndex = 8
        Me.KryptonLabel3.Values.Text = "Año"
        '
        'cbo_ano
        '
        Me.cbo_ano.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cbo_ano.DropDownWidth = 78
        Me.cbo_ano.Location = New System.Drawing.Point(228, 2)
        Me.cbo_ano.Name = "cbo_ano"
        Me.cbo_ano.Size = New System.Drawing.Size(78, 21)
        Me.cbo_ano.TabIndex = 9
        '
        'cboMes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.cbo_ano)
        Me.Controls.Add(Me.KryptonLabel3)
        Me.Controls.Add(Me.KryptonLabel2)
        Me.Controls.Add(Me.cbo_mes)
        Me.Controls.Add(Me.KryptonLabel1)
        Me.Controls.Add(Me.cbo_ds)
        Me.Controls.Add(Me.btn_ajustar)
        Me.Controls.Add(Me.btn_Excel)
        Me.Controls.Add(Me.btnCargar)
        Me.Controls.Add(Me.dtg_contable)
        Me.Name = "cboMes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ajuste contable"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dtg_contable, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbo_ds, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbo_mes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbo_ano, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dtg_contable As ComponentFactory.Krypton.Toolkit.KryptonDataGridView
    Friend WithEvents btnCargar As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents btn_Excel As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents btn_ajustar As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents cbo_ds As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents KryptonLabel1 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents cbo_mes As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents KryptonLabel2 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel3 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents cbo_ano As ComponentFactory.Krypton.Toolkit.KryptonComboBox
End Class
