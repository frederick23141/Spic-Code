<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_orden_prod_punt_tambores
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
        Me.Label15 = New System.Windows.Forms.Label()
        Me.cbo_tambor = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.cbo_operario_tambor = New System.Windows.Forms.ComboBox()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.txt_lector_tambor = New System.Windows.Forms.TextBox()
        Me.txt_kilos_tambor = New System.Windows.Forms.TextBox()
        Me.btn__reg_tambor = New System.Windows.Forms.Button()
        Me.lbl_desc_tambor = New System.Windows.Forms.Label()
        Me.lbl_codigo_tambor = New System.Windows.Forms.Label()
        Me.GroupBox7.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(13, 65)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(62, 16)
        Me.Label15.TabIndex = 2137
        Me.Label15.Text = "Tambor"
        '
        'cbo_tambor
        '
        Me.cbo_tambor.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbo_tambor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_tambor.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_tambor.FormattingEnabled = True
        Me.cbo_tambor.Items.AddRange(New Object() {"Seleccione", "1", "2", "3", "4", "5"})
        Me.cbo_tambor.Location = New System.Drawing.Point(14, 86)
        Me.cbo_tambor.Name = "cbo_tambor"
        Me.cbo_tambor.Size = New System.Drawing.Size(449, 26)
        Me.cbo_tambor.TabIndex = 2136
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(12, 9)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(73, 16)
        Me.Label14.TabIndex = 2135
        Me.Label14.Text = "Operario:"
        '
        'cbo_operario_tambor
        '
        Me.cbo_operario_tambor.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbo_operario_tambor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_operario_tambor.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_operario_tambor.FormattingEnabled = True
        Me.cbo_operario_tambor.Location = New System.Drawing.Point(13, 30)
        Me.cbo_operario_tambor.Name = "cbo_operario_tambor"
        Me.cbo_operario_tambor.Size = New System.Drawing.Size(449, 26)
        Me.cbo_operario_tambor.TabIndex = 2134
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.txt_lector_tambor)
        Me.GroupBox7.Location = New System.Drawing.Point(13, 115)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(450, 68)
        Me.GroupBox7.TabIndex = 2130
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Lector "
        '
        'txt_lector_tambor
        '
        Me.txt_lector_tambor.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_lector_tambor.Location = New System.Drawing.Point(6, 22)
        Me.txt_lector_tambor.Name = "txt_lector_tambor"
        Me.txt_lector_tambor.Size = New System.Drawing.Size(430, 29)
        Me.txt_lector_tambor.TabIndex = 1074
        '
        'txt_kilos_tambor
        '
        Me.txt_kilos_tambor.Enabled = False
        Me.txt_kilos_tambor.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_kilos_tambor.Location = New System.Drawing.Point(18, 225)
        Me.txt_kilos_tambor.MaxLength = 4
        Me.txt_kilos_tambor.Name = "txt_kilos_tambor"
        Me.txt_kilos_tambor.ReadOnly = True
        Me.txt_kilos_tambor.Size = New System.Drawing.Size(117, 26)
        Me.txt_kilos_tambor.TabIndex = 2133
        '
        'btn__reg_tambor
        '
        Me.btn__reg_tambor.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn__reg_tambor.Image = Global.Spic.My.Resources.Resources.cilindr2
        Me.btn__reg_tambor.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn__reg_tambor.Location = New System.Drawing.Point(86, 253)
        Me.btn__reg_tambor.Name = "btn__reg_tambor"
        Me.btn__reg_tambor.Size = New System.Drawing.Size(307, 51)
        Me.btn__reg_tambor.TabIndex = 2129
        Me.btn__reg_tambor.Text = "Registrar como tamboreado"
        Me.btn__reg_tambor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn__reg_tambor.UseVisualStyleBackColor = True
        '
        'lbl_desc_tambor
        '
        Me.lbl_desc_tambor.AutoSize = True
        Me.lbl_desc_tambor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_desc_tambor.Location = New System.Drawing.Point(16, 207)
        Me.lbl_desc_tambor.Name = "lbl_desc_tambor"
        Me.lbl_desc_tambor.Size = New System.Drawing.Size(59, 15)
        Me.lbl_desc_tambor.TabIndex = 2132
        Me.lbl_desc_tambor.Text = "Label14"
        '
        'lbl_codigo_tambor
        '
        Me.lbl_codigo_tambor.AutoSize = True
        Me.lbl_codigo_tambor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_codigo_tambor.Location = New System.Drawing.Point(16, 186)
        Me.lbl_codigo_tambor.Name = "lbl_codigo_tambor"
        Me.lbl_codigo_tambor.Size = New System.Drawing.Size(63, 16)
        Me.lbl_codigo_tambor.TabIndex = 2131
        Me.lbl_codigo_tambor.Text = "Label15"
        '
        'frm_orden_prod_punt_tambores
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(470, 313)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.cbo_tambor)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.cbo_operario_tambor)
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.txt_kilos_tambor)
        Me.Controls.Add(Me.btn__reg_tambor)
        Me.Controls.Add(Me.lbl_desc_tambor)
        Me.Controls.Add(Me.lbl_codigo_tambor)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_orden_prod_punt_tambores"
        Me.Text = "Traslado Tambores"
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cbo_tambor As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cbo_operario_tambor As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_lector_tambor As System.Windows.Forms.TextBox
    Friend WithEvents txt_kilos_tambor As System.Windows.Forms.TextBox
    Friend WithEvents btn__reg_tambor As System.Windows.Forms.Button
    Friend WithEvents lbl_desc_tambor As System.Windows.Forms.Label
    Friend WithEvents lbl_codigo_tambor As System.Windows.Forms.Label
End Class
