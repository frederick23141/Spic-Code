<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMaeGestMod
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
        Me.dtgMaestro = New System.Windows.Forms.DataGridView()
        Me.btnNew = New System.Windows.Forms.DataGridViewImageColumn()
        Me.btnSave = New System.Windows.Forms.DataGridViewImageColumn()
        Me.btnDelete = New System.Windows.Forms.DataGridViewImageColumn()
        CType(Me.dtgMaestro, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dtgMaestro
        '
        Me.dtgMaestro.AllowUserToAddRows = False
        Me.dtgMaestro.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtgMaestro.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dtgMaestro.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dtgMaestro.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.dtgMaestro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgMaestro.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.btnNew, Me.btnSave, Me.btnDelete})
        Me.dtgMaestro.Location = New System.Drawing.Point(12, 12)
        Me.dtgMaestro.Name = "dtgMaestro"
        Me.dtgMaestro.RowHeadersVisible = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(135, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(179, Byte), Integer))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.SteelBlue
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        Me.dtgMaestro.RowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dtgMaestro.Size = New System.Drawing.Size(521, 362)
        Me.dtgMaestro.TabIndex = 1031
        '
        'btnNew
        '
        Me.btnNew.Frozen = True
        Me.btnNew.HeaderText = ""
        Me.btnNew.Image = Global.Spic.My.Resources.Resources.nuevo
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Width = 5
        '
        'btnSave
        '
        Me.btnSave.Frozen = True
        Me.btnSave.HeaderText = ""
        Me.btnSave.Image = Global.Spic.My.Resources.Resources.save_16
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Width = 5
        '
        'btnDelete
        '
        Me.btnDelete.Frozen = True
        Me.btnDelete.HeaderText = ""
        Me.btnDelete.Image = Global.Spic.My.Resources.Resources.x
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Width = 5
        '
        'FrmMaeGestMod
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(545, 386)
        Me.Controls.Add(Me.dtgMaestro)
        Me.Name = "FrmMaeGestMod"
        Me.Text = "Maestro"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dtgMaestro, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dtgMaestro As System.Windows.Forms.DataGridView
    Friend WithEvents btnNew As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents btnSave As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents btnDelete As System.Windows.Forms.DataGridViewImageColumn
End Class
