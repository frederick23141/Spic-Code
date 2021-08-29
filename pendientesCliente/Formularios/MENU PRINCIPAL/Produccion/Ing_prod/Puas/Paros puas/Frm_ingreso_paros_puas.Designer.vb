<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Frm_ingreso_paros_puas
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.lbl_Nomb_Paros = New System.Windows.Forms.Label()
        Me.lbl_paro = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.cbo_paro = New System.Windows.Forms.ComboBox()
        Me.btn_detener_paro = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.btn_iniciar_paro = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.pb_Paros = New System.Windows.Forms.PictureBox()
        CType(Me.pb_Paros, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbl_Nomb_Paros
        '
        Me.lbl_Nomb_Paros.AutoSize = True
        Me.lbl_Nomb_Paros.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Nomb_Paros.Location = New System.Drawing.Point(231, 200)
        Me.lbl_Nomb_Paros.Name = "lbl_Nomb_Paros"
        Me.lbl_Nomb_Paros.Size = New System.Drawing.Size(174, 20)
        Me.lbl_Nomb_Paros.TabIndex = 11
        Me.lbl_Nomb_Paros.Text = "El paro actual es de:"
        Me.lbl_Nomb_Paros.Visible = False
        '
        'lbl_paro
        '
        Me.lbl_paro.Location = New System.Drawing.Point(300, 247)
        Me.lbl_paro.Name = "lbl_paro"
        Me.lbl_paro.Size = New System.Drawing.Size(38, 20)
        Me.lbl_paro.TabIndex = 10
        Me.lbl_paro.Values.Text = "Paro:"
        '
        'cbo_paro
        '
        Me.cbo_paro.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_paro.FormattingEnabled = True
        Me.cbo_paro.Items.AddRange(New Object() {"Seleccione", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12"})
        Me.cbo_paro.Location = New System.Drawing.Point(353, 240)
        Me.cbo_paro.Name = "cbo_paro"
        Me.cbo_paro.Size = New System.Drawing.Size(130, 32)
        Me.cbo_paro.TabIndex = 9
        '
        'btn_detener_paro
        '
        Me.btn_detener_paro.Location = New System.Drawing.Point(490, 296)
        Me.btn_detener_paro.Name = "btn_detener_paro"
        Me.btn_detener_paro.Size = New System.Drawing.Size(204, 201)
        Me.btn_detener_paro.StateNormal.Content.ShortText.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Stretch
        Me.btn_detener_paro.TabIndex = 8
        Me.btn_detener_paro.Values.Image = Global.Spic.My.Resources.Resources.start1
        Me.btn_detener_paro.Values.Text = ""
        '
        'btn_iniciar_paro
        '
        Me.btn_iniciar_paro.Location = New System.Drawing.Point(99, 296)
        Me.btn_iniciar_paro.Name = "btn_iniciar_paro"
        Me.btn_iniciar_paro.Size = New System.Drawing.Size(210, 201)
        Me.btn_iniciar_paro.StateNormal.Content.ShortText.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Stretch
        Me.btn_iniciar_paro.TabIndex = 7
        Me.btn_iniciar_paro.Values.Image = Global.Spic.My.Resources.Resources._stop
        Me.btn_iniciar_paro.Values.Text = ""
        '
        'pb_Paros
        '
        Me.pb_Paros.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pb_Paros.Image = Global.Spic.My.Resources.Resources.Paros_puas
        Me.pb_Paros.Location = New System.Drawing.Point(78, 15)
        Me.pb_Paros.Name = "pb_Paros"
        Me.pb_Paros.Size = New System.Drawing.Size(656, 175)
        Me.pb_Paros.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pb_Paros.TabIndex = 12
        Me.pb_Paros.TabStop = False
        '
        'Frm_ingreso_paros_puas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 509)
        Me.Controls.Add(Me.pb_Paros)
        Me.Controls.Add(Me.lbl_Nomb_Paros)
        Me.Controls.Add(Me.lbl_paro)
        Me.Controls.Add(Me.cbo_paro)
        Me.Controls.Add(Me.btn_detener_paro)
        Me.Controls.Add(Me.btn_iniciar_paro)
        Me.MaximizeBox = False
        Me.Name = "Frm_ingreso_paros_puas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ingreso de paros de púas"
        CType(Me.pb_Paros, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lbl_Nomb_Paros As Label
    Friend WithEvents lbl_paro As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents cbo_paro As ComboBox
    Friend WithEvents btn_detener_paro As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents btn_iniciar_paro As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents pb_Paros As PictureBox
End Class
