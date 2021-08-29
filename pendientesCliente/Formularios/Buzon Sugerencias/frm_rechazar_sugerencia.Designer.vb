<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_rechazar_sugerencia
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
        Me.btn_denegar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txt_razon = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'btn_denegar
        '
        Me.btn_denegar.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btn_denegar.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_denegar.Image = Global.Spic.My.Resources.Resources.cancelar_buz
        Me.btn_denegar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_denegar.Location = New System.Drawing.Point(202, 179)
        Me.btn_denegar.Name = "btn_denegar"
        Me.btn_denegar.Size = New System.Drawing.Size(133, 45)
        Me.btn_denegar.TabIndex = 0
        Me.btn_denegar.Text = "Denegar"
        Me.btn_denegar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_denegar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(2, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(529, 20)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Por favor digite la razon por la cual desea denegar la sugerencia."
        '
        'txt_razon
        '
        Me.txt_razon.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_razon.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txt_razon.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_razon.Location = New System.Drawing.Point(6, 42)
        Me.txt_razon.Multiline = True
        Me.txt_razon.Name = "txt_razon"
        Me.txt_razon.Size = New System.Drawing.Size(524, 131)
        Me.txt_razon.TabIndex = 2
        '
        'frm_rechazar_sugerencia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DimGray
        Me.ClientSize = New System.Drawing.Size(539, 231)
        Me.Controls.Add(Me.txt_razon)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btn_denegar)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_rechazar_sugerencia"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frm_rechazar_sugerencia"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn_denegar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_razon As System.Windows.Forms.TextBox
End Class
