<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_tiquete_recocido_manual
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
        Me.lbl_orden = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txt_orden = New System.Windows.Forms.TextBox()
        Me.txt_detalle = New System.Windows.Forms.TextBox()
        Me.btn_imprimir = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lbl_orden
        '
        Me.lbl_orden.AutoSize = True
        Me.lbl_orden.Location = New System.Drawing.Point(58, 70)
        Me.lbl_orden.Name = "lbl_orden"
        Me.lbl_orden.Size = New System.Drawing.Size(72, 13)
        Me.lbl_orden.TabIndex = 0
        Me.lbl_orden.Text = "Nro de orden:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(58, 153)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Id_detalle:"
        '
        'txt_orden
        '
        Me.txt_orden.Location = New System.Drawing.Point(157, 67)
        Me.txt_orden.Name = "txt_orden"
        Me.txt_orden.Size = New System.Drawing.Size(100, 20)
        Me.txt_orden.TabIndex = 2
        '
        'txt_detalle
        '
        Me.txt_detalle.Location = New System.Drawing.Point(157, 150)
        Me.txt_detalle.Name = "txt_detalle"
        Me.txt_detalle.Size = New System.Drawing.Size(100, 20)
        Me.txt_detalle.TabIndex = 3
        '
        'btn_imprimir
        '
        Me.btn_imprimir.Image = Global.Spic.My.Resources.Resources.imprimir
        Me.btn_imprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_imprimir.Location = New System.Drawing.Point(83, 205)
        Me.btn_imprimir.Name = "btn_imprimir"
        Me.btn_imprimir.Size = New System.Drawing.Size(128, 23)
        Me.btn_imprimir.TabIndex = 4
        Me.btn_imprimir.Text = "Imprimir"
        Me.btn_imprimir.UseVisualStyleBackColor = True
        '
        'frm_tiquete_recocido_manual
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 261)
        Me.Controls.Add(Me.btn_imprimir)
        Me.Controls.Add(Me.txt_detalle)
        Me.Controls.Add(Me.txt_orden)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lbl_orden)
        Me.MaximizeBox = False
        Me.Name = "frm_tiquete_recocido_manual"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tiquetes manuales recocido"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbl_orden As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_orden As System.Windows.Forms.TextBox
    Friend WithEvents txt_detalle As System.Windows.Forms.TextBox
    Friend WithEvents btn_imprimir As System.Windows.Forms.Button
End Class
