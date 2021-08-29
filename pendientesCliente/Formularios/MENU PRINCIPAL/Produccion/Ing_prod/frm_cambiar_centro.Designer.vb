<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_cambiar_centro
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
        Me.cbo_operario = New System.Windows.Forms.ComboBox()
        Me.cbo_centro = New System.Windows.Forms.ComboBox()
        Me.lbl_empleado = New System.Windows.Forms.Label()
        Me.lblcentro = New System.Windows.Forms.Label()
        Me.btn_mod = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'cbo_operario
        '
        Me.cbo_operario.FormattingEnabled = True
        Me.cbo_operario.Location = New System.Drawing.Point(105, 71)
        Me.cbo_operario.Name = "cbo_operario"
        Me.cbo_operario.Size = New System.Drawing.Size(136, 21)
        Me.cbo_operario.TabIndex = 0
        '
        'cbo_centro
        '
        Me.cbo_centro.FormattingEnabled = True
        Me.cbo_centro.Location = New System.Drawing.Point(102, 140)
        Me.cbo_centro.Name = "cbo_centro"
        Me.cbo_centro.Size = New System.Drawing.Size(136, 21)
        Me.cbo_centro.TabIndex = 1
        '
        'lbl_empleado
        '
        Me.lbl_empleado.AutoSize = True
        Me.lbl_empleado.Location = New System.Drawing.Point(45, 74)
        Me.lbl_empleado.Name = "lbl_empleado"
        Me.lbl_empleado.Size = New System.Drawing.Size(57, 13)
        Me.lbl_empleado.TabIndex = 2
        Me.lbl_empleado.Text = "Empleado:"
        '
        'lblcentro
        '
        Me.lblcentro.AutoSize = True
        Me.lblcentro.Location = New System.Drawing.Point(51, 145)
        Me.lblcentro.Name = "lblcentro"
        Me.lblcentro.Size = New System.Drawing.Size(41, 13)
        Me.lblcentro.TabIndex = 3
        Me.lblcentro.Text = "Centro:"
        '
        'btn_mod
        '
        Me.btn_mod.Location = New System.Drawing.Point(102, 209)
        Me.btn_mod.Name = "btn_mod"
        Me.btn_mod.Size = New System.Drawing.Size(75, 23)
        Me.btn_mod.TabIndex = 4
        Me.btn_mod.Text = "Modificar"
        Me.btn_mod.UseVisualStyleBackColor = True
        '
        'frm_cambiar_centro
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 261)
        Me.Controls.Add(Me.btn_mod)
        Me.Controls.Add(Me.lblcentro)
        Me.Controls.Add(Me.lbl_empleado)
        Me.Controls.Add(Me.cbo_centro)
        Me.Controls.Add(Me.cbo_operario)
        Me.MaximizeBox = False
        Me.Name = "frm_cambiar_centro"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cambiar centro de costo "
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cbo_operario As System.Windows.Forms.ComboBox
    Friend WithEvents cbo_centro As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_empleado As System.Windows.Forms.Label
    Friend WithEvents lblcentro As System.Windows.Forms.Label
    Friend WithEvents btn_mod As System.Windows.Forms.Button
End Class
