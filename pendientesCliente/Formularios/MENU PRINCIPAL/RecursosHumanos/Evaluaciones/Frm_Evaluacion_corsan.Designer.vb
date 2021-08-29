<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Evaluacion_corsan
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
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tb_Evaluacion1 = New System.Windows.Forms.TabPage()
        Me.btn_contraseña = New System.Windows.Forms.Button()
        Me.txt_continuar = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.gp_Evaluar = New System.Windows.Forms.GroupBox()
        Me.cbo_evaluador = New System.Windows.Forms.ComboBox()
        Me.lbl_evaluador = New System.Windows.Forms.Label()
        Me.lbl_tipo_evaluacion = New System.Windows.Forms.Label()
        Me.cbo_tipo_Evaluacion = New System.Windows.Forms.ComboBox()
        Me.cbo_empleados = New System.Windows.Forms.ComboBox()
        Me.lbl_evaluado = New System.Windows.Forms.Label()
        Me.gb_contraseña = New System.Windows.Forms.GroupBox()
        Me.txt_contraseña = New System.Windows.Forms.TextBox()
        Me.lbl_contraseña = New System.Windows.Forms.Label()
        Me.ep_evaluacion = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.TabControl1.SuspendLayout()
        Me.tb_Evaluacion1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gp_Evaluar.SuspendLayout()
        Me.gb_contraseña.SuspendLayout()
        CType(Me.ep_evaluacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.tb_Evaluacion1)
        Me.TabControl1.Location = New System.Drawing.Point(12, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(860, 553)
        Me.TabControl1.TabIndex = 0
        '
        'tb_Evaluacion1
        '
        Me.tb_Evaluacion1.BackColor = System.Drawing.Color.DarkGray
        Me.tb_Evaluacion1.Controls.Add(Me.btn_contraseña)
        Me.tb_Evaluacion1.Controls.Add(Me.txt_continuar)
        Me.tb_Evaluacion1.Controls.Add(Me.PictureBox1)
        Me.tb_Evaluacion1.Controls.Add(Me.gp_Evaluar)
        Me.tb_Evaluacion1.Controls.Add(Me.gb_contraseña)
        Me.tb_Evaluacion1.Location = New System.Drawing.Point(4, 22)
        Me.tb_Evaluacion1.Name = "tb_Evaluacion1"
        Me.tb_Evaluacion1.Padding = New System.Windows.Forms.Padding(3)
        Me.tb_Evaluacion1.Size = New System.Drawing.Size(852, 527)
        Me.tb_Evaluacion1.TabIndex = 0
        Me.tb_Evaluacion1.Text = "Principal"
        '
        'btn_contraseña
        '
        Me.btn_contraseña.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_contraseña.Location = New System.Drawing.Point(369, 376)
        Me.btn_contraseña.Name = "btn_contraseña"
        Me.btn_contraseña.Size = New System.Drawing.Size(116, 23)
        Me.btn_contraseña.TabIndex = 7
        Me.btn_contraseña.Text = "Pedir contraseña"
        Me.btn_contraseña.UseVisualStyleBackColor = True
        Me.btn_contraseña.Visible = False
        '
        'txt_continuar
        '
        Me.txt_continuar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_continuar.Location = New System.Drawing.Point(707, 446)
        Me.txt_continuar.Name = "txt_continuar"
        Me.txt_continuar.Size = New System.Drawing.Size(120, 68)
        Me.txt_continuar.TabIndex = 4
        Me.txt_continuar.Text = "Continuar"
        Me.txt_continuar.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Spic.My.Resources.Resources.Corsan1
        Me.PictureBox1.Location = New System.Drawing.Point(274, 31)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(291, 154)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'gp_Evaluar
        '
        Me.gp_Evaluar.BackColor = System.Drawing.Color.DarkGray
        Me.gp_Evaluar.Controls.Add(Me.cbo_evaluador)
        Me.gp_Evaluar.Controls.Add(Me.lbl_evaluador)
        Me.gp_Evaluar.Controls.Add(Me.lbl_tipo_evaluacion)
        Me.gp_Evaluar.Controls.Add(Me.cbo_tipo_Evaluacion)
        Me.gp_Evaluar.Controls.Add(Me.cbo_empleados)
        Me.gp_Evaluar.Controls.Add(Me.lbl_evaluado)
        Me.gp_Evaluar.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.gp_Evaluar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gp_Evaluar.Location = New System.Drawing.Point(196, 200)
        Me.gp_Evaluar.Name = "gp_Evaluar"
        Me.gp_Evaluar.Size = New System.Drawing.Size(447, 170)
        Me.gp_Evaluar.TabIndex = 3
        Me.gp_Evaluar.TabStop = False
        Me.gp_Evaluar.Text = "Información de evaluación"
        '
        'cbo_evaluador
        '
        Me.cbo_evaluador.FormattingEnabled = True
        Me.cbo_evaluador.Location = New System.Drawing.Point(158, 127)
        Me.cbo_evaluador.Name = "cbo_evaluador"
        Me.cbo_evaluador.Size = New System.Drawing.Size(221, 21)
        Me.cbo_evaluador.TabIndex = 7
        '
        'lbl_evaluador
        '
        Me.lbl_evaluador.AutoSize = True
        Me.lbl_evaluador.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_evaluador.Location = New System.Drawing.Point(80, 130)
        Me.lbl_evaluador.Name = "lbl_evaluador"
        Me.lbl_evaluador.Size = New System.Drawing.Size(68, 13)
        Me.lbl_evaluador.TabIndex = 6
        Me.lbl_evaluador.Text = "Evaluador:"
        '
        'lbl_tipo_evaluacion
        '
        Me.lbl_tipo_evaluacion.AutoSize = True
        Me.lbl_tipo_evaluacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_tipo_evaluacion.Location = New System.Drawing.Point(52, 41)
        Me.lbl_tipo_evaluacion.Name = "lbl_tipo_evaluacion"
        Me.lbl_tipo_evaluacion.Size = New System.Drawing.Size(102, 13)
        Me.lbl_tipo_evaluacion.TabIndex = 5
        Me.lbl_tipo_evaluacion.Text = "Tipo evaluación:"
        '
        'cbo_tipo_Evaluacion
        '
        Me.cbo_tipo_Evaluacion.FormattingEnabled = True
        Me.cbo_tipo_Evaluacion.Items.AddRange(New Object() {"Evaluación x Jefe", "Evaluacion x Compañero", "Autoevaluacion"})
        Me.cbo_tipo_Evaluacion.Location = New System.Drawing.Point(158, 38)
        Me.cbo_tipo_Evaluacion.Name = "cbo_tipo_Evaluacion"
        Me.cbo_tipo_Evaluacion.Size = New System.Drawing.Size(221, 21)
        Me.cbo_tipo_Evaluacion.TabIndex = 4
        '
        'cbo_empleados
        '
        Me.cbo_empleados.FormattingEnabled = True
        Me.cbo_empleados.Location = New System.Drawing.Point(158, 86)
        Me.cbo_empleados.Name = "cbo_empleados"
        Me.cbo_empleados.Size = New System.Drawing.Size(221, 21)
        Me.cbo_empleados.TabIndex = 3
        '
        'lbl_evaluado
        '
        Me.lbl_evaluado.AutoSize = True
        Me.lbl_evaluado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_evaluado.Location = New System.Drawing.Point(80, 89)
        Me.lbl_evaluado.Name = "lbl_evaluado"
        Me.lbl_evaluado.Size = New System.Drawing.Size(64, 13)
        Me.lbl_evaluado.TabIndex = 2
        Me.lbl_evaluado.Text = "Evaluado:"
        '
        'gb_contraseña
        '
        Me.gb_contraseña.Controls.Add(Me.txt_contraseña)
        Me.gb_contraseña.Controls.Add(Me.lbl_contraseña)
        Me.gb_contraseña.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gb_contraseña.Location = New System.Drawing.Point(295, 421)
        Me.gb_contraseña.Name = "gb_contraseña"
        Me.gb_contraseña.Size = New System.Drawing.Size(254, 100)
        Me.gb_contraseña.TabIndex = 6
        Me.gb_contraseña.TabStop = False
        Me.gb_contraseña.Text = "Contraseña autoevaluación"
        Me.gb_contraseña.Visible = False
        '
        'txt_contraseña
        '
        Me.txt_contraseña.Location = New System.Drawing.Point(118, 43)
        Me.txt_contraseña.Name = "txt_contraseña"
        Me.txt_contraseña.Size = New System.Drawing.Size(100, 20)
        Me.txt_contraseña.TabIndex = 6
        '
        'lbl_contraseña
        '
        Me.lbl_contraseña.AutoSize = True
        Me.lbl_contraseña.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_contraseña.Location = New System.Drawing.Point(35, 46)
        Me.lbl_contraseña.Name = "lbl_contraseña"
        Me.lbl_contraseña.Size = New System.Drawing.Size(75, 13)
        Me.lbl_contraseña.TabIndex = 5
        Me.lbl_contraseña.Text = "Contraseña:"
        '
        'ep_evaluacion
        '
        Me.ep_evaluacion.ContainerControl = Me
        '
        'Frm_Evaluacion_corsan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(884, 577)
        Me.Controls.Add(Me.TabControl1)
        Me.MaximizeBox = False
        Me.Name = "Frm_Evaluacion_corsan"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Evaluación de desempeño para el personal de Corsan SA"
        Me.TabControl1.ResumeLayout(False)
        Me.tb_Evaluacion1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gp_Evaluar.ResumeLayout(False)
        Me.gp_Evaluar.PerformLayout()
        Me.gb_contraseña.ResumeLayout(False)
        Me.gb_contraseña.PerformLayout()
        CType(Me.ep_evaluacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tb_Evaluacion1 As System.Windows.Forms.TabPage
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents txt_continuar As System.Windows.Forms.Button
    Friend WithEvents gp_Evaluar As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_evaluado As System.Windows.Forms.Label
    Friend WithEvents ep_evaluacion As System.Windows.Forms.ErrorProvider
    Friend WithEvents cbo_empleados As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_tipo_evaluacion As System.Windows.Forms.Label
    Friend WithEvents cbo_tipo_Evaluacion As System.Windows.Forms.ComboBox
    Friend WithEvents cbo_evaluador As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_evaluador As System.Windows.Forms.Label
    Friend WithEvents gb_contraseña As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_contraseña As System.Windows.Forms.Label
    Friend WithEvents btn_contraseña As System.Windows.Forms.Button
    Friend WithEvents txt_contraseña As System.Windows.Forms.TextBox
End Class
