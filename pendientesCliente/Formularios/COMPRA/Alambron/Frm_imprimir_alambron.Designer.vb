<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_imprimir_alambron
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
        Me.lstImpresorasInstaladas = New System.Windows.Forms.ListBox()
        Me.SuspendLayout()
        '
        'lstImpresorasInstaladas
        '
        Me.lstImpresorasInstaladas.FormattingEnabled = True
        Me.lstImpresorasInstaladas.Location = New System.Drawing.Point(12, 12)
        Me.lstImpresorasInstaladas.Name = "lstImpresorasInstaladas"
        Me.lstImpresorasInstaladas.Size = New System.Drawing.Size(290, 160)
        Me.lstImpresorasInstaladas.TabIndex = 8
        '
        'Frm_imprimir_alambron
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(314, 180)
        Me.Controls.Add(Me.lstImpresorasInstaladas)
        Me.Name = "Frm_imprimir_alambron"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Seleccione impresora zebra"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lstImpresorasInstaladas As System.Windows.Forms.ListBox
End Class
