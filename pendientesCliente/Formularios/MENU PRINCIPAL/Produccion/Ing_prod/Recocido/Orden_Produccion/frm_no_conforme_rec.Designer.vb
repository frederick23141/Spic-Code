<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_no_conforme_rec
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
        Me.cbo_codigo = New System.Windows.Forms.ComboBox()
        Me.lbl_codigo = New System.Windows.Forms.Label()
        Me.lbl_peso = New System.Windows.Forms.Label()
        Me.btn_generar_noconforme = New System.Windows.Forms.Button()
        Me.lbl_traccion = New System.Windows.Forms.Label()
        Me.lbl_colada = New System.Windows.Forms.Label()
        Me.txt_traccion = New System.Windows.Forms.TextBox()
        Me.txt_colada = New System.Windows.Forms.TextBox()
        Me.txt_peso = New System.Windows.Forms.TextBox()
        Me.lbl_diametro = New System.Windows.Forms.Label()
        Me.txt_diametro = New System.Windows.Forms.TextBox()
        Me.txt_calidad = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.gp_noconforme = New System.Windows.Forms.GroupBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.gp_noconforme.SuspendLayout()
        Me.SuspendLayout()
        '
        'cbo_codigo
        '
        Me.cbo_codigo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbo_codigo.FormattingEnabled = True
        Me.cbo_codigo.Location = New System.Drawing.Point(148, 50)
        Me.cbo_codigo.Name = "cbo_codigo"
        Me.cbo_codigo.Size = New System.Drawing.Size(327, 21)
        Me.cbo_codigo.TabIndex = 0
        '
        'lbl_codigo
        '
        Me.lbl_codigo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_codigo.AutoSize = True
        Me.lbl_codigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_codigo.Location = New System.Drawing.Point(78, 53)
        Me.lbl_codigo.Name = "lbl_codigo"
        Me.lbl_codigo.Size = New System.Drawing.Size(50, 13)
        Me.lbl_codigo.TabIndex = 1
        Me.lbl_codigo.Text = "Codigo:"
        '
        'lbl_peso
        '
        Me.lbl_peso.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_peso.AutoSize = True
        Me.lbl_peso.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_peso.Location = New System.Drawing.Point(89, 96)
        Me.lbl_peso.Name = "lbl_peso"
        Me.lbl_peso.Size = New System.Drawing.Size(39, 13)
        Me.lbl_peso.TabIndex = 5
        Me.lbl_peso.Text = "Peso:"
        '
        'btn_generar_noconforme
        '
        Me.btn_generar_noconforme.Location = New System.Drawing.Point(206, 336)
        Me.btn_generar_noconforme.Name = "btn_generar_noconforme"
        Me.btn_generar_noconforme.Size = New System.Drawing.Size(126, 35)
        Me.btn_generar_noconforme.TabIndex = 6
        Me.btn_generar_noconforme.Text = "Generar"
        Me.btn_generar_noconforme.UseVisualStyleBackColor = True
        '
        'lbl_traccion
        '
        Me.lbl_traccion.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_traccion.AutoSize = True
        Me.lbl_traccion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_traccion.Location = New System.Drawing.Point(67, 132)
        Me.lbl_traccion.Name = "lbl_traccion"
        Me.lbl_traccion.Size = New System.Drawing.Size(61, 13)
        Me.lbl_traccion.TabIndex = 7
        Me.lbl_traccion.Text = "Traccion:"
        '
        'lbl_colada
        '
        Me.lbl_colada.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_colada.AutoSize = True
        Me.lbl_colada.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_colada.Location = New System.Drawing.Point(78, 176)
        Me.lbl_colada.Name = "lbl_colada"
        Me.lbl_colada.Size = New System.Drawing.Size(50, 13)
        Me.lbl_colada.TabIndex = 8
        Me.lbl_colada.Text = "Colada:"
        '
        'txt_traccion
        '
        Me.txt_traccion.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_traccion.Location = New System.Drawing.Point(148, 132)
        Me.txt_traccion.Name = "txt_traccion"
        Me.txt_traccion.Size = New System.Drawing.Size(329, 20)
        Me.txt_traccion.TabIndex = 9
        '
        'txt_colada
        '
        Me.txt_colada.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_colada.Location = New System.Drawing.Point(148, 169)
        Me.txt_colada.Name = "txt_colada"
        Me.txt_colada.Size = New System.Drawing.Size(329, 20)
        Me.txt_colada.TabIndex = 10
        '
        'txt_peso
        '
        Me.txt_peso.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_peso.Enabled = False
        Me.txt_peso.Location = New System.Drawing.Point(150, 93)
        Me.txt_peso.Name = "txt_peso"
        Me.txt_peso.Size = New System.Drawing.Size(327, 20)
        Me.txt_peso.TabIndex = 11
        '
        'lbl_diametro
        '
        Me.lbl_diametro.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_diametro.AutoSize = True
        Me.lbl_diametro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_diametro.Location = New System.Drawing.Point(67, 208)
        Me.lbl_diametro.Name = "lbl_diametro"
        Me.lbl_diametro.Size = New System.Drawing.Size(61, 13)
        Me.lbl_diametro.TabIndex = 12
        Me.lbl_diametro.Text = "Diametro:"
        '
        'txt_diametro
        '
        Me.txt_diametro.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_diametro.Location = New System.Drawing.Point(148, 205)
        Me.txt_diametro.Name = "txt_diametro"
        Me.txt_diametro.Size = New System.Drawing.Size(329, 20)
        Me.txt_diametro.TabIndex = 13
        '
        'txt_calidad
        '
        Me.txt_calidad.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_calidad.Location = New System.Drawing.Point(148, 236)
        Me.txt_calidad.Name = "txt_calidad"
        Me.txt_calidad.Size = New System.Drawing.Size(329, 20)
        Me.txt_calidad.TabIndex = 15
        '
        'Label3
        '
        Me.Label3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(75, 239)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 13)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Calidad:"
        '
        'gp_noconforme
        '
        Me.gp_noconforme.Controls.Add(Me.txt_traccion)
        Me.gp_noconforme.Controls.Add(Me.txt_peso)
        Me.gp_noconforme.Controls.Add(Me.lbl_traccion)
        Me.gp_noconforme.Controls.Add(Me.txt_diametro)
        Me.gp_noconforme.Controls.Add(Me.txt_colada)
        Me.gp_noconforme.Controls.Add(Me.lbl_peso)
        Me.gp_noconforme.Controls.Add(Me.lbl_colada)
        Me.gp_noconforme.Controls.Add(Me.txt_calidad)
        Me.gp_noconforme.Controls.Add(Me.lbl_diametro)
        Me.gp_noconforme.Controls.Add(Me.lbl_codigo)
        Me.gp_noconforme.Controls.Add(Me.Label3)
        Me.gp_noconforme.Controls.Add(Me.cbo_codigo)
        Me.gp_noconforme.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gp_noconforme.Location = New System.Drawing.Point(12, 12)
        Me.gp_noconforme.Name = "gp_noconforme"
        Me.gp_noconforme.Size = New System.Drawing.Size(503, 295)
        Me.gp_noconforme.TabIndex = 16
        Me.gp_noconforme.TabStop = False
        Me.gp_noconforme.Text = "Información rollo"
        '
        'Timer1
        '
        Me.Timer1.Interval = 60
        '
        'SerialPort1
        '
        Me.SerialPort1.WriteTimeout = 2000
        '
        'frm_no_conforme_rec
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(527, 426)
        Me.Controls.Add(Me.btn_generar_noconforme)
        Me.Controls.Add(Me.gp_noconforme)
        Me.Name = "frm_no_conforme_rec"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "No conforme recocido"
        Me.gp_noconforme.ResumeLayout(False)
        Me.gp_noconforme.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cbo_codigo As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_codigo As System.Windows.Forms.Label
    Friend WithEvents lbl_peso As System.Windows.Forms.Label
    Friend WithEvents btn_generar_noconforme As System.Windows.Forms.Button
    Friend WithEvents lbl_traccion As System.Windows.Forms.Label
    Friend WithEvents lbl_colada As System.Windows.Forms.Label
    Friend WithEvents txt_traccion As System.Windows.Forms.TextBox
    Friend WithEvents txt_colada As System.Windows.Forms.TextBox
    Friend WithEvents txt_peso As System.Windows.Forms.TextBox
    Friend WithEvents lbl_diametro As System.Windows.Forms.Label
    Friend WithEvents txt_diametro As System.Windows.Forms.TextBox
    Friend WithEvents txt_calidad As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents gp_noconforme As System.Windows.Forms.GroupBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents SerialPort1 As System.IO.Ports.SerialPort
End Class
