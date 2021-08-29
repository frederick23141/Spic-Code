<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_notas_prod
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
        Me.dtg_nota = New System.Windows.Forms.DataGridView()
        Me.ctm_nota_prod = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.IngresarNotaProdToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.dtg_nota, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ctm_nota_prod.SuspendLayout()
        Me.SuspendLayout()
        '
        'dtg_nota
        '
        Me.dtg_nota.AllowUserToAddRows = False
        Me.dtg_nota.AllowUserToDeleteRows = False
        Me.dtg_nota.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtg_nota.ContextMenuStrip = Me.ctm_nota_prod
        Me.dtg_nota.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtg_nota.Location = New System.Drawing.Point(0, 0)
        Me.dtg_nota.Name = "dtg_nota"
        Me.dtg_nota.ReadOnly = True
        Me.dtg_nota.RowHeadersVisible = False
        Me.dtg_nota.Size = New System.Drawing.Size(499, 292)
        Me.dtg_nota.TabIndex = 0
        '
        'ctm_nota_prod
        '
        Me.ctm_nota_prod.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.IngresarNotaProdToolStripMenuItem})
        Me.ctm_nota_prod.Name = "ctm_nota_prod"
        Me.ctm_nota_prod.Size = New System.Drawing.Size(172, 48)
        '
        'IngresarNotaProdToolStripMenuItem
        '
        Me.IngresarNotaProdToolStripMenuItem.Image = Global.Spic.My.Resources.Resources.ico_ok1
        Me.IngresarNotaProdToolStripMenuItem.Name = "IngresarNotaProdToolStripMenuItem"
        Me.IngresarNotaProdToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.IngresarNotaProdToolStripMenuItem.Text = "Ingresar nota prod"
        '
        'frm_notas_prod
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(499, 292)
        Me.Controls.Add(Me.dtg_nota)
        Me.Name = "frm_notas_prod"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Notas prod"
        CType(Me.dtg_nota, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ctm_nota_prod.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dtg_nota As System.Windows.Forms.DataGridView
    Friend WithEvents ctm_nota_prod As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents IngresarNotaProdToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
