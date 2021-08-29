<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Clientes_Sin_Clasificar
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
        Me.dtg_Sin_Clasificar = New System.Windows.Forms.DataGridView()
        CType(Me.dtg_Sin_Clasificar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dtg_Sin_Clasificar
        '
        Me.dtg_Sin_Clasificar.AllowUserToAddRows = False
        Me.dtg_Sin_Clasificar.AllowUserToDeleteRows = False
        Me.dtg_Sin_Clasificar.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtg_Sin_Clasificar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dtg_Sin_Clasificar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtg_Sin_Clasificar.Location = New System.Drawing.Point(0, 0)
        Me.dtg_Sin_Clasificar.Name = "dtg_Sin_Clasificar"
        Me.dtg_Sin_Clasificar.ReadOnly = True
        Me.dtg_Sin_Clasificar.RowHeadersVisible = False
        Me.dtg_Sin_Clasificar.Size = New System.Drawing.Size(797, 424)
        Me.dtg_Sin_Clasificar.TabIndex = 0
        '
        'frm_Clientes_Sin_Clasificar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(797, 424)
        Me.Controls.Add(Me.dtg_Sin_Clasificar)
        Me.Name = "frm_Clientes_Sin_Clasificar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Clientes sin clasificar"
        CType(Me.dtg_Sin_Clasificar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dtg_Sin_Clasificar As System.Windows.Forms.DataGridView
End Class
