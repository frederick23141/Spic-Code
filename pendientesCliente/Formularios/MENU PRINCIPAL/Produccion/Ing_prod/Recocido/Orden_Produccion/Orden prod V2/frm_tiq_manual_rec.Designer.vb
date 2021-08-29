<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_tiq_manual_rec
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
        Me.cbo_prod_final = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txt_peso = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btn_imprimir = New System.Windows.Forms.Button()
        Me.txt_trac_tref = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txt_trac_rec = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txt_diam = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txt_colada = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cbo_clase = New System.Windows.Forms.ComboBox()
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txt_cliente = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'cbo_prod_final
        '
        Me.cbo_prod_final.FormattingEnabled = True
        Me.cbo_prod_final.Location = New System.Drawing.Point(114, 34)
        Me.cbo_prod_final.Name = "cbo_prod_final"
        Me.cbo_prod_final.Size = New System.Drawing.Size(212, 21)
        Me.cbo_prod_final.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 15)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Producto final:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(7, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(321, 18)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "GENERAR TIQUETES ALAMBRE RECOCIDO"
        '
        'txt_peso
        '
        Me.txt_peso.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_peso.Location = New System.Drawing.Point(59, 296)
        Me.txt_peso.Name = "txt_peso"
        Me.txt_peso.Size = New System.Drawing.Size(132, 38)
        Me.txt_peso.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(10, 312)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 15)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Peso:"
        '
        'btn_imprimir
        '
        Me.btn_imprimir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_imprimir.Location = New System.Drawing.Point(197, 296)
        Me.btn_imprimir.Name = "btn_imprimir"
        Me.btn_imprimir.Size = New System.Drawing.Size(132, 38)
        Me.btn_imprimir.TabIndex = 6
        Me.btn_imprimir.Text = "Imprimir tiquete"
        Me.btn_imprimir.UseVisualStyleBackColor = True
        '
        'txt_trac_tref
        '
        Me.txt_trac_tref.Location = New System.Drawing.Point(114, 74)
        Me.txt_trac_tref.Name = "txt_trac_tref"
        Me.txt_trac_tref.Size = New System.Drawing.Size(212, 20)
        Me.txt_trac_tref.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(8, 75)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(95, 15)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Traccion Tref:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(8, 116)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(95, 15)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Traccion Rec:"
        '
        'txt_trac_rec
        '
        Me.txt_trac_rec.Location = New System.Drawing.Point(114, 115)
        Me.txt_trac_rec.Name = "txt_trac_rec"
        Me.txt_trac_rec.Size = New System.Drawing.Size(212, 20)
        Me.txt_trac_rec.TabIndex = 9
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(8, 151)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(70, 15)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Diametro:"
        '
        'txt_diam
        '
        Me.txt_diam.Location = New System.Drawing.Point(114, 150)
        Me.txt_diam.Name = "txt_diam"
        Me.txt_diam.Size = New System.Drawing.Size(212, 20)
        Me.txt_diam.TabIndex = 11
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(8, 186)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(56, 15)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Colada:"
        '
        'txt_colada
        '
        Me.txt_colada.Location = New System.Drawing.Point(114, 185)
        Me.txt_colada.Name = "txt_colada"
        Me.txt_colada.Size = New System.Drawing.Size(212, 20)
        Me.txt_colada.TabIndex = 13
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(12, 228)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(47, 15)
        Me.Label9.TabIndex = 18
        Me.Label9.Text = "Clase:"
        '
        'cbo_clase
        '
        Me.cbo_clase.FormattingEnabled = True
        Me.cbo_clase.Location = New System.Drawing.Point(114, 222)
        Me.cbo_clase.Name = "cbo_clase"
        Me.cbo_clase.Size = New System.Drawing.Size(214, 21)
        Me.cbo_clase.TabIndex = 17
        '
        'SerialPort1
        '
        Me.SerialPort1.WriteTimeout = 2000
        '
        'Timer1
        '
        Me.Timer1.Interval = 60
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(12, 263)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(52, 15)
        Me.Label8.TabIndex = 19
        Me.Label8.Text = "Ciente:"
        '
        'txt_cliente
        '
        Me.txt_cliente.Location = New System.Drawing.Point(114, 260)
        Me.txt_cliente.Name = "txt_cliente"
        Me.txt_cliente.Size = New System.Drawing.Size(212, 20)
        Me.txt_cliente.TabIndex = 20
        '
        'frm_tiq_manual_rec
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(335, 343)
        Me.Controls.Add(Me.txt_cliente)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.cbo_clase)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txt_colada)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txt_diam)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txt_trac_rec)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txt_trac_tref)
        Me.Controls.Add(Me.btn_imprimir)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txt_peso)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cbo_prod_final)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_tiq_manual_rec"
        Me.Text = "Generar Tiquetes Manuales"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cbo_prod_final As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_peso As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btn_imprimir As System.Windows.Forms.Button
    Friend WithEvents txt_trac_tref As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txt_trac_rec As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txt_diam As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txt_colada As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cbo_clase As System.Windows.Forms.ComboBox
    Friend WithEvents SerialPort1 As System.IO.Ports.SerialPort
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Label8 As Label
    Friend WithEvents txt_cliente As TextBox
End Class
