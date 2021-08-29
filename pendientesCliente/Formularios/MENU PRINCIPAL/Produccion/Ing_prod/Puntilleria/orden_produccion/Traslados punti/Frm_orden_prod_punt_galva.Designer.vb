<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_orden_prod_punt_galva
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
        Me.txt_lector_galv = New System.Windows.Forms.TextBox()
        Me.txt_kilos_galv = New System.Windows.Forms.TextBox()
        Me.btn_galv = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.KryptonLabel1 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.lbl_cod_text = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.lblDescEmpaque = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.GroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.txt_lector_galv)
        Me.GroupBox5.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(445, 68)
        Me.GroupBox5.TabIndex = 1126
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Lector "
        '
        'txt_lector_galv
        '
        Me.txt_lector_galv.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_lector_galv.Location = New System.Drawing.Point(6, 22)
        Me.txt_lector_galv.Name = "txt_lector_galv"
        Me.txt_lector_galv.Size = New System.Drawing.Size(430, 29)
        Me.txt_lector_galv.TabIndex = 1074
        '
        'txt_kilos_galv
        '
        Me.txt_kilos_galv.Enabled = False
        Me.txt_kilos_galv.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_kilos_galv.Location = New System.Drawing.Point(85, 113)
        Me.txt_kilos_galv.MaxLength = 4
        Me.txt_kilos_galv.Name = "txt_kilos_galv"
        Me.txt_kilos_galv.ReadOnly = True
        Me.txt_kilos_galv.Size = New System.Drawing.Size(117, 26)
        Me.txt_kilos_galv.TabIndex = 1132
        '
        'btn_galv
        '
        Me.btn_galv.Location = New System.Drawing.Point(112, 149)
        Me.btn_galv.Name = "btn_galv"
        Me.btn_galv.Size = New System.Drawing.Size(254, 44)
        Me.btn_galv.StateCommon.Content.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_galv.StateNormal.Content.LongText.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_galv.TabIndex = 1134
        Me.btn_galv.Values.Text = "Registrar galvanizado"
        '
        'KryptonLabel1
        '
        Me.KryptonLabel1.Location = New System.Drawing.Point(24, 85)
        Me.KryptonLabel1.Name = "KryptonLabel1"
        Me.KryptonLabel1.Size = New System.Drawing.Size(53, 20)
        Me.KryptonLabel1.TabIndex = 1135
        Me.KryptonLabel1.Values.Text = "Codigo:"
        '
        'lbl_cod_text
        '
        Me.lbl_cod_text.Location = New System.Drawing.Point(83, 84)
        Me.lbl_cod_text.Name = "lbl_cod_text"
        Me.lbl_cod_text.Size = New System.Drawing.Size(89, 20)
        Me.lbl_cod_text.TabIndex = 1136
        Me.lbl_cod_text.Values.Text = "KryptonLabel2"
        '
        'lblDescEmpaque
        '
        Me.lblDescEmpaque.Location = New System.Drawing.Point(37, 114)
        Me.lblDescEmpaque.Name = "lblDescEmpaque"
        Me.lblDescEmpaque.Size = New System.Drawing.Size(39, 20)
        Me.lblDescEmpaque.TabIndex = 1137
        Me.lblDescEmpaque.Values.Text = "Peso:"
        '
        'Frm_orden_prod_punt_galva
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(467, 205)
        Me.Controls.Add(Me.lblDescEmpaque)
        Me.Controls.Add(Me.lbl_cod_text)
        Me.Controls.Add(Me.KryptonLabel1)
        Me.Controls.Add(Me.btn_galv)
        Me.Controls.Add(Me.txt_kilos_galv)
        Me.Controls.Add(Me.GroupBox5)
        Me.Name = "Frm_orden_prod_punt_galva"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Galvanizar"
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents txt_lector_galv As TextBox
    Friend WithEvents txt_kilos_galv As TextBox
    Friend WithEvents btn_galv As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents KryptonLabel1 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents lbl_cod_text As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents lblDescEmpaque As ComponentFactory.Krypton.Toolkit.KryptonLabel
End Class
