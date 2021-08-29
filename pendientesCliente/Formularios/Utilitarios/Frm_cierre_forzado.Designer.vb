<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_cierre_forzado
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btncerrar_spic = New System.Windows.Forms.Button()
        Me.btn_cancelar_cierre = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(2, 66)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(439, 26)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Este modulo sirve para cerrar la aplicacion spic a los 10" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " segundos y para cance" & _
    "lar los cierre cuando se haya hecho la actualizacion"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(66, 114)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(298, 39)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Nota:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Se recomienda utilizar este modulo en horas " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "en que el pico de uso del sp" & _
    "ic sea el menor posible"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btncerrar_spic
        '
        Me.btncerrar_spic.Location = New System.Drawing.Point(175, 187)
        Me.btncerrar_spic.Name = "btncerrar_spic"
        Me.btncerrar_spic.Size = New System.Drawing.Size(75, 23)
        Me.btncerrar_spic.TabIndex = 2
        Me.btncerrar_spic.Text = "Cerrar spic"
        Me.btncerrar_spic.UseVisualStyleBackColor = True
        '
        'btn_cancelar_cierre
        '
        Me.btn_cancelar_cierre.Location = New System.Drawing.Point(175, 218)
        Me.btn_cancelar_cierre.Name = "btn_cancelar_cierre"
        Me.btn_cancelar_cierre.Size = New System.Drawing.Size(75, 23)
        Me.btn_cancelar_cierre.TabIndex = 3
        Me.btn_cancelar_cierre.Text = "Cancelar cierre"
        Me.btn_cancelar_cierre.UseVisualStyleBackColor = True
        Me.btn_cancelar_cierre.Visible = False
        '
        'Frm_cierre_forzado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(441, 261)
        Me.Controls.Add(Me.btn_cancelar_cierre)
        Me.Controls.Add(Me.btncerrar_spic)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.Name = "Frm_cierre_forzado"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cierre forzado"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btncerrar_spic As System.Windows.Forms.Button
    Friend WithEvents btn_cancelar_cierre As System.Windows.Forms.Button
End Class
