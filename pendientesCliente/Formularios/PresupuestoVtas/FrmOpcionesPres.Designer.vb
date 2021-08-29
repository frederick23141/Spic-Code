<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmOpcionesPres
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
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.cboMes = New System.Windows.Forms.ComboBox()
        Me.cboAño = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chk12M = New System.Windows.Forms.CheckBox()
        Me.chk6M = New System.Windows.Forms.CheckBox()
        Me.chk3M = New System.Windows.Forms.CheckBox()
        Me.btnGenerar = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.ChkPesosVend = New System.Windows.Forms.CheckBox()
        Me.chkKilVend = New System.Windows.Forms.CheckBox()
        Me.cboVend = New System.Windows.Forms.ComboBox()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label37)
        Me.GroupBox2.Controls.Add(Me.Label30)
        Me.GroupBox2.Controls.Add(Me.cboMes)
        Me.GroupBox2.Controls.Add(Me.cboAño)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(55, 109)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.GroupBox2.Size = New System.Drawing.Size(183, 63)
        Me.GroupBox2.TabIndex = 110
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Mes presupuesto"
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(110, 17)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(29, 13)
        Me.Label37.TabIndex = 44
        Me.Label37.Text = "Año"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(6, 16)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(30, 13)
        Me.Label30.TabIndex = 41
        Me.Label30.Text = "Mes"
        '
        'cboMes
        '
        Me.cboMes.FormattingEnabled = True
        Me.cboMes.Items.AddRange(New Object() {"Enero ", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"})
        Me.cboMes.Location = New System.Drawing.Point(9, 34)
        Me.cboMes.Name = "cboMes"
        Me.cboMes.Size = New System.Drawing.Size(91, 21)
        Me.cboMes.TabIndex = 34
        '
        'cboAño
        '
        Me.cboAño.FormattingEnabled = True
        Me.cboAño.Location = New System.Drawing.Point(113, 35)
        Me.cboAño.Name = "cboAño"
        Me.cboAño.Size = New System.Drawing.Size(63, 21)
        Me.cboAño.TabIndex = 35
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(35, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(222, 24)
        Me.Label1.TabIndex = 111
        Me.Label1.Text = "Opciones presupuesto"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chk12M)
        Me.GroupBox1.Controls.Add(Me.chk6M)
        Me.GroupBox1.Controls.Add(Me.chk3M)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(71, 187)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(150, 100)
        Me.GroupBox1.TabIndex = 112
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "En base a los ultimos"
        '
        'chk12M
        '
        Me.chk12M.AutoSize = True
        Me.chk12M.Location = New System.Drawing.Point(34, 65)
        Me.chk12M.Name = "chk12M"
        Me.chk12M.Size = New System.Drawing.Size(80, 17)
        Me.chk12M.TabIndex = 2
        Me.chk12M.Text = "12 Meses"
        Me.chk12M.UseVisualStyleBackColor = True
        '
        'chk6M
        '
        Me.chk6M.AutoSize = True
        Me.chk6M.Location = New System.Drawing.Point(34, 42)
        Me.chk6M.Name = "chk6M"
        Me.chk6M.Size = New System.Drawing.Size(73, 17)
        Me.chk6M.TabIndex = 1
        Me.chk6M.Text = "6 Meses"
        Me.chk6M.UseVisualStyleBackColor = True
        '
        'chk3M
        '
        Me.chk3M.AutoSize = True
        Me.chk3M.Location = New System.Drawing.Point(34, 19)
        Me.chk3M.Name = "chk3M"
        Me.chk3M.Size = New System.Drawing.Size(73, 17)
        Me.chk3M.TabIndex = 0
        Me.chk3M.Text = "3 Meses"
        Me.chk3M.UseVisualStyleBackColor = True
        '
        'btnGenerar
        '
        Me.btnGenerar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerar.Image = Global.Spic.My.Resources.Resources.mas
        Me.btnGenerar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGenerar.Location = New System.Drawing.Point(109, 295)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(75, 23)
        Me.btnGenerar.TabIndex = 113
        Me.btnGenerar.Text = "Generar"
        Me.btnGenerar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGenerar.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.ChkPesosVend)
        Me.GroupBox3.Controls.Add(Me.chkKilVend)
        Me.GroupBox3.Controls.Add(Me.cboVend)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(45, 47)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(202, 56)
        Me.GroupBox3.TabIndex = 115
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Vendedor"
        '
        'ChkPesosVend
        '
        Me.ChkPesosVend.AutoSize = True
        Me.ChkPesosVend.Location = New System.Drawing.Point(135, 14)
        Me.ChkPesosVend.Name = "ChkPesosVend"
        Me.ChkPesosVend.Size = New System.Drawing.Size(60, 17)
        Me.ChkPesosVend.TabIndex = 117
        Me.ChkPesosVend.Text = "Pesos"
        Me.ChkPesosVend.UseVisualStyleBackColor = True
        '
        'chkKilVend
        '
        Me.chkKilVend.AutoSize = True
        Me.chkKilVend.Location = New System.Drawing.Point(135, 31)
        Me.chkKilVend.Name = "chkKilVend"
        Me.chkKilVend.Size = New System.Drawing.Size(53, 17)
        Me.chkKilVend.TabIndex = 116
        Me.chkKilVend.Text = "Kilos"
        Me.chkKilVend.UseVisualStyleBackColor = True
        '
        'cboVend
        '
        Me.cboVend.FormattingEnabled = True
        Me.cboVend.Location = New System.Drawing.Point(6, 19)
        Me.cboVend.Name = "cboVend"
        Me.cboVend.Size = New System.Drawing.Size(121, 21)
        Me.cboVend.TabIndex = 35
        '
        'FrmOpcionesPres
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(292, 331)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.btnGenerar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Name = "FrmOpcionesPres"
        Me.Text = "FrmOpcionesPres"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents cboMes As System.Windows.Forms.ComboBox
    Friend WithEvents cboAño As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents chk12M As System.Windows.Forms.CheckBox
    Friend WithEvents chk6M As System.Windows.Forms.CheckBox
    Friend WithEvents chk3M As System.Windows.Forms.CheckBox
    Friend WithEvents btnGenerar As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cboVend As System.Windows.Forms.ComboBox
    Friend WithEvents ChkPesosVend As System.Windows.Forms.CheckBox
    Friend WithEvents chkKilVend As System.Windows.Forms.CheckBox
End Class
