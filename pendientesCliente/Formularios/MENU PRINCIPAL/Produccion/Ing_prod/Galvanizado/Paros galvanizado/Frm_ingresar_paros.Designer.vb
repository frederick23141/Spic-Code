<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_ingresar_paros
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_ingresar_paros))
        Me.pb_Paros = New System.Windows.Forms.PictureBox()
        Me.btn_iniciar_paro = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.KryptonManager1 = New ComponentFactory.Krypton.Toolkit.KryptonManager(Me.components)
        Me.btn_detener_paro = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.cbo_paro = New System.Windows.Forms.ComboBox()
        Me.lbl_paro = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.lbl_Nomb_Paros = New System.Windows.Forms.Label()
        CType(Me.pb_Paros, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pb_Paros
        '
        Me.pb_Paros.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pb_Paros.Image = CType(resources.GetObject("pb_Paros.Image"), System.Drawing.Image)
        Me.pb_Paros.Location = New System.Drawing.Point(12, 5)
        Me.pb_Paros.Name = "pb_Paros"
        Me.pb_Paros.Size = New System.Drawing.Size(656, 175)
        Me.pb_Paros.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pb_Paros.TabIndex = 0
        Me.pb_Paros.TabStop = False
        '
        'btn_iniciar_paro
        '
        Me.btn_iniciar_paro.Location = New System.Drawing.Point(39, 304)
        Me.btn_iniciar_paro.Name = "btn_iniciar_paro"
        Me.btn_iniciar_paro.Size = New System.Drawing.Size(210, 212)
        Me.btn_iniciar_paro.StateNormal.Content.ShortText.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Stretch
        Me.btn_iniciar_paro.TabIndex = 1
        Me.btn_iniciar_paro.Values.Image = Global.Spic.My.Resources.Resources._stop
        Me.btn_iniciar_paro.Values.Text = ""
        '
        'KryptonManager1
        '
        Me.KryptonManager1.GlobalPaletteMode = ComponentFactory.Krypton.Toolkit.PaletteModeManager.Office2010Silver
        '
        'btn_detener_paro
        '
        Me.btn_detener_paro.Location = New System.Drawing.Point(430, 304)
        Me.btn_detener_paro.Name = "btn_detener_paro"
        Me.btn_detener_paro.Size = New System.Drawing.Size(204, 215)
        Me.btn_detener_paro.StateNormal.Content.ShortText.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Stretch
        Me.btn_detener_paro.TabIndex = 2
        Me.btn_detener_paro.Values.Image = Global.Spic.My.Resources.Resources.start1
        Me.btn_detener_paro.Values.Text = ""
        '
        'cbo_paro
        '
        Me.cbo_paro.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_paro.FormattingEnabled = True
        Me.cbo_paro.Items.AddRange(New Object() {"Seleccione", "1", "2", "3", "4", "5", "6", "7", "8", "9"})
        Me.cbo_paro.Location = New System.Drawing.Point(293, 248)
        Me.cbo_paro.Name = "cbo_paro"
        Me.cbo_paro.Size = New System.Drawing.Size(130, 32)
        Me.cbo_paro.TabIndex = 3
        '
        'lbl_paro
        '
        Me.lbl_paro.Location = New System.Drawing.Point(240, 255)
        Me.lbl_paro.Name = "lbl_paro"
        Me.lbl_paro.Size = New System.Drawing.Size(38, 20)
        Me.lbl_paro.TabIndex = 4
        Me.lbl_paro.Values.Text = "Paro:"
        '
        'lbl_Nomb_Paros
        '
        Me.lbl_Nomb_Paros.AutoSize = True
        Me.lbl_Nomb_Paros.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Nomb_Paros.Location = New System.Drawing.Point(171, 201)
        Me.lbl_Nomb_Paros.Name = "lbl_Nomb_Paros"
        Me.lbl_Nomb_Paros.Size = New System.Drawing.Size(174, 20)
        Me.lbl_Nomb_Paros.TabIndex = 5
        Me.lbl_Nomb_Paros.Text = "El paro actual es de:"
        Me.lbl_Nomb_Paros.Visible = False
        '
        'Frm_ingresar_paros
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(673, 537)
        Me.Controls.Add(Me.lbl_Nomb_Paros)
        Me.Controls.Add(Me.lbl_paro)
        Me.Controls.Add(Me.cbo_paro)
        Me.Controls.Add(Me.btn_detener_paro)
        Me.Controls.Add(Me.btn_iniciar_paro)
        Me.Controls.Add(Me.pb_Paros)
        Me.MaximizeBox = False
        Me.Name = "Frm_ingresar_paros"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Ingresar paros galvanizado"
        CType(Me.pb_Paros, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pb_Paros As PictureBox
    Friend WithEvents btn_iniciar_paro As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents KryptonManager1 As ComponentFactory.Krypton.Toolkit.KryptonManager
    Friend WithEvents btn_detener_paro As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents cbo_paro As ComboBox
    Friend WithEvents lbl_paro As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents lbl_Nomb_Paros As Label
End Class
