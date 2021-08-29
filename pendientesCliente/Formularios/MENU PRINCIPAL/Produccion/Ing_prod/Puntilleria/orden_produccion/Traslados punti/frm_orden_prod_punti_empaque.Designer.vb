<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_orden_prod_punti_empaque
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
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.txt_lector_empaque = New System.Windows.Forms.TextBox()
        Me.txt_kilos_empaque = New System.Windows.Forms.TextBox()
        Me.btn_transaccion_empaque = New System.Windows.Forms.Button()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cbo_transaccion_empaque = New System.Windows.Forms.ComboBox()
        Me.lblDescEmpaque = New System.Windows.Forms.Label()
        Me.lblCodigoEmpaque = New System.Windows.Forms.Label()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.txt_lector_empaque)
        Me.GroupBox5.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(450, 68)
        Me.GroupBox5.TabIndex = 1125
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Lector "
        '
        'txt_lector_empaque
        '
        Me.txt_lector_empaque.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_lector_empaque.Location = New System.Drawing.Point(6, 22)
        Me.txt_lector_empaque.Name = "txt_lector_empaque"
        Me.txt_lector_empaque.Size = New System.Drawing.Size(430, 29)
        Me.txt_lector_empaque.TabIndex = 1074
        '
        'txt_kilos_empaque
        '
        Me.txt_kilos_empaque.Enabled = False
        Me.txt_kilos_empaque.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_kilos_empaque.Location = New System.Drawing.Point(17, 122)
        Me.txt_kilos_empaque.MaxLength = 4
        Me.txt_kilos_empaque.Name = "txt_kilos_empaque"
        Me.txt_kilos_empaque.ReadOnly = True
        Me.txt_kilos_empaque.Size = New System.Drawing.Size(117, 26)
        Me.txt_kilos_empaque.TabIndex = 1129
        '
        'btn_transaccion_empaque
        '
        Me.btn_transaccion_empaque.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_transaccion_empaque.Image = Global.Spic.My.Resources.Resources.box2
        Me.btn_transaccion_empaque.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_transaccion_empaque.Location = New System.Drawing.Point(212, 160)
        Me.btn_transaccion_empaque.Name = "btn_transaccion_empaque"
        Me.btn_transaccion_empaque.Size = New System.Drawing.Size(237, 53)
        Me.btn_transaccion_empaque.TabIndex = 1124
        Me.btn_transaccion_empaque.Text = "Enviar a empaque"
        Me.btn_transaccion_empaque.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_transaccion_empaque.UseVisualStyleBackColor = True
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.PictureBox1)
        Me.GroupBox6.Controls.Add(Me.Label13)
        Me.GroupBox6.Controls.Add(Me.cbo_transaccion_empaque)
        Me.GroupBox6.Location = New System.Drawing.Point(11, 154)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(195, 59)
        Me.GroupBox6.TabIndex = 1128
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Datos de la transacción"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Spic.My.Resources.Resources._1371750041_14125
        Me.PictureBox1.Location = New System.Drawing.Point(175, 19)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(15, 17)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 1067
        Me.PictureBox1.TabStop = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(-1, 25)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(36, 13)
        Me.Label13.TabIndex = 1061
        Me.Label13.Text = "Tipo:"
        '
        'cbo_transaccion_empaque
        '
        Me.cbo_transaccion_empaque.AutoCompleteCustomSource.AddRange(New String() {"1", "2", "3", "7"})
        Me.cbo_transaccion_empaque.Enabled = False
        Me.cbo_transaccion_empaque.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_transaccion_empaque.FormattingEnabled = True
        Me.cbo_transaccion_empaque.Items.AddRange(New Object() {""})
        Me.cbo_transaccion_empaque.Location = New System.Drawing.Point(41, 19)
        Me.cbo_transaccion_empaque.Name = "cbo_transaccion_empaque"
        Me.cbo_transaccion_empaque.Size = New System.Drawing.Size(128, 28)
        Me.cbo_transaccion_empaque.TabIndex = 1062
        Me.cbo_transaccion_empaque.Text = "Seleccione"
        '
        'lblDescEmpaque
        '
        Me.lblDescEmpaque.AutoSize = True
        Me.lblDescEmpaque.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescEmpaque.Location = New System.Drawing.Point(15, 104)
        Me.lblDescEmpaque.Name = "lblDescEmpaque"
        Me.lblDescEmpaque.Size = New System.Drawing.Size(59, 15)
        Me.lblDescEmpaque.TabIndex = 1127
        Me.lblDescEmpaque.Text = "Label14"
        '
        'lblCodigoEmpaque
        '
        Me.lblCodigoEmpaque.AutoSize = True
        Me.lblCodigoEmpaque.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodigoEmpaque.Location = New System.Drawing.Point(15, 83)
        Me.lblCodigoEmpaque.Name = "lblCodigoEmpaque"
        Me.lblCodigoEmpaque.Size = New System.Drawing.Size(63, 16)
        Me.lblCodigoEmpaque.TabIndex = 1126
        Me.lblCodigoEmpaque.Text = "Label15"
        '
        'frm_orden_prod_punti_empaque
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(470, 224)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.txt_kilos_empaque)
        Me.Controls.Add(Me.btn_transaccion_empaque)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.lblDescEmpaque)
        Me.Controls.Add(Me.lblCodigoEmpaque)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_orden_prod_punti_empaque"
        Me.Text = "Enviar a Empaque"
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_lector_empaque As System.Windows.Forms.TextBox
    Friend WithEvents txt_kilos_empaque As System.Windows.Forms.TextBox
    Friend WithEvents btn_transaccion_empaque As System.Windows.Forms.Button
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cbo_transaccion_empaque As System.Windows.Forms.ComboBox
    Friend WithEvents lblDescEmpaque As System.Windows.Forms.Label
    Friend WithEvents lblCodigoEmpaque As System.Windows.Forms.Label
End Class
