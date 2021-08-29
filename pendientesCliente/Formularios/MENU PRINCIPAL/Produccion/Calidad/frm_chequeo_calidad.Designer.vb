<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_chequeo_calidad
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
        Me.blinding_Chequeo = New System.Windows.Forms.BindingSource(Me.components)
        Me.dtg_Chequeo = New System.Windows.Forms.DataGridView()
        Me.btnAprobar = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.btnDesapro = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.txt_consecutivo = New System.Windows.Forms.TextBox()
        Me.lbl_consecutivo = New System.Windows.Forms.Label()
        Me.KryptonButton1 = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        CType(Me.blinding_Chequeo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtg_Chequeo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dtg_Chequeo
        '
        Me.dtg_Chequeo.AllowUserToDeleteRows = False
        Me.dtg_Chequeo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtg_Chequeo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtg_Chequeo.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.btnAprobar, Me.btnDesapro})
        Me.dtg_Chequeo.Location = New System.Drawing.Point(12, 50)
        Me.dtg_Chequeo.Name = "dtg_Chequeo"
        Me.dtg_Chequeo.ReadOnly = True
        Me.dtg_Chequeo.RowHeadersVisible = False
        Me.dtg_Chequeo.Size = New System.Drawing.Size(787, 394)
        Me.dtg_Chequeo.TabIndex = 0
        '
        'btnAprobar
        '
        Me.btnAprobar.HeaderText = "Aprobar"
        Me.btnAprobar.Name = "btnAprobar"
        Me.btnAprobar.ReadOnly = True
        Me.btnAprobar.Text = "Aprobar"
        Me.btnAprobar.UseColumnTextForButtonValue = True
        '
        'btnDesapro
        '
        Me.btnDesapro.HeaderText = "Desaprobar"
        Me.btnDesapro.Name = "btnDesapro"
        Me.btnDesapro.ReadOnly = True
        Me.btnDesapro.Text = "Desaprobar"
        Me.btnDesapro.UseColumnTextForButtonValue = True
        '
        'txt_consecutivo
        '
        Me.txt_consecutivo.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_consecutivo.Location = New System.Drawing.Point(391, 24)
        Me.txt_consecutivo.Name = "txt_consecutivo"
        Me.txt_consecutivo.Size = New System.Drawing.Size(100, 20)
        Me.txt_consecutivo.TabIndex = 1
        '
        'lbl_consecutivo
        '
        Me.lbl_consecutivo.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lbl_consecutivo.AutoSize = True
        Me.lbl_consecutivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_consecutivo.Location = New System.Drawing.Point(298, 27)
        Me.lbl_consecutivo.Name = "lbl_consecutivo"
        Me.lbl_consecutivo.Size = New System.Drawing.Size(77, 13)
        Me.lbl_consecutivo.TabIndex = 2
        Me.lbl_consecutivo.Text = "Consecutivo"
        '
        'KryptonButton1
        '
        Me.KryptonButton1.Location = New System.Drawing.Point(179, 12)
        Me.KryptonButton1.Name = "KryptonButton1"
        Me.KryptonButton1.Size = New System.Drawing.Size(90, 25)
        Me.KryptonButton1.TabIndex = 3
        Me.KryptonButton1.Values.Text = "KryptonButton1"
        '
        'frm_chequeo_calidad
        '
        Me.AccessibleName = "Chequeo calidad tref"
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.KryptonButton1)
        Me.Controls.Add(Me.lbl_consecutivo)
        Me.Controls.Add(Me.txt_consecutivo)
        Me.Controls.Add(Me.dtg_Chequeo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "frm_chequeo_calidad"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Chequeo calidad tref"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.blinding_Chequeo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtg_Chequeo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents blinding_Chequeo As BindingSource
    Friend WithEvents dtg_Chequeo As DataGridView
    Friend WithEvents txt_consecutivo As TextBox
    Friend WithEvents lbl_consecutivo As Label
    Friend WithEvents btnAprobar As DataGridViewButtonColumn
    Friend WithEvents btnDesapro As DataGridViewButtonColumn
    Friend WithEvents KryptonButton1 As ComponentFactory.Krypton.Toolkit.KryptonButton
End Class
