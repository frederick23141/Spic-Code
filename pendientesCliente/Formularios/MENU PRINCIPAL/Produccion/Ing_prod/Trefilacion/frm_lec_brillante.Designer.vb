<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_lec_brillante
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
        Me.pn_codigo_barras = New System.Windows.Forms.Panel()
        Me.lbl_error_lector = New System.Windows.Forms.Label()
        Me.txt_lector = New System.Windows.Forms.TextBox()
        Me.lbl_codigo_barras = New System.Windows.Forms.Label()
        Me.btn_leer = New System.Windows.Forms.Button()
        Me.btn_cerrar = New System.Windows.Forms.Button()
        Me.pn_codigo_barras.SuspendLayout()
        Me.SuspendLayout()
        '
        'pn_codigo_barras
        '
        Me.pn_codigo_barras.BackColor = System.Drawing.Color.Gold
        Me.pn_codigo_barras.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pn_codigo_barras.Controls.Add(Me.lbl_error_lector)
        Me.pn_codigo_barras.Controls.Add(Me.txt_lector)
        Me.pn_codigo_barras.Controls.Add(Me.lbl_codigo_barras)
        Me.pn_codigo_barras.Location = New System.Drawing.Point(6, 2)
        Me.pn_codigo_barras.Name = "pn_codigo_barras"
        Me.pn_codigo_barras.Size = New System.Drawing.Size(528, 104)
        Me.pn_codigo_barras.TabIndex = 3
        '
        'lbl_error_lector
        '
        Me.lbl_error_lector.AutoSize = True
        Me.lbl_error_lector.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_error_lector.Location = New System.Drawing.Point(48, 79)
        Me.lbl_error_lector.Name = "lbl_error_lector"
        Me.lbl_error_lector.Size = New System.Drawing.Size(0, 15)
        Me.lbl_error_lector.TabIndex = 2
        '
        'txt_lector
        '
        Me.txt_lector.BackColor = System.Drawing.Color.Red
        Me.txt_lector.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_lector.Location = New System.Drawing.Point(20, 27)
        Me.txt_lector.Name = "txt_lector"
        Me.txt_lector.Size = New System.Drawing.Size(492, 49)
        Me.txt_lector.TabIndex = 1
        '
        'lbl_codigo_barras
        '
        Me.lbl_codigo_barras.AutoSize = True
        Me.lbl_codigo_barras.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_codigo_barras.Location = New System.Drawing.Point(3, 0)
        Me.lbl_codigo_barras.Name = "lbl_codigo_barras"
        Me.lbl_codigo_barras.Size = New System.Drawing.Size(232, 24)
        Me.lbl_codigo_barras.TabIndex = 0
        Me.lbl_codigo_barras.Text = "Lector codigo de barras"
        '
        'btn_leer
        '
        Me.btn_leer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_leer.Location = New System.Drawing.Point(166, 112)
        Me.btn_leer.Name = "btn_leer"
        Me.btn_leer.Size = New System.Drawing.Size(77, 61)
        Me.btn_leer.TabIndex = 2
        Me.btn_leer.Text = "Leer tiquete"
        Me.btn_leer.UseVisualStyleBackColor = True
        '
        'btn_cerrar
        '
        Me.btn_cerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_cerrar.Location = New System.Drawing.Point(267, 112)
        Me.btn_cerrar.Name = "btn_cerrar"
        Me.btn_cerrar.Size = New System.Drawing.Size(81, 61)
        Me.btn_cerrar.TabIndex = 4
        Me.btn_cerrar.Text = "Cerrar lector"
        Me.btn_cerrar.UseVisualStyleBackColor = True
        '
        'Frm_lec_brillante
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(532, 174)
        Me.ControlBox = False
        Me.Controls.Add(Me.btn_cerrar)
        Me.Controls.Add(Me.pn_codigo_barras)
        Me.Controls.Add(Me.btn_leer)
        Me.Name = "Frm_lec_brillante"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lector brillante"
        Me.pn_codigo_barras.ResumeLayout(false)
        Me.pn_codigo_barras.PerformLayout
        Me.ResumeLayout(false)

End Sub
    Friend WithEvents pn_codigo_barras As System.Windows.Forms.Panel
    Friend WithEvents lbl_error_lector As System.Windows.Forms.Label
    Friend WithEvents txt_lector As System.Windows.Forms.TextBox
    Friend WithEvents lbl_codigo_barras As System.Windows.Forms.Label
    Friend WithEvents btn_leer As System.Windows.Forms.Button
    Friend WithEvents btn_cerrar As System.Windows.Forms.Button
End Class
