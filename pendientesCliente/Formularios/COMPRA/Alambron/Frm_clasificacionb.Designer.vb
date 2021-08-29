<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_clasificacionb
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
        Me.btncancelar = New System.Windows.Forms.Button()
        Me.cbdescripcion = New System.Windows.Forms.ComboBox()
        Me.btncambiar = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btncancelar
        '
        Me.btncancelar.Location = New System.Drawing.Point(165, 71)
        Me.btncancelar.Name = "btncancelar"
        Me.btncancelar.Size = New System.Drawing.Size(75, 23)
        Me.btncancelar.TabIndex = 8
        Me.btncancelar.Text = "Cancelar"
        Me.btncancelar.UseVisualStyleBackColor = True
        '
        'cbdescripcion
        '
        Me.cbdescripcion.FormattingEnabled = True
        Me.cbdescripcion.Location = New System.Drawing.Point(88, 31)
        Me.cbdescripcion.Name = "cbdescripcion"
        Me.cbdescripcion.Size = New System.Drawing.Size(121, 21)
        Me.cbdescripcion.TabIndex = 7
        '
        'btncambiar
        '
        Me.btncambiar.Location = New System.Drawing.Point(74, 71)
        Me.btncambiar.Name = "btncambiar"
        Me.btncambiar.Size = New System.Drawing.Size(75, 23)
        Me.btncambiar.TabIndex = 6
        Me.btncambiar.Text = "Cambiar"
        Me.btncambiar.UseVisualStyleBackColor = True
        '
        'Frm_clasificacionb
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(314, 114)
        Me.Controls.Add(Me.btncancelar)
        Me.Controls.Add(Me.cbdescripcion)
        Me.Controls.Add(Me.btncambiar)
        Me.Name = "Frm_clasificacionb"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Frm_clasificacionb"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btncancelar As System.Windows.Forms.Button
    Friend WithEvents cbdescripcion As System.Windows.Forms.ComboBox
    Friend WithEvents btncambiar As System.Windows.Forms.Button
End Class
