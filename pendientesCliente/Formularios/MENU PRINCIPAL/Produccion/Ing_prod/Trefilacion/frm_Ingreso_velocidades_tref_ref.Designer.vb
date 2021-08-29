<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Ingreso_velocidades_tref_ref
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboMaquinaConsulta = New System.Windows.Forms.ComboBox()
        Me.cbo_Referencia = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txt_Velocidad = New System.Windows.Forms.TextBox()
        Me.btn_guardar = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(56, 54)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Trefiladora:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(55, 115)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Referencia:"
        '
        'cboMaquinaConsulta
        '
        Me.cboMaquinaConsulta.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboMaquinaConsulta.FormattingEnabled = True
        Me.cboMaquinaConsulta.Location = New System.Drawing.Point(134, 51)
        Me.cboMaquinaConsulta.Name = "cboMaquinaConsulta"
        Me.cboMaquinaConsulta.Size = New System.Drawing.Size(111, 21)
        Me.cboMaquinaConsulta.TabIndex = 2117
        Me.cboMaquinaConsulta.Text = "Seleccione"
        '
        'cbo_Referencia
        '
        Me.cbo_Referencia.FormattingEnabled = True
        Me.cbo_Referencia.Location = New System.Drawing.Point(135, 112)
        Me.cbo_Referencia.Name = "cbo_Referencia"
        Me.cbo_Referencia.Size = New System.Drawing.Size(110, 21)
        Me.cbo_Referencia.TabIndex = 2118
        Me.cbo_Referencia.Text = "Seleccione"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(54, 167)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 13)
        Me.Label3.TabIndex = 2119
        Me.Label3.Text = "Veleocidad:"
        '
        'txt_Velocidad
        '
        Me.txt_Velocidad.Location = New System.Drawing.Point(134, 164)
        Me.txt_Velocidad.Name = "txt_Velocidad"
        Me.txt_Velocidad.Size = New System.Drawing.Size(110, 20)
        Me.txt_Velocidad.TabIndex = 2120
        '
        'btn_guardar
        '
        Me.btn_guardar.Location = New System.Drawing.Point(101, 211)
        Me.btn_guardar.Name = "btn_guardar"
        Me.btn_guardar.Size = New System.Drawing.Size(75, 23)
        Me.btn_guardar.TabIndex = 2121
        Me.btn_guardar.Text = "Guardar"
        Me.btn_guardar.UseVisualStyleBackColor = True
        '
        'frm_Ingreso_velocidades_tref_ref
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 261)
        Me.Controls.Add(Me.btn_guardar)
        Me.Controls.Add(Me.txt_Velocidad)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cbo_Referencia)
        Me.Controls.Add(Me.cboMaquinaConsulta)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frm_Ingreso_velocidades_tref_ref"
        Me.Text = "Ingreso de velocidades"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboMaquinaConsulta As System.Windows.Forms.ComboBox
    Friend WithEvents cbo_Referencia As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txt_Velocidad As System.Windows.Forms.TextBox
    Friend WithEvents btn_guardar As System.Windows.Forms.Button
End Class
