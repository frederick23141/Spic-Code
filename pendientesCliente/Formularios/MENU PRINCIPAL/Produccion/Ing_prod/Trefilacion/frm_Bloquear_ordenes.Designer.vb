<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Bloquear_ordenes
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
        Me.btn_bloquear = New System.Windows.Forms.Button()
        Me.txt_nota = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'btn_bloquear
        '
        Me.btn_bloquear.Location = New System.Drawing.Point(74, 177)
        Me.btn_bloquear.Name = "btn_bloquear"
        Me.btn_bloquear.Size = New System.Drawing.Size(75, 23)
        Me.btn_bloquear.TabIndex = 1196
        Me.btn_bloquear.Text = "Guardar"
        Me.btn_bloquear.UseVisualStyleBackColor = True
        '
        'txt_nota
        '
        Me.txt_nota.Location = New System.Drawing.Point(34, 12)
        Me.txt_nota.Multiline = True
        Me.txt_nota.Name = "txt_nota"
        Me.txt_nota.Size = New System.Drawing.Size(167, 159)
        Me.txt_nota.TabIndex = 1197
        '
        'frm_Bloquear_ordenes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(237, 212)
        Me.Controls.Add(Me.txt_nota)
        Me.Controls.Add(Me.btn_bloquear)
        Me.Name = "frm_Bloquear_ordenes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Guardar notas"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn_bloquear As System.Windows.Forms.Button
    Friend WithEvents txt_nota As System.Windows.Forms.TextBox
End Class
