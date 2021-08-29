<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Asignar_dias
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
        Me.cbo_calendar = New ComponentFactory.Krypton.Toolkit.KryptonMonthCalendar()
        Me.btn_asignar = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.txt_obj_visit = New System.Windows.Forms.TextBox()
        Me.KryptonLabel1 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.SuspendLayout()
        '
        'cbo_calendar
        '
        Me.cbo_calendar.Location = New System.Drawing.Point(12, 255)
        Me.cbo_calendar.Name = "cbo_calendar"
        Me.cbo_calendar.Size = New System.Drawing.Size(314, 184)
        Me.cbo_calendar.TabIndex = 0
        '
        'btn_asignar
        '
        Me.btn_asignar.Location = New System.Drawing.Point(118, 479)
        Me.btn_asignar.Name = "btn_asignar"
        Me.btn_asignar.Size = New System.Drawing.Size(90, 25)
        Me.btn_asignar.TabIndex = 1
        Me.btn_asignar.Values.Text = "Asignar"
        '
        'txt_obj_visit
        '
        Me.txt_obj_visit.Location = New System.Drawing.Point(12, 54)
        Me.txt_obj_visit.Multiline = True
        Me.txt_obj_visit.Name = "txt_obj_visit"
        Me.txt_obj_visit.Size = New System.Drawing.Size(314, 184)
        Me.txt_obj_visit.TabIndex = 2
        '
        'KryptonLabel1
        '
        Me.KryptonLabel1.Location = New System.Drawing.Point(118, 28)
        Me.KryptonLabel1.Name = "KryptonLabel1"
        Me.KryptonLabel1.Size = New System.Drawing.Size(99, 20)
        Me.KryptonLabel1.TabIndex = 3
        Me.KryptonLabel1.Values.Text = "Objeto de visita:"
        '
        'Asignar_dias
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(333, 510)
        Me.Controls.Add(Me.KryptonLabel1)
        Me.Controls.Add(Me.txt_obj_visit)
        Me.Controls.Add(Me.btn_asignar)
        Me.Controls.Add(Me.cbo_calendar)
        Me.MaximizeBox = False
        Me.Name = "Asignar_dias"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Asignar dias"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cbo_calendar As ComponentFactory.Krypton.Toolkit.KryptonMonthCalendar
    Friend WithEvents btn_asignar As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents txt_obj_visit As TextBox
    Friend WithEvents KryptonLabel1 As ComponentFactory.Krypton.Toolkit.KryptonLabel
End Class
