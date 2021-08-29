<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_Duplicar
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.lbl_fecha = New System.Windows.Forms.Label()
        Me.mc_Fecha_Duplicar = New System.Windows.Forms.MonthCalendar()
        Me.txt_duplicar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txt_cant_prog = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'lbl_fecha
        '
        Me.lbl_fecha.AutoSize = True
        Me.lbl_fecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_fecha.Location = New System.Drawing.Point(87, 34)
        Me.lbl_fecha.Name = "lbl_fecha"
        Me.lbl_fecha.Size = New System.Drawing.Size(102, 13)
        Me.lbl_fecha.TabIndex = 0
        Me.lbl_fecha.Text = "Fecha a duplicar"
        '
        'mc_Fecha_Duplicar
        '
        Me.mc_Fecha_Duplicar.Location = New System.Drawing.Point(18, 56)
        Me.mc_Fecha_Duplicar.Name = "mc_Fecha_Duplicar"
        Me.mc_Fecha_Duplicar.TabIndex = 1
        '
        'txt_duplicar
        '
        Me.txt_duplicar.Location = New System.Drawing.Point(103, 290)
        Me.txt_duplicar.Name = "txt_duplicar"
        Me.txt_duplicar.Size = New System.Drawing.Size(75, 23)
        Me.txt_duplicar.TabIndex = 2
        Me.txt_duplicar.Text = "Duplicar"
        Me.txt_duplicar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(76, 229)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(128, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Cantidad a programar"
        '
        'txt_cant_prog
        '
        Me.txt_cant_prog.Location = New System.Drawing.Point(90, 248)
        Me.txt_cant_prog.Name = "txt_cant_prog"
        Me.txt_cant_prog.Size = New System.Drawing.Size(100, 20)
        Me.txt_cant_prog.TabIndex = 4
        '
        'frm_Duplicar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 321)
        Me.Controls.Add(Me.txt_cant_prog)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txt_duplicar)
        Me.Controls.Add(Me.mc_Fecha_Duplicar)
        Me.Controls.Add(Me.lbl_fecha)
        Me.Name = "frm_Duplicar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Duplicar orden"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbl_fecha As System.Windows.Forms.Label
    Friend WithEvents mc_Fecha_Duplicar As System.Windows.Forms.MonthCalendar
    Friend WithEvents txt_duplicar As System.Windows.Forms.Button
    Friend WithEvents Label1 As Label
    Friend WithEvents txt_cant_prog As TextBox
End Class
