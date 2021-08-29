<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_reg_mp_puas
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
        Me.txt_lector = New System.Windows.Forms.TextBox()
        Me.lbl_nom = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.lbl_codigo = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.Label1 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.lbl_peso = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.btn_registrar = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.SuspendLayout()
        '
        'txt_lector
        '
        Me.txt_lector.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txt_lector.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_lector.Location = New System.Drawing.Point(63, 21)
        Me.txt_lector.Name = "txt_lector"
        Me.txt_lector.Size = New System.Drawing.Size(378, 40)
        Me.txt_lector.TabIndex = 0
        '
        'lbl_nom
        '
        Me.lbl_nom.Location = New System.Drawing.Point(63, 79)
        Me.lbl_nom.Name = "lbl_nom"
        Me.lbl_nom.Size = New System.Drawing.Size(84, 23)
        Me.lbl_nom.StateNormal.LongText.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_nom.StateNormal.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_nom.TabIndex = 6
        Me.lbl_nom.Values.Text = "NOMBRE"
        '
        'lbl_codigo
        '
        Me.lbl_codigo.Location = New System.Drawing.Point(68, 118)
        Me.lbl_codigo.Name = "lbl_codigo"
        Me.lbl_codigo.Size = New System.Drawing.Size(79, 23)
        Me.lbl_codigo.StateNormal.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_codigo.TabIndex = 7
        Me.lbl_codigo.Values.Text = "CODIGO"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(239, 118)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 23)
        Me.Label1.StateNormal.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.TabIndex = 8
        Me.Label1.Values.Text = "PESO:"
        '
        'lbl_peso
        '
        Me.lbl_peso.Location = New System.Drawing.Point(298, 105)
        Me.lbl_peso.Name = "lbl_peso"
        Me.lbl_peso.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleOrange
        Me.lbl_peso.Size = New System.Drawing.Size(93, 36)
        Me.lbl_peso.StateNormal.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_peso.TabIndex = 9
        Me.lbl_peso.Values.Text = "PESO"
        '
        'btn_registrar
        '
        Me.btn_registrar.Enabled = False
        Me.btn_registrar.Location = New System.Drawing.Point(136, 221)
        Me.btn_registrar.Name = "btn_registrar"
        Me.btn_registrar.Size = New System.Drawing.Size(199, 146)
        Me.btn_registrar.StateNormal.Content.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_registrar.StateNormal.Content.ShortText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Far
        Me.btn_registrar.TabIndex = 10
        Me.btn_registrar.Values.Image = Global.Spic.My.Resources.Resources.conveyor_1_iloveimg_resized
        Me.btn_registrar.Values.Text = "Registrar"
        '
        'frm_reg_mp_puas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(495, 433)
        Me.Controls.Add(Me.btn_registrar)
        Me.Controls.Add(Me.lbl_peso)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lbl_codigo)
        Me.Controls.Add(Me.lbl_nom)
        Me.Controls.Add(Me.txt_lector)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_reg_mp_puas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Registro materia prima púas"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txt_lector As System.Windows.Forms.TextBox
    Friend WithEvents lbl_nom As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents lbl_codigo As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents Label1 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents lbl_peso As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents btn_registrar As ComponentFactory.Krypton.Toolkit.KryptonButton
End Class
