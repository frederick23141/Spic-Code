<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Mantenimiento_Planta
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
        Me.lbl_servicio_solicitado = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.lbl_maquina_afectada = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.cbo_solicitante = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.btn_realizar = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.KryptonGroupBox1 = New ComponentFactory.Krypton.Toolkit.KryptonGroupBox()
        Me.txt_solicitado = New System.Windows.Forms.TextBox()
        Me.cbo_maquina_afec = New System.Windows.Forms.ComboBox()
        Me.cbo_operario_sol = New System.Windows.Forms.ComboBox()
        Me.KryptonPalette1 = New ComponentFactory.Krypton.Toolkit.KryptonPalette(Me.components)
        CType(Me.KryptonGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonGroupBox1.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonGroupBox1.Panel.SuspendLayout()
        Me.KryptonGroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbl_servicio_solicitado
        '
        Me.lbl_servicio_solicitado.Location = New System.Drawing.Point(65, 136)
        Me.lbl_servicio_solicitado.Name = "lbl_servicio_solicitado"
        Me.lbl_servicio_solicitado.Size = New System.Drawing.Size(129, 19)
        Me.lbl_servicio_solicitado.StateNormal.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_servicio_solicitado.TabIndex = 1
        Me.lbl_servicio_solicitado.Values.Text = "Servicio Solicitado:"
        '
        'lbl_maquina_afectada
        '
        Me.lbl_maquina_afectada.Location = New System.Drawing.Point(69, 83)
        Me.lbl_maquina_afectada.Name = "lbl_maquina_afectada"
        Me.lbl_maquina_afectada.Size = New System.Drawing.Size(125, 19)
        Me.lbl_maquina_afectada.StateNormal.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_maquina_afectada.TabIndex = 3
        Me.lbl_maquina_afectada.Values.Text = "Maquina afectada:"
        '
        'cbo_solicitante
        '
        Me.cbo_solicitante.Location = New System.Drawing.Point(114, 32)
        Me.cbo_solicitante.Name = "cbo_solicitante"
        Me.cbo_solicitante.Size = New System.Drawing.Size(80, 19)
        Me.cbo_solicitante.StateNormal.LongText.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_solicitante.StateNormal.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_solicitante.TabIndex = 4
        Me.cbo_solicitante.Values.Text = "Solicitante:"
        '
        'btn_realizar
        '
        Me.btn_realizar.Location = New System.Drawing.Point(235, 400)
        Me.btn_realizar.Name = "btn_realizar"
        Me.btn_realizar.Size = New System.Drawing.Size(287, 38)
        Me.btn_realizar.TabIndex = 6
        Me.btn_realizar.Values.Text = "Realizar solicitud"
        '
        'KryptonGroupBox1
        '
        Me.KryptonGroupBox1.Location = New System.Drawing.Point(27, 12)
        Me.KryptonGroupBox1.Name = "KryptonGroupBox1"
        '
        'KryptonGroupBox1.Panel
        '
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.txt_solicitado)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.cbo_maquina_afec)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.cbo_operario_sol)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.cbo_solicitante)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.lbl_maquina_afectada)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.lbl_servicio_solicitado)
        Me.KryptonGroupBox1.Size = New System.Drawing.Size(722, 365)
        Me.KryptonGroupBox1.TabIndex = 7
        Me.KryptonGroupBox1.Values.Heading = "Mantenimiento"
        '
        'txt_solicitado
        '
        Me.txt_solicitado.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_solicitado.Location = New System.Drawing.Point(65, 162)
        Me.txt_solicitado.Multiline = True
        Me.txt_solicitado.Name = "txt_solicitado"
        Me.txt_solicitado.Size = New System.Drawing.Size(583, 157)
        Me.txt_solicitado.TabIndex = 7
        Me.txt_solicitado.Text = "Escribe el servicio de mantenimiento que necesitas"
        '
        'cbo_maquina_afec
        '
        Me.cbo_maquina_afec.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_maquina_afec.FormattingEnabled = True
        Me.cbo_maquina_afec.Location = New System.Drawing.Point(233, 79)
        Me.cbo_maquina_afec.Name = "cbo_maquina_afec"
        Me.cbo_maquina_afec.Size = New System.Drawing.Size(413, 26)
        Me.cbo_maquina_afec.TabIndex = 6
        Me.cbo_maquina_afec.Text = "Seleccione"
        '
        'cbo_operario_sol
        '
        Me.cbo_operario_sol.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_operario_sol.FormattingEnabled = True
        Me.cbo_operario_sol.Location = New System.Drawing.Point(233, 28)
        Me.cbo_operario_sol.Name = "cbo_operario_sol"
        Me.cbo_operario_sol.Size = New System.Drawing.Size(413, 26)
        Me.cbo_operario_sol.TabIndex = 5
        Me.cbo_operario_sol.Text = "Seleccione"
        '
        'KryptonPalette1
        '
        Me.KryptonPalette1.BasePaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.[Global]
        Me.KryptonPalette1.Common.StateCommon.Content.LongText.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KryptonPalette1.Common.StateCommon.Content.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KryptonPalette1.InputControlStyles.InputControlCommon.StateCommon.Content.LongText.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KryptonPalette1.InputControlStyles.InputControlCommon.StateCommon.Content.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KryptonPalette1.InputControlStyles.InputControlCommon.StateNormal.Content.LongText.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KryptonPalette1.InputControlStyles.InputControlCommon.StateNormal.Content.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'Frm_Mantenimiento_Planta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 450)
        Me.Controls.Add(Me.btn_realizar)
        Me.Controls.Add(Me.KryptonGroupBox1)
        Me.MaximizeBox = False
        Me.Name = "Frm_Mantenimiento_Planta"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Solicitar mantenimiento"
        CType(Me.KryptonGroupBox1.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox1.Panel.ResumeLayout(False)
        Me.KryptonGroupBox1.Panel.PerformLayout()
        CType(Me.KryptonGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lbl_servicio_solicitado As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents lbl_maquina_afectada As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents cbo_solicitante As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents btn_realizar As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents KryptonGroupBox1 As ComponentFactory.Krypton.Toolkit.KryptonGroupBox
    Friend WithEvents KryptonPalette1 As ComponentFactory.Krypton.Toolkit.KryptonPalette
    Friend WithEvents txt_solicitado As TextBox
    Friend WithEvents cbo_maquina_afec As ComboBox
    Friend WithEvents cbo_operario_sol As ComboBox
End Class
