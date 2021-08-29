<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_transacion_bodega_G
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
        Me.cbobobina = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.imgTipo = New System.Windows.Forms.PictureBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboTipo = New System.Windows.Forms.ComboBox()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.txtKilos = New System.Windows.Forms.TextBox()
        Me.lblDescipcion = New System.Windows.Forms.Label()
        Me.lblCodigo = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtCodigoLector = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        CType(Me.imgTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'cbobobina
        '
        Me.cbobobina.FormattingEnabled = True
        Me.cbobobina.Location = New System.Drawing.Point(204, 175)
        Me.cbobobina.Name = "cbobobina"
        Me.cbobobina.Size = New System.Drawing.Size(63, 21)
        Me.cbobobina.TabIndex = 1122
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(142, 181)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 15)
        Me.Label1.TabIndex = 1121
        Me.Label1.Text = "Bobina:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.imgTipo)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.cboTipo)
        Me.GroupBox1.Controls.Add(Me.btnGuardar)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 202)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(425, 59)
        Me.GroupBox1.TabIndex = 1120
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos de la transacción"
        '
        'imgTipo
        '
        Me.imgTipo.Image = Global.Spic.My.Resources.Resources._1371750041_14125
        Me.imgTipo.Location = New System.Drawing.Point(175, 19)
        Me.imgTipo.Name = "imgTipo"
        Me.imgTipo.Size = New System.Drawing.Size(15, 17)
        Me.imgTipo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgTipo.TabIndex = 1067
        Me.imgTipo.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(-1, 25)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(36, 13)
        Me.Label4.TabIndex = 1061
        Me.Label4.Text = "Tipo:"
        '
        'cboTipo
        '
        Me.cboTipo.AutoCompleteCustomSource.AddRange(New String() {"1", "2", "3", "7"})
        Me.cboTipo.Enabled = False
        Me.cboTipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTipo.FormattingEnabled = True
        Me.cboTipo.Items.AddRange(New Object() {""})
        Me.cboTipo.Location = New System.Drawing.Point(41, 19)
        Me.cboTipo.Name = "cboTipo"
        Me.cboTipo.Size = New System.Drawing.Size(128, 28)
        Me.cboTipo.TabIndex = 1062
        Me.cboTipo.Text = "Seleccione"
        '
        'btnGuardar
        '
        Me.btnGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardar.Image = Global.Spic.My.Resources.Resources.ok3
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGuardar.Location = New System.Drawing.Point(241, 9)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(143, 44)
        Me.btnGuardar.TabIndex = 1092
        Me.btnGuardar.Text = "Transacción"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'txtKilos
        '
        Me.txtKilos.Enabled = False
        Me.txtKilos.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtKilos.Location = New System.Drawing.Point(254, 34)
        Me.txtKilos.MaxLength = 4
        Me.txtKilos.Name = "txtKilos"
        Me.txtKilos.ReadOnly = True
        Me.txtKilos.Size = New System.Drawing.Size(117, 26)
        Me.txtKilos.TabIndex = 1116
        '
        'lblDescipcion
        '
        Me.lblDescipcion.AutoSize = True
        Me.lblDescipcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescipcion.Location = New System.Drawing.Point(67, 131)
        Me.lblDescipcion.Name = "lblDescipcion"
        Me.lblDescipcion.Size = New System.Drawing.Size(94, 15)
        Me.lblDescipcion.TabIndex = 1119
        Me.lblDescipcion.Text = "lblDescipcion"
        '
        'lblCodigo
        '
        Me.lblCodigo.AutoSize = True
        Me.lblCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodigo.Location = New System.Drawing.Point(67, 96)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(75, 16)
        Me.lblCodigo.TabIndex = 1118
        Me.lblCodigo.Text = "lblCodigo"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtCodigoLector)
        Me.GroupBox2.Location = New System.Drawing.Point(28, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(180, 68)
        Me.GroupBox2.TabIndex = 1117
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Lector "
        '
        'txtCodigoLector
        '
        Me.txtCodigoLector.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigoLector.Location = New System.Drawing.Point(6, 22)
        Me.txtCodigoLector.Name = "txtCodigoLector"
        Me.txtCodigoLector.Size = New System.Drawing.Size(169, 24)
        Me.txtCodigoLector.TabIndex = 1074
        '
        'Frm_transacion_bodega_G
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(451, 273)
        Me.Controls.Add(Me.cbobobina)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txtKilos)
        Me.Controls.Add(Me.lblDescipcion)
        Me.Controls.Add(Me.lblCodigo)
        Me.Controls.Add(Me.GroupBox2)
        Me.Name = "Frm_transacion_bodega_G"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Transacción de consumo galvanizado"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.imgTipo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cbobobina As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents imgTipo As System.Windows.Forms.PictureBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboTipo As System.Windows.Forms.ComboBox
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents txtKilos As System.Windows.Forms.TextBox
    Friend WithEvents lblDescipcion As System.Windows.Forms.Label
    Friend WithEvents lblCodigo As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtCodigoLector As System.Windows.Forms.TextBox
End Class
