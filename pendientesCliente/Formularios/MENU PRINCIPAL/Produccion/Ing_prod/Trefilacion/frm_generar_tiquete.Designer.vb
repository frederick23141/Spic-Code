<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_generar_tiquete
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
        Me.lbl_peso = New System.Windows.Forms.Label()
        Me.gb_rollos = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txtcolada = New System.Windows.Forms.TextBox()
        Me.lbl_colada = New System.Windows.Forms.Label()
        Me.txt_calibre = New System.Windows.Forms.TextBox()
        Me.lbl_calibre = New System.Windows.Forms.Label()
        Me.txt_tracc = New System.Windows.Forms.TextBox()
        Me.lbl_traccion = New System.Windows.Forms.Label()
        Me.txt_peso = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txt_nro_plani = New System.Windows.Forms.TextBox()
        Me.txt_nro_orden = New System.Windows.Forms.TextBox()
        Me.lbl_planilla = New System.Windows.Forms.Label()
        Me.lbl_orden = New System.Windows.Forms.Label()
        Me.lbl_cliente = New System.Windows.Forms.Label()
        Me.txt_clientes = New System.Windows.Forms.TextBox()
        Me.gb_rollos.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbl_peso
        '
        Me.lbl_peso.AutoSize = True
        Me.lbl_peso.Location = New System.Drawing.Point(59, 23)
        Me.lbl_peso.Name = "lbl_peso"
        Me.lbl_peso.Size = New System.Drawing.Size(34, 13)
        Me.lbl_peso.TabIndex = 0
        Me.lbl_peso.Text = "Peso:"
        '
        'gb_rollos
        '
        Me.gb_rollos.Controls.Add(Me.txt_clientes)
        Me.gb_rollos.Controls.Add(Me.Button1)
        Me.gb_rollos.Controls.Add(Me.txtcolada)
        Me.gb_rollos.Controls.Add(Me.lbl_colada)
        Me.gb_rollos.Controls.Add(Me.txt_calibre)
        Me.gb_rollos.Controls.Add(Me.lbl_calibre)
        Me.gb_rollos.Controls.Add(Me.txt_tracc)
        Me.gb_rollos.Controls.Add(Me.lbl_traccion)
        Me.gb_rollos.Controls.Add(Me.txt_peso)
        Me.gb_rollos.Controls.Add(Me.lbl_peso)
        Me.gb_rollos.ForeColor = System.Drawing.SystemColors.ControlText
        Me.gb_rollos.Location = New System.Drawing.Point(12, 112)
        Me.gb_rollos.Name = "gb_rollos"
        Me.gb_rollos.Size = New System.Drawing.Size(260, 237)
        Me.gb_rollos.TabIndex = 1
        Me.gb_rollos.TabStop = False
        Me.gb_rollos.Text = "Información rollos"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(73, 208)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(106, 23)
        Me.Button1.TabIndex = 7
        Me.Button1.Text = "Generar tiquete"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txtcolada
        '
        Me.txtcolada.Location = New System.Drawing.Point(99, 138)
        Me.txtcolada.Name = "txtcolada"
        Me.txtcolada.Size = New System.Drawing.Size(100, 20)
        Me.txtcolada.TabIndex = 2
        '
        'lbl_colada
        '
        Me.lbl_colada.AutoSize = True
        Me.lbl_colada.Location = New System.Drawing.Point(49, 141)
        Me.lbl_colada.Name = "lbl_colada"
        Me.lbl_colada.Size = New System.Drawing.Size(42, 13)
        Me.lbl_colada.TabIndex = 6
        Me.lbl_colada.Text = "colada:"
        '
        'txt_calibre
        '
        Me.txt_calibre.Location = New System.Drawing.Point(99, 99)
        Me.txt_calibre.Name = "txt_calibre"
        Me.txt_calibre.Size = New System.Drawing.Size(100, 20)
        Me.txt_calibre.TabIndex = 5
        '
        'lbl_calibre
        '
        Me.lbl_calibre.AutoSize = True
        Me.lbl_calibre.Location = New System.Drawing.Point(48, 102)
        Me.lbl_calibre.Name = "lbl_calibre"
        Me.lbl_calibre.Size = New System.Drawing.Size(42, 13)
        Me.lbl_calibre.TabIndex = 4
        Me.lbl_calibre.Text = "Calibre:"
        '
        'txt_tracc
        '
        Me.txt_tracc.Location = New System.Drawing.Point(99, 61)
        Me.txt_tracc.Name = "txt_tracc"
        Me.txt_tracc.Size = New System.Drawing.Size(100, 20)
        Me.txt_tracc.TabIndex = 3
        '
        'lbl_traccion
        '
        Me.lbl_traccion.AutoSize = True
        Me.lbl_traccion.Location = New System.Drawing.Point(41, 64)
        Me.lbl_traccion.Name = "lbl_traccion"
        Me.lbl_traccion.Size = New System.Drawing.Size(52, 13)
        Me.lbl_traccion.TabIndex = 2
        Me.lbl_traccion.Text = "Traccion:"
        '
        'txt_peso
        '
        Me.txt_peso.Location = New System.Drawing.Point(99, 20)
        Me.txt_peso.Name = "txt_peso"
        Me.txt_peso.Size = New System.Drawing.Size(100, 20)
        Me.txt_peso.TabIndex = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txt_nro_plani)
        Me.GroupBox1.Controls.Add(Me.txt_nro_orden)
        Me.GroupBox1.Controls.Add(Me.lbl_planilla)
        Me.GroupBox1.Controls.Add(Me.lbl_orden)
        Me.GroupBox1.Location = New System.Drawing.Point(11, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(261, 100)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Información orden"
        '
        'txt_nro_plani
        '
        Me.txt_nro_plani.Enabled = False
        Me.txt_nro_plani.Location = New System.Drawing.Point(100, 59)
        Me.txt_nro_plani.Name = "txt_nro_plani"
        Me.txt_nro_plani.Size = New System.Drawing.Size(100, 20)
        Me.txt_nro_plani.TabIndex = 3
        '
        'txt_nro_orden
        '
        Me.txt_nro_orden.Enabled = False
        Me.txt_nro_orden.Location = New System.Drawing.Point(100, 24)
        Me.txt_nro_orden.Name = "txt_nro_orden"
        Me.txt_nro_orden.Size = New System.Drawing.Size(100, 20)
        Me.txt_nro_orden.TabIndex = 2
        '
        'lbl_planilla
        '
        Me.lbl_planilla.AutoSize = True
        Me.lbl_planilla.Location = New System.Drawing.Point(33, 62)
        Me.lbl_planilla.Name = "lbl_planilla"
        Me.lbl_planilla.Size = New System.Drawing.Size(60, 13)
        Me.lbl_planilla.TabIndex = 1
        Me.lbl_planilla.Text = "nro planilla:"
        '
        'lbl_orden
        '
        Me.lbl_orden.AutoSize = True
        Me.lbl_orden.Location = New System.Drawing.Point(38, 29)
        Me.lbl_orden.Name = "lbl_orden"
        Me.lbl_orden.Size = New System.Drawing.Size(55, 13)
        Me.lbl_orden.TabIndex = 0
        Me.lbl_orden.Text = "nro orden:"
        '
        'lbl_cliente
        '
        Me.lbl_cliente.AutoSize = True
        Me.lbl_cliente.Location = New System.Drawing.Point(58, 287)
        Me.lbl_cliente.Name = "lbl_cliente"
        Me.lbl_cliente.Size = New System.Drawing.Size(42, 13)
        Me.lbl_cliente.TabIndex = 3
        Me.lbl_cliente.Text = "Cliente:"
        '
        'txt_clientes
        '
        Me.txt_clientes.Location = New System.Drawing.Point(99, 172)
        Me.txt_clientes.Name = "txt_clientes"
        Me.txt_clientes.Size = New System.Drawing.Size(100, 20)
        Me.txt_clientes.TabIndex = 8
        '
        'frm_generar_tiquete
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(280, 359)
        Me.Controls.Add(Me.lbl_cliente)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.gb_rollos)
        Me.Name = "frm_generar_tiquete"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Generar tiquete"
        Me.gb_rollos.ResumeLayout(False)
        Me.gb_rollos.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbl_peso As System.Windows.Forms.Label
    Friend WithEvents gb_rollos As System.Windows.Forms.GroupBox
    Friend WithEvents txt_peso As System.Windows.Forms.TextBox
    Friend WithEvents txt_tracc As System.Windows.Forms.TextBox
    Friend WithEvents lbl_traccion As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txtcolada As System.Windows.Forms.TextBox
    Friend WithEvents lbl_colada As System.Windows.Forms.Label
    Friend WithEvents txt_calibre As System.Windows.Forms.TextBox
    Friend WithEvents lbl_calibre As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_nro_plani As System.Windows.Forms.TextBox
    Friend WithEvents txt_nro_orden As System.Windows.Forms.TextBox
    Friend WithEvents lbl_planilla As System.Windows.Forms.Label
    Friend WithEvents lbl_orden As System.Windows.Forms.Label
    Friend WithEvents txt_clientes As TextBox
    Friend WithEvents lbl_cliente As Label
End Class
