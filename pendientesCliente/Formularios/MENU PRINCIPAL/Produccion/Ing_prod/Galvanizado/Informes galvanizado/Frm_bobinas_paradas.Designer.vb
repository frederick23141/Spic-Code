<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_bobinas_paradas
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
        Me.Dgvbobina = New System.Windows.Forms.DataGridView()
        CType(Me.Dgvbobina, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Dgvbobina
        '
        Me.Dgvbobina.AllowUserToAddRows = False
        Me.Dgvbobina.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgvbobina.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgvbobina.Location = New System.Drawing.Point(0, 0)
        Me.Dgvbobina.Name = "Dgvbobina"
        Me.Dgvbobina.RowHeadersVisible = False
        Me.Dgvbobina.Size = New System.Drawing.Size(653, 294)
        Me.Dgvbobina.TabIndex = 2
        '
        'Frm_bobinas_paradas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(653, 294)
        Me.Controls.Add(Me.Dgvbobina)
        Me.Name = "Frm_bobinas_paradas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Bobinas paradas"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.Dgvbobina, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Dgvbobina As System.Windows.Forms.DataGridView
End Class
