<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_meta_ambiental
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txt_meta = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbo_centro = New System.Windows.Forms.ComboBox()
        Me.month_Calender_year = New System.Windows.Forms.MonthCalendar()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btn_guardar = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(80, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Meta:"
        '
        'txt_meta
        '
        Me.txt_meta.Location = New System.Drawing.Point(120, 34)
        Me.txt_meta.Name = "txt_meta"
        Me.txt_meta.Size = New System.Drawing.Size(208, 20)
        Me.txt_meta.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(74, 75)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Centro:"
        '
        'cbo_centro
        '
        Me.cbo_centro.FormattingEnabled = True
        Me.cbo_centro.Location = New System.Drawing.Point(122, 72)
        Me.cbo_centro.Name = "cbo_centro"
        Me.cbo_centro.Size = New System.Drawing.Size(206, 21)
        Me.cbo_centro.TabIndex = 3
        '
        'month_Calender_year
        '
        Me.month_Calender_year.Location = New System.Drawing.Point(96, 132)
        Me.month_Calender_year.Name = "month_Calender_year"
        Me.month_Calender_year.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(93, 110)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(245, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Seleccione mes y año(El dia puede ser cualquiera)"
        '
        'btn_guardar
        '
        Me.btn_guardar.Location = New System.Drawing.Point(179, 306)
        Me.btn_guardar.Name = "btn_guardar"
        Me.btn_guardar.Size = New System.Drawing.Size(75, 23)
        Me.btn_guardar.TabIndex = 6
        Me.btn_guardar.Text = "Guardar"
        Me.btn_guardar.UseVisualStyleBackColor = True
        '
        'Frm_meta_ambiental
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(407, 348)
        Me.Controls.Add(Me.btn_guardar)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.month_Calender_year)
        Me.Controls.Add(Me.cbo_centro)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txt_meta)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Frm_meta_ambiental"
        Me.Text = "Meta centro de costos"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_meta As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbo_centro As System.Windows.Forms.ComboBox
    Friend WithEvents month_Calender_year As System.Windows.Forms.MonthCalendar
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btn_guardar As System.Windows.Forms.Button
End Class
